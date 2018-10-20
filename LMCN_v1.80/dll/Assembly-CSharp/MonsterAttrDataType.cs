using System;
using System.Runtime.InteropServices;

// Token: 0x020000CE RID: 206
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MonsterAttrDataType
{
	// Token: 0x04000940 RID: 2368
	public byte ActionTimes;

	// Token: 0x04000941 RID: 2369
	public uint SequentialDamageScale;

	// Token: 0x04000942 RID: 2370
	public uint DamageScale;

	// Token: 0x04000943 RID: 2371
	public uint MaxHPScale;

	// Token: 0x04000944 RID: 2372
	public uint HealingScale;

	// Token: 0x04000945 RID: 2373
	public ushort InitMP;
}
