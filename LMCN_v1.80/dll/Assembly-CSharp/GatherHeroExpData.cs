using System;
using System.Runtime.InteropServices;

// Token: 0x020000F7 RID: 247
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class GatherHeroExpData
{
	// Token: 0x04000B0D RID: 2829
	public ushort HeroID;

	// Token: 0x04000B0E RID: 2830
	public byte Star;

	// Token: 0x04000B0F RID: 2831
	public uint Exp;
}
