using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000574 RID: 1396
public class UISkillInfo : IMotionUpdate, UILoadImageHander
{
	// Token: 0x06001BC1 RID: 7105 RVA: 0x00314C5C File Offset: 0x00312E5C
	public void Load()
	{
		UnityEngine.Object @object = GUIManager.Instance.m_ManagerAssetBundle.Load("UI_SkillInfo");
		if (@object == null)
		{
			return;
		}
		GUIManager instance = GUIManager.Instance;
		Font ttffont = instance.GetTTFFont();
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
		gameObject.transform.SetParent(GUIManager.Instance.m_WindowTopLayer, false);
		gameObject.SetActive(false);
		this.m_RectTransform = (gameObject.transform as RectTransform);
		this.Canvasgroup = this.m_RectTransform.GetComponent<CanvasGroup>();
		this.m_RectTransform.GetComponent<CustomImage>().hander = this;
		this.m_RectTransform.GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_RectTransform.GetChild(4).GetComponent<CustomImage>().hander = this;
		this.m_RectTransform.GetChild(5).GetComponent<CustomImage>().hander = this;
		this.LegionTrans = (this.m_RectTransform.GetChild(7) as RectTransform);
		for (int i = 0; i < 5; i++)
		{
			this.m_RectTransform.GetChild(7).GetChild(i).GetComponent<CustomImage>().hander = this;
			this.m_RectTransform.GetChild(7).GetChild(i).GetChild(0).GetComponent<CustomImage>().hander = this;
			this.BadgeText[i] = this.m_RectTransform.GetChild(7).GetChild(i).GetChild(1).GetComponent<UIText>();
			this.BadgeText[i].font = ttffont;
			this.BadgeTransform[i] = (this.m_RectTransform.GetChild(7).GetChild(i) as RectTransform);
		}
		this.Name = this.m_RectTransform.GetChild(1).GetComponent<UIText>();
		this.Name.font = ttffont;
		this.Kind = this.m_RectTransform.GetChild(2).GetComponent<UIText>();
		this.Kind.font = ttffont;
		this.Content = this.m_RectTransform.GetChild(3).GetComponent<UIText>();
		this.Content.font = ttffont;
		this.Prop = this.m_RectTransform.GetChild(6).GetComponent<UIText>();
		this.Prop.font = ttffont;
		this.SkillIcon = this.m_RectTransform.GetChild(0).GetComponent<Image>();
		this.Divider1 = (this.m_RectTransform.GetChild(4) as RectTransform);
		this.Divider2 = (this.m_RectTransform.GetChild(5) as RectTransform);
		this.RequireMsg = this.m_RectTransform.GetChild(8).GetComponent<UIText>();
		this.RequireMsg.font = ttffont;
		for (int j = 0; j < this.m_tmpStr.Length; j++)
		{
			this.m_tmpStr[j] = StringManager.Instance.SpawnString(400);
		}
		this.m_tmpStrlong = StringManager.Instance.SpawnString(800);
		this.BadgeMotion = new EasingEffect();
		this.BadgeMotion.Motion = this;
		this.CanvasRect = instance.m_UICanvas.GetComponent<RectTransform>();
		this.Divider2.gameObject.SetActive(false);
	}

