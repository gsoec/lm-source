using System;
using System.Collections.Generic;

// Token: 0x0200001A RID: 26
public class ActivityDataType
{
	// Token: 0x06000032 RID: 50 RVA: 0x000033C0 File Offset: 0x000015C0
	public void Initial()
	{
		this.ActiveType = EActivityType.EAT_MAX;
		this.KVKActiveType = EKVKActivityType.EKAT_MAX;
		this.bAskDetailData = false;
		this.bAskRankPrize = false;
		this.EventState = EActivityState.EAS_None;
		this.EventBeginTime = 0L;
		this.EventReqiureTIme = 0u;
		this.EventScore = 0UL;
		this.EventRank = 0;
		this.EventCountTime = 0L;
		this.EventPrizeID = 0;
		this.EventPrizeID2 = 0;
		this.EventPrizeID3 = 0;
		this.Name = 0;
		this.Pic = 0;
		this.PicStr = 0;
		this.DetailContentStrID = 0;
		Array.Clear(this.RequireScore, 0, this.RequireScore.Length);
		this.EventAllDegreePrizeWorthData.CrystalPrice = 0u;
		this.EventAllDegreePrizeWorthData.Crystal = 0u;
		this.EventAllDegreePrizeWorthData.Priceless = 0;
		for (int i = 0; i < this.GetScoreFactor.Length; i++)
		{
			this.GetScoreFactor[i].Factor = EGetScoreFactor.EGSF_MAX;
			this.GetScoreFactor[i].BonusRate = 0;
		}
		Array.Clear(this.EventPrizeWorthData, 0, this.EventPrizeWorthData.Length);
		Array.Clear(this.DataLen, 0, this.DataLen.Length);
		Array.Clear(this.DegreePrize, 0, this.DegreePrize.Length);
		this.SpDegreePrizeFlag = 0;
		this.EventBonusType = EActEventBonusType.EAEBT_None;
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00003508 File Offset: 0x00001708
	public bool CheckPrizeFlag(byte bit)
	{
		return ((int)this.SpDegreePrizeFlag & 1 << (int)bit) != 0;
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00003520 File Offset: 0x00001720
	public bool CheckBonusType(ushort ItemID)
	{
		if (this.EventBonusType == EActEventBonusType.EAEBT_None || this.EventBonusType == EActEventBonusType.EAEBT_RequireScoreDown)
		{
			return false;
		}
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(ItemID);
		if (recordByKey.EquipKey != ItemID)
		{
			return false;
		}
		switch (this.EventBonusType)
		{
		case EActEventBonusType.EAEBT_Crystal:
			if (recordByKey.EquipKind == 11 && recordByKey.PropertiesInfo[0].Propertieskey == 6)
			{
				return true;
			}
			break;
		case EActEventBonusType.EAEBT_SpeedUpItem:
			if (recordByKey.EquipKind == 12 && (recordByKey.PropertiesInfo[0].Propertieskey == 1 || recordByKey.PropertiesInfo[0].Propertieskey == 12 || recordByKey.PropertiesInfo[0].Propertieskey == 17 || recordByKey.PropertiesInfo[0].Propertieskey == 18 || (recordByKey.PropertiesInfo[0].Propertieskey >= 21 && recordByKey.PropertiesInfo[0].Propertieskey <= 30)))
			{
				return true;
			}
			break;
		case EActEventBonusType.EAEBT_MatLotteryBox:
			if (recordByKey.EquipKind == 18 && recordByKey.PropertiesInfo[3].Propertieskey == 1)
			{
				return true;
			}
			break;
		case EActEventBonusType.EAEBT_Gold:
			if (recordByKey.EquipKind == 11 && recordByKey.PropertiesInfo[0].Propertieskey == 5)
			{
				return true;
			}
			break;
		}
		return false;
	}

	// Token: 0x06000035 RID: 53 RVA: 0x000036BC File Offset: 0x000018BC
	public void InitialNobility()
	{
		if (this.NobilityGroupData != null)
		{
			for (int i = 0; i < this.NobilityGroupData.Length; i++)
			{
				StringManager.Instance.DeSpawnString(this.NobilityGroupData[i].NobilityName);
				StringManager.Instance.DeSpawnString(this.NobilityGroupData[i].EventTimeStr);
			}
		}
		this.GroupCount = 0;
		this.NobilityGroupData = null;
		this.NobilityGroupDataIndex = new byte[256];
		if (this.NobilityGroupDataSortIndex == null)
		{
			this.NobilityGroupDataSortIndex = new List<byte>();
		}
		else
		{
			this.NobilityGroupDataSortIndex.Clear();
		}
	}

	// Token: 0x06000036 RID: 54 RVA: 0x0000376C File Offset: 0x0000196C
	public void InitGroupData(byte Count)
	{
		this.GroupCount = Count;
		this.NobilityGroupData = new NobilityGroupDataType[(int)Count];
		this.NobilityGroupDataSortIndex.Clear();
		for (int i = 0; i < this.NobilityGroupData.Length; i++)
		{
			this.NobilityGroupData[i].KingdomID = 0;
			this.NobilityGroupData[i].WonderID = 0;
			this.NobilityGroupData[i].EventState = EActivityState.EAS_None;
			this.NobilityGroupData[i].EventBeginTime = 0L;
			this.NobilityGroupData[i].EventRequireTime = 0u;
			this.NobilityGroupData[i].EventCountTime = 0L;
			this.NobilityGroupData[i].FightKingdomCount = 0;
			this.NobilityGroupData[i].FightKingdomID = null;
			this.NobilityGroupData[i].NobilityKingdomID = 0;
			this.NobilityGroupData[i].NobilityHeroID = 0;
			this.NobilityGroupData[i].bAskPrizeData = false;
			this.NobilityGroupData[i].bAskKingdomData = false;
			this.NobilityGroupData[i].bAskNobilityData = false;
			this.NobilityGroupData[i].PreparePrize = new ActPrizeDataType[3][];
			for (int j = 0; j < 3; j++)
			{
				this.NobilityGroupData[i].PreparePrize[j] = new ActPrizeDataType[3];
			}
			this.NobilityGroupData[i].NobilityName = StringManager.Instance.SpawnString(30);
			this.NobilityGroupData[i].EventTimeStr = StringManager.Instance.SpawnString(30);
			this.NobilityGroupDataSortIndex.Add((byte)i);
		}
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00003928 File Offset: 0x00001B28
	public void SetGroupEventTime()
	{
		for (int i = 0; i < this.NobilityGroupData.Length; i++)
		{
			DateTime dateTime = GameConstants.GetDateTime(this.NobilityGroupData[i].EventBeginTime);
			DateTime dateTime2 = GameConstants.GetDateTime(this.NobilityGroupData[i].EventBeginTime + (long)((ulong)this.NobilityGroupData[i].EventRequireTime));
			this.NobilityGroupData[i].EventTimeStr.Length = 0;
			this.NobilityGroupData[i].EventTimeStr.StringToFormat(dateTime.ToString("MM/dd/yy HH:mm"));
			this.NobilityGroupData[i].EventTimeStr.StringToFormat(dateTime2.ToString("HH:mm"));
			this.NobilityGroupData[i].EventTimeStr.AppendFormat("{0}~{1}");
		}
	}

	// Token: 0x04000101 RID: 257
	public EActivityType ActiveType;

	// Token: 0x04000102 RID: 258
	public EKVKActivityType KVKActiveType;

	// Token: 0x04000103 RID: 259
	public EActivityKingdomEventType FIFAActiveType;

	// Token: 0x04000104 RID: 260
	public bool bAskDetailData;

	// Token: 0x04000105 RID: 261
	public bool bAskRankPrize;

	// Token: 0x04000106 RID: 262
	public EActivityState EventState;

	// Token: 0x04000107 RID: 263
	public long EventBeginTime;

	// Token: 0x04000108 RID: 264
	public uint EventReqiureTIme;

	// Token: 0x04000109 RID: 265
	public ulong EventScore;

	// Token: 0x0400010A RID: 266
	public byte EventRank;

	// Token: 0x0400010B RID: 267
	public long EventCountTime;

	// Token: 0x0400010C RID: 268
	public ushort EventPrizeID;

	// Token: 0x0400010D RID: 269
	public ushort EventPrizeID2;

	// Token: 0x0400010E RID: 270
	public ushort EventPrizeID3;

	// Token: 0x0400010F RID: 271
	public ushort Name;

	// Token: 0x04000110 RID: 272
	public ushort Pic;

	// Token: 0x04000111 RID: 273
	public ushort PicStr;

	// Token: 0x04000112 RID: 274
	public ushort DetailContentStrID;

	// Token: 0x04000113 RID: 275
	public uint[] RequireScore = new uint[3];

	// Token: 0x04000114 RID: 276
	public ActivityPrizeWorthDataType EventAllDegreePrizeWorthData = default(ActivityPrizeWorthDataType);

	// Token: 0x04000115 RID: 277
	public ActGetScoreFactorDataType[] GetScoreFactor = new ActGetScoreFactorDataType[6];

	// Token: 0x04000116 RID: 278
	public ActivityPrizeWorthDataType[] EventPrizeWorthData = new ActivityPrizeWorthDataType[3];

	// Token: 0x04000117 RID: 279
	public byte[] DataLen = new byte[3];

	// Token: 0x04000118 RID: 280
	public ActPrizeDataType[] DegreePrize = new ActPrizeDataType[60];

	// Token: 0x04000119 RID: 281
	public ActivityPrizeWorthDataType[] RankPrizeWorthData = new ActivityPrizeWorthDataType[7];

	// Token: 0x0400011A RID: 282
	public byte[] RankingPrizeDataLen = new byte[7];

	// Token: 0x0400011B RID: 283
	public ActPrizeDataType[] RankingPrize = new ActPrizeDataType[140];

	// Token: 0x0400011C RID: 284
	public byte SpDegreePrizeFlag;

	// Token: 0x0400011D RID: 285
	public EActEventBonusType EventBonusType;

	// Token: 0x0400011E RID: 286
	public byte GroupCount;

	// Token: 0x0400011F RID: 287
	public NobilityGroupDataType[] NobilityGroupData;

	// Token: 0x04000120 RID: 288
	public byte[] NobilityGroupDataIndex;

	// Token: 0x04000121 RID: 289
	public List<byte> NobilityGroupDataSortIndex;
}
