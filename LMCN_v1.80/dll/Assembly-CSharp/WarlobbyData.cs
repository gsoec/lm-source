using System;

// Token: 0x020000FC RID: 252
public class WarlobbyData
{
	// Token: 0x060002EE RID: 750 RVA: 0x00027A74 File Offset: 0x00025C74
	public WarlobbyData(int index)
	{
		this.ListIndex = (ushort)index;
		this.AllyName = StringManager.Instance.SpawnString(100);
		this.EnemyName = StringManager.Instance.SpawnString(30);
		this.EnemyAllianceTag = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x060002EF RID: 751 RVA: 0x00027AC8 File Offset: 0x00025CC8
	public void Init(MessagePacket MP)
	{
		this.Kind = MP.ReadByte(-1);
		this.EventTime.BeginTime = MP.ReadLong(-1);
		this.EventTime.RequireTime = MP.ReadUInt(-1);
		this.AllyCapitalPoint.zoneID = MP.ReadUShort(-1);
		this.AllyCapitalPoint.pointID = MP.ReadByte(-1);
		this.AllyHead = MP.ReadUShort(-1);
		MP.ReadStringPlus(13, this.AllyName, -1);
		this.AllyNameID = this.AllyName.GetHashCode(false);
		this.AllyVIP = MP.ReadByte(-1);
		this.AllyRank = MP.ReadByte(-1);
		if (this.PositionInfo != 1)
		{
			this.AllyCurrTroop = MP.ReadUInt(-1);
		}
		this.AllyMAXTroop = MP.ReadUInt(-1);
		this.EnemyCapitalPoint.zoneID = MP.ReadUShort(-1);
		this.EnemyCapitalPoint.pointID = MP.ReadByte(-1);
		this.EnemyHead = MP.ReadUShort(-1);
		MP.ReadStringPlus(13, this.EnemyName, -1);
		this.EnemyVIP = MP.ReadByte(-1);
		this.EnemyRank = MP.ReadByte(-1);
		MP.ReadStringPlus(3, this.EnemyAllianceTag, -1);
		this.EnemyHomeKingdom = MP.ReadUShort(-1);
		this.WonderID = byte.MaxValue;
		this.UIWonderID = byte.MaxValue;
		this.AddCombatPower = 0u;
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x00027C2C File Offset: 0x00025E2C
	public void InitWonder(MessagePacket MP)
	{
		this.AllyCapitalPoint.zoneID = MP.ReadUShort(-1);
		this.AllyCapitalPoint.pointID = MP.ReadByte(-1);
		this.AllyHead = MP.ReadUShort(-1);
		MP.ReadStringPlus(13, this.AllyName, -1);
		this.AllyNameID = this.AllyName.GetHashCode(false);
		this.AllyMAXTroop = MP.ReadUInt(-1);
		this.WonderID = MP.ReadByte(-1);
		this.UIWonderID = this.WonderID;
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x00027CB4 File Offset: 0x00025EB4
	public void InitWonderAttack(MessagePacket MP)
	{
		this.AllyCapitalPoint.zoneID = MP.ReadUShort(-1);
		this.AllyCapitalPoint.pointID = MP.ReadByte(-1);
		this.AllyHead = MP.ReadUShort(-1);
		MP.ReadStringPlus(13, this.AllyName, -1);
		this.AllyNameID = this.AllyName.GetHashCode(false);
		if (this.PositionInfo != 1)
		{
			this.AllyCurrTroop = MP.ReadUInt(-1);
		}
		this.AllyMAXTroop = MP.ReadUInt(-1);
		this.WonderID = MP.ReadByte(-1);
		this.UIWonderID = this.WonderID;
		MP.ReadStringPlus(20, this.EnemyName, -1);
		MP.ReadStringPlus(3, this.EnemyAllianceTag, -1);
		this.EnemyHomeKingdom = MP.ReadUShort(-1);
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x00027D7C File Offset: 0x00025F7C
	public void InitWonderDefence(MessagePacket MP)
	{
		this.WonderID = MP.ReadByte(-1);
		this.UIWonderID = this.WonderID;
		if (this.PositionInfo != 1)
		{
			this.AllyCurrTroop = MP.ReadUInt(-1);
		}
		this.AllyMAXTroop = MP.ReadUInt(-1);
		this.EnemyCapitalPoint.zoneID = MP.ReadUShort(-1);
		this.EnemyCapitalPoint.pointID = MP.ReadByte(-1);
		this.EnemyHead = MP.ReadUShort(-1);
		MP.ReadStringPlus(13, this.EnemyName, -1);
		MP.ReadStringPlus(3, this.EnemyAllianceTag, -1);
		this.EnemyHomeKingdom = MP.ReadUShort(-1);
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x00027E24 File Offset: 0x00026024
	public void InitNpc(MessagePacket MP)
	{
		this.Kind = MP.ReadByte(-1);
		this.EventTime.BeginTime = MP.ReadLong(-1);
		this.EventTime.RequireTime = MP.ReadUInt(-1);
		this.AllyCapitalPoint.zoneID = MP.ReadUShort(-1);
		this.AllyCapitalPoint.pointID = MP.ReadByte(-1);
		this.AllyHead = MP.ReadUShort(-1);
		MP.ReadStringPlus(13, this.AllyName, -1);
		this.AllyNameID = this.AllyName.GetHashCode(false);
		this.AllyVIP = MP.ReadByte(-1);
		this.AllyRank = MP.ReadByte(-1);
		if (this.PositionInfo != 1)
		{
			this.AllyCurrTroop = MP.ReadUInt(-1);
		}
		this.AllyMAXTroop = MP.ReadUInt(-1);
		if (this.PositionInfo != 1)
		{
			this.AllyHomeKingdom = MP.ReadUShort(-1);
		}
		this.EnemyHead = 255;
		this.EnemyCapitalPoint.zoneID = MP.ReadUShort(-1);
		this.EnemyCapitalPoint.pointID = MP.ReadByte(-1);
		this.EnemyVIP = MP.ReadByte(-1);
		this.EnemyNPCID = MP.ReadUShort(-1);
		this.EnemyName.ClearString();
		this.EnemyName.IntToFormat((long)this.EnemyVIP, 1, false);
		this.EnemyName.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021u));
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x00027F98 File Offset: 0x00026198
	public void Empty()
	{
		this.EnemyHomeKingdom = 0;
		this.AllyHead = 0;
		this.EnemyHead = 0;
		this.AllyName.ClearString();
		this.EnemyName.ClearString();
		this.EnemyAllianceTag.ClearString();
		this.AllyVIP = (this.EnemyVIP = (this.AllyRank = (this.EnemyRank = 0)));
		this.AllyCurrTroop = (this.AllyMAXTroop = 0u);
		this.AllyNameID = 0;
		this.SelfParticipateTroopIndex = byte.MaxValue;
		this.EventTime.BeginTime = 0L;
		this.WonderID = byte.MaxValue;
		this.AddCombatPower = 0u;
	}

	// Token: 0x04000B3C RID: 2876
	public int DataIndex;

	// Token: 0x04000B3D RID: 2877
	public ushort ListIndex;

	// Token: 0x04000B3E RID: 2878
	public byte Kind;

	// Token: 0x04000B3F RID: 2879
	public byte AttackOrDefense;

	// Token: 0x04000B40 RID: 2880
	public byte DirtyData;

	// Token: 0x04000B41 RID: 2881
	public TimeEventDataType EventTime;

	// Token: 0x04000B42 RID: 2882
	public byte PositionInfo;

	// Token: 0x04000B43 RID: 2883
	public PointCode AllyCapitalPoint;

	// Token: 0x04000B44 RID: 2884
	public ushort AllyHead;

	// Token: 0x04000B45 RID: 2885
	public CString AllyName;

	// Token: 0x04000B46 RID: 2886
	public byte AllyVIP;

	// Token: 0x04000B47 RID: 2887
	public byte AllyRank;

	// Token: 0x04000B48 RID: 2888
	public uint AllyCurrTroop;

	// Token: 0x04000B49 RID: 2889
	public uint AllyMAXTroop;

	// Token: 0x04000B4A RID: 2890
	public int AllyNameID;

	// Token: 0x04000B4B RID: 2891
	public ushort AllyHomeKingdom;

	// Token: 0x04000B4C RID: 2892
	public PointCode EnemyCapitalPoint;

	// Token: 0x04000B4D RID: 2893
	public ushort EnemyHead;

	// Token: 0x04000B4E RID: 2894
	public CString EnemyName;

	// Token: 0x04000B4F RID: 2895
	public byte EnemyVIP;

	// Token: 0x04000B50 RID: 2896
	public byte EnemyRank;

	// Token: 0x04000B51 RID: 2897
	public CString EnemyAllianceTag;

	// Token: 0x04000B52 RID: 2898
	public ushort EnemyHomeKingdom;

	// Token: 0x04000B53 RID: 2899
	public byte ListDetailRecNum;

	// Token: 0x04000B54 RID: 2900
	public byte SelfParticipateTroopIndex;

	// Token: 0x04000B55 RID: 2901
	public byte WonderID;

	// Token: 0x04000B56 RID: 2902
	public byte UIWonderID;

	// Token: 0x04000B57 RID: 2903
	public ushort EnemyNPCID;

	// Token: 0x04000B58 RID: 2904
	public uint AddCombatPower;
}
