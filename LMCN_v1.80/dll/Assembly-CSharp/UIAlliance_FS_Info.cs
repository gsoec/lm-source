using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002DB RID: 731
public class UIAlliance_FS_Info : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06000EC7 RID: 3783 RVA: 0x0018C6EC File Offset: 0x0018A8EC
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.AWM = ActivityManager.Instance.AllianceWarMgr;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.mMaT = this.door.LoadMaterial();
		this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
		this.FrameMaterial = this.GUIM.GetFrameMaterial();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		for (int i = 0; i < 2; i++)
		{
			this.ItemInfo[i] = this.DM.mStringTable.GetStringByID((uint)((ushort)(5343 + i)));
		}
		for (int j = 2; j < 4; j++)
		{
			this.ItemInfo[j] = this.DM.mStringTable.GetStringByID((uint)((ushort)(6088 + j)));
		}
		for (int k = 0; k < 17; k++)
		{
			this.Cstr_tmpItem1[k] = StringManager.Instance.SpawnString(30);
			this.Cstr_tmpItem2[k] = StringManager.Instance.SpawnString(30);
			this.Cstr_tmpItem3[k] = StringManager.Instance.SpawnString(30);
			this.Cstr_tmpItem4[k] = StringManager.Instance.SpawnString(30);
		}
		for (int l = 0; l < 2; l++)
		{
			this.Cstr_PlayName[l] = StringManager.Instance.SpawnString(30);
			this.Cstr_Title[l] = StringManager.Instance.SpawnString(30);
			this.Cstr_Title4[l] = StringManager.Instance.SpawnString(30);
		}
		this.Cstr_Hint = StringManager.Instance.SpawnString(100);
		this.Cstr_PlayName[0].ClearString();
		this.Cstr_PlayName[0].Append(this.DM.RoleAttr.Name);
		CString cstring = StringManager.Instance.StaticString1024();
		for (int m = 0; m < 5; m++)
		{
			this.Cstr_DS_Heros[m] = StringManager.Instance.SpawnString(30);
		}
		for (int n = 0; n < 5; n++)
		{
			this.mHead[n] = null;
		}
		this.Tmp = this.GameT.GetChild(4);
		this.Img_Hint = this.Tmp.GetComponent<Image>();
		this.Tmp = this.GameT.GetChild(4).GetChild(0);
		this.text_Hint_1 = this.Tmp.GetComponent<UIText>();
		this.text_Hint_1.font = this.TTFont;
		this.Tmp = this.GameT.GetChild(4).GetChild(1);
		this.text_Hint_2 = this.Tmp.GetComponent<UIText>();
		this.text_Hint_2.font = this.TTFont;
		this.Tmp = this.GameT.GetChild(1);
		this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
		Transform child = this.GameT.GetChild(2);
		this.tmptext = child.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmpImg = child.GetChild(0).GetChild(1).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_EO_icon_01");
		this.tmpImg.material = this.mMaT;
		this.hint = this.tmpImg.gameObject.AddComponent<UIButtonHint>();
		this.hint.m_eHint = EUIButtonHint.CountDown;
		this.hint.DelayTime = 0.2f;
		this.hint.m_Handler = this;
		this.hint.Parm1 = 3;
		for (int num = 0; num < 5; num++)
		{
			this.text_tmpStr[0 + num] = child.GetChild(1).GetChild(num).GetComponent<UIText>();
			this.text_tmpStr[0 + num].font = this.TTFont;
			if (num == 1)
			{
				this.text_tmpStr[0 + num].text = this.DM.mStringTable.GetStringByID(5339u);
			}
			else if (num == 2)
			{
				this.text_tmpStr[0 + num].text = this.DM.mStringTable.GetStringByID(5340u);
			}
		}
		this.tmptext = child.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = child.GetChild(2).GetChild(1).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext.text = this.DM.mStringTable.GetStringByID(12086u);
		this.tmptext = child.GetChild(2).GetChild(2).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.text_tmpStr[5] = child.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[5].font = this.TTFont;
		this.tmpImg = child.GetChild(3).GetChild(1).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_EO_icon_02");
		this.tmpImg.material = this.mMaT;
		this.hint = this.tmpImg.gameObject.AddComponent<UIButtonHint>();
		this.hint.m_eHint = EUIButtonHint.CountDown;
		this.hint.DelayTime = 0.2f;
		this.hint.m_Handler = this;
		this.hint.Parm1 = 4;
		for (int num2 = 0; num2 < 5; num2++)
		{
			this.Tmp = child.GetChild(4).GetChild(num2).GetChild(0);
			this.tmpImg = this.Tmp.GetComponent<Image>();
			this.tmpImg.material = this.IconMaterial;
			this.tmpRC = this.Tmp.GetComponent<RectTransform>();
			this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
			this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.Tmp = child.GetChild(4).GetChild(num2).GetChild(1);
			this.tmpImg = this.Tmp.GetComponent<Image>();
			cstring.ClearString();
			cstring.AppendFormat("hf000");
			this.tmpImg.sprite = this.GUIM.LoadFrameSprite(cstring);
			this.tmpImg.material = this.FrameMaterial;
			this.tmpRC = this.Tmp.GetComponent<RectTransform>();
			this.tmpRC.anchorMin = Vector2.zero;
			this.tmpRC.anchorMax = new Vector2(1f, 1f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.Tmp = child.GetChild(4).GetChild(num2).GetChild(2);
			this.tmpImg = this.Tmp.GetComponent<Image>();
			cstring.ClearString();
			cstring.AppendFormat("hf101");
			this.tmpImg.sprite = this.GUIM.LoadFrameSprite(cstring);
			this.tmpImg.material = this.FrameMaterial;
			this.tmpImg = child.GetChild(4).GetChild(num2).GetChild(3).GetComponent<Image>();
			cstring.ClearString();
			cstring.AppendFormat("UI_legion_icon_12");
			this.tmpImg.sprite = this.GUIM.LoadFrameSprite(cstring);
			this.tmpImg.material = this.FrameMaterial;
			this.tmpImg = child.GetChild(4).GetChild(num2).GetChild(3).GetChild(0).GetComponent<Image>();
			cstring.ClearString();
			cstring.AppendFormat("UI_legion_icon_13");
			this.tmpImg.sprite = this.GUIM.LoadFrameSprite(cstring);
			this.tmpImg.material = this.FrameMaterial;
		}
		for (int num3 = 0; num3 < 4; num3++)
		{
			this.text_tmpStr[6 + num3] = child.GetChild(5).GetChild(num3).GetComponent<UIText>();
			this.text_tmpStr[6 + num3].font = this.TTFont;
			if (num3 < 2)
			{
				this.text_tmpStr[6 + num3].text = this.DM.mStringTable.GetStringByID((uint)(5341 + num3));
			}
		}
		for (int num4 = 0; num4 < 4; num4++)
		{
			this.tmptext = child.GetChild(6).GetChild(num4).GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
		}
		UIButton component = child.GetChild(6).GetChild(4).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1;
		this.hint = component.gameObject.AddComponent<UIButtonHint>();
		this.hint.m_eHint = EUIButtonHint.DownUpHandler;
		this.hint.m_Handler = this;
		this.tmptext = child.GetChild(6).GetChild(4).GetChild(1).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = child.GetChild(7).GetChild(0).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = child.GetChild(7).GetChild(1).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = child.GetChild(8).GetChild(2).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext.text = this.DM.mStringTable.GetStringByID(5341u);
		this.tmptext = child.GetChild(8).GetChild(3).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext.text = this.DM.mStringTable.GetStringByID(4919u);
		this.tmptext = child.GetChild(8).GetChild(4).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext.text = this.DM.mStringTable.GetStringByID(5321u);
		this.tmptext = child.GetChild(8).GetChild(5).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext.text = this.DM.mStringTable.GetStringByID(4919u);
		this.tmptext = child.GetChild(8).GetChild(6).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext.text = this.DM.mStringTable.GetStringByID(5321u);
		this.tmptext = child.GetChild(9).GetChild(2).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = child.GetChild(9).GetChild(3).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = child.GetChild(9).GetChild(4).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = child.GetChild(9).GetChild(5).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = child.GetChild(9).GetChild(6).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		component = child.GetChild(9).GetChild(7).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1;
		this.hint = component.gameObject.AddComponent<UIButtonHint>();
		this.hint.m_eHint = EUIButtonHint.DownUpHandler;
		this.hint.m_Handler = this;
		this.tmptext = child.GetChild(9).GetChild(7).GetChild(1).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmplist.Clear();
		this.SetFsData(true);
		this.m_ScrollPanel.IntiScrollPanel(505f, 4f, 0f, this.tmplist, 17, this);
		this.text_tmpStr[10] = this.GameT.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[10].font = this.TTFont;
		this.text_tmpStr[10].text = this.DM.mStringTable.GetStringByID(5396u);
		UIButtonHint.scrollRect = this.m_ScrollPanel.transform.GetComponent<CScrollRect>();
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
	}

	// Token: 0x06000EC8 RID: 3784 RVA: 0x0018D594 File Offset: 0x0018B794
	public void SetFsData(bool bopen = true)
	{
		uint num = 0u;
		uint num2 = 0u;
		for (int i = 0; i < 16; i++)
		{
			this.DM.mFs_A_ST[i] = 0u;
			this.DM.mFs_A_SL[i] = 0u;
			this.DM.mFs_D_ST[i] = 0u;
			this.DM.mFs_D_SL[i] = 0u;
			this.DM.mFs_A_ST[i] += this.AWM.m_CombatPlayerData[0].SurviveTroop[i] + this.AWM.m_CombatPlayerData[0].DeadTroop[i];
			this.DM.mFs_A_SL[i] += this.AWM.m_CombatPlayerData[0].DeadTroop[i];
			num += this.DM.mFs_A_SL[i];
			this.DM.mFs_D_ST[i] += this.AWM.m_CombatPlayerData[1].SurviveTroop[i] + this.AWM.m_CombatPlayerData[1].DeadTroop[i];
			this.DM.mFs_D_SL[i] += this.AWM.m_CombatPlayerData[1].DeadTroop[i];
			num2 += this.DM.mFs_D_SL[i];
		}
		this.tmplist.Clear();
		this.tmplistInfo_Type.Clear();
		this.tmplistInfo_DataName.Clear();
		this.tmplistInfo_Data_L.Clear();
		this.tmplistInfo_Data_H.Clear();
		this.tmplistInfo_Data_D.Clear();
		this.tmplistInfo_Data_.Clear();
		this.tmplistInfo_Data_Icon.Clear();
		if (this.AWM.MyAllySide == 1)
		{
			this.IsAttack = true;
		}
		else
		{
			this.IsAttack = false;
		}
		this.tmplistInfo_Type.Add(0);
		this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID(12073u));
		this.tmplistInfo_Data_L.Add(0u);
		this.tmplistInfo_Data_H.Add(0u);
		this.tmplistInfo_Data_D.Add(0u);
		this.tmplistInfo_Data_.Add(0u);
		this.tmplistInfo_Data_Icon.Add(0);
		this.tmplist.Add(44f);
		this.tmplistInfo_Type.Add(11);
		this.tmplistInfo_DataName.Add("P_Title4");
		this.Cstr_Title4[0].ClearString();
		if (this.IsAttack)
		{
			this.Cstr_Title4[0].Append(this.DM.mStringTable.GetStringByID(11163u));
		}
		else
		{
			this.Cstr_Title4[0].Append(this.DM.mStringTable.GetStringByID(11164u));
		}
		this.Cstr_Title4[1].ClearString();
		if (!this.IsAttack)
		{
			this.Cstr_Title4[1].Append(this.DM.mStringTable.GetStringByID(11163u));
		}
		else
		{
			this.Cstr_Title4[1].Append(this.DM.mStringTable.GetStringByID(11164u));
		}
		this.tmplistInfo_Data_L.Add(0u);
		this.tmplistInfo_Data_H.Add(0u);
		this.tmplistInfo_Data_D.Add(0u);
		this.tmplistInfo_Data_.Add(0u);
		this.tmplistInfo_Data_Icon.Add(0);
		this.tmplist.Add(41f);
		this.tmplistInfo_Type.Add(12);
		this.tmplistInfo_DataName.Add("P_Name2");
		this.tmplistInfo_Data_L.Add(0u);
		this.tmplistInfo_Data_H.Add(0u);
		this.tmplistInfo_Data_D.Add(0u);
		this.tmplistInfo_Data_.Add(0u);
		this.tmplistInfo_Data_Icon.Add(0);
		this.tmplist.Add(38f);
		this.tmpA = 0;
		for (int j = 0; j < 16; j++)
		{
			int num3 = 3 - j / 4 + j % 4 * 4;
			if (this.DM.mFs_A_ST[num3] > 0u || this.DM.mFs_D_ST[num3] > 0u)
			{
				this.tmplistInfo_Type.Add(13);
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num3 + 1));
				this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
				this.tmplistInfo_Data_L.Add(this.DM.mFs_A_ST[num3]);
				this.tmplistInfo_Data_H.Add(this.DM.mFs_A_SL[num3]);
				this.tmplistInfo_Data_D.Add(this.DM.mFs_D_ST[num3]);
				this.tmplistInfo_Data_.Add(this.DM.mFs_D_SL[num3]);
				this.tmplistInfo_Data_Icon.Add((byte)num3);
				this.tmplist.Add(35f);
				this.tmpA += 1;
			}
		}
		if (this.tmpA > 0)
		{
			this.tmplist.RemoveAt(this.tmplist.Count - 1);
			this.tmplist.Add(45f);
		}
		else
		{
			this.tmplistInfo_Type.Add(9);
			this.tmplistInfo_DataName.Add("-");
			this.tmplistInfo_Data_L.Add(0u);
			this.tmplistInfo_Data_H.Add(0u);
			this.tmplistInfo_Data_D.Add(0u);
			this.tmplistInfo_Data_.Add(0u);
			this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
			this.tmplist.Add(45f);
		}
		this.tmplistInfo_Type.Add(0);
		this.Cstr_Title[0].ClearString();
		if (this.IsAttack)
		{
			this.Cstr_Title[0].Append(this.DM.mStringTable.GetStringByID(11163u));
		}
		else
		{
			this.Cstr_Title[0].Append(this.DM.mStringTable.GetStringByID(11164u));
		}
		this.tmplistInfo_DataName.Add(this.Cstr_Title[0].ToString());
		this.tmplistInfo_Data_L.Add(0u);
		this.tmplistInfo_Data_H.Add(0u);
		this.tmplistInfo_Data_D.Add(0u);
		this.tmplistInfo_Data_.Add(0u);
		this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
		this.tmplist.Add(44f);
		this.tmplistInfo_Type.Add(3);
		if (this.IsAttack)
		{
			this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID(5338u));
		}
		else
		{
			this.tmplistInfo_DataName.Add(this.AWM.m_CombatPlayerData[0].Name);
		}
		this.tmplistInfo_Data_L.Add(num2);
		this.tmplistInfo_Data_H.Add(0u);
		this.tmplistInfo_Data_D.Add(0u);
		this.tmplistInfo_Data_.Add(0u);
		this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
		this.tmplist.Add(59f);
		if (this.AWM.m_CombatPlayerData[0].HeroInfo[0].ID > 0)
		{
			this.tmplistInfo_Type.Add(7);
			this.tmplistInfo_DataName.Add(string.Empty);
			this.tmplistInfo_Data_L.Add(0u);
			this.tmplistInfo_Data_H.Add(0u);
			this.tmplistInfo_Data_D.Add(0u);
			this.tmplistInfo_Data_.Add(0u);
			this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
			for (int k = 0; k < this.AWM.m_CombatPlayerData[0].HeroInfo.Length; k++)
			{
				this.mHeroID_A[k] = this.AWM.m_CombatPlayerData[0].HeroInfo[k].ID;
				this.mHeroRank_A[k] = this.AWM.m_CombatPlayerData[0].HeroInfo[k].Rank;
				this.mHeroStar_A[k] = this.AWM.m_CombatPlayerData[0].HeroInfo[k].Star;
			}
			this.tmplist.Add(96f);
		}
		this.tmplistInfo_Type.Add(5);
		this.tmplistInfo_DataName.Add(string.Empty);
		this.tmplistInfo_Data_L.Add(1u);
		this.tmplistInfo_Data_H.Add(0u);
		this.tmplistInfo_Data_D.Add(0u);
		this.tmplistInfo_Data_.Add(0u);
		this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
		this.tmplist.Add(38f);
		this.tmpA = 0;
		for (int l = 0; l < 16; l++)
		{
			int num3 = 3 - l / 4 + l % 4 * 4;
			if (this.AWM.m_CombatPlayerData[0].SurviveTroop[num3] > 0u || this.AWM.m_CombatPlayerData[0].DeadTroop[num3] > 0u)
			{
				this.tmpA += 1;
				this.tmplistInfo_Type.Add(9);
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num3 + 1));
				this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
				this.tmplistInfo_Data_L.Add(this.AWM.m_CombatPlayerData[0].SurviveTroop[num3]);
				this.tmplistInfo_Data_H.Add(0u);
				this.tmplistInfo_Data_D.Add(this.AWM.m_CombatPlayerData[0].DeadTroop[num3]);
				this.tmplistInfo_Data_.Add(0u);
				this.tmplistInfo_Data_Icon.Add((byte)num3);
				this.tmplist.Add(35f);
			}
		}
		if (this.tmpA > 0)
		{
			this.tmplist.RemoveAt(this.tmplist.Count - 1);
			this.tmplist.Add(45f);
		}
		else
		{
			this.tmplistInfo_Type.Add(9);
			this.tmplistInfo_DataName.Add("-");
			this.tmplistInfo_Data_L.Add(0u);
			this.tmplistInfo_Data_H.Add(0u);
			this.tmplistInfo_Data_D.Add(0u);
			this.tmplistInfo_Data_.Add(0u);
			this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
			this.tmplist.Add(45f);
		}
		this.tmplistInfo_Type.Add(1);
		this.Cstr_Title[1].ClearString();
		if (!this.IsAttack)
		{
			this.Cstr_Title[1].Append(this.DM.mStringTable.GetStringByID(11163u));
		}
		else
		{
			this.Cstr_Title[1].Append(this.DM.mStringTable.GetStringByID(11164u));
		}
		this.tmplistInfo_DataName.Add(this.Cstr_Title[1].ToString());
		this.tmplistInfo_Data_L.Add(0u);
		this.tmplistInfo_Data_H.Add(0u);
		this.tmplistInfo_Data_D.Add(0u);
		this.tmplistInfo_Data_.Add(0u);
		this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
		this.tmplist.Add(44f);
		this.tmplistInfo_Type.Add(3);
		if (!this.IsAttack)
		{
			this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID(5338u));
		}
		else
		{
			this.tmplistInfo_DataName.Add(this.AWM.m_CombatPlayerData[1].Name);
		}
		this.tmplistInfo_Data_L.Add(num);
		this.tmplistInfo_Data_H.Add(0u);
		this.tmplistInfo_Data_D.Add(0u);
		this.tmplistInfo_Data_.Add(0u);
		this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
		this.tmplist.Add(59f);
		if (this.AWM.m_CombatPlayerData[1].HeroInfo[0].ID > 0)
		{
			this.tmplistInfo_Type.Add(8);
			this.tmplistInfo_DataName.Add(string.Empty);
			this.tmplistInfo_Data_L.Add(1u);
			this.tmplistInfo_Data_H.Add(0u);
			this.tmplistInfo_Data_D.Add(0u);
			this.tmplistInfo_Data_.Add(0u);
			this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
			for (int m = 0; m < this.AWM.m_CombatPlayerData[1].HeroInfo.Length; m++)
			{
				this.mHeroID_D[m] = this.AWM.m_CombatPlayerData[1].HeroInfo[m].ID;
				this.mHeroRank_D[m] = this.AWM.m_CombatPlayerData[1].HeroInfo[m].Rank;
				this.mHeroStar_D[m] = this.AWM.m_CombatPlayerData[1].HeroInfo[m].Star;
			}
			this.tmplist.Add(96f);
		}
		this.tmplistInfo_Type.Add(6);
		this.tmplistInfo_DataName.Add(string.Empty);
		this.tmplistInfo_Data_L.Add(1u);
		this.tmplistInfo_Data_H.Add(0u);
		this.tmplistInfo_Data_D.Add(0u);
		this.tmplistInfo_Data_.Add(0u);
		this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
		this.tmplist.Add(38f);
		this.tmpA = 0;
		for (int n = 0; n < 16; n++)
		{
			int num3 = 3 - n / 4 + n % 4 * 4;
			if (this.AWM.m_CombatPlayerData[1].SurviveTroop[num3] > 0u || this.AWM.m_CombatPlayerData[1].DeadTroop[num3] > 0u)
			{
				this.tmpA += 1;
				this.tmplistInfo_Type.Add(10);
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num3 + 1));
				this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
				this.tmplistInfo_Data_L.Add(this.AWM.m_CombatPlayerData[1].SurviveTroop[num3]);
				this.tmplistInfo_Data_H.Add(0u);
				this.tmplistInfo_Data_D.Add(this.AWM.m_CombatPlayerData[1].DeadTroop[num3]);
				this.tmplistInfo_Data_.Add(0u);
				this.tmplistInfo_Data_Icon.Add((byte)num3);
				this.tmplist.Add(35f);
			}
		}
		if (this.tmpA > 0)
		{
			this.tmplist.RemoveAt(this.tmplist.Count - 1);
			this.tmplist.Add(45f);
		}
		else
		{
			this.tmplistInfo_Type.Add(10);
			this.tmplistInfo_DataName.Add("-");
			this.tmplistInfo_Data_L.Add(0u);
			this.tmplistInfo_Data_H.Add(0u);
			this.tmplistInfo_Data_D.Add(0u);
			this.tmplistInfo_Data_.Add(0u);
			this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
			this.tmplist.Add(45f);
		}
		if (!bopen)
		{
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
		}
	}

	// Token: 0x06000EC9 RID: 3785 RVA: 0x0018E594 File Offset: 0x0018C794
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.mSeroll_Item[panelObjectIdx] == null)
		{
			this.mSeroll_Item[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			this.text_Top[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.Img_Hint1[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(0).GetChild(1).GetComponent<Image>();
			this.hint = this.Img_Hint1[panelObjectIdx].gameObject.GetComponent<UIButtonHint>();
			this.hint.m_eHint = EUIButtonHint.CountDown;
			this.hint.DelayTime = 0.2f;
			this.hint.m_Handler = this;
			this.hint.Parm1 = 3;
			this.text_Title1[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.text_Title1_1[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(1).GetChild(1).GetComponent<UIText>();
			this.text_Title1_2[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(1).GetChild(2).GetComponent<UIText>();
			this.text_ATitleTroops[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(1).GetChild(3).GetComponent<UIText>();
			this.text_ATitleTraps[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(1).GetChild(4).GetComponent<UIText>();
			this.text_Title2[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(2).GetChild(0).GetComponent<UIText>();
			this.text_Title2_1[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(2).GetChild(1).GetComponent<UIText>();
			this.text_DTitleTroops[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(2).GetChild(2).GetComponent<UIText>();
			this.text_DTitleTraps[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(3).GetChild(0).GetComponent<UIText>();
			this.Img_Hint2[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(3).GetChild(1).GetComponent<Image>();
			this.hint = this.Img_Hint2[panelObjectIdx].gameObject.GetComponent<UIButtonHint>();
			this.hint.m_eHint = EUIButtonHint.CountDown;
			this.hint.DelayTime = 0.2f;
			this.hint.m_Handler = this;
			this.hint.Parm1 = 4;
			this.Img_HeroBG[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(4).GetComponent<Image>();
			this.Img_ItemTitleBG[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(5).GetComponent<Image>();
			this.text_InfoName3[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(5).GetChild(0).GetComponent<UIText>();
			this.text_InfoName4[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(5).GetChild(1).GetComponent<UIText>();
			this.text_InfoName1[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(5).GetChild(2).GetComponent<UIText>();
			this.text_InfoName2[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(5).GetChild(3).GetComponent<UIText>();
			this.Img_ItemInfoBG[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(6).GetComponent<Image>();
			this.text_Troops_Name[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(6).GetChild(0).GetComponent<UIText>();
			this.text_Item_L[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(6).GetChild(1).GetComponent<UIText>();
			this.text_Item_H[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(6).GetChild(2).GetComponent<UIText>();
			this.text_Item_D[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(6).GetChild(3).GetComponent<UIText>();
			this.btn_Icon1[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(6).GetChild(4).GetComponent<UIButton>();
			this.btn_Icon1[panelObjectIdx].m_Handler = this;
			this.m_ItembtnHint[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(6).GetChild(4).GetComponent<UIButtonHint>();
			this.m_ItembtnHint[panelObjectIdx].m_eHint = EUIButtonHint.CountDown;
			this.m_ItembtnHint[panelObjectIdx].DelayTime = 0.2f;
			this.m_ItembtnHint[panelObjectIdx].m_DownUpHandler = this;
			this.m_ItembtnHint[panelObjectIdx].ControlFadeOut = this.Img_Hint.gameObject;
			this.m_ItembtnHint[panelObjectIdx].Parm1 = 1;
			this.btn_IconRT_1[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(6).GetChild(4).GetComponent<RectTransform>();
			this.Img_Icon_1[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(6).GetChild(4).GetChild(0).GetComponent<Image>();
			this.text_Icon_1[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(6).GetChild(4).GetChild(1).GetComponent<UIText>();
			this.text_Title4_1[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(7).GetChild(0).GetComponent<UIText>();
			this.text_Title4_2[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(7).GetChild(1).GetComponent<UIText>();
			this.Img_Name2_L[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(8).GetChild(0).GetComponent<Image>();
			this.Img_Name2_R[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(8).GetChild(1).GetComponent<Image>();
			this.text_Name2_1[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(8).GetChild(2).GetComponent<UIText>();
			this.text_Name2_2[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(8).GetChild(3).GetComponent<UIText>();
			this.text_Name2_3[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(8).GetChild(4).GetComponent<UIText>();
			this.text_Name2_4[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(8).GetChild(5).GetComponent<UIText>();
			this.text_Name2_5[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(8).GetChild(6).GetComponent<UIText>();
			this.Img_Data2_L[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(9).GetChild(0).GetComponent<Image>();
			this.Img_Data2_R[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(9).GetChild(1).GetComponent<Image>();
			this.text_Data2_1[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(9).GetChild(2).GetComponent<UIText>();
			this.text_Data2_2[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(9).GetChild(3).GetComponent<UIText>();
			this.text_Data2_3[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(9).GetChild(4).GetComponent<UIText>();
			this.text_Data2_4[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(9).GetChild(5).GetComponent<UIText>();
			this.text_Data2_5[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(9).GetChild(6).GetComponent<UIText>();
			this.btn_Icon2[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(9).GetChild(7).GetComponent<UIButton>();
			this.btn_Icon2[panelObjectIdx].m_Handler = this;
			this.m_ItembtnHint2[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(9).GetChild(7).GetComponent<UIButtonHint>();
			this.m_ItembtnHint2[panelObjectIdx].m_DownUpHandler = this;
			this.m_ItembtnHint2[panelObjectIdx].m_eHint = EUIButtonHint.CountDown;
			this.m_ItembtnHint2[panelObjectIdx].DelayTime = 0.2f;
			this.m_ItembtnHint2[panelObjectIdx].ControlFadeOut = this.Img_Hint.gameObject;
			this.m_ItembtnHint2[panelObjectIdx].Parm1 = 2;
			this.btn_IconRT_2[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(9).GetChild(7).GetComponent<RectTransform>();
			this.Img_Icon_2[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(9).GetChild(7).GetChild(0).GetComponent<Image>();
			this.text_Icon_2[panelObjectIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(9).GetChild(7).GetChild(1).GetComponent<UIText>();
		}
		int num = this.mSeroll_Item[panelObjectIdx].m_BtnID2;
		if (num != 0)
		{
			this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).gameObject.SetActive(false);
		}
		switch (this.tmplistInfo_Type[dataIdx])
		{
		case 0:
		case 1:
			this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 1;
			num = 1;
			this.text_Top[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
			this.text_Top[panelObjectIdx].SetAllDirty();
			this.text_Top[panelObjectIdx].cachedTextGenerator.Invalidate();
			if (this.tmplistInfo_Data_Icon[dataIdx] < 255)
			{
				this.Img_Hint1[panelObjectIdx].gameObject.SetActive(true);
			}
			else
			{
				this.Img_Hint1[panelObjectIdx].gameObject.SetActive(false);
			}
			break;
		case 2:
			this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 2;
			num = 2;
			this.text_Title1[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
			this.text_Title1[panelObjectIdx].SetAllDirty();
			this.text_Title1[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.Cstr_tmpItem1[panelObjectIdx].ClearString();
			this.Cstr_tmpItem1[panelObjectIdx].IntToFormat((long)((ulong)this.tmplistInfo_Data_L[dataIdx]), 1, true);
			this.Cstr_tmpItem1[panelObjectIdx].AppendFormat("{0}");
			this.text_ATitleTroops[panelObjectIdx].text = this.Cstr_tmpItem1[panelObjectIdx].ToString();
			this.text_ATitleTroops[panelObjectIdx].SetAllDirty();
			this.text_ATitleTroops[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.Cstr_tmpItem2[panelObjectIdx].ClearString();
			this.Cstr_tmpItem2[panelObjectIdx].IntToFormat((long)((ulong)this.tmplistInfo_Data_H[dataIdx]), 1, true);
			this.Cstr_tmpItem2[panelObjectIdx].AppendFormat("{0}");
			this.text_ATitleTraps[panelObjectIdx].text = this.Cstr_tmpItem2[panelObjectIdx].ToString();
			this.text_ATitleTraps[panelObjectIdx].SetAllDirty();
			this.text_ATitleTraps[panelObjectIdx].cachedTextGenerator.Invalidate();
			break;
		case 3:
			this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 3;
			num = 3;
			this.text_Title2[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
			this.text_Title2[panelObjectIdx].SetAllDirty();
			this.text_Title2[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.Cstr_tmpItem1[panelObjectIdx].ClearString();
			this.Cstr_tmpItem1[panelObjectIdx].IntToFormat((long)((ulong)this.tmplistInfo_Data_L[dataIdx]), 1, true);
			this.Cstr_tmpItem1[panelObjectIdx].AppendFormat("{0}");
			this.text_DTitleTroops[panelObjectIdx].text = this.Cstr_tmpItem1[panelObjectIdx].ToString();
			this.text_DTitleTroops[panelObjectIdx].SetAllDirty();
			this.text_DTitleTroops[panelObjectIdx].cachedTextGenerator.Invalidate();
			break;
		case 4:
			this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 4;
			num = 4;
			this.text_DTitleTraps[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
			this.text_DTitleTraps[panelObjectIdx].SetAllDirty();
			this.text_DTitleTraps[panelObjectIdx].cachedTextGenerator.Invalidate();
			if (this.tmplistInfo_Data_Icon[dataIdx] < 255)
			{
				this.Img_Hint2[panelObjectIdx].gameObject.SetActive(true);
			}
			else
			{
				this.Img_Hint2[panelObjectIdx].gameObject.SetActive(false);
			}
			break;
		case 5:
			this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 6;
			num = 6;
			this.text_InfoName1[panelObjectIdx].text = this.ItemInfo[0];
			this.text_InfoName1[panelObjectIdx].SetAllDirty();
			this.text_InfoName1[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_InfoName2[panelObjectIdx].text = this.ItemInfo[1];
			this.text_InfoName2[panelObjectIdx].SetAllDirty();
			this.text_InfoName2[panelObjectIdx].cachedTextGenerator.Invalidate();
			if (this.IsAttack)
			{
				this.Img_ItemTitleBG[panelObjectIdx].sprite = this.SArray.m_Sprites[2];
			}
			else
			{
				this.Img_ItemTitleBG[panelObjectIdx].sprite = this.SArray.m_Sprites[3];
			}
			break;
		case 6:
			this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 6;
			num = 6;
			if (this.tmplistInfo_Data_L[dataIdx] == 1u)
			{
				this.text_InfoName1[panelObjectIdx].text = this.ItemInfo[0];
				this.text_InfoName2[panelObjectIdx].text = this.ItemInfo[1];
			}
			else
			{
				this.text_InfoName1[panelObjectIdx].text = this.ItemInfo[2];
				this.text_InfoName2[panelObjectIdx].text = this.ItemInfo[3];
			}
			this.text_InfoName1[panelObjectIdx].SetAllDirty();
			this.text_InfoName1[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_InfoName2[panelObjectIdx].SetAllDirty();
			this.text_InfoName2[panelObjectIdx].cachedTextGenerator.Invalidate();
			if (!this.IsAttack)
			{
				this.Img_ItemTitleBG[panelObjectIdx].sprite = this.SArray.m_Sprites[2];
			}
			else
			{
				this.Img_ItemTitleBG[panelObjectIdx].sprite = this.SArray.m_Sprites[3];
			}
			break;
		case 7:
			this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 5;
			num = 5;
			if (this.IsAttack)
			{
				this.Img_HeroBG[panelObjectIdx].sprite = this.SArray.m_Sprites[0];
			}
			else
			{
				this.Img_HeroBG[panelObjectIdx].sprite = this.SArray.m_Sprites[1];
			}
			if (this.AWM.m_CombatPlayerData[0].bMain)
			{
				this.Img_MainHeroShow1[0] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(0).GetChild(3).GetComponent<Image>();
				this.Img_MainHeroShow1[0].gameObject.SetActive(true);
				this.Img_MainHeroShow_A[0] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(0).GetChild(3).GetChild(0).GetComponent<Image>();
				this.ShowMainHeroTime1 = 0f;
			}
			else
			{
				for (int i = 0; i < 5; i++)
				{
					if (this.Img_MainHeroShow1[i] != null)
					{
						this.Img_MainHeroShow1[i].gameObject.SetActive(false);
					}
				}
			}
			for (int j = 0; j < this.AWM.m_CombatPlayerData[0].HeroInfo.Length; j++)
			{
				if (this.AWM.m_CombatPlayerData[0].HeroInfo[j].ID > 0)
				{
					this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(j).gameObject.SetActive(true);
				}
				else
				{
					this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(j).gameObject.SetActive(false);
				}
				this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.mHeroID_A[j]);
				this.tmpImg = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(j).GetChild(0).GetComponent<Image>();
				this.tmpImg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
				if (this.tmpImg.transform.childCount != 0)
				{
					this.tmpImg.transform.GetChild(0).gameObject.SetActive(false);
				}
				this.tmpImg = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(j).GetChild(1).GetComponent<Image>();
				this.Cstr_DS_Heros[j].ClearString();
				this.Cstr_DS_Heros[j].IntToFormat((long)this.mHeroStar_A[j], 1, false);
				this.Cstr_DS_Heros[j].AppendFormat("hf00{0}");
				this.tmpImg.sprite = this.GUIM.LoadFrameSprite(this.Cstr_DS_Heros[j]);
				this.tmpImg = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(j).GetChild(2).GetComponent<Image>();
				this.Cstr_DS_Heros[j].ClearString();
				this.Cstr_DS_Heros[j].IntToFormat((long)this.mHeroRank_A[j], 1, false);
				this.Cstr_DS_Heros[j].AppendFormat("hf10{0}");
				this.tmpImg.sprite = this.GUIM.LoadFrameSprite(this.Cstr_DS_Heros[j]);
			}
			break;
		case 8:
			this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 5;
			num = 5;
			if (!this.IsAttack)
			{
				this.Img_HeroBG[panelObjectIdx].sprite = this.SArray.m_Sprites[0];
			}
			else
			{
				this.Img_HeroBG[panelObjectIdx].sprite = this.SArray.m_Sprites[1];
			}
			if (this.AWM.m_CombatPlayerData[1].bMain)
			{
				this.Img_MainHeroShow2[0] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(0).GetChild(3).GetComponent<Image>();
				this.Img_MainHeroShow2[0].gameObject.SetActive(true);
				this.Img_MainHeroShow_D[0] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(0).GetChild(3).GetChild(0).GetComponent<Image>();
				this.ShowMainHeroTime2 = 0f;
			}
			else
			{
				for (int k = 0; k < 5; k++)
				{
					if (this.Img_MainHeroShow2[k] != null)
					{
						this.Img_MainHeroShow2[k].gameObject.SetActive(false);
					}
				}
			}
			for (int l = 0; l < this.AWM.m_CombatPlayerData[1].HeroInfo.Length; l++)
			{
				if (this.AWM.m_CombatPlayerData[1].HeroInfo[l].ID > 0)
				{
					this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(l).gameObject.SetActive(true);
				}
				else
				{
					this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(l).gameObject.SetActive(false);
				}
				this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.mHeroID_D[l]);
				this.tmpImg = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(l).GetChild(0).GetComponent<Image>();
				this.tmpImg.rectTransform.pivot = new Vector2(0.5f, 0.5f);
				if (this.tmpImg.transform.childCount != 0)
				{
					this.tmpImg.transform.GetChild(0).gameObject.SetActive(true);
				}
				else if (this.tmpHero.Graph < 50000)
				{
					this.tmpImg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
				}
				else
				{
					this.Cstr_DS_Heros[l].ClearString();
					this.Cstr_DS_Heros[l].IntToFormat((long)this.tmpHero.Graph, 1, false);
					this.Cstr_DS_Heros[l].AppendFormat("UI/MapNPCHead_{0}");
					if (AssetManager.GetAssetBundleDownload(this.Cstr_DS_Heros[l], AssetPath.UI, AssetType.NPCHead, this.tmpHero.Graph, false))
					{
						int num2 = 0;
						AssetBundle assetBundle = AssetManager.GetAssetBundle(this.Cstr_DS_Heros[l], out num2);
						if (assetBundle != null)
						{
							this.mHead[l] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
						}
						if (this.mHead[l] != null)
						{
							this.mHead[l].transform.SetParent(this.tmpImg.transform);
							this.mHead[l].gameObject.SetActive(true);
							this.mHead[l].transform.GetComponent<RectTransform>().sizeDelta = new Vector2(64f, 64f);
							this.mHead[l].transform.localPosition = new Vector3(0f, 0f, 0f);
							this.mHead[l].transform.localScale = new Vector3(1f, 1f, 1f);
						}
					}
				}
				this.tmpImg = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(l).GetChild(1).GetComponent<Image>();
				this.Cstr_DS_Heros[l].ClearString();
				this.Cstr_DS_Heros[l].IntToFormat((long)this.mHeroStar_D[l], 1, false);
				this.Cstr_DS_Heros[l].AppendFormat("hf00{0}");
				this.tmpImg.sprite = this.GUIM.LoadFrameSprite(this.Cstr_DS_Heros[l]);
				this.tmpImg = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(l).GetChild(2).GetComponent<Image>();
				this.Cstr_DS_Heros[l].ClearString();
				this.Cstr_DS_Heros[l].IntToFormat((long)this.mHeroRank_D[l], 1, false);
				this.Cstr_DS_Heros[l].AppendFormat("hf10{0}");
				this.tmpImg.sprite = this.GUIM.LoadFrameSprite(this.Cstr_DS_Heros[l]);
			}
			break;
		case 9:
			this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 7;
			num = 7;
			this.tmpH = item.GetComponent<RectTransform>().sizeDelta.y;
			this.tmpRC = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.tmpRC.sizeDelta.x, this.tmpH);
			this.text_Troops_Name[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
			this.text_Troops_Name[panelObjectIdx].SetAllDirty();
			this.text_Troops_Name[panelObjectIdx].cachedTextGenerator.Invalidate();
			if (this.tmplistInfo_Data_L[dataIdx] == 0u && this.tmplistInfo_Data_H[dataIdx] == 0u && this.tmplistInfo_Data_D[dataIdx] == 0u)
			{
				this.text_Item_L[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
				this.text_Item_H[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
				this.text_Item_D[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
			}
			else
			{
				this.Cstr_tmpItem1[panelObjectIdx].ClearString();
				this.Cstr_tmpItem1[panelObjectIdx].IntToFormat((long)((ulong)this.tmplistInfo_Data_L[dataIdx]), 1, true);
				this.Cstr_tmpItem1[panelObjectIdx].AppendFormat("{0}");
				this.text_Item_L[panelObjectIdx].text = this.Cstr_tmpItem1[panelObjectIdx].ToString();
				this.Cstr_tmpItem2[panelObjectIdx].ClearString();
				this.Cstr_tmpItem2[panelObjectIdx].IntToFormat((long)((ulong)this.tmplistInfo_Data_H[dataIdx]), 1, true);
				this.Cstr_tmpItem2[panelObjectIdx].AppendFormat("{0}");
				this.text_Item_H[panelObjectIdx].text = this.Cstr_tmpItem2[panelObjectIdx].ToString();
				this.Cstr_tmpItem3[panelObjectIdx].ClearString();
				this.Cstr_tmpItem3[panelObjectIdx].IntToFormat((long)((ulong)this.tmplistInfo_Data_D[dataIdx]), 1, true);
				this.Cstr_tmpItem3[panelObjectIdx].AppendFormat("{0}");
				this.text_Item_D[panelObjectIdx].text = this.Cstr_tmpItem3[panelObjectIdx].ToString();
			}
			this.text_Item_L[panelObjectIdx].SetAllDirty();
			this.text_Item_L[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_Item_H[panelObjectIdx].SetAllDirty();
			this.text_Item_H[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_Item_D[panelObjectIdx].SetAllDirty();
			this.text_Item_D[panelObjectIdx].cachedTextGenerator.Invalidate();
			if (this.IsAttack)
			{
				this.Img_ItemInfoBG[panelObjectIdx].sprite = this.SArray.m_Sprites[0];
			}
			else
			{
				this.Img_ItemInfoBG[panelObjectIdx].sprite = this.SArray.m_Sprites[1];
			}
			this.btn_Icon1[panelObjectIdx].gameObject.SetActive(false);
			if (this.tmplistInfo_Data_Icon[dataIdx] < 255)
			{
				if (this.text_Troops_Name[panelObjectIdx].preferredWidth > 200f)
				{
					this.tmpA = 200;
				}
				else
				{
					this.tmpA = (byte)(this.text_Troops_Name[panelObjectIdx].preferredWidth + 1f);
				}
				this.btn_IconRT_1[panelObjectIdx].sizeDelta = new Vector2((float)(this.tmpA + 38), this.btn_IconRT_1[panelObjectIdx].sizeDelta.y);
				this.btn_Icon1[panelObjectIdx].gameObject.SetActive(true);
				this.tmpA = 8 + this.tmplistInfo_Data_Icon[dataIdx] / 4;
				if ((int)this.tmpA < this.SArray.m_Sprites.Length)
				{
					this.Img_Icon_1[panelObjectIdx].sprite = this.SArray.m_Sprites[(int)this.tmpA];
				}
				this.text_Icon_1[panelObjectIdx].text = ((int)(this.tmplistInfo_Data_Icon[dataIdx] % 4 + 1)).ToString();
				this.m_ItembtnHint[panelObjectIdx].Parm2 = this.tmplistInfo_Data_Icon[dataIdx];
			}
			break;
		case 10:
			this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 7;
			num = 7;
			this.tmpH = item.GetComponent<RectTransform>().sizeDelta.y;
			this.tmpRC = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.tmpRC.sizeDelta.x, this.tmpH);
			this.text_Troops_Name[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
			this.text_Troops_Name[panelObjectIdx].SetAllDirty();
			this.text_Troops_Name[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_Troops_Name[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
			this.Cstr_tmpItem1[panelObjectIdx].ClearString();
			this.Cstr_tmpItem1[panelObjectIdx].IntToFormat((long)((ulong)this.tmplistInfo_Data_L[dataIdx]), 1, true);
			this.Cstr_tmpItem1[panelObjectIdx].AppendFormat("{0}");
			this.text_Item_L[panelObjectIdx].text = this.Cstr_tmpItem1[panelObjectIdx].ToString();
			this.Cstr_tmpItem2[panelObjectIdx].ClearString();
			this.Cstr_tmpItem2[panelObjectIdx].IntToFormat((long)((ulong)this.tmplistInfo_Data_H[dataIdx]), 1, true);
			this.Cstr_tmpItem2[panelObjectIdx].AppendFormat("{0}");
			this.text_Item_H[panelObjectIdx].text = this.Cstr_tmpItem2[panelObjectIdx].ToString();
			this.Cstr_tmpItem3[panelObjectIdx].ClearString();
			this.Cstr_tmpItem3[panelObjectIdx].IntToFormat((long)((ulong)this.tmplistInfo_Data_D[dataIdx]), 1, true);
			this.Cstr_tmpItem3[panelObjectIdx].AppendFormat("{0}");
			this.text_Item_D[panelObjectIdx].text = this.Cstr_tmpItem3[panelObjectIdx].ToString();
			this.text_Item_L[panelObjectIdx].SetAllDirty();
			this.text_Item_L[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_Item_H[panelObjectIdx].SetAllDirty();
			this.text_Item_H[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_Item_D[panelObjectIdx].SetAllDirty();
			this.text_Item_D[panelObjectIdx].cachedTextGenerator.Invalidate();
			if (!this.IsAttack)
			{
				this.Img_ItemInfoBG[panelObjectIdx].sprite = this.SArray.m_Sprites[0];
			}
			else
			{
				this.Img_ItemInfoBG[panelObjectIdx].sprite = this.SArray.m_Sprites[1];
			}
			this.btn_Icon1[panelObjectIdx].gameObject.SetActive(false);
			if (this.tmplistInfo_Data_Icon[dataIdx] < 255)
			{
				this.btn_Icon1[panelObjectIdx].gameObject.SetActive(true);
				if (this.text_Troops_Name[panelObjectIdx].preferredWidth > 200f)
				{
					this.tmpA = 200;
				}
				else
				{
					this.tmpA = (byte)(this.text_Troops_Name[panelObjectIdx].preferredWidth + 1f);
				}
				this.btn_IconRT_1[panelObjectIdx].sizeDelta = new Vector2((float)(this.tmpA + 38), this.btn_IconRT_1[panelObjectIdx].sizeDelta.y);
				if (this.tmplistInfo_Data_Icon[dataIdx] < 16)
				{
					this.tmpA = 8 + this.tmplistInfo_Data_Icon[dataIdx] / 4;
				}
				else
				{
					this.tmpA = 12 + (this.tmplistInfo_Data_Icon[dataIdx] - 16) / 4;
				}
				if ((int)this.tmpA < this.SArray.m_Sprites.Length)
				{
					this.Img_Icon_1[panelObjectIdx].sprite = this.SArray.m_Sprites[(int)this.tmpA];
				}
				this.text_Icon_1[panelObjectIdx].text = ((int)(this.tmplistInfo_Data_Icon[dataIdx] % 4 + 1)).ToString();
				this.m_ItembtnHint[panelObjectIdx].Parm2 = this.tmplistInfo_Data_Icon[dataIdx];
			}
			break;
		case 11:
			this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 8;
			num = 8;
			this.text_Title4_1[panelObjectIdx].text = this.Cstr_Title4[0].ToString();
			this.text_Title4_1[panelObjectIdx].SetAllDirty();
			this.text_Title4_1[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_Title4_2[panelObjectIdx].text = this.Cstr_Title4[1].ToString();
			this.text_Title4_2[panelObjectIdx].SetAllDirty();
			this.text_Title4_2[panelObjectIdx].cachedTextGenerator.Invalidate();
			break;
		case 12:
			this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 9;
			num = 9;
			if (this.IsAttack)
			{
				this.Img_Name2_L[panelObjectIdx].sprite = this.SArray.m_Sprites[6];
				this.Img_Name2_R[panelObjectIdx].sprite = this.SArray.m_Sprites[7];
			}
			else
			{
				this.Img_Name2_L[panelObjectIdx].sprite = this.SArray.m_Sprites[7];
				this.Img_Name2_R[panelObjectIdx].sprite = this.SArray.m_Sprites[6];
			}
			break;
		case 13:
			this.mSeroll_Item[panelObjectIdx].m_BtnID2 = 10;
			num = 10;
			this.tmpH = item.GetComponent<RectTransform>().sizeDelta.y;
			this.tmpRC = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.tmpRC.sizeDelta.x, this.tmpH);
			this.text_Data2_1[panelObjectIdx].text = this.tmplistInfo_DataName[dataIdx];
			this.text_Data2_1[panelObjectIdx].SetAllDirty();
			this.text_Data2_1[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_Data2_1[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_Data2_1[panelObjectIdx].preferredWidth > 180f)
			{
				this.tmpA = 180;
			}
			else
			{
				this.tmpA = (byte)(this.text_Data2_1[panelObjectIdx].preferredWidth + 1f);
			}
			this.btn_IconRT_2[panelObjectIdx].sizeDelta = new Vector2((float)(this.tmpA + 38), this.btn_IconRT_2[panelObjectIdx].sizeDelta.y);
			this.Cstr_tmpItem1[panelObjectIdx].ClearString();
			this.Cstr_tmpItem2[panelObjectIdx].ClearString();
			if (this.tmplistInfo_Data_L[dataIdx] > 0u)
			{
				this.Cstr_tmpItem1[panelObjectIdx].IntToFormat((long)((ulong)this.tmplistInfo_Data_L[dataIdx]), 1, true);
				this.Cstr_tmpItem1[panelObjectIdx].AppendFormat("{0}");
				this.Cstr_tmpItem2[panelObjectIdx].IntToFormat((long)((ulong)this.tmplistInfo_Data_H[dataIdx]), 1, true);
				this.Cstr_tmpItem2[panelObjectIdx].AppendFormat("{0}");
			}
			else
			{
				this.Cstr_tmpItem1[panelObjectIdx].Append("-");
				this.Cstr_tmpItem2[panelObjectIdx].Append("-");
			}
			this.text_Data2_2[panelObjectIdx].text = this.Cstr_tmpItem1[panelObjectIdx].ToString();
			this.text_Data2_2[panelObjectIdx].SetAllDirty();
			this.text_Data2_2[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_Data2_3[panelObjectIdx].text = this.Cstr_tmpItem2[panelObjectIdx].ToString();
			this.text_Data2_3[panelObjectIdx].SetAllDirty();
			this.text_Data2_3[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.Cstr_tmpItem3[panelObjectIdx].ClearString();
			this.Cstr_tmpItem4[panelObjectIdx].ClearString();
			if (this.tmplistInfo_Data_D[dataIdx] > 0u)
			{
				this.Cstr_tmpItem3[panelObjectIdx].IntToFormat((long)((ulong)this.tmplistInfo_Data_D[dataIdx]), 1, true);
				this.Cstr_tmpItem3[panelObjectIdx].AppendFormat("{0}");
				this.Cstr_tmpItem4[panelObjectIdx].IntToFormat((long)((ulong)this.tmplistInfo_Data_[dataIdx]), 1, true);
				this.Cstr_tmpItem4[panelObjectIdx].AppendFormat("{0}");
			}
			else
			{
				this.Cstr_tmpItem3[panelObjectIdx].Append("-");
				this.Cstr_tmpItem4[panelObjectIdx].Append("-");
			}
			this.text_Data2_4[panelObjectIdx].text = this.Cstr_tmpItem3[panelObjectIdx].ToString();
			this.text_Data2_4[panelObjectIdx].SetAllDirty();
			this.text_Data2_4[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_Data2_5[panelObjectIdx].text = this.Cstr_tmpItem4[panelObjectIdx].ToString();
			this.text_Data2_5[panelObjectIdx].SetAllDirty();
			this.text_Data2_5[panelObjectIdx].cachedTextGenerator.Invalidate();
			if (this.IsAttack)
			{
				this.Img_Data2_L[panelObjectIdx].sprite = this.SArray.m_Sprites[4];
				this.Img_Data2_R[panelObjectIdx].sprite = this.SArray.m_Sprites[5];
			}
			else
			{
				this.Img_Data2_L[panelObjectIdx].sprite = this.SArray.m_Sprites[5];
				this.Img_Data2_R[panelObjectIdx].sprite = this.SArray.m_Sprites[4];
			}
			this.Img_Data2_L[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.Img_Data2_L[panelObjectIdx].rectTransform.sizeDelta.x, this.tmpH);
			this.Img_Data2_R[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.Img_Data2_R[panelObjectIdx].rectTransform.sizeDelta.x, this.tmpH);
			if (this.tmplistInfo_Data_Icon[dataIdx] < 16)
			{
				this.tmpA = 8 + this.tmplistInfo_Data_Icon[dataIdx] / 4;
			}
			else
			{
				this.tmpA = 12 + (this.tmplistInfo_Data_Icon[dataIdx] - 16) / 4;
			}
			if ((int)this.tmpA < this.SArray.m_Sprites.Length)
			{
				this.Img_Icon_2[panelObjectIdx].sprite = this.SArray.m_Sprites[(int)this.tmpA];
			}
			if (this.tmplistInfo_Data_Icon[dataIdx] < 255)
			{
				this.text_Icon_2[panelObjectIdx].text = ((int)(this.tmplistInfo_Data_Icon[dataIdx] % 4 + 1)).ToString();
				this.m_ItembtnHint2[panelObjectIdx].Parm2 = this.tmplistInfo_Data_Icon[dataIdx];
			}
			break;
		}
		this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).gameObject.SetActive(true);
	}

	// Token: 0x06000ECA RID: 3786 RVA: 0x00190AC8 File Offset: 0x0018ECC8
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06000ECB RID: 3787 RVA: 0x00190ACC File Offset: 0x0018ECCC
	public override void OnClose()
	{
		if (this.Cstr_Hint != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Hint);
		}
		for (int i = 0; i < 5; i++)
		{
			if (this.Cstr_DS_Heros[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_DS_Heros[i]);
			}
		}
		for (int j = 0; j < 17; j++)
		{
			if (this.Cstr_tmpItem1[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_tmpItem1[j]);
			}
			if (this.Cstr_tmpItem2[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_tmpItem2[j]);
			}
			if (this.Cstr_tmpItem3[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_tmpItem3[j]);
			}
			if (this.Cstr_tmpItem4[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_tmpItem4[j]);
			}
		}
		for (int k = 0; k < 2; k++)
		{
			if (this.Cstr_PlayName[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_PlayName[k]);
			}
			if (this.Cstr_Title[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Title[k]);
			}
			if (this.Cstr_Title4[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Title4[k]);
			}
		}
		for (int l = 0; l < 5; l++)
		{
			if (this.mHead[l] != null)
			{
				UnityEngine.Object.Destroy(this.mHead[l]);
			}
			this.mHead[l] = null;
		}
	}

	// Token: 0x06000ECC RID: 3788 RVA: 0x00190C68 File Offset: 0x0018EE68
	public void OnButtonClick(UIButton sender)
	{
		UIAlliance_FS_Infobtn btnID = (UIAlliance_FS_Infobtn)sender.m_BtnID1;
		if (btnID == UIAlliance_FS_Infobtn.btn_EXIT)
		{
			DataManager dm = this.DM;
			dm.mSaveInfo += 1;
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x06000ECD RID: 3789 RVA: 0x00190CC0 File Offset: 0x0018EEC0
	public override bool OnBackButtonClick()
	{
		DataManager dm = this.DM;
		dm.mSaveInfo += 1;
		return false;
	}

	// Token: 0x06000ECE RID: 3790 RVA: 0x00190CD8 File Offset: 0x0018EED8
	public void OnButtonDown(UIButtonHint sender)
	{
		switch (sender.Parm1)
		{
		case 1:
		case 2:
			this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(sender.Parm2 + 1));
			this.text_Hint_1.text = this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name);
			this.text_Hint_1.SetAllDirty();
			this.text_Hint_1.cachedTextGenerator.Invalidate();
			this.text_Hint_1.cachedTextGeneratorForLayout.Invalidate();
			this.text_Hint_1.rectTransform.sizeDelta = new Vector2(this.text_Hint_1.preferredWidth + 1f, this.text_Hint_1.rectTransform.sizeDelta.y);
			if (this.GUIM.IsArabic)
			{
				this.text_Hint_1.UpdateArabicPos();
			}
			this.Cstr_Hint.ClearString();
			this.Cstr_Hint.IntToFormat((long)(sender.Parm2 % 4 + 1), 1, false);
			if (sender.Parm2 < 16)
			{
				this.Cstr_Hint.StringToFormat(this.DM.mStringTable.GetStringByID((uint)((ushort)(3841 + (int)(sender.Parm2 / 4)))));
			}
			else
			{
				this.Cstr_Hint.StringToFormat(this.DM.mStringTable.GetStringByID((uint)((ushort)(12079 + (int)((sender.Parm2 - 16) / 4)))));
			}
			this.Cstr_Hint.AppendFormat(this.DM.mStringTable.GetStringByID(12078u));
			this.text_Hint_2.text = this.Cstr_Hint.ToString();
			this.text_Hint_2.SetAllDirty();
			this.text_Hint_2.cachedTextGenerator.Invalidate();
			this.text_Hint_2.cachedTextGeneratorForLayout.Invalidate();
			this.text_Hint_2.rectTransform.sizeDelta = new Vector2(this.text_Hint_2.preferredWidth + 1f, this.text_Hint_2.rectTransform.sizeDelta.y);
			if (this.GUIM.IsArabic)
			{
				this.text_Hint_2.UpdateArabicPos();
			}
			if (this.text_Hint_1.preferredWidth > this.text_Hint_2.preferredWidth)
			{
				this.Img_Hint.rectTransform.sizeDelta = new Vector2(this.text_Hint_1.preferredWidth + 21f, this.Img_Hint.rectTransform.sizeDelta.y);
			}
			else
			{
				this.Img_Hint.rectTransform.sizeDelta = new Vector2(this.text_Hint_2.preferredWidth + 21f, this.Img_Hint.rectTransform.sizeDelta.y);
			}
			sender.GetTipPosition(this.Img_Hint.rectTransform, UIButtonHint.ePosition.Original, null);
			this.Img_Hint.rectTransform.anchoredPosition = new Vector2(this.Img_Hint.rectTransform.anchoredPosition.x + 70f, this.Img_Hint.rectTransform.anchoredPosition.y);
			this.Img_Hint.gameObject.SetActive(true);
			break;
		case 3:
		case 4:
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintArmy, 0, 0f, 0, (int)(sender.Parm1 - 3), 0, Vector2.zero, UIButtonHint.ePosition.Original);
			break;
		}
	}

	// Token: 0x06000ECF RID: 3791 RVA: 0x00191064 File Offset: 0x0018F264
	public void OnButtonUp(UIButtonHint sender)
	{
		this.Img_Hint.gameObject.SetActive(false);
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x06000ED0 RID: 3792 RVA: 0x00191088 File Offset: 0x0018F288
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
			break;
		case NetworkNews.Refresh_Asset:
			if (meg[1] == 0 && meg[2] == 1)
			{
				ushort num = GameConstants.ConvertBytesToUShort(meg, 3);
				for (int i = 0; i < 5; i++)
				{
					this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.mHeroID_D[i]);
					if (GameConstants.ConvertBytesToUShort(meg, 3) == this.tmpHero.Graph)
					{
						for (int j = 0; j < 17; j++)
						{
							if (this.mSeroll_Item[j] != null && this.mSeroll_Item[j].gameObject.activeSelf)
							{
								int btnID = this.mSeroll_Item[j].m_BtnID1;
								int btnID2 = this.mSeroll_Item[j].m_BtnID2;
								if (btnID >= 0 && btnID < this.tmplistInfo_Type.Count && this.tmplistInfo_Type[btnID] == 8)
								{
									this.UpDateRowItem(this.mSeroll_Item[j].gameObject, btnID, j, 0);
								}
							}
						}
						break;
					}
				}
			}
			break;
		}
	}

	// Token: 0x06000ED1 RID: 3793 RVA: 0x001911E0 File Offset: 0x0018F3E0
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < 11; i++)
		{
			if (this.text_tmpStr[i] != null && this.text_tmpStr[i].enabled)
			{
				this.text_tmpStr[i].enabled = false;
				this.text_tmpStr[i].enabled = true;
			}
		}
		for (int j = 0; j < 17; j++)
		{
			if (this.text_Top[j] != null && this.text_Top[j].enabled)
			{
				this.text_Top[j].enabled = false;
				this.text_Top[j].enabled = true;
			}
			if (this.text_Title1[j] != null && this.text_Title1[j].enabled)
			{
				this.text_Title1[j].enabled = false;
				this.text_Title1[j].enabled = true;
			}
			if (this.text_ATitleTroops[j] != null && this.text_ATitleTroops[j].enabled)
			{
				this.text_ATitleTroops[j].enabled = false;
				this.text_ATitleTroops[j].enabled = true;
			}
			if (this.text_ATitleTraps[j] != null && this.text_ATitleTraps[j].enabled)
			{
				this.text_ATitleTraps[j].enabled = false;
				this.text_ATitleTraps[j].enabled = true;
			}
			if (this.text_Title1_1[j] != null && this.text_Title1_1[j].enabled)
			{
				this.text_Title1_1[j].enabled = false;
				this.text_Title1_1[j].enabled = true;
			}
			if (this.text_Title1_2[j] != null && this.text_Title1_2[j].enabled)
			{
				this.text_Title1_2[j].enabled = false;
				this.text_Title1_2[j].enabled = true;
			}
			if (this.text_Title2[j] != null && this.text_Title2[j].enabled)
			{
				this.text_Title2[j].enabled = false;
				this.text_Title2[j].enabled = true;
			}
			if (this.text_Title2_1[j] != null && this.text_Title2_1[j].enabled)
			{
				this.text_Title2_1[j].enabled = false;
				this.text_Title2_1[j].enabled = true;
			}
			if (this.text_DTitleTroops[j] != null && this.text_DTitleTroops[j].enabled)
			{
				this.text_DTitleTroops[j].enabled = false;
				this.text_DTitleTroops[j].enabled = true;
			}
			if (this.text_InfoName1[j] != null && this.text_InfoName1[j].enabled)
			{
				this.text_InfoName1[j].enabled = false;
				this.text_InfoName1[j].enabled = true;
			}
			if (this.text_InfoName2[j] != null && this.text_InfoName2[j].enabled)
			{
				this.text_InfoName2[j].enabled = false;
				this.text_InfoName2[j].enabled = true;
			}
			if (this.text_InfoName3[j] != null && this.text_InfoName3[j].enabled)
			{
				this.text_InfoName3[j].enabled = false;
				this.text_InfoName3[j].enabled = true;
			}
			if (this.text_InfoName4[j] != null && this.text_InfoName4[j].enabled)
			{
				this.text_InfoName4[j].enabled = false;
				this.text_InfoName4[j].enabled = true;
			}
			if (this.text_Troops_Name[j] != null && this.text_Troops_Name[j].enabled)
			{
				this.text_Troops_Name[j].enabled = false;
				this.text_Troops_Name[j].enabled = true;
			}
			if (this.text_Item_L[j] != null && this.text_Item_L[j].enabled)
			{
				this.text_Item_L[j].enabled = false;
				this.text_Item_L[j].enabled = true;
			}
			if (this.text_Item_H[j] != null && this.text_Item_H[j].enabled)
			{
				this.text_Item_H[j].enabled = false;
				this.text_Item_H[j].enabled = true;
			}
			if (this.text_Item_D[j] != null && this.text_Item_D[j].enabled)
			{
				this.text_Item_D[j].enabled = false;
				this.text_Item_D[j].enabled = true;
			}
			if (this.text_DTitleTraps[j] != null && this.text_DTitleTraps[j].enabled)
			{
				this.text_DTitleTraps[j].enabled = false;
				this.text_DTitleTraps[j].enabled = true;
			}
			if (this.text_Icon_1[j] != null && this.text_Icon_1[j].enabled)
			{
				this.text_Icon_1[j].enabled = false;
				this.text_Icon_1[j].enabled = true;
			}
			if (this.text_Icon_2[j] != null && this.text_Icon_2[j].enabled)
			{
				this.text_Icon_2[j].enabled = false;
				this.text_Icon_2[j].enabled = true;
			}
			if (this.text_Title4_1[j] != null && this.text_Title4_1[j].enabled)
			{
				this.text_Title4_1[j].enabled = false;
				this.text_Title4_1[j].enabled = true;
			}
			if (this.text_Title4_2[j] != null && this.text_Title4_2[j].enabled)
			{
				this.text_Title4_2[j].enabled = false;
				this.text_Title4_2[j].enabled = true;
			}
			if (this.text_Name2_1[j] != null && this.text_Name2_1[j].enabled)
			{
				this.text_Name2_1[j].enabled = false;
				this.text_Name2_1[j].enabled = true;
			}
			if (this.text_Name2_2[j] != null && this.text_Name2_2[j].enabled)
			{
				this.text_Name2_2[j].enabled = false;
				this.text_Name2_2[j].enabled = true;
			}
			if (this.text_Name2_3[j] != null && this.text_Name2_3[j].enabled)
			{
				this.text_Name2_3[j].enabled = false;
				this.text_Name2_3[j].enabled = true;
			}
			if (this.text_Name2_4[j] != null && this.text_Name2_4[j].enabled)
			{
				this.text_Name2_4[j].enabled = false;
				this.text_Name2_4[j].enabled = true;
			}
			if (this.text_Name2_5[j] != null && this.text_Name2_5[j].enabled)
			{
				this.text_Name2_5[j].enabled = false;
				this.text_Name2_5[j].enabled = true;
			}
			if (this.text_Data2_1[j] != null && this.text_Data2_1[j].enabled)
			{
				this.text_Data2_1[j].enabled = false;
				this.text_Data2_1[j].enabled = true;
			}
			if (this.text_Data2_2[j] != null && this.text_Data2_2[j].enabled)
			{
				this.text_Data2_2[j].enabled = false;
				this.text_Data2_2[j].enabled = true;
			}
			if (this.text_Data2_3[j] != null && this.text_Data2_3[j].enabled)
			{
				this.text_Data2_3[j].enabled = false;
				this.text_Data2_3[j].enabled = true;
			}
			if (this.text_Data2_4[j] != null && this.text_Data2_4[j].enabled)
			{
				this.text_Data2_4[j].enabled = false;
				this.text_Data2_4[j].enabled = true;
			}
			if (this.text_Data2_5[j] != null && this.text_Data2_5[j].enabled)
			{
				this.text_Data2_5[j].enabled = false;
				this.text_Data2_5[j].enabled = true;
			}
		}
	}

	// Token: 0x06000ED2 RID: 3794 RVA: 0x00191A74 File Offset: 0x0018FC74
	public override void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x06000ED3 RID: 3795 RVA: 0x00191A78 File Offset: 0x0018FC78
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.Img_MainHeroShow1[0] != null && this.Img_MainHeroShow_A[0] != null && this.Img_MainHeroShow1[0].gameObject.activeSelf)
		{
			this.ShowMainHeroTime1 += Time.smoothDeltaTime;
			if (this.ShowMainHeroTime1 >= 0f)
			{
				if (this.ShowMainHeroTime1 >= 2f)
				{
					this.ShowMainHeroTime1 = 0f;
				}
				float a = (this.ShowMainHeroTime1 <= 1f) ? this.ShowMainHeroTime1 : (2f - this.ShowMainHeroTime1);
				this.Img_MainHeroShow_A[0].color = new Color(1f, 1f, 1f, a);
			}
		}
		if (this.Img_MainHeroShow2[0] != null && this.Img_MainHeroShow_D[0] != null && this.Img_MainHeroShow2[0].gameObject.activeSelf)
		{
			this.ShowMainHeroTime2 += Time.smoothDeltaTime;
			if (this.ShowMainHeroTime2 >= 0f)
			{
				if (this.ShowMainHeroTime2 >= 2f)
				{
					this.ShowMainHeroTime2 = 0f;
				}
				float a2 = (this.ShowMainHeroTime2 <= 1f) ? this.ShowMainHeroTime2 : (2f - this.ShowMainHeroTime2);
				this.Img_MainHeroShow_D[0].color = new Color(1f, 1f, 1f, a2);
			}
		}
	}

	// Token: 0x04003037 RID: 12343
	private Transform GameT;

	// Token: 0x04003038 RID: 12344
	private Transform Tmp;

	// Token: 0x04003039 RID: 12345
	private ScrollPanelItem[] mSeroll_Item = new ScrollPanelItem[17];

	// Token: 0x0400303A RID: 12346
	private RectTransform tmpRC;

	// Token: 0x0400303B RID: 12347
	private RectTransform[] btn_IconRT_1 = new RectTransform[17];

	// Token: 0x0400303C RID: 12348
	private RectTransform[] btn_IconRT_2 = new RectTransform[17];

	// Token: 0x0400303D RID: 12349
	private UIButton btn_EXIT;

	// Token: 0x0400303E RID: 12350
	private UIButton[] btn_Icon1 = new UIButton[17];

	// Token: 0x0400303F RID: 12351
	private UIButton[] btn_Icon2 = new UIButton[17];

	// Token: 0x04003040 RID: 12352
	private Image tmpImg;

	// Token: 0x04003041 RID: 12353
	private Image Img_Hint;

	// Token: 0x04003042 RID: 12354
	private Image[] Img_MainHeroShow1 = new Image[5];

	// Token: 0x04003043 RID: 12355
	private Image[] Img_MainHeroShow_A = new Image[5];

	// Token: 0x04003044 RID: 12356
	private Image[] Img_MainHeroShow2 = new Image[5];

	// Token: 0x04003045 RID: 12357
	private Image[] Img_MainHeroShow_D = new Image[5];

	// Token: 0x04003046 RID: 12358
	private UIText tmptext;

	// Token: 0x04003047 RID: 12359
	private UIText text_Hint_1;

	// Token: 0x04003048 RID: 12360
	private UIText text_Hint_2;

	// Token: 0x04003049 RID: 12361
	private UIText[] text_tmpStr = new UIText[11];

	// Token: 0x0400304A RID: 12362
	private CString[] Cstr_DS_Heros = new CString[5];

	// Token: 0x0400304B RID: 12363
	private DataManager DM;

	// Token: 0x0400304C RID: 12364
	private GUIManager GUIM;

	// Token: 0x0400304D RID: 12365
	private AllianceWarManager AWM;

	// Token: 0x0400304E RID: 12366
	private Font TTFont;

	// Token: 0x0400304F RID: 12367
	private Door door;

	// Token: 0x04003050 RID: 12368
	private UISpritesArray SArray;

	// Token: 0x04003051 RID: 12369
	private Material mMaT;

	// Token: 0x04003052 RID: 12370
	private Material IconMaterial;

	// Token: 0x04003053 RID: 12371
	private Material FrameMaterial;

	// Token: 0x04003054 RID: 12372
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04003055 RID: 12373
	private List<float> tmplist = new List<float>();

	// Token: 0x04003056 RID: 12374
	private List<byte> tmplistInfo_Type = new List<byte>();

	// Token: 0x04003057 RID: 12375
	private List<string> tmplistInfo_DataName = new List<string>();

	// Token: 0x04003058 RID: 12376
	private List<uint> tmplistInfo_Data_L = new List<uint>();

	// Token: 0x04003059 RID: 12377
	private List<uint> tmplistInfo_Data_H = new List<uint>();

	// Token: 0x0400305A RID: 12378
	private List<uint> tmplistInfo_Data_D = new List<uint>();

	// Token: 0x0400305B RID: 12379
	private List<uint> tmplistInfo_Data_ = new List<uint>();

	// Token: 0x0400305C RID: 12380
	private List<byte> tmplistInfo_Data_Icon = new List<byte>();

	// Token: 0x0400305D RID: 12381
	private Image[] Img_HeroBG = new Image[17];

	// Token: 0x0400305E RID: 12382
	private Image[] Img_ItemTitleBG = new Image[17];

	// Token: 0x0400305F RID: 12383
	private Image[] Img_ItemInfoBG = new Image[17];

	// Token: 0x04003060 RID: 12384
	private Image[] Img_Icon_1 = new Image[17];

	// Token: 0x04003061 RID: 12385
	private Image[] Img_Icon_2 = new Image[17];

	// Token: 0x04003062 RID: 12386
	private Image[] Img_Name2_L = new Image[17];

	// Token: 0x04003063 RID: 12387
	private Image[] Img_Name2_R = new Image[17];

	// Token: 0x04003064 RID: 12388
	private Image[] Img_Data2_L = new Image[17];

	// Token: 0x04003065 RID: 12389
	private Image[] Img_Data2_R = new Image[17];

	// Token: 0x04003066 RID: 12390
	private Image[] Img_Hint1 = new Image[17];

	// Token: 0x04003067 RID: 12391
	private Image[] Img_Hint2 = new Image[17];

	// Token: 0x04003068 RID: 12392
	private UIText[] text_Top = new UIText[17];

	// Token: 0x04003069 RID: 12393
	private UIText[] text_Title1 = new UIText[17];

	// Token: 0x0400306A RID: 12394
	private UIText[] text_ATitleTroops = new UIText[17];

	// Token: 0x0400306B RID: 12395
	private UIText[] text_ATitleTraps = new UIText[17];

	// Token: 0x0400306C RID: 12396
	private UIText[] text_Title1_1 = new UIText[17];

	// Token: 0x0400306D RID: 12397
	private UIText[] text_Title1_2 = new UIText[17];

	// Token: 0x0400306E RID: 12398
	private UIText[] text_Title2 = new UIText[17];

	// Token: 0x0400306F RID: 12399
	private UIText[] text_Title2_1 = new UIText[17];

	// Token: 0x04003070 RID: 12400
	private UIText[] text_DTitleTroops = new UIText[17];

	// Token: 0x04003071 RID: 12401
	private UIText[] text_DTitleTraps = new UIText[17];

	// Token: 0x04003072 RID: 12402
	private UIText[] text_InfoName1 = new UIText[17];

	// Token: 0x04003073 RID: 12403
	private UIText[] text_InfoName2 = new UIText[17];

	// Token: 0x04003074 RID: 12404
	private UIText[] text_InfoName3 = new UIText[17];

	// Token: 0x04003075 RID: 12405
	private UIText[] text_InfoName4 = new UIText[17];

	// Token: 0x04003076 RID: 12406
	private UIText[] text_Troops_Name = new UIText[17];

	// Token: 0x04003077 RID: 12407
	private UIText[] text_Item_L = new UIText[17];

	// Token: 0x04003078 RID: 12408
	private UIText[] text_Item_H = new UIText[17];

	// Token: 0x04003079 RID: 12409
	private UIText[] text_Item_D = new UIText[17];

	// Token: 0x0400307A RID: 12410
	private UIText[] text_Icon_1 = new UIText[17];

	// Token: 0x0400307B RID: 12411
	private UIText[] text_Icon_2 = new UIText[17];

	// Token: 0x0400307C RID: 12412
	private UIText[] text_Title4_1 = new UIText[17];

	// Token: 0x0400307D RID: 12413
	private UIText[] text_Title4_2 = new UIText[17];

	// Token: 0x0400307E RID: 12414
	private UIText[] text_Name2_1 = new UIText[17];

	// Token: 0x0400307F RID: 12415
	private UIText[] text_Name2_2 = new UIText[17];

	// Token: 0x04003080 RID: 12416
	private UIText[] text_Name2_3 = new UIText[17];

	// Token: 0x04003081 RID: 12417
	private UIText[] text_Name2_4 = new UIText[17];

	// Token: 0x04003082 RID: 12418
	private UIText[] text_Name2_5 = new UIText[17];

	// Token: 0x04003083 RID: 12419
	private UIText[] text_Data2_1 = new UIText[17];

	// Token: 0x04003084 RID: 12420
	private UIText[] text_Data2_2 = new UIText[17];

	// Token: 0x04003085 RID: 12421
	private UIText[] text_Data2_3 = new UIText[17];

	// Token: 0x04003086 RID: 12422
	private UIText[] text_Data2_4 = new UIText[17];

	// Token: 0x04003087 RID: 12423
	private UIText[] text_Data2_5 = new UIText[17];

	// Token: 0x04003088 RID: 12424
	private string[] ItemInfo = new string[4];

	// Token: 0x04003089 RID: 12425
	private CString[] Cstr_PlayName = new CString[2];

	// Token: 0x0400308A RID: 12426
	private CString[] Cstr_Title = new CString[2];

	// Token: 0x0400308B RID: 12427
	private CString[] Cstr_Title4 = new CString[2];

	// Token: 0x0400308C RID: 12428
	private CString[] Cstr_tmpItem1 = new CString[17];

	// Token: 0x0400308D RID: 12429
	private CString[] Cstr_tmpItem2 = new CString[17];

	// Token: 0x0400308E RID: 12430
	private CString[] Cstr_tmpItem3 = new CString[17];

	// Token: 0x0400308F RID: 12431
	private CString[] Cstr_tmpItem4 = new CString[17];

	// Token: 0x04003090 RID: 12432
	private CString Cstr_Hint;

	// Token: 0x04003091 RID: 12433
	private ushort[] mHeroID_A = new ushort[5];

	// Token: 0x04003092 RID: 12434
	private byte[] mHeroRank_A = new byte[5];

	// Token: 0x04003093 RID: 12435
	private byte[] mHeroStar_A = new byte[5];

	// Token: 0x04003094 RID: 12436
	private ushort[] mHeroID_D = new ushort[5];

	// Token: 0x04003095 RID: 12437
	private byte[] mHeroRank_D = new byte[5];

	// Token: 0x04003096 RID: 12438
	private byte[] mHeroStar_D = new byte[5];

	// Token: 0x04003097 RID: 12439
	private float tmpH;

	// Token: 0x04003098 RID: 12440
	private float ShowMainHeroTime1;

	// Token: 0x04003099 RID: 12441
	private float ShowMainHeroTime2;

	// Token: 0x0400309A RID: 12442
	private bool IsAttack;

	// Token: 0x0400309B RID: 12443
	private Hero tmpHero;

	// Token: 0x0400309C RID: 12444
	private SoldierData tmpSD;

	// Token: 0x0400309D RID: 12445
	private GameObject[] mHead = new GameObject[5];

	// Token: 0x0400309E RID: 12446
	private byte tmpA;

	// Token: 0x0400309F RID: 12447
	private UIButtonHint hint;

	// Token: 0x040030A0 RID: 12448
	private UIButtonHint[] m_ItembtnHint = new UIButtonHint[17];

	// Token: 0x040030A1 RID: 12449
	private UIButtonHint[] m_ItembtnHint2 = new UIButtonHint[17];
}
