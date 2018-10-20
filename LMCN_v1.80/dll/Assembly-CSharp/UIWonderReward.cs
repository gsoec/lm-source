using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006C0 RID: 1728
public class UIWonderReward : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUILEBtnClickHandler
{
	// Token: 0x06002105 RID: 8453 RVA: 0x003EC580 File Offset: 0x003EA780
	public override void OnOpen(int arg1, int arg2)
	{
		this.mOpenType = arg1;
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.ActM = ActivityManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.mMaT = this.door.LoadMaterial();
		CString cstring = StringManager.Instance.StaticString1024();
		for (int i = 0; i < 5; i++)
		{
			this.m_CStr[i] = StringManager.Instance.SpawnString(50);
		}
		this.Tmp = this.GameT.GetChild(1);
		this.Tmp1 = this.Tmp.GetChild(0);
		this.text_Info = this.Tmp1.GetComponent<UIText>();
		this.text_Info.font = this.TTFont;
		this.Tmp = this.GameT.GetChild(2);
		this.Tmp1 = this.Tmp.GetChild(0);
		this.text_Title = this.Tmp1.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.Tmp = this.GameT.GetChild(4);
		this.Tmp1 = this.Tmp.GetChild(2);
		this.btn_Item_L = this.Tmp1.GetComponent<UILEBtn>();
		Array.Clear(this.ItemID, 0, this.ItemID.Length);
		int num = 0;
		int num2 = 0;
		byte b = 0;
		if (this.mOpenType == 0)
		{
			KOFPrizeData recordByKey = this.DM.KOFPrize.GetRecordByKey(ActivityManager.Instance.KOWData.EventPrizeID);
			if (recordByKey.PrizeItem != null)
			{
				for (int j = 0; j < 3; j++)
				{
					this.ItemID[j] = recordByKey.PrizeItem[j].ItemID;
				}
				b = recordByKey.PrizeItem[0].ItemRank;
				num = (int)recordByKey.PrizeItem[1].ItemNum;
				num2 = (int)recordByKey.PrizeItem[2].ItemNum;
			}
			this.text_Info.text = this.DM.mStringTable.GetStringByID(11022u);
			this.text_Title.text = this.DM.mStringTable.GetStringByID(11026u);
		}
		else
		{
			for (int k = 0; k < 3; k++)
			{
				this.ItemID[k] = this.ActM.RewardRankingPrize[k].ItemID;
			}
			b = this.ActM.RewardRankingPrize[0].Rank;
			num = (int)this.ActM.RewardRankingPrize[1].Num;
			num2 = (int)this.ActM.RewardRankingPrize[2].Num;
			this.text_Info.text = this.DM.mStringTable.GetStringByID(11083u);
			this.text_Title.text = this.DM.mStringTable.GetStringByID(11058u);
		}
		Equip recordByKey2 = this.DM.EquipTable.GetRecordByKey(this.ItemID[0]);
		this.GUIM.InitLordEquipImg(this.btn_Item_L.transform, this.ItemID[0], b, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		this.tmphint = this.btn_Item_L.gameObject.AddComponent<UIButtonHint>();
		this.tmphint.m_eHint = EUIButtonHint.UILeBtn;
		this.tmphint.m_DownUpHandler = this;
		this.tmphint.Parm1 = recordByKey2.EquipKey;
		this.tmphint.Parm2 = b;
		for (int l = 0; l < 2; l++)
		{
			this.Tmp1 = this.Tmp.GetChild(5 + l);
			this.btn_Itme[l] = this.Tmp1.GetComponent<UIHIBtn>();
			this.GUIM.InitianHeroItemImg(this.btn_Itme[l].transform, eHeroOrItem.Item, 0, 0, 0, 0, true, true, true, false);
		}
		for (int m = 0; m < 5; m++)
		{
			this.Tmp1 = this.Tmp.GetChild(7 + m);
			this.text_Str[m] = this.Tmp1.GetComponent<UIText>();
			this.text_Str[m].font = this.TTFont;
		}
		this.m_CStr[4].ClearString();
		this.m_CStr[4].Append(this.DM.mStringTable.GetStringByID((uint)recordByKey2.EquipName));
		this.text_Str[4].text = this.m_CStr[4].ToString();
		this.text_Str[4].SetAllDirty();
		this.text_Str[4].cachedTextGenerator.Invalidate();
		this.m_CStr[0].ClearString();
		this.m_CStr[0].IntToFormat((long)num, 1, true);
		if (this.GUIM.IsArabic)
		{
			this.m_CStr[0].AppendFormat("{0}x");
		}
		else
		{
			this.m_CStr[0].AppendFormat("x{0}");
		}
		this.text_Str[0].text = this.m_CStr[0].ToString();
		this.text_Str[0].SetAllDirty();
		this.text_Str[0].cachedTextGenerator.Invalidate();
		recordByKey2 = this.DM.EquipTable.GetRecordByKey(this.ItemID[1]);
		byte equipKind = recordByKey2.EquipKind;
		this.m_CStr[1].ClearString();
		this.GUIM.ChangeHeroItemImg(this.btn_Itme[0].transform, eHeroOrItem.Item, this.ItemID[1], 0, 0, 0);
		if (equipKind == 11)
		{
			this.m_CStr[1].StringToFormat(this.GetItemStr(recordByKey2.PropertiesInfo[0].Propertieskey));
			this.m_CStr[1].IntToFormat((long)((int)(recordByKey2.PropertiesInfo[1].Propertieskey * recordByKey2.PropertiesInfo[1].PropertiesValue) * num), 1, true);
			if (this.GUIM.IsArabic)
			{
				this.m_CStr[1].AppendFormat("{1} {0}");
			}
			else
			{
				this.m_CStr[1].AppendFormat("{0} {1}");
			}
		}
		this.text_Str[1].text = this.m_CStr[1].ToString();
		this.text_Str[1].SetAllDirty();
		this.text_Str[1].cachedTextGenerator.Invalidate();
		this.m_CStr[2].ClearString();
		this.m_CStr[2].IntToFormat((long)num2, 1, true);
		if (this.GUIM.IsArabic)
		{
			this.m_CStr[2].AppendFormat("{0}x");
		}
		else
		{
			this.m_CStr[2].AppendFormat("x{0}");
		}
		this.text_Str[2].text = this.m_CStr[2].ToString();
		this.text_Str[2].SetAllDirty();
		this.text_Str[2].cachedTextGenerator.Invalidate();
		recordByKey2 = this.DM.EquipTable.GetRecordByKey(this.ItemID[2]);
		equipKind = recordByKey2.EquipKind;
		this.m_CStr[3].ClearString();
		this.GUIM.ChangeHeroItemImg(this.btn_Itme[1].transform, eHeroOrItem.Item, this.ItemID[2], 0, 0, 0);
		if (equipKind == 11)
		{
			this.m_CStr[3].StringToFormat(this.GetItemStr(recordByKey2.PropertiesInfo[0].Propertieskey));
			this.m_CStr[3].IntToFormat((long)((int)(recordByKey2.PropertiesInfo[1].Propertieskey * recordByKey2.PropertiesInfo[1].PropertiesValue) * num2), 1, true);
			if (this.GUIM.IsArabic)
			{
				this.m_CStr[3].AppendFormat("{1} {0}");
			}
			else
			{
				this.m_CStr[3].AppendFormat("{0} {1}");
			}
		}
		this.text_Str[3].text = this.m_CStr[3].ToString();
		this.text_Str[3].SetAllDirty();
		this.text_Str[3].cachedTextGenerator.Invalidate();
		this.Tmp = this.GameT.GetChild(5);
		this.tmpImg = this.Tmp.GetComponent<Image>();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_close_base");
		this.tmpImg.sprite = this.door.LoadSprite(cstring);
		this.tmpImg.material = this.mMaT;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.Tmp = this.GameT.GetChild(5).GetChild(0);
		this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_close");
		this.btn_EXIT.image.sprite = this.door.LoadSprite(cstring);
		this.btn_EXIT.image.material = this.mMaT;
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		if (this.mOpenType == 0)
		{
			GUIManager.Instance.m_LordInfo.HideEquipVal = true;
		}
	}

	// Token: 0x06002106 RID: 8454 RVA: 0x003ECF1C File Offset: 0x003EB11C
	public override void OnClose()
	{
		GUIManager.Instance.m_LordInfo.HideEquipVal = false;
		for (int i = 0; i < 5; i++)
		{
			if (this.m_CStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_CStr[i]);
			}
		}
	}

