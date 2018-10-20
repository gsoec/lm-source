using System;
using System.Text;
using UnityEngine;

// Token: 0x0200004B RID: 75
public class BookMark
{
	// Token: 0x060001F9 RID: 505 RVA: 0x0001B6A0 File Offset: 0x000198A0
	public BookMark()
	{
		this.AllAllianceData = new BookMarkData[20];
		this.AllianceIDIndex = new byte[20];
		for (byte b = 0; b < 20; b += 1)
		{
			this.AllAllianceData[(int)b] = new BookMarkData((ushort)this.NameSize);
		}
	}

	// Token: 0x060001FA RID: 506 RVA: 0x0001B72C File Offset: 0x0001992C
	public void Initial()
	{
		this.RecvDataCount = 0;
	}

	// Token: 0x060001FB RID: 507 RVA: 0x0001B738 File Offset: 0x00019938
	public byte GetNameSize()
	{
		return this.NameSize;
	}

	// Token: 0x060001FC RID: 508 RVA: 0x0001B740 File Offset: 0x00019940
	public int GetMapID(ushort ID, BookMark.eBookType bookType = BookMark.eBookType.Role)
	{
		if (ID == 0)
		{
			return 0;
		}
		BookMarkData[] array;
		if (bookType == BookMark.eBookType.Role)
		{
			array = this.AllData;
		}
		else
		{
			array = this.AllAllianceData;
		}
		if (array[(int)(ID -= 1)].MapID == 0)
		{
			array[(int)ID].MapID = GameConstants.PointCodeToMapID(array[(int)ID].KingdomPoint.zoneID, array[(int)ID].KingdomPoint.pointID);
		}
		return array[(int)ID].MapID;
	}

	// Token: 0x060001FD RID: 509 RVA: 0x0001B7C8 File Offset: 0x000199C8
	public ushort GetKingdomID(ushort ID, BookMark.eBookType bookType = BookMark.eBookType.Role)
	{
		if (ID == 0)
		{
			return 0;
		}
		if (bookType == BookMark.eBookType.Role)
		{
			return this.AllData[(int)(ID -= 1)].KingdomID;
		}
		return this.AllAllianceData[(int)(ID -= 1)].KingdomID;
	}

	// Token: 0x060001FE RID: 510 RVA: 0x0001B808 File Offset: 0x00019A08
	private ushort GetBookMarkID(int MapID, ushort KingdomID, BookMark.eBookType bookType = BookMark.eBookType.Role)
	{
		ushort num;
		byte[] array;
		BookMarkData[] array2;
		if (bookType == BookMark.eBookType.Role)
		{
			num = DataManager.Instance.RoleAttr.BookmarkNum;
			array = this.KindDataIDIndex[3];
			array2 = this.AllData;
		}
		else
		{
			num = (ushort)this.AllianceBookCount;
			array = this.AllianceIDIndex;
			array2 = this.AllAllianceData;
		}
		for (ushort num2 = 0; num2 < num; num2 += 1)
		{
			ushort id = array2[(int)array[(int)num2]].ID;
			if (array2[(int)array[(int)num2]].KingdomID == KingdomID && this.GetMapID(id, bookType) == MapID)
			{
				return id;
			}
		}
		return 0;
	}

	// Token: 0x060001FF RID: 511 RVA: 0x0001B8A4 File Offset: 0x00019AA4
	public void CheckUpdate(bool LockInput = true)
	{
		if ((this.UpdateTime == 0L || DataManager.Instance.RoleAttr.BookmarkTime != this.UpdateTime) && this.RecvDataCount == 0)
		{
			this.sendBookMarkInfo(LockInput);
		}
	}

	// Token: 0x06000200 RID: 512 RVA: 0x0001B8E0 File Offset: 0x00019AE0
	public void CheckUpdate_Alliance(bool LockInput = true)
	{
		if (DataManager.Instance.RoleAlliance.BookmarkTime == 0L)
		{
			return;
		}
		if (this.UpdateTimeAlliance == 0L || DataManager.Instance.RoleAlliance.BookmarkTime != this.UpdateTimeAlliance)
		{
			this.sendBookMarkInfo_Alliance(LockInput);
		}
	}

