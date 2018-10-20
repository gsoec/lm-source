using System;
using System.Runtime.InteropServices;

// Token: 0x02000237 RID: 567
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct KingdomInfo
{
	// Token: 0x04002282 RID: 8834
	public ushort kingdomID;

	// Token: 0x04002283 RID: 8835
	public byte kingdomFlag;

	// Token: 0x04002284 RID: 8836
	public KINGDOM_PERIOD kingdomPeriod;

	// Token: 0x04002285 RID: 8837
	public ushort kingKingdomID;

	// Token: 0x04002286 RID: 8838
	public CString kingName;

	// Token: 0x04002287 RID: 8839
	public ushort allianceKingdomID;

	// Token: 0x04002288 RID: 8840
	public CString allianceTag;

	// Token: 0x04002289 RID: 8841
	public CString allianceName;

	// Token: 0x0400228A RID: 8842
	public CString kingdomName;

	// Token: 0x0400228B RID: 8843
	public ulong kingdomTime;
}
