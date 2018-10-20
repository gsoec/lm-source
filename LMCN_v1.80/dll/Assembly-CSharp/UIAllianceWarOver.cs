using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002C2 RID: 706
public class UIAllianceWarOver : GUIWindow, IActivityWindow, IUIButtonClickHandler
{
	// Token: 0x06000E78 RID: 3704 RVA: 0x0017C994 File Offset: 0x0017AB94
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.Cstr_Rank = StringManager.Instance.SpawnString(200);
		this.Cstr_AllianceTag = StringManager.Instance.SpawnString(30);
		this.Tmp1 = this.GameT.GetChild(0).GetChild(0);
		this.btn_Rewards = this.Tmp1.GetChild(0).GetComponent<UIButton>();
		this.btn_Rewards.m_Handler = this;
		this.btn_Rewards.m_BtnID1 = 0;
		this.btn_Rewards.m_EffectType = e_EffectType.e_Scale;
		this.btn_Rewards.transition = Selectable.Transition.None;
		if (this.GUIM.IsArabic)
		{
			this.btn_Rewards.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.GiftInCreaseObj = this.Tmp1.GetChild(0).GetChild(0).gameObject;
		if (ActivityManager.Instance.AW_PrizeGroupID > 0)
		{
			this.GiftInCreaseObj.SetActive(true);
		}
		this.text_Title = this.Tmp1.GetChild(1).GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(14631u);
		this.BadgeT = this.GameT.GetChild(0).GetChild(2);
		this.Tmp1 = this.GameT.GetChild(0);
		this.text_Rank = this.Tmp1.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.text_Rank.font = this.TTFont;
		this.Cstr_Rank.ClearString();
		this.Cstr_Rank.Append(this.DM.mStringTable.GetStringByID((uint)((ushort)(14635 + (int)ActivityManager.Instance.AllianceWarMgr.MyFinalGame))));
		this.text_Rank.text = this.Cstr_Rank.ToString();
		this.text_Rank.SetAllDirty();
		this.text_Rank.cachedTextGenerator.Invalidate();
		this.text_AllianceTag = this.Tmp1.GetChild(4).GetComponent<UIText>();
		this.text_AllianceTag.font = this.TTFont;
		this.Cstr_AllianceTag.ClearString();
		this.GUIM.FormatRoleNameForChat(this.Cstr_AllianceTag, null, this.DM.RoleAlliance.Tag, 0, false);
		this.text_AllianceTag.text = this.Cstr_AllianceTag.ToString();
		this.text_AllianceTag.SetAllDirty();
		this.text_AllianceTag.cachedTextGenerator.Invalidate();
		this.text_Over = this.Tmp1.GetChild(5).GetComponent<UIText>();
		this.text_Over.font = this.TTFont;
		this.text_Over.text = this.DM.mStringTable.GetStringByID(14633u);
		this.text_Schedule = this.Tmp1.GetChild(6).GetComponent<UIText>();
		this.text_Schedule.font = this.TTFont;
		this.text_Schedule.text = this.DM.mStringTable.GetStringByID(14625u);
		this.GUIM.InitBadgeTotem(this.BadgeT, this.DM.RoleAlliance.Emblem);
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		ActivityWindow activityWindow = this.GameT.gameObject.AddComponent<ActivityWindow>();
		activityWindow.Initial(e_ActivityType.RunFail, this);
		if (this.DM.RoleAlliance.Id == 0u || ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
		{
			this.bClose = 1;
		}
		else if (ActivityManager.Instance.AW_State >= EAllianceWarState.EAWS_Replay)
		{
			this.bClose = 2;
		}
	}

	// Token: 0x06000E79 RID: 3705 RVA: 0x0017CD88 File Offset: 0x0017AF88
	public void OnStateChange(EAllianceWarState oldState, EAllianceWarState NewState)
	{
	}

	// Token: 0x06000E7A RID: 3706 RVA: 0x0017CD8C File Offset: 0x0017AF8C
	public override void OnClose()
	{
		if (this.Cstr_Rank != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Rank);
		}
		if (this.Cstr_AllianceTag != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_AllianceTag);
		}
	}

	// Token: 0x06000E7B RID: 3707 RVA: 0x0017CDD4 File Offset: 0x0017AFD4
	public void OnButtonClick(UIButton sender)
	{
		GUIAllianceWarOver_btn btnID = (GUIAllianceWarOver_btn)sender.m_BtnID1;
		if (btnID == GUIAllianceWarOver_btn.btn_Rewards)
		{
			ActivityManager.Instance.Send_REQUEST_ALLIANCEWAR_RANKPRIZE();
		}
	}

	// Token: 0x06000E7C RID: 3708 RVA: 0x0017CE04 File Offset: 0x0017B004
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.bClose > 0)
		{
			if (this.bClose == 2)
			{
				ActivityManager.Instance.AllianceWarSendReOpenMenu();
			}
			else
			{
				this.door.CloseMenu(false);
			}
			this.bClose = 0;
		}
	}

	// Token: 0x06000E7D RID: 3709 RVA: 0x0017CE4C File Offset: 0x0017B04C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Alliance)
			{
				if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
				{
					if (networkNews == NetworkNews.Refresh_RecvAllianceInfo)
					{
						if (this.DM.RoleAlliance.Id == 0u)
						{
							this.door.CloseMenu_Alliance(EGUIWindow.UI_AllianceWarOver);
							return;
						}
						if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
						{
							this.door.CloseMenu(false);
							return;
						}
						ActivityManager.Instance.AllianceWarSendReOpenMenu();
					}
				}
				else
				{
					this.Refresh_FontTexture();
				}
			}
			else if (this.DM.RoleAlliance.Id == 0u)
			{
				this.door.CloseMenu_Alliance(EGUIWindow.UI_AllianceWarOver);
				return;
			}
		}
		else
		{
			if (this.DM.RoleAlliance.Id == 0u)
			{
				this.door.CloseMenu_Alliance(EGUIWindow.UI_AllianceWarOver);
				return;
			}
			if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
			{
				this.door.CloseMenu(false);
				return;
			}
		}
	}

	// Token: 0x06000E7E RID: 3710 RVA: 0x0017CF50 File Offset: 0x0017B150
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Rank != null && this.text_Rank.enabled)
		{
			this.text_Rank.enabled = false;
			this.text_Rank.enabled = true;
		}
		if (this.text_AllianceTag != null && this.text_AllianceTag.enabled)
		{
			this.text_AllianceTag.enabled = false;
			this.text_AllianceTag.enabled = true;
		}
		if (this.text_Over != null && this.text_Over.enabled)
		{
			this.text_Over.enabled = false;
			this.text_Over.enabled = true;
		}
		if (this.text_Schedule != null && this.text_Schedule.enabled)
		{
			this.text_Schedule.enabled = false;
			this.text_Schedule.enabled = true;
		}
	}

	// Token: 0x04002E62 RID: 11874
	private DataManager DM;

	// Token: 0x04002E63 RID: 11875
	private GUIManager GUIM;

	// Token: 0x04002E64 RID: 11876
	private ActivityManager ActM;

	// Token: 0x04002E65 RID: 11877
	private Transform GameT;

	// Token: 0x04002E66 RID: 11878
	private Transform Tmp1;

	// Token: 0x04002E67 RID: 11879
	private Transform BadgeT;

	// Token: 0x04002E68 RID: 11880
	private Door door;

	// Token: 0x04002E69 RID: 11881
	private Font TTFont;

	// Token: 0x04002E6A RID: 11882
	private UIButton btn_Rewards;

	// Token: 0x04002E6B RID: 11883
	private UIText text_Title;

	// Token: 0x04002E6C RID: 11884
	private UIText text_Rank;

	// Token: 0x04002E6D RID: 11885
	private UIText text_AllianceTag;

	// Token: 0x04002E6E RID: 11886
	private UIText text_Over;

	// Token: 0x04002E6F RID: 11887
	private UIText text_Schedule;

	// Token: 0x04002E70 RID: 11888
	private CString Cstr_Rank;

	// Token: 0x04002E71 RID: 11889
	private CString Cstr_AllianceTag;

	// Token: 0x04002E72 RID: 11890
	private byte bClose;

	// Token: 0x04002E73 RID: 11891
	private GameObject GiftInCreaseObj;
}