	// Token: 0x06000201 RID: 513 RVA: 0x0001B930 File Offset: 0x00019B30
	public void CheckModify()
	{
		this.sendModifyBookMark(this.OverWriteID, this.OverWriteType, this.OverWriteName);
	}

	// Token: 0x06000202 RID: 514 RVA: 0x0001B94C File Offset: 0x00019B4C
	private void AddDataIndex(ushort id)
	{
		if (this.KindDataIDIndex[(int)this.AllData[(int)id].Type].Length > (int)this.KindDataCount[(int)this.AllData[(int)id].Type])
		{
			byte[] array = this.KindDataIDIndex[(int)this.AllData[(int)id].Type];
			byte[] kindDataCount = this.KindDataCount;
			byte type = this.AllData[(int)id].Type;
			byte b;
			kindDataCount[(int)type] = (b = kindDataCount[(int)type]) + 1;
			array[(int)b] = (byte)id;
		}
	}

	// Token: 0x06000203 RID: 515 RVA: 0x0001B9D0 File Offset: 0x00019BD0
	private void InsertDataIndex(ushort id)
	{
		if (this.KindDataIDIndex[(int)this.AllData[(int)id].Type].Length <= (int)this.KindDataCount[(int)this.AllData[(int)id].Type])
		{
			return;
		}
		ushort type = (ushort)this.AllData[(int)id].Type;
		bool flag = false;
		for (int i = 0; i < (int)this.KindDataCount[(int)type]; i++)
		{
			if ((ushort)this.KindDataIDIndex[(int)type][i] > id)
			{
				int num = (int)this.KindDataCount[(int)type] - i;
				if (num > 0 && i + 1 + num <= 100)
				{
					Array.Copy(this.KindDataIDIndex[(int)type], i, this.KindDataIDIndex[(int)type], i + 1, num);
				}
				this.KindDataIDIndex[(int)type][i] = (byte)id;
				byte[] kindDataCount = this.KindDataCount;
				ushort num2 = type;
				kindDataCount[(int)num2] = kindDataCount[(int)num2] + 1;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			this.AddDataIndex(id);
		}
	}

	// Token: 0x06000204 RID: 516 RVA: 0x0001BABC File Offset: 0x00019CBC
	private void InsertDataIndex_Alliance(ushort id)
	{
		if (this.AllianceIDIndex.Length <= (int)this.AllianceBookCount)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < (int)this.AllianceBookCount; i++)
		{
			if ((ushort)this.AllianceIDIndex[i] > id)
			{
				flag = true;
				int num = (int)this.AllianceBookCount - i;
				if (num > 0 && i + 1 + num <= 20)
				{
					Array.Copy(this.AllianceIDIndex, i, this.AllianceIDIndex, i + 1, num);
				}
				this.AllianceIDIndex[i] = (byte)id;
				break;
			}
		}
		if (!flag)
		{
			this.AllianceIDIndex[(int)this.AllianceBookCount] = (byte)id;
		}
		this.AllianceBookCount += 1;
	}

	// Token: 0x06000205 RID: 517 RVA: 0x0001BB6C File Offset: 0x00019D6C
	private void RemoveDataIndex(ushort index, BookMark.eBookType bookType = BookMark.eBookType.Role)
	{
		byte b;
		byte[] array2;
		if (bookType == BookMark.eBookType.Role)
		{
			BookMarkData[] array = this.AllData;
			b = this.KindDataCount[(int)array[(int)index].Type];
			array2 = this.KindDataIDIndex[(int)array[(int)index].Type];
		}
		else
		{
			BookMarkData[] array = this.AllAllianceData;
			b = this.AllianceBookCount;
			array2 = this.AllianceIDIndex;
		}
		bool flag = false;
		for (int i = 0; i < (int)b; i++)
		{
			if ((ushort)array2[i] == index)
			{
				flag = true;
				int num = (int)b - (i + 1);
				if (num > 0)
				{
					Array.Copy(array2, i + 1, array2, i, num);
				}
				break;
			}
		}
		if (flag && b > 0)
		{
			if (bookType == BookMark.eBookType.Role)
			{
				byte[] kindDataCount = this.KindDataCount;
				byte type = this.AllData[(int)index].Type;
				kindDataCount[(int)type] = kindDataCount[(int)type] - 1;
			}
			else
			{
				this.AllianceBookCount -= 1;
			}
		}
	}

