using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class StageAimMission : ManorAimNow
{
	// Token: 0x06001489 RID: 5257 RVA: 0x0023B15C File Offset: 0x0023935C
	public override void AddData(ushort Priority, ushort Key, ushort Val)
	{
		Val = Key;
		Key = 0;
		List<ushort> lvCondi = this.ManorBuildData[(int)Key].LvCondi;
		List<ushort> priority = this.ManorBuildData[(int)Key].Priority;
		int num = lvCondi.BinarySearch(Val);
		if (num >= 0)
		{
			Debug.Log(string.Concat(new object[]
			{
				"ID = ",
				num,
				"Priority = ",
				Priority
			}));
		}
		lvCondi.Insert(~num, Val);
		num = priority.BinarySearch(Priority);
		priority.Insert(~num, Priority);
	}
}
