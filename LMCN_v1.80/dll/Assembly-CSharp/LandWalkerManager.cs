using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200037C RID: 892
public class LandWalkerManager
{
	// Token: 0x1700008E RID: 142
	// (get) Token: 0x060012AA RID: 4778 RVA: 0x0020B818 File Offset: 0x00209A18
	public static bool alive
	{
		get
		{
			return LandWalkerManager._instance != null;
		}
	}

	// Token: 0x1700008F RID: 143
	// (get) Token: 0x060012AB RID: 4779 RVA: 0x0020B828 File Offset: 0x00209A28
	public static LandWalkerManager Instance
	{
		get
		{
			if (LandWalkerManager._instance == null)
			{
				LandWalkerManager._instance = new LandWalkerManager();
				LandWalkerManager._instance.Awake();
			}
			return LandWalkerManager._instance;
		}
	}

	// Token: 0x060012AC RID: 4780 RVA: 0x0020B850 File Offset: 0x00209A50
	public static void Release()
	{
		if (LandWalkerManager._instance == null)
		{
			return;
		}
		LandWalkerManager._instance.ClearWalkers();
		for (int i = 0; i < LandWalkerManager._instance.freeWalkers.Count; i++)
		{
			LandWalkerManager._instance.freeWalkers[i].movingUnit.RecoverUnit();
			LandWalkerManager._instance.freeWalkers[i].movingUnit = null;
		}
		LandWalkerManager._instance.freeWalkers.Clear();
		LandWalkerManager instance = LandWalkerManager._instance;
		LandWalkerManager._instance = null;
		SheetAnimationUnitGroup.FreeResource();
		if (instance.WalkerCenter != null)
		{
			UnityEngine.Object.Destroy(instance.WalkerCenter);
		}
	}

	// Token: 0x060012AD RID: 4781 RVA: 0x0020B900 File Offset: 0x00209B00
	public void OnApplicationQuit()
	{
		LandWalkerManager.Release();
	}

	// Token: 0x060012AE RID: 4782 RVA: 0x0020B908 File Offset: 0x00209B08
	protected void Awake()
	{
		LandWalkerManager._instance = this;
		this.WalkerCenter = new GameObject();
		this.WalkerCenter.name = "LandWalkers";
		this.WalkerCenter.transform.position = Vector3.zero;
		SheetAnimationUnitGroup.InitResource();
		this.walkers = new List<LandWalker>();
		this.freeWalkers = new List<LandWalker>();
		this.WalkerMarks = new List<ushort>();
		this.WalkerGroupIdx = new ushort[DataManager.Instance.LandWalkerData.TableCount + 1];
		int num = 0;
		ushort num2 = 0;
		ushort num3 = 0;
		while ((int)num3 < DataManager.Instance.LandWalkerData.TableCount)
		{
			this.walkerData = DataManager.Instance.LandWalkerData.GetRecordByIndex((int)num3);
			if (num != (int)this.walkerData.groupID)
			{
				num = (int)this.walkerData.groupID;
				this.WalkerMarks.Add(num3);
				num2 += 1;
			}
			this.WalkerGroupIdx[(int)num3] = num2;
			num3 += 1;
		}
		this.WalkerCount = new WalkerGenData[this.WalkerMarks.Count];
		LandWalkerManager.SetNewCastleLevel(GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level);
		this.enabled = true;
	}

