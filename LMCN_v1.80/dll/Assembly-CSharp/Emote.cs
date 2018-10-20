using System;
using System.Runtime.InteropServices;

// Token: 0x0200023D RID: 573
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Emote
{
	// Token: 0x040022B5 RID: 8885
	[MarshalAs(UnmanagedType.U2)]
	public ushort EmojiIndex;

	// Token: 0x040022B6 RID: 8886
	[MarshalAs(UnmanagedType.U1)]
	public byte SelectionPicNo;

	// Token: 0x040022B7 RID: 8887
	[MarshalAs(UnmanagedType.U2)]
	public ushort Weight;

	// Token: 0x040022B8 RID: 8888
	[MarshalAs(UnmanagedType.U4)]
	public uint ProductID;

	// Token: 0x040022B9 RID: 8889
	[MarshalAs(UnmanagedType.U2)]
	public ushort GiftID;

	// Token: 0x040022BA RID: 8890
	[MarshalAs(UnmanagedType.U1)]
	public byte GiftCount;

	// Token: 0x040022BB RID: 8891
	[MarshalAs(UnmanagedType.U1)]
	public byte TabScale;

	// Token: 0x040022BC RID: 8892
	[MarshalAs(UnmanagedType.U1)]
	public byte FirstShow;

	// Token: 0x040022BD RID: 8893
	[MarshalAs(UnmanagedType.U2)]
	public ushort EmotionTwo;

	// Token: 0x040022BE RID: 8894
	[MarshalAs(UnmanagedType.U2)]
	public ushort EmotionThree;

	// Token: 0x040022BF RID: 8895
	[MarshalAs(UnmanagedType.U2)]
	public ushort EmotionFour;

	// Token: 0x040022C0 RID: 8896
	[MarshalAs(UnmanagedType.U2)]
	public ushort EmotionFive;
}
