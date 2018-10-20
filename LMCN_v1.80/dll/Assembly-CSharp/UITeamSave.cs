using System;
using UnityEngine;

// Token: 0x02000684 RID: 1668
public class UITeamSave : UISaveList
{
	// Token: 0x0600200B RID: 8203 RVA: 0x003CDFA8 File Offset: 0x003CC1A8
	public override void OnOpen(int arg1, int arg2)
	{
		RectTransform component = base.transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<RectTransform>();
		RectTransform component2 = base.transform.GetChild(2).GetChild(0).GetChild(2).GetComponent<RectTransform>();
		component.gameObject.SetActive(false);
		component2.anchoredPosition = new Vector2(640f, component.anchoredPosition.y);
		component2.sizeDelta = component.sizeDelta;
		this.DefaultTeamName = new CString[DataManager.Instance.mTroopMemoryData.Length];
		for (int i = 0; i < this.DefaultTeamName.Length; i++)
		{
			this.DefaultTeamName[i] = StringManager.Instance.SpawnString(30);
		}
		base.OnOpen(arg1, arg2);
		this.Titles[0].text = DataManager.Instance.mStringTable.GetStringByID(990u);
	}

	// Token: 0x0600200C RID: 8204 RVA: 0x003CE094 File Offset: 0x003CC294
	public override void OnButtonClick(UIButton sender)
	{
		base.OnButtonClick(sender);
		UISaveList.ClickType btnID = (UISaveList.ClickType)sender.m_BtnID1;
		if (btnID == UISaveList.ClickType.Setup)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_Expedition, sender.m_BtnID2, 6, false);
		}
	}

	// Token: 0x0600200D RID: 8205 RVA: 0x003CE0E4 File Offset: 0x003CC2E4
	public override short GetResearchIndex()
	{
		DataManager instance = DataManager.Instance;
		byte techLevel = instance.GetTechLevel(this.GetResearchID());
		if (techLevel == 5)
		{
			return -1;
		}
		return (short)techLevel;
	}

	// Token: 0x0600200E RID: 8206 RVA: 0x003CE110 File Offset: 0x003CC310
	public override byte GetItemNum()
	{
		DataManager instance = DataManager.Instance;
		byte techLevel = instance.GetTechLevel(this.GetResearchID());
		if (techLevel == 5)
		{
			return 5;
		}
		return techLevel + 1;
	}

	// Token: 0x0600200F RID: 8207 RVA: 0x003CE140 File Offset: 0x003CC340
	public override ushort GetResearchID()
	{
		return 120;
	}

	// Token: 0x06002010 RID: 8208 RVA: 0x003CE144 File Offset: 0x003CC344
	public override void SetItemData(ref UISaveList.ItemEdit Data, int dataIdx)
	{
		base.SetItemData(ref Data, dataIdx);
		DataManager instance = DataManager.Instance;
		if (instance.mTroopMemoryData[dataIdx].Label == null || instance.mTroopMemoryData[dataIdx].Label == string.Empty)
		{
			this.DefaultTeamName[dataIdx].ClearString();
			this.DefaultTeamName[dataIdx].IntToFormat((long)(dataIdx + 1), 1, false);
			this.DefaultTeamName[dataIdx].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(993u));
			Data.Title.text = this.DefaultTeamName[dataIdx].ToString();
			Data.Title.SetAllDirty();
			Data.Title.cachedTextGenerator.Invalidate();
		}
		else
		{
			Data.Title.text = DataManager.Instance.mTroopMemoryData[dataIdx].Label;
		}
	}

	// Token: 0x06002011 RID: 8209 RVA: 0x003CE230 File Offset: 0x003CC430
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			base.UpdateSaveList();
		}
		else if (arg1 == -1)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu(false);
		}
	}

	// Token: 0x06002012 RID: 8210 RVA: 0x003CE270 File Offset: 0x003CC470
	public override void OnClose()
	{
		for (int i = 0; i < this.DefaultTeamName.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.DefaultTeamName[i]);
		}
		base.OnClose();
	}

	// Token: 0x04006521 RID: 25889
	private CString[] DefaultTeamName;
}