	// Token: 0x06001BC2 RID: 7106 RVA: 0x00314F7C File Offset: 0x0031317C
	public unsafe void Show(UIButtonHint hint, uint HeroID, byte SkillIndex, ushort HeroAttrValA, ushort HeroAttrValB, bool bPreview = false)
	{
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		byte b = SkillIndex;
		if (this.m_RectTransform.gameObject.activeSelf)
		{
			this.Hide(this.m_ButtonHint);
		}
		CurHeroData curHeroData;
		if (bPreview)
		{
			curHeroData = instance.PreviewHeroData;
		}
		else
		{
			if (!instance.curHeroData.ContainsKey(HeroID))
			{
				return;
			}
			curHeroData = instance.curHeroData[HeroID];
		}
		Hero recordByKey = instance.HeroTable.GetRecordByKey(curHeroData.ID);
		if (recordByKey.AttackPower == null || curHeroData.SkillLV == null)
		{
			return;
		}
		Skill recordByKey2;
		if (SkillIndex < 4)
		{
			recordByKey2 = instance.SkillTable.GetRecordByKey(recordByKey.AttackPower[(int)(SkillIndex + 1)]);
		}
		else
		{
			ushort* ptr = stackalloc ushort[checked(4 * 2)];
			*ptr = recordByKey.GroupSkill1;
			ptr[1] = recordByKey.GroupSkill2;
			ptr[2] = recordByKey.GroupSkill3;
			ptr[3] = recordByKey.GroupSkill4;
			recordByKey2 = instance.SkillTable.GetRecordByKey(ptr[SkillIndex - 4]);
			b -= 4;
		}
		this.HeroEnhance = curHeroData.Star;
		this.SkillIndex = SkillIndex;
		this.HeroAttrValA = HeroAttrValA;
		this.HeroAttrValB = HeroAttrValB;
		this.m_tmpStr[5].ClearString();
		this.m_tmpStr[5].Append('s');
		this.m_tmpStr[5].IntToFormat((long)recordByKey2.SkillIcon, 5, false);
		this.m_tmpStr[5].AppendFormat("{0}");
		this.SkillIcon.sprite = instance2.LoadSkillSprite(this.m_tmpStr[5]);
		this.SkillIcon.material = instance2.GetSkillMaterial();
		this.Name.text = instance.mStringTable.GetStringByID((uint)recordByKey2.SkillName);
		this.m_tmpStrlong.ClearString();
		if (recordByKey2.Describe > 0)
		{
			this.m_tmpStrlong.Append(instance.mStringTable.GetStringByID((uint)recordByKey2.Describe));
		}
		if (recordByKey2.SkillType >= 10 && recordByKey2.SkillType <= 12)
		{
			this.ShowLegionHint(ref recordByKey2);
		}
		else
		{
			if (curHeroData.SkillLV.Length <= (int)SkillIndex)
			{
				this.Hide(this.m_ButtonHint);
				return;
			}
			this.ShowHerohint(ref recordByKey2, curHeroData.SkillLV[(int)SkillIndex]);
		}
		if (curHeroData.SkillLV[(int)b] == 0)
		{
			uint id;
			if (SkillIndex == 1 || SkillIndex == 5)
			{
				id = 482u;
			}
			else if (SkillIndex == 2 || SkillIndex == 6)
			{
				id = 483u;
			}
			else
			{
				id = 484u;
			}
			this.m_tmpStr[5].ClearString();
			this.m_tmpStr[5].StringToFormat(instance.mStringTable.GetStringByID(id));
			this.m_tmpStr[5].AppendFormat("<color=#ff846dff>{0}</color>");
			this.RequireMsg.text = this.m_tmpStr[5].ToString();
			this.RequireMsg.SetAllDirty();
			this.RequireMsg.cachedTextGenerator.Invalidate();
			this.RequireIdx = 1;
		}
		else if (SkillIndex >= 4)
		{
			this.m_tmpStr[5].ClearString();
			this.m_tmpStr[5].Append("<color=#8b765fff>");
			this.m_tmpStr[5].Append(instance.mStringTable.GetStringByID(10134u - (uint)(recordByKey2.SkillType % 10)));
			this.m_tmpStr[5].Append("</color>");
			this.RequireMsg.text = this.m_tmpStr[5].ToString();
			this.RequireMsg.SetAllDirty();
			this.RequireMsg.cachedTextGenerator.Invalidate();
			this.RequireIdx = 1;
		}
		Vector2 anchoredPosition = this.Content.rectTransform.anchoredPosition;
		Vector2 sizeDelta = this.Content.rectTransform.sizeDelta;
		sizeDelta.y = this.Content.preferredHeight;
		this.Content.rectTransform.sizeDelta = sizeDelta;
		anchoredPosition.x = this.Divider1.anchoredPosition.x;
		anchoredPosition.y += -this.Content.preferredHeight - 12f;
		this.Divider1.anchoredPosition = anchoredPosition;
		if (this.Prop.text != string.Empty)
		{
			sizeDelta = this.Prop.rectTransform.sizeDelta;
			sizeDelta.y = this.Prop.preferredHeight;
			this.Prop.rectTransform.sizeDelta = sizeDelta;
			anchoredPosition.y += -17f;
			anchoredPosition.x = this.Prop.rectTransform.anchoredPosition.x;
			this.Prop.rectTransform.anchoredPosition = anchoredPosition;
			anchoredPosition.y += -this.Prop.preferredHeight - 3f;
		}
		else
		{
			this.Divider1.gameObject.SetActive(false);
			anchoredPosition.y += -3f;
		}
		float num = 0f;
		if (this.LegionTrans.gameObject.activeSelf)
		{
			num = 72f;
			bool isArabic = instance2.IsArabic;
			for (int i = 0; i < 5; i++)
			{
				anchoredPosition.x = this.BadgeTransform[i].anchoredPosition.x;
				this.BadgeTransform[i].anchoredPosition = anchoredPosition;
				this.m_tmpStr[i].ClearString();
				if (recordByKey2.HurtKind == 1)
				{
					this.m_tmpStr[i].FloatToFormat((float)(recordByKey2.HurtIncreaseValue * (ushort)this.LegionRankMagnifation[i]), -1, true);
					this.m_tmpStr[i].AppendFormat("{0}");
				}
				else
				{
					this.m_tmpStr[i].FloatToFormat((float)recordByKey2.HurtValue + (float)recordByKey2.HurtIncreaseValue / 1000f * (float)this.LegionRankMagnifation[i], -1, true);
					if (GUIManager.Instance.IsArabic)
					{
						this.m_tmpStr[i].AppendFormat("%{0}");
					}
					else
					{
						this.m_tmpStr[i].AppendFormat("{0}%");
					}
				}
				this.BadgeText[i].text = this.m_tmpStr[i].ToString();
				this.BadgeText[i].SetAllDirty();
				this.BadgeText[i].cachedTextGenerator.Invalidate();
			}
		}
		if (this.RequireIdx > 0)
		{
			this.Divider2.gameObject.SetActive(true);
			anchoredPosition.x = this.Divider2.anchoredPosition.x;
			anchoredPosition.y += -3f - num;
			this.Divider2.anchoredPosition = anchoredPosition;
			anchoredPosition.x = this.RequireMsg.rectTransform.anchoredPosition.x;
			anchoredPosition.y += -17f;
			this.RequireMsg.rectTransform.anchoredPosition = anchoredPosition;
			sizeDelta = this.RequireMsg.rectTransform.sizeDelta;
			sizeDelta.y = this.RequireMsg.preferredHeight;
			this.RequireMsg.rectTransform.sizeDelta = sizeDelta;
			sizeDelta.y = sizeDelta.y + anchoredPosition.y * -1f + 23f;
			sizeDelta.x = this.m_RectTransform.sizeDelta.x;
			this.m_RectTransform.sizeDelta = sizeDelta;
		}
		else
		{
			sizeDelta = this.m_RectTransform.sizeDelta;
			sizeDelta.y = anchoredPosition.y * -1f + 14f + num;
			this.m_RectTransform.sizeDelta = sizeDelta;
		}
		Vector3 anchoredPosition3D = this.m_RectTransform.anchoredPosition3D;
		if (this.m_RectTransform.sizeDelta.y + 75f < this.CanvasRect.sizeDelta.y)
		{
			anchoredPosition3D.Set(-230f, -75f, 0f);
		}
		else
		{
			if (this.CanvasRect.sizeDelta.y < this.m_RectTransform.sizeDelta.y)
			{
				this.Prop.fontSize--;
				this.Content.fontSize--;
				this.Show(hint, HeroID, SkillIndex, HeroAttrValA, HeroAttrValB, bPreview);
				return;
			}
			anchoredPosition3D.Set(-230f, this.m_RectTransform.sizeDelta.y - this.CanvasRect.sizeDelta.y, 0f);
		}
		this.m_RectTransform.gameObject.SetActive(true);
		this.m_RectTransform.anchoredPosition3D = anchoredPosition3D;
		this.m_ButtonHint = hint;
		this.Canvasgroup.alpha = 1f;
	}

