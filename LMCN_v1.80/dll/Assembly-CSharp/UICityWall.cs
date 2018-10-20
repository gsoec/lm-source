using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000530 RID: 1328
public class UICityWall : GUIWindow, IBuildingWindowType, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06001A7E RID: 6782 RVA: 0x002D2334 File Offset: 0x002D0534
	public override void OnOpen(int arg1, int arg2)
	{
		this.B_ID = arg1;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.DM = DataManager.Instance;
		this.m_SliderTimeTick = 1f;
		this.m_Panel = base.transform.GetChild(0);
		for (int i = 0; i < this.m_Str.Length; i++)
		{
			this.m_Str[i] = StringManager.Instance.SpawnString(30);
		}
		uint[] array = new uint[]
		{
			3744u,
			3746u,
			3748u,
			3750u
		};
		Transform child;
		for (int j = 0; j < 4; j++)
		{
			child = this.m_Panel.GetChild(j);
			UIButton component = child.GetComponent<UIButton>();
			component.m_Handler = this;
			component.m_BtnID1 = j;
			this.m_tmptext[this.mTextCount] = child.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.m_tmptext[this.mTextCount].text = DataManager.Instance.mStringTable.GetStringByID(array[j]);
			this.m_tmptext[this.mTextCount].font = ttffont;
			this.mTextCount++;
			this.m_SliderValues[j] = child.GetChild(2).GetChild(0).GetComponent<Image>();
			this.m_SliderTexts[j] = child.GetChild(2).GetChild(1).GetComponent<UIText>();
			this.m_SliderTexts[j].font = ttffont;
		}
		child = this.m_Panel.GetChild(1);
		this.m_WallImageIcon = child.GetChild(4).GetComponent<Image>();
		UIButtonHint uibuttonHint = this.m_WallImageIcon.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		this.m_WallImageIcon.gameObject.SetActive(true);
		this.m_TypeImage[0] = this.m_Panel.GetChild(0).GetChild(3).GetComponent<Image>();
		this.m_TypeImage[1] = this.m_Panel.GetChild(1).GetChild(3).GetComponent<Image>();
		this.m_TypeImage[2] = this.m_Panel.GetChild(3).GetChild(3).GetComponent<Image>();
		for (int k = 0; k < this.m_TypeImage.Length; k++)
		{
			this.m_TypeImage[k].enabled = false;
		}
		this.m_ArrowRepair = this.m_Panel.GetChild(0).GetChild(4).GetComponent<Image>();
		this.m_Image = this.m_Panel.GetChild(2).GetChild(3).GetComponent<Image>();
		if (GUIManager.Instance.BuildingData.GuideSoldierID >= 17 && GUIManager.Instance.BuildingData.GuideSoldierID <= 28)
		{
			this.m_Image.gameObject.SetActive(true);
		}
		if (GUIManager.Instance.BuildingData.GuideSoldierID == 30)
		{
			this.m_ArrowRepair.gameObject.SetActive(true);
		}
		this.m_tmptext[this.mTextCount] = this.m_Panel.GetChild(4).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.mTextCount++;
		this.m_SprryArray = base.transform.GetComponent<UISpritesArray>();
		this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.InitBuildingWindow(12, (ushort)arg1, 2, 0);
		this.baseBuild.m_Handler = this;
		this.baseBuild.baseTransform.SetAsFirstSibling();
		this.OnTypeChange(this.baseBuild.buildType);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		this.SetTrapSlider(this.DM.TrapTotal, this.DM.GetMaxTrapValue());
		this.SeteTrapRepair(this.DM.TrapHospitalTotal, this.DM.GetMaxTrapValue());
		this.m_SelectDefender = 0;
		for (int l = 0; l < this.DM.m_DefendersID.Length; l++)
		{
			if (this.DM.m_DefendersID[l] != 0)
			{
				this.m_SelectDefender++;
			}
		}
		this.SetDefenderSlider(this.m_SelectDefender, this.DM.GetMaxDefenders());
	}

	// Token: 0x06001A7F RID: 6783 RVA: 0x002D2764 File Offset: 0x002D0964
	private void Update()
	{
		this.SetWallRePaireSlider(this.DM.m_WallRepairNowValue, this.DM.m_WallRepairMaxValue, Time.deltaTime);
	}

	// Token: 0x06001A80 RID: 6784 RVA: 0x002D2788 File Offset: 0x002D0988
	private void GetWallRepairMaxValue()
	{
		this.DM.m_WallRepairMaxValue = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_WALL_HEALTH);
	}

	// Token: 0x06001A81 RID: 6785 RVA: 0x002D27A8 File Offset: 0x002D09A8
	private void SetWallRePaireSlider(uint value, uint max, float deltaTime)
	{
		float num = Mathf.Clamp(value / max, 0f, 1f);
		this.m_SliderValues[1].rectTransform.sizeDelta = new Vector2(num * 145f, this.m_SliderValues[1].rectTransform.sizeDelta.y);
		this.m_SliderTimeTick += Time.deltaTime;
		if (this.m_SliderTimeTick >= 1f)
		{
			this.m_Str[1].ClearString();
			StringManager.Instance.IntToFormat((long)((ulong)value), 1, true);
			StringManager.Instance.IntToFormat((long)((ulong)max), 1, true);
			if (GUIManager.Instance.IsArabic)
			{
				this.m_Str[1].AppendFormat("{1} / {0}");
			}
			else
			{
				this.m_Str[1].AppendFormat("{0} / {1}");
			}
			this.m_SliderTexts[1].text = this.m_Str[1].ToString();
			this.m_SliderTimeTick = 0f;
			this.m_SliderTexts[1].SetAllDirty();
			this.m_SliderTexts[1].cachedTextGenerator.Invalidate();
		}
		if (value < max)
		{
			this.m_TypeImage[1].enabled = true;
		}
		else
		{
			this.m_TypeImage[1].enabled = false;
		}
	}

	// Token: 0x06001A82 RID: 6786 RVA: 0x002D28F8 File Offset: 0x002D0AF8
	private void SetTrapSlider(uint value, uint max)
	{
		float num = Mathf.Clamp(value / max, 0f, 1f);
		this.m_SliderValues[2].rectTransform.sizeDelta = new Vector2(num * 154f, this.m_SliderValues[2].rectTransform.sizeDelta.y);
		this.m_Str[2].ClearString();
		StringManager.Instance.IntToFormat((long)((ulong)value), 1, true);
		StringManager.Instance.IntToFormat((long)((ulong)max), 1, true);
		if (GUIManager.Instance.IsArabic)
		{
			this.m_Str[2].AppendFormat("{1} / {0}");
		}
		else
		{
			this.m_Str[2].AppendFormat("{0} / {1}");
		}
		this.m_SliderTexts[2].text = this.m_Str[2].ToString();
		this.m_SliderTexts[2].SetAllDirty();
		this.m_SliderTexts[2].cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001A83 RID: 6787 RVA: 0x002D29F4 File Offset: 0x002D0BF4
	private void SetDefenderSlider(int value, int max)
	{
		float num = Mathf.Clamp((float)value / (float)max, 0f, 1f);
		this.m_SliderValues[0].rectTransform.sizeDelta = new Vector2(num * 154f, this.m_SliderValues[0].rectTransform.sizeDelta.y);
		this.m_Str[0].ClearString();
		StringManager.Instance.IntToFormat((long)value, 1, true);
		StringManager.Instance.IntToFormat((long)max, 1, true);
		if (GUIManager.Instance.IsArabic)
		{
			this.m_Str[0].AppendFormat("{1} / {0}");
		}
		else
		{
			this.m_Str[0].AppendFormat("{0} / {1}");
		}
		this.m_SliderTexts[0].text = this.m_Str[0].ToString();
		this.m_SliderTexts[0].SetAllDirty();
		this.m_SliderTexts[0].cachedTextGenerator.Invalidate();
		bool flag = false;
		for (int i = 0; i < this.DM.FightHeroID.Length; i++)
		{
			if (this.DM.FightHeroID[i] == (uint)this.DM.GetLeaderID())
			{
				flag = true;
				break;
			}
		}
		if (value < max)
		{
			this.m_TypeImage[0].sprite = this.m_SprryArray.GetSprite(0);
			this.m_TypeImage[0].enabled = true;
		}
		else if (flag)
		{
			this.m_TypeImage[0].sprite = this.m_SprryArray.GetSprite(1);
			this.m_TypeImage[0].enabled = true;
		}
		else
		{
			this.m_TypeImage[0].enabled = false;
		}
	}

	// Token: 0x06001A84 RID: 6788 RVA: 0x002D2BA4 File Offset: 0x002D0DA4
	private void SeteTrapRepair(uint value, uint max)
	{
		float num = Mathf.Clamp(value / max, 0f, 1f);
		this.m_SliderValues[3].rectTransform.sizeDelta = new Vector2(num * 154f, this.m_SliderValues[3].rectTransform.sizeDelta.y);
		this.m_Str[3].ClearString();
		StringManager.Instance.IntToFormat((long)((ulong)value), 1, true);
		StringManager.Instance.IntToFormat((long)((ulong)max), 1, true);
		if (GUIManager.Instance.IsArabic)
		{
			this.m_Str[3].AppendFormat("{1} / {0}");
		}
		else
		{
			this.m_Str[3].AppendFormat("{0} / {1}");
		}
		this.m_SliderTexts[3].text = this.m_Str[3].ToString();
		this.m_SliderTexts[3].SetAllDirty();
		this.m_SliderTexts[3].cachedTextGenerator.Invalidate();
		if (value > 0u && value < max)
		{
			this.m_TypeImage[2].enabled = true;
		}
		else
		{
			this.m_TypeImage[2].enabled = false;
		}
	}

	// Token: 0x06001A85 RID: 6789 RVA: 0x002D2CCC File Offset: 0x002D0ECC
	public override void OnClose()
	{
		for (int i = 0; i < this.m_Str.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.m_Str[i]);
		}
		this.baseBuild.DestroyBuildingWindow();
	}

	// Token: 0x06001A86 RID: 6790 RVA: 0x002D2D10 File Offset: 0x002D0F10
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.SetWallRePaireSlider(this.DM.m_WallRepairNowValue, this.DM.m_WallRepairMaxValue, Time.deltaTime);
			this.SetTrapSlider(this.DM.TrapTotal, this.DM.GetMaxTrapValue());
			this.SeteTrapRepair(this.DM.TrapHospitalTotal, this.DM.GetMaxTrapValue());
			this.m_SelectDefender = 0;
			for (int i = 0; i < this.DM.m_DefendersID.Length; i++)
			{
				if (this.DM.m_DefendersID[i] != 0)
				{
					this.m_SelectDefender++;
				}
			}
			this.SetDefenderSlider(this.m_SelectDefender, this.DM.GetMaxDefenders());
		}
	}

	// Token: 0x06001A87 RID: 6791 RVA: 0x002D2DE8 File Offset: 0x002D0FE8
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
						this.Refresh_FontTexture();
						if (this.baseBuild != null)
						{
							this.baseBuild.Refresh_FontTexture();
						}
					}
				}
				else
				{
					this.baseBuild.MyUpdate(0, false);
					this.UpdateUI(1, 0);
				}
			}
			else
			{
				this.baseBuild.MyUpdate(meg[1], false);
				this.UpdateUI(1, 0);
			}
		}
		else
		{
			this.baseBuild.MyUpdate(0, false);
			this.UpdateUI(1, 0);
		}
	}

	// Token: 0x06001A88 RID: 6792 RVA: 0x002D2E94 File Offset: 0x002D1094
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < 4; i++)
		{
			if (this.m_SliderTexts[i] != null && this.m_SliderTexts[i].enabled)
			{
				this.m_SliderTexts[i].enabled = false;
				this.m_SliderTexts[i].enabled = true;
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (this.m_tmptext[j] != null && this.m_tmptext[j].enabled)
			{
				this.m_tmptext[j].enabled = false;
				this.m_tmptext[j].enabled = true;
			}
		}
	}

	// Token: 0x06001A89 RID: 6793 RVA: 0x002D2F48 File Offset: 0x002D1148
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
	}

	// Token: 0x06001A8A RID: 6794 RVA: 0x002D2F4C File Offset: 0x002D114C
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x06001A8B RID: 6795 RVA: 0x002D2F50 File Offset: 0x002D1150
	public void OnButtonClick(UIButton sender)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door == null)
		{
			return;
		}
		switch (sender.m_BtnID1)
		{
		case 0:
			door.OpenMenu(EGUIWindow.UI_Defenders, 0, 0, false);
			GUIManager.Instance.BuildingData.GuideSoldierID = 0;
			break;
		case 1:
			door.OpenMenu(EGUIWindow.UI_WallRepair, 0, 0, false);
			GUIManager.Instance.BuildingData.GuideSoldierID = 0;
			break;
		case 2:
			if (GUIManager.Instance.BuildingData.GuideSoldierID == 30)
			{
				GUIManager.Instance.BuildingData.GuideSoldierID = 0;
			}
			door.OpenMenu(EGUIWindow.UI_Trap, 0, 0, false);
			break;
		case 3:
			door.OpenMenu(EGUIWindow.UI_Hospital, this.B_ID, 0, false);
			GUIManager.Instance.BuildingData.GuideSoldierID = 0;
			break;
		}
	}

	// Token: 0x06001A8C RID: 6796 RVA: 0x002D303C File Offset: 0x002D123C
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing)
		{
			this.m_Panel.gameObject.SetActive(true);
			if (GUIManager.Instance.BuildingData.GuideSoldierID >= 17 && GUIManager.Instance.BuildingData.GuideSoldierID <= 28)
			{
				this.m_Image.gameObject.SetActive(true);
			}
			else
			{
				this.m_Image.gameObject.SetActive(false);
			}
			if (GUIManager.Instance.BuildingData.GuideSoldierID == 30)
			{
				this.m_ArrowRepair.gameObject.SetActive(true);
			}
			else
			{
				this.m_ArrowRepair.gameObject.SetActive(false);
			}
		}
		else
		{
			this.m_Panel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001A8D RID: 6797 RVA: 0x002D3110 File Offset: 0x002D1310
	public void OnButtonDown(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, 11167, 0, Vector2.zero, UIButtonHint.ePosition.Original);
	}

	// Token: 0x06001A8E RID: 6798 RVA: 0x002D3144 File Offset: 0x002D1344
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(sender);
	}

	// Token: 0x04004EAB RID: 20139
	private const float MaxSliderValue = 154f;

	// Token: 0x04004EAC RID: 20140
	private const float MaxWallRePaireSliderValue = 145f;

	// Token: 0x04004EAD RID: 20141
	private const int TextMax = 5;

	// Token: 0x04004EAE RID: 20142
	private BuildingWindow baseBuild;

	// Token: 0x04004EAF RID: 20143
	private Transform m_Panel;

	// Token: 0x04004EB0 RID: 20144
	private Image[] m_SliderValues = new Image[4];

	// Token: 0x04004EB1 RID: 20145
	private UIText[] m_SliderTexts = new UIText[4];

	// Token: 0x04004EB2 RID: 20146
	private CString[] m_Str = new CString[5];

	// Token: 0x04004EB3 RID: 20147
	private Image[] m_TypeImage = new Image[3];

	// Token: 0x04004EB4 RID: 20148
	private UISpritesArray m_SprryArray;

	// Token: 0x04004EB5 RID: 20149
	private Image m_WallImageIcon;

	// Token: 0x04004EB6 RID: 20150
	private int B_ID;

	// Token: 0x04004EB7 RID: 20151
	private DataManager DM;

	// Token: 0x04004EB8 RID: 20152
	private float m_SliderTimeTick;

	// Token: 0x04004EB9 RID: 20153
	private int m_SelectDefender;

	// Token: 0x04004EBA RID: 20154
	private Image m_ArrowRepair;

	// Token: 0x04004EBB RID: 20155
	private Image m_Image;

	// Token: 0x04004EBC RID: 20156
	private int mTextCount;

	// Token: 0x04004EBD RID: 20157
	private UIText[] m_tmptext = new UIText[5];
}
