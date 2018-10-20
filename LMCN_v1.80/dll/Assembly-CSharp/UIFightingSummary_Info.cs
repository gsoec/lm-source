using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000555 RID: 1365
public class UIFightingSummary_Info : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06001B33 RID: 6963 RVA: 0x002FFF24 File Offset: 0x002FE124
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
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

	// Token: 0x06001B34 RID: 6964 RVA: 0x00300DBC File Offset: 0x002FEFBC
	public void SetFsData(bool bopen = true)
	{
		this.tmplist.Clear();
		this.tmplistInfo_Type.Clear();
		this.tmplistInfo_DataName.Clear();
		this.tmplistInfo_Data_L.Clear();
		this.tmplistInfo_Data_H.Clear();
		this.tmplistInfo_Data_D.Clear();
		this.tmplistInfo_Data_.Clear();
		this.tmplistInfo_Data_Icon.Clear();
		if (this.DM.mFs_Side == 0 || this.DM.mFs_Side == 2 || this.DM.mFs_Side == 4 || this.DM.mFs_Side == 6)
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
		this.Cstr_Title4[0].Append(this.DM.mStringTable.GetStringByID(5315u));
		if (this.IsAttack)
		{
			this.Cstr_Title4[0].Append(this.DM.mStringTable.GetStringByID(5317u));
		}
		this.Cstr_Title4[1].ClearString();
		this.Cstr_Title4[1].Append(this.DM.mStringTable.GetStringByID(5316u));
		if (!this.IsAttack)
		{
			this.Cstr_Title4[1].Append(this.DM.mStringTable.GetStringByID(5317u));
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
		for (int i = 0; i < 16; i++)
		{
			int num = 3 - i / 4 + i % 4 * 4;
			if (this.DM.mFs_A_ST[num] > 0u || this.DM.mFs_D_ST[num] > 0u)
			{
				this.tmplistInfo_Type.Add(13);
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num + 1));
				this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
				this.tmplistInfo_Data_L.Add(this.DM.mFs_A_ST[num]);
				this.tmplistInfo_Data_H.Add(this.DM.mFs_A_SL[num]);
				this.tmplistInfo_Data_D.Add(this.DM.mFs_D_ST[num]);
				this.tmplistInfo_Data_.Add(this.DM.mFs_D_SL[num]);
				this.tmplistInfo_Data_Icon.Add((byte)num);
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
		this.Cstr_Title[0].Append(this.DM.mStringTable.GetStringByID(12074u));
		if (this.IsAttack)
		{
			this.Cstr_Title[0].Append(this.DM.mStringTable.GetStringByID(5317u));
		}
		this.tmplistInfo_DataName.Add(this.Cstr_Title[0].ToString());
		this.tmplistInfo_Data_L.Add(0u);
		this.tmplistInfo_Data_H.Add(0u);
		this.tmplistInfo_Data_D.Add(0u);
		this.tmplistInfo_Data_.Add(0u);
		this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
		this.tmplist.Add(44f);
		if (this.DM.mFS_DetailData.HasSeigeData == 1)
		{
			this.tmplistInfo_Type.Add(2);
		}
		else
		{
			this.tmplistInfo_Type.Add(3);
		}
		if (this.IsAttack && (this.DM.mFs_Side == 0 || this.DM.mFs_Side == 4))
		{
			this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID(5338u));
		}
		else
		{
			this.tmplistInfo_DataName.Add(this.DM.mFS_DetailData.mFS_Info[0].Name.ToString());
		}
		this.tmplistInfo_Data_L.Add(this.DM.mFS_DetailData.mFS_Info[0].Troops);
		this.tmplistInfo_Data_H.Add(this.DM.mFS_DetailData.mFS_Info[0].Traps);
		this.tmplistInfo_Data_D.Add(0u);
		this.tmplistInfo_Data_.Add(0u);
		this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
		this.tmplist.Add(59f);
		if (this.DM.mFS_DetailData.mFS_Hero[0].HeroNum > 0)
		{
			this.tmplistInfo_Type.Add(7);
			this.tmplistInfo_DataName.Add(string.Empty);
			this.tmplistInfo_Data_L.Add(0u);
			this.tmplistInfo_Data_H.Add(0u);
			this.tmplistInfo_Data_D.Add(0u);
			this.tmplistInfo_Data_.Add(0u);
			this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
			for (int j = 0; j < (int)this.DM.mFS_DetailData.mFS_Hero[0].HeroNum; j++)
			{
				this.mHeroID_A[j] = this.DM.mFS_DetailData.mFS_Hero[0].HeroID[j];
				this.mHeroRank_A[j] = this.DM.mFS_DetailData.mFS_Hero[0].Rank[j];
				this.mHeroStar_A[j] = this.DM.mFS_DetailData.mFS_Hero[0].Star[j];
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
		for (int k = 0; k < 16; k++)
		{
			int num = 3 - k / 4 + k % 4 * 4;
			if ((this.DM.mFS_DetailData.mFS_Info[0].TroopsFlag >> num & 1) == 1)
			{
				this.tmpA += 1;
				this.tmplistInfo_Type.Add(9);
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num + 1));
				this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
				this.tmplistInfo_Data_L.Add(this.DM.mFS_DetailData.mFS_Info[0].Troops_L[num]);
				this.tmplistInfo_Data_H.Add(this.DM.mFS_DetailData.mFS_Info[0].Troops_H[num]);
				this.tmplistInfo_Data_D.Add(this.DM.mFS_DetailData.mFS_Info[0].Troops_D[num]);
				this.tmplistInfo_Data_.Add(0u);
				this.tmplistInfo_Data_Icon.Add((byte)num);
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
		if (!bopen || this.DM.mFs_A_Count > 0)
		{
			for (int l = 0; l < (int)this.DM.mFs_A_Count; l++)
			{
				if (this.DM.mFS_DetailData.HasSeigeData == 1)
				{
					this.tmplistInfo_Type.Add(2);
				}
				else
				{
					this.tmplistInfo_Type.Add(3);
				}
				this.Cstr_PlayName[1].ClearString();
				this.Cstr_PlayName[1].Append(this.DM.mFs_Info_A[l].Name);
				if (DataManager.CompareStr(this.Cstr_PlayName[0], this.Cstr_PlayName[1]) == 0 && this.IsAttack && (this.DM.mFs_Side == 2 || this.DM.mFs_Side == 6))
				{
					this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID(5338u));
				}
				else
				{
					this.tmplistInfo_DataName.Add(this.DM.mFs_Info_A[l].Name.ToString());
				}
				this.tmplistInfo_Data_L.Add(this.DM.mFs_Info_A[l].Troops);
				this.tmplistInfo_Data_H.Add(this.DM.mFs_Info_A[l].Traps);
				this.tmplistInfo_Data_D.Add(0u);
				this.tmplistInfo_Data_.Add(0u);
				this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
				this.tmplist.Add(59f);
				this.tmplistInfo_Type.Add(5);
				this.tmplistInfo_DataName.Add(string.Empty);
				this.tmplistInfo_Data_L.Add(1u);
				this.tmplistInfo_Data_H.Add(0u);
				this.tmplistInfo_Data_D.Add(0u);
				this.tmplistInfo_Data_.Add(0u);
				this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
				this.tmplist.Add(38f);
				int num2 = 0;
				for (int m = 0; m < 16; m++)
				{
					int num = 3 - m / 4 + m % 4 * 4;
					if ((this.DM.mFs_Info_A[l].TroopsFlag >> num & 1) == 1)
					{
						num2++;
						this.tmplistInfo_Type.Add(9);
						this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num + 1));
						this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
						this.tmplistInfo_Data_L.Add(this.DM.mFs_Info_A[l].Troops_L[num]);
						this.tmplistInfo_Data_H.Add(this.DM.mFs_Info_A[l].Troops_H[num]);
						this.tmplistInfo_Data_D.Add(this.DM.mFs_Info_A[l].Troops_D[num]);
						this.tmplistInfo_Data_.Add(0u);
						this.tmplistInfo_Data_Icon.Add((byte)num);
						this.tmplist.Add(35f);
					}
				}
				if (num2 > 0)
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
			}
		}
		this.tmplistInfo_Type.Add(1);
		this.Cstr_Title[1].ClearString();
		this.Cstr_Title[1].Append(this.DM.mStringTable.GetStringByID(12075u));
		if (!this.IsAttack)
		{
			this.Cstr_Title[1].Append(this.DM.mStringTable.GetStringByID(5317u));
		}
		this.tmplistInfo_DataName.Add(this.Cstr_Title[1].ToString());
		this.tmplistInfo_Data_L.Add(0u);
		this.tmplistInfo_Data_H.Add(0u);
		this.tmplistInfo_Data_D.Add(0u);
		this.tmplistInfo_Data_.Add(0u);
		this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
		this.tmplist.Add(44f);
		this.tmplistInfo_Type.Add(3);
		if (!this.IsAttack && (this.DM.mFs_Side == 1 || this.DM.mFs_Side == 5))
		{
			this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID(5338u));
		}
		else
		{
			this.tmplistInfo_DataName.Add(this.DM.mFS_DetailData.mFS_Info[1].Name.ToString());
		}
		this.tmplistInfo_Data_L.Add(this.DM.mFS_DetailData.mFS_Info[1].Troops);
		this.tmplistInfo_Data_H.Add(this.DM.mFS_DetailData.mFS_Info[1].Traps);
		this.tmplistInfo_Data_D.Add(0u);
		this.tmplistInfo_Data_.Add(0u);
		this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
		this.tmplist.Add(59f);
		if (this.DM.mFS_DetailData.mFS_Hero[1].HeroNum > 0)
		{
			this.tmplistInfo_Type.Add(8);
			this.tmplistInfo_DataName.Add(string.Empty);
			this.tmplistInfo_Data_L.Add(1u);
			this.tmplistInfo_Data_H.Add(0u);
			this.tmplistInfo_Data_D.Add(0u);
			this.tmplistInfo_Data_.Add(0u);
			this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
			for (int n = 0; n < (int)this.DM.mFS_DetailData.mFS_Hero[1].HeroNum; n++)
			{
				this.mHeroID_D[n] = this.DM.mFS_DetailData.mFS_Hero[1].HeroID[n];
				this.mHeroRank_D[n] = this.DM.mFS_DetailData.mFS_Hero[1].Rank[n];
				this.mHeroStar_D[n] = this.DM.mFS_DetailData.mFS_Hero[1].Star[n];
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
		for (int num3 = 0; num3 < 16; num3++)
		{
			int num = 3 - num3 / 4 + num3 % 4 * 4;
			if ((this.DM.mFS_DetailData.mFS_Info[1].TroopsFlag >> num & 1) == 1)
			{
				this.tmpA += 1;
				this.tmplistInfo_Type.Add(10);
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num + 1));
				this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
				this.tmplistInfo_Data_L.Add(this.DM.mFS_DetailData.mFS_Info[1].Troops_L[num]);
				this.tmplistInfo_Data_H.Add(this.DM.mFS_DetailData.mFS_Info[1].Troops_H[num]);
				this.tmplistInfo_Data_D.Add(this.DM.mFS_DetailData.mFS_Info[1].Troops_D[num]);
				this.tmplistInfo_Data_.Add(0u);
				this.tmplistInfo_Data_Icon.Add((byte)num);
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
		if (this.DM.mFS_DetailData.HasSeigeData == 1)
		{
			this.tmplistInfo_Type.Add(4);
			this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID(5345u));
			this.tmplistInfo_Data_L.Add(0u);
			this.tmplistInfo_Data_H.Add(0u);
			this.tmplistInfo_Data_D.Add(0u);
			this.tmplistInfo_Data_.Add(0u);
			this.tmplistInfo_Data_Icon.Add(0);
			this.tmplist.Add(59f);
			this.tmplistInfo_Type.Add(6);
			this.tmplistInfo_DataName.Add(string.Empty);
			this.tmplistInfo_Data_L.Add(0u);
			this.tmplistInfo_Data_H.Add(0u);
			this.tmplistInfo_Data_D.Add(0u);
			this.tmplistInfo_Data_.Add(0u);
			this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
			this.tmplist.Add(38f);
			this.tmpA = 0;
			for (int num4 = 0; num4 < 12; num4++)
			{
				int num = 3 - num4 / 3 + num4 % 3 * 4;
				if ((this.DM.mFS_DetailData.TrapsFlag >> num & 1) == 1)
				{
					this.tmpA += 1;
					this.tmplistInfo_Type.Add(10);
					this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num + 17));
					this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
					this.tmplistInfo_Data_L.Add(this.DM.mFS_DetailData.mTraps_L[num]);
					this.tmplistInfo_Data_H.Add(this.DM.mFS_DetailData.mTraps_S[num]);
					this.tmplistInfo_Data_D.Add(this.DM.mFS_DetailData.mTraps_D[num]);
					this.tmplistInfo_Data_.Add(0u);
					this.tmplistInfo_Data_Icon.Add((byte)(num + 16));
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
		}
		if (!bopen || this.DM.mFs_D_Count > 0)
		{
			for (int num5 = 0; num5 < (int)this.DM.mFs_D_Count; num5++)
			{
				this.Cstr_PlayName[1].ClearString();
				this.Cstr_PlayName[1].Append(this.DM.mFs_Info_D[num5].Name);
				this.tmplistInfo_Type.Add(3);
				if (DataManager.CompareStr(this.Cstr_PlayName[0], this.Cstr_PlayName[1]) == 0 && !this.IsAttack && this.DM.mFs_Side == 3)
				{
					this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID(5338u));
				}
				else
				{
					this.tmplistInfo_DataName.Add(this.DM.mFs_Info_D[num5].Name.ToString());
				}
				this.tmplistInfo_Data_L.Add(this.DM.mFs_Info_D[num5].Troops);
				this.tmplistInfo_Data_H.Add(this.DM.mFs_Info_D[num5].Traps);
				this.tmplistInfo_Data_D.Add(0u);
				this.tmplistInfo_Data_.Add(0u);
				this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
				this.tmplist.Add(59f);
				this.tmplistInfo_Type.Add(6);
				this.tmplistInfo_DataName.Add(string.Empty);
				this.tmplistInfo_Data_L.Add(1u);
				this.tmplistInfo_Data_H.Add(0u);
				this.tmplistInfo_Data_D.Add(0u);
				this.tmplistInfo_Data_.Add(0u);
				this.tmplistInfo_Data_Icon.Add(byte.MaxValue);
				this.tmplist.Add(38f);
				int num6 = 0;
				for (int num7 = 0; num7 < 16; num7++)
				{
					int num = 3 - num7 / 4 + num7 % 4 * 4;
					if ((this.DM.mFs_Info_D[num5].TroopsFlag >> num & 1) == 1)
					{
						num6++;
						this.tmplistInfo_Type.Add(10);
						this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num + 1));
						this.tmplistInfo_DataName.Add(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
						this.tmplistInfo_Data_L.Add(this.DM.mFs_Info_D[num5].Troops_L[num]);
						this.tmplistInfo_Data_H.Add(this.DM.mFs_Info_D[num5].Troops_H[num]);
						this.tmplistInfo_Data_D.Add(this.DM.mFs_Info_D[num5].Troops_D[num]);
						this.tmplistInfo_Data_.Add(0u);
						this.tmplistInfo_Data_Icon.Add((byte)num);
						this.tmplist.Add(35f);
					}
				}
				if (num6 > 0)
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
			}
		}
		if (!bopen)
		{
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
		}
	}

	// Token: 0x06001B35 RID: 6965 RVA: 0x003027C8 File Offset: 0x003009C8
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
			if (this.DM.mFs_Main[0] == 1 && this.DM.mFs_A_MHIdx != 5)
			{
				this.Img_MainHeroShow1[(int)this.DM.mFs_A_MHIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild((int)this.DM.mFs_A_MHIdx).GetChild(3).GetComponent<Image>();
				this.Img_MainHeroShow1[(int)this.DM.mFs_A_MHIdx].gameObject.SetActive(true);
				this.Img_MainHeroShow_A[(int)this.DM.mFs_A_MHIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild((int)this.DM.mFs_A_MHIdx).GetChild(3).GetChild(0).GetComponent<Image>();
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
			for (int j = 0; j < (int)this.DM.mFS_DetailData.mFS_Hero[0].HeroNum; j++)
			{
				this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(j).gameObject.SetActive(true);
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
			for (int k = (int)this.DM.mFS_DetailData.mFS_Hero[0].HeroNum; k < 5; k++)
			{
				this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(k).gameObject.SetActive(false);
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
			if (this.DM.mFs_Main[1] == 1 && this.DM.mFs_D_MHIdx != 5)
			{
				this.Img_MainHeroShow2[(int)this.DM.mFs_D_MHIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild((int)this.DM.mFs_D_MHIdx).GetChild(3).GetComponent<Image>();
				this.Img_MainHeroShow2[(int)this.DM.mFs_D_MHIdx].gameObject.SetActive(true);
				this.Img_MainHeroShow_D[(int)this.DM.mFs_D_MHIdx] = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild((int)this.DM.mFs_D_MHIdx).GetChild(3).GetChild(0).GetComponent<Image>();
				this.ShowMainHeroTime2 = 0f;
			}
			else
			{
				for (int l = 0; l < 5; l++)
				{
					if (this.Img_MainHeroShow2[l] != null)
					{
						this.Img_MainHeroShow2[l].gameObject.SetActive(false);
					}
				}
			}
			for (int m = 0; m < (int)this.DM.mFS_DetailData.mFS_Hero[1].HeroNum; m++)
			{
				this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(m).gameObject.SetActive(true);
				this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.mHeroID_D[m]);
				this.tmpImg = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(m).GetChild(0).GetComponent<Image>();
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
					this.Cstr_DS_Heros[m].ClearString();
					this.Cstr_DS_Heros[m].IntToFormat((long)this.tmpHero.Graph, 1, false);
					this.Cstr_DS_Heros[m].AppendFormat("UI/MapNPCHead_{0}");
					if (AssetManager.GetAssetBundleDownload(this.Cstr_DS_Heros[m], AssetPath.UI, AssetType.NPCHead, this.tmpHero.Graph, false))
					{
						int num2 = 0;
						AssetBundle assetBundle = AssetManager.GetAssetBundle(this.Cstr_DS_Heros[m], out num2);
						if (assetBundle != null)
						{
							this.mHead[m] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
						}
						if (this.mHead[m] != null)
						{
							this.mHead[m].transform.SetParent(this.tmpImg.transform);
							this.mHead[m].gameObject.SetActive(true);
							this.mHead[m].transform.GetComponent<RectTransform>().sizeDelta = new Vector2(64f, 64f);
							this.mHead[m].transform.localPosition = new Vector3(0f, 0f, 0f);
							this.mHead[m].transform.localScale = new Vector3(1f, 1f, 1f);
						}
					}
				}
				this.tmpImg = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(m).GetChild(1).GetComponent<Image>();
				this.Cstr_DS_Heros[m].ClearString();
				this.Cstr_DS_Heros[m].IntToFormat((long)this.mHeroStar_D[m], 1, false);
				this.Cstr_DS_Heros[m].AppendFormat("hf00{0}");
				this.tmpImg.sprite = this.GUIM.LoadFrameSprite(this.Cstr_DS_Heros[m]);
				this.tmpImg = this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(m).GetChild(2).GetComponent<Image>();
				this.Cstr_DS_Heros[m].ClearString();
				this.Cstr_DS_Heros[m].IntToFormat((long)this.mHeroRank_D[m], 1, false);
				this.Cstr_DS_Heros[m].AppendFormat("hf10{0}");
				this.tmpImg.sprite = this.GUIM.LoadFrameSprite(this.Cstr_DS_Heros[m]);
			}
			for (int n = (int)this.DM.mFS_DetailData.mFS_Hero[1].HeroNum; n < 5; n++)
			{
				this.mSeroll_Item[panelObjectIdx].transform.GetChild(num - 1).GetChild(n).gameObject.SetActive(false);
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

	// Token: 0x06001B36 RID: 6966 RVA: 0x00304D80 File Offset: 0x00302F80
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001B37 RID: 6967 RVA: 0x00304D84 File Offset: 0x00302F84
	public float AddAttPlayer(float ftmpH, bool bAdd = false, byte mNum = 0)
	{
		return 0f;
	}

	// Token: 0x06001B38 RID: 6968 RVA: 0x00304D98 File Offset: 0x00302F98
	public float Add_DPlayer(float ftmpH, bool bAdd = false, byte mNum = 0)
	{
		return 0f;
	}

	// Token: 0x06001B39 RID: 6969 RVA: 0x00304DAC File Offset: 0x00302FAC
	public void UpDateUI_H()
	{
	}

	// Token: 0x06001B3A RID: 6970 RVA: 0x00304DB0 File Offset: 0x00302FB0
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

	// Token: 0x06001B3B RID: 6971 RVA: 0x00304F4C File Offset: 0x0030314C
	public void OnButtonClick(UIButton sender)
	{
		FightingSummary_Infobtn btnID = (FightingSummary_Infobtn)sender.m_BtnID1;
		if (btnID == FightingSummary_Infobtn.btn_EXIT)
		{
			DataManager dm = this.DM;
			dm.mSaveInfo += 1;
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x06001B3C RID: 6972 RVA: 0x00304FA4 File Offset: 0x003031A4
	public override bool OnBackButtonClick()
	{
		DataManager dm = this.DM;
		dm.mSaveInfo += 1;
		return false;
	}

	// Token: 0x06001B3D RID: 6973 RVA: 0x00304FBC File Offset: 0x003031BC
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

	// Token: 0x06001B3E RID: 6974 RVA: 0x00305348 File Offset: 0x00303548
	public void OnButtonUp(UIButtonHint sender)
	{
		this.Img_Hint.gameObject.SetActive(false);
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x06001B3F RID: 6975 RVA: 0x0030536C File Offset: 0x0030356C
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

	// Token: 0x06001B40 RID: 6976 RVA: 0x003054B4 File Offset: 0x003036B4
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

	// Token: 0x06001B41 RID: 6977 RVA: 0x00305D48 File Offset: 0x00303F48
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.SetFsData(false);
		}
	}

	// Token: 0x06001B42 RID: 6978 RVA: 0x00305D70 File Offset: 0x00303F70
	private void Start()
	{
	}

	// Token: 0x06001B43 RID: 6979 RVA: 0x00305D74 File Offset: 0x00303F74
	private void Update()
	{
		if (this.DM.mFs_A_MHIdx != 5 && this.Img_MainHeroShow1[(int)this.DM.mFs_A_MHIdx] != null && this.Img_MainHeroShow_A[(int)this.DM.mFs_A_MHIdx] != null && this.Img_MainHeroShow1[(int)this.DM.mFs_A_MHIdx].gameObject.activeSelf)
		{
			this.ShowMainHeroTime1 += Time.smoothDeltaTime;
			if (this.ShowMainHeroTime1 >= 0f)
			{
				if (this.ShowMainHeroTime1 >= 2f)
				{
					this.ShowMainHeroTime1 = 0f;
				}
				float a = (this.ShowMainHeroTime1 <= 1f) ? this.ShowMainHeroTime1 : (2f - this.ShowMainHeroTime1);
				this.Img_MainHeroShow_A[(int)this.DM.mFs_A_MHIdx].color = new Color(1f, 1f, 1f, a);
			}
		}
		if (this.DM.mFs_D_MHIdx != 5 && this.Img_MainHeroShow2[(int)this.DM.mFs_D_MHIdx] != null && this.Img_MainHeroShow_D[(int)this.DM.mFs_D_MHIdx] != null && this.Img_MainHeroShow2[(int)this.DM.mFs_D_MHIdx].gameObject.activeSelf)
		{
			this.ShowMainHeroTime2 += Time.smoothDeltaTime;
			if (this.ShowMainHeroTime2 >= 0f)
			{
				if (this.ShowMainHeroTime2 >= 2f)
				{
					this.ShowMainHeroTime2 = 0f;
				}
				float a2 = (this.ShowMainHeroTime2 <= 1f) ? this.ShowMainHeroTime2 : (2f - this.ShowMainHeroTime2);
				this.Img_MainHeroShow_D[(int)this.DM.mFs_D_MHIdx].color = new Color(1f, 1f, 1f, a2);
			}
		}
	}

	// Token: 0x04005201 RID: 20993
	private Transform GameT;

	// Token: 0x04005202 RID: 20994
	private Transform Tmp;

	// Token: 0x04005203 RID: 20995
	private ScrollPanelItem[] mSeroll_Item = new ScrollPanelItem[17];

	// Token: 0x04005204 RID: 20996
	private RectTransform tmpRC;

	// Token: 0x04005205 RID: 20997
	private RectTransform[] btn_IconRT_1 = new RectTransform[17];

	// Token: 0x04005206 RID: 20998
	private RectTransform[] btn_IconRT_2 = new RectTransform[17];

	// Token: 0x04005207 RID: 20999
	private UIButton btn_EXIT;

	// Token: 0x04005208 RID: 21000
	private UIButton[] btn_Icon1 = new UIButton[17];

	// Token: 0x04005209 RID: 21001
	private UIButton[] btn_Icon2 = new UIButton[17];

	// Token: 0x0400520A RID: 21002
	private Image tmpImg;

	// Token: 0x0400520B RID: 21003
	private Image Img_Hint;

	// Token: 0x0400520C RID: 21004
	private Image[] Img_MainHeroShow1 = new Image[5];

	// Token: 0x0400520D RID: 21005
	private Image[] Img_MainHeroShow_A = new Image[5];

	// Token: 0x0400520E RID: 21006
	private Image[] Img_MainHeroShow2 = new Image[5];

	// Token: 0x0400520F RID: 21007
	private Image[] Img_MainHeroShow_D = new Image[5];

	// Token: 0x04005210 RID: 21008
	private UIText tmptext;

	// Token: 0x04005211 RID: 21009
	private UIText text_Hint_1;

	// Token: 0x04005212 RID: 21010
	private UIText text_Hint_2;

	// Token: 0x04005213 RID: 21011
	private UIText[] text_tmpStr = new UIText[11];

	// Token: 0x04005214 RID: 21012
	private CString[] Cstr_DS_Heros = new CString[5];

	// Token: 0x04005215 RID: 21013
	private DataManager DM;

	// Token: 0x04005216 RID: 21014
	private GUIManager GUIM;

	// Token: 0x04005217 RID: 21015
	private Font TTFont;

	// Token: 0x04005218 RID: 21016
	private Door door;

	// Token: 0x04005219 RID: 21017
	private UISpritesArray SArray;

	// Token: 0x0400521A RID: 21018
	private Material mMaT;

	// Token: 0x0400521B RID: 21019
	private Material IconMaterial;

	// Token: 0x0400521C RID: 21020
	private Material FrameMaterial;

	// Token: 0x0400521D RID: 21021
	private ScrollPanel m_ScrollPanel;

	// Token: 0x0400521E RID: 21022
	private List<float> tmplist = new List<float>();

	// Token: 0x0400521F RID: 21023
	private List<byte> tmplistInfo_Type = new List<byte>();

	// Token: 0x04005220 RID: 21024
	private List<string> tmplistInfo_DataName = new List<string>();

	// Token: 0x04005221 RID: 21025
	private List<uint> tmplistInfo_Data_L = new List<uint>();

	// Token: 0x04005222 RID: 21026
	private List<uint> tmplistInfo_Data_H = new List<uint>();

	// Token: 0x04005223 RID: 21027
	private List<uint> tmplistInfo_Data_D = new List<uint>();

	// Token: 0x04005224 RID: 21028
	private List<uint> tmplistInfo_Data_ = new List<uint>();

	// Token: 0x04005225 RID: 21029
	private List<byte> tmplistInfo_Data_Icon = new List<byte>();

	// Token: 0x04005226 RID: 21030
	private Image[] Img_HeroBG = new Image[17];

	// Token: 0x04005227 RID: 21031
	private Image[] Img_ItemTitleBG = new Image[17];

	// Token: 0x04005228 RID: 21032
	private Image[] Img_ItemInfoBG = new Image[17];

	// Token: 0x04005229 RID: 21033
	private Image[] Img_Icon_1 = new Image[17];

	// Token: 0x0400522A RID: 21034
	private Image[] Img_Icon_2 = new Image[17];

	// Token: 0x0400522B RID: 21035
	private Image[] Img_Name2_L = new Image[17];

	// Token: 0x0400522C RID: 21036
	private Image[] Img_Name2_R = new Image[17];

	// Token: 0x0400522D RID: 21037
	private Image[] Img_Data2_L = new Image[17];

	// Token: 0x0400522E RID: 21038
	private Image[] Img_Data2_R = new Image[17];

	// Token: 0x0400522F RID: 21039
	private Image[] Img_Hint1 = new Image[17];

	// Token: 0x04005230 RID: 21040
	private Image[] Img_Hint2 = new Image[17];

	// Token: 0x04005231 RID: 21041
	private UIText[] text_Top = new UIText[17];

	// Token: 0x04005232 RID: 21042
	private UIText[] text_Title1 = new UIText[17];

	// Token: 0x04005233 RID: 21043
	private UIText[] text_ATitleTroops = new UIText[17];

	// Token: 0x04005234 RID: 21044
	private UIText[] text_ATitleTraps = new UIText[17];

	// Token: 0x04005235 RID: 21045
	private UIText[] text_Title1_1 = new UIText[17];

	// Token: 0x04005236 RID: 21046
	private UIText[] text_Title1_2 = new UIText[17];

	// Token: 0x04005237 RID: 21047
	private UIText[] text_Title2 = new UIText[17];

	// Token: 0x04005238 RID: 21048
	private UIText[] text_Title2_1 = new UIText[17];

	// Token: 0x04005239 RID: 21049
	private UIText[] text_DTitleTroops = new UIText[17];

	// Token: 0x0400523A RID: 21050
	private UIText[] text_DTitleTraps = new UIText[17];

	// Token: 0x0400523B RID: 21051
	private UIText[] text_InfoName1 = new UIText[17];

	// Token: 0x0400523C RID: 21052
	private UIText[] text_InfoName2 = new UIText[17];

	// Token: 0x0400523D RID: 21053
	private UIText[] text_InfoName3 = new UIText[17];

	// Token: 0x0400523E RID: 21054
	private UIText[] text_InfoName4 = new UIText[17];

	// Token: 0x0400523F RID: 21055
	private UIText[] text_Troops_Name = new UIText[17];

	// Token: 0x04005240 RID: 21056
	private UIText[] text_Item_L = new UIText[17];

	// Token: 0x04005241 RID: 21057
	private UIText[] text_Item_H = new UIText[17];

	// Token: 0x04005242 RID: 21058
	private UIText[] text_Item_D = new UIText[17];

	// Token: 0x04005243 RID: 21059
	private UIText[] text_Icon_1 = new UIText[17];

	// Token: 0x04005244 RID: 21060
	private UIText[] text_Icon_2 = new UIText[17];

	// Token: 0x04005245 RID: 21061
	private UIText[] text_Title4_1 = new UIText[17];

	// Token: 0x04005246 RID: 21062
	private UIText[] text_Title4_2 = new UIText[17];

	// Token: 0x04005247 RID: 21063
	private UIText[] text_Name2_1 = new UIText[17];

	// Token: 0x04005248 RID: 21064
	private UIText[] text_Name2_2 = new UIText[17];

	// Token: 0x04005249 RID: 21065
	private UIText[] text_Name2_3 = new UIText[17];

	// Token: 0x0400524A RID: 21066
	private UIText[] text_Name2_4 = new UIText[17];

	// Token: 0x0400524B RID: 21067
	private UIText[] text_Name2_5 = new UIText[17];

	// Token: 0x0400524C RID: 21068
	private UIText[] text_Data2_1 = new UIText[17];

	// Token: 0x0400524D RID: 21069
	private UIText[] text_Data2_2 = new UIText[17];

	// Token: 0x0400524E RID: 21070
	private UIText[] text_Data2_3 = new UIText[17];

	// Token: 0x0400524F RID: 21071
	private UIText[] text_Data2_4 = new UIText[17];

	// Token: 0x04005250 RID: 21072
	private UIText[] text_Data2_5 = new UIText[17];

	// Token: 0x04005251 RID: 21073
	private string[] ItemInfo = new string[4];

	// Token: 0x04005252 RID: 21074
	private CString[] Cstr_PlayName = new CString[2];

	// Token: 0x04005253 RID: 21075
	private CString[] Cstr_Title = new CString[2];

	// Token: 0x04005254 RID: 21076
	private CString[] Cstr_Title4 = new CString[2];

	// Token: 0x04005255 RID: 21077
	private CString[] Cstr_tmpItem1 = new CString[17];

	// Token: 0x04005256 RID: 21078
	private CString[] Cstr_tmpItem2 = new CString[17];

	// Token: 0x04005257 RID: 21079
	private CString[] Cstr_tmpItem3 = new CString[17];

	// Token: 0x04005258 RID: 21080
	private CString[] Cstr_tmpItem4 = new CString[17];

	// Token: 0x04005259 RID: 21081
	private CString Cstr_Hint;

	// Token: 0x0400525A RID: 21082
	private ushort[] mHeroID_A = new ushort[5];

	// Token: 0x0400525B RID: 21083
	private byte[] mHeroRank_A = new byte[5];

	// Token: 0x0400525C RID: 21084
	private byte[] mHeroStar_A = new byte[5];

	// Token: 0x0400525D RID: 21085
	private ushort[] mHeroID_D = new ushort[5];

	// Token: 0x0400525E RID: 21086
	private byte[] mHeroRank_D = new byte[5];

	// Token: 0x0400525F RID: 21087
	private byte[] mHeroStar_D = new byte[5];

	// Token: 0x04005260 RID: 21088
	private float tmpH;

	// Token: 0x04005261 RID: 21089
	private float ShowMainHeroTime1;

	// Token: 0x04005262 RID: 21090
	private float ShowMainHeroTime2;

	// Token: 0x04005263 RID: 21091
	private bool IsAttack;

	// Token: 0x04005264 RID: 21092
	private Hero tmpHero;

	// Token: 0x04005265 RID: 21093
	private SoldierData tmpSD;

	// Token: 0x04005266 RID: 21094
	private GameObject[] mHead = new GameObject[5];

	// Token: 0x04005267 RID: 21095
	private byte tmpA;

	// Token: 0x04005268 RID: 21096
	private UIButtonHint hint;

	// Token: 0x04005269 RID: 21097
	private UIButtonHint[] m_ItembtnHint = new UIButtonHint[17];

	// Token: 0x0400526A RID: 21098
	private UIButtonHint[] m_ItembtnHint2 = new UIButtonHint[17];
}
