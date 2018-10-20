using System;

// Token: 0x020002F5 RID: 757
public class UIAlliance_Rally : GUIWindow
{
	// Token: 0x06000F75 RID: 3957 RVA: 0x001B3B90 File Offset: 0x001B1D90
	public override void OnOpen(int arg1, int arg2)
	{
		if (arg1 == 0 || arg1 == 100 || arg1 == 102)
		{
			this.RallyInst = new Rally_Attack(base.transform, arg2);
		}
		else if (arg1 == 101)
		{
			this.RallyInst = new Rally_WondersInfo(base.transform, arg2);
		}
		else
		{
			this.RallyInst = new Rally_Defense(base.transform, arg2);
		}
		this.RallyInst.OnOpen(arg1, arg2);
	}

	// Token: 0x06000F76 RID: 3958 RVA: 0x001B3C08 File Offset: 0x001B1E08
	public override void OnClose()
	{
		this.RallyInst.OnClose();
	}

	// Token: 0x06000F77 RID: 3959 RVA: 0x001B3C18 File Offset: 0x001B1E18
	public override void UpdateUI(int arg1, int arg2)
	{
		this.RallyInst.UpdateUI(arg1, arg2);
	}

	// Token: 0x06000F78 RID: 3960 RVA: 0x001B3C28 File Offset: 0x001B1E28
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.RallyInst.TextRefresh();
			}
		}
		else
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu_Alliance(this.m_eWindow);
		}
	}

	// Token: 0x06000F79 RID: 3961 RVA: 0x001B3C80 File Offset: 0x001B1E80
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (this.RallyInst != null)
		{
			this.RallyInst.OnOKCancelBoxClick(bOK, arg1, arg2);
		}
	}

	// Token: 0x06000F7A RID: 3962 RVA: 0x001B3C9C File Offset: 0x001B1E9C
	public override void UpdateTime(bool bOnSecond)
	{
		this.RallyInst.UpdateTime(bOnSecond);
	}

	// Token: 0x040032EE RID: 13038
	private Rally RallyInst;
}
