using System;

// Token: 0x020007B5 RID: 1973
internal class SocialManager
{
	// Token: 0x0600286A RID: 10346 RVA: 0x00446CA8 File Offset: 0x00444EA8
	private SocialManager()
	{
		this.SocialName = new CString(42);
		this.InviterTag = new CString(4);
	}

	// Token: 0x1700010C RID: 268
	// (get) Token: 0x0600286C RID: 10348 RVA: 0x00446CE4 File Offset: 0x00444EE4
	public bool CanInvite
	{
		get
		{
			return (DataManager.Instance.RoleAttr.Invitation & 1) > 0;
		}
	}

	// Token: 0x1700010D RID: 269
	// (get) Token: 0x0600286D RID: 10349 RVA: 0x00446CFC File Offset: 0x00444EFC
	public static SocialManager Instance
	{
		get
		{
			if (SocialManager.SM == null)
			{
				SocialManager.SM = new SocialManager();
			}
			return SocialManager.SM;
		}
	}

	// Token: 0x0600286E RID: 10350 RVA: 0x00446D18 File Offset: 0x00444F18
	public bool CheckBonding(bool CheckFlag = true)
	{
		return (!CheckFlag || !DataManager.Instance.CheckPrizeFlag(30)) && IGGGameSDK.Instance.m_IGGLoginType == IGGLoginType.GUEST && !IGGGameSDK.Instance.bBindingGoogle;
	}

	// Token: 0x0600286F RID: 10351 RVA: 0x00446D68 File Offset: 0x00444F68
	public bool CheckFBMission()
	{
		return this.CheckShowPrize() || this.CheckShowMission();
	}

	// Token: 0x06002870 RID: 10352 RVA: 0x00446D80 File Offset: 0x00444F80
	public bool CheckSocialBind()
	{
		return (DataManager.FBMissionDataManager.GetRewardCount() > 0 && DataManager.FBMissionDataManager.GetRewardIndex() == 0 && DataManager.FBMissionDataManager.GetRewardSerial() == DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo) || (DataManager.Instance.RoleAttr.Inviter.Invited > 0 && !DataManager.Instance.CheckPrizeFlag(30));
	}

	// Token: 0x06002871 RID: 10353 RVA: 0x00446DFC File Offset: 0x00444FFC
	public bool CheckShowPrizeCount()
	{
		return DataManager.FBMissionDataManager.GetRewardCount() > 0 && (DataManager.Instance.RoleAttr.Inviter.Invited == 0 || DataManager.Instance.CheckPrizeFlag(30));
	}

	// Token: 0x06002872 RID: 10354 RVA: 0x00446E44 File Offset: 0x00445044
	public bool CheckShowPrize()
	{
		return DataManager.FBMissionDataManager.GetRewardCount() > 0 || (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 2 && DataManager.Instance.RoleAttr.Inviter.Invited > 0 && !DataManager.Instance.CheckPrizeFlag(30) && !DataManager.Instance.CheckPrizeFlag(27) && !DataManager.Instance.CheckPrizeFlag(29));
	}

	// Token: 0x06002873 RID: 10355 RVA: 0x00446ED4 File Offset: 0x004450D4
	public bool CheckShowMission()
	{
		return GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 4 && (DataManager.FBMissionDataManager.IsInTime() || !DataManager.Instance.CheckPrizeFlag(27) || !DataManager.Instance.CheckPrizeFlag(29));
	}

	// Token: 0x06002874 RID: 10356 RVA: 0x00446F38 File Offset: 0x00445138
	public bool CanShowInvite()
	{
		return GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 7 && DataManager.Instance.RoleAttr.Invitation > 0;
	}

	// Token: 0x06002875 RID: 10357 RVA: 0x00446F7C File Offset: 0x0044517C
	public byte GetFriendNumber()
	{
		return DataManager.FBMissionDataManager.CurrentFriendNum;
	}

	// Token: 0x06002876 RID: 10358 RVA: 0x00446F88 File Offset: 0x00445188
	public byte GetRecommandNumber()
	{
		return (this.FriendRecommended <= 10) ? this.FriendRecommended : 10;
	}

	// Token: 0x06002877 RID: 10359 RVA: 0x00446FA4 File Offset: 0x004451A4
	public void Recv_RESP_BINDING_PLATFORM(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Mission);
		byte b = MP.ReadByte(-1);
		if (b <= 0)
		{
			DataManager instance = DataManager.Instance;
			instance.RoleAttr.PrizeFlag = (instance.RoleAttr.PrizeFlag | 1073741824u);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 0, 0);
		}
	}

	// Token: 0x06002878 RID: 10360 RVA: 0x00447000 File Offset: 0x00445200
	public bool PostShare(SocialType Kind)
	{
		if (this.CanShowInvite() && this.ShareAddress != null)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.Append(this.ShareAddress);
			cstring.IntToFormat(DataManager.Instance.RoleAttr.UserId, 1, false);
			cstring.IntToFormat((long)Kind, 1, false);
			cstring.AppendFormat("{0}id={1}&kind={2}");
			return true;
		}
		return false;
	}

	// Token: 0x06002879 RID: 10361 RVA: 0x00447074 File Offset: 0x00445274
	public void BindingPlatform(byte Type, string Name, string Key)
	{
		GUIManager.Instance.ShowUILock(EUILock.Mission);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_BINDING_PLATFORM;
		messagePacket.AddSeqId();
		messagePacket.Add(Type);
		messagePacket.Add(Name, 41);
		messagePacket.Add(Key, 255);
		messagePacket.Send(false);
	}

	// Token: 0x0600287A RID: 10362 RVA: 0x004470D0 File Offset: 0x004452D0
	public void BindingPlatform(bool ShowMsg = true)
	{
		if (DataManager.Instance.RoleAttr.Inviter.Invited == 0 || DataManager.Instance.CheckPrizeFlag(30) || DataManager.Instance.CheckPrizeFlag(27) || DataManager.Instance.CheckPrizeFlag(29))
		{
			return;
		}
		GUIManager.Instance.ShowUILock(EUILock.Mission);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_BINDING_PLATFORM;
		messagePacket.AddSeqId();
		messagePacket.Add(this.BindingName, 41);
		messagePacket.Send(false);
	}

	// Token: 0x040072CE RID: 29390
	private const byte MAX_SOCIAL_FRIEND = 100;

	// Token: 0x040072CF RID: 29391
	private const int SOCIAL_BINDING_KEY_LEN = 255;

	// Token: 0x040072D0 RID: 29392
	public byte MaxConcurrentFriend;

	// Token: 0x040072D1 RID: 29393
	public byte FriendRecommended;

	// Token: 0x040072D2 RID: 29394
	public string ShareAddress = "http://download-lo-tw.igg.com/android/?";

	// Token: 0x040072D3 RID: 29395
	public SocialType Kind;

	// Token: 0x040072D4 RID: 29396
	public byte InviterLen;

	// Token: 0x040072D5 RID: 29397
	public long InviterIGGId;

	// Token: 0x040072D6 RID: 29398
	public ushort InviterHead;

	// Token: 0x040072D7 RID: 29399
	public string InviterName;

	// Token: 0x040072D8 RID: 29400
	public string BindingName = string.Empty;

	// Token: 0x040072D9 RID: 29401
	public string BindingKey;

	// Token: 0x040072DA RID: 29402
	public BondType BindingType;

	// Token: 0x040072DB RID: 29403
	public CString InviterTag;

	// Token: 0x040072DC RID: 29404
	public CString SocialName;

	// Token: 0x040072DD RID: 29405
	private static SocialManager SM;
}
