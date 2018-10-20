using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200062D RID: 1581
public class UIMarket : GUIWindow, IBuildingWindowType, IUIButtonClickHandler
{
	// Token: 0x06001E85 RID: 7813 RVA: 0x003A5B80 File Offset: 0x003A3D80
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		StringManager instance3 = StringManager.Instance;
		Font ttffont = instance2.GetTTFFont();
		this.m_transform = base.transform;
		this.MiddleStr1 = instance3.SpawnString(30);
		this.MiddleStr2 = instance3.SpawnString(30);
		this.NormalPanel = this.m_transform.GetChild(0);
		this.NormalPanel.GetChild(2).GetComponent<UIButton>().m_Handler = this;
		this.RBText[0] = this.NormalPanel.GetChild(2).GetChild(1).GetComponent<UIText>();
		this.RBText[0].font = ttffont;
		this.RBText[0].text = instance.mStringTable.GetStringByID(3948u);
		this.BuildIndex = arg1;
		byte level = instance2.BuildingData.AllBuildsData[this.BuildIndex].Level;
		this.MiddleText1 = this.NormalPanel.GetChild(3).GetComponent<UIText>();
		this.MiddleText1.font = ttffont;
		this.MiddleText2 = this.NormalPanel.GetChild(4).GetComponent<UIText>();
		this.MiddleText2.font = ttffont;
		this.OpenRefresh();
		this.RBText[1] = this.NormalPanel.GetChild(5).GetComponent<UIText>();
		this.RBText[1].font = ttffont;
		this.RBText[1].text = instance.mStringTable.GetStringByID(5784u);
		this.HasAllyGO[0] = this.NormalPanel.GetChild(2).gameObject;
		this.HasAllyGO[1] = this.NormalPanel.GetChild(2).GetChild(0).gameObject;
		this.HasAllyGO[2] = this.NormalPanel.GetChild(2).GetChild(1).gameObject;
		this.NoAllyGO[0] = this.NormalPanel.GetChild(1).gameObject;
		this.NoAllyGO[1] = this.NormalPanel.GetChild(5).gameObject;
		this.baseBuild = this.m_transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		this.baseBuild.InitBuildingWindow(17, (ushort)arg1, 1, level);
		this.baseBuild.baseTransform.SetAsFirstSibling();
		instance2.UpdateUI(EGUIWindow.Door, 1, 2);
		this.CheckHasAlly();
	}

	// Token: 0x06001E86 RID: 7814 RVA: 0x003A5DD4 File Offset: 0x003A3FD4
	public void OpenRefresh()
	{
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		byte level = instance2.BuildingData.AllBuildsData[this.BuildIndex].Level;
		BuildLevelRequest buildLevelRequestData = instance2.BuildingData.GetBuildLevelRequestData(17, level);
		this.MiddleStr1.Length = 0;
		float f = 0f;
		uint effectBaseVal = instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_TRADE_TAX_REDUCTION);
		if (buildLevelRequestData.Value2 >= effectBaseVal)
		{
			f = (buildLevelRequestData.Value2 - effectBaseVal) / 100f;
		}
		this.MiddleStr1.FloatToFormat(f, 1, false);
		this.MiddleStr1.AppendFormat(instance.mStringTable.GetStringByID(3949u));
		this.MiddleText1.text = this.MiddleStr1.ToString();
		this.MiddleText1.SetAllDirty();
		this.MiddleText1.cachedTextGenerator.Invalidate();
		uint effectBaseVal2 = instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_TRADE_CAPACITY);
		uint effectBaseVal3 = instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_TRADE_CAPACITY_PERCENT);
		this.MiddleStr2.Length = 0;
		this.MiddleStr2.IntToFormat((long)(effectBaseVal2 * ((10000u + effectBaseVal3) / 10000.0)), 1, true);
		this.MiddleStr2.AppendFormat(instance.mStringTable.GetStringByID(3950u));
		this.MiddleText2.text = this.MiddleStr2.ToString();
		this.MiddleText2.SetAllDirty();
		this.MiddleText2.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001E87 RID: 7815 RVA: 0x003A5F5C File Offset: 0x003A415C
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		if (this.MiddleStr1 != null)
		{
			StringManager.Instance.DeSpawnString(this.MiddleStr1);
		}
		if (this.MiddleStr2 != null)
		{
			StringManager.Instance.DeSpawnString(this.MiddleStr2);
		}
	}

	// Token: 0x06001E88 RID: 7816 RVA: 0x003A5FC0 File Offset: 0x003A41C0
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing)
		{
			this.NormalPanel.gameObject.SetActive(true);
		}
		else
		{
			this.NormalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001E89 RID: 7817 RVA: 0x003A6004 File Offset: 0x003A4204
	public void CheckHasAlly()
	{
		bool flag = DataManager.Instance.RoleAlliance.Id != 0u;
		for (int i = 0; i < this.HasAllyGO.Length; i++)
		{
			this.HasAllyGO[i].SetActive(flag);
		}
		for (int j = 0; j < this.NoAllyGO.Length; j++)
		{
			this.NoAllyGO[j].SetActive(!flag);
		}
	}

	// Token: 0x06001E8A RID: 7818 RVA: 0x003A6078 File Offset: 0x003A4278
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_BuildBase:
		case NetworkNews.Refresh_Technology:
			this.baseBuild.MyUpdate(meg[1], false);
			this.OpenRefresh();
			break;
		default:
			if (networkNews != NetworkNews.Login)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.baseBuild.Refresh_FontTexture();
					if (this.MiddleText1 != null && this.MiddleText1.enabled)
					{
						this.MiddleText1.enabled = false;
						this.MiddleText1.enabled = true;
					}
					if (this.MiddleText2 != null && this.MiddleText2.enabled)
					{
						this.MiddleText2.enabled = false;
						this.MiddleText2.enabled = true;
					}
					for (int i = 0; i < this.RBText.Length; i++)
					{
						if (this.RBText[i] != null && this.RBText[i].enabled)
						{
							this.RBText[i].enabled = false;
							this.RBText[i].enabled = true;
						}
					}
				}
			}
			else
			{
				this.baseBuild.MyUpdate(0, false);
				this.OpenRefresh();
			}
			break;
		}
	}

	// Token: 0x06001E8B RID: 7819 RVA: 0x003A61C0 File Offset: 0x003A43C0
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.OpenRefresh();
		}
	}

	// Token: 0x06001E8C RID: 7820 RVA: 0x003A61D0 File Offset: 0x003A43D0
	public void OnButtonClick(UIButton sender)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		door.OpenMenu(EGUIWindow.UI_Alliance_List, 4, 0, false);
	}

	// Token: 0x04006095 RID: 24725
	private Transform m_transform;

	// Token: 0x04006096 RID: 24726
	private Transform NormalPanel;

	// Token: 0x04006097 RID: 24727
	private BuildingWindow baseBuild;

	// Token: 0x04006098 RID: 24728
	private UIText MiddleText1;

	// Token: 0x04006099 RID: 24729
	private UIText MiddleText2;

	// Token: 0x0400609A RID: 24730
	private CString MiddleStr1;

	// Token: 0x0400609B RID: 24731
	private CString MiddleStr2;

	// Token: 0x0400609C RID: 24732
	private GameObject[] NoAllyGO = new GameObject[2];

	// Token: 0x0400609D RID: 24733
	private GameObject[] HasAllyGO = new GameObject[3];

	// Token: 0x0400609E RID: 24734
	private int BuildIndex;

	// Token: 0x0400609F RID: 24735
	private UIText[] RBText = new UIText[2];
}
