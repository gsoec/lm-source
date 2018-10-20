using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003F6 RID: 1014
public class GamePlayAchievementManager
{
	// Token: 0x060014A0 RID: 5280 RVA: 0x0023B828 File Offset: 0x00239A28
	public void Init()
	{
		if (this.RoleAchievementData != null)
		{
			return;
		}
		this.RoleAchievementData = new Dictionary<int, string>();
	}

	// Token: 0x060014A1 RID: 5281 RVA: 0x0023B844 File Offset: 0x00239A44
	public void Signin()
	{
		bool.TryParse(PlayerPrefs.GetString("Google_AchieveMent"), out this.bSignin);
		if (this.bSignin)
		{
			return;
		}
	}

	// Token: 0x060014A2 RID: 5282 RVA: 0x0023B874 File Offset: 0x00239A74
	public void OpenAchievementUI()
	{
		if (!this.bAuthenticate)
		{
			return;
		}
		Social.ShowAchievementsUI();
		this.bAuthenticate = false;
		this.checkAuthenticate = 5;
		if (this.Sending > 0)
		{
			this.Push(this.Sending - 1);
			this.Sending = 0;
		}
	}

	// Token: 0x060014A3 RID: 5283 RVA: 0x0023B8C4 File Offset: 0x00239AC4
	public void testSignin()
	{
		if (!this.bAuthenticate)
		{
			return;
		}
	}

	// Token: 0x060014A4 RID: 5284 RVA: 0x0023B8D4 File Offset: 0x00239AD4
	public void LoadTable()
	{
		this.AchievementTable = new CExternalTableWithWordKey<_AchieveTbl>();
		this.AchievementTable.LoadTable("Achievements");
	}

	// Token: 0x060014A5 RID: 5285 RVA: 0x0023B8F4 File Offset: 0x00239AF4
	public void Make(byte[] Buffer)
	{
		int tableCount = this.AchievementTable.TableCount;
		this.AchievementIDStr = new string[tableCount];
		this.SendAchievement = new byte[tableCount];
		for (int i = 0; i < tableCount; i++)
		{
			_AchieveTbl recordByIndex = this.AchievementTable.GetRecordByIndex(i);
			Buffer[(int)recordByIndex.MissionID] = (byte)recordByIndex.AchievementID;
			this.AchievementIDStr[i] = new string(recordByIndex.AchievementName, 0, this.CharLen(recordByIndex.AchievementName));
		}
	}

	// Token: 0x060014A6 RID: 5286 RVA: 0x0023B978 File Offset: 0x00239B78
	private int CharLen(char[] str)
	{
		int i;
		for (i = str.Length - 1; i >= 0; i--)
		{
			if (str[i] != '\0')
			{
				i++;
				break;
			}
		}
		return i;
	}

