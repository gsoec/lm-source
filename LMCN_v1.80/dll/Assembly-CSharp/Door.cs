using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x02000292 RID: 658
public class Door : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUTimeBarOnTimer
{
	// Token: 0x17000077 RID: 119
	// (get) Token: 0x06000C93 RID: 3219 RVA: 0x001274EC File Offset: 0x001256EC
	public List<GUIWindowStackData> m_WindowStack
	{
		get
		{
			if (this._m_WindowStack == null)
			{
				this._m_WindowStack = GUIManager.Instance.m_WindowStack;
			}
			return this._m_WindowStack;
		}
	}

	// Token: 0x06000C94 RID: 3220 RVA: 0x00127510 File Offset: 0x00125710
	public bool OpenMenu(EGUIWindow eWin, int arg1 = 0, int arg2 = 0, bool bCameraMode = false)
	{
		this.SetDefaultFadeAlpha();
		this.GM.m_SpeciallyEffect.ClearAllEffect();
		this.ReSetPressPosition();
		if (this.GM.FindMenu(eWin) != null)
		{
			if (this.GM.m_Chat != null && this.GM.m_Chat.activeInHierarchy)
			{
				this.GM.CloseMenu(this.GM.Chatwin.m_eWindow);
				GUIWindowStackData item;
				item.m_eWindow = eWin;
				item.m_Arg1 = arg1;
				item.m_Arg2 = arg2;
				item.bCameraMode = bCameraMode;
				this.m_WindowStack.Add(item);
				return true;
			}
			return false;
		}
		else
		{
			if (this.GM.OpenMenu(eWin, arg1, arg2, bCameraMode, false, true) == null)
			{
				return false;
			}
			GUIWindowStackData item2;
			item2.m_eWindow = eWin;
			if (eWin == EGUIWindow.UI_Chat || eWin == EGUIWindow.UI_MessageBoard)
			{
				arg1 = 0;
			}
			item2.m_Arg1 = arg1;
			item2.m_Arg2 = arg2;
			item2.bCameraMode = bCameraMode;
			this.m_WindowStack.Add(item2);
			if (this.GM.bOpenNeedClose)
			{
				this.GM.bOpenNeedClose = false;
				this.CloseMenu(false);
				return false;
			}
			if (this.m_eMapMode == EUIOriginMapMode.KingdomMap)
			{
				if (eWin != EGUIWindow.UI_MapMonster)
				{
					DataManager.msgBuffer[0] = 84;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
			}
			else if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
			{
				DataManager.msgBuffer[0] = 123;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			return true;
		}
	}

	// Token: 0x06000C95 RID: 3221 RVA: 0x0012769C File Offset: 0x0012589C
	public void CloseMenu(bool bClear = false)
	{
		this.GM.m_SpeciallyEffect.ClearAllEffect();
		if (this.m_WindowStack.Count == 0)
		{
			return;
		}
		this.GM.HideArrow(false);
		EGUIWindow eWindow = this.m_WindowStack[this.m_WindowStack.Count - 1].m_eWindow;
		if (bClear)
		{
			for (int i = this.m_WindowStack.Count - 1; i > -1; i--)
			{
				this.GM.CloseMenu(this.m_WindowStack[i].m_eWindow);
			}
			this.m_WindowStack.Clear();
			this.GM.bClearWindowStack = bClear;
		}
		else
		{
			this.GM.CloseMenu(eWindow);
			this.m_WindowStack.RemoveAt(this.m_WindowStack.Count - 1);
		}
		if (this.m_WindowStack.Count == 0)
		{
			if (this.m_eMapMode == EUIOriginMapMode.KingdomMap)
			{
				DataManager.msgBuffer[0] = 85;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			else if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
			{
				DataManager.msgBuffer[0] = 124;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			this.SwitchMode(EUIOriginMode.Show);
		}
		else
		{
			this.HideFightButton();
			if (this.GM.m_Window2 == null || eWindow != EGUIWindow.UI_Chat)
			{
				this.GM.OpenMenu(this.m_WindowStack[this.m_WindowStack.Count - 1].m_eWindow, this.m_WindowStack[this.m_WindowStack.Count - 1].m_Arg1, this.m_WindowStack[this.m_WindowStack.Count - 1].m_Arg2, this.m_WindowStack[this.m_WindowStack.Count - 1].bCameraMode, false, false);
				if (this.GM.bOpenNeedClose)
				{
					this.GM.bOpenNeedClose = false;
					this.CloseMenu(false);
				}
			}
			else
			{
				this.GM.m_Window2.ReOnOpen();
			}
		}
	}

	// Token: 0x06000C96 RID: 3222 RVA: 0x001278CC File Offset: 0x00125ACC
	public void ClearWindowStack()
	{
		this.GM.m_SpeciallyEffect.ClearAllEffect();
		if (this.m_WindowStack.Count > 0)
		{
			bool flag = false;
			for (int i = 0; i < this.m_WindowStack.Count; i++)
			{
				if (this.m_WindowStack[i].m_eWindow == EGUIWindow.UI_StageSelect || this.m_WindowStack[i].m_eWindow == EGUIWindow.UI_StageSelect2)
				{
					GUIWindowStackData item;
					item.m_eWindow = this.m_WindowStack[i].m_eWindow;
					item.m_Arg1 = this.m_WindowStack[i].m_Arg1;
					item.m_Arg2 = this.m_WindowStack[i].m_Arg2;
					item.bCameraMode = this.m_WindowStack[i].bCameraMode;
					this.m_WindowStack.Clear();
					this.m_WindowStack.Add(item);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.m_WindowStack.Clear();
			}
		}
	}

	// Token: 0x06000C97 RID: 3223 RVA: 0x001279EC File Offset: 0x00125BEC
	public void ClearWindowStack(EGUIWindow SaveA, EGUIWindow SaveB = EGUIWindow.MAX)
	{
		this.GM.m_SpeciallyEffect.ClearAllEffect();
		if (this.m_WindowStack.Count > 0)
		{
			GUIWindowStackData item = default(GUIWindowStackData);
			GUIWindowStackData item2 = default(GUIWindowStackData);
			GUIWindowStackData item3 = default(GUIWindowStackData);
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			for (int i = 0; i < this.m_WindowStack.Count; i++)
			{
				if (!flag && (this.m_WindowStack[i].m_eWindow == EGUIWindow.UI_StageSelect || this.m_WindowStack[i].m_eWindow == EGUIWindow.UI_StageSelect2))
				{
					item = this.m_WindowStack[i];
					flag = true;
				}
				else if (SaveA != EGUIWindow.MAX && !flag2 && this.m_WindowStack[i].m_eWindow == SaveA)
				{
					item2 = this.m_WindowStack[i];
					flag2 = true;
				}
				else if (SaveB != EGUIWindow.MAX && !flag3 && this.m_WindowStack[i].m_eWindow == SaveB)
				{
					item3 = this.m_WindowStack[i];
					flag3 = true;
				}
				if (flag && flag2 && flag3)
				{
					break;
				}
			}
			this.m_WindowStack.Clear();
			if (flag)
			{
				this.m_WindowStack.Add(item);
			}
			if (flag2)
			{
				this.m_WindowStack.Add(item2);
			}
			if (flag3)
			{
				this.m_WindowStack.Add(item3);
			}
		}
	}

	// Token: 0x06000C98 RID: 3224 RVA: 0x00127B98 File Offset: 0x00125D98
	public void CloseMenu_Alliance(EGUIWindow Target)
	{
		if (this.GM.FindMenu(EGUIWindow.UI_Chat))
		{
			if (this.GM.m_WindowStack.Count >= 2)
			{
				this.GM.m_WindowStack.RemoveAt(this.GM.m_WindowStack.Count - 2);
			}
			this.GM.CloseMenu(Target);
		}
		else
		{
			this.CloseMenu(false);
		}
	}

	// Token: 0x06000C99 RID: 3225 RVA: 0x00127C0C File Offset: 0x00125E0C
	public void SwitchMode(EUIOriginMode eMode)
	{
		Vector2 vector = Vector2.zero;
		Vector3 zero = Vector3.zero;
		switch (this.m_eMode)
		{
		case EUIOriginMode.Show:
		{
			Camera.main.cullingMask &= -2;
			this.GM.m_UICanvas.renderMode = RenderMode.ScreenSpaceOverlay;
			this.GM.SetCameraorthOgraphic(true);
			this.m_Background.gameObject.SetActive(true);
			if (this.bHideMainMenu)
			{
				this.SwitchFullMap(true);
			}
			if (this.m_GroundInfo != null)
			{
				this.m_GroundInfo.Close();
			}
			vector.Set(144f, this.m_ChatBox.offsetMin.y);
			this.m_ChatBox.offsetMin = vector;
			vector.Set(-95f, this.m_ChatBox.offsetMax.y);
			this.m_ChatBox.offsetMax = vector;
			this.m_ChatScrollRect.ChangePageWidth(this.m_ChatScrollRectRC.rect.width);
			vector.Set(-9f, 4f);
			this.m_ChatChannelLight.rectTransform.anchoredPosition = vector;
			if (GUIManager.Instance.IsArabic)
			{
				for (int i = 0; i < this.m_ChatScrollRect.content.childCount; i++)
				{
					UIText component = this.m_ChatScrollRect.content.GetChild(i).GetChild(2).GetComponent<UIText>();
					component.UpdateArabicPos();
					component = this.m_ChatScrollRect.content.GetChild(i).GetChild(3).GetComponent<UIText>();
					component.UpdateArabicPos();
				}
			}
			RectTransform rectTransform = (RectTransform)this.m_DiamondBox.transform;
			vector.Set(63.5f, -16f);
			rectTransform.anchoredPosition = vector;
			vector.Set(127f, 32f);
			rectTransform.sizeDelta = vector;
			vector.Set(18f, -16f);
			this.m_DiamondIcon.rectTransform.anchoredPosition = vector;
			zero.Set(0.84f, 0.84f, 0.84f);
			this.m_DiamondIcon.rectTransform.localScale = zero;
			vector.Set(33.9f, 2f);
			vector = this.m_DiamondText.ArabicFixPos(vector);
			this.m_DiamondText.rectTransform.anchoredPosition = vector;
			vector.Set(122.9f, -15.5f);
			this.m_DiamondPlus.rectTransform.anchoredPosition = vector;
			zero.Set(0.8f, 0.8f, 1f);
			this.m_DiamondPlus.rectTransform.localScale = zero;
			rectTransform = (RectTransform)this.m_MoraleBox.transform;
			vector.Set(62.5f, -48f);
			rectTransform.anchoredPosition = vector;
			vector.Set(125f, 32f);
			rectTransform.sizeDelta = vector;
			vector.Set(18f, -14.1f);
			this.m_MoraleIcon.rectTransform.anchoredPosition = vector;
			zero.Set(0.84f, 0.84f, 0.84f);
			this.m_MoraleIcon.rectTransform.localScale = zero;
			vector.Set(34.5f, 2.5f);
			vector = this.m_MoraleText.ArabicFixPos(vector);
			this.m_MoraleText.rectTransform.anchoredPosition = vector;
			break;
		}
		case EUIOriginMode.Hide:
			this.m_ChatBox.gameObject.SetActive(true);
			this.m_FuncPanel.gameObject.SetActive(true);
			this.m_MoneyPanel.gameObject.SetActive(true);
			this.m_SpTopPanel.gameObject.SetActive(true);
			break;
		case EUIOriginMode.MoneyAndFuncButton:
		case EUIOriginMode.MoneyAndFuncButtonWM:
		case EUIOriginMode.MoneyAndFuncButtonF:
		case EUIOriginMode.MoneyAndFuncButtonAndScene:
			if (this.m_eMode == EUIOriginMode.MoneyAndFuncButtonAndScene)
			{
				Camera.main.cullingMask &= -2;
				this.GM.SetCameraorthOgraphic(true);
				this.m_Background.gameObject.SetActive(true);
			}
			this.ShowFuncButton(this.m_bOldShowFuncButton == 1);
			break;
		case EUIOriginMode.Money:
		case EUIOriginMode.MoneyF:
			this.m_FuncPanel.gameObject.SetActive(true);
			break;
		case EUIOriginMode.FuncButton:
			this.ShowFuncButton(this.m_bOldShowFuncButton == 1);
			this.m_MoneyPanel.gameObject.SetActive(true);
			this.m_SpTopPanel.gameObject.SetActive(true);
			break;
		case EUIOriginMode.FuncButtonWithoutChatBox:
			this.ShowFuncButton(this.m_bOldShowFuncButton == 1);
			this.m_ChatBox.gameObject.SetActive(true);
			this.m_MoneyPanel.gameObject.SetActive(true);
			this.m_SpTopPanel.gameObject.SetActive(true);
			break;
		}
		switch (eMode)
		{
		case EUIOriginMode.Show:
		{
			Camera.main.cullingMask |= 1;
			this.GM.m_UICanvas.renderMode = RenderMode.ScreenSpaceCamera;
			if (this.m_eMapMode == EUIOriginMapMode.KingdomMap)
			{
				DataManager.msgBuffer[0] = 71;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			this.GM.SetCameraorthOgraphic(false);
			this.m_Background.gameObject.SetActive(false);
			vector.Set(267f, this.m_ChatBox.offsetMin.y);
			this.m_ChatBox.offsetMin = vector;
			vector.Set(-152f, this.m_ChatBox.offsetMax.y);
			this.m_ChatBox.offsetMax = vector;
			this.m_ChatScrollRect.ChangePageWidth(this.m_ChatScrollRectRC.rect.width);
			vector.Set(-11f, 4f);
			this.m_ChatChannelLight.rectTransform.anchoredPosition = vector;
			if (this.GM.IsArabic)
			{
				for (int j = 0; j < this.m_ChatScrollRect.content.childCount; j++)
				{
					UIText component2 = this.m_ChatScrollRect.content.GetChild(j).GetChild(2).GetComponent<UIText>();
					component2.UpdateArabicPos();
					component2 = this.m_ChatScrollRect.content.GetChild(j).GetChild(3).GetComponent<UIText>();
					component2.UpdateArabicPos();
				}
			}
			RectTransform rectTransform = (RectTransform)this.m_DiamondBox.transform;
			vector.Set(174f, -52.5f);
			rectTransform.anchoredPosition = vector;
			vector.Set(142f, 41f);
			rectTransform.sizeDelta = vector;
			vector.Set(20.3f, -21.7f);
			this.m_DiamondIcon.rectTransform.anchoredPosition = vector;
			this.m_DiamondIcon.rectTransform.localScale = Vector3.one;
			vector.Set(41.4f, -3.3f);
			vector = this.m_DiamondText.ArabicFixPos(vector);
			this.m_DiamondText.rectTransform.anchoredPosition = vector;
			vector.Set(238.5f, -53f);
			this.m_DiamondPlus.rectTransform.anchoredPosition = vector;
			this.m_DiamondPlus.rectTransform.localScale = Vector3.one;
			rectTransform = (RectTransform)this.m_MoraleBox.transform;
			vector.Set(170.5f, -91.5f);
			rectTransform.anchoredPosition = vector;
			vector.Set(135f, 37f);
			rectTransform.sizeDelta = vector;
			vector.Set(20.6f, -17f);
			this.m_MoraleIcon.rectTransform.anchoredPosition = vector;
			this.m_MoraleIcon.rectTransform.localScale = Vector3.one;
			vector.Set(41.6f, 0f);
			vector = this.m_MoraleText.ArabicFixPos(vector);
			this.m_MoraleText.rectTransform.anchoredPosition = vector;
			break;
		}
		case EUIOriginMode.Hide:
			this.m_ChatBox.gameObject.SetActive(false);
			this.m_FuncPanel.gameObject.SetActive(false);
			this.m_MoneyPanel.gameObject.SetActive(false);
			this.m_SpTopPanel.gameObject.SetActive(false);
			break;
		case EUIOriginMode.MoneyAndFuncButton:
		case EUIOriginMode.MoneyAndFuncButtonWM:
		case EUIOriginMode.MoneyAndFuncButtonF:
		case EUIOriginMode.MoneyAndFuncButtonAndScene:
			if (eMode == EUIOriginMode.MoneyAndFuncButtonAndScene)
			{
				Camera.main.cullingMask |= 1;
				this.GM.SetCameraorthOgraphic(false);
				this.m_Background.gameObject.SetActive(false);
			}
			this.m_bOldShowFuncButton = ((this.m_bShowFuncButton != 1 && this.m_bShowFuncButton != 2) ? 0 : 1);
			this.ShowFuncButton(false);
			break;
		case EUIOriginMode.Money:
		case EUIOriginMode.MoneyF:
			this.m_FuncPanel.gameObject.SetActive(false);
			break;
		case EUIOriginMode.FuncButton:
			this.m_bOldShowFuncButton = ((this.m_bShowFuncButton != 1 && this.m_bShowFuncButton != 2) ? 0 : 1);
			this.ShowFuncButton(false);
			this.m_MoneyPanel.gameObject.SetActive(false);
			this.m_SpTopPanel.gameObject.SetActive(false);
			break;
		case EUIOriginMode.FuncButtonWithoutChatBox:
			this.m_bOldShowFuncButton = ((this.m_bShowFuncButton != 1 && this.m_bShowFuncButton != 2) ? 0 : 1);
			this.ShowFuncButton(false);
			this.m_ChatBox.gameObject.SetActive(false);
			this.m_MoneyPanel.gameObject.SetActive(false);
			this.m_SpTopPanel.gameObject.SetActive(false);
			break;
		}
		this.GM.UpdateChatBox(0, 0);
		this.m_FuncPanelBG.gameObject.SetActive(false);
		this.m_eMode = eMode;
		this.SwitchMapMode(this.m_eMapMode);
		this.GM.CheckBattleMessageSize(eMode == EUIOriginMode.Show);
	}

	// Token: 0x06000C9A RID: 3226 RVA: 0x001285C8 File Offset: 0x001267C8
	public void SwitchMapMode(EUIOriginMapMode eMode)
	{
		bool flag = this.m_eMode == EUIOriginMode.Show;
		Vector2 zero = Vector2.zero;
		if (eMode != EUIOriginMapMode.OriginMap)
		{
			Camera.main.transform.position = new Vector3(0f, 0f, -16f);
			Camera.main.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			this.GM.SetCameraorthOgraphic(true);
			this.m_TerritoryPanel.gameObject.SetActive(false);
			this.m_MapFuncPanel.gameObject.SetActive(flag);
			if (flag)
			{
				this.HideFightButton();
				if (eMode == EUIOriginMapMode.WorldMap)
				{
					this.m_MapSwitchImage.SetSpriteIndex(1);
				}
				else
				{
					this.m_MapSwitchImage.SetSpriteIndex(0);
				}
			}
			else
			{
				this.m_MapSwitchImage.SetSpriteIndex(1);
			}
			this.m_GroundInfo.bOpenPvePanel = false;
			this.m_MissionHintTrans.gameObject.SetActive(false);
			this.m_BackBlockSA.SetSpriteIndex(0);
			this.m_BackBlock.gameObject.SetActive(flag);
		}
		else
		{
			if (this.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				this.GM.SetCameraorthOgraphic(false);
			}
			this.m_TerritoryPanel.gameObject.SetActive(flag);
			this.m_MapFuncPanel.gameObject.SetActive(false);
			if (flag)
			{
				this.m_MapSwitchImage.SetSpriteIndex(1);
				DataManager.msgBuffer[0] = 48;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			else
			{
				this.m_MapSwitchImage.SetSpriteIndex(0);
				if (this.m_eMode != EUIOriginMode.MoneyAndFuncButtonAndScene)
				{
					DataManager.msgBuffer[0] = 49;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
				else
				{
					DataManager.msgBuffer[0] = 48;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
			}
			this.m_MissionHintTrans.gameObject.SetActive(DataManager.Instance.MySysSetting.bShowMission);
			this.m_BackBlockSA.SetSpriteIndex(1);
			this.m_BackBlock.gameObject.SetActive(flag);
		}
		this.m_MapSwitchButton.gameObject.SetActive(flag);
		if (this.m_MapSwitchImage.m_SpriteIndex == 1)
		{
			zero.Set(18f, 6f);
			((RectTransform)this.m_MapSwitchImage.transform).anchoredPosition = zero;
			this.m_MapSwitchImage.m_Image.SetNativeSize();
		}
		else
		{
			zero.Set(16f, 28f);
			((RectTransform)this.m_MapSwitchImage.transform).anchoredPosition = zero;
			this.m_MapSwitchImage.m_Image.SetNativeSize();
		}
		this.m_RolePanel.gameObject.SetActive(flag);
		this.m_ResourcePanel.gameObject.SetActive(flag);
		this.m_AlertPanel.gameObject.SetActive(flag);
		this.m_TimeBarPanel.gameObject.SetActive(flag || this.m_eMode == EUIOriginMode.MoneyAndFuncButtonAndScene);
		if (this.m_eMode == EUIOriginMode.MoneyAndFuncButtonAndScene)
		{
			this.m_TimeBarPanel.offsetMax = new Vector2(0f, 65f);
			this.ForceQueueBarOpenClose(false);
		}
		else
		{
			this.m_TimeBarPanel.offsetMax = Vector2.zero;
		}
		this.m_eMapMode = eMode;
		this.UpdateMissionInfo();
		this.CheckSetShowActivityBtn();
		this.CheckShowMallBtn();
		this.UpdateMoney();
		this.CheckTreasureBoxState();
		this.ChecNeedForceOpenFuncBtn();
		this.CheckShowDaBauBtn();
		this.CheckFBBtn(0);
		this.CheckShowMapInfoFlash();
		if (eMode == EUIOriginMapMode.OriginMap || eMode == EUIOriginMapMode.WorldMap)
		{
			this.ClearPVPWonderID();
		}
		if (this.m_eMode == EUIOriginMode.Show)
		{
			this.SwitchFullMap(false);
		}
		NewbieManager.EntryTest();
		Indemnify.CheckShowIndemnify();
		ActivityGiftManager.Instance.CheckShowActivityGiftEffect();
	}

	// Token: 0x06000C9B RID: 3227 RVA: 0x0012896C File Offset: 0x00126B6C
	private void SwitchFullMap(bool ForceShow = false)
	{
		if (this.bHideMainByFIFA)
		{
			this.SetMainMenuActive_FIFA(false);
			return;
		}
		bool flag = !this.bHideMainMenu || ForceShow;
		Vector2 zero = Vector2.zero;
		this.m_FuncPanel.gameObject.SetActive(flag);
		this.m_ChatBox.gameObject.SetActive(flag);
		this.m_RolePanel.gameObject.SetActive(flag);
		this.m_MoneyPanel.gameObject.SetActive(flag);
		this.m_SpTopPanel.gameObject.SetActive(flag);
		this.m_ResourcePanel.gameObject.SetActive(flag);
		this.m_AlertPanel.gameObject.SetActive(flag);
		this.m_TimeBarPanel.gameObject.SetActive(flag);
		if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
		{
			this.m_MapFuncPanel.GetChild(2).gameObject.SetActive(false);
			this.m_MapFuncPanel.GetChild(3).gameObject.SetActive(false);
			this.m_MapFuncPanel.GetChild(4).gameObject.SetActive(false);
			this.m_LocationBoxBG.enabled = false;
			this.m_LocationBoxIcon.rectTransform.anchoredPosition = new Vector2(106f, 6f);
			this.m_LocationBox.transform.GetChild(1).gameObject.SetActive(false);
			this.m_LocationBox.transform.GetChild(2).gameObject.SetActive(false);
		}
		else
		{
			this.m_MapFuncPanel.GetChild(2).gameObject.SetActive(flag);
			this.m_MapFuncPanel.GetChild(3).gameObject.SetActive(true);
			this.m_MapFuncPanel.GetChild(4).gameObject.SetActive(flag);
			this.m_LocationBoxBG.enabled = true;
			this.m_LocationBoxIcon.rectTransform.anchoredPosition = new Vector2(15f, 6f);
			this.m_LocationBox.transform.GetChild(1).gameObject.SetActive(true);
			this.m_LocationBox.transform.GetChild(2).gameObject.SetActive(true);
			if (!flag)
			{
				this.ShowPVPTime(false);
			}
			else
			{
				this.HidePVPTime();
			}
			if (!flag)
			{
				this.ShowKVKTime(false);
			}
			else
			{
				this.HideKVKTime();
			}
			if (!flag)
			{
				this.ShowFIFATime(false);
			}
			else
			{
				this.HideFIFATime();
			}
		}
		if (flag)
		{
			this.m_FullMapButton.SetSpriteIndex(0);
			if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
			{
				zero.Set(51f, 53f);
			}
			else
			{
				zero.Set(51f, 210f);
			}
			this.m_MapFuncBG.rectTransform.sizeDelta = zero;
			RectTransform rectTransform = (RectTransform)this.m_LocationBox.transform;
			zero.Set(55f, -71f);
			rectTransform.anchoredPosition = zero;
			rectTransform = (RectTransform)this.m_MapFuncPanel.GetChild(3);
			zero.Set(179.8f, -83.9f);
			rectTransform.anchoredPosition = zero;
			rectTransform = (RectTransform)this.m_HomeButton.transform;
			zero.Set(-182f, -201.5f);
			rectTransform.anchoredPosition = zero;
			rectTransform = (RectTransform)this.FIFA_FindBtn.transform;
			zero.Set(-182f, -293f);
			rectTransform.anchoredPosition = zero;
			if (GUIManager.Instance.bOpenOnIPhoneX)
			{
				this.m_iPhonePanel.gameObject.SetActive(true);
				this.m_BackBlock_L.enabled = false;
				this.m_BackBlock_R.enabled = false;
			}
			else
			{
				this.m_BackBlock_L.enabled = true;
				this.m_BackBlock_R.enabled = true;
			}
			this.m_BackBlock_B.enabled = true;
		}
		else
		{
			this.m_FullMapButton.SetSpriteIndex(1);
			zero.Set(51f, 53f);
			this.m_MapFuncBG.rectTransform.sizeDelta = zero;
			RectTransform rectTransform = (RectTransform)this.m_LocationBox.transform;
			zero.Set(55f, -8f);
			rectTransform.anchoredPosition = zero;
			rectTransform = (RectTransform)this.m_MapFuncPanel.GetChild(3);
			zero.Set(179.8f, -20.9f);
			rectTransform.anchoredPosition = zero;
			rectTransform = (RectTransform)this.m_HomeButton.transform;
			zero.Set(-55f, -64f);
			rectTransform.anchoredPosition = zero;
			rectTransform = (RectTransform)this.FIFA_FindBtn.transform;
			zero.Set(-55f, -155.5f);
			rectTransform.anchoredPosition = zero;
			this.m_BackBlock_L.enabled = false;
			this.m_BackBlock_R.enabled = false;
			this.m_BackBlock_B.enabled = false;
			if (GUIManager.Instance.bOpenOnIPhoneX)
			{
				this.m_iPhonePanel.gameObject.SetActive(false);
			}
		}
		if (this.m_eMapMode != EUIOriginMapMode.OriginMap)
		{
			this.notifyHomeBtnPos();
		}
	}

	// Token: 0x06000C9C RID: 3228 RVA: 0x00128E60 File Offset: 0x00127060
	public void SetMainMenuActive_FIFA(bool bShow)
	{
		this.bHideMainByFIFA = !bShow;
		this.m_FuncPanel.gameObject.SetActive(bShow);
		this.m_ChatBox.gameObject.SetActive(bShow);
		this.m_RolePanel.gameObject.SetActive(bShow);
		this.m_MoneyPanel.gameObject.SetActive(bShow);
		this.m_SpTopPanel.gameObject.SetActive(bShow);
		this.m_ResourcePanel.gameObject.SetActive(bShow);
		this.m_AlertPanel.gameObject.SetActive(bShow);
		this.m_TimeBarPanel.gameObject.SetActive(bShow);
		this.m_MapFuncPanel.GetChild(1).gameObject.SetActive(bShow);
		this.m_MapFuncPanel.GetChild(2).gameObject.SetActive(bShow);
		this.m_MapFuncPanel.GetChild(3).gameObject.SetActive(bShow);
		this.m_MapFuncPanel.GetChild(4).gameObject.SetActive(bShow);
		this.m_MapFuncPanel.GetChild(5).gameObject.SetActive(bShow);
		this.m_MapFuncPanel.GetChild(7).gameObject.SetActive(bShow && this.bShowHomeBtn);
		this.FIFA_FindBtn.SetActive(bShow && this.bShowFIFA_FindBtn);
		this.FIFA_UITop.SetActive(!bShow);
		this.m_LocationBoxBG.enabled = true;
		this.m_LocationBox.enabled = bShow;
		this.m_LocationBox.transform.GetChild(0).gameObject.SetActive(bShow);
		this.m_LocationBox.transform.GetChild(1).gameObject.SetActive(true);
		this.m_LocationBox.transform.GetChild(2).gameObject.SetActive(true);
		if (bShow)
		{
			this.m_LocationXText.text = this.LocXStr.ToString();
			this.m_LocationXText.SetAllDirty();
			this.m_LocationXText.cachedTextGenerator.Invalidate();
			this.m_LocationYText.text = this.LocYStr.ToString();
			this.m_LocationYText.SetAllDirty();
			this.m_LocationYText.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.m_LocationXText.text = this.LocXStr.ToString();
			this.m_LocationXText.SetAllDirty();
			this.m_LocationXText.cachedTextGenerator.Invalidate();
			this.m_LocationYText.text = this.LocYStr.ToString();
			this.m_LocationYText.SetAllDirty();
			this.m_LocationYText.cachedTextGenerator.Invalidate();
		}
		Vector2 zero = Vector2.zero;
		if (bShow)
		{
			RectTransform rectTransform = (RectTransform)this.m_LocationBox.transform;
			zero.Set(55f, -71f);
			rectTransform.anchoredPosition = zero;
			rectTransform = (RectTransform)this.m_LocationBox.transform.GetChild(1).transform;
			if (this.GM.IsArabic)
			{
				zero.Set(140f, 0f);
			}
			else
			{
				zero.Set(60f, 0f);
			}
			rectTransform.anchoredPosition = zero;
			rectTransform = (RectTransform)this.m_LocationBox.transform.GetChild(2).transform;
			if (this.GM.IsArabic)
			{
				zero.Set(220f, 0f);
			}
			else
			{
				zero.Set(140f, 0f);
			}
			rectTransform.anchoredPosition = zero;
			this.SwitchFullMap(false);
			this.CheckandShowFuncBtnCount(-1, false);
		}
		else
		{
			RectTransform rectTransform = (RectTransform)this.m_LocationBox.transform;
			zero.Set(0f, -8f);
			rectTransform.anchoredPosition = zero;
			rectTransform = (RectTransform)this.m_LocationBox.transform.GetChild(1).transform;
			if (this.GM.IsArabic)
			{
				zero.Set(113.9f, 0f);
			}
			else
			{
				zero.Set(33.9f, 0f);
			}
			rectTransform.anchoredPosition = zero;
			rectTransform = (RectTransform)this.m_LocationBox.transform.GetChild(2).transform;
			if (this.GM.IsArabic)
			{
				zero.Set(193.9f, 0f);
			}
			else
			{
				zero.Set(113.9f, 0f);
			}
			rectTransform.anchoredPosition = zero;
			this.ShowPVPTime(true);
			this.ShowKVKTime(true);
			this.ShowFIFATime(true);
		}
		if (this.GM.m_BMGO != null)
		{
			this.GM.m_BMGO.gameObject.SetActive(bShow);
		}
	}

	// Token: 0x06000C9D RID: 3229 RVA: 0x00129320 File Offset: 0x00127520
	public void CheckSetShowActivityBtn()
	{
		if (ActivityManager.Instance.bCastleLevel && this.m_eMapMode == EUIOriginMapMode.OriginMap)
		{
			this.m_ActivityBtnT.gameObject.SetActive(true);
		}
		else
		{
			this.m_ActivityBtnT.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000C9E RID: 3230 RVA: 0x00129370 File Offset: 0x00127570
	public void CheckShowMallBtn()
	{
		if (this.m_eMapMode == EUIOriginMapMode.OriginMap)
		{
			this.m_MallGO.SetActive(true);
		}
		else
		{
			this.m_MallGO.SetActive(false);
		}
	}

	// Token: 0x06000C9F RID: 3231 RVA: 0x001293A8 File Offset: 0x001275A8
	public void CheckShowDaBauBtn()
	{
		if (this.m_eMode == EUIOriginMode.Show && this.m_eMapMode == EUIOriginMapMode.OriginMap && Indemnify.UIStatus == INDEMNIFY_STATE.ShowButton)
		{
			this.m_DaBauBtnGO.SetActive(true);
		}
		else
		{
			this.m_DaBauBtnGO.SetActive(false);
		}
	}

	// Token: 0x06000CA0 RID: 3232 RVA: 0x001293F4 File Offset: 0x001275F4
	public void CheckMonthBtn()
	{
	}

	// Token: 0x06000CA1 RID: 3233 RVA: 0x001293F8 File Offset: 0x001275F8
	public Sprite LoadSprite(string SpriteName)
	{
		Sprite result;
		this.m_SpriteDict.TryGetValue(SpriteName.GetHashCode(), out result);
		return result;
	}

	// Token: 0x06000CA2 RID: 3234 RVA: 0x0012941C File Offset: 0x0012761C
	public Sprite LoadSprite(CString SpriteName)
	{
		Sprite result;
		this.m_SpriteDict.TryGetValue(SpriteName.GetHashCode(false), out result);
		return result;
	}

	// Token: 0x06000CA3 RID: 3235 RVA: 0x00129440 File Offset: 0x00127640
	public Material LoadMaterial()
	{
		return this.m_AssetBundle.Load("UI_main_m", typeof(Material)) as Material;
	}

	// Token: 0x06000CA4 RID: 3236 RVA: 0x00129464 File Offset: 0x00127664
	public void SetPointTexture(byte point, Image numImg)
	{
		if (point == 255)
		{
			numImg.sprite = this.LoadSprite("UI_mall_x_001");
		}
		else
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat((long)point, 1, false);
			cstring.AppendFormat("UI_mall_{0}_001");
			numImg.sprite = this.LoadSprite(cstring);
		}
		numImg.material = this.LoadMaterial();
	}

	// Token: 0x06000CA5 RID: 3237 RVA: 0x001294CC File Offset: 0x001276CC
	public void LoadMainEff(EMapEffectKind kind)
	{
		bool flag = (ActivityManager.Instance.bSpecialMonsterTreasureEvent & 8UL) > 0UL;
		if (!flag && this.EffectObj != null && kind != EMapEffectKind.WORLDWAR)
		{
			ParticleManager.Instance.DeSpawn(this.EffectObj);
			this.EffectObj = null;
			return;
		}
		if (this.EffectObj != null)
		{
			return;
		}
		MapEffect recordByIndex = DataManager.Instance.MapEffectTB.GetRecordByIndex((int)kind);
		if (kind == EMapEffectKind.ORIGIN)
		{
			this.EffectObj = ((!flag) ? null : ParticleManager.Instance.Spawn(recordByIndex.EffectID, this.m_RolePanel, Vector3.zero, 0.6875f, true, true, true));
		}
		else if (kind == EMapEffectKind.CHAOS)
		{
			this.EffectObj = ((!flag) ? null : ParticleManager.Instance.Spawn(recordByIndex.EffectID, this.m_MapFuncPanel, Vector3.zero, 85.33334f, true, true, true));
		}
		else
		{
			this.EffectObj = ParticleManager.Instance.Spawn(recordByIndex.EffectID, this.m_MapFuncPanel, Vector3.zero, 85.33334f, true, true, true);
		}
		if (this.EffectObj != null)
		{
			GUIManager.Instance.SetLayer(this.EffectObj, Door.MapEffectCanvasLayer[(int)kind]);
			this.EffectObj.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			Vector3 zero = Vector3.zero;
			zero.x = recordByIndex.PosX * 0.01f * (float)((recordByIndex.PosX_Sign != 0) ? -1 : 1);
			zero.y = recordByIndex.PosY * 0.01f * (float)((recordByIndex.PosY_Sign != 0) ? -1 : 1);
			zero.z = recordByIndex.PosZ * 0.01f * (float)((recordByIndex.PosZ_Sign != 0) ? -1 : 1);
			this.EffectObj.transform.localPosition = zero;
		}
		if (this.EffectObj != null)
		{
			this.EffectObj.SetActive(false);
			this.EffectObj.SetActive(true);
		}
	}

	// Token: 0x06000CA6 RID: 3238 RVA: 0x00129704 File Offset: 0x00127904
	public void RefreshMainEff()
	{
		if (this.m_eMapMode == EUIOriginMapMode.OriginMap)
		{
			this.LoadMainEff(EMapEffectKind.ORIGIN);
		}
		else if (this.m_eMapMode == EUIOriginMapMode.KingdomMap)
		{
			if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_WORLD_WAR)
			{
				this.LoadMainEff(EMapEffectKind.CHAOS);
			}
			else
			{
				this.LoadMainEff(EMapEffectKind.WORLDWAR);
			}
		}
	}

	// Token: 0x06000CA7 RID: 3239 RVA: 0x00129758 File Offset: 0x00127958
	public void DeSpawnMainEff()
	{
		if (this.EffectObj != null)
		{
			ParticleManager.Instance.DeSpawn(this.EffectObj);
			this.EffectObj = null;
		}
	}

	// Token: 0x06000CA8 RID: 3240 RVA: 0x00129784 File Offset: 0x00127984
	public override void OnOpen(int arg1, int arg2)
	{
		Material material = this.LoadMaterial();
		if (SystemInfo.supportsGyroscope)
		{
			Input.gyro.enabled = true;
			this.isTrackBackGround = true;
		}
		this.GM.SetCameraorthOgraphic(false);
		UnityEngine.Object[] array = this.m_AssetBundle.LoadAll(typeof(Sprite));
		for (int i = 0; i < array.Length; i++)
		{
			this.m_SpriteDict.Add(array[i].name.GetHashCode(), (Sprite)array[i]);
		}
		this.m_BackBlock = base.transform.GetChild(0).GetComponent<RectTransform>();
		this.m_BackBlockSA = base.transform.GetChild(0).GetChild(0).GetComponent<UISpritesArray>();
		if (this.m_BackBlockSA != null && this.m_BackBlockSA.m_Image != null)
		{
			this.m_BackBlockSA.m_Image.color = new Color(1f, 1f, 1f, 0.6f);
		}
		this.m_BackBlock_B = base.transform.GetChild(0).GetChild(1).GetComponent<Image>();
		this.m_BackBlock_L = base.transform.GetChild(0).GetChild(2).GetComponent<Image>();
		this.m_BackBlock_R = base.transform.GetChild(0).GetChild(3).GetComponent<Image>();
		this.m_Background = base.transform.GetChild(1).GetComponent<RectTransform>();
		this.m_AlertBlock = base.transform.GetChild(2).GetComponent<RectTransform>();
		this.m_AlertBlock_T = this.m_AlertBlock.GetChild(0).GetComponent<Image>();
		this.m_AlertBlock_B = this.m_AlertBlock.GetChild(1).GetComponent<Image>();
		this.m_AlertBlock_L = this.m_AlertBlock.GetChild(2).GetComponent<Image>();
		this.m_AlertBlock_R = this.m_AlertBlock.GetChild(3).GetComponent<Image>();
		this.m_TerritoryPanel = base.transform.GetChild(3).GetComponent<RectTransform>();
		this.m_MapFuncPanel = base.transform.GetChild(4).GetComponent<RectTransform>();
		this.m_ResourcePanel = base.transform.GetChild(5).GetComponent<RectTransform>();
		this.m_TopLayer = base.transform.GetChild(6).GetComponent<RectTransform>();
		this.m_GroundInfo = new UIGroundInfo();
		this.m_ChatBox = (RectTransform)this.m_TopLayer.GetChild(0);
		this.m_MoneyPanel = (RectTransform)this.m_TopLayer.GetChild(1);
		this.m_RolePanel = (RectTransform)this.m_TopLayer.GetChild(2);
		this.m_AlertPanel = (RectTransform)this.m_TopLayer.GetChild(3);
		this.m_TimeBarPanel = (RectTransform)this.m_TopLayer.GetChild(4);
		this.m_SpTopPanel = (RectTransform)this.m_TopLayer.GetChild(5);
		this.m_FuncPanel = (RectTransform)this.m_TopLayer.GetChild(6);
		this.m_iPhonePanel = (RectTransform)this.m_TopLayer.GetChild(7);
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_iPhonePanel.SetParent(this.GM.m_UICanvas2.transform, false);
			this.m_iPhonePanel.offsetMax = Vector2.zero;
			this.m_iPhonePanel.offsetMin = Vector2.zero;
			this.m_iPhonePanel.SetAsFirstSibling();
		}
		Vector2 sizeDelta = this.m_Background.sizeDelta;
		if (((RectTransform)base.transform).rect.width > sizeDelta.x)
		{
			sizeDelta.x = ((RectTransform)base.transform).rect.width + ((!this.GM.bOpenOnIPhoneX) ? 0f : (this.GM.IPhoneX_DeltaX * 2f));
			this.m_Background.sizeDelta = sizeDelta;
			RectTransform rectTransform = (RectTransform)this.m_Background.GetChild(0);
			RectTransform rectTransform2 = (RectTransform)this.m_Background.GetChild(1);
			float num = 40f;
			sizeDelta = new Vector2(this.m_Background.sizeDelta.x * 0.5f + num, this.m_Background.sizeDelta.y + num * 2f);
			rectTransform.sizeDelta = sizeDelta;
			rectTransform2.sizeDelta = sizeDelta;
			sizeDelta = new Vector2(this.m_Background.sizeDelta.x * 0.25f + num / 2f, 0f);
			rectTransform.anchoredPosition = -sizeDelta;
			rectTransform2.anchoredPosition = sizeDelta;
		}
		this.m_ChatBox.gameObject.AddComponent<CanvasGroup>().ignoreParentGroups = true;
		this.GM.DoorOpenChatBox(this.m_ChatBox);
		this.GM.UpdateChatBox(0, 0);
		this.m_ChatScrollRectRC = this.GM.m_ChatScrollRectRC;
		this.m_ChatScrollRect = this.GM.m_ChatScrollRect;
		this.m_ChatChannelLight = this.GM.m_ChatChannelLight;
		Transform child = this.m_TerritoryPanel.GetChild(0);
		this.m_BattleButton = child.GetComponent<UIButton>();
		this.m_BattleButton.m_Handler = this;
		this.m_BattleButton.gameObject.SetActive(false);
		this.FIFA_UITop = this.m_MapFuncPanel.GetChild(0).gameObject;
		child = this.m_MapFuncPanel.GetChild(1);
		this.m_MapFuncBG = child.GetComponent<Image>();
		UIButton component;
		for (int j = 2; j <= 5; j++)
		{
			child = this.m_MapFuncPanel.GetChild(j);
			component = child.GetComponent<UIButton>();
			component.m_Handler = this;
		}
		child = this.m_MapFuncPanel.GetChild(5);
		this.m_FullMapButton = child.GetComponent<UISpritesArray>();
		Transform child2 = this.m_MapFuncPanel.GetChild(6);
		this.m_LocationBoxBG = child2.GetComponent<Image>();
		this.m_LocationBox = child2.GetComponent<UIButton>();
		this.m_LocationBox.m_Handler = this;
		child = child2.GetChild(0);
		this.m_LocationBoxIcon = child.GetComponent<Image>();
		child = child2.GetChild(1);
		this.m_LocationXText = child.GetComponent<UIText>();
		this.m_LocationXText.font = this.GM.GetTTFFont();
		this.LocXStr = StringManager.Instance.SpawnString(30);
		this.LocXStrFIFA = StringManager.Instance.SpawnString(30);
		child = child2.GetChild(2);
		this.m_LocationYText = child.GetComponent<UIText>();
		this.m_LocationYText.font = this.GM.GetTTFFont();
		this.LocYStr = StringManager.Instance.SpawnString(30);
		this.LocYStrFIFA = StringManager.Instance.SpawnString(30);
		child2 = this.m_MapFuncPanel.GetChild(7);
		this.m_HomeButton = child2.GetComponent<UIButton>();
		this.m_HomeButton.m_Handler = this;
		this.m_HomeArrowT = child2.GetChild(1);
		child = child2.GetChild(3);
		this.m_HomeDistText = child.GetComponent<UIText>();
		this.m_HomeDistText.font = this.GM.GetTTFFont();
		this.HomeStr = StringManager.Instance.SpawnString(30);
		this.SetShowHomeBtn(false);
		this.KVKTransBtnGO = this.m_MapFuncPanel.GetChild(8).gameObject;
		((RectTransform)this.KVKTransBtnGO.transform).anchoredPosition = new Vector2(0f, 142f);
		component = this.m_MapFuncPanel.GetChild(8).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 33;
		this.KVKTransBtnSA = this.m_MapFuncPanel.GetChild(8).GetComponent<UISpritesArray>();
		this.PVPTimeObj = this.m_MapFuncPanel.GetChild(9).gameObject;
		UIButtonHint uibuttonHint = this.PVPTimeObj.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 1;
		this.PVPWonderImg = this.m_MapFuncPanel.GetChild(9).GetChild(0).GetComponent<Image>();
		this.PVPWonderImg.rectTransform.localScale = new Vector3(0.14f, 0.14f, 0.14f);
		this.PVPTimeText = this.m_MapFuncPanel.GetChild(9).GetChild(1).GetComponent<UIText>();
		this.PVPTimeText.font = this.GM.GetTTFFont();
		this.PVPTimeText.gameObject.AddComponent<Outline>();
		this.PVPStr = StringManager.Instance.SpawnString(30);
		this.PVPTimeStr = StringManager.Instance.SpawnString(150);
		this.KVKTimeObj = this.m_MapFuncPanel.GetChild(10).gameObject;
		uibuttonHint = this.KVKTimeObj.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 2;
		this.KVKTimeSA = this.m_MapFuncPanel.GetChild(10).GetComponent<UISpritesArray>();
		this.KVKTimeText = this.m_MapFuncPanel.GetChild(10).GetChild(1).GetComponent<UIText>();
		this.KVKTimeText.font = this.GM.GetTTFFont();
		this.KVKTimeText.gameObject.AddComponent<Outline>();
		this.KVKTimeText.color = new Color(1f, 0.863f, 0.322f);
		this.KVKStr = StringManager.Instance.SpawnString(30);
		this.KVKTimeStr = StringManager.Instance.SpawnString(150);
		this.FIFATimeObj = this.m_MapFuncPanel.GetChild(11).gameObject;
		uibuttonHint = this.FIFATimeObj.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 3;
		this.FIFATimeText = this.m_MapFuncPanel.GetChild(11).GetChild(1).GetComponent<UIText>();
		this.FIFATimeText.font = this.GM.GetTTFFont();
		this.FIFATimeText.gameObject.AddComponent<Outline>();
		this.FIFATimeText.color = new Color(0.0784f, 0.9725f, 0.3333f);
		this.FIFAStr = StringManager.Instance.SpawnString(30);
		this.FIFATimeStr = StringManager.Instance.SpawnString(100);
		this.FIFA_FindBtn = this.m_MapFuncPanel.GetChild(12).gameObject;
		this.SetShowFIFA_FindBtn(false);
		component = this.m_MapFuncPanel.GetChild(12).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 35;
		child = this.m_FuncPanel.GetChild(0);
		this.m_FuncPanelBG = child.GetComponent<UIButton>();
		this.m_FuncPanelBG.m_Handler = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			((RectTransform)child).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0f);
			((RectTransform)child).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0f);
		}
		child = this.m_FuncPanel.GetChild(1);
		this.m_FuncBG = child.GetComponent<Image>();
		this.m_FuncBGWidth = this.m_FuncBG.rectTransform.sizeDelta.x;
		child = this.m_FuncPanel.GetChild(3);
		this.m_ShowFuncButton = child.gameObject;
		this.m_ShowFuncButtonAlert = child.GetChild(0).gameObject;
		this.SPGiftImgMain = child.GetChild(1).GetComponent<Image>();
		this.LiveImgMain = child.GetChild(2).GetComponent<Image>();
		this.LiveImgMain.gameObject.AddComponent<ArabicItemTextureRot>();
		this.LiveImgMainTW = child.GetChild(2).GetComponent<uTweenScale>();
		this.LiveImgMainTWF = child.GetChild(2).GetChild(0).GetComponent<uTweenAlpha>();
		this.LiveImgMainTWF.gameObject.AddComponent<ArabicItemTextureRot>();
		component = child.GetComponent<UIButton>();
		component.m_Handler = this;
		component.SoundIndex = 2;
		this.m_ShowFuncPosX = ((RectTransform)child).anchoredPosition.x;
		child = this.m_FuncPanel.GetChild(4);
		this.m_ShowFuncIcon = child.GetComponent<Image>();
		this.m_SFuncRC = new RectTransform[6];
		this.m_SFuncCG = new CanvasGroup[6];
		this.m_SFuncPosX = new float[6];
		this.m_FuncRC = new RectTransform[6];
		this.m_FuncCG = new CanvasGroup[6];
		this.m_FuncLight = new GameObject[6];
		this.m_FuncPosX = new float[6];
		this.m_FuncBtnCountRC = new RectTransform[6];
		this.m_FuncBtnText = new UIText[6];
		this.m_FuncBtnCount = new int[6];
		this.m_FuncBtnCountStr = new CString[6];
		this.m_MissionAlert = this.m_FuncPanel.GetChild(8).GetChild(0).GetChild(2).gameObject;
		this.m_MissionFlash = this.m_FuncPanel.GetChild(8).GetChild(0).GetChild(0).gameObject;
		this.m_RallyRecFlash = this.m_FuncPanel.GetChild(10).GetChild(1).GetChild(0).gameObject;
		this.m_AllianceGift = this.m_FuncPanel.GetChild(10).GetChild(1).GetChild(2).gameObject;
		this.SPGiftImgAlly = this.m_FuncPanel.GetChild(10).GetChild(1).GetChild(3).GetComponent<Image>();
		this.m_OtherGift = this.m_FuncPanel.GetChild(7).GetChild(0).GetChild(1).gameObject;
		this.LiveImgOther = this.m_FuncPanel.GetChild(7).GetChild(0).GetChild(2).GetComponent<Image>();
		this.LiveImgOther.gameObject.AddComponent<ArabicItemTextureRot>();
		this.LiveImgOtherTW = this.m_FuncPanel.GetChild(7).GetChild(0).GetChild(2).GetComponent<uTweenScale>();
		this.LiveImgOtherTWF = this.m_FuncPanel.GetChild(7).GetChild(0).GetChild(2).GetChild(0).GetComponent<uTweenAlpha>();
		this.LiveImgOtherTWF.gameObject.AddComponent<ArabicItemTextureRot>();
		this.m_OtherAlert = this.m_FuncPanel.GetChild(7).GetChild(0).GetChild(3).gameObject;
		for (int k = 0; k < this.m_FuncRC.Length; k++)
		{
			if (k == 0 || k == 5)
			{
				this.m_FuncLight[k] = this.m_FuncPanel.GetChild(k + 5).GetChild(0).gameObject;
				child = this.m_FuncPanel.GetChild(k + 5).GetChild(1);
			}
			else if (k == 3)
			{
				this.m_FuncLight[k] = this.m_FuncPanel.GetChild(k + 5).GetChild(0).GetChild(0).gameObject;
				child = this.m_FuncPanel.GetChild(k + 5).GetChild(0);
			}
			else
			{
				this.m_FuncLight[k] = null;
				child = this.m_FuncPanel.GetChild(k + 5).GetChild(0);
			}
			component = child.GetComponent<UIButton>();
			component.m_Handler = this;
			this.m_FuncRC[k] = this.m_FuncPanel.GetChild(k + 5).GetComponent<RectTransform>();
			this.m_FuncPosX[k] = this.m_FuncRC[k].anchoredPosition.x;
			this.m_FuncCG[k] = this.m_FuncRC[k].GetComponent<CanvasGroup>();
			if (k == 3 || k == 5)
			{
				child = child.GetChild(1);
			}
			else
			{
				child = child.GetChild(0);
			}
			if (k == 0)
			{
				this.m_FuncBtnCountRC[k] = this.m_FuncPanel.GetChild(k + 5).GetChild(1).GetChild(1).GetComponent<RectTransform>();
			}
			else
			{
				this.m_FuncBtnCountRC[k] = child.GetComponent<RectTransform>();
			}
			this.m_FuncBtnText[k] = child.GetChild(0).GetComponent<UIText>();
			this.m_FuncBtnText[k].font = this.GM.GetTTFFont();
			this.m_FuncBtnCountStr[k] = StringManager.Instance.SpawnString(30);
			this.RefreshFuncBtnCount(k, -1);
		}
		child = this.m_FuncPanel.GetChild(11);
		component = child.GetComponent<UIButton>();
		component.m_Handler = this;
		this.m_MapSwitchButton = child.GetComponent<CanvasGroup>();
		this.m_MapSwitchImage = child.GetChild(0).GetComponent<UISpritesArray>();
		this.m_MapSwitchImage2 = child.GetChild(1).GetComponent<Image>();
		this.m_MapSwitchImage2.gameObject.AddComponent<ArabicItemTextureRot>();
		this.LoadingImgT = this.m_FuncPanel.GetChild(12);
		this.m_HeadImage = this.m_RolePanel.GetChild(0).GetComponent<Image>();
		child = this.m_RolePanel.GetChild(2);
		this.m_HeadBoxFlash = this.m_RolePanel.GetChild(2).GetChild(1).gameObject;
		this.m_HeadBoxJail = this.m_RolePanel.GetChild(2).GetChild(0).gameObject;
		this.m_HeadIcon = child.GetComponent<UIButton>();
		this.m_HeadIcon.m_Handler = this;
		this.m_HeadIcon.image.sprite = this.GM.m_IconSpriteAsset.LoadSprite(1);
		this.m_HeadIcon.image.material = this.GM.m_IconSpriteAsset.GetMaterial();
		child = this.m_RolePanel.GetChild(3);
		this.m_VIPIcon = child.GetComponent<UIButton>();
		this.m_VIPIcon.m_Handler = this;
		this.m_VipText = child.GetChild(0).GetComponent<UIText>();
		this.m_VipText.font = this.GM.GetTTFFont();
		this.m_VIPStr = StringManager.Instance.SpawnString(30);
		if (this.GM.IsArabic)
		{
			child.GetComponent<Image>().sprite = child.GetComponent<UISpritesArray>().m_Sprites[0];
			this.m_VipText.fontStyle = FontStyle.Normal;
		}
		child = this.m_RolePanel.GetChild(4).GetChild(0);
		this.m_Level = child.GetComponent<UIText>();
		this.m_Level.font = this.GM.GetTTFFont();
		this.m_LevelStr = StringManager.Instance.SpawnString(30);
		child = this.m_RolePanel.GetChild(5);
		this.m_PowerBtn = child.GetComponent<UIButton>();
		this.m_PowerBtn.m_Handler = this;
		this.m_PowerBtn.m_BtnID1 = 16;
		this.RBText[0] = child.GetChild(0).GetComponent<UIText>();
		this.RBText[0].font = this.GM.GetTTFFont();
		this.RBText[0].text = DataManager.Instance.mStringTable.GetStringByID(250u);
		this.m_Power = child.GetChild(1).GetComponent<UIText>();
		this.m_Power.font = this.GM.GetTTFFont();
		this.m_PowerStr = StringManager.Instance.SpawnString(30);
		child2 = this.m_MoneyPanel.GetChild(0);
		component = child2.GetComponent<UIButton>();
		component.m_Handler = this;
		this.m_DiamondBox = component;
		child = child2.GetChild(0);
		this.m_DiamondIcon = child.GetComponent<Image>();
		child = child2.GetChild(1);
		UIText component2 = child.GetComponent<UIText>();
		this.m_DiamondText = component2;
		component2.font = this.GM.GetTTFFont();
		this.DiamondString = StringManager.Instance.SpawnString(30);
		child2 = this.m_MoneyPanel.GetChild(1);
		component = child2.GetComponent<UIButton>();
		this.m_MoraleBox = component;
		this.m_MoraleSA2 = child2.GetComponent<UISpritesArray>();
		this.m_MoraleForceBlood = child2.GetChild(0).GetComponent<Image>();
		this.m_MoraleFlash = child2.GetChild(1).GetComponent<Image>();
		child = child2.GetChild(2);
		child.gameObject.AddComponent<ArabicItemTextureRot>();
		this.m_MoraleIcon = child.GetComponent<Image>();
		this.m_MoraleSA = child.GetComponent<UISpritesArray>();
		uibuttonHint = child2.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 0;
		this.m_MoraleIconHint = child.gameObject.AddComponent<UIButtonHint>();
		this.m_MoraleIconHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_MoraleIconHint.m_Handler = this;
		child = child2.GetChild(3);
		component2 = child.GetComponent<UIText>();
		this.m_MoraleText = component2;
		component2.font = this.GM.GetTTFFont();
		this.MoraleString = StringManager.Instance.SpawnString(30);
		this.m_ResourceIcon = new Image[5];
		this.m_ResourceBar = new Image[5];
		this.m_ResourceText = new UIText[5];
		this.m_ResourceColor = new Color[5];
		this.m_ResourceStr = new CString[5];
		for (int l = 0; l < this.m_ResourceBar.Length; l++)
		{
			child2 = this.m_ResourcePanel.GetChild(l);
			component = child2.GetComponent<UIButton>();
			component.m_Handler = this;
			child = child2.GetChild(1);
			this.m_ResourceBar[l] = child.GetComponent<Image>();
			child = child2.GetChild(3);
			this.m_ResourceIcon[l] = child.GetComponent<Image>();
			child = child2.GetChild(4);
			this.m_ResourceText[l] = child.GetComponent<UIText>();
			this.m_ResourceText[l].font = this.GM.GetTTFFont();
			if (l == 0)
			{
				if (this.DM.Resource[0].Stock >= this.DM.Resource[0].Capacity)
				{
					this.m_ResourceColor[l] = this.ResourceSColor;
				}
				else
				{
					this.m_ResourceColor[l] = Color.white;
				}
			}
			else
			{
				this.m_ResourceColor[l] = Color.white;
			}
			this.m_ResourceText[l].color = this.m_ResourceColor[l];
			this.m_ResourceStr[l] = StringManager.Instance.SpawnString(30);
		}
		child = this.m_AlertPanel.GetChild(0);
		this.m_AttackedAlert = child.GetComponent<UIButton>();
		this.m_AttackedAlert.m_Handler = this;
		this.m_AttackedAlertBackSA = child.GetComponent<UISpritesArray>();
		this.m_AttackedAlertBackSA2 = child.GetChild(0).GetComponent<UISpritesArray>();
		this.m_AttackedAlertSA = child.GetChild(1).GetComponent<UISpritesArray>();
		this.m_AttackedAlertSA2 = child.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
		child = child.GetChild(2);
		this.m_AttackedAlertRC = child.GetComponent<RectTransform>();
		this.m_AttackedAlertText = child.GetChild(0).GetComponent<UIText>();
		this.m_AttackedAlertText.font = this.GM.GetTTFFont();
		this.m_AttackedAlertStr = StringManager.Instance.SpawnString(30);
		child = this.m_AlertPanel.GetChild(1);
		this.m_HelpAlert = child.GetComponent<UIButton>();
		this.m_HelpAlert.m_Handler = this;
		this.m_HelpAlertImageGO = child.GetChild(0).gameObject;
		this.m_HelpAlertext2 = child.GetChild(1).GetComponent<UIText>();
		this.m_HelpAlertext2.font = this.GM.GetTTFFont();
		this.m_HelpAlertStr2 = StringManager.Instance.SpawnString(30);
		child = child.GetChild(2);
		this.m_HelpAlertRC = child.GetComponent<RectTransform>();
		this.m_HelpAlertext = child.GetChild(0).GetComponent<UIText>();
		this.m_HelpAlertext.font = this.GM.GetTTFFont();
		this.m_HelpAlertStr = StringManager.Instance.SpawnString(30);
		this.m_HelpAlertL = this.m_AlertPanel.GetChild(1).GetChild(3).GetComponent<Image>();
		this.m_HelpAlertR = this.m_AlertPanel.GetChild(1).GetChild(4).GetComponent<Image>();
		this.m_HelpAlertSA = this.m_AlertPanel.GetChild(1).GetChild(3).GetComponent<UISpritesArray>();
		if (this.GM.IsArabic)
		{
			this.m_HelpAlertL.gameObject.AddComponent<ArabicItemTextureRot>();
			this.m_HelpAlertR.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		child = this.m_AlertPanel.GetChild(2);
		this.m_AllianceFreeSA1 = child.GetComponent<UISpritesArray>();
		this.m_AllianceFreeSA2 = child.GetChild(0).GetComponent<UISpritesArray>();
		this.m_AllianceFree = child.GetComponent<UIButton>();
		this.m_AllianceFree.m_Handler = this;
		this.m_AllianceFreetext = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_AllianceFreetext.font = this.GM.GetTTFFont();
		this.m_AllianceFreetext.text = DataManager.Instance.mStringTable.GetStringByID(777u);
		child = this.m_AlertPanel.GetChild(3);
		this.m_TroopsBtn = child.GetComponent<UIButton>();
		this.m_TroopsBtn.m_Handler = this;
		child = child.GetChild(0);
		this.m_TroopsRC = child.GetComponent<RectTransform>();
		this.m_TroopsText = child.GetChild(0).GetComponent<UIText>();
		this.m_TroopsText.font = this.GM.GetTTFFont();
		this.m_TroopsAlertStr = StringManager.Instance.SpawnString(30);
		child = this.m_AlertPanel.GetChild(4);
		this.m_BuffSA = child.GetComponent<UISpritesArray>();
		this.m_BuffBtn = child.GetComponent<UIButton>();
		this.m_BuffBtn.m_Handler = this;
		child = child.GetChild(0);
		this.m_BuffRC = child.GetComponent<RectTransform>();
		this.m_BuffText = child.GetChild(0).GetComponent<UIText>();
		this.m_BuffText.font = this.GM.GetTTFFont();
		this.m_BuffAlertStr = StringManager.Instance.SpawnString(30);
		child = this.m_AlertPanel.GetChild(4).GetChild(1);
		this.m_BuffRC2 = child.GetComponent<RectTransform>();
		this.m_BuffText2 = child.GetChild(0).GetComponent<UIText>();
		this.m_BuffText2.font = this.GM.GetTTFFont();
		this.m_BuffAlertStr2 = StringManager.Instance.SpawnString(30);
		this.m_ActivityBtnT = this.m_AlertPanel.GetChild(5);
		this.m_ActivityBtnCG = this.m_ActivityBtnT.GetComponent<CanvasGroup>();
		this.m_ActivityBackSA = this.m_ActivityBtnT.GetChild(0).GetComponent<UISpritesArray>();
		this.m_ActivityBtnImg = this.m_ActivityBtnT.GetChild(0).GetComponent<Image>();
		this.m_FlashKVKImg = this.m_ActivityBtnT.GetChild(0).GetChild(0).GetComponent<Image>();
		this.m_ActivityAlert = this.m_AlertPanel.GetChild(5).GetChild(3).gameObject;
		this.m_ActivityTitleText = this.m_ActivityBtnT.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_ActivityTitleText.font = this.GM.GetTTFFont();
		this.m_ActivityTimeText = this.m_ActivityBtnT.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.m_ActivityTimeText.font = this.GM.GetTTFFont();
		this.m_ActivityBtnT.GetChild(2).GetComponent<UIButton>().m_Handler = this;
		ActivityManager.Instance.door = this;
		ActivityManager.Instance.SetActivityBtnToFirst();
		child = this.m_AlertPanel.GetChild(6);
		this.m_TreasureBoxObject = child.gameObject;
		this.m_TreasureBox = child.GetChild(0).GetComponent<UIButton>();
		this.m_TreasureBox.m_Handler = this;
		this.m_TreasureBoxFlash = child.GetChild(0).gameObject;
		this.m_TreasureBoxFlash_5x = child.GetChild(0).GetChild(0).gameObject;
		this.m_TreasureBoxSA = child.GetChild(0).GetComponent<UISpritesArray>();
		this.m_TreasureBoxPos = child.GetChild(0).GetComponent<uTweenPosition>();
		this.m_TreasureBoxScale = child.GetChild(0).GetComponent<uTweenScale>();
		this.m_TreasureBoxtext = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_TreasureBoxtext.font = this.GM.GetTTFFont();
		this.m_TreasureBoxtext.rectTransform.offsetMin = new Vector2(-20f, 0f);
		this.m_TreasureBoxtext.rectTransform.offsetMax = new Vector2(20f, 0f);
		this.m_TreasureBoxStr = StringManager.Instance.SpawnString(30);
		child.GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
		child.GetChild(0).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
		child = this.m_AlertPanel.GetChild(7);
		this.m_MissionHintTrans = child;
		this.NewMissionReward = this.m_MissionHintTrans.GetChild(2).GetComponent<Image>();
		this.NewMissionReward.gameObject.SetActive(true);
		this.NewMissionReward.enabled = false;
		this.m_MissionHintRC = child.GetComponent<RectTransform>();
		this.m_MissionHintRRC = child.GetChild(0).GetComponent<RectTransform>();
		this.m_MissionHinttextR = child.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.m_MissionHinttextR.font = this.GM.GetTTFFont();
		this.m_MissionHintStrR = StringManager.Instance.SpawnString(150);
		this.m_MissionHintSA = child.GetChild(1).GetComponent<UISpritesArray>();
		this.m_MissionHinttextL = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_MissionHinttextL.font = this.GM.GetTTFFont();
		this.m_MissionBtn = child.GetChild(1).GetComponent<UIButton>();
		this.m_MissionScale = child.GetChild(1).GetComponent<uButtonScale>();
		this.m_MissionBtn.m_Handler = this;
		this.m_MissionBtnTS = child.GetChild(1).GetComponent<uTweenScale>();
		this.m_MissionBtnTS.loopStyle = LoopStyle.PingPong;
		this.m_MissionBtnRect = child.GetChild(1).GetComponent<RectTransform>();
		this.UpdateMissionInfo();
		child = this.m_AlertPanel.GetChild(8);
		this.m_MallGO = child.gameObject;
		component = child.GetComponent<UIButton>();
		component.m_Handler = this;
		if (this.GM.IsArabic)
		{
			child.GetComponent<RectTransform>().gameObject.AddComponent<ArabicItemTextureRot>();
			child.GetComponent<uButtonScale>().CheckTargetScale();
		}
		this.SpriteA = child.GetChild(0).GetComponent<SpriteAnimation>();
		this.SpriteA.m_Image.preserveAspect = true;
		this.m_MallImageGO = this.m_AlertPanel.GetChild(8).GetChild(1).gameObject;
		this.m_MallText = this.m_AlertPanel.GetChild(8).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_MallText.font = this.GM.GetTTFFont();
		this.m_MallStr = StringManager.Instance.SpawnString(30);
		MallManager.Instance.door = this;
		child = this.m_AlertPanel.GetChild(9);
		this.m_DaBauBtnGO = child.gameObject;
		component = child.GetComponent<UIButton>();
		component.m_Handler = this;
		child = this.m_AlertPanel.GetChild(10);
		this.m_PetSkillBtnGO = child.gameObject;
		component = child.GetComponent<UIButton>();
		component.m_Handler = this;
		this.m_PetSkillBtnFlashGO = child.GetChild(0).gameObject;
		this.m_PetSkillCountRC = child.GetChild(1).GetComponent<RectTransform>();
		this.m_PetSkillText = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_PetSkillText.font = this.GM.GetTTFFont();
		this.m_PetSkillStr = StringManager.Instance.SpawnString(30);
		child = this.m_AlertPanel.GetChild(11);
		this.m_FBBtnGO = child.gameObject;
		this.m_FBBtnSA = child.GetComponent<UISpritesArray>();
		component = child.GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 34;
		this.m_FBBtnCountRC = child.GetChild(0).GetComponent<RectTransform>();
		this.m_FBBtnCountText = child.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.m_FBBtnCountText.font = this.GM.GetTTFFont();
		this.m_FBBtnCountStr = StringManager.Instance.SpawnString(30);
		this.m_FBBtnTimeGO = child.GetChild(1).gameObject;
		this.m_FBBtnTimeText = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_FBBtnTimeText.font = this.GM.GetTTFFont();
		this.m_FBBtnTimeStr = StringManager.Instance.SpawnString(30);
		this.m_FBBtnAlertGO = child.GetChild(2).gameObject;
		child2 = this.m_SpTopPanel.GetChild(0);
		this.m_MoraleHintBox = child2.GetComponent<Image>();
		this.m_MoraleIconHint.ControlFadeOut = this.m_MoraleHintBox.gameObject;
		uibuttonHint.ControlFadeOut = this.m_MoraleHintBox.gameObject;
		child = child2.GetChild(0);
		this.m_MoraleHintText = child.GetComponent<UIText>();
		this.m_MoraleHintText.font = this.GM.GetTTFFont();
		this.m_MoraleHintText.horizontalOverflow = HorizontalWrapMode.Overflow;
		this.m_DiamondPlus = this.m_SpTopPanel.GetChild(1).GetComponent<Image>();
		this.m_SpTopPanel.GetChild(1).GetComponent<UIButton>().m_Handler = this;
		this.RunningText = this.m_SpTopPanel.GetChild(2).GetComponent<UIRunningTextEX>();
		this.RunningText.m_RunningText1.font = this.GM.GetTTFFont();
		this.RunningText.m_RunningText2.font = this.GM.GetTTFFont();
		this.RunningText.Speed = 50;
		this.m_SpTopPanel.GetChild(2).GetComponent<Image>().color = Color.black;
		this.m_ArrowRC = this.m_SpTopPanel.GetChild(3).GetComponent<RectTransform>();
		this.m_ArrowPos = this.m_SpTopPanel.GetChild(3).GetComponent<uTweenPosition>();
		this.m_ArrowRC.SetParent(this.m_TopLayer);
		child = this.m_TimeBarPanel.GetChild(0);
		this.m_QueueButton = child.GetComponent<UIButton>();
		this.m_QueueButton.m_Handler = this;
		this.m_QueueIcon = child.GetChild(0).GetComponent<Image>();
		this.m_QueueCountBox = (RectTransform)this.m_TimeBarPanel.GetChild(0).GetChild(1);
		child = this.m_QueueCountBox.GetChild(0);
		this.m_QueueCountText = child.GetComponent<UIText>();
		this.m_QueueCountText.font = this.GM.GetTTFFont();
		this.m_QueueCountStr = StringManager.Instance.SpawnString(30);
		this.m_QueuePanel = (RectTransform)this.m_TimeBarPanel.GetChild(1);
		this.m_QueueTimeBar = new UITimeBar[this.m_QueuePanel.childCount];
		this.m_QueueTimeBarIcon = new Image[this.m_QueuePanel.childCount];
		for (int m = 0; m < this.m_QueueTimeBar.Length; m++)
		{
			child2 = this.m_QueuePanel.GetChild(m);
			this.m_QueueTimeBar[m] = child2.gameObject.AddComponent<UITimeBar>();
			this.GM.CreateTimerBar(this.m_QueueTimeBar[m], 0L, 0L, 0L, eTimeBarType.IconType, string.Empty, string.Empty);
			child = child2.GetChild(3);
			this.m_QueueTimeBar[m].m_TimeBarID = m;
			this.m_QueueTimeBar[m].m_Handler = this;
			this.m_QueueTimeBarIcon[m] = child.gameObject.AddComponent<Image>();
			this.m_QueueTimeBarIcon[m].sprite = this.LoadSprite("icon001");
			this.m_QueueTimeBarIcon[m].material = material;
			this.m_QueueTimeBarIcon[m].SetNativeSize();
			this.m_QueueTimeBarIcon[m].rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
			this.m_QueueTimeBar[m].m_FuntionBtn.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		for (int n = this.m_QueuePanel.childCount / 2; n < this.m_QueuePanel.childCount; n++)
		{
			float x = ((RectTransform)this.m_QueueTimeBar[n - this.m_QueuePanel.childCount / 2].transform).anchoredPosition.x;
			float x2 = ((RectTransform)this.m_QueueTimeBar[n - this.m_QueuePanel.childCount / 2].transform).sizeDelta.x;
			Vector2 anchoredPosition = ((RectTransform)this.m_QueueTimeBar[n].transform).anchoredPosition;
			anchoredPosition.x = x + 60f + x2;
			((RectTransform)this.m_QueueTimeBar[n].transform).anchoredPosition = anchoredPosition;
		}
		for (int num2 = 0; num2 < this.m_QueuePanel.childCount; num2++)
		{
			((RectTransform)this.m_QueueTimeBar[num2].transform).anchoredPosition += new Vector2(-12f, 0f);
		}
		this.m_QueueTimeBar[0].transform.SetParent(this.m_TimeBarPanel, false);
		((RectTransform)this.m_QueueTimeBar[0].transform).anchoredPosition += new Vector2(0f, this.m_QueuePanel.anchoredPosition.y);
		this.m_TopLayer.SetParent(this.GM.m_WindowTopLayer, false);
		this.m_TopLayer.SetAsFirstSibling();
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_BackBlock.SetParent(this.GM.m_UICanvas.transform, false);
			this.m_BackBlock.SetAsFirstSibling();
			this.m_BackBlock.offsetMin = Vector2.zero;
			this.m_BackBlock.offsetMax = Vector2.zero;
			this.m_iPhonePanel.gameObject.SetActive(true);
		}
		this.CGDoor = base.transform.gameObject.AddComponent<CanvasGroup>();
		this.CGTop = this.m_TopLayer.gameObject.AddComponent<CanvasGroup>();
		base.transform.GetChild(0).gameObject.AddComponent<CanvasGroup>().ignoreParentGroups = true;
		this.m_MapFuncPanel.GetChild(3).gameObject.AddComponent<CanvasGroup>().ignoreParentGroups = true;
		this.m_MapFuncPanel.GetChild(6).gameObject.AddComponent<CanvasGroup>().ignoreParentGroups = true;
		this.m_MapFuncPanel.GetChild(7).gameObject.AddComponent<CanvasGroup>().ignoreParentGroups = true;
		this.m_MapFuncPanel.GetChild(12).gameObject.AddComponent<CanvasGroup>().ignoreParentGroups = true;
		this.SpecialTimeCG[0] = this.PVPTimeObj.AddComponent<CanvasGroup>();
		this.SpecialTimeCG[0].ignoreParentGroups = true;
		this.SpecialTimeCG[1] = this.KVKTimeObj.AddComponent<CanvasGroup>();
		this.SpecialTimeCG[1].ignoreParentGroups = true;
		this.SpecialTimeCG[2] = this.FIFATimeObj.AddComponent<CanvasGroup>();
		this.SpecialTimeCG[2].ignoreParentGroups = true;
		this.m_MapFuncPanel.gameObject.SetActive(false);
		this.SwitchMapMode(this.m_eMapMode);
		this.UpdateLocation(0, 0, 0f, 0f);
		this.UpdateRoleInfo();
		this.UpDateLeadState();
		this.UpdateMoney();
		this.UpdateResource();
		this.CheckHelpAlertState();
		this.CheckAllianceFreeState();
		this.CheckAttackState();
		this.CheckTroopsState();
		this.CheckBuffState();
		this.CheckTalentPoint();
		this.SetTreasureBoxSprite();
		this.CheckTreasureBox();
		this.CheckFuncButtonState();
		this.CheckShowDaBauBtn();
		this.CheckShowMissionFlash();
		this.CheckPetSkillBtn(0);
		this.CheckFBBtn(0);
		this.CheckShowMapInfoFlash();
		if (this.DM.bFirstOpenQueueBar)
		{
			this.DM.SortQueueBarData();
			this.DM.bFirstOpenQueueBar = false;
		}
		this.UpdateQueue();
		this.ForceQueueBarOpenClose(this.DM.bOpenQueue);
		this.m_GroundInfo.Load(this);
		if (GUIManager.Instance.m_BMGO != null)
		{
			this.m_ChatBox.gameObject.SetActive(false);
			GUIManager.Instance.CheckBattleMessageSize(this.m_eMode == EUIOriginMode.Show);
		}
		this.GM.GetABColor();
		if (this.m_WindowStack.Count > 0)
		{
			this.HideFightButton();
			GUIManager.Instance.OpenMenu(this.m_WindowStack[this.m_WindowStack.Count - 1].m_eWindow, this.m_WindowStack[this.m_WindowStack.Count - 1].m_Arg1, this.m_WindowStack[this.m_WindowStack.Count - 1].m_Arg2, this.m_WindowStack[this.m_WindowStack.Count - 1].bCameraMode, false, false);
			this.GM.bClearWindowStack = true;
		}
		if (GUIManager.Instance.BattleSerialNo > 0u)
		{
			this.OpenMenu(EGUIWindow.UI_Letter, 0, 0, false);
		}
		this.GM.m_SpeciallyEffect.InitSE_Mat();
		MallManager.Instance.SetMainPackage();
		MallManager.Instance.SetMainTime(true);
		if ((DataManager.Instance.RoleAttr.PrizeFlag & 2u) > 0u)
		{
			this.RunningText.CheckAddStr();
		}
		ActivityManager.Instance.CheckActivityShow();
		if (NewbieManager.IsNewbie)
		{
			this.ForceFuncBtnOpenClose(false);
		}
		else if (NewbieManager.IsTeachWorking(ETeachKind.GOLDGUY))
		{
			NewbieManager.CheckTeach(ETeachKind.GOLDGUY, null, false);
		}
		else if (NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP))
		{
			NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, null, false);
		}
		else if (NewbieManager.IsTeachWorking(ETeachKind.ARMY_HOLE))
		{
			NewbieManager.CheckTeach(ETeachKind.ARMY_HOLE, null, false);
		}
	}

	// Token: 0x06000CA9 RID: 3241 RVA: 0x0012C064 File Offset: 0x0012A264
	public override void OnClose()
	{
		StringManager instance = StringManager.Instance;
		this.m_TopLayer.SetParent(base.transform, false);
		Camera.main.cullingMask |= 1;
		Camera.main.orthographic = false;
		if (this.m_GroundInfo != null)
		{
			this.m_GroundInfo.Unload();
			this.m_GroundInfo = null;
		}
		for (int i = 0; i < 5; i++)
		{
			instance.DeSpawnString(this.m_ResourceStr[i]);
		}
		for (int j = 0; j < 6; j++)
		{
			instance.DeSpawnString(this.m_FuncBtnCountStr[j]);
		}
		instance.DeSpawnString(this.MoraleString);
		instance.DeSpawnString(this.DiamondString);
		instance.DeSpawnString(this.m_TroopsAlertStr);
		instance.DeSpawnString(this.m_HelpAlertStr);
		instance.DeSpawnString(this.m_HelpAlertStr2);
		instance.DeSpawnString(this.MoraleHintString);
		instance.DeSpawnString(this.m_VIPStr);
		instance.DeSpawnString(this.m_PowerStr);
		instance.DeSpawnString(this.m_LevelStr);
		instance.DeSpawnString(this.m_QueueCountStr);
		instance.DeSpawnString(this.m_MissionHintStrR);
		instance.DeSpawnString(this.LocXStr);
		instance.DeSpawnString(this.LocYStr);
		instance.DeSpawnString(this.LocXStrFIFA);
		instance.DeSpawnString(this.LocYStrFIFA);
		instance.DeSpawnString(this.m_BuffAlertStr);
		instance.DeSpawnString(this.m_BuffAlertStr2);
		instance.DeSpawnString(this.KingdomMarkString);
		instance.DeSpawnString(this.PVPStr);
		instance.DeSpawnString(this.PVPTimeStr);
		instance.DeSpawnString(this.FIFAStr);
		instance.DeSpawnString(this.FIFATimeStr);
		instance.DeSpawnString(this.KVKTimeStr);
		instance.DeSpawnString(this.m_MallStr);
		instance.DeSpawnString(this.m_PetSkillStr);
		instance.DeSpawnString(this.m_FBBtnCountStr);
		instance.DeSpawnString(this.m_FBBtnTimeStr);
		int num = 0;
		while (num < (int)this.m_QueueCount && num < this.m_QueueTimeBar.Length)
		{
			if (this.m_QueueTimeBar[num].m_ListID != 0)
			{
				this.GM.RemoverTimeBaarToList(this.m_QueueTimeBar[num]);
			}
			num++;
		}
		this.GM.DoorCloseChatBox();
		ActivityManager.Instance.door = null;
		MallManager.Instance.door = null;
		this.GM.m_ItemInfo.DestroySlider();
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_BackBlock.SetParent(base.transform, false);
			this.m_BackBlock.SetAsFirstSibling();
			this.m_iPhonePanel.SetParent(this.m_TopLayer, false);
		}
	}

	// Token: 0x06000CAA RID: 3242 RVA: 0x0012C320 File Offset: 0x0012A520
	public override void UpdateUI(int arg1, int arg2)
	{
		switch ((byte)arg1)
		{
		case 1:
			this.SwitchMode((EUIOriginMode)arg2);
			break;
		case 2:
			if (DataManager.MapDataController.gotoKingdomState == 255)
			{
				this.CloseMenu(this.m_WindowStack.Count > 0);
				DataManager.MapDataController.gotoKingdomState = 0;
				this.GoToKingdom(DataManager.MapDataController.FocusKingdomID, DataManager.MapDataController.FocusMapID);
				if (DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
				{
					DataManager.msgBuffer[0] = 89;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					this.ShowKingdomMark(false);
					GUIManager.Instance.m_HUDMessage.MapHud.AddChangeKindomMapMsg();
					GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
				}
			}
			else
			{
				Camera.main.cullingMask &= -2;
				this.CloseMenu(this.m_WindowStack.Count > 0);
				GUIManager.Instance.m_HUDMessage.MapHud.AddChangeKindomMapMsg();
				DataManager.msgBuffer[0] = 36;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				this.m_bDontDestroyOnSwitch = true;
				GameManager.SwitchGameplay(GameplayKind.CHAOS);
			}
			DataManager.MapDataController.RequsetYolkswitch();
			break;
		case 3:
			DataManager.msgBuffer[0] = 67;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			DataManager.StageDataController.currentWorldMode = WorldMode.Wild;
			DataManager.StageDataController._stageMode = StageMode.Count;
			if (this.bHideMainMenu)
			{
				this.bHideMainMenu = false;
				this.SwitchFullMap(false);
			}
			NewbieManager.bIgnoreGameplayCheck = true;
			this.SwitchMapMode(EUIOriginMapMode.OriginMap);
			this.m_bDontDestroyOnSwitch = true;
			GameManager.SwitchGameplay(GameplayKind.Origin);
			GUIManager.Instance.m_HUDMessage.MapHud.AddManorMsg();
			break;
		case 4:
			if (DataManager.MapDataController.gotoKingdomState == 255)
			{
				DataManager.MapDataController.gotoKingdomState = 0;
				this.CloseMenu(this.m_WindowStack.Count > 0);
				DataManager.msgBuffer[0] = 127;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			else
			{
				Camera.main.cullingMask &= -2;
				this.CloseMenu(this.m_WindowStack.Count > 0);
				DataManager.msgBuffer[0] = 36;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				this.m_bDontDestroyOnSwitch = true;
				GameManager.SwitchGameplay(GameplayKind.Cosmos);
				GUIManager.Instance.m_HUDMessage.MapHud.AddWorldMsg();
			}
			break;
		case 5:
			this.RefreshFuncBtnCount(0, arg2);
			break;
		case 9:
			this.CheckAllianceFreeState();
			break;
		case 10:
			this.RefreshFuncBtnCount(4, -1);
			break;
		case 11:
			this.CheckHelpAlertState();
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_StageSelect, 1, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_StageSelect2, 1, 0);
			break;
		case 12:
			this.CheckBuffState();
			break;
		case 13:
			this.CheckTalentPoint();
			break;
		case 14:
			this.CheckSysSetting();
			break;
		case 15:
			this.RefreshFuncBtnCount(3, -1);
			break;
		case 16:
			this.CheckTreasureBox();
			break;
		case 17:
			this.RefreshFuncBtnCount(5, -1);
			break;
		case 18:
			this.UpDateLeadState();
			break;
		case 19:
			this.CheckFuncButtonState();
			break;
		case 20:
			this.RefreshFuncBtnCount(2, -1);
			break;
		case 21:
			this.CheckShowDaBauBtn();
			break;
		case 23:
			this.SetTreasureBoxSprite();
			break;
		case 24:
			this.CheckShowMissionFlash();
			break;
		case 25:
			this.ShowKVKTime(false);
			this.ShowKingdomMark(false);
			break;
		case 26:
			this.CheckPetSkillBtn(arg2);
			break;
		case 27:
			this.CheckFBBtn(arg2);
			break;
		case 28:
			this.ShowFIFATime(false);
			break;
		case 29:
			this.CheckShowMapInfoFlash();
			break;
		}
	}

	// Token: 0x06000CAB RID: 3243 RVA: 0x0012C718 File Offset: 0x0012A918
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_QBarTime:
			DataManager.Instance.bNeedSortQueueBarData = true;
			return;
		default:
			switch (networkNews)
			{
			case NetworkNews.Login:
			case NetworkNews.Refresh:
				if (meg[0] == 0)
				{
					this.m_GroundInfo.m_RequsetTick = 2f;
					this.m_GroundInfo.bRequsetAdvanceMapdata = true;
				}
				GUIManager.Instance.HideUILock(EUILock.All);
				this.UpdateMoney();
				this.UpdateResource();
				this.UpDateLeadState();
				this.CheckShowMissionFlash();
				this.CheckAllianceFreeState();
				for (int i = 0; i < 6; i++)
				{
					this.RefreshFuncBtnCount(i, -1);
				}
				this.RefreshMainEff();
				if (meg[0] == 0)
				{
					NewbieManager.NB_SpawnPetTimeCache = 0L;
					NewbieManager.EntryTest();
				}
				return;
			case NetworkNews.Fallout:
			case NetworkNews.Refresh_Hero:
			case NetworkNews.Refresh_Item:
			case NetworkNews.Refresh_Stage:
			case NetworkNews.Refresh_Alliance:
			case NetworkNews.Refresh_Inputbox:
				return;
			case NetworkNews.Refresh_Asset:
				if (meg[1] == 0 && meg[2] == 1 && (int)GameConstants.ConvertBytesToUShort(meg, 3) == this.m_GroundInfo.Get0NpcCastleHeadID())
				{
					this.m_GroundInfo.UpdateCastleIcon();
				}
				return;
			case NetworkNews.Refresh_Attr:
				break;
			case NetworkNews.Refresh_Resource:
				this.UpdateResource();
				return;
			case NetworkNews.Refresh_Mailbox:
				this.RefreshFuncBtnCount(4, -1);
				return;
			default:
				return;
			}
			break;
		case NetworkNews.Refresh_AttribEffectVal:
		case NetworkNews.Refresh_Morale:
		case NetworkNews.Refresh_MonsterPoint:
			this.UpdateMoney();
			return;
		case NetworkNews.Refresh_HeroExclamation:
			this.RefreshFuncBtnCount(0, 0);
			return;
		case NetworkNews.Refresh_ChangeLord:
			break;
		case NetworkNews.Refresh_VIP:
			DataManager.Instance.bNeedSortQueueBarData = true;
			this.UpdateRoleInfo();
			return;
		case NetworkNews.Refresh_FontTextureRebuilt:
			this.Refresh_FontTextureRebuilt();
			if (this.m_GroundInfo != null)
			{
				this.m_GroundInfo.Refresh_FontTexture();
			}
			return;
		case NetworkNews.Refresh_PetResource:
			this.UpdateMoney();
			this.UpDateForceHint();
			return;
		}
		this.UpdateRoleInfo();
	}

	// Token: 0x06000CAC RID: 3244 RVA: 0x0012C908 File Offset: 0x0012AB08
	private void Refresh_FontTextureRebuilt()
	{
		if (this.m_QueueTimeBar != null)
		{
			for (int i = 0; i < this.m_QueueTimeBar.Length; i++)
			{
				if (this.m_QueueTimeBar[i] != null && this.m_QueueTimeBar[i].gameObject.activeSelf)
				{
					this.m_QueueTimeBar[i].Refresh_FontTexture();
				}
			}
		}
		for (int j = 0; j < this.m_ResourceText.Length; j++)
		{
			if (this.m_ResourceText[j] != null && this.m_ResourceText[j].enabled)
			{
				this.m_ResourceText[j].enabled = false;
				this.m_ResourceText[j].enabled = true;
			}
		}
		for (int k = 0; k < this.RBText.Length; k++)
		{
			if (this.RBText[k] != null && this.RBText[k].enabled)
			{
				this.RBText[k].enabled = false;
				this.RBText[k].enabled = true;
			}
		}
		for (int l = 0; l < this.m_FuncBtnText.Length; l++)
		{
			if (this.m_FuncBtnText[l] != null && this.m_FuncBtnText[l].enabled)
			{
				this.m_FuncBtnText[l].enabled = false;
				this.m_FuncBtnText[l].enabled = true;
			}
		}
		if (this.m_LocationXText != null && this.m_LocationXText.enabled)
		{
			this.m_LocationXText.enabled = false;
			this.m_LocationXText.enabled = true;
		}
		if (this.m_LocationYText != null && this.m_LocationYText.enabled)
		{
			this.m_LocationYText.enabled = false;
			this.m_LocationYText.enabled = true;
		}
		if (this.m_HomeDistText != null && this.m_HomeDistText.enabled)
		{
			this.m_HomeDistText.enabled = false;
			this.m_HomeDistText.enabled = true;
		}
		if (this.m_VipText != null && this.m_VipText.enabled)
		{
			this.m_VipText.enabled = false;
			this.m_VipText.enabled = true;
		}
		if (this.m_Power != null && this.m_Power.enabled)
		{
			this.m_Power.enabled = false;
			this.m_Power.enabled = true;
		}
		if (this.m_Level != null && this.m_Level.enabled)
		{
			this.m_Level.enabled = false;
			this.m_Level.enabled = true;
		}
		if (this.m_DiamondText != null && this.m_DiamondText.enabled)
		{
			this.m_DiamondText.enabled = false;
			this.m_DiamondText.enabled = true;
		}
		if (this.m_MoraleText != null && this.m_MoraleText.enabled)
		{
			this.m_MoraleText.enabled = false;
			this.m_MoraleText.enabled = true;
		}
		if (this.m_MoraleHintText != null && this.m_MoraleHintText.enabled)
		{
			this.m_MoraleHintText.enabled = false;
			this.m_MoraleHintText.enabled = true;
		}
		if (this.m_AttackedAlertText != null && this.m_AttackedAlertText.enabled)
		{
			this.m_AttackedAlertText.enabled = false;
			this.m_AttackedAlertText.enabled = true;
		}
		if (this.m_HelpAlertext != null && this.m_HelpAlertext.enabled)
		{
			this.m_HelpAlertext.enabled = false;
			this.m_HelpAlertext.enabled = true;
		}
		if (this.m_HelpAlertext2 != null && this.m_HelpAlertext2.enabled)
		{
			this.m_HelpAlertext2.enabled = false;
			this.m_HelpAlertext2.enabled = true;
		}
		if (this.m_AllianceFreetext != null && this.m_AllianceFreetext.enabled)
		{
			this.m_AllianceFreetext.enabled = false;
			this.m_AllianceFreetext.enabled = true;
		}
		if (this.m_TroopsText != null && this.m_TroopsText.enabled)
		{
			this.m_TroopsText.enabled = false;
			this.m_TroopsText.enabled = true;
		}
		if (this.m_BuffText != null && this.m_BuffText.enabled)
		{
			this.m_BuffText.enabled = false;
			this.m_BuffText.enabled = true;
		}
		if (this.m_ActivityTitleText != null && this.m_ActivityTitleText.enabled)
		{
			this.m_ActivityTitleText.enabled = false;
			this.m_ActivityTitleText.enabled = true;
		}
		if (this.m_ActivityTimeText != null && this.m_ActivityTimeText.enabled)
		{
			this.m_ActivityTimeText.enabled = false;
			this.m_ActivityTimeText.enabled = true;
		}
		if (this.m_TreasureBoxtext != null && this.m_TreasureBoxtext.enabled)
		{
			this.m_TreasureBoxtext.enabled = false;
			this.m_TreasureBoxtext.enabled = true;
		}
		if (this.m_MissionHinttextL != null && this.m_MissionHinttextL.enabled)
		{
			this.m_MissionHinttextL.enabled = false;
			this.m_MissionHinttextL.enabled = true;
		}
		if (this.m_MissionHinttextR != null && this.m_MissionHinttextR.enabled)
		{
			this.m_MissionHinttextR.enabled = false;
			this.m_MissionHinttextR.enabled = true;
		}
		if (this.m_QueueCountText != null && this.m_QueueCountText.enabled)
		{
			this.m_QueueCountText.enabled = false;
			this.m_QueueCountText.enabled = true;
		}
		if (this.KingdomMarkText != null && this.KingdomMarkText.enabled)
		{
			this.KingdomMarkText.enabled = false;
			this.KingdomMarkText.enabled = true;
		}
		if (this.PVPTimeText != null && this.PVPTimeText.enabled)
		{
			this.PVPTimeText.enabled = false;
			this.PVPTimeText.enabled = true;
		}
		if (this.KVKTimeText != null && this.KVKTimeText.enabled)
		{
			this.KVKTimeText.enabled = false;
			this.KVKTimeText.enabled = true;
		}
		if (this.RunningText != null)
		{
			if (this.RunningText.m_RunningText1 != null && this.RunningText.m_RunningText1.enabled)
			{
				this.RunningText.m_RunningText1.enabled = false;
				this.RunningText.m_RunningText1.enabled = true;
			}
			if (this.RunningText.m_RunningText2 != null && this.RunningText.m_RunningText2.enabled)
			{
				this.RunningText.m_RunningText2.enabled = false;
				this.RunningText.m_RunningText2.enabled = true;
			}
		}
		if (this.m_MallText != null && this.m_MallText.enabled)
		{
			this.m_MallText.enabled = false;
			this.m_MallText.enabled = true;
		}
		if (this.m_PetSkillText != null && this.m_PetSkillText.enabled)
		{
			this.m_PetSkillText.enabled = false;
			this.m_PetSkillText.enabled = true;
		}
		if (this.m_FBBtnCountText != null && this.m_FBBtnCountText.enabled)
		{
			this.m_FBBtnCountText.enabled = false;
			this.m_FBBtnCountText.enabled = true;
		}
		if (this.m_FBBtnTimeText != null && this.m_FBBtnTimeText.enabled)
		{
			this.m_FBBtnTimeText.enabled = false;
			this.m_FBBtnTimeText.enabled = true;
		}
	}

	// Token: 0x06000CAD RID: 3245 RVA: 0x0012D168 File Offset: 0x0012B368
	public override bool OnBackButtonClick()
	{
		if (this.m_GroundInfo.bGroundInfoOpen)
		{
			this.m_GroundInfo.Close();
			return true;
		}
		if (this.m_WindowStack.Count != 0)
		{
			GUIWindow guiwindow = GUIManager.Instance.FindMenu(this.m_WindowStack[this.m_WindowStack.Count - 1].m_eWindow);
			if (guiwindow != null && guiwindow.OnBackButtonClick())
			{
				return true;
			}
			this.CloseMenu(false);
		}
		else
		{
			GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(685u), DataManager.Instance.mStringTable.GetStringByID(242u), 0, 0, null, null);
		}
		return true;
	}

	// Token: 0x06000CAE RID: 3246 RVA: 0x0012D22C File Offset: 0x0012B42C
	public void setFightButton(AssetBundle _FightButtonAB)
	{
		if (_FightButtonAB == null)
		{
			if (this.FightassetKey != 0)
			{
				AssetManager.UnloadAssetBundle(this.FightassetKey, true);
				this.FightassetKey = 0;
			}
			this.FightButtonAS = null;
			this.FightButtonAS_Touch = null;
			if (this.FightButton != null)
			{
				UnityEngine.Object.Destroy(this.FightButton.gameObject);
				this.FightButton = null;
			}
		}
		else if (this.FightButton == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_FightButtonAB.mainAsset) as GameObject;
			this.FightButtonSMR = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
			if (DataManager.Instance.GoToBattleOrWar == GameplayKind.CHAOS)
			{
				GameObject gameObject2 = new GameObject("point light");
				Light light = gameObject2.AddComponent<Light>();
				light.type = LightType.Point;
				light.range = 10f;
				light.intensity = 7.5f;
				light.color = new Color(0.8667f, 0.8118f, 0.8078f);
				gameObject2.transform.localPosition = new Vector3(0f, -0.387f, 2.694f);
				gameObject2.transform.eulerAngles = new Vector3(357.55f, 180f, 180f);
				gameObject2.transform.SetParent(gameObject.transform, false);
			}
			gameObject.SetActive(false);
			gameObject.transform.SetParent(GUIManager.Instance.m_WindowsTransform, false);
			this.FightButton = gameObject.GetComponent<Animation>();
			this.FightButtonAS = this.FightButton[this.FightName];
			this.FightButtonAS_Touch = this.FightButton[this.TouchName];
			GUIManager.Instance.SetLayer(gameObject, 5);
			this.FightButton.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		}
	}

