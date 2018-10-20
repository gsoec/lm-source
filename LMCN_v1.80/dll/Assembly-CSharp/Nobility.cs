using System;

// Token: 0x02000854 RID: 2132
public class Nobility : _WhoReward
{
	// Token: 0x06002C12 RID: 11282 RVA: 0x00485F4C File Offset: 0x0048414C
	public Nobility()
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.TitleStr = mStringTable.GetStringByID(11084u);
		this.MainStr = mStringTable.GetStringByID(11060u);
	}

	// Token: 0x06002C13 RID: 11283 RVA: 0x00485F8C File Offset: 0x0048418C
	public override bool CheckReward()
	{
		return DataManager.MapDataController.CheckNobilityFunction(eNobilityFunction.eReward, DataManager.Instance.KingGift.WonderID);
	}

	// Token: 0x06002C14 RID: 11284 RVA: 0x00485FA8 File Offset: 0x004841A8
	public override bool CheckAndOpenList(int ID)
	{
		if (DataManager.MapDataController.IsPeaceState(true, DataManager.Instance.KingGift.WonderID))
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 9, ID, false);
			return true;
		}
		return false;
	}
}