	// Token: 0x060012AF RID: 4783 RVA: 0x0020BA3C File Offset: 0x00209C3C
	public void Update()
	{
		if (!this.enabled)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		for (int i = 0; i < this.walkers.Count; i++)
		{
			this.walkers[i].update(deltaTime);
		}
		if (Time.time > this.nextActionTime)
		{
			this.nextActionTime = Time.time + this.ActionGap;
			switch (this.walkerBattleState)
			{
			case LandWalkerManager.WalkerBattleState.ChangeForBattle:
				if (DataManager.Instance.ServerTime > this.nextPerformTime)
				{
					this.BattleStateChange(LandWalkerManager.WalkerBattleState.BattleNow);
				}
				return;
			case LandWalkerManager.WalkerBattleState.BattleNow:
				if (DataManager.Instance.ServerTime > this.nextPerformTime)
				{
					this.BattleStateChange(LandWalkerManager.WalkerBattleState.ChangeForResult);
					return;
				}
				break;
			case LandWalkerManager.WalkerBattleState.ChangeForResult:
				if (DataManager.Instance.ServerTime > this.nextPerformTime)
				{
					this.BattleStateChange(LandWalkerManager.performState);
				}
				return;
			case LandWalkerManager.WalkerBattleState.BattleLose:
			case LandWalkerManager.WalkerBattleState.BattleWin:
				if (DataManager.Instance.ServerTime > this.nextPerformTime)
				{
					this.BattleStateChange(LandWalkerManager.WalkerBattleState.ChangeBackNormal);
					return;
				}
				break;
			case LandWalkerManager.WalkerBattleState.ChangeBackNormal:
				if (DataManager.Instance.ServerTime > this.nextPerformTime)
				{
					this.BattleStateChange(LandWalkerManager.WalkerBattleState.None);
					return;
				}
				break;
			}
			if (this.firstUpdate)
			{
				this.firstUpdate = false;
				this.PreCreateWalker();
			}
			ushort num = 0;
			while ((int)num < this.WalkerMarks.Count)
			{
				if (Time.time >= this.WalkerCount[(int)num].NextGenTime)
				{
					this.walkerData = DataManager.Instance.LandWalkerData.GetRecordByIndex((int)this.WalkerMarks[(int)num]);
					switch (this.walkerBattleState)
					{
					case LandWalkerManager.WalkerBattleState.None:
						if (DataManager.StageDataController.StageRecord[2] < (ushort)this.walkerData.chapter)
						{
							this.WalkerCount[(int)num].NextGenTime = Time.time + 60f;
							goto IL_4B9;
						}
						break;
					case LandWalkerManager.WalkerBattleState.ChangeForBattle:
					case LandWalkerManager.WalkerBattleState.ChangeForResult:
					case LandWalkerManager.WalkerBattleState.ChangeBackNormal:
						return;
					case LandWalkerManager.WalkerBattleState.BattleNow:
						if (this.walkerData.chapter != 200)
						{
							this.WalkerCount[(int)num].NextGenTime = Time.time + 60f;
							goto IL_4B9;
						}
						break;
					case LandWalkerManager.WalkerBattleState.BattleLose:
						if (this.walkerData.chapter != 201)
						{
							this.WalkerCount[(int)num].NextGenTime = Time.time + 60f;
							goto IL_4B9;
						}
						break;
					case LandWalkerManager.WalkerBattleState.BattleWin:
						if (this.walkerData.chapter != 202)
						{
							this.WalkerCount[(int)num].NextGenTime = Time.time + 60f;
							goto IL_4B9;
						}
						break;
					}
					if (this.WalkerCount[(int)num].isRepeat)
					{
						this.WalkerCount[(int)num].NextGenTime = Time.time + 60f;
						if (this.WalkerCount[(int)num].Count == 0 && this.CastleLevel >= this.walkerData.GenData[(int)this.WalkerCount[(int)num].GenBlock].castleLevel)
						{
							this.addWalker(this.WalkerMarks[(int)num], this.WalkerCount[(int)num].GenBlock, true);
							WalkerGenData[] walkerCount = this.WalkerCount;
							ushort num2 = num;
							walkerCount[(int)num2].Count = walkerCount[(int)num2].Count + 1;
						}
					}
					else if ((this.walkerData.GenData[(int)this.WalkerCount[(int)num].GenBlock].GenLimit == 0 || this.WalkerCount[(int)num].Count < this.walkerData.GenData[(int)this.WalkerCount[(int)num].GenBlock].GenLimit) && this.CastleLevel >= this.walkerData.GenData[(int)this.WalkerCount[(int)num].GenBlock].castleLevel)
					{
						this.WalkerCount[(int)num].NextGenTime = Time.time + (float)this.walkerData.GenData[(int)this.WalkerCount[(int)num].GenBlock].GenGap + (float)this.walkerData.GenData[(int)this.WalkerCount[(int)num].GenBlock].GenRandom * UnityEngine.Random.value;
						this.addWalker(this.WalkerMarks[(int)num], this.WalkerCount[(int)num].GenBlock, false);
						WalkerGenData[] walkerCount2 = this.WalkerCount;
						ushort num3 = num;
						walkerCount2[(int)num3].Count = walkerCount2[(int)num3].Count + 1;
					}
				}
				IL_4B9:
				num += 1;
			}
		}
	}

