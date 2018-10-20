using System;
using System.Runtime.InteropServices;

// Token: 0x0200023C RID: 572
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct EmojiData
{
	// Token: 0x040022A5 RID: 8869
	[MarshalAs(UnmanagedType.U2)]
	public ushort EmojiKey;

	// Token: 0x040022A6 RID: 8870
	[MarshalAs(UnmanagedType.U2)]
	public ushort GroupIconID;

	// Token: 0x040022A7 RID: 8871
	[MarshalAs(UnmanagedType.U2)]
	public ushort IconID;

	// Token: 0x040022A8 RID: 8872
	[MarshalAs(UnmanagedType.U2)]
	public ushort SoundID;

	// Token: 0x040022A9 RID: 8873
	[MarshalAs(UnmanagedType.U2)]
	public ushort sizeX;

	// Token: 0x040022AA RID: 8874
	[MarshalAs(UnmanagedType.U2)]
	public ushort sizeY;

	// Token: 0x040022AB RID: 8875
	[MarshalAs(UnmanagedType.U2)]
	public ushort Xoffset;

	// Token: 0x040022AC RID: 8876
	[MarshalAs(UnmanagedType.U2)]
	public ushort Yoffset;

	// Token: 0x040022AD RID: 8877
	[MarshalAs(UnmanagedType.U1)]
	public byte KeyFrame;

	// Token: 0x040022AE RID: 8878
	[MarshalAs(UnmanagedType.U2)]
	public ushort MapTime;

	// Token: 0x040022AF RID: 8879
	[MarshalAs(UnmanagedType.U4)]
	public uint UseTime;

	// Token: 0x040022B0 RID: 8880
	[MarshalAs(UnmanagedType.U1)]
	public byte EmojiType;

	// Token: 0x040022B1 RID: 8881
	[MarshalAs(UnmanagedType.U2)]
	public ushort EmotionOne;

	// Token: 0x040022B2 RID: 8882
	[MarshalAs(UnmanagedType.U2)]
	public ushort EmotionTwo;

	// Token: 0x040022B3 RID: 8883
	[MarshalAs(UnmanagedType.U2)]
	public ushort EmotionThree;

	// Token: 0x040022B4 RID: 8884
	[MarshalAs(UnmanagedType.U2)]
	public ushort EmotionFour;
}
