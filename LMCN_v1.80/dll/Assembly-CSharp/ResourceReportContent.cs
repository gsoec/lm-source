using System;
using System.Runtime.InteropServices;

// Token: 0x020000EE RID: 238
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class ResourceReportContent : MailReportHead
{
	// Token: 0x04000ABD RID: 2749
	public byte Result;

	// Token: 0x04000ABE RID: 2750
	public uint[] Resource;

	// Token: 0x04000ABF RID: 2751
	public string Name;
}
