using System;

// Token: 0x02000853 RID: 2131
public class WorldKing : _WhoReward
{
	// Token: 0x06002C0F RID: 11279 RVA: 0x00485EA4 File Offset: 0x004840A4
	public WorldKing()
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.TitleStr = mStringTable.GetStringByID(9798u);
		this.MainStr = mStringTable.GetStringByID(9797u);
		if (DataManager.MapDataController.IsWorldKing())
		{
			this.IsKing = true;
		}
	}

	// Token: 0x06002C10 RID: 11280 RVA: 0x00485EFC File Offset: 0x004840FC
	public override bool CheckReward()
	{
		return DataManager.MapDataController.CheckWorldKingFunction(eWorldKingFunction.eReward);
	}

	// Token: 0x06002C11 RID: 11281 RVA: 0x00485F0C File Offset: 0x0048410C
	public override bool CheckAndOpenList(int ID)
	{
		if (DataManager.MapDataController.IsPeaceState(true, 0))
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 8, ID, false);
			return true;
		}
		return false;
	}
}
