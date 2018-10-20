using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200055D RID: 1373
public class UIFormationSelect : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06001B7E RID: 7038 RVA: 0x0030C404 File Offset: 0x0030A604
	public override void OnOpen(int arg1, int arg2)
	{
		this.door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIText component = this.AGS_Form.GetChild(3).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.alignment = TextAnchor.MiddleCenter;
		component.text = DataManager.Instance.mStringTable.GetStringByID(9784u);
		this.BGScene = (this.AGS_Form.GetChild(1) as RectTransform);
		Image component2 = this.AGS_Form.GetChild(4).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.door.LoadMaterial();
		component2.enabled = !GUIManager.Instance.bOpenOnIPhoneX;
		component2 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close");
		component2.material = this.door.LoadMaterial();
		UIButton component3 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 8;
		component3 = this.AGS_Form.GetChild(5).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 10;
		component3.gameObject.AddComponent<ArabicItemTextureRot>();
		for (int i = 0; i < 6; i++)
		{
			Transform child = this.AGS_Form.GetChild(7).GetChild(i);
			component3 = child.GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 1 + i;
			this.CoordBtn[i] = component3;
			this.CoordBtnImage[i] = child.GetComponent<Image>();
			this.CoordBtnUseIcon[i] = child.GetChild(3).gameObject;
			this.CoordBtnLockIcon[i] = child.GetChild(4).gameObject;
			this.CoordBtnLight[i] = child.GetChild(5).gameObject;
			this.CoordIconImage[i] = child.GetChild(0).GetComponent<Image>();
			this.CoordIconImage2[i] = child.GetChild(1).GetComponent<Image>();
			this.CoordBtnUseIcon[i].SetActive(false);
			this.CoordBtnLockIcon[i].SetActive(false);
			this.CoordBtnLight[i].SetActive(false);
			component = child.GetChild(2).GetComponent<UIText>();
			component.font = ttffont;
			component.text = string.Empty;
			this.CoordBtnText[i] = component;
		}
		component3 = this.AGS_Form.GetChild(8).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 7;
		this.ConfirmBtn = component3;
		this.ConfirmBtnImage = this.AGS_Form.GetChild(8).GetComponent<Image>();
		this.AGS_ConformBtn_SA = this.AGS_Form.GetChild(8).GetComponent<UISpritesArray>();
		component = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(924u);
		this.ConfirmBtnText = component;
		component3 = this.AGS_Form.GetChild(9).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 9;
		component = this.AGS_Form.GetChild(10).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(9786u);
		Image component4 = this.AGS_Form.GetChild(12).GetComponent<Image>();
		component = component4.transform.GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.Hint = component;
		this.HintTrans = component4.rectTransform;
		this.HintTrans.gameObject.SetActive(false);
		component4 = this.AGS_Form.GetChild(11).GetComponent<Image>();
		component = component4.transform.GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.Label = component;
		for (int j = 0; j < 16; j++)
		{
			Transform child2 = this.AGS_Form.GetChild(6).GetChild(j);
			this.SoliderIcon[j] = (child2 as RectTransform);
			UIButtonHint uibuttonHint = child2.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.Parm1 = (ushort)j;
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		UIFormationSelect.NowArmyCoordIndex = UIFormationSelect.ArmyCoordIndexCache;
		this.RefreshButtonStatus();
	}

	// Token: 0x06001B7F RID: 7039 RVA: 0x0030C8A0 File Offset: 0x0030AAA0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login && networkNews != NetworkNews.Refresh_Technology)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
		}
		else
		{
			this.UpdateUI(2, 0);
		}
	}

	// Token: 0x06001B80 RID: 7040 RVA: 0x0030C8E8 File Offset: 0x0030AAE8
	public void RefreshButtonFocus()
	{
		for (int i = 0; i < 6; i++)
		{
			if ((int)UIFormationSelect.NowArmyCoordIndex == i)
			{
				this.CoordBtnLight[i].SetActive(true);
				if (this.CoordBtnUseIcon[i].activeSelf)
				{
					this.SetupConfirmBtn(UIFormationSelect.ECoordConfirmBtnStatus.Used);
				}
				else if (this.CoordBtnLockIcon[i].activeSelf)
				{
					this.SetupConfirmBtn(UIFormationSelect.ECoordConfirmBtnStatus.GoToCollege);
				}
				else
				{
					this.SetupConfirmBtn(UIFormationSelect.ECoordConfirmBtnStatus.Setup);
				}
			}
			else
			{
				this.CoordBtnLight[i].SetActive(false);
			}
		}
		this.SetupSoliderIcon();
		this.Label.text = DataManager.Instance.mStringTable.GetStringByID(9778u + (uint)UIFormationSelect.NowArmyCoordIndex);
	}

	// Token: 0x06001B81 RID: 7041 RVA: 0x0030C9A4 File Offset: 0x0030ABA4
	public void RefreshButtonStatus()
	{
		for (int i = 0; i < 6; i++)
		{
			if (i != 0)
			{
				if (DataManager.Instance.GetTechLevel(this.CoordTechID[i]) == 0)
				{
					this.CoordBtnText[i].color = this.DisableColor;
					this.CoordBtnImage[i].color = this.DisableColor;
					this.CoordIconImage[i].color = this.DisableColor;
					this.CoordIconImage2[i].color = this.DisableColor;
					this.CoordBtnLockIcon[i].SetActive(true);
				}
				else
				{
					this.CoordBtnText[i].color = this.NormalColor;
					this.CoordBtnImage[i].color = this.NormalColor;
					this.CoordIconImage[i].color = this.NormalColor;
					this.CoordIconImage2[i].color = this.NormalColor;
					this.CoordBtnLockIcon[i].SetActive(false);
				}
			}
			if ((int)DataManager.Instance.RoleAttr.NowArmyCoordIndex == i)
			{
				this.CoordBtnUseIcon[i].SetActive(true);
			}
			else
			{
				this.CoordBtnUseIcon[i].SetActive(false);
			}
		}
		this.RefreshButtonFocus();
	}

	// Token: 0x06001B82 RID: 7042 RVA: 0x0030CB00 File Offset: 0x0030AD00
	public void SetupConfirmBtn(UIFormationSelect.ECoordConfirmBtnStatus status)
	{
		if (status == UIFormationSelect.ECoordConfirmBtnStatus.Setup)
		{
			this.ConfirmBtnImage.sprite = this.AGS_ConformBtn_SA.GetSprite(0);
			this.ConfirmBtnText.text = DataManager.Instance.mStringTable.GetStringByID(924u);
			this.ConfirmBtnText.color = new Color32(byte.MaxValue, 247, 153, byte.MaxValue);
			this.ConfirmBtn.interactable = true;
			this.ConfirmBtn.m_BtnID2 = (int)status;
			this.ConfirmBtnImage.color = this.NormalColor;
		}
		if (status == UIFormationSelect.ECoordConfirmBtnStatus.GoToCollege)
		{
			this.ConfirmBtnImage.sprite = this.AGS_ConformBtn_SA.GetSprite(1);
			this.ConfirmBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3776u);
			this.ConfirmBtnText.color = Color.white;
			this.ConfirmBtn.interactable = true;
			this.ConfirmBtn.m_BtnID2 = (int)status;
			this.ConfirmBtnImage.color = this.NormalColor;
		}
		if (status == UIFormationSelect.ECoordConfirmBtnStatus.Used)
		{
			this.ConfirmBtnImage.sprite = this.AGS_ConformBtn_SA.GetSprite(1);
			this.ConfirmBtnText.text = DataManager.Instance.mStringTable.GetStringByID(7444u);
			this.ConfirmBtnText.color = new Color(0.898f, 0f, 0.31f);
			this.ConfirmBtn.interactable = false;
			this.ConfirmBtn.m_BtnID2 = (int)status;
			this.ConfirmBtnImage.color = this.DisableColor;
		}
	}

	// Token: 0x06001B83 RID: 7043 RVA: 0x0030CCA8 File Offset: 0x0030AEA8
	public void ExeConfirmButtonEvent(UIFormationSelect.ECoordConfirmBtnStatus status)
	{
		if (status == UIFormationSelect.ECoordConfirmBtnStatus.Setup)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.AddSeqId();
			messagePacket.Protocol = Protocol._MSG_REQUEST_COORD_CHANGE;
			messagePacket.Add(UIFormationSelect.NowArmyCoordIndex);
			messagePacket.Send(false);
		}
		else if (status == UIFormationSelect.ECoordConfirmBtnStatus.GoToCollege)
		{
			GUIManager.Instance.OpenTechTree(this.CoordTechID[(int)UIFormationSelect.NowArmyCoordIndex], true);
		}
	}

	// Token: 0x06001B84 RID: 7044 RVA: 0x0030CD10 File Offset: 0x0030AF10
	public void SetupSoliderIcon()
	{
		Vector2 a = new Vector2(-248f, -164f);
		for (int i = 0; i < 16; i++)
		{
			CoordData recordByIndex = DataManager.Instance.CoordTable.GetRecordByIndex((int)(UIFormationSelect.NowArmyCoordIndex * 16) + i);
			Vector2 b = new Vector2((float)recordByIndex.AtkX * 0.1f, (float)recordByIndex.AtkY * 0.1f);
			this.SoliderIcon[i].anchoredPosition = a + b;
		}
	}

	// Token: 0x06001B85 RID: 7045 RVA: 0x0030CD94 File Offset: 0x0030AF94
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
			UIFormationSelect.NowArmyCoordIndex = (byte)(sender.m_BtnID1 - 1);
			this.RefreshButtonStatus();
			break;
		case 7:
			this.ExeConfirmButtonEvent((UIFormationSelect.ECoordConfirmBtnStatus)sender.m_BtnID2);
			break;
		case 8:
			this.door.CloseMenu(false);
			break;
		case 9:
			AudioManager.Instance.PlaySFX(40029, 0f, PitchKind.NoPitch, null, null);
			if (WarManager.CheckVersion(true))
			{
				this.SetupWarDefault();
				GUIManager.Instance.bClearWindowStack = false;
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MapToWar_CoordTest);
				FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_LINEUP_DRILL);
			}
			break;
		case 10:
			GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(9129u), DataManager.Instance.mStringTable.GetStringByID(9787u), null, null, 0, 0, true, true);
			break;
		}
	}

	// Token: 0x06001B86 RID: 7046 RVA: 0x0030CEB4 File Offset: 0x0030B0B4
	public void SetupWarDefault()
	{
		WarManager.CoordSimuIndex_Left = (ushort)UIFormationSelect.NowArmyCoordIndex;
		WarManager.TroopKindSimuIndex_Right = this.LeftCoordToRightSoldier[(int)UIFormationSelect.NowArmyCoordIndex];
		UIFormationSelect.ArmyCoordIndexCache = UIFormationSelect.NowArmyCoordIndex;
	}

	// Token: 0x06001B87 RID: 7047 RVA: 0x0030CEDC File Offset: 0x0030B0DC
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 1)
		{
			if (arg1 == 2)
			{
				this.RefreshButtonStatus();
			}
		}
		else
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(927u), 255, true);
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001B88 RID: 7048 RVA: 0x0030CF40 File Offset: 0x0030B140
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(3).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		for (int i = 0; i < 6; i++)
		{
			component = this.AGS_Form.GetChild(7).GetChild(i).GetChild(2).GetComponent<UIText>();
			if (component != null && component.enabled)
			{
				component.enabled = false;
				component.enabled = true;
			}
		}
		component = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(10).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		if (this.Label != null && this.Label.enabled)
		{
			this.Label.enabled = false;
			this.Label.enabled = true;
		}
	}

	// Token: 0x06001B89 RID: 7049 RVA: 0x0030D090 File Offset: 0x0030B290
	public static void RecvFormation(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			byte b = MP.ReadByte(-1);
			if (b >= 0 && b < 6)
			{
				DataManager.Instance.RoleAttr.NowArmyCoordIndex = b;
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_FormationSelect, 1, 0);
			}
		}
	}

	// Token: 0x06001B8A RID: 7050 RVA: 0x0030D0E8 File Offset: 0x0030B2E8
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.Parm1 < 16)
		{
			this.HintTrans.gameObject.SetActive(true);
			int id = 3841 + (int)this.IndexToSoldierKind[(int)sender.Parm1];
			this.Hint.text = DataManager.Instance.mStringTable.GetStringByID((uint)id);
			this.HintTrans.sizeDelta = new Vector2(1920f, 1920f);
			this.HintTrans.sizeDelta = new Vector2(this.Hint.preferredWidth + 35f, this.Hint.preferredHeight + 31f);
			this.Hint.UpdateArabicPos();
			this.HintTrans.anchoredPosition = ((RectTransform)sender.transform).anchoredPosition + new Vector2(0f, 110f);
		}
	}

	// Token: 0x06001B8B RID: 7051 RVA: 0x0030D1C8 File Offset: 0x0030B3C8
	public void OnButtonUp(UIButtonHint sender)
	{
		this.HintTrans.gameObject.SetActive(false);
	}

	// Token: 0x0400532D RID: 21293
	private Transform AGS_Form;

	// Token: 0x0400532E RID: 21294
	private UISpritesArray AGS_ConformBtn_SA;

	// Token: 0x0400532F RID: 21295
	private Door door;

	// Token: 0x04005330 RID: 21296
	private UIButton[] CoordBtn = new UIButton[6];

	// Token: 0x04005331 RID: 21297
	private Image[] CoordBtnImage = new Image[6];

	// Token: 0x04005332 RID: 21298
	private Image[] CoordIconImage = new Image[6];

	// Token: 0x04005333 RID: 21299
	private Image[] CoordIconImage2 = new Image[6];

	// Token: 0x04005334 RID: 21300
	private UIText[] CoordBtnText = new UIText[6];

	// Token: 0x04005335 RID: 21301
	private GameObject[] CoordBtnUseIcon = new GameObject[6];

	// Token: 0x04005336 RID: 21302
	private GameObject[] CoordBtnLockIcon = new GameObject[6];

	// Token: 0x04005337 RID: 21303
	private GameObject[] CoordBtnLight = new GameObject[6];

	// Token: 0x04005338 RID: 21304
	private UIButton ConfirmBtn;

	// Token: 0x04005339 RID: 21305
	private Image ConfirmBtnImage;

	// Token: 0x0400533A RID: 21306
	private UIText ConfirmBtnText;

	// Token: 0x0400533B RID: 21307
	private RectTransform BGScene;

	// Token: 0x0400533C RID: 21308
	private RectTransform[] SoliderIcon = new RectTransform[16];

	// Token: 0x0400533D RID: 21309
	public static byte NowArmyCoordIndex;

	// Token: 0x0400533E RID: 21310
	public static byte ArmyCoordIndexCache;

	// Token: 0x0400533F RID: 21311
	private UIText Label;

	// Token: 0x04005340 RID: 21312
	private UIText Hint;

	// Token: 0x04005341 RID: 21313
	private RectTransform HintTrans;

	// Token: 0x04005342 RID: 21314
	private readonly ushort[] CoordTechID = new ushort[]
	{
		0,
		136,
		137,
		138,
		139,
		140
	};

	// Token: 0x04005343 RID: 21315
	private readonly Color32 DisableColor = new Color32(124, 124, 124, byte.MaxValue);

	// Token: 0x04005344 RID: 21316
	private readonly Color32 NormalColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	// Token: 0x04005345 RID: 21317
	private readonly ushort[] LeftCoordToRightSoldier = new ushort[]
	{
		1,
		2,
		0,
		1,
		2,
		0
	};

	// Token: 0x04005346 RID: 21318
	private readonly byte[] IndexToSoldierKind = new byte[]
	{
		0,
		0,
		0,
		0,
		1,
		1,
		1,
		1,
		2,
		2,
		2,
		2,
		3,
		3,
		3,
		3
	};

	// Token: 0x0200055E RID: 1374
	private enum e_AGS_UI_FormationSelect
	{
		// Token: 0x04005348 RID: 21320
		BGFrame,
		// Token: 0x04005349 RID: 21321
		BGFrame2,
		// Token: 0x0400534A RID: 21322
		BGLine,
		// Token: 0x0400534B RID: 21323
		BGFrameTitle,
		// Token: 0x0400534C RID: 21324
		exitImage,
		// Token: 0x0400534D RID: 21325
		Infobtn,
		// Token: 0x0400534E RID: 21326
		TroopIcons,
		// Token: 0x0400534F RID: 21327
		FormationSelet,
		// Token: 0x04005350 RID: 21328
		ConformBtn,
		// Token: 0x04005351 RID: 21329
		PlayBtn,
		// Token: 0x04005352 RID: 21330
		PlayText,
		// Token: 0x04005353 RID: 21331
		Label,
		// Token: 0x04005354 RID: 21332
		Hint
	}

	// Token: 0x0200055F RID: 1375
	private enum e_AGS_BGFrameTitle
	{
		// Token: 0x04005356 RID: 21334
		Text
	}

	// Token: 0x02000560 RID: 1376
	private enum e_AGS_exitImage
	{
		// Token: 0x04005358 RID: 21336
		exitUIButton
	}

	// Token: 0x02000561 RID: 1377
	private enum e_AGS_ConformBtn
	{
		// Token: 0x0400535A RID: 21338
		UIText
	}

	// Token: 0x02000562 RID: 1378
	private enum e_UIFSButtonID
	{
		// Token: 0x0400535C RID: 21340
		Default,
		// Token: 0x0400535D RID: 21341
		CoordBtn1,
		// Token: 0x0400535E RID: 21342
		CoordBtn2,
		// Token: 0x0400535F RID: 21343
		CoordBtn3,
		// Token: 0x04005360 RID: 21344
		CoordBtn4,
		// Token: 0x04005361 RID: 21345
		CoordBtn5,
		// Token: 0x04005362 RID: 21346
		CoordBtn6,
		// Token: 0x04005363 RID: 21347
		ConfirmBtn,
		// Token: 0x04005364 RID: 21348
		ExitBtn,
		// Token: 0x04005365 RID: 21349
		PlayBtn,
		// Token: 0x04005366 RID: 21350
		InfoBtn
	}

	// Token: 0x02000563 RID: 1379
	private enum ECoordBtnChild
	{
		// Token: 0x04005368 RID: 21352
		CoordIcon,
		// Token: 0x04005369 RID: 21353
		CoordIcon2,
		// Token: 0x0400536A RID: 21354
		NameText,
		// Token: 0x0400536B RID: 21355
		UseIcon,
		// Token: 0x0400536C RID: 21356
		LockIcon,
		// Token: 0x0400536D RID: 21357
		Light
	}

	// Token: 0x02000564 RID: 1380
	public enum ECoordConfirmBtnStatus
	{
		// Token: 0x0400536F RID: 21359
		Setup,
		// Token: 0x04005370 RID: 21360
		Used,
		// Token: 0x04005371 RID: 21361
		GoToCollege
	}
}
