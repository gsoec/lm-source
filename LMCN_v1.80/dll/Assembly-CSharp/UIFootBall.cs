using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000360 RID: 864
public class UIFootBall : GUIWindow, IDragHandler, IEventSystemHandler, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIFootballBtnDrag
{
	// Token: 0x060011B4 RID: 4532 RVA: 0x001EE7F8 File Offset: 0x001EC9F8
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.FM = FootballManager.Instance;
		this.TTFont = this.GUIM.GetTTFFont();
		this.GameT = base.gameObject.transform;
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		this.mFootBallID = this.FM.NowBallID;
		this.chaos = (GameManager.ActiveGameplay as CHAOS);
		this.Cstr_Combo = StringManager.Instance.SpawnString(100);
		this.Cstr_Hint = StringManager.Instance.SpawnString(200);
		this.Cstr_SendChat = StringManager.Instance.SpawnString(300);
		this.Cstr_SendToChat = StringManager.Instance.SpawnString(300);
		for (int i = 0; i < 4; i++)
		{
			this.Cstr_CDTime[i] = StringManager.Instance.SpawnString(100);
			this.Cstr_SkillSoldier[i] = StringManager.Instance.SpawnString(100);
			this.Cstr_SkillTime[i] = StringManager.Instance.SpawnString(100);
		}
		this.TcenterID = GameConstants.getTileMapPosbySpriteID(this.FM.mFootBallMapID);
		GameConstants.MapIDToPointCode(this.FM.mFootBallMapID, out this.ZoneID, out this.PointID);
		this.Distance_Total = DataManager.MapDataController.CalcDistance(this.FM.mFootBallMapID, this.DM.RoleAttr.CapitalPoint, 0);
		this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ATTACK_MARCH_SPEED);
		this.EGASpeed = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED);
		this.EGASpeed2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_DEBUFF);
		this.EGASpeed3 = 0u;
		this.EGASpeed4 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_CURSE);
		Transform child = this.GameT.GetChild(0);
		this.btn_Input = child.GetComponent<UIButton>();
		this.btn_Input.m_Handler = this;
		child = this.GameT.GetChild(1);
		this.Img_BG = child.GetComponent<Image>();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Img_BG.rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, this.Img_BG.rectTransform.offsetMin.y);
			this.Img_BG.rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, this.Img_BG.rectTransform.offsetMax.y);
		}
		RectTransform component = child.GetChild(0).GetComponent<RectTransform>();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component.anchoredPosition = new Vector2(component.anchoredPosition.x - this.GUIM.IPhoneX_DeltaX, component.anchoredPosition.y);
		}
		this.Btn_RT = this.GameT.GetChild(1).GetChild(0).GetComponent<RectTransform>();
		child = this.GameT.GetChild(1).GetChild(0).GetChild(0);
		this.btn_EXIT = child.GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 1;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		child = this.GameT.GetChild(1).GetChild(0).GetChild(1);
		this.btn_I = child.GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_I.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_I.m_Handler = this;
		this.btn_I.m_BtnID1 = 6;
		this.btn_I.m_EffectType = e_EffectType.e_Scale;
		this.btn_I.transition = Selectable.Transition.None;
		child = this.GameT.GetChild(1).GetChild(1);
		this.Img_Combo = child.GetComponent<Image>();
		this.Img_Combo.gameObject.SetActive(true);
		for (int j = 0; j < 2; j++)
		{
			child = this.GameT.GetChild(1).GetChild(1).GetChild(j);
			this.text_Combo[j] = child.GetComponent<UIText>();
			this.text_Combo[j].font = this.TTFont;
		}
		this.text_Combo[0].text = this.DM.mStringTable.GetStringByID(353u);
		this.SetCombo();
		for (int k = 0; k < 4; k++)
		{
			this.tmpSkill = this.FM.FootBallSkillTable.GetRecordByKey((ushort)(k + 1));
			child = this.GameT.GetChild(1).GetChild(2 + k).GetChild(0);
			this.text_SkillSoldierRank[k] = child.GetComponent<UIText>();
			this.text_SkillSoldierRank[k].font = this.TTFont;
			this.text_SkillSoldierRank[k].text = this.tmpSkill.NeedSoldierRank.ToString();
			child = this.GameT.GetChild(1).GetChild(2 + k).GetChild(1);
			this.text_SkillSoldier[k] = child.GetComponent<UIText>();
			this.text_SkillSoldier[k].font = this.TTFont;
			this.Cstr_SkillSoldier[k].ClearString();
			GameConstants.FormatResourceValue(this.Cstr_SkillSoldier[k], this.tmpSkill.NeedSoldierQty);
			this.text_SkillSoldier[k].text = this.Cstr_SkillSoldier[k].ToString();
			this.text_SkillSoldier[k].SetAllDirty();
			this.text_SkillSoldier[k].cachedTextGenerator.Invalidate();
		}
		for (int l = 0; l < 4; l++)
		{
			child = this.GameT.GetChild(1).GetChild(6).GetChild(l);
			this.text_SkillTime[l] = child.GetComponent<UIText>();
			this.text_SkillTime[l].font = this.TTFont;
			this.UpDataSkillInfo((byte)l);
			this.Cstr_SkillTime[l].ClearString();
			if (this.Time_Total > 3600u)
			{
				this.Cstr_SkillTime[l].IntToFormat((long)((ulong)(this.Time_Total / 3600u)), 2, false);
				this.Cstr_SkillTime[l].IntToFormat((long)((ulong)(this.Time_Total % 3600u / 60u)), 2, false);
				this.Cstr_SkillTime[l].IntToFormat((long)((ulong)(this.Time_Total % 60u)), 2, false);
				this.Cstr_SkillTime[l].AppendFormat("{0}:{1}:{2}");
			}
			else
			{
				this.Cstr_SkillTime[l].IntToFormat((long)((ulong)(this.Time_Total / 60u)), 2, false);
				this.Cstr_SkillTime[l].IntToFormat((long)((ulong)(this.Time_Total % 60u)), 2, false);
				this.Cstr_SkillTime[l].AppendFormat("{0}:{1}");
			}
			this.text_SkillTime[l].text = this.Cstr_SkillTime[l].ToString();
			this.text_SkillTime[l].SetAllDirty();
			this.text_SkillTime[l].cachedTextGenerator.Invalidate();
		}
		UIButtonHint uibuttonHint;
		for (int m = 0; m < 9; m++)
		{
			child = this.GameT.GetChild(1).GetChild(7 + m);
			this.Img_Hint[m] = child.GetComponent<Image>();
			uibuttonHint = this.Img_Hint[m].gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = (ushort)(1 + m);
		}
		this.tmpSkillT = this.GameT.GetChild(2);
		for (int n = 0; n < 4; n++)
		{
			this.SkillRT[n] = this.tmpSkillT.GetChild(n).GetComponent<RectTransform>();
			this.FootBtn[n] = this.tmpSkillT.GetChild(n).GetChild(0).GetComponent<UIFootballBtnDrag>();
			this.FootBtn[n].m_DHandler = this;
			this.FootBtn[n].m_BtnID1 = n + 1;
			this.FootBtn[n].m_BtnID2 = 2 + n;
			this.FootBtn[n].interactable = true;
			child = this.tmpSkillT.GetChild(n).GetChild(0).GetChild(0);
			this.text_tmpStr[n] = child.GetComponent<UIText>();
			this.text_tmpStr[n].font = this.TTFont;
			this.tmpSkill = this.FM.FootBallSkillTable.GetRecordByKey((ushort)(n + 1));
			this.text_tmpStr[n].text = this.tmpSkill.SkillStrength.ToString();
			this.Img_SkillF[n] = this.tmpSkillT.GetChild(n).GetChild(1).GetComponent<Image>();
			this.Img_SkillMask[n] = this.tmpSkillT.GetChild(n).GetChild(2).GetComponent<Image>();
			this.Img_SkillNo[n] = this.tmpSkillT.GetChild(n).GetChild(3).GetComponent<Image>();
			this.Img_SkillLock[n] = this.tmpSkillT.GetChild(n).GetChild(4).GetComponent<Image>();
			child = this.tmpSkillT.GetChild(n).GetChild(5);
			this.text_CD[n] = child.GetComponent<UIText>();
			this.text_CD[n].font = this.TTFont;
			this.CheckSkillUse((byte)n);
		}
		float num = 0f;
		for (int num2 = 1; num2 < 7; num2++)
		{
			if (this.mYolkID[1] == 0)
			{
				this.mYolkID[1] = (ushort)num2;
				num = DataManager.MapDataController.CalcDistance((int)DataManager.MapDataController.GetYolkMapID((ushort)num2, DataManager.MapDataController.OtherKingdomData.kingdomID), this.FM.mFootBallMapID, 0);
			}
			else
			{
				float num3 = DataManager.MapDataController.CalcDistance((int)DataManager.MapDataController.GetYolkMapID((ushort)num2, DataManager.MapDataController.OtherKingdomData.kingdomID), this.FM.mFootBallMapID, 0);
				if (num3 > num)
				{
					this.mYolkID[1] = (ushort)num2;
					num = num3;
				}
			}
		}
		ushort num4 = (DataManager.MapDataController.FocusKingdomID != 0) ? DataManager.MapDataController.FocusKingdomID : 1;
		for (int num5 = 0; num5 < 2; num5++)
		{
			child = this.GameT.GetChild(3 + num5);
			this.YolkRT[num5] = child.GetComponent<RectTransform>();
			this.Img_Yolk[num5] = child.GetChild(0).GetComponent<Image>();
			uibuttonHint = this.YolkRT[num5].gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = (ushort)(10 + num5);
			uibuttonHint.Parm2 = (byte)(1 + num5);
		}
		KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(num4);
		if (ActivityManager.Instance.IsInKvK(0, false) && num4 != ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.IsEnemy(num4))
		{
			this.Img_Yolk[0].sprite = this.SArray.m_Sprites[0];
			this.Img_Yolk[1].sprite = this.SArray.m_Sprites[7];
		}
		else
		{
			if (recordByKey.mapID < 6)
			{
				this.Img_Yolk[0].sprite = this.SArray.m_Sprites[(int)((recordByKey.mapID != 0) ? recordByKey.mapID : 1)];
			}
			this.Img_Yolk[1].sprite = this.SArray.m_Sprites[6];
		}
		child = this.GameT.GetChild(5);
		this.Img_FIFA_Hint = child.GetComponent<Image>();
		uibuttonHint = this.Img_FIFA_Hint.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 12;
		this.tmpSendChatT = this.GameT.GetChild(6);
		this.btn_SendChat = this.tmpSendChatT.GetChild(0).GetComponent<UIButton>();
		this.btn_SendChat.m_Handler = this;
		this.btn_SendChat.m_BtnID1 = 7;
		this.btn_SendChat.m_EffectType = e_EffectType.e_Scale;
		this.btn_SendChat.transition = Selectable.Transition.None;
		if (this.FM.mCloseFootBallSkill == 0)
		{
			this.bOpenEnd = true;
		}
		this.Btn_RT.transform.SetParent(this.GUIM.m_SecWindowLayer);
		this.Btn_RT.transform.SetAsLastSibling();
		this.tmpSendChatT.transform.SetParent(this.GUIM.m_SecWindowLayer);
		this.tmpSendChatT.transform.SetAsLastSibling();
		if (this.door)
		{
			this.door.SetMainMenuActive_FIFA(false);
		}
		this.Img_FIFA_Hint.rectTransform.anchoredPosition = new Vector2(11f, this.Img_FIFA_Hint.rectTransform.anchoredPosition.y);
		if (this.chaos != null && this.chaos.realmController != null)
		{
			if (FootballManager.Instance.mUIOpenState == 0)
			{
				FootballManager.Instance.mUIOpenState = 1;
			}
			else
			{
				this.UpdateUI(7, 0);
			}
		}
		this.Img_BG.gameObject.SetActive(false);
		this.tmpSkillT.gameObject.SetActive(false);
		for (int num6 = 0; num6 < 2; num6++)
		{
			this.YolkRT[num6].gameObject.SetActive(false);
		}
		this.Btn_RT.gameObject.SetActive(false);
		this.tmpSendChatT.gameObject.SetActive(false);
	}

	// Token: 0x060011B5 RID: 4533 RVA: 0x001EF5E8 File Offset: 0x001ED7E8
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(17200u), 255, true);
			break;
		case 1:
			this.GUIM.CloseMenu(this.m_eWindow);
			this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			break;
		case 6:
			this.GUIM.CloseMenu(this.m_eWindow);
			this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			this.door.OpenMenu(EGUIWindow.UI_FootBall_Info, 0, 0, false);
			break;
		case 7:
		{
			if (this.DM.RoleAlliance.Id == 0u && GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 8)
			{
				this.GUIM.MsgStr.ClearString();
				this.GUIM.MsgStr.IntToFormat(8L, 1, false);
				this.GUIM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(9167u));
				this.GUIM.AddHUDMessage(this.GUIM.MsgStr.ToString(), 255, true);
				return;
			}
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			this.GetLocation(cstring, this.FM.mFootBallMapID, true);
			this.Cstr_SendChat.ClearString();
			this.Cstr_SendChat.StringToFormat(cstring);
			if (this.DM.RoleAlliance.Id == 0u)
			{
				this.Cstr_SendChat.AppendFormat(this.DM.mStringTable.GetStringByID(17214u));
			}
			else
			{
				this.Cstr_SendChat.AppendFormat(this.DM.mStringTable.GetStringByID(17213u));
			}
			this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(17212u), this.Cstr_SendChat.ToString(), 1, 0, this.DM.mStringTable.GetStringByID(5026u), this.DM.mStringTable.GetStringByID(5025u));
			break;
		}
		}
	}

	// Token: 0x060011B6 RID: 4534 RVA: 0x001EF840 File Offset: 0x001EDA40
	public void GetLocation(CString m_Str, int MapPointID, bool bHaveArbText = false)
	{
		Vector2 tileMapPosbySpriteID = GameConstants.getTileMapPosbySpriteID(MapPointID);
		if (GUIManager.Instance.IsArabic)
		{
			if (bHaveArbText)
			{
				m_Str.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4504u));
				m_Str.IntToFormat((long)DataManager.MapDataController.FocusKingdomID, 1, false);
				m_Str.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4505u));
				m_Str.IntToFormat((long)((int)tileMapPosbySpriteID.x), 1, false);
				m_Str.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4506u));
				m_Str.IntToFormat((long)((int)tileMapPosbySpriteID.y), 1, false);
				m_Str.AppendFormat("{1}{0} {3}{2} {5}{4}");
			}
			else
			{
				m_Str.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4504u));
				m_Str.IntToFormat((long)DataManager.MapDataController.FocusKingdomID, 1, false);
				m_Str.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4505u));
				m_Str.IntToFormat((long)((int)tileMapPosbySpriteID.x), 1, false);
				m_Str.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4506u));
				m_Str.IntToFormat((long)((int)tileMapPosbySpriteID.y), 1, false);
				m_Str.AppendFormat("{5}{4} {3}{2} {1}{0}");
			}
		}
		else
		{
			m_Str.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4504u));
			m_Str.IntToFormat((long)DataManager.MapDataController.FocusKingdomID, 1, false);
			m_Str.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4505u));
			m_Str.IntToFormat((long)((int)tileMapPosbySpriteID.x), 1, false);
			m_Str.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4506u));
			m_Str.IntToFormat((long)((int)tileMapPosbySpriteID.y), 1, false);
			m_Str.AppendFormat("{0}{1} {2}{3} {4}{5}");
		}
	}

	// Token: 0x060011B7 RID: 4535 RVA: 0x001EFA30 File Offset: 0x001EDC30
	public void OnPointerDown(UIFootballBtnDrag sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
		if (this.bShowFirstOpen)
		{
			NewbieManager.Get().UIController.ShowPointer(false, null, null);
			this.bShowFirstOpen = false;
		}
		switch (sender.m_BtnID1)
		{
		case 1:
		case 2:
		case 3:
		case 4:
		{
			this.mSkillID = 0;
			int num = sender.m_BtnID1 - 1;
			this.Img_SkillF[num].gameObject.SetActive(!this.IsOnLock[num] && !this.IsNeedQty[num] && !this.IsCDTime[num]);
			if (this.Img_SkillF[num].gameObject.activeInHierarchy)
			{
				this.mSkillID = (ushort)sender.m_BtnID1;
				this.mInGO = sender.gameObject;
				if (this.chaos != null && this.chaos.realmController != null)
				{
					this.chaos.realmController.SetFootBallSkillID(this.mSkillID);
				}
			}
			break;
		}
		}
	}

	// Token: 0x060011B8 RID: 4536 RVA: 0x001EFB5C File Offset: 0x001EDD5C
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.mInGO != null && (eventData.pointerEnter == this.btn_Input.gameObject || eventData.pointerEnter == this.YolkRT[0].gameObject || eventData.pointerEnter == this.YolkRT[1].gameObject || eventData.pointerEnter == this.Img_FIFA_Hint.gameObject))
		{
			if (this.chaos != null && this.chaos.realmController != null)
			{
				this.chaos.realmController.OnPointerUp(eventData);
			}
			byte b = (byte)this.chaos.realmController.mapTileController.FootBallGetSkill(eventData);
			this.mSkillID = (ushort)Mathf.Clamp((int)this.mSkillID, 1, 4);
			if (b > 0 && this.mSkillID > 0 && this.Img_SkillF[(int)(this.mSkillID - 1)].gameObject.activeInHierarchy)
			{
				this.FM.SendFootBall_Skill(this.ZoneID, this.PointID, this.mSkillID, b);
			}
			else
			{
				this.ShowSkillMsg((int)(this.mSkillID - 1));
			}
			this.HideSkillEffect();
		}
		else if (this.mInGO != null)
		{
			this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(17200u), 255, true);
			this.HideSkillEffect();
		}
		if (this.mSkillID > 0 && this.Img_SkillF[(int)(this.mSkillID - 1)].gameObject.activeInHierarchy)
		{
			this.Img_SkillF[(int)(this.mSkillID - 1)].gameObject.SetActive(false);
		}
	}

	// Token: 0x060011B9 RID: 4537 RVA: 0x001EFD38 File Offset: 0x001EDF38
	public void OnDrag(PointerEventData eventData)
	{
		if (this.mInGO != null && (eventData.pointerEnter == this.btn_Input.gameObject || eventData.pointerEnter == this.YolkRT[0].gameObject || eventData.pointerEnter == this.YolkRT[1].gameObject || eventData.pointerEnter == this.Img_FIFA_Hint.gameObject))
		{
			if (this.chaos != null && this.chaos.realmController != null)
			{
				this.chaos.realmController.OnDrag(eventData);
			}
		}
		else if (this.chaos != null && this.chaos.realmController != null)
		{
			this.chaos.realmController.SetHideFootBallSkill();
		}
	}

	// Token: 0x060011BA RID: 4538 RVA: 0x001EFE30 File Offset: 0x001EE030
	public void OnPointerClick(UIFootballBtnDrag sender)
	{
		switch (sender.m_BtnID2)
		{
		case 2:
			if (!this.Img_SkillF[0].gameObject.activeInHierarchy)
			{
				this.ShowSkillMsg(sender.m_BtnID2 - 2);
			}
			break;
		case 3:
			if (!this.Img_SkillF[1].gameObject.activeInHierarchy)
			{
				this.ShowSkillMsg(sender.m_BtnID2 - 2);
			}
			break;
		case 4:
			if (!this.Img_SkillF[2].gameObject.activeInHierarchy)
			{
				this.ShowSkillMsg(sender.m_BtnID2 - 2);
			}
			break;
		case 5:
			if (!this.Img_SkillF[3].gameObject.activeInHierarchy)
			{
				this.ShowSkillMsg(sender.m_BtnID2 - 2);
			}
			break;
		}
	}

	// Token: 0x060011BB RID: 4539 RVA: 0x001EFF0C File Offset: 0x001EE10C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 == 1)
			{
				byte channel = 0;
				if (this.DM.RoleAlliance.Id != 0u)
				{
					channel = 1;
				}
				CString cstring = StringManager.Instance.StaticString1024();
				this.GetLocation(cstring, this.FM.mFootBallMapID, true);
				this.Cstr_SendToChat.ClearString();
				this.Cstr_SendToChat.StringToFormat(this.DM.mStringTable.GetStringByID(14739u));
				this.Cstr_SendToChat.StringToFormat(cstring);
				this.Cstr_SendToChat.AppendFormat("{0} {1}");
				this.Cstr_SendToChat.SetLength(this.Cstr_SendToChat.Length);
				if (this.GUIM.SendChat(channel, this.Cstr_SendToChat.ToString()))
				{
					this.GUIM.MsgStr.ClearString();
					this.GUIM.MsgStr.Append(this.DM.mStringTable.GetStringByID(17215u));
					this.GUIM.AddHUDMessage(this.GUIM.MsgStr.ToString(), 255, true);
				}
				this.Cstr_SendToChat.SetLength(this.Cstr_SendToChat.MaxLength);
			}
		}
	}

	// Token: 0x060011BC RID: 4540 RVA: 0x001F0050 File Offset: 0x001EE250
	public override void OnClose()
	{
		DataManager.msgBuffer[0] = 112;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		if (this.Btn_RT != null)
		{
			UnityEngine.Object.Destroy(this.Btn_RT.gameObject);
		}
		this.Btn_RT = null;
		if (this.tmpSendChatT != null)
		{
			UnityEngine.Object.Destroy(this.tmpSendChatT.gameObject);
		}
		this.tmpSendChatT = null;
		if (this.chaos != null && this.chaos.realmController != null)
		{
			this.chaos.realmController.ClearFootBall();
		}
		if (this.Cstr_Combo != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Combo);
		}
		if (this.Cstr_Hint != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Hint);
		}
		if (this.Cstr_SendChat != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_SendChat);
		}
		if (this.Cstr_SendToChat != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_SendToChat);
		}
		for (int i = 0; i < 4; i++)
		{
			if (this.Cstr_CDTime[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_CDTime[i]);
			}
			if (this.Cstr_SkillSoldier[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_SkillSoldier[i]);
			}
			if (this.Cstr_SkillTime[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_SkillTime[i]);
			}
		}
		if (this.bShowFirstOpen)
		{
			NewbieManager.Get().UIController.ShowPointer(false, null, null);
			this.bShowFirstOpen = false;
		}
		if (this.door)
		{
			this.door.SetMainMenuActive_FIFA(true);
		}
		this.GUIM.CloseOKCancelBox();
	}

	// Token: 0x060011BD RID: 4541 RVA: 0x001F0230 File Offset: 0x001EE430
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x060011BE RID: 4542 RVA: 0x001F0234 File Offset: 0x001EE434
	public void OnButtonDown(UIButtonHint sender)
	{
		this.Cstr_Hint.ClearString();
		switch (sender.Parm1)
		{
		case 1:
		case 2:
		case 3:
		case 4:
			this.tmpSkill = this.FM.FootBallSkillTable.GetRecordByKey(sender.Parm1);
			this.Cstr_Hint.IntToFormat((long)this.tmpSkill.NeedSoldierRank, 1, false);
			this.Cstr_Hint.IntToFormat((long)((ulong)this.tmpSkill.NeedSoldierQty), 1, true);
			this.Cstr_Hint.AppendFormat(this.DM.mStringTable.GetStringByID(17209u));
			break;
		case 5:
		case 6:
		case 7:
		case 8:
			this.Cstr_Hint.Append(this.DM.mStringTable.GetStringByID(337u));
			break;
		case 9:
			this.Cstr_Hint.Append(this.DM.mStringTable.GetStringByID(17210u));
			break;
		case 10:
		case 11:
			if (DataManager.MapDataController.FocusKingdomID != 0)
			{
				this.KID = DataManager.MapDataController.FocusKingdomID;
			}
			else
			{
				this.KID = DataManager.MapDataController.OtherKingdomData.kingdomID;
			}
			this.Cstr_Hint.Append(DataManager.MapDataController.GetYolkName(this.mYolkID[(int)(sender.Parm1 - 10)], this.KID));
			break;
		case 12:
			this.Cstr_Hint.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11243u));
			break;
		}
		this.GUIM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.Cstr_Hint, Vector2.zero);
	}

	// Token: 0x060011BF RID: 4543 RVA: 0x001F0404 File Offset: 0x001EE604
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x060011C0 RID: 4544 RVA: 0x001F0418 File Offset: 0x001EE618
	public void CheckSkillUse(byte mIdx)
	{
		this.text_CD[(int)mIdx].gameObject.SetActive(false);
		bool flag = this.IsOnLock[(int)mIdx] = this.CheckSkillLock(mIdx);
		bool flag2 = this.IsNeedQty[(int)mIdx] = this.CheckNeedSoldierQty(mIdx);
		bool flag3 = this.IsCDTime[(int)mIdx] = (this.FM.mFootballSkillCDTime[(int)mIdx] != 0L && this.FM.mFootballSkillCDTime[(int)mIdx] - this.DM.ServerTime > 0L);
		this.SkillRT[(int)mIdx].localScale = ((flag || flag2 || flag3) ? this.mNoUse : this.mCanUse);
		this.Img_SkillLock[(int)mIdx].gameObject.SetActive(flag);
		if (!flag)
		{
			this.Img_SkillNo[(int)mIdx].gameObject.SetActive(flag2);
			this.text_SkillSoldier[(int)mIdx].color = (flag2 ? this.mNoEnQty : this.mEnQty);
			if (!flag2 && flag3)
			{
				this.text_CD[(int)mIdx].gameObject.SetActive(true);
				this.text_CD[(int)mIdx].text = (this.FM.mFootballSkillCDTime[(int)mIdx] - this.DM.ServerTime).ToString();
				this.text_CD[(int)mIdx].SetAllDirty();
				this.text_CD[(int)mIdx].cachedTextGenerator.Invalidate();
			}
		}
		else
		{
			this.Img_SkillNo[(int)mIdx].gameObject.SetActive(false);
			this.text_SkillSoldier[(int)mIdx].color = this.mEnQty;
		}
		this.Img_SkillMask[(int)mIdx].gameObject.SetActive(flag || flag2 || flag3);
		this.UpDataSkillInfo(mIdx);
		this.Cstr_SkillTime[(int)mIdx].ClearString();
		if (flag || flag2)
		{
			this.Cstr_SkillTime[(int)mIdx].Append(this.DM.mStringTable.GetStringByID(17135u));
		}
		else if (this.Time_Total > 3600u)
		{
			this.Cstr_SkillTime[(int)mIdx].IntToFormat((long)((ulong)(this.Time_Total / 3600u)), 2, false);
			this.Cstr_SkillTime[(int)mIdx].IntToFormat((long)((ulong)(this.Time_Total % 3600u / 60u)), 2, false);
			this.Cstr_SkillTime[(int)mIdx].IntToFormat((long)((ulong)(this.Time_Total % 60u)), 2, false);
			this.Cstr_SkillTime[(int)mIdx].AppendFormat("{0}:{1}:{2}");
		}
		else
		{
			this.Cstr_SkillTime[(int)mIdx].IntToFormat((long)((ulong)(this.Time_Total / 60u)), 2, false);
			this.Cstr_SkillTime[(int)mIdx].IntToFormat((long)((ulong)(this.Time_Total % 60u)), 2, false);
			this.Cstr_SkillTime[(int)mIdx].AppendFormat("{0}:{1}");
		}
		this.text_SkillTime[(int)mIdx].text = this.Cstr_SkillTime[(int)mIdx].ToString();
		this.text_SkillTime[(int)mIdx].SetAllDirty();
		this.text_SkillTime[(int)mIdx].cachedTextGenerator.Invalidate();
	}

	// Token: 0x060011C1 RID: 4545 RVA: 0x001F0720 File Offset: 0x001EE920
	public bool CheckSkillLock(byte mIdx)
	{
		bool result = true;
		for (int i = 0; i < 4; i++)
		{
			int num = (int)mIdx + i * 4;
			this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num + 1));
			if (this.tmpSD.Science == 0 || this.DM.GetTechLevel(this.tmpSD.Science) > 0)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	// Token: 0x060011C2 RID: 4546 RVA: 0x001F0798 File Offset: 0x001EE998
	public bool CheckNeedSoldierQty(byte mIdx)
	{
		uint num = 0u;
		for (int i = 0; i < 4; i++)
		{
			int num2 = (int)mIdx + i * 4;
			num += this.DM.RoleAttr.m_Soldier[num2];
		}
		this.tmpSkill = this.FM.FootBallSkillTable.GetRecordByKey((ushort)(mIdx + 1));
		return this.tmpSkill.NeedSoldierQty > num;
	}

	// Token: 0x060011C3 RID: 4547 RVA: 0x001F080C File Offset: 0x001EEA0C
	public void ShowSkillMsg(int Idx)
	{
		Idx = Mathf.Clamp(Idx, 0, this.IsOnLock.Length);
		this.GUIM.MsgStr.ClearString();
		if (this.IsOnLock[Idx])
		{
			this.GUIM.MsgStr.IntToFormat((long)(Idx + 1), 1, false);
			this.GUIM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(17197u));
			this.GUIM.AddHUDMessage(this.GUIM.MsgStr.ToString(), 255, true);
		}
		else if (this.IsNeedQty[Idx])
		{
			this.GUIM.MsgStr.IntToFormat((long)(Idx + 1), 1, false);
			this.GUIM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(17199u));
			this.GUIM.AddHUDMessage(this.GUIM.MsgStr.ToString(), 255, true);
		}
		else if (this.IsCDTime[Idx])
		{
			this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(17198u), 255, true);
		}
		else
		{
			this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(17200u), 255, true);
			if (this.mSkillID > 0 && this.Img_SkillF[(int)(this.mSkillID - 1)].gameObject.activeInHierarchy)
			{
				this.Img_SkillF[(int)(this.mSkillID - 1)].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x060011C4 RID: 4548 RVA: 0x001F09BC File Offset: 0x001EEBBC
	public void HideSkillEffect()
	{
		if (this.chaos != null && this.chaos.realmController != null)
		{
			this.chaos.realmController.SetHideFootBallSkill();
		}
		this.mInGO = null;
	}

	// Token: 0x060011C5 RID: 4549 RVA: 0x001F0A04 File Offset: 0x001EEC04
	public void SetCombo()
	{
		this.EGASpeed5 = this.GetEGASpeed();
		this.Cstr_Combo.ClearString();
		int num = (int)(this.EGAKind + this.EGASpeed - this.EGASpeed2 + this.EGASpeed3 + this.EGASpeed5);
		if ((float)num % 100f != 0f)
		{
			this.Cstr_Combo.FloatToFormat((float)num / 100f, 2, false);
		}
		else
		{
			this.Cstr_Combo.IntToFormat((long)(num / 100), 1, false);
		}
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Combo.AppendFormat("%{0}+");
		}
		else
		{
			this.Cstr_Combo.AppendFormat("+{0}%");
		}
		this.text_Combo[1].text = this.Cstr_Combo.ToString();
		this.text_Combo[1].SetAllDirty();
		this.text_Combo[1].cachedTextGenerator.Invalidate();
	}

	// Token: 0x060011C6 RID: 4550 RVA: 0x001F0AF8 File Offset: 0x001EECF8
	public uint GetEGASpeed()
	{
		uint result = 0u;
		if (this.FM.mFootballKickData.last_football_id != 0u && this.FM.mFootballKickData.last_football_id == this.mFootBallID && this.FM.mFootballKickData.last_kick_time + 7200L - this.DM.ServerTime > 0L)
		{
			if (this.FM.FootBallComboTable.TableCount > (int)this.FM.mFootballKickData.combo)
			{
				this.tmpCombo = this.FM.FootBallComboTable.GetRecordByKey(this.FM.mFootballKickData.combo);
			}
			else
			{
				this.tmpCombo = this.FM.FootBallComboTable.GetRecordByKey((ushort)this.FM.FootBallComboTable.TableCount);
			}
			result = this.tmpCombo.Combo;
		}
		return result;
	}

	// Token: 0x060011C7 RID: 4551 RVA: 0x001F0BE8 File Offset: 0x001EEDE8
	public void UpDataSkillInfo(byte mRank)
	{
		this.tmpSkill = this.FM.FootBallSkillTable.GetRecordByKey((ushort)(mRank + 1));
		this.EGASpeed5 = this.GetEGASpeed();
		uint num = 0u;
		int num2 = 0;
		int num3;
		for (int i = 0; i < 4; i++)
		{
			num3 = (int)(mRank + this.mSpeedIdx[i] * 4);
			num += this.DM.RoleAttr.m_Soldier[num3];
			if (num >= this.tmpSkill.NeedSoldierQty)
			{
				num2 = i;
				break;
			}
		}
		num3 = (int)(mRank + this.mSpeedIdx[num2] * 4);
		this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num3 + 1));
		this.tmpTime = (10000u + this.EGASpeed4) / (10000u + this.EGAKind + this.EGASpeed - this.EGASpeed2 + this.EGASpeed3 + this.EGASpeed5);
		this.Time_Total = GameConstants.appCeil(GameConstants.FastInvSqrt(this.Distance_Total * this.Distance_Total) * ((float)this.tmpSD.Speed * this.tmpTime));
	}

	// Token: 0x060011C8 RID: 4552 RVA: 0x001F0D04 File Offset: 0x001EEF04
	public Vector2 FootBallGetYolkLocation(ushort mYolkID)
	{
		Vector2 b = Vector2.zero;
		Vector2 a = Vector2.zero;
		Vector2 from = Vector2.zero;
		Vector2 vector = Vector2.zero;
		b = this.TcenterID;
		a = DataManager.MapDataController.GetYolkPos(mYolkID, DataManager.MapDataController.OtherKingdomData.kingdomID);
		from = a - b;
		from.x *= 2f;
		float num;
		if (GUIManager.Instance.IsArabic)
		{
			num = Vector2.Angle(from, Vector2.up) * (float)((from.x >= 0f) ? -1 : 1);
		}
		else
		{
			num = Vector2.Angle(from, Vector2.up) * (float)((from.x >= 0f) ? 1 : -1);
		}
		int num2 = 1;
		int num3 = 1;
		if (num > 0f && num < 90f)
		{
			num = 90f - num;
			num3 = -1;
		}
		else if (num > 0f && num < 180f)
		{
			num -= 90f;
		}
		else if (num < 0f && num > -90f)
		{
			num = -(90f - num);
			num2 = -1;
			num3 = -1;
		}
		else if (num < 0f && num > -180f)
		{
			num = -num - 90f;
			num2 = -1;
		}
		float num4 = 256f / (1f + 2f * Mathf.Tan(num * 3.14159274f / 180f));
		float num5 = (256f - num4) / 2f;
		if (num == 0f || num == 180f)
		{
			if (from.x == 0f)
			{
				num4 = 0f;
				num5 = (256f - num4) / 2f;
				if (from.y > 0f)
				{
					num3 = -1;
				}
			}
			else
			{
				num4 = 256f;
				num5 = 0f;
				if (from.x > 0f)
				{
					num2 = 1;
				}
			}
		}
		vector.Set(num4 * (float)num2, num5 * (float)num3 + 50f);
		if (this.FM.mFootBallCenterPos != Vector2.zero)
		{
			vector += this.FM.mFootBallCenterPos * DataManager.MapDataController.zoomSize;
		}
		return vector;
	}

	// Token: 0x060011C9 RID: 4553 RVA: 0x001F0F84 File Offset: 0x001EF184
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Soldier)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				this.ReSetSkillCountDown();
			}
		}
		else
		{
			this.ReSetSkillCountDown();
			this.SetCombo();
			this.HideSkillEffect();
		}
	}

	// Token: 0x060011CA RID: 4554 RVA: 0x001F0FE0 File Offset: 0x001EF1E0
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < 2; i++)
		{
			if (this.text_Combo[i] != null && this.text_Combo[i].enabled)
			{
				this.text_Combo[i].enabled = false;
				this.text_Combo[i].enabled = true;
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (this.text_SkillSoldierRank[j] != null && this.text_SkillSoldierRank[j].enabled)
			{
				this.text_SkillSoldierRank[j].enabled = false;
				this.text_SkillSoldierRank[j].enabled = true;
			}
			if (this.text_SkillSoldier[j] != null && this.text_SkillSoldier[j].enabled)
			{
				this.text_SkillSoldier[j].enabled = false;
				this.text_SkillSoldier[j].enabled = true;
			}
			if (this.text_SkillTime[j] != null && this.text_SkillTime[j].enabled)
			{
				this.text_SkillTime[j].enabled = false;
				this.text_SkillTime[j].enabled = true;
			}
			if (this.text_tmpStr[j] != null && this.text_tmpStr[j].enabled)
			{
				this.text_tmpStr[j].enabled = false;
				this.text_tmpStr[j].enabled = true;
			}
			if (this.text_CD[j] != null && this.text_CD[j].enabled)
			{
				this.text_CD[j].enabled = false;
				this.text_CD[j].enabled = true;
			}
		}
	}

	// Token: 0x060011CB RID: 4555 RVA: 0x001F1198 File Offset: 0x001EF398
	public void ReSetSkillCountDown()
	{
		for (int i = 0; i < 4; i++)
		{
			this.CheckSkillUse((byte)i);
		}
	}

	// Token: 0x060011CC RID: 4556 RVA: 0x001F11C0 File Offset: 0x001EF3C0
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			if (arg2 == 255)
			{
				this.ReSetSkillCountDown();
			}
			else
			{
				arg2 = (int)((ushort)Mathf.Clamp(arg2, 0, 3));
				this.CheckSkillUse((byte)arg2);
			}
			break;
		case 2:
			this.SetCombo();
			break;
		case 3:
			if (arg2 == 1)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14737u), 255, true);
			}
			else if (arg2 == 2)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14738u), 255, true);
			}
			else if (arg2 == 3)
			{
				ActivityManager instance = ActivityManager.Instance;
				if (instance.NowWaveEndTime == 0L || instance.GetFIFAState() != EActivityState.EAS_Run)
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14738u), 255, true);
				}
			}
			this.GUIM.CloseMenu(this.m_eWindow);
			this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			break;
		case 4:
			this.mInGO = null;
			if (this.mSkillID > 0 && this.Img_SkillF[(int)(this.mSkillID - 1)].gameObject.activeInHierarchy)
			{
				this.Img_SkillF[(int)(this.mSkillID - 1)].gameObject.SetActive(false);
			}
			break;
		case 5:
			if (this.door != null && this.door.FIFATimeObj.activeInHierarchy)
			{
				this.Img_FIFA_Hint.rectTransform.anchoredPosition = new Vector2(this.Img_FIFA_Hint.rectTransform.anchoredPosition.x, ((RectTransform)this.door.FIFATimeObj.transform).anchoredPosition.y);
			}
			break;
		case 6:
		{
			this.Img_BG.gameObject.SetActive(true);
			this.tmpSkillT.gameObject.SetActive(true);
			this.Btn_RT.gameObject.SetActive(true);
			this.tmpSendChatT.gameObject.SetActive(true);
			if (this.chaos != null && this.chaos.realmController != null)
			{
				this.chaos.realmController.OpenFootBall();
			}
			int num = (this.FM.mFootBallMapID + 512 >= 262144) ? this.FM.mFootBallMapID : (this.FM.mFootBallMapID + 512);
			if (num != this.FM.mFootBallMapID)
			{
				this.FM.mFootBallCenterPos.Set(0f, 128f);
				ushort zoneID = 0;
				byte pointID = 0;
				GameConstants.MapIDToPointCode(num, out zoneID, out pointID);
				if (this.chaos != null && this.chaos.realmController != null && this.chaos.realmController.mapTileController)
				{
					this.FM.mFootBallCenterPos += this.chaos.realmController.mapTileController.getTilePosition(zoneID, pointID);
				}
			}
			else
			{
				this.FM.mFootBallCenterPos = Vector2.zero;
			}
			for (int i = 0; i < 2; i++)
			{
				this.YolkRT[i].anchoredPosition = this.FootBallGetYolkLocation(this.mYolkID[i]);
				this.YolkRT[i].gameObject.SetActive(true);
			}
			if (this.chaos != null && this.chaos.realmController != null)
			{
				this.chaos.realmController.SetFootBallSelect();
			}
			if (this.FM.bFirstOpen && this.bSetMapSelect)
			{
				Vector2 vector = NewbieManager.Get().UIController.ScreenPointTest(this.SkillRT[0]);
				vector -= new Vector2(0f, 50f);
				Vector2 vector2 = this.FM.mFootBallCenterPos / 128f;
				vector2 = Camera.main.WorldToScreenPoint(vector2);
				NewbieManager.Get().UIController.ToEnemyPointer(vector, vector2);
				this.FM.bFirstOpen = false;
				this.bShowFirstOpen = true;
			}
			break;
		}
		case 7:
			this.bSetMapSelect = true;
			break;
		}
	}

	// Token: 0x060011CD RID: 4557 RVA: 0x001F1664 File Offset: 0x001EF864
	public override void UpdateTime(bool bOnSecond)
	{
		if (!this.bOpenEnd)
		{
			if (this.FM.mCloseFootBallSkill == 1)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14737u), 255, true);
			}
			this.GUIM.CloseMenu(this.m_eWindow);
			this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		}
		if (bOnSecond && this.bOpenEnd)
		{
			for (int i = 0; i < 4; i++)
			{
				if (this.text_CD[i].gameObject.activeInHierarchy)
				{
					this.mTime = this.FM.mFootballSkillCDTime[i] - this.DM.ServerTime;
					if (this.FM.mFootballSkillCDTime[i] != 0L && this.FM.mFootballSkillCDTime[i] - this.DM.ServerTime <= 0L)
					{
						this.mTime = 0L;
						this.CheckSkillUse((byte)i);
						this.text_CD[i].gameObject.SetActive(false);
					}
					this.Cstr_CDTime[i].ClearString();
					StringManager.IntToStr(this.Cstr_CDTime[i], this.mTime, 1, false);
					this.text_CD[i].text = this.Cstr_CDTime[i].ToString();
					this.text_CD[i].SetAllDirty();
					this.text_CD[i].cachedTextGenerator.Invalidate();
				}
			}
		}
	}

	// Token: 0x060011CE RID: 4558 RVA: 0x001F17DC File Offset: 0x001EF9DC
	private void Start()
	{
	}

	// Token: 0x060011CF RID: 4559 RVA: 0x001F17E0 File Offset: 0x001EF9E0
	private void Update()
	{
	}

	// Token: 0x04003851 RID: 14417
	private DataManager DM;

	// Token: 0x04003852 RID: 14418
	private GUIManager GUIM;

	// Token: 0x04003853 RID: 14419
	private FootballManager FM;

	// Token: 0x04003854 RID: 14420
	private Font TTFont;

	// Token: 0x04003855 RID: 14421
	private Door door;

	// Token: 0x04003856 RID: 14422
	private Transform GameT;

	// Token: 0x04003857 RID: 14423
	private Transform tmpSkillT;

	// Token: 0x04003858 RID: 14424
	private Transform tmpSendChatT;

	// Token: 0x04003859 RID: 14425
	private RectTransform[] SkillRT = new RectTransform[4];

	// Token: 0x0400385A RID: 14426
	private RectTransform[] YolkRT = new RectTransform[2];

	// Token: 0x0400385B RID: 14427
	private RectTransform Btn_RT;

	// Token: 0x0400385C RID: 14428
	private UIButton btn_Input;

	// Token: 0x0400385D RID: 14429
	private UIButton btn_EXIT;

	// Token: 0x0400385E RID: 14430
	private UIButton btn_I;

	// Token: 0x0400385F RID: 14431
	private UIButton btn_SendChat;

	// Token: 0x04003860 RID: 14432
	private UIFootballBtnDrag[] FootBtn = new UIFootballBtnDrag[4];

	// Token: 0x04003861 RID: 14433
	private Image Img_BG;

	// Token: 0x04003862 RID: 14434
	private Image Img_Combo;

	// Token: 0x04003863 RID: 14435
	private Image Img_FIFA_Hint;

	// Token: 0x04003864 RID: 14436
	private Image[] Img_SkillF = new Image[4];

	// Token: 0x04003865 RID: 14437
	private Image[] Img_SkillLock = new Image[4];

	// Token: 0x04003866 RID: 14438
	private Image[] Img_SkillNo = new Image[4];

	// Token: 0x04003867 RID: 14439
	private Image[] Img_SkillMask = new Image[4];

	// Token: 0x04003868 RID: 14440
	private Image[] Img_Yolk = new Image[2];

	// Token: 0x04003869 RID: 14441
	private Image[] Img_Hint = new Image[9];

	// Token: 0x0400386A RID: 14442
	private UIText[] text_tmpStr = new UIText[4];

	// Token: 0x0400386B RID: 14443
	private UIText[] text_CD = new UIText[4];

	// Token: 0x0400386C RID: 14444
	private UIText[] text_Combo = new UIText[2];

	// Token: 0x0400386D RID: 14445
	private UIText[] text_SkillSoldier = new UIText[4];

	// Token: 0x0400386E RID: 14446
	private UIText[] text_SkillSoldierRank = new UIText[4];

	// Token: 0x0400386F RID: 14447
	private UIText[] text_SkillTime = new UIText[4];

	// Token: 0x04003870 RID: 14448
	private CString Cstr_Combo;

	// Token: 0x04003871 RID: 14449
	private CString Cstr_Hint;

	// Token: 0x04003872 RID: 14450
	private CString Cstr_SendChat;

	// Token: 0x04003873 RID: 14451
	private CString Cstr_SendToChat;

	// Token: 0x04003874 RID: 14452
	private CString[] Cstr_CDTime = new CString[4];

	// Token: 0x04003875 RID: 14453
	private CString[] Cstr_SkillSoldier = new CString[4];

	// Token: 0x04003876 RID: 14454
	private CString[] Cstr_SkillTime = new CString[4];

	// Token: 0x04003877 RID: 14455
	private UISpritesArray SArray;

	// Token: 0x04003878 RID: 14456
	private ushort ZoneID;

	// Token: 0x04003879 RID: 14457
	private byte PointID;

	// Token: 0x0400387A RID: 14458
	public Image[] m_Pointer = new Image[5];

	// Token: 0x0400387B RID: 14459
	public RectTransform[] m_PointerTrans = new RectTransform[5];

	// Token: 0x0400387C RID: 14460
	public bool bPointerShow;

	// Token: 0x0400387D RID: 14461
	public Vector2 StartPoint = Vector2.zero;

	// Token: 0x0400387E RID: 14462
	public Vector2 EndPoint = Vector2.zero;

	// Token: 0x0400387F RID: 14463
	public Vector2 CenterPoint = Vector2.zero;

	// Token: 0x04003880 RID: 14464
	public float PointerTimer;

	// Token: 0x04003881 RID: 14465
	public float PointerTimer2;

	// Token: 0x04003882 RID: 14466
	public byte PointerState;

	// Token: 0x04003883 RID: 14467
	public Color[] PointerColor = new Color[5];

	// Token: 0x04003884 RID: 14468
	public int PointerFlag;

	// Token: 0x04003885 RID: 14469
	private bool bShowFirstOpen;

	// Token: 0x04003886 RID: 14470
	private Vector2 TcenterID = Vector2.zero;

	// Token: 0x04003887 RID: 14471
	private byte[] mSpeedIdx = new byte[]
	{
		2,
		1,
		0,
		3
	};

	// Token: 0x04003888 RID: 14472
	private long mTime;

	// Token: 0x04003889 RID: 14473
	private GameObject mInGO;

	// Token: 0x0400388A RID: 14474
	private SoldierData tmpSD;

	// Token: 0x0400388B RID: 14475
	private FootBallSkillData tmpSkill;

	// Token: 0x0400388C RID: 14476
	private FootBallCombo tmpCombo;

	// Token: 0x0400388D RID: 14477
	private float Distance_Total;

	// Token: 0x0400388E RID: 14478
	private float tmpTime;

	// Token: 0x0400388F RID: 14479
	private uint Time_Total;

	// Token: 0x04003890 RID: 14480
	private uint EGAKind;

	// Token: 0x04003891 RID: 14481
	private uint EGASpeed;

	// Token: 0x04003892 RID: 14482
	private uint EGASpeed2;

	// Token: 0x04003893 RID: 14483
	private uint EGASpeed3;

	// Token: 0x04003894 RID: 14484
	private uint EGASpeed4;

	// Token: 0x04003895 RID: 14485
	private uint EGASpeed5;

	// Token: 0x04003896 RID: 14486
	private uint mFootBallID;

	// Token: 0x04003897 RID: 14487
	private Vector3 mCanUse = new Vector3(1f, 1f, 1f);

	// Token: 0x04003898 RID: 14488
	private Vector3 mNoUse = new Vector3(0.8f, 0.8f, 0.8f);

	// Token: 0x04003899 RID: 14489
	private Color mEnQty = new Color(0.855f, 0.816f, 0.682f);

	// Token: 0x0400389A RID: 14490
	private Color mNoEnQty = new Color(1f, 0.224f, 0.224f);

	// Token: 0x0400389B RID: 14491
	private bool[] IsOnLock = new bool[4];

	// Token: 0x0400389C RID: 14492
	private bool[] IsNeedQty = new bool[4];

	// Token: 0x0400389D RID: 14493
	private bool[] IsCDTime = new bool[4];

	// Token: 0x0400389E RID: 14494
	private CHAOS chaos;

	// Token: 0x0400389F RID: 14495
	private ushort mSkillID;

	// Token: 0x040038A0 RID: 14496
	private bool bOpenEnd;

	// Token: 0x040038A1 RID: 14497
	private ushort[] mYolkID = new ushort[2];

	// Token: 0x040038A2 RID: 14498
	private ushort KID;

	// Token: 0x040038A3 RID: 14499
	private bool bSetMapSelect;
}
