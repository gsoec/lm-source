using System;
using System.Collections.Generic;

// Token: 0x0200079F RID: 1951
public struct PetTrainingSet
{
	// Token: 0x060027CE RID: 10190 RVA: 0x0043FBB8 File Offset: 0x0043DDB8
	public PetTrainingSet(int maxCoach = 100)
	{
		this.m_PetId = 0;
		if (maxCoach >= 0 && maxCoach <= DataManager.Instance.MaxCurHeroData)
		{
			this.m_CoachHeroId = new List<ushort>(maxCoach);
		}
		else
		{
			this.m_CoachHeroId = new List<ushort>(DataManager.Instance.MaxCurHeroData);
		}
		this.m_CoachHeroId.Clear();
	}

	// Token: 0x060027CF RID: 10191 RVA: 0x0043FC14 File Offset: 0x0043DE14
	public void Empty()
	{
		this.m_PetId = 0;
		if (this.m_CoachHeroId != null)
		{
			this.m_CoachHeroId.Clear();
		}
	}

	// Token: 0x040071C3 RID: 29123
	public ushort m_PetId;

	// Token: 0x040071C4 RID: 29124
	public List<ushort> m_CoachHeroId;
}