	// Token: 0x06000CAF RID: 3247 RVA: 0x0012D3FC File Offset: 0x0012B5FC
	public void ShowFightButton(Vector3 position, float Scale, bool closeLightProbes = false, E3DButtonKind BtnKind = E3DButtonKind.BK_Main)
	{
		if (this.FightButton == null)
		{
			AssetBundle assetBundle = AssetManager.GetAssetBundle("Role/3dbutton01", out this.FightassetKey, false);
			if (assetBundle)
			{
				this.setFightButton(assetBundle);
			}
			if (this.FightButton == null)
			{
				this.FightassetKey = 0;
				return;
			}
		}
		this.FightButton.transform.localPosition = position;
		this.FightButton.transform.localScale = new Vector3(Scale, Scale, Scale);
		this.FightButton.wrapMode = WrapMode.Loop;
		this.FightButton.Play("idle");
		this.FightButton.gameObject.SetActive(true);
		this.FightButton.transform.SetAsLastSibling();
		this.FightButton.transform.localRotation = Quaternion.Euler(0f, (!Camera.main.orthographic) ? (180f - Camera.main.fieldOfView * 0.5f) : 180f, 0f);
		if (DataManager.Instance.GoToBattleOrWar == GameplayKind.CHAOS)
		{
			Light component = this.FightButton.transform.GetChild(2).GetComponent<Light>();
			if (Scale == 150f)
			{
				component.range = 10f;
			}
			else if (Scale == 250f)
			{
				component.range = 14f;
			}
			else
			{
				component.range = 12f;
			}
		}
		if (closeLightProbes)
		{
			this.FightButtonSMR.useLightProbes = false;
		}
	}

