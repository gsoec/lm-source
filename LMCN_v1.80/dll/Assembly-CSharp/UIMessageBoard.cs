using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000633 RID: 1587
public class UIMessageBoard : GUIWindow, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001EA2 RID: 7842 RVA: 0x003A8224 File Offset: 0x003A6424
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_transform = base.transform;
		this.m_Font = this.GM.GetTTFFont();
		this.RBText[0] = this.m_transform.GetChild(2).GetComponent<UIText>();
		this.RBText[0].font = this.m_Font;
		this.RBText[0].text = this.DM.mStringTable.GetStringByID(8206u);
		this.NoMessageGO = this.m_transform.GetChild(3).gameObject;
		this.RBText[1] = this.m_transform.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.RBText[1].font = this.m_Font;
		this.RBText[1].text = this.DM.mStringTable.GetStringByID(8207u);
		this.Input = this.m_transform.GetChild(7).GetComponent<UIEmojiInput>();
		this.Input.placeholder = this.m_transform.GetChild(7).GetChild(0).GetComponent<UIText>();
		this.Input.textComponent = this.m_transform.GetChild(7).GetChild(1).GetComponent<UIText>();
		this.Input.transform.GetChild(0).GetComponent<UIText>().font = this.m_Font;
		this.Input.transform.GetChild(1).GetComponent<UIText>().font = this.m_Font;
		this.Input.shouldHideMobileInput = false;
		this.Input.lineType = UIEmojiInput.LineType.MultiLineNewline;
		this.Input.placeholder.GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(8208u);
		this.InputColor = this.Input.placeholder.GetComponent<UIText>().color;
		this.InputErrorColor = new Color(0.596f, 0f, 0f);
		this.InputErroeCString = StringManager.Instance.SpawnString(200);
		this.InputErroeCString.IntToFormat(8L, 1, false);
		this.InputErroeCString.AppendFormat(this.DM.mStringTable.GetStringByID(9167u));
		this.SendBtn = this.m_transform.GetChild(6).GetComponent<UIButton>();
		this.SendBtn.m_Handler = this;
		this.SendBtn.transition = Selectable.Transition.ColorTint;
		this.SendImg = this.SendBtn.transform.GetChild(0).GetComponent<Image>();
		this.m_transform.GetChild(8).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(8).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(8).GetChild(0).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(8).GetComponent<CustomImage>().enabled = false;
		}
		Transform child = this.m_transform.GetChild(5).GetChild(0);
		this.GM.InitBadgeTotem(child.GetChild(1).GetChild(0), 0);
		this.GM.InitianHeroItemImg(child.GetChild(2), eHeroOrItem.Hero, 1, 11, 0, 0, true, true, true, false);
		UIText component = child.GetChild(3).GetComponent<UIText>();
		component.font = this.m_Font;
		component.resizeTextForBestFit = true;
		component.resizeTextMaxSize = 18;
		component.alignment = TextAnchor.MiddleLeft;
		component.rectTransform.sizeDelta = new Vector2(480f, component.rectTransform.sizeDelta.y);
		this.LeftmainText = child.GetChild(4).GetComponent<UIText>();
		this.LeftmainText.font = this.m_Font;
		component = child.GetChild(5).GetComponent<UIText>();
		component.font = this.m_Font;
		child = this.m_transform.GetChild(5).GetChild(1);
		component = child.GetChild(1).GetComponent<UIText>();
		component.font = this.m_Font;
		component = child.GetChild(2).GetComponent<UIText>();
		component.font = this.m_Font;
		this.AllianceID = this.DM.SendAllianceID;
		this.NowList = this.DM.MessageBoardList;
		this.PanelGO = this.m_transform.GetChild(4).gameObject;
		this.Scroll = this.m_transform.GetChild(4).GetComponent<ScrollPanel>();
		this.Scroll.IntiScrollPanel(446f, 0f, 4f, this.NowHeightList, 9, this);
		this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
		this.UpDateHeight(true, true);
		if (arg1 == 1)
		{
			this.Scroll.gameObject.SetActive(false);
		}
		else if (this.DM.PreSendAllianceID != this.DM.SendAllianceID)
		{
			this.DM.PreSendAllianceID = this.DM.SendAllianceID;
			this.Scroll.GoToLast();
		}
		else
		{
			this.Scroll.GoTo(this.DM.MessageBoardScroll_Idx, this.DM.MessageBoardScroll_Y);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001EA3 RID: 7843 RVA: 0x003A875C File Offset: 0x003A695C
	public override void OnClose()
	{
		for (int i = 8; i >= 0; i--)
		{
			if (this.TimeStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.TimeStr[i]);
				this.TimeStr[i] = null;
			}
			if (this.NameStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.NameStr[i]);
				this.NameStr[i] = null;
			}
			if (this.LanguageStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.LanguageStr[i]);
				this.LanguageStr[i] = null;
			}
			if (this.DeleteMsgStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.DeleteMsgStr[i]);
				this.DeleteMsgStr[i] = null;
			}
		}
		StringManager.Instance.DeSpawnString(this.InputErroeCString);
		this.DM.MessageBoardScroll_Y = this.cScrollRect.content.anchoredPosition.y;
		this.DM.MessageBoardScroll_Idx = this.Scroll.GetTopIdx();
	}

	// Token: 0x06001EA4 RID: 7844 RVA: 0x003A886C File Offset: 0x003A6A6C
	private void InputEnd(string tmpStr)
	{
		if (this.DM.sendTimer > 0f)
		{
			this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(658u), 255, true);
			return;
		}
		int num = 0;
		for (int i = 0; i < tmpStr.Length; i++)
		{
			if (tmpStr[i] == '\n')
			{
				num++;
			}
		}
		if (num >= 5)
		{
			this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(244u), 255, true);
			return;
		}
		int num2 = Encoding.UTF8.GetBytes(tmpStr.ToCharArray(), 0, tmpStr.Length).Length;
		if (num2 > 400)
		{
			this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(243u), 255, true);
			return;
		}
		this.SendChat(tmpStr);
	}

	// Token: 0x06001EA5 RID: 7845 RVA: 0x003A8964 File Offset: 0x003A6B64
	private void SendChat(string tmpStr)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_SENDALLY;
		char[] array = tmpStr.ToCharArray();
		if (this.DM.m_BannedWord != null)
		{
			this.DM.m_BannedWord.CheckBannedWord(array);
		}
		byte[] bytes = Encoding.UTF8.GetBytes(array, 0, tmpStr.Length);
		if (bytes.Length <= 0)
		{
			return;
		}
		this.DM.FindBlack = 0;
		messagePacket.AddSeqId();
		messagePacket.Add(this.AllianceID);
		if (this.DM.ServerVersionMajor != 0)
		{
			messagePacket.Add((!ArabicTransfer.Instance.IsArabicStr(tmpStr)) ? 1 : 2);
		}
		messagePacket.Add((ushort)bytes.Length);
		messagePacket.Add(bytes, 0, 0);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.MessageBoard);
		this.DM.sendTimer = 3f;
		this.Input.text = string.Empty;
	}

	// Token: 0x06001EA6 RID: 7846 RVA: 0x003A8A60 File Offset: 0x003A6C60
	private void UpDateHeight(bool GoToTop = true, bool bStopMove = true)
	{
		if (this.NowList.Count > 0)
		{
			this.PanelGO.SetActive(true);
			this.NoMessageGO.SetActive(false);
			this.NowHeightList.Clear();
			for (int i = 0; i < this.NowList.Count; i++)
			{
				this.NowHeightList.Add(this.GetUnitHeight(i));
			}
			this.Scroll.AddNewDataHeight(this.NowHeightList, GoToTop, bStopMove);
		}
		else
		{
			this.PanelGO.SetActive(false);
			this.NoMessageGO.SetActive(true);
		}
		this.CheckSpeakInKindom();
	}

	// Token: 0x06001EA7 RID: 7847 RVA: 0x003A8B08 File Offset: 0x003A6D08
	private void CheckSpeakInKindom()
	{
		if (this.GM.BuildingData.GetBuildData(8, 0).Level < 8)
		{
			this.Input.interactable = false;
			this.SendBtn.interactable = false;
			this.SendImg.color = Color.gray;
			UIText component = this.Input.placeholder.GetComponent<UIText>();
			component.text = this.InputErroeCString.ToString();
			component.color = this.InputErrorColor;
		}
		else
		{
			this.Input.interactable = true;
			this.SendBtn.interactable = true;
			this.SendImg.color = Color.white;
			UIText component2 = this.Input.placeholder.GetComponent<UIText>();
			component2.text = this.DM.mStringTable.GetStringByID(779u);
			component2.color = this.InputColor;
		}
	}

	// Token: 0x06001EA8 RID: 7848 RVA: 0x003A8BF0 File Offset: 0x003A6DF0
	private float GetUnitHeight(int Index)
	{
		if (Index < 0 || Index >= this.NowList.Count)
		{
			return 0f;
		}
		float num = 120f;
		if (this.NowList[Index].AllianceOrRole == 0 || this.NowList[Index].AllianceOrRole == 1)
		{
			float num2 = 55f;
			if (this.GM.bAutoTranslate && this.NowList[Index].TranslateShow != 0 && !this.NowList[Index].bSelfMessage && this.NowList[Index].TranslateState == eTranslateState.completed)
			{
				if (this.NowList[Index].TotalHeightT != 0f)
				{
					return this.NowList[Index].TotalHeightT;
				}
				num += 10f;
				this.LeftmainText.text = this.NowList[Index].TranslateText.ToString();
				if (this.LeftmainText.preferredHeight > num2)
				{
					num += this.LeftmainText.preferredHeight - num2;
				}
				this.NowList[Index].TotalHeightT = num;
			}
			else
			{
				if (this.NowList[Index].TotalHeight != 0f)
				{
					return this.NowList[Index].TotalHeight;
				}
				if (this.GM.bAutoTranslate && !this.NowList[Index].bSelfMessage && this.NowList[Index].TranslateState != eTranslateState.NoNeedTranslate)
				{
					num += 10f;
				}
				this.LeftmainText.text = this.NowList[Index].MessageStr.ToString();
				if (this.LeftmainText.preferredHeight > num2)
				{
					num += this.LeftmainText.preferredHeight - num2;
				}
				this.NowList[Index].TotalHeight = num;
			}
		}
		else if (this.NowList[Index].AllianceOrRole >= 2 && this.NowList[Index].AllianceOrRole <= 5)
		{
			if (this.NowList[Index].TotalHeight != 0f)
			{
				return this.NowList[Index].TotalHeight;
			}
			num = 55f;
			this.LeftmainText.text = this.DM.mStringTable.GetStringByID(10070u);
			this.LeftmainText.SetAllDirty();
			this.LeftmainText.cachedTextGeneratorForLayout.Invalidate();
			if (this.LeftmainText.preferredHeight > 32f)
			{
				num = this.LeftmainText.preferredHeight + 25f;
			}
			this.NowList[Index].TotalHeight = num;
		}
		return num;
	}

	// Token: 0x06001EA9 RID: 7849 RVA: 0x003A8EDC File Offset: 0x003A70DC
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < 9)
		{
			if (!this.bFindScrollComp[panelObjectIdx])
			{
				this.bFindScrollComp[panelObjectIdx] = true;
				this.Scroll_1_Comp[panelObjectIdx].NormalItemGO = item.transform.GetChild(0).gameObject;
				this.Scroll_1_Comp[panelObjectIdx].DeleteItemGO = item.transform.GetChild(1).gameObject;
				Transform child = item.transform.GetChild(0);
				this.Scroll_1_Comp[panelObjectIdx].BackRC = item.transform.GetComponent<RectTransform>();
				this.Scroll_1_Comp[panelObjectIdx].BadageT = child.GetChild(1);
				this.Scroll_1_Comp[panelObjectIdx].RoleIconT = child.GetChild(2);
				this.Scroll_1_Comp[panelObjectIdx].NameText = child.GetChild(3).GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].MessageText = child.GetChild(4).GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].TimeText = child.GetChild(5).GetComponent<UIText>();
				this.TimeStr[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.NameStr[panelObjectIdx] = StringManager.Instance.SpawnString(100);
				this.LanguageStr[panelObjectIdx] = StringManager.Instance.SpawnString(150);
				this.Scroll_1_Comp[panelObjectIdx].NameText.SetCheckArabic(true);
				this.Scroll_1_Comp[panelObjectIdx].MessageText.SetCheckArabic(true);
				this.Scroll_1_Comp[panelObjectIdx].TranslateImgGO = child.GetChild(6).gameObject;
				this.Scroll_1_Comp[panelObjectIdx].TranslateText = child.GetChild(8).GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].TranslateText.font = this.m_Font;
				this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO = child.GetChild(7).gameObject;
				UIButton component = this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO.transform.GetComponent<UIButton>();
				component.m_Handler = this;
				component.m_BtnID2 = panelObjectIdx;
				component = child.GetChild(9).GetComponent<UIButton>();
				component.m_Handler = this;
				component.m_BtnID2 = panelObjectIdx;
				component = child.GetChild(10).GetComponent<UIButton>();
				component.m_Handler = this;
				component.m_BtnID1 = 5;
				component.m_BtnID2 = panelObjectIdx;
				this.Scroll_1_Comp[panelObjectIdx].ProfileBtn2 = (RectTransform)component.transform;
				this.Scroll_1_Comp[panelObjectIdx].DeleteBtnGO = child.GetChild(11).gameObject;
				component = this.Scroll_1_Comp[panelObjectIdx].DeleteBtnGO.transform.GetComponent<UIButton>();
				component.m_Handler = this;
				component.m_BtnID2 = panelObjectIdx;
				child = item.transform.GetChild(1);
				this.Scroll_1_Comp[panelObjectIdx].Delete_RC = child.GetComponent<RectTransform>();
				this.Scroll_1_Comp[panelObjectIdx].Delete_TimeText = child.GetChild(1).GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].Delete_MessageText = child.GetChild(2).GetComponent<UIText>();
				this.DeleteMsgStr[panelObjectIdx] = StringManager.Instance.SpawnString(300);
			}
			if (dataIdx < 0 || dataIdx >= this.NowList.Count)
			{
				return;
			}
			MessageBoard messageBoard = this.NowList[dataIdx];
			this.Scroll_1_Comp[panelObjectIdx].DataIndex = dataIdx;
			if (this.NowList[dataIdx].AllianceOrRole == 0 || this.NowList[dataIdx].AllianceOrRole == 1)
			{
				this.Scroll_1_Comp[panelObjectIdx].NormalItemGO.SetActive(true);
				this.Scroll_1_Comp[panelObjectIdx].DeleteItemGO.SetActive(false);
				bool flag = !this.NowList[dataIdx].bSelfMessage && this.GM.bAutoTranslate && this.NowList[dataIdx].TranslateState != eTranslateState.NoNeedTranslate;
				if (flag)
				{
					if (this.NowList[dataIdx].TranslateState == eTranslateState.Translation)
					{
						this.Scroll_1_Comp[panelObjectIdx].TranslateImgGO.SetActive(true);
						this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO.SetActive(false);
					}
					else
					{
						this.Scroll_1_Comp[panelObjectIdx].TranslateImgGO.SetActive(false);
						this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO.SetActive(true);
					}
					this.Scroll_1_Comp[panelObjectIdx].TranslateText.gameObject.SetActive(true);
					if (this.NowList[dataIdx].TranslateShow == 0)
					{
						this.Scroll_1_Comp[panelObjectIdx].TranslateText.text = this.DM.mStringTable.GetStringByID(9052u);
					}
					else
					{
						this.LanguageStr[panelObjectIdx].Length = 0;
						this.LanguageStr[panelObjectIdx].StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte)this.NowList[dataIdx].TranslateLanguage));
						this.LanguageStr[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(9054u));
						this.Scroll_1_Comp[panelObjectIdx].TranslateText.text = this.LanguageStr[panelObjectIdx].ToString();
						this.Scroll_1_Comp[panelObjectIdx].TranslateText.SetVerticesDirty();
						this.Scroll_1_Comp[panelObjectIdx].TranslateText.SetLayoutDirty();
						this.Scroll_1_Comp[panelObjectIdx].TranslateText.cachedTextGenerator.Invalidate();
					}
				}
				else
				{
					this.Scroll_1_Comp[panelObjectIdx].TranslateImgGO.SetActive(false);
					this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO.SetActive(false);
					this.Scroll_1_Comp[panelObjectIdx].TranslateText.gameObject.SetActive(false);
				}
				if (flag && this.NowList[dataIdx].TranslateShow != 0 && this.NowList[dataIdx].TranslateState == eTranslateState.completed)
				{
					this.Scroll_1_Comp[panelObjectIdx].BackRC.sizeDelta = new Vector2(702f, messageBoard.TotalHeightT);
				}
				else
				{
					this.Scroll_1_Comp[panelObjectIdx].BackRC.sizeDelta = new Vector2(702f, messageBoard.TotalHeight);
				}
				if (messageBoard.AllianceOrRole == 1)
				{
					this.Scroll_1_Comp[panelObjectIdx].BadageT.gameObject.SetActive(true);
					this.Scroll_1_Comp[panelObjectIdx].RoleIconT.gameObject.SetActive(false);
					this.GM.SetBadgeTotemImg(this.Scroll_1_Comp[panelObjectIdx].BadageT.GetChild(0), messageBoard.PicID);
				}
				else
				{
					this.Scroll_1_Comp[panelObjectIdx].BadageT.gameObject.SetActive(false);
					this.Scroll_1_Comp[panelObjectIdx].RoleIconT.gameObject.SetActive(true);
					this.GM.ChangeHeroItemImg(this.Scroll_1_Comp[panelObjectIdx].RoleIconT, eHeroOrItem.Hero, messageBoard.PicID, 11, 0, 0);
				}
				if (messageBoard.AllianceOrRole == 0)
				{
					this.NameStr[panelObjectIdx].Length = 0;
					this.NameStr[panelObjectIdx].StringToFormat(messageBoard.NameStr);
					this.NameStr[panelObjectIdx].AppendFormat("<color=#00479DFF>{0}</color>");
					this.Scroll_1_Comp[panelObjectIdx].NameText.text = this.NameStr[panelObjectIdx].ToString();
					this.Scroll_1_Comp[panelObjectIdx].NameText.SetAllDirty();
					this.Scroll_1_Comp[panelObjectIdx].NameText.cachedTextGenerator.Invalidate();
				}
				else
				{
					this.NameStr[panelObjectIdx].Length = 0;
					this.NameStr[panelObjectIdx].StringToFormat(messageBoard.AllianceTagStr);
					this.NameStr[panelObjectIdx].StringToFormat(messageBoard.AllianceNameStr);
					this.NameStr[panelObjectIdx].StringToFormat(messageBoard.NameStr);
					this.NameStr[panelObjectIdx].AppendFormat("[{0}]{1} <color=#00479DFF>{2}</color>");
					this.Scroll_1_Comp[panelObjectIdx].NameText.text = this.NameStr[panelObjectIdx].ToString();
					this.Scroll_1_Comp[panelObjectIdx].NameText.SetAllDirty();
					this.Scroll_1_Comp[panelObjectIdx].NameText.cachedTextGenerator.Invalidate();
				}
				int num = 0;
				if (flag && this.NowList[dataIdx].TranslateShow != 0 && this.NowList[dataIdx].TranslateState == eTranslateState.completed)
				{
					this.Scroll_1_Comp[panelObjectIdx].MessageText.text = messageBoard.TranslateText.ToString();
				}
				else
				{
					this.Scroll_1_Comp[panelObjectIdx].MessageText.text = messageBoard.MessageStr.ToString();
				}
				if (this.Scroll_1_Comp[panelObjectIdx].MessageText.preferredHeight > this.BaseHeight)
				{
					this.Scroll_1_Comp[panelObjectIdx].MessageText.rectTransform.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].MessageText.rectTransform.sizeDelta.x, this.Scroll_1_Comp[panelObjectIdx].MessageText.preferredHeight);
					num = (int)(this.Scroll_1_Comp[panelObjectIdx].MessageText.preferredHeight - this.BaseHeight);
				}
				if (num > 0)
				{
					this.Scroll_1_Comp[panelObjectIdx].ProfileBtn2.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].ProfileBtn2.sizeDelta.x, (float)(103 + num));
				}
				else
				{
					this.Scroll_1_Comp[panelObjectIdx].ProfileBtn2.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].ProfileBtn2.sizeDelta.x, 103f);
				}
				this.DM.SetSBTime(this.DM.ServerTime - messageBoard.MessageTime, this.TimeStr[panelObjectIdx]);
				this.Scroll_1_Comp[panelObjectIdx].TimeText.text = this.TimeStr[panelObjectIdx].ToString();
				this.Scroll_1_Comp[panelObjectIdx].TimeText.SetAllDirty();
				this.Scroll_1_Comp[panelObjectIdx].TimeText.cachedTextGenerator.Invalidate();
				if (this.AllianceID == this.DM.RoleAlliance.Id && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
				{
					this.Scroll_1_Comp[panelObjectIdx].DeleteBtnGO.SetActive(true);
				}
				else
				{
					this.Scroll_1_Comp[panelObjectIdx].DeleteBtnGO.SetActive(false);
				}
			}
			else if (this.NowList[dataIdx].AllianceOrRole >= 2 && this.NowList[dataIdx].AllianceOrRole <= 5)
			{
				this.Scroll_1_Comp[panelObjectIdx].NormalItemGO.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].DeleteItemGO.SetActive(true);
				this.Scroll_1_Comp[panelObjectIdx].BackRC.sizeDelta = new Vector2(702f, messageBoard.TotalHeight);
				this.Scroll_1_Comp[panelObjectIdx].Delete_RC.sizeDelta = new Vector2(702f, messageBoard.TotalHeight - 3f);
				this.Scroll_1_Comp[panelObjectIdx].Delete_MessageText.text = this.DM.mStringTable.GetStringByID(10070u);
				this.DM.SetSBTime(this.DM.ServerTime - messageBoard.MessageTime, this.TimeStr[panelObjectIdx]);
				this.Scroll_1_Comp[panelObjectIdx].Delete_TimeText.text = this.TimeStr[panelObjectIdx].ToString();
				this.Scroll_1_Comp[panelObjectIdx].Delete_TimeText.SetAllDirty();
				this.Scroll_1_Comp[panelObjectIdx].Delete_TimeText.cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x06001EAA RID: 7850 RVA: 0x003A9B58 File Offset: 0x003A7D58
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				for (int i = 0; i < 9; i++)
				{
					if (this.bFindScrollComp[i])
					{
						if (this.Scroll_1_Comp[i].NameText != null && this.Scroll_1_Comp[i].NameText.enabled)
						{
							this.Scroll_1_Comp[i].NameText.enabled = false;
							this.Scroll_1_Comp[i].NameText.enabled = true;
						}
						if (this.Scroll_1_Comp[i].MessageText != null && this.Scroll_1_Comp[i].MessageText.enabled)
						{
							this.Scroll_1_Comp[i].MessageText.enabled = false;
							this.Scroll_1_Comp[i].MessageText.enabled = true;
						}
						if (this.Scroll_1_Comp[i].TimeText != null && this.Scroll_1_Comp[i].TimeText.enabled)
						{
							this.Scroll_1_Comp[i].TimeText.enabled = false;
							this.Scroll_1_Comp[i].TimeText.enabled = true;
						}
						if (this.Scroll_1_Comp[i].TranslateText != null && this.Scroll_1_Comp[i].TranslateText.enabled)
						{
							this.Scroll_1_Comp[i].TranslateText.enabled = false;
							this.Scroll_1_Comp[i].TranslateText.enabled = true;
						}
						if (this.Scroll_1_Comp[i].Delete_MessageText != null && this.Scroll_1_Comp[i].Delete_MessageText.enabled)
						{
							this.Scroll_1_Comp[i].Delete_MessageText.enabled = false;
							this.Scroll_1_Comp[i].Delete_MessageText.enabled = true;
						}
						if (this.Scroll_1_Comp[i].Delete_TimeText != null && this.Scroll_1_Comp[i].Delete_TimeText.enabled)
						{
							this.Scroll_1_Comp[i].Delete_TimeText.enabled = false;
							this.Scroll_1_Comp[i].Delete_TimeText.enabled = true;
						}
					}
				}
				for (int j = 0; j < this.RBText.Length; j++)
				{
					if (this.RBText[j] != null && this.RBText[j].enabled)
					{
						this.RBText[j].enabled = false;
						this.RBText[j].enabled = true;
					}
				}
				if (this.Input != null)
				{
					if (this.Input.textComponent != null && this.Input.textComponent.enabled)
					{
						this.Input.textComponent.enabled = false;
						this.Input.textComponent.enabled = true;
					}
					if (this.Input.placeholder != null && this.Input.placeholder.enabled)
					{
						this.Input.placeholder.enabled = false;
						this.Input.placeholder.enabled = true;
					}
				}
			}
		}
		else
		{
			if (this.GM.FindMenu(EGUIWindow.UI_Chat))
			{
				return;
			}
			this.Scroll.gameObject.SetActive(false);
			this.DM.AskMessageBoard(this.AllianceID);
		}
	}

	// Token: 0x06001EAB RID: 7851 RVA: 0x003A9F44 File Offset: 0x003A8144
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.UpDateHeight(true, true);
			this.Scroll.GoToLast();
		}
		else if (arg1 == 2 || arg1 == 3)
		{
			this.UpDateHeight(true, true);
			if (this.DM.PreSendAllianceID != this.DM.SendAllianceID)
			{
				this.DM.PreSendAllianceID = this.DM.SendAllianceID;
				this.Scroll.GoToLast();
			}
			else
			{
				this.Scroll.GoTo(this.DM.MessageBoardScroll_Idx, this.DM.MessageBoardScroll_Y);
			}
			this.Scroll.gameObject.SetActive(true);
		}
		else if (arg1 == 4)
		{
			this.UpDateHeight(false, false);
		}
		else if (arg1 == 5)
		{
			this.CheckSpeakInKindom();
		}
		else if (arg1 == 6)
		{
			this.SendDeleteMessage();
		}
		else if (arg1 == 7)
		{
			this.UpDateHeight(false, false);
		}
	}

	// Token: 0x06001EAC RID: 7852 RVA: 0x003AA048 File Offset: 0x003A8248
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			int btnID = sender.m_BtnID2;
			if (btnID != 1)
			{
				if (btnID == 2)
				{
					this.InputEnd(this.Input.text);
				}
			}
			else
			{
				(GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu(false);
			}
		}
		else if (sender.m_BtnID1 == 3)
		{
			if (this.bFindScrollComp[sender.m_BtnID2])
			{
				int dataIndex = this.Scroll_1_Comp[sender.m_BtnID2].DataIndex;
				if (dataIndex < this.NowList.Count)
				{
					if (this.NowList[dataIndex].TranslateState == eTranslateState.completed)
					{
						if (this.NowList[dataIndex].TranslateShow == 0)
						{
							this.NowList[dataIndex].TranslateShow = 1;
						}
						else
						{
							this.NowList[dataIndex].TranslateShow = 0;
						}
						this.UpDateHeight(false, false);
					}
					else if (this.NowList[dataIndex].TranslateState != eTranslateState.Translation)
					{
						if ((this.NowList[dataIndex].TranslateState == eTranslateState.Untranslated || this.NowList[dataIndex].TranslateState == eTranslateState.TranslateFail) && !this.GM.bWaitTranslate_MB)
						{
							this.GM.MB_TranslateBatch(this.NowList[dataIndex]);
							this.NowList[dataIndex].TranslateState = eTranslateState.Translation;
							this.GM.MB_SendTranslateBatch();
							this.UpDateHeight(false, false);
						}
					}
				}
			}
		}
		else if (sender.m_BtnID1 == 4 || sender.m_BtnID1 == 5)
		{
			if (this.bFindScrollComp[sender.m_BtnID2])
			{
				int dataIndex2 = this.Scroll_1_Comp[sender.m_BtnID2].DataIndex;
				if (dataIndex2 < this.NowList.Count)
				{
					Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
					if (door == null)
					{
						return;
					}
					if (this.NowList[dataIndex2].AllianceOrRole == 0 || sender.m_BtnID1 == 5)
					{
						this.DM.ShowLordProfile(this.NowList[dataIndex2].NameStr.ToString());
					}
					else
					{
						door.AllianceInfo(this.NowList[dataIndex2].AllianceTagStr.ToString());
					}
				}
			}
		}
		else if (sender.m_BtnID1 == 6 && this.bFindScrollComp[sender.m_BtnID2])
		{
			this.DeleteMessageIndex = this.Scroll_1_Comp[sender.m_BtnID2].DataIndex;
			if (this.DeleteMessageIndex < this.NowList.Count)
			{
				this.DeleteMessageID = this.NowList[this.DeleteMessageIndex].MessageID;
				if (this.GM.bCheckDeleteMsg)
				{
					this.GM.OpenCheckDeleteMsg();
				}
				else
				{
					this.SendDeleteMessage();
				}
			}
		}
	}

	// Token: 0x06001EAD RID: 7853 RVA: 0x003AA364 File Offset: 0x003A8564
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001EAE RID: 7854 RVA: 0x003AA368 File Offset: 0x003A8568
	public void SendDeleteMessage()
	{
		if (this.DM.RoleAlliance.Rank < AllianceRank.RANK4)
		{
			GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4753u), 255, true);
			return;
		}
		if (this.DeleteMessageIndex < this.NowList.Count && this.NowList[this.DeleteMessageIndex].AllianceOrRole >= 2)
		{
			GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(10074u), 255, true);
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_DELETECHAT;
		messagePacket.Add(this.AllianceID);
		messagePacket.Add(this.DeleteMessageID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.MessageBoard);
	}

	// Token: 0x06001EAF RID: 7855 RVA: 0x003AA454 File Offset: 0x003A8654
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x040060FD RID: 24829
	private const int UnitCount = 9;

	// Token: 0x040060FE RID: 24830
	private const float SendTalkTime = 3f;

	// Token: 0x040060FF RID: 24831
	private const float TranslateHeight = 10f;

	// Token: 0x04006100 RID: 24832
	private Transform m_transform;

	// Token: 0x04006101 RID: 24833
	private DataManager DM = DataManager.Instance;

	// Token: 0x04006102 RID: 24834
	private GUIManager GM = GUIManager.Instance;

	// Token: 0x04006103 RID: 24835
	private UIText LeftmainText;

	// Token: 0x04006104 RID: 24836
	private float BaseHeight = 55f;

	// Token: 0x04006105 RID: 24837
	private ScrollPanel Scroll;

	// Token: 0x04006106 RID: 24838
	private CScrollRect cScrollRect;

	// Token: 0x04006107 RID: 24839
	private GameObject PanelGO;

	// Token: 0x04006108 RID: 24840
	private GameObject NoMessageGO;

	// Token: 0x04006109 RID: 24841
	private List<MessageBoard> NowList;

	// Token: 0x0400610A RID: 24842
	private List<float> NowHeightList = new List<float>();

	// Token: 0x0400610B RID: 24843
	private bool[] bFindScrollComp = new bool[9];

	// Token: 0x0400610C RID: 24844
	private BMUnitComp[] Scroll_1_Comp = new BMUnitComp[9];

	// Token: 0x0400610D RID: 24845
	private CString[] TimeStr = new CString[9];

	// Token: 0x0400610E RID: 24846
	private CString[] NameStr = new CString[9];

	// Token: 0x0400610F RID: 24847
	private CString[] LanguageStr = new CString[9];

	// Token: 0x04006110 RID: 24848
	private CString[] DeleteMsgStr = new CString[9];

	// Token: 0x04006111 RID: 24849
	private UIEmojiInput Input;

	// Token: 0x04006112 RID: 24850
	private Font m_Font;

	// Token: 0x04006113 RID: 24851
	private uint AllianceID;

	// Token: 0x04006114 RID: 24852
	private UIText[] RBText = new UIText[2];

	// Token: 0x04006115 RID: 24853
	private UIButton SendBtn;

	// Token: 0x04006116 RID: 24854
	private Image SendImg;

	// Token: 0x04006117 RID: 24855
	private CString InputErroeCString;

	// Token: 0x04006118 RID: 24856
	private Color InputColor;

	// Token: 0x04006119 RID: 24857
	private Color InputErrorColor;

	// Token: 0x0400611A RID: 24858
	private long DeleteMessageID;

	// Token: 0x0400611B RID: 24859
	private int DeleteMessageIndex;
}
