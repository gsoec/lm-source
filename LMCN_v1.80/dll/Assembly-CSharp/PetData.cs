using System;
using UnityEngine;

// Token: 0x020007AB RID: 1963
public class PetData
{
	// Token: 0x0600283B RID: 10299 RVA: 0x00445F00 File Offset: 0x00444100
	public PetData(int Index)
	{
		this._DataIdx = Index;
	}

	// Token: 0x17000108 RID: 264
	// (get) Token: 0x0600283D RID: 10301 RVA: 0x00445FC0 File Offset: 0x004441C0
	public int DataIndex
	{
		get
		{
			return this._DataIdx;
		}
	}

	// Token: 0x17000109 RID: 265
	// (get) Token: 0x0600283F RID: 10303 RVA: 0x00446018 File Offset: 0x00444218
	// (set) Token: 0x0600283E RID: 10302 RVA: 0x00445FC8 File Offset: 0x004441C8
	public ushort ID
	{
		get
		{
			return this._ID;
		}
		set
		{
			if (value != this._ID)
			{
				this._ID = value;
				PetTbl recordByKey = PetManager.Instance.PetTable.GetRecordByKey(this._ID);
				this.Rare = recordByKey.Rare;
				this.SkillID = recordByKey.PetSkill;
			}
		}
	}

	// Token: 0x06002840 RID: 10304 RVA: 0x00446020 File Offset: 0x00444220
	public void AddState(PetManager.EPetState state)
	{
		this.PetState |= state;
	}

	// Token: 0x06002841 RID: 10305 RVA: 0x00446030 File Offset: 0x00444230
	public bool CheckState(PetManager.EPetState state)
	{
		return (this.PetState & state) == state;
	}

	// Token: 0x06002842 RID: 10306 RVA: 0x00446040 File Offset: 0x00444240
	public void Remove(PetManager.EPetState state)
	{
		this.PetState &= ~state;
	}

	// Token: 0x06002843 RID: 10307 RVA: 0x00446054 File Offset: 0x00444254
	public void Init()
	{
		this.Level = 0;
		this.Exp = 0u;
		this.Enhance = 0;
		Array.Clear(this.SkillLv, 0, this.SkillLv.Length);
		Array.Clear(this.SkillExp, 0, this.SkillExp.Length);
		this.PetState = PetManager.EPetState.None;
	}

	// Token: 0x06002844 RID: 10308 RVA: 0x004460A8 File Offset: 0x004442A8
	public byte GetMaxLevel(bool bCheckRoleLv = true)
	{
		byte b = 60;
		if (this.Enhance == 0)
		{
			b = 20;
		}
		else if (this.Enhance == 1)
		{
			b = 50;
		}
		if (bCheckRoleLv)
		{
			byte level = DataManager.Instance.RoleAttr.Level;
			if (level <= 15)
			{
				b = 15;
			}
			else if (level < b)
			{
				b = level;
			}
		}
		return b;
	}

	// Token: 0x06002845 RID: 10309 RVA: 0x0044610C File Offset: 0x0044430C
	public bool IsFullSkillLevel()
	{
		return this.CheckState(PetManager.EPetState.Limit);
	}

	// Token: 0x06002846 RID: 10310 RVA: 0x00446118 File Offset: 0x00444318
	public void UpdateLevelState()
	{
		PetManager instance = PetManager.Instance;
		PetTbl recordByKey = instance.PetTable.GetRecordByKey(this.ID);
		bool flag = true;
		for (int i = 0; i < 4; i++)
		{
			if (recordByKey.PetSkill[i] != 0)
			{
				PetSkillTbl recordByKey2 = instance.PetSkillTable.GetRecordByKey(recordByKey.PetSkill[i]);
				if (recordByKey2.UpLevel != 0 && this.SkillLv[i] < recordByKey2.UpLevel)
				{
					flag = false;
				}
			}
		}
		if (flag && this.Level == 60)
		{
			this.AddState(PetManager.EPetState.Limit);
		}
		else
		{
			this.Remove(PetManager.EPetState.Limit);
			uint needExp = instance.GetNeedExp(this.Level, recordByKey.Rare);
			if (this.Level >= this.GetMaxLevel(false) && this.Level != 60 && this.Exp >= needExp - 1u)
			{
				this.AddState(PetManager.EPetState.LockLimit);
			}
			else
			{
				this.Remove(PetManager.EPetState.LockLimit);
			}
		}
	}

	// Token: 0x06002847 RID: 10311 RVA: 0x0044621C File Offset: 0x0044441C
	public ulong getPetPower()
	{
		ulong num = 0UL;
		int num2 = Mathf.Clamp((int)(this.Enhance + 1), 0, PetData.PetGrowMod.Length - 1);
		int num3 = Mathf.Clamp((int)this.Rare, 0, PetData.PetRareMod.Length - 1);
		num += (ulong)(PetData.FullGrowPower * PetData.PetGrowMod[num2] * PetData.PetRareMod[num3]);
		for (int i = 0; i < this.SkillLv.Length; i++)
		{
			if (this.SkillLv[i] > 0)
			{
				num2 = Mathf.Clamp((int)this.SkillLv[i], 0, PetData.PetSkillLevelMod.Length - 1);
				num += (ulong)(PetData.FullSkillPower * PetData.PetSkillLevelMod[num2] * PetData.PetSkillRareMod[num3]);
			}
		}
		return num;
	}

	// Token: 0x0400728B RID: 29323
	private int _DataIdx;

	// Token: 0x0400728C RID: 29324
	private ushort _ID;

	// Token: 0x0400728D RID: 29325
	public byte Rare;

	// Token: 0x0400728E RID: 29326
	public byte Level;

	// Token: 0x0400728F RID: 29327
	public uint Exp;

	// Token: 0x04007290 RID: 29328
	public byte Enhance;

	// Token: 0x04007291 RID: 29329
	public byte[] SkillLv = new byte[4];

	// Token: 0x04007292 RID: 29330
	public uint[] SkillExp = new uint[4];

	// Token: 0x04007293 RID: 29331
	public ushort[] SkillID;

	// Token: 0x04007294 RID: 29332
	public PetManager.EPetState PetState;

	// Token: 0x04007295 RID: 29333
	private static readonly double[] PetGrowMod = new double[]
	{
		0.0,
		0.01,
		0.3,
		1.0
	};

	// Token: 0x04007296 RID: 29334
	private static readonly double[] PetRareMod = new double[]
	{
		0.0,
		0.3,
		0.4,
		0.6,
		0.8,
		1.0
	};

	// Token: 0x04007297 RID: 29335
	private static ulong FullGrowPower = 250000UL;

	// Token: 0x04007298 RID: 29336
	private static readonly double[] PetSkillLevelMod = new double[]
	{
		0.0,
		0.0,
		0.05,
		0.1,
		0.15,
		0.2,
		0.3,
		0.4,
		0.5,
		0.6,
		1.0
	};

	// Token: 0x04007299 RID: 29337
	private static readonly double[] PetSkillRareMod = new double[]
	{
		0.0,
		0.16,
		0.32,
		0.48,
		0.72,
		1.0
	};

	// Token: 0x0400729A RID: 29338
	private static ulong FullSkillPower = 250000UL;
}
