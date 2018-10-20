using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020003C9 RID: 969
public class FBMissionManager
{
	// Token: 0x06001432 RID: 5170 RVA: 0x002383EC File Offset: 0x002365EC
	public FBMissionManager()
	{
		this.CurMissionProcess = new FBMissionManager.FbMissionProgress();
		this.Goals = new FBMissionManager.FBMissionGoalData[2];
		this.FBFriends = new SocialFriend[10];
		for (int i = 0; i < 10; i++)
		{
			this.FBFriends[i] = new SocialFriend();
		}
		this.HudArray = new FBMissionManager._FBHUMArray(3);
		this.FriendComparer = new FriendComparer();
		this.FriendComparer.FriendsProgress = this.FBFriends;
		this.FriendsIndexTable = new byte[10];
	}

	// Token: 0x06001433 RID: 5171 RVA: 0x00238490 File Offset: 0x00236690
	public void LoadTable()
	{
		this.FBMissionTable = new CExternalTableWithWordKey<FBMissionTbl>();
		this.FBMissionTable.LoadTable("FBMission");
		int num = this.FBMissionTable.TableCount + 1;
		this.FriendsBegin = new byte[num];
		this.FriendsCount = new byte[num];
	}

	// Token: 0x06001434 RID: 5172 RVA: 0x002384E0 File Offset: 0x002366E0
	public ushort GetRewardIndex()
	{
		return (ushort)this.CurFBAwardData.AwardIndex;
	}

	// Token: 0x06001435 RID: 5173 RVA: 0x002384F0 File Offset: 0x002366F0
	public byte GetRewardSerial()
	{
		return this.CurFBAwardData.UserSerialNo;
	}

	// Token: 0x06001436 RID: 5174 RVA: 0x00238500 File Offset: 0x00236700
	public ushort GetRewardCount()
	{
		return this.CurFBAwardData.AwardTotalNum;
	}

	// Token: 0x06001437 RID: 5175 RVA: 0x00238510 File Offset: 0x00236710
	public FBMissionManager.FBAward GetReward()
	{
		return this.CurFBAwardData;
	}

	// Token: 0x06001438 RID: 5176 RVA: 0x00238518 File Offset: 0x00236718
	public void GetMissionState(ref FBMissionManager.FBMissionState State, ushort ID, int index)
	{
		if (index >= 2)
		{
			State = default(FBMissionManager.FBMissionState);
			return;
		}
		FBMissionTbl recordByKey = this.FBMissionTable.GetRecordByKey(ID);
		State.type = recordByKey.MissionItems[index].Kind;
		State.GoalNum = recordByKey.MissionItems[index].Parm;
		if (State.type == 1 || State.type == 3 || State.type == 4 || State.type == 7 || State.type == 8 || State.type == 10 || State.type == 15 || State.type == 17 || 18 < State.type)
		{
			State.bCount = 0;
		}
		else
		{
			State.bCount = 1;
		}
		if (ID == (ushort)this.CurMissionProcess.NodeIndex)
		{
			State.CurNum = this.Goals[index].Record;
			if (State.CurNum > State.GoalNum)
			{
				State.CurNum = State.GoalNum;
			}
		}
		else
		{
			State.CurNum = (State.GoalNum = 0u);
		}
	}

