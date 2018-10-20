using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x02000298 RID: 664
public class UIAllianceWarRegister : GUIWindow, IActivityWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06000D32 RID: 3378 RVA: 0x00139AEC File Offset: 0x00137CEC
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager instance = GUIManager.Instance;
		DataManager instance2 = DataManager.Instance;
		Font ttffont = instance.GetTTFFont();
		instance.UpdateUI(EGUIWindow.Door, 1, 2);
		this.TitleText[0] = base.transform.GetChild(0).GetChild(1).GetComponent<UIText>();
		this.TitleText[1] = base.transform.GetChild(0).GetChild(2).GetComponent<UIText>();
		Text text = this.TitleText[0];
		Font font = ttffont;
		this.TitleText[1].font = font;
		text.font = font;
		this.TitleText[0].text = instance2.mStringTable.GetStringByID(17012u);
		this.TitleText[1].text = instance2.mStringTable.GetStringByID(17005u);
		this.GiftInCreaseObj = base.transform.GetChild(0).GetChild(3).GetChild(0).gameObject;
		RectTransform component = base.transform.GetChild(0).GetChild(3).GetComponent<RectTransform>();
		component.pivot = new Vector2(0.5f, 0.5f);
		component.anchoredPosition = new Vector2(786.5f, -26f);
		this.RankBtn = base.transform.GetChild(0).GetChild(3).GetComponent<UIButton>();
		this.RankBtn.m_Handler = this;
		this.RankBtn.m_BtnID1 = 2;
		this.RankBtnScale = this.RankBtn.transform.GetComponent<uButtonScale>();
		this.RankBtn.gameObject.AddComponent<ArabicItemTextureRot>();
		this.ScrollMsgText = base.transform.GetChild(1).GetChild(0).GetChild(3).GetComponent<UIText>();
		this.ScrollMsgText.font = ttffont;
		this.ScrollMsgText.text = instance2.mStringTable.GetStringByID(17014u);
		for (int i = 0; i < 3; i++)
		{
			base.transform.GetChild(1).GetChild(3).GetChild(i).GetChild(0).GetComponent<UIText>().font = ttffont;
			this.ColumnText[i] = base.transform.GetChild(1).GetChild(0).GetChild(i).GetChild(0).GetComponent<UIText>();
			this.ColumnText[i].font = ttffont;
		}
		this.ColumnText[0].text = instance2.mStringTable.GetStringByID(17013u);
		this.ColumnText[1].text = instance2.mStringTable.GetStringByID(4717u);
		this.ColumnText[2].text = instance2.mStringTable.GetStringByID(1560u);
		this.BackupStr = StringManager.Instance.SpawnString(100);
		this.BackupText = base.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<UIText>();
		this.BackupText.font = ttffont;
		this.BackupItemRect = base.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
		this.AllyView = base.transform.GetChild(1).GetChild(1).GetComponent<ScrollPanel>();
		this.EmblemObj = base.transform.GetChild(3).GetChild(0).gameObject;
		this.AllyNameStr = StringManager.Instance.SpawnString(30);
		this.ElbemTrans = base.transform.GetChild(3).GetChild(0).GetChild(0);
		this.AllianceElbem = DataManager.Instance.RoleAlliance.Emblem;
		instance.InitBadgeTotem(this.ElbemTrans, this.AllianceElbem);
		this.AllyNameText = base.transform.GetChild(3).GetChild(0).GetChild(1).GetComponent<UIText>();
		this.AllyNameText.font = ttffont;
		this.AllyNameStr.StringToFormat(DataManager.Instance.RoleAlliance.Tag);
		this.AllyNameStr.StringToFormat(DataManager.Instance.RoleAlliance.Name);
		this.AllyNameStr.AppendFormat("[{0}]{1}");
		this.AllyNameText.text = this.AllyNameStr.ToString();
		this.RankStr = StringManager.Instance.SpawnString(30);
		this.RankText = base.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.RankText.font = ttffont;
		this.RankObj = this.RankText.gameObject;
		this.MessageText = base.transform.GetChild(3).GetChild(1).GetChild(1).GetComponent<UIText>();
		this.MessageText.font = ttffont;
		this.MessageRect = this.MessageText.rectTransform;
		this.RegisterText = base.transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<UIText>();
		this.RegisterText.font = ttffont;
		this.RegisterBtn = base.transform.GetChild(3).GetChild(2).GetComponent<UIButton>();
		this.RegisterBtn.m_Handler = this;
		this.RegisterBtn.m_BtnID1 = 0;
		if (ActivityManager.Instance.AW_PrizeGroupID > 0)
		{
			this.GiftInCreaseObj.SetActive(true);
		}
		this.ArmyHintObj = base.transform.GetChild(3).GetChild(3).gameObject;
		UIButtonHint uibuttonHint = this.ArmyHintObj.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.Parm1 = 17078;
		uibuttonHint.Parm2 = 3;
		uibuttonHint.ScrollID = 2;
		ActivityWindow activityWindow = base.transform.gameObject.AddComponent<ActivityWindow>();
		activityWindow.Initial(e_ActivityType.SignUp, this);
		if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
		{
			this.bColse = 1;
		}
		else if (ActivityManager.Instance.AW_State > EAllianceWarState.EAWS_Prepare)
		{
			if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_Run)
			{
				if (instance2.RoleAlliance.Id > 0u && ActivityManager.Instance.AW_NowAllianceEnterWar > 0)
				{
					this.bColse = 2;
				}
			}
			else
			{
				this.bColse = 2;
			}
		}
		if (this.bColse > 0)
		{
			return;
		}
		if (DataManager.Instance.RoleAlliance.Id > 0u)
		{
			this.AWD.SendAllianceWarList();
		}
		else
		{
			this.UpdateMessage();
			this.SetNonAllianceState();
		}
	}

	// Token: 0x06000D33 RID: 3379 RVA: 0x0013A138 File Offset: 0x00138338
	private bool InitialScroll()
	{
		if (this.RegisterItem != null || this.RegisterDataCount == 0)
		{
			return false;
		}
		this.ScrollMsgText.gameObject.SetActive(false);
		this.RegisterItem = new UIAllianceWarRegister._RegisterItem[this.PagepeItem];
		for (byte b = 0; b < this.RegisterDataCount; b += 1)
		{
			if (b == this.AWD.GetRegisterMaxCount())
			{
				this.Heights.Add(90f);
			}
			else
			{
				this.Heights.Add(45f);
			}
		}
		this.AllyView.IntiScrollPanel(333f, 0f, 0f, this.Heights, this.PagepeItem, this);
		this.AllyViewContentRect = this.AllyView.transform.GetChild(0).GetComponent<RectTransform>();
		UIButtonHint.scrollRect = this.AllyView.transform.GetComponent<CScrollRect>();
		this.AllyView.gameObject.SetActive(true);
		this.UpdateEnrollPower();
		if (this.AWD.MyRank > 0)
		{
			int num = (int)this.AWD.GetRegisterMaxCount();
			if (num > (int)this.AWD.GetRegisterCount())
			{
				num = (int)this.AWD.GetRegisterCount();
			}
			int num2 = num - (int)this.AWD.MyRank;
			if (num2 >= 5)
			{
				this.AllyView.GoTo(num2 - 2);
			}
			else if (num2 < 0 && this.AWD.MyRank > 3)
			{
				this.AllyView.GoTo((int)(this.AWD.MyRank - 3));
			}
			this.CheckWaitItem();
		}
		return true;
	}

	// Token: 0x06000D34 RID: 3380 RVA: 0x0013A2D8 File Offset: 0x001384D8
	private void UpdateEnrollPower()
	{
		this.BackupStr.ClearString();
		this.BackupStr.IntToFormat((long)this.AWD.GetEnrollPower(), 1, true);
		this.BackupStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17015u));
		this.BackupText.text = this.BackupStr.ToString();
		this.BackupText.SetAllDirty();
		this.BackupText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000D35 RID: 3381 RVA: 0x0013A35C File Offset: 0x0013855C
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.bColse > 0)
		{
			if (this.bColse == 2)
			{
				ActivityManager.Instance.AllianceWarSendReOpenMenu();
			}
			else
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.CloseMenu(false);
			}
			this.bColse = 0;
		}
	}

	// Token: 0x06000D36 RID: 3382 RVA: 0x0013A3B0 File Offset: 0x001385B0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Login)
		{
			if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.CloseMenu(false);
			}
			else
			{
				ActivityManager.Instance.AllianceWarSendReOpenMenu();
			}
		}
		else if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			if (this.RegisterItem != null)
			{
				for (int i = 0; i < this.RegisterItem.Length; i++)
				{
					if (!(this.RegisterItem[i].transform == null))
					{
						this.RegisterItem[i].TextureRebuilt();
					}
				}
			}
			for (int j = 0; j < 3; j++)
			{
				this.ColumnText[j].enabled = false;
				this.ColumnText[j].enabled = true;
			}
			this.TitleText[0].enabled = false;
			this.TitleText[0].enabled = true;
			this.TitleText[1].enabled = false;
			this.TitleText[1].enabled = true;
			this.AllyNameText.enabled = false;
			this.AllyNameText.enabled = true;
			this.RegisterText.enabled = false;
			this.RegisterText.enabled = true;
			this.RankText.enabled = false;
			this.RankText.enabled = true;
			this.MessageText.enabled = false;
			this.MessageText.enabled = true;
			this.BackupText.enabled = false;
			this.BackupText.enabled = true;
			this.ScrollMsgText.enabled = false;
			this.ScrollMsgText.enabled = true;
		}
		else if (networkNews == NetworkNews.Refresh)
		{
			if (this.AllianceElbem != DataManager.Instance.RoleAlliance.Emblem)
			{
				this.AllianceElbem = DataManager.Instance.RoleAlliance.Emblem;
				GUIManager.Instance.SetBadgeTotemImg(this.ElbemTrans, this.AllianceElbem);
			}
		}
		else if (networkNews == NetworkNews.Refresh_Alliance)
		{
			if (DataManager.Instance.RoleAlliance.Id > 0u)
			{
				if (meg[1] == 3 || meg[1] == 4)
				{
					this.EmblemObj.SetActive(true);
					this.AllyNameStr.ClearString();
					this.AllyNameStr.StringToFormat(DataManager.Instance.RoleAlliance.Tag);
					this.AllyNameStr.StringToFormat(DataManager.Instance.RoleAlliance.Name);
					this.AllyNameStr.AppendFormat("[{0}]{1}");
					this.AllyNameText.text = this.AllyNameStr.ToString();
					this.AllyNameText.SetAllDirty();
					this.AllyNameText.cachedTextGenerator.Invalidate();
					this.UpdateMessage();
				}
				else if (meg[1] == 7 && this.AllianceElbem != DataManager.Instance.RoleAlliance.Emblem)
				{
					this.AllianceElbem = DataManager.Instance.RoleAlliance.Emblem;
					GUIManager.Instance.SetBadgeTotemImg(this.ElbemTrans, this.AllianceElbem);
				}
			}
			else
			{
				this.UpdateMessage();
				this.SetNonAllianceState();
			}
		}
	}

	// Token: 0x06000D37 RID: 3383 RVA: 0x0013A6D4 File Offset: 0x001388D4
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.RegisterDataCount = (byte)arg2;
			if (!this.InitialScroll())
			{
				this.UpdateAllItem();
			}
			this.UpdateMessage();
			ActivityManager.Instance.UpDateAllianceWarTop();
			return;
		}
		if (arg1 == 5 && DataManager.Instance.RoleAlliance.Id > 0u && (ActivityManager.Instance.AW_State <= EAllianceWarState.EAWS_Prepare || (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_Run && this.AWD.GetRegisterCount() < this.AWD.GetRegisterMaxCount())))
		{
			this.AWD.SendAllianceWarList();
		}
		if (this.RegisterItem == null || this.RegisterDataCount == 0)
		{
			return;
		}
		switch (arg1)
		{
		case 2:
			if (this.AllyView != null)
			{
				for (int i = 0; i < this.RegisterItem.Length; i++)
				{
					this.RegisterItem[i].SetData(this.RegisterItem[i].DataIndex);
				}
			}
			this.UpdateEnrollPower();
			this.UpdateRank();
			ActivityManager.Instance.UpDateAllianceWarTop();
			break;
		case 3:
			this.UpdateMessage();
			if (DataManager.Instance.RoleAlliance.Id == 0u)
			{
				this.SetNonAllianceState();
			}
			break;
		case 4:
			GUIManager.Instance.m_Arena_Hint.ShowHint(1, this.tmpRc);
			break;
		case 6:
			if (ActivityManager.Instance.AW_NowAllianceEnterWar > 0)
			{
				ActivityManager.Instance.AllianceWarSendReOpenMenu();
			}
			break;
		}
	}

	// Token: 0x06000D38 RID: 3384 RVA: 0x0013A878 File Offset: 0x00138A78
	private void SetNonAllianceState()
	{
		if (!this.RankBtn.interactable)
		{
			return;
		}
		this.RankBtn.interactable = false;
		this.RankBtnScale.transform.GetComponent<Image>().color = Color.gray;
		this.RankBtnScale.enabled = false;
		this.AllyView.gameObject.SetActive(false);
		this.EmblemObj.SetActive(false);
		this.ScrollMsgText.gameObject.SetActive(false);
		ActivityManager.Instance.UpDateAllianceWarTop();
	}

	// Token: 0x06000D39 RID: 3385 RVA: 0x0013A900 File Offset: 0x00138B00
	private void UpdateAllItem()
	{
		if (this.RegisterDataCount == 0)
		{
			return;
		}
		int topIdx = this.AllyView.GetTopIdx();
		float y = this.AllyViewContentRect.anchoredPosition.y;
		this.Heights.Clear();
		for (byte b = 0; b < this.RegisterDataCount; b += 1)
		{
			if (b == this.AWD.GetRegisterMaxCount())
			{
				this.Heights.Add(90f);
			}
			else
			{
				this.Heights.Add(45f);
			}
		}
		this.AllyView.AddNewDataHeight(this.Heights, true, true);
		this.AllyView.GoTo(topIdx, y);
		this.UpdateEnrollPower();
		this.CheckWaitItem();
	}

	// Token: 0x06000D3A RID: 3386 RVA: 0x0013A9C0 File Offset: 0x00138BC0
	public override void OnClose()
	{
		if (this.RegisterItem != null)
		{
			for (int i = 0; i < this.RegisterItem.Length; i++)
			{
				if (!(this.RegisterItem[i].transform == null))
				{
					this.RegisterItem[i].OnClose();
				}
			}
		}
		StringManager.Instance.DeSpawnString(this.AllyNameStr);
		StringManager.Instance.DeSpawnString(this.RankStr);
		StringManager.Instance.DeSpawnString(this.BackupStr);
	}

	// Token: 0x06000D3B RID: 3387 RVA: 0x0013AA58 File Offset: 0x00138C58
	private void UpdateMessage()
	{
		bool active = false;
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MessageRect.sizeDelta = new Vector2(this.MessageRect.sizeDelta.x, 97f);
		this.RegisterBtn.m_BtnID1 = 0;
		this.RegisterText.text = mStringTable.GetStringByID(17005u);
		this.MessageText.text = string.Empty;
		this.MessageText.color = Color.white;
		if (DataManager.Instance.RoleAlliance.Id == 0u)
		{
			this.MessageText.color = new Color(1f, 0.2667f, 0.349f);
			this.MessageText.text = mStringTable.GetStringByID(17020u);
		}
		else if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_SignUp)
		{
			if (ActivityManager.Instance.AW_SignUpAllianceID > 0u)
			{
				if (this.AWD.MyRank == 0)
				{
					this.MessageText.color = new Color(1f, 0.2667f, 0.349f);
					this.MessageText.text = mStringTable.GetStringByID(17010u);
				}
			}
			else
			{
				active = true;
			}
		}
		else if (this.AWD.GetRegisterCount() < this.AWD.GetRegisterMaxCount())
		{
			this.MessageText.color = new Color(1f, 0.2667f, 0.349f);
			this.MessageText.text = mStringTable.GetStringByID(17019u);
		}
		else
		{
			this.MessageText.color = new Color(0.298f, 0.961f, 0.961f);
			this.MessageText.text = mStringTable.GetStringByID(17031u);
		}
		if (this.AWD.MyRank > 0 && DataManager.Instance.RoleAlliance.Id > 0u)
		{
			if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_SignUp)
			{
				active = true;
			}
			this.MessageRect.sizeDelta = new Vector2(this.MessageRect.sizeDelta.x, 67f);
			this.RegisterText.text = mStringTable.GetStringByID(17009u);
		}
		this.UpdateRank();
		this.RegisterBtn.gameObject.SetActive(active);
		this.ArmyHintObj.SetActive(active);
		if (this.RegisterDataCount == 0 && DataManager.Instance.RoleAlliance.Id > 0u)
		{
			this.ScrollMsgText.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000D3C RID: 3388 RVA: 0x0013ACF0 File Offset: 0x00138EF0
	private void UpdateRank()
	{
		if (this.AWD.MyRank == 0 || DataManager.Instance.RoleAlliance.Id == 0u)
		{
			this.RankText.text = string.Empty;
			return;
		}
		this.RankStr.ClearString();
		if (this.AWD.MyRank > this.AWD.GetRegisterMaxCount())
		{
			this.RankStr.IntToFormat((long)(this.AWD.MyRank - this.AWD.GetRegisterMaxCount()), 1, false);
			this.RankStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17008u));
		}
		else
		{
			if (this.AWD.GetRegisterMaxCount() < this.AWD.GetRegisterCount())
			{
				this.RankStr.IntToFormat((long)(this.AWD.GetRegisterMaxCount() - this.AWD.MyRank + 1), 1, false);
			}
			else
			{
				this.RankStr.IntToFormat((long)(this.AWD.GetRegisterCount() - this.AWD.MyRank + 1), 1, false);
			}
			this.RankStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17007u));
		}
		this.RankText.text = this.RankStr.ToString();
		this.RankText.SetAllDirty();
		this.RankText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000D3D RID: 3389 RVA: 0x0013AE64 File Offset: 0x00139064
	public virtual void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 3)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu(false);
		}
		else if (sender.m_BtnID1 == 0)
		{
			if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 9)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17037u), 255, true);
				return;
			}
			if (this.AWD.MyRank == 0 && this.AWD.GetRegisterCount() == 100)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17011u), 255, true);
				return;
			}
			Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door2.OpenMenu(EGUIWindow.UI_Expedition, 0, 10, false);
		}
		else if (sender.m_BtnID1 == 2)
		{
			ActivityManager.Instance.Send_REQUEST_ALLIANCEWAR_RANKPRIZE();
		}
	}

	// Token: 0x06000D3E RID: 3390 RVA: 0x0013AF6C File Offset: 0x0013916C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.RegisterItem[panelObjectIdx].transform == null)
		{
			this.RegisterItem[panelObjectIdx] = new UIAllianceWarRegister._RegisterItem(item.transform, this.AWD, this);
		}
		if (this.AllyView.GetBeginIdx() != this.TopIndex)
		{
			this.TopIndex = this.AllyView.GetBeginIdx();
			this.CheckWaitItem();
		}
		if (dataIdx == (int)this.AWD.GetRegisterMaxCount())
		{
			this.RegisterItem[panelObjectIdx].SetTitle(this.BackupItemRect);
		}
		this.RegisterItem[panelObjectIdx].SetData(dataIdx);
	}

	// Token: 0x06000D3F RID: 3391 RVA: 0x0013B020 File Offset: 0x00139220
	private void CheckWaitItem()
	{
		if (this.TopIndex > (int)this.AWD.GetRegisterMaxCount() || this.TopIndex + this.PagepeItem - 1 < (int)this.AWD.GetRegisterMaxCount())
		{
			this.BackupItemRect.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000D40 RID: 3392 RVA: 0x0013B074 File Offset: 0x00139274
	public virtual void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06000D41 RID: 3393 RVA: 0x0013B078 File Offset: 0x00139278
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.Parm2 == 3)
		{
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 326.5f, 20, (int)sender.Parm1, 0, new Vector2(0f, 0f), UIButtonHint.ePosition.Original);
		}
		else
		{
			ActivityManager.Instance.AllianceWarMgr.Send_MSG_REQUEST_ALLIANCEWAR_MEMBER_DATA((byte)sender.Parm1);
		}
	}

	// Token: 0x06000D42 RID: 3394 RVA: 0x0013B0DC File Offset: 0x001392DC
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
		if (GUIManager.Instance.m_Arena_Hint != null)
		{
			GUIManager.Instance.m_Arena_Hint.Hide();
		}
	}

	// Token: 0x06000D43 RID: 3395 RVA: 0x0013B118 File Offset: 0x00139318
	public void OnStateChange(EAllianceWarState oldState, EAllianceWarState NewState)
	{
		this.UpdateMessage();
	}

	// Token: 0x04002AD3 RID: 10963
	private UIAllianceWarRegister._RegisterItem[] RegisterItem;

	// Token: 0x04002AD4 RID: 10964
	private ScrollPanel AllyView;

	// Token: 0x04002AD5 RID: 10965
	private int PagepeItem = 9;

	// Token: 0x04002AD6 RID: 10966
	private List<float> Heights = new List<float>();

	// Token: 0x04002AD7 RID: 10967
	private UIText RegisterText;

	// Token: 0x04002AD8 RID: 10968
	private UIText RankText;

	// Token: 0x04002AD9 RID: 10969
	private UIText MessageText;

	// Token: 0x04002ADA RID: 10970
	private UIText BackupText;

	// Token: 0x04002ADB RID: 10971
	private UIText ScrollMsgText;

	// Token: 0x04002ADC RID: 10972
	private UIText AllyNameText;

	// Token: 0x04002ADD RID: 10973
	private UIText[] TitleText = new UIText[2];

	// Token: 0x04002ADE RID: 10974
	private UIText[] ColumnText = new UIText[3];

	// Token: 0x04002ADF RID: 10975
	private CString AllyNameStr;

	// Token: 0x04002AE0 RID: 10976
	private CString RankStr;

	// Token: 0x04002AE1 RID: 10977
	private CString BackupStr;

	// Token: 0x04002AE2 RID: 10978
	private RectTransform MessageRect;

	// Token: 0x04002AE3 RID: 10979
	private RectTransform BackupItemRect;

	// Token: 0x04002AE4 RID: 10980
	private RectTransform AllyViewContentRect;

	// Token: 0x04002AE5 RID: 10981
	private GameObject RankObj;

	// Token: 0x04002AE6 RID: 10982
	private GameObject EmblemObj;

	// Token: 0x04002AE7 RID: 10983
	private GameObject GiftInCreaseObj;

	// Token: 0x04002AE8 RID: 10984
	private GameObject ArmyHintObj;

	// Token: 0x04002AE9 RID: 10985
	private Transform ElbemTrans;

	// Token: 0x04002AEA RID: 10986
	private ushort AllianceElbem;

	// Token: 0x04002AEB RID: 10987
	private UIButton RegisterBtn;

	// Token: 0x04002AEC RID: 10988
	private UIButton RankBtn;

	// Token: 0x04002AED RID: 10989
	public AllianceWarManager AWD = ActivityManager.Instance.AllianceWarMgr;

	// Token: 0x04002AEE RID: 10990
	private byte RegisterDataCount;

	// Token: 0x04002AEF RID: 10991
	private byte bColse;

	// Token: 0x04002AF0 RID: 10992
	private int TopIndex = -1;

	// Token: 0x04002AF1 RID: 10993
	public RectTransform tmpRc;

	// Token: 0x04002AF2 RID: 10994
	private uButtonScale RankBtnScale;

	// Token: 0x02000299 RID: 665
	private enum UIControl
	{
		// Token: 0x04002AF4 RID: 10996
		TopPanel,
		// Token: 0x04002AF5 RID: 10997
		AllyPanel,
		// Token: 0x04002AF6 RID: 10998
		Image,
		// Token: 0x04002AF7 RID: 10999
		RegisterPanel
	}

	// Token: 0x0200029A RID: 666
	private enum TopPanelControl
	{
		// Token: 0x04002AF9 RID: 11001
		BGFrame,
		// Token: 0x04002AFA RID: 11002
		Title1,
		// Token: 0x04002AFB RID: 11003
		Title2,
		// Token: 0x04002AFC RID: 11004
		RankBtn
	}

	// Token: 0x0200029B RID: 667
	private enum AllyPanelConrol
	{
		// Token: 0x04002AFE RID: 11006
		Title,
		// Token: 0x04002AFF RID: 11007
		Scroll,
		// Token: 0x04002B00 RID: 11008
		BackupItem,
		// Token: 0x04002B01 RID: 11009
		Item
	}

	// Token: 0x0200029C RID: 668
	private enum RegisterPanelControl
	{
		// Token: 0x04002B03 RID: 11011
		Emblem,
		// Token: 0x04002B04 RID: 11012
		Message,
		// Token: 0x04002B05 RID: 11013
		Register,
		// Token: 0x04002B06 RID: 11014
		ArmyHint
	}

	// Token: 0x0200029D RID: 669
	private enum ClickType
	{
		// Token: 0x04002B08 RID: 11016
		Register,
		// Token: 0x04002B09 RID: 11017
		Modify,
		// Token: 0x04002B0A RID: 11018
		Rank,
		// Token: 0x04002B0B RID: 11019
		Close
	}

	// Token: 0x0200029E RID: 670
	private struct _RegisterItem
	{
		// Token: 0x06000D44 RID: 3396 RVA: 0x0013B120 File Offset: 0x00139320
		public _RegisterItem(Transform transform, AllianceWarManager AWD, IUIButtonDownUpHandler handle)
		{
			this.AWD = AWD;
			this.transform = transform;
			this.DataIndex = 0;
			this.UnderLineRect = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<RectTransform>();
			this.UnderLineImg = this.UnderLineRect.GetComponent<Image>();
			this.HintRangeRect = transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
			this.Hint = this.HintRangeRect.gameObject.AddComponent<UIButtonHint>();
			this.Hint.m_DownUpHandler = handle;
			this.Hint.m_eHint = EUIButtonHint.CountDown;
			this.Hint.DelayTime = 0.2f;
			this.Hint.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
			this.RankText = transform.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.NameText = transform.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.PowerText = transform.GetChild(2).GetChild(0).GetComponent<UIText>();
			this.RankStr = StringManager.Instance.SpawnString(30);
			this.NameStr = StringManager.Instance.SpawnString(30);
			this.PowerStr = StringManager.Instance.SpawnString(30);
			this.TitleRect = null;
			this.DefNameFontSize = this.NameText.fontSize;
			this.OriTextColor = this.NameText.color;
			this.BGFrame = new UISpritesArray[3];
			for (int i = 0; i < this.BGFrame.Length; i++)
			{
				this.BGFrame[i] = transform.GetChild(i).GetComponent<UISpritesArray>();
			}
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x0013B2C8 File Offset: 0x001394C8
		public void OnClose()
		{
			StringManager.Instance.DeSpawnString(this.RankStr);
			StringManager.Instance.DeSpawnString(this.NameStr);
			StringManager.Instance.DeSpawnString(this.PowerStr);
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x0013B308 File Offset: 0x00139508
		public void TextureRebuilt()
		{
			this.RankText.enabled = false;
			this.RankText.enabled = true;
			this.NameText.enabled = false;
			this.NameText.enabled = true;
			this.PowerText.enabled = false;
			this.PowerText.enabled = true;
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x0013B360 File Offset: 0x00139560
		public void SetData(int DataIndex)
		{
			if (this.transform == null)
			{
				return;
			}
			this.DataIndex = DataIndex;
			AllianceWarManager._RegisterData dataIndex = this.AWD.GetDataIndex(DataIndex);
			this.AWD.FormatRank(DataIndex, ref this.RankStr);
			this.RankText.text = this.RankStr.ToString();
			this.RankText.SetAllDirty();
			this.RankText.cachedTextGenerator.Invalidate();
			this.NameStr.ClearString();
			this.NameStr.Append(dataIndex.Name);
			this.NameText.fontSize = this.DefNameFontSize;
			this.NameText.text = this.NameStr.ToString();
			this.NameText.SetAllDirty();
			this.NameText.cachedTextGenerator.Invalidate();
			this.NameText.cachedTextGeneratorForLayout.Invalidate();
			this.PowerStr.ClearString();
			this.PowerStr.IntToFormat((long)dataIndex.Power, 1, true);
			this.PowerStr.AppendFormat("{0}");
			this.PowerText.text = this.PowerStr.ToString();
			this.PowerText.SetAllDirty();
			this.PowerText.cachedTextGenerator.Invalidate();
			float num;
			for (num = this.NameText.preferredWidth; num > 209f; num = this.NameText.preferredWidth)
			{
				this.NameText.fontSize--;
				if (this.NameText.fontSize < 8)
				{
					num = 209f;
					break;
				}
				this.NameText.SetLayoutDirty();
				this.NameText.cachedTextGeneratorForLayout.Invalidate();
			}
			this.UnderLineRect.sizeDelta = new Vector2(num, 3f);
			this.HintRangeRect.sizeDelta = new Vector2(num, 45f);
			if (GUIManager.Instance.IsArabic)
			{
				this.UnderLineRect.anchoredPosition = new Vector2(this.NameText.rectTransform.rect.width - num, this.UnderLineRect.anchoredPosition.y);
			}
			int num2 = (int)this.AWD.GetRegisterMaxCount();
			if (num2 > (int)this.AWD.GetRegisterCount())
			{
				num2 = (int)this.AWD.GetRegisterCount();
			}
			if ((int)this.AWD.GetRegisterMaxCount() > DataIndex)
			{
				Graphic rankText = this.RankText;
				Color color = this.OriTextColor;
				this.PowerText.color = color;
				color = color;
				this.NameText.color = color;
				rankText.color = color;
				this.UnderLineImg.color = Color.white;
				this.Hint.Parm1 = (ushort)(num2 - DataIndex);
			}
			else
			{
				Graphic rankText2 = this.RankText;
				Color color = new Color(0.443f, 0.816f, 0.953f);
				this.UnderLineImg.color = color;
				color = color;
				this.PowerText.color = color;
				color = color;
				this.NameText.color = color;
				rankText2.color = color;
				this.Hint.Parm1 = (ushort)(DataIndex + 1);
			}
			int spriteIndex = 0;
			if ((DataIndex & 1) > 0)
			{
				spriteIndex = 1;
			}
			if (this.AWD.MyRank > 0)
			{
				if (num2 > (int)(this.AWD.MyRank - 1))
				{
					if (num2 - DataIndex == (int)this.AWD.MyRank)
					{
						spriteIndex = 2;
					}
				}
				else if (this.AWD.MyRank > 0 && DataIndex == (int)(this.AWD.MyRank - 1))
				{
					spriteIndex = 2;
				}
			}
			for (int i = 0; i < this.BGFrame.Length; i++)
			{
				this.BGFrame[i].SetSpriteIndex(spriteIndex);
			}
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x0013B724 File Offset: 0x00139924
		public void SetTitle(RectTransform rect)
		{
			this.TitleRect = rect;
			this.TitleRect.SetParent(this.transform.parent, false);
			RectTransform rectTransform = this.transform as RectTransform;
			this.TitleRect.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y);
			rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y - 45f);
			this.TitleRect.gameObject.SetActive(true);
		}

		// Token: 0x04002B0C RID: 11020
		public Transform transform;

		// Token: 0x04002B0D RID: 11021
		private RectTransform TitleRect;

		// Token: 0x04002B0E RID: 11022
		private RectTransform UnderLineRect;

		// Token: 0x04002B0F RID: 11023
		private RectTransform HintRangeRect;

		// Token: 0x04002B10 RID: 11024
		private Image UnderLineImg;

		// Token: 0x04002B11 RID: 11025
		private UISpritesArray[] BGFrame;

		// Token: 0x04002B12 RID: 11026
		public int DataIndex;

		// Token: 0x04002B13 RID: 11027
		private UIText RankText;

		// Token: 0x04002B14 RID: 11028
		private UIText NameText;

		// Token: 0x04002B15 RID: 11029
		private UIText PowerText;

		// Token: 0x04002B16 RID: 11030
		private CString RankStr;

		// Token: 0x04002B17 RID: 11031
		private CString NameStr;

		// Token: 0x04002B18 RID: 11032
		private CString PowerStr;

		// Token: 0x04002B19 RID: 11033
		private AllianceWarManager AWD;

		// Token: 0x04002B1A RID: 11034
		private int DefNameFontSize;

		// Token: 0x04002B1B RID: 11035
		private Color OriTextColor;

		// Token: 0x04002B1C RID: 11036
		private UIButtonHint Hint;
	}

	// Token: 0x0200029F RID: 671
	public enum eUpdatteUI
	{
		// Token: 0x04002B1E RID: 11038
		Initial = 1,
		// Token: 0x04002B1F RID: 11039
		Item,
		// Token: 0x04002B20 RID: 11040
		Message,
		// Token: 0x04002B21 RID: 11041
		Hint,
		// Token: 0x04002B22 RID: 11042
		Data,
		// Token: 0x04002B23 RID: 11043
		AllianceEnterWar
	}
}
