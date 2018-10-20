using System;

// Token: 0x020003F4 RID: 1012
public class MarkAimMission : ManorAimEver
{
	// Token: 0x0600149A RID: 5274 RVA: 0x0023B4E0 File Offset: 0x002396E0
	public MarkAimMission(ushort[] RecordMark) : base(RecordMark)
	{
		this.KeyBegin = 101;
		this.ManorBuildData = new ManorCheck[RecordMark.Length - (int)this.KeyBegin];
		base.Init();
	}

	// Token: 0x0600149B RID: 5275 RVA: 0x0023B518 File Offset: 0x00239718
	public override void AddDataFail(ushort Priority)
	{
		DataManager.MissionDataManager.RecommandTable.RecommandID[(int)Priority] = 0;
	}

	// Token: 0x0600149C RID: 5276 RVA: 0x0023B52C File Offset: 0x0023972C
	public override bool CheckValueChanged(ushort Key, ushort Val)
	{
		if (Key == 103)
		{
			EActivityCircleEventType eactivityCircleEventType = (EActivityCircleEventType)Val;
			if (eactivityCircleEventType != EActivityCircleEventType.EACET_SoloEvent)
			{
				if (eactivityCircleEventType != EActivityCircleEventType.EACET_InfernalEvent)
				{
					return false;
				}
				Key = 104;
			}
			ActivityDataType activityDataType = ActivityManager.Instance.ActivityData[(int)Val];
			ushort num = 0;
			for (int i = 0; i < 3; i++)
			{
				if (activityDataType.RequireScore[i] > 0u && activityDataType.EventScore >= (ulong)activityDataType.RequireScore[i])
				{
					num += 1;
				}
			}
			if (this.RecordMark[(int)Key] >= num)
			{
				return false;
			}
			Val = num;
		}
		else if (Key == 136)
		{
			switch (Val)
			{
			case 0:
				goto IL_DD;
			case 2:
				Key = 138;
				goto IL_DD;
			case 3:
				Key = 137;
				goto IL_DD;
			}
			return false;
			IL_DD:
			ActivityDataType activityDataType2 = ActivityManager.Instance.KvKActivityData[(int)Val];
			ushort num2 = 0;
			for (int j = 0; j < 3; j++)
			{
				if (activityDataType2.RequireScore[j] > 0u && activityDataType2.EventScore >= (ulong)activityDataType2.RequireScore[j])
				{
					num2 += 1;
				}
			}
			if (this.RecordMark[(int)Key] >= num2)
			{
				return false;
			}
			Val = num2;
		}
		else if (Key == 186)
		{
			EActivityKingdomEventType eactivityKingdomEventType = (EActivityKingdomEventType)Val;
			if (eactivityKingdomEventType == EActivityKingdomEventType.EAKET_SoloEvent)
			{
				Key = 187;
			}
			else if (eactivityKingdomEventType != EActivityKingdomEventType.EAKET_AllianceEvent)
			{
				return false;
			}
			if (ActivityManager.Instance.IsInKvK(0, false))
			{
				if (Key == 186)
				{
					Key = 137;
				}
				else
				{
					Key = 138;
				}
			}
			ActivityDataType activityDataType3 = ActivityManager.Instance.FIFAData[(int)Val];
			ushort num3 = 0;
			for (int k = 0; k < 3; k++)
			{
				if (activityDataType3.RequireScore[k] > 0u && activityDataType3.EventScore >= (ulong)activityDataType3.RequireScore[k])
				{
					num3 += 1;
				}
			}
			if (this.RecordMark[(int)Key] >= num3)
			{
				return false;
			}
			Val = num3;
		}
		if (DataManager.MissionDataManager.GetMarkNarrativeType(Key) == _eMarkAimNarrativeType.Accumlate)
		{
			ushort[] recordMark = this.RecordMark;
			ushort num4 = Key;
			recordMark[(int)num4] = recordMark[(int)num4] + Val;
		}
		else if (this.RecordMark[(int)Key] < Val)
		{
			this.RecordMark[(int)Key] = Val;
		}
		if (!base.CheckValueChanged(Key, this.RecordMark[(int)Key]))
		{
			return false;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
		return true;
	}

	// Token: 0x0600149D RID: 5277 RVA: 0x0023B7B4 File Offset: 0x002399B4
	public override void SetCompleteWhileLogin()
	{
		ushort num = 0;
		while ((int)num < this.ManorBuildData.Length)
		{
			base.CheckValueChanged(this.KeyBegin + num, this.RecordMark[(int)(this.KeyBegin + num)]);
			num += 1;
		}
	}
}
