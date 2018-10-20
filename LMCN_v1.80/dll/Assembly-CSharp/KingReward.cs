using System;
using System.Collections.Generic;

// Token: 0x02000764 RID: 1892
public class KingReward
{
	// Token: 0x170000EF RID: 239
	// (get) Token: 0x060024B6 RID: 9398 RVA: 0x0042313C File Offset: 0x0042133C
	// (set) Token: 0x060024B7 RID: 9399 RVA: 0x00423144 File Offset: 0x00421344
	public byte WonderID
	{
		get
		{
			return this._WonderID;
		}
		set
		{
			this._WonderID = value;
			if ((int)this._WonderID >= this.KingGift.Length)
			{
				this._WonderID = 0;
			}
			this.CheckValid(this._WonderID);
		}
	}

	// Token: 0x060024B8 RID: 9400 RVA: 0x00423174 File Offset: 0x00421374
	private void CheckValid(byte wonderID)
	{
		if ((int)wonderID >= this.KingGift.Length)
		{
			wonderID = 0;
		}
		if (this.KingGift[(int)wonderID] == null)
		{
			this.KingGift[(int)wonderID] = new GiftData();
		}
	}

	// Token: 0x060024B9 RID: 9401 RVA: 0x004231A4 File Offset: 0x004213A4
	public KingGiftInfo GetKingGiftObj()
	{
		KingGiftInfo kingGiftInfo = null;
		if (this.GiftDataCountIdx == this.KingGiftListPool.Count)
		{
			int count = this.KingGiftListPool.Count;
			for (byte b = 0; b < 10; b += 1)
			{
				this.KingGiftListPool.Insert(count + (int)b, new KingGiftInfo(count + (int)b));
			}
		}
		int giftDataCountIdx = this.GiftDataCountIdx;
		for (int i = 0; i < this.KingGiftListPool.Count; i++)
		{
			int index = (i + giftDataCountIdx) % this.KingGiftListPool.Count;
			kingGiftInfo = this.KingGiftListPool[index];
			if (kingGiftInfo != null)
			{
				this.KingGiftListPool[index] = null;
				break;
			}
		}
		this.GiftDataCountIdx++;
		return kingGiftInfo;
	}

	// Token: 0x060024BA RID: 9402 RVA: 0x00423270 File Offset: 0x00421470
	public void ReleaseKingGiftObj(KingGiftInfo Data)
	{
		if (Data == null || this.GiftDataCountIdx == 0)
		{
			return;
		}
		this.GiftDataCountIdx--;
		this.KingGiftListPool[Data.DataIdx] = Data;
	}

