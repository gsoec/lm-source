using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006BE RID: 1726
public class UIWatchtower_Details : GUIWindow, IUIButtonClickHandler, IUTimeBarOnTimer
{
	// Token: 0x060020F7 RID: 8439 RVA: 0x003E9548 File Offset: 0x003E7748
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		if (this.DM.m_WTList_Idx < 0 || this.DM.m_WTList_Idx > this.DM.m_WatchTowerData.Count || this.DM.m_WatchTowerData.Count == 0)
		{
			this.door.CloseMenu(false);
			return;
		}
		this.tmpData = this.DM.tmp_WatchTowerData[(int)this.DM.m_WatchTowerData[this.DM.m_WTList_Idx].ListIdx];
		if (this.tmpData.Index >= 0 && this.tmpData.Index <= 7 && this.DM.MarchEventData[(int)this.tmpData.Index].PointKind == POINT_KIND.PK_YOLK)
		{
			this.bYolk = true;
		}
		switch (this.tmpData.LineType)
		{
		case 5:
		case 7:
			if (this.tmpData.Index == 255 || this.bYolk)
			{
				this.mStatus = 2;
			}
			else
			{
				this.mStatus = 3;
			}
			goto IL_261;
		case 6:
			if (this.tmpData.Index == 255)
			{
				this.mStatus = 11;
			}
			else if (this.bYolk)
			{
				this.mStatus = 12;
			}
			goto IL_261;
		case 8:
			if (this.tmpData.Index == 255 || this.bYolk)
			{
				this.mStatus = 5;
			}
			else
			{
				this.mStatus = 6;
			}
			goto IL_261;
		case 10:
			this.mStatus = 8;
			goto IL_261;
		case 11:
			this.mStatus = 7;
			goto IL_261;
		case 12:
			this.mStatus = 1;
			goto IL_261;
		case 13:
			this.mStatus = 9;
			goto IL_261;
		case 22:
			this.mStatus = 13;
			goto IL_261;
		}
		this.mStatus = 2;
		IL_261:
		Transform transform = base.gameObject.transform;
		this.SArray = transform.GetComponent<UISpritesArray>();
		this.ImgList[0] = this.SArray.m_Sprites[6];
		this.ImgList[1] = this.SArray.m_Sprites[1];
		this.ImgList[2] = this.SArray.m_Sprites[1];
		this.ImgList[3] = this.SArray.m_Sprites[5];
		this.ImgList[4] = this.SArray.m_Sprites[0];
		this.ImgList[5] = this.SArray.m_Sprites[0];
		this.ImgList[6] = this.SArray.m_Sprites[4];
		this.ImgList[7] = this.SArray.m_Sprites[3];
		this.ImgList[8] = this.SArray.m_Sprites[2];
		this.ImgList[9] = this.SArray.m_Sprites[7];
		this.ImgList[10] = this.SArray.m_Sprites[8];
		this.ImgList[11] = this.SArray.m_Sprites[9];
		this.ImgList[12] = this.SArray.m_Sprites[10];
		this.ImgList[13] = this.SArray.m_Sprites[11];
		this.ImgList[14] = this.SArray.m_Sprites[12];
		this.Cstr_Title = StringManager.Instance.SpawnString(200);
		for (int i = 0; i < 2; i++)
		{
			this.Cstr_PlayerName[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_btnCoordinate[i] = StringManager.Instance.SpawnString(30);
		}
		this.text_tmpStr[0] = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(3896u);
		this.Tmp = transform.GetChild(1);
		this.Img_Status = this.Tmp.GetChild(2).GetComponent<Image>();
		if (this.mStatus > 0)
		{
			if (!this.bYolk)
			{
				if (this.mStatus == 11)
				{
					this.Img_Status.sprite = this.ImgList[13];
				}
				else if (this.mStatus == 13)
				{
					this.Img_Status.sprite = this.ImgList[14];
				}
				else
				{
					this.Img_Status.sprite = this.ImgList[this.mStatus - 1];
				}
			}
			else
			{
				Status_Kind status_Kind = (Status_Kind)this.mStatus;
				switch (status_Kind)
				{
				case Status_Kind.K_MusterAttack:
					this.Img_Status.sprite = this.ImgList[9];
					break;
				case Status_Kind.K_Attack:
					this.Img_Status.sprite = this.ImgList[10];
					break;
				default:
					if (status_Kind == Status_Kind.K_WonderHost)
					{
						this.Img_Status.sprite = this.ImgList[12];
					}
					break;
				case Status_Kind.K_Investigate:
					this.Img_Status.sprite = this.ImgList[11];
					break;
				case Status_Kind.K_Reinforce:
					this.Img_Status.sprite = this.ImgList[12];
					break;
				}
			}
		}
		else
		{
			this.Img_Status.sprite = this.ImgList[0];
		}
		this.Img_Status.SetNativeSize();
		this.door_M = this.door.LoadMaterial();
		this.btn_Coordinate_1 = this.Tmp.GetChild(3).GetComponent<UIButton>();
		this.btn_Coordinate_1.m_Handler = this;
		this.btn_Coordinate_1.m_BtnID1 = 2;
		this.Coordinate1_RT[0] = this.Tmp.GetChild(3).GetComponent<RectTransform>();
		this.Coordinate1_RT[1] = this.Tmp.GetChild(3).GetChild(0).GetComponent<RectTransform>();
		this.Coordinate1_RT[2] = this.Tmp.GetChild(3).GetChild(1).GetComponent<RectTransform>();
		this.text_btnCoordinate[0] = this.Tmp.GetChild(3).GetChild(1).GetComponent<UIText>();
		this.text_btnCoordinate[0].font = this.TTFont;
		this.Cstr_btnCoordinate[0].ClearString();
		if (this.mStatus == 3 || this.mStatus == 6 || (this.bYolk && (this.mStatus == 1 || this.mStatus == 2 || this.mStatus == 5 || this.mStatus == 8 || this.mStatus == 12)) || (this.tmpData.Index >= 0 && this.tmpData.Index <= 7 && this.DM.MarchEventData[(int)this.tmpData.Index].IsAmbushCamp() && this.mStatus == 1))
		{
			if (!this.bYolk)
			{
				this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.DM.MarchEventData[(int)this.tmpData.Index].Point.zoneID, this.DM.MarchEventData[(int)this.tmpData.Index].Point.pointID));
			}
			else
			{
				this.tmpV = DataManager.MapDataController.GetYolkPos((ushort)this.DM.MarchEventData[(int)this.tmpData.Index].DesPointLevel, DataManager.MapDataController.OtherKingdomData.kingdomID);
			}
			this.Cstr_btnCoordinate[0].StringToFormat(this.DM.mStringTable.GetStringByID(4505u));
			this.Cstr_btnCoordinate[0].IntToFormat((long)((int)this.tmpV.x), 1, false);
			this.Cstr_btnCoordinate[0].StringToFormat(this.DM.mStringTable.GetStringByID(4506u));
			this.Cstr_btnCoordinate[0].IntToFormat((long)((int)this.tmpV.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_btnCoordinate[0].AppendFormat("{3}{2} {1}{0}");
			}
			else
			{
				this.Cstr_btnCoordinate[0].AppendFormat("{0}{1} {2}{3}");
			}
			this.text_btnCoordinate[0].text = this.Cstr_btnCoordinate[0].ToString();
			this.text_btnCoordinate[0].SetAllDirty();
			this.text_btnCoordinate[0].cachedTextGenerator.Invalidate();
			for (int j = 0; j < 3; j++)
			{
				this.Coordinate1_RT[j].sizeDelta = new Vector2(this.text_btnCoordinate[0].preferredWidth, this.Coordinate1_RT[j].sizeDelta.y);
			}
		}
		this.timeBar = this.Tmp.GetChild(4).GetComponent<UITimeBar>();
		this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.NormalType, string.Empty, string.Empty);
		this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
		this.timeBar.m_Handler = this;
		this.timeBar.m_TimeBarID = 1;
		this.text_tmptimeBar[0] = this.Tmp.GetChild(4).GetChild(2).GetComponent<UIText>();
		this.text_tmptimeBar[1] = this.Tmp.GetChild(4).GetChild(3).GetComponent<UIText>();
		this.stringStatus1[0] = 4984;
		this.stringStatus1[1] = 4005;
		this.stringStatus1[2] = 4004;
		this.stringStatus1[3] = 9753;
		this.stringStatus1[4] = 4006;
		this.stringStatus1[5] = 4878;
		this.stringStatus1[6] = 4008;
		this.stringStatus1[7] = 4007;
		this.stringStatus1[8] = 4003;
		this.stringStatus1[9] = 9743;
		this.stringStatus1[10] = 9762;
		this.stringStatus1[11] = 9763;
		this.stringStatus1[12] = 12099;
		this.stringStatus2[0] = 4983;
		this.stringStatus2[1] = 3997;
		this.stringStatus2[2] = 3998;
		this.stringStatus2[3] = 3998;
		this.stringStatus2[4] = 3999;
		this.stringStatus2[5] = 3999;
		this.stringStatus2[6] = 4000;
		this.stringStatus2[7] = 4001;
		this.stringStatus2[8] = 4002;
		this.stringStatus2[9] = 8577;
		this.stringStatus2[10] = 8578;
		this.stringStatus2[11] = 8579;
		this.stringStatus2[12] = 8580;
		this.stringStatus2[13] = 9739;
		this.stringStatus2[14] = 12101;
		this.text_Title = this.Tmp.GetChild(5).GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.color = this.R_Color;
		this.text_Title2 = this.Tmp.GetChild(6).GetComponent<UIText>();
		this.text_Title2.font = this.TTFont;
		if (!this.bYolk)
		{
			if (this.mStatus == 11)
			{
				this.text_Title.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus1[9]);
				this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus2[13]);
			}
			else if (this.mStatus == 13)
			{
				this.text_Title.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus1[12]);
				this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus2[14]);
			}
			else if (this.tmpData.Index >= 0 && this.tmpData.Index <= 7 && this.DM.MarchEventData[(int)this.tmpData.Index].IsAmbushCamp())
			{
				switch (this.mStatus)
				{
				case 1:
					this.text_Title.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus1[10]);
					this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus2[0]);
					break;
				case 3:
					this.text_Title.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus1[3]);
					this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus2[3]);
					break;
				case 6:
					this.text_Title.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus1[11]);
					this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus2[5]);
					break;
				}
			}
			else if (this.mStatus > 0)
			{
				this.text_Title.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus1[this.mStatus - 1]);
				this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus2[this.mStatus - 1]);
			}
		}
		else
		{
			this.Cstr_Title.ClearString();
			this.Cstr_Title.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.DM.MarchEventData[(int)this.tmpData.Index].DesPointLevel, 0));
			Status_Kind status_Kind = (Status_Kind)this.mStatus;
			switch (status_Kind)
			{
			case Status_Kind.K_MusterAttack:
				this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(8544u));
				this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus2[9]);
				break;
			case Status_Kind.K_Attack:
				this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(8545u));
				this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus2[10]);
				break;
			default:
				if (status_Kind == Status_Kind.K_WonderHost)
				{
					this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(9917u));
					this.text_Title2.text = this.DM.mStringTable.GetStringByID(9918u);
				}
				break;
			case Status_Kind.K_Investigate:
				this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(8546u));
				this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus2[11]);
				break;
			case Status_Kind.K_Reinforce:
				this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(8547u));
				this.text_Title2.text = this.DM.mStringTable.GetStringByID((uint)this.stringStatus2[12]);
				break;
			}
			this.text_Title.text = this.Cstr_Title.ToString();
		}
		this.text_Title.SetAllDirty();
		this.text_Title.cachedTextGenerator.Invalidate();
		this.text_Title2.SetAllDirty();
		this.text_Title2.cachedTextGenerator.Invalidate();
		this.text_PlayerName[0] = this.Tmp.GetChild(7).GetComponent<UIText>();
		this.text_PlayerName[0].font = this.TTFont;
		this.text_PlayerName[0].text = this.DM.mStringTable.GetStringByID(4009u);
		this.text_PlayerName[1] = this.Tmp.GetChild(8).GetComponent<UIText>();
		this.text_PlayerName[1].font = this.TTFont;
		this.text_Time = this.Tmp.GetChild(9).GetComponent<UIText>();
		this.text_Time.font = this.TTFont;
		this.text_Time.text = this.DM.mStringTable.GetStringByID(4041u);
		this.text_TimeBar = this.Tmp.GetChild(10).GetComponent<UIText>();
		this.text_TimeBar.font = this.TTFont;
		this.text_TimeBar.alignment = TextAnchor.UpperLeft;
		this.CustomPanelT = transform.GetChild(2);
		this.Tmp = transform.GetChild(3);
		this.Img_Lock = this.Tmp.GetComponent<Image>();
		this.Img_Lock.sprite = this.door.LoadSprite("UI_main_lock");
		this.Img_Lock.material = this.door_M;
		this.Img_Lock.gameObject.SetActive(false);
		this.text_tmpStr[1] = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(4015u);
		this.Tmp = transform.GetChild(4);
		this.Img_NoHero = this.Tmp.GetChild(0).GetComponent<Image>();
		this.Img_Hero = this.Tmp.GetChild(1).GetComponent<Image>();
		this.Img_Hero.material = this.GUIM.m_IconSpriteAsset.GetMaterial();
		this.btn_Hero = this.Tmp.GetChild(1).GetComponent<UIButton>();
		this.btn_Hero.m_Handler = this;
		this.btn_Hero.m_BtnID1 = 5;
		this.btn_Hero.m_EffectType = e_EffectType.e_Scale;
		this.btn_Hero.transition = Selectable.Transition.None;
		this.Img_HeroBG = this.Tmp.GetChild(1).GetChild(0).GetComponent<Image>();
		this.Img_HeroBG.material = this.GUIM.m_IconSpriteAsset.GetMaterial();
		this.tmpRC = this.Img_HeroBG.transform.GetComponent<RectTransform>();
		this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
		this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.Img_HeroFrame = this.Tmp.GetChild(1).GetChild(1).GetComponent<Image>();
		this.Img_HeroFrame.material = this.GUIM.GetFrameMaterial();
		this.tmpRC = this.Img_HeroFrame.transform.GetComponent<RectTransform>();
		this.tmpRC.anchorMin = Vector2.zero;
		this.tmpRC.anchorMax = new Vector2(1f, 1f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.Img_Drop = this.Tmp.GetChild(2).GetComponent<Image>();
		this.text_Drop = this.Tmp.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.text_Drop.font = this.TTFont;
		this.text_Drop.text = this.DM.mStringTable.GetStringByID(4016u);
		this.btn_Prepare = this.Tmp.GetChild(3).GetComponent<UIButton>();
		this.btn_Prepare.m_Handler = this;
		this.btn_Prepare.m_BtnID1 = 4;
		this.btn_Prepare.m_EffectType = e_EffectType.e_Scale;
		this.btn_Prepare.transition = Selectable.Transition.None;
		this.text_btnStr = this.Tmp.GetChild(3).GetChild(1).GetComponent<UIText>();
		this.text_btnStr.font = this.TTFont;
		this.text_btnStr.text = this.DM.mStringTable.GetStringByID(8532u);
		this.btn_Coordinate_2 = this.Tmp.GetChild(4).GetComponent<UIButton>();
		this.btn_Coordinate_2.m_Handler = this;
		this.btn_Coordinate_2.m_BtnID1 = 3;
		this.Coordinate2_RT[0] = this.Tmp.GetChild(4).GetComponent<RectTransform>();
		this.Coordinate2_RT[1] = this.Tmp.GetChild(4).GetChild(0).GetComponent<RectTransform>();
		this.Coordinate2_RT[2] = this.Tmp.GetChild(4).GetChild(1).GetComponent<RectTransform>();
		this.text_btnCoordinate[1] = this.Tmp.GetChild(4).GetChild(1).GetComponent<UIText>();
		this.text_btnCoordinate[1].font = this.TTFont;
		this.text_MainHero = this.Tmp.GetChild(5).GetComponent<UIText>();
		this.text_MainHero.font = this.TTFont;
		this.ImgShowMain[0] = this.Tmp.GetChild(6).GetComponent<Image>();
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.AppendFormat("UI_legion_icon_13");
		this.ImgShowMain[0].sprite = this.GUIM.LoadFrameSprite(cstring);
		this.ImgShowMain[0].material = this.GUIM.GetFrameMaterial();
		this.ImgShowMain[1] = this.Tmp.GetChild(6).GetChild(0).GetComponent<Image>();
		cstring.ClearString();
		cstring.AppendFormat("UI_legion_icon_12");
		this.ImgShowMain[1].sprite = this.GUIM.LoadFrameSprite(cstring);
		this.ImgShowMain[1].material = this.GUIM.GetFrameMaterial();
		Image component = transform.GetChild(5).GetComponent<Image>();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component.enabled = false;
		}
		this.btn_EXIT = transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 1;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.text_NoTroops = transform.GetChild(6).GetComponent<UIText>();
		this.text_NoTroops.font = this.TTFont;
		this.text_NoTroops.text = this.DM.mStringTable.GetStringByID(3974u);
		this.tmpRC = this.text_Title.GetComponent<RectTransform>();
		if (this.mStatus == 3 || this.mStatus == 6 || (this.bYolk && (this.mStatus == 1 || this.mStatus == 2 || this.mStatus == 5 || this.mStatus == 8 || this.mStatus == 12)) || (this.tmpData.Index >= 0 && this.tmpData.Index <= 7 && this.DM.MarchEventData[(int)this.tmpData.Index].IsAmbushCamp() && this.mStatus == 1))
		{
			if (this.text_Title.preferredWidth > this.text_Title.rectTransform.sizeDelta.x)
			{
				this.text_Title.rectTransform.anchoredPosition = new Vector2(-50f, this.tmpRC.anchoredPosition.y);
				this.text_Title.rectTransform.sizeDelta = new Vector2(600f, this.text_Title.rectTransform.sizeDelta.y);
				this.Coordinate1_RT[0].anchoredPosition = new Vector2(670f, this.Coordinate1_RT[0].anchoredPosition.y);
			}
			else
			{
				this.text_Title.rectTransform.sizeDelta = new Vector2(this.text_Title.preferredWidth, this.text_Title.rectTransform.sizeDelta.y);
				this.Coordinate1_RT[0].anchoredPosition = new Vector2(420f + this.text_Title.preferredWidth / 2f, this.Coordinate1_RT[0].anchoredPosition.y);
			}
		}
		else if (this.text_Title.preferredWidth > this.tmpRC.sizeDelta.x)
		{
			if (this.text_Title.preferredWidth > 710f)
			{
				this.tmpRC.sizeDelta = new Vector2(710f, this.tmpRC.sizeDelta.y);
			}
			else
			{
				this.tmpRC.sizeDelta = new Vector2(this.text_Title.preferredWidth, this.tmpRC.sizeDelta.y);
			}
		}
		switch (this.mStatus)
		{
		case 1:
		case 2:
			if (this.bYolk)
			{
				this.btn_Coordinate_1.gameObject.SetActive(true);
			}
			if (this.mStatus == 1 && this.tmpData.Index >= 0 && this.tmpData.Index <= 7 && this.DM.MarchEventData[(int)this.tmpData.Index].IsAmbushCamp())
			{
				this.btn_Coordinate_1.gameObject.SetActive(true);
			}
			break;
		case 3:
			this.text_MainHero.gameObject.SetActive(true);
			this.btn_Coordinate_1.gameObject.SetActive(true);
			break;
		case 5:
			this.bHaveTroops = false;
			break;
		case 6:
			this.btn_Coordinate_1.gameObject.SetActive(true);
			this.bHaveTroops = false;
			break;
		case 7:
			if (this.bYolk)
			{
				this.btn_Coordinate_1.gameObject.SetActive(true);
			}
			break;
		case 8:
			if (this.bYolk)
			{
				this.btn_Coordinate_1.gameObject.SetActive(true);
			}
			break;
		case 9:
			this.bHaveTroops = false;
			break;
		case 12:
			if (this.bYolk)
			{
				this.btn_Coordinate_1.gameObject.SetActive(true);
			}
			break;
		case 13:
			this.mBD = this.GUIM.BuildingData.GetBuildData(13, 0);
			if (this.mBD.Level >= 19)
			{
				this.bHaveTroops = true;
			}
			else
			{
				this.bHaveTroops = false;
			}
			break;
		}
		this._DataIdx.Clear();
		if (this.bHaveTroops)
		{
			this.tmpPanel = this.CustomPanelT.gameObject.AddComponent<CustomPanel>();
			if (this.mStatus == 13)
			{
				this._DataIdx.Add(43);
			}
			else
			{
				this._DataIdx.Add(1);
				if (this.mStatus != 8 && this.mStatus != 7)
				{
					this._DataIdx.Add(2);
				}
			}
		}
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		this.bOpen = true;
	}

	// Token: 0x060020F8 RID: 8440 RVA: 0x003EB19C File Offset: 0x003E939C
	public void CheckEffect()
	{
		this.mBD = this.GUIM.BuildingData.GetBuildData(13, 0);
		this.m_Effect = (ushort)this.mBD.Level;
		this.text_TimeBar.text = this.DM.mStringTable.GetStringByID(3931u);
		this.text_TimeBar.alignment = TextAnchor.UpperCenter;
		this.Img_NoHero.gameObject.SetActive(true);
		bool active = true;
		if (this.m_Effect == 25)
		{
			if (this.mStatus == 1 || this.mStatus == 2 || this.mStatus == 3 || this.mStatus == 5 || this.mStatus == 12)
			{
				if (!this.bYolk)
				{
					this.btn_Prepare.gameObject.SetActive(true);
				}
				active = false;
			}
			if ((this.mStatus == 1 || this.mStatus == 2) && !this.bYolk)
			{
				this.Img_Drop.gameObject.SetActive(true);
			}
		}
		if (this.m_Effect >= 23 && this.mStatus == 11)
		{
			active = false;
		}
		if (this.m_Effect >= 21 && (this.mStatus == 7 || this.mStatus == 8))
		{
			active = false;
		}
		if (this.m_Effect >= 19 && this.mStatus == 13)
		{
			active = false;
		}
		if (this.m_Effect >= 17)
		{
		}
		if (this.m_Effect >= 15)
		{
			this.Img_Hero.gameObject.SetActive(true);
			this.Img_NoHero.gameObject.SetActive(false);
			Hero recordByKey = this.DM.HeroTable.GetRecordByKey(this.DM.m_WT_MH);
			this.Img_Hero.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(recordByKey.Graph);
			this.Img_HeroBG.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(recordByKey.Graph);
			this.Img_HeroFrame.sprite = this.GUIM.LoadFrameSprite("hf011");
			if (this.mStatus == 1 || this.mStatus == 2 || this.mStatus == 3 || this.mStatus == 11 || this.mStatus == 12)
			{
				this.text_MainHero.gameObject.SetActive(true);
			}
			if (this.DM.m_WT_WithSupremeLeader > 0)
			{
				this.text_MainHero.text = this.DM.mStringTable.GetStringByID(4012u);
				this.ImgShowMain[0].gameObject.SetActive(true);
			}
			else
			{
				this.text_MainHero.text = this.DM.mStringTable.GetStringByID(4013u);
				this.ImgShowMain[0].gameObject.SetActive(false);
			}
			if (this.mStatus == 9)
			{
				active = false;
			}
		}
		if (this.m_Effect >= 13)
		{
		}
		if (this.m_Effect >= 10)
		{
		}
		if (this.m_Effect >= 7)
		{
			if (this.DM.m_WTList_Idx == -1)
			{
				this.text_TimeBar.text = this.DM.mStringTable.GetStringByID(5776u);
				this.text_TimeBar.SetAllDirty();
				this.text_TimeBar.cachedTextGenerator.Invalidate();
				this.text_TimeBar.alignment = TextAnchor.UpperCenter;
				this.timeBar.gameObject.SetActive(false);
			}
			else
			{
				this.text_TimeBar.gameObject.SetActive(false);
				long beginTime = this.DM.tmp_WatchTowerData[(int)this.DM.m_WatchTowerData[this.DM.m_WTList_Idx].ListIdx].MarchTimeData.BeginTime;
				long target = beginTime + (long)((ulong)this.DM.tmp_WatchTowerData[(int)this.DM.m_WatchTowerData[this.DM.m_WTList_Idx].ListIdx].MarchTimeData.RequireTime);
				this.GUIM.SetTimerBar(this.timeBar, beginTime, target, 0L, eTimeBarType.NormalType, this.DM.mStringTable.GetStringByID(3985u), string.Empty);
				this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
			}
		}
		if (this.m_Effect >= 4)
		{
			this.Cstr_PlayerName[0].ClearString();
			this.text_PlayerName[1].color = Color.white;
			this.Cstr_PlayerName[0].Append(this.DM.mStringTable.GetStringByID(4009u));
			this.text_PlayerName[0].text = this.Cstr_PlayerName[0].ToString();
			this.text_PlayerName[0].SetAllDirty();
			this.text_PlayerName[0].cachedTextGenerator.Invalidate();
			this.Cstr_PlayerName[1].ClearString();
			CString cstring = StringManager.Instance.StaticString1024();
			CString cstring2 = StringManager.Instance.StaticString1024();
			CString cstring3 = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring2.ClearString();
			cstring3.ClearString();
			if (this.m_Effect >= 10)
			{
				cstring.Append(this.DM.m_WT_Name);
				if (this.DM.m_WT_AllianceName.Length > 0)
				{
					cstring2.Append(this.DM.m_WT_AllianceName);
					if (this.DM.m_WT_KingdomID != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.text_PlayerName[1].color = new Color(1f, 0.294f, 0.459f);
						GameConstants.FormatRoleName(this.Cstr_PlayerName[1], cstring, cstring2, null, 0, this.DM.m_WT_KingdomID, null, null, null, null);
					}
					else
					{
						GameConstants.FormatRoleName(this.Cstr_PlayerName[1], cstring, cstring2, null, 0, 0, null, null, null, null);
					}
				}
				else if (this.DM.m_WT_KingdomID != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.text_PlayerName[1].color = new Color(1f, 0.294f, 0.459f);
					GameConstants.FormatRoleName(this.Cstr_PlayerName[1], cstring, null, null, 0, this.DM.m_WT_KingdomID, null, null, null, null);
				}
				else
				{
					GameConstants.FormatRoleName(this.Cstr_PlayerName[1], cstring, null, null, 0, 0, null, null, null, null);
				}
			}
			else
			{
				cstring.Append(this.DM.m_WT_Name);
				if (this.DM.m_WT_KingdomID != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.text_PlayerName[1].color = new Color(1f, 0.294f, 0.459f);
					GameConstants.FormatRoleName(this.Cstr_PlayerName[1], cstring, null, null, 0, this.DM.m_WT_KingdomID, null, null, null, null);
				}
				else
				{
					GameConstants.FormatRoleName(this.Cstr_PlayerName[1], cstring, null, null, 0, 0, null, null, null, null);
				}
			}
			this.text_PlayerName[1].text = this.Cstr_PlayerName[1].ToString();
			this.text_PlayerName[1].SetAllDirty();
			this.text_PlayerName[1].cachedTextGenerator.Invalidate();
			this.Cstr_btnCoordinate[1].ClearString();
			this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.DM.m_WT_Point.zoneID, this.DM.m_WT_Point.pointID));
			this.Cstr_btnCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(4505u));
			this.Cstr_btnCoordinate[1].IntToFormat((long)((int)this.tmpV.x), 1, false);
			this.Cstr_btnCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(4506u));
			this.Cstr_btnCoordinate[1].IntToFormat((long)((int)this.tmpV.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_btnCoordinate[1].AppendFormat("{3}{2} {1}{0}");
			}
			else
			{
				this.Cstr_btnCoordinate[1].AppendFormat("{0}{1} {2}{3}");
			}
			this.text_btnCoordinate[1].text = this.Cstr_btnCoordinate[1].ToString();
			this.text_btnCoordinate[1].SetAllDirty();
			this.text_btnCoordinate[1].cachedTextGenerator.Invalidate();
			for (int i = 0; i < 3; i++)
			{
				this.Coordinate2_RT[i].sizeDelta = new Vector2(this.text_btnCoordinate[1].preferredWidth, this.Coordinate2_RT[i].sizeDelta.y);
			}
		}
		else
		{
			this.text_PlayerName[1].text = this.DM.mStringTable.GetStringByID(3931u);
			this.Cstr_btnCoordinate[1].ClearString();
			this.Cstr_btnCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(4505u));
			this.Cstr_btnCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(3931u));
			this.Cstr_btnCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(4506u));
			this.Cstr_btnCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(3931u));
			if (this.GUIM.IsArabic)
			{
				this.Cstr_btnCoordinate[1].AppendFormat("{3}{2} {1}{0}");
			}
			else
			{
				this.Cstr_btnCoordinate[1].AppendFormat("{0}{1} {2}{3}");
			}
			this.text_btnCoordinate[1].text = this.Cstr_btnCoordinate[1].ToString();
			this.text_btnCoordinate[1].SetAllDirty();
			this.text_btnCoordinate[1].cachedTextGenerator.Invalidate();
			for (int j = 0; j < 3; j++)
			{
				this.Coordinate2_RT[j].sizeDelta = new Vector2(this.text_btnCoordinate[1].preferredWidth, this.Coordinate2_RT[j].sizeDelta.y);
			}
		}
		this.Img_Lock.gameObject.SetActive(active);
		if (this.text_TimeBar.IsActive())
		{
			this.timeBar.m_TimeText.gameObject.SetActive(false);
		}
		else if (!this.timeBar.m_TimeText.IsActive())
		{
			this.timeBar.m_TimeText.gameObject.SetActive(true);
		}
		if (this.bHaveTroops)
		{
			this.tmpPanel.SetPanelData(this._DataIdx, false, true, (int)this.m_Effect, this.mStatus, 0f);
			this.tmpPanel.InitScrollPanel();
		}
		else
		{
			this.text_NoTroops.gameObject.SetActive(true);
		}
	}

	// Token: 0x060020F9 RID: 8441 RVA: 0x003EBCA8 File Offset: 0x003E9EA8
	public override void OnClose()
	{
		this._DataIdx = null;
		if (this.tmpPanel != null)
		{
			this.tmpPanel.Destroy();
		}
		if (this.timeBar != null)
		{
			this.GUIM.RemoverTimeBaarToList(this.timeBar);
		}
		if (this.Cstr_Title != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Title);
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.Cstr_PlayerName[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_PlayerName[i]);
			}
			if (this.Cstr_btnCoordinate[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_btnCoordinate[i]);
			}
		}
	}

	// Token: 0x060020FA RID: 8442 RVA: 0x003EBD68 File Offset: 0x003E9F68
	public void OnTimer(UITimeBar sender)
	{
		if (this.m_Effect >= 4 && this.timeBar.gameObject.activeSelf)
		{
			this.text_TimeBar.text = this.DM.mStringTable.GetStringByID(5776u);
			this.text_TimeBar.SetAllDirty();
			this.text_TimeBar.cachedTextGenerator.Invalidate();
			this.text_TimeBar.alignment = TextAnchor.UpperCenter;
			this.timeBar.gameObject.SetActive(false);
		}
	}

	// Token: 0x060020FB RID: 8443 RVA: 0x003EBDF0 File Offset: 0x003E9FF0
	public void OnNotify(UITimeBar sender)
	{
	}

	// Token: 0x060020FC RID: 8444 RVA: 0x003EBDF4 File Offset: 0x003E9FF4
	public void Onfunc(UITimeBar sender)
	{
	}

	// Token: 0x060020FD RID: 8445 RVA: 0x003EBDF8 File Offset: 0x003E9FF8
	public void OnCancel(UITimeBar sender)
	{
	}

	// Token: 0x060020FE RID: 8446 RVA: 0x003EBDFC File Offset: 0x003E9FFC
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 1:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 2:
			this.door.GoToPointCode(DataManager.MapDataController.OtherKingdomData.kingdomID, this.DM.MarchEventData[(int)this.tmpData.Index].Point.zoneID, this.DM.MarchEventData[(int)this.tmpData.Index].Point.pointID, 0);
			break;
		case 3:
			if (this.m_Effect >= 4)
			{
				this.door.GoToPointCode(this.DM.m_WTInfo_KID, this.DM.m_WT_Point.zoneID, this.DM.m_WT_Point.pointID, 0);
			}
			break;
		case 4:
			this.door.OpenMenu(EGUIWindow.UI_BuffList, 2, 0, false);
			break;
		case 5:
			if (this.m_Effect >= 4 && this.DM.m_WT_Name != null && this.DM.m_WT_Name != string.Empty)
			{
				DataManager.Instance.ShowLordProfile(this.DM.m_WT_Name);
			}
			break;
		}
	}

	// Token: 0x060020FF RID: 8447 RVA: 0x003EBF6C File Offset: 0x003EA16C
	private void Start()
	{
	}

	// Token: 0x06002100 RID: 8448 RVA: 0x003EBF70 File Offset: 0x003EA170
	private void Update()
	{
		if (this.bOpen && this.text_TimeBar != null)
		{
			this.CheckEffect();
			this.bOpen = false;
		}
		if (this.ImgShowMain[0] != null && this.ImgShowMain[0].IsActive())
		{
			this.ShowTime += Time.smoothDeltaTime;
			if (this.ShowTime >= 0f)
			{
				if (this.ShowTime >= 2f)
				{
					this.ShowTime = 0f;
				}
				float a = (this.ShowTime <= 1f) ? this.ShowTime : (2f - this.ShowTime);
				this.ImgShowMain[1].color = new Color(1f, 1f, 1f, a);
			}
		}
	}

	// Token: 0x06002101 RID: 8449 RVA: 0x003EC054 File Offset: 0x003EA254
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			this.CheckEffect();
			break;
		case 2:
			if (this.m_Effect >= 7 && arg2 == this.DM.m_WTList_Idx)
			{
				long beginTime = this.DM.tmp_WatchTowerData[(int)this.DM.m_WatchTowerData[this.DM.m_WTList_Idx].ListIdx].MarchTimeData.BeginTime;
				long target = beginTime + (long)((ulong)this.DM.tmp_WatchTowerData[(int)this.DM.m_WatchTowerData[this.DM.m_WTList_Idx].ListIdx].MarchTimeData.RequireTime);
				this.GUIM.SetTimerBar(this.timeBar, beginTime, target, 0L, eTimeBarType.NormalType, this.DM.mStringTable.GetStringByID(3985u), string.Empty);
			}
			break;
		case 3:
			if (arg2 == this.DM.m_WTList_Idx)
			{
				this.text_TimeBar.gameObject.SetActive(true);
				this.text_TimeBar.text = this.DM.mStringTable.GetStringByID(5776u);
				this.text_TimeBar.alignment = TextAnchor.UpperCenter;
				this.timeBar.gameObject.SetActive(false);
			}
			break;
		}
	}

	// Token: 0x06002102 RID: 8450 RVA: 0x003EC1C8 File Offset: 0x003EA3C8
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
				if (this.tmpPanel != null)
				{
					this.tmpPanel.Refresh_FontTexture();
				}
				if (this.timeBar != null && this.timeBar.enabled)
				{
					this.timeBar.Refresh_FontTexture();
				}
			}
			break;
		}
	}

	// Token: 0x06002103 RID: 8451 RVA: 0x003EC250 File Offset: 0x003EA450
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Title2 != null && this.text_Title2.enabled)
		{
			this.text_Title2.enabled = false;
			this.text_Title2.enabled = true;
		}
		if (this.text_Drop != null && this.text_Drop.enabled)
		{
			this.text_Drop.enabled = false;
			this.text_Drop.enabled = true;
		}
		if (this.text_MainHero != null && this.text_MainHero.enabled)
		{
			this.text_MainHero.enabled = false;
			this.text_MainHero.enabled = true;
		}
		if (this.text_NoTroops != null && this.text_NoTroops.enabled)
		{
			this.text_NoTroops.enabled = false;
			this.text_NoTroops.enabled = true;
		}
		if (this.text_TimeBar != null && this.text_TimeBar.enabled)
		{
			this.text_TimeBar.enabled = false;
			this.text_TimeBar.enabled = true;
		}
		if (this.text_Time != null && this.text_Time.enabled)
		{
			this.text_Time.enabled = false;
			this.text_Time.enabled = true;
		}
		if (this.text_btnStr != null && this.text_Time.enabled)
		{
			this.text_btnStr.enabled = false;
			this.text_btnStr.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_PlayerName[i] != null && this.text_PlayerName[i].enabled)
			{
				this.text_PlayerName[i].enabled = false;
				this.text_PlayerName[i].enabled = true;
			}
			if (this.text_btnCoordinate[i] != null && this.text_btnCoordinate[i].enabled)
			{
				this.text_btnCoordinate[i].enabled = false;
				this.text_btnCoordinate[i].enabled = true;
			}
			if (this.text_tmpStr[i] != null && this.text_tmpStr[i].enabled)
			{
				this.text_tmpStr[i].enabled = false;
				this.text_tmpStr[i].enabled = true;
			}
			if (this.text_tmptimeBar[i] != null && this.text_tmptimeBar[i].enabled)
			{
				this.text_tmptimeBar[i].enabled = false;
				this.text_tmptimeBar[i].enabled = true;
			}
		}
	}

	// Token: 0x04006807 RID: 26631
	private DataManager DM;

	// Token: 0x04006808 RID: 26632
	private GUIManager GUIM;

	// Token: 0x04006809 RID: 26633
	private Transform Tmp;

	// Token: 0x0400680A RID: 26634
	private Transform CustomPanelT;

	// Token: 0x0400680B RID: 26635
	private RectTransform tmpRC;

	// Token: 0x0400680C RID: 26636
	private RectTransform[] Coordinate1_RT = new RectTransform[3];

	// Token: 0x0400680D RID: 26637
	private RectTransform[] Coordinate2_RT = new RectTransform[3];

	// Token: 0x0400680E RID: 26638
	private UIButton btn_EXIT;

	// Token: 0x0400680F RID: 26639
	private UIButton btn_Coordinate_1;

	// Token: 0x04006810 RID: 26640
	private UIButton btn_Coordinate_2;

	// Token: 0x04006811 RID: 26641
	private UIButton btn_Prepare;

	// Token: 0x04006812 RID: 26642
	private UIButton btn_Hero;

	// Token: 0x04006813 RID: 26643
	private Image Img_Status;

	// Token: 0x04006814 RID: 26644
	private Image Img_Lock;

	// Token: 0x04006815 RID: 26645
	private Image Img_NoHero;

	// Token: 0x04006816 RID: 26646
	private Image Img_Hero;

	// Token: 0x04006817 RID: 26647
	private Image Img_HeroBG;

	// Token: 0x04006818 RID: 26648
	private Image Img_HeroFrame;

	// Token: 0x04006819 RID: 26649
	private Image Img_Drop;

	// Token: 0x0400681A RID: 26650
	private Image[] ImgShowMain = new Image[2];

	// Token: 0x0400681B RID: 26651
	private Sprite[] ImgList = new Sprite[15];

	// Token: 0x0400681C RID: 26652
	private UIText text_Title;

	// Token: 0x0400681D RID: 26653
	private UIText text_Title2;

	// Token: 0x0400681E RID: 26654
	private UIText text_Drop;

	// Token: 0x0400681F RID: 26655
	private UIText text_MainHero;

	// Token: 0x04006820 RID: 26656
	private UIText text_NoTroops;

	// Token: 0x04006821 RID: 26657
	private UIText text_TimeBar;

	// Token: 0x04006822 RID: 26658
	private UIText text_Time;

	// Token: 0x04006823 RID: 26659
	private UIText text_btnStr;

	// Token: 0x04006824 RID: 26660
	private UIText[] text_PlayerName = new UIText[2];

	// Token: 0x04006825 RID: 26661
	private UIText[] text_btnCoordinate = new UIText[2];

	// Token: 0x04006826 RID: 26662
	private UIText[] text_tmpStr = new UIText[2];

	// Token: 0x04006827 RID: 26663
	private UIText[] text_tmptimeBar = new UIText[2];

	// Token: 0x04006828 RID: 26664
	private CString Cstr_Title;

	// Token: 0x04006829 RID: 26665
	private CString[] Cstr_PlayerName = new CString[2];

	// Token: 0x0400682A RID: 26666
	private CString[] Cstr_btnCoordinate = new CString[2];

	// Token: 0x0400682B RID: 26667
	private UITimeBar timeBar;

	// Token: 0x0400682C RID: 26668
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x0400682D RID: 26669
	private Door door;

	// Token: 0x0400682E RID: 26670
	private Material door_M;

	// Token: 0x0400682F RID: 26671
	private Color R_Color = new Color(1f, 0.2941f, 0.4588f, 1f);

	// Token: 0x04006830 RID: 26672
	private RoleBuildingData mBD;

	// Token: 0x04006831 RID: 26673
	private int mStatus;

	// Token: 0x04006832 RID: 26674
	private ushort m_Effect;

	// Token: 0x04006833 RID: 26675
	private ushort[] stringStatus1 = new ushort[13];

	// Token: 0x04006834 RID: 26676
	private ushort[] stringStatus2 = new ushort[15];

	// Token: 0x04006835 RID: 26677
	private bool bHaveTroops = true;

	// Token: 0x04006836 RID: 26678
	private bool bOpen;

	// Token: 0x04006837 RID: 26679
	private float ShowTime;

	// Token: 0x04006838 RID: 26680
	private List<int> _DataIdx = new List<int>();

	// Token: 0x04006839 RID: 26681
	private CustomPanel tmpPanel;

	// Token: 0x0400683A RID: 26682
	private Vector2 tmpV;

	// Token: 0x0400683B RID: 26683
	private WatchTowerData tmpData;

	// Token: 0x0400683C RID: 26684
	private UISpritesArray SArray;

	// Token: 0x0400683D RID: 26685
	private bool bYolk;
}
