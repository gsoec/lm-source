using System;

// Token: 0x0200064C RID: 1612
public class UIResourceBuilding : GUIWindow
{
	// Token: 0x06001F1F RID: 7967 RVA: 0x003BB328 File Offset: 0x003B9528
	private void Start()
	{
	}

	// Token: 0x06001F20 RID: 7968 RVA: 0x003BB32C File Offset: 0x003B952C
	public override void OnOpen(int arg1, int arg2)
	{
		int num = GUIManager.Instance.BuildingData.AllBuildsData.Length;
		if (arg1 < num && arg1 >= 0)
		{
			ushort num2 = (ushort)arg2;
			byte level = GUIManager.Instance.BuildingData.AllBuildsData[arg1].Level;
			this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
			this.baseBuild.InitBuildingWindow((byte)num2, (ushort)arg1, 1, level);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001F21 RID: 7969 RVA: 0x003BB3AC File Offset: 0x003B95AC
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
	}

	// Token: 0x06001F22 RID: 7970 RVA: 0x003BB3CC File Offset: 0x003B95CC
	public override void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x06001F23 RID: 7971 RVA: 0x003BB3D0 File Offset: 0x003B95D0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_BuildBase)
			{
				if (networkNews != NetworkNews.Refresh_AttribEffectVal)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						this.baseBuild.Refresh_FontTexture();
					}
				}
				else
				{
					this.baseBuild.MyUpdate(0, false);
				}
			}
			else
			{
				this.baseBuild.MyUpdate(meg[1], false);
			}
		}
		else
		{
			this.baseBuild.MyUpdate(0, false);
		}
	}

	// Token: 0x06001F24 RID: 7972 RVA: 0x003BB450 File Offset: 0x003B9650
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
	}

	// Token: 0x040062C0 RID: 25280
	private BuildingWindow baseBuild;
}
