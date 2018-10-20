using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
internal class ExtraObject
{
	// Token: 0x06000005 RID: 5 RVA: 0x0000216C File Offset: 0x0000036C
	public ExtraObject(int eAppsFlayerEvent)
	{
		this.DataIdx = eAppsFlayerEvent;
		this.InitData(this.DataIdx);
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002188 File Offset: 0x00000388
	public int GetDifference()
	{
		int result;
		try
		{
			if (this.TriggerDate.Year == 2000)
			{
				result = 0;
			}
			else
			{
				DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
				TimeSpan timeSpan = d - this.TriggerDate;
				if (timeSpan.Days > 0)
				{
					result = timeSpan.Days;
				}
				else
				{
					result = 0;
				}
			}
		}
		catch (SystemException ex)
		{
			result = 0;
		}
		return result;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002240 File Offset: 0x00000440
	public bool SetUnbrokenDay()
	{
		bool result = false;
		this.GetData();
		int difference = this.GetDifference();
		this.TriggerDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
		if (difference == 1)
		{
			this.UnbrokenDay += 1;
			result = true;
			this.SaveData();
		}
		else if (difference > 1)
		{
			this.UnbrokenDay = 1;
			result = false;
			this.SaveData();
		}
		return result;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000022CC File Offset: 0x000004CC
	private void SaveData()
	{
		try
		{
			PlayerPrefs.SetString("AdvanceEventContinuousDataTag_" + this.DataIdx, this.TriggerDate.ToString());
			PlayerPrefs.SetString("AdvanceEventContinuousCountTag_" + this.DataIdx, this.UnbrokenDay.ToString());
		}
		catch (SystemException ex)
		{
			Debug.Log(ex.ToString());
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002358 File Offset: 0x00000558
	public void InitData(int DataIdx)
	{
		try
		{
			this.TriggerDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			this.UnbrokenDay = 0;
		}
		catch (SystemException ex)
		{
			Debug.Log(ex.ToString());
		}
	}

	// Token: 0x0600000A RID: 10 RVA: 0x000023D0 File Offset: 0x000005D0
	private void GetData()
	{
		try
		{
			string @string = PlayerPrefs.GetString("AdvanceEventContinuousDataTag_" + this.DataIdx);
			if (@string != null && @string != string.Empty)
			{
				this.TriggerDate = Convert.ToDateTime(@string);
				byte.TryParse(PlayerPrefs.GetString("AdvanceEventContinuousCountTag_" + this.DataIdx), out this.UnbrokenDay);
			}
			else
			{
				this.TriggerDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
				this.UnbrokenDay = 1;
				this.SaveData();
			}
		}
		catch (SystemException ex)
		{
			Debug.Log(ex.ToString());
		}
	}

	// Token: 0x04000001 RID: 1
	private const string AdvanceEventContinuousDataTag = "AdvanceEventContinuousDataTag_";

	// Token: 0x04000002 RID: 2
	private const string AdvanceEventContinuousCountTag = "AdvanceEventContinuousCountTag_";

	// Token: 0x04000003 RID: 3
	public DateTime TriggerDate;

	// Token: 0x04000004 RID: 4
	public byte UnbrokenDay;

	// Token: 0x04000005 RID: 5
	public int DataIdx;
}