	// Token: 0x06000206 RID: 518 RVA: 0x0001BC5C File Offset: 0x00019E5C
	public void RecvBookMarkInfo(MessagePacket MP)
	{
		DataManager instance = DataManager.Instance;
		this.RecvDataCount = MP.ReadUShort(-1);
		ushort num = MP.ReadUShort(-1);
		this.UpdateTime = MP.ReadLong(-1);
		instance.RoleAttr.BookmarkNum = this.RecvDataCount;
		if (this.AllData == null)
		{
			this.AllData = new BookMarkData[100];
			for (int i = 0; i < this.KindDataIDIndex.Length; i++)
			{
				this.KindDataIDIndex[i] = new byte[100];
			}
			for (byte b = 0; b < 100; b += 1)
			{
				this.AllData[(int)b] = new BookMarkData((ushort)this.NameSize);
			}
			this.MessageStr = new CString(200);
		}
		else
		{
			byte b2 = 0;
			while ((ushort)b2 < num)
			{
				if (this.AllData.Length <= (int)b2)
				{
					break;
				}
				this.AllData[(int)b2].Clear();
				b2 += 1;
			}
			for (int j = 0; j < this.KindDataIDIndex.Length; j++)
			{
				Array.Clear(this.KindDataIDIndex[j], 0, this.KindDataIDIndex[j].Length);
			}
			Array.Clear(this.KindDataCount, 0, this.KindDataCount.Length);
		}
		instance.RoleAttr.BookmarkLimit = num;
		instance.RoleAttr.BookmarkTime = this.UpdateTime;
		if (instance.RoleAttr.BookmarkNum == 0)
		{
			GUIManager.Instance.HideUILock(EUILock.BookMark);
		}
	}

