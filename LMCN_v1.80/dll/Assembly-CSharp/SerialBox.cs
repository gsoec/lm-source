using System;
using System.Runtime.InteropServices;

// Token: 0x020000DF RID: 223
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class SerialBox
{
	// Token: 0x060002DA RID: 730 RVA: 0x00027970 File Offset: 0x00025B70
	public SerialBox()
	{
	}

	// Token: 0x060002DB RID: 731 RVA: 0x00027978 File Offset: 0x00025B78
	public SerialBox(uint serial, byte flag, bool read, bool save, bool pull = true, bool keep = true)
	{
		this.Serial = serial;
		this.Read = read;
		this.Keep = keep;
		this.Save = save;
		this.Flag = flag;
		this.Pull = pull;
	}

	// Token: 0x040009F8 RID: 2552
	public uint Serial;

	// Token: 0x040009F9 RID: 2553
	public bool Read;

	// Token: 0x040009FA RID: 2554
	public bool Save;

	// Token: 0x040009FB RID: 2555
	public byte Flag;

	// Token: 0x040009FC RID: 2556
	public byte Type;

	// Token: 0x040009FD RID: 2557
	public bool Pull;

	// Token: 0x040009FE RID: 2558
	public bool Keep;

	// Token: 0x040009FF RID: 2559
	public CombatCollectReport Sub;
}
