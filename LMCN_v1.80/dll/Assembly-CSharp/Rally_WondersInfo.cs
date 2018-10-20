using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000309 RID: 777
public class Rally_WondersInfo : Rally
{
	// Token: 0x06000FCD RID: 4045 RVA: 0x001BAF74 File Offset: 0x001B9174
	public Rally_WondersInfo(Transform transform, int DataIndex) : base(transform, DataIndex)
	{
	}

	// Token: 0x06000FCE RID: 4046 RVA: 0x001BAF80 File Offset: 0x001B9180
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		base.OnOpen(arg1, arg2);
		this.TitleText.color = Color.white;
		this.TitleText.text = instance.mStringTable.GetStringByID(8556u);
		this.TopText.text = instance.mStringTable.GetStringByID(8561u);
		this.TopBar.gameObject.SetActive(false);
		this.LeftBar.gameObject.SetActive(false);
		this.TopTargetIcon.SetActive(false);
		this.LeftTargetIcon.SetActive(false);
		this.RightFlagDefense.enabled = false;
		this.TopLayerBlue.SetActive(true);
		this.RallyTitleStr = instance.mStringTable.GetStringByID(4891u);
		this.LeftCancelTextStr = StringManager.Instance.SpawnString(30);
		this.InfoBtn.gameObject.SetActive(true);
		if (GUIManager.Instance.IsArabic)
		{
			this.InfoBtn.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
	}

	// Token: 0x06000FCF RID: 4047 RVA: 0x001BB0A0 File Offset: 0x001B92A0
	private void OnOurWondersOpen()
	{
		this.LeftCancelImg.sprite = this.SPriteArray.GetSprite(5);
	}

	// Token: 0x06000FD0 RID: 4048 RVA: 0x001BB0BC File Offset: 0x001B92BC
	private void OnOtherWondersOpen()
	{
		DataManager instance = DataManager.Instance;
		this.FilterBtn.gameObject.SetActive(false);
		this.LeftJoinText.text = instance.mStringTable.GetStringByID(4882u);
		this.LeftCancelImg.sprite = this.SPriteArray.GetSprite(5);
		if (!this.HideChangeDefence)
		{
			RectTransform rectTransform = this.LeftJoinImg.rectTransform;
			rectTransform.anchoredPosition = new Vector2(131.5f, -366.76f);
			rectTransform.sizeDelta = new Vector2(206f, 82f);
			rectTransform = this.LeftCancelImg.rectTransform;
			rectTransform.anchoredPosition = new Vector2(131.5f, -289.3f);
			rectTransform.sizeDelta = new Vector2(206f, 82f);
			this.LeftCancelText.text = instance.mStringTable.GetStringByID(9907u);
		}
	}