	// Token: 0x06000CB0 RID: 3248 RVA: 0x0012D588 File Offset: 0x0012B788
	public void HideFightButton()
	{
		if (this.FightButton == null)
		{
			return;
		}
		this.FightButton.gameObject.SetActive(false);
		this.FightButtonSMR.useLightProbes = true;
		this.m_BattleButton.gameObject.SetActive(false);
	}

	// Token: 0x06000CB1 RID: 3249 RVA: 0x0012D5D8 File Offset: 0x0012B7D8
	public float PlayFight(float PlayTime = 0f)
	{
		if (this.FightButton != null)
		{
			if (PlayTime != 0f)
			{
				this.FightButtonAS.speed = this.FightButtonAS.length / PlayTime;
				this.PlayFightTime = PlayTime;
			}
			else
			{
				this.PlayFightTime = this.FightButtonAS.length;
			}
			this.PlayFightTime *= 0.6f;
			this.FightButton.wrapMode = WrapMode.Once;
			this.FightButton.Play(this.FightName);
			return this.PlayFightTime + 0.2f;
		}
		return 0f;
	}

	// Token: 0x06000CB2 RID: 3250 RVA: 0x0012D678 File Offset: 0x0012B878
	public float PlayTouch(float PlayTime = 0f)
	{
		if (this.FightButton != null)
		{
			if (PlayTime != 0f)
			{
				this.FightButtonAS_Touch.speed = this.FightButtonAS_Touch.length / PlayTime;
				this.PlayTouchTime = PlayTime;
			}
			else
			{
				this.PlayTouchTime = this.FightButtonAS_Touch.length;
			}
			this.FightButton.wrapMode = WrapMode.Once;
			this.FightButton.Play(this.TouchName);
			return this.PlayTouchTime;
		}
		return 0f;
	}

	// Token: 0x06000CB3 RID: 3251 RVA: 0x0012D700 File Offset: 0x0012B900
	public void FightButtonUpdate()
	{
		if (this.PlayFightTime > 0f)
		{
			this.PlayFightTime -= Time.deltaTime;
			if (this.PlayFightTime <= 0f)
			{
				this.Vec3.Set(0f, 0.4f, 0.4f);
				GameObject go = ParticleManager.Instance.Spawn(59, this.FightButton.transform, this.Vec3, 1f, true, true, true);
				GUIManager.Instance.SetLayer(go, 5);
				AudioManager.Instance.PlayUISFX(UIKind.AxSound);
				this.PlayFightTime = 0f;
			}
		}
	}

	// Token: 0x06000CB4 RID: 3252 RVA: 0x0012D7A8 File Offset: 0x0012B9A8
	public void ShowBattleButton()
	{
		this.ShowFightButton(this.m_BattleButton.transform.localPosition + new Vector3(95f, 18f, 0f), 150f, false, E3DButtonKind.BK_Main);
		this.m_BattleButton.gameObject.SetActive(true);
	}

	// Token: 0x06000CB5 RID: 3253 RVA: 0x0012D7FC File Offset: 0x0012B9FC
	public void SetTileMapController(MapTile _mapTile)
	{
		this.TileMapController = _mapTile;
	}

	// Token: 0x06000CB6 RID: 3254 RVA: 0x0012D808 File Offset: 0x0012BA08
	public void SetBackGroundPosZ(float Z)
	{
		if (this.m_Background == null)
		{
			return;
		}
		this.m_Background.anchoredPosition3D = new Vector3(this.m_Background.anchoredPosition3D.x, this.m_Background.anchoredPosition3D.y, Z);
	}

	// Token: 0x06000CB7 RID: 3255 RVA: 0x0012D860 File Offset: 0x0012BA60
	public void SetBackGroundColor(Color sColor)
	{
		if (this.m_Background == null)
		{
			return;
		}
		this.m_Background.GetChild(0).GetComponent<Image>().color = sColor;
		this.m_Background.GetChild(1).GetComponent<Image>().color = sColor;
	}

