using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000556 RID: 1366
public class UIForge : GUIWindow, IBuildingWindowType, IUpDateScrollPanel, IUIButtonClickHandler, IUTimeBarOnTimer
{
	// Token: 0x06001B45 RID: 6981 RVA: 0x00305FF4 File Offset: 0x003041F4
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
		{
			this.BG_T.gameObject.SetActive(true);
			this.BG1_T.gameObject.SetActive(true);
			this.m_ScrollPanel.gameObject.SetActive(true);
			if (this.Forging)
			{
				this.timeBar.gameObject.SetActive(true);
			}
			else
			{
				this.timeBar.gameObject.SetActive(false);
			}
		}
		else
		{
			this.m_ScrollRect.StopMovement();
			this.BG_T.gameObject.SetActive(false);
			this.BG1_T.gameObject.SetActive(false);
			this.m_ScrollPanel.gameObject.SetActive(false);
			if (this.Forging)
			{
				this.timeBar.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001B46 RID: 6982 RVA: 0x003060DC File Offset: 0x003042DC
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.B_ID = arg1;
		for (int i = 0; i < 3; i++)
		{
			this.m_ItemName[i] = this.DM.mStringTable.GetStringByID((uint)(7402 + i));
		}
		this.GameT = base.gameObject.transform;
		this.BG_T = this.GameT.GetChild(0);
		this.timeBar = this.BG_T.GetChild(0).GetComponent<UITimeBar>();
		if (this.DM.queueBarData[18].bActive)
		{
			this.begin = this.DM.queueBarData[18].StartTime;
			this.target = this.begin + (long)((ulong)this.DM.queueBarData[18].TotalTime);
			this.GUIM.CreateTimerBar(this.timeBar, this.begin, this.target, 0L, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(261u), this.DM.mStringTable.GetStringByID(261u));
			this.timeBar.gameObject.SetActive(true);
			this.Forging = true;
		}
		else
		{
			this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
			this.timeBar.gameObject.SetActive(false);
		}
		this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
		this.text_timeBar[0] = this.BG_T.GetChild(0).GetChild(2).GetComponent<UIText>();
		this.text_timeBar[1] = this.BG_T.GetChild(0).GetChild(3).GetComponent<UIText>();
		this.timeBar.m_Handler = this;
		this.timeBar.m_TimeBarID = 1;
		this.btn_Magnifier = this.BG_T.GetChild(1).GetComponent<UIButton>();
		this.btn_Magnifier.m_Handler = this;
		this.btn_Magnifier.m_BtnID1 = 1;
		this.btn_Magnifier.m_EffectType = e_EffectType.e_Scale;
		this.btn_Magnifier.transition = Selectable.Transition.None;
		this.btn_Magnifier.gameObject.SetActive(this.DM.RoleAttr.LordEquipEventData.ItemID != 0);
		this.text_tmpStr[0] = this.BG_T.GetChild(2).GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		if (this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level < 17)
		{
			this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7401u);
		}
		else
		{
			this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7496u);
		}
		this.m_ScrollPanel = this.GameT.GetChild(1).GetComponent<ScrollPanel>();
		this.Item_T = this.GameT.GetChild(2);
		for (int j = 0; j < 3; j++)
		{
			UIButton component = this.Item_T.GetChild(j).GetComponent<UIButton>();
			component.m_Handler = this;
			component.m_BtnID1 = 2 + j;
			component.SoundIndex = 64;
			component.m_EffectType = e_EffectType.e_Scale;
			component.transition = Selectable.Transition.None;
			this.text_tmpStr[1 + j] = this.Item_T.GetChild(j).GetChild(0).GetChild(0).GetComponent<UIText>();
			this.text_tmpStr[1 + j].font = this.TTFont;
			this.text_tmpStr[1 + j].text = this.m_ItemName[j];
		}
		for (int k = 0; k < 1; k++)
		{
			this.tmplist.Add(227f);
		}
		this.m_ScrollPanel.IntiScrollPanel(285f, 0f, 0f, this.tmplist, 1, this);
		this.m_ScrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
		this.BG1_T = this.GameT.GetChild(3);
		if (this.DM.mLordEquip == null)
		{
			this.DM.mLordEquip = LordEquipData.Instance();
		}
		if (this.DM.mLordEquip.isEquipEvoReady)
		{
			this.Img_isEquipEvoReady.gameObject.SetActive(true);
		}
		else
		{
			this.Img_isEquipEvoReady.gameObject.SetActive(false);
		}
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		NewbieManager.CheckTeach(ETeachKind.SMITH, null, true);
	}

	// Token: 0x06001B47 RID: 6983 RVA: 0x00306598 File Offset: 0x00304798
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 1:
			UIAnvil.SetOpen(eUI_Anvil_OpenKind.NowForging, 0, 0);
			break;
		case 2:
			this.door.OpenMenu(EGUIWindow.UI_Forge_Item, 0, 0, false);
			break;
		case 3:
			this.door.OpenMenu(EGUIWindow.UI_Forge_ActivityItem, 1, 0, false);
			break;
		case 4:
			UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
			this.door.OpenMenu(EGUIWindow.UI_LordEquip, 1, 0, false);
			break;
		}
	}

	// Token: 0x06001B48 RID: 6984 RVA: 0x00306620 File Offset: 0x00304820
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.tmpItem[panelObjectIdx] == null)
		{
			this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			for (int i = 0; i < 3; i++)
			{
				this.btn_Itme[i] = this.tmpItem[panelObjectIdx].transform.GetChild(i).GetComponent<UIButton>();
				this.btn_Itme[i].m_Handler = this;
				this.btn_Itme[i].m_BtnID1 = 2 + i;
				this.text_tmpItme[i] = this.tmpItem[panelObjectIdx].transform.GetChild(i).GetComponent<UIText>();
				if (i == 2)
				{
					this.Img_isEquipEvoReady = this.tmpItem[panelObjectIdx].transform.GetChild(i).GetChild(1).GetComponent<Image>();
				}
			}
		}
	}

	// Token: 0x06001B49 RID: 6985 RVA: 0x003066EC File Offset: 0x003048EC
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001B4A RID: 6986 RVA: 0x003066F0 File Offset: 0x003048F0
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		if (this.timeBar != null)
		{
			this.GUIM.RemoverTimeBaarToList(this.timeBar);
		}
	}

	// Token: 0x06001B4B RID: 6987 RVA: 0x0030673C File Offset: 0x0030493C
	public void OnTimer(UITimeBar sender)
	{
	}

	// Token: 0x06001B4C RID: 6988 RVA: 0x00306740 File Offset: 0x00304940
	public void OnNotify(UITimeBar sender)
	{
	}

	// Token: 0x06001B4D RID: 6989 RVA: 0x00306744 File Offset: 0x00304944
	public void Onfunc(UITimeBar sender)
	{
		if (sender.m_TimerSpriteType == eTimerSpriteType.Speed)
		{
			this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 18, false);
		}
	}

	// Token: 0x06001B4E RID: 6990 RVA: 0x00306764 File Offset: 0x00304964
	public void OnCancel(UITimeBar sender)
	{
		this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(7514u), this.DM.mStringTable.GetStringByID(7513u), 1, 0, this.DM.mStringTable.GetStringByID(7426u), this.DM.mStringTable.GetStringByID(188u));
	}

	// Token: 0x06001B4F RID: 6991 RVA: 0x003067D4 File Offset: 0x003049D4
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 == 1)
			{
				LordEquipData.CancelCombine();
			}
		}
	}

	// Token: 0x06001B50 RID: 6992 RVA: 0x00306800 File Offset: 0x00304A00
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_BuildBase)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
					if (this.baseBuild != null)
					{
						this.baseBuild.Refresh_FontTexture();
					}
					if (this.timeBar != null && this.timeBar.enabled)
					{
						this.timeBar.Refresh_FontTexture();
					}
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
	}

	// Token: 0x06001B51 RID: 6993 RVA: 0x003068C4 File Offset: 0x00304AC4
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < 2; i++)
		{
			if (this.text_timeBar[i] != null && this.text_timeBar[i].enabled)
			{
				this.text_timeBar[i].enabled = false;
				this.text_timeBar[i].enabled = true;
			}
		}
		for (int j = 0; j < 3; j++)
		{
			if (this.text_tmpItme[j] != null && this.text_tmpItme[j].enabled)
			{
				this.text_tmpItme[j].enabled = false;
				this.text_tmpItme[j].enabled = true;
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (this.text_tmpStr[k] != null && this.text_tmpStr[k].enabled)
			{
				this.text_tmpStr[k].enabled = false;
				this.text_tmpStr[k].enabled = true;
			}
		}
	}

	// Token: 0x06001B52 RID: 6994 RVA: 0x003069CC File Offset: 0x00304BCC
	public override void UpdateUI(int arg1, int arg2)
	{
		if (this.baseBuild == null)
		{
			return;
		}
		if (arg1 != 0)
		{
			if (arg1 == 1)
			{
				if (this.DM.queueBarData[18].bActive)
				{
					long startTime = this.DM.queueBarData[18].StartTime;
					long num = startTime + (long)((ulong)this.DM.queueBarData[18].TotalTime);
					this.GUIM.SetTimerBar(this.timeBar, startTime, num, 0L, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(261u), this.DM.mStringTable.GetStringByID(261u));
					this.timeBar.gameObject.SetActive(true);
				}
				else
				{
					this.GUIM.RemoverTimeBaarToList(this.timeBar);
					this.timeBar.gameObject.SetActive(false);
				}
				this.btn_Magnifier.gameObject.SetActive(this.DM.RoleAttr.LordEquipEventData.ItemID != 0);
			}
		}
		else if (this.DM.mLordEquip.isEquipEvoReady)
		{
			this.Img_isEquipEvoReady.gameObject.SetActive(true);
		}
		else
		{
			this.Img_isEquipEvoReady.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001B53 RID: 6995 RVA: 0x00306B38 File Offset: 0x00304D38
	private void Start()
	{
		this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		byte level = this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level;
		this.baseBuild.InitBuildingWindow(15, (ushort)this.B_ID, 2, level);
		this.baseBuild.baseTransform.SetAsFirstSibling();
	}

	// Token: 0x06001B54 RID: 6996 RVA: 0x00306BB0 File Offset: 0x00304DB0
	private void Update()
	{
	}

	// Token: 0x0400526B RID: 21099
	private DataManager DM;

	// Token: 0x0400526C RID: 21100
	private GUIManager GUIM;

	// Token: 0x0400526D RID: 21101
	private Transform GameT;

	// Token: 0x0400526E RID: 21102
	private Transform Item_T;

	// Token: 0x0400526F RID: 21103
	private Transform BG_T;

	// Token: 0x04005270 RID: 21104
	private Transform BG1_T;

	// Token: 0x04005271 RID: 21105
	private UIButton btn_Magnifier;

	// Token: 0x04005272 RID: 21106
	private UIButton[] btn_Itme = new UIButton[3];

	// Token: 0x04005273 RID: 21107
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04005274 RID: 21108
	private CScrollRect m_ScrollRect;

	// Token: 0x04005275 RID: 21109
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[3];

	// Token: 0x04005276 RID: 21110
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x04005277 RID: 21111
	private BuildingWindow baseBuild;

	// Token: 0x04005278 RID: 21112
	private UITimeBar timeBar;

	// Token: 0x04005279 RID: 21113
	private Door door;

	// Token: 0x0400527A RID: 21114
	private UIText[] text_tmpStr = new UIText[4];

	// Token: 0x0400527B RID: 21115
	private UIText[] text_tmpItme = new UIText[3];

	// Token: 0x0400527C RID: 21116
	private UIText[] text_timeBar = new UIText[2];

	// Token: 0x0400527D RID: 21117
	private Image Img_isEquipEvoReady;

	// Token: 0x0400527E RID: 21118
	private int B_ID;

	// Token: 0x0400527F RID: 21119
	private long begin;

	// Token: 0x04005280 RID: 21120
	private long target;

	// Token: 0x04005281 RID: 21121
	private bool Forging;

	// Token: 0x04005282 RID: 21122
	private List<float> tmplist = new List<float>();

	// Token: 0x04005283 RID: 21123
	private string[] m_ItemName = new string[3];
}