	// Token: 0x06001BC3 RID: 7107 RVA: 0x003158A0 File Offset: 0x00313AA0
	private void ShowLegionHint(ref Skill skill)
	{
		DataManager instance = DataManager.Instance;
		this.LegionTrans.gameObject.SetActive(true);
		this.Kind.text = instance.mStringTable.GetStringByID(485u + (uint)(skill.SkillType % 10));
		this.Prop.text = instance.mStringTable.GetStringByID(488u);
		this.BadgeTransform[(int)(this.HeroEnhance - 1)].GetChild(0).gameObject.SetActive(true);
		if (this.BadgeIndex < 0)
		{
			this.BadgeIndex = (int)MotionEffect.SetStack(this.BadgeMotion);
		}
		this.GetLegionHintStr(this.HeroEnhance, ref skill, ref this.m_tmpStrlong, 0);
		this.Content.text = this.m_tmpStrlong.ToString();
		this.Content.SetAllDirty();
		this.Content.cachedTextGenerator.Invalidate();
		this.Content.cachedTextGeneratorForLayout.Invalidate();
	}

	// Token: 0x06001BC4 RID: 7108 RVA: 0x00315998 File Offset: 0x00313B98
	public void GetLegionHintStr(byte heroEnhance, ref Skill skill, ref CString Content, byte RankStr = 0)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring.Append(Content);
		float num = (float)skill.HurtValue + (float)((ushort)this.LegionRankMagnifation[(int)(heroEnhance - 1)] * skill.HurtIncreaseValue) / 1000f;
		if (skill.HurtKind == 1)
		{
			GameConstants.GetEffectValue(Content, skill.HurtAddition, 0u, 7, 0f);
			Content.IntToFormat((long)((ushort)this.LegionRankMagnifation[(int)(heroEnhance - 1)] * skill.HurtIncreaseValue), 1, true);
			Content.AppendFormat("{0}");
		}
		else if (skill.SkillType == 10)
		{
			GameConstants.GetEffectValue(Content, skill.HurtAddition, (uint)num, 1, 0f);
		}
		else
		{
			GameConstants.GetEffectValue(Content, skill.HurtAddition, 0u, 6, num * 100f);
		}
		if (RankStr > 0)
		{
			cstring2.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(15u));
			cstring2.IntToFormat((long)RankStr, 1, false);
			cstring2.StringToFormat(Content);
			if (skill.SkillType == 10)
			{
				cstring2.AppendFormat("<color=#ffff00ff>{0}{1} : {2}</color>");
			}
			else
			{
				cstring2.AppendFormat("<color=#33eb67ff>{0}{1} : {2}</color>");
			}
		}
		else
		{
			cstring2.StringToFormat(Content);
			if (skill.SkillType == 10)
			{
				cstring2.AppendFormat("<color=#ffff00ff>{0}</color>");
			}
			else
			{
				cstring2.AppendFormat("<color=#33eb67ff>{0}</color>");
			}
		}
		cstring2.Insert(0, cstring, -1);
		Content.ClearString();
		Content.Append(cstring2);
	}

	// Token: 0x06001BC5 RID: 7109 RVA: 0x00315B1C File Offset: 0x00313D1C
	private void ShowHerohint(ref Skill skill, byte SkillLv)
	{
		DataManager instance = DataManager.Instance;
		this.LegionTrans.gameObject.SetActive(false);
		uint id;
		switch (skill.SkillType)
		{
		case 1:
			id = 476u;
			break;
		case 2:
			id = 477u;
			break;
		case 3:
		case 4:
		case 5:
			id = 478u;
			break;
		default:
			id = 479u;
			break;
		}
		this.Kind.text = instance.mStringTable.GetStringByID(id);
		this.DisplayLv = 0;
		this.m_tmpStr[1].ClearString();
		if (this.SkillIndex == 0 || this.SkillIndex == 1)
		{
			this.DisplayLv = (int)SkillLv;
		}
		else if (this.SkillIndex == 2)
		{
			this.DisplayLv = (int)(SkillLv + 20);
		}
		else
		{
			this.DisplayLv = (int)(SkillLv + 40);
		}
		if (this.DisplayLv == 60)
		{
			this.m_tmpStr[1].Append(instance.mStringTable.GetStringByID(481u));
		}
		else if (SkillLv >= 1)
		{
			this.m_tmpStr[1].Append(instance.mStringTable.GetStringByID(480u));
		}
		this.m_tmpStrlong.Append("\n");
		string stringByID = instance.mStringTable.GetStringByID((uint)skill.ValueInfo);
		if (stringByID == null)
		{
			return;
		}
		byte b = Math.Max(1, SkillLv);
		this.ValueX = (int)(skill.HurtAddition * this.HeroAttrValA / 1000 + skill.HurtValue + (ushort)b * skill.HurtIncreaseValue / 1000);
		this.ValueY = (int)(skill.StateAddition * this.HeroAttrValB / 1000 + skill.StateValue + (ushort)b * skill.StateIncreaseValue / 1000);
		this.m_tmpStr[0].ClearString();
		this.m_tmpStr[0].IntToFormat((long)(this.DisplayLv - 1), 1, false);
		this.m_tmpStr[0].AppendFormat(instance.mStringTable.GetStringByID(489u));
		this.PraseString(this.m_tmpStrlong, stringByID);
		if (SkillLv >= 1)
		{
			this.DisplayLv++;
			SkillLv += 1;
			this.m_tmpStr[1].Append("\n");
			if (this.DisplayLv <= 60)
			{
				this.m_tmpStr[0].ClearString();
				this.ValueX = (int)(skill.HurtAddition * this.HeroAttrValA / 1000 + skill.HurtValue + (ushort)SkillLv * skill.HurtIncreaseValue / 1000);
				this.ValueY = (int)(skill.StateAddition * this.HeroAttrValB / 1000 + skill.StateValue + (ushort)SkillLv * skill.StateIncreaseValue / 1000);
				this.PraseString(this.m_tmpStr[1], stringByID);
			}
			this.Prop.text = this.m_tmpStr[1].ToString();
			this.Prop.SetAllDirty();
			this.Prop.cachedTextGeneratorForLayout.Invalidate();
		}
		this.Content.text = this.m_tmpStrlong.ToString();
		this.Content.SetAllDirty();
		this.Content.cachedTextGenerator.Invalidate();
		this.Content.cachedTextGeneratorForLayout.Invalidate();
	}

	// Token: 0x06001BC6 RID: 7110 RVA: 0x00315E68 File Offset: 0x00314068
	public void PraseString(CString NewStr, string str)
	{
		int i = 0;
		while (i < str.Length)
		{
			char c = str[i++];
			if (c == '%')
			{
				char c2 = str[i];
				if (c2 != 'x' && c2 != 'y')
				{
					if (c2 != 'b')
					{
						NewStr.Append(c);
					}
					else
					{
						NewStr.Append(this.GetCharString(str[i++]));
					}
				}
				else
				{
					NewStr.IntToFormat((long)this.GetCharVal(str[i++]), 1, true);
					NewStr.AppendFormat("{0}");
				}
			}
			else
			{
				NewStr.Append(c);
			}
		}
	}

	// Token: 0x06001BC7 RID: 7111 RVA: 0x00315F2C File Offset: 0x0031412C
	public int GetCharVal(char ch)
	{
		if (ch == 'x')
		{
			return this.ValueX;
		}
		if (ch == 'y')
		{
			return this.ValueY;
		}
		return 0;
	}

	// Token: 0x06001BC8 RID: 7112 RVA: 0x00315F50 File Offset: 0x00314150
	public string GetCharString(char ch)
	{
		if (ch == 'b')
		{
			int num = this.DisplayLv;
			if (this.SkillIndex == 0 || this.SkillIndex == 1)
			{
				if (num == 0)
				{
					num = 1;
				}
			}
			else if (this.SkillIndex == 2)
			{
				if (num == 20)
				{
					num = 21;
				}
			}
			else if (num == 40)
			{
				num = 41;
			}
			this.m_tmpStr[2].ClearString();
			this.m_tmpStr[2].IntToFormat((long)num, 1, false);
			this.m_tmpStr[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(489u));
			return this.m_tmpStr[2].ToString();
		}
		return this.m_tmpStr[0].ToString();
	}

	// Token: 0x06001BC9 RID: 7113 RVA: 0x00316014 File Offset: 0x00314214
	public void Hide(UIButtonHint hint)
	{
		this.m_RectTransform.gameObject.SetActive(false);
		this.Divider1.gameObject.SetActive(true);
		this.Divider2.gameObject.SetActive(false);
		this.RequireIdx = 0;
		this.SkillIndex = 0;
		this.m_ButtonHint = null;
		this.Prop.text = string.Empty;
		this.RequireMsg.text = string.Empty;
		if (this.HeroEnhance > 0 && this.BadgeTransform.Length > (int)this.HeroEnhance)
		{
			this.BadgeTransform[(int)(this.HeroEnhance - 1)].GetChild(0).gameObject.SetActive(false);
			this.HeroEnhance = 0;
		}
		this.Timer = 0f;
		this.Content.fontSize = 18;
		this.Prop.fontSize = 18;
	}

	// Token: 0x06001BCA RID: 7114 RVA: 0x003160F4 File Offset: 0x003142F4
	public void UnLoad()
	{
		if (this.m_RectTransform == null)
		{
			return;
		}
		for (int i = 0; i < this.m_tmpStr.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.m_tmpStr[i]);
		}
		StringManager.Instance.DeSpawnString(this.m_tmpStrlong);
		UnityEngine.Object.Destroy(this.m_RectTransform.gameObject);
	}

	// Token: 0x06001BCB RID: 7115 RVA: 0x00316160 File Offset: 0x00314360
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			if (img.sprite)
			{
				img.material = door.LoadMaterial();
			}
			else
			{
				img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
				img.material = GUIManager.Instance.GetFrameMaterial();
			}
		}
	}

	// Token: 0x06001BCC RID: 7116 RVA: 0x003161D8 File Offset: 0x003143D8
	public bool UpdateRun(float delta)
	{
		if (!this.m_RectTransform.gameObject.activeSelf)
		{
			if (this.HeroEnhance > 0 && this.BadgeTransform[(int)(this.HeroEnhance - 1)].GetChild(0).gameObject.activeSelf)
			{
				this.BadgeTransform[(int)(this.HeroEnhance - 1)].GetChild(0).gameObject.SetActive(false);
			}
			this.BadgeIndex = -1;
			return false;
		}
		if (this.HeroEnhance > 0 && this.BadgeTransform.Length >= (int)this.HeroEnhance && this.Timer > 0.3f)
		{
			this.BadgeTransform[(int)(this.HeroEnhance - 1)].GetChild(0).gameObject.SetActive(!this.BadgeTransform[(int)(this.HeroEnhance - 1)].GetChild(0).gameObject.activeSelf);
			this.Timer = 0f;
		}
		this.Timer += delta;
		return true;
	}

	// Token: 0x06001BCD RID: 7117 RVA: 0x003162E0 File Offset: 0x003144E0
	public void TextRefresh()
	{
		if (this.m_RectTransform == null || !this.m_RectTransform.gameObject.activeSelf)
		{
			return;
		}
		this.Name.enabled = false;
		this.Name.enabled = true;
		this.Kind.enabled = false;
		this.Kind.enabled = true;
		this.Content.enabled = false;
		this.Content.enabled = true;
		this.Prop.enabled = false;
		this.Prop.enabled = true;
		this.RequireMsg.enabled = false;
		this.RequireMsg.enabled = true;
		for (int i = 0; i < this.BadgeText.Length; i++)
		{
			this.BadgeText[i].enabled = false;
			this.BadgeText[i].enabled = true;
		}
	}

	// Token: 0x04005446 RID: 21574
	public RectTransform m_RectTransform;

	// Token: 0x04005447 RID: 21575
	private RectTransform Divider1;

	// Token: 0x04005448 RID: 21576
	private RectTransform Divider2;

	// Token: 0x04005449 RID: 21577
	private RectTransform LegionTrans;

	// Token: 0x0400544A RID: 21578
	private RectTransform CanvasRect;

	// Token: 0x0400544B RID: 21579
	private RectTransform[] BadgeTransform = new RectTransform[5];

	// Token: 0x0400544C RID: 21580
	private Image SkillIcon;

	// Token: 0x0400544D RID: 21581
	private UIText Name;

	// Token: 0x0400544E RID: 21582
	private UIText Kind;

	// Token: 0x0400544F RID: 21583
	private UIText Content;

	// Token: 0x04005450 RID: 21584
	private UIText Prop;

	// Token: 0x04005451 RID: 21585
	private UIText RequireMsg;

	// Token: 0x04005452 RID: 21586
	private UIText[] BadgeText = new UIText[5];

	// Token: 0x04005453 RID: 21587
	public UIButtonHint m_ButtonHint;

	// Token: 0x04005454 RID: 21588
	private CString[] m_tmpStr = new CString[6];

	// Token: 0x04005455 RID: 21589
	private CString m_tmpStrlong;

	// Token: 0x04005456 RID: 21590
	private readonly byte[] LegionRankMagnifation = new byte[]
	{
		1,
		2,
		4,
		8,
		20
	};

	// Token: 0x04005457 RID: 21591
	private byte RequireIdx;

	// Token: 0x04005458 RID: 21592
	private ushort HeroAttrValA;

	// Token: 0x04005459 RID: 21593
	private ushort HeroAttrValB;

	// Token: 0x0400545A RID: 21594
	private int DisplayLv;

	// Token: 0x0400545B RID: 21595
	private EasingEffect BadgeMotion;

	// Token: 0x0400545C RID: 21596
	private int BadgeIndex = -1;

	// Token: 0x0400545D RID: 21597
	private CanvasGroup Canvasgroup;

	// Token: 0x0400545E RID: 21598
	private float Timer;

	// Token: 0x0400545F RID: 21599
	private byte HeroEnhance;

	// Token: 0x04005460 RID: 21600
	private byte SkillIndex;

	// Token: 0x04005461 RID: 21601
	private int ValueX;

	// Token: 0x04005462 RID: 21602
	private int ValueY;

	// Token: 0x02000575 RID: 1397
	private enum UIControl
	{
		// Token: 0x04005464 RID: 21604
		Icon,
		// Token: 0x04005465 RID: 21605
		Name,
		// Token: 0x04005466 RID: 21606
		Kind,
		// Token: 0x04005467 RID: 21607
		Content,
		// Token: 0x04005468 RID: 21608
		DividerImg1,
		// Token: 0x04005469 RID: 21609
		DividerImg2,
		// Token: 0x0400546A RID: 21610
		Prop,
		// Token: 0x0400546B RID: 21611
		Legion,
		// Token: 0x0400546C RID: 21612
		Require
	}
}
