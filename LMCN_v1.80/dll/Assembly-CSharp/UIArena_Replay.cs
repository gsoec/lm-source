using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200033C RID: 828
public class UIArena_Replay : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x060010DB RID: 4315 RVA: 0x001E1178 File Offset: 0x001DF378
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.AM = ArenaManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		for (int i = 0; i < 7; i++)
		{
			this.Cstr_Rank[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_Name[i] = StringManager.Instance.SpawnString(30);
		}
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		Material material = this.door.LoadMaterial();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		Transform child = this.GameT.GetChild(0);
		Transform child2 = child.GetChild(0).GetChild(0);
		this.text_Title = child2.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(9122u);
		child = this.GameT.GetChild(1);
		this.m_ScrollPanel = child.GetChild(0).GetComponent<ScrollPanel>();
		child2 = child.GetChild(1);
		this.tmpHIBtn = child2.GetChild(3).GetComponent<UIHIBtn>();
		this.tmpHIBtn.gameObject.AddComponent<IgnoreRaycast>();
		this.GUIM.InitianHeroItemImg(this.tmpHIBtn.transform, eHeroOrItem.Hero, 1, 11, 0, 0, false, false, true, false);
		this.tmpText[0] = child2.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.tmpText[0].font = this.TTFont;
		this.tmpText[0].text = this.DM.mStringTable.GetStringByID(6048u);
		UIButton component = child2.GetChild(5).GetComponent<UIButton>();
		component.m_BtnID1 = 1;
		component.m_Handler = this;
		component.SoundIndex = 64;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		child2.GetChild(5).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
		component = child2.GetChild(6).GetComponent<UIButton>();
		component.m_BtnID1 = 2;
		component.m_Handler = this;
		component.SoundIndex = 64;
		UIButtonHint uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		this.tmpText[1] = child2.GetChild(7).GetComponent<UIText>();
		this.tmpText[1].font = this.TTFont;
		this.tmpText[2] = child2.GetChild(8).GetComponent<UIText>();
		this.tmpText[2].font = this.TTFont;
		this.tmpText[2].text = this.DM.mStringTable.GetStringByID(9123u);
		this.tmpText[3] = child2.GetChild(9).GetComponent<UIText>();
		this.tmpText[3].font = this.TTFont;
		this.tmpText[3].text = this.DM.mStringTable.GetStringByID(9124u);
		this.tmpText[4] = child2.GetChild(10).GetComponent<UIText>();
		this.tmpText[4].font = this.TTFont;
		this.tmpText[5] = child2.GetChild(11).GetComponent<UIText>();
		this.tmpText[5].font = this.TTFont;
		this.tmpText[6] = child2.GetChild(12).GetChild(0).GetComponent<UIText>();
		this.tmpText[6].font = this.TTFont;
		this.tmplist.Clear();
		for (int j = 0; j < this.AM.m_ArenaReportData.Count; j++)
		{
			this.tmplist.Add(95f);
		}
		this.m_ScrollPanel.IntiScrollPanel(509f, 0f, 0f, this.tmplist, 7, this);
		child = this.GameT.GetChild(2);
		this.Img_NoReplay = child.GetComponent<Image>();
		child2 = child.GetChild(0);
		this.text_NoReplay = child2.GetComponent<UIText>();
		this.text_NoReplay.font = this.TTFont;
		this.text_NoReplay.text = this.DM.mStringTable.GetStringByID(9156u);
		if (this.AM.m_ArenaReportData.Count > 0)
		{
			this.m_ScrollPanel.gameObject.SetActive(true);
			this.Img_NoReplay.gameObject.SetActive(false);
		}
		else
		{
			this.m_ScrollPanel.gameObject.SetActive(false);
			this.Img_NoReplay.gameObject.SetActive(true);
		}
		child = this.GameT.GetChild(3);
		Image component2 = child.GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = material;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component2.enabled = false;
		}
		child = this.GameT.GetChild(3).GetChild(0);
		this.btn_EXIT = child.GetComponent<UIButton>();
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = material;
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x060010DC RID: 4316 RVA: 0x001E1710 File Offset: 0x001DF910
	public override void OnClose()
	{
		for (int i = 0; i < 7; i++)
		{
			if (this.Cstr_Rank[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Rank[i]);
			}
			if (this.Cstr_Name[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Name[i]);
			}
		}
		ArenaReportDataType value = default(ArenaReportDataType);
		for (int j = 0; j < this.AM.m_ArenaReportData.Count; j++)
		{
			if ((this.AM.m_ArenaReportData[j].Flag >> 2 & 1) == 0)
			{
				value = this.AM.m_ArenaReportData[j];
				value.Flag += 4;
				this.AM.m_ArenaReportData[j] = value;
			}
		}
	}

	// Token: 0x060010DD RID: 4317 RVA: 0x001E17F0 File Offset: 0x001DF9F0
	public void OnButtonClick(UIButton sender)
	{
		GUIArena_Replay btnID = (GUIArena_Replay)sender.m_BtnID1;
		if (btnID != GUIArena_Replay.btn_EXIT)
		{
			if (btnID == GUIArena_Replay.btn_Replay)
			{
				Transform parent = sender.gameObject.transform.parent;
				int btnID2 = parent.GetComponent<ScrollPanelItem>().m_BtnID1;
				if (this.AM.SetReportIDToPlayingData(btnID2))
				{
					if (!WarManager.CheckVersion(this.AM.ArenaPlayingData.SimulatorVersion, this.AM.ArenaPlayingData.SimulatorPatchNo, true))
					{
						return;
					}
					int num = btnID2;
					if (this.AM.m_ArenaReportData.Count > num)
					{
						num = this.AM.m_ArenaReportData.Count - 1 - num;
					}
					ushort[] array = new ushort[10];
					for (int i = 0; i < 5; i++)
					{
						array[i] = this.AM.m_ArenaReportData[num].MyHeroData[i].ID;
					}
					for (int j = 0; j < 5; j++)
					{
						array[j + 5] = this.AM.m_ArenaReportData[num].EnemyHeroData[j].ID;
					}
					if (!this.DM.CheckHeroBattleResourceReady(HeroFightType.HeorArena, array))
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(8350u), 255, true);
						return;
					}
					GUIManager instance = GUIManager.Instance;
					instance.bClearWindowStack = false;
					BattleController.BattleMode = EBattleMode.PVP_Replay;
					instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MonsterBattle);
				}
			}
		}
		else if (this.door != null)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x060010DE RID: 4318 RVA: 0x001E19B0 File Offset: 0x001DFBB0
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		this.ItemT = item.GetComponent<Transform>();
		if (this.tmpItem[panelObjectIdx] == null)
		{
			this.Img_ItmeRank[panelObjectIdx] = this.ItemT.GetChild(1).GetComponent<Image>();
			this.tmpItemHIBtn[panelObjectIdx] = this.ItemT.GetChild(3).GetComponent<UIHIBtn>();
			this.Img_ItmeNew[panelObjectIdx] = this.ItemT.GetChild(4).GetComponent<Image>();
			this.tmpItemBtn[panelObjectIdx] = this.ItemT.GetChild(5).GetComponent<UIButton>();
			this.tmpItemBtn[panelObjectIdx].m_Handler = this;
			this.tmpItemHintBtn[panelObjectIdx] = this.ItemT.GetChild(6).GetComponent<UIButton>();
			this.tmpItemHintBtn[panelObjectIdx].m_Handler = this;
			this.tmpItemHintBtn[panelObjectIdx].m_BtnID2 = panelObjectIdx;
			this.text_ItmeRank[panelObjectIdx] = this.ItemT.GetChild(7).GetComponent<UIText>();
			this.text_ItmeResult_W[panelObjectIdx] = this.ItemT.GetChild(8).GetComponent<UIText>();
			this.text_ItmeResult_L[panelObjectIdx] = this.ItemT.GetChild(9).GetComponent<UIText>();
			this.text_ItmeTime[panelObjectIdx] = this.ItemT.GetChild(10).GetComponent<UIText>();
			this.text_ItmeName[panelObjectIdx] = this.ItemT.GetChild(11).GetComponent<UIText>();
			this.Img_ItmeHint[panelObjectIdx] = this.ItemT.GetChild(12).GetComponent<Image>();
			this.text_ItmeHint[panelObjectIdx] = this.ItemT.GetChild(12).GetChild(0).GetComponent<UIText>();
			UIButtonHint component = this.ItemT.GetChild(6).GetComponent<UIButtonHint>();
			component.m_Handler = this;
			component.ControlFadeOut = this.Img_ItmeHint[panelObjectIdx].gameObject;
		}
		if (dataIdx < this.AM.m_ArenaReportData.Count)
		{
			int index = this.AM.m_ArenaReportData.Count - 1 - dataIdx;
			if ((this.AM.m_ArenaReportData[index].Flag >> 1 & 1) == 1 && (this.AM.m_ArenaReportData[index].Flag & 1) == 0)
			{
				this.Img_ItmeRank[panelObjectIdx].gameObject.SetActive(false);
				this.text_ItmeRank[panelObjectIdx].gameObject.SetActive(false);
			}
			else
			{
				if (this.AM.m_ArenaReportData[index].ChangePlace > 0u)
				{
					this.Img_ItmeRank[panelObjectIdx].gameObject.SetActive(true);
				}
				else
				{
					this.Img_ItmeRank[panelObjectIdx].gameObject.SetActive(false);
				}
				this.text_ItmeRank[panelObjectIdx].gameObject.SetActive(true);
			}
			if ((this.AM.m_ArenaReportData[index].Flag & 1) == 1)
			{
				this.Img_ItmeRank[panelObjectIdx].sprite = this.SArray.m_Sprites[0];
				this.text_ItmeResult_W[panelObjectIdx].gameObject.SetActive(true);
				this.text_ItmeResult_L[panelObjectIdx].gameObject.SetActive(false);
			}
			else
			{
				this.text_ItmeResult_W[panelObjectIdx].gameObject.SetActive(false);
				this.text_ItmeResult_L[panelObjectIdx].gameObject.SetActive(true);
				if ((this.AM.m_ArenaReportData[index].Flag >> 1 & 1) == 0)
				{
					this.Img_ItmeRank[panelObjectIdx].sprite = this.SArray.m_Sprites[1];
				}
			}
			if ((this.AM.m_ArenaReportData[index].Flag >> 1 & 1) == 1)
			{
				this.tmpItemHintBtn[panelObjectIdx].image.sprite = this.SArray.m_Sprites[2];
				this.text_ItmeHint[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(9166u);
			}
			else
			{
				this.tmpItemHintBtn[panelObjectIdx].image.sprite = this.SArray.m_Sprites[3];
				this.text_ItmeHint[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(9165u);
			}
			this.text_ItmeHint[panelObjectIdx].SetAllDirty();
			this.text_ItmeHint[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_ItmeHint[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_ItmeHint[panelObjectIdx].preferredWidth > this.text_ItmeHint[panelObjectIdx].rectTransform.sizeDelta.x)
			{
				this.text_ItmeHint[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.text_ItmeHint[panelObjectIdx].preferredWidth, this.text_ItmeHint[panelObjectIdx].rectTransform.sizeDelta.y);
				this.Img_ItmeHint[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.text_ItmeHint[panelObjectIdx].preferredWidth + 10f, this.Img_ItmeHint[panelObjectIdx].rectTransform.sizeDelta.y);
			}
			if ((this.AM.m_ArenaReportData[index].Flag >> 2 & 1) == 0)
			{
				this.Img_ItmeNew[panelObjectIdx].gameObject.SetActive(true);
			}
			else
			{
				this.Img_ItmeNew[panelObjectIdx].gameObject.SetActive(false);
			}
			this.Cstr_Rank[panelObjectIdx].ClearString();
			if (this.AM.m_ArenaReportData[index].ChangePlace > 0u)
			{
				this.Cstr_Rank[panelObjectIdx].IntToFormat((long)((ulong)this.AM.m_ArenaReportData[index].ChangePlace), 1, true);
				this.Cstr_Rank[panelObjectIdx].AppendFormat("{0}");
			}
			this.text_ItmeRank[panelObjectIdx].text = this.Cstr_Rank[panelObjectIdx].ToString();
			this.text_ItmeRank[panelObjectIdx].SetAllDirty();
			this.text_ItmeRank[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.GUIM.ChangeHeroItemImg(this.tmpItemHIBtn[panelObjectIdx].transform, eHeroOrItem.Hero, this.AM.m_ArenaReportData[index].EnemyHead, 11, 0, 0);
			this.Cstr_Name[panelObjectIdx].ClearString();
			CString cstring = StringManager.Instance.StaticString1024();
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring2.ClearString();
			cstring.Append(this.AM.m_ArenaReportData[index].EnemyName);
			if (this.AM.m_ArenaReportData[index].EnemyAllianceTag != string.Empty)
			{
				cstring2.Append(this.AM.m_ArenaReportData[index].EnemyAllianceTag);
				GameConstants.FormatRoleName(this.Cstr_Name[panelObjectIdx], cstring, cstring2, null, 0, 0, null, null, null, null);
			}
			else
			{
				GameConstants.FormatRoleName(this.Cstr_Name[panelObjectIdx], cstring, null, null, 0, 0, null, null, null, null);
			}
			this.text_ItmeName[panelObjectIdx].text = this.Cstr_Name[panelObjectIdx].ToString();
			this.text_ItmeName[panelObjectIdx].SetAllDirty();
			this.text_ItmeName[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_ItmeTime[panelObjectIdx].text = GameConstants.GetDateTime(this.AM.m_ArenaReportData[index].Time).ToString("MM/dd/yy HH:mm:ss");
			this.text_ItmeTime[panelObjectIdx].SetAllDirty();
			this.text_ItmeTime[panelObjectIdx].cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x060010DF RID: 4319 RVA: 0x001E2140 File Offset: 0x001E0340
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x060010E0 RID: 4320 RVA: 0x001E2144 File Offset: 0x001E0344
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton component = sender.transform.GetComponent<UIButton>();
		GUIArena_Replay btnID = (GUIArena_Replay)component.m_BtnID1;
		if (btnID == GUIArena_Replay.btn_Hint)
		{
			if (this.Img_ItmeHint[component.m_BtnID2] != null)
			{
				this.Img_ItmeHint[component.m_BtnID2].gameObject.SetActive(true);
			}
		}
	}

	// Token: 0x060010E1 RID: 4321 RVA: 0x001E21A8 File Offset: 0x001E03A8
	public void OnButtonUp(UIButtonHint sender)
	{
		UIButton component = sender.transform.GetComponent<UIButton>();
		GUIArena_Replay btnID = (GUIArena_Replay)component.m_BtnID1;
		if (btnID == GUIArena_Replay.btn_Hint)
		{
			if (this.Img_ItmeHint[component.m_BtnID2] != null)
			{
				this.Img_ItmeHint[component.m_BtnID2].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x060010E2 RID: 4322 RVA: 0x001E220C File Offset: 0x001E040C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
		}
		else
		{
			this.AM.SendArena_Report();
		}
	}

	// Token: 0x060010E3 RID: 4323 RVA: 0x001E224C File Offset: 0x001E044C
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_NoReplay != null && this.text_NoReplay.enabled)
		{
			this.text_NoReplay.enabled = false;
			this.text_NoReplay.enabled = true;
		}
		if (this.tmpHIBtn != null && this.tmpHIBtn.enabled)
		{
			this.tmpHIBtn.Refresh_FontTexture();
		}
		for (int i = 0; i < 7; i++)
		{
			if (this.tmpText[i] != null && this.tmpText[i].enabled)
			{
				this.tmpText[i].enabled = false;
				this.tmpText[i].enabled = true;
			}
		}
		for (int j = 0; j < 7; j++)
		{
			if (this.text_ItmeRank[j] != null && this.text_ItmeRank[j].enabled)
			{
				this.text_ItmeRank[j].enabled = false;
				this.text_ItmeRank[j].enabled = true;
			}
			if (this.text_ItmeResult_W[j] != null && this.text_ItmeResult_W[j].enabled)
			{
				this.text_ItmeResult_W[j].enabled = false;
				this.text_ItmeResult_W[j].enabled = true;
			}
			if (this.text_ItmeResult_L[j] != null && this.text_ItmeResult_L[j].enabled)
			{
				this.text_ItmeResult_L[j].enabled = false;
				this.text_ItmeResult_L[j].enabled = true;
			}
			if (this.text_ItmeTime[j] != null && this.text_ItmeTime[j].enabled)
			{
				this.text_ItmeTime[j].enabled = false;
				this.text_ItmeTime[j].enabled = true;
			}
			if (this.text_ItmeName[j] != null && this.text_ItmeName[j].enabled)
			{
				this.text_ItmeName[j].enabled = false;
				this.text_ItmeName[j].enabled = true;
			}
			if (this.text_ItmeHint[j] != null && this.text_ItmeHint[j].enabled)
			{
				this.text_ItmeHint[j].enabled = false;
				this.text_ItmeHint[j].enabled = true;
			}
			if (this.tmpItemHIBtn[j] != null && this.tmpItemHIBtn[j].enabled)
			{
				this.tmpItemHIBtn[j].Refresh_FontTexture();
			}
		}
	}

	// Token: 0x060010E4 RID: 4324 RVA: 0x001E2514 File Offset: 0x001E0714
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 1)
		{
			if (arg1 == 2)
			{
				this.AM.SendArena_Report();
			}
		}
		else
		{
			this.tmplist.Clear();
			for (int i = 0; i < this.AM.m_ArenaReportData.Count; i++)
			{
				this.tmplist.Add(95f);
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			if (this.AM.m_ArenaReportData.Count == 0)
			{
				this.m_ScrollPanel.gameObject.SetActive(false);
				this.Img_NoReplay.gameObject.SetActive(true);
			}
			else if (!this.m_ScrollPanel.gameObject.activeSelf)
			{
				this.m_ScrollPanel.gameObject.SetActive(true);
				this.Img_NoReplay.gameObject.SetActive(false);
			}
			Array.Clear(this.AM.RepoetUnRead, 0, this.AM.RepoetUnRead.Length);
			this.AM.RepoetUnReadCount = 0;
		}
	}

	// Token: 0x060010E5 RID: 4325 RVA: 0x001E2638 File Offset: 0x001E0838
	private void Start()
	{
	}

	// Token: 0x060010E6 RID: 4326 RVA: 0x001E263C File Offset: 0x001E083C
	private void Update()
	{
		if (this.bOpen)
		{
			this.AM.SendArena_Report();
			this.bOpen = false;
		}
	}

	// Token: 0x040036F5 RID: 14069
	private DataManager DM;

	// Token: 0x040036F6 RID: 14070
	private GUIManager GUIM;

	// Token: 0x040036F7 RID: 14071
	private ArenaManager AM;

	// Token: 0x040036F8 RID: 14072
	private Transform GameT;

	// Token: 0x040036F9 RID: 14073
	private Transform ItemT;

	// Token: 0x040036FA RID: 14074
	private Door door;

	// Token: 0x040036FB RID: 14075
	private Font TTFont;

	// Token: 0x040036FC RID: 14076
	private UISpritesArray SArray;

	// Token: 0x040036FD RID: 14077
	private UIButton btn_EXIT;

	// Token: 0x040036FE RID: 14078
	private UIButton[] tmpItemBtn = new UIButton[7];

	// Token: 0x040036FF RID: 14079
	private UIButton[] tmpItemHintBtn = new UIButton[7];

	// Token: 0x04003700 RID: 14080
	private UIHIBtn tmpHIBtn;

	// Token: 0x04003701 RID: 14081
	private UIHIBtn[] tmpItemHIBtn = new UIHIBtn[7];

	// Token: 0x04003702 RID: 14082
	private Image Img_NoReplay;

	// Token: 0x04003703 RID: 14083
	private Image[] Img_ItmeRank = new Image[7];

	// Token: 0x04003704 RID: 14084
	private Image[] Img_ItmeNew = new Image[7];

	// Token: 0x04003705 RID: 14085
	private Image[] Img_ItmeHint = new Image[7];

	// Token: 0x04003706 RID: 14086
	private UIText text_Title;

	// Token: 0x04003707 RID: 14087
	private UIText text_NoReplay;

	// Token: 0x04003708 RID: 14088
	private UIText[] tmpText = new UIText[7];

	// Token: 0x04003709 RID: 14089
	private UIText[] text_ItmeRank = new UIText[7];

	// Token: 0x0400370A RID: 14090
	private UIText[] text_ItmeResult_W = new UIText[7];

	// Token: 0x0400370B RID: 14091
	private UIText[] text_ItmeResult_L = new UIText[7];

	// Token: 0x0400370C RID: 14092
	private UIText[] text_ItmeTime = new UIText[7];

	// Token: 0x0400370D RID: 14093
	private UIText[] text_ItmeName = new UIText[7];

	// Token: 0x0400370E RID: 14094
	private UIText[] text_ItmeHint = new UIText[7];

	// Token: 0x0400370F RID: 14095
	private CString[] Cstr_Rank = new CString[7];

	// Token: 0x04003710 RID: 14096
	private CString[] Cstr_Name = new CString[7];

	// Token: 0x04003711 RID: 14097
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04003712 RID: 14098
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[7];

	// Token: 0x04003713 RID: 14099
	private List<float> tmplist = new List<float>();

	// Token: 0x04003714 RID: 14100
	private bool bOpen = true;
}
