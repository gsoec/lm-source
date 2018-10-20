using System;

// Token: 0x020007A1 RID: 1953
public struct PetTraining
{
	// Token: 0x060027D1 RID: 10193 RVA: 0x0043FC98 File Offset: 0x0043DE98
	public PetTraining(PetManager.EPetTrainDataState state)
	{
		this.m_State = state;
		this.m_CoachHeroCount = 0;
		this.m_TotalExp = 0u;
		this.m_CancelExp = 0u;
		this.m_PetTrainingSet = new PetTrainingSet(100);
		this.m_EventTime.BeginTime = 0L;
		this.m_EventTime.RequireTime = 0u;
		this.bHasInstance = true;
	}

	// Token: 0x17000104 RID: 260
	// (get) Token: 0x060027D2 RID: 10194 RVA: 0x0043FCF0 File Offset: 0x0043DEF0
	public byte CoachHeroCount
	{
		get
		{
			if (this.m_PetTrainingSet.m_CoachHeroId != null)
			{
				return (byte)this.m_PetTrainingSet.m_CoachHeroId.Count;
			}
			return 0;
		}
	}

	// Token: 0x17000105 RID: 261
	// (get) Token: 0x060027D3 RID: 10195 RVA: 0x0043FD18 File Offset: 0x0043DF18
	public bool HasInstance
	{
		get
		{
			return this.bHasInstance;
		}
	}

	// Token: 0x060027D4 RID: 10196 RVA: 0x0043FD20 File Offset: 0x0043DF20
	public void AddCoachHero(ushort id)
	{
		if (this.m_PetTrainingSet.m_CoachHeroId != null && this.m_PetTrainingSet.m_CoachHeroId.Count < 100)
		{
			this.m_PetTrainingSet.m_CoachHeroId.Add(id);
		}
	}

	// Token: 0x060027D5 RID: 10197 RVA: 0x0043FD68 File Offset: 0x0043DF68
	public void Empty()
	{
		this.m_CoachHeroCount = 0;
		this.m_TotalExp = 0u;
		this.m_CancelExp = 0u;
		this.m_EventTime.BeginTime = 0L;
		this.m_EventTime.RequireTime = 0u;
		this.m_PetTrainingSet.Empty();
	}

	// Token: 0x060027D6 RID: 10198 RVA: 0x0043FDA4 File Offset: 0x0043DFA4
	public void SetState(PetManager.EPetTrainDataState state)
	{
		this.m_State = state;
		if (state == PetManager.EPetTrainDataState.Empty || state == PetManager.EPetTrainDataState.Closed || state == PetManager.EPetTrainDataState.NextOpen)
		{
			this.Empty();
		}
	}

	// Token: 0x040071CB RID: 29131
	public PetManager.EPetTrainDataState m_State;

	// Token: 0x040071CC RID: 29132
	public PetTrainingSet m_PetTrainingSet;

	// Token: 0x040071CD RID: 29133
	public uint m_TotalExp;

	// Token: 0x040071CE RID: 29134
	public uint m_CancelExp;

	// Token: 0x040071CF RID: 29135
	public TimeEventDataType m_EventTime;

	// Token: 0x040071D0 RID: 29136
	private byte m_CoachHeroCount;

	// Token: 0x040071D1 RID: 29137
	private bool bHasInstance;
}
