using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200046C RID: 1132
public class UIPetFusionbuilding : GUIWindow, IBuildingWindowType, IUIButtonClickHandler, IUTimeBarOnTimer
{
	// Token: 0x060016F8 RID: 5880 RVA: 0x0027A51C File Offset: 0x0027871C
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
		{
			this.mFusionbuildingT.gameObject.SetActive(true);
			this.Img_Line.gameObject.SetActive(true);
		}
		else
		{
			this.mFusionbuildingT.gameObject.SetActive(false);
			this.Img_Line.gameObject.SetActive(false);
		}
	}

	// Token: 0x060016F9 RID: 5881 RVA: 0x0027A588 File Offset: 0x00278788
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.PM = PetManager.Instance;
		this.GameT = base.gameObject.transform;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.AssetName = "BuildingWindow";
		Material material = this.GUIM.AddSpriteAsset(this.AssetName);
		this.Cstr = StringManager.Instance.SpawnString(30);
		this.B_ID = arg1;
		if (this.PM.bCheckLockFusionSkill)
		{
			for (int i = 0; i < this.PM.sortPetData.Count; i++)
			{
				this.tmpPetD = this.PM.PetTable.GetRecordByKey(this.PM.GetPetData((int)this.PM.sortPetData[i]).ID);
				ushort num = 0;
				for (int j = 0; j < 4; j++)
				{
					if (this.tmpPetD.PetSkill[j] > 0)
					{
						num = this.PM.PetSkillTable.GetRecordByKey(this.tmpPetD.PetSkill[j]).Diamond;
					}
					if (num > 0)
					{
						this.PM.bCheckLockFusionSkill = false;
						break;
					}
				}
				if (!this.PM.bCheckLockFusionSkill)
				{
					break;
				}
			}
		}
		this.mFusionbuildingT = this.GameT.GetChild(0);
		this.timeBar = this.mFusionbuildingT.GetChild(0).GetComponent<UITimeBar>();
		RectTransform component = this.mFusionbuildingT.GetChild(0).GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(-40f, component.anchoredPosition.y);
		long num2 = this.DM.ServerTime;
		long target = this.DM.SoldierBeginTime + (long)((ulong)this.DM.SoldierNeedTime) - num2;
		this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
		this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
		this.timeBar.m_Handler = this;
		this.timeBar.m_TimeBarID = 1;
		this.timeBar.gameObject.SetActive(false);
		this.text_Info = this.mFusionbuildingT.GetChild(1).GetComponent<UIText>();
		this.text_Info.font = this.TTFont;
		this.text_Info.text = this.DM.mStringTable.GetStringByID(14652u);
		if (this.DM.queueBarData[34].bActive)
		{
			num2 = this.DM.queueBarData[34].StartTime;
			target = num2 + (long)((ulong)this.DM.queueBarData[34].TotalTime);
			this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(PetManager.Instance.ItemCraftID);
			Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
			CString cstring = StringManager.Instance.StaticString1024();
			StringManager.IntToStr(cstring, (long)PetManager.Instance.ItemCraftCount, 1, true);
			this.Cstr.ClearString();
			if (this.tmpFD.Fusion_Kind < 1)
			{
				this.Cstr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID).EquipName));
			}
			else
			{
				CString cstring2 = StringManager.Instance.StaticString1024();
				cstring2.ClearString();
				cstring2.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID).EquipName));
				cstring2.StringToFormat(this.DM.mStringTable.GetStringByID(14669u));
				cstring2.AppendFormat("{0}{1}");
				this.Cstr.StringToFormat(cstring2);
			}
			this.Cstr.StringToFormat(cstring);
			this.Cstr.AppendFormat(this.DM.mStringTable.GetStringByID(4048u));
			this.GUIM.SetTimerBar(this.timeBar, num2, target, 0L, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(14660u), this.Cstr.ToString());
			this.timeBar.gameObject.SetActive(true);
			this.text_Info.gameObject.SetActive(false);
			this.bFusion = true;
		}
		Transform child = this.GameT.GetChild(1);
		this.Img_Line = child.GetComponent<Image>();
		this.Img_Line.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_divider_02");
		this.Img_Line.material = material;
		Transform child2 = child.GetChild(0);
		this.btn_PetContract = child2.GetComponent<UIButton>();
		this.btn_PetContract.m_Handler = this;
		this.btn_PetContract.m_BtnID1 = 0;
		this.btn_PetContract.m_EffectType = e_EffectType.e_Scale;
		this.btn_PetContract.transition = Selectable.Transition.None;
		this.text_PetContract = child2.GetChild(0).GetComponent<UIText>();
		this.text_PetContract.font = this.TTFont;
		this.text_PetContract.text = this.DM.mStringTable.GetStringByID(14653u);
		child2 = child.GetChild(1);
		this.btn_Petskill = child2.GetComponent<UIButton>();
		this.btn_Petskill.m_Handler = this;
		this.btn_Petskill.m_BtnID1 = 1;
		this.btn_Petskill.m_EffectType = e_EffectType.e_Scale;
		this.btn_Petskill.transition = Selectable.Transition.None;
		this.Img_Lock = child2.GetChild(0).GetComponent<Image>();
		this.Img_Lock.sprite = this.door.LoadSprite("UI_main_lock");
		this.Img_Lock.material = this.door.LoadMaterial();
		this.Img_Lock.SetNativeSize();
		if (this.PM.bCheckLockFusionSkill)
		{
			this.Img_Lock.gameObject.SetActive(true);
			this.btn_Petskill.image.color = Color.gray;
		}
		this.text_Petskill = child2.GetChild(1).GetComponent<UIText>();
		this.text_Petskill.font = this.TTFont;
		this.text_Petskill.text = this.DM.mStringTable.GetStringByID(14654u);
		this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		byte level = this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level;
		this.baseBuild.InitBuildingWindow(22, (ushort)this.B_ID, 2, level);
		this.baseBuild.baseTransform.SetAsFirstSibling();
		if (!NewbieManager.CheckNewbie(this))
		{
			NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIERS, this, false);
		}
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 4);
		NewbieManager.CheckPetFusionBuilding();
	}

	// Token: 0x060016FA RID: 5882 RVA: 0x0027ACC0 File Offset: 0x00278EC0
	public void OnButtonClick(UIButton sender)
	{
		GUIPetFusionbuilding btnID = (GUIPetFusionbuilding)sender.m_BtnID1;
		if (btnID != GUIPetFusionbuilding.btn_PetContract)
		{
			if (btnID == GUIPetFusionbuilding.btn_Petskill)
			{
				if (this.PM.bCheckLockFusionSkill)
				{
					this.GUIM.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14655u), 255, true);
				}
				else
				{
					this.door.OpenMenu(EGUIWindow.UI_PetFusion, 1, 0, false);
				}
			}
		}
		else
		{
			this.door.OpenMenu(EGUIWindow.UI_PetFusion, 0, 0, false);
		}
	}

	// Token: 0x060016FB RID: 5883 RVA: 0x0027AD54 File Offset: 0x00278F54
	public override void OnClose()
	{
		if (this.AssetName != null)
		{
			this.GUIM.RemoveSpriteAsset(this.AssetName);
		}
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		if (this.timeBar != null)
		{
			this.GUIM.RemoverTimeBaarToList(this.timeBar);
		}
		if (this.Cstr != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr);
		}
	}

	// Token: 0x060016FC RID: 5884 RVA: 0x0027ADD8 File Offset: 0x00278FD8
	public void Refresh_FontTexture()
	{
		if (this.text_Info != null && this.text_Info.enabled)
		{
			this.text_Info.enabled = false;
			this.text_Info.enabled = true;
		}
		if (this.text_PetContract != null && this.text_PetContract.enabled)
		{
			this.text_PetContract.enabled = false;
			this.text_PetContract.enabled = true;
		}
		if (this.text_Petskill != null && this.text_Petskill.enabled)
		{
			this.text_Petskill.enabled = false;
			this.text_Petskill.enabled = true;
		}
	}

	// Token: 0x060016FD RID: 5885 RVA: 0x0027AE90 File Offset: 0x00279090
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
		else if (this.DM.queueBarData[34].bActive)
		{
			long startTime = this.DM.queueBarData[34].StartTime;
			long target = startTime + (long)((ulong)this.DM.queueBarData[34].TotalTime);
			long notifyTime = 0L;
			this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(PetManager.Instance.ItemCraftID);
			Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
			CString cstring = StringManager.Instance.StaticString1024();
			StringManager.IntToStr(cstring, (long)PetManager.Instance.ItemCraftCount, 1, true);
			this.Cstr.ClearString();
			if (this.tmpFD.Fusion_Kind < 1)
			{
				this.Cstr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID).EquipName));
			}
			else
			{
				CString cstring2 = StringManager.Instance.StaticString1024();
				cstring2.ClearString();
				cstring2.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID).EquipName));
				cstring2.StringToFormat(this.DM.mStringTable.GetStringByID(14669u));
				cstring2.AppendFormat("{0}{1}");
				this.Cstr.StringToFormat(cstring2);
			}
			this.Cstr.StringToFormat(cstring);
			this.Cstr.AppendFormat(this.DM.mStringTable.GetStringByID(4048u));
			this.GUIM.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(14660u), this.Cstr.ToString());
			this.timeBar.gameObject.SetActive(true);
			this.text_Info.gameObject.SetActive(false);
			this.bFusion = true;
		}
		else
		{
			this.GUIM.RemoverTimeBaarToList(this.timeBar);
			this.timeBar.gameObject.SetActive(false);
			this.text_Info.gameObject.SetActive(true);
			this.bFusion = false;
		}
	}

	// Token: 0x060016FE RID: 5886 RVA: 0x0027B1BC File Offset: 0x002793BC
	public override void UpdateUI(int arg1, int arg2)
	{
		if (this.baseBuild == null)
		{
			return;
		}
		if (arg1 == 1)
		{
			if (this.DM.queueBarData[34].bActive)
			{
				long startTime = this.DM.queueBarData[34].StartTime;
				long target = startTime + (long)((ulong)this.DM.queueBarData[34].TotalTime);
				long notifyTime = 0L;
				this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(PetManager.Instance.ItemCraftID);
				Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
				CString cstring = StringManager.Instance.StaticString1024();
				StringManager.IntToStr(cstring, (long)PetManager.Instance.ItemCraftCount, 1, true);
				this.Cstr.ClearString();
				if (this.tmpFD.Fusion_Kind < 1)
				{
					this.Cstr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID).EquipName));
				}
				else
				{
					CString cstring2 = StringManager.Instance.StaticString1024();
					cstring2.ClearString();
					cstring2.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID).EquipName));
					cstring2.StringToFormat(this.DM.mStringTable.GetStringByID(14669u));
					cstring2.AppendFormat("{0}{1}");
					this.Cstr.StringToFormat(cstring2);
				}
				this.Cstr.StringToFormat(cstring);
				this.Cstr.AppendFormat(this.DM.mStringTable.GetStringByID(4048u));
				this.GUIM.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(14660u), this.Cstr.ToString());
				this.timeBar.gameObject.SetActive(true);
				this.text_Info.gameObject.SetActive(false);
				this.bFusion = true;
			}
			else
			{
				this.GUIM.RemoverTimeBaarToList(this.timeBar);
				this.timeBar.gameObject.SetActive(false);
				this.text_Info.gameObject.SetActive(true);
				this.bFusion = false;
			}
		}
	}

	// Token: 0x060016FF RID: 5887 RVA: 0x0027B454 File Offset: 0x00279654
	public void OnTimer(UITimeBar sender)
	{
		this.timeBar.gameObject.SetActive(false);
		this.text_Info.gameObject.SetActive(true);
		this.bFusion = false;
	}

	// Token: 0x06001700 RID: 5888 RVA: 0x0027B48C File Offset: 0x0027968C
	public void OnNotify(UITimeBar sender)
	{
	}

	// Token: 0x06001701 RID: 5889 RVA: 0x0027B490 File Offset: 0x00279690
	public void Onfunc(UITimeBar sender)
	{
		if (sender.m_TimerSpriteType == eTimerSpriteType.Speed)
		{
			this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 34, false);
		}
	}

	// Token: 0x06001702 RID: 5890 RVA: 0x0027B4B0 File Offset: 0x002796B0
	public void OnCancel(UITimeBar sender)
	{
		this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(14662u), this.DM.mStringTable.GetStringByID(14663u), 1, 0, this.DM.mStringTable.GetStringByID(3925u), this.DM.mStringTable.GetStringByID(3926u));
	}

	// Token: 0x06001703 RID: 5891 RVA: 0x0027B520 File Offset: 0x00279720
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 == 1)
			{
				if (GUIManager.Instance.ShowUILock(EUILock.PetFusion))
				{
					PetManager.Instance.SendItemCraft_Cancel();
				}
			}
		}
	}

	// Token: 0x06001704 RID: 5892 RVA: 0x0027B564 File Offset: 0x00279764
	private void Start()
	{
	}

	// Token: 0x06001705 RID: 5893 RVA: 0x0027B568 File Offset: 0x00279768
	private void Update()
	{
	}

	// Token: 0x040044D8 RID: 17624
	private DataManager DM;

	// Token: 0x040044D9 RID: 17625
	private GUIManager GUIM;

	// Token: 0x040044DA RID: 17626
	private PetManager PM;

	// Token: 0x040044DB RID: 17627
	private Transform GameT;

	// Token: 0x040044DC RID: 17628
	private Transform mFusionbuildingT;

	// Token: 0x040044DD RID: 17629
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x040044DE RID: 17630
	public BuildingWindow baseBuild;

	// Token: 0x040044DF RID: 17631
	public UITimeBar timeBar;

	// Token: 0x040044E0 RID: 17632
	private Door door;

	// Token: 0x040044E1 RID: 17633
	private UIButton btn_PetContract;

	// Token: 0x040044E2 RID: 17634
	private UIButton btn_Petskill;

	// Token: 0x040044E3 RID: 17635
	private Image Img_Lock;

	// Token: 0x040044E4 RID: 17636
	private Image Img_Line;

	// Token: 0x040044E5 RID: 17637
	private UIText text_Info;

	// Token: 0x040044E6 RID: 17638
	private UIText text_PetContract;

	// Token: 0x040044E7 RID: 17639
	private UIText text_Petskill;

	// Token: 0x040044E8 RID: 17640
	private CString Cstr;

	// Token: 0x040044E9 RID: 17641
	private int B_ID;

	// Token: 0x040044EA RID: 17642
	private bool bFusion;

	// Token: 0x040044EB RID: 17643
	private FusionData tmpFD;

	// Token: 0x040044EC RID: 17644
	private Equip tmpEquip;

	// Token: 0x040044ED RID: 17645
	private PetTbl tmpPetD;

	// Token: 0x040044EE RID: 17646
	private string AssetName;
}
