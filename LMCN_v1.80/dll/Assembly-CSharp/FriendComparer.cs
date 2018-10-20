using System;
using System.Collections.Generic;

// Token: 0x020003D2 RID: 978
public class FriendComparer : IComparer<byte>
{
	// Token: 0x06001463 RID: 5219 RVA: 0x0023A3F4 File Offset: 0x002385F4
	public int Compare(byte x, byte y)
	{
		x -= 1;
		y -= 1;
		if (this.FriendsProgress[(int)x].NodeIndex > this.FriendsProgress[(int)y].NodeIndex)
		{
			return 1;
		}
		if (this.FriendsProgress[(int)x].NodeIndex < this.FriendsProgress[(int)y].NodeIndex)
		{
			return -1;
		}
		if (this.FriendsProgress[(int)x].MissionTime.BeginTime > 0L && this.FriendsProgress[(int)y].MissionTime.BeginTime == 0L)
		{
			return -1;
		}
		if (this.FriendsProgress[(int)x].MissionTime.BeginTime == 0L && this.FriendsProgress[(int)y].MissionTime.BeginTime > 0L)
		{
			return 1;
		}
		if (this.FriendsProgress[(int)x].MissionTime.BeginTime == 0L && this.FriendsProgress[(int)y].MissionTime.BeginTime == 0L)
		{
			if (this.FriendsProgress[(int)x].UserSerialNo > this.FriendsProgress[(int)y].UserSerialNo)
			{
				return 1;
			}
			if (this.FriendsProgress[(int)x].UserSerialNo < this.FriendsProgress[(int)y].UserSerialNo)
			{
				return -1;
			}
		}
		if (this.FriendsProgress[(int)x].MissionTime.BeginTime + (long)((ulong)this.FriendsProgress[(int)x].MissionTime.RequireTime) > this.FriendsProgress[(int)y].MissionTime.BeginTime + (long)((ulong)this.FriendsProgress[(int)y].MissionTime.RequireTime))
		{
			return 1;
		}
		if (this.FriendsProgress[(int)x].MissionTime.BeginTime + (long)((ulong)this.FriendsProgress[(int)x].MissionTime.RequireTime) < this.FriendsProgress[(int)y].MissionTime.BeginTime + (long)((ulong)this.FriendsProgress[(int)y].MissionTime.RequireTime))
		{
			return -1;
		}
		if (this.FriendsProgress[(int)x].UserSerialNo > this.FriendsProgress[(int)y].UserSerialNo)
		{
			return 1;
		}
		if (this.FriendsProgress[(int)x].UserSerialNo < this.FriendsProgress[(int)y].UserSerialNo)
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x04003D06 RID: 15622
	public FBMissionManager.FbMissionProgress[] FriendsProgress;
}
