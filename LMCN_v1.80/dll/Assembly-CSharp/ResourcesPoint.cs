using System;
using System.Runtime.InteropServices;

// Token: 0x02000232 RID: 562
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ResourcesPoint
{
	// Token: 0x0400226B RID: 8811
	public ulong time;

	// Token: 0x0400226C RID: 8812
	public uint count;

	// Token: 0x0400226D RID: 8813
	public float rate;

	// Token: 0x0400226E RID: 8814
	public ushort kingdomID;

	// Token: 0x0400226F RID: 8815
	public byte level;

	// Token: 0x04002270 RID: 8816
	public CString allianceTag;

	// Token: 0x04002271 RID: 8817
	public CString playerName;

	// Token: 0x04002272 RID: 8818
	public byte baseFlag;

	// Token: 0x04002273 RID: 8819
	public ushort emojiID;
}
