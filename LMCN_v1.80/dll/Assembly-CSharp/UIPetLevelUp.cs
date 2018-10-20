using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200046E RID: 1134
internal class UIPetLevelUp : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x0600170C RID: 5900 RVA: 0x0027BBB8 File Offset: 0x00279DB8
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.m_PetID = (ushort)arg1;
		this.m_PetModel = new Pet3DLoader(base.transform.GetChild(2), this.m_PetID);
		this.m_PetModel.LoadPet();
		this.time = new float[4];
		this.time[0] = 0f;
		this.time[1] = 0f;
		this.time[2] = 0f;
		this.time[3] = 0f;
		this.m_State = UIPetLevelUp.ExpState.End;
		this.m_State_Lv = UIPetLevelUp.ELvState.None;
		this.m_State_Exp = UIPetLevelUp.EExpState.None;
		this.m_State_Exp2 = UIPetLevelUp.EExpState.None;
		this.m_PlayUISFX[0] = false;
		this.m_PlayUISFX[1] = false;
		this.m_PlayUISFX[2] = false;
		this.m_UIType = (UIPetLevelUp.EUIType)arg2;
		this.Spawn();
		this.InitUI(this.m_PetID);
		this.SetExpValue();
		this.SetLvText();
		GUIManager.Instance.m_UICanvas.renderMode = RenderMode.ScreenSpaceCamera;
		GUIManager.Instance.SetCanvasChanged();
	}

	// Token: 0x0600170D RID: 5901 RVA: 0x0027BCCC File Offset: 0x00279ECC
	public override void OnClose()
	{
		if (this.m_PetModel != null)
		{
			this.m_PetModel.Destory();
		}
		this.DeSpawn();
		if (this.m_SFXKey != 255)
		{
			AudioManager.Instance.StopSFX(this.m_SFXKey, true);
			this.m_SFXKey = byte.MaxValue;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 9, 0);
	}

	// Token: 0x0600170E RID: 5902 RVA: 0x0027BD34 File Offset: 0x00279F34
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.RefreshFontTexture();
		}
	}

	// Token: 0x0600170F RID: 5903 RVA: 0x0027BD60 File Offset: 0x00279F60
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x06001710 RID: 5904 RVA: 0x0027BD64 File Offset: 0x00279F64
	public void Update()
	{
		if (this.m_PetModel != null)
		{
			this.m_PetModel.Update();
		}
		if (this.m_State_Lv != UIPetLevelUp.ELvState.Scale)
		{
			this.UpdateSlider();
		}
		this.UpdateLv();
		this.UpdateLvValue();
		this.UpdateExpValue();
	}

	// Token: 0x06001711 RID: 5905 RVA: 0x0027BDAC File Offset: 0x00279FAC
	public void OnButtonClick(UIButton sender)
	{
		GUIManager.Instance.CloseMenu(EGUIWindow.UI_PetLevelUp);
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
	}

	// Token: 0x06001712 RID: 5906 RVA: 0x0027BDC8 File Offset: 0x00279FC8
	public void UpdateSlider()
	{
		if (this.m_Slider != null && this.m_State != UIPetLevelUp.ExpState.End)
		{
			this.time[0] += Time.deltaTime;
			if (this.m_BeginLv <= this.m_EndLv + 1)
			{
				this.maxTime = 2f * (1f - this.m_BeginExpRate / 1f);
				if (this.m_State == UIPetLevelUp.ExpState.Begin)
				{
					this.rate = Mathf.Lerp(this.m_BeginExpRate, 1f, this.time[0] / this.maxTime);
					if (!this.m_PlayUISFX[0])
					{
						AudioManager.Instance.PlaySFXLoop(40069, out this.m_SFXKey, null, SFXEffect.Normal, 0f);
						this.m_PlayUISFX[0] = true;
					}
					this.size = this.m_Slider.rectTransform.sizeDelta;
					this.size.x = 234f * this.rate;
					this.size.x = Mathf.Clamp(this.size.x, 0f, 234f);
					this.m_Slider.rectTransform.sizeDelta = this.size;
					if (this.rate >= 1f)
					{
						this.time[0] = 0f;
						this.m_BeginLv += 1;
						this.m_State_Lv = UIPetLevelUp.ELvState.Scale;
						this.m_State_Exp = UIPetLevelUp.EExpState.Move;
						if (this.m_BeginLv >= this.m_EndLv)
						{
							this.m_State = UIPetLevelUp.ExpState.Last;
						}
						else
						{
							this.m_State = UIPetLevelUp.ExpState.Middle;
						}
						this.SetLvText();
						this.SetEffectLvPos();
						this.CheckSliderSprite();
						if (this.m_SFXKey != 255)
						{
							AudioManager.Instance.StopSFX(this.m_SFXKey, false);
							this.m_SFXKey = byte.MaxValue;
						}
						AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
					}
				}
				else if (this.m_State == UIPetLevelUp.ExpState.Middle)
				{
					if (!this.m_PlayUISFX[1])
					{
						if (this.m_SFXKey != 255)
						{
							AudioManager.Instance.StopSFX(this.m_SFXKey, false);
							this.m_SFXKey = byte.MaxValue;
						}
						AudioManager.Instance.PlaySFXLoop(40069, out this.m_SFXKey, null, SFXEffect.Normal, 0f);
						this.m_PlayUISFX[1] = true;
					}
					this.rate = Mathf.Lerp(0f, 1f, this.time[0] / 2f);
					this.size = this.m_Slider.rectTransform.sizeDelta;
					this.size.x = 234f * this.rate;
					this.size.x = Mathf.Clamp(this.size.x, 0f, 234f);
					this.m_Slider.rectTransform.sizeDelta = this.size;
					if (this.rate >= 1f)
					{
						this.time[0] = 0f;
						this.m_BeginLv += 1;
						this.m_State_Lv = UIPetLevelUp.ELvState.Scale;
						this.m_State_Exp = UIPetLevelUp.EExpState.Move;
						if (this.m_EndLv == this.m_BeginLv)
						{
							this.m_State = UIPetLevelUp.ExpState.Last;
						}
						this.CheckSliderSprite();
						this.SetLvText();
						this.SetEffectLvPos();
						this.m_PlayUISFX[1] = false;
						if (this.m_SFXKey != 255)
						{
							AudioManager.Instance.StopSFX(this.m_SFXKey, false);
							this.m_SFXKey = byte.MaxValue;
						}
						AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
					}
				}
				else if (this.m_State == UIPetLevelUp.ExpState.Last)
				{
					this.maxTime = 2f * (this.m_EndExpRate / 1f);
					if (!this.m_PlayUISFX[2])
					{
						if (this.m_SFXKey != 255)
						{
							AudioManager.Instance.StopSFX(this.m_SFXKey, false);
							this.m_SFXKey = byte.MaxValue;
						}
						AudioManager.Instance.PlaySFXLoop(40069, out this.m_SFXKey, null, SFXEffect.Normal, 0f);
						this.m_PlayUISFX[2] = true;
					}
					this.rate = Mathf.Lerp(0f, this.m_EndExpRate, this.time[0] / this.maxTime);
					this.size = this.m_Slider.rectTransform.sizeDelta;
					this.size.x = 234f * this.rate;
					this.size.x = Mathf.Clamp(this.size.x, 0f, 234f);
					this.m_Slider.rectTransform.sizeDelta = this.size;
					this.CheckSliderSprite();
					if (this.time[0] >= this.maxTime)
					{
						this.time[0] = 0f;
						this.m_State = UIPetLevelUp.ExpState.End;
						if (this.m_SFXKey != 255)
						{
							AudioManager.Instance.StopSFX(this.m_SFXKey, false);
							this.m_SFXKey = byte.MaxValue;
						}
					}
				}
				this.UpdateExpText(this.rate);
			}
		}
	}

	// Token: 0x06001713 RID: 5907 RVA: 0x0027C2D0 File Offset: 0x0027A4D0
	public void UpdateLv()
	{
		RectTransform rectTransform;
		if (this.m_UIType == UIPetLevelUp.EUIType.PetLvUp)
		{
			rectTransform = (RectTransform)this.m_LvPanel;
		}
		else
		{
			rectTransform = this.m_SkillName.rectTransform;
		}
		if (rectTransform != null && this.m_State_Lv != UIPetLevelUp.ELvState.None)
		{
			this.time[1] += Time.deltaTime;
			this.scale = Mathf.Lerp(1f, 2f, this.time[1] / 0.5f);
			this.scaleSize = rectTransform.localScale;
			if (this.scale > 1f)
			{
				this.scaleSize.x = 1f + (2f - this.scale);
				if (GUIManager.Instance.IsArabic)
				{
					this.scaleSize.x = this.scaleSize.x * -1f;
				}
				this.scaleSize.y = 1f + (2f - this.scale);
				this.scaleSize.z = 1f + (2f - this.scale);
			}
			else
			{
				this.scaleSize.x = 1f + this.scale;
				if (GUIManager.Instance.IsArabic)
				{
					this.scaleSize.x = this.scaleSize.x * -1f;
				}
				this.scaleSize.y = 1f + this.scale;
				this.scaleSize.z = 1f + this.scale;
			}
			rectTransform.localScale = this.scaleSize;
			if (this.scale >= 2f)
			{
				this.time[1] = 0f;
				this.m_State_Lv = UIPetLevelUp.ELvState.None;
			}
		}
	}

	// Token: 0x06001714 RID: 5908 RVA: 0x0027C490 File Offset: 0x0027A690
	public void UpdateLvValue()
	{
		RectTransform rectTransform = this.m_EffectTextLV.rectTransform;
		if (this.m_State_Exp != UIPetLevelUp.EExpState.None)
		{
			this.time[2] += Time.deltaTime;
			this.pos = Vector2.Lerp(this.BEGIN, this.END, this.time[2] / 0.5f);
			rectTransform.anchoredPosition = this.pos;
			if (this.pos.y >= this.END.y)
			{
				this.time[2] = 0f;
				this.m_State_Exp = UIPetLevelUp.EExpState.None;
			}
		}
	}

	// Token: 0x06001715 RID: 5909 RVA: 0x0027C52C File Offset: 0x0027A72C
	public void UpdateExpValue()
	{
		RectTransform rectTransform = this.m_EffectTextExp.rectTransform;
		if (this.m_State_Exp2 != UIPetLevelUp.EExpState.None)
		{
			this.time[3] += Time.deltaTime;
			this.pos = Vector2.Lerp(this.EXP_BEGIN, this.EXP_END, this.time[3] / 0.5f);
			rectTransform.anchoredPosition = this.pos;
			if (this.pos.y >= this.END.y)
			{
				this.time[3] = 0f;
				this.m_State_Exp2 = UIPetLevelUp.EExpState.None;
			}
		}
	}

	// Token: 0x06001716 RID: 5910 RVA: 0x0027C5C8 File Offset: 0x0027A7C8
	public void UpdateExpText(float rate)
	{
		byte b;
		if (this.m_UIType == UIPetLevelUp.EUIType.PetLvUp)
		{
			b = 60;
		}
		else
		{
			b = 10;
		}
		if (this.m_BeginLv < b)
		{
			this.m_Str[3].ClearString();
			this.m_Str[3].FloatToFormat(rate * 100f, 2, true);
			if (GUIManager.Instance.IsArabic)
			{
				this.m_Str[3].AppendFormat("%{0}");
			}
			else
			{
				this.m_Str[3].AppendFormat("{0}%");
			}
			this.m_ExpText.text = this.m_Str[3].ToString();
		}
		else
		{
			this.m_ExpText.text = DataManager.Instance.mStringTable.GetStringByID(1507u);
		}
		this.m_ExpText.SetAllDirty();
		this.m_ExpText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001717 RID: 5911 RVA: 0x0027C6AC File Offset: 0x0027A8AC
	public void CheckSliderSprite()
	{
		byte b;
		if (this.m_UIType == UIPetLevelUp.EUIType.PetLvUp)
		{
			b = 60;
		}
		else
		{
			b = 10;
		}
		if (this.m_BeginLv >= b && this.m_Slider != null)
		{
			this.size.x = 234f;
			this.m_Slider.rectTransform.sizeDelta = this.size;
			this.m_Slider.sprite = this.m_Sp.GetSprite(1);
		}
	}

	// Token: 0x06001718 RID: 5912 RVA: 0x0027C72C File Offset: 0x0027A92C
	public void Spawn()
	{
		this.m_Str = new CString[5];
		for (int i = 0; i < this.m_Str.Length; i++)
		{
			this.m_Str[i] = StringManager.Instance.SpawnString(30);
		}
	}

	// Token: 0x06001719 RID: 5913 RVA: 0x0027C774 File Offset: 0x0027A974
	public void DeSpawn()
	{
		if (this.m_Str != null)
		{
			for (int i = 0; i < this.m_Str.Length; i++)
			{
				if (this.m_Str[i] != null)
				{
					StringManager.Instance.DeSpawnString(this.m_Str[i]);
					this.m_Str[i] = null;
				}
			}
		}
	}

	// Token: 0x0600171A RID: 5914 RVA: 0x0027C7D0 File Offset: 0x0027A9D0
	public void SetLvText()
	{
		if (this.m_UIType == UIPetLevelUp.EUIType.PetLvUp)
		{
			if (this.m_PetLv != null)
			{
				this.m_Str[0].ClearString();
				this.m_Str[0].IntToFormat((long)this.m_BeginLv, 1, false);
				this.m_Str[0].AppendFormat("Lv.{0}");
				this.m_PetLv.text = this.m_Str[0].ToString();
				this.m_PetLv.SetAllDirty();
				this.m_PetLv.cachedTextGenerator.Invalidate();
			}
		}
		else if (this.m_SkillName != null)
		{
			PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey(this.m_PetSkillID);
			this.m_Str[2].ClearString();
			this.m_Str[2].IntToFormat((long)this.m_BeginLv, 1, false);
			this.m_Str[2].StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.Name));
			this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(268u));
			this.m_SkillName.text = this.m_Str[2].ToString();
			this.m_SkillName.SetAllDirty();
			this.m_SkillName.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x0600171B RID: 5915 RVA: 0x0027C92C File Offset: 0x0027AB2C
	private void SetEffectLvPos()
	{
		this.m_EffectTextLV.gameObject.SetActive(true);
		this.m_EffectTextLV.rectTransform.anchoredPosition = this.BEGIN;
	}

	// Token: 0x0600171C RID: 5916 RVA: 0x0027C960 File Offset: 0x0027AB60
	public void SetEffectExpText(byte lv)
	{
		PetManager instance = PetManager.Instance;
		PetData petData = instance.FindPetData(this.m_PetID);
		if (petData == null)
		{
			return;
		}
		PetTbl recordByKey = instance.PetTable.GetRecordByKey(petData.ID);
		PetExpTbl recordByKey2 = instance.PetExpTable.GetRecordByKey((ushort)lv);
		uint num;
		if (this.m_UIType == UIPetLevelUp.EUIType.PetLvUp)
		{
			num = instance.GetNeedExp(lv, recordByKey.Rare);
		}
		else
		{
			num = instance.GetPetSkillMaxExp(this.m_PetID, this.m_Skillidx);
		}
		if (this.m_EffectTextLV != null && this.m_EffectTextExp != null)
		{
			this.m_Str[4].ClearString();
			if (lv == instance.m_PetBeginLv)
			{
				this.m_Str[4].IntToFormat((long)((ulong)(num - instance.m_BeginExp)), 1, false);
			}
			else if (lv == instance.m_PetEndLv)
			{
				this.m_Str[4].IntToFormat((long)((ulong)instance.m_EndExp), 1, false);
			}
			else
			{
				this.m_Str[4].IntToFormat((long)((ulong)num), 1, false);
			}
			this.m_Str[4].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(55u));
			this.m_EffectTextExp.text = this.m_Str[4].ToString();
			this.m_EffectTextExp.SetAllDirty();
			this.m_EffectTextExp.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x0600171D RID: 5917 RVA: 0x0027CAC0 File Offset: 0x0027ACC0
	public void RefreshFontTexture()
	{
		if (this.m_TitleName != null && this.m_TitleName.enabled)
		{
			this.m_TitleName.enabled = false;
			this.m_TitleName.enabled = true;
		}
		if (this.m_PetName != null && this.m_PetName.enabled)
		{
			this.m_PetName.enabled = false;
			this.m_PetName.enabled = true;
		}
		if (this.m_SkillName != null && this.m_SkillName.enabled)
		{
			this.m_SkillName.enabled = false;
			this.m_SkillName.enabled = true;
		}
		if (this.m_PetLv != null && this.m_PetLv.enabled)
		{
			this.m_PetLv.enabled = false;
			this.m_PetLv.enabled = true;
		}
		if (this.m_ExpText != null && this.m_ExpText.enabled)
		{
			this.m_ExpText.enabled = false;
			this.m_ExpText.enabled = true;
		}
		if (this.m_EffectTextLV != null && this.m_EffectTextLV.enabled)
		{
			this.m_EffectTextLV.enabled = false;
			this.m_EffectTextLV.enabled = true;
		}
		if (this.m_EffectTextExp != null && this.m_EffectTextExp.enabled)
		{
			this.m_EffectTextExp.enabled = false;
			this.m_EffectTextExp.enabled = true;
		}
	}

	// Token: 0x0600171E RID: 5918 RVA: 0x0027CC5C File Offset: 0x0027AE5C
	public void InitUI(ushort petID)
	{
		this.m_Sp = base.transform.gameObject.GetComponent<UISpritesArray>();
		Transform child;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			child = base.transform.GetChild(0);
			((RectTransform)child).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)child).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		UIButton component = base.transform.GetChild(0).GetComponent<UIButton>();
		child = base.transform.GetChild(1);
		this.m_BlueBg = child.GetChild(0).GetComponent<Image>();
		this.m_RedBg = child.GetChild(1).GetComponent<Image>();
		this.m_TitleName = child.GetChild(4).GetComponent<UIText>();
		this.m_TitleName.font = GUIManager.Instance.GetTTFFont();
		child = base.transform.GetChild(3);
		this.m_SliderTf = child.GetChild(0);
		this.m_Slider = this.m_SliderTf.GetChild(0).GetComponent<Image>();
		this.m_ExpText = this.m_SliderTf.GetChild(1).GetComponent<UIText>();
		this.m_ExpText.font = GUIManager.Instance.GetTTFFont();
		child = base.transform.GetChild(4);
		this.m_PetName = child.GetChild(0).GetComponent<UIText>();
		this.m_PetName.font = GUIManager.Instance.GetTTFFont();
		this.m_PetName.text = PetManager.Instance.GetPetNameByID(petID);
		this.m_SkillName = child.GetChild(1).GetComponent<UIText>();
		this.m_SkillName.font = GUIManager.Instance.GetTTFFont();
		child = base.transform.GetChild(5);
		this.m_LvPanel = child.GetChild(0);
		this.m_PetLv = this.m_LvPanel.GetChild(0).GetComponent<UIText>();
		this.m_PetLv.font = GUIManager.Instance.GetTTFFont();
		this.m_SkillPanel = child.GetChild(1);
		this.m_Skill = this.m_SkillPanel.GetChild(0).GetComponent<Image>();
		this.m_SkillFrame = this.m_SkillPanel.GetChild(0).GetChild(0).GetComponent<Image>();
		child = base.transform.GetChild(6);
		this.m_EffectTextTf = child;
		this.m_EffectTextTf.gameObject.SetActive(true);
		this.m_EffectTextLV = child.GetChild(1).GetComponent<UIText>();
		this.m_EffectTextLV.font = GUIManager.Instance.GetTTFFont();
		this.m_EffectTextLV.text = DataManager.Instance.mStringTable.GetStringByID(1555u);
		this.m_EffectTextLV.gameObject.SetActive(false);
		this.m_EffectTextExp = child.GetChild(0).GetComponent<UIText>();
		this.m_EffectTextExp.font = GUIManager.Instance.GetTTFFont();
		this.m_EffectTextExp.gameObject.SetActive(false);
		child = base.transform.GetChild(9);
		UIButton component2 = child.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.image.sprite = this.door.LoadSprite("UI_main_close");
		component2.image.material = this.door.LoadMaterial();
		if (this.m_UIType == UIPetLevelUp.EUIType.SkillLvUp)
		{
			this.BEGIN = new Vector2(-1f, -222f);
			this.END = new Vector2(-1f, -45f);
			this.EXP_BEGIN = new Vector2(-1f, -252f);
			this.EXP_END = new Vector2(-1f, -80f);
			this.m_TitleName.text = DataManager.Instance.mStringTable.GetStringByID(17096u);
			this.m_SkillPanel.gameObject.SetActive(true);
			this.m_LvPanel.gameObject.SetActive(false);
			this.m_PetName.gameObject.SetActive(false);
			this.m_Skill.gameObject.SetActive(true);
			this.m_SkillName.gameObject.SetActive(true);
			this.m_BlueBg.enabled = true;
			this.m_RedBg.enabled = false;
			this.m_SliderTf.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1f, -225.5f);
		}
		else
		{
			this.BEGIN = new Vector2(-1f, -222f);
			this.END = new Vector2(-1f, -122f);
			this.EXP_BEGIN = new Vector2(-1f, -252f);
			this.EXP_END = new Vector2(-1f, -152f);
			this.m_TitleName.text = DataManager.Instance.mStringTable.GetStringByID(17094u);
			this.m_SkillPanel.gameObject.SetActive(false);
			this.m_LvPanel.gameObject.SetActive(true);
			this.m_PetName.gameObject.SetActive(true);
			this.m_Skill.gameObject.SetActive(false);
			this.m_SkillName.gameObject.SetActive(false);
			this.m_BlueBg.enabled = false;
			this.m_RedBg.enabled = true;
		}
	}

	// Token: 0x0600171F RID: 5919 RVA: 0x0027D18C File Offset: 0x0027B38C
	public void SetExpValue()
	{
		if (this.m_PetID != 0)
		{
			this.m_BeginLv = PetManager.Instance.m_PetBeginLv;
			this.m_EndLv = PetManager.Instance.m_PetEndLv;
			uint beginExp = PetManager.Instance.m_BeginExp;
			uint endExp = PetManager.Instance.m_EndExp;
			this.m_PetSkillID = PetManager.Instance.m_PetSkillLvUpID;
			PetTbl recordByKey = PetManager.Instance.PetTable.GetRecordByKey(this.m_PetID);
			uint num;
			uint num2;
			if (this.m_UIType == UIPetLevelUp.EUIType.PetLvUp)
			{
				num = PetManager.Instance.GetNeedExp(this.m_BeginLv, recordByKey.Rare);
				num2 = PetManager.Instance.GetNeedExp(this.m_EndLv, recordByKey.Rare);
			}
			else
			{
				num = PetManager.Instance.GetPetSkillMaxExpByID(this.m_PetSkillID, this.m_BeginLv);
				num2 = PetManager.Instance.GetPetSkillMaxExpByID(this.m_PetSkillID, this.m_EndLv);
				byte b = 0;
				while ((int)b < recordByKey.PetSkill.Length)
				{
					if (recordByKey.PetSkill[(int)b] == this.m_PetSkillID)
					{
						this.m_Skillidx = b;
					}
					b += 1;
				}
			}
			if (num > 0u && num2 > 0u)
			{
				this.m_BeginExpRate = beginExp / num;
				this.m_EndExpRate = endExp / num2;
			}
			else
			{
				this.m_BeginExpRate = 0f;
				this.m_EndExpRate = 0f;
			}
			uint num3 = 0u;
			for (byte b2 = this.m_BeginLv; b2 <= this.m_EndLv; b2 += 1)
			{
				if (b2 == this.m_BeginLv)
				{
					uint num4;
					if (this.m_UIType == UIPetLevelUp.EUIType.PetLvUp)
					{
						num4 = PetManager.Instance.GetNeedExp(b2, recordByKey.Rare);
					}
					else
					{
						num4 = PetManager.Instance.GetPetSkillMaxExpByID(this.m_PetSkillID, b2);
					}
					num3 += num4 - beginExp;
				}
				else if (b2 == this.m_EndLv)
				{
					num3 += endExp;
				}
				else if (this.m_UIType == UIPetLevelUp.EUIType.PetLvUp)
				{
					num3 += PetManager.Instance.GetNeedExp(b2, recordByKey.Rare);
				}
				else
				{
					num3 += PetManager.Instance.GetPetSkillMaxExpByID(this.m_PetSkillID, b2);
				}
			}
			if (this.m_EffectTextLV != null && this.m_EffectTextExp != null)
			{
				this.m_EffectTextLV.rectTransform.anchoredPosition = this.BEGIN;
				this.m_EffectTextExp.rectTransform.anchoredPosition = this.EXP_BEGIN;
				this.m_EffectTextExp.gameObject.SetActive(true);
				this.m_Str[4].ClearString();
				this.m_Str[4].IntToFormat((long)((ulong)num3), 1, true);
				this.m_Str[4].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(55u));
				this.m_EffectTextExp.text = this.m_Str[4].ToString();
				this.m_EffectTextExp.SetAllDirty();
				this.m_EffectTextExp.cachedTextGenerator.Invalidate();
			}
			PetSkillTbl recordByKey2 = PetManager.Instance.PetSkillTable.GetRecordByKey(this.m_PetSkillID);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.Append('s');
			cstring.IntToFormat((long)recordByKey2.Icon, 5, false);
			cstring.AppendFormat("{0}");
			this.m_Skill.sprite = GUIManager.Instance.LoadSkillSprite(cstring);
			this.m_Skill.material = GUIManager.Instance.GetSkillMaterial();
			this.m_SkillFrame.sprite = GUIManager.Instance.LoadFrameSprite("sk");
			this.m_SkillFrame.material = GUIManager.Instance.GetFrameMaterial();
			this.m_State = UIPetLevelUp.ExpState.Begin;
			this.m_State_Lv = UIPetLevelUp.ELvState.None;
			this.m_State_Exp2 = UIPetLevelUp.EExpState.Move;
		}
	}

	// Token: 0x040044FF RID: 17663
	private const float SLIDER_WIDTH = 234f;

	// Token: 0x04004500 RID: 17664
	private const float SLIDER_TIME = 2f;

	// Token: 0x04004501 RID: 17665
	private const float SCALE_TIME = 0.5f;

	// Token: 0x04004502 RID: 17666
	private const float MOVETIME = 0.5f;

	// Token: 0x04004503 RID: 17667
	private Vector2 BEGIN;

	// Token: 0x04004504 RID: 17668
	private Vector2 END;

	// Token: 0x04004505 RID: 17669
	private Vector2 EXP_BEGIN;

	// Token: 0x04004506 RID: 17670
	private Vector2 EXP_END;

	// Token: 0x04004507 RID: 17671
	private ushort m_PetID;

	// Token: 0x04004508 RID: 17672
	private Pet3DLoader m_PetModel;

	// Token: 0x04004509 RID: 17673
	private Transform m_SkillPanel;

	// Token: 0x0400450A RID: 17674
	private Transform m_LvPanel;

	// Token: 0x0400450B RID: 17675
	private Transform m_EffectTextTf;

	// Token: 0x0400450C RID: 17676
	private Transform m_SliderTf;

	// Token: 0x0400450D RID: 17677
	private UIText m_TitleName;

	// Token: 0x0400450E RID: 17678
	private UIText m_PetName;

	// Token: 0x0400450F RID: 17679
	private UIText m_SkillName;

	// Token: 0x04004510 RID: 17680
	private UIText m_PetLv;

	// Token: 0x04004511 RID: 17681
	private UIText m_ExpText;

	// Token: 0x04004512 RID: 17682
	private UIText m_EffectTextLV;

	// Token: 0x04004513 RID: 17683
	private UIText m_EffectTextExp;

	// Token: 0x04004514 RID: 17684
	private Image m_BlueBg;

	// Token: 0x04004515 RID: 17685
	private Image m_RedBg;

	// Token: 0x04004516 RID: 17686
	private Image m_Slider;

	// Token: 0x04004517 RID: 17687
	private Image m_Skill;

	// Token: 0x04004518 RID: 17688
	private Image m_SkillFrame;

	// Token: 0x04004519 RID: 17689
	private UISpritesArray m_Sp;

	// Token: 0x0400451A RID: 17690
	private CString[] m_Str;

	// Token: 0x0400451B RID: 17691
	private byte m_BeginLv;

	// Token: 0x0400451C RID: 17692
	private byte m_EndLv;

	// Token: 0x0400451D RID: 17693
	private float m_BeginExpRate;

	// Token: 0x0400451E RID: 17694
	private float m_EndExpRate;

	// Token: 0x0400451F RID: 17695
	private ushort m_PetSkillID;

	// Token: 0x04004520 RID: 17696
	private byte m_Skillidx;

	// Token: 0x04004521 RID: 17697
	private float[] time;

	// Token: 0x04004522 RID: 17698
	private float rate;

	// Token: 0x04004523 RID: 17699
	private Vector2 size;

	// Token: 0x04004524 RID: 17700
	private Vector3 scaleSize;

	// Token: 0x04004525 RID: 17701
	private float scale;

	// Token: 0x04004526 RID: 17702
	private Vector2 pos;

	// Token: 0x04004527 RID: 17703
	private float maxTime;

	// Token: 0x04004528 RID: 17704
	private UIPetLevelUp.ExpState m_State;

	// Token: 0x04004529 RID: 17705
	private UIPetLevelUp.ELvState m_State_Lv;

	// Token: 0x0400452A RID: 17706
	private UIPetLevelUp.EExpState m_State_Exp;

	// Token: 0x0400452B RID: 17707
	private UIPetLevelUp.EExpState m_State_Exp2;

	// Token: 0x0400452C RID: 17708
	private UIPetLevelUp.EUIType m_UIType;

	// Token: 0x0400452D RID: 17709
	private bool[] m_PlayUISFX = new bool[3];

	// Token: 0x0400452E RID: 17710
	private byte m_SFXKey = byte.MaxValue;

	// Token: 0x0400452F RID: 17711
	private Door door;

	// Token: 0x0200046F RID: 1135
	private enum ExpState
	{
		// Token: 0x04004531 RID: 17713
		Begin,
		// Token: 0x04004532 RID: 17714
		Middle,
		// Token: 0x04004533 RID: 17715
		Last,
		// Token: 0x04004534 RID: 17716
		End
	}

	// Token: 0x02000470 RID: 1136
	private enum EExpState
	{
		// Token: 0x04004536 RID: 17718
		None,
		// Token: 0x04004537 RID: 17719
		Move
	}

	// Token: 0x02000471 RID: 1137
	private enum ELvState
	{
		// Token: 0x04004539 RID: 17721
		None,
		// Token: 0x0400453A RID: 17722
		Scale
	}

	// Token: 0x02000472 RID: 1138
	private enum ECstr
	{
		// Token: 0x0400453C RID: 17724
		LvText,
		// Token: 0x0400453D RID: 17725
		Name,
		// Token: 0x0400453E RID: 17726
		SkillName,
		// Token: 0x0400453F RID: 17727
		ExpText,
		// Token: 0x04004540 RID: 17728
		EffectExpText,
		// Token: 0x04004541 RID: 17729
		Max
	}

	// Token: 0x02000473 RID: 1139
	private enum EUIType
	{
		// Token: 0x04004543 RID: 17731
		PetLvUp,
		// Token: 0x04004544 RID: 17732
		SkillLvUp
	}

	// Token: 0x02000474 RID: 1140
	private enum EUIPetLevelUp
	{
		// Token: 0x04004546 RID: 17734
		BgBtn,
		// Token: 0x04004547 RID: 17735
		BgPanel,
		// Token: 0x04004548 RID: 17736
		PetModel,
		// Token: 0x04004549 RID: 17737
		ExpSlider,
		// Token: 0x0400454A RID: 17738
		Name,
		// Token: 0x0400454B RID: 17739
		Icon,
		// Token: 0x0400454C RID: 17740
		EffectText,
		// Token: 0x0400454D RID: 17741
		Pointlight_1,
		// Token: 0x0400454E RID: 17742
		Pointlight_2,
		// Token: 0x0400454F RID: 17743
		ExitBtn
	}
}
