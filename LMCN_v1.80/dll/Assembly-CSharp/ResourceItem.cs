using System;
using System.Runtime.InteropServices;

// Token: 0x020000F9 RID: 249
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class ResourceItem
{
	// Token: 0x04000B12 RID: 2834
	public ushort ItemID;

	// Token: 0x04000B13 RID: 2835
	public ushort Quantity;

	// Token: 0x04000B14 RID: 2836
	public byte Rank;
}
