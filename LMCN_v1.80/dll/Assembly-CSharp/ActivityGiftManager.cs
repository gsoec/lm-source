using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020002B3 RID: 691
public class ActivityGiftManager
{
	// Token: 0x06000DD0 RID: 3536 RVA: 0x001623D8 File Offset: 0x001605D8
	private ActivityGiftManager()
	{
	}

	// Token: 0x17000078 RID: 120
	// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x001623F4 File Offset: 0x001605F4
	public static ActivityGiftManager Instance
	{
		get
		{
			if (ActivityGiftManager.instance == null)
			{
				ActivityGiftManager.instance = new ActivityGiftManager();
			}
			return ActivityGiftManager.instance;
		}
	}

	// Token: 0x17000079 RID: 121
	// (get) Token: 0x06000DD2 RID: 3538 RVA: 0x00162410 File Offset: 0x00160610
	// (set) Token: 0x06000DD3 RID: 3539 RVA: 0x00162418 File Offset: 0x00160618
	public byte EnableRedPocketNum
	{
		get
		{
			return this.m_EnableRedPocketNum;
		}
		set
		{
			if (!this.bShowActivityGift && this.m_EnableRedPocketNum >= 0 && value > this.m_EnableRedPocketNum && this.mActGiftEffectParticle == null)
			{
				this.bShowActivityGift = true;
				this.CheckShowActivityGiftEffect();
			}
			else if (this.bShowActivityGift && value == 0)
			{
				this.bShowActivityGift = false;
			}
			this.m_EnableRedPocketNum = value;
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 17, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 6, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Info, 9, 0);
		}
	}

	// Token: 0x06000DD4 RID: 3540 RVA: 0x001624B8 File Offset: 0x001606B8
	~ActivityGiftManager()
	{
	}

	// Token: 0x06000DD5 RID: 3541 RVA: 0x001624F0 File Offset: 0x001606F0
	public void Update()
	{
		if (this.bReSetMainGift && this.mMainGift_CDTime != ActivityManager.Instance.ServerEventTime)
		{
			this.mMainGift_CDTime = ActivityManager.Instance.ServerEventTime;
			if (ActivityGiftManager.Instance.mLeaderRedPocketResetTime <= ActivityManager.Instance.ServerEventTime)
			{
				this.bReSetMainGift = false;
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 4, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Info, 11, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 17, 0);
			}
		}
		if (this.mActGiftEffectParticle != null)
		{
			this.mEffectTime -= Time.smoothDeltaTime;
			if (this.mEffectTime <= 0f)
			{
				this.DespawnActivityGiftEffect(true);
			}
		}
	}

	// Token: 0x06000DD6 RID: 3542 RVA: 0x001625B8 File Offset: 0x001607B8
	public static int GiftCompare(AllianceActivityGiftDataType x, AllianceActivityGiftDataType y)
	{
		bool flag;
		if (x.Status == 0)
		{
			if (y.Status != 0)
			{
				return -1;
			}
			flag = true;
		}
		else
		{
			if (y.Status == 0)
			{
				return 1;
			}
			flag = true;
		}
		if (!flag)
		{
			return -1;
		}
		if (x.RcvTime < y.RcvTime)
		{
			return -1;
		}
		if (x.RcvTime > y.RcvTime)
		{
			return 1;
		}
		if (x.serverIndex > y.serverIndex)
		{
			return -1;
		}
		return 1;
	}

	// Token: 0x06000DD7 RID: 3543 RVA: 0x0016263C File Offset: 0x0016083C
	public void sortData()
	{
		this.mListActGift.Sort(new Comparison<AllianceActivityGiftDataType>(ActivityGiftManager.GiftCompare));
		int num = 0;
		for (int i = 0; i < this.mListActGift.Count; i++)
		{
			if (this.mListActGift[i].Status == 0)
			{
				num++;
			}
		}
	}

	// Token: 0x06000DD8 RID: 3544 RVA: 0x00162698 File Offset: 0x00160898
	public void cleanListData()
	{
		for (int i = 0; i < this.mListActGift.Count; i++)
		{
			if (this.mListActGift[i].Name != null)
			{
				StringManager.Instance.DeSpawnString(this.mListActGift[i].Name);
			}
		}
		this.mListActGift.Clear();
		this.EnableRedPocketNum = 0;
	}

	// Token: 0x06000DD9 RID: 3545 RVA: 0x00162708 File Offset: 0x00160908
	public void cleanQuitAlliance()
	{
		this.cleanListData();
		this.mLeaderRedPocketResetTime = 0L;
		this.ActivityGiftBeginTime = 0L;
		this.ActivityGiftEndTime = 0L;
		this.bReSetMainGift = false;
	}

	// Token: 0x06000DDA RID: 3546 RVA: 0x00162730 File Offset: 0x00160930
	public void Recv_MSG_RESP_REDPOCKET_LIST(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		int num = (int)MP.ReadByte(-1);
		if (b == 255)
		{
			this.cleanListData();
			for (int i = 0; i < num; i++)
			{
				AllianceActivityGiftDataType allianceActivityGiftDataType = new AllianceActivityGiftDataType();
				allianceActivityGiftDataType.serverIndex = MP.ReadByte(-1);
				byte b2 = MP.ReadByte(-1);
				uint num2 = MP.ReadUInt(-1);
				bool flag = false;
				for (int j = 0; j < DataManager.Instance.FastivalSpecialDataTable.TableCount; j++)
				{
					flag = false;
					FastivalSpecialData recordByIndex = DataManager.Instance.FastivalSpecialDataTable.GetRecordByIndex(j);
					if (b2 == recordByIndex.GroupID)
					{
						if (num2 == recordByIndex.StoreID)
						{
							flag = true;
							allianceActivityGiftDataType.SN = recordByIndex.ID;
							allianceActivityGiftDataType.isLeader = (recordByIndex.StoreID == 0u);
							allianceActivityGiftDataType.CDtime = false;
							break;
						}
					}
				}
				allianceActivityGiftDataType.Name = StringManager.Instance.SpawnString(30);
				MP.ReadStringPlus(13, allianceActivityGiftDataType.Name, -1);
				allianceActivityGiftDataType.Rank = MP.ReadByte(-1);
				allianceActivityGiftDataType.RcvTime = MP.ReadLong(-1);
				allianceActivityGiftDataType.Num = MP.ReadByte(-1);
				allianceActivityGiftDataType.Status = MP.ReadByte(-1);
				if (flag)
				{
					this.mListActGift.Add(allianceActivityGiftDataType);
				}
			}
			this.sortData();
		}
		else if (GameConstants.IsBetween((int)b, 0, 9))
		{
			AllianceActivityGiftDataType allianceActivityGiftDataType2 = null;
			bool flag2 = false;
			for (int k = 0; k < this.mListActGift.Count; k++)
			{
				if (this.mListActGift[k].serverIndex == b)
				{
					allianceActivityGiftDataType2 = this.mListActGift[k];
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				allianceActivityGiftDataType2 = new AllianceActivityGiftDataType();
				allianceActivityGiftDataType2.Name = StringManager.Instance.SpawnString(30);
			}
			else
			{
				allianceActivityGiftDataType2.Name.ClearString();
			}
			allianceActivityGiftDataType2.serverIndex = MP.ReadByte(-1);
			byte b3 = MP.ReadByte(-1);
			uint num3 = MP.ReadUInt(-1);
			bool flag3 = false;
			for (int l = 0; l < DataManager.Instance.FastivalSpecialDataTable.TableCount; l++)
			{
				flag3 = false;
				FastivalSpecialData recordByIndex2 = DataManager.Instance.FastivalSpecialDataTable.GetRecordByIndex(l);
				if (b3 == recordByIndex2.GroupID)
				{
					if (num3 == recordByIndex2.StoreID)
					{
						flag3 = true;
						allianceActivityGiftDataType2.SN = recordByIndex2.ID;
						allianceActivityGiftDataType2.isLeader = (recordByIndex2.StoreID == 0u);
						allianceActivityGiftDataType2.CDtime = false;
						break;
					}
				}
			}
			if (!flag3)
			{
				return;
			}
			MP.ReadStringPlus(13, allianceActivityGiftDataType2.Name, -1);
			allianceActivityGiftDataType2.Rank = MP.ReadByte(-1);
			allianceActivityGiftDataType2.RcvTime = MP.ReadLong(-1);
			allianceActivityGiftDataType2.Num = MP.ReadByte(-1);
			allianceActivityGiftDataType2.Status = MP.ReadByte(-1);
			if (!flag2)
			{
				this.mListActGift.Add(allianceActivityGiftDataType2);
			}
		}
		this.RecountGift();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 1, 0);
	}

	// Token: 0x06000DDB RID: 3547 RVA: 0x00162A68 File Offset: 0x00160C68
	public void Recv_MSG_RESP_REDPOCKET_LEADEREND(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.ActGift);
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			DataManager dataManager = DataManager.Instance;
			int tableCount = dataManager.FastivalSpecialDataTable.TableCount;
			for (int i = 0; i < tableCount; i++)
			{
				FastivalSpecialData recordByIndex = dataManager.FastivalSpecialDataTable.GetRecordByIndex(i);
				if (recordByIndex.StoreID == 0u && recordByIndex.GroupID == this.GroupID)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.StringToFormat(dataManager.mStringTable.GetStringByID((uint)recordByIndex.ItemName));
					cstring.AppendFormat(dataManager.mStringTable.GetStringByID(11205u));
					GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
					break;
				}
			}
		}
		else if (b == 5)
		{
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11215u));
			GUIManager.Instance.AddHUDMessage(cstring2.ToString(), 255, true);
		}
	}

	// Token: 0x06000DDC RID: 3548 RVA: 0x00162B84 File Offset: 0x00160D84
	public void Recv_MSG_RESP_REDPOCKET_GET(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		uint num = MP.ReadUInt(-1);
		byte b2 = MP.ReadByte(-1);
		if (b2 == 0)
		{
			DataManager dataManager = DataManager.Instance;
			GUIManager guimanager = GUIManager.Instance;
			uint num2 = MP.ReadUInt(-1);
			uint num3 = MP.ReadUInt(-1);
			ushort num4 = MP.ReadUShort(-1);
			ushort num5 = MP.ReadUShort(-1);
			byte b3 = MP.ReadByte(-1);
			ushort num6 = num5;
			if (num2 > 0u)
			{
				GUIManager.Instance.SetRoleAttrDiamond(num2 + dataManager.RoleAttr.Diamond, 0, eSpentCredits.eMax);
				GameManager.OnRefresh(NetworkNews.Refresh, null);
			}
			else if (num3 > 0u)
			{
				DataManager dataManager2 = dataManager;
				dataManager2.RoleAlliance.Money = dataManager2.RoleAlliance.Money + num3;
				GameManager.OnRefresh(NetworkNews.Refresh_Alliance, null);
			}
			else
			{
				num5 += dataManager.GetCurItemQuantity(num4, b3);
				dataManager.SetCurItemQuantity(num4, num5, b3, 0L);
				GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
			}
			for (int i = 0; i < this.mListActGift.Count; i++)
			{
				if (this.mListActGift[i].serverIndex == b)
				{
					this.mListActGift[i].Status = 1;
					break;
				}
			}
			this.RecountGift();
			Equip recordByKey = dataManager.EquipTable.GetRecordByKey(num4);
			bool flag = guimanager.IsLeadItem(recordByKey.EquipKind);
			GUIManager.Instance.m_SpeciallyEffect.mDiamondValue = 0u;
			if (recordByKey.EquipKind != 11)
			{
				if (flag)
				{
					guimanager.SE_Item_L_Color[0] = b3;
					guimanager.m_SpeciallyEffect.AddIconShow(false, guimanager.mStartV2, SpeciallyEffect_Kind.Item_Material, 0, recordByKey.EquipKey, true, 2f);
				}
				else
				{
					guimanager.m_SpeciallyEffect.AddIconShow(false, guimanager.mStartV2, SpeciallyEffect_Kind.Item, 0, recordByKey.EquipKey, true, 2f);
				}
			}
			else if (recordByKey.PropertiesInfo[0].Propertieskey < 6)
			{
				guimanager.m_SpeciallyEffect.AddIconShow(false, guimanager.mStartV2, SpeciallyEffect_Kind.Item, 0, recordByKey.EquipKey, true, 2f);
			}
			else if (recordByKey.PropertiesInfo[0].Propertieskey == 6)
			{
				guimanager.m_SpeciallyEffect.mDiamondValue = (uint)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue);
				guimanager.m_SpeciallyEffect.AddIconShow(false, guimanager.mStartV2, SpeciallyEffect_Kind.Diamond, 0, 0, true, 2f);
			}
			else
			{
				guimanager.m_SpeciallyEffect.AddIconShow(false, guimanager.mStartV2, SpeciallyEffect_Kind.AllianceMoney, 0, 0, true, 2f);
			}
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.Append(DataManager.Instance.mStringTable.GetStringByID(840u));
			if (num6 > 1)
			{
				cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.EquipName));
				cstring.IntToFormat((long)num6, 1, true);
				cstring.AppendFormat("{0} x {1}");
			}
			else
			{
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.EquipName));
			}
			guimanager.AddHUDMessage(cstring.ToString(), 255, true);
			AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 1, 0);
		}
		else if (b2 == 1)
		{
			DataManager dataManager3 = DataManager.Instance;
			FastivalSpecialData fastivalSpecialData = default(FastivalSpecialData);
			bool flag2 = false;
			for (int j = 0; j < dataManager3.FastivalSpecialDataTable.TableCount; j++)
			{
				fastivalSpecialData = dataManager3.FastivalSpecialDataTable.GetRecordByIndex(j);
				if (fastivalSpecialData.GroupID == this.GroupID)
				{
					if (fastivalSpecialData.StoreID == 0u)
					{
						flag2 = true;
						break;
					}
				}
			}
			if (!flag2)
			{
				return;
			}
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.StringToFormat(dataManager3.mStringTable.GetStringByID((uint)fastivalSpecialData.ItemName));
			cstring2.AppendFormat(dataManager3.mStringTable.GetStringByID(11206u));
			GUIManager.Instance.AddHUDMessage(cstring2.ToString(), 255, true);
		}
		else if (b2 == 4)
		{
			CString cstring3 = StringManager.Instance.StaticString1024();
			cstring3.Append(DataManager.Instance.mStringTable.GetStringByID(11227u));
			GUIManager.Instance.AddHUDMessage(cstring3.ToString(), 255, true);
		}
		else if (b2 == 6)
		{
			CString cstring4 = StringManager.Instance.StaticString1024();
			cstring4.Append(DataManager.Instance.mStringTable.GetStringByID(11226u));
			GUIManager.Instance.AddHUDMessage(cstring4.ToString(), 255, true);
		}
	}

	// Token: 0x06000DDD RID: 3549 RVA: 0x00163060 File Offset: 0x00161260
	public void Recv_MSG_RESP_REDPOCKET_BUY(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11207u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
		}
		else if (b == 1)
		{
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11208u));
			GUIManager.Instance.AddHUDMessage(cstring2.ToString(), 255, true);
		}
		AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
		AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
		GUIManager.Instance.HideUILock(EUILock.Mall);
	}

	// Token: 0x06000DDE RID: 3550 RVA: 0x0016312C File Offset: 0x0016132C
	public void RecvUpdate_EventInfo(MessagePacket MP)
	{
		this.ActivityGiftBeginTime = MP.ReadLong(-1);
		this.ActivityGiftEndTime = MP.ReadLong(-1);
		this.GroupID = MP.ReadByte(-1);
		for (int i = 0; i < DataManager.Instance.FastivalSpecialDataTable.TableCount; i++)
		{
			FastivalSpecialData recordByKey = DataManager.Instance.FastivalSpecialDataTable.GetRecordByKey((ushort)(i + 1));
			if (this.GroupID == recordByKey.GroupID)
			{
				this.ParticleID = recordByKey.UB1;
				break;
			}
		}
		this.mLeaderRedPocketResetTime = MP.ReadLong(-1);
		ActivityGiftManager.Instance.bReSetMainGift = (ActivityGiftManager.Instance.mLeaderRedPocketResetTime > ActivityManager.Instance.ServerEventTime);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 17, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Info, 11, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 4, 0);
	}

	// Token: 0x06000DDF RID: 3551 RVA: 0x00163214 File Offset: 0x00161414
	public void SendRequestBoardData()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_REDPOCKET_LIST;
		messagePacket.Add(byte.MaxValue);
		messagePacket.Add(0);
		messagePacket.Send(false);
	}

	// Token: 0x06000DE0 RID: 3552 RVA: 0x00163258 File Offset: 0x00161458
	public void SendDataRequest(byte serverIndex)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_REDPOCKET_LIST;
		messagePacket.Add(serverIndex);
		messagePacket.Add(0);
		messagePacket.Send(false);
	}

	// Token: 0x06000DE1 RID: 3553 RVA: 0x00163298 File Offset: 0x00161498
	public void SendDataReset(byte serverIndex)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_REDPOCKET_LIST;
		messagePacket.Add(serverIndex);
		messagePacket.Add(1);
		messagePacket.Send(false);
	}

	// Token: 0x06000DE2 RID: 3554 RVA: 0x001632D8 File Offset: 0x001614D8
	public void AllianceLeaderSendGift()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_REDPOCKET_LEADERSEND;
		messagePacket.Send(false);
	}

	// Token: 0x06000DE3 RID: 3555 RVA: 0x0016330C File Offset: 0x0016150C
	public void GetGift(byte serverIndex, uint StoreID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_REDPOCKET_GET;
		messagePacket.Add(serverIndex);
		messagePacket.Add(StoreID);
		messagePacket.Send(false);
	}

	// Token: 0x06000DE4 RID: 3556 RVA: 0x0016334C File Offset: 0x0016154C
	public void updateGiftCount(byte serverIndex, byte giftCount)
	{
		for (int i = 0; i < this.mListActGift.Count; i++)
		{
			if (this.mListActGift[i].serverIndex == serverIndex)
			{
				this.mListActGift[i].Num = giftCount;
				if (giftCount == 0)
				{
					if (this.mListActGift[i].Name != null)
					{
						StringManager.Instance.DeSpawnString(this.mListActGift[i].Name);
					}
					this.mListActGift.Remove(this.mListActGift[i]);
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 1, 0);
				}
				else
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 2, (int)serverIndex);
				}
				this.RecountGift();
				return;
			}
		}
		if (giftCount == 0)
		{
			this.RecountGift();
		}
	}

	// Token: 0x06000DE5 RID: 3557 RVA: 0x00163428 File Offset: 0x00161628
	public bool GetIconState()
	{
		bool result = true;
		if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
		{
			result = false;
		}
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (!(door != null) || door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
		{
			result = false;
		}
		if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
		{
			result = false;
		}
		if (!MallManager.Instance.bCanOpenMain)
		{
			result = false;
		}
		if (!(GameManager.ActiveGameplay is Origin))
		{
			result = false;
		}
		if (Indemnify.UIStatus == INDEMNIFY_STATE.ShowingTalk)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000DE6 RID: 3558 RVA: 0x001634DC File Offset: 0x001616DC
	public void CheckShowActivityGiftEffect()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (this.bShowActivityGift && !NewbieManager.IsWorking() && this.GetIconState() && door != null && this.mActGiftEffectParticle == null)
		{
			if (this.mActGiftcontroller != null)
			{
				this.mActGiftcontroller.Stop();
			}
			if (this.ParticleID != 0u)
			{
				this.mActGiftEffectParticle = ParticleManager.Instance.Spawn((ushort)this.ParticleID, door.m_RolePanel, Vector3.zero, 1f, true, true, true);
			}
			this.mEffectTime = 7f;
			this.bShowActivityGift = false;
			AudioManager.Instance.PlayUISFX(ref this.mActGiftcontroller, UIKind.ActGift);
		}
	}

	// Token: 0x06000DE7 RID: 3559 RVA: 0x001635AC File Offset: 0x001617AC
	public void DespawnActivityGiftEffect(bool bstop = true)
	{
		if (this.mActGiftEffectParticle != null)
		{
			if (this.mActGiftcontroller != null && bstop)
			{
				this.mActGiftcontroller.Stop();
			}
			ParticleManager.Instance.DeSpawn(this.mActGiftEffectParticle);
			this.mActGiftEffectParticle = null;
			this.mEffectTime = 0f;
		}
	}

	// Token: 0x06000DE8 RID: 3560 RVA: 0x0016360C File Offset: 0x0016180C
	public void RecountGift()
	{
		int num = 0;
		for (int i = 0; i < this.mListActGift.Count; i++)
		{
			if (this.mListActGift[i].Status == 0 && this.mListActGift[i].Num > 0)
			{
				num++;
			}
		}
		if (num != (int)this.m_EnableRedPocketNum)
		{
			this.EnableRedPocketNum = (byte)num;
		}
	}

	// Token: 0x04002D0B RID: 11531
	private static ActivityGiftManager instance;

	// Token: 0x04002D0C RID: 11532
	private byte m_EnableRedPocketNum;

	// Token: 0x04002D0D RID: 11533
	public List<AllianceActivityGiftDataType> mListActGift = new List<AllianceActivityGiftDataType>();

	// Token: 0x04002D0E RID: 11534
	public ushort mShowActGiftUnOpenIdx;

	// Token: 0x04002D0F RID: 11535
	public long mLeaderRedPocketResetTime;

	// Token: 0x04002D10 RID: 11536
	public long ActivityGiftBeginTime;

	// Token: 0x04002D11 RID: 11537
	public long ActivityGiftEndTime;

	// Token: 0x04002D12 RID: 11538
	public byte GroupID;

	// Token: 0x04002D13 RID: 11539
	public byte mActivityGiftPage;

	// Token: 0x04002D14 RID: 11540
	public bool bShowActivityGift;

	// Token: 0x04002D15 RID: 11541
	public long mMainGift_CDTime;

	// Token: 0x04002D16 RID: 11542
	public bool bReSetMainGift = true;

	// Token: 0x04002D17 RID: 11543
	public uint ParticleID;

	// Token: 0x04002D18 RID: 11544
	public GameObject mActGiftEffectParticle;

	// Token: 0x04002D19 RID: 11545
	private float mEffectTime;

	// Token: 0x04002D1A RID: 11546
	private AudioSourceController mActGiftcontroller;
}
