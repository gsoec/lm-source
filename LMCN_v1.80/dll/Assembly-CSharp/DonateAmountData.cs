using System;
using System.Runtime.InteropServices;

// Token: 0x020000C4 RID: 196
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct DonateAmountData
{
	// Token: 0x04000909 RID: 2313
	[MarshalAs(UnmanagedType.U2)]
	public ushort DonateAmountID;

	// Token: 0x0400090A RID: 2314
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 380)]
	public ushort[] DonateAmount;
}