	// Token: 0x06000CB8 RID: 3256 RVA: 0x0012D8B0 File Offset: 0x0012BAB0
	private void Update()
	{
		if (this.isTrackBackGround)
		{
			this.TrackBackGround();
		}
		this.UpdateFuncButton();
		this.FightButtonUpdate();
		if (this.DM.SortQueueBarData())
		{
			this.UpdateQueue();
		}
		if (this.HomeArrowtarget != this.m_HomeArrowT.localRotation)
		{
			this.m_HomeArrowT.localRotation = Quaternion.Slerp(this.m_HomeArrowT.localRotation, this.HomeArrowtarget, Time.smoothDeltaTime * 15f);
		}
		long speed = this.DM.Resource[0].GetSpeed();
		if (speed < 0L)
		{
			this.ResourceRedTime += Time.deltaTime;
			if (this.bResourceRed)
			{
				if (this.ResourceRedTime >= 0.5f)
				{
					this.ResourceRedTime = 0f;
					this.m_ResourceText[0].color = this.m_ResourceColor[0];
					this.bResourceRed = false;
				}
			}
			else if (this.ResourceRedTime >= 1.3f)
			{
				this.ResourceRedTime = 0f;
				this.m_ResourceText[0].color = Color.red;
				this.bResourceRed = true;
			}
		}
		else if (this.bResourceRed)
		{
			this.ResourceRedTime = 0f;
			this.bResourceRed = false;
			this.m_ResourceText[0].color = this.m_ResourceColor[0];
		}
		if (this.m_BuffRC2.gameObject.activeInHierarchy)
		{
			if (DataManager.Instance.bHaveWarBuff)
			{
				this.BuffRedTime += Time.deltaTime;
			}
			this.BuffTextTime += Time.deltaTime;
			if (this.bBuffRed)
			{
				if (this.BuffRedTime >= 0.5f)
				{
					this.BuffRedTime = 0f;
					this.m_BuffText2.color = Color.white;
					this.bBuffRed = false;
				}
			}
			else if (this.BuffRedTime >= 1.3f)
			{
				this.BuffRedTime = 0f;
				this.m_BuffText2.color = Color.red;
				this.bBuffRed = true;
			}
			if (this.BuffTextTime >= 1f)
			{
				this.m_BuffAlertStr2.Length = 0;
				if (ShieldLogManager.Instance.IsNeedShowBecomeDue())
				{
					ShieldLogManager.Instance.GetBecomeDueTimeString(this.m_BuffAlertStr2);
				}
				else
				{
					GameConstants.GetTimeString(this.m_BuffAlertStr2, 0u, false, false, false, false, true);
				}
				this.m_BuffText2.text = this.m_BuffAlertStr2.ToString();
				this.m_BuffText2.SetAllDirty();
				this.m_BuffText2.cachedTextGenerator.Invalidate();
				this.m_BuffText2.cachedTextGeneratorForLayout.Invalidate();
				this.BuffTextTime = 0f;
			}
		}
		else if (this.bBuffRed)
		{
			this.BuffRedTime = 0f;
			this.bBuffRed = false;
			this.m_BuffText2.color = this.m_ResourceColor[0];
		}
		if (this.bMoraleHintOpen)
		{
			this.SetMolareHint(true);
		}
		if (this.bShowLoadingImg)
		{
			this.LoadingImgT.Rotate(Vector3.forward * Time.smoothDeltaTime * -200f);
		}
		if (this.NewMissionReward.enabled && this.m_MissionHintTrans.gameObject.activeSelf)
		{
			float num = Mathf.Clamp(this.RewardTime / this.MaxRewardTime, 0f, 1f);
			Color color = this.NewMissionReward.color;
			this.NewMissionReward.rectTransform.localScale = Vector3.one * 0.9f + Vector3.one * (0.5f * num);
			if (num < 0.5f)
			{
				color.a = num * 2f;
			}
			else
			{
				color.a = 1f - (num - 0.5f) / 0.5f;
			}
			this.NewMissionReward.color = color;
			this.RewardTime += Time.deltaTime;
			if (this.RewardTime > this.MaxRewardTime)
			{
				this.RewardTime = 0f;
			}
		}
		if (this.m_TickBeginAnimBtnTime <= 10f)
		{
			this.m_TickBeginAnimBtnTime += Time.deltaTime;
		}
		if (this.m_TickBeginAnimBtnTime >= 10f && this.m_TickEndAnimBtnTime <= 0.2f)
		{
			this.m_TickEndAnimBtnTime += Time.deltaTime;
		}
		if (this.m_MissionBtn.enabled && !this.NewMissionReward.enabled && this.m_TickBeginAnimBtnTime >= 10f)
		{
			if (!this.m_MissionBtnTS.enabled)
			{
				this.m_MissionBtnTS.enabled = true;
				this.m_MissionBtnTS.factor = 0f;
			}
			if (this.m_TickEndAnimBtnTime >= 0.2f)
			{
				float num2 = Mathf.Abs(this.m_MissionBtnRect.localScale.x);
				if (num2 < 1.1f && num2 > 0.9f)
				{
					this.m_TickEndAnimBtnTime = 0f;
					this.m_TickBeginAnimBtnTime = 0f;
				}
			}
		}
		else if (this.m_MissionBtnTS.enabled)
		{
			this.m_MissionBtnRect.localScale = new Vector3(1f, 1f, 1f);
			this.m_MissionBtnTS.enabled = false;
		}
	}

