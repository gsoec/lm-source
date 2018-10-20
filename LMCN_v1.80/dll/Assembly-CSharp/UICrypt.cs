using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000531 RID: 1329
public class UICrypt : GUIWindow, IBuildingWindowType, IUIButtonClickHandler
{
	// Token: 0x06001A90 RID: 6800 RVA: 0x002D3164 File Offset: 0x002D1364
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
		this.B_ID = (ushort)arg1;
		this.barText = StringManager.Instance.SpawnString(100);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIButton component = this.AGS_Form.GetChild(1).GetChild(1).GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1;
		component.m_EffectType = e_EffectType.e_Scale;
		UIText component2 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(5).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = this.DM.mStringTable.GetStringByID(3986u);
		component = this.AGS_Form.GetChild(1).GetChild(2).GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 2;
		component.m_EffectType = e_EffectType.e_Scale;
		component2 = this.AGS_Form.GetChild(1).GetChild(2).GetChild(5).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = this.DM.mStringTable.GetStringByID(3987u);
		component = this.AGS_Form.GetChild(1).GetChild(3).GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 3;
		component.m_EffectType = e_EffectType.e_Scale;
		component2 = this.AGS_Form.GetChild(1).GetChild(3).GetChild(5).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = this.DM.mStringTable.GetStringByID(3988u);
		component2 = this.AGS_Form.GetChild(1).GetChild(4).GetChild(1).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = string.Empty;
		this.light1 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(3).GetComponent<Image>();
		this.light2 = this.AGS_Form.GetChild(1).GetChild(2).GetChild(3).GetComponent<Image>();
		this.light3 = this.AGS_Form.GetChild(1).GetChild(3).GetChild(3).GetComponent<Image>();
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component3 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(2).GetComponent<RectTransform>();
			component3.localScale = new Vector3(-1f, 1f, 1f);
			component3.anchoredPosition = new Vector2(component3.anchoredPosition.x + 70f, component3.anchoredPosition.y);
			component3 = this.AGS_Form.GetChild(1).GetChild(2).GetChild(2).GetComponent<RectTransform>();
			component3.localScale = new Vector3(-1f, 1f, 1f);
			component3.anchoredPosition = new Vector2(component3.anchoredPosition.x + 70f, component3.anchoredPosition.y);
			component3 = this.AGS_Form.GetChild(1).GetChild(3).GetChild(2).GetComponent<RectTransform>();
			component3.localScale = new Vector3(-1f, 1f, 1f);
			component3.anchoredPosition = new Vector2(component3.anchoredPosition.x + 70f, component3.anchoredPosition.y);
		}
		this.updataTimeBar();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001A91 RID: 6801 RVA: 0x002D350C File Offset: 0x002D170C
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		StringManager.Instance.DeSpawnString(this.barText);
	}

	// Token: 0x06001A92 RID: 6802 RVA: 0x002D353C File Offset: 0x002D173C
	private void Start()
	{
		UnityEngine.Object.Destroy(this.AGS_Form.GetChild(0).gameObject);
		this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		byte level = GUIManager.Instance.BuildingData.AllBuildsData[(int)this.B_ID].Level;
		this.baseBuild.InitBuildingWindow(16, this.B_ID, 2, level);
		this.baseBuild.baseTransform.SetAsFirstSibling();
		this.NoReflashFont = true;
	}

	// Token: 0x06001A93 RID: 6803 RVA: 0x002D35D0 File Offset: 0x002D17D0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Refresh_BuildBase)
		{
			if (networkNews != NetworkNews.Refresh_AttribEffectVal)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
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
				this.baseBuild.MyUpdate(0, false);
			}
		}
		else if (meg[1] == 1)
		{
			this.door.CloseMenu(true);
		}
		else if (this.baseBuild != null)
		{
			this.baseBuild.MyUpdate(meg[1], false);
		}
	}

	// Token: 0x06001A94 RID: 6804 RVA: 0x002D3678 File Offset: 0x002D1878
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			this.updataTimeBar();
		}
	}

	// Token: 0x06001A95 RID: 6805 RVA: 0x002D3688 File Offset: 0x002D1888
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

	// Token: 0x06001A96 RID: 6806 RVA: 0x002D36DC File Offset: 0x002D18DC
	public void OnButtonClick(UIButton sender)
	{
		this.door.OpenMenu(EGUIWindow.UI_CryptDig, sender.m_BtnID1, 0, false);
	}

	// Token: 0x06001A97 RID: 6807 RVA: 0x002D36F4 File Offset: 0x002D18F4
	public void updataTimeBar()
	{
		RectTransform component = this.AGS_Form.GetChild(1).GetChild(4).GetComponent<RectTransform>();
		this.AGS_Form.GetChild(1).GetChild(1).GetChild(2).gameObject.SetActive(false);
		this.AGS_Form.GetChild(1).GetChild(2).GetChild(2).gameObject.SetActive(false);
		this.AGS_Form.GetChild(1).GetChild(3).GetChild(2).gameObject.SetActive(false);
		if (this.DM.m_CryptData.money == 0)
		{
			this.light1.gameObject.SetActive(false);
			this.light2.gameObject.SetActive(false);
			this.light3.gameObject.SetActive(false);
			component.gameObject.SetActive(false);
			return;
		}
		component.gameObject.SetActive(true);
		component.anchoredPosition = new Vector2((float)(-342 + (int)((this.DM.m_CryptData.kind - 1) * 249)), -79f);
		long num = this.DM.m_CryptData.startTime + (long)((ulong)GameConstants.CryptSecends[(int)this.DM.m_CryptData.kind]) - this.DM.ServerTime;
		if (num < 0L)
		{
			num = 0L;
		}
		UIText component2 = component.GetChild(1).GetComponent<UIText>();
		this.barText.ClearString();
		if (num != 0L)
		{
			this.barText.Append(this.DM.mStringTable.GetStringByID(3989u));
			this.barText.Append(" ");
			GameConstants.GetTimeString(this.barText, (uint)num, false, true, true, false, true);
			component2.text = this.barText.ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			component = component.GetChild(0).GetComponent<RectTransform>();
			float num2 = (float)num / GameConstants.CryptSecends[(int)this.DM.m_CryptData.kind];
			num2 = Mathf.Clamp01(1f - num2);
			component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 164f);
			return;
		}
		this.AGS_Form.GetChild(1).GetChild((int)(0 + this.DM.m_CryptData.kind)).GetChild(2).gameObject.SetActive(true);
		this.barText.Append(this.DM.mStringTable.GetStringByID(5881u));
		this.light1.gameObject.SetActive(false);
		this.light2.gameObject.SetActive(false);
		this.light3.gameObject.SetActive(false);
		component.gameObject.SetActive(false);
		switch (this.DM.m_CryptData.kind)
		{
		case 1:
			this.light1.gameObject.SetActive(true);
			break;
		case 2:
			this.light2.gameObject.SetActive(true);
			break;
		case 3:
			this.light3.gameObject.SetActive(true);
			break;
		}
	}

	// Token: 0x06001A98 RID: 6808 RVA: 0x002D3A20 File Offset: 0x002D1C20
	public void Refresh_FontTexture()
	{
		if (this.NoReflashFont)
		{
			this.ReflashFont = true;
			return;
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(1).GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(2).GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(3).GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(4).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
	}

	// Token: 0x06001A99 RID: 6809 RVA: 0x002D3B4C File Offset: 0x002D1D4C
	public void Update()
	{
		this.NoReflashFont = false;
		if (this.ReflashFont)
		{
			this.Refresh_FontTexture();
		}
		this.HintTime += Time.smoothDeltaTime / 2f;
		if (this.HintTime >= 2f)
		{
			this.HintTime = 0f;
		}
		float a = (this.HintTime <= 1f) ? this.HintTime : (2f - this.HintTime);
		Color color = new Color(1f, 1f, 1f, a);
		this.light1.color = color;
		this.light2.color = color;
		this.light3.color = color;
	}

	// Token: 0x04004EBE RID: 20158
	private Transform AGS_Form;

	// Token: 0x04004EBF RID: 20159
	private BuildingWindow baseBuild;

	// Token: 0x04004EC0 RID: 20160
	private ushort B_ID;

	// Token: 0x04004EC1 RID: 20161
	private Door door;

	// Token: 0x04004EC2 RID: 20162
	private DataManager DM;

	// Token: 0x04004EC3 RID: 20163
	private Image light1;

	// Token: 0x04004EC4 RID: 20164
	private Image light2;

	// Token: 0x04004EC5 RID: 20165
	private Image light3;

	// Token: 0x04004EC6 RID: 20166
	private CString barText;

	// Token: 0x04004EC7 RID: 20167
	private bool ReflashFont;

	// Token: 0x04004EC8 RID: 20168
	private bool NoReflashFont;

	// Token: 0x04004EC9 RID: 20169
	private float HintTime;

	// Token: 0x02000532 RID: 1330
	private enum e_AGS_UI_Crypt_Editor
	{
		// Token: 0x04004ECB RID: 20171
		BuildingWindow,
		// Token: 0x04004ECC RID: 20172
		MyWindow
	}

	// Token: 0x02000533 RID: 1331
	private enum e_AGS_MyWindow
	{
		// Token: 0x04004ECE RID: 20174
		BGImage,
		// Token: 0x04004ECF RID: 20175
		Group1,
		// Token: 0x04004ED0 RID: 20176
		Group2,
		// Token: 0x04004ED1 RID: 20177
		Group3,
		// Token: 0x04004ED2 RID: 20178
		Bar
	}

	// Token: 0x02000534 RID: 1332
	private enum e_AGS_Group
	{
		// Token: 0x04004ED4 RID: 20180
		frame,
		// Token: 0x04004ED5 RID: 20181
		Btn,
		// Token: 0x04004ED6 RID: 20182
		Check,
		// Token: 0x04004ED7 RID: 20183
		Light,
		// Token: 0x04004ED8 RID: 20184
		TextBg,
		// Token: 0x04004ED9 RID: 20185
		Text
	}

	// Token: 0x02000535 RID: 1333
	private enum e_AGS_Bar
	{
		// Token: 0x04004EDB RID: 20187
		Bar,
		// Token: 0x04004EDC RID: 20188
		Text
	}
}
