using System;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x020002C3 RID: 707
public class UIAllianceWar_Rank : GUIWindow, IActivityWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x06000E81 RID: 3713 RVA: 0x0017D0FC File Offset: 0x0017B2FC
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIText component = this.AGS_Form.GetChild(1).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(1).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(1).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = instance.mStringTable.GetStringByID(8119u);
		component.gameObject.SetActive(true);
		component = this.AGS_Form.GetChild(1).GetChild(6).GetComponent<UIText>();
		component.font = ttffont;
		component.text = instance.mStringTable.GetStringByID(1021u);
		component.gameObject.SetActive(true);
		UIButton uibutton = this.AGS_Form.GetChild(1).GetChild(7).GetComponent<UIButton>();
		uibutton.m_Handler = this;
		uibutton.m_BtnID1 = 1;
		uibutton.m_BtnID2 = 1;
		uibutton.transition = Selectable.Transition.None;
		uibutton.SetButtonEffectType(e_EffectType.e_Scale);
		uibutton = this.AGS_Form.GetChild(1).GetChild(8).GetComponent<UIButton>();
		uibutton.m_Handler = this;
		uibutton.m_BtnID1 = 1;
		uibutton.m_BtnID2 = 2;
		uibutton.transition = Selectable.Transition.None;
		uibutton.SetButtonEffectType(e_EffectType.e_Scale);
		uibutton.gameObject.AddComponent<ArabicItemTextureRot>();
		uibutton = this.AGS_Form.GetChild(1).GetChild(9).GetComponent<UIButton>();
		uibutton.m_Handler = this;
		uibutton.m_BtnID1 = 1;
		uibutton.m_BtnID2 = 3;
		uibutton.transition = Selectable.Transition.None;
		uibutton.SetButtonEffectType(e_EffectType.e_Scale);
		uibutton.gameObject.AddComponent<ArabicItemTextureRot>();
		uibutton = this.AGS_Form.GetChild(2).GetChild(0).GetComponent<UIButton>();
		uibutton.m_Handler = this;
		uibutton.m_BtnID1 = 2;
		uibutton.m_BtnID2 = 1;
		uibutton.gameObject.SetActive(true);
		uibutton.transition = Selectable.Transition.None;
		uibutton.SetButtonEffectType(e_EffectType.e_Scale);
		component = this.AGS_Form.GetChild(2).GetChild(0).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = instance.mStringTable.GetStringByID(776u);
		this.AGS_Form.GetChild(2).GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
		component = this.AGS_Form.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = instance.mStringTable.GetStringByID(7012u);
		component = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component.color = new Color32(byte.MaxValue, 68, 89, byte.MaxValue);
		UIHIBtn component2 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetComponent<UIHIBtn>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 1;
		component2.m_BtnID2 = 0;
		component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component2 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 1;
		component2.m_BtnID2 = 1;
		component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component2 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(2).GetChild(0).GetComponent<UIHIBtn>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 1;
		component2.m_BtnID2 = 2;
		component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(2).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component2 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(3).GetChild(0).GetComponent<UIHIBtn>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 1;
		component2.m_BtnID2 = 3;
		component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(3).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(2).GetChild(4).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component.resizeTextMaxSize = 30;
		this.TimeCountDown = component;
		component = this.AGS_Form.GetChild(2).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(1371u);
		component = this.AGS_Form.GetChild(3).GetChild(0).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(3).GetChild(1).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(3).GetChild(2).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		uibutton = this.AGS_Form.GetChild(3).GetChild(0).GetChild(0).gameObject.AddComponent<UIButton>();
		uibutton.m_Handler = this;
		uibutton.m_EffectType = e_EffectType.e_Normal;
		uibutton.transition = Selectable.Transition.None;
		uibutton.m_BtnID1 = 3;
		uibutton.m_BtnID2 = 1;
		UIButtonHint uibuttonHint = uibutton.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
		uibuttonHint.ScrollID = 1;
		uibutton = this.AGS_Form.GetChild(3).GetChild(1).GetChild(0).gameObject.AddComponent<UIButton>();
		uibutton.m_Handler = this;
		uibutton.m_EffectType = e_EffectType.e_Normal;
		uibutton.transition = Selectable.Transition.None;
		uibutton.m_BtnID1 = 3;
		uibutton.m_BtnID2 = 2;
		uibuttonHint = uibutton.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
		uibuttonHint.ScrollID = 1;
		uibutton = this.AGS_Form.GetChild(3).GetChild(2).GetChild(0).gameObject.AddComponent<UIButton>();
		uibutton.m_Handler = this;
		uibutton.m_EffectType = e_EffectType.e_Normal;
		uibutton.transition = Selectable.Transition.None;
		uibutton.m_BtnID1 = 3;
		uibutton.m_BtnID2 = 3;
		uibuttonHint = uibutton.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
		uibuttonHint.ScrollID = 1;
		component = this.AGS_Form.GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(17033u);
		this.setPanel();
	}

	// Token: 0x06000E82 RID: 3714 RVA: 0x0017D8C0 File Offset: 0x0017BAC0
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(1).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(4).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(6).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(0).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(2).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(3).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(4).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(3).GetChild(0).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(3).GetChild(1).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(3).GetChild(2).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(4).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
	}

	// Token: 0x06000E83 RID: 3715 RVA: 0x0017DD28 File Offset: 0x0017BF28
	public override void OnClose()
	{
		this.RankAnime.Destroy();
		for (int i = 0; i < this.RankStr.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.RankStr[i]);
		}
		for (int j = 0; j < this.XStr.Length; j++)
		{
			StringManager.Instance.DeSpawnString(this.XStr[j]);
		}
		StringManager.Instance.DeSpawnString(this.GiftBoxStr);
		StringManager.Instance.DeSpawnString(this.countDownStr);
		StringManager.Instance.DeSpawnString(this.HintStr);
	}

	// Token: 0x06000E84 RID: 3716 RVA: 0x0017DDCC File Offset: 0x0017BFCC
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.bClose == 1)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu(false);
		}
		else if (this.bClose == 2)
		{
			ActivityManager.Instance.AllianceWarSendReOpenMenu();
		}
		if (this.RankAnime != null)
		{
			this.RankAnime.Update();
		}
		if (this.glowLight != null && this.glowLight.gameObject.activeInHierarchy)
		{
			this.GetPointTime += Time.smoothDeltaTime;
			if (this.GetPointTime >= 2f)
			{
				this.GetPointTime = 0f;
			}
			float num = (this.GetPointTime <= 1f) ? this.GetPointTime : (2f - this.GetPointTime);
			if (num < 0.2f)
			{
				num = 0.2f;
			}
			this.glowLight.color = new Color(1f, 1f, 1f, num);
		}
		if (bOnSecond && this.TimeCountDown != null && this.TimeCountDown.gameObject.activeInHierarchy)
		{
			this.countDownStr.ClearString();
			long num2 = ActivityManager.Instance.AllianceWarData.EventBeginTime + (long)((ulong)ActivityManager.Instance.AllianceWarData.EventReqiureTIme) - DataManager.Instance.ServerTime;
			if (num2 < 0L)
			{
				num2 = 0L;
			}
			GameConstants.GetTimeString(this.countDownStr, (uint)num2, false, false, true, false, true);
			this.TimeCountDown.text = this.countDownStr.ToString();
			this.TimeCountDown.cachedTextGenerator.Invalidate();
			this.TimeCountDown.SetAllDirty();
		}
		if (!ActivityManager.Instance.AW_bcalculateEnd && DataManager.Instance.ServerTime > this.nextCheckTime)
		{
			this.nextCheckTime = DataManager.Instance.ServerTime + 300L;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_OPENGETPRIZEUI;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
		}
		if (this.OpenSecendFlyer && Time.time > this.nextFlyer)
		{
			this.setSecendFlyer();
		}
	}

	// Token: 0x06000E85 RID: 3717 RVA: 0x0017E00C File Offset: 0x0017C20C
	public void OnStateChange(EAllianceWarState oldState, EAllianceWarState NewState)
	{
	}

	// Token: 0x06000E86 RID: 3718 RVA: 0x0017E010 File Offset: 0x0017C210
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 1:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door == null)
			{
				return;
			}
			switch (sender.m_BtnID2)
			{
			case 1:
				if (DataManager.Instance.RoleAlliance.Id == 0u)
				{
					return;
				}
				UIAlliVSAlliBoard.NewOpen = true;
				door.OpenMenu(EGUIWindow.UI_AlliVSAlliBoard, 0, 0, false);
				break;
			case 2:
				if (DataManager.Instance.RoleAlliance.Id == 0u)
				{
					return;
				}
				if (ActivityManager.Instance.AW_NowAllianceEnterWar == 0)
				{
					return;
				}
				UIAlliVSGroupBoard.NewOpen = true;
				door.OpenMenu(EGUIWindow.UI_AlliVSGroupBoard, 0, 0, false);
				break;
			case 3:
				ActivityManager.Instance.Send_REQUEST_ALLIANCEWAR_RANKPRIZE();
				break;
			}
			break;
		}
		case 2:
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_GETPRIZE;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			break;
		}
		}
	}

	// Token: 0x06000E87 RID: 3719 RVA: 0x0017E12C File Offset: 0x0017C32C
	public void OnHIButtonClick(UIHIBtn sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID == 1)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door == null)
			{
				return;
			}
			Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(UIAllianceWar_Rank.RewardItem[sender.m_BtnID2]);
			if (recordByKey.EquipKind != 18 && recordByKey.EquipKind != 19)
			{
				return;
			}
			door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int)UIAllianceWar_Rank.RewardItem[sender.m_BtnID2], false);
		}
	}

	// Token: 0x06000E88 RID: 3720 RVA: 0x0017E1C0 File Offset: 0x0017C3C0
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		if (uibutton == null)
		{
			return;
		}
		int btnID = uibutton.m_BtnID1;
		if (btnID == 3)
		{
			if (DataManager.Instance.RoleAlliance.Id == 0u)
			{
				return;
			}
			this.HintStr.ClearString();
			this.HintStr.IntToFormat((long)uibutton.m_BtnID3, 1, false);
			this.HintStr.IntToFormat((long)UIAllianceWar_Rank.RankLeastMemberCount[uibutton.m_BtnID2 - 1], 1, false);
			this.HintStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17074u));
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.HintStr, Vector2.zero);
		}
	}

	// Token: 0x06000E89 RID: 3721 RVA: 0x0017E294 File Offset: 0x0017C494
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(false);
	}

	// Token: 0x06000E8A RID: 3722 RVA: 0x0017E2A8 File Offset: 0x0017C4A8
	public void setPanel()
	{
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		RectTransform component = this.AGS_Form.GetChild(0).GetComponent<RectTransform>();
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0f);
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0f);
		component.anchorMax = Vector2.one;
		component.anchorMin = Vector2.zero;
		ActivityWindow activityWindow = component.gameObject.AddComponent<ActivityWindow>();
		activityWindow.Initial(e_ActivityType.Ranking, this);
		if (!UIAllianceWar_Rank.isDataReady && DataManager.Instance.RoleAlliance.Id != 0u)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_OPENGETPRIZEUI;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
		}
		if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
		{
			this.bClose = 1;
		}
		else if (ActivityManager.Instance.AW_State != EAllianceWarState.EAWS_Replay)
		{
			this.bClose = 2;
		}
		this.RankPoint[0] = this.AGS_Form.GetChild(5).GetChild(0);
		this.RankPoint[1] = this.AGS_Form.GetChild(5).GetChild(1);
		this.RankPoint[2] = this.AGS_Form.GetChild(5).GetChild(2);
		if (this.RankAnime == null)
		{
			this.RankAnime = new UIAlliance_Control();
		}
		this.RankAnime.Initial(this.AGS_Form.GetChild(5).GetChild(3).GetComponent<Image>());
		this.ImgUpRect = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<RectTransform>();
		this.ImgDownRect = this.AGS_Form.GetChild(3).GetChild(4).GetComponent<RectTransform>();
		for (int i = 0; i < this.RankStr.Length; i++)
		{
			this.RankStr[i] = StringManager.Instance.SpawnString(30);
		}
		for (int j = 0; j < this.XStr.Length; j++)
		{
			this.XStr[j] = StringManager.Instance.SpawnString(30);
		}
		this.GiftBoxStr = StringManager.Instance.SpawnString(500);
		this.countDownStr = StringManager.Instance.SpawnString(500);
		this.HintStr = StringManager.Instance.SpawnString(500);
		this.glowLight = this.AGS_Form.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>();
		this.countDownStr.ClearString();
		long num = ActivityManager.Instance.AllianceWarData.EventBeginTime + (long)((ulong)ActivityManager.Instance.AllianceWarData.EventReqiureTIme) - DataManager.Instance.ServerTime;
		GameConstants.GetTimeString(this.countDownStr, (uint)num, false, false, true, false, true);
		this.TimeCountDown.text = this.countDownStr.ToString();
		this.TimeCountDown.cachedTextGenerator.Invalidate();
		this.TimeCountDown.SetAllDirty();
		if (!ActivityManager.Instance.AW_bcalculateEnd)
		{
			this.nextCheckTime = DataManager.Instance.ServerTime + 300L;
		}
		this.UpdateLayout();
		this.UpdateRank();
	}

	// Token: 0x06000E8B RID: 3723 RVA: 0x0017E5BC File Offset: 0x0017C7BC
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_FontTextureRebuilt:
			this.Refresh_FontTexture();
			return;
		default:
			if (networkNews != NetworkNews.Login && networkNews != NetworkNews.Refresh_Alliance)
			{
				return;
			}
			break;
		case NetworkNews.Refresh_AllianceWarState:
			break;
		}
		if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu(false);
			return;
		}
		if (ActivityManager.Instance.AW_State != EAllianceWarState.EAWS_Replay)
		{
			ActivityManager.Instance.AllianceWarSendReOpenMenu();
			return;
		}
		if (DataManager.Instance.RoleAlliance.Id == 0u)
		{
			this.UpdateLayout();
			this.UpdateRank();
			return;
		}
		if (!UIAllianceWar_Rank.isDataReady)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_OPENGETPRIZEUI;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
		}
	}

	// Token: 0x06000E8C RID: 3724 RVA: 0x0017E698 File Offset: 0x0017C898
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.UpdateLayout();
			if (ActivityManager.Instance.AW_GetGift != 0)
			{
				this.SetFlyer();
			}
		}
		else if (arg1 == 2)
		{
			if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.CloseMenu(false);
				return;
			}
			if (ActivityManager.Instance.AW_State != EAllianceWarState.EAWS_Replay)
			{
				ActivityManager.Instance.AllianceWarSendReOpenMenu();
				return;
			}
			this.UpdateLayout();
			ActivityManager.Instance.UpDateAllianceWarTop();
		}
		else if (arg1 == 3 && !UIAllianceWar_Rank.isDataReady)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_OPENGETPRIZEUI;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			return;
		}
	}

	// Token: 0x06000E8D RID: 3725 RVA: 0x0017E764 File Offset: 0x0017C964
	public void UpdateLayout()
	{
		int num = UIAllianceWar_Rank.OpenKindCheck();
		switch (num + 1)
		{
		case 0:
			this.bClose = 1;
			break;
		case 1:
		{
			this.AGS_Form.GetChild(2).GetChild(3).gameObject.SetActive(true);
			this.AGS_Form.GetChild(1).GetChild(9).GetComponent<Image>().color = Color.white;
			this.AGS_Form.GetChild(1).GetChild(9).GetComponent<uButtonScale>().enabled = true;
			this.AGS_Form.GetChild(1).GetChild(7).GetComponent<Image>().color = Color.white;
			this.AGS_Form.GetChild(1).GetChild(7).GetComponent<uButtonScale>().enabled = true;
			int num2 = 0;
			for (int i = 0; i < 4; i++)
			{
				if (UIAllianceWar_Rank.RewardItem[i] != 0)
				{
					Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(UIAllianceWar_Rank.RewardItem[i]);
					num2++;
					this.AGS_Form.GetChild(2).GetChild(3).GetChild(0 + i).gameObject.SetActive(true);
					UIHIBtn component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0 + i).GetChild(0).GetComponent<UIHIBtn>();
					GUIManager.Instance.InitianHeroItemImg(component.transform, eHeroOrItem.Item, UIAllianceWar_Rank.RewardItem[i], 0, UIAllianceWar_Rank.RewardItemRare[i], 0, false, recordByKey.EquipKind != 18 && recordByKey.EquipKind != 19, true, false);
					this.XStr[i].ClearString();
					this.XStr[i].IntToFormat((long)UIAllianceWar_Rank.RewardItemCount[i], 1, false);
					if (GUIManager.Instance.IsArabic)
					{
						this.XStr[i].AppendFormat("{0}x");
					}
					else
					{
						this.XStr[i].AppendFormat("x{0}");
					}
					UIText component2 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0 + i).GetChild(1).GetComponent<UIText>();
					component2.text = this.XStr[i].ToString();
					component2.cachedTextGenerator.Invalidate();
					component2.SetAllDirty();
				}
				else
				{
					this.AGS_Form.GetChild(2).GetChild(3).GetChild(0 + i).gameObject.SetActive(false);
				}
			}
			switch (num2)
			{
			case 1:
			{
				RectTransform component3 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetComponent<RectTransform>();
				component3.anchoredPosition = Vector2.zero;
				break;
			}
			case 2:
			{
				RectTransform component3 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetComponent<RectTransform>();
				component3.anchoredPosition = new Vector2(-65f, 0f);
				component3 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetComponent<RectTransform>();
				component3.anchoredPosition = new Vector2(65f, 0f);
				break;
			}
			case 3:
			{
				RectTransform component3 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetComponent<RectTransform>();
				component3.anchoredPosition = new Vector2(-65f, 50f);
				component3 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetComponent<RectTransform>();
				component3.anchoredPosition = new Vector2(65f, 50f);
				break;
			}
			}
			if (ActivityManager.Instance.AW_GetGift == 0)
			{
				this.AGS_Form.GetChild(2).GetChild(0).gameObject.SetActive(true);
				this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(true);
				this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(true);
				this.AGS_Form.GetChild(2).GetChild(1).gameObject.SetActive(false);
			}
			else
			{
				this.AGS_Form.GetChild(2).GetChild(0).gameObject.SetActive(false);
				this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
				this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
				this.AGS_Form.GetChild(2).GetChild(1).gameObject.SetActive(true);
			}
			break;
		}
		case 2:
		case 3:
		{
			this.AGS_Form.GetChild(2).GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
			UIText component4 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
			component4.gameObject.SetActive(true);
			component4.text = DataManager.Instance.mStringTable.GetStringByID(17024u);
			this.AGS_Form.GetChild(1).GetChild(9).GetComponent<Image>().color = Color.white;
			this.AGS_Form.GetChild(1).GetChild(9).GetComponent<uButtonScale>().enabled = true;
			this.AGS_Form.GetChild(1).GetChild(7).GetComponent<Image>().color = Color.white;
			this.AGS_Form.GetChild(1).GetChild(7).GetComponent<uButtonScale>().enabled = true;
			break;
		}
		case 4:
		{
			this.AGS_Form.GetChild(2).GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
			UIText component5 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
			component5.gameObject.SetActive(true);
			component5.text = DataManager.Instance.mStringTable.GetStringByID(17023u);
			this.AGS_Form.GetChild(1).GetChild(9).GetComponent<Image>().color = Color.white;
			this.AGS_Form.GetChild(1).GetChild(9).GetComponent<uButtonScale>().enabled = true;
			this.AGS_Form.GetChild(1).GetChild(7).GetComponent<Image>().color = Color.white;
			this.AGS_Form.GetChild(1).GetChild(7).GetComponent<uButtonScale>().enabled = true;
			break;
		}
		case 5:
		{
			this.AGS_Form.GetChild(2).GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
			UIText component6 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
			component6.gameObject.SetActive(true);
			component6.text = DataManager.Instance.mStringTable.GetStringByID(1594u);
			this.AGS_Form.GetChild(1).GetChild(9).GetComponent<Image>().color = Color.gray;
			this.AGS_Form.GetChild(1).GetChild(9).GetComponent<uButtonScale>().enabled = false;
			this.AGS_Form.GetChild(1).GetChild(7).GetComponent<Image>().color = Color.gray;
			this.AGS_Form.GetChild(1).GetChild(7).GetComponent<uButtonScale>().enabled = false;
			break;
		}
		case 6:
		{
			this.AGS_Form.GetChild(2).GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
			UIText component7 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
			component7.gameObject.SetActive(true);
			component7.text = DataManager.Instance.mStringTable.GetStringByID(14613u);
			this.AGS_Form.GetChild(1).GetChild(9).GetComponent<Image>().color = Color.white;
			this.AGS_Form.GetChild(1).GetChild(9).GetComponent<uButtonScale>().enabled = true;
			this.AGS_Form.GetChild(1).GetChild(7).GetComponent<Image>().color = Color.white;
			this.AGS_Form.GetChild(1).GetChild(7).GetComponent<uButtonScale>().enabled = true;
			break;
		}
		}
		if (ActivityManager.Instance.AW_NowAllianceEnterWar == 0 || !ActivityManager.Instance.AW_bcalculateEnd)
		{
			this.AGS_Form.GetChild(1).GetChild(8).GetComponent<Image>().color = Color.gray;
			this.AGS_Form.GetChild(1).GetChild(8).GetComponent<uButtonScale>().enabled = false;
			this.AGS_Form.GetChild(4).gameObject.SetActive(false);
		}
		else
		{
			this.AGS_Form.GetChild(1).GetChild(8).GetComponent<Image>().color = Color.white;
			this.AGS_Form.GetChild(1).GetChild(8).GetComponent<uButtonScale>().enabled = true;
			this.AGS_Form.GetChild(4).gameObject.SetActive(true);
		}
		this.AGS_Form.GetChild(1).GetChild(9).GetChild(0).gameObject.SetActive(ActivityManager.Instance.AW_PrizeGroupID != 0);
	}

	// Token: 0x06000E8E RID: 3726 RVA: 0x0017F2DC File Offset: 0x0017D4DC
	public void UpdateRank()
	{
		float angle = 270f;
		float[] array = new float[]
		{
			119f,
			187f
		};
		byte b = (byte)Mathf.Clamp((int)ActivityManager.Instance.AW_NextRank, (int)ActivityManager.Instance.AW_MinRank, (int)ActivityManager.Instance.AW_MaxRank);
		byte b2 = (byte)Mathf.Clamp((int)ActivityManager.Instance.AW_Rank, (int)ActivityManager.Instance.AW_MinRank, (int)ActivityManager.Instance.AW_MaxRank);
		if (!ActivityManager.Instance.AW_bcalculateEnd)
		{
			b = b2;
		}
		bool flag = false;
		UIAlliance_Control.eRankState eRankState;
		if (b != b2)
		{
			if (b > b2)
			{
				eRankState = UIAlliance_Control.eRankState.RankUp;
			}
			else if (b < b2)
			{
				eRankState = UIAlliance_Control.eRankState.RankDown;
			}
			else
			{
				eRankState = UIAlliance_Control.eRankState.RankEqual;
			}
		}
		else
		{
			eRankState = UIAlliance_Control.eRankState.RankEqual;
		}
		ushort num;
		if (b != b2)
		{
			if (!ushort.TryParse(PlayerPrefs.GetString("Alliance_RankAM_" + DataManager.Instance.RoleAttr.UserId), out num))
			{
				if (eRankState != UIAlliance_Control.eRankState.RankEqual)
				{
					flag = true;
				}
			}
			else if (num / 100 != (ushort)b || num % 100 != (ushort)b2)
			{
				flag = true;
			}
		}
		num = (ushort)(b * 100 + b2);
		PlayerPrefs.SetString("Alliance_RankAM_" + DataManager.Instance.RoleAttr.UserId, num.ToString());
		this.RankAnime.SetAnimState(eRankState);
		int num2;
		if (b2 == ActivityManager.Instance.AW_MinRank)
		{
			num2 = 0;
		}
		else if (b2 == ActivityManager.Instance.AW_MaxRank)
		{
			num2 = 2;
		}
		else
		{
			num2 = 1;
		}
		int num3;
		if (eRankState == UIAlliance_Control.eRankState.RankUp)
		{
			num3 = num2 + 1;
			angle = 135f;
		}
		else if (eRankState == UIAlliance_Control.eRankState.RankDown)
		{
			num3 = num2 - 1;
			angle = 315f;
		}
		else
		{
			num3 = num2;
		}
		if (flag)
		{
			this.RankAnime.rectTransform.localPosition = new Vector3(this.RankPoint[num2].localPosition.x, this.RankPoint[num2].localPosition.y, 0f);
			this.RankAnime.MoveTo(this.RankPoint[num3], 0f, angle, 1f);
		}
		else
		{
			this.RankAnime.rectTransform.localPosition = new Vector3(this.RankPoint[num3].localPosition.x, this.RankPoint[num3].localPosition.y, 0f);
		}
		if (DataManager.Instance.RoleAlliance.Id != 0u)
		{
			if (eRankState == UIAlliance_Control.eRankState.RankUp)
			{
				this.ImgUpRect.gameObject.SetActive(true);
				this.ImgUpRect.anchoredPosition = new Vector2(this.ImgUpRect.anchoredPosition.x, array[num2] - -2f);
			}
			else if (eRankState == UIAlliance_Control.eRankState.RankDown)
			{
				this.ImgDownRect.gameObject.SetActive(true);
				this.ImgDownRect.anchoredPosition = new Vector2(this.ImgDownRect.anchoredPosition.x, array[num3] - -2f);
			}
		}
		else
		{
			this.ImgUpRect.gameObject.SetActive(false);
			this.ImgDownRect.gameObject.SetActive(false);
		}
		this.RankAnime.rectTransform.gameObject.SetActive(DataManager.Instance.RoleAlliance.Id != 0u);
		if (!ActivityManager.Instance.AW_bcalculateEnd)
		{
			this.RankAnime.rectTransform.gameObject.SetActive(false);
		}
		int num4 = (int)(b2 - 1);
		if (b2 == ActivityManager.Instance.AW_MaxRank)
		{
			num4 = (int)(b2 - 2);
		}
		else if (b2 == ActivityManager.Instance.AW_MinRank)
		{
			num4 = (int)ActivityManager.Instance.AW_MinRank;
		}
		for (int i = 0; i < this.RankStr.Length; i++)
		{
			UIText component = this.AGS_Form.GetChild(3).GetChild(0 + i).GetChild(1).GetComponent<UIText>();
			this.RankStr[i].ClearString();
			this.RankStr[i].IntToFormat((long)(num4 + i), 1, false);
			this.RankStr[i].AppendFormat("{0}");
			component.text = this.RankStr[i].ToString();
			component.cachedTextGenerator.Invalidate();
			component.SetAllDirty();
			UISpritesArray component2 = this.AGS_Form.GetChild(3).GetChild(0 + i).GetComponent<UISpritesArray>();
			int spriteIndex = Math.Min(4, (num4 + i - 1) / 5);
			component2.SetSpriteIndex(spriteIndex);
			UIButton component3 = this.AGS_Form.GetChild(3).GetChild(0 + i).GetChild(0).GetComponent<UIButton>();
			component3.m_BtnID3 = num4 + i;
			component3.m_Handler = this;
			GUIManager.Instance.SetAllyWarRankImage(this.AGS_Form.GetChild(3).GetChild(0 + i).GetChild(0).GetComponent<Image>(), (byte)(num4 + i));
		}
	}

	// Token: 0x06000E8F RID: 3727 RVA: 0x0017F800 File Offset: 0x0017DA00
	private void SetFlyer()
	{
		GUIManager instance = GUIManager.Instance;
		Array.Clear(instance.SE_Kind, 0, instance.SE_Kind.Length);
		Array.Clear(instance.SE_ItemID, 0, instance.SE_ItemID.Length);
		for (int i = 0; i < 3; i++)
		{
			if (UIAllianceWar_Rank.RewardItem[i] != 0)
			{
				instance.SE_ItemID[i] = UIAllianceWar_Rank.RewardItem[i];
			}
		}
		instance.mStartV2 = new Vector2(instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + 259.5f, instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f + 101f);
		instance.m_SpeciallyEffect.AddIconShow(instance.mStartV2, instance.SE_Kind, instance.SE_ItemID, true);
		if (UIAllianceWar_Rank.RewardItem[3] != 0)
		{
			this.OpenSecendFlyer = true;
			this.nextFlyer = Time.time + 1.5f;
		}
		AudioManager.Instance.PlaySFX(11001, 0f, PitchKind.NoPitch, null, null);
	}

	// Token: 0x06000E90 RID: 3728 RVA: 0x0017F920 File Offset: 0x0017DB20
	private void setSecendFlyer()
	{
		this.OpenSecendFlyer = false;
		GUIManager instance = GUIManager.Instance;
		Array.Clear(instance.SE_Kind, 0, instance.SE_Kind.Length);
		Array.Clear(instance.m_SpeciallyEffect.mResValue, 0, instance.m_SpeciallyEffect.mResValue.Length);
		Array.Clear(instance.SE_ItemID, 0, instance.SE_ItemID.Length);
		if (UIAllianceWar_Rank.RewardItem[3] != 0)
		{
			instance.SE_ItemID[0] = UIAllianceWar_Rank.RewardItem[3];
		}
		instance.mStartV2 = new Vector2(instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + 259.5f, instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f + 101f);
		instance.m_SpeciallyEffect.AddIconShow(instance.mStartV2, instance.SE_Kind, instance.SE_ItemID, true);
	}

	// Token: 0x06000E91 RID: 3729 RVA: 0x0017FA0C File Offset: 0x0017DC0C
	public static void OpenUI()
	{
		if (DataManager.Instance.RoleAlliance.Id == 0u || (UIAllianceWar_Rank.isDataReady && UIAllianceWar_Rank.DataAllianceID == DataManager.Instance.RoleAlliance.Id))
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door == null)
			{
				return;
			}
			ActivityManager.Instance.AllianceWarReopenCheck();
			door.OpenMenu(EGUIWindow.UI_AllianceWar_Rank, 0, 0, false);
		}
		else
		{
			UIAllianceWar_Rank.isDataReady = false;
			UIAllianceWar_Rank.DataAllianceID = 0u;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_OPENGETPRIZEUI;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Activity);
		}
	}

	// Token: 0x06000E92 RID: 3730 RVA: 0x0017FACC File Offset: 0x0017DCCC
	public static void DispatchOpen(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		switch (b)
		{
		case 0:
		case 1:
		case 5:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door == null)
			{
				return;
			}
			ActivityManager.Instance.AllianceWarReopenCheck();
			if (b == 1)
			{
				door.OpenMenu(EGUIWindow.UI_AllianceWar_Rank, 0, 0, false);
				GUIManager.Instance.HideUILock(EUILock.Activity);
				return;
			}
			ActivityManager instance = ActivityManager.Instance;
			if (b == 5)
			{
				UIAllianceWar_Rank.isDataReady = false;
				instance.AW_bcalculateEnd = false;
				UIAllianceWar_Rank.DataAllianceID = DataManager.Instance.RoleAlliance.Id;
				MP.ReadByte(-1);
				MP.ReadByte(-1);
				instance.AW_MaxRank = MP.ReadByte(-1);
				instance.AW_MinRank = MP.ReadByte(-1);
				UIAllianceWar_Rank.RankLeastMemberCount[0] = MP.ReadByte(-1);
				UIAllianceWar_Rank.RankLeastMemberCount[1] = MP.ReadByte(-1);
				UIAllianceWar_Rank.RankLeastMemberCount[2] = MP.ReadByte(-1);
			}
			else
			{
				instance.AW_NextRank = MP.ReadByte(-1);
				LeaderBoardManager.Instance.AllianceWarGroupRank = (int)MP.ReadByte(-1);
				instance.AW_MaxRank = MP.ReadByte(-1);
				instance.AW_MinRank = MP.ReadByte(-1);
				UIAllianceWar_Rank.isDataReady = true;
				instance.AW_bcalculateEnd = true;
				UIAllianceWar_Rank.DataAllianceID = DataManager.Instance.RoleAlliance.Id;
				UIAllianceWar_Rank.RankLeastMemberCount[0] = MP.ReadByte(-1);
				UIAllianceWar_Rank.RankLeastMemberCount[1] = MP.ReadByte(-1);
				UIAllianceWar_Rank.RankLeastMemberCount[2] = MP.ReadByte(-1);
				int num = 0;
				for (int i = 0; i < 4; i++)
				{
					UIAllianceWar_Rank.RewardItemRare[num] = MP.ReadByte(-1);
					UIAllianceWar_Rank.RewardItem[num] = MP.ReadUShort(-1);
					UIAllianceWar_Rank.RewardItemCount[num] = (ushort)MP.ReadByte(-1);
					if (UIAllianceWar_Rank.RewardItem[num] != 0)
					{
						num++;
					}
				}
			}
			UIAllianceWar_Rank x = GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWar_Rank) as UIAllianceWar_Rank;
			if (x != null)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWar_Rank, 2, 0);
			}
			else
			{
				door.OpenMenu(EGUIWindow.UI_AllianceWar_Rank, 0, 0, false);
			}
			GUIManager.Instance.HideUILock(EUILock.Activity);
			return;
		}
		case 2:
			GUIManager.Instance.HideUILock(EUILock.Activity);
			return;
		}
	}

	// Token: 0x06000E93 RID: 3731 RVA: 0x0017FD1C File Offset: 0x0017DF1C
	public static void DispatchReward(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b > 0)
		{
			return;
		}
		byte b2 = MP.ReadByte(-1);
		for (int i = 0; i < 4; i++)
		{
			ushort itemID = MP.ReadUShort(-1);
			ushort quantity = MP.ReadUShort(-1);
			byte rare = MP.ReadByte(-1);
			DataManager.Instance.SetCurItemQuantity(itemID, quantity, rare, 0L);
		}
		ActivityManager.Instance.AW_GetGift = 1;
		ActivityManager.Instance.CheckAWShowHint();
		ActivityManager.Instance.UpDateAllianceWarTop();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWar_Rank, 1, 0);
		GUIManager.Instance.HideUILock(EUILock.Activity);
	}

	// Token: 0x06000E94 RID: 3732 RVA: 0x0017FDBC File Offset: 0x0017DFBC
	public static int OpenKindCheck()
	{
		ActivityManager instance = ActivityManager.Instance;
		if (DataManager.Instance.RoleAlliance.Id == 0u)
		{
			return 4;
		}
		if (!instance.AW_bcalculateEnd)
		{
			return 5;
		}
		if (instance.AW_NowAllianceEnterWar == 0)
		{
			return 3;
		}
		if (instance.AW_SignUpAllianceID != DataManager.Instance.RoleAlliance.Id)
		{
			return 2;
		}
		if (instance.AW_SignUpAllianceID == 0u)
		{
			return 1;
		}
		if (!UIAllianceWar_Rank.isDataReady)
		{
			return 4;
		}
		if (instance.AW_State != EAllianceWarState.EAWS_Replay)
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x04002E74 RID: 11892
	private const long dataCheckGap = 300L;

	// Token: 0x04002E75 RID: 11893
	private const float ZVal = 0f;

	// Token: 0x04002E76 RID: 11894
	private const int MaxReward = 4;

	// Token: 0x04002E77 RID: 11895
	private Transform AGS_Form;

	// Token: 0x04002E78 RID: 11896
	private Image glowLight;

	// Token: 0x04002E79 RID: 11897
	private UIText TimeCountDown;

	// Token: 0x04002E7A RID: 11898
	private float GetPointTime;

	// Token: 0x04002E7B RID: 11899
	private int bClose;

	// Token: 0x04002E7C RID: 11900
	private long nextCheckTime;

	// Token: 0x04002E7D RID: 11901
	private CString HintStr;

	// Token: 0x04002E7E RID: 11902
	private CString[] RankStr = new CString[3];

	// Token: 0x04002E7F RID: 11903
	private CString[] XStr = new CString[4];

	// Token: 0x04002E80 RID: 11904
	private CString GiftBoxStr;

	// Token: 0x04002E81 RID: 11905
	private CString countDownStr;

	// Token: 0x04002E82 RID: 11906
	private UIAlliance_Control RankAnime;

	// Token: 0x04002E83 RID: 11907
	private Transform[] RankPoint = new Transform[3];

	// Token: 0x04002E84 RID: 11908
	private RectTransform ImgUpRect;

	// Token: 0x04002E85 RID: 11909
	private RectTransform ImgDownRect;

	// Token: 0x04002E86 RID: 11910
	private bool OpenSecendFlyer;

	// Token: 0x04002E87 RID: 11911
	private float nextFlyer;

	// Token: 0x04002E88 RID: 11912
	public static bool isDataReady = false;

	// Token: 0x04002E89 RID: 11913
	public static uint DataAllianceID = 0u;

	// Token: 0x04002E8A RID: 11914
	public static byte[] RewardItemRare = new byte[4];

	// Token: 0x04002E8B RID: 11915
	public static ushort[] RewardItem = new ushort[4];

	// Token: 0x04002E8C RID: 11916
	public static ushort[] RewardItemCount = new ushort[4];

	// Token: 0x04002E8D RID: 11917
	public static byte[] RankLeastMemberCount = new byte[3];

	// Token: 0x020002C4 RID: 708
	public enum UpdateKind
	{
		// Token: 0x04002E8F RID: 11919
		Data = 1,
		// Token: 0x04002E90 RID: 11920
		Reflash,
		// Token: 0x04002E91 RID: 11921
		ReSendRequest
	}

	// Token: 0x020002C5 RID: 709
	private enum e_AGS_UIAllianceWar_Rank_Editor
	{
		// Token: 0x04002E93 RID: 11923
		BaseUnitReplace,
		// Token: 0x04002E94 RID: 11924
		BaseLook,
		// Token: 0x04002E95 RID: 11925
		GiftBlock,
		// Token: 0x04002E96 RID: 11926
		Rank,
		// Token: 0x04002E97 RID: 11927
		Text,
		// Token: 0x04002E98 RID: 11928
		AnimPoint
	}

	// Token: 0x020002C6 RID: 710
	private enum e_AGS_BaseLook
	{
		// Token: 0x04002E9A RID: 11930
		Img_info,
		// Token: 0x04002E9B RID: 11931
		Bar1,
		// Token: 0x04002E9C RID: 11932
		Bar2,
		// Token: 0x04002E9D RID: 11933
		text_Count,
		// Token: 0x04002E9E RID: 11934
		text_empty,
		// Token: 0x04002E9F RID: 11935
		Text,
		// Token: 0x04002EA0 RID: 11936
		Text_result,
		// Token: 0x04002EA1 RID: 11937
		btn_Rank1,
		// Token: 0x04002EA2 RID: 11938
		btn_Rank2,
		// Token: 0x04002EA3 RID: 11939
		btn_Add
	}

	// Token: 0x020002C7 RID: 711
	private enum e_AGS_GiftBlock
	{
		// Token: 0x04002EA5 RID: 11941
		UIButton,
		// Token: 0x04002EA6 RID: 11942
		Img_Get,
		// Token: 0x04002EA7 RID: 11943
		EndText,
		// Token: 0x04002EA8 RID: 11944
		Reward,
		// Token: 0x04002EA9 RID: 11945
		Img_RewardTime,
		// Token: 0x04002EAA RID: 11946
		Text
	}

	// Token: 0x020002C8 RID: 712
	private enum e_AGS_UIButton
	{
		// Token: 0x04002EAC RID: 11948
		Image,
		// Token: 0x04002EAD RID: 11949
		Text
	}

	// Token: 0x020002C9 RID: 713
	private enum e_AGS_Img_Get
	{
		// Token: 0x04002EAF RID: 11951
		Text
	}

	// Token: 0x020002CA RID: 714
	private enum e_AGS_Reward
	{
		// Token: 0x04002EB1 RID: 11953
		Item1,
		// Token: 0x04002EB2 RID: 11954
		Item2,
		// Token: 0x04002EB3 RID: 11955
		Item3,
		// Token: 0x04002EB4 RID: 11956
		Item4
	}

	// Token: 0x020002CB RID: 715
	private enum e_AGS_Item1
	{
		// Token: 0x04002EB6 RID: 11958
		UIHIBtn,
		// Token: 0x04002EB7 RID: 11959
		UIText
	}

	// Token: 0x020002CC RID: 716
	private enum e_AGS_Img_RewardTime
	{
		// Token: 0x04002EB9 RID: 11961
		Text
	}

	// Token: 0x020002CD RID: 717
	private enum e_AGS_Rank
	{
		// Token: 0x04002EBB RID: 11963
		Rank2,
		// Token: 0x04002EBC RID: 11964
		Rank3,
		// Token: 0x04002EBD RID: 11965
		Rank4,
		// Token: 0x04002EBE RID: 11966
		Up,
		// Token: 0x04002EBF RID: 11967
		Down
	}

	// Token: 0x020002CE RID: 718
	private enum e_AGS_Rank2
	{
		// Token: 0x04002EC1 RID: 11969
		Image,
		// Token: 0x04002EC2 RID: 11970
		Text
	}

	// Token: 0x020002CF RID: 719
	private enum e_AGS_Rank3
	{
		// Token: 0x04002EC4 RID: 11972
		Image,
		// Token: 0x04002EC5 RID: 11973
		Text
	}

	// Token: 0x020002D0 RID: 720
	private enum e_AGS_Rank4
	{
		// Token: 0x04002EC7 RID: 11975
		Image,
		// Token: 0x04002EC8 RID: 11976
		Text
	}

	// Token: 0x020002D1 RID: 721
	private enum e_AGS_AnimPoint
	{
		// Token: 0x04002ECA RID: 11978
		Point2,
		// Token: 0x04002ECB RID: 11979
		Point3,
		// Token: 0x04002ECC RID: 11980
		Point4,
		// Token: 0x04002ECD RID: 11981
		Image
	}
}