	// Token: 0x06000FD1 RID: 4049 RVA: 0x001BB1A4 File Offset: 0x001B93A4
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (!bOK)
		{
			return;
		}
		if (arg1 != 7 && arg1 != 8)
		{
			if (arg1 == 13)
			{
				this.KickMember((ushort)(arg2 >> 16), (byte)(arg2 & 65535));
			}
		}
		else
		{
			GUIManager.Instance.ShowUILock(EUILock.Expedition);
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_TROOPRETURN;
			messagePacket.AddSeqId();
			messagePacket.Add((byte)arg2);
			messagePacket.Send(false);
		}
	}

	// Token: 0x06000FD2 RID: 4050 RVA: 0x001BB22C File Offset: 0x001B942C
	public override void KickMember(ushort Index, byte WonderID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_KICK_WONDERMEMBER;
		messagePacket.Add(WonderID);
		messagePacket.Add(Index);
		messagePacket.Send(false);
	}

	// Token: 0x06000FD3 RID: 4051 RVA: 0x001BB26C File Offset: 0x001B946C
	public override void UpdateUI(int arg1, int arg2)
	{
		base.UpdateUI(arg1, arg2);
		if (arg1 == 1)
		{
			base.CloseMenuCheck();
			return;
		}
		this.UpdateRallyData();
	}

	// Token: 0x06000FD4 RID: 4052 RVA: 0x001BB28C File Offset: 0x001B948C
	public override void UpdateRallyData()
	{
		DataManager instance = DataManager.Instance;
		WarlobbyData warlobbyDetail = instance.WarlobbyDetail;
		if (warlobbyDetail == null || warlobbyDetail.WonderID == 255)
		{
			return;
		}
		warlobbyDetail.AttackOrDefense = 2;
		if (DataManager.MapDataController.OtherKingdomData.kingdomID == ActivityManager.Instance.KOWKingdomID)
		{
			this.HideChangeDefence = true;
		}
		if (warlobbyDetail.AllyNameID == instance.RoleAttr.Name.GetHashCode(false))
		{
			this.OnOurWondersOpen();
		}
		else
		{
			this.OnOtherWondersOpen();
		}
		if (!this.FilterBtn.gameObject.activeSelf)
		{
			GUIManager.Instance.ChangeHeroItemImg(this.TopHero, eHeroOrItem.Hero, warlobbyDetail.AllyHead, 11, 0, 0);
			if (warlobbyDetail.AllyHead > 0)
			{
				this.TopHero.gameObject.SetActive(true);
			}
			base.SetText(Rally.TextType.TopName, 0, warlobbyDetail.AllyName, 0, instance.RoleAlliance.Tag, warlobbyDetail.AllyHomeKingdom);
		}
		if (warlobbyDetail.WonderID > 0 && DataManager.MapDataController.OtherKingdomData.kingdomID != ActivityManager.Instance.KOWKingdomID)
		{
			this.WonderStr = instance.mStringTable.GetStringByID(9309u);
		}
		else
		{
			this.WonderStr = instance.mStringTable.GetStringByID(9308u);
		}
		this.LeftTextStr.ClearString();
		this.LeftTextStr.StringToFormat(this.WonderStr);
		this.LeftTextStr.AppendFormat(instance.mStringTable.GetStringByID(8558u));
		this.LeftText.text = this.LeftTextStr.ToString();
		this.LeftText.SetAllDirty();
		this.LeftText.cachedTextGenerator.Invalidate();
		if (DataManager.MapDataController.OtherKingdomData.kingdomID == ActivityManager.Instance.KOWKingdomID)
		{
			GUIManager.Instance.ChangeWonderImg(this.LeftHero, warlobbyDetail.WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID);
		}
		else
		{
			GUIManager.Instance.ChangeWonderImg(this.LeftHero, warlobbyDetail.WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID);
		}
		if (warlobbyDetail.WonderID != 255)
		{
			this.LeftHero.gameObject.SetActive(true);
		}
		warlobbyDetail.EnemyName.ClearString();
		warlobbyDetail.EnemyName.Append(DataManager.MapDataController.GetYolkName((ushort)warlobbyDetail.WonderID, 0));
		base.SetText(Rally.TextType.LeftName, 0, warlobbyDetail.EnemyName, 0, null, 0);
		this.TopHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(warlobbyDetail.AllyCapitalPoint.zoneID, warlobbyDetail.AllyCapitalPoint.pointID);
		this.TopHeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.WonderMapID = (int)DataManager.MapDataController.GetYolkMapID((ushort)warlobbyDetail.WonderID, 0);
		Vector2 yolkPointCode = DataManager.MapDataController.GetYolkPointCode((ushort)warlobbyDetail.WonderID, 0);
		warlobbyDetail.EnemyCapitalPoint.zoneID = (ushort)yolkPointCode.x;
		warlobbyDetail.EnemyCapitalPoint.pointID = (byte)yolkPointCode.y;
		this.LeftHeroBtn.m_BtnID1 = this.WonderMapID;
		this.LeftHeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.TopUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(warlobbyDetail.AllyCapitalPoint.zoneID, warlobbyDetail.AllyCapitalPoint.pointID);
		this.TopUnderLineBtn.m_BtnID3 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.LeftUnderLineBtn.m_BtnID2 = this.WonderMapID;
		this.LeftUnderLineBtn.m_BtnID3 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		Vector2 sizeDelta = this.TopUnderLine.sizeDelta;
		sizeDelta.x = Math.Min(this.TopNameText.preferredWidth, 362f);
		this.TopUnderLine.sizeDelta = sizeDelta;
		this.TopUnderLine.gameObject.SetActive(true);
		sizeDelta = this.LeftUnderLine.sizeDelta;
		if (this.LeftNameText.preferredWidth > 245f)
		{
			this.LeftNameText.fontSize = 19;
			this.LeftNameText.SetAllDirty();
			this.LeftNameText.cachedTextGeneratorForLayout.Invalidate();
		}
		sizeDelta.x = Math.Min(this.LeftNameText.preferredWidth, 245f);
		this.LeftUnderLine.sizeDelta = sizeDelta;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform rectTransform = this.TopUnderLine.transform as RectTransform;
			rectTransform.anchoredPosition = new Vector2(this.TopNameText.rectTransform.sizeDelta.x - this.TopNameText.preferredWidth, rectTransform.anchoredPosition.y);
		}
		this.LeftUnderLine.gameObject.SetActive(true);
		if (warlobbyDetail.AllyHomeKingdom == 0 || DataManager.MapDataController.kingdomData.kingdomID == warlobbyDetail.AllyHomeKingdom)
		{
			this.TopCountry.SetActive(false);
		}
		else
		{
			this.TopCountry.SetActive(true);
			base.SetText(Rally.TextType.TopCountry, (int)warlobbyDetail.AllyHomeKingdom, null, 0, null, 0);
		}
		int num = this.ItemsHeight.Count - instance.WarTroop.Count;
		if (num < 0)
		{
			short num2 = 0;
			while ((int)num2 > num)
			{
				this.ItemsHeight.Add(80f);
				this.ItemsExtend.Add(0);
				num2 -= 1;
			}
		}
		else if (num > 0)
		{
			if (WarlobbyTroop.DelIndex != 255 && (int)WarlobbyTroop.DelIndex < this.ItemsExtend.Count)
			{
				this.ItemsHeight.RemoveAt((int)WarlobbyTroop.DelIndex);
				this.ItemsExtend.RemoveAt((int)WarlobbyTroop.DelIndex);
				WarlobbyTroop.DelIndex = byte.MaxValue;
				num--;
			}
			byte b = 0;
			while ((int)b < num)
			{
				this.ItemsHeight.RemoveAt(0);
				this.ItemsExtend.RemoveAt(0);
				b += 1;
			}
		}
		if (warlobbyDetail.AllyNameID == 0 || instance.WarTroop.Count == 0)
		{
			this.LeftCancelImg.gameObject.SetActive(false);
			this.LeftJoinImg.gameObject.SetActive(false);
		}
		else
		{
			byte b2 = 0;
			this.CancelBtn.m_BtnID1 = 12;
			for (byte b3 = 0; b3 < instance.MaxMarchEventNum; b3 += 1)
			{
				if (instance.MarchEventData[(int)b3].Type == EMarchEventType.EMET_Camp && GameConstants.PointCodeToMapID(instance.MarchEventData[(int)b3].Point.zoneID, instance.MarchEventData[(int)b3].Point.pointID) == this.WonderMapID)
				{
					this.LeftCancelImg.gameObject.SetActive(true);
					this.FilterBtn.gameObject.SetActive(true);
					this.LeftJoinImg.gameObject.SetActive(false);
					this.LeftCancelImg.rectTransform.anchoredPosition = new Vector2(131.5f, -319.5f);
					this.LeftCancelText.text = instance.mStringTable.GetStringByID(8559u);
					this.CancelBtn.m_BtnID1 = 7;
					this.CancelBtn.m_BtnID2 = (int)b3;
					b2 = 1;
					break;
				}
				if (instance.MarchEventData[(int)b3].Type == EMarchEventType.EMET_InforceMarching && this.WonderMapID == GameConstants.PointCodeToMapID(instance.MarchEventData[(int)b3].Point.zoneID, instance.MarchEventData[(int)b3].Point.pointID))
				{
					this.LeftJoinText.text = instance.mStringTable.GetStringByID(8574u);
					this.LeftJoinText.color = Color.red;
					this.JoinBtn.enabled = false;
					b2 = 2;
					break;
				}
				if (instance.MarchEventData[(int)b3].Type == EMarchEventType.EMET_InforceStanby && this.WonderMapID == GameConstants.PointCodeToMapID(instance.MarchEventData[(int)b3].Point.zoneID, instance.MarchEventData[(int)b3].Point.pointID))
				{
					this.LeftJoinText.text = instance.mStringTable.GetStringByID(8562u);
					this.LeftJoinText.color = Color.white;
					this.JoinBtn.enabled = true;
					this.JoinBtn.m_BtnID1 = 8;
					this.JoinBtn.m_BtnID2 = (int)b3;
					b2 = 3;
					break;
				}
			}
			if (b2 == 2 || b2 == 3)
			{
				this.LeftCancelImg.gameObject.SetActive(!this.HideChangeDefence);
				this.FilterBtn.gameObject.SetActive(false);
				this.LeftJoinImg.gameObject.SetActive(true);
			}
			else if (b2 == 0)
			{
				this.LeftCancelImg.gameObject.SetActive(!this.HideChangeDefence);
				this.LeftJoinText.text = instance.mStringTable.GetStringByID(4887u);
				this.LeftJoinText.color = Color.white;
				this.JoinBtn.enabled = true;
				this.JoinBtn.m_BtnID1 = 2;
				this.LeftJoinImg.gameObject.SetActive(true);
			}
		}
		this.MemberCombat.gameobject.SetActive(true);
		this.MemberCombat.SetCombatVal(base.GetCombatPower(true));
		this.MemberCombat.UpdateHint();
		this.StaticRect.anchoredPosition = new Vector2(-192.2f, 149.7f);
		if (this.ItemsHeight.Count > 0)
		{
			this.RightMessage.gameObject.SetActive(false);
			this.RallyScroll.gameObject.SetActive(true);
			this.RallyScollRect.sizeDelta = new Vector2(this.RallyScollRect.sizeDelta.x, 306f);
			this.RallyScroll.AddNewDataHeight(this.ItemsHeight, 306f, true);
			this.RallyScroll.GoTo(this.LoadBeginIndex, this.LoadContY);
		}
		else
		{
			this.RightMessage.gameObject.SetActive(true);
			this.RallyScroll.gameObject.SetActive(false);
		}
		warlobbyDetail.AllyCurrTroop = 0u;
		for (int i = 0; i < instance.WarTroop.Count; i++)
		{
			warlobbyDetail.AllyCurrTroop += instance.WarTroop[i].TotalTroopNum;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(instance.mStringTable.GetStringByID(8560u));
		cstring.AppendFormat("{0} : ");
		base.SetText(Rally.TextType.RightTitle, (int)warlobbyDetail.AllyCurrTroop, cstring, (int)warlobbyDetail.AllyMAXTroop, null, 0);
		this.ArmyStatisticHint.Show(null);
	}

	// Token: 0x06000FD5 RID: 4053 RVA: 0x001BBD80 File Offset: 0x001B9F80
	public override void OnButtonClick(UIButton sender)
	{
		if (this.DelayInit > 0)
		{
			this.Init();
			this.DelayInit = 0;
		}
		StringTable mStringTable = DataManager.Instance.mStringTable;
		GUIManager instance = GUIManager.Instance;
		WarlobbyData warlobbyDetail = DataManager.Instance.WarlobbyDetail;
		Rally.ClickType btnID = (Rally.ClickType)sender.m_BtnID1;
		switch (btnID)
		{
		case Rally.ClickType.CancelWonders:
			GUIManager.Instance.OpenOKCancelBox(instance.FindMenu(EGUIWindow.UI_Rally), mStringTable.GetStringByID(8571u), mStringTable.GetStringByID(8572u), 7, sender.m_BtnID2, mStringTable.GetStringByID(4846u), mStringTable.GetStringByID(4847u));
			break;
		case Rally.ClickType.CancelJoin:
			this.MessageStr.ClearString();
			this.MessageStr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)warlobbyDetail.WonderID, 0));
			this.MessageStr.AppendFormat(mStringTable.GetStringByID(8576u));
			GUIManager.Instance.OpenOKCancelBox(instance.FindMenu(EGUIWindow.UI_Rally), mStringTable.GetStringByID(4844u), this.MessageStr.ToString(), 8, sender.m_BtnID2, mStringTable.GetStringByID(4846u), mStringTable.GetStringByID(4847u));
			break;
		default:
			switch (btnID)
			{
			case Rally.ClickType.Filter:
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.OpenMenu(EGUIWindow.UI_BuffList, 1, 0, false);
				return;
			}
			case Rally.ClickType.Join:
			{
				List<WarlobbyTroop> warTroop = DataManager.Instance.WarTroop;
				string stringByID = mStringTable.GetStringByID(5748u);
				string stringByID2 = mStringTable.GetStringByID(5750u);
				byte b = 0;
				if (ActivityManager.Instance.IsInKvK(0, false) && DataManager.MapDataController.kingdomData.kingdomID != warlobbyDetail.AllyHomeKingdom)
				{
					instance.OpenMessageBox(stringByID, mStringTable.GetStringByID(4827u), stringByID2, null, 0, 0, false, false, false, false, false);
					return;
				}
				if (warTroop.Count == 1 && warlobbyDetail.AllyCurrTroop == warlobbyDetail.AllyMAXTroop)
				{
					b = 1;
					stringByID = mStringTable.GetStringByID(8563u);
					this.MessageStr.ClearString();
					this.MessageStr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)warlobbyDetail.WonderID, 0));
					this.MessageStr.AppendFormat(mStringTable.GetStringByID(8566u));
					stringByID2 = mStringTable.GetStringByID(8565u);
					instance.OpenMessageBox(stringByID, this.MessageStr.ToString(), stringByID2, null, 0, 0, false, false, false, false, false);
				}
				else if (warTroop.Count > 30)
				{
					b = 1;
					stringByID = mStringTable.GetStringByID(8563u);
					this.MessageStr.ClearString();
					this.MessageStr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)warlobbyDetail.WonderID, 0));
					this.MessageStr.AppendFormat(mStringTable.GetStringByID(8568u));
					instance.OpenMessageBox(stringByID, this.MessageStr.ToString(), stringByID2, null, 0, 0, false, false, false, false, false);
				}
				else if (warlobbyDetail.AllyCurrTroop >= warlobbyDetail.AllyMAXTroop)
				{
					b = 1;
					stringByID = mStringTable.GetStringByID(8563u);
					this.MessageStr.ClearString();
					this.MessageStr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)warlobbyDetail.WonderID, 0));
					this.MessageStr.AppendFormat(mStringTable.GetStringByID(8567u));
					instance.OpenMessageBox(stringByID, this.MessageStr.ToString(), stringByID2, null, 0, 0, false, false, false, false, false);
				}
				else if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyPointCode(warlobbyDetail.EnemyCapitalPoint.zoneID, warlobbyDetail.EnemyCapitalPoint.pointID)) == 0f)
				{
					b = 1;
					stringByID = mStringTable.GetStringByID(4030u);
					stringByID2 = mStringTable.GetStringByID(4031u);
					instance.OpenMessageBox(stringByID, mStringTable.GetStringByID(119u), stringByID2, null, 0, 0, false, false, false, false, false);
				}
				else
				{
					stringByID = mStringTable.GetStringByID(3967u);
					stringByID2 = mStringTable.GetStringByID(4034u);
					int num = 0;
					if (DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
					{
						num++;
					}
					uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
					for (int i = 0; i < 8; i++)
					{
						if (DataManager.Instance.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
						{
							num++;
							if ((long)num == (long)((ulong)effectBaseVal))
							{
								b = 1;
								instance.OpenMessageBox(stringByID, mStringTable.GetStringByID(3959u), stringByID2, null, 0, 0, false, false, false, false, false);
								break;
							}
						}
					}
				}
				if (b == 0)
				{
					Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					if (door2)
					{
						door2.OpenMenu(EGUIWindow.UI_Expedition, 4, 2, true);
					}
				}
				return;
			}
			}
			base.OnButtonClick(sender);
			break;
		case Rally.ClickType.Info:
			this.MessageStr.ClearString();
			this.MessageStr.Append('\n');
			this.MessageStr.Append(mStringTable.GetStringByID(9921u));
			GUIManager.Instance.OpenMessageBoxEX(mStringTable.GetStringByID(8556u), this.MessageStr.ToString(), null, null, 0, 0, false, false);
			break;
		case Rally.ClickType.ChangeLeader:
		{
			Door door3 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door3)
			{
				door3.OpenMenu(EGUIWindow.UI_Expedition, (int)warlobbyDetail.WonderID, 8, true);
			}
			break;
		}
		}
	}

	// Token: 0x06000FD6 RID: 4054 RVA: 0x001BC2F4 File Offset: 0x001BA4F4
	public override void OnClose()
	{
		base.OnClose();
		StringManager.Instance.DeSpawnString(this.LeftCancelTextStr);
	}

	// Token: 0x06000FD7 RID: 4055 RVA: 0x001BC310 File Offset: 0x001BA510
	public override void OnTimer(UITimeBar sender)
	{
	}

	// Token: 0x040033C5 RID: 13253
	private int WonderMapID;

	// Token: 0x040033C6 RID: 13254
	private string WonderStr;

	// Token: 0x040033C7 RID: 13255
	private CString LeftCancelTextStr;

	// Token: 0x040033C8 RID: 13256
	private bool HideChangeDefence;
}
