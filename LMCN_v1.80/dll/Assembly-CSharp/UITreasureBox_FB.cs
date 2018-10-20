using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006A7 RID: 1703
public class UITreasureBox_FB : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x060020A5 RID: 8357 RVA: 0x003E1A2C File Offset: 0x003DFC2C
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.TTFont = this.GUIM.GetTTFFont();
		this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		this.GameT = base.gameObject.transform;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.GameT.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.GameT.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.Tmp = this.GameT.GetChild(0).GetChild(0);
		this.btn_FBInvite = this.Tmp.GetComponent<UIButton>();
		this.btn_FBInvite.m_Handler = this;
		this.btn_FBInvite.m_BtnID1 = 1;
		this.btn_FBInvite.m_EffectType = e_EffectType.e_Scale;
		this.btn_FBInvite.transition = Selectable.Transition.None;
		this.Tmp = this.GameT.GetChild(0).GetChild(0).GetChild(0);
		this.text_Invite = this.Tmp.GetComponent<UIText>();
		this.text_Invite.font = this.TTFont;
		this.text_Invite.text = this.DM.mStringTable.GetStringByID(14650u);
		this.Tmp = this.GameT.GetChild(0).GetChild(3);
		this.text_Info = this.Tmp.GetComponent<UIText>();
		this.text_Info.font = this.TTFont;
		this.text_Info.text = this.DM.mStringTable.GetStringByID(14649u);
		this.Tmp = this.GameT.GetChild(1).GetChild(0);
		this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.Tmp = this.GameT.GetChild(1).GetChild(1);
		this.text_Title = this.Tmp.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(14648u);
		this.OutsideExitBtn = base.gameObject.AddComponent<HelperUIButton>();
		this.OutsideExitBtn.m_Handler = this;
		this.OutsideExitBtn.m_BtnID1 = 0;
	}

	// Token: 0x060020A6 RID: 8358 RVA: 0x003E1CC8 File Offset: 0x003DFEC8
	public override void OnClose()
	{
		if (DataManager.FBMissionDataManager.bFB_CDTime)
		{
			DataManager.FBMissionDataManager.bFB_btnShow = false;
			DataManager.FBMissionDataManager.ReSetFB_CDTime(null);
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 0);
		}
	}

	// Token: 0x060020A7 RID: 8359 RVA: 0x003E1D08 File Offset: 0x003DFF08
	public void OnButtonClick(UIButton sender)
	{
		GUITreasureBox_FB_btn btnID = (GUITreasureBox_FB_btn)sender.m_BtnID1;
		if (btnID != GUITreasureBox_FB_btn.btn_EXIT)
		{
			if (btnID == GUITreasureBox_FB_btn.btn_FBInvite)
			{
				this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox_FB);
				this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
				Door door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
				if (door != null)
				{
					DataManager.FBMissionDataManager.m_FBBindEnd = false;
					if (DataManager.FBMissionDataManager.GetRemainTime() == 0u)
					{
						DataManager.FBMissionDataManager.ReSetFB_CDTime(null);
					}
					door.OpenMenu(EGUIWindow.UI_MissionFB, 0, 0, true);
				}
			}
		}
		else
		{
			this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox_FB);
			this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		}
	}

	// Token: 0x060020A8 RID: 8360 RVA: 0x003E1DC4 File Offset: 0x003DFFC4
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
			this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
			this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		}
	}

	// Token: 0x060020A9 RID: 8361 RVA: 0x003E1E14 File Offset: 0x003E0014
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Info != null && this.text_Info.enabled)
		{
			this.text_Info.enabled = false;
			this.text_Info.enabled = true;
		}
		if (this.text_Invite != null && this.text_Invite.enabled)
		{
			this.text_Invite.enabled = false;
			this.text_Invite.enabled = true;
		}
	}

	// Token: 0x060020AA RID: 8362 RVA: 0x003E1ECC File Offset: 0x003E00CC
	private void Start()
	{
	}

	// Token: 0x060020AB RID: 8363 RVA: 0x003E1ED0 File Offset: 0x003E00D0
	private void Update()
	{
	}

	// Token: 0x0400670B RID: 26379
	private Transform GameT;

	// Token: 0x0400670C RID: 26380
	private Transform Tmp;

	// Token: 0x0400670D RID: 26381
	private UIButton btn_EXIT;

	// Token: 0x0400670E RID: 26382
	private UIButton btn_FBInvite;

	// Token: 0x0400670F RID: 26383
	private HelperUIButton OutsideExitBtn;

	// Token: 0x04006710 RID: 26384
	private UIText text_Title;

	// Token: 0x04006711 RID: 26385
	private UIText text_Info;

	// Token: 0x04006712 RID: 26386
	private UIText text_Invite;

	// Token: 0x04006713 RID: 26387
	private DataManager DM;

	// Token: 0x04006714 RID: 26388
	private GUIManager GUIM;

	// Token: 0x04006715 RID: 26389
	private Font TTFont;
}