	// Token: 0x06000207 RID: 519 RVA: 0x0001BDEC File Offset: 0x00019FEC
	public void RecvBookMarkList(MessagePacket MP)
	{
		ushort num = MP.ReadUShort(-1);
		this.NameSize = MP.ReadByte(-1);
		if (this.RecvDataCount > num)
		{
			this.RecvDataCount -= num;
		}
		else
		{
			this.RecvDataCount = 0;
		}
		for (ushort num2 = 0; num2 < num; num2 += 1)
		{
			ushort num3 = MP.ReadUShort(-1);
			num3 = (ushort)Mathf.Clamp((int)num3, 1, this.AllData.Length);
			BookMarkData[] allData = this.AllData;
			int num4 = (int)(num3 - 1);
			ushort num5 = num3;
			num3 = num5 - 1;
			allData[num4].ID = num5;
			this.AllData[(int)num3].Type = MP.ReadByte(-1);
			if (this.AllData[(int)num3].Type > 2)
			{
				this.AllData[(int)num3].Type = 0;
			}
			this.AllData[(int)num3].KingdomID = MP.ReadUShort(-1);
			this.AllData[(int)num3].KingdomPoint.zoneID = MP.ReadUShort(-1);
			this.AllData[(int)num3].KingdomPoint.pointID = MP.ReadByte(-1);
			MP.ReadStringPlus((int)this.NameSize, this.AllData[(int)num3].Name, -1);
			this.AddDataIndex(num3);
			if ((int)(num2 + this.RecvDataCount) < this.KindDataIDIndex[3].Length)
			{
				this.KindDataIDIndex[3][(int)(num2 + this.RecvDataCount)] = (byte)num3;
			}
		}
		if (this.RecvDataCount == 0)
		{
			GUIManager.Instance.HideUILock(EUILock.BookMark);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 0, 0);
		}
	}

	// Token: 0x06000208 RID: 520 RVA: 0x0001BF84 File Offset: 0x0001A184
	public void RecvBookMarkList_Alliance(MessagePacket MP)
	{
		if (MP.ReadByte(-1) > 0)
		{
			return;
		}
		if (MP.ReadByte(-1) > 0)
		{
			return;
		}
		byte b = MP.ReadByte(-1);
		this.UpdateTimeAlliance = MP.ReadLong(-1);
		this.AllianceBookCount = 0;
		Array.Clear(this.AllianceIDIndex, 0, this.AllianceIDIndex.Length);
		for (byte b2 = 0; b2 < b; b2 += 1)
		{
			if (this.AllAllianceData.Length <= (int)b2)
			{
				break;
			}
			byte b3 = MP.ReadByte(-1);
			this.AllAllianceData[(int)b2].KingdomID = MP.ReadUShort(-1);
			this.AllAllianceData[(int)b2].KingdomPoint.zoneID = MP.ReadUShort(-1);
			this.AllAllianceData[(int)b2].KingdomPoint.pointID = MP.ReadByte(-1);
			this.AllAllianceData[(int)b2].MapID = 0;
			this.AllAllianceData[(int)b2].Type = 3;
			if (b3 > 0)
			{
				MP.ReadStringPlus((int)b3, this.AllAllianceData[(int)b2].Name, -1);
				this.AllAllianceData[(int)b2].ID = (ushort)(b2 + 1);
				this.AllianceIDIndex[(int)this.AllianceBookCount] = b2;
				this.AllianceBookCount += 1;
			}
			else
			{
				this.AllAllianceData[(int)b2].ID = 0;
			}
		}
		DataManager.Instance.RoleAlliance.BookmarkTime = this.UpdateTimeAlliance;
		GUIManager.Instance.HideUILock(EUILock.BookMark);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 0, 0);
	}

	// Token: 0x06000209 RID: 521 RVA: 0x0001C11C File Offset: 0x0001A31C
	public void RecvBookMarkAdd(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.BookMark);
		DataManager instance = DataManager.Instance;
		ushort num = MP.ReadUShort(-1);
		if (num == 0)
		{
			return;
		}
		this.UpdateTime = MP.ReadLong(-1);
		ushort num2 = MP.ReadUShort(-1);
		if (num2 == 0 || (int)num2 > this.AllData.Length)
		{
			return;
		}
		BookMarkData[] allData = this.AllData;
		int num3 = (int)(num2 - 1);
		ushort num4 = num2;
		num2 = num4 - 1;
		allData[num3].ID = num4;
		this.AllData[(int)num2].Type = MP.ReadByte(-1);
		if (this.AllData[(int)num2].Type > 2)
		{
			this.AllData[(int)num2].Type = 0;
		}
		this.AllData[(int)num2].KingdomID = MP.ReadUShort(-1);
		this.AllData[(int)num2].KingdomPoint.zoneID = MP.ReadUShort(-1);
		this.AllData[(int)num2].KingdomPoint.pointID = MP.ReadByte(-1);
		this.AllData[(int)num2].MapID = 0;
		MP.ReadStringPlus((int)this.NameSize, this.AllData[(int)num2].Name, -1);
		DataManager.Instance.RoleAttr.BookmarkTime = this.UpdateTime;
		this.InsertDataIndex(num2);
		if (this.KindDataIDIndex[3].Length >= (int)num)
		{
			if (num < 2)
			{
				this.KindDataIDIndex[3][(int)(num - 1)] = (byte)num2;
			}
			if ((ushort)this.KindDataIDIndex[3][0] < num2)
			{
				for (int i = (int)(instance.RoleAttr.BookmarkNum - 1); i >= 0; i--)
				{
					if ((ushort)this.KindDataIDIndex[3][i] < num2)
					{
						int num5 = i + 1;
						int num6 = (int)instance.RoleAttr.BookmarkNum - num5;
						if (num6 > 0 && num5 + 1 + num6 <= 100)
						{
							Array.Copy(this.KindDataIDIndex[3], num5, this.KindDataIDIndex[3], num5 + 1, num6);
						}
						this.KindDataIDIndex[3][num5] = (byte)num2;
						break;
					}
				}
			}
			else if ((ushort)this.KindDataIDIndex[3][0] > num2)
			{
				Array.Copy(this.KindDataIDIndex[3], 0, this.KindDataIDIndex[3], 1, (int)instance.RoleAttr.BookmarkNum);
				this.KindDataIDIndex[3][0] = (byte)num2;
			}
		}
		instance.RoleAttr.BookmarkNum = num;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 0, 0);
		GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(786u), 255, true);
	}

	// Token: 0x0600020A RID: 522 RVA: 0x0001C3AC File Offset: 0x0001A5AC
	public void RecvBookMarkAddModify_Alliance(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.BookMark);
		DataManager instance = DataManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b != 0 && b != 1)
		{
			return;
		}
		byte b2 = MP.ReadByte(-1);
		byte b3 = MP.ReadByte(-1);
		bool flag = true;
		if (b3 > 0)
		{
			if (b3 == 1)
			{
				GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(4753u), 255, true);
			}
			return;
		}
		if ((int)b2 >= this.AllAllianceData.Length)
		{
			return;
		}
		if (b == 0 && this.AllAllianceData[(int)b2].ID > 0)
		{
			flag = false;
		}
		this.UpdateTimeAlliance = MP.ReadLong(-1);
		instance.RoleAlliance.BookmarkTime = this.UpdateTimeAlliance;
		byte vsize = MP.ReadByte(-1);
		this.AllAllianceData[(int)b2].ID = (ushort)(b2 + 1);
		this.AllAllianceData[(int)b2].Type = 3;
		this.AllAllianceData[(int)b2].KingdomID = MP.ReadUShort(-1);
		this.AllAllianceData[(int)b2].KingdomPoint.zoneID = MP.ReadUShort(-1);
		this.AllAllianceData[(int)b2].KingdomPoint.pointID = MP.ReadByte(-1);
		this.AllAllianceData[(int)b2].MapID = 0;
		MP.ReadStringPlus((int)vsize, this.AllAllianceData[(int)b2].Name, -1);
		if (b == 0 && flag)
		{
			this.InsertDataIndex_Alliance((ushort)b2);
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12631u), 255, true);
		}
		else
		{
			if (this.OverWriteID == 0)
			{
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_BookMark) == null)
				{
					Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					door.OpenMenu(EGUIWindow.UI_BookMark, 655360 | (int)(this.AllAllianceData[(int)b2].Type + 1), this.GetMapID(this.AllAllianceData[(int)b2].ID, BookMark.eBookType.Alliance), false);
				}
				else
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 655360 | (int)(this.AllAllianceData[(int)b2].Type + 1), this.GetMapID(this.AllAllianceData[(int)b2].ID, BookMark.eBookType.Alliance));
				}
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12638u), 255, true);
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12637u), 255, true);
			}
			this.OverWriteID = 0;
		}
	}

	// Token: 0x0600020B RID: 523 RVA: 0x0001C664 File Offset: 0x0001A864
	public void RecvBookMarkDel(MessagePacket MP)
	{
		DataManager instance = DataManager.Instance;
		GUIManager.Instance.HideUILock(EUILock.BookMark);
		ushort num = MP.ReadUShort(-1);
		if (num == 0 || (int)num > this.AllData.Length)
		{
			return;
		}
		this.AllData[(int)(num -= 1)].ID = 0;
		ushort bookmarkNum = MP.ReadUShort(-1);
		this.UpdateTime = MP.ReadLong(-1);
		this.RemoveDataIndex(num, BookMark.eBookType.Role);
		for (ushort num2 = 0; num2 < instance.RoleAttr.BookmarkNum; num2 += 1)
		{
			if ((int)num2 >= this.KindDataIDIndex[3].Length)
			{
				break;
			}
			if ((ushort)this.KindDataIDIndex[3][(int)num2] == num)
			{
				int num3 = (int)(instance.RoleAttr.BookmarkNum - (num2 + 1));
				if (num3 > 0)
				{
					Array.Copy(this.KindDataIDIndex[3], (int)(num2 + 1), this.KindDataIDIndex[3], (int)num2, num3);
				}
				break;
			}
		}
		instance.RoleAttr.BookmarkNum = bookmarkNum;
		instance.RoleAttr.BookmarkTime = this.UpdateTime;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 0, 0);
	}

	// Token: 0x0600020C RID: 524 RVA: 0x0001C77C File Offset: 0x0001A97C
	public void RecvBookMarkDel_Alliance(MessagePacket MP)
	{
		DataManager instance = DataManager.Instance;
		GUIManager.Instance.HideUILock(EUILock.BookMark);
		if (MP.ReadByte(-1) > 0)
		{
			return;
		}
		byte b = MP.ReadByte(-1);
		byte b2 = MP.ReadByte(-1);
		if (b2 > 0)
		{
			if (b2 == 1)
			{
				GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(4753u), 255, true);
			}
			return;
		}
		if ((int)b >= this.AllAllianceData.Length || this.AllAllianceData[(int)b].ID == 0)
		{
			return;
		}
		this.AllAllianceData[(int)b].ID = 0;
		this.RemoveDataIndex((ushort)b, BookMark.eBookType.Alliance);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 0, 0);
	}

	// Token: 0x0600020D RID: 525 RVA: 0x0001C838 File Offset: 0x0001AA38
	public void RecvBookMarkModify(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.BookMark);
		if (MP.ReadUShort(-1) == 0)
		{
			return;
		}
		this.UpdateTime = MP.ReadLong(-1);
		ushort num = MP.ReadUShort(-1);
		if (num == 0 || (int)num > this.AllData.Length)
		{
			return;
		}
		BookMarkData[] allData = this.AllData;
		int num2 = (int)(num - 1);
		ushort num3 = num;
		num = num3 - 1;
		allData[num2].ID = num3;
		byte b = MP.ReadByte(-1);
		if (b > 2)
		{
			b = 0;
		}
		if (b != this.AllData[(int)num].Type)
		{
			this.RemoveDataIndex(num, BookMark.eBookType.Role);
			this.AllData[(int)num].Type = b;
			this.InsertDataIndex(num);
		}
		MP.ReadStringPlus((int)this.NameSize, this.AllData[(int)num].Name, -1);
		DataManager.Instance.RoleAttr.BookmarkTime = this.UpdateTime;
		if (this.OverWriteID == 0)
		{
			if (GUIManager.Instance.FindMenu(EGUIWindow.UI_BookMark) == null)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.OpenMenu(EGUIWindow.UI_BookMark, 589824 | (int)(this.AllData[(int)num].Type + 1), this.GetMapID(this.AllData[(int)num].ID, BookMark.eBookType.Role), false);
			}
			else
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_BookMark, 589824 | (int)(this.AllData[(int)num].Type + 1), this.GetMapID(this.AllData[(int)num].ID, BookMark.eBookType.Role));
			}
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(787u), 255, true);
		}
		else
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12629u), 255, true);
		}
		this.OverWriteID = 0;
	}

	// Token: 0x0600020E RID: 526 RVA: 0x0001CA24 File Offset: 0x0001AC24
	public void sendBookMarkInfo(bool LockInput)
	{
		if (LockInput && !GUIManager.Instance.ShowUILock(EUILock.BookMark))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_BOOKMARKINFO;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x0600020F RID: 527 RVA: 0x0001CA70 File Offset: 0x0001AC70
	public void sendBookMarkInfo_Alliance(bool LockInput)
	{
		if (LockInput && !GUIManager.Instance.ShowUILock(EUILock.BookMark))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_BOOKMARKINFO;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06000210 RID: 528 RVA: 0x0001CABC File Offset: 0x0001ACBC
	public void sendAddBookMark(string Name, byte Type, ushort KingdomID, int MapPointID)
	{
		if (Type == 3)
		{
			this.sendAddBookMark_Alliance(Name, KingdomID, MapPointID);
			return;
		}
		StringTable mStringTable = DataManager.Instance.mStringTable;
		DataManager instance = DataManager.Instance;
		if (this.UpdateTime == 0L || instance.RoleAttr.BookmarkTime != this.UpdateTime || this.RecvDataCount > 0)
		{
			GUIManager.Instance.AddHUDMessage(mStringTable.GetStringByID(8459u), 255, true);
			return;
		}
		ushort num = this.GetBookMarkID(MapPointID, KingdomID, BookMark.eBookType.Role);
		if (num > 0)
		{
			ushort num2 = num;
			num = num2 - 1;
			this.OverWriteID = num2;
			this.OverWriteType = Type;
			this.OverWriteName = Name;
			this.MessageStr.ClearString();
			this.MessageStr.StringToFormat(this.AllData[(int)num].Name);
			this.MessageStr.AppendFormat(mStringTable.GetStringByID(4598u));
			GUIManager.Instance.OpenOKCancelBox(5, mStringTable.GetStringByID(4518u), this.MessageStr.ToString(), 0, 0, mStringTable.GetStringByID(4599u), null);
			return;
		}
		if (instance.RoleAttr.BookmarkNum == instance.RoleAttr.BookmarkLimit)
		{
			GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(614u), mStringTable.GetStringByID(642u), mStringTable.GetStringByID(3u), null, 0, 0, false, false, false, false, false);
			return;
		}
		if (!GUIManager.Instance.ShowUILock(EUILock.BookMark))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBOOKMARK;
		PointCode pointCode;
		GameConstants.MapIDToPointCode(MapPointID, out pointCode.zoneID, out pointCode.pointID);
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.Append(Name);
		messagePacket.AddSeqId();
		messagePacket.Add(this.GetEmptyID(BookMark.eBookType.Role));
		messagePacket.Add(Type);
		messagePacket.Add(KingdomID);
		messagePacket.Add(pointCode.zoneID);
		messagePacket.Add(pointCode.pointID);
		messagePacket.Add(Encoding.UTF8.GetBytes(cstring.ToString()), 0, (int)this.NameSize);
		messagePacket.Send(false);
	}

	// Token: 0x06000211 RID: 529 RVA: 0x0001CCCC File Offset: 0x0001AECC
	private void sendAddBookMark_Alliance(string Name, ushort KingdomID, int MapPointID)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		DataManager instance = DataManager.Instance;
		if (instance.RoleAlliance.Id == 0u || instance.RoleAlliance.Rank < AllianceRank.RANK4)
		{
			GUIManager.Instance.AddHUDMessage(mStringTable.GetStringByID(4753u), 255, true);
			return;
		}
		ushort num = this.GetBookMarkID(MapPointID, KingdomID, BookMark.eBookType.Alliance);
		if (num > 0)
		{
			ushort num2 = num;
			num = num2 - 1;
			this.OverWriteID = num2;
			this.OverWriteType = 3;
			this.OverWriteName = Name;
			this.MessageStr.ClearString();
			this.MessageStr.StringToFormat(this.AllAllianceData[(int)num].Name);
			this.MessageStr.AppendFormat(mStringTable.GetStringByID(12633u));
			GUIManager.Instance.OpenOKCancelBox(5, mStringTable.GetStringByID(12632u), this.MessageStr.ToString(), 0, 0, mStringTable.GetStringByID(4599u), null);
			return;
		}
		if (this.AllianceBookCount == 20)
		{
			GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(4826u), mStringTable.GetStringByID(12634u), null, null, 0, 0, false, false, false, false, false);
			return;
		}
		if (!GUIManager.Instance.ShowUILock(EUILock.BookMark))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFYBOOKMARK;
		PointCode pointCode;
		GameConstants.MapIDToPointCode(MapPointID, out pointCode.zoneID, out pointCode.pointID);
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.Append(Name);
		cstring.SetLength(cstring.Length);
		byte[] bytes = Encoding.UTF8.GetBytes(cstring.ToString());
		byte b = (byte)Math.Min(bytes.Length, (int)this.NameSize);
		cstring.SetLength(cstring.MaxLength);
		messagePacket.AddSeqId();
		messagePacket.Add(0);
		messagePacket.Add((byte)(this.GetEmptyID(BookMark.eBookType.Alliance) - 1));
		messagePacket.Add(b);
		messagePacket.Add(KingdomID);
		messagePacket.Add(pointCode.zoneID);
		messagePacket.Add(pointCode.pointID);
		messagePacket.Add(bytes, 0, (int)b);
		messagePacket.Send(false);
	}

	// Token: 0x06000212 RID: 530 RVA: 0x0001CEE4 File Offset: 0x0001B0E4
	public ushort GetEmptyID(BookMark.eBookType bookType = BookMark.eBookType.Role)
	{
		ushort num;
		BookMarkData[] array;
		if (bookType == BookMark.eBookType.Role)
		{
			num = DataManager.Instance.RoleAttr.BookmarkLimit;
			array = this.AllData;
		}
		else
		{
			num = 20;
			array = this.AllAllianceData;
		}
		byte b = 0;
		while ((ushort)b < num)
		{
			if (array.Length <= (int)b)
			{
				return 1;
			}
			if (array[(int)b].ID == 0)
			{
				return (ushort)(b + 1);
			}
			b += 1;
		}
		return 1;
	}

	// Token: 0x06000213 RID: 531 RVA: 0x0001CF58 File Offset: 0x0001B158
	public void sendDelBookMark(ushort ID)
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.BookMark))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_DELBOOKMARK;
		messagePacket.AddSeqId();
		messagePacket.Add(ID);
		messagePacket.Send(false);
	}

	// Token: 0x06000214 RID: 532 RVA: 0x0001CFA4 File Offset: 0x0001B1A4
	public void sendDelBookMark_Alliance(byte ID)
	{
		if (DataManager.Instance.RoleAlliance.Id == 0u || DataManager.Instance.RoleAlliance.Rank < AllianceRank.RANK4)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753u), 255, true);
			return;
		}
		if (!GUIManager.Instance.ShowUILock(EUILock.BookMark))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_REMOVEBOOKMARK;
		messagePacket.AddSeqId();
		messagePacket.Add(0);
		messagePacket.Add(ID -= 1);
		messagePacket.Send(false);
	}

	// Token: 0x06000215 RID: 533 RVA: 0x0001D04C File Offset: 0x0001B24C
	public void sendModifyBookMark(ushort ID, byte Type, string Name)
	{
		if (Type == 3)
		{
			this.sendModifyBookMark_Alliance((byte)ID, Name);
			return;
		}
		if (!GUIManager.Instance.ShowUILock(EUILock.BookMark))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_MODIFYBOOKMARK;
		messagePacket.AddSeqId();
		messagePacket.Add(ID);
		messagePacket.Add(Type);
		messagePacket.Add(Encoding.UTF8.GetBytes(Name), 0, (int)this.NameSize);
		messagePacket.Send(false);
	}

	// Token: 0x06000216 RID: 534 RVA: 0x0001D0C8 File Offset: 0x0001B2C8
	private void sendModifyBookMark_Alliance(byte ID, string Name)
	{
		if (DataManager.Instance.RoleAlliance.Id == 0u || DataManager.Instance.RoleAlliance.Rank < AllianceRank.RANK4)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753u), 255, true);
			return;
		}
		if (!GUIManager.Instance.ShowUILock(EUILock.BookMark))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFYBOOKMARK;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.Append(Name);
		cstring.SetLength(cstring.Length);
		byte[] bytes = Encoding.UTF8.GetBytes(cstring.ToString());
		byte b = (byte)Math.Min(bytes.Length, (int)this.NameSize);
		cstring.SetLength(cstring.MaxLength);
		messagePacket.AddSeqId();
		messagePacket.Add(1);
		messagePacket.Add(ID -= 1);
		messagePacket.Add(b);
		messagePacket.Add(this.AllAllianceData[(int)ID].KingdomID);
		messagePacket.Add(this.AllAllianceData[(int)ID].KingdomPoint.zoneID);
		messagePacket.Add(this.AllAllianceData[(int)ID].KingdomPoint.pointID);
		messagePacket.Add(bytes, 0, (int)b);
		messagePacket.Send(false);
	}

	// Token: 0x040003F1 RID: 1009
	public const ushort DefaultDataMax = 100;

	// Token: 0x040003F2 RID: 1010
	public const byte DefaultAllianceDataMax = 20;

	// Token: 0x040003F3 RID: 1011
	private byte NameSize = 50;

	// Token: 0x040003F4 RID: 1012
	public long UpdateTime;

	// Token: 0x040003F5 RID: 1013
	public long UpdateTimeAlliance;

	// Token: 0x040003F6 RID: 1014
	public BookMarkData[] AllData;

	// Token: 0x040003F7 RID: 1015
	public BookMarkData[] AllAllianceData;

	// Token: 0x040003F8 RID: 1016
	public ushort RecvDataCount;

	// Token: 0x040003F9 RID: 1017
	private CString MessageStr;

	// Token: 0x040003FA RID: 1018
	public byte[][] KindDataIDIndex = new byte[4][];

	// Token: 0x040003FB RID: 1019
	public byte[] KindDataCount = new byte[3];

	// Token: 0x040003FC RID: 1020
	private ushort OverWriteID;

	// Token: 0x040003FD RID: 1021
	private byte OverWriteType;

	// Token: 0x040003FE RID: 1022
	private string OverWriteName;

	// Token: 0x040003FF RID: 1023
	public byte AllianceBookCount;

	// Token: 0x04000400 RID: 1024
	public byte[] AllianceIDIndex;

	// Token: 0x04000401 RID: 1025
	public byte[] SelectBookMarkIndex = new byte[10];

	// Token: 0x04000402 RID: 1026
	public byte SelectCount;

	// Token: 0x0200004C RID: 76
	public enum eBookType
	{
		// Token: 0x04000404 RID: 1028
		Role,
		// Token: 0x04000405 RID: 1029
		Alliance
	}
}
