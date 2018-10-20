using System;

// Token: 0x02000683 RID: 1667
public class UITalentSave : UISaveList
{
	// Token: 0x06002002 RID: 8194 RVA: 0x003CDD28 File Offset: 0x003CBF28
	public override void OnOpen(int arg1, int arg2)
	{
		base.OnOpen(arg1, arg2);
		this.Titles[0].text = DataManager.Instance.mStringTable.GetStringByID(923u);
		this.UISaved = GUIManager.Instance.TalentSaveSaved;
		this.SaveScrollPanel.GoTo((int)this.UISaved[0], GameConstants.ConvertBytesToFloat(this.UISaved, 1));
	}

	// Token: 0x06002003 RID: 8195 RVA: 0x003CDD90 File Offset: 0x003CBF90
	public override void OnButtonClick(UIButton sender)
	{
		base.OnButtonClick(sender);
		UISaveList.ClickType btnID = (UISaveList.ClickType)sender.m_BtnID1;
		if (btnID != UISaveList.ClickType.Apply)
		{
			if (btnID == UISaveList.ClickType.Setup)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.OpenMenu(EGUIWindow.UI_Talent, sender.m_BtnID2, 0, false);
			}
		}
		else
		{
			GUIManager.Instance.UseOrSpend(1008, DataManager.Instance.mStringTable.GetStringByID(926u), 0, 1, (ushort)(sender.m_BtnID2 - 1), UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
		}
	}

	// Token: 0x06002004 RID: 8196 RVA: 0x003CDE20 File Offset: 0x003CC020
	public override short GetResearchIndex()
	{
		AttribValManager attribVal = DataManager.Instance.AttribVal;
		if (attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_QUICK_TALENT_SET) == 10u)
		{
			return -1;
		}
		return (short)attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_QUICK_TALENT_SET);
	}

	// Token: 0x06002005 RID: 8197 RVA: 0x003CDE54 File Offset: 0x003CC054
	public override byte GetItemNum()
	{
		AttribValManager attribVal = DataManager.Instance.AttribVal;
		if (attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_QUICK_TALENT_SET) == 10u)
		{
			return 10;
		}
		return (byte)(attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_QUICK_TALENT_SET) + 1u);
	}

	// Token: 0x06002006 RID: 8198 RVA: 0x003CDE8C File Offset: 0x003CC08C
	public override ushort GetResearchID()
	{
		return 117;
	}

	// Token: 0x06002007 RID: 8199 RVA: 0x003CDE90 File Offset: 0x003CC090
	public override void SetItemData(ref UISaveList.ItemEdit Data, int dataIdx)
	{
		base.SetItemData(ref Data, ++dataIdx);
		Data.Title.text = DataManager.Instance.SaveTalentData[dataIdx].GetTagName().ToString();
		Data.Title.SetAllDirty();
		Data.Title.cachedTextGenerator.Invalidate();
		if (DataManager.Instance.SaveTalentData[dataIdx].NoUseTalent == 1)
		{
			Data.SetaApplyEnable(false);
		}
		else
		{
			Data.SetaApplyEnable(true);
		}
	}

	// Token: 0x06002008 RID: 8200 RVA: 0x003CDF18 File Offset: 0x003CC118
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

	// Token: 0x06002009 RID: 8201 RVA: 0x003CDF58 File Offset: 0x003CC158
	public override void OnClose()
	{
		base.OnClose();
		this.UISaved[0] = (byte)this.SaveScrollPanel.GetBeginIdx();
		GameConstants.GetBytes(this.ScrollContentRect.anchoredPosition.y, this.UISaved, 1);
	}

	// Token: 0x04006520 RID: 25888
	private byte[] UISaved;
}