	// Token: 0x06000CB9 RID: 3257 RVA: 0x0012DE40 File Offset: 0x0012C040
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			this.UpdatePVPTime();
			this.UpdateKVKTime();
			this.UpdateFIFATime();
			this.SetFBBtnTime();
		}
		this.FadeInOutUpDate();
		this.GroundInfoUpdate();
	}

	// Token: 0x06000CBA RID: 3258 RVA: 0x0012DE78 File Offset: 0x0012C078
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			Application.Quit();
		}
	}

	// Token: 0x06000CBB RID: 3259 RVA: 0x0012DE88 File Offset: 0x0012C088
	public void ForceQueueBarOpenClose(bool bOpen)
	{
		QueueBarData queueBarData = DataManager.Instance.queueBarData[17];
		if ((!queueBarData.bActive || this.m_QueueCount > 1) && this.m_QueueCount > 0)
		{
			this.SetQueueBar(bOpen);
			this.QueuePanelSetActive(bOpen);
			DataManager.Instance.bOpenQueue = bOpen;
		}
	}

	// Token: 0x06000CBC RID: 3260 RVA: 0x0012DEEC File Offset: 0x0012C0EC
	public void ForceFuncBtnOpenClose(bool bOpen)
	{
		this.m_bShowFuncButton = ((!bOpen) ? 3 : 2);
		this.m_ShowFuncTime = 0f;
		if (bOpen)
		{
			if (this.m_WindowStack.Count > 0)
			{
				this.m_FuncPanelBG.gameObject.SetActive(true);
				this.m_MapSwitchButton.gameObject.SetActive(true);
				this.m_MapSwitchButton.alpha = 0f;
			}
			this.m_FuncBG.gameObject.SetActive(true);
		}
		else
		{
			this.m_FuncPanelBG.gameObject.SetActive(false);
			this.m_MapSwitchButton.alpha = 1f;
		}
	}

	// Token: 0x06000CBD RID: 3261 RVA: 0x0012DF98 File Offset: 0x0012C198
	public void OnButtonClick(UIButton sender)
	{
		DataManager.MapDataController.StopMapWeapon();
		this.SetDefaultFadeAlpha();
		switch (sender.m_BtnID1)
		{
		case 1:
			this.FuncButtonOnClick(sender);
			break;
		case 2:
		{
			int btnID = sender.m_BtnID2;
			if (btnID == 0)
			{
				DataManager.StageDataController.resetStageMode(StageMode.Corps);
				DataManager.msgBuffer[0] = 3;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			break;
		}
		case 3:
			this.MapFuncButtonOnClick(sender);
			break;
		case 11:
			this.MoneyOnClick(sender);
			break;
		case 13:
		case 16:
			this.OpenMenu(EGUIWindow.UI_LordInfo, 1, 0, true);
			break;
		case 14:
			this.OpenMenu(EGUIWindow.UI_VIP, 0, 0, false);
			break;
		case 15:
			this.ForceQueueBarOpenClose(!this.m_QueuePanel.gameObject.activeSelf);
			break;
		case 22:
		{
			RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(13, 0);
			this.OpenMenu(EGUIWindow.UI_Watchtower, (int)buildData.ManorID, (int)buildData.BuildID, false);
			break;
		}
		case 23:
			this.OpenMenu(EGUIWindow.UI_Alliance_HelpSpeedup, 0, 0, false);
			break;
		case 24:
			this.OpenMenu(EGUIWindow.UI_ArmyInfo, 0, 0, false);
			break;
		case 25:
			this.AllianceOnClick();
			break;
		case 26:
			ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST();
			break;
		case 27:
			this.OpenMenu(EGUIWindow.UI_BuffList, 0, 0, false);
			break;
		case 28:
			if (MallManager.Instance.CheckBtnShow())
			{
				GUIManager.Instance.OpenMenu(EGUIWindow.UI_TreasureBox, 11, 0, false, true, false);
			}
			else if (this.DM.CheckDailyGift())
			{
				GUIManager.Instance.OpenUI_Queued_Restricted_Top(EGUIWindow.UI_TreasureBox, 12, 1, true, 1);
			}
			else if (this.DM.RoleAttr.NextOnlineGiftOpenTime - this.DM.ServerTime >= 0L)
			{
				this.GM.OpenMenu(EGUIWindow.UI_TreasureBox, 0, 0, false, true, false);
			}
			else
			{
				this.GM.OpenMenu(EGUIWindow.UI_TreasureBox, 1, 0, false, true, false);
			}
			break;
		case 29:
		{
			ushort num = (ushort)sender.m_BtnID3;
			if (sender.m_BtnID2 == 1)
			{
				ManorAimTbl recordByKey = DataManager.MissionDataManager.ManorAimTable.GetRecordByKey(num);
				if (recordByKey.MissionKind - 1 == 0)
				{
					DataManager.MissionDataManager.sendMissionComplete(num, GUIManager.Instance.BuildingData.GetBuildData(recordByKey.Parm1, 0).ManorID);
				}
				else
				{
					DataManager.MissionDataManager.sendMissionComplete(num, 0);
				}
				GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x + sender.transform.GetComponent<RectTransform>().anchoredPosition.x, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y - sender.transform.GetComponent<RectTransform>().anchoredPosition.y);
			}
			else
			{
				DataManager.MissionDataManager.GetManorAimGuide(num);
			}
			break;
		}
		case 30:
			MallManager.Instance.Send_Mall_Info();
			break;
		case 31:
			GUIManager.Instance.OpenMenu(EGUIWindow.UI_TreasureBox, 10, 0, false, true, false);
			break;
		case 32:
			this.OpenMenu(EGUIWindow.UI_PetBuff, 0, 0, false);
			break;
		case 33:
			if (DataManager.Instance.bHaveWarBuff)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9943u), 255, true);
			}
			else
			{
				DataManager.Instance.MoveTo(DataManager.MapDataController.FocusKingdomID, -1);
			}
			break;
		case 34:
			if (this.m_FBUIType > 0)
			{
				GUIManager.Instance.OpenMenu(EGUIWindow.UI_TreasureBox_FB, 0, 0, false, true, false);
			}
			else
			{
				DataManager.FBMissionDataManager.m_FBBindEnd = false;
				this.OpenMenu(EGUIWindow.UI_MissionFB, 0, 0, true);
			}
			break;
		case 35:
			FootballManager.Instance.MoveToFootballPos();
			break;
		}
	}

	// Token: 0x06000CBE RID: 3262 RVA: 0x0012E3FC File Offset: 0x0012C5FC
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.Parm1 == 0)
		{
			Vector2 anchoredPosition = ((RectTransform)this.m_MoraleBox.transform).anchoredPosition;
			anchoredPosition.x += 125f;
			anchoredPosition.y -= 37f;
			this.m_MoraleHintBox.rectTransform.anchoredPosition = anchoredPosition;
			this.m_MoraleHintBox.gameObject.SetActive(true);
			this.bMoraleHintOpen = true;
			this.MonsterTime = -1L;
			this.MoraleHintTime = 2L;
			this.SetForceCount();
			this.SetMolareHint(true);
		}
		else if (sender.Parm1 == 1)
		{
			this.PVPTimeStr.Length = 0;
			this.PVPTimeStr.StringToFormat(DataManager.MapDataController.GetYolkName(this.PVPWonderID, DataManager.MapDataController.FocusKingdomID));
			this.PVPTimeStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11078u));
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.PVPTimeStr, Vector2.zero);
		}
		else if (sender.Parm1 == 2)
		{
			this.KVKTimeStr.Length = 0;
			this.KVKTimeStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12092u));
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.KVKTimeStr, Vector2.zero);
		}
		else if (sender.Parm1 == 3)
		{
			this.FIFATimeStr.Length = 0;
			this.FIFATimeStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11243u));
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.FIFATimeStr, Vector2.zero);
		}
	}

	// Token: 0x06000CBF RID: 3263 RVA: 0x0012E5DC File Offset: 0x0012C7DC
	public void OnButtonUp(UIButtonHint sender)
	{
		if (sender.Parm1 == 0)
		{
			this.m_MoraleHintBox.gameObject.SetActive(false);
			this.bMoraleHintOpen = false;
			this.ForceTime = 0u;
		}
		else if (sender.Parm1 == 1 || sender.Parm1 == 2 || sender.Parm1 == 3)
		{
			GUIManager.Instance.m_Hint.Hide(true);
		}
	}

	// Token: 0x06000CC0 RID: 3264 RVA: 0x0012E64C File Offset: 0x0012C84C
	private void AddFuncStack(EGUIWindow eWin)
	{
		GUIWindowStackData item;
		item.m_eWindow = eWin;
		item.m_Arg1 = 0;
		item.m_Arg2 = 0;
		item.bCameraMode = false;
		this.m_WindowStack.Add(item);
	}

	// Token: 0x06000CC1 RID: 3265 RVA: 0x0012E688 File Offset: 0x0012C888
	private void FuncButtonOnClick(UIButton sender)
	{
		if (this.m_bShowFuncButton >= 2)
		{
			return;
		}
		if (sender.m_BtnID2 >= 10 && this.m_WindowStack.Count > 0)
		{
			this.m_FuncPanelBG.gameObject.SetActive(false);
			this.m_MapSwitchButton.gameObject.SetActive(false);
			this.ShowFuncButton(false);
		}
		switch (sender.m_BtnID2)
		{
		case 0:
		case 1:
			this.ForceFuncBtnOpenClose(this.m_bShowFuncButton == 0);
			break;
		case 2:
			if (this.m_WindowStack.Count > 0)
			{
				this.CloseMenu(true);
				DataManager.msgBuffer[0] = 4;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			else if (this.m_eMapMode == EUIOriginMapMode.OriginMap)
			{
				if (!NewbieManager.CheckRename(true))
				{
					this.GoToGroup(-1, 0, true);
				}
			}
			else if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
			{
				this.GoToGroup(-1, 0, true);
			}
			else
			{
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToMap);
			}
			break;
		case 10:
			if (this.m_FuncLight[0].activeSelf)
			{
				this.m_FuncLight[0].SetActive(false);
			}
			this.ClearWindowStack();
			if (!this.OpenMenu(EGUIWindow.UI_HeroList, 0, 0, false))
			{
				this.AddFuncStack(EGUIWindow.UI_HeroList);
			}
			break;
		case 11:
		{
			UIBagFilter uibagFilter = GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter) as UIBagFilter;
			if (uibagFilter != null && uibagFilter.Type != 0)
			{
				if (this.GM.m_Chat != null && this.GM.m_Chat.activeInHierarchy)
				{
					this.CloseMenu(false);
				}
				this.CloseMenu(false);
			}
			this.ClearWindowStack();
			if (!this.OpenMenu(EGUIWindow.UI_BagFilter, 0, 0, false))
			{
				this.AddFuncStack(EGUIWindow.UI_BagFilter);
			}
			break;
		}
		case 12:
			this.ClearWindowStack();
			if (!this.OpenMenu(EGUIWindow.UI_Other, 0, 0, false))
			{
				this.AddFuncStack(EGUIWindow.UI_Other);
			}
			break;
		case 13:
			this.ClearWindowStack();
			if (!this.OpenMenu(EGUIWindow.UI_Mission, 0, 0, false))
			{
				this.AddFuncStack(EGUIWindow.UI_Mission);
			}
			break;
		case 14:
			this.ClearWindowStack();
			if (!this.OpenMenu(EGUIWindow.UI_Letter, 0, 0, false))
			{
				this.AddFuncStack(EGUIWindow.UI_Letter);
			}
			break;
		case 15:
		{
			if (this.m_FuncLight[5].activeSelf)
			{
				this.m_FuncLight[5].SetActive(false);
			}
			this.ClearWindowStack();
			EGUIWindow eWin;
			if (DataManager.Instance.RoleAlliance.Id > 0u)
			{
				eWin = EGUIWindow.UI_Alliance_Info;
			}
			else
			{
				DataManager.Instance.SetSelectRequest = 0;
				eWin = EGUIWindow.UI_AllianceHint;
			}
			if (!this.OpenMenu(eWin, 0, 0, false))
			{
				this.AddFuncStack(eWin);
			}
			break;
		}
		}
		GUIManager.Instance.HideArrow(false);
	}

	// Token: 0x06000CC2 RID: 3266 RVA: 0x0012E97C File Offset: 0x0012CB7C
	private void CheckFuncButtonState()
	{
		this.FunButtonShowCount = 0;
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < 6; i++)
		{
			bool flag = true;
			if (i == 0)
			{
				if (!this.GM.CheckOpenHeroBtn())
				{
					num2 = (num = 83f);
					this.m_FuncRC[0].gameObject.SetActive(false);
					flag = false;
				}
				else if (!this.GM.bOpenHeroBtn)
				{
					this.GM.bOpenHeroBtn = true;
					this.GM.bNeedForceOpenFuncBtn = true;
					this.RefreshFuncBtnCount(0, -1);
					this.m_FuncLight[0].SetActive(true);
				}
			}
			else if (i == 5)
			{
				if (!this.GM.CheckOpenAllianceBtn())
				{
					num2 += 93f;
					this.m_FuncRC[5].gameObject.SetActive(false);
					flag = false;
				}
				else if (!this.GM.bOpenAllianceBtn)
				{
					this.GM.bOpenAllianceBtn = true;
					this.GM.bNeedForceOpenFuncBtn = true;
					this.RefreshFuncBtnCount(5, -1);
					this.m_FuncLight[5].SetActive(true);
				}
			}
			if (flag)
			{
				this.m_SFuncRC[(int)this.FunButtonShowCount] = this.m_FuncRC[i];
				this.m_SFuncCG[(int)this.FunButtonShowCount] = this.m_FuncCG[i];
				this.m_SFuncPosX[(int)this.FunButtonShowCount] = this.m_FuncPosX[i] + num;
				this.FunButtonShowCount += 1;
			}
		}
		this.m_SFuncBGWidth = this.m_FuncBGWidth - num2;
		if (!this.ChecNeedForceOpenFuncBtn())
		{
			this.ShowFuncButton(this.m_bShowFuncButton == 1);
		}
	}

	// Token: 0x06000CC3 RID: 3267 RVA: 0x0012EB24 File Offset: 0x0012CD24
	private bool ChecNeedForceOpenFuncBtn()
	{
		if (GUIManager.Instance.bNeedForceOpenFuncBtn && this.m_eMode == EUIOriginMode.Show)
		{
			GUIManager.Instance.bNeedForceOpenFuncBtn = false;
			this.ForceFuncBtnOpenClose(true);
			return true;
		}
		return false;
	}

	// Token: 0x06000CC4 RID: 3268 RVA: 0x0012EB58 File Offset: 0x0012CD58
	private void UpdateFuncButton()
	{
		if (this.m_bShowFuncButton < 2)
		{
			return;
		}
		Vector2 vector = Vector2.zero;
		this.m_ShowFuncTime += Time.unscaledDeltaTime;
		if (this.m_ShowFuncTime < 0.1f)
		{
			if (this.m_bShowFuncButton == 2)
			{
				float num = 0.0100000007f;
				float num2 = (0.1f - num) / 2f;
				RectTransform rectTransform = this.m_FuncBG.rectTransform;
				float num3;
				if (this.m_ShowFuncTime < num)
				{
					num3 = this.m_ShowFuncTime / num;
					vector.x = this.m_SFuncBGWidth * num3;
				}
				else
				{
					float num4 = 0.200000048f / num2;
					float num5 = num4 * (this.m_ShowFuncTime - num - num2) / num2 * (this.m_ShowFuncTime - num - num2) / 2f;
					num3 = 1.1f - num5;
					vector.x = this.m_SFuncBGWidth * num3;
				}
				vector.y = rectTransform.sizeDelta.y;
				rectTransform.sizeDelta = vector;
				for (int i = 0; i < (int)this.FunButtonShowCount; i++)
				{
					this.m_SFuncRC[i].gameObject.SetActive(true);
					rectTransform = this.m_SFuncRC[i];
					vector = rectTransform.anchoredPosition;
					vector.x = this.m_ShowFuncPosX + (this.m_SFuncPosX[i] - this.m_ShowFuncPosX) * num3;
					rectTransform.anchoredPosition = vector;
					this.m_SFuncCG[i].alpha = this.m_ShowFuncTime / 0.1f;
				}
				if (this.m_WindowStack.Count > 0)
				{
					this.m_MapSwitchButton.alpha = this.m_ShowFuncTime / 0.1f;
				}
			}
			else
			{
				float num4 = this.m_ShowFuncTime / 0.1f;
				RectTransform rectTransform = this.m_FuncBG.rectTransform;
				vector.x = this.m_SFuncBGWidth - this.m_SFuncBGWidth * num4;
				vector.y = rectTransform.sizeDelta.y;
				rectTransform.sizeDelta = vector;
				float num5 = (this.m_SFuncPosX[(int)(this.FunButtonShowCount - 1)] - this.m_ShowFuncPosX) * (1f - this.m_ShowFuncTime / 0.1f);
				for (int j = 0; j < (int)this.FunButtonShowCount; j++)
				{
					if (num5 >= this.m_SFuncPosX[j] - this.m_ShowFuncPosX)
					{
						if (j > 0 && num5 > this.m_SFuncPosX[j - 1] - this.m_ShowFuncPosX)
						{
							this.m_SFuncRC[j].gameObject.SetActive(false);
						}
						else
						{
							rectTransform = this.m_SFuncRC[j];
							vector.x = num5 + this.m_ShowFuncPosX;
							vector.y = rectTransform.anchoredPosition.y;
							rectTransform.anchoredPosition = vector;
							num4 = ((j <= 0) ? 0f : (this.m_SFuncPosX[j - 1] - this.m_ShowFuncPosX));
							this.m_SFuncCG[j].alpha = (num5 - num4) / (this.m_SFuncPosX[j] - this.m_ShowFuncPosX - num4);
						}
					}
				}
				if (this.m_WindowStack.Count > 0)
				{
					this.m_MapSwitchButton.alpha = 1f - this.m_ShowFuncTime / 0.1f;
				}
			}
		}
		else if (this.m_bShowFuncButton == 2)
		{
			this.ShowFuncButton(true);
			if (this.m_WindowStack.Count > 0)
			{
				this.m_MapSwitchButton.alpha = 1f;
			}
		}
		else
		{
			this.ShowFuncButton(false);
			if (this.m_WindowStack.Count > 0)
			{
				this.m_MapSwitchButton.alpha = 1f;
				this.m_MapSwitchButton.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06000CC5 RID: 3269 RVA: 0x0012EF30 File Offset: 0x0012D130
	public void ShowFuncButton(bool bShow)
	{
		Vector2 vector = Vector2.zero;
		RectTransform rectTransform = this.m_FuncBG.rectTransform;
		rectTransform.gameObject.SetActive(bShow);
		vector.x = ((!bShow) ? 0f : this.m_SFuncBGWidth);
		vector.y = rectTransform.sizeDelta.y;
		rectTransform.sizeDelta = vector;
		for (int i = 0; i < (int)this.FunButtonShowCount; i++)
		{
			rectTransform = this.m_SFuncRC[i];
			rectTransform.gameObject.SetActive(bShow);
			float alpha;
			if (bShow)
			{
				vector.x = this.m_SFuncPosX[i];
				alpha = 1f;
			}
			else
			{
				vector.x = ((i <= 0) ? this.m_ShowFuncPosX : this.m_SFuncPosX[i - 1]);
				alpha = 0f;
			}
			vector.y = rectTransform.anchoredPosition.y;
			rectTransform.anchoredPosition = vector;
			this.m_SFuncCG[i].alpha = alpha;
			this.CheckandShowFuncBtnCount(i, bShow);
		}
		this.m_bShowFuncButton = ((!bShow) ? 0 : 1);
		rectTransform = (RectTransform)this.m_ShowFuncIcon.transform;
		rectTransform.localRotation = Quaternion.Euler(0f, (float)(180 * this.m_bShowFuncButton), 0f);
		vector = rectTransform.anchoredPosition;
		vector.x = ((!bShow) ? -30.5f : -19.5f);
		rectTransform.anchoredPosition = vector;
		this.CheckandShowFuncBtnCount(-1, false);
	}

	// Token: 0x06000CC6 RID: 3270 RVA: 0x0012F0BC File Offset: 0x0012D2BC
	private void MapFuncButtonOnClick(UIButton sender)
	{
		switch (sender.m_BtnID2)
		{
		case 1:
			if (this.m_eMapMode == EUIOriginMapMode.KingdomMap)
			{
				DataManager.MapDataController.gotokingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToWorld);
			}
			break;
		case 3:
			this.OpenMenu(EGUIWindow.UI_BookMark, 0, 0, false);
			break;
		case 4:
			this.bHideMainMenu = !this.bHideMainMenu;
			this.SwitchFullMap(false);
			break;
		case 5:
			if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
			{
				this.m_GroundInfo.OpenSearchPanel(true, true);
			}
			else
			{
				this.m_GroundInfo.OpenSearchPanel(true, false);
			}
			break;
		case 6:
			if (this.m_eMapMode == EUIOriginMapMode.KingdomMap)
			{
				this.CheckFocusGroup();
				DataManager.MapDataController.FocusGroupID = 10;
				this.GoToMapID(DataManager.MapDataController.OtherKingdomData.kingdomID, DataManager.Instance.RoleAttr.CapitalPoint, 0, 1, true);
			}
			else if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
			{
				this.GoToKingdom(DataManager.MapDataController.OtherKingdomData.kingdomID, -1);
			}
			break;
		case 7:
		{
			this.OpenMenu(EGUIWindow.UI_MiniMap, 0, 0, false);
			FootballManager instance = FootballManager.Instance;
			ActivityManager instance2 = ActivityManager.Instance;
			if (instance2.IsInFIFA(0, false) && instance2.NowWaveEndTime != 0L && instance.bFirstFootBallMiniMap)
			{
				instance.bFirstFootBallMiniMap = false;
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 29, 0);
			}
			break;
		}
		}
	}

	// Token: 0x06000CC7 RID: 3271 RVA: 0x0012F25C File Offset: 0x0012D45C
	public void notifyHomeBtnPos()
	{
		if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
		{
			DataManager.msgBuffer[0] = ((!this.bHideMainMenu) ? 116 : 117);
		}
		else
		{
			DataManager.msgBuffer[0] = ((!this.bHideMainMenu) ? 72 : 73);
		}
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06000CC8 RID: 3272 RVA: 0x0012F2BC File Offset: 0x0012D4BC
	public void SetShowHomeBtn(bool bShow)
	{
		this.bShowHomeBtn = bShow;
		this.m_HomeButton.gameObject.SetActive(this.bShowHomeBtn && !this.bHideMainByFIFA);
	}

	// Token: 0x06000CC9 RID: 3273 RVA: 0x0012F2F8 File Offset: 0x0012D4F8
	public void SetHomeBtnLocation(ushort posx, ushort posy)
	{
		this.m_HomeLocationX = posx;
		this.m_HomeLocationY = posy;
	}

	// Token: 0x06000CCA RID: 3274 RVA: 0x0012F308 File Offset: 0x0012D508
	public void SetCapitalLocation(ushort posx, ushort posy)
	{
		this.m_CapitalLocationX = posx;
		this.m_CapitalLocationY = posy;
	}

	// Token: 0x06000CCB RID: 3275 RVA: 0x0012F318 File Offset: 0x0012D518
	public void UpdateLocation(ushort posx, ushort posy, float DeltaX, float DeltaY)
	{
		Vector2 zero = Vector2.zero;
		Vector2 zero2 = Vector2.zero;
		Vector2 zero3 = Vector2.zero;
		Vector2 vector = Vector2.zero;
		zero.Set((float)posx - DeltaX, (float)posy + DeltaY);
		zero2.Set((float)this.m_CapitalLocationX, (float)this.m_CapitalLocationY);
		GUIManager.Instance.mNewCenterPos.Set((float)posx, (float)posy);
		if (GUIManager.Instance.IsArabic)
		{
			zero3.Set(zero.x - (float)this.m_HomeLocationX, zero.y - (float)this.m_HomeLocationY);
			this.LocXStr.Length = 0;
			this.LocXStr.IntToFormat((long)posx, 1, false);
			this.LocXStr.AppendFormat("{0}:X");
			this.LocYStr.Length = 0;
			this.LocYStr.IntToFormat((long)posy, 1, false);
			this.LocYStr.AppendFormat("{0}:Y");
		}
		else
		{
			zero3.Set(zero.x + (float)this.m_HomeLocationX, zero.y - (float)this.m_HomeLocationY);
			this.LocXStr.Length = 0;
			this.LocXStr.IntToFormat((long)posx, 1, false);
			this.LocXStr.AppendFormat("X:{0}");
			this.LocYStr.Length = 0;
			this.LocYStr.IntToFormat((long)posy, 1, false);
			this.LocYStr.AppendFormat("Y:{0}");
		}
		this.m_LocationXText.text = this.LocXStr.ToString();
		this.m_LocationXText.SetAllDirty();
		this.m_LocationXText.cachedTextGenerator.Invalidate();
		this.m_LocationYText.text = this.LocYStr.ToString();
		this.m_LocationYText.SetAllDirty();
		this.m_LocationYText.cachedTextGenerator.Invalidate();
		vector = zero2 - zero3;
		vector.x *= 2f;
		if (GUIManager.Instance.IsArabic)
		{
			this.HomeArrowtarget = Quaternion.Euler(0f, 0f, Vector2.Angle(vector, Vector2.up) * (float)((vector.x >= 0f) ? -1 : 1));
		}
		else
		{
			this.HomeArrowtarget = Quaternion.Euler(0f, 0f, Vector2.Angle(vector, Vector2.up) * (float)((vector.x >= 0f) ? 1 : -1));
		}
		vector = zero2 - zero3;
		this.HomeStr.Length = 0;
		if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
		{
			this.HomeStr.IntToFormat((long)DataManager.MapDataController.OtherKingdomData.kingdomID, 1, false);
			if (GUIManager.Instance.IsArabic)
			{
				this.HomeStr.AppendFormat("{0}:K");
			}
			else
			{
				this.HomeStr.AppendFormat("K:{0}");
			}
		}
		else
		{
			this.HomeStr.FloatToFormat(Vector2.Distance(vector, Vector2.zero), 1, true);
			this.HomeStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(252u));
			this.HomeStr.AppendFormat("{0} {1}");
		}
		this.m_HomeDistText.text = this.HomeStr.ToString();
		this.m_HomeDistText.SetAllDirty();
		this.m_HomeDistText.cachedTextGenerator.Invalidate();
		if (this.bHideMainByFIFA)
		{
			Vector2 tileMapPosbySpriteID = GameConstants.getTileMapPosbySpriteID(FootballManager.Instance.mFootBallMapID);
			if (this.GM.IsArabic)
			{
				this.LocXStrFIFA.Length = 0;
				this.LocXStrFIFA.IntToFormat((long)((int)tileMapPosbySpriteID.x), 1, false);
				this.LocXStrFIFA.AppendFormat("{0}:X");
				this.LocYStrFIFA.Length = 0;
				this.LocYStrFIFA.IntToFormat((long)((int)tileMapPosbySpriteID.y), 1, false);
				this.LocYStrFIFA.AppendFormat("{0}:Y");
			}
			else
			{
				this.LocXStrFIFA.Length = 0;
				this.LocXStrFIFA.IntToFormat((long)((int)tileMapPosbySpriteID.x), 1, false);
				this.LocXStrFIFA.AppendFormat("X:{0}");
				this.LocYStrFIFA.Length = 0;
				this.LocYStrFIFA.IntToFormat((long)((int)tileMapPosbySpriteID.y), 1, false);
				this.LocYStrFIFA.AppendFormat("Y:{0}");
			}
			this.m_LocationXText.text = this.LocXStrFIFA.ToString();
			this.m_LocationXText.SetAllDirty();
			this.m_LocationXText.cachedTextGenerator.Invalidate();
			this.m_LocationYText.text = this.LocYStrFIFA.ToString();
			this.m_LocationYText.SetAllDirty();
			this.m_LocationYText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06000CCC RID: 3276 RVA: 0x0012F7D8 File Offset: 0x0012D9D8
	public void CheckhowFIFA_FindBtn()
	{
		this.SetShowFIFA_FindBtn(this.m_eMapMode == EUIOriginMapMode.KingdomMap && FootballManager.Instance.mFootballKickData.combo > 0);
	}

	// Token: 0x06000CCD RID: 3277 RVA: 0x0012F804 File Offset: 0x0012DA04
	public void SetShowFIFA_FindBtn(bool bShow)
	{
		if (bShow && this.m_eMapMode == EUIOriginMapMode.KingdomMap && FootballManager.Instance.mFootballKickData.combo > 0)
		{
			this.bShowFIFA_FindBtn = bShow;
		}
		else
		{
			this.bShowFIFA_FindBtn = false;
		}
		this.FIFA_FindBtn.gameObject.SetActive(this.bShowFIFA_FindBtn);
	}

	// Token: 0x06000CCE RID: 3278 RVA: 0x0012F864 File Offset: 0x0012DA64
	private void UpDateLeadState()
	{
		if (DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.Captured)
		{
			this.m_HeadBoxJail.SetActive(true);
		}
		else
		{
			this.m_HeadBoxJail.SetActive(false);
		}
		this.CheckTalentPoint();
		this.UpdateRoleInfo();
	}

	// Token: 0x06000CCF RID: 3279 RVA: 0x0012F8B0 File Offset: 0x0012DAB0
	private void UpdateRoleInfo()
	{
		if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Dead)
		{
			this.m_HeadIcon.image.sprite = this.LoadSprite("UI_GG_001");
			this.m_HeadIcon.image.material = this.LoadMaterial();
		}
		else
		{
			Hero recordByKey = this.DM.HeroTable.GetRecordByKey(DataManager.Instance.RoleAttr.Head);
			if (recordByKey.HeroKey == this.DM.RoleAttr.Head)
			{
				this.m_HeadIcon.image.sprite = GUIManager.Instance.m_IconSpriteAsset.LoadSprite(recordByKey.Graph);
			}
			else
			{
				this.m_HeadIcon.image.sprite = GUIManager.Instance.m_IconSpriteAsset.LoadSprite(10);
			}
			this.m_HeadIcon.image.material = GUIManager.Instance.m_IconSpriteAsset.GetMaterial();
		}
		this.m_PowerStr.Length = 0;
		this.m_PowerStr.uLongToFormat(this.DM.RoleAttr.Power, 1, true);
		this.m_PowerStr.AppendFormat("{0}");
		this.m_Power.text = this.m_PowerStr.ToString();
		this.m_Power.SetAllDirty();
		this.m_Power.cachedTextGenerator.Invalidate();
		this.m_LevelStr.Length = 0;
		this.m_LevelStr.uLongToFormat((ulong)this.DM.RoleAttr.Level, 1, false);
		this.m_LevelStr.AppendFormat("{0}");
		this.m_Level.text = this.m_LevelStr.ToString();
		this.m_Level.SetAllDirty();
		this.m_Level.cachedTextGenerator.Invalidate();
		byte viplevel = this.DM.RoleAttr.VIPLevel;
		if (viplevel == 0)
		{
			this.m_VIPIcon.gameObject.SetActive(false);
		}
		else
		{
			this.m_VIPStr.Length = 0;
			this.m_VIPStr.IntToFormat((long)viplevel, 1, false);
			this.m_VIPStr.AppendFormat("{0}");
			this.m_VipText.text = this.m_VIPStr.ToString();
			this.m_VipText.SetAllDirty();
			this.m_VipText.cachedTextGenerator.Invalidate();
			this.m_VIPIcon.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000CD0 RID: 3280 RVA: 0x0012FB24 File Offset: 0x0012DD24
	public void AllianceInfo(uint ID)
	{
		DataManager.Instance.AllianceView.Id = ID;
		DataManager.Instance.AllianceView.Tag = string.Empty;
		this.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5, 0, false);
	}

	// Token: 0x06000CD1 RID: 3281 RVA: 0x0012FB64 File Offset: 0x0012DD64
	public void AllianceInfo(string Tag)
	{
		DataManager.Instance.AllianceView.Id = 0u;
		DataManager.Instance.AllianceView.Tag = Tag;
		this.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5, 0, false);
	}

	// Token: 0x06000CD2 RID: 3282 RVA: 0x0012FBA0 File Offset: 0x0012DDA0
	public void AllianceOnClick()
	{
		if (DataManager.Instance.RoleAlliance.Id > 0u)
		{
			if (GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceHint))
			{
				this.CloseMenu(false);
			}
			if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Alliance_Info) == null)
			{
				this.OpenMenu(EGUIWindow.UI_Alliance_Info, 0, 0, false);
			}
		}
		else if (DataManager.Instance.CheckPrizeFlag(0))
		{
			DataManager.Instance.SetSelectRequest = 0;
			this.OpenMenu(EGUIWindow.UI_AllianceHint, 11, 0, false);
		}
		else if (GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceHint) == null)
		{
			DataManager.Instance.SetSelectRequest = 0;
			this.OpenMenu(EGUIWindow.UI_AllianceHint, 0, 0, false);
		}
	}

	// Token: 0x06000CD3 RID: 3283 RVA: 0x0012FC64 File Offset: 0x0012DE64
	public void AllianceOnJoin(uint ID, byte Direct)
	{
		GUIManager.Instance.ShowUILock(EUILock.AllianceCreate);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_APPLY;
		messagePacket.AddSeqId();
		messagePacket.Add(0);
		messagePacket.Add(ID);
		messagePacket.Send(false);
	}

	// Token: 0x06000CD4 RID: 3284 RVA: 0x0012FCB0 File Offset: 0x0012DEB0
	public void AllianceOnJoin(string Tag)
	{
		GUIManager.Instance.ShowUILock(EUILock.AllianceCreate);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_APPLY;
		messagePacket.AddSeqId();
		messagePacket.Add(1);
		messagePacket.Add(Encoding.UTF8.GetBytes(Tag), 0, 3);
		messagePacket.Send(false);
	}

	// Token: 0x06000CD5 RID: 3285 RVA: 0x0012FD08 File Offset: 0x0012DF08
	private void MoneyOnClick(UIButton sender)
	{
		int num = 1;
		int btnID = sender.m_BtnID2;
		switch (btnID)
		{
		case 10:
			this.OpenMenu(EGUIWindow.UI_BagFilter, num, 0, false);
			break;
		case 11:
			this.OpenMenu(EGUIWindow.UI_BagFilter, num + 65536, 0, false);
			break;
		case 12:
			this.OpenMenu(EGUIWindow.UI_BagFilter, num + 131072, 0, false);
			break;
		case 13:
			this.OpenMenu(EGUIWindow.UI_BagFilter, num + 196608, 0, false);
			break;
		case 14:
			this.OpenMenu(EGUIWindow.UI_BagFilter, num + 262144, 0, false);
			break;
		default:
			if (btnID != 0)
			{
				if (btnID != 1)
				{
				}
			}
			else
			{
				MallManager.Instance.Send_Mall_Info();
			}
			break;
		}
	}

	// Token: 0x06000CD6 RID: 3286 RVA: 0x0012FDD0 File Offset: 0x0012DFD0
	private void CheckMonsterPoint()
	{
		bool flag = this.DM.RoleAttr.MonsterPoint >= this.DM.GetMaxMonsterPoint();
		if ((this.m_eMode == EUIOriginMode.MoneyAndFuncButtonWM || (this.m_eMode == EUIOriginMode.Show && this.m_eMapMode == EUIOriginMapMode.KingdomMap) || (this.m_eMode == EUIOriginMode.Show && this.m_eMapMode == EUIOriginMapMode.WorldMap)) && flag)
		{
			this.m_MoraleText.color = this.ResourceSColor;
			this.m_MoraleFlash.gameObject.SetActive(this.DM.MySysSetting.bShowMonsterPointMax && this.DM.GetTechLevel(76) > 0);
		}
		else
		{
			this.m_MoraleText.color = Color.white;
			this.m_MoraleFlash.gameObject.SetActive(false);
		}
		if (flag && this.m_eMapMode == EUIOriginMapMode.OriginMap)
		{
			this.m_MapSwitchImage2.gameObject.SetActive(this.DM.MySysSetting.bShowMonsterPointMax && this.DM.GetTechLevel(76) > 0);
		}
		else
		{
			this.m_MapSwitchImage2.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000CD7 RID: 3287 RVA: 0x0012FF0C File Offset: 0x0012E10C
	private void UpdateMoney()
	{
		this.DiamondString.ClearString();
		GameConstants.FormatResourceValue(this.DiamondString, DataManager.Instance.RoleAttr.Diamond);
		this.m_DiamondText.text = this.DiamondString.ToString();
		this.m_DiamondText.SetAllDirty();
		this.m_DiamondText.cachedTextGenerator.Invalidate();
		this.MoraleString.ClearString();
		this.m_MoraleForceBlood.gameObject.SetActive(false);
		this.m_MoraleSA2.SetSpriteIndex(0);
		this.m_MoraleText.color = Color.white;
		if (this.m_eMode == EUIOriginMode.MoneyAndFuncButtonF || this.m_eMode == EUIOriginMode.MoneyF)
		{
			this.m_MoraleForceBlood.gameObject.SetActive(true);
			this.m_MoraleSA2.SetSpriteIndex(1);
			this.m_MoraleSA.SetSpriteIndex(2);
			this.m_MoraleIcon.SetNativeSize();
			uint stock = this.DM.PetResource.Stock;
			uint capacity = this.DM.PetResource.Capacity;
			this.m_MoraleForceBlood.fillAmount = stock / capacity;
			if (stock >= capacity)
			{
				this.m_MoraleText.color = this.ResourceSColor;
			}
			else
			{
				this.m_MoraleText.color = Color.white;
			}
			GameConstants.FormatResourceValue(this.MoraleString, stock);
		}
		else if (this.m_eMode == EUIOriginMode.MoneyAndFuncButtonWM || (this.m_eMode == EUIOriginMode.Show && this.m_eMapMode == EUIOriginMapMode.KingdomMap) || (this.m_eMode == EUIOriginMode.Show && this.m_eMapMode == EUIOriginMapMode.WorldMap))
		{
			this.m_MoraleSA.SetSpriteIndex(1);
			this.m_MoraleIcon.SetNativeSize();
			GameConstants.FormatResourceValue(this.MoraleString, this.DM.RoleAttr.MonsterPoint);
		}
		else
		{
			this.m_MoraleSA.SetSpriteIndex(0);
			this.m_MoraleIcon.SetNativeSize();
			this.MoraleString.IntToFormat((long)this.DM.RoleAttr.Morale, 1, false);
			this.MoraleString.IntToFormat((long)DataManager.Instance.HeroMaxMorale, 1, false);
			if (GUIManager.Instance.IsArabic)
			{
				this.MoraleString.AppendFormat("{1}/{0}");
			}
			else
			{
				this.MoraleString.AppendFormat("{0}/{1}");
			}
		}
		this.m_MoraleText.text = this.MoraleString.ToString();
		this.m_MoraleText.SetAllDirty();
		this.m_MoraleText.cachedTextGenerator.Invalidate();
		this.CheckMonsterPoint();
	}

	// Token: 0x06000CD8 RID: 3288 RVA: 0x00130198 File Offset: 0x0012E398
	private void UpdateResource()
	{
		uint num = 0u;
		uint num2 = 4200000000u;
		for (int i = 0; i < this.m_ResourceBar.Length; i++)
		{
			switch (i)
			{
			case 0:
				num = this.DM.Resource[0].Stock;
				num2 = this.DM.Resource[0].Capacity;
				break;
			case 1:
				num = this.DM.Resource[1].Stock;
				num2 = this.DM.Resource[1].Capacity;
				break;
			case 2:
				num = this.DM.Resource[2].Stock;
				num2 = this.DM.Resource[2].Capacity;
				break;
			case 3:
				num = this.DM.Resource[3].Stock;
				num2 = this.DM.Resource[3].Capacity;
				break;
			case 4:
				num = this.DM.Resource[4].Stock;
				num2 = this.DM.Resource[4].Capacity;
				break;
			}
			this.m_ResourceBar[i].fillAmount = num / num2;
			if (num >= num2)
			{
				this.m_ResourceColor[i] = this.ResourceSColor;
			}
			else
			{
				this.m_ResourceColor[i] = Color.white;
			}
			if (i != 0 || this.DM.Resource[0].GetSpeed() >= 0L)
			{
				this.m_ResourceText[i].color = this.m_ResourceColor[i];
			}
			this.m_ResourceStr[i].Length = 0;
			GameConstants.FormatResourceValue(this.m_ResourceStr[i], num);
			this.m_ResourceText[i].text = this.m_ResourceStr[i].ToString();
			this.m_ResourceText[i].SetAllDirty();
			this.m_ResourceText[i].cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06000CD9 RID: 3289 RVA: 0x001303A0 File Offset: 0x0012E5A0
	private void UpdateQueue()
	{
		Vector2 vector = Vector2.zero;
		this.m_QueueCount = this.DM.curQueueBarDataCount;
		for (int i = (int)this.m_QueueCount; i < this.m_QueueTimeBar.Length; i++)
		{
			if (this.m_QueueTimeBar[i].gameObject.activeSelf)
			{
				this.m_QueueTimeBar[i].gameObject.SetActive(false);
			}
			if (this.m_QueueTimeBar[i].m_ListID != 0)
			{
				this.GM.RemoverTimeBaarToList(this.m_QueueTimeBar[i]);
			}
		}
		QueueBarData queueBarData = DataManager.Instance.queueBarData[17];
		if ((this.m_QueueCount <= 1 && queueBarData.bActive) || this.m_QueueCount == 0)
		{
			this.QueuePanelSetActive(false);
			if (this.m_QueueCount > 0)
			{
				this.m_QueueButton.gameObject.SetActive(true);
				this.m_QueueIcon.gameObject.SetActive(true);
				this.m_QueueIcon.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
				vector = this.m_QueueIcon.rectTransform.anchoredPosition;
				vector.x = 24f;
				this.m_QueueIcon.rectTransform.anchoredPosition = vector;
			}
			else
			{
				this.m_QueueButton.gameObject.SetActive(false);
				this.m_QueueIcon.gameObject.SetActive(false);
				this.m_QueueIcon.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
				vector = this.m_QueueIcon.rectTransform.anchoredPosition;
				vector.x = 36.6f;
				this.m_QueueIcon.rectTransform.anchoredPosition = vector;
			}
			this.m_QueueCountBox.gameObject.SetActive(false);
		}
		else
		{
			int num;
			if (queueBarData.bActive)
			{
				num = (int)(this.m_QueueCount - 1);
			}
			else
			{
				num = (int)this.m_QueueCount;
			}
			StringManager.IntToStr(this.m_QueueCountStr, (long)num, 1, false);
			this.m_QueueCountText.text = this.m_QueueCountStr.ToString();
			this.m_QueueCountText.SetAllDirty();
			this.m_QueueCountText.cachedTextGenerator.Invalidate();
			vector.Set(Door.GetRedBackWidth(this.m_QueueCountText.preferredWidth), 51f);
			this.m_QueueCountBox.sizeDelta = vector;
			this.m_QueueButton.gameObject.SetActive(true);
			this.m_QueueIcon.gameObject.SetActive(true);
			if (!this.m_QueuePanel.gameObject.activeSelf)
			{
				this.m_QueueCountBox.gameObject.SetActive(true);
			}
			else
			{
				this.m_QueueCountBox.gameObject.SetActive(false);
			}
		}
		StringBuilder sb = new StringBuilder();
		string empty = string.Empty;
		string empty2 = string.Empty;
		bool flag = false;
		int num2 = 0;
		while (num2 < (int)this.m_QueueCount && num2 < this.m_QueueTimeBar.Length)
		{
			byte b = this.DM.sortedQueueBarData[num2];
			QueueBarData queueBarData2 = this.DM.queueBarData[(int)b];
			if (num2 == 0)
			{
				this.CheckSpQueueBar();
			}
			else
			{
				this.m_QueueTimeBar[num2].gameObject.SetActive(true);
			}
			if (queueBarData2.eKind == EQueueBarKind.Idle)
			{
				this.m_QueueTimeBar[num2].m_TimeBarID = (int)b;
				this.m_QueueTimeBar[num2].m_FuntionBtn.gameObject.SetActive(false);
				this.m_QueueTimeBar[num2].m_TimeText.enabled = false;
				this.m_QueueTimeBar[num2].SetValue(0L, 0L);
				this.m_QueueTimeBar[num2].m_SliderImage.fillAmount = 0f;
				this.m_QueueTimeBar[num2].m_TitleText.color = Color.yellow;
				if (queueBarData2.StartTime == 1L)
				{
					this.m_QueueTimeBar[num2].m_Titles[0] = this.DM.mStringTable.GetStringByID(782u);
					this.m_QueueTimeBar[num2].m_Titles[1] = this.DM.mStringTable.GetStringByID(782u);
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon001");
				}
				else if (queueBarData2.StartTime == 2L)
				{
					this.m_QueueTimeBar[num2].m_Titles[0] = this.DM.mStringTable.GetStringByID(783u);
					this.m_QueueTimeBar[num2].m_Titles[1] = this.DM.mStringTable.GetStringByID(783u);
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon015");
				}
				else if (queueBarData2.StartTime == 3L)
				{
					this.m_QueueTimeBar[num2].m_Titles[0] = this.DM.mStringTable.GetStringByID(784u);
					this.m_QueueTimeBar[num2].m_Titles[1] = this.DM.mStringTable.GetStringByID(784u);
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon001");
				}
				else
				{
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon001");
				}
				this.m_QueueTimeBar[num2].SetTitleText();
				eTimerSpriteType queueBarSpriteType = this.DM.GetQueueBarSpriteType((EQueueBarIndex)b);
				this.GM.SetTimerSpriteType(this.m_QueueTimeBar[num2], queueBarSpriteType);
			}
			else
			{
				this.m_QueueTimeBar[num2].m_FuntionBtn.gameObject.SetActive(true);
				this.m_QueueTimeBar[num2].m_TimeText.enabled = true;
				this.m_QueueTimeBar[num2].m_TitleText.color = Color.white;
				eTimerSpriteType queueBarSpriteType2 = this.DM.GetQueueBarSpriteType((EQueueBarIndex)b);
				this.DM.GetQueueBarTitle((EQueueBarIndex)b, sb, ref empty, ref empty2);
				if (queueBarSpriteType2 == eTimerSpriteType.RallyAttack || queueBarSpriteType2 == eTimerSpriteType.RallyMarching || queueBarSpriteType2 == eTimerSpriteType.RallyStanby)
				{
					if (DataManager.Instance.ServerTime > queueBarData2.StartTime + (long)((ulong)queueBarData2.TotalTime))
					{
						this.GM.SetTimerBar(this.m_QueueTimeBar[num2], queueBarData2.StartTime, queueBarData2.StartTime + (long)((ulong)queueBarData2.TotalTime), 0L, eTimeBarType.IconType, empty, empty2);
					}
					else
					{
						this.GM.SetTimerBar(this.m_QueueTimeBar[num2], queueBarData2.StartTime, queueBarData2.StartTime + (long)((ulong)queueBarData2.TotalTime), queueBarData2.StartTime + (long)((ulong)queueBarData2.TotalTime) - 1L, eTimeBarType.IconType, empty, empty2);
					}
				}
				else if (queueBarSpriteType2 == eTimerSpriteType.RallyCountDown)
				{
					if (DataManager.Instance.ServerTime > queueBarData2.StartTime + (long)((ulong)queueBarData2.TotalTime))
					{
						this.GM.SetTimerBar(this.m_QueueTimeBar[num2], queueBarData2.StartTime, queueBarData2.StartTime + (long)((ulong)queueBarData2.TotalTime), 0L, eTimeBarType.IconType, empty, empty2);
					}
					else
					{
						this.GM.SetTimerBar(this.m_QueueTimeBar[num2], queueBarData2.StartTime, queueBarData2.StartTime + (long)((ulong)queueBarData2.TotalTime), queueBarData2.StartTime + (long)((ulong)queueBarData2.TotalTime) - 1L, eTimeBarType.IconType, empty, empty2);
					}
				}
				else if (queueBarSpriteType2 == eTimerSpriteType.Free || DataManager.Instance.ServerTime > queueBarData2.StartTime + (long)((ulong)queueBarData2.TotalTime) - (long)this.DM.FreeCompletePeriod)
				{
					this.GM.SetTimerBar(this.m_QueueTimeBar[num2], queueBarData2.StartTime, queueBarData2.StartTime + (long)((ulong)queueBarData2.TotalTime), 0L, eTimeBarType.IconType, empty, empty2);
				}
				else
				{
					this.GM.SetTimerBar(this.m_QueueTimeBar[num2], queueBarData2.StartTime, queueBarData2.StartTime + (long)((ulong)queueBarData2.TotalTime), queueBarData2.StartTime + (long)((ulong)queueBarData2.TotalTime) - (long)this.DM.FreeCompletePeriod, eTimeBarType.IconType, empty, empty2);
				}
				if (queueBarSpriteType2 == eTimerSpriteType.Mobilization_fail || queueBarSpriteType2 == eTimerSpriteType.Mobilization_Report)
				{
					this.m_QueueTimeBar[num2].m_TimeText.enabled = false;
					this.m_QueueTimeBar[num2].SetValue(0L, 0L);
					this.m_QueueTimeBar[num2].m_SliderImage.fillAmount = 0f;
				}
				if (queueBarSpriteType2 == eTimerSpriteType.NPCRewardEnd)
				{
					this.m_QueueTimeBar[num2].m_TimeText.enabled = false;
				}
				this.m_QueueTimeBar[num2].m_TimeBarID = (int)b;
				bool flag2 = this.m_QueueTimeBar[num2].m_TimerSpriteType == eTimerSpriteType.Free;
				this.GM.SetTimerSpriteType(this.m_QueueTimeBar[num2], queueBarSpriteType2);
				if (this.DM.MySysSetting.bShowTimeBar && !flag && !this.DM.bBeginReLogin && ((!flag2 && queueBarSpriteType2 == eTimerSpriteType.Free) || this.DM.bNewQueue))
				{
					flag = true;
					this.DM.bNewQueue = false;
				}
				switch (queueBarData2.eKind)
				{
				case EQueueBarKind.Building:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon001");
					if (NewbieManager.IsTeachWorking(ETeachKind.TURBO))
					{
						NewbieManager.CheckTeach(ETeachKind.TURBO, this.m_QueueTimeBar[num2], false);
					}
					goto IL_DBC;
				case EQueueBarKind.Researching:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon015");
					goto IL_DBC;
				case EQueueBarKind.Marching:
				{
					int num3 = (int)(b - 2);
					if (num3 < this.DM.MarchEventData.Length && num3 >= 0)
					{
						if (DataManager.Instance.MarchEventData[num3].Type == EMarchEventType.EMET_RallyStanby)
						{
							this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon018");
						}
						else if (GameConstants.IsMarchDeparture(this.DM.MarchEventData[num3].Type))
						{
							this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon016");
						}
						else if (GameConstants.IsMarchReturnOrRetreat(this.DM.MarchEventData[num3].Type))
						{
							this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon017");
						}
						else
						{
							this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon016");
						}
					}
					else
					{
						this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon016");
					}
					goto IL_DBC;
				}
				case EQueueBarKind.Training:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon002");
					goto IL_DBC;
				case EQueueBarKind.HeroEnhance:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon009");
					goto IL_DBC;
				case EQueueBarKind.HeroEvolution:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon010");
					goto IL_DBC;
				case EQueueBarKind.Treatmenting:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon003");
					goto IL_DBC;
				case EQueueBarKind.Manufacturing:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon004");
					goto IL_DBC;
				case EQueueBarKind.WallRepair:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon011");
					goto IL_DBC;
				case EQueueBarKind.Mission:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon014");
					goto IL_DBC;
				case EQueueBarKind.Forging:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon013");
					goto IL_DBC;
				case EQueueBarKind.JoinedRally:
				{
					int num3 = (int)(b - 22);
					if (num3 < this.DM.MarchEventData.Length && num3 >= 0)
					{
						if (DataManager.Instance.MarchEventData[num3].Type == EMarchEventType.EMET_RallyReturn || DataManager.Instance.MarchEventData[num3].Type == EMarchEventType.EMET_RallyRetreat || DataManager.Instance.MarchEventData[num3].Type == EMarchEventType.EMET_RallyAttack)
						{
							this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon016");
						}
						else
						{
							this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon018");
						}
					}
					else
					{
						this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon016");
					}
					goto IL_DBC;
				}
				case EQueueBarKind.LordReturn:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon017");
					goto IL_DBC;
				case EQueueBarKind.HideArmy:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon016");
					goto IL_DBC;
				case EQueueBarKind.Mobilization:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("UI_mall_box_a_02");
					goto IL_DBC;
				case EQueueBarKind.NpcReward:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon049");
					goto IL_DBC;
				case EQueueBarKind.PetFusion:
					if (DataManager.Instance.FusionDataTable.GetRecordByKey(PetManager.Instance.ItemCraftID).Fusion_Kind == 0)
					{
						this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon051");
					}
					else
					{
						this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon057");
					}
					goto IL_DBC;
				case EQueueBarKind.PetEvolution:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon054");
					goto IL_DBC;
				case EQueueBarKind.PetMarch:
					this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("icon054");
					goto IL_DBC;
				}
				this.m_QueueTimeBarIcon[num2].sprite = this.LoadSprite("UI_main_res_house");
			}
			IL_DBC:
			this.m_QueueTimeBarIcon[num2].SetNativeSize();
			this.m_QueueTimeBarIcon[num2].rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
			this.m_QueueTimeBar[num2].SetFlashCount(1f, this.m_QueueTimeBar[num2].GetTextIndex());
			num2++;
		}
		if (flag)
		{
			this.ForceQueueBarOpenClose(flag);
		}
	}

	// Token: 0x06000CDA RID: 3290 RVA: 0x001311F0 File Offset: 0x0012F3F0
	private void UpdateMissionInfo()
	{
		if (this.m_MissionHintTrans == null)
		{
			return;
		}
		this.m_MissionHintTrans.gameObject.SetActive(DataManager.Instance.MySysSetting.bShowMission);
		if (!this.m_MissionHintTrans.gameObject.activeSelf)
		{
			return;
		}
		MissionManager missionDataManager = DataManager.MissionDataManager;
		ushort num = missionDataManager.GetReCommandMissionID();
		if (this.m_eMapMode != EUIOriginMapMode.OriginMap || (missionDataManager.RewardList.Priority.Count == 0 && num == 65535))
		{
			this.m_MissionHintTrans.gameObject.SetActive(false);
			return;
		}
		this.m_MissionHintTrans.gameObject.SetActive(true);
		ManorAimTbl recordByKey = missionDataManager.ManorAimTable.GetRecordByKey(num);
		if (missionDataManager.GetRewardCount(1) > 0 && (num == 65535 || recordByKey.UIPriority > missionDataManager.RewardList.Priority[0]))
		{
			this.m_MissionHintSA.SetSpriteIndex(1);
			num = missionDataManager.GetMissionID(missionDataManager.RewardList.Priority[0]);
			recordByKey = missionDataManager.ManorAimTable.GetRecordByKey(num);
			this.m_MissionHinttextL.text = DataManager.Instance.mStringTable.GetStringByID(1520u);
			this.m_MissionBtn.m_BtnID2 = 1;
			this.NewMissionReward.enabled = true;
			this.m_MissionBtn.enabled = true;
			this.RewardTime = 0f;
		}
		else
		{
			this.m_MissionBtn.m_BtnID2 = 0;
			this.NewMissionReward.enabled = false;
			num = missionDataManager.GetReCommandMissionID();
			recordByKey = missionDataManager.ManorAimTable.GetRecordByKey(num);
			eMissionKind eMissionKind = (eMissionKind)(recordByKey.MissionKind - 1);
			eMissionKind eMissionKind2 = eMissionKind;
			if (eMissionKind2 != eMissionKind.Record)
			{
				if (eMissionKind2 != eMissionKind.Mark)
				{
					this.m_MissionHinttextL.text = DataManager.Instance.mStringTable.GetStringByID(834u);
					this.m_MissionHintSA.SetSpriteIndex(2);
					this.m_MissionBtn.enabled = true;
				}
				else if (recordByKey.Parm1 == 131 || recordByKey.Parm1 == 132)
				{
					this.m_MissionHinttextL.text = DataManager.Instance.mStringTable.GetStringByID(834u);
					this.m_MissionHintSA.SetSpriteIndex(2);
					this.m_MissionBtn.enabled = true;
				}
				else
				{
					this.m_MissionHinttextL.text = DataManager.Instance.mStringTable.GetStringByID(1519u);
					this.m_MissionHintSA.SetSpriteIndex(0);
					this.m_MissionBtn.enabled = false;
				}
			}
			else if ((recordByKey.Parm1 >= 21 && recordByKey.Parm1 <= 27) || recordByKey.Parm1 == 7 || recordByKey.Parm1 == 19)
			{
				this.m_MissionHinttextL.text = DataManager.Instance.mStringTable.GetStringByID(834u);
				this.m_MissionHintSA.SetSpriteIndex(2);
				this.m_MissionBtn.enabled = true;
			}
			else
			{
				this.m_MissionHinttextL.text = DataManager.Instance.mStringTable.GetStringByID(1519u);
				this.m_MissionHintSA.SetSpriteIndex(0);
				this.m_MissionBtn.enabled = false;
			}
		}
		this.m_MissionScale.enabled = this.m_MissionBtn.enabled;
		this.m_MissionBtn.m_BtnID3 = (int)num;
		missionDataManager.GetNarrative(this.m_MissionHintStrR, ref recordByKey);
		this.m_MissionHinttextR.text = this.m_MissionHintStrR.ToString();
		this.m_MissionHinttextR.SetAllDirty();
		this.m_MissionHinttextR.cachedTextGenerator.Invalidate();
		this.m_MissionHinttextR.cachedTextGeneratorForLayout.Invalidate();
		Vector2 vector = this.m_MissionHintRRC.sizeDelta;
		bool flag = false;
		float preferredWidth = this.m_MissionHinttextR.preferredWidth;
		if (GUIManager.Instance.IsArabic)
		{
			while (preferredWidth > 385f)
			{
				flag = true;
				this.m_MissionHintStrR.Substring(this.m_MissionHintStrR.ToString(), 0, this.m_MissionHintStrR.Length - 2);
				this.m_MissionHinttextR.text = this.m_MissionHintStrR.ToString();
				this.m_MissionHinttextR.SetAllDirty();
				this.m_MissionHinttextR.cachedTextGenerator.Invalidate();
				this.m_MissionHinttextR.cachedTextGeneratorForLayout.Invalidate();
				preferredWidth = this.m_MissionHinttextR.preferredWidth;
			}
		}
		else
		{
			int num2 = 0;
			while (preferredWidth > 385f)
			{
				this.m_MissionHintStrR.Substring(this.m_MissionHintStrR.ToString(), 0, this.m_MissionHintStrR.Length - 2);
				this.m_MissionHinttextR.text = this.m_MissionHintStrR.ToString();
				this.m_MissionHinttextR.SetLayoutDirty();
				this.m_MissionHinttextR.cachedTextGeneratorForLayout.Invalidate();
				preferredWidth = this.m_MissionHinttextR.preferredWidth;
				flag = true;
				num2++;
			}
			Debug.Log("Loop = " + num2);
		}
		if (flag)
		{
			this.m_MissionHintStrR.Append("...");
			this.m_MissionHinttextR.text = this.m_MissionHintStrR.ToString();
			this.m_MissionHinttextR.SetAllDirty();
			this.m_MissionHinttextR.cachedTextGenerator.Invalidate();
		}
		vector.x = 140f + preferredWidth;
		this.m_MissionHintRRC.sizeDelta = vector;
		vector = this.m_MissionHintRRC.anchoredPosition;
		vector.x = this.m_MissionHintRRC.sizeDelta.x - 712f;
		this.m_MissionHintRRC.anchoredPosition = vector;
	}

	// Token: 0x06000CDB RID: 3291 RVA: 0x00131794 File Offset: 0x0012F994
	public void OnTimer(UITimeBar sender)
	{
	}

	// Token: 0x06000CDC RID: 3292 RVA: 0x00131798 File Offset: 0x0012F998
	public void OnNotify(UITimeBar sender)
	{
		DataManager.Instance.bNeedSortQueueBarData = true;
	}

	// Token: 0x06000CDD RID: 3293 RVA: 0x001317A8 File Offset: 0x0012F9A8
	public void Onfunc(UITimeBar sender)
	{
		eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType((EQueueBarIndex)sender.m_TimeBarID);
		if (sender.m_TimeBarID == 0)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 0, false);
			}
			else if (queueBarSpriteType == eTimerSpriteType.Free)
			{
				GUIManager.Instance.BuildingData.sendBuildCompleteFree();
			}
			else if (queueBarSpriteType == eTimerSpriteType.Help)
			{
				DataManager.Instance.SendAllianceHelp(1);
			}
		}
		else if (sender.m_TimeBarID == 1)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 1, false);
			}
			else if (queueBarSpriteType == eTimerSpriteType.Free)
			{
				DataManager.Instance.sendTechnologyCompleteFree();
			}
			else if (queueBarSpriteType == eTimerSpriteType.Help)
			{
				DataManager.Instance.SendAllianceHelp(0);
			}
		}
		else if (sender.m_TimeBarID >= 2 && sender.m_TimeBarID <= 9)
		{
			int num = Mathf.Clamp(sender.m_TimeBarID - 2, 0, 7);
			if (DataManager.Instance.MarchEventData[num].Type == EMarchEventType.EMET_RallyStanby)
			{
				this.OpenMenu(EGUIWindow.UI_Rally, 100, num, false);
			}
			else
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, sender.m_TimeBarID, false);
			}
		}
		else if (sender.m_TimeBarID >= 22 && sender.m_TimeBarID <= 29)
		{
			int arg = Mathf.Clamp(sender.m_TimeBarID - 22, 0, 7);
			this.OpenMenu(EGUIWindow.UI_Rally, 100, arg, false);
		}
		else if (sender.m_TimeBarID == 10)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 10, false);
			}
		}
		else if (sender.m_TimeBarID == 11)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 11, false);
			}
			else if (queueBarSpriteType == eTimerSpriteType.Free)
			{
				DataManager.Instance.SendHeroEnhance_Free();
			}
		}
		else if (sender.m_TimeBarID == 12)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 12, false);
			}
			else if (queueBarSpriteType == eTimerSpriteType.Free)
			{
				DataManager.Instance.SendHeroStarUp_Free();
			}
		}
		else if (sender.m_TimeBarID == 16)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 16, false);
			}
			else if (queueBarSpriteType == eTimerSpriteType.Free)
			{
				DataManager.Instance.SendHeroStarUp_Free();
			}
		}
		else if (sender.m_TimeBarID == 14)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 14, false);
			}
		}
		else if (sender.m_TimeBarID == 13)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 13, false);
			}
		}
		else if (sender.m_TimeBarID == 15)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 15, false);
			}
		}
		else if (sender.m_TimeBarID == 19)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 19, false);
			}
		}
		else if (sender.m_TimeBarID == 20)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 20, false);
			}
		}
		else if (sender.m_TimeBarID == 18)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 18, false);
			}
		}
		else if (sender.m_TimeBarID == 30)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 30, false);
			}
		}
		else if (sender.m_TimeBarID == 21)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 21, false);
			}
		}
		else if (sender.m_TimeBarID == 31)
		{
			HideArmyManager.Instance.OpenHideArmyUI();
		}
		else if (sender.m_TimeBarID == 32)
		{
			this.OpenMenu(EGUIWindow.UI_Alliance_Mobilization, 0, 0, false);
		}
		else if (sender.m_TimeBarID == 33)
		{
			this.OpenMenu(EGUIWindow.UIAlchemy, 0, 0, true);
		}
		else if (sender.m_TimeBarID == 34)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 34, false);
			}
		}
		else if (sender.m_TimeBarID == 35)
		{
			if (queueBarSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 35, false);
			}
			else if (queueBarSpriteType == eTimerSpriteType.Free)
			{
				PetManager.Instance.Send_PET_STARUP_FREECOMPLETE();
			}
		}
		else if (sender.m_TimeBarID == 36)
		{
			this.GoToGroup(9, 0, true);
		}
	}

	// Token: 0x06000CDE RID: 3294 RVA: 0x00131BE8 File Offset: 0x0012FDE8
	public void OnCancel(UITimeBar sender)
	{
	}

	// Token: 0x06000CDF RID: 3295 RVA: 0x00131BEC File Offset: 0x0012FDEC
	public void CheckandShowFuncBtnCount(int tmpIndex, bool bShow = false)
	{
		if (tmpIndex == -1)
		{
			bool flag = false;
			if (this.m_MissionAlert.activeSelf || this.CheckShowRedPocket() || this.CheckShowLiveImg() || this.CheckShowLiveAlert())
			{
				flag = true;
			}
			int num = 0;
			while (num < 6 && !flag)
			{
				if (this.m_FuncBtnCount[num] > 0)
				{
					flag = true;
				}
				num++;
			}
			if (this.m_bShowFuncButton == 0 && flag)
			{
				if (this.m_ShowFuncButton.activeInHierarchy && (!this.m_ShowFuncButtonAlert.activeInHierarchy || !this.SPGiftImgMain.gameObject.activeInHierarchy || !this.LiveImgMain.gameObject.activeInHierarchy))
				{
					if (this.CheckShowRedPocket())
					{
						this.LiveImgMain.gameObject.SetActive(false);
						this.m_ShowFuncButtonAlert.SetActive(false);
						this.SetSPGiftImgSprite(true);
						this.SPGiftImgMain.gameObject.SetActive(true);
					}
					else
					{
						this.SPGiftImgMain.gameObject.SetActive(false);
						if (this.CheckShowLiveImg())
						{
							this.m_ShowFuncButtonAlert.SetActive(false);
							if (GUIManager.Instance.StopShowLiveScale > 0)
							{
								this.LiveImgMainTW.enabled = false;
								this.LiveImgMainTW.SetCurrentValueToStart();
								this.LiveImgMainTWF.enabled = false;
								this.LiveImgMainTWF.SetCurrentValueToStart();
							}
							else
							{
								this.LiveImgMainTW.enabled = true;
								this.LiveImgMainTWF.enabled = true;
							}
							this.LiveImgMain.gameObject.SetActive(true);
						}
						else
						{
							this.LiveImgMain.gameObject.SetActive(false);
							this.m_ShowFuncButtonAlert.SetActive(true);
						}
					}
				}
			}
			else
			{
				if (this.m_ShowFuncButtonAlert.activeSelf)
				{
					this.m_ShowFuncButtonAlert.SetActive(false);
				}
				if (this.SPGiftImgMain.gameObject.activeSelf)
				{
					this.SPGiftImgMain.gameObject.SetActive(false);
				}
				if (this.LiveImgMain.gameObject.activeSelf)
				{
					this.LiveImgMain.gameObject.SetActive(false);
				}
			}
		}
		else
		{
			if (tmpIndex < 0 || tmpIndex >= 6)
			{
				return;
			}
			bool activeInHierarchy = this.m_FuncBtnCountRC[tmpIndex].gameObject.activeInHierarchy;
			if (bShow)
			{
				if (this.m_FuncBtnCount[tmpIndex] > 0 && !activeInHierarchy)
				{
					this.m_FuncBtnCountRC[tmpIndex].gameObject.SetActive(true);
				}
			}
			else if (activeInHierarchy)
			{
				this.m_FuncBtnCountRC[tmpIndex].gameObject.SetActive(true);
			}
		}
	}

	// Token: 0x06000CE0 RID: 3296 RVA: 0x00131E94 File Offset: 0x00130094
	public void CheckShowMissionFlash()
	{
		if (DataManager.MissionDataManager.AllianceMissionBonusRate > 100)
		{
			this.m_MissionFlash.SetActive(true);
		}
		else
		{
			this.m_MissionFlash.SetActive(false);
		}
	}

	// Token: 0x06000CE1 RID: 3297 RVA: 0x00131ED0 File Offset: 0x001300D0
	public void SetPVPWonderID(ushort WonderID)
	{
		if (WonderID < 40 && DataManager.MapDataController.YolkPointTable[(int)WonderID].WonderState > 0 && DataManager.MapDataController.YolkPointTable[(int)WonderID].WonderState != 255)
		{
			this.PVPWonderID = WonderID;
			this.ShowPVPTime(false);
		}
		else
		{
			this.ClearPVPWonderID();
		}
	}

	// Token: 0x06000CE2 RID: 3298 RVA: 0x00131F38 File Offset: 0x00130138
	public void ClearPVPWonderID()
	{
		this.PVPWonderID = 40;
		this.HidePVPTime();
	}

	// Token: 0x06000CE3 RID: 3299 RVA: 0x00131F48 File Offset: 0x00130148
	public void ShowPVPTime(bool Force = false)
	{
		if ((this.bHideMainMenu || Force) && this.PVPWonderID != 40)
		{
			this.PVPTimeObj.SetActive(true);
			this.SetPVPObj();
			this.LoadPVPImage();
			this.UpdatePVPTime();
		}
	}

	// Token: 0x06000CE4 RID: 3300 RVA: 0x00131F94 File Offset: 0x00130194
	public void HidePVPTime()
	{
		if (this.PVPTimeObj == null)
		{
			return;
		}
		this.PVPTimeObj.SetActive(false);
	}

	// Token: 0x06000CE5 RID: 3301 RVA: 0x00131FB4 File Offset: 0x001301B4
	public void LoadPVPImage()
	{
		if (this.TileMapController != null)
		{
			this.PVPWonderImg.sprite = this.TileMapController.yolk.getMapTileYolkSprite((byte)this.PVPWonderID);
			Material mapTileYolkMaterial = this.TileMapController.yolk.getMapTileYolkMaterial((byte)this.PVPWonderID);
			if (mapTileYolkMaterial == null || this.PVPWonderImg.sprite == null)
			{
				this.PVPWonderImg.enabled = false;
			}
			else
			{
				this.PVPWonderImg.rectTransform.sizeDelta = new Vector2(this.PVPWonderImg.sprite.rect.width, this.PVPWonderImg.sprite.rect.height);
				if (this.PVPWonderImgMaterial == null)
				{
					this.PVPWonderImgMaterial = new Material(mapTileYolkMaterial);
					this.PVPWonderImgMaterial.renderQueue = 3000;
				}
				else
				{
					this.PVPWonderImgMaterial.SetTexture("_AlphaTex", mapTileYolkMaterial.GetTexture("_AlphaTex"));
				}
				this.PVPWonderImg.material = this.PVPWonderImgMaterial;
				this.PVPWonderImg.enabled = true;
			}
		}
		else
		{
			this.PVPWonderImg.enabled = false;
		}
	}

	// Token: 0x06000CE6 RID: 3302 RVA: 0x00132100 File Offset: 0x00130300
	public void UpdatePVPTime()
	{
		if (this.PVPWonderID >= 40)
		{
			return;
		}
		long num = (long)(DataManager.MapDataController.YolkPointTable[(int)this.PVPWonderID].StateBegin + (ulong)DataManager.MapDataController.YolkPointTable[(int)this.PVPWonderID].StateDuring - (ulong)DataManager.Instance.ServerTime);
		if (num < 0L)
		{
			this.ClearPVPWonderID();
			return;
		}
		if (!this.PVPWonderImg.enabled)
		{
			this.LoadPVPImage();
		}
		this.PVPStr.Length = 0;
		GameConstants.GetTimeString(this.PVPStr, (uint)num, false, false, true, false, true);
		this.PVPTimeText.text = this.PVPStr.ToString();
		this.PVPTimeText.SetAllDirty();
		this.PVPTimeText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000CE7 RID: 3303 RVA: 0x001321D4 File Offset: 0x001303D4
	public void ShowKVKTime(bool Force = false)
	{
		if (this.KVKTimeObj == null)
		{
			return;
		}
		ActivityManager instance = ActivityManager.Instance;
		MapManager mapDataController = DataManager.MapDataController;
		ActivityDataType activityDataType = instance.KvKActivityData[4];
		if ((this.bHideMainMenu || Force) && instance.KVKHuntCircleMin != 0 && instance.IsInKvK(0, true) && instance.IsMatchKvk() && (this.m_eMapMode == EUIOriginMapMode.WorldMap || mapDataController.IsEnemy(mapDataController.FocusKingdomID) || mapDataController.kingdomData.kingdomID == mapDataController.FocusKingdomID) && instance.KVKReTime < activityDataType.EventBeginTime + (long)((ulong)activityDataType.EventReqiureTIme))
		{
			this.KVKTimeObj.SetActive(true);
			this.SetPVPObj();
			this.UpdateKVKTime();
		}
		else
		{
			this.HideKVKTime();
		}
	}

	// Token: 0x06000CE8 RID: 3304 RVA: 0x001322AC File Offset: 0x001304AC
	public void HideKVKTime()
	{
		if (this.KVKTimeObj == null)
		{
			return;
		}
		this.KVKTimeObj.SetActive(false);
		this.SetPVPObj();
	}

	// Token: 0x06000CE9 RID: 3305 RVA: 0x001322E0 File Offset: 0x001304E0
	public void UpdateKVKTime()
	{
		if (this.KVKTimeObj == null || !this.KVKTimeObj.activeInHierarchy)
		{
			return;
		}
		long num = ActivityManager.Instance.KVKReTime - ActivityManager.Instance.ServerEventTime;
		if (num < 0L)
		{
			num = 0L;
		}
		this.KVKStr.Length = 0;
		GameConstants.GetTimeString(this.KVKStr, (uint)num, false, false, true, false, true);
		this.KVKTimeText.text = this.KVKStr.ToString();
		this.KVKTimeText.SetAllDirty();
		this.KVKTimeText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000CEA RID: 3306 RVA: 0x00132380 File Offset: 0x00130580
	public void ShowFIFATime(bool Force = false)
	{
		if (this.FIFATimeObj == null)
		{
			return;
		}
		ActivityManager instance = ActivityManager.Instance;
		MapManager mapDataController = DataManager.MapDataController;
		ActivityDataType activityDataType = instance.FIFAData[2];
		ushort kingdomID;
		if (DataManager.MapDataController.FocusKingdomID != 0)
		{
			kingdomID = DataManager.MapDataController.FocusKingdomID;
		}
		else
		{
			kingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
		}
		bool flag = ActivityManager.Instance.IsInKvK(0, false);
		if ((this.bHideMainMenu || Force) && instance.NowWaveEndTime != 0L && instance.IsInFIFA(0, true) && this.m_eMapMode == EUIOriginMapMode.KingdomMap && instance.NowWaveEndTime <= activityDataType.EventBeginTime + (long)((ulong)activityDataType.EventReqiureTIme) && (!flag || (flag && instance.IsMatchKvk_kingdom(kingdomID))))
		{
			this.FIFATimeObj.SetActive(true);
			this.SetPVPObj();
			this.UpdateFIFATime();
			if (!Force || this.bHideMainByFIFA)
			{
				this.SetSpecialTimeCG(1f);
			}
		}
		else
		{
			this.HideFIFATime();
		}
	}

	// Token: 0x06000CEB RID: 3307 RVA: 0x0013249C File Offset: 0x0013069C
	public void HideFIFATime()
	{
		if (this.FIFATimeObj == null)
		{
			return;
		}
		this.FIFATimeObj.SetActive(false);
		this.SetPVPObj();
		this.SetSpecialTimeCG(1f);
	}

	// Token: 0x06000CEC RID: 3308 RVA: 0x001324D0 File Offset: 0x001306D0
	public void UpdateFIFATime()
	{
		if (this.FIFATimeObj == null || !this.FIFATimeObj.activeInHierarchy)
		{
			return;
		}
		long num = ActivityManager.Instance.NowWaveEndTime - ActivityManager.Instance.ServerEventTime;
		if (num < 0L)
		{
			num = 0L;
		}
		this.FIFAStr.Length = 0;
		GameConstants.GetTimeString(this.FIFAStr, (uint)num, false, false, true, false, true);
		this.FIFATimeText.text = this.FIFAStr.ToString();
		this.FIFATimeText.SetAllDirty();
		this.FIFATimeText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000CED RID: 3309 RVA: 0x00132570 File Offset: 0x00130770
	public void SetPVPObj()
	{
		if (this.PVPTimeObj == null || this.KVKTimeObj == null || this.FIFATimeObj == null)
		{
			return;
		}
		int num = -63;
		int num2 = 0;
		if (this.KVKTimeObj.activeInHierarchy)
		{
			num2++;
		}
		if (this.FIFATimeObj.activeInHierarchy)
		{
			((RectTransform)this.FIFATimeObj.transform).anchoredPosition = new Vector2(11f, (float)(-7 + num2 * num));
			num2++;
		}
		if (this.PVPTimeObj.activeInHierarchy)
		{
			((RectTransform)this.PVPTimeObj.transform).anchoredPosition = new Vector2(11f, (float)(-7 + num2 * num));
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBall, 5, 0);
	}

	// Token: 0x06000CEE RID: 3310 RVA: 0x0013264C File Offset: 0x0013084C
	public void RefreshFuncBtnCount(int tmpIndex = -1, int tmpIndex2 = -1)
	{
		switch (tmpIndex)
		{
		case 0:
			this.m_FuncBtnCount[tmpIndex] = 0;
			if (tmpIndex2 == 0 || tmpIndex2 == -1)
			{
				this.bCanEquip = false;
				this.bCanEvolutionRank = false;
				this.bCanEvolutionStar = false;
				this.bCanRecruit = false;
				uint num = 0u;
				while (num < this.DM.CurHeroDataCount && !this.bCanEquip && !this.bCanEvolutionRank && !this.bCanEvolutionStar)
				{
					uint key = this.DM.sortHeroData[(int)((UIntPtr)num)];
					if (this.DM.curHeroData.ContainsKey(key))
					{
						CurHeroData curHeroData = this.DM.curHeroData[key];
						if (curHeroData.Equip == 63 && curHeroData.Enhance < 8 && this.DM.RoleAttr.EnhanceEventHeroID != curHeroData.ID)
						{
							this.bCanEvolutionRank = true;
							break;
						}
						ushort id = curHeroData.ID;
						Hero recordByKey = this.DM.HeroTable.GetRecordByKey(id);
						ushort curItemQuantity = this.DM.GetCurItemQuantity(recordByKey.SoulStone, 0);
						int num2 = Mathf.Clamp((int)curHeroData.Star, 0, this.DM.Medal.Length - 1);
						if (curHeroData.Star < 5 && curItemQuantity >= (ushort)this.DM.Medal[num2] && this.DM.RoleAttr.StarUpEventHeroID != id)
						{
							this.bCanEvolutionStar = true;
							break;
						}
						ushort num3 = 0;
						int num4 = 0;
						while (num4 < 6 && !this.bCanEquip)
						{
							int num5 = curHeroData.Equip >> num4 & 1;
							Enhance recordByKey2 = this.DM.EnhanceTable.GetRecordByKey(curHeroData.ID);
							if (recordByKey2.EnhanceNumber != null)
							{
								num3 = recordByKey2.EnhanceNumber[(int)((curHeroData.Enhance - 1) * 6) + num4];
							}
							byte needLv = this.DM.EquipTable.GetRecordByKey(num3).NeedLv;
							if (num5 == 0 && this.DM.FindItemComposite(num3, 1) && curHeroData.Level >= needLv)
							{
								this.bCanEquip = true;
							}
							num4++;
						}
					}
					num += 1u;
				}
				ushort[] array = new ushort[]
				{
					10,
					30,
					80,
					180,
					330
				};
				DataManager.Instance.SortCurItemData();
				ushort num6 = DataManager.Instance.sortItemDataStart[4];
				ushort num7 = DataManager.Instance.sortItemDataCount[4];
				int num8 = (int)num6;
				while (num8 < (int)(num7 + num6) && !this.bCanRecruit)
				{
					ushort num9 = DataManager.Instance.sortItemData[num8];
					Equip recordByKey3 = DataManager.Instance.EquipTable.GetRecordByKey(num9);
					if (!DataManager.Instance.curHeroData.ContainsKey((uint)recordByKey3.SyntheticParts[0].SyntheticItem))
					{
						ushort num10 = array[(int)(DataManager.Instance.HeroTable.GetRecordByKey(recordByKey3.SyntheticParts[0].SyntheticItem).defaultStar - 1)];
						ushort curItemQuantity2 = DataManager.Instance.GetCurItemQuantity(num9, 0);
						if (curItemQuantity2 >= num10)
						{
							this.bCanRecruit = true;
							NewbieManager.CheckNewHero();
						}
					}
					num8++;
				}
			}
			if (tmpIndex2 == 1 || tmpIndex2 == -1)
			{
			}
			if (GUIManager.Instance.bOpenHeroBtn && (this.bCanEquip || this.bCanEvolutionStar || this.bCanEvolutionRank || this.bCanShowSkillPoint || this.bCanRecruit))
			{
				this.m_FuncBtnCount[tmpIndex] = 1;
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroList, 0, 0);
			break;
		case 2:
			if (this.CheckShowLiveImg())
			{
				if (GUIManager.Instance.StopShowLiveScale > 0)
				{
					this.LiveImgOtherTW.enabled = false;
					this.LiveImgOtherTW.SetCurrentValueToStart();
					this.LiveImgOtherTWF.enabled = false;
					this.LiveImgOtherTWF.SetCurrentValueToStart();
				}
				else
				{
					this.LiveImgOtherTW.enabled = true;
					this.LiveImgOtherTWF.enabled = true;
				}
				this.LiveImgOther.gameObject.SetActive(true);
				this.m_OtherGift.gameObject.SetActive(false);
			}
			else
			{
				this.LiveImgOther.gameObject.SetActive(false);
				if (!DataManager.Instance.CheckPrizeFlag(2) && IGGGameSDK.Instance.m_IGGLoginType != IGGLoginType.Facebook)
				{
					this.m_OtherGift.gameObject.SetActive(true);
				}
				else
				{
					this.m_OtherGift.gameObject.SetActive(false);
				}
			}
			if (this.CheckShowLiveAlert())
			{
				this.m_OtherAlert.SetActive(true);
			}
			else
			{
				this.m_OtherAlert.SetActive(false);
			}
			this.m_FuncBtnCount[tmpIndex] = 0;
			if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 7)
			{
				this.m_FuncBtnCount[tmpIndex] += (int)DataManager.FBMissionDataManager.GetRewardCount();
			}
			break;
		case 3:
			if (DataManager.Instance.RoleAlliance.Id == 0u && DataManager.Instance.queueBarData[20].bActive)
			{
				DataManager.Instance.SetQueueBarData(EQueueBarIndex.AllianceMission, false, 0L, 0u);
			}
			this.m_FuncBtnCount[tmpIndex] = (int)DataManager.MissionDataManager.GetTotalAccessMissionCount();
			if (DataManager.MissionDataManager.MissionNotice > 0 || DataManager.MissionDataManager.GetRewardCount(1) > 0)
			{
				this.m_MissionAlert.SetActive(true);
			}
			else
			{
				this.m_MissionAlert.SetActive(false);
			}
			this.UpdateMissionInfo();
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 16, 0);
			break;
		case 4:
			this.m_FuncBtnCount[tmpIndex] = (int)DataManager.Instance.GetMailboxUnread(MailType.EMAIL_MAX);
			break;
		case 5:
			this.m_FuncBtnCount[tmpIndex] = 0;
			if (DataManager.Instance.RoleAlliance.Id == 0u)
			{
				this.m_AllianceGift.gameObject.SetActive(false);
				this.m_RallyRecFlash.gameObject.SetActive(false);
				this.SPGiftImgAlly.gameObject.SetActive(false);
			}
			else if (GUIManager.Instance.bOpenAllianceBtn)
			{
				this.m_FuncBtnCount[tmpIndex] = (int)DataManager.Instance.RoleAlliance.GiftNum + DataManager.Instance.mHelpDataList.Count;
				if (DataManager.Instance.RoleAlliance.Rank >= AllianceRank.RANK4)
				{
					this.m_FuncBtnCount[tmpIndex] += (int)DataManager.Instance.RoleAlliance.Applicant;
				}
				if (this.CheckShowRedPocket())
				{
					this.SetSPGiftImgSprite(false);
					this.SPGiftImgAlly.gameObject.SetActive(true);
					this.m_AllianceGift.gameObject.SetActive(false);
					this.m_FuncBtnCount[tmpIndex] += (int)ActivityGiftManager.Instance.EnableRedPocketNum;
				}
				else
				{
					this.SPGiftImgAlly.gameObject.SetActive(false);
					if (DataManager.Instance.RoleAlliance.GiftNum > 0)
					{
						this.m_AllianceGift.gameObject.SetActive(true);
					}
					else
					{
						this.m_AllianceGift.gameObject.SetActive(false);
					}
				}
				this.m_FuncBtnCount[tmpIndex] += (int)(DataManager.Instance.ActiveRallyRecNum + DataManager.Instance.BeingRallyRecNum);
				if (DataManager.Instance.ActiveRallyRecNum > 0u || DataManager.Instance.BeingRallyRecNum > 0u)
				{
					this.m_RallyRecFlash.gameObject.SetActive(true);
				}
				else
				{
					this.m_RallyRecFlash.gameObject.SetActive(false);
				}
				long num11 = DataManager.Instance.RoleAlliance.ChatMax - DataManager.Instance.RoleAlliance.ChatId;
				if (num11 > 0L)
				{
					this.m_FuncBtnCount[tmpIndex] += ((num11 <= 20L) ? ((int)num11) : 20);
				}
			}
			break;
		}
		if (tmpIndex >= 0 && tmpIndex < 6)
		{
			this.SetFuncBtnCount(tmpIndex);
		}
	}

	// Token: 0x06000CEF RID: 3311 RVA: 0x00132E84 File Offset: 0x00131084
	private void SetFuncBtnCount(int tmpIndex)
	{
		if (this.m_FuncBtnCount[tmpIndex] > 0)
		{
			if (tmpIndex != 0)
			{
				this.m_FuncBtnCountStr[tmpIndex].ClearString();
				this.m_FuncBtnCountStr[tmpIndex].IntToFormat((long)this.m_FuncBtnCount[tmpIndex], 1, false);
				this.m_FuncBtnCountStr[tmpIndex].AppendFormat("{0}");
				this.m_FuncBtnText[tmpIndex].text = this.m_FuncBtnCountStr[tmpIndex].ToString();
				this.m_FuncBtnText[tmpIndex].SetAllDirty();
				this.m_FuncBtnText[tmpIndex].cachedTextGenerator.Invalidate();
				this.m_FuncBtnText[tmpIndex].cachedTextGeneratorForLayout.Invalidate();
				this.m_FuncBtnCountRC[tmpIndex].sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_FuncBtnText[tmpIndex].preferredWidth), 51f);
			}
			this.m_FuncBtnCountRC[tmpIndex].gameObject.SetActive(true);
		}
		else
		{
			this.m_FuncBtnCountRC[tmpIndex].gameObject.SetActive(false);
		}
		this.CheckandShowFuncBtnCount(-1, false);
	}

	// Token: 0x06000CF0 RID: 3312 RVA: 0x00132F84 File Offset: 0x00131184
	public void CheckTroopsState()
	{
		int troopsCount = GUIManager.Instance.m_TroopsCount;
		if (troopsCount > 0)
		{
			this.m_TroopsAlertStr.Length = 0;
			this.m_TroopsAlertStr.IntToFormat((long)troopsCount, 1, false);
			this.m_TroopsAlertStr.AppendFormat("{0}");
			this.m_TroopsText.text = this.m_TroopsAlertStr.ToString();
			this.m_TroopsText.SetAllDirty();
			this.m_TroopsText.cachedTextGenerator.Invalidate();
			this.m_TroopsText.cachedTextGeneratorForLayout.Invalidate();
			this.m_TroopsRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_TroopsText.preferredWidth), 51f);
			this.m_TroopsRC.gameObject.SetActive(true);
			this.m_TroopsBtn.gameObject.SetActive(true);
		}
		else
		{
			this.m_TroopsBtn.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000CF1 RID: 3313 RVA: 0x00133070 File Offset: 0x00131270
	public void CheckBuffState()
	{
		int buffListUseCount = DataManager.Instance.m_BuffListUseCount;
		this.m_BuffRC2.gameObject.SetActive(false);
		if (buffListUseCount > 0)
		{
			if (buffListUseCount > 1)
			{
				this.m_BuffAlertStr.Length = 0;
				this.m_BuffAlertStr.IntToFormat((long)buffListUseCount, 1, false);
				this.m_BuffAlertStr.AppendFormat("{0}");
				this.m_BuffText.text = this.m_BuffAlertStr.ToString();
				this.m_BuffText.SetAllDirty();
				this.m_BuffText.cachedTextGenerator.Invalidate();
				this.m_BuffText.cachedTextGeneratorForLayout.Invalidate();
				this.m_BuffRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_BuffText.preferredWidth), 51f);
				this.m_BuffRC.gameObject.SetActive(true);
			}
			else
			{
				this.m_BuffRC.gameObject.SetActive(false);
			}
			if (ShieldLogManager.Instance.IsNeedShowBecomeDue())
			{
				this.m_BuffRC2.gameObject.SetActive(true);
				this.BuffTextTime = 1f;
				this.BuffRedTime = 0f;
				this.m_BuffText2.color = Color.white;
			}
			this.m_BuffSA.SetSpriteIndex((int)DataManager.Instance.m_BuffListOpenIcon);
		}
		else
		{
			this.m_BuffRC.gameObject.SetActive(false);
			this.m_BuffSA.SetSpriteIndex(0);
		}
	}

	// Token: 0x06000CF2 RID: 3314 RVA: 0x001331E0 File Offset: 0x001313E0
	private void CheckTalentPoint()
	{
		if (DataManager.Instance.RoleTalentPoint > 0 && DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.None)
		{
			this.m_HeadBoxFlash.SetActive(true);
		}
		else
		{
			this.m_HeadBoxFlash.SetActive(false);
		}
	}

	// Token: 0x06000CF3 RID: 3315 RVA: 0x00133230 File Offset: 0x00131430
	private void CheckTreasureBoxState()
	{
		if (this.m_eMapMode == EUIOriginMapMode.OriginMap && (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 3 || MallManager.Instance.CheckBtnShow()))
		{
			this.m_TreasureBoxObject.SetActive(true);
		}
		else
		{
			this.m_TreasureBoxObject.SetActive(false);
		}
	}

	// Token: 0x06000CF4 RID: 3316 RVA: 0x00133294 File Offset: 0x00131494
	private void SetTreasureBoxSprite()
	{
		ActivityManager instance = ActivityManager.Instance;
		bool flag = false;
		if (MallManager.Instance.CheckBtnShow())
		{
			this.m_TreasureBoxSA.m_Sprites[0] = this.LoadSprite("UI_chest_13a");
			this.m_TreasureBoxSA.m_Sprites[1] = this.LoadSprite("UI_chest_13b");
			this.m_TreasureBoxSA.m_Image.material = this.LoadMaterial();
			flag = true;
		}
		else
		{
			bool flag2 = this.DM.CheckDailyGift();
			if (this.m_TreasureBoxSA != null && instance.bDownLoadPic3 && (instance.TreasureBoxID > 0 || flag2))
			{
				ushort iconID = instance.TreasureBoxID;
				if (flag2)
				{
					iconID = this.DM.mDailyGift_Pic;
				}
				if (instance.bUpDatePic3)
				{
					instance.m_DoorBoxAsset.UnloadAsset();
					instance.bUpDatePic3 = false;
				}
				if (instance.m_DoorBoxAsset.m_AssetBundleKey == 0)
				{
					instance.m_DoorBoxAsset.InitialAsset("UIActivityBack_3");
				}
				this.m_TreasureBoxSA.m_Sprites[0] = instance.LoadDoorBoxSprite(iconID, true);
				this.m_TreasureBoxSA.m_Sprites[1] = instance.LoadDoorBoxSprite(iconID, false);
				this.m_TreasureBoxSA.m_Image.material = instance.GetDoorBoxMaterial();
				if (this.m_TreasureBoxSA.m_Sprites[0] != null && this.m_TreasureBoxSA.m_Sprites[1] != null && this.m_TreasureBoxSA.m_Image.material != null)
				{
					flag = true;
				}
			}
		}
		if (!flag)
		{
			this.m_TreasureBoxSA.m_Sprites[0] = this.LoadSprite("UI_main_chest_a");
			this.m_TreasureBoxSA.m_Sprites[1] = this.LoadSprite("UI_main_chest_b");
			this.m_TreasureBoxSA.m_Image.material = this.LoadMaterial();
		}
		this.CheckTreasureBox();
	}

	// Token: 0x06000CF5 RID: 3317 RVA: 0x00133474 File Offset: 0x00131674
	private void CheckTreasureBox()
	{
		this.CheckTreasureBoxState();
		this.m_TreasureBoxFlash_5x.gameObject.SetActive(false);
		if (MallManager.Instance.CheckBtnShow())
		{
			this.m_TreasureBoxtext.text = this.DM.mStringTable.GetStringByID(10080u);
			this.m_TreasureBoxSA.SetSpriteIndex(1);
			this.m_TreasureBoxPos.enabled = true;
			this.m_TreasureBoxScale.enabled = true;
		}
		else
		{
			bool flag = this.DM.CheckDailyGift();
			long num = this.DM.RoleAttr.NextOnlineGiftOpenTime - this.DM.ServerTime;
			if (num > 0L && !flag)
			{
				this.m_TreasureBoxSA.SetSpriteIndex(0);
				this.m_TreasureBoxPos.enabled = false;
				this.m_TreasureBoxPos.SetCurrentValueToStart();
				this.m_TreasureBoxScale.enabled = false;
				this.m_TreasureBoxScale.SetCurrentValueToStart();
				this.m_TreasureBoxStr.Length = 0;
				GameConstants.GetTimeString(this.m_TreasureBoxStr, (uint)num, false, false, false, false, true);
				this.m_TreasureBoxtext.text = this.m_TreasureBoxStr.ToString();
			}
			else
			{
				this.m_TreasureBoxSA.SetSpriteIndex(1);
				this.m_TreasureBoxPos.enabled = true;
				this.m_TreasureBoxScale.enabled = true;
				this.m_TreasureBoxtext.text = this.DM.mStringTable.GetStringByID(776u);
			}
			if (this.DM.RoleAttr.OnlineGiftOpenTimes == 19 && !flag)
			{
				this.m_TreasureBoxFlash_5x.gameObject.SetActive(true);
			}
		}
		this.m_TreasureBoxtext.SetAllDirty();
		this.m_TreasureBoxtext.cachedTextGenerator.Invalidate();
		this.m_TreasureBoxtext.cachedTextGeneratorForLayout.Invalidate();
	}

	// Token: 0x06000CF6 RID: 3318 RVA: 0x00133638 File Offset: 0x00131838
	private bool CheckShowLiveImg()
	{
		return GUIManager.Instance.bShowLive && GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 12;
	}

	// Token: 0x06000CF7 RID: 3319 RVA: 0x00133678 File Offset: 0x00131878
	private bool CheckShowLiveAlert()
	{
		bool flag = false;
		return flag && !DataManager.Instance.CheckPrizeFlag(28) && GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 12;
	}

	// Token: 0x06000CF8 RID: 3320 RVA: 0x001336C4 File Offset: 0x001318C4
	private bool CheckShowRedPocket()
	{
		if (this.DM.RoleAlliance.Id == 0u)
		{
			return false;
		}
		ActivityGiftManager instance = ActivityGiftManager.Instance;
		if (instance.GroupID == 0)
		{
			return false;
		}
		if (instance.EnableRedPocketNum > 0)
		{
			return true;
		}
		ActivityManager instance2 = ActivityManager.Instance;
		return this.DM.RoleAlliance.Rank == AllianceRank.RANK5 && instance.ActivityGiftBeginTime != 0L && instance2.ServerEventTime >= instance.ActivityGiftBeginTime && instance.ActivityGiftEndTime != 0L && instance2.ServerEventTime <= instance.ActivityGiftEndTime && instance.mLeaderRedPocketResetTime != 0L && instance2.ServerEventTime >= instance.mLeaderRedPocketResetTime;
	}

	// Token: 0x06000CF9 RID: 3321 RVA: 0x0013377C File Offset: 0x0013197C
	private void CheckShowMapInfoFlash()
	{
		bool active = false;
		if (ActivityManager.Instance.IsInFIFA(0, false) && ActivityManager.Instance.NowWaveEndTime != 0L)
		{
			ushort kingdomID;
			if (DataManager.MapDataController.FocusKingdomID != 0)
			{
				kingdomID = DataManager.MapDataController.FocusKingdomID;
			}
			else
			{
				kingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
			}
			bool flag = ActivityManager.Instance.IsInKvK(0, false);
			if (!flag || (flag && ActivityManager.Instance.IsMatchKvk_kingdom(kingdomID)))
			{
				active = FootballManager.Instance.bFirstFootBallMiniMap;
			}
		}
		this.m_MapFuncPanel.GetChild(4).GetChild(0).gameObject.SetActive(active);
	}

	// Token: 0x06000CFA RID: 3322 RVA: 0x00133830 File Offset: 0x00131A30
	private void SetSPGiftImgSprite(bool bMain)
	{
		Image image = (!bMain) ? this.SPGiftImgAlly : this.SPGiftImgMain;
		bool flag = GUIManager.Instance.SetFastivalImage(ActivityGiftManager.Instance.GroupID, 4, image);
		if (!flag || image.sprite == null || image.material == null)
		{
			image.enabled = false;
		}
		else
		{
			image.enabled = true;
		}
	}

	// Token: 0x06000CFB RID: 3323 RVA: 0x001338A8 File Offset: 0x00131AA8
	private void CheckPetSkillBtn(int arg = 0)
	{
		bool active = PetBuff.ShowButt(arg);
		bool active2 = PetBuff.CheckFlash();
		ushort num = PetBuff.CheckCount();
		this.m_PetSkillBtnGO.SetActive(active);
		this.m_PetSkillBtnFlashGO.SetActive(active2);
		if (num > 0)
		{
			this.m_PetSkillStr.Length = 0;
			this.m_PetSkillStr.IntToFormat((long)num, 1, false);
			this.m_PetSkillStr.AppendFormat("{0}");
			this.m_PetSkillText.text = this.m_PetSkillStr.ToString();
			this.m_PetSkillText.SetAllDirty();
			this.m_PetSkillText.cachedTextGenerator.Invalidate();
			this.m_PetSkillText.cachedTextGeneratorForLayout.Invalidate();
			this.m_PetSkillCountRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_PetSkillText.preferredWidth), 51f);
			this.m_PetSkillCountRC.gameObject.SetActive(true);
		}
		else
		{
			this.m_PetSkillCountRC.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000CFC RID: 3324 RVA: 0x001339A0 File Offset: 0x00131BA0
	private void SetFBBtnTime()
	{
		if (this.m_FBBtnTimeGO == null || !this.m_FBBtnTimeGO.activeInHierarchy || DataManager.FBMissionDataManager.m_FBTimeEnd)
		{
			return;
		}
		long num = (long)((ulong)DataManager.FBMissionDataManager.GetRemainTime());
		if (num > 0L)
		{
			this.m_FBBtnTimeStr.Length = 0;
			GameConstants.GetTimeString(this.m_FBBtnTimeStr, (uint)num, false, true, false, false, true);
			this.m_FBBtnTimeText.text = this.m_FBBtnTimeStr.ToString();
			this.m_FBBtnTimeText.SetAllDirty();
			this.m_FBBtnTimeText.cachedTextGenerator.Invalidate();
			this.m_FBBtnTimeText.cachedTextGeneratorForLayout.Invalidate();
			this.m_FBBtnTimeGO.SetActive(true);
		}
		else
		{
			this.CheckFBBtn(0);
		}
	}

	// Token: 0x06000CFD RID: 3325 RVA: 0x00133A6C File Offset: 0x00131C6C
	private void CheckFBBtn(int arg = 0)
	{
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 0, arg);
		if (this.m_eMapMode != EUIOriginMapMode.OriginMap)
		{
			this.m_FBBtnGO.SetActive(false);
			return;
		}
		if (DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex <= 11 || DataManager.FBMissionDataManager.GetRewardCount() > 0)
		{
			if (SocialManager.Instance.CheckShowPrize())
			{
				this.m_FBUIType = 0;
				this.m_FBBtnGO.SetActive(true);
				this.m_FBBtnSA.SetSpriteIndex(2);
				this.m_FBBtnTimeGO.SetActive(false);
				this.m_FBBtnAlertGO.SetActive(false);
				if (SocialManager.Instance.CheckShowPrizeCount())
				{
					this.m_FBBtnCountStr.Length = 0;
					this.m_FBBtnCountStr.IntToFormat((long)DataManager.FBMissionDataManager.GetRewardCount(), 1, false);
					this.m_FBBtnCountStr.AppendFormat("{0}");
					this.m_FBBtnCountText.text = this.m_FBBtnCountStr.ToString();
					this.m_FBBtnCountText.SetAllDirty();
					this.m_FBBtnCountText.cachedTextGenerator.Invalidate();
					this.m_FBBtnCountText.cachedTextGeneratorForLayout.Invalidate();
					this.m_FBBtnCountRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_FBBtnCountText.preferredWidth), 51f);
					this.m_FBBtnCountRC.gameObject.SetActive(true);
				}
				else
				{
					this.m_FBBtnCountRC.gameObject.SetActive(false);
				}
			}
			else if (SocialManager.Instance.CheckShowMission())
			{
				this.m_FBUIType = 0;
				if (!DataManager.FBMissionDataManager.m_FBTimeEnd)
				{
					DataManager.FBMissionDataManager.m_FBTimeEnd = (DataManager.Instance.CheckPrizeFlag(27) && !DataManager.FBMissionDataManager.IsInTime());
				}
				if (DataManager.FBMissionDataManager.m_FBTimeEnd)
				{
					if (DataManager.Instance.CheckPrizeFlag(27))
					{
						this.m_FBBtnAlertGO.SetActive(false);
						this.m_FBBtnTimeStr.Length = 0;
						GameConstants.GetTimeString(this.m_FBBtnTimeStr, 0u, false, true, false, false, true);
						this.m_FBBtnTimeText.text = this.m_FBBtnTimeStr.ToString();
						this.m_FBBtnTimeText.SetAllDirty();
						this.m_FBBtnTimeText.cachedTextGenerator.Invalidate();
						this.m_FBBtnTimeText.cachedTextGeneratorForLayout.Invalidate();
						this.m_FBBtnTimeText.color = Color.red;
						this.m_FBBtnTimeGO.SetActive(true);
					}
					else
					{
						this.m_FBBtnAlertGO.SetActive(true);
						this.m_FBBtnTimeGO.SetActive(false);
					}
					this.m_FBBtnCountRC.gameObject.SetActive(false);
					this.m_FBBtnSA.SetSpriteIndex(1);
					this.m_FBBtnGO.SetActive(true);
				}
				else
				{
					this.m_FBBtnAlertGO.SetActive(!DataManager.Instance.CheckPrizeFlag(27));
					this.m_FBBtnTimeGO.SetActive(!this.m_FBBtnAlertGO.activeSelf);
					this.m_FBBtnCountRC.gameObject.SetActive(false);
					this.m_FBBtnSA.SetSpriteIndex(1);
					this.m_FBBtnGO.SetActive(true);
					if (DataManager.FBMissionDataManager.IsInTime())
					{
						this.SetFBBtnTime();
					}
				}
			}
			else
			{
				this.m_FBBtnGO.SetActive(false);
			}
		}
		else
		{
			this.m_FBBtnGO.SetActive(false);
		}
		DataManager.FBMissionDataManager.bFB_CDTime = false;
		if (!this.m_FBBtnGO.activeSelf && (DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex > 11 || !DataManager.FBMissionDataManager.IsInTime()) && DataManager.FBMissionDataManager.CurrentFriendNum < 10 && GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 7 && DataManager.Instance.RoleAttr.Invitation != 0)
		{
			DataManager.FBMissionDataManager.bFB_CDTime = true;
			if (DataManager.FBMissionDataManager.CheckReSetFB_CDTime())
			{
				DataManager.FBMissionDataManager.bFB_btnShow = true;
			}
			if (DataManager.FBMissionDataManager.bFB_btnShow)
			{
				this.m_FBUIType = 1;
				this.m_FBBtnGO.SetActive(true);
				this.m_FBBtnSA.SetSpriteIndex(0);
				this.m_FBBtnTimeGO.SetActive(false);
				this.m_FBBtnAlertGO.SetActive(false);
				this.m_FBBtnCountRC.gameObject.SetActive(false);
			}
		}
		this.m_FBBtnSA.m_Image.SetNativeSize();
	}

	// Token: 0x06000CFE RID: 3326 RVA: 0x00133EC8 File Offset: 0x001320C8
	private void SetForceCount()
	{
		this.ForceTime = 0u;
		if (this.m_MoraleSA.m_SpriteIndex == 2)
		{
			uint stock = this.DM.PetResource.Stock;
			uint capacity = this.DM.PetResource.Capacity;
			double num = (double)((float)this.DM.PetResource.GetSpeed() / 3600f);
			if (num != 0.0)
			{
				this.ForceTime = (uint)((capacity - stock) / num);
			}
		}
	}

	// Token: 0x06000CFF RID: 3327 RVA: 0x00133F50 File Offset: 0x00132150
	private void UpDateForceHint()
	{
		if (this.bMoraleHintOpen && this.m_MoraleSA != null && this.m_MoraleSA.m_SpriteIndex == 2)
		{
			this.SetMolareHint(false);
		}
	}

	// Token: 0x06000D00 RID: 3328 RVA: 0x00133F94 File Offset: 0x00132194
	private void SetMolareHint(bool bCheckSec = true)
	{
		if (bCheckSec)
		{
			if (this.MoraleHintTime == DataManager.Instance.ServerTime)
			{
				return;
			}
			this.MoraleHintTime = DataManager.Instance.ServerTime;
		}
		if (this.MoraleHintString == null)
		{
			this.MoraleHintString = StringManager.Instance.SpawnString(600);
		}
		if (this.m_MoraleSA.m_SpriteIndex == 0)
		{
			ushort heroMaxMorale = this.DM.HeroMaxMorale;
			this.MoraleHintString.Length = 0;
			this.MoraleHintString.Append(this.DM.mStringTable.GetStringByID(251u));
			this.MoraleHintString.Append("\n");
			byte todayUseMoraleItemTimes = this.DM.RoleAttr.TodayUseMoraleItemTimes;
			byte moraleBanner = this.DM.VIPLevelTable.GetRecordByKey((ushort)this.DM.RoleAttr.VIPLevel).moraleBanner;
			this.MoraleHintString.Append("<color=#ffff00>");
			if (moraleBanner == 255)
			{
				this.MoraleHintString.AppendFormat(this.DM.mStringTable.GetStringByID(8583u));
			}
			else
			{
				if (todayUseMoraleItemTimes >= moraleBanner)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					StringManager.IntToStr(cstring, (long)moraleBanner, 1, false);
					CString cstring2 = StringManager.Instance.StaticString1024();
					cstring2.Append("<color=#ff0000>");
					cstring2.Append(cstring);
					cstring2.Append("</color>");
					this.MoraleHintString.StringToFormat(cstring2);
				}
				else
				{
					this.MoraleHintString.IntToFormat((long)todayUseMoraleItemTimes, 1, false);
				}
				this.MoraleHintString.IntToFormat((long)moraleBanner, 1, false);
				this.MoraleHintString.AppendFormat(this.DM.mStringTable.GetStringByID(8582u));
			}
			this.MoraleHintString.Append("</color>\n");
			this.MoraleHintString.Append("<color=#ffff00>");
			this.MoraleHintString.IntToFormat((long)GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Hour, 2, false);
			this.MoraleHintString.IntToFormat((long)GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Minute, 2, false);
			this.MoraleHintString.AppendFormat(this.DM.mStringTable.GetStringByID(753u));
			this.MoraleHintString.Append("</color>\n");
			if (this.DM.RoleAttr.Morale < heroMaxMorale)
			{
				long num = 360L - (this.DM.ServerTime - this.DM.RoleAttr.LastMoraleRecoverTime);
				if (num < 0L)
				{
					return;
				}
				int num2 = 0;
				int num3 = (int)num / 60;
				int num4 = (int)num % 60;
				this.MoraleHintString.IntToFormat((long)num2, 2, false);
				this.MoraleHintString.IntToFormat((long)num3, 2, false);
				this.MoraleHintString.IntToFormat((long)num4, 2, false);
				this.MoraleHintString.AppendFormat(this.DM.mStringTable.GetStringByID(360u));
				this.MoraleHintString.Append("\n");
				int num5 = (int)(heroMaxMorale - this.DM.RoleAttr.Morale);
				if (num5 > 1)
				{
					num5--;
					num5 *= 6;
					num2 += num5 / 60;
					num3 += num5 % 60;
				}
				this.MoraleHintString.IntToFormat((long)num2, 2, false);
				this.MoraleHintString.IntToFormat((long)num3, 2, false);
				this.MoraleHintString.IntToFormat((long)num4, 2, false);
				this.MoraleHintString.AppendFormat(this.DM.mStringTable.GetStringByID(361u));
			}
			else
			{
				this.MoraleHintString.Append(this.DM.mStringTable.GetStringByID(359u));
			}
		}
		else if (this.m_MoraleSA.m_SpriteIndex == 2)
		{
			if (bCheckSec && this.ForceTime > 0u)
			{
				this.ForceTime -= 1u;
			}
			this.MoraleHintString.Length = 0;
			this.MoraleHintString.Append(this.DM.mStringTable.GetStringByID(14590u));
			uint stock = this.DM.PetResource.Stock;
			uint capacity = this.DM.PetResource.Capacity;
			if (stock >= capacity)
			{
				CString cstring3 = StringManager.Instance.StaticString1024();
				cstring3.IntToFormat((long)((ulong)stock), 1, true);
				cstring3.IntToFormat((long)((ulong)capacity), 1, true);
				cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(14594u));
				this.MoraleHintString.Append(cstring3);
				if (capacity != 0u)
				{
					this.MoraleHintString.Append("\n");
					this.MoraleHintString.Append(this.DM.mStringTable.GetStringByID(14592u));
				}
			}
			else
			{
				CString cstring4 = StringManager.Instance.StaticString1024();
				cstring4.IntToFormat((long)((ulong)stock), 1, true);
				cstring4.IntToFormat((long)((ulong)capacity), 1, true);
				cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(14593u));
				this.MoraleHintString.Append(cstring4);
				this.MoraleHintString.Append("\n");
				this.MoraleHintString.Append(this.DM.mStringTable.GetStringByID(14591u));
				this.MoraleHintString.Append("<color=#00ff00>");
				CString cstring5 = StringManager.Instance.StaticString1024();
				GameConstants.GetTimeString(cstring5, this.ForceTime, false, false, true, false, true);
				this.MoraleHintString.Append(cstring5);
				this.MoraleHintString.Append("</color>");
			}
		}
		else
		{
			this.MoraleHintString.Length = 0;
			this.MoraleHintString.Append(this.DM.mStringTable.GetStringByID(880u));
			this.MoraleHintString.Append("\n");
			uint maxMonsterPoint = this.DM.GetMaxMonsterPoint();
			if (maxMonsterPoint > this.DM.RoleAttr.MonsterPoint)
			{
				if (this.MonsterTime == -1L)
				{
					this.MonsterTime = (long)((this.DM.GetMaxMonsterPoint() - this.DM.RoleAttr.MonsterPoint) * ((double)this.DM.RoleAttr.MonsterPointRecoverFrequency / 1000.0));
				}
				else
				{
					this.MonsterTime -= 1L;
				}
				int num6 = (int)this.MonsterTime / 3600;
				int num7 = (int)this.MonsterTime % 3600 / 60;
				int num8 = (int)this.MonsterTime % 60;
				this.MoraleHintString.IntToFormat((long)num6, 2, false);
				this.MoraleHintString.IntToFormat((long)num7, 2, false);
				this.MoraleHintString.IntToFormat((long)num8, 2, false);
				this.MoraleHintString.AppendFormat(this.DM.mStringTable.GetStringByID(881u));
			}
			else
			{
				this.MoraleHintString.Append(this.DM.mStringTable.GetStringByID(882u));
			}
		}
		this.m_MoraleHintText.text = this.MoraleHintString.ToString();
		this.m_MoraleHintText.SetAllDirty();
		this.m_MoraleHintText.cachedTextGenerator.Invalidate();
		this.m_MoraleHintText.cachedTextGeneratorForLayout.Invalidate();
		this.m_MoraleHintBox.rectTransform.sizeDelta = new Vector2(this.m_MoraleHintText.preferredWidth + 35f, this.m_MoraleHintText.preferredHeight + 31f);
		RectTransform component = GUIManager.Instance.m_UICanvas.GetComponent<RectTransform>();
		float x = component.sizeDelta.x;
		RectTransform rectTransform = this.m_MoraleHintText.rectTransform;
		if (rectTransform.anchoredPosition.x + rectTransform.sizeDelta.x > x)
		{
			rectTransform.anchoredPosition = new Vector2(x - rectTransform.sizeDelta.x, rectTransform.anchoredPosition.y);
		}
		if (rectTransform.anchoredPosition.x < 0f)
		{
			rectTransform.anchoredPosition = new Vector2(0f, rectTransform.anchoredPosition.y);
		}
		this.m_MoraleHintText.UpdateArabicPos();
	}

	// Token: 0x06000D01 RID: 3329 RVA: 0x00134814 File Offset: 0x00132A14
	public void SetAlertImageAlpha(float Alpha)
	{
		if (GUIManager.Instance.m_AlertImageIndex == 0 && this.m_AlertBlock != null)
		{
			Color color = new Color(1f, 1f, 1f, Alpha);
			this.m_AlertBlock_T.color = color;
			this.m_AlertBlock_B.color = color;
			this.m_AlertBlock_R.color = color;
			this.m_AlertBlock_L.color = color;
		}
	}

	// Token: 0x06000D02 RID: 3330 RVA: 0x00134888 File Offset: 0x00132A88
	public void CheckAttackState()
	{
		int[] attackedAlertCount = this.GM.m_AttackedAlertCount;
		int num = -1;
		for (int i = 0; i < 15; i++)
		{
			if (attackedAlertCount[i] > 0 && num == -1)
			{
				num = i;
			}
		}
		if (this.GM.m_AttackedAlertTCount > 0)
		{
			this.m_AttackedAlertStr.Length = 0;
			this.m_AttackedAlertStr.IntToFormat((long)this.GM.m_AttackedAlertTCount, 1, false);
			this.m_AttackedAlertStr.AppendFormat("{0}");
			this.m_AttackedAlertText.text = this.m_AttackedAlertStr.ToString();
			this.m_AttackedAlertText.SetAllDirty();
			this.m_AttackedAlertText.cachedTextGenerator.Invalidate();
			this.m_AttackedAlertText.cachedTextGeneratorForLayout.Invalidate();
			this.m_AttackedAlertRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_AttackedAlertText.preferredWidth), 51f);
			this.m_AttackedAlertSA.SetSpriteIndex(num);
			this.m_AttackedAlertSA.m_Image.SetNativeSize();
			this.m_AttackedAlertSA2.SetSpriteIndex(num);
			this.m_AttackedAlertRC.gameObject.SetActive(true);
			this.m_AttackedAlert.gameObject.SetActive(true);
			EAttackKind eattackKind = (EAttackKind)num;
			if (eattackKind == EAttackKind.Wonder_Attack || eattackKind == EAttackKind.Wonder_Detect || eattackKind == EAttackKind.Wonder_GatherAttack || eattackKind == EAttackKind.Wonder_Reinforce)
			{
				this.m_AttackedAlertBackSA.SetSpriteIndex(1);
				this.m_AttackedAlertBackSA2.SetSpriteIndex(1);
			}
			else
			{
				this.m_AttackedAlertBackSA.SetSpriteIndex(0);
				this.m_AttackedAlertBackSA2.SetSpriteIndex(0);
			}
			this.m_AlertBlock.gameObject.SetActive(this.GM.m_AlertImageIndex == 0);
		}
		else
		{
			this.m_AttackedAlert.gameObject.SetActive(false);
			this.m_AlertBlock.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000D03 RID: 3331 RVA: 0x00134A58 File Offset: 0x00132C58
	public void CheckHelpAlertState()
	{
		if (DataManager.Instance.mHelpDataList.Count > 0)
		{
			this.m_HelpAlertStr.Length = 0;
			this.m_HelpAlertStr.IntToFormat((long)DataManager.Instance.mHelpDataList.Count, 1, false);
			this.m_HelpAlertStr.AppendFormat("{0}");
			this.m_HelpAlertext.text = this.m_HelpAlertStr.ToString();
			this.m_HelpAlertext.SetAllDirty();
			this.m_HelpAlertext.cachedTextGenerator.Invalidate();
			this.m_HelpAlertext.cachedTextGeneratorForLayout.Invalidate();
			this.m_HelpAlertRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_HelpAlertext.preferredWidth), 51f);
			this.m_HelpAlertRC.gameObject.SetActive(true);
			this.m_HelpAlert.gameObject.SetActive(true);
			if (DataManager.Instance.AllianceMoneyBonusRate > 100)
			{
				int num = (int)(DataManager.Instance.AllianceMoneyBonusRate / 100 - 2);
				if (num >= 0 && num < this.m_HelpAlertSA.m_Sprites.Length)
				{
					this.m_HelpAlertSA.SetSpriteIndex(num);
				}
				else
				{
					this.m_HelpAlertSA.SetSpriteIndex(0);
				}
				this.m_HelpAlertL.gameObject.SetActive(true);
				this.m_HelpAlertR.gameObject.SetActive(true);
				this.m_HelpAlertImageGO.SetActive(true);
			}
			else
			{
				this.m_HelpAlertImageGO.SetActive(false);
				this.m_HelpAlertL.gameObject.SetActive(false);
				this.m_HelpAlertR.gameObject.SetActive(false);
			}
		}
		else
		{
			this.m_HelpAlert.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000D04 RID: 3332 RVA: 0x00134C0C File Offset: 0x00132E0C
	public void CheckAllianceFreeState()
	{
		if (DataManager.Instance.RoleAlliance.Id <= 0u)
		{
			if (DataManager.Instance.CheckPrizeFlag(0))
			{
				this.m_AllianceFreetext.rectTransform.offsetMax = new Vector2(-5f, 0f);
				this.m_AllianceFreetext.rectTransform.offsetMin = new Vector2(5f, 0f);
				this.m_AllianceFreetext.text = DataManager.Instance.mStringTable.GetStringByID(16110u);
				this.m_AllianceFreeSA1.SetSpriteIndex(1);
				this.m_AllianceFreeSA2.SetSpriteIndex(1);
				this.m_AllianceFreeSA1.m_Image.rectTransform.anchoredPosition = new Vector2(-39.5f, 156.8f);
			}
			else
			{
				this.m_AllianceFreetext.rectTransform.offsetMax = Vector2.zero;
				this.m_AllianceFreetext.rectTransform.offsetMin = Vector2.zero;
				this.m_AllianceFreetext.text = DataManager.Instance.mStringTable.GetStringByID(777u);
				this.m_AllianceFreeSA1.SetSpriteIndex(0);
				this.m_AllianceFreeSA2.SetSpriteIndex(0);
				this.m_AllianceFreeSA1.m_Image.rectTransform.anchoredPosition = new Vector2(-39.5f, 160.3f);
			}
			this.m_AllianceFreeSA1.m_Image.SetNativeSize();
			this.m_AllianceFreeSA2.m_Image.SetNativeSize();
			this.m_AllianceFree.gameObject.SetActive(true);
		}
		else
		{
			this.m_AllianceFree.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000D05 RID: 3333 RVA: 0x00134DA8 File Offset: 0x00132FA8
	public void QueuePanelSetActive(bool bActive)
	{
		this.m_QueuePanel.gameObject.SetActive(bActive);
		this.CheckSpQueueBar();
		if (bActive)
		{
			int num = 0;
			while (num < (int)this.m_QueueCount && num < this.m_QueueTimeBar.Length)
			{
				this.m_QueueTimeBar[num].SetFlashCount(1f, this.m_QueueTimeBar[num].GetTextIndex());
				num++;
			}
		}
	}

	// Token: 0x06000D06 RID: 3334 RVA: 0x00134E18 File Offset: 0x00133018
	public void CheckSpQueueBar()
	{
		QueueBarData queueBarData = DataManager.Instance.queueBarData[17];
		if (queueBarData.bActive)
		{
			if (this.m_QueueCount > 0)
			{
				this.m_QueueTimeBar[0].gameObject.SetActive(true);
			}
			else
			{
				this.m_QueueTimeBar[0].gameObject.SetActive(false);
			}
		}
		else
		{
			this.m_QueueTimeBar[0].gameObject.SetActive(this.m_QueuePanel.gameObject.activeSelf);
		}
	}

	// Token: 0x06000D07 RID: 3335 RVA: 0x00134EA8 File Offset: 0x001330A8
	public void SetQueueBar(bool bShow)
	{
		Vector2 anchoredPosition = this.m_QueueIcon.rectTransform.anchoredPosition;
		if (bShow)
		{
			QueueBarData queueBarData = DataManager.Instance.queueBarData[17];
			if (queueBarData.bActive && this.m_QueueCount <= 1)
			{
				this.m_QueueIcon.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
				anchoredPosition.x = 36.6f;
			}
			else
			{
				this.m_QueueIcon.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
				anchoredPosition.x = 24f;
			}
			this.m_QueueCountBox.gameObject.SetActive(false);
		}
		else
		{
			this.m_QueueIcon.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
			anchoredPosition.x = 36.6f;
			if (this.m_QueueCount > 0)
			{
				this.m_QueueCountBox.gameObject.SetActive(true);
			}
			else
			{
				this.m_QueueCountBox.gameObject.SetActive(false);
			}
		}
		this.m_QueueIcon.rectTransform.anchoredPosition = anchoredPosition;
	}

	// Token: 0x06000D08 RID: 3336 RVA: 0x00134FEC File Offset: 0x001331EC
	public static float GetRedBackWidth(float WordWidth)
	{
		float num = WordWidth + 28f;
		return (num >= 52f) ? num : 52f;
	}

	// Token: 0x06000D09 RID: 3337 RVA: 0x00135018 File Offset: 0x00133218
	public void CheckSysSetting()
	{
		DataManager.Instance.bNeedSortQueueBarData = true;
	}

	// Token: 0x06000D0A RID: 3338 RVA: 0x00135028 File Offset: 0x00133228
	public void ShowLoadingImg()
	{
		if (this.LoadingImgT != null)
		{
			this.LoadingImgT.gameObject.SetActive(true);
			this.bShowLoadingImg = true;
		}
	}

	// Token: 0x06000D0B RID: 3339 RVA: 0x00135054 File Offset: 0x00133254
	public void HideLoadingImg()
	{
		if (this.LoadingImgT != null)
		{
			this.LoadingImgT.gameObject.SetActive(false);
			this.bShowLoadingImg = false;
		}
	}

	// Token: 0x06000D0C RID: 3340 RVA: 0x00135080 File Offset: 0x00133280
	public void GoToKingdom(ushort kingdomID, int MapID = -1)
	{
		if (MapID == -1)
		{
			if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
			{
				DataManager.msgBuffer[0] = 126;
				GameConstants.GetBytes(kingdomID, DataManager.msgBuffer, 1);
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			else
			{
				DataManager.MapDataController.gotokingdomID = kingdomID;
				DataManager.MapDataController.FocusWorldMapPos = -Vector2.one;
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToWorld);
			}
		}
		else
		{
			DataManager.MapDataController.ClearLayoutMapInfoYolkKind();
			DataManager.MapDataController.FocusKingdomID = kingdomID;
			DataManager.MapDataController.FocusMapID = MapID;
			if (kingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
			{
				DataManager.MapDataController.FocusKingdomPeriod = DataManager.MapDataController.OtherKingdomData.kingdomPeriod;
				if (NetworkManager.GuestController.Connected() || NetworkManager.GuestController.Connecting())
				{
					NetworkManager.Instance.ViewClose();
				}
				if (DataManager.MapDataController.gotoKingdomState == 0)
				{
					DataManager.MapDataController.ClearAll();
					this.GoToMapID(kingdomID, DataManager.MapDataController.FocusMapID, 0, 1, true);
				}
			}
			else
			{
				if (!NetworkManager.GuestController.Connected())
				{
					DataManager.MapDataController.OutMap();
				}
				MapManager mapDataController = DataManager.MapDataController;
				mapDataController.gotoKingdomState += 1;
				GUIManager.Instance.ShowUILock(EUILock.Normal);
				NetworkManager.Instance.ViewKingdom(kingdomID);
			}
		}
	}

	// Token: 0x06000D0D RID: 3341 RVA: 0x001351E8 File Offset: 0x001333E8
	public void ViewKingdom()
	{
		MapManager mapDataController = DataManager.MapDataController;
		mapDataController.gotoKingdomState -= 1;
		if (DataManager.MapDataController.gotoKingdomState == 0)
		{
			this.HideLoadingImg();
			DataManager.MapDataController.ClearAll();
			this.GoToMapID(DataManager.MapDataController.FocusKingdomID, DataManager.MapDataController.FocusMapID, 0, 1, true);
		}
		GUIManager.Instance.HideUILock(EUILock.Normal);
	}

	// Token: 0x06000D0E RID: 3342 RVA: 0x00135250 File Offset: 0x00133450
	public void GoToGroup(int groupID, byte isOpenGroundInfo = 0, bool bsend = true)
	{
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		if (groupID < -1 || groupID >= 10)
		{
			return;
		}
		this.CheckFocusGroup();
		byte isMarkGroundInfo = 1;
		int mapID;
		if (groupID == 9)
		{
			if (PetManager.Instance.m_PetMarchEventData.PetID != 0)
			{
				mapID = ((this.m_eMapMode != EUIOriginMapMode.KingdomMap) ? DataManager.Instance.getMapIDbyGroupID((byte)groupID) : DataManager.Instance.RoleAttr.CapitalPoint);
				DataManager.MapDataController.FocusGroupID = (byte)groupID;
				isMarkGroundInfo = 0;
			}
			else
			{
				mapID = DataManager.Instance.RoleAttr.CapitalPoint;
			}
		}
		else if (groupID == 8)
		{
			if (DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
			{
				mapID = ((this.m_eMapMode != EUIOriginMapMode.KingdomMap) ? DataManager.Instance.getMapIDbyGroupID((byte)groupID) : DataManager.Instance.RoleAttr.CapitalPoint);
				DataManager.MapDataController.FocusGroupID = (byte)groupID;
				isMarkGroundInfo = 0;
			}
			else
			{
				mapID = DataManager.Instance.RoleAttr.CapitalPoint;
			}
		}
		else if (groupID == -1 || DataManager.Instance.MarchEventData[groupID].Type == EMarchEventType.EMET_Standby)
		{
			mapID = DataManager.Instance.RoleAttr.CapitalPoint;
		}
		else if (DataManager.Instance.MarchEventData[groupID].Type < EMarchEventType.EMET_AttackMarching)
		{
			mapID = GameConstants.PointCodeToMapID(DataManager.Instance.MarchEventData[groupID].Point.zoneID, DataManager.Instance.MarchEventData[groupID].Point.pointID);
		}
		else
		{
			mapID = ((this.m_eMapMode != EUIOriginMapMode.KingdomMap) ? DataManager.Instance.getMapIDbyGroupID((byte)groupID) : DataManager.Instance.RoleAttr.CapitalPoint);
			DataManager.MapDataController.FocusGroupID = (byte)groupID;
			isMarkGroundInfo = 0;
		}
		this.GoToMapID(DataManager.MapDataController.OtherKingdomData.kingdomID, mapID, isOpenGroundInfo, isMarkGroundInfo, bsend);
	}

	// Token: 0x06000D0F RID: 3343 RVA: 0x00135450 File Offset: 0x00133650
	public void GoToPointCode(ushort kingdomID, ushort zoneID, byte pointID, byte isOpenGroundInfo = 0)
	{
		this.CheckFocusGroup();
		DataManager.MapDataController.FocusGroupID = 10;
		this.GoToMapID(kingdomID, GameConstants.PointCodeToMapID(zoneID, pointID), isOpenGroundInfo, 1, true);
	}

	// Token: 0x06000D10 RID: 3344 RVA: 0x00135484 File Offset: 0x00133684
	public void GoToMapID(ushort kingdomID, int MapID, byte isOpenGroundInfo = 0, byte isMarkGroundInfo = 1, bool bsend = true)
	{
		if (!DataManager.MapDataController.CheckKingdomID(kingdomID))
		{
			return;
		}
		FootballManager.Instance.CheckFootBallIDHitClose(4);
		if (kingdomID != DataManager.MapDataController.FocusKingdomID)
		{
			if (this.m_eMapMode == EUIOriginMapMode.KingdomMap)
			{
				DataManager.MapDataController.ClearLayoutMapInfoYolkKind();
				DataManager.MapDataController.FocusKingdomID = kingdomID;
				DataManager.MapDataController.FocusMapID = MapID;
				DataManager.MapDataController.gotoKingdomState = byte.MaxValue;
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToKing);
			}
			else
			{
				this.GoToKingdom(kingdomID, MapID);
			}
			return;
		}
		DataManager.MapDataController.FocusMapID = MapID;
		DataManager.MapDataController.isMarkGroundInfo = isMarkGroundInfo;
		DataManager.MapDataController.isOpenGroundInfo = isOpenGroundInfo;
		if (this.m_eMapMode != EUIOriginMapMode.KingdomMap)
		{
			DataManager.MapDataController.ClearLayoutMapInfoYolkKind();
			GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToKing);
		}
		else if (this.TileMapController != null)
		{
			this.CloseMenu(this.m_WindowStack.Count > 0);
			uint num = DataManager.MapDataController.CheckWonderMapID((uint)DataManager.MapDataController.FocusMapID, DataManager.MapDataController.FocusKingdomID);
			DataManager.MapDataController.FocusMapID = (int)((num != 40u) ? num : ((uint)DataManager.MapDataController.FocusMapID));
			if (DataManager.MapDataController.FocusGroupID == 10)
			{
				Vector2 tileMapPosbyMapID = GameConstants.getTileMapPosbyMapID(DataManager.MapDataController.FocusMapID);
				this.TileMapController.MovebyTileMapPos((int)tileMapPosbyMapID.x, (int)tileMapPosbyMapID.y, bsend);
			}
			else if (!this.TileMapController.ClickGroup())
			{
				DataManager.MapDataController.FocusMapID = DataManager.Instance.getMapIDbyGroupID(DataManager.MapDataController.FocusGroupID);
				Vector2 tileMapPosbyMapID2 = GameConstants.getTileMapPosbyMapID(DataManager.MapDataController.FocusMapID);
				this.TileMapController.MovebyTileMapPos((int)tileMapPosbyMapID2.x, (int)tileMapPosbyMapID2.y, true);
			}
			this.TileMapController.CheckCenterPos();
		}
	}

	// Token: 0x06000D11 RID: 3345 RVA: 0x00135678 File Offset: 0x00133878
	public void GoToWonder(ushort kingdomID, byte WonderID)
	{
		this.GoToMapID(kingdomID, (int)DataManager.MapDataController.GetYolkMapID((ushort)WonderID, kingdomID), 0, 1, true);
	}

	// Token: 0x06000D12 RID: 3346 RVA: 0x0013569C File Offset: 0x0013389C
	public void CheckFocusGroup()
	{
		if (DataManager.MapDataController.FocusGroupID != 10)
		{
			DataManager.msgBuffer[0] = 65;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x06000D13 RID: 3347 RVA: 0x001356D0 File Offset: 0x001338D0
	public void CheckMapID(int mapInfoID)
	{
		if (this.m_GroundInfo != null)
		{
			this.m_GroundInfo.CheckMapInfoID(mapInfoID);
		}
	}

	// Token: 0x06000D14 RID: 3348 RVA: 0x001356EC File Offset: 0x001338EC
	public void OpenGroundInfo(int mapInfoID, POINT_KIND infoKind = POINT_KIND.PK_MAX)
	{
		this.SetDefaultFadeAlpha();
		if (this.m_GroundInfo != null)
		{
			if (this.m_WindowStack.Count > 0)
			{
				return;
			}
			if (this.m_GroundInfo.m_PanelGameObject.activeSelf || this.m_GroundInfo.m_TeamPanelGameObject.activeSelf)
			{
				this.m_GroundInfo.Close();
			}
			else
			{
				DataManager.msgBuffer[0] = 78;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			this.m_GroundInfo.delayOpen(mapInfoID, infoKind);
		}
	}

	// Token: 0x06000D15 RID: 3349 RVA: 0x00135778 File Offset: 0x00133978
	public void ShowKVKTransBtn(bool bShow = true)
	{
		this.KVKTransBtnGO.SetActive(bShow);
		int kvKKingdomType = (int)ActivityManager.Instance.getKvKKingdomType(DataManager.MapDataController.FocusKingdomID);
		if (kvKKingdomType > 0 && kvKKingdomType <= 3)
		{
			this.KVKTransBtnSA.SetSpriteIndex(kvKKingdomType - 1);
		}
		else
		{
			this.KVKTransBtnSA.SetSpriteIndex(0);
		}
	}

	// Token: 0x06000D16 RID: 3350 RVA: 0x001357D4 File Offset: 0x001339D4
	public void ShowKingdomMark(bool bclear = false)
	{
		if (bclear || DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
		{
			if (this.KingdomMarkGameObject != null)
			{
				this.KingdomMarkGameObject.SetActive(false);
				this.ShowKVKTransBtn(false);
			}
		}
		else
		{
			if (this.KingdomMarkGameObject == null)
			{
				this.KingdomMarkGameObject = new GameObject("KingdomMark");
				RectTransform rectTransform = this.KingdomMarkGameObject.AddComponent<RectTransform>();
				rectTransform.sizeDelta = Vector2.zero;
				rectTransform.anchoredPosition = new Vector2(0f, 200f);
				GameObject gameObject = new GameObject("back");
				Image image = gameObject.AddComponent<Image>();
				Image component = this.m_LocationBox.GetComponent<Image>();
				image.sprite = component.sprite;
				image.material = component.material;
				RectTransform rectTransform2 = image.transform as RectTransform;
				image.type = Image.Type.Sliced;
				rectTransform2.sizeDelta = new Vector2(500f, 40f);
				gameObject.transform.SetParent(rectTransform, false);
				gameObject = new GameObject("kingdom_name");
				this.KingdomMarkText = gameObject.AddComponent<UIText>();
				gameObject.AddComponent<Outline>();
				rectTransform2 = (this.KingdomMarkText.transform as RectTransform);
				rectTransform2.sizeDelta = new Vector2(500f, 40f);
				this.KingdomMarkText.font = GUIManager.Instance.GetTTFFont();
				this.KingdomMarkText.alignment = TextAnchor.MiddleCenter;
				this.KingdomMarkText.fontSize = 22;
				this.KingdomMarkText.color = Color.red;
				gameObject.transform.SetParent(rectTransform, false);
				rectTransform.SetParent(this.m_MapFuncPanel, false);
				this.KingdomMarkGameObject.AddComponent<CanvasGroup>().ignoreParentGroups = true;
				this.KingdomMarkString = StringManager.Instance.SpawnString(30);
			}
			this.KingdomMarkGameObject.SetActive(false);
			this.KingdomMarkString.ClearString();
			if (GUIManager.Instance.IsArabic)
			{
				this.KingdomMarkString.IntToFormat((long)DataManager.MapDataController.FocusKingdomID, 1, false);
				this.KingdomMarkString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(592u));
				this.KingdomMarkString.AppendFormat("{1} ({0}:K)");
			}
			else
			{
				this.KingdomMarkString.IntToFormat((long)DataManager.MapDataController.FocusKingdomID, 1, false);
				this.KingdomMarkString.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(592u));
			}
			this.KingdomMarkText.text = this.KingdomMarkString.ToString();
			this.KingdomMarkText.SetAllDirty();
			this.KingdomMarkGameObject.SetActive(true);
			if (ActivityManager.Instance.IsInKvK(0, true) && ((DataManager.MapDataController.kingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID && DataManager.MapDataController.kingdomData.kingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID && DataManager.MapDataController.kingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK) || DataManager.MapDataController.IsEnemy(DataManager.MapDataController.FocusKingdomID)))
			{
				this.ShowKVKTransBtn(true);
			}
			else
			{
				this.ShowKVKTransBtn(false);
			}
		}
	}

	// Token: 0x06000D17 RID: 3351 RVA: 0x00135B18 File Offset: 0x00133D18
	public MAP_TERRAIN_KIND GetTerrain(ushort kingdomID, uint mapID)
	{
		if (this.TileMapController != null && this.TileMapController.TileMapInfo != null && (ulong)mapID < (ulong)((long)this.TileMapController.TileMapInfo.Length) && this.m_eMapMode == EUIOriginMapMode.KingdomMap && kingdomID == DataManager.MapDataController.FocusKingdomID)
		{
			return DataManager.MapDataController.GetTerrain(this.TileMapController.TileMapInfo[(int)((UIntPtr)mapID)]);
		}
		KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(kingdomID);
		AssetBundle tableAB = DataManager.Instance.GetTableAB();
		if (!tableAB)
		{
			return MAP_TERRAIN_KIND.MTK_NONE;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.IntToFormat((long)recordByKey.mapID, 3, false);
		cstring.AppendFormat("TileMap_{0}");
		TextAsset textAsset = tableAB.Load(cstring.ToString()) as TextAsset;
		if (textAsset == null)
		{
			return MAP_TERRAIN_KIND.MTK_NONE;
		}
		Stream stream = new MemoryStream(textAsset.bytes);
		MAP_TERRAIN_KIND terrain = DataManager.MapDataController.GetTerrain(textAsset.bytes[(int)((UIntPtr)mapID)]);
		stream.Close();
		return terrain;
	}

	// Token: 0x06000D18 RID: 3352 RVA: 0x00135C34 File Offset: 0x00133E34
	private void GroundInfoUpdate()
	{
		if (this.m_GroundInfo != null)
		{
			this.m_GroundInfo.Run();
		}
	}

	// Token: 0x06000D19 RID: 3353 RVA: 0x00135C4C File Offset: 0x00133E4C
	public void BeginFadeInOut()
	{
		if (this.FadeInOrOut == 2 || this.CGDoor.alpha == 0f)
		{
			this.BeginFadeIn();
		}
		else if (this.FadeInOrOut == 1 || this.CGDoor.alpha == 1f)
		{
			this.BeginFadeOut();
		}
	}

	// Token: 0x06000D1A RID: 3354 RVA: 0x00135CAC File Offset: 0x00133EAC
	public void BeginFadeIn()
	{
		if (this.FadeInOrOut == 1 || !DataManager.Instance.MySysSetting.bShowMainMenu)
		{
			return;
		}
		this.FadeBeginAlpha = this.CGDoor.alpha;
		this.FadeInOrOut = 1;
		this.FadeNowTime = 0f;
		this.CGDoor.blocksRaycasts = true;
		this.CGTop.blocksRaycasts = true;
	}

	// Token: 0x06000D1B RID: 3355 RVA: 0x00135D18 File Offset: 0x00133F18
	public void BeginFadeOut()
	{
		if (this.bHideMainMenu || this.FadeInOrOut == 2 || !DataManager.Instance.MySysSetting.bShowMainMenu)
		{
			return;
		}
		this.FadeBeginAlpha = this.CGDoor.alpha;
		this.FadeInOrOut = 2;
		this.FadeNowTime = 0f;
		if (!this.bHideMainMenu)
		{
			this.ShowFIFATime(true);
			this.ShowPVPTime(true);
			this.ShowKVKTime(true);
		}
	}

	// Token: 0x06000D1C RID: 3356 RVA: 0x00135D94 File Offset: 0x00133F94
	public void SetDefaultFadeAlpha()
	{
		if (this.CGDoor.alpha == 1f)
		{
			return;
		}
		this.BeginFadeIn();
	}

	// Token: 0x06000D1D RID: 3357 RVA: 0x00135DB4 File Offset: 0x00133FB4
	private void SetFadeTargetAlpha(byte TargetAlpha)
	{
		this.CGDoor.alpha = (float)TargetAlpha;
		this.CGTop.alpha = (float)TargetAlpha;
		this.CGDoor.blocksRaycasts = (TargetAlpha == 1);
		this.CGTop.blocksRaycasts = (TargetAlpha == 1);
		this.FadeInOrOut = 0;
		this.FadeNowTime = 0f;
		this.FadeBeginAlpha = 0f;
		if (GUIManager.Instance.bOpenOnIPhoneX && TargetAlpha == 1)
		{
			this.m_BackBlock_L.enabled = false;
			this.m_BackBlock_R.enabled = false;
			this.m_BackBlock_L.color = new Color(1f, 1f, 1f, 1f);
			this.m_BackBlock_R.color = new Color(1f, 1f, 1f, 1f);
		}
		if (!this.bHideMainMenu && !this.bHideMainByFIFA && TargetAlpha == 1)
		{
			this.HideFIFATime();
			this.HidePVPTime();
			this.HideKVKTime();
		}
	}

	// Token: 0x06000D1E RID: 3358 RVA: 0x00135EBC File Offset: 0x001340BC
	private void FadeInOutUpDate()
	{
		if (this.FadeInOrOut != 0)
		{
			this.FadeNowTime += Time.smoothDeltaTime;
			if (this.FadeInOrOut == 1)
			{
				if (this.FadeNowTime >= this.FadeInTime)
				{
					this.SetFadeTargetAlpha(1);
				}
				else
				{
					float num = Mathf.Lerp(this.FadeBeginAlpha, 1f, this.FadeNowTime / this.FadeInTime);
					this.CGDoor.alpha = num;
					this.CGTop.alpha = num;
					if (GUIManager.Instance.bOpenOnIPhoneX)
					{
						this.m_BackBlock_L.enabled = true;
						this.m_BackBlock_R.enabled = true;
						this.m_BackBlock_L.color = new Color(1f, 1f, 1f, 1f - num);
						this.m_BackBlock_R.color = new Color(1f, 1f, 1f, 1f - num);
					}
					if (!this.bHideMainMenu && !this.bHideMainByFIFA)
					{
						this.SetSpecialTimeCG(1f - num);
					}
				}
			}
			else if (this.FadeInOrOut == 2)
			{
				if (this.FadeNowTime >= this.FadeOutTime)
				{
					this.SetFadeTargetAlpha(0);
				}
				else
				{
					float num2 = Mathf.Lerp(this.FadeBeginAlpha, 0f, this.FadeNowTime / this.FadeOutTime);
					this.CGDoor.alpha = num2;
					this.CGTop.alpha = num2;
					if (GUIManager.Instance.bOpenOnIPhoneX)
					{
						this.m_BackBlock_L.enabled = true;
						this.m_BackBlock_R.enabled = true;
						this.m_BackBlock_L.color = new Color(1f, 1f, 1f, 1f - num2);
						this.m_BackBlock_R.color = new Color(1f, 1f, 1f, 1f - num2);
					}
					if (!this.bHideMainMenu && !this.bHideMainByFIFA)
					{
						this.SetSpecialTimeCG(1f - num2);
					}
				}
			}
		}
	}

	// Token: 0x06000D1F RID: 3359 RVA: 0x001360D8 File Offset: 0x001342D8
	private void SetSpecialTimeCG(float TargetAlpha)
	{
		for (int i = 0; i < this.SpecialTimeCG.Length; i++)
		{
			this.SpecialTimeCG[i].alpha = TargetAlpha;
		}
	}

	// Token: 0x06000D20 RID: 3360 RVA: 0x0013610C File Offset: 0x0013430C
	private void ReSetPressPosition()
	{
		DataManager.msgBuffer[0] = 132;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06000D21 RID: 3361 RVA: 0x00136128 File Offset: 0x00134328
	private void TrackBackGround()
	{
		if (!this.m_Background.gameObject.activeInHierarchy)
		{
			return;
		}
		Vector3 rotationRate = Input.gyro.rotationRate;
		rotationRate.x *= 0.5f;
		rotationRate.y *= 0.5f;
		this.BackGroundMoved += rotationRate;
		if (this.BackGroundMoved.x < -40f)
		{
			this.BackGroundMoved.x = -40f;
		}
		else if (this.BackGroundMoved.x > 40f)
		{
			this.BackGroundMoved.x = 40f;
		}
		if (this.BackGroundMoved.y < -40f)
		{
			this.BackGroundMoved.y = -40f;
		}
		else if (this.BackGroundMoved.y > 40f)
		{
			this.BackGroundMoved.y = 40f;
		}
		this.m_Background.localPosition = new Vector3(this.BackGroundMoved.y, this.BackGroundMoved.x, this.m_Background.localPosition.z);
	}

	// Token: 0x0400294A RID: 10570
	private const byte FuncBtnCount = 6;

	// Token: 0x0400294B RID: 10571
	private const float m_DuringTime = 10f;

	// Token: 0x0400294C RID: 10572
	private const float m_AnimBtnTime = 0.2f;

	// Token: 0x0400294D RID: 10573
	private const byte QueueMinCount = 1;

	// Token: 0x0400294E RID: 10574
	private const int MoveDistance = 40;

	// Token: 0x0400294F RID: 10575
	private List<GUIWindowStackData> _m_WindowStack;

	// Token: 0x04002950 RID: 10576
	public EUIOriginMode m_eMode;

	// Token: 0x04002951 RID: 10577
	public EUIOriginMapMode m_eMapMode;

	// Token: 0x04002952 RID: 10578
	private Dictionary<int, Sprite> m_SpriteDict = new Dictionary<int, Sprite>();

	// Token: 0x04002953 RID: 10579
	public RectTransform m_Background;

	// Token: 0x04002954 RID: 10580
	public RectTransform m_BackBlock;

	// Token: 0x04002955 RID: 10581
	public RectTransform m_AlertBlock;

	// Token: 0x04002956 RID: 10582
	public RectTransform m_ChatBox;

	// Token: 0x04002957 RID: 10583
	public RectTransform m_ChatScrollRectRC;

	// Token: 0x04002958 RID: 10584
	private CScrollRect m_ChatScrollRect;

	// Token: 0x04002959 RID: 10585
	private Image m_ChatChannelLight;

	// Token: 0x0400295A RID: 10586
	private UISpritesArray m_BackBlockSA;

	// Token: 0x0400295B RID: 10587
	private Image m_BackBlock_L;

	// Token: 0x0400295C RID: 10588
	private Image m_BackBlock_R;

	// Token: 0x0400295D RID: 10589
	private Image m_BackBlock_B;

	// Token: 0x0400295E RID: 10590
	private Image m_AlertBlock_T;

	// Token: 0x0400295F RID: 10591
	private Image m_AlertBlock_B;

	// Token: 0x04002960 RID: 10592
	private Image m_AlertBlock_R;

	// Token: 0x04002961 RID: 10593
	private Image m_AlertBlock_L;

	// Token: 0x04002962 RID: 10594
	private RectTransform m_TerritoryPanel;

	// Token: 0x04002963 RID: 10595
	public UIButton m_BattleButton;

	// Token: 0x04002964 RID: 10596
	private RectTransform m_MapFuncPanel;

	// Token: 0x04002965 RID: 10597
	private Image m_MapFuncBG;

	// Token: 0x04002966 RID: 10598
	private UISpritesArray m_FullMapButton;

	// Token: 0x04002967 RID: 10599
	public bool bHideMainMenu;

	// Token: 0x04002968 RID: 10600
	public bool bHideMainByFIFA;

	// Token: 0x04002969 RID: 10601
	private UIButton m_LocationBox;

	// Token: 0x0400296A RID: 10602
	private Image m_LocationBoxBG;

	// Token: 0x0400296B RID: 10603
	private Image m_LocationBoxIcon;

	// Token: 0x0400296C RID: 10604
	private UIText m_LocationXText;

	// Token: 0x0400296D RID: 10605
	private UIText m_LocationYText;

	// Token: 0x0400296E RID: 10606
	private CString LocXStr;

	// Token: 0x0400296F RID: 10607
	private CString LocYStr;

	// Token: 0x04002970 RID: 10608
	private CString LocXStrFIFA;

	// Token: 0x04002971 RID: 10609
	private CString LocYStrFIFA;

	// Token: 0x04002972 RID: 10610
	private UIButton m_HomeButton;

	// Token: 0x04002973 RID: 10611
	private UIText m_HomeDistText;

	// Token: 0x04002974 RID: 10612
	private CString HomeStr;

	// Token: 0x04002975 RID: 10613
	public ushort m_CapitalLocationX;

	// Token: 0x04002976 RID: 10614
	public ushort m_CapitalLocationY;

	// Token: 0x04002977 RID: 10615
	public ushort m_HomeLocationX;

	// Token: 0x04002978 RID: 10616
	public ushort m_HomeLocationY;

	// Token: 0x04002979 RID: 10617
	private bool bShowHomeBtn;

	// Token: 0x0400297A RID: 10618
	private Vector2 HomeBtnPos = Vector2.zero;

	// Token: 0x0400297B RID: 10619
	private Transform m_HomeArrowT;

	// Token: 0x0400297C RID: 10620
	private Quaternion HomeArrowtarget = new Quaternion(0f, 0f, 0f, 0f);

	// Token: 0x0400297D RID: 10621
	private GameObject PVPTimeObj;

	// Token: 0x0400297E RID: 10622
	private Image PVPWonderImg;

	// Token: 0x0400297F RID: 10623
	private Material PVPWonderImgMaterial;

	// Token: 0x04002980 RID: 10624
	private UIText PVPTimeText;

	// Token: 0x04002981 RID: 10625
	private ushort PVPWonderID = 40;

	// Token: 0x04002982 RID: 10626
	private CString PVPStr;

	// Token: 0x04002983 RID: 10627
	private CString PVPTimeStr;

	// Token: 0x04002984 RID: 10628
	private GameObject KVKTimeObj;

	// Token: 0x04002985 RID: 10629
	private UISpritesArray KVKTimeSA;

	// Token: 0x04002986 RID: 10630
	private UIText KVKTimeText;

	// Token: 0x04002987 RID: 10631
	private CString KVKStr;

	// Token: 0x04002988 RID: 10632
	private CString KVKTimeStr;

	// Token: 0x04002989 RID: 10633
	public GameObject FIFATimeObj;

	// Token: 0x0400298A RID: 10634
	private UIText FIFATimeText;

	// Token: 0x0400298B RID: 10635
	private CString FIFAStr;

	// Token: 0x0400298C RID: 10636
	private CString FIFATimeStr;

	// Token: 0x0400298D RID: 10637
	private CanvasGroup[] SpecialTimeCG = new CanvasGroup[3];

	// Token: 0x0400298E RID: 10638
	private GameObject FIFA_FindBtn;

	// Token: 0x0400298F RID: 10639
	private bool bShowFIFA_FindBtn;

	// Token: 0x04002990 RID: 10640
	private GameObject FIFA_UITop;

	// Token: 0x04002991 RID: 10641
	private RectTransform m_ResourcePanel;

	// Token: 0x04002992 RID: 10642
	public Image[] m_ResourceIcon;

	// Token: 0x04002993 RID: 10643
	private Image[] m_ResourceBar;

	// Token: 0x04002994 RID: 10644
	private UIText[] m_ResourceText;

	// Token: 0x04002995 RID: 10645
	private CString[] m_ResourceStr;

	// Token: 0x04002996 RID: 10646
	private Color[] m_ResourceColor;

	// Token: 0x04002997 RID: 10647
	private Color ResourceSColor = new Color(1f, 0.925f, 0.529f);

	// Token: 0x04002998 RID: 10648
	private float ResourceRedTime;

	// Token: 0x04002999 RID: 10649
	private bool bResourceRed;

	// Token: 0x0400299A RID: 10650
	public RectTransform m_TopLayer;

	// Token: 0x0400299B RID: 10651
	private RectTransform m_FuncPanel;

	// Token: 0x0400299C RID: 10652
	private UIButton m_FuncPanelBG;

	// Token: 0x0400299D RID: 10653
	private Image m_FuncBG;

	// Token: 0x0400299E RID: 10654
	private Image m_ShowFuncIcon;

	// Token: 0x0400299F RID: 10655
	public CanvasGroup m_MapSwitchButton;

	// Token: 0x040029A0 RID: 10656
	private UISpritesArray m_MapSwitchImage;

	// Token: 0x040029A1 RID: 10657
	private Image m_MapSwitchImage2;

	// Token: 0x040029A2 RID: 10658
	public byte m_bShowFuncButton = 1;

	// Token: 0x040029A3 RID: 10659
	private byte m_bOldShowFuncButton;

	// Token: 0x040029A4 RID: 10660
	private float m_ShowFuncTime;

	// Token: 0x040029A5 RID: 10661
	private float m_FuncBGWidth;

	// Token: 0x040029A6 RID: 10662
	private float m_SFuncBGWidth;

	// Token: 0x040029A7 RID: 10663
	private float m_ShowFuncPosX;

	// Token: 0x040029A8 RID: 10664
	private byte FunButtonShowCount;

	// Token: 0x040029A9 RID: 10665
	public RectTransform[] m_SFuncRC;

	// Token: 0x040029AA RID: 10666
	public CanvasGroup[] m_SFuncCG;

	// Token: 0x040029AB RID: 10667
	private float[] m_SFuncPosX;

	// Token: 0x040029AC RID: 10668
	public RectTransform[] m_FuncRC;

	// Token: 0x040029AD RID: 10669
	public CanvasGroup[] m_FuncCG;

	// Token: 0x040029AE RID: 10670
	public GameObject[] m_FuncLight;

	// Token: 0x040029AF RID: 10671
	private float[] m_FuncPosX;

	// Token: 0x040029B0 RID: 10672
	private RectTransform[] m_FuncBtnCountRC;

	// Token: 0x040029B1 RID: 10673
	private UIText[] m_FuncBtnText;

	// Token: 0x040029B2 RID: 10674
	public int[] m_FuncBtnCount;

	// Token: 0x040029B3 RID: 10675
	private CString[] m_FuncBtnCountStr;

	// Token: 0x040029B4 RID: 10676
	private GameObject m_ShowFuncButton;

	// Token: 0x040029B5 RID: 10677
	private GameObject m_ShowFuncButtonAlert;

	// Token: 0x040029B6 RID: 10678
	private GameObject m_MissionAlert;

	// Token: 0x040029B7 RID: 10679
	private GameObject m_AllianceGift;

	// Token: 0x040029B8 RID: 10680
	private GameObject m_RallyRecFlash;

	// Token: 0x040029B9 RID: 10681
	private GameObject m_OtherGift;

	// Token: 0x040029BA RID: 10682
	private GameObject m_MissionFlash;

	// Token: 0x040029BB RID: 10683
	private GameObject m_OtherAlert;

	// Token: 0x040029BC RID: 10684
	private bool bCanEquip;

	// Token: 0x040029BD RID: 10685
	private bool bCanEvolutionStar;

	// Token: 0x040029BE RID: 10686
	private bool bCanEvolutionRank;

	// Token: 0x040029BF RID: 10687
	private bool bCanShowSkillPoint;

	// Token: 0x040029C0 RID: 10688
	public bool bCanRecruit;

	// Token: 0x040029C1 RID: 10689
	private Image SPGiftImgMain;

	// Token: 0x040029C2 RID: 10690
	private Image SPGiftImgAlly;

	// Token: 0x040029C3 RID: 10691
	private Image LiveImgMain;

	// Token: 0x040029C4 RID: 10692
	private Image LiveImgOther;

	// Token: 0x040029C5 RID: 10693
	private uTweenScale LiveImgMainTW;

	// Token: 0x040029C6 RID: 10694
	private uTweenScale LiveImgOtherTW;

	// Token: 0x040029C7 RID: 10695
	private uTweenAlpha LiveImgMainTWF;

	// Token: 0x040029C8 RID: 10696
	private uTweenAlpha LiveImgOtherTWF;

	// Token: 0x040029C9 RID: 10697
	public RectTransform m_RolePanel;

	// Token: 0x040029CA RID: 10698
	public Image m_HeadImage;

	// Token: 0x040029CB RID: 10699
	private UIButton m_HeadIcon;

	// Token: 0x040029CC RID: 10700
	public UIButton m_VIPIcon;

	// Token: 0x040029CD RID: 10701
	private UIText m_VipText;

	// Token: 0x040029CE RID: 10702
	private CString m_VIPStr;

	// Token: 0x040029CF RID: 10703
	public UIButton m_PowerBtn;

	// Token: 0x040029D0 RID: 10704
	private UIText m_Power;

	// Token: 0x040029D1 RID: 10705
	private CString m_PowerStr;

	// Token: 0x040029D2 RID: 10706
	private UIText m_Level;

	// Token: 0x040029D3 RID: 10707
	private CString m_LevelStr;

	// Token: 0x040029D4 RID: 10708
	private GameObject m_HeadBoxFlash;

	// Token: 0x040029D5 RID: 10709
	private GameObject m_HeadBoxJail;

	// Token: 0x040029D6 RID: 10710
	private RectTransform m_MoneyPanel;

	// Token: 0x040029D7 RID: 10711
	private UIButton m_DiamondBox;

	// Token: 0x040029D8 RID: 10712
	public Image m_DiamondIcon;

	// Token: 0x040029D9 RID: 10713
	private Image m_DiamondPlus;

	// Token: 0x040029DA RID: 10714
	private UIText m_DiamondText;

	// Token: 0x040029DB RID: 10715
	public UIButton m_MoraleBox;

	// Token: 0x040029DC RID: 10716
	public Image m_MoraleIcon;

	// Token: 0x040029DD RID: 10717
	public Image m_MoraleForceBlood;

	// Token: 0x040029DE RID: 10718
	public Image m_MoraleFlash;

	// Token: 0x040029DF RID: 10719
	private UISpritesArray m_MoraleSA;

	// Token: 0x040029E0 RID: 10720
	private UISpritesArray m_MoraleSA2;

	// Token: 0x040029E1 RID: 10721
	private UIButtonHint m_MoraleIconHint;

	// Token: 0x040029E2 RID: 10722
	private UIText m_MoraleText;

	// Token: 0x040029E3 RID: 10723
	private Image m_MoraleHintBox;

	// Token: 0x040029E4 RID: 10724
	private UIText m_MoraleHintText;

	// Token: 0x040029E5 RID: 10725
	private CString MoraleString;

	// Token: 0x040029E6 RID: 10726
	private CString DiamondString;

	// Token: 0x040029E7 RID: 10727
	private bool bMoraleHintOpen;

	// Token: 0x040029E8 RID: 10728
	private CString MoraleHintString;

	// Token: 0x040029E9 RID: 10729
	private long MoraleHintTime;

	// Token: 0x040029EA RID: 10730
	private long MonsterTime;

	// Token: 0x040029EB RID: 10731
	private uint ForceTime;

	// Token: 0x040029EC RID: 10732
	private RectTransform m_AlertPanel;

	// Token: 0x040029ED RID: 10733
	private UIButton m_AttackedAlert;

	// Token: 0x040029EE RID: 10734
	private UISpritesArray m_AttackedAlertSA;

	// Token: 0x040029EF RID: 10735
	private UISpritesArray m_AttackedAlertSA2;

	// Token: 0x040029F0 RID: 10736
	private UISpritesArray m_AttackedAlertBackSA;

	// Token: 0x040029F1 RID: 10737
	private UISpritesArray m_AttackedAlertBackSA2;

	// Token: 0x040029F2 RID: 10738
	private RectTransform m_AttackedAlertRC;

	// Token: 0x040029F3 RID: 10739
	private UIText m_AttackedAlertText;

	// Token: 0x040029F4 RID: 10740
	private CString m_AttackedAlertStr;

	// Token: 0x040029F5 RID: 10741
	private UIButton m_HelpAlert;

	// Token: 0x040029F6 RID: 10742
	private RectTransform m_HelpAlertRC;

	// Token: 0x040029F7 RID: 10743
	private UIText m_HelpAlertext;

	// Token: 0x040029F8 RID: 10744
	private CString m_HelpAlertStr;

	// Token: 0x040029F9 RID: 10745
	private GameObject m_HelpAlertImageGO;

	// Token: 0x040029FA RID: 10746
	private UIText m_HelpAlertext2;

	// Token: 0x040029FB RID: 10747
	private CString m_HelpAlertStr2;

	// Token: 0x040029FC RID: 10748
	private Image m_HelpAlertL;

	// Token: 0x040029FD RID: 10749
	private Image m_HelpAlertR;

	// Token: 0x040029FE RID: 10750
	public UISpritesArray m_HelpAlertSA;

	// Token: 0x040029FF RID: 10751
	private UISpritesArray m_AllianceFreeSA1;

	// Token: 0x04002A00 RID: 10752
	private UISpritesArray m_AllianceFreeSA2;

	// Token: 0x04002A01 RID: 10753
	private UIButton m_AllianceFree;

	// Token: 0x04002A02 RID: 10754
	private UIText m_AllianceFreetext;

	// Token: 0x04002A03 RID: 10755
	private UIButton m_TroopsBtn;

	// Token: 0x04002A04 RID: 10756
	private RectTransform m_TroopsRC;

	// Token: 0x04002A05 RID: 10757
	private UIText m_TroopsText;

	// Token: 0x04002A06 RID: 10758
	private CString m_TroopsAlertStr;

	// Token: 0x04002A07 RID: 10759
	public UIButton m_BuffBtn;

	// Token: 0x04002A08 RID: 10760
	public RectTransform m_BuffRC;

	// Token: 0x04002A09 RID: 10761
	public RectTransform m_BuffRC2;

	// Token: 0x04002A0A RID: 10762
	private UIText m_BuffText;

	// Token: 0x04002A0B RID: 10763
	private UIText m_BuffText2;

	// Token: 0x04002A0C RID: 10764
	private CString m_BuffAlertStr;

	// Token: 0x04002A0D RID: 10765
	private CString m_BuffAlertStr2;

	// Token: 0x04002A0E RID: 10766
	private UISpritesArray m_BuffSA;

	// Token: 0x04002A0F RID: 10767
	private float BuffRedTime;

	// Token: 0x04002A10 RID: 10768
	private float BuffTextTime;

	// Token: 0x04002A11 RID: 10769
	private bool bBuffRed;

	// Token: 0x04002A12 RID: 10770
	public Transform m_ActivityBtnT;

	// Token: 0x04002A13 RID: 10771
	public CanvasGroup m_ActivityBtnCG;

	// Token: 0x04002A14 RID: 10772
	public Image m_ActivityBtnImg;

	// Token: 0x04002A15 RID: 10773
	public UISpritesArray m_ActivityBackSA;

	// Token: 0x04002A16 RID: 10774
	public UIText m_ActivityTitleText;

	// Token: 0x04002A17 RID: 10775
	public UIText m_ActivityTimeText;

	// Token: 0x04002A18 RID: 10776
	public Image m_FlashKVKImg;

	// Token: 0x04002A19 RID: 10777
	public GameObject m_ActivityAlert;

	// Token: 0x04002A1A RID: 10778
	private GameObject m_TreasureBoxObject;

	// Token: 0x04002A1B RID: 10779
	private UIButton m_TreasureBox;

	// Token: 0x04002A1C RID: 10780
	private GameObject m_TreasureBoxFlash;

	// Token: 0x04002A1D RID: 10781
	private GameObject m_TreasureBoxFlash_5x;

	// Token: 0x04002A1E RID: 10782
	private UISpritesArray m_TreasureBoxSA;

	// Token: 0x04002A1F RID: 10783
	private uTweenPosition m_TreasureBoxPos;

	// Token: 0x04002A20 RID: 10784
	private uTweenScale m_TreasureBoxScale;

	// Token: 0x04002A21 RID: 10785
	private UIText m_TreasureBoxtext;

	// Token: 0x04002A22 RID: 10786
	private CString m_TreasureBoxStr;

	// Token: 0x04002A23 RID: 10787
	public Transform m_MissionHintTrans;

	// Token: 0x04002A24 RID: 10788
	private RectTransform m_MissionHintRC;

	// Token: 0x04002A25 RID: 10789
	private RectTransform m_MissionHintRRC;

	// Token: 0x04002A26 RID: 10790
	private UISpritesArray m_MissionHintSA;

	// Token: 0x04002A27 RID: 10791
	public UIButton m_MissionBtn;

	// Token: 0x04002A28 RID: 10792
	public uButtonScale m_MissionScale;

	// Token: 0x04002A29 RID: 10793
	private UIText m_MissionHinttextL;

	// Token: 0x04002A2A RID: 10794
	private UIText m_MissionHinttextR;

	// Token: 0x04002A2B RID: 10795
	private CString m_MissionHintStrR;

	// Token: 0x04002A2C RID: 10796
	private Image NewMissionReward;

	// Token: 0x04002A2D RID: 10797
	private float RewardTime;

	// Token: 0x04002A2E RID: 10798
	private float MaxRewardTime = 1f;

	// Token: 0x04002A2F RID: 10799
	private uTweenScale m_MissionBtnTS;

	// Token: 0x04002A30 RID: 10800
	private RectTransform m_MissionBtnRect;

	// Token: 0x04002A31 RID: 10801
	private float m_TickBeginAnimBtnTime = 10f;

	// Token: 0x04002A32 RID: 10802
	private float m_TickEndAnimBtnTime = 0.2f;

	// Token: 0x04002A33 RID: 10803
	public GameObject m_MallGO;

	// Token: 0x04002A34 RID: 10804
	public SpriteAnimation SpriteA;

	// Token: 0x04002A35 RID: 10805
	public GameObject m_MallImageGO;

	// Token: 0x04002A36 RID: 10806
	public UIText m_MallText;

	// Token: 0x04002A37 RID: 10807
	public CString m_MallStr;

	// Token: 0x04002A38 RID: 10808
	public GameObject m_DaBauBtnGO;

	// Token: 0x04002A39 RID: 10809
	public GameObject m_PetSkillBtnGO;

	// Token: 0x04002A3A RID: 10810
	public GameObject m_PetSkillBtnFlashGO;

	// Token: 0x04002A3B RID: 10811
	private RectTransform m_PetSkillCountRC;

	// Token: 0x04002A3C RID: 10812
	private UIText m_PetSkillText;

	// Token: 0x04002A3D RID: 10813
	private CString m_PetSkillStr;

	// Token: 0x04002A3E RID: 10814
	public UIRunningTextEX RunningText;

	// Token: 0x04002A3F RID: 10815
	private GameObject m_FBBtnGO;

	// Token: 0x04002A40 RID: 10816
	private UISpritesArray m_FBBtnSA;

	// Token: 0x04002A41 RID: 10817
	private RectTransform m_FBBtnCountRC;

	// Token: 0x04002A42 RID: 10818
	private UIText m_FBBtnCountText;

	// Token: 0x04002A43 RID: 10819
	private CString m_FBBtnCountStr;

	// Token: 0x04002A44 RID: 10820
	private GameObject m_FBBtnTimeGO;

	// Token: 0x04002A45 RID: 10821
	private UIText m_FBBtnTimeText;

	// Token: 0x04002A46 RID: 10822
	private CString m_FBBtnTimeStr;

	// Token: 0x04002A47 RID: 10823
	private GameObject m_FBBtnAlertGO;

	// Token: 0x04002A48 RID: 10824
	public bool m_FBTimeEnd;

	// Token: 0x04002A49 RID: 10825
	public byte m_FBUIType;

	// Token: 0x04002A4A RID: 10826
	private RectTransform m_SpTopPanel;

	// Token: 0x04002A4B RID: 10827
	public RectTransform m_ArrowRC;

	// Token: 0x04002A4C RID: 10828
	public uTweenPosition m_ArrowPos;

	// Token: 0x04002A4D RID: 10829
	private RectTransform m_TimeBarPanel;

	// Token: 0x04002A4E RID: 10830
	private RectTransform m_QueuePanel;

	// Token: 0x04002A4F RID: 10831
	public UITimeBar[] m_QueueTimeBar;

	// Token: 0x04002A50 RID: 10832
	private Image[] m_QueueTimeBarIcon;

	// Token: 0x04002A51 RID: 10833
	private byte m_QueueCount;

	// Token: 0x04002A52 RID: 10834
	private UIButton m_QueueButton;

	// Token: 0x04002A53 RID: 10835
	private Image m_QueueIcon;

	// Token: 0x04002A54 RID: 10836
	private RectTransform m_QueueCountBox;

	// Token: 0x04002A55 RID: 10837
	private UIText m_QueueCountText;

	// Token: 0x04002A56 RID: 10838
	private CString m_QueueCountStr;

	// Token: 0x04002A57 RID: 10839
	private bool bShowLoadingImg;

	// Token: 0x04002A58 RID: 10840
	private Transform LoadingImgT;

	// Token: 0x04002A59 RID: 10841
	public UIGroundInfo m_GroundInfo;

	// Token: 0x04002A5A RID: 10842
	private Animation FightButton;

	// Token: 0x04002A5B RID: 10843
	private AnimationState FightButtonAS;

	// Token: 0x04002A5C RID: 10844
	private AnimationState FightButtonAS_Touch;

	// Token: 0x04002A5D RID: 10845
	private SkinnedMeshRenderer FightButtonSMR;

	// Token: 0x04002A5E RID: 10846
	private float PlayFightTime;

	// Token: 0x04002A5F RID: 10847
	private float PlayTouchTime;

	// Token: 0x04002A60 RID: 10848
	private Vector3 Vec3 = Vector3.zero;

	// Token: 0x04002A61 RID: 10849
	private string FightName = "fight";

	// Token: 0x04002A62 RID: 10850
	private string TouchName = "touch";

	// Token: 0x04002A63 RID: 10851
	private int FightassetKey;

	// Token: 0x04002A64 RID: 10852
	public int MailPage;

	// Token: 0x04002A65 RID: 10853
	public MapTile TileMapController;

	// Token: 0x04002A66 RID: 10854
	private GameObject KingdomMarkGameObject;

	// Token: 0x04002A67 RID: 10855
	private UIText KingdomMarkText;

	// Token: 0x04002A68 RID: 10856
	private CString KingdomMarkString;

	// Token: 0x04002A69 RID: 10857
	private GameObject KVKTransBtnGO;

	// Token: 0x04002A6A RID: 10858
	private UISpritesArray KVKTransBtnSA;

	// Token: 0x04002A6B RID: 10859
	private UIText[] RBText = new UIText[2];

	// Token: 0x04002A6C RID: 10860
	private GameObject EffectObj;

	// Token: 0x04002A6D RID: 10861
	private float FadeInTime = 0.25f;

	// Token: 0x04002A6E RID: 10862
	private float FadeOutTime = 0.5f;

	// Token: 0x04002A6F RID: 10863
	private float FadeNowTime;

	// Token: 0x04002A70 RID: 10864
	private float FadeBeginAlpha;

	// Token: 0x04002A71 RID: 10865
	private byte FadeInOrOut;

	// Token: 0x04002A72 RID: 10866
	private CanvasGroup CGDoor;

	// Token: 0x04002A73 RID: 10867
	private CanvasGroup CGTop;

	// Token: 0x04002A74 RID: 10868
	private RectTransform m_iPhonePanel;

	// Token: 0x04002A75 RID: 10869
	private GUIManager GM = GUIManager.Instance;

	// Token: 0x04002A76 RID: 10870
	private DataManager DM = DataManager.Instance;

	// Token: 0x04002A77 RID: 10871
	private static readonly int[] MapEffectCanvasLayer = new int[]
	{
		5,
		5,
		5
	};

	// Token: 0x04002A78 RID: 10872
	private Vector3 BackGroundMoved = new Vector3(0f, 0f, 0f);

	// Token: 0x04002A79 RID: 10873
	private bool isTrackBackGround;
}