	// Token: 0x06002107 RID: 8455 RVA: 0x003ECF6C File Offset: 0x003EB16C
	public void RefreshItem()
	{
		Array.Clear(this.ItemID, 0, this.ItemID.Length);
		int num = 0;
		int num2 = 0;
		byte b = 0;
		if (this.mOpenType == 0)
		{
			KOFPrizeData recordByKey = this.DM.KOFPrize.GetRecordByKey(ActivityManager.Instance.KOWData.EventPrizeID);
			if (recordByKey.PrizeItem != null)
			{
				for (int i = 0; i < 3; i++)
				{
					this.ItemID[i] = recordByKey.PrizeItem[i].ItemID;
				}
				b = recordByKey.PrizeItem[0].ItemRank;
				num = (int)recordByKey.PrizeItem[1].ItemNum;
				num2 = (int)recordByKey.PrizeItem[2].ItemNum;
			}
		}
		else
		{
			for (int j = 0; j < 3; j++)
			{
				this.ItemID[j] = this.ActM.RewardRankingPrize[j].ItemID;
			}
			b = this.ActM.RewardRankingPrize[0].Rank;
			num = (int)this.ActM.RewardRankingPrize[1].Num;
			num2 = (int)this.ActM.RewardRankingPrize[2].Num;
		}
		Equip recordByKey2 = this.DM.EquipTable.GetRecordByKey(this.ItemID[0]);
		this.GUIM.ChangeLordEquipImg(this.btn_Item_L.transform, this.ItemID[0], b, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
		this.tmphint.Parm1 = recordByKey2.EquipKey;
		this.tmphint.Parm2 = b;
		this.m_CStr[4].ClearString();
		this.m_CStr[4].Append(this.DM.mStringTable.GetStringByID((uint)recordByKey2.EquipName));
		this.text_Str[4].text = this.m_CStr[4].ToString();
		this.text_Str[4].SetAllDirty();
		this.text_Str[4].cachedTextGenerator.Invalidate();
		this.m_CStr[0].ClearString();
		this.m_CStr[0].IntToFormat((long)num, 1, true);
		if (this.GUIM.IsArabic)
		{
			this.m_CStr[0].AppendFormat("{0}x");
		}
		else
		{
			this.m_CStr[0].AppendFormat("x{0}");
		}
		this.text_Str[0].text = this.m_CStr[0].ToString();
		this.text_Str[0].SetAllDirty();
		this.text_Str[0].cachedTextGenerator.Invalidate();
		recordByKey2 = this.DM.EquipTable.GetRecordByKey(this.ItemID[1]);
		byte equipKind = recordByKey2.EquipKind;
		this.m_CStr[1].ClearString();
		this.GUIM.ChangeHeroItemImg(this.btn_Itme[0].transform, eHeroOrItem.Item, this.ItemID[1], 0, 0, 0);
		if (equipKind == 11)
		{
			this.m_CStr[1].StringToFormat(this.GetItemStr(recordByKey2.PropertiesInfo[0].Propertieskey));
			this.m_CStr[1].IntToFormat((long)((int)(recordByKey2.PropertiesInfo[1].Propertieskey * recordByKey2.PropertiesInfo[1].PropertiesValue) * num), 1, true);
			if (this.GUIM.IsArabic)
			{
				this.m_CStr[1].AppendFormat("{1} {0}");
			}
			else
			{
				this.m_CStr[1].AppendFormat("{0} {1}");
			}
		}
		this.text_Str[1].text = this.m_CStr[1].ToString();
		this.text_Str[1].SetAllDirty();
		this.text_Str[1].cachedTextGenerator.Invalidate();
		this.m_CStr[2].ClearString();
		this.m_CStr[2].IntToFormat((long)num2, 1, true);
		if (this.GUIM.IsArabic)
		{
			this.m_CStr[2].AppendFormat("{0}x");
		}
		else
		{
			this.m_CStr[2].AppendFormat("x{0}");
		}
		this.text_Str[2].text = this.m_CStr[2].ToString();
		this.text_Str[2].SetAllDirty();
		this.text_Str[2].cachedTextGenerator.Invalidate();
		recordByKey2 = this.DM.EquipTable.GetRecordByKey(this.ItemID[2]);
		equipKind = recordByKey2.EquipKind;
		this.m_CStr[3].ClearString();
		this.GUIM.ChangeHeroItemImg(this.btn_Itme[1].transform, eHeroOrItem.Item, this.ItemID[2], 0, 0, 0);
		if (equipKind == 11)
		{
			this.m_CStr[3].StringToFormat(this.GetItemStr(recordByKey2.PropertiesInfo[0].Propertieskey));
			this.m_CStr[3].IntToFormat((long)((int)(recordByKey2.PropertiesInfo[1].Propertieskey * recordByKey2.PropertiesInfo[1].PropertiesValue) * num2), 1, true);
			if (this.GUIM.IsArabic)
			{
				this.m_CStr[3].AppendFormat("{1} {0}");
			}
			else
			{
				this.m_CStr[3].AppendFormat("{0} {1}");
			}
		}
		this.text_Str[3].text = this.m_CStr[3].ToString();
		this.text_Str[3].SetAllDirty();
		this.text_Str[3].cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002108 RID: 8456 RVA: 0x003ED4FC File Offset: 0x003EB6FC
	public string GetItemStr(ushort mkey)
	{
		string result = string.Empty;
		switch (mkey)
		{
		case 1:
			result = this.DM.mStringTable.GetStringByID((uint)(3951 + mkey));
			break;
		case 2:
			result = this.DM.mStringTable.GetStringByID((uint)(3951 + mkey));
			break;
		case 3:
			result = this.DM.mStringTable.GetStringByID((uint)(3951 + mkey));
			break;
		case 4:
			result = this.DM.mStringTable.GetStringByID((uint)(3951 + mkey));
			break;
		case 5:
			result = this.DM.mStringTable.GetStringByID((uint)(3951 + mkey));
			break;
		case 6:
			result = this.DM.mStringTable.GetStringByID(9991u);
			break;
		}
		return result;
	}

	// Token: 0x06002109 RID: 8457 RVA: 0x003ED5EC File Offset: 0x003EB7EC
	public void OnButtonClick(UIButton sender)
	{
		UIWonderReward_btn btnID = (UIWonderReward_btn)sender.m_BtnID1;
		if (btnID == UIWonderReward_btn.btn_EXIT)
		{
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x0600210A RID: 8458 RVA: 0x003ED630 File Offset: 0x003EB830
	public void OnButtonDown(UIButtonHint sender)
	{
		byte equipKind = DataManager.Instance.EquipTable.GetRecordByKey(sender.Parm1).EquipKind;
		bool flag = this.GUIM.IsLeadItem(equipKind);
		if (flag)
		{
			sender.SetFadeOutObject(EUIButtonHint.UILeBtn);
			this.GUIM.m_LordInfo.Show(sender, sender.Parm1, sender.Parm2, -1);
		}
	}

	// Token: 0x0600210B RID: 8459 RVA: 0x003ED694 File Offset: 0x003EB894
	public void OnButtonUp(UIButtonHint sender)
	{
		byte equipKind = DataManager.Instance.EquipTable.GetRecordByKey(sender.Parm1).EquipKind;
		bool flag = this.GUIM.IsLeadItem(equipKind);
		if (flag)
		{
			this.GUIM.m_LordInfo.Hide(sender);
		}
	}

	// Token: 0x0600210C RID: 8460 RVA: 0x003ED6E4 File Offset: 0x003EB8E4
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x0600210D RID: 8461 RVA: 0x003ED6E8 File Offset: 0x003EB8E8
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 0)
		{
			this.RefreshItem();
		}
	}

	// Token: 0x0600210E RID: 8462 RVA: 0x003ED710 File Offset: 0x003EB910
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
			this.RefreshItem();
		}
	}

