using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006B7 RID: 1719
public class UIWarLobby : GUIWindow, IBuildingWindowType, IUIButtonClickHandler
{
	// Token: 0x060020D4 RID: 8404 RVA: 0x003E5E68 File Offset: 0x003E4068
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Upgrade)
		{
			this.ThisTransform.gameObject.SetActive(false);
		}
		else if (buildType == e_BuildType.Normal)
		{
			this.ThisTransform.gameObject.SetActive(true);
		}
	}

	// Token: 0x060020D5 RID: 8405 RVA: 0x003E5EAC File Offset: 0x003E40AC
	private void Start()
	{
		this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		RoleBuildingData roleBuildingData = this.GUIM.BuildingData.AllBuildsData[this.ManorID];
		this.baseBuild.InitBuildingWindow((byte)roleBuildingData.BuildID, (ushort)this.ManorID, 2, roleBuildingData.Level);
		this.baseBuild.baseTransform.SetAsFirstSibling();
	}

	// Token: 0x060020D6 RID: 8406 RVA: 0x003E5F30 File Offset: 0x003E4130
	public override void OnOpen(int arg1, int arg2)
	{
		this.ThisTransform = base.transform.GetChild(0);
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.ManorID = arg1;
		Font ttffont = this.GUIM.GetTTFFont();
		this.RecruitStr = StringManager.Instance.SpawnString(100);
		this.AttackStr = StringManager.Instance.SpawnString(30);
		this.DefenceStr = StringManager.Instance.SpawnString(30);
		this.RecruitText = this.ThisTransform.GetChild(1).GetComponent<UIText>();
		this.RecruitText.font = ttffont;
		this.AttackTrans = this.ThisTransform.GetChild(3).GetComponent<RectTransform>();
		this.AttackText = this.ThisTransform.GetChild(3).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.AttackText.font = ttffont;
		UIText component = this.ThisTransform.GetChild(3).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(4862u);
		this.TextReflash[0] = component;
		UIButton component2 = this.ThisTransform.GetChild(3).GetChild(1).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 0;
		this.DefenceTrans = this.ThisTransform.GetChild(4).GetComponent<RectTransform>();
		this.DefenceText = this.ThisTransform.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.DefenceText.font = ttffont;
		component = this.ThisTransform.GetChild(4).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(4863u);
		this.TextReflash[1] = component;
		component2 = this.ThisTransform.GetChild(4).GetChild(1).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 1;
		this.TeamTrans = this.ThisTransform.GetChild(5).GetComponent<RectTransform>();
		component = this.ThisTransform.GetChild(5).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(990u);
		this.TextReflash[2] = component;
		component2 = this.ThisTransform.GetChild(5).GetChild(1).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 2;
		this.IconRect = this.ThisTransform.GetChild(2).GetComponent<RectTransform>();
		this.MessageTrans = this.ThisTransform.GetChild(6);
		component = this.MessageTrans.GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(5781u);
		this.TextReflash[3] = component;
		this.UpdateFunctionState();
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		this.DM.CheckWalHall_List();
		this.UpdateRecruitNum();
	}

	// Token: 0x060020D7 RID: 8407 RVA: 0x003E623C File Offset: 0x003E443C
	public void UpdateFunctionState()
	{
		if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 20)
		{
			this.AttackTrans.anchoredPosition = Vector2.zero;
			this.DefenceTrans.anchoredPosition = Vector2.zero;
			this.TeamTrans.gameObject.SetActive(false);
		}
		else
		{
			this.AttackTrans.anchoredPosition = new Vector2(-82f, 0f);
			this.DefenceTrans.anchoredPosition = new Vector2(-174f, 0f);
			this.TeamTrans.gameObject.SetActive(true);
		}
	}

	// Token: 0x060020D8 RID: 8408 RVA: 0x003E62E4 File Offset: 0x003E44E4
	public void OnButtonClick(UIButton sender)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		switch (sender.m_BtnID1)
		{
		case 0:
			if (DataManager.Instance.RoleAlliance.Id == 0u)
			{
				this.GUIM.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5781u), 255, true);
			}
			else
			{
				this.GUIM.MarshalSaved = 1;
				door.OpenMenu(EGUIWindow.UI_Alliance_Info, 1, 0, false);
			}
			break;
		case 1:
			if (DataManager.Instance.RoleAlliance.Id == 0u)
			{
				this.GUIM.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5781u), 255, true);
			}
			else
			{
				this.GUIM.MarshalSaved = 2;
				door.OpenMenu(EGUIWindow.UI_Alliance_Info, 1, 0, false);
			}
			break;
		case 2:
			door.OpenMenu(EGUIWindow.UI_TeamSave, 0, 0, false);
			break;
		}
	}

	// Token: 0x060020D9 RID: 8409 RVA: 0x003E63E8 File Offset: 0x003E45E8
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		StringManager.Instance.DeSpawnString(this.RecruitStr);
		StringManager.Instance.DeSpawnString(this.AttackStr);
		StringManager.Instance.DeSpawnString(this.DefenceStr);
	}

	// Token: 0x060020DA RID: 8410 RVA: 0x003E6444 File Offset: 0x003E4644
	public void UpdateRecruitNum()
	{
		uint num = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_CAPACITY) + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_PETSKILL_RALLY_CAPACITY);
		this.RecruitStr.ClearString();
		if (this.DM.Sponsor > 0 && this.DM.WarHall[0] != null && this.DM.WarHall[0].Count >= (int)this.DM.Sponsor)
		{
			WarlobbyData warlobbyData = this.DM.WarHall[0][(int)(this.DM.Sponsor - 1)];
			this.RecruitStr.StringToFormat(this.DM.mStringTable.GetStringByID(4861u));
			this.RecruitStr.IntToFormat((long)((ulong)warlobbyData.AllyCurrTroop), 1, true);
			this.RecruitStr.IntToFormat((long)((ulong)warlobbyData.AllyMAXTroop), 1, true);
			this.RecruitStr.AppendFormat("{0} {1} / {2}");
		}
		else
		{
			this.RecruitStr.StringToFormat(this.DM.mStringTable.GetStringByID(4860u));
			this.RecruitStr.IntToFormat((long)((ulong)num), 1, true);
			this.RecruitStr.AppendFormat("{0}{1}");
		}
		this.RecruitText.text = this.RecruitStr.ToString();
		this.RecruitText.SetAllDirty();
		this.RecruitText.cachedTextGenerator.Invalidate();
		this.RecruitText.cachedTextGeneratorForLayout.Invalidate();
		Vector2 anchoredPosition = this.IconRect.anchoredPosition;
		anchoredPosition.x = -this.RecruitText.preferredWidth * 0.5f - 26f;
		this.IconRect.anchoredPosition = anchoredPosition;
		if (DataManager.Instance.RoleAlliance.Id == 0u && GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 20)
		{
			this.AttackTrans.gameObject.SetActive(false);
			this.DefenceTrans.gameObject.SetActive(false);
			this.MessageTrans.gameObject.SetActive(true);
			return;
		}
		this.AttackStr.ClearString();
		if (this.DM.ActiveRallyRecNum == 0u)
		{
			this.AttackStr.Append(this.DM.mStringTable.GetStringByID(4865u));
		}
		else
		{
			this.AttackStr.StringToFormat(this.DM.mStringTable.GetStringByID(4864u));
			this.AttackStr.IntToFormat((long)((ulong)this.DM.ActiveRallyRecNum), 1, false);
			this.AttackStr.AppendFormat("{0} : {1}");
		}
		this.AttackText.text = this.AttackStr.ToString();
		this.AttackText.SetAllDirty();
		this.AttackText.cachedTextGenerator.Invalidate();
		this.DefenceStr.ClearString();
		if (this.DM.BeingRallyRecNum == 0u)
		{
			this.DefenceStr.Append(this.DM.mStringTable.GetStringByID(4867u));
		}
		else
		{
			this.DefenceStr.StringToFormat(this.DM.mStringTable.GetStringByID(4866u));
			this.DefenceStr.IntToFormat((long)((ulong)this.DM.BeingRallyRecNum), 1, false);
			this.DefenceStr.AppendFormat("{0} : {1}");
		}
		this.DefenceText.text = this.DefenceStr.ToString();
		this.DefenceText.SetAllDirty();
		this.DefenceText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x060020DB RID: 8411 RVA: 0x003E67E4 File Offset: 0x003E49E4
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
						if (this.baseBuild != null)
						{
							this.baseBuild.Refresh_FontTexture();
						}
						this.RecruitText.enabled = false;
						this.RecruitText.enabled = true;
						this.AttackText.enabled = false;
						this.AttackText.enabled = true;
						this.DefenceText.enabled = false;
						this.DefenceText.enabled = true;
						for (int i = 0; i < this.TextReflash.Length; i++)
						{
							this.TextReflash[i].enabled = false;
							this.TextReflash[i].enabled = true;
						}
					}
				}
				else
				{
					if (this.baseBuild != null)
					{
						this.baseBuild.MyUpdate(0, false);
					}
					this.UpdateRecruitNum();
				}
			}
			else
			{
				this.UpdateFunctionState();
				if (this.baseBuild != null)
				{
					this.baseBuild.MyUpdate(meg[1], false);
				}
			}
		}
		else
		{
			DataManager.Instance.CheckWalHall_List();
		}
	}

	// Token: 0x060020DC RID: 8412 RVA: 0x003E691C File Offset: 0x003E4B1C
	public override void UpdateUI(int arg1, int arg2)
	{
		this.UpdateRecruitNum();
	}

	// Token: 0x04006795 RID: 26517
	private DataManager DM;

	// Token: 0x04006796 RID: 26518
	private GUIManager GUIM;

	// Token: 0x04006797 RID: 26519
	private BuildingWindow baseBuild;

	// Token: 0x04006798 RID: 26520
	private Transform ThisTransform;

	// Token: 0x04006799 RID: 26521
	private Transform MessageTrans;

	// Token: 0x0400679A RID: 26522
	private RectTransform AttackTrans;

	// Token: 0x0400679B RID: 26523
	private RectTransform DefenceTrans;

	// Token: 0x0400679C RID: 26524
	private RectTransform TeamTrans;

	// Token: 0x0400679D RID: 26525
	private UIText RecruitText;

	// Token: 0x0400679E RID: 26526
	private UIText AttackText;

	// Token: 0x0400679F RID: 26527
	private UIText DefenceText;

	// Token: 0x040067A0 RID: 26528
	private UIText[] TextReflash = new UIText[4];

	// Token: 0x040067A1 RID: 26529
	private CString RecruitStr;

	// Token: 0x040067A2 RID: 26530
	private CString AttackStr;

	// Token: 0x040067A3 RID: 26531
	private CString DefenceStr;

	// Token: 0x040067A4 RID: 26532
	private RectTransform IconRect;

	// Token: 0x040067A5 RID: 26533
	private int ManorID;

	// Token: 0x020006B8 RID: 1720
	private enum UIControl
	{
		// Token: 0x040067A7 RID: 26535
		Image,
		// Token: 0x040067A8 RID: 26536
		RecruitText,
		// Token: 0x040067A9 RID: 26537
		Icon,
		// Token: 0x040067AA RID: 26538
		Attack,
		// Token: 0x040067AB RID: 26539
		Defence,
		// Token: 0x040067AC RID: 26540
		Team,
		// Token: 0x040067AD RID: 26541
		Message
	}

	// Token: 0x020006B9 RID: 1721
	private enum ClickType
	{
		// Token: 0x040067AF RID: 26543
		Attack,
		// Token: 0x040067B0 RID: 26544
		Defence,
		// Token: 0x040067B1 RID: 26545
		Team
	}
}
