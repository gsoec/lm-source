using System;

// Token: 0x020003D1 RID: 977
public class SocialFriend : FBMissionManager.FbMissionProgress
{
	// Token: 0x06001460 RID: 5216 RVA: 0x0023A358 File Offset: 0x00238558
	public SocialFriend()
	{
		this.SocialName = new CString(42);
		this.Name = new CString(14);
		this.AllianceTag = new CString(4);
	}

	// Token: 0x06001461 RID: 5217 RVA: 0x0023A394 File Offset: 0x00238594
	public void Clear()
	{
		this.IconNo = 0;
		this.Head = 0;
		this.SocialName.ClearString();
		this.Name.ClearString();
		this.AllianceTag.ClearString();
		this.NodeIndex = 0;
		this.bShowHUD = 0;
		this.MissionTime.BeginTime = 0L;
	}

	// Token: 0x04003CFE RID: 15614
	public CString SocialName;

	// Token: 0x04003CFF RID: 15615
	public byte Invited;

	// Token: 0x04003D00 RID: 15616
	public byte IconNo;

	// Token: 0x04003D01 RID: 15617
	public byte Result;

	// Token: 0x04003D02 RID: 15618
	public ushort Head;

	// Token: 0x04003D03 RID: 15619
	public bool TimeRemain;

	// Token: 0x04003D04 RID: 15620
	public CString Name;

	// Token: 0x04003D05 RID: 15621
	public CString AllianceTag;
}
