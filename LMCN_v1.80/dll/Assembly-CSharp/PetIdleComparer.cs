using System;
using System.Collections.Generic;

// Token: 0x020007AE RID: 1966
public class PetIdleComparer : IComparer<byte>
{
	// Token: 0x06002851 RID: 10321 RVA: 0x004464A4 File Offset: 0x004446A4
	public int MyCompare(int value1, int value2)
	{
		if (value1 > value2)
		{
			return -1;
		}
		if (value1 < value2)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06002852 RID: 10322 RVA: 0x004464BC File Offset: 0x004446BC
	public int Compare(byte x, byte y)
	{
		PetData petData = PetManager.Instance.GetPetData((int)x);
		PetData petData2 = PetManager.Instance.GetPetData((int)y);
		if (petData == null || petData2 == null)
		{
			return 0;
		}
		int result;
		if (!petData.IsFullSkillLevel() && !petData2.IsFullSkillLevel())
		{
			if (petData.Enhance == petData2.Enhance)
			{
				if (petData.Level == petData2.Level)
				{
					if (petData.Rare == petData2.Rare)
					{
						result = this.MyCompare((int)petData.ID, (int)petData2.ID);
					}
					else
					{
						result = this.MyCompare((int)petData.Rare, (int)petData2.Rare);
					}
				}
				else
				{
					result = this.MyCompare((int)petData.Level, (int)petData2.Level);
				}
			}
			else
			{
				result = this.MyCompare((int)petData.Enhance, (int)petData2.Enhance);
			}
		}
		else
		{
			if (!petData.IsFullSkillLevel() && petData2.IsFullSkillLevel())
			{
				return -1;
			}
			if (petData.IsFullSkillLevel() && !petData2.IsFullSkillLevel())
			{
				return 1;
			}
			result = this.MyCompare((int)petData.ID, (int)petData2.ID);
		}
		return result;
	}
}
