using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005D5 RID: 1493
public class UILetter_Watchtower : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001DAD RID: 7597 RVA: 0x00370084 File Offset: 0x0036E284
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
		this.mStatus = arg1;
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
		this.ImgMainHeroHead.material = this.IconMaterial;
		IgnoreRaycast component = this.ImgMainHero.GetComponent<IgnoreRaycast>();
		if (component != null)
		{
			UnityEngine.Object.DestroyImmediate(component);
		}
		this.btn_Hero = this.ImgMainHero.gameObject.AddComponent<UIButton>();
		this.btn_Hero.m_EffectType = e_EffectType.e_Scale;
		this.btn_Hero.transition = Selectable.Transition.None;
		this.btn_Hero.m_BtnID1 = 8;
		this.btn_Hero.m_Handler = this;
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

	// Token: 0x06001DAE RID: 7598 RVA: 0x003710A4 File Offset: 0x0036F2A4
	public void SetDataInfo()
	{
		if (this.btn_Hero)
		{
			this.btn_Hero.m_EffectType = e_EffectType.e_Scale;
			this.btn_Hero.transition = Selectable.Transition.None;
			this.btn_Hero.m_BtnID1 = 8;
		}
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
			if (this.Report.Type == CombatCollectReport.CCR_SCOUT)
			{
				if (this.Favor.Combat.Scout.ScoutLevel != 0)
				{
					this.mStatus = 0;
				}
				else
				{
					this.mStatus = 1;
				}
			}
			else if (this.Report.Type == CombatCollectReport.CCR_RECON)
			{
				if (this.Favor.Combat.Recon.AntiScout == 1)
				{
					this.mStatus = 4;
				}
				else if (this.Favor.Combat.Recon.CombatPointKind == POINT_KIND.PK_CITY && this.Favor.Combat.Recon.bAmbush == 0)
				{
					this.mStatus = 2;
				}
				else
				{
					this.mStatus = 3;
				}
			}
			this.bCity = false;
			if (this.mStatus == 0)
			{
				if (this.Report.Scout.CombatPointKind == POINT_KIND.PK_CITY)
				{
					this.DM.SetScoutData(this.Report.Scout.ScoutLevel, this.Report.Scout.ScoutContent, this.Report.Scout.ScoutContentLen, 0);
					this.bCity = true;
				}
				else if (this.Report.Scout.CombatPointKind == POINT_KIND.PK_NPC)
				{
					this.DM.SetScoutData(this.Report.Scout.ScoutLevel, this.Report.Scout.ScoutContent, this.Report.Scout.ScoutContentLen, 0);
				}
				else if (this.Report.Scout.CombatPointKind == POINT_KIND.PK_YOLK)
				{
					this.DM.SetScoutData(this.Report.Scout.ScoutLevel, this.Report.Scout.ScoutContent, this.Report.Scout.ScoutContentLen, 2);
				}
				else
				{
					this.DM.SetScoutData(this.Report.Scout.ScoutLevel, this.Report.Scout.ScoutContent, this.Report.Scout.ScoutContentLen, 1);
				}
			}
			if (this.mStatus >= 2)
			{
				this.IsWatch = false;
			}
			else
			{
				this.IsWatch = true;
			}
			this.Cstr_Title.ClearString();
			this.Cstr_Name.ClearString();
			this.Cstr_Country.ClearString();
			if (this.IsWatch)
			{
				this.mWatchLv = (int)this.Report.Scout.ScoutLevel;
				this.btn_Title.gameObject.SetActive(true);
				this.Cstr_Watch[0].ClearString();
				if (this.Report.Scout.CombatPointKind == POINT_KIND.PK_YOLK)
				{
					if (this.Report.Scout.CombatPoint == 0 || this.Report.Scout.KingdomID == ActivityManager.Instance.KOWKingdomID)
					{
						this.Cstr_Watch[0].StringToFormat(this.DM.mStringTable.GetStringByID(9308u));
					}
					else
					{
						this.Cstr_Watch[0].StringToFormat(this.DM.mStringTable.GetStringByID(9309u));
					}
				}
				else
				{
					this.Cstr_Watch[0].StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Scout.CombatPointKind));
				}
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
					if (this.mStatus == 0 || (this.mWatchLv >= 10 && this.mStatus == 1))
					{
						CString cstring2 = StringManager.Instance.StaticString1024();
						CString cstring3 = StringManager.Instance.StaticString1024();
						cstring2.ClearString();
						cstring3.ClearString();
						if (this.Report.Scout.ObjName.Length != 0)
						{
							cstring2.Append(this.Report.Scout.ObjName);
						}
						else
						{
							cstring2.Append(" -");
						}
						if (this.Report.Scout.ObjAllianceTag != null && this.Report.Scout.ObjAllianceTag.Length != 0)
						{
							cstring3.Append(this.Report.Scout.ObjAllianceTag);
							GameConstants.FormatRoleName(this.Cstr_Name, cstring2, cstring3, null, 0, 0, null, null, null, null);
						}
						else
						{
							GameConstants.FormatRoleName(this.Cstr_Name, cstring2, null, null, 0, 0, null, null, null, null);
						}
						if (this.Report.Scout.ObjKingdomID != DataManager.MapDataController.kingdomData.kingdomID && this.Report.Scout.ObjKingdomID != 0)
						{
							this.Cstr_Country.IntToFormat((long)this.Report.Scout.ObjKingdomID, 1, false);
							if (this.GUIM.IsArabic)
							{
								this.Cstr_Country.AppendFormat("{0}#");
							}
							else
							{
								this.Cstr_Country.AppendFormat("#{0}");
							}
							this.text_Country.gameObject.SetActive(true);
						}
						else
						{
							this.text_Country.gameObject.SetActive(false);
						}
					}
					else
					{
						this.Cstr_Name.Append(this.Report.Scout.ObjName);
						this.text_Country.gameObject.SetActive(false);
					}
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
					if (this.DM.MainHeroHome == 1)
					{
						this.ImgMainHeroshow[0].gameObject.SetActive(true);
						this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.DM.MainHero);
						this.ImgMainHeroHead.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
					}
					else
					{
						this.ImgMainHeroshow[0].gameObject.SetActive(false);
						this.ImgMainHeroHome.gameObject.SetActive(true);
						this.ImgMainHeroHead.sprite = this.SArray.m_Sprites[0];
					}
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
				if (this.Report.Scout.CombatPointKind != POINT_KIND.PK_YOLK)
				{
					this.Cstr_Title.Append(this.DM.mStringTable.GetStringByID(6027u));
					if (this.Report.Scout.ScoutResult == 0)
					{
						CString cstring4 = StringManager.Instance.StaticString1024();
						CString cstring5 = StringManager.Instance.StaticString1024();
						CString cstring6 = StringManager.Instance.StaticString1024();
						cstring4.ClearString();
						cstring5.ClearString();
						cstring6.ClearString();
						cstring5.Append(this.Report.Scout.ObjName);
						if (this.Report.Scout.ObjAllianceTag != string.Empty)
						{
							cstring6.Append(this.Report.Scout.ObjAllianceTag);
							if (this.Report.Scout.ObjKingdomID != DataManager.MapDataController.kingdomData.kingdomID)
							{
								this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.Report.Scout.ObjKingdomID, this.GUIM.IsArabic);
							}
							else
							{
								this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, 0, this.GUIM.IsArabic);
							}
						}
						else if (this.Report.Scout.ObjKingdomID != DataManager.MapDataController.kingdomData.kingdomID)
						{
							this.GUIM.FormatRoleNameForChat(cstring4, cstring5, null, this.Report.Scout.ObjKingdomID, this.GUIM.IsArabic);
						}
						else
						{
							this.GUIM.FormatRoleNameForChat(cstring4, cstring5, null, 0, this.GUIM.IsArabic);
						}
						this.Cstr_Title.Append(cstring4);
					}
				}
				else if (this.mStatus == 0)
				{
					this.Cstr_Title.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Scout.CombatPoint, this.Report.Scout.KingdomID));
					this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7259u));
				}
				this.text_Title.text = this.Cstr_Title.ToString();
				this.tmpRCT = this.BG_T[1].GetChild(1).GetComponent<RectTransform>();
				this.Cstr_Coordinate.ClearString();
				if (this.Report.Scout.CombatPointKind != POINT_KIND.PK_YOLK)
				{
					this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Scout.CombatlZone, this.Report.Scout.CombatPoint));
				}
				else
				{
					this.tmpV = DataManager.MapDataController.GetYolkPos((ushort)this.Report.Scout.CombatPoint, this.Report.Scout.KingdomID);
				}
				this.Cstr_Coordinate.IntToFormat((long)this.Report.Scout.KingdomID, 1, false);
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
				this.Cstr_Coordinate.IntToFormat((long)this.Report.Scout.KingdomID, 1, false);
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
				this.ImgMainHeroHead.material = this.IconMaterial;
				if (this.GUIM.IsArabic)
				{
					this.ImgMainHeroHead.rectTransform.localScale = new Vector3(1f, 1f, 1f);
				}
				if (this.mStatus == 1)
				{
					this.text_LV.gameObject.SetActive(false);
					this.Img_T.gameObject.SetActive(true);
					if (this.Report.Scout.ScoutResult == 3 && this.Report.Scout.CombatPointKind == POINT_KIND.PK_YOLK)
					{
						if (this.btn_Hero)
						{
							this.btn_Hero.m_EffectType = e_EffectType.e_Normal;
							this.btn_Hero.transition = Selectable.Transition.None;
							this.btn_Hero.m_BtnID1 = 8;
						}
						this.StatusT[1].gameObject.SetActive(true);
						this.text_Name.gameObject.SetActive(false);
						this.Cstr_Status[0].ClearString();
						if (DataManager.MapDataController.OtherKingdomData.kingdomID != ActivityManager.Instance.KOWKingdomID)
						{
							this.Cstr_Status[0].StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Scout.CombatPoint, this.Report.Scout.KingdomID));
							this.Cstr_Status[0].AppendFormat(this.DM.mStringTable.GetStringByID(7262u));
						}
						else
						{
							this.Cstr_Status[0].Append(this.DM.mStringTable.GetStringByID(11019u));
						}
						this.text_Status[2].text = this.Cstr_Status[0].ToString();
						this.text_Status[2].SetAllDirty();
						this.text_Status[2].cachedTextGenerator.Invalidate();
						this.Cstr_Title.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Scout.CombatPoint, this.Report.Scout.KingdomID));
						this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7259u));
						this.text_Title.text = this.Cstr_Title.ToString();
						this.ImgFrame.gameObject.SetActive(false);
						this.ImgMainHero.gameObject.SetActive(true);
						if (this.Report.Scout.CombatlZone == 0)
						{
							this.ImgMainHeroHead.sprite = this.GUIM.GetWonderSprite(this.Report.Scout.CombatPoint, this.Report.Scout.KingdomID, 1);
						}
						else
						{
							this.ImgMainHeroHead.sprite = this.GUIM.GetWonderSprite(this.Report.Scout.CombatPoint, this.Report.Scout.KingdomID, 0);
						}
						this.ImgMainHeroHead.material = this.GUIM.m_WonderMaterial;
						if (this.GUIM.IsArabic)
						{
							this.ImgMainHeroHead.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
						}
						this.ImgMainHeroFrame.sprite = this.GUIM.LoadFrameSprite("hf011");
						this.ImgMainHeroshow[0].gameObject.SetActive(false);
					}
					else
					{
						this.StatusT[0].gameObject.SetActive(true);
						this.text_Status[0].text = this.DM.mStringTable.GetStringByID(5387u);
						this.Cstr_Status[0].ClearString();
						switch (this.Report.Scout.ScoutResult)
						{
						case 1:
							this.Cstr_Status[0].StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Scout.CombatPointKind));
							this.Cstr_Status[0].AppendFormat(this.DM.mStringTable.GetStringByID(5388u));
							break;
						case 2:
							this.Cstr_Status[0].Append(this.DM.mStringTable.GetStringByID(6068u));
							if (this.Report.Scout.CombatPointKind == POINT_KIND.PK_YOLK)
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
							this.Cstr_Status[0].StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Scout.CombatPointKind));
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
				}
				else
				{
					this._DataIdx.Clear();
					if (this.tmpPanel == null)
					{
						this.tmpPanel = this.CustomPanelT.gameObject.AddComponent<CustomPanel>();
					}
					this.CustomPanelT.gameObject.SetActive(true);
					this.Img_T.gameObject.SetActive(false);
					this.StatusT[1].gameObject.SetActive(false);
					this.text_Name.gameObject.SetActive(true);
					if (this.bCity)
					{
						this._DataIdx.Add(3);
					}
					if (this.mWatchLv >= 8)
					{
						this._DataIdx.Add(2);
					}
					if (this.mWatchLv >= 10 && (this.bCity || this.Report.Scout.CombatPointKind == POINT_KIND.PK_YOLK))
					{
						this._DataIdx.Add(5);
					}
					if (this.bCity || this.Report.Scout.CombatPointKind == POINT_KIND.PK_NPC)
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
					if (this.mWatchLv >= 3 && (this.bCity || this.Report.Scout.CombatPointKind == POINT_KIND.PK_YOLK))
					{
						this._DataIdx.Add(9);
					}
					if (this.mWatchLv >= 7 && (this.bCity || this.Report.Scout.CombatPointKind == POINT_KIND.PK_YOLK))
					{
						this._DataIdx.Add(10);
					}
					if (this.bCity)
					{
						if (this.mWatchLv >= 8)
						{
							this._DataIdx.Add(37);
						}
						if (this.mWatchLv >= 3)
						{
							this._DataIdx.Add(36);
						}
						if (this.mWatchLv >= 7)
						{
							this._DataIdx.Add(38);
						}
						if (this.mWatchLv >= 10)
						{
							this._DataIdx.Add(11);
						}
						if (this.mWatchLv >= 10)
						{
							this._DataIdx.Add(12);
						}
						if (this.mWatchLv >= 7)
						{
							this._DataIdx.Add(13);
						}
						if (this.mWatchLv >= 2)
						{
							this._DataIdx.Add(32);
						}
						if (this.mWatchLv >= 9)
						{
							this._DataIdx.Add(14);
						}
					}
					if (this.mWatchLv < 10)
					{
						this._DataIdx.Add(4);
					}
				}
			}
			else
			{
				this.btn_Title.gameObject.SetActive(false);
				this.btn_Coordinate.gameObject.SetActive(false);
				this.text_Top.gameObject.SetActive(false);
				this.text_Watch[1].gameObject.SetActive(true);
				this.mWatchLv = (int)this.Report.Recon.WatchLevel;
				this.text_Name.gameObject.SetActive(false);
				this.text_Country.gameObject.SetActive(false);
				this.ImgMainHeroshow[0].gameObject.SetActive(false);
				this.ImgMainHeroHome.gameObject.SetActive(false);
				if (this.mWatchLv >= 4)
				{
					this.text_Name.gameObject.SetActive(true);
					if (this.mWatchLv >= 10)
					{
						CString cstring7 = StringManager.Instance.StaticString1024();
						CString cstring8 = StringManager.Instance.StaticString1024();
						cstring7.ClearString();
						cstring8.ClearString();
						cstring7.Append(this.Report.Recon.SrcName);
						if (this.Report.Recon.SrcAllianceTag != null && this.Report.Recon.SrcAllianceTag.Length != 0)
						{
							cstring8.Append(this.Report.Recon.SrcAllianceTag);
							GameConstants.FormatRoleName(this.Cstr_Name, cstring7, cstring8, null, 0, 0, null, null, null, null);
						}
						else
						{
							GameConstants.FormatRoleName(this.Cstr_Name, cstring7, null, null, 0, 0, null, null, null, null);
						}
						if (this.Report.Recon.SrcKingdomID != DataManager.MapDataController.kingdomData.kingdomID)
						{
							this.Cstr_Country.IntToFormat((long)this.Report.Recon.SrcKingdomID, 1, false);
							if (this.GUIM.IsArabic)
							{
								this.Cstr_Country.AppendFormat("{0}#");
							}
							else
							{
								this.Cstr_Country.AppendFormat("#{0}");
							}
							this.text_Country.gameObject.SetActive(true);
						}
						else
						{
							this.text_Country.gameObject.SetActive(false);
						}
					}
					else
					{
						this.Cstr_Name.Append(this.Report.Recon.SrcName);
					}
				}
				this.ImgRecon.gameObject.SetActive(true);
				if (this.mWatchLv >= 15 && this.Report.Recon.SrcHead != 0)
				{
					this.ImgMainHero.gameObject.SetActive(true);
					this.ImgFrame.gameObject.SetActive(false);
					this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.Report.Recon.SrcHead);
					this.ImgMainHeroHead.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
					cstring.ClearString();
					cstring.Append("hf011");
					this.ImgMainHeroFrame.sprite = this.GUIM.LoadFrameSprite(cstring);
				}
				else
				{
					this.ImgMainHero.gameObject.SetActive(false);
					this.ImgFrame.gameObject.SetActive(true);
				}
				int num = this.mStatus;
				if (this.mStatus == 4)
				{
					num = 1;
				}
				this.Img_T.gameObject.SetActive(true);
				this.StatusT[num - 1].gameObject.SetActive(true);
				if (this.mWatchLv < 15)
				{
					this.text_LV.gameObject.SetActive(true);
				}
				switch (this.mStatus)
				{
				case 2:
					this.Cstr_Status[0].ClearString();
					this.Cstr_Status[0].StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Recon.CombatPointKind));
					this.Cstr_Status[0].AppendFormat(this.DM.mStringTable.GetStringByID(5355u));
					this.text_Status[2].text = this.Cstr_Status[0].ToString();
					this.text_Status[0].text = this.Cstr_Status[0].ToString();
					this.Cstr_Title.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Recon.CombatPointKind));
					this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(5355u));
					this.text_Title.text = this.Cstr_Title.ToString();
					this.text_Status[2].SetAllDirty();
					this.text_Status[2].cachedTextGenerator.Invalidate();
					break;
				case 3:
					this.Cstr_Status[0].ClearString();
					if (this.Report.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
					{
						this.Cstr_Status[0].StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Recon.CombatPoint, this.Report.Recon.KingdomID));
					}
					else
					{
						this.Cstr_Status[0].StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Recon.CombatPointKind));
					}
					this.Cstr_Status[0].AppendFormat(this.DM.mStringTable.GetStringByID(5353u));
					if (this.Report.Recon.bAmbush == 1)
					{
						this.Cstr_Status[0].ClearString();
						this.Cstr_Status[0].Append(this.DM.mStringTable.GetStringByID(9750u));
					}
					this.text_Status[3].text = this.Cstr_Status[0].ToString();
					this.text_Status[0].text = this.Cstr_Status[0].ToString();
					this.Cstr_Status[1].ClearString();
					if (this.Report.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
					{
						this.tmpV = DataManager.MapDataController.GetYolkPos((ushort)this.Report.Recon.CombatPoint, this.Report.Recon.KingdomID);
						this.Cstr_Title.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Recon.CombatPoint, this.Report.Recon.KingdomID));
						this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7263u));
					}
					else
					{
						this.Cstr_Title.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Recon.CombatPointKind));
						this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Recon.CombatlZone, this.Report.Recon.CombatPoint));
						this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(5355u));
					}
					if (this.Report.Recon.bAmbush == 1)
					{
						this.Cstr_Title.ClearString();
						this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Recon.CombatlZone, this.Report.Recon.CombatPoint));
						this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(9748u));
					}
					this.text_Title.text = this.Cstr_Title.ToString();
					this.Cstr_Status[1].IntToFormat((long)this.Report.Recon.KingdomID, 1, false);
					this.Cstr_Status[1].IntToFormat((long)((int)this.tmpV.x), 1, false);
					this.Cstr_Status[1].IntToFormat((long)((int)this.tmpV.y), 1, false);
					if (this.GUIM.IsArabic)
					{
						this.Cstr_Status[1].AppendFormat("{2}:Y {1}:X {0}:K");
					}
					else
					{
						this.Cstr_Status[1].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
					}
					this.text_Status[4].text = this.Cstr_Status[1].ToString();
					this.text_Status[4].SetAllDirty();
					this.text_Status[4].cachedTextGenerator.Invalidate();
					this.text_Status[4].cachedTextGeneratorForLayout.Invalidate();
					this.tmpRCT = this.StatusT[2].GetChild(1).GetComponent<RectTransform>();
					this.tmpRCT.sizeDelta = new Vector2(this.text_Status[4].preferredWidth, this.tmpRCT.sizeDelta.y);
					if (this.text_Status[4].preferredWidth + this.text_tmpStr[1].preferredWidth > 400f)
					{
						this.tmpRCT.anchoredPosition = new Vector2(139f - (this.text_Status[4].preferredWidth + this.text_tmpStr[1].preferredWidth - 400f) / 2f, this.tmpRCT.anchoredPosition.y);
					}
					this.tmpRCT = this.StatusT[2].GetChild(1).GetChild(0).GetComponent<RectTransform>();
					this.tmpRCT.sizeDelta = new Vector2(this.text_Status[4].preferredWidth, this.tmpRCT.sizeDelta.y);
					this.tmpRCT = this.StatusT[2].GetChild(1).GetChild(1).GetComponent<RectTransform>();
					this.tmpRCT.sizeDelta = new Vector2(this.text_Status[4].preferredWidth, this.tmpRCT.sizeDelta.y);
					this.tmpRCT = this.StatusT[2].GetChild(1).GetChild(2).GetComponent<RectTransform>();
					this.tmpRCT.anchoredPosition = new Vector2(this.text_Status[4].preferredWidth + 7f, this.tmpRCT.anchoredPosition.y);
					break;
				case 4:
					this.Cstr_Status[0].ClearString();
					this.Cstr_Status[0].StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Recon.CombatPointKind));
					this.Cstr_Status[0].AppendFormat(this.DM.mStringTable.GetStringByID(5355u));
					this.Cstr_Title.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Recon.CombatPointKind));
					this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(5355u));
					if (this.Report.Recon.bAmbush == 1)
					{
						this.Cstr_Status[0].ClearString();
						this.Cstr_Status[0].Append(this.DM.mStringTable.GetStringByID(9748u));
						this.Cstr_Title.ClearString();
						this.Cstr_Title.Append(this.DM.mStringTable.GetStringByID(9748u));
					}
					this.text_Status[2].text = this.Cstr_Status[0].ToString();
					this.text_Status[0].text = this.Cstr_Status[0].ToString();
					this.text_Title.text = this.Cstr_Title.ToString();
					this.text_Status[2].SetAllDirty();
					this.text_Status[2].cachedTextGenerator.Invalidate();
					this.Cstr_Status[1].ClearString();
					this.Cstr_Status[1].StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Recon.CombatPointKind));
					this.Cstr_Status[1].AppendFormat(this.DM.mStringTable.GetStringByID(5356u));
					this.text_Status[1].text = this.Cstr_Status[1].ToString();
					this.text_Status[1].SetAllDirty();
					this.text_Status[1].cachedTextGenerator.Invalidate();
					break;
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

	// Token: 0x06001DAF RID: 7599 RVA: 0x003738E0 File Offset: 0x00371AE0
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

	// Token: 0x06001DB0 RID: 7600 RVA: 0x00373A1C File Offset: 0x00371C1C
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
			if (this.Report.Scout.CombatPointKind != POINT_KIND.PK_YOLK)
			{
				this.door.GoToPointCode(this.Report.Scout.KingdomID, this.Report.Scout.CombatlZone, this.Report.Scout.CombatPoint, 0);
			}
			else
			{
				this.door.GoToWonder(this.Report.Scout.KingdomID, this.Report.Scout.CombatPoint);
			}
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
				if (this.Report.Scout.CombatPointKind != POINT_KIND.PK_YOLK)
				{
					this.door.GoToPointCode(this.Report.Scout.KingdomID, this.Report.Scout.CombatlZone, this.Report.Scout.CombatPoint, 0);
				}
				else
				{
					this.door.GoToWonder(this.Report.Scout.KingdomID, this.Report.Scout.CombatPoint);
				}
			}
			else
			{
				this.door.GoToPointCode(this.Report.Scout.KingdomID, this.Report.Recon.CombatlZone, this.Report.Recon.CombatPoint, 0);
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
		case 8:
			if (this.btn_Hero.m_EffectType == e_EffectType.e_Scale)
			{
				if (this.IsWatch)
				{
					if (this.Report != null && this.Report.Scout != null && this.Report.Scout.ObjName != null && this.Report.Scout.ObjName != string.Empty)
					{
						DataManager.Instance.ShowLordProfile(this.Report.Scout.ObjName);
					}
				}
				else if (this.Report != null && this.Report.Recon != null && this.Report.Recon.SrcName != null && this.Report.Recon.SrcName != string.Empty)
				{
					DataManager.Instance.ShowLordProfile(this.Report.Recon.SrcName);
				}
			}
			break;
		}
	}

	// Token: 0x06001DB1 RID: 7601 RVA: 0x00373DF8 File Offset: 0x00371FF8
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
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower);
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
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower);
					break;
				case CombatCollectReport.CCR_RESOURCE:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Resources, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower);
					break;
				case CombatCollectReport.CCR_COLLECT:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Collection, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower);
					break;
				case CombatCollectReport.CCR_SCOUT:
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
					if (this.Favor.Combat.Scout.ScoutLevel != 0)
					{
						this.mStatus = 0;
					}
					else
					{
						this.mStatus = 1;
					}
					this.SetDataInfo();
					break;
				case CombatCollectReport.CCR_RECON:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower);
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
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower);
					break;
				case CombatCollectReport.CCR_NPCSCOUT:
					this.door.CloseMenu(false);
					this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout, 0, 0, false);
					break;
				case CombatCollectReport.CCR_PETREPORT:
					this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower);
					break;
				}
				break;
			case MailType.EMAIL_LETTER:
				this.DM.OpenMail.Serial = this.Favor.Serial;
				this.DM.OpenMail.Type = this.Favor.Type;
				this.DM.OpenMail.Kind = this.Favor.Kind;
				this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower);
				break;
			}
		}
	}

	// Token: 0x06001DB2 RID: 7602 RVA: 0x003741AC File Offset: 0x003723AC
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

	// Token: 0x06001DB3 RID: 7603 RVA: 0x003741F0 File Offset: 0x003723F0
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
					return;
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
		}
	}

	// Token: 0x06001DB4 RID: 7604 RVA: 0x00374444 File Offset: 0x00372644
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

	// Token: 0x06001DB5 RID: 7605 RVA: 0x00374744 File Offset: 0x00372944
	private void Start()
	{
	}

	// Token: 0x06001DB6 RID: 7606 RVA: 0x00374748 File Offset: 0x00372948
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
			if (this.IsWatch && this.mStatus == 0 && this.Report != null)
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
			}
			this.bOpen = false;
		}
	}

	// Token: 0x04005BB7 RID: 23479
	private DataManager DM;

	// Token: 0x04005BB8 RID: 23480
	private GUIManager GUIM;

	// Token: 0x04005BB9 RID: 23481
	private Font TTFont;

	// Token: 0x04005BBA RID: 23482
	private Door door;

	// Token: 0x04005BBB RID: 23483
	private Transform GameT;

	// Token: 0x04005BBC RID: 23484
	private Transform Tmp;

	// Token: 0x04005BBD RID: 23485
	private Transform Tmp1;

	// Token: 0x04005BBE RID: 23486
	private Transform Tmp2;

	// Token: 0x04005BBF RID: 23487
	private Transform PreviousT;

	// Token: 0x04005BC0 RID: 23488
	private Transform NextT;

	// Token: 0x04005BC1 RID: 23489
	private Transform Img_T;

	// Token: 0x04005BC2 RID: 23490
	private Transform[] BG_T = new Transform[3];

	// Token: 0x04005BC3 RID: 23491
	private Transform[] StatusT = new Transform[4];

	// Token: 0x04005BC4 RID: 23492
	private Transform CustomPanelT;

	// Token: 0x04005BC5 RID: 23493
	private RectTransform tmpRCT;

	// Token: 0x04005BC6 RID: 23494
	private UIButton btn_EXIT;

	// Token: 0x04005BC7 RID: 23495
	private UIButton btn_Previous;

	// Token: 0x04005BC8 RID: 23496
	private UIButton btn_Next;

	// Token: 0x04005BC9 RID: 23497
	private UIButton btn_Title;

	// Token: 0x04005BCA RID: 23498
	private UIButton btn_Delete;

	// Token: 0x04005BCB RID: 23499
	private UIButton btn_Collect;

	// Token: 0x04005BCC RID: 23500
	private UIButton btn_Coordinate;

	// Token: 0x04005BCD RID: 23501
	private UIButton btn_ReconCoordinate;

	// Token: 0x04005BCE RID: 23502
	private UIButton btn_Hero;

	// Token: 0x04005BCF RID: 23503
	private Image tmpImg;

	// Token: 0x04005BD0 RID: 23504
	private Image ImgFrame;

	// Token: 0x04005BD1 RID: 23505
	private Image ImgRecon;

	// Token: 0x04005BD2 RID: 23506
	private Image ImgMainHero;

	// Token: 0x04005BD3 RID: 23507
	private Image ImgMainHeroHead;

	// Token: 0x04005BD4 RID: 23508
	private Image ImgMainHeroFrame;

	// Token: 0x04005BD5 RID: 23509
	private Image ImgMainHeroHome;

	// Token: 0x04005BD6 RID: 23510
	private Image[] ImgMainHeroshow = new Image[2];

	// Token: 0x04005BD7 RID: 23511
	private Image ImgNpcItem;

	// Token: 0x04005BD8 RID: 23512
	private UIText text_Coordinate;

	// Token: 0x04005BD9 RID: 23513
	private UIText[] text_tmpStr = new UIText[2];

	// Token: 0x04005BDA RID: 23514
	private UIText[] text_Watch = new UIText[2];

	// Token: 0x04005BDB RID: 23515
	private UIText[] text_Time = new UIText[2];

	// Token: 0x04005BDC RID: 23516
	private UIText text_Title;

	// Token: 0x04005BDD RID: 23517
	private UIText text_Page;

	// Token: 0x04005BDE RID: 23518
	private UIText text_Top;

	// Token: 0x04005BDF RID: 23519
	private UIText text_Country;

	// Token: 0x04005BE0 RID: 23520
	private UIText text_Name;

	// Token: 0x04005BE1 RID: 23521
	private UIText text_H_Coordinate;

	// Token: 0x04005BE2 RID: 23522
	private UIText text_LV;

	// Token: 0x04005BE3 RID: 23523
	private UIText[] text_Status = new UIText[9];

	// Token: 0x04005BE4 RID: 23524
	private CString Cstr_Coordinate;

	// Token: 0x04005BE5 RID: 23525
	private CString[] Cstr_Watch = new CString[2];

	// Token: 0x04005BE6 RID: 23526
	private CString[] Cstr_Time = new CString[2];

	// Token: 0x04005BE7 RID: 23527
	private CString Cstr_Title;

	// Token: 0x04005BE8 RID: 23528
	private CString Cstr_Page;

	// Token: 0x04005BE9 RID: 23529
	private CString Cstr_Country;

	// Token: 0x04005BEA RID: 23530
	private CString Cstr_Name;

	// Token: 0x04005BEB RID: 23531
	private CString Cstr_H_Coordinate;

	// Token: 0x04005BEC RID: 23532
	private CString[] Cstr_Status = new CString[4];

	// Token: 0x04005BED RID: 23533
	private Material mMaT;

	// Token: 0x04005BEE RID: 23534
	private Material IconMaterial;

	// Token: 0x04005BEF RID: 23535
	private Material FrameMaterial;

	// Token: 0x04005BF0 RID: 23536
	private List<int> _DataIdx = new List<int>();

	// Token: 0x04005BF1 RID: 23537
	private CustomPanel tmpPanel;

	// Token: 0x04005BF2 RID: 23538
	private bool IsWatch = true;

	// Token: 0x04005BF3 RID: 23539
	private int mWatchLv;

	// Token: 0x04005BF4 RID: 23540
	private bool bOpen = true;

	// Token: 0x04005BF5 RID: 23541
	private bool bFirst = true;

	// Token: 0x04005BF6 RID: 23542
	private int mStatus;

	// Token: 0x04005BF7 RID: 23543
	private bool bCity = true;

	// Token: 0x04005BF8 RID: 23544
	private int MaxLetterNum;

	// Token: 0x04005BF9 RID: 23545
	private float tempL;

	// Token: 0x04005BFA RID: 23546
	private float MoveTime1;

	// Token: 0x04005BFB RID: 23547
	private float MoveTime2;

	// Token: 0x04005BFC RID: 23548
	private float TmpTime;

	// Token: 0x04005BFD RID: 23549
	private float ShowMainHeroTime1;

	// Token: 0x04005BFE RID: 23550
	private Vector3 Vec3Instance;

	// Token: 0x04005BFF RID: 23551
	private Vector2 tmpV;

	// Token: 0x04005C00 RID: 23552
	private MyFavorite Favor = new MyFavorite(MailType.EMAIL_MAX, 0u);

	// Token: 0x04005C01 RID: 23553
	private CombatReport Report;

	// Token: 0x04005C02 RID: 23554
	private Hero tmpHero;

	// Token: 0x04005C03 RID: 23555
	private UISpritesArray SArray;
}