	// Token: 0x060012B0 RID: 4784 RVA: 0x0020BF18 File Offset: 0x0020A118
	public static bool IsBattleFire()
	{
		if (LandWalkerManager.isWinning)
		{
			if (LandWalkerManager.LastBattleTime + 1200L > DataManager.Instance.ServerTime)
			{
				return true;
			}
		}
		else if (LandWalkerManager.LastBattleTime + 1200L > DataManager.Instance.ServerTime)
		{
			return true;
		}
		return false;
	}

	// Token: 0x060012B1 RID: 4785 RVA: 0x0020BF70 File Offset: 0x0020A170
	private void PreCreateWalker()
	{
		LandWalkerManager.WalkerBattleState walkerBattleState = LandWalkerManager.performState;
		if (walkerBattleState != LandWalkerManager.WalkerBattleState.BattleLose)
		{
			if (walkerBattleState == LandWalkerManager.WalkerBattleState.BattleWin)
			{
				if (LandWalkerManager.LastBattleTime + 1200L > DataManager.Instance.ServerTime)
				{
					if (LandWalkerManager.StartBattle)
					{
						LandWalkerManager.StartBattle = false;
						this.BattleStateChange(LandWalkerManager.WalkerBattleState.ChangeForBattle);
					}
					else
					{
						this.BattleStateChange(LandWalkerManager.performState);
					}
					return;
				}
			}
		}
		else if (LandWalkerManager.LastBattleTime + 1200L > DataManager.Instance.ServerTime)
		{
			if (LandWalkerManager.StartBattle)
			{
				LandWalkerManager.StartBattle = false;
				this.BattleStateChange(LandWalkerManager.WalkerBattleState.ChangeForBattle);
			}
			else
			{
				this.BattleStateChange(LandWalkerManager.performState);
			}
			return;
		}
		ushort num = 0;
		while ((int)num < this.WalkerMarks.Count)
		{
			if (UnityEngine.Random.value <= 0.5f)
			{
				this.walkerData = DataManager.Instance.LandWalkerData.GetRecordByIndex((int)this.WalkerMarks[(int)num]);
				if (DataManager.StageDataController.StageRecord[2] < (ushort)this.walkerData.chapter)
				{
					this.WalkerCount[(int)num].NextGenTime = Time.time + 60f;
				}
				else if (!this.WalkerCount[(int)num].isRepeat)
				{
					if ((this.walkerData.GenData[(int)this.WalkerCount[(int)num].GenBlock].GenLimit == 0 || this.WalkerCount[(int)num].Count < this.walkerData.GenData[(int)this.WalkerCount[(int)num].GenBlock].GenLimit) && this.CastleLevel >= this.walkerData.GenData[(int)this.WalkerCount[(int)num].GenBlock].castleLevel)
					{
						this.WalkerCount[(int)num].NextGenTime = Time.time + (float)this.walkerData.GenData[(int)this.WalkerCount[(int)num].GenBlock].GenGap + (float)this.walkerData.GenData[(int)this.WalkerCount[(int)num].GenBlock].GenRandom * UnityEngine.Random.value;
						int num2;
						if ((int)(num + 1) < this.WalkerMarks.Count)
						{
							num2 = UnityEngine.Random.Range((int)this.WalkerMarks[(int)num], (int)(this.WalkerMarks[(int)(num + 1)] - 1));
						}
						else
						{
							num2 = UnityEngine.Random.Range((int)this.WalkerMarks[(int)num], DataManager.Instance.LandWalkerData.TableCount - 1);
						}
						LandWalker landWalker = this.addWalker((ushort)num2, this.WalkerCount[(int)num].GenBlock, false);
						landWalker.nowTime = landWalker.totalTime * UnityEngine.Random.value;
						WalkerGenData[] walkerCount = this.WalkerCount;
						ushort num3 = num;
						walkerCount[(int)num3].Count = walkerCount[(int)num3].Count + 1;
					}
				}
			}
			num += 1;
		}
	}