	// Token: 0x060024BB RID: 9403 RVA: 0x004232B0 File Offset: 0x004214B0
	public List<KingGiftInfo> GetGiftList()
	{
		this.CheckValid(this.WonderID);
		List<KingGiftInfo> result;
		if (DataManager.MapDataController.FocusKingdomID == 0 || DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
		{
			result = this.KingGift[(int)this.WonderID].KingGiftList;
		}
		else
		{
			result = this.KingGift[(int)this.WonderID].GustKingGiftList;
		}
		return result;
	}

	// Token: 0x060024BC RID: 9404 RVA: 0x00423324 File Offset: 0x00421524
	public void SetGiftList(ushort ItemID, CString Name, long UserID)
	{
		List<KingGiftInfo> giftList = this.GetGiftList();
		for (int i = 0; i < giftList.Count; i++)
		{
			if (giftList[i].ItemID == ItemID)
			{
				KingGiftInfo.GiftList[] list = giftList[i].List;
				KingGiftInfo kingGiftInfo = giftList[i];
				byte listCount;
				kingGiftInfo.ListCount = (listCount = kingGiftInfo.ListCount) + 1;
				list[(int)listCount].Set(DataManager.Instance.RoleAlliance.Tag, Name, UserID);
				if (DataManager.MapDataController.FocusKingdomID == 0 || DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
				{
					this.KingGift[(int)this.WonderID].KingGiftNum = 0;
				}
				else
				{
					this.KingGift[(int)this.WonderID].GuetGiftnum = 0;
				}
				break;
			}
		}
	}

	// Token: 0x060024BD RID: 9405 RVA: 0x00423400 File Offset: 0x00421600
	public void Reset()
	{
		for (int i = 0; i < this.KingGift.Length; i++)
		{
			if (this.KingGift[i] != null)
			{
				this.KingGift[i].GustKingdomID = 0;
				this.KingGift[i].KingGiftNum = 0;
				this.KingGift[i].GuetGiftnum = 0;
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 9, 2);
	}

	// Token: 0x060024BE RID: 9406 RVA: 0x00423474 File Offset: 0x00421674
	public void sendKingGiftInfo(byte wonderID = 0)
	{
		this.WonderID = wonderID;
		ushort data;
		MessagePacket messagePacket;
		if (DataManager.MapDataController.FocusKingdomID == 0 || DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
		{
			data = this.KingGift[(int)this.WonderID].KingGiftNum;
			messagePacket = new MessagePacket(1024);
		}
		else
		{
			if (DataManager.MapDataController.FocusKingdomID != this.KingGift[(int)this.WonderID].GustKingdomID)
			{
				for (int i = 0; i < this.KingGift[(int)this.WonderID].GustKingGiftList.Count; i++)
				{
					this.ReleaseKingGiftObj(this.KingGift[(int)this.WonderID].GustKingGiftList[i]);
				}
				this.KingGift[(int)this.WonderID].GustKingGiftList.Clear();
				this.KingGift[(int)this.WonderID].GustKingdomID = DataManager.MapDataController.FocusKingdomID;
				this.KingGift[(int)this.WonderID].GuetGiftnum = 0;
			}
			data = this.KingGift[(int)this.WonderID].GuetGiftnum;
			messagePacket = MessagePacket.GetGuestMessagePack();
		}
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_KING_GIFT_INFO_PLUS;
		messagePacket.Add(data);
		messagePacket.Add(DataManager.Instance.RoleAttr.Name.ToString(), 13);
		messagePacket.Add(wonderID);
		messagePacket.Send(false);
	}

	// Token: 0x060024BF RID: 9407 RVA: 0x004235E4 File Offset: 0x004217E4
	public void RecvKingGiftInfo(MessagePacket MP)
	{
		ushort num = MP.ReadUShort(-1);
		this.CheckValid(this.WonderID);
		List<KingGiftInfo> list;
		if (DataManager.MapDataController.FocusKingdomID == 0 || DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
		{
			if (this.KingGift[(int)this.WonderID].StartPos == 0 && num == this.KingGift[(int)this.WonderID].KingGiftNum)
			{
				return;
			}
			this.KingGift[(int)this.WonderID].KingGiftNum = num;
			list = this.KingGift[(int)this.WonderID].KingGiftList;
		}
		else
		{
			if (this.KingGift[(int)this.WonderID].StartPos == 0 && num == this.KingGift[(int)this.WonderID].GuetGiftnum)
			{
				return;
			}
			this.KingGift[(int)this.WonderID].GuetGiftnum = num;
			list = this.KingGift[(int)this.WonderID].GustKingGiftList;
		}
		byte b = MP.ReadByte(-1);
		byte b2 = (byte)(b >> 6 & 1);
		byte b3 = b & 31;
		byte b4 = (byte)(b >> 5 & 1);
		if (this.KingGift[(int)this.WonderID].StartPos == 0 && b4 == 0)
		{
			for (int i = 0; i < list.Count; i++)
			{
				this.ReleaseKingGiftObj(list[i]);
			}
			list.Clear();
		}
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		for (byte b5 = 0; b5 < b3; b5 += 1)
		{
			KingGiftInfo kingGiftInfo = null;
			int num2 = -1;
			ushort num3 = MP.ReadUShort(-1);
			if (b4 == 0)
			{
				kingGiftInfo = this.GetKingGiftObj();
			}
			else
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].ItemID == num3)
					{
						num2 = j;
						kingGiftInfo = list[j];
						break;
					}
				}
			}
			if (kingGiftInfo == null)
			{
				kingGiftInfo = this.GetKingGiftObj();
			}
			kingGiftInfo.ItemID = num3;
			kingGiftInfo.GiftCount = MP.ReadByte(-1);
			byte b6;
			if (b4 == 0)
			{
				kingGiftInfo.ListCount = MP.ReadByte(-1);
				b6 = kingGiftInfo.ListCount;
			}
			else
			{
				b6 = MP.ReadByte(-1);
			}
			for (byte b7 = 0; b7 < b6; b7 += 1)
			{
				byte b8;
				if (b4 == 0)
				{
					b8 = b7;
				}
				else
				{
					b8 = kingGiftInfo.ListCount + b7;
				}
				MP.ReadStringPlus(3, cstring2, -1);
				MP.ReadStringPlus(13, cstring, -1);
				if (b2 == 0)
				{
					kingGiftInfo.List[(int)b8].Set(cstring2, cstring, 0L);
				}
				else
				{
					kingGiftInfo.List[(int)b8].Set(cstring2, cstring, MP.ReadLong(-1));
				}
			}
			if (b4 == 1)
			{
				KingGiftInfo kingGiftInfo2 = kingGiftInfo;
				kingGiftInfo2.ListCount += b6;
			}
			if (num2 == -1)
			{
				list.Add(kingGiftInfo);
			}
		}
		if ((b >> 7 & 1) > 0)
		{
			GiftData giftData = this.KingGift[(int)this.WonderID];
			giftData.StartPos += b3;
		}
		else
		{
			this.KingGift[(int)this.WonderID].StartPos = 0;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 9, 1);
		}
	}

