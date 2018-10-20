using System;
using System.Runtime.InteropServices;

// Token: 0x020004B3 RID: 1203
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CorpsStage
{
	// Token: 0x0400478A RID: 18314
	[MarshalAs(UnmanagedType.U2)]
	public ushort CorpsStageKey;

	// Token: 0x0400478B RID: 18315
	[MarshalAs(UnmanagedType.U2)]
	public ushort StageName;

	// Token: 0x0400478C RID: 18316
	[MarshalAs(UnmanagedType.U2)]
	public ushort StageForeword;

	// Token: 0x0400478D RID: 18317
	[MarshalAs(UnmanagedType.U2)]
	public ushort StageEndword;

	// Token: 0x0400478E RID: 18318
	[MarshalAs(UnmanagedType.Struct)]
	public WordVector3 StagePos;

	// Token: 0x0400478F RID: 18319
	[MarshalAs(UnmanagedType.Struct)]
	public WordVector3 CastlePos;

	// Token: 0x04004790 RID: 18320
	[MarshalAs(UnmanagedType.U2)]
	public ushort CastleRotY;

	// Token: 0x04004791 RID: 18321
	[MarshalAs(UnmanagedType.U2)]
	public ushort CastleScale;

	// Token: 0x04004792 RID: 18322
	[MarshalAs(UnmanagedType.Struct)]
	public WordVector3 LordPos;

	// Token: 0x04004793 RID: 18323
	[MarshalAs(UnmanagedType.U2)]
	public ushort LordScale;

	// Token: 0x04004794 RID: 18324
	[MarshalAs(UnmanagedType.U2)]
	public ushort LordTile;

	// Token: 0x04004795 RID: 18325
	[MarshalAs(UnmanagedType.U2)]
	public ushort LordName;

	// Token: 0x04004796 RID: 18326
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public CorpsHeroAttribute[] Heros;

	// Token: 0x04004797 RID: 18327
	[MarshalAs(UnmanagedType.U2)]
	public ushort BattleForeword;

	// Token: 0x04004798 RID: 18328
	[MarshalAs(UnmanagedType.U2)]
	public ushort BattleEndword;

	// Token: 0x04004799 RID: 18329
	[MarshalAs(UnmanagedType.U2)]
	public ushort Info;

	// Token: 0x0400479A RID: 18330
	[MarshalAs(UnmanagedType.U2)]
	public ushort HeroExp;

	// Token: 0x0400479B RID: 18331
	[MarshalAs(UnmanagedType.U2)]
	public ushort LeadExp;
}
