using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000536 RID: 1334
public class UICryptDig : GUIWindow, IUIButtonClickHandler, IUICalculatorHandler, IUIUnitRSliderHandler
{
	// Token: 0x06001A9B RID: 6811 RVA: 0x002D3C10 File Offset: 0x002D1E10
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
		this.OpenDigType = (byte)arg1;
		this.interestText = StringManager.Instance.SpawnString(50);
		this.fundsText = StringManager.Instance.SpawnString(50);
		this.profitText = StringManager.Instance.SpawnString(50);
		this.timeText = StringManager.Instance.SpawnString(50);
		this.MaxFundText = StringManager.Instance.SpawnString(50);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(3986u + (uint)this.OpenDigType - 1u);
		Image component2 = this.AGS_Form.GetChild(4).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.door.LoadMaterial();
		component2.enabled = !GUIManager.Instance.bOpenOnIPhoneX;
		component2 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close");
		component2.material = this.door.LoadMaterial();
		UIButton component3 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		this.AGS_Icon = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UISpritesArray>();
		this.AGS_Icon.SetSpriteIndex((int)(this.OpenDigType - 1));
		component = this.AGS_Form.GetChild(6).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(3993u);
		component = this.AGS_Form.GetChild(6).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(3994u);
		component = this.AGS_Form.GetChild(6).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(3995u);
		component = this.AGS_Form.GetChild(6).GetChild(6).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(3996u);
		component = this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(3930u);
		component = this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(6).GetChild(9).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(6).GetChild(10).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component.color = new Color32(0, byte.MaxValue, 0, byte.MaxValue);
		component = this.AGS_Form.GetChild(6).GetChild(11).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(6).GetChild(12).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(4055u);
		component = this.AGS_Form.GetChild(8).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(8).GetChild(4).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(9).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(3934u);
		component = this.AGS_Form.GetChild(9).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(5897u);
		component3 = this.AGS_Form.GetChild(10).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		this.AGS_SuperBtn_SA = this.AGS_Form.GetChild(10).GetComponent<UISpritesArray>();
		component = this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component.gameObject.AddComponent<Outline>();
		component = this.AGS_Form.GetChild(10).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(4090u);
		component.color = new Color32(209, 192, 165, byte.MaxValue);
		this.AGS_Form.GetChild(9).gameObject.SetActive(false);
		this.Light = this.AGS_Form.GetChild(10).GetChild(0).GetComponent<Image>();
		this.LoadInfo();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001A9C RID: 6812 RVA: 0x002D423C File Offset: 0x002D243C
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.interestText);
		StringManager.Instance.DeSpawnString(this.fundsText);
		StringManager.Instance.DeSpawnString(this.profitText);
		StringManager.Instance.DeSpawnString(this.timeText);
		StringManager.Instance.DeSpawnString(this.MaxFundText);
		GUIManager.Instance.ClearCalculator();
	}

	// Token: 0x06001A9D RID: 6813 RVA: 0x002D42A8 File Offset: 0x002D24A8
	public override void UpdateUI(int arg1, int arg2)
	{
		this.LoadInfo();
	}

	// Token: 0x06001A9E RID: 6814 RVA: 0x002D42B0 File Offset: 0x002D24B0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
		}
		else
		{
			this.LoadInfo();
		}
	}

	// Token: 0x06001A9F RID: 6815 RVA: 0x002D42EC File Offset: 0x002D24EC
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			this.updateTimeBar();
		}
	}

	// Token: 0x06001AA0 RID: 6816 RVA: 0x002D42FC File Offset: 0x002D24FC
	private void LoadInfo()
	{
		switch (this.OpenDigType)
		{
		case 1:
		{
			UIText component = this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(3990u);
			component = this.AGS_Form.GetChild(6).GetChild(9).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(4058u);
			break;
		}
		case 2:
		{
			UIText component = this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(3991u);
			component = this.AGS_Form.GetChild(6).GetChild(9).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(4059u);
			break;
		}
		case 3:
		{
			UIText component = this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(3992u);
			component = this.AGS_Form.GetChild(6).GetChild(9).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(4060u);
			break;
		}
		}
		if (this.DM.m_CryptData.money == 0)
		{
			this.interest = 1.0 + GameConstants.cryptInterest[(int)this.OpenDigType] + this.DM.AttribVal.GetEffectBaseValByEffectID(277) / 10000.0;
			if (this.funds < 10000)
			{
				this.funds = 10000;
			}
			this.profit = (uint)Math.Floor((double)this.funds * this.interest);
			this.MaxFunds = (ushort)this.DM.AttribVal.GetEffectBaseValByEffectID(278);
			UIText component = this.AGS_Form.GetChild(6).GetChild(10).GetComponent<UIText>();
			this.interestText.ClearString();
			this.interestText.FloatToFormat(this.DM.AttribVal.GetEffectBaseValByEffectID(277) / 100u, 2, false);
			if (!GUIManager.Instance.IsArabic)
			{
				this.interestText.AppendFormat("+{0}%");
			}
			else
			{
				this.interestText.AppendFormat("%{0}+");
			}
			component.text = this.interestText.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			RectTransform rectTransform;
			if (this.slider == null)
			{
				GameObject gameObject = new GameObject("Slider");
				rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchoredPosition = new Vector2(-110f, -215f);
				gameObject.transform.SetParent(this.AGS_Form.GetChild(9), false);
				this.slider = gameObject.AddComponent<UnitResourcesSlider>();
				GUIManager.Instance.InitUnitResourcesSlider(gameObject.transform, eUnitSlider.Crypt, 10000u, (uint)this.MaxFunds, 1f);
				this.slider.m_Handler = this;
				this.slider.m_ID = 1;
				this.slider.BtnInputText.m_Handler = this;
				this.slider.BtnInputText.m_BtnID1 = 4;
			}
			this.slider.MaxValue = (long)this.MaxFunds;
			this.slider.m_slider.maxValue = (double)this.MaxFunds;
			this.MaxFundText.ClearString();
			this.MaxFundText.IntToFormat((long)this.MaxFunds, 1, true);
			this.MaxFundText.AppendFormat("{0}");
			this.slider.m_TotalText.text = this.MaxFundText.ToString();
			this.slider.m_TotalText.SetAllDirty();
			this.slider.m_TotalText.cachedTextGenerator.Invalidate();
			StringManager.IntToStr(this.fundsText, (long)this.funds, 1, true);
			this.slider.m_inputText.text = this.fundsText.ToString();
			this.slider.m_inputText.SetAllDirty();
			this.slider.m_inputText.cachedTextGenerator.Invalidate();
			rectTransform = this.AGS_Form.GetChild(9).GetChild(1).GetComponent<RectTransform>();
			rectTransform.anchoredPosition = new Vector2(-110f, -281f);
			rectTransform = this.AGS_Form.GetChild(9).GetChild(0).GetComponent<RectTransform>();
			rectTransform.anchoredPosition = new Vector2(-170f, -213f);
			rectTransform = this.AGS_Form.GetChild(9).GetChild(2).GetComponent<RectTransform>();
			rectTransform.anchoredPosition = new Vector2(54f, -223f);
			this.AGS_SuperBtn_SA.SetSpriteIndex(0);
			this.AGS_Form.GetChild(10).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(10).GetChild(2).gameObject.SetActive(false);
			this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(4089u);
			this.AGS_Form.GetChild(10).GetComponent<UIButton>().m_BtnID1 = 1;
			component = this.AGS_Form.GetChild(6).GetChild(12).GetComponent<UIText>();
			component.color = new Color32(0, byte.MaxValue, 0, byte.MaxValue);
			this.AGS_Form.GetChild(9).gameObject.SetActive(true);
			this.AGS_Form.GetChild(10).gameObject.SetActive(true);
			this.AGS_Form.GetChild(9).GetChild(1).gameObject.SetActive(true);
			this.AGS_Form.GetChild(9).GetChild(2).gameObject.SetActive(true);
		}
		else
		{
			if (this.DM.m_CryptData.kind == this.OpenDigType)
			{
				BuildLevelRequest buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(16, this.DM.m_CryptData.level);
				this.interest = 1.0 + GameConstants.cryptInterest[(int)this.DM.m_CryptData.kind] + buildLevelRequestData.Value2 / 10000.0;
				this.funds = this.DM.m_CryptData.money;
				this.profit = (uint)Math.Floor((double)this.funds * this.interest);
				UIText component = this.AGS_Form.GetChild(6).GetChild(10).GetComponent<UIText>();
				this.interestText.ClearString();
				this.interestText.FloatToFormat(buildLevelRequestData.Value2 / 100u, 2, false);
				if (!GUIManager.Instance.IsArabic)
				{
					this.interestText.AppendFormat("+{0}%");
				}
				else
				{
					this.interestText.AppendFormat("%{0}+");
				}
				component.text = this.interestText.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				component = this.AGS_Form.GetChild(6).GetChild(12).GetComponent<UIText>();
				component.color = Color.yellow;
				this.AGS_Form.GetChild(8).gameObject.SetActive(true);
				this.AGS_Form.GetChild(10).gameObject.SetActive(true);
				component = this.AGS_Form.GetChild(8).GetChild(3).GetComponent<UIText>();
				this.profitText.ClearString();
				this.profitText.IntToFormat((long)((ulong)this.profit), 1, true);
				this.profitText.AppendFormat("{0}");
				component.text = this.profitText.ToString();
				this.updateTimeBar();
			}
			else
			{
				this.interest = 1.0 + GameConstants.cryptInterest[(int)this.OpenDigType] + this.DM.AttribVal.GetEffectBaseValByEffectID(277) / 10000.0;
				this.funds = 0;
				this.profit = 0u;
				UIText component = this.AGS_Form.GetChild(6).GetChild(10).GetComponent<UIText>();
				this.interestText.ClearString();
				this.interestText.FloatToFormat(this.DM.AttribVal.GetEffectBaseValByEffectID(277) / 100u, 2, false);
				if (!GUIManager.Instance.IsArabic)
				{
					this.interestText.AppendFormat("+{0}%");
				}
				else
				{
					this.interestText.AppendFormat("%{0}+");
				}
				component.text = this.interestText.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				component = this.AGS_Form.GetChild(6).GetChild(12).GetComponent<UIText>();
				component.color = Color.yellow;
				component = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
				component.text = this.DM.mStringTable.GetStringByID(4092u);
				component.transform.parent.gameObject.SetActive(true);
				component.gameObject.SetActive(true);
			}
			this.AGS_Form.GetChild(9).GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(9).GetChild(2).gameObject.SetActive(false);
		}
		this.SetNumbers();
	}

	// Token: 0x06001AA1 RID: 6817 RVA: 0x002D4CBC File Offset: 0x002D2EBC
	private void updateTimeBar()
	{
		if (this.DM.m_CryptData.money == 0)
		{
			this.AGS_SuperBtn_SA.SetSpriteIndex(0);
			this.AGS_Form.GetChild(10).GetComponent<UIButton>().m_BtnID1 = 1;
			return;
		}
		long num = this.DM.m_CryptData.startTime + (long)((ulong)GameConstants.CryptSecends[(int)this.DM.m_CryptData.kind]) - this.DM.ServerTime;
		if (num < 0L)
		{
			num = 0L;
		}
		if (num == 0L)
		{
			UIText component = this.AGS_Form.GetChild(8).GetChild(4).GetChild(1).GetComponent<UIText>();
			this.timeText.ClearString();
			this.timeText.Append(this.DM.mStringTable.GetStringByID(5881u));
			component.text = this.timeText.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.AGS_SuperBtn_SA.SetSpriteIndex(2);
			this.AGS_Form.GetChild(10).GetChild(2).gameObject.SetActive(false);
			this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(4091u);
			this.Light.gameObject.SetActive(true);
			this.AGS_Form.GetChild(10).GetComponent<UIButton>().m_BtnID1 = 2;
		}
		else
		{
			UIText component = this.AGS_Form.GetChild(8).GetChild(4).GetChild(1).GetComponent<UIText>();
			this.timeText.ClearString();
			this.timeText.Append(this.DM.mStringTable.GetStringByID(3933u));
			this.timeText.Append(" ");
			RectTransform component2 = this.AGS_Form.GetChild(8).GetChild(4).GetChild(0).GetComponent<RectTransform>();
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 256f * (1f - (float)num / GameConstants.CryptSecends[(int)this.DM.m_CryptData.kind]));
			GameConstants.GetTimeString(this.timeText, (uint)num, false, false, true, true, true);
			component.text = this.timeText.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.AGS_SuperBtn_SA.SetSpriteIndex(1);
			this.AGS_Form.GetChild(10).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(5880u);
			this.Light.gameObject.SetActive(false);
			this.AGS_Form.GetChild(10).GetComponent<UIButton>().m_BtnID1 = 3;
		}
	}

	// Token: 0x06001AA2 RID: 6818 RVA: 0x002D4F9C File Offset: 0x002D319C
	private void SetNumbers()
	{
		UIText component = this.AGS_Form.GetChild(6).GetChild(11).GetComponent<UIText>();
		this.fundsText.ClearString();
		this.fundsText.IntToFormat((long)this.funds, 1, true);
		this.fundsText.AppendFormat("{0}");
		component.text = this.fundsText.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(6).GetChild(12).GetComponent<UIText>();
		this.profitText.ClearString();
		this.profitText.IntToFormat((long)((ulong)this.profit), 1, true);
		this.profitText.AppendFormat("{0}");
		component.text = this.profitText.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		if ((uint)this.funds > this.DM.RoleAttr.Diamond && this.DM.m_CryptData.money == 0)
		{
			this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>().color = new Color32(229, 0, 79, byte.MaxValue);
		}
		else
		{
			this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>().color = new Color32(byte.MaxValue, 238, 158, byte.MaxValue);
		}
	}

	// Token: 0x06001AA3 RID: 6819 RVA: 0x002D5124 File Offset: 0x002D3324
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			this.door.CloseMenu(false);
			break;
		case 1:
		{
			if (this.DM.RoleAttr.Diamond < 10000u)
			{
				GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4093u), 255, true);
				return;
			}
			if (this.slider.Value > (long)((ulong)this.DM.RoleAttr.Diamond))
			{
				GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4095u), 255, true);
				return;
			}
			if (this.slider.Value < 10000L)
			{
				this.slider.Value = 10000L;
			}
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_CRYPT_START;
			messagePacket.AddSeqId();
			messagePacket.Add((ushort)this.slider.Value);
			messagePacket.Add(this.OpenDigType);
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Crypt);
			break;
		}
		case 2:
		{
			MessagePacket messagePacket2 = new MessagePacket(1024);
			messagePacket2.Protocol = Protocol._MSG_REQUEST_CRYPT_REWARD;
			messagePacket2.AddSeqId();
			messagePacket2.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Crypt);
			GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f - 342.96f, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f + 236.5f);
			break;
		}
		case 3:
			GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4096u), this.DM.mStringTable.GetStringByID(4097u), 0, 0, this.DM.mStringTable.GetStringByID(4098u), this.DM.mStringTable.GetStringByID(4099u));
			break;
		case 4:
			GUIManager.Instance.m_UICalculator.m_CalculatorHandler = this;
			GUIManager.Instance.m_UICalculator.OpenCalculator(this.slider.MaxValue, this.slider.Value, 250f, -140f, this.slider, 10000L);
			break;
		}
	}

	// Token: 0x06001AA4 RID: 6820 RVA: 0x002D53B8 File Offset: 0x002D35B8
	public void OnVauleChang(UnitResourcesSlider sender)
	{
		if (sender.Value < 10000L)
		{
			sender.Value = 10000L;
		}
		this.funds = (ushort)sender.Value;
		this.profit = (uint)Math.Floor((double)this.funds * this.interest);
		this.SetNumbers();
		StringManager.IntToStr(this.fundsText, (long)this.funds, 1, true);
		sender.m_inputText.text = this.fundsText.ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001AA5 RID: 6821 RVA: 0x002D5458 File Offset: 0x002D3658
	public void OnTextChang(UnitResourcesSlider sender)
	{
		this.funds = (ushort)sender.Value;
		this.profit = (uint)Math.Floor((double)this.funds * this.interest);
		StringManager.IntToStr(this.fundsText, (long)this.funds, 1, true);
		sender.m_inputText.text = this.fundsText.ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001AA6 RID: 6822 RVA: 0x002D54D4 File Offset: 0x002D36D4
	public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS = null)
	{
		URS.m_slider.value = (double)mValue;
		URS.SliderValueChange();
	}

	// Token: 0x06001AA7 RID: 6823 RVA: 0x002D54EC File Offset: 0x002D36EC
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_CRYPT_CANCEL;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Crypt);
		}
	}

	// Token: 0x06001AA8 RID: 6824 RVA: 0x002D5530 File Offset: 0x002D3730
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(4).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(6).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(9).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(10).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(11).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(12).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(8).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(8).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(8).GetChild(4).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(9).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(9).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(10).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		if (this.slider != null)
		{
			this.slider.Refresh_FontTexture();
		}
	}

	// Token: 0x06001AA9 RID: 6825 RVA: 0x002D59F0 File Offset: 0x002D3BF0
	public void Update()
	{
		this.LightTime += Time.smoothDeltaTime;
		if (this.LightTime >= 2f)
		{
			this.LightTime = 0f;
		}
		float a = (this.LightTime <= 1f) ? this.LightTime : (2f - this.LightTime);
		this.Light.color = new Color(1f, 1f, 1f, a);
	}

	// Token: 0x04004EDD RID: 20189
	private const ushort BaseFunds = 10000;

	// Token: 0x04004EDE RID: 20190
	private Transform AGS_Form;

	// Token: 0x04004EDF RID: 20191
	private UISpritesArray AGS_Icon;

	// Token: 0x04004EE0 RID: 20192
	private UISpritesArray AGS_SuperBtn_SA;

	// Token: 0x04004EE1 RID: 20193
	private Door door;

	// Token: 0x04004EE2 RID: 20194
	private DataManager DM;

	// Token: 0x04004EE3 RID: 20195
	private byte OpenDigType;

	// Token: 0x04004EE4 RID: 20196
	private UnitResourcesSlider slider;

	// Token: 0x04004EE5 RID: 20197
	private CString interestText;

	// Token: 0x04004EE6 RID: 20198
	private CString fundsText;

	// Token: 0x04004EE7 RID: 20199
	private CString profitText;

	// Token: 0x04004EE8 RID: 20200
	private CString timeText;

	// Token: 0x04004EE9 RID: 20201
	private CString MaxFundText;

	// Token: 0x04004EEA RID: 20202
	private ushort funds;

	// Token: 0x04004EEB RID: 20203
	private ushort MaxFunds;

	// Token: 0x04004EEC RID: 20204
	private double interest;

	// Token: 0x04004EED RID: 20205
	private uint profit;

	// Token: 0x04004EEE RID: 20206
	private Image Light;

	// Token: 0x04004EEF RID: 20207
	private float LightTime;

	// Token: 0x02000537 RID: 1335
	private enum e_AGS_UI_CryptDig_Editor
	{
		// Token: 0x04004EF1 RID: 20209
		BGFrame,
		// Token: 0x04004EF2 RID: 20210
		BGFrameTitle,
		// Token: 0x04004EF3 RID: 20211
		BGFrameLTop,
		// Token: 0x04004EF4 RID: 20212
		BGFrameRTop,
		// Token: 0x04004EF5 RID: 20213
		exitImage,
		// Token: 0x04004EF6 RID: 20214
		BGImage,
		// Token: 0x04004EF7 RID: 20215
		Main,
		// Token: 0x04004EF8 RID: 20216
		frame2,
		// Token: 0x04004EF9 RID: 20217
		Timebar,
		// Token: 0x04004EFA RID: 20218
		Funds,
		// Token: 0x04004EFB RID: 20219
		SuperBtn,
		// Token: 0x04004EFC RID: 20220
		BGFrameLeft,
		// Token: 0x04004EFD RID: 20221
		BGFrameRight
	}

	// Token: 0x02000538 RID: 1336
	private enum e_AGS_Main
	{
		// Token: 0x04004EFF RID: 20223
		frame,
		// Token: 0x04004F00 RID: 20224
		Icon,
		// Token: 0x04004F01 RID: 20225
		frame2,
		// Token: 0x04004F02 RID: 20226
		Desc1,
		// Token: 0x04004F03 RID: 20227
		Desc2,
		// Token: 0x04004F04 RID: 20228
		Desc3,
		// Token: 0x04004F05 RID: 20229
		Desc4,
		// Token: 0x04004F06 RID: 20230
		Desc5,
		// Token: 0x04004F07 RID: 20231
		Value1,
		// Token: 0x04004F08 RID: 20232
		Value2,
		// Token: 0x04004F09 RID: 20233
		Value3,
		// Token: 0x04004F0A RID: 20234
		Value4,
		// Token: 0x04004F0B RID: 20235
		Value5
	}

	// Token: 0x02000539 RID: 1337
	private enum e_AGS_Timebar
	{
		// Token: 0x04004F0D RID: 20237
		GemBg,
		// Token: 0x04004F0E RID: 20238
		Icon1,
		// Token: 0x04004F0F RID: 20239
		desc,
		// Token: 0x04004F10 RID: 20240
		GemValue,
		// Token: 0x04004F11 RID: 20241
		Bar
	}

	// Token: 0x0200053A RID: 1338
	private enum e_AGS_Bar
	{
		// Token: 0x04004F13 RID: 20243
		Bar,
		// Token: 0x04004F14 RID: 20244
		Text
	}

	// Token: 0x0200053B RID: 1339
	private enum e_AGS_Funds
	{
		// Token: 0x04004F16 RID: 20246
		Icon1,
		// Token: 0x04004F17 RID: 20247
		Text,
		// Token: 0x04004F18 RID: 20248
		Text2
	}

	// Token: 0x0200053C RID: 1340
	private enum e_AGS_SuperBtn
	{
		// Token: 0x04004F1A RID: 20250
		Image,
		// Token: 0x04004F1B RID: 20251
		Text,
		// Token: 0x04004F1C RID: 20252
		desc
	}
}
