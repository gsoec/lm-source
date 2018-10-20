using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using uTools;

// Token: 0x020001AC RID: 428
public class GUIManager : IPagemove, UILoadImageHander, IUIButtonClickHandler
{
	// Token: 0x060005E5 RID: 1509 RVA: 0x000821D0 File Offset: 0x000803D0
	private GUIManager()
	{
		GameObject gameObject = new GameObject("EventSystem");
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		gameObject.AddComponent<EventSystem>();
		gameObject.AddComponent<CusStandaloneInputModule>();
		gameObject.AddComponent<CusTouchInputModule>();
		gameObject = new GameObject("Canvas");
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		gameObject.layer = 5;
		this.m_UICanvas = gameObject.AddComponent<Canvas>();
		this.m_UICanvas.renderMode = RenderMode.ScreenSpaceOverlay;
		gameObject.AddComponent<GraphicRaycaster>();
		CanvasScaler canvasScaler = gameObject.AddComponent<CanvasScaler>();
		canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		canvasScaler.referenceResolution = GUIManager.ResolutionSize;
		canvasScaler.matchWidthOrHeight = 1f;
		this.m_UICanvas.worldCamera = Camera.main;
		this.m_UICanvas.planeDistance = 16f;
		this.m_UICanvas2GO = new GameObject("Canvas2");
		this.m_UICanvas2GO.layer = 5;
		this.m_UICanvas2GO.AddComponent<RectTransform>();
		this.m_UICanvas2 = this.m_UICanvas2GO.AddComponent<Canvas>();
		this.m_UICanvas2.renderMode = RenderMode.ScreenSpaceOverlay;
		this.m_UICanvas2.sortingOrder = 2;
		this.m_UICanvas2GO.AddComponent<GraphicRaycaster>();
		canvasScaler = this.m_UICanvas2GO.AddComponent<CanvasScaler>();
		canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		canvasScaler.referenceResolution = GUIManager.ResolutionSize;
		canvasScaler.matchWidthOrHeight = 1f;
		this.m_BottomLayer = new GameObject("BottomLayer")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_BottomLayer.SetParent(this.m_UICanvas.transform, false);
		this.StretchTransform(this.m_BottomLayer);
		this.pDVMgr = new DamageValueManager(this.m_BottomLayer);
		this.m_WindowsTransform = new GameObject("Windows")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_WindowsTransform.SetParent(this.m_UICanvas.transform, false);
		this.StretchTransform(this.m_WindowsTransform);
		this.m_WindowList = new GUIWindow[197];
		if (this.IsArabic)
		{
			this.m_WindowsTransform.localScale = new Vector3(-this.m_WindowsTransform.localScale.x, this.m_WindowsTransform.localScale.y, this.m_WindowsTransform.localScale.z);
		}
		this.m_ChatLayer = new GameObject("ChatLayer")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_ChatLayer.SetParent(this.m_UICanvas.transform, false);
		this.StretchTransform(this.m_ChatLayer);
		if (this.IsArabic)
		{
			this.m_ChatLayer.localScale = new Vector3(-this.m_ChatLayer.localScale.x, this.m_ChatLayer.localScale.y, this.m_ChatLayer.localScale.z);
		}
		this.m_TopLayer = new GameObject("TopLayer")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_TopLayer.SetParent(this.m_UICanvas.transform, false);
		this.StretchTransform(this.m_TopLayer);
		if (this.IsArabic)
		{
			this.m_TopLayer.localScale = new Vector3(-this.m_TopLayer.localScale.x, this.m_TopLayer.localScale.y, this.m_TopLayer.localScale.z);
		}
		this.m_WindowTopLayer = new GameObject("WindowTopLayer")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_WindowTopLayer.SetParent(this.m_TopLayer, false);
		this.StretchTransform(this.m_WindowTopLayer);
		this.m_ItemInfoLayer = new GameObject("ItemInfoLayer")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_ItemInfoLayer.SetParent(this.m_TopLayer, false);
		this.StretchTransform(this.m_ItemInfoLayer);
		this.m_BattleMessageLayer = new GameObject("BattleMessageLayer")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_BattleMessageLayer.SetParent(this.m_WindowTopLayer, false);
		this.StretchTransform(this.m_BattleMessageLayer);
		this.m_SecWindowLayer = new GameObject("SecWindowLayer")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_SecWindowLayer.SetParent(this.m_WindowTopLayer, false);
		this.StretchTransform(this.m_SecWindowLayer);
		this.m_FourthWindowLayer = new GameObject("FourthWindowLayer")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_FourthWindowLayer.SetParent(this.m_TopLayer, false);
		this.StretchTransform(this.m_FourthWindowLayer);
		this.m_NewbieLayer = new GameObject("NewbieLayer")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_NewbieLayer.SetParent(this.m_TopLayer, false);
		this.StretchTransform(this.m_NewbieLayer);
		this.m_MessageBoxLayer = new GameObject("MessageBoxLayer")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_MessageBoxLayer.SetParent(this.m_TopLayer, false);
		this.StretchTransform(this.m_MessageBoxLayer);
		this.m_HUDsTransform = new GameObject("HUDs")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_HUDsTransform.SetParent(this.m_TopLayer, false);
		this.StretchTransform(this.m_HUDsTransform);
		this.pDVMgr.SetTransitionLayer(this.m_UICanvas2GO.transform);
		this.m_LockPanelLayer = new GameObject("LockPanelLayer")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_LockPanelLayer.SetParent(this.m_UICanvas2GO.transform, false);
		this.StretchTransform(this.m_LockPanelLayer);
		this.m_HUDMessage = new HUDMessageMgr();
		this.BuildingData = new BuildsData();
		this.m_TimeBarList = new List<UITimeBar>();
		this.m_AttackedAlertCount = new int[15];
		this.m_AttackedAlertTCount = 0;
		this.MsgStr = new CString(1024);
		this.MsgTitleStr = StringManager.Instance.SpawnString(300);
		this.MsgBtnStr = StringManager.Instance.SpawnString(150);
		this.InitSynthesisUISaveData();
		this.upgradePanelDataPool = new ObjectPool<BuildInfoObject>(new BuildInfoObject(), 20, false);
		this.upgradeEffectDataPool = new ObjectPool<BuildInfoObject2>(new BuildInfoObject2(), 6, false);
		this.m_HeroList_Soldier_ItemDataPool = new ObjectPool<HeroList_Soldier_Item>(new HeroList_Soldier_Item(), (DataManager.Instance.MaxCurHeroData + 2) * 5, false);
		this.m_HeroList_Soldier_ItemDataPool2 = new ObjectPool<SoldierScrollItem>(new SoldierScrollItem(), 102, false);
		for (int i = 0; i < 5; i++)
		{
			this.WM_HeroData[i] = default(HeroBattleData);
		}
		this.InitialBackMessageBox();
		this.SendTag = new CString(3);
		this.SendName = new CString(13);
		this.CanonizedName = StringManager.Instance.SpawnString(30);
		this.m_BuildingTopIdx = 0;
		this.m_BuildingPosY = 0f;
		this.EmojiManager = new EmojiCenter();
	}

	// Token: 0x17000040 RID: 64
	// (get) Token: 0x060005E7 RID: 1511 RVA: 0x00082DE0 File Offset: 0x00080FE0
	public static GUIManager Instance
	{
		get
		{
			if (GUIManager.instance == null)
			{
				GUIManager.instance = new GUIManager();
			}
			return GUIManager.instance;
		}
	}

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x060005E8 RID: 1512 RVA: 0x00082DFC File Offset: 0x00080FFC
	public Sprite NpcHead
	{
		get
		{
			if (this.WondericonAssKey == 0)
			{
				this.InitWondersSprite();
			}
			return this._NpcHead;
		}
	}

	// Token: 0x17000042 RID: 66
	// (get) Token: 0x060005E9 RID: 1513 RVA: 0x00082E18 File Offset: 0x00081018
	public Material m_WonderMaterial
	{
		get
		{
			if (this.WondericonAssKey == 0)
			{
				this.InitWondersSprite();
			}
			return this._m_WonderMaterial;
		}
	}

	// Token: 0x17000043 RID: 67
	// (get) Token: 0x060005EA RID: 1514 RVA: 0x00082E34 File Offset: 0x00081034
	public bool bAutoTranslate
	{
		get
		{
			return IGGGameSDK.Instance.GetTranslateStatus() && DataManager.Instance.MySysSetting.bAutoTranslate;
		}
	}

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x060005EB RID: 1515 RVA: 0x00082E58 File Offset: 0x00081058
	public bool IsArabic
	{
		get
		{
			return DataManager.Instance.UserLanguage == GameLanguage.GL_Arb;
		}
	}

	// Token: 0x060005EC RID: 1516 RVA: 0x00082E68 File Offset: 0x00081068
	public void Update()
	{
		if (this.bRebuildFont)
		{
			this.bRebuildFont = false;
			GameManager.OnRefresh(NetworkNews.Refresh_FontTextureRebuilt, null);
			if (this.LTWin != null)
			{
				this.LTWin.UpdateUI(10, 0);
			}
		}
		this.UpDateCanvas();
		this.m_HUDMessage.Update();
		if (!this.m_bLoadAsset)
		{
			return;
		}
		if (this.m_eUILock != EUILock.Normal)
		{
			float uilockTime = this.m_UILockTime;
			this.m_UILockTime += Time.deltaTime;
			if (this.m_UILockTime >= 0.5f)
			{
				int num = (int)((uilockTime - 0.5f) * 10f);
				int num2 = (int)((this.m_UILockTime - 0.5f) * 10f);
				if (uilockTime < 0.5f)
				{
					for (int i = 0; i < this.m_LockPanel.childCount; i++)
					{
						this.m_LockPanel.GetChild(i).gameObject.SetActive(true);
					}
				}
				else if (num != num2)
				{
					RectTransform rectTransform = (RectTransform)this.m_LockPanel.GetChild(this.m_LockPanel.transform.childCount - 1);
					Vector2 anchoredPosition = rectTransform.anchoredPosition;
					Quaternion localRotation = rectTransform.localRotation;
					for (int j = 0; j < this.m_LockPanel.childCount; j++)
					{
						rectTransform = (RectTransform)this.m_LockPanel.GetChild(j);
						Vector2 anchoredPosition2 = rectTransform.anchoredPosition;
						rectTransform.anchoredPosition = anchoredPosition;
						anchoredPosition = anchoredPosition2;
						Quaternion localRotation2 = rectTransform.localRotation;
						rectTransform.localRotation = localRotation;
						localRotation = localRotation2;
					}
				}
			}
			if (this.m_UILockTime >= 2f)
			{
				this.m_UILockTime = 1f;
			}
		}
		this.pDVMgr.UpdateRun();
		this.UpDatePvPUI();
		this.UpDateWonderCountTime();
		if (this.bBackTranslate)
		{
			this.BackTranslate();
		}
		if (this.bBackTranslateBatch)
		{
			this.BackTranslateBatch();
		}
		if (this.bBackTranslateFail != 0)
		{
			this.BackTranslateFail();
		}
		if (this.bBackTranslateBatch_MB)
		{
			this.MB_BackTranslateBatch();
		}
		if (this.bBackTranslateFail_MB != 0)
		{
			this.MB_BackTranslateFail();
		}
		Indemnify.UpdateRun();
		LightmapManager.Instance.Update();
		MotionEffect.Update();
		bool flag = DataManager.Instance.ServerTime != this.m_LastServerTime;
		for (int k = 0; k < this.m_TimeBarList.Count; k++)
		{
			if (this.m_TimeBarList[k] != null)
			{
				if (flag)
				{
					this.m_TimeBarList[k].UpdateTimeText(DataManager.Instance.ServerTime);
				}
				if (this.m_TimeBarList[k].UpdateTime(NetworkManager.ServerTime))
				{
					this.RemoverTimeBaarToList(this.m_TimeBarList[k]);
				}
			}
		}
		this.UpdateLordEquip(flag);
		if (this.m_Window1 != null)
		{
			this.m_Window1.UpdateTime(flag);
		}
		if (this.m_Window2 != null)
		{
			this.m_Window2.UpdateTime(flag);
		}
		if (this.m_SecWindow != null)
		{
			this.m_SecWindow.UpdateTime(flag);
		}
		if (this.m_OtheCanvas != null)
		{
			this.m_OtheCanvas.UpdateTime(flag);
		}
		if (flag)
		{
			this.CheckBackMessage();
			this.CheckNPCRewardHUD();
			this.m_LastServerTime = DataManager.Instance.ServerTime;
		}
		if (this.m_BMTime > 0f && this.m_OKCancelClickIndex != 1)
		{
			this.m_BMTime -= Time.unscaledDeltaTime;
			if (!this.bSendShow && this.m_BMTime <= 0f)
			{
				this.CloseBattleMessage();
			}
			else if (this.m_BMLight != null)
			{
				float num3 = Mathf.Clamp(this.m_BMLightTime / this.m_BMLightMaxTime, 0f, 1f);
				Color color = this.m_BMLight.color;
				this.m_BMLight.rectTransform.localScale = Vector3.one * 0.9f + Vector3.one * (0.5f * num3);
				if (num3 < 0.5f)
				{
					color.a = num3 * 2f;
				}
				else
				{
					color.a = 1f - (num3 - 0.5f) / 0.5f;
				}
				this.m_BMLight.color = color;
				this.m_BMLightTime += Time.unscaledDeltaTime;
				if (this.m_BMLightTime > this.m_BMLightMaxTime)
				{
					this.m_BMLightTime = 0f;
				}
			}
		}
		if (this.m_AttackedAlertTCount > 0)
		{
			if (this.bAddAlertImageAlpha)
			{
				this.AlertImageSA.m_Image.color += new Color(0f, 0f, 0f, Time.deltaTime);
			}
			else
			{
				this.AlertImageSA.m_Image.color -= new Color(0f, 0f, 0f, Time.deltaTime);
			}
			if (this.AlertImageSA.m_Image.color.a <= 0.3f)
			{
				this.bAddAlertImageAlpha = true;
			}
			if (this.AlertImageSA.m_Image.color.a >= 1f)
			{
				this.bAddAlertImageAlpha = false;
			}
			Door door = this.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.SetAlertImageAlpha(this.AlertImageSA.m_Image.color.a);
			}
			UIBattle uibattle = this.FindMenu(EGUIWindow.UI_Battle) as UIBattle;
			if (uibattle != null)
			{
				uibattle.SetAlertImageAlpha(this.AlertImageSA.m_Image.color.a);
			}
			UILegBattle uilegBattle = this.FindMenu(EGUIWindow.UI_LegBattle) as UILegBattle;
			if (uilegBattle != null)
			{
				uilegBattle.SetAlertImageAlpha(this.AlertImageSA.m_Image.color.a);
			}
			UIBattle_Gambling uibattle_Gambling = this.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
			if (uibattle_Gambling != null)
			{
				uibattle_Gambling.SetAlertImageAlpha(this.AlertImageSA.m_Image.color.a);
			}
		}
		if (Input.GetKeyDown(KeyCode.Escape) && this.m_UILockCount == 0 && this.m_eUILock == EUILock.Normal)
		{
			if (UIInput.IsOpen() || NewbieManager.IsWorking())
			{
				return;
			}
			if (AntiAddictive.Instance.GetAnitAddicitvDlgStage() == NotificationStage.Stage5)
			{
				return;
			}
			if (this.m_BackMGGO != null)
			{
				this.ReleaseBackMessageBox();
				return;
			}
			if (this.m_CheckCrystalBox != null)
			{
				if (this.m_CheckCrystalCloseButton != null)
				{
					this.OnButtonClick(this.m_CheckCrystalCloseButton);
				}
				else
				{
					this.CloseCheckCrystalBox();
				}
				return;
			}
			if (this.m_OKCancelBox != null)
			{
				if (this.m_OKCancelCloseButton != null)
				{
					this.OnButtonClick(this.m_OKCancelCloseButton);
				}
				else
				{
					this.CloseOKCancelBox();
				}
				return;
			}
			if (this.Obj_UICalculator != null)
			{
				UnityEngine.Object.Destroy(this.Obj_UICalculator);
				this.Obj_UICalculator = null;
				this.m_UICalculator.mUnitRslider = null;
				return;
			}
			if (this.m_ItemInfo.m_RectTransform.gameObject.activeSelf)
			{
				this.m_ItemInfo.Hide();
			}
			if (BattleController.IsGambleMode)
			{
				GamblingManager.Instance.OnBackButtonClick();
				return;
			}
			if (this.m_SecWindow != null)
			{
				if (this.m_SecWindow.m_eWindow == EGUIWindow.UI_NewTerritory)
				{
					DataManager.msgBuffer[0] = 20;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
				else
				{
					if (this.FindMenu(EGUIWindow.UI_Synthesis) != null)
					{
						GUIManager.Instance.m_IsOpenedUISynthesis = false;
					}
					this.CloseMenu(this.m_SecWindow.m_eWindow);
					this.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
				}
				return;
			}
			GUIWindow guiwindow;
			if (this.m_OtheCanvas != null)
			{
				guiwindow = this.FindMenu(EGUIWindow.UI_HeroTalk);
				if (guiwindow != null)
				{
					GUIManager.instance.CloseMenu(EGUIWindow.UI_HeroTalk);
					DataManager.msgBuffer[0] = 2;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
				guiwindow = this.FindMenu(EGUIWindow.UI_TreasureBox);
				if (guiwindow != null && !guiwindow.OnBackButtonClick())
				{
					GUIManager.instance.CloseMenu(EGUIWindow.UI_TreasureBox);
					this.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
				}
				guiwindow = this.FindMenu(EGUIWindow.UI_PetLevelUp);
				if (guiwindow != null && !guiwindow.OnBackButtonClick())
				{
					GUIManager.instance.CloseMenu(EGUIWindow.UI_PetLevelUp);
					this.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
				}
				return;
			}
			guiwindow = this.FindMenu(EGUIWindow.Door);
			if (guiwindow == null)
			{
				guiwindow = ((!(this.m_Window2 != null)) ? this.m_Window1 : this.m_Window2);
			}
			if (guiwindow != null)
			{
				guiwindow.OnBackButtonClick();
			}
		}
		if (this.m_SpeciallyEffect != null)
		{
			this.m_SpeciallyEffect.UpdateRun();
		}
		if (this.UpdateArrow > 1)
		{
			this.UpdateArrow -= 1;
		}
		else if (this.UpdateArrow == 1)
		{
			this.UpdateArrow = 0;
			if (this.ArrowParentRect != null && this.ArrowRect != null)
			{
				this.ArrowRect.SetParent(this.ArrowParentRect);
				this.ArrowRect.localScale = Vector3.one;
			}
		}
		this.m_Hint.Update();
		if (this.TechABRequest != null && this.TechABRequest.isDone)
		{
			GameObject gameObject = this.TechABRequest.asset as GameObject;
			this.TechIconArray = gameObject.transform.GetComponent<UISpritesArray>();
			this.TechIconArrayCN = gameObject.transform.GetChild(0).GetComponent<UISpritesArray>();
			this._TechMaterial = gameObject.transform.GetComponent<Image>().material;
			this.TechABRequest = null;
			this.UpdateUI(this._TechUpdateUI, -1, 0);
		}
		this.m_BeginChangeTime += Time.deltaTime;
		if (this.m_BeginChangeTime >= 3f)
		{
			this.m_ChangeTime += Time.deltaTime;
			if (this.m_ChangeTime >= 0.05f)
			{
				byte curQueueBarDataCount = DataManager.Instance.curQueueBarDataCount;
				Door door2 = this.FindMenu(EGUIWindow.Door) as Door;
				this.m_FlashCount -= 0.05f;
				if (this.m_FlashCount <= 0f)
				{
					if (this.m_TextIdx == 0)
					{
						this.m_TextIdx = 1;
					}
					else
					{
						this.m_TextIdx = 0;
					}
					for (int l = 0; l < this.m_TimeBarList.Count; l++)
					{
						if (this.m_TimeBarList[l] != null)
						{
							this.m_TimeBarList[l].SetTitleText();
						}
					}
					if (door2 != null)
					{
						int num4 = 0;
						while (num4 < (int)curQueueBarDataCount && num4 < door2.m_QueueTimeBar.Length)
						{
							if (door2.m_QueueTimeBar[num4].m_TimerSpriteType == eTimerSpriteType.RallyCountDown || door2.m_QueueTimeBar[num4].m_TimerSpriteType == eTimerSpriteType.Mobilization_Report || door2.m_QueueTimeBar[num4].m_TimerSpriteType == eTimerSpriteType.Mobilization_fail || door2.m_QueueTimeBar[num4].m_TimerSpriteType == eTimerSpriteType.NPCRewardEnd)
							{
								door2.m_QueueTimeBar[num4].SetTitleText();
							}
							num4++;
						}
					}
					this.m_FlashCount = 1f;
					this.m_ChangeTime = 0f;
					this.m_BeginChangeTime = 0f;
				}
				for (int m = 0; m < this.m_TimeBarList.Count; m++)
				{
					if (this.m_TimeBarList[m] != null)
					{
						this.m_TimeBarList[m].SetTitleTextColor();
					}
				}
				if (door2 != null)
				{
					int num5 = 0;
					while (num5 < (int)curQueueBarDataCount && num5 < door2.m_QueueTimeBar.Length)
					{
						if (num5 == 0 || door2.m_QueueTimeBar[num5].m_TimerSpriteType == eTimerSpriteType.RallyCountDown || door2.m_QueueTimeBar[num5].m_TimerSpriteType == eTimerSpriteType.Mobilization_Report || door2.m_QueueTimeBar[num5].m_TimerSpriteType == eTimerSpriteType.Mobilization_fail || door2.m_QueueTimeBar[num5].m_TimerSpriteType == eTimerSpriteType.NPCRewardEnd)
						{
							door2.m_QueueTimeBar[num5].SetTitleTextColor();
						}
						num5++;
					}
				}
				this.m_ChangeTime = 0f;
			}
		}
		if (this.m_OKCancelBox != null && this.MsgBarTimeText != null && this.MsgBarImage != null)
		{
			float msgBarTimeSec = this.MsgBarTimeSec;
			this.MsgBarTimeSec -= Time.deltaTime;
			if (this.MsgBarTimeSec < 0f)
			{
				this.MsgBarTimeSec = 0f;
			}
			if ((uint)msgBarTimeSec - (uint)this.MsgBarTimeSec >= 1u)
			{
				GUIManager.Instance.SetMsgBarTimeAndFill(this.MsgBarTimeSec, this.MaxBarTimeSec);
			}
			else if (msgBarTimeSec == 0f)
			{
				this.CloseOKCancelBox();
			}
		}
		this.EmojiManager.Run();
	}

	// Token: 0x060005ED RID: 1517 RVA: 0x00083C10 File Offset: 0x00081E10
	public void UpdateNext()
	{
		if (this.m_SecWindow != null)
		{
			this.CloseMenu(this.m_SecWindow.m_eWindow);
		}
		if (this.m_OtheCanvas != null)
		{
			this.CloseMenu(this.m_OtheCanvas.m_eWindow);
		}
		if (this.m_Chat != null && this.m_Chat.activeInHierarchy)
		{
			this.m_Chat.SetActive(false);
			this.m_WindowList[14] = null;
		}
		int i = 0;
		while (i < this.m_WindowsTransform.childCount)
		{
			Transform child = this.m_WindowsTransform.GetChild(i);
			GUIWindow component = child.GetComponent<GUIWindow>();
			if (!(component != null))
			{
				goto IL_F8;
			}
			if (!component.m_bDontDestroyOnSwitch && !(this.m_WindowList[(int)component.m_eWindow] == null))
			{
				component.OnClose();
				this.m_WindowList[(int)component.m_eWindow] = null;
				AssetManager.UnloadAssetBundle(component.m_AssetBundleKey, true);
				component.m_AssetBundle = null;
				component.m_AssetBundleKey = 0;
				goto IL_F8;
			}
			IL_103:
			i++;
			continue;
			IL_F8:
			UnityEngine.Object.Destroy(child.gameObject);
			goto IL_103;
		}
		if (this.bClearWindowStack)
		{
			this.m_WindowStack.Clear();
		}
	}

	// Token: 0x060005EE RID: 1518 RVA: 0x00083D4C File Offset: 0x00081F4C
	public void UpdateNetwork(byte[] meg)
	{
		if (this.m_Window1 != null)
		{
			this.m_Window1.UpdateNetwork(meg);
		}
		if (this.m_Window2 != null)
		{
			this.m_Window2.UpdateNetwork(meg);
		}
		if (this.m_SecWindow != null)
		{
			this.m_SecWindow.UpdateNetwork(meg);
		}
		if (this.m_OtheCanvas != null)
		{
			this.m_OtheCanvas.UpdateNetwork(meg);
		}
		if (this.Chatwin != null && this.m_Chat != null && this.m_Chat.activeInHierarchy)
		{
			this.Chatwin.UpdateNetwork(meg);
		}
		if (this.m_ActivityWindow != null)
		{
			this.m_ActivityWindow.UpdateNetwork(meg);
		}
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
			this.UpdateChatBox(9, 0);
			this.CloseCheckCrystalBox();
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				if (this.m_ChatBox != null)
				{
					for (int i = 0; i < 2; i++)
					{
						if (this.m_ChatChannel[i] != null)
						{
							this.m_ChatChannel[i].m_ChatText[0].enabled = false;
							this.m_ChatChannel[i].m_ChatText[0].enabled = true;
							this.m_ChatChannel[i].m_ChatText[1].enabled = false;
							this.m_ChatChannel[i].m_ChatText[1].enabled = true;
						}
					}
					if (this.NoAllianceText != null && this.NoAllianceText.enabled)
					{
						this.NoAllianceText.enabled = false;
						this.NoAllianceText.enabled = true;
					}
				}
				if (this.m_BMGO != null)
				{
					if (this.m_BMBtnText != null && this.m_BMBtnText.enabled)
					{
						this.m_BMBtnText.enabled = false;
						this.m_BMBtnText.enabled = true;
					}
					if (this.m_BMText1 != null && this.m_BMText1.enabled)
					{
						this.m_BMText1.enabled = false;
						this.m_BMText1.enabled = true;
					}
					if (this.m_BMText2 != null && this.m_BMText2.enabled)
					{
						this.m_BMText2.enabled = false;
						this.m_BMText2.enabled = true;
					}
				}
				if (this.m_CheckCrystalBox != null)
				{
					for (int j = 0; j < this.CheckCrystalText.Length; j++)
					{
						if (this.CheckCrystalText[j] != null && this.CheckCrystalText[j].enabled)
						{
							this.CheckCrystalText[j].enabled = false;
							this.CheckCrystalText[j].enabled = true;
						}
					}
				}
				if (this.m_OKCancelBox != null)
				{
					for (int k = 0; k < this.m_MsgText.Count; k++)
					{
						if (this.m_MsgText[k] != null && this.m_MsgText[k].enabled)
						{
							this.m_MsgText[k].enabled = false;
							this.m_MsgText[k].enabled = true;
						}
					}
				}
				if (this.m_BattleBeginGO != null)
				{
					for (int l = 0; l < this.m_bbText.Length; l++)
					{
						if (!(this.m_bbText[l] == null))
						{
							this.m_bbText[l].enabled = false;
							this.m_bbText[l].enabled = true;
						}
					}
				}
				if (this.m_ItemInfo != null)
				{
					this.m_ItemInfo.TextRefresh();
				}
				if (this.m_SimpleItemInfo != null)
				{
					this.m_SimpleItemInfo.TextRefresh();
				}
				if (this.m_SkillInfo != null)
				{
					this.m_SkillInfo.TextRefresh();
				}
				if (this.m_LordInfo != null)
				{
					this.m_LordInfo.TextRefresh();
				}
				if (this.m_Arena_Hint != null)
				{
					this.m_Arena_Hint.TextRefresh();
				}
				this.m_HUDMessage.TextRefresh();
				if (this.BuildingData.mapspriteManager != null)
				{
					this.BuildingData.mapspriteManager.TextRefresh();
				}
				if (this.m_UICalculator != null)
				{
					this.m_UICalculator.TextRefresh();
				}
				if (this.m_SpeciallyEffect != null)
				{
					this.m_SpeciallyEffect.Refresh_FontTexture();
				}
				if (this.m_Hint != null)
				{
					this.m_Hint.TextRefresh();
				}
				if (this.pDVMgr != null)
				{
					this.pDVMgr.RebuiltFont();
				}
			}
			break;
		case NetworkNews.Refresh_Asset:
			if (meg[1] == 2)
			{
				MallManager.Instance.UpDateDownLoad(meg);
			}
			else if (meg[1] == 4)
			{
				ActivityManager.Instance.UpDateDownLoad(meg);
			}
			break;
		}
		NewbieManager.UpdateNetwork(meg);
	}

	// Token: 0x060005EF RID: 1519 RVA: 0x0008425C File Offset: 0x0008245C
	private void OnFontTextureRebuilt(Font changedFont)
	{
		if (changedFont != this.m_TTFFont)
		{
			return;
		}
		this.bRebuildFont = true;
	}

	// Token: 0x060005F0 RID: 1520 RVA: 0x00084278 File Offset: 0x00082478
	public void LoadFont()
	{
		if (this.m_TTFFont == null)
		{
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
			{
				this.m_TTFFont = Resources.GetBuiltinResource<Font>("Arial.ttf");
				Font.textureRebuilt += this.OnFontTextureRebuilt;
			}
			else
			{
				int num;
				this.m_TTFFontBundle = AssetManager.GetAssetBundle("UI/TTFFont", out num, false);
				if (this.m_TTFFontBundle != null)
				{
					this.m_TTFFont = (Font)this.m_TTFFontBundle.mainAsset;
					Font.textureRebuilt += this.OnFontTextureRebuilt;
				}
			}
			Texture mainTexture = this.m_TTFFont.material.mainTexture;
			DataManager dataManager = DataManager.Instance;
			uint num2 = 0u;
			uint num3 = 10u;
			int num4 = dataManager.mStringTable.RecordAmount / 2;
			int num5 = 72;
			while ((ulong)num2 < (ulong)((long)num4) && (mainTexture.width < 2048 || mainTexture.height < 2048))
			{
				for (uint num6 = 1u; num6 <= num3; num6 += 1u)
				{
					string stringByID = dataManager.mStringTable.GetStringByID(num6 + num2);
					if (stringByID != null)
					{
						this.m_TTFFont.RequestCharactersInTexture(stringByID, num5);
					}
				}
				num2 += num3;
				if (num5 == 72 && (mainTexture.width > 1024 || mainTexture.height > 1024))
				{
					num5 = 26;
				}
			}
		}
	}

	// Token: 0x060005F1 RID: 1521 RVA: 0x000843EC File Offset: 0x000825EC
	public void InitialMessageBox()
	{
		this.m_FrameSpriteAsset.InitialAsset("UI_frame");
		this.m_ManagerAssetBundle2 = AssetManager.GetAssetBundle("UI/ManagerAsset2", out this.m_ManagerAssetBundleKey2, false);
	}

	// Token: 0x060005F2 RID: 1522 RVA: 0x00084418 File Offset: 0x00082618
	public void UnloadMessageBox()
	{
		this.m_FrameSpriteAsset.UnloadAsset();
		if (this.m_ManagerAssetBundleKey2 != 0)
		{
			AssetManager.UnloadAssetBundle(this.m_ManagerAssetBundleKey2, true);
			this.m_ManagerAssetBundle2 = null;
			this.m_ManagerAssetBundleKey2 = 0;
		}
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x00084458 File Offset: 0x00082658
	public void InitialAssets()
	{
		this.LoadFont();
		this.m_bLoadAsset = true;
		this.m_SpriteAssetDict = new Dictionary<int, SpriteAsset>();
		this.m_IconSpriteAsset.InitialAsset("UI_icon");
		this.m_ItemIconSpriteAsset.InitialAsset("UI_itemicon");
		this.m_LeadItemIconSpriteAsset.InitialAsset("UI_leadicon");
		this.m_LeadMatIconSpriteAsset.InitialAsset("UI_leadmaticon");
		this.m_FrameSpriteAsset.InitialAsset("UI_frame");
		this.m_BadgeSpriteAsset.InitialAsset("UI_league_badge");
		this.m_TotemSpriteAsset.InitialAsset("UI_league_totem");
		this.m_SkillSpriteAsset.InitialAsset("UI_skill");
		this.m_AllianceBoxAsset.InitialAsset("UIAllianceBox");
		this.m_LeagueGO_iconAsset.InitialAsset("LeagueGO_icon");
		this.m_ConditiontIconSpriteAsset.InitialAsset("UI_ConditionIcon");
		this.m_TitleSpriteAsset.InitialAsset("UI_Titleicon");
		this.m_ManagerAssetBundle = AssetManager.GetAssetBundle("UI/ManagerAsset", out this.m_ManagerAssetBundleKey, false);
		if (this.m_ManagerAssetBundle != null)
		{
			this.m_ItemInfo.Load();
			this.m_SimpleItemInfo.Load();
			this.m_SkillInfo.Load();
			this.m_LordInfo.Load();
			this.HintMaskObj.Load();
			this.m_Hint.Load();
		}
		this.m_Arena_HintAssetBundle = AssetManager.GetAssetBundle("UI/UIArena_Hint", out this.m_Arena_HintAssetBundleKey, false);
		this.m_Arena_Hint.Load();
		this.m_ManagerAssetBundle2 = AssetManager.GetAssetBundle("UI/ManagerAsset2", out this.m_ManagerAssetBundleKey2, false);
		this.m_EffectAssetBundle = AssetManager.GetAssetBundle("UI/SpeciallyEffect", out this.m_EffectAssetBundleKey, false);
		this.m_SpeciallyEffect.Load();
		this.m_CalculatorAssetBundle = AssetManager.GetAssetBundle("UI/UICalculator", out this.m_CalculatorAssetBundleKey, false);
		this.CreateAttackStateImg();
		this.m_HUDMessage.Init();
		this.m_FastivalIconSet = new Dictionary<byte, int>();
		this.bGPShow = true;
	}

	// Token: 0x060005F4 RID: 1524 RVA: 0x0008463C File Offset: 0x0008283C
	public void InitMapSprite()
	{
		if (this.MapSpriteKey != 0)
		{
			return;
		}
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/Building", out this.MapSpriteKey, false);
		UnityEngine.Object[] array = assetBundle.LoadAll();
		ushort num = 0;
		while ((int)num < array.Length)
		{
			Sprite sprite = array[(int)num] as Sprite;
			if (sprite != null)
			{
				this.MapIconDict.Add(sprite.name.GetHashCode(), sprite);
			}
			else if (array[(int)num] as Material)
			{
				if (array[(int)num].name == "building")
				{
					this.MapSpriteMaterial = (array[(int)num] as Material);
				}
				else
				{
					this.MapSpriteUIMaterial = (array[(int)num] as Material);
				}
			}
			num += 1;
		}
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x00084700 File Offset: 0x00082900
	public void InitTowerSprite()
	{
		if (this.MapSpriteKey != 0)
		{
			return;
		}
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/Tower", out this.MapSpriteKey, false);
		UnityEngine.Object[] array = assetBundle.LoadAll();
		ushort num = 0;
		while ((int)num < array.Length)
		{
			Sprite sprite = array[(int)num] as Sprite;
			if (sprite != null)
			{
				this.MapIconDict.Add(sprite.name.GetHashCode(), sprite);
			}
			else if (array[(int)num] as Material)
			{
				this.MapSpriteUIMaterial = (array[(int)num] as Material);
			}
			num += 1;
		}
	}

	// Token: 0x060005F6 RID: 1526 RVA: 0x00084798 File Offset: 0x00082998
	public unsafe void InitWondersSprite()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat("UI_Wonders_icon");
		cstring.AppendFormat("UI/{0}");
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.WondericonAssKey);
		if (assetBundle == null)
		{
			return;
		}
		UnityEngine.Object[] array = assetBundle.LoadAll(typeof(Sprite));
		cstring.ClearString();
		cstring.StringToFormat("UI_Wonders_icon");
		cstring.AppendFormat("{0}_m");
		this._m_WonderMaterial = (assetBundle.Load(cstring.ToString(), typeof(Material)) as Material);
		if (this.m_WondersiconSprite == null || this.m_WondersiconSprite.Length < array.Length)
		{
			this.m_WondersiconSprite = new Sprite[array.Length];
		}
		for (int i = 0; i < array.Length; i++)
		{
			Sprite sprite = array[i] as Sprite;
			if (!(sprite == null))
			{
				cstring.ClearString();
				fixed (string text = sprite.name)
				{
					fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
					{
						int j;
						for (j = sprite.name.Length; j >= 0; j--)
						{
							if (ptr[j] == '_')
							{
								break;
							}
						}
						text = null;
						this.m_WondersiconSprite[int.Parse(sprite.name.Substring(j + 1))] = sprite;
					}
				}
			}
		}
		if (9 < this.m_WondersiconSprite.Length)
		{
			this._NpcHead = this.m_WondersiconSprite[9];
		}
		else
		{
			this._NpcHead = this.m_WondersiconSprite[0];
		}
	}

	// Token: 0x060005F7 RID: 1527 RVA: 0x0008492C File Offset: 0x00082B2C
	public Sprite GetWonderSprite(byte wonderID, ushort kingdomID = 0, byte forcdeKvK = 0)
	{
		if (this.WondericonAssKey == 0)
		{
			this.InitWondersSprite();
		}
		bool flag = false;
		if (forcdeKvK > 0)
		{
			flag = true;
		}
		else
		{
			EActivityState eventState = ActivityManager.Instance.KvKActivityData[4].EventState;
			if (ActivityManager.Instance.IsInKvK(0, false) && eventState != EActivityState.EAS_Prepare && kingdomID > 0 && DataManager.MapDataController.kingdomData.kingdomID != kingdomID)
			{
				flag = true;
			}
			ushort num = (kingdomID != 0) ? kingdomID : DataManager.MapDataController.OtherKingdomData.kingdomID;
			if (!ActivityManager.Instance.IsInKvK(0, false) || num == ActivityManager.Instance.KOWKingdomID || !DataManager.MapDataController.IsEnemy(num))
			{
				flag = false;
			}
		}
		Sprite result;
		if (wonderID == 0)
		{
			if (kingdomID == 0)
			{
				if (flag)
				{
					result = this.m_WondersiconSprite[2];
				}
				else
				{
					int num2;
					if (DataManager.MapDataController.OtherKingdomData.kingdomID == ActivityManager.Instance.KOWKingdomID)
					{
						num2 = 8;
					}
					else
					{
						num2 = (int)(DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.kingdomData.kingdomID).mapID + 2);
					}
					if (this.m_WondersiconSprite.Length > num2)
					{
						result = this.m_WondersiconSprite[num2];
					}
					else
					{
						result = this.m_WondersiconSprite[3];
					}
				}
			}
			else if (flag)
			{
				result = this.m_WondersiconSprite[2];
			}
			else
			{
				int num2;
				if (kingdomID == ActivityManager.Instance.KOWKingdomID)
				{
					num2 = 8;
				}
				else
				{
					num2 = (int)(DataManager.MapDataController.KingdomMapTable.GetRecordByKey(kingdomID).mapID + 2);
				}
				if (this.m_WondersiconSprite.Length > num2)
				{
					result = this.m_WondersiconSprite[num2];
				}
				else
				{
					result = this.m_WondersiconSprite[3];
				}
			}
		}
		else if (flag)
		{
			result = this.m_WondersiconSprite[1];
		}
		else
		{
			KingdomYolkDeploy recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
			int i;
			for (i = 1; i < DataManager.MapDataController.KingdomYolkDeployTable.TableCount; i++)
			{
				recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(i);
				if (recordByIndex.kingdomID == kingdomID)
				{
					break;
				}
			}
			if (i >= DataManager.MapDataController.KingdomYolkDeployTable.TableCount)
			{
				recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
			}
			if ((int)wonderID >= recordByIndex.yolkDeployIDs.Length)
			{
				wonderID = 0;
			}
			ushort inKey = recordByIndex.yolkDeployIDs[(int)wonderID];
			YolkDeploy recordByKey = DataManager.MapDataController.YolkDeployTable.GetRecordByKey(inKey);
			if ((int)recordByKey.iconID < this.m_WondersiconSprite.Length)
			{
				result = this.m_WondersiconSprite[(int)recordByKey.iconID];
			}
			else
			{
				result = this.m_WondersiconSprite[0];
			}
		}
		return result;
	}

	// Token: 0x060005F8 RID: 1528 RVA: 0x00084C04 File Offset: 0x00082E04
	public void UnloadWonderSprite()
	{
		if (this.WondericonAssKey == 0)
		{
			return;
		}
		AssetManager.UnloadAssetBundle(this.WondericonAssKey, true);
		this.WondericonAssKey = 0;
	}

	// Token: 0x060005F9 RID: 1529 RVA: 0x00084C28 File Offset: 0x00082E28
	public void ClearMapSprite()
	{
		AssetManager.UnloadAssetBundle(this.MapSpriteKey, true);
		this.MapSpriteKey = 0;
		this.MapIconDict.Clear();
	}

	// Token: 0x060005FA RID: 1530 RVA: 0x00084C48 File Offset: 0x00082E48
	public void UnloadAssets()
	{
		this.m_bLoadAsset = false;
		if (this.m_SpriteAssetDict != null)
		{
			this.m_SpriteAssetDict.Clear();
		}
		if (this.m_SpriteAssetDict != null)
		{
			this.m_FastivalIconSet.Clear();
		}
		this.m_IconSpriteAsset.UnloadAsset();
		this.m_ItemIconSpriteAsset.UnloadAsset();
		this.m_LeadItemIconSpriteAsset.UnloadAsset();
		this.m_LeadMatIconSpriteAsset.UnloadAsset();
		this.m_FrameSpriteAsset.UnloadAsset();
		this.m_BadgeSpriteAsset.UnloadAsset();
		this.m_TotemSpriteAsset.UnloadAsset();
		this.m_SkillSpriteAsset.UnloadAsset();
		this.m_AllianceBoxAsset.UnloadAsset();
		this.m_LeagueGO_iconAsset.UnloadAsset();
		this.m_ConditiontIconSpriteAsset.UnloadAsset();
		this.m_TitleSpriteAsset.UnloadAsset();
		this.m_EmojiSpriteAsset.UnloadAsset();
		this.UnloadWonderSprite();
		this.CloseCheckCrystalBox();
		if (this.m_OKCancelBox != null)
		{
			UnityEngine.Object.Destroy(this.m_OKCancelBox);
			this.m_OKCancelBox = null;
			this.m_OKCancelCloseButton = null;
			this.m_OKCancelBoxHandler = null;
		}
		this.m_MsgText.Clear();
		if (this.m_LockPanel != null)
		{
			UnityEngine.Object.Destroy(this.m_LockPanel.gameObject);
			this.m_LockPanel = null;
			this.m_eUILock = EUILock.Normal;
			this.m_UILockCount = 0;
		}
		if (this.m_ManagerAssetBundleKey != 0)
		{
			this.m_ItemInfo.Unload();
			this.m_SimpleItemInfo.Unload();
			this.m_SkillInfo.UnLoad();
			this.m_LordInfo.UnLoad();
			this.HintMaskObj.UnLoad();
			this.m_Hint.UnLoad();
			AssetManager.UnloadAssetBundle(this.m_ManagerAssetBundleKey, true);
			this.m_ManagerAssetBundle = null;
			this.m_ManagerAssetBundleKey = 0;
		}
		if (this.m_Arena_HintAssetBundleKey != 0)
		{
			this.m_Arena_Hint.UnLoad();
			AssetManager.UnloadAssetBundle(this.m_Arena_HintAssetBundleKey, true);
			this.m_Arena_HintAssetBundle = null;
			this.m_Arena_HintAssetBundleKey = 0;
		}
		if (this.m_ManagerAssetBundleKey2 != 0)
		{
			AssetManager.UnloadAssetBundle(this.m_ManagerAssetBundleKey2, true);
			this.m_ManagerAssetBundle2 = null;
			this.m_ManagerAssetBundleKey2 = 0;
		}
		if (this.m_EffectAssetBundleKey != 0)
		{
			this.m_SpeciallyEffect.UnLoad();
			AssetManager.UnloadAssetBundle(this.m_EffectAssetBundleKey, true);
			this.m_EffectAssetBundle = null;
			this.m_EffectAssetBundleKey = 0;
		}
		if (this.m_CalculatorAssetBundleKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.m_CalculatorAssetBundleKey, true);
			this.m_CalculatorAssetBundle = null;
			this.m_CalculatorAssetBundleKey = 0;
		}
		if (this.m_BMGO != null)
		{
			this.CloseBattleMessage();
		}
		if (this.m_Chat != null)
		{
			UnityEngine.Object.Destroy(this.m_Chat);
			this.m_Chat = null;
			this.m_WindowList[14] = null;
			this.Chatwin = null;
			AssetManager.UnloadAssetBundle(this.ChatabKey, true);
			this.Chatab = null;
			this.ChatabKey = 0;
			this.window2mode = EUIOriginMode.Show;
		}
		this.ClearBackMessageBox(byte.MaxValue);
		if (this.m_WindowStack != null)
		{
			this.m_WindowStack.Clear();
		}
		this.bClearWindowStack = true;
		this.m_HUDMessage.Destroy();
		this.UIHero_Index = -1;
		this.UIBarrack_Y = -1f;
		this.UIBarrack_TrapY = -1f;
		this.RemoveAllAttackState();
		this.mUIQueueLock = 0;
		this.GUIQueue.Clear();
		if (this.MapEmojiCount != null)
		{
			this.MapEmojiCount.Clear();
			this.MapEmojiCount = null;
		}
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x00084F98 File Offset: 0x00083198
	public Font GetTTFFont()
	{
		return this.m_TTFFont;
	}

	// Token: 0x060005FC RID: 1532 RVA: 0x00084FA0 File Offset: 0x000831A0
	public Material AddSpriteAsset(string AssetName)
	{
		this.Key = AssetName.GetHashCode();
		SpriteAsset value;
		if (!this.m_SpriteAssetDict.TryGetValue(this.Key, out value))
		{
			value.InitialAsset(AssetName);
			if (value.m_AssetBundle == null)
			{
				return null;
			}
			this.m_SpriteAssetDict.Add(this.Key, value);
		}
		else
		{
			value.m_RefCount++;
			this.m_SpriteAssetDict[this.Key] = value;
		}
		return value.m_Material;
	}

	// Token: 0x060005FD RID: 1533 RVA: 0x0008502C File Offset: 0x0008322C
	public void RemoveSpriteAsset(string AssetName)
	{
		this.Key = AssetName.GetHashCode();
		SpriteAsset value;
		if (this.m_SpriteAssetDict.TryGetValue(this.Key, out value))
		{
			value.m_RefCount--;
			this.m_SpriteAssetDict[this.Key] = value;
			if (value.m_RefCount <= 0)
			{
				this.m_SpriteAssetDict.Remove(this.Key);
				value.UnloadAsset();
			}
		}
	}

	// Token: 0x060005FE RID: 1534 RVA: 0x000850A4 File Offset: 0x000832A4
	public Sprite LoadSprite(string AssetName, string SpriteName)
	{
		SpriteAsset spriteAsset;
		if (this.m_SpriteAssetDict.TryGetValue(AssetName.GetHashCode(), out spriteAsset))
		{
			Sprite result;
			spriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(), out result);
			return result;
		}
		return null;
	}

	// Token: 0x060005FF RID: 1535 RVA: 0x000850E4 File Offset: 0x000832E4
	public Sprite LoadSprite(string AssetName, CString SpriteName)
	{
		SpriteAsset spriteAsset;
		if (this.m_SpriteAssetDict.TryGetValue(AssetName.GetHashCode(), out spriteAsset))
		{
			Sprite result;
			spriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out result);
			return result;
		}
		return null;
	}

	// Token: 0x06000600 RID: 1536 RVA: 0x00085124 File Offset: 0x00083324
	public Material LoadMaterial(string AssetName, string MaterialName)
	{
		SpriteAsset spriteAsset;
		if (this.m_SpriteAssetDict.TryGetValue(AssetName.GetHashCode(), out spriteAsset))
		{
			return spriteAsset.m_AssetBundle.Load(MaterialName, typeof(Material)) as Material;
		}
		return null;
	}

	// Token: 0x06000601 RID: 1537 RVA: 0x00085168 File Offset: 0x00083368
	public Sprite LoadFrameSprite(EFrameSprite eFrame, byte id)
	{
		this.LoadSpriteStr.Length = 0;
		switch (eFrame)
		{
		case EFrameSprite.Hero:
			this.LoadSpriteStr.IntToFormat((long)id, 3, false);
			this.LoadSpriteStr.AppendFormat("hf{0:000}");
			break;
		case EFrameSprite.Item:
			this.LoadSpriteStr.IntToFormat((long)id, 3, false);
			this.LoadSpriteStr.AppendFormat("if{0:000}");
			break;
		case EFrameSprite.Lead:
			this.LoadSpriteStr.IntToFormat((long)id, 3, false);
			this.LoadSpriteStr.AppendFormat("lf{0:000}");
			break;
		case EFrameSprite.Jewelry:
			this.LoadSpriteStr.IntToFormat((long)id, 3, false);
			this.LoadSpriteStr.AppendFormat("jf{0:000}");
			break;
		case EFrameSprite.Pet:
			this.LoadSpriteStr.IntToFormat((long)(id + 2), 3, false);
			this.LoadSpriteStr.AppendFormat("hf{0:000}");
			break;
		}
		return this.LoadFrameSprite(this.LoadSpriteStr);
	}

	// Token: 0x06000602 RID: 1538 RVA: 0x0008526C File Offset: 0x0008346C
	public Sprite LoadFrameSprite(string SpriteName)
	{
		Sprite result;
		this.m_FrameSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(), out result);
		return result;
	}

	// Token: 0x06000603 RID: 1539 RVA: 0x00085294 File Offset: 0x00083494
	public Sprite LoadFrameSprite(CString SpriteName)
	{
		Sprite result;
		this.m_FrameSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out result);
		return result;
	}

	// Token: 0x06000604 RID: 1540 RVA: 0x000852BC File Offset: 0x000834BC
	public Material GetFrameMaterial()
	{
		return this.m_FrameSpriteAsset.m_Material;
	}

	// Token: 0x06000605 RID: 1541 RVA: 0x000852CC File Offset: 0x000834CC
	public void SetPointTexture(byte point, Image numImg)
	{
		if (point == 255)
		{
			numImg.sprite = this.LoadFrameSprite("UI_mall_x_001");
		}
		else
		{
			this.LoadSpriteStr.Length = 0;
			this.LoadSpriteStr.IntToFormat((long)point, 1, false);
			this.LoadSpriteStr.AppendFormat("UI_mall_{0}_001");
			numImg.sprite = this.LoadFrameSprite(this.LoadSpriteStr);
		}
		numImg.material = this.GetFrameMaterial();
	}

	// Token: 0x06000606 RID: 1542 RVA: 0x00085344 File Offset: 0x00083544
	public Sprite LoadBadgeSprite(bool bBadge, string SpriteName)
	{
		Sprite result;
		if (bBadge)
		{
			this.m_BadgeSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(), out result);
		}
		else
		{
			this.m_TotemSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(), out result);
		}
		return result;
	}

	// Token: 0x06000607 RID: 1543 RVA: 0x00085390 File Offset: 0x00083590
	public Sprite LoadBadgeSprite(bool bBadge, CString SpriteName)
	{
		Sprite result;
		if (bBadge)
		{
			this.m_BadgeSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out result);
		}
		else
		{
			this.m_TotemSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out result);
		}
		return result;
	}

	// Token: 0x06000608 RID: 1544 RVA: 0x000853E0 File Offset: 0x000835E0
	public Material GetBadgeMaterial(bool bBadge)
	{
		if (bBadge)
		{
			return this.m_BadgeSpriteAsset.m_Material;
		}
		return this.m_TotemSpriteAsset.m_Material;
	}

	// Token: 0x06000609 RID: 1545 RVA: 0x00085400 File Offset: 0x00083600
	public Sprite LoadSkillSprite(string SpriteName)
	{
		Sprite result;
		this.m_SkillSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(), out result);
		return result;
	}

	// Token: 0x0600060A RID: 1546 RVA: 0x00085428 File Offset: 0x00083628
	public Sprite LoadSkillSprite(CString SpriteName)
	{
		Sprite result;
		this.m_SkillSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out result);
		return result;
	}

	// Token: 0x0600060B RID: 1547 RVA: 0x00085450 File Offset: 0x00083650
	public Material GetSkillMaterial()
	{
		return this.m_SkillSpriteAsset.m_Material;
	}

	// Token: 0x0600060C RID: 1548 RVA: 0x00085460 File Offset: 0x00083660
	public Sprite LoadTitleSprite(byte IconID, eTitleKind kind = eTitleKind.KvkTitle)
	{
		this.LoadSpriteStr.Length = 0;
		this.LoadSpriteStr.IntToFormat((long)IconID, 3, false);
		if (kind == eTitleKind.KvkTitle)
		{
			this.LoadSpriteStr.AppendFormat("TI{0:000}");
		}
		else if (kind == eTitleKind.WorldTitle)
		{
			this.LoadSpriteStr.AppendFormat("WT{0:000}");
		}
		else if (kind == eTitleKind.KingdomTitle)
		{
			this.LoadSpriteStr.AppendFormat("KT{0:000}");
		}
		else if (kind == eTitleKind.NobilityTitle)
		{
			this.LoadSpriteStr.AppendFormat("DT{0:000}");
		}
		else
		{
			this.LoadSpriteStr.AppendFormat("TI{0:000}");
		}
		Sprite sprite = null;
		this.m_TitleSpriteAsset.m_Dict.TryGetValue(this.LoadSpriteStr.GetHashCode(false), out sprite);
		if (sprite != null)
		{
			return sprite;
		}
		this.LoadSpriteStr.Length = 0;
		this.LoadSpriteStr.Append("TI000");
		this.m_TitleSpriteAsset.m_Dict.TryGetValue(this.LoadSpriteStr.GetHashCode(false), out sprite);
		return sprite;
	}

	// Token: 0x0600060D RID: 1549 RVA: 0x00085574 File Offset: 0x00083774
	public Material GetTitleMaterial()
	{
		return this.m_TitleSpriteAsset.m_Material;
	}

	// Token: 0x0600060E RID: 1550 RVA: 0x00085584 File Offset: 0x00083784
	public Sprite LoadLeagueGO_iconSprite(CString SpriteName)
	{
		Sprite result;
		if (this.m_LeagueGO_iconAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out result))
		{
			return result;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.Append("000");
		this.m_LeagueGO_iconAsset.m_Dict.TryGetValue(cstring.GetHashCode(false), out result);
		return result;
	}

	// Token: 0x0600060F RID: 1551 RVA: 0x000855E4 File Offset: 0x000837E4
	public Material GetLeagueGO_iconMaterial()
	{
		return this.m_LeagueGO_iconAsset.m_Material;
	}

	// Token: 0x06000610 RID: 1552 RVA: 0x000855F4 File Offset: 0x000837F4
	public Sprite LoadEmojiSprite(string SpriteName)
	{
		Sprite result;
		this.m_EmojiSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(), out result);
		return result;
	}

	// Token: 0x06000611 RID: 1553 RVA: 0x0008561C File Offset: 0x0008381C
	public Sprite LoadEmojiSprite(CString SpriteName)
	{
		Sprite result;
		this.m_EmojiSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out result);
		return result;
	}

	// Token: 0x06000612 RID: 1554 RVA: 0x00085644 File Offset: 0x00083844
	public Material GetEmojiMaterial()
	{
		return this.m_EmojiSpriteAsset.m_Material;
	}

	// Token: 0x06000613 RID: 1555 RVA: 0x00085654 File Offset: 0x00083854
	public void SetAllyRankImage(Image img, byte Rank)
	{
		Door door = this.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			switch (Rank)
			{
			case 1:
				img.sprite = door.LoadSprite("L_vs_badge_02");
				break;
			case 2:
				img.sprite = door.LoadSprite("L_vs_badge_03");
				break;
			case 3:
				img.sprite = door.LoadSprite("L_vs_badge_04");
				break;
			case 4:
				img.sprite = door.LoadSprite("L_vs_badge_05");
				break;
			default:
				img.sprite = door.LoadSprite("L_vs_badge_01");
				break;
			}
			img.material = door.LoadMaterial();
		}
		else
		{
			img.material = this.m_FrameSpriteAsset.m_Material;
		}
	}

	// Token: 0x06000614 RID: 1556 RVA: 0x00085728 File Offset: 0x00083928
	public void SetAllyWarRankImage(Image img, byte Rank)
	{
		Door door = this.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			Rank = ((Rank <= 0) ? 0 : ((Rank - 1) / 5));
			switch (Rank)
			{
			case 0:
				img.sprite = door.LoadSprite("SC_L_vs_badge_01");
				break;
			case 1:
				img.sprite = door.LoadSprite("SC_L_vs_badge_02");
				break;
			case 2:
				img.sprite = door.LoadSprite("SC_L_vs_badge_03");
				break;
			case 3:
				img.sprite = door.LoadSprite("SC_L_vs_badge_04");
				break;
			case 4:
				img.sprite = door.LoadSprite("SC_L_vs_badge_05");
				break;
			default:
				img.sprite = door.LoadSprite("SC_L_vs_badge_01");
				break;
			}
			img.material = door.LoadMaterial();
		}
		else
		{
			img.material = this.m_FrameSpriteAsset.m_Material;
		}
	}

	// Token: 0x06000615 RID: 1557 RVA: 0x0008582C File Offset: 0x00083A2C
	public void StretchTransform(RectTransform tran)
	{
		tran.sizeDelta = Vector2.zero;
		tran.anchorMin = Vector2.zero;
		tran.anchorMax = Vector2.one;
	}

	// Token: 0x06000616 RID: 1558 RVA: 0x0008585C File Offset: 0x00083A5C
	public void UpDateCanvas()
	{
		if (this.m_OrthographicCount == 0)
		{
			return;
		}
		this.m_OrthographicCount += 1;
		int num = (int)(this.m_UICanvas.transform.lossyScale.x * 1000000f);
		if (num == 15625)
		{
			this.m_OrthographicCount = 0;
			this.SetCanvasChanged();
		}
	}

	// Token: 0x06000617 RID: 1559 RVA: 0x000858BC File Offset: 0x00083ABC
	public void SetCameraorthOgraphic(bool orthographic)
	{
		Camera.main.orthographic = orthographic;
		if (orthographic)
		{
			this.m_OrthographicCount = 1;
			this.m_TopLayer.localPosition = Vector3.zero;
			this.m_TopLayer.localScale = Vector3.one;
			if (this.IsArabic)
			{
				this.m_TopLayer.localScale = new Vector3(-this.m_TopLayer.localScale.x, this.m_TopLayer.localScale.y, this.m_TopLayer.localScale.z);
			}
		}
		else
		{
			this.m_OrthographicCount = 0;
			this.SetCanvasChanged();
		}
	}

	// Token: 0x06000618 RID: 1560 RVA: 0x00085968 File Offset: 0x00083B68
	public void SetCanvasChanged()
	{
		Vector3 localPosition = this.m_TopLayer.localPosition;
		if (this.m_UICanvas.renderMode == RenderMode.ScreenSpaceOverlay)
		{
			localPosition.z = 0f;
			this.m_TopLayer.localPosition = localPosition;
			localPosition.x = 1f;
		}
		else if (Camera.main.orthographic)
		{
			localPosition.z = (1f - this.m_UICanvas.planeDistance) / 0.015625f;
			this.m_TopLayer.localPosition = localPosition;
			localPosition.x = 1f;
		}
		else
		{
			localPosition.z = (11f - this.m_UICanvas.planeDistance) / ((Camera.main.fieldOfView != 25f) ? 0.0288675f : 0.0110847f);
			this.m_TopLayer.localPosition = localPosition;
			localPosition.x = 11f / this.m_UICanvas.planeDistance;
		}
		localPosition.y = localPosition.x;
		localPosition.z = localPosition.x;
		this.m_TopLayer.localScale = localPosition;
		if (this.IsArabic)
		{
			this.m_TopLayer.localScale = new Vector3(-this.m_TopLayer.localScale.x, this.m_TopLayer.localScale.y, this.m_TopLayer.localScale.z);
		}
	}

	// Token: 0x06000619 RID: 1561 RVA: 0x00085AE4 File Offset: 0x00083CE4
	public GUIWindow OpenMenu(EGUIWindow eWin, int arg1 = 0, int arg2 = 0, bool bCameraMode = false, bool bSecWindow = false, bool bFromDoor = false)
	{
		GUIManager.Instance.m_SpeciallyEffect.ClearAllEffect();
		if (ActivityGiftManager.Instance.mActGiftEffectParticle != null)
		{
			ActivityGiftManager.Instance.DespawnActivityGiftEffect(false);
		}
		GUIWindow guiwindow = this.m_WindowList[(int)eWin];
		this.HideArrow(false);
		if (eWin == EGUIWindow.UI_Chat)
		{
			if (this.m_Chat == null)
			{
				this.Chatab = AssetManager.GetAssetBundle("UI/UIChat", out this.ChatabKey, false);
				if (this.Chatab == null)
				{
					return null;
				}
				this.m_Chat = (GameObject)UnityEngine.Object.Instantiate(this.Chatab.mainAsset);
				if (this.m_Chat == null)
				{
					AssetManager.UnloadAssetBundle(this.ChatabKey, true);
					return null;
				}
				this.m_Chat.transform.SetParent(this.m_ChatLayer, false);
				this.Chatwin = (GUIWindow)this.m_Chat.AddComponent(WindowPrefabData.Data[(int)eWin].m_WindowType);
				this.m_WindowList[(int)eWin] = this.Chatwin;
				this.Chatwin.m_eWindow = eWin;
				this.Chatwin.m_AssetBundle = this.Chatab;
				this.Chatwin.m_AssetBundleKey = this.ChatabKey;
				this.Chatwin.OnOpen(arg1, arg2);
			}
			else
			{
				this.m_WindowList[(int)eWin] = this.Chatwin;
				this.m_Chat.SetActive(true);
				this.UpdateUI(EGUIWindow.UI_Chat, 9, arg1);
			}
			if (this.m_Window2 != null)
			{
				this.m_Window2.gameObject.SetActive(false);
				Door door = this.FindMenu(EGUIWindow.Door) as Door;
				if (door != null)
				{
					this.window2mode = door.m_eMode;
				}
			}
			this.UpdateUI(EGUIWindow.Door, 1, 9);
			if (bFromDoor)
			{
				Door door2 = this.FindMenu(EGUIWindow.Door) as Door;
				if (door2)
				{
					door2.HideFightButton();
				}
			}
			return this.Chatwin;
		}
		if (!bSecWindow)
		{
			if (this.m_Chat != null && this.m_Chat.activeInHierarchy)
			{
				this.CloseMenu(this.Chatwin.m_eWindow);
			}
			if (guiwindow != null)
			{
				if (guiwindow.m_bDontDestroyOnSwitch)
				{
					guiwindow.m_bDontDestroyOnSwitch = false;
				}
				return guiwindow;
			}
			if (this.m_Window2 != null)
			{
				this.CloseMenu(this.m_Window2.m_eWindow);
			}
		}
		else if (this.m_SecWindow != null)
		{
			this.CloseMenu(this.m_SecWindow.m_eWindow);
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("UI/{0}", WindowPrefabData.Data[(int)eWin].m_PrefabName);
		int num = 0;
		GameObject gameObject = null;
		AssetBundle assetBundle = AssetManager.GetAssetBundle(stringBuilder.ToString(), out num, false);
		if (assetBundle != null)
		{
			UnityEngine.Object @object;
			if (WindowPrefabData.Data[(int)eWin].m_OptName == null)
			{
				@object = assetBundle.mainAsset;
			}
			else
			{
				@object = assetBundle.Load(WindowPrefabData.Data[(int)eWin].m_OptName);
			}
			if (@object)
			{
				gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
			}
		}
		if (gameObject == null)
		{
			AssetManager.UnloadAssetBundle(num, true);
			return null;
		}
		if (bFromDoor)
		{
			Door door3 = this.FindMenu(EGUIWindow.Door) as Door;
			if (door3)
			{
				door3.HideFightButton();
			}
		}
		if (!bSecWindow)
		{
			gameObject.transform.SetParent(this.m_WindowsTransform, false);
		}
		else
		{
			gameObject.transform.SetParent(this.m_SecWindowLayer, false);
		}
		guiwindow = (GUIWindow)gameObject.AddComponent(WindowPrefabData.Data[(int)eWin].m_WindowType);
		this.m_WindowList[(int)eWin] = guiwindow;
		if (!bSecWindow)
		{
			if (this.m_Window1 == null)
			{
				this.m_Window1 = guiwindow;
			}
			else
			{
				this.m_Window2 = guiwindow;
			}
		}
		else
		{
			this.m_SecWindow = guiwindow;
		}
		guiwindow.m_eWindow = eWin;
		guiwindow.m_AssetBundle = assetBundle;
		guiwindow.m_AssetBundleKey = num;
		guiwindow.OnOpen(arg1, arg2);
		if (!bSecWindow && bCameraMode)
		{
			this.m_UICanvas.renderMode = RenderMode.ScreenSpaceCamera;
			this.SetCanvasChanged();
		}
		return guiwindow;
	}

	// Token: 0x0600061A RID: 1562 RVA: 0x00085F2C File Offset: 0x0008412C
	public void CloseMenu(EGUIWindow eWin)
	{
		GUIWindow guiwindow = this.m_WindowList[(int)eWin];
		if (guiwindow == null || guiwindow.m_bDontDestroyOnSwitch)
		{
			return;
		}
		this.HideArrow(false);
		if (eWin == EGUIWindow.UI_Chat)
		{
			this.m_WindowList[(int)eWin] = null;
			this.m_Chat.SetActive(false);
			if (this.m_Window2 != null)
			{
				this.m_Window2.gameObject.SetActive(true);
				this.UpdateUI(EGUIWindow.Door, 1, (int)this.window2mode);
			}
			return;
		}
		if (eWin == EGUIWindow.UI_TreasureBox)
		{
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 20, (ushort)DataManager.Instance.CurHeroDataCount);
			if (DataManager.StageDataController._stageMode == StageMode.Full || DataManager.StageDataController._stageMode == StageMode.Lean)
			{
				DataManager.MissionDataManager.CheckChanged((eMissionKind)((byte)(3 + DataManager.StageDataController._stageMode)), 1, DataManager.StageDataController.StageRecord[(int)DataManager.StageDataController._stageMode]);
			}
		}
		else if (eWin == EGUIWindow.UI_leadup)
		{
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 6, (ushort)DataManager.Instance.RoleAttr.Level);
		}
		guiwindow.OnClose();
		this.m_WindowList[(int)eWin] = null;
		bool flag = false;
		if (guiwindow == this.m_Window1)
		{
			this.m_Window1 = null;
		}
		else if (guiwindow == this.m_Window2)
		{
			this.m_Window2 = null;
		}
		else if (guiwindow == this.m_SecWindow)
		{
			this.m_SecWindow = null;
			flag = true;
		}
		else if (guiwindow == this.m_OtheCanvas)
		{
			if (NewbieManager.IsNewbie)
			{
				this.UpdateUI(EGUIWindow.UI_Front, 3, 0);
			}
			this.m_OtheCanvas = null;
			this.DestoryOtherCanvas();
			flag = true;
		}
		if (!flag && this.m_UICanvas.renderMode != RenderMode.ScreenSpaceOverlay)
		{
			this.m_UICanvas.renderMode = RenderMode.ScreenSpaceOverlay;
			this.SetCanvasChanged();
		}
		AssetManager.UnloadAssetBundle(guiwindow.m_AssetBundleKey, true);
		guiwindow.m_AssetBundle = null;
		guiwindow.m_AssetBundleKey = 0;
		UnityEngine.Object.Destroy(guiwindow.gameObject);
		GC.Collect();
	}

	// Token: 0x0600061B RID: 1563 RVA: 0x0008613C File Offset: 0x0008433C
	public GUIWindow FindMenu(EGUIWindow eWin)
	{
		return this.m_WindowList[(int)eWin];
	}

	// Token: 0x0600061C RID: 1564 RVA: 0x00086148 File Offset: 0x00084348
	public void UpdateUI(EGUIWindow eWin, int arg1, int arg2 = 0)
	{
		if (eWin == EGUIWindow.UI_Chat)
		{
			if (this.m_Chat != null && this.m_Chat.activeInHierarchy)
			{
				this.Chatwin.UpdateUI(arg1, arg2);
			}
		}
		else
		{
			GUIWindow guiwindow = this.FindMenu(eWin);
			if (guiwindow != null)
			{
				guiwindow.UpdateUI(arg1, arg2);
			}
		}
	}

	// Token: 0x0600061D RID: 1565 RVA: 0x000861AC File Offset: 0x000843AC
	public void SetMsgBarTimeAndFill(float TimeSec, float MaxTimeSec)
	{
		if (this.MsgBarTimeText != null)
		{
			this.MsgBarStr.Length = 0;
			GameConstants.GetTimeString(this.MsgBarStr, (uint)TimeSec, false, true, false, false, true);
			this.MsgBarTimeText.text = this.MsgBarStr.ToString();
			this.MsgBarTimeText.SetAllDirty();
			this.MsgBarTimeText.cachedTextGenerator.Invalidate();
			this.MsgBarTimeText.cachedTextGeneratorForLayout.Invalidate();
			this.MsgBarTimeSec = TimeSec;
		}
		if (this.MsgBarImage != null && MaxTimeSec != 0f)
		{
			this.MaxBarTimeSec = MaxTimeSec;
			this.MsgBarImage.fillAmount = (this.MaxBarTimeSec - TimeSec + 1f) / this.MaxBarTimeSec;
		}
	}

	// Token: 0x0600061E RID: 1566 RVA: 0x00086274 File Offset: 0x00084474
	private bool OKCancelNoWindow(bool bOK, int arg1, int arg2)
	{
		switch (this.m_OKCancelClickIndex)
		{
		case 0:
			this.useOrSpendType = UseOrSpendType.UST_MAX;
			break;
		case 1:
			if (bOK)
			{
				DataManager dataManager = DataManager.Instance;
				if (!WarManager.CheckVersion(true))
				{
					this.bSendShow = false;
					return true;
				}
				if (this.m_BMNowLiveType == GUIManager.ECombatLiveType.ECLTR_ATTACK || this.m_BMNowLiveType == GUIManager.ECombatLiveType.ECLTR_RALLYATTACK)
				{
					dataManager.KindomID_War[1] = this.m_BMNowKingdomID;
					dataManager.AllianceTag_War[1].ClearString();
					dataManager.AllianceTag_War[1].Append(this.m_BMATStr);
					dataManager.PlayerName_War[1].ClearString();
					dataManager.PlayerName_War[1].Append(this.m_BMNStr);
					dataManager.KindomID_War[0] = dataManager.MyKingdomID;
					dataManager.AllianceTag_War[0].ClearString();
					if (dataManager.RoleAlliance.Id > 0u)
					{
						dataManager.AllianceTag_War[0].Append(dataManager.RoleAlliance.Tag);
					}
					dataManager.PlayerName_War[0].ClearString();
					dataManager.PlayerName_War[0].Append(dataManager.RoleAttr.Name);
					WarManager.CurrentPointKind = this.m_BMNowPointKind;
					WarManager.UpdateLocalTimeToTheme(0L);
				}
				else if (this.m_BMNowLiveType == GUIManager.ECombatLiveType.ECLTR_WILDMONSTER)
				{
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.Protocol = Protocol._MSG_REQUEST_REPORTINFO;
					messagePacket.AddSeqId();
					messagePacket.Add(DataManager.Instance.Mailing.ReportSerial.New);
					messagePacket.Send(false);
					BattleController.BattleMode = EBattleMode.Monster;
					this.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MonsterBattle);
				}
				else if (this.m_BMNowLiveType == GUIManager.ECombatLiveType.ECLTR_NPCCITY)
				{
					dataManager.bWarAttacker = true;
					dataManager.KindomID_War[0] = DataManager.MapDataController.kingdomData.kingdomID;
					dataManager.AllianceTag_War[0].ClearString();
					if (dataManager.RoleAlliance.Id > 0u)
					{
						dataManager.AllianceTag_War[0].Append(dataManager.RoleAlliance.Tag);
					}
					dataManager.PlayerName_War[0].ClearString();
					dataManager.PlayerName_War[0].Append(dataManager.RoleAttr.Name);
					dataManager.KindomID_War[1] = DataManager.MapDataController.OtherKingdomData.kingdomID;
					dataManager.PlayerName_War[1].ClearString();
					dataManager.PlayerName_War[1].IntToFormat((long)this.WM_NPCLevel, 1, false);
					dataManager.PlayerName_War[1].AppendFormat(dataManager.mStringTable.GetStringByID(12021u));
					dataManager.AllianceTag_War[1].ClearString();
				}
				else
				{
					dataManager.KindomID_War[0] = this.m_BMNowKingdomID;
					dataManager.AllianceTag_War[0].ClearString();
					dataManager.AllianceTag_War[0].Append(this.m_BMATStr);
					dataManager.PlayerName_War[0].ClearString();
					dataManager.PlayerName_War[0].Append(this.m_BMNStr);
					dataManager.KindomID_War[1] = dataManager.MyKingdomID;
					dataManager.AllianceTag_War[1].ClearString();
					if (dataManager.RoleAlliance.Id > 0u)
					{
						dataManager.AllianceTag_War[1].Append(dataManager.RoleAlliance.Tag);
					}
					dataManager.PlayerName_War[1].ClearString();
					dataManager.PlayerName_War[1].Append(dataManager.RoleAttr.Name);
					WarManager.CurrentPointKind = this.m_BMNowPointKind;
					WarManager.UpdateLocalTimeToTheme(0L);
				}
				if (this.m_BMNowLiveType != GUIManager.ECombatLiveType.ECLTR_WILDMONSTER)
				{
					this.SendBattleMessageRP();
				}
				this.BattleSerialNo = this.SerialNo;
				this.bClearWindowStack = false;
				this.CloseBattleMessage();
			}
			this.bSendShow = false;
			break;
		case 2:
			NetworkManager.Resume(bOK);
			break;
		case 3:
		{
			DataManager dataManager2 = DataManager.Instance;
			GUIManager guimanager = GUIManager.Instance;
			ushort num = (ushort)(arg1 >> 16);
			ushort num2 = (ushort)(arg1 & 65535);
			ushort parameter = (ushort)(arg2 >> 16);
			ushort parameter2 = (ushort)(arg2 & 65535);
			if (this.useOrSpendType == UseOrSpendType.UST_ALLIANCE_MONEY_DOUBLE_CHECK || this.useOrSpendType == UseOrSpendType.UST_DIAMOND_DOUBLE_CHECK || this.useOrSpendType == UseOrSpendType.UST_WORLDTELEPORT)
			{
				this.useOrSpendType = ((this.useOrSpendType != UseOrSpendType.UST_WORLDTELEPORT) ? ((UseOrSpendType)(this.useOrSpendType - UseOrSpendType.UST_DIAMOND_DOUBLE_CHECK)) : UseOrSpendType.UST_DIAMOND_NORMAL);
				if ((num == GameConstants.WorldWarTeleportItemID || (num == GameConstants.AdvanceTeleportItemID && num2 == ActivityManager.Instance.KOWKingdomID && ActivityManager.Instance.NobilityActivityData.EventState == EActivityState.EAS_Run)) && (DataManager.Instance.RoleAttr.PetSkillFatigue > 0 || PetManager.Instance.BuffImmune.BeginTime > 0L))
				{
					guimanager.OpenOKCancelBox(17, dataManager2.mStringTable.GetStringByID(12140u), dataManager2.mStringTable.GetStringByID(12141u), arg1, arg2, null, null);
					return false;
				}
				if (DataManager.Instance.UseItemNote(num, num2, parameter, parameter2))
				{
					return false;
				}
				this.useOrSpendType = UseOrSpendType.UST_MAX;
			}
			else if (bOK)
			{
				if (num == 1115)
				{
					byte todayUseMoraleItemTimes = dataManager2.RoleAttr.TodayUseMoraleItemTimes;
					byte moraleBanner = dataManager2.VIPLevelTable.GetRecordByKey((ushort)dataManager2.RoleAttr.VIPLevel).moraleBanner;
					if (todayUseMoraleItemTimes >= moraleBanner)
					{
						guimanager.MsgStr.Length = 0;
						guimanager.MsgStr.IntToFormat((long)moraleBanner, 1, false);
						guimanager.MsgStr.IntToFormat((long)moraleBanner, 1, false);
						guimanager.MsgStr.AppendFormat(dataManager2.mStringTable.GetStringByID(8584u));
						guimanager.OpenOKCancelBox(8, dataManager2.mStringTable.GetStringByID(5811u), guimanager.MsgStr.ToString(), arg1, arg2, dataManager2.mStringTable.GetStringByID(4507u), dataManager2.mStringTable.GetStringByID(617u));
						this.useOrSpendType = UseOrSpendType.UST_MAX;
						return false;
					}
					Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(num);
					if (dataManager2.RoleAttr.Morale + recordByKey.PropertiesInfo[0].PropertiesValue > 999)
					{
						guimanager.AddHUDMessage(dataManager2.mStringTable.GetStringByID(809u), 255, true);
						return true;
					}
				}
				if (dataManager2.GetCurItemQuantity(num, 0) <= 0)
				{
					bool result = dataManager2.sendBuyItem((byte)(this.useOrSpendType + 1), dataManager2.TotalShopItemData.Find(num), num, true, null, arg1, arg2, 0u, string.Empty, true, 1);
					this.useOrSpendType = UseOrSpendType.UST_MAX;
					return result;
				}
				if (num == GameConstants.WorldTeleportItemID)
				{
					dataManager2.UseItem(num, dataManager2.WorldTeleportItemCount, num2, parameter, parameter2, 0u, string.Empty, true);
					dataManager2.WorldTeleportItemCount = 0;
				}
				else
				{
					dataManager2.UseItem(num, 1, num2, parameter, parameter2, 0u, string.Empty, true);
				}
				this.useOrSpendType = UseOrSpendType.UST_MAX;
			}
			else
			{
				this.useOrSpendType = UseOrSpendType.UST_MAX;
			}
			break;
		}
		case 4:
			if (bOK)
			{
				if (BattleController.IsGambleMode)
				{
					GamblingManager.Instance.bOpenTreasure = 1;
					GamblingManager.Instance.CloseMenu(false);
					this.UpdateUI(EGUIWindow.UI_Battle_Gambling, 13, 0);
				}
				else
				{
					MallManager.Instance.Send_Mall_Info();
				}
			}
			break;
		case 5:
			if (bOK)
			{
				DataManager.Instance.RoleBookMark.CheckModify();
			}
			break;
		case 6:
			if (bOK)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door)
				{
					door.OpenMenu(EGUIWindow.UI_BagFilter, 262145, 0, false);
				}
			}
			break;
		case 7:
		{
			Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (bOK && door2)
			{
				bool flag = door2.m_GroundInfo.ScoutCheckBox(eScoutCheckBox.Shield_Self);
				if (!flag)
				{
					return false;
				}
				DataManager.Instance.ScoutDesPoint.pointID = 0;
				DataManager.Instance.ScoutDesPoint.zoneID = 0;
				GameConstants.MapIDToPointCode(arg1, out DataManager.Instance.ScoutDesPoint.zoneID, out DataManager.Instance.ScoutDesPoint.pointID);
				DataManager.Instance.SendScout(DataManager.Instance.ScoutDesPoint);
			}
			break;
		}
		case 8:
		{
			Door door3 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (bOK && door3)
			{
				door3.OpenMenu(EGUIWindow.UI_VIP, 0, 0, false);
			}
			break;
		}
		case 9:
			if (bOK)
			{
				GUIManager.instance.OpenTechTree(43, true);
			}
			break;
		case 11:
			if (bOK)
			{
				ushort num3 = (ushort)(arg1 >> 16);
				if (num3 == GameConstants.WorldTeleportItemID)
				{
					DataManager.Instance.RequsetWorldTeleportItemCount();
				}
				else
				{
					ushort num4 = (ushort)(arg1 & 65535);
					ushort parameter3 = 0;
					byte parameter4 = 0;
					GameConstants.MapIDToPointCode(arg2, out parameter3, out parameter4);
					Vector2 tileMapPosbyMapID = GameConstants.getTileMapPosbyMapID(arg2);
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.ClearString();
					cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4504u));
					cstring.IntToFormat((long)num4, 1, false);
					cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4505u));
					cstring.IntToFormat((long)tileMapPosbyMapID.x, 1, false);
					cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4506u));
					cstring.IntToFormat((long)tileMapPosbyMapID.y, 1, false);
					cstring.AppendFormat("{0}{1} {2}{3} {4}{5}");
					this.UseOrSpend(num3, DataManager.Instance.mStringTable.GetStringByID(4512u), num4, parameter3, (ushort)parameter4, UseOrSpendType.UST_DIAMOND_DOUBLE_CHECK, null, null, cstring.ToString(), 0);
				}
				return false;
			}
			break;
		case 12:
			if (bOK)
			{
				this.useOrSpendType = UseOrSpendType.UST_MAX;
				GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3782u), DataManager.Instance.mStringTable.GetStringByID(955u), 0, null, 0, 0, false, false, false, false, false);
			}
			break;
		case 13:
			if (bOK)
			{
				ushort num5 = (ushort)(arg1 & 65535);
				ushort num6 = 0;
				byte b = 0;
				GameConstants.MapIDToPointCode(arg2, out num6, out b);
				int arg3 = (int)GameConstants.WorldTeleportItemID << 16 | (int)num5;
				int arg4 = (int)num6 << 16 | (int)b;
				this.m_OKCancelClickIndex = 3;
				this.OKCancelNoWindow(true, arg3, arg4);
				GUIManager.instance.CloseMenu(EGUIWindow.UI_Immigration);
			}
			break;
		case 14:
			if (bOK)
			{
				Application.Quit();
			}
			break;
		case 17:
			if (bOK)
			{
				DataManager dataManager3 = DataManager.Instance;
				GUIManager guimanager2 = GUIManager.Instance;
				ushort num7 = (ushort)(arg1 >> 16);
				ushort targetID = (ushort)(arg1 & 65535);
				ushort parameter5 = (ushort)(arg2 >> 16);
				ushort parameter6 = (ushort)(arg2 & 65535);
				if (DataManager.Instance.UseItemNote(num7, targetID, parameter5, parameter6))
				{
					return false;
				}
				if (dataManager3.GetCurItemQuantity(num7, 0) <= 0)
				{
					bool result2 = dataManager3.sendBuyItem((byte)(this.useOrSpendType + 1), dataManager3.TotalShopItemData.Find(num7), num7, true, null, arg1, arg2, 0u, string.Empty, true, 1);
					this.useOrSpendType = UseOrSpendType.UST_MAX;
					return result2;
				}
				if (num7 == GameConstants.WorldTeleportItemID)
				{
					dataManager3.UseItem(num7, dataManager3.WorldTeleportItemCount, targetID, parameter5, parameter6, 0u, string.Empty, true);
					dataManager3.WorldTeleportItemCount = 0;
				}
				else
				{
					dataManager3.UseItem(num7, 1, targetID, parameter5, parameter6, 0u, string.Empty, true);
				}
				this.useOrSpendType = UseOrSpendType.UST_MAX;
			}
			else
			{
				this.useOrSpendType = UseOrSpendType.UST_MAX;
			}
			break;
		}
		return true;
	}

	// Token: 0x0600061F RID: 1567 RVA: 0x00086DCC File Offset: 0x00084FCC
	public void OK(int arg1, int arg2)
	{
		this.m_OKCancelBoxArg1 = arg1;
		this.m_OKCancelBoxArg2 = arg2;
		this.OKCancelNoWindow(true, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2);
	}

	// Token: 0x06000620 RID: 1568 RVA: 0x00086DFC File Offset: 0x00084FFC
	public void OnButtonClick(UIButton sender)
	{
		DataManager.MapDataController.StopMapWeapon();
		switch (sender.m_BtnID1)
		{
		case 1:
		case 2:
			this.m_MsgText.Clear();
			UnityEngine.Object.Destroy(this.m_OKCancelBox);
			this.m_OKCancelBox = null;
			if (sender.m_BtnID1 == 1)
			{
				if (this.m_OKCancelBoxHandler != null)
				{
					this.m_OKCancelBoxHandler.OnOKCancelBoxClick(sender.m_BtnID2 == 1, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2);
					this.m_OKCancelClickIndex = -1;
				}
				else if (this.OKCancelNoWindow(sender.m_BtnID2 == 1, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2))
				{
					this.m_OKCancelClickIndex = -1;
				}
			}
			else
			{
				this.useOrSpendType = UseOrSpendType.UST_MAX;
			}
			break;
		case 3:
		{
			DataManager dataManager = DataManager.Instance;
			if (this.m_BMNowLiveType == GUIManager.ECombatLiveType.ECLTR_WILDMONSTER && !dataManager.CheckMonsterResourceReady(this.WM_MonsterID))
			{
				this.AddHUDMessage(dataManager.mStringTable.GetStringByID(8350u), 255, true);
				return;
			}
			this.OpenOKCancelBox(1, dataManager.mStringTable.GetStringByID(585u), dataManager.mStringTable.GetStringByID(586u), 0, 0, dataManager.mStringTable.GetStringByID(587u), dataManager.mStringTable.GetStringByID(588u));
			this.bSendShow = true;
			break;
		}
		case 12:
		{
			if (BattleController.IsGambleMode)
			{
				if (sender.m_BtnID2 == 1 && DataManager.Instance.RoleAlliance.Id == 0u)
				{
					this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9184u), 255, true);
				}
				else
				{
					GamblingManager.Instance.OpenMenu(EGUIWindow.UI_Chat, 0, 0, false);
				}
				return;
			}
			Door door = this.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				if (sender.m_BtnID2 == 1 && DataManager.Instance.RoleAlliance.Id == 0u)
				{
					door.AllianceOnClick();
				}
				else if (!NewbieManager.CheckRename(true))
				{
					door.OpenMenu(EGUIWindow.UI_Chat, sender.m_BtnID2 + 1, 0, false);
				}
			}
			else
			{
				this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(789u), 255, true);
			}
			break;
		}
		case 13:
			this.ReleaseBackMessageBox();
			break;
		case 14:
			if (sender.m_BtnID2 == 1)
			{
				UnityEngine.Object.Destroy(this.m_CheckCrystalBox);
				this.m_CheckCrystalBox = null;
				switch (this.CheckCrystalKind)
				{
				case 0:
					this.m_CheckCrystalButton.m_BtnID1 = 1;
					this.m_CheckCrystalButton.m_BtnID2 = 1;
					this.OnButtonClick(this.m_CheckCrystalButton);
					break;
				case 1:
					this.UpdateUI(EGUIWindow.UI_BagFilter, this.CheckCrystalPara1, 0);
					break;
				case 2:
					ArenaManager.Instance.SendArena_ReSet_TodayChallenge();
					break;
				case 3:
					DataManager.Instance.sendTechnologyResearchCompleteImmediate((ushort)this.CheckCrystalPara1);
					break;
				case 4:
					this.BuildingData.sendBuildCompleteImmediate((ushort)this.CheckCrystalPara1, (ushort)this.CheckCrystalPara2);
					break;
				case 5:
					this.UpdateUI((EGUIWindow)(this.CheckCrystalPara1 >> 16), this.CheckCrystalPara1 & 65535, this.CheckCrystalPara2);
					break;
				case 6:
					DataManager.Instance.mLordEquip.QuickCombine((ushort)this.CheckCrystalPara1, (uint)this.CheckCrystalPara2);
					break;
				case 7:
					DataManager.Instance.SendAllanceDismissLeader(DataManager.Instance.AllianceMember[this.CheckCrystalPara1].UserId);
					break;
				case 8:
					MobilizationManager.Instance.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_BUY();
					break;
				case 9:
					this.UpdateUI(EGUIWindow.UIEmojiSelect, 2, 0);
					break;
				case 10:
					this.UpdateUI(EGUIWindow.UI_Pet, 10, 0);
					break;
				}
			}
			else if (sender.m_BtnID2 == 2)
			{
				UnityEngine.Object.Destroy(this.m_CheckCrystalBox);
				this.m_CheckCrystalBox = null;
				this.bCheckCrystal = false;
			}
			else if (sender.m_BtnID2 == 3)
			{
				this.bCheckCrystal = !this.bCheckCrystal;
				if (this.CheckCrystalImg != null)
				{
					this.CheckCrystalImg.gameObject.SetActive(this.bCheckCrystal);
				}
			}
			break;
		case 15:
			if (this.m_CheckCrystalButton == null)
			{
				this.m_CheckCrystalButton = sender;
				this.tmpCheckCrystal = (uint)sender.m_BtnID4;
			}
			if (!this.OpenCheckCrystal(this.tmpCheckCrystal, 0, -1, -1))
			{
				sender.m_BtnID1 = 1;
				sender.m_BtnID2 = 1;
				this.OnButtonClick(sender);
			}
			break;
		case 16:
			if (sender.m_BtnID2 == 1)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 12, 0);
				UnityEngine.Object.Destroy(this.m_CheckCrystalBox);
				this.m_CheckCrystalBox = null;
			}
			else if (sender.m_BtnID2 == 2)
			{
				UnityEngine.Object.Destroy(this.m_CheckCrystalBox);
				this.m_CheckCrystalBox = null;
				GamblingManager.Instance.bIsFirstOpen = false;
			}
			else if (sender.m_BtnID2 == 3)
			{
				GamblingManager.Instance.bIsFirstOpen = !GamblingManager.Instance.bIsFirstOpen;
				if (this.CheckCrystalImg != null)
				{
					this.CheckCrystalImg.gameObject.SetActive(GamblingManager.Instance.bIsFirstOpen);
				}
			}
			break;
		case 17:
			this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(744u), 255, true);
			break;
		case 18:
			if (sender.m_BtnID2 == 1)
			{
				this.UpdateUI(EGUIWindow.UI_AlliWarSchedule, 1, sender.m_BtnID3);
				UnityEngine.Object.Destroy(this.m_CheckCrystalBox);
				this.m_CheckCrystalBox = null;
			}
			else if (sender.m_BtnID2 == 2)
			{
				UnityEngine.Object.Destroy(this.m_CheckCrystalBox);
				this.m_CheckCrystalBox = null;
				this.bCheckAWSSchedule = true;
			}
			else if (sender.m_BtnID2 == 3)
			{
				this.bCheckAWSSchedule = !this.bCheckAWSSchedule;
				if (this.CheckCrystalImg != null)
				{
					this.CheckCrystalImg.gameObject.SetActive(!this.bCheckAWSSchedule);
				}
			}
			break;
		case 19:
			if (sender.m_BtnID2 == 1)
			{
				this.UpdateUI(EGUIWindow.UI_MessageBoard, 6, 0);
				UnityEngine.Object.Destroy(this.m_CheckCrystalBox);
				this.m_CheckCrystalBox = null;
			}
			else if (sender.m_BtnID2 == 2)
			{
				UnityEngine.Object.Destroy(this.m_CheckCrystalBox);
				this.m_CheckCrystalBox = null;
				this.bCheckDeleteMsg = true;
			}
			else if (sender.m_BtnID2 == 3)
			{
				this.bCheckDeleteMsg = !this.bCheckDeleteMsg;
				if (this.CheckCrystalImg != null)
				{
					this.CheckCrystalImg.gameObject.SetActive(!this.bCheckDeleteMsg);
				}
			}
			break;
		case 20:
			if (sender.m_BtnID2 == 1)
			{
				this.UpdateUI(EGUIWindow.UI_PetStoneTrans, 1, 0);
				UnityEngine.Object.Destroy(this.m_CheckCrystalBox);
				this.m_CheckCrystalBox = null;
			}
			else if (sender.m_BtnID2 == 2)
			{
				UnityEngine.Object.Destroy(this.m_CheckCrystalBox);
				this.m_CheckCrystalBox = null;
				this.bCheckStoneTrans = true;
			}
			else if (sender.m_BtnID2 == 3)
			{
				this.bCheckStoneTrans = !this.bCheckStoneTrans;
				if (this.CheckCrystalImg != null)
				{
					this.CheckCrystalImg.gameObject.SetActive(!this.bCheckStoneTrans);
				}
			}
			break;
		case 21:
			if (sender.m_BtnID2 != 1)
			{
				if (sender.m_BtnID2 == 2)
				{
					RealNameHelp.Instance.OpenQuitGameRealNameByWebView();
				}
				else if (sender.m_BtnID2 == 3)
				{
					Application.Quit();
				}
			}
			this.m_MsgText.Clear();
			UnityEngine.Object.Destroy(this.m_OKCancelBox);
			this.m_OKCancelBox = null;
			if (this.m_OKCancelBoxHandler != null)
			{
				this.m_OKCancelBoxHandler.OnOKCancelBoxClick(sender.m_BtnID2 == 1, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2);
				this.m_OKCancelClickIndex = -1;
			}
			else if (this.OKCancelNoWindow(sender.m_BtnID2 == 1, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2))
			{
				this.m_OKCancelClickIndex = -1;
			}
			AntiAddictive.Instance.SetAnitAddicitvDlgStage(NotificationStage.None);
			break;
		case 22:
			RealNameHelp.Instance.ClearUpdateCheckState();
			if (sender.m_BtnID2 == 0)
			{
				RealNameHelp.Instance.OpenRealNameByWebView();
			}
			else if (sender.m_BtnID2 == 1)
			{
				RealNameHelp.Instance.OpenRealNameByWebView();
			}
			else if (sender.m_BtnID2 != 2)
			{
				if (sender.m_BtnID2 != 3)
				{
					if (sender.m_BtnID2 == 4)
					{
					}
				}
			}
			this.m_MsgText.Clear();
			UnityEngine.Object.Destroy(this.m_OKCancelBox);
			this.m_OKCancelBox = null;
			if (this.m_OKCancelBoxHandler != null)
			{
				this.m_OKCancelBoxHandler.OnOKCancelBoxClick(sender.m_BtnID2 == 1, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2);
				this.m_OKCancelClickIndex = -1;
			}
			else if (this.OKCancelNoWindow(sender.m_BtnID2 == 1, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2))
			{
				this.m_OKCancelClickIndex = -1;
			}
			if (sender.m_BtnID2 != 0 && sender.m_BtnID2 != 1 && AntiAddictive.Instance.m_SaveStage == NotificationStage.Stage5)
			{
				RealNameHelp.Instance.CheckFromQuitGameDlgFlag();
			}
			break;
		case 23:
			if (sender.m_BtnID2 == 1)
			{
				UnityEngine.Object.Destroy(this.m_CheckCrystalBox);
				this.m_CheckCrystalBox = null;
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Expedition, 6, 0);
			}
			else if (sender.m_BtnID2 == 2)
			{
				UnityEngine.Object.Destroy(this.m_CheckCrystalBox);
				this.m_CheckCrystalBox = null;
				DataManager.Instance.bFirstOpenWarlobbyTroopSelect = false;
			}
			else if (sender.m_BtnID2 == 3)
			{
				DataManager.Instance.bFirstOpenWarlobbyTroopSelect = !DataManager.Instance.bFirstOpenWarlobbyTroopSelect;
				if (this.CheckCrystalImg != null)
				{
					this.CheckCrystalImg.gameObject.SetActive(DataManager.Instance.bFirstOpenWarlobbyTroopSelect);
				}
			}
			break;
		}
	}

	// Token: 0x06000621 RID: 1569 RVA: 0x00087864 File Offset: 0x00085A64
	public void OpenOKCancelBox(int ClickIndex, string TitleText, string QuestionText, int arg1 = 0, int arg2 = 0, string YesText = null, string NoText = null)
	{
		this.m_OKCancelClickIndex = ClickIndex;
		this.OpenOKCancelBox(null, TitleText, QuestionText, arg1, arg2, YesText, NoText);
	}

	// Token: 0x06000622 RID: 1570 RVA: 0x0008788C File Offset: 0x00085A8C
	public void OpenOKCancelBox(GUIWindow win, string TitleText, string QuestionText, int arg1 = 0, int arg2 = 0, string YesText = null, string NoText = null)
	{
		if (this.m_OKCancelBox != null)
		{
			return;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UIOKCancelBox");
		if (@object == null)
		{
			return;
		}
		this.m_MsgText.Clear();
		this.HideArrow(false);
		this.m_OKCancelBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_OKCancelBox.transform.SetParent(this.m_MessageBoxLayer, false);
		CustomImage component = this.m_OKCancelBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		Transform child = this.m_OKCancelBox.transform.GetChild(0);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		Transform child2 = child.GetChild(2);
		UIText component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = TitleText;
		this.m_MsgText.Add(component2);
		child2 = child.GetChild(3);
		component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.SetCheckArabic(true);
		component2.text = QuestionText;
		this.m_MsgText.Add(component2);
		float num = component2.preferredHeight - 86.8f;
		if (num > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num);
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num);
		}
		child2 = child.GetChild(4);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		UIButton component3 = child2.GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 1;
		component3.m_BtnID2 = 1;
		child2 = child2.GetChild(0);
		component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		if (YesText == null)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(189u);
		}
		else
		{
			component2.text = YesText;
		}
		this.m_MsgText.Add(component2);
		child2 = child.GetChild(5);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component3 = child2.GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 1;
		component3.m_BtnID2 = 2;
		child2 = child2.GetChild(0);
		component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		if (NoText == null)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(188u);
		}
		else
		{
			component2.text = NoText;
		}
		this.m_MsgText.Add(component2);
		if (this.IsArabic)
		{
			RectTransform rectTransform = (RectTransform)child.GetChild(4);
			RectTransform rectTransform2 = (RectTransform)child.GetChild(5);
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			rectTransform.anchoredPosition = rectTransform2.anchoredPosition;
			rectTransform2.anchoredPosition = anchoredPosition;
		}
		RectTransform rectTransform3 = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform3.sizeDelta.y + 109f > y)
		{
			float num2 = (y - rectTransform3.sizeDelta.y) * 0.5f;
			if (num2 < 0f)
			{
				num2 = 19f;
			}
			rectTransform3.anchoredPosition = new Vector2(rectTransform3.anchoredPosition.x, -num2);
		}
		child2 = child.GetChild(8);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_OKCancelCloseButton = child2.GetComponent<UIButton>();
		this.m_OKCancelCloseButton.m_Handler = this;
		this.m_OKCancelCloseButton.m_BtnID1 = 1;
		this.m_OKCancelCloseButton.m_BtnID2 = 2;
		this.m_OKCancelBoxHandler = win;
		this.m_OKCancelBoxArg1 = arg1;
		this.m_OKCancelBoxArg2 = arg2;
	}

	// Token: 0x06000623 RID: 1571 RVA: 0x00087CB0 File Offset: 0x00085EB0
	public void OpenMessageBox(string TitleText, string MessageText, int ClickIndex, string ButtonText = null, int arg1 = 0, int arg2 = 0, bool bCloseIDSet = false, bool ShowBar = false, bool BackExit = false, bool bHideCloseBtn = false, bool bHideYesBtn = false)
	{
		this.m_OKCancelClickIndex = ClickIndex;
		this.OpenMessageBox(TitleText, MessageText, ButtonText, null, arg1, arg2, bCloseIDSet, ShowBar, BackExit, bHideCloseBtn, bHideYesBtn);
	}

	// Token: 0x06000624 RID: 1572 RVA: 0x00087CE0 File Offset: 0x00085EE0
	public void OpenMessageBox(string TitleText, string MessageText, string ButtonText = null, GUIWindow win = null, int arg1 = 0, int arg2 = 0, bool bCloseIDSet = false, bool ShowBar = false, bool BackExit = false, bool bHideCloseBtn = false, bool bHideYesBtn = false)
	{
		if (this.m_OKCancelBox != null)
		{
			return;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UIOKCancelBox");
		if (@object == null)
		{
			return;
		}
		this.m_MsgText.Clear();
		this.HideArrow(false);
		this.m_OKCancelBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_OKCancelBox.transform.SetParent(this.m_MessageBoxLayer, false);
		CustomImage component = this.m_OKCancelBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		Transform child = this.m_OKCancelBox.transform.GetChild(0);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		Transform child2 = child.GetChild(2);
		UIText component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		if (TitleText == null)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(3782u);
		}
		else
		{
			component2.text = TitleText;
		}
		this.m_MsgText.Add(component2);
		child2 = child.GetChild(3);
		component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = MessageText;
		this.m_MsgText.Add(component2);
		float num = component2.preferredHeight - 86.8f;
		if (num > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num);
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num);
		}
		if (ShowBar)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, 50f);
		}
		child2 = child.GetChild(4);
		((RectTransform)child2).anchoredPosition = new Vector2(0f, 75f);
		((RectTransform)child2).sizeDelta += new Vector2(121f, 0f);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		UIButton component3 = child2.GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 1;
		if (bCloseIDSet)
		{
			component3.m_BtnID2 = 1;
		}
		else
		{
			component3.m_BtnID2 = 2;
		}
		child2 = child2.GetChild(0);
		component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		if (ButtonText == null)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(189u);
		}
		else
		{
			component2.text = ButtonText;
		}
		this.m_MsgText.Add(component2);
		if (bHideYesBtn)
		{
			child.GetChild(4).gameObject.SetActive(false);
		}
		child.GetChild(5).gameObject.SetActive(false);
		RectTransform rectTransform = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform.sizeDelta.y + 109f > y)
		{
			float num2 = (y - rectTransform.sizeDelta.y) * 0.5f;
			if (num2 < 0f)
			{
				num2 = 19f;
			}
			rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -num2);
		}
		child2 = child.GetChild(8);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_OKCancelCloseButton = child2.GetComponent<UIButton>();
		this.m_OKCancelCloseButton.m_Handler = this;
		this.m_OKCancelCloseButton.m_BtnID1 = 1;
		this.m_OKCancelCloseButton.m_BtnID2 = 2;
		if (BackExit)
		{
			HelperUIButton helperUIButton = this.m_OKCancelBox.AddComponent<HelperUIButton>();
			helperUIButton.m_Handler = this;
			helperUIButton.m_BtnID1 = 1;
			helperUIButton.m_BtnID2 = 2;
		}
		if (bHideCloseBtn)
		{
			child.GetChild(8).gameObject.SetActive(false);
		}
		if (ShowBar)
		{
			child2 = child.GetChild(9);
			component = child2.GetComponent<CustomImage>();
			component.hander = this;
			this.MsgBarImage = child2.GetChild(0).GetComponent<CustomImage>();
			this.MsgBarImage.hander = this;
			component2 = child2.GetChild(1).GetComponent<UIText>();
			component2.font = this.GetTTFFont();
			component2.text = DataManager.Instance.mStringTable.GetStringByID(6097u);
			this.m_MsgText.Add(component2);
			component2 = child2.GetChild(2).GetComponent<UIText>();
			component2.font = this.GetTTFFont();
			this.MsgBarTimeText = component2;
			this.m_MsgText.Add(component2);
			child2.gameObject.SetActive(true);
		}
		this.m_OKCancelBoxHandler = win;
		this.m_OKCancelBoxArg1 = arg1;
		this.m_OKCancelBoxArg2 = arg2;
	}

	// Token: 0x06000625 RID: 1573 RVA: 0x000881F4 File Offset: 0x000863F4
	public void OpenMessageBoxEX(string TitleText, string MessageText, int ClickIndex, string ButtonText = null, int arg1 = 0, int arg2 = 0, bool bInfo = false, bool BackExit = false)
	{
		this.m_OKCancelClickIndex = ClickIndex;
		this.OpenMessageBoxEX(TitleText, MessageText, ButtonText, null, arg1, arg2, bInfo, BackExit);
	}

	// Token: 0x06000626 RID: 1574 RVA: 0x0008821C File Offset: 0x0008641C
	public void OpenMessageBoxEX(string TitleText, string MessageText, string ButtonText = null, GUIWindow win = null, int arg1 = 0, int arg2 = 0, bool bInfo = false, bool BackExit = false)
	{
		if (this.m_OKCancelBox != null)
		{
			return;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UIOKCancelBox");
		if (@object == null)
		{
			return;
		}
		this.m_MsgText.Clear();
		this.HideArrow(false);
		this.m_OKCancelBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_OKCancelBox.transform.SetParent(this.m_MessageBoxLayer, false);
		CustomImage component = this.m_OKCancelBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		Transform child = this.m_OKCancelBox.transform.GetChild(0);
		child.gameObject.SetActive(false);
		child = this.m_OKCancelBox.transform.GetChild(2);
		child.gameObject.SetActive(true);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		Transform child2 = child.GetChild(2);
		UIText component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		if (TitleText == null)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(3782u);
		}
		else
		{
			component2.text = TitleText;
		}
		this.m_MsgText.Add(component2);
		float num = 216.4f;
		if (bInfo)
		{
			float num2 = 26f;
			num += num2;
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num2);
			((RectTransform)child.GetChild(3)).sizeDelta += new Vector2(0f, num2);
		}
		child2 = child.GetChild(3);
		component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = MessageText;
		this.m_MsgText.Add(component2);
		float num3 = component2.preferredHeight - num;
		if (num3 > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num3);
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num3);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num3);
		}
		RectTransform rectTransform = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform.sizeDelta.y + 109f > y)
		{
			float num4 = (y - rectTransform.sizeDelta.y) * 0.5f;
			if (num4 < 0f)
			{
				num4 = 19f;
				rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, y - 19f);
				((RectTransform)child.GetChild(0)).sizeDelta = new Vector2(((RectTransform)child.GetChild(0)).sizeDelta.x, y - 220f);
				((RectTransform)child2).sizeDelta = new Vector2(((RectTransform)child2).sizeDelta.x, y - 220f);
				component2.resizeTextForBestFit = true;
				component2.resizeTextMinSize = 14;
			}
			rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -num4);
		}
		if (bInfo)
		{
			child.GetChild(4).gameObject.SetActive(false);
		}
		else
		{
			child2 = child.GetChild(4);
			component = child2.GetComponent<CustomImage>();
			component.hander = this;
			UIButton component3 = child2.GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 1;
			component3.m_BtnID2 = 2;
			child2 = child2.GetChild(0);
			component2 = child2.GetComponent<UIText>();
			component2.font = this.GetTTFFont();
			if (ButtonText == null)
			{
				component2.text = DataManager.Instance.mStringTable.GetStringByID(189u);
			}
			else
			{
				component2.text = ButtonText;
			}
			this.m_MsgText.Add(component2);
		}
		child2 = child.GetChild(5);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_OKCancelCloseButton = child2.GetComponent<UIButton>();
		this.m_OKCancelCloseButton.m_Handler = this;
		this.m_OKCancelCloseButton.m_BtnID1 = 1;
		this.m_OKCancelCloseButton.m_BtnID2 = 2;
		if (BackExit)
		{
			HelperUIButton helperUIButton = this.m_OKCancelBox.AddComponent<HelperUIButton>();
			helperUIButton.m_Handler = this;
			helperUIButton.m_BtnID1 = 1;
			helperUIButton.m_BtnID2 = 2;
		}
		this.m_OKCancelBoxHandler = win;
		this.m_OKCancelBoxArg1 = arg1;
		this.m_OKCancelBoxArg2 = arg2;
	}

	// Token: 0x06000627 RID: 1575 RVA: 0x000886FC File Offset: 0x000868FC
	public void OpenSpendWindow_Normal(int ClickIndex, string TitleText, string QuestionText, int Cost, int arg1 = 0, int arg2 = 0, string Buttontext = null)
	{
		this.m_OKCancelClickIndex = ClickIndex;
		this.OpenSpendWindow_Normal(null, TitleText, QuestionText, Cost, arg1, arg2, Buttontext, false);
	}

	// Token: 0x06000628 RID: 1576 RVA: 0x00088724 File Offset: 0x00086924
	public void OpenSpendWindow_Normal(GUIWindow win, string TitleText, string QuestionText, int Cost, int arg1 = 0, int arg2 = 0, string Buttontext = null, bool bGold = false)
	{
		if (this.m_OKCancelBox != null)
		{
			return;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UIOKCancelBox");
		if (@object == null)
		{
			return;
		}
		this.m_MsgText.Clear();
		this.HideArrow(false);
		this.m_OKCancelBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_OKCancelBox.transform.SetParent(this.m_MessageBoxLayer, false);
		CustomImage component = this.m_OKCancelBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		Transform child = this.m_OKCancelBox.transform.GetChild(0);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		Transform child2 = child.GetChild(2);
		UIText component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = TitleText;
		this.m_MsgText.Add(component2);
		child2 = child.GetChild(3);
		component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = QuestionText;
		this.m_MsgText.Add(component2);
		float num = component2.preferredHeight - 86.8f;
		if (num > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num);
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num);
		}
		child.GetChild(4).gameObject.SetActive(false);
		child.GetChild(5).gameObject.SetActive(false);
		child2 = child.GetChild(6);
		child2.gameObject.SetActive(true);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		UIButton component3 = child2.GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 1;
		component3.m_BtnID2 = 1;
		component2 = child2.GetChild(0).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		if (Buttontext != null)
		{
			component2.text = Buttontext;
		}
		else
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(284u);
		}
		this.m_MsgText.Add(component2);
		component2 = child2.GetChild(1).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		this.m_MsgText.Add(component2);
		if (this.m_OKString == null)
		{
			this.m_OKString = StringManager.Instance.SpawnString(30);
		}
		this.m_OKString.Length = 0;
		this.m_OKString.IntToFormat((long)Cost, 1, true);
		this.m_OKString.AppendFormat("{0}");
		component2.text = this.m_OKString.ToString();
		component = child2.GetChild(2).GetComponent<CustomImage>();
		component.hander = this;
		component = child2.GetChild(3).GetComponent<CustomImage>();
		component.hander = this;
		if (bGold)
		{
			child2.GetChild(3).gameObject.SetActive(true);
		}
		else
		{
			child2.GetChild(2).gameObject.SetActive(true);
		}
		RectTransform rectTransform = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform.sizeDelta.y + 109f > y)
		{
			float num2 = (y - rectTransform.sizeDelta.y) * 0.5f;
			if (num2 < 0f)
			{
				num2 = 19f;
			}
			rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -num2);
		}
		child2 = child.GetChild(8);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_OKCancelCloseButton = child2.GetComponent<UIButton>();
		this.m_OKCancelCloseButton.m_Handler = this;
		this.m_OKCancelCloseButton.m_BtnID1 = 2;
		this.m_OKCancelBoxHandler = win;
		this.m_OKCancelBoxArg1 = arg1;
		this.m_OKCancelBoxArg2 = arg2;
	}

	// Token: 0x06000629 RID: 1577 RVA: 0x00088B6C File Offset: 0x00086D6C
	public void OpenSpendWindow_ItemID(int ClickIndex, string TitleText, ushort ItemID, int arg1 = 0, int arg2 = 0, string HaveItemText = null, string NoItemText = null, string SpecialStr = null)
	{
		this.m_OKCancelClickIndex = ClickIndex;
		this.OpenSpendWindow_ItemID(null, TitleText, ItemID, arg1, arg2, HaveItemText, NoItemText, SpecialStr);
	}

	// Token: 0x0600062A RID: 1578 RVA: 0x00088B94 File Offset: 0x00086D94
	public void OpenSpendWindow_ItemID(GUIWindow win, string TitleText, ushort ItemID, int arg1 = 0, int arg2 = 0, string HaveItemText = null, string NoItemText = null, string SpecialStr = null)
	{
		if (this.m_OKCancelBox != null)
		{
			return;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UIOKCancelBox");
		if (@object == null)
		{
			return;
		}
		this.m_MsgText.Clear();
		this.HideArrow(false);
		this.m_OKCancelBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_OKCancelBox.transform.SetParent(this.m_MessageBoxLayer, false);
		DataManager dataManager = DataManager.Instance;
		StringManager stringManager = StringManager.Instance;
		CustomImage component = this.m_OKCancelBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		Transform child = this.m_OKCancelBox.transform.GetChild(0);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		Transform child2 = child.GetChild(2);
		UIText component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = TitleText;
		this.m_MsgText.Add(component2);
		Equip recordByKey = dataManager.EquipTable.GetRecordByKey(ItemID);
		child2 = child.GetChild(3);
		component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		this.m_MsgText.Add(component2);
		ushort curItemQuantity = dataManager.GetCurItemQuantity(ItemID, 0);
		ushort num = (ushort)(arg1 >> 16);
		if (SpecialStr != null)
		{
			if (this.m_OKString_Info == null)
			{
				this.m_OKString_Info = stringManager.SpawnString(1024);
			}
			this.m_OKString_Info.Length = 0;
			if (this.useOrSpendType == UseOrSpendType.UST_WORLDTELEPORT && num > 1)
			{
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.ClearString();
				cstring.IntToFormat((long)dataManager.WorldTeleportRank, 1, false);
				cstring.IntToFormat((long)dataManager.WorldTeleportItemCount, 1, false);
				cstring.AppendFormat(dataManager.mStringTable.GetStringByID(950u));
				this.m_OKString_Info.StringToFormat(dataManager.mStringTable.GetStringByID((uint)recordByKey.EquipInfo));
				this.m_OKString_Info.StringToFormat(cstring.ToString());
				this.m_OKString_Info.StringToFormat(SpecialStr);
				this.m_OKString_Info.AppendFormat("{0}\n\n{1}\n<color=#A7EBFF>{2}</color>");
				cstring.ClearString();
			}
			else
			{
				this.m_OKString_Info.StringToFormat(dataManager.mStringTable.GetStringByID((uint)recordByKey.EquipInfo));
				this.m_OKString_Info.StringToFormat(SpecialStr);
				this.m_OKString_Info.AppendFormat("{0}\n<color=#A7EBFF>{1}</color>");
			}
			component2.text = this.m_OKString_Info.ToString();
		}
		else
		{
			component2.text = dataManager.mStringTable.GetStringByID((uint)recordByKey.EquipInfo);
		}
		component2.alignment = TextAnchor.UpperLeft;
		component2.lineSpacing = 1.03f;
		((RectTransform)child).sizeDelta = new Vector2(450f, 363f);
		((RectTransform)child.GetChild(0)).sizeDelta = new Vector2(376f, 155f);
		RectTransform rectTransform = (RectTransform)child2;
		rectTransform.anchoredPosition = new Vector2(46.1f, -162.9f);
		rectTransform.sizeDelta = new Vector2(360f, 86f);
		float num2 = component2.preferredHeight - 86f;
		if (num2 > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num2);
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num2);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num2 + 1f);
		}
		child.GetChild(4).gameObject.SetActive(false);
		child.GetChild(5).gameObject.SetActive(false);
		child2 = child.GetChild(6);
		child2.gameObject.SetActive(true);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		child2.GetChild(2).gameObject.SetActive(true);
		UIButton component3 = child2.GetComponent<UIButton>();
		component3.m_Handler = this;
		if (!this.bCheckCrystal && curItemQuantity <= 0)
		{
			component3.m_BtnID1 = 15;
			ushort inKey = dataManager.TotalShopItemData.Find(ItemID);
			StoreTbl recordByKey2 = dataManager.StoreData.GetRecordByKey(inKey);
			this.tmpCheckCrystal = recordByKey2.Price;
			component3.m_BtnID4 = (int)recordByKey2.Price;
			this.m_CheckCrystalButton = component3;
		}
		else
		{
			component3.m_BtnID1 = 1;
			component3.m_BtnID2 = 1;
		}
		component2 = child2.GetChild(0).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		this.m_MsgText.Add(component2);
		if (curItemQuantity > 0)
		{
			if (HaveItemText != null)
			{
				if (this.useOrSpendType == UseOrSpendType.UST_WORLDTELEPORT && NoItemText != null && num > 1)
				{
					if (this.m_OKString == null)
					{
						this.m_OKString = stringManager.SpawnString(30);
					}
					this.m_OKString.Length = 0;
					this.m_OKString.StringToFormat(NoItemText);
					this.m_OKString.IntToFormat((long)num, 1, false);
					this.m_OKString.StringToFormat(dataManager.mStringTable.GetStringByID(949u));
					if (num > curItemQuantity)
					{
						this.m_OKString.AppendFormat("<color=#FF0000>{0}{1}</color>\n{2}");
						if (this.m_OKCancelClickIndex == 3)
						{
							this.m_OKCancelClickIndex = 12;
						}
					}
					else
					{
						this.m_OKString.AppendFormat("{0}{1}\n{2}");
					}
					component2.text = this.m_OKString.ToString();
				}
				else
				{
					component2.text = HaveItemText;
				}
			}
			else
			{
				component2.text = dataManager.mStringTable.GetStringByID(94u);
			}
			component2.rectTransform.offsetMin = new Vector2(1f, 6.15f);
			component2.rectTransform.offsetMax = new Vector2(-1f, -6.15f);
			component2.alignment = TextAnchor.MiddleCenter;
			child2.GetChild(1).gameObject.SetActive(false);
			child2.GetChild(2).gameObject.SetActive(false);
		}
		else
		{
			ushort num3 = dataManager.TotalShopItemData.Find(ItemID);
			if (num3 == 0)
			{
				if (this.m_OKString == null)
				{
					this.m_OKString = stringManager.SpawnString(30);
				}
				this.m_OKString.Length = 0;
				this.m_OKString.StringToFormat(dataManager.mStringTable.GetStringByID(94u));
				this.m_OKString.AppendFormat("<color=#E5004F>{0}</color>");
				component2.text = this.m_OKString.ToString();
				component2.rectTransform.offsetMin = new Vector2(1f, 6.15f);
				component2.rectTransform.offsetMax = new Vector2(-1f, -6.15f);
				component2.alignment = TextAnchor.MiddleCenter;
				child2.GetChild(1).gameObject.SetActive(false);
				child2.GetChild(2).gameObject.SetActive(false);
				component3.m_BtnID1 = 17;
			}
			else
			{
				if (NoItemText != null)
				{
					component2.text = NoItemText;
				}
				else
				{
					component2.text = dataManager.mStringTable.GetStringByID(4062u);
				}
				component2 = child2.GetChild(1).GetComponent<UIText>();
				component2.font = this.GetTTFFont();
				this.m_MsgText.Add(component2);
				if (this.m_OKString == null)
				{
					this.m_OKString = stringManager.SpawnString(30);
				}
				this.m_OKString.Length = 0;
				StoreTbl recordByKey3 = dataManager.StoreData.GetRecordByKey(num3);
				this.m_OKString.IntToFormat((long)((ulong)recordByKey3.Price), 1, true);
				this.m_OKString.AppendFormat("{0}");
				component2.text = this.m_OKString.ToString();
				component = child2.GetChild(2).GetComponent<CustomImage>();
				component.hander = this;
			}
		}
		if (this.m_OKCancelClickIndex == 3 || this.m_OKCancelClickIndex == 12)
		{
			arg1 &= 65535;
			arg1 |= (int)ItemID << 16;
		}
		child2 = child.GetChild(7);
		child2.gameObject.SetActive(true);
		component2 = child2.GetChild(0).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = dataManager.mStringTable.GetStringByID((uint)recordByKey.EquipName);
		this.m_MsgText.Add(component2);
		Transform child3 = child2.GetChild(1);
		component = child3.GetComponent<CustomImage>();
		component.hander = this;
		component2 = child3.GetChild(0).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		this.m_MsgText.Add(component2);
		if (this.m_OKString_ItemCount == null)
		{
			this.m_OKString_ItemCount = stringManager.SpawnString(30);
		}
		this.m_OKString_ItemCount.Length = 0;
		this.m_OKString_ItemCount.StringToFormat(dataManager.mStringTable.GetStringByID(281u));
		this.m_OKString_ItemCount.IntToFormat((long)curItemQuantity, 1, true);
		this.m_OKString_ItemCount.AppendFormat("{0}{1}");
		component2.text = this.m_OKString_ItemCount.ToString();
		child3 = child2.GetChild(2);
		this.InitianHeroItemImg(child3, eHeroOrItem.Item, ItemID, 0, 0, 0, false, false, true, false);
		RectTransform rectTransform2 = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform2.sizeDelta.y + 109f > y)
		{
			float num4 = (y - rectTransform2.sizeDelta.y) * 0.5f;
			if (num4 < 0f)
			{
				num4 = 19f;
			}
			rectTransform2.anchoredPosition = new Vector2(rectTransform2.anchoredPosition.x, -num4);
		}
		child2 = child.GetChild(8);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_OKCancelCloseButton = child2.GetComponent<UIButton>();
		this.m_OKCancelCloseButton.m_Handler = this;
		this.m_OKCancelCloseButton.m_BtnID1 = 2;
		this.m_OKCancelBoxHandler = win;
		this.m_OKCancelBoxArg1 = arg1;
		this.m_OKCancelBoxArg2 = arg2;
	}

	// Token: 0x0600062B RID: 1579 RVA: 0x000895E0 File Offset: 0x000877E0
	public bool UseOrSpend(ushort ItemID, string TitleText, ushort TargetID = 0, ushort Parameter1 = 0, ushort Parameter2 = 0, UseOrSpendType Type = UseOrSpendType.UST_DIAMOND_NORMAL, string HaveItemText = null, string NoItemText = null, string SpecialStr = null, ushort maxcount = 0)
	{
		if (this.useOrSpendType != UseOrSpendType.UST_MAX)
		{
			return false;
		}
		this.useOrSpendType = Type;
		this.OpenSpendWindow_ItemID(3, TitleText, ItemID, (int)TargetID | (int)maxcount << 16, (int)Parameter1 << 16 | (int)Parameter2, HaveItemText, NoItemText, SpecialStr);
		return true;
	}

	// Token: 0x0600062C RID: 1580 RVA: 0x00089624 File Offset: 0x00087824
	public void OpenSpendWindow_ItemID2(int ClickIndex, string TitleText, ushort ItemID1, ushort ItemID2, uint price, ushort day, byte hour, byte min, byte sec, bool bShowCount = true, int arg1 = 0, int arg2 = 0, string HaveItemText = null, string NoItemText = null, string BottomText = null)
	{
		this.m_OKCancelClickIndex = ClickIndex;
		this.OpenSpendWindow_ItemID2(null, TitleText, ItemID1, ItemID2, price, day, hour, min, sec, bShowCount, arg1, arg2, HaveItemText, NoItemText, BottomText);
	}

	// Token: 0x0600062D RID: 1581 RVA: 0x0008965C File Offset: 0x0008785C
	public void OpenSpendWindow_ItemID2(GUIWindow win, string TitleText, ushort ItemID1, ushort ItemID2, uint price, ushort day, byte hour, byte min, byte sec, bool bShowCount = true, int arg1 = 0, int arg2 = 0, string HaveItemText = null, string NoItemText = null, string BottomText = null)
	{
		if (this.m_OKCancelBox != null)
		{
			return;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UIOKCancelBox");
		if (@object == null)
		{
			return;
		}
		this.m_MsgText.Clear();
		this.HideArrow(false);
		this.m_OKCancelBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_OKCancelBox.transform.SetParent(this.m_MessageBoxLayer, false);
		DataManager dataManager = DataManager.Instance;
		StringManager stringManager = StringManager.Instance;
		CustomImage component = this.m_OKCancelBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		Transform child = this.m_OKCancelBox.transform.GetChild(0);
		child.gameObject.SetActive(false);
		child = this.m_OKCancelBox.transform.GetChild(1);
		child.gameObject.SetActive(true);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		Transform child2 = child.GetChild(1);
		UIText component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = TitleText;
		this.m_MsgText.Add(component2);
		Equip recordByKey = dataManager.EquipTable.GetRecordByKey(ItemID1);
		Equip recordByKey2 = dataManager.EquipTable.GetRecordByKey(ItemID2);
		child2 = child.GetChild(2);
		component = child2.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		this.InitianHeroItemImg(child2.GetChild(1), eHeroOrItem.Item, ItemID1, 0, 0, 0, false, false, true, false);
		ushort curItemQuantity = dataManager.GetCurItemQuantity(ItemID1, 0);
		Transform child3;
		if (bShowCount)
		{
			child3 = child2.GetChild(2);
			component = child3.GetComponent<CustomImage>();
			component.hander = this;
			component2 = child3.GetChild(0).GetComponent<UIText>();
			component2.font = this.GetTTFFont();
			this.m_MsgText.Add(component2);
			if (this.m_OKString_ItemCount == null)
			{
				this.m_OKString_ItemCount = stringManager.SpawnString(30);
			}
			this.m_OKString_ItemCount.Length = 0;
			this.m_OKString_ItemCount.StringToFormat(dataManager.mStringTable.GetStringByID(281u));
			this.m_OKString_ItemCount.IntToFormat((long)curItemQuantity, 1, true);
			this.m_OKString_ItemCount.AppendFormat("{0}{1}");
			component2.text = this.m_OKString_ItemCount.ToString();
		}
		else
		{
			child2.GetChild(2).gameObject.SetActive(false);
		}
		component2 = child2.GetChild(3).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = dataManager.mStringTable.GetStringByID((uint)recordByKey.EquipName);
		this.m_MsgText.Add(component2);
		component2 = child2.GetChild(4).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = dataManager.mStringTable.GetStringByID((uint)recordByKey.EquipInfo);
		this.m_MsgText.Add(component2);
		float num = component2.preferredHeight - 28f;
		if (num > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num);
			((RectTransform)child2.GetChild(4)).sizeDelta += new Vector2(0f, num);
		}
		child3 = child2.GetChild(5);
		component = child3.GetComponent<CustomImage>();
		component.hander = this;
		UIButton component3 = child3.GetComponent<UIButton>();
		component3.m_Handler = this;
		if (!this.bCheckCrystal && curItemQuantity <= 0)
		{
			component3.m_BtnID1 = 15;
			component3.m_BtnID4 = (int)price;
			this.tmpCheckCrystal = price;
			this.m_CheckCrystalButton = component3;
		}
		else
		{
			component3.m_BtnID1 = 1;
			component3.m_BtnID2 = 1;
		}
		component2 = child3.GetChild(0).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		this.m_MsgText.Add(component2);
		if (bShowCount)
		{
			if (curItemQuantity > 0 && HaveItemText != null)
			{
				component2.text = HaveItemText;
				child3.GetChild(1).gameObject.SetActive(false);
				child3.GetChild(2).gameObject.SetActive(false);
				component2.rectTransform.offsetMin = new Vector2(1f, 6.15f);
				component2.rectTransform.offsetMax = new Vector2(-1f, -6.15f);
			}
			else if (curItemQuantity == 0 && NoItemText != null)
			{
				component2.text = NoItemText;
			}
			else
			{
				component2.text = dataManager.mStringTable.GetStringByID(284u);
			}
		}
		else if (HaveItemText != null)
		{
			component2.text = HaveItemText;
		}
		else
		{
			component2.text = dataManager.mStringTable.GetStringByID(284u);
		}
		component2 = child3.GetChild(1).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		this.m_MsgText.Add(component2);
		if (this.m_OKString == null)
		{
			this.m_OKString = stringManager.SpawnString(30);
		}
		this.m_OKString.Length = 0;
		this.m_OKString.IntToFormat((long)((ulong)price), 1, true);
		this.m_OKString.AppendFormat("{0}");
		component2.text = this.m_OKString.ToString();
		component = child3.GetChild(2).GetComponent<CustomImage>();
		component.hander = this;
		child2 = child.GetChild(3);
		if (num > 0f)
		{
			((RectTransform)child2).anchoredPosition += new Vector2(0f, -num);
		}
		component = child2.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		if (recordByKey2.EquipPicture > 0)
		{
			this.InitianHeroItemImg(child2.GetChild(1), eHeroOrItem.Item, ItemID2, 0, 0, 0, false, false, true, false);
		}
		else
		{
			child2.GetChild(1).gameObject.SetActive(false);
		}
		child3 = child2.GetChild(2);
		child3.gameObject.SetActive(false);
		component2 = child2.GetChild(3).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = dataManager.mStringTable.GetStringByID((uint)recordByKey2.EquipName);
		this.m_MsgText.Add(component2);
		component2 = child2.GetChild(4).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = dataManager.mStringTable.GetStringByID((uint)recordByKey2.EquipInfo);
		this.m_MsgText.Add(component2);
		float num2 = component2.preferredHeight - 28f;
		if (num2 > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num2);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num2);
			((RectTransform)child2.GetChild(4)).sizeDelta += new Vector2(0f, num2);
		}
		child3 = child2.GetChild(5);
		component = child3.GetComponent<CustomImage>();
		component.hander = this;
		component3 = child3.GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 1;
		component3.m_BtnID2 = 2;
		component = child3.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child3.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		component2 = child3.GetChild(2).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		if (BottomText != null)
		{
			component2.text = BottomText;
		}
		else
		{
			component2.text = dataManager.mStringTable.GetStringByID(94u);
		}
		this.m_MsgText.Add(component2);
		component2 = child3.GetChild(3).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		if (this.m_OKString2 == null)
		{
			this.m_OKString2 = stringManager.SpawnString(30);
		}
		this.m_OKString2.Length = 0;
		if (day > 0)
		{
			this.m_OKString2.IntToFormat((long)day, 1, false);
		}
		this.m_OKString2.IntToFormat((long)hour, 2, false);
		this.m_OKString2.IntToFormat((long)min, 2, false);
		this.m_OKString2.IntToFormat((long)sec, 2, false);
		if (day > 0)
		{
			this.m_OKString2.AppendFormat("{0}d {1}:{2}:{3}");
		}
		else
		{
			this.m_OKString2.AppendFormat("{0}:{1}:{2}");
		}
		component2.text = this.m_OKString2.ToString();
		this.m_MsgText.Add(component2);
		RectTransform rectTransform = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform.sizeDelta.y + 109f > y)
		{
			float num3 = (y - rectTransform.sizeDelta.y) * 0.5f;
			if (num3 < 0f)
			{
				num3 = 19f;
			}
			rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -num3);
		}
		child2 = child.GetChild(4);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_OKCancelCloseButton = child2.GetComponent<UIButton>();
		this.m_OKCancelCloseButton.m_Handler = this;
		this.m_OKCancelCloseButton.m_BtnID1 = 2;
		this.m_OKCancelBoxHandler = win;
		this.m_OKCancelBoxArg1 = arg1;
		this.m_OKCancelBoxArg2 = arg2;
	}

	// Token: 0x0600062E RID: 1582 RVA: 0x0008A01C File Offset: 0x0008821C
	public void OpenAntiAddictiveMessageBox(NotificationStage stage, string TitleText, string MessageText, string ButtonText, bool bShowRealNameBtn, bool bShowCloseBtn, int arg1, int arg2)
	{
		int num = (stage != NotificationStage.Stage5) ? 1 : 3;
		if (this.m_OKCancelBox != null)
		{
			return;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UIOKCancelBox");
		if (@object == null)
		{
			return;
		}
		this.m_MsgText.Clear();
		this.HideArrow(false);
		this.m_OKCancelBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_OKCancelBox.transform.SetParent(this.m_MessageBoxLayer, false);
		CustomImage component = this.m_OKCancelBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		Transform child = this.m_OKCancelBox.transform.GetChild(0);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		Transform child2 = child.GetChild(2);
		UIText component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		if (TitleText == null)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(3782u);
		}
		else
		{
			component2.text = TitleText;
		}
		this.m_MsgText.Add(component2);
		child2 = child.GetChild(3);
		component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = MessageText;
		this.m_MsgText.Add(component2);
		float num2 = component2.preferredHeight - 86.8f;
		if (num2 > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num2);
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num2);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num2);
		}
		child2 = child.GetChild(4);
		((RectTransform)child2).anchoredPosition = new Vector2(0f, 75f);
		((RectTransform)child2).sizeDelta += new Vector2(121f, 0f);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		UIButton component3 = child2.GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = arg1;
		component3.m_BtnID2 = num;
		child2 = child2.GetChild(0);
		component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		if (stage == NotificationStage.Stage5)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(10062u);
		}
		else
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(3u);
		}
		this.m_MsgText.Add(component2);
		if (bShowRealNameBtn)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, 50f);
			child2 = child.GetChild(5);
			((RectTransform)child2).anchoredPosition = new Vector2(0f, 125f);
			((RectTransform)child2).sizeDelta += new Vector2(121f, 0f);
			component = child2.GetComponent<CustomImage>();
			component.hander = this;
			component3 = child2.GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = arg1;
			component3.m_BtnID2 = 2;
			child2 = child2.GetChild(0);
			component2 = child2.GetComponent<UIText>();
			component2.font = this.GetTTFFont();
			component2.text = DataManager.Instance.mStringTable.GetStringByID(9677u);
			this.m_MsgText.Add(component2);
		}
		else
		{
			child.GetChild(5).gameObject.SetActive(false);
		}
		RectTransform rectTransform = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform.sizeDelta.y + 109f > y)
		{
			float num3 = (y - rectTransform.sizeDelta.y) * 0.5f;
			if (num3 < 0f)
			{
				num3 = 19f;
			}
			rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -num3);
		}
		child2 = child.GetChild(8);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_OKCancelCloseButton = child2.GetComponent<UIButton>();
		this.m_OKCancelCloseButton.m_Handler = this;
		this.m_OKCancelCloseButton.m_BtnID1 = arg1;
		this.m_OKCancelCloseButton.m_BtnID2 = num;
		if (bShowCloseBtn)
		{
			HelperUIButton helperUIButton = this.m_OKCancelBox.AddComponent<HelperUIButton>();
			helperUIButton.m_Handler = this;
			helperUIButton.m_BtnID1 = 1;
			helperUIButton.m_BtnID2 = 2;
		}
		if (!bShowCloseBtn)
		{
			child.GetChild(8).gameObject.SetActive(false);
		}
		this.m_OKCancelBoxHandler = null;
		this.m_OKCancelBoxArg1 = arg1;
		this.m_OKCancelBoxArg2 = num;
		AntiAddictive.Instance.SetAnitAddicitvDlgStage(stage);
	}

	// Token: 0x0600062F RID: 1583 RVA: 0x0008A544 File Offset: 0x00088744
	public void OpenRealNameMessageBox(RealNameState state)
	{
		int num = 22;
		int btnID;
		if (state == RealNameState.None)
		{
			btnID = 0;
		}
		else if (state == RealNameState.UnAuthorized)
		{
			btnID = 1;
		}
		else if (state == RealNameState.Sumbitted)
		{
			btnID = 2;
		}
		else
		{
			btnID = 3;
		}
		if (this.m_OKCancelBox != null)
		{
			return;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UIOKCancelBox");
		if (@object == null)
		{
			return;
		}
		this.m_MsgText.Clear();
		this.HideArrow(false);
		this.m_OKCancelBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_OKCancelBox.transform.SetParent(this.m_MessageBoxLayer, false);
		CustomImage component = this.m_OKCancelBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		Transform child = this.m_OKCancelBox.transform.GetChild(0);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		Transform child2 = child.GetChild(2);
		UIText component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9677u);
		this.m_MsgText.Add(component2);
		child2 = child.GetChild(3);
		component2 = child2.GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		if (state == RealNameState.None)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(14558u);
		}
		else if (state == RealNameState.UnAuthorized)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(14560u);
		}
		else if (state == RealNameState.Sumbitted)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(16086u);
		}
		else if (state == RealNameState.Authorized)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(14559u);
		}
		this.m_MsgText.Add(component2);
		float num2 = component2.preferredHeight - 86.8f;
		if (num2 > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num2);
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num2);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num2);
		}
		child2 = child.GetChild(4);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		UIButton component3 = child2.GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = num;
		component3.m_BtnID2 = btnID;
		component2 = child2.GetChild(0).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		if (state == RealNameState.None || state == RealNameState.UnAuthorized)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(3968u);
		}
		else if (state == RealNameState.Sumbitted || state == RealNameState.Authorized)
		{
			((RectTransform)child2).anchoredPosition = new Vector2(0f, 75f);
			((RectTransform)child2).sizeDelta += new Vector2(121f, 0f);
			component2.text = DataManager.Instance.mStringTable.GetStringByID(3u);
		}
		this.m_MsgText.Add(component2);
		child2 = child.GetChild(5);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component3 = child2.GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = num;
		component3.m_BtnID2 = 4;
		component2 = child2.GetChild(0).GetComponent<UIText>();
		component2.font = this.GetTTFFont();
		if (state == RealNameState.None || state == RealNameState.UnAuthorized)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(188u);
			child2.gameObject.SetActive(true);
			this.m_MsgText.Add(component2);
		}
		else if (state == RealNameState.Sumbitted || state == RealNameState.Authorized)
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(3u);
			child2.gameObject.SetActive(false);
			this.m_MsgText.Add(component2);
		}
		RectTransform rectTransform = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform.sizeDelta.y + 109f > y)
		{
			float num3 = (y - rectTransform.sizeDelta.y) * 0.5f;
			if (num3 < 0f)
			{
				num3 = 19f;
			}
			rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -num3);
		}
		child2 = child.GetChild(8);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_OKCancelCloseButton = child2.GetComponent<UIButton>();
		this.m_OKCancelCloseButton.m_Handler = this;
		this.m_OKCancelCloseButton.m_BtnID1 = num;
		this.m_OKCancelCloseButton.m_BtnID2 = 4;
		this.m_OKCancelBoxHandler = null;
		this.m_OKCancelBoxArg1 = num;
		this.m_OKCancelBoxArg2 = 0;
	}

	// Token: 0x06000630 RID: 1584 RVA: 0x0008AAAC File Offset: 0x00088CAC
	public void CloseAntiAddictiveMessageBox()
	{
		this.CloseOKCancelBox();
		AntiAddictive.Instance.SetAnitAddicitvDlgStage(NotificationStage.None);
	}

	// Token: 0x06000631 RID: 1585 RVA: 0x0008AAC0 File Offset: 0x00088CC0
	public void CloseOKCancelBox()
	{
		if (this.m_OKCancelBox == null)
		{
			return;
		}
		this.m_MsgText.Clear();
		UnityEngine.Object.Destroy(this.m_OKCancelBox);
		this.m_OKCancelBox = null;
		this.m_OKCancelClickIndex = -1;
		this.MsgBarTimeText = null;
		this.MsgBarImage = null;
		this.MsgBarTimeSec = (this.MaxBarTimeSec = 0f);
	}

	// Token: 0x06000632 RID: 1586 RVA: 0x0008AB28 File Offset: 0x00088D28
	public bool OpenCheckCrystal(uint price, byte Kind = 0, int Para1 = -1, int Para2 = -1)
	{
		if (this.bCheckCrystal)
		{
			return false;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UICheckCryctalBox");
		if (@object == null)
		{
			return false;
		}
		this.CheckCrystalKind = Kind;
		this.CheckCrystalPara1 = Para1;
		this.CheckCrystalPara2 = Para2;
		this.m_CheckCrystalBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_CheckCrystalBox.transform.SetParent(this.m_MessageBoxLayer, false);
		CustomImage component = this.m_CheckCrystalBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		Transform child = this.m_CheckCrystalBox.transform.GetChild(0);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(8).GetComponent<CustomImage>();
		component.hander = this;
		this.CheckCrystalImg = child.GetChild(9).GetComponent<CustomImage>();
		this.CheckCrystalImg.hander = this;
		if (this.IsArabic)
		{
			this.CheckCrystalImg.rectTransform.localScale = new Vector3(-this.CheckCrystalImg.rectTransform.localScale.x, this.CheckCrystalImg.rectTransform.localScale.y, this.CheckCrystalImg.rectTransform.localScale.z);
			this.CheckCrystalImg.rectTransform.anchoredPosition += new Vector2(this.CheckCrystalImg.rectTransform.sizeDelta.x, 0f);
		}
		Transform child2 = child.GetChild(2);
		this.CheckCrystalText[0] = child2.GetComponent<UIText>();
		this.CheckCrystalText[0].font = this.GetTTFFont();
		this.CheckCrystalText[0].text = DataManager.Instance.mStringTable.GetStringByID(614u);
		child2 = child.GetChild(3);
		this.CheckCrystalStr = StringManager.Instance.SpawnString(1024);
		this.CheckCrystalStr.IntToFormat((long)((ulong)price), 1, true);
		this.CheckCrystalStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(966u));
		this.CheckCrystalText[1] = child2.GetComponent<UIText>();
		this.CheckCrystalText[1].font = this.GetTTFFont();
		this.CheckCrystalText[1].text = this.CheckCrystalStr.ToString();
		this.CheckCrystalText[1].SetAllDirty();
		this.CheckCrystalText[1].cachedTextGenerator.Invalidate();
		float num = this.CheckCrystalText[1].preferredHeight - 86.8f;
		if (num > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num);
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num);
		}
		child2 = child.GetChild(4);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		UIButton component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 14;
		component2.m_BtnID2 = 1;
		child2 = child2.GetChild(0);
		this.CheckCrystalText[2] = child2.GetComponent<UIText>();
		this.CheckCrystalText[2].font = this.GetTTFFont();
		this.CheckCrystalText[2].text = DataManager.Instance.mStringTable.GetStringByID(189u);
		child2 = child.GetChild(5);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 14;
		component2.m_BtnID2 = 2;
		child2 = child2.GetChild(0);
		this.CheckCrystalText[3] = child2.GetComponent<UIText>();
		this.CheckCrystalText[3].font = this.GetTTFFont();
		this.CheckCrystalText[3].text = DataManager.Instance.mStringTable.GetStringByID(188u);
		if (this.IsArabic)
		{
			RectTransform rectTransform = (RectTransform)child.GetChild(4);
			RectTransform rectTransform2 = (RectTransform)child.GetChild(5);
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			rectTransform.anchoredPosition = rectTransform2.anchoredPosition;
			rectTransform2.anchoredPosition = anchoredPosition;
		}
		RectTransform rectTransform3 = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform3.sizeDelta.y + 109f > y)
		{
			float num2 = (y - rectTransform3.sizeDelta.y) * 0.5f;
			if (num2 < 0f)
			{
				num2 = 19f;
			}
			rectTransform3.anchoredPosition = new Vector2(rectTransform3.anchoredPosition.x, -num2);
		}
		child2 = child.GetChild(6);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_CheckCrystalCloseButton = child2.GetComponent<UIButton>();
		this.m_CheckCrystalCloseButton.m_Handler = this;
		this.m_CheckCrystalCloseButton.m_BtnID1 = 14;
		this.m_CheckCrystalCloseButton.m_BtnID2 = 2;
		child2 = child.GetChild(7);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 14;
		component2.m_BtnID2 = 3;
		child2 = child.GetChild(10);
		this.CheckCrystalText[4] = child2.GetComponent<UIText>();
		this.CheckCrystalText[4].font = this.GetTTFFont();
		this.CheckCrystalText[4].text = DataManager.Instance.mStringTable.GetStringByID(967u);
		this.HideArrow(false);
		return true;
	}

	// Token: 0x06000633 RID: 1587 RVA: 0x0008B104 File Offset: 0x00089304
	public bool OpenCheckGamble()
	{
		if (GamblingManager.Instance.bIsFirstOpen)
		{
			return false;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UICheckCryctalBox");
		if (@object == null)
		{
			return false;
		}
		this.m_CheckCrystalBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_CheckCrystalBox.transform.SetParent(this.m_MessageBoxLayer, false);
		CustomImage component = this.m_CheckCrystalBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		Transform child = this.m_CheckCrystalBox.transform.GetChild(0);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(8).GetComponent<CustomImage>();
		component.hander = this;
		this.CheckCrystalImg = child.GetChild(9).GetComponent<CustomImage>();
		this.CheckCrystalImg.hander = this;
		if (this.IsArabic)
		{
			this.CheckCrystalImg.rectTransform.localScale = new Vector3(-this.CheckCrystalImg.rectTransform.localScale.x, this.CheckCrystalImg.rectTransform.localScale.y, this.CheckCrystalImg.rectTransform.localScale.z);
			this.CheckCrystalImg.rectTransform.anchoredPosition += new Vector2(this.CheckCrystalImg.rectTransform.sizeDelta.x, 0f);
		}
		Transform child2 = child.GetChild(2);
		this.CheckCrystalText[0] = child2.GetComponent<UIText>();
		this.CheckCrystalText[0].font = this.GetTTFFont();
		this.CheckCrystalText[0].text = DataManager.Instance.mStringTable.GetStringByID(614u);
		child2 = child.GetChild(3);
		this.CheckCrystalText[1] = child2.GetComponent<UIText>();
		this.CheckCrystalText[1].font = this.GetTTFFont();
		this.CheckCrystalText[1].text = DataManager.Instance.mStringTable.GetStringByID(9174u);
		this.CheckCrystalText[1].SetAllDirty();
		this.CheckCrystalText[1].cachedTextGenerator.Invalidate();
		float num = this.CheckCrystalText[1].preferredHeight - 86.8f;
		if (num > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num);
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num);
		}
		child2 = child.GetChild(4);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		UIButton component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 16;
		component2.m_BtnID2 = 1;
		child2 = child2.GetChild(0);
		this.CheckCrystalText[2] = child2.GetComponent<UIText>();
		this.CheckCrystalText[2].font = this.GetTTFFont();
		this.CheckCrystalText[2].text = DataManager.Instance.mStringTable.GetStringByID(189u);
		child2 = child.GetChild(5);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 16;
		component2.m_BtnID2 = 2;
		child2 = child2.GetChild(0);
		this.CheckCrystalText[3] = child2.GetComponent<UIText>();
		this.CheckCrystalText[3].font = this.GetTTFFont();
		this.CheckCrystalText[3].text = DataManager.Instance.mStringTable.GetStringByID(188u);
		if (this.IsArabic)
		{
			RectTransform rectTransform = (RectTransform)child.GetChild(4);
			RectTransform rectTransform2 = (RectTransform)child.GetChild(5);
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			rectTransform.anchoredPosition = rectTransform2.anchoredPosition;
			rectTransform2.anchoredPosition = anchoredPosition;
		}
		RectTransform rectTransform3 = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform3.sizeDelta.y + 109f > y)
		{
			float num2 = (y - rectTransform3.sizeDelta.y) * 0.5f;
			if (num2 < 0f)
			{
				num2 = 19f;
			}
			rectTransform3.anchoredPosition = new Vector2(rectTransform3.anchoredPosition.x, -num2);
		}
		child2 = child.GetChild(6);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_CheckCrystalCloseButton = child2.GetComponent<UIButton>();
		this.m_CheckCrystalCloseButton.m_Handler = this;
		this.m_CheckCrystalCloseButton.m_BtnID1 = 16;
		this.m_CheckCrystalCloseButton.m_BtnID2 = 2;
		child2 = child.GetChild(7);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 16;
		component2.m_BtnID2 = 3;
		child2 = child.GetChild(10);
		this.CheckCrystalText[4] = child2.GetComponent<UIText>();
		this.CheckCrystalText[4].font = this.GetTTFFont();
		this.CheckCrystalText[4].text = DataManager.Instance.mStringTable.GetStringByID(967u);
		this.HideArrow(false);
		return true;
	}

	// Token: 0x06000634 RID: 1588 RVA: 0x0008B694 File Offset: 0x00089894
	public bool OpenCheckAWSSchedule(string str, byte matchid)
	{
		if (!this.bCheckAWSSchedule)
		{
			return false;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UICheckCryctalBox");
		if (@object == null)
		{
			return false;
		}
		this.m_CheckCrystalBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_CheckCrystalBox.transform.SetParent(this.m_MessageBoxLayer, false);
		CustomImage component = this.m_CheckCrystalBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		UIButton uibutton = this.m_CheckCrystalBox.transform.gameObject.AddComponent<UIButton>();
		uibutton.m_BtnID1 = 18;
		uibutton.m_BtnID2 = 2;
		uibutton.m_Handler = this;
		Transform child = this.m_CheckCrystalBox.transform.GetChild(0);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(8).GetComponent<CustomImage>();
		component.hander = this;
		this.CheckCrystalImg = child.GetChild(9).GetComponent<CustomImage>();
		this.CheckCrystalImg.hander = this;
		if (this.IsArabic)
		{
			this.CheckCrystalImg.rectTransform.localScale = new Vector3(-this.CheckCrystalImg.rectTransform.localScale.x, this.CheckCrystalImg.rectTransform.localScale.y, this.CheckCrystalImg.rectTransform.localScale.z);
			this.CheckCrystalImg.rectTransform.anchoredPosition += new Vector2(this.CheckCrystalImg.rectTransform.sizeDelta.x, 0f);
		}
		Transform child2 = child.GetChild(2);
		this.CheckCrystalText[0] = child2.GetComponent<UIText>();
		this.CheckCrystalText[0].font = this.GetTTFFont();
		this.CheckCrystalText[0].text = DataManager.Instance.mStringTable.GetStringByID(614u);
		child2 = child.GetChild(3);
		this.CheckCrystalText[1] = child2.GetComponent<UIText>();
		this.CheckCrystalText[1].font = this.GetTTFFont();
		this.CheckCrystalText[1].text = str;
		this.CheckCrystalText[1].SetAllDirty();
		this.CheckCrystalText[1].cachedTextGenerator.Invalidate();
		float num = this.CheckCrystalText[1].preferredHeight - 86.8f;
		if (num > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num);
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num);
		}
		child2 = child.GetChild(4);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		UIButton component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 18;
		component2.m_BtnID2 = 1;
		component2.m_BtnID3 = (int)matchid;
		child2 = child2.GetChild(0);
		this.CheckCrystalText[2] = child2.GetComponent<UIText>();
		this.CheckCrystalText[2].font = this.GetTTFFont();
		this.CheckCrystalText[2].text = DataManager.Instance.mStringTable.GetStringByID(189u);
		child2 = child.GetChild(5);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 18;
		component2.m_BtnID2 = 2;
		child2 = child2.GetChild(0);
		this.CheckCrystalText[3] = child2.GetComponent<UIText>();
		this.CheckCrystalText[3].font = this.GetTTFFont();
		this.CheckCrystalText[3].text = DataManager.Instance.mStringTable.GetStringByID(188u);
		if (this.IsArabic)
		{
			RectTransform rectTransform = (RectTransform)child.GetChild(4);
			RectTransform rectTransform2 = (RectTransform)child.GetChild(5);
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			rectTransform.anchoredPosition = rectTransform2.anchoredPosition;
			rectTransform2.anchoredPosition = anchoredPosition;
		}
		RectTransform rectTransform3 = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform3.sizeDelta.y + 109f > y)
		{
			float num2 = (y - rectTransform3.sizeDelta.y) * 0.5f;
			if (num2 < 0f)
			{
				num2 = 19f;
			}
			rectTransform3.anchoredPosition = new Vector2(rectTransform3.anchoredPosition.x, -num2);
		}
		child2 = child.GetChild(6);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_CheckCrystalCloseButton = child2.GetComponent<UIButton>();
		this.m_CheckCrystalCloseButton.m_Handler = this;
		this.m_CheckCrystalCloseButton.m_BtnID1 = 18;
		this.m_CheckCrystalCloseButton.m_BtnID2 = 2;
		child2 = child.GetChild(7);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 18;
		component2.m_BtnID2 = 3;
		child2 = child.GetChild(10);
		this.CheckCrystalText[4] = child2.GetComponent<UIText>();
		this.CheckCrystalText[4].font = this.GetTTFFont();
		this.CheckCrystalText[4].text = DataManager.Instance.mStringTable.GetStringByID(967u);
		this.HideArrow(false);
		return true;
	}

	// Token: 0x06000635 RID: 1589 RVA: 0x0008BC44 File Offset: 0x00089E44
	public bool OpenCheckWarlobbyTroopSelect()
	{
		if (DataManager.Instance.bFirstOpenWarlobbyTroopSelect)
		{
			return false;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UICheckCryctalBox");
		if (@object == null)
		{
			return false;
		}
		this.m_CheckCrystalBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_CheckCrystalBox.transform.SetParent(this.m_MessageBoxLayer, false);
		CustomImage component = this.m_CheckCrystalBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		Transform child = this.m_CheckCrystalBox.transform.GetChild(0);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(8).GetComponent<CustomImage>();
		component.hander = this;
		this.CheckCrystalImg = child.GetChild(9).GetComponent<CustomImage>();
		this.CheckCrystalImg.hander = this;
		if (this.IsArabic)
		{
			this.CheckCrystalImg.rectTransform.localScale = new Vector3(-this.CheckCrystalImg.rectTransform.localScale.x, this.CheckCrystalImg.rectTransform.localScale.y, this.CheckCrystalImg.rectTransform.localScale.z);
			this.CheckCrystalImg.rectTransform.anchoredPosition += new Vector2(this.CheckCrystalImg.rectTransform.sizeDelta.x, 0f);
		}
		Transform child2 = child.GetChild(2);
		this.CheckCrystalText[0] = child2.GetComponent<UIText>();
		this.CheckCrystalText[0].font = this.GetTTFFont();
		this.CheckCrystalText[0].text = DataManager.Instance.mStringTable.GetStringByID(614u);
		child2 = child.GetChild(3);
		this.CheckCrystalText[1] = child2.GetComponent<UIText>();
		this.CheckCrystalText[1].font = this.GetTTFFont();
		this.CheckCrystalText[1].text = DataManager.Instance.mStringTable.GetStringByID(14722u);
		this.CheckCrystalText[1].SetAllDirty();
		this.CheckCrystalText[1].cachedTextGenerator.Invalidate();
		float num = this.CheckCrystalText[1].preferredHeight - 86.8f;
		if (num > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num);
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num);
		}
		child2 = child.GetChild(4);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		UIButton component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 23;
		component2.m_BtnID2 = 1;
		child2 = child2.GetChild(0);
		this.CheckCrystalText[2] = child2.GetComponent<UIText>();
		this.CheckCrystalText[2].font = this.GetTTFFont();
		this.CheckCrystalText[2].text = DataManager.Instance.mStringTable.GetStringByID(3u);
		child2 = child.GetChild(5);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 23;
		component2.m_BtnID2 = 2;
		child2 = child2.GetChild(0);
		this.CheckCrystalText[3] = child2.GetComponent<UIText>();
		this.CheckCrystalText[3].font = this.GetTTFFont();
		this.CheckCrystalText[3].text = DataManager.Instance.mStringTable.GetStringByID(188u);
		if (this.IsArabic)
		{
			RectTransform rectTransform = (RectTransform)child.GetChild(4);
			RectTransform rectTransform2 = (RectTransform)child.GetChild(5);
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			rectTransform.anchoredPosition = rectTransform2.anchoredPosition;
			rectTransform2.anchoredPosition = anchoredPosition;
		}
		RectTransform rectTransform3 = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform3.sizeDelta.y + 109f > y)
		{
			float num2 = (y - rectTransform3.sizeDelta.y) * 0.5f;
			if (num2 < 0f)
			{
				num2 = 19f;
			}
			rectTransform3.anchoredPosition = new Vector2(rectTransform3.anchoredPosition.x, -num2);
		}
		child2 = child.GetChild(6);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_CheckCrystalCloseButton = child2.GetComponent<UIButton>();
		this.m_CheckCrystalCloseButton.m_Handler = this;
		this.m_CheckCrystalCloseButton.m_BtnID1 = 23;
		this.m_CheckCrystalCloseButton.m_BtnID2 = 2;
		child2 = child.GetChild(7);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 23;
		component2.m_BtnID2 = 3;
		child2 = child.GetChild(10);
		this.CheckCrystalText[4] = child2.GetComponent<UIText>();
		this.CheckCrystalText[4].font = this.GetTTFFont();
		this.CheckCrystalText[4].text = DataManager.Instance.mStringTable.GetStringByID(967u);
		this.HideArrow(false);
		return true;
	}

	// Token: 0x06000636 RID: 1590 RVA: 0x0008C1D0 File Offset: 0x0008A3D0
	public bool OpenCheckDeleteMsg()
	{
		if (!this.bCheckDeleteMsg)
		{
			return false;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UICheckCryctalBox");
		if (@object == null)
		{
			return false;
		}
		this.m_CheckCrystalBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_CheckCrystalBox.transform.SetParent(this.m_MessageBoxLayer, false);
		CustomImage component = this.m_CheckCrystalBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		Transform child = this.m_CheckCrystalBox.transform.GetChild(0);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(8).GetComponent<CustomImage>();
		component.hander = this;
		this.CheckCrystalImg = child.GetChild(9).GetComponent<CustomImage>();
		this.CheckCrystalImg.hander = this;
		if (this.IsArabic)
		{
			this.CheckCrystalImg.rectTransform.localScale = new Vector3(-this.CheckCrystalImg.rectTransform.localScale.x, this.CheckCrystalImg.rectTransform.localScale.y, this.CheckCrystalImg.rectTransform.localScale.z);
			this.CheckCrystalImg.rectTransform.anchoredPosition += new Vector2(this.CheckCrystalImg.rectTransform.sizeDelta.x, 0f);
		}
		Transform child2 = child.GetChild(2);
		this.CheckCrystalText[0] = child2.GetComponent<UIText>();
		this.CheckCrystalText[0].font = this.GetTTFFont();
		this.CheckCrystalText[0].text = DataManager.Instance.mStringTable.GetStringByID(614u);
		child2 = child.GetChild(3);
		this.CheckCrystalText[1] = child2.GetComponent<UIText>();
		this.CheckCrystalText[1].font = this.GetTTFFont();
		this.CheckCrystalText[1].text = DataManager.Instance.mStringTable.GetStringByID(10072u);
		this.CheckCrystalText[1].SetAllDirty();
		this.CheckCrystalText[1].cachedTextGenerator.Invalidate();
		float num = this.CheckCrystalText[1].preferredHeight - 86.8f;
		if (num > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num);
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num);
		}
		child2 = child.GetChild(4);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		UIButton component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 19;
		component2.m_BtnID2 = 1;
		child2 = child2.GetChild(0);
		this.CheckCrystalText[2] = child2.GetComponent<UIText>();
		this.CheckCrystalText[2].font = this.GetTTFFont();
		this.CheckCrystalText[2].text = DataManager.Instance.mStringTable.GetStringByID(1596u);
		child2 = child.GetChild(5);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 19;
		component2.m_BtnID2 = 2;
		child2 = child2.GetChild(0);
		this.CheckCrystalText[3] = child2.GetComponent<UIText>();
		this.CheckCrystalText[3].font = this.GetTTFFont();
		this.CheckCrystalText[3].text = DataManager.Instance.mStringTable.GetStringByID(3827u);
		if (this.IsArabic)
		{
			RectTransform rectTransform = (RectTransform)child.GetChild(4);
			RectTransform rectTransform2 = (RectTransform)child.GetChild(5);
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			rectTransform.anchoredPosition = rectTransform2.anchoredPosition;
			rectTransform2.anchoredPosition = anchoredPosition;
		}
		RectTransform rectTransform3 = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform3.sizeDelta.y + 109f > y)
		{
			float num2 = (y - rectTransform3.sizeDelta.y) * 0.5f;
			if (num2 < 0f)
			{
				num2 = 19f;
			}
			rectTransform3.anchoredPosition = new Vector2(rectTransform3.anchoredPosition.x, -num2);
		}
		child2 = child.GetChild(6);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_CheckCrystalCloseButton = child2.GetComponent<UIButton>();
		this.m_CheckCrystalCloseButton.m_Handler = this;
		this.m_CheckCrystalCloseButton.m_BtnID1 = 19;
		this.m_CheckCrystalCloseButton.m_BtnID2 = 2;
		child2 = child.GetChild(7);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 19;
		component2.m_BtnID2 = 3;
		child2 = child.GetChild(10);
		this.CheckCrystalText[4] = child2.GetComponent<UIText>();
		this.CheckCrystalText[4].font = this.GetTTFFont();
		this.CheckCrystalText[4].text = DataManager.Instance.mStringTable.GetStringByID(967u);
		this.HideArrow(false);
		return true;
	}

	// Token: 0x06000637 RID: 1591 RVA: 0x0008C75C File Offset: 0x0008A95C
	public bool OpenCheckStoneTrans(CString MessageStr)
	{
		if (!this.bCheckStoneTrans)
		{
			return false;
		}
		UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UICheckCryctalBox");
		if (@object == null)
		{
			return false;
		}
		this.m_CheckCrystalBox = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.m_CheckCrystalBox.transform.SetParent(this.m_MessageBoxLayer, false);
		CustomImage component = this.m_CheckCrystalBox.transform.GetComponent<CustomImage>();
		component.hander = this;
		Transform child = this.m_CheckCrystalBox.transform.GetChild(0);
		component = child.GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = this;
		component = child.GetChild(8).GetComponent<CustomImage>();
		component.hander = this;
		this.CheckCrystalImg = child.GetChild(9).GetComponent<CustomImage>();
		this.CheckCrystalImg.hander = this;
		if (this.IsArabic)
		{
			this.CheckCrystalImg.rectTransform.localScale = new Vector3(-this.CheckCrystalImg.rectTransform.localScale.x, this.CheckCrystalImg.rectTransform.localScale.y, this.CheckCrystalImg.rectTransform.localScale.z);
			this.CheckCrystalImg.rectTransform.anchoredPosition += new Vector2(this.CheckCrystalImg.rectTransform.sizeDelta.x, 0f);
		}
		Transform child2 = child.GetChild(2);
		this.CheckCrystalText[0] = child2.GetComponent<UIText>();
		this.CheckCrystalText[0].font = this.GetTTFFont();
		this.CheckCrystalText[0].text = DataManager.Instance.mStringTable.GetStringByID(614u);
		child2 = child.GetChild(3);
		this.CheckCrystalText[1] = child2.GetComponent<UIText>();
		this.CheckCrystalText[1].font = this.GetTTFFont();
		this.CheckCrystalText[1].text = MessageStr.ToString();
		this.CheckCrystalText[1].SetAllDirty();
		this.CheckCrystalText[1].cachedTextGenerator.Invalidate();
		float num = this.CheckCrystalText[1].preferredHeight - 86.8f;
		if (num > 1f)
		{
			((RectTransform)child).sizeDelta += new Vector2(0f, num);
			((RectTransform)child.GetChild(0)).sizeDelta += new Vector2(0f, num);
			((RectTransform)child2).sizeDelta += new Vector2(0f, num);
		}
		child2 = child.GetChild(4);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		UIButton component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 20;
		component2.m_BtnID2 = 1;
		child2 = child2.GetChild(0);
		this.CheckCrystalText[2] = child2.GetComponent<UIText>();
		this.CheckCrystalText[2].font = this.GetTTFFont();
		this.CheckCrystalText[2].text = DataManager.Instance.mStringTable.GetStringByID(1596u);
		child2 = child.GetChild(5);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 20;
		component2.m_BtnID2 = 2;
		child2 = child2.GetChild(0);
		this.CheckCrystalText[3] = child2.GetComponent<UIText>();
		this.CheckCrystalText[3].font = this.GetTTFFont();
		this.CheckCrystalText[3].text = DataManager.Instance.mStringTable.GetStringByID(3827u);
		if (this.IsArabic)
		{
			RectTransform rectTransform = (RectTransform)child.GetChild(4);
			RectTransform rectTransform2 = (RectTransform)child.GetChild(5);
			Vector2 anchoredPosition = rectTransform.anchoredPosition;
			rectTransform.anchoredPosition = rectTransform2.anchoredPosition;
			rectTransform2.anchoredPosition = anchoredPosition;
		}
		RectTransform rectTransform3 = (RectTransform)child;
		float y = this.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y;
		if (rectTransform3.sizeDelta.y + 109f > y)
		{
			float num2 = (y - rectTransform3.sizeDelta.y) * 0.5f;
			if (num2 < 0f)
			{
				num2 = 19f;
			}
			rectTransform3.anchoredPosition = new Vector2(rectTransform3.anchoredPosition.x, -num2);
		}
		child2 = child.GetChild(6);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		this.m_CheckCrystalCloseButton = child2.GetComponent<UIButton>();
		this.m_CheckCrystalCloseButton.m_Handler = this;
		this.m_CheckCrystalCloseButton.m_BtnID1 = 20;
		this.m_CheckCrystalCloseButton.m_BtnID2 = 2;
		child2 = child.GetChild(7);
		component = child2.GetComponent<CustomImage>();
		component.hander = this;
		component2 = child2.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 20;
		component2.m_BtnID2 = 3;
		child2 = child.GetChild(10);
		this.CheckCrystalText[4] = child2.GetComponent<UIText>();
		this.CheckCrystalText[4].font = this.GetTTFFont();
		this.CheckCrystalText[4].text = DataManager.Instance.mStringTable.GetStringByID(967u);
		this.HideArrow(false);
		return true;
	}

	// Token: 0x06000638 RID: 1592 RVA: 0x0008CCDC File Offset: 0x0008AEDC
	public void CloseCheckCrystalBox()
	{
		if (this.m_CheckCrystalBox == null)
		{
			return;
		}
		UnityEngine.Object.Destroy(this.m_CheckCrystalBox);
		this.m_CheckCrystalBox = null;
		this.m_CheckCrystalCloseButton = null;
		this.m_CheckCrystalButton = null;
		this.CheckCrystalImg = null;
		this.tmpCheckCrystal = 0u;
		StringManager.Instance.DeSpawnString(this.CheckCrystalStr);
		for (int i = 0; i < this.CheckCrystalText.Length; i++)
		{
			this.CheckCrystalText[i] = null;
		}
	}

	// Token: 0x06000639 RID: 1593 RVA: 0x0008CD5C File Offset: 0x0008AF5C
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		if (TextureName == "UI_main")
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door)
			{
				img.sprite = door.LoadSprite(ImageName);
				img.material = door.LoadMaterial();
			}
		}
		else
		{
			img.sprite = this.LoadFrameSprite(ImageName);
			img.material = this.GetFrameMaterial();
		}
	}

	// Token: 0x0600063A RID: 1594 RVA: 0x0008CDCC File Offset: 0x0008AFCC
	public bool ShowUILock(EUILock eLock)
	{
		if (!NetworkManager.Connected() && eLock != EUILock.Network)
		{
			return false;
		}
		if (this.m_LockPanel == null)
		{
			if (this.m_ManagerAssetBundle2 == null)
			{
				this.m_ManagerAssetBundle2 = AssetManager.GetAssetBundle("UI/ManagerAsset2", out this.m_ManagerAssetBundleKey2, false);
			}
			UnityEngine.Object @object = this.m_ManagerAssetBundle2.Load("UILockPanel");
			if (@object == null)
			{
				return false;
			}
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
			gameObject.transform.SetParent(this.m_LockPanelLayer, false);
			this.m_LockPanel = gameObject.GetComponent<RectTransform>();
			gameObject.transform.GetComponent<UIButton>().SoundIndex = byte.MaxValue;
			gameObject.SetActive(false);
		}
		if (eLock == EUILock.Normal)
		{
			this.m_UILockCount += 1;
			this.m_LockPanel.gameObject.SetActive(true);
			if (this.m_eUILock == EUILock.Normal)
			{
				for (int i = 0; i < this.m_LockPanel.childCount; i++)
				{
					this.m_LockPanel.GetChild(i).gameObject.SetActive(false);
				}
			}
		}
		else
		{
			if (eLock != EUILock.All && this.m_eUILock != EUILock.Normal)
			{
				return false;
			}
			this.m_eUILock = eLock;
			this.m_UILockTime = 0f;
			NetworkManager.Freeze(true);
			this.m_LockPanel.gameObject.SetActive(true);
			for (int j = 0; j < this.m_LockPanel.childCount; j++)
			{
				this.m_LockPanel.GetChild(j).gameObject.SetActive(false);
			}
		}
		return true;
	}

	// Token: 0x0600063B RID: 1595 RVA: 0x0008CF68 File Offset: 0x0008B168
	public bool HideUILock(EUILock eLock)
	{
		if (this.m_LockPanel == null)
		{
			return false;
		}
		if (eLock == EUILock.Normal)
		{
			if (this.m_UILockCount == 0)
			{
				return false;
			}
			this.m_UILockCount -= 1;
			if (this.m_UILockCount == 0 && this.m_eUILock == EUILock.Normal)
			{
				this.m_LockPanel.gameObject.SetActive(false);
			}
		}
		else if (eLock == EUILock.All)
		{
			this.m_UILockCount = 0;
			this.m_eUILock = EUILock.Normal;
			NetworkManager.Freeze(false);
			this.m_LockPanel.gameObject.SetActive(false);
			for (int i = 0; i < this.m_LockPanel.childCount; i++)
			{
				this.m_LockPanel.GetChild(i).gameObject.SetActive(false);
			}
		}
		else
		{
			if (eLock != EUILock.All && eLock != EUILock.Network && eLock != this.m_eUILock)
			{
				return false;
			}
			this.m_eUILock = EUILock.Normal;
			NetworkManager.Freeze(false);
			if (this.m_UILockCount == 0)
			{
				this.m_LockPanel.gameObject.SetActive(false);
			}
			else
			{
				for (int j = 0; j < this.m_LockPanel.childCount; j++)
				{
					this.m_LockPanel.GetChild(j).gameObject.SetActive(false);
				}
			}
		}
		return true;
	}

	// Token: 0x0600063C RID: 1596 RVA: 0x0008D0BC File Offset: 0x0008B2BC
	public EUILock GetUILock()
	{
		return this.m_eUILock;
	}

	// Token: 0x0600063D RID: 1597 RVA: 0x0008D0C4 File Offset: 0x0008B2C4
	public void AddHUDMessage(string msg, ushort MsgID = 255, bool bCheckSame = true)
	{
		this.m_HUDMessage.AddMessage(msg, MsgID, bCheckSame);
	}

	// Token: 0x0600063E RID: 1598 RVA: 0x0008D0D4 File Offset: 0x0008B2D4
	public void AddHUDQueue(string msg, ushort MsgID = 255, bool bCheckSame = true)
	{
		this.m_HUDMessage.AddMessageQueqe(msg, MsgID, bCheckSame);
	}

	// Token: 0x0600063F RID: 1599 RVA: 0x0008D0E4 File Offset: 0x0008B2E4
	public bool IsLeadItem(byte EquipKind)
	{
		return EquipKind >= 20 && EquipKind <= 27;
	}

	// Token: 0x06000640 RID: 1600 RVA: 0x0008D0FC File Offset: 0x0008B2FC
	public void SetLayer(GameObject go, int layer)
	{
		go.layer = layer;
		Transform transform = go.transform;
		int i = 0;
		int childCount = transform.childCount;
		while (i < childCount)
		{
			Transform child = transform.GetChild(i);
			this.SetLayer(child.gameObject, layer);
			i++;
		}
	}

	// Token: 0x06000641 RID: 1601 RVA: 0x0008D148 File Offset: 0x0008B348
	public void SetIPhoneX()
	{
		this.bOpenOnIPhoneX = true;
		this.m_WindowsTransform.offsetMin = new Vector2(this.IPhoneX_DeltaX, 0f);
		this.m_WindowsTransform.offsetMax = new Vector2(-this.IPhoneX_DeltaX, 0f);
		this.m_ChatLayer.offsetMin = new Vector2(this.IPhoneX_DeltaX, 0f);
		this.m_ChatLayer.offsetMax = new Vector2(-this.IPhoneX_DeltaX, 0f);
		this.m_TopLayer.offsetMin = new Vector2(this.IPhoneX_DeltaX, 0f);
		this.m_TopLayer.offsetMax = new Vector2(-this.IPhoneX_DeltaX, 0f);
		this.m_MessageBoxLayer.offsetMin = new Vector2(-this.IPhoneX_DeltaX, 0f);
		this.m_MessageBoxLayer.offsetMax = new Vector2(this.IPhoneX_DeltaX, 0f);
		this.m_NewbieLayer.offsetMin = new Vector2(-this.IPhoneX_DeltaX, 0f);
		this.m_NewbieLayer.offsetMax = new Vector2(this.IPhoneX_DeltaX, 0f);
	}

	// Token: 0x06000642 RID: 1602 RVA: 0x0008D270 File Offset: 0x0008B470
	public bool InitianHeroItemImg(Transform BtnT, eHeroOrItem HeroOrItem, ushort HIID, byte Circle = 0, byte Rank = 0, int LvOrNum = 0, bool bShowText = true, bool bAutoShowHint = true, bool bClickSound = true, bool bScaleBtn = false)
	{
		UIHIBtn component = BtnT.GetComponent<UIHIBtn>();
		if (component == null)
		{
			return false;
		}
		Image component2 = BtnT.GetComponent<Image>();
		component2.enabled = true;
		component2.color = new Color(1f, 1f, 1f, 0f);
		component2.sprite = null;
		component2.material = this.m_IconSpriteAsset.GetMaterial();
		component.HeroOrItem = (byte)HeroOrItem;
		component.HIID = HIID;
		if (HeroOrItem == eHeroOrItem.Hero)
		{
			Vector2 anchorMin = new Vector2(0f, 0f);
			Vector2 anchorMax = new Vector2(1f, 1f);
			if (bAutoShowHint)
			{
				BtnT.gameObject.AddComponent<UIButtonHint>();
			}
			GameObject gameObject = new GameObject("HIImg");
			gameObject.layer = 5;
			RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
			anchorMin.Set(0.0703125f, 0.0703125f);
			rectTransform.anchorMin = anchorMin;
			anchorMax.Set(0.9296875f, 0.9296875f);
			rectTransform.anchorMax = anchorMax;
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
			gameObject.AddComponent<IgnoreRaycast>();
			component.HIImage = gameObject.AddComponent<Image>();
			gameObject.transform.SetParent(BtnT, false);
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(HIID);
			component.HIImage.sprite = this.m_IconSpriteAsset.LoadSprite(recordByKey.Graph);
			component.HIImage.material = this.m_IconSpriteAsset.GetMaterial();
			if (component.HIImage.sprite == null)
			{
				component.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite(1130);
				component.HIImage.material = this.m_ItemIconSpriteAsset.GetMaterial();
			}
			component.targetGraphic = component.HIImage;
			component2.sprite = component.HIImage.sprite;
			if (bShowText)
			{
				gameObject = new GameObject("TextImg");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				anchorMin.Set(0.4218f, 0.078125f);
				rectTransform.anchorMin = anchorMin;
				anchorMax.Set(0.93f, 0.31f);
				rectTransform.anchorMax = anchorMax;
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				component.TextImage = gameObject.AddComponent<Image>();
				component.TextImage.sprite = this.LoadFrameSprite("UI_black_top");
				component.TextImage.material = this.GetFrameMaterial();
				Color color = component.TextImage.color;
				color.a = 0.67f;
				component.TextImage.color = color;
				gameObject.transform.SetParent(BtnT, false);
				if (LvOrNum != 0)
				{
					gameObject.SetActive(true);
				}
				else
				{
					gameObject.SetActive(false);
				}
			}
			gameObject = new GameObject("CircleImg");
			gameObject.layer = 5;
			rectTransform = gameObject.AddComponent<RectTransform>();
			anchorMin.Set(0f, 0f);
			rectTransform.anchorMin = anchorMin;
			anchorMax.Set(1f, 1f);
			rectTransform.anchorMax = anchorMax;
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
			gameObject.AddComponent<IgnoreRaycast>();
			component.CircleImage = gameObject.AddComponent<Image>();
			gameObject.transform.SetParent(BtnT, false);
			component.CircleImage.material = this.GetFrameMaterial();
			if (Circle != 0)
			{
				component.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Hero, Circle);
				gameObject.SetActive(true);
			}
			else
			{
				gameObject.SetActive(false);
			}
			gameObject = new GameObject("HeroRankImg");
			gameObject.layer = 5;
			rectTransform = gameObject.AddComponent<RectTransform>();
			anchorMin.Set(-0.06f, 0f);
			rectTransform.anchorMin = anchorMin;
			anchorMax.Set(0.368125f, 0.428125f);
			rectTransform.anchorMax = anchorMax;
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
			gameObject.AddComponent<IgnoreRaycast>();
			component.HeroRankImage = gameObject.AddComponent<Image>();
			gameObject.transform.SetParent(BtnT, false);
			component.HeroRankImage.material = this.GetFrameMaterial();
			if (Rank != 0)
			{
				component.HeroRankImage.sprite = this.LoadFrameSprite(EFrameSprite.Hero, Rank + 100);
				gameObject.SetActive(true);
			}
			else
			{
				gameObject.SetActive(false);
			}
			if (bShowText)
			{
				gameObject = new GameObject("LvOrNumText");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				anchorMin.Set(0.5f, 0.069f);
				rectTransform.anchorMin = anchorMin;
				anchorMax.Set(0.9f, 0.328f);
				rectTransform.anchorMax = anchorMax;
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				component.LvOrNum = gameObject.AddComponent<UIText>();
				gameObject.AddComponent<Outline>().effectColor = new Color(0f, 0f, 0f, 1f);
				gameObject.transform.SetParent(BtnT, false);
				component.LvOrNum.alignment = TextAnchor.MiddleRight;
				component.LvOrNum.supportRichText = true;
				component.LvOrNum.resizeTextForBestFit = true;
				component.LvOrNum.font = this.m_TTFFont;
				if (LvOrNum != 0)
				{
					component.LvOrNum.text = LvOrNum.ToString();
					gameObject.SetActive(true);
				}
				else
				{
					gameObject.SetActive(false);
				}
			}
		}
		else if (HeroOrItem == eHeroOrItem.Pet)
		{
			Vector2 anchorMin2 = new Vector2(0f, 0f);
			Vector2 anchorMax2 = new Vector2(1f, 1f);
			if (bAutoShowHint)
			{
				BtnT.gameObject.AddComponent<UIButtonHint>();
			}
			GameObject gameObject2 = new GameObject("HIImg");
			gameObject2.layer = 5;
			RectTransform rectTransform2 = gameObject2.AddComponent<RectTransform>();
			anchorMin2.Set(0.0703125f, 0.0703125f);
			rectTransform2.anchorMin = anchorMin2;
			anchorMax2.Set(0.9296875f, 0.9296875f);
			rectTransform2.anchorMax = anchorMax2;
			rectTransform2.offsetMin = Vector2.zero;
			rectTransform2.offsetMax = Vector2.zero;
			gameObject2.AddComponent<IgnoreRaycast>();
			component.HIImage = gameObject2.AddComponent<Image>();
			gameObject2.transform.SetParent(BtnT, false);
			PetTbl recordByKey2 = PetManager.Instance.PetTable.GetRecordByKey(HIID);
			Hero recordByKey3 = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey2.HeroID);
			component.HIImage.sprite = this.m_IconSpriteAsset.LoadSprite(recordByKey3.Graph);
			component.HIImage.material = this.m_IconSpriteAsset.GetMaterial();
			if (component.HIImage.sprite == null)
			{
				component.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite(1130);
				component.HIImage.material = this.m_ItemIconSpriteAsset.GetMaterial();
			}
			component.targetGraphic = component.HIImage;
			component2.sprite = component.HIImage.sprite;
			if (bShowText)
			{
				gameObject2 = new GameObject("TextImg");
				gameObject2.layer = 5;
				rectTransform2 = gameObject2.AddComponent<RectTransform>();
				anchorMin2.Set(0.4218f, 0.078125f);
				rectTransform2.anchorMin = anchorMin2;
				anchorMax2.Set(0.93f, 0.31f);
				rectTransform2.anchorMax = anchorMax2;
				rectTransform2.offsetMin = Vector2.zero;
				rectTransform2.offsetMax = Vector2.zero;
				gameObject2.AddComponent<IgnoreRaycast>();
				component.TextImage = gameObject2.AddComponent<Image>();
				component.TextImage.sprite = this.LoadFrameSprite("UI_black_top");
				component.TextImage.material = this.GetFrameMaterial();
				Color color2 = component.TextImage.color;
				color2.a = 0.67f;
				component.TextImage.color = color2;
				gameObject2.transform.SetParent(BtnT, false);
				if (LvOrNum != 0)
				{
					gameObject2.SetActive(true);
				}
				else
				{
					gameObject2.SetActive(false);
				}
			}
			gameObject2 = new GameObject("CircleImg");
			gameObject2.layer = 5;
			rectTransform2 = gameObject2.AddComponent<RectTransform>();
			anchorMin2.Set(0f, 0f);
			rectTransform2.anchorMin = anchorMin2;
			anchorMax2.Set(1f, 1f);
			rectTransform2.anchorMax = anchorMax2;
			rectTransform2.offsetMin = Vector2.zero;
			rectTransform2.offsetMax = Vector2.zero;
			gameObject2.AddComponent<IgnoreRaycast>();
			component.CircleImage = gameObject2.AddComponent<Image>();
			gameObject2.transform.SetParent(BtnT, false);
			component.CircleImage.material = this.GetFrameMaterial();
			if (HIID == 0)
			{
				component.CircleImage.sprite = this.LoadFrameSprite("hf000_b");
			}
			else
			{
				component.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Pet, Circle);
			}
			gameObject2.SetActive(true);
			float num = component.GetComponent<RectTransform>().rect.width / component.CircleImage.sprite.rect.width;
			gameObject2 = new GameObject("PetRareImg");
			gameObject2.layer = 5;
			rectTransform2 = gameObject2.AddComponent<RectTransform>();
			anchorMin2.Set(0.5f, 0.5f);
			rectTransform2.anchorMin = anchorMin2;
			anchorMax2.Set(0.5f, 0.5f);
			rectTransform2.anchorMax = anchorMax2;
			rectTransform2.offsetMin = Vector2.zero;
			rectTransform2.offsetMax = Vector2.zero;
			rectTransform2.anchoredPosition = new Vector2(-49f * num, -35f * num);
			rectTransform2.localScale = new Vector3(num * 0.9f, num * 0.9f, num * 0.9f);
			gameObject2.AddComponent<IgnoreRaycast>();
			component.HeroRankImage = gameObject2.AddComponent<Image>();
			gameObject2.transform.SetParent(BtnT, false);
			component.HeroRankImage.material = this.GetFrameMaterial();
			component.HeroRankImage.sprite = this.LoadFrameSprite("UI_mp_rarity");
			component.HeroRankImage.SetNativeSize();
			gameObject2 = new GameObject("PetRareText", new Type[]
			{
				typeof(UIText)
			});
			gameObject2.AddComponent<Outline>();
			gameObject2.AddComponent<Shadow>();
			component.PetRareText = gameObject2.transform.GetComponent<UIText>();
			component.PetRareText.font = this.GetTTFFont();
			gameObject2.transform.SetParent(rectTransform2, false);
			rectTransform2 = component.PetRareText.rectTransform;
			RectTransform rectTransform3 = rectTransform2;
			Vector2 vector = new Vector2(0.5f, 0.5f);
			rectTransform2.pivot = vector;
			vector = vector;
			rectTransform2.anchorMin = vector;
			rectTransform3.anchorMax = vector;
			rectTransform2.sizeDelta = new Vector2(48f, 58f);
			rectTransform2.anchoredPosition = Vector2.zero;
			component.PetRareText.supportRichText = false;
			component.PetRareText.resizeTextForBestFit = false;
			component.PetRareText.fontSize = 18;
			component.PetRareText.alignment = TextAnchor.MiddleCenter;
			if (Rank != 0)
			{
				component.HeroRankImage.gameObject.SetActive(true);
				component.SetPetRare(Rank);
			}
			else
			{
				component.HeroRankImage.gameObject.SetActive(false);
			}
			if (bShowText)
			{
				gameObject2 = new GameObject("LvOrNumText");
				gameObject2.layer = 5;
				rectTransform2 = gameObject2.AddComponent<RectTransform>();
				anchorMin2.Set(0.5f, 0.069f);
				rectTransform2.anchorMin = anchorMin2;
				anchorMax2.Set(0.9f, 0.328f);
				rectTransform2.anchorMax = anchorMax2;
				rectTransform2.offsetMin = Vector2.zero;
				rectTransform2.offsetMax = Vector2.zero;
				gameObject2.AddComponent<IgnoreRaycast>();
				component.LvOrNum = gameObject2.AddComponent<UIText>();
				gameObject2.AddComponent<Outline>().effectColor = new Color(0f, 0f, 0f, 1f);
				gameObject2.transform.SetParent(BtnT, false);
				component.LvOrNum.alignment = TextAnchor.MiddleRight;
				component.LvOrNum.supportRichText = true;
				component.LvOrNum.resizeTextForBestFit = true;
				component.LvOrNum.font = this.m_TTFFont;
				if (LvOrNum != 0)
				{
					component.LvOrNum.text = LvOrNum.ToString();
					gameObject2.SetActive(true);
				}
				else
				{
					gameObject2.SetActive(false);
				}
			}
		}
		else
		{
			if (HeroOrItem != eHeroOrItem.Item)
			{
				return false;
			}
			this.SetItemScaleClickSound(component, bScaleBtn, bClickSound);
			Vector2 anchorMin3 = new Vector2(0f, 0f);
			Vector2 anchorMax3 = new Vector2(1f, 1f);
			if (bAutoShowHint)
			{
				BtnT.gameObject.AddComponent<UIButtonHint>();
			}
			Equip recordByKey4 = DataManager.Instance.EquipTable.GetRecordByKey(HIID);
			GameObject gameObject3 = new GameObject("HIImg");
			gameObject3.layer = 5;
			RectTransform rectTransform4 = gameObject3.AddComponent<RectTransform>();
			byte b = recordByKey4.EquipKind;
			b -= 1;
			if (b == 2 || (b == 3 && recordByKey4.SyntheticParts[1].SyntheticItemNum == 1))
			{
				anchorMin3.Set(0.25f, 0.3f);
				anchorMax3.Set(0.7625f, 0.8125f);
			}
			else if (b == 4 || b == 28 || (b == 9 && recordByKey4.PropertiesInfo[0].Propertieskey == 45))
			{
				anchorMin3.Set(0.0625f, 0.1125f);
				anchorMax3.Set(0.9375f, 0.9875f);
			}
			else
			{
				anchorMin3.Set(0.0625f, 0.0625f);
				anchorMax3.Set(0.9375f, 0.9375f);
			}
			rectTransform4.anchorMin = anchorMin3;
			rectTransform4.anchorMax = anchorMax3;
			rectTransform4.offsetMin = Vector2.zero;
			rectTransform4.offsetMax = Vector2.zero;
			gameObject3.AddComponent<IgnoreRaycast>();
			component.HIImage = gameObject3.AddComponent<Image>();
			gameObject3.transform.SetParent(BtnT, false);
			if (b == 4 || b == 28 || b == 29 || (b == 9 && recordByKey4.PropertiesInfo[0].Propertieskey == 45))
			{
				component.HIImage.sprite = this.m_IconSpriteAsset.LoadSprite(recordByKey4.EquipPicture);
				component.HIImage.material = this.m_IconSpriteAsset.GetMaterial();
			}
			else
			{
				component.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite(recordByKey4.EquipPicture);
				component.HIImage.material = this.m_ItemIconSpriteAsset.GetMaterial();
			}
			if (component.HIImage.sprite == null)
			{
				component.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite(1130);
				component.HIImage.material = this.m_ItemIconSpriteAsset.GetMaterial();
			}
			component.targetGraphic = component.HIImage;
			component2.sprite = component.HIImage.sprite;
			component2.material = this.m_ItemIconSpriteAsset.GetMaterial();
			if (this.IsArabic)
			{
				if (b == 4 || b == 29 || (b == 9 && recordByKey4.PropertiesInfo[0].Propertieskey == 45))
				{
					component.HIImage.rectTransform.localScale = new Vector3(1f, 1f, 1f);
				}
				else if (b == 28)
				{
					rectTransform4.localScale = new Vector3(0.9f, 0.9f, 0.9f);
				}
				else
				{
					component.HIImage.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
				}
			}
			else if (b == 28)
			{
				rectTransform4.localScale = new Vector3(0.9f, 0.9f, 0.9f);
			}
			else
			{
				rectTransform4.localScale = Vector3.one;
			}
			gameObject3 = new GameObject("CircleImg");
			gameObject3.layer = 5;
			rectTransform4 = gameObject3.AddComponent<RectTransform>();
			anchorMin3.Set(0f, 0f);
			rectTransform4.anchorMin = anchorMin3;
			anchorMax3.Set(1f, 1f);
			rectTransform4.anchorMax = anchorMax3;
			rectTransform4.offsetMin = Vector2.zero;
			rectTransform4.offsetMax = Vector2.zero;
			gameObject3.AddComponent<IgnoreRaycast>();
			component.CircleImage = gameObject3.AddComponent<Image>();
			gameObject3.transform.SetParent(BtnT, false);
			component.CircleImage.material = this.GetFrameMaterial();
			if (recordByKey4.Color != 0)
			{
				if (b == 4)
				{
					component.CircleImage.sprite = this.LoadFrameSprite("if102");
				}
				else if (b == 28)
				{
					component.CircleImage.sprite = this.LoadFrameSprite("if201");
				}
				else if (b == 9 && recordByKey4.PropertiesInfo[0].Propertieskey == 45)
				{
					component.CircleImage.sprite = this.LoadFrameSprite("if202");
				}
				else if (b == 29)
				{
					component.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Pet, Circle);
				}
				else
				{
					component.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Item, recordByKey4.Color);
				}
				gameObject3.SetActive(true);
			}
			else
			{
				gameObject3.SetActive(false);
			}
			gameObject3 = new GameObject("ChipBookImg2");
			gameObject3.layer = 5;
			rectTransform4 = gameObject3.AddComponent<RectTransform>();
			anchorMin3.Set(0f, 0f);
			rectTransform4.anchorMin = anchorMin3;
			anchorMax3.Set(1f, 1f);
			rectTransform4.anchorMax = anchorMax3;
			rectTransform4.offsetMin = Vector2.zero;
			rectTransform4.offsetMax = Vector2.zero;
			gameObject3.AddComponent<IgnoreRaycast>();
			component.ChipBookImage = gameObject3.AddComponent<Image>();
			gameObject3.transform.SetParent(BtnT, false);
			component.ChipBookImage.material = this.GetFrameMaterial();
			if (b == 3)
			{
				if (recordByKey4.SyntheticParts[1].SyntheticItemNum == 1)
				{
					component.ChipBookImage.sprite = this.LoadFrameSprite("gf002");
				}
				else
				{
					component.ChipBookImage.sprite = this.LoadFrameSprite("gf001");
				}
				gameObject3.SetActive(true);
			}
			else if (b == 2)
			{
				component.ChipBookImage.sprite = this.LoadFrameSprite("if101");
				gameObject3.SetActive(true);
			}
			else
			{
				gameObject3.SetActive(false);
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool specialNumText = this.GetSpecialNumText(stringBuilder, HIID);
			gameObject3 = new GameObject("TextImg");
			gameObject3.layer = 5;
			rectTransform4 = gameObject3.AddComponent<RectTransform>();
			rectTransform4.offsetMin = Vector2.zero;
			rectTransform4.offsetMax = Vector2.zero;
			gameObject3.AddComponent<IgnoreRaycast>();
			component.TextImage = gameObject3.AddComponent<Image>();
			component.TextImage.sprite = this.LoadFrameSprite("UI_black_top");
			component.TextImage.material = this.GetFrameMaterial();
			Color color3 = component.TextImage.color;
			color3.a = 0.67f;
			component.TextImage.color = color3;
			if (specialNumText)
			{
				anchorMin3.Set(-0.1f, 0.06f);
				rectTransform4.anchorMin = anchorMin3;
				anchorMax3.Set(0.93f, 0.4f);
				rectTransform4.anchorMax = anchorMax3;
				gameObject3.SetActive(true);
			}
			else
			{
				anchorMin3.Set(0.4218f, 0.078125f);
				rectTransform4.anchorMin = anchorMin3;
				anchorMax3.Set(0.9f, 0.31f);
				rectTransform4.anchorMax = anchorMax3;
				if (LvOrNum != 0 && b != 4)
				{
					gameObject3.SetActive(true);
				}
				else
				{
					gameObject3.SetActive(false);
				}
			}
			gameObject3.transform.SetParent(BtnT, false);
			gameObject3 = new GameObject("LvOrNumText");
			gameObject3.layer = 5;
			rectTransform4 = gameObject3.AddComponent<RectTransform>();
			rectTransform4.offsetMin = Vector2.zero;
			rectTransform4.offsetMax = Vector2.zero;
			gameObject3.AddComponent<IgnoreRaycast>();
			component.LvOrNum = gameObject3.AddComponent<UIText>();
			gameObject3.AddComponent<Outline>().effectColor = new Color(0f, 0f, 0f, 1f);
			if (specialNumText)
			{
				component.LvOrNum.alignment = TextAnchor.LowerCenter;
			}
			else
			{
				component.LvOrNum.alignment = TextAnchor.MiddleRight;
			}
			component.LvOrNum.supportRichText = true;
			component.LvOrNum.resizeTextForBestFit = true;
			component.LvOrNum.font = this.m_TTFFont;
			if (specialNumText)
			{
				anchorMin3.Set(0.1f, 0.03f);
				rectTransform4.anchorMin = anchorMin3;
				anchorMax3.Set(0.9f, 0.4f);
				rectTransform4.anchorMax = anchorMax3;
				component.LvOrNum.text = stringBuilder.ToString();
				gameObject3.SetActive(true);
			}
			else
			{
				anchorMin3.Set(0.1f, 0.076f);
				rectTransform4.anchorMin = anchorMin3;
				anchorMax3.Set(0.9f, 0.335f);
				rectTransform4.anchorMax = anchorMax3;
				if (LvOrNum != 0)
				{
					component.LvOrNum.text = LvOrNum.ToString();
					gameObject3.SetActive(true);
				}
				else
				{
					gameObject3.SetActive(false);
				}
			}
			gameObject3.transform.SetParent(BtnT, false);
		}
		return true;
	}

	// Token: 0x06000643 RID: 1603 RVA: 0x0008E814 File Offset: 0x0008CA14
	public void ChangeHeroItemImg(Transform BtnT, eHeroOrItem HeroOrItem, ushort HIID, byte Circle = 0, byte Rank = 0, int LvOrNum = 0)
	{
		UIHIBtn component = BtnT.GetComponent<UIHIBtn>();
		if (component == null)
		{
			return;
		}
		component.HeroOrItem = (byte)HeroOrItem;
		component.HIID = HIID;
		if (HeroOrItem == eHeroOrItem.Hero)
		{
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(HIID);
			component.HIImage.sprite = this.m_IconSpriteAsset.LoadSprite(recordByKey.Graph);
			component.HIImage.material = this.m_IconSpriteAsset.GetMaterial();
			if (component.HIImage.sprite == null)
			{
				component.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite(1130);
				component.HIImage.material = this.m_ItemIconSpriteAsset.GetMaterial();
			}
			component.targetGraphic = component.HIImage;
			if (Circle != 0)
			{
				component.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Hero, Circle);
				if (!component.CircleImage.gameObject.activeInHierarchy)
				{
					component.CircleImage.gameObject.SetActive(true);
				}
			}
			else
			{
				component.CircleImage.gameObject.SetActive(false);
			}
			if (Rank != 0)
			{
				component.HeroRankImage.sprite = this.LoadFrameSprite(EFrameSprite.Hero, Rank + 100);
				component.HeroRankImage.material = this.GetFrameMaterial();
				if (!component.HeroRankImage.gameObject.activeInHierarchy)
				{
					component.HeroRankImage.gameObject.SetActive(true);
				}
			}
			else
			{
				component.HeroRankImage.gameObject.SetActive(false);
			}
			if (component.LvOrNum != null)
			{
				if (LvOrNum != 0)
				{
					component.LvOrNum.text = LvOrNum.ToString();
					if (!component.TextImage.gameObject.activeInHierarchy)
					{
						component.TextImage.gameObject.SetActive(true);
					}
					if (!component.LvOrNum.gameObject.activeInHierarchy)
					{
						component.LvOrNum.gameObject.SetActive(true);
					}
				}
				else
				{
					component.LvOrNum.gameObject.SetActive(false);
					component.TextImage.gameObject.SetActive(false);
				}
			}
		}
		else if (HeroOrItem == eHeroOrItem.Pet)
		{
			PetTbl recordByKey2 = PetManager.Instance.PetTable.GetRecordByKey(HIID);
			Hero recordByKey3 = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey2.HeroID);
			component.HIImage.sprite = this.m_IconSpriteAsset.LoadSprite(recordByKey3.Graph);
			component.HIImage.material = this.m_IconSpriteAsset.GetMaterial();
			if (component.HIImage.sprite == null)
			{
				component.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite(1130);
				component.HIImage.material = this.m_ItemIconSpriteAsset.GetMaterial();
			}
			component.targetGraphic = component.HIImage;
			if (HIID == 0)
			{
				component.CircleImage.sprite = this.LoadFrameSprite("hf000_b");
			}
			else
			{
				component.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Pet, Circle);
			}
			if (!component.CircleImage.gameObject.activeInHierarchy)
			{
				component.CircleImage.gameObject.SetActive(true);
			}
			if (component.LvOrNum != null)
			{
				if (LvOrNum != 0)
				{
					component.LvOrNum.text = LvOrNum.ToString();
					if (!component.TextImage.gameObject.activeInHierarchy)
					{
						component.TextImage.gameObject.SetActive(true);
					}
					if (!component.LvOrNum.gameObject.activeInHierarchy)
					{
						component.LvOrNum.gameObject.SetActive(true);
					}
				}
				else
				{
					component.LvOrNum.gameObject.SetActive(false);
					component.TextImage.gameObject.SetActive(false);
				}
			}
			if (Rank != 0)
			{
				component.HeroRankImage.gameObject.SetActive(true);
				if (component.PetRareText == null)
				{
					component.PetRareText = component.HeroRankImage.transform.GetChild(0).GetComponent<UIText>();
				}
				component.SetPetRare(Rank);
			}
			else
			{
				component.HeroRankImage.gameObject.SetActive(false);
			}
		}
		else if (HeroOrItem == eHeroOrItem.Item)
		{
			Equip recordByKey4 = DataManager.Instance.EquipTable.GetRecordByKey(HIID);
			Vector2 anchorMin = new Vector2(0f, 0f);
			Vector2 anchorMax = new Vector2(1f, 1f);
			byte b = recordByKey4.EquipKind;
			b -= 1;
			if (b == 4 || b == 28 || b == 29 || (b == 9 && recordByKey4.PropertiesInfo[0].Propertieskey == 45))
			{
				component.HIImage.sprite = this.m_IconSpriteAsset.LoadSprite(recordByKey4.EquipPicture);
				component.HIImage.material = this.m_IconSpriteAsset.GetMaterial();
			}
			else
			{
				component.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite(recordByKey4.EquipPicture);
				component.HIImage.material = this.m_ItemIconSpriteAsset.GetMaterial();
			}
			if (component.HIImage.sprite == null)
			{
				component.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite(1130);
				component.HIImage.material = this.m_ItemIconSpriteAsset.GetMaterial();
			}
			component.targetGraphic = component.HIImage;
			if (this.IsArabic)
			{
				if (b == 4 || b == 29 || (b == 9 && recordByKey4.PropertiesInfo[0].Propertieskey == 45))
				{
					component.HIImage.rectTransform.localScale = new Vector3(1f, 1f, 1f);
				}
				else if (b == 28)
				{
					component.HIImage.rectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
				}
				else
				{
					component.HIImage.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
				}
			}
			else if (b == 28)
			{
				component.HIImage.rectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
			}
			else
			{
				component.HIImage.rectTransform.localScale = Vector3.one;
			}
			RectTransform rectTransform = component.HIImage.rectTransform;
			if (b == 2 || (b == 3 && recordByKey4.SyntheticParts[1].SyntheticItemNum == 1))
			{
				anchorMin.Set(0.25f, 0.3f);
				anchorMax.Set(0.7625f, 0.8125f);
			}
			else if (b == 4 || b == 28 || (b == 9 && recordByKey4.PropertiesInfo[0].Propertieskey == 45))
			{
				anchorMin.Set(0.0625f, 0.1125f);
				anchorMax.Set(0.9375f, 0.9875f);
			}
			else
			{
				anchorMin.Set(0.0625f, 0.0625f);
				anchorMax.Set(0.9375f, 0.9375f);
			}
			rectTransform.anchorMin = anchorMin;
			rectTransform.anchorMax = anchorMax;
			if (b == 2)
			{
				component.ChipBookImage.sprite = this.LoadFrameSprite("if101");
				component.ChipBookImage.material = this.GetFrameMaterial();
				if (!component.ChipBookImage.gameObject.activeInHierarchy)
				{
					component.ChipBookImage.gameObject.SetActive(true);
				}
			}
			else if (b == 3)
			{
				if (recordByKey4.SyntheticParts[1].SyntheticItemNum == 1)
				{
					component.ChipBookImage.sprite = this.LoadFrameSprite("gf002");
				}
				else
				{
					component.ChipBookImage.sprite = this.LoadFrameSprite("gf001");
				}
				component.ChipBookImage.material = this.GetFrameMaterial();
				if (!component.ChipBookImage.gameObject.activeInHierarchy)
				{
					component.ChipBookImage.gameObject.SetActive(true);
				}
			}
			else
			{
				component.ChipBookImage.gameObject.SetActive(false);
			}
			if (recordByKey4.Color != 0)
			{
				if (b == 4)
				{
					component.CircleImage.sprite = this.LoadFrameSprite("if102");
				}
				else if (b == 28)
				{
					component.CircleImage.sprite = this.LoadFrameSprite("if201");
				}
				else if (b == 9 && recordByKey4.PropertiesInfo[0].Propertieskey == 45)
				{
					component.CircleImage.sprite = this.LoadFrameSprite("if202");
				}
				else if (b == 29)
				{
					component.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Pet, Circle);
				}
				else
				{
					component.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Item, recordByKey4.Color);
				}
				if (!component.CircleImage.gameObject.activeInHierarchy)
				{
					component.CircleImage.gameObject.SetActive(true);
				}
			}
			else
			{
				component.CircleImage.gameObject.SetActive(false);
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool specialNumText = this.GetSpecialNumText(stringBuilder, HIID);
			if (specialNumText)
			{
				if (component.TextImage != null)
				{
					rectTransform = component.TextImage.rectTransform;
					anchorMin.Set(-0.1f, 0.06f);
					rectTransform.anchorMin = anchorMin;
					anchorMax.Set(0.93f, 0.4f);
					rectTransform.anchorMax = anchorMax;
				}
				if (component.LvOrNum != null)
				{
					rectTransform = component.LvOrNum.rectTransform;
					anchorMin.Set(0.1f, 0.03f);
					rectTransform.anchorMin = anchorMin;
					anchorMax.Set(0.9f, 0.4f);
					rectTransform.anchorMax = anchorMax;
					component.LvOrNum.text = stringBuilder.ToString();
				}
				component.LvOrNum.alignment = TextAnchor.LowerCenter;
				if (!component.TextImage.gameObject.activeInHierarchy)
				{
					component.TextImage.gameObject.SetActive(true);
				}
				if (!component.LvOrNum.gameObject.activeInHierarchy)
				{
					component.LvOrNum.gameObject.SetActive(true);
				}
			}
			else
			{
				if (component.TextImage != null)
				{
					rectTransform = component.TextImage.rectTransform;
					anchorMin.Set(0.4218f, 0.078125f);
					rectTransform.anchorMin = anchorMin;
					anchorMax.Set(0.9f, 0.31f);
					rectTransform.anchorMax = anchorMax;
				}
				if (component.LvOrNum != null)
				{
					rectTransform = component.LvOrNum.rectTransform;
					anchorMin.Set(0.1f, 0.076f);
					rectTransform.anchorMin = anchorMin;
					anchorMax.Set(0.9f, 0.335f);
					rectTransform.anchorMax = anchorMax;
					if (LvOrNum != 0)
					{
						component.LvOrNum.alignment = TextAnchor.MiddleRight;
						component.LvOrNum.text = LvOrNum.ToString("N0");
						if (!component.TextImage.gameObject.activeInHierarchy && recordByKey4.EquipKind != 5)
						{
							component.TextImage.gameObject.SetActive(true);
						}
						if (!component.LvOrNum.gameObject.activeInHierarchy)
						{
							component.LvOrNum.gameObject.SetActive(true);
						}
					}
					else
					{
						component.LvOrNum.gameObject.SetActive(false);
						component.TextImage.gameObject.SetActive(false);
					}
				}
			}
		}
	}

	// Token: 0x06000644 RID: 1604 RVA: 0x0008F410 File Offset: 0x0008D610
	public void ChangeWonderImg(Transform BtnT, byte WonderID, ushort KingdomID = 0)
	{
		UIHIBtn component = BtnT.GetComponent<UIHIBtn>();
		if (component == null)
		{
			return;
		}
		component.HeroOrItem = 2;
		component.HIID = (ushort)WonderID;
		component.HIImage.sprite = this.GetWonderSprite(WonderID, KingdomID, 0);
		component.HIImage.material = this._m_WonderMaterial;
		component.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Hero, 11);
		component.HeroRankImage.gameObject.SetActive(false);
	}

	// Token: 0x06000645 RID: 1605 RVA: 0x0008F48C File Offset: 0x0008D68C
	public void ChangeNPCImg(Transform BtnT)
	{
		UIHIBtn component = BtnT.GetComponent<UIHIBtn>();
		if (component == null)
		{
			return;
		}
		component.HeroOrItem = 3;
		component.HIImage.sprite = this.NpcHead;
		component.HIImage.material = this._m_WonderMaterial;
		component.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Hero, 11);
		component.HeroRankImage.gameObject.SetActive(false);
	}

	// Token: 0x06000646 RID: 1606 RVA: 0x0008F4FC File Offset: 0x0008D6FC
	public bool GetSpecialNumText(StringBuilder sb, ushort ItemID)
	{
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(ItemID);
		bool result = false;
		byte b = recordByKey.EquipKind;
		b -= 1;
		if ((b == 10 && recordByKey.PropertiesInfo[0].Propertieskey <= 8) || (b == 9 && recordByKey.PropertiesInfo[0].Propertieskey == 30) || (b == 9 && recordByKey.PropertiesInfo[0].Propertieskey == 33) || (b == 9 && recordByKey.PropertiesInfo[0].Propertieskey == 40) || (b == 9 && recordByKey.PropertiesInfo[0].Propertieskey == 49))
		{
			result = true;
			uint value = (uint)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue);
			GameConstants.FormatResourceValue(sb, value);
		}
		else if (b == 12 && recordByKey.PropertiesInfo[0].Propertieskey == 1)
		{
			result = true;
			GameConstants.FormatResourceValue(sb, (uint)recordByKey.PropertiesInfo[1].Propertieskey);
		}
		else if ((b == 11 && recordByKey.PropertiesInfo[0].Propertieskey == 1) || (b == 11 && recordByKey.PropertiesInfo[0].Propertieskey == 12) || (b == 11 && recordByKey.PropertiesInfo[0].Propertieskey == 17) || (b == 11 && recordByKey.PropertiesInfo[0].Propertieskey == 18) || (b == 11 && recordByKey.PropertiesInfo[0].Propertieskey == 21) || (b == 11 && recordByKey.PropertiesInfo[0].Propertieskey == 22) || (b == 13 && recordByKey.PropertiesInfo[0].Propertieskey <= 2))
		{
			result = true;
			ushort propertieskey = recordByKey.PropertiesInfo[1].Propertieskey;
			if (propertieskey <= 60)
			{
				sb.AppendFormat("{0}m", propertieskey);
			}
			else if (propertieskey > 60 && propertieskey <= 1440)
			{
				sb.AppendFormat("{0}h", propertieskey / 60);
			}
			else if (propertieskey > 1440)
			{
				sb.AppendFormat("{0}d", propertieskey / 60 / 24);
			}
		}
		return result;
	}

	// Token: 0x06000647 RID: 1607 RVA: 0x0008F7B4 File Offset: 0x0008D9B4
	public void SetItemScaleClickSound(UIHIBtn tmpHI, bool bEnableScasle, bool bEnableSound)
	{
		if (tmpHI == null)
		{
			return;
		}
		uButtonScale uButtonScale = tmpHI.gameObject.GetComponent<uButtonScale>();
		if (uButtonScale == null)
		{
			uButtonScale = tmpHI.gameObject.AddComponent<uButtonScale>();
		}
		uButtonScale.m_Handler = tmpHI;
		uButtonScale.enabled = bEnableScasle;
		if (bEnableScasle)
		{
			tmpHI.SetEffectType(e_EffectType.e_Scale);
		}
		else
		{
			tmpHI.SetEffectType(e_EffectType.e_Normal);
		}
		GameConstants.SetPivot((RectTransform)tmpHI.transform, new Vector2(0.5f, 0.5f));
		if (bEnableSound)
		{
			tmpHI.SoundIndex = 0;
		}
		else
		{
			tmpHI.SoundIndex = byte.MaxValue;
		}
	}

	// Token: 0x06000648 RID: 1608 RVA: 0x0008F858 File Offset: 0x0008DA58
	public void GetABColor()
	{
		this.MyColor = RenderSettings.ambientLight;
	}

	// Token: 0x06000649 RID: 1609 RVA: 0x0008F868 File Offset: 0x0008DA68
	public void OpenABColor()
	{
		RenderSettings.ambientLight = this.ABColor;
	}

	// Token: 0x0600064A RID: 1610 RVA: 0x0008F878 File Offset: 0x0008DA78
	public void CloseABColor()
	{
		this.ABColor = RenderSettings.ambientLight;
		RenderSettings.ambientLight = this.MyColor;
	}

	// Token: 0x0600064B RID: 1611 RVA: 0x0008F890 File Offset: 0x0008DA90
	public void Recv_QuickBattle(MessagePacket MP)
	{
		DataManager dataManager = DataManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			return;
		}
		this.UIQueueLock(EGUIQueueLock.UIQL_BattleReport);
		dataManager.KingOldLv = dataManager.RoleAttr.Level;
		dataManager.KingOldExp = dataManager.RoleAttr.Exp;
		DataManager.StageDataController.RoleAttrLevelUp(MP, 63);
		byte b2 = MP.ReadByte(-1);
		MP.ReadUShort(-1);
		ushort freq = MP.ReadUShort(-1);
		dataManager.QBTimes = MP.ReadByte(-1);
		dataManager.ExpItemCount = 0;
		for (int i = 0; i < 6; i++)
		{
			dataManager.QBExpItem[i].ItemID = MP.ReadUShort(-1);
			dataManager.QBExpItem[i].Quantity = MP.ReadUShort(-1);
			if (dataManager.QBExpItem[i].ItemID > 0)
			{
				DataManager dataManager2 = dataManager;
				dataManager2.ExpItemCount += 1;
			}
		}
		MP.ReadBlock(dataManager.QBRewardLen, 0, 10, -1);
		b2 -= 1;
		DataManager.StageDataController.SetStagePoint(DataManager.StageDataController.currentPointID, b, freq);
		dataManager.QBRewardCount = 0;
		for (int j = 0; j < 10; j++)
		{
			dataManager.QBRewardCount += (int)dataManager.QBRewardLen[j];
		}
		if (dataManager.QBRewardCount > dataManager.QBRewardData.Length)
		{
			dataManager.QBRewardCount = dataManager.QBRewardData.Length;
		}
		for (int k = 0; k < dataManager.QBRewardCount; k++)
		{
			dataManager.QBRewardData[k] = MP.ReadUShort(-1);
		}
		dataManager.QBMoney = (uint)DataManager.StageDataController.GetLevelBycurrentPointID(0).Money;
		(GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BattleReport, 0, 0, true);
		int num = 0;
		while (num < dataManager.QBRewardCount && num < 220)
		{
			ushort itemID = dataManager.QBRewardData[num];
			ushort curItemQuantity = dataManager.GetCurItemQuantity(itemID, 0);
			if (curItemQuantity < 65535)
			{
				dataManager.SetCurItemQuantity(itemID, curItemQuantity + 1, 0, 0L);
			}
			num++;
		}
		int num2 = 0;
		while (num2 < (int)dataManager.ExpItemCount && num2 < 6)
		{
			int num3 = (int)(dataManager.GetCurItemQuantity(dataManager.QBExpItem[num2].ItemID, 0) + dataManager.QBExpItem[num2].Quantity);
			if (num3 <= 65535)
			{
				dataManager.SetCurItemQuantity(dataManager.QBExpItem[num2].ItemID, (ushort)num3, 0, 0L);
			}
			num2++;
		}
		GameManager.OnRefresh(NetworkNews.Refresh, null);
		GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
		GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
		if (dataManager.KingOldLv != dataManager.RoleAttr.Level)
		{
			GameManager.OnRefresh(NetworkNews.Refresh_Attr, null);
		}
		AFAdvanceManager.Instance.CheckHeroStageUnbroken();
	}

	// Token: 0x0600064C RID: 1612 RVA: 0x0008FB78 File Offset: 0x0008DD78
	public void SendQuickBattle(GUIManager.EQuickFightKind Kind, GUIManager.EStageKind Stagekind, ushort StageID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_QUICKBATTLE;
		messagePacket.AddSeqId();
		messagePacket.Add((byte)Kind);
		messagePacket.Add((byte)Stagekind);
		messagePacket.Add(StageID);
		messagePacket.Send(false);
	}

	// Token: 0x0600064D RID: 1613 RVA: 0x0008FBC0 File Offset: 0x0008DDC0
	private void CreateAttackStateImg()
	{
		GameObject gameObject = new GameObject("AlertImage");
		gameObject.layer = 5;
		RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.SetParent(this.m_FourthWindowLayer, false);
		this.StretchTransform(rectTransform);
		Image image = gameObject.AddComponent<Image>();
		image.type = Image.Type.Sliced;
		image.fillCenter = true;
		image.material = this.GetFrameMaterial();
		gameObject.AddComponent<IgnoreRaycast>();
		this.AlertImageSA = gameObject.AddComponent<UISpritesArray>();
		this.AlertImageSA.m_Sprites = new Sprite[3];
		this.AlertImageSA.m_Sprites[0] = this.LoadFrameSprite("UI_full_light_red");
		this.AlertImageSA.m_Sprites[1] = this.LoadFrameSprite("UI_full_light_blue");
		this.AlertImageSA.m_Sprites[2] = this.LoadFrameSprite("UI_full_light_green");
		this.AlertImageSA.m_Image = image;
		this.AlertImageSA.SetSpriteIndex(0);
		this.AlertImageSA.gameObject.SetActive(false);
	}

	// Token: 0x0600064E RID: 1614 RVA: 0x0008FCB0 File Offset: 0x0008DEB0
	public void AddAttackState(EAttackKind Kind)
	{
		this.AttackState(Kind, true);
	}

	// Token: 0x0600064F RID: 1615 RVA: 0x0008FCBC File Offset: 0x0008DEBC
	public void RemoveAttackState(EAttackKind Kind)
	{
		this.AttackState(Kind, false);
	}

	// Token: 0x06000650 RID: 1616 RVA: 0x0008FCC8 File Offset: 0x0008DEC8
	public void RemoveAllAttackState()
	{
		Array.Clear(GUIManager.Instance.m_AttackedAlertCount, 0, GUIManager.Instance.m_AttackedAlertCount.Length);
		this.CheckAttackState();
	}

	// Token: 0x06000651 RID: 1617 RVA: 0x0008FCF8 File Offset: 0x0008DEF8
	private void AttackState(EAttackKind Kind, bool bAdd = true)
	{
		int[] attackedAlertCount = this.m_AttackedAlertCount;
		if (bAdd)
		{
			attackedAlertCount[(int)Kind]++;
		}
		else
		{
			if (attackedAlertCount[(int)Kind] <= 0)
			{
				return;
			}
			attackedAlertCount[(int)Kind]--;
		}
		this.CheckAttackState();
	}

	// Token: 0x06000652 RID: 1618 RVA: 0x0008FD44 File Offset: 0x0008DF44
	private void CheckAttackState()
	{
		int[] attackedAlertCount = this.m_AttackedAlertCount;
		this.m_AttackedAlertTCount = 0;
		for (int i = 0; i < 15; i++)
		{
			this.m_AttackedAlertTCount += attackedAlertCount[i];
		}
		if (this.AlertImageSA != null)
		{
			if (this.m_AttackedAlertTCount > 0)
			{
				if (attackedAlertCount[0] > 0 || attackedAlertCount[1] > 0 || attackedAlertCount[6] > 0 || attackedAlertCount[7] > 0 || attackedAlertCount[2] > 0 || attackedAlertCount[3] > 0 || attackedAlertCount[8] > 0 || attackedAlertCount[4] > 0 || attackedAlertCount[9] > 0 || attackedAlertCount[5] > 0)
				{
					this.m_AlertImageIndex = 0;
				}
				else if (attackedAlertCount[10] > 0 || attackedAlertCount[11] > 0 || attackedAlertCount[12] > 0 || attackedAlertCount[13] > 0)
				{
					this.m_AlertImageIndex = 1;
				}
				else
				{
					this.m_AlertImageIndex = 2;
				}
				this.AlertImageSA.SetSpriteIndex(this.m_AlertImageIndex);
				this.AlertImageSA.gameObject.SetActive(true);
			}
			else
			{
				this.AlertImageSA.gameObject.SetActive(false);
			}
		}
		Door door = this.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.CheckAttackState();
		}
		else
		{
			this.CheckBattleAttackState();
		}
	}

	// Token: 0x06000653 RID: 1619 RVA: 0x0008FEA4 File Offset: 0x0008E0A4
	public void CheckBattleAttackState()
	{
		bool alertBlock = this.m_AttackedAlertTCount > 0 && this.m_AlertImageIndex == 0;
		UIBattle uibattle = this.FindMenu(EGUIWindow.UI_Battle) as UIBattle;
		if (uibattle != null && uibattle.gameObject.activeSelf)
		{
			uibattle.SetAlertBlock(alertBlock);
		}
		else
		{
			UILegBattle uilegBattle = this.FindMenu(EGUIWindow.UI_LegBattle) as UILegBattle;
			if (uilegBattle != null)
			{
				uilegBattle.SetAlertBlock(alertBlock);
			}
			else
			{
				UIBattle_Gambling uibattle_Gambling = this.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
				if (uibattle_Gambling != null)
				{
					uibattle_Gambling.SetAlertBlock(alertBlock);
				}
			}
		}
	}

	// Token: 0x06000654 RID: 1620 RVA: 0x0008FF4C File Offset: 0x0008E14C
	public void SetTroopsCount(int count)
	{
		this.m_TroopsCount = count;
		Door door = this.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.CheckTroopsState();
		}
	}

	// Token: 0x06000655 RID: 1621 RVA: 0x0008FF80 File Offset: 0x0008E180
	public void ClearBM()
	{
		this.m_BMGO = null;
		this.m_BMContentT = null;
		this.m_BMButtonT = null;
		this.m_BMBtnText = null;
		this.m_BMText1 = null;
		this.m_BMText2 = null;
		this.m_BMAssetBundleKey = 0;
		this.SerialNo = 0u;
		this.m_BMTime = -1f;
		this.bSendShow = false;
	}

	// Token: 0x06000656 RID: 1622 RVA: 0x0008FFD8 File Offset: 0x0008E1D8
	public string GetPointName(POINT_KIND PointKind)
	{
		DataManager dataManager = DataManager.Instance;
		switch (PointKind)
		{
		case POINT_KIND.PK_FOOD:
			return dataManager.mStringTable.GetStringByID(635u);
		case POINT_KIND.PK_STONE:
			return dataManager.mStringTable.GetStringByID(634u);
		case POINT_KIND.PK_IRON:
			return dataManager.mStringTable.GetStringByID(633u);
		case POINT_KIND.PK_WOOD:
			return dataManager.mStringTable.GetStringByID(636u);
		case POINT_KIND.PK_GOLD:
			return dataManager.mStringTable.GetStringByID(638u);
		case POINT_KIND.PK_CRYSTAL:
			return dataManager.mStringTable.GetStringByID(637u);
		case POINT_KIND.PK_CITY:
			return dataManager.mStringTable.GetStringByID(631u);
		case POINT_KIND.PK_CAMP:
			return dataManager.mStringTable.GetStringByID(639u);
		}
		return null;
	}

	// Token: 0x06000657 RID: 1623 RVA: 0x000900A8 File Offset: 0x0008E2A8
	public string GetPointName_Letter(POINT_KIND PointKind)
	{
		DataManager dataManager = DataManager.Instance;
		switch (PointKind)
		{
		case POINT_KIND.PK_FOOD:
			return dataManager.mStringTable.GetStringByID(6031u);
		case POINT_KIND.PK_STONE:
			return dataManager.mStringTable.GetStringByID(6028u);
		case POINT_KIND.PK_IRON:
			return dataManager.mStringTable.GetStringByID(6030u);
		case POINT_KIND.PK_WOOD:
			return dataManager.mStringTable.GetStringByID(6029u);
		case POINT_KIND.PK_GOLD:
			return dataManager.mStringTable.GetStringByID(6033u);
		case POINT_KIND.PK_CRYSTAL:
			return dataManager.mStringTable.GetStringByID(6032u);
		case POINT_KIND.PK_CITY:
			return dataManager.mStringTable.GetStringByID(631u);
		case POINT_KIND.PK_CAMP:
			return dataManager.mStringTable.GetStringByID(4540u);
		}
		return null;
	}

	// Token: 0x06000658 RID: 1624 RVA: 0x00090178 File Offset: 0x0008E378
	public void RecvBattleMessage(MessagePacket MP)
	{
		StringManager stringManager = StringManager.Instance;
		this.SerialNo = MP.ReadUInt(-1);
		GUIManager.ECombatLiveType ecombatLiveType = (GUIManager.ECombatLiveType)MP.ReadByte(-1);
		POINT_KIND point_KIND = (POINT_KIND)MP.ReadByte(-1);
		ushort bmnowKingdomID = MP.ReadUShort(-1);
		CString cstring = stringManager.StaticString1024();
		CString cstring2 = stringManager.StaticString1024();
		CString cstring3 = stringManager.StaticString1024();
		CString cstring4 = stringManager.StaticString1024();
		MP.ReadStringPlus(3, cstring, -1);
		MP.ReadStringPlus(13, cstring2, -1);
		if (this.m_BMATStr == null)
		{
			this.m_BMATStr = stringManager.SpawnString(30);
		}
		if (this.m_BMNStr == null)
		{
			this.m_BMNStr = stringManager.SpawnString(30);
		}
		this.m_BMATStr.Length = 0;
		this.m_BMATStr.Append(cstring);
		this.m_BMNStr.Length = 0;
		this.m_BMNStr.Append(cstring2);
		this.m_BMNowLiveType = ecombatLiveType;
		this.m_BMNowPointKind = point_KIND;
		this.m_BMNowKingdomID = bmnowKingdomID;
		int length = cstring.Length;
		int length2 = cstring2.Length;
		if (length2 > 0)
		{
			if (length > 0)
			{
				cstring3.StringToFormat(cstring);
				cstring3.AppendFormat("[{0}]");
			}
			cstring3.Append(cstring2);
		}
		else
		{
			cstring3.Append("NoName");
		}
		if (ecombatLiveType == GUIManager.ECombatLiveType.ECLTR_REINFORCE_UNDERATTACK)
		{
			cstring2.Length = 0;
			MP.ReadStringPlus(13, cstring2, -1);
			length2 = cstring2.Length;
			if (length2 > 0)
			{
				cstring4.Append(cstring2);
			}
			else
			{
				cstring4.Append("NoName");
			}
			this.OpenBattleMessage(ecombatLiveType, cstring3, point_KIND, this.SerialNo > 0u, cstring4, 0);
		}
		else
		{
			this.OpenBattleMessage(ecombatLiveType, cstring3, point_KIND, this.SerialNo > 0u, null, 0);
		}
		if (ecombatLiveType == GUIManager.ECombatLiveType.ECLTR_ATTACK)
		{
			this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7727u), 13, true);
		}
		else if (ecombatLiveType == GUIManager.ECombatLiveType.ECLTR_RALLYATTACK)
		{
			this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(493u), 13, true);
		}
	}

	// Token: 0x06000659 RID: 1625 RVA: 0x00090374 File Offset: 0x0008E574
	public void RecvWMMessage(MessagePacket MP)
	{
		this.SerialNo = MP.ReadUInt(-1);
		this.WM_RandomSeed = MP.ReadUShort(-1);
		this.WM_RandomGap = MP.ReadByte(-1);
		this.WM_HeroCount = 0;
		for (int i = 0; i < 5; i++)
		{
			this.WM_HeroData[i].HeroID = MP.ReadUShort(-1);
			if (this.WM_HeroData[i].HeroID != 0)
			{
				this.WM_HeroCount += 1;
			}
		}
		for (int j = 0; j < 5; j++)
		{
			this.WM_HeroData[j].AttrData.SkillLV1 = MP.ReadByte(-1);
			this.WM_HeroData[j].AttrData.SkillLV2 = MP.ReadByte(-1);
			this.WM_HeroData[j].AttrData.SkillLV3 = MP.ReadByte(-1);
			this.WM_HeroData[j].AttrData.SkillLV4 = MP.ReadByte(-1);
			this.WM_HeroData[j].AttrData.LV = MP.ReadByte(-1);
			this.WM_HeroData[j].AttrData.Star = MP.ReadByte(-1);
			this.WM_HeroData[j].AttrData.Enhance = MP.ReadByte(-1);
			this.WM_HeroData[j].AttrData.Equip = MP.ReadByte(-1);
		}
		this.WM_MonsterID = MP.ReadUShort(-1);
		this.WM_MonsterLv = MP.ReadByte(-1);
		this.WM_MonsterNowHP = MP.ReadUInt(-1);
		this.WM_MonsterMaxHP = MP.ReadUInt(-1);
		this.WM_MonsterAttr.ActionTimes = MP.ReadByte(-1);
		this.WM_MonsterAttr.SequentialDamageScale = MP.ReadUInt(-1);
		this.WM_MonsterAttr.DamageScale = MP.ReadUInt(-1);
		this.WM_MonsterAttr.MaxHPScale = MP.ReadUInt(-1);
		this.WM_MonsterAttr.HealingScale = MP.ReadUInt(-1);
		this.WM_MonsterAttr.InitMP = MP.ReadUShort(-1);
		this.WM_MonsterTagStr.Length = 0;
		MP.ReadStringPlus(3, this.WM_MonsterTagStr, -1);
		this.OpenBattleMessage(GUIManager.ECombatLiveType.ECLTR_WILDMONSTER, null, POINT_KIND.PK_NONE, true, null, 0);
	}

	// Token: 0x0600065A RID: 1626 RVA: 0x000905C0 File Offset: 0x0008E7C0
	public void RecvWonderMessage(MessagePacket MP)
	{
		StringManager stringManager = StringManager.Instance;
		this.SerialNo = MP.ReadUInt(-1);
		GUIManager.ECombatLiveType ecombatLiveType = (GUIManager.ECombatLiveType)MP.ReadByte(-1);
		byte b = MP.ReadByte(-1);
		ushort bmnowKingdomID = MP.ReadUShort(-1);
		CString cstring = stringManager.StaticString1024();
		CString cstring2 = stringManager.StaticString1024();
		CString cstring3 = stringManager.StaticString1024();
		CString cstring4 = stringManager.StaticString1024();
		MP.ReadStringPlus(3, cstring, -1);
		MP.ReadStringPlus(13, cstring2, -1);
		if (this.m_BMATStr == null)
		{
			this.m_BMATStr = stringManager.SpawnString(30);
		}
		if (this.m_BMNStr == null)
		{
			this.m_BMNStr = stringManager.SpawnString(30);
		}
		this.m_BMATStr.Length = 0;
		this.m_BMATStr.Append(cstring);
		this.m_BMNStr.Length = 0;
		this.m_BMNStr.Append(cstring2);
		this.m_BMNowLiveType = ecombatLiveType;
		this.m_BMNowPointKind = POINT_KIND.PK_YOLK;
		this.m_BMNowKingdomID = bmnowKingdomID;
		int length = cstring.Length;
		int length2 = cstring2.Length;
		if (length2 > 0)
		{
			if (length > 0)
			{
				cstring3.StringToFormat(cstring);
				cstring3.AppendFormat("[{0}]");
			}
			cstring3.Append(cstring2);
		}
		else
		{
			cstring3.Append("NoName");
		}
		if (ecombatLiveType == GUIManager.ECombatLiveType.ECLTR_REINFORCE_UNDERATTACK)
		{
			cstring2.Length = 0;
			MP.ReadStringPlus(13, cstring2, -1);
			length2 = cstring2.Length;
			if (length2 > 0)
			{
				cstring4.Append(cstring2);
			}
			else
			{
				cstring4.Append("NoName");
			}
			this.OpenBattleMessage(ecombatLiveType, cstring3, POINT_KIND.PK_MAX, this.SerialNo > 0u, cstring4, b + 1);
		}
		else
		{
			this.OpenBattleMessage(ecombatLiveType, cstring3, POINT_KIND.PK_MAX, this.SerialNo > 0u, null, b + 1);
		}
		if (ecombatLiveType == GUIManager.ECombatLiveType.ECLTR_ATTACK)
		{
			this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7727u), 13, true);
		}
		else if (ecombatLiveType == GUIManager.ECombatLiveType.ECLTR_RALLYATTACK)
		{
			this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(493u), 13, true);
		}
	}

	// Token: 0x0600065B RID: 1627 RVA: 0x000907C4 File Offset: 0x0008E9C4
	public void RecvNPCCityMessage(MessagePacket MP)
	{
		this.SerialNo = MP.ReadUInt(-1);
		this.WM_NPCLevel = MP.ReadByte(-1);
		this.OpenBattleMessage(GUIManager.ECombatLiveType.ECLTR_NPCCITY, null, POINT_KIND.PK_NONE, true, null, this.WM_NPCLevel);
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x000907FC File Offset: 0x0008E9FC
	public void Recv_PET_LIVEINFO(MessagePacket MP)
	{
		StringManager stringManager = StringManager.Instance;
		GUIManager.EPetLiveType epetLiveType = (GUIManager.EPetLiveType)MP.ReadByte(-1);
		POINT_KIND pointKind = (POINT_KIND)MP.ReadByte(-1);
		ushort num = MP.ReadUShort(-1);
		CString cstring = stringManager.StaticString1024();
		CString cstring2 = stringManager.StaticString1024();
		CString cstring3 = stringManager.StaticString1024();
		MP.ReadStringPlus(3, cstring, -1);
		MP.ReadStringPlus(13, cstring2, -1);
		int length = cstring.Length;
		int length2 = cstring2.Length;
		if (length2 > 0)
		{
			if (length > 0)
			{
				cstring3.StringToFormat(cstring);
				cstring3.AppendFormat("[{0}]");
			}
			cstring3.Append(cstring2);
		}
		else
		{
			cstring3.Append("NoName");
		}
		if (epetLiveType == GUIManager.EPetLiveType.EPLTR_ATTACK)
		{
			this.OpenBattleMessage(GUIManager.ECombatLiveType.ECLTR_PETATTACK, cstring3, pointKind, this.SerialNo > 0u, null, 0);
		}
		else if (epetLiveType == GUIManager.EPetLiveType.EPLTR_UNDERATTACK)
		{
			this.OpenBattleMessage(GUIManager.ECombatLiveType.ECLTR_PETUNDERATTACK, cstring3, pointKind, this.SerialNo > 0u, null, 0);
		}
	}

	// Token: 0x0600065D RID: 1629 RVA: 0x000908E4 File Offset: 0x0008EAE4
	public void OpenBattleMessage(GUIManager.ECombatLiveType MessageKind, CString PlayerName = null, POINT_KIND PointKind = POINT_KIND.PK_NONE, bool bShowButton = true, CString Player2Name = null, byte WonderID = 0)
	{
		DataManager dataManager = DataManager.Instance;
		StringManager stringManager = StringManager.Instance;
		if (!dataManager.MySysSetting.bShowChatFight)
		{
			return;
		}
		if (this.m_BMGO == null)
		{
			AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/BattleMessage", out this.m_BMAssetBundleKey, false);
			if (assetBundle == null)
			{
				return;
			}
			this.m_BMGO = (GameObject)UnityEngine.Object.Instantiate(assetBundle.mainAsset);
			if (this.m_BMGO == null)
			{
				AssetManager.UnloadAssetBundle(this.m_BMAssetBundleKey, true);
				return;
			}
			Transform transform = this.m_BMGO.transform;
			transform.GetChild(1).gameObject.SetActive(false);
			transform.GetChild(2).gameObject.SetActive(false);
			this.m_BMButtonT = transform.GetChild(3);
			UIButton component = this.m_BMButtonT.GetComponent<UIButton>();
			component.m_Handler = this;
			component.m_BtnID1 = 3;
			this.m_BMBtnText = this.m_BMButtonT.GetChild(0).GetComponent<UIText>();
			this.m_BMBtnText.font = this.m_TTFFont;
			this.m_BMBtnText.text = dataManager.mStringTable.GetStringByID(582u);
			this.m_BMLight = this.m_BMButtonT.GetChild(1).GetComponent<Image>();
			this.m_BMLightTime = 0f;
			transform = this.m_BMGO.transform.GetChild(4);
			this.m_BMContentT = transform.GetChild(0);
			this.m_BMText1 = this.m_BMContentT.GetChild(0).GetComponent<UIText>();
			this.m_BMText1.font = this.m_TTFFont;
			this.m_BMText2 = this.m_BMContentT.GetChild(1).GetComponent<UIText>();
			this.m_BMText2.font = this.m_TTFFont;
			this.m_BMGO.transform.SetParent(this.m_BattleMessageLayer, false);
		}
		else if (this.m_OKCancelClickIndex == 1)
		{
			this.CloseOKCancelBox();
			this.bSendShow = false;
		}
		if (this.SerialNo == 0u || !this.bGPShow)
		{
			this.m_BMButtonT.gameObject.SetActive(false);
			if (MessageKind == GUIManager.ECombatLiveType.ECLTR_PETATTACK || MessageKind == GUIManager.ECombatLiveType.ECLTR_PETUNDERATTACK)
			{
				RectTransform component2 = this.m_BMGO.transform.GetChild(4).GetComponent<RectTransform>();
				component2.offsetMax = new Vector2(-5f, 0f);
			}
		}
		else
		{
			this.m_BMButtonT.gameObject.SetActive(true);
		}
		this.m_BMTime = 15f;
		if (MessageKind == GUIManager.ECombatLiveType.ECLTR_UNDERATTACK || MessageKind == GUIManager.ECombatLiveType.ECLTR_REINFORCE_UNDERATTACK || MessageKind == GUIManager.ECombatLiveType.ECLTR_AMBUSH_UNDERATTACK || MessageKind == GUIManager.ECombatLiveType.ECLTR_PETUNDERATTACK)
		{
			this.bWarAttacker = false;
			UISpritesArray component3 = this.m_BMGO.transform.GetComponent<UISpritesArray>();
			component3.SetSpriteIndex(2);
			this.m_BMGO.transform.GetChild(0).GetComponent<Image>().sprite = component3.GetSprite(3);
			if (this.m_BMMessage1 == null)
			{
				this.m_BMMessage1 = stringManager.SpawnString(1024);
			}
			this.m_BMMessage1.Length = 0;
			if (MessageKind == GUIManager.ECombatLiveType.ECLTR_REINFORCE_UNDERATTACK)
			{
				CString cstring = stringManager.StaticString1024();
				cstring.StringToFormat(Player2Name);
				cstring.AppendFormat(dataManager.mStringTable.GetStringByID(632u));
				this.m_BMMessage1.StringToFormat(cstring);
			}
			else if (MessageKind == GUIManager.ECombatLiveType.ECLTR_AMBUSH_UNDERATTACK)
			{
				this.m_BMMessage1.StringToFormat(dataManager.mStringTable.GetStringByID(9734u));
			}
			else if (WonderID != 0)
			{
				this.m_BMMessage1.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)(WonderID - 1), 0));
			}
			else
			{
				this.m_BMMessage1.StringToFormat(this.GetPointName(PointKind));
			}
			this.m_BMMessage1.StringToFormat(PlayerName);
			this.m_BMMessage1.AppendFormat(dataManager.mStringTable.GetStringByID(628u));
			this.m_BMText1.text = this.m_BMMessage1.ToString();
			this.m_BMText1.SetAllDirty();
			this.m_BMText1.cachedTextGenerator.Invalidate();
		}
		else if (MessageKind == GUIManager.ECombatLiveType.ECLTR_WILDMONSTER)
		{
			this.m_BMNowLiveType = GUIManager.ECombatLiveType.ECLTR_WILDMONSTER;
			UISpritesArray component4 = this.m_BMGO.transform.GetComponent<UISpritesArray>();
			component4.SetSpriteIndex(0);
			this.m_BMGO.transform.GetChild(0).GetComponent<Image>().sprite = component4.GetSprite(1);
			if (this.m_BMMessage1 == null)
			{
				this.m_BMMessage1 = stringManager.SpawnString(1024);
			}
			this.m_BMMessage1.Length = 0;
			ushort nameID = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.WM_MonsterID).NameID;
			CString cstring2 = StringManager.Instance.StaticString1024();
			if (this.WM_MonsterTagStr[0] == '\0')
			{
				cstring2.Append(dataManager.mStringTable.GetStringByID((uint)nameID));
			}
			else
			{
				cstring2.StringToFormat(this.WM_MonsterTagStr);
				cstring2.StringToFormat(dataManager.mStringTable.GetStringByID((uint)nameID));
				cstring2.AppendFormat("[{0}]{1}");
			}
			this.m_BMMessage1.StringToFormat(cstring2);
			this.m_BMMessage1.IntToFormat((long)this.WM_MonsterLv, 1, false);
			this.m_BMMessage1.AppendFormat(dataManager.mStringTable.GetStringByID(8348u));
			this.m_BMText1.text = this.m_BMMessage1.ToString();
			this.m_BMText1.SetAllDirty();
			this.m_BMText1.cachedTextGenerator.Invalidate();
		}
		else if (MessageKind == GUIManager.ECombatLiveType.ECLTR_NPCCITY)
		{
			this.bWarAttacker = true;
			this.m_BMNowLiveType = GUIManager.ECombatLiveType.ECLTR_NPCCITY;
			UISpritesArray component5 = this.m_BMGO.transform.GetComponent<UISpritesArray>();
			component5.SetSpriteIndex(0);
			this.m_BMGO.transform.GetChild(0).GetComponent<Image>().sprite = component5.GetSprite(1);
			if (this.m_BMMessage1 == null)
			{
				this.m_BMMessage1 = stringManager.SpawnString(1024);
			}
			this.m_BMMessage1.Length = 0;
			CString cstring3 = StringManager.Instance.StaticString1024();
			cstring3.IntToFormat((long)WonderID, 1, false);
			cstring3.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021u));
			this.m_BMMessage1.StringToFormat(cstring3);
			this.m_BMMessage1.AppendFormat(dataManager.mStringTable.GetStringByID(12025u));
			this.m_BMText1.text = this.m_BMMessage1.ToString();
			this.m_BMText1.SetAllDirty();
			this.m_BMText1.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.bWarAttacker = true;
			UISpritesArray component6 = this.m_BMGO.transform.GetComponent<UISpritesArray>();
			component6.SetSpriteIndex(0);
			this.m_BMGO.transform.GetChild(0).GetComponent<Image>().sprite = component6.GetSprite(1);
			if (this.m_BMMessage1 == null)
			{
				this.m_BMMessage1 = stringManager.SpawnString(1024);
			}
			this.m_BMMessage1.Length = 0;
			this.m_BMMessage1.StringToFormat(PlayerName);
			if (WonderID != 0)
			{
				this.m_BMMessage1.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)(WonderID - 1), 0));
			}
			else
			{
				this.m_BMMessage1.StringToFormat(this.GetPointName(PointKind));
			}
			if (MessageKind == GUIManager.ECombatLiveType.ECLTR_PETATTACK)
			{
				this.m_BMMessage1.AppendFormat(dataManager.mStringTable.GetStringByID(14589u));
			}
			else
			{
				this.m_BMMessage1.AppendFormat(dataManager.mStringTable.GetStringByID(629u));
			}
			this.m_BMText1.text = this.m_BMMessage1.ToString();
			this.m_BMText1.SetAllDirty();
			this.m_BMText1.cachedTextGenerator.Invalidate();
		}
		Door door = this.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.m_ChatBox.gameObject.SetActive(false);
			this.CheckBattleMessageSize(door.m_eMode == EUIOriginMode.Show);
			if (door.bHideMainByFIFA)
			{
				this.m_BMGO.gameObject.SetActive(false);
			}
		}
		else
		{
			if (this.m_ChatBox != null)
			{
				this.m_ChatBox.gameObject.SetActive(false);
			}
			if (this.bInFightHideChat)
			{
				this.m_BMGO.gameObject.SetActive(false);
			}
			this.CheckBattleMessageSize(true);
		}
		AudioManager.Instance.PlayUISFX(UIKind.News);
	}

	// Token: 0x0600065E RID: 1630 RVA: 0x0009113C File Offset: 0x0008F33C
	public void CloseBattleMessage()
	{
		UnityEngine.Object.Destroy(this.m_BMGO);
		AssetManager.UnloadAssetBundle(this.m_BMAssetBundleKey, true);
		this.ClearBM();
		Door door = this.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			if ((door.m_eMode != EUIOriginMode.Show || !door.bHideMainMenu) && door.m_eMode != EUIOriginMode.Hide && door.m_eMode != EUIOriginMode.FuncButtonWithoutChatBox && !door.bHideMainByFIFA)
			{
				door.m_ChatBox.gameObject.SetActive(true);
			}
		}
		else if (this.m_ChatBox != null && !this.bInFightHideChat)
		{
			this.m_ChatBox.gameObject.SetActive(true);
		}
	}

	// Token: 0x0600065F RID: 1631 RVA: 0x000911FC File Offset: 0x0008F3FC
	public void CheckBattleMessageSize(bool bNormal)
	{
		if (this.m_BMGO != null)
		{
			RectTransform rectTransform = this.m_BMGO.transform as RectTransform;
			if (!this.bGPShow)
			{
				rectTransform.offsetMin = new Vector2(161f, rectTransform.offsetMin.y);
				rectTransform.offsetMax = new Vector2(-95f, rectTransform.offsetMax.y);
			}
			else if (bNormal)
			{
				rectTransform.offsetMin = new Vector2(267f, rectTransform.offsetMin.y);
				rectTransform.offsetMax = new Vector2(-152f, rectTransform.offsetMax.y);
			}
			else
			{
				rectTransform.offsetMin = new Vector2(144f, rectTransform.offsetMin.y);
				rectTransform.offsetMax = new Vector2(-95f, rectTransform.offsetMax.y);
			}
		}
	}

	// Token: 0x06000660 RID: 1632 RVA: 0x00091300 File Offset: 0x0008F500
	public void SetBattleMessageButton(bool bShow)
	{
		if (this.m_BMGO != null && this.bGPShow != bShow)
		{
			if (this.SerialNo == 0u || !bShow)
			{
				this.m_BMButtonT.gameObject.SetActive(false);
			}
			else
			{
				this.m_BMButtonT.gameObject.SetActive(true);
			}
		}
		this.bGPShow = bShow;
		if (this.m_BMGO != null && this.bGPShow)
		{
			this.m_BMGO.gameObject.SetActive(true);
		}
		if (!this.bGPShow)
		{
			this.CheckBattleMessageSize(false);
		}
	}

	// Token: 0x06000661 RID: 1633 RVA: 0x000913A8 File Offset: 0x0008F5A8
	public void SendBattleMessageRP()
	{
		if (this.SerialNo == 0u)
		{
			return;
		}
		DataManager.Instance.bWarAttacker = this.bWarAttacker;
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_LIVECOMBATREPLAY;
		messagePacket.AddSeqId();
		messagePacket.Add(this.SerialNo);
		messagePacket.Add(DataManager.Instance.Mailing.ReportSerial.New);
		messagePacket.Send(false);
	}

	// Token: 0x06000662 RID: 1634 RVA: 0x0009141C File Offset: 0x0008F61C
	public void CheckSuggestion()
	{
		if (this.RandomIndex != -1)
		{
			int randomIndex = this.RandomIndex;
			this.RandomIndex = -1;
			Door door = this.FindMenu(EGUIWindow.Door) as Door;
			if (door == null)
			{
				return;
			}
			switch (randomIndex)
			{
			case 0:
			{
				door.OpenMenu(EGUIWindow.UI_Hero_Info, 0, 0, true);
				UIHero_Info uihero_Info = this.FindMenu(EGUIWindow.UI_Hero_Info) as UIHero_Info;
				if (uihero_Info != null)
				{
					uihero_Info.SetPage(1);
				}
				break;
			}
			case 1:
				door.OpenMenu(EGUIWindow.UI_BagFilter, 4, 0, false);
				break;
			case 2:
			case 3:
				door.OpenMenu(EGUIWindow.UI_Hero_Info, 0, 0, true);
				break;
			case 4:
				this.HeroListSaved = 1;
				door.OpenMenu(EGUIWindow.UI_HeroList, 0, 0, false);
				break;
			}
		}
	}

	// Token: 0x06000663 RID: 1635 RVA: 0x000914EC File Offset: 0x0008F6EC
	public void CheckLvUp(bool bInBattle = false)
	{
		if (this.PreLeadLevel > 0 && (int)DataManager.Instance.RoleAttr.Level >= this.PreLeadLevel + 1)
		{
			this.OpenUI_Queued_Restricted(EGUIWindow.UI_leadup, this.PreLeadLevel, 0, false, 0);
		}
		this.PreLeadLevel = -1;
	}

	// Token: 0x06000664 RID: 1636 RVA: 0x0009153C File Offset: 0x0008F73C
	private void InitialChatBox(RectTransform ChatBox)
	{
		this.m_ChatBox = ChatBox;
		Transform transform = this.m_ChatBox.transform;
		this.m_ChatChannelLight = transform.GetChild(2).GetComponent<Image>();
		this.m_ChatChannelLight1 = this.m_ChatChannelLight.transform.GetChild(0).GetComponent<Image>();
		this.ChannelSpriteOn = this.m_ChatChannelLight1.sprite;
		this.m_ChatChannelLight2 = this.m_ChatChannelLight.transform.GetChild(1).GetComponent<Image>();
		this.ChannelSpriteOff = this.m_ChatChannelLight2.sprite;
		this.m_ChannelLightFlashGO = this.m_ChatChannelLight.transform.GetChild(1).GetChild(0).gameObject;
		Transform child = transform.GetChild(3);
		this.m_ChatImage = child.GetComponent<Image>();
		this.m_ChatImage.enabled = false;
		this.m_ChatMask = child.GetComponent<Mask>();
		this.m_ChatMask.enabled = false;
		this.m_ChatScrollRect = child.gameObject.AddComponent<CScrollRect>();
		this.m_ChatScrollRect.horizontal = true;
		this.m_ChatScrollRect.vertical = false;
		this.m_ChatScrollRect.content = (RectTransform)child.GetChild(0);
		this.m_ChatScrollRect.bPageMove = true;
		this.m_ChatScrollRect.m_PageMoveHandler = this;
		this.m_ChatScrollRectRC = this.m_ChatScrollRect.GetComponent<RectTransform>();
		this.m_ChatContentT = child.GetChild(0);
		for (int i = 0; i < 2; i++)
		{
			this.m_ChatChannel[i] = new ChatChannel();
			child = this.m_ChatContentT.GetChild(i);
			this.m_ChatChannel[i].MainRC = (RectTransform)child;
			this.m_ChatChannel[i].m_ChatText[0] = child.GetChild(2).GetComponent<UIText>();
			this.m_ChatChannel[i].m_ChatText[0].font = this.GetTTFFont();
			this.m_ChatChannel[i].m_ChatTextRC[0] = this.m_ChatChannel[i].m_ChatText[0].rectTransform;
			this.m_ChatChannel[i].m_ChatText[1] = child.GetChild(3).GetComponent<UIText>();
			this.m_ChatChannel[i].m_ChatText[1].font = this.GetTTFFont();
			this.m_ChatChannel[i].m_ChatTextRC[1] = this.m_ChatChannel[i].m_ChatText[1].rectTransform;
			this.m_ChatChannel[i].m_ChatText[0].SetCheckArabic(true);
			this.m_ChatChannel[i].m_ChatText[1].SetCheckArabic(true);
			this.m_ChatChannel[i].m_Button = child.GetChild(4).GetComponent<UIButton>();
			this.m_ChatChannel[i].m_Button.m_Handler = this;
			this.m_ChatChannel[i].m_ChatEmojiRC[0] = child.GetChild(5 + i).GetComponent<RectTransform>();
			this.m_ChatChannel[i].m_ChatEmojiRC[0].gameObject.AddComponent<IgnoreRaycast>();
			this.m_ChatChannel[i].m_ChatEmojiRC[1] = child.GetChild(6 + i).GetComponent<RectTransform>();
			this.m_ChatChannel[i].m_ChatEmojiRC[1].gameObject.AddComponent<IgnoreRaycast>();
			if (this.IsArabic)
			{
				this.m_ChatChannel[i].m_ChatEmojiRC[0].localScale = new Vector3(-1f, 1f, 1f);
				this.m_ChatChannel[i].m_ChatEmojiRC[1].localScale = new Vector3(-1f, 1f, 1f);
			}
			if (i == 1)
			{
				this.NoAllianceText = child.GetChild(5).GetComponent<UIText>();
				this.NoAllianceText.font = this.GetTTFFont();
				this.NoAllianceText.text = DataManager.Instance.mStringTable.GetStringByID(689u);
			}
		}
		this.m_ChatScrollRect.ChangePageWidth(this.m_ChatScrollRectRC.rect.width);
		if (DataManager.Instance.NowChannel == 1)
		{
			this.m_ChatScrollRect.setCurrentIndex(1, true);
			this.m_ChatContentT.GetChild(0).gameObject.SetActive(false);
		}
		else
		{
			this.m_ChatScrollRect.setCurrentIndex(0, true);
			this.m_ChatContentT.GetChild(1).gameObject.SetActive(false);
		}
		this.CheckNoAllianceText();
		this.bInFightHideChat = false;
	}

	// Token: 0x06000665 RID: 1637 RVA: 0x00091978 File Offset: 0x0008FB78
	private void ClearChatBox()
	{
		this.m_ChatBox = null;
	}

	// Token: 0x06000666 RID: 1638 RVA: 0x00091984 File Offset: 0x0008FB84
	private void ClearEmoji()
	{
		if (this.m_ChatBox == null)
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				if (this.m_ChatChannel[i] != null && this.m_ChatChannel[i].EUnit[j] != null)
				{
					this.pushEmojiIcon(this.m_ChatChannel[i].EUnit[j]);
					this.m_ChatChannel[i].EUnit[j] = null;
				}
			}
		}
	}

	// Token: 0x06000667 RID: 1639 RVA: 0x00091A10 File Offset: 0x0008FC10
	public void DoorOpenChatBox(RectTransform ChatBox)
	{
		this.InitialChatBox(ChatBox);
		this.UpdateMainUIChat();
		this.CheckChannelLightFlash(0);
		if (this.m_BMGO != null)
		{
			this.m_BMGO.gameObject.SetActive(true);
			if (this.m_ChatBox != null)
			{
				this.m_ChatBox.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06000668 RID: 1640 RVA: 0x00091A78 File Offset: 0x0008FC78
	public void DoorCloseChatBox()
	{
		this.ClearEmoji();
		this.ClearChatBox();
	}

	// Token: 0x06000669 RID: 1641 RVA: 0x00091A88 File Offset: 0x0008FC88
	public void BattleOpenChatBox()
	{
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/ChatBox", out this.m_ChatBoxAssetKey, false);
		if (assetBundle == null)
		{
			return;
		}
		this.m_ChatBoxGO = (GameObject)UnityEngine.Object.Instantiate(assetBundle.mainAsset);
		if (this.m_ChatBoxGO == null)
		{
			AssetManager.UnloadAssetBundle(this.m_ChatBoxAssetKey, true);
			return;
		}
		this.m_ChatBoxGO.transform.SetParent(this.m_WindowsTransform, false);
		this.m_ChatBoxGO.transform.SetAsFirstSibling();
		this.InitialChatBox(this.m_ChatBoxGO.GetComponent<RectTransform>());
		this.m_ChatBox.offsetMin = new Vector2(161f, this.m_ChatBox.offsetMin.y);
		this.m_ChatBox.offsetMax = new Vector2(-95f, this.m_ChatBox.offsetMax.y);
		this.m_ChatScrollRect.ChangePageWidth(this.m_ChatScrollRectRC.rect.width);
		this.UpdateMainUIChat();
		this.CheckChannelLightFlash(0);
		if (this.m_BMGO != null)
		{
			this.m_ChatBox.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600066A RID: 1642 RVA: 0x00091BC0 File Offset: 0x0008FDC0
	public void BattleCloseChatBox()
	{
		this.ClearEmoji();
		UnityEngine.Object.Destroy(this.m_ChatBoxGO);
		AssetManager.UnloadAssetBundle(this.m_ChatBoxAssetKey, true);
		this.ClearChatBox();
	}

	// Token: 0x0600066B RID: 1643 RVA: 0x00091BE8 File Offset: 0x0008FDE8
	public void ShowChatBox()
	{
		if (this.m_BMGO != null)
		{
			this.m_BMGO.gameObject.SetActive(true);
		}
		else if (this.m_ChatBox != null)
		{
			this.m_ChatBox.gameObject.SetActive(true);
		}
		this.bInFightHideChat = false;
	}

	// Token: 0x0600066C RID: 1644 RVA: 0x00091C48 File Offset: 0x0008FE48
	public void HideChatBox()
	{
		if (this.m_BMGO != null)
		{
			this.m_BMGO.gameObject.SetActive(false);
		}
		if (this.m_ChatBox != null)
		{
			this.m_ChatBox.gameObject.SetActive(false);
		}
		this.bInFightHideChat = true;
	}

	// Token: 0x0600066D RID: 1645 RVA: 0x00091CA0 File Offset: 0x0008FEA0
	private unsafe void UpdateMainUIChat()
	{
		DataManager dataManager = DataManager.Instance;
		Font font = this.m_ChatChannel[0].m_ChatText[0].font;
		CharacterInfo characterInfo = default(CharacterInfo);
		byte check = 0;
		for (int i = 0; i < 2; i++)
		{
			List<TalkDataType> list = (i != 0) ? dataManager.TalkData_Alliance : dataManager.TalkData_Kingdom;
			CString[] array = (i != 0) ? dataManager.ChatStrA : dataManager.ChatStr;
			int num = 0;
			int[] array2 = new int[]
			{
				-1,
				-1
			};
			int num2 = list.Count - 1;
			while (num2 >= 0 && num < 2)
			{
				if (list[num2].TalkKind != 1)
				{
					if (i != 1 || !dataManager.CheckHideTalk(list[num2]))
					{
						array2[num] = num2;
						num++;
					}
				}
				num2--;
			}
			for (int j = 0; j < 2; j++)
			{
				array[j].ClearString();
				int num3;
				if (j == 0)
				{
					num3 = ((array2[1] != -1) ? array2[1] : array2[0]);
				}
				else
				{
					num3 = ((array2[1] != -1) ? array2[0] : array2[1]);
				}
				this.m_ChatChannel[i].m_ChatEmojiRC[j].gameObject.SetActive(false);
				if (num3 >= 0 && num3 < list.Count)
				{
					bool flag = list[num3].FuncKind == 109;
					check = list[num3].bHaveArabic;
					float num4 = 0f;
					if (flag)
					{
						font.RequestCharactersInTexture(list[num3].ShowName.ToString(), 17);
						for (int k = 0; k < list[num3].ShowName.Length; k++)
						{
							if (font.GetCharacterInfo(list[num3].ShowName[k], out characterInfo, 17))
							{
								num4 += characterInfo.width;
							}
							else
							{
								num4 += 15f;
							}
						}
						font.RequestCharactersInTexture("：", 17);
						if (font.GetCharacterInfo('：', out characterInfo, 17))
						{
							num4 += characterInfo.width;
						}
						else
						{
							num4 += 15f;
						}
						dataManager.ChatMainStr.Length = 0;
						bool flag2 = i == 0 && list[num3].KingdomID > 0 && list[num3].KingdomID != DataManager.MapDataController.kingdomData.kingdomID;
						ushort kingdomID = (!flag2) ? 0 : list[num3].KingdomID;
						dataManager.ChatNameStr.Length = 0;
						this.FormatRoleNameForChat(dataManager.ChatNameStr, list[num3].PlayerName, list[num3].TitleName, kingdomID, false);
						if (this.IsArabic)
						{
							array[j].Append("：");
							array[j].Append(dataManager.ChatNameStr);
						}
						else
						{
							array[j].Append(dataManager.ChatNameStr);
							array[j].Append("：");
						}
						this.m_ChatChannel[i].m_ChatEmojiRC[j].gameObject.SetActive(true);
						if (this.m_ChatChannel[i].EUnit[j] != null)
						{
							this.pushEmojiIcon(this.m_ChatChannel[i].EUnit[j]);
							this.m_ChatChannel[i].EUnit[j] = null;
						}
						EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(list[num3].EmojiKey);
						this.m_ChatChannel[i].EUnit[j] = this.pullEmojiIcon(recordByKey.IconID, recordByKey.KeyFrame, false);
						this.m_ChatChannel[i].EUnit[j].EmojiTransform.SetParent(this.m_ChatChannel[i].m_ChatEmojiRC[j], false);
						((RectTransform)this.m_ChatChannel[i].EUnit[j].EmojiTransform).anchoredPosition = Vector2.zero;
						RectTransform component = this.m_ChatChannel[i].EUnit[j].EmojiTransform.GetComponent<RectTransform>();
						float num5 = 24f / (float)recordByKey.sizeY;
						component.localScale = new Vector3(num5, num5, num5);
						this.m_ChatChannel[i].m_ChatEmojiRC[j].anchoredPosition = new Vector2(36.5f + num4, this.m_ChatChannel[i].m_ChatEmojiRC[j].anchoredPosition.y) + ((!this.IsArabic) ? Vector2.zero : new Vector2(24f, 0f));
					}
					else
					{
						bool flag3 = false;
						if (list[num3].FuncKind <= 100)
						{
							font.RequestCharactersInTexture(list[num3].ShowName.ToString(), 17);
							for (int l = 0; l < list[num3].ShowName.Length; l++)
							{
								if (font.GetCharacterInfo(list[num3].ShowName[l], out characterInfo, 17))
								{
									num4 += characterInfo.width;
								}
								else
								{
									num4 += 15f;
								}
							}
							font.RequestCharactersInTexture("：", 17);
							if (font.GetCharacterInfo('：', out characterInfo, 17))
							{
								num4 += characterInfo.width;
							}
							else
							{
								num4 += 15f;
							}
						}
						float num6 = this.m_ChatChannel[0].m_ChatTextRC[0].rect.width - 45f - num4;
						dataManager.ChatMainStr.Length = 0;
						if (list[num3].FuncKind > 100)
						{
							dataManager.ChatMainStr.Append(list[num3].MainText);
						}
						else if (this.bAutoTranslate && list[num3].PlayID != dataManager.RoleAttr.UserId && list[num3].TranslateState == eTranslateState.completed && dataManager.CheckLanguageTranslateByIdx((int)list[num3].TranslateLanguage) && list[num3].TranslateLanguage != (ushort)IGGGameSDK.Instance.UserLanguageMapToTranslateLanguageIdx)
						{
							dataManager.ChatMainStr.Append(list[num3].TranslateText);
							flag3 = true;
						}
						else
						{
							dataManager.ChatMainStr.Append(list[num3].MainText);
						}
						font.RequestCharactersInTexture(dataManager.ChatMainStr.ToString(), 17);
						int length = dataManager.ColorL.Length;
						int num7 = (!list[num3].bHasLoc) ? -1 : list[num3].BeginIndex;
						int length2 = dataManager.ColorR.Length;
						int num8 = (!list[num3].bHasLoc) ? -1 : (list[num3].EndIndex + length);
						int num9 = -1;
						if (flag3)
						{
							num7 = ((!list[num3].bHasLocT) ? -1 : list[num3].BeginIndexT);
							num8 = ((!list[num3].bHasLocT) ? -1 : (list[num3].EndIndexT + length));
						}
						bool flag4 = false;
						fixed (string text = dataManager.ChatMainStr.ToString())
						{
							fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
							{
								float num10 = 0f;
								int m;
								for (m = 0; m < dataManager.ChatMainStr.Length; m++)
								{
									if (!flag4 && ArabicTransfer.Instance.IsArabic(dataManager.ChatMainStr[m]))
									{
										flag4 = true;
									}
									if (num7 != -1 && m >= num7 && m < num7 + length - 1)
									{
										if (m == num7 + 8)
										{
											dataManager.ChatMainStr.SetChar(m, '0');
										}
										else if (m == num7 + 9)
										{
											dataManager.ChatMainStr.SetChar(m, '0');
										}
										else if (m == num7 + 10)
										{
											dataManager.ChatMainStr.SetChar(m, 'C');
										}
										else if (m == num7 + 11)
										{
											dataManager.ChatMainStr.SetChar(m, '3');
										}
										else if (m == num7 + 12)
										{
											dataManager.ChatMainStr.SetChar(m, 'F');
										}
										else if (m == num7 + 13)
										{
											dataManager.ChatMainStr.SetChar(m, 'E');
										}
									}
									else if (num8 == -1 || m <= num8 || m >= num8 + length2)
									{
										if (font.GetCharacterInfo(dataManager.ChatMainStr[m], out characterInfo, 17))
										{
											num10 += characterInfo.width;
										}
										else
										{
											num10 += 15f;
										}
										if (dataManager.ChatMainStr[m] == '\n' || num10 > num6)
										{
											ptr[m] = '.';
											ptr[m + 1] = '.';
											ptr[m + 2] = '.';
											ptr[m + 3] = '\0';
											num9 = m;
											break;
										}
									}
								}
								if (num9 != -1 && list[num3].bHasLoc && m >= num7 + length - 1 && m < num8 + length2)
								{
									dataManager.ChatMainStr.Insert(num9, "</color>", -1);
								}
								text = null;
								if (list[num3].FuncKind <= 100)
								{
									bool flag5 = i == 0 && list[num3].KingdomID > 0 && list[num3].KingdomID != DataManager.MapDataController.kingdomData.kingdomID;
									ushort kingdomID2 = (!flag5) ? 0 : list[num3].KingdomID;
									dataManager.ChatNameStr.Length = 0;
									this.FormatRoleNameForChat(dataManager.ChatNameStr, list[num3].PlayerName, list[num3].TitleName, kingdomID2, flag4);
									array[j].StringToFormat(dataManager.ChatNameStr);
									array[j].StringToFormat(dataManager.ChatMainStr);
									if (this.IsArabic)
									{
										if (flag4)
										{
											array[j].AppendFormat(dataManager.chatusestr);
										}
										else
										{
											array[j].AppendFormat(dataManager.chatusestr2);
										}
									}
									else if (flag4)
									{
										array[j].AppendFormat(dataManager.chatusestr2);
									}
									else
									{
										array[j].AppendFormat(dataManager.chatusestr);
									}
								}
								else
								{
									array[j].Append(dataManager.ChatMainStr);
								}
							}
						}
					}
					if (list[num3].TalkKind >= 4 && list[num3].TalkKind <= 7)
					{
						this.m_ChatChannel[i].m_ChatText[j].color = Color.green;
					}
					else if (list[num3].TalkKind == 9)
					{
						this.m_ChatChannel[i].m_ChatText[j].color = new Color32(byte.MaxValue, 235, 4, byte.MaxValue);
					}
					else if (list[num3].TalkKind == 10 || list[num3].TalkKind == 11)
					{
						this.m_ChatChannel[i].m_ChatText[j].color = new Color32(byte.MaxValue, 238, 158, byte.MaxValue);
					}
					else
					{
						this.m_ChatChannel[i].m_ChatText[j].color = Color.white;
					}
				}
				this.m_ChatChannel[i].m_ChatText[j].SetText(array[j].ToString(), (eTextCheck)check);
				this.m_ChatChannel[i].m_ChatText[j].SetAllDirty();
				this.m_ChatChannel[i].m_ChatText[j].cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x0600066E RID: 1646 RVA: 0x00092968 File Offset: 0x00090B68
	public void BeginPageMove()
	{
		if (this.m_ChatMask != null)
		{
			this.m_ChatMask.enabled = true;
		}
		if (this.m_ChatImage != null)
		{
			this.m_ChatImage.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (i != (int)this.ChannelIndex)
			{
				this.m_ChatContentT.GetChild(i).gameObject.SetActive(true);
			}
		}
	}

	// Token: 0x0600066F RID: 1647 RVA: 0x000929E4 File Offset: 0x00090BE4
	public void EndPageMove()
	{
		for (int i = 0; i < 2; i++)
		{
			if (i != (int)this.ChannelIndex)
			{
				this.m_ChatContentT.GetChild(i).gameObject.SetActive(false);
			}
		}
		if (this.m_ChatImage != null)
		{
			this.m_ChatImage.enabled = false;
		}
		if (this.m_ChatMask != null)
		{
			this.m_ChatMask.enabled = false;
		}
	}

	// Token: 0x06000670 RID: 1648 RVA: 0x00092A60 File Offset: 0x00090C60
	public void PageIndexChange(byte PageIndex)
	{
		if (this.ChannelIndex != PageIndex)
		{
			this.ChannelIndex = PageIndex;
			DataManager.Instance.NowChannel = this.ChannelIndex;
		}
		if (this.ChannelIndex == 0)
		{
			this.m_ChatChannelLight1.sprite = this.ChannelSpriteOn;
			this.m_ChatChannelLight2.sprite = this.ChannelSpriteOff;
			if (DataManager.Instance.bRecvKingdom == 0)
			{
				DataManager.Instance.SendAskData(0, 0, -1, 0L, 0L);
			}
		}
		else if (this.ChannelIndex == 1)
		{
			this.m_ChatChannelLight1.sprite = this.ChannelSpriteOff;
			this.m_ChatChannelLight2.sprite = this.ChannelSpriteOn;
		}
		this.CheckChannelLightFlash(0);
	}

	// Token: 0x06000671 RID: 1649 RVA: 0x00092B18 File Offset: 0x00090D18
	private void CheckChannelLightFlash(int open)
	{
		if ((open == 1 || (DataManager.Instance.unReadCount > 0 && DataManager.Instance.bShowUnreadCount)) && this.ChannelIndex == 0)
		{
			this.m_ChannelLightFlashGO.SetActive(true);
		}
		else
		{
			this.m_ChannelLightFlashGO.SetActive(false);
		}
	}

	// Token: 0x06000672 RID: 1650 RVA: 0x00092B74 File Offset: 0x00090D74
	private void CheckNoAllianceText()
	{
		if (DataManager.Instance.RoleAlliance.Id > 0u)
		{
			this.NoAllianceText.gameObject.SetActive(false);
		}
		else
		{
			this.NoAllianceText.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x00092BC0 File Offset: 0x00090DC0
	public void UpdateChatBox(int arg1, int arg2 = 0)
	{
		if (this.m_ChatBox == null)
		{
			return;
		}
		switch ((byte)arg1)
		{
		case 0:
			this.UpdateMainUIChat();
			break;
		case 6:
			this.m_ChatScrollRect.setCurrentIndex(0, true);
			this.m_ChatContentT.GetChild(1).gameObject.SetActive(false);
			this.m_ChatContentT.GetChild(0).gameObject.SetActive(true);
			break;
		case 7:
			this.m_ChatScrollRect.setCurrentIndex(1, true);
			this.m_ChatContentT.GetChild(0).gameObject.SetActive(false);
			this.m_ChatContentT.GetChild(1).gameObject.SetActive(true);
			break;
		case 8:
			this.CheckChannelLightFlash(arg2);
			break;
		case 9:
			this.CheckNoAllianceText();
			break;
		}
	}

	// Token: 0x06000674 RID: 1652 RVA: 0x00092CB8 File Offset: 0x00090EB8
	public bool FormatRoleNameForChat(CString FromattedName, CString Name, CString Tag = null, ushort KingdomID = 0, bool ForceArabic = false)
	{
		bool flag = false;
		if (FromattedName == null)
		{
			return flag;
		}
		FromattedName.ClearString();
		if (ForceArabic)
		{
			flag = true;
		}
		if (flag)
		{
			if (this.IsArabic && KingdomID > 0)
			{
				FromattedName.IntToFormat((long)KingdomID, 1, false);
				FromattedName.AppendFormat("#{0} ");
			}
			FromattedName.Append(Name);
			if (Tag != null && Tag.Length > 0)
			{
				FromattedName.StringToFormat(Tag);
				FromattedName.AppendFormat("[{0}]");
			}
			if (!this.IsArabic && KingdomID > 0)
			{
				FromattedName.IntToFormat((long)KingdomID, 1, false);
				FromattedName.AppendFormat(" {0}#");
			}
		}
		else
		{
			if (!this.IsArabic && KingdomID > 0)
			{
				FromattedName.IntToFormat((long)KingdomID, 1, false);
				FromattedName.AppendFormat("#{0} ");
			}
			if (Tag != null && Tag.Length > 0)
			{
				FromattedName.StringToFormat(Tag);
				FromattedName.AppendFormat("[{0}]");
			}
			FromattedName.Append(Name);
			if (this.IsArabic && KingdomID > 0)
			{
				FromattedName.IntToFormat((long)KingdomID, 1, false);
				FromattedName.AppendFormat(" {0}#");
			}
		}
		return flag;
	}

	// Token: 0x06000675 RID: 1653 RVA: 0x00092DEC File Offset: 0x00090FEC
	public bool SendChat(byte Channel, string tmpStr)
	{
		DataManager dataManager = DataManager.Instance;
		if (dataManager.sendTimer > 0f)
		{
			this.AddHUDMessage(dataManager.mStringTable.GetStringByID(658u), 255, true);
			return false;
		}
		eTextCheck data;
		if (ArabicTransfer.Instance.IsArabicStr(tmpStr))
		{
			data = eTextCheck.Text_Arabic;
		}
		else
		{
			data = eTextCheck.Text_NonArabic;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_SENDCHAT;
		char[] chars = tmpStr.ToCharArray();
		byte[] bytes = Encoding.UTF8.GetBytes(chars, 0, tmpStr.Length);
		if (bytes.Length <= 0)
		{
			return false;
		}
		messagePacket.AddSeqId();
		messagePacket.Add(Channel);
		messagePacket.Add(0);
		if (dataManager.ServerVersionMajor != 0)
		{
			messagePacket.Add((byte)data);
		}
		messagePacket.Add((ushort)bytes.Length);
		messagePacket.Add(bytes, 0, 0);
		messagePacket.Send(false);
		dataManager.sendTimer = dataManager.SendTalkTime;
		if (Channel == 1)
		{
			AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.CHAT_INGUILD);
		}
		return true;
	}

	// Token: 0x06000676 RID: 1654 RVA: 0x00092EEC File Offset: 0x000910EC
	public void LoginCheckOpenBtn()
	{
		this.bOpenHeroBtn = this.CheckOpenHeroBtn();
		this.bOpenAllianceBtn = this.CheckOpenAllianceBtn();
		this.bNeedForceOpenFuncBtn = false;
	}

	// Token: 0x06000677 RID: 1655 RVA: 0x00092F10 File Offset: 0x00091110
	public bool CheckOpenHeroBtn()
	{
		return DataManager.StageDataController.StageRecord[2] >= 2;
	}

	// Token: 0x06000678 RID: 1656 RVA: 0x00092F24 File Offset: 0x00091124
	public bool CheckOpenAllianceBtn()
	{
		return GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 3 || DataManager.Instance.RoleAlliance.Id > 0u || DataManager.Instance.CheckPrizeFlag(0);
	}

	// Token: 0x06000679 RID: 1657 RVA: 0x00092F7C File Offset: 0x0009117C
	public void LoadLvUpLight(Transform ParentT)
	{
		if (this.m_LvUpGO != null)
		{
			this.ReleaseLvUpLight();
		}
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UILight", out this.m_LvUpAssetBundleKey, false);
		if (assetBundle == null)
		{
			return;
		}
		this.m_LvUpGO = (GameObject)UnityEngine.Object.Instantiate(assetBundle.mainAsset);
		if (this.m_LvUpGO == null)
		{
			AssetManager.UnloadAssetBundle(this.m_LvUpAssetBundleKey, true);
			return;
		}
		this.m_LvUpGO.transform.SetParent(ParentT, false);
		this.m_LvUpGO.transform.SetAsFirstSibling();
	}

	// Token: 0x0600067A RID: 1658 RVA: 0x00093018 File Offset: 0x00091218
	public void ReleaseLvUpLight()
	{
		if (this.m_LvUpAssetBundleKey != 0)
		{
			UnityEngine.Object.Destroy(this.m_LvUpGO);
			AssetManager.UnloadAssetBundle(this.m_LvUpAssetBundleKey, true);
			this.m_LvUpGO = null;
			this.m_LvUpAssetBundleKey = 0;
		}
	}

	// Token: 0x0600067B RID: 1659 RVA: 0x00093058 File Offset: 0x00091258
	private void InitialBackMessageBox()
	{
		for (int i = 0; i < 5; i++)
		{
			this.m_SystemInChat[i].m_Message = new CString(1026);
			this.m_RunningText[i].m_Message = new CString(1026);
		}
	}

	// Token: 0x0600067C RID: 1660 RVA: 0x000930B0 File Offset: 0x000912B0
	public void ClearBackMessageBox(byte Kind = 255)
	{
		if (Kind == 255 || Kind == 0)
		{
			this.m_BackMGWaitOpen = false;
			this.m_BackMGBeginTime = 0L;
			this.m_BackMGEndTime = 0L;
			this.m_BackMGDeltaTime = 0u;
			this.ReleaseBackMessageBox();
		}
		if (Kind == 255 || Kind == 1)
		{
			this.m_RunningTextIndex = 0;
			for (int i = 0; i < 5; i++)
			{
				this.m_RunningText[i].m_BeginTime = 0L;
				this.m_RunningText[i].m_EndTime = 0L;
				this.m_RunningText[i].m_TimeInterval = 0u;
			}
		}
		if (Kind == 255 || Kind == 2)
		{
			this.m_SystemInChatIndex = 0;
			for (int j = 0; j < 5; j++)
			{
				this.m_SystemInChat[j].m_BeginTime = 0L;
				this.m_SystemInChat[j].m_EndTime = 0L;
				this.m_SystemInChat[j].m_TimeInterval = 0u;
			}
		}
	}

	// Token: 0x0600067D RID: 1661 RVA: 0x000931B8 File Offset: 0x000913B8
	public void RecvBackMessageDelete(MessagePacket MP)
	{
		this.ClearBackMessageBox(MP.ReadByte(-1));
	}

	// Token: 0x0600067E RID: 1662 RVA: 0x000931C8 File Offset: 0x000913C8
	public void RecvBackMessage(MessagePacket MP)
	{
		MP.ReadByte(-1);
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			this.m_BackMGBeginTime = MP.ReadLong(-1);
			this.m_BackMGEndTime = MP.ReadLong(-1);
			this.m_BackMGDeltaTime = MP.ReadUInt(-1);
			MP.ReadStringPlus(241, this.m_BackMGTitle, -1);
			MP.ReadStringPlus(1025, this.m_BackMGMessage, -1);
			this.m_BackMGWaitOpen = false;
		}
		else if (b == 1)
		{
			byte runningTextIndex = this.m_RunningTextIndex;
			this.m_RunningText[(int)runningTextIndex].m_BeginTime = MP.ReadLong(-1);
			this.m_RunningText[(int)runningTextIndex].m_EndTime = MP.ReadLong(-1);
			this.m_RunningText[(int)runningTextIndex].m_TimeInterval = MP.ReadUInt(-1);
			MP.ReadStringPlus(1025, this.m_RunningText[(int)runningTextIndex].m_Message, -1);
			this.m_RunningTextIndex += 1;
			if (this.m_RunningTextIndex >= 5)
			{
				this.m_RunningTextIndex = 0;
			}
		}
		else if (b == 2)
		{
			byte systemInChatIndex = this.m_SystemInChatIndex;
			this.m_SystemInChat[(int)systemInChatIndex].m_BeginTime = MP.ReadLong(-1);
			this.m_SystemInChat[(int)systemInChatIndex].m_EndTime = MP.ReadLong(-1);
			this.m_SystemInChat[(int)systemInChatIndex].m_TimeInterval = MP.ReadUInt(-1);
			MP.ReadStringPlus(1025, this.m_SystemInChat[(int)systemInChatIndex].m_Message, -1);
			ActivityManager.Instance.TransToLocalTime(this.m_SystemInChat[(int)systemInChatIndex].m_Message);
			this.m_SystemInChatIndex += 1;
			if (this.m_SystemInChatIndex >= 5)
			{
				this.m_SystemInChatIndex = 0;
			}
		}
	}

	// Token: 0x0600067F RID: 1663 RVA: 0x00093390 File Offset: 0x00091590
	private void CheckBackMessage()
	{
		long serverTime = DataManager.Instance.ServerTime;
		if (this.m_BackMGBeginTime > 0L && serverTime >= this.m_BackMGBeginTime)
		{
			if ((serverTime - this.m_BackMGBeginTime) % (long)((ulong)this.m_BackMGDeltaTime) == 0L || this.m_BackMGWaitOpen)
			{
				this.LoadBackMessageBox();
			}
			if (this.m_BackMGEndTime < serverTime)
			{
				this.m_BackMGBeginTime = 0L;
				this.m_BackMGEndTime = 0L;
				this.m_BackMGDeltaTime = 0u;
				this.m_BackMGWaitOpen = false;
			}
		}
		for (int i = 0; i < 5; i++)
		{
			if (this.m_SystemInChat[i].m_BeginTime > 0L && serverTime >= this.m_SystemInChat[i].m_BeginTime)
			{
				if ((serverTime - this.m_SystemInChat[i].m_BeginTime) % (long)((ulong)this.m_SystemInChat[i].m_TimeInterval) == 0L)
				{
					DataManager.Instance.AddSystemMessage(this.m_SystemInChat[i].m_Message, 4, -1L);
				}
				if (this.m_SystemInChat[i].m_EndTime < serverTime)
				{
					this.m_SystemInChat[i].m_BeginTime = 0L;
					this.m_SystemInChat[i].m_EndTime = 0L;
					this.m_SystemInChat[i].m_TimeInterval = 0u;
				}
			}
			if (this.m_RunningText[i].m_BeginTime > 0L && serverTime >= this.m_RunningText[i].m_BeginTime)
			{
				if ((serverTime - this.m_RunningText[i].m_BeginTime) % (long)((ulong)this.m_RunningText[i].m_TimeInterval) == 0L)
				{
					this.SetRunningText(this.m_RunningText[i].m_Message);
				}
				if (this.m_RunningText[i].m_EndTime < serverTime)
				{
					this.m_RunningText[i].m_BeginTime = 0L;
					this.m_RunningText[i].m_EndTime = 0L;
					this.m_RunningText[i].m_TimeInterval = 0u;
				}
			}
		}
	}

	// Token: 0x06000680 RID: 1664 RVA: 0x000935AC File Offset: 0x000917AC
	private void LoadBackMessageBox()
	{
		if (this.mUIQueueLock != 0)
		{
			this.m_BackMGWaitOpen = true;
			return;
		}
		this.m_BackMGWaitOpen = false;
		if (this.m_BackMGGO == null)
		{
			AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UIBackMessage", out this.m_BackMGAssetBundleKey, false);
			if (assetBundle == null)
			{
				return;
			}
			this.m_BackMGGO = (GameObject)UnityEngine.Object.Instantiate(assetBundle.mainAsset);
			if (this.m_BackMGGO == null)
			{
				AssetManager.UnloadAssetBundle(this.m_BackMGAssetBundleKey, true);
				return;
			}
		}
		Transform transform = this.m_BackMGGO.transform;
		UIText component = transform.GetChild(1).GetComponent<UIText>();
		component.font = this.m_TTFFont;
		component.text = this.m_BackMGTitle.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
		component.font = this.m_TTFFont;
		component.text = this.m_BackMGMessage.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component.cachedTextGeneratorForLayout.Invalidate();
		RectTransform component2 = transform.GetChild(2).GetChild(0).GetComponent<RectTransform>();
		component2.sizeDelta = new Vector2(component2.sizeDelta.x, component.preferredHeight + 10f);
		transform.GetChild(3).gameObject.SetActive(false);
		transform.GetChild(4).GetComponent<UIButton>().m_Handler = this;
		transform.GetChild(4).GetComponent<UIButton>().m_BtnID1 = 13;
		component = transform.GetChild(4).GetChild(0).GetComponent<UIText>();
		component.font = this.m_TTFFont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(7077u);
		this.m_BackMGGO.transform.SetParent(this.m_MessageBoxLayer, false);
		this.m_BackMGGO.transform.SetAsLastSibling();
	}

	// Token: 0x06000681 RID: 1665 RVA: 0x000937A0 File Offset: 0x000919A0
	private void ReleaseBackMessageBox()
	{
		if (this.m_BackMGAssetBundleKey != 0)
		{
			UnityEngine.Object.Destroy(this.m_BackMGGO);
			AssetManager.UnloadAssetBundle(this.m_BackMGAssetBundleKey, true);
			this.m_BackMGGO = null;
			this.m_BackMGAssetBundleKey = 0;
		}
	}

	// Token: 0x06000682 RID: 1666 RVA: 0x000937E0 File Offset: 0x000919E0
	public void OpenLoadingTalk()
	{
		this.LoadingTalkTable = new CExternalTableWithWordKey<LoadingTalk>();
		if (this.LoadingTalkTable == null)
		{
			return;
		}
		this.LoadingTalkTable.LoadTable("LoadingTalk");
		DataManager.Instance.UnloadTableAB();
		int num = 0;
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UILoadingTalk", out num, false);
		if (assetBundle == null)
		{
			return;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(assetBundle.mainAsset);
		if (gameObject == null)
		{
			AssetManager.UnloadAssetBundle(num, true);
			return;
		}
		gameObject.transform.SetParent(this.m_WindowsTransform, false);
		this.LTWin = (GUIWindow)gameObject.AddComponent("UILoadingTalk");
		this.LTWin.m_AssetBundle = assetBundle;
		this.LTWin.m_AssetBundleKey = num;
		this.LTWin.OnOpen(0, 0);
	}

	// Token: 0x06000683 RID: 1667 RVA: 0x000938B0 File Offset: 0x00091AB0
	public void CloseLoadingTalk()
	{
		if (this.LTWin != null)
		{
			this.LTWin.OnClose();
			AssetManager.UnloadAssetBundle(this.LTWin.m_AssetBundleKey, true);
			this.LTWin.m_AssetBundle = null;
			this.LTWin.m_AssetBundleKey = 0;
			UnityEngine.Object.Destroy(this.LTWin.gameObject);
			this.LTWin = null;
			this.LoadingTalkTable = null;
			GC.Collect();
		}
	}

	// Token: 0x06000684 RID: 1668 RVA: 0x00093928 File Offset: 0x00091B28
	public void OpenLoadingTalk_TBox(int arg1, int arg2)
	{
		int num = 0;
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UITBWindow", out num, false);
		if (assetBundle == null)
		{
			return;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(assetBundle.Load("UITreasureBox"));
		if (gameObject == null)
		{
			AssetManager.UnloadAssetBundle(num, true);
			return;
		}
		gameObject.transform.SetParent(this.m_WindowsTransform, false);
		this.TBoxWin = (GUIWindow)gameObject.AddComponent("UITreasureBox");
		this.TBoxWin.m_AssetBundle = assetBundle;
		this.TBoxWin.m_AssetBundleKey = num;
		this.TBoxWin.OnOpen(arg1, arg2);
	}

	// Token: 0x06000685 RID: 1669 RVA: 0x000939CC File Offset: 0x00091BCC
	public void CloseLoadingTalk_TBox()
	{
		if (this.TBoxWin != null)
		{
			this.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			AssetManager.UnloadAssetBundle(this.TBoxWin.m_AssetBundleKey, true);
			this.TBoxWin.m_AssetBundle = null;
			this.TBoxWin.m_AssetBundleKey = 0;
			UnityEngine.Object.Destroy(this.TBoxWin.gameObject);
			this.TBoxWin = null;
			GC.Collect();
		}
	}

	// Token: 0x06000686 RID: 1670 RVA: 0x00093A38 File Offset: 0x00091C38
	public void OpenPvPUI()
	{
		if (!(this.m_BattleBeginGO == null))
		{
			return;
		}
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UIBattleBegin", out this.m_BattleBeginAssetBundleKey, false);
		if (assetBundle == null)
		{
			return;
		}
		this.m_BattleBeginGO = (GameObject)UnityEngine.Object.Instantiate(assetBundle.mainAsset);
		if (this.m_BattleBeginGO == null)
		{
			AssetManager.UnloadAssetBundle(this.m_BattleBeginAssetBundleKey, true);
			return;
		}
		DataManager dataManager = DataManager.Instance;
		ArenaManager arenaManager = ArenaManager.Instance;
		Transform transform = this.m_BattleBeginGO.transform;
		Color[] array = new Color[]
		{
			new Color(0.1882f, 0.8196f, 1f),
			new Color(1f, 0.3529f, 0.4431f)
		};
		transform.SetParent(this.m_SecWindowLayer, false);
		this.m_BBCanvasGroup = transform.GetComponent<CanvasGroup>();
		this.m_BBCanvasGroup.alpha = 1f;
		Transform child = transform.GetChild(0);
		this.m_LeftRC = child.GetChild(0).GetComponent<RectTransform>();
		this.m_RightRC = child.GetChild(1).GetComponent<RectTransform>();
		if (this.bOpenOnIPhoneX)
		{
			this.m_LeftRC.anchoredPosition = new Vector2(-348f, 0f);
			this.m_RightRC.anchoredPosition = new Vector2(53f, 0f);
		}
		bool flag = (arenaManager.ArenaPlayingData.Flag & 2) > 0;
		if (!flag)
		{
			child.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
			child.GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(1);
		}
		this.m_bbText[0] = child.GetChild(2).GetComponent<UIText>();
		this.m_bbText[0].font = this.m_TTFFont;
		this.m_bbText[0].text = string.Empty;
		this.m_bbText[1] = child.GetChild(3).GetComponent<UIText>();
		this.m_bbText[1].font = this.m_TTFFont;
		this.m_bbText[1].text = string.Empty;
		this.m_bbText[2] = child.GetChild(4).GetComponent<UIText>();
		this.m_bbText[2].font = this.m_TTFFont;
		this.m_bbText[2].text = string.Empty;
		this.m_bbText[3] = child.GetChild(5).GetComponent<UIText>();
		this.m_bbText[3].font = this.m_TTFFont;
		this.m_bbText[3].text = string.Empty;
		this.m_bbCString[0] = StringManager.Instance.SpawnString(150);
		this.m_bbCString[1] = StringManager.Instance.SpawnString(150);
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			if (arenaManager.ArenaPlayingData.TopicID[i] != 0)
			{
				this.m_bbText[num].text = dataManager.mStringTable.GetStringByID(9200u + (uint)arenaManager.ArenaPlayingData.TopicID[i]);
				num++;
			}
		}
		num = 2;
		for (int j = 0; j < 2; j++)
		{
			if (arenaManager.ArenaPlayingData.TopicEffect[j].Effect != 0)
			{
				GameConstants.GetEffectValue(this.m_bbCString[j], arenaManager.ArenaPlayingData.TopicEffect[j].Effect, (uint)arenaManager.ArenaPlayingData.TopicEffect[j].Value, 10, 0f);
				this.m_bbText[num].text = this.m_bbCString[j].ToString();
				num++;
			}
		}
		byte b = 0;
		byte b2 = 0;
		ushort[] array2 = new ushort[5];
		byte[] array3 = new byte[5];
		ushort[] array4 = new ushort[5];
		byte[] array5 = new byte[5];
		for (int k = 0; k < 5; k++)
		{
			if (arenaManager.ArenaPlayingData.MyHeroData[k].ID > 0 && this.CheckHeroAstrology(arenaManager.ArenaPlayingData.MyHeroData[k].ID))
			{
				array2[(int)b] = arenaManager.ArenaPlayingData.MyHeroData[k].ID;
				array3[(int)b] = arenaManager.ArenaPlayingData.MyHeroData[k].Star;
				b += 1;
			}
			if (arenaManager.ArenaPlayingData.EnemyHeroData[k].ID > 0 && this.CheckHeroAstrology(arenaManager.ArenaPlayingData.EnemyHeroData[k].ID))
			{
				array4[(int)b2] = arenaManager.ArenaPlayingData.EnemyHeroData[k].ID;
				array5[(int)b2] = arenaManager.ArenaPlayingData.EnemyHeroData[k].Star;
				b2 += 1;
			}
		}
		int num2 = (!flag) ? 1 : 0;
		Transform child2 = transform.GetChild(0).GetChild(num2);
		for (byte b3 = 0; b3 < b; b3 += 1)
		{
			child = child2.GetChild((int)b3);
			this.InitianHeroItemImg(child.GetChild(0), eHeroOrItem.Hero, array2[(int)b3], array3[(int)b3], 0, 0, true, true, true, false);
			child.gameObject.SetActive(true);
			if (b < 5)
			{
				child2.GetChild((int)b3).GetComponent<RectTransform>().anchoredPosition = this.GetPvPIconPos((byte)num2, b, b3);
			}
			child.GetChild(1).gameObject.SetActive(true);
		}
		this.m_bbText[4] = child2.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.m_bbText[4].font = this.m_TTFFont;
		this.m_bbText[4].text = dataManager.mStringTable.GetStringByID(8229u);
		this.m_bbText[4].color = array[0];
		num2 = ((!flag) ? 0 : 1);
		child2 = transform.GetChild(0).GetChild(num2);
		for (byte b4 = 0; b4 < b2; b4 += 1)
		{
			child = child2.GetChild((int)b4);
			this.InitianHeroItemImg(child.GetChild(0), eHeroOrItem.Hero, array4[(int)b4], array5[(int)b4], 0, 0, true, true, true, false);
			child.gameObject.SetActive(true);
			if (b2 < 5)
			{
				child2.GetChild((int)b4).GetComponent<RectTransform>().anchoredPosition = this.GetPvPIconPos((byte)num2, b2, b4);
			}
			child.GetChild(1).gameObject.SetActive(true);
		}
		this.m_bbCString[2] = StringManager.Instance.SpawnString(150);
		this.m_bbText[5] = child2.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.m_bbText[5].font = this.m_TTFFont;
		this.m_bbText[5].color = array[1];
		if (arenaManager.ArenaPlayingData.EnemyName.Length > 0)
		{
			if (arenaManager.ArenaPlayingData.EnemyAllianceTag.Length > 0)
			{
				this.m_bbCString[2].StringToFormat(arenaManager.ArenaPlayingData.EnemyAllianceTag);
				this.m_bbCString[2].AppendFormat("[{0}]");
			}
			this.m_bbCString[2].Append(arenaManager.ArenaPlayingData.EnemyName);
		}
		this.m_bbText[5].text = this.m_bbCString[2].ToString();
		if (this.IsArabic)
		{
			UIText component = transform.GetChild(0).GetChild(1).GetChild(5).GetChild(0).GetComponent<UIText>();
			component.rectTransform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
			component.alignment = TextAnchor.MiddleLeft;
		}
		this.m_BBStep = GUIManager.eBBSetp.eMax;
		this.ShowUILock(EUILock.Normal);
	}

	// Token: 0x06000687 RID: 1671 RVA: 0x00094238 File Offset: 0x00092438
	public void ClosePvPUI()
	{
		if (this.m_BattleBeginAssetBundleKey != 0)
		{
			this.m_BBStep = GUIManager.eBBSetp.eMax;
			this.m_BBDeltaTime = 0f;
			this.m_LeftRC = null;
			this.m_RightRC = null;
			this.m_BBCanvasGroup = null;
			for (int i = 0; i < this.m_bbText.Length; i++)
			{
				this.m_bbText[i] = null;
			}
			for (int j = 0; j < this.m_bbCString.Length; j++)
			{
				StringManager.Instance.DeSpawnString(this.m_bbCString[j]);
			}
			UnityEngine.Object.Destroy(this.m_BattleBeginGO);
			AssetManager.UnloadAssetBundle(this.m_BattleBeginAssetBundleKey, true);
			this.m_BattleBeginGO = null;
			this.m_BattleBeginAssetBundleKey = 0;
			this.HideUILock(EUILock.Normal);
			DataManager.msgBuffer[0] = 131;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x06000688 RID: 1672 RVA: 0x0009430C File Offset: 0x0009250C
	public void BeginPvPOpening()
	{
		this.m_BBStep = GUIManager.eBBSetp.eMoveIn;
	}

	// Token: 0x06000689 RID: 1673 RVA: 0x00094318 File Offset: 0x00092518
	private void UpDatePvPUI()
	{
		if (this.m_BattleBeginGO == null || this.m_BBStep == GUIManager.eBBSetp.eMax)
		{
			return;
		}
		this.m_BBDeltaTime += Time.smoothDeltaTime;
		if (this.m_BBStep == GUIManager.eBBSetp.eMoveIn)
		{
			if (this.m_BBDeltaTime <= 0.1f)
			{
				this.m_LeftRC.anchoredPosition = new Vector2(Mathf.Lerp(-295f, 0f, this.m_BBDeltaTime / 0.1f), 0f);
				this.m_RightRC.anchoredPosition = new Vector2(Mathf.Lerp(0f, -295f, this.m_BBDeltaTime / 0.1f), 0f);
			}
			else
			{
				this.m_BBStep = GUIManager.eBBSetp.eWait;
				this.m_BBDeltaTime = 0f;
				this.m_LeftRC.anchoredPosition = new Vector2(0f, 0f);
				this.m_RightRC.anchoredPosition = new Vector2(-295f, 0f);
				AudioManager.Instance.PlayUISFX(UIKind.HeroSkill);
			}
		}
		else if (this.m_BBStep == GUIManager.eBBSetp.eWait)
		{
			if (this.m_BBDeltaTime > 1f)
			{
				this.m_BBStep = GUIManager.eBBSetp.eFadeOut;
				this.m_BBDeltaTime = 0f;
			}
		}
		else if (this.m_BBStep == GUIManager.eBBSetp.eFadeOut)
		{
			if (this.m_BBDeltaTime <= 1f)
			{
				this.m_BBCanvasGroup.alpha = Mathf.Lerp(1f, 0f, this.m_BBDeltaTime / 1f);
			}
			else
			{
				this.ClosePvPUI();
			}
		}
	}

	// Token: 0x0600068A RID: 1674 RVA: 0x000944B0 File Offset: 0x000926B0
	private float easeOutBounce(float start, float end, float value)
	{
		value /= 1f;
		end -= start;
		if (value < 0.363636374f)
		{
			return end * (7.5625f * value * value) + start;
		}
		if (value < 0.727272749f)
		{
			value -= 0.545454562f;
			return end * (7.5625f * value * value + 0.75f) + start;
		}
		if ((double)value < 0.90909090909090906)
		{
			value -= 0.8181818f;
			return end * (7.5625f * value * value + 0.9375f) + start;
		}
		value -= 0.954545438f;
		return end * (7.5625f * value * value + 0.984375f) + start;
	}

	// Token: 0x0600068B RID: 1675 RVA: 0x00094558 File Offset: 0x00092758
	private Vector2 GetPvPIconPos(byte side, byte count, byte Index)
	{
		Vector2 result = default(Vector2);
		if (side == 0)
		{
			if (count == 4)
			{
				switch (Index)
				{
				case 0:
					result.x = 50f;
					result.y = -20f;
					break;
				case 1:
					result.x = 129f;
					result.y = -20f;
					break;
				case 2:
					result.x = 50f;
					result.y = -99f;
					break;
				case 3:
					result.x = 129f;
					result.y = -99f;
					break;
				}
			}
			else if (count == 3)
			{
				switch (Index)
				{
				case 0:
					result.x = 89f;
					result.y = -20f;
					break;
				case 1:
					result.x = 50f;
					result.y = -99f;
					break;
				case 2:
					result.x = 129f;
					result.y = -99f;
					break;
				}
			}
			else if (count == 2)
			{
				if (Index != 0)
				{
					if (Index == 1)
					{
						result.x = 129f;
						result.y = -60f;
					}
				}
				else
				{
					result.x = 50f;
					result.y = -60f;
				}
			}
			else if (count == 1)
			{
				result.x = 90f;
				result.y = -60f;
			}
		}
		else if (count == 4)
		{
			switch (Index)
			{
			case 0:
				result.x = 200f;
				result.y = -20f;
				break;
			case 1:
				result.x = 121f;
				result.y = -20f;
				break;
			case 2:
				result.x = 200f;
				result.y = -99f;
				break;
			case 3:
				result.x = 121f;
				result.y = -99f;
				break;
			}
		}
		else if (count == 3)
		{
			switch (Index)
			{
			case 0:
				result.x = 160f;
				result.y = -20f;
				break;
			case 1:
				result.x = 200f;
				result.y = -99f;
				break;
			case 2:
				result.x = 121f;
				result.y = -99f;
				break;
			}
		}
		else if (count == 2)
		{
			if (Index != 0)
			{
				if (Index == 1)
				{
					result.x = 121f;
					result.y = -60f;
				}
			}
			else
			{
				result.x = 200f;
				result.y = -60f;
			}
		}
		else if (count == 1)
		{
			result.x = 160f;
			result.y = -60f;
		}
		return result;
	}

	// Token: 0x0600068C RID: 1676 RVA: 0x000948A0 File Offset: 0x00092AA0
	private bool CheckHeroAstrology(ushort HeroID)
	{
		ArenaManager arenaManager = ArenaManager.Instance;
		ArenaHeroTopic recordByKey = DataManager.Instance.ArenaHeroTopicData.GetRecordByKey(HeroID);
		return (arenaManager.ArenaPlayingData.TopicID[0] != 0 && (recordByKey.Value >> (int)(arenaManager.ArenaPlayingData.TopicID[0] - 1) & 1u) == 1u) || (arenaManager.ArenaPlayingData.TopicID[1] != 0 && (recordByKey.Value >> (int)(arenaManager.ArenaPlayingData.TopicID[1] - 1) & 1u) == 1u);
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x00094934 File Offset: 0x00092B34
	public void Recv_WONDER_INIT_NOTICE(MessagePacket MP)
	{
		this.bShowWonder = false;
		this.WonderCountTime.BeginTime = MP.ReadLong(-1);
		this.WonderCountTime.RequireTime = MP.ReadUInt(-1);
		if (MP.ReadByte(-1) == 1 && (this.NowBeginTime != this.WonderCountTime.BeginTime || DataManager.Instance.ServerTime - this.ShowRunningTime >= 1200L))
		{
			this.NowBeginTime = this.WonderCountTime.BeginTime;
			this.ShowRunningTime = DataManager.Instance.ServerTime;
			if (!ActivityManager.Instance.IsInKvK(0, false))
			{
				CString cstring = StringManager.Instance.SpawnString(1024);
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(9311u));
				this.WonderCountStr.Add(cstring);
				this.SetRunningText(cstring);
			}
		}
		this.UpDateWonderCountTime();
	}

	// Token: 0x0600068E RID: 1678 RVA: 0x00094A20 File Offset: 0x00092C20
	public void Recv_WONDER_TAKEOVER_NOTICE(MessagePacket MP)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		CString cstring3 = StringManager.Instance.StaticString1024();
		CString cstring4 = StringManager.Instance.SpawnString(1024);
		byte wonderID = MP.ReadByte(-1);
		MP.ReadStringPlus(20, cstring, -1);
		MP.ReadStringPlus(13, cstring2, -1);
		MP.ReadStringPlus(3, cstring3, -1);
		cstring4.StringToFormat(cstring3);
		cstring4.StringToFormat(cstring);
		cstring4.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)wonderID, 0));
		cstring4.StringToFormat(cstring2);
		cstring4.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9379u));
		this.WonderCountStr.Add(cstring4);
		this.SetRunningText(cstring4);
	}

	// Token: 0x0600068F RID: 1679 RVA: 0x00094AE0 File Offset: 0x00092CE0
	public void Recv_WONDER_PEACE_NOTICE(MessagePacket MP)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		CString cstring3 = StringManager.Instance.SpawnString(1024);
		byte wonderID = MP.ReadByte(-1);
		MP.ReadStringPlus(20, cstring, -1);
		this.WonderCountTime.BeginTime = MP.ReadLong(-1);
		this.WonderCountTime.RequireTime = MP.ReadUInt(-1);
		MP.ReadStringPlus(3, cstring2, -1);
		cstring3.StringToFormat(cstring2);
		cstring3.StringToFormat(cstring);
		cstring3.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)wonderID, 0));
		cstring3.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9380u));
		this.WonderCountStr.Add(cstring3);
		this.SetRunningText(cstring3);
	}

	// Token: 0x06000690 RID: 1680 RVA: 0x00094BA4 File Offset: 0x00092DA4
	public void Recv_WONDER_PEACE_OVER(MessagePacket MP)
	{
		this.bShowWonder = false;
		this.WonderCountTime.BeginTime = 0L;
		this.WonderCountTime.RequireTime = 0u;
		if (!ActivityManager.Instance.IsInKvK(0, false))
		{
			CString cstring = StringManager.Instance.SpawnString(1024);
			cstring.Append(DataManager.Instance.mStringTable.GetStringByID(9311u));
			this.WonderCountStr.Add(cstring);
			this.SetRunningText(cstring);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_DevelopmentDetails, 1, 0);
	}

	// Token: 0x06000691 RID: 1681 RVA: 0x00094C30 File Offset: 0x00092E30
	private void UpDateWonderCountTime()
	{
		if (!this.bShowWonder && this.WonderCountTime.BeginTime != 0L)
		{
			long num = this.WonderCountTime.BeginTime + (long)((ulong)this.WonderCountTime.RequireTime);
			if (num - DataManager.Instance.ServerTime == 600L)
			{
				this.bShowWonder = true;
				CString cstring = StringManager.Instance.SpawnString(1024);
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(9310u));
				this.WonderCountStr.Add(cstring);
				this.SetRunningText(cstring);
			}
		}
	}

	// Token: 0x06000692 RID: 1682 RVA: 0x00094CCC File Offset: 0x00092ECC
	public void ClearWonderStr()
	{
		for (int i = 0; i < this.WonderCountStr.Count; i++)
		{
			StringManager.Instance.DeSpawnString(this.WonderCountStr[i]);
		}
		this.WonderCountStr.Clear();
	}

	// Token: 0x06000693 RID: 1683 RVA: 0x00094D18 File Offset: 0x00092F18
	public void Recv_WORLDWONDER_OPEN(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			if (DataManager.Instance.ServerTime - this.KOW_ShowRunningTime >= 1200L)
			{
				this.KOW_ShowRunningTime = DataManager.Instance.ServerTime;
				CString cstring = StringManager.Instance.SpawnString(1024);
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(11016u));
				this.KOWCountStr.Add(cstring);
				this.SetRunningText(cstring);
			}
		}
		else if (DataManager.Instance.ServerTime - this.NW_ShowRunningTime >= 1200L)
		{
			this.NW_ShowRunningTime = DataManager.Instance.ServerTime;
			CString cstring2 = StringManager.Instance.SpawnString(1024);
			cstring2.Append(DataManager.Instance.mStringTable.GetStringByID(11098u));
			this.KOWCountStr.Add(cstring2);
			this.SetRunningText(cstring2);
		}
	}

	// Token: 0x06000694 RID: 1684 RVA: 0x00094E0C File Offset: 0x0009300C
	public void Recv_WORLDWONDER_TAKEOVER(MessagePacket MP)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		CString cstring3 = StringManager.Instance.SpawnString(1024);
		ushort num = MP.ReadUShort(-1);
		MP.ReadStringPlus(13, cstring, -1);
		MP.ReadStringPlus(3, cstring2, -1);
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			cstring3.IntToFormat((long)num, 1, false);
			cstring3.StringToFormat(cstring2);
			cstring3.StringToFormat(cstring);
			cstring3.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9990u));
			cstring3.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11017u));
		}
		else
		{
			cstring3.IntToFormat((long)num, 1, false);
			cstring3.StringToFormat(cstring2);
			cstring3.StringToFormat(cstring);
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				cstring3.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)b, DataManager.MapDataController.OtherKingdomData.kingdomID));
			}
			else
			{
				cstring3.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)b, DataManager.MapDataController.FocusKingdomID));
			}
			cstring3.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11017u));
		}
		this.KOWCountStr.Add(cstring3);
		this.SetRunningText(cstring3);
	}

	// Token: 0x06000695 RID: 1685 RVA: 0x00094F6C File Offset: 0x0009316C
	public void Recv_WORLDWONDER_CLOSE(MessagePacket MP)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		CString cstring3 = StringManager.Instance.SpawnString(1024);
		ushort num = MP.ReadUShort(-1);
		MP.ReadStringPlus(13, cstring, -1);
		MP.ReadStringPlus(3, cstring2, -1);
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			cstring3.IntToFormat((long)num, 1, false);
			cstring3.StringToFormat(cstring2);
			cstring3.StringToFormat(cstring);
			cstring3.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11018u));
		}
		else
		{
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				cstring3.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)b, DataManager.MapDataController.OtherKingdomData.kingdomID));
			}
			else
			{
				cstring3.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)b, DataManager.MapDataController.FocusKingdomID));
			}
			cstring3.IntToFormat((long)num, 1, false);
			cstring3.StringToFormat(cstring2);
			cstring3.StringToFormat(cstring);
			cstring3.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11100u));
		}
		this.KOWCountStr.Add(cstring3);
		this.SetRunningText(cstring3);
	}

	// Token: 0x06000696 RID: 1686 RVA: 0x000950B0 File Offset: 0x000932B0
	public void ClearKOWStr()
	{
		for (int i = 0; i < this.KOWCountStr.Count; i++)
		{
			StringManager.Instance.DeSpawnString(this.KOWCountStr[i]);
		}
		this.KOWCountStr.Clear();
	}

	// Token: 0x06000697 RID: 1687 RVA: 0x000950FC File Offset: 0x000932FC
	public void SetbNeedTranslate(TalkDataType tmpData)
	{
		if (tmpData == null)
		{
			return;
		}
		if (tmpData.FuncKind == 109 || !this.CheckNeedTranslate(tmpData.MainText))
		{
			tmpData.TranslateState = eTranslateState.NoNeedTranslate;
		}
	}

	// Token: 0x06000698 RID: 1688 RVA: 0x00095138 File Offset: 0x00093338
	public bool TransLatebyIndex(TalkDataType tmpData)
	{
		if (tmpData == null)
		{
			return false;
		}
		if (this.bWaitTranslate)
		{
			this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8459u), 255, true);
			return false;
		}
		this.TranslateData = tmpData;
		this.TranslateID = this.TranslateData.TalkID;
		this.TranslateData.OriginalText.SetLength(this.TranslateData.OriginalText.Length);
		IGGSDKPlugin.Translate(this.TranslateData.OriginalText.ToString());
		this.TranslateData.OriginalText.SetLength(this.TranslateData.OriginalText.MaxLength);
		this.TranslateData.TranslateState = eTranslateState.Translation;
		this.bWaitTranslate = true;
		return true;
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x000951FC File Offset: 0x000933FC
	public void TranslateBatch(TalkDataType tmpData)
	{
		if (!this.bAutoTranslate || tmpData == null || this.bWaitTranslate)
		{
			return;
		}
		DataManager dataManager = DataManager.Instance;
		if (tmpData.TalkKind == 0 && tmpData.PlayID != dataManager.RoleAttr.UserId)
		{
			if (this.CheckNeedTranslate(tmpData.MainText))
			{
				this.TranslateStrListID.Add(tmpData.TalkID);
				this.TranslateDataList.Add(tmpData);
			}
			else
			{
				tmpData.TranslateState = eTranslateState.NoNeedTranslate;
			}
		}
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x00095288 File Offset: 0x00093488
	public void SendTranslateBatch()
	{
		if (!this.bAutoTranslate || this.bWaitTranslate)
		{
			return;
		}
		if (this.TranslateStrListID.Count > 0)
		{
			this.bWaitTranslate = true;
			this.TranslateCStrList.Clear();
			for (int i = 0; i < this.TranslateDataList.Count; i++)
			{
				this.TranslateCStrList.Add(this.TranslateDataList[i].OriginalText);
				this.TranslateDataList[i].TranslateState = eTranslateState.Translation;
			}
			IGGGameSDK.Instance.TranslateBatchByList(this.TranslateCStrList);
		}
		else
		{
			this.TranslateStrListID.Clear();
			this.TranslateDataList.Clear();
		}
	}

	// Token: 0x0600069B RID: 1691 RVA: 0x00095344 File Offset: 0x00093544
	public void BackTranslate()
	{
		this.bBackTranslate = false;
		this.bWaitTranslate = false;
		if (this.TranslateData == null || this.TranslateID != this.TranslateData.TalkID)
		{
			return;
		}
		this.TranslateData.TranslateComplete(this.GetTranslateSplit(this.TranslateStr, this.TranslateData));
		this.TranslateData.TotalHeightT = 0f;
		this.TranslateData.TotalHeight = 0f;
		this.CheckText(this.TranslateData);
		this.UpdateUI(EGUIWindow.UI_Chat, 10, 0);
		this.UpdateChatBox(0, 0);
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x000953E0 File Offset: 0x000935E0
	public void BackTranslateBatch()
	{
		this.bBackTranslateBatch = false;
		this.bWaitTranslate = false;
		IGGGameSDK igggameSDK = IGGGameSDK.Instance;
		for (int i = 0; i < this.TranslateDataList.Count; i++)
		{
			if (this.TranslateDataList[i].TalkID == this.TranslateStrListID[i])
			{
				igggameSDK.TranslateString[i].SetLength(igggameSDK.TranslateString[i].Length);
				this.TranslateDataList[i].TranslateComplete(this.GetTranslateSplit(igggameSDK.TranslateString[i].ToString(), this.TranslateDataList[i]));
				igggameSDK.TranslateString[i].SetLength(igggameSDK.TranslateString[i].MaxLength);
				this.TranslateDataList[i].TotalHeightT = 0f;
				this.TranslateDataList[i].TotalHeight = 0f;
				this.CheckText(this.TranslateDataList[i]);
			}
		}
		this.TranslateStrListID.Clear();
		this.TranslateDataList.Clear();
		this.UpdateUI(EGUIWindow.UI_Chat, 12, 0);
		this.UpdateChatBox(0, 0);
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x0009550C File Offset: 0x0009370C
	public void BackTranslateFail()
	{
		this.bWaitTranslate = false;
		if (this.bBackTranslateFail == 1)
		{
			this.TranslateData.TranslateState = eTranslateState.TranslateFail;
			this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9077u), 255, true);
			this.TranslateData = null;
			this.TranslateID = -1L;
		}
		else if (this.bBackTranslateFail == 2)
		{
			for (int i = 0; i < this.TranslateDataList.Count; i++)
			{
				if (this.TranslateDataList[i] != null)
				{
					this.TranslateDataList[i].TranslateState = eTranslateState.TranslateFail;
					this.TranslateDataList[i].TotalHeightT = 0f;
					this.TranslateDataList[i].TotalHeight = 0f;
				}
			}
			this.TranslateStrListID.Clear();
			this.TranslateDataList.Clear();
		}
		this.UpdateUI(EGUIWindow.UI_Chat, 12, 0);
		this.bBackTranslateFail = 0;
	}

	// Token: 0x0600069E RID: 1694 RVA: 0x0009560C File Offset: 0x0009380C
	private void CheckText(TalkDataType tmpTalk)
	{
		CString translateText = tmpTalk.TranslateText;
		int num = -1;
		int num2 = -1;
		int length = translateText.Length;
		int num3 = 0;
		while (num3 < length && (num == -1 || num2 == -1))
		{
			char c = translateText[num3];
			num3++;
			if (num3 == length)
			{
				break;
			}
			if (translateText[num3] == ':' || translateText[num3] == '：')
			{
				int num4 = num3;
				if (c == 'K')
				{
					num = num3 - 1;
					num3++;
					while (num3 < length && (c = translateText[num3]) == ' ')
					{
						num3++;
					}
					if (num3 >= length)
					{
						break;
					}
					if (c >= '0' && c <= '9')
					{
						int num5 = 0;
						do
						{
							num5 = num5 * 10 + (int)c - 48;
							num3++;
							if (num3 == length)
							{
								break;
							}
							c = translateText[num3];
						}
						while (c >= '0' && c <= '9' && num5 < 65535);
						IL_114:
						num3++;
						if (num3 >= length)
						{
							break;
						}
						if (c == ' ')
						{
							c = translateText[num3];
							num3++;
							if (num3 >= length)
							{
								break;
							}
							if (c == 'X' && (translateText[num3] == ':' || translateText[num3] == '：'))
							{
								num3++;
								while (num3 < length && (c = translateText[num3]) == ' ')
								{
									num3++;
								}
								if (num3 >= length)
								{
									break;
								}
								if (c >= '0' && c <= '9')
								{
									int num6 = 0;
									do
									{
										num6 = num6 * 10 + (int)c - 48;
										num3++;
										if (num3 == length)
										{
											break;
										}
										c = translateText[num3];
									}
									while (c >= '0' && c <= '9' && num6 < 65535);
									IL_216:
									num3++;
									if (num3 >= length)
									{
										break;
									}
									if (c != ' ')
									{
										continue;
									}
									c = translateText[num3];
									num3++;
									if (num3 >= length)
									{
										break;
									}
									if (c != 'Y' || (translateText[num3] != ':' && translateText[num3] != '：'))
									{
										continue;
									}
									num3++;
									while (num3 < length && (c = translateText[num3]) == ' ')
									{
										num3++;
									}
									if (num3 >= length)
									{
										break;
									}
									if (c < '0' || c > '9')
									{
										continue;
									}
									int num7 = 0;
									do
									{
										num7 = num7 * 10 + (int)c - 48;
										num3++;
										if (num3 == length)
										{
											break;
										}
										c = translateText[num3];
									}
									while (c >= '0' && c <= '9' && num7 < 65535);
									IL_318:
									num2 = num3;
									continue;
									goto IL_318;
									goto IL_216;
								}
							}
						}
						continue;
						goto IL_114;
					}
				}
				else if (c >= '0' && c <= '9')
				{
					num3--;
					do
					{
						num3--;
						if (num3 < 0)
						{
							break;
						}
						c = translateText[num3];
					}
					while (c >= '0' && c <= '9');
					IL_371:
					num3++;
					c = translateText[num3];
					num = num3;
					int num5 = 0;
					byte b = 1;
					do
					{
						num5 = num5 * 10 + (int)c - 48;
						num3++;
						if (num3 == length)
						{
							break;
						}
						c = translateText[num3];
					}
					while (c >= '0' && c <= '9' && num5 < 65535);
					IL_3D2:
					if (c != ':' && c != '：')
					{
						num = -1;
						num3 = num4;
						continue;
					}
					num3++;
					while (num3 < length && (c = translateText[num3]) == ' ')
					{
						num3++;
					}
					if (num3 >= length)
					{
						break;
					}
					if (c >= '0' && c <= '9')
					{
						int num6 = 0;
						b += 1;
						do
						{
							num6 = num6 * 10 + (int)c - 48;
							num3++;
							if (num3 == length)
							{
								break;
							}
							c = translateText[num3];
						}
						while (c >= '0' && c <= '9' && num6 < 65535);
						IL_484:
						if (c == ':' || c == '：')
						{
							num3++;
							while (num3 < length && (c = translateText[num3]) == ' ')
							{
								num3++;
							}
							if (num3 >= length)
							{
								break;
							}
							if (c >= '0' && c <= '9')
							{
								int num7 = 0;
								b += 1;
								do
								{
									num7 = num7 * 10 + (int)c - 48;
									num3++;
									if (num3 == length)
									{
										break;
									}
									c = translateText[num3];
								}
								while (c >= '0' && c <= '9' && num7 < 65535);
							}
						}
						if (b > 1)
						{
							num2 = num3;
							continue;
						}
						continue;
						goto IL_484;
					}
					continue;
					goto IL_3D2;
					goto IL_371;
				}
			}
		}
		if (num != -1 && num2 != -1 && tmpTalk.LocX < 512 && tmpTalk.LocY < 1024)
		{
			tmpTalk.bHasLocT = true;
			tmpTalk.BeginIndexT = num;
			tmpTalk.EndIndexT = num2;
			translateText.Insert(num, DataManager.Instance.ColorL, -1);
			translateText.Insert(num2 + DataManager.Instance.ColorL.Length, DataManager.Instance.ColorR, -1);
		}
	}

	// Token: 0x0600069F RID: 1695 RVA: 0x00095BF4 File Offset: 0x00093DF4
	public ushort GetTranslateSplit(string s, TalkDataType TData)
	{
		if (s == null)
		{
			return 0;
		}
		char c = '\u007f';
		CString cstring = StringManager.Instance.StaticString1024();
		int i;
		for (i = 0; i < s.Length; i++)
		{
			if (s[i] == c)
			{
				break;
			}
			cstring.Append(s[i]);
		}
		cstring.SetLength(cstring.Length);
		ushort translateLanguageStringId = (ushort)IGGGameSDK.Instance.GetTranslateLanguageStringId(cstring.ToString());
		cstring.SetLength(cstring.MaxLength);
		TData.TranslateText.Length = 0;
		TData.TranslateText.Substring(s, i + 1);
		TData.TranslateText.CheckBannedWord();
		return translateLanguageStringId;
	}

	// Token: 0x060006A0 RID: 1696 RVA: 0x00095CA0 File Offset: 0x00093EA0
	public void MB_SetbNeedTranslate(MessageBoard tmpData)
	{
		if (tmpData == null)
		{
			return;
		}
		if (!this.CheckNeedTranslate(tmpData.MessageStr))
		{
			tmpData.TranslateState = eTranslateState.NoNeedTranslate;
		}
	}

	// Token: 0x060006A1 RID: 1697 RVA: 0x00095CC4 File Offset: 0x00093EC4
	public void MB_TranslateBatch(MessageBoard tmpData)
	{
		if (!this.bAutoTranslate || tmpData == null)
		{
			return;
		}
		if (!tmpData.bSelfMessage)
		{
			if (this.CheckNeedTranslate(tmpData.MessageStr))
			{
				this.MB_TranslateDataList.Add(tmpData);
				this.MB_TranslateStrListID.Add(tmpData.MessageID);
			}
			else
			{
				tmpData.TranslateState = eTranslateState.NoNeedTranslate;
			}
		}
	}

	// Token: 0x060006A2 RID: 1698 RVA: 0x00095D28 File Offset: 0x00093F28
	public void MB_SendTranslateBatch()
	{
		if (!this.bAutoTranslate)
		{
			return;
		}
		if (this.bWaitTranslate_MB)
		{
			this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8459u), 255, true);
			return;
		}
		if (this.MB_TranslateStrListID.Count > 0)
		{
			this.bWaitTranslate_MB = true;
			this.MB_TranslateCStrList.Clear();
			for (int i = 0; i < this.MB_TranslateDataList.Count; i++)
			{
				this.MB_TranslateCStrList.Add(this.MB_TranslateDataList[i].MessageStr);
				this.MB_TranslateDataList[i].TranslateState = eTranslateState.Translation;
			}
			IGGGameSDK.Instance.TranslateBatchByList_Diplomatic(this.MB_TranslateCStrList);
		}
		else
		{
			this.MB_TranslateStrListID.Clear();
			this.MB_TranslateDataList.Clear();
		}
	}

	// Token: 0x060006A3 RID: 1699 RVA: 0x00095E08 File Offset: 0x00094008
	public void MB_BackTranslateBatch()
	{
		this.bWaitTranslate_MB = false;
		this.bBackTranslateBatch_MB = false;
		IGGGameSDK igggameSDK = IGGGameSDK.Instance;
		int num = 0;
		while (num < this.MB_TranslateDataList.Count && num < igggameSDK.TranslateString_Diplomatic.Length)
		{
			if (this.MB_TranslateDataList[num].MessageID == this.MB_TranslateStrListID[num])
			{
				igggameSDK.TranslateString_Diplomatic[num].SetLength(igggameSDK.TranslateString_Diplomatic[num].Length);
				this.MB_TranslateDataList[num].TranslateComplete(this.MB_GetTranslateSplit(igggameSDK.TranslateString_Diplomatic[num].ToString(), this.MB_TranslateDataList[num]));
				igggameSDK.TranslateString_Diplomatic[num].SetLength(igggameSDK.TranslateString_Diplomatic[num].MaxLength);
				this.MB_TranslateDataList[num].TotalHeightT = 0f;
				this.MB_TranslateDataList[num].TotalHeight = 0f;
			}
			num++;
		}
		this.MB_TranslateStrListID.Clear();
		this.MB_TranslateDataList.Clear();
		this.UpdateUI(EGUIWindow.UI_MessageBoard, 4, 0);
	}

	// Token: 0x060006A4 RID: 1700 RVA: 0x00095F28 File Offset: 0x00094128
	public void MB_BackTranslateFail()
	{
		this.bWaitTranslate_MB = false;
		for (int i = 0; i < this.MB_TranslateDataList.Count; i++)
		{
			if (this.MB_TranslateDataList[i] != null)
			{
				this.MB_TranslateDataList[i].TranslateState = eTranslateState.TranslateFail;
				this.MB_TranslateDataList[i].TotalHeightT = 0f;
				this.MB_TranslateDataList[i].TotalHeight = 0f;
			}
		}
		this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9077u), 255, true);
		this.MB_TranslateStrListID.Clear();
		this.MB_TranslateDataList.Clear();
		this.bBackTranslateFail_MB = 0;
		this.UpdateUI(EGUIWindow.UI_MessageBoard, 4, 0);
	}

	// Token: 0x060006A5 RID: 1701 RVA: 0x00095FF0 File Offset: 0x000941F0
	public ushort MB_GetTranslateSplit(string s, MessageBoard TData)
	{
		if (s == null)
		{
			return 0;
		}
		char c = '\u007f';
		CString cstring = StringManager.Instance.StaticString1024();
		int i;
		for (i = 0; i < s.Length; i++)
		{
			if (s[i] == c)
			{
				break;
			}
			cstring.Append(s[i]);
		}
		cstring.SetLength(cstring.Length);
		ushort translateLanguageStringId = (ushort)IGGGameSDK.Instance.GetTranslateLanguageStringId(cstring.ToString());
		cstring.SetLength(cstring.MaxLength);
		TData.TranslateText.Length = 0;
		TData.TranslateText.Substring(s, i + 1);
		TData.TranslateText.CheckBannedWord();
		return translateLanguageStringId;
	}

	// Token: 0x060006A6 RID: 1702 RVA: 0x0009609C File Offset: 0x0009429C
	public bool CheckNeedTranslate(string tmpStr)
	{
		for (int i = 0; i < tmpStr.Length; i++)
		{
			if (tmpStr[i] == '\0')
			{
				return false;
			}
			if (tmpStr[i] != ' ' && !char.IsNumber(tmpStr[i]))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060006A7 RID: 1703 RVA: 0x000960F8 File Offset: 0x000942F8
	public bool CheckNeedTranslate(CString tmpStr)
	{
		return this.CheckNeedTranslate(tmpStr.ToString());
	}

	// Token: 0x060006A8 RID: 1704 RVA: 0x00096108 File Offset: 0x00094308
	public void Recv_BROCAST_NPC_WAR_BEGIN(MessagePacket MP)
	{
		long dataIndex = MP.ReadLong(-1);
		byte b = MP.ReadByte(-1);
		CString cstring = StringManager.Instance.StaticString1024();
		MP.ReadStringPlus(13, cstring, -1);
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring2.IntToFormat((long)b, 1, false);
		cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021u));
		CString cstring3 = StringManager.Instance.StaticString1024();
		cstring3.StringToFormat(cstring);
		cstring3.StringToFormat(cstring2);
		cstring3.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9591u));
		DataManager.Instance.AddSystemMessage(cstring3, 6, dataIndex);
		GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4904u), 15, true);
	}

	// Token: 0x060006A9 RID: 1705 RVA: 0x000961D4 File Offset: 0x000943D4
	public void Recv_NPC_RALLY_DETAIL_FAILED(MessagePacket MP)
	{
		long num = MP.ReadLong(-1);
		this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9592u), 255, true);
		if (DataManager.Instance.WarhallProtocol == 7313)
		{
			DataManager.Instance.WarhallProtocol = 0;
		}
	}

	// Token: 0x060006AA RID: 1706 RVA: 0x00096228 File Offset: 0x00094428
	public void Send_REQUEST_NPC_RALLY_DETAIL_BYID(long NPCUserID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_NPC_RALLY_DETAIL_BYID;
		messagePacket.AddSeqId();
		messagePacket.Add(NPCUserID);
		messagePacket.Send(false);
		DataManager.Instance.WarhallProtocol = (ushort)messagePacket.Protocol;
		DataManager.Instance.EmptyRallyDetail();
		Array.Clear(this.RallySaved, 0, this.RallySaved.Length);
	}

	// Token: 0x060006AB RID: 1707 RVA: 0x00096290 File Offset: 0x00094490
	public void ClearBox(int index)
	{
		if (this.BoxID[index] > 0 && this.BoxTime[index] > 0L)
		{
			this.TrueBoxRequire = 0u;
		}
		this.BoxID[index] = 0;
		this.BoxTime[index] = 0L;
		this.BoxRequire[index] = 0;
		this.BoxBShowMessage[index] = false;
	}

	// Token: 0x060006AC RID: 1708 RVA: 0x000962E8 File Offset: 0x000944E8
	public void InitialAlchemy()
	{
		for (int i = 0; i < 3; i++)
		{
			this.ClearBox(i);
		}
	}

	// Token: 0x060006AD RID: 1709 RVA: 0x00096310 File Offset: 0x00094510
	public void CheckTimeBar(bool bShowMessage = false)
	{
		int num = -1;
		for (int i = 0; i < 3; i++)
		{
			if (this.BoxID[i] > 0 && this.BoxTime[i] > 0L)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.NpcReward, false, 0L, 0u);
		}
		else
		{
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.NpcReward, true, this.BoxTime[num] - (long)((ulong)this.TrueBoxRequire), this.TrueBoxRequire);
		}
	}

	// Token: 0x060006AE RID: 1710 RVA: 0x00096394 File Offset: 0x00094594
	private void CheckNPCRewardHUD()
	{
		if (!DataManager.Instance.queueBarData[33].bActive)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < 3; i++)
		{
			if (this.BoxID[i] > 0 && this.BoxTime[i] > 0L)
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			DataManager dataManager = DataManager.Instance;
			if (!this.BoxBShowMessage[num] && this.BoxTime[num] < dataManager.ServerTime)
			{
				this.BoxBShowMessage[num] = true;
				dataManager.SetQueueBarData(EQueueBarIndex.NpcReward, true, this.BoxTime[num] - (long)((ulong)this.TrueBoxRequire), this.TrueBoxRequire);
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.StringToFormat(dataManager.mStringTable.GetStringByID((uint)dataManager.NPCPrize.GetRecordByKey(this.BoxID[num]).Element));
				cstring.AppendFormat(dataManager.mStringTable.GetStringByID(12041u));
				this.AddHUDMessage(cstring.ToString(), 30, true);
				this.BuildingData.UpdateBuildState(5, 255);
				this.UpdateUI(EGUIWindow.UIAlchemy, 6, num);
			}
		}
	}

	// Token: 0x060006AF RID: 1711 RVA: 0x000964C8 File Offset: 0x000946C8
	public uint GetRequireTime(ushort RequireTime)
	{
		float num = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_REWARD_SPEED);
		return (uint)((float)RequireTime * 60f * (1f - num / 10000f));
	}

	// Token: 0x060006B0 RID: 1712 RVA: 0x00096504 File Offset: 0x00094704
	public void Recv_NPC_REWARDSAVE(MessagePacket MP)
	{
		int num = -1;
		for (int i = 0; i < 3; i++)
		{
			this.BoxID[i] = MP.ReadUShort(-1);
			this.BoxTime[i] = MP.ReadLong(-1);
			this.BoxRequire[i] = MP.ReadUShort(-1);
			if (this.BoxID[i] > 0 && this.BoxTime[i] > 0L && this.BoxTime[i] <= DataManager.Instance.ServerTime)
			{
				this.BoxBShowMessage[i] = true;
			}
			else
			{
				this.BoxBShowMessage[i] = false;
			}
			if (this.BoxID[i] > 0 && this.BoxTime[i] > 0L)
			{
				num = i;
			}
		}
		this.TrueBoxRequire = MP.ReadUInt(-1);
		if (num != -1 && this.TrueBoxRequire == 0u)
		{
			this.TrueBoxRequire = this.GetRequireTime(this.BoxRequire[num]);
		}
		this.CheckTimeBar(false);
		this.UpdateUI(EGUIWindow.UIAlchemy, 1, 0);
		this.BuildingData.UpdateBuildState(5, 255);
	}

	// Token: 0x060006B1 RID: 1713 RVA: 0x00096614 File Offset: 0x00094814
	public void Recv_NPC_START_REWARD(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Alchemy);
		if (MP.ReadByte(-1) == 0)
		{
			byte b = MP.ReadByte(-1) - 1;
			if (b < 3)
			{
				this.BoxTime[(int)b] = MP.ReadLong(-1);
			}
			this.TrueBoxRequire = MP.ReadUInt(-1);
			this.CheckTimeBar(false);
			this.UpdateUI(EGUIWindow.UIAlchemy, 2, (int)b);
			this.BuildingData.UpdateBuildState(5, 255);
			FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_TRANSMUTATION);
		}
	}

	// Token: 0x060006B2 RID: 1714 RVA: 0x0009669C File Offset: 0x0009489C
	public void Recv_NPC_GET_REWARD(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Alchemy);
		if (MP.ReadByte(-1) == 0)
		{
			byte b = MP.ReadByte(-1) - 1;
			if (b < 3)
			{
				this.BoxRewardItemID = MP.ReadUShort(-1);
				this.BoxRewardNum = MP.ReadUShort(-1);
				this.BoxRewardItemRank = MP.ReadByte(-1);
				this.BoxRewardCrystal = MP.ReadUInt(-1);
				this.BoxRewardAlliance = MP.ReadUInt(-1);
				if (this.BoxRewardCrystal > 0u)
				{
					DataManager dataManager = DataManager.Instance;
					dataManager.RoleAttr.Diamond = dataManager.RoleAttr.Diamond + this.BoxRewardCrystal;
					GameManager.OnRefresh(NetworkNews.Refresh, null);
				}
				else if (this.BoxRewardAlliance > 0u)
				{
					DataManager dataManager2 = DataManager.Instance;
					dataManager2.RoleAlliance.Money = dataManager2.RoleAlliance.Money + this.BoxRewardAlliance;
					GameManager.OnRefresh(NetworkNews.Refresh, null);
				}
				else
				{
					ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(this.BoxRewardItemID, this.BoxRewardItemRank);
					DataManager.Instance.SetCurItemQuantity(this.BoxRewardItemID, curItemQuantity + this.BoxRewardNum, this.BoxRewardItemRank, 0L);
					GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
				}
				this.BoxRewardID = this.BoxID[(int)b];
				ushort id = DataManager.Instance.NPCPrize.GetRecordByKey(this.BoxID[(int)b]).ID;
				DataManager.MissionDataManager.CheckChanged(eMissionKind.Mark, 159 + id, 1);
				this.ClearBox((int)b);
				this.CheckTimeBar(false);
				this.UpdateUI(EGUIWindow.UIAlchemy, 3, (int)b);
				this.BuildingData.UpdateBuildState(5, 255);
			}
		}
	}

	// Token: 0x060006B3 RID: 1715 RVA: 0x0009682C File Offset: 0x00094A2C
	public void Recv_NPC_DELETE_REWARD(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Alchemy);
		if (MP.ReadByte(-1) == 0)
		{
			byte b = MP.ReadByte(-1) - 1;
			if (b < 3)
			{
				this.ClearBox((int)b);
				DataManager.Instance.Resource[4].Stock = MP.ReadUInt(-1);
				GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
				this.CheckTimeBar(false);
				this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12047u), 255, true);
				this.UpdateUI(EGUIWindow.UIAlchemy, 4, (int)b);
				this.BuildingData.UpdateBuildState(5, 255);
			}
		}
	}

	// Token: 0x060006B4 RID: 1716 RVA: 0x000968D0 File Offset: 0x00094AD0
	public void Recv_NPC_UPDATEREWARD(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1) - 1;
		if (b < 3)
		{
			this.BoxID[(int)b] = MP.ReadUShort(-1);
			this.BoxTime[(int)b] = MP.ReadLong(-1);
			this.BoxRequire[(int)b] = MP.ReadUShort(-1);
			if (this.BoxID[(int)b] > 0 && this.BoxTime[(int)b] > 0L && this.BoxTime[(int)b] <= DataManager.Instance.ServerTime)
			{
				this.BoxBShowMessage[(int)b] = true;
			}
			else
			{
				this.BoxBShowMessage[(int)b] = false;
			}
			this.CheckTimeBar(false);
			this.UpdateUI(EGUIWindow.UIAlchemy, 5, (int)b);
			this.BuildingData.UpdateBuildState(5, 255);
			NewbieManager.CheckMetallurgy();
		}
	}

	// Token: 0x060006B5 RID: 1717 RVA: 0x00096994 File Offset: 0x00094B94
	public void Send_NPC_START_REWARD(byte Index)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_NPC_START_REWARD;
		messagePacket.AddSeqId();
		messagePacket.Add(Index);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Alchemy);
	}

	// Token: 0x060006B6 RID: 1718 RVA: 0x000969DC File Offset: 0x00094BDC
	public void Send_NPC_GET_REWARD(byte Index)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_NPC_GET_REWARD;
		messagePacket.AddSeqId();
		messagePacket.Add(Index);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Alchemy);
	}

	// Token: 0x060006B7 RID: 1719 RVA: 0x00096A24 File Offset: 0x00094C24
	public void Send_NPC_DELETE_REWARD(byte Index)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_NPC_DELETE_REWARD;
		messagePacket.AddSeqId();
		messagePacket.Add(Index);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Alchemy);
	}

	// Token: 0x060006B8 RID: 1720 RVA: 0x00096A6C File Offset: 0x00094C6C
	public void LoadEmojiSelectSave()
	{
		if (this.bLoadEmojiSaveKey)
		{
			return;
		}
		this.bLoadEmojiSaveKey = true;
		this.SaveEmojiKey.Clear();
		ushort num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < 8; i++)
		{
			stringBuilder.AppendFormat("{0}_{1}", this.SaveEmojiName[i], DataManager.Instance.RoleAttr.UserId);
			this.SaveEmojiName[i] = stringBuilder.ToString();
			ushort.TryParse(PlayerPrefs.GetString(this.SaveEmojiName[i]), out num);
			if (num > 0)
			{
				this.SaveEmojiKey.Add(num);
			}
		}
		if (this.SaveEmojiKey.Count == 0)
		{
			this.EmojiNowPackageIndex = 0;
		}
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x00096B28 File Offset: 0x00094D28
	public void SaveEmojiSelectSave()
	{
		for (int i = 0; i < 8; i++)
		{
			if (i >= this.SaveEmojiKey.Count)
			{
				PlayerPrefs.SetString(this.SaveEmojiName[i], "0");
			}
			else
			{
				PlayerPrefs.SetString(this.SaveEmojiName[i], this.SaveEmojiKey[i].ToString());
			}
		}
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x00096B90 File Offset: 0x00094D90
	public byte GetMapEmojiCount(ushort PackageIndex)
	{
		if (PackageIndex == 65535)
		{
			return (byte)this.SaveEmojiKey.Count;
		}
		byte b = 0;
		if (this.MapEmojiCount == null)
		{
			this.MapEmojiCount = new Dictionary<ushort, byte>();
			int tableCount = DataManager.MapDataController.EmojiDataTable.TableCount;
			for (int i = 0; i < tableCount; i++)
			{
				EmojiData recordByIndex = DataManager.MapDataController.EmojiDataTable.GetRecordByIndex(i);
				if (this.MapEmojiCount.TryGetValue(recordByIndex.GroupIconID, out b))
				{
					this.MapEmojiCount[recordByIndex.GroupIconID] = b + 1;
				}
				else
				{
					this.MapEmojiCount.Add(recordByIndex.GroupIconID, 1);
				}
			}
		}
		if (this.MapEmojiCount.TryGetValue(PackageIndex, out b))
		{
			return b;
		}
		return 0;
	}

	// Token: 0x060006BB RID: 1723 RVA: 0x00096C60 File Offset: 0x00094E60
	public void SortEmojiData()
	{
		if (this.EmojiIndex.Count <= 0)
		{
			this.EmojiIndex.Clear();
			int tableCount = DataManager.MapDataController.EmoteTable.TableCount;
			for (int i = 0; i < tableCount; i++)
			{
				Emote recordByIndex = DataManager.MapDataController.EmoteTable.GetRecordByIndex(i);
				this.EmojiIndex.Add(recordByIndex.EmojiIndex);
			}
		}
		this.EmojiIndex.Sort(this.EmojiDataComparer);
	}

	// Token: 0x060006BC RID: 1724 RVA: 0x00096CE0 File Offset: 0x00094EE0
	public bool HasEmotionPck(ushort eid)
	{
		if (eid == 0 || eid > 512)
		{
			return false;
		}
		int num = (int)(eid - 1);
		long num2 = 1L << num % 64;
		int num3 = num / 64;
		return (this.EmojiFlag[num3] & num2) != 0L;
	}

	// Token: 0x060006BD RID: 1725 RVA: 0x00096D28 File Offset: 0x00094F28
	public bool InitLordEquipImg(Transform BtnT, ushort LEID = 0, byte color = 0, eLordEquipDisplayKind DisplayKind = eLordEquipDisplayKind.OnlyItem, bool setScale = false, bool setSound = true, ushort gem1 = 0, ushort gem2 = 0, ushort gem3 = 0, ushort gem4 = 0, ushort Quantity = 0, bool isEquip = false)
	{
		UILEBtn component = BtnT.GetComponent<UILEBtn>();
		if (component == null)
		{
			return false;
		}
		component.BackPanel = BtnT.GetComponent<Image>();
		RectTransform rectTransform;
		if (setScale)
		{
			component.transition = Selectable.Transition.None;
			uButtonScale uButtonScale = BtnT.gameObject.AddComponent<uButtonScale>();
			uButtonScale.m_Handler = component;
			uButtonScale.enabled = true;
			component.SetEffectType(e_EffectType.e_Scale);
			rectTransform = BtnT.GetComponent<RectTransform>();
			GameConstants.SetPivot(rectTransform, new Vector2(0.5f, 0.5f));
		}
		if (setSound)
		{
			component.SoundIndex = 0;
		}
		else
		{
			component.SoundIndex = byte.MaxValue;
		}
		GameObject gameObject = new GameObject("LEimg");
		gameObject.layer = 5;
		rectTransform = gameObject.AddComponent<RectTransform>();
		gameObject.AddComponent<IgnoreRaycast>();
		component.LEImage = gameObject.AddComponent<Image>();
		gameObject.transform.SetParent(BtnT, false);
		gameObject = new GameObject("Equip");
		gameObject.layer = 5;
		rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMin = new Vector2(0.68f, 0.23f);
		rectTransform.anchorMax = new Vector2(1.05f, 0.6f);
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		gameObject.AddComponent<IgnoreRaycast>();
		component.OnEquip = gameObject.AddComponent<Image>();
		gameObject.transform.SetParent(BtnT, false);
		gameObject.SetActive(false);
		gameObject = new GameObject("Level");
		gameObject.layer = 5;
		rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMin = new Vector2(0.05f, 0.8f);
		rectTransform.anchorMax = new Vector2(0.7f, 1f);
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		gameObject.AddComponent<IgnoreRaycast>();
		component.Level = gameObject.AddComponent<UIText>();
		component.Level.supportRichText = true;
		component.Level.resizeTextForBestFit = true;
		component.Level.font = this.m_TTFFont;
		gameObject.AddComponent<Outline>().effectColor = new Color32(36, 16, 0, byte.MaxValue);
		gameObject.AddComponent<Shadow>().effectColor = new Color(0f, 0f, 0f, 0.5f);
		gameObject.transform.SetParent(BtnT, false);
		gameObject = new GameObject("Quantity");
		gameObject.layer = 5;
		rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMin = new Vector2(0.4f, 0.23f);
		rectTransform.anchorMax = new Vector2(0.86f, 0.43f);
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		gameObject.AddComponent<IgnoreRaycast>();
		component.Quantity = gameObject.AddComponent<UIText>();
		component.Quantity.supportRichText = true;
		component.Quantity.resizeTextForBestFit = true;
		component.Quantity.font = this.m_TTFFont;
		component.Quantity.alignment = TextAnchor.MiddleRight;
		gameObject.AddComponent<Outline>().effectColor = new Color32(36, 16, 0, byte.MaxValue);
		gameObject.AddComponent<Shadow>().effectColor = new Color(0f, 0f, 0f, 0.5f);
		gameObject.transform.SetParent(BtnT, false);
		gameObject = new GameObject("Name");
		gameObject.layer = 5;
		rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMin = new Vector2(0f, 0f);
		rectTransform.anchorMax = new Vector2(1f, 0.25f);
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		gameObject.AddComponent<IgnoreRaycast>();
		component.Name = gameObject.AddComponent<UIText>();
		component.Name.supportRichText = true;
		component.Name.resizeTextForBestFit = true;
		component.Name.font = this.m_TTFFont;
		component.Name.alignment = TextAnchor.MiddleCenter;
		if (GameConstants.IsBigStyle())
		{
			component.Name.resizeTextMinSize = 10;
			component.Name.resizeTextMaxSize = 18;
		}
		else
		{
			component.Name.resizeTextMinSize = 8;
			component.Name.resizeTextMaxSize = 12;
		}
		gameObject.AddComponent<Outline>().effectColor = new Color32(36, 16, 0, byte.MaxValue);
		gameObject.AddComponent<Shadow>().effectColor = new Color(0f, 0f, 0f, 0.5f);
		gameObject.transform.SetParent(BtnT, false);
		this.ChangeLordEquipImg(BtnT, LEID, color, DisplayKind, gem1, gem2, gem3, gem4, Quantity, isEquip);
		return true;
	}

	// Token: 0x060006BE RID: 1726 RVA: 0x0009719C File Offset: 0x0009539C
	public void ChangeLordEquipImg(Transform BtnT, LordEquipMaterial data, eLordEquipDisplayKind DisplayKind = eLordEquipDisplayKind.Gems_Name_Quantity)
	{
		if (data.ItemID == 0)
		{
			this.ChangeLordEquipImg(BtnT, 0, 0, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
			return;
		}
		this.ChangeLordEquipImg(BtnT, data.ItemID, data.Color, DisplayKind, 0, 0, 0, 0, data.Quantity, false);
	}

	// Token: 0x060006BF RID: 1727 RVA: 0x000971E8 File Offset: 0x000953E8
	public void ChangeLordEquipImg(Transform BtnT, ItemLordEquip data, eLordEquipDisplayKind DisplayKind = eLordEquipDisplayKind.Item_Gems, bool isEquip = false)
	{
		if (data.ItemID == 0)
		{
			this.ChangeLordEquipImg(BtnT, 0, 0, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
			return;
		}
		this.ChangeLordEquipImg(BtnT, data.ItemID, data.Color, DisplayKind, data.Gem[0], data.Gem[1], data.Gem[2], data.Gem[3], 0, isEquip);
	}

	// Token: 0x060006C0 RID: 1728 RVA: 0x00097250 File Offset: 0x00095450
	public void ChangeLordEquipImg(Transform BtnT, LordEquipSerialData data, eLordEquipDisplayKind DisplayKind = eLordEquipDisplayKind.Item_Gems, bool isEquip = false)
	{
		if (data.ItemID == 0)
		{
			this.ChangeLordEquipImg(BtnT, 0, 0, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
			return;
		}
		this.ChangeLordEquipImg(BtnT, data.ItemID, data.Color, DisplayKind, data.Gem[0], data.Gem[1], data.Gem[2], data.Gem[3], 0, isEquip);
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x000972B8 File Offset: 0x000954B8
	public void ChangeLordEquipImg(Transform BtnT, ushort LEID, byte color, eLordEquipDisplayKind DisplayKind = eLordEquipDisplayKind.OnlyItem, ushort gem1 = 0, ushort gem2 = 0, ushort gem3 = 0, ushort gem4 = 0, ushort Quantity = 0, bool isEquip = false)
	{
		UILEBtn component = BtnT.GetComponent<UILEBtn>();
		UIButtonHint component2 = component.GetComponent<UIButtonHint>();
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(LEID);
		if (component2 != null)
		{
			component2.m_DownUpHandler = GUIManager.instance.m_LordInfo;
			component2.Parm1 = LEID;
			component2.Parm2 = color;
		}
		Vector2 zero = Vector2.zero;
		Vector2 one = Vector2.one;
		if (DisplayKind != eLordEquipDisplayKind.OnlyItem)
		{
			zero = new Vector2(0.075f, 0.15f);
			one = new Vector2(0.925f, 1f);
		}
		component.LEImage.rectTransform.anchorMin = zero;
		component.LEImage.rectTransform.anchorMax = one;
		component.LEImage.rectTransform.offsetMin = Vector2.zero;
		component.LEImage.rectTransform.offsetMax = Vector2.zero;
		if (GameConstants.IsBetween((int)color, 0, 6))
		{
			if ((recordByKey.EquipKind == 27 && recordByKey.NewGem > 0) || DisplayKind == eLordEquipDisplayKind.Item_NewGem)
			{
				color = Math.Min(color, 5);
				component.BackPanel.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite((ushort)(65528 + (int)color));
			}
			else
			{
				component.BackPanel.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite((ushort)(65500 + (int)color));
				component.Name.rectTransform.anchorMin = new Vector2(0f, 0f);
				component.Name.rectTransform.anchorMax = new Vector2(1f, 0.25f);
				component.Quantity.rectTransform.anchorMin = new Vector2(0.4f, 0.23f);
				component.Quantity.rectTransform.anchorMax = new Vector2(0.86f, 0.43f);
			}
		}
		component.BackPanel.material = this.m_LeadItemIconSpriteAsset.GetMaterial();
		byte equipKind = recordByKey.EquipKind;
		if (equipKind != 20 && equipKind != 27)
		{
			component.LEImage.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite(recordByKey.EquipPicture);
			component.LEImage.material = this.m_LeadItemIconSpriteAsset.GetMaterial();
		}
		else
		{
			component.LEImage.sprite = this.m_LeadMatIconSpriteAsset.LoadSprite(recordByKey.EquipPicture);
			component.LEImage.material = this.m_LeadMatIconSpriteAsset.GetMaterial();
		}
		component.LEImage.gameObject.SetActive(component.LEImage.sprite != null);
		component.OnEquip.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite(65524);
		component.OnEquip.material = this.m_LeadItemIconSpriteAsset.GetMaterial();
		bool flag = DisplayKind == eLordEquipDisplayKind.Gems_Name_Quantity || DisplayKind == eLordEquipDisplayKind.Gems_Name;
		component.Name.gameObject.SetActive(flag);
		if (flag)
		{
			component.Name.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.EquipName);
		}
		flag = (DisplayKind == eLordEquipDisplayKind.Gems_Name_Quantity);
		component.Quantity.gameObject.SetActive(flag);
		if (flag)
		{
			component.Quantity.text = string.Format("{0:N0}", Quantity);
		}
		int needLv = (int)recordByKey.NeedLv;
		flag = (needLv != 0 && LEID != 0 && DisplayKind == eLordEquipDisplayKind.Item_Gems);
		if (flag)
		{
			component.Level.text = string.Format(DataManager.Instance.mStringTable.GetStringByID(52u), needLv);
			if (needLv > (int)DataManager.Instance.RoleAttr.Level)
			{
				component.Level.color = Color.red;
			}
			else
			{
				component.Level.color = Color.white;
			}
		}
		component.Level.gameObject.SetActive(flag);
		component.OnEquip.gameObject.SetActive(isEquip);
		if (DisplayKind == eLordEquipDisplayKind.Item_Gems)
		{
			if (component.Gem1 == null)
			{
				GameObject gameObject = new GameObject("Gem1Panel");
				gameObject.layer = 5;
				RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMin = Vector2.zero;
				rectTransform.anchorMax = new Vector2(0.25f, 0.25f);
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				component.Gem1Panel = gameObject.AddComponent<Image>();
				gameObject.transform.SetParent(BtnT, false);
				gameObject = new GameObject("Gem2Panel");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0.25f, 0f);
				rectTransform.anchorMax = new Vector2(0.5f, 0.25f);
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				component.Gem2Panel = gameObject.AddComponent<Image>();
				gameObject.transform.SetParent(BtnT, false);
				gameObject = new GameObject("Gem3Panel");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0.5f, 0f);
				rectTransform.anchorMax = new Vector2(0.75f, 0.25f);
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				component.Gem3Panel = gameObject.AddComponent<Image>();
				gameObject.transform.SetParent(BtnT, false);
				gameObject = new GameObject("Gem4Panel");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0.74f, 0f);
				rectTransform.anchorMax = new Vector2(1f, 0.26f);
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				component.Gem4Panel = gameObject.AddComponent<Image>();
				gameObject.transform.SetParent(BtnT, false);
				gameObject = new GameObject("Gem1");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMin = Vector2.zero;
				rectTransform.anchorMax = new Vector2(0.25f, 0.25f);
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				component.Gem1 = gameObject.AddComponent<Image>();
				gameObject.transform.SetParent(BtnT, false);
				gameObject = new GameObject("Gem2");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0.25f, 0f);
				rectTransform.anchorMax = new Vector2(0.5f, 0.25f);
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				component.Gem2 = gameObject.AddComponent<Image>();
				gameObject.transform.SetParent(BtnT, false);
				gameObject = new GameObject("Gem3");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0.5f, 0f);
				rectTransform.anchorMax = new Vector2(0.75f, 0.25f);
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				component.Gem3 = gameObject.AddComponent<Image>();
				gameObject.transform.SetParent(BtnT, false);
				gameObject = new GameObject("Gem4");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0.74f, 0f);
				rectTransform.anchorMax = new Vector2(1f, 0.26f);
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				component.Gem4 = gameObject.AddComponent<Image>();
				gameObject.transform.SetParent(BtnT, false);
			}
			component.Gem1Panel.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite(65510);
			component.Gem1Panel.material = this.m_LeadItemIconSpriteAsset.GetMaterial();
			component.Gem2Panel.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite(65510);
			component.Gem2Panel.material = this.m_LeadItemIconSpriteAsset.GetMaterial();
			component.Gem3Panel.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite(65510);
			component.Gem3Panel.material = this.m_LeadItemIconSpriteAsset.GetMaterial();
			component.Gem4Panel.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite(65534);
			component.Gem4Panel.material = this.m_LeadItemIconSpriteAsset.GetMaterial();
			recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(gem1);
			component.Gem1.sprite = this.m_LeadMatIconSpriteAsset.LoadSprite(recordByKey.EquipPicture);
			component.Gem1.material = this.m_LeadMatIconSpriteAsset.GetMaterial();
			component.Gem1.gameObject.SetActive(component.Gem1.sprite != null);
			recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(gem2);
			component.Gem2.sprite = this.m_LeadMatIconSpriteAsset.LoadSprite(recordByKey.EquipPicture);
			component.Gem2.material = this.m_LeadMatIconSpriteAsset.GetMaterial();
			component.Gem2.gameObject.SetActive(component.Gem2.sprite != null);
			recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(gem3);
			component.Gem3.sprite = this.m_LeadMatIconSpriteAsset.LoadSprite(recordByKey.EquipPicture);
			component.Gem3.material = this.m_LeadMatIconSpriteAsset.GetMaterial();
			component.Gem3.gameObject.SetActive(component.Gem3.sprite != null);
			recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(gem4);
			component.Gem4.sprite = this.m_LeadMatIconSpriteAsset.LoadSprite(recordByKey.EquipPicture);
			component.Gem4.material = this.m_LeadMatIconSpriteAsset.GetMaterial();
			component.Gem4.gameObject.SetActive(component.Gem4.sprite != null);
			component.Gem1Panel.gameObject.SetActive(true);
			component.Gem2Panel.gameObject.SetActive(true);
			component.Gem3Panel.gameObject.SetActive(true);
			component.Gem4Panel.gameObject.SetActive(true);
		}
		else if (component.Gem1 != null)
		{
			component.Gem1.gameObject.SetActive(false);
			component.Gem2.gameObject.SetActive(false);
			component.Gem3.gameObject.SetActive(false);
			component.Gem4.gameObject.SetActive(false);
			component.Gem1Panel.gameObject.SetActive(false);
			component.Gem2Panel.gameObject.SetActive(false);
			component.Gem3Panel.gameObject.SetActive(false);
			component.Gem4Panel.gameObject.SetActive(false);
		}
		component.SetTimedItem((long)((ulong)DataManager.Instance.EquipTable.GetRecordByKey(LEID).TimedTime), DisplayKind);
	}

	// Token: 0x060006C2 RID: 1730 RVA: 0x00097E3C File Offset: 0x0009603C
	public void UpdateLordEquip(bool onSec)
	{
		double num = (double)Time.time % 1.6;
		if (num > 0.8)
		{
			num = 1.8 - num;
		}
		else
		{
			num += 0.2;
		}
		this.m_LEBtn_SharedAlpha = (float)num;
		for (int i = this.m_LEBTN_updateList.Count - 1; i >= 0; i--)
		{
			if (this.m_LEBTN_updateList[i] == null)
			{
				this.m_LEBTN_updateList.RemoveAt(i);
			}
			else
			{
				this.m_LEBTN_updateList[i].BtnUpdateTime(onSec);
			}
		}
		if (onSec && this.m_LEBTN_updateList.Count > 0)
		{
			LordEquipData.CheckEquipExpired();
		}
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x00097F04 File Offset: 0x00096104
	public void AddTimeBarToList(UITimeBar timebar)
	{
		this.m_TimeBarList.Add(timebar);
	}

	// Token: 0x060006C4 RID: 1732 RVA: 0x00097F14 File Offset: 0x00096114
	public void RemoverTimeBaarToList(UITimeBar timebar)
	{
		timebar.m_ListID = 0;
		this.m_TimeBarList.Remove(timebar);
	}

	// Token: 0x060006C5 RID: 1733 RVA: 0x00097F2C File Offset: 0x0009612C
	public void SetTimerBar(UITimeBar timebar, long begin, long target, long notifyTime, eTimeBarType type, string title1, string title2)
	{
		timebar.m_Titles[0] = title1;
		timebar.m_Titles[1] = title2;
		timebar.SetTitleText();
		timebar.SetValue(begin, target);
		timebar.m_NotifyTime = notifyTime;
		timebar.m_Type = type;
		if (timebar.m_ListID == 0)
		{
			this.AddTimeBarToList(timebar);
			timebar.m_ListID = 1;
		}
		timebar.UpdateTimeText(DataManager.Instance.ServerTime);
		if (timebar.m_TitleText != null)
		{
			timebar.m_TitleText.UpdateArabicPos();
		}
		if (timebar.m_TimeText != null)
		{
			timebar.m_TimeText.UpdateArabicPos();
		}
	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x00097FCC File Offset: 0x000961CC
	public void SetTimeBarIconStyle(UITimeBar timebar)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door == null)
		{
			return;
		}
		Material material = door.LoadMaterial();
		Sprite sprite = door.LoadSprite("UI_main_res_box");
		Sprite sprite2 = door.LoadSprite("UI_main_res_box_a");
		float num = 268f;
		float y = 33f;
		float num2 = num;
		float y2 = 31f;
		float num3 = num - 16f;
		float y3 = -1f;
		float x = 1f;
		timebar.TimeBarSizeY = 31f;
		timebar.TimeBarSizeX = num3;
		Image.Type type = Image.Type.Filled;
		Image.FillMethod fillMethod = Image.FillMethod.Horizontal;
		float num4 = num - 21f;
		timebar.GetComponent<RectTransform>().sizeDelta = new Vector2(num2, y);
		GameObject gameObject = new GameObject("Background");
		Image image = gameObject.AddComponent<Image>();
		image.material = material;
		image.sprite = sprite;
		image.type = Image.Type.Sliced;
		timebar.m_BackgroundImage = image;
		RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
		rectTransform.sizeDelta = new Vector2(num2, y);
		rectTransform.anchorMax = new Vector2(0f, 1f);
		rectTransform.anchorMin = new Vector2(0f, 1f);
		rectTransform.pivot = new Vector2(0f, 1f);
		gameObject.transform.SetParent(timebar.transform, false);
		GameObject gameObject2 = new GameObject("Slider");
		image = gameObject2.AddComponent<Image>();
		image.material = material;
		image.sprite = sprite2;
		image.type = type;
		image.fillMethod = fillMethod;
		image.fillAmount = 0f;
		timebar.m_SliderImage = image;
		rectTransform = gameObject2.GetComponent<RectTransform>();
		rectTransform.anchoredPosition = new Vector2(x, y3);
		rectTransform.sizeDelta = new Vector2(num3, y2);
		rectTransform.anchorMax = new Vector2(0f, 1f);
		rectTransform.anchorMin = new Vector2(0f, 1f);
		rectTransform.pivot = new Vector2(0f, 1f);
		gameObject2.transform.SetParent(timebar.transform, false);
		timebar.m_SliderRectTransform = rectTransform;
		gameObject = new GameObject("Background");
		image = gameObject.AddComponent<Image>();
		image.material = material;
		image.sprite = door.LoadSprite("UI_main_res_01");
		image.SetNativeSize();
		image.enabled = false;
		rectTransform = image.GetComponent<RectTransform>();
		rectTransform.anchorMax = new Vector2(0f, 1f);
		rectTransform.anchorMin = new Vector2(0f, 1f);
		rectTransform.pivot = new Vector2(0f, 1f);
		rectTransform.anchoredPosition = new Vector2(-18f, 2f);
		rectTransform.SetParent(timebar.transform, false);
		gameObject = new GameObject("Icon");
		rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMax = new Vector2(0f, 1f);
		rectTransform.anchorMin = new Vector2(0f, 1f);
		rectTransform.anchoredPosition = new Vector2(20f, -16f);
		rectTransform.SetParent(timebar.transform, false);
		GameObject gameObject3 = new GameObject("TitleText");
		UIText uitext = gameObject3.AddComponent<UIText>();
		uitext.font = this.GetTTFFont();
		uitext.alignment = TextAnchor.MiddleLeft;
		uitext.fontSize = 18;
		uitext.resizeTextForBestFit = false;
		uitext.resizeTextMinSize = 10;
		uitext.resizeTextMaxSize = 18;
		rectTransform = gameObject3.GetComponent<RectTransform>();
		rectTransform.anchorMax = new Vector2(0f, 1f);
		rectTransform.anchorMin = new Vector2(0f, 1f);
		rectTransform.pivot = new Vector2(0f, 1f);
		rectTransform.sizeDelta = new Vector2(num - 40f, y);
		rectTransform.anchoredPosition = new Vector2(40f, 0f);
		gameObject3.transform.SetParent(timebar.transform, false);
		timebar.m_TitleText = uitext;
		this.TimeBarTitleWidth = num2 - 50f;
		GameObject gameObject4 = new GameObject("TimeText");
		uitext = gameObject4.AddComponent<UIText>();
		uitext.font = this.GetTTFFont();
		uitext.alignment = TextAnchor.MiddleRight;
		uitext.fontSize = 18;
		uitext.resizeTextForBestFit = false;
		uitext.resizeTextMinSize = 10;
		uitext.resizeTextMaxSize = 18;
		uitext.color = new Color(0.964705f, 0.937254f, 0.603921f);
		rectTransform = gameObject4.GetComponent<RectTransform>();
		rectTransform.sizeDelta = new Vector2(num - 21.5f, y);
		rectTransform.anchorMax = new Vector2(1f, 1f);
		rectTransform.anchorMin = new Vector2(1f, 1f);
		rectTransform.pivot = new Vector2(1f, 1f);
		rectTransform.anchoredPosition = new Vector2(-24f, 0f);
		gameObject4.transform.SetParent(timebar.transform, false);
		timebar.m_TimeText = uitext;
		GameObject gameObject5 = new GameObject("FunBtn");
		image = gameObject5.AddComponent<Image>();
		UIButton uibutton = gameObject5.AddComponent<UIButton>();
		rectTransform = gameObject5.GetComponent<RectTransform>();
		rectTransform.anchorMax = new Vector2(0f, 0.5f);
		rectTransform.anchorMin = new Vector2(0f, 0.5f);
		rectTransform.pivot = new Vector2(0.5f, 0.5f);
		rectTransform.anchoredPosition = new Vector2(num4 + rectTransform.sizeDelta.x / 2f, 0f);
		timebar.m_FuntionBtn = uibutton;
		timebar.m_FuntionBtn.image.material = material;
		timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_queue_butt_up");
		timebar.m_FuntionBtn.SetButtonEffectType(e_EffectType.e_Scale);
		timebar.m_FuntionBtn.transition = Selectable.Transition.None;
		image.SetNativeSize();
		gameObject5.transform.SetParent(timebar.transform, false);
		uibutton.m_BtnID4 = (int)num4;
		GameObject gameObject6 = new GameObject("BtnText");
		uitext = gameObject6.AddComponent<UIText>();
		uitext.font = this.GetTTFFont();
		uitext.alignment = TextAnchor.MiddleCenter;
		uitext.fontSize = 20;
		uitext.resizeTextForBestFit = true;
		uitext.resizeTextMinSize = 6;
		uitext.resizeTextMaxSize = 20;
		rectTransform = gameObject6.GetComponent<RectTransform>();
		rectTransform.anchorMax = new Vector2(1f, 1f);
		rectTransform.anchorMin = new Vector2(0f, 0f);
		rectTransform.pivot = new Vector2(0.5f, 0.5f);
		rectTransform.offsetMax = new Vector2(-10f, -15f);
		rectTransform.offsetMin = new Vector2(10f, 15f);
		rectTransform.anchoredPosition = new Vector2(0f, 0f);
		gameObject6.AddComponent<Outline>();
		gameObject6.transform.SetParent(gameObject5.transform, false);
		uibutton.m_BtnID1 = 2;
	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x00098738 File Offset: 0x00096938
	public void SetTimeBarNormalStyle(UITimeBar timebar)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door == null)
		{
			return;
		}
		Image.Type type = Image.Type.Sliced;
		Image.FillMethod fillMethod = Image.FillMethod.Horizontal;
		Material material = door.LoadMaterial();
		Sprite sprite = door.LoadSprite("UI_main_art_box");
		Sprite sprite2 = door.LoadSprite("UI_main_art_blood_up");
		float y = 29f;
		float x = 268f;
		float y2 = 17f;
		float x2 = 244f;
		float y3 = -5f;
		float x3 = 9f;
		timebar.TimeBarSizeY = 19f;
		timebar.TimeBarSizeX = 250f;
		timebar.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);
		GameObject gameObject = new GameObject("Background");
		Image image = gameObject.AddComponent<Image>();
		image.material = material;
		image.sprite = sprite;
		image.type = Image.Type.Sliced;
		timebar.m_BackgroundImage = image;
		RectTransform component = gameObject.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(x, y);
		component.anchorMax = new Vector2(0f, 1f);
		component.anchorMin = new Vector2(0f, 1f);
		component.pivot = new Vector2(0f, 1f);
		gameObject.transform.SetParent(timebar.transform, false);
		GameObject gameObject2 = new GameObject("Slider");
		image = gameObject2.AddComponent<Image>();
		image.material = material;
		image.sprite = sprite2;
		image.type = type;
		image.fillMethod = fillMethod;
		image.fillAmount = 0f;
		timebar.m_SliderImage = image;
		component = gameObject2.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(x3, y3);
		component.sizeDelta = new Vector2(x2, y2);
		component.anchorMax = new Vector2(0f, 1f);
		component.anchorMin = new Vector2(0f, 1f);
		component.pivot = new Vector2(0f, 1f);
		gameObject2.transform.SetParent(timebar.transform, false);
		timebar.m_SliderRectTransform = component;
		GameObject gameObject3 = new GameObject("TitleText");
		UIText uitext = gameObject3.AddComponent<UIText>();
		uitext.font = this.GetTTFFont();
		uitext.fontSize = 16;
		uitext.resizeTextForBestFit = false;
		uitext.resizeTextMaxSize = 16;
		uitext.resizeTextMinSize = 10;
		uitext.alignment = TextAnchor.MiddleLeft;
		component = gameObject3.GetComponent<RectTransform>();
		component.anchorMax = new Vector2(0f, 1f);
		component.anchorMin = new Vector2(0f, 1f);
		component.pivot = new Vector2(0f, 1f);
		component.sizeDelta = new Vector2(157f, 29f);
		component.anchoredPosition = new Vector2(14f, 0f);
		gameObject3.transform.SetParent(timebar.transform, false);
		timebar.m_TitleText = uitext;
		GameObject gameObject4 = new GameObject("TimeText");
		uitext = gameObject4.AddComponent<UIText>();
		uitext.font = this.GetTTFFont();
		uitext.fontSize = 16;
		uitext.resizeTextForBestFit = false;
		uitext.resizeTextMaxSize = 16;
		uitext.resizeTextMinSize = 10;
		uitext.alignment = TextAnchor.MiddleRight;
		component = gameObject4.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(83f, 29f);
		component.anchorMax = new Vector2(1f, 1f);
		component.anchorMin = new Vector2(1f, 1f);
		component.pivot = new Vector2(1f, 1f);
		component.anchoredPosition = new Vector2(-14f, 0f);
		gameObject4.transform.SetParent(timebar.transform, false);
		timebar.m_TimeText = uitext;
	}

	// Token: 0x060006C8 RID: 1736 RVA: 0x00098B40 File Offset: 0x00096D40
	public void SetTimeBarCancelStyle(UITimeBar timebar)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door == null)
		{
			return;
		}
		Image.Type type = Image.Type.Sliced;
		Image.FillMethod fillMethod = Image.FillMethod.Horizontal;
		Material material = door.LoadMaterial();
		Sprite sprite = door.LoadSprite("UI_main_art_box_up");
		Sprite sprite2 = door.LoadSprite("UI_main_art_blood_up");
		timebar.TimeBarSizeY = 19f;
		timebar.TimeBarSizeX = 213f;
		GameObject gameObject = new GameObject("Background");
		Image image = gameObject.AddComponent<Image>();
		image.material = material;
		image.sprite = sprite;
		image.type = Image.Type.Sliced;
		timebar.m_BackgroundImage = image;
		RectTransform component = gameObject.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(43.5f, 0f);
		component.sizeDelta = new Vector2(250f, 47f);
		component.anchorMax = new Vector2(0f, 1f);
		component.anchorMin = new Vector2(0f, 1f);
		component.pivot = new Vector2(0f, 1f);
		gameObject.transform.SetParent(timebar.transform, false);
		GameObject gameObject2 = new GameObject("Slider");
		image = gameObject2.AddComponent<Image>();
		image.material = material;
		image.sprite = sprite2;
		image.type = type;
		image.fillMethod = fillMethod;
		image.fillAmount = 0f;
		timebar.m_SliderImage = image;
		component = gameObject2.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(61f, -14f);
		component.sizeDelta = new Vector2(213f, 19f);
		component.anchorMax = new Vector2(0f, 1f);
		component.anchorMin = new Vector2(0f, 1f);
		component.pivot = new Vector2(0f, 1f);
		gameObject2.transform.SetParent(timebar.transform, false);
		timebar.m_SliderRectTransform = component;
		GameObject gameObject3 = new GameObject("TitleText");
		UIText uitext = gameObject3.AddComponent<UIText>();
		uitext.font = this.GetTTFFont();
		uitext.alignment = TextAnchor.MiddleLeft;
		uitext.fontSize = 16;
		component = gameObject3.GetComponent<RectTransform>();
		component.anchorMax = new Vector2(0f, 1f);
		component.anchorMin = new Vector2(0f, 1f);
		component.pivot = new Vector2(0f, 1f);
		component.sizeDelta = new Vector2(119f, 27f);
		component.anchoredPosition = new Vector2(70f, -10f);
		gameObject3.transform.SetParent(timebar.transform, false);
		timebar.m_TitleText = uitext;
		GameObject gameObject4 = new GameObject("TimeText");
		uitext = gameObject4.AddComponent<UIText>();
		uitext.font = this.GetTTFFont();
		uitext.alignment = TextAnchor.MiddleRight;
		uitext.fontSize = 20;
		uitext.resizeTextForBestFit = true;
		uitext.resizeTextMinSize = 10;
		uitext.resizeTextMaxSize = 20;
		component = gameObject4.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(186f, 27f);
		component.anchorMax = new Vector2(1f, 1f);
		component.anchorMin = new Vector2(1f, 1f);
		component.pivot = new Vector2(1f, 1f);
		component.anchoredPosition = new Vector2(10f, -10f);
		gameObject4.transform.SetParent(timebar.transform, false);
		timebar.m_TimeText = uitext;
		GameObject gameObject5 = new GameObject("FunBtn");
		gameObject5.AddComponent<Image>();
		UIButton uibutton = gameObject5.AddComponent<UIButton>();
		uibutton.SetButtonEffectType(e_EffectType.e_Scale);
		component = gameObject5.GetComponent<RectTransform>();
		component.pivot = new Vector2(0.5f, 0.5f);
		component.anchoredPosition = new Vector2(315f, -23.5f);
		component.sizeDelta = new Vector2(47f, 47f);
		component.anchorMax = new Vector2(0f, 1f);
		component.anchorMin = new Vector2(0f, 1f);
		component.pivot = new Vector2(0.5f, 0.5f);
		gameObject5.transform.SetParent(timebar.transform, false);
		timebar.m_FuntionBtn = uibutton;
		timebar.m_FuntionBtn.image.material = material;
		timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_art_butt_up");
		timebar.m_FuntionBtn.image.SetNativeSize();
		timebar.m_FuntionBtn.m_EffectType = e_EffectType.e_Scale;
		timebar.m_FuntionBtn.transition = Selectable.Transition.None;
		uibutton.m_BtnID1 = 2;
		GameObject gameObject6 = new GameObject("CancelBtn");
		gameObject6.AddComponent<Image>();
		uibutton = gameObject6.AddComponent<UIButton>();
		uibutton.SetButtonEffectType(e_EffectType.e_Scale);
		component = gameObject6.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(23.5f, -23.5f);
		component.sizeDelta = new Vector2(47f, 47f);
		component.anchorMax = new Vector2(0f, 1f);
		component.anchorMin = new Vector2(0f, 1f);
		component.pivot = new Vector2(0.5f, 0.5f);
		gameObject6.transform.SetParent(timebar.transform, false);
		timebar.m_CancelBtn = uibutton;
		timebar.m_CancelBtn.image.material = material;
		timebar.m_CancelBtn.image.sprite = door.LoadSprite("UI_main_art_butt_stop");
		timebar.m_CancelBtn.m_EffectType = e_EffectType.e_Scale;
		timebar.m_CancelBtn.transition = Selectable.Transition.None;
		uibutton.m_BtnID1 = 1;
	}

	// Token: 0x060006C9 RID: 1737 RVA: 0x00099118 File Offset: 0x00097318
	public void SetTimeBarSpeedupStyle(UITimeBar timebar)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door == null)
		{
			return;
		}
		Image.Type type = Image.Type.Sliced;
		Image.FillMethod fillMethod = Image.FillMethod.Horizontal;
		Material material = door.LoadMaterial();
		Sprite sprite = door.LoadSprite("UI_main_art_box");
		Sprite sprite2 = door.LoadSprite("UI_main_art_blood_up");
		float y = 29f;
		float x = 600f;
		float y2 = 19f;
		float x2 = 577.8f;
		float y3 = -4.3f;
		float x3 = 8.89f;
		timebar.TimeBarSizeY = 20.39f;
		timebar.TimeBarSizeX = 581.9f;
		timebar.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);
		GameObject gameObject = new GameObject("Background");
		Image image = gameObject.AddComponent<Image>();
		image.material = material;
		image.sprite = sprite;
		image.type = Image.Type.Sliced;
		timebar.m_BackgroundImage = image;
		RectTransform component = gameObject.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(x, y);
		component.anchorMax = new Vector2(0f, 1f);
		component.anchorMin = new Vector2(0f, 1f);
		component.pivot = new Vector2(0f, 1f);
		gameObject.transform.SetParent(timebar.transform, false);
		GameObject gameObject2 = new GameObject("Slider");
		image = gameObject2.AddComponent<Image>();
		image.material = material;
		image.sprite = sprite2;
		image.type = type;
		image.fillMethod = fillMethod;
		image.fillAmount = 0f;
		timebar.m_SliderImage = image;
		component = gameObject2.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(x3, y3);
		component.sizeDelta = new Vector2(x2, y2);
		component.anchorMax = new Vector2(0f, 1f);
		component.anchorMin = new Vector2(0f, 1f);
		component.pivot = new Vector2(0f, 1f);
		gameObject2.transform.SetParent(timebar.transform, false);
		timebar.m_SliderRectTransform = component;
		GameObject gameObject3 = new GameObject("TitleText");
		UIText uitext = gameObject3.AddComponent<UIText>();
		uitext.font = this.GetTTFFont();
		uitext.fontSize = 20;
		uitext.resizeTextForBestFit = true;
		uitext.resizeTextMaxSize = 20;
		uitext.resizeTextMinSize = 10;
		uitext.alignment = TextAnchor.MiddleLeft;
		component = gameObject3.GetComponent<RectTransform>();
		component.anchorMax = new Vector2(0f, 1f);
		component.anchorMin = new Vector2(0f, 1f);
		component.pivot = new Vector2(0f, 1f);
		component.sizeDelta = new Vector2(x2, 26f);
		component.anchoredPosition = new Vector2(14f, -2f);
		gameObject3.transform.SetParent(timebar.transform, false);
		timebar.m_TitleText = uitext;
		GameObject gameObject4 = new GameObject("TimeText");
		uitext = gameObject4.AddComponent<UIText>();
		uitext.font = this.GetTTFFont();
		uitext.fontSize = 20;
		uitext.resizeTextForBestFit = true;
		uitext.resizeTextMaxSize = 20;
		uitext.resizeTextMinSize = 10;
		uitext.alignment = TextAnchor.MiddleRight;
		component = gameObject4.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(x2, 26f);
		component.anchorMax = new Vector2(0f, 1f);
		component.anchorMin = new Vector2(0f, 1f);
		component.pivot = new Vector2(0f, 1f);
		component.anchoredPosition = new Vector2(0f, -2f);
		gameObject4.transform.SetParent(timebar.transform, false);
		timebar.m_TimeText = uitext;
	}

	// Token: 0x060006CA RID: 1738 RVA: 0x00099518 File Offset: 0x00097718
	public void SetTimeBarMarshalStyle(UITimeBar timebar, byte bulebar = 0)
	{
		RectTransform component = timebar.transform.GetComponent<RectTransform>();
		Image component2 = component.GetComponent<Image>();
		Image component3 = component.GetChild(0).GetComponent<Image>();
		Image component4 = component.GetComponent<Image>();
		timebar.m_BackgroundImage = component4;
		UIText component5 = component.GetChild(4).GetComponent<UIText>();
		component5.font = this.GetTTFFont();
		timebar.m_TimeText = component5;
		component5 = component.GetChild(5).GetComponent<UIText>();
		timebar.m_TitleText = component5;
		component5 = component.GetChild(3).GetComponent<UIText>();
		component5.font = this.GetTTFFont();
		RectTransform component6;
		if (bulebar == 0)
		{
			component2.enabled = true;
			component3.gameObject.SetActive(false);
			component.GetChild(1).gameObject.SetActive(false);
			component4 = component.GetChild(2).GetComponent<Image>();
			component6 = component.GetChild(2).GetComponent<RectTransform>();
			component4.gameObject.SetActive(true);
		}
		else
		{
			component2.enabled = false;
			component3.gameObject.SetActive(true);
			component.GetChild(2).gameObject.SetActive(false);
			component4 = component.GetChild(1).GetComponent<Image>();
			component6 = component.GetChild(1).GetComponent<RectTransform>();
			component4.gameObject.SetActive(true);
		}
		component4.fillAmount = 0f;
		timebar.m_SliderImage = component4;
		timebar.m_SliderRectTransform = component6;
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x00099664 File Offset: 0x00097864
	public void SetTimeBarUIMissionStyle(UITimeBar timebar)
	{
		RectTransform component = timebar.transform.GetComponent<RectTransform>();
		Image component2 = component.GetComponent<Image>();
		timebar.m_BackgroundImage = component2;
		component2 = component.GetChild(0).GetComponent<Image>();
		component2.fillAmount = 0f;
		timebar.m_SliderImage = component2;
		RectTransform component3 = component.GetChild(0).GetComponent<RectTransform>();
		timebar.m_SliderRectTransform = component3;
		UIText component4 = component.GetChild(1).GetComponent<UIText>();
		timebar.m_TitleText = component4;
		component4.font = this.GetTTFFont();
		component4 = component.GetChild(2).GetComponent<UIText>();
		timebar.m_TimeText = component4;
		component4.font = this.GetTTFFont();
	}

	// Token: 0x060006CC RID: 1740 RVA: 0x00099700 File Offset: 0x00097900
	public void CreateTimerBar(UITimeBar timebar, long begin, long target, long notifyTime, eTimeBarType type, string title1, string title2)
	{
		if (type == eTimeBarType.IconType)
		{
			this.SetTimeBarIconStyle(timebar);
		}
		else if (type == eTimeBarType.NormalType)
		{
			this.SetTimeBarNormalStyle(timebar);
		}
		else if (type == eTimeBarType.CancelType)
		{
			this.SetTimeBarCancelStyle(timebar);
		}
		else if (type == eTimeBarType.SpeedupType)
		{
			this.SetTimeBarSpeedupStyle(timebar);
		}
		else if (type == eTimeBarType.Marshal)
		{
			this.SetTimeBarMarshalStyle(timebar, 0);
		}
		else if (type == eTimeBarType.UIMission)
		{
			this.SetTimeBarUIMissionStyle(timebar);
		}
		timebar.InitTimeBar();
		timebar.SetFunctionBtn();
		this.SetTimerBar(timebar, begin, target, notifyTime, type, title1, title2);
	}

	// Token: 0x060006CD RID: 1741 RVA: 0x000997A0 File Offset: 0x000979A0
	public void SetTimerSpriteType(UITimeBar timebar, eTimerSpriteType type)
	{
		timebar.m_TimerSpriteType = type;
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door == null)
		{
			return;
		}
		if (timebar.m_Type == eTimeBarType.IconType)
		{
			UIText component = timebar.m_FuntionBtn.transform.GetChild(0).GetComponent<UIText>();
			if (timebar.m_TimerSpriteType == eTimerSpriteType.Speed)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_res_box_a");
				timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_queue_butt_up");
				timebar.m_FuntionBtn.image.SetNativeSize();
				component.enabled = false;
				RectTransform component2 = timebar.m_FuntionBtn.GetComponent<RectTransform>();
				component2.anchoredPosition = new Vector2((float)timebar.m_FuntionBtn.m_BtnID4 + component2.sizeDelta.x / 2f + 5f, 0f);
				timebar.m_TitleText.resizeTextForBestFit = false;
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.Help)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_res_box_c");
				timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_queue_butt_help");
				timebar.m_FuntionBtn.image.SetNativeSize();
				component.text = DataManager.Instance.mStringTable.GetStringByID(781u);
				RectTransform component3 = timebar.m_FuntionBtn.GetComponent<RectTransform>();
				timebar.m_FuntionBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)timebar.m_FuntionBtn.m_BtnID4 + component3.sizeDelta.x / 2f, 0f);
				component.enabled = true;
				timebar.m_TitleText.resizeTextForBestFit = false;
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.Free)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_res_box_b");
				timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_queue_butt_end");
				timebar.m_FuntionBtn.image.SetNativeSize();
				component.text = DataManager.Instance.mStringTable.GetStringByID(780u);
				component.enabled = true;
				RectTransform component4 = timebar.m_FuntionBtn.GetComponent<RectTransform>();
				timebar.m_FuntionBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)timebar.m_FuntionBtn.m_BtnID4 + component4.sizeDelta.x / 2f, 0f);
				timebar.m_TitleText.resizeTextForBestFit = false;
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.RallyCountDown || timebar.m_TimerSpriteType == eTimerSpriteType.RallyStanby)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_res_box_a");
				timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_queue_butt_view");
				timebar.m_FuntionBtn.image.SetNativeSize();
				component.enabled = false;
				RectTransform component5 = timebar.m_FuntionBtn.GetComponent<RectTransform>();
				timebar.m_FuntionBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)timebar.m_FuntionBtn.m_BtnID4 + component5.sizeDelta.x / 2f + 4f, 0f);
				timebar.m_TitleText.resizeTextForBestFit = false;
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.Mobilization)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_res_box_a");
				timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_queue_butt_view");
				timebar.m_FuntionBtn.image.SetNativeSize();
				component.enabled = false;
				RectTransform component6 = timebar.m_FuntionBtn.GetComponent<RectTransform>();
				timebar.m_FuntionBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)timebar.m_FuntionBtn.m_BtnID4 + component6.sizeDelta.x / 2f + 4f, 0f);
				timebar.m_TitleText.resizeTextForBestFit = false;
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.Mobilization_Report)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_res_box_a");
				timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_queue_butt_OK");
				timebar.m_FuntionBtn.image.SetNativeSize();
				component.enabled = false;
				RectTransform component7 = timebar.m_FuntionBtn.GetComponent<RectTransform>();
				timebar.m_FuntionBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)timebar.m_FuntionBtn.m_BtnID4 + component7.sizeDelta.x / 2f + 5f, 0f);
				timebar.m_TitleText.resizeTextForBestFit = false;
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.Mobilization_fail)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_res_box_a");
				timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_queue_butt_NO");
				timebar.m_FuntionBtn.image.SetNativeSize();
				component.enabled = false;
				RectTransform component8 = timebar.m_FuntionBtn.GetComponent<RectTransform>();
				timebar.m_FuntionBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)timebar.m_FuntionBtn.m_BtnID4 + component8.sizeDelta.x / 2f + 5f, 0f);
				timebar.m_TitleText.resizeTextForBestFit = false;
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.NPCRewardEnd)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_res_box_a");
				timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_queue_butt_OK");
				timebar.m_FuntionBtn.image.SetNativeSize();
				component.enabled = false;
				RectTransform component9 = timebar.m_FuntionBtn.GetComponent<RectTransform>();
				timebar.m_FuntionBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)timebar.m_FuntionBtn.m_BtnID4 + component9.sizeDelta.x / 2f + 5f, 0f);
				timebar.m_TitleText.resizeTextForBestFit = false;
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.NPCRewardTransIng)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_res_box_a");
				timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_queue_butt_view");
				timebar.m_FuntionBtn.image.SetNativeSize();
				component.enabled = false;
				RectTransform component10 = timebar.m_FuntionBtn.GetComponent<RectTransform>();
				timebar.m_FuntionBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)timebar.m_FuntionBtn.m_BtnID4 + component10.sizeDelta.x / 2f + 5f, 0f);
				timebar.m_TitleText.resizeTextForBestFit = false;
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.PetMarch)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_res_box_a");
				timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_queue_butt_view");
				timebar.m_FuntionBtn.image.SetNativeSize();
				component.enabled = false;
				RectTransform component11 = timebar.m_FuntionBtn.GetComponent<RectTransform>();
				timebar.m_FuntionBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)timebar.m_FuntionBtn.m_BtnID4 + component11.sizeDelta.x / 2f + 5f, 0f);
				timebar.m_TitleText.resizeTextForBestFit = false;
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.Idle)
			{
				timebar.m_FuntionBtn.image.SetNativeSize();
				RectTransform rectTransform = timebar.m_TitleText.rectTransform;
				rectTransform.sizeDelta = new Vector2(this.TimeBarTitleWidth, rectTransform.sizeDelta.y);
				timebar.m_TitleText.resizeTextForBestFit = true;
			}
		}
		else if (timebar.m_Type == eTimeBarType.NormalType)
		{
			if (timebar.m_TimerSpriteType == eTimerSpriteType.Speed)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_art_blood_up");
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.Help)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_art_blood_help");
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.Free)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_art_blood_end");
			}
		}
		else if (timebar.m_Type == eTimeBarType.SpeedupType)
		{
			timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_art_blood_end");
		}
		else if (timebar.m_Type == eTimeBarType.CancelType)
		{
			if (timebar.m_TimerSpriteType == eTimerSpriteType.Speed)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_art_blood_up");
				if (this.IsArabic)
				{
					timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_art_butt_up_Arab");
				}
				else
				{
					timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_art_butt_up");
				}
				timebar.m_BackgroundImage.sprite = door.LoadSprite("UI_main_art_box_up");
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.Help)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_art_blood_help");
				timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_art_butt_help");
				timebar.m_BackgroundImage.sprite = door.LoadSprite("UI_main_art_box_help");
			}
			else if (timebar.m_TimerSpriteType == eTimerSpriteType.Free)
			{
				timebar.m_SliderImage.sprite = door.LoadSprite("UI_main_art_blood_end");
				if (GUIManager.instance.IsArabic)
				{
					timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_art_butt_end_Arab");
				}
				else
				{
					timebar.m_FuntionBtn.image.sprite = door.LoadSprite("UI_main_art_butt_end");
				}
				timebar.m_BackgroundImage.sprite = door.LoadSprite("UI_main_art_box_end");
			}
		}
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x0009A19C File Offset: 0x0009839C
	public void OpenUISynthesis(int itemID)
	{
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UISynthesis", out this.m_UISynthesisAbKey, false);
		if (assetBundle == null)
		{
			return;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(assetBundle.mainAsset);
		if (gameObject == null)
		{
			AssetManager.UnloadAssetBundle(this.m_UISynthesisAbKey, true);
			return;
		}
		this.m_UISynthesis = gameObject.AddComponent<UISynthesis>();
		int num = 24;
		this.m_WindowList[num] = this.m_UISynthesis;
		GUIWindow guiwindow = this.m_WindowList[num];
		this.m_SecWindow = guiwindow;
		guiwindow.m_eWindow = EGUIWindow.UI_Synthesis;
		guiwindow.m_AssetBundle = assetBundle;
		guiwindow.m_AssetBundleKey = this.m_UISynthesisAbKey;
		if (this.m_UISynthesis != null)
		{
			this.m_UISynthesis.MyOnOpen(itemID, gameObject.transform);
		}
		gameObject.transform.SetParent(GUIManager.Instance.m_SecWindowLayer, false);
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x0009A274 File Offset: 0x00098474
	public void SetRunningText(CString str)
	{
		this.m_RunningTextList.Add(str);
		if ((DataManager.Instance.RoleAttr.PrizeFlag & 2u) == 0u)
		{
			return;
		}
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.RunningText.CheckAddStr();
		}
		else
		{
			UIBattle_Gambling uibattle_Gambling = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
			if (uibattle_Gambling != null && uibattle_Gambling.RunningText != null)
			{
				uibattle_Gambling.RunningText.CheckAddStr();
			}
		}
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x0009A310 File Offset: 0x00098510
	public bool InitDemandResources(Transform DRT, float Width = 0f, float Spacing = 0f, bool bSetL = false)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		DemandResources component = DRT.GetComponent<DemandResources>();
		if (door == null && component == null)
		{
			return false;
		}
		Vector2 vector = new Vector2(0.5f, 0.5f);
		component.BtnResources = new Image[5];
		component.ImgResources = new Image[5];
		component.TextResources = new UIText[5];
		for (int i = 0; i < 5; i++)
		{
			GameObject gameObject = new GameObject("Btn");
			gameObject.layer = 5;
			RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
			vector.Set(0.5f, 0.5f);
			rectTransform.pivot = vector;
			rectTransform.anchorMin = vector;
			rectTransform.anchorMax = vector;
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
			if (bSetL)
			{
				vector.Set((float)(i - 2) * Spacing + 15f, -15f);
			}
			else
			{
				vector.Set((float)(i - 2) * Spacing, -15f);
			}
			rectTransform.anchoredPosition = vector;
			vector.Set(Spacing, 70f);
			rectTransform.sizeDelta = vector;
			UIButton uibutton = gameObject.AddComponent<UIButton>();
			uibutton.SetButtonEffectType(e_EffectType.e_Scale);
			uibutton.image = gameObject.AddComponent<Image>();
			uibutton.image.sprite = door.LoadSprite("UI_con_icon_05");
			uibutton.image.material = door.LoadMaterial();
			uibutton.image.color = new Color(1f, 1f, 1f, 0f);
			gameObject.transform.SetParent(component.GetComponent<RectTransform>(), false);
			uibutton.m_Handler = component;
			uibutton.m_BtnID1 = 1000 + i;
			gameObject = new GameObject("Img");
			gameObject.layer = 5;
			RectTransform rectTransform2 = gameObject.AddComponent<RectTransform>();
			vector.Set(0.5f, 0.5f);
			rectTransform2.pivot = vector;
			rectTransform2.anchorMin = vector;
			rectTransform2.anchorMax = vector;
			rectTransform2.offsetMin = Vector2.zero;
			rectTransform2.offsetMax = Vector2.zero;
			if (bSetL)
			{
				vector.Set(-15f, 5f);
			}
			else
			{
				vector.Set(0f, 5f);
			}
			rectTransform2.anchoredPosition = vector;
			component.ImgResources[i] = gameObject.AddComponent<Image>();
			gameObject.transform.SetParent(rectTransform.GetComponent<RectTransform>(), false);
			gameObject = new GameObject("Img2");
			gameObject.layer = 5;
			rectTransform2 = gameObject.AddComponent<RectTransform>();
			vector.Set(0.5f, 0.5f);
			rectTransform2.pivot = vector;
			rectTransform2.anchorMin = vector;
			rectTransform2.anchorMax = vector;
			rectTransform2.offsetMin = Vector2.zero;
			rectTransform2.offsetMax = Vector2.zero;
			vector.Set(37.5f, 17f);
			rectTransform2.anchoredPosition = vector;
			vector.Set(44f, 44f);
			rectTransform2.sizeDelta = vector;
			component.BtnResources[i] = gameObject.AddComponent<Image>();
			component.BtnResources[i].sprite = door.LoadSprite("UI_con_icon_05");
			component.BtnResources[i].material = door.LoadMaterial();
			component.BtnResources[i].SetNativeSize();
			gameObject.transform.SetParent(component.ImgResources[i].GetComponent<RectTransform>(), false);
			component.BtnResources[i].gameObject.SetActive(false);
			gameObject = new GameObject("text");
			gameObject.layer = 5;
			rectTransform2 = gameObject.AddComponent<RectTransform>();
			vector.Set(0.5f, 0.5f);
			rectTransform2.pivot = vector;
			rectTransform2.anchorMin = vector;
			rectTransform2.anchorMax = vector;
			rectTransform2.offsetMin = Vector2.zero;
			rectTransform2.offsetMax = Vector2.zero;
			vector.Set(0f, -25f);
			rectTransform2.anchoredPosition = vector;
			vector.Set(Spacing, 24f);
			rectTransform2.sizeDelta = vector;
			component.TextResources[i] = gameObject.AddComponent<UIText>();
			gameObject.transform.SetParent(component.ImgResources[i].GetComponent<RectTransform>(), false);
			component.TextResources[i].font = this.m_TTFFont;
			component.TextResources[i].fontSize = 16;
			this.tmpString.Length = 0;
			component.TextResources[i].text = this.tmpString.AppendFormat("{0:00000}", i).ToString();
			component.TextResources[i].alignment = TextAnchor.MiddleCenter;
			gameObject.AddComponent<IgnoreRaycast>();
		}
		component.ImgResources[0].sprite = door.LoadSprite("UI_main_res_food");
		component.ImgResources[0].material = door.LoadMaterial();
		component.ImgResources[0].SetNativeSize();
		component.ImgResources[1].sprite = door.LoadSprite("UI_main_res_stone");
		component.ImgResources[1].material = door.LoadMaterial();
		component.ImgResources[1].SetNativeSize();
		component.ImgResources[2].sprite = door.LoadSprite("UI_main_res_wood");
		component.ImgResources[2].material = door.LoadMaterial();
		component.ImgResources[2].SetNativeSize();
		component.ImgResources[3].sprite = door.LoadSprite("UI_main_res_iron");
		component.ImgResources[3].material = door.LoadMaterial();
		component.ImgResources[3].SetNativeSize();
		component.ImgResources[4].sprite = door.LoadSprite("UI_main_money_01");
		component.ImgResources[4].material = door.LoadMaterial();
		component.ImgResources[4].SetNativeSize();
		return true;
	}

	// Token: 0x060006D1 RID: 1745 RVA: 0x0009A8D0 File Offset: 0x00098AD0
	public bool SetDemandResourcesText(Transform DRT, long[] Resources)
	{
		DemandResources component = DRT.GetComponent<DemandResources>();
		if (component == null)
		{
			return false;
		}
		DataManager dataManager = DataManager.Instance;
		for (int i = 0; i < 5; i++)
		{
			uint stock = dataManager.Resource[i].Stock;
			component.BtnResources[i].gameObject.SetActive(false);
			this.tmpString.Length = 0;
			if ((ulong)stock < (ulong)Resources[i])
			{
				if (this.IsArabic)
				{
					GameConstants.FormatResourceValue(this.tmpString, (uint)Resources[i]);
					this.tmpString.Append("/<color=#E5004F>");
					GameConstants.FormatResourceValue(this.tmpString, stock);
					this.tmpString.Append("</color>");
				}
				else
				{
					this.tmpString.Append("<color=#E5004F>");
					GameConstants.FormatResourceValue(this.tmpString, stock);
					this.tmpString.AppendFormat("</color>/", new object[0]);
					GameConstants.FormatResourceValue(this.tmpString, (uint)Resources[i]);
				}
				component.BtnResources[i].gameObject.SetActive(true);
			}
			else if (this.IsArabic)
			{
				GameConstants.FormatResourceValue(this.tmpString, (uint)Resources[i]);
				this.tmpString.AppendFormat("/", new object[0]);
				GameConstants.FormatResourceValue(this.tmpString, stock);
			}
			else
			{
				GameConstants.FormatResourceValue(this.tmpString, stock);
				this.tmpString.AppendFormat("/", new object[0]);
				GameConstants.FormatResourceValue(this.tmpString, (uint)Resources[i]);
			}
			component.tmpValue[i] = (uint)Resources[i];
			component.TextResources[i].text = this.tmpString.ToString();
		}
		return true;
	}

	// Token: 0x060006D2 RID: 1746 RVA: 0x0009AA84 File Offset: 0x00098C84
	public bool InitUnitResourcesSlider(Transform URST, eUnitSlider Kind, uint Min, uint Max, float Alpha = 1f)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		UnitResourcesSlider component = URST.GetComponent<UnitResourcesSlider>();
		if (component == null)
		{
			return false;
		}
		Vector2 vector = new Vector2(0.5f, 0.5f);
		component.Value = (long)((ulong)Min);
		component.SetMinValue((long)((ulong)Min));
		component.Type = (byte)Kind;
		Material material = this.LoadMaterial("BuildingWindow", "BuildingWindow_m");
		GameObject gameObject = new GameObject("BtnIncrease");
		gameObject.layer = 5;
		RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
		vector.Set(0.5f, 0.5f);
		rectTransform.pivot = vector;
		rectTransform.anchorMin = vector;
		rectTransform.anchorMax = vector;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		vector.Set(170f, -20f);
		rectTransform.anchoredPosition = vector;
		vector.Set(70f, 60f);
		rectTransform.sizeDelta = vector;
		component.BtnIncrease = gameObject.AddComponent<UIButton>();
		component.BtnIncrease.SetButtonEffectType(e_EffectType.e_Scale);
		component.BtnIncrease.image = gameObject.AddComponent<Image>();
		if (door != null)
		{
			component.BtnIncrease.image.sprite = door.LoadSprite("UI_main_strip_01");
			component.BtnIncrease.image.material = door.LoadMaterial();
		}
		component.BtnIncrease.image.color = new Color(1f, 1f, 1f, 0f);
		UISliderBeHavior uisliderBeHavior = gameObject.AddComponent<UISliderBeHavior>();
		uisliderBeHavior.m_Handler = component;
		gameObject.transform.SetParent(component.GetComponent<RectTransform>(), false);
		gameObject = new GameObject("Img");
		gameObject.layer = 5;
		rectTransform = gameObject.AddComponent<RectTransform>();
		vector.Set(0.5f, 0.5f);
		rectTransform.pivot = vector;
		rectTransform.anchorMin = vector;
		rectTransform.anchorMax = vector;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		vector.Set(0f, 0f);
		rectTransform.anchoredPosition = vector;
		vector.Set(33f, 33f);
		rectTransform.sizeDelta = vector;
		Image image = gameObject.AddComponent<Image>();
		if (door != null)
		{
			image.sprite = door.LoadSprite("UI_main_strip_01");
			image.material = door.LoadMaterial();
		}
		image.SetNativeSize();
		Color color = image.color;
		color.a = Alpha;
		image.color = color;
		gameObject.transform.SetParent(component.BtnIncrease.GetComponent<RectTransform>(), false);
		gameObject = new GameObject("BtnLessen");
		gameObject.layer = 5;
		rectTransform = gameObject.AddComponent<RectTransform>();
		vector.Set(0.5f, 0.5f);
		rectTransform.pivot = vector;
		rectTransform.anchorMin = vector;
		rectTransform.anchorMax = vector;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		vector.Set(-180f, -20f);
		rectTransform.anchoredPosition = vector;
		vector.Set(70f, 60f);
		rectTransform.sizeDelta = vector;
		component.BtnLessen = gameObject.AddComponent<UIButton>();
		component.BtnLessen.SetButtonEffectType(e_EffectType.e_Scale);
		component.BtnLessen.image = gameObject.AddComponent<Image>();
		if (door != null)
		{
			component.BtnLessen.image.sprite = door.LoadSprite("UI_main_strip_02");
			component.BtnLessen.image.material = door.LoadMaterial();
		}
		component.BtnLessen.image.color = new Color(1f, 1f, 1f, 0f);
		uisliderBeHavior = gameObject.AddComponent<UISliderBeHavior>();
		uisliderBeHavior.m_Handler = component;
		gameObject.transform.SetParent(component.GetComponent<RectTransform>(), false);
		gameObject = new GameObject("Img");
		gameObject.layer = 5;
		rectTransform = gameObject.AddComponent<RectTransform>();
		vector.Set(0.5f, 0.5f);
		rectTransform.pivot = vector;
		rectTransform.anchorMin = vector;
		rectTransform.anchorMax = vector;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		vector.Set(0f, 0f);
		rectTransform.anchoredPosition = vector;
		vector.Set(33f, 33f);
		rectTransform.sizeDelta = vector;
		image = gameObject.AddComponent<Image>();
		if (door != null)
		{
			image.sprite = door.LoadSprite("UI_main_strip_02");
			image.material = door.LoadMaterial();
		}
		image.SetNativeSize();
		color = image.color;
		color.a = Alpha;
		image.color = color;
		gameObject.transform.SetParent(component.BtnLessen.GetComponent<RectTransform>(), false);
		gameObject = new GameObject("m_slider");
		gameObject.layer = 5;
		rectTransform = gameObject.AddComponent<RectTransform>();
		vector.Set(0.5f, 0.5f);
		rectTransform.pivot = vector;
		rectTransform.anchorMin = vector;
		rectTransform.anchorMax = vector;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		vector.Set(0f, -20f);
		rectTransform.anchoredPosition = vector;
		vector.Set(257f, 19f);
		rectTransform.sizeDelta = vector;
		component.m_slider = gameObject.AddComponent<CSlider>();
		gameObject.transform.SetParent(component.GetComponent<RectTransform>(), false);
		GameObject gameObject2 = new GameObject("Background");
		gameObject2.layer = 5;
		rectTransform = gameObject2.AddComponent<RectTransform>();
		vector.Set(0.5f, 0.5f);
		rectTransform.pivot = vector;
		vector.Set(0.5f, 0.5f);
		rectTransform.anchorMin = vector;
		vector.Set(0.5f, 0.5f);
		rectTransform.anchorMax = vector;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		vector.Set(0f, 0f);
		rectTransform.anchoredPosition = vector;
		vector.Set(257f, 19f);
		rectTransform.sizeDelta = vector;
		image = gameObject2.AddComponent<Image>();
		if (door != null)
		{
			image.sprite = door.LoadSprite("UI_main_strip_03");
			image.material = door.LoadMaterial();
		}
		color = image.color;
		color.a = Alpha;
		image.color = color;
		image.type = Image.Type.Sliced;
		gameObject2.transform.SetParent(component.m_slider.transform, false);
		gameObject2 = new GameObject("FillArea");
		gameObject2.layer = 5;
		rectTransform = gameObject2.AddComponent<RectTransform>();
		vector.Set(0.5f, 0.5f);
		rectTransform.pivot = vector;
		vector.Set(0f, 0.25f);
		rectTransform.anchorMin = vector;
		vector.Set(1f, 0.75f);
		rectTransform.anchorMax = vector;
		rectTransform.offsetMin = new Vector2(5f, 0f);
		rectTransform.offsetMax = new Vector2(-15f, 0f);
		vector.Set(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);
		rectTransform.anchoredPosition = vector;
		vector.Set(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
		rectTransform.sizeDelta = vector;
		gameObject2.transform.SetParent(component.m_slider.transform, false);
		GameObject gameObject3 = new GameObject("Fill");
		gameObject3.layer = 5;
		rectTransform = gameObject3.AddComponent<RectTransform>();
		vector.Set(0.5f, 0.5f);
		rectTransform.pivot = vector;
		vector.Set(0f, 0f);
		rectTransform.anchorMin = vector;
		vector.Set(0f, 1f);
		rectTransform.anchorMax = vector;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		vector.Set(-5f, rectTransform.anchoredPosition.y);
		rectTransform.anchoredPosition = vector;
		vector.Set(5f, rectTransform.sizeDelta.y);
		rectTransform.sizeDelta = vector;
		image = gameObject3.AddComponent<Image>();
		if (door != null)
		{
			image.sprite = door.LoadSprite("UI_main_strip_03");
			image.material = door.LoadMaterial();
		}
		color = image.color;
		color.a = Alpha;
		image.color = color;
		image.gameObject.SetActive(false);
		gameObject3.transform.SetParent(gameObject2.transform, false);
		component.m_slider.fillRect = rectTransform;
		gameObject2 = new GameObject("HandleSlideArea");
		gameObject2.layer = 5;
		rectTransform = gameObject2.AddComponent<RectTransform>();
		vector.Set(0.5f, 0.5f);
		rectTransform.pivot = vector;
		vector.Set(0f, 0f);
		rectTransform.anchorMin = vector;
		vector.Set(1f, 1f);
		rectTransform.anchorMax = vector;
		rectTransform.offsetMin = new Vector2(8f, 0f);
		rectTransform.offsetMax = new Vector2(-10f, 0f);
		gameObject2.transform.SetParent(component.m_slider.transform, false);
		gameObject3 = new GameObject("Handle");
		gameObject3.layer = 5;
		rectTransform = gameObject3.AddComponent<RectTransform>();
		vector.Set(0.5f, 0.5f);
		rectTransform.pivot = vector;
		vector.Set(1f, 0f);
		rectTransform.anchorMin = vector;
		vector.Set(1f, 1f);
		rectTransform.anchorMax = vector;
		rectTransform.offsetMin = new Vector2(0f, -13.5f);
		rectTransform.offsetMax = new Vector2(0f, 13.5f);
		vector.Set(0f, rectTransform.anchoredPosition.y);
		rectTransform.anchoredPosition = vector;
		vector.Set(46f, rectTransform.sizeDelta.y);
		rectTransform.sizeDelta = vector;
		image = gameObject3.AddComponent<Image>();
		if (door != null)
		{
			image.sprite = door.LoadSprite("UI_main_strip_04");
			image.material = door.LoadMaterial();
		}
		gameObject3.transform.SetParent(gameObject2.transform, false);
		component.m_slider.targetGraphic = image;
		component.m_slider.handleRect = rectTransform;
		component.m_slider.wholeNumbers = true;
		component.MaxValue = (long)((ulong)Max);
		component.m_slider.minValue = Min;
		component.m_slider.maxValue = Max;
		component.m_slider.value = Min;
		component.Speed = Max / 100u;
		if (component.Speed < 3u)
		{
			component.Speed = 3u;
		}
		Vector2 anchoredPosition = new Vector2(0.5f, 0.5f);
		Vector2 sizeDelta = new Vector2(84f, 24f);
		switch (Kind)
		{
		case eUnitSlider.Barrack:
			anchoredPosition.Set(-32.5f, 33f);
			break;
		case eUnitSlider.Hospital:
			if (!this.IsArabic)
			{
				anchoredPosition.Set(40f, 20f);
			}
			else
			{
				anchoredPosition.Set(0f, 20f);
			}
			break;
		case eUnitSlider.Expedition:
			anchoredPosition.Set(100f, 26f);
			break;
		case eUnitSlider.AutoUse:
			anchoredPosition.Set(-51f, 30f);
			break;
		case eUnitSlider.MarketHelp:
			anchoredPosition.Set(100f, 26f);
			break;
		case eUnitSlider.Crypt:
			if (!this.IsArabic)
			{
				anchoredPosition.Set(-20f, 29f);
			}
			else
			{
				anchoredPosition.Set(-30f, 29f);
			}
			sizeDelta.Set(80f, 24f);
			break;
		case eUnitSlider.CastleStrengthen:
			anchoredPosition.Set(50f, 26f);
			break;
		case eUnitSlider.Other:
			anchoredPosition.Set(-80f, 52.5f);
			sizeDelta.Set(80f, 24f);
			break;
		}
		gameObject = new GameObject("BtnInputText");
		gameObject.layer = 5;
		rectTransform = gameObject.AddComponent<RectTransform>();
		vector.Set(0.5f, 0.5f);
		rectTransform.pivot = vector;
		rectTransform.anchorMin = vector;
		rectTransform.anchorMax = vector;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		rectTransform.anchoredPosition = anchoredPosition;
		rectTransform.sizeDelta = sizeDelta;
		component.BtnInputText = gameObject.AddComponent<UIButton>();
		component.BtnInputText.image = gameObject.AddComponent<Image>();
		if (door != null)
		{
			component.BtnInputText.image.sprite = door.LoadSprite("UI_main_strip_05");
			component.BtnInputText.image.material = door.LoadMaterial();
		}
		component.BtnInputText.image.type = Image.Type.Sliced;
		gameObject.transform.SetParent(component.GetComponent<RectTransform>(), false);
		gameObject = new GameObject("Text");
		gameObject.layer = 5;
		rectTransform = gameObject.AddComponent<RectTransform>();
		vector.Set(0.5f, 0.5f);
		rectTransform.pivot = vector;
		vector.Set(0f, 0f);
		rectTransform.anchorMin = vector;
		vector.Set(1f, 1f);
		rectTransform.anchorMax = vector;
		rectTransform.offsetMin = Vector2.zero;
		vector.Set(-8f, 0f);
		rectTransform.offsetMax = vector;
		vector.Set(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);
		rectTransform.anchoredPosition = vector;
		vector.Set(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
		rectTransform.sizeDelta = vector;
		UIText uitext = gameObject.AddComponent<UIText>();
		uitext.font = this.GetTTFFont();
		uitext.fontSize = 18;
		uitext.alignment = TextAnchor.MiddleRight;
		uitext.supportRichText = false;
		gameObject.transform.SetParent(component.BtnInputText.transform, false);
		component.m_inputText = uitext;
		this.tmpString.Length = 0;
		this.tmpString.AppendFormat("{0}", Min);
		component.m_inputText.text = this.tmpString.ToString();
		if (Kind == eUnitSlider.CastleStrengthen)
		{
			component.BtnInputText.gameObject.SetActive(false);
		}
		if (Kind == eUnitSlider.Barrack || Kind == eUnitSlider.Hospital || Kind == eUnitSlider.Other || Kind == eUnitSlider.Crypt)
		{
			gameObject = new GameObject("Image");
			gameObject.layer = 5;
			rectTransform = gameObject.AddComponent<RectTransform>();
			vector.Set(0.5f, 0.5f);
			rectTransform.pivot = vector;
			rectTransform.anchorMin = vector;
			rectTransform.anchorMax = vector;
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
			vector.Set(anchoredPosition.x + 54f, anchoredPosition.y);
			rectTransform.anchoredPosition = vector;
			image = gameObject.AddComponent<Image>();
			if (door != null)
			{
				image.sprite = door.LoadSprite("UI_main_strip_06");
				image.material = door.LoadMaterial();
			}
			image.SetNativeSize();
			gameObject.transform.SetParent(component.transform, false);
			if (Kind != eUnitSlider.Crypt)
			{
				gameObject2 = new GameObject("Text");
				gameObject2.layer = 5;
				rectTransform = gameObject2.AddComponent<RectTransform>();
				vector.Set(0f, 0.5f);
				rectTransform.pivot = vector;
				rectTransform.anchorMin = vector;
				rectTransform.anchorMax = vector;
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				vector.Set(314.5f, anchoredPosition.y);
				rectTransform.anchoredPosition = vector;
				vector.Set(72f, 30f);
				rectTransform.sizeDelta = vector;
				component.m_TotalText = gameObject2.AddComponent<UIText>();
				component.m_TotalText.font = this.GetTTFFont();
				component.m_TotalText.alignment = TextAnchor.MiddleLeft;
				component.m_TotalText.fontSize = 18;
				this.tmpString.Length = 0;
				this.tmpString.AppendFormat("{0:N0}", Max);
				component.m_TotalText.text = this.tmpString.ToString();
				component.m_TotalText.color = new Color(1f, 0.925f, 0.529f);
				gameObject2.transform.SetParent(component.transform, false);
				if (this.IsArabic)
				{
					image.transform.localScale = new Vector3(-1f, image.transform.localScale.y, image.transform.localScale.z);
				}
			}
			else
			{
				gameObject2 = new GameObject("Text");
				gameObject2.layer = 5;
				rectTransform = gameObject2.AddComponent<RectTransform>();
				vector.Set(0f, 0.5f);
				rectTransform.pivot = vector;
				rectTransform.anchorMin = vector;
				rectTransform.anchorMax = vector;
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				if (!this.IsArabic)
				{
					vector.Set(98f, anchoredPosition.y);
				}
				else
				{
					vector.Set(88f, anchoredPosition.y);
				}
				rectTransform.anchoredPosition = vector;
				vector.Set(70f, 30f);
				rectTransform.sizeDelta = vector;
				component.m_TotalText = gameObject2.AddComponent<UIText>();
				component.m_TotalText.font = this.GetTTFFont();
				component.m_TotalText.alignment = TextAnchor.MiddleLeft;
				component.m_TotalText.fontSize = 18;
				this.tmpString.Length = 0;
				this.tmpString.AppendFormat("{0:N0}", Max);
				component.m_TotalText.text = this.tmpString.ToString();
				component.m_TotalText.color = new Color(1f, 0.925f, 0.529f);
				gameObject2.transform.SetParent(component.transform, false);
				if (this.IsArabic)
				{
					image.transform.localScale = new Vector3(-1f, image.transform.localScale.y, image.transform.localScale.z);
				}
			}
			if (Kind == eUnitSlider.Barrack)
			{
				gameObject = new GameObject("Image");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				vector.Set(0.5f, 0.5f);
				rectTransform.pivot = vector;
				rectTransform.anchorMin = vector;
				rectTransform.anchorMax = vector;
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				vector.Set(-90f, 33f);
				rectTransform.anchoredPosition = vector;
				vector.Set(31f, 41f);
				rectTransform.sizeDelta = vector;
				image = gameObject.AddComponent<Image>();
				image.sprite = this.LoadSprite("BuildingWindow", "UI_con_icon_04");
				image.material = material;
				image.SetNativeSize();
				gameObject.transform.SetParent(component.transform, false);
			}
			else if (Kind == eUnitSlider.Hospital)
			{
				if (this.IsArabic)
				{
					component.m_TotalText.rectTransform.anchoredPosition = new Vector2(270f, component.m_TotalText.rectTransform.anchoredPosition.y);
				}
				gameObject = new GameObject("Image");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				vector.Set(0.5f, 0.5f);
				rectTransform.pivot = vector;
				rectTransform.anchorMin = vector;
				rectTransform.anchorMax = vector;
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				if (!this.IsArabic)
				{
					vector.Set(-25f, 20f);
				}
				else
				{
					vector.Set(160f, 20f);
				}
				rectTransform.anchoredPosition = vector;
				image = gameObject.AddComponent<Image>();
				image.sprite = this.LoadSprite("BuildingWindow", "UI_con_icon_01");
				image.material = material;
				image.SetNativeSize();
				gameObject.transform.SetParent(component.transform, false);
			}
		}
		else if (Kind == eUnitSlider.Expedition)
		{
			gameObject = new GameObject("Image");
			gameObject.layer = 5;
			rectTransform = gameObject.AddComponent<RectTransform>();
			vector.Set(0.5f, 0.5f);
			rectTransform.pivot = vector;
			rectTransform.anchorMin = vector;
			rectTransform.anchorMax = vector;
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
			vector.Set(45f, 25f);
			rectTransform.anchoredPosition = vector;
			vector.Set(31f, 41f);
			rectTransform.sizeDelta = vector;
			image = gameObject.AddComponent<Image>();
			gameObject.transform.SetParent(component.transform, false);
		}
		return true;
	}

	// Token: 0x060006D3 RID: 1747 RVA: 0x0009BFF8 File Offset: 0x0009A1F8
	public bool SetUnitResourcesSliderImg(Transform URST, eUnitSliderSize Kind, Sprite mspeite = null, Material mmaterial = null)
	{
		UnitResourcesSlider component = URST.GetComponent<UnitResourcesSlider>();
		if (component == null)
		{
			return false;
		}
		if (mspeite != null && mmaterial != null)
		{
			switch (Kind)
			{
			case eUnitSliderSize.BtnIncrease:
			{
				component.BtnIncrease.image.sprite = mspeite;
				component.BtnIncrease.image.material = mmaterial;
				Image component2 = component.BtnIncrease.transform.GetChild(0).GetComponent<Image>();
				component2.sprite = mspeite;
				component2.material = mmaterial;
				break;
			}
			case eUnitSliderSize.BtnLessen:
			{
				component.BtnLessen.image.sprite = mspeite;
				component.BtnLessen.image.material = mmaterial;
				Image component2 = component.BtnLessen.transform.GetChild(0).GetComponent<Image>();
				component2.sprite = mspeite;
				component2.material = mmaterial;
				break;
			}
			case eUnitSliderSize.Input:
				component.BtnInputText.image.sprite = mspeite;
				component.BtnInputText.image.material = mmaterial;
				break;
			case eUnitSliderSize.m_sliderBG1:
			{
				Transform component3 = component.m_slider.GetComponent<Transform>();
				Image component2 = component3.GetChild(0).GetComponent<Image>();
				component2.sprite = mspeite;
				component2.material = mmaterial;
				component2 = component3.GetChild(1).GetChild(0).GetComponent<Image>();
				component2.sprite = mspeite;
				component2.material = mmaterial;
				break;
			}
			case eUnitSliderSize.m_sliderBG2:
			{
				Transform component3 = component.m_slider.GetComponent<Transform>();
				Image component2 = component3.GetChild(2).GetChild(0).GetComponent<Image>();
				component2.sprite = mspeite;
				component2.material = mmaterial;
				break;
			}
			case eUnitSliderSize.m_Img:
			{
				Image component2 = URST.GetChild(4).GetComponent<Image>();
				component2.sprite = mspeite;
				component2.material = mmaterial;
				component2.SetNativeSize();
				break;
			}
			case eUnitSliderSize.m_micon:
			{
				Image component2 = URST.GetChild(6).GetComponent<Image>();
				component2.sprite = mspeite;
				component2.material = mmaterial;
				component2.SetNativeSize();
				break;
			}
			}
		}
		return true;
	}

	// Token: 0x060006D4 RID: 1748 RVA: 0x0009C1F8 File Offset: 0x0009A3F8
	public bool SetUnitResourcesSliderSize(Transform URST, eUnitSliderSize Kind, float L, float T, float W, float H, float min = 0f, float Max = 0f)
	{
		UnitResourcesSlider component = URST.GetComponent<UnitResourcesSlider>();
		if (component == null)
		{
			return false;
		}
		Vector2 anchoredPosition = new Vector2(L, T);
		Vector2 sizeDelta = new Vector2(W, H);
		int num = (int)Kind;
		switch (Kind)
		{
		case eUnitSliderSize.m_Img:
			num = 4;
			break;
		case eUnitSliderSize.m_micon:
			num = 6;
			break;
		case eUnitSliderSize.m_Text:
			num = 5;
			break;
		}
		RectTransform component2;
		if (Kind == eUnitSliderSize.m_sliderBG1)
		{
			component2 = URST.GetChild(2).GetChild(0).GetComponent<RectTransform>();
		}
		else
		{
			component2 = URST.GetChild(num).GetComponent<RectTransform>();
		}
		component2.anchoredPosition = anchoredPosition;
		component2.sizeDelta = sizeDelta;
		if (num == 2)
		{
			component.m_slider.minValue = (double)min;
			component.m_slider.maxValue = (double)Max;
			component.MaxValue = (long)Max;
			Image component3 = URST.GetChild(2).GetChild(0).GetComponent<Image>();
			component2 = component3.GetComponent<RectTransform>();
			component2.sizeDelta = new Vector2(W, component2.sizeDelta.y);
		}
		return true;
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x0009C308 File Offset: 0x0009A508
	public void InitBadgeTotem(Transform mBadgeT, ushort mEmblem)
	{
		StringBuilder stringBuilder = new StringBuilder();
		Vector2 vector = new Vector2(0.5f, 0.5f);
		Image image = mBadgeT.GetComponent<Image>();
		int num = (int)(mEmblem & 7);
		int num2 = mEmblem >> 3 & 7;
		int num3 = num2 * 8 + num + 1;
		if (num3 > 64)
		{
			num3 = 64;
		}
		int num4 = (mEmblem >> 6 & 63) + 1;
		if (num4 > 64)
		{
			num4 = 64;
		}
		stringBuilder.Length = 0;
		stringBuilder.AppendFormat("UI_league_badge_{0:00}", num3);
		image.sprite = this.LoadBadgeSprite(true, stringBuilder.ToString());
		image.material = this.GetBadgeMaterial(true);
		GameObject gameObject = new GameObject("Image");
		gameObject.layer = 5;
		RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.pivot = vector;
		rectTransform.anchorMin = vector;
		rectTransform.anchorMax = vector;
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		vector.Set(0f, 0f);
		rectTransform.anchoredPosition = vector;
		vector.Set(64f, 64f);
		rectTransform.sizeDelta = vector;
		image = gameObject.AddComponent<Image>();
		stringBuilder.Length = 0;
		stringBuilder.AppendFormat("UI_league_totem_{0:00}", num4);
		image.sprite = this.LoadBadgeSprite(false, stringBuilder.ToString());
		image.material = this.GetBadgeMaterial(false);
		image.SetNativeSize();
		gameObject.transform.SetParent(mBadgeT, false);
		if (num3 > 0)
		{
			mBadgeT.gameObject.SetActive(true);
		}
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x0009C494 File Offset: 0x0009A694
	public void SetBadgeTotemImg(Transform mBadgeT, ushort mEmblem)
	{
		int num = (int)(mEmblem & 7);
		int num2 = mEmblem >> 3 & 7;
		int num3 = num2 * 8 + num + 1;
		if (num3 > 64)
		{
			num3 = 64;
		}
		int num4 = (mEmblem >> 6 & 63) + 1;
		if (num4 > 64)
		{
			num4 = 64;
		}
		this.SetBadgeTotemImg(mBadgeT, num3, num4);
	}

	// Token: 0x060006D7 RID: 1751 RVA: 0x0009C4E0 File Offset: 0x0009A6E0
	public void SetBadgeTotemImg(Transform mBadgeT, int mBadge, int mTotem)
	{
		StringBuilder stringBuilder = new StringBuilder();
		Image component = mBadgeT.GetComponent<Image>();
		stringBuilder.Length = 0;
		stringBuilder.AppendFormat("UI_league_badge_{0:00}", mBadge);
		component.sprite = this.LoadBadgeSprite(true, stringBuilder.ToString());
		component.material = this.GetBadgeMaterial(true);
		component = mBadgeT.GetChild(0).GetComponent<Image>();
		stringBuilder.Length = 0;
		stringBuilder.AppendFormat("UI_league_totem_{0:00}", mTotem);
		component.sprite = this.LoadBadgeSprite(false, stringBuilder.ToString());
		component.material = this.GetBadgeMaterial(false);
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x0009C57C File Offset: 0x0009A77C
	public void HideAllHint()
	{
		if (this.m_ItemInfo.m_RectTransform)
		{
			this.m_ItemInfo.Hide();
		}
		if (this.m_SimpleItemInfo.m_RectTransform)
		{
			this.m_SimpleItemInfo.Hide(this.m_SimpleItemInfo.m_ButtonHint);
		}
		if (this.m_SkillInfo.m_RectTransform)
		{
			this.m_SkillInfo.Hide(this.m_SkillInfo.m_ButtonHint);
		}
		if (this.m_LordInfo.m_RectTransform)
		{
			this.m_LordInfo.Hide(this.m_LordInfo.m_ButtonHint);
		}
		if (this.m_Arena_Hint.m_RectTransform)
		{
			this.m_Arena_Hint.Hide(this.m_Arena_Hint.m_ButtonHint);
		}
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x0009C658 File Offset: 0x0009A858
	public void OpenContinuousUI(ushort ItemID, int HeroID = -1)
	{
		int num = 3;
		this.OpenMenu(EGUIWindow.UI_BagFilter, num + ((int)ItemID << 16), HeroID, false, true, false);
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x0009C67C File Offset: 0x0009A87C
	public void OpenItemFilterUI(ushort ItemID, ushort Num)
	{
		int num = 4;
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_BagFilter, num + ((int)ItemID << 16), (int)Num, false);
		}
	}

	// Token: 0x060006DB RID: 1755 RVA: 0x0009C6BC File Offset: 0x0009A8BC
	public void OpenItemKindFilterUI(ushort ItemKind, byte Property, byte SuitID = 0)
	{
		int num = 6;
		if (BattleController.IsGambleMode)
		{
			GamblingManager.Instance.OpenMenu(EGUIWindow.UI_BagFilter, num + ((int)ItemKind << 16), (int)Property + ((int)SuitID << 16), false);
		}
		else
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.OpenMenu(EGUIWindow.UI_BagFilter, num + ((int)ItemKind << 16), (int)Property + ((int)SuitID << 16), false);
			}
		}
	}

	// Token: 0x060006DC RID: 1756 RVA: 0x0009C728 File Offset: 0x0009A928
	public void OpenGemRemoveUI(ushort ItemPos, byte GemPos)
	{
		int num = 7;
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_BagFilter, num + ((int)ItemPos << 16), (int)GemPos, false);
		}
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x0009C768 File Offset: 0x0009A968
	public void OpenSendGiftUI(CString Tag, CString Name)
	{
		if (!DataManager.Instance.CheckPrizeFlag(9))
		{
			return;
		}
		this.SendTag.ClearString();
		this.SendTag.Append(Tag);
		this.SendName.ClearString();
		this.SendName.Append(Name);
		Door door = this.FindMenu(EGUIWindow.Door) as Door;
		door.OpenMenu(EGUIWindow.UI_BagFilter, 8, 0, false);
	}

	// Token: 0x17000045 RID: 69
	// (get) Token: 0x060006DE RID: 1758 RVA: 0x0009C7D0 File Offset: 0x0009A9D0
	public Material TechMaterial
	{
		get
		{
			return this._TechMaterial;
		}
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x0009C7D8 File Offset: 0x0009A9D8
	public void SetTalentIconSprite(string name, EGUIWindow updateui)
	{
		if (this.TechIconArray != null)
		{
			return;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat("UITechIcon");
		cstring.AppendFormat("UI/{0}");
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.TechIconKey);
		this.TechABRequest = assetBundle.LoadAsync(name, typeof(GameObject));
		this._TechUpdateUI = updateui;
	}

	// Token: 0x060006E0 RID: 1760 RVA: 0x0009C844 File Offset: 0x0009AA44
	public void DestroyTechIconSprite()
	{
		this.TechABRequest = null;
		if (this.TechIconKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.TechIconKey, true);
			this.TechIconKey = 0;
		}
		if (this.TechIconArray == null)
		{
			return;
		}
		UnityEngine.Object.DestroyImmediate(this.TechIconArray.gameObject, true);
		this.TechIconArray = null;
		this.TechIconArrayCN = null;
		this._TechMaterial = null;
	}

	// Token: 0x060006E1 RID: 1761 RVA: 0x0009C8B0 File Offset: 0x0009AAB0
	public Sprite GetTechSprite(ushort id)
	{
		if (this.TechIconArray == null)
		{
			return null;
		}
		if (id == 0)
		{
			return this.TechIconArray.GetSprite(0);
		}
		Sprite sprite;
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			sprite = this.TechIconArrayCN.GetSprite((int)(id - 1));
			if (sprite == null)
			{
				sprite = this.TechIconArray.GetSprite((int)(id - 1));
			}
		}
		else
		{
			sprite = this.TechIconArray.GetSprite((int)(id - 1));
		}
		if (sprite == null)
		{
			return this.TechIconArray.GetSprite(0);
		}
		return sprite;
	}

	// Token: 0x060006E2 RID: 1762 RVA: 0x0009C950 File Offset: 0x0009AB50
	public void InitSynthesisUISaveData()
	{
		this.m_SynthesisItemData = new List<ushort>();
		this.m_SynthesisPageType = e_SynPageType.Synthesis;
	}

	// Token: 0x060006E3 RID: 1763 RVA: 0x0009C964 File Offset: 0x0009AB64
	public void ClearSynthesisUIData()
	{
		this.m_SynthesisItemData.Clear();
		this.m_SynthesisPageType = e_SynPageType.Synthesis;
		this.m_SynthesisScrollIdx = 0;
		this.m_SynthesisScrollRectY = 0f;
		this.m_SynthesisBtnType = LevelTableKind.NormalStage;
		for (int i = 0; i < this.m_RequirementNum.Length; i++)
		{
			this.m_RequirementNum[i] = 0;
			this.m_SynthesisItemNum[i] = 0;
		}
	}

	// Token: 0x060006E4 RID: 1764 RVA: 0x0009C9C8 File Offset: 0x0009ABC8
	public void DestroySynthesisUISaveData()
	{
		this.ClearSynthesisUIData();
		this.m_SynthesisItemData = null;
	}

	// Token: 0x060006E5 RID: 1765 RVA: 0x0009C9D8 File Offset: 0x0009ABD8
	public void CheckSynIsOpned()
	{
		int count = GUIManager.Instance.m_WindowStack.Count;
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < count; i++)
		{
			if (GUIManager.Instance.m_WindowStack[i].m_eWindow == EGUIWindow.UI_Synthesis)
			{
				flag = true;
			}
			if (GUIManager.Instance.m_WindowStack[i].m_eWindow == EGUIWindow.UI_BattleHeroSelect)
			{
				flag2 = true;
			}
		}
		if (flag2 && (flag || GUIManager.Instance.m_IsOpenedUISynthesis))
		{
			count = GUIManager.Instance.m_WindowStack.Count;
			GUIManager.Instance.m_WindowStack.RemoveAt(count - 1);
			count = GUIManager.Instance.m_WindowStack.Count;
			GUIManager.Instance.m_WindowStack.RemoveAt(count - 1);
		}
	}

	// Token: 0x060006E6 RID: 1766 RVA: 0x0009CAB0 File Offset: 0x0009ACB0
	public void OpenTechTree(ushort TechID, bool GuideArrow = false)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		DataManager dataManager = DataManager.Instance;
		if (this.BuildingData.GetBuildNumByID(10) == 0)
		{
			this.BuildingData.ManorGuild(10, GuideArrow);
			door.CloseMenu(true);
			return;
		}
		if (GuideArrow)
		{
			this.GuideParm1 = 3;
			this.GuideParm2 = TechID;
		}
		TechDataTbl recordByKey = dataManager.TechData.GetRecordByKey(TechID);
		TechKindTbl recordByKey2 = dataManager.TechKindData.GetRecordByKey((ushort)recordByKey.Kind);
		int arg = (int)recordByKey.Kind | 32768;
		if (recordByKey.Locked == 1)
		{
			this.AddHUDMessage(dataManager.mStringTable.GetStringByID(7520u), 12, true);
			return;
		}
		GameConstants.GetBytes(0, GUIManager.Instance.TechSaved, 6);
		door.ClearWindowStack();
		if (door.m_eMapMode != EUIOriginMapMode.KingdomMap)
		{
			GUIWindowStackData item;
			item.m_eWindow = EGUIWindow.UI_TechInstitute;
			item.m_Arg1 = (int)this.BuildingData.GetBuildData(10, 0).ManorID;
			item.m_Arg2 = 0;
			item.bCameraMode = false;
			door.m_WindowStack.Add(item);
		}
		door.OpenMenu(EGUIWindow.UI_TechTree, arg, (int)recordByKey2.KindName, false);
		for (int i = 0; i < dataManager.sortTechKindIndex.Length; i++)
		{
			if (dataManager.TechKindData.GetRecordByIndex((int)dataManager.sortTechKindIndex[i]).TechKind == (ushort)recordByKey.Kind)
			{
				this.TechKindSaved[0] = (byte)(i / 4);
				GameConstants.GetBytes((float)this.TechKindSaved[0] * 227f, this.TechKindSaved, 1);
				break;
			}
		}
		ushort arg2 = 0;
		ushort num;
		ushort num2;
		dataManager.GetTechTreeDataRange(recordByKey.Kind, out num, out num2);
		for (ushort num3 = 0; num3 < num2; num3 += 1)
		{
			TechTreeLayoutTbl recordByIndex = dataManager.TechTreeLayout.GetRecordByIndex((int)(num + num3));
			if (recordByIndex.TechID1 == TechID || recordByIndex.TechID2 == TechID || recordByIndex.TechID3 == TechID || recordByIndex.TechID4 == TechID)
			{
				arg2 = num3;
				break;
			}
		}
		this.UpdateUI(EGUIWindow.UI_TechTree, (int)arg2, (int)TechID);
	}

	// Token: 0x060006E7 RID: 1767 RVA: 0x0009CCDC File Offset: 0x0009AEDC
	public void UIQueueLock(EGUIQueueLock bits)
	{
		this.mUIQueueLock |= (int)bits;
	}

	// Token: 0x060006E8 RID: 1768 RVA: 0x0009CCEC File Offset: 0x0009AEEC
	public void UIQueueLockRelease(EGUIQueueLock bits)
	{
		if (this.CheckUIQueueLock(bits))
		{
			this.mUIQueueLock ^= (int)bits;
		}
		if (this.mUIQueueLock == 0)
		{
			this.RestoreQueuedUI();
		}
	}

	// Token: 0x060006E9 RID: 1769 RVA: 0x0009CD1C File Offset: 0x0009AF1C
	private bool CheckUIQueueLock(EGUIQueueLock bits)
	{
		return (this.mUIQueueLock & (int)bits) != 0;
	}

	// Token: 0x060006EA RID: 1770 RVA: 0x0009CD2C File Offset: 0x0009AF2C
	private bool OpenUIRestrict()
	{
		return this.mUIQueueLock == 0;
	}

	// Token: 0x060006EB RID: 1771 RVA: 0x0009CD38 File Offset: 0x0009AF38
	public void OpenUI_Queued_Restricted(EGUIWindow eWin, int arg1 = 0, int arg2 = 0, bool bCameraMode = false, byte openMode = 0)
	{
		if (this.OpenUIRestrict())
		{
			switch (openMode)
			{
			case 0:
				this.OpenMenu(eWin, arg1, arg2, bCameraMode, true, false);
				break;
			case 1:
				this.OpenOtherCanvasMenu(eWin, arg1, arg2);
				break;
			case 2:
			{
				Door door = this.FindMenu(EGUIWindow.Door) as Door;
				door.OpenMenu(eWin, arg1, arg2, bCameraMode);
				break;
			}
			}
		}
		else
		{
			GUIQueueOpen item;
			item.eWin = eWin;
			item.arg1 = arg1;
			item.arg2 = arg2;
			item.bCameraMode = bCameraMode;
			item.mOpenMode = openMode;
			this.GUIQueue.Add(item);
		}
	}

	// Token: 0x060006EC RID: 1772 RVA: 0x0009CDE8 File Offset: 0x0009AFE8
	public void OpenUI_Queued_Restricted_Top(EGUIWindow eWin, int arg1 = 0, int arg2 = 0, bool bCameraMode = false, byte openMode = 0)
	{
		if (this.OpenUIRestrict())
		{
			switch (openMode)
			{
			case 0:
				this.OpenMenu(eWin, arg1, arg2, bCameraMode, true, false);
				break;
			case 1:
				this.OpenOtherCanvasMenu(eWin, arg1, arg2);
				break;
			case 2:
			{
				Door door = this.FindMenu(EGUIWindow.Door) as Door;
				door.OpenMenu(eWin, arg1, arg2, bCameraMode);
				break;
			}
			}
		}
		else
		{
			GUIQueueOpen item;
			item.eWin = eWin;
			item.arg1 = arg1;
			item.arg2 = arg2;
			item.bCameraMode = bCameraMode;
			item.mOpenMode = openMode;
			this.GUIQueue.Insert(0, item);
		}
	}

	// Token: 0x060006ED RID: 1773 RVA: 0x0009CE98 File Offset: 0x0009B098
	public void QueuedUI_Restricted(EGUIWindow eWin, int arg1 = 0, int arg2 = 0, bool bCameraMode = false, byte openMode = 0)
	{
		GUIQueueOpen item;
		item.eWin = eWin;
		item.arg1 = arg1;
		item.arg2 = arg2;
		item.bCameraMode = bCameraMode;
		item.mOpenMode = openMode;
		this.GUIQueue.Add(item);
	}

	// Token: 0x060006EE RID: 1774 RVA: 0x0009CEDC File Offset: 0x0009B0DC
	public void RestoreQueuedUI()
	{
		if (this.GUIQueue.Count == 0)
		{
			return;
		}
		if (this.OpenUIRestrict())
		{
			switch (this.GUIQueue[0].mOpenMode)
			{
			case 0:
				this.OpenMenu(this.GUIQueue[0].eWin, this.GUIQueue[0].arg1, this.GUIQueue[0].arg2, this.GUIQueue[0].bCameraMode, true, false);
				break;
			case 1:
				this.OpenOtherCanvasMenu(this.GUIQueue[0].eWin, this.GUIQueue[0].arg1, this.GUIQueue[0].arg2);
				break;
			case 2:
			{
				Door door = this.FindMenu(EGUIWindow.Door) as Door;
				door.OpenMenu(this.GUIQueue[0].eWin, this.GUIQueue[0].arg1, this.GUIQueue[0].arg2, this.GUIQueue[0].bCameraMode);
				this.GUIQueue.RemoveAt(0);
				this.RestoreQueuedUI();
				return;
			}
			}
			this.GUIQueue.RemoveAt(0);
		}
	}

	// Token: 0x060006EF RID: 1775 RVA: 0x0009D064 File Offset: 0x0009B264
	public bool CheckInQueue(EGUIWindow eWin)
	{
		for (int i = 0; i < this.GUIQueue.Count; i++)
		{
			if (this.GUIQueue[i].eWin == eWin)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060006F0 RID: 1776 RVA: 0x0009D0AC File Offset: 0x0009B2AC
	public bool CanResourceTransport()
	{
		bool result = false;
		if (this.m_ResourceTransportStr == null)
		{
			this.m_ResourceTransportStr = StringManager.Instance.SpawnString(300);
		}
		GUIManager guimanager = GUIManager.Instance;
		StringTable mStringTable = DataManager.Instance.mStringTable;
		RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(17, 0);
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			if (DataManager.Instance.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
			{
				num++;
			}
		}
		if ((long)num >= (long)((ulong)effectBaseVal))
		{
			this.m_ResourceTransportStr.ClearString();
			this.m_ResourceTransportStr.IntToFormat((long)((ulong)effectBaseVal), 1, false);
			this.m_ResourceTransportStr.AppendFormat(mStringTable.GetStringByID(3959u));
			guimanager.OpenMessageBox(mStringTable.GetStringByID(3967u), this.m_ResourceTransportStr.ToString(), null, null, 0, 0, false, false, false, false, false);
		}
		else if (buildData.Level <= 0)
		{
			guimanager.OpenMessageBox(mStringTable.GetStringByID(4834u), mStringTable.GetStringByID(4088u), null, null, 0, 0, false, false, false, false, false);
			result = false;
		}
		else
		{
			result = true;
		}
		return result;
	}

	// Token: 0x060006F1 RID: 1777 RVA: 0x0009D1F0 File Offset: 0x0009B3F0
	public bool CanReinforce()
	{
		bool result = false;
		if (this.m_ResourceTransportStr == null)
		{
			this.m_ResourceTransportStr = StringManager.Instance.SpawnString(30);
		}
		GUIManager guimanager = GUIManager.Instance;
		StringTable mStringTable = DataManager.Instance.mStringTable;
		RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(14, 0);
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			if (DataManager.Instance.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
			{
				num++;
			}
		}
		if (buildData.Level <= 0)
		{
			guimanager.OpenMessageBox(mStringTable.GetStringByID(4834u), mStringTable.GetStringByID(4835u), null, null, 0, 0, false, false, false, false, false);
			result = false;
		}
		else if ((long)num >= (long)((ulong)effectBaseVal))
		{
			this.m_ResourceTransportStr.ClearString();
			this.m_ResourceTransportStr.IntToFormat((long)((ulong)effectBaseVal), 1, false);
			this.m_ResourceTransportStr.AppendFormat(mStringTable.GetStringByID(3959u));
			guimanager.OpenMessageBox(mStringTable.GetStringByID(3967u), this.m_ResourceTransportStr.ToString(), null, null, 0, 0, false, false, false, false, false);
		}
		else
		{
			result = true;
		}
		return result;
	}

	// Token: 0x060006F2 RID: 1778 RVA: 0x0009D330 File Offset: 0x0009B530
	public GUIWindow OpenOtherCanvasMenu(EGUIWindow eWin, int arg1 = 0, int arg2 = 0)
	{
		GUIWindow guiwindow = this.m_WindowList[(int)eWin];
		if (guiwindow != null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("UI/{0}", WindowPrefabData.Data[(int)eWin].m_PrefabName);
		int num = 0;
		AssetBundle assetBundle = AssetManager.GetAssetBundle(stringBuilder.ToString(), out num, false);
		if (assetBundle == null)
		{
			return null;
		}
		GameObject gameObject;
		if (WindowPrefabData.Data[(int)eWin].m_OptName == null)
		{
			gameObject = (GameObject)UnityEngine.Object.Instantiate(assetBundle.mainAsset);
		}
		else
		{
			gameObject = (GameObject)UnityEngine.Object.Instantiate(assetBundle.Load(WindowPrefabData.Data[(int)eWin].m_OptName));
		}
		if (gameObject == null)
		{
			AssetManager.UnloadAssetBundle(num, true);
			return null;
		}
		if (this.m_OtherCanvasLayer == null)
		{
			this.initOtherCanvas();
		}
		gameObject.transform.SetParent(this.m_OtherCanvasTransform, false);
		if (NewbieManager.IsNewbie)
		{
			this.UpdateUI(EGUIWindow.UI_Front, 2, 0);
		}
		guiwindow = (GUIWindow)gameObject.AddComponent(WindowPrefabData.Data[(int)eWin].m_WindowType);
		this.m_WindowList[(int)eWin] = guiwindow;
		this.m_OtheCanvas = guiwindow;
		guiwindow.m_eWindow = eWin;
		guiwindow.m_AssetBundle = assetBundle;
		guiwindow.m_AssetBundleKey = num;
		guiwindow.OnOpen(arg1, arg2);
		return guiwindow;
	}

	// Token: 0x060006F3 RID: 1779 RVA: 0x0009D48C File Offset: 0x0009B68C
	private void initOtherCanvas()
	{
		this.GoSubCam = new GameObject("subCamera");
		this.GoSubCam.transform.localPosition = new Vector3(0f, 500f, 0f);
		Camera camera = this.GoSubCam.AddComponent<Camera>();
		camera.clearFlags = CameraClearFlags.Depth;
		camera.isOrthoGraphic = true;
		camera.cullingMask = 32;
		this.GoSubCanvas = new GameObject("subCanvas");
		this.GoSubCanvas.layer = 5;
		this.m_OtherCanvasLayer = this.GoSubCanvas.AddComponent<RectTransform>();
		Canvas canvas = this.GoSubCanvas.AddComponent<Canvas>();
		canvas.renderMode = RenderMode.ScreenSpaceCamera;
		canvas.worldCamera = camera;
		this.GoSubCanvas.AddComponent<GraphicRaycaster>();
		CanvasScaler canvasScaler = this.GoSubCanvas.AddComponent<CanvasScaler>();
		canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
		canvasScaler.referenceResolution = GUIManager.ResolutionSize;
		canvasScaler.matchWidthOrHeight = 1f;
		this.m_OtherCanvasTransform = new GameObject("Windows")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.m_OtherCanvasTransform.SetParent(this.m_OtherCanvasLayer.transform, false);
		this.StretchTransform(this.m_OtherCanvasTransform);
		if (this.IsArabic)
		{
			this.m_OtherCanvasTransform.localScale = new Vector3(-this.m_OtherCanvasTransform.localScale.x, this.m_OtherCanvasTransform.localScale.y, this.m_OtherCanvasTransform.localScale.z);
		}
	}

	// Token: 0x060006F4 RID: 1780 RVA: 0x0009D604 File Offset: 0x0009B804
	private void DestoryOtherCanvas()
	{
		this.m_OtherCanvasLayer = null;
		if (this.GoSubCam != null)
		{
			UnityEngine.Object.Destroy(this.GoSubCam);
			this.GoSubCam = null;
		}
		if (this.GoSubCanvas != null)
		{
			UnityEngine.Object.Destroy(this.GoSubCanvas);
			this.GoSubCanvas = null;
		}
	}

	// Token: 0x060006F5 RID: 1781 RVA: 0x0009D660 File Offset: 0x0009B860
	public void GuideArrow(RectTransform Target, ArrowDirect ArWay, float offset = 0f)
	{
		if (NewbieManager.IsWorking())
		{
			this.GuideParm1 = 0;
			this.GuideParm2 = 0;
			return;
		}
		if (this.ArrowRect == null)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			this.ArrowRect = door.m_ArrowRC;
			this.ArrowPos = door.m_ArrowPos;
			this.ArrowPos.duration = 0.95f;
			this.ArrowParentRect = (RectTransform)this.ArrowRect.parent;
		}
		if (this.ArrowRect == null || this.ArrowRect.gameObject.activeSelf)
		{
			return;
		}
		Vector2 sizeDelta = this.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta;
		float num = 0f;
		this.ArrowRect.SetParent(Target.parent);
		this.ArrowRect.anchoredPosition3D = Target.anchoredPosition3D;
		Vector3 anchoredPosition3D = this.ArrowRect.anchoredPosition3D;
		anchoredPosition3D.x = anchoredPosition3D.x + this.ArrowRect.sizeDelta.y * (1f - this.ArrowRect.pivot.x) - this.ArrowRect.sizeDelta.y * 0.5f;
		anchoredPosition3D.y = anchoredPosition3D.y + this.ArrowRect.sizeDelta.x * (1f - this.ArrowRect.pivot.y) - this.ArrowRect.sizeDelta.x * 0.5f;
		if (Target.anchorMin.x < 0.5f && Target.anchorMax.x < 0.5f)
		{
			anchoredPosition3D.x = sizeDelta.x * -0.5f + anchoredPosition3D.x;
		}
		else if (Target.anchorMin.x > 0.5f && Target.anchorMax.x > 0.5f)
		{
			anchoredPosition3D.x = sizeDelta.x * 0.5f + anchoredPosition3D.x;
		}
		if (Target.anchorMin.y < 0.5f && Target.anchorMax.y < 0.5f)
		{
			anchoredPosition3D.y = sizeDelta.y * -0.5f + anchoredPosition3D.y;
		}
		else if (Target.anchorMin.y > 0.5f && Target.anchorMax.y > 0.5f)
		{
			anchoredPosition3D.y = sizeDelta.y * 0.5f - anchoredPosition3D.y;
		}
		Quaternion localRotation = this.ArrowRect.localRotation;
		switch (ArWay)
		{
		case ArrowDirect.Ar_Up:
			localRotation.eulerAngles = new Vector3(0f, 0f, 270f);
			if (Target.pivot.x < 0.5f)
			{
				anchoredPosition3D.x += Target.sizeDelta.x * 0.5f;
			}
			if (Target.pivot.y < 0.5f)
			{
				anchoredPosition3D.y += Target.sizeDelta.y * 0.5f;
			}
			anchoredPosition3D.y += Target.sizeDelta.y * 0.5f + this.ArrowRect.sizeDelta.y * 0.5f;
			num = 40f;
			break;
		case ArrowDirect.Ar_Down:
			localRotation.eulerAngles = new Vector3(0f, 0f, 90f);
			if (Target.pivot.x < 0.5f)
			{
				anchoredPosition3D.x -= Target.sizeDelta.x * 0.5f;
			}
			if (Target.pivot.x < 0.5f)
			{
				anchoredPosition3D.y -= Target.sizeDelta.y * 0.5f;
			}
			anchoredPosition3D.y -= Target.sizeDelta.y * 0.5f + this.ArrowRect.sizeDelta.y * 0.5f;
			num = -40f;
			break;
		case ArrowDirect.Ar_Left:
			localRotation.eulerAngles = Vector3.zero;
			if (Target.pivot.x < 0.5f)
			{
				anchoredPosition3D.x -= Target.sizeDelta.x * 0.5f;
			}
			if (Target.pivot.y < 0.5f)
			{
				anchoredPosition3D.y -= Target.sizeDelta.y * 0.5f;
			}
			anchoredPosition3D.x -= Target.sizeDelta.x * 0.5f + this.ArrowRect.sizeDelta.x * 0.5f;
			num = -40f;
			break;
		case ArrowDirect.Ar_Right:
			localRotation.eulerAngles = new Vector3(0f, 0f, 180f);
			if (Target.pivot.x < 0.5f)
			{
				anchoredPosition3D.x += Target.sizeDelta.x * 0.5f;
			}
			if (Target.pivot.y < 0.5f)
			{
				anchoredPosition3D.y += Target.sizeDelta.y * 0.5f;
			}
			anchoredPosition3D.x += Target.sizeDelta.x * 0.5f + this.ArrowRect.sizeDelta.x * 0.5f;
			num = 40f;
			break;
		}
		this.ArrowRect.localRotation = localRotation;
		this.ArrowRect.anchoredPosition3D = anchoredPosition3D;
		if (ArWay == ArrowDirect.Ar_Up || ArWay == ArrowDirect.Ar_Down)
		{
			this.ArrowPos.from = new Vector3(anchoredPosition3D.x, anchoredPosition3D.y + offset, anchoredPosition3D.z);
			this.ArrowPos.to = new Vector3(anchoredPosition3D.x, anchoredPosition3D.y + num + offset, anchoredPosition3D.z);
		}
		else
		{
			this.ArrowPos.from = new Vector3(anchoredPosition3D.x + offset, anchoredPosition3D.y, anchoredPosition3D.z);
			this.ArrowPos.to = new Vector3(anchoredPosition3D.x + num + offset, anchoredPosition3D.y, anchoredPosition3D.z);
		}
		this.ArrowRect.gameObject.SetActive(true);
		this.UpdateArrow = 2;
	}

	// Token: 0x060006F6 RID: 1782 RVA: 0x0009DDC0 File Offset: 0x0009BFC0
	public void GuideArrow_Position(Vector3 Pos, ArrowDirect ArWay)
	{
		if (NewbieManager.IsWorking())
		{
			this.GuideParm1 = 0;
			this.GuideParm2 = 0;
			return;
		}
		if (this.ArrowRect == null)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			this.ArrowRect = door.m_ArrowRC;
			this.ArrowPos = door.m_ArrowPos;
			this.ArrowPos.duration = 0.95f;
			this.ArrowParentRect = (RectTransform)this.ArrowRect.parent;
		}
		if (this.ArrowRect == null || this.ArrowRect.gameObject.activeSelf)
		{
			return;
		}
		this.ArrowRect.localScale = Vector2.one;
		Vector2 sizeDelta = this.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta;
		float num = 0f;
		Quaternion localRotation = this.ArrowRect.localRotation;
		switch (ArWay)
		{
		case ArrowDirect.Ar_Up:
			localRotation.eulerAngles = new Vector3(0f, 0f, 270f);
			num = 40f;
			break;
		case ArrowDirect.Ar_Down:
			localRotation.eulerAngles = new Vector3(0f, 0f, 90f);
			num = -40f;
			break;
		case ArrowDirect.Ar_Left:
			localRotation.eulerAngles = Vector3.zero;
			num = -40f;
			break;
		case ArrowDirect.Ar_Right:
			localRotation.eulerAngles = new Vector3(0f, 0f, 180f);
			num = 40f;
			break;
		}
		this.ArrowRect.localRotation = localRotation;
		this.ArrowRect.anchoredPosition3D = Pos;
		if (ArWay == ArrowDirect.Ar_Up || ArWay == ArrowDirect.Ar_Down)
		{
			this.ArrowPos.from = new Vector3(Pos.x, Pos.y, Pos.z);
			this.ArrowPos.to = new Vector3(Pos.x, Pos.y + num, Pos.z);
		}
		else
		{
			this.ArrowPos.from = new Vector3(Pos.x, Pos.y, Pos.z);
			this.ArrowPos.to = new Vector3(Pos.x + num, Pos.y, Pos.z);
		}
		this.ArrowRect.gameObject.SetActive(true);
		this.UpdateArrow = 2;
	}

	// Token: 0x060006F7 RID: 1783 RVA: 0x0009E02C File Offset: 0x0009C22C
	public void HideArrow(bool bClearParm = false)
	{
		if (this.ArrowRect != null && this.ArrowRect.gameObject.activeSelf)
		{
			this.ArrowRect.gameObject.SetActive(false);
			this.GuideParm1 = 0;
			this.GuideParm2 = 0;
		}
		else if (bClearParm)
		{
			this.GuideParm1 = 0;
			this.GuideParm2 = 0;
		}
	}

	// Token: 0x060006F8 RID: 1784 RVA: 0x0009E098 File Offset: 0x0009C298
	public void SetFrontMark(byte Val)
	{
		PlayerPrefs.SetString("Front_Guide", Val.ToString());
	}

	// Token: 0x060006F9 RID: 1785 RVA: 0x0009E0AC File Offset: 0x0009C2AC
	public void AddHerodLvUpData(ushort heroID, byte beginLv, byte targetLv)
	{
		bool flag = false;
		if (this.m_HerodLvUpData != null)
		{
			for (int i = 0; i < this.m_HerodLvUpData.Count; i++)
			{
				if (this.m_HerodLvUpData[i].HeroID == heroID)
				{
					flag = true;
					sHeroLvUp sHeroLvUp = this.m_HerodLvUpData[i];
					sHeroLvUp.HeroID = heroID;
					sHeroLvUp.BeginLv = beginLv;
					sHeroLvUp.TargetLv = targetLv;
					this.m_HerodLvUpData[i] = sHeroLvUp;
				}
			}
		}
		if (!flag)
		{
			sHeroLvUp sHeroLvUp = default(sHeroLvUp);
			sHeroLvUp.HeroID = heroID;
			sHeroLvUp.BeginLv = beginLv;
			sHeroLvUp.TargetLv = targetLv;
			this.m_HerodLvUpData.Add(sHeroLvUp);
		}
	}

	// Token: 0x060006FA RID: 1786 RVA: 0x0009E164 File Offset: 0x0009C364
	public void SetRoleAttrDiamond(uint diamond, ushort itemID = 0, eSpentCredits type = eSpentCredits.eMax)
	{
		if (diamond < DataManager.Instance.RoleAttr.Diamond)
		{
			string content_type = string.Empty;
			string content_id = string.Empty;
			int num = (int)(DataManager.Instance.RoleAttr.Diamond - diamond);
			if (itemID != 0)
			{
				Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(itemID);
				content_type = ((EItemType)(recordByKey.EquipKind - 1)).ToString();
				content_id = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.EquipName);
			}
			else if (type < (eSpentCredits)this.SpentCreditsStr.Length)
			{
				content_type = this.SpentCreditsStr[(int)type];
			}
			IGGSDKPlugin.SetFacebookEventSpentCredits((double)num, content_type, content_id);
		}
		if (diamond > 100000000u)
		{
			diamond = 100000000u;
		}
		DataManager.Instance.RoleAttr.Diamond = diamond;
	}

	// Token: 0x060006FB RID: 1787 RVA: 0x0009E230 File Offset: 0x0009C430
	public void ClearCalculator()
	{
		if (this.Obj_UICalculator != null)
		{
			UnityEngine.Object.Destroy(this.Obj_UICalculator);
			this.Obj_UICalculator = null;
			this.m_UICalculator.mUnitRslider = null;
		}
	}

	// Token: 0x060006FC RID: 1788 RVA: 0x0009E264 File Offset: 0x0009C464
	public void OnUIBattlePause(bool pause)
	{
		if (pause)
		{
			UILegBattle uilegBattle = (UILegBattle)this.FindMenu(EGUIWindow.UI_LegBattle);
			if (uilegBattle != null)
			{
				uilegBattle.OnBattlePause();
			}
			UIBattle uibattle = (UIBattle)this.FindMenu(EGUIWindow.UI_Battle);
			if (uibattle != null)
			{
				uibattle.OnBattlePause();
			}
		}
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x0009E2B8 File Offset: 0x0009C4B8
	public void OpenCanonizedPanel(CString name, byte backgroundType, int btnType)
	{
		if (name != null && this.CanonizedName != null)
		{
			this.CanonizedName.ClearString();
			this.CanonizedName.Append(name);
			this.OpenMenu(EGUIWindow.UI_CanonizedPanel, (int)backgroundType, btnType, true, true, false);
		}
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x0009E300 File Offset: 0x0009C500
	public void OpenPreviewHeroInfo(ushort HeroID, bool Curhero = true, byte Lv = 60, byte Enhance = 8, byte Star = 5, byte Equip = 63, int mIdx = 0)
	{
		DataManager dataManager = DataManager.Instance;
		dataManager.PreviewHeroData.ID = HeroID;
		dataManager.PreviewHeroData.Level = Lv;
		dataManager.PreviewHeroData.SkillLV = new byte[4];
		dataManager.PreviewHeroData.Enhance = Enhance;
		dataManager.PreviewHeroData.Star = Star;
		dataManager.PreviewHeroData.Equip = Equip;
		dataManager.PreviewHeroData.SkillLV[0] = Lv;
		if (dataManager.PreviewHeroData.Enhance >= 2)
		{
			dataManager.PreviewHeroData.SkillLV[1] = Lv;
		}
		else
		{
			dataManager.PreviewHeroData.SkillLV[1] = 0;
		}
		if (dataManager.PreviewHeroData.Enhance >= 4 && Lv - 20 > 0)
		{
			dataManager.PreviewHeroData.SkillLV[2] = Lv - 20;
		}
		else
		{
			dataManager.PreviewHeroData.SkillLV[2] = 0;
		}
		if (dataManager.PreviewHeroData.Enhance >= 7 && Lv - 40 > 0)
		{
			dataManager.PreviewHeroData.SkillLV[3] = Lv - 40;
		}
		else
		{
			dataManager.PreviewHeroData.SkillLV[3] = 0;
		}
		int arg = 0;
		if (!Curhero)
		{
			arg = 1;
			this.UIPreviewHero_Index = mIdx;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Synthesis, 1, 0);
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Hero_Info))
			{
				door.CloseMenu(false);
			}
			door.OpenMenu(EGUIWindow.UI_Hero_Info, arg, 1, true);
		}
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x0009E488 File Offset: 0x0009C688
	public void SetChallegeRewardUI(int CrystalNum, ushort stageID, byte difficult)
	{
		if (CrystalNum > 0)
		{
			GUIManager.Instance.OpenMenu(EGUIWindow.UI_ChallegeTreasure, CrystalNum, (int)stageID << 8 | (int)difficult, false, true, false);
		}
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x0009E4B8 File Offset: 0x0009C6B8
	public void OpenChallegeRewardUI()
	{
		GUIManager.instance.UpdateUI(EGUIWindow.UI_ChallegeTreasure, 1000, 0);
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x0009E4D0 File Offset: 0x0009C6D0
	public EmojiUnit pullEmojiIcon(ushort iconid, byte defaultSpriteID = 0, bool isSpriteRenderer = false)
	{
		return (this.EmojiManager == null) ? null : this.EmojiManager.pullIcon(iconid, defaultSpriteID, isSpriteRenderer);
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x0009E4F4 File Offset: 0x0009C6F4
	public void pushEmojiIcon(EmojiUnit inIcon)
	{
		if (this.EmojiManager != null)
		{
			this.EmojiManager.pushIcon(inIcon);
		}
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x0009E510 File Offset: 0x0009C710
	public bool SetFastivalImage(byte packID, ushort imageID, Image TargetImage)
	{
		if (packID == 0)
		{
			return false;
		}
		if (!this.m_FastivalIconSet.ContainsKey(packID) && this.currentIconCount < this.m_FastivalIconSpriteAssets.Length)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Festival_icon_{0:000}", packID);
			this.m_FastivalIconSpriteAssets[this.currentIconCount].InitialAsset(stringBuilder.ToString());
			if (this.m_FastivalIconSpriteAssets[this.currentIconCount].GetMaterial() == null)
			{
				return false;
			}
			this.m_FastivalIconSet.Add(packID, this.currentIconCount++);
		}
		int num;
		if (!this.m_FastivalIconSet.TryGetValue(packID, out num))
		{
			return false;
		}
		if (TargetImage == null)
		{
			return false;
		}
		TargetImage.material = this.m_FastivalIconSpriteAssets[num].GetMaterial();
		TargetImage.sprite = this.m_FastivalIconSpriteAssets[num].LoadSprite(imageID);
		return true;
	}

	// Token: 0x06000704 RID: 1796 RVA: 0x0009E610 File Offset: 0x0009C810
	public void Free()
	{
		if (this.EmojiManager != null)
		{
			this.EmojiManager.OnDestroy();
		}
		this.EmojiManager = null;
	}

	// Token: 0x04001878 RID: 6264
	public const float UILockMaxTime = 1f;

	// Token: 0x04001879 RID: 6265
	public const float UILockHalftime = 0.5f;

	// Token: 0x0400187A RID: 6266
	private const byte ChannelCount = 2;

	// Token: 0x0400187B RID: 6267
	private const int LanguageMax = 2;

	// Token: 0x0400187C RID: 6268
	private const int BackMGCount = 5;

	// Token: 0x0400187D RID: 6269
	private const int BackMG_TitleLen = 241;

	// Token: 0x0400187E RID: 6270
	private const int BackMG_MessageLen = 1025;

	// Token: 0x0400187F RID: 6271
	private const float m_BBTotalTime = 0.1f;

	// Token: 0x04001880 RID: 6272
	private const float m_BBWaitTotalTime = 1f;

	// Token: 0x04001881 RID: 6273
	private const float m_BBFadeOutTotalTime = 1f;

	// Token: 0x04001882 RID: 6274
	public const int NPCMessageID = 9591;

	// Token: 0x04001883 RID: 6275
	public const int NPCErrorMessageID = 9592;

	// Token: 0x04001884 RID: 6276
	public const byte MAX_NPCCITY_REWARD = 3;

	// Token: 0x04001885 RID: 6277
	public const byte SaveEmojiKeyCount = 8;

	// Token: 0x04001886 RID: 6278
	public static Vector2 ResolutionSize = new Vector2(853f, 640f);

	// Token: 0x04001887 RID: 6279
	private static GUIManager instance;

	// Token: 0x04001888 RID: 6280
	private long m_LastServerTime;

	// Token: 0x04001889 RID: 6281
	private int Key;

	// Token: 0x0400188A RID: 6282
	private bool m_bLoadAsset;

	// Token: 0x0400188B RID: 6283
	private bool bRebuildFont;

	// Token: 0x0400188C RID: 6284
	private Font m_TTFFont;

	// Token: 0x0400188D RID: 6285
	private AssetBundle m_TTFFontBundle;

	// Token: 0x0400188E RID: 6286
	private Dictionary<int, SpriteAsset> m_SpriteAssetDict;

	// Token: 0x0400188F RID: 6287
	public IconSpriteAsset m_IconSpriteAsset;

	// Token: 0x04001890 RID: 6288
	public IconSpriteAsset m_ItemIconSpriteAsset;

	// Token: 0x04001891 RID: 6289
	public IconSpriteAsset m_LeadItemIconSpriteAsset;

	// Token: 0x04001892 RID: 6290
	public IconSpriteAsset m_LeadMatIconSpriteAsset;

	// Token: 0x04001893 RID: 6291
	public IconSpriteAsset m_ConditiontIconSpriteAsset;

	// Token: 0x04001894 RID: 6292
	private int currentIconCount;

	// Token: 0x04001895 RID: 6293
	private IconSpriteAsset[] m_FastivalIconSpriteAssets = new IconSpriteAsset[5];

	// Token: 0x04001896 RID: 6294
	private Dictionary<byte, int> m_FastivalIconSet;

	// Token: 0x04001897 RID: 6295
	private Sprite[] m_WondersiconSprite;

	// Token: 0x04001898 RID: 6296
	private int WondericonAssKey;

	// Token: 0x04001899 RID: 6297
	private Sprite _NpcHead;

	// Token: 0x0400189A RID: 6298
	private Material _m_WonderMaterial;

	// Token: 0x0400189B RID: 6299
	public SpriteAsset m_BadgeSpriteAsset;

	// Token: 0x0400189C RID: 6300
	public SpriteAsset m_TotemSpriteAsset;

	// Token: 0x0400189D RID: 6301
	public SpriteAsset m_SkillSpriteAsset;

	// Token: 0x0400189E RID: 6302
	public SpriteAsset m_AllianceBoxAsset;

	// Token: 0x0400189F RID: 6303
	public SpriteAsset m_LeagueGO_iconAsset;

	// Token: 0x040018A0 RID: 6304
	public SpriteAsset m_EmojiSpriteAsset;

	// Token: 0x040018A1 RID: 6305
	public SpriteAsset m_TitleSpriteAsset;

	// Token: 0x040018A2 RID: 6306
	private SpriteAsset m_FrameSpriteAsset;

	// Token: 0x040018A3 RID: 6307
	public AssetBundle m_ManagerAssetBundle;

	// Token: 0x040018A4 RID: 6308
	public AssetBundle m_ManagerAssetBundle2;

	// Token: 0x040018A5 RID: 6309
	private int m_ManagerAssetBundleKey;

	// Token: 0x040018A6 RID: 6310
	private int m_ManagerAssetBundleKey2;

	// Token: 0x040018A7 RID: 6311
	public AssetBundle m_EffectAssetBundle;

	// Token: 0x040018A8 RID: 6312
	private int m_EffectAssetBundleKey;

	// Token: 0x040018A9 RID: 6313
	public CString LoadSpriteStr = new CString(512);

	// Token: 0x040018AA RID: 6314
	public Canvas m_UICanvas;

	// Token: 0x040018AB RID: 6315
	public bool m_Orthographic;

	// Token: 0x040018AC RID: 6316
	public byte m_OrthographicCount;

	// Token: 0x040018AD RID: 6317
	public Canvas m_UICanvas2;

	// Token: 0x040018AE RID: 6318
	private GameObject m_UICanvas2GO;

	// Token: 0x040018AF RID: 6319
	private GUIWindow[] m_WindowList;

	// Token: 0x040018B0 RID: 6320
	public GUIWindow m_Window1;

	// Token: 0x040018B1 RID: 6321
	public GUIWindow m_Window2;

	// Token: 0x040018B2 RID: 6322
	public GUIWindow m_SecWindow;

	// Token: 0x040018B3 RID: 6323
	public GUIWindow m_OtheCanvas;

	// Token: 0x040018B4 RID: 6324
	private GameObject GoSubCam;

	// Token: 0x040018B5 RID: 6325
	private GameObject GoSubCanvas;

	// Token: 0x040018B6 RID: 6326
	public GUIWindow Chatwin;

	// Token: 0x040018B7 RID: 6327
	private int ChatabKey;

	// Token: 0x040018B8 RID: 6328
	private AssetBundle Chatab;

	// Token: 0x040018B9 RID: 6329
	public GameObject m_Chat;

	// Token: 0x040018BA RID: 6330
	private EUIOriginMode window2mode;

	// Token: 0x040018BB RID: 6331
	public RectTransform m_BottomLayer;

	// Token: 0x040018BC RID: 6332
	public RectTransform m_WindowsTransform;

	// Token: 0x040018BD RID: 6333
	public RectTransform m_ChatLayer;

	// Token: 0x040018BE RID: 6334
	public RectTransform m_TopLayer;

	// Token: 0x040018BF RID: 6335
	public RectTransform m_WindowTopLayer;

	// Token: 0x040018C0 RID: 6336
	public RectTransform m_ItemInfoLayer;

	// Token: 0x040018C1 RID: 6337
	public RectTransform m_BattleMessageLayer;

	// Token: 0x040018C2 RID: 6338
	public RectTransform m_SecWindowLayer;

	// Token: 0x040018C3 RID: 6339
	public RectTransform m_FourthWindowLayer;

	// Token: 0x040018C4 RID: 6340
	public RectTransform m_NewbieLayer;

	// Token: 0x040018C5 RID: 6341
	public RectTransform m_MessageBoxLayer;

	// Token: 0x040018C6 RID: 6342
	public RectTransform m_OtherCanvasLayer;

	// Token: 0x040018C7 RID: 6343
	public RectTransform m_OtherCanvasTransform;

	// Token: 0x040018C8 RID: 6344
	private GameObject m_OKCancelBox;

	// Token: 0x040018C9 RID: 6345
	private UIButton m_OKCancelCloseButton;

	// Token: 0x040018CA RID: 6346
	private GUIWindow m_OKCancelBoxHandler;

	// Token: 0x040018CB RID: 6347
	private CString m_OKString;

	// Token: 0x040018CC RID: 6348
	private CString m_OKString2;

	// Token: 0x040018CD RID: 6349
	private CString m_OKString_ItemCount;

	// Token: 0x040018CE RID: 6350
	private CString m_OKString_Info;

	// Token: 0x040018CF RID: 6351
	private int m_OKCancelBoxArg1;

	// Token: 0x040018D0 RID: 6352
	private int m_OKCancelBoxArg2;

	// Token: 0x040018D1 RID: 6353
	private int m_OKCancelClickIndex = -1;

	// Token: 0x040018D2 RID: 6354
	private UseOrSpendType useOrSpendType = UseOrSpendType.UST_MAX;

	// Token: 0x040018D3 RID: 6355
	public UIItemInfo m_ItemInfo = new UIItemInfo();

	// Token: 0x040018D4 RID: 6356
	public UISimpleItemInfo m_SimpleItemInfo = new UISimpleItemInfo();

	// Token: 0x040018D5 RID: 6357
	public UISkillInfo m_SkillInfo = new UISkillInfo();

	// Token: 0x040018D6 RID: 6358
	public UILordItemInfo m_LordInfo = new UILordItemInfo();

	// Token: 0x040018D7 RID: 6359
	public UIHintMask HintMaskObj = new UIHintMask();

	// Token: 0x040018D8 RID: 6360
	public AssetBundle m_Arena_HintAssetBundle;

	// Token: 0x040018D9 RID: 6361
	private int m_Arena_HintAssetBundleKey;

	// Token: 0x040018DA RID: 6362
	public UIArena_Hint m_Arena_Hint = new UIArena_Hint();

	// Token: 0x040018DB RID: 6363
	public UIHint m_Hint = new UIHint();

	// Token: 0x040018DC RID: 6364
	public SpeciallyEffect m_SpeciallyEffect = new SpeciallyEffect();

	// Token: 0x040018DD RID: 6365
	public int TmpCount;

	// Token: 0x040018DE RID: 6366
	public Vector2 mStartV2 = Vector2.zero;

	// Token: 0x040018DF RID: 6367
	public SpeciallyEffect_Kind[] SE_Kind = new SpeciallyEffect_Kind[7];

	// Token: 0x040018E0 RID: 6368
	public uint[] SE_Stock = new uint[5];

	// Token: 0x040018E1 RID: 6369
	public ushort[] SE_ItemID = new ushort[3];

	// Token: 0x040018E2 RID: 6370
	public byte[] SE_Item_L_Color = new byte[3];

	// Token: 0x040018E3 RID: 6371
	public AssetBundle m_CalculatorAssetBundle;

	// Token: 0x040018E4 RID: 6372
	private int m_CalculatorAssetBundleKey;

	// Token: 0x040018E5 RID: 6373
	public UICalculator m_UICalculator = new UICalculator();

	// Token: 0x040018E6 RID: 6374
	public GameObject Obj_UICalculator;

	// Token: 0x040018E7 RID: 6375
	public CString m_CalculatorStr;

	// Token: 0x040018E8 RID: 6376
	public RectTransform m_LockPanelLayer;

	// Token: 0x040018E9 RID: 6377
	private RectTransform m_LockPanel;

	// Token: 0x040018EA RID: 6378
	private EUILock m_eUILock;

	// Token: 0x040018EB RID: 6379
	private byte m_UILockCount;

	// Token: 0x040018EC RID: 6380
	private float m_UILockTime;

	// Token: 0x040018ED RID: 6381
	public RectTransform m_HUDsTransform;

	// Token: 0x040018EE RID: 6382
	public HUDMessageMgr m_HUDMessage;

	// Token: 0x040018EF RID: 6383
	public DamageValueManager pDVMgr;

	// Token: 0x040018F0 RID: 6384
	private Color ABColor = Color.white;

	// Token: 0x040018F1 RID: 6385
	private Color MyColor = new Color(0.2f, 0.2f, 0.2f, 1f);

	// Token: 0x040018F2 RID: 6386
	private float TimeBarTitleWidth;

	// Token: 0x040018F3 RID: 6387
	public bool bCheckDeleteMsg = true;

	// Token: 0x040018F4 RID: 6388
	public bool bCheckStoneTrans = true;

	// Token: 0x040018F5 RID: 6389
	public bool bOpenOnIPhoneX;

	// Token: 0x040018F6 RID: 6390
	public float IPhoneX_DeltaX = 53f;

	// Token: 0x040018F7 RID: 6391
	public int OpenBoxCount;

	// Token: 0x040018F8 RID: 6392
	public uint CommonGetCrystal;

	// Token: 0x040018F9 RID: 6393
	public uint CommonGetAllianceCoin;

	// Token: 0x040018FA RID: 6394
	public List<CommonItemDataType> CommonItemData = new List<CommonItemDataType>();

	// Token: 0x040018FB RID: 6395
	public bool m_OpenResourceMenu;

	// Token: 0x040018FC RID: 6396
	public uint[] m_SendResource = new uint[5];

	// Token: 0x040018FD RID: 6397
	public uint[] m_SaveResource = new uint[5];

	// Token: 0x040018FE RID: 6398
	public GameObject m_BMGO;

	// Token: 0x040018FF RID: 6399
	public Transform m_BMContentT;

	// Token: 0x04001900 RID: 6400
	public Transform m_BMButtonT;

	// Token: 0x04001901 RID: 6401
	private UIText m_BMBtnText;

	// Token: 0x04001902 RID: 6402
	private UIText m_BMText1;

	// Token: 0x04001903 RID: 6403
	private UIText m_BMText2;

	// Token: 0x04001904 RID: 6404
	public int m_BMAssetBundleKey;

	// Token: 0x04001905 RID: 6405
	public uint BattleSerialNo;

	// Token: 0x04001906 RID: 6406
	public uint SerialNo;

	// Token: 0x04001907 RID: 6407
	private CString m_BMATStr;

	// Token: 0x04001908 RID: 6408
	private CString m_BMNStr;

	// Token: 0x04001909 RID: 6409
	private CString m_BMMessage1;

	// Token: 0x0400190A RID: 6410
	private GUIManager.ECombatLiveType m_BMNowLiveType;

	// Token: 0x0400190B RID: 6411
	private POINT_KIND m_BMNowPointKind;

	// Token: 0x0400190C RID: 6412
	private ushort m_BMNowKingdomID;

	// Token: 0x0400190D RID: 6413
	private float m_BMTime = -1f;

	// Token: 0x0400190E RID: 6414
	private bool bSendShow;

	// Token: 0x0400190F RID: 6415
	private bool bGPShow = true;

	// Token: 0x04001910 RID: 6416
	private bool bWarAttacker;

	// Token: 0x04001911 RID: 6417
	private bool bInFightHideChat;

	// Token: 0x04001912 RID: 6418
	private Image m_BMLight;

	// Token: 0x04001913 RID: 6419
	private float m_BMLightTime;

	// Token: 0x04001914 RID: 6420
	private float m_BMLightMaxTime = 1f;

	// Token: 0x04001915 RID: 6421
	public ushort WM_RandomSeed;

	// Token: 0x04001916 RID: 6422
	public byte WM_RandomGap;

	// Token: 0x04001917 RID: 6423
	public byte WM_Combo;

	// Token: 0x04001918 RID: 6424
	public HeroBattleData[] WM_HeroData = new HeroBattleData[5];

	// Token: 0x04001919 RID: 6425
	public byte WM_HeroCount;

	// Token: 0x0400191A RID: 6426
	public ushort WM_MonsterID;

	// Token: 0x0400191B RID: 6427
	public byte WM_MonsterLv;

	// Token: 0x0400191C RID: 6428
	public uint WM_MonsterNowHP;

	// Token: 0x0400191D RID: 6429
	public uint WM_MonsterMaxHP;

	// Token: 0x0400191E RID: 6430
	public MonsterAttrDataType WM_MonsterAttr = default(MonsterAttrDataType);

	// Token: 0x0400191F RID: 6431
	public CString WM_MonsterTagStr = new CString(4);

	// Token: 0x04001920 RID: 6432
	public byte WM_NPCLevel;

	// Token: 0x04001921 RID: 6433
	public int RandomIndex = -1;

	// Token: 0x04001922 RID: 6434
	public RectTransform m_ChatBox;

	// Token: 0x04001923 RID: 6435
	public RectTransform m_ChatScrollRectRC;

	// Token: 0x04001924 RID: 6436
	public CScrollRect m_ChatScrollRect;

	// Token: 0x04001925 RID: 6437
	private Transform m_ChatContentT;

	// Token: 0x04001926 RID: 6438
	private Mask m_ChatMask;

	// Token: 0x04001927 RID: 6439
	public Image m_ChatImage;

	// Token: 0x04001928 RID: 6440
	private Sprite ChannelSpriteOn;

	// Token: 0x04001929 RID: 6441
	private Sprite ChannelSpriteOff;

	// Token: 0x0400192A RID: 6442
	public Image m_ChatChannelLight;

	// Token: 0x0400192B RID: 6443
	public Image m_ChatChannelLight1;

	// Token: 0x0400192C RID: 6444
	public Image m_ChatChannelLight2;

	// Token: 0x0400192D RID: 6445
	private GameObject m_ChannelLightFlashGO;

	// Token: 0x0400192E RID: 6446
	public byte ChannelIndex;

	// Token: 0x0400192F RID: 6447
	private ChatChannel[] m_ChatChannel = new ChatChannel[2];

	// Token: 0x04001930 RID: 6448
	private UIText NoAllianceText;

	// Token: 0x04001931 RID: 6449
	public GameObject m_ChatBoxGO;

	// Token: 0x04001932 RID: 6450
	private int m_ChatBoxAssetKey;

	// Token: 0x04001933 RID: 6451
	public int PreLeadLevel = -1;

	// Token: 0x04001934 RID: 6452
	public bool bOpenHeroBtn;

	// Token: 0x04001935 RID: 6453
	public bool bOpenAllianceBtn;

	// Token: 0x04001936 RID: 6454
	public bool bNeedForceOpenFuncBtn;

	// Token: 0x04001937 RID: 6455
	private GameObject m_LvUpGO;

	// Token: 0x04001938 RID: 6456
	private int m_LvUpAssetBundleKey;

	// Token: 0x04001939 RID: 6457
	private GameObject m_BackMGGO;

	// Token: 0x0400193A RID: 6458
	private int m_BackMGAssetBundleKey;

	// Token: 0x0400193B RID: 6459
	private long m_BackMGBeginTime;

	// Token: 0x0400193C RID: 6460
	private long m_BackMGEndTime;

	// Token: 0x0400193D RID: 6461
	private uint m_BackMGDeltaTime;

	// Token: 0x0400193E RID: 6462
	private CString m_BackMGTitle = new CString(242);

	// Token: 0x0400193F RID: 6463
	private CString m_BackMGMessage = new CString(1026);

	// Token: 0x04001940 RID: 6464
	private bool m_BackMGWaitOpen;

	// Token: 0x04001941 RID: 6465
	private byte m_SystemInChatIndex;

	// Token: 0x04001942 RID: 6466
	private BackMG[] m_SystemInChat = new BackMG[5];

	// Token: 0x04001943 RID: 6467
	private byte m_RunningTextIndex;

	// Token: 0x04001944 RID: 6468
	private BackMG[] m_RunningText = new BackMG[5];

	// Token: 0x04001945 RID: 6469
	public List<CString> m_RunningTextList = new List<CString>();

	// Token: 0x04001946 RID: 6470
	public CExternalTableWithWordKey<LoadingTalk> LoadingTalkTable;

	// Token: 0x04001947 RID: 6471
	public GUIWindow LTWin;

	// Token: 0x04001948 RID: 6472
	public GUIWindow TBoxWin;

	// Token: 0x04001949 RID: 6473
	private GameObject m_BattleBeginGO;

	// Token: 0x0400194A RID: 6474
	private RectTransform m_LeftRC;

	// Token: 0x0400194B RID: 6475
	private RectTransform m_RightRC;

	// Token: 0x0400194C RID: 6476
	private CanvasGroup m_BBCanvasGroup;

	// Token: 0x0400194D RID: 6477
	private UIText[] m_bbText = new UIText[6];

	// Token: 0x0400194E RID: 6478
	private CString[] m_bbCString = new CString[3];

	// Token: 0x0400194F RID: 6479
	private int m_BattleBeginAssetBundleKey;

	// Token: 0x04001950 RID: 6480
	private float m_BBDeltaTime;

	// Token: 0x04001951 RID: 6481
	private GUIManager.eBBSetp m_BBStep = GUIManager.eBBSetp.eMax;

	// Token: 0x04001952 RID: 6482
	private bool bShowWonder;

	// Token: 0x04001953 RID: 6483
	private long NowBeginTime;

	// Token: 0x04001954 RID: 6484
	private long ShowRunningTime;

	// Token: 0x04001955 RID: 6485
	public TimeEventDataType WonderCountTime;

	// Token: 0x04001956 RID: 6486
	public List<CString> WonderCountStr = new List<CString>();

	// Token: 0x04001957 RID: 6487
	private long KOW_ShowRunningTime;

	// Token: 0x04001958 RID: 6488
	public List<CString> KOWCountStr = new List<CString>();

	// Token: 0x04001959 RID: 6489
	private long NW_ShowRunningTime;

	// Token: 0x0400195A RID: 6490
	public long TranslateID = -1L;

	// Token: 0x0400195B RID: 6491
	public string TranslateStr;

	// Token: 0x0400195C RID: 6492
	public TalkDataType TranslateData;

	// Token: 0x0400195D RID: 6493
	public List<long> TranslateStrListID = new List<long>();

	// Token: 0x0400195E RID: 6494
	public List<TalkDataType> TranslateDataList = new List<TalkDataType>();

	// Token: 0x0400195F RID: 6495
	public List<CString> TranslateCStrList = new List<CString>();

	// Token: 0x04001960 RID: 6496
	public List<long> MB_TranslateStrListID = new List<long>();

	// Token: 0x04001961 RID: 6497
	public List<MessageBoard> MB_TranslateDataList = new List<MessageBoard>();

	// Token: 0x04001962 RID: 6498
	public List<CString> MB_TranslateCStrList = new List<CString>();

	// Token: 0x04001963 RID: 6499
	public bool bWaitTranslate;

	// Token: 0x04001964 RID: 6500
	public bool bWaitTranslate_MB;

	// Token: 0x04001965 RID: 6501
	public bool bBackTranslate;

	// Token: 0x04001966 RID: 6502
	public bool bBackTranslateBatch;

	// Token: 0x04001967 RID: 6503
	public bool bBackTranslateBatch_MB;

	// Token: 0x04001968 RID: 6504
	public byte bBackTranslateFail;

	// Token: 0x04001969 RID: 6505
	public byte bBackTranslateFail_MB;

	// Token: 0x0400196A RID: 6506
	private GameObject m_CheckCrystalBox;

	// Token: 0x0400196B RID: 6507
	private UIButton m_CheckCrystalButton;

	// Token: 0x0400196C RID: 6508
	private UIButton m_CheckCrystalCloseButton;

	// Token: 0x0400196D RID: 6509
	private bool bCheckCrystal;

	// Token: 0x0400196E RID: 6510
	private uint tmpCheckCrystal;

	// Token: 0x0400196F RID: 6511
	private UIText[] CheckCrystalText = new UIText[5];

	// Token: 0x04001970 RID: 6512
	private CustomImage CheckCrystalImg;

	// Token: 0x04001971 RID: 6513
	private CString CheckCrystalStr;

	// Token: 0x04001972 RID: 6514
	private byte CheckCrystalKind;

	// Token: 0x04001973 RID: 6515
	public int CheckCrystalPara1 = -1;

	// Token: 0x04001974 RID: 6516
	public int CheckCrystalPara2 = -1;

	// Token: 0x04001975 RID: 6517
	public ushort[] BoxID = new ushort[3];

	// Token: 0x04001976 RID: 6518
	public long[] BoxTime = new long[3];

	// Token: 0x04001977 RID: 6519
	public ushort[] BoxRequire = new ushort[3];

	// Token: 0x04001978 RID: 6520
	public uint TrueBoxRequire;

	// Token: 0x04001979 RID: 6521
	public bool[] BoxBShowMessage = new bool[3];

	// Token: 0x0400197A RID: 6522
	public ushort BoxRewardID;

	// Token: 0x0400197B RID: 6523
	public ushort BoxRewardItemID;

	// Token: 0x0400197C RID: 6524
	public byte BoxRewardItemRank;

	// Token: 0x0400197D RID: 6525
	public ushort BoxRewardNum;

	// Token: 0x0400197E RID: 6526
	public uint BoxRewardCrystal;

	// Token: 0x0400197F RID: 6527
	public uint BoxRewardAlliance;

	// Token: 0x04001980 RID: 6528
	public long NPCCityBonusTime;

	// Token: 0x04001981 RID: 6529
	public ushort UIPointID;

	// Token: 0x04001982 RID: 6530
	public byte UINodus;

	// Token: 0x04001983 RID: 6531
	public ushort EmojiNowPackageIndex = ushort.MaxValue;

	// Token: 0x04001984 RID: 6532
	public ushort EmojiNowPicIndex;

	// Token: 0x04001985 RID: 6533
	public int EmojiNowScrollIndex = -1;

	// Token: 0x04001986 RID: 6534
	public float EmojiNowContentPos;

	// Token: 0x04001987 RID: 6535
	private Dictionary<ushort, byte> MapEmojiCount;

	// Token: 0x04001988 RID: 6536
	public long[] EmojiFlag = new long[8];

	// Token: 0x04001989 RID: 6537
	public byte EmojiOpenType;

	// Token: 0x0400198A RID: 6538
	public SortEmojiComparer EmojiDataComparer = new SortEmojiComparer();

	// Token: 0x0400198B RID: 6539
	public List<ushort> EmojiIndex = new List<ushort>();

	// Token: 0x0400198C RID: 6540
	public bool bLoadEmojiSaveKey;

	// Token: 0x0400198D RID: 6541
	public List<ushort> SaveEmojiKey = new List<ushort>(8);

	// Token: 0x0400198E RID: 6542
	public string[] SaveEmojiName = new string[]
	{
		"SaveEmojiKey_1",
		"SaveEmojiKey_2",
		"SaveEmojiKey_3",
		"SaveEmojiKey_4",
		"SaveEmojiKey_5",
		"SaveEmojiKey_6",
		"SaveEmojiKey_7",
		"SaveEmojiKey_8"
	};

	// Token: 0x0400198F RID: 6543
	public ActivityWindow m_ActivityWindow;

	// Token: 0x04001990 RID: 6544
	public Dictionary<int, Sprite> MapIconDict = new Dictionary<int, Sprite>();

	// Token: 0x04001991 RID: 6545
	public Material MapSpriteMaterial;

	// Token: 0x04001992 RID: 6546
	public Material MapSpriteUIMaterial;

	// Token: 0x04001993 RID: 6547
	private int MapSpriteKey;

	// Token: 0x04001994 RID: 6548
	public BuildsData BuildingData;

	// Token: 0x04001995 RID: 6549
	public ushort BuildGuildQueue;

	// Token: 0x04001996 RID: 6550
	public byte[] BagTagSaved = new byte[10];

	// Token: 0x04001997 RID: 6551
	public byte[] ResourceFilterSaved = new byte[37];

	// Token: 0x04001998 RID: 6552
	public byte HeroListSaved;

	// Token: 0x04001999 RID: 6553
	public byte[] TechKindSaved = new byte[5];

	// Token: 0x0400199A RID: 6554
	public byte[] TechSaved = new byte[8];

	// Token: 0x0400199B RID: 6555
	public byte[] BookMarkSaved = new byte[8];

	// Token: 0x0400199C RID: 6556
	public byte[] TalentSaved = new byte[7];

	// Token: 0x0400199D RID: 6557
	public byte[] RallySaved = new byte[5];

	// Token: 0x0400199E RID: 6558
	public byte MissionSaved;

	// Token: 0x0400199F RID: 6559
	public byte[] TalentSaveSaved = new byte[5];

	// Token: 0x040019A0 RID: 6560
	public byte[] CastleSkinSaved = new byte[6];

	// Token: 0x040019A1 RID: 6561
	public CString SendTag;

	// Token: 0x040019A2 RID: 6562
	public CString SendName;

	// Token: 0x040019A3 RID: 6563
	public bool bContinuousUse;

	// Token: 0x040019A4 RID: 6564
	public byte MarshalSaved;

	// Token: 0x040019A5 RID: 6565
	public byte GuideParm1;

	// Token: 0x040019A6 RID: 6566
	public ushort GuideParm2;

	// Token: 0x040019A7 RID: 6567
	private RectTransform ArrowRect;

	// Token: 0x040019A8 RID: 6568
	private RectTransform ArrowParentRect;

	// Token: 0x040019A9 RID: 6569
	private uTweenPosition ArrowPos;

	// Token: 0x040019AA RID: 6570
	private byte UpdateArrow;

	// Token: 0x040019AB RID: 6571
	public List<UITimeBar> m_TimeBarList;

	// Token: 0x040019AC RID: 6572
	public int m_UISynthesisAbKey;

	// Token: 0x040019AD RID: 6573
	public UISynthesis m_UISynthesis;

	// Token: 0x040019AE RID: 6574
	public bool m_IsOpenedUISynthesis;

	// Token: 0x040019AF RID: 6575
	public ushort m_UISynthesisID;

	// Token: 0x040019B0 RID: 6576
	public List<ushort> m_SynthesisItemData;

	// Token: 0x040019B1 RID: 6577
	public e_SynPageType m_SynthesisPageType;

	// Token: 0x040019B2 RID: 6578
	public ushort m_SynthesisItemIdx;

	// Token: 0x040019B3 RID: 6579
	public float m_SynthesisScrollRectY;

	// Token: 0x040019B4 RID: 6580
	public int m_SynthesisScrollIdx;

	// Token: 0x040019B5 RID: 6581
	public LevelTableKind m_SynthesisBtnType = LevelTableKind.NormalStage;

	// Token: 0x040019B6 RID: 6582
	public ushort[] m_RequirementNum = new ushort[5];

	// Token: 0x040019B7 RID: 6583
	public ushort[] m_SynthesisItemNum = new ushort[5];

	// Token: 0x040019B8 RID: 6584
	public int[] m_AttackedAlertCount;

	// Token: 0x040019B9 RID: 6585
	public int m_AttackedAlertTCount;

	// Token: 0x040019BA RID: 6586
	public int m_AlertImageIndex = 2;

	// Token: 0x040019BB RID: 6587
	public UISpritesArray AlertImageSA;

	// Token: 0x040019BC RID: 6588
	private bool bAddAlertImageAlpha;

	// Token: 0x040019BD RID: 6589
	public int m_TroopsCount;

	// Token: 0x040019BE RID: 6590
	public int UIHero_Index = -1;

	// Token: 0x040019BF RID: 6591
	public float UIBarrack_Y = -1f;

	// Token: 0x040019C0 RID: 6592
	public float UIBarrack_TrapY = -1f;

	// Token: 0x040019C1 RID: 6593
	public int UIPreviewHero_Index = -1;

	// Token: 0x040019C2 RID: 6594
	public StringBuilder tmpString = new StringBuilder();

	// Token: 0x040019C3 RID: 6595
	public List<UIText> m_MsgText = new List<UIText>(10);

	// Token: 0x040019C4 RID: 6596
	public CString MsgStr;

	// Token: 0x040019C5 RID: 6597
	public CString MsgTitleStr;

	// Token: 0x040019C6 RID: 6598
	public CString MsgBtnStr;

	// Token: 0x040019C7 RID: 6599
	public CString MsgBarStr = new CString(10);

	// Token: 0x040019C8 RID: 6600
	public UIText MsgBarTimeText;

	// Token: 0x040019C9 RID: 6601
	public CustomImage MsgBarImage;

	// Token: 0x040019CA RID: 6602
	public float MsgBarTimeSec;

	// Token: 0x040019CB RID: 6603
	public float MaxBarTimeSec;

	// Token: 0x040019CC RID: 6604
	public List<GUIWindowStackData> m_WindowStack = new List<GUIWindowStackData>(10);

	// Token: 0x040019CD RID: 6605
	public bool bClearWindowStack = true;

	// Token: 0x040019CE RID: 6606
	public bool bOpenNeedClose;

	// Token: 0x040019CF RID: 6607
	public ObjectPool<BuildInfoObject> upgradePanelDataPool;

	// Token: 0x040019D0 RID: 6608
	public ObjectPool<BuildInfoObject2> upgradeEffectDataPool;

	// Token: 0x040019D1 RID: 6609
	public ObjectPool<HeroList_Soldier_Item> m_HeroList_Soldier_ItemDataPool;

	// Token: 0x040019D2 RID: 6610
	public ObjectPool<SoldierScrollItem> m_HeroList_Soldier_ItemDataPool2;

	// Token: 0x040019D3 RID: 6611
	public bool bButnUpReturn;

	// Token: 0x040019D4 RID: 6612
	private List<GUIQueueOpen> GUIQueue = new List<GUIQueueOpen>(4);

	// Token: 0x040019D5 RID: 6613
	private int mUIQueueLock;

	// Token: 0x040019D6 RID: 6614
	public CString m_ResourceTransportStr;

	// Token: 0x040019D7 RID: 6615
	public List<sHeroLvUp> m_HerodLvUpData = new List<sHeroLvUp>();

	// Token: 0x040019D8 RID: 6616
	public bool bOpenHeroLvUp;

	// Token: 0x040019D9 RID: 6617
	private string[] SpentCreditsStr = new string[]
	{
		"Item",
		"Technology",
		"FixWallImmediate",
		"BuildImmediate",
		"BuildFinish",
		"DismentleImmediate",
		"eDismentleFinish",
		"eMission",
		"HeroEnhance",
		"HeroStarUp",
		"Immediately",
		"AllianceModifyEmblem",
		"Instanthealing",
		"InstantCraftLordEquip",
		"eCraftLordEquipInstantFinish"
	};

	// Token: 0x040019DA RID: 6618
	public int AllianceListTopIdx;

	// Token: 0x040019DB RID: 6619
	public float AllienceListContentY;

	// Token: 0x040019DC RID: 6620
	public bool[] AllienceListGroupOpen = new bool[]
	{
		true,
		true,
		true,
		true,
		true
	};

	// Token: 0x040019DD RID: 6621
	public float m_BeginChangeTime = 3f;

	// Token: 0x040019DE RID: 6622
	public float m_ChangeTime;

	// Token: 0x040019DF RID: 6623
	public float m_FlashCount;

	// Token: 0x040019E0 RID: 6624
	public int m_TextIdx;

	// Token: 0x040019E1 RID: 6625
	public int Barrack_Soldier_Lock = 2;

	// Token: 0x040019E2 RID: 6626
	public long Barrack_Soldier_SliderValue;

	// Token: 0x040019E3 RID: 6627
	public CString CanonizedName;

	// Token: 0x040019E4 RID: 6628
	public bool bBackInPreviewModel;

	// Token: 0x040019E5 RID: 6629
	public float BackInPreviewHight;

	// Token: 0x040019E6 RID: 6630
	public bool bCheckAWSSchedule = true;

	// Token: 0x040019E7 RID: 6631
	public int m_BuildingTopIdx;

	// Token: 0x040019E8 RID: 6632
	public float m_BuildingPosY;

	// Token: 0x040019E9 RID: 6633
	public EmojiCenter EmojiManager;

	// Token: 0x040019EA RID: 6634
	public Vector2 mNewCenterPos = Vector2.zero;

	// Token: 0x040019EB RID: 6635
	public bool bShowLive;

	// Token: 0x040019EC RID: 6636
	public byte StopShowLiveScale;

	// Token: 0x040019ED RID: 6637
	public float m_LEBtn_SharedAlpha = 1f;

	// Token: 0x040019EE RID: 6638
	public List<UILEBtn> m_LEBTN_updateList = new List<UILEBtn>();

	// Token: 0x040019EF RID: 6639
	private UISpritesArray TechIconArray;

	// Token: 0x040019F0 RID: 6640
	private UISpritesArray TechIconArrayCN;

	// Token: 0x040019F1 RID: 6641
	private Material _TechMaterial;

	// Token: 0x040019F2 RID: 6642
	private AssetBundleRequest TechABRequest;

	// Token: 0x040019F3 RID: 6643
	private EGUIWindow _TechUpdateUI;

	// Token: 0x040019F4 RID: 6644
	private int TechIconKey;

	// Token: 0x020001AD RID: 429
	private enum eBBSetp
	{
		// Token: 0x040019F6 RID: 6646
		eMoveIn,
		// Token: 0x040019F7 RID: 6647
		eWait,
		// Token: 0x040019F8 RID: 6648
		eFadeOut,
		// Token: 0x040019F9 RID: 6649
		eMax
	}

	// Token: 0x020001AE RID: 430
	public enum EQuickFightKind
	{
		// Token: 0x040019FB RID: 6651
		EQFK_Normal = 1,
		// Token: 0x040019FC RID: 6652
		EQFK_VIP
	}

	// Token: 0x020001AF RID: 431
	public enum EStageKind
	{
		// Token: 0x040019FE RID: 6654
		ESK_Normal = 1,
		// Token: 0x040019FF RID: 6655
		ESK_Advance
	}

	// Token: 0x020001B0 RID: 432
	public enum ECombatLiveType : byte
	{
		// Token: 0x04001A01 RID: 6657
		ECLTR_ATTACK,
		// Token: 0x04001A02 RID: 6658
		ECLTR_UNDERATTACK,
		// Token: 0x04001A03 RID: 6659
		ECLTR_REINFORCE_UNDERATTACK,
		// Token: 0x04001A04 RID: 6660
		ECLTR_RALLYATTACK,
		// Token: 0x04001A05 RID: 6661
		ECLTR_AMBUSH_UNDERATTACK,
		// Token: 0x04001A06 RID: 6662
		ECLTR_WILDMONSTER,
		// Token: 0x04001A07 RID: 6663
		ECLTR_NPCCITY,
		// Token: 0x04001A08 RID: 6664
		ECLTR_PETATTACK,
		// Token: 0x04001A09 RID: 6665
		ECLTR_PETUNDERATTACK
	}

	// Token: 0x020001B1 RID: 433
	private enum EPetLiveType : byte
	{
		// Token: 0x04001A0B RID: 6667
		EPLTR_ATTACK,
		// Token: 0x04001A0C RID: 6668
		EPLTR_UNDERATTACK
	}
}