	// Token: 0x0600210F RID: 8463 RVA: 0x003ED74C File Offset: 0x003EB94C
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Info != null && this.text_Info.enabled)
		{
			this.text_Info.enabled = false;
			this.text_Info.enabled = true;
		}
		for (int i = 0; i < 5; i++)
		{
			if (this.text_Str[i] != null && this.text_Str[i].enabled)
			{
				this.text_Str[i].enabled = false;
				this.text_Str[i].enabled = true;
			}
		}
		for (int j = 0; j < 2; j++)
		{
			if (this.btn_Itme[j] != null && this.btn_Itme[j].enabled)
			{
				this.btn_Itme[j].Refresh_FontTexture();
			}
		}
		if (this.btn_Item_L != null && this.btn_Item_L.enabled)
		{
			LordEquipData.ResetLordEquipFont(this.btn_Item_L);
		}
	}

	// Token: 0x06002110 RID: 8464 RVA: 0x003ED890 File Offset: 0x003EBA90
	private void Start()
	{
	}

	// Token: 0x06002111 RID: 8465 RVA: 0x003ED894 File Offset: 0x003EBA94
	private void Update()
	{
	}

	// Token: 0x04006840 RID: 26688
	private Transform GameT;

	// Token: 0x04006841 RID: 26689
	private Transform Tmp;

	// Token: 0x04006842 RID: 26690
	private Transform Tmp1;

	// Token: 0x04006843 RID: 26691
	private DataManager DM;

	// Token: 0x04006844 RID: 26692
	private GUIManager GUIM;

	// Token: 0x04006845 RID: 26693
	private ActivityManager ActM;

	// Token: 0x04006846 RID: 26694
	private Font TTFont;

	// Token: 0x04006847 RID: 26695
	private Door door;

	// Token: 0x04006848 RID: 26696
	private Material mMaT;

	// Token: 0x04006849 RID: 26697
	private UIButton btn_EXIT;

	// Token: 0x0400684A RID: 26698
	private Image tmpImg;

	// Token: 0x0400684B RID: 26699
	private UIText text_Title;

	// Token: 0x0400684C RID: 26700
	private UIText text_Info;

	// Token: 0x0400684D RID: 26701
	private UIText[] text_Str = new UIText[5];

	// Token: 0x0400684E RID: 26702
	private UIHIBtn[] btn_Itme = new UIHIBtn[2];

	// Token: 0x0400684F RID: 26703
	private UILEBtn btn_Item_L;

	// Token: 0x04006850 RID: 26704
	private CString[] m_CStr = new CString[5];

	// Token: 0x04006851 RID: 26705
	private ushort[] ItemID = new ushort[3];

	// Token: 0x04006852 RID: 26706
	private UIButtonHint tmphint;

	// Token: 0x04006853 RID: 26707
	private int mOpenType;
}
