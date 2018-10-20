using System;
using System.Runtime.InteropServices;

// Token: 0x0200007B RID: 123
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AI
{
	// Token: 0x0400071B RID: 1819
	[MarshalAs(UnmanagedType.U2)]
	public ushort AIKey;

	// Token: 0x0400071C RID: 1820
	[MarshalAs(UnmanagedType.U1)]
	public byte Search;

	// Token: 0x0400071D RID: 1821
	[MarshalAs(UnmanagedType.U1)]
	public byte ChangTime;

	// Token: 0x0400071E RID: 1822
	[MarshalAs(UnmanagedType.U1)]
	public byte GoodSkillSearch;
}
