using System;
using System.Runtime.InteropServices;

// Token: 0x020003B8 RID: 952
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LordEquipSerialData
{
	// Token: 0x0600139D RID: 5021 RVA: 0x0022E7EC File Offset: 0x0022C9EC
	public void Init()
	{
		this.ItemID = 0;
		this.DontUse = 0u;
		this.Color = 0;
		this.Gem = new ushort[4];
		this.GemColor = new byte[4];
		for (int i = 0; i < 4; i++)
		{
			this.GemColor[i] = 0;
			this.Gem[i] = 0;
		}
	}

	// Token: 0x0600139E RID: 5022 RVA: 0x0022E84C File Offset: 0x0022CA4C
	public void Clear()
	{
		this.ItemID = 0;
		this.DontUse = 0u;
		this.Color = 0;
		for (int i = 0; i < 4; i++)
		{
			this.GemColor[i] = 0;
			this.Gem[i] = 0;
		}
	}

	// Token: 0x04003C1A RID: 15386
	public ushort ItemID;

	// Token: 0x04003C1B RID: 15387
	public byte Color;

	// Token: 0x04003C1C RID: 15388
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] GemColor;

	// Token: 0x04003C1D RID: 15389
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public ushort[] Gem;

	// Token: 0x04003C1E RID: 15390
	public uint DontUse;
}
