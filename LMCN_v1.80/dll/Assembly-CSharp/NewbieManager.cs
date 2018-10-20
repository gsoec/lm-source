using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200078D RID: 1933
public class NewbieManager
{
	// Token: 0x060025BF RID: 9663 RVA: 0x0042EBA0 File Offset: 0x0042CDA0
	protected NewbieManager()
	{
	}

	// Token: 0x170000FE RID: 254
	// (get) Token: 0x060025C1 RID: 9665 RVA: 0x0042EC78 File Offset: 0x0042CE78
	public NewbieController UIController
	{
		get
		{
			return this.Controller;
		}
	}

	// Token: 0x170000FF RID: 255
	// (get) Token: 0x060025C2 RID: 9666 RVA: 0x0042EC80 File Offset: 0x0042CE80
	public static bool HasFlag
	{
		get
		{
			return !DataManager.Instance.CheckPrizeFlag(1);
		}
	}

	// Token: 0x17000100 RID: 256
	// (get) Token: 0x060025C3 RID: 9667 RVA: 0x0042EC90 File Offset: 0x0042CE90
	public static bool IsNewbie
	{
		get
		{
			return NewbieManager.m_Self != null && NewbieManager.HasFlag;
		}
	}

	// Token: 0x17000101 RID: 257
	// (get) Token: 0x060025C4 RID: 9668 RVA: 0x0042ECA4 File Offset: 0x0042CEA4
	public static bool IsTeaching
	{
		get
		{
			return NewbieManager.m_Self != null && NewbieManager.m_Self.TeachFlag != 0UL;
		}
	}

	// Token: 0x060025C5 RID: 9669 RVA: 0x0042ECC4 File Offset: 0x0042CEC4
	public static void CheckNewbieLive()
	{
		if (!DataManager.Instance.CheckPrizeFlag(6))
		{
			DataManager instance = DataManager.Instance;
			instance.RoleAttr.Guide = (instance.RoleAttr.Guide & 18446744073709551611UL);
		}
		if (!DataManager.Instance.CheckPrizeFlag(7))
		{
			DataManager instance2 = DataManager.Instance;
			instance2.RoleAttr.Guide = (instance2.RoleAttr.Guide & 18446744073709289471UL);
		}
		if (!DataManager.Instance.CheckPrizeFlag(11))
		{
			DataManager instance3 = DataManager.Instance;
			instance3.RoleAttr.Guide = (instance3.RoleAttr.Guide & 18446744073709027327UL);
		}
		if (!DataManager.Instance.CheckPrizeFlag(12))
		{
			DataManager instance4 = DataManager.Instance;
			instance4.RoleAttr.Guide = (instance4.RoleAttr.Guide & 18446744073708503039UL);
		}
		if (!DataManager.Instance.CheckPrizeFlag(13))
		{
			DataManager instance5 = DataManager.Instance;
			instance5.RoleAttr.Guide = (instance5.RoleAttr.Guide & 18446744073707454463UL);
		}
		if (!DataManager.Instance.CheckPrizeFlag(14))
		{
			DataManager instance6 = DataManager.Instance;
			instance6.RoleAttr.Guide = (instance6.RoleAttr.Guide & 18446744073705357311UL);
		}
		if (!DataManager.Instance.CheckPrizeFlag(15))
		{
			DataManager instance7 = DataManager.Instance;
			instance7.RoleAttr.Guide = (instance7.RoleAttr.Guide & 18446744073692774399UL);
		}
		if (!DataManager.Instance.CheckPrizeFlag(16))
		{
			DataManager instance8 = DataManager.Instance;
			instance8.RoleAttr.Guide = (instance8.RoleAttr.Guide & 18446744073675997183UL);
		}
		if (!DataManager.Instance.CheckPrizeFlag(17))
		{
			DataManager instance9 = DataManager.Instance;
			instance9.RoleAttr.Guide = (instance9.RoleAttr.Guide & 18446744073642442751UL);
		}
		if (!DataManager.Instance.CheckPrizeFlag(18))
		{
			DataManager instance10 = DataManager.Instance;
			instance10.RoleAttr.Guide = (instance10.RoleAttr.Guide & 18446744073575333887UL);
		}
		if (!DataManager.Instance.CheckPrizeFlag(19))
		{
			DataManager instance11 = DataManager.Instance;
			instance11.RoleAttr.Guide = (instance11.RoleAttr.Guide & 18446744073441116159UL);
		}
		if (!DataManager.Instance.CheckPrizeFlag(22))
		{
			DataManager instance12 = DataManager.Instance;
			instance12.RoleAttr.Guide = (instance12.RoleAttr.Guide & 18446744073172680703UL);
		}
		if (!DataManager.Instance.CheckPrizeFlag(23))
		{
			DataManager instance13 = DataManager.Instance;
			instance13.RoleAttr.Guide = (instance13.RoleAttr.Guide & 18446744072635809791UL);
		}
		if (!DataManager.Instance.CheckPrizeFlag(24))
		{
			DataManager instance14 = DataManager.Instance;
			instance14.RoleAttr.Guide = (instance14.RoleAttr.Guide & 18446744071562067967UL);
		}
		NewbieManager.PreCheckFlag();
		if (DataManager.StageDataController.StageRecord[0] == 0)
		{
			DataManager instance15 = DataManager.Instance;
			instance15.RoleAttr.Guide = (instance15.RoleAttr.Guide & 18446744073709551487UL);
		}
		NewbieManager.Create();
	}

	// Token: 0x060025C6 RID: 9670 RVA: 0x0042EF80 File Offset: 0x0042D180
	private static bool CheckGuideEx(EGuideFlagEx flag)
	{
		return (DataManager.Instance.RoleAttr.GuideEx & 1u << (int)flag) != 0u;
	}

	// Token: 0x060025C7 RID: 9671 RVA: 0x0042EFA0 File Offset: 0x0042D1A0
	private static void PreCheckFlag()
	{
		if (!NewbieManager.CheckGuideEx(EGuideFlagEx.EGFE_PetInfo))
		{
			DataManager instance = DataManager.Instance;
			instance.RoleAttr.Guide = (instance.RoleAttr.Guide & 18446744069414584319UL);
		}
		if (!NewbieManager.CheckGuideEx(EGuideFlagEx.EGFE_PetFusion))
		{
			DataManager instance2 = DataManager.Instance;
			instance2.RoleAttr.Guide = (instance2.RoleAttr.Guide & 18446744065119617023UL);
		}
		if (!NewbieManager.CheckGuideEx(EGuideFlagEx.EGFE_PetTraining))
		{
			DataManager instance3 = DataManager.Instance;
			instance3.RoleAttr.Guide = (instance3.RoleAttr.Guide & 18446744056529682431UL);
		}
		if (!NewbieManager.CheckGuideEx(EGuideFlagEx.EGFE_PetSkill))
		{
			DataManager instance4 = DataManager.Instance;
			instance4.RoleAttr.Guide = (instance4.RoleAttr.Guide & 18446744039349813247UL);
		}
		if (!NewbieManager.CheckGuideEx(EGuideFlagEx.EGFE_Social_Invite))
		{
			DataManager instance5 = DataManager.Instance;
			instance5.RoleAttr.Guide = (instance5.RoleAttr.Guide & 18446744004990074879UL);
		}
		if (!NewbieManager.CheckGuideEx(EGuideFlagEx.EGFE_Social_Invite_After_Mission))
		{
			DataManager instance6 = DataManager.Instance;
			instance6.RoleAttr.Guide = (instance6.RoleAttr.Guide & 18446743936270598143UL);
		}
	}

	// Token: 0x060025C8 RID: 9672 RVA: 0x0042F0AC File Offset: 0x0042D2AC
	public static void Create()
	{
		if (NewbieManager.m_Self == null)
		{
			NewbieManager.m_Self = new NewbieManager();
		}
		NewbieManager.m_Self.Init();
	}

	// Token: 0x060025C9 RID: 9673 RVA: 0x0042F0CC File Offset: 0x0042D2CC
	public static void Free()
	{
		if (NewbieManager.m_Self != null)
		{
			NewbieManager.m_Self.Controller.FreeResource();
			UnityEngine.Object.Destroy(NewbieManager.m_Self.NewbieRoot);
			NewbieManager.m_Self = null;
		}
	}

	// Token: 0x060025CA RID: 9674 RVA: 0x0042F108 File Offset: 0x0042D308
	public static NewbieManager Get()
	{
		return NewbieManager.m_Self;
	}