	// Token: 0x060024C0 RID: 9408 RVA: 0x00423940 File Offset: 0x00421B40
	public void SendKingGift(long userid, ushort itemId, bool bIsKingOfWorld = false, bool bGuest = false)
	{
		GUIManager.Instance.ShowUILock(EUILock.KingGift);
		MessagePacket messagePacket;
		if (bGuest)
		{
			messagePacket = MessagePacket.GetGuestMessagePack();
		}
		else
		{
			messagePacket = new MessagePacket(1024);
		}
		if (bIsKingOfWorld)
		{
			messagePacket.Protocol = Protocol._MSG_REQUEST_EMPEROR_GIFT;
		}
		else
		{
			messagePacket.Protocol = Protocol._MSG_REQUEST_KING_GIFT;
		}
		messagePacket.AddSeqId();
		messagePacket.Add(userid);
		messagePacket.Add(itemId);
		messagePacket.Send(false);
	}

	// Token: 0x060024C1 RID: 9409 RVA: 0x004239B4 File Offset: 0x00421BB4
	public void SendNobilityGift(long userid, ushort itemId, bool bGuest = false)
	{
		GUIManager.Instance.ShowUILock(EUILock.KingGift);
		MessagePacket messagePacket;
		if (bGuest)
		{
			messagePacket = MessagePacket.GetGuestMessagePack();
		}
		else
		{
			messagePacket = new MessagePacket(1024);
		}
		messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_GIFT;
		messagePacket.AddSeqId();
		messagePacket.Add(this.WonderID);
		messagePacket.Add(userid);
		messagePacket.Add(itemId);
		messagePacket.Send(false);
	}

	// Token: 0x060024C2 RID: 9410 RVA: 0x00423A20 File Offset: 0x00421C20
	public void RecvKingGift(MessagePacket MP)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		GUIManager.Instance.HideUILock(EUILock.KingGift);
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			ushort itemID = MP.ReadUShort(-1);
			long userID = MP.ReadLong(-1);
			MP.ReadStringPlus(13, cstring, -1);
			this.SetGiftList(itemID, cstring, userID);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_List, 3, 0);
		}
		else
		{
			byte b2 = b;
			if (b2 != 1)
			{
				if (b2 == 6)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(744u), 255, true);
				}
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9718u), 255, true);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_List, 4, 0);
		}
	}

	// Token: 0x060024C3 RID: 9411 RVA: 0x00423B08 File Offset: 0x00421D08
	public void RecvKingGiftRecived(MessagePacket MP)
	{
		ushort itemID = MP.ReadUShort(-1);
		ushort quantity = MP.ReadUShort(-1);
		DataManager.Instance.SetCurItemQuantity(itemID, quantity, 0, 0L);
		this.SetGiftList(itemID, DataManager.Instance.RoleAttr.Name, 0L);
		GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 9, 1);
	}

	// Token: 0x04006F0E RID: 28430
	public const byte ListMaxSize = 30;

	// Token: 0x04006F0F RID: 28431
	private List<KingGiftInfo> KingGiftListPool = new List<KingGiftInfo>();

	// Token: 0x04006F10 RID: 28432
	private int GiftDataCountIdx;

	// Token: 0x04006F11 RID: 28433
	private GiftData[] KingGift = new GiftData[40];

	// Token: 0x04006F12 RID: 28434
	private byte _WonderID;
}
