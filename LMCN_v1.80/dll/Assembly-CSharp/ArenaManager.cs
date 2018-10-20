using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000334 RID: 820
public class ArenaManager
{
	// Token: 0x06001097 RID: 4247 RVA: 0x001D7540 File Offset: 0x001D5740
	private ArenaManager()
	{
	}

	// Token: 0x17000080 RID: 128
	// (get) Token: 0x06001098 RID: 4248 RVA: 0x001D7608 File Offset: 0x001D5808
	public static ArenaManager Instance
	{
		get
		{
			if (ArenaManager.instance == null)
			{
				ArenaManager.instance = new ArenaManager();
			}
			return ArenaManager.instance;
		}
	}

	// Token: 0x06001099 RID: 4249 RVA: 0x001D7624 File Offset: 0x001D5824
	public void RecvArena_Info(MessagePacket MP)
	{
		this.m_ArenaPlace = MP.ReadUInt(-1);
		Array.Clear(this.m_ArenaDefHero, 0, this.m_ArenaDefHero.Length);
		Array.Clear(this.m_ArenaTarget, 0, this.m_ArenaTarget.Length);
		for (int i = 0; i < 5; i++)
		{
			this.m_ArenaDefHero[i] = MP.ReadUShort(-1);
		}
		this.m_ArenaTodayChallenge = MP.ReadByte(-1);
		this.m_ArenaTodayResetChallenge = MP.ReadByte(-1);
		this.m_ArenaLastChallengeTime = MP.ReadLong(-1);
		this.m_ArenaCrystalPrize = MP.ReadUInt(-1);
		for (int j = 0; j < 3; j++)
		{
			this.m_ArenaTarget[j].Head = MP.ReadUShort(-1);
			this.m_ArenaTarget[j].Name = MP.ReadString(13, -1);
			this.m_ArenaTarget[j].AllianceTagTag = MP.ReadString(3, -1);
			this.m_ArenaTarget[j].Place = MP.ReadUInt(-1);
			if (this.m_ArenaTarget[j].HeroData == null)
			{
				this.m_ArenaTarget[j].HeroData = new ArenaTargetHeroDataType[5];
			}
			for (int k = 0; k < 5; k++)
			{
				this.m_ArenaTarget[j].HeroData[k].ID = MP.ReadUShort(-1);
				this.m_ArenaTarget[j].HeroData[k].Level = MP.ReadByte(-1);
				this.m_ArenaTarget[j].HeroData[k].Rank = MP.ReadByte(-1);
				this.m_ArenaTarget[j].HeroData[k].Star = MP.ReadByte(-1);
				this.m_ArenaTarget[j].HeroData[k].Equip = MP.ReadByte(-1);
			}
		}
		this.m_ArenaNewReportNum = MP.ReadByte(-1);
		this.m_NowArenaTopicID[0] = MP.ReadByte(-1);
		this.m_NowArenaTopicID[1] = MP.ReadByte(-1);
		this.m_NowArenaTopicEndTime = MP.ReadLong(-1);
		this.m_NowTopicEffect[0].Effect = MP.ReadUShort(-1);
		this.m_NowTopicEffect[0].Value = MP.ReadUShort(-1);
		this.m_NowTopicEffect[1].Effect = MP.ReadUShort(-1);
		this.m_NowTopicEffect[1].Value = MP.ReadUShort(-1);
		this.m_NextArenaTopicID[0] = MP.ReadByte(-1);
		this.m_NextArenaTopicID[1] = MP.ReadByte(-1);
		this.m_NextArenaTopicBeginTime = MP.ReadLong(-1);
		this.m_NextTopicEffect[0].Effect = MP.ReadUShort(-1);
		this.m_NextTopicEffect[0].Value = MP.ReadUShort(-1);
		this.m_NextTopicEffect[1].Effect = MP.ReadUShort(-1);
		this.m_NextTopicEffect[1].Value = MP.ReadUShort(-1);
		this.m_ArenaHistoryPlace = MP.ReadUInt(-1);
		this.m_ArenaExtraChallenge = MP.ReadByte(-1);
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 6, 0);
		DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 28, this.GetHeroAstrologyNum());
		if (this.m_ArenaHistoryPlace > 0u && this.m_ArenaHistoryPlace < 65535u)
		{
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 29, (ushort)(65535u - this.m_ArenaHistoryPlace));
		}
	}

	// Token: 0x0600109A RID: 4250 RVA: 0x001D79CC File Offset: 0x001D5BCC
	public ushort GetHeroAstrologyNum()
	{
		ushort num = 0;
		for (int i = 0; i < 5; i++)
		{
			if (this.m_ArenaDefHero[i] != 0)
			{
				if (this.CheckHeroAstrology(this.m_ArenaDefHero[i]))
				{
					num += 1;
				}
			}
		}
		return num;
	}

	// Token: 0x0600109B RID: 4251 RVA: 0x001D7A18 File Offset: 0x001D5C18
	public void RecvArena_Report(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		GUIManager.Instance.HideUILock(EUILock.Arena);
		byte b2 = MP.ReadByte(-1);
		ArenaReportDataType arenaReportDataType = default(ArenaReportDataType);
		int index = 0;
		int num = 0;
		while (num < (int)b2 && num < 10)
		{
			if (!this.bArenaOpenGet)
			{
				if (b == 0 || b == 2)
				{
					index = (int)this.RepoetUnRead[num + 10];
				}
				else if (b == 3 || b == 1)
				{
					index = (int)this.RepoetUnRead[num];
				}
				arenaReportDataType = this.m_ArenaReportData[index];
			}
			arenaReportDataType.MyHeroData = new ArenaHeroDataType[5];
			arenaReportDataType.EnemyHeroData = new ArenaHeroDataType[5];
			arenaReportDataType.TopicID = new byte[2];
			arenaReportDataType.TopicEffect = new ArenaTopicEffectDataType[2];
			arenaReportDataType.SimulatorVersion = MP.ReadUInt(-1);
			arenaReportDataType.SimulatorPatchNo = MP.ReadUInt(-1);
			arenaReportDataType.Flag = MP.ReadByte(-1);
			arenaReportDataType.TopicID[0] = MP.ReadByte(-1);
			arenaReportDataType.TopicID[1] = MP.ReadByte(-1);
			arenaReportDataType.TopicEffect[0].Effect = MP.ReadUShort(-1);
			arenaReportDataType.TopicEffect[0].Value = MP.ReadUShort(-1);
			arenaReportDataType.TopicEffect[1].Effect = MP.ReadUShort(-1);
			arenaReportDataType.TopicEffect[1].Value = MP.ReadUShort(-1);
			arenaReportDataType.ChangePlace = MP.ReadUInt(-1);
			for (int i = 0; i < 5; i++)
			{
				arenaReportDataType.MyHeroData[i].SkillLV = new byte[4];
				arenaReportDataType.MyHeroData[i].ID = MP.ReadUShort(-1);
				arenaReportDataType.MyHeroData[i].Level = MP.ReadByte(-1);
				arenaReportDataType.MyHeroData[i].Rank = MP.ReadByte(-1);
				arenaReportDataType.MyHeroData[i].Star = MP.ReadByte(-1);
				arenaReportDataType.MyHeroData[i].Equip = MP.ReadByte(-1);
				for (int j = 0; j < 4; j++)
				{
					arenaReportDataType.MyHeroData[i].SkillLV[j] = MP.ReadByte(-1);
				}
			}
			arenaReportDataType.EnemyHead = MP.ReadUShort(-1);
			arenaReportDataType.EnemyName = MP.ReadString(13, -1);
			arenaReportDataType.EnemyAllianceTag = MP.ReadString(3, -1);
			for (int k = 0; k < 5; k++)
			{
				arenaReportDataType.EnemyHeroData[k].SkillLV = new byte[4];
				arenaReportDataType.EnemyHeroData[k].ID = MP.ReadUShort(-1);
				arenaReportDataType.EnemyHeroData[k].Level = MP.ReadByte(-1);
				arenaReportDataType.EnemyHeroData[k].Rank = MP.ReadByte(-1);
				arenaReportDataType.EnemyHeroData[k].Star = MP.ReadByte(-1);
				arenaReportDataType.EnemyHeroData[k].Equip = MP.ReadByte(-1);
				for (int l = 0; l < 4; l++)
				{
					arenaReportDataType.EnemyHeroData[k].SkillLV[l] = MP.ReadByte(-1);
				}
			}
			arenaReportDataType.RandomSeed = MP.ReadUShort(-1);
			arenaReportDataType.RandomGap = MP.ReadByte(-1);
			arenaReportDataType.PrimarySide = MP.ReadByte(-1);
			arenaReportDataType.Time = MP.ReadLong(-1);
			if (!this.bArenaOpenGet)
			{
				this.m_ArenaReportData[index] = arenaReportDataType;
			}
			else
			{
				if (this.m_ArenaReportData.Count == 20)
				{
					this.m_ArenaReportData.RemoveAt(0);
				}
				this.m_ArenaReportData.Add(arenaReportDataType);
			}
			num++;
		}
		if (b == 2 || b == 3)
		{
			if (this.bArenaOpenGet)
			{
				this.bArenaOpenGet = false;
			}
			this.m_ArenaNewReportNum = 0;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena_Replay, 1, 0);
			GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
		}
	}

	// Token: 0x0600109C RID: 4252 RVA: 0x001D7E68 File Offset: 0x001D6068
	public void RecvArena_Refresh_Target(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Arena);
		byte b = MP.ReadByte(-1);
		if (MP.ReadByte(-1) == 0)
		{
			for (int i = 0; i < 3; i++)
			{
				this.m_ArenaTarget[i].Head = MP.ReadUShort(-1);
				this.m_ArenaTarget[i].Name = MP.ReadString(13, -1);
				this.m_ArenaTarget[i].AllianceTagTag = MP.ReadString(3, -1);
				this.m_ArenaTarget[i].Place = MP.ReadUInt(-1);
				for (int j = 0; j < 5; j++)
				{
					this.m_ArenaTarget[i].HeroData[j].ID = MP.ReadUShort(-1);
					this.m_ArenaTarget[i].HeroData[j].Level = MP.ReadByte(-1);
					this.m_ArenaTarget[i].HeroData[j].Rank = MP.ReadByte(-1);
					this.m_ArenaTarget[i].HeroData[j].Star = MP.ReadByte(-1);
					this.m_ArenaTarget[i].HeroData[j].Equip = MP.ReadByte(-1);
				}
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 4, 0);
			if (b == 4)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 7, 0);
				if (GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject.activeSelf)
				{
					for (int k = 0; k < 3; k++)
					{
						if (this.m_ArenaTargetHint.Name == this.m_ArenaTarget[k].Name)
						{
							this.m_ArenaTargetHint = this.m_ArenaTarget[k];
							break;
						}
					}
					GUIManager.Instance.m_Arena_Hint.UpdateUI();
				}
			}
		}
	}

	// Token: 0x0600109D RID: 4253 RVA: 0x001D8078 File Offset: 0x001D6278
	public void RecvArena_Set_DefHero(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Arena);
		if (MP.ReadByte(-1) == 0)
		{
			for (int i = 0; i < 5; i++)
			{
				this.m_ArenaDefHero[i] = MP.ReadUShort(-1);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 7, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 5, 0);
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 28, this.GetHeroAstrologyNum());
		}
	}

	// Token: 0x0600109E RID: 4254 RVA: 0x001D80F0 File Offset: 0x001D62F0
	public void RecvArena_Challenge(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Arena);
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			this.BattleResult = MP.ReadByte(-1);
			this.m_ArenaPlace = MP.ReadUInt(-1);
			this.m_ArenaTodayChallenge = MP.ReadByte(-1);
			this.m_ArenaLastChallengeTime = MP.ReadLong(-1);
			DataManager dataManager = DataManager.Instance;
			dataManager.KingOldLv = dataManager.RoleAttr.Level;
			dataManager.KingOldExp = dataManager.RoleAttr.Exp;
			DataManager.StageDataController.UpdateRoleAttrLevel(MP.ReadByte(-1));
			DataManager.StageDataController.UpdateRoleAttrExp(MP.ReadUInt(-1));
			MP.ReadUInt(-1);
			for (int i = 0; i < 5; i++)
			{
				ushort num = MP.ReadUShort(-1);
				if (num != 0 && dataManager.curHeroData.ContainsKey((uint)num))
				{
					CurHeroData curHeroData = dataManager.curHeroData[(uint)num];
					dataManager.heroLv[i] = curHeroData.Level;
					dataManager.heroExp[i] = curHeroData.Exp;
					dataManager.UpdateHeroAttr(num, MP);
				}
				else
				{
					MP.ReadByte(-1);
					MP.ReadUInt(-1);
					MP.ReadUInt(-1);
				}
			}
			ArenaReportDataType arenaReportDataType = default(ArenaReportDataType);
			arenaReportDataType.MyHeroData = new ArenaHeroDataType[5];
			arenaReportDataType.EnemyHeroData = new ArenaHeroDataType[5];
			arenaReportDataType.TopicID = new byte[2];
			arenaReportDataType.TopicEffect = new ArenaTopicEffectDataType[2];
			arenaReportDataType.SimulatorVersion = MP.ReadUInt(-1);
			arenaReportDataType.SimulatorPatchNo = MP.ReadUInt(-1);
			arenaReportDataType.Flag = MP.ReadByte(-1);
			arenaReportDataType.TopicID[0] = MP.ReadByte(-1);
			arenaReportDataType.TopicID[1] = MP.ReadByte(-1);
			arenaReportDataType.TopicEffect[0].Effect = MP.ReadUShort(-1);
			arenaReportDataType.TopicEffect[0].Value = MP.ReadUShort(-1);
			arenaReportDataType.TopicEffect[1].Effect = MP.ReadUShort(-1);
			arenaReportDataType.TopicEffect[1].Value = MP.ReadUShort(-1);
			arenaReportDataType.ChangePlace = MP.ReadUInt(-1);
			for (int j = 0; j < 5; j++)
			{
				arenaReportDataType.MyHeroData[j].SkillLV = new byte[4];
				arenaReportDataType.MyHeroData[j].ID = MP.ReadUShort(-1);
				arenaReportDataType.MyHeroData[j].Level = MP.ReadByte(-1);
				arenaReportDataType.MyHeroData[j].Rank = MP.ReadByte(-1);
				arenaReportDataType.MyHeroData[j].Star = MP.ReadByte(-1);
				arenaReportDataType.MyHeroData[j].Equip = MP.ReadByte(-1);
				for (int k = 0; k < 4; k++)
				{
					arenaReportDataType.MyHeroData[j].SkillLV[k] = MP.ReadByte(-1);
				}
			}
			arenaReportDataType.EnemyHead = MP.ReadUShort(-1);
			arenaReportDataType.EnemyName = MP.ReadString(13, -1);
			arenaReportDataType.EnemyAllianceTag = MP.ReadString(3, -1);
			for (int l = 0; l < 5; l++)
			{
				arenaReportDataType.EnemyHeroData[l].SkillLV = new byte[4];
				arenaReportDataType.EnemyHeroData[l].ID = MP.ReadUShort(-1);
				arenaReportDataType.EnemyHeroData[l].Level = MP.ReadByte(-1);
				arenaReportDataType.EnemyHeroData[l].Rank = MP.ReadByte(-1);
				arenaReportDataType.EnemyHeroData[l].Star = MP.ReadByte(-1);
				arenaReportDataType.EnemyHeroData[l].Equip = MP.ReadByte(-1);
				for (int m = 0; m < 4; m++)
				{
					arenaReportDataType.EnemyHeroData[l].SkillLV[m] = MP.ReadByte(-1);
				}
			}
			arenaReportDataType.RandomSeed = MP.ReadUShort(-1);
			arenaReportDataType.RandomGap = MP.ReadByte(-1);
			arenaReportDataType.PrimarySide = MP.ReadByte(-1);
			arenaReportDataType.Time = MP.ReadLong(-1);
			if (!this.bArenaOpenGet)
			{
				if (this.m_ArenaReportData.Count == 20)
				{
					this.m_ArenaReportData.RemoveAt(0);
				}
				bool flag = false;
				if (this.RepoetUnReadCount > 0 && this.RepoetUnRead[0] == 0)
				{
					flag = true;
					this.RepoetUnReadCount -= 1;
				}
				if (flag)
				{
					int num2 = 0;
					while (num2 < (int)this.RepoetUnReadCount && this.RepoetUnReadCount < 19)
					{
						byte[] repoetUnRead = this.RepoetUnRead;
						int num3 = num2;
						byte[] repoetUnRead2 = this.RepoetUnRead;
						int num4 = num2 + 1;
						repoetUnRead[num3] = (repoetUnRead2[num4] -= 1);
						num2++;
					}
				}
				else
				{
					int num5 = 0;
					while (num5 < (int)this.RepoetUnReadCount && num5 < this.RepoetUnRead.Length)
					{
						byte[] repoetUnRead3 = this.RepoetUnRead;
						int num6 = num5;
						byte[] repoetUnRead4 = this.RepoetUnRead;
						int num7 = num5;
						repoetUnRead3[num6] = (repoetUnRead4[num7] -= 1);
						num5++;
					}
				}
				this.m_ArenaReportData.Add(arenaReportDataType);
			}
			this.m_ArenaHistoryPlace = MP.ReadUInt(-1);
			GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 2, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_TreasureBox, 5, 0);
			if (this.m_ArenaHistoryPlace > 0u && this.m_ArenaHistoryPlace < 65535u)
			{
				DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 29, (ushort)(65535u - this.m_ArenaHistoryPlace));
			}
			if ((arenaReportDataType.Flag & 2) != 0 && GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) != null)
			{
				if (WarManager.CheckVersion(arenaReportDataType.SimulatorVersion, arenaReportDataType.SimulatorPatchNo, true))
				{
					this.ArenaPlayingData = arenaReportDataType;
					BattleController.BattleMode = EBattleMode.PVP;
					GUIManager.Instance.bClearWindowStack = false;
					if (GUIManager.Instance.m_WindowStack.Count > 0)
					{
						GUIManager.Instance.m_WindowStack.RemoveAt(GUIManager.Instance.m_WindowStack.Count - 1);
					}
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 0, 0);
					DataManager.Instance.SetArenaHeroBattleDataSave();
				}
				else
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 6, 0);
				}
			}
			FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_COLOSSEUM_BATTLE);
		}
		else
		{
			if (b == 6)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9157u), 255, true);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 6, 0);
		}
	}

	// Token: 0x0600109F RID: 4255 RVA: 0x001D87C8 File Offset: 0x001D69C8
	public void RecvArena_ReSet_Todaychallenge(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Arena);
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			this.m_ArenaTodayChallenge = 0;
			this.m_ArenaTodayResetChallenge = MP.ReadByte(-1);
			GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eMax);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 1, 0);
			GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
		}
		else if (b == 1)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9163u), 255, true);
		}
	}

	// Token: 0x060010A0 RID: 4256 RVA: 0x001D886C File Offset: 0x001D6A6C
	public void RecvArena_ReSet_Challenge_CD(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Arena);
		if (MP.ReadByte(-1) == 0)
		{
			this.m_ArenaLastChallengeTime = MP.ReadLong(-1);
			GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eMax);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 2, 0);
			GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
		}
	}

	// Token: 0x060010A1 RID: 4257 RVA: 0x001D88D8 File Offset: 0x001D6AD8
	public void RecvArena_Arena_GetPrize(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Arena);
		if (MP.ReadByte(-1) == 0)
		{
			this.m_ArenaCrystalPrize = 0u;
			uint num = MP.ReadUInt(-1);
			GUIManager.Instance.m_SpeciallyEffect.mDiamondValue = num - DataManager.Instance.RoleAttr.Diamond;
			GUIManager.Instance.SetRoleAttrDiamond(num, 0, eSpentCredits.eMax);
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_TreasureBox);
			GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
			GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, SpeciallyEffect_Kind.Diamond, 0, 0, true, 2f);
			GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 9, 0);
			AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
		}
	}

	// Token: 0x060010A2 RID: 4258 RVA: 0x001D8A08 File Offset: 0x001D6C08
	public void RecvArena_Update_Topic(MessagePacket MP)
	{
		this.m_NowArenaTopicID[0] = MP.ReadByte(-1);
		this.m_NowArenaTopicID[1] = MP.ReadByte(-1);
		this.m_NowArenaTopicEndTime = MP.ReadLong(-1);
		this.m_NowTopicEffect[0].Effect = MP.ReadUShort(-1);
		this.m_NowTopicEffect[0].Value = MP.ReadUShort(-1);
		this.m_NowTopicEffect[1].Effect = MP.ReadUShort(-1);
		this.m_NowTopicEffect[1].Value = MP.ReadUShort(-1);
		this.m_NextArenaTopicID[0] = MP.ReadByte(-1);
		this.m_NextArenaTopicID[1] = MP.ReadByte(-1);
		this.m_NextArenaTopicBeginTime = MP.ReadLong(-1);
		this.m_NextTopicEffect[0].Effect = MP.ReadUShort(-1);
		this.m_NextTopicEffect[0].Value = MP.ReadUShort(-1);
		this.m_NextTopicEffect[1].Effect = MP.ReadUShort(-1);
		this.m_NextTopicEffect[1].Value = MP.ReadUShort(-1);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 10, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena_Info, 1, 0);
		DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 28, this.GetHeroAstrologyNum());
	}

	// Token: 0x060010A3 RID: 4259 RVA: 0x001D8B5C File Offset: 0x001D6D5C
	public void RecvArena_Update_Single_target(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		b = (byte)Mathf.Clamp((int)b, 0, this.m_ArenaTarget.Length - 1);
		this.m_ArenaTarget[(int)b].Head = MP.ReadUShort(-1);
		this.m_ArenaTarget[(int)b].Name = MP.ReadString(13, -1);
		this.m_ArenaTarget[(int)b].AllianceTagTag = MP.ReadString(3, -1);
		this.m_ArenaTarget[(int)b].Place = MP.ReadUInt(-1);
		for (int i = 0; i < 5; i++)
		{
			this.m_ArenaTarget[(int)b].HeroData[i].ID = MP.ReadUShort(-1);
			this.m_ArenaTarget[(int)b].HeroData[i].Level = MP.ReadByte(-1);
			this.m_ArenaTarget[(int)b].HeroData[i].Rank = MP.ReadByte(-1);
			this.m_ArenaTarget[(int)b].HeroData[i].Star = MP.ReadByte(-1);
			this.m_ArenaTarget[(int)b].HeroData[i].Equip = MP.ReadByte(-1);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 8, (int)b);
	}

	// Token: 0x060010A4 RID: 4260 RVA: 0x001D8CB8 File Offset: 0x001D6EB8
	public void SendArena_Report()
	{
		GUIManager.Instance.ShowUILock(EUILock.Arena);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_REPORT;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x060010A5 RID: 4261 RVA: 0x001D8CF8 File Offset: 0x001D6EF8
	public void SendArena_Refresh_Target(byte Kind)
	{
		if (Kind == 1)
		{
			GUIManager.Instance.ShowUILock(EUILock.Arena);
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_REFRESH_TARGET;
		messagePacket.AddSeqId();
		messagePacket.Add(Kind);
		messagePacket.Send(false);
	}

	// Token: 0x060010A6 RID: 4262 RVA: 0x001D8D44 File Offset: 0x001D6F44
	public void SendArena_Set_DefHero(ushort[] mHero)
	{
		GUIManager.Instance.ShowUILock(EUILock.Arena);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_SET_DEFHERO;
		messagePacket.AddSeqId();
		for (int i = 0; i < 5; i++)
		{
			messagePacket.Add(mHero[i]);
		}
		messagePacket.Send(false);
	}

	// Token: 0x060010A7 RID: 4263 RVA: 0x001D8DA0 File Offset: 0x001D6FA0
	public void SendArena_Challenge(byte TargetIdx)
	{
		GUIManager.Instance.ShowUILock(EUILock.Arena);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_CHALLENGE;
		messagePacket.AddSeqId();
		messagePacket.Add(TargetIdx);
		messagePacket.Add(this.m_ArenaTarget[(int)TargetIdx].Place);
		messagePacket.Add(this.m_ArenaTarget[(int)TargetIdx].Name, 13);
		for (int i = 0; i < 5; i++)
		{
			messagePacket.Add(this.m_ArenaTargetHero[i]);
		}
		messagePacket.Send(false);
	}

	// Token: 0x060010A8 RID: 4264 RVA: 0x001D8E38 File Offset: 0x001D7038
	public void SendArena_ReSet_TodayChallenge()
	{
		GUIManager.Instance.ShowUILock(EUILock.Arena);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_RESET_TODAYCHALLENGE;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x060010A9 RID: 4265 RVA: 0x001D8E78 File Offset: 0x001D7078
	public void SendArena_ReSet_Challenge_CD()
	{
		GUIManager.Instance.ShowUILock(EUILock.Arena);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_RESET_CHALLENGE_CD;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x060010AA RID: 4266 RVA: 0x001D8EB8 File Offset: 0x001D70B8
	public void SendArena_Arena_GetPrize()
	{
		GUIManager.Instance.ShowUILock(EUILock.Arena);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_GET_PRIZE;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x060010AB RID: 4267 RVA: 0x001D8EF8 File Offset: 0x001D70F8
	public bool CheckHeroAstrology(ushort HeroID)
	{
		bool flag = false;
		ArenaHeroTopic recordByKey = DataManager.Instance.ArenaHeroTopicData.GetRecordByKey(HeroID);
		if (this.m_NowArenaTopicID[0] != 0 && (recordByKey.Value >> (int)(this.m_NowArenaTopicID[0] - 1) & 1u) == 1u)
		{
			flag = true;
		}
		if (!flag && this.m_NowArenaTopicID[1] != 0 && (recordByKey.Value >> (int)(this.m_NowArenaTopicID[1] - 1) & 1u) == 1u)
		{
			flag = true;
		}
		return flag;
	}

	// Token: 0x060010AC RID: 4268 RVA: 0x001D8F78 File Offset: 0x001D7178
	public bool CheckHeroAstrology(ushort HeroID, ushort Topic)
	{
		bool result = false;
		ArenaHeroTopic recordByKey = DataManager.Instance.ArenaHeroTopicData.GetRecordByKey(HeroID);
		if (Topic != 0 && (recordByKey.Value >> (int)(Topic - 1) & 1u) == 1u)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x060010AD RID: 4269 RVA: 0x001D8FB8 File Offset: 0x001D71B8
	public void GetHeroAstrology(CString Str1, CString Str2)
	{
		DataManager dataManager = DataManager.Instance;
		if (this.m_NowArenaTopicID[0] != 0)
		{
			Str1.Append(dataManager.mStringTable.GetStringByID(9200u + (uint)this.m_NowArenaTopicID[0]));
		}
		if (this.m_NowArenaTopicID[1] != 0)
		{
			Str2.Append(dataManager.mStringTable.GetStringByID(9200u + (uint)this.m_NowArenaTopicID[1]));
		}
	}

	// Token: 0x060010AE RID: 4270 RVA: 0x001D9024 File Offset: 0x001D7224
	public ushort GetNowCrystal()
	{
		ushort result = 0;
		for (int i = DataManager.Instance.ArenaRewardData.TableCount; i > 0; i--)
		{
			ArenaReward recordByIndex = DataManager.Instance.ArenaRewardData.GetRecordByIndex(i - 1);
			if (this.m_ArenaPlace >= (uint)recordByIndex.Value1 && this.m_ArenaPlace <= (uint)recordByIndex.Value2)
			{
				result = recordByIndex.Crystal;
				break;
			}
		}
		return result;
	}

	// Token: 0x060010AF RID: 4271 RVA: 0x001D9098 File Offset: 0x001D7298
	public uint GetAllPower(byte Kind, int TargetIdx = 0)
	{
		uint num = 0u;
		ArenaTargetDataType arenaTargetDataType = default(ArenaTargetDataType);
		if (Kind == 0)
		{
			arenaTargetDataType = this.m_ArenaTargetHint;
		}
		else
		{
			arenaTargetDataType = this.m_ArenaTarget[TargetIdx];
		}
		for (int i = 0; i < 5; i++)
		{
			if (arenaTargetDataType.HeroData != null)
			{
				num += this.GetPower(arenaTargetDataType.HeroData[i]);
			}
		}
		return num;
	}

	// Token: 0x060010B0 RID: 4272 RVA: 0x001D9110 File Offset: 0x001D7310
	public uint GetPower(ArenaTargetHeroDataType HeroData)
	{
		uint result = 0u;
		if (HeroData.ID == 0)
		{
			return result;
		}
		CalcAttrDataType calcAttrDataType = default(CalcAttrDataType);
		byte[] array = new byte[4];
		uint num = 0u;
		ushort[] array2 = new ushort[28];
		ushort[] array3 = new ushort[28];
		uint hp = 0u;
		calcAttrDataType.SkillLV1 = HeroData.Level;
		if (HeroData.Rank >= 2)
		{
			calcAttrDataType.SkillLV2 = HeroData.Level;
		}
		if (HeroData.Rank >= 4)
		{
			calcAttrDataType.SkillLV3 = HeroData.Level - 20;
		}
		if (HeroData.Rank >= 7)
		{
			calcAttrDataType.SkillLV4 = HeroData.Level - 40;
		}
		array[0] = HeroData.Level;
		if (HeroData.Rank >= 2)
		{
			array[1] = HeroData.Level;
		}
		if (HeroData.Rank >= 4)
		{
			array[2] = HeroData.Level - 20;
		}
		if (HeroData.Rank >= 7)
		{
			array[3] = HeroData.Level - 40;
		}
		calcAttrDataType.LV = HeroData.Level;
		calcAttrDataType.Star = HeroData.Star;
		calcAttrDataType.Enhance = HeroData.Rank;
		calcAttrDataType.Equip = HeroData.Equip;
		num = 0u;
		Array.Clear(array2, 0, array2.Length);
		BSInvokeUtil.getInstance.setCalculateHeroEquipEffect(HeroData.ID, calcAttrDataType.Enhance, calcAttrDataType.Equip, ref num, array2);
		Array.Clear(array3, 0, array3.Length);
		BSInvokeUtil.getInstance.setCalculateAttribute(HeroData.ID, ref calcAttrDataType, ref hp, array3);
		return BSInvokeUtil.getInstance.updateFightScore(HeroData.ID, hp, array3, array);
	}

	// Token: 0x060010B1 RID: 4273 RVA: 0x001D92B8 File Offset: 0x001D74B8
	public ushort CheckArenaClose()
	{
		ushort result = 0;
		if (this.bArenaKVK)
		{
			result = 9109;
		}
		else if (this.m_ArenaClose_CDTime != 0L)
		{
			EActivityType arenaClose_ActivityType = this.m_ArenaClose_ActivityType;
			if (arenaClose_ActivityType != EActivityType.EAT_KingOfTheWorld)
			{
				if (arenaClose_ActivityType == EActivityType.EAT_FederalEvent)
				{
					result = 11107;
				}
			}
			else
			{
				result = 10018;
			}
		}
		return result;
	}

	// Token: 0x060010B2 RID: 4274 RVA: 0x001D931C File Offset: 0x001D751C
	~ArenaManager()
	{
	}

	// Token: 0x060010B3 RID: 4275 RVA: 0x001D9354 File Offset: 0x001D7554
	public bool SetReportIDToPlayingData(int id)
	{
		if (this.m_ArenaReportData.Count > id)
		{
			id = this.m_ArenaReportData.Count - 1 - id;
			this.ArenaPlayingData = this.m_ArenaReportData[id];
			return true;
		}
		return false;
	}

	// Token: 0x060010B4 RID: 4276 RVA: 0x001D9390 File Offset: 0x001D7590
	public void SendArena_UIClear()
	{
		DataManager dataManager = DataManager.Instance;
		dataManager.RoleAttr.PrizeFlag = dataManager.RoleAttr.PrizeFlag - 1048576u;
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_UICLEAR;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x04003652 RID: 13906
	private static ArenaManager instance;

	// Token: 0x04003653 RID: 13907
	public List<ArenaReportDataType> m_ArenaReportData = new List<ArenaReportDataType>(20);

	// Token: 0x04003654 RID: 13908
	public byte[] RepoetUnRead = new byte[20];

	// Token: 0x04003655 RID: 13909
	public byte RepoetUnReadCount;

	// Token: 0x04003656 RID: 13910
	public byte BattleResult;

	// Token: 0x04003657 RID: 13911
	public uint m_ArenaPlace;

	// Token: 0x04003658 RID: 13912
	public ushort[] m_ArenaDefHero = new ushort[5];

	// Token: 0x04003659 RID: 13913
	public byte m_ArenaTodayChallenge;

	// Token: 0x0400365A RID: 13914
	public byte m_ArenaTodayResetChallenge;

	// Token: 0x0400365B RID: 13915
	public long m_ArenaLastChallengeTime;

	// Token: 0x0400365C RID: 13916
	public uint m_ArenaCrystalPrize;

	// Token: 0x0400365D RID: 13917
	public ArenaTargetDataType[] m_ArenaTarget = new ArenaTargetDataType[3];

	// Token: 0x0400365E RID: 13918
	public byte m_ArenaNewReportNum;

	// Token: 0x0400365F RID: 13919
	public byte[] m_NowArenaTopicID = new byte[2];

	// Token: 0x04003660 RID: 13920
	public long m_NowArenaTopicEndTime;

	// Token: 0x04003661 RID: 13921
	public ArenaTopicEffectDataType[] m_NowTopicEffect = new ArenaTopicEffectDataType[2];

	// Token: 0x04003662 RID: 13922
	public byte[] m_NextArenaTopicID = new byte[2];

	// Token: 0x04003663 RID: 13923
	public long m_NextArenaTopicBeginTime;

	// Token: 0x04003664 RID: 13924
	public ArenaTopicEffectDataType[] m_NextTopicEffect = new ArenaTopicEffectDataType[2];

	// Token: 0x04003665 RID: 13925
	public uint m_ArenaHistoryPlace;

	// Token: 0x04003666 RID: 13926
	public ushort[] m_TodayChallengeCost = new ushort[]
	{
		250,
		400,
		700,
		1200,
		1900,
		2800,
		3900,
		5200,
		6700,
		8400,
		10300,
		12500
	};

	// Token: 0x04003667 RID: 13927
	public bool bArenaOpenGet = true;

	// Token: 0x04003668 RID: 13928
	public bool bArenaKVK;

	// Token: 0x04003669 RID: 13929
	public byte m_ArenaTargetIdx;

	// Token: 0x0400366A RID: 13930
	public ushort[] m_ArenaTargetHero = new ushort[5];

	// Token: 0x0400366B RID: 13931
	public ArenaTargetDataType m_ArenaTargetHint = default(ArenaTargetDataType);

	// Token: 0x0400366C RID: 13932
	public ArenaReportDataType ArenaPlayingData = default(ArenaReportDataType);

	// Token: 0x0400366D RID: 13933
	public long m_ArenaClose_CDTime;

	// Token: 0x0400366E RID: 13934
	public EActivityType m_ArenaClose_ActivityType = EActivityType.EAT_MAX;

	// Token: 0x0400366F RID: 13935
	public float m_ArenaPlacedropTime;

	// Token: 0x04003670 RID: 13936
	public bool bShowArenaPlacedrop;

	// Token: 0x04003671 RID: 13937
	public byte m_ArenaExtraChallenge;
}
