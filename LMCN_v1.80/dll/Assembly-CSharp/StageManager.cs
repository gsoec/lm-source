using System;
using UnityEngine;

// Token: 0x020004B9 RID: 1209
public class StageManager
{
	// Token: 0x06001848 RID: 6216 RVA: 0x0028D0E8 File Offset: 0x0028B2E8
	public StageManager()
	{
		this.StageInit();
	}

	// Token: 0x06001849 RID: 6217 RVA: 0x0028D110 File Offset: 0x0028B310
	public void Init()
	{
		this.StageInit();
	}

	// Token: 0x0600184A RID: 6218 RVA: 0x0028D118 File Offset: 0x0028B318
	public void loginFinish()
	{
		if (this.inoutStageMode == StageMode.Count || this.inoutStageMode >= StageMode.Count)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.uLongToFormat((ulong)DataManager.Instance.RoleAttr.UserId, 1, false);
			cstring.AppendFormat("{0}_currentStageMode");
			this.inoutStageMode = (StageMode)PlayerPrefs.GetInt(cstring.ToString());
			if (this.inoutStageMode == StageMode.Corps || this.inoutStageMode >= StageMode.Count)
			{
				this.inoutStageMode = StageMode.Full;
			}
			this.GetUserStage(StageMode.Full);
			this.GetUserStage(StageMode.Lean);
			this.GetUserStage(StageMode.Dare);
			this.resetStageMode(this.inoutStageMode);
		}
	}

	// Token: 0x0600184B RID: 6219 RVA: 0x0028D1C4 File Offset: 0x0028B3C4
	public void LoadTableData()
	{
		this.LevelTable = new CExternalTableWithWordKey<Level>[3];
		this.LevelEXTable = new CExternalTableWithWordKey<LevelEX>[3];
		this.ChapterTable = new CExternalTableWithWordKey<Chapter>();
		this.LevelTable[0] = new CExternalTableWithWordKey<Level>();
		this.LevelTable[1] = new CExternalTableWithWordKey<Level>();
		this.LevelTable[2] = new CExternalTableWithWordKey<Level>();
		this.StageTable = new CExternalTableWithWordKey<Stage>();
		this.CorpsStageTable = new CExternalTableWithWordKey<CorpsStage>();
		this.CorpsStageBattleTable = new CExternalTableWithWordKey<CorpsStageBattle>();
		this.StageConditionDataTable = new CExternalTableWithWordKey<StageConditionData>();
		this.LevelEXTable[0] = new CExternalTableWithWordKey<LevelEX>();
		this.LevelEXTable[1] = new CExternalTableWithWordKey<LevelEX>();
		this.LevelEXTable[2] = new CExternalTableWithWordKey<LevelEX>();
		this.StageConditionInfoTable = new CExternalTableWithWordKey<StageConditionInfo>();
		this.ChapterTable.LoadTable("Chapter");
		this.LevelTable[0].LoadTable("NormalMiniStage");
		this.LevelTable[1].LoadTable("NormalStage");
		this.LevelTable[2].LoadTable("AdvanceStage");
		this.LevelEXTable[0].LoadTable("EX_NormalMiniStage");
		this.LevelEXTable[1].LoadTable("EX_NormalStage");
		this.LevelEXTable[2].LoadTable("EX_AdvanceStage");
		this.StageTable.LoadTable("Stage");
		this.CorpsStageTable.LoadTable("CorpsPVEface");
		this.CorpsStageBattleTable.LoadTable("CorpsPVEbattle");
		this.StageConditionDataTable.LoadTable("HeroChallengeLevel");
		this.StageConditionInfoTable.LoadTable("HeroChallengeEffect");
		this.limitRecord[2] = (ushort)this.CorpsStageTable.TableCount;
	}

	// Token: 0x0600184C RID: 6220 RVA: 0x0028D368 File Offset: 0x0028B568
	public void StageInit()
	{
		this.mStageTroopsCount = (this.mStageTrapsCount = 0);
		this.mStageTroopsAmount = (this.mStageTrapsAmount = (this.CorpsStagetotalStrength = 0u));
		if (this.NowCombatStageInfo == null)
		{
			this.NowCombatStageInfo = new CombatStageSoldierDataType[10];
			Array.Clear(this.NowCombatStageInfo, 0, this.NowCombatStageInfo.Length);
		}
		if (this.StageRecord == null)
		{
			this.StageRecord = new ushort[4];
			Array.Clear(this.StageRecord, 0, this.StageRecord.Length);
		}
		if (this.inoutPointID == null)
		{
			this.inoutPointID = new ushort[4];
			Array.Clear(this.inoutPointID, 0, this.inoutPointID.Length);
		}
		if (this.StageInfo == null)
		{
			this.StageInfo = new byte[4][];
		}
		if (this.StageInfo[0] == null)
		{
			this.StageInfo[0] = new byte[(int)GameConstants.StageInfoSize[0]];
			Array.Clear(this.StageInfo[0], 0, this.StageInfo[0].Length);
		}
		if (this.StageInfo[1] == null)
		{
			this.StageInfo[1] = new byte[(int)GameConstants.StageInfoSize[1]];
			Array.Clear(this.StageInfo[1], 0, this.StageInfo[1].Length);
		}
		this.StageInfo[2] = null;
		if (this.StageInfo[3] == null)
		{
			this.StageInfo[3] = new byte[(int)GameConstants.StageInfoSize[3]];
			Array.Clear(this.StageInfo[3], 0, this.StageInfo[3].Length);
		}
		if (this.isNotFirstInLine == null)
		{
			this.isNotFirstInLine = new byte[4];
			Array.Clear(this.isNotFirstInLine, 0, this.isNotFirstInLine.Length);
		}
		if (this.isNotFirstInChapter == null)
		{
			this.isNotFirstInChapter = new byte[4];
			Array.Clear(this.isNotFirstInChapter, 0, this.isNotFirstInChapter.Length);
		}
		if (this.limitRecord == null)
		{
			this.limitRecord = new ushort[4];
			this.limitRecord[0] = 18;
			this.limitRecord[1] = 6;
			this.limitRecord[2] = 1;
			this.limitRecord[3] = 18;
		}
		this.resetStageMode(StageMode.Full);
		this.savePointID = 0;
		this.saveStageMode = StageMode.Count;
	}

	// Token: 0x170000AF RID: 175
	// (get) Token: 0x0600184D RID: 6221 RVA: 0x0028D594 File Offset: 0x0028B794
	public byte ChapterID
	{
		get
		{
			byte stageMode = (byte)this._stageMode;
			ushort num = this.StageRecord[(int)stageMode];
			if (num >= this.limitRecord[(int)stageMode])
			{
				num = ((this.limitRecord[(int)stageMode] != 0) ? (this.limitRecord[(int)stageMode] - 1) : 0);
			}
			num /= GameConstants.StagePointNum[(int)stageMode];
			return (byte)(num + 1);
		}
	}

	// Token: 0x0600184E RID: 6222 RVA: 0x0028D5F0 File Offset: 0x0028B7F0
	public bool reflashStageRecordInfo(StageMode in_stageMode, ushort in_StageRecord)
	{
		ushort num = this.StageRecord[(int)in_stageMode];
		this.StageRecord[(int)in_stageMode] = in_StageRecord;
		this.UpdateStagelimitRecord();
		if (in_stageMode == StageMode.Full || in_stageMode == StageMode.Lean || in_stageMode == StageMode.Corps)
		{
			DataManager.MissionDataManager.CheckChanged((eMissionKind)((byte)(3 + in_stageMode)), 1, this.StageRecord[(int)in_stageMode]);
		}
		else
		{
			DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeStage, 1, this.StageRecord[(int)in_stageMode]);
		}
		if (num != 0 && in_StageRecord > num)
		{
			DataManager.msgBuffer[0] = 4;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			return true;
		}
		return false;
	}

	// Token: 0x0600184F RID: 6223 RVA: 0x0028D680 File Offset: 0x0028B880
	public void UpdateStageRecord(StageMode in_stageMode, ushort in_StageRecord)
	{
		this._stageMode = in_stageMode;
		if (DataManager.Instance.lastBattleResult > 0 && this.currentChapterID == this.ChapterID && this.currentPointID == this.StageRecord[(int)this._stageMode] + 1)
		{
			if (this.StageRecord[(int)this._stageMode] % GameConstants.LinePointNum[(int)this._stageMode] == GameConstants.LinePointNum[(int)this._stageMode] - 1)
			{
				this.isNotFirstInLine[(int)this._stageMode] = 0;
				if (this._stageMode == StageMode.Full && this.StageRecord[0] % GameConstants.StagePointNum[0] == 17)
				{
					Chapter recordByKey = this.ChapterTable.GetRecordByKey((ushort)this.currentChapterID);
					ushort itemID = recordByKey.Hero_ItemID;
					ushort num = (ushort)recordByKey.Hero_ItemNum;
					ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(itemID, 0);
					if (curItemQuantity < 65535)
					{
						DataManager.Instance.SetCurItemQuantity(itemID, curItemQuantity + num, 0, 0L);
					}
					for (int i = 0; i < 5; i++)
					{
						if (recordByKey.Items[i].ItemID != 0)
						{
							itemID = recordByKey.Items[i].ItemID;
							num = (ushort)recordByKey.Items[i].ItemNum;
							curItemQuantity = DataManager.Instance.GetCurItemQuantity(itemID, 0);
							if (curItemQuantity < 65535)
							{
								DataManager.Instance.SetCurItemQuantity(itemID, curItemQuantity + num, 0, 0L);
							}
						}
					}
				}
			}
			this.currentPointID += 1;
			if (this.currentPointID > this.limitRecord[(int)this._stageMode])
			{
				this.currentPointID = this.limitRecord[(int)this._stageMode];
			}
			this.SaveUserStage(this._stageMode);
		}
		if (in_StageRecord == 3 && in_stageMode == StageMode.Full && this.StageRecord[(int)in_stageMode] == 2)
		{
			AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.HEROSTAGE1_3_COMPLETION);
		}
		if (in_StageRecord > this.StageRecord[(int)in_stageMode] && in_stageMode == StageMode.Full)
		{
			FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.FIRST_UNLOCK_NORMAL_CHAPTER, 0L, 0UL);
		}
		this.StageRecord[(int)this._stageMode] = in_StageRecord;
		this.UpdateStagelimitRecord();
	}

	// Token: 0x06001850 RID: 6224 RVA: 0x0028D8A0 File Offset: 0x0028BAA0
	public void UpdateStagelimitRecord()
	{
		this.limitRecord[0] = this.StageRecord[2] * GameConstants.StagePointNum[0];
		this.limitRecord[1] = this.limitRecord[0] / GameConstants.StagePointNum[0] * GameConstants.StagePointNum[1];
		ushort num = (ushort)(this.LevelEXTable[0].TableCount + this.LevelEXTable[1].TableCount);
		this.limitRecord[3] = this.StageRecord[1] / GameConstants.StagePointNum[1] * GameConstants.StagePointNum[3];
		if (num < this.limitRecord[3])
		{
			this.limitRecord[3] = num;
		}
	}

	// Token: 0x06001851 RID: 6225 RVA: 0x0028D93C File Offset: 0x0028BB3C
	public void CheckFirstInChapter()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.uLongToFormat((ulong)DataManager.Instance.RoleAttr.UserId, 1, false);
		cstring.AppendFormat("{0}_isNotFirstInChapter");
		int @int = PlayerPrefs.GetInt(cstring.ToString());
		byte b = 0;
		while ((int)b < this.isNotFirstInChapter.Length)
		{
			this.isNotFirstInChapter[(int)b] = (byte)(@int >> (int)b & 1);
			if (b != 2)
			{
				if (this.isNotFirstInChapter[(int)b] == 0 && (this.StageRecord[(int)b] % GameConstants.StagePointNum[(int)b] != 0 || (this.limitRecord[(int)b] != 0 && this.StageRecord[(int)b] == this.limitRecord[(int)b])))
				{
					this.isNotFirstInChapter[(int)b] = 1;
				}
				if (this.isNotFirstInChapter[(int)b] == 0)
				{
					this.isNotFirstInLine[(int)b] = 0;
				}
				else if (this.StageRecord[(int)b] % GameConstants.LinePointNum[(int)b] != 0)
				{
					this.isNotFirstInLine[(int)b] = 1;
				}
			}
			b += 1;
		}
	}

	// Token: 0x06001852 RID: 6226 RVA: 0x0028DA44 File Offset: 0x0028BC44
	private void InicurrentPointID()
	{
		byte stageMode = (byte)this._stageMode;
		this.currentPointID = ((this.StageRecord[(int)stageMode] >= this.limitRecord[(int)stageMode]) ? this.limitRecord[(int)stageMode] : (this.StageRecord[(int)stageMode] + 1));
	}

	// Token: 0x06001853 RID: 6227 RVA: 0x0028DA8C File Offset: 0x0028BC8C
	public void resetCurrentPointIDwithStageRecord()
	{
		byte stageMode = (byte)this._stageMode;
		this.currentPointID = ((this.StageRecord[(int)stageMode] >= this.limitRecord[(int)stageMode]) ? this.limitRecord[(int)stageMode] : (this.StageRecord[(int)stageMode] + 1));
		this.inoutPointID[(int)stageMode] = this.currentPointID;
	}

	// Token: 0x06001854 RID: 6228 RVA: 0x0028DAE4 File Offset: 0x0028BCE4
	public void SaveCurrentChapter()
	{
		this.saveStageMode = this._stageMode;
		this.savePointID = this.currentPointID;
	}

	// Token: 0x06001855 RID: 6229 RVA: 0x0028DB00 File Offset: 0x0028BD00
	public void ReBackCurrentChapter()
	{
		if (this.saveStageMode != StageMode.Count)
		{
			this._stageMode = this.saveStageMode;
			this.currentPointID = this.savePointID;
			this.currentChapterID = (byte)((this.currentPointID - 1) / GameConstants.StagePointNum[(int)this._stageMode]);
			this.currentChapterID += 1;
			DataManager.Instance.lastBattleResult = -1;
			this.saveStageMode = StageMode.Count;
		}
	}

	// Token: 0x06001856 RID: 6230 RVA: 0x0028DB70 File Offset: 0x0028BD70
	public void UpdateRoleAttrLevel(byte newLevel)
	{
		if (newLevel > 60)
		{
			newLevel = 60;
		}
		if (DataManager.Instance.RoleAttr.Level != newLevel)
		{
			GUIManager.Instance.PreLeadLevel = (int)DataManager.Instance.RoleAttr.Level;
			DataManager.Instance.RoleAttr.Level = newLevel;
			GUIManager.Instance.CheckLvUp(false);
		}
		AFAdvanceManager.Instance.CheckCharacterLvEvent(DataManager.Instance.RoleAttr.Level);
	}

	// Token: 0x06001857 RID: 6231 RVA: 0x0028DBEC File Offset: 0x0028BDEC
	public LevelTableKind GetcurrentPointLevelID(out ushort LevelID, ushort pointid = 0)
	{
		ushort num = LevelID = ((pointid != 0) ? pointid : this.currentPointID);
		LevelTableKind result = LevelTableKind.NormalMiniStage;
		if (LevelID != 0)
		{
			if (this._stageMode == StageMode.Dare)
			{
				if (this.StageDareMode(this.currentChapterID) == StageMode.Lean)
				{
					result = LevelTableKind.AdvanceStage;
					LevelID -= 1;
					LevelID /= GameConstants.LinePointNum[(int)this._stageMode];
					LevelID += 1;
				}
				else
				{
					LevelID -= 1;
					LevelID /= GameConstants.LinePointNum[(int)this._stageMode];
					ushort num2 = num % GameConstants.LinePointNum[(int)this._stageMode];
					if (num2 == 0)
					{
						result = LevelTableKind.NormalStage;
						LevelID += 1;
					}
					else
					{
						LevelID = (ushort)(LevelID << 1);
						LevelID += num2;
					}
				}
			}
			else if (this._stageMode == StageMode.Lean)
			{
				result = LevelTableKind.AdvanceStage;
			}
			else if (this._stageMode == StageMode.Full)
			{
				LevelID -= 1;
				LevelID /= GameConstants.LinePointNum[(int)this._stageMode];
				ushort num3 = num % GameConstants.LinePointNum[(int)this._stageMode];
				if (num3 == 0)
				{
					result = LevelTableKind.NormalStage;
					LevelID += 1;
				}
				else
				{
					LevelID = (ushort)(LevelID << 1);
					LevelID += num3;
				}
			}
		}
		return result;
	}

	// Token: 0x06001858 RID: 6232 RVA: 0x0028DD1C File Offset: 0x0028BF1C
	public Level GetLevelBycurrentPointID(ushort pointid = 0)
	{
		ushort inKey = 0;
		LevelTableKind levelTableKind = this.GetcurrentPointLevelID(out inKey, pointid);
		return this.LevelTable[(int)levelTableKind].GetRecordByKey(inKey);
	}

	// Token: 0x06001859 RID: 6233 RVA: 0x0028DD44 File Offset: 0x0028BF44
	public LevelEX GetLevelEXBycurrentPointID(ushort pointid = 0)
	{
		ushort inKey = 0;
		LevelTableKind levelTableKind = this.GetcurrentPointLevelID(out inKey, pointid);
		return this.LevelEXTable[(int)levelTableKind].GetRecordByKey(inKey);
	}

	// Token: 0x0600185A RID: 6234 RVA: 0x0028DD6C File Offset: 0x0028BF6C
	public int GetStagePoint(ushort PointID = 0, byte SetStageMode = 0)
	{
		int num = -1;
		if (PointID == 0)
		{
			PointID = this.currentPointID;
		}
		StageMode stageMode = (SetStageMode != 1) ? ((SetStageMode != 2) ? ((SetStageMode != 3) ? this._stageMode : StageMode.Dare) : StageMode.Lean) : StageMode.Full;
		if (stageMode == StageMode.Full)
		{
			if (PointID % 3 != 0 || PointID < 1)
			{
				return num;
			}
			PointID /= 3;
			int num2 = (int)(PointID -= 1) << 1;
			int num3 = num2 >> 3;
			if (num3 < this.StageInfo[0].Length)
			{
				num = (this.StageInfo[0][num3] >> (num2 & 7) & 3);
			}
		}
		else if (stageMode == StageMode.Lean)
		{
			if ((int)((byte)(PointID - 1)) < this.StageInfo[1].Length)
			{
				num = (int)(this.StageInfo[1][(int)(PointID - 1)] & 3);
			}
		}
		else if (stageMode == StageMode.Dare)
		{
			if (this.StageDareMode(PointID) != StageMode.Lean || PointID % 3 != 0 || PointID < 1)
			{
				return num;
			}
			PointID -= 1;
			int num4 = (int)(PointID & 7);
			int num5 = PointID >> 3;
			if (num5 < this.StageInfo[3].Length)
			{
				if (num4 < 2)
				{
					if (num5 > 0)
					{
						if (num4 == 0)
						{
							num = ((int)(this.StageInfo[3][num5] & 1) << 2 | this.StageInfo[3][num5 - 1] >> 6);
						}
						else
						{
							num = ((int)(this.StageInfo[3][num5] & 3) << 1 | this.StageInfo[3][num5 - 1] >> 7);
						}
					}
				}
				else
				{
					num = this.StageInfo[3][num5] >> num4 - 2;
				}
				num &= 7;
			}
		}
		return num;
	}

	// Token: 0x0600185B RID: 6235 RVA: 0x0028DEFC File Offset: 0x0028C0FC
	public void SetStagePoint(ushort PointID, byte Score, ushort Freq = 0)
	{
		this.DareNodusUpdatePointID = 0;
		int num = this.GetStagePoint(PointID, 0);
		if (this._stageMode == StageMode.Full)
		{
			if (num < 0 || num >= (int)Score)
			{
				return;
			}
			PointID /= 3;
			int num2 = (int)(PointID -= 1) << 1;
			int num3 = num2 >> 3;
			byte[] array = this.StageInfo[0];
			int num4 = num3;
			array[num4] &= (byte)(~(byte)(3 << (num2 & 7)));
			byte[] array2 = this.StageInfo[0];
			int num5 = num3;
			array2[num5] |= (byte)(Score << (num2 & 7));
		}
		else if (this._stageMode == StageMode.Lean)
		{
			if (num < (int)Score)
			{
				num = (int)Score;
			}
			int num6 = num | (int)Freq << 2;
			this.StageInfo[1][(int)(PointID - 1)] = (byte)num6;
		}
		else if (this._stageMode == StageMode.Dare)
		{
			Score &= 7;
			if (num < 0 || num >= (int)Score)
			{
				return;
			}
			this.DareNodusUpdatePointID = PointID;
			PointID -= 1;
			int num7 = (int)(PointID & 7);
			int num8 = PointID >> 3;
			if (num8 < this.StageInfo[3].Length)
			{
				if (num7 < 2)
				{
					if (num8 > 0)
					{
						if (num7 == 0)
						{
							byte[] array3 = this.StageInfo[3];
							int num9 = num8;
							array3[num9] &= 254;
							byte[] array4 = this.StageInfo[3];
							int num10 = num8;
							array4[num10] |= (byte)(Score >> 2);
							byte[] array5 = this.StageInfo[3];
							int num11 = num8 - 1;
							array5[num11] &= 63;
							byte[] array6 = this.StageInfo[3];
							int num12 = num8 - 1;
							array6[num12] |= (byte)(Score << 6);
						}
						else
						{
							byte[] array7 = this.StageInfo[3];
							int num13 = num8;
							array7[num13] &= 252;
							byte[] array8 = this.StageInfo[3];
							int num14 = num8;
							array8[num14] |= (byte)(Score >> 1);
							byte[] array9 = this.StageInfo[3];
							int num15 = num8 - 1;
							array9[num15] &= 127;
							byte[] array10 = this.StageInfo[3];
							int num16 = num8 - 1;
							array10[num16] |= (byte)(Score << 7);
						}
					}
				}
				else
				{
					byte[] array11 = this.StageInfo[3];
					int num17 = num8;
					array11[num17] &= (byte)(~(byte)(7 << num7 - 2));
					byte[] array12 = this.StageInfo[3];
					int num18 = num8;
					array12[num18] |= (byte)(Score << num7 - 2);
				}
			}
		}
	}

	// Token: 0x0600185C RID: 6236 RVA: 0x0028E120 File Offset: 0x0028C320
	public void ResetLeanStageTimes()
	{
		for (int i = 0; i < this.StageInfo[1].Length; i++)
		{
			this.StageInfo[1][i] = (this.StageInfo[1][i] & 3);
		}
	}

	// Token: 0x0600185D RID: 6237 RVA: 0x0028E160 File Offset: 0x0028C360
	public bool UpdateCorpsStageInfo(MessagePacket MP, bool reflash = false)
	{
		if (reflash)
		{
			reflash = this.reflashStageRecordInfo(StageMode.Corps, (ushort)MP.ReadByte(-1));
		}
		else
		{
			this.StageRecord[2] = (ushort)MP.ReadByte(-1);
			this.UpdateStagelimitRecord();
		}
		if (this.StageRecord[2] >= 1)
		{
			AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.TURFBATTLE1_COMPLETION);
		}
		FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.FIRST_CONQUER_TURF_BATTLE, 0L, 0UL);
		this.mStageTrapsCount = (this.mStageTroopsCount = 0);
		this.CorpsStagetotalStrength = (this.mStageTrapsAmount = (this.mStageTroopsAmount = 0u));
		for (int i = 0; i < 10; i++)
		{
			this.NowCombatStageInfo[i].SoldierTableID = MP.ReadByte(-1);
			this.NowCombatStageInfo[i].Amount = MP.ReadUInt(-1);
			if (this.NowCombatStageInfo[i].SoldierTableID > 16)
			{
				this.mStageTrapsCount += 1;
				this.mStageTrapsAmount += this.NowCombatStageInfo[i].Amount;
			}
			else if (this.NowCombatStageInfo[i].SoldierTableID > 0)
			{
				this.mStageTroopsCount += 1;
				this.mStageTroopsAmount += this.NowCombatStageInfo[i].Amount;
			}
			SoldierData recordByKey = DataManager.Instance.SoldierDataTable.GetRecordByKey((ushort)this.NowCombatStageInfo[i].SoldierTableID);
			this.CorpsStagetotalStrength += (uint)recordByKey.Strength * this.NowCombatStageInfo[i].Amount;
		}
		this.CorpsStageWallDefence = MP.ReadUInt(-1);
		return reflash;
	}

	// Token: 0x0600185E RID: 6238 RVA: 0x0028E318 File Offset: 0x0028C518
	public void UpdateRoleAttrExp(uint newExp)
	{
		if (DataManager.Instance.RoleAttr.Exp != newExp)
		{
			DataManager.Instance.RoleAttr.Exp = newExp;
		}
	}

	// Token: 0x0600185F RID: 6239 RVA: 0x0028E340 File Offset: 0x0028C540
	public void UpdateRoleTalentPoint(ushort newTalentPoint)
	{
		if (DataManager.Instance.RoleTalentPoint != newTalentPoint)
		{
			DataManager.Instance.tmpRoleTotalTalent = newTalentPoint - DataManager.Instance.RoleTalentPoint;
			DataManager.Instance.UpdateSaveTalent_Point(true);
			DataManager.Instance.RoleTalentPoint = newTalentPoint;
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 13, 0);
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			DataManager.Instance.CheckTalentSend();
		}
	}

	// Token: 0x06001860 RID: 6240 RVA: 0x0028E3AC File Offset: 0x0028C5AC
	public void UpdateRoleAttrMorale(ushort newMorale)
	{
		if (DataManager.Instance.RoleAttr.Morale != newMorale)
		{
			DataManager.Instance.RoleAttr.Morale = newMorale;
			GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
			GameManager.OnRefresh(NetworkNews.Refresh, null);
		}
	}

	// Token: 0x06001861 RID: 6241 RVA: 0x0028E3FC File Offset: 0x0028C5FC
	public void RoleAttrLevelUp(MessagePacket MP, int UpdateFlag = 59)
	{
		if ((UpdateFlag & 1) != 0)
		{
			this.UpdateRoleAttrLevel(MP.ReadByte(-1));
		}
		if ((UpdateFlag & 2) != 0)
		{
			this.UpdateRoleAttrExp(MP.ReadUInt(-1));
		}
		if ((UpdateFlag & 4) != 0)
		{
			DataManager.Instance.Resource[4].Stock = MP.ReadUInt(-1);
		}
		if ((UpdateFlag & 8) != 0)
		{
			this.UpdateRoleAttrMorale(MP.ReadUShort(-1));
		}
		if ((UpdateFlag & 16) != 0)
		{
			DataManager.Instance.RoleAttr.LastMoraleRecoverTime = MP.ReadLong(-1);
		}
		if ((UpdateFlag & 32) != 0)
		{
			this.UpdateRoleTalentPoint(MP.ReadUShort(-1));
		}
	}

	// Token: 0x06001862 RID: 6242 RVA: 0x0028E4A0 File Offset: 0x0028C6A0
	public void resetStageMode(StageMode newStageMode)
	{
		if (newStageMode >= StageMode.Count)
		{
			return;
		}
		this._stageMode = newStageMode;
		this.currentPointID = this.inoutPointID[(int)this._stageMode];
		if (this._stageMode == StageMode.Corps || this.currentPointID < 1 || this.currentPointID > this.limitRecord[(int)this._stageMode])
		{
			this.currentChapterID = this.ChapterID;
			this.InicurrentPointID();
			if (this.inoutPointID[(int)this._stageMode] != this.currentPointID)
			{
				this.inoutPointID[(int)this._stageMode] = this.currentPointID;
			}
		}
		else
		{
			this.currentChapterID = (byte)((this.currentPointID - 1) / GameConstants.StagePointNum[(int)this._stageMode]);
			this.currentChapterID += 1;
		}
	}

	// Token: 0x06001863 RID: 6243 RVA: 0x0028E56C File Offset: 0x0028C76C
	public bool CheckStageModle()
	{
		byte b = (byte)this.inoutStageMode;
		if (this.currentPointID != this.StageRecord[(int)b] + 1 || this.currentPointID != this.limitRecord[(int)b])
		{
			return true;
		}
		bool result = false;
		CString cstring = StringManager.Instance.SpawnString(30);
		ushort inKey = 1;
		if (DataManager.Instance.RoleAttr.Head != 0)
		{
			inKey = DataManager.Instance.RoleAttr.Head;
		}
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(inKey);
		cstring.ClearString();
		cstring.IntToFormat((long)recordByKey.Modle, 5, false);
		cstring.AppendFormat("Role/hero_{0}");
		if (recordByKey.Modle > 0 && AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, recordByKey.Modle, false))
		{
			ushort num = (ushort)this.currentChapterID;
			num -= 1;
			num *= 6;
			ushort num2 = this.StageRecord[(int)b];
			if (num2 == this.limitRecord[(int)b] && num2 > 0)
			{
				num2 -= 1;
			}
			num2 /= GameConstants.LinePointNum[(int)b];
			num2 %= 6;
			b += 1;
			if ((int)b > this.LevelTable.Length)
			{
				b = 1;
			}
			for (ushort num3 = 0; num3 <= num2; num3 += 1)
			{
				num += 1;
			}
			Level recordByKey2 = this.LevelTable[(int)b].GetRecordByKey(num);
			if (recordByKey2.Team == null)
			{
				return result;
			}
			HeroTeam recordByKey3 = DataManager.Instance.TeamTable.GetRecordByKey(recordByKey2.Team[2]);
			if (recordByKey3.Arrays == null)
			{
				return result;
			}
			for (int i = 0; i < recordByKey3.Arrays.Length; i++)
			{
				HeroTeamAttribute heroTeamAttribute = recordByKey3.Arrays[i];
				if (heroTeamAttribute.Type == 3)
				{
					inKey = heroTeamAttribute.Hero;
					recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(inKey);
					cstring.ClearString();
					cstring.IntToFormat((long)recordByKey.Modle, 5, false);
					cstring.AppendFormat("Role/hero_{0}");
					result = AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, recordByKey.Modle, false);
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x06001864 RID: 6244 RVA: 0x0028E798 File Offset: 0x0028C998
	public void SaveisNotFirstInChapter()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.uLongToFormat((ulong)DataManager.Instance.RoleAttr.UserId, 1, false);
		cstring.AppendFormat("{0}_isNotFirstInChapter");
		PlayerPrefs.SetInt(cstring.ToString(), (int)this.isNotFirstInChapter[3] << 3 | (int)this.isNotFirstInChapter[2] << 2 | (int)this.isNotFirstInChapter[1] << 1 | (int)this.isNotFirstInChapter[0]);
	}

	// Token: 0x06001865 RID: 6245 RVA: 0x0028E810 File Offset: 0x0028CA10
	public StageMode StageDareMode(byte in_ChapterID)
	{
		byte b = 3;
		ushort num = this.StageRecord[(int)b];
		if (num >= this.limitRecord[(int)b])
		{
			num = this.limitRecord[(int)b];
		}
		num /= GameConstants.StagePointNum[(int)b];
		byte b2 = (byte)(num + 1);
		return (in_ChapterID >= b2) ? StageMode.Full : StageMode.Lean;
	}

	// Token: 0x06001866 RID: 6246 RVA: 0x0028E860 File Offset: 0x0028CA60
	public StageMode StageDareMode(ushort in_PointID)
	{
		byte b = 3;
		ushort num = (in_PointID != 0) ? (in_PointID - 1) : 0;
		if (num >= this.limitRecord[(int)b])
		{
			num = this.limitRecord[(int)b];
		}
		num /= GameConstants.StagePointNum[(int)b];
		byte in_ChapterID = (byte)(num + 1);
		return this.StageDareMode(in_ChapterID);
	}

	// Token: 0x06001867 RID: 6247 RVA: 0x0028E8B4 File Offset: 0x0028CAB4
	public bool GetStageConditionString(CString CStr, byte ConditionID, ushort FactorA = 0, ushort FactorB = 0, ushort ConditionKey = 0)
	{
		bool result = true;
		DataManager instance = DataManager.Instance;
		CStr.Length = 0;
		switch (ConditionID)
		{
		case 1:
			CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)(9200 + FactorB)));
			if (FactorA == 0)
			{
				CStr.AppendFormat(instance.mStringTable.GetStringByID(13501u));
			}
			else
			{
				CStr.AppendFormat(instance.mStringTable.GetStringByID(13502u));
			}
			break;
		case 2:
			CStr.IntToFormat((long)FactorA, 1, false);
			CStr.AppendFormat(instance.mStringTable.GetStringByID(13503u));
			break;
		case 3:
		{
			Hero recordByKey = instance.HeroTable.GetRecordByKey(FactorA);
			CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey.HeroTitle));
			CStr.AppendFormat(instance.mStringTable.GetStringByID(13504u));
			break;
		}
		case 4:
			CStr.IntToFormat((long)FactorA, 1, false);
			CStr.AppendFormat(instance.mStringTable.GetStringByID(13505u));
			break;
		case 5:
			if (FactorA == 0)
			{
				CStr.Append(instance.mStringTable.GetStringByID(13506u));
			}
			else
			{
				CStr.IntToFormat((long)FactorA, 1, false);
				CStr.AppendFormat(instance.mStringTable.GetStringByID(12502u));
			}
			break;
		case 6:
			if (FactorA == 1)
			{
				CStr.StringToFormat(instance.mStringTable.GetStringByID(13517u));
			}
			else
			{
				CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)(13519 + FactorA)));
			}
			CStr.IntToFormat((long)FactorB, 1, false);
			CStr.AppendFormat(instance.mStringTable.GetStringByID(13509u));
			break;
		case 7:
			CStr.IntToFormat((long)FactorA, 1, false);
			CStr.IntToFormat((long)FactorB, 1, false);
			CStr.AppendFormat(instance.mStringTable.GetStringByID(13510u));
			break;
		case 8:
			if (FactorA == 0)
			{
				CStr.Append(instance.mStringTable.GetStringByID(13531u));
			}
			else
			{
				CStr.IntToFormat((long)FactorA, 1, false);
				CStr.AppendFormat(instance.mStringTable.GetStringByID(13511u));
			}
			break;
		case 9:
			CStr.IntToFormat((long)FactorA, 1, false);
			CStr.AppendFormat(instance.mStringTable.GetStringByID(13512u));
			break;
		case 10:
		{
			Hero recordByKey2 = instance.HeroTable.GetRecordByKey(FactorA);
			CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey2.HeroTitle));
			CStr.AppendFormat(instance.mStringTable.GetStringByID(13513u));
			break;
		}
		case 11:
		{
			if (FactorA < 1 || FactorA > 3 || FactorB < 1 || FactorB > 20)
			{
				return false;
			}
			Level levelBycurrentPointID = this.GetLevelBycurrentPointID(0);
			HeroTeam recordByKey3 = instance.TeamTable.GetRecordByKey(levelBycurrentPointID.Team[(int)(FactorA - 1)]);
			Hero recordByKey4 = instance.HeroTable.GetRecordByKey(recordByKey3.Arrays[(int)(FactorB - 1)].Hero);
			CStr.IntToFormat((long)FactorA, 1, false);
			CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey4.HeroTitle));
			CStr.AppendFormat(instance.mStringTable.GetStringByID(13514u));
			break;
		}
		case 12:
		{
			if (FactorA < 1 || FactorA > 3 || FactorB < 1 || FactorB > 20)
			{
				return false;
			}
			Level levelBycurrentPointID2 = this.GetLevelBycurrentPointID(0);
			HeroTeam recordByKey5 = instance.TeamTable.GetRecordByKey(levelBycurrentPointID2.Team[(int)(FactorA - 1)]);
			Hero recordByKey6 = instance.HeroTable.GetRecordByKey(recordByKey5.Arrays[(int)(FactorB - 1)].Hero);
			CStr.IntToFormat((long)FactorA, 1, false);
			CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey6.HeroTitle));
			CStr.AppendFormat(instance.mStringTable.GetStringByID(13515u));
			break;
		}
		case 13:
			CStr.IntToFormat((long)FactorA, 1, false);
			CStr.AppendFormat(instance.mStringTable.GetStringByID(13518u));
			break;
		case 14:
			CStr.IntToFormat((long)FactorA, 1, false);
			CStr.IntToFormat((long)FactorB, 1, false);
			CStr.AppendFormat(instance.mStringTable.GetStringByID(13519u));
			break;
		case 15:
			if (FactorA == 1)
			{
				CStr.StringToFormat(instance.mStringTable.GetStringByID(13533u));
			}
			else if (FactorA == 2)
			{
				CStr.StringToFormat(instance.mStringTable.GetStringByID(13534u));
			}
			else if (FactorA == 3)
			{
				CStr.StringToFormat(instance.mStringTable.GetStringByID(13535u));
			}
			else if (FactorA == 4)
			{
				CStr.StringToFormat(instance.mStringTable.GetStringByID(13536u));
			}
			else if (FactorA == 5)
			{
				CStr.StringToFormat(instance.mStringTable.GetStringByID(13537u));
			}
			else
			{
				CStr.StringToFormat(instance.mStringTable.GetStringByID(13533u));
			}
			CStr.AppendFormat(instance.mStringTable.GetStringByID(13507u));
			break;
		case 16:
			CStr.Append(instance.mStringTable.GetStringByID(13508u));
			break;
		case 17:
			if (FactorA == 0)
			{
				if (FactorB == 1)
				{
					CStr.StringToFormat(instance.mStringTable.GetStringByID(13517u));
				}
				else
				{
					CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)(13519 + FactorB)));
				}
				CStr.AppendFormat(instance.mStringTable.GetStringByID(12503u));
			}
			else
			{
				CStr.IntToFormat((long)FactorA, 1, false);
				if (FactorB == 1)
				{
					CStr.StringToFormat(instance.mStringTable.GetStringByID(13517u));
				}
				else
				{
					CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)(13519 + FactorB)));
				}
				CStr.AppendFormat(instance.mStringTable.GetStringByID(13532u));
			}
			break;
		case 18:
		case 27:
		{
			ushort factorA = DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(ConditionKey).ConditionArray[7].FactorA;
			if (factorA < 1 || factorA > 3 || FactorA < 1 || FactorA > 20)
			{
				return false;
			}
			Level levelBycurrentPointID3 = this.GetLevelBycurrentPointID(0);
			HeroTeam recordByKey7 = instance.TeamTable.GetRecordByKey(levelBycurrentPointID3.Team[(int)(factorA - 1)]);
			Hero recordByKey8 = instance.HeroTable.GetRecordByKey(recordByKey7.Arrays[(int)(FactorA - 1)].Hero);
			CStr.IntToFormat((long)factorA, 1, false);
			CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey8.HeroTitle));
			if (FactorB == 1)
			{
				CStr.StringToFormat(instance.mStringTable.GetStringByID(13517u));
			}
			else
			{
				CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)(13519 + FactorB)));
			}
			if (ConditionID == 18)
			{
				CStr.AppendFormat(instance.mStringTable.GetStringByID(12504u));
			}
			else if (ConditionID == 27)
			{
				CStr.AppendFormat(instance.mStringTable.GetStringByID(12520u));
			}
			break;
		}
		case 19:
			CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)(12700 + FactorA)));
			CStr.AppendFormat(instance.mStringTable.GetStringByID(12505u));
			break;
		case 20:
			CStr.IntToFormat((long)FactorA, 1, false);
			CStr.AppendFormat(instance.mStringTable.GetStringByID(13520u));
			break;
		case 21:
		{
			Hero recordByKey9 = instance.HeroTable.GetRecordByKey(FactorB);
			CStr.IntToFormat((long)FactorA, 1, false);
			CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey9.HeroName));
			CStr.AppendFormat(instance.mStringTable.GetStringByID(12507u));
			break;
		}
		case 22:
			if (FactorA == 0)
			{
				Skill recordByKey10 = DataManager.Instance.SkillTable.GetRecordByKey(FactorB);
				CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey10.Describe));
				CStr.AppendFormat(instance.mStringTable.GetStringByID(12503u));
			}
			else
			{
				CStr.IntToFormat((long)FactorA, 1, false);
				Skill recordByKey11 = DataManager.Instance.SkillTable.GetRecordByKey(FactorB);
				CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey11.Describe));
				CStr.AppendFormat(instance.mStringTable.GetStringByID(13532u));
			}
			break;
		case 23:
		{
			ushort factorA2 = DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(ConditionKey).ConditionArray[7].FactorA;
			if (factorA2 < 1 || factorA2 > 3 || FactorA < 1 || FactorA > 20)
			{
				return false;
			}
			Level levelBycurrentPointID4 = this.GetLevelBycurrentPointID(0);
			HeroTeam recordByKey12 = instance.TeamTable.GetRecordByKey(levelBycurrentPointID4.Team[(int)(factorA2 - 1)]);
			Hero recordByKey13 = instance.HeroTable.GetRecordByKey(recordByKey12.Arrays[(int)(FactorA - 1)].Hero);
			CStr.IntToFormat((long)factorA2, 1, false);
			CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey13.HeroTitle));
			CStr.IntToFormat((long)FactorB, 1, false);
			CStr.AppendFormat(instance.mStringTable.GetStringByID(12510u));
			break;
		}
		case 24:
			if (FactorA == 0)
			{
				switch (FactorB)
				{
				case 0:
					CStr.Append(instance.mStringTable.GetStringByID(12512u));
					break;
				case 1:
					CStr.Append(instance.mStringTable.GetStringByID(12514u));
					break;
				case 2:
					CStr.Append(instance.mStringTable.GetStringByID(12516u));
					break;
				}
			}
			else
			{
				CStr.IntToFormat((long)FactorA, 1, false);
				switch (FactorB)
				{
				case 0:
					CStr.AppendFormat(instance.mStringTable.GetStringByID(12513u));
					break;
				case 1:
					CStr.AppendFormat(instance.mStringTable.GetStringByID(12515u));
					break;
				case 2:
					CStr.AppendFormat(instance.mStringTable.GetStringByID(12517u));
					break;
				}
			}
			break;
		case 25:
		{
			Hero recordByKey14 = instance.HeroTable.GetRecordByKey(FactorB);
			CStr.IntToFormat((long)FactorA, 1, false);
			CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey14.HeroName));
			CStr.AppendFormat(instance.mStringTable.GetStringByID(12518u));
			break;
		}
		case 26:
		{
			Hero recordByKey15 = instance.HeroTable.GetRecordByKey(FactorB);
			CStr.IntToFormat((long)FactorA, 1, false);
			CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey15.HeroName));
			CStr.AppendFormat(instance.mStringTable.GetStringByID(12519u));
			break;
		}
		case 28:
		{
			ushort factorA3 = DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(ConditionKey).ConditionArray[7].FactorA;
			if (factorA3 < 1 || factorA3 > 3 || FactorA < 1 || FactorA > 20)
			{
				return false;
			}
			Level levelBycurrentPointID5 = this.GetLevelBycurrentPointID(0);
			HeroTeam recordByKey16 = instance.TeamTable.GetRecordByKey(levelBycurrentPointID5.Team[(int)(factorA3 - 1)]);
			Hero recordByKey17 = instance.HeroTable.GetRecordByKey(recordByKey16.Arrays[(int)(FactorA - 1)].Hero);
			CStr.IntToFormat((long)factorA3, 1, false);
			CStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey17.HeroTitle));
			if (FactorB != 0)
			{
				CStr.IntToFormat((long)FactorB, 1, false);
				CStr.AppendFormat(instance.mStringTable.GetStringByID(12522u));
			}
			else
			{
				CStr.AppendFormat(instance.mStringTable.GetStringByID(12521u));
			}
			break;
		}
		case 29:
		{
			Skill recordByKey18 = DataManager.Instance.SkillTable.GetRecordByKey(FactorB);
			CStr.Append(instance.mStringTable.GetStringByID((uint)recordByKey18.Describe));
			break;
		}
		default:
			if (ConditionID != 255)
			{
				result = false;
			}
			else
			{
				CStr.Append(instance.mStringTable.GetStringByID(13516u));
			}
			break;
		}
		return result;
	}

	// Token: 0x06001868 RID: 6248 RVA: 0x0028F574 File Offset: 0x0028D774
	public Sprite GetStageConditionSprite(byte ConditionID, ushort FactorA = 0, ushort FactorB = 0)
	{
		StageConditionInfo recordByKey = this.StageConditionInfoTable.GetRecordByKey((ushort)ConditionID);
		if (recordByKey.ConditionID != (ushort)ConditionID)
		{
			recordByKey = this.StageConditionInfoTable.GetRecordByKey(255);
		}
		GUIManager instance = GUIManager.Instance;
		if (recordByKey.PicType == 0)
		{
			return instance.m_ConditiontIconSpriteAsset.LoadSprite((ushort)recordByKey.PicNo);
		}
		if (recordByKey.PicType == 1)
		{
			return instance.m_IconSpriteAsset.LoadSprite(DataManager.Instance.HeroTable.GetRecordByKey(FactorA).Graph);
		}
		if (recordByKey.PicType == 2)
		{
			return instance.m_IconSpriteAsset.LoadSprite(DataManager.Instance.HeroTable.GetRecordByKey(FactorB).Graph);
		}
		return instance.m_ConditiontIconSpriteAsset.LoadSprite(1);
	}

	// Token: 0x06001869 RID: 6249 RVA: 0x0028F640 File Offset: 0x0028D840
	public Material GetStageConditionMaterial(byte ConditionID)
	{
		StageConditionInfo recordByKey = this.StageConditionInfoTable.GetRecordByKey((ushort)ConditionID);
		if (recordByKey.ConditionID != (ushort)ConditionID)
		{
			recordByKey = this.StageConditionInfoTable.GetRecordByKey(255);
		}
		if (recordByKey.PicType == 1 || recordByKey.PicType == 2)
		{
			return GUIManager.Instance.m_IconSpriteAsset.GetMaterial();
		}
		return GUIManager.Instance.m_ConditiontIconSpriteAsset.GetMaterial();
	}

	// Token: 0x0600186A RID: 6250 RVA: 0x0028F6B4 File Offset: 0x0028D8B4
	public void GetUserStage(StageMode getStageMode)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.uLongToFormat((ulong)DataManager.Instance.RoleAttr.UserId, 1, false);
		cstring.IntToFormat((long)getStageMode, 1, false);
		cstring.AppendFormat("{0}_{1}_currentPointID");
		this.inoutPointID[(int)getStageMode] = (ushort)PlayerPrefs.GetInt(cstring.ToString());
		if (this.inoutPointID[(int)getStageMode] > this.StageRecord[(int)getStageMode] + 1)
		{
			this.inoutPointID[(int)getStageMode] = this.StageRecord[(int)getStageMode] + 1;
		}
		if (this.inoutPointID[(int)getStageMode] > this.limitRecord[(int)getStageMode])
		{
			this.inoutPointID[(int)getStageMode] = this.StageRecord[(int)getStageMode];
		}
	}

	// Token: 0x0600186B RID: 6251 RVA: 0x0028F764 File Offset: 0x0028D964
	public void SaveUserStage(StageMode saveStageMode)
	{
		if (saveStageMode == this._stageMode && this.inoutPointID[(int)saveStageMode] != this.currentPointID)
		{
			this.inoutPointID[(int)saveStageMode] = this.currentPointID;
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.uLongToFormat((ulong)DataManager.Instance.RoleAttr.UserId, 1, false);
			cstring.IntToFormat((long)saveStageMode, 1, false);
			cstring.AppendFormat("{0}_{1}_currentPointID");
			PlayerPrefs.SetInt(cstring.ToString(), (int)this.inoutPointID[(int)saveStageMode]);
		}
	}

	// Token: 0x0600186C RID: 6252 RVA: 0x0028F7F0 File Offset: 0x0028D9F0
	public void SaveUserStageMode(StageMode saveStageMode)
	{
		if (saveStageMode != this.inoutStageMode)
		{
			this.inoutStageMode = saveStageMode;
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.uLongToFormat((ulong)DataManager.Instance.RoleAttr.UserId, 1, false);
			cstring.AppendFormat("{0}_currentStageMode");
			PlayerPrefs.SetInt(cstring.ToString(), (int)this.inoutStageMode);
		}
	}

	// Token: 0x040047AD RID: 18349
	public CExternalTableWithWordKey<Chapter> ChapterTable;

	// Token: 0x040047AE RID: 18350
	public CExternalTableWithWordKey<Level>[] LevelTable;

	// Token: 0x040047AF RID: 18351
	public CExternalTableWithWordKey<LevelEX>[] LevelEXTable;

	// Token: 0x040047B0 RID: 18352
	public CExternalTableWithWordKey<Stage> StageTable;

	// Token: 0x040047B1 RID: 18353
	public CExternalTableWithWordKey<CorpsStage> CorpsStageTable;

	// Token: 0x040047B2 RID: 18354
	public CExternalTableWithWordKey<CorpsStageBattle> CorpsStageBattleTable;

	// Token: 0x040047B3 RID: 18355
	public CExternalTableWithWordKey<StageConditionData> StageConditionDataTable;

	// Token: 0x040047B4 RID: 18356
	public CExternalTableWithWordKey<StageConditionInfo> StageConditionInfoTable;

	// Token: 0x040047B5 RID: 18357
	public byte currentChapterID = byte.MaxValue;

	// Token: 0x040047B6 RID: 18358
	public ushort currentPointID;

	// Token: 0x040047B7 RID: 18359
	public ushort savePointID;

	// Token: 0x040047B8 RID: 18360
	public StageMode saveStageMode;

	// Token: 0x040047B9 RID: 18361
	public ushort lastStageRecord;

	// Token: 0x040047BA RID: 18362
	public ushort[] StageRecord;

	// Token: 0x040047BB RID: 18363
	public ushort[] inoutPointID;

	// Token: 0x040047BC RID: 18364
	public byte[][] StageInfo;

	// Token: 0x040047BD RID: 18365
	public byte[] isNotFirstInLine;

	// Token: 0x040047BE RID: 18366
	public byte[] isNotFirstInChapter;

	// Token: 0x040047BF RID: 18367
	public ushort[] limitRecord;

	// Token: 0x040047C0 RID: 18368
	public StageMode _stageMode = StageMode.Count;

	// Token: 0x040047C1 RID: 18369
	public StageMode inoutStageMode = StageMode.Count;

	// Token: 0x040047C2 RID: 18370
	public WorldMode currentWorldMode;

	// Token: 0x040047C3 RID: 18371
	public CombatStageSoldierDataType[] NowCombatStageInfo;

	// Token: 0x040047C4 RID: 18372
	public uint CorpsStageWallDefence;

	// Token: 0x040047C5 RID: 18373
	public byte currentNodus;

	// Token: 0x040047C6 RID: 18374
	public ushort DareNodusUpdatePointID;

	// Token: 0x040047C7 RID: 18375
	public byte mStageTroopsCount;

	// Token: 0x040047C8 RID: 18376
	public byte mStageTrapsCount;

	// Token: 0x040047C9 RID: 18377
	public uint mStageTroopsAmount;

	// Token: 0x040047CA RID: 18378
	public uint mStageTrapsAmount;

	// Token: 0x040047CB RID: 18379
	public uint CorpsStagetotalStrength;
}