	// Token: 0x060012B2 RID: 4786 RVA: 0x0020C280 File Offset: 0x0020A480
	public static void EndAction(LandWalker done)
	{
		ushort num = LandWalkerManager._instance.WalkerGroupIdx[(int)done.idx];
		switch (LandWalkerManager._instance.walkerBattleState)
		{
		case LandWalkerManager.WalkerBattleState.ChangeForBattle:
		case LandWalkerManager.WalkerBattleState.ChangeForResult:
		case LandWalkerManager.WalkerBattleState.ChangeBackNormal:
		{
			WalkerGenData[] walkerCount = LandWalkerManager._instance.WalkerCount;
			ushort num2 = num - 1;
			walkerCount[(int)num2].Count = walkerCount[(int)num2].Count - 1;
			LandWalkerManager._instance.walkers.Remove(done);
			LandWalkerManager._instance.freeWalkers.Add(done);
			done.movingUnit.gameObject.SetActive(false);
			done.movingUnit.RecoverUnit();
			return;
		}
		}
		if ((int)(done.idx + 1) < DataManager.Instance.LandWalkerData.TableCount && num == LandWalkerManager._instance.WalkerGroupIdx[(int)(done.idx + 1)])
		{
			done.movingUnit.RecoverUnit();
			done.setUnit(done.idx + 1, LandWalkerManager._instance.WalkerCount[(int)(num - 1)].GenBlock, false);
			return;
		}
		if (LandWalkerManager._instance.WalkerCount[(int)(num - 1)].isRepeat)
		{
			done.movingUnit.RecoverUnit();
			done.setUnit(LandWalkerManager._instance.WalkerMarks[(int)(num - 1)], LandWalkerManager._instance.WalkerCount[(int)(num - 1)].GenBlock, false);
			return;
		}
		WalkerGenData[] walkerCount2 = LandWalkerManager._instance.WalkerCount;
		ushort num3 = num - 1;
		walkerCount2[(int)num3].Count = walkerCount2[(int)num3].Count - 1;
		LandWalkerManager._instance.walkers.Remove(done);
		LandWalkerManager._instance.freeWalkers.Add(done);
		done.movingUnit.gameObject.SetActive(false);
		done.movingUnit.RecoverUnit();
	}

	// Token: 0x060012B3 RID: 4787 RVA: 0x0020C44C File Offset: 0x0020A64C
	public LandWalker addWalker(ushort idx, byte block, bool forceFade = false)
	{
		if (this.freeWalkers.Count > 0)
		{
			LandWalker landWalker = this.freeWalkers[0];
			this.freeWalkers.RemoveAt(0);
			this.walkers.Add(landWalker);
			landWalker.setUnit(idx, block, forceFade);
			return landWalker;
		}
		LandWalker landWalker2 = new LandWalker(this.WalkerCenter.transform);
		this.walkers.Add(landWalker2);
		landWalker2.setUnit(idx, block, forceFade);
		return landWalker2;
	}

	// Token: 0x060012B4 RID: 4788 RVA: 0x0020C4C4 File Offset: 0x0020A6C4
	public void ClearWalkers()
	{
		if (this.EffectGameObject != null)
		{
			ParticleManager.Instance.DeSpawn(this.EffectGameObject);
		}
		for (int i = 0; i < this.FireEffectGameObject.Length; i++)
		{
			if (this.FireEffectGameObject[i] != null)
			{
				ParticleManager.Instance.DeSpawn(this.FireEffectGameObject[i]);
			}
		}
		for (int j = 0; j < this.walkers.Count; j++)
		{
			this.walkers[j].movingUnit.gameObject.SetActive(false);
			this.freeWalkers.Add(this.walkers[j]);
		}
		this.walkers.Clear();
	}

