using System;
using System.Runtime.InteropServices;

// Token: 0x020000C2 RID: 194
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PushNotificationData
{
	// Token: 0x04000901 RID: 2305
	[MarshalAs(UnmanagedType.U2)]
	public ushort PushNKey;

	// Token: 0x04000902 RID: 2306
	[MarshalAs(UnmanagedType.U2)]
	public ushort PushNStr;

	// Token: 0x04000903 RID: 2307
	[MarshalAs(UnmanagedType.U1)]
	public byte PushNType;

	// Token: 0x04000904 RID: 2308
	[MarshalAs(UnmanagedType.U2)]
	public ushort PushNswitch;

	// Token: 0x04000905 RID: 2309
	[MarshalAs(UnmanagedType.U2)]
	public ushort PushNValue1;

	// Token: 0x04000906 RID: 2310
	[MarshalAs(UnmanagedType.U2)]
	public ushort PushNValue2;
}
