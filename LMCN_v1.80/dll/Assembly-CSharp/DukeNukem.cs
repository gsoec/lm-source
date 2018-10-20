using System;

// Token: 0x020006C4 RID: 1732
public static class DukeNukem
{
	// Token: 0x06002140 RID: 8512 RVA: 0x003F4E14 File Offset: 0x003F3014
	public static void FederalOrderKingdom(MessagePacket MP)
	{
		DukeNukem.Result = MP.ReadByte(-1);
		DukeNukem.Wonder = MP.ReadByte(-1);
		DukeNukem.Dukedom = MP.ReadByte(-1);
		DukeNukem.Kid = new ushort[(int)DukeNukem.Dukedom];
		for (int i = 0; i < (int)DukeNukem.Dukedom; i++)
		{
			DukeNukem.Kid[i] = MP.ReadUShort(-1);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, 0, 0);
	}

	// Token: 0x04006903 RID: 26883
	public static byte Result;

	// Token: 0x04006904 RID: 26884
	public static byte Wonder;

	// Token: 0x04006905 RID: 26885
	public static byte Dukedom;

	// Token: 0x04006906 RID: 26886
	public static ushort[] Kid;
}