	// Token: 0x06001439 RID: 5177 RVA: 0x00238658 File Offset: 0x00236858
	public void GetNarrative(CString NarrativeStr, ref FBMissionTbl ManorData, byte id, bool checkCurMission = true)
	{
		DataManager instance = DataManager.Instance;
		NarrativeStr.ClearString();
		if ((int)id >= ManorData.MissionItems.Length)
		{
			return;
		}
		FBMissionManager.FBMissionState fbmissionState = default(FBMissionManager.FBMissionState);
		if (checkCurMission)
		{
			this.GetMissionState(ref fbmissionState, ManorData.ID, (int)id);
		}
		switch (ManorData.MissionItems[(int)id].Kind)
		{
		case 0:
			break;
		case 1:
		case 2:
		case 3:
		case 5:
		case 6:
		case 9:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 18:
			NarrativeStr.IntToFormat((long)((ulong)ManorData.MissionItems[(int)id].Parm), 0, true);
			if (checkCurMission && fbmissionState.bCount == 1 && fbmissionState.CurNum < fbmissionState.GoalNum)
			{
				NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.OwnProcressDescribe[(int)id]));
			}
			else
			{
				NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.MissionItems[(int)id].Descirb));
			}
			break;
		case 4:
			NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint)instance.TalentData.GetRecordByKey((ushort)ManorData.MissionItems[(int)id].Parm).NameID));
			NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.MissionItems[(int)id].Descirb));
			break;
		case 7:
			NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint)DataManager.StageDataController.CorpsStageTable.GetRecordByKey((ushort)ManorData.MissionItems[(int)id].Parm).StageName));
			NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.MissionItems[(int)id].Descirb));
			break;
		case 8:
		{
			CString cstring = StringManager.Instance.StaticString1024();
			uint num = ManorData.MissionItems[(int)id].Parm / 18u;
			uint num2 = ManorData.MissionItems[(int)id].Parm % 18u;
			if (num2 > 0u)
			{
				num += 1u;
			}
			cstring.IntToFormat((long)((ulong)num), 1, false);
			if (num2 == 0u)
			{
				num2 = 18u;
			}
			cstring.IntToFormat((long)((ulong)num2), 1, false);
			cstring.AppendFormat("{0}-{1}");
			NarrativeStr.StringToFormat(cstring);
			NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.MissionItems[(int)id].Descirb));
			break;
		}
		case 10:
		case 17:
			NarrativeStr.Append(instance.mStringTable.GetStringByID((uint)ManorData.MissionItems[(int)id].Descirb));
			break;
		default:
			NarrativeStr.Append(instance.mStringTable.GetStringByID(1049u));
			break;
		}
	}

	// Token: 0x0600143A RID: 5178 RVA: 0x00238938 File Offset: 0x00236B38
	public bool IsInTime()
	{
		return this.CurMissionProcess.MissionTime.BeginTime + (long)((ulong)this.CurMissionProcess.MissionTime.RequireTime) > DataManager.Instance.ServerTime;
	}

	// Token: 0x0600143B RID: 5179 RVA: 0x0023897C File Offset: 0x00236B7C
	public uint GetRemainTime()
	{
		long num = this.CurMissionProcess.MissionTime.BeginTime + (long)((ulong)this.CurMissionProcess.MissionTime.RequireTime) - DataManager.Instance.ServerTime;
		if (num > 0L)
		{
			return (uint)num;
		}
		return 0u;
	}

	// Token: 0x0600143C RID: 5180 RVA: 0x002389C4 File Offset: 0x00236BC4
	public void CheckHUDMsg(byte kind)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		GUIManager instance = GUIManager.Instance;
		int num = 0;
		this.HudArray.Find(kind, ref num, cstring);
		while (num != -1)
		{
			instance.AddHUDQueue(cstring.ToString(), 255, true);
			cstring = StringManager.Instance.StaticString1024();
			this.HudArray.Find(kind, ref num, cstring);
		}
		byte b = 0;
		FBMissionManager.FBMissionState fbmissionState = default(FBMissionManager.FBMissionState);
		for (int i = 0; i < 2; i++)
		{
			this.GetMissionState(ref fbmissionState, this.Goals[i].MissionId, i);
			if (fbmissionState.GoalNum == fbmissionState.CurNum && fbmissionState.CurNum > 0u)
			{
				b += 1;
			}
		}
		if (b == 2 && this.CurMissionProcess.bShowHUD == 0)
		{
			this.CurMissionProcess.bShowHUD = 1;
			FBMissionTbl recordByKey = this.FBMissionTable.GetRecordByKey((ushort)this.CurMissionProcess.NodeIndex);
			cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.Name));
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12184u));
			GUIManager.Instance.AddHUDQueue(cstring.ToString(), 255, true);
		}
	}

	// Token: 0x0600143D RID: 5181 RVA: 0x00238B20 File Offset: 0x00236D20
	public void ClearHUDArray()
	{
		this.HudArray.Clear();
	}

	// Token: 0x0600143E RID: 5182 RVA: 0x00238B30 File Offset: 0x00236D30
	public void OnLoginFinish()
	{
		this.HudArray.Clear();
	}

	// Token: 0x0600143F RID: 5183 RVA: 0x00238B40 File Offset: 0x00236D40
	public int GetFriendIndex(byte serialno, byte index = 255)
	{
		int result = -1;
		if (index < this.CurrentFriendNum && this.FBFriends[(int)index].UserSerialNo == serialno)
		{
			result = (int)index;
		}
		else
		{
			for (int i = 0; i < (int)this.CurrentFriendNum; i++)
			{
				if (this.FBFriends[i].UserSerialNo == serialno)
				{
					result = i;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x06001440 RID: 5184 RVA: 0x00238BA8 File Offset: 0x00236DA8
	private void SortFriends()
	{
		if (this.NeedSort == 0)
		{
			return;
		}
		this.NeedSort = 0;
		Array.Clear(this.FriendsCount, 0, this.FriendsCount.Length);
		Array.Sort<byte>(this.FriendsIndexTable, 0, (int)this.CurrentFriendNum, this.FriendComparer);
		byte b = 0;
		for (byte b2 = 0; b2 < this.CurrentFriendNum; b2 += 1)
		{
			int num = (int)(this.FriendsIndexTable[(int)b2] - 1);
			if (num >= 0)
			{
				if (this.FBFriends[num].NodeIndex != b)
				{
					if ((int)this.FBFriends[num].NodeIndex >= this.FriendsBegin.Length)
					{
						break;
					}
					b = this.FBFriends[num].NodeIndex;
					this.FriendsBegin[(int)b] = b2;
					this.FriendsCount[(int)b] = 1;
				}
				else
				{
					byte[] friendsCount = this.FriendsCount;
					byte b3 = b;
					friendsCount[(int)b3] = friendsCount[(int)b3] + 1;
				}
			}
		}
	}

	// Token: 0x06001441 RID: 5185 RVA: 0x00238C90 File Offset: 0x00236E90
	public byte GetFriendCountByProgress(byte progress)
	{
		byte result = 0;
		this.SortFriends();
		if ((int)progress < this.FriendsCount.Length)
		{
			result = this.FriendsCount[(int)progress];
		}
		return result;
	}

	// Token: 0x06001442 RID: 5186 RVA: 0x00238CC0 File Offset: 0x00236EC0
	public void GetFriendSocialInfo(byte progress, int index, out SocialFriend friend, bool GetInfo = true)
	{
		friend = null;
		if ((int)progress >= this.FriendsCount.Length || index >= (int)this.FriendsCount[(int)progress])
		{
			return;
		}
		int num = (int)(this.FriendsIndexTable[(int)this.FriendsBegin[(int)progress] + index] - 1);
		if (num >= this.FBFriends.Length)
		{
			return;
		}
		friend = this.FBFriends[num];
		if (GetInfo && this.FBFriends[num].Name.Length == 0)
		{
			this.SendFriend_SocialInfo(this.FBFriends[num].UserSerialNo);
		}
	}

	// Token: 0x06001443 RID: 5187 RVA: 0x00238D4C File Offset: 0x00236F4C
	public FBMissionManager.FBAward GetAwardSocialInfo()
	{
		return this.CurFBAwardData;
	}

	// Token: 0x06001444 RID: 5188 RVA: 0x00238D54 File Offset: 0x00236F54
	public EmojiUnit GetFriendEmoji(byte progress, int index)
	{
		SocialFriend socialFriend;
		this.GetFriendSocialInfo(progress, index, out socialFriend, false);
		if (socialFriend != null)
		{
			return this.GetFriendEmoji((ushort)socialFriend.IconNo);
		}
		return null;
	}

	// Token: 0x06001445 RID: 5189 RVA: 0x00238D80 File Offset: 0x00236F80
	public EmojiUnit GetFriendEmoji(ushort key)
	{
		if (key == 0 || (int)key > this.FriendIconTable.Length)
		{
			key = 1;
		}
		return GUIManager.Instance.pullEmojiIcon((ushort)this.FriendIconTable[(int)(key - 1)], 0, false);
	}

	// Token: 0x06001446 RID: 5190 RVA: 0x00238DB0 File Offset: 0x00236FB0
	public bool CheckReSetFB_CDTime()
	{
		bool result = false;
		long num = 0L;
		long num2 = 0L;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.IntToFormat(NetworkManager.UserID, 1, false);
		cstring.AppendFormat("{0}_FB_CDTime_UseID");
		long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out num);
		if (num == 0L)
		{
			PlayerPrefs.SetString(cstring.ToString(), NetworkManager.UserID.ToString());
			num = NetworkManager.UserID;
		}
		cstring.ClearString();
		cstring.IntToFormat(num, 1, false);
		cstring.AppendFormat("{0}_FB_CDTime_Time");
		long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out num2);
		if ((num2 > 0L && num2 - ActivityManager.Instance.ServerEventTime <= 0L) || num2 == 0L)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x06001447 RID: 5191 RVA: 0x00238E78 File Offset: 0x00237078
	public bool IsCanSetFB_CDTime(CString tmpName = null, long m_UseID = 0L)
	{
		bool result = false;
		if (tmpName == null)
		{
			tmpName = StringManager.Instance.StaticString1024();
		}
		long num = 0L;
		if (m_UseID == 0L)
		{
			tmpName.ClearString();
			tmpName.IntToFormat(NetworkManager.UserID, 1, false);
			tmpName.AppendFormat("{0}_FB_CDTime_UseID");
			long.TryParse(PlayerPrefs.GetString(tmpName.ToString()), out m_UseID);
		}
		tmpName.ClearString();
		tmpName.IntToFormat(m_UseID, 1, false);
		tmpName.AppendFormat("{0}_FB_CDTime_Time_Check");
		long.TryParse(PlayerPrefs.GetString(tmpName.ToString()), out num);
		if (num == 0L || (num <= ActivityManager.Instance.ServerEventTime && GameConstants.GetDateTime(num + 86400L).Day <= GameConstants.GetDateTime(ActivityManager.Instance.ServerEventTime).Day) || GameConstants.GetDateTime(num + 86400L).Month < GameConstants.GetDateTime(ActivityManager.Instance.ServerEventTime).Month || GameConstants.GetDateTime(num + 86400L).Year < GameConstants.GetDateTime(ActivityManager.Instance.ServerEventTime).Year)
		{
			result = true;
			PlayerPrefs.SetString(tmpName.ToString(), ActivityManager.Instance.ServerEventTime.ToString());
		}
		return result;
	}

	// Token: 0x06001448 RID: 5192 RVA: 0x00238FD0 File Offset: 0x002371D0
	public void ReSetFB_CDTime(CString tmpName = null)
	{
		long num = 0L;
		if (tmpName == null)
		{
			tmpName = StringManager.Instance.StaticString1024();
		}
		tmpName.ClearString();
		tmpName.IntToFormat(NetworkManager.UserID, 1, false);
		tmpName.AppendFormat("{0}_FB_CDTime_UseID");
		long.TryParse(PlayerPrefs.GetString(tmpName.ToString()), out num);
		if (!this.IsCanSetFB_CDTime(tmpName, num))
		{
			return;
		}
		tmpName.ClearString();
		tmpName.IntToFormat(num, 1, false);
		tmpName.AppendFormat("{0}_FB_CDTime_Time");
		long num2 = (long)(86400 * UnityEngine.Random.Range(10, 14));
		PlayerPrefs.SetString(tmpName.ToString(), (ActivityManager.Instance.ServerEventTime + num2).ToString());
		DataManager.FBMissionDataManager.bFB_btnShow = false;
	}

	// Token: 0x06001449 RID: 5193 RVA: 0x00239088 File Offset: 0x00237288
	public void RecvFBMissionInfo(MessagePacket MP)
	{
		this.CurMissionProcess.UserSerialNo = MP.ReadByte(-1);
		this.CurMissionProcess.NodeIndex = MP.ReadByte(-1);
		this.CurMissionProcess.MissionTime.BeginTime = MP.ReadLong(-1);
		this.CurMissionProcess.MissionTime.RequireTime = MP.ReadUInt(-1);
		if (this.CurMissionProcess.NodeIndex > 1)
		{
			AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_I);
		}
		if (this.CurMissionProcess.NodeIndex > 2)
		{
			AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_II);
		}
		if (this.CurMissionProcess.NodeIndex > 3)
		{
			AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_III);
		}
		if (this.CurMissionProcess.NodeIndex > 4)
		{
			AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_IV);
		}
		if (this.CurMissionProcess.NodeIndex > 5)
		{
			AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_V);
		}
		if (this.CurMissionProcess.NodeIndex > 10)
		{
			AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_X);
		}
		FBMissionManager.FBMissionState fbmissionState = default(FBMissionManager.FBMissionState);
		byte b = 2;
		for (int i = 0; i < 2; i++)
		{
			this.Goals[i].MissionId = MP.ReadUShort(-1);
			this.Goals[i].GoalIndex = MP.ReadByte(-1);
			this.Goals[i].Type = MP.ReadByte(-1);
			this.Goals[i].Record = MP.ReadUInt(-1);
			this.GetMissionState(ref fbmissionState, this.Goals[i].MissionId, i);
			if (fbmissionState.CurNum == fbmissionState.GoalNum)
			{
				b -= 1;
			}
		}
		if (b == 0)
		{
			this.CurMissionProcess.bShowHUD = 1;
		}
		this.CurFBAwardData.UserSerialNo = MP.ReadByte(-1);
		this.CurFBAwardData.AwardIndex = MP.ReadByte(-1);
		this.CurFBAwardData.AwardTotalNum = MP.ReadUShort(-1);
		this.CurrentFriendNum = MP.ReadByte(-1);
		if (this.CurrentFriendNum > 10)
		{
			this.CurrentFriendNum = 10;
		}
		for (int j = 0; j < (int)this.CurrentFriendNum; j++)
		{
			this.FBFriends[j].Clear();
			this.FBFriends[j].UserSerialNo = MP.ReadByte(-1);
			this.FriendsIndexTable[j] = (byte)(j + 1);
			this.FBFriends[j].NodeIndex = MP.ReadByte(-1);
			if (this.FBFriends[j].NodeIndex == 0)
			{
				this.FBFriends[j].NodeIndex = 1;
			}
			this.FBFriends[j].MissionTime.BeginTime = MP.ReadLong(-1);
			this.FBFriends[j].MissionTime.RequireTime = MP.ReadUInt(-1);
			this.FBFriends[j].TimeRemain = (this.FBFriends[j].MissionTime.BeginTime > 0L);
		}
		this.NeedSort = 1;
		DataManager.Instance.RoleAttr.Inviter.Name.ClearString();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 20, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other, 5, 0);
	}

	// Token: 0x0600144A RID: 5194 RVA: 0x002393CC File Offset: 0x002375CC
	public void RecvFBMissionStart(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Mission);
		byte b = MP.ReadByte(-1);
		if (b > 0)
		{
			return;
		}
		this.CurMissionProcess.MissionTime.BeginTime = MP.ReadLong(-1);
		this.CurMissionProcess.MissionTime.RequireTime = MP.ReadUInt(-1);
		DataManager instance = DataManager.Instance;
		instance.RoleAttr.PrizeFlag = (instance.RoleAttr.PrizeFlag | 134217728u);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 0);
	}

	// Token: 0x0600144B RID: 5195 RVA: 0x00239450 File Offset: 0x00237650
	public void SendFBGetReward()
	{
		GUIManager.Instance.ShowUILock(EUILock.Mission);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_FB_GET_AWARD;
		messagePacket.AddSeqId();
		messagePacket.Add(this.CurFBAwardData.UserSerialNo);
		messagePacket.Add(this.CurFBAwardData.AwardIndex);
		messagePacket.Send(false);
	}

	// Token: 0x0600144C RID: 5196 RVA: 0x002394B0 File Offset: 0x002376B0
	public void RecvFBGetReward(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Mission);
		byte b = MP.ReadByte(-1);
		if (b > 0)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat((long)b, 1, false);
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12185u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
			return;
		}
		if (this.CurFBAwardData.AwardIndex == 11)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 1, 0);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 1);
		AudioManager.Instance.PlayUISFX(UIKind.RewardReceive);
	}

	// Token: 0x0600144D RID: 5197 RVA: 0x00239564 File Offset: 0x00237764
	public void UpdateFBMissionProGress(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (this.CurMissionProcess.UserSerialNo == b)
		{
			byte b2 = MP.ReadByte(-1);
			if (this.CurMissionProcess.NodeIndex != b2)
			{
				this.CurMissionProcess.bShowHUD = 0;
				this.ClearHUDArray();
			}
			this.CurMissionProcess.NodeIndex = b2;
			this.CurMissionProcess.MissionTime.BeginTime = MP.ReadLong(-1);
			this.CurMissionProcess.MissionTime.RequireTime = MP.ReadUInt(-1);
			if (this.CurMissionProcess.NodeIndex > 1)
			{
				AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_I);
			}
			if (this.CurMissionProcess.NodeIndex > 2)
			{
				AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_II);
			}
			if (this.CurMissionProcess.NodeIndex > 3)
			{
				AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_III);
			}
			if (this.CurMissionProcess.NodeIndex > 4)
			{
				AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_IV);
			}
			if (this.CurMissionProcess.NodeIndex > 5)
			{
				AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_V);
			}
			if (this.CurMissionProcess.NodeIndex > 10)
			{
				AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_X);
			}
		}
		else
		{
			int friendIndex = this.GetFriendIndex(b, byte.MaxValue);
			if (friendIndex < 0)
			{
				return;
			}
			this.UpdateFriendSerialNo = byte.MaxValue;
			this.FBFriends[friendIndex].NodeIndex = MP.ReadByte(-1);
			if (this.FBFriends[friendIndex].NodeIndex == 0)
			{
				this.FBFriends[friendIndex].NodeIndex = 1;
			}
			this.FBFriends[friendIndex].MissionTime.BeginTime = MP.ReadLong(-1);
			this.FBFriends[friendIndex].MissionTime.RequireTime = MP.ReadUInt(-1);
			this.NeedSort = 1;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 0, 0);
		}
	}

	// Token: 0x0600144E RID: 5198 RVA: 0x00239748 File Offset: 0x00237948
	public void UpdateMissionReward(MessagePacket MP)
	{
		ushort awardTotalNum = this.CurFBAwardData.AwardTotalNum;
		this.CurFBAwardData.UserSerialNo = MP.ReadByte(-1);
		this.CurFBAwardData.AwardIndex = MP.ReadByte(-1);
		this.CurFBAwardData.AwardTotalNum = MP.ReadUShort(-1);
		if (this.CurFBAwardData.AwardTotalNum > awardTotalNum && this.CurMissionProcess.UserSerialNo != this.CurFBAwardData.UserSerialNo)
		{
			GUIManager.Instance.AddHUDQueue(DataManager.Instance.mStringTable.GetStringByID(12189u), 255, true);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 1);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 20, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other, 5, 0);
	}

	// Token: 0x0600144F RID: 5199 RVA: 0x00239814 File Offset: 0x00237A14
	public void UpdateMissionGoals(MessagePacket MP)
	{
		FBMissionManager.FBMissionState fbmissionState = default(FBMissionManager.FBMissionState);
		byte b = 0;
		byte b2 = 2;
		FBMissionTbl recordByKey = this.FBMissionTable.GetRecordByKey((ushort)this.CurMissionProcess.NodeIndex);
		byte b3 = 0;
		for (int i = 0; i < 2; i++)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != this.Goals[i].MissionId)
			{
				this.Goals[i].Clear();
			}
			this.Goals[i].MissionId = num;
			this.GetMissionState(ref fbmissionState, this.Goals[i].MissionId, i);
			uint curNum = fbmissionState.CurNum;
			this.Goals[i].GoalIndex = MP.ReadByte(-1);
			this.Goals[i].Type = MP.ReadByte(-1);
			this.Goals[i].Record = MP.ReadUInt(-1);
			this.GetMissionState(ref fbmissionState, this.Goals[i].MissionId, i);
			if (fbmissionState.GoalNum == fbmissionState.CurNum && fbmissionState.CurNum > 0u)
			{
				b += 1;
				if (recordByKey.MissionItems[i].Kind != 17)
				{
					if (fbmissionState.CurNum > curNum)
					{
						CString cstring = StringManager.Instance.StaticString1024();
						CString cstring2 = StringManager.Instance.StaticString1024();
						this.GetNarrative(cstring2, ref recordByKey, (byte)i, false);
						cstring.StringToFormat(cstring2);
						cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12183u));
						if (this.Goals[i].Type == 11)
						{
							b3 = this.Goals[i].Type;
							this.HudArray.Add(cstring, this.Goals[i].MissionId, this.Goals[i].Type);
						}
						else if (this.Goals[i].Type == 7)
						{
							if (recordByKey.MissionItems[i].Parm > (uint)DataManager.StageDataController.StageRecord[2])
							{
								b3 = this.Goals[i].Type;
								this.HudArray.Add(cstring, this.Goals[i].MissionId, this.Goals[i].Type);
							}
							else
							{
								GUIManager.Instance.AddHUDQueue(cstring.ToString(), 255, true);
							}
						}
						else
						{
							GUIManager.Instance.AddHUDQueue(cstring.ToString(), 255, true);
						}
					}
				}
				else
				{
					b2 -= 1;
				}
			}
		}
		if (b3 == 0 && b == b2 && this.CurMissionProcess.bShowHUD == 0)
		{
			this.CurMissionProcess.bShowHUD = 1;
			if (recordByKey.ID == 11)
			{
				GUIManager.Instance.AddHUDQueue(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.Name), 255, true);
			}
			else
			{
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.Name));
				cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12184u));
				GUIManager.Instance.AddHUDQueue(cstring.ToString(), 255, true);
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 0, 0);
	}

	// Token: 0x06001450 RID: 5200 RVA: 0x00239BC4 File Offset: 0x00237DC4
	public void RecvSocialData(MessagePacket MP)
	{
		MP.ReadStringPlus(41, SocialManager.Instance.SocialName, -1);
		DataManager.Instance.RoleAttr.Inviter.Invited = MP.ReadByte(-1);
		MP.ReadStringPlus(41, DataManager.Instance.RoleAttr.Inviter.SocialName, -1);
		SocialManager.Instance.MaxConcurrentFriend = MP.ReadByte(-1);
		this.CurrentFriendNum = MP.ReadByte(-1);
		if (this.CurrentFriendNum > 10)
		{
			this.CurrentFriendNum = 10;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		for (byte b = 0; b < this.CurrentFriendNum; b += 1)
		{
			MP.ReadStringPlus(41, cstring, -1);
			byte b2 = MP.ReadByte(-1);
			if (this.FBFriends[(int)b].UserSerialNo != b2)
			{
				this.FBFriends[(int)b].TimeRemain = false;
				this.FBFriends[(int)b].Clear();
			}
			this.FBFriends[(int)b].SocialName.ClearString();
			this.FBFriends[(int)b].SocialName.Append(cstring);
			this.FBFriends[(int)b].UserSerialNo = b2;
			this.FBFriends[(int)b].IconNo = MP.ReadByte(-1);
			this.FriendsIndexTable[(int)b] = b + 1;
		}
		for (byte b3 = this.CurrentFriendNum; b3 < 10; b3 += 1)
		{
			this.FBFriends[(int)b3].UserSerialNo = 0;
		}
		this.NeedSort = 1;
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 0);
		if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 2 && DataManager.Instance.RoleAttr.Inviter.Invited > 0 && !SocialManager.Instance.CheckBonding(false) && !DataManager.Instance.CheckPrizeFlag(30))
		{
			SocialManager.Instance.BindingPlatform(true);
		}
	}

	// Token: 0x06001451 RID: 5201 RVA: 0x00239DA8 File Offset: 0x00237FA8
	public void SendFriend_SocialInfo(byte serialno)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_FRIEND_USER_INFO;
		messagePacket.AddSeqId();
		messagePacket.Add(serialno);
		messagePacket.Send(false);
	}

	// Token: 0x06001452 RID: 5202 RVA: 0x00239DE0 File Offset: 0x00237FE0
	public void RespFriendSocialInfo(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = MP.ReadByte(-1);
		if (b2 > 0)
		{
			int friendIndex = this.GetFriendIndex(b2, byte.MaxValue);
			if (friendIndex < 0)
			{
				return;
			}
			this.UpdateFriendSerialNo = b2;
			this.FBFriends[friendIndex].Result = b;
			this.FBFriends[friendIndex].Head = MP.ReadUShort(-1);
			MP.ReadStringPlus(13, this.FBFriends[friendIndex].Name, -1);
			MP.ReadStringPlus(3, this.FBFriends[friendIndex].AllianceTag, -1);
			if (this.FBFriends[friendIndex].Name.Length == 0 && b == 0)
			{
				return;
			}
		}
		else
		{
			this.UpdateFriendSerialNo = b2;
			DataManager.Instance.RoleAttr.Inviter.Result = b;
			DataManager.Instance.RoleAttr.Inviter.Head = MP.ReadUShort(-1);
			MP.ReadStringPlus(13, DataManager.Instance.RoleAttr.Inviter.Name, -1);
			MP.ReadStringPlus(3, DataManager.Instance.RoleAttr.Inviter.AllianceTag, -1);
			if (DataManager.Instance.RoleAttr.Inviter.Name.Length == 0 && b == 0)
			{
				return;
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 0, 0);
	}

	// Token: 0x06001453 RID: 5203 RVA: 0x00239F38 File Offset: 0x00238138
	public void UpdateFriendName(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			MP.ReadStringPlus(13, DataManager.Instance.RoleAttr.Inviter.Name, -1);
		}
		else
		{
			CString cstring = StringManager.Instance.StaticString1024();
			MP.ReadStringPlus(13, cstring, -1);
			int friendIndex = this.GetFriendIndex(b, byte.MaxValue);
			if (friendIndex >= 0)
			{
				this.UpdateFriendSerialNo = b;
				this.FBFriends[friendIndex].Name.ClearString();
				this.FBFriends[friendIndex].Name.Append(cstring);
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 0, 0);
	}

	// Token: 0x06001454 RID: 5204 RVA: 0x00239FDC File Offset: 0x002381DC
	public void RESP_SOCIAL_ENABLE(MessagePacket MP)
	{
		byte invitation = DataManager.Instance.RoleAttr.Invitation;
		DataManager.Instance.RoleAttr.Invitation = MP.ReadByte(-1);
		if (DataManager.Instance.RoleAttr.Invitation != invitation)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 0);
		}
	}

	// Token: 0x04003CCB RID: 15563
	public const byte MaxPriceNum = 4;

	// Token: 0x04003CCC RID: 15564
	public const byte MaxMiaaionKind = 18;

	// Token: 0x04003CCD RID: 15565
	public const byte MAX_FB_FRIEND_IN_MISSION_NUM = 10;

	// Token: 0x04003CCE RID: 15566
	public const byte SOCIAL_NAME_LEN = 41;

	// Token: 0x04003CCF RID: 15567
	public const byte FB_MISSION_GOAL_NUM = 2;

	// Token: 0x04003CD0 RID: 15568
	public CExternalTableWithWordKey<FBMissionTbl> FBMissionTable;

	// Token: 0x04003CD1 RID: 15569
	public FBMissionManager.FBMissionGoalData[] Goals;

	// Token: 0x04003CD2 RID: 15570
	public FBMissionManager.FbMissionProgress CurMissionProcess;

	// Token: 0x04003CD3 RID: 15571
	private FBMissionManager.FBAward CurFBAwardData;

	// Token: 0x04003CD4 RID: 15572
	public byte CurrentFriendNum;

	// Token: 0x04003CD5 RID: 15573
	public SocialFriend[] FBFriends;

	// Token: 0x04003CD6 RID: 15574
	private FriendComparer FriendComparer;

	// Token: 0x04003CD7 RID: 15575
	public byte UpdateFriendSerialNo;

	// Token: 0x04003CD8 RID: 15576
	public bool m_FBTimeEnd;

	// Token: 0x04003CD9 RID: 15577
	public bool m_FBBindEnd;

	// Token: 0x04003CDA RID: 15578
	public bool bFB_CDTime;

	// Token: 0x04003CDB RID: 15579
	public bool bFB_btnShow;

	// Token: 0x04003CDC RID: 15580
	private FBMissionManager._FBHUMArray HudArray;

	// Token: 0x04003CDD RID: 15581
	private byte[] FriendsIndexTable;

	// Token: 0x04003CDE RID: 15582
	private byte[] FriendsBegin;

	// Token: 0x04003CDF RID: 15583
	private byte[] FriendsCount;

	// Token: 0x04003CE0 RID: 15584
	public byte NeedSort;

	// Token: 0x04003CE1 RID: 15585
	private byte[] FriendIconTable = new byte[]
	{
		3,
		6,
		2,
		14,
		11,
		15,
		26,
		29,
		30,
		25
	};

	// Token: 0x020003CA RID: 970
	public struct FBMissionGoalData
	{
		// Token: 0x06001455 RID: 5205 RVA: 0x0023A034 File Offset: 0x00238234
		public void Clear()
		{
			this.MissionId = 0;
			this.GoalIndex = 0;
			this.Type = 0;
			this.Record = 0u;
		}

		// Token: 0x04003CE2 RID: 15586
		public ushort MissionId;

		// Token: 0x04003CE3 RID: 15587
		public byte GoalIndex;

		// Token: 0x04003CE4 RID: 15588
		public byte Type;

		// Token: 0x04003CE5 RID: 15589
		public uint Record;
	}

	// Token: 0x020003CB RID: 971
	public struct FBAward
	{
		// Token: 0x04003CE6 RID: 15590
		public byte UserSerialNo;

		// Token: 0x04003CE7 RID: 15591
		public byte AwardIndex;

		// Token: 0x04003CE8 RID: 15592
		public ushort AwardTotalNum;
	}

	// Token: 0x020003CC RID: 972
	public class FbMissionProgress
	{
		// Token: 0x04003CE9 RID: 15593
		public byte UserSerialNo;

		// Token: 0x04003CEA RID: 15594
		public byte NodeIndex;

		// Token: 0x04003CEB RID: 15595
		public byte bShowHUD;

		// Token: 0x04003CEC RID: 15596
		public TimeEventDataType MissionTime;
	}

	// Token: 0x020003CD RID: 973
	private struct _FBHUMArray
	{
		// Token: 0x06001457 RID: 5207 RVA: 0x0023A05C File Offset: 0x0023825C
		public _FBHUMArray(byte count)
		{
			this.Msg = new CString[(int)count];
			for (int i = 0; i < (int)count; i++)
			{
				this.Msg[i] = new CString(64);
			}
			this.Kind = new byte[(int)count];
			this.Size = 0;
			this.End = 0;
			this.MissionID = 0;
		}

		// Token: 0x06001458 RID: 5208 RVA: 0x0023A0B8 File Offset: 0x002382B8
		public void Add(CString msg, ushort missionID, byte kind)
		{
			if (this.MissionID > 0 && this.MissionID != missionID)
			{
				this.Clear();
			}
			if ((int)this.Size >= this.Msg.Length || this.End >= this.Msg.Length)
			{
				return;
			}
			this.MissionID = missionID;
			this.Msg[this.End].ClearString();
			this.Msg[this.End].Append(msg);
			this.Kind[this.End] = kind;
			this.End++;
			this.Size += 1;
		}

		// Token: 0x06001459 RID: 5209 RVA: 0x0023A164 File Offset: 0x00238364
		public void Clear()
		{
			this.Size = 0;
			this.End = 0;
			this.MissionID = 0;
		}

		// Token: 0x0600145A RID: 5210 RVA: 0x0023A17C File Offset: 0x0023837C
		public void Find(byte kind, ref int index, CString msg)
		{
			if (this.Size == 0)
			{
				index = -1;
				return;
			}
			byte size = this.Size;
			for (int i = index; i < this.Kind.Length; i++)
			{
				if (this.Kind[i] == kind)
				{
					this.Kind[i] = byte.MaxValue;
					this.Size -= 1;
					msg.ClearString();
					msg.Append(this.Msg[i]);
					break;
				}
			}
			if (size == this.Size)
			{
				index = -1;
			}
		}

		// Token: 0x04003CED RID: 15597
		public CString[] Msg;

		// Token: 0x04003CEE RID: 15598
		public byte[] Kind;

		// Token: 0x04003CEF RID: 15599
		public ushort MissionID;

		// Token: 0x04003CF0 RID: 15600
		public byte Size;

		// Token: 0x04003CF1 RID: 15601
		private int End;
	}

	// Token: 0x020003CE RID: 974
	public struct FBMissionState
	{
		// Token: 0x04003CF2 RID: 15602
		public byte bCount;

		// Token: 0x04003CF3 RID: 15603
		public byte type;

		// Token: 0x04003CF4 RID: 15604
		public uint CurNum;

		// Token: 0x04003CF5 RID: 15605
		public uint GoalNum;
	}

	// Token: 0x020003CF RID: 975
	private class _FriendUI
	{
		// Token: 0x04003CF6 RID: 15606
		public byte SerialNo;

		// Token: 0x04003CF7 RID: 15607
		public Image HeadImg;

		// Token: 0x04003CF8 RID: 15608
		public UIText SocialText;

		// Token: 0x04003CF9 RID: 15609
		public UIText NameText;

		// Token: 0x04003CFA RID: 15610
		public CString NameStr;
	}

	// Token: 0x020003D0 RID: 976
	private struct FriendUIInfoQueue
	{
		// Token: 0x0600145C RID: 5212 RVA: 0x0023A214 File Offset: 0x00238414
		public FriendUIInfoQueue(byte Capacity)
		{
			this.head = 0;
			this.size = 0;
			this.FriendUI = new FBMissionManager._FriendUI[(int)Capacity];
			for (int i = 0; i < (int)Capacity; i++)
			{
				this.FriendUI[i] = new FBMissionManager._FriendUI();
			}
		}

		// Token: 0x0600145D RID: 5213 RVA: 0x0023A25C File Offset: 0x0023845C
		public void Push(Image HeadImg, UIText Name, UIText SocialName, CString NameStr, byte SerialNo)
		{
			int num = this.FriendUI.Length;
			if (num <= (int)this.size)
			{
				return;
			}
			int num2 = (int)(this.head + this.size) % num;
			this.size += 1;
			this.FriendUI[num2].SerialNo = SerialNo;
			this.FriendUI[num2].HeadImg = HeadImg;
			this.FriendUI[num2].NameText = Name;
			this.FriendUI[num2].SocialText = SocialName;
			this.FriendUI[num2].NameStr = NameStr;
		}

		// Token: 0x0600145E RID: 5214 RVA: 0x0023A2E8 File Offset: 0x002384E8
		public FBMissionManager._FriendUI Pop()
		{
			if (this.size == 0)
			{
				return null;
			}
			FBMissionManager._FriendUI[] friendUI = this.FriendUI;
			byte b;
			this.head = (b = this.head) + 1;
			FBMissionManager._FriendUI result = friendUI[(int)b];
			if ((int)this.head == this.FriendUI.Length)
			{
				this.head = 0;
			}
			this.size -= 1;
			return result;
		}

		// Token: 0x0600145F RID: 5215 RVA: 0x0023A348 File Offset: 0x00238548
		public void clear()
		{
			this.head = 0;
			this.size = 0;
		}

		// Token: 0x04003CFB RID: 15611
		public byte head;

		// Token: 0x04003CFC RID: 15612
		public byte size;

		// Token: 0x04003CFD RID: 15613
		public FBMissionManager._FriendUI[] FriendUI;
	}
}