	// Token: 0x060025CB RID: 9675 RVA: 0x0042F110 File Offset: 0x0042D310
	public static void UpdateNetwork(byte[] meg)
	{
		if (NewbieManager.m_Self == null)
		{
			return;
		}
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Technology)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					NewbieManager.m_Self.UIController.RebuildText();
				}
			}
			else
			{
				NewbieManager.CheckArmyCoord();
			}
		}
		else if (NewbieManager.m_Self.Step >= 4 && (DataManager.Instance.RoleAttr.PrizeFlag & 2u) == 0u)
		{
			NewbieManager.SendFinishNewbie();
		}
	}

	// Token: 0x060025CC RID: 9676 RVA: 0x0042F198 File Offset: 0x0042D398
	protected void Init()
	{
		this.DM = DataManager.Instance;
		this.SaveName = string.Format(NewbieManager.NEWBIE_SAVE_NAME, this.DM.RoleAttr.UserId);
		NewbieManager.EntryLock = false;
		this.bIsNewUser = false;
		if (this.UserID != this.DM.RoleAttr.UserId)
		{
			this.UserID = this.DM.RoleAttr.UserId;
			this.CurFakeData = 0;
			this.FakeBuildStep = 0;
			this.FakeMarkStep = 0;
			this.FakeBuildLvStep = 0;
			this.TeachStep = 0;
			NewbieManager.bQueuePopMenu = false;
			this.bIsNewUser = true;
			this.WorldTeach_Point = 0L;
			NewbieManager.NB_SpawnPetTimeCache = 0L;
		}
		if (this.Controller == null)
		{
			this.NewbieRoot = new GameObject("Newbie");
			RectTransform rectTransform = this.NewbieRoot.AddComponent<RectTransform>();
			rectTransform.anchorMax = Vector2.zero;
			rectTransform.anchorMin = Vector2.zero;
			rectTransform.pivot = Vector2.zero;
			this.NewbieRoot.transform.SetParent(GUIManager.Instance.m_NewbieLayer, false);
			this.Controller = this.NewbieRoot.AddComponent<NewbieController>();
			this.Controller.pManager = this;
		}
		if (this.bIsNewUser)
		{
			this.Controller.PreClickFlag = 0;
		}
		if (NewbieManager.IsNewbie)
		{
			if (this.bIsNewUser)
			{
				this.Step = PlayerPrefs.GetInt(this.SaveName);
				if (this.Step >= 4)
				{
					this.DM.ResetLocalSave();
					this.Step = 0;
				}
				else
				{
					GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Newbie);
				}
				if (this.Step == 0)
				{
					PlayerPrefs.SetInt(this.SaveName, 1);
				}
				this.LoadTeachFlag();
			}
			if (!DataManager.Instance.MySysSetting.bShowTimeBar)
			{
				DataManager.Instance.MySysSetting.bShowTimeBar = true;
			}
			this.DM.MySysSetting.bShowMission = true;
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
		}
		else
		{
			this.Step = 4;
			if (this.bIsNewUser)
			{
				this.LoadTeachFlag();
				this.LockControl(false);
			}
			else if (NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door != null)
				{
					door.ForceQueueBarOpenClose(false);
				}
			}
			else if (NewbieManager.IsTeachWorking(ETeachKind.TURBO))
			{
				DataManager.Instance.MySysSetting.bShowTimeBar = true;
			}
		}
		if (this.ActionMap.Count == 0)
		{
			this.ActionMap.Add(0, new NewbieManager.NewbieNode(2f, new NewbieManager.ActiveStep(this.WaitForIntoScene)));
			this.ActionMap.Add(100, new NewbieManager.NewbieNode(0.5f, new NewbieManager.ActiveStep(this.ShowDrama)));
			this.ActionMap.Add(101, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.FirstIntoDoor)));
			this.ActionMap.Add(102, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.Step1TargetGoal)));
			this.ActionMap.Add(103, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetManor)));
			this.ActionMap.Add(104, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.FirstIntoSuitBuilding)));
			this.ActionMap.Add(105, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.FirstIntoBarrack)));
			this.ActionMap.Add(106, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.ExitBarrackToDoor)));
			this.ActionMap.Add(107, new NewbieManager.NewbieNode(3f, new NewbieManager.ActiveStep(this.WaitBuilding)));
			this.ActionMap.Add(108, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.Step1TargetPrize)));
			this.ActionMap.Add(200, new NewbieManager.NewbieNode(1f, new NewbieManager.ActiveStep(this.IntoUpdateCastle)));
			this.ActionMap.Add(201, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Step2TargetGoal)));
			this.ActionMap.Add(202, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetCastle)));
			this.ActionMap.Add(203, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoUICastle)));
			this.ActionMap.Add(204, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoCastleUpgrade)));
			this.ActionMap.Add(205, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.CastleUpgradeRightNow)));
			this.ActionMap.Add(206, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoLevelUpUI)));
			this.ActionMap.Add(207, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Step2TargetPrize)));
			this.ActionMap.Add(300, new NewbieManager.NewbieNode(1f, new NewbieManager.ActiveStep(this.IntoGetPrize)));
			this.ActionMap.Add(301, new NewbieManager.NewbieNode(1f, new NewbieManager.ActiveStep(this.VipLevelUp)));
			this.ActionMap.Add(302, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.VipLevelUp2)));
			this.ActionMap.Add(303, new NewbieManager.NewbieNode(1f, new NewbieManager.ActiveStep(this.Step3Talk2)));
			this.ActionMap.Add(304, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetPrize)));
			this.ActionMap.Add(1000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.SpawnSoldier)));
			this.ActionMap.Add(1001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetSoldierItem)));
			this.ActionMap.Add(1002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetTrain)));
			this.ActionMap.Add(1003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.FinishTrain)));
			this.ActionMap.Add(1004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.FinishTrain2)));
			this.ActionMap.Add(2000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Into_WarScout)));
			this.ActionMap.Add(2001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.WarScout_TargetCastle)));
			this.ActionMap.Add(2002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetScout)));
			this.ActionMap.Add(2003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetScoutInfo)));
			this.ActionMap.Add(2004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetScoutInfoExit)));
			this.ActionMap.Add(2005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Into_WarAttack)));
			this.ActionMap.Add(2006, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Team_Select)));
			this.ActionMap.Add(2007, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Soldier_Select)));
			this.ActionMap.Add(2008, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Fight_Select)));
			this.ActionMap.Add(3000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoArena)));
			this.ActionMap.Add(3001, new NewbieManager.NewbieNode(1.2f, new NewbieManager.ActiveStep(this.GoArena2)));
			this.ActionMap.Add(3002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoArena3)));
			this.ActionMap.Add(3003, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GoArena4)));
			this.ActionMap.Add(3004, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GoArena5)));
			this.ActionMap.Add(4000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoCollege)));
			this.ActionMap.Add(4001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetMilitary)));
			this.ActionMap.Add(4002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetTopSkill)));
			this.ActionMap.Add(4003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetTechInfo)));
			this.ActionMap.Add(4004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TechUpgrade)));
			this.ActionMap.Add(4005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TechFinish)));
			this.ActionMap.Add(5000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Rename)));
			this.ActionMap.Add(6000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GotoWorld)));
			this.ActionMap.Add(6001, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GotoWorld2)));
			this.ActionMap.Add(6002, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GotoWorld3)));
			this.ActionMap.Add(6003, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GotoWorld4)));
			this.ActionMap.Add(7000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GotoSmith)));
			this.ActionMap.Add(7001, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GotoSmith2)));
			this.ActionMap.Add(7002, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GotoSmith3)));
			this.ActionMap.Add(8000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Battle_Before)));
			this.ActionMap.Add(8001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetLord)));
			this.ActionMap.Add(8002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoStageInfo)));
			this.ActionMap.Add(8003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.BattleSelect_S1)));
			this.ActionMap.Add(8004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.BattleSelect_S2)));
			this.ActionMap.Add(8005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.BattleSelect_Start)));
			this.ActionMap.Add(8006, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.Battle_StartNewbie)));
			this.ActionMap.Add(8007, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.Battle_NextLevel)));
			this.ActionMap.Add(8008, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Battle_FirstUltra)));
			this.ActionMap.Add(8009, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.Battle_NextLevel_FullScreen)));
			this.ActionMap.Add(8010, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Battle_SecondUltra)));
			this.ActionMap.Add(8011, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Battle_ThirdUltra)));
			this.ActionMap.Add(9000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.WorldHunt1)));
			this.ActionMap.Add(9001, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.WorldHunt2)));
			this.ActionMap.Add(9002, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.WorldHunt3)));
			this.ActionMap.Add(10000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.CheckPutOnEquip)));
			this.ActionMap.Add(10001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.ClickHeroList)));
			this.ActionMap.Add(10002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.ClickHeroFromList)));
			this.ActionMap.Add(10003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.ClickEquipBtn)));
			this.ActionMap.Add(10004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.ClickPutOn)));
			this.ActionMap.Add(10005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank1)));
			this.ActionMap.Add(10006, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank2)));
			this.ActionMap.Add(10007, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank3)));
			this.ActionMap.Add(10008, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank4)));
			this.ActionMap.Add(10009, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank5)));
			this.ActionMap.Add(10010, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank6)));
			this.ActionMap.Add(10011, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank7)));
			this.ActionMap.Add(11000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.WorldAttack1)));
			this.ActionMap.Add(11001, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.WorldAttack2)));
			this.ActionMap.Add(11002, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.WorldAttack3)));
			this.ActionMap.Add(11003, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.WorldAttack4)));
			this.ActionMap.Add(12000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GetNewHero)));
			this.ActionMap.Add(12001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GetNewHero2)));
			this.ActionMap.Add(12002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GetNewHero3)));
			this.ActionMap.Add(12003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GetNewHero4)));
			this.ActionMap.Add(13000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TWipeOut)));
			this.ActionMap.Add(13001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TWipeOut2)));
			this.ActionMap.Add(13002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TWipeOut3)));
			this.ActionMap.Add(13003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TWipeOut4)));
			this.ActionMap.Add(13004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TWipeOut5)));
			this.ActionMap.Add(13005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TWipeOut6)));
			this.ActionMap.Add(14000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Turbo1)));
			this.ActionMap.Add(14001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Turbo2)));
			this.ActionMap.Add(14002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Turbo3)));
			this.ActionMap.Add(14003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Turbo4)));
			this.ActionMap.Add(15000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoldGuy1)));
			this.ActionMap.Add(15001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoldGuy2)));
			this.ActionMap.Add(15002, new NewbieManager.NewbieNode(1f, new NewbieManager.ActiveStep(this.GoldGuy3)));
			this.ActionMap.Add(16000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoActivity)));
			this.ActionMap.Add(16001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoActivity2)));
			this.ActionMap.Add(17000, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GoAutoBattle)));
			this.ActionMap.Add(18000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoEliteStage1)));
			this.ActionMap.Add(18001, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GoEliteStage2)));
			this.ActionMap.Add(18002, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GoEliteStage3)));
			this.ActionMap.Add(19000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoArmyHole)));
			this.ActionMap.Add(19001, new NewbieManager.NewbieNode(1.2f, new NewbieManager.ActiveStep(this.GoArmyHole2)));
			this.ActionMap.Add(19002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoArmyHole3)));
			this.ActionMap.Add(20000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoBlackMarket1)));
			this.ActionMap.Add(20001, new NewbieManager.NewbieNode(1.2f, new NewbieManager.ActiveStep(this.GoBlackMarket2)));
			this.ActionMap.Add(20002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoBlackMarket3)));
			this.ActionMap.Add(21000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoTroopMemory)));
			this.ActionMap.Add(21001, new NewbieManager.NewbieNode(1.2f, new NewbieManager.ActiveStep(this.GoTroopMemory2)));
			this.ActionMap.Add(21002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoTroopMemory3)));
			this.ActionMap.Add(22000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDeShield)));
			this.ActionMap.Add(22001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDeShield2)));
			this.ActionMap.Add(22002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDeShield3)));
			this.ActionMap.Add(23000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoCoord)));
			this.ActionMap.Add(23001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoCoord2)));
			this.ActionMap.Add(23002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoCoord3)));
			this.ActionMap.Add(23003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoCoord4)));
			this.ActionMap.Add(24000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.PressX)));
			this.ActionMap.Add(25000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoMetallurgy)));
			this.ActionMap.Add(25001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoMetallurgy2)));
			this.ActionMap.Add(25002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoMetallurgy3)));
			this.ActionMap.Add(25003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoMetallurgy4)));
			this.ActionMap.Add(25004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoMetallurgy5)));
			this.ActionMap.Add(25005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoMetallurgy6)));
			this.ActionMap.Add(26000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleNormal)));
			this.ActionMap.Add(26001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleNormal2)));
			this.ActionMap.Add(26002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleNormal3)));
			this.ActionMap.Add(26003, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GoGambleNormal4)));
			this.ActionMap.Add(26004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleNormal5)));
			this.ActionMap.Add(26005, new NewbieManager.NewbieNode(4f, new NewbieManager.ActiveStep(this.GoGambleNormal6)));
			this.ActionMap.Add(26006, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleNormal7)));
			this.ActionMap.Add(26007, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleNormal8)));
			this.ActionMap.Add(27000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleElite)));
			this.ActionMap.Add(27001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleElite2)));
			this.ActionMap.Add(27002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleElite3)));
			this.ActionMap.Add(28000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull)));
			this.ActionMap.Add(28001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull2)));
			this.ActionMap.Add(28002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull3)));
			this.ActionMap.Add(28003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull4)));
			this.ActionMap.Add(28004, new NewbieManager.NewbieNode(2.5f, new NewbieManager.ActiveStep(this.GoDareFull5)));
			this.ActionMap.Add(28005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull6)));
			this.ActionMap.Add(28006, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull7)));
			this.ActionMap.Add(28007, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull8)));
			this.ActionMap.Add(28008, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull9)));
			this.ActionMap.Add(28009, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull10)));
			this.ActionMap.Add(28010, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull11)));
			this.ActionMap.Add(28011, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull12)));
			this.ActionMap.Add(28012, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull13)));
			this.ActionMap.Add(29000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareLead)));
			this.ActionMap.Add(29001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareLead2)));
			this.ActionMap.Add(29002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareLead3)));
			this.ActionMap.Add(29003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareLead4)));
			this.ActionMap.Add(30000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSpawnSoliderDetail)));
			this.ActionMap.Add(30001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSpawnSoliderDetail2)));
			this.ActionMap.Add(31000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoTreasBoxUpgrade)));
			this.ActionMap.Add(31001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoTreasBoxUpgrade2)));
			this.ActionMap.Add(31002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoTreasBoxUpgrade3)));
			this.ActionMap.Add(32000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSpawnPet)));
			this.ActionMap.Add(32001, new NewbieManager.NewbieNode(1f, new NewbieManager.ActiveStep(this.GoSpawnPet2)));
			this.ActionMap.Add(32002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSpawnPet3)));
			this.ActionMap.Add(32003, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GoSpawnPet4)));
			this.ActionMap.Add(32004, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GoSpawnPet5)));
			this.ActionMap.Add(33000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoPetInfo)));
			this.ActionMap.Add(33001, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GoPetInfo2)));
			this.ActionMap.Add(34000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoPetFusion)));
			this.ActionMap.Add(34001, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GoPetFusion2)));
			this.ActionMap.Add(35000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoPetTraining)));
			this.ActionMap.Add(35001, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GoPetTraining2)));
			this.ActionMap.Add(36000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoPetSkill)));
			this.ActionMap.Add(36001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoPetSkill2)));
			this.ActionMap.Add(36002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoPetSkill3)));
			this.ActionMap.Add(36003, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GoPetSkill4)));
			this.ActionMap.Add(37000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSocialInvite)));
			this.ActionMap.Add(37001, new NewbieManager.NewbieNode(0f, new NewbieManager.ActiveStep(this.GoSocialInvite2)));
			this.ActionMap.Add(37002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSocialInvite3)));
			this.ActionMap.Add(38000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSocialInviteII)));
			this.ActionMap.Add(38001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSocialInviteII2)));
			this.ActionMap.Add(38002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSocialInviteII3)));
			this.ActionMap.Add(38003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSocialInviteII4)));
		}
		if (this.ClickActionMap.Count == 0)
		{
			this.ClickActionMap.Add(100, new NewbieManager.ActiveStep(this.RecvShowDrama));
			this.ClickActionMap.Add(101, new NewbieManager.ActiveStep(this.RecvFirstIntoDoor));
			this.ClickActionMap.Add(102, new NewbieManager.ActiveStep(this.RecvStep1TargetGoal));
			this.ClickActionMap.Add(105, new NewbieManager.ActiveStep(this.RecvBarrackUpgrade));
			this.ClickActionMap.Add(106, new NewbieManager.ActiveStep(this.RecvBarrackToDoor));
			this.ClickActionMap.Add(108, new NewbieManager.ActiveStep(this.Step1RecvTargetPrize));
			this.ClickActionMap.Add(200, new NewbieManager.ActiveStep(this.RecvIntoUpdateCastle));
			this.ClickActionMap.Add(201, new NewbieManager.ActiveStep(this.RecvStep2TargetGoal));
			this.ClickActionMap.Add(203, new NewbieManager.ActiveStep(this.RecvIntoUICastle));
			this.ClickActionMap.Add(204, new NewbieManager.ActiveStep(this.RecvIntoCastleUpgrade));
			this.ClickActionMap.Add(205, new NewbieManager.ActiveStep(this.RecvCastleUpgradeRightNow));
			this.ClickActionMap.Add(206, new NewbieManager.ActiveStep(this.RecvIntoLevelUpUI));
			this.ClickActionMap.Add(207, new NewbieManager.ActiveStep(this.Step2RecvTargetPrize));
			this.ClickActionMap.Add(300, new NewbieManager.ActiveStep(this.RecvIntoGetPrize));
			this.ClickActionMap.Add(301, new NewbieManager.ActiveStep(this.RecvVipLevelUp));
			this.ClickActionMap.Add(302, new NewbieManager.ActiveStep(this.RecvVipLevelUp2));
			this.ClickActionMap.Add(303, new NewbieManager.ActiveStep(this.RecvStep3Talk2));
			this.ClickActionMap.Add(304, new NewbieManager.ActiveStep(this.RecvTargetPrize));
			this.ClickActionMap.Add(1000, new NewbieManager.ActiveStep(this.RecvSpawnSoldier));
			this.ClickActionMap.Add(1001, new NewbieManager.ActiveStep(this.RecvTargetSoldierItem));
			this.ClickActionMap.Add(1002, new NewbieManager.ActiveStep(this.RecvTargetTrain));
			this.ClickActionMap.Add(1003, new NewbieManager.ActiveStep(this.RecvFinishTrain));
			this.ClickActionMap.Add(1004, new NewbieManager.ActiveStep(this.RecvFinishTrain2));
			this.ClickActionMap.Add(2000, new NewbieManager.ActiveStep(this.Recv_Into_WarScout));
			this.ClickActionMap.Add(2001, new NewbieManager.ActiveStep(this.Recv_WarScout_TargetCastle));
			this.ClickActionMap.Add(2002, new NewbieManager.ActiveStep(this.RecvTargetScout));
			this.ClickActionMap.Add(2003, new NewbieManager.ActiveStep(this.RecvTargetScoutInfo));
			this.ClickActionMap.Add(2004, new NewbieManager.ActiveStep(this.RecvTargetScoutInfoExit));
			this.ClickActionMap.Add(2005, new NewbieManager.ActiveStep(this.Recv_Into_WarAttack));
			this.ClickActionMap.Add(2006, new NewbieManager.ActiveStep(this.Recv_Team_Select));
			this.ClickActionMap.Add(2007, new NewbieManager.ActiveStep(this.Recv_Soldier_Select));
			this.ClickActionMap.Add(2008, new NewbieManager.ActiveStep(this.Recv_Fight_Select));
			this.ClickActionMap.Add(3000, new NewbieManager.ActiveStep(this.RecvGoArena));
			this.ClickActionMap.Add(3001, new NewbieManager.ActiveStep(this.RecvGoArena2));
			this.ClickActionMap.Add(3002, new NewbieManager.ActiveStep(this.RecvGoArena3));
			this.ClickActionMap.Add(3003, new NewbieManager.ActiveStep(this.RecvGoArena4));
			this.ClickActionMap.Add(3004, new NewbieManager.ActiveStep(this.RecvGoArena5));
			this.ClickActionMap.Add(4000, new NewbieManager.ActiveStep(this.RecvIntoCollege));
			this.ClickActionMap.Add(4001, new NewbieManager.ActiveStep(this.RecvTargetMilitary));
			this.ClickActionMap.Add(4002, new NewbieManager.ActiveStep(this.RecvTargetTopSkill));
			this.ClickActionMap.Add(4003, new NewbieManager.ActiveStep(this.RecvTargetTechInfo));
			this.ClickActionMap.Add(4004, new NewbieManager.ActiveStep(this.RecvTechUpgrade));
			this.ClickActionMap.Add(4005, new NewbieManager.ActiveStep(this.RecvTechFinish));
			this.ClickActionMap.Add(5000, new NewbieManager.ActiveStep(this.RecvRename));
			this.ClickActionMap.Add(6000, new NewbieManager.ActiveStep(this.RecvGotoWorld));
			this.ClickActionMap.Add(6001, new NewbieManager.ActiveStep(this.RecvGotoWorld2));
			this.ClickActionMap.Add(6002, new NewbieManager.ActiveStep(this.RecvGotoWorld3));
			this.ClickActionMap.Add(6003, new NewbieManager.ActiveStep(this.RecvGotoWorld4));
			this.ClickActionMap.Add(7000, new NewbieManager.ActiveStep(this.RecvGotoSmith));
			this.ClickActionMap.Add(7001, new NewbieManager.ActiveStep(this.RecvGotoSmith2));
			this.ClickActionMap.Add(7002, new NewbieManager.ActiveStep(this.RecvGotoSmith3));
			this.ClickActionMap.Add(8000, new NewbieManager.ActiveStep(this.Recv_Battle_Before));
			this.ClickActionMap.Add(8001, new NewbieManager.ActiveStep(this.Recv_TargetLord));
			this.ClickActionMap.Add(8002, new NewbieManager.ActiveStep(this.Recv_IntoStageInfo));
			this.ClickActionMap.Add(8003, new NewbieManager.ActiveStep(this.Recv_BattleSelect_S1));
			this.ClickActionMap.Add(8004, new NewbieManager.ActiveStep(this.Recv_BattleSelect_S2));
			this.ClickActionMap.Add(8005, new NewbieManager.ActiveStep(this.Recv_BattleSelect_Start));
			this.ClickActionMap.Add(8007, new NewbieManager.ActiveStep(this.Recv_Battle_NextLevel));
			this.ClickActionMap.Add(8008, new NewbieManager.ActiveStep(this.Recv_Battle_FirstUltra));
			this.ClickActionMap.Add(8009, new NewbieManager.ActiveStep(this.Recv_Battle_NextLevel));
			this.ClickActionMap.Add(8010, new NewbieManager.ActiveStep(this.Recv_Battle_SecondUltra));
			this.ClickActionMap.Add(8011, new NewbieManager.ActiveStep(this.Recv_Battle_ThirdUltra));
			this.ClickActionMap.Add(9000, new NewbieManager.ActiveStep(this.RecvWorldHunt1));
			this.ClickActionMap.Add(9001, new NewbieManager.ActiveStep(this.RecvWorldHunt2));
			this.ClickActionMap.Add(9002, new NewbieManager.ActiveStep(this.RecvWorldHunt3));
			this.ClickActionMap.Add(10000, new NewbieManager.ActiveStep(this.RecvCheckPutOnEquip));
			this.ClickActionMap.Add(10001, new NewbieManager.ActiveStep(this.RecvClickHeroList));
			this.ClickActionMap.Add(10002, new NewbieManager.ActiveStep(this.RecvClickHeroFromList));
			this.ClickActionMap.Add(10003, new NewbieManager.ActiveStep(this.RecvClickEquipBtn));
			this.ClickActionMap.Add(10004, new NewbieManager.ActiveStep(this.RecvClickPutOn));
			this.ClickActionMap.Add(10005, new NewbieManager.ActiveStep(this.RecvUpdateRank1));
			this.ClickActionMap.Add(10006, new NewbieManager.ActiveStep(this.RecvUpdateRank2));
			this.ClickActionMap.Add(10007, new NewbieManager.ActiveStep(this.RecvUpdateRank3));
			this.ClickActionMap.Add(10008, new NewbieManager.ActiveStep(this.RecvUpdateRank4));
			this.ClickActionMap.Add(10009, new NewbieManager.ActiveStep(this.RecvUpdateRank5));
			this.ClickActionMap.Add(10010, new NewbieManager.ActiveStep(this.RecvUpdateRank6));
			this.ClickActionMap.Add(10011, new NewbieManager.ActiveStep(this.RecvUpdateRank7));
			this.ClickActionMap.Add(11000, new NewbieManager.ActiveStep(this.RecvWorldAttack1));
			this.ClickActionMap.Add(11001, new NewbieManager.ActiveStep(this.RecvWorldAttack2));
			this.ClickActionMap.Add(11002, new NewbieManager.ActiveStep(this.RecvWorldAttack3));
			this.ClickActionMap.Add(11003, new NewbieManager.ActiveStep(this.RecvWorldAttack4));
			this.ClickActionMap.Add(12000, new NewbieManager.ActiveStep(this.RecvGetNewHero));
			this.ClickActionMap.Add(12001, new NewbieManager.ActiveStep(this.RecvGetNewHero2));
			this.ClickActionMap.Add(12002, new NewbieManager.ActiveStep(this.RecvGetNewHero3));
			this.ClickActionMap.Add(12003, new NewbieManager.ActiveStep(this.RecvGetNewHero4));
			this.ClickActionMap.Add(13000, new NewbieManager.ActiveStep(this.RecvTWipeOut));
			this.ClickActionMap.Add(13001, new NewbieManager.ActiveStep(this.RecvTWipeOut2));
			this.ClickActionMap.Add(13002, new NewbieManager.ActiveStep(this.RecvTWipeOut3));
			this.ClickActionMap.Add(13003, new NewbieManager.ActiveStep(this.RecvTWipeOut4));
			this.ClickActionMap.Add(13004, new NewbieManager.ActiveStep(this.RecvTWipeOut5));
			this.ClickActionMap.Add(13005, new NewbieManager.ActiveStep(this.RecvTWipeOut6));
			this.ClickActionMap.Add(14000, new NewbieManager.ActiveStep(this.RecvTurbo1));
			this.ClickActionMap.Add(14001, new NewbieManager.ActiveStep(this.RecvTurbo2));
			this.ClickActionMap.Add(14002, new NewbieManager.ActiveStep(this.RecvTurbo3));
			this.ClickActionMap.Add(14003, new NewbieManager.ActiveStep(this.RecvTurbo4));
			this.ClickActionMap.Add(15000, new NewbieManager.ActiveStep(this.RecvGoldGuy1));
			this.ClickActionMap.Add(15001, new NewbieManager.ActiveStep(this.RecvGoldGuy2));
			this.ClickActionMap.Add(15002, new NewbieManager.ActiveStep(this.RecvGoldGuy3));
			this.ClickActionMap.Add(16000, new NewbieManager.ActiveStep(this.RecvIntoActivity));
			this.ClickActionMap.Add(16001, new NewbieManager.ActiveStep(this.RecvIntoActivity2));
			this.ClickActionMap.Add(17000, new NewbieManager.ActiveStep(this.RecvGoAutoBattle));
			this.ClickActionMap.Add(18000, new NewbieManager.ActiveStep(this.RecvGoEliteStage1));
			this.ClickActionMap.Add(18001, new NewbieManager.ActiveStep(this.RecvGoEliteStage2));
			this.ClickActionMap.Add(18002, new NewbieManager.ActiveStep(this.RecvGoEliteStage3));
			this.ClickActionMap.Add(19000, new NewbieManager.ActiveStep(this.RecvGoArmyHole));
			this.ClickActionMap.Add(19001, new NewbieManager.ActiveStep(this.RecvGoArmyHole2));
			this.ClickActionMap.Add(19002, new NewbieManager.ActiveStep(this.RecvGoArmyHole3));
			this.ClickActionMap.Add(20000, new NewbieManager.ActiveStep(this.RecvGoBlackMarket1));
			this.ClickActionMap.Add(20001, new NewbieManager.ActiveStep(this.RecvGoBlackMarket2));
			this.ClickActionMap.Add(20002, new NewbieManager.ActiveStep(this.RecvGoBlackMarket3));
			this.ClickActionMap.Add(21000, new NewbieManager.ActiveStep(this.RecvGoTroopMemory));
			this.ClickActionMap.Add(21001, new NewbieManager.ActiveStep(this.RecvGoTroopMemory2));
			this.ClickActionMap.Add(21002, new NewbieManager.ActiveStep(this.RecvGoTroopMemory3));
			this.ClickActionMap.Add(22000, new NewbieManager.ActiveStep(this.RecvGoDeShield));
			this.ClickActionMap.Add(22001, new NewbieManager.ActiveStep(this.RecvGoDeShield2));
			this.ClickActionMap.Add(22002, new NewbieManager.ActiveStep(this.RecvGoDeShield3));
			this.ClickActionMap.Add(23000, new NewbieManager.ActiveStep(this.RecvGoCoord));
			this.ClickActionMap.Add(23001, new NewbieManager.ActiveStep(this.RecvGoCoord2));
			this.ClickActionMap.Add(23002, new NewbieManager.ActiveStep(this.RecvGoCoord3));
			this.ClickActionMap.Add(23003, new NewbieManager.ActiveStep(this.RecvGoCoord4));
			this.ClickActionMap.Add(24000, new NewbieManager.ActiveStep(this.RecvPressX));
			this.ClickActionMap.Add(25000, new NewbieManager.ActiveStep(this.RecvGoMetallurgy));
			this.ClickActionMap.Add(25001, new NewbieManager.ActiveStep(this.RecvGoMetallurgy2));
			this.ClickActionMap.Add(25002, new NewbieManager.ActiveStep(this.RecvGoMetallurgy3));
			this.ClickActionMap.Add(25003, new NewbieManager.ActiveStep(this.RecvGoMetallurgy4));
			this.ClickActionMap.Add(25004, new NewbieManager.ActiveStep(this.RecvGoMetallurgy5));
			this.ClickActionMap.Add(25005, new NewbieManager.ActiveStep(this.RecvGoMetallurgy6));
			this.ClickActionMap.Add(26000, new NewbieManager.ActiveStep(this.RecvGoGambleNormal));
			this.ClickActionMap.Add(26001, new NewbieManager.ActiveStep(this.RecvGoGambleNormal2));
			this.ClickActionMap.Add(26002, new NewbieManager.ActiveStep(this.RecvGoGambleNormal3));
			this.ClickActionMap.Add(26003, new NewbieManager.ActiveStep(this.RecvGoGambleNormal4));
			this.ClickActionMap.Add(26004, new NewbieManager.ActiveStep(this.RecvGoGambleNormal5));
			this.ClickActionMap.Add(26005, new NewbieManager.ActiveStep(this.RecvGoGambleNormal6));
			this.ClickActionMap.Add(26006, new NewbieManager.ActiveStep(this.RecvGoGambleNormal7));
			this.ClickActionMap.Add(26007, new NewbieManager.ActiveStep(this.RecvGoGambleNormal8));
			this.ClickActionMap.Add(27000, new NewbieManager.ActiveStep(this.RecvGoGambleElite));
			this.ClickActionMap.Add(27001, new NewbieManager.ActiveStep(this.RecvGoGambleElite2));
			this.ClickActionMap.Add(27002, new NewbieManager.ActiveStep(this.RecvGoGambleElite3));
			this.ClickActionMap.Add(28000, new NewbieManager.ActiveStep(this.RecvGoDareFull));
			this.ClickActionMap.Add(28001, new NewbieManager.ActiveStep(this.RecvGoDareFull2));
			this.ClickActionMap.Add(28002, new NewbieManager.ActiveStep(this.RecvGoDareFull3));
			this.ClickActionMap.Add(28003, new NewbieManager.ActiveStep(this.RecvGoDareFull4));
			this.ClickActionMap.Add(28004, new NewbieManager.ActiveStep(this.RecvGoDareFull5));
			this.ClickActionMap.Add(28005, new NewbieManager.ActiveStep(this.RecvGoDareFull6));
			this.ClickActionMap.Add(28006, new NewbieManager.ActiveStep(this.RecvGoDareFull7));
			this.ClickActionMap.Add(28007, new NewbieManager.ActiveStep(this.RecvGoDareFull8));
			this.ClickActionMap.Add(28008, new NewbieManager.ActiveStep(this.RecvGoDareFull9));
			this.ClickActionMap.Add(28009, new NewbieManager.ActiveStep(this.RecvGoDareFull10));
			this.ClickActionMap.Add(28010, new NewbieManager.ActiveStep(this.RecvGoDareFull11));
			this.ClickActionMap.Add(28011, new NewbieManager.ActiveStep(this.RecvGoDareFull12));
			this.ClickActionMap.Add(28012, new NewbieManager.ActiveStep(this.RecvGoDareFull13));
			this.ClickActionMap.Add(29000, new NewbieManager.ActiveStep(this.RecvGoDareLead));
			this.ClickActionMap.Add(29001, new NewbieManager.ActiveStep(this.RecvGoDareLead2));
			this.ClickActionMap.Add(29002, new NewbieManager.ActiveStep(this.RecvGoDareLead3));
			this.ClickActionMap.Add(29003, new NewbieManager.ActiveStep(this.RecvGoDareLead4));
			this.ClickActionMap.Add(30000, new NewbieManager.ActiveStep(this.RecvGoSpawnSoliderDetail));
			this.ClickActionMap.Add(30001, new NewbieManager.ActiveStep(this.RecvGoSpawnSoliderDetail2));
			this.ClickActionMap.Add(31000, new NewbieManager.ActiveStep(this.RecvGoTreasBoxUpgrade));
			this.ClickActionMap.Add(31001, new NewbieManager.ActiveStep(this.RecvGoTreasBoxUpgrade2));
			this.ClickActionMap.Add(31002, new NewbieManager.ActiveStep(this.RecvGoTreasBoxUpgrade3));
			this.ClickActionMap.Add(32000, new NewbieManager.ActiveStep(this.RecvGoSpawnPet));
			this.ClickActionMap.Add(32001, new NewbieManager.ActiveStep(this.RecvGoSpawnPet2));
			this.ClickActionMap.Add(32002, new NewbieManager.ActiveStep(this.RecvGoSpawnPet3));
			this.ClickActionMap.Add(32003, new NewbieManager.ActiveStep(this.RecvGoSpawnPet4));
			this.ClickActionMap.Add(32004, new NewbieManager.ActiveStep(this.RecvGoSpawnPet5));
			this.ClickActionMap.Add(33000, new NewbieManager.ActiveStep(this.RecvGoPetInfo));
			this.ClickActionMap.Add(33001, new NewbieManager.ActiveStep(this.RecvGoPetInfo2));
			this.ClickActionMap.Add(34000, new NewbieManager.ActiveStep(this.RecvGoPetFusion));
			this.ClickActionMap.Add(34001, new NewbieManager.ActiveStep(this.RecvGoPetFusion2));
			this.ClickActionMap.Add(35000, new NewbieManager.ActiveStep(this.RecvGoPetTraining));
			this.ClickActionMap.Add(35001, new NewbieManager.ActiveStep(this.RecvGoPetTraining2));
			this.ClickActionMap.Add(36000, new NewbieManager.ActiveStep(this.RecvGoPetSkill));
			this.ClickActionMap.Add(36001, new NewbieManager.ActiveStep(this.RecvGoPetSkill2));
			this.ClickActionMap.Add(36002, new NewbieManager.ActiveStep(this.RecvGoPetSkill3));
			this.ClickActionMap.Add(36003, new NewbieManager.ActiveStep(this.RecvGoPetSkill4));
			this.ClickActionMap.Add(37000, new NewbieManager.ActiveStep(this.RecvGoSocialInvite));
			this.ClickActionMap.Add(37001, new NewbieManager.ActiveStep(this.RecvGoSocialInvite2));
			this.ClickActionMap.Add(37002, new NewbieManager.ActiveStep(this.RecvGoSocialInvite3));
			this.ClickActionMap.Add(38000, new NewbieManager.ActiveStep(this.RecvGoSocialInviteII));
			this.ClickActionMap.Add(38001, new NewbieManager.ActiveStep(this.RecvGoSocialInviteII2));
			this.ClickActionMap.Add(38002, new NewbieManager.ActiveStep(this.RecvGoSocialInviteII3));
			this.ClickActionMap.Add(38003, new NewbieManager.ActiveStep(this.RecvGoSocialInviteII4));
		}
	}

	// Token: 0x060025CD RID: 9677 RVA: 0x004323DC File Offset: 0x004305DC
	public static void CheckInitData()
	{
		if (NewbieManager.IsNewbie)
		{
			NewbieManager.m_Self.InitData();
		}
	}

	// Token: 0x060025CE RID: 9678 RVA: 0x004323F4 File Offset: 0x004305F4
	public void InitData()
	{
		if (this.Step >= 0 && this.Step < 4)
		{
			if (this.bIsNewUser)
			{
				if (this.Step != 0)
				{
					this.LockControl(true);
				}
				if (this.Step == 1)
				{
					this.CurFakeData = 1;
				}
				else if (this.Step == 2)
				{
					this.CurFakeData = 2;
				}
				else if (this.Step == 3)
				{
					this.CurFakeData = 4;
				}
				this.SetupFakeData((int)this.CurFakeData);
				if (this.Step < 2)
				{
					RoleBuildingData roleBuildingData = new RoleBuildingData(5, 0, 0);
					if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 5)
					{
						GUIManager.Instance.BuildingData.AllBuildsData[5] = roleBuildingData;
					}
					if (GUIManager.Instance.BuildingData.BuildIDCount != null)
					{
						GUIManager.Instance.BuildingData.BuildIDCount[6] = 0;
					}
				}
				if (this.Step < 3)
				{
					if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1)
					{
						GUIManager.Instance.BuildingData.AllBuildsData[1].Level = 1;
					}
					DataManager.MissionDataManager.SetCompleteWhileLogin(eMissionKind.Build);
					if (this.Step == 2)
					{
						this.FakeBuildLvStep = 2;
					}
				}
				if (this.Step >= 2)
				{
					DataManager.MissionDataManager.sendMissionComplete(6, 0);
				}
				if (this.Step == 3)
				{
					this.FakeBuildLvStep = 4;
					DataManager.MissionDataManager.sendMissionComplete(33, 0);
				}
			}
			else
			{
				if (this.FakeBuildLvStep < 1)
				{
					RoleBuildingData roleBuildingData2 = new RoleBuildingData(5, 0, 0);
					if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 5)
					{
						GUIManager.Instance.BuildingData.AllBuildsData[5] = roleBuildingData2;
					}
					if (GUIManager.Instance.BuildingData.BuildIDCount != null)
					{
						GUIManager.Instance.BuildingData.BuildIDCount[6] = 0;
					}
					GUIManager.Instance.BuildingData.UpdateBuildState(6, 255);
					DataManager.MissionDataManager.Reset();
					Array.Clear(DataManager.MissionDataManager.BoolMark, 0, DataManager.MissionDataManager.BoolMark.Length);
					GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
				}
				if (this.FakeBuildLvStep < 3)
				{
					if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1)
					{
						GUIManager.Instance.BuildingData.AllBuildsData[1].Level = 1;
					}
					GUIManager.Instance.BuildingData.UpdateBuildState(6, 255);
					if (this.FakeBuildLvStep == 2)
					{
						Array.Clear(DataManager.MissionDataManager.BoolMark, 0, DataManager.MissionDataManager.BoolMark.Length);
						DataManager.MissionDataManager.sendMissionComplete(6, 0);
					}
				}
				if (this.FakeBuildLvStep >= 3)
				{
					Array.Clear(DataManager.MissionDataManager.BoolMark, 0, DataManager.MissionDataManager.BoolMark.Length);
					DataManager.MissionDataManager.sendMissionComplete(6, 0);
					if (this.FakeBuildLvStep == 4)
					{
						DataManager.MissionDataManager.sendMissionComplete(33, 0);
					}
				}
				if (GUIManager.Instance.BuildingData.BuildIDCount != null)
				{
					Array.Clear(GUIManager.Instance.BuildingData.BuildIDCount, 0, GUIManager.Instance.BuildingData.BuildIDCount.Length);
				}
				GUIManager.Instance.BuildingData.NeedSortData = true;
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0, 0);
				if (this.FakeMarkStep >= 1)
				{
					if (this.FakeMarkStep >= 2)
					{
						DataManager.MissionDataManager.RecommandTable.SaveIndex = 3;
					}
					else
					{
						DataManager.MissionDataManager.RecommandTable.SaveIndex = 2;
					}
					GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
				}
				else
				{
					DataManager.MissionDataManager.RecommandTable.SaveIndex = 1;
					GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
				}
				this.SetupFakeData((int)this.CurFakeData);
				if (this.FakeBuildStep == 1)
				{
					this.DisplayBarrackQueue();
				}
				else if (this.FakeBuildStep == 2)
				{
					this.DisplayCastleQueue();
				}
				GameManager.OnRefresh(NetworkNews.Refresh_AttribEffectVal, null);
			}
		}
	}

	// Token: 0x060025CF RID: 9679 RVA: 0x0043281C File Offset: 0x00430A1C
	public void SkipForceNewbie()
	{
		RoleBuildingData roleBuildingData = new RoleBuildingData(5, 6, 1);
		if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 5)
		{
			GUIManager.Instance.BuildingData.AllBuildsData[5] = roleBuildingData;
		}
		if (GUIManager.Instance.BuildingData.BuildIDCount != null)
		{
			GUIManager.Instance.BuildingData.BuildIDCount[6] = 1;
		}
		GUIManager.Instance.BuildingData.AllBuildsData[1].Level = 2;
		GUIManager.Instance.BuildingData.UpdateBuildState(3, 5);
		GUIManager.Instance.BuildingData.UpdateBuildState(3, 1);
		this.SetupFakeData(6);
		DataManager.MissionDataManager.sendMissionComplete(6, 0);
		DataManager.MissionDataManager.sendMissionComplete(33, 0);
		DataManager instance = DataManager.Instance;
		instance.RoleAttr.PrizeFlag = (instance.RoleAttr.PrizeFlag | 2u);
		bool flag = true;
		bool.TryParse(PlayerPrefs.GetString("Other_bShowTimeBar"), out flag);
		if (!flag)
		{
			DataManager.Instance.MySysSetting.bShowTimeBar = false;
		}
		NewbieLog.Log(ENewbieLogKind.FORCE_4, 2);
		this.LockControl(false);
		this.Step = 3;
		this.FinishStep(true);
		NewbieManager.SendFinishNewbie();
		IGGSDKPlugin.SetFacebookEventCompletedTutorial();
		AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.TUTORIAL_COMPLETION);
		this.DM.GetSysSettingSave();
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Newbie);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 0);
	}

	// Token: 0x060025D0 RID: 9680 RVA: 0x00432980 File Offset: 0x00430B80
	public void CheckTimeBarStatus()
	{
		if (!bool.TryParse(PlayerPrefs.GetString("Other_bShowTimeBar"), out this.bTimeBarOpen))
		{
			this.bTimeBarOpen = false;
		}
		if (!DataManager.Instance.MySysSetting.bShowTimeBar)
		{
			DataManager.Instance.MySysSetting.bShowTimeBar = true;
		}
	}

	// Token: 0x060025D1 RID: 9681 RVA: 0x004329D4 File Offset: 0x00430BD4
	public void RestoreTimeBarStatus()
	{
		if (!this.bTimeBarOpen)
		{
			DataManager.Instance.MySysSetting.bShowTimeBar = false;
		}
	}

	// Token: 0x060025D2 RID: 9682 RVA: 0x004329F4 File Offset: 0x00430BF4
	public void SetupFakeData(int key)
	{
		DataManager instance = DataManager.Instance;
		NewbieData recordByKey = instance.NewbieTable.GetRecordByKey((ushort)key);
		instance.Resource[0].Stock = (uint)recordByKey.Food;
		instance.Resource[1].Stock = (uint)recordByKey.Rock;
		instance.Resource[2].Stock = (uint)recordByKey.Wood;
		instance.Resource[3].Stock = (uint)recordByKey.Iron;
		instance.Resource[4].Stock = (uint)recordByKey.Gold;
		instance.RoleAttr.Power = (ulong)recordByKey.Power;
		DataManager.StageDataController.UpdateRoleAttrMorale(recordByKey.Morale);
		DataManager.StageDataController.UpdateRoleAttrExp((uint)recordByKey.Lead);
		GameManager.OnRefresh(NetworkNews.Refresh, null);
	}

	// Token: 0x060025D3 RID: 9683 RVA: 0x00432AB8 File Offset: 0x00430CB8
	public void Update()
	{
		if (this.bRunAction)
		{
			if (this.ActionDelay <= 0f)
			{
				this.ActionDelay = 0f;
				this.bRunAction = false;
				if (this.pAction != null)
				{
					NewbieManager.ActiveStep activeStep = this.pAction;
					this.pAction = null;
					activeStep();
				}
			}
			else
			{
				this.ActionDelay -= Time.deltaTime;
			}
		}
		if (this.bFlagDirty)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_UPDATEGUIDE;
			messagePacket.AddSeqId();
			messagePacket.Add((uint)(this.DM.RoleAttr.Guide & (ulong)-1));
			messagePacket.Add((uint)(this.DM.RoleAttr.Guide >> 32));
			if (messagePacket.Send(false))
			{
				this.bFlagDirty = false;
			}
		}
		if (this.bFlagDirty2)
		{
			MessagePacket messagePacket2 = new MessagePacket(1024);
			messagePacket2.Protocol = Protocol._MSG_REQUEST_ARENA_NEWBIE_FLAG;
			messagePacket2.AddSeqId();
			if (messagePacket2.Send(false))
			{
				this.bFlagDirty2 = false;
			}
		}
		if (this.bFlagDirty3)
		{
			MessagePacket messagePacket3 = new MessagePacket(1024);
			messagePacket3.Protocol = Protocol._MSG_REQUEST_SHELTER_NEWBIE_FLAG;
			messagePacket3.AddSeqId();
			if (messagePacket3.Send(false))
			{
				this.bFlagDirty3 = false;
			}
		}
		if (this.bFlagDirty_Blackmarket)
		{
			MessagePacket messagePacket4 = new MessagePacket(1024);
			messagePacket4.Protocol = Protocol._MSG_BLACKMARKET_NEWBIE_FLAG;
			messagePacket4.AddSeqId();
			if (messagePacket4.Send(false))
			{
				this.bFlagDirty_Blackmarket = false;
			}
		}
		if (this.bFlagDirty_TroopMemory)
		{
			MessagePacket messagePacket5 = new MessagePacket(1024);
			messagePacket5.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
			messagePacket5.AddSeqId();
			messagePacket5.Add(12);
			if (messagePacket5.Send(false))
			{
				this.bFlagDirty_TroopMemory = false;
			}
		}
		if (this.bFlagDirty_DeShield)
		{
			MessagePacket messagePacket6 = new MessagePacket(1024);
			messagePacket6.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
			messagePacket6.AddSeqId();
			messagePacket6.Add(13);
			if (messagePacket6.Send(false))
			{
				this.bFlagDirty_DeShield = false;
			}
		}
		if (this.bFlagDirty_Coord)
		{
			MessagePacket messagePacket7 = new MessagePacket(1024);
			messagePacket7.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
			messagePacket7.AddSeqId();
			messagePacket7.Add(14);
			if (messagePacket7.Send(false))
			{
				this.bFlagDirty_Coord = false;
			}
		}
		if (this.bFlagDirty_Metallurgy)
		{
			MessagePacket messagePacket8 = new MessagePacket(1024);
			messagePacket8.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
			messagePacket8.AddSeqId();
			messagePacket8.Add(15);
			if (messagePacket8.Send(false))
			{
				this.bFlagDirty_Metallurgy = false;
			}
		}
		if (this.bFlagDirty_Gamble2)
		{
			MessagePacket messagePacket9 = new MessagePacket(1024);
			messagePacket9.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
			messagePacket9.AddSeqId();
			messagePacket9.Add(17);
			if (messagePacket9.Send(false))
			{
				this.bFlagDirty_Gamble2 = false;
			}
		}
		if (this.bFlagDirty_DareFull)
		{
			MessagePacket messagePacket10 = new MessagePacket(1024);
			messagePacket10.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
			messagePacket10.AddSeqId();
			messagePacket10.Add(18);
			if (messagePacket10.Send(false))
			{
				this.bFlagDirty_DareFull = false;
			}
		}
		if (this.bFlagDirty_DareLead)
		{
			MessagePacket messagePacket11 = new MessagePacket(1024);
			messagePacket11.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
			messagePacket11.AddSeqId();
			messagePacket11.Add(19);
			if (messagePacket11.Send(false))
			{
				this.bFlagDirty_DareLead = false;
			}
		}
		if (this.bFlagDirty_SpawnSoldierDetail)
		{
			MessagePacket messagePacket12 = new MessagePacket(1024);
			messagePacket12.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
			messagePacket12.AddSeqId();
			messagePacket12.Add(22);
			if (messagePacket12.Send(false))
			{
				this.bFlagDirty_SpawnSoldierDetail = false;
			}
		}
		if (this.bFlagDirty_TreasBoxUpgrade)
		{
			MessagePacket messagePacket13 = new MessagePacket(1024);
			messagePacket13.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
			messagePacket13.AddSeqId();
			messagePacket13.Add(23);
			if (messagePacket13.Send(false))
			{
				this.bFlagDirty_TreasBoxUpgrade = false;
			}
		}
		if (this.bFlagDirty_SpawnPet)
		{
			MessagePacket messagePacket14 = new MessagePacket(1024);
			messagePacket14.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
			messagePacket14.AddSeqId();
			messagePacket14.Add(24);
			if (messagePacket14.Send(false))
			{
				this.bFlagDirty_SpawnPet = false;
			}
		}
		if (this.SendGuideExFlag != 0)
		{
			MessagePacket messagePacket15 = new MessagePacket(1024);
			messagePacket15.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
			messagePacket15.AddSeqId();
			messagePacket15.Add(0);
			messagePacket15.Add(this.SendGuideExFlag);
			if (messagePacket15.Send(false))
			{
				this.SendGuideExFlag = 0;
			}
		}
		if (this.TeachStep == 14 && this.SubStep == 1 && this.Target != null)
		{
			UITimeBar uitimeBar = this.Target as UITimeBar;
			if (uitimeBar != null && uitimeBar.m_TimerSpriteType != eTimerSpriteType.Help)
			{
				this.IgnoreStep(false, 2);
			}
		}
	}

	// Token: 0x060025D4 RID: 9684 RVA: 0x00432FB4 File Offset: 0x004311B4
	public NewbieStep GetStep()
	{
		return (NewbieStep)this.Step;
	}

	// Token: 0x060025D5 RID: 9685 RVA: 0x00432FBC File Offset: 0x004311BC
	public void FinishStep(bool bSave = true)
	{
		this.Step++;
		if (bSave)
		{
			PlayerPrefs.SetInt(this.SaveName, this.Step);
		}
		this.SubStep = 0;
	}

	// Token: 0x060025D6 RID: 9686 RVA: 0x00432FF8 File Offset: 0x004311F8
	public static ulong GetTeachFlag()
	{
		return ~DataManager.Instance.RoleAttr.Guide & 274877906943UL;
	}

	// Token: 0x060025D7 RID: 9687 RVA: 0x00433014 File Offset: 0x00431214
	public void LoadTeachFlag()
	{
		this.TeachFlag = NewbieManager.GetTeachFlag();
	}

	// Token: 0x060025D8 RID: 9688 RVA: 0x00433024 File Offset: 0x00431224
	public void ResetTeach()
	{
		this.TeachFlag = 274877906943UL;
		this.SaveTeachFlag(null);
	}

	// Token: 0x060025D9 RID: 9689 RVA: 0x00433050 File Offset: 0x00431250
	public bool HasTeachFlag(ETeachKind t)
	{
		return (this.TeachFlag & 1UL << (int)t) != 0UL;
	}

	// Token: 0x060025DA RID: 9690 RVA: 0x00433068 File Offset: 0x00431268
	public void SaveTeachFlag(ulong? flag = null)
	{
		if (flag == null)
		{
			flag = new ulong?(this.TeachFlag);
		}
		this.DM.RoleAttr.Guide = ~(flag.Value & ulong.MaxValue);
		this.bFlagDirty = true;
	}

	// Token: 0x060025DB RID: 9691 RVA: 0x004330B4 File Offset: 0x004312B4
	public void RemoveFlag(ETeachKind kind, byte type = 0, bool IgnoreUIQueue = false)
	{
		ulong num = this.TeachFlag;
		num &= ~(1UL << (int)kind);
		if (type == 0)
		{
			this.SaveTeachFlag(new ulong?(num));
		}
		else
		{
			this.TeachFlag = num;
			this.TeachStep = 0;
			if (!IgnoreUIQueue)
			{
				GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Newbie);
			}
		}
	}

	// Token: 0x060025DC RID: 9692 RVA: 0x0043310C File Offset: 0x0043130C
	public int GetCurActionKey()
	{
		return this.Step * 100 + this.SubStep;
	}

	// Token: 0x060025DD RID: 9693 RVA: 0x00433120 File Offset: 0x00431320
	public int GetCurTeachKey()
	{
		return this.TeachStep * 1000 + this.SubStep;
	}

	// Token: 0x060025DE RID: 9694 RVA: 0x00433138 File Offset: 0x00431338
	public static bool NeedQueuePopMenu()
	{
		return NewbieManager.IsWorking() || NewbieManager.bQueuePopMenu;
	}

	// Token: 0x060025DF RID: 9695 RVA: 0x00433154 File Offset: 0x00431354
	public static bool IsWorking()
	{
		return (NewbieManager.m_Self != null && NewbieManager.m_Self.TeachStep != 0) || NewbieManager.IsNewbie;
	}

	// Token: 0x060025E0 RID: 9696 RVA: 0x00433188 File Offset: 0x00431388
	public static bool IsTeachWorking(ETeachKind tk)
	{
		return NewbieManager.IsWorking() && NewbieManager.m_Self.TeachStep == (int)(tk + 1);
	}

	// Token: 0x060025E1 RID: 9697 RVA: 0x004331AC File Offset: 0x004313AC
	public static bool CheckNewbie(object target = null)
	{
		if (NewbieManager.IsNewbie && NewbieManager.m_Self != null)
		{
			int curActionKey = NewbieManager.m_Self.GetCurActionKey();
			NewbieManager.m_Self.ExeAction(curActionKey, target);
			return true;
		}
		return false;
	}

	// Token: 0x060025E2 RID: 9698 RVA: 0x004331E8 File Offset: 0x004313E8
	public static void ClosePopMenu()
	{
		if (NewbieManager.m_Self != null && NewbieManager.m_Self.TeachStep == 5)
		{
			return;
		}
		GUIManager instance = GUIManager.Instance;
		if (instance.m_SecWindow != null)
		{
			instance.CloseMenu(instance.m_SecWindow.m_eWindow);
			instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		}
	}

	// Token: 0x060025E3 RID: 9699 RVA: 0x00433240 File Offset: 0x00431440
	private void CheckGuideExFlagDirty(ETeachKind kind)
	{
		switch (kind)
		{
		case ETeachKind.PET_INFO:
			this.SendGuideExFlag = 1;
			break;
		case ETeachKind.PET_FUSION:
			this.SendGuideExFlag = 2;
			break;
		case ETeachKind.PET_TRAINING:
			this.SendGuideExFlag = 3;
			break;
		case ETeachKind.PET_SKILL:
			this.SendGuideExFlag = 4;
			break;
		case ETeachKind.SOCIAL_INVITE:
			this.SendGuideExFlag = 5;
			break;
		case ETeachKind.SOCIAL_INVITE_AFTER_MISSION:
			this.SendGuideExFlag = 6;
			break;
		}
	}

	// Token: 0x060025E4 RID: 9700 RVA: 0x004332C0 File Offset: 0x004314C0
	public static bool EntryTeach(ETeachKind kind)
	{
		if (NewbieManager.m_Self == null)
		{
			return false;
		}
		if (NewbieManager.m_Self.TeachStep != 0)
		{
			return false;
		}
		if (NewbieManager.IsTeaching)
		{
			NewbieManager.m_Self.LoadTeachFlag();
			ulong num = 1UL << (int)kind;
			if ((NewbieManager.m_Self.TeachFlag & num) != 0UL)
			{
				int num2 = (int)(kind + 1);
				if (num2 != NewbieManager.m_Self.TeachStep)
				{
					NewbieManager.m_Self.TeachStep = num2;
					NewbieManager.m_Self.SubStep = 0;
					NewbieManager.m_Self.RemoveFlag(kind, 0, false);
					if (kind == ETeachKind.ARENA)
					{
						NewbieManager.m_Self.bFlagDirty2 = true;
					}
					else if (kind == ETeachKind.ARMY_HOLE)
					{
						NewbieManager.m_Self.bFlagDirty3 = true;
					}
					else if (kind == ETeachKind.BLACK_MARKET)
					{
						NewbieManager.m_Self.bFlagDirty_Blackmarket = true;
					}
					else if (kind == ETeachKind.TROOP_MEMORY)
					{
						NewbieManager.m_Self.bFlagDirty_TroopMemory = true;
					}
					else if (kind == ETeachKind.DESHIELD)
					{
						NewbieManager.m_Self.bFlagDirty_DeShield = true;
					}
					else if (kind == ETeachKind.ARMY_COORD)
					{
						NewbieManager.m_Self.bFlagDirty_Coord = true;
					}
					else if (kind == ETeachKind.METALLURGY)
					{
						NewbieManager.m_Self.bFlagDirty_Metallurgy = true;
					}
					else if (kind == ETeachKind.GAMBLING2)
					{
						NewbieManager.m_Self.bFlagDirty_Gamble2 = true;
					}
					else if (kind == ETeachKind.DARE_FULL)
					{
						NewbieManager.m_Self.bFlagDirty_DareFull = true;
					}
					else if (kind == ETeachKind.DARE_LEAD)
					{
						NewbieManager.m_Self.bFlagDirty_DareLead = true;
					}
					else if (kind == ETeachKind.SPAWN_SOLDIER_DETAIL)
					{
						NewbieManager.m_Self.bFlagDirty_SpawnSoldierDetail = true;
					}
					else if (kind == ETeachKind.TREASBOX_UPGRADE)
					{
						NewbieManager.m_Self.bFlagDirty_TreasBoxUpgrade = true;
					}
					else if (kind == ETeachKind.SPAWN_PET)
					{
						NewbieManager.m_Self.bFlagDirty_SpawnPet = true;
					}
					else
					{
						NewbieManager.m_Self.CheckGuideExFlagDirty(kind);
					}
					NewbieManager.m_Self.LockControl(true);
					UIPriestTalk.Block1s = true;
					GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Newbie);
					NewbieManager.ClosePopMenu();
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025E5 RID: 9701 RVA: 0x004334B4 File Offset: 0x004316B4
	public static bool CheckTeach(ETeachKind kind, object target = null, bool bEntry = false)
	{
		if (NewbieManager.m_Self == null)
		{
			return false;
		}
		if (!bEntry && NewbieManager.m_Self.TeachStep == 0)
		{
			return false;
		}
		int num = (int)(kind + 1);
		if (NewbieManager.m_Self.TeachStep != 0 && num != NewbieManager.m_Self.TeachStep)
		{
			return false;
		}
		if (NewbieManager.IsTeaching)
		{
			ulong num2 = 1UL << (int)kind;
			if ((NewbieManager.m_Self.TeachFlag & num2) != 0UL)
			{
				if (num != NewbieManager.m_Self.TeachStep)
				{
					NewbieManager.m_Self.TeachStep = num;
					NewbieManager.m_Self.SubStep = 0;
					if (kind != ETeachKind.BATTLE_BEFORE)
					{
						NewbieManager.m_Self.RemoveFlag(kind, 0, false);
					}
					if (kind == ETeachKind.ARENA)
					{
						NewbieManager.m_Self.bFlagDirty2 = true;
					}
					else if (kind == ETeachKind.ARMY_HOLE)
					{
						NewbieManager.m_Self.bFlagDirty3 = true;
					}
					else if (kind == ETeachKind.BLACK_MARKET)
					{
						NewbieManager.m_Self.bFlagDirty_Blackmarket = true;
					}
					else if (kind == ETeachKind.TROOP_MEMORY)
					{
						NewbieManager.m_Self.bFlagDirty_TroopMemory = true;
					}
					else if (kind == ETeachKind.DESHIELD)
					{
						NewbieManager.m_Self.bFlagDirty_DeShield = true;
					}
					else if (kind == ETeachKind.ARMY_COORD)
					{
						NewbieManager.m_Self.bFlagDirty_Coord = true;
					}
					else if (kind == ETeachKind.METALLURGY)
					{
						NewbieManager.m_Self.bFlagDirty_Metallurgy = true;
					}
					else if (kind == ETeachKind.GAMBLING2)
					{
						NewbieManager.m_Self.bFlagDirty_Gamble2 = true;
					}
					else if (kind == ETeachKind.DARE_FULL)
					{
						NewbieManager.m_Self.bFlagDirty_DareFull = true;
					}
					else if (kind == ETeachKind.DARE_LEAD)
					{
						NewbieManager.m_Self.bFlagDirty_DareLead = true;
					}
					else if (kind == ETeachKind.SPAWN_SOLDIER_DETAIL)
					{
						NewbieManager.m_Self.bFlagDirty_SpawnSoldierDetail = true;
					}
					else if (kind == ETeachKind.TREASBOX_UPGRADE)
					{
						NewbieManager.m_Self.bFlagDirty_TreasBoxUpgrade = true;
					}
					else if (kind == ETeachKind.SPAWN_PET)
					{
						NewbieManager.m_Self.bFlagDirty_SpawnPet = true;
					}
					else
					{
						NewbieManager.m_Self.CheckGuideExFlagDirty(kind);
					}
					NewbieManager.m_Self.LockControl(true);
					UIPriestTalk.Block1s = true;
					GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Newbie);
					NewbieManager.ClosePopMenu();
				}
				if (NewbieManager.bQueuePopMenu)
				{
					NewbieManager.bQueuePopMenu = false;
				}
				int curTeachKey = NewbieManager.m_Self.GetCurTeachKey();
				NewbieManager.m_Self.ExeAction(curTeachKey, target);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025E6 RID: 9702 RVA: 0x004336F4 File Offset: 0x004318F4
	public static bool NeedTeach(ETeachKind kind)
	{
		if (NewbieManager.m_Self == null)
		{
			return false;
		}
		if (NewbieManager.m_Self.TeachStep != 0)
		{
			return false;
		}
		if (NewbieManager.IsTeaching)
		{
			NewbieManager.m_Self.LoadTeachFlag();
			ulong num = 1UL << (int)kind;
			if ((NewbieManager.m_Self.TeachFlag & num) != 0UL)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025E7 RID: 9703 RVA: 0x00433750 File Offset: 0x00431950
	public static bool CheckRename(bool enableMessage = true)
	{
		DataManager instance = DataManager.Instance;
		string text = instance.RoleAttr.Name.ToString();
		int curItemQuantity = (int)instance.GetCurItemQuantity(1006, 0);
		if (text.Substring(0, 3) == "ID." && curItemQuantity > 0)
		{
			instance.CheckUseItem(1006, 0, 0, 0);
			if (enableMessage)
			{
				NewbieManager.bShowRenameMessage = true;
			}
			NewbieManager.CheckTeach(ETeachKind.FIRST_RENAME, null, true);
			return true;
		}
		if (NewbieManager.m_Self != null && NewbieManager.m_Self.HasTeachFlag(ETeachKind.FIRST_RENAME))
		{
			NewbieManager.m_Self.RemoveFlag(ETeachKind.FIRST_RENAME, 0, false);
			NewbieManager.m_Self.RemoveFlag(ETeachKind.FIRST_RENAME, 1, false);
		}
		return false;
	}

	// Token: 0x060025E8 RID: 9704 RVA: 0x004337FC File Offset: 0x004319FC
	public static bool CheckGoldGuy()
	{
		ushort num = DataManager.StageDataController.StageRecord[2];
		return num >= 2 && !NewbieManager.IsWorking() && NewbieManager.EntryTeach(ETeachKind.GOLDGUY);
	}

	// Token: 0x060025E9 RID: 9705 RVA: 0x00433838 File Offset: 0x00431A38
	public static bool CheckArmyHole(bool JustEntry = false)
	{
		if ((DataManager.Instance.RoleAttr.Guide & 262144UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			ushort num = DataManager.StageDataController.StageRecord[2];
			if (num < 3)
			{
				return false;
			}
			if (ShieldLogManager.Instance.HasShieldState())
			{
				return false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door == null)
			{
				return false;
			}
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				return false;
			}
			if (door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				return false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				return false;
			}
			if (!NewbieManager.IsWorking() && NewbieManager.EntryTeach(ETeachKind.ARMY_HOLE))
			{
				if (JustEntry)
				{
					NewbieManager.EntryTeach(ETeachKind.ARMY_HOLE);
				}
				else
				{
					NewbieManager.CheckTeach(ETeachKind.ARMY_HOLE, null, true);
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025EA RID: 9706 RVA: 0x00433940 File Offset: 0x00431B40
	public static bool CheckActivity(bool JustEntry = false)
	{
		if ((DataManager.Instance.RoleAttr.Guide & 32768UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			bool flag = true;
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				flag = false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (!(door != null) || door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				flag = false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				flag = false;
			}
			if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1 && GUIManager.Instance.BuildingData.AllBuildsData[1].Level >= 5 && !NewbieManager.IsWorking() && flag)
			{
				if (JustEntry)
				{
					NewbieManager.EntryTeach(ETeachKind.ACTIVITY);
				}
				else
				{
					NewbieManager.CheckTeach(ETeachKind.ACTIVITY, null, true);
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025EB RID: 9707 RVA: 0x00433A50 File Offset: 0x00431C50
	public static bool CheckArena(bool JustEntry = false)
	{
		if ((DataManager.Instance.RoleAttr.Guide & 4UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			bool flag = true;
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				flag = false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (!(door != null) || door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				flag = false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				flag = false;
			}
			if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1 && GUIManager.Instance.BuildingData.AllBuildsData[1].Level >= 10 && !NewbieManager.IsWorking() && flag)
			{
				if (JustEntry)
				{
					NewbieManager.EntryTeach(ETeachKind.ARENA);
				}
				else
				{
					NewbieManager.CheckTeach(ETeachKind.ARENA, null, true);
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025EC RID: 9708 RVA: 0x00433B5C File Offset: 0x00431D5C
	public static bool CheckBlackmarket(bool JustEntry = false)
	{
		if ((DataManager.Instance.RoleAttr.Guide & 524288UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			bool flag = true;
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				flag = false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (!(door != null) || door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				flag = false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				flag = false;
			}
			if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1 && GUIManager.Instance.BuildingData.AllBuildsData[1].Level >= 13 && !NewbieManager.IsWorking() && flag)
			{
				if (JustEntry)
				{
					NewbieManager.EntryTeach(ETeachKind.BLACK_MARKET);
				}
				else
				{
					NewbieManager.CheckTeach(ETeachKind.BLACK_MARKET, null, true);
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025ED RID: 9709 RVA: 0x00433C6C File Offset: 0x00431E6C
	public static bool CheckTroopMemory(bool JustEntry = false)
	{
		if ((DataManager.Instance.RoleAttr.Guide & 1048576UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			bool flag = true;
			if (GUIManager.Instance.BuildingData.ManorGride[6] == null)
			{
				flag = false;
			}
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				flag = false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (!(door != null) || door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				flag = false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				flag = false;
			}
			if (DataManager.Instance.GetTechLevel(120) > 0 && !NewbieManager.IsWorking() && flag)
			{
				if (JustEntry)
				{
					NewbieManager.EntryTeach(ETeachKind.TROOP_MEMORY);
				}
				else
				{
					NewbieManager.CheckTeach(ETeachKind.TROOP_MEMORY, null, true);
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025EE RID: 9710 RVA: 0x00433D74 File Offset: 0x00431F74
	public static bool CheckDeShield()
	{
		if ((DataManager.Instance.RoleAttr.Guide & 2097152UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			bool flag = true;
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				flag = false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (!(door != null) || door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				flag = false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				flag = false;
			}
			if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1 && GUIManager.Instance.BuildingData.AllBuildsData[1].Level >= 9 && !NewbieManager.IsWorking() && flag)
			{
				NewbieManager.CheckTeach(ETeachKind.DESHIELD, null, true);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025EF RID: 9711 RVA: 0x00433E74 File Offset: 0x00432074
	public static bool CheckArmyCoord()
	{
		if ((DataManager.Instance.RoleAttr.Guide & 4194304UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			bool flag = true;
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				flag = false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (!(door != null) || door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				flag = false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				flag = false;
			}
			if ((DataManager.Instance.GetTechLevel(136) > 0 || DataManager.Instance.GetTechLevel(137) > 0) && !NewbieManager.IsWorking() && flag)
			{
				NewbieManager.CheckTeach(ETeachKind.ARMY_COORD, null, true);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025F0 RID: 9712 RVA: 0x00433F64 File Offset: 0x00432164
	public static bool CheckNewHero()
	{
		if ((DataManager.Instance.RoleAttr.Guide & 2048UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (DataManager.StageDataController.StageRecord[2] < 2)
			{
				return false;
			}
			if (NewbieManager.IsWorking())
			{
				return false;
			}
			bool flag = true;
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				flag = false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (!(door != null) || door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				flag = false;
			}
			if (!(door != null) || !door.bCanRecruit)
			{
				flag = false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				flag = false;
			}
			if (flag)
			{
				NewbieManager.CheckTeach(ETeachKind.NEW_HERO, null, true);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025F1 RID: 9713 RVA: 0x00434058 File Offset: 0x00432258
	public static bool PreCheckPutOnEquipTeach()
	{
		if (NewbieManager.Get() == null)
		{
			return false;
		}
		if (!NewbieManager.Get().HasTeachFlag(ETeachKind.PUTON_EQUIP))
		{
			return false;
		}
		DataManager instance = DataManager.Instance;
		if (instance.GetLeaderID() == 1)
		{
			if (instance.beCaptured.nowCaptureStat == LoadCaptureState.Captured)
			{
				return false;
			}
			if (instance.beCaptured.nowCaptureStat == LoadCaptureState.Dead)
			{
				return false;
			}
		}
		CurHeroData curHeroData = DataManager.Instance.curHeroData.Find(1u);
		return curHeroData.ID == 1 && curHeroData.Enhance == 1 && curHeroData.Equip == 62 && DataManager.Instance.GetCurItemQuantity(1, 0) != 0;
	}

	// Token: 0x060025F2 RID: 9714 RVA: 0x0043410C File Offset: 0x0043230C
	public static bool CheckPutOnEquipTeach()
	{
		if (NewbieManager.IsWorking())
		{
			return false;
		}
		if (NewbieManager.PreCheckPutOnEquipTeach())
		{
			return NewbieManager.EntryTeach(ETeachKind.PUTON_EQUIP);
		}
		if (NewbieManager.Get() != null && NewbieManager.Get().HasTeachFlag(ETeachKind.PUTON_EQUIP))
		{
			CurHeroData curHeroData = DataManager.Instance.curHeroData.Find(1u);
			if (curHeroData.ID == 1 && (curHeroData.Enhance > 1 || curHeroData.Equip == 63))
			{
				NewbieManager.Get().RemoveFlag(ETeachKind.PUTON_EQUIP, 0, false);
				NewbieManager.Get().RemoveFlag(ETeachKind.PUTON_EQUIP, 1, false);
			}
		}
		return false;
	}

	// Token: 0x060025F3 RID: 9715 RVA: 0x004341A8 File Offset: 0x004323A8
	public static bool CheckWipeOutTeach()
	{
		if (NewbieManager.m_Self == null || NewbieManager.IsWorking())
		{
			return false;
		}
		if (!NewbieManager.Get().HasTeachFlag(ETeachKind.WIPE_OUT))
		{
			return false;
		}
		StageManager stageDataController = DataManager.StageDataController;
		return (stageDataController._stageMode == StageMode.Full || stageDataController._stageMode == StageMode.Lean) && stageDataController.GetStagePoint(0, 0) >= 3 && NewbieManager.CheckTeach(ETeachKind.WIPE_OUT, null, true);
	}

	// Token: 0x060025F4 RID: 9716 RVA: 0x00434214 File Offset: 0x00432414
	public static void CheckWorldTeach()
	{
		if (NewbieManager.m_Self == null)
		{
			return;
		}
		if (DataManager.Instance.ServerTime - NewbieManager.m_Self.WorldTeach_Point < 300L)
		{
			return;
		}
		if (!NewbieManager.CheckTeach(ETeachKind.GOTO_WORLD, null, true) && !NewbieManager.CheckTeach(ETeachKind.WORLD_HUNT, null, true))
		{
			NewbieManager.CheckTeach(ETeachKind.WORLD_ATTACK, null, true);
		}
	}

	// Token: 0x060025F5 RID: 9717 RVA: 0x00434274 File Offset: 0x00432474
	public static void CheckRemovePressXFlag()
	{
		if (NewbieManager.m_Self == null)
		{
			return;
		}
		ulong num = 8388608UL;
		if ((NewbieManager.m_Self.TeachFlag & num) != 0UL)
		{
			NewbieManager.m_Self.RemoveFlag(ETeachKind.PRESS_X, 0, true);
			NewbieManager.m_Self.RemoveFlag(ETeachKind.PRESS_X, 1, false);
		}
	}

	// Token: 0x060025F6 RID: 9718 RVA: 0x004342C0 File Offset: 0x004324C0
	public static bool CheckMetallurgy()
	{
		if ((DataManager.Instance.RoleAttr.Guide & 16777216UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (GUIManager.Instance.BoxID[0] == 0)
			{
				return false;
			}
			if (GUIManager.Instance.m_WindowStack.Count > 0)
			{
				return false;
			}
			bool flag = true;
			if (!NewbieManager.bIgnoreGameplayCheck)
			{
				if (!(GameManager.ActiveGameplay is Origin))
				{
					flag = false;
				}
			}
			else
			{
				NewbieManager.bIgnoreGameplayCheck = false;
			}
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				flag = false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (!(door != null) || door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				flag = false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				flag = false;
			}
			if (!NewbieManager.IsWorking() && flag)
			{
				NewbieManager.CheckTeach(ETeachKind.METALLURGY, null, true);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025F7 RID: 9719 RVA: 0x004343D8 File Offset: 0x004325D8
	public static bool CheckGambleNormal()
	{
		if ((DataManager.Instance.RoleAttr.Guide & 33554432UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (DataManager.StageDataController.StageRecord[2] < 8)
			{
				return false;
			}
			if (GamblingManager.Instance.m_GambleEventSave.State != EActivityState.EAS_Run)
			{
				return false;
			}
			GamblingManager.Instance.BattleMonsterID = GamblingManager.Instance.m_GambleEventSave.MonsterID;
			if (!DataManager.CheckGambleBattleResources())
			{
				return false;
			}
			bool flag = true;
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				flag = false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (!(door != null) || door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				flag = false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				flag = false;
			}
			if (!NewbieManager.IsWorking() && flag)
			{
				if (NewbieManager.CheckTeach(ETeachKind.GAMBLING1, null, true))
				{
					GamblingManager.Instance.GambleMode = UIBattle_Gambling.eMode.Normal;
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025F8 RID: 9720 RVA: 0x004344FC File Offset: 0x004326FC
	public static bool CheckGambleElite()
	{
		if ((DataManager.Instance.RoleAttr.Guide & 67108864UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (!BattleController.IsGambleMode || BattleController.GambleMode != EGambleMode.Normal)
			{
				return false;
			}
			if (GamblingManager.Instance.GetRemainFreePlay(UIBattle_Gambling.eMode.Normal) > 0 || GamblingManager.Instance.IsSpecialType(UIBattle_Gambling.eMode.Normal))
			{
				return false;
			}
			if (!DataManager.Instance.CheckPrizeFlag(9))
			{
				return false;
			}
			bool flag = true;
			if (!NewbieManager.IsWorking() && flag)
			{
				NewbieManager.CheckTeach(ETeachKind.GAMBLING2, null, true);
				GUIManager.Instance.CloseCheckCrystalBox();
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025F9 RID: 9721 RVA: 0x004345A8 File Offset: 0x004327A8
	public static bool CheckDareFull(bool bFromWild = false)
	{
		if ((DataManager.Instance.RoleAttr.Guide & 134217728UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (DataManager.StageDataController.StageRecord[1] < 24)
			{
				return false;
			}
			if (!bFromWild && GUIManager.Instance.m_WindowStack.Count > 0)
			{
				return false;
			}
			if (DataManager.StageDataController.StageRecord[3] != 0)
			{
				return false;
			}
			bool flag = true;
			if (!bFromWild)
			{
				if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
				{
					flag = false;
				}
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (!(door != null) || door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
				{
					flag = false;
				}
				if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
				{
					flag = false;
				}
			}
			if (!NewbieManager.IsWorking() && flag)
			{
				if (bFromWild)
				{
					if (NewbieManager.EntryTeach(ETeachKind.DARE_FULL))
					{
						NewbieManager.m_Self.SubStep = 2;
						NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, false);
					}
				}
				else
				{
					NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, true);
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x17000102 RID: 258
	// (get) Token: 0x060025FA RID: 9722 RVA: 0x004346E4 File Offset: 0x004328E4
	public static bool IsLeadNewbiePass
	{
		get
		{
			return (DataManager.Instance.RoleAttr.Guide & 268435456UL) != 0UL;
		}
	}

	// Token: 0x060025FB RID: 9723 RVA: 0x00434704 File Offset: 0x00432904
	public static bool CheckDareLead()
	{
		if ((DataManager.Instance.RoleAttr.Guide & 268435456UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (!NewbieManager.IsWorking())
			{
				NewbieManager.CheckTeach(ETeachKind.DARE_LEAD, null, true);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025FC RID: 9724 RVA: 0x00434750 File Offset: 0x00432950
	public static bool CheckSpawnSoldierDetail()
	{
		if ((DataManager.Instance.RoleAttr.Guide & 536870912UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 11)
			{
				return false;
			}
			if (!NewbieManager.IsWorking())
			{
				NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIER_DETAIL, null, true);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025FD RID: 9725 RVA: 0x004347C0 File Offset: 0x004329C0
	public static bool CheckTreasBoxUpgrade()
	{
		if ((DataManager.Instance.RoleAttr.Guide & 1073741824UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (!MallManager.Instance.bLevelUpPack)
			{
				return false;
			}
			if (NewbieManager.BuildCastleImmediate)
			{
				return false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door == null)
			{
				return false;
			}
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				return false;
			}
			if (door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				return false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				return false;
			}
			if (!door.m_MallGO.activeSelf)
			{
				return false;
			}
			if (!NewbieManager.IsWorking())
			{
				NewbieManager.CheckTeach(ETeachKind.TREASBOX_UPGRADE, null, true);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025FE RID: 9726 RVA: 0x004348B0 File Offset: 0x00432AB0
	public static bool CheckSpawnPet()
	{
		if ((DataManager.Instance.RoleAttr.Guide & (ulong)-2147483648) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (GUIManager.Instance.BuildingData.AllBuildsData[49].BuildID != 20)
			{
				return false;
			}
			if (NewbieManager.NB_SpawnPetTimeCache != 0L && DataManager.Instance.ServerTime - NewbieManager.NB_SpawnPetTimeCache < 300L)
			{
				return false;
			}
			if (DataManager.StageDataController.StageRecord[2] < 8)
			{
				return false;
			}
			if ((DataManager.Instance.RoleAttr.Guide & 33554432UL) == 0UL)
			{
				return false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door == null)
			{
				return false;
			}
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				return false;
			}
			if (door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				return false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				return false;
			}
			if (!NewbieManager.IsWorking())
			{
				NewbieManager.CheckTeach(ETeachKind.SPAWN_PET, null, true);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060025FF RID: 9727 RVA: 0x004349EC File Offset: 0x00432BEC
	public static bool CheckSpawnPetFromUI()
	{
		if (NewbieManager.IsWorking())
		{
			return false;
		}
		if ((DataManager.Instance.RoleAttr.Guide & (ulong)-2147483648) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (NewbieManager.EntryTeach(ETeachKind.SPAWN_PET))
			{
				NewbieManager.m_Self.SubStep = 2;
				return NewbieManager.CheckTeach(ETeachKind.SPAWN_PET, null, false);
			}
		}
		return false;
	}

	// Token: 0x06002600 RID: 9728 RVA: 0x00434A50 File Offset: 0x00432C50
	public static bool CheckPetInfo()
	{
		return !NewbieManager.IsWorking() && (DataManager.Instance.RoleAttr.Guide & 4294967296UL) == 0UL && !NewbieManager.EntryLock && NewbieManager.CheckTeach(ETeachKind.PET_INFO, null, true);
	}

	// Token: 0x06002601 RID: 9729 RVA: 0x00434AA0 File Offset: 0x00432CA0
	public static bool CheckPetFusionBuilding()
	{
		return !NewbieManager.IsWorking() && (DataManager.Instance.RoleAttr.Guide & 8589934592UL) == 0UL && !NewbieManager.EntryLock && NewbieManager.CheckTeach(ETeachKind.PET_FUSION, null, true);
	}

	// Token: 0x06002602 RID: 9730 RVA: 0x00434AF0 File Offset: 0x00432CF0
	public static bool CheckPetTraining()
	{
		return !NewbieManager.IsWorking() && (DataManager.Instance.RoleAttr.Guide & 17179869184UL) == 0UL && !NewbieManager.EntryLock && NewbieManager.CheckTeach(ETeachKind.PET_TRAINING, null, true);
	}

	// Token: 0x06002603 RID: 9731 RVA: 0x00434B40 File Offset: 0x00432D40
	public static bool CheckPetSkill()
	{
		if ((DataManager.Instance.RoleAttr.Guide & 34359738368UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (!PetBuff.UpdateSkill(0))
			{
				return false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door == null)
			{
				return false;
			}
			if (!door.m_PetSkillBtnGO.activeSelf)
			{
				return false;
			}
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				return false;
			}
			if (door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				return false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				return false;
			}
			if (!NewbieManager.IsWorking())
			{
				NewbieManager.CheckTeach(ETeachKind.PET_SKILL, null, true);
				return true;
			}
		}
		return false;
	}

	// Token: 0x06002604 RID: 9732 RVA: 0x00434C24 File Offset: 0x00432E24
	public static bool CheckPetSkillFromUI()
	{
		if (NewbieManager.IsWorking())
		{
			return false;
		}
		if ((DataManager.Instance.RoleAttr.Guide & 34359738368UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (!PetBuff.UpdateSkill(0))
			{
				return false;
			}
			if (NewbieManager.EntryTeach(ETeachKind.PET_SKILL))
			{
				NewbieManager.m_Self.SubStep = 2;
				return NewbieManager.CheckTeach(ETeachKind.PET_SKILL, null, false);
			}
		}
		return false;
	}

	// Token: 0x06002605 RID: 9733 RVA: 0x00434C98 File Offset: 0x00432E98
	public static bool CheckSocialInvite()
	{
		if (NewbieManager.IsWorking())
		{
			return false;
		}
		if ((DataManager.Instance.RoleAttr.Guide & 68719476736UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (DataManager.Instance.RoleAttr.Invitation == 0)
			{
				return false;
			}
			if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 7)
			{
				return false;
			}
			if ((DataManager.FBMissionDataManager.GetRewardCount() > 0 && DataManager.FBMissionDataManager.GetRewardIndex() == 0 && DataManager.FBMissionDataManager.GetRewardSerial() == DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo) || DataManager.FBMissionDataManager.m_FBBindEnd || (DataManager.Instance.RoleAttr.Inviter.Invited > 0 && !DataManager.Instance.CheckPrizeFlag(30)))
			{
				return false;
			}
			if (NewbieManager.EntryTeach(ETeachKind.SOCIAL_INVITE))
			{
				if ((DataManager.Instance.RoleAttr.Guide & 137438953472UL) != 0UL)
				{
					NewbieManager.m_Self.SubStep = 1;
					NewbieManager.m_Self.ActionMap[37001].DelayTime = 0.8f;
				}
				return NewbieManager.CheckTeach(ETeachKind.SOCIAL_INVITE, null, false);
			}
		}
		return false;
	}

	// Token: 0x06002606 RID: 9734 RVA: 0x00434DEC File Offset: 0x00432FEC
	public static bool CheckSocialInviteII()
	{
		if (NewbieManager.IsWorking())
		{
			return false;
		}
		if ((DataManager.Instance.RoleAttr.Guide & 137438953472UL) == 0UL)
		{
			if (NewbieManager.EntryLock)
			{
				return false;
			}
			if (DataManager.Instance.RoleAttr.Invitation == 0)
			{
				return false;
			}
			if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 7)
			{
				return false;
			}
			if (!DataManager.Instance.CheckPrizeFlag(29))
			{
				return false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door == null)
			{
				return false;
			}
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				return false;
			}
			if (door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				return false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				return false;
			}
			if (NewbieManager.EntryTeach(ETeachKind.SOCIAL_INVITE_AFTER_MISSION))
			{
				return NewbieManager.CheckTeach(ETeachKind.SOCIAL_INVITE_AFTER_MISSION, null, false);
			}
		}
		return false;
	}

	// Token: 0x06002607 RID: 9735 RVA: 0x00434F04 File Offset: 0x00433104
	public static void EntryTest()
	{
		if (NewbieManager.CheckActivity(false))
		{
			return;
		}
		if (NewbieManager.CheckArena(false))
		{
			return;
		}
		if (NewbieManager.CheckBlackmarket(false))
		{
			return;
		}
		if (NewbieManager.CheckTroopMemory(false))
		{
			return;
		}
		if (NewbieManager.CheckArmyHole(false))
		{
			return;
		}
		if (NewbieManager.CheckDeShield())
		{
			return;
		}
		if (NewbieManager.CheckArmyCoord())
		{
			return;
		}
		if (NewbieManager.CheckMetallurgy())
		{
			return;
		}
		if (NewbieManager.CheckGambleNormal())
		{
			return;
		}
		if (NewbieManager.CheckDareFull(false))
		{
			return;
		}
		if (NewbieManager.CheckNewHero())
		{
			return;
		}
		if (NewbieManager.CheckTreasBoxUpgrade())
		{
			return;
		}
		if (NewbieManager.CheckSpawnPet())
		{
			return;
		}
		if (NewbieManager.CheckPetSkill())
		{
			return;
		}
		if (NewbieManager.CheckSocialInviteII())
		{
			return;
		}
	}

	// Token: 0x06002608 RID: 9736 RVA: 0x00434FBC File Offset: 0x004331BC
	public static void ClearFakeLineData()
	{
		if (NewbieManager.m_Self == null)
		{
			return;
		}
		if (NewbieManager.m_Self.Controller.m_FlowLineFactoryNewbie != null)
		{
			NewbieManager.m_Self.Controller.m_FlowLineFactoryNewbie.Clear();
			NewbieManager.m_Self.Controller.m_FlowLineFactoryNewbie = null;
		}
	}

	// Token: 0x06002609 RID: 9737 RVA: 0x0043500C File Offset: 0x0043320C
	public static void SetupFakeMonster(int value, LineNode line = null)
	{
		if (NewbieManager.m_Self == null || NewbieManager.m_Self.Controller.Npc_Node == null)
		{
			return;
		}
		if (value == 0)
		{
			NewbieManager.m_Self.Controller.Npc_Node.Hurt();
		}
		else if (value == 1 && line != null)
		{
			NewbieManager.m_Self.Controller.Npc_Node.updateNPC(line);
		}
		else if (value == 2 && line != null)
		{
			NewbieManager.m_Self.Controller.Npc_Node.FighterLeave(line);
		}
	}

	// Token: 0x0600260A RID: 9738 RVA: 0x004350A0 File Offset: 0x004332A0
	public void MoveNext(object target = null)
	{
		int curTeachKey = NewbieManager.m_Self.GetCurTeachKey();
		NewbieManager.m_Self.ExeAction(curTeachKey, target);
	}

	// Token: 0x0600260B RID: 9739 RVA: 0x004350C4 File Offset: 0x004332C4
	public void ExeAction(int step, object target = null)
	{
		this.Target = target;
		NewbieManager.NewbieNode newbieNode = null;
		if (this.ActionMap.TryGetValue(step, out newbieNode))
		{
			this.ClearOperate();
			this.pAction = newbieNode.StepFunc;
			this.ActionDelay = newbieNode.DelayTime;
			this.WorkingKey = step;
			this.bRunAction = true;
		}
	}

	// Token: 0x0600260C RID: 9740 RVA: 0x0043511C File Offset: 0x0043331C
	public void ExeClickAction(int key)
	{
		NewbieManager.ActiveStep activeStep = null;
		if (this.ClickActionMap.TryGetValue(key, out activeStep))
		{
			activeStep();
		}
	}

	// Token: 0x0600260D RID: 9741 RVA: 0x00435144 File Offset: 0x00433344
	public void ClearOperate()
	{
		this.NextUI = EGUIWindow.MAX;
		this.NextUIArg1 = 0;
		this.UIOperator = 0;
		this.NextUIObj = null;
		this.WorkingKey = 0;
	}

	// Token: 0x0600260E RID: 9742 RVA: 0x00435170 File Offset: 0x00433370
	public bool IsControlLocked()
	{
		return this.Controller && this.Controller.BlackPanel && this.Controller.BlackPanel.gameObject.activeSelf;
	}

	// Token: 0x0600260F RID: 9743 RVA: 0x004351B0 File Offset: 0x004333B0
	public void LockControl(bool bLock = true)
	{
		if (bLock)
		{
			this.Controller.BlackPanel.gameObject.SetActive(true);
			RectTransform rectTransform = this.Controller.BlackPanel.transform as RectTransform;
			rectTransform.anchoredPosition = Vector2.zero;
			this.Controller.SetBlackVisible(false);
		}
		else
		{
			this.Controller.BlackPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06002610 RID: 9744 RVA: 0x00435224 File Offset: 0x00433424
	public void NextStep()
	{
		this.Controller.TriggerButtonEvent(0);
	}

	// Token: 0x06002611 RID: 9745 RVA: 0x00435234 File Offset: 0x00433434
	public void SendSetArenaNewbieFlag()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_NEWBIE_FLAG;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06002612 RID: 9746 RVA: 0x00435268 File Offset: 0x00433468
	public static void SendFinishNewbie()
	{
		GUIManager.Instance.ShowUILock(EUILock.ForceNewbie);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_PASSNEWBIE;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06002613 RID: 9747 RVA: 0x004352A8 File Offset: 0x004334A8
	public void SetupUI(ref Vector2 pos, bool setAP = false, int arg = 0, int arg2 = 0)
	{
		int num = this.TeachStep * 100 + this.SubStep;
		NewbieUI recordByKey = DataManager.Instance.NewbieUITable.GetRecordByKey((ushort)num);
		if ((int)recordByKey.ID == num)
		{
			this.Controller.SetBlackVisible(true);
			if (recordByKey.TalkType == 1)
			{
				if (arg2 != 0)
				{
					if (!GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk))
					{
						GUIManager.Instance.OpenMenu(EGUIWindow.UI_PriestTalk, (int)recordByKey.TalkID, arg, false, false, false);
					}
					else
					{
						GUIManager.Instance.UpdateUI(EGUIWindow.UI_PriestTalk, (int)recordByKey.TalkID, arg);
					}
				}
				else if (!GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk))
				{
					GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_PriestTalk, (int)recordByKey.TalkID, arg);
				}
				else
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_PriestTalk, (int)recordByKey.TalkID, arg);
				}
			}
			else
			{
				if (recordByKey.TouchWidth == 0 && recordByKey.TouchHeight == 0)
				{
					Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
					recordByKey.TouchWidth = (ushort)(sizeDelta.x * 2f);
					recordByKey.TouchHeight = (ushort)(sizeDelta.y * 2f);
				}
				this.Controller.SetHoleVisible(true, new Rect?(new Rect(pos.x, pos.y, (float)recordByKey.TouchWidth, (float)recordByKey.TouchHeight)), HolePivot.CENTER, setAP);
				if (recordByKey.ArrowDir > 0 && recordByKey.ArrowDir <= 4)
				{
					int dir = (int)(recordByKey.ArrowDir - 1);
					this.Controller.SetArrow(true, (EArrowDir)dir);
				}
				if (recordByKey.TalkType == 2)
				{
					Vector2 zero = Vector2.zero;
					zero.x = (float)recordByKey.TalkBoxX * ((recordByKey.TalkBoxX_Sign == 0) ? 1f : -1f);
					zero.y = (float)recordByKey.TalkBoxY * ((recordByKey.TalkBoxY_Sign == 0) ? 1f : -1f);
					this.Controller.SetText(recordByKey.TalkID, zero);
				}
			}
		}
	}

	// Token: 0x06002614 RID: 9748 RVA: 0x004354D4 File Offset: 0x004336D4
	public static void CheckShowArrow(bool bShow, GameObject Obj = null)
	{
		if (NewbieManager.m_Self == null)
		{
			return;
		}
		if (bShow)
		{
			StageManager stageDataController = DataManager.StageDataController;
			if (stageDataController._stageMode != StageMode.Full || stageDataController.StageRecord[0] == 0 || stageDataController.StageRecord[0] > 5)
			{
				return;
			}
			if (Obj == null)
			{
				return;
			}
			Vector2 vector = Camera.main.WorldToScreenPoint(Obj.transform.position);
			float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
			vector /= scaleFactor;
			vector += new Vector2(0f, 100f);
			NewbieManager.m_Self.Controller.SetStageArrow(true, new Vector2?(vector));
		}
		else
		{
			NewbieManager.m_Self.Controller.SetStageArrow(false, null);
		}
	}

	// Token: 0x06002615 RID: 9749 RVA: 0x004355AC File Offset: 0x004337AC
	public bool PreTriggerCheck()
	{
		if (!this.IsSpecialKey() || this.bTargeting)
		{
			return true;
		}
		UIBattle uibattle = this.Target as UIBattle;
		if (uibattle == null)
		{
			return false;
		}
		uibattle.bc.setupProjector(false, ref uibattle.projectorType);
		uibattle.projectorTrans = null;
		uibattle.SetTeachProjector(false);
		this.Controller.SetBlackVisible(true);
		this.Controller.ShowPointer(true, null, null);
		return false;
	}

	// Token: 0x06002616 RID: 9750 RVA: 0x00435638 File Offset: 0x00433838
	public bool IsSpecialKey()
	{
		return this.WorkingKey == 8010 || this.WorkingKey == 8011;
	}

	// Token: 0x06002617 RID: 9751 RVA: 0x00435660 File Offset: 0x00433860
	public void DisplayBarrackQueue()
	{
		if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 5)
		{
			GUIManager.Instance.BuildingData.AllBuildsData[5].BuildID = 6;
			GUIManager.Instance.BuildingData.AllBuildsData[5].Level = 0;
		}
		GUIManager.Instance.BuildingData.BuildingManorID = 5;
		GUIManager.Instance.BuildingData.QueueBuildType = 1;
		GUIManager.Instance.BuildingData.UpdateBuildState(2, GUIManager.Instance.BuildingData.BuildingManorID);
		GUIManager.Instance.BuildingData.UpdateBuildState(10, 1);
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, true, DataManager.Instance.ServerTime, 90u);
	}

	// Token: 0x06002618 RID: 9752 RVA: 0x00435724 File Offset: 0x00433924
	public void DisplayCastleQueue()
	{
		if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1)
		{
			GUIManager.Instance.BuildingData.AllBuildsData[1].BuildID = 8;
			GUIManager.Instance.BuildingData.AllBuildsData[1].Level = 1;
		}
		GUIManager.Instance.BuildingData.BuildingManorID = 1;
		GUIManager.Instance.BuildingData.QueueBuildType = 1;
		GUIManager.Instance.BuildingData.UpdateBuildState(2, GUIManager.Instance.BuildingData.BuildingManorID);
		GUIManager.Instance.BuildingData.UpdateBuildState(10, 1);
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, true, DataManager.Instance.ServerTime, 90u);
	}

	// Token: 0x06002619 RID: 9753 RVA: 0x004357E8 File Offset: 0x004339E8
	public static void SetNewbieControlLock(bool bLock)
	{
		if (NewbieManager.IsWorking() && NewbieManager.m_Self.WorkingKey / 1000 == 8)
		{
			NewbieManager.m_Self.LockControl(bLock);
		}
	}

	// Token: 0x0600261A RID: 9754 RVA: 0x00435818 File Offset: 0x00433A18
	public void IgnoreStep(bool bExitTeach, int MoveToSubStepIdx = -1)
	{
		if (bExitTeach)
		{
			this.Controller.HideUI(false);
			if (GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) != null)
			{
				GUIManager.Instance.CloseMenu(EGUIWindow.UI_PriestTalk);
			}
			if (this.TeachStep != 0)
			{
				this.RemoveFlag((ETeachKind)(this.TeachStep - 1), 1, false);
			}
			this.LockControl(false);
		}
		else if (MoveToSubStepIdx != -1 && this.TeachStep != 0)
		{
			this.Controller.HideUI(false);
			this.SubStep = MoveToSubStepIdx;
			NewbieManager.CheckTeach((ETeachKind)(this.TeachStep - 1), this.Target, false);
		}
	}

	// Token: 0x0600261B RID: 9755 RVA: 0x004358C0 File Offset: 0x00433AC0
	public Vector2 LocalToScreenPoint(Transform t)
	{
		Vector2 a = Camera.main.WorldToScreenPoint(t.position);
		return a / GUIManager.Instance.m_UICanvas.scaleFactor;
	}

	// Token: 0x0600261C RID: 9756 RVA: 0x004358FC File Offset: 0x00433AFC
	public void SuckBugProtector()
	{
		this.Controller.HideUI(true);
		GUIManager.Instance.CloseMenu(EGUIWindow.UI_PriestTalk);
	}

	// Token: 0x0600261D RID: 9757 RVA: 0x00435918 File Offset: 0x00433B18
	public Vector2 CheckMirror(Vector2 pos)
	{
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform canvasRT = GUIManager.Instance.pDVMgr.CanvasRT;
			float num = pos.x - canvasRT.sizeDelta.x * 0.5f;
			pos.x -= num * 2f;
		}
		return pos;
	}

	// Token: 0x0600261E RID: 9758 RVA: 0x00435978 File Offset: 0x00433B78
	public void WaitForIntoScene()
	{
		this.FinishStep(false);
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x0600261F RID: 9759 RVA: 0x00435988 File Offset: 0x00433B88
	public void ShowDrama()
	{
		if (!DataManager.Instance.MySysSetting.bShowTimeBar)
		{
			DataManager.Instance.MySysSetting.bShowTimeBar = true;
		}
		GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, 13, 1);
		NewbieLog.Log(ENewbieLogKind.FORCE_2, 0);
	}

	// Token: 0x06002620 RID: 9760 RVA: 0x004359C8 File Offset: 0x00433BC8
	public void RecvShowDrama()
	{
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x06002621 RID: 9761 RVA: 0x004359D4 File Offset: 0x00433BD4
	public void FirstIntoDoor()
	{
		this.Controller.SetBlackVisible(true);
		GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_PriestTalk, 1488, 0);
		NewbieLog.Log(ENewbieLogKind.FORCE_2, 1);
	}

	// Token: 0x06002622 RID: 9762 RVA: 0x00435A08 File Offset: 0x00433C08
	public void RecvFirstIntoDoor()
	{
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x06002623 RID: 9763 RVA: 0x00435A14 File Offset: 0x00433C14
	public void Step1TargetGoal()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_MissionHintTrans != null)
		{
			RectTransform rt = (RectTransform)door.m_MissionHintTrans.GetChild(1);
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 170f, 100f)), HolePivot.CENTER, true);
			this.Controller.SetArrow(true, EArrowDir.RIGHT);
			this.Controller.SetText(8078, new Vector2(0f, 85f));
		}
		NewbieLog.Log(ENewbieLogKind.FORCE_2, 2);
	}

	// Token: 0x06002624 RID: 9764 RVA: 0x00435AE0 File Offset: 0x00433CE0
	public void RecvStep1TargetGoal()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_MissionHintTrans != null)
		{
			door.OnButtonClick(door.m_MissionBtn);
		}
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x06002625 RID: 9765 RVA: 0x00435B30 File Offset: 0x00433D30
	public void TargetManor()
	{
		Transform transform = GUIManager.Instance.BuildingData.ManorGride[1];
		Vector2 vector = Camera.main.WorldToScreenPoint(transform.position);
		float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
		vector /= scaleFactor;
		vector += new Vector2(0f, 33.188f);
		vector = this.CheckMirror(vector);
		this.Controller.SetBlackVisible(true);
		this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 140f, 140f)), HolePivot.CENTER, false);
		this.Controller.SetArrow(true, EArrowDir.RIGHT);
		this.NextUI = EGUIWindow.UI_SuitBuilding;
		this.NextUIArg1 = 5;
		NewbieLog.Log(ENewbieLogKind.FORCE_2, 3);
	}

	// Token: 0x06002626 RID: 9766 RVA: 0x00435BFC File Offset: 0x00433DFC
	public void FirstIntoSuitBuilding()
	{
		UISuitBuilding uisuitBuilding = this.Target as UISuitBuilding;
		if (uisuitBuilding != null)
		{
			RectTransform rectTransform = uisuitBuilding.scrollPanel.m_PanelObjects[0].rectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rectTransform);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 670f, 220f)), HolePivot.CENTER, false);
			this.Controller.SetArrow(true, EArrowDir.RIGHT);
			this.NextUI = EGUIWindow.UI_Barrack;
			this.NextUIArg1 = 5;
		}
		NewbieLog.Log(ENewbieLogKind.FORCE_2, 4);
	}

	// Token: 0x06002627 RID: 9767 RVA: 0x00435CA0 File Offset: 0x00433EA0
	public void FirstIntoBarrack()
	{
		UIBarrack uibarrack = this.Target as UIBarrack;
		if (uibarrack != null)
		{
			RectTransform upgradeBtnRect = uibarrack.baseBuild.upgradeBtnRect;
			Vector2 vector = this.UIController.ScreenPointTest(upgradeBtnRect);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 160f, 160f)), HolePivot.CENTER, false);
			this.Controller.SetArrow(true, EArrowDir.RIGHT);
			this.NextUI = EGUIWindow.UI_Barrack;
		}
		NewbieLog.Log(ENewbieLogKind.FORCE_2, 5);
	}

	// Token: 0x06002628 RID: 9768 RVA: 0x00435D38 File Offset: 0x00433F38
	public void RecvBarrackUpgrade()
	{
		this.FakeBuildStep = 1;
		this.DisplayBarrackQueue();
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		door.CloseMenu(true);
		this.CurFakeData = 2;
		this.SetupFakeData((int)this.CurFakeData);
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x06002629 RID: 9769 RVA: 0x00435D84 File Offset: 0x00433F84
	public void ExitBarrackToDoor()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		UIButton funtionBtn = door.m_QueueTimeBar[0].m_FuntionBtn;
		if (funtionBtn != null)
		{
			Vector2 vector = this.UIController.ScreenPointTest(funtionBtn.gameObject.transform as RectTransform);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 150f, 120f)), HolePivot.CENTER, true);
			this.Controller.SetArrow(true, EArrowDir.RIGHT);
			this.Controller.SetText(1573, new Vector2(0f, -85f));
		}
		NewbieLog.Log(ENewbieLogKind.FORCE_2, 6);
	}

	// Token: 0x0600262A RID: 9770 RVA: 0x00435E48 File Offset: 0x00434048
	public void RecvBarrackToDoor()
	{
		this.FakeBuildStep = 0;
		this.FakeBuildLvStep = 1;
		GUIManager.Instance.BuildingData.BuildingManorID = 0;
		if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 5)
		{
			GUIManager.Instance.BuildingData.AllBuildsData[5].Level = 1;
		}
		GUIManager.Instance.BuildingData.UpdateBuildState(3, 5);
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0u);
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x0600262B RID: 9771 RVA: 0x00435ECC File Offset: 0x004340CC
	public void WaitBuilding()
	{
		this.SubStep++;
		NewbieManager.CheckNewbie(null);
		GUIManager.Instance.BuildingData.NeedSortData = true;
		DataManager.MissionDataManager.SetCompleteWhileLogin(eMissionKind.Build);
		this.FakeMarkStep = 1;
	}

	// Token: 0x0600262C RID: 9772 RVA: 0x00435F08 File Offset: 0x00434108
	public void Step1TargetPrize()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_MissionHintTrans != null)
		{
			RectTransform rt = (RectTransform)door.m_MissionHintTrans.GetChild(1);
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 170f, 100f)), HolePivot.CENTER, true);
			this.Controller.SetArrow(true, EArrowDir.RIGHT);
			this.Controller.SetText(1575, new Vector2(0f, 85f));
		}
		NewbieLog.Log(ENewbieLogKind.FORCE_2, 7);
	}

	// Token: 0x0600262D RID: 9773 RVA: 0x00435FD4 File Offset: 0x004341D4
	public void Step1RecvTargetPrize()
	{
		this.FinishStep(true);
		this.CurFakeData = 3;
		this.FakeBuildLvStep = 2;
		this.SetupFakeData((int)this.CurFakeData);
		NewbieManager.CheckNewbie(null);
		DataManager.MissionDataManager.sendMissionComplete(6, 0);
		GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7945u), 11, true);
		GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x / 2f - 141.5f, GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.y - 100f);
		Array.Clear(GUIManager.Instance.SE_Kind, 0, GUIManager.Instance.SE_Kind.Length);
		Array.Clear(GUIManager.Instance.m_SpeciallyEffect.mResValue, 0, GUIManager.Instance.m_SpeciallyEffect.mResValue.Length);
		Array.Clear(GUIManager.Instance.SE_ItemID, 0, GUIManager.Instance.SE_ItemID.Length);
		GUIManager.Instance.SE_Kind[0] = SpeciallyEffect_Kind.Food;
		GUIManager.Instance.SE_Kind[1] = SpeciallyEffect_Kind.Stone;
		GUIManager.Instance.SE_Kind[2] = SpeciallyEffect_Kind.Wood;
		GUIManager.Instance.SE_Kind[3] = SpeciallyEffect_Kind.Iron;
		GUIManager.Instance.SE_Kind[4] = SpeciallyEffect_Kind.Money;
		GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x / 2f - 141.5f, GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.y - 100f);
		GUIManager.Instance.m_SpeciallyEffect.AddIconShow(GUIManager.Instance.mStartV2, GUIManager.Instance.SE_Kind, GUIManager.Instance.SE_ItemID, true);
	}

	// Token: 0x0600262E RID: 9774 RVA: 0x004361D0 File Offset: 0x004343D0
	public void IntoUpdateCastle()
	{
		this.Controller.SetBlackVisible(true);
		GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_PriestTalk, 1570, 0);
		NewbieLog.Log(ENewbieLogKind.FORCE_3, 0);
	}

	// Token: 0x0600262F RID: 9775 RVA: 0x00436204 File Offset: 0x00434404
	public void RecvIntoUpdateCastle()
	{
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x06002630 RID: 9776 RVA: 0x00436210 File Offset: 0x00434410
	public void Step2TargetGoal()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_MissionHintTrans != null)
		{
			RectTransform rt = (RectTransform)door.m_MissionHintTrans.GetChild(1);
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 170f, 100f)), HolePivot.CENTER, true);
			this.Controller.SetArrow(true, EArrowDir.RIGHT);
			this.Controller.SetText(8078, new Vector2(0f, 85f));
		}
		NewbieLog.Log(ENewbieLogKind.FORCE_3, 1);
	}

	// Token: 0x06002631 RID: 9777 RVA: 0x004362DC File Offset: 0x004344DC
	public void RecvStep2TargetGoal()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_MissionHintTrans != null)
		{
			door.OnButtonClick(door.m_MissionBtn);
		}
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x06002632 RID: 9778 RVA: 0x0043632C File Offset: 0x0043452C
	public void TargetCastle()
	{
		Transform transform = GUIManager.Instance.BuildingData.ManorGride[0];
		Vector2 vector = Camera.main.WorldToScreenPoint(transform.position);
		float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
		vector /= scaleFactor;
		vector += new Vector2(2f, 112.641f);
		vector = this.CheckMirror(vector);
		this.Controller.SetBlackVisible(true);
		this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 290f, 255f)), HolePivot.CENTER, false);
		this.Controller.SetArrow(true, EArrowDir.RIGHT);
		this.NextUI = EGUIWindow.UI_Castle;
		this.NextUIArg1 = 1;
		NewbieLog.Log(ENewbieLogKind.FORCE_3, 2);
	}

	// Token: 0x06002633 RID: 9779 RVA: 0x004363F8 File Offset: 0x004345F8
	public void IntoUICastle()
	{
		UICastle uicastle = this.Target as UICastle;
		if (uicastle != null)
		{
			RectTransform upgradeBtnRect = uicastle.baseBuild.upgradeBtnRect;
			Vector2 vector = this.UIController.ScreenPointTest(upgradeBtnRect);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 160f, 160f)), HolePivot.CENTER, false);
			this.Controller.SetArrow(true, EArrowDir.RIGHT);
		}
		NewbieLog.Log(ENewbieLogKind.FORCE_3, 3);
	}

	// Token: 0x06002634 RID: 9780 RVA: 0x00436488 File Offset: 0x00434688
	public void RecvIntoUICastle()
	{
		UICastle uicastle = this.Target as UICastle;
		if (uicastle != null)
		{
			uicastle.baseBuild.OnButtonClick(uicastle.baseBuild.upgradeBtn);
		}
		NewbieManager.CheckNewbie(this.Target);
	}

	// Token: 0x06002635 RID: 9781 RVA: 0x004364D0 File Offset: 0x004346D0
	public void IntoCastleUpgrade()
	{
		UICastle uicastle = this.Target as UICastle;
		if (uicastle != null)
		{
			RectTransform upgradeBtnRect = uicastle.baseBuild.upgradeBtnRect;
			Vector2 vector = this.UIController.ScreenPointTest(upgradeBtnRect);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 160f, 160f)), HolePivot.CENTER, false);
			this.Controller.SetArrow(true, EArrowDir.RIGHT);
		}
		NewbieLog.Log(ENewbieLogKind.FORCE_3, 4);
	}

	// Token: 0x06002636 RID: 9782 RVA: 0x00436560 File Offset: 0x00434760
	public void RecvIntoCastleUpgrade()
	{
		this.FakeBuildStep = 2;
		this.DisplayCastleQueue();
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		door.CloseMenu(true);
		this.CurFakeData = 4;
		this.SetupFakeData((int)this.CurFakeData);
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x06002637 RID: 9783 RVA: 0x004365AC File Offset: 0x004347AC
	public void CastleUpgradeRightNow()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		UIButton funtionBtn = door.m_QueueTimeBar[0].m_FuntionBtn;
		if (funtionBtn != null)
		{
			Vector2 vector = this.UIController.ScreenPointTest(funtionBtn.gameObject.transform as RectTransform);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 150f, 120f)), HolePivot.CENTER, true);
			this.Controller.SetArrow(true, EArrowDir.RIGHT);
		}
		NewbieLog.Log(ENewbieLogKind.FORCE_3, 5);
	}

	// Token: 0x06002638 RID: 9784 RVA: 0x00436650 File Offset: 0x00434850
	public void RecvCastleUpgradeRightNow()
	{
		this.FakeBuildStep = 0;
		this.FakeBuildLvStep = 3;
		GUIManager.Instance.BuildingData.BuildingManorID = 0;
		if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1)
		{
			GUIManager.Instance.BuildingData.AllBuildsData[1].Level = 2;
		}
		GUIManager.Instance.BuildingData.UpdateBuildState(3, 1);
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0u);
		object target = GUIManager.Instance.OpenMenu(EGUIWindow.UI_CastleUpgradeReward, 2, 0, false, true, false);
		DataManager.MissionDataManager.SetCompleteWhileLogin(eMissionKind.Build);
		this.FakeMarkStep = 2;
		this.CurFakeData = 5;
		this.SetupFakeData((int)this.CurFakeData);
		NewbieManager.CheckNewbie(target);
	}

	// Token: 0x06002639 RID: 9785 RVA: 0x0043670C File Offset: 0x0043490C
	public void IntoLevelUpUI()
	{
		UICastleUpgradeReward uicastleUpgradeReward = this.Target as UICastleUpgradeReward;
		if (uicastleUpgradeReward != null)
		{
			RectTransform exitBtn = uicastleUpgradeReward.ExitBtn;
			Vector2 vector = this.UIController.ScreenPointTest(exitBtn);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 120f, 120f)), HolePivot.CENTER, true);
			this.Controller.SetArrow(true, EArrowDir.RIGHT);
			this.Controller.SetText(1574, new Vector2(0f, -85f));
		}
		NewbieLog.Log(ENewbieLogKind.FORCE_3, 6);
	}

	// Token: 0x0600263A RID: 9786 RVA: 0x004367B4 File Offset: 0x004349B4
	public void RecvIntoLevelUpUI()
	{
		GUIManager.Instance.CloseMenu(EGUIWindow.UI_CastleUpgradeReward);
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x0600263B RID: 9787 RVA: 0x004367D4 File Offset: 0x004349D4
	public void Step2TargetPrize()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_MissionHintTrans != null)
		{
			RectTransform rt = (RectTransform)door.m_MissionHintTrans.GetChild(1);
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 170f, 100f)), HolePivot.CENTER, true);
			this.Controller.SetArrow(true, EArrowDir.RIGHT);
			this.Controller.SetText(1575, new Vector2(0f, 85f));
		}
		NewbieLog.Log(ENewbieLogKind.FORCE_3, 7);
	}

	// Token: 0x0600263C RID: 9788 RVA: 0x004368A0 File Offset: 0x00434AA0
	public void Step2RecvTargetPrize()
	{
		this.FinishStep(true);
		this.CurFakeData = 6;
		this.FakeBuildLvStep = 4;
		this.SetupFakeData((int)this.CurFakeData);
		NewbieManager.CheckNewbie(null);
		DataManager.MissionDataManager.sendMissionComplete(33, 0);
		GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7945u), 11, true);
		GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x / 2f - 141.5f, GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.y - 100f);
		Array.Clear(GUIManager.Instance.SE_Kind, 0, GUIManager.Instance.SE_Kind.Length);
		Array.Clear(GUIManager.Instance.m_SpeciallyEffect.mResValue, 0, GUIManager.Instance.m_SpeciallyEffect.mResValue.Length);
		Array.Clear(GUIManager.Instance.SE_ItemID, 0, GUIManager.Instance.SE_ItemID.Length);
		GUIManager.Instance.SE_Kind[0] = SpeciallyEffect_Kind.Food;
		GUIManager.Instance.SE_Kind[1] = SpeciallyEffect_Kind.Stone;
		GUIManager.Instance.SE_Kind[2] = SpeciallyEffect_Kind.Wood;
		GUIManager.Instance.SE_Kind[3] = SpeciallyEffect_Kind.Iron;
		GUIManager.Instance.SE_Kind[4] = SpeciallyEffect_Kind.Money;
		GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x / 2f - 141.5f, GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.y - 100f);
		GUIManager.Instance.m_SpeciallyEffect.AddIconShow(GUIManager.Instance.mStartV2, GUIManager.Instance.SE_Kind, GUIManager.Instance.SE_ItemID, true);
	}

	// Token: 0x0600263D RID: 9789 RVA: 0x00436A9C File Offset: 0x00434C9C
	public void IntoGetPrize()
	{
		this.Controller.SetBlackVisible(true);
		GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_PriestTalk, 1572, 0);
		NewbieLog.Log(ENewbieLogKind.FORCE_4, 0);
	}

	// Token: 0x0600263E RID: 9790 RVA: 0x00436AD0 File Offset: 0x00434CD0
	public void RecvIntoGetPrize()
	{
		this.DM.RoleAttr.VipPoint = 10u;
		this.DM.RoleAttr.VIPLevel = this.DM.GetVIPLevel(this.DM.RoleAttr.VipPoint);
		DataManager.MissionDataManager.UpdateVipState();
		GameManager.OnRefresh(NetworkNews.Refresh, null);
		GUIManager.Instance.OpenMenu(EGUIWindow.UI_VipLevelUp, (int)DataManager.Instance.RoleAttr.VIPLevel, 2, false, true, false);
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x0600263F RID: 9791 RVA: 0x00436B54 File Offset: 0x00434D54
	public void VipLevelUp()
	{
		UIVIPLevelUP uiviplevelUP = GUIManager.Instance.FindMenu(EGUIWindow.UI_VipLevelUp) as UIVIPLevelUP;
		if (uiviplevelUP != null)
		{
			RectTransform bg_Rt = uiviplevelUP.BG_Rt;
			Vector2 vector = ((RectTransform)bg_Rt.GetChild(1)).sizeDelta * 1.1f;
			Vector2 vector2 = this.UIController.ScreenPointTest(bg_Rt);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y + 30f, vector.x, vector.y)), HolePivot.CENTER, true);
			this.Controller.SetText(7743, new Vector2(0f, vector.y * -0.5f - 30f));
		}
	}

	// Token: 0x06002640 RID: 9792 RVA: 0x00436C24 File Offset: 0x00434E24
	public void RecvVipLevelUp()
	{
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x06002641 RID: 9793 RVA: 0x00436C30 File Offset: 0x00434E30
	public void VipLevelUp2()
	{
		UIVIPLevelUP uiviplevelUP = GUIManager.Instance.FindMenu(EGUIWindow.UI_VipLevelUp) as UIVIPLevelUP;
		if (uiviplevelUP != null)
		{
			RectTransform rt = uiviplevelUP.CloseBtn.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 120f, 120f)), HolePivot.CENTER, true);
			this.Controller.SetArrow(true, EArrowDir.RIGHT);
			this.Controller.SetText(8079, new Vector2(0f, -90f));
		}
	}

	// Token: 0x06002642 RID: 9794 RVA: 0x00436CE4 File Offset: 0x00434EE4
	public void RecvVipLevelUp2()
	{
		GUIManager.Instance.CloseMenu(EGUIWindow.UI_VipLevelUp);
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x06002643 RID: 9795 RVA: 0x00436D04 File Offset: 0x00434F04
	public void Step3Talk2()
	{
		this.Controller.SetBlackVisible(true);
		GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_PriestTalk, 1571, 0);
		NewbieLog.Log(ENewbieLogKind.FORCE_4, 1);
	}

	// Token: 0x06002644 RID: 9796 RVA: 0x00436D38 File Offset: 0x00434F38
	public void RecvStep3Talk2()
	{
		NewbieManager.CheckNewbie(null);
	}

	// Token: 0x06002645 RID: 9797 RVA: 0x00436D44 File Offset: 0x00434F44
	public void TargetPrize()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_MissionHintTrans != null)
		{
			RectTransform rt = (RectTransform)door.m_MissionHintTrans.GetChild(1);
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.Controller.SetBlackVisible(true);
			this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector.x, vector.y, 170f, 100f)), HolePivot.CENTER, true);
			this.Controller.SetArrow(true, EArrowDir.RIGHT);
			this.Controller.SetText(8078, new Vector2(0f, 85f));
		}
		NewbieLog.Log(ENewbieLogKind.FORCE_4, 2);
	}

	// Token: 0x06002646 RID: 9798 RVA: 0x00436E10 File Offset: 0x00435010
	public void RecvTargetPrize()
	{
		bool flag = true;
		bool.TryParse(PlayerPrefs.GetString("Other_bShowTimeBar"), out flag);
		if (!flag)
		{
			DataManager.Instance.MySysSetting.bShowTimeBar = false;
		}
		this.LockControl(false);
		this.FinishStep(true);
		NewbieManager.SendFinishNewbie();
		IGGSDKPlugin.SetFacebookEventCompletedTutorial();
		AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.TUTORIAL_COMPLETION);
		this.DM.GetSysSettingSave();
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Newbie);
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_MissionHintTrans != null)
		{
			door.OnButtonClick(door.m_MissionBtn);
		}
	}

	// Token: 0x06002647 RID: 9799 RVA: 0x00436EBC File Offset: 0x004350BC
	public void SpawnSoldier()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002648 RID: 9800 RVA: 0x00436EDC File Offset: 0x004350DC
	public void RecvSpawnSoldier()
	{
		NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIERS, this.Target, false);
	}

	// Token: 0x06002649 RID: 9801 RVA: 0x00436EEC File Offset: 0x004350EC
	public void TargetSoldierItem()
	{
		UIBarrack uibarrack = this.Target as UIBarrack;
		if (uibarrack != null)
		{
			RectTransform rt = uibarrack.tmpItemBtn[3].transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600264A RID: 9802 RVA: 0x00436F3C File Offset: 0x0043513C
	public void RecvTargetSoldierItem()
	{
		UIBarrack uibarrack = this.Target as UIBarrack;
		if (uibarrack != null)
		{
			uibarrack.OnButtonClick(uibarrack.tmpItemBtn[3]);
		}
	}

	// Token: 0x0600264B RID: 9803 RVA: 0x00436F70 File Offset: 0x00435170
	public void TargetTrain()
	{
		UIBarrack_Soldier uibarrack_Soldier = this.Target as UIBarrack_Soldier;
		if (uibarrack_Soldier != null)
		{
			RectTransform rt = uibarrack_Soldier.btn_Training.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600264C RID: 9804 RVA: 0x00436FC0 File Offset: 0x004351C0
	public void RecvTargetTrain()
	{
		UIBarrack_Soldier uibarrack_Soldier = this.Target as UIBarrack_Soldier;
		if (uibarrack_Soldier != null)
		{
			if (uibarrack_Soldier.btn_Training.m_BtnType == e_BtnType.e_ChangeText)
			{
				this.IgnoreStep(true, -1);
			}
			uibarrack_Soldier.OnButtonClick(uibarrack_Soldier.btn_Training);
		}
	}

	// Token: 0x0600264D RID: 9805 RVA: 0x0043700C File Offset: 0x0043520C
	public void FinishTrain()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x0600264E RID: 9806 RVA: 0x0043702C File Offset: 0x0043522C
	public void RecvFinishTrain()
	{
		NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIERS, null, false);
	}

	// Token: 0x0600264F RID: 9807 RVA: 0x00437038 File Offset: 0x00435238
	public void FinishTrain2()
	{
		UIBarrack uibarrack = GUIManager.Instance.FindMenu(EGUIWindow.UI_Barrack) as UIBarrack;
		if (uibarrack != null)
		{
			RectTransform rt = uibarrack.baseBuild.exitBtn.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002650 RID: 9808 RVA: 0x00437094 File Offset: 0x00435294
	public void RecvFinishTrain2()
	{
		this.RemoveFlag(ETeachKind.SPAWN_SOLDIERS, 1, false);
		this.LockControl(false);
		GUIManager.Instance.SetFrontMark(1);
		UIBarrack uibarrack = GUIManager.Instance.FindMenu(EGUIWindow.UI_Barrack) as UIBarrack;
		if (uibarrack != null)
		{
			uibarrack.baseBuild.OnButtonClick(uibarrack.baseBuild.exitBtn);
		}
	}

	// Token: 0x06002651 RID: 9809 RVA: 0x004370F0 File Offset: 0x004352F0
	public void Into_WarScout()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002652 RID: 9810 RVA: 0x00437110 File Offset: 0x00435310
	public void Recv_Into_WarScout()
	{
		NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, null, false);
	}

	// Token: 0x06002653 RID: 9811 RVA: 0x0043711C File Offset: 0x0043531C
	public void WarScout_TargetCastle()
	{
		Origin origin = GameManager.ActiveGameplay as Origin;
		if (origin != null)
		{
			Transform transform = origin.WorldController.CastleObj.transform;
			Vector2 vector = Camera.main.WorldToScreenPoint(transform.position);
			float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
			vector /= scaleFactor;
			vector += new Vector2(0f, 27.188f);
			vector = this.CheckMirror(vector);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002654 RID: 9812 RVA: 0x004371A4 File Offset: 0x004353A4
	public void Recv_WarScout_TargetCastle()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		door.m_GroundInfo.OpenPvePanel(true, DataManager.StageDataController.StageRecord[2] + 1);
	}

	// Token: 0x06002655 RID: 9813 RVA: 0x004371E0 File Offset: 0x004353E0
	public void TargetScout()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		RectTransform rt = door.m_GroundInfo.m_PvePanel.GetChild(10) as RectTransform;
		Vector2 vector = this.UIController.ScreenPointTest(rt);
		this.SetupUI(ref vector, true, 0, 0);
	}

	// Token: 0x06002656 RID: 9814 RVA: 0x00437230 File Offset: 0x00435430
	public void RecvTargetScout()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		UIButton component = door.m_GroundInfo.m_PvePanel.GetChild(10).GetComponent<UIButton>();
		door.m_GroundInfo.OnButtonClick(component);
	}

	// Token: 0x06002657 RID: 9815 RVA: 0x00437274 File Offset: 0x00435474
	public void TargetScoutInfo()
	{
		UIDevelopmentDetails uidevelopmentDetails = this.Target as UIDevelopmentDetails;
		if (uidevelopmentDetails != null)
		{
			RectTransform rectTransform = uidevelopmentDetails.tmpPanel.getScrollPanel().m_PanelObjects[0].rectTransform;
			Vector2 a = this.UIController.ScreenPointTest(rectTransform);
			RectTransform rectTransform2 = uidevelopmentDetails.tmpPanel.getScrollPanel().m_PanelObjects[1].rectTransform;
			a += new Vector2(0f, -((rectTransform.sizeDelta.y + rectTransform2.sizeDelta.y) * 0.5f));
			this.SetupUI(ref a, false, 0, 0);
		}
	}

	// Token: 0x06002658 RID: 9816 RVA: 0x00437318 File Offset: 0x00435518
	public void RecvTargetScoutInfo()
	{
		NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, this.Target, false);
	}

	// Token: 0x06002659 RID: 9817 RVA: 0x00437328 File Offset: 0x00435528
	public void TargetScoutInfoExit()
	{
		UIDevelopmentDetails uidevelopmentDetails = this.Target as UIDevelopmentDetails;
		if (uidevelopmentDetails != null)
		{
			RectTransform rt = uidevelopmentDetails.btn_EXIT.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600265A RID: 9818 RVA: 0x00437378 File Offset: 0x00435578
	public void RecvTargetScoutInfoExit()
	{
		UIDevelopmentDetails uidevelopmentDetails = this.Target as UIDevelopmentDetails;
		if (uidevelopmentDetails != null)
		{
			uidevelopmentDetails.OnButtonClick(uidevelopmentDetails.btn_EXIT);
		}
	}

	// Token: 0x0600265B RID: 9819 RVA: 0x004373AC File Offset: 0x004355AC
	public void Into_WarAttack()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		RectTransform rt = door.m_GroundInfo.m_PvePanel.GetChild(11) as RectTransform;
		Vector2 vector = this.UIController.ScreenPointTest(rt);
		this.SetupUI(ref vector, true, 0, 0);
	}

	// Token: 0x0600265C RID: 9820 RVA: 0x004373FC File Offset: 0x004355FC
	public void Recv_Into_WarAttack()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		UIButton component = door.m_GroundInfo.m_PvePanel.GetChild(11).GetComponent<UIButton>();
		door.m_GroundInfo.OnButtonClick(component);
	}

	// Token: 0x0600265D RID: 9821 RVA: 0x00437440 File Offset: 0x00435640
	public void Team_Select()
	{
		UIExpedition uiexpedition = this.Target as UIExpedition;
		if (uiexpedition != null)
		{
			RectTransform rt = uiexpedition.gameObject.transform.GetChild(2) as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600265E RID: 9822 RVA: 0x00437494 File Offset: 0x00435694
	public void Recv_Team_Select()
	{
		NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, this.Target, false);
	}

	// Token: 0x0600265F RID: 9823 RVA: 0x004374A4 File Offset: 0x004356A4
	public void Soldier_Select()
	{
		UIExpedition uiexpedition = this.Target as UIExpedition;
		if (uiexpedition != null)
		{
			RectTransform rt = uiexpedition.gameObject.transform.GetChild(3) as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002660 RID: 9824 RVA: 0x004374F8 File Offset: 0x004356F8
	public void Recv_Soldier_Select()
	{
		NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, this.Target, false);
	}

	// Token: 0x06002661 RID: 9825 RVA: 0x00437508 File Offset: 0x00435708
	public void Fight_Select()
	{
		UIExpedition uiexpedition = this.Target as UIExpedition;
		if (uiexpedition != null)
		{
			RectTransform rt = uiexpedition.btn_Expedition.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002662 RID: 9826 RVA: 0x00437558 File Offset: 0x00435758
	public void Recv_Fight_Select()
	{
		UIExpedition uiexpedition = this.Target as UIExpedition;
		if (uiexpedition != null)
		{
			uiexpedition.OnButtonClick(uiexpedition.btn_Expedition);
		}
		this.RemoveFlag(ETeachKind.WAR_SCOUT, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002663 RID: 9827 RVA: 0x0043759C File Offset: 0x0043579C
	public void IntoCollege()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002664 RID: 9828 RVA: 0x004375BC File Offset: 0x004357BC
	public void RecvIntoCollege()
	{
		NewbieManager.CheckTeach(ETeachKind.COLLEGE, this.Target, false);
	}

	// Token: 0x06002665 RID: 9829 RVA: 0x004375CC File Offset: 0x004357CC
	public void TargetMilitary()
	{
		UITechInstitute uitechInstitute = this.Target as UITechInstitute;
		if (uitechInstitute != null)
		{
			RectTransform rt = uitechInstitute.TechItem[0].Button[2].transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002666 RID: 9830 RVA: 0x00437628 File Offset: 0x00435828
	public void RecvTargetMilitary()
	{
		UITechInstitute uitechInstitute = this.Target as UITechInstitute;
		if (uitechInstitute != null)
		{
			uitechInstitute.OnButtonClick(uitechInstitute.TechItem[0].Button[2]);
		}
	}

	// Token: 0x06002667 RID: 9831 RVA: 0x00437668 File Offset: 0x00435868
	public void TargetTopSkill()
	{
		UITechTree uitechTree = this.Target as UITechTree;
		if (uitechTree != null)
		{
			RectTransform rt = uitechTree.TreeLayer[0].Tech[1].TechBtn.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002668 RID: 9832 RVA: 0x004376C8 File Offset: 0x004358C8
	public void RecvTargetTopSkill()
	{
		UITechTree uitechTree = this.Target as UITechTree;
		if (uitechTree != null)
		{
			uitechTree.OnButtonClick(uitechTree.TreeLayer[0].Tech[1].TechBtn);
			NewbieManager.CheckTeach(ETeachKind.COLLEGE, this.Target, false);
		}
	}

	// Token: 0x06002669 RID: 9833 RVA: 0x0043771C File Offset: 0x0043591C
	public void TargetTechInfo()
	{
		UITechTree uitechTree = this.Target as UITechTree;
		if (uitechTree != null)
		{
			RectTransform rt = uitechTree.InfoWindow.ConfirmBtn.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600266A RID: 9834 RVA: 0x00437770 File Offset: 0x00435970
	public void RecvTargetTechInfo()
	{
		UITechTree uitechTree = this.Target as UITechTree;
		if (uitechTree != null)
		{
			uitechTree.InfoWindow.OnButtonClick(uitechTree.InfoWindow.ConfirmBtn);
		}
	}

	// Token: 0x0600266B RID: 9835 RVA: 0x004377AC File Offset: 0x004359AC
	public void TechUpgrade()
	{
		UITechUpgrade uitechUpgrade = this.Target as UITechUpgrade;
		if (uitechUpgrade != null)
		{
			RectTransform upgradeBtnRect = uitechUpgrade.buildWin.upgradeBtnRect;
			Vector2 vector = this.UIController.ScreenPointTest(upgradeBtnRect);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600266C RID: 9836 RVA: 0x004377F8 File Offset: 0x004359F8
	public void RecvTechUpgrade()
	{
		UITechUpgrade uitechUpgrade = this.Target as UITechUpgrade;
		if (uitechUpgrade != null)
		{
			if (uitechUpgrade.buildWin.upgradeBtn.m_BtnID2 == 100)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5771u), 255, true);
				this.RemoveFlag(ETeachKind.COLLEGE, 1, false);
				this.LockControl(false);
			}
			else
			{
				uitechUpgrade.buildWin.OnButtonClick(uitechUpgrade.buildWin.upgradeBtn);
			}
		}
	}

	// Token: 0x0600266D RID: 9837 RVA: 0x00437884 File Offset: 0x00435A84
	public void TechFinish()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x0600266E RID: 9838 RVA: 0x004378A4 File Offset: 0x00435AA4
	public void RecvTechFinish()
	{
		this.RemoveFlag(ETeachKind.COLLEGE, 1, false);
		this.LockControl(false);
	}

	// Token: 0x0600266F RID: 9839 RVA: 0x004378B8 File Offset: 0x00435AB8
	public void Rename()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002670 RID: 9840 RVA: 0x004378D8 File Offset: 0x00435AD8
	public void RecvRename()
	{
		this.RemoveFlag(ETeachKind.FIRST_RENAME, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002671 RID: 9841 RVA: 0x004378EC File Offset: 0x00435AEC
	public void GotoWorld()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
		this.Controller.SetSpecialBox(true, 0);
		this.Controller.PreClickFlag = 1;
	}

	// Token: 0x06002672 RID: 9842 RVA: 0x00437924 File Offset: 0x00435B24
	public void RecvGotoWorld()
	{
		this.MoveNext(null);
	}

	// Token: 0x06002673 RID: 9843 RVA: 0x00437930 File Offset: 0x00435B30
	public void GotoWorld2()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x06002674 RID: 9844 RVA: 0x00437950 File Offset: 0x00435B50
	public void RecvGotoWorld2()
	{
		this.MoveNext(null);
	}

	// Token: 0x06002675 RID: 9845 RVA: 0x0043795C File Offset: 0x00435B5C
	public void GotoWorld3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
		this.Controller.PreClickFlag = 0;
	}

	// Token: 0x06002676 RID: 9846 RVA: 0x00437988 File Offset: 0x00435B88
	public void RecvGotoWorld3()
	{
		this.MoveNext(null);
	}

	// Token: 0x06002677 RID: 9847 RVA: 0x00437994 File Offset: 0x00435B94
	public void GotoWorld4()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			RectTransform rt = door.m_MapSwitchButton.GetComponent<UIButton>().transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002678 RID: 9848 RVA: 0x004379EC File Offset: 0x00435BEC
	public void RecvGotoWorld4()
	{
		this.RemoveFlag(ETeachKind.GOTO_WORLD, 1, false);
		this.LockControl(false);
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			UIButton component = door.m_MapSwitchButton.GetComponent<UIButton>();
			door.OnButtonClick(component);
		}
		this.SuckBugProtector();
		this.WorldTeach_Point = DataManager.Instance.ServerTime;
	}

	// Token: 0x06002679 RID: 9849 RVA: 0x00437A50 File Offset: 0x00435C50
	public void Battle_Before()
	{
		if (!this.IsControlLocked())
		{
			this.LockControl(true);
		}
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x0600267A RID: 9850 RVA: 0x00437A80 File Offset: 0x00435C80
	public void Recv_Battle_Before()
	{
		NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, null, false);
	}

	// Token: 0x0600267B RID: 9851 RVA: 0x00437A8C File Offset: 0x00435C8C
	public void TargetLord()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.ForceQueueBarOpenClose(false);
		}
		if (NewbieManager.pTrans != null)
		{
			Vector2 vector = Camera.main.WorldToScreenPoint(NewbieManager.pTrans.position);
			float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
			vector /= scaleFactor;
			vector += new Vector2(0f, 34f);
			vector = this.CheckMirror(vector);
			this.SetupUI(ref vector, false, 0, 0);
			NewbieManager.pTrans = null;
		}
	}

	// Token: 0x0600267C RID: 9852 RVA: 0x00437B30 File Offset: 0x00435D30
	public void Recv_TargetLord()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_StageInfo, 0, 0, true);
		}
	}

	// Token: 0x0600267D RID: 9853 RVA: 0x00437B68 File Offset: 0x00435D68
	public void IntoStageInfo()
	{
		UIStageInfo uistageInfo = this.Target as UIStageInfo;
		if (uistageInfo != null)
		{
			RectTransform rt = uistageInfo.transform.GetChild(21).transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600267E RID: 9854 RVA: 0x00437BC0 File Offset: 0x00435DC0
	public void Recv_IntoStageInfo()
	{
		UIStageInfo uistageInfo = this.Target as UIStageInfo;
		if (uistageInfo != null)
		{
			UIButton component = uistageInfo.transform.GetChild(21).GetComponent<UIButton>();
			uistageInfo.OnButtonClick(component);
		}
	}

	// Token: 0x0600267F RID: 9855 RVA: 0x00437C00 File Offset: 0x00435E00
	public void BattleSelect_S1()
	{
		UIBattleHeroSelect uibattleHeroSelect = this.Target as UIBattleHeroSelect;
		if (uibattleHeroSelect != null)
		{
			RectTransform rt = uibattleHeroSelect.m_HerosView.transform.GetChild(0).GetChild(0) as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002680 RID: 9856 RVA: 0x00437C5C File Offset: 0x00435E5C
	public void Recv_BattleSelect_S1()
	{
		UIBattleHeroSelect uibattleHeroSelect = this.Target as UIBattleHeroSelect;
		if (uibattleHeroSelect != null)
		{
			UIHIBtn component = uibattleHeroSelect.m_HerosView.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<UIHIBtn>();
			uibattleHeroSelect.OnHIButtonClick(component);
		}
		NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, this.Target, false);
	}

	// Token: 0x06002681 RID: 9857 RVA: 0x00437CC0 File Offset: 0x00435EC0
	public void BattleSelect_S2()
	{
		UIBattleHeroSelect uibattleHeroSelect = this.Target as UIBattleHeroSelect;
		if (uibattleHeroSelect != null)
		{
			RectTransform rt = uibattleHeroSelect.m_HerosView.transform.GetChild(0).GetChild(1) as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002682 RID: 9858 RVA: 0x00437D1C File Offset: 0x00435F1C
	public void Recv_BattleSelect_S2()
	{
		UIBattleHeroSelect uibattleHeroSelect = this.Target as UIBattleHeroSelect;
		if (uibattleHeroSelect != null)
		{
			UIHIBtn component = uibattleHeroSelect.m_HerosView.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<UIHIBtn>();
			uibattleHeroSelect.OnHIButtonClick(component);
		}
		NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, this.Target, false);
	}

	// Token: 0x06002683 RID: 9859 RVA: 0x00437D80 File Offset: 0x00435F80
	public void BattleSelect_Start()
	{
		UIBattleHeroSelect uibattleHeroSelect = this.Target as UIBattleHeroSelect;
		if (uibattleHeroSelect != null)
		{
			RectTransform rt = uibattleHeroSelect.transform.GetChild(15) as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002684 RID: 9860 RVA: 0x00437DD0 File Offset: 0x00435FD0
	public void Recv_BattleSelect_Start()
	{
		UIBattleHeroSelect uibattleHeroSelect = this.Target as UIBattleHeroSelect;
		if (uibattleHeroSelect != null)
		{
			UIButton component = uibattleHeroSelect.transform.GetChild(15).gameObject.GetComponent<UIButton>();
			uibattleHeroSelect.OnButtonClick(component);
		}
	}

	// Token: 0x06002685 RID: 9861 RVA: 0x00437E14 File Offset: 0x00436014
	public void Battle_StartNewbie()
	{
		this.SubStep++;
	}

	// Token: 0x06002686 RID: 9862 RVA: 0x00437E24 File Offset: 0x00436024
	public void Battle_NextLevel()
	{
		BattleController battleController = this.Target as BattleController;
		if (battleController != null)
		{
			UIBattle uiBattle = battleController.uiBattle;
			if (uiBattle != null)
			{
				RectTransform rt = uiBattle.btnRt[2];
				Vector2 vector = this.UIController.ScreenPointTest(rt);
				this.SetupUI(ref vector, false, 0, 0);
			}
		}
	}

	// Token: 0x06002687 RID: 9863 RVA: 0x00437E78 File Offset: 0x00436078
	public void Battle_NextLevel_FullScreen()
	{
		this.Controller.SetHoleVisible(true, null, HolePivot.CENTER, false);
	}

	// Token: 0x06002688 RID: 9864 RVA: 0x00437E9C File Offset: 0x0043609C
	public void Recv_Battle_NextLevel()
	{
		BattleController battleController = this.Target as BattleController;
		if (battleController != null)
		{
			battleController.controlPanel.OnPointerUp(null);
		}
	}

	// Token: 0x06002689 RID: 9865 RVA: 0x00437EC8 File Offset: 0x004360C8
	public void Battle_FirstUltra()
	{
		UIBattle uibattle = this.Target as UIBattle;
		if (uibattle != null)
		{
			uibattle.ultraSkillWorking = true;
			uibattle.bc.updateMaxSkillFreeze(true);
			uibattle.bc.m_BattleState = BattleController.BattleState.BATTLE_MAXSKILL_WORKING;
			this.UltraTimeCache = uibattle.bc.deltaTime;
			RectTransform rt = uibattle.btnRt[1];
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600268A RID: 9866 RVA: 0x00437F40 File Offset: 0x00436140
	public void Recv_Battle_FirstUltra()
	{
		UIBattle uibattle = this.Target as UIBattle;
		if (uibattle != null)
		{
			uibattle.bc.checkInitUltra(1);
			uibattle.bc.maxSkillTimeCache = this.UltraTimeCache;
			uibattle.bc.inputUltra(false, null);
			uibattle.ultraSkillWorking = false;
		}
	}

	// Token: 0x0600268B RID: 9867 RVA: 0x00437FA0 File Offset: 0x004361A0
	public void Battle_SecondUltra()
	{
		UIBattle uibattle = this.Target as UIBattle;
		if (uibattle != null)
		{
			uibattle.ultraSkillWorking = true;
			uibattle.bc.updateMaxSkillFreeze(true);
			uibattle.bc.m_BattleState = BattleController.BattleState.BATTLE_MAXSKILL_WORKING;
			this.UltraTimeCache = uibattle.bc.deltaTime;
			RectTransform rt = uibattle.btnRt[2];
			this.PosCache = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref this.PosCache, false, 0, 0);
			this.Controller.ToEnemyPointer(this.PosCache, 0, 0);
		}
	}

	// Token: 0x0600268C RID: 9868 RVA: 0x00438034 File Offset: 0x00436234
	public void Battle_SecondUltra_BtnDown()
	{
		UIBattle uibattle = this.Target as UIBattle;
		if (uibattle != null && !uibattle.bc.IsMaxSkillWorking)
		{
			uibattle.ultraSkillWorking = false;
			uibattle.OnHIButtonDown(uibattle.buttons[2]);
			this.bTargeting = false;
			this.bUltraWorking = true;
		}
		this.Controller.SetBlackVisible(false);
		this.Controller.ShowPointer(false, null, null);
		this.bOutsideHole = false;
	}

	// Token: 0x0600268D RID: 9869 RVA: 0x004380C0 File Offset: 0x004362C0
	public void Battle_SecondUltra_BtnDrag()
	{
		UIBattle uibattle = this.Target as UIBattle;
		if (uibattle == null)
		{
			return;
		}
		if (!this.bOutsideHole && this.Controller.CheckOutsideHole())
		{
			this.bOutsideHole = true;
			uibattle.OnHIButtonDragExit(uibattle.buttons[2]);
			uibattle.UpdateProjector(false, false);
			uibattle.SetTeachProjector(true);
		}
		if (this.bOutsideHole && !this.bTargeting)
		{
			BattleController battleController = GameManager.ActiveGameplay as BattleController;
			if (battleController != null)
			{
				Vector3 to = battleController.enemyUnit[0].Position - battleController.playerUnit[0].Position;
				float num = Vector3.Angle(battleController.playerUnit[0].Forward, to);
				if (num < 20f)
				{
					Vector2 vector = Camera.main.WorldToScreenPoint(battleController.enemyUnit[0].Position);
					float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
					vector /= scaleFactor;
					uibattle.rayCache = Camera.main.ScreenPointToRay(vector);
					uibattle.UpdateProjector(true, true);
					uibattle.bProjectorMode = false;
					uibattle.SetTeachProjector(false);
					this.bTargeting = true;
				}
			}
		}
	}

	// Token: 0x0600268E RID: 9870 RVA: 0x004381FC File Offset: 0x004363FC
	public void Recv_Battle_SecondUltra()
	{
		UIBattle uibattle = this.Target as UIBattle;
		if (uibattle != null)
		{
			uibattle.bc.maxSkillTimeCache = this.UltraTimeCache;
			uibattle.OnHIButtonUp(uibattle.buttons[2]);
		}
	}

	// Token: 0x0600268F RID: 9871 RVA: 0x00438240 File Offset: 0x00436440
	public void Battle_ThirdUltra()
	{
		UIBattle uibattle = this.Target as UIBattle;
		if (uibattle != null)
		{
			uibattle.ultraSkillWorking = true;
			uibattle.bc.updateMaxSkillFreeze(true);
			uibattle.bc.m_BattleState = BattleController.BattleState.BATTLE_MAXSKILL_WORKING;
			this.UltraTimeCache = uibattle.bc.deltaTime;
			RectTransform rt = uibattle.btnRt[1];
			this.PosCache = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref this.PosCache, false, 0, 0);
			this.Controller.ToEnemyPointer(this.PosCache, 0, 1);
		}
	}

	// Token: 0x06002690 RID: 9872 RVA: 0x004382D4 File Offset: 0x004364D4
	public void Battle_ThirdUltra_BtnDown()
	{
		UIBattle uibattle = this.Target as UIBattle;
		if (uibattle != null && !uibattle.bc.IsMaxSkillWorking)
		{
			uibattle.ultraSkillWorking = false;
			uibattle.OnHIButtonDown(uibattle.buttons[1]);
			this.bTargeting = false;
			this.bUltraWorking = true;
		}
		this.Controller.SetBlackVisible(false);
		this.Controller.ShowPointer(false, null, null);
		this.bOutsideHole = false;
	}

	// Token: 0x06002691 RID: 9873 RVA: 0x00438360 File Offset: 0x00436560
	public void Battle_ThirdUltra_BtnDrag()
	{
		UIBattle uibattle = this.Target as UIBattle;
		if (uibattle == null)
		{
			return;
		}
		if (!this.bOutsideHole && this.Controller.CheckOutsideHole())
		{
			this.bOutsideHole = true;
			uibattle.OnHIButtonDragExit(uibattle.buttons[1]);
			uibattle.UpdateProjector(false, false);
			uibattle.SetTeachProjector(true);
		}
		if (this.bOutsideHole)
		{
			BattleController battleController = GameManager.ActiveGameplay as BattleController;
			if (battleController != null && battleController.lastNearestTargetIndex == 0)
			{
				uibattle.SetTeachProjector(false);
				uibattle.bProjectorMode = false;
				this.bTargeting = true;
			}
		}
	}

	// Token: 0x06002692 RID: 9874 RVA: 0x00438404 File Offset: 0x00436604
	public void Recv_Battle_ThirdUltra()
	{
		UIBattle uibattle = this.Target as UIBattle;
		if (uibattle != null)
		{
			uibattle.bc.maxSkillTimeCache = this.UltraTimeCache;
			uibattle.OnHIButtonUp(uibattle.buttons[1]);
		}
		NewbieManager.bQueuePopMenu = true;
		this.RemoveFlag(ETeachKind.BATTLE_BEFORE, 1, false);
		this.LockControl(false);
		if (NewbieManager.PreCheckPutOnEquipTeach())
		{
			GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Newbie);
		}
	}

	// Token: 0x06002693 RID: 9875 RVA: 0x00438474 File Offset: 0x00436674
	public void CheckPutOnEquip()
	{
		CurHeroData curHeroData = this.DM.curHeroData.Find(1u);
		if (curHeroData.ID == 1 && curHeroData.Enhance == 1 && (curHeroData.Equip & 1) == 0)
		{
			Vector2 zero = Vector2.zero;
			this.SetupUI(ref zero, false, 0, 0);
		}
		else
		{
			this.RemoveFlag(ETeachKind.PUTON_EQUIP, 1, false);
			this.LockControl(false);
		}
	}

	// Token: 0x06002694 RID: 9876 RVA: 0x004384E4 File Offset: 0x004366E4
	public void RecvCheckPutOnEquip()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_bShowFuncButton != 1)
		{
			door.ShowFuncButton(true);
		}
		NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, door, false);
	}

	// Token: 0x06002695 RID: 9877 RVA: 0x0043852C File Offset: 0x0043672C
	public void ClickHeroList()
	{
		Door door = this.Target as Door;
		if (door != null)
		{
			RectTransform rt = door.m_FuncRC[0];
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002696 RID: 9878 RVA: 0x00438574 File Offset: 0x00436774
	public void RecvClickHeroList()
	{
		Door door = this.Target as Door;
		if (door != null)
		{
			door.OnButtonClick(door.m_FuncRC[0].GetChild(1).GetComponent<UIButton>());
		}
	}

	// Token: 0x06002697 RID: 9879 RVA: 0x004385B4 File Offset: 0x004367B4
	public void ClickHeroFromList()
	{
		UIHeroList uiheroList = this.Target as UIHeroList;
		if (uiheroList != null)
		{
			RectTransform rt = uiheroList.scrolCont.GetChild(0) as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002698 RID: 9880 RVA: 0x00438604 File Offset: 0x00436804
	public void RecvClickHeroFromList()
	{
		UIHeroList uiheroList = this.Target as UIHeroList;
		if (uiheroList != null)
		{
			GameObject gameObject = uiheroList.scrolCont.GetChild(0).gameObject;
			uiheroList.ButtonOnClick(gameObject, 0);
		}
	}

	// Token: 0x06002699 RID: 9881 RVA: 0x00438644 File Offset: 0x00436844
	public void ClickEquipBtn()
	{
		UIHero_Info uihero_Info = this.Target as UIHero_Info;
		if (uihero_Info != null)
		{
			RectTransform rt = uihero_Info.btn_Equip[0].transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600269A RID: 9882 RVA: 0x00438694 File Offset: 0x00436894
	public void RecvClickEquipBtn()
	{
		UIHero_Info uihero_Info = this.Target as UIHero_Info;
		if (uihero_Info != null)
		{
			uihero_Info.OnHIButtonClick(uihero_Info.btn_Equip[0]);
		}
	}

	// Token: 0x0600269B RID: 9883 RVA: 0x004386C8 File Offset: 0x004368C8
	public void ClickPutOn()
	{
		UIItemInfo uiitemInfo = this.Target as UIItemInfo;
		if (uiitemInfo != null)
		{
			RectTransform rt = uiitemInfo.m_Button1.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600269C RID: 9884 RVA: 0x00438710 File Offset: 0x00436910
	public void RecvClickPutOn()
	{
		UIItemInfo uiitemInfo = this.Target as UIItemInfo;
		if (uiitemInfo != null)
		{
			uiitemInfo.OnButtonClick(uiitemInfo.m_Button1);
		}
	}

	// Token: 0x0600269D RID: 9885 RVA: 0x0043873C File Offset: 0x0043693C
	public void UpdateRank1()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x0600269E RID: 9886 RVA: 0x0043875C File Offset: 0x0043695C
	public void RecvUpdateRank1()
	{
		NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, this.Target, false);
	}

	// Token: 0x0600269F RID: 9887 RVA: 0x00438770 File Offset: 0x00436970
	public void UpdateRank2()
	{
		UIHero_Info uihero_Info = this.Target as UIHero_Info;
		if (uihero_Info != null)
		{
			RectTransform rt = uihero_Info.btn_Evolution.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x060026A0 RID: 9888 RVA: 0x004387C0 File Offset: 0x004369C0
	public void RecvUpdateRank2()
	{
		UIHero_Info uihero_Info = this.Target as UIHero_Info;
		if (uihero_Info != null)
		{
			uihero_Info.OnButtonClick(uihero_Info.btn_Evolution);
		}
		Transform child = GUIManager.Instance.m_MessageBoxLayer.GetChild(0);
		child.SetParent(GUIManager.Instance.m_FourthWindowLayer, false);
	}

	// Token: 0x060026A1 RID: 9889 RVA: 0x00438814 File Offset: 0x00436A14
	public void UpdateRank3()
	{
		Transform child = GUIManager.Instance.m_FourthWindowLayer.GetChild(GUIManager.Instance.m_FourthWindowLayer.childCount - 1);
		if (child == null)
		{
			this.IgnoreStep(true, -1);
		}
		RectTransform rt = child.GetChild(1).GetChild(3).GetChild(5) as RectTransform;
		Vector2 vector = this.UIController.ScreenPointTest(rt);
		this.SetupUI(ref vector, false, 0, 0);
	}

	// Token: 0x060026A2 RID: 9890 RVA: 0x00438888 File Offset: 0x00436A88
	public void RecvUpdateRank3()
	{
		GUIManager.Instance.CloseOKCancelBox();
		UIHero_Info uihero_Info = GUIManager.Instance.FindMenu(EGUIWindow.UI_Hero_Info) as UIHero_Info;
		if (uihero_Info != null)
		{
			uihero_Info.OnOKCancelBoxClick(false, 1, 0);
		}
	}

	// Token: 0x060026A3 RID: 9891 RVA: 0x004388C8 File Offset: 0x00436AC8
	public void UpdateRank4()
	{
		UIHero_Info uihero_Info = this.Target as UIHero_Info;
		if (uihero_Info != null)
		{
			RectTransform rt = uihero_Info.timeBarRank.m_FuntionBtn.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x060026A4 RID: 9892 RVA: 0x0043891C File Offset: 0x00436B1C
	public void RecvUpdateRank4()
	{
		UIHero_Info uihero_Info = this.Target as UIHero_Info;
		if (uihero_Info != null)
		{
			uihero_Info.timeBarRank.OnButtonClick(uihero_Info.timeBarRank.m_FuntionBtn);
		}
		NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, null, false);
	}

	// Token: 0x060026A5 RID: 9893 RVA: 0x00438964 File Offset: 0x00436B64
	public void UpdateRank5()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026A6 RID: 9894 RVA: 0x00438984 File Offset: 0x00436B84
	public void RecvUpdateRank5()
	{
		NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, null, false);
	}

	// Token: 0x060026A7 RID: 9895 RVA: 0x00438990 File Offset: 0x00436B90
	public void UpdateRank6()
	{
		UIHero_Info uihero_Info = GUIManager.Instance.FindMenu(EGUIWindow.UI_Hero_Info) as UIHero_Info;
		if (uihero_Info != null)
		{
			RectTransform rt = uihero_Info.btn_EXIT.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x060026A8 RID: 9896 RVA: 0x004389E4 File Offset: 0x00436BE4
	public void RecvUpdateRank6()
	{
		UIHero_Info uihero_Info = GUIManager.Instance.FindMenu(EGUIWindow.UI_Hero_Info) as UIHero_Info;
		if (uihero_Info != null)
		{
			uihero_Info.OnButtonClick(uihero_Info.btn_EXIT);
			NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, null, false);
		}
	}

	// Token: 0x060026A9 RID: 9897 RVA: 0x00438A28 File Offset: 0x00436C28
	public void UpdateRank7()
	{
		UIHeroList uiheroList = GUIManager.Instance.FindMenu(EGUIWindow.UI_HeroList) as UIHeroList;
		if (uiheroList != null)
		{
			RectTransform rt = uiheroList.exitButton.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x060026AA RID: 9898 RVA: 0x00438A7C File Offset: 0x00436C7C
	public void RecvUpdateRank7()
	{
		this.RemoveFlag(ETeachKind.PUTON_EQUIP, 1, false);
		this.LockControl(false);
		UIHeroList uiheroList = GUIManager.Instance.FindMenu(EGUIWindow.UI_HeroList) as UIHeroList;
		if (uiheroList != null)
		{
			uiheroList.OnButtonClick(uiheroList.exitButton);
		}
	}

	// Token: 0x060026AB RID: 9899 RVA: 0x00438AC4 File Offset: 0x00436CC4
	public void Turbo1()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026AC RID: 9900 RVA: 0x00438AE4 File Offset: 0x00436CE4
	public void RecvTurbo1()
	{
		if (DataManager.Instance.RoleAlliance.Id == 0u)
		{
			this.SubStep++;
		}
		NewbieManager.CheckTeach(ETeachKind.TURBO, this.Target, false);
	}

	// Token: 0x060026AD RID: 9901 RVA: 0x00438B18 File Offset: 0x00436D18
	public void Turbo2()
	{
		RectTransform rt = ((UITimeBar)this.Target).gameObject.transform.GetChild(6).GetChild(0) as RectTransform;
		Vector2 vector = this.UIController.ScreenPointTest(rt);
		this.SetupUI(ref vector, false, 0, 0);
	}

	// Token: 0x060026AE RID: 9902 RVA: 0x00438B64 File Offset: 0x00436D64
	public void RecvTurbo2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.Onfunc((UITimeBar)this.Target);
		}
		NewbieManager.CheckTeach(ETeachKind.TURBO, this.Target, false);
	}

	// Token: 0x060026AF RID: 9903 RVA: 0x00438BB0 File Offset: 0x00436DB0
	public void Turbo3()
	{
		RectTransform rt = ((UITimeBar)this.Target).gameObject.transform.GetChild(6).GetChild(0) as RectTransform;
		Vector2 vector = this.UIController.ScreenPointTest(rt);
		this.SetupUI(ref vector, false, 0, 0);
	}

	// Token: 0x060026B0 RID: 9904 RVA: 0x00438BFC File Offset: 0x00436DFC
	public void RecvTurbo3()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.Onfunc((UITimeBar)this.Target);
		}
		NewbieManager.CheckTeach(ETeachKind.TURBO, this.Target, false);
	}

	// Token: 0x060026B1 RID: 9905 RVA: 0x00438C48 File Offset: 0x00436E48
	public void Turbo4()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026B2 RID: 9906 RVA: 0x00438C68 File Offset: 0x00436E68
	public void RecvTurbo4()
	{
		this.RestoreTimeBarStatus();
		this.RemoveFlag(ETeachKind.TURBO, 1, false);
		this.LockControl(false);
	}

	// Token: 0x060026B3 RID: 9907 RVA: 0x00438C84 File Offset: 0x00436E84
	public void GoldGuy1()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026B4 RID: 9908 RVA: 0x00438CA4 File Offset: 0x00436EA4
	public void RecvGoldGuy1()
	{
		NewbieManager.CheckTeach(ETeachKind.GOLDGUY, null, false);
	}

	// Token: 0x060026B5 RID: 9909 RVA: 0x00438CB0 File Offset: 0x00436EB0
	public void GoldGuy2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			RectTransform rt = door.m_MoraleBox.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x060026B6 RID: 9910 RVA: 0x00438D04 File Offset: 0x00436F04
	public void RecvGoldGuy2()
	{
		Origin origin = GameManager.ActiveGameplay as Origin;
		if (origin != null)
		{
			origin.WorldController.cameraController.CameraMoveTarget(CameraState.Build, GUIManager.Instance.BuildingData.ManorGride[2].position);
		}
		NewbieManager.CheckTeach(ETeachKind.GOLDGUY, null, false);
	}

	// Token: 0x060026B7 RID: 9911 RVA: 0x00438D54 File Offset: 0x00436F54
	public void GoldGuy3()
	{
		Transform transform = GUIManager.Instance.BuildingData.ManorGride[2];
		Vector2 vector = Camera.main.WorldToScreenPoint(transform.position);
		float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
		vector /= scaleFactor;
		vector.y += 97f;
		vector = this.CheckMirror(vector);
		this.SetupUI(ref vector, false, 0, 0);
	}

	// Token: 0x060026B8 RID: 9912 RVA: 0x00438DC8 File Offset: 0x00436FC8
	public void RecvGoldGuy3()
	{
		Door doorController = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		GUIManager.Instance.BuildingData.OpenUI(100, doorController);
		this.RemoveFlag(ETeachKind.GOLDGUY, 1, false);
		this.LockControl(false);
	}

	// Token: 0x060026B9 RID: 9913 RVA: 0x00438E0C File Offset: 0x0043700C
	public void GotoSmith()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x060026BA RID: 9914 RVA: 0x00438E2C File Offset: 0x0043702C
	public void RecvGotoSmith()
	{
		this.MoveNext(null);
	}

	// Token: 0x060026BB RID: 9915 RVA: 0x00438E38 File Offset: 0x00437038
	public void GotoSmith2()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x060026BC RID: 9916 RVA: 0x00438E58 File Offset: 0x00437058
	public void RecvGotoSmith2()
	{
		this.MoveNext(null);
	}

	// Token: 0x060026BD RID: 9917 RVA: 0x00438E64 File Offset: 0x00437064
	public void GotoSmith3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026BE RID: 9918 RVA: 0x00438E84 File Offset: 0x00437084
	public void RecvGotoSmith3()
	{
		this.RemoveFlag(ETeachKind.SMITH, 1, false);
		this.LockControl(false);
	}

	// Token: 0x060026BF RID: 9919 RVA: 0x00438E98 File Offset: 0x00437098
	public void IntoActivity()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026C0 RID: 9920 RVA: 0x00438EB8 File Offset: 0x004370B8
	public void RecvIntoActivity()
	{
		NewbieManager.CheckTeach(ETeachKind.ACTIVITY, null, false);
	}

	// Token: 0x060026C1 RID: 9921 RVA: 0x00438EC4 File Offset: 0x004370C4
	public void IntoActivity2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			RectTransform rt = door.m_ActivityBtnT as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x060026C2 RID: 9922 RVA: 0x00438F14 File Offset: 0x00437114
	public void RecvIntoActivity2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			UIButton component = door.m_ActivityBtnT.GetChild(2).GetComponent<UIButton>();
			if (component != null)
			{
				door.OnButtonClick(component);
			}
		}
		this.RemoveFlag(ETeachKind.ACTIVITY, 1, false);
		this.LockControl(false);
	}

	// Token: 0x060026C3 RID: 9923 RVA: 0x00438F74 File Offset: 0x00437174
	public void GetNewHero()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026C4 RID: 9924 RVA: 0x00438F94 File Offset: 0x00437194
	public void RecvGetNewHero()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_bShowFuncButton != 1)
		{
			door.ShowFuncButton(true);
		}
		NewbieManager.CheckTeach(ETeachKind.NEW_HERO, door, false);
	}

	// Token: 0x060026C5 RID: 9925 RVA: 0x00438FDC File Offset: 0x004371DC
	public void GetNewHero2()
	{
		Door door = this.Target as Door;
		if (door != null)
		{
			RectTransform rt = door.m_FuncRC[0];
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x060026C6 RID: 9926 RVA: 0x00439024 File Offset: 0x00437224
	public void RecvGetNewHero2()
	{
		Door door = this.Target as Door;
		if (door != null)
		{
			door.OnButtonClick(door.m_FuncRC[0].GetChild(1).GetComponent<UIButton>());
		}
	}

	// Token: 0x060026C7 RID: 9927 RVA: 0x00439064 File Offset: 0x00437264
	public void GetNewHero3()
	{
		UIHeroList uiheroList = this.Target as UIHeroList;
		if (uiheroList != null && uiheroList.scrolCont.GetChild(0) != null && uiheroList.scrolCont.GetChild(0).GetChild(0).GetChild(9) != null)
		{
			RectTransform rt = uiheroList.scrolCont.GetChild(0).GetChild(0).GetChild(9) as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x060026C8 RID: 9928 RVA: 0x00439108 File Offset: 0x00437308
	public void RecvGetNewHero3()
	{
		UIHeroList uiheroList = this.Target as UIHeroList;
		if (uiheroList != null)
		{
			GameObject gameObject = uiheroList.scrolCont.GetChild(0).gameObject;
			uiheroList.ButtonOnClick(gameObject, 0);
			if (uiheroList.checkPanel.gameObject.activeSelf)
			{
				NewbieManager.CheckTeach(ETeachKind.NEW_HERO, this.Target, false);
			}
			else
			{
				this.IgnoreStep(true, -1);
			}
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x060026C9 RID: 9929 RVA: 0x00439188 File Offset: 0x00437388
	public void GetNewHero4()
	{
		UIHeroList uiheroList = this.Target as UIHeroList;
		if (uiheroList != null)
		{
			RectTransform rt = uiheroList.checkPanel.GetChild(7) as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x060026CA RID: 9930 RVA: 0x004391D8 File Offset: 0x004373D8
	public void RecvGetNewHero4()
	{
		UIHeroList uiheroList = this.Target as UIHeroList;
		if (uiheroList != null)
		{
			UIButton component = uiheroList.checkPanel.GetChild(7).GetComponent<UIButton>();
			if (component != null)
			{
				GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Newbie_Protocal_ExtLock);
				uiheroList.OnButtonClick(component);
			}
		}
		this.RemoveFlag(ETeachKind.NEW_HERO, 1, false);
		this.LockControl(false);
	}

	// Token: 0x060026CB RID: 9931 RVA: 0x00439244 File Offset: 0x00437444
	public void TWipeOut()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026CC RID: 9932 RVA: 0x00439264 File Offset: 0x00437464
	public void RecvTWipeOut()
	{
		NewbieManager.CheckTeach(ETeachKind.WIPE_OUT, null, false);
	}

	// Token: 0x060026CD RID: 9933 RVA: 0x00439270 File Offset: 0x00437470
	public void TWipeOut2()
	{
		UIStageInfo uistageInfo = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
		if (uistageInfo != null)
		{
			Vector2 vector = this.UIController.ScreenPointTest(uistageInfo.Play1T as RectTransform);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x060026CE RID: 9934 RVA: 0x004392CC File Offset: 0x004374CC
	public void RecvTWipeOut2()
	{
		UIStageInfo uistageInfo = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
		if (uistageInfo != null)
		{
			UIButton component = uistageInfo.Play1T.GetComponent<UIButton>();
			if (component != null)
			{
				uistageInfo.OnButtonClick(component);
			}
		}
	}

	// Token: 0x060026CF RID: 9935 RVA: 0x00439318 File Offset: 0x00437518
	public void TWipeOut3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026D0 RID: 9936 RVA: 0x00439338 File Offset: 0x00437538
	public void RecvTWipeOut3()
	{
		NewbieManager.CheckTeach(ETeachKind.WIPE_OUT, this.Target, false);
	}

	// Token: 0x060026D1 RID: 9937 RVA: 0x0043934C File Offset: 0x0043754C
	public void TWipeOut4()
	{
		UIBattleReport uibattleReport = this.Target as UIBattleReport;
		if (uibattleReport != null)
		{
			RectTransform rt = uibattleReport.ContentT.GetChild(3) as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x060026D2 RID: 9938 RVA: 0x004393A8 File Offset: 0x004375A8
	public void RecvTWipeOut4()
	{
		NewbieManager.CheckTeach(ETeachKind.WIPE_OUT, this.Target, false);
	}

	// Token: 0x060026D3 RID: 9939 RVA: 0x004393BC File Offset: 0x004375BC
	public void TWipeOut5()
	{
		UIBattleReport uibattleReport = this.Target as UIBattleReport;
		if (uibattleReport != null)
		{
			Transform child = uibattleReport.ContentT.GetChild(0);
			RectTransform rt = child as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x060026D4 RID: 9940 RVA: 0x0043941C File Offset: 0x0043761C
	public void RecvTWipeOut5()
	{
		NewbieManager.CheckTeach(ETeachKind.WIPE_OUT, this.Target, false);
	}

	// Token: 0x060026D5 RID: 9941 RVA: 0x00439430 File Offset: 0x00437630
	public void TWipeOut6()
	{
		UIBattleReport uibattleReport = this.Target as UIBattleReport;
		if (uibattleReport != null)
		{
			Vector2 vector = this.UIController.ScreenPointTest(uibattleReport.ContentT.GetChild(2).GetChild(1) as RectTransform);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x060026D6 RID: 9942 RVA: 0x00439490 File Offset: 0x00437690
	public void RecvTWipeOut6()
	{
		this.RemoveFlag(ETeachKind.WIPE_OUT, 1, false);
		this.LockControl(false);
	}

	// Token: 0x060026D7 RID: 9943 RVA: 0x004394A4 File Offset: 0x004376A4
	public void WorldAttack1()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
		this.Controller.SetSpecialBox(true, 1);
		this.Controller.PreClickFlag = 1;
	}

	// Token: 0x060026D8 RID: 9944 RVA: 0x004394DC File Offset: 0x004376DC
	public void RecvWorldAttack1()
	{
		this.MoveNext(null);
	}

	// Token: 0x060026D9 RID: 9945 RVA: 0x004394E8 File Offset: 0x004376E8
	public void WorldAttack2()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x060026DA RID: 9946 RVA: 0x00439508 File Offset: 0x00437708
	public void RecvWorldAttack2()
	{
		this.MoveNext(null);
	}

	// Token: 0x060026DB RID: 9947 RVA: 0x00439514 File Offset: 0x00437714
	public void WorldAttack3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x060026DC RID: 9948 RVA: 0x00439534 File Offset: 0x00437734
	public void RecvWorldAttack3()
	{
		this.MoveNext(null);
	}

	// Token: 0x060026DD RID: 9949 RVA: 0x00439540 File Offset: 0x00437740
	public void WorldAttack4()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
		this.Controller.PreClickFlag = 0;
	}

	// Token: 0x060026DE RID: 9950 RVA: 0x0043956C File Offset: 0x0043776C
	public void RecvWorldAttack4()
	{
		this.RemoveFlag(ETeachKind.WORLD_ATTACK, 1, false);
		this.LockControl(false);
		this.SuckBugProtector();
		this.WorldTeach_Point = DataManager.Instance.ServerTime;
	}

	// Token: 0x060026DF RID: 9951 RVA: 0x004395A0 File Offset: 0x004377A0
	public void WorldHunt1()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
		this.Controller.SetSpecialBox(true, 2);
		this.Controller.PreClickFlag = 1;
	}

	// Token: 0x060026E0 RID: 9952 RVA: 0x004395D8 File Offset: 0x004377D8
	public void RecvWorldHunt1()
	{
		this.MoveNext(null);
	}

	// Token: 0x060026E1 RID: 9953 RVA: 0x004395E4 File Offset: 0x004377E4
	public void WorldHunt2()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x060026E2 RID: 9954 RVA: 0x00439604 File Offset: 0x00437804
	public void RecvWorldHunt2()
	{
		this.MoveNext(null);
	}

	// Token: 0x060026E3 RID: 9955 RVA: 0x00439610 File Offset: 0x00437810
	public void WorldHunt3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
		this.Controller.PreClickFlag = 0;
	}

	// Token: 0x060026E4 RID: 9956 RVA: 0x0043963C File Offset: 0x0043783C
	public void RecvWorldHunt3()
	{
		this.RemoveFlag(ETeachKind.WORLD_HUNT, 1, false);
		this.LockControl(false);
		this.SuckBugProtector();
		this.WorldTeach_Point = DataManager.Instance.ServerTime;
	}

	// Token: 0x060026E5 RID: 9957 RVA: 0x00439670 File Offset: 0x00437870
	public void GoAutoBattle()
	{
		UIBattle uibattle = this.Target as UIBattle;
		uibattle.ultraSkillWorking = true;
		uibattle.bc.updateMaxSkillFreeze(true);
		uibattle.bc.m_BattleState = BattleController.BattleState.BATTLE_MAXSKILL_WORKING;
		RectTransform rt = uibattle.autoButtonUp.transform as RectTransform;
		Vector2 vector = this.UIController.ScreenPointTest(rt);
		this.SetupUI(ref vector, false, 0, 0);
	}

	// Token: 0x060026E6 RID: 9958 RVA: 0x004396D4 File Offset: 0x004378D4
	public void RecvGoAutoBattle()
	{
		UIBattle uibattle = this.Target as UIBattle;
		uibattle.ultraSkillWorking = false;
		uibattle.bc.updateMaxSkillFreeze(false);
		uibattle.bc.m_BattleState = BattleController.BattleState.BATTLE_RUNNING;
		uibattle.bc.deltaTime = 0f;
		uibattle.bc.m_SubStateFlag = 0;
		uibattle.OnButtonClick(uibattle.autoButtonUp);
		NewbieManager.AutoBattleFlag = false;
		this.RemoveFlag(ETeachKind.AUTO_BATTLE, 1, false);
		this.LockControl(false);
	}

	// Token: 0x060026E7 RID: 9959 RVA: 0x0043974C File Offset: 0x0043794C
	public void GoEliteStage1()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x060026E8 RID: 9960 RVA: 0x0043976C File Offset: 0x0043796C
	public void RecvGoEliteStage1()
	{
		this.MoveNext(null);
	}

	// Token: 0x060026E9 RID: 9961 RVA: 0x00439778 File Offset: 0x00437978
	public void GoEliteStage2()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026EA RID: 9962 RVA: 0x00439798 File Offset: 0x00437998
	public void RecvGoEliteStage2()
	{
		this.MoveNext(null);
	}

	// Token: 0x060026EB RID: 9963 RVA: 0x004397A4 File Offset: 0x004379A4
	public void GoEliteStage3()
	{
		UIStageSelect uistageSelect = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
		if (uistageSelect != null)
		{
			RectTransform rt = uistageSelect.transform.GetChild(2).transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x060026EC RID: 9964 RVA: 0x00439800 File Offset: 0x00437A00
	public void RecvGoEliteStage3()
	{
		this.RemoveFlag(ETeachKind.ELITE_STAGE, 1, false);
		this.LockControl(false);
		UIStageSelect uistageSelect = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
		if (uistageSelect != null)
		{
			UIButton component = uistageSelect.transform.GetChild(2).GetComponent<UIButton>();
			uistageSelect.OnButtonClick(component);
		}
	}

	// Token: 0x060026ED RID: 9965 RVA: 0x00439854 File Offset: 0x00437A54
	public void GoArena()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026EE RID: 9966 RVA: 0x00439874 File Offset: 0x00437A74
	public void RecvGoArena()
	{
		GUIManager.Instance.BuildingData.ArneaGuild();
		NewbieManager.CheckTeach(ETeachKind.ARENA, null, false);
	}

	// Token: 0x060026EF RID: 9967 RVA: 0x00439890 File Offset: 0x00437A90
	public void GoArena2()
	{
		Transform transform = GUIManager.Instance.BuildingData.ManorGride[3];
		Vector2 vector = Camera.main.WorldToScreenPoint(transform.position);
		float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
		vector /= scaleFactor;
		vector += new Vector2(7f, 90f);
		vector = this.CheckMirror(vector);
		this.SetupUI(ref vector, false, 0, 0);
	}

	// Token: 0x060026F0 RID: 9968 RVA: 0x00439908 File Offset: 0x00437B08
	public void RecvGoArena2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_Arena, 0, 0, false);
		}
	}

	// Token: 0x060026F1 RID: 9969 RVA: 0x00439940 File Offset: 0x00437B40
	public void GoArena3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x060026F2 RID: 9970 RVA: 0x00439960 File Offset: 0x00437B60
	public void RecvGoArena3()
	{
		this.MoveNext(null);
	}

	// Token: 0x060026F3 RID: 9971 RVA: 0x0043996C File Offset: 0x00437B6C
	public void GoArena4()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026F4 RID: 9972 RVA: 0x0043998C File Offset: 0x00437B8C
	public void RecvGoArena4()
	{
		this.MoveNext(null);
	}

	// Token: 0x060026F5 RID: 9973 RVA: 0x00439998 File Offset: 0x00437B98
	public void GoArena5()
	{
		UIArena uiarena = GUIManager.Instance.FindMenu(EGUIWindow.UI_Arena) as UIArena;
		if (uiarena != null)
		{
			RectTransform rt = uiarena.btn_Defend.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x060026F6 RID: 9974 RVA: 0x004399EC File Offset: 0x00437BEC
	public void RecvGoArena5()
	{
		this.RemoveFlag(ETeachKind.ARENA, 1, false);
		this.LockControl(false);
	}

	// Token: 0x060026F7 RID: 9975 RVA: 0x00439A00 File Offset: 0x00437C00
	public void GoArmyHole()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026F8 RID: 9976 RVA: 0x00439A20 File Offset: 0x00437C20
	public void RecvGoArmyHole()
	{
		GUIManager.Instance.BuildingData.DugoutGuild();
		NewbieManager.CheckTeach(ETeachKind.ARMY_HOLE, null, false);
	}

	// Token: 0x060026F9 RID: 9977 RVA: 0x00439A3C File Offset: 0x00437C3C
	public void GoArmyHole2()
	{
		Transform transform = GUIManager.Instance.BuildingData.ManorGride[4];
		Vector2 vector = Camera.main.WorldToScreenPoint(transform.position);
		float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
		vector /= scaleFactor;
		vector += new Vector2(-3f, 60f);
		vector = this.CheckMirror(vector);
		this.SetupUI(ref vector, false, 0, 0);
	}

	// Token: 0x060026FA RID: 9978 RVA: 0x00439AB4 File Offset: 0x00437CB4
	public void RecvGoArmyHole2()
	{
		HideArmyManager.Instance.OpenHideArmyUI();
		NewbieManager.CheckTeach(ETeachKind.ARMY_HOLE, null, false);
	}

	// Token: 0x060026FB RID: 9979 RVA: 0x00439ACC File Offset: 0x00437CCC
	public void GoArmyHole3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026FC RID: 9980 RVA: 0x00439AEC File Offset: 0x00437CEC
	public void RecvGoArmyHole3()
	{
		this.RemoveFlag(ETeachKind.ARMY_HOLE, 1, false);
		this.LockControl(false);
	}

	// Token: 0x060026FD RID: 9981 RVA: 0x00439B00 File Offset: 0x00437D00
	public void GoBlackMarket1()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x060026FE RID: 9982 RVA: 0x00439B20 File Offset: 0x00437D20
	public void RecvGoBlackMarket1()
	{
		GUIManager.Instance.BuildingData.BlackMarketGuild();
		NewbieManager.CheckTeach(ETeachKind.BLACK_MARKET, null, false);
	}

	// Token: 0x060026FF RID: 9983 RVA: 0x00439B3C File Offset: 0x00437D3C
	public void GoBlackMarket2()
	{
		Transform transform = GUIManager.Instance.BuildingData.ManorGride[5];
		Vector2 vector = Camera.main.WorldToScreenPoint(transform.position);
		float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
		vector /= scaleFactor;
		vector += new Vector2(-3f, 70f);
		vector = this.CheckMirror(vector);
		this.SetupUI(ref vector, false, 0, 0);
	}

	// Token: 0x06002700 RID: 9984 RVA: 0x00439BB4 File Offset: 0x00437DB4
	public void RecvGoBlackMarket2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_Merchantman, 0, 0, false);
		}
		NewbieManager.CheckTeach(ETeachKind.BLACK_MARKET, null, false);
	}

	// Token: 0x06002701 RID: 9985 RVA: 0x00439BF4 File Offset: 0x00437DF4
	public void GoBlackMarket3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002702 RID: 9986 RVA: 0x00439C14 File Offset: 0x00437E14
	public void RecvGoBlackMarket3()
	{
		this.RemoveFlag(ETeachKind.BLACK_MARKET, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002703 RID: 9987 RVA: 0x00439C28 File Offset: 0x00437E28
	private void GoTroopMemory()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002704 RID: 9988 RVA: 0x00439C48 File Offset: 0x00437E48
	private void RecvGoTroopMemory()
	{
		GUIManager.Instance.BuildingData.WarLobbyGuide();
		NewbieManager.CheckTeach(ETeachKind.TROOP_MEMORY, null, false);
	}

	// Token: 0x06002705 RID: 9989 RVA: 0x00439C64 File Offset: 0x00437E64
	private void GoTroopMemory2()
	{
		Transform transform = GUIManager.Instance.BuildingData.ManorGride[6];
		if (transform != null)
		{
			Vector2 vector = Camera.main.WorldToScreenPoint(transform.position);
			float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
			vector /= scaleFactor;
			vector += new Vector2(-3f, 60f);
			vector = this.CheckMirror(vector);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002706 RID: 9990 RVA: 0x00439CF4 File Offset: 0x00437EF4
	private void RecvGoTroopMemory2()
	{
		GUIManager.Instance.BuildingData.OpenWarlobbyUI();
		NewbieManager.CheckTeach(ETeachKind.TROOP_MEMORY, null, false);
	}

	// Token: 0x06002707 RID: 9991 RVA: 0x00439D10 File Offset: 0x00437F10
	private void GoTroopMemory3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002708 RID: 9992 RVA: 0x00439D30 File Offset: 0x00437F30
	private void RecvGoTroopMemory3()
	{
		this.RemoveFlag(ETeachKind.TROOP_MEMORY, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002709 RID: 9993 RVA: 0x00439D44 File Offset: 0x00437F44
	private void GoDeShield()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x0600270A RID: 9994 RVA: 0x00439D64 File Offset: 0x00437F64
	private void RecvGoDeShield()
	{
		NewbieManager.CheckTeach(ETeachKind.DESHIELD, null, false);
	}

	// Token: 0x0600270B RID: 9995 RVA: 0x00439D70 File Offset: 0x00437F70
	private void GoDeShield2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_BuffRC != null)
		{
			Vector2 vector = this.UIController.ScreenPointTest(door.m_BuffBtn.GetComponent<RectTransform>());
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x0600270C RID: 9996 RVA: 0x00439DDC File Offset: 0x00437FDC
	private void RecvGoDeShield2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_BuffBtn != null)
		{
			door.OnButtonClick(door.m_BuffBtn);
			NewbieManager.CheckTeach(ETeachKind.DESHIELD, null, false);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x0600270D RID: 9997 RVA: 0x00439E3C File Offset: 0x0043803C
	private void GoDeShield3()
	{
		UIBuffList uibuffList = GUIManager.Instance.FindMenu(EGUIWindow.UI_BuffList) as UIBuffList;
		if (uibuffList == null)
		{
			this.IgnoreStep(true, -1);
			return;
		}
		int num = -1;
		int count = uibuffList.m_Data.Count;
		for (int i = 0; i < count; i++)
		{
			if ((int)uibuffList.m_Data[i] < this.DM.m_SortBuffData.Length)
			{
				int index = (int)this.DM.m_SortBuffData[(int)uibuffList.m_Data[i]];
				if (this.DM.ItemBuffTable.GetRecordByIndex(index).BuffKind == 7)
				{
					num = i;
				}
			}
		}
		if (num == -1)
		{
			this.IgnoreStep(true, -1);
			return;
		}
		Transform child;
		if ((child = uibuffList.transform.GetChild(1)) != null && (child = child.GetChild(0)) != null && (child = child.GetChild(num)) != null)
		{
			Vector2 vector = this.UIController.ScreenPointTest(child as RectTransform);
			vector.x += 20f;
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x0600270E RID: 9998 RVA: 0x00439F88 File Offset: 0x00438188
	private void RecvGoDeShield3()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_BuffInformation, 0, 0, false);
		}
		this.RemoveFlag(ETeachKind.DESHIELD, 1, false);
		this.LockControl(false);
	}

	// Token: 0x0600270F RID: 9999 RVA: 0x00439FD0 File Offset: 0x004381D0
	public void GoCoord()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002710 RID: 10000 RVA: 0x00439FF0 File Offset: 0x004381F0
	public void RecvGoCoord()
	{
		NewbieManager.CheckTeach(ETeachKind.ARMY_COORD, null, false);
	}

	// Token: 0x06002711 RID: 10001 RVA: 0x00439FFC File Offset: 0x004381FC
	public void GoCoord2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_HeadImage != null)
		{
			Vector2 vector = this.UIController.ScreenPointTest(door.m_HeadImage.gameObject.GetComponent<RectTransform>());
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002712 RID: 10002 RVA: 0x0043A06C File Offset: 0x0043826C
	public void RecvGoCoord2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_LordInfo, 1, 0, true);
			NewbieManager.CheckTeach(ETeachKind.ARMY_COORD, null, false);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002713 RID: 10003 RVA: 0x0043A0BC File Offset: 0x004382BC
	public void GoCoord3()
	{
		UILordInfo uilordInfo = GUIManager.Instance.FindMenu(EGUIWindow.UI_LordInfo) as UILordInfo;
		if (uilordInfo != null && uilordInfo.CoordBtnRT != null)
		{
			Vector2 vector = this.UIController.ScreenPointTest(uilordInfo.CoordBtnRT);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002714 RID: 10004 RVA: 0x0043A124 File Offset: 0x00438324
	public void RecvGoCoord3()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_FormationSelect, 0, 0, false);
			NewbieManager.CheckTeach(ETeachKind.ARMY_COORD, null, false);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002715 RID: 10005 RVA: 0x0043A174 File Offset: 0x00438374
	public void GoCoord4()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002716 RID: 10006 RVA: 0x0043A194 File Offset: 0x00438394
	public void RecvGoCoord4()
	{
		this.RemoveFlag(ETeachKind.ARMY_COORD, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002717 RID: 10007 RVA: 0x0043A1A8 File Offset: 0x004383A8
	private void PressX()
	{
		UIStageSelect uistageSelect = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
		if (uistageSelect != null)
		{
			Vector2 vector = Camera.main.WorldToScreenPoint(uistageSelect.m_ExitBtn.transform.position);
			float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
			vector /= scaleFactor;
			vector = this.CheckMirror(vector);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002718 RID: 10008 RVA: 0x0043A220 File Offset: 0x00438420
	private void RecvPressX()
	{
		UIStageSelect uistageSelect = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
		if (uistageSelect != null)
		{
			uistageSelect.OnButtonClick(uistageSelect.m_ExitBtn);
		}
		this.RemoveFlag(ETeachKind.PRESS_X, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002719 RID: 10009 RVA: 0x0043A268 File Offset: 0x00438468
	public void GoMetallurgy()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x0600271A RID: 10010 RVA: 0x0043A288 File Offset: 0x00438488
	public void RecvGoMetallurgy()
	{
		GUIManager.Instance.BuildingData.LaboratoryGuide();
		NewbieManager.CheckTeach(ETeachKind.METALLURGY, null, false);
	}

	// Token: 0x0600271B RID: 10011 RVA: 0x0043A2A4 File Offset: 0x004384A4
	public void GoMetallurgy2()
	{
		Transform transform = GUIManager.Instance.BuildingData.ManorGride[8];
		Vector2 vector = Camera.main.WorldToScreenPoint(transform.position);
		float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
		vector /= scaleFactor;
		vector += new Vector2(0f, 80f);
		vector = this.CheckMirror(vector);
		this.SetupUI(ref vector, false, 0, 0);
	}

	// Token: 0x0600271C RID: 10012 RVA: 0x0043A31C File Offset: 0x0043851C
	public void RecvGoMetallurgy2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			GUIManager.Instance.BuildingData.OpenUI(105, door);
			NewbieManager.CheckTeach(ETeachKind.METALLURGY, null, false);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x0600271D RID: 10013 RVA: 0x0043A370 File Offset: 0x00438570
	public void GoMetallurgy3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x0600271E RID: 10014 RVA: 0x0043A390 File Offset: 0x00438590
	public void RecvGoMetallurgy3()
	{
		NewbieManager.CheckTeach(ETeachKind.METALLURGY, null, false);
	}

	// Token: 0x0600271F RID: 10015 RVA: 0x0043A39C File Offset: 0x0043859C
	public void GoMetallurgy4()
	{
		UIAlchemy uialchemy = GUIManager.Instance.FindMenu(EGUIWindow.UIAlchemy) as UIAlchemy;
		if (uialchemy != null)
		{
			Vector2 vector = Camera.main.WorldToScreenPoint(uialchemy.WPT[0].position);
			float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
			vector /= scaleFactor;
			vector = this.CheckMirror(vector);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002720 RID: 10016 RVA: 0x0043A420 File Offset: 0x00438620
	public void RecvGoMetallurgy4()
	{
		UIAlchemy uialchemy = GUIManager.Instance.FindMenu(EGUIWindow.UIAlchemy) as UIAlchemy;
		if (uialchemy != null)
		{
			uialchemy.OpenFront2(0);
			NewbieManager.CheckTeach(ETeachKind.METALLURGY, null, false);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002721 RID: 10017 RVA: 0x0043A46C File Offset: 0x0043866C
	public void GoMetallurgy5()
	{
		UIAlchemy uialchemy = GUIManager.Instance.FindMenu(EGUIWindow.UIAlchemy) as UIAlchemy;
		if (uialchemy != null)
		{
			Vector2 vector = this.UIController.ScreenPointTest((RectTransform)uialchemy.tFront2.GetChild(8));
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002722 RID: 10018 RVA: 0x0043A4D0 File Offset: 0x004386D0
	public void RecvGoMetallurgy5()
	{
		UIAlchemy uialchemy = GUIManager.Instance.FindMenu(EGUIWindow.UIAlchemy) as UIAlchemy;
		if (uialchemy != null)
		{
			uialchemy.OnButtonClick(uialchemy.tFront2.GetChild(8).GetComponent<UIButton>());
		}
		NewbieManager.CheckTeach(ETeachKind.METALLURGY, null, false);
	}

	// Token: 0x06002723 RID: 10019 RVA: 0x0043A520 File Offset: 0x00438720
	public void GoMetallurgy6()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002724 RID: 10020 RVA: 0x0043A540 File Offset: 0x00438740
	public void RecvGoMetallurgy6()
	{
		this.RemoveFlag(ETeachKind.METALLURGY, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002725 RID: 10021 RVA: 0x0043A554 File Offset: 0x00438754
	public void GoGambleNormal()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002726 RID: 10022 RVA: 0x0043A574 File Offset: 0x00438774
	public void RecvGoGambleNormal()
	{
		GUIManager.Instance.BuildingData.CasinoGuide();
		NewbieManager.CheckTeach(ETeachKind.GAMBLING1, null, false);
	}

	// Token: 0x06002727 RID: 10023 RVA: 0x0043A590 File Offset: 0x00438790
	public void GoGambleNormal2()
	{
		Transform transform = GUIManager.Instance.BuildingData.ManorGride[7];
		Vector2 vector = Camera.main.WorldToScreenPoint(transform.position);
		float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
		vector /= scaleFactor;
		vector += new Vector2(3f, 60f);
		vector = this.CheckMirror(vector);
		this.SetupUI(ref vector, false, 0, 0);
	}

	// Token: 0x06002728 RID: 10024 RVA: 0x0043A608 File Offset: 0x00438808
	public void RecvGoGambleNormal2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			GUIManager.Instance.BuildingData.OpenUI(106, door);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002729 RID: 10025 RVA: 0x0043A654 File Offset: 0x00438854
	public void GoGambleNormal3()
	{
		UIBattle_Gambling uibattle_Gambling = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
		if (uibattle_Gambling != null)
		{
			Vector2 zero = Vector2.zero;
			this.SetupUI(ref zero, false, 1, 1);
			UIPriestTalk uipriestTalk = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
			if (uipriestTalk != null)
			{
				uipriestTalk.transform.SetParent(uibattle_Gambling.transform.parent);
				uipriestTalk.transform.SetAsLastSibling();
				uipriestTalk.transform.localRotation = Quaternion.identity;
				uipriestTalk.transform.localPosition = Vector3.zero;
				uipriestTalk.transform.localScale = Vector3.one;
			}
			this.Controller.transform.SetParent(uibattle_Gambling.transform.parent, false);
			this.Controller.transform.SetSiblingIndex(1);
			this.Controller.transform.localRotation = Quaternion.identity;
			this.Controller.transform.localScale = Vector3.one;
			Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
			this.Controller.transform.localPosition = new Vector3(sizeDelta.x * -0.5f, sizeDelta.y * -0.5f, 700f);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x0600272A RID: 10026 RVA: 0x0043A7B0 File Offset: 0x004389B0
	public void RecvGoGambleNormal3()
	{
		this.MoveNext(null);
	}

	// Token: 0x0600272B RID: 10027 RVA: 0x0043A7BC File Offset: 0x004389BC
	public void GoGambleNormal4()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x0600272C RID: 10028 RVA: 0x0043A7DC File Offset: 0x004389DC
	public void RecvGoGambleNormal4()
	{
		UIPriestTalk uipriestTalk = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
		if (uipriestTalk != null)
		{
			uipriestTalk.transform.SetParent(GUIManager.Instance.m_WindowsTransform);
		}
		this.MoveNext(null);
	}

	// Token: 0x0600272D RID: 10029 RVA: 0x0043A824 File Offset: 0x00438A24
	public void GoGambleNormal5()
	{
		UIBattle_Gambling uibattle_Gambling = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
		if (uibattle_Gambling != null)
		{
			Vector2 vector = this.UIController.ScreenPointTest((RectTransform)uibattle_Gambling.btn_Hint2.transform);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x0600272E RID: 10030 RVA: 0x0043A888 File Offset: 0x00438A88
	public void RecvGoGambleNormal5()
	{
		UIBattle_Gambling uibattle_Gambling = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
		if (uibattle_Gambling != null)
		{
			uibattle_Gambling.OnButtonClick(uibattle_Gambling.btn_Hint2);
		}
		this.MoveNext(null);
	}

	// Token: 0x0600272F RID: 10031 RVA: 0x0043A8CC File Offset: 0x00438ACC
	public void GoGambleNormal6()
	{
		UIBattle_Gambling uibattle_Gambling = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
		if (uibattle_Gambling != null)
		{
			Vector2 vector = this.UIController.ScreenPointTest((RectTransform)uibattle_Gambling.btn_Item[2].transform);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002730 RID: 10032 RVA: 0x0043A930 File Offset: 0x00438B30
	public void RecvGoGambleNormal6()
	{
		this.MoveNext(null);
	}

	// Token: 0x06002731 RID: 10033 RVA: 0x0043A93C File Offset: 0x00438B3C
	public void GoGambleNormal7()
	{
		UIBattle_Gambling uibattle_Gambling = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
		if (uibattle_Gambling != null)
		{
			Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
			RectTransform rectTransform = uibattle_Gambling.Img_ItemListT.transform as RectTransform;
			Vector2 vector = new Vector2(sizeDelta.x - rectTransform.sizeDelta.x * 0.5f, rectTransform.sizeDelta.y * 0.5f);
			vector = new Vector3(vector.x + 83f, vector.y);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002732 RID: 10034 RVA: 0x0043AA00 File Offset: 0x00438C00
	public void RecvGoGambleNormal7()
	{
		this.MoveNext(null);
	}

	// Token: 0x06002733 RID: 10035 RVA: 0x0043AA0C File Offset: 0x00438C0C
	public void GoGambleNormal8()
	{
		UIBattle_Gambling uibattle_Gambling = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
		if (uibattle_Gambling != null)
		{
			Vector2 zero = Vector2.zero;
			this.SetupUI(ref zero, false, 0, 1);
			UIPriestTalk uipriestTalk = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
			if (uipriestTalk != null)
			{
				uipriestTalk.transform.SetParent(uibattle_Gambling.transform.parent);
				uipriestTalk.transform.SetAsLastSibling();
				uipriestTalk.transform.localRotation = Quaternion.identity;
				uipriestTalk.transform.localPosition = Vector3.zero;
				uipriestTalk.transform.localScale = Vector3.one;
			}
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002734 RID: 10036 RVA: 0x0043AAC8 File Offset: 0x00438CC8
	public void RecvGoGambleNormal8()
	{
		UIPriestTalk uipriestTalk = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
		if (uipriestTalk != null)
		{
			uipriestTalk.transform.SetParent(GUIManager.Instance.m_WindowsTransform);
		}
		this.Controller.transform.SetParent(GUIManager.Instance.m_NewbieLayer);
		this.Controller.transform.localRotation = Quaternion.identity;
		this.Controller.transform.localScale = Vector3.one;
		Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
		this.Controller.transform.localPosition = new Vector3(sizeDelta.x * -0.5f, sizeDelta.y * -0.5f, 0f);
		this.RemoveFlag(ETeachKind.GAMBLING1, 1, false);
		this.LockControl(false);
		NewbieManager.CheckGambleElite();
		NewbieManager.NB_SpawnPetTimeCache = DataManager.Instance.ServerTime;
	}

	// Token: 0x06002735 RID: 10037 RVA: 0x0043ABBC File Offset: 0x00438DBC
	public void GoGambleElite()
	{
		UIBattle_Gambling uibattle_Gambling = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
		if (uibattle_Gambling != null)
		{
			Vector2 zero = Vector2.zero;
			this.SetupUI(ref zero, false, 0, 1);
			UIPriestTalk uipriestTalk = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
			if (uipriestTalk != null)
			{
				uipriestTalk.transform.SetParent(uibattle_Gambling.transform.parent);
				uipriestTalk.transform.SetAsLastSibling();
				uipriestTalk.transform.localRotation = Quaternion.identity;
				uipriestTalk.transform.localPosition = Vector3.zero;
				uipriestTalk.transform.localScale = Vector3.one;
			}
			this.Controller.transform.SetParent(uibattle_Gambling.transform.parent, false);
			this.Controller.transform.SetSiblingIndex(1);
			this.Controller.transform.localRotation = Quaternion.identity;
			this.Controller.transform.localScale = Vector3.one;
			Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
			this.Controller.transform.localPosition = new Vector3(sizeDelta.x * -0.5f, sizeDelta.y * -0.5f, 700f);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002736 RID: 10038 RVA: 0x0043AD18 File Offset: 0x00438F18
	public void RecvGoGambleElite()
	{
		UIPriestTalk uipriestTalk = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
		if (uipriestTalk != null)
		{
			uipriestTalk.transform.SetParent(GUIManager.Instance.m_WindowsTransform);
		}
		this.MoveNext(null);
	}

	// Token: 0x06002737 RID: 10039 RVA: 0x0043AD60 File Offset: 0x00438F60
	public void GoGambleElite2()
	{
		UIBattle_Gambling uibattle_Gambling = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
		if (uibattle_Gambling != null)
		{
			Vector2 vector = this.UIController.ScreenPointTest((RectTransform)uibattle_Gambling.btn_ChangeModel_Turbo.transform);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002738 RID: 10040 RVA: 0x0043ADC4 File Offset: 0x00438FC4
	public void RecvGoGambleElite2()
	{
		UIBattle_Gambling uibattle_Gambling = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
		if (uibattle_Gambling != null)
		{
			uibattle_Gambling.OnButtonClick(uibattle_Gambling.btn_ChangeModel_Turbo);
		}
	}

	// Token: 0x06002739 RID: 10041 RVA: 0x0043AE00 File Offset: 0x00439000
	public void GoGambleElite3()
	{
		UIBattle_Gambling uibattle_Gambling = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
		if (uibattle_Gambling != null)
		{
			Vector2 zero = Vector2.zero;
			this.SetupUI(ref zero, false, 0, 1);
			UIPriestTalk uipriestTalk = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
			if (uipriestTalk != null)
			{
				uipriestTalk.transform.SetParent(uibattle_Gambling.transform.parent);
				uipriestTalk.transform.SetAsLastSibling();
				uipriestTalk.transform.localRotation = Quaternion.identity;
				uipriestTalk.transform.localPosition = Vector3.zero;
				uipriestTalk.transform.localScale = Vector3.one;
			}
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x0600273A RID: 10042 RVA: 0x0043AEBC File Offset: 0x004390BC
	public void RecvGoGambleElite3()
	{
		UIPriestTalk uipriestTalk = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
		if (uipriestTalk != null)
		{
			uipriestTalk.transform.SetParent(GUIManager.Instance.m_WindowsTransform);
		}
		this.Controller.transform.SetParent(GUIManager.Instance.m_NewbieLayer);
		this.Controller.transform.localRotation = Quaternion.identity;
		this.Controller.transform.localScale = Vector3.one;
		Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
		this.Controller.transform.localPosition = new Vector3(sizeDelta.x * -0.5f, sizeDelta.y * -0.5f, 0f);
		this.RemoveFlag(ETeachKind.GAMBLING2, 1, false);
		this.LockControl(false);
	}

	// Token: 0x0600273B RID: 10043 RVA: 0x0043AF9C File Offset: 0x0043919C
	public void GoDareFull()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x0600273C RID: 10044 RVA: 0x0043AFBC File Offset: 0x004391BC
	public void RecvGoDareFull()
	{
		Origin origin = GameManager.ActiveGameplay as Origin;
		if (origin != null)
		{
			origin.WorldController.cameraController.CameraMoveTarget(CameraState.Build, GUIManager.Instance.BuildingData.ManorGride[2].position);
		}
		NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, false);
	}

	// Token: 0x0600273D RID: 10045 RVA: 0x0043B00C File Offset: 0x0043920C
	public void GoDareFull2()
	{
		Transform transform = GUIManager.Instance.BuildingData.ManorGride[2];
		Vector2 vector = Camera.main.WorldToScreenPoint(transform.position);
		float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
		vector /= scaleFactor;
		vector.y += 97f;
		vector = this.CheckMirror(vector);
		this.SetupUI(ref vector, false, 0, 0);
	}

	// Token: 0x0600273E RID: 10046 RVA: 0x0043B080 File Offset: 0x00439280
	public void RecvGoDareFull2()
	{
		Door doorController = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		GUIManager.Instance.BuildingData.OpenUI(100, doorController);
	}

	// Token: 0x0600273F RID: 10047 RVA: 0x0043B0B0 File Offset: 0x004392B0
	public void GoDareFull3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002740 RID: 10048 RVA: 0x0043B0D0 File Offset: 0x004392D0
	public void RecvGoDareFull3()
	{
		NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, false);
	}

	// Token: 0x06002741 RID: 10049 RVA: 0x0043B0DC File Offset: 0x004392DC
	public void GoDareFull4()
	{
		UIStageSelect uistageSelect = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
		if (uistageSelect != null)
		{
			RectTransform rt = uistageSelect.transform.GetChild(3).transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002742 RID: 10050 RVA: 0x0043B138 File Offset: 0x00439338
	public void RecvGoDareFull4()
	{
		UIStageSelect uistageSelect = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
		if (uistageSelect != null)
		{
			UIButton component = uistageSelect.transform.GetChild(3).GetComponent<UIButton>();
			uistageSelect.OnButtonClick(component);
		}
	}

	// Token: 0x06002743 RID: 10051 RVA: 0x0043B17C File Offset: 0x0043937C
	public void GoDareFull5()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.ForceQueueBarOpenClose(false);
		}
		if (NewbieManager.pTrans != null)
		{
			Vector2 vector = Camera.main.WorldToScreenPoint(NewbieManager.pTrans.position);
			float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
			vector /= scaleFactor;
			vector += new Vector2(0f, 34f);
			vector = this.CheckMirror(vector);
			this.SetupUI(ref vector, false, 0, 0);
			NewbieManager.pTrans = null;
		}
	}

	// Token: 0x06002744 RID: 10052 RVA: 0x0043B220 File Offset: 0x00439420
	public void RecvGoDareFull5()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_StageInfo, 0, 0, true);
		}
		NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, false);
	}

	// Token: 0x06002745 RID: 10053 RVA: 0x0043B260 File Offset: 0x00439460
	public void GoDareFull6()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002746 RID: 10054 RVA: 0x0043B280 File Offset: 0x00439480
	public void RecvGoDareFull6()
	{
		NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, false);
	}

	// Token: 0x06002747 RID: 10055 RVA: 0x0043B28C File Offset: 0x0043948C
	public void GoDareFull7()
	{
		UIStageInfo uistageInfo = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
		if (uistageInfo != null)
		{
			RectTransform rt = uistageInfo.transform.GetChild(58).transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			vector.y -= 50f;
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002748 RID: 10056 RVA: 0x0043B2FC File Offset: 0x004394FC
	public void RecvGoDareFull7()
	{
		NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, false);
	}

	// Token: 0x06002749 RID: 10057 RVA: 0x0043B308 File Offset: 0x00439508
	public void GoDareFull8()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x0600274A RID: 10058 RVA: 0x0043B328 File Offset: 0x00439528
	public void RecvGoDareFull8()
	{
		NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, false);
	}

	// Token: 0x0600274B RID: 10059 RVA: 0x0043B334 File Offset: 0x00439534
	public void GoDareFull9()
	{
		UIStageInfo uistageInfo = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
		if (uistageInfo != null)
		{
			RectTransform rt = uistageInfo.transform.GetChild(21).transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600274C RID: 10060 RVA: 0x0043B390 File Offset: 0x00439590
	public void RecvGoDareFull9()
	{
		UIStageInfo uistageInfo = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
		if (uistageInfo != null)
		{
			UIButton component = uistageInfo.transform.GetChild(21).GetComponent<UIButton>();
			uistageInfo.OnButtonClick(component);
			NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, false);
		}
	}

	// Token: 0x0600274D RID: 10061 RVA: 0x0043B3E0 File Offset: 0x004395E0
	public void GoDareFull10()
	{
		UIBattleHeroSelect uibattleHeroSelect = GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) as UIBattleHeroSelect;
		if (uibattleHeroSelect != null)
		{
			RectTransform rt = uibattleHeroSelect.transform.GetChild(25) as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600274E RID: 10062 RVA: 0x0043B438 File Offset: 0x00439638
	public void RecvGoDareFull10()
	{
		UIBattleHeroSelect uibattleHeroSelect = GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) as UIBattleHeroSelect;
		if (uibattleHeroSelect != null)
		{
			UIButton component = uibattleHeroSelect.transform.GetChild(25).GetComponent<UIButton>();
			uibattleHeroSelect.OnButtonClick(component);
		}
		NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, false);
	}

	// Token: 0x0600274F RID: 10063 RVA: 0x0043B488 File Offset: 0x00439688
	public void GoDareFull11()
	{
		UIBattleHeroSelect uibattleHeroSelect = GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) as UIBattleHeroSelect;
		if (uibattleHeroSelect != null)
		{
			RectTransform rt = uibattleHeroSelect.transform.GetChild(26).GetChild(0) as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002750 RID: 10064 RVA: 0x0043B4E4 File Offset: 0x004396E4
	public void RecvGoDareFull11()
	{
		NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, false);
	}

	// Token: 0x06002751 RID: 10065 RVA: 0x0043B4F0 File Offset: 0x004396F0
	public void GoDareFull12()
	{
		UIBattleHeroSelect uibattleHeroSelect = GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) as UIBattleHeroSelect;
		if (uibattleHeroSelect != null)
		{
			RectTransform rt = uibattleHeroSelect.m_HerosView.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002752 RID: 10066 RVA: 0x0043B544 File Offset: 0x00439744
	public void RecvGoDareFull12()
	{
		NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, false);
	}

	// Token: 0x06002753 RID: 10067 RVA: 0x0043B550 File Offset: 0x00439750
	public void GoDareFull13()
	{
		UIBattleHeroSelect uibattleHeroSelect = GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) as UIBattleHeroSelect;
		if (uibattleHeroSelect != null)
		{
			RectTransform rt = uibattleHeroSelect.transform.GetChild(25) as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002754 RID: 10068 RVA: 0x0043B5A8 File Offset: 0x004397A8
	public void RecvGoDareFull13()
	{
		UIBattleHeroSelect uibattleHeroSelect = GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) as UIBattleHeroSelect;
		if (uibattleHeroSelect != null)
		{
			UIButton component = uibattleHeroSelect.transform.GetChild(25).GetComponent<UIButton>();
			uibattleHeroSelect.OnButtonClick(component);
		}
		this.RemoveFlag(ETeachKind.DARE_FULL, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002755 RID: 10069 RVA: 0x0043B600 File Offset: 0x00439800
	public void GoDareLead()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002756 RID: 10070 RVA: 0x0043B620 File Offset: 0x00439820
	public void RecvGoDareLead()
	{
		NewbieManager.CheckTeach(ETeachKind.DARE_LEAD, null, false);
	}

	// Token: 0x06002757 RID: 10071 RVA: 0x0043B62C File Offset: 0x0043982C
	public void GoDareLead2()
	{
		for (int i = 0; i < 6; i++)
		{
			if (!(NewbieManager.HeroIconCache[i] == null))
			{
				Vector2 vector = Camera.main.WorldToScreenPoint(NewbieManager.HeroIconCache[i].transform.position);
				float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
				vector /= scaleFactor;
				vector = this.CheckMirror(vector);
				if (i == 0)
				{
					this.SetupUI(ref vector, false, 0, 0);
				}
				else
				{
					this.Controller.SetOtherHoleVisible(i - 1, true, vector);
				}
			}
		}
	}

	// Token: 0x06002758 RID: 10072 RVA: 0x0043B6CC File Offset: 0x004398CC
	public void RecvGoDareLead2()
	{
		int num = (int)((DataManager.StageDataController.currentChapterID - 1) * 6) + NewbieManager.ClickBtnID + 1;
		num *= (int)GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode];
		DataManager.StageDataController.currentPointID = (ushort)num;
		DataManager.StageDataController.SaveUserStage(DataManager.StageDataController._stageMode);
		DataManager.msgBuffer[0] = 17;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		NewbieManager.CheckTeach(ETeachKind.DARE_LEAD, null, false);
	}

	// Token: 0x06002759 RID: 10073 RVA: 0x0043B744 File Offset: 0x00439944
	public void GoDareLead3()
	{
		UIStageInfo uistageInfo = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
		if (uistageInfo != null)
		{
			RectTransform rt = uistageInfo.transform.GetChild(68).transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			vector.y += 20f;
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600275A RID: 10074 RVA: 0x0043B7B4 File Offset: 0x004399B4
	public void RecvGoDareLead3()
	{
		NewbieManager.CheckTeach(ETeachKind.DARE_LEAD, null, false);
	}

	// Token: 0x0600275B RID: 10075 RVA: 0x0043B7C0 File Offset: 0x004399C0
	public void GoDareLead4()
	{
		UIStageInfo uistageInfo = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
		if (uistageInfo != null)
		{
			RectTransform rt = uistageInfo.transform.GetChild(7).transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			vector.y -= 40f;
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600275C RID: 10076 RVA: 0x0043B82C File Offset: 0x00439A2C
	public void RecvGoDareLead4()
	{
		this.RemoveFlag(ETeachKind.DARE_FULL, 1, false);
		this.LockControl(false);
	}

	// Token: 0x0600275D RID: 10077 RVA: 0x0043B840 File Offset: 0x00439A40
	public void GoSpawnSoliderDetail()
	{
		UIBarrack_Soldier uibarrack_Soldier = GUIManager.Instance.FindMenu(EGUIWindow.UI_Barrack_Soldier) as UIBarrack_Soldier;
		if (uibarrack_Soldier != null)
		{
			RectTransform rt = uibarrack_Soldier.m_UnitRS.BtnInputText.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x0600275E RID: 10078 RVA: 0x0043B8A8 File Offset: 0x00439AA8
	public void RecvGoSpawnSoliderDetail()
	{
		UIBarrack_Soldier uibarrack_Soldier = GUIManager.Instance.FindMenu(EGUIWindow.UI_Barrack_Soldier) as UIBarrack_Soldier;
		if (uibarrack_Soldier != null)
		{
			uibarrack_Soldier.OnButtonClick(uibarrack_Soldier.m_UnitRS.BtnInputText);
		}
		NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIER_DETAIL, null, false);
	}

	// Token: 0x0600275F RID: 10079 RVA: 0x0043B8F0 File Offset: 0x00439AF0
	public void GoSpawnSoliderDetail2()
	{
		if (GUIManager.Instance.Obj_UICalculator != null && GUIManager.Instance.m_UICalculator != null)
		{
			RectTransform calculatorRT = GUIManager.Instance.m_UICalculator.CalculatorRT;
			Vector2 vector = this.UIController.ScreenPointTest(calculatorRT);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002760 RID: 10080 RVA: 0x0043B958 File Offset: 0x00439B58
	public void RecvGoSpawnSoliderDetail2()
	{
		this.RemoveFlag(ETeachKind.SPAWN_SOLDIER_DETAIL, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002761 RID: 10081 RVA: 0x0043B96C File Offset: 0x00439B6C
	public void GoTreasBoxUpgrade()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002762 RID: 10082 RVA: 0x0043B98C File Offset: 0x00439B8C
	public void RecvGoTreasBoxUpgrade()
	{
		NewbieManager.CheckTeach(ETeachKind.TREASBOX_UPGRADE, null, false);
	}

	// Token: 0x06002763 RID: 10083 RVA: 0x0043B998 File Offset: 0x00439B98
	public void GoTreasBoxUpgrade2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			RectTransform rt = door.m_MallGO.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x06002764 RID: 10084 RVA: 0x0043B9EC File Offset: 0x00439BEC
	public void RecvGoTreasBoxUpgrade2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OnButtonClick(door.m_MallGO.GetComponent<UIButton>());
		}
	}

	// Token: 0x06002765 RID: 10085 RVA: 0x0043BA28 File Offset: 0x00439C28
	public void GoTreasBoxUpgrade3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002766 RID: 10086 RVA: 0x0043BA48 File Offset: 0x00439C48
	public void RecvGoTreasBoxUpgrade3()
	{
		this.RemoveFlag(ETeachKind.TREASBOX_UPGRADE, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002767 RID: 10087 RVA: 0x0043BA5C File Offset: 0x00439C5C
	public void GoSpawnPet()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002768 RID: 10088 RVA: 0x0043BA7C File Offset: 0x00439C7C
	public void RecvGoSpawnPet()
	{
		GUIManager.Instance.BuildingData.PetListGuide();
		NewbieManager.CheckTeach(ETeachKind.SPAWN_PET, null, false);
	}

	// Token: 0x06002769 RID: 10089 RVA: 0x0043BA98 File Offset: 0x00439C98
	public void GoSpawnPet2()
	{
		Transform transform = GUIManager.Instance.BuildingData.ManorGride[9];
		Vector2 vector = Camera.main.WorldToScreenPoint(transform.position);
		float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
		vector /= scaleFactor;
		vector += new Vector2(-2f, 60f);
		vector = this.CheckMirror(vector);
		this.SetupUI(ref vector, false, 0, 0);
	}

	// Token: 0x0600276A RID: 10090 RVA: 0x0043BB10 File Offset: 0x00439D10
	public void RecvGoSpawnPet2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_PetList, 49, 20, false);
			NewbieManager.CheckTeach(ETeachKind.SPAWN_PET, null, false);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x0600276B RID: 10091 RVA: 0x0043BB64 File Offset: 0x00439D64
	public void GoSpawnPet3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x0600276C RID: 10092 RVA: 0x0043BB84 File Offset: 0x00439D84
	public void RecvGoSpawnPet3()
	{
		NewbieManager.CheckTeach(ETeachKind.SPAWN_PET, null, false);
	}

	// Token: 0x0600276D RID: 10093 RVA: 0x0043BB90 File Offset: 0x00439D90
	public void GoSpawnPet4()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x0600276E RID: 10094 RVA: 0x0043BBB0 File Offset: 0x00439DB0
	public void RecvGoSpawnPet4()
	{
		NewbieManager.CheckTeach(ETeachKind.SPAWN_PET, null, false);
	}

	// Token: 0x0600276F RID: 10095 RVA: 0x0043BBBC File Offset: 0x00439DBC
	public void GoSpawnPet5()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002770 RID: 10096 RVA: 0x0043BBDC File Offset: 0x00439DDC
	public void RecvGoSpawnPet5()
	{
		this.RemoveFlag(ETeachKind.SPAWN_PET, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002771 RID: 10097 RVA: 0x0043BBF0 File Offset: 0x00439DF0
	private void GoPetInfo()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x06002772 RID: 10098 RVA: 0x0043BC10 File Offset: 0x00439E10
	private void RecvGoPetInfo()
	{
		this.MoveNext(null);
	}

	// Token: 0x06002773 RID: 10099 RVA: 0x0043BC1C File Offset: 0x00439E1C
	private void GoPetInfo2()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002774 RID: 10100 RVA: 0x0043BC3C File Offset: 0x00439E3C
	private void RecvGoPetInfo2()
	{
		this.RemoveFlag(ETeachKind.PET_INFO, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002775 RID: 10101 RVA: 0x0043BC50 File Offset: 0x00439E50
	private void GoPetFusion()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x06002776 RID: 10102 RVA: 0x0043BC70 File Offset: 0x00439E70
	private void RecvGoPetFusion()
	{
		this.MoveNext(null);
	}

	// Token: 0x06002777 RID: 10103 RVA: 0x0043BC7C File Offset: 0x00439E7C
	private void GoPetFusion2()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002778 RID: 10104 RVA: 0x0043BC9C File Offset: 0x00439E9C
	private void RecvGoPetFusion2()
	{
		this.RemoveFlag(ETeachKind.PET_FUSION, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002779 RID: 10105 RVA: 0x0043BCB0 File Offset: 0x00439EB0
	private void GoPetTraining()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x0600277A RID: 10106 RVA: 0x0043BCD0 File Offset: 0x00439ED0
	private void RecvGoPetTraining()
	{
		this.MoveNext(null);
	}

	// Token: 0x0600277B RID: 10107 RVA: 0x0043BCDC File Offset: 0x00439EDC
	private void GoPetTraining2()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x0600277C RID: 10108 RVA: 0x0043BCFC File Offset: 0x00439EFC
	private void RecvGoPetTraining2()
	{
		this.RemoveFlag(ETeachKind.PET_TRAINING, 1, false);
		this.LockControl(false);
	}

	// Token: 0x0600277D RID: 10109 RVA: 0x0043BD10 File Offset: 0x00439F10
	private void GoPetSkill()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x0600277E RID: 10110 RVA: 0x0043BD30 File Offset: 0x00439F30
	private void RecvGoPetSkill()
	{
		this.MoveNext(null);
	}

	// Token: 0x0600277F RID: 10111 RVA: 0x0043BD3C File Offset: 0x00439F3C
	private void GoPetSkill2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			RectTransform rt = door.m_PetSkillBtnGO.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002780 RID: 10112 RVA: 0x0043BD9C File Offset: 0x00439F9C
	private void RecvGoPetSkill2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_PetBuff, 0, 0, false);
			this.MoveNext(null);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x06002781 RID: 10113 RVA: 0x0043BDEC File Offset: 0x00439FEC
	private void GoPetSkill3()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x06002782 RID: 10114 RVA: 0x0043BE0C File Offset: 0x0043A00C
	private void RecvGoPetSkill3()
	{
		this.MoveNext(null);
	}

	// Token: 0x06002783 RID: 10115 RVA: 0x0043BE18 File Offset: 0x0043A018
	private void GoPetSkill4()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002784 RID: 10116 RVA: 0x0043BE38 File Offset: 0x0043A038
	private void RecvGoPetSkill4()
	{
		this.RemoveFlag(ETeachKind.PET_SKILL, 1, false);
		this.LockControl(false);
	}

	// Token: 0x06002785 RID: 10117 RVA: 0x0043BE4C File Offset: 0x0043A04C
	private void GoSocialInvite()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 1, 0);
	}

	// Token: 0x06002786 RID: 10118 RVA: 0x0043BE6C File Offset: 0x0043A06C
	private void RecvGoSocialInvite()
	{
		this.MoveNext(null);
	}

	// Token: 0x06002787 RID: 10119 RVA: 0x0043BE78 File Offset: 0x0043A078
	private void GoSocialInvite2()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002788 RID: 10120 RVA: 0x0043BE98 File Offset: 0x0043A098
	private void RecvGoSocialInvite2()
	{
		this.MoveNext(null);
	}

	// Token: 0x06002789 RID: 10121 RVA: 0x0043BEA4 File Offset: 0x0043A0A4
	private void GoSocialInvite3()
	{
		UIFBWindow uifbwindow = GUIManager.Instance.FindMenu(EGUIWindow.UI_MissionFB) as UIFBWindow;
		if (uifbwindow != null)
		{
			RectTransform rt = uifbwindow.btnInvite.transform as RectTransform;
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
		else
		{
			this.IgnoreStep(true, -1);
		}
	}

	// Token: 0x0600278A RID: 10122 RVA: 0x0043BF08 File Offset: 0x0043A108
	private void RecvGoSocialInvite3()
	{
		this.RemoveFlag(ETeachKind.SOCIAL_INVITE, 1, false);
		this.LockControl(false);
	}

	// Token: 0x0600278B RID: 10123 RVA: 0x0043BF1C File Offset: 0x0043A11C
	private void GoSocialInviteII()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x0600278C RID: 10124 RVA: 0x0043BF3C File Offset: 0x0043A13C
	private void RecvGoSocialInviteII()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_bShowFuncButton != 1)
		{
			door.ShowFuncButton(true);
		}
		this.MoveNext(null);
	}

	// Token: 0x0600278D RID: 10125 RVA: 0x0043BF80 File Offset: 0x0043A180
	private void GoSocialInviteII2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			RectTransform rt = door.m_FuncRC[2];
			Vector2 vector = this.UIController.ScreenPointTest(rt);
			this.SetupUI(ref vector, false, 0, 0);
		}
	}

	// Token: 0x0600278E RID: 10126 RVA: 0x0043BFCC File Offset: 0x0043A1CC
	private void RecvGoSocialInviteII2()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OnButtonClick(door.m_FuncRC[2].GetChild(0).GetComponent<UIButton>());
		}
		this.MoveNext(null);
	}

	// Token: 0x0600278F RID: 10127 RVA: 0x0043C018 File Offset: 0x0043A218
	private void GoSocialInviteII3()
	{
		UIOther uiother = GUIManager.Instance.FindMenu(EGUIWindow.UI_Other) as UIOther;
		if (uiother != null)
		{
			for (int i = 0; i < 15; i++)
			{
				if (uiother.btnItem[i] != null && uiother.btnItem[i].m_BtnID1 == 1 && uiother.btnItem[i].m_BtnID2 == 13)
				{
					RectTransform rt = uiother.btnItem[i].transform as RectTransform;
					Vector2 vector = this.UIController.ScreenPointTest(rt);
					this.SetupUI(ref vector, false, 0, 0);
					return;
				}
			}
		}
		this.IgnoreStep(true, -1);
	}

	// Token: 0x06002790 RID: 10128 RVA: 0x0043C0C4 File Offset: 0x0043A2C4
	private void RecvGoSocialInviteII3()
	{
		UIOther uiother = GUIManager.Instance.FindMenu(EGUIWindow.UI_Other) as UIOther;
		if (uiother != null)
		{
			uiother.OnClickBtn(13);
		}
		this.MoveNext(null);
	}

	// Token: 0x06002791 RID: 10129 RVA: 0x0043C100 File Offset: 0x0043A300
	private void GoSocialInviteII4()
	{
		Vector2 zero = Vector2.zero;
		this.SetupUI(ref zero, false, 0, 0);
	}

	// Token: 0x06002792 RID: 10130 RVA: 0x0043C120 File Offset: 0x0043A320
	private void RecvGoSocialInviteII4()
	{
		this.RemoveFlag(ETeachKind.SOCIAL_INVITE_AFTER_MISSION, 1, false);
		this.LockControl(false);
		NewbieManager.CheckSocialInvite();
	}

	// Token: 0x040070D7 RID: 28887
	public const uint WAR_STOP_POINT = 140u;

	// Token: 0x040070D8 RID: 28888
	public const uint BATTLE_STOP_POINT = 150u;

	// Token: 0x040070D9 RID: 28889
	public const ushort RENAME_ITEMID = 1006;

	// Token: 0x040070DA RID: 28890
	public const ushort NON_RENAME_STRID = 8055;

	// Token: 0x040070DB RID: 28891
	public const ushort PUTON_ITEMID = 1;

	// Token: 0x040070DC RID: 28892
	public const int MAX_TEACH_COUNT = 38;

	// Token: 0x040070DD RID: 28893
	public const ulong DEFAULT_TEACH = 274877906943UL;

	// Token: 0x040070DE RID: 28894
	public const long WORLD_TEACH_INTERVAL = 300L;

	// Token: 0x040070DF RID: 28895
	private DataManager DM;

	// Token: 0x040070E0 RID: 28896
	private static readonly string NEWBIE_SAVE_NAME = "Newbie{0}";

	// Token: 0x040070E1 RID: 28897
	private int Step;

	// Token: 0x040070E2 RID: 28898
	public int SubStep;

	// Token: 0x040070E3 RID: 28899
	private string SaveName = string.Empty;

	// Token: 0x040070E4 RID: 28900
	private int TeachStep;

	// Token: 0x040070E5 RID: 28901
	private NewbieController Controller;

	// Token: 0x040070E6 RID: 28902
	private NewbieManager.ActiveStep pAction;

	// Token: 0x040070E7 RID: 28903
	private Dictionary<int, NewbieManager.NewbieNode> ActionMap = new Dictionary<int, NewbieManager.NewbieNode>();

	// Token: 0x040070E8 RID: 28904
	private object Target;

	// Token: 0x040070E9 RID: 28905
	private bool bRunAction;

	// Token: 0x040070EA RID: 28906
	private float ActionDelay;

	// Token: 0x040070EB RID: 28907
	public EGUIWindow NextUI = EGUIWindow.MAX;

	// Token: 0x040070EC RID: 28908
	public int NextUIArg1;

	// Token: 0x040070ED RID: 28909
	public int UIOperator;

	// Token: 0x040070EE RID: 28910
	public object NextUIObj;

	// Token: 0x040070EF RID: 28911
	private Dictionary<int, NewbieManager.ActiveStep> ClickActionMap = new Dictionary<int, NewbieManager.ActiveStep>();

	// Token: 0x040070F0 RID: 28912
	public ulong TeachFlag;

	// Token: 0x040070F1 RID: 28913
	public int WorkingKey;

	// Token: 0x040070F2 RID: 28914
	private GameObject NewbieRoot;

	// Token: 0x040070F3 RID: 28915
	private bool bFlagDirty;

	// Token: 0x040070F4 RID: 28916
	private bool bFlagDirty2;

	// Token: 0x040070F5 RID: 28917
	private bool bFlagDirty3;

	// Token: 0x040070F6 RID: 28918
	private bool bFlagDirty_Blackmarket;

	// Token: 0x040070F7 RID: 28919
	private bool bFlagDirty_TroopMemory;

	// Token: 0x040070F8 RID: 28920
	private bool bFlagDirty_DeShield;

	// Token: 0x040070F9 RID: 28921
	private bool bFlagDirty_Coord;

	// Token: 0x040070FA RID: 28922
	private bool bFlagDirty_Metallurgy;

	// Token: 0x040070FB RID: 28923
	private bool bFlagDirty_Gamble2;

	// Token: 0x040070FC RID: 28924
	private bool bFlagDirty_DareFull;

	// Token: 0x040070FD RID: 28925
	private bool bFlagDirty_DareLead;

	// Token: 0x040070FE RID: 28926
	private bool bFlagDirty_SpawnSoldierDetail;

	// Token: 0x040070FF RID: 28927
	private bool bFlagDirty_TreasBoxUpgrade;

	// Token: 0x04007100 RID: 28928
	private bool bFlagDirty_SpawnPet;

	// Token: 0x04007101 RID: 28929
	private byte SendGuideExFlag;

	// Token: 0x04007102 RID: 28930
	public long UserID;

	// Token: 0x04007103 RID: 28931
	private bool bIsNewUser = true;

	// Token: 0x04007104 RID: 28932
	private ushort CurFakeData;

	// Token: 0x04007105 RID: 28933
	private byte FakeBuildLvStep;

	// Token: 0x04007106 RID: 28934
	private byte FakeMarkStep;

	// Token: 0x04007107 RID: 28935
	private byte FakeBuildStep;

	// Token: 0x04007108 RID: 28936
	public static bool bShowRenameMessage = false;

	// Token: 0x04007109 RID: 28937
	public static bool bQueuePopMenu = false;

	// Token: 0x0400710A RID: 28938
	public bool bOutsideHole;

	// Token: 0x0400710B RID: 28939
	public bool bTargeting;

	// Token: 0x0400710C RID: 28940
	public bool bUltraWorking;

	// Token: 0x0400710D RID: 28941
	public float UltraTimeCache;

	// Token: 0x0400710E RID: 28942
	public Vector2 PosCache = Vector2.zero;

	// Token: 0x0400710F RID: 28943
	public static Transform pTrans = null;

	// Token: 0x04007110 RID: 28944
	public uint[] sortHeroDataCache = new uint[DataManager.Instance.MaxCurHeroData];

	// Token: 0x04007111 RID: 28945
	public long WorldTeach_Point;

	// Token: 0x04007112 RID: 28946
	protected static NewbieManager m_Self = null;

	// Token: 0x04007113 RID: 28947
	public static long UserIdCache = 0L;

	// Token: 0x04007114 RID: 28948
	private bool bTimeBarOpen = true;

	// Token: 0x04007115 RID: 28949
	public static bool EntryLock = false;

	// Token: 0x04007116 RID: 28950
	public static bool AutoBattleFlag = false;

	// Token: 0x04007117 RID: 28951
	public static GameObject[] HeroIconCache = new GameObject[6];

	// Token: 0x04007118 RID: 28952
	public static int ClickBtnID = 0;

	// Token: 0x04007119 RID: 28953
	public static bool BuildCastleImmediate = false;

	// Token: 0x0400711A RID: 28954
	public static long NB_SpawnPetTimeCache = 0L;

	// Token: 0x0400711B RID: 28955
	public static bool bIgnoreGameplayCheck = false;

	// Token: 0x0200078E RID: 1934
	public class NewbieNode
	{
		// Token: 0x06002793 RID: 10131 RVA: 0x0043C13C File Offset: 0x0043A33C
		public NewbieNode(float delay, NewbieManager.ActiveStep step)
		{
			this.DelayTime = delay;
			this.StepFunc = step;
		}

		// Token: 0x0400711C RID: 28956
		public float DelayTime;

		// Token: 0x0400711D RID: 28957
		public NewbieManager.ActiveStep StepFunc;
	}

	// Token: 0x02000897 RID: 2199
	// (Invoke) Token: 0x06002DA4 RID: 11684
	public delegate void ActiveStep();
}
