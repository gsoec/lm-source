using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005D1 RID: 1489
public class UILetter_NPCScout : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06001D92 RID: 7570 RVA: 0x0036A5F8 File Offset: 0x003687F8
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.mMaT = this.door.LoadMaterial();
		this.FrameMaterial = this.GUIM.GetFrameMaterial();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		CString cstring = StringManager.Instance.StaticString1024();
		this.Cstr_Coordinate = StringManager.Instance.SpawnString(30);
		this.Cstr_Title = StringManager.Instance.SpawnString(30);
		this.Cstr_Page = StringManager.Instance.SpawnString(30);
		this.Cstr_Country = StringManager.Instance.SpawnString(30);
		this.Cstr_Name = StringManager.Instance.SpawnString(30);
		this.Cstr_H_Coordinate = StringManager.Instance.SpawnString(30);
		for (int i = 0; i < 2; i++)
		{
			this.Cstr_Watch[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_Time[i] = StringManager.Instance.SpawnString(30);
		}
		for (int j = 0; j < 4; j++)
		{
			this.Cstr_Status[j] = StringManager.Instance.SpawnString(30);
		}
		this.BG_T[0] = this.GameT.GetChild(0);
		this.Tmp1 = this.BG_T[0].GetChild(2);
		this.text_Title = this.Tmp1.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.Tmp1 = this.BG_T[0].GetChild(3);
		this.text_Page = this.Tmp1.GetComponent<UIText>();
		this.text_Page.font = this.TTFont;
		this.BG_T[1] = this.GameT.GetChild(1);
		this.Tmp1 = this.BG_T[1].GetChild(1);
		this.btn_Title = this.Tmp1.GetComponent<UIButton>();
		this.btn_Title.m_Handler = this;
		this.btn_Title.m_BtnID1 = 3;
		this.text_Coordinate = this.Tmp1.GetChild(1).GetComponent<UIText>();
		this.text_Coordinate.font = this.TTFont;
		this.text_Watch[0] = this.Tmp1.GetChild(2).GetComponent<UIText>();
		this.text_Watch[0].font = this.TTFont;
		this.Cstr_Watch[0].ClearString();
		this.text_Watch[1] = this.BG_T[1].GetChild(2).GetComponent<UIText>();
		this.text_Watch[1].font = this.TTFont;
		this.text_Watch[1].text = this.DM.mStringTable.GetStringByID(5350u);
		this.text_Time[0] = this.BG_T[1].GetChild(3).GetComponent<UIText>();
		this.text_Time[0].font = this.TTFont;
		this.Cstr_Time[0].ClearString();
		this.text_Time[0].text = this.Cstr_Time[0].ToString();
		this.text_Time[1] = this.BG_T[1].GetChild(4).GetComponent<UIText>();
		this.text_Time[1].font = this.TTFont;
		this.Cstr_Time[1].ClearString();
		this.text_Time[1].text = this.Cstr_Time[1].ToString();
		this.BG_T[2] = this.GameT.GetChild(2);
		this.ImgFrame = this.BG_T[2].GetChild(0).GetComponent<Image>();
		this.ImgRecon = this.BG_T[2].GetChild(1).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.BG_T[2].GetChild(0).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.text_tmpStr[0] = this.BG_T[2].GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(6015u);
		this.ImgMainHero = this.BG_T[2].GetChild(2).GetComponent<Image>();
		this.ImgMainHero.sprite = this.GUIM.LoadFrameSprite("hf000");
		this.ImgMainHero.material = this.FrameMaterial;
		this.ImgMainHeroHead = this.BG_T[2].GetChild(2).GetChild(0).GetComponent<Image>();
		this.ImgMainHeroHead.material = this.GUIM.m_WonderMaterial;
		IgnoreRaycast component = this.ImgMainHero.GetComponent<IgnoreRaycast>();
		if (component != null)
		{
			UnityEngine.Object.DestroyImmediate(component);
		}
		this.btn_Hero = this.ImgMainHero.gameObject.AddComponent<UIButton>();
		this.tmpRCT = this.ImgMainHeroHead.GetComponent<RectTransform>();
		this.tmpRCT.anchorMin = new Vector2(0.0703125f, 0.0703125f);
		this.tmpRCT.anchorMax = new Vector2(0.9296875f, 0.9296875f);
		this.tmpRCT.offsetMin = Vector2.zero;
		this.tmpRCT.offsetMax = Vector2.zero;
		this.tmpRCT.pivot = new Vector2(0.5f, 0.5f);
		this.ImgMainHeroFrame = this.BG_T[2].GetChild(2).GetChild(1).GetComponent<Image>();
		this.ImgMainHeroFrame.material = this.FrameMaterial;
		this.tmpRCT = this.ImgMainHeroFrame.GetComponent<RectTransform>();
		this.tmpRCT.anchorMin = Vector2.zero;
		this.tmpRCT.anchorMax = new Vector2(1f, 1f);
		this.tmpRCT.offsetMin = Vector2.zero;
		this.tmpRCT.offsetMax = Vector2.zero;
		this.ImgMainHeroshow[0] = this.BG_T[2].GetChild(2).GetChild(2).GetComponent<Image>();
		this.ImgMainHeroshow[1] = this.BG_T[2].GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>();
		this.ImgMainHeroHome = this.BG_T[2].GetChild(2).GetChild(3).GetComponent<Image>();
		this.ImgMainHeroHome.gameObject.AddComponent<ArabicItemTextureRot>();
		this.Tmp1 = this.BG_T[2].GetChild(3);
		this.btn_Coordinate = this.Tmp1.GetComponent<UIButton>();
		this.btn_Coordinate.m_Handler = this;
		this.btn_Coordinate.m_BtnID1 = 6;
		this.Tmp2 = this.Tmp1.GetChild(1);
		this.text_H_Coordinate = this.Tmp2.GetComponent<UIText>();
		this.text_H_Coordinate.font = this.TTFont;
		this.Tmp1 = this.BG_T[2].GetChild(4);
		this.text_Top = this.Tmp1.GetComponent<UIText>();
		this.text_Top.font = this.TTFont;
		this.Tmp1 = this.BG_T[2].GetChild(5);
		this.text_Country = this.Tmp1.GetComponent<UIText>();
		this.text_Country.font = this.TTFont;
		this.Cstr_Country.ClearString();
		this.text_Country.text = this.Cstr_Country.ToString();
		this.Tmp1 = this.BG_T[2].GetChild(6);
		this.text_Name = this.Tmp1.GetComponent<UIText>();
		this.text_Name.font = this.TTFont;
		this.Cstr_Name.ClearString();
		this.text_Name.text = this.Cstr_Name.ToString();
		this.Img_T = this.GameT.GetChild(3);
		this.Tmp1 = this.Img_T.GetChild(4);
		this.text_LV = this.Tmp1.GetComponent<UIText>();
		this.text_LV.font = this.TTFont;
		this.text_LV.text = this.DM.mStringTable.GetStringByID(5354u);
		this.StatusT[0] = this.Img_T.GetChild(0);
		this.text_Status[0] = this.StatusT[0].GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_Status[0].font = this.TTFont;
		this.text_Status[0].text = this.DM.mStringTable.GetStringByID(5387u);
		this.text_Status[1] = this.StatusT[0].GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_Status[1].font = this.TTFont;
		this.StatusT[1] = this.Img_T.GetChild(1);
		this.text_Status[2] = this.StatusT[1].GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_Status[2].font = this.TTFont;
		this.StatusT[2] = this.Img_T.GetChild(2);
		this.text_Status[3] = this.StatusT[2].GetChild(2).GetComponent<UIText>();
		this.text_Status[3].font = this.TTFont;
		this.btn_ReconCoordinate = this.StatusT[2].GetChild(1).GetComponent<UIButton>();
		this.btn_ReconCoordinate.m_Handler = this;
		this.btn_ReconCoordinate.m_BtnID1 = 7;
		this.text_Status[4] = this.StatusT[2].GetChild(1).GetChild(1).GetComponent<UIText>();
		this.text_Status[4].font = this.TTFont;
		this.text_tmpStr[1] = this.StatusT[2].GetChild(1).GetChild(2).GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(6004u);
		this.StatusT[3] = this.Img_T.GetChild(3);
		this.ImgNpcItem = this.StatusT[3].GetChild(0).GetChild(1).GetComponent<Image>();
		this.text_Status[5] = this.StatusT[3].GetChild(0).GetChild(2).GetComponent<UIText>();
		this.text_Status[5].font = this.TTFont;
		this.text_Status[5].text = this.DM.mStringTable.GetStringByID(9595u);
		this.text_Status[6] = this.StatusT[3].GetChild(0).GetChild(3).GetComponent<UIText>();
		this.text_Status[6].font = this.TTFont;
		this.text_Status[6].text = "2";
		this.text_Status[7] = this.StatusT[3].GetChild(1).GetChild(1).GetComponent<UIText>();
		this.text_Status[7].font = this.TTFont;
		this.text_Status[8] = this.StatusT[3].GetChild(1).GetChild(2).GetComponent<UIText>();
		this.text_Status[8].font = this.TTFont;
		this.CustomPanelT = this.GameT.GetChild(4);
		this.Tmp1 = this.GameT.GetChild(5);
		this.btn_Delete = this.Tmp1.GetComponent<UIButton>();
		this.btn_Delete.m_Handler = this;
		this.btn_Delete.m_BtnID1 = 4;
		this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
		this.btn_Delete.transition = Selectable.Transition.None;
		this.Tmp1 = this.GameT.GetChild(6);
		this.btn_Collect = this.Tmp1.GetComponent<UIButton>();
		this.btn_Collect.m_Handler = this;
		this.btn_Collect.m_BtnID1 = 5;
		this.btn_Collect.m_EffectType = e_EffectType.e_Scale;
		this.btn_Collect.transition = Selectable.Transition.None;
		float x = this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x;
		this.tempL = (this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x - 853f) / 2f;
		this.PreviousT = this.GameT.GetChild(7);
		this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
		this.btn_Previous.m_Handler = this;
		this.btn_Previous.m_BtnID1 = 1;
		this.btn_Previous.m_EffectType = e_EffectType.e_Scale;
		this.btn_Previous.transition = Selectable.Transition.None;
		this.NextT = this.GameT.GetChild(8);
		this.btn_Next = this.NextT.GetComponent<UIButton>();
		this.btn_Next.m_Handler = this;
		this.btn_Next.m_BtnID1 = 2;
		this.btn_Next.m_EffectType = e_EffectType.e_Scale;
		this.btn_Next.transition = Selectable.Transition.None;
		if (this.tempL > 0f && this.NextT.localPosition.x + this.tempL > x / 2f)
		{
			this.tempL = x / 2f - this.NextT.localPosition.x;
		}
		this.MoveTime1 = this.NextT.localPosition.x + this.tempL;
		this.MoveTime2 = this.PreviousT.localPosition.x - this.tempL;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.MoveTime1 -= this.GUIM.IPhoneX_DeltaX;
			this.MoveTime2 += this.GUIM.IPhoneX_DeltaX;
		}
		this.Vec3Instance.Set(this.MoveTime1, this.NextT.localPosition.y, this.NextT.localPosition.z);
		this.NextT.localPosition = this.Vec3Instance;
		this.Vec3Instance.Set(this.MoveTime2, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
		this.PreviousT.localPosition = this.Vec3Instance;
		this.btn_Previous.gameObject.SetActive(true);
		this.btn_Next.gameObject.SetActive(true);
		this.Tmp = this.GameT.GetChild(9);
		this.tmpImg = this.Tmp.GetComponent<Image>();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_close_base");
		this.tmpImg.sprite = this.door.LoadSprite(cstring);
		this.tmpImg.material = this.mMaT;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.Tmp = this.GameT.GetChild(9).GetChild(0);
		this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_close");
		this.btn_EXIT.image.sprite = this.door.LoadSprite(cstring);
		this.btn_EXIT.image.material = this.mMaT;
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.SetDataInfo();
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001D93 RID: 7571 RVA: 0x0036B5D0 File Offset: 0x003697D0
	public void SetDataInfo()
	{
		this.Favor.Serial = this.DM.OpenMail.Serial;
		this.Favor.Type = this.DM.OpenMail.Type;
		this.Favor.Kind = this.DM.OpenMail.Kind;
		if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
		{
			this.Report = this.Favor.Combat;
			if (!this.Report.BeRead)
			{
				if (this.Favor.Kind == MailType.EMAIL_BATTLE)
				{
					this.DM.BattleReportRead(this.Report.SerialID, false);
				}
				else
				{
					this.DM.FavorReportRead(this.Report.SerialID, false);
				}
			}
			this.Cstr_Page.ClearString();
			this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
			switch (this.DM.OpenMail.Kind)
			{
			case MailType.EMAIL_BATTLE:
				this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
				this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
				break;
			case MailType.EMAIL_FAVORY:
				this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
				this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
				break;
			}
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Page.AppendFormat("{1}/{0}");
			}
			else
			{
				this.Cstr_Page.AppendFormat("{0}/{1}");
			}
			this.text_Page.text = this.Cstr_Page.ToString();
			this.text_Page.SetAllDirty();
			this.text_Page.cachedTextGenerator.Invalidate();
			this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
			this.text_Time[0].SetAllDirty();
			this.text_Time[0].cachedTextGenerator.Invalidate();
			this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
			this.text_Time[1].SetAllDirty();
			this.text_Time[1].cachedTextGenerator.Invalidate();
			this.btn_Previous.gameObject.SetActive(true);
			this.btn_Next.gameObject.SetActive(true);
			if (this.MaxLetterNum > 1)
			{
				if (this.Report.Index + 1 == 1)
				{
					this.btn_Previous.gameObject.SetActive(false);
					if (!this.btn_Next.IsActive())
					{
						this.btn_Next.gameObject.SetActive(true);
					}
				}
				if ((int)(this.Report.Index + 1) == this.MaxLetterNum)
				{
					this.btn_Next.gameObject.SetActive(false);
					if (!this.btn_Previous.IsActive())
					{
						this.btn_Previous.gameObject.SetActive(true);
					}
				}
			}
			else
			{
				this.btn_Previous.gameObject.SetActive(false);
				this.btn_Next.gameObject.SetActive(false);
			}
			CString cstring = StringManager.Instance.StaticString1024();
			this.bOpen = true;
			if (this.Report.NPCScout.ScoutResult == 1)
			{
				this.mStatus = 1;
			}
			this.bCity = false;
			if (this.mStatus == 0 && this.Report.NPCScout.CombatPointKind == POINT_KIND.PK_CITY)
			{
				this.DM.SetScoutData(this.Report.NPCScout.ScoutLevel, this.Report.NPCScout.ScoutContent, this.Report.NPCScout.ScoutContentLen, 3);
				this.bCity = true;
			}
			this.Cstr_Title.ClearString();
			this.Cstr_Name.ClearString();
			this.Cstr_Country.ClearString();
			this.ImgMainHeroshow[0].gameObject.SetActive(false);
			this.mWatchLv = (int)this.Report.NPCScout.ScoutLevel;
			this.btn_Title.gameObject.SetActive(true);
			this.Cstr_Watch[0].ClearString();
			this.Cstr_Watch[0].StringToFormat(this.GUIM.GetPointName_Letter(this.Report.NPCScout.CombatPointKind));
			this.Cstr_Watch[0].StringToFormat(this.DM.mStringTable.GetStringByID(5347u));
			this.Cstr_Watch[0].AppendFormat("{0} {1}");
			this.text_Watch[0].text = this.Cstr_Watch[0].ToString();
			this.text_Watch[0].SetAllDirty();
			this.text_Watch[0].cachedTextGenerator.Invalidate();
			this.text_Watch[1].gameObject.SetActive(false);
			this.ImgRecon.gameObject.SetActive(false);
			if (this.mStatus == 0 || (this.mWatchLv >= 4 && this.mStatus == 1))
			{
				this.text_Name.gameObject.SetActive(true);
				this.Cstr_Name.ClearString();
				this.Cstr_Name.IntToFormat((long)this.Report.NPCScout.NPCLevel, 1, false);
				this.Cstr_Name.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021u));
			}
			else
			{
				this.text_Name.gameObject.SetActive(false);
			}
			if (this.mWatchLv >= 5)
			{
				this.text_Top.gameObject.SetActive(false);
				this.btn_Coordinate.gameObject.SetActive(true);
				this.ImgMainHeroHome.gameObject.SetActive(false);
				this.ImgMainHero.gameObject.SetActive(true);
				this.ImgMainHeroHead.sprite = this.GUIM.NpcHead;
				this.ImgMainHeroHead.material = this.GUIM.m_WonderMaterial;
				cstring.ClearString();
				cstring.Append("hf011");
				this.ImgMainHeroFrame.sprite = this.GUIM.LoadFrameSprite(cstring);
			}
			else
			{
				this.ImgFrame.gameObject.SetActive(true);
				this.ImgMainHero.gameObject.SetActive(false);
				this.btn_Coordinate.gameObject.SetActive(false);
				this.text_Top.gameObject.SetActive(false);
				this.ImgMainHeroHome.gameObject.SetActive(false);
			}
			if (this.Report.NPCScout.CombatPointKind != POINT_KIND.PK_YOLK)
			{
				this.Cstr_Title.Append(this.DM.mStringTable.GetStringByID(6027u));
				if (this.Report.NPCScout.ScoutResult == 0)
				{
					this.Cstr_Name.ClearString();
					this.Cstr_Name.IntToFormat((long)this.Report.NPCScout.NPCLevel, 1, false);
					this.Cstr_Name.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021u));
					this.Cstr_Title.Append(this.Cstr_Name);
				}
			}
			else if (this.mStatus == 0)
			{
				this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7259u));
			}
			this.text_Title.text = this.Cstr_Title.ToString();
			this.tmpRCT = this.BG_T[1].GetChild(1).GetComponent<RectTransform>();
			this.Cstr_Coordinate.ClearString();
			if (this.Report.NPCScout.CombatPointKind == POINT_KIND.PK_CITY)
			{
				this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.NPCScout.CombatlZone, this.Report.NPCScout.CombatPoint));
			}
			else
			{
				this.tmpV = Vector2.zero;
			}
			this.Cstr_Coordinate.IntToFormat((long)this.Report.NPCScout.KingdomID, 1, false);
			this.Cstr_Coordinate.IntToFormat((long)((int)this.tmpV.x), 1, false);
			this.Cstr_Coordinate.IntToFormat((long)((int)this.tmpV.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Coordinate.AppendFormat("{2}:Y {1}:X {0}:K");
			}
			else
			{
				this.Cstr_Coordinate.AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
			}
			this.text_Coordinate.text = this.Cstr_Coordinate.ToString();
			this.text_Coordinate.SetAllDirty();
			this.text_Coordinate.cachedTextGenerator.Invalidate();
			this.text_Coordinate.cachedTextGeneratorForLayout.Invalidate();
			this.tmpRCT.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
			this.tmpRCT = this.BG_T[1].GetChild(1).GetChild(0).GetComponent<RectTransform>();
			this.tmpRCT.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
			this.tmpRCT = this.BG_T[1].GetChild(1).GetChild(1).GetComponent<RectTransform>();
			this.tmpRCT.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
			this.tmpRCT = this.BG_T[1].GetChild(1).GetChild(2).GetComponent<RectTransform>();
			if (this.GUIM.IsArabic)
			{
				Vector2 anchoredPosition = this.text_Watch[0].ArabicFixPos(new Vector2(this.text_Coordinate.preferredWidth + 10f, this.tmpRCT.anchoredPosition.y));
				this.tmpRCT.anchoredPosition = anchoredPosition;
			}
			else
			{
				this.tmpRCT.anchoredPosition = new Vector2(this.text_Coordinate.preferredWidth + 10f, this.tmpRCT.anchoredPosition.y);
			}
			this.tmpRCT = this.BG_T[2].GetChild(3).GetComponent<RectTransform>();
			this.Cstr_H_Coordinate.ClearString();
			this.Cstr_Coordinate.IntToFormat((long)this.Report.NPCScout.KingdomID, 1, false);
			this.Cstr_Coordinate.IntToFormat((long)((int)this.tmpV.x), 1, false);
			this.Cstr_Coordinate.IntToFormat((long)((int)this.tmpV.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_H_Coordinate.AppendFormat("{2}:Y {1}:X {0}:K");
			}
			else
			{
				this.Cstr_H_Coordinate.AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
			}
			this.text_H_Coordinate.text = this.Cstr_H_Coordinate.ToString();
			this.text_H_Coordinate.gameObject.SetActive(true);
			this.text_H_Coordinate.SetAllDirty();
			this.text_H_Coordinate.cachedTextGenerator.Invalidate();
			this.text_H_Coordinate.cachedTextGeneratorForLayout.Invalidate();
			this.tmpRCT.sizeDelta = new Vector2(this.text_H_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
			this.tmpRCT = this.BG_T[2].GetChild(3).GetChild(0).GetComponent<RectTransform>();
			this.tmpRCT.sizeDelta = new Vector2(this.text_H_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
			this.tmpRCT = this.BG_T[2].GetChild(3).GetChild(1).GetComponent<RectTransform>();
			this.tmpRCT.sizeDelta = new Vector2(this.text_H_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
			this.tmpRCT = this.BG_T[2].GetChild(3).GetChild(2).GetComponent<RectTransform>();
			this.tmpRCT.sizeDelta = new Vector2(this.text_H_Coordinate.preferredWidth, this.tmpRCT.sizeDelta.y);
			if (this.tmpPanel == null)
			{
				this.tmpPanel = this.CustomPanelT.gameObject.AddComponent<CustomPanel>();
			}
			this.CustomPanelT.gameObject.SetActive(true);
			if (this.GUIM.IsArabic)
			{
				this.ImgMainHeroHead.rectTransform.localScale = new Vector3(1f, 1f, 1f);
			}
			this._DataIdx.Clear();
			if (this.mStatus == 1)
			{
				this.text_LV.gameObject.SetActive(false);
				this.Img_T.gameObject.SetActive(true);
				this.tmpPanel.RewardID = this.Report.NPCScout.Reward;
				this.tmpPanel.UpDownHandle = this;
				this._DataIdx.Add(40);
				this.text_Status[0].text = this.DM.mStringTable.GetStringByID(5387u);
				this.Cstr_Status[0].ClearString();
				switch (this.Report.NPCScout.ScoutResult)
				{
				case 1:
					this.tmpPanel.InfoID = (uint)this.Report.NPCScout.CombatPointKind;
					this._DataIdx.Add(42);
					break;
				case 2:
					this.Cstr_Status[0].Append(this.DM.mStringTable.GetStringByID(6068u));
					if (this.Report.NPCScout.CombatPointKind == POINT_KIND.PK_YOLK)
					{
						this.Cstr_Title.Append(this.DM.mStringTable.GetStringByID(6027u));
						this.text_Title.text = this.Cstr_Title.ToString();
					}
					break;
				case 3:
					this.Cstr_Status[0].Append(this.DM.mStringTable.GetStringByID(6069u));
					break;
				case 4:
					this.StatusT[0].gameObject.SetActive(false);
					this.StatusT[3].gameObject.SetActive(true);
					this.text_Status[7].text = this.DM.mStringTable.GetStringByID(5387u);
					this.Cstr_Status[0].StringToFormat(this.GUIM.GetPointName_Letter(this.Report.NPCScout.CombatPointKind));
					this.Cstr_Status[0].AppendFormat(this.DM.mStringTable.GetStringByID(5388u));
					this.text_Status[8].text = this.Cstr_Status[0].ToString();
					this.text_Status[8].SetAllDirty();
					this.text_Status[8].cachedTextGenerator.Invalidate();
					break;
				}
				this.text_Status[1].text = this.Cstr_Status[0].ToString();
				this.text_Status[1].SetAllDirty();
				this.text_Status[1].cachedTextGenerator.Invalidate();
			}
			else
			{
				this._DataIdx.Clear();
				this.Img_T.gameObject.SetActive(false);
				this.StatusT[1].gameObject.SetActive(false);
				this.text_Name.gameObject.SetActive(true);
				this.tmpPanel.RewardID = this.Report.NPCScout.Reward;
				this.tmpPanel.UpDownHandle = this;
				this._DataIdx.Add(40);
				if (this.mWatchLv >= 8)
				{
					this._DataIdx.Add(41);
				}
				if (this.mWatchLv >= 10 && (this.bCity || this.Report.NPCScout.CombatPointKind == POINT_KIND.PK_YOLK))
				{
					this._DataIdx.Add(5);
				}
				if (this.bCity || this.Report.NPCScout.CombatPointKind == POINT_KIND.PK_NPC)
				{
					if (this.mWatchLv >= 6)
					{
						this._DataIdx.Add(6);
					}
					if (this.mWatchLv >= 2)
					{
						this._DataIdx.Add(7);
					}
				}
				this._DataIdx.Add(8);
				if (this.mWatchLv < 10)
				{
					this._DataIdx.Add(4);
				}
			}
			this.text_Status[0].SetAllDirty();
			this.text_Status[0].cachedTextGenerator.Invalidate();
			this.text_Title.SetAllDirty();
			this.text_Title.cachedTextGenerator.Invalidate();
			this.text_Country.text = this.Cstr_Country.ToString();
			this.text_Country.SetAllDirty();
			this.text_Country.cachedTextGenerator.Invalidate();
			this.text_Name.text = this.Cstr_Name.ToString();
			this.text_Name.SetAllDirty();
			this.text_Name.cachedTextGenerator.Invalidate();
			return;
		}
		this.Report = null;
		this.door.CloseMenu(false);
	}

	// Token: 0x06001D94 RID: 7572 RVA: 0x0036C780 File Offset: 0x0036A980
	public override void OnClose()
	{
		if (this.Cstr_Coordinate != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Coordinate);
		}
		if (this.Cstr_Title != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Title);
		}
		if (this.Cstr_Page != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Page);
		}
		if (this.Cstr_Country != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Country);
		}
		if (this.Cstr_Name != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Name);
		}
		if (this.Cstr_H_Coordinate != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_H_Coordinate);
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.Cstr_Time[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Time[i]);
			}
			if (this.Cstr_Watch[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Watch[i]);
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (this.Cstr_Status[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Status[j]);
			}
		}
	}

	// Token: 0x06001D95 RID: 7573 RVA: 0x0036C8BC File Offset: 0x0036AABC
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 1:
			this.Open_NP_Mail(false);
			break;
		case 2:
			this.Open_NP_Mail(true);
			break;
		case 3:
			this.door.GoToPointCode(this.Report.NPCScout.KingdomID, this.Report.NPCScout.CombatlZone, this.Report.NPCScout.CombatPoint, 0);
			break;
		case 4:
			if (this.DM.BattleReportDelete(this.Report.SerialID))
			{
				this.door.CloseMenu(false);
			}
			break;
		case 5:
			if (this.Favor.Kind == MailType.EMAIL_FAVORY)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6100u), 255, true);
				return;
			}
			this.DM.BattleReportSave(this.Report.SerialID);
			break;
		case 6:
			if (this.mStatus < 2)
			{
				if (this.Report.NPCScout.CombatPointKind != POINT_KIND.PK_YOLK)
				{
					this.door.GoToPointCode(this.Report.NPCScout.KingdomID, this.Report.NPCScout.CombatlZone, this.Report.NPCScout.CombatPoint, 0);
				}
				else
				{
					this.door.GoToWonder(this.Report.NPCScout.KingdomID, this.Report.NPCScout.CombatPoint);
				}
			}
			else
			{
				this.door.GoToPointCode(this.Report.NPCScout.KingdomID, this.Report.NPCScout.CombatlZone, this.Report.NPCScout.CombatPoint, 0);
			}
			break;
		case 7:
			if (this.Report.Recon.CombatPointKind != POINT_KIND.PK_YOLK)
			{
				this.door.GoToPointCode(this.Report.Recon.KingdomID, this.Report.Recon.CombatlZone, this.Report.Recon.CombatPoint, 0);
			}
			else
			{
				this.door.GoToWonder(this.Report.Recon.KingdomID, this.Report.Recon.CombatPoint);
			}
			break;
		}
	}

	// Token: 0x06001D96 RID: 7574 RVA: 0x0036CB5C File Offset: 0x0036AD5C
	public void Open_NP_Mail(bool bNext)
	{
		if (this.DM.MailReportGet(ref this.Favor, bNext))
		{
			switch (this.Favor.Type)
			{
			case MailType.EMAIL_SYSTEM:
				this.DM.OpenMail.Serial = this.Favor.Serial;
				this.DM.OpenMail.Type = this.Favor.Type;
				this.DM.OpenMail.Kind = this.Favor.Kind;
				this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
				break;
			case MailType.EMAIL_BATTLE:
				this.DM.OpenMail.Serial = this.Favor.Serial;
				this.DM.OpenMail.Type = this.Favor.Type;
				this.DM.OpenMail.Kind = this.Favor.Kind;
				switch (this.Favor.Combat.Type)
				{
				case CombatCollectReport.CCR_BATTLE:
				case CombatCollectReport.CCR_NPCCOMBAT:
					this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
					break;
				case CombatCollectReport.CCR_RESOURCE:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Resources, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
					break;
				case CombatCollectReport.CCR_COLLECT:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Collection, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
					break;
				case CombatCollectReport.CCR_SCOUT:
					this.door.CloseMenu(false);
					this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 0, 0, false);
					break;
				case CombatCollectReport.CCR_RECON:
					this.door.CloseMenu(false);
					this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon, 0, 0, false);
					break;
				case CombatCollectReport.CCR_MONSTER:
					if (this.Favor.Combat.Monster.Result < 2 || this.Favor.Combat.Monster.Result > 3)
					{
						this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1, 0, false);
					}
					else
					{
						this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
					}
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
					break;
				case CombatCollectReport.CCR_NPCSCOUT:
					this.CustomPanelT.gameObject.SetActive(false);
					this.Img_T.gameObject.SetActive(false);
					if (this.mStatus >= 1)
					{
						int num = this.mStatus;
						if (this.mStatus == 4)
						{
							num = 1;
						}
						else if (this.mStatus == 5)
						{
							num = 4;
						}
						this.StatusT[num - 1].gameObject.SetActive(false);
					}
					if (this.Favor.Combat.NPCScout.ScoutLevel != 0)
					{
						this.mStatus = 0;
					}
					else
					{
						this.mStatus = 1;
					}
					this.SetDataInfo();
					break;
				case CombatCollectReport.CCR_PETREPORT:
					this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
					break;
				}
				break;
			case MailType.EMAIL_LETTER:
				this.DM.OpenMail.Serial = this.Favor.Serial;
				this.DM.OpenMail.Type = this.Favor.Type;
				this.DM.OpenMail.Kind = this.Favor.Kind;
				this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_NPCScout);
				break;
			}
		}
	}

	// Token: 0x06001D97 RID: 7575 RVA: 0x0036CF20 File Offset: 0x0036B120
	public void OnButtonDown(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 277f, 20, (int)sender.Parm1, 0, Vector2.zero, UIButtonHint.ePosition.Original);
	}

	// Token: 0x06001D98 RID: 7576 RVA: 0x0036CF54 File Offset: 0x0036B154
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(false);
	}

	// Token: 0x06001D99 RID: 7577 RVA: 0x0036CF68 File Offset: 0x0036B168
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 2)
		{
			if (!this.DM.MailReportGet(ref this.Favor))
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x06001D9A RID: 7578 RVA: 0x0036CFAC File Offset: 0x0036B1AC
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Mailing)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					if (this.tmpPanel != null)
					{
						this.tmpPanel.Refresh_FontTexture();
					}
					this.Refresh_FontTexture();
				}
			}
			else
			{
				if (!this.DM.MailReportGet(ref this.Favor))
				{
					this.door.CloseMenu(false);
				}
				this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
				this.Cstr_Page.ClearString();
				switch (this.DM.OpenMail.Kind)
				{
				case MailType.EMAIL_BATTLE:
					this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
					this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
					break;
				case MailType.EMAIL_FAVORY:
					this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
					this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
					break;
				}
				if (this.GUIM.IsArabic)
				{
					this.Cstr_Page.AppendFormat("{1}/{0}");
				}
				else
				{
					this.Cstr_Page.AppendFormat("{0}/{1}");
				}
				this.text_Page.text = this.Cstr_Page.ToString();
				this.text_Page.SetAllDirty();
				this.text_Page.cachedTextGenerator.Invalidate();
				if (this.MaxLetterNum > 1)
				{
					if (this.Report.Index + 1 == 1)
					{
						this.btn_Previous.gameObject.SetActive(false);
					}
					else
					{
						this.btn_Previous.gameObject.SetActive(true);
					}
					if ((int)(this.Report.Index + 1) == this.MaxLetterNum)
					{
						this.btn_Next.gameObject.SetActive(false);
					}
					else
					{
						this.btn_Next.gameObject.SetActive(true);
					}
				}
				else
				{
					this.btn_Previous.gameObject.SetActive(false);
					this.btn_Next.gameObject.SetActive(false);
				}
			}
			break;
		case NetworkNews.Refresh_Asset:
			if (this.mStatus == 0 && this.tmpPanel != null && meg[1] == 0 && meg[2] == 1)
			{
				this.tmpPanel.SetNpcImg();
			}
			break;
		}
	}

	// Token: 0x06001D9B RID: 7579 RVA: 0x0036D240 File Offset: 0x0036B440
	public void Refresh_FontTexture()
	{
		if (this.text_Coordinate != null && this.text_Coordinate.enabled)
		{
			this.text_Coordinate.enabled = false;
			this.text_Coordinate.enabled = true;
		}
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Page != null && this.text_Page.enabled)
		{
			this.text_Page.enabled = false;
			this.text_Page.enabled = true;
		}
		if (this.text_Top != null && this.text_Top.enabled)
		{
			this.text_Top.enabled = false;
			this.text_Top.enabled = true;
		}
		if (this.text_Country != null && this.text_Country.enabled)
		{
			this.text_Country.enabled = false;
			this.text_Country.enabled = true;
		}
		if (this.text_Name != null && this.text_Name.enabled)
		{
			this.text_Name.enabled = false;
			this.text_Name.enabled = true;
		}
		if (this.text_H_Coordinate != null && this.text_H_Coordinate.enabled)
		{
			this.text_H_Coordinate.enabled = false;
			this.text_H_Coordinate.enabled = true;
		}
		if (this.text_LV != null && this.text_LV.enabled)
		{
			this.text_LV.enabled = false;
			this.text_LV.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_tmpStr[i] != null && this.text_tmpStr[i].enabled)
			{
				this.text_tmpStr[i].enabled = false;
				this.text_tmpStr[i].enabled = true;
			}
			if (this.text_Watch[i] != null && this.text_Watch[i].enabled)
			{
				this.text_Watch[i].enabled = false;
				this.text_Watch[i].enabled = true;
			}
			if (this.text_Time[i] != null && this.text_Time[i].enabled)
			{
				this.text_Time[i].enabled = false;
				this.text_Time[i].enabled = true;
			}
		}
		for (int j = 0; j < 9; j++)
		{
			if (this.text_Status[j] != null && this.text_Status[j].enabled)
			{
				this.text_Status[j].enabled = false;
				this.text_Status[j].enabled = true;
			}
		}
	}

	// Token: 0x06001D9C RID: 7580 RVA: 0x0036D540 File Offset: 0x0036B740
	private void Start()
	{
	}

	// Token: 0x06001D9D RID: 7581 RVA: 0x0036D544 File Offset: 0x0036B744
	private void Update()
	{
		this.TmpTime += Time.smoothDeltaTime * 40f;
		if (this.TmpTime >= 40f)
		{
			this.TmpTime = 0f;
		}
		float num = (this.TmpTime <= 20f) ? this.TmpTime : (40f - this.TmpTime);
		if (num < 0f)
		{
			num = 0f;
		}
		if (this.NextT != null)
		{
			this.Vec3Instance.Set(this.MoveTime1 - num, this.NextT.localPosition.y, this.NextT.localPosition.z);
			this.NextT.localPosition = this.Vec3Instance;
		}
		if (this.PreviousT != null)
		{
			this.Vec3Instance.Set(this.MoveTime2 + num, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
			this.PreviousT.localPosition = this.Vec3Instance;
		}
		if (this.ImgMainHeroshow[0] != null && this.ImgMainHeroshow[0].IsActive())
		{
			this.ShowMainHeroTime1 += Time.smoothDeltaTime;
			if (this.ShowMainHeroTime1 >= 0f)
			{
				if (this.ShowMainHeroTime1 >= 2f)
				{
					this.ShowMainHeroTime1 = 0f;
				}
				float a = (this.ShowMainHeroTime1 <= 1f) ? this.ShowMainHeroTime1 : (2f - this.ShowMainHeroTime1);
				this.ImgMainHeroshow[1].color = new Color(1f, 1f, 1f, a);
			}
		}
		if (this.bOpen)
		{
			if (this.mStatus <= 1 && this.Report != null)
			{
				this.tmpPanel.Report = this.Report;
				if (this.bFirst)
				{
					this.tmpPanel.SetPanelData(this._DataIdx, false, this.bFirst, this.mWatchLv, 5, 332f);
					this.bFirst = false;
				}
				else
				{
					this.tmpPanel.SetPanelData(this._DataIdx, false, this.bFirst, this.mWatchLv, 5, 332f);
				}
				this.tmpPanel.InitScrollPanel();
				UIButtonHint.scrollRect = this.tmpPanel.transform.GetChild(0).GetChild(0).GetComponent<CScrollRect>();
			}
			this.bOpen = false;
		}
	}

	// Token: 0x04005B19 RID: 23321
	private DataManager DM;

	// Token: 0x04005B1A RID: 23322
	private GUIManager GUIM;

	// Token: 0x04005B1B RID: 23323
	private Font TTFont;

	// Token: 0x04005B1C RID: 23324
	private Door door;

	// Token: 0x04005B1D RID: 23325
	private Transform GameT;

	// Token: 0x04005B1E RID: 23326
	private Transform Tmp;

	// Token: 0x04005B1F RID: 23327
	private Transform Tmp1;

	// Token: 0x04005B20 RID: 23328
	private Transform Tmp2;

	// Token: 0x04005B21 RID: 23329
	private Transform PreviousT;

	// Token: 0x04005B22 RID: 23330
	private Transform NextT;

	// Token: 0x04005B23 RID: 23331
	private Transform Img_T;

	// Token: 0x04005B24 RID: 23332
	private Transform[] BG_T = new Transform[3];

	// Token: 0x04005B25 RID: 23333
	private Transform[] StatusT = new Transform[4];

	// Token: 0x04005B26 RID: 23334
	private Transform CustomPanelT;

	// Token: 0x04005B27 RID: 23335
	private RectTransform tmpRCT;

	// Token: 0x04005B28 RID: 23336
	private UIButton btn_EXIT;

	// Token: 0x04005B29 RID: 23337
	private UIButton btn_Previous;

	// Token: 0x04005B2A RID: 23338
	private UIButton btn_Next;

	// Token: 0x04005B2B RID: 23339
	private UIButton btn_Title;

	// Token: 0x04005B2C RID: 23340
	private UIButton btn_Delete;

	// Token: 0x04005B2D RID: 23341
	private UIButton btn_Collect;

	// Token: 0x04005B2E RID: 23342
	private UIButton btn_Coordinate;

	// Token: 0x04005B2F RID: 23343
	private UIButton btn_ReconCoordinate;

	// Token: 0x04005B30 RID: 23344
	private UIButton btn_Hero;

	// Token: 0x04005B31 RID: 23345
	private Image tmpImg;

	// Token: 0x04005B32 RID: 23346
	private Image ImgFrame;

	// Token: 0x04005B33 RID: 23347
	private Image ImgRecon;

	// Token: 0x04005B34 RID: 23348
	private Image ImgMainHero;

	// Token: 0x04005B35 RID: 23349
	private Image ImgMainHeroHead;

	// Token: 0x04005B36 RID: 23350
	private Image ImgMainHeroFrame;

	// Token: 0x04005B37 RID: 23351
	private Image ImgMainHeroHome;

	// Token: 0x04005B38 RID: 23352
	private Image[] ImgMainHeroshow = new Image[2];

	// Token: 0x04005B39 RID: 23353
	private Image ImgNpcItem;

	// Token: 0x04005B3A RID: 23354
	private UIText text_Coordinate;

	// Token: 0x04005B3B RID: 23355
	private UIText[] text_tmpStr = new UIText[2];

	// Token: 0x04005B3C RID: 23356
	private UIText[] text_Watch = new UIText[2];

	// Token: 0x04005B3D RID: 23357
	private UIText[] text_Time = new UIText[2];

	// Token: 0x04005B3E RID: 23358
	private UIText text_Title;

	// Token: 0x04005B3F RID: 23359
	private UIText text_Page;

	// Token: 0x04005B40 RID: 23360
	private UIText text_Top;

	// Token: 0x04005B41 RID: 23361
	private UIText text_Country;

	// Token: 0x04005B42 RID: 23362
	private UIText text_Name;

	// Token: 0x04005B43 RID: 23363
	private UIText text_H_Coordinate;

	// Token: 0x04005B44 RID: 23364
	private UIText text_LV;

	// Token: 0x04005B45 RID: 23365
	private UIText[] text_Status = new UIText[9];

	// Token: 0x04005B46 RID: 23366
	private CString Cstr_Coordinate;

	// Token: 0x04005B47 RID: 23367
	private CString[] Cstr_Watch = new CString[2];

	// Token: 0x04005B48 RID: 23368
	private CString[] Cstr_Time = new CString[2];

	// Token: 0x04005B49 RID: 23369
	private CString Cstr_Title;

	// Token: 0x04005B4A RID: 23370
	private CString Cstr_Page;

	// Token: 0x04005B4B RID: 23371
	private CString Cstr_Country;

	// Token: 0x04005B4C RID: 23372
	private CString Cstr_Name;

	// Token: 0x04005B4D RID: 23373
	private CString Cstr_H_Coordinate;

	// Token: 0x04005B4E RID: 23374
	private CString[] Cstr_Status = new CString[4];

	// Token: 0x04005B4F RID: 23375
	private Material mMaT;

	// Token: 0x04005B50 RID: 23376
	private Material FrameMaterial;

	// Token: 0x04005B51 RID: 23377
	private List<int> _DataIdx = new List<int>();

	// Token: 0x04005B52 RID: 23378
	private CustomPanel tmpPanel;

	// Token: 0x04005B53 RID: 23379
	private int mWatchLv;

	// Token: 0x04005B54 RID: 23380
	private bool bOpen = true;

	// Token: 0x04005B55 RID: 23381
	private bool bFirst = true;

	// Token: 0x04005B56 RID: 23382
	private int mStatus;

	// Token: 0x04005B57 RID: 23383
	private bool bCity = true;

	// Token: 0x04005B58 RID: 23384
	private int MaxLetterNum;

	// Token: 0x04005B59 RID: 23385
	private float tempL;

	// Token: 0x04005B5A RID: 23386
	private float MoveTime1;

	// Token: 0x04005B5B RID: 23387
	private float MoveTime2;

	// Token: 0x04005B5C RID: 23388
	private float TmpTime;

	// Token: 0x04005B5D RID: 23389
	private float ShowMainHeroTime1;

	// Token: 0x04005B5E RID: 23390
	private Vector3 Vec3Instance;

	// Token: 0x04005B5F RID: 23391
	private Vector2 tmpV;

	// Token: 0x04005B60 RID: 23392
	private MyFavorite Favor = new MyFavorite(MailType.EMAIL_MAX, 0u);

	// Token: 0x04005B61 RID: 23393
	private CombatReport Report;

	// Token: 0x04005B62 RID: 23394
	private UISpritesArray SArray;
}
