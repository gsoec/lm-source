using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200052E RID: 1326
public class UIChat : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001A56 RID: 6742 RVA: 0x002CA560 File Offset: 0x002C8760
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_transform = base.transform;
		this.m_Font = this.GM.GetTTFFont();
		this.SArray = this.m_transform.GetComponent<UISpritesArray>();
		Transform child = this.m_transform.GetChild(0);
		this.KindomFlash = child.GetChild(11).GetChild(0).gameObject;
		this.AllianceFlash = child.GetChild(12).GetChild(0).gameObject;
		this.mInput = child.GetChild(6).GetComponent<UIEmojiInput>();
		this.mInput.transform.GetChild(0).GetComponent<UIText>().font = this.m_Font;
		this.mInput.transform.GetChild(1).GetComponent<UIText>().font = this.m_Font;
		this.mInput.lineType = UIEmojiInput.LineType.MultiLineNewline;
		this.mInput.textComponent.fontStyle = FontStyle.Normal;
		this.mInput.textComponent.alignment = TextAnchor.MiddleLeft;
		this.mInput.shouldHideMobileInput = false;
		this.mInput.characterLimit = 400;
		this.mInput.placeholder.GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(779u);
		this.mInput.placeholder.GetComponent<UIText>().alignment = TextAnchor.MiddleLeft;
		this.InputColor = this.mInput.placeholder.GetComponent<UIText>().color;
		this.InputErrorColor = new Color(0.596f, 0f, 0f);
		this.InputErroeCString = StringManager.Instance.SpawnString(200);
		this.InputErroeCString.IntToFormat(8L, 1, false);
		this.InputErroeCString.AppendFormat(this.DM.mStringTable.GetStringByID(9167u));
		this.ViewStateTextRC = child.GetChild(3).GetComponent<RectTransform>();
		this.ViewStateText = child.GetChild(3).GetComponent<UIText>();
		this.ViewStateText.font = this.m_Font;
		this.ViewStateImgRC = child.GetChild(2).GetComponent<RectTransform>();
		this.ViewStateImg = child.GetChild(2).GetComponent<Image>();
		this.Scroll = child.GetChild(4).GetComponent<ScrollPanel>();
		this.HelpBtnObj = child.GetChild(15).gameObject;
		this.PreBtnObject = child.GetChild(8).gameObject;
		this.MiddleBtnObject = child.GetChild(9).gameObject;
		this.PreBtn = child.GetChild(8).GetComponent<UIButton>();
		this.MiddleBtn = child.GetChild(9).GetComponent<UIButton>();
		this.BottomBtn = child.GetChild(10).GetComponent<UIButton>();
		this.SendBtn = child.GetChild(7).GetComponent<UIButton>();
		this.SendImg = this.SendBtn.transform.GetChild(0).GetComponent<Image>();
		this.EmojiBnt = child.GetChild(18).GetComponent<UIButton>();
		this.EmojiBnt.m_Handler = this;
		this.EmojiBnt.transition = Selectable.Transition.ColorTint;
		this.EmojiImg = this.EmojiBnt.transform.GetChild(0).GetComponent<Image>();
		this.EmojiAleretObj = child.GetChild(18).GetChild(1).gameObject;
		if (this.DM.AskOldData == 3)
		{
			this.OpenSendAsk = 3;
		}
		else if (this.DM.AskOldData == 2)
		{
			this.OpenSendAsk = 2;
		}
		for (int i = 7; i <= 15; i++)
		{
			if (i == 14)
			{
				child.GetChild(i).GetChild(0).GetComponent<UIButton>().m_Handler = this;
				if (this.GM.bOpenOnIPhoneX)
				{
					child.GetChild(i).GetComponent<Image>().enabled = false;
				}
			}
			else
			{
				child.GetChild(i).GetComponent<UIButton>().m_Handler = this;
			}
		}
		this.UnReadCountRC = (child.GetChild(12).GetChild(1) as RectTransform);
		this.UnReadCountText = this.UnReadCountRC.GetChild(0).GetComponent<UIText>();
		this.UnReadCountText.font = this.m_Font;
		this.UnreadStr = StringManager.Instance.SpawnString(30);
		this.CheckUnRead(this.DM.unReadCount > 0 && this.DM.bShowUnreadCount);
		this.FlashObj = child.GetChild(10).GetChild(0).gameObject;
		this.FlashObj.SetActive(false);
		this.LeftT = child.GetChild(5);
		Transform child2 = this.LeftT.GetChild(1);
		child = child2.GetChild(3);
		UIText component = child.GetComponent<UIText>();
		component.font = this.m_Font;
		component.fontStyle = FontStyle.Normal;
		child = child2.GetChild(4);
		this.TitleText = child.GetComponent<UIText>();
		this.TitleText.font = this.m_Font;
		this.TitleText.fontStyle = FontStyle.Normal;
		this.TitleText.resizeTextForBestFit = true;
		this.TitleText.resizeTextMaxSize = 18;
		this.TitleText.resizeTextMinSize = 10;
		child = child2.GetChild(13);
		component = child.GetComponent<UIText>();
		component.font = this.m_Font;
		child = child2.GetChild(15);
		component = child.GetComponent<UIText>();
		component.font = this.m_Font;
		child = child2.GetChild(5);
		this.LeftmainText = child.GetComponent<UIText>();
		this.LeftmainText.font = this.m_Font;
		child = child2.GetChild(6);
		component = child.GetComponent<UIText>();
		component.font = this.m_Font;
		component.resizeTextMinSize = 8;
		component.resizeTextMaxSize = 15;
		child = child2.GetChild(7);
		component = child.GetComponent<UIText>();
		component.font = this.m_Font;
		if (this.GM.IsArabic)
		{
			RectTransform rectTransform = child2.GetChild(1).GetComponent<Image>().rectTransform;
			rectTransform.localScale = new Vector3(-1f, 1f, 1f);
			rectTransform.anchoredPosition += new Vector2(rectTransform.sizeDelta.x, 0f);
			rectTransform = child2.GetChild(11).GetComponent<Image>().rectTransform;
			rectTransform.localScale = new Vector3(-1f, 1f, 1f);
			rectTransform.anchoredPosition += new Vector2(rectTransform.sizeDelta.x, 0f);
		}
		this.LeftT.GetChild(0).gameObject.AddComponent<IgnoreRaycast>();
		GUIManager.Instance.InitianHeroItemImg(this.LeftT.GetChild(0), eHeroOrItem.Hero, 1, 2, 0, 0, false, false, true, false);
		if (this.GM.bOpenOnIPhoneX)
		{
			((RectTransform)this.m_transform.GetChild(1)).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0f);
			((RectTransform)this.m_transform.GetChild(1)).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0f);
		}
		child = this.m_transform.GetChild(1);
		child.GetComponent<UIButton>().m_Handler = this;
		this.ClickChatObject = child.gameObject;
		for (int j = 0; j < 6; j++)
		{
			if (j == 0)
			{
				this.PlayerInfoBtn = child.GetChild(1).GetComponent<UIButton>();
				this.PlayerInfoBtn.m_Handler = this;
			}
			else if (j == 1)
			{
				this.CopyMsgObj = child.GetChild(2).gameObject;
				this.CopyMsgObj.transform.GetComponent<UIButton>().m_Handler = this;
			}
			else if (j == 2)
			{
				this.PosBtnObject = child.GetChild(3).gameObject;
				this.PosBtnObject.transform.GetComponent<UIButton>().m_Handler = this;
			}
			else if (j == 3)
			{
				this.BLBtnObject = child.GetChild(4).gameObject;
				this.BLBtnObject.transform.GetComponent<UIButton>().m_Handler = this;
			}
			else if (j == 4)
			{
				this.SendBLBtnObject = child.GetChild(5).gameObject;
				this.SendBLBtnObject.transform.GetComponent<UIButton>().m_Handler = this;
			}
			else
			{
				child.GetChild(j + 1).GetComponent<UIButton>().m_Handler = this;
			}
			component = child.GetChild(j + 1).GetChild(0).GetComponent<UIText>();
			component.font = this.m_Font;
			if (j == 0)
			{
				this.PlayerNameText = component;
				component.text = this.DM.mStringTable.GetStringByID(4535u);
			}
			else if (j == 1)
			{
				component.text = this.DM.mStringTable.GetStringByID(155u);
			}
			else if (j == 2)
			{
				this.PosText = component;
				this.PosText.text = this.DM.mStringTable.GetStringByID(156u);
				this.PosTextWidth = this.PosText.preferredWidth;
				this.PosText.rectTransform.sizeDelta = new Vector2(this.PosTextWidth, this.PosText.rectTransform.sizeDelta.y);
				this.PosText2 = child.GetChild(j + 1).GetChild(2).GetComponent<UIText>();
				this.PosText2.font = this.m_Font;
				this.PosText2.gameObject.GetComponent<Outline>().enabled = false;
			}
			else if (j == 3)
			{
				this.BLText = component;
				component.text = this.DM.mStringTable.GetStringByID(8212u);
			}
			else if (j == 4)
			{
				component.text = this.DM.mStringTable.GetStringByID(8533u);
			}
			else if (j == 5)
			{
				component.text = this.DM.mStringTable.GetStringByID(4u);
			}
		}
		this.PosImage = child.GetChild(3).GetChild(2).GetChild(0).gameObject.GetComponent<Image>();
		this.PosImgObject = child.GetChild(3).GetChild(1).gameObject;
		child = this.m_transform.GetChild(2);
		child.GetComponent<UIButton>().m_Handler = this;
		this.AllianceRequestObject = child.gameObject;
		if (this.GM.bOpenOnIPhoneX)
		{
			((RectTransform)this.m_transform.GetChild(2)).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0f);
			((RectTransform)this.m_transform.GetChild(2)).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0f);
		}
		for (int k = 0; k < 5; k++)
		{
			UIEmojiInput component2 = child.GetChild(9 + k).GetComponent<UIEmojiInput>();
			component2.characterLimit = 9;
			child.GetChild(9 + k).GetChild(0).GetComponent<UIText>().font = this.m_Font;
			child.GetChild(9 + k).GetChild(1).GetComponent<UIText>().font = this.m_Font;
		}
		component = child.GetChild(5).GetComponent<UIText>();
		component.font = this.m_Font;
		component.text = this.DM.mStringTable.GetStringByID(181u);
		component = child.GetChild(6).GetComponent<UIText>();
		component.font = this.m_Font;
		component.text = this.DM.mStringTable.GetStringByID(182u);
		child.GetChild(7).GetComponent<UIButton>().m_Handler = this;
		component = child.GetChild(7).GetChild(0).GetComponent<UIText>();
		component.font = this.m_Font;
		component.text = this.DM.mStringTable.GetStringByID(183u);
		child.GetChild(8).GetComponent<UIButton>().m_Handler = this;
		component = child.GetChild(8).GetChild(0).GetComponent<UIText>();
		component.font = this.m_Font;
		component.text = this.DM.mStringTable.GetStringByID(184u);
		for (int l = 0; l < 13; l++)
		{
			this.bFindScrollComp[l] = false;
		}
		this.Scroll.IntiScrollPanel(532f, 17f, 0f, this.NowHeightList, 13, this);
		this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
		this.cScrollRect.InitViewState(this.ViewStateText, this.ViewStateImg);
		this.OpenUpdate(arg1);
	}

	// Token: 0x06001A57 RID: 6743 RVA: 0x002CB218 File Offset: 0x002C9418
	public void OpenUpdate(int arg1)
	{
		if (this.ClickChatObject.activeInHierarchy)
		{
			this.CloseClickChatObj();
		}
		this.CheckUnRead(this.DM.unReadCount > 0 && this.DM.bShowUnreadCount);
		this.NowChannel = byte.MaxValue;
		bool flag;
		if (arg1 != 0)
		{
			flag = this.SetChannel((byte)(arg1 - 1));
		}
		else
		{
			flag = this.SetChannel(this.DM.NowChannel);
		}
		if (!flag || this.DM.bChangeKingdomClear)
		{
			this.RefreshScrollPanel(false, false);
		}
		this.DM.bChangeKingdomClear = false;
		if (BattleController.IsGambleMode)
		{
			this.GM.m_ChatBox.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001A58 RID: 6744 RVA: 0x002CB2E0 File Offset: 0x002C94E0
	private void CheckAutoScroll()
	{
		if (this.NowList.Count > 0)
		{
			if (this.DM.NowChannel == 0)
			{
				if (this.DM.NowKingdomIndex != -1)
				{
					this.Scroll.GoTo(this.DM.NowKingdomIndex, this.DM.NowKingdomPos);
				}
				else
				{
					this.Scroll.GoToLast();
				}
			}
			else
			{
				if (this.NowChannel == 1 && this.DM.unReadIndex != -1 && !this.DM.bClearUnread)
				{
					this.DM.bClearUnread = true;
				}
				if (this.AllianceChatState == 1)
				{
					if (this.DM.NowAllianceIndex2 != -1)
					{
						this.Scroll.GoTo(this.DM.NowAllianceIndex2, this.DM.NowAlliancePos2);
					}
					else
					{
						this.Scroll.GoToLast();
					}
				}
				else if (this.DM.NowAllianceIndex1 != -1)
				{
					this.Scroll.GoTo(this.DM.NowAllianceIndex1, this.DM.NowAlliancePos1);
				}
				else
				{
					this.Scroll.GoToLast();
				}
			}
		}
	}

	// Token: 0x06001A59 RID: 6745 RVA: 0x002CB424 File Offset: 0x002C9624
	public override void OnClose()
	{
		this.SavePagePara();
		for (int i = 12; i >= 0; i--)
		{
			if (this.TimeStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.TimeStr[i]);
				this.TimeStr[i] = null;
			}
			if (this.LanguageStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.LanguageStr[i]);
				this.LanguageStr[i] = null;
			}
			if (this.NameCStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.NameCStr[i]);
				this.NameCStr[i] = null;
			}
			if (this.VIPCStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.VIPCStr[i]);
				this.VIPCStr[i] = null;
			}
			if (this.Scroll_1_Comp[i].Emoji != null)
			{
				this.GM.pushEmojiIcon(this.Scroll_1_Comp[i].Emoji);
				this.Scroll_1_Comp[i].Emoji = null;
			}
		}
		StringManager.Instance.DeSpawnString(this.InputErroeCString);
		StringManager.Instance.DeSpawnString(this.UnreadStr);
		this.UnreadStr = null;
		if (this.PosStr != null)
		{
			StringManager.Instance.DeSpawnString(this.PosStr);
		}
	}

	// Token: 0x06001A5A RID: 6746 RVA: 0x002CB578 File Offset: 0x002C9778
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			for (int i = 0; i < 13; i++)
			{
				if (this.bFindScrollComp[i])
				{
					if (this.Scroll_1_Comp[i].VIPText != null && this.Scroll_1_Comp[i].VIPText.enabled)
					{
						this.Scroll_1_Comp[i].VIPText.enabled = false;
						this.Scroll_1_Comp[i].VIPText.enabled = true;
					}
					if (this.Scroll_1_Comp[i].PlayerName != null && this.Scroll_1_Comp[i].PlayerName.enabled)
					{
						this.Scroll_1_Comp[i].PlayerName.enabled = false;
						this.Scroll_1_Comp[i].PlayerName.enabled = true;
					}
					for (int j = 0; j < this.Scroll_1_Comp[i].TitleNameText.Length; j++)
					{
						if (this.Scroll_1_Comp[i].TitleNameText != null && this.Scroll_1_Comp[i].TitleNameText[j] != null && this.Scroll_1_Comp[i].TitleNameText[j].enabled)
						{
							this.Scroll_1_Comp[i].TitleNameText[j].enabled = false;
							this.Scroll_1_Comp[i].TitleNameText[j].enabled = true;
						}
					}
					if (this.Scroll_1_Comp[i].MainText != null && this.Scroll_1_Comp[i].MainText.enabled)
					{
						this.Scroll_1_Comp[i].MainText.enabled = false;
						this.Scroll_1_Comp[i].MainText.enabled = true;
					}
					if (this.Scroll_1_Comp[i].TimeText != null && this.Scroll_1_Comp[i].TimeText.enabled)
					{
						this.Scroll_1_Comp[i].TimeText.enabled = false;
						this.Scroll_1_Comp[i].TimeText.enabled = true;
					}
					if (this.Scroll_1_Comp[i].Base2Text != null && this.Scroll_1_Comp[i].Base2Text.enabled)
					{
						this.Scroll_1_Comp[i].Base2Text.enabled = false;
						this.Scroll_1_Comp[i].Base2Text.enabled = true;
					}
					if (this.Scroll_1_Comp[i].Base3Text != null && this.Scroll_1_Comp[i].Base3Text.enabled)
					{
						this.Scroll_1_Comp[i].Base3Text.enabled = false;
						this.Scroll_1_Comp[i].Base3Text.enabled = true;
					}
					if (this.Scroll_1_Comp[i].Base3TimeText != null && this.Scroll_1_Comp[i].Base3TimeText.enabled)
					{
						this.Scroll_1_Comp[i].Base3TimeText.enabled = false;
						this.Scroll_1_Comp[i].Base3TimeText.enabled = true;
					}
					if (this.Scroll_1_Comp[i].TranslateText != null && this.Scroll_1_Comp[i].TranslateText.enabled)
					{
						this.Scroll_1_Comp[i].TranslateText.enabled = false;
						this.Scroll_1_Comp[i].TranslateText.enabled = true;
					}
				}
			}
			if (this.mInput != null)
			{
				if (this.mInput.textComponent != null && this.mInput.textComponent.enabled)
				{
					this.mInput.textComponent.enabled = false;
					this.mInput.textComponent.enabled = true;
				}
				if (this.mInput.placeholder != null && this.mInput.placeholder.enabled)
				{
					this.mInput.placeholder.enabled = false;
					this.mInput.placeholder.enabled = true;
				}
			}
			if (this.PlayerNameText != null && this.PlayerNameText.enabled)
			{
				this.PlayerNameText.enabled = false;
				this.PlayerNameText.enabled = true;
			}
			if (this.PosText != null && this.PosText.enabled)
			{
				this.PosText.enabled = false;
				this.PosText.enabled = true;
			}
			if (this.PosText2 != null && this.PosText2.enabled)
			{
				this.PosText2.enabled = false;
				this.PosText2.enabled = true;
			}
			if (this.BLText != null && this.BLText.enabled)
			{
				this.BLText.enabled = false;
				this.BLText.enabled = true;
			}
		}
	}

	// Token: 0x06001A5B RID: 6747 RVA: 0x002CBB1C File Offset: 0x002C9D1C
	private void Update()
	{
		float deltaTime = Time.deltaTime;
		this.CheckTimer -= deltaTime;
		if (this.CheckTimer <= 0f)
		{
			this.CheckTimer = 0.5f;
			if (this.NowChannel == 1)
			{
				if (this.DM.unReadCount > 0 && this.DM.unReadIndex != -1 && !this.Scroll.CheckInPanel(this.DM.unReadIndex - this.BeginIndex))
				{
					ColorBlock colors = this.MiddleBtn.colors;
					colors.normalColor = Color.white;
					colors.highlightedColor = Color.white;
					this.MiddleBtn.colors = colors;
				}
				else
				{
					ColorBlock colors2 = this.MiddleBtn.colors;
					colors2.normalColor = Color.gray;
					colors2.highlightedColor = Color.gray;
					this.MiddleBtn.colors = colors2;
				}
				if (this.OpenSendAsk == 2 && (this.AllianceChatState == 0 || !this.Scroll.CheckInPanel(this.DM.LastTimeIndex)))
				{
					ColorBlock colors3 = this.PreBtn.colors;
					colors3.normalColor = Color.white;
					colors3.highlightedColor = Color.white;
					this.PreBtn.colors = colors3;
				}
				else
				{
					ColorBlock colors4 = this.PreBtn.colors;
					colors4.normalColor = Color.gray;
					colors4.highlightedColor = Color.gray;
					this.PreBtn.colors = colors4;
				}
				bool flag = this.Scroll.CheckAtLast();
				if (this.AllianceChatState == 1 || (this.AllianceChatState != 1 && !flag))
				{
					ColorBlock colors5 = this.BottomBtn.colors;
					colors5.normalColor = Color.white;
					colors5.highlightedColor = Color.white;
					this.BottomBtn.colors = colors5;
				}
				else
				{
					ColorBlock colors6 = this.BottomBtn.colors;
					colors6.normalColor = Color.gray;
					colors6.highlightedColor = Color.gray;
					this.BottomBtn.colors = colors6;
				}
				this.CheckFlashBottomBtn();
			}
			else
			{
				bool flag2 = this.Scroll.CheckAtLast();
				if (this.NowList.Count > 0 && !flag2)
				{
					ColorBlock colors7 = this.BottomBtn.colors;
					colors7.normalColor = Color.white;
					colors7.highlightedColor = Color.white;
					this.BottomBtn.colors = colors7;
				}
				else
				{
					ColorBlock colors8 = this.BottomBtn.colors;
					colors8.normalColor = Color.gray;
					colors8.highlightedColor = Color.gray;
					this.BottomBtn.colors = colors8;
				}
			}
		}
		if ((!this.cScrollRect.bStopViewState || !this.cScrollRect.bStopViewState_Up) && this.NowViewState != this.cScrollRect.ViewState)
		{
			this.NowViewState = this.cScrollRect.ViewState;
			switch (this.NowViewState)
			{
			case ListViewState.LVS_PULL_REFRESH:
				this.ViewStateTextRC.anchoredPosition = new Vector2(30f, 267.5f);
				this.ViewStateImgRC.anchoredPosition = new Vector2(-75f, 267.5f);
				this.ViewStateImgRC.localRotation = new Quaternion(0f, 0f, 0f, 0f);
				this.ViewStateImgRC.sizeDelta = new Vector2(26f, 25f);
				this.ViewStateImg.sprite = this.SArray.m_Sprites[15];
				break;
			case ListViewState.LVS_RELEASE_REFRESH:
				this.ViewStateTextRC.anchoredPosition = new Vector2(30f, 267.5f);
				this.ViewStateImgRC.anchoredPosition = new Vector2(-75f, 267.5f);
				this.ViewStateImgRC.localRotation = new Quaternion(0f, 0f, 0f, 0f);
				this.ViewStateImgRC.sizeDelta = new Vector2(26f, 25f);
				this.ViewStateImg.sprite = this.SArray.m_Sprites[14];
				break;
			case ListViewState.LVS_LOADING:
			{
				this.ViewStateTextRC.anchoredPosition = new Vector2(30f, 267.5f);
				this.ViewStateImgRC.anchoredPosition = new Vector2(-12f, 267.5f);
				this.ViewStateImgRC.sizeDelta = new Vector2(26f, 26f);
				this.ViewStateImg.sprite = this.SArray.m_Sprites[16];
				int num = this.FindNowTopIndex();
				if (this.DM.SendAskKind == -1 && num != -1)
				{
					if (this.AllianceChatState == 0)
					{
						this.DM.SendAskKind = 2;
					}
					else if (this.AllianceChatState == 1)
					{
						this.DM.SendAskKind = 0;
					}
					else if (this.AllianceChatState == 2)
					{
						this.DM.SendAskKind = 0;
					}
					this.DM.SendAskData(this.NowChannel, 1, this.DM.SendAskKind, this.NowList[num].TalkID, this.NowList[num].TalkTime);
					this.cScrollRect.SwitchViewState(ListViewState.LVS_WAITLOADING);
				}
				else
				{
					this.cScrollRect.SwitchViewState(ListViewState.LVS_NORMAL);
				}
				break;
			}
			case ListViewState.LVS_PULL_REFRESH_UP:
				this.ViewStateTextRC.anchoredPosition = new Vector2(30f, -205f);
				this.ViewStateImgRC.anchoredPosition = new Vector2(-75f, -205f);
				this.ViewStateImgRC.localRotation = new Quaternion(0f, 0f, 0f, 0f);
				this.ViewStateImgRC.sizeDelta = new Vector2(26f, 25f);
				this.ViewStateImg.sprite = this.SArray.m_Sprites[14];
				break;
			case ListViewState.LVS_RELEASE_REFRESH_UP:
				this.ViewStateTextRC.anchoredPosition = new Vector2(30f, -205f);
				this.ViewStateImgRC.anchoredPosition = new Vector2(-75f, -205f);
				this.ViewStateImgRC.localRotation = new Quaternion(0f, 0f, 0f, 0f);
				this.ViewStateImgRC.sizeDelta = new Vector2(26f, 25f);
				this.ViewStateImg.sprite = this.SArray.m_Sprites[15];
				break;
			case ListViewState.LVS_LOADING_UP:
				this.ViewStateTextRC.anchoredPosition = new Vector2(30f, -205f);
				this.ViewStateImgRC.anchoredPosition = new Vector2(-12f, -205f);
				this.ViewStateImgRC.sizeDelta = new Vector2(26f, 26f);
				this.ViewStateImg.sprite = this.SArray.m_Sprites[16];
				if (this.DM.SendAskKind == -1 && this.DM.MiddleTopIndex != -1)
				{
					this.DM.SendAskKind = 1;
					this.DM.SendAskData(this.NowChannel, 0, this.DM.SendAskKind, this.NowList[this.DM.MiddleTopIndex].TalkID, this.NowList[this.DM.MiddleTopIndex].TalkTime);
					this.cScrollRect.SwitchViewState(ListViewState.LVS_WAITLOADING_UP);
				}
				else
				{
					this.cScrollRect.SwitchViewState(ListViewState.LVS_NORMAL);
				}
				break;
			}
		}
	}

	// Token: 0x06001A5C RID: 6748 RVA: 0x002CC2D4 File Offset: 0x002CA4D4
	private int FindNowTopIndex()
	{
		if (this.BeginIndex != -1)
		{
			for (int i = this.BeginIndex; i <= this.EndIndex; i++)
			{
				if (i < 0 || i >= this.NowList.Count)
				{
					return -1;
				}
				if (this.NowList[i].TalkID != 0L)
				{
					return i;
				}
			}
		}
		return -1;
	}

	// Token: 0x06001A5D RID: 6749 RVA: 0x002CC33C File Offset: 0x002CA53C
	private void CheckFlashBottomBtn()
	{
		if (this.NewTalkCount > 0)
		{
			if (this.NowChannel == 0 && this.FlashObj.activeInHierarchy)
			{
				this.FlashObj.SetActive(false);
			}
			if (this.NowChannel == 1)
			{
				bool flag = this.Scroll.CheckAtLast();
				if (this.AllianceChatState == 1 || (this.AllianceChatState != 1 && !flag))
				{
					if (!this.FlashObj.activeInHierarchy)
					{
						this.FlashObj.SetActive(true);
					}
				}
				else if (this.FlashObj.activeInHierarchy)
				{
					this.FlashObj.SetActive(false);
					if (this.AllianceChatState != 1 && flag)
					{
						this.NewTalkCount = 0;
					}
				}
			}
		}
		else if (this.FlashObj.activeInHierarchy)
		{
			this.FlashObj.SetActive(false);
		}
	}

	// Token: 0x06001A5E RID: 6750 RVA: 0x002CC42C File Offset: 0x002CA62C
	private bool SetChannel(byte Channel)
	{
		if (Channel == this.NowChannel)
		{
			return false;
		}
		this.NowChannel = Channel;
		this.DM.NowChannel = this.NowChannel;
		this.cScrollRect.StopMovement();
		if (this.NowChannel == 0)
		{
			this.HelpBtnObj.SetActive(false);
			this.PreBtnObject.SetActive(false);
			this.MiddleBtnObject.SetActive(false);
			this.NowList = this.DM.TalkData_Kingdom;
			this.NowHeightList = this.DM.Height_Kingdom;
			this.KindomFlash.SetActive(true);
			this.AllianceFlash.SetActive(false);
			this.DM.SendAskData(0, 0, -1, 0L, 0L);
			this.CheckStopViewState();
		}
		else if (this.NowChannel == 1)
		{
			this.HelpBtnObj.SetActive(false);
			this.PreBtnObject.SetActive(true);
			this.MiddleBtnObject.SetActive(true);
			this.NowList = this.DM.TalkData_Alliance;
			this.NowHeightList = this.DM.Height_Alliance;
			this.KindomFlash.SetActive(false);
			this.AllianceFlash.SetActive(true);
			if (this.DM.NowAlliancePage != -1)
			{
				this.SetAllianceState((byte)this.DM.NowAlliancePage);
			}
			else
			{
				this.SetAllianceState(0);
				this.DM.NowAlliancePage = 0;
			}
			this.CheckUnRead(false);
			if (this.DM.RoleAlliance.Id > 0u && this.DM.SendAskKind == -1 && this.OpenSendAsk == 0 && this.DM.AskOldData == 0)
			{
				this.OpenSendAsk = 1;
				this.DM.SendAskKind = 4;
				this.DM.AskOldData = 1;
				this.DM.SendAskData(1, 0, this.DM.SendAskKind, 0L, this.DM.LastTime);
			}
		}
		this.RefreshScrollPanel(true, true);
		this.CheckAutoScroll();
		this.CheckFlashBottomBtn();
		this.CheckSpeakInKindom();
		this.GM.UpdateChatBox((this.NowChannel != 0) ? 7 : 6, 0);
		return true;
	}

	// Token: 0x06001A5F RID: 6751 RVA: 0x002CC65C File Offset: 0x002CA85C
	private void CheckEmojiAlert()
	{
		if (this.DM.CheckShowOnGroundInfo())
		{
			this.EmojiAleretObj.SetActive(true);
		}
		else
		{
			this.EmojiAleretObj.SetActive(false);
		}
	}

	// Token: 0x06001A60 RID: 6752 RVA: 0x002CC68C File Offset: 0x002CA88C
	private void CheckSpeakInKindom()
	{
		if (this.NowChannel == 0 && this.GM.BuildingData.GetBuildData(8, 0).Level < 8)
		{
			this.mInput.interactable = false;
			this.SendBtn.interactable = false;
			this.EmojiBnt.interactable = false;
			this.EmojiImg.color = Color.gray;
			this.SendImg.color = Color.gray;
			this.EmojiAleretObj.SetActive(false);
			UIText component = this.mInput.placeholder.GetComponent<UIText>();
			component.text = this.InputErroeCString.ToString();
			component.color = this.InputErrorColor;
			this.mInput.text = string.Empty;
		}
		else
		{
			this.mInput.interactable = true;
			this.SendBtn.interactable = true;
			this.EmojiBnt.interactable = true;
			this.EmojiImg.color = Color.white;
			this.SendImg.color = Color.white;
			this.CheckEmojiAlert();
			UIText component2 = this.mInput.placeholder.GetComponent<UIText>();
			component2.text = this.DM.mStringTable.GetStringByID(779u);
			component2.color = this.InputColor;
		}
	}

	// Token: 0x06001A61 RID: 6753 RVA: 0x002CC7DC File Offset: 0x002CA9DC
	private void CheckStopViewState()
	{
		if (this.NowChannel == 1 && this.NowList.Count > 0)
		{
			this.cScrollRect.bStopViewState = false;
		}
		else
		{
			this.cScrollRect.bStopViewState = true;
		}
		if (this.NowChannel == 1 && this.AllianceChatState == 1)
		{
			this.cScrollRect.bStopViewState_Up = false;
		}
		else
		{
			this.cScrollRect.bStopViewState_Up = true;
		}
	}

	// Token: 0x06001A62 RID: 6754 RVA: 0x002CC858 File Offset: 0x002CAA58
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			if (arg2 == (int)this.NowChannel || arg2 == 2)
			{
				if (this.cScrollRect.ViewState == ListViewState.LVS_WAITLOADING || this.cScrollRect.ViewState == ListViewState.LVS_WAITLOADING_UP)
				{
					this.cScrollRect.SwitchViewState(ListViewState.LVS_NORMAL);
				}
				bool flag = this.NowList[this.NowList.Count - 1].PlayID == this.DM.RoleAttr.UserId;
				bool flag2 = this.cScrollRect.IsAtLast();
				if (this.NowChannel == 0)
				{
					if (this.NowList.Count < 30 && this.DM.KindomRecvType == 0)
					{
						this.NowIndexList.Add(this.NowList.Count - 1);
						this.Scroll.AddItem(this.GetUnitHeight(this.NowList.Count - 1), false);
					}
					else
					{
						this.SavePagePara();
						this.RefreshScrollPanel(true, true);
						this.CheckAutoScroll();
					}
					if (flag || flag2)
					{
						this.Scroll.GoToLast();
					}
				}
				else if (this.NowChannel == 1)
				{
					if (this.AllianceChatState == 1)
					{
						if (flag)
						{
							this.SetAllianceState(0);
							this.RefreshScrollPanel(true, true);
							this.Scroll.GoToLast();
						}
						this.NewTalkCount++;
					}
					else
					{
						int beginIndex = this.BeginIndex;
						int endIndex = this.EndIndex;
						this.CheckBeginEndIndex();
						if (beginIndex != this.BeginIndex || endIndex != this.EndIndex)
						{
							this.NowIndexList.Add(this.NowList.Count - 1);
							this.Scroll.AddItem(this.GetUnitHeight(this.NowList.Count - 1), false);
						}
						else
						{
							this.RefreshScrollPanel(true, true);
						}
						if (flag || flag2)
						{
							this.SetAllianceState(0);
							this.Scroll.GoToLast();
						}
						if (!flag2)
						{
							this.NewTalkCount++;
						}
					}
				}
			}
			break;
		case 2:
			if (this.cScrollRect.ViewState == ListViewState.LVS_WAITLOADING || this.cScrollRect.ViewState == ListViewState.LVS_WAITLOADING_UP)
			{
				this.cScrollRect.SwitchViewState(ListViewState.LVS_NORMAL);
			}
			break;
		case 3:
		{
			if (this.NowChannel != 1)
			{
				return;
			}
			bool flag3 = this.Scroll.CheckAtLast();
			int topIdx = this.Scroll.GetTopIdx();
			if (arg2 == 4 && this.OpenSendAsk != 1)
			{
				this.SetAllianceState(1);
			}
			else
			{
				this.SetAllianceState(this.AllianceChatState);
			}
			if (arg2 == 4 && this.OpenSendAsk == 1)
			{
				this.OpenSendAsk = 2;
			}
			this.RefreshScrollPanel(true, true);
			this.cScrollRect.StopMovement();
			if (arg2 == 4 && this.AllianceChatState == 2)
			{
				this.Scroll.GoToLast();
				this.SavePagePara();
			}
			else if (arg2 == 0 || arg2 == 2)
			{
				this.Scroll.GoTo(this.DM.ThisTimeCounts - 1);
			}
			else if (arg2 == 1)
			{
				this.Scroll.GoTo(topIdx + 1);
			}
			else if (arg2 == 5)
			{
				this.Scroll.GoTo(topIdx);
			}
			else if (flag3)
			{
				this.Scroll.GoToLast();
			}
			else
			{
				this.Scroll.GoTo(topIdx);
			}
			if (this.cScrollRect.ViewState == ListViewState.LVS_WAITLOADING || this.cScrollRect.ViewState == ListViewState.LVS_WAITLOADING_UP)
			{
				this.cScrollRect.SwitchViewState(ListViewState.LVS_NORMAL);
			}
			break;
		}
		case 4:
			this.OpenSendAsk = 2;
			this.SetAllianceState(1);
			this.RefreshScrollPanel(true, true);
			break;
		case 5:
			this.SetAllianceState(0);
			this.RefreshScrollPanel(true, true);
			break;
		case 6:
			this.SetAllianceState(0);
			this.SetChannel(0);
			break;
		case 7:
			this.CheckUnRead(true);
			break;
		case 8:
		{
			this.OpenSendAsk = 3;
			ColorBlock colors = this.PreBtn.colors;
			colors.normalColor = Color.gray;
			colors.highlightedColor = Color.gray;
			this.PreBtn.colors = colors;
			break;
		}
		case 9:
			this.OpenUpdate(arg2);
			break;
		case 10:
			this.CheckTranslated();
			break;
		case 12:
			this.RefreshScrollPanel(false, false);
			break;
		case 13:
			this.CheckSpeakInKindom();
			break;
		case 14:
			if (arg2 == (int)this.NowChannel)
			{
				this.SavePagePara();
				this.RefreshScrollPanel(true, true);
				this.CheckAutoScroll();
			}
			break;
		case 15:
			this.SendEmoji((ushort)arg2);
			break;
		case 16:
			this.CheckEmojiAlert();
			break;
		}
	}

	// Token: 0x06001A63 RID: 6755 RVA: 0x002CCD48 File Offset: 0x002CAF48
	private float CheckTitleHeight(int Index)
	{
		float num = 0f;
		byte b = 0;
		TitleData recordByKey = this.DM.TitleData.GetRecordByKey(0);
		float num2 = -1f;
		float num3 = 0f;
		this.NowList[Index].TitleLine = 1;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		for (int i = 0; i < 3; i++)
		{
			ushort num4 = 0;
			if (!flag && this.NowList[Index].WTitleID == 1)
			{
				num4 = 1;
				recordByKey = this.DM.TitleDataW.GetRecordByKey(1);
				flag = true;
			}
			else if (!flag2 && this.NowList[Index].NTitleID == 1)
			{
				num4 = 1;
				recordByKey = this.DM.TitleDataF.GetRecordByKey(1);
				flag2 = true;
			}
			else if (!flag3 && this.NowList[Index].TitleID == 1)
			{
				num4 = 1;
				recordByKey = this.DM.TitleData.GetRecordByKey(1);
				flag3 = true;
			}
			else if (!flag && this.NowList[Index].WTitleID != 0)
			{
				num4 = this.NowList[Index].WTitleID;
				recordByKey = this.DM.TitleDataW.GetRecordByKey(this.NowList[Index].WTitleID);
				flag = true;
			}
			else if (!flag2 && this.NowList[Index].NTitleID != 0)
			{
				num4 = this.NowList[Index].NTitleID;
				recordByKey = this.DM.TitleDataF.GetRecordByKey(this.NowList[Index].NTitleID);
				flag2 = true;
			}
			else if (!flag3 && this.NowList[Index].TitleID != 0)
			{
				num4 = (ushort)this.NowList[Index].TitleID;
				recordByKey = this.DM.TitleData.GetRecordByKey((ushort)this.NowList[Index].TitleID);
				flag3 = true;
			}
			if (num4 != 0)
			{
				this.TitleText.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.StringID);
				if (num2 > 0f)
				{
					float preferredWidth = this.TitleText.preferredWidth;
					float x;
					if (num2 + preferredWidth + 35f > 425f)
					{
						num += this.TitleHeight;
						x = -1f;
						num3 += this.TitleHeight;
						num2 = preferredWidth;
						TalkDataType talkDataType = this.NowList[Index];
						talkDataType.TitleLine += 1;
					}
					else
					{
						x = num2;
						num2 = num2 + preferredWidth + 35f;
					}
					this.NowList[Index].TitlePos[(int)b].x = x;
					this.NowList[Index].TitlePos[(int)b].y = num3;
					b += 1;
				}
				else
				{
					num2 = this.TitleText.preferredWidth;
				}
			}
		}
		return num;
	}

	// Token: 0x06001A64 RID: 6756 RVA: 0x002CD06C File Offset: 0x002CB26C
	private float GetUnitHeight(int Index)
	{
		if (Index < 0 || Index >= this.NowList.Count)
		{
			return 0f;
		}
		if (this.GM.bAutoTranslate && this.NowList[Index].TalkKind == 0 && this.NowList[Index].TranslateShow != 0 && this.NowList[Index].PlayID != this.DM.RoleAttr.UserId && this.NowList[Index].TranslateState == eTranslateState.completed)
		{
			if (this.NowList[Index].TotalHeightT != 0f)
			{
				return this.NowList[Index].TotalHeightT;
			}
			float num = this.UnitbaseHeight + 10f;
			this.LeftmainText.text = this.NowList[Index].TranslateText.ToString();
			if (this.NowList[Index].TitleID > 0 || this.NowList[Index].WTitleID > 0 || this.NowList[Index].NTitleID > 0)
			{
				num += this.CheckTitleHeight(Index);
				num += this.LeftmainText.preferredHeight;
			}
			else if (this.LeftmainText.preferredHeight > this.TitleHeight)
			{
				num += this.LeftmainText.preferredHeight - this.TitleHeight;
			}
			num += 5f;
			this.NowList[Index].TotalHeightT = num;
			return num;
		}
		else
		{
			if (this.NowList[Index].TotalHeight != 0f)
			{
				return this.NowList[Index].TotalHeight;
			}
			float num2 = this.UnitbaseHeight;
			if (this.NowList[Index].TalkKind == 0)
			{
				if (this.NowList[Index].FuncKind == 109)
				{
					EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(this.NowList[Index].EmojiKey);
					if (this.NowList[Index].TitleID > 0 || this.NowList[Index].WTitleID > 0 || this.NowList[Index].NTitleID > 0)
					{
						num2 += this.CheckTitleHeight(Index);
						num2 += (float)recordByKey.sizeY;
					}
					else
					{
						num2 += (float)recordByKey.sizeY - this.TitleHeight;
					}
					num2 += 5f;
				}
				else
				{
					if (this.GM.bAutoTranslate && this.NowList[Index].PlayID != this.DM.RoleAttr.UserId && this.NowList[Index].TranslateState != eTranslateState.NoNeedTranslate)
					{
						num2 += 10f;
					}
					this.LeftmainText.text = this.NowList[Index].MainText.ToString();
					if (this.NowList[Index].TitleID > 0 || this.NowList[Index].WTitleID > 0 || this.NowList[Index].NTitleID > 0)
					{
						num2 += this.CheckTitleHeight(Index);
						num2 += this.LeftmainText.preferredHeight;
					}
					else if (this.LeftmainText.preferredHeight > this.TitleHeight)
					{
						num2 += this.LeftmainText.preferredHeight - this.TitleHeight;
					}
					num2 += 5f;
				}
			}
			else if (this.NowList[Index].TalkKind == 1 || this.NowList[Index].TalkKind == 2)
			{
				num2 = 49f;
			}
			else if (this.NowList[Index].TalkKind >= 3 && this.NowList[Index].TalkKind <= 11)
			{
				this.LeftmainText.text = this.NowList[Index].MainText.ToString();
				num2 = this.LeftmainText.preferredHeight + 30f;
			}
			this.NowList[Index].TotalHeight = num2;
			return num2;
		}
	}

	// Token: 0x06001A65 RID: 6757 RVA: 0x002CD4D4 File Offset: 0x002CB6D4
	private void RefreshScrollPanel(bool GoToTop = true, bool bStopMove = true)
	{
		this.NowHeightList.Clear();
		this.NowIndexList.Clear();
		if (this.NowChannel == 0)
		{
			this.BeginIndex = 0;
			this.EndIndex = this.NowList.Count - 1;
			for (int i = 0; i < this.NowList.Count; i++)
			{
				this.NowHeightList.Add(this.GetUnitHeight(i));
				this.NowIndexList.Add(i);
			}
		}
		else
		{
			this.CheckBeginEndIndex();
			if (this.BeginIndex != -1)
			{
				for (int j = this.BeginIndex; j < this.EndIndex + 1; j++)
				{
					if (j >= 0 && j < this.NowList.Count && !this.DM.CheckHideTalk(this.NowList[j]))
					{
						this.NowHeightList.Add(this.GetUnitHeight(j));
						this.NowIndexList.Add(j);
					}
				}
			}
		}
		this.Scroll.AddNewDataHeight(this.NowHeightList, GoToTop, bStopMove);
	}

	// Token: 0x06001A66 RID: 6758 RVA: 0x002CD5F0 File Offset: 0x002CB7F0
	private void InputEnd(string tmpStr, eTextCheck State = eTextCheck.Text_None)
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
		this.SendChat(tmpStr, State);
	}

	// Token: 0x06001A67 RID: 6759 RVA: 0x002CD6E8 File Offset: 0x002CB8E8
	private void SendChat(string tmpStr, eTextCheck State = eTextCheck.Text_None)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_SENDCHAT;
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
		messagePacket.AddSeqId();
		messagePacket.Add(this.NowChannel);
		messagePacket.Add(this.NowInputType);
		if (this.DM.ServerVersionMajor != 0)
		{
			messagePacket.Add((byte)State);
		}
		messagePacket.Add((ushort)bytes.Length);
		messagePacket.Add(bytes, 0, 0);
		messagePacket.Send(false);
		this.DM.sendTimer = this.DM.SendTalkTime;
		this.NowInputType = 0;
		this.mInput.text = string.Empty;
		if (this.NowChannel == 1)
		{
			AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.CHAT_INGUILD);
		}
	}

	// Token: 0x06001A68 RID: 6760 RVA: 0x002CD7E8 File Offset: 0x002CB9E8
	private void SendEmoji(ushort EmojiKey)
	{
		if (this.DM.sendTimer > 0f)
		{
			this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(658u), 255, true);
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_SENDCHAT;
		EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(EmojiKey);
		messagePacket.AddSeqId();
		messagePacket.Add(this.NowChannel);
		messagePacket.Add(109);
		if (this.DM.ServerVersionMajor != 0)
		{
			messagePacket.Add(0);
		}
		messagePacket.Add(4);
		messagePacket.Add(EmojiKey);
		messagePacket.Add(recordByKey.IconID);
		messagePacket.Send(false);
		this.DM.sendTimer = this.DM.SendTalkTime;
		if (this.NowChannel == 1)
		{
			AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.CHAT_INGUILD);
		}
	}

	// Token: 0x06001A69 RID: 6761 RVA: 0x002CD8DC File Offset: 0x002CBADC
	private void CheckTranslated()
	{
		for (int i = 0; i < 13; i++)
		{
			if (this.bFindScrollComp[i] && this.Scroll_1_Comp[i].ItemGO.activeInHierarchy && this.Scroll_1_Comp[i].TalkDataIndex != -1)
			{
				int talkDataIndex = this.Scroll_1_Comp[i].TalkDataIndex;
				if (this.NowList[talkDataIndex].TalkID == this.GM.TranslateData.TalkID)
				{
					this.Scroll_1_Comp[i].TranslateImgGO.SetActive(false);
					this.Scroll_1_Comp[i].TranslateBtnGO.SetActive(true);
					this.RefreshScrollPanel(false, false);
					break;
				}
			}
		}
		for (int j = 0; j < 13; j++)
		{
			if (this.bFindScrollComp[j] && this.Scroll_1_Comp[j].ItemGO.activeInHierarchy && this.Scroll_1_Comp[j].TalkDataIndex != -1)
			{
				int talkDataIndex2 = this.Scroll_1_Comp[j].TalkDataIndex;
				if (this.NowList[talkDataIndex2].TranslateState != eTranslateState.Translation)
				{
					bool flag = this.NowList[talkDataIndex2].PlayID != this.DM.RoleAttr.UserId && this.GM.bAutoTranslate && this.NowList[talkDataIndex2].TranslateState != eTranslateState.NoNeedTranslate;
					if (flag)
					{
						this.Scroll_1_Comp[j].TranslateBtnGO.SetActive(true);
					}
					this.Scroll_1_Comp[j].TranslateImgGO.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06001A6A RID: 6762 RVA: 0x002CDAC0 File Offset: 0x002CBCC0
	private void CheckTranslateNext()
	{
		if (!this.GM.bAutoTranslate || this.GM.bWaitTranslate)
		{
			return;
		}
		for (int i = 0; i < 13; i++)
		{
			if (this.bFindScrollComp[i] && this.Scroll_1_Comp[i].ItemGO.activeInHierarchy && this.Scroll_1_Comp[i].TalkDataIndex != -1)
			{
				int talkDataIndex = this.Scroll_1_Comp[i].TalkDataIndex;
				if (this.NowList[talkDataIndex].TranslateState == eTranslateState.Untranslated && this.NowList[talkDataIndex].TalkKind == 0 && this.NowList[talkDataIndex].PlayID != this.DM.RoleAttr.UserId && this.GM.TransLatebyIndex(this.NowList[talkDataIndex]))
				{
					this.Scroll_1_Comp[i].TranslateImgGO.SetActive(true);
					this.Scroll_1_Comp[i].TranslateBtnGO.SetActive(false);
					return;
				}
			}
		}
	}

	// Token: 0x06001A6B RID: 6763 RVA: 0x002CDBF0 File Offset: 0x002CBDF0
	public byte GetBackImageIndex(int dataIdx)
	{
		if (this.NowChannel == 0 && this.NowList[dataIdx].KingdomID != 0 && DataManager.MapDataController.OtherKingdomData.kingdomID != ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.kingdomData.kingdomID != this.NowList[dataIdx].KingdomID)
		{
			return 11;
		}
		if (this.NowList[dataIdx].SpecialBlockID == 1)
		{
			return 11;
		}
		if (this.NowList[dataIdx].SpecialBlockID == 2)
		{
			return 10;
		}
		if (this.NowList[dataIdx].SpecialBlockID == 3 || this.NowList[dataIdx].SpecialBlockID == 7 || this.NowList[dataIdx].SpecialBlockID == 8)
		{
			return 9;
		}
		if (this.NowList[dataIdx].SpecialBlockID == 4 || this.NowList[dataIdx].SpecialBlockID == 9)
		{
			return 8;
		}
		if (this.NowList[dataIdx].SpecialBlockID == 5)
		{
			return 7;
		}
		return 6;
	}

	// Token: 0x06001A6C RID: 6764 RVA: 0x002CDD2C File Offset: 0x002CBF2C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId == 1 && panelObjectIdx < 13)
		{
			float num = 0f;
			if (!this.bFindScrollComp[panelObjectIdx])
			{
				this.bFindScrollComp[panelObjectIdx] = true;
				Transform child = item.transform.GetChild(1);
				this.Scroll_1_Comp[panelObjectIdx].TalkDataIndex = -1;
				this.Scroll_1_Comp[panelObjectIdx].ItemGO = item.gameObject;
				this.Scroll_1_Comp[panelObjectIdx].Base0RC = item.transform.GetChild(0).GetComponent<RectTransform>();
				this.Scroll_1_Comp[panelObjectIdx].Base1RC = child.GetComponent<RectTransform>();
				this.Scroll_1_Comp[panelObjectIdx].VIPText = child.GetChild(7).GetComponent<UIText>();
				this.VIPCStr[panelObjectIdx] = StringManager.Instance.SpawnString(10);
				this.Scroll_1_Comp[panelObjectIdx].GuildRankImg = child.GetChild(11).GetComponent<Image>();
				this.Scroll_1_Comp[panelObjectIdx].PlayerName = child.GetChild(3).GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].PlayerName.SetCheckArabic(true);
				this.NameCStr[panelObjectIdx] = StringManager.Instance.SpawnString(80);
				this.Scroll_1_Comp[panelObjectIdx].ChairmanT = new Transform[3];
				this.Scroll_1_Comp[panelObjectIdx].ChairmanImg = new Image[3];
				this.Scroll_1_Comp[panelObjectIdx].TitleNameT = new Transform[3];
				this.Scroll_1_Comp[panelObjectIdx].TitleNameText = new UIText[3];
				this.Scroll_1_Comp[panelObjectIdx].ChairmanT[0] = child.GetChild(2);
				this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[0] = this.Scroll_1_Comp[panelObjectIdx].ChairmanT[0].GetComponent<Image>();
				this.Scroll_1_Comp[panelObjectIdx].ChairmanT[1] = child.GetChild(12);
				this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[1] = this.Scroll_1_Comp[panelObjectIdx].ChairmanT[1].GetComponent<Image>();
				this.Scroll_1_Comp[panelObjectIdx].ChairmanT[2] = child.GetChild(16);
				this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[2] = this.Scroll_1_Comp[panelObjectIdx].ChairmanT[2].GetComponent<Image>();
				this.Scroll_1_Comp[panelObjectIdx].TitleNameT[0] = child.GetChild(4);
				this.Scroll_1_Comp[panelObjectIdx].TitleNameText[0] = this.Scroll_1_Comp[panelObjectIdx].TitleNameT[0].GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].TitleNameT[1] = child.GetChild(13);
				this.Scroll_1_Comp[panelObjectIdx].TitleNameText[1] = this.Scroll_1_Comp[panelObjectIdx].TitleNameT[1].GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].TitleNameT[2] = child.GetChild(15);
				this.Scroll_1_Comp[panelObjectIdx].TitleNameText[2] = this.Scroll_1_Comp[panelObjectIdx].TitleNameT[2].GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].TranslateImgGO = child.GetChild(8).gameObject;
				this.Scroll_1_Comp[panelObjectIdx].TranslateText = child.GetChild(9).GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].TranslateText.font = this.m_Font;
				this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO = child.GetChild(10).gameObject;
				UIButton component = this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO.transform.GetComponent<UIButton>();
				component.m_Handler = this;
				component.m_BtnID2 = panelObjectIdx;
				Transform child2 = child.GetChild(5);
				this.Scroll_1_Comp[panelObjectIdx].MainRC = child2.GetComponent<RectTransform>();
				this.Scroll_1_Comp[panelObjectIdx].MainText = child2.GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].MainText.SetCheckArabic(true);
				this.Scroll_1_Comp[panelObjectIdx].BackImgRC = child.GetChild(0).GetComponent<RectTransform>();
				this.Scroll_1_Comp[panelObjectIdx].BackImg = child.GetChild(0).GetComponent<Image>();
				this.Scroll_1_Comp[panelObjectIdx].TimeText = child.GetChild(6).GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].Base2GO = item.transform.GetChild(2).gameObject;
				this.Scroll_1_Comp[panelObjectIdx].Base2Text = item.transform.GetChild(2).GetChild(2).GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].Base2Text.font = this.m_Font;
				this.Scroll_1_Comp[panelObjectIdx].Base3GO = item.transform.GetChild(3).GetComponent<RectTransform>();
				this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC = item.transform.GetChild(3).GetChild(0).GetComponent<RectTransform>();
				this.Scroll_1_Comp[panelObjectIdx].Base3Text = item.transform.GetChild(3).GetChild(1).GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.font = this.m_Font;
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText = item.transform.GetChild(3).GetChild(2).GetComponent<UIText>();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.font = this.m_Font;
				this.OriginalColor = this.Scroll_1_Comp[panelObjectIdx].Base3Text.color;
				this.TimeStr[panelObjectIdx] = StringManager.Instance.SpawnString(20);
				this.LanguageStr[panelObjectIdx] = StringManager.Instance.SpawnString(150);
				this.Scroll_1_Comp[panelObjectIdx].EmojiRC = child.GetChild(14).GetComponent<RectTransform>();
				if (this.GM.IsArabic)
				{
					this.Scroll_1_Comp[panelObjectIdx].EmojiRC.localScale = new Vector3(-1f, 1f, 1f);
				}
			}
			if (dataIdx < 0 || dataIdx >= this.NowIndexList.Count)
			{
				return;
			}
			dataIdx = this.NowIndexList[dataIdx];
			if (dataIdx < 0 || dataIdx >= this.NowList.Count)
			{
				return;
			}
			this.Scroll_1_Comp[panelObjectIdx].TalkDataIndex = -1;
			if (this.NowList[dataIdx].TalkKind == 0)
			{
				this.Scroll_1_Comp[panelObjectIdx].TalkDataIndex = dataIdx;
				this.Scroll_1_Comp[panelObjectIdx].Base0RC.gameObject.SetActive(true);
				this.Scroll_1_Comp[panelObjectIdx].Base1RC.gameObject.SetActive(true);
				this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base3GO.gameObject.SetActive(false);
				int num2 = (this.NowList[dataIdx].PlayID != this.DM.RoleAttr.UserId) ? 0 : 1;
				this.VIPCStr[panelObjectIdx].Length = 0;
				StringManager.IntToStr(this.VIPCStr[panelObjectIdx], (long)this.NowList[dataIdx].VIPRank, 1, false);
				this.Scroll_1_Comp[panelObjectIdx].VIPText.text = this.VIPCStr[panelObjectIdx].ToString();
				this.Scroll_1_Comp[panelObjectIdx].VIPText.SetVerticesDirty();
				this.Scroll_1_Comp[panelObjectIdx].VIPText.SetLayoutDirty();
				this.Scroll_1_Comp[panelObjectIdx].VIPText.cachedTextGenerator.Invalidate();
				bool flag = this.NowList[dataIdx].AllyRank > 0;
				if (flag)
				{
					this.Scroll_1_Comp[panelObjectIdx].GuildRankImg.gameObject.SetActive(true);
					this.Scroll_1_Comp[panelObjectIdx].GuildRankImg.sprite = this.SArray.m_Sprites[(int)(this.NowList[dataIdx].AllyRank + 16)];
					Vector2 vector = new Vector2(113f, -7f);
					this.Scroll_1_Comp[panelObjectIdx].PlayerName.rectTransform.sizeDelta = new Vector2(385f, 25f);
					vector = this.Scroll_1_Comp[panelObjectIdx].PlayerName.ArabicFixPos(vector);
					this.Scroll_1_Comp[panelObjectIdx].PlayerName.rectTransform.anchoredPosition = vector;
				}
				else
				{
					this.Scroll_1_Comp[panelObjectIdx].GuildRankImg.gameObject.SetActive(false);
					Vector2 vector = new Vector2(78f, -7f);
					this.Scroll_1_Comp[panelObjectIdx].PlayerName.rectTransform.sizeDelta = new Vector2(410f, 25f);
					vector = this.Scroll_1_Comp[panelObjectIdx].PlayerName.ArabicFixPos(vector);
					this.Scroll_1_Comp[panelObjectIdx].PlayerName.rectTransform.anchoredPosition = vector;
				}
				if (this.NowList[dataIdx].NickNameText.Length > 0)
				{
					bool flag2 = this.NowChannel == 0 && this.NowList[dataIdx].KingdomID > 0 && this.NowList[dataIdx].KingdomID != DataManager.MapDataController.kingdomData.kingdomID;
					ushort kingdomID = (!flag2) ? 0 : this.NowList[dataIdx].KingdomID;
					GameConstants.FormatRoleName(this.NameCStr[panelObjectIdx], this.NowList[dataIdx].PlayerName, this.NowList[dataIdx].TitleName, this.NowList[dataIdx].NickNameText, 0, kingdomID, null, null, null, "<color=#005EA5>");
					this.Scroll_1_Comp[panelObjectIdx].PlayerName.text = this.NameCStr[panelObjectIdx].ToString();
					this.Scroll_1_Comp[panelObjectIdx].PlayerName.SetAllDirty();
					this.Scroll_1_Comp[panelObjectIdx].PlayerName.cachedTextGenerator.Invalidate();
				}
				else
				{
					this.Scroll_1_Comp[panelObjectIdx].PlayerName.text = this.NowList[dataIdx].ShowName.ToString();
				}
				this.Scroll_1_Comp[panelObjectIdx].ChairmanT[0].gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].TitleNameT[0].gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].ChairmanT[1].gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].TitleNameT[1].gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].ChairmanT[2].gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].TitleNameT[2].gameObject.SetActive(false);
				byte b = 0;
				eTitleKind kind = eTitleKind.KvkTitle;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				TitleData recordByKey = this.DM.TitleData.GetRecordByKey(0);
				for (int i = 0; i < 3; i++)
				{
					ushort num3 = 0;
					if (!flag3 && this.NowList[dataIdx].WTitleID == 1)
					{
						kind = eTitleKind.WorldTitle;
						num3 = 1;
						recordByKey = this.DM.TitleDataW.GetRecordByKey(1);
						flag3 = true;
					}
					else if (!flag4 && this.NowList[dataIdx].NTitleID == 1)
					{
						kind = eTitleKind.NobilityTitle;
						num3 = 1;
						recordByKey = this.DM.TitleDataF.GetRecordByKey(1);
						flag4 = true;
					}
					else if (!flag5 && this.NowList[dataIdx].TitleID == 1)
					{
						kind = eTitleKind.KvkTitle;
						num3 = 1;
						recordByKey = this.DM.TitleData.GetRecordByKey(1);
						flag5 = true;
					}
					else if (!flag3 && this.NowList[dataIdx].WTitleID != 0)
					{
						kind = eTitleKind.WorldTitle;
						num3 = this.NowList[dataIdx].WTitleID;
						recordByKey = this.DM.TitleDataW.GetRecordByKey(this.NowList[dataIdx].WTitleID);
						flag3 = true;
					}
					else if (!flag4 && this.NowList[dataIdx].NTitleID != 0)
					{
						kind = eTitleKind.NobilityTitle;
						num3 = this.NowList[dataIdx].NTitleID;
						recordByKey = this.DM.TitleDataF.GetRecordByKey(this.NowList[dataIdx].NTitleID);
						flag4 = true;
					}
					else if (!flag5 && this.NowList[dataIdx].TitleID != 0)
					{
						kind = eTitleKind.KvkTitle;
						num3 = (ushort)this.NowList[dataIdx].TitleID;
						recordByKey = this.DM.TitleData.GetRecordByKey((ushort)this.NowList[dataIdx].TitleID);
						flag5 = true;
					}
					if (num3 != 0)
					{
						this.Scroll_1_Comp[panelObjectIdx].ChairmanT[(int)b].gameObject.SetActive(true);
						this.Scroll_1_Comp[panelObjectIdx].TitleNameT[(int)b].gameObject.SetActive(true);
						this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[(int)b].sprite = this.GM.LoadTitleSprite(recordByKey.IconID, kind);
						this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[(int)b].material = this.GM.GetTitleMaterial();
						this.Scroll_1_Comp[panelObjectIdx].TitleNameText[(int)b].text = this.DM.mStringTable.GetStringByID((uint)recordByKey.StringID);
						if (b > 0)
						{
							if (this.NowList[dataIdx].TitlePos[(int)(b - 1)].x < 0f)
							{
								this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[(int)b].rectTransform.anchoredPosition = new Vector2(this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[0].rectTransform.anchoredPosition.x, this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[0].rectTransform.anchoredPosition.y - this.NowList[dataIdx].TitlePos[(int)(b - 1)].y);
								this.Scroll_1_Comp[panelObjectIdx].TitleNameText[(int)b].rectTransform.anchoredPosition = new Vector2(this.Scroll_1_Comp[panelObjectIdx].TitleNameText[0].rectTransform.anchoredPosition.x, this.Scroll_1_Comp[panelObjectIdx].TitleNameText[0].rectTransform.anchoredPosition.y - this.NowList[dataIdx].TitlePos[(int)(b - 1)].y);
							}
							else
							{
								this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[(int)b].rectTransform.anchoredPosition = new Vector2(this.Scroll_1_Comp[panelObjectIdx].TitleNameText[0].rectTransform.anchoredPosition.x + this.NowList[dataIdx].TitlePos[(int)(b - 1)].x + 5f, this.Scroll_1_Comp[panelObjectIdx].TitleNameText[0].rectTransform.anchoredPosition.y - this.NowList[dataIdx].TitlePos[(int)(b - 1)].y);
								this.Scroll_1_Comp[panelObjectIdx].TitleNameText[(int)b].rectTransform.anchoredPosition = new Vector2(this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[(int)b].rectTransform.anchoredPosition.x + 30f, this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[(int)b].rectTransform.anchoredPosition.y);
							}
						}
						b += 1;
					}
				}
				bool flag6 = this.NowList[dataIdx].FuncKind == 109;
				bool flag7 = num2 == 0 && this.GM.bAutoTranslate && this.NowList[dataIdx].TranslateState != eTranslateState.NoNeedTranslate;
				float num4 = 0f;
				if (flag7)
				{
					num4 = 10f;
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
				float num5;
				if (flag6)
				{
					this.Scroll_1_Comp[panelObjectIdx].MainText.gameObject.SetActive(false);
					this.Scroll_1_Comp[panelObjectIdx].EmojiRC.gameObject.SetActive(true);
					EmojiData recordByKey2 = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(this.NowList[dataIdx].EmojiKey);
					num5 = (float)recordByKey2.sizeY;
					if (this.Scroll_1_Comp[panelObjectIdx].Emoji != null)
					{
						this.GM.pushEmojiIcon(this.Scroll_1_Comp[panelObjectIdx].Emoji);
						this.Scroll_1_Comp[panelObjectIdx].Emoji = null;
					}
					this.Scroll_1_Comp[panelObjectIdx].Emoji = this.GM.pullEmojiIcon(recordByKey2.IconID, recordByKey2.KeyFrame, false);
					this.Scroll_1_Comp[panelObjectIdx].Emoji.EmojiTransform.SetParent(this.Scroll_1_Comp[panelObjectIdx].EmojiRC, false);
					if (num5 <= 70f)
					{
						((RectTransform)this.Scroll_1_Comp[panelObjectIdx].Emoji.EmojiTransform).anchoredPosition = Vector2.zero;
					}
					else
					{
						((RectTransform)this.Scroll_1_Comp[panelObjectIdx].Emoji.EmojiTransform).anchoredPosition = new Vector2(0f, -((num5 - 70f) / 2f));
					}
				}
				else
				{
					this.Scroll_1_Comp[panelObjectIdx].MainText.gameObject.SetActive(true);
					this.Scroll_1_Comp[panelObjectIdx].EmojiRC.gameObject.SetActive(false);
					if (flag7 && this.NowList[dataIdx].TranslateShow != 0 && this.NowList[dataIdx].TranslateState == eTranslateState.completed)
					{
						this.Scroll_1_Comp[panelObjectIdx].MainText.text = this.NowList[dataIdx].TranslateText.ToString();
					}
					else
					{
						this.Scroll_1_Comp[panelObjectIdx].MainText.SetText(this.NowList[dataIdx].MainText.ToString(), (eTextCheck)this.NowList[dataIdx].bHaveArabic);
					}
					this.Scroll_1_Comp[panelObjectIdx].MainText.SetLayoutDirty();
					this.Scroll_1_Comp[panelObjectIdx].MainText.cachedTextGeneratorForLayout.Invalidate();
					num5 = this.Scroll_1_Comp[panelObjectIdx].MainText.preferredHeight;
				}
				this.Scroll_1_Comp[panelObjectIdx].MainRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].MainRC.sizeDelta.x, num5);
				if (b > 0)
				{
					num = num5 + this.TitleHeight * (float)(this.NowList[dataIdx].TitleLine - 1);
					this.Scroll_1_Comp[panelObjectIdx].MainRC.anchoredPosition = new Vector2(this.Scroll_1_Comp[panelObjectIdx].MainRC.anchoredPosition.x, -38f - this.TitleHeight * (float)this.NowList[dataIdx].TitleLine);
				}
				else
				{
					this.Scroll_1_Comp[panelObjectIdx].MainRC.anchoredPosition = new Vector2(this.Scroll_1_Comp[panelObjectIdx].MainRC.anchoredPosition.x, -38f);
					if (num5 > this.TitleHeight)
					{
						num = num5 - this.TitleHeight;
					}
				}
				this.Scroll_1_Comp[panelObjectIdx].BackImg.sprite = this.SArray.m_Sprites[(int)this.GetBackImageIndex(dataIdx)];
				if (flag6)
				{
					this.Scroll_1_Comp[panelObjectIdx].EmojiRC.anchoredPosition = new Vector2(50.4f, this.Scroll_1_Comp[panelObjectIdx].MainRC.anchoredPosition.y) + ((!this.GM.IsArabic) ? Vector2.zero : new Vector2(70f, 0f));
				}
				num += num4;
				this.Scroll_1_Comp[panelObjectIdx].Base1RC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base1RC.sizeDelta.x, this.UnitbaseHeight + num);
				this.Scroll_1_Comp[panelObjectIdx].BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].BackImgRC.sizeDelta.x, this.UnitbaseHeight + num);
				if (num2 == 0)
				{
					this.Scroll_1_Comp[panelObjectIdx].Base1RC.anchoredPosition = new Vector2(99f, 0f);
					this.Scroll_1_Comp[panelObjectIdx].BackImgRC.anchoredPosition = new Vector2(0f, 0f);
					this.Scroll_1_Comp[panelObjectIdx].BackImgRC.localRotation = new Quaternion(0f, 0f, 0f, 0f);
				}
				else
				{
					this.Scroll_1_Comp[panelObjectIdx].Base1RC.anchoredPosition = new Vector2(2f, 0f);
					this.Scroll_1_Comp[panelObjectIdx].BackImgRC.anchoredPosition = new Vector2(638f, 0f);
					this.Scroll_1_Comp[panelObjectIdx].BackImgRC.localRotation = new Quaternion(0f, -180f, 0f, 0f);
				}
				if (num2 == 0)
				{
					this.Scroll_1_Comp[panelObjectIdx].Base0RC.anchoredPosition = new Vector2(28f, -2f);
				}
				else
				{
					this.Scroll_1_Comp[panelObjectIdx].Base0RC.anchoredPosition = new Vector2(638f, -2f);
				}
				GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(0), eHeroOrItem.Hero, this.NowList[dataIdx].PlayerPicID, 11, 0, 0);
				this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
				this.Scroll_1_Comp[panelObjectIdx].TimeText.text = this.TimeStr[panelObjectIdx].ToString();
				this.Scroll_1_Comp[panelObjectIdx].TimeText.SetVerticesDirty();
				this.Scroll_1_Comp[panelObjectIdx].TimeText.SetLayoutDirty();
				this.Scroll_1_Comp[panelObjectIdx].TimeText.cachedTextGenerator.Invalidate();
			}
			else if (this.NowList[dataIdx].TalkKind == 1)
			{
				this.Scroll_1_Comp[panelObjectIdx].Base0RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base1RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base3GO.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(true);
				this.Scroll_1_Comp[panelObjectIdx].Base2Text.text = this.DM.mStringTable.GetStringByID(305u);
			}
			else if (this.NowList[dataIdx].TalkKind == 2)
			{
				this.Scroll_1_Comp[panelObjectIdx].Base0RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base1RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base3GO.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(true);
				this.Scroll_1_Comp[panelObjectIdx].Base2Text.text = this.DM.mStringTable.GetStringByID(306u);
			}
			else if (this.NowList[dataIdx].TalkKind == 3)
			{
				this.Scroll_1_Comp[panelObjectIdx].Base0RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base1RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base3GO.gameObject.SetActive(true);
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.color = this.OriginalColor;
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.text = this.NowList[dataIdx].MainText.ToString();
				float num5 = this.Scroll_1_Comp[panelObjectIdx].Base3Text.preferredHeight + 18f;
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.rectTransform.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3Text.rectTransform.sizeDelta.x, num5);
				this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta.x, num5);
				this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.text = this.TimeStr[panelObjectIdx].ToString();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.SetVerticesDirty();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.SetLayoutDirty();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.cachedTextGenerator.Invalidate();
			}
			else if (this.NowList[dataIdx].TalkKind == 4)
			{
				this.Scroll_1_Comp[panelObjectIdx].Base0RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base1RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base3GO.gameObject.SetActive(true);
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.color = Color.green;
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.text = this.NowList[dataIdx].MainText.ToString();
				float num5 = this.Scroll_1_Comp[panelObjectIdx].Base3Text.preferredHeight + 18f;
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.rectTransform.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3Text.rectTransform.sizeDelta.x, num5);
				this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta.x, num5);
				this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.text = this.TimeStr[panelObjectIdx].ToString();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.SetVerticesDirty();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.SetLayoutDirty();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.cachedTextGenerator.Invalidate();
			}
			else if (this.NowList[dataIdx].TalkKind == 5)
			{
				this.Scroll_1_Comp[panelObjectIdx].Base0RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base1RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base3GO.gameObject.SetActive(true);
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.color = Color.green;
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.text = this.NowList[dataIdx].MainText.ToString();
				float num5 = this.Scroll_1_Comp[panelObjectIdx].Base3Text.preferredHeight + 18f;
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.rectTransform.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3Text.rectTransform.sizeDelta.x, num5);
				this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta.x, num5);
				this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.text = this.TimeStr[panelObjectIdx].ToString();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.SetVerticesDirty();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.SetLayoutDirty();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.cachedTextGenerator.Invalidate();
			}
			else if (this.NowList[dataIdx].TalkKind == 6 || this.NowList[dataIdx].TalkKind == 7)
			{
				this.Scroll_1_Comp[panelObjectIdx].Base0RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base1RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base3GO.gameObject.SetActive(true);
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.color = Color.green;
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.text = this.NowList[dataIdx].MainText.ToString();
				float num5 = this.Scroll_1_Comp[panelObjectIdx].Base3Text.preferredHeight + 18f;
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.rectTransform.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3Text.rectTransform.sizeDelta.x, num5);
				this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta.x, num5);
				this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.text = this.TimeStr[panelObjectIdx].ToString();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.SetVerticesDirty();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.SetLayoutDirty();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.cachedTextGenerator.Invalidate();
			}
			else if (this.NowList[dataIdx].TalkKind == 8)
			{
				this.Scroll_1_Comp[panelObjectIdx].Base0RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base1RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base3GO.gameObject.SetActive(true);
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.color = this.OriginalColor;
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.text = this.NowList[dataIdx].MainText.ToString();
				float num5 = this.Scroll_1_Comp[panelObjectIdx].Base3Text.preferredHeight + 18f;
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.rectTransform.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3Text.rectTransform.sizeDelta.x, num5);
				this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta.x, num5);
				this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.text = this.TimeStr[panelObjectIdx].ToString();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.SetVerticesDirty();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.SetLayoutDirty();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.cachedTextGenerator.Invalidate();
			}
			else if (this.NowList[dataIdx].TalkKind >= 9 && this.NowList[dataIdx].TalkKind <= 11)
			{
				this.Scroll_1_Comp[panelObjectIdx].Base0RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base1RC.gameObject.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
				this.Scroll_1_Comp[panelObjectIdx].Base3GO.gameObject.SetActive(true);
				if (this.NowList[dataIdx].TalkKind == 10 || this.NowList[dataIdx].TalkKind == 11)
				{
					this.Scroll_1_Comp[panelObjectIdx].Base3Text.color = new Color32(byte.MaxValue, 238, 158, byte.MaxValue);
				}
				else
				{
					this.Scroll_1_Comp[panelObjectIdx].Base3Text.color = new Color32(byte.MaxValue, 235, 4, byte.MaxValue);
				}
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.text = this.NowList[dataIdx].MainText.ToString();
				float num5 = this.Scroll_1_Comp[panelObjectIdx].Base3Text.preferredHeight + 18f;
				this.Scroll_1_Comp[panelObjectIdx].Base3Text.rectTransform.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3Text.rectTransform.sizeDelta.x, num5);
				this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta.x, num5);
				this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.text = this.TimeStr[panelObjectIdx].ToString();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.SetVerticesDirty();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.SetLayoutDirty();
				this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x06001A6D RID: 6765 RVA: 0x002D0568 File Offset: 0x002CE768
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		if (panelId == 1)
		{
			int num = this.NowIndexList[dataIndex];
			if (this.NowList[num].TalkKind == 0)
			{
				int count = this.NowList.Count;
				if (count > 0 && num < count)
				{
					this.ClickChatData = this.NowList[num];
					this.ClickChatPlayID = this.ClickChatData.PlayID;
					this.PlayerNameText.text = this.ClickChatData.PlayerName.ToString();
					if (BattleController.IsGambleMode)
					{
						this.PlayerNameText.color = Color.gray;
					}
					else
					{
						this.PlayerNameText.color = Color.white;
					}
					if (this.ClickChatData.FuncKind == 109)
					{
						this.CopyMsgObj.SetActive(false);
					}
					else
					{
						this.CopyMsgObj.SetActive(true);
					}
					if (this.ClickChatData.bHasLoc)
					{
						this.PosBtnObject.SetActive(true);
						this.PosImgObject.SetActive(true);
						if (this.PosStr == null)
						{
							this.PosStr = StringManager.Instance.SpawnString(30);
						}
						this.PosStr.Length = 0;
						if (this.ClickChatData.King != -1)
						{
							this.PosStr.IntToFormat((long)this.ClickChatData.King, 1, false);
							this.PosStr.IntToFormat((long)this.ClickChatData.LocX, 1, false);
							this.PosStr.IntToFormat((long)this.ClickChatData.LocY, 1, false);
							this.PosStr.AppendFormat("{0}:{1}:{2}");
						}
						else
						{
							this.PosStr.IntToFormat((long)this.ClickChatData.LocX, 1, false);
							this.PosStr.IntToFormat((long)this.ClickChatData.LocY, 1, false);
							this.PosStr.AppendFormat("{0}:{1}");
						}
						this.PosText2.text = this.PosStr.ToString();
						this.PosText2.SetAllDirty();
						this.PosText2.cachedTextGenerator.Invalidate();
						this.PosText2.cachedTextGeneratorForLayout.Invalidate();
						this.PosText2.rectTransform.sizeDelta = new Vector2(this.PosText2.preferredWidth, this.PosText2.rectTransform.sizeDelta.y);
						float num2 = 194.5f - (this.PosTextWidth + this.PosText2.preferredWidth + 10f) / 2f;
						this.PosText.rectTransform.anchoredPosition = new Vector2(num2, this.PosText.rectTransform.anchoredPosition.y);
						this.PosText2.rectTransform.anchoredPosition = new Vector2(num2 + this.PosTextWidth + 10f, this.PosText2.rectTransform.anchoredPosition.y);
						if (BattleController.IsGambleMode)
						{
							this.PosText.color = Color.gray;
							this.PosText2.color = Color.gray;
							this.PosImage.color = Color.gray;
						}
						else
						{
							this.PosText.color = Color.white;
							this.PosText2.color = Color.blue;
							this.PosImage.color = Color.blue;
						}
					}
					else
					{
						this.PosBtnObject.SetActive(false);
						this.PosImgObject.SetActive(false);
					}
					if (this.ClickChatData.PlayID != this.DM.RoleAttr.UserId)
					{
						this.BLBtnObject.SetActive(true);
						if (this.DM.FindBlackList(this.ClickChatData.PlayerName))
						{
							this.BLText.text = this.DM.mStringTable.GetStringByID(8213u);
						}
						else
						{
							this.BLText.text = this.DM.mStringTable.GetStringByID(8212u);
						}
					}
					else
					{
						this.BLBtnObject.SetActive(false);
					}
					if (this.ClickChatData.PlayID != this.DM.RoleAttr.UserId)
					{
						this.SendBLBtnObject.SetActive(true);
					}
					else
					{
						this.SendBLBtnObject.SetActive(false);
					}
					this.ClickChatObject.SetActive(true);
				}
			}
			else if (this.NowList[num].TalkKind == 5)
			{
				if (this.CheckIsGambleModeShowMsg())
				{
					return;
				}
				if (this.NowList[num].PlayerPicID != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1478u), 255, true);
					return;
				}
				this.SavePagePara();
				this.DM.SendKingdomBullitin_Info(true);
			}
			else if (this.NowList[num].TalkKind == 6)
			{
				if (this.CheckIsGambleModeShowMsg())
				{
					return;
				}
				if (this.NowList[num].NPCID != 0L)
				{
					this.SavePagePara();
					this.GM.Send_REQUEST_NPC_RALLY_DETAIL_BYID(this.NowList[num].NPCID);
				}
			}
			else if (this.NowList[num].TalkKind == 7)
			{
				if (ActivityManager.Instance.AllianceSummon_SummonData.MonsterEndTime > 0L)
				{
					this.SavePagePara();
					int kingdomID = (int)ActivityManager.Instance.AllianceSummon_SummonData.MonsterPos.KingdomID;
					int mapID = GameConstants.PointCodeToMapID(ActivityManager.Instance.AllianceSummon_SummonData.MonsterPos.CombatPoint.zoneID, ActivityManager.Instance.AllianceSummon_SummonData.MonsterPos.CombatPoint.pointID);
					Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					door.GoToMapID((ushort)kingdomID, mapID, 0, 1, true);
				}
				else
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8342u), 255, true);
				}
			}
			else if (this.NowList[num].TalkKind == 9)
			{
				if (this.CheckIsGambleModeShowMsg())
				{
					return;
				}
				ActivityManager instance = ActivityManager.Instance;
				ActivityGiftManager instance2 = ActivityGiftManager.Instance;
				if (instance2.EnableRedPocketNum > 0 || (instance2.ActivityGiftBeginTime != 0L && instance.ServerEventTime >= instance2.ActivityGiftBeginTime && instance2.ActivityGiftEndTime != 0L && instance.ServerEventTime <= instance2.ActivityGiftEndTime))
				{
					UIAlliance_ActivityGift uialliance_ActivityGift = this.GM.FindMenu(EGUIWindow.UI_Alliance_ActivityGift) as UIAlliance_ActivityGift;
					Door door2 = this.GM.FindMenu(EGUIWindow.Door) as Door;
					if (door2 != null)
					{
						this.SavePagePara();
						if (uialliance_ActivityGift == null)
						{
							ActivityGiftManager.Instance.mActivityGiftPage = 0;
							door2.OpenMenu(EGUIWindow.UI_Alliance_ActivityGift, 0, 0, false);
						}
						else if (!uialliance_ActivityGift.gameObject.activeSelf)
						{
							door2.CloseMenu(false);
							GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 5, 0);
						}
						else
						{
							GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 5, 0);
						}
					}
				}
				else
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(16101u), 255, true);
				}
			}
		}
		else if (panelId == 2)
		{
		}
	}

	// Token: 0x06001A6E RID: 6766 RVA: 0x002D0CF4 File Offset: 0x002CEEF4
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			switch (sender.m_BtnID2)
			{
			case 1:
				if (this.NowChannel == 1 && DataManager.Instance.RoleAlliance.Id == 0u)
				{
					Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
					if (door != null)
					{
						door.AllianceOnClick();
					}
				}
				else if (!this.cScrollRect.CheckBeLoad() && this.mInput.text.Length > 0)
				{
					string tmpStr;
					eTextCheck state;
					this.mInput.GetText(out tmpStr, out state);
					this.InputEnd(tmpStr, state);
				}
				break;
			case 2:
				if (this.NowChannel == 1 && DataManager.Instance.RoleAlliance.Id == 0u)
				{
					Door door2 = this.GM.FindMenu(EGUIWindow.Door) as Door;
					if (door2 != null)
					{
						door2.AllianceOnClick();
					}
				}
				else if (this.DM.AskOldData == 0)
				{
					if (this.DM.SendAskKind == -1)
					{
						this.DM.SendAskKind = 4;
						this.DM.AskOldData = 1;
						this.DM.SendAskData(1, 0, this.DM.SendAskKind, 0L, this.DM.LastTime);
					}
				}
				else if (this.DM.AskOldData != 1)
				{
					if (this.DM.AskOldData == 2)
					{
						if ((this.AllianceChatState == 1 || this.AllianceChatState == 2) && this.DM.LastTimeIndex != -1 && this.Scroll.CheckInPanel(this.DM.LastTimeIndex - this.BeginIndex))
						{
							this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(709u), 255, true);
							return;
						}
						if (this.AllianceChatState == 0)
						{
							this.SetAllianceState(1);
							this.RefreshScrollPanel(true, true);
						}
						this.Scroll.GoTo(this.DM.LastTimeIndex - this.BeginIndex);
					}
					else
					{
						this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(238u), 255, true);
					}
				}
				break;
			case 3:
				this.SavePagePara();
				this.SetChannel(0);
				break;
			case 4:
				if (this.DM.RoleAlliance.Id == 0u)
				{
					if (this.CheckIsGambleModeShowMsg())
					{
						return;
					}
					if (this.GM.FindMenu(EGUIWindow.UI_AllianceHint) != null)
					{
						Door door3 = this.GM.FindMenu(EGUIWindow.Door) as Door;
						if (door3 != null)
						{
							door3.CloseMenu(false);
						}
					}
					else
					{
						if (this.GM.m_WindowStack.Count > 0 && this.GM.m_WindowStack[this.GM.m_WindowStack.Count - 1].m_eWindow == EGUIWindow.UI_Chat)
						{
							this.GM.m_WindowStack.RemoveAt(this.GM.m_WindowStack.Count - 1);
						}
						Door door4 = this.GM.FindMenu(EGUIWindow.Door) as Door;
						if (door4 != null)
						{
							door4.AllianceOnClick();
						}
					}
				}
				else
				{
					this.SavePagePara();
					this.SetChannel(1);
				}
				break;
			case 6:
				this.CloseSelf();
				break;
			case 7:
				this.AllianceRequestObject.SetActive(!this.AllianceRequestObject.activeInHierarchy);
				break;
			case 8:
				if (!this.cScrollRect.CheckBeLoad())
				{
					if (this.DM.unReadCount <= 0)
					{
						this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(239u), 255, true);
						return;
					}
					if (this.DM.unReadIndex != -1 && this.Scroll.CheckInPanel(this.DM.unReadIndex - this.BeginIndex))
					{
						this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(710u), 255, true);
						return;
					}
					if (this.AllianceChatState == 1)
					{
						this.SetAllianceState(0);
						this.RefreshScrollPanel(true, true);
					}
					this.Scroll.GoTo(this.DM.unReadIndex - this.BeginIndex);
				}
				break;
			case 9:
				if (!this.cScrollRect.CheckBeLoad())
				{
					if (this.AllianceChatState != 1 && this.Scroll.CheckAtLast())
					{
						this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(247u), 255, true);
						return;
					}
					if (this.AllianceChatState == 1)
					{
						this.SetAllianceState(0);
						this.RefreshScrollPanel(true, true);
					}
					this.Scroll.GoToLast();
					this.NewTalkCount = 0;
				}
				break;
			case 10:
				this.GM.OpenMenu(EGUIWindow.UIEmojiSelect, 2, 0, false, true, false);
				break;
			}
		}
		else if (sender.m_BtnID1 == 3)
		{
			if (this.ClickChatData == null || this.ClickChatData.PlayID != this.ClickChatPlayID)
			{
				this.CloseClickChatObj();
				return;
			}
			if (sender.m_BtnID2 == 1)
			{
				if (this.CheckIsGambleModeShowMsg())
				{
					return;
				}
				if (this.GM.FindMenu(EGUIWindow.UI_LordInfo))
				{
					this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
				}
				if (this.ClickChatData.PlayID == this.DM.RoleAttr.UserId)
				{
					Door door5 = this.GM.FindMenu(EGUIWindow.Door) as Door;
					if (door5 == null)
					{
						return;
					}
					door5.OpenMenu(EGUIWindow.UI_LordInfo, 1, 0, true);
				}
				else
				{
					DataManager.Instance.ShowLordProfile(this.ClickChatData.PlayerName.ToString());
				}
			}
			else if (sender.m_BtnID2 == 2)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(this.ClickChatData.OriginalText.ToString(), 0, this.ClickChatData.OriginalText.Length);
				this.SetInputText(stringBuilder.ToString());
			}
			else if (sender.m_BtnID2 == 3)
			{
				if (this.CheckIsGambleModeShowMsg())
				{
					return;
				}
				Door door6 = this.GM.FindMenu(EGUIWindow.Door) as Door;
				if (door6 == null)
				{
					return;
				}
				if (this.ClickChatData.bHasLoc)
				{
					if (this.ClickChatData.King != -1)
					{
						door6.GoToMapID((ushort)this.ClickChatData.King, GameConstants.TileMapPosToMapID(this.ClickChatData.LocX, this.ClickChatData.LocY), 0, 1, true);
					}
					else
					{
						door6.GoToMapID(DataManager.MapDataController.OtherKingdomData.kingdomID, GameConstants.TileMapPosToMapID(this.ClickChatData.LocX, this.ClickChatData.LocY), 0, 1, true);
					}
				}
			}
			else if (sender.m_BtnID2 == 4)
			{
				if (this.DM.FindBlackList(this.ClickChatData.PlayerName))
				{
					this.DM.RemoveBlackList(this.ClickChatData.PlayerName);
				}
				else
				{
					this.DM.AddBlackList(this.ClickChatData.PlayerName, this.ClickChatData.PlayerPicID);
				}
			}
			else if (sender.m_BtnID2 != 5)
			{
				if (sender.m_BtnID2 == 6)
				{
					this.GM.MsgStr.Length = 0;
					this.GM.MsgStr.StringToFormat(this.ClickChatData.PlayerName);
					this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(8535u));
					this.GM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(8534u), this.GM.MsgStr.ToString(), 0, 0, this.DM.mStringTable.GetStringByID(3925u), this.DM.mStringTable.GetStringByID(3926u));
				}
			}
			this.SavePagePara();
			this.CloseClickChatObj();
		}
		else if (sender.m_BtnID1 == 4)
		{
			if (sender.m_BtnID2 == 1)
			{
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_SENDCHAT;
				byte[] bytes = Encoding.UTF8.GetBytes(this.mInput.text.ToCharArray(), 0, this.mInput.text.Length);
				messagePacket.AddSeqId();
				messagePacket.Add(this.NowChannel);
				messagePacket.Add(3);
				messagePacket.Add((ushort)bytes.Length);
				messagePacket.Add(bytes, 0, 0);
				messagePacket.Send(false);
			}
			else if (sender.m_BtnID2 == 2)
			{
				MessagePacket messagePacket2 = new MessagePacket(1024);
				messagePacket2.Protocol = Protocol._MSG_REQUEST_SENDCHAT;
				byte[] bytes2 = Encoding.UTF8.GetBytes(this.mInput.text.ToCharArray(), 0, this.mInput.text.Length);
				messagePacket2.AddSeqId();
				messagePacket2.Add(this.NowChannel);
				messagePacket2.Add(4);
				messagePacket2.Add((ushort)bytes2.Length);
				messagePacket2.Add(bytes2, 0, 0);
				messagePacket2.Send(false);
			}
			this.AllianceRequestObject.SetActive(false);
		}
		else if (sender.m_BtnID1 == 5)
		{
			if (sender.m_BtnID2 == 1)
			{
			}
		}
		else if (sender.m_BtnID1 == 6 && this.bFindScrollComp[sender.m_BtnID2])
		{
			int talkDataIndex = this.Scroll_1_Comp[sender.m_BtnID2].TalkDataIndex;
			if (talkDataIndex < this.NowList.Count)
			{
				if (this.NowList[talkDataIndex].TranslateState == eTranslateState.completed)
				{
					if (this.NowList[talkDataIndex].TranslateShow == 0)
					{
						this.NowList[talkDataIndex].TranslateShow = 1;
					}
					else
					{
						this.NowList[talkDataIndex].TranslateShow = 0;
					}
					this.RefreshScrollPanel(false, false);
				}
				else if (this.NowList[talkDataIndex].TranslateState != eTranslateState.Translation)
				{
					if ((this.NowList[talkDataIndex].TranslateState == eTranslateState.Untranslated || this.NowList[talkDataIndex].TranslateState == eTranslateState.TranslateFail) && !this.GM.bWaitTranslate && this.GM.TransLatebyIndex(this.NowList[talkDataIndex]))
					{
						this.Scroll_1_Comp[sender.m_BtnID2].TranslateImgGO.SetActive(true);
						this.Scroll_1_Comp[sender.m_BtnID2].TranslateBtnGO.SetActive(false);
					}
				}
			}
		}
	}

	// Token: 0x06001A6F RID: 6767 RVA: 0x002D1850 File Offset: 0x002CFA50
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8536u), 255, true);
		}
	}

	// Token: 0x06001A70 RID: 6768 RVA: 0x002D188C File Offset: 0x002CFA8C
	private void SetSBTime(long time, CString tmpS)
	{
		tmpS.ClearString();
		if (this.GM.IsArabic)
		{
			if (time >= 0L && time < 60L)
			{
				tmpS.IntToFormat(time, 1, false);
				if (time > 1L)
				{
					tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(446u));
				}
				else
				{
					tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(442u));
				}
			}
			else if (time >= 60L && time < 3600L)
			{
				long num = time / 60L;
				tmpS.IntToFormat(num, 1, false);
				if (num > 1L)
				{
					tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(447u));
				}
				else
				{
					tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(443u));
				}
			}
			else if (time >= 3600L && time < 86400L)
			{
				long num2 = time / 3600L;
				tmpS.IntToFormat(num2, 1, false);
				if (num2 > 1L)
				{
					tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(448u));
				}
				else
				{
					tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(444u));
				}
			}
			else if (time >= 86400L)
			{
				long num3 = time / 86400L;
				tmpS.IntToFormat(num3, 1, false);
				if (num3 > 1L)
				{
					tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(449u));
				}
				else
				{
					tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(445u));
				}
			}
			else
			{
				tmpS.IntToFormat(0L, 1, false);
				tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(442u));
			}
			tmpS.AppendFormat("{0} {1}");
		}
		else if (time >= 0L && time < 60L)
		{
			tmpS.IntToFormat(time, 1, false);
			if (time > 1L)
			{
				tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(446u));
			}
			else
			{
				tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(442u));
			}
		}
		else if (time >= 60L && time < 3600L)
		{
			long num4 = time / 60L;
			tmpS.IntToFormat(num4, 1, false);
			if (num4 > 1L)
			{
				tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(447u));
			}
			else
			{
				tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(443u));
			}
		}
		else if (time >= 3600L && time < 86400L)
		{
			long num5 = time / 3600L;
			tmpS.IntToFormat(num5, 1, false);
			if (num5 > 1L)
			{
				tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(448u));
			}
			else
			{
				tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(444u));
			}
		}
		else if (time >= 86400L)
		{
			long num6 = time / 86400L;
			tmpS.IntToFormat(num6, 1, false);
			if (num6 > 1L)
			{
				tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(449u));
			}
			else
			{
				tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(445u));
			}
		}
		else
		{
			tmpS.IntToFormat(0L, 1, false);
			tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(442u));
		}
	}

	// Token: 0x06001A71 RID: 6769 RVA: 0x002D1C70 File Offset: 0x002CFE70
	private void CheckBeginEndIndex()
	{
		if (this.AllianceChatState == 2)
		{
			this.BeginIndex = 0;
			this.EndIndex = this.NowList.Count - 1;
		}
		else if (this.AllianceChatState == 1)
		{
			this.BeginIndex = this.DM.TopIndex;
			this.EndIndex = this.DM.MiddleTopIndex;
		}
		else if (this.AllianceChatState == 0)
		{
			this.BeginIndex = this.DM.MiddleBottomIndex;
			this.EndIndex = this.NowList.Count - 1;
		}
	}

	// Token: 0x06001A72 RID: 6770 RVA: 0x002D1D0C File Offset: 0x002CFF0C
	private void SetAllianceState(byte State)
	{
		if (this.DM.MiddleBottomIndex != -1 && this.DM.MiddleTopIndex == this.DM.MiddleBottomIndex)
		{
			State = 2;
		}
		this.AllianceChatState = State;
		this.CheckStopViewState();
	}

	// Token: 0x06001A73 RID: 6771 RVA: 0x002D1D58 File Offset: 0x002CFF58
	public override bool OnBackButtonClick()
	{
		if (this.ClickChatObject.activeInHierarchy)
		{
			this.CloseClickChatObj();
			return true;
		}
		if (this.AllianceRequestObject.activeInHierarchy)
		{
			this.AllianceRequestObject.SetActive(false);
			return true;
		}
		if (BattleController.IsGambleMode && this.GM.FindMenu(EGUIWindow.UIEmojiSelect))
		{
			this.GM.CloseMenu(EGUIWindow.UIEmojiSelect);
			return true;
		}
		this.CloseSelf();
		return true;
	}

	// Token: 0x06001A74 RID: 6772 RVA: 0x002D1DD8 File Offset: 0x002CFFD8
	public void CloseSelf()
	{
		if (BattleController.IsGambleMode)
		{
			GamblingManager.Instance.CloseMenu(false);
			this.GM.m_ChatBox.gameObject.SetActive(true);
			return;
		}
		if (this.cScrollRect.ViewState == ListViewState.LVS_WAITLOADING || this.cScrollRect.ViewState == ListViewState.LVS_WAITLOADING_UP)
		{
			this.cScrollRect.SwitchViewState(ListViewState.LVS_NORMAL);
		}
		this.SavePagePara();
		Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			if (door.m_WindowStack.Count == 0 || door.m_WindowStack[door.m_WindowStack.Count - 1].m_eWindow != EGUIWindow.UI_Chat)
			{
				GUIWindowStackData item;
				item.m_eWindow = EGUIWindow.UI_Chat;
				item.m_Arg1 = 0;
				item.m_Arg2 = 0;
				item.bCameraMode = false;
				door.m_WindowStack.Add(item);
				door.CloseMenu(true);
				if (this.GM.m_Window2 != null)
				{
					this.GM.CloseMenu(this.GM.m_Window2.m_eWindow);
				}
			}
			else
			{
				door.CloseMenu(false);
			}
		}
		else
		{
			this.GM.CloseMenu(EGUIWindow.UI_Chat);
		}
	}

	// Token: 0x06001A75 RID: 6773 RVA: 0x002D1F20 File Offset: 0x002D0120
	public void SetInputText(string str)
	{
		this.mInput.text = str;
		this.mInput.textComponent.SetAllDirty();
		this.mInput.textComponent.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001A76 RID: 6774 RVA: 0x002D1F60 File Offset: 0x002D0160
	public void CheckUnRead(bool bShow)
	{
		if (bShow)
		{
			this.UnReadCountRC.gameObject.SetActive(true);
			this.UpdateUnRead();
			this.DM.bShowUnreadCount = true;
		}
		else
		{
			this.UnReadCountRC.gameObject.SetActive(false);
			this.DM.bShowUnreadCount = false;
		}
		GUIManager.Instance.UpdateChatBox(8, 0);
	}

	// Token: 0x06001A77 RID: 6775 RVA: 0x002D1FC4 File Offset: 0x002D01C4
	private void UpdateUnRead()
	{
		if (this.UnReadCountRC.gameObject.activeSelf)
		{
			this.UnreadStr.ClearString();
			this.UnreadStr.IntToFormat((long)this.DM.unReadCount, 1, false);
			this.UnreadStr.AppendFormat("{0}");
			this.UnReadCountText.text = this.UnreadStr.ToString();
			this.UnReadCountText.SetAllDirty();
			this.UnReadCountText.cachedTextGenerator.Invalidate();
			this.UnReadCountText.cachedTextGeneratorForLayout.Invalidate();
			this.UnReadCountRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.UnReadCountText.preferredWidth), 51f);
		}
	}

	// Token: 0x06001A78 RID: 6776 RVA: 0x002D2084 File Offset: 0x002D0284
	public void SavePagePara()
	{
		if (this.DM.NowChannel == 0)
		{
			this.DM.NowKingdomIndex = this.Scroll.GetTopIdx();
			this.DM.NowKingdomPos = this.cScrollRect.content.anchoredPosition.y;
			if (this.DM.NowKingdomIndex == -1 && this.NowList.Count > 0)
			{
				this.DM.NowKingdomIndex = 0;
				this.DM.NowKingdomPos = 0f;
			}
		}
		else
		{
			this.DM.NowAlliancePage = (int)this.AllianceChatState;
			if (this.AllianceChatState == 1)
			{
				this.DM.NowAllianceIndex2 = this.Scroll.GetTopIdx();
				this.DM.NowAlliancePos2 = this.cScrollRect.content.anchoredPosition.y;
				if (this.DM.NowAllianceIndex2 == -1 && this.NowList.Count > 0)
				{
					this.DM.NowAllianceIndex2 = 0;
					this.DM.NowAlliancePos2 = 0f;
				}
			}
			else
			{
				this.DM.NowAllianceIndex1 = this.Scroll.GetTopIdx();
				this.DM.NowAlliancePos1 = this.cScrollRect.content.anchoredPosition.y;
				if (this.DM.NowAllianceIndex1 == -1 && this.NowList.Count > 0)
				{
					this.DM.NowAllianceIndex1 = 0;
					this.DM.NowAlliancePos1 = 0f;
				}
			}
		}
	}

	// Token: 0x06001A79 RID: 6777 RVA: 0x002D2230 File Offset: 0x002D0430
	public void SetBottom(float bottom)
	{
		bottom = bottom * 2f / GUIManager.Instance.m_UICanvas.transform.localScale.y;
		this.m_transform.GetComponent<RectTransform>().offsetMin = new Vector2(0f, bottom);
	}

	// Token: 0x06001A7A RID: 6778 RVA: 0x002D2280 File Offset: 0x002D0480
	public void Adjust(int Height)
	{
		this.SetBottom((float)Height);
	}

	// Token: 0x06001A7B RID: 6779 RVA: 0x002D228C File Offset: 0x002D048C
	public bool CheckIsGambleModeShowMsg()
	{
		if (BattleController.IsGambleMode)
		{
			this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9184u), 255, true);
			return true;
		}
		return false;
	}

	// Token: 0x06001A7C RID: 6780 RVA: 0x002D22C4 File Offset: 0x002D04C4
	private void CloseClickChatObj()
	{
		this.ClickChatObject.SetActive(false);
		this.ClickChatData = null;
		this.ClickChatPlayID = 0L;
	}

	// Token: 0x04004E59 RID: 20057
	private const int UnitCount = 13;

	// Token: 0x04004E5A RID: 20058
	private const float TranslateHeight = 10f;

	// Token: 0x04004E5B RID: 20059
	private Transform m_transform;

	// Token: 0x04004E5C RID: 20060
	private Transform LeftT;

	// Token: 0x04004E5D RID: 20061
	private RectTransform ViewStateImgRC;

	// Token: 0x04004E5E RID: 20062
	private RectTransform ViewStateTextRC;

	// Token: 0x04004E5F RID: 20063
	private GameObject ClickChatObject;

	// Token: 0x04004E60 RID: 20064
	private GameObject AllianceRequestObject;

	// Token: 0x04004E61 RID: 20065
	private GameObject HelpBtnObj;

	// Token: 0x04004E62 RID: 20066
	private GameObject PreBtnObject;

	// Token: 0x04004E63 RID: 20067
	private GameObject MiddleBtnObject;

	// Token: 0x04004E64 RID: 20068
	private GameObject FlashObj;

	// Token: 0x04004E65 RID: 20069
	private GameObject PosBtnObject;

	// Token: 0x04004E66 RID: 20070
	private GameObject PosImgObject;

	// Token: 0x04004E67 RID: 20071
	private GameObject BLBtnObject;

	// Token: 0x04004E68 RID: 20072
	private GameObject SendBLBtnObject;

	// Token: 0x04004E69 RID: 20073
	private GameObject KindomFlash;

	// Token: 0x04004E6A RID: 20074
	private GameObject AllianceFlash;

	// Token: 0x04004E6B RID: 20075
	private GameObject CopyMsgObj;

	// Token: 0x04004E6C RID: 20076
	private GameObject EmojiAleretObj;

	// Token: 0x04004E6D RID: 20077
	private UIButton PreBtn;

	// Token: 0x04004E6E RID: 20078
	private UIButton MiddleBtn;

	// Token: 0x04004E6F RID: 20079
	private UIButton BottomBtn;

	// Token: 0x04004E70 RID: 20080
	private UIButton SendBtn;

	// Token: 0x04004E71 RID: 20081
	private UIButton PlayerInfoBtn;

	// Token: 0x04004E72 RID: 20082
	private UIButton EmojiBnt;

	// Token: 0x04004E73 RID: 20083
	private DataManager DM = DataManager.Instance;

	// Token: 0x04004E74 RID: 20084
	private GUIManager GM = GUIManager.Instance;

	// Token: 0x04004E75 RID: 20085
	private ScrollPanel Scroll;

	// Token: 0x04004E76 RID: 20086
	private ScrollPanel ScrollBL;

	// Token: 0x04004E77 RID: 20087
	private CScrollRect cScrollRect;

	// Token: 0x04004E78 RID: 20088
	private UIEmojiInput mInput;

	// Token: 0x04004E79 RID: 20089
	private Font m_Font;

	// Token: 0x04004E7A RID: 20090
	private UIText LeftmainText;

	// Token: 0x04004E7B RID: 20091
	private UIText ViewStateText;

	// Token: 0x04004E7C RID: 20092
	private UIText PlayerNameText;

	// Token: 0x04004E7D RID: 20093
	private UIText PosText;

	// Token: 0x04004E7E RID: 20094
	private UIText PosText2;

	// Token: 0x04004E7F RID: 20095
	private UIText BLText;

	// Token: 0x04004E80 RID: 20096
	private UIText InputText;

	// Token: 0x04004E81 RID: 20097
	private UIText TitleText;

	// Token: 0x04004E82 RID: 20098
	private Image ViewStateImg;

	// Token: 0x04004E83 RID: 20099
	private Image SendImg;

	// Token: 0x04004E84 RID: 20100
	private Image EmojiImg;

	// Token: 0x04004E85 RID: 20101
	private Image PosImage;

	// Token: 0x04004E86 RID: 20102
	private byte NowInputType;

	// Token: 0x04004E87 RID: 20103
	private byte NowChannel = byte.MaxValue;

	// Token: 0x04004E88 RID: 20104
	private float TitleHeight = 25f;

	// Token: 0x04004E89 RID: 20105
	private float UnitbaseHeight = 75f;

	// Token: 0x04004E8A RID: 20106
	private float PosTextWidth;

	// Token: 0x04004E8B RID: 20107
	private List<TalkDataType> NowList;

	// Token: 0x04004E8C RID: 20108
	private List<float> NowHeightList = new List<float>();

	// Token: 0x04004E8D RID: 20109
	private List<int> NowIndexList = new List<int>();

	// Token: 0x04004E8E RID: 20110
	private TalkDataType ClickChatData;

	// Token: 0x04004E8F RID: 20111
	private long ClickChatPlayID;

	// Token: 0x04004E90 RID: 20112
	private UISpritesArray SArray;

	// Token: 0x04004E91 RID: 20113
	private bool[] bFindScrollComp = new bool[13];

	// Token: 0x04004E92 RID: 20114
	private UnitComp[] Scroll_1_Comp = new UnitComp[13];

	// Token: 0x04004E93 RID: 20115
	private CString[] TimeStr = new CString[13];

	// Token: 0x04004E94 RID: 20116
	private CString[] LanguageStr = new CString[13];

	// Token: 0x04004E95 RID: 20117
	private CString[] NameCStr = new CString[13];

	// Token: 0x04004E96 RID: 20118
	private CString[] VIPCStr = new CString[13];

	// Token: 0x04004E97 RID: 20119
	private CString PosStr;

	// Token: 0x04004E98 RID: 20120
	private CString InputErroeCString;

	// Token: 0x04004E99 RID: 20121
	private ListViewState NowViewState;

	// Token: 0x04004E9A RID: 20122
	private byte AllianceChatState;

	// Token: 0x04004E9B RID: 20123
	private int BeginIndex;

	// Token: 0x04004E9C RID: 20124
	private int EndIndex;

	// Token: 0x04004E9D RID: 20125
	private RectTransform UnReadCountRC;

	// Token: 0x04004E9E RID: 20126
	private UIText UnReadCountText;

	// Token: 0x04004E9F RID: 20127
	private CString UnreadStr;

	// Token: 0x04004EA0 RID: 20128
	private float CheckTimer;

	// Token: 0x04004EA1 RID: 20129
	private int NewTalkCount;

	// Token: 0x04004EA2 RID: 20130
	private byte OpenSendAsk;

	// Token: 0x04004EA3 RID: 20131
	private Color OriginalColor;

	// Token: 0x04004EA4 RID: 20132
	private Color InputColor;

	// Token: 0x04004EA5 RID: 20133
	private Color InputErrorColor;
}
