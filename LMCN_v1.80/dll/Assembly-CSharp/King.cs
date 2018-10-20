using System;

// Token: 0x02000852 RID: 2130
public class King : _WhoReward
{
	// Token: 0x06002C0C RID: 11276 RVA: 0x00485DF0 File Offset: 0x00483FF0
	public King()
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.TitleStr = mStringTable.GetStringByID(9709u);
		this.MainStr = mStringTable.GetStringByID(9710u);
		if (DataManager.MapDataController.IsKing() && DataManager.MapDataController.IsInMyAllianceKingdom(false))
		{
			this.IsKing = true;
		}
	}

	// Token: 0x06002C0D RID: 11277 RVA: 0x00485E58 File Offset: 0x00484058
	public override bool CheckReward()
	{
		return DataManager.MapDataController.CheckKingFunction(eKingFunction.eReward);
	}

	// Token: 0x06002C0E RID: 11278 RVA: 0x00485E68 File Offset: 0x00484068
	public override bool CheckAndOpenList(int ID)
	{
		if (DataManager.MapDataController.IsPeaceState(true, 0))
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 7, ID, false);
		}
		return false;
	}
}
