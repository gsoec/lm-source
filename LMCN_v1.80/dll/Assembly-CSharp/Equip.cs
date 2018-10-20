using System;
using System.Runtime.InteropServices;

// Token: 0x02000080 RID: 128
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Equip
{
	// Token: 0x04000733 RID: 1843
	[MarshalAs(UnmanagedType.U2)]
	public ushort EquipKey;

	// Token: 0x04000734 RID: 1844
	[MarshalAs(UnmanagedType.U2)]
	public ushort EquipName;

	// Token: 0x04000735 RID: 1845
	[MarshalAs(UnmanagedType.U1)]
	public byte Color;

	// Token: 0x04000736 RID: 1846
	[MarshalAs(UnmanagedType.U1)]
	public byte NeedLv;

	// Token: 0x04000737 RID: 1847
	[MarshalAs(UnmanagedType.U2)]
	public ushort EquipInfo;

	// Token: 0x04000738 RID: 1848
	[MarshalAs(UnmanagedType.U2)]
	public ushort EquipPicture;

	// Token: 0x04000739 RID: 1849
	[MarshalAs(UnmanagedType.U4)]
	public uint RecoverPrice;

	// Token: 0x0400073A RID: 1850
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public Properties[] PropertiesInfo;

	// Token: 0x0400073B RID: 1851
	[MarshalAs(UnmanagedType.U1)]
	public byte EquipKind;

	// Token: 0x0400073C RID: 1852
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public Synthetic[] SyntheticParts;

	// Token: 0x0400073D RID: 1853
	[MarshalAs(UnmanagedType.U4)]
	public uint MixPrice;

	// Token: 0x0400073E RID: 1854
	[MarshalAs(UnmanagedType.U4)]
	public uint MixTime;

	// Token: 0x0400073F RID: 1855
	[MarshalAs(UnmanagedType.U4)]
	public uint ForgingExp;

	// Token: 0x04000740 RID: 1856
	[MarshalAs(UnmanagedType.U1)]
	public byte Hide;

	// Token: 0x04000741 RID: 1857
	[MarshalAs(UnmanagedType.U1)]
	public byte ActivitySuitIndex;

	// Token: 0x04000742 RID: 1858
	[MarshalAs(UnmanagedType.U4)]
	public uint TimedTime;

	// Token: 0x04000743 RID: 1859
	[MarshalAs(UnmanagedType.U1)]
	public byte TimedType;

	// Token: 0x04000744 RID: 1860
	[MarshalAs(UnmanagedType.U1)]
	public byte NewGem;

	// Token: 0x04000745 RID: 1861
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public ushort[] NewGemEffect;

	// Token: 0x04000746 RID: 1862
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] Reserve;
}