	// Token: 0x060012B5 RID: 4789 RVA: 0x0020C58C File Offset: 0x0020A78C
	public static void SetNewCastleLevel(byte level)
	{
		if (LandWalkerManager._instance == null)
		{
			return;
		}
		LandWalkerManager._instance.CastleLevel = level;
		for (int i = 0; i < LandWalkerManager._instance.WalkerMarks.Count; i++)
		{
			LandWalkerManager._instance.walkerData = DataManager.Instance.LandWalkerData.GetRecordByIndex((int)LandWalkerManager._instance.WalkerMarks[i]);
			LandWalkerManager._instance.WalkerCount[i].isRepeat = (LandWalkerManager._instance.walkerData.NeverGone != 0);
			for (byte b = 0; b < 4; b += 1)
			{
				if (level >= LandWalkerManager._instance.walkerData.GenData[(int)b].castleLevel && LandWalkerManager._instance.walkerData.GenData[(int)b].castleLevel != 0)
				{
					LandWalkerManager._instance.WalkerCount[i].GenBlock = b;
					LandWalkerManager._instance.WalkerCount[i].NextGenTime = Time.time + (float)LandWalkerManager._instance.walkerData.GenData[(int)LandWalkerManager._instance.WalkerCount[i].GenBlock].GenGap + (float)LandWalkerManager._instance.walkerData.GenData[(int)LandWalkerManager._instance.WalkerCount[i].GenBlock].GenRandom * UnityEngine.Random.value;
				}
			}
		}
	}

	// Token: 0x060012B6 RID: 4790 RVA: 0x0020C70C File Offset: 0x0020A90C
	public static void HappenAttack(long HappenTime, bool isWinning)
	{
		if (LandWalkerManager.LastBattleTime == HappenTime)
		{
			return;
		}
		if (isWinning)
		{
			LandWalkerManager.performState = LandWalkerManager.WalkerBattleState.BattleWin;
		}
		else
		{
			LandWalkerManager.performState = LandWalkerManager.WalkerBattleState.BattleLose;
		}
		if (LandWalkerManager._instance != null)
		{
			LandWalkerManager._instance.BattleStateChange(LandWalkerManager.WalkerBattleState.ChangeForBattle);
		}
		else
		{
			LandWalkerManager.StartBattle = true;
		}
		LandWalkerManager.isWinning = isWinning;
		LandWalkerManager.LastBattleTime = HappenTime;
	}

	// Token: 0x060012B7 RID: 4791 RVA: 0x0020C768 File Offset: 0x0020A968
	public static void SetActionNormal()
	{
		LandWalkerManager.LastBattleTime = 0L;
		if (LandWalkerManager._instance != null)
		{
			LandWalkerManager._instance.BattleStateChange(LandWalkerManager.WalkerBattleState.ChangeBackNormal);
		}
	}

