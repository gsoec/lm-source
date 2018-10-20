using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006BB RID: 1723
public class UIWatchtower : GUIWindow, IBuildingWindowType, IUpDateScrollPanel, IUIButtonClickHandler, IUTimeBarOnTimer
{
	// Token: 0x060020E7 RID: 8423 RVA: 0x003E7418 File Offset: 0x003E5618
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.mBD = this.GUIM.BuildingData.GetBuildData(13, 0);
		this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData(13, this.mBD.Level);
		this.m_Effect = (ushort)this.mBR.Level;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.AssetName = "BuildingWindow";
		Transform transform = base.gameObject.transform;
		this.SArray = transform.GetComponent<UISpritesArray>();
		this.ImgList[0] = this.SArray.m_Sprites[1];
		this.ImgList[1] = this.SArray.m_Sprites[1];
		this.ImgList[2] = this.SArray.m_Sprites[5];
		this.ImgList[3] = this.SArray.m_Sprites[0];
		this.ImgList[4] = this.SArray.m_Sprites[4];
		this.ImgList[5] = this.SArray.m_Sprites[3];
		this.ImgList[6] = this.SArray.m_Sprites[2];
		this.ImgList[7] = this.SArray.m_Sprites[6];
		this.ImgList[8] = this.SArray.m_Sprites[7];
		this.ImgList[9] = this.SArray.m_Sprites[8];
		this.ImgList[10] = this.SArray.m_Sprites[9];
		this.ImgList[11] = this.SArray.m_Sprites[10];
		this.ImgList[12] = this.SArray.m_Sprites[11];
		this.ImgList[13] = this.SArray.m_Sprites[12];
		this.mStrStatus[0] = this.DM.mStringTable.GetStringByID(4982u);
		this.mStrStatus[1] = this.DM.mStringTable.GetStringByID(3978u);
		this.mStrStatus[2] = this.DM.mStringTable.GetStringByID(3852u);
		this.mStrStatus[3] = this.DM.mStringTable.GetStringByID(3979u);
		this.mStrStatus[4] = this.DM.mStringTable.GetStringByID(3980u);
		this.mStrStatus[5] = this.DM.mStringTable.GetStringByID(5804u);
		this.mStrStatus[6] = this.DM.mStringTable.GetStringByID(3981u);
		this.mStrStatus[7] = this.DM.mStringTable.GetStringByID(3982u);
		this.mStrStatus[8] = this.DM.mStringTable.GetStringByID(3983u);
		this.mStrStatus[9] = this.DM.mStringTable.GetStringByID(9744u);
		this.mStrStatus[10] = this.DM.mStringTable.GetStringByID(9760u);
		this.mStrStatus[11] = this.DM.mStringTable.GetStringByID(9764u);
		this.mStrStatus[12] = this.DM.mStringTable.GetStringByID(9765u);
		this.mStrStatus[13] = this.DM.mStringTable.GetStringByID(9920u);
		this.mStrStatus[14] = this.DM.mStringTable.GetStringByID(12100u);
		for (int i = 0; i < 6; i++)
		{
			this.Cstr_textCoordinate[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_Status[i] = StringManager.Instance.SpawnString(30);
		}
		this.Tmp = transform.GetChild(0);
		this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
		Transform child = transform.GetChild(1);
		this.text_No = transform.GetChild(2).GetComponent<UIText>();
		this.text_No.font = this.TTFont;
		this.text_No.text = this.DM.mStringTable.GetStringByID(3975u);
		this.tmpImg = child.GetChild(1).GetChild(0).GetComponent<Image>();
		this.tmpImg.sprite = this.ImgList[0];
		this.timeBar = child.GetChild(2).GetComponent<UITimeBar>();
		this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.NormalType, string.Empty, string.Empty);
		this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
		this.timeBar.m_Handler = this;
		this.timeBar.m_TimeBarID = 1;
		this.tmptext = child.GetChild(3).GetChild(1).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmpbtn = child.GetChild(4).GetChild(0).GetComponent<UIButton>();
		this.tmpbtn.m_Handler = this;
		this.tmpbtn.m_BtnID1 = 1;
		this.tmptext = child.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext.text = this.DM.mStringTable.GetStringByID(3976u);
		this.tmpbtn = child.GetChild(4).GetChild(1).GetComponent<UIButton>();
		this.tmpbtn.m_Handler = this;
		this.tmpbtn.m_BtnID1 = 2;
		this.tmptext = child.GetChild(4).GetChild(1).GetChild(1).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = child.GetChild(4).GetChild(2).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmplist.Clear();
		for (int j = 0; j < this.DM.m_WatchTowerData.Count; j++)
		{
			this.tmplist.Add(112f);
		}
		this.m_ScrollPanel.IntiScrollPanel(490f, 0f, 0f, this.tmplist, 6, this);
		this.m_ScrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
		this.B_ID = arg1;
		if (this.DM.m_WatchTowerData.Count > 0)
		{
			this.text_No.gameObject.SetActive(false);
		}
		else
		{
			this.bWatch = false;
			this.m_ScrollPanel.gameObject.SetActive(false);
			this.text_No.gameObject.SetActive(true);
		}
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x060020E8 RID: 8424 RVA: 0x003E7AE0 File Offset: 0x003E5CE0
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		if (this.AssetName != null)
		{
			this.GUIM.RemoveSpriteAsset(this.AssetName);
		}
		this.tmplist = null;
		if (this.timeBar != null)
		{
			this.GUIM.RemoverTimeBaarToList(this.timeBar);
		}
		for (int i = 0; i < 6; i++)
		{
			if (this.Item_timebar[i] != null)
			{
				this.GUIM.RemoverTimeBaarToList(this.Item_timebar[i]);
			}
			if (this.Cstr_textCoordinate[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_textCoordinate[i]);
			}
			if (this.Cstr_Status[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Status[i]);
			}
		}
	}

	// Token: 0x060020E9 RID: 8425 RVA: 0x003E7BC8 File Offset: 0x003E5DC8
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
		{
			if (this.bWatch)
			{
				this.text_No.gameObject.SetActive(false);
				this.m_ScrollPanel.gameObject.SetActive(true);
			}
			else
			{
				this.text_No.gameObject.SetActive(true);
				this.m_ScrollPanel.gameObject.SetActive(false);
			}
		}
		else
		{
			this.text_No.gameObject.SetActive(false);
			this.m_ScrollPanel.gameObject.SetActive(false);
			this.m_ScrollRect.StopMovement();
		}
	}

	// Token: 0x060020EA RID: 8426 RVA: 0x003E7C70 File Offset: 0x003E5E70
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID != 1)
		{
			if (btnID == 2)
			{
				int num = (int)(this.DM.m_WatchTowerData[sender.m_BtnID2].ListIdx - 1u);
				this.door.GoToPointCode(DataManager.MapDataController.OtherKingdomData.kingdomID, this.DM.MarchEventData[num].Point.zoneID, this.DM.MarchEventData[num].Point.pointID, 0);
			}
		}
		else
		{
			this.Tmp = sender.gameObject.transform.parent;
			int num2 = (int)(this.DM.m_WatchTowerData[sender.m_BtnID2].ListIdx - 1u);
			this.door.GoToGroup((int)(this.DM.mtmpIdx[num2].LineID - 1u), 0, true);
		}
	}

	// Token: 0x060020EB RID: 8427 RVA: 0x003E7D70 File Offset: 0x003E5F70
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.ItemT[panelObjectIdx] == null)
		{
			this.ItemT[panelObjectIdx] = item.GetComponent<Transform>();
			this.mScrollItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			this.Item_ImgIcon[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(1).GetChild(0).GetComponent<Image>();
			this.Item_timebar[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(2).GetComponent<UITimeBar>();
			this.Item_timebar[panelObjectIdx].m_Handler = this;
			this.Item_timebar[panelObjectIdx].m_ListID = 0;
			this.Item_timebar[panelObjectIdx].gameObject.SetActive(false);
			this.Item_textTimebar1[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(2).GetChild(2).GetComponent<UIText>();
			this.Item_textTimebar2[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(2).GetChild(3).GetComponent<UIText>();
			this.Item_StausT1[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(3).GetComponent<Transform>();
			this.Item_Img[panelObjectIdx] = this.Item_StausT1[panelObjectIdx].GetChild(0).GetComponent<Image>();
			this.Item_textStatus[panelObjectIdx] = this.Item_StausT1[panelObjectIdx].GetChild(1).GetComponent<UIText>();
			this.Item_StausT2[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(4).GetComponent<Transform>();
			this.Item_btnTroops[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(0).GetComponent<UIButton>();
			this.Item_btnTroops[panelObjectIdx].m_Handler = this;
			this.Item_btnTroops[panelObjectIdx].m_BtnID2 = dataIdx;
			this.Item_btnCoordinate[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(1).GetComponent<UIButton>();
			this.Item_btnCoordinate[panelObjectIdx].m_Handler = this;
			this.Item_btnCoordinate[panelObjectIdx].m_BtnID2 = dataIdx;
			this.Item_btn_CRT[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(1).GetComponent<RectTransform>();
			this.Item_Img_CRT[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(1).GetChild(0).GetComponent<RectTransform>();
			this.Item_text[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<UIText>();
			this.Item_textCoordinate[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(1).GetChild(1).GetComponent<UIText>();
			this.Item_textStatus_C[panelObjectIdx] = this.Item_StausT2[panelObjectIdx].GetChild(2).GetComponent<UIText>();
		}
		else if (this.DM.m_WatchTowerData.Count > dataIdx)
		{
			if (this.mScrollItem[panelObjectIdx].m_BtnID2 == 1)
			{
				this.Item_StausT1[panelObjectIdx].gameObject.SetActive(false);
			}
			else
			{
				this.Item_StausT2[panelObjectIdx].gameObject.SetActive(false);
			}
		}
		if (this.DM.m_WatchTowerData[dataIdx].LineType > 0)
		{
			this.mScrollItem[panelObjectIdx].m_BtnID2 = 1;
			int num = (int)this.DM.m_WatchTowerData[dataIdx].ListIdx;
			this.Item_StausT1[panelObjectIdx].gameObject.SetActive(true);
			if (this.m_Effect >= 7)
			{
				this.begin = this.DM.tmp_WatchTowerData[num].MarchTimeData.BeginTime;
				this.target = this.begin + (long)((ulong)this.DM.tmp_WatchTowerData[num].MarchTimeData.RequireTime);
				this.GUIM.SetTimerBar(this.Item_timebar[panelObjectIdx], this.begin, this.target, 0L, eTimeBarType.NormalType, this.DM.mStringTable.GetStringByID(3985u).ToString(), string.Empty);
				this.Item_timebar[panelObjectIdx].gameObject.SetActive(true);
			}
			bool flag = false;
			if (this.DM.tmp_WatchTowerData[num].Index >= 0 && this.DM.tmp_WatchTowerData[num].Index <= 7 && this.DM.MarchEventData[(int)this.DM.tmp_WatchTowerData[num].Index].PointKind == POINT_KIND.PK_YOLK)
			{
				flag = true;
			}
			switch (this.DM.m_WatchTowerData[dataIdx].LineType)
			{
			case 5:
			case 7:
				if (flag)
				{
					this.Cstr_Status[panelObjectIdx].ClearString();
					this.Cstr_Status[panelObjectIdx].StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.DM.MarchEventData[(int)this.DM.tmp_WatchTowerData[num].Index].DesPointLevel, 0));
					this.Cstr_Status[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(8549u));
					this.Item_textStatus[panelObjectIdx].text = this.Cstr_Status[panelObjectIdx].ToString();
					this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[9];
				}
				else
				{
					this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[1];
					if (this.DM.tmp_WatchTowerData[num].Index == 255)
					{
						this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[1];
					}
					else if (this.DM.tmp_WatchTowerData[num].Index >= 0 && this.DM.tmp_WatchTowerData[num].Index <= 7 && this.DM.MarchEventData[(int)this.DM.tmp_WatchTowerData[num].Index].IsAmbushCamp())
					{
						this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[10];
					}
					else
					{
						this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[2];
					}
				}
				break;
			case 6:
				if (this.DM.tmp_WatchTowerData[num].Index == 255)
				{
					this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[12];
					this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[9];
				}
				else if (flag)
				{
					this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[5];
					this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[13];
				}
				break;
			case 8:
				if (flag)
				{
					this.Cstr_Status[panelObjectIdx].ClearString();
					this.Cstr_Status[panelObjectIdx].StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.DM.MarchEventData[(int)this.DM.tmp_WatchTowerData[num].Index].DesPointLevel, 0));
					this.Cstr_Status[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(8550u));
					this.Item_textStatus[panelObjectIdx].text = this.Cstr_Status[panelObjectIdx].ToString();
					this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[10];
				}
				else
				{
					this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[3];
					if (this.DM.tmp_WatchTowerData[num].Index == 255)
					{
						this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[4];
					}
					else if (this.DM.tmp_WatchTowerData[num].Index >= 0 && this.DM.tmp_WatchTowerData[num].Index <= 7 && this.DM.MarchEventData[(int)this.DM.tmp_WatchTowerData[num].Index].IsAmbushCamp())
					{
						this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[12];
					}
					else
					{
						this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[5];
					}
				}
				break;
			case 10:
				if (flag)
				{
					this.Cstr_Status[panelObjectIdx].ClearString();
					this.Cstr_Status[panelObjectIdx].StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.DM.MarchEventData[(int)this.DM.tmp_WatchTowerData[num].Index].DesPointLevel, 0));
					this.Cstr_Status[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(8551u));
					this.Item_textStatus[panelObjectIdx].text = this.Cstr_Status[panelObjectIdx].ToString();
					this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[11];
				}
				else
				{
					this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[5];
					this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[7];
				}
				break;
			case 11:
				this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[4];
				this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[6];
				break;
			case 12:
				if (flag)
				{
					this.Cstr_Status[panelObjectIdx].ClearString();
					this.Cstr_Status[panelObjectIdx].StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.DM.MarchEventData[(int)this.DM.tmp_WatchTowerData[num].Index].DesPointLevel, 0));
					this.Cstr_Status[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(8548u));
					this.Item_textStatus[panelObjectIdx].text = this.Cstr_Status[panelObjectIdx].ToString();
					this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[8];
				}
				else
				{
					if (this.DM.tmp_WatchTowerData[num].Index >= 0 && this.DM.tmp_WatchTowerData[num].Index <= 7 && this.DM.MarchEventData[(int)this.DM.tmp_WatchTowerData[num].Index].IsAmbushCamp())
					{
						this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[11];
					}
					else
					{
						this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[0];
					}
					this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[7];
				}
				break;
			case 13:
				this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[6];
				this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[8];
				break;
			case 22:
				this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[13];
				this.Item_textStatus[panelObjectIdx].text = this.mStrStatus[14];
				break;
			}
			this.Item_textStatus[panelObjectIdx].SetAllDirty();
			this.Item_textStatus[panelObjectIdx].cachedTextGenerator.Invalidate();
		}
		else
		{
			this.Item_btnTroops[panelObjectIdx].m_BtnID2 = dataIdx;
			this.Item_btnCoordinate[panelObjectIdx].m_BtnID2 = dataIdx;
			this.Item_ImgIcon[panelObjectIdx].sprite = this.ImgList[2];
			this.Item_textStatus_C[panelObjectIdx].text = this.mStrStatus[3];
			int num = (int)(this.DM.m_WatchTowerData[dataIdx].ListIdx - 1u);
			if (this.m_Effect >= 7)
			{
				this.begin = this.DM.MarchEventTime[num].BeginTime;
				this.target = this.begin + (long)((ulong)this.DM.MarchEventTime[num].RequireTime);
				this.GUIM.SetTimerBar(this.Item_timebar[panelObjectIdx], this.begin, this.target, 0L, eTimeBarType.NormalType, this.DM.mStringTable.GetStringByID(3985u).ToString(), string.Empty);
				this.Item_timebar[panelObjectIdx].gameObject.SetActive(true);
			}
			this.mScrollItem[panelObjectIdx].m_BtnID2 = 2;
			this.Item_StausT2[panelObjectIdx].gameObject.SetActive(true);
			this.Cstr_textCoordinate[1].ClearString();
			this.tmpV2 = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.DM.MarchEventData[num].Point.zoneID, this.DM.MarchEventData[num].Point.pointID));
			this.Cstr_textCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(4505u));
			this.Cstr_textCoordinate[1].IntToFormat((long)((int)this.tmpV2.x), 1, false);
			this.Cstr_textCoordinate[1].StringToFormat(this.DM.mStringTable.GetStringByID(4506u));
			this.Cstr_textCoordinate[1].IntToFormat((long)((int)this.tmpV2.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_textCoordinate[1].AppendFormat("{3}{2} {1}{0}");
			}
			else
			{
				this.Cstr_textCoordinate[1].AppendFormat("{0}{1} {2}{3}");
			}
			this.Item_textCoordinate[panelObjectIdx].text = this.Cstr_textCoordinate[1].ToString();
			this.Item_textCoordinate[panelObjectIdx].SetAllDirty();
			this.Item_textCoordinate[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.Item_btn_CRT[panelObjectIdx].sizeDelta = new Vector2(this.Item_textCoordinate[panelObjectIdx].preferredWidth, this.Item_btn_CRT[panelObjectIdx].sizeDelta.y);
			this.Item_Img_CRT[panelObjectIdx].sizeDelta = new Vector2(this.Item_textCoordinate[panelObjectIdx].preferredWidth, this.Item_Img_CRT[panelObjectIdx].sizeDelta.y);
		}
		this.Item_ImgIcon[panelObjectIdx].SetNativeSize();
	}

	// Token: 0x060020EC RID: 8428 RVA: 0x003E8BEC File Offset: 0x003E6DEC
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		if (this.DM.m_WatchTowerData.Count > 0 && dataIndex > -1 && dataIndex < this.DM.m_WatchTowerData.Count)
		{
			if (this.DM.m_WatchTowerData[dataIndex].LineType > 0)
			{
				if (this.mBD.Level >= 4)
				{
					if (this.GUIM.ShowUILock(EUILock.WatchTower))
					{
						MessagePacket messagePacket = new MessagePacket(1024);
						messagePacket.Protocol = Protocol._MSG_REQUEST_WATCHTOWER_LINEDETAIL;
						messagePacket.AddSeqId();
						messagePacket.Add(this.DM.tmp_WatchTowerData[(int)this.DM.m_WatchTowerData[dataIndex].ListIdx].LineID);
						messagePacket.Send(false);
						this.DM.m_WTList_Idx = dataIndex;
					}
				}
				else
				{
					this.DM.m_WTList_Idx = dataIndex;
					this.door.OpenMenu(EGUIWindow.UI_Watchtower_Details, (int)this.DM.m_WatchTowerData[dataIndex].LineType, (int)this.mBD.Level, false);
				}
			}
			else
			{
				int num = (int)(this.DM.m_WatchTowerData[dataIndex].ListIdx - 1u);
				this.door.GoToPointCode(DataManager.MapDataController.OtherKingdomData.kingdomID, this.DM.MarchEventData[num].Point.zoneID, this.DM.MarchEventData[num].Point.pointID, 0);
			}
		}
	}

	// Token: 0x060020ED RID: 8429 RVA: 0x003E8D90 File Offset: 0x003E6F90
	public void OnTimer(UITimeBar sender)
	{
	}

	// Token: 0x060020EE RID: 8430 RVA: 0x003E8D94 File Offset: 0x003E6F94
	public void OnNotify(UITimeBar sender)
	{
	}

	// Token: 0x060020EF RID: 8431 RVA: 0x003E8D98 File Offset: 0x003E6F98
	public void Onfunc(UITimeBar sender)
	{
	}

	// Token: 0x060020F0 RID: 8432 RVA: 0x003E8D9C File Offset: 0x003E6F9C
	public void OnCancel(UITimeBar sender)
	{
	}

	// Token: 0x060020F1 RID: 8433 RVA: 0x003E8DA0 File Offset: 0x003E6FA0
	private void Start()
	{
		this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		byte level = this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level;
		this.baseBuild.InitBuildingWindow(13, (ushort)this.B_ID, 1, level);
		this.baseBuild.baseTransform.SetAsFirstSibling();
	}

	// Token: 0x060020F2 RID: 8434 RVA: 0x003E8E18 File Offset: 0x003E7018
	private void Update()
	{
	}

	// Token: 0x060020F3 RID: 8435 RVA: 0x003E8E1C File Offset: 0x003E701C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews != NetworkNews.Refresh_BuildBase)
			{
				if (networkNews != NetworkNews.Refresh_AttribEffectVal)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						this.Refresh_FontTexture();
						if (this.baseBuild != null)
						{
							this.baseBuild.Refresh_FontTexture();
						}
						if (this.timeBar != null && this.timeBar.enabled)
						{
							this.timeBar.Refresh_FontTexture();
						}
						for (int i = 0; i < 6; i++)
						{
							if (this.Item_timebar[i] != null && this.Item_timebar[i].enabled)
							{
								this.Item_timebar[i].Refresh_FontTexture();
							}
						}
					}
				}
				else if (this.baseBuild != null)
				{
					this.baseBuild.MyUpdate(0, false);
				}
			}
			else
			{
				this.mBD = this.GUIM.BuildingData.GetBuildData(13, 0);
				this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData(13, this.mBD.Level);
				if (meg[1] == 1)
				{
					this.door.CloseMenu(true);
				}
				else if (this.baseBuild != null)
				{
					this.baseBuild.MyUpdate(meg[1], false);
				}
			}
			break;
		}
	}

	// Token: 0x060020F4 RID: 8436 RVA: 0x003E8F98 File Offset: 0x003E7198
	public void Refresh_FontTexture()
	{
		if (this.text_No != null && this.text_No.enabled)
		{
			this.text_No.enabled = false;
			this.text_No.enabled = true;
		}
		for (int i = 0; i < 6; i++)
		{
			if (this.Item_textCoordinate[i] != null && this.Item_textCoordinate[i].enabled)
			{
				this.Item_textCoordinate[i].enabled = false;
				this.Item_textCoordinate[i].enabled = true;
			}
			if (this.Item_textStatus[i] != null && this.Item_textStatus[i].enabled)
			{
				this.Item_textStatus[i].enabled = false;
				this.Item_textStatus[i].enabled = true;
			}
			if (this.Item_textStatus_C[i] != null && this.Item_textStatus_C[i].enabled)
			{
				this.Item_textStatus_C[i].enabled = false;
				this.Item_textStatus_C[i].enabled = true;
			}
			if (this.Item_text[i] != null && this.Item_text[i].enabled)
			{
				this.Item_text[i].enabled = false;
				this.Item_text[i].enabled = true;
			}
			if (this.Item_textTimebar1[i] != null && this.Item_textTimebar1[i].enabled)
			{
				this.Item_textTimebar1[i].enabled = false;
				this.Item_textTimebar1[i].enabled = true;
			}
			if (this.Item_textTimebar2[i] != null && this.Item_textTimebar2[i].enabled)
			{
				this.Item_textTimebar2[i].enabled = false;
				this.Item_textTimebar2[i].enabled = true;
			}
		}
	}

	// Token: 0x060020F5 RID: 8437 RVA: 0x003E9178 File Offset: 0x003E7378
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
		{
			int topIdx = this.m_ScrollPanel.GetTopIdx();
			this.tmplist.Clear();
			if (this.DM.m_WatchTowerData.Count == 0)
			{
				this.bWatch = false;
				if (this.baseBuild.buildType == e_BuildType.Normal || this.baseBuild.buildType == e_BuildType.SelfUpgradeing || this.baseBuild.buildType == e_BuildType.SelfBackOuting)
				{
					this.text_No.gameObject.SetActive(true);
				}
				this.m_ScrollPanel.gameObject.SetActive(false);
			}
			else
			{
				this.bWatch = true;
				for (int i = 0; i < this.DM.m_WatchTowerData.Count; i++)
				{
					this.tmplist.Add(112f);
				}
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
				if (topIdx > 1)
				{
					this.m_ScrollPanel.GoTo(topIdx + 1);
				}
				if (this.text_No.IsActive())
				{
					this.text_No.gameObject.SetActive(false);
					if (this.baseBuild.buildType == e_BuildType.Normal || this.baseBuild.buildType == e_BuildType.SelfUpgradeing || this.baseBuild.buildType == e_BuildType.SelfBackOuting)
					{
						this.m_ScrollPanel.gameObject.SetActive(true);
					}
				}
			}
			break;
		}
		case 2:
			if (this.DM.m_WTList_Idx != -1)
			{
				this.door.OpenMenu(EGUIWindow.UI_Watchtower_Details, this.DM.m_WTInfo_Status, (int)this.mBD.Level, false);
			}
			break;
		case 3:
			for (int j = 0; j < 6; j++)
			{
				if (this.mScrollItem[j] != null && this.mScrollItem[j].m_BtnID1 != -1)
				{
					int btnID = this.mScrollItem[j].m_BtnID1;
					int listIdx = (int)this.DM.m_WatchTowerData[btnID].ListIdx;
					if (this.mScrollItem[j].m_BtnID2 == 1 && this.m_Effect >= 7 && listIdx == arg2)
					{
						this.begin = this.DM.tmp_WatchTowerData[listIdx].MarchTimeData.BeginTime;
						this.target = this.begin + (long)((ulong)this.DM.tmp_WatchTowerData[listIdx].MarchTimeData.RequireTime);
						this.GUIM.SetTimerBar(this.Item_timebar[j], this.begin, this.target, 0L, eTimeBarType.NormalType, this.DM.mStringTable.GetStringByID(3985u).ToString(), string.Empty);
					}
				}
			}
			break;
		}
	}

	// Token: 0x040067C4 RID: 26564
	private DataManager DM;

	// Token: 0x040067C5 RID: 26565
	private GUIManager GUIM;

	// Token: 0x040067C6 RID: 26566
	private Transform Tmp;

	// Token: 0x040067C7 RID: 26567
	private Transform[] ItemT = new Transform[6];

	// Token: 0x040067C8 RID: 26568
	private Transform[] Item_StausT1 = new Transform[6];

	// Token: 0x040067C9 RID: 26569
	private Transform[] Item_StausT2 = new Transform[6];

	// Token: 0x040067CA RID: 26570
	private RectTransform[] Item_btn_CRT = new RectTransform[6];

	// Token: 0x040067CB RID: 26571
	private RectTransform[] Item_Img_CRT = new RectTransform[6];

	// Token: 0x040067CC RID: 26572
	private UIButton tmpbtn;

	// Token: 0x040067CD RID: 26573
	private UIButton[] Item_btnTroops = new UIButton[6];

	// Token: 0x040067CE RID: 26574
	private UIButton[] Item_btnCoordinate = new UIButton[6];

	// Token: 0x040067CF RID: 26575
	private Image tmpImg;

	// Token: 0x040067D0 RID: 26576
	private Image[] Item_ImgIcon = new Image[6];

	// Token: 0x040067D1 RID: 26577
	private Image[] Item_Img = new Image[6];

	// Token: 0x040067D2 RID: 26578
	private Sprite[] ImgList = new Sprite[14];

	// Token: 0x040067D3 RID: 26579
	private UIText tmptext;

	// Token: 0x040067D4 RID: 26580
	private UIText text_No;

	// Token: 0x040067D5 RID: 26581
	private UIText[] Item_textCoordinate = new UIText[6];

	// Token: 0x040067D6 RID: 26582
	private UIText[] Item_textStatus = new UIText[6];

	// Token: 0x040067D7 RID: 26583
	private UIText[] Item_textStatus_C = new UIText[6];

	// Token: 0x040067D8 RID: 26584
	private UIText[] Item_text = new UIText[6];

	// Token: 0x040067D9 RID: 26585
	private UIText[] Item_textTimebar1 = new UIText[6];

	// Token: 0x040067DA RID: 26586
	private UIText[] Item_textTimebar2 = new UIText[6];

	// Token: 0x040067DB RID: 26587
	private CString[] Cstr_textCoordinate = new CString[6];

	// Token: 0x040067DC RID: 26588
	private CString[] Cstr_Status = new CString[6];

	// Token: 0x040067DD RID: 26589
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040067DE RID: 26590
	private CScrollRect m_ScrollRect;

	// Token: 0x040067DF RID: 26591
	private UITimeBar timeBar;

	// Token: 0x040067E0 RID: 26592
	private UITimeBar[] Item_timebar = new UITimeBar[6];

	// Token: 0x040067E1 RID: 26593
	private ScrollPanelItem[] mScrollItem = new ScrollPanelItem[6];

	// Token: 0x040067E2 RID: 26594
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x040067E3 RID: 26595
	private BuildingWindow baseBuild;

	// Token: 0x040067E4 RID: 26596
	private RoleBuildingData mBD;

	// Token: 0x040067E5 RID: 26597
	private BuildLevelRequest mBR;

	// Token: 0x040067E6 RID: 26598
	private int B_ID;

	// Token: 0x040067E7 RID: 26599
	private Door door;

	// Token: 0x040067E8 RID: 26600
	private string AssetName;

	// Token: 0x040067E9 RID: 26601
	public string[] mStrStatus = new string[15];

	// Token: 0x040067EA RID: 26602
	private Vector2 tmpV2 = new Vector2(0f, 0f);

	// Token: 0x040067EB RID: 26603
	private bool bWatch = true;

	// Token: 0x040067EC RID: 26604
	private long begin;

	// Token: 0x040067ED RID: 26605
	private long target;

	// Token: 0x040067EE RID: 26606
	private ushort m_Effect;

	// Token: 0x040067EF RID: 26607
	private List<float> tmplist = new List<float>();

	// Token: 0x040067F0 RID: 26608
	private UISpritesArray SArray;
}
