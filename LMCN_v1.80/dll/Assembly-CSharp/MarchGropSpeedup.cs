using System;

// Token: 0x02000844 RID: 2116
public class MarchGropSpeedup : SpeedupBase
{
	// Token: 0x06002BCE RID: 11214 RVA: 0x00482900 File Offset: 0x00480B00
	public MarchGropSpeedup(int parm)
	{
		DataManager instance = DataManager.Instance;
		this.MainTitleStr = instance.mStringTable.GetStringByID(298u);
		this.CompleteImmContStr = string.Empty;
		this.CompleteImmBntStr = string.Empty;
		this.bFreeSpeedup = false;
		this.bImmediate = false;
		this.SkipFilterTime = 1;
		int num = ((parm & 1073741824) <= 0) ? 0 : 1;
		if (num == 1)
		{
			uint num2 = (uint)(parm & -1073741825);
			parm = (int)instance.GetMarchInxByLineTableID(num2);
			if (parm != 255)
			{
				parm += 2;
			}
			else
			{
				this.mapline = DataManager.MapDataController.MapLineTable[(int)num2];
			}
		}
		if (parm >= 2 && parm <= 9)
		{
			if (instance.MarchEventData[parm - 2].Type == EMarchEventType.EMET_RallyAttack)
			{
				this.MarchType = MarchGropSpeedup._MarchType.RallyAttack;
				this.UseTarget = (_UseItemTarget)(parm - 2);
				this.QueueBar = (byte)(parm - 2 + 22);
				this.Rally = 2;
				this.FilterType = 16;
			}
			else
			{
				this.UseTarget = (_UseItemTarget)(parm - 2);
				this.QueueBar = (byte)parm;
				this.FilterType = 11;
			}
		}
		else if (parm >= 100 && parm < 200)
		{
			this.MarchType = MarchGropSpeedup._MarchType.Rally;
			this.Rally = 1;
			this.QueueBar = (byte)(parm - 100);
			this.UseTarget = _UseItemTarget.Rally;
			this.FilterType = 11;
		}
		else
		{
			this.MarchType = MarchGropSpeedup._MarchType.RallyAttack;
			this.Rally = 2;
			if (parm != 255)
			{
				if (parm == 200)
				{
					this.QueueBar = 100;
				}
				else
				{
					this.QueueBar = (byte)(parm - 201 + instance.queueBarData.Length);
				}
			}
			else
			{
				this.QueueBar = byte.MaxValue;
			}
			this.UseTarget = _UseItemTarget.Rally;
			this.FilterType = 16;
		}
	}

	// Token: 0x1700014C RID: 332
	// (get) Token: 0x06002BCF RID: 11215 RVA: 0x00482AD4 File Offset: 0x00480CD4
	public override long StartTime
	{
		get
		{
			DataManager instance = DataManager.Instance;
			switch (this.MarchType)
			{
			case MarchGropSpeedup._MarchType.Normal:
				return instance.queueBarData[(int)this.QueueBar].StartTime;
			case MarchGropSpeedup._MarchType.Rally:
				if ((int)this.QueueBar < instance.WarTroop.Count)
				{
					return instance.WarTroop[(int)this.QueueBar].MarchTime.BeginTime;
				}
				break;
			case MarchGropSpeedup._MarchType.RallyAttack:
				if ((int)this.QueueBar < instance.queueBarData.Length)
				{
					return instance.queueBarData[(int)this.QueueBar].StartTime;
				}
				if (this.mapline != null)
				{
					return (long)this.mapline.begin;
				}
				if (this.QueueBar == 100)
				{
					return instance.WarlobbyDetail.EventTime.BeginTime;
				}
				if ((int)this.QueueBar - instance.queueBarData.Length < instance.WarHall[0].Count)
				{
					return instance.WarHall[0][(int)this.QueueBar - instance.queueBarData.Length].EventTime.BeginTime;
				}
				break;
			}
			return 0L;
		}
	}

	// Token: 0x1700014D RID: 333
	// (get) Token: 0x06002BD0 RID: 11216 RVA: 0x00482C04 File Offset: 0x00480E04
	public override uint TotalTime
	{
		get
		{
			DataManager instance = DataManager.Instance;
			switch (this.MarchType)
			{
			case MarchGropSpeedup._MarchType.Normal:
				return instance.queueBarData[(int)this.QueueBar].TotalTime;
			case MarchGropSpeedup._MarchType.Rally:
				if ((int)this.QueueBar < instance.WarTroop.Count)
				{
					return instance.WarTroop[(int)this.QueueBar].MarchTime.RequireTime;
				}
				break;
			case MarchGropSpeedup._MarchType.RallyAttack:
				if ((int)this.QueueBar < instance.queueBarData.Length)
				{
					return instance.queueBarData[(int)this.QueueBar].TotalTime;
				}
				if (this.mapline != null)
				{
					return this.mapline.during;
				}
				if (this.QueueBar == 100)
				{
					return instance.WarlobbyDetail.EventTime.RequireTime;
				}
				if ((int)this.QueueBar - instance.queueBarData.Length < instance.WarHall[0].Count)
				{
					return instance.WarHall[0][(int)this.QueueBar - instance.queueBarData.Length].EventTime.RequireTime;
				}
				break;
			}
			return 0u;
		}
	}

	// Token: 0x1700014E RID: 334
	// (get) Token: 0x06002BD1 RID: 11217 RVA: 0x00482D30 File Offset: 0x00480F30
	public override CString Name
	{
		get
		{
			DataManager instance = DataManager.Instance;
			if (this.MarchType == MarchGropSpeedup._MarchType.Rally)
			{
				if ((int)this.QueueBar < instance.WarTroop.Count)
				{
					return instance.WarTroop[(int)this.QueueBar].AllyName;
				}
			}
			else if (this.MarchType == MarchGropSpeedup._MarchType.RallyAttack && (int)this.QueueBar >= instance.queueBarData.Length)
			{
				if (this.mapline != null)
				{
					return this.mapline.playerName;
				}
				if (this.QueueBar == 100)
				{
					return instance.WarlobbyDetail.AllyName;
				}
				if ((int)this.QueueBar - instance.queueBarData.Length < instance.WarHall[0].Count)
				{
					return instance.WarHall[0][(int)this.QueueBar - instance.queueBarData.Length].AllyName;
				}
			}
			return null;
		}
	}

	// Token: 0x06002BD2 RID: 11218 RVA: 0x00482E14 File Offset: 0x00481014
	public override void SendImmediate()
	{
	}

	// Token: 0x06002BD3 RID: 11219 RVA: 0x00482E18 File Offset: 0x00481018
	public override void SendImmediateFree()
	{
	}

	// Token: 0x04007869 RID: 30825
	public MapLine mapline;

	// Token: 0x0400786A RID: 30826
	private MarchGropSpeedup._MarchType MarchType;

	// Token: 0x02000845 RID: 2117
	private enum _MarchType
	{
		// Token: 0x0400786C RID: 30828
		Normal,
		// Token: 0x0400786D RID: 30829
		Rally,
		// Token: 0x0400786E RID: 30830
		RallyAttack
	}
}
