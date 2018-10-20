using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200049A RID: 1178
public class UI_PetResourceStation : GUIWindow, IBuildingWindowType
{
	// Token: 0x0600180C RID: 6156 RVA: 0x0028AA30 File Offset: 0x00288C30
	public override void OnOpen(int arg1, int arg2)
	{
		this.Manor_ID = (ushort)arg1;
		DataManager instance = DataManager.Instance;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = instance.mStringTable.GetStringByID(12106u);
		component = this.AGS_Form.GetChild(1).GetChild(0).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.ResourceAmount = component;
		component = this.AGS_Form.GetChild(1).GetChild(1).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = instance.mStringTable.GetStringByID(12107u);
		component = this.AGS_Form.GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(1).GetChild(2).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = instance.mStringTable.GetStringByID(12108u);
		component = this.AGS_Form.GetChild(1).GetChild(2).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(1).GetChild(3).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = instance.mStringTable.GetStringByID(12109u);
		component = this.AGS_Form.GetChild(1).GetChild(3).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.SetOnOpen();
	}

	// Token: 0x0600180D RID: 6157 RVA: 0x0028AC1C File Offset: 0x00288E1C
	public void Refresh_FontTexture()
	{
		if (this.NoReflashFont)
		{
			this.ReflashFont = true;
			return;
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(0).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(1).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(2).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(2).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(3).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(3).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
	}

	// Token: 0x0600180E RID: 6158 RVA: 0x0028AE54 File Offset: 0x00289054
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		for (int i = 0; i < this.values.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.values[i]);
		}
	}

	// Token: 0x0600180F RID: 6159 RVA: 0x0028AEAC File Offset: 0x002890AC
	private void Start()
	{
		this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		byte level = GUIManager.Instance.BuildingData.AllBuildsData[(int)this.Manor_ID].Level;
		this.baseBuild.InitBuildingWindow(21, this.Manor_ID, 2, level);
		UnityEngine.Object.Destroy(this.AGS_Form.GetChild(0).gameObject);
		this.baseBuild.baseTransform.SetAsFirstSibling();
		this.NoReflashFont = true;
	}

	// Token: 0x06001810 RID: 6160 RVA: 0x0028AF40 File Offset: 0x00289140
	public void Update()
	{
		this.NoReflashFont = false;
		if (this.ReflashFont)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x06001811 RID: 6161 RVA: 0x0028AF5C File Offset: 0x0028915C
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
		{
			this.AGS_Form.GetChild(1).gameObject.SetActive(true);
		}
		else
		{
			this.AGS_Form.GetChild(1).gameObject.SetActive(false);
		}
	}

	// Token: 0x06001812 RID: 6162 RVA: 0x0028AFB0 File Offset: 0x002891B0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Refresh_BuildBase)
		{
			if (networkNews != NetworkNews.Refresh_AttribEffectVal)
			{
				if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
				{
					if (networkNews == NetworkNews.Refresh_PetResource)
					{
						this.UpdateResource();
					}
				}
				else
				{
					if (this.baseBuild != null)
					{
						this.baseBuild.Refresh_FontTexture();
					}
					this.Refresh_FontTexture();
				}
			}
			else
			{
				if (this.baseBuild != null)
				{
					this.baseBuild.MyUpdate(0, false);
				}
				this.UpdateInfo();
			}
		}
		else
		{
			if (meg[1] == 1)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.CloseMenu(true);
			}
			else if (this.baseBuild != null)
			{
				this.baseBuild.MyUpdate(meg[1], false);
			}
			this.UpdateInfo();
		}
	}

	// Token: 0x06001813 RID: 6163 RVA: 0x0028B094 File Offset: 0x00289294
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 0)
		{
			if (arg1 == 1)
			{
				this.UpdateInfo();
			}
		}
		else
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.CloseMenu(false);
			}
		}
	}

	// Token: 0x06001814 RID: 6164 RVA: 0x0028B0EC File Offset: 0x002892EC
	private void SetOnOpen()
	{
		this.values = new CString[4];
		for (int i = 0; i < this.values.Length; i++)
		{
			this.values[i] = StringManager.Instance.SpawnString(30);
		}
		this.UpdateResource();
		this.UpdateInfo();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
	}

	// Token: 0x06001815 RID: 6165 RVA: 0x0028B14C File Offset: 0x0028934C
	private void UpdateResource()
	{
		this.values[0].ClearString();
		this.values[0].IntToFormat((long)((ulong)DataManager.Instance.PetResource.Stock), 1, true);
		this.values[0].AppendFormat("{0}");
		this.ResourceAmount.text = this.values[0].ToString();
		this.ResourceAmount.cachedTextGenerator.Invalidate();
		this.ResourceAmount.SetAllDirty();
	}

	// Token: 0x06001816 RID: 6166 RVA: 0x0028B1CC File Offset: 0x002893CC
	private void UpdateInfo()
	{
		BuildLevelRequest buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(21, GUIManager.Instance.BuildingData.AllBuildsData[(int)this.Manor_ID].Level);
		long num = 0L;
		if (buildLevelRequestData.Effect1 == 358)
		{
			num = (long)((ulong)buildLevelRequestData.Value1);
		}
		else if (buildLevelRequestData.Effect2 == 358)
		{
			num = (long)((ulong)buildLevelRequestData.Value2);
		}
		else if (buildLevelRequestData.Effect3 == 358)
		{
			num = (long)buildLevelRequestData.Value3;
		}
		num = num * (long)((ulong)DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETRSS_PRODUCTION_PERCENT) + 10000UL) / 10000L;
		this.values[1].ClearString();
		this.values[1].IntToFormat(num, 1, true);
		this.values[1].AppendFormat("{0}");
		UIText component = this.AGS_Form.GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
		component.text = this.values[1].ToString();
		component.cachedTextGenerator.Invalidate();
		component.SetAllDirty();
		this.values[2].ClearString();
		this.values[2].IntToFormat((long)((ulong)DataManager.Instance.PetResource.Capacity), 1, true);
		this.values[2].AppendFormat("{0}");
		component = this.AGS_Form.GetChild(1).GetChild(2).GetChild(2).GetComponent<UIText>();
		component.text = this.values[2].ToString();
		component.cachedTextGenerator.Invalidate();
		component.SetAllDirty();
		this.values[3].ClearString();
		this.values[3].IntToFormat(DataManager.Instance.PetResource.GetSpeed(), 1, true);
		this.values[3].AppendFormat("{0}");
		component = this.AGS_Form.GetChild(1).GetChild(3).GetChild(2).GetComponent<UIText>();
		component.text = this.values[3].ToString();
		component.cachedTextGenerator.Invalidate();
		component.SetAllDirty();
	}

	// Token: 0x040046DF RID: 18143
	private Transform AGS_Form;

	// Token: 0x040046E0 RID: 18144
	private BuildingWindow baseBuild;

	// Token: 0x040046E1 RID: 18145
	private ushort Manor_ID;

	// Token: 0x040046E2 RID: 18146
	private UIText ResourceAmount;

	// Token: 0x040046E3 RID: 18147
	private CString[] values;

	// Token: 0x040046E4 RID: 18148
	private bool ReflashFont;

	// Token: 0x040046E5 RID: 18149
	private bool NoReflashFont;

	// Token: 0x0200049B RID: 1179
	private enum e_AGS_UI_PetResourceStation_Editor
	{
		// Token: 0x040046E7 RID: 18151
		builidingWindows,
		// Token: 0x040046E8 RID: 18152
		MyFormItems
	}

	// Token: 0x0200049C RID: 1180
	private enum e_AGS_MyFormItems
	{
		// Token: 0x040046EA RID: 18154
		TitlePanel,
		// Token: 0x040046EB RID: 18155
		HavePanel,
		// Token: 0x040046EC RID: 18156
		CapPanel,
		// Token: 0x040046ED RID: 18157
		totalIncome
	}

	// Token: 0x0200049D RID: 1181
	private enum e_AGS_TitlePanel
	{
		// Token: 0x040046EF RID: 18159
		Image,
		// Token: 0x040046F0 RID: 18160
		UIText,
		// Token: 0x040046F1 RID: 18161
		UIText2
	}
}
