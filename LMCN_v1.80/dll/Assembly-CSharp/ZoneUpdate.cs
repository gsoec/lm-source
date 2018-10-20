using System;
using System.Runtime.InteropServices;

// Token: 0x0200022F RID: 559
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ZoneUpdate
{
	// Token: 0x04002250 RID: 8784
	public ulong updateNum;

	// Token: 0x04002251 RID: 8785
	public byte zoneState;
}
