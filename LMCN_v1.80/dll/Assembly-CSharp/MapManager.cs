using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

// Token: 0x02000244 RID: 580
public class MapManager
{
	// Token: 0x060009E5 RID: 2533 RVA: 0x000D0984 File Offset: 0x000CEB84
	public MapManager()
	{
		byte[] array = new byte[40];
		array[1] = 1;
		array[2] = 2;
		array[3] = 3;
		array[4] = 4;
		array[5] = 5;
		array[6] = 6;
		this.showYolkMapYolkID = array;
		this.yolkswitch = new byte[5];
		this.MapBasePointSize = 39;
		this.MapLineSize = 49;
		this.MapKingdomSize = 40;
		this.stateKinds = new byte[255];
		this.stateCounts = new byte[255];
		this.stateSkillIDs = new ushort[255][][];
		this.stateSkillLevels = new byte[255][][];
		base();
		this.kingdomData.kingdomID = (this.kingdomData.kingKingdomID = (this.kingdomData.allianceKingdomID = 0));
		this.kingdomData.kingdomFlag = 0;
		this.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_NONE;
		this.kingdomData.kingName = new CString(13);
		this.kingdomData.allianceTag = new CString(4);
		this.kingdomData.allianceName = new CString(21);
		this.kingdomData.kingdomName = new CString(21);
		this.OtherKingdomData.kingdomID = (this.OtherKingdomData.kingKingdomID = (this.OtherKingdomData.allianceKingdomID = 0));
		this.OtherKingdomData.kingdomFlag = 0;
		this.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_NONE;
		this.OtherKingdomData.kingName = new CString(13);
		this.OtherKingdomData.allianceTag = new CString(4);
		this.OtherKingdomData.allianceName = new CString(21);
		this.OtherKingdomData.kingdomName = new CString(21);
		for (int i = 0; i < 32; i++)
		{
			this.WorldKingdomTable[i].kingdomID = (this.WorldKingdomTable[i].kingKingdomID = (this.WorldKingdomTable[i].allianceKingdomID = 0));
			this.WorldKingdomTable[i].kingdomFlag = 0;
			this.WorldKingdomTable[i].kingdomPeriod = KINGDOM_PERIOD.KP_NONE;
			this.WorldKingdomTable[i].kingName = new CString(13);
			this.WorldKingdomTable[i].allianceTag = new CString(4);
			this.WorldKingdomTable[i].allianceName = new CString(21);
			this.WorldKingdomTable[i].kingdomName = new CString(21);
		}
		if (this.ZoneLineIDTable != null)
		{
			for (int j = 0; j < this.ZoneLineIDTable.Length; j++)
			{
				this.ZoneLineIDTable[j] = new List<ZoneLine>(32);
			}
		}
		if (this.TempLineIDTable != null)
		{
			for (int k = 0; k < this.TempLineIDTable.Length; k++)
			{
				this.TempLineIDTable[k] = new List<ZoneLine>(32);
			}
		}
		if (this.MapLineTable != null)
		{
			for (int l = 0; l < 256; l++)
			{
				this.MapLineTable.Add(new MapLine());
			}
		}
		if (this.PlayerPointTable != null)
		{
			for (int m = 0; m < 2048; m++)
			{
				this.PlayerPointTable[m].allianceTag = new CString(4);
				this.PlayerPointTable[m].allianceName = new CString(21);
				this.PlayerPointTable[m].playerName = new CString(13);
				this.PlayerPointTable[m].cityAttribute = new byte[6];
			}
		}
		if (this.ResourcesPointTable != null)
		{
			for (int n = 0; n < 2048; n++)
			{
				this.ResourcesPointTable[n].allianceTag = new CString(4);
				this.ResourcesPointTable[n].playerName = new CString(13);
			}
		}
		if (this.YolkPointTable != null)
		{
			for (int num = 0; num < 40; num++)
			{
				this.YolkPointTable[num].WonderID = (byte)num;
				this.YolkPointTable[num].WonderAllianceTag = new CString(4);
				this.YolkPointTable[num].OwnerAllianceName = new CString(21);
				this.YolkPointTable[num].WonderLeader = new CString(13);
				this.YolkPointTable[num].OwnerName = new CString(13);
				this.YolkPointTable[num].WonderState = byte.MaxValue;
				this.YolkPointTable[num].AllianceKingdomID = ushort.MaxValue;
			}
		}
		if (this.NPCPointTable != null)
		{
			for (int num2 = 0; num2 < 2048; num2++)
			{
				this.NPCPointTable[num2].NPCAllianceTag = new CString(21);
			}
		}
		this.zoneID[0] = (this.LastZoneID[0] = 16384);
		this.waitZoneIDNum = 0;
		Array.Clear(this.stateKinds, 0, this.stateKinds.Length);
		Array.Clear(this.stateCounts, 0, this.stateCounts.Length);
		Array.Clear(this.stateSkillIDs, 0, this.stateSkillIDs.Length);
		Array.Clear(this.stateSkillLevels, 0, this.stateSkillLevels.Length);
	}

	// Token: 0x060009E6 RID: 2534 RVA: 0x000D10C8 File Offset: 0x000CF2C8
	public void Init()
	{
		this.LoadMapInfo();
	}

	// Token: 0x060009E7 RID: 2535 RVA: 0x000D10D0 File Offset: 0x000CF2D0
	public void loginFinish()
	{
	}

	// Token: 0x060009E8 RID: 2536 RVA: 0x000D10D4 File Offset: 0x000CF2D4
	public void LoadTableData()
	{
		this.EmojiDataTable = new CExternalTableWithWordKey<EmojiData>();
		this.EmoteTable = new CExternalTableWithWordKey<Emote>();
		this.YolkDeployTable = new CExternalTableWithWordKey<YolkDeploy>();
		this.KingdomMapTable = new CExternalTableWithWordKey<KingdomMap>();
		this.MapMonsterTable = new CExternalTableWithWordKey<MapMonster>();
		this.MapMonsterPriceTable = new CExternalTableWithWordKey<MapMonsterPrice>();
		this.MapWondersInfoTable = new CExternalTableWithWordKey<WondersInfoTbl>();
		this.KingdomYolkDeployTable = new CExternalTableWithWordKey<KingdomYolkDeploy>();
		this.KingdomMapTable.LoadTable("Kingdom");
		this.KingdomYolkDeployTable.LoadTable("KingdomToWonders");
		this.MapMonsterPriceTable.LoadTable("MonsterTreasure");
		this.MapMonsterTable.LoadTable("Monster");
		this.MapWondersInfoTable.LoadTable("WondersInformation");
		this.EmojiDataTable.LoadTable("EMOJI");
		this.EmoteTable.LoadTable("Emote");
		this.YolkDeployTable.LoadTable("WonderPosition");
		if (this.yolkName == null)
		{
			this.yolkName = new CString[this.MapWondersInfoTable.TableCount];
			for (int i = 0; i < this.yolkName.Length; i++)
			{
				this.yolkName[i] = new CString(32);
				this.yolkName[i].ClearString();
				this.yolkName[i].Append(DataManager.Instance.mStringTable.GetStringByID((uint)this.MapWondersInfoTable.GetRecordByIndex(i).NameID));
			}
		}
	}

	// Token: 0x060009E9 RID: 2537 RVA: 0x000D1248 File Offset: 0x000CF448
	public CString GetYolkName(ushort WonderID, ushort kingdomID = 0)
	{
		if (kingdomID == 0)
		{
			kingdomID = this.OtherKingdomData.kingdomID;
		}
		KingdomYolkDeploy recordByIndex = this.KingdomYolkDeployTable.GetRecordByIndex(0);
		int i;
		for (i = 1; i < this.KingdomYolkDeployTable.TableCount; i++)
		{
			recordByIndex = this.KingdomYolkDeployTable.GetRecordByIndex(i);
			if (recordByIndex.kingdomID == kingdomID)
			{
				break;
			}
		}
		if (i >= this.KingdomYolkDeployTable.TableCount)
		{
			recordByIndex = this.KingdomYolkDeployTable.GetRecordByIndex(0);
		}
		if ((int)WonderID >= recordByIndex.yolkDeployIDs.Length)
		{
			WonderID = 0;
		}
		ushort inKey = recordByIndex.yolkDeployIDs[(int)WonderID];
		YolkDeploy recordByKey = this.YolkDeployTable.GetRecordByKey(inKey);
		return ((int)recordByKey.YolkNameID > this.yolkName.Length) ? this.yolkName[0] : this.yolkName[(int)(recordByKey.YolkNameID - 1)];
	}

	// Token: 0x060009EA RID: 2538 RVA: 0x000D1328 File Offset: 0x000CF528
	public Vector2 GetYolkPos(ushort WonderID, ushort kingdomID = 0)
	{
		if (kingdomID == 0)
		{
			kingdomID = this.OtherKingdomData.kingdomID;
		}
		KingdomYolkDeploy recordByIndex = this.KingdomYolkDeployTable.GetRecordByIndex(0);
		int i;
		for (i = 1; i < this.KingdomYolkDeployTable.TableCount; i++)
		{
			recordByIndex = this.KingdomYolkDeployTable.GetRecordByIndex(i);
			if (recordByIndex.kingdomID == kingdomID)
			{
				break;
			}
		}
		if (i >= this.KingdomYolkDeployTable.TableCount)
		{
			recordByIndex = this.KingdomYolkDeployTable.GetRecordByIndex(0);
		}
		if ((int)WonderID >= recordByIndex.yolkDeployIDs.Length)
		{
			WonderID = 0;
		}
		ushort inKey = recordByIndex.yolkDeployIDs[(int)WonderID];
		YolkDeploy recordByKey = this.YolkDeployTable.GetRecordByKey(inKey);
		return new Vector2((float)recordByKey.posX, (float)recordByKey.posY);
	}

	// Token: 0x060009EB RID: 2539 RVA: 0x000D13EC File Offset: 0x000CF5EC
	public Vector2 GetYolkPointCode(ushort WonderID, ushort kingdomID = 0)
	{
		Vector2 yolkPos = this.GetYolkPos(WonderID, kingdomID);
		Vector2 in_mapPos = yolkPos;
		in_mapPos.x += 1f;
		Vector2 vector = GameConstants.MapPosToPointCode(yolkPos);
		Vector2 rhs = GameConstants.MapPosToPointCode(in_mapPos);
		if (vector == rhs)
		{
			in_mapPos = yolkPos;
			in_mapPos.y += 1f;
			vector = GameConstants.MapPosToPointCode(in_mapPos);
		}
		return vector;
	}

	// Token: 0x060009EC RID: 2540 RVA: 0x000D1450 File Offset: 0x000CF650
	public uint GetYolkMapID(ushort WonderID, ushort kingdomID = 0)
	{
		Vector2 yolkPointCode = this.GetYolkPointCode(WonderID, kingdomID);
		return (uint)GameConstants.PointCodeToMapID((ushort)yolkPointCode.x, (byte)yolkPointCode.y);
	}

	// Token: 0x060009ED RID: 2541 RVA: 0x000D147C File Offset: 0x000CF67C
	public bool CheckYolk(ushort WonderID, ushort kingdomID = 0)
	{
		if (this.yolkswitch == null)
		{
			return false;
		}
		WonderID += 1;
		ushort num;
		byte b;
		this.GetKingdomOpenIndexShift(WonderID, out num, out b);
		return (int)num < this.yolkswitch.Length && ((int)this.yolkswitch[(int)num] & 1 << (int)b) > 0;
	}

	// Token: 0x060009EE RID: 2542 RVA: 0x000D14CC File Offset: 0x000CF6CC
	public void ClearLayoutMapInfoYolkKind()
	{
		for (ushort num = 1; num < (ushort)this.showYolkNum; num += 1)
		{
			this.LayoutMapInfo[(int)((UIntPtr)this.GetYolkMapID((ushort)this.showYolkMapYolkID[(int)num], this.FocusKingdomID))].pointKind = 0;
		}
	}

