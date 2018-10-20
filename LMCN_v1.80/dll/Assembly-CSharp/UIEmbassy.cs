using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000546 RID: 1350
public class UIEmbassy : GUIWindow, IBuildingWindowType, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06001AD1 RID: 6865 RVA: 0x002D81A8 File Offset: 0x002D63A8
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager instance = GUIManager.Instance;
		this.DM = DataManager.Instance;
		this.SM = StringManager.Instance;
		this.m_Font = instance.GetTTFFont();
		this.m_transform = base.transform;
		this.SA = this.m_transform.GetComponent<UISpritesArray>();
		byte level = instance.BuildingData.AllBuildsData[arg1].Level;
		this.NormalPanel = this.m_transform.GetChild(0);
		this.NormalPanel.GetChild(1).GetComponent<UIButton>().m_Handler = this;
		this.NormalPanel.GetChild(2).GetComponent<UIButton>().m_Handler = this;
		this.RBText[0] = this.NormalPanel.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.RBText[0].font = this.m_Font;
		this.RBText[0].text = this.DM.mStringTable.GetStringByID(4820u);
		this.RBText[1] = this.NormalPanel.GetChild(5).GetComponent<UIText>();
		this.RBText[1].font = this.m_Font;
		this.RBText[1].text = this.DM.mStringTable.GetStringByID(4821u);
		RectTransform component = this.NormalPanel.GetChild(3).GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(-176f - this.RBText[1].preferredWidth * 0.5f, this.RBText[1].rectTransform.anchoredPosition.y);
		this.RBText[2] = this.NormalPanel.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.RBText[2].font = this.m_Font;
		this.RBText[2].text = this.DM.mStringTable.GetStringByID(4825u);
		this.TitleText = this.NormalPanel.GetChild(6).GetComponent<UIText>();
		this.TitleText.font = this.m_Font;
		this.MaxStr = this.SM.SpawnString(100);
		this.RBText[3] = this.NormalPanel.GetChild(7).GetComponent<UIText>();
		this.RBText[3].font = this.m_Font;
		this.RBText[3].text = this.DM.mStringTable.GetStringByID(4824u);
		this.RBText[4] = this.NormalPanel.GetChild(8).GetComponent<UIText>();
		this.RBText[4].font = this.m_Font;
		this.RBText[4].text = this.DM.mStringTable.GetStringByID(5785u);
		this.Scroll = this.NormalPanel.GetChild(9).GetComponent<ScrollPanel>();
		for (int i = 0; i < 30; i++)
		{
			this.NowHeightList.Add(39f);
		}
		this.Scroll.IntiScrollPanel(289f, 0f, 0f, this.NowHeightList, 10, this);
		UIButtonHint.scrollRect = this.NormalPanel.GetChild(9).GetComponent<CScrollRect>();
		this.HasArmyGO[0] = this.NormalPanel.GetChild(2).gameObject;
		this.HasArmyGO[1] = this.NormalPanel.GetChild(9).gameObject;
		this.NoArmyGO[0] = this.NormalPanel.GetChild(4).gameObject;
		this.NoArmyGO[1] = this.NormalPanel.GetChild(7).gameObject;
		this.HasAllyGO = this.NormalPanel.GetChild(1).gameObject;
		this.NoAllyGO = this.NormalPanel.GetChild(8).gameObject;
		for (int j = 0; j < 10; j++)
		{
			this.bFindScrollComp[j] = false;
		}
		this.baseBuild = this.m_transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		this.baseBuild.InitBuildingWindow(this.BuildID, (ushort)arg1, 1, level);
		this.baseBuild.baseTransform.SetAsFirstSibling();
		instance.UpdateUI(EGUIWindow.Door, 1, 2);
		this.CheckHasArmy();
		this.CheckHasAlly();
	}

	// Token: 0x06001AD2 RID: 6866 RVA: 0x002D85F4 File Offset: 0x002D67F4
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		for (int i = 9; i >= 0; i--)
		{
			if (this.ItemStrL[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.ItemStrL[i]);
				this.ItemStrL[i] = null;
			}
			if (this.ItemStrR[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.ItemStrR[i]);
				this.ItemStrR[i] = null;
			}
			if (this.TierStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.TierStr[i]);
				this.TierStr[i] = null;
			}
		}
		if (this.MaxStr != null)
		{
			this.SM.DeSpawnString(this.MaxStr);
			this.MaxStr = null;
		}
	}

	// Token: 0x06001AD3 RID: 6867 RVA: 0x002D86D0 File Offset: 0x002D68D0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Alliance)
			{
				if (networkNews != NetworkNews.Refresh_BuildBase)
				{
					if (networkNews != NetworkNews.Refresh_AttribEffectVal)
					{
						if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
						{
							this.baseBuild.Refresh_FontTexture();
							if (this.TitleText != null && this.TitleText.enabled)
							{
								this.TitleText.enabled = false;
								this.TitleText.enabled = true;
							}
							for (int i = 0; i < this.RBText.Length; i++)
							{
								if (this.RBText[i] != null && this.RBText[i].enabled)
								{
									this.RBText[i].enabled = false;
									this.RBText[i].enabled = true;
								}
							}
							for (int j = 0; j < 10; j++)
							{
								if (this.bFindScrollComp[j])
								{
									if (this.Scroll_Comp[j].TextL != null && this.Scroll_Comp[j].TextL.enabled)
									{
										this.Scroll_Comp[j].TextL.enabled = false;
										this.Scroll_Comp[j].TextL.enabled = true;
									}
									if (this.Scroll_Comp[j].TextR != null && this.Scroll_Comp[j].TextR.enabled)
									{
										this.Scroll_Comp[j].TextR.enabled = false;
										this.Scroll_Comp[j].TextR.enabled = true;
									}
									if (this.Scroll_Comp[j].TierText != null && this.Scroll_Comp[j].TierText.enabled)
									{
										this.Scroll_Comp[j].TierText.enabled = false;
										this.Scroll_Comp[j].TierText.enabled = true;
									}
								}
							}
						}
					}
					else
					{
						this.CheckHasArmy();
					}
				}
				else
				{
					this.baseBuild.MyUpdate(meg[1], false);
				}
			}
			else
			{
				this.CheckHasAlly();
			}
		}
		else
		{
			this.baseBuild.MyUpdate(0, false);
		}
	}

	// Token: 0x06001AD4 RID: 6868 RVA: 0x002D893C File Offset: 0x002D6B3C
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 0)
		{
			if (arg1 == 1)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.CloseMenu(false);
			}
		}
		else
		{
			this.CheckHasArmy();
		}
	}

	// Token: 0x06001AD5 RID: 6869 RVA: 0x002D8988 File Offset: 0x002D6B88
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
		{
			this.NormalPanel.gameObject.SetActive(true);
		}
		else
		{
			this.NormalPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001AD6 RID: 6870 RVA: 0x002D89D0 File Offset: 0x002D6BD0
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_Alliance_List, 5, 0, false);
		}
		else if (sender.m_BtnID1 == 2)
		{
			GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4850u), this.DM.mStringTable.GetStringByID(4851u), 1, 0, this.DM.mStringTable.GetStringByID(4852u), this.DM.mStringTable.GetStringByID(4853u));
		}
	}

	// Token: 0x06001AD7 RID: 6871 RVA: 0x002D8A78 File Offset: 0x002D6C78
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 == 1)
			{
				this.DM.Send_DissMiss_Inforce();
			}
		}
	}

	// Token: 0x06001AD8 RID: 6872 RVA: 0x002D8AAC File Offset: 0x002D6CAC
	public void CheckHasArmy()
	{
		int num = 0;
		this.TroopsTotal = 0L;
		this.NowHeightList.Clear();
		for (int i = 0; i < 16; i++)
		{
			int num2 = 3 - i / 4 + i % 4 * 4;
			if (this.DM.mSoldier_Embassy[num2] > 0u)
			{
				this.mTroopsIdx[num] = (byte)num2;
				num++;
				this.NowHeightList.Add(39f);
				this.TroopsTotal += (long)((ulong)this.DM.mSoldier_Embassy[num2]);
			}
		}
		for (int j = 0; j < this.HasArmyGO.Length; j++)
		{
			this.HasArmyGO[j].SetActive(this.TroopsTotal > 0L);
		}
		for (int k = 0; k < this.NoArmyGO.Length; k++)
		{
			this.NoArmyGO[k].SetActive(this.TroopsTotal <= 0L);
		}
		if (this.TroopsTotal > 0L)
		{
			this.Scroll.AddNewDataHeight(this.NowHeightList, true, true);
			this.MaxStr.Length = 0;
			this.MaxStr.StringToFormat(this.DM.mStringTable.GetStringByID(4823u));
			this.MaxStr.IntToFormat(this.TroopsTotal, 1, true);
			this.MaxStr.IntToFormat((long)((ulong)this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_REINFORCE_CAPACITY)), 1, true);
			this.MaxStr.AppendFormat("{0} {1} / {2}");
		}
		else
		{
			this.MaxStr.Length = 0;
			this.MaxStr.StringToFormat(this.DM.mStringTable.GetStringByID(4822u));
			this.MaxStr.IntToFormat((long)((ulong)this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_REINFORCE_CAPACITY)), 1, true);
			this.MaxStr.AppendFormat("{0}{1}");
		}
		this.TitleText.text = this.MaxStr.ToString();
		this.TitleText.SetAllDirty();
		this.TitleText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001AD9 RID: 6873 RVA: 0x002D8CCC File Offset: 0x002D6ECC
	public void CheckHasAlly()
	{
		bool flag = this.DM.RoleAlliance.Id != 0u;
		this.NoAllyGO.SetActive(!flag);
		this.HasAllyGO.SetActive(flag);
	}

	// Token: 0x06001ADA RID: 6874 RVA: 0x002D8D0C File Offset: 0x002D6F0C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < 10)
		{
			if (!this.bFindScrollComp[panelObjectIdx])
			{
				this.bFindScrollComp[panelObjectIdx] = true;
				Transform transform = item.transform;
				this.Scroll_Comp[panelObjectIdx].TextL = transform.GetChild(0).GetComponent<UIText>();
				this.Scroll_Comp[panelObjectIdx].TextL.font = this.m_Font;
				this.Scroll_Comp[panelObjectIdx].TextR = transform.GetChild(1).GetComponent<UIText>();
				this.Scroll_Comp[panelObjectIdx].TextR.font = this.m_Font;
				this.Scroll_Comp[panelObjectIdx].KindImg = transform.GetChild(2).GetComponent<Image>();
				this.Scroll_Comp[panelObjectIdx].TierText = transform.GetChild(2).GetChild(0).GetComponent<UIText>();
				this.Scroll_Comp[panelObjectIdx].TierText.font = this.m_Font;
				this.Scroll_Comp[panelObjectIdx].TierText.resizeTextForBestFit = true;
				this.Scroll_Comp[panelObjectIdx].TierText.resizeTextMaxSize = 16;
				this.Scroll_Comp[panelObjectIdx].TierText.resizeTextMinSize = 10;
				this.Scroll_Comp[panelObjectIdx].HintRC = transform.GetChild(3).GetComponent<RectTransform>();
				this.Scroll_Comp[panelObjectIdx].Hint = transform.GetChild(3).gameObject.AddComponent<UIButtonHint>();
				this.Scroll_Comp[panelObjectIdx].Hint.m_eHint = EUIButtonHint.CountDown;
				this.Scroll_Comp[panelObjectIdx].Hint.DelayTime = 0.2f;
				this.Scroll_Comp[panelObjectIdx].Hint.m_Handler = this;
				this.Scroll_Comp[panelObjectIdx].Hint.Parm1 = 0;
				this.ItemStrL[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.ItemStrR[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.TierStr[panelObjectIdx] = StringManager.Instance.SpawnString(30);
			}
			if (dataIdx < 0 || dataIdx >= this.mTroopsIdx.Length)
			{
				return;
			}
			this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(this.mTroopsIdx[dataIdx] + 1));
			this.Scroll_Comp[panelObjectIdx].Hint.Parm1 = (ushort)this.mTroopsIdx[dataIdx];
			this.Scroll_Comp[panelObjectIdx].KindImg.sprite = this.SA.GetSprite((int)this.tmpSD.SoldierKind);
			this.TierStr[panelObjectIdx].Length = 0;
			if ((int)this.tmpSD.Tier < GameConstants.numChar.Length)
			{
				this.TierStr[panelObjectIdx].Append(GameConstants.numChar[(int)this.tmpSD.Tier]);
			}
			this.Scroll_Comp[panelObjectIdx].TierText.text = this.TierStr[panelObjectIdx].ToString();
			this.Scroll_Comp[panelObjectIdx].TierText.SetAllDirty();
			this.Scroll_Comp[panelObjectIdx].TierText.cachedTextGenerator.Invalidate();
			this.ItemStrL[panelObjectIdx].Length = 0;
			this.ItemStrL[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
			this.Scroll_Comp[panelObjectIdx].TextL.text = this.ItemStrL[panelObjectIdx].ToString();
			this.Scroll_Comp[panelObjectIdx].TextL.SetAllDirty();
			this.Scroll_Comp[panelObjectIdx].TextL.cachedTextGenerator.Invalidate();
			this.Scroll_Comp[panelObjectIdx].TextL.cachedTextGeneratorForLayout.Invalidate();
			this.ItemStrR[panelObjectIdx].Length = 0;
			StringManager.IntToStr(this.ItemStrR[panelObjectIdx], (long)((ulong)this.DM.mSoldier_Embassy[(int)this.mTroopsIdx[dataIdx]]), 1, true);
			this.Scroll_Comp[panelObjectIdx].TextR.text = this.ItemStrR[panelObjectIdx].ToString();
			this.Scroll_Comp[panelObjectIdx].TextR.SetAllDirty();
			this.Scroll_Comp[panelObjectIdx].TextR.cachedTextGenerator.Invalidate();
			this.Scroll_Comp[panelObjectIdx].HintRC.sizeDelta = new Vector2(this.Scroll_Comp[panelObjectIdx].TextL.preferredWidth + 32f, 38.5f);
		}
	}

	// Token: 0x06001ADB RID: 6875 RVA: 0x002D91B0 File Offset: 0x002D73B0
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001ADC RID: 6876 RVA: 0x002D91B4 File Offset: 0x002D73B4
	public void OnButtonDown(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 3, 277f, 20, (int)sender.Parm1, 0, new Vector2(70f, 0f), UIButtonHint.ePosition.Original);
	}

	// Token: 0x06001ADD RID: 6877 RVA: 0x002D91F4 File Offset: 0x002D73F4
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(sender);
	}

	// Token: 0x04004F7C RID: 20348
	private const int UnitCount = 10;

	// Token: 0x04004F7D RID: 20349
	private Transform m_transform;

	// Token: 0x04004F7E RID: 20350
	private Transform NormalPanel;

	// Token: 0x04004F7F RID: 20351
	private BuildingWindow baseBuild;

	// Token: 0x04004F80 RID: 20352
	private GameObject NoAllyGO;

	// Token: 0x04004F81 RID: 20353
	private GameObject HasAllyGO;

	// Token: 0x04004F82 RID: 20354
	private GameObject[] NoArmyGO = new GameObject[2];

	// Token: 0x04004F83 RID: 20355
	private GameObject[] HasArmyGO = new GameObject[2];

	// Token: 0x04004F84 RID: 20356
	private ScrollPanel Scroll;

	// Token: 0x04004F85 RID: 20357
	private Font m_Font;

	// Token: 0x04004F86 RID: 20358
	private DataManager DM;

	// Token: 0x04004F87 RID: 20359
	private StringManager SM;

	// Token: 0x04004F88 RID: 20360
	private byte BuildID = 14;

	// Token: 0x04004F89 RID: 20361
	private UIText TitleText;

	// Token: 0x04004F8A RID: 20362
	private UISpritesArray SA;

	// Token: 0x04004F8B RID: 20363
	private List<float> NowHeightList = new List<float>();

	// Token: 0x04004F8C RID: 20364
	private bool[] bFindScrollComp = new bool[10];

	// Token: 0x04004F8D RID: 20365
	private ItemComp[] Scroll_Comp = new ItemComp[10];

	// Token: 0x04004F8E RID: 20366
	private CString[] ItemStrL = new CString[10];

	// Token: 0x04004F8F RID: 20367
	private CString[] ItemStrR = new CString[10];

	// Token: 0x04004F90 RID: 20368
	private CString[] TierStr = new CString[10];

	// Token: 0x04004F91 RID: 20369
	private CString MaxStr;

	// Token: 0x04004F92 RID: 20370
	private SoldierData tmpSD;

	// Token: 0x04004F93 RID: 20371
	private byte[] mTroopsIdx = new byte[16];

	// Token: 0x04004F94 RID: 20372
	private long TroopsTotal;

	// Token: 0x04004F95 RID: 20373
	private UIText[] RBText = new UIText[5];
}