	// Token: 0x060012B8 RID: 4792 RVA: 0x0020C788 File Offset: 0x0020A988
	public void BattleStateChange(LandWalkerManager.WalkerBattleState battleState)
	{
		this.walkerBattleState = battleState;
		this.firstUpdate = false;
		switch (battleState)
		{
		case LandWalkerManager.WalkerBattleState.None:
			this.nextPerformTime = 0L;
			for (int i = 0; i < this.walkers.Count; i++)
			{
				this.walkers[i].SetFade();
			}
			if (this.EffectGameObject != null)
			{
				ParticleManager.Instance.DeSpawn(this.EffectGameObject);
			}
			for (int j = 0; j < this.FireEffectGameObject.Length; j++)
			{
				if (this.FireEffectGameObject[j] != null)
				{
					ParticleManager.Instance.DeSpawn(this.FireEffectGameObject[j]);
				}
			}
			break;
		case LandWalkerManager.WalkerBattleState.ChangeForBattle:
		case LandWalkerManager.WalkerBattleState.ChangeForResult:
		case LandWalkerManager.WalkerBattleState.ChangeBackNormal:
			this.nextPerformTime = DataManager.Instance.ServerTime + (long)this.actionChangeTime;
			for (int k = 0; k < this.walkers.Count; k++)
			{
				this.walkers[k].SetFade();
			}
			if (this.EffectGameObject != null)
			{
				ParticleManager.Instance.DeSpawn(this.EffectGameObject);
			}
			for (int l = 0; l < this.FireEffectGameObject.Length; l++)
			{
				if (this.FireEffectGameObject[l] != null)
				{
					ParticleManager.Instance.DeSpawn(this.FireEffectGameObject[l]);
				}
			}
			break;
		case LandWalkerManager.WalkerBattleState.BattleNow:
			this.nextPerformTime = DataManager.Instance.ServerTime + (long)this.BattleTime;
			break;
		case LandWalkerManager.WalkerBattleState.BattleLose:
			this.nextPerformTime = Math.Max(DataManager.Instance.ServerTime + 30L, LandWalkerManager.LastBattleTime + 1200L);
			this.PlayEffect(false);
			break;
		case LandWalkerManager.WalkerBattleState.BattleWin:
			this.nextPerformTime = Math.Max(DataManager.Instance.ServerTime + 30L, LandWalkerManager.LastBattleTime + 1200L);
			this.PlayEffect(true);
			break;
		}
		ushort num = 0;
		while ((int)num < this.WalkerMarks.Count)
		{
			this.walkerData = DataManager.Instance.LandWalkerData.GetRecordByIndex((int)this.WalkerMarks[(int)num]);
			if (this.WalkerCount[(int)num].isRepeat)
			{
				this.WalkerCount[(int)num].NextGenTime = Time.time;
			}
			else
			{
				this.WalkerCount[(int)num].NextGenTime = Time.time + 3f * UnityEngine.Random.value;
			}
			num += 1;
		}
	}

	// Token: 0x060012B9 RID: 4793 RVA: 0x0020CA2C File Offset: 0x0020AC2C
	public void PlayEffect(bool isFireWork)
	{
		if (isFireWork)
		{
			BuildManorData recordByKey = DataManager.Instance.BuildManorData.GetRecordByKey(0);
			float x = ((recordByKey.bPosionX <= 30000) ? ((float)recordByKey.bPosionX) : ((float)recordByKey.bPosionX - 65535f)) * 0.01f;
			float num = ((recordByKey.bPosionY <= 32768) ? ((float)recordByKey.bPosionY) : ((float)recordByKey.bPosionY - 65535f)) * 0.01f;
			float num2 = ((recordByKey.bPosionZ <= 32768) ? ((float)recordByKey.bPosionZ) : ((float)recordByKey.bPosionZ - 65535f)) * 0.01f;
			if (this.EffectGameObject != null)
			{
				ParticleManager.Instance.DeSpawn(this.EffectGameObject);
			}
			this.EffectGameObject = ParticleManager.Instance.Spawn(358, null, new Vector3(x, num + 40f, num2 + 20f), 2f, true, false, true);
			Quaternion localRotation = this.EffectGameObject.transform.localRotation;
			localRotation.eulerAngles = new Vector3(0f, 180f, 0f);
			this.EffectGameObject.transform.localRotation = localRotation;
		}
		else
		{
			float[,] array = new float[,]
			{
				{
					-48f,
					19f,
					0f,
					3f
				},
				{
					-75f,
					13f,
					13f,
					2f
				},
				{
					16f,
					16f,
					10.5f,
					2f
				},
				{
					-15.8f,
					16f,
					21.5f,
					2f
				},
				{
					-64f,
					12.7f,
					41.3f,
					1f
				},
				{
					31f,
					11f,
					33.3f,
					1f
				},
				{
					22f,
					10.2f,
					53.5f,
					2f
				}
			};
			for (int i = 0; i < 7; i++)
			{
				if (this.FireEffectGameObject[i] != null)
				{
					ParticleManager.Instance.DeSpawn(this.FireEffectGameObject[i]);
				}
				this.FireEffectGameObject[i] = ParticleManager.Instance.Spawn(370, null, new Vector3(array[i, 0], array[i, 1], array[i, 2]), array[i, 3], true, false, true);
				Quaternion localRotation2 = this.FireEffectGameObject[i].transform.localRotation;
				localRotation2.eulerAngles = new Vector3(0f, 180f, 0f);
				this.FireEffectGameObject[i].transform.localRotation = localRotation2;
			}
		}
	}

