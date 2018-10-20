using System;
using System.Runtime.InteropServices;

// Token: 0x02000140 RID: 320
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class BlackListDataType
{
	// Token: 0x0600033A RID: 826 RVA: 0x00028730 File Offset: 0x00026930
	public BlackListDataType()
	{
		this.PlayerName = new CString(18);
	}

	// Token: 0x04000D04 RID: 3332
	public ushort PlayerPicID;

	// Token: 0x04000D05 RID: 3333
	public CString PlayerName;
}