	// Token: 0x060014A7 RID: 5287 RVA: 0x0023B9B0 File Offset: 0x00239BB0
	private void CheckUnlockAchievementState()
	{
		for (int i = 0; i < this.UnlockAchievementListNoSign.ID.Length; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				if (this.UnlockAchievementListNoSign.Count == 0)
				{
					Array.Clear(this.UnlockAchievementListNoSign.ID, 0, this.UnlockAchievementListNoSign.ID.Length);
					break;
				}
				if ((this.UnlockAchievementListNoSign.ID[i] >> j & 1) > 0)
				{
					int num = 8 * i + j + 1;
					this.UnlockAchievement((byte)num);
					this.UnlockAchievementListNoSign.Count = this.UnlockAchievementListNoSign.Count - 1;
				}
			}
		}
	}

	// Token: 0x060014A8 RID: 5288 RVA: 0x0023BA60 File Offset: 0x00239C60
	public void UpdateGameCenterLevel(ushort level)
	{
		if (!this.bAuthenticate)
		{
			return;
		}
		Social.ReportScore((long)level, "level", new Action<bool>(this.ScoreCallBack));
	}

	// Token: 0x060014A9 RID: 5289 RVA: 0x0023BA94 File Offset: 0x00239C94
	public void ScoreCallBack(bool result)
	{
	}

	// Token: 0x060014AA RID: 5290 RVA: 0x0023BA98 File Offset: 0x00239C98
	public void UnlockAchievement(byte AchievementID)
	{
		if (!this.bAuthenticate)
		{
			this.UnlockAchievementListNoSign.push(AchievementID);
			return;
		}
		ushort indexByKey = this.AchievementTable.GetIndexByKey((ushort)AchievementID);
		this.Push((byte)indexByKey);
	}

	// Token: 0x060014AB RID: 5291 RVA: 0x0023BAD4 File Offset: 0x00239CD4
	private void Push(byte val)
	{
		if ((int)this.SendCount >= this.SendAchievement.Length)
		{
			return;
		}
		byte[] sendAchievement = this.SendAchievement;
		byte pushIdx;
		this.PushIdx = (pushIdx = this.PushIdx) + 1;
		val = (sendAchievement[(int)pushIdx % this.SendAchievement.Length] = val + 1);
		if (this.PushIdx == 0)
		{
			this.PushIdx = (byte)(256 % this.SendAchievement.Length);
		}
		this.SendCount += 1;
	}

	// Token: 0x060014AC RID: 5292 RVA: 0x0023BB50 File Offset: 0x00239D50
	private byte Pop()
	{
		if (this.SendCount == 0)
		{
			return 0;
		}
		this.SendCount -= 1;
		byte[] sendAchievement = this.SendAchievement;
		byte popindex;
		this.Popindex = (popindex = this.Popindex) + 1;
		byte result = sendAchievement[(int)popindex % this.SendAchievement.Length];
		if (this.Popindex == 0)
		{
			this.Popindex = (byte)(256 % this.SendAchievement.Length);
		}
		return result;
	}

	// Token: 0x060014AD RID: 5293 RVA: 0x0023BBC0 File Offset: 0x00239DC0
	private bool ReportAchievement(byte id)
	{
		string text;
		this.RoleAchievementData.TryGetValue(this.AchievementIDStr[(int)id].GetHashCode(), out text);
		if (text == null)
		{
			Social.ReportProgress(this.AchievementIDStr[(int)id], 100.0, new Action<bool>(this.AchievementRes));
			return true;
		}
		return false;
	}

	// Token: 0x060014AE RID: 5294 RVA: 0x0023BC14 File Offset: 0x00239E14
	public void RefleshRoleAchievement()
	{
		if (!this.bAuthenticate)
		{
			return;
		}
		this.bLoadRoleAchievement = false;
	}

	// Token: 0x060014AF RID: 5295 RVA: 0x0023BC2C File Offset: 0x00239E2C
	public void AchievementRes(bool res)
	{
		if (res)
		{
			this.RoleAchievementData.Add(this.AchievementIDStr[(int)this.Sending].GetHashCode(), this.AchievementIDStr[(int)this.Sending]);
			Debug.Log("Success Achievement");
		}
		else
		{
			Debug.Log("Fail Achievement");
		}
		this.Sending = 0;
	}

	// Token: 0x060014B0 RID: 5296 RVA: 0x0023BC8C File Offset: 0x00239E8C
	public void Update(float delta)
	{
		if (this.checkAuthenticate > 0)
		{
			return;
		}
		if (this.Sending == 0 && this.bLoadRoleAchievement && this.bAuthenticate)
		{
			if (this.DelayTime < 0f)
			{
				byte b = this.Pop();
				if (b == 0)
				{
					return;
				}
				this.Sending = b - 1;
				while (!this.ReportAchievement(this.Sending))
				{
					this.Sending = 0;
					b = this.Pop();
					if (b == 0)
					{
						return;
					}
					this.Sending = b - 1;
				}
				this.DelayTime = 2f;
			}
			else
			{
				this.DelayTime -= delta;
			}
		}
	}

	// Token: 0x060014B1 RID: 5297 RVA: 0x0023BD44 File Offset: 0x00239F44
	public void ClearAchievement()
	{
		this.SendCount = 0;
		this.PushIdx = 0;
		this.Popindex = 0;
		this.Sending = 0;
		this.bLoadRoleAchievement = false;
	}

	// Token: 0x060014B2 RID: 5298 RVA: 0x0023BD6C File Offset: 0x00239F6C
	public void CheckAuthenticate()
	{
	}

	// Token: 0x04003D94 RID: 15764
	public CExternalTableWithWordKey<_AchieveTbl> AchievementTable;

	// Token: 0x04003D95 RID: 15765
	private bool bAuthenticate;

	// Token: 0x04003D96 RID: 15766
	private bool bLoadRoleAchievement;

	// Token: 0x04003D97 RID: 15767
	private bool bSignin;

	// Token: 0x04003D98 RID: 15768
	private bool bSigninOpenAchievementUI;

	// Token: 0x04003D99 RID: 15769
	private Dictionary<int, string> RoleAchievementData;

	// Token: 0x04003D9A RID: 15770
	private string[] AchievementIDStr;

	// Token: 0x04003D9B RID: 15771
	private byte[] SendAchievement;

	// Token: 0x04003D9C RID: 15772
	private byte SendCount;

	// Token: 0x04003D9D RID: 15773
	private byte PushIdx;

	// Token: 0x04003D9E RID: 15774
	private byte Popindex;

	// Token: 0x04003D9F RID: 15775
	private byte Sending;

	// Token: 0x04003DA0 RID: 15776
	private byte checkAuthenticate;

	// Token: 0x04003DA1 RID: 15777
	private GamePlayAchievementManager._unlockAchievementList UnlockAchievementListNoSign = new GamePlayAchievementManager._unlockAchievementList(true);

	// Token: 0x04003DA2 RID: 15778
	private float DelayTime;

	// Token: 0x020003F7 RID: 1015
	private struct _unlockAchievementList
	{
		// Token: 0x060014B3 RID: 5299 RVA: 0x0023BD70 File Offset: 0x00239F70
		public _unlockAchievementList(bool init = true)
		{
			this.ID = new byte[32];
			this.Count = 0;
		}

		// Token: 0x060014B4 RID: 5300 RVA: 0x0023BD88 File Offset: 0x00239F88
		public void push(byte val)
		{
			if (val == 0)
			{
				return;
			}
			int num = val - 1 >> 3;
			int num2 = 1 << (int)(val - 1 & 7);
			if (((int)this.ID[num] & num2) == 0)
			{
				this.Count += 1;
			}
			byte[] id = this.ID;
			int num3 = num;
			id[num3] |= (byte)num2;
		}

		// Token: 0x04003DA3 RID: 15779
		public byte[] ID;

		// Token: 0x04003DA4 RID: 15780
		public byte Count;
	}
}