	// Token: 0x040039EB RID: 14827
	public const int LandWalkerFrontLayer = -30;

	// Token: 0x040039EC RID: 14828
	public const int LandWalkerBackLayer = -60;

	// Token: 0x040039ED RID: 14829
	public const byte ChapterBattle = 200;

	// Token: 0x040039EE RID: 14830
	public const byte ChapterBattleLose = 201;

	// Token: 0x040039EF RID: 14831
	public const byte ChapterBattleWin = 202;

	// Token: 0x040039F0 RID: 14832
	public const ushort WinningPerformTime = 1200;

	// Token: 0x040039F1 RID: 14833
	public const ushort LosingPerformTime = 1200;

	// Token: 0x040039F2 RID: 14834
	public const ushort MinResultTime = 30;

	// Token: 0x040039F3 RID: 14835
	public List<ushort> WalkerMarks;

	// Token: 0x040039F4 RID: 14836
	public WalkerGenData[] WalkerCount;

	// Token: 0x040039F5 RID: 14837
	public ushort[] WalkerGroupIdx;

	// Token: 0x040039F6 RID: 14838
	private LandWalkerData walkerData;

	// Token: 0x040039F7 RID: 14839
	public GameObject WalkerCenter;

	// Token: 0x040039F8 RID: 14840
	public bool enabled;

	// Token: 0x040039F9 RID: 14841
	public LandWalkerManager.WalkerBattleState walkerBattleState;

	// Token: 0x040039FA RID: 14842
	public static LandWalkerManager.WalkerBattleState performState;

	// Token: 0x040039FB RID: 14843
	public static bool StartBattle;

	// Token: 0x040039FC RID: 14844
	public static long LastBattleTime;

	// Token: 0x040039FD RID: 14845
	public static bool isWinning;

	// Token: 0x040039FE RID: 14846
	public long nextPerformTime;

	// Token: 0x040039FF RID: 14847
	public byte CastleLevel;

	// Token: 0x04003A00 RID: 14848
	private List<LandWalker> walkers;

	// Token: 0x04003A01 RID: 14849
	private List<LandWalker> freeWalkers;

	// Token: 0x04003A02 RID: 14850
	public float ActionGap = 1f;

	// Token: 0x04003A03 RID: 14851
	public float nextActionTime;

	// Token: 0x04003A04 RID: 14852
	public int actionChangeTime = 1;

	// Token: 0x04003A05 RID: 14853
	public int BattleTime = 30;

	// Token: 0x04003A06 RID: 14854
	private static LandWalkerManager _instance;

	// Token: 0x04003A07 RID: 14855
	private bool firstUpdate = true;

	// Token: 0x04003A08 RID: 14856
	public GameObject EffectGameObject;

	// Token: 0x04003A09 RID: 14857
	public GameObject[] FireEffectGameObject = new GameObject[7];

	// Token: 0x0200037D RID: 893
	public enum WalkerBattleState
	{
		// Token: 0x04003A0B RID: 14859
		None,
		// Token: 0x04003A0C RID: 14860
		ChangeForBattle,
		// Token: 0x04003A0D RID: 14861
		BattleNow,
		// Token: 0x04003A0E RID: 14862
		ChangeForResult,
		// Token: 0x04003A0F RID: 14863
		BattleLose,
		// Token: 0x04003A10 RID: 14864
		BattleWin,
		// Token: 0x04003A11 RID: 14865
		ChangeBackNormal
	}
}
