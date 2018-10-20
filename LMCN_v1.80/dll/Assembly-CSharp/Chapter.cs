using System;
using System.Runtime.InteropServices;

// Token: 0x020004B1 RID: 1201
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Chapter
{
	// Token: 0x04004779 RID: 18297
	[MarshalAs(UnmanagedType.U2)]
	public ushort ChapterKey;

	// Token: 0x0400477A RID: 18298
	[MarshalAs(UnmanagedType.U2)]
	public ushort ChapterName;

	// Token: 0x0400477B RID: 18299
	[MarshalAs(UnmanagedType.U1)]
	public byte MapID;

	// Token: 0x0400477C RID: 18300
	[MarshalAs(UnmanagedType.U1)]
	public byte NeedLV;

	// Token: 0x0400477D RID: 18301
	[MarshalAs(UnmanagedType.U1)]
	public byte Power;

	// Token: 0x0400477E RID: 18302
	[MarshalAs(UnmanagedType.U2)]
	public ushort OpenTipsID;

	// Token: 0x0400477F RID: 18303
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public WordVector3[] BigPointPos;

	// Token: 0x04004780 RID: 18304
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	public WordVector3[] PointPos;

	// Token: 0x04004781 RID: 18305
	[MarshalAs(UnmanagedType.Struct)]
	public WordVector3 CameraPos;

	// Token: 0x04004782 RID: 18306
	[MarshalAs(UnmanagedType.Struct)]
	public WordVector3 CameraRot;

	// Token: 0x04004783 RID: 18307
	[MarshalAs(UnmanagedType.U2)]
	public ushort HeroID;

	// Token: 0x04004784 RID: 18308
	[MarshalAs(UnmanagedType.U2)]
	public ushort Hero_ItemID;

	// Token: 0x04004785 RID: 18309
	[MarshalAs(UnmanagedType.U1)]
	public byte Hero_ItemNum;

	// Token: 0x04004786 RID: 18310
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public Stage_ItemData[] Items;
}
