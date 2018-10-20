using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000578 RID: 1400
public class UIArena_Hint : IUIButtonDownUpHandler
{
	// Token: 0x06001BDA RID: 7130 RVA: 0x00317A80 File Offset: 0x00315C80
	public void Load()
	{
		GUIManager instance = GUIManager.Instance;
		UnityEngine.Object @object = instance.m_Arena_HintAssetBundle.Load("UIArena_Hint");
		if (@object == null)
		{
			return;
		}
		this.m_StrRank = StringManager.Instance.SpawnString(30);
		this.m_StrStrength = StringManager.Instance.SpawnString(30);
		this.m_StrName = StringManager.Instance.SpawnString(30);
		for (int i = 0; i < 16; i++)
		{
			this.m_dataNum[i] = StringManager.Instance.SpawnString(30);
		}
		Font ttffont = instance.GetTTFFont();
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
		gameObject.transform.SetParent(instance.m_WindowTopLayer, false);
		gameObject.SetActive(false);
		this.m_RectTransform = (RectTransform)gameObject.transform;
		this.m_RectTransform.GetChild(0).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		this.m_BGRectTransform = this.m_RectTransform.GetChild(0).GetComponent<RectTransform>();
		Transform transform = this.m_BGRectTransform.transform;
		Transform child;
		for (int j = 0; j < 5; j++)
		{
			child = transform.GetChild(j);
			child.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
			child = transform.GetChild(j).GetChild(0);
			this.m_HeroBtn[j] = child.GetComponent<UIHIBtn>();
			instance.InitianHeroItemImg(child, eHeroOrItem.Hero, 1, 0, 0, 0, true, true, true, false);
			child = transform.GetChild(j).GetChild(1);
			this.m_Frame[j] = child.GetComponent<Image>();
			child.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
			child = transform.GetChild(j).GetChild(2);
			this.m_Astrology[j] = child.GetComponent<Image>();
			child.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		}
		child = transform.GetChild(5);
		this.m_Rank = child.GetComponent<Image>();
		child.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		if (instance.IsArabic)
		{
			child.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		child = transform.GetChild(5).GetChild(0);
		this.m_TextRank = child.GetComponent<UIText>();
		this.m_TextRank.font = ttffont;
		child = transform.GetChild(6);
		this.m_ST = child.GetComponent<Image>();
		child.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		child = transform.GetChild(6).GetChild(0);
		this.m_TextStrength = child.GetComponent<UIText>();
		this.m_TextStrength.font = ttffont;
		child = transform.GetChild(7);
		this.m_Line = child.GetComponent<Image>();
		child.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		child = transform.GetChild(8);
		this.m_TextName = child.GetComponent<UIText>();
		this.m_TextName.font = ttffont;
		this.m_RectTransform.GetChild(1).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		this.m_BGRectTransform2 = this.m_RectTransform.GetChild(1).GetComponent<RectTransform>();
		this.mSprite[0] = instance.LoadFrameSprite("UI_legion_icon_a");
		this.mSprite[1] = instance.LoadFrameSprite("UI_legion_icon_b");
		this.mSprite[2] = instance.LoadFrameSprite("UI_legion_icon_c");
		this.mSprite[3] = instance.LoadFrameSprite("UI_legion_icon_d");
		this.m_MT = instance.GetFrameMaterial();
		transform = this.m_BGRectTransform2.transform;
		for (int k = 0; k < 5; k++)
		{
			child = transform.GetChild(k);
			child.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
			child = transform.GetChild(k).GetChild(0);
			this.m_HeroBtn2[k] = child.GetComponent<UIHIBtn>();
			GUIManager.Instance.InitianHeroItemImg(child, eHeroOrItem.Hero, 1, 0, 0, 0, true, true, true, false);
			child = transform.GetChild(k).GetChild(1);
			this.m_Frame2[k] = child.GetComponent<Image>();
			child.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
			if (k == 0)
			{
				child = transform.GetChild(k).GetChild(2);
				this.m_Main[0] = child.GetComponent<Image>();
				child.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
				child = transform.GetChild(k).GetChild(2).GetChild(0);
				this.m_Main[1] = child.GetComponent<Image>();
				child.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
			}
		}
		child = transform.GetChild(5);
		this.m_Line2 = child.GetComponent<Image>();
		child.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		for (int l = 0; l < 16; l++)
		{
			this.m_T_data[l] = transform.GetChild(5).GetChild(l);
			child = this.m_T_data[l].GetChild(0);
			this.m_data_Icon[l] = child.GetComponent<Image>();
			this.m_data_Icon[l].material = this.m_MT;
			child = this.m_T_data[l].GetChild(1);
			this.m_Text_data_Rank[l] = child.GetComponent<UIText>();
			this.m_Text_data_Rank[l].font = ttffont;
			child = this.m_T_data[l].GetChild(2);
			this.m_Text_data_Name[l] = child.GetComponent<UIText>();
			this.m_Text_data_Name[l].font = ttffont;
			child = this.m_T_data[l].GetChild(3);
			this.m_Text_data_Num[l] = child.GetComponent<UIText>();
			this.m_Text_data_Num[l].font = ttffont;
		}
		child = transform.GetChild(6);
		this.m_TextName2 = child.GetComponent<UIText>();
		this.m_TextName2.font = ttffont;
		child = transform.GetChild(7);
		this.m_Text_F = child.GetComponent<UIText>();
		this.m_Text_F.font = ttffont;
	}

	// Token: 0x06001BDB RID: 7131 RVA: 0x0031806C File Offset: 0x0031626C
	public void UnLoad()
	{
		if (this.m_StrRank != null)
		{
			StringManager.Instance.DeSpawnString(this.m_StrRank);
		}
		if (this.m_StrStrength != null)
		{
			StringManager.Instance.DeSpawnString(this.m_StrStrength);
		}
		if (this.m_StrName != null)
		{
			StringManager.Instance.DeSpawnString(this.m_StrName);
		}
		for (int i = 0; i < 16; i++)
		{
			if (this.m_dataNum[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_dataNum[i]);
			}
		}
	}

	// Token: 0x06001BDC RID: 7132 RVA: 0x00318100 File Offset: 0x00316300
	public void Show(UIButtonHint hint, float X = 0f, float Y = 0f, byte type = 0)
	{
		if (this.m_RectTransform.gameObject.activeSelf)
		{
			this.Hide(this.m_ButtonHint);
		}
		this.m_RectTransform.gameObject.SetActive(true);
		ArenaManager instance = ArenaManager.Instance;
		this.m_StrRank.ClearString();
		this.m_StrStrength.ClearString();
		this.m_StrName.ClearString();
		this.Type = type;
		if (this.Type == 0)
		{
			this.m_BGRectTransform.anchoredPosition = new Vector2(X, Y);
			this.m_BGRectTransform.gameObject.SetActive(true);
			this.m_BGRectTransform2.gameObject.SetActive(false);
			for (int i = 0; i < 5; i++)
			{
				if (instance.m_ArenaTargetHint.HeroData != null && instance.m_ArenaTargetHint.HeroData[i].ID != 0)
				{
					this.m_HeroBtn[i].gameObject.SetActive(true);
					this.m_Frame[i].gameObject.SetActive(false);
					GUIManager.Instance.ChangeHeroItemImg(this.m_HeroBtn[i].transform, eHeroOrItem.Hero, instance.m_ArenaTargetHint.HeroData[i].ID, instance.m_ArenaTargetHint.HeroData[i].Star, instance.m_ArenaTargetHint.HeroData[i].Rank, (int)instance.m_ArenaTargetHint.HeroData[i].Level);
					if (instance.CheckHeroAstrology(instance.m_ArenaTargetHint.HeroData[i].ID))
					{
						this.m_Astrology[i].gameObject.SetActive(true);
					}
					else
					{
						this.m_Astrology[i].gameObject.SetActive(false);
					}
				}
				else
				{
					this.m_Astrology[i].gameObject.SetActive(false);
					this.m_HeroBtn[i].gameObject.SetActive(false);
					this.m_Frame[i].gameObject.SetActive(true);
				}
			}
			this.m_StrRank.IntToFormat((long)((ulong)instance.m_ArenaTargetHint.Place), 1, true);
			this.m_StrRank.AppendFormat("{0}");
			this.m_TextRank.text = this.m_StrRank.ToString();
			this.m_TextRank.SetAllDirty();
			this.m_TextRank.cachedTextGenerator.Invalidate();
			this.m_StrStrength.IntToFormat((long)((ulong)instance.GetAllPower(0, 0)), 1, true);
			this.m_StrStrength.AppendFormat("{0}");
			this.m_TextStrength.text = this.m_StrStrength.ToString();
			this.m_TextStrength.SetAllDirty();
			this.m_TextStrength.cachedTextGenerator.Invalidate();
			CString cstring = StringManager.Instance.StaticString1024();
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring2.ClearString();
			cstring.Append(instance.m_ArenaTargetHint.Name);
			if (instance.m_ArenaTargetHint.AllianceTagTag != string.Empty)
			{
				cstring2.Append(instance.m_ArenaTargetHint.AllianceTagTag);
				GameConstants.FormatRoleName(this.m_StrName, cstring, cstring2, null, 0, 0, null, null, null, null);
			}
			else
			{
				GameConstants.FormatRoleName(this.m_StrName, cstring, null, null, 0, 0, null, null, null, null);
			}
			this.m_TextName.text = this.m_StrName.ToString();
			this.m_TextName.SetAllDirty();
			this.m_TextName.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001BDD RID: 7133 RVA: 0x0031847C File Offset: 0x0031667C
	public void ShowHint(byte type = 1, RectTransform tipRect = null)
	{
		this.m_RectTransform.gameObject.SetActive(true);
		this.Type = type;
		AllianceWarManager allianceWarMgr = ActivityManager.Instance.AllianceWarMgr;
		if (this.Type == 1)
		{
			this.m_BGRectTransform.gameObject.SetActive(false);
			this.m_BGRectTransform2.gameObject.SetActive(true);
			this.m_Main[0].gameObject.SetActive(false);
			float num = 0f;
			bool flag = GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 17;
			this.m_Text_F.gameObject.SetActive(flag);
			if (flag)
			{
				num += 22f;
				this.m_Line2.rectTransform.anchoredPosition = new Vector2(this.m_Line2.rectTransform.anchoredPosition.x, -161f);
			}
			else
			{
				this.m_Line2.rectTransform.anchoredPosition = new Vector2(this.m_Line2.rectTransform.anchoredPosition.x, -139f);
			}
			this.m_Main[0].gameObject.SetActive(allianceWarMgr.m_AllianceWarHintData.bMain);
			for (int i = 0; i < 5; i++)
			{
				if (allianceWarMgr.m_AllianceWarHintData.HeroData[i].ID != 0)
				{
					this.m_HeroBtn2[i].gameObject.SetActive(true);
					this.m_Frame2[i].gameObject.SetActive(false);
					GUIManager.Instance.ChangeHeroItemImg(this.m_HeroBtn2[i].transform, eHeroOrItem.Hero, allianceWarMgr.m_AllianceWarHintData.HeroData[i].ID, allianceWarMgr.m_AllianceWarHintData.HeroData[i].Star, allianceWarMgr.m_AllianceWarHintData.HeroData[i].Rank, 0);
				}
				else
				{
					this.m_HeroBtn2[i].gameObject.SetActive(false);
					this.m_Frame2[i].gameObject.SetActive(true);
				}
			}
			DataManager instance = DataManager.Instance;
			this.m_StrStrength.ClearString();
			this.m_StrStrength.Append(instance.mStringTable.GetStringByID(9788u));
			this.m_StrStrength.Append(instance.mStringTable.GetStringByID((uint)((ushort)(9778 + (int)allianceWarMgr.m_AllianceWarHintData.ArmyCoordIndex))));
			this.m_Text_F.text = this.m_StrStrength.ToString();
			this.m_Text_F.SetAllDirty();
			this.m_Text_F.cachedTextGenerator.Invalidate();
			int num2 = 0;
			for (int j = 0; j < 16; j++)
			{
				int num3 = 3 - j / 4 + j % 4 * 4;
				if (allianceWarMgr.m_AllianceWarHintData.TroopData[num3] > 0u)
				{
					SoldierData recordByKey = instance.SoldierDataTable.GetRecordByKey((ushort)(num3 + 1));
					this.m_dataNum[num2].ClearString();
					if ((int)recordByKey.SoldierKind < this.mSprite.Length)
					{
						this.m_data_Icon[num2].sprite = this.mSprite[(int)recordByKey.SoldierKind];
					}
					else
					{
						this.m_data_Icon[num2].sprite = this.mSprite[0];
					}
					this.m_Text_data_Rank[num2].text = recordByKey.Tier.ToString();
					this.m_Text_data_Name[num2].text = instance.mStringTable.GetStringByID((uint)recordByKey.Name);
					this.m_Text_data_Name[num2].SetAllDirty();
					this.m_Text_data_Name[num2].cachedTextGenerator.Invalidate();
					this.m_Text_data_Name[num2].cachedTextGeneratorForLayout.Invalidate();
					this.m_dataNum[num2].ClearString();
					this.m_dataNum[num2].IntToFormat((long)((ulong)allianceWarMgr.m_AllianceWarHintData.TroopData[num3]), 1, true);
					this.m_dataNum[num2].AppendFormat("{0}");
					this.m_Text_data_Num[num2].text = this.m_dataNum[num2].ToString();
					this.m_Text_data_Num[num2].SetAllDirty();
					this.m_Text_data_Num[num2].cachedTextGenerator.Invalidate();
					this.m_Text_data_Num[num2].cachedTextGeneratorForLayout.Invalidate();
					this.m_T_data[num2].gameObject.SetActive(true);
					num2++;
				}
			}
			for (int k = num2; k < 16; k++)
			{
				this.m_T_data[k].gameObject.SetActive(false);
			}
			num += (float)(num2 * 28);
			this.m_BGRectTransform2.sizeDelta = new Vector2(this.m_BGRectTransform2.sizeDelta.x, 170f + num);
			RectTransform component = GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>();
			this.m_BGRectTransform2.anchoredPosition = new Vector2(0f, 0f);
			CString cstring = StringManager.Instance.StaticString1024();
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring2.ClearString();
			cstring.Append(allianceWarMgr.m_AllianceWarHintData.Name);
			if (allianceWarMgr.m_AllianceWarHintData.AllianceTagTag != string.Empty)
			{
				cstring2.Append(allianceWarMgr.m_AllianceWarHintData.AllianceTagTag);
				GameConstants.FormatRoleName(this.m_StrName, cstring, cstring2, null, 0, 0, null, null, null, null);
			}
			else
			{
				GameConstants.FormatRoleName(this.m_StrName, cstring, null, null, 0, 0, null, null, null, null);
			}
			this.m_TextName2.text = this.m_StrName.ToString();
			this.m_TextName2.SetAllDirty();
			this.m_TextName2.cachedTextGenerator.Invalidate();
			if (tipRect != null)
			{
				this.GetTipPosition(tipRect);
			}
		}
	}

	// Token: 0x06001BDE RID: 7134 RVA: 0x00318A54 File Offset: 0x00316C54
	public void Hide(UIButtonHint hint)
	{
		this.m_RectTransform.gameObject.SetActive(false);
	}

	// Token: 0x06001BDF RID: 7135 RVA: 0x00318A68 File Offset: 0x00316C68
	public void Hide()
	{
		this.m_RectTransform.gameObject.SetActive(false);
	}

	// Token: 0x06001BE0 RID: 7136 RVA: 0x00318A7C File Offset: 0x00316C7C
	public void OnButtonDown(UIButtonHint sender)
	{
		this.Show(sender, (float)sender.Parm2, 0f, 0);
	}

	// Token: 0x06001BE1 RID: 7137 RVA: 0x00318A94 File Offset: 0x00316C94
	public void OnButtonUp(UIButtonHint sender)
	{
		this.Hide(sender);
	}

	// Token: 0x06001BE2 RID: 7138 RVA: 0x00318AA0 File Offset: 0x00316CA0
	public void TextRefresh()
	{
		if (this.m_TextRank != null && this.m_TextRank.enabled)
		{
			this.m_TextRank.enabled = false;
			this.m_TextRank.enabled = true;
		}
		if (this.m_TextStrength != null && this.m_TextStrength.enabled)
		{
			this.m_TextStrength.enabled = false;
			this.m_TextStrength.enabled = true;
		}
		if (this.m_TextName != null && this.m_TextName.enabled)
		{
			this.m_TextName.enabled = false;
			this.m_TextName.enabled = true;
		}
		if (this.m_TextName2 != null && this.m_TextName2.enabled)
		{
			this.m_TextName2.enabled = false;
			this.m_TextName2.enabled = true;
		}
		if (this.m_Text_F != null && this.m_Text_F.enabled)
		{
			this.m_Text_F.enabled = false;
			this.m_Text_F.enabled = true;
		}
		for (int i = 0; i < 5; i++)
		{
			if (this.m_HeroBtn[i] != null && this.m_HeroBtn[i].enabled)
			{
				this.m_HeroBtn[i].Refresh_FontTexture();
			}
			if (this.m_HeroBtn2[i] != null && this.m_HeroBtn2[i].enabled)
			{
				this.m_HeroBtn2[i].Refresh_FontTexture();
			}
		}
		for (int j = 0; j < 16; j++)
		{
			if (this.m_Text_data_Rank[j] != null && this.m_Text_data_Rank[j].enabled)
			{
				this.m_Text_data_Rank[j].enabled = false;
				this.m_Text_data_Rank[j].enabled = true;
			}
			if (this.m_Text_data_Name[j] != null && this.m_Text_data_Name[j].enabled)
			{
				this.m_Text_data_Name[j].enabled = false;
				this.m_Text_data_Name[j].enabled = true;
			}
			if (this.m_Text_data_Num[j] != null && this.m_Text_data_Num[j].enabled)
			{
				this.m_Text_data_Num[j].enabled = false;
				this.m_Text_data_Num[j].enabled = true;
			}
		}
	}

	// Token: 0x06001BE3 RID: 7139 RVA: 0x00318D18 File Offset: 0x00316F18
	public void UpdateUI()
	{
		if (this.Type != 0)
		{
			return;
		}
		ArenaManager instance = ArenaManager.Instance;
		this.m_StrRank.ClearString();
		this.m_StrStrength.ClearString();
		this.m_StrName.ClearString();
		for (int i = 0; i < 5; i++)
		{
			if (instance.m_ArenaTargetHint.HeroData != null && instance.m_ArenaTargetHint.HeroData[i].ID != 0)
			{
				this.m_HeroBtn[i].gameObject.SetActive(true);
				this.m_Frame[i].gameObject.SetActive(false);
				GUIManager.Instance.ChangeHeroItemImg(this.m_HeroBtn[i].transform, eHeroOrItem.Hero, instance.m_ArenaTargetHint.HeroData[i].ID, instance.m_ArenaTargetHint.HeroData[i].Star, instance.m_ArenaTargetHint.HeroData[i].Rank, (int)instance.m_ArenaTargetHint.HeroData[i].Level);
				if (instance.CheckHeroAstrology(instance.m_ArenaTargetHint.HeroData[i].ID))
				{
					this.m_Astrology[i].gameObject.SetActive(true);
				}
				else
				{
					this.m_Astrology[i].gameObject.SetActive(false);
				}
			}
			else
			{
				this.m_Astrology[i].gameObject.SetActive(false);
				this.m_HeroBtn[i].gameObject.SetActive(false);
				this.m_Frame[i].gameObject.SetActive(true);
			}
		}
		this.m_StrRank.IntToFormat((long)((ulong)instance.m_ArenaTargetHint.Place), 1, true);
		this.m_StrRank.AppendFormat("{0}");
		this.m_TextRank.text = this.m_StrRank.ToString();
		this.m_TextRank.SetAllDirty();
		this.m_TextRank.cachedTextGenerator.Invalidate();
		this.m_StrStrength.IntToFormat((long)((ulong)instance.GetAllPower(0, 0)), 1, true);
		this.m_StrStrength.AppendFormat("{0}");
		this.m_TextStrength.text = this.m_StrStrength.ToString();
		this.m_TextStrength.SetAllDirty();
		this.m_TextStrength.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001BE4 RID: 7140 RVA: 0x00318F68 File Offset: 0x00317168
	public void GetTipPosition(RectTransform tipRect)
	{
		if (tipRect == null)
		{
			return;
		}
		RectTransform component = GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>();
		Vector2 sizeDelta = component.sizeDelta;
		this.m_BGRectTransform2.position = tipRect.position;
		Vector3 anchoredPosition3D = this.m_BGRectTransform2.anchoredPosition3D;
		anchoredPosition3D.x = 0f;
		anchoredPosition3D.y += tipRect.rect.y;
		anchoredPosition3D.z = 0f;
		if (anchoredPosition3D.y + tipRect.rect.height + this.m_BGRectTransform2.sizeDelta.y / 2f > sizeDelta.y / 2f)
		{
			anchoredPosition3D.y = sizeDelta.y / 2f - this.m_BGRectTransform2.sizeDelta.y / 2f;
		}
		else if (-1f * anchoredPosition3D.y + this.m_BGRectTransform2.sizeDelta.y / 2f > sizeDelta.y / 2f)
		{
			anchoredPosition3D.y = -1f * (sizeDelta.y / 2f - this.m_BGRectTransform2.sizeDelta.y / 2f);
		}
		this.m_BGRectTransform2.anchoredPosition3D = anchoredPosition3D;
	}

	// Token: 0x0400549C RID: 21660
	public RectTransform m_RectTransform;

	// Token: 0x0400549D RID: 21661
	public RectTransform m_BGRectTransform;

	// Token: 0x0400549E RID: 21662
	public RectTransform m_BGRectTransform2;

	// Token: 0x0400549F RID: 21663
	public UIButtonHint m_ButtonHint;

	// Token: 0x040054A0 RID: 21664
	public UIHIBtn[] m_HeroBtn = new UIHIBtn[5];

	// Token: 0x040054A1 RID: 21665
	public UIHIBtn[] m_HeroBtn2 = new UIHIBtn[5];

	// Token: 0x040054A2 RID: 21666
	public Image[] m_Frame = new Image[5];

	// Token: 0x040054A3 RID: 21667
	public Image[] m_Frame2 = new Image[5];

	// Token: 0x040054A4 RID: 21668
	public Image[] m_Astrology = new Image[5];

	// Token: 0x040054A5 RID: 21669
	public Image[] m_Main = new Image[2];

	// Token: 0x040054A6 RID: 21670
	public Image[] m_data_Icon = new Image[16];

	// Token: 0x040054A7 RID: 21671
	public UIText m_TextRank;

	// Token: 0x040054A8 RID: 21672
	public UIText m_TextStrength;

	// Token: 0x040054A9 RID: 21673
	public UIText m_TextName;

	// Token: 0x040054AA RID: 21674
	public UIText m_TextName2;

	// Token: 0x040054AB RID: 21675
	public UIText m_Text_F;

	// Token: 0x040054AC RID: 21676
	public UIText[] m_Text_data_Rank = new UIText[16];

	// Token: 0x040054AD RID: 21677
	public UIText[] m_Text_data_Name = new UIText[16];

	// Token: 0x040054AE RID: 21678
	public UIText[] m_Text_data_Num = new UIText[16];

	// Token: 0x040054AF RID: 21679
	private CString m_StrRank;

	// Token: 0x040054B0 RID: 21680
	private CString m_StrStrength;

	// Token: 0x040054B1 RID: 21681
	private CString m_StrName;

	// Token: 0x040054B2 RID: 21682
	public CString[] m_dataNum = new CString[16];

	// Token: 0x040054B3 RID: 21683
	public Image m_Rank;

	// Token: 0x040054B4 RID: 21684
	public Image m_ST;

	// Token: 0x040054B5 RID: 21685
	public Image m_Line;

	// Token: 0x040054B6 RID: 21686
	public Image m_Line2;

	// Token: 0x040054B7 RID: 21687
	public byte Type;

	// Token: 0x040054B8 RID: 21688
	public Transform[] m_T_data = new Transform[16];

	// Token: 0x040054B9 RID: 21689
	public Sprite[] mSprite = new Sprite[4];

	// Token: 0x040054BA RID: 21690
	public Material m_MT;
}
