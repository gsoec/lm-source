using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x02000433 RID: 1075
public class UIOther : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x060015C7 RID: 5575 RVA: 0x002507BC File Offset: 0x0024E9BC
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.m_Mat = this.door.LoadMaterial();
		for (int i = 0; i < 9; i++)
		{
			this.tmpStrlist.Add(this.DM.mStringTable.GetStringByID((uint)((ushort)(7023 + i))));
		}
		this.tmpStrlist.Add(this.DM.mStringTable.GetStringByID(9016u));
		this.tmpStrlist.Add(this.DM.mStringTable.GetStringByID(16033u));
		this.tmpStrlist.Add(this.DM.mStringTable.GetStringByID(963u));
		this.tmpStrlist.Add(this.DM.mStringTable.GetStringByID(12178u));
		this.tmpStrlist.Add(this.DM.mStringTable.GetStringByID(10148u));
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Ukr)
		{
			this.tmpStrlist[7] = this.DM.mStringTable.GetStringByID(16115u);
		}
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.mListSp = new Sprite[this.SArray.m_Sprites.Length];
		for (int j = 0; j < this.SArray.m_Sprites.Length; j++)
		{
			this.mListSp[j] = this.SArray.m_Sprites[j];
		}
		this.mIdx[0] = 1;
		this.mIdx[1] = 5;
		this.mIdx[2] = 6;
		this.mIdx[3] = 2;
		this.mIdx[4] = 3;
		this.mIdx[5] = 4;
		this.mIdx[6] = 10;
		this.CheckListData();
		this.Cstr_Number = StringManager.Instance.SpawnString(30);
		this.Cstr_CDTime = StringManager.Instance.SpawnString(30);
		Transform child = this.GameT.GetChild(0).GetChild(0).GetChild(0);
		this.text_tmpStr[0] = child.GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7022u);
		this.LiveT = this.GameT.GetChild(0).GetChild(2);
		if (this.GUIM.IsArabic)
		{
			this.tmpImg = this.LiveT.GetChild(0).GetComponent<Image>();
			this.tmpImg.gameObject.AddComponent<ArabicItemTextureRot>();
			this.tmpImg = this.LiveT.GetChild(1).GetComponent<Image>();
			this.tmpImg.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.uToolBG_S = this.LiveT.GetChild(0).GetComponent<uTweenScale>();
		this.uToolBGF_S = this.LiveT.GetChild(1).GetComponent<uTweenScale>();
		this.uToolBGF_A = this.LiveT.GetChild(1).GetComponent<uTweenAlpha>();
		this.H5LiveCheckMarkT = this.GameT.GetChild(0).GetChild(3);
		this.Img_FBNum = this.GameT.GetChild(0).GetChild(4).GetComponent<Image>();
		this.text_FBNum = this.GameT.GetChild(0).GetChild(4).GetChild(0).GetComponent<UIText>();
		this.text_FBNum.font = this.TTFont;
		this.text_FBNum.text = DataManager.FBMissionDataManager.GetRewardCount().ToString();
		this.Img_FBNum.rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_FBNum.preferredWidth), this.Img_FBNum.rectTransform.sizeDelta.y);
		child = this.GameT.GetChild(1);
		this.m_ScrollPanel = child.GetComponent<ScrollPanel>();
		this.tmplist.Clear();
		child = this.GameT.GetChild(2);
		for (int k = 0; k < 3; k++)
		{
			UIButton component = child.GetChild(k).GetComponent<UIButton>();
			component.m_Handler = this;
			this.tmptext = child.GetChild(k).GetChild(1).GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			component.m_EffectType = e_EffectType.e_Scale;
			component.transition = Selectable.Transition.None;
		}
		for (int l = 0; l < this.ListCount / 3; l++)
		{
			this.tmplist.Add(120f);
		}
		if (this.ListCount % 3 > 0)
		{
			this.tmplist.Add(120f);
		}
		this.m_ScrollPanel.IntiScrollPanel(437f, 10f, 0f, this.tmplist, 5, this);
		if (this.tmpItem[2] != null)
		{
			this.LiveT.SetParent(this.tmpItem[2].transform.GetChild((int)this.mMoveNum), false);
			this.H5LiveCheckMarkT.SetParent(this.tmpItem[2].transform.GetChild((int)this.mMoveNum), false);
			this.Img_FBNum.transform.SetParent(this.tmpItem[2].transform.GetChild(1), false);
			this.Img_FBNum.gameObject.SetActive(this.bShowFB_Btn && DataManager.FBMissionDataManager.GetRewardCount() > 0);
		}
		if (this.LiveT.gameObject.activeInHierarchy && this.GUIM.StopShowLiveScale < 2)
		{
			this.uToolBG_S.enabled = true;
			this.uToolBGF_S.enabled = true;
			this.uToolBGF_A.enabled = true;
		}
		else
		{
			this.uToolBG_S.enabled = false;
			this.uToolBG_S.SetCurrentValueToStart();
			this.uToolBGF_S.enabled = false;
			this.uToolBGF_S.SetCurrentValueToStart();
			this.uToolBGF_A.enabled = false;
			this.uToolBGF_A.SetCurrentValueToStart();
		}
		if (this.GUIM.IsArabic)
		{
			this.tmpImg = this.GameT.GetChild(3).GetComponent<Image>();
			this.tmpImg.gameObject.AddComponent<ArabicItemTextureRot>();
			this.tmpImg.rectTransform.anchoredPosition = new Vector2(this.tmpImg.rectTransform.anchoredPosition.x + 275f, this.tmpImg.rectTransform.anchoredPosition.y);
		}
		child = this.GameT.GetChild(4).GetChild(1);
		this.text_CDTime = child.GetComponent<UIText>();
		this.CDTime_text_RT = child.GetComponent<RectTransform>();
		this.text_CDTime.font = this.TTFont;
		this.Cstr_CDTime.ClearString();
		this.Cstr_CDTime.IntToFormat((long)GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Hour, 2, false);
		this.Cstr_CDTime.IntToFormat((long)GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Minute, 2, false);
		this.Cstr_CDTime.AppendFormat(this.DM.mStringTable.GetStringByID(753u));
		this.text_CDTime.text = this.Cstr_CDTime.ToString();
		this.text_CDTime.SetAllDirty();
		this.text_CDTime.cachedTextGenerator.Invalidate();
		this.text_CDTime.cachedTextGeneratorForLayout.Invalidate();
		this.CDTime_text_RT.sizeDelta = new Vector2(this.text_CDTime.preferredWidth, this.CDTime_text_RT.sizeDelta.y);
		this.GiftT = this.GameT.GetChild(5);
		if (this.tmpItem[0] != null)
		{
			this.GiftT.SetParent(this.tmpItem[0].transform.GetChild(0), false);
		}
		if (!DataManager.Instance.CheckPrizeFlag(2) && IGGGameSDK.Instance.m_IGGLoginType != IGGLoginType.Facebook)
		{
			this.GiftT.gameObject.SetActive(true);
		}
		child = this.GameT.GetChild(5);
		this.text_tmpStr[1] = child.GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7048u);
		child = this.GameT.GetChild(6);
		this.text_Number = child.GetComponent<UIText>();
		this.text_Number.font = this.TTFont;
		this.Cstr_Number.ClearString();
		this.Cstr_Number.IntToFormat((long)GameConstants.Version[0], 1, false);
		this.Cstr_Number.IntToFormat((long)GameConstants.Version[1], 1, false);
		this.Cstr_Number.IntToFormat((long)GameConstants.Version[2], 1, false);
		this.Cstr_Number.AppendFormat(this.DM.mStringTable.GetStringByID(7049u));
		this.text_Number.text = this.Cstr_Number.ToString();
		child = this.GameT.GetChild(7);
		this.text_Mail = child.GetComponent<UIText>();
		this.text_Mail.font = this.TTFont;
		this.text_Mail.text = GameConstants.m_Mail[(int)this.DM.UserLanguage];
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Ukr || DataManager.Instance.UserLanguage == GameLanguage.GL_Mys)
		{
			this.text_Mail.gameObject.SetActive(false);
		}
		this.text_Mail.gameObject.SetActive(false);
		this.tmpImg = this.GameT.GetChild(8).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(8).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		if (this.GUIM.StopShowLiveScale == 0)
		{
			GUIManager guim = this.GUIM;
			guim.StopShowLiveScale += 1;
			this.GUIM.UpdateUI(EGUIWindow.Door, 20, 0);
		}
	}

	// Token: 0x060015C8 RID: 5576 RVA: 0x002512D8 File Offset: 0x0024F4D8
	public void CheckListData()
	{
		this.ListCount = 7;
		this.mMoveNum = 0;
		if (this.GUIM.BuildingData.GetBuildData(8, 0).Level >= 7)
		{
			this.mIdx[this.ListCount] = 13;
			this.mListSp[this.ListCount] = this.SArray.m_Sprites[16];
			this.ListCount++;
			this.mMoveNum += 1;
			this.bShowFB_Btn = true;
		}
		this.mIdx[this.ListCount] = 8;
		this.mListSp[this.ListCount] = this.SArray.m_Sprites[7];
		this.ListCount++;
		this.mIdx[this.ListCount] = 11;
		this.mListSp[this.ListCount] = this.SArray.m_Sprites[8];
		this.ListCount++;
		this.mIdx[this.ListCount] = 12;
		this.mListSp[this.ListCount] = this.SArray.m_Sprites[12];
		this.ListCount++;
		this.mIdx[this.ListCount] = 9;
		this.mListSp[this.ListCount] = this.SArray.m_Sprites[9];
		this.ListCount++;
		this.mIdx[this.ListCount] = 7;
		this.mListSp[this.ListCount] = this.SArray.m_Sprites[10];
		this.ListCount++;
	}

	// Token: 0x060015C9 RID: 5577 RVA: 0x00251478 File Offset: 0x0024F678
	public void OnButtonClick(UIButton sender)
	{
		GUIOther_btn btnID = (GUIOther_btn)sender.m_BtnID1;
		if (btnID != GUIOther_btn.btn_EXIT)
		{
			if (btnID == GUIOther_btn.btn_Item)
			{
				this.OnClickBtn(sender.m_BtnID2);
			}
		}
		else if (this.door != null)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x060015CA RID: 5578 RVA: 0x002514D4 File Offset: 0x0024F6D4
	public void OnClickBtn(int mkind)
	{
		switch (mkind)
		{
		case 1:
			GUIManager.Instance.OpenUI_Queued_Restricted_Top(EGUIWindow.UI_Other_Account, 0, 0, false, 0);
			break;
		case 2:
			this.door.OpenMenu(EGUIWindow.UI_Other_Set, 0, 0, false);
			break;
		case 3:
			this.door.OpenMenu(EGUIWindow.UI_Other_FunctionSwitch, 0, 0, false);
			break;
		case 4:
			this.door.OpenMenu(EGUIWindow.UI_Other_FunctionSwitch, 1, 0, false);
			break;
		case 5:
			this.door.OpenMenu(EGUIWindow.UI_SearchList, 0, 0, false);
			break;
		case 6:
			if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 8)
			{
				GUIManager.Instance.MsgStr.ClearString();
				GUIManager.Instance.MsgStr.StringToFormat(this.DM.mStringTable.GetStringByID(7028u));
				GUIManager.Instance.MsgStr.IntToFormat(8L, 1, false);
				GUIManager.Instance.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(9749u));
				GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), 255, true);
			}
			else
			{
				UILeaderBoard.NewOpen = true;
				this.door.OpenMenu(EGUIWindow.UI_LeaderBoard, 2, 0, false);
			}
			break;
		case 7:
			this.door.OpenMenu(EGUIWindow.UI_BlackList, 0, 0, false);
			break;
		case 8:
			this.door.OpenMenu(EGUIWindow.UI_Other_Forum, 0, 0, false);
			break;
		case 9:
			this.door.OpenMenu(EGUIWindow.UI_Other_Forum, 1, 0, false);
			break;
		case 10:
			this.door.OpenMenu(EGUIWindow.UI_LanguageSelect, 2, 0, false);
			break;
		case 11:
			IGGSDKPlugin.OpenFbByUrl("http://weibo.com/lordsmobilecn");
			break;
		case 12:
			GUIManager.Instance.OpenMenu(EGUIWindow.UI_PaySetting, 0, 0, false, true, false);
			break;
		case 13:
			DataManager.FBMissionDataManager.m_FBBindEnd = false;
			this.door.OpenMenu(EGUIWindow.UI_MissionFB, 0, 0, true);
			if (DataManager.FBMissionDataManager.bFB_CDTime || DataManager.FBMissionDataManager.GetRemainTime() == 0u)
			{
				DataManager.FBMissionDataManager.bFB_btnShow = false;
				DataManager.FBMissionDataManager.ReSetFB_CDTime(null);
			}
			break;
		case 14:
		{
			bool flag = false;
			if (!this.DM.CheckPrizeFlag(28))
			{
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_WEGAMER_RESP_OFFICIAL_LIVE;
				messagePacket.AddSeqId();
				messagePacket.Send(false);
				DataManager dm = this.DM;
				dm.RoleAttr.PrizeFlag = (dm.RoleAttr.PrizeFlag | 268435456u);
				flag = true;
			}
			this.GUIM.StopShowLiveScale = 2;
			if (this.uToolBG_S)
			{
				this.uToolBG_S.enabled = false;
				this.uToolBG_S.SetCurrentValueToStart();
			}
			if (this.uToolBGF_S)
			{
				this.uToolBGF_S.enabled = false;
				this.uToolBGF_S.SetCurrentValueToStart();
			}
			if (this.uToolBGF_A)
			{
				this.uToolBGF_A.enabled = false;
				this.uToolBGF_A.SetCurrentValueToStart();
			}
			this.GUIM.UpdateUI(EGUIWindow.Door, 20, 0);
			if (!flag)
			{
				this.OpenH5();
			}
			break;
		}
		}
	}

	// Token: 0x060015CB RID: 5579 RVA: 0x00251830 File Offset: 0x0024FA30
	private void OpenH5()
	{
		H5SDKPlugin.StartH5ByWebView(IGGGameSDK.Instance.m_IGGID, DataManager.Instance.UserLanguage.ToString(), "1", DataManager.Instance.RoleAttr.Name.ToString());
	}

	// Token: 0x060015CC RID: 5580 RVA: 0x0025187C File Offset: 0x0024FA7C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.tmpItem[panelObjectIdx] == null)
		{
			this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
			for (int i = 0; i < 3; i++)
			{
				this.btnItem[panelObjectIdx * 3 + i] = this.tmpItem[panelObjectIdx].transform.GetChild(i).GetComponent<UIButton>();
				this.btnItem[panelObjectIdx * 3 + i].m_Handler = this;
				this.btnItem[panelObjectIdx * 3 + i].m_BtnID1 = 1;
				this.btnItem[panelObjectIdx * 3 + i].m_BtnID2 = 0;
				this.ImgItem[panelObjectIdx * 3 + i] = this.tmpItem[panelObjectIdx].transform.GetChild(i).GetChild(0).GetComponent<Image>();
				this.ImgItemIcon[panelObjectIdx * 3 + i] = this.tmpItem[panelObjectIdx].transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>();
				this.textItem[panelObjectIdx * 3 + i] = this.tmpItem[panelObjectIdx].transform.GetChild(i).GetChild(1).GetComponent<UIText>();
				this.textItem[panelObjectIdx * 3 + i].font = this.TTFont;
				if (dataIdx * 3 + i < this.ListCount)
				{
					if (dataIdx * 3 + i < this.mListSp.Length)
					{
						this.ImgItem[panelObjectIdx * 3 + i].sprite = this.mListSp[dataIdx * 3 + i];
					}
					else
					{
						this.ImgItem[panelObjectIdx * 3 + i].sprite = this.mListSp[0];
					}
					if (dataIdx * 3 + i < this.mIdx.Length && (int)(this.mIdx[dataIdx * 3 + i] - 1) < this.tmpStrlist.Count)
					{
						this.textItem[panelObjectIdx * 3 + i].text = this.tmpStrlist[(int)(this.mIdx[dataIdx * 3 + i] - 1)];
					}
					else
					{
						this.textItem[panelObjectIdx * 3 + i].text = string.Empty;
					}
					if (!this.btnItem[panelObjectIdx * 3 + i].IsActive())
					{
						this.btnItem[panelObjectIdx * 3 + i].gameObject.SetActive(true);
					}
					this.btnItem[panelObjectIdx * 3 + i].m_BtnID2 = (int)this.mIdx[dataIdx * 3 + i];
					if (this.GUIM.IsArabic && (this.mIdx[dataIdx * 3 + i] == 6 || this.mIdx[dataIdx * 3 + i] == 11))
					{
						this.ImgItem[panelObjectIdx * 3 + i].transform.localScale = new Vector3(-1f, 1f, 1f);
					}
					if (this.mIdx[dataIdx * 3 + i] == 11)
					{
						this.ImgItemIcon[panelObjectIdx * 3 + i].gameObject.SetActive(true);
						this.ImgItemIcon[panelObjectIdx * 3 + i].sprite = this.SArray.m_Sprites[15];
						this.ImgItemIcon[panelObjectIdx * 3 + i].SetNativeSize();
					}
					else
					{
						this.ImgItemIcon[panelObjectIdx * 3 + i].gameObject.SetActive(false);
					}
				}
				else
				{
					this.btnItem[panelObjectIdx * 3 + i].gameObject.SetActive(false);
				}
			}
		}
		else
		{
			if (this.tmpItem[panelObjectIdx].m_BtnID2 == 0)
			{
				if (dataIdx == 0 && !DataManager.Instance.CheckPrizeFlag(2) && IGGGameSDK.Instance.m_IGGLoginType != IGGLoginType.Facebook)
				{
					this.GiftT.gameObject.SetActive(true);
				}
				else
				{
					this.GiftT.gameObject.SetActive(false);
				}
			}
			for (int j = 0; j < 3; j++)
			{
				if (dataIdx * 3 + j < this.ListCount)
				{
					if (!this.btnItem[panelObjectIdx * 3 + j].IsActive())
					{
						this.btnItem[panelObjectIdx * 3 + j].gameObject.SetActive(true);
					}
					if (dataIdx * 3 + j < this.mListSp.Length)
					{
						this.ImgItem[panelObjectIdx * 3 + j].sprite = this.mListSp[dataIdx * 3 + j];
					}
					else
					{
						this.ImgItem[panelObjectIdx * 3 + j].sprite = this.mListSp[0];
					}
					if (dataIdx * 3 + j < this.mIdx.Length && (int)(this.mIdx[dataIdx * 3 + j] - 1) < this.tmpStrlist.Count)
					{
						this.textItem[panelObjectIdx * 3 + j].text = this.tmpStrlist[(int)(this.mIdx[dataIdx * 3 + j] - 1)];
					}
					else
					{
						this.textItem[panelObjectIdx * 3 + j].text = string.Empty;
					}
					this.textItem[panelObjectIdx * 3 + j].SetAllDirty();
					this.textItem[panelObjectIdx * 3 + j].cachedTextGenerator.Invalidate();
					this.btnItem[panelObjectIdx * 3 + j].m_BtnID2 = (int)this.mIdx[dataIdx * 3 + j];
					if (this.mIdx[dataIdx * 3 + j] == 11)
					{
						this.ImgItemIcon[panelObjectIdx * 3 + j].gameObject.SetActive(true);
						this.ImgItemIcon[panelObjectIdx * 3 + j].sprite = this.SArray.m_Sprites[15];
						this.ImgItemIcon[panelObjectIdx * 3 + j].SetNativeSize();
					}
					else
					{
						this.ImgItemIcon[panelObjectIdx * 3 + j].gameObject.SetActive(false);
					}
					if (this.GUIM.IsArabic && (this.mIdx[dataIdx * 3 + j] == 6 || this.mIdx[dataIdx * 3 + j] == 11))
					{
						this.ImgItem[panelObjectIdx * 3 + j].transform.localScale = new Vector3(-1f, 1f, 1f);
					}
				}
				else
				{
					this.btnItem[panelObjectIdx * 3 + j].gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x060015CD RID: 5581 RVA: 0x00251E78 File Offset: 0x00250078
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x060015CE RID: 5582 RVA: 0x00251E7C File Offset: 0x0025007C
	public override void OnClose()
	{
		if (this.Cstr_Number != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Number);
		}
		if (this.Cstr_CDTime != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_CDTime);
		}
	}

	// Token: 0x060015CF RID: 5583 RVA: 0x00251EC4 File Offset: 0x002500C4
	private void CheckKiveShow()
	{
		if (this.LiveT != null && this.LiveT.gameObject.activeInHierarchy && this.GUIM.StopShowLiveScale < 2)
		{
			if (this.uToolBG_S)
			{
				this.uToolBG_S.enabled = true;
			}
			if (this.uToolBGF_S)
			{
				this.uToolBGF_S.enabled = true;
			}
			if (this.uToolBGF_A)
			{
				this.uToolBGF_A.enabled = true;
			}
		}
		else
		{
			if (this.uToolBG_S)
			{
				this.uToolBG_S.enabled = false;
				this.uToolBG_S.SetCurrentValueToStart();
			}
			if (this.uToolBGF_S)
			{
				this.uToolBGF_S.enabled = false;
				this.uToolBGF_S.SetCurrentValueToStart();
			}
			if (this.uToolBGF_A)
			{
				this.uToolBGF_A.enabled = false;
				this.uToolBGF_A.SetCurrentValueToStart();
			}
		}
	}

	// Token: 0x060015D0 RID: 5584 RVA: 0x00251FD8 File Offset: 0x002501D8
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			if (this.GUIM.BuildingData.GetBuildData(8, 0).Level >= 12)
			{
				this.CheckKiveShow();
			}
			if (!this.bShowFB_Btn && this.GUIM.BuildingData.GetBuildData(8, 0).Level >= 7)
			{
				this.door.CloseMenu(false);
				this.door.OpenMenu(EGUIWindow.UI_Other, 0, 0, false);
			}
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
			break;
		}
	}

	// Token: 0x060015D1 RID: 5585 RVA: 0x00252088 File Offset: 0x00250288
	public void Refresh_FontTexture()
	{
		if (this.text_Number != null && this.text_Number.enabled)
		{
			this.text_Number.enabled = false;
			this.text_Number.enabled = true;
		}
		if (this.text_CDTime != null && this.text_CDTime.enabled)
		{
			this.text_CDTime.enabled = false;
			this.text_CDTime.enabled = true;
		}
		if (this.text_Mail != null && this.text_Mail.enabled)
		{
			this.text_Mail.enabled = false;
			this.text_Mail.enabled = true;
		}
		if (this.text_FBNum != null && this.text_FBNum.enabled)
		{
			this.text_FBNum.enabled = false;
			this.text_FBNum.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_tmpStr[i] != null && this.text_tmpStr[i].enabled)
			{
				this.text_tmpStr[i].enabled = false;
				this.text_tmpStr[i].enabled = true;
			}
		}
		for (int j = 0; j < 15; j++)
		{
			if (this.textItem[j] != null && this.textItem[j].enabled)
			{
				this.textItem[j].enabled = false;
				this.textItem[j].enabled = true;
			}
		}
	}

	// Token: 0x060015D2 RID: 5586 RVA: 0x00252220 File Offset: 0x00250420
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			if (DataManager.Instance.CheckPrizeFlag(2))
			{
				this.GiftT.gameObject.SetActive(false);
			}
			break;
		case 2:
			if (this.GUIM.BuildingData.GetBuildData(8, 0).Level >= 12)
			{
				this.CheckKiveShow();
			}
			break;
		case 3:
			this.OpenH5();
			break;
		case 4:
			if (!this.bShowFB_Btn && this.GUIM.BuildingData.GetBuildData(8, 0).Level >= 7)
			{
				this.door.CloseMenu(false);
				this.door.OpenMenu(EGUIWindow.UI_Other, 0, 0, false);
			}
			break;
		case 5:
			this.Img_FBNum.gameObject.SetActive(this.bShowFB_Btn && DataManager.FBMissionDataManager.GetRewardCount() > 0);
			if (this.Img_FBNum.gameObject.activeSelf)
			{
				this.text_FBNum.text = DataManager.FBMissionDataManager.GetRewardCount().ToString();
				this.text_FBNum.SetAllDirty();
				this.text_FBNum.cachedTextGenerator.Invalidate();
				this.text_FBNum.cachedTextGeneratorForLayout.Invalidate();
				this.Img_FBNum.rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_FBNum.preferredWidth), this.Img_FBNum.rectTransform.sizeDelta.y);
			}
			break;
		}
	}

	// Token: 0x060015D3 RID: 5587 RVA: 0x002523C8 File Offset: 0x002505C8
	private void Start()
	{
	}

	// Token: 0x060015D4 RID: 5588 RVA: 0x002523CC File Offset: 0x002505CC
	private void Update()
	{
	}

	// Token: 0x0400402B RID: 16427
	public const int OtherItemCount = 15;

	// Token: 0x0400402C RID: 16428
	private DataManager DM;

	// Token: 0x0400402D RID: 16429
	private GUIManager GUIM;

	// Token: 0x0400402E RID: 16430
	private ScrollPanel m_ScrollPanel;

	// Token: 0x0400402F RID: 16431
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x04004030 RID: 16432
	private Door door;

	// Token: 0x04004031 RID: 16433
	private Transform GameT;

	// Token: 0x04004032 RID: 16434
	private Transform GiftT;

	// Token: 0x04004033 RID: 16435
	private Transform LiveT;

	// Token: 0x04004034 RID: 16436
	private Transform H5LiveCheckMarkT;

	// Token: 0x04004035 RID: 16437
	private RectTransform CDTime_text_RT;

	// Token: 0x04004036 RID: 16438
	private UIButton btn_EXIT;

	// Token: 0x04004037 RID: 16439
	public UIButton[] btnItem = new UIButton[15];

	// Token: 0x04004038 RID: 16440
	private Image[] ImgItem = new Image[15];

	// Token: 0x04004039 RID: 16441
	private Image[] ImgItemIcon = new Image[15];

	// Token: 0x0400403A RID: 16442
	private Image tmpImg;

	// Token: 0x0400403B RID: 16443
	private Image Img_FBNum;

	// Token: 0x0400403C RID: 16444
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[5];

	// Token: 0x0400403D RID: 16445
	private UIText tmptext;

	// Token: 0x0400403E RID: 16446
	private UIText text_Number;

	// Token: 0x0400403F RID: 16447
	private UIText text_CDTime;

	// Token: 0x04004040 RID: 16448
	private UIText text_Mail;

	// Token: 0x04004041 RID: 16449
	private UIText text_FBNum;

	// Token: 0x04004042 RID: 16450
	private UIText[] text_tmpStr = new UIText[2];

	// Token: 0x04004043 RID: 16451
	private CString Cstr_Number;

	// Token: 0x04004044 RID: 16452
	private CString Cstr_CDTime;

	// Token: 0x04004045 RID: 16453
	private UIText[] textItem = new UIText[15];

	// Token: 0x04004046 RID: 16454
	private Material m_Mat;

	// Token: 0x04004047 RID: 16455
	private List<float> tmplist = new List<float>();

	// Token: 0x04004048 RID: 16456
	private List<string> tmpStrlist = new List<string>();

	// Token: 0x04004049 RID: 16457
	private byte[] mIdx = new byte[15];

	// Token: 0x0400404A RID: 16458
	private UISpritesArray SArray;

	// Token: 0x0400404B RID: 16459
	private Sprite[] mListSp;

	// Token: 0x0400404C RID: 16460
	private int ListCount;

	// Token: 0x0400404D RID: 16461
	private byte mMoveNum;

	// Token: 0x0400404E RID: 16462
	private uTweenScale uToolBG_S;

	// Token: 0x0400404F RID: 16463
	private uTweenScale uToolBGF_S;

	// Token: 0x04004050 RID: 16464
	private uTweenAlpha uToolBGF_A;

	// Token: 0x04004051 RID: 16465
	private bool bShowFB_Btn;
}