	// Token: 0x060009EF RID: 2543 RVA: 0x000D1518 File Offset: 0x000CF718
	public void RequsetYolkswitch()
	{
		MessagePacket messagePacket;
		if (this.FocusKingdomID != this.OtherKingdomData.kingdomID)
		{
			messagePacket = MessagePacket.GetGuestMessagePack();
		}
		else
		{
			messagePacket = new MessagePacket(1024);
		}
		messagePacket.Protocol = Protocol._MSG_REQUEST_WONDER_SWITCH;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x060009F0 RID: 2544 RVA: 0x000D156C File Offset: 0x000CF76C
	public void UpdateYolkswitch(MessagePacket MP)
	{
		if (this.yolkswitch == null)
		{
			return;
		}
		byte b = 0;
		while ((int)b < this.yolkswitch.Length)
		{
			byte b2 = MP.ReadByte(-1);
			byte[] array = this.yolkswitch;
			byte b3 = b;
			array[(int)b3] = (array[(int)b3] ^ b2);
			if (this.yolkswitch[(int)b] != 0)
			{
				for (byte b4 = 0; b4 < 8; b4 += 1)
				{
					if (((int)this.yolkswitch[(int)b] & 1 << (int)b4) != 0 && ((int)b2 & 1 << (int)b4) == 0)
					{
						byte b5 = b * 8 + b4;
						uint yolkMapID = this.GetYolkMapID((ushort)b5, this.FocusKingdomID);
						if (b5 < 40)
						{
							this.LayoutMapInfo[(int)((UIntPtr)yolkMapID)].pointKind = 0;
						}
						this.PointNotifyObserver(yolkMapID);
					}
				}
			}
			this.yolkswitch[(int)b] = b2;
			b += 1;
		}
		this.showYolkNum = 0;
		for (byte b6 = 0; b6 < 40; b6 += 1)
		{
			if (this.CheckYolk((ushort)b6, this.FocusKingdomID))
			{
				uint yolkMapID2 = this.GetYolkMapID((ushort)b6, this.FocusKingdomID);
				byte[] array2 = this.showYolkMapYolkID;
				byte b7;
				this.showYolkNum = (b7 = this.showYolkNum) + 1;
				array2[(int)b7] = b6;
				this.LayoutMapInfo[(int)((UIntPtr)yolkMapID2)].pointKind = 11;
				this.LayoutMapInfo[(int)((UIntPtr)yolkMapID2)].tableID = (ushort)b6;
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MiniMap, 0, 0);
	}

	// Token: 0x060009F1 RID: 2545 RVA: 0x000D16D8 File Offset: 0x000CF8D8
	public ushort getYolkIDbyMapID(int inMapID, ushort inkingdomID = 0)
	{
		if (inkingdomID == this.FocusKingdomID)
		{
			for (byte b = 0; b < this.showYolkNum; b += 1)
			{
				if (inMapID == (int)this.GetYolkMapID((ushort)this.showYolkMapYolkID[(int)b], inkingdomID))
				{
					return (ushort)this.showYolkMapYolkID[(int)b];
				}
			}
		}
		else
		{
			for (ushort num = 0; num < 40; num += 1)
			{
				if (inMapID == (int)this.GetYolkMapID(num, inkingdomID))
				{
					return num;
				}
			}
		}
		return 40;
	}

	// Token: 0x060009F2 RID: 2546 RVA: 0x000D1754 File Offset: 0x000CF954
	public ushort getYolkIDbyPointCode(ushort inZoneID, byte inPointID, ushort inkingdomID = 0)
	{
		if (inkingdomID == 0)
		{
			inkingdomID = this.OtherKingdomData.kingdomID;
		}
		return this.getYolkIDbyMapID(GameConstants.PointCodeToMapID(inZoneID, inPointID), inkingdomID);
	}

	// Token: 0x060009F3 RID: 2547 RVA: 0x000D1778 File Offset: 0x000CF978
	public float CalcDistance(int startmapID, int endmapID, ushort inkingdomID = 0)
	{
		if (inkingdomID == 0)
		{
			inkingdomID = this.OtherKingdomData.kingdomID;
		}
		Vector2 tileMapPosbySpriteID = GameConstants.getTileMapPosbySpriteID(startmapID);
		if (this.getYolkIDbyMapID(startmapID, inkingdomID) != 40)
		{
			tileMapPosbySpriteID.y -= 1f;
		}
		Vector2 a = GameConstants.getTileMapPosbySpriteID(endmapID);
		if (this.getYolkIDbyMapID(endmapID, inkingdomID) != 40)
		{
			a.y -= 1f;
		}
		a -= tileMapPosbySpriteID;
		return GameConstants.FastInvSqrt(a.sqrMagnitude);
	}

	// Token: 0x060009F4 RID: 2548 RVA: 0x000D1800 File Offset: 0x000CFA00
	public void OutMap()
	{
		this.lastReqKingdomIDNum = 0;
		if (this.zoneID[0] == 16384)
		{
			return;
		}
		if (this.checkZone >> (int)this.zoneIDNum == 1)
		{
			for (byte b = 0; b < 4; b += 1)
			{
				this.LastZoneID[(int)b] = this.zoneID[(int)b];
			}
			this.LastZoneIDNum = this.zoneIDNum;
		}
		this.checkZone = 2;
		Array.Clear(this.zoneID, 0, 4);
		this.zoneID[0] = 16384;
		ulong data = 0UL;
		this.zoneIDNum = 1;
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_MAPDATA;
		messagePacket.AddSeqId();
		messagePacket.Add(this.zoneIDNum);
		for (int i = 0; i < 4; i++)
		{
			messagePacket.Add(this.zoneID[i]);
		}
		for (int j = 0; j < 4; j++)
		{
			messagePacket.Add(data);
		}
		messagePacket.Send(false);
	}

	// Token: 0x060009F5 RID: 2549 RVA: 0x000D1904 File Offset: 0x000CFB04
	public void RequsetAdvanceMapdata(int mapPointID)
	{
		this.stateMapID = (uint)mapPointID;
		this.mapStateKindCount = 0;
		ushort data = 0;
		byte data2 = 0;
		GameConstants.MapIDToPointCode(mapPointID, out data, out data2);
		MessagePacket messagePacket;
		if (this.FocusKingdomID != this.OtherKingdomData.kingdomID)
		{
			messagePacket = MessagePacket.GetGuestMessagePack();
		}
		else
		{
			messagePacket = new MessagePacket(1024);
		}
		messagePacket.Protocol = Protocol._MSG_REQUEST_MAP_ADVANCE;
		messagePacket.AddSeqId();
		messagePacket.Add(data);
		messagePacket.Add(data2);
		messagePacket.Send(false);
	}

	// Token: 0x060009F6 RID: 2550 RVA: 0x000D1980 File Offset: 0x000CFB80
	public void RequsetLineInZone(ushort ZoneID)
	{
	}

	// Token: 0x060009F7 RID: 2551 RVA: 0x000D1984 File Offset: 0x000CFB84
	public void RequsetLineByID(ushort LineID)
	{
	}

	// Token: 0x060009F8 RID: 2552 RVA: 0x000D1988 File Offset: 0x000CFB88
	public void RecvMapInfoPlus(MessagePacket MP)
	{
		for (MAP_UPDATE_KIND map_UPDATE_KIND = (MAP_UPDATE_KIND)MP.ReadByte(-1); map_UPDATE_KIND != MAP_UPDATE_KIND.MAPUPDATE_NONE; map_UPDATE_KIND = (MAP_UPDATE_KIND)MP.ReadByte(-1))
		{
			if (map_UPDATE_KIND == MAP_UPDATE_KIND.MAPUPDATE_ZONE_NONE)
			{
				this.CheckZoneID(MP.ReadUShort(-1), false);
			}
			else if (map_UPDATE_KIND == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM)
			{
				byte b = MP.ReadByte(-1);
				if (b > this.MapKingdomSize && b <= 128)
				{
					this.MapKingdomSize = b;
				}
				this.updateKingdomNum = MP.ReadByte(-1);
				int num = (int)(16 - this.updateKingdomNum);
				int num2 = (int)(this.WorldMaxX - this.WorldMinX + 1);
				for (int i = 0; i < (int)this.updateKingdomNum; i++)
				{
					ulong num3 = MP.ReadULong(-1);
					this.updateKingdomID[i] = MP.ReadUShort(-1);
					KingdomMap recordByKey = this.KingdomMapTable.GetRecordByKey(this.updateKingdomID[i]);
					int num4 = (int)(recordByKey.worldPosX - this.WorldMinX) + (int)(recordByKey.worldPosY - this.WorldMinY) * num2;
					num = (int)this.TileMapKingdomID[num4].tableID;
					if (this.TileMapKingdomID[num4].KingdomID != this.WorldKingdomTable[num].kingdomID)
					{
						byte worldKingdomTableIDcounter;
						this.WorldKingdomTableIDcounter = (worldKingdomTableIDcounter = this.WorldKingdomTableIDcounter) + 1;
						num = (int)worldKingdomTableIDcounter;
						this.WorldKingdomTableIDcounter &= 31;
					}
					this.TileMapKingdomID[num4].tableID = (byte)num;
					this.WorldKingdomTable[num].kingdomID = this.updateKingdomID[i];
					this.WorldKingdomTable[num].kingdomFlag = MP.ReadByte(-1);
					this.WorldKingdomTable[num].kingdomPeriod = (KINGDOM_PERIOD)MP.ReadByte(-1);
					this.WorldKingdomTable[num].kingName.ClearString();
					MP.ReadStringPlus(13, this.WorldKingdomTable[num].kingName, -1);
					this.WorldKingdomTable[num].allianceTag.ClearString();
					MP.ReadStringPlus(3, this.WorldKingdomTable[num].allianceTag, -1);
					this.WorldKingdomTable[num].allianceName.ClearString();
					MP.ReadStringPlus(20, this.WorldKingdomTable[num].allianceName, -1);
					this.GetKingdomName(this.WorldKingdomTable[num].kingdomID, ref this.WorldKingdomTable[num].kingdomName);
					for (int j = (int)(b - 40); j > 0; j--)
					{
						MP.ReadByte(-1);
					}
					this.KingdomNotifyObserver((byte)num, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM);
				}
				if (this.updateKingdomNum <= this.reqKingdomIDNum)
				{
					int num5 = 0;
					int num6 = 0;
					while (num5 < (int)this.reqKingdomIDNum && num6 < (int)this.updateKingdomNum)
					{
						if (this.reqKingdomID[num5] == this.updateKingdomID[num6])
						{
							num6++;
						}
						num5++;
					}
					if (num6 == (int)this.updateKingdomNum)
					{
						DataManager.msgBuffer[0] = 115;
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						this.wait = 0f;
					}
				}
				if (this.wait != 0f)
				{
					DataManager.msgBuffer[0] = 115;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					this.wait = 0f;
				}
			}
			else if (map_UPDATE_KIND == MAP_UPDATE_KIND.MAPUPDATE_MAX || map_UPDATE_KIND == MAP_UPDATE_KIND.MAPUPDATE_END)
			{
				ushort num7 = MP.ReadUShort(-1);
				byte b2 = (byte)(num7 >> 12);
				byte b3 = (byte)(num7 >> 6 & 63);
				byte b4 = (byte)(num7 & 63);
				if (b2 > 0 && this.UpdateZoneIDNum != 0)
				{
					for (int k = 0; k < (int)this.UpdateZoneIDNum; k++)
					{
						this.ZoneNotifyObserver(this.UpdateZoneID[k]);
					}
					this.UpdateZoneIDNum = 0;
				}
				for (int l = 0; l < (int)b2; l++)
				{
					this.UpdateZoneIDNum += 1;
					this.UpdateZoneID[l] = MP.ReadUShort(-1);
					this.ZoneUpdateNum[l] = MP.ReadULong(-1);
					if (this.ZoneUpdateNum[l] == 0UL)
					{
						this.ZoneUpdateNum[l] += 1UL;
					}
				}
				byte b5;
				if (b2 != 0)
				{
					this.checkZoneLine(this.UpdateZoneIDNum, this.UpdateZoneID);
					for (int m = 0; m < (int)this.UpdateZoneIDNum; m++)
					{
						this.CheckZoneID(this.UpdateZoneID[m], true);
						this.ZoneUpdateInfo[(int)this.UpdateZoneID[m]].updateNum = this.ZoneUpdateNum[m];
					}
					b5 = MP.ReadByte(-1);
					if (b5 > 39 && b5 <= 128)
					{
						this.MapBasePointSize = b5;
					}
					b5 = MP.ReadByte(-1);
					if (b5 > 49 && b5 <= 128)
					{
						this.MapLineSize = b5;
					}
				}
				b5 = this.MapBasePointSize - 4;
				for (int n = 0; n < (int)b3; n++)
				{
					ushort num8 = MP.ReadUShort(-1);
					byte pointID = MP.ReadByte(-1);
					uint num9 = (uint)GameConstants.PointCodeToMapID(num8, pointID);
					if (this.IsCityOrCamp(num9))
					{
						this.PlayerPointTableIDpool.despawn((int)this.LayoutMapInfo[(int)((UIntPtr)num9)].tableID);
					}
					else if (this.IsResources(num9))
					{
						this.ResourcesPointTableIDpool.despawn((int)this.LayoutMapInfo[(int)((UIntPtr)num9)].tableID);
					}
					else if (this.LayoutMapInfo[(int)((UIntPtr)num9)].pointKind == 10)
					{
						this.NPCPointTableIDpool.despawn((int)this.LayoutMapInfo[(int)((UIntPtr)num9)].tableID);
					}
					this.LayoutMapInfo[(int)((UIntPtr)num9)].pointKind = MP.ReadByte(-1);
					if (this.LayoutMapInfo[(int)((UIntPtr)num9)].pointKind == 12)
					{
						this.LayoutMapInfo[(int)((UIntPtr)num9)].tableID = (ushort)MP.ReadByte(-1);
						for (int num10 = (int)(b5 - 1); num10 > 0; num10--)
						{
							MP.ReadByte(-1);
						}
					}
					else if (this.IsCityOrCamp(num9))
					{
						ushort num11 = this.LayoutMapInfo[(int)((UIntPtr)num9)].tableID = (ushort)this.PlayerPointTableIDpool.spawn();
						MP.ReadStringPlus(13, this.PlayerPointTable[(int)num11].playerName, -1);
						MP.ReadStringPlus(3, this.PlayerPointTable[(int)num11].allianceTag, -1);
						this.PlayerPointTable[(int)num11].kingdomID = MP.ReadUShort(-1);
						this.PlayerPointTable[(int)num11].level = MP.ReadByte(-1);
						this.PlayerPointTable[(int)num11].capitalFlag = MP.ReadByte(-1);
						this.PlayerPointTable[(int)num11].kingdomTitle = (KINGDOM_DESIGNATION)MP.ReadByte(-1);
						this.PlayerPointTable[(int)num11].worldTitle = (WORLD_PLAYER_DESIGNATION)MP.ReadByte(-1);
						this.PlayerPointTable[(int)num11].allianceKingdomID = MP.ReadUShort(-1);
						this.PlayerPointTable[(int)num11].cityProperty = (CITY_PROPERTY)MP.ReadByte(-1);
						this.PlayerPointTable[(int)num11].cityOutward = (CITY_OUTWARD)MP.ReadByte(-1);
						this.PlayerPointTable[(int)num11].cityOutwardLevel = MP.ReadByte(-1);
						this.PlayerPointTable[(int)num11].nobilityTitle = MP.ReadByte(-1);
						for (int num12 = 0; num12 < this.PlayerPointTable[(int)num11].cityAttribute.Length; num12++)
						{
							this.PlayerPointTable[(int)num11].cityAttribute[num12] = MP.ReadByte(-1);
						}
						for (int num13 = (int)(b5 - 34 - 3); num13 > 0; num13--)
						{
							MP.ReadByte(-1);
						}
						this.PlayerPointTable[(int)num11].baseFlag = MP.ReadByte(-1);
						this.PlayerPointTable[(int)num11].emojiID = MP.ReadUShort(-1);
					}
					else if (this.IsResources(num9))
					{
						ushort num11 = this.LayoutMapInfo[(int)((UIntPtr)num9)].tableID = (ushort)this.ResourcesPointTableIDpool.spawn();
						MP.ReadStringPlus(13, this.ResourcesPointTable[(int)num11].playerName, -1);
						MP.ReadStringPlus(3, this.ResourcesPointTable[(int)num11].allianceTag, -1);
						this.ResourcesPointTable[(int)num11].kingdomID = MP.ReadUShort(-1);
						this.ResourcesPointTable[(int)num11].level = MP.ReadByte(-1);
						this.ResourcesPointTable[(int)num11].count = MP.ReadUInt(-1);
						this.ResourcesPointTable[(int)num11].rate = MP.ReadFloat(-1);
						this.ResourcesPointTable[(int)num11].time = MP.ReadULong(-1);
						for (int num14 = (int)(b5 - 35 - 3); num14 > 0; num14--)
						{
							MP.ReadByte(-1);
						}
						this.ResourcesPointTable[(int)num11].baseFlag = MP.ReadByte(-1);
						this.ResourcesPointTable[(int)num11].emojiID = MP.ReadUShort(-1);
					}
					else if (this.LayoutMapInfo[(int)((UIntPtr)num9)].pointKind == 10)
					{
						ushort num11 = this.LayoutMapInfo[(int)((UIntPtr)num9)].tableID = (ushort)this.NPCPointTableIDpool.spawn();
						this.NPCPointTable[(int)num11].level = MP.ReadByte(-1);
						this.NPCPointTable[(int)num11].NPCNum = MP.ReadUShort(-1);
						if (this.NPCPointTable[(int)num11].NPCNum < 2 || (int)this.NPCPointTable[(int)num11].NPCNum >= this.MapMonsterTable.TableCount)
						{
							this.NPCPointTable[(int)num11].NPCNum = 2;
						}
						this.NPCPointTable[(int)num11].Key = MP.ReadUInt(-1);
						this.NPCPointTable[(int)num11].Blood = MP.ReadFloat(-1);
						MP.ReadStringPlus(3, this.NPCPointTable[(int)num11].NPCAllianceTag, -1);
						this.NPCPointTable[(int)num11].endTime = MP.ReadULong(-1);
						for (int num15 = (int)(b5 - 22 - 3); num15 > 0; num15--)
						{
							MP.ReadByte(-1);
						}
						this.NPCPointTable[(int)num11].baseFlag = MP.ReadByte(-1);
						this.NPCPointTable[(int)num11].emojiID = MP.ReadUShort(-1);
					}
					else if (this.LayoutMapInfo[(int)((UIntPtr)num9)].pointKind == 11)
					{
						ushort num11 = this.LayoutMapInfo[(int)((UIntPtr)num9)].tableID = (ushort)MP.ReadByte(-1);
						this.YolkPointTable[(int)num11].WonderID = (byte)num11;
						this.YolkPointTable[(int)num11].WonderState = MP.ReadByte(-1);
						this.YolkPointTable[(int)num11].StateBegin = MP.ReadULong(-1);
						this.YolkPointTable[(int)num11].StateDuring = MP.ReadUInt(-1);
						this.YolkPointTable[(int)num11].OwnerEmblem = MP.ReadUShort(-1);
						MP.ReadStringPlus(13, this.YolkPointTable[(int)num11].WonderLeader, -1);
						MP.ReadStringPlus(3, this.YolkPointTable[(int)num11].WonderAllianceTag, -1);
						this.YolkPointTable[(int)num11].LeaderKingdomID = MP.ReadUShort(-1);
						this.YolkPointTable[(int)num11].WonderFlag = MP.ReadByte(-1);
						this.YolkPointTable[(int)num11].AllianceKingdomID = MP.ReadUShort(-1);
						this.YolkPointTable[(int)num11].LeaderHomeKingdomID = MP.ReadUShort(-1);
						for (int num16 = (int)(b5 - 39 - 3); num16 > 0; num16--)
						{
							MP.ReadByte(-1);
						}
						this.YolkPointTable[(int)num11].baseFlag = MP.ReadByte(-1);
						this.YolkPointTable[(int)num11].emojiID = MP.ReadUShort(-1);
						if (!this.CheckYolk(num11, this.FocusKingdomID))
						{
							this.LayoutMapInfo[(int)((UIntPtr)num9)].pointKind = 0;
						}
						else
						{
							DataManager.msgBuffer[0] = 94;
							GameConstants.GetBytes(num11, DataManager.msgBuffer, 1);
							GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						}
					}
					else
					{
						for (int num17 = (int)b5; num17 > 0; num17--)
						{
							MP.ReadByte(-1);
						}
					}
				}
				for (int num18 = 0; num18 < (int)b4; num18++)
				{
					uint lineID = MP.ReadUInt(-1);
					int num19 = this.getLineTableID(lineID);
					if (num19 == 1048576)
					{
						num19 = this.MapLineTableIDpool.spawn();
						while (num19 >= this.MapLineTable.Count)
						{
							this.MapLineTable.Add(new MapLine());
						}
						this.MapLineTable[num19].lineID = lineID;
						MP.ReadStringPlus(13, this.MapLineTable[num19].playerName, -1);
						MP.ReadStringPlus(3, this.MapLineTable[num19].allianceTag, -1);
						this.MapLineTable[num19].kingdomID = MP.ReadUShort(-1);
						this.MapLineTable[num19].start.zoneID = MP.ReadUShort(-1);
						this.MapLineTable[num19].start.pointID = MP.ReadByte(-1);
						this.MapLineTable[num19].end.zoneID = MP.ReadUShort(-1);
						this.MapLineTable[num19].end.pointID = MP.ReadByte(-1);
						this.MapLineTable[num19].begin = MP.ReadULong(-1);
						this.MapLineTable[num19].during = MP.ReadUInt(-1);
						this.MapLineTable[num19].EXbegin = MP.ReadUInt(-1);
						this.MapLineTable[num19].EXduring = MP.ReadUInt(-1);
						this.MapLineTable[num19].lineFlag = MP.ReadByte(-1);
						this.MapLineTable[num19].baseFlag = MP.ReadByte(-1);
						this.MapLineTable[num19].emojiID = MP.ReadUShort(-1);
						if ((this.MapLineTable[num19].start.zoneID == this.MapLineTable[num19].end.zoneID && this.MapLineTable[num19].start.pointID == this.MapLineTable[num19].end.pointID) || this.MapLineTable[num19].playerName[0] == '\0')
						{
							this.MapLineTableIDpool.despawn(num19);
							this.MapLineTable[num19].MapLineInit();
						}
						else
						{
							this.addLine(num19);
						}
					}
					else
					{
						this.MapLineTable[num19].lineID = lineID;
						MP.ReadStringPlus(13, this.MapLineTable[num19].playerName, -1);
						MP.ReadStringPlus(3, this.MapLineTable[num19].allianceTag, -1);
						this.MapLineTable[num19].kingdomID = MP.ReadUShort(-1);
						this.MapLineTable[num19].start.zoneID = MP.ReadUShort(-1);
						this.MapLineTable[num19].start.pointID = MP.ReadByte(-1);
						this.MapLineTable[num19].end.zoneID = MP.ReadUShort(-1);
						this.MapLineTable[num19].end.pointID = MP.ReadByte(-1);
						this.MapLineTable[num19].begin = MP.ReadULong(-1);
						this.MapLineTable[num19].during = MP.ReadUInt(-1);
						this.MapLineTable[num19].EXbegin = MP.ReadUInt(-1);
						this.MapLineTable[num19].EXduring = MP.ReadUInt(-1);
						this.MapLineTable[num19].lineFlag = MP.ReadByte(-1);
						byte b6 = MP.ReadByte(-1);
						ushort num20 = MP.ReadUShort(-1);
						if (this.MapLineTable[num19].lineObject != null)
						{
							if ((this.MapLineTable[num19].baseFlag & 1) != (b6 & 1) || num20 != this.MapLineTable[num19].emojiID)
							{
								this.MapLineTable[num19].baseFlag = b6;
								this.MapLineTable[num19].emojiID = num20;
								this.LineNotifyObserver(61, num19, 1, 0);
							}
							if ((this.MapLineTable[num19].baseFlag & 2) != (b6 & 2))
							{
								this.MapLineTable[num19].baseFlag = b6;
								this.MapLineTable[num19].emojiID = num20;
								this.LineNotifyObserver(62, num19, 1, 0);
							}
						}
						else
						{
							this.MapLineTable[num19].baseFlag = b6;
							this.MapLineTable[num19].emojiID = num20;
						}
						double num21 = Math.Round(640000000000.0);
						for (int num22 = 0; num22 < (int)this.UpdateZoneIDNum; num22++)
						{
							if (num19 != this.getLineTableID(this.UpdateZoneID[num22], lineID))
							{
								bool flag = this.MapLineTable[num19].start.zoneID == this.UpdateZoneID[num22] || this.MapLineTable[num19].end.zoneID == this.UpdateZoneID[num22];
								if (!flag)
								{
									Vector2 tileMapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(this.UpdateZoneID[num22], 0);
									tileMapPosbyPointCode.x *= 2f;
									if (tileMapPosbyPointCode.x < this.MapLineTable[num19].zoneMax.x && tileMapPosbyPointCode.x >= this.MapLineTable[num19].zoneMin.x && tileMapPosbyPointCode.y < this.MapLineTable[num19].zoneMax.y && tileMapPosbyPointCode.y >= this.MapLineTable[num19].zoneMin.y)
									{
										if (this.MapLineTable[num19].XIntercept < 0.0)
										{
											if (this.MapLineTable[num19].Slope == 0.0)
											{
												flag = (this.MapLineTable[num19].YIntercept >= (double)tileMapPosbyPointCode.y && this.MapLineTable[num19].YIntercept < (double)(tileMapPosbyPointCode.y + 16f));
											}
											else
											{
												double num23 = this.MapLineTable[num19].Slope * (double)tileMapPosbyPointCode.x + this.MapLineTable[num19].YIntercept;
												num23 = Math.Round(num23 * 10000000000.0);
												double num24 = this.MapLineTable[num19].Slope * (double)(tileMapPosbyPointCode.x + 64f) + this.MapLineTable[num19].YIntercept;
												num24 = Math.Round(num24 * 10000000000.0);
												double num25 = ((double)tileMapPosbyPointCode.y - this.MapLineTable[num19].YIntercept) / this.MapLineTable[num19].Slope;
												num25 = Math.Round(num25 * 10000000000.0);
												double num26 = ((double)(tileMapPosbyPointCode.y + 16f) - this.MapLineTable[num19].YIntercept) / this.MapLineTable[num19].Slope;
												num26 = Math.Round(num26 * 10000000000.0);
												double num27 = Math.Round((double)(tileMapPosbyPointCode.y * 1E+10f));
												double num28 = Math.Round((double)(tileMapPosbyPointCode.x * 1E+10f));
												double num29 = Math.Round(160000000000.0);
												flag = ((num23 >= num27 && num23 < num27 + num29) || (num24 > num27 && num24 < num27 + num29) || (num25 >= num28 && num25 < num28 + num21) || (num26 > num28 && num26 < num28 + num21) || (num24 == num27 && num24 + num29 == num23 && num26 == num28 && num26 + num21 == num25));
											}
										}
										else
										{
											flag = (this.MapLineTable[num19].XIntercept >= (double)tileMapPosbyPointCode.x && this.MapLineTable[num19].XIntercept < (double)(tileMapPosbyPointCode.x + 64f));
										}
									}
								}
								if (flag)
								{
									int zoneState = (int)this.ZoneUpdateInfo[(int)this.UpdateZoneID[num22]].zoneState;
									if (this.MapLineTable[num19].ZoneIDTable[zoneState] == 1048576)
									{
										this.MapLineTable[num19].ZoneIDTable[zoneState] = this.ZoneLineIDTable[zoneState].Count;
										MapLine mapLine = this.MapLineTable[num19];
										mapLine.zoneNum += 1;
										ZoneLine item;
										item.lineID = this.MapLineTable[num19].lineID;
										item.lineTableID = (ushort)num19;
										this.ZoneLineIDTable[zoneState].Add(item);
									}
								}
							}
						}
					}
					for (int num30 = (int)(this.MapLineSize - 52); num30 > 0; num30--)
					{
						MP.ReadByte(-1);
					}
				}
				if (map_UPDATE_KIND == MAP_UPDATE_KIND.MAPUPDATE_END)
				{
					for (int num31 = 0; num31 < (int)this.UpdateZoneIDNum; num31++)
					{
						this.ZoneNotifyObserver(this.UpdateZoneID[num31]);
					}
					this.UpdateZoneIDNum = 0;
				}
			}
			else
			{
				ulong updateNum = MP.ReadULong(-1);
				switch (map_UPDATE_KIND)
				{
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_ADD:
				{
					short num32 = MP.ReadShort(-1);
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					byte pointID2 = MP.ReadByte(-1);
					uint num33 = 0u;
					num32 -= 3;
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						bool flag2 = true;
						byte pointKind = MP.ReadByte(-1);
						num32 -= 1;
						uint num34 = (uint)GameConstants.PointCodeToMapID(num8, pointID2);
						if (this.IsCityOrCamp(num34))
						{
							this.PlayerPointTableIDpool.despawn((int)this.LayoutMapInfo[(int)((UIntPtr)num34)].tableID);
						}
						else if (this.IsResources(num34))
						{
							this.ResourcesPointTableIDpool.despawn((int)this.LayoutMapInfo[(int)((UIntPtr)num34)].tableID);
						}
						else if (this.LayoutMapInfo[(int)((UIntPtr)num34)].pointKind == 10)
						{
							ushort num35 = this.LayoutMapInfo[(int)((UIntPtr)num34)].tableID;
							if ((this.NPCPointTable[(int)num35].baseFlag & 4) == 0)
							{
								if (this.NPCPointTable[(int)num35].NPCAllianceTag != null && this.NPCPointTable[(int)num35].NPCAllianceTag[0] != '\0')
								{
									num33 = this.NPCPointTable[(int)num35].Key;
								}
								else
								{
									num33 = this.NPCPointTable[(int)num35].Key - 1u;
								}
							}
							this.NPCPointTableIDpool.despawn((int)this.LayoutMapInfo[(int)((UIntPtr)num34)].tableID);
						}
						this.LayoutMapInfo[(int)((UIntPtr)num34)].pointKind = pointKind;
						if (this.LayoutMapInfo[(int)((UIntPtr)num34)].pointKind == 12)
						{
							this.LayoutMapInfo[(int)((UIntPtr)num34)].tableID = (ushort)MP.ReadByte(-1);
							for (int num36 = (int)(num32 - 1); num36 > 0; num36--)
							{
								MP.ReadByte(-1);
							}
						}
						else if (this.IsCityOrCamp(num34))
						{
							ushort num35 = this.LayoutMapInfo[(int)((UIntPtr)num34)].tableID = (ushort)this.PlayerPointTableIDpool.spawn();
							MP.ReadStringPlus(13, this.PlayerPointTable[(int)num35].playerName, -1);
							MP.ReadStringPlus(3, this.PlayerPointTable[(int)num35].allianceTag, -1);
							this.PlayerPointTable[(int)num35].kingdomID = MP.ReadUShort(-1);
							this.PlayerPointTable[(int)num35].level = MP.ReadByte(-1);
							this.PlayerPointTable[(int)num35].capitalFlag = MP.ReadByte(-1);
							this.PlayerPointTable[(int)num35].kingdomTitle = (KINGDOM_DESIGNATION)MP.ReadByte(-1);
							this.PlayerPointTable[(int)num35].worldTitle = (WORLD_PLAYER_DESIGNATION)MP.ReadByte(-1);
							this.PlayerPointTable[(int)num35].allianceKingdomID = MP.ReadUShort(-1);
							this.PlayerPointTable[(int)num35].cityProperty = (CITY_PROPERTY)MP.ReadByte(-1);
							this.PlayerPointTable[(int)num35].cityOutward = (CITY_OUTWARD)MP.ReadByte(-1);
							this.PlayerPointTable[(int)num35].cityOutwardLevel = MP.ReadByte(-1);
							this.PlayerPointTable[(int)num35].nobilityTitle = MP.ReadByte(-1);
							for (int num37 = 0; num37 < this.PlayerPointTable[(int)num35].cityAttribute.Length; num37++)
							{
								this.PlayerPointTable[(int)num35].cityAttribute[num37] = MP.ReadByte(-1);
							}
							for (int num38 = (int)(num32 - 34 - 3); num38 > 0; num38--)
							{
								MP.ReadByte(-1);
							}
							this.PlayerPointTable[(int)num35].baseFlag = MP.ReadByte(-1);
							this.PlayerPointTable[(int)num35].emojiID = MP.ReadUShort(-1);
						}
						else if (this.LayoutMapInfo[(int)((UIntPtr)num34)].pointKind == 10)
						{
							ushort num35 = this.LayoutMapInfo[(int)((UIntPtr)num34)].tableID = (ushort)this.NPCPointTableIDpool.spawn();
							this.NPCPointTable[(int)num35].level = MP.ReadByte(-1);
							this.NPCPointTable[(int)num35].NPCNum = MP.ReadUShort(-1);
							if (this.NPCPointTable[(int)num35].NPCNum < 2 || (int)this.NPCPointTable[(int)num35].NPCNum >= this.MapMonsterTable.TableCount)
							{
								this.NPCPointTable[(int)num35].NPCNum = 2;
							}
							this.NPCPointTable[(int)num35].Key = MP.ReadUInt(-1);
							this.NPCPointTable[(int)num35].Blood = MP.ReadFloat(-1);
							MP.ReadStringPlus(3, this.NPCPointTable[(int)num35].NPCAllianceTag, -1);
							this.NPCPointTable[(int)num35].endTime = MP.ReadULong(-1);
							for (int num39 = (int)(num32 - 22 - 3); num39 > 0; num39--)
							{
								MP.ReadByte(-1);
							}
							this.NPCPointTable[(int)num35].baseFlag = MP.ReadByte(-1);
							this.NPCPointTable[(int)num35].emojiID = MP.ReadUShort(-1);
							flag2 = ((this.NPCPointTable[(int)num35].baseFlag & 4) > 0);
							if (!flag2 && this.NPCPointTable[(int)num35].NPCAllianceTag != null && this.NPCPointTable[(int)num35].NPCAllianceTag[0] != '\0')
							{
								flag2 = (num33 == this.NPCPointTable[(int)num35].Key);
							}
						}
						else if (this.LayoutMapInfo[(int)((UIntPtr)num34)].pointKind == 11)
						{
							ushort num35 = this.LayoutMapInfo[(int)((UIntPtr)num34)].tableID = (ushort)MP.ReadByte(-1);
							this.YolkPointTable[(int)num35].WonderID = (byte)num35;
							this.YolkPointTable[(int)num35].WonderState = MP.ReadByte(-1);
							this.YolkPointTable[(int)num35].StateBegin = MP.ReadULong(-1);
							this.YolkPointTable[(int)num35].StateDuring = MP.ReadUInt(-1);
							this.YolkPointTable[(int)num35].OwnerEmblem = MP.ReadUShort(-1);
							MP.ReadStringPlus(13, this.YolkPointTable[(int)num35].WonderLeader, -1);
							MP.ReadStringPlus(3, this.YolkPointTable[(int)num35].WonderAllianceTag, -1);
							this.YolkPointTable[(int)num35].LeaderKingdomID = MP.ReadUShort(-1);
							this.YolkPointTable[(int)num35].WonderFlag = MP.ReadByte(-1);
							this.YolkPointTable[(int)num35].AllianceKingdomID = MP.ReadUShort(-1);
							this.YolkPointTable[(int)num35].LeaderHomeKingdomID = MP.ReadUShort(-1);
							for (int num40 = (int)(num32 - 39 - 3); num40 > 0; num40--)
							{
								MP.ReadByte(-1);
							}
							this.YolkPointTable[(int)num35].baseFlag = MP.ReadByte(-1);
							this.YolkPointTable[(int)num35].emojiID = MP.ReadUShort(-1);
							if (!this.CheckYolk(num35, this.FocusKingdomID))
							{
								this.LayoutMapInfo[(int)((UIntPtr)num34)].pointKind = 0;
							}
							else
							{
								DataManager.msgBuffer[0] = 94;
								GameConstants.GetBytes(num35, DataManager.msgBuffer, 1);
								GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
							}
						}
						else if (this.IsResources(num34))
						{
							ushort num35 = this.LayoutMapInfo[(int)((UIntPtr)num34)].tableID = (ushort)this.ResourcesPointTableIDpool.spawn();
							MP.ReadStringPlus(13, this.ResourcesPointTable[(int)num35].playerName, -1);
							MP.ReadStringPlus(3, this.ResourcesPointTable[(int)num35].allianceTag, -1);
							this.ResourcesPointTable[(int)num35].kingdomID = MP.ReadUShort(-1);
							this.ResourcesPointTable[(int)num35].level = MP.ReadByte(-1);
							this.ResourcesPointTable[(int)num35].count = MP.ReadUInt(-1);
							this.ResourcesPointTable[(int)num35].rate = MP.ReadFloat(-1);
							this.ResourcesPointTable[(int)num35].time = MP.ReadULong(-1);
							for (int num41 = (int)(num32 - 35 - 3); num41 > 0; num41--)
							{
								MP.ReadByte(-1);
							}
							this.ResourcesPointTable[(int)num35].baseFlag = MP.ReadByte(-1);
							this.ResourcesPointTable[(int)num35].emojiID = MP.ReadUShort(-1);
						}
						else
						{
							for (int num42 = (int)num32; num42 > 0; num42--)
							{
								MP.ReadByte(-1);
							}
						}
						if (flag2)
						{
							this.PointNotifyObserver(num34);
						}
						else
						{
							DataManager.msgBuffer[0] = 87;
							GameConstants.GetBytes(num34, DataManager.msgBuffer, 1);
							GameConstants.GetBytes(-2f, DataManager.msgBuffer, 5);
							GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						}
					}
					else
					{
						for (int num43 = (int)num32; num43 > 0; num43--)
						{
							MP.ReadByte(-1);
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_DEL:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					byte pointID3 = MP.ReadByte(-1);
					if (this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					}
					uint num44 = (uint)GameConstants.PointCodeToMapID(num8, pointID3);
					if (this.LayoutMapInfo[(int)((UIntPtr)num44)].pointKind > 0)
					{
						bool flag3 = true;
						if (this.IsCityOrCamp(num44))
						{
							this.PlayerPointTableIDpool.despawn((int)this.LayoutMapInfo[(int)((UIntPtr)num44)].tableID);
						}
						else if (this.IsResources(num44))
						{
							this.ResourcesPointTableIDpool.despawn((int)this.LayoutMapInfo[(int)((UIntPtr)num44)].tableID);
						}
						else if (this.LayoutMapInfo[(int)((UIntPtr)num44)].pointKind == 10)
						{
							CHAOS chaos = GameManager.ActiveGameplay as CHAOS;
							if (chaos == null || (this.NPCPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num44)].tableID].baseFlag & 4) > 0)
							{
								this.NPCPointTableIDpool.despawn((int)this.LayoutMapInfo[(int)((UIntPtr)num44)].tableID);
							}
							else
							{
								flag3 = false;
								DataManager.msgBuffer[0] = 87;
								GameConstants.GetBytes(num44, DataManager.msgBuffer, 1);
								GameConstants.GetBytes(-1f, DataManager.msgBuffer, 5);
								GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
							}
						}
						if (flag3)
						{
							this.LayoutMapInfo[(int)((UIntPtr)num44)].pointKind = 0;
							this.PointNotifyObserver(num44);
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_RESOURCE:
				{
					short num45 = MP.ReadShort(-1);
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID4 = MP.ReadByte(-1);
					num45 -= 3;
					uint num46 = (uint)GameConstants.PointCodeToMapID(num8, pointID4);
					if (this.IsResources(num46) && this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						ushort tableID = this.LayoutMapInfo[(int)((UIntPtr)num46)].tableID;
						MP.ReadStringPlus(13, this.ResourcesPointTable[(int)tableID].playerName, -1);
						MP.ReadStringPlus(3, this.ResourcesPointTable[(int)tableID].allianceTag, -1);
						this.ResourcesPointTable[(int)tableID].kingdomID = MP.ReadUShort(-1);
						this.ResourcesPointTable[(int)tableID].count = MP.ReadUInt(-1);
						this.ResourcesPointTable[(int)tableID].rate = MP.ReadFloat(-1);
						this.ResourcesPointTable[(int)tableID].time = MP.ReadULong(-1);
						for (int num47 = (int)(num45 - 34); num47 > 0; num47--)
						{
							MP.ReadByte(-1);
						}
						this.PointNotifyObserver(num46);
					}
					else
					{
						for (int num48 = (int)num45; num48 > 0; num48--)
						{
							MP.ReadByte(-1);
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_RESOURCE_OWNER_NAME:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID5 = MP.ReadByte(-1);
					uint num49 = (uint)GameConstants.PointCodeToMapID(num8, pointID5);
					if (this.IsResources(num49) && this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						MP.ReadStringPlus(13, this.ResourcesPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num49)].tableID].playerName, -1);
						this.PointNotifyObserver(num49);
					}
					else
					{
						for (int num50 = 0; num50 < 13; num50++)
						{
							MP.ReadByte(-1);
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_RESOURCE_OWNER_TAG:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID6 = MP.ReadByte(-1);
					uint num51 = (uint)GameConstants.PointCodeToMapID(num8, pointID6);
					if (this.IsResources(num51) && this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						MP.ReadStringPlus(3, this.ResourcesPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num51)].tableID].allianceTag, -1);
						this.ZoneNotifyObserver(1024);
					}
					else
					{
						for (int num52 = 0; num52 < 3; num52++)
						{
							MP.ReadByte(-1);
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_NAME:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID7 = MP.ReadByte(-1);
					uint num53 = (uint)GameConstants.PointCodeToMapID(num8, pointID7);
					if (this.IsCityOrCamp(num53) && this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						MP.ReadStringPlus(13, this.PlayerPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num53)].tableID].playerName, -1);
						this.PointNotifyObserver(num53);
					}
					else
					{
						for (int num54 = 0; num54 < 13; num54++)
						{
							MP.ReadByte(-1);
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_TAG:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID8 = MP.ReadByte(-1);
					uint num55 = (uint)GameConstants.PointCodeToMapID(num8, pointID8);
					if (this.IsCityOrCamp(num55) && this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						MP.ReadStringPlus(3, this.PlayerPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num55)].tableID].allianceTag, -1);
						if ((ulong)num55 == (ulong)((long)DataManager.Instance.RoleAttr.CapitalPoint))
						{
							DataManager.Instance.RoleAlliance.Tag.ClearString();
							DataManager.Instance.RoleAlliance.Tag.Append(this.PlayerPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num55)].tableID].allianceTag);
							if (DataManager.Instance.RoleAlliance.Tag.Length == 0)
							{
								DataManager.Instance.RoleAlliance.Id = 0u;
								DataManager.Instance.RoleAlliance.KingdomID = 0;
							}
						}
						this.ZoneNotifyObserver(1024);
					}
					else
					{
						for (int num56 = 0; num56 < 3; num56++)
						{
							MP.ReadByte(-1);
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_LEVEL:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID9 = MP.ReadByte(-1);
					uint num57 = (uint)GameConstants.PointCodeToMapID(num8, pointID9);
					if (this.IsCityOrCamp(num57) && this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						this.PlayerPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num57)].tableID].level = MP.ReadByte(-1);
						this.PointNotifyObserver(num57);
					}
					else
					{
						MP.ReadByte(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_CAPITALFLAG:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID10 = MP.ReadByte(-1);
					uint num58 = (uint)GameConstants.PointCodeToMapID(num8, pointID10);
					if (this.IsCityOrCamp(num58) && this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						this.PlayerPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num58)].tableID].capitalFlag = MP.ReadByte(-1);
						this.PointNotifyObserver(num58);
					}
					else
					{
						MP.ReadByte(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_KTITLE:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID11 = MP.ReadByte(-1);
					uint num59 = (uint)GameConstants.PointCodeToMapID(num8, pointID11);
					if (this.IsCityOrCamp(num59) && this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						this.PlayerPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num59)].tableID].kingdomTitle = (KINGDOM_DESIGNATION)MP.ReadByte(-1);
						this.PointNotifyObserver(num59);
					}
					else
					{
						MP.ReadByte(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_WTITLE:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID12 = MP.ReadByte(-1);
					uint num60 = (uint)GameConstants.PointCodeToMapID(num8, pointID12);
					if (this.IsCityOrCamp(num60) && this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						this.PlayerPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num60)].tableID].worldTitle = (WORLD_PLAYER_DESIGNATION)MP.ReadByte(-1);
						this.PointNotifyObserver(num60);
					}
					else
					{
						MP.ReadByte(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_ADVANCE:
				{
					short num61 = MP.ReadShort(-1);
					ushort num8 = MP.ReadUShort(-1);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID13 = MP.ReadByte(-1);
					num61 -= 3;
					uint num62 = (uint)GameConstants.PointCodeToMapID(num8, pointID13);
					if (this.IsCityOrCamp(num62) && this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						int tableID2 = (int)this.LayoutMapInfo[(int)((UIntPtr)num62)].tableID;
						MP.ReadStringPlus(20, this.PlayerPointTable[tableID2].allianceName, -1);
						this.PlayerPointTable[tableID2].VIP = MP.ReadByte(-1);
						this.PlayerPointTable[tableID2].allianceRank = MP.ReadByte(-1);
						this.PlayerPointTable[tableID2].portraitID = MP.ReadUShort(-1);
						this.PlayerPointTable[tableID2].bounty = MP.ReadUInt(-1);
						this.PlayerPointTable[tableID2].power = MP.ReadULong(-1);
						this.PlayerPointTable[tableID2].kill = MP.ReadULong(-1);
						for (int num63 = (int)(num61 - 44); num63 > 0; num63--)
						{
							MP.ReadByte(-1);
						}
						DataManager.msgBuffer[0] = 79;
						GameConstants.GetBytes(num62, DataManager.msgBuffer, 1);
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					}
					else if (this.LayoutMapInfo[(int)((UIntPtr)num62)].pointKind == 11 && this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						int tableID3 = (int)this.LayoutMapInfo[(int)((UIntPtr)num62)].tableID;
						MP.ReadStringPlus(20, this.YolkPointTable[tableID3].OwnerAllianceName, -1);
						this.YolkPointTable[tableID3].LeaderHead = MP.ReadUShort(-1);
						this.YolkPointTable[tableID3].LeaderPos.zoneID = MP.ReadUShort(-1);
						this.YolkPointTable[tableID3].LeaderPos.pointID = MP.ReadByte(-1);
						MP.ReadStringPlus(13, this.YolkPointTable[tableID3].OwnerName, -1);
						for (int num64 = (int)(num61 - 38); num64 > 0; num64--)
						{
							MP.ReadByte(-1);
						}
						DataManager.msgBuffer[0] = 79;
						GameConstants.GetBytes(num62, DataManager.msgBuffer, 1);
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					}
					else
					{
						for (int num65 = (int)num61; num65 > 0; num65--)
						{
							MP.ReadByte(-1);
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_NPC_BLOOD:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID14 = MP.ReadByte(-1);
					uint num66 = (uint)GameConstants.PointCodeToMapID(num8, pointID14);
					if (this.LayoutMapInfo[(int)((UIntPtr)num66)].pointKind == 10 && this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						float num67 = MP.ReadFloat(-1);
						if (!(GameManager.ActiveGameplay is CHAOS))
						{
							this.NPCPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num66)].tableID].Blood = num67;
						}
						else
						{
							DataManager.msgBuffer[0] = 87;
							GameConstants.GetBytes(num66, DataManager.msgBuffer, 1);
							GameConstants.GetBytes(num67, DataManager.msgBuffer, 5);
							GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						}
					}
					else
					{
						MP.ReadFloat(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_LINE_ADD:
				{
					short num68 = MP.ReadShort(-1);
					ushort num8 = MP.ReadUShort(-1);
					num68 -= 2;
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					uint lineID2 = MP.ReadUInt(-1);
					int num69 = this.getLineTableID(num8, lineID2);
					if (num69 == 1048576)
					{
						num69 = this.MapLineTableIDpool.spawn();
						while (num69 >= this.MapLineTable.Count)
						{
							this.MapLineTable.Add(new MapLine());
						}
						this.MapLineTable[num69].lineID = lineID2;
						MP.ReadStringPlus(13, this.MapLineTable[num69].playerName, -1);
						MP.ReadStringPlus(3, this.MapLineTable[num69].allianceTag, -1);
						this.MapLineTable[num69].kingdomID = MP.ReadUShort(-1);
						this.MapLineTable[num69].start.zoneID = MP.ReadUShort(-1);
						this.MapLineTable[num69].start.pointID = MP.ReadByte(-1);
						this.MapLineTable[num69].end.zoneID = MP.ReadUShort(-1);
						this.MapLineTable[num69].end.pointID = MP.ReadByte(-1);
						this.MapLineTable[num69].begin = MP.ReadULong(-1);
						this.MapLineTable[num69].during = MP.ReadUInt(-1);
						this.MapLineTable[num69].EXbegin = MP.ReadUInt(-1);
						this.MapLineTable[num69].EXduring = MP.ReadUInt(-1);
						this.MapLineTable[num69].lineFlag = MP.ReadByte(-1);
						this.MapLineTable[num69].baseFlag = MP.ReadByte(-1);
						this.MapLineTable[num69].emojiID = MP.ReadUShort(-1);
						this.addLine(num69);
					}
					else
					{
						this.MapLineTable[num69].lineID = lineID2;
						MP.ReadStringPlus(13, this.MapLineTable[num69].playerName, -1);
						MP.ReadStringPlus(3, this.MapLineTable[num69].allianceTag, -1);
						this.MapLineTable[num69].kingdomID = MP.ReadUShort(-1);
						this.MapLineTable[num69].start.zoneID = MP.ReadUShort(-1);
						this.MapLineTable[num69].start.pointID = MP.ReadByte(-1);
						this.MapLineTable[num69].end.zoneID = MP.ReadUShort(-1);
						this.MapLineTable[num69].end.pointID = MP.ReadByte(-1);
						this.MapLineTable[num69].begin = MP.ReadULong(-1);
						this.MapLineTable[num69].during = MP.ReadUInt(-1);
						this.MapLineTable[num69].EXbegin = MP.ReadUInt(-1);
						this.MapLineTable[num69].EXduring = MP.ReadUInt(-1);
						this.MapLineTable[num69].lineFlag = MP.ReadByte(-1);
						byte b7 = MP.ReadByte(-1);
						ushort num70 = MP.ReadUShort(-1);
						if (this.MapLineTable[num69].lineObject == null)
						{
							this.LineNotifyObserver(56, num69, 1, 0);
						}
						else
						{
							if ((this.MapLineTable[num69].baseFlag & 1) != (b7 & 1) || num70 != this.MapLineTable[num69].emojiID)
							{
								this.MapLineTable[num69].baseFlag = b7;
								this.MapLineTable[num69].emojiID = num70;
								this.LineNotifyObserver(61, num69, 1, 0);
							}
							if ((this.MapLineTable[num69].baseFlag & 2) != (b7 & 2))
							{
								this.MapLineTable[num69].baseFlag = b7;
								this.LineNotifyObserver(62, num69, 1, 0);
							}
						}
					}
					if ((this.MapLineTable[num69].baseFlag & 4) > 0)
					{
						if (DataManager.CompareStr(this.MapLineTable[num69].playerName, DataManager.Instance.RoleAttr.Name) == 0)
						{
							if (this.MyFocusBallLineTableID == -2)
							{
								this.MyFocusBallLineTableID = num69;
								DataManager.msgBuffer[0] = 108;
								GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
							}
							else
							{
								this.MyFocusBallLineTableID = num69;
							}
						}
						int num71 = GameConstants.PointCodeToMapID(this.MapLineTable[num69].start.zoneID, this.MapLineTable[num69].start.pointID);
						if (num71 == FootballManager.Instance.mFootBallMapID)
						{
							FootballManager.Instance.CheckFootBallIDHitClose(1);
						}
					}
					for (int num72 = (int)(num68 - 52); num72 > 0; num72--)
					{
						MP.ReadByte(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_LINE_DEL:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					uint num73 = MP.ReadUInt(-1);
					int lineTableID = this.getLineTableID(num8, num73);
					if (lineTableID < 1048576 && num73 == this.MapLineTable[lineTableID].lineID)
					{
						this.delLine(lineTableID, 1, 0);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_LINE_OWNER_NAME:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					uint num74 = MP.ReadUInt(-1);
					int lineTableID2 = this.getLineTableID(num8, num74);
					if (lineTableID2 < 1048576 && num74 == this.MapLineTable[lineTableID2].lineID && this.MapLineTable[lineTableID2].lineObject != null)
					{
						MP.ReadStringPlus(13, this.MapLineTable[lineTableID2].playerName, -1);
						this.LineNotifyObserver(57, lineTableID2, 1, 0);
					}
					else
					{
						for (int num75 = 0; num75 < 13; num75++)
						{
							MP.ReadByte(-1);
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_LINE_OWNER_TAG:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					uint num76 = MP.ReadUInt(-1);
					int lineTableID3 = this.getLineTableID(num8, num76);
					if (lineTableID3 < 1048576 && num76 == this.MapLineTable[lineTableID3].lineID && this.MapLineTable[lineTableID3].lineObject != null)
					{
						MP.ReadStringPlus(3, this.MapLineTable[lineTableID3].allianceTag, -1);
						this.LineNotifyObserver(58, lineTableID3, 1, 0);
					}
					else
					{
						for (int num77 = 0; num77 < 3; num77++)
						{
							MP.ReadByte(-1);
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_LINE_BEGIN:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					uint num78 = MP.ReadUInt(-1);
					int lineTableID4 = this.getLineTableID(num8, num78);
					if (lineTableID4 < 1048576 && num78 == this.MapLineTable[lineTableID4].lineID && this.MapLineTable[lineTableID4].lineObject != null)
					{
						this.MapLineTable[lineTableID4].begin = MP.ReadULong(-1);
						this.MapLineTable[lineTableID4].EXbegin = MP.ReadUInt(-1);
						this.MapLineTable[lineTableID4].EXduring = MP.ReadUInt(-1);
						this.LineNotifyObserver(60, lineTableID4, 1, 0);
					}
					else
					{
						MP.ReadULong(-1);
						MP.ReadULong(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_FLAG:
				{
					ushort num8 = MP.ReadUShort(-1);
					KingdomMap recordByKey2 = this.KingdomMapTable.GetRecordByKey(num8);
					int num79 = (int)(this.WorldMaxX - this.WorldMinX + 1);
					int num80 = (int)(recordByKey2.worldPosX - this.WorldMinX) + (int)(recordByKey2.worldPosY - this.WorldMinY) * num79;
					byte tableID4 = this.TileMapKingdomID[num80].tableID;
					if (this.TileMapKingdomID[num80].KingdomID == num8 && this.WorldKingdomTable[(int)tableID4].kingdomID == num8)
					{
						byte b8 = (byte)(this.WorldKingdomTable[(int)tableID4].kingdomFlag >> 3);
						this.WorldKingdomTable[(int)tableID4].kingdomFlag = MP.ReadByte(-1);
						if (b8 > 0 && this.WorldKingdomTable[(int)tableID4].kingdomFlag >> 3 == 0 && DataManager.Instance.RoleAttr.WorldTitle_Personal == 1)
						{
							DataManager.Instance.RoleAttr.WorldTitle_Personal = 0;
						}
						this.KingdomNotifyObserver(tableID4, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_FLAG);
					}
					else
					{
						MP.ReadByte(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_PERIOD:
				{
					ushort num8 = MP.ReadUShort(-1);
					KingdomMap recordByKey3 = this.KingdomMapTable.GetRecordByKey(num8);
					int num81 = (int)(this.WorldMaxX - this.WorldMinX + 1);
					int num82 = (int)(recordByKey3.worldPosX - this.WorldMinX) + (int)(recordByKey3.worldPosY - this.WorldMinY) * num81;
					byte tableID5 = this.TileMapKingdomID[num82].tableID;
					if (this.TileMapKingdomID[num82].KingdomID == num8 && this.WorldKingdomTable[(int)tableID5].kingdomID == num8)
					{
						this.WorldKingdomTable[(int)tableID5].kingdomPeriod = (KINGDOM_PERIOD)MP.ReadByte(-1);
						this.KingdomNotifyObserver(tableID5, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_PERIOD);
					}
					else
					{
						MP.ReadByte(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_ALLIANCE:
				{
					ushort num8 = MP.ReadUShort(-1);
					KingdomMap recordByKey4 = this.KingdomMapTable.GetRecordByKey(num8);
					int num83 = (int)(this.WorldMaxX - this.WorldMinX + 1);
					int num84 = (int)(recordByKey4.worldPosX - this.WorldMinX) + (int)(recordByKey4.worldPosY - this.WorldMinY) * num83;
					byte tableID6 = this.TileMapKingdomID[num84].tableID;
					if (this.TileMapKingdomID[num84].KingdomID == num8 && this.WorldKingdomTable[(int)tableID6].kingdomID == num8)
					{
						this.WorldKingdomTable[(int)tableID6].kingName.ClearString();
						MP.ReadStringPlus(13, this.WorldKingdomTable[(int)tableID6].kingName, -1);
						this.WorldKingdomTable[(int)tableID6].allianceTag.ClearString();
						MP.ReadStringPlus(3, this.WorldKingdomTable[(int)tableID6].allianceTag, -1);
						this.WorldKingdomTable[(int)tableID6].allianceName.ClearString();
						MP.ReadStringPlus(20, this.WorldKingdomTable[(int)tableID6].allianceName, -1);
						this.KingdomNotifyObserver(tableID6, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_ALLIANCE);
					}
					else
					{
						int num85 = 36;
						byte b9 = 0;
						while ((int)b9 < num85)
						{
							MP.ReadByte(-1);
							b9 += 1;
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_STATE:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID15 = MP.ReadByte(-1);
					uint num86 = (uint)GameConstants.PointCodeToMapID(num8, pointID15);
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						ushort tableID7 = this.LayoutMapInfo[(int)((UIntPtr)num86)].tableID;
						if ((int)tableID7 < this.YolkPointTable.Length)
						{
							byte wonderState = this.YolkPointTable[(int)tableID7].WonderState;
							this.YolkPointTable[(int)tableID7].WonderState = MP.ReadByte(-1);
							this.YolkPointTable[(int)tableID7].StateBegin = MP.ReadULong(-1);
							this.YolkPointTable[(int)tableID7].StateDuring = MP.ReadUInt(-1);
							if (this.YolkPointTable[(int)tableID7].WonderState == 2 || (wonderState == 0 && this.YolkPointTable[(int)tableID7].WonderState == 1))
							{
								this.YolkPointTable[(int)tableID7].WonderAllianceTag.ClearString();
								this.YolkPointTable[(int)tableID7].OwnerEmblem = ushort.MaxValue;
								this.YolkPointTable[(int)tableID7].OwnerAllianceName.ClearString();
								this.YolkPointTable[(int)tableID7].WonderLeader.ClearString();
								this.YolkPointTable[(int)tableID7].LeaderKingdomID = (this.YolkPointTable[(int)tableID7].AllianceKingdomID = (this.YolkPointTable[(int)tableID7].LeaderHomeKingdomID = 0));
								this.YolkPointTable[(int)tableID7].LeaderPos.zoneID = 0;
								this.YolkPointTable[(int)tableID7].LeaderPos.pointID = 0;
								this.YolkPointTable[(int)tableID7].LeaderHead = 0;
								this.YolkPointTable[(int)tableID7].OwnerName.ClearString();
								DataManager.msgBuffer[0] = 94;
								GameConstants.GetBytes(tableID7, DataManager.msgBuffer, 1);
								GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
							}
							else if (this.YolkPointTable[(int)tableID7].WonderState == 0)
							{
								DataManager.msgBuffer[0] = 95;
								GameConstants.GetBytes(tableID7, DataManager.msgBuffer, 1);
								GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
							}
							this.PointNotifyObserver(num86);
						}
						else
						{
							for (int num87 = 13; num87 > 0; num87--)
							{
								MP.ReadByte(-1);
							}
						}
					}
					else
					{
						for (int num88 = 13; num88 > 0; num88--)
						{
							MP.ReadByte(-1);
						}
					}
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int)map_UPDATE_KIND, 0);
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_EMBLEM:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID16 = MP.ReadByte(-1);
					uint num89 = (uint)GameConstants.PointCodeToMapID(num8, pointID16);
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						if ((int)this.LayoutMapInfo[(int)((UIntPtr)num89)].tableID < this.YolkPointTable.Length)
						{
							this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num89)].tableID].OwnerEmblem = MP.ReadUShort(-1);
							this.PointNotifyObserver(num89);
						}
						else
						{
							MP.ReadUShort(-1);
						}
					}
					else
					{
						MP.ReadUShort(-1);
					}
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int)map_UPDATE_KIND, 0);
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_LEADER_NAME:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID17 = MP.ReadByte(-1);
					uint num90 = (uint)GameConstants.PointCodeToMapID(num8, pointID17);
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						if ((int)this.LayoutMapInfo[(int)((UIntPtr)num90)].tableID < this.YolkPointTable.Length)
						{
							MP.ReadStringPlus(13, this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num90)].tableID].WonderLeader, -1);
							this.PointNotifyObserver(num90);
						}
						else
						{
							for (int num91 = 0; num91 < 13; num91++)
							{
								MP.ReadByte(-1);
							}
						}
					}
					else
					{
						for (int num92 = 0; num92 < 13; num92++)
						{
							MP.ReadByte(-1);
						}
					}
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int)map_UPDATE_KIND, 0);
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_ALLIANCE_TAG:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID18 = MP.ReadByte(-1);
					uint num93 = (uint)GameConstants.PointCodeToMapID(num8, pointID18);
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						if ((int)this.LayoutMapInfo[(int)((UIntPtr)num93)].tableID < this.YolkPointTable.Length)
						{
							MP.ReadStringPlus(3, this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num93)].tableID].WonderAllianceTag, -1);
							if (this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num93)].tableID].WonderAllianceTag[0] == '\0')
							{
								this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num93)].tableID].WonderAllianceTag.ClearString();
								this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num93)].tableID].OwnerEmblem = ushort.MaxValue;
								this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num93)].tableID].OwnerAllianceName.ClearString();
								if (this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num93)].tableID].LeaderKingdomID == 0)
								{
									this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num93)].tableID].WonderLeader.ClearString();
									this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num93)].tableID].LeaderKingdomID = 0;
									this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num93)].tableID].LeaderPos.zoneID = 0;
									this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num93)].tableID].LeaderPos.pointID = 0;
									this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num93)].tableID].LeaderHead = 0;
									this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num93)].tableID].OwnerName.ClearString();
								}
							}
							this.PointNotifyObserver(num93);
						}
						else
						{
							for (int num94 = 0; num94 < 3; num94++)
							{
								MP.ReadByte(-1);
							}
						}
					}
					else
					{
						for (int num95 = 0; num95 < 3; num95++)
						{
							MP.ReadByte(-1);
						}
					}
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int)map_UPDATE_KIND, 0);
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_LEADER_POS:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID19 = MP.ReadByte(-1);
					uint num96 = (uint)GameConstants.PointCodeToMapID(num8, pointID19);
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						ushort tableID8 = this.LayoutMapInfo[(int)((UIntPtr)num96)].tableID;
						if ((int)tableID8 < this.YolkPointTable.Length)
						{
							this.YolkPointTable[(int)tableID8].LeaderKingdomID = MP.ReadUShort(-1);
							this.YolkPointTable[(int)tableID8].LeaderPos.zoneID = MP.ReadUShort(-1);
							this.YolkPointTable[(int)tableID8].LeaderPos.pointID = MP.ReadByte(-1);
							this.YolkPointTable[(int)tableID8].LeaderHomeKingdomID = MP.ReadUShort(-1);
							this.PointNotifyObserver(num96);
						}
						else
						{
							MP.ReadInt(-1);
							MP.ReadByte(-1);
							MP.ReadUShort(-1);
						}
					}
					else
					{
						MP.ReadInt(-1);
						MP.ReadByte(-1);
						MP.ReadUShort(-1);
					}
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int)map_UPDATE_KIND, 0);
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_ALLIANCE_NAME:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID20 = MP.ReadByte(-1);
					uint num97 = (uint)GameConstants.PointCodeToMapID(num8, pointID20);
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						if ((int)this.LayoutMapInfo[(int)((UIntPtr)num97)].tableID < this.YolkPointTable.Length)
						{
							MP.ReadStringPlus(20, this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num97)].tableID].OwnerAllianceName, -1);
							this.PointNotifyObserver(num97);
						}
						else
						{
							for (int num98 = 0; num98 < 20; num98++)
							{
								MP.ReadByte(-1);
							}
						}
					}
					else
					{
						for (int num99 = 0; num99 < 20; num99++)
						{
							MP.ReadByte(-1);
						}
					}
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int)map_UPDATE_KIND, 0);
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_LEADER_HEAD:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID21 = MP.ReadByte(-1);
					uint num100 = (uint)GameConstants.PointCodeToMapID(num8, pointID21);
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						if ((int)this.LayoutMapInfo[(int)((UIntPtr)num100)].tableID < this.YolkPointTable.Length)
						{
							this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num100)].tableID].LeaderHead = MP.ReadUShort(-1);
							this.PointNotifyObserver(num100);
						}
						else
						{
							MP.ReadUShort(-1);
						}
					}
					else
					{
						MP.ReadUShort(-1);
					}
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int)map_UPDATE_KIND, 0);
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_LEADER:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID22 = MP.ReadByte(-1);
					uint num101 = (uint)GameConstants.PointCodeToMapID(num8, pointID22);
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						ushort tableID9 = this.LayoutMapInfo[(int)((UIntPtr)num101)].tableID;
						if ((int)tableID9 < this.YolkPointTable.Length)
						{
							MP.ReadStringPlus(13, this.YolkPointTable[(int)tableID9].WonderLeader, -1);
							this.YolkPointTable[(int)tableID9].LeaderHead = MP.ReadUShort(-1);
							this.YolkPointTable[(int)tableID9].LeaderKingdomID = MP.ReadUShort(-1);
							this.YolkPointTable[(int)tableID9].LeaderPos.zoneID = MP.ReadUShort(-1);
							this.YolkPointTable[(int)tableID9].LeaderPos.pointID = MP.ReadByte(-1);
							this.YolkPointTable[(int)tableID9].LeaderHomeKingdomID = MP.ReadUShort(-1);
							this.PointNotifyObserver(num101);
						}
						else
						{
							for (int num102 = 0; num102 < 13; num102++)
							{
								MP.ReadByte(-1);
							}
							MP.ReadUShort(-1);
							MP.ReadUShort(-1);
							MP.ReadUShort(-1);
							MP.ReadByte(-1);
							MP.ReadUShort(-1);
						}
					}
					else
					{
						for (int num103 = 0; num103 < 13; num103++)
						{
							MP.ReadByte(-1);
						}
						MP.ReadUShort(-1);
						MP.ReadUShort(-1);
						MP.ReadUShort(-1);
						MP.ReadByte(-1);
						MP.ReadUShort(-1);
					}
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int)map_UPDATE_KIND, 0);
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_OWNER:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID23 = MP.ReadByte(-1);
					uint num104 = (uint)GameConstants.PointCodeToMapID(num8, pointID23);
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						if ((int)this.LayoutMapInfo[(int)((UIntPtr)num104)].tableID < this.YolkPointTable.Length)
						{
							MP.ReadStringPlus(13, this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num104)].tableID].OwnerName, -1);
							MP.ReadStringPlus(3, this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num104)].tableID].WonderAllianceTag, -1);
							MP.ReadStringPlus(20, this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num104)].tableID].OwnerAllianceName, -1);
							this.PointNotifyObserver(num104);
						}
						else
						{
							for (int num105 = 0; num105 < 13; num105++)
							{
								MP.ReadByte(-1);
							}
							for (int num106 = 0; num106 < 3; num106++)
							{
								MP.ReadByte(-1);
							}
							for (int num107 = 0; num107 < 20; num107++)
							{
								MP.ReadByte(-1);
							}
						}
					}
					else
					{
						for (int num108 = 0; num108 < 13; num108++)
						{
							MP.ReadByte(-1);
						}
						for (int num109 = 0; num109 < 3; num109++)
						{
							MP.ReadByte(-1);
						}
						for (int num110 = 0; num110 < 20; num110++)
						{
							MP.ReadByte(-1);
						}
					}
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int)map_UPDATE_KIND, 0);
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_ALLIANCE:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID24 = MP.ReadByte(-1);
					uint num111 = (uint)GameConstants.PointCodeToMapID(num8, pointID24);
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						ushort tableID10 = this.LayoutMapInfo[(int)((UIntPtr)num111)].tableID;
						if ((int)tableID10 < this.YolkPointTable.Length)
						{
							this.YolkPointTable[(int)tableID10].StateBegin = MP.ReadULong(-1);
							this.YolkPointTable[(int)tableID10].StateDuring = MP.ReadUInt(-1);
							this.YolkPointTable[(int)tableID10].OwnerEmblem = MP.ReadUShort(-1);
							MP.ReadStringPlus(13, this.YolkPointTable[(int)tableID10].WonderLeader, -1);
							this.YolkPointTable[(int)tableID10].LeaderHead = MP.ReadUShort(-1);
							this.YolkPointTable[(int)tableID10].LeaderKingdomID = MP.ReadUShort(-1);
							this.YolkPointTable[(int)tableID10].LeaderPos.zoneID = MP.ReadUShort(-1);
							this.YolkPointTable[(int)tableID10].LeaderPos.pointID = MP.ReadByte(-1);
							this.YolkPointTable[(int)tableID10].LeaderHomeKingdomID = MP.ReadUShort(-1);
							this.YolkPointTable[(int)tableID10].AllianceKingdomID = MP.ReadUShort(-1);
							this.PointNotifyObserver(num111);
							if (this.YolkPointTable[(int)tableID10].StateBegin > 0UL)
							{
								DataManager.msgBuffer[0] = 94;
							}
							else
							{
								DataManager.msgBuffer[0] = 95;
							}
							GameConstants.GetBytes(tableID10, DataManager.msgBuffer, 1);
							GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						}
						else
						{
							for (int num112 = 0; num112 < 13; num112++)
							{
								MP.ReadByte(-1);
							}
							MP.ReadULong(-1);
							MP.ReadULong(-1);
							MP.ReadUInt(-1);
							MP.ReadByte(-1);
							MP.ReadUShort(-1);
							MP.ReadUShort(-1);
						}
					}
					else
					{
						for (int num113 = 0; num113 < 13; num113++)
						{
							MP.ReadByte(-1);
						}
						MP.ReadULong(-1);
						MP.ReadULong(-1);
						MP.ReadUInt(-1);
						MP.ReadByte(-1);
						MP.ReadUShort(-1);
						MP.ReadUShort(-1);
					}
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, (int)map_UPDATE_KIND, 0);
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_FLAG:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID25 = MP.ReadByte(-1);
					uint num114 = (uint)GameConstants.PointCodeToMapID(num8, pointID25);
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						if ((int)this.LayoutMapInfo[(int)((UIntPtr)num114)].tableID < this.YolkPointTable.Length)
						{
							this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num114)].tableID].WonderFlag = MP.ReadByte(-1);
							this.PointNotifyObserver(num114);
						}
						else
						{
							MP.ReadByte(-1);
						}
					}
					else
					{
						MP.ReadByte(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_ALLIANCE_KINGDOM:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID26 = MP.ReadByte(-1);
					uint num115 = (uint)GameConstants.PointCodeToMapID(num8, pointID26);
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						if ((int)this.LayoutMapInfo[(int)((UIntPtr)num115)].tableID < this.YolkPointTable.Length)
						{
							this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num115)].tableID].AllianceKingdomID = MP.ReadUShort(-1);
							this.PointNotifyObserver(num115);
						}
						else
						{
							MP.ReadUShort(-1);
						}
					}
					else
					{
						MP.ReadUShort(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_TIME:
				{
					ushort num8 = MP.ReadUShort(-1);
					KingdomMap recordByKey5 = this.KingdomMapTable.GetRecordByKey(num8);
					int num116 = (int)(this.WorldMaxX - this.WorldMinX + 1);
					int num117 = (int)(recordByKey5.worldPosX - this.WorldMinX) + (int)(recordByKey5.worldPosY - this.WorldMinY) * num116;
					byte tableID11 = this.TileMapKingdomID[num117].tableID;
					if (this.TileMapKingdomID[num117].KingdomID == num8 && this.WorldKingdomTable[(int)tableID11].kingdomID == num8)
					{
						this.WorldKingdomTable[(int)tableID11].kingdomTime = MP.ReadULong(-1);
						this.KingdomNotifyObserver(tableID11, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_TIME);
					}
					else
					{
						MP.ReadULong(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_OWNERKINGDOMID:
				{
					ushort num8 = MP.ReadUShort(-1);
					KingdomMap recordByKey6 = this.KingdomMapTable.GetRecordByKey(num8);
					int num118 = (int)(this.WorldMaxX - this.WorldMinX + 1);
					int num119 = (int)(recordByKey6.worldPosX - this.WorldMinX) + (int)(recordByKey6.worldPosY - this.WorldMinY) * num118;
					byte tableID12 = this.TileMapKingdomID[num119].tableID;
					if (this.TileMapKingdomID[num119].KingdomID == num8 && this.WorldKingdomTable[(int)tableID12].kingdomID == num8)
					{
						this.WorldKingdomTable[(int)tableID12].allianceKingdomID = MP.ReadUShort(-1);
						this.WorldKingdomTable[(int)tableID12].kingKingdomID = MP.ReadUShort(-1);
						this.KingdomNotifyObserver(tableID12, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_OWNERKINGDOMID);
					}
					else
					{
						MP.ReadUInt(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_ALLIANCE_KINGDOM:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID27 = MP.ReadByte(-1);
					uint num120 = (uint)GameConstants.PointCodeToMapID(num8, pointID27);
					if (this.IsCityOrCamp(num120) && this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						this.PlayerPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num120)].tableID].allianceKingdomID = MP.ReadUShort(-1);
						this.PointNotifyObserver(num120);
					}
					else
					{
						MP.ReadUShort(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_YOLK_LEADER_HOME_KINGDOM:
				{
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID28 = MP.ReadByte(-1);
					uint num121 = (uint)GameConstants.PointCodeToMapID(num8, pointID28);
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						if ((int)this.LayoutMapInfo[(int)((UIntPtr)num121)].tableID < this.YolkPointTable.Length)
						{
							this.YolkPointTable[(int)this.LayoutMapInfo[(int)((UIntPtr)num121)].tableID].LeaderHomeKingdomID = MP.ReadUShort(-1);
							this.PointNotifyObserver(num121);
						}
						else
						{
							MP.ReadUShort(-1);
						}
					}
					else
					{
						MP.ReadUShort(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_LINE_EMOJI:
				{
					short num122 = MP.ReadShort(-1);
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					uint num123 = MP.ReadUInt(-1);
					num122 -= 6;
					int lineTableID5 = this.getLineTableID(num8, num123);
					if (lineTableID5 < 1048576 && num123 == this.MapLineTable[lineTableID5].lineID && this.MapLineTable[lineTableID5].lineObject != null)
					{
						this.MapLineTable[lineTableID5].baseFlag = MP.ReadByte(-1);
						this.MapLineTable[lineTableID5].emojiID = MP.ReadUShort(-1);
						this.LineNotifyObserver(61, lineTableID5, 1, 0);
					}
					else
					{
						MP.ReadByte(-1);
						MP.ReadUShort(-1);
					}
					for (int num124 = (int)(num122 - 3); num124 > 0; num124--)
					{
						MP.ReadByte(-1);
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_EMOJI:
				{
					short num125 = MP.ReadShort(-1);
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID29 = MP.ReadByte(-1);
					num125 -= 3;
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						uint num126 = (uint)GameConstants.PointCodeToMapID(num8, pointID29);
						ushort tableID13 = this.LayoutMapInfo[(int)((UIntPtr)num126)].tableID;
						if (this.IsCityOrCamp(num126))
						{
							this.PlayerPointTable[(int)tableID13].baseFlag = MP.ReadByte(-1);
							this.PlayerPointTable[(int)tableID13].emojiID = MP.ReadUShort(-1);
							this.PointNotifyObserver(num126);
						}
						else if (this.IsResources(num126))
						{
							this.ResourcesPointTable[(int)tableID13].baseFlag = MP.ReadByte(-1);
							this.ResourcesPointTable[(int)tableID13].emojiID = MP.ReadUShort(-1);
							this.PointNotifyObserver(num126);
						}
						else if (this.LayoutMapInfo[(int)((UIntPtr)num126)].pointKind == 11)
						{
							this.YolkPointTable[(int)tableID13].baseFlag = MP.ReadByte(-1);
							this.YolkPointTable[(int)tableID13].emojiID = MP.ReadUShort(-1);
							this.PointNotifyObserver(num126);
						}
						else
						{
							for (int num127 = (int)num125; num127 > 0; num127--)
							{
								MP.ReadByte(-1);
							}
						}
					}
					else
					{
						for (int num128 = (int)num125; num128 > 0; num128--)
						{
							MP.ReadByte(-1);
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_NPC_TAG:
				{
					short num129 = MP.ReadShort(-1);
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID30 = MP.ReadByte(-1);
					num129 -= 3;
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						uint num130 = (uint)GameConstants.PointCodeToMapID(num8, pointID30);
						ushort tableID14 = this.LayoutMapInfo[(int)((UIntPtr)num130)].tableID;
						if (this.LayoutMapInfo[(int)((UIntPtr)num130)].pointKind == 10)
						{
							MP.ReadStringPlus(3, this.NPCPointTable[(int)tableID14].NPCAllianceTag, -1);
							this.PointNotifyObserver(num130);
						}
						else
						{
							for (int num131 = (int)num129; num131 > 0; num131--)
							{
								MP.ReadByte(-1);
							}
						}
					}
					else
					{
						for (int num132 = (int)num129; num132 > 0; num132--)
						{
							MP.ReadByte(-1);
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_OUTWARD:
				{
					short num133 = MP.ReadShort(-1);
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID31 = MP.ReadByte(-1);
					num133 -= 3;
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						uint num134 = (uint)GameConstants.PointCodeToMapID(num8, pointID31);
						ushort tableID15 = this.LayoutMapInfo[(int)((UIntPtr)num134)].tableID;
						if (this.IsCityOrCamp(num134))
						{
							this.PlayerPointTable[(int)tableID15].cityOutward = (CITY_OUTWARD)MP.ReadByte(-1);
							this.PlayerPointTable[(int)tableID15].cityOutwardLevel = MP.ReadByte(-1);
							this.PointNotifyObserver(num134);
						}
						else
						{
							for (int num135 = (int)num133; num135 > 0; num135--)
							{
								MP.ReadByte(-1);
							}
						}
					}
					else
					{
						for (int num136 = (int)num133; num136 > 0; num136--)
						{
							MP.ReadByte(-1);
						}
					}
					goto IL_5953;
				}
				case MAP_UPDATE_KIND.MAPUPDATE_POINT_PLAYER_OUTWARD_LEVEL:
				{
					short num137 = MP.ReadShort(-1);
					ushort num8 = MP.ReadUShort(-1);
					this.CheckZoneID(num8, false);
					this.ZoneUpdateInfo[(int)num8].updateNum = updateNum;
					byte pointID32 = MP.ReadByte(-1);
					num137 -= 3;
					if (this.ZoneUpdateInfo[(int)num8].zoneState < 8 && this.RAMSataeInfo[(int)this.ZoneUpdateInfo[(int)num8].zoneState].zoneID == num8)
					{
						uint num138 = (uint)GameConstants.PointCodeToMapID(num8, pointID32);
						ushort tableID16 = this.LayoutMapInfo[(int)((UIntPtr)num138)].tableID;
						if (this.IsCityOrCamp(num138))
						{
							this.PlayerPointTable[(int)tableID16].cityOutwardLevel = MP.ReadByte(-1);
							this.PointNotifyObserver(num138);
						}
						else
						{
							for (int num139 = (int)num137; num139 > 0; num139--)
							{
								MP.ReadByte(-1);
							}
						}
					}
					else
					{
						for (int num140 = (int)num137; num140 > 0; num140--)
						{
							MP.ReadByte(-1);
						}
					}
					goto IL_5953;
				}
				}
				short num141 = MP.ReadShort(-1);
				for (int num142 = (int)num141; num142 > 0; num142--)
				{
					MP.ReadByte(-1);
				}
			}
			IL_5953:;
		}
		DataManager.msgBuffer[0] = 70;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x060009F9 RID: 2553 RVA: 0x000D730C File Offset: 0x000D550C
	public void RecvMapMonsterAttack(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		DataManager instance = DataManager.Instance;
		if (b == 0)
		{
			byte b2 = MP.ReadByte(-1);
			if (b2 < 8)
			{
				instance.MarchEventData[(int)b2].Type = EMarchEventType.EMET_HitMonsterMarching;
				instance.MarchEventData[(int)b2].Point.zoneID = MP.ReadUShort(-1);
				instance.MarchEventData[(int)b2].Point.pointID = MP.ReadByte(-1);
				instance.MarchEventTime[(int)b2].BeginTime = MP.ReadLong(-1);
				instance.MarchEventTime[(int)b2].RequireTime = MP.ReadUInt(-1);
				instance.RoleAttr.recvMonsterPoint = MP.ReadUInt(-1);
				for (int i = 0; i < 5; i++)
				{
					ushort num = MP.ReadUShort(-1);
					instance.MarchEventData[(int)b2].HeroID[i] = num;
					instance.TempFightHeroID[(int)num] = 1;
				}
				instance.MarchEventData[(int)b2].PointKind = POINT_KIND.PK_NPC;
				for (int j = 0; j < instance.MarchEventData[(int)b2].TroopData.Length; j++)
				{
					Array.Clear(instance.MarchEventData[(int)b2].TroopData[j], instance.MarchEventData[(int)b2].TroopData[j].Length, 0);
				}
				instance.RoleAttr.LastMonsterPointRecoverTime = instance.MarchEventTime[(int)b2].BeginTime;
				instance.UpdateMonsterPoint();
				instance.SetFightHeroData();
				instance.SetQueueBarData(EQueueBarIndex.MarchingBegin + (int)b2, true, instance.MarchEventTime[(int)b2].BeginTime, instance.MarchEventTime[(int)b2].RequireTime);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 4, 1);
				instance.CheckTroolCount();
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0, 0);
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.GoToGroup((int)b2, 0, true);
				GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
			}
		}
		else
		{
			switch (b)
			{
			case 1:
				GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8342u), 255, true);
				break;
			case 2:
				GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8341u), 255, true);
				break;
			case 4:
				GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(663u), 255, true);
				break;
			case 5:
				GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8343u), 255, true);
				break;
			case 6:
				GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8344u), 255, true);
				break;
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 4, 1);
		}
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Expedition);
		GUIManager.Instance.HideUILock(EUILock.Battle);
	}

	// Token: 0x060009FA RID: 2554 RVA: 0x000D7628 File Offset: 0x000D5828
	public void RecvMonsterReturn(MessagePacket MP)
	{
		DataManager instance = DataManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b >= 8)
		{
			return;
		}
		instance.MarchEventData[(int)b].Type = (EMarchEventType)MP.ReadByte(-1);
		instance.MarchEventTime[(int)b].BeginTime = MP.ReadLong(-1);
		instance.MarchEventTime[(int)b].RequireTime = MP.ReadUInt(-1);
		for (int i = 0; i < 5; i++)
		{
			instance.MarchEventData[(int)b].HeroID[i] = MP.ReadUShort(-1);
		}
		instance.MarchEventData[(int)b].PointKind = POINT_KIND.PK_NONE;
		for (int j = 0; j < instance.MarchEventData[(int)b].TroopData.Length; j++)
		{
			Array.Clear(instance.MarchEventData[(int)b].TroopData[j], instance.MarchEventData[(int)b].TroopData[j].Length, 0);
		}
		byte b2 = MP.ReadByte(-1);
		for (byte b3 = 0; b3 < b2; b3 += 1)
		{
			ushort itemID = MP.ReadUShort(-1);
			ushort num = MP.ReadUShort(-1);
			byte b4 = MP.ReadByte(-1);
			num += instance.GetCurItemQuantity(itemID, b4);
			instance.SetCurItemQuantity(itemID, num, b4, 0L);
			if (b4 > 0)
			{
				instance.ReflashMaterialItem = 1;
			}
		}
		instance.UpdateLoadItemNotify();
		instance.SetQueueBarData(EQueueBarIndex.MarchingBegin + (int)b, true, instance.MarchEventTime[(int)b].BeginTime, instance.MarchEventTime[(int)b].RequireTime);
		instance.CheckTroolCount();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0, 0);
	}

	// Token: 0x060009FB RID: 2555 RVA: 0x000D77D4 File Offset: 0x000D59D4
	public void RecvMonsterHome(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		DataManager instance = DataManager.Instance;
		for (int i = 0; i < 5; i++)
		{
			ushort num = instance.MarchEventData[(int)b].HeroID[i];
			instance.TempFightHeroID[(int)num] = 0;
		}
		Array.Clear(instance.MarchEventData[(int)b].HeroID, 0, instance.MarchEventData[(int)b].HeroID.Length);
		instance.SetFightHeroData();
		GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
		DataManager.Instance.MarchEventData[(int)b].Type = EMarchEventType.EMET_Standby;
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.MarchingBegin + (int)b, false, 0L, 0u);
		DataManager.Instance.CheckTroolCount();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0, 0);
	}

	// Token: 0x060009FC RID: 2556 RVA: 0x000D7898 File Offset: 0x000D5A98
	public void RecvMapMonsterInfo(MessagePacket MP)
	{
		DataManager instance = DataManager.Instance;
		instance.RoleAttr.LastHitMonsterTime = MP.ReadLong(-1);
		instance.RoleAttr.LastHitMonsterSerialNO = MP.ReadUInt(-1);
		instance.RoleAttr.DamageRateForMonster = MP.ReadByte(-1);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MapMonster, 0, 0);
	}

	// Token: 0x060009FD RID: 2557 RVA: 0x000D78F0 File Offset: 0x000D5AF0
	public ushort GetMonsterType(ushort MonsterID)
	{
		ActivityManager instance = ActivityManager.Instance;
		for (int i = 0; i < (int)instance.MonsterCount; i++)
		{
			if (instance.Monster[i] == MonsterID)
			{
				return instance.MonsterType[i];
			}
		}
		return 0;
	}

	// Token: 0x060009FE RID: 2558 RVA: 0x000D7934 File Offset: 0x000D5B34
	public void SaveMapInfo()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(Application.persistentDataPath);
		cstring.AppendFormat("{0}/~HKMA.tmp");
		using (FileStream fileStream = new FileStream(cstring.ToString(), FileMode.OpenOrCreate, FileAccess.Write))
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
			{
				binaryWriter.Write(this.OtherKingdomData.kingdomID);
				for (byte b = 0; b < 8; b += 1)
				{
					ushort tableID = this.RAMSataeInfo[(int)b].zoneID;
					binaryWriter.Write(tableID);
					ulong updateNum = this.ZoneUpdateInfo[(int)tableID].updateNum;
					binaryWriter.Write(updateNum);
					if (this.ZoneUpdateInfo[(int)tableID].updateNum != 0UL)
					{
						for (int i = 0; i < 256; i++)
						{
							int num = GameConstants.PointCodeToMapID(tableID, (byte)i);
							POINT_KIND layoutMapInfoPointKind = this.GetLayoutMapInfoPointKind((uint)num);
							binaryWriter.Write((byte)layoutMapInfoPointKind);
							if (layoutMapInfoPointKind > POINT_KIND.PK_NONE)
							{
								tableID = this.LayoutMapInfo[num].tableID;
								if (layoutMapInfoPointKind < POINT_KIND.PK_CITY)
								{
									binaryWriter.Write(this.ResourcesPointTable[(int)tableID].playerName.ToString());
									if (this.ResourcesPointTable[(int)tableID].playerName.Length != 0)
									{
										binaryWriter.Write(this.ResourcesPointTable[(int)tableID].allianceTag.ToString());
										binaryWriter.Write(this.ResourcesPointTable[(int)tableID].kingdomID);
										binaryWriter.Write(this.ResourcesPointTable[(int)tableID].rate);
										binaryWriter.Write(this.ResourcesPointTable[(int)tableID].time);
									}
									binaryWriter.Write(this.ResourcesPointTable[(int)tableID].level);
									binaryWriter.Write(this.ResourcesPointTable[(int)tableID].count);
									binaryWriter.Flush();
								}
								else if (layoutMapInfoPointKind < POINT_KIND.PK_NPC)
								{
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].playerName.ToString());
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].allianceTag.ToString());
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].kingdomID);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].level);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].capitalFlag);
									binaryWriter.Write((byte)this.PlayerPointTable[(int)tableID].kingdomTitle);
									binaryWriter.Write((byte)this.PlayerPointTable[(int)tableID].worldTitle);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].VIP);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].allianceRank);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].portraitID);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].bounty);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].power);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].kill);
									binaryWriter.Flush();
								}
								else if (layoutMapInfoPointKind == POINT_KIND.PK_NPC)
								{
									binaryWriter.Write(this.NPCPointTable[(int)tableID].level);
									binaryWriter.Write(this.NPCPointTable[(int)tableID].NPCNum);
									binaryWriter.Write(this.NPCPointTable[(int)tableID].Key);
									binaryWriter.Write(this.NPCPointTable[(int)tableID].Blood);
									binaryWriter.Flush();
								}
							}
						}
					}
				}
				binaryWriter.Close();
			}
			fileStream.Close();
		}
	}

	// Token: 0x060009FF RID: 2559 RVA: 0x000D7D54 File Offset: 0x000D5F54
	public void LoadMapInfo()
	{
		this.wait = 0f;
		this.checkZone = (this.zoneIDNum = (this.UpdateZoneIDNum = (this.LastZoneIDNum = (this.waitZoneIDNum = (this.gotoKingdomState = 0)))));
		this.zoneID[0] = (this.LastZoneID[0] = 16384);
		Array.Clear(this.ZoneUpdateInfo, 0, 1024);
		Array.Clear(this.LayoutMapInfo, 0, 262144);
		ushort num = 1;
		while ((int)num < this.yolkswitch.Length)
		{
			this.yolkswitch[(int)num] = 0;
			num += 1;
		}
		this.yolkswitch[0] = 127;
		for (byte b = 0; b < 8; b += 1)
		{
			this.RAMSataeInfo[(int)b].sortID = (this.sortRAMReplaceNum[(int)b] = b);
			this.RAMSataeInfo[(int)b].replaceNum = 0u;
			this.RAMSataeInfo[(int)b].zoneID = 1024;
		}
		if (this.ROMSataeInfo != null)
		{
			for (byte b2 = 0; b2 < 120; b2 += 1)
			{
				this.ROMSataeInfo[(int)b2].sortID = (this.sortROMReplaceNum[(int)b2] = b2);
				this.ROMSataeInfo[(int)b2].replaceNum = 0u;
			}
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(Application.persistentDataPath);
			cstring.AppendFormat("{0}/~HKMA.tmp");
			if (File.Exists(cstring.ToString()))
			{
				using (FileStream fileStream = new FileStream(cstring.ToString(), FileMode.Open))
				{
					using (BinaryReader binaryReader = new BinaryReader(fileStream))
					{
						ushort num2 = binaryReader.ReadUInt16();
						if (num2 == this.OtherKingdomData.kingdomID)
						{
							for (byte b3 = 0; b3 < 8; b3 += 1)
							{
								num2 = binaryReader.ReadUInt16();
								this.ZoneUpdateInfo[(int)num2].updateNum = binaryReader.ReadUInt64();
								if (this.ZoneUpdateInfo[(int)num2].updateNum == 0UL)
								{
									break;
								}
								this.ZoneUpdateInfo[(int)num2].zoneState = b3;
								this.RAMSataeInfo[(int)b3].zoneID = num2;
								this.RAMSataeInfo[(int)b3].replaceNum = 1u;
								this.sortMaxRAM(b3);
								for (int i = 0; i < 256; i++)
								{
									int num3 = GameConstants.PointCodeToMapID(num2, (byte)i);
									this.LayoutMapInfo[num3].pointKind = binaryReader.ReadByte();
									if (this.LayoutMapInfo[num3].pointKind > 0)
									{
										if (this.LayoutMapInfo[num3].pointKind < 8)
										{
											ushort num4 = this.LayoutMapInfo[num3].tableID = (ushort)this.ResourcesPointTableIDpool.spawn();
											DataManager.DataBuffer[0] = binaryReader.ReadByte();
											if (DataManager.DataBuffer[0] != 0)
											{
												for (int j = 1; j < 13; j++)
												{
													DataManager.DataBuffer[j] = binaryReader.ReadByte();
												}
												this.ResourcesPointTable[(int)num4].playerName.ClearString();
												this.ResourcesPointTable[(int)num4].playerName.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 13));
												DataManager.DataBuffer[0] = binaryReader.ReadByte();
												if (DataManager.DataBuffer[0] != 0)
												{
													for (int k = 1; k < 3; k++)
													{
														DataManager.DataBuffer[k] = binaryReader.ReadByte();
													}
													this.ResourcesPointTable[(int)num4].allianceTag.ClearString();
													this.ResourcesPointTable[(int)num4].allianceTag.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 3));
												}
												this.ResourcesPointTable[(int)num4].kingdomID = binaryReader.ReadUInt16();
												for (int l = 0; l < 4; l++)
												{
													DataManager.DataBuffer[l] = binaryReader.ReadByte();
												}
												this.ResourcesPointTable[(int)num4].rate = GameConstants.ConvertBytesToFloat(DataManager.DataBuffer, 0);
												this.ResourcesPointTable[(int)num4].time = binaryReader.ReadUInt64();
											}
											else
											{
												this.ResourcesPointTable[(int)num4].allianceTag.ClearString();
											}
											this.ResourcesPointTable[(int)num4].level = binaryReader.ReadByte();
											this.ResourcesPointTable[(int)num4].count = binaryReader.ReadUInt32();
										}
										else if (this.LayoutMapInfo[num3].pointKind < 10)
										{
											ushort num4 = this.LayoutMapInfo[num3].tableID = (ushort)this.PlayerPointTableIDpool.spawn();
											for (int m = 0; m < 13; m++)
											{
												DataManager.DataBuffer[m] = binaryReader.ReadByte();
											}
											this.PlayerPointTable[(int)num4].playerName.ClearString();
											this.PlayerPointTable[(int)num4].playerName.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 13));
											DataManager.DataBuffer[0] = binaryReader.ReadByte();
											if (DataManager.DataBuffer[0] != 0)
											{
												for (int n = 1; n < 3; n++)
												{
													DataManager.DataBuffer[n] = binaryReader.ReadByte();
												}
												this.PlayerPointTable[(int)num4].allianceTag.ClearString();
												this.PlayerPointTable[(int)num4].allianceTag.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 3));
											}
											this.PlayerPointTable[(int)num4].kingdomID = binaryReader.ReadUInt16();
											this.PlayerPointTable[(int)num4].level = binaryReader.ReadByte();
											this.PlayerPointTable[(int)num4].capitalFlag = binaryReader.ReadByte();
											this.PlayerPointTable[(int)num4].kingdomTitle = (KINGDOM_DESIGNATION)binaryReader.ReadByte();
											this.PlayerPointTable[(int)num4].worldTitle = (WORLD_PLAYER_DESIGNATION)binaryReader.ReadByte();
											this.PlayerPointTable[(int)num4].VIP = binaryReader.ReadByte();
											this.PlayerPointTable[(int)num4].allianceRank = binaryReader.ReadByte();
											this.PlayerPointTable[(int)num4].portraitID = binaryReader.ReadUInt16();
											this.PlayerPointTable[(int)num4].bounty = binaryReader.ReadUInt32();
											this.PlayerPointTable[(int)num4].power = binaryReader.ReadUInt64();
											this.PlayerPointTable[(int)num4].kill = binaryReader.ReadUInt64();
										}
										else if (this.LayoutMapInfo[num3].pointKind == 10)
										{
											ushort num4 = this.LayoutMapInfo[num3].tableID = (ushort)this.NPCPointTableIDpool.spawn();
											this.NPCPointTable[(int)num4].level = binaryReader.ReadByte();
											this.NPCPointTable[(int)num4].NPCNum = binaryReader.ReadUInt16();
											this.NPCPointTable[(int)num4].Key = binaryReader.ReadUInt32();
											this.NPCPointTable[(int)num4].Blood = binaryReader.ReadUInt32();
										}
									}
								}
							}
						}
						binaryReader.Close();
					}
					fileStream.Close();
				}
				cstring = StringManager.Instance.StaticString1024();
				cstring.StringToFormat(Application.persistentDataPath);
				cstring.AppendFormat("{0}/~HKMO.tmp");
				if (File.Exists(cstring.ToString()))
				{
					using (FileStream fileStream2 = new FileStream(cstring.ToString(), FileMode.Open))
					{
						using (BinaryReader binaryReader2 = new BinaryReader(fileStream2))
						{
							ushort num2 = binaryReader2.ReadUInt16();
							if (num2 == this.OtherKingdomData.kingdomID)
							{
								for (int num5 = 0; num5 < 120; num5++)
								{
									num2 = binaryReader2.ReadUInt16();
									this.ZoneUpdateInfo[(int)num2].updateNum = binaryReader2.ReadUInt64();
									if (this.ZoneUpdateInfo[(int)num2].updateNum != 0UL)
									{
										this.ZoneUpdateInfo[(int)num2].zoneState = (byte)(num5 + 8);
										this.ROMSataeInfo[num5].zoneID = num2;
										this.ROMSataeInfo[num5].replaceNum = 1u;
										this.sortMaxROM((byte)num5);
									}
								}
							}
							binaryReader2.Close();
						}
						fileStream2.Close();
					}
				}
			}
		}
		this.PlayerPointTableIDpool.init();
		this.ResourcesPointTableIDpool.init();
		this.NPCPointTableIDpool.init();
		Array.Clear(this.NPCNumMap, 0, 5);
		Array.Clear(this.OtherNPCNumMap, 0, 5);
		this.delAllLine();
		this.MapLineTableIDpool.init();
		this.WorldKingdomTableIDcounter = (this.reqKingdomIDNum = (this.lastReqKingdomIDNum = (this.updateKingdomNum = 0)));
		Array.Clear(this.reqKingdomID, 0, 16);
		Array.Clear(this.lastReqKingdomID, 0, 16);
		Array.Clear(this.updateKingdomID, 0, 16);
		if (this.KingdomIDposOrder != null)
		{
			Array.Clear(this.KingdomIDposOrder, 0, this.KingdomIDposOrder.Length);
		}
		if (this.TileMapKingdomID != null)
		{
			Array.Clear(this.TileMapKingdomID, 0, this.TileMapKingdomID.Length);
		}
	}

	// Token: 0x06000A00 RID: 2560 RVA: 0x000D877C File Offset: 0x000D697C
	public void moveRAMtoROM(ushort newZoneID)
	{
		byte b = this.sortRAMReplaceNum[0];
		int num = 62;
		if (this.ROMSataeInfo == null)
		{
			ushort num2 = this.RAMSataeInfo[(int)b].zoneID;
			this.RAMSataeInfo[(int)b].zoneID = newZoneID;
			this.RAMSataeInfo[(int)b].replaceNum = this.RAMSataeInfo[(int)this.sortRAMReplaceNum[7]].replaceNum + 1u;
			this.ZoneUpdateInfo[(int)newZoneID].zoneState = b;
			this.sortMaxRAM(b);
			if (num2 < 1024)
			{
				this.ZoneUpdateInfo[(int)num2].updateNum = 0UL;
				this.freeZonePoint(num2);
			}
			return;
		}
		byte b2 = this.sortROMReplaceNum[0];
		if (this.ROMSataeInfo[(int)b2].replaceNum != 0u)
		{
			ushort num2 = this.ROMSataeInfo[(int)b2].zoneID;
			this.ZoneUpdateInfo[(int)num2].updateNum = 0UL;
			num2 = (this.ROMSataeInfo[(int)b2].zoneID = this.RAMSataeInfo[(int)b].zoneID);
			this.ROMSataeInfo[(int)b2].replaceNum = this.RAMSataeInfo[(int)b].replaceNum;
			this.sortMaxROM(b2);
			this.ZoneUpdateInfo[(int)num2].zoneState = b2 + 120;
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(Application.persistentDataPath);
			cstring.AppendFormat("{0}/~HKMO.tmp");
			if (File.Exists(cstring.ToString()))
			{
				using (FileStream fileStream = new FileStream(cstring.ToString(), FileMode.Open, FileAccess.Write))
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
					{
						binaryWriter.Seek((int)(4 + 12 * b2), SeekOrigin.Current);
						ulong value;
						if (this.ROMSataeInfo[(int)b2].replaceNum == 0u)
						{
							num2 = 0;
							value = 0UL;
						}
						else
						{
							num2 = this.ROMSataeInfo[(int)b2].zoneID;
							value = this.ZoneUpdateInfo[(int)num2].updateNum;
						}
						binaryWriter.Write(num2);
						binaryWriter.Write(value);
						binaryWriter.Seek(1444 + (int)b2 * 256 * num, SeekOrigin.Begin);
						for (int i = 0; i < 256; i++)
						{
							int num3 = GameConstants.PointCodeToMapID(num2, (byte)i);
							POINT_KIND layoutMapInfoPointKind = this.GetLayoutMapInfoPointKind((uint)num3);
							binaryWriter.Write((byte)layoutMapInfoPointKind);
							if (layoutMapInfoPointKind > POINT_KIND.PK_NONE)
							{
								ushort tableID = this.LayoutMapInfo[num3].tableID;
								if (layoutMapInfoPointKind < POINT_KIND.PK_CITY)
								{
									binaryWriter.Write(this.ResourcesPointTable[(int)tableID].playerName.ToString());
									binaryWriter.Seek(13 - this.ResourcesPointTable[(int)tableID].playerName.Length, SeekOrigin.Current);
									binaryWriter.Write(this.ResourcesPointTable[(int)tableID].allianceTag.ToString());
									binaryWriter.Seek(3 - this.ResourcesPointTable[(int)tableID].allianceTag.Length, SeekOrigin.Current);
									binaryWriter.Write(this.ResourcesPointTable[(int)tableID].kingdomID);
									binaryWriter.Write(this.ResourcesPointTable[(int)tableID].rate);
									binaryWriter.Write(this.ResourcesPointTable[(int)tableID].time);
									binaryWriter.Write(this.ResourcesPointTable[(int)tableID].level);
									binaryWriter.Write(this.ResourcesPointTable[(int)tableID].count);
									binaryWriter.Flush();
									binaryWriter.Seek(7, SeekOrigin.Current);
									this.ResourcesPointTableIDpool.despawn((int)tableID);
								}
								else if (layoutMapInfoPointKind < POINT_KIND.PK_NPC)
								{
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].playerName.ToString());
									binaryWriter.Seek(13 - this.PlayerPointTable[(int)tableID].playerName.Length, SeekOrigin.Current);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].allianceTag.ToString());
									binaryWriter.Seek(13 - this.PlayerPointTable[(int)tableID].allianceTag.Length, SeekOrigin.Current);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].kingdomID);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].level);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].capitalFlag);
									binaryWriter.Write((byte)this.PlayerPointTable[(int)tableID].kingdomTitle);
									binaryWriter.Write((byte)this.PlayerPointTable[(int)tableID].worldTitle);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].VIP);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].allianceRank);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].portraitID);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].bounty);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].power);
									binaryWriter.Write(this.PlayerPointTable[(int)tableID].kill);
									binaryWriter.Flush();
									this.PlayerPointTableIDpool.despawn((int)tableID);
								}
								else if (layoutMapInfoPointKind == POINT_KIND.PK_NPC)
								{
									binaryWriter.Write(this.NPCPointTable[(int)tableID].level);
									binaryWriter.Write(this.NPCPointTable[(int)tableID].NPCNum);
									binaryWriter.Write(this.NPCPointTable[(int)tableID].Key);
									binaryWriter.Write(this.NPCPointTable[(int)tableID].Blood);
									binaryWriter.Flush();
									this.NPCPointTableIDpool.despawn((int)tableID);
								}
								this.LayoutMapInfo[num3].pointKind = 0;
							}
							else
							{
								binaryWriter.Seek(num - 1, SeekOrigin.Current);
							}
						}
						binaryWriter.Close();
					}
					fileStream.Close();
				}
			}
			else
			{
				using (FileStream fileStream2 = new FileStream(cstring.ToString(), FileMode.CreateNew, FileAccess.Write))
				{
					using (BinaryWriter binaryWriter2 = new BinaryWriter(fileStream2))
					{
						binaryWriter2.Write(this.OtherKingdomData.kingdomID);
						for (int j = 0; j < 120; j++)
						{
							ulong value;
							if (this.ROMSataeInfo[j].replaceNum == 0u)
							{
								num2 = 0;
								value = 0UL;
							}
							else
							{
								num2 = this.ROMSataeInfo[j].zoneID;
								value = this.ZoneUpdateInfo[(int)num2].updateNum;
							}
							binaryWriter2.Write(num2);
							binaryWriter2.Write(value);
						}
						binaryWriter2.Seek((int)b2 * 256 * num, SeekOrigin.Current);
						for (int k = 0; k < 256; k++)
						{
							int num3 = GameConstants.PointCodeToMapID(num2, (byte)k);
							POINT_KIND layoutMapInfoPointKind = this.GetLayoutMapInfoPointKind((uint)num3);
							binaryWriter2.Write((byte)layoutMapInfoPointKind);
							if (layoutMapInfoPointKind > POINT_KIND.PK_NONE)
							{
								ushort tableID = this.LayoutMapInfo[num3].tableID;
								if (layoutMapInfoPointKind < POINT_KIND.PK_CITY)
								{
									binaryWriter2.Write(this.ResourcesPointTable[(int)tableID].playerName.ToString());
									binaryWriter2.Seek(13 - this.ResourcesPointTable[(int)tableID].playerName.Length, SeekOrigin.Current);
									binaryWriter2.Write(this.ResourcesPointTable[(int)tableID].allianceTag.ToString());
									binaryWriter2.Seek(3 - this.ResourcesPointTable[(int)tableID].allianceTag.Length, SeekOrigin.Current);
									binaryWriter2.Write(this.ResourcesPointTable[(int)tableID].kingdomID);
									binaryWriter2.Write(this.ResourcesPointTable[(int)tableID].rate);
									binaryWriter2.Write(this.ResourcesPointTable[(int)tableID].time);
									binaryWriter2.Write(this.ResourcesPointTable[(int)tableID].level);
									binaryWriter2.Write(this.ResourcesPointTable[(int)tableID].count);
									binaryWriter2.Flush();
									binaryWriter2.Seek(7, SeekOrigin.Current);
									this.ResourcesPointTableIDpool.despawn((int)tableID);
								}
								else if (layoutMapInfoPointKind < POINT_KIND.PK_NPC)
								{
									binaryWriter2.Write(this.PlayerPointTable[(int)tableID].playerName.ToString());
									binaryWriter2.Seek(13 - this.PlayerPointTable[(int)tableID].playerName.Length, SeekOrigin.Current);
									binaryWriter2.Write(this.PlayerPointTable[(int)tableID].allianceTag.ToString());
									binaryWriter2.Seek(13 - this.PlayerPointTable[(int)tableID].allianceTag.Length, SeekOrigin.Current);
									binaryWriter2.Write(this.PlayerPointTable[(int)tableID].kingdomID);
									binaryWriter2.Write(this.PlayerPointTable[(int)tableID].level);
									binaryWriter2.Write(this.PlayerPointTable[(int)tableID].capitalFlag);
									binaryWriter2.Write((byte)this.PlayerPointTable[(int)tableID].kingdomTitle);
									binaryWriter2.Write((byte)this.PlayerPointTable[(int)tableID].worldTitle);
									binaryWriter2.Write(this.PlayerPointTable[(int)tableID].VIP);
									binaryWriter2.Write(this.PlayerPointTable[(int)tableID].allianceRank);
									binaryWriter2.Write(this.PlayerPointTable[(int)tableID].portraitID);
									binaryWriter2.Write(this.PlayerPointTable[(int)tableID].bounty);
									binaryWriter2.Write(this.PlayerPointTable[(int)tableID].power);
									binaryWriter2.Write(this.PlayerPointTable[(int)tableID].kill);
									binaryWriter2.Flush();
									this.PlayerPointTableIDpool.despawn((int)tableID);
								}
								else if (layoutMapInfoPointKind == POINT_KIND.PK_NPC)
								{
									binaryWriter2.Write(this.NPCPointTable[(int)tableID].level);
									binaryWriter2.Write(this.NPCPointTable[(int)tableID].NPCNum);
									binaryWriter2.Write(this.NPCPointTable[(int)tableID].Key);
									binaryWriter2.Write(this.NPCPointTable[(int)tableID].Blood);
									binaryWriter2.Flush();
									this.NPCPointTableIDpool.despawn((int)tableID);
								}
								this.LayoutMapInfo[num3].pointKind = 0;
							}
							else
							{
								binaryWriter2.Seek(num - 1, SeekOrigin.Current);
							}
						}
						binaryWriter2.Close();
					}
					fileStream2.Close();
				}
			}
		}
		this.ZoneUpdateInfo[(int)newZoneID].zoneState = b;
		this.RAMSataeInfo[(int)b].zoneID = newZoneID;
	}

	// Token: 0x06000A01 RID: 2561 RVA: 0x000D92D0 File Offset: 0x000D74D0
	public void switchRAMtoROM(byte ROMID, bool bClear)
	{
		byte b = this.sortRAMReplaceNum[0];
		if (this.RAMSataeInfo[(int)b].replaceNum == 0u)
		{
			return;
		}
		ushort num = this.RAMSataeInfo[(int)b].zoneID;
		ushort num2 = this.ROMSataeInfo[(int)ROMID].zoneID;
		int num3 = 62;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(Application.persistentDataPath);
		cstring.AppendFormat("{0}/~HKMO.tmp");
		ulong num4;
		using (FileStream fileStream = new FileStream(cstring.ToString(), FileMode.Open, FileAccess.ReadWrite))
		{
			BinaryReader binaryReader = new BinaryReader(fileStream);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			fileStream.Seek((long)(4 + 12 * ROMID), SeekOrigin.Current);
			num4 = this.ZoneUpdateInfo[(int)num].updateNum;
			binaryWriter.Write(num);
			binaryWriter.Write(num4);
			binaryWriter.Flush();
			fileStream.Seek((long)(1444 + (int)ROMID * 256 * num3), SeekOrigin.Begin);
			for (int i = 0; i < 256; i++)
			{
				if (bClear)
				{
					int num5 = GameConstants.PointCodeToMapID(num2, (byte)i);
					this.LayoutMapInfo[num5].pointKind = binaryReader.ReadByte();
					if (this.LayoutMapInfo[num5].pointKind > 0)
					{
						if (this.LayoutMapInfo[num5].pointKind < 8)
						{
							for (int j = 0; j < 13; j++)
							{
								DataManager.DataBuffer[j] = binaryReader.ReadByte();
							}
							ushort num6 = this.LayoutMapInfo[num5].tableID = (ushort)this.ResourcesPointTableIDpool.spawn();
							this.ResourcesPointTable[(int)num6].playerName.ClearString();
							this.ResourcesPointTable[(int)num6].playerName.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 13));
							for (int k = 0; k < 3; k++)
							{
								DataManager.DataBuffer[k] = binaryReader.ReadByte();
							}
							this.ResourcesPointTable[(int)num6].allianceTag.ClearString();
							this.ResourcesPointTable[(int)num6].allianceTag.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 3));
							this.ResourcesPointTable[(int)num6].kingdomID = binaryReader.ReadUInt16();
							for (int l = 0; l < 4; l++)
							{
								DataManager.DataBuffer[l] = binaryReader.ReadByte();
							}
							this.ResourcesPointTable[(int)num6].rate = GameConstants.ConvertBytesToFloat(DataManager.DataBuffer, 0);
							this.ResourcesPointTable[(int)num6].time = binaryReader.ReadUInt64();
							this.ResourcesPointTable[(int)num6].level = binaryReader.ReadByte();
							this.ResourcesPointTable[(int)num6].count = binaryReader.ReadUInt32();
							fileStream.Seek(-55L, SeekOrigin.Current);
						}
						else if (this.LayoutMapInfo[num5].pointKind < 10)
						{
							for (int m = 0; m < 13; m++)
							{
								DataManager.DataBuffer[m] = binaryReader.ReadByte();
							}
							ushort num6 = this.LayoutMapInfo[num5].tableID = (ushort)this.PlayerPointTableIDpool.spawn();
							this.PlayerPointTable[(int)num6].playerName.ClearString();
							this.PlayerPointTable[(int)num6].playerName.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 13));
							DataManager.DataBuffer[0] = binaryReader.ReadByte();
							if (DataManager.DataBuffer[0] != 0)
							{
								for (int n = 1; n < 3; n++)
								{
									DataManager.DataBuffer[n] = binaryReader.ReadByte();
								}
								this.PlayerPointTable[(int)num6].allianceTag.ClearString();
								this.PlayerPointTable[(int)num6].allianceTag.Append(Encoding.UTF8.GetString(DataManager.DataBuffer, 0, 3));
							}
							this.PlayerPointTable[(int)num6].kingdomID = binaryReader.ReadUInt16();
							this.PlayerPointTable[(int)num6].level = binaryReader.ReadByte();
							this.PlayerPointTable[(int)num6].capitalFlag = binaryReader.ReadByte();
							this.PlayerPointTable[(int)num6].kingdomTitle = (KINGDOM_DESIGNATION)binaryReader.ReadByte();
							this.PlayerPointTable[(int)num6].worldTitle = (WORLD_PLAYER_DESIGNATION)binaryReader.ReadByte();
							this.PlayerPointTable[(int)num6].VIP = binaryReader.ReadByte();
							this.PlayerPointTable[(int)num6].allianceRank = binaryReader.ReadByte();
							this.PlayerPointTable[(int)num6].portraitID = binaryReader.ReadUInt16();
							this.PlayerPointTable[(int)num6].bounty = binaryReader.ReadUInt32();
							this.PlayerPointTable[(int)num6].power = binaryReader.ReadUInt64();
							this.PlayerPointTable[(int)num6].kill = binaryReader.ReadUInt64();
							fileStream.Seek((long)(-num3 - 1), SeekOrigin.Current);
						}
						else if (this.LayoutMapInfo[num5].pointKind == 10)
						{
							ushort num6 = this.LayoutMapInfo[num5].tableID = (ushort)this.NPCPointTableIDpool.spawn();
							this.NPCPointTable[(int)num6].level = binaryReader.ReadByte();
							this.NPCPointTable[(int)num6].NPCNum = binaryReader.ReadUInt16();
							this.NPCPointTable[(int)num6].Key = binaryReader.ReadUInt32();
							this.NPCPointTable[(int)num6].Blood = binaryReader.ReadUInt32();
							fileStream.Seek((long)(-num3 - 1), SeekOrigin.Current);
						}
					}
					else
					{
						fileStream.Seek(-1L, SeekOrigin.Current);
					}
				}
				int num7 = GameConstants.PointCodeToMapID(num, (byte)i);
				POINT_KIND layoutMapInfoPointKind = this.GetLayoutMapInfoPointKind((uint)num7);
				binaryWriter.Write((byte)layoutMapInfoPointKind);
				if (layoutMapInfoPointKind > POINT_KIND.PK_NONE)
				{
					ushort num6 = this.LayoutMapInfo[num7].tableID;
					if (layoutMapInfoPointKind < POINT_KIND.PK_CITY)
					{
						binaryWriter.Write(this.ResourcesPointTable[(int)num6].playerName.ToString());
						fileStream.Seek((long)(13 - this.ResourcesPointTable[(int)num6].playerName.Length), SeekOrigin.Current);
						binaryWriter.Write(this.ResourcesPointTable[(int)num6].allianceTag.ToString());
						fileStream.Seek((long)(3 - this.ResourcesPointTable[(int)num6].allianceTag.Length), SeekOrigin.Current);
						binaryWriter.Write(this.ResourcesPointTable[(int)num6].kingdomID);
						binaryWriter.Write(this.ResourcesPointTable[(int)num6].rate);
						binaryWriter.Write(this.ResourcesPointTable[(int)num6].time);
						binaryWriter.Write(this.ResourcesPointTable[(int)num6].level);
						binaryWriter.Write(this.ResourcesPointTable[(int)num6].count);
						binaryWriter.Flush();
						fileStream.Seek(7L, SeekOrigin.Current);
						this.ResourcesPointTableIDpool.despawn((int)num6);
					}
					else if (layoutMapInfoPointKind < POINT_KIND.PK_NPC)
					{
						binaryWriter.Write(this.PlayerPointTable[(int)num6].playerName.ToString());
						fileStream.Seek((long)(13 - this.PlayerPointTable[(int)num6].playerName.Length), SeekOrigin.Current);
						binaryWriter.Write(this.PlayerPointTable[(int)num6].allianceTag.ToString());
						fileStream.Seek((long)(13 - this.PlayerPointTable[(int)num6].allianceTag.Length), SeekOrigin.Current);
						binaryWriter.Write(this.PlayerPointTable[(int)num6].kingdomID);
						binaryWriter.Write(this.PlayerPointTable[(int)num6].level);
						binaryWriter.Write(this.PlayerPointTable[(int)num6].capitalFlag);
						binaryWriter.Write((byte)this.PlayerPointTable[(int)num6].kingdomTitle);
						binaryWriter.Write((byte)this.PlayerPointTable[(int)num6].worldTitle);
						binaryWriter.Write(this.PlayerPointTable[(int)num6].VIP);
						binaryWriter.Write(this.PlayerPointTable[(int)num6].allianceRank);
						binaryWriter.Write(this.PlayerPointTable[(int)num6].portraitID);
						binaryWriter.Write(this.PlayerPointTable[(int)num6].bounty);
						binaryWriter.Write(this.PlayerPointTable[(int)num6].power);
						binaryWriter.Write(this.PlayerPointTable[(int)num6].kill);
						binaryWriter.Flush();
						this.PlayerPointTableIDpool.despawn((int)num6);
					}
					else if (layoutMapInfoPointKind == POINT_KIND.PK_NPC)
					{
						binaryWriter.Write(this.NPCPointTable[(int)num6].level);
						binaryWriter.Write(this.NPCPointTable[(int)num6].NPCNum);
						binaryWriter.Write(this.NPCPointTable[(int)num6].Key);
						binaryWriter.Write(this.NPCPointTable[(int)num6].Blood);
						binaryWriter.Flush();
						this.NPCPointTableIDpool.despawn((int)num6);
					}
					this.LayoutMapInfo[num7].pointKind = 0;
				}
				else
				{
					fileStream.Seek((long)(num3 - 1), SeekOrigin.Current);
				}
			}
			binaryReader.Close();
			binaryWriter.Close();
			fileStream.Close();
		}
		num4 = (ulong)(this.ROMSataeInfo[(int)ROMID].replaceNum + 1u);
		this.ROMSataeInfo[(int)ROMID].replaceNum = this.RAMSataeInfo[(int)b].replaceNum;
		this.sortMaxROM(ROMID);
		this.ROMSataeInfo[(int)ROMID].zoneID = num;
		this.ZoneUpdateInfo[(int)num].zoneState = ROMID + 8;
		this.RAMSataeInfo[(int)b].replaceNum = (uint)num4;
		this.sortMaxRAM(b);
		this.RAMSataeInfo[(int)b].zoneID = num2;
		this.ZoneUpdateInfo[(int)num2].zoneState = b;
	}

	// Token: 0x06000A02 RID: 2562 RVA: 0x000D9D58 File Offset: 0x000D7F58
	public void sortMaxRAM(byte index)
	{
		byte b = this.RAMSataeInfo[(int)index].sortID + 1;
		while (b < 8 && this.RAMSataeInfo[(int)index].replaceNum > this.RAMSataeInfo[(int)this.sortRAMReplaceNum[(int)b]].replaceNum)
		{
			this.RAMSataeInfo[(int)this.sortRAMReplaceNum[(int)b]].sortID = this.RAMSataeInfo[(int)index].sortID;
			this.sortRAMReplaceNum[(int)this.RAMSataeInfo[(int)index].sortID] = this.sortRAMReplaceNum[(int)b];
			this.RAMSataeInfo[(int)index].sortID = b;
			byte[] array = this.sortRAMReplaceNum;
			byte b2 = b;
			b = b2 + 1;
			array[(int)b2] = index;
		}
	}

	// Token: 0x06000A03 RID: 2563 RVA: 0x000D9E20 File Offset: 0x000D8020
	public void sortMaxROM(byte index)
	{
		byte b = this.ROMSataeInfo[(int)index].sortID + 1;
		while (b < 120 && this.ROMSataeInfo[(int)index].replaceNum > this.ROMSataeInfo[(int)this.sortROMReplaceNum[(int)b]].replaceNum)
		{
			this.ROMSataeInfo[(int)this.sortROMReplaceNum[(int)b]].sortID = this.ROMSataeInfo[(int)index].sortID;
			this.sortROMReplaceNum[(int)this.ROMSataeInfo[(int)index].sortID] = this.sortROMReplaceNum[(int)b];
			this.ROMSataeInfo[(int)index].sortID = b;
			byte[] array = this.sortROMReplaceNum;
			byte b2 = b;
			b = b2 + 1;
			array[(int)b2] = index;
		}
	}

	// Token: 0x06000A04 RID: 2564 RVA: 0x000D9EE8 File Offset: 0x000D80E8
	public void setLastZoneInfo(byte nowZoneIDNum, ushort[] nowZoneID, bool renew)
	{
		if (this.zoneIDNum == 0 || this.checkZone >> (int)this.zoneIDNum == 1)
		{
			for (byte b = 0; b < 4; b += 1)
			{
				this.LastZoneID[(int)b] = this.zoneID[(int)b];
				this.zoneID[(int)b] = nowZoneID[(int)b];
			}
			this.LastZoneIDNum = this.zoneIDNum;
			this.zoneIDNum = nowZoneIDNum;
			this.sendRequestMapdataMsg(renew);
			return;
		}
		if (nowZoneIDNum > 0 && nowZoneIDNum < 4)
		{
			for (byte b2 = 0; b2 < 4; b2 += 1)
			{
				this.waitZoneID[(int)b2] = nowZoneID[(int)b2];
			}
			this.waitZoneIDNum = nowZoneIDNum;
		}
	}

	// Token: 0x06000A05 RID: 2565 RVA: 0x000D9F98 File Offset: 0x000D8198
	public void sendRequestMapdataMsg(bool renew)
	{
		this.checkZone = ((this.zoneID[0] != 16384) ? 0 : 2);
		DataManager.msgBuffer[0] = 68;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		MessagePacket messagePacket;
		if (this.FocusKingdomID != this.OtherKingdomData.kingdomID)
		{
			messagePacket = MessagePacket.GetGuestMessagePack();
		}
		else
		{
			messagePacket = new MessagePacket(1024);
		}
		messagePacket.Protocol = Protocol._MSG_REQUEST_MAPDATA;
		messagePacket.AddSeqId();
		messagePacket.Add(this.zoneIDNum);
		for (int i = 0; i < 4; i++)
		{
			messagePacket.Add(this.zoneID[i]);
		}
		if (renew)
		{
			for (int j = 0; j < 4; j++)
			{
				messagePacket.Add(0UL);
			}
		}
		else
		{
			for (int k = 0; k < 4; k++)
			{
				messagePacket.Add(this.ZoneUpdateInfo[(int)this.zoneID[k]].updateNum);
			}
		}
		messagePacket.Send(false);
		this.wait = 1.5f;
	}

	// Token: 0x06000A06 RID: 2566 RVA: 0x000DA0AC File Offset: 0x000D82AC
	public void sendRequestKingdomMsg()
	{
		DataManager.msgBuffer[0] = 114;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		this.lastReqKingdomIDNum = this.reqKingdomIDNum;
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_KINGDOM;
		messagePacket.AddSeqId();
		messagePacket.Add(this.reqKingdomIDNum);
		for (int i = 0; i < 16; i++)
		{
			messagePacket.Add(this.reqKingdomID[i]);
			this.lastReqKingdomID[i] = this.reqKingdomID[i];
		}
		for (int j = 0; j < 16; j++)
		{
			messagePacket.Add(0UL);
		}
		messagePacket.Send(false);
		this.wait = 1.5f;
	}

	// Token: 0x06000A07 RID: 2567 RVA: 0x000DA164 File Offset: 0x000D8364
	public void delAllLine()
	{
		for (int i = 0; i < this.MapLineTable.Count; i++)
		{
			if (this.MapLineTable[i].lineID < 1048576u)
			{
				this.delLine(i, 0, 1);
			}
		}
		DataManager.msgBuffer[0] = 92;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06000A08 RID: 2568 RVA: 0x000DA1C8 File Offset: 0x000D83C8
	public void updateCapitalPoint(ushort newZoneID, byte newPointID, ushort newKingdomID, bool gotoCapitalPoint = false)
	{
		bool flag = this.OtherKingdomData.kingdomID == newKingdomID;
		this.updateMyKingdom(newKingdomID, this.kingdomData.kingdomID);
		if (newZoneID >= 1024)
		{
			return;
		}
		DataManager.Instance.RoleAttr.CapitalPoint = GameConstants.PointCodeToMapID(newZoneID, newPointID);
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.GetTerrain(newKingdomID, (uint)DataManager.Instance.RoleAttr.CapitalPoint) == MAP_TERRAIN_KIND.MTK_FOREST)
		{
			DataManager.Instance.CancelShieldItemBuff();
		}
		if (gotoCapitalPoint)
		{
			DataManager.msgBuffer[0] = 83;
			DataManager.msgBuffer[1] = ((!flag) ? 0 : 1);
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			DataManager.msgBuffer[0] = 128;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x06000A09 RID: 2569 RVA: 0x000DA2A4 File Offset: 0x000D84A4
	public bool IsResources(uint layoutMapInfoID)
	{
		POINT_KIND layoutMapInfoPointKind = this.GetLayoutMapInfoPointKind(layoutMapInfoID);
		return layoutMapInfoPointKind > POINT_KIND.PK_NONE && layoutMapInfoPointKind < POINT_KIND.PK_CITY;
	}

	// Token: 0x06000A0A RID: 2570 RVA: 0x000DA2C8 File Offset: 0x000D84C8
	public bool IsCityOrCamp(uint layoutMapInfoID)
	{
		POINT_KIND layoutMapInfoPointKind = this.GetLayoutMapInfoPointKind(layoutMapInfoID);
		return layoutMapInfoPointKind == POINT_KIND.PK_CAMP || layoutMapInfoPointKind == POINT_KIND.PK_CITY;
	}

	// Token: 0x06000A0B RID: 2571 RVA: 0x000DA2EC File Offset: 0x000D84EC
	public POINT_KIND GetLayoutMapInfoPointKind(uint layoutMapInfoID)
	{
		return (POINT_KIND)this.LayoutMapInfo[(int)((UIntPtr)layoutMapInfoID)].pointKind;
	}

	// Token: 0x06000A0C RID: 2572 RVA: 0x000DA300 File Offset: 0x000D8500
	public void GetKingdomName(ushort kindomID, ref CString str)
	{
		str.ClearString();
		KingdomMap recordByKey = this.KingdomMapTable.GetRecordByKey(kindomID);
		if (recordByKey.kingdomName != null)
		{
			for (int i = 0; i < recordByKey.kingdomName.Length; i++)
			{
				str.Append(recordByKey.kingdomName[i]);
			}
		}
	}

	// Token: 0x06000A0D RID: 2573 RVA: 0x000DA35C File Offset: 0x000D855C
	public void UpdateWaitZone()
	{
		if (this.wait != 0f)
		{
			this.wait -= Time.deltaTime;
			if (this.wait < 0f)
			{
				this.wait = 0f;
				if (this.zoneIDNum > 0 && this.checkZone >> (int)this.zoneIDNum != 1)
				{
					this.sendRequestMapdataMsg(false);
				}
				else
				{
					if (this.waitZoneIDNum > 0 && this.waitZoneIDNum < 4)
					{
						this.setLastZoneInfo(this.waitZoneIDNum, this.waitZoneID, false);
					}
					this.waitZoneIDNum = 0;
				}
			}
		}
	}

	// Token: 0x06000A0E RID: 2574 RVA: 0x000DA408 File Offset: 0x000D8608
	public void UpdateWaitKingdom()
	{
		if (this.wait != 0f)
		{
			this.wait -= Time.deltaTime;
			if (this.wait < 0f)
			{
				this.wait = 0f;
				this.sendRequestKingdomMsg();
			}
		}
	}

	// Token: 0x06000A0F RID: 2575 RVA: 0x000DA458 File Offset: 0x000D8658
	public void RequestKingdomData(int minX, int minY, int maxX, int maxY)
	{
		this.reqKingdomIDNum = 0;
		int num = (int)(this.WorldMaxX - this.WorldMinX + 1);
		for (int i = minX; i <= maxX; i++)
		{
			for (int j = minY; j <= maxY; j++)
			{
				int num2 = i + j * num;
				if (this.TileMapKingdomID[num2].KingdomID > 0 && this.CheckKingdomOpen(this.TileMapKingdomID[num2].KingdomID))
				{
					byte in_reqKingdomTableID;
					this.reqKingdomIDNum = (in_reqKingdomTableID = this.reqKingdomIDNum) + 1;
					this.pushReqKingdomID(in_reqKingdomTableID, this.TileMapKingdomID[num2].KingdomID);
				}
			}
		}
		if (this.reqKingdomIDNum == this.lastReqKingdomIDNum)
		{
			int i;
			for (i = 0; i < (int)this.reqKingdomIDNum; i++)
			{
				if (this.reqKingdomID[i] != this.lastReqKingdomID[i])
				{
					break;
				}
			}
			if (i == (int)this.reqKingdomIDNum)
			{
				return;
			}
		}
		else if (this.reqKingdomIDNum < this.lastReqKingdomIDNum)
		{
			int num3 = 0;
			int num4 = 0;
			int i = 0;
			while (i < (int)this.lastReqKingdomIDNum && num3 < (int)this.reqKingdomIDNum)
			{
				if (this.reqKingdomID[num3] == this.lastReqKingdomID[i])
				{
					num3++;
					i++;
					num4++;
				}
				else if (this.lastReqKingdomID[i] > this.reqKingdomID[num3])
				{
					num3++;
				}
				else
				{
					i++;
				}
			}
			if (num4 == (int)this.reqKingdomIDNum)
			{
				return;
			}
		}
		this.sendRequestKingdomMsg();
	}

	// Token: 0x06000A10 RID: 2576 RVA: 0x000DA5F8 File Offset: 0x000D87F8
	public void updateMyKingdom(ushort nowKingdomID, ushort homeKingdomID)
	{
		if (this.kingdomData.kingdomID != homeKingdomID)
		{
			this.kingdomData.kingdomID = homeKingdomID;
			if (this.kingdomData.kingdomID == ActivityManager.Instance.KOWKingdomID)
			{
				this.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
			}
			else if (this.kingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
			{
				this.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
			}
			this.GetKingdomName(this.kingdomData.kingdomID, ref this.kingdomData.kingdomName);
		}
		if (this.OtherKingdomData.kingdomID != nowKingdomID)
		{
			this.OtherKingdomData.kingdomID = nowKingdomID;
			if (this.OtherKingdomData.kingdomID == ActivityManager.Instance.KOWKingdomID)
			{
				this.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
			}
			else if (this.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
			{
				this.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
			}
			this.GetKingdomName(this.OtherKingdomData.kingdomID, ref this.OtherKingdomData.kingdomName);
			LeaderBoardManager.Instance.TotalClear();
			if (this.OtherKingdomData.kingdomID != this.kingdomData.kingdomID && !ActivityManager.Instance.IsKOWRunning(false))
			{
				this.KVKKingdomID = nowKingdomID;
			}
			if (this.FocusKingdomID == 0)
			{
				this.FocusKingdomID = this.OtherKingdomData.kingdomID;
				this.FocusKingdomPeriod = this.OtherKingdomData.kingdomPeriod;
			}
		}
	}

	// Token: 0x06000A11 RID: 2577 RVA: 0x000DA770 File Offset: 0x000D8970
	public bool CheckKingdomID(ushort kingdomID)
	{
		return this.CheckKingdomOpen(kingdomID) && this.KingdomMapTable.GetRecordByKey(kingdomID).KingdomMapKey == kingdomID;
	}

	// Token: 0x06000A12 RID: 2578 RVA: 0x000DA7A4 File Offset: 0x000D89A4
	public uint CheckWonderMapID(uint inMapID, ushort kingdomID)
	{
		Vector2 rhs = Vector2.zero;
		if (kingdomID == this.FocusKingdomID)
		{
			for (ushort num = 0; num < (ushort)this.showYolkNum; num += 1)
			{
				rhs = this.GetYolkPos((ushort)this.showYolkMapYolkID[(int)num], kingdomID);
				rhs.y += 1f;
				uint num2 = (uint)GameConstants.TileMapPosToMapID((int)rhs.x, (int)rhs.y);
				if (num2 == inMapID)
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x + 1, (int)rhs.y - 1))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x - 1, (int)rhs.y - 1))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x + 2, (int)rhs.y - 2))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x, (int)rhs.y - 2))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x - 2, (int)rhs.y - 2))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x + 1, (int)rhs.y - 3))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x - 1, (int)rhs.y - 3))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x, (int)rhs.y - 4))
				{
					return num2;
				}
			}
		}
		else
		{
			Vector2 yolkPos;
			rhs = (yolkPos = this.GetYolkPos(0, kingdomID));
			rhs.y += 1f;
			uint num2 = (uint)GameConstants.TileMapPosToMapID((int)rhs.x, (int)rhs.y);
			if (num2 == inMapID)
			{
				return num2;
			}
			if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x + 1, (int)rhs.y - 1))
			{
				return num2;
			}
			if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x - 1, (int)rhs.y - 1))
			{
				return num2;
			}
			if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x + 2, (int)rhs.y - 2))
			{
				return num2;
			}
			if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x, (int)rhs.y - 2))
			{
				return num2;
			}
			if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x - 2, (int)rhs.y - 2))
			{
				return num2;
			}
			if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x + 1, (int)rhs.y - 3))
			{
				return num2;
			}
			if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x - 1, (int)rhs.y - 3))
			{
				return num2;
			}
			if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x, (int)rhs.y - 4))
			{
				return num2;
			}
			for (ushort num3 = 1; num3 < 40; num3 += 1)
			{
				rhs = this.GetYolkPos(num3, kingdomID);
				if (yolkPos == rhs)
				{
					break;
				}
				rhs.y += 1f;
				num2 = (uint)GameConstants.TileMapPosToMapID((int)rhs.x, (int)rhs.y);
				if (num2 == inMapID)
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x + 1, (int)rhs.y - 1))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x - 1, (int)rhs.y - 1))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x + 2, (int)rhs.y - 2))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x, (int)rhs.y - 2))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x - 2, (int)rhs.y - 2))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x + 1, (int)rhs.y - 3))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x - 1, (int)rhs.y - 3))
				{
					return num2;
				}
				if (inMapID == (uint)GameConstants.TileMapPosToMapID((int)rhs.x, (int)rhs.y - 4))
				{
					return num2;
				}
			}
		}
		return 40u;
	}

	// Token: 0x06000A13 RID: 2579 RVA: 0x000DABD4 File Offset: 0x000D8DD4
	public void ClearAll()
	{
		this.delAllLine();
		this.zoneIDNum = 0;
		byte b = 0;
		while ((int)b < this.RAMSataeInfo.Length)
		{
			if (this.RAMSataeInfo[(int)b].zoneID < 1024)
			{
				this.freeZonePoint(this.RAMSataeInfo[(int)b].zoneID);
				this.ZoneUpdateInfo[(int)this.RAMSataeInfo[(int)b].zoneID].updateNum = 0UL;
			}
			this.RAMSataeInfo[(int)b].sortID = (this.sortRAMReplaceNum[(int)b] = b);
			this.RAMSataeInfo[(int)b].replaceNum = 0u;
			this.RAMSataeInfo[(int)b].zoneID = 1024;
			b += 1;
		}
		Array.Clear(this.ZoneUpdateInfo, 0, 1024);
	}

	// Token: 0x06000A14 RID: 2580 RVA: 0x000DACB4 File Offset: 0x000D8EB4
	public MAP_TERRAIN_KIND GetTerrain(byte mapinfoID)
	{
		return (mapinfoID >= 35) ? ((mapinfoID >= 69) ? ((mapinfoID >= 99) ? ((mapinfoID >= 113) ? MAP_TERRAIN_KIND.MTK_NONE : MAP_TERRAIN_KIND.MTK_FOREST) : MAP_TERRAIN_KIND.MTK_FROZEN) : MAP_TERRAIN_KIND.MTK_LAVA) : MAP_TERRAIN_KIND.MTK_PRAIRIE;
	}

	// Token: 0x06000A15 RID: 2581 RVA: 0x000DACFC File Offset: 0x000D8EFC
	public float CheckLenght(Vector2 point)
	{
		point -= GameConstants.getTileMapPosbySpriteID(DataManager.Instance.RoleAttr.CapitalPoint);
		return (point.sqrMagnitude >= 179776f) ? 0f : point.magnitude;
	}

	// Token: 0x06000A16 RID: 2582 RVA: 0x000DAD48 File Offset: 0x000D8F48
	public bool CheckKingdomOpen(ushort check_kingdomID)
	{
		if (this.KingdomOpenFlag == null || check_kingdomID == 0)
		{
			return false;
		}
		ushort num;
		byte b;
		this.GetKingdomOpenIndexShift(check_kingdomID, out num, out b);
		return (int)num < this.KingdomOpenFlag.Length && ((int)this.KingdomOpenFlag[(int)num] & 1 << (int)b) > 0;
	}

	// Token: 0x06000A17 RID: 2583 RVA: 0x000DAD98 File Offset: 0x000D8F98
	public void UpdateKingdomInWorld()
	{
		if (this.KingdomOpenFlag == null)
		{
			return;
		}
		ushort num = 0;
		for (int i = this.KingdomOpenFlag.Length - 1; i > -1; i--)
		{
			for (int j = 7; j > -1; j--)
			{
				if (((int)this.KingdomOpenFlag[i] & 1 << j) > 0)
				{
					num = (ushort)((i << 3) + j + 1);
					break;
				}
			}
			if (num != 0)
			{
				break;
			}
		}
		if ((int)num > this.KingdomMapTable.TableCount)
		{
			num = (ushort)this.KingdomMapTable.TableCount;
		}
		if (num == 0)
		{
			return;
		}
		this.KingdomIDposOrder = new ushort[(int)num];
		Array.Clear(this.KingdomIDposOrder, 0, this.KingdomIDposOrder.Length);
		KingdomMap recordByIndex = this.KingdomMapTable.GetRecordByIndex(0);
		this.WorldOX = (this.WorldMaxX = (this.WorldMinX = recordByIndex.worldPosX));
		this.WorldOY = (this.WorldMaxY = (this.WorldMinY = recordByIndex.worldPosY));
		this.KingdomIDposOrder[0] = recordByIndex.KingdomMapKey;
		for (int k = 1; k < this.KingdomIDposOrder.Length; k++)
		{
			recordByIndex = this.KingdomMapTable.GetRecordByIndex(k);
			if (recordByIndex.worldPosX > this.WorldMaxX)
			{
				this.WorldMaxX = recordByIndex.worldPosX;
			}
			if (recordByIndex.worldPosX < this.WorldMinX)
			{
				this.WorldMinX = recordByIndex.worldPosX;
			}
			if (recordByIndex.worldPosY > this.WorldMaxY)
			{
				this.WorldMaxY = recordByIndex.worldPosY;
			}
			if (recordByIndex.worldPosY < this.WorldMinY)
			{
				this.WorldMinY = recordByIndex.worldPosY;
			}
			this.KingdomIDposOrder[k] = recordByIndex.KingdomMapKey;
			for (int l = k - 1; l > -1; l--)
			{
				KingdomMap recordByKey = this.KingdomMapTable.GetRecordByKey(this.KingdomIDposOrder[l]);
				if (recordByIndex.worldPosX == recordByKey.worldPosX)
				{
					if (recordByIndex.worldPosY >= recordByKey.worldPosY)
					{
						break;
					}
					this.KingdomIDposOrder[l + 1] = recordByKey.KingdomMapKey;
					this.KingdomIDposOrder[l] = recordByIndex.KingdomMapKey;
				}
				else
				{
					if (recordByIndex.worldPosX >= recordByKey.worldPosX)
					{
						break;
					}
					this.KingdomIDposOrder[l + 1] = recordByKey.KingdomMapKey;
					this.KingdomIDposOrder[l] = recordByIndex.KingdomMapKey;
				}
			}
		}
		int num2 = (int)(this.WorldMaxX - this.WorldMinX + 1);
		int num3 = 10 - (num2 + 8);
		int num4 = (int)(this.WorldMinX - this.WorldOX & 1);
		if ((num2 & 1) == 1)
		{
			if (num3 > 0)
			{
				num3 = (int)((float)(10 - num2) * 0.5f);
			}
			else
			{
				num3 = num2 + 8;
				num3 += (num3 & 1);
				num3 -= num2;
				num3 = (int)((float)num3 * 0.5f);
			}
			this.WorldMaxX += (ushort)num3;
			this.WorldMinX -= (ushort)num3;
			if (num4 == 1)
			{
				if ((num3 & 1) == 1)
				{
					this.WorldMaxX += 1;
				}
				else
				{
					this.WorldMinX -= 1;
				}
			}
			else if ((num3 & 1) == 0)
			{
				this.WorldMaxX += 1;
			}
			else
			{
				this.WorldMinX -= 1;
			}
		}
		else
		{
			if (num3 > 0)
			{
				num3 = (int)((float)(10 - num2) * 0.5f);
			}
			else
			{
				num3 = 4;
			}
			this.WorldMaxX += (ushort)num3;
			this.WorldMinX -= (ushort)num3;
			if (num4 == 1)
			{
				if ((num3 & 1) == 0)
				{
					this.WorldMaxX += 1;
					this.WorldMinX -= 1;
				}
			}
			else if ((num3 & 1) == 1)
			{
				this.WorldMaxX += 1;
				this.WorldMinX -= 1;
			}
		}
		int num5 = (int)(this.WorldMaxY - this.WorldMinY + 1);
		num3 = 16 - (num5 + 8);
		num4 = (int)(this.WorldMinY - this.WorldOY & 1);
		if ((num5 & 1) == 1)
		{
			if (num3 > 0)
			{
				num3 = (int)((float)(16 - num5) * 0.5f);
			}
			else
			{
				num3 = num5 + 8;
				num3 += (num3 & 1);
				num3 -= num5;
				num3 = (int)((float)num3 * 0.5f);
			}
			this.WorldMaxY += (ushort)num3;
			this.WorldMinY -= (ushort)num3;
			if (num4 == 1)
			{
				if ((num3 & 1) == 1)
				{
					this.WorldMaxY += 1;
				}
				else
				{
					this.WorldMinY -= 1;
				}
			}
			else if ((num3 & 1) == 0)
			{
				this.WorldMaxY += 1;
			}
			else
			{
				this.WorldMinY -= 1;
			}
		}
		else
		{
			if (num3 > 0)
			{
				num3 = (int)((float)(16 - num5) * 0.5f);
			}
			else
			{
				num3 = 4;
			}
			this.WorldMaxY += (ushort)num3;
			this.WorldMinY -= (ushort)num3;
			if (num4 == 1)
			{
				if ((num3 & 1) == 0)
				{
					this.WorldMaxY += 1;
					this.WorldMinY -= 1;
				}
			}
			else if ((num3 & 1) == 1)
			{
				this.WorldMaxY += 1;
				this.WorldMinY -= 1;
			}
		}
		num2 = (int)(this.WorldMaxX - this.WorldMinX + 1);
		num5 = (int)(this.WorldMaxY - this.WorldMinY + 1);
		bool flag = false;
		if (this.TileMapKingdomID == null)
		{
			this.TileMapKingdomID = new MapKingdom[num2 * num5];
		}
		else if (this.TileMapKingdomID.Length != num2 * num5)
		{
			flag = true;
			this.TileMapKingdomID = new MapKingdom[num2 * num5];
		}
		Array.Clear(this.TileMapKingdomID, 0, this.TileMapKingdomID.Length);
		for (int m = 0; m < this.KingdomIDposOrder.Length; m++)
		{
			if (this.CheckKingdomOpen((ushort)(m + 1)))
			{
				recordByIndex = this.KingdomMapTable.GetRecordByIndex(m);
				int num6 = (int)(recordByIndex.worldPosX - this.WorldMinX) + (int)(recordByIndex.worldPosY - this.WorldMinY) * num2;
				this.TileMapKingdomID[num6].KingdomID = recordByIndex.KingdomMapKey;
				if (flag)
				{
					byte b = this.WorldKingdomTableIDcounter - 1;
					b &= 31;
					byte b2 = 0;
					while ((int)b2 < this.WorldKingdomTable.Length)
					{
						if (this.WorldKingdomTable[(int)b].kingdomID == this.TileMapKingdomID[num6].KingdomID)
						{
							this.TileMapKingdomID[num6].tableID = b;
							break;
						}
						b -= 1;
						b &= 31;
						b2 += 1;
					}
				}
			}
		}
	}

	// Token: 0x06000A18 RID: 2584 RVA: 0x000DB4EC File Offset: 0x000D96EC
	public void INIT_OPENKINGDOMINFO(MessagePacket MP)
	{
		for (int i = 0; i < DataManager.DataBuffer.Length; i++)
		{
			DataManager.DataBuffer[i] = MP.ReadByte(-1);
		}
		for (int j = 0; j < 38 - DataManager.msgBuffer.Length; j++)
		{
			DataManager.msgBuffer[j] = MP.ReadByte(-1);
		}
		byte b = MP.ReadByte(-1);
		if (b < 38)
		{
			b = 38;
		}
		if (this.KingdomOpenFlag == null)
		{
			this.KingdomOpenFlag = new byte[(int)b];
			for (int k = 0; k < DataManager.DataBuffer.Length; k++)
			{
				this.KingdomOpenFlag[k] = DataManager.DataBuffer[k];
			}
			for (int l = DataManager.DataBuffer.Length; l < 38; l++)
			{
				this.KingdomOpenFlag[l] = DataManager.msgBuffer[l - DataManager.DataBuffer.Length];
			}
			for (int m = 38; m < this.KingdomOpenFlag.Length; m++)
			{
				this.KingdomOpenFlag[m] = MP.ReadByte(-1);
			}
			this.UpdateKingdomInWorld();
		}
		else
		{
			bool flag = false;
			if (this.KingdomOpenFlag.Length != (int)b)
			{
				flag = true;
				this.KingdomOpenFlag = new byte[(int)b];
				for (int n = 0; n < DataManager.DataBuffer.Length; n++)
				{
					this.KingdomOpenFlag[n] = DataManager.DataBuffer[n];
				}
				for (int num = DataManager.DataBuffer.Length; num < 38; num++)
				{
					this.KingdomOpenFlag[num] = DataManager.msgBuffer[num - DataManager.DataBuffer.Length];
				}
				for (int num2 = 38; num2 < this.KingdomOpenFlag.Length; num2++)
				{
					this.KingdomOpenFlag[num2] = MP.ReadByte(-1);
				}
			}
			else
			{
				for (int num3 = 0; num3 < DataManager.DataBuffer.Length; num3++)
				{
					if (this.KingdomOpenFlag[num3] != DataManager.DataBuffer[num3])
					{
						flag = true;
						this.KingdomOpenFlag[num3] = DataManager.DataBuffer[num3];
					}
				}
				for (int num4 = DataManager.DataBuffer.Length; num4 < 38; num4++)
				{
					if (this.KingdomOpenFlag[num4] != DataManager.msgBuffer[num4 - DataManager.DataBuffer.Length])
					{
						flag = true;
						this.KingdomOpenFlag[num4] = DataManager.msgBuffer[num4 - DataManager.DataBuffer.Length];
					}
				}
				for (int num5 = 38; num5 < this.KingdomOpenFlag.Length; num5++)
				{
					byte b2 = MP.ReadByte(-1);
					if (b2 != this.KingdomOpenFlag[num5])
					{
						flag = true;
						this.KingdomOpenFlag[num5] = b2;
					}
				}
			}
			if (flag)
			{
				this.UpdateKingdomInWorld();
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door != null && door.m_eMapMode == EUIOriginMapMode.WorldMap)
				{
					this.gotoKingdomState = byte.MaxValue;
					this.gotokingdomID = this.OtherKingdomData.kingdomID;
					this.FocusWorldMapPos = -Vector2.one;
					GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToWorld);
				}
			}
		}
	}

	// Token: 0x06000A19 RID: 2585 RVA: 0x000DB81C File Offset: 0x000D9A1C
	public void UPDATE_OPENKINGDOMINFO(MessagePacket MP)
	{
		if (this.KingdomOpenFlag == null)
		{
			return;
		}
		ushort num = MP.ReadUShort(-1);
		if (num == 0)
		{
			return;
		}
		ushort num2;
		byte b;
		this.GetKingdomOpenIndexShift(num, out num2, out b);
		if ((int)num2 < this.KingdomOpenFlag.Length)
		{
			byte[] kingdomOpenFlag = this.KingdomOpenFlag;
			ushort num3 = num2;
			kingdomOpenFlag[(int)num3] = (kingdomOpenFlag[(int)num3] | (byte)(1 << (int)b));
			this.UpdateKingdomInWorld();
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null && door.m_eMapMode == EUIOriginMapMode.WorldMap)
			{
				this.gotoKingdomState = byte.MaxValue;
				this.gotokingdomID = this.OtherKingdomData.kingdomID;
				this.FocusWorldMapPos = -Vector2.one;
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToWorld);
			}
		}
	}

	// Token: 0x06000A1A RID: 2586 RVA: 0x000DB8E4 File Offset: 0x000D9AE4
	public void MY_KINGDOMINFO(MessagePacket MP)
	{
		for (MAP_KINGDOMINFO_KIND map_KINGDOMINFO_KIND = (MAP_KINGDOMINFO_KIND)MP.ReadByte(-1); map_KINGDOMINFO_KIND != MAP_KINGDOMINFO_KIND.MAPKINFO_NONE; map_KINGDOMINFO_KIND = (MAP_KINGDOMINFO_KIND)MP.ReadByte(-1))
		{
			ushort num = MP.ReadUShort(-1);
			MAP_KINGDOMINFO_KIND map_KINGDOMINFO_KIND2 = map_KINGDOMINFO_KIND;
			if (map_KINGDOMINFO_KIND2 != MAP_KINGDOMINFO_KIND.MAPKINFO_KINGDOMTIME)
			{
				for (ushort num2 = 0; num2 < num; num2 += 1)
				{
					MP.ReadByte(-1);
				}
			}
			else
			{
				ushort num3 = MP.ReadUShort(-1);
				ulong kingdomTime = MP.ReadULong(-1);
				if (num3 == this.kingdomData.kingdomID)
				{
					this.kingdomData.kingdomTime = kingdomTime;
				}
				if (num3 == this.OtherKingdomData.kingdomID)
				{
					this.OtherKingdomData.kingdomTime = kingdomTime;
				}
				byte b = this.WorldKingdomTableIDcounter - 1;
				b &= 31;
				byte b2 = 0;
				while ((int)b2 < this.WorldKingdomTable.Length)
				{
					if (this.WorldKingdomTable[(int)b].kingdomID == num3)
					{
						this.WorldKingdomTable[(int)b].kingdomTime = kingdomTime;
						break;
					}
					b -= 1;
					b &= 31;
					b2 += 1;
				}
			}
		}
	}

	// Token: 0x06000A1B RID: 2587 RVA: 0x000DBA0C File Offset: 0x000D9C0C
	public void addLine(int mapLineTableID)
	{
		if ((this.MapLineTable[mapLineTableID].start.zoneID & 1023) == this.MapLineTable[mapLineTableID].end.zoneID)
		{
			int zoneState = (int)this.ZoneUpdateInfo[(int)(this.MapLineTable[mapLineTableID].start.zoneID & 1023)].zoneState;
			this.MapLineTable[mapLineTableID].ZoneIDTable[zoneState] = this.ZoneLineIDTable[zoneState].Count;
			this.MapLineTable[mapLineTableID].zoneNum = 1;
			ZoneLine item;
			item.lineID = this.MapLineTable[mapLineTableID].lineID;
			item.lineTableID = (ushort)mapLineTableID;
			this.ZoneLineIDTable[zoneState].Add(item);
		}
		else
		{
			double num = Math.Round(640000000000.0);
			Vector2 vector = GameConstants.getTileMapPosbyPointCode(this.MapLineTable[mapLineTableID].start.zoneID, 0);
			Vector2 vector2 = GameConstants.getTileMapPosbyPointCode(this.MapLineTable[mapLineTableID].end.zoneID, 0);
			this.MapLineTable[mapLineTableID].zoneMin.x = ((vector.x >= vector2.x) ? (vector2.x * 2f) : (vector.x * 2f));
			this.MapLineTable[mapLineTableID].zoneMin.y = ((vector.y >= vector2.y) ? vector2.y : vector.y);
			vector = GameConstants.getTileMapPosbyPointCode(this.MapLineTable[mapLineTableID].start.zoneID, byte.MaxValue) + Vector2.one;
			vector2 = GameConstants.getTileMapPosbyPointCode(this.MapLineTable[mapLineTableID].end.zoneID, byte.MaxValue) + Vector2.one;
			this.MapLineTable[mapLineTableID].zoneMax.x = ((vector.x >= vector2.x) ? (vector.x * 2f) : (vector2.x * 2f));
			this.MapLineTable[mapLineTableID].zoneMax.y = ((vector.y >= vector2.y) ? vector.y : vector2.y);
			vector = GameConstants.getTileMapPosbyPointCode(this.MapLineTable[mapLineTableID].start.zoneID, this.MapLineTable[mapLineTableID].start.pointID);
			vector.x *= 2f;
			vector2 = GameConstants.getTileMapPosbyPointCode(this.MapLineTable[mapLineTableID].end.zoneID, this.MapLineTable[mapLineTableID].end.pointID);
			vector2.x *= 2f;
			double num2 = (double)(vector2.x - vector.x);
			if (num2 == 0.0)
			{
				this.MapLineTable[mapLineTableID].XIntercept = (double)vector.x;
			}
			else
			{
				this.MapLineTable[mapLineTableID].XIntercept = -1.0;
				this.MapLineTable[mapLineTableID].Slope = (double)(vector2.y - vector.y) / num2;
				this.MapLineTable[mapLineTableID].YIntercept = (double)vector.y - this.MapLineTable[mapLineTableID].Slope * (double)vector.x;
			}
			for (int i = 0; i < this.RAMSataeInfo.Length; i++)
			{
				if (this.RAMSataeInfo[i].zoneID != 1024)
				{
					bool flag = this.MapLineTable[mapLineTableID].start.zoneID == this.RAMSataeInfo[i].zoneID || this.MapLineTable[mapLineTableID].end.zoneID == this.RAMSataeInfo[i].zoneID;
					if (!flag)
					{
						vector = GameConstants.getTileMapPosbyPointCode(this.RAMSataeInfo[i].zoneID, 0);
						vector.x *= 2f;
						if (vector.x < this.MapLineTable[mapLineTableID].zoneMax.x && vector.x >= this.MapLineTable[mapLineTableID].zoneMin.x && vector.y < this.MapLineTable[mapLineTableID].zoneMax.y && vector.y >= this.MapLineTable[mapLineTableID].zoneMin.y)
						{
							if (this.MapLineTable[mapLineTableID].XIntercept < 0.0)
							{
								if (this.MapLineTable[mapLineTableID].Slope == 0.0)
								{
									flag = (this.MapLineTable[mapLineTableID].YIntercept >= (double)vector.y && this.MapLineTable[mapLineTableID].YIntercept < (double)(vector.y + 16f));
								}
								else
								{
									double num3 = this.MapLineTable[mapLineTableID].Slope * (double)vector.x + this.MapLineTable[mapLineTableID].YIntercept;
									num3 = Math.Round(num3 * 10000000000.0);
									double num4 = this.MapLineTable[mapLineTableID].Slope * (double)(vector.x + 64f) + this.MapLineTable[mapLineTableID].YIntercept;
									num4 = Math.Round(num4 * 10000000000.0);
									num2 = ((double)vector.y - this.MapLineTable[mapLineTableID].YIntercept) / this.MapLineTable[mapLineTableID].Slope;
									num2 = Math.Round(num2 * 10000000000.0);
									double num5 = ((double)(vector.y + 16f) - this.MapLineTable[mapLineTableID].YIntercept) / this.MapLineTable[mapLineTableID].Slope;
									num5 = Math.Round(num5 * 10000000000.0);
									double num6 = Math.Round((double)(vector.y * 1E+10f));
									double num7 = Math.Round((double)(vector.x * 1E+10f));
									double num8 = Math.Round(160000000000.0);
									flag = ((num3 >= num6 && num3 < num6 + num8) || (num4 > num6 && num4 < num6 + num8) || (num2 >= num7 && num2 < num7 + num) || (num5 > num7 && num5 < num7 + num) || (num4 == num6 && num4 + num8 == num3 && num5 == num7 && num5 + num == num2));
								}
							}
							else
							{
								flag = (this.MapLineTable[mapLineTableID].XIntercept >= (double)vector.x && this.MapLineTable[mapLineTableID].XIntercept < (double)(vector.x + 64f));
							}
						}
					}
					if (flag)
					{
						int zoneState2 = (int)this.ZoneUpdateInfo[(int)this.RAMSataeInfo[i].zoneID].zoneState;
						this.MapLineTable[mapLineTableID].ZoneIDTable[zoneState2] = this.ZoneLineIDTable[zoneState2].Count;
						MapLine mapLine = this.MapLineTable[mapLineTableID];
						mapLine.zoneNum += 1;
						ZoneLine item2;
						item2.lineID = this.MapLineTable[mapLineTableID].lineID;
						item2.lineTableID = (ushort)mapLineTableID;
						this.ZoneLineIDTable[zoneState2].Add(item2);
					}
				}
			}
		}
		this.LineNotifyObserver(56, mapLineTableID, 1, 0);
	}

	// Token: 0x06000A1C RID: 2588 RVA: 0x000DC280 File Offset: 0x000DA480
	public void delLine(int mapLineTableID, byte Send = 1, byte bDelAll = 0)
	{
		for (int i = 0; i < this.MapLineTable[mapLineTableID].ZoneIDTable.Length; i++)
		{
			if (this.MapLineTable[mapLineTableID].ZoneIDTable[i] != 1048576)
			{
				for (int j = this.ZoneLineIDTable[i].Count - 1; j > this.MapLineTable[mapLineTableID].ZoneIDTable[i]; j--)
				{
					this.MapLineTable[(int)this.ZoneLineIDTable[i][j].lineTableID].ZoneIDTable[i]--;
				}
				this.ZoneLineIDTable[i].RemoveAt(this.MapLineTable[mapLineTableID].ZoneIDTable[i]);
				this.MapLineTable[mapLineTableID].ZoneIDTable[i] = 1048576;
				this.LineDelZone(mapLineTableID, Send, bDelAll);
			}
		}
	}

	// Token: 0x06000A1D RID: 2589 RVA: 0x000DC374 File Offset: 0x000DA574
	public bool IsWorldKing()
	{
		return DataManager.Instance.RoleAttr.WorldTitle_Personal == 1;
	}

	// Token: 0x06000A1E RID: 2590 RVA: 0x000DC388 File Offset: 0x000DA588
	public bool IsWorldChief()
	{
		return DataManager.Instance.RoleAttr.WorldTitle_Personal == 14;
	}

	// Token: 0x06000A1F RID: 2591 RVA: 0x000DC3A0 File Offset: 0x000DA5A0
	public bool IsKing()
	{
		return DataManager.Instance.RoleAttr.KingdomTitle == 1;
	}

	// Token: 0x06000A20 RID: 2592 RVA: 0x000DC3B4 File Offset: 0x000DA5B4
	public bool IsKingdomChief()
	{
		return DataManager.Instance.RoleAttr.KingdomTitle == 20;
	}

	// Token: 0x06000A21 RID: 2593 RVA: 0x000DC3CC File Offset: 0x000DA5CC
	public bool IsNobilityKing()
	{
		return DataManager.Instance.RoleAttr.NobilityTitle == 1;
	}

	// Token: 0x06000A22 RID: 2594 RVA: 0x000DC3E0 File Offset: 0x000DA5E0
	public bool IsNobilityChief()
	{
		return DataManager.Instance.RoleAttr.NobilityTitle == 14;
	}

	// Token: 0x06000A23 RID: 2595 RVA: 0x000DC3F8 File Offset: 0x000DA5F8
	public bool IsFocusKing(ushort LeaderHomeKingdomID)
	{
		return LeaderHomeKingdomID == this.FocusKingdomID;
	}

	// Token: 0x06000A24 RID: 2596 RVA: 0x000DC404 File Offset: 0x000DA604
	public bool IsFocusWorldWar()
	{
		return ((this.FocusKingdomID <= 0 || this.OtherKingdomData.kingdomID == this.FocusKingdomID) ? this.OtherKingdomData.kingdomID : this.FocusKingdomID) == ActivityManager.Instance.KOWKingdomID;
	}

	// Token: 0x06000A25 RID: 2597 RVA: 0x000DC458 File Offset: 0x000DA658
	public bool IsPeaceState(bool bShowMsg = false, byte wonderID = 0)
	{
		MapYolk mapYolk;
		if ((int)wonderID < this.YolkPointTable.Length)
		{
			mapYolk = this.YolkPointTable[(int)wonderID];
		}
		else
		{
			mapYolk = this.YolkPointTable[0];
		}
		if (mapYolk.WonderState != 0)
		{
			if (bShowMsg)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9719u), 255, true);
			}
			return false;
		}
		return true;
	}

	// Token: 0x06000A26 RID: 2598 RVA: 0x000DC4D8 File Offset: 0x000DA6D8
	public bool IsInMyKingdom(bool bShowMsg = false)
	{
		if (this.FocusKingdomID == 0 || this.kingdomData.kingdomID == this.FocusKingdomID)
		{
			return true;
		}
		if (bShowMsg)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7744u), 255, true);
		}
		return false;
	}

	// Token: 0x06000A27 RID: 2599 RVA: 0x000DC534 File Offset: 0x000DA734
	public bool IsInMyAllianceKingdom(bool bShowMsg = false)
	{
		if (this.FocusKingdomID == 0 || this.kingdomData.kingdomID == this.FocusKingdomID)
		{
			return true;
		}
		if (bShowMsg)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7744u), 255, true);
		}
		return false;
	}

	// Token: 0x06000A28 RID: 2600 RVA: 0x000DC590 File Offset: 0x000DA790
	public bool CheckKingFunction(eKingFunction func)
	{
		DataManager instance = DataManager.Instance;
		if (func != eKingFunction.eTitle && !this.IsPeaceState(true, 0))
		{
			return false;
		}
		if (!this.IsKing())
		{
			GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(1460u), 255, true);
			return false;
		}
		if (func != eKingFunction.eTitle && this.FocusKingdomID != 0 && this.kingdomData.kingdomID != this.FocusKingdomID)
		{
			GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(9720u), 255, true);
			return false;
		}
		if (func == eKingFunction.eAmnesty && this.FocusKingdomID != 0 && this.kingdomData.kingdomID != this.FocusKingdomID)
		{
			GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(7744u), 255, true);
			return false;
		}
		if ((func == eKingFunction.eReward || func == eKingFunction.eStrengthen) && this.FocusKingdomID != 0 && this.OtherKingdomData.kingdomID != this.FocusKingdomID)
		{
			GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(7744u), 255, true);
			return false;
		}
		return true;
	}

	// Token: 0x06000A29 RID: 2601 RVA: 0x000DC6CC File Offset: 0x000DA8CC
	public bool CheckWorldKingFunction(eWorldKingFunction func)
	{
		if (func != eWorldKingFunction.ePersionalTitle && func != eWorldKingFunction.eWorldTitle && !this.IsPeaceState(true, 0))
		{
			return false;
		}
		if (!this.IsWorldKing())
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5791u), 255, true);
			return false;
		}
		if (func == eWorldKingFunction.eReward && DataManager.Instance.RoleAlliance.Id == 0u)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(689u), 255, true);
			return false;
		}
		return true;
	}

	// Token: 0x06000A2A RID: 2602 RVA: 0x000DC768 File Offset: 0x000DA968
	public bool CheckNobilityFunction(eNobilityFunction func, byte wonderID)
	{
		if (func != eNobilityFunction.eTitle && !this.IsPeaceState(true, wonderID))
		{
			return false;
		}
		if (func == eNobilityFunction.eReward && DataManager.Instance.RoleAlliance.Id == 0u)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(689u), 255, true);
			return false;
		}
		return true;
	}

	// Token: 0x06000A2B RID: 2603 RVA: 0x000DC7CC File Offset: 0x000DA9CC
	public ulong GetKingdomTime(ushort kingdomID)
	{
		if (!this.CheckKingdomOpen(kingdomID))
		{
			return 0UL;
		}
		if (kingdomID == this.kingdomData.kingdomID)
		{
			return this.kingdomData.kingdomTime;
		}
		if (kingdomID == this.OtherKingdomData.kingdomID)
		{
			return this.OtherKingdomData.kingdomTime;
		}
		KingdomMap recordByKey = this.KingdomMapTable.GetRecordByKey(kingdomID);
		int num = (int)(this.WorldMaxX - this.WorldMinX + 1);
		int num2 = (int)(recordByKey.worldPosX - this.WorldMinX) + (int)(recordByKey.worldPosY - this.WorldMinY) * num;
		byte tableID = this.TileMapKingdomID[num2].tableID;
		if (this.TileMapKingdomID[num2].KingdomID == kingdomID && this.WorldKingdomTable[(int)tableID].kingdomID == kingdomID)
		{
			return this.WorldKingdomTable[(int)tableID].kingdomTime;
		}
		if (this.FocusKingdomTime != 0UL)
		{
			return this.FocusKingdomTime;
		}
		return 0UL;
	}

	// Token: 0x06000A2C RID: 2604 RVA: 0x000DC8C8 File Offset: 0x000DAAC8
	public bool GetWorldKingdomTableID(ushort kingdomID, out byte kingdomTableID)
	{
		kingdomTableID = 32;
		KingdomMap recordByKey = this.KingdomMapTable.GetRecordByKey(kingdomID);
		int num = (int)(this.WorldMaxX - this.WorldMinX + 1);
		int num2 = (int)(recordByKey.worldPosX - this.WorldMinX) + (int)(recordByKey.worldPosY - this.WorldMinY) * num;
		if (num2 < this.TileMapKingdomID.Length)
		{
			byte tableID = this.TileMapKingdomID[num2].tableID;
			if (this.TileMapKingdomID[num2].KingdomID == kingdomID && (int)tableID < this.WorldKingdomTable.Length && this.WorldKingdomTable[(int)tableID].kingdomID == kingdomID)
			{
				kingdomTableID = tableID;
			}
		}
		return kingdomTableID != 32;
	}

	// Token: 0x06000A2D RID: 2605 RVA: 0x000DC980 File Offset: 0x000DAB80
	public bool IsEnemy(ushort kingdomID)
	{
		byte b = 0;
		KINGDOM_PERIOD kingdom_PERIOD;
		if (kingdomID == this.OtherKingdomData.kingdomID)
		{
			kingdom_PERIOD = this.OtherKingdomData.kingdomPeriod;
		}
		else if (this.FocusKingdomID == kingdomID)
		{
			kingdom_PERIOD = this.FocusKingdomPeriod;
		}
		else
		{
			if (!this.GetWorldKingdomTableID(kingdomID, out b))
			{
				return this.FocusKingdomPeriod == KINGDOM_PERIOD.KP_KVK && kingdomID != this.kingdomData.kingdomID && (!ActivityManager.Instance.IsMatchKvk() || ActivityManager.Instance.CheckIsMatchKingdom(kingdomID));
			}
			kingdom_PERIOD = this.WorldKingdomTable[(int)b].kingdomPeriod;
		}
		return kingdom_PERIOD == KINGDOM_PERIOD.KP_KVK && kingdomID != this.kingdomData.kingdomID && (!ActivityManager.Instance.IsMatchKvk() || ActivityManager.Instance.CheckIsMatchKingdom(kingdomID));
	}

	// Token: 0x06000A2E RID: 2606 RVA: 0x000DCA74 File Offset: 0x000DAC74
	public void UpdateKingdomPeriod(KINGDOM_PERIOD in_Period = KINGDOM_PERIOD.KP_KVK)
	{
		byte b = this.WorldKingdomTableIDcounter - 1;
		b &= 31;
		if (in_Period == KINGDOM_PERIOD.KP_KVK)
		{
			byte b2 = 0;
			while ((int)b2 < this.WorldKingdomTable.Length)
			{
				if (this.WorldKingdomTable[(int)b].kingdomID != 0)
				{
					KingdomMap recordByKey = this.KingdomMapTable.GetRecordByKey(this.WorldKingdomTable[(int)b].kingdomID);
					int num = (int)(this.WorldMaxX - this.WorldMinX + 1);
					int num2 = (int)(recordByKey.worldPosX - this.WorldMinX) + (int)(recordByKey.worldPosY - this.WorldMinY) * num;
					if (this.TileMapKingdomID[num2].tableID == b && this.WorldKingdomTable[(int)b].kingdomPeriod != KINGDOM_PERIOD.KP_WORLD_WAR && this.WorldKingdomTable[(int)b].kingdomTime + 7776000UL <= (ulong)DataManager.Instance.ServerTime && this.WorldKingdomTable[(int)b].kingdomPeriod != in_Period)
					{
						this.WorldKingdomTable[(int)b].kingdomPeriod = in_Period;
						this.KingdomNotifyObserver(b, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_PERIOD);
					}
				}
				b -= 1;
				b &= 31;
				b2 += 1;
			}
		}
		else if (in_Period == KINGDOM_PERIOD.KP_INFIGHTING)
		{
			byte b3 = 0;
			while ((int)b3 < this.WorldKingdomTable.Length)
			{
				if (this.WorldKingdomTable[(int)b].kingdomID != 0)
				{
					KingdomMap recordByKey2 = this.KingdomMapTable.GetRecordByKey(this.WorldKingdomTable[(int)b].kingdomID);
					int num3 = (int)(this.WorldMaxX - this.WorldMinX + 1);
					int num4 = (int)(recordByKey2.worldPosX - this.WorldMinX) + (int)(recordByKey2.worldPosY - this.WorldMinY) * num3;
					if (this.TileMapKingdomID[num4].tableID == b && this.WorldKingdomTable[(int)b].kingdomPeriod != KINGDOM_PERIOD.KP_WORLD_WAR && this.WorldKingdomTable[(int)b].kingdomPeriod != in_Period)
					{
						this.WorldKingdomTable[(int)b].kingdomPeriod = in_Period;
						this.KingdomNotifyObserver(b, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_PERIOD);
					}
				}
				b -= 1;
				b &= 31;
				b3 += 1;
			}
		}
	}

	// Token: 0x06000A2F RID: 2607 RVA: 0x000DCCA8 File Offset: 0x000DAEA8
	public void KingdomNotifyObserver(byte kingdomtableid, MAP_UPDATE_KIND updatekind)
	{
		if (this.WorldKingdomTable[(int)kingdomtableid].kingdomID == this.kingdomData.kingdomID)
		{
			if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_OWNERKINGDOMID)
			{
				this.kingdomData.allianceKingdomID = this.WorldKingdomTable[(int)kingdomtableid].allianceKingdomID;
				this.kingdomData.kingKingdomID = this.WorldKingdomTable[(int)kingdomtableid].kingKingdomID;
			}
			if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_TIME)
			{
				this.kingdomData.kingdomTime = this.WorldKingdomTable[(int)kingdomtableid].kingdomTime;
			}
			if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_FLAG)
			{
				this.kingdomData.kingdomFlag = this.WorldKingdomTable[(int)kingdomtableid].kingdomFlag;
			}
			if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_PERIOD)
			{
				this.kingdomData.kingdomPeriod = this.WorldKingdomTable[(int)kingdomtableid].kingdomPeriod;
			}
			if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_ALLIANCE)
			{
				this.kingdomData.kingName.ClearString();
				for (int i = 0; i < this.WorldKingdomTable[(int)kingdomtableid].kingdomName.Length; i++)
				{
					this.kingdomData.kingName.Append(this.WorldKingdomTable[(int)kingdomtableid].kingdomName[i]);
				}
				this.kingdomData.allianceTag.ClearString();
				for (int j = 0; j < this.WorldKingdomTable[(int)kingdomtableid].allianceTag.Length; j++)
				{
					this.kingdomData.allianceTag.Append(this.WorldKingdomTable[(int)kingdomtableid].allianceTag[j]);
				}
				this.kingdomData.allianceName.ClearString();
				for (int k = 0; k < this.WorldKingdomTable[(int)kingdomtableid].allianceName.Length; k++)
				{
					this.kingdomData.allianceName.Append(this.WorldKingdomTable[(int)kingdomtableid].allianceName[k]);
				}
			}
			if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM)
			{
				this.kingdomData.kingdomFlag = this.WorldKingdomTable[(int)kingdomtableid].kingdomFlag;
				this.kingdomData.kingdomPeriod = this.WorldKingdomTable[(int)kingdomtableid].kingdomPeriod;
				this.kingdomData.kingName.ClearString();
				for (int l = 0; l < this.WorldKingdomTable[(int)kingdomtableid].kingdomName.Length; l++)
				{
					this.kingdomData.kingName.Append(this.WorldKingdomTable[(int)kingdomtableid].kingdomName[l]);
				}
				this.kingdomData.allianceTag.ClearString();
				for (int m = 0; m < this.WorldKingdomTable[(int)kingdomtableid].allianceTag.Length; m++)
				{
					this.kingdomData.allianceTag.Append(this.WorldKingdomTable[(int)kingdomtableid].allianceTag[m]);
				}
				this.kingdomData.allianceName.ClearString();
				for (int n = 0; n < this.WorldKingdomTable[(int)kingdomtableid].allianceName.Length; n++)
				{
					this.kingdomData.allianceName.Append(this.WorldKingdomTable[(int)kingdomtableid].allianceName[n]);
				}
			}
		}
		else if (this.OtherKingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_NONE && this.OtherKingdomData.kingdomID == this.WorldKingdomTable[(int)kingdomtableid].kingdomID)
		{
			if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_OWNERKINGDOMID)
			{
				this.OtherKingdomData.allianceKingdomID = this.WorldKingdomTable[(int)kingdomtableid].allianceKingdomID;
				this.OtherKingdomData.kingKingdomID = this.WorldKingdomTable[(int)kingdomtableid].kingKingdomID;
			}
			if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_TIME)
			{
				this.OtherKingdomData.kingdomTime = this.WorldKingdomTable[(int)kingdomtableid].kingdomTime;
			}
			if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_FLAG)
			{
				this.OtherKingdomData.kingdomFlag = this.WorldKingdomTable[(int)kingdomtableid].kingdomFlag;
			}
			if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_PERIOD)
			{
				this.OtherKingdomData.kingdomPeriod = this.WorldKingdomTable[(int)kingdomtableid].kingdomPeriod;
			}
			if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_ALLIANCE)
			{
				this.OtherKingdomData.kingName.ClearString();
				for (int num = 0; num < this.WorldKingdomTable[(int)kingdomtableid].kingdomName.Length; num++)
				{
					this.OtherKingdomData.kingName.Append(this.WorldKingdomTable[(int)kingdomtableid].kingdomName[num]);
				}
				this.OtherKingdomData.allianceTag.ClearString();
				for (int num2 = 0; num2 < this.WorldKingdomTable[(int)kingdomtableid].allianceTag.Length; num2++)
				{
					this.OtherKingdomData.allianceTag.Append(this.WorldKingdomTable[(int)kingdomtableid].allianceTag[num2]);
				}
				this.OtherKingdomData.allianceName.ClearString();
				for (int num3 = 0; num3 < this.WorldKingdomTable[(int)kingdomtableid].allianceName.Length; num3++)
				{
					this.OtherKingdomData.allianceName.Append(this.WorldKingdomTable[(int)kingdomtableid].allianceName[num3]);
				}
			}
			if (updatekind == MAP_UPDATE_KIND.MAPUPDATE_KINGDOM)
			{
				this.OtherKingdomData.kingdomFlag = this.WorldKingdomTable[(int)kingdomtableid].kingdomFlag;
				this.OtherKingdomData.kingdomPeriod = this.WorldKingdomTable[(int)kingdomtableid].kingdomPeriod;
				this.OtherKingdomData.kingName.ClearString();
				for (int num4 = 0; num4 < this.WorldKingdomTable[(int)kingdomtableid].kingdomName.Length; num4++)
				{
					this.OtherKingdomData.kingName.Append(this.WorldKingdomTable[(int)kingdomtableid].kingdomName[num4]);
				}
				this.OtherKingdomData.allianceTag.ClearString();
				for (int num5 = 0; num5 < this.WorldKingdomTable[(int)kingdomtableid].allianceTag.Length; num5++)
				{
					this.OtherKingdomData.allianceTag.Append(this.WorldKingdomTable[(int)kingdomtableid].allianceTag[num5]);
				}
				this.OtherKingdomData.allianceName.ClearString();
				for (int num6 = 0; num6 < this.WorldKingdomTable[(int)kingdomtableid].allianceName.Length; num6++)
				{
					this.OtherKingdomData.allianceName.Append(this.WorldKingdomTable[(int)kingdomtableid].allianceName[num6]);
				}
			}
		}
		DataManager.msgBuffer[0] = 113;
		GameConstants.GetBytes((ushort)kingdomtableid, DataManager.msgBuffer, 1);
		GameConstants.GetBytes((ushort)updatekind, DataManager.msgBuffer, 2);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06000A30 RID: 2608 RVA: 0x000DD3B4 File Offset: 0x000DB5B4
	public bool ShowDamageRange(ushort zoneID, byte pointID, ushort damageRangeID = 1)
	{
		DataManager.msgBuffer[0] = 98;
		GameConstants.GetBytes(zoneID, DataManager.msgBuffer, 1);
		DataManager.msgBuffer[3] = pointID;
		GameConstants.GetBytes(damageRangeID, DataManager.msgBuffer, 4);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		return true;
	}

	// Token: 0x06000A31 RID: 2609 RVA: 0x000DD3F8 File Offset: 0x000DB5F8
	public bool HideDamageRange()
	{
		DataManager.msgBuffer[0] = 99;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		return true;
	}

	// Token: 0x06000A32 RID: 2610 RVA: 0x000DD410 File Offset: 0x000DB610
	public bool UseMapWeapon(ushort MapWeaponID, ushort MapSkillID)
	{
		DataManager.msgBuffer[0] = 100;
		GameConstants.GetBytes(MapWeaponID, DataManager.msgBuffer, 1);
		GameConstants.GetBytes(MapSkillID, DataManager.msgBuffer, 3);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		return true;
	}

	// Token: 0x06000A33 RID: 2611 RVA: 0x000DD44C File Offset: 0x000DB64C
	public bool StopMapWeapon()
	{
		DataManager.msgBuffer[0] = 101;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		return true;
	}

	// Token: 0x06000A34 RID: 2612 RVA: 0x000DD464 File Offset: 0x000DB664
	public void SendUseMapWeapon()
	{
		UIPetSkill.onFinish();
	}

	// Token: 0x06000A35 RID: 2613 RVA: 0x000DD46C File Offset: 0x000DB66C
	public bool MapWeaponAttack(ushort zoneID, byte pointID, ushort effectID, float effectTime)
	{
		DataManager.msgBuffer[0] = 102;
		GameConstants.GetBytes(zoneID, DataManager.msgBuffer, 1);
		GameConstants.GetBytes((ushort)pointID, DataManager.msgBuffer, 3);
		GameConstants.GetBytes(effectID, DataManager.msgBuffer, 4);
		GameConstants.GetBytes(effectTime, DataManager.msgBuffer, 6);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		return true;
	}

	// Token: 0x06000A36 RID: 2614 RVA: 0x000DD4C0 File Offset: 0x000DB6C0
	public bool MapWeaponDefense(ushort zoneID, byte pointID, ushort effectID, float effectTime)
	{
		DataManager.msgBuffer[0] = 103;
		GameConstants.GetBytes(zoneID, DataManager.msgBuffer, 1);
		GameConstants.GetBytes((ushort)pointID, DataManager.msgBuffer, 3);
		GameConstants.GetBytes(effectID, DataManager.msgBuffer, 4);
		GameConstants.GetBytes(effectTime, DataManager.msgBuffer, 6);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		return true;
	}

	// Token: 0x17000074 RID: 116
	// (get) Token: 0x06000A37 RID: 2615 RVA: 0x000DD514 File Offset: 0x000DB714
	public byte StateKindCount
	{
		get
		{
			return this.mapStateKindCount;
		}
	}

	// Token: 0x06000A38 RID: 2616 RVA: 0x000DD51C File Offset: 0x000DB71C
	public byte getStateKind(byte index)
	{
		if (index >= this.mapStateKindCount)
		{
			return 0;
		}
		return this.stateKinds[(int)index];
	}

	// Token: 0x06000A39 RID: 2617 RVA: 0x000DD534 File Offset: 0x000DB734
	public byte getStateIndexByKind(byte kind)
	{
		for (byte b = 0; b < this.mapStateKindCount; b += 1)
		{
			if (this.stateKinds[(int)b] == kind)
			{
				return b;
			}
		}
		return byte.MaxValue;
	}

	// Token: 0x06000A3A RID: 2618 RVA: 0x000DD570 File Offset: 0x000DB770
	public byte getStateCountByIndex(byte index)
	{
		if (index >= this.mapStateKindCount)
		{
			return 0;
		}
		return this.stateCounts[(int)index];
	}

	// Token: 0x06000A3B RID: 2619 RVA: 0x000DD588 File Offset: 0x000DB788
	public byte getStateCountByKind(byte kind)
	{
		return this.getStateCountByIndex(this.getStateIndexByKind(kind));
	}

	// Token: 0x06000A3C RID: 2620 RVA: 0x000DD598 File Offset: 0x000DB798
	public ushort getStateSkillIDByIndex(byte kind, byte index)
	{
		byte stateCountByKind = this.getStateCountByKind(kind);
		byte stateIndexByKind = this.getStateIndexByKind(kind);
		if (stateCountByKind < 1 || index >= stateCountByKind || stateIndexByKind >= 255 || this.stateSkillIDs[(int)stateIndexByKind] == null)
		{
			return 0;
		}
		byte b = index / 16;
		if (this.stateSkillIDs[(int)stateIndexByKind][(int)b] != null)
		{
			byte b2 = index % 16;
			return this.stateSkillIDs[(int)stateIndexByKind][(int)b][(int)b2];
		}
		return 0;
	}

	// Token: 0x06000A3D RID: 2621 RVA: 0x000DD608 File Offset: 0x000DB808
	public byte getStateSkillLevelByIndex(byte kind, byte index)
	{
		byte stateCountByKind = this.getStateCountByKind(kind);
		byte stateIndexByKind = this.getStateIndexByKind(kind);
		if (stateCountByKind < 1 || index >= stateCountByKind || stateIndexByKind >= 255 || this.stateSkillIDs[(int)stateIndexByKind] == null)
		{
			return 0;
		}
		byte b = index / 16;
		if (this.stateSkillLevels[(int)stateIndexByKind][(int)b] != null)
		{
			byte b2 = index % 16;
			return this.stateSkillLevels[(int)stateIndexByKind][(int)b][(int)b2];
		}
		return 0;
	}

	// Token: 0x06000A3E RID: 2622 RVA: 0x000DD678 File Offset: 0x000DB878
	public void RESP_PETSKILL_STATE(MessagePacket MP)
	{
		ushort num = MP.ReadUShort(-1);
		byte pointID = MP.ReadByte(-1);
		uint num2 = (uint)GameConstants.PointCodeToMapID(num, pointID);
		if (this.stateMapID != num2)
		{
			return;
		}
		byte b = MP.ReadByte(-1);
		int i = (int)this.mapStateKindCount;
		this.mapStateKindCount += MP.ReadByte(-1);
		if (b == 0 || b == 1)
		{
			while (i < (int)this.mapStateKindCount)
			{
				if (this.stateSkillIDs[i] == null)
				{
					this.stateSkillIDs[i] = new ushort[16][];
				}
				if (this.stateSkillLevels[i] == null)
				{
					this.stateSkillLevels[i] = new byte[16][];
				}
				this.stateKinds[i] = MP.ReadByte(-1);
				this.stateCounts[i] = MP.ReadByte(-1);
				for (int j = 0; j < (int)this.stateCounts[i]; j++)
				{
					byte b2 = (byte)(j / 16);
					if (this.stateSkillIDs[i][(int)b2] == null)
					{
						this.stateSkillIDs[i][(int)b2] = new ushort[16];
					}
					if (this.stateSkillLevels[i][(int)b2] == null)
					{
						this.stateSkillLevels[i][(int)b2] = new byte[16];
					}
					byte b3 = (byte)(j % 16);
					this.stateSkillIDs[i][(int)b2][(int)b3] = MP.ReadUShort(-1);
					this.stateSkillLevels[i][(int)b2][(int)b3] = MP.ReadByte(-1);
				}
				i++;
			}
			if (b == 0)
			{
				DataManager.msgBuffer[0] = 80;
				GameConstants.GetBytes(this.stateMapID, DataManager.msgBuffer, 1);
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
		}
	}

	// Token: 0x06000A3F RID: 2623 RVA: 0x000DD820 File Offset: 0x000DBA20
	private void freeZonePoint(ushort freeZoneID)
	{
		for (int i = 0; i < 256; i++)
		{
			int num = GameConstants.PointCodeToMapID(freeZoneID, (byte)i);
			ushort tableID = this.LayoutMapInfo[num].tableID;
			POINT_KIND layoutMapInfoPointKind = this.GetLayoutMapInfoPointKind((uint)num);
			if (layoutMapInfoPointKind > POINT_KIND.PK_NONE)
			{
				if (layoutMapInfoPointKind < POINT_KIND.PK_CITY)
				{
					this.ResourcesPointTableIDpool.despawn((int)tableID);
				}
				else if (layoutMapInfoPointKind < POINT_KIND.PK_NPC)
				{
					this.PlayerPointTableIDpool.despawn((int)tableID);
				}
				else if (layoutMapInfoPointKind == POINT_KIND.PK_NPC)
				{
					this.NPCPointTableIDpool.despawn((int)tableID);
				}
				if (layoutMapInfoPointKind != POINT_KIND.PK_YOLK)
				{
					this.LayoutMapInfo[num].pointKind = 0;
				}
			}
		}
	}

	// Token: 0x06000A40 RID: 2624 RVA: 0x000DD8D0 File Offset: 0x000DBAD0
	private void checkZoneLine(byte nowZoneIDNum, ushort[] nowZoneID)
	{
		Vector2 vector = Vector2.zero;
		double num = Math.Round(640000000000.0);
		byte b = 0;
		byte b2 = 0;
		for (byte b3 = 0; b3 < nowZoneIDNum; b3 += 1)
		{
			if (this.ZoneUpdateInfo[(int)nowZoneID[(int)b3]].updateNum == 0UL)
			{
				List<ZoneLine> list;
				byte b5;
				if (this.LastZoneID[0] != 16384)
				{
					vector = GameConstants.getTileMapPosbyPointCode(nowZoneID[(int)b3], 0);
					vector.x *= 2f;
					for (byte b4 = 0; b4 < this.LastZoneIDNum; b4 += 1)
					{
						if (this.ZoneUpdateInfo[(int)this.LastZoneID[(int)b4]].updateNum != 0UL)
						{
							list = this.ZoneLineIDTable[(int)this.ZoneUpdateInfo[(int)this.LastZoneID[(int)b4]].zoneState];
							for (int i = list.Count - 1; i > -1; i--)
							{
								int lineTableID = (int)list[i].lineTableID;
								bool flag = this.MapLineTable[lineTableID].start.zoneID == nowZoneID[(int)b3] || this.MapLineTable[lineTableID].end.zoneID == nowZoneID[(int)b3];
								if (!flag && lineTableID < this.MapLineTable.Count && list[i].lineID == this.MapLineTable[lineTableID].lineID && this.MapLineTable[lineTableID].start.zoneID != this.MapLineTable[lineTableID].end.zoneID && this.MapLineTable[lineTableID].zoneMax.x > vector.x && this.MapLineTable[lineTableID].zoneMin.x <= vector.x && this.MapLineTable[lineTableID].zoneMax.y > vector.y && this.MapLineTable[lineTableID].zoneMin.y <= vector.y)
								{
									if (this.MapLineTable[lineTableID].XIntercept < 0.0)
									{
										if (this.MapLineTable[lineTableID].Slope == 0.0)
										{
											flag = (this.MapLineTable[lineTableID].YIntercept >= (double)vector.y && this.MapLineTable[lineTableID].YIntercept < (double)(vector.y + 16f));
										}
										else
										{
											double num2 = this.MapLineTable[lineTableID].Slope * (double)vector.x + this.MapLineTable[lineTableID].YIntercept;
											num2 = Math.Round(num2 * 10000000000.0);
											double num3 = this.MapLineTable[lineTableID].Slope * (double)(vector.x + 64f) + this.MapLineTable[lineTableID].YIntercept;
											num3 = Math.Round(num3 * 10000000000.0);
											double num4 = ((double)vector.y - this.MapLineTable[lineTableID].YIntercept) / this.MapLineTable[lineTableID].Slope;
											num4 = Math.Round(num4 * 10000000000.0);
											double num5 = ((double)(vector.y + 16f) - this.MapLineTable[lineTableID].YIntercept) / this.MapLineTable[lineTableID].Slope;
											num5 = Math.Round(num5 * 10000000000.0);
											double num6 = Math.Round((double)(vector.y * 1E+10f));
											double num7 = Math.Round((double)(vector.x * 1E+10f));
											double num8 = Math.Round(160000000000.0);
											flag = ((num2 >= num6 && num2 < num6 + num8) || (num3 > num6 && num3 < num6 + num8) || (num4 >= num7 && num4 < num7 + num) || (num5 > num7 && num5 < num7 + num) || (num3 == num6 && num3 + num8 == num2 && num5 == num7 && num5 + num == num4));
										}
									}
									else
									{
										flag = (this.MapLineTable[lineTableID].XIntercept >= (double)vector.x && this.MapLineTable[lineTableID].XIntercept < (double)(vector.x + 64f));
									}
								}
								if (flag)
								{
									ZoneLine item = list[i];
									for (int j = 0; j < this.TempLineIDTable[(int)b].Count; j++)
									{
										if (this.TempLineIDTable[(int)b][j].lineTableID == item.lineTableID)
										{
											flag = false;
											break;
										}
									}
									if (flag)
									{
										b5 = this.sortRAMReplaceNum[(int)b2];
										if ((int)b5 >= this.MapLineTable[lineTableID].ZoneIDTable.Length || this.MapLineTable[lineTableID].ZoneIDTable[(int)b5] == 1048576)
										{
											MapLine mapLine = this.MapLineTable[lineTableID];
											mapLine.zoneNum += 1;
										}
										else
										{
											if (this.ZoneLineIDTable[(int)b5].Count <= this.MapLineTable[lineTableID].ZoneIDTable[(int)b5])
											{
												goto IL_69F;
											}
											for (int k = this.ZoneLineIDTable[(int)b5].Count - 1; k > this.MapLineTable[lineTableID].ZoneIDTable[(int)b5]; k--)
											{
												this.MapLineTable[(int)this.ZoneLineIDTable[(int)b5][k].lineTableID].ZoneIDTable[(int)b5]--;
											}
											this.ZoneLineIDTable[(int)b5].RemoveAt(this.MapLineTable[lineTableID].ZoneIDTable[(int)b5]);
										}
										this.MapLineTable[lineTableID].ZoneIDTable[(int)b5] = this.TempLineIDTable[(int)b].Count;
										this.TempLineIDTable[(int)b].Add(item);
									}
								}
								IL_69F:;
							}
						}
					}
				}
				ushort[] tempZoneStateID = this.TempZoneStateID;
				int num9 = (int)b;
				byte[] array = this.sortRAMReplaceNum;
				byte b6 = b2;
				b2 = b6 + 1;
				b5 = (tempZoneStateID[num9] = array[(int)b6]);
				list = this.ZoneLineIDTable[(int)b5];
				this.ZoneLineIDTable[(int)b5] = this.TempLineIDTable[(int)b];
				List<ZoneLine>[] tempLineIDTable = this.TempLineIDTable;
				byte b7 = b;
				b = b7 + 1;
				tempLineIDTable[(int)b7] = list;
			}
		}
		for (int l = 0; l < (int)b; l++)
		{
			for (int m = this.TempLineIDTable[l].Count - 1; m > -1; m--)
			{
				int lineTableID = (int)this.TempLineIDTable[l][m].lineTableID;
				if (this.TempLineIDTable[l][m].lineID == this.MapLineTable[lineTableID].lineID)
				{
					this.MapLineTable[lineTableID].ZoneIDTable[(int)this.TempZoneStateID[l]] = 1048576;
					this.LineDelZone(lineTableID, byte.MaxValue, 1);
				}
			}
			this.TempLineIDTable[l].Clear();
		}
	}

	// Token: 0x06000A41 RID: 2625 RVA: 0x000DE0B4 File Offset: 0x000DC2B4
	private void finishMapLoading()
	{
		if ((int)this.checkZone == (1 << (int)this.zoneIDNum) - 1)
		{
			this.checkZone += 1;
			this.wait = 0f;
			if (this.waitZoneIDNum > 0)
			{
				if (this.waitZoneIDNum < 4)
				{
					this.setLastZoneInfo(this.waitZoneIDNum, this.waitZoneID, false);
				}
				this.waitZoneIDNum = 0;
			}
			else
			{
				DataManager.msgBuffer[0] = 69;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				this.wait = 0f;
			}
		}
	}

	// Token: 0x06000A42 RID: 2626 RVA: 0x000DE14C File Offset: 0x000DC34C
	private void LineDelZone(int mapLineTableID, byte Send = 1, byte bDelAll = 0)
	{
		MapLine mapLine = this.MapLineTable[mapLineTableID];
		mapLine.zoneNum -= 1;
		if (this.MapLineTable[mapLineTableID].zoneNum == 0)
		{
			this.LineNotifyObserver(55, mapLineTableID, Send, bDelAll);
			this.MapLineTableIDpool.despawn(mapLineTableID);
			this.MapLineTable[mapLineTableID].MapLineInit();
		}
	}

	// Token: 0x06000A43 RID: 2627 RVA: 0x000DE1B4 File Offset: 0x000DC3B4
	private int getLineTableID(ushort zoneID, uint lineID)
	{
		if (this.ZoneUpdateInfo[(int)zoneID].updateNum != 0UL)
		{
			int zoneState = (int)this.ZoneUpdateInfo[(int)zoneID].zoneState;
			for (int i = 0; i < this.ZoneLineIDTable[zoneState].Count; i++)
			{
				if (this.ZoneLineIDTable[zoneState][i].lineID == lineID)
				{
					return (int)this.ZoneLineIDTable[zoneState][i].lineTableID;
				}
			}
		}
		return 1048576;
	}

	// Token: 0x06000A44 RID: 2628 RVA: 0x000DE240 File Offset: 0x000DC440
	private int getLineTableID(uint lineID)
	{
		for (int i = 0; i < this.MapLineTable.Count; i++)
		{
			if (this.MapLineTable[i].lineID == lineID)
			{
				return i;
			}
		}
		return 1048576;
	}

	// Token: 0x06000A45 RID: 2629 RVA: 0x000DE288 File Offset: 0x000DC488
	private MapManager.MAP_ZONE_STATE CheckZoneID(ushort ZoneID, bool bClear = false)
	{
		if (ZoneID >= 1024)
		{
			return MapManager.MAP_ZONE_STATE.MAPZONESTATE_RAM;
		}
		if (this.checkZone >> (int)this.zoneIDNum == 1)
		{
			if (this.UpdateZoneIDNum != 0)
			{
				for (int i = 0; i < (int)this.UpdateZoneIDNum; i++)
				{
					this.ZoneNotifyObserver(this.UpdateZoneID[i]);
				}
				this.UpdateZoneIDNum = 0;
			}
			return MapManager.MAP_ZONE_STATE.MAPZONESTATE_NONE;
		}
		byte b = 0;
		while (b < this.zoneIDNum)
		{
			if (((int)this.checkZone & 1 << (int)b) == 0 && this.zoneID[(int)b] == ZoneID)
			{
				this.checkZone |= (byte)(1 << (int)b);
				if (this.ZoneUpdateInfo[(int)ZoneID].updateNum == 0UL)
				{
					this.moveRAMtoROM(ZoneID);
					this.finishMapLoading();
					return MapManager.MAP_ZONE_STATE.MAPZONESTATE_NONE;
				}
				if (this.ZoneUpdateInfo[(int)ZoneID].zoneState < 8)
				{
					byte zoneState = this.ZoneUpdateInfo[(int)ZoneID].zoneState;
					this.RAMSataeInfo[(int)zoneState].replaceNum = this.RAMSataeInfo[(int)this.sortRAMReplaceNum[7]].replaceNum + 1u;
					this.sortMaxRAM(zoneState);
					if (bClear)
					{
						this.freeZonePoint(ZoneID);
					}
					this.finishMapLoading();
					if (this.LastZoneID[0] == 16384)
					{
						this.ZoneNotifyObserver(ZoneID);
					}
					else
					{
						byte b2;
						for (b2 = 0; b2 < this.LastZoneIDNum; b2 += 1)
						{
							if (this.LastZoneID[(int)b2] == ZoneID)
							{
								break;
							}
						}
						if (b2 == this.LastZoneIDNum)
						{
							this.CheckZoneLine(ZoneID);
						}
					}
					return MapManager.MAP_ZONE_STATE.MAPZONESTATE_RAM;
				}
				this.switchRAMtoROM(this.ZoneUpdateInfo[(int)ZoneID].zoneState - 120, bClear);
				this.RequsetLineInZone(ZoneID);
				this.finishMapLoading();
				return MapManager.MAP_ZONE_STATE.MAPZONESTATE_ROM;
			}
			else
			{
				b += 1;
			}
		}
		return MapManager.MAP_ZONE_STATE.MAPZONESTATE_RAM;
	}

	// Token: 0x06000A46 RID: 2630 RVA: 0x000DE45C File Offset: 0x000DC65C
	private void LineNotifyObserver(byte news, int maplinetableID, byte Send = 1, byte bDelAll = 0)
	{
		DataManager.msgBuffer[0] = news;
		GameConstants.GetBytes((uint)maplinetableID, DataManager.msgBuffer, 1);
		DataManager.msgBuffer[5] = Send;
		DataManager.msgBuffer[6] = bDelAll;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06000A47 RID: 2631 RVA: 0x000DE490 File Offset: 0x000DC690
	private void CheckZoneLine(ushort zoneID)
	{
		if (zoneID < 1024)
		{
			int zoneState = (int)this.ZoneUpdateInfo[(int)zoneID].zoneState;
			List<ZoneLine> list = this.ZoneLineIDTable[zoneState];
			for (int i = list.Count - 1; i > -1; i--)
			{
				int lineTableID = (int)list[i].lineTableID;
				if (this.MapLineTable[lineTableID].lineObject == null)
				{
					this.LineNotifyObserver(56, lineTableID, 1, 0);
				}
			}
		}
	}

	// Token: 0x06000A48 RID: 2632 RVA: 0x000DE518 File Offset: 0x000DC718
	private void ZoneNotifyObserver(ushort zoneID)
	{
		this.CheckZoneLine(zoneID);
		DataManager.msgBuffer[0] = 52;
		GameConstants.GetBytes(zoneID, DataManager.msgBuffer, 1);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06000A49 RID: 2633 RVA: 0x000DE550 File Offset: 0x000DC750
	private void PointNotifyObserver(uint mapID)
	{
		DataManager.msgBuffer[0] = 54;
		GameConstants.GetBytes(mapID, DataManager.msgBuffer, 1);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06000A4A RID: 2634 RVA: 0x000DE574 File Offset: 0x000DC774
	private void pushReqKingdomID(byte in_reqKingdomTableID, ushort in_reqKingdomID)
	{
		this.reqKingdomID[(int)in_reqKingdomTableID] = in_reqKingdomID;
		while (in_reqKingdomTableID > 0 && this.reqKingdomID[(int)in_reqKingdomTableID] < this.reqKingdomID[(int)(in_reqKingdomTableID - 1)])
		{
			in_reqKingdomID = this.reqKingdomID[(int)in_reqKingdomTableID];
			this.reqKingdomID[(int)in_reqKingdomTableID] = this.reqKingdomID[(int)(in_reqKingdomTableID - 1)];
			this.reqKingdomID[(int)(in_reqKingdomTableID -= 1)] = in_reqKingdomID;
		}
	}

	// Token: 0x06000A4B RID: 2635 RVA: 0x000DE5D8 File Offset: 0x000DC7D8
	private void GetKingdomOpenIndexShift(ushort kingdomID, out ushort index, out byte bitShift)
	{
		kingdomID -= 1;
		index = (ushort)(kingdomID >> 3);
		bitShift = (byte)(kingdomID & 7);
	}

	// Token: 0x040022EF RID: 8943
	private const long CHECK_ZONE_LINE_FACTOR = 10000000000L;

	// Token: 0x040022F0 RID: 8944
	private const int ZoneLineIDTableSize = 32;

	// Token: 0x040022F1 RID: 8945
	private const float ZoneCheckBottom = 16f;

	// Token: 0x040022F2 RID: 8946
	private const float ZoneCheckRight = 64f;

	// Token: 0x040022F3 RID: 8947
	private const byte MaxMapDataSize = 128;

	// Token: 0x040022F4 RID: 8948
	private const byte MinMapBasePointSize = 39;

	// Token: 0x040022F5 RID: 8949
	private const byte MinMapLineSize = 49;

	// Token: 0x040022F6 RID: 8950
	private const byte MinKingdomSize = 40;

	// Token: 0x040022F7 RID: 8951
	private const byte PointBaseSize = 4;

	// Token: 0x040022F8 RID: 8952
	private const byte BasePlayerPointSize = 34;

	// Token: 0x040022F9 RID: 8953
	private const byte ResourcesPointSize = 35;

	// Token: 0x040022FA RID: 8954
	private const byte NPCPointSize = 22;

	// Token: 0x040022FB RID: 8955
	private const byte YolkPointSize = 39;

	// Token: 0x040022FC RID: 8956
	private const byte DOBSPointSize = 1;

	// Token: 0x040022FD RID: 8957
	private const byte LineIDSize = 4;

	// Token: 0x040022FE RID: 8958
	private const byte LineBaseSize = 52;

	// Token: 0x040022FF RID: 8959
	private const byte LineEmojiSize = 3;

	// Token: 0x04002300 RID: 8960
	private const byte updateResourcesPointSize = 34;

	// Token: 0x04002301 RID: 8961
	private const byte AdvancePlayerPointSize = 44;

	// Token: 0x04002302 RID: 8962
	private const byte AdvanceYolkPointSize = 38;

	// Token: 0x04002303 RID: 8963
	private const byte YolkStateSize = 13;

	// Token: 0x04002304 RID: 8964
	private const byte WoldMapKingdomSize = 40;

	// Token: 0x04002305 RID: 8965
	private const byte FlagEmojiIDSize = 3;

	// Token: 0x04002306 RID: 8966
	private const byte maxStateCount = 255;

	// Token: 0x04002307 RID: 8967
	private const byte maxStateSkillCount = 16;

	// Token: 0x04002308 RID: 8968
	public CExternalTableWithWordKey<KingdomMap> KingdomMapTable;

	// Token: 0x04002309 RID: 8969
	public byte checkZone;

	// Token: 0x0400230A RID: 8970
	public byte zoneIDNum;

	// Token: 0x0400230B RID: 8971
	public ushort[] zoneID = new ushort[4];

	// Token: 0x0400230C RID: 8972
	public byte UpdateZoneIDNum;

	// Token: 0x0400230D RID: 8973
	public ushort[] UpdateZoneID = new ushort[4];

	// Token: 0x0400230E RID: 8974
	public ulong[] ZoneUpdateNum = new ulong[4];

	// Token: 0x0400230F RID: 8975
	public byte LastZoneIDNum;

	// Token: 0x04002310 RID: 8976
	public ushort[] LastZoneID = new ushort[4];

	// Token: 0x04002311 RID: 8977
	public byte waitZoneIDNum;

	// Token: 0x04002312 RID: 8978
	public ushort[] waitZoneID = new ushort[4];

	// Token: 0x04002313 RID: 8979
	public ZoneUpdate[] ZoneUpdateInfo = new ZoneUpdate[1024];

	// Token: 0x04002314 RID: 8980
	public MapPoint[] LayoutMapInfo = new MapPoint[262144];

	// Token: 0x04002315 RID: 8981
	public byte[] sortRAMReplaceNum = new byte[8];

	// Token: 0x04002316 RID: 8982
	public MemSatae[] RAMSataeInfo = new MemSatae[8];

	// Token: 0x04002317 RID: 8983
	public byte[] sortROMReplaceNum;

	// Token: 0x04002318 RID: 8984
	public MemSatae[] ROMSataeInfo;

	// Token: 0x04002319 RID: 8985
	public TableIDPool PlayerPointTableIDpool = new TableIDPool(2048, false);

	// Token: 0x0400231A RID: 8986
	public PlayerPoint[] PlayerPointTable = new PlayerPoint[2048];

	// Token: 0x0400231B RID: 8987
	public TableIDPool ResourcesPointTableIDpool = new TableIDPool(2048, false);

	// Token: 0x0400231C RID: 8988
	public ResourcesPoint[] ResourcesPointTable = new ResourcesPoint[2048];

	// Token: 0x0400231D RID: 8989
	public TableIDPool NPCPointTableIDpool = new TableIDPool(2048, false);

	// Token: 0x0400231E RID: 8990
	public NPCPoint[] NPCPointTable = new NPCPoint[2048];

	// Token: 0x0400231F RID: 8991
	public NPCBase[] NPCNumMap = new NPCBase[5];

	// Token: 0x04002320 RID: 8992
	public NPCBase[] OtherNPCNumMap = new NPCBase[5];

	// Token: 0x04002321 RID: 8993
	public MapYolk[] YolkPointTable = new MapYolk[40];

	// Token: 0x04002322 RID: 8994
	public List<ZoneLine>[] ZoneLineIDTable = new List<ZoneLine>[8];

	// Token: 0x04002323 RID: 8995
	public List<ZoneLine>[] TempLineIDTable = new List<ZoneLine>[4];

	// Token: 0x04002324 RID: 8996
	public ushort[] TempZoneStateID = new ushort[4];

	// Token: 0x04002325 RID: 8997
	public TableIDPool MapLineTableIDpool = new TableIDPool(256, true);

	// Token: 0x04002326 RID: 8998
	public List<MapLine> MapLineTable = new List<MapLine>(256);

	// Token: 0x04002327 RID: 8999
	public byte reqKingdomIDNum;

	// Token: 0x04002328 RID: 9000
	public ushort[] reqKingdomID = new ushort[16];

	// Token: 0x04002329 RID: 9001
	public byte lastReqKingdomIDNum;

	// Token: 0x0400232A RID: 9002
	public ushort[] lastReqKingdomID = new ushort[16];

	// Token: 0x0400232B RID: 9003
	public byte updateKingdomNum;

	// Token: 0x0400232C RID: 9004
	public ushort[] updateKingdomID = new ushort[16];

	// Token: 0x0400232D RID: 9005
	public KingdomInfo kingdomData;

	// Token: 0x0400232E RID: 9006
	public KingdomInfo OtherKingdomData;

	// Token: 0x0400232F RID: 9007
	public ushort KVKKingdomID;

	// Token: 0x04002330 RID: 9008
	public ushort WARKingdomID;

	// Token: 0x04002331 RID: 9009
	public ushort WorldOX;

	// Token: 0x04002332 RID: 9010
	public ushort WorldOY;

	// Token: 0x04002333 RID: 9011
	public ushort WorldMaxX;

	// Token: 0x04002334 RID: 9012
	public ushort WorldMaxY;

	// Token: 0x04002335 RID: 9013
	public ushort WorldMinX;

	// Token: 0x04002336 RID: 9014
	public ushort WorldMinY;

	// Token: 0x04002337 RID: 9015
	public ushort[] KingdomIDposOrder;

	// Token: 0x04002338 RID: 9016
	public byte WorldKingdomTableIDcounter;

	// Token: 0x04002339 RID: 9017
	public KingdomInfo[] WorldKingdomTable = new KingdomInfo[32];

	// Token: 0x0400233A RID: 9018
	public MapKingdom[] TileMapKingdomID;

	// Token: 0x0400233B RID: 9019
	public byte[] KingdomOpenFlag;

	// Token: 0x0400233C RID: 9020
	public float zoomSize = 0.75f;

	// Token: 0x0400233D RID: 9021
	public float wait;

	// Token: 0x0400233E RID: 9022
	public int FocusMapID;

	// Token: 0x0400233F RID: 9023
	public ushort FocusKingdomID;

	// Token: 0x04002340 RID: 9024
	public ulong FocusKingdomTime;

	// Token: 0x04002341 RID: 9025
	public KINGDOM_PERIOD FocusKingdomPeriod;

	// Token: 0x04002342 RID: 9026
	public byte FocusGroupID = 10;

	// Token: 0x04002343 RID: 9027
	public byte isOpenGroundInfo;

	// Token: 0x04002344 RID: 9028
	public byte isMarkGroundInfo;

	// Token: 0x04002345 RID: 9029
	public byte gotoKingdomState;

	// Token: 0x04002346 RID: 9030
	public int MyFocusBallLineTableID = -1;

	// Token: 0x04002347 RID: 9031
	public float ScreenSpaceCameraCanvasrectranScale = 1f;

	// Token: 0x04002348 RID: 9032
	public CExternalTableWithWordKey<MapMonster> MapMonsterTable;

	// Token: 0x04002349 RID: 9033
	public CExternalTableWithWordKey<MapMonsterPrice> MapMonsterPriceTable;

	// Token: 0x0400234A RID: 9034
	public CExternalTableWithWordKey<WondersInfoTbl> MapWondersInfoTable;

	// Token: 0x0400234B RID: 9035
	public CExternalTableWithWordKey<MapWeaponDamageRange> MapWeaponDamageRangeTable;

	// Token: 0x0400234C RID: 9036
	public ushort gotokingdomID;

	// Token: 0x0400234D RID: 9037
	public Vector2 FocusWorldMapPos = -Vector2.one;

	// Token: 0x0400234E RID: 9038
	public Vector2 coloneWorldMapPos = Vector2.zero;

	// Token: 0x0400234F RID: 9039
	public Vector2 coltwoWorldMapPos = Vector2.zero;

	// Token: 0x04002350 RID: 9040
	public float worldZoomSize = 0.75f;

	// Token: 0x04002351 RID: 9041
	public int StartID;

	// Token: 0x04002352 RID: 9042
	public CExternalTableWithWordKey<EmojiData> EmojiDataTable;

	// Token: 0x04002353 RID: 9043
	public CExternalTableWithWordKey<Emote> EmoteTable;

	// Token: 0x04002354 RID: 9044
	public CExternalTableWithWordKey<KingdomYolkDeploy> KingdomYolkDeployTable;

	// Token: 0x04002355 RID: 9045
	public CExternalTableWithWordKey<YolkDeploy> YolkDeployTable;

	// Token: 0x04002356 RID: 9046
	public byte showYolkNum = 7;

	// Token: 0x04002357 RID: 9047
	public byte[] showYolkMapYolkID;

	// Token: 0x04002358 RID: 9048
	private CString[] yolkName;

	// Token: 0x04002359 RID: 9049
	private byte[] yolkswitch;

	// Token: 0x0400235A RID: 9050
	private byte MapBasePointSize;

	// Token: 0x0400235B RID: 9051
	private byte MapLineSize;

	// Token: 0x0400235C RID: 9052
	private byte MapKingdomSize;

	// Token: 0x0400235D RID: 9053
	private uint stateMapID;

	// Token: 0x0400235E RID: 9054
	private byte mapStateKindCount;

	// Token: 0x0400235F RID: 9055
	private byte[] stateKinds;

	// Token: 0x04002360 RID: 9056
	private byte[] stateCounts;

	// Token: 0x04002361 RID: 9057
	private ushort[][][] stateSkillIDs;

	// Token: 0x04002362 RID: 9058
	private byte[][][] stateSkillLevels;

	// Token: 0x02000245 RID: 581
	private enum MAP_ZONE_STATE : byte
	{
		// Token: 0x04002364 RID: 9060
		MAPZONESTATE_NONE,
		// Token: 0x04002365 RID: 9061
		MAPZONESTATE_RAM,
		// Token: 0x04002366 RID: 9062
		MAPZONESTATE_ROM,
		// Token: 0x04002367 RID: 9063
		MAPZONESTATE_MAX
	}
}
