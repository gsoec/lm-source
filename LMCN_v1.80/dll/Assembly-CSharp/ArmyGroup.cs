using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200070B RID: 1803
public class ArmyGroup
{
	// Token: 0x06002299 RID: 8857 RVA: 0x00408928 File Offset: 0x00406B28
	protected ArmyGroup()
	{
	}

	// Token: 0x0600229A RID: 8858 RVA: 0x004089B0 File Offset: 0x00406BB0
	public ArmyGroup(EGroupKind groupKind, byte tier, Transform renderRoot, byte side, byte texColor, ushort heroID, byte index, bool hasLord, float scaleFactor = 1f)
	{
		if (ArmyGroup.m_FSMMap == null)
		{
			ArmyGroup.m_FSMMap = new Dictionary<ArmyGroup.EGROUPSTATE, EStateName>();
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.MOVING, EStateName.MOVING);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.RETREAT_MOVING_SPREAD, EStateName.MOVING);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.RETREAT_MOVING, EStateName.MOVING);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.FIGHT, EStateName.TRYFIGHT);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE, EStateName.MELEE_FIGHT_IMMEDIATE);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.IDLE_WITHOUT_CLUMP, EStateName.IDLE_WITHOUT_CLUMP);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.VICTORY, EStateName.VICTORY);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN, EStateName.MOVE_OUTOF_TOWN);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL, EStateName.JUMP_FROM_WALL);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.GO_CAPTIVING, EStateName.GO_CAPTIVING);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.ATTACKER_RUN_AWAY, EStateName.ATTACKER_RUN_AWAY);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.DEFENSER_CHASING, EStateName.DEFENSER_CHASING);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.DEFENSER_RUN_AWAY, EStateName.DEFENSER_RUN_AWAY);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.ATTACKER_CHASING, EStateName.ATTACKER_CHASING);
			ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.IDLE, EStateName.IDLE);
		}
		if (ArmyGroup.FSMMgr == null)
		{
			ArmyGroup.FSMMgr = FSMManager.Instance;
		}
		this.bNpcMode = false;
		if (WarManager.IsNpcModeEnable)
		{
			if (heroID != 0)
			{
				Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(heroID);
				if (recordByKey.HeroKey == heroID && recordByKey.Summary != 0)
				{
					this.bNpcMode = true;
				}
			}
			if (side != 0)
			{
				texColor = 2;
			}
		}
		this.DataIndex = index;
		this.Side = side;
		this.Tier = tier;
		this.GroupKind = groupKind;
		this.TextureColor = texColor;
		GameObject gameObject = new GameObject("ArmyGroup");
		this.groupRoot = gameObject.transform;
		if (FSMManager.Instance.bIsSiegeMode && this.Side == 1)
		{
			this.bAttackMode = false;
		}
		if (groupKind == EGroupKind.Cavalry)
		{
			this.RowCount = 2;
		}
		else if (groupKind == EGroupKind.Catapults)
		{
			this.RowCount = 1;
			this.hitPointOffset.y = 1.5f;
		}
		else if (groupKind == EGroupKind.Archer)
		{
			this.hitPointOffset.y = 1f;
		}
		int num = (int)(groupKind - EGroupKind.Infantry);
		this.MoveSpeed = ArmyGroup.ConstSoldierSpeed[num];
		if (!this.bNpcMode)
		{
			this.SoldierCount = (int)ArmyGroup.ConstSoldierCount[num];
			this.CurrentSoldierCount = (int)ArmyGroup.ConstSoldierCount[num];
			this.SoldierCountDefault = this.SoldierCount;
			this.soldierArray = new Vector3[this.SoldierCount];
			this.soldiers = new Soldier[this.SoldierCount];
			this.setupSoldierArray(groupKind);
		}
		else
		{
			this.SoldierCount = 1;
			this.CurrentSoldierCount = 1;
			this.SoldierCountDefault = 1;
			this.soldierArray = new Vector3[this.SoldierCount];
			this.soldiers = new Soldier[this.SoldierCount];
			this.soldierArray[0] = Vector3.zero;
		}
		int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
		int num2 = 2 + sceneLightmapSize;
		this.groupRoot.localScale = new Vector3(scaleFactor * 1f, scaleFactor * 1f, scaleFactor * 1f);
		for (int i = 0; i < this.SoldierCount; i++)
		{
			this.soldiers[i] = new Soldier((byte)groupKind, tier, texColor);
			GameObject gameObject2 = this.soldiers[i].gameObject;
			this.soldiers[i].renderer.lightmapIndex = num2;
			this.soldiers[i].Parent = this;
			this.soldiers[i].Index = (ushort)i;
			this.soldiers[i].FSMController = ArmyGroup.FSMMgr.getState(EStateName.IDLE);
			this.soldiers[i].pListener = new Soldier.ParentListener(this.SoldierCallBack);
			gameObject2.transform.parent = renderRoot;
			Vector3 position = this.targetPosition + this.groupRoot.TransformPoint(this.soldierArray[i]);
			gameObject2.transform.position = position;
			gameObject2.transform.rotation = Quaternion.LookRotation(this.groupRoot.forward);
			gameObject2.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
			if (this.bNpcMode)
			{
				this.soldiers[i].renderer.enabled = false;
				this.soldiers[i].EnableShadow = false;
			}
		}
		this.lightmapIndex = num2;
		if (heroID != 0)
		{
			this.heroSoldier = new Lord(heroID, (byte)groupKind, tier, this.Side, hasLord, this.DataIndex);
			this.heroSoldier.renderer.lightmapIndex = 255;
			this.heroSoldier.Parent = this;
			this.heroSoldier.Index = 255;
			this.heroSoldier.transform.parent = renderRoot;
			this.heroSoldier.transform.position = this.groupRoot.TransformPoint(this.HeroOffset);
			this.heroSoldier.FSMController = ArmyGroup.FSMMgr.getState(EStateName.IDLE);
			this.HasHeroDisplay = true;
		}
		this.m_State = ArmyGroup.EGROUPSTATE.IDLE;
	}

	// Token: 0x170000C2 RID: 194
	// (get) Token: 0x0600229C RID: 8860 RVA: 0x00408FA8 File Offset: 0x004071A8
	// (set) Token: 0x0600229D RID: 8861 RVA: 0x00408FB0 File Offset: 0x004071B0
	public ArmyGroup.EGROUPSTATE State
	{
		get
		{
			return this.m_State;
		}
		set
		{
			this.m_State = value;
		}
	}

	// Token: 0x170000C3 RID: 195
	// (get) Token: 0x0600229E RID: 8862 RVA: 0x00408FBC File Offset: 0x004071BC
	// (set) Token: 0x0600229F RID: 8863 RVA: 0x00408FC4 File Offset: 0x004071C4
	public bool HasLord
	{
		get
		{
			return this.hasLord;
		}
		set
		{
			this.hasLord = value;
			if (this.heroSoldier != null)
			{
				this.heroSoldier.IsLord = value;
			}
		}
	}

	// Token: 0x170000C4 RID: 196
	// (get) Token: 0x060022A0 RID: 8864 RVA: 0x00408FE4 File Offset: 0x004071E4
	public Vector3 CurrentHitPoint
	{
		get
		{
			return this.groupRoot.position + this.hitPointOffset;
		}
	}

	// Token: 0x170000C5 RID: 197
	// (get) Token: 0x060022A1 RID: 8865 RVA: 0x00408FFC File Offset: 0x004071FC
	// (set) Token: 0x060022A2 RID: 8866 RVA: 0x00409004 File Offset: 0x00407204
	public virtual int MaxHP
	{
		get
		{
			return this.m_HP;
		}
		set
		{
			this.m_HP = value;
			this.m_CurHP = this.m_HP;
			this.HpDefault = this.m_HP;
			if (!this.bNpcMode && this.m_HP < (int)ArmyGroup.ConstSoldierCount[(int)(this.GroupKind - EGroupKind.Infantry)])
			{
				this.SoldierCount = this.m_HP;
				for (int i = this.SoldierCount; i < this.SoldierCountDefault; i++)
				{
					this.soldiers[i].gameObject.SetActive(false);
				}
				this.SoldierCountDefault = this.SoldierCount;
				this.CurrentSoldierCount = this.SoldierCount;
			}
		}
	}

	// Token: 0x170000C6 RID: 198
	// (get) Token: 0x060022A3 RID: 8867 RVA: 0x004090A8 File Offset: 0x004072A8
	public virtual int CurHP
	{
		get
		{
			return this.m_CurHP;
		}
	}

	// Token: 0x170000C7 RID: 199
	// (set) Token: 0x060022A4 RID: 8868 RVA: 0x004090B0 File Offset: 0x004072B0
	public virtual int GotHurt
	{
		set
		{
			this.m_CurHP -= value;
			this.m_CurHP = Mathf.Max(this.m_CurHP, 0);
			if (this.CurrentSoldierCount > 1)
			{
				int num = this.SoldierCountDefault - 1;
				this.CurrentSoldierCount = (int)((float)this.m_CurHP / (float)this.m_HP * (float)num) + 1;
			}
		}
	}

	// Token: 0x170000C8 RID: 200
	// (get) Token: 0x060022A5 RID: 8869 RVA: 0x00409110 File Offset: 0x00407310
	// (set) Token: 0x060022A6 RID: 8870 RVA: 0x00409118 File Offset: 0x00407318
	public virtual WarParticleManager particleManager
	{
		get
		{
			return this.particleMgr;
		}
		set
		{
			this.particleMgr = value;
			if (this.heroSoldier != null && this.hasLord)
			{
				ushort effID = (this.TextureColor != 0) ? 2017 : 2014;
				this.particleMgr.Spawn(effID, this.heroSoldier.transform, Vector3.zero, 1f, true, true);
			}
		}
	}

	// Token: 0x170000C9 RID: 201
	// (get) Token: 0x060022A7 RID: 8871 RVA: 0x00409184 File Offset: 0x00407384
	public Vector3 HeroOffset
	{
		get
		{
			return (!this.bNpcMode) ? ArmyGroup.ConstHeroOffset : Vector3.zero;
		}
	}

	// Token: 0x060022A8 RID: 8872 RVA: 0x004091A0 File Offset: 0x004073A0
	private byte getRandowPos()
	{
		int index = UnityEngine.Random.Range(0, ArmyGroup.RandomPosList.Count);
		byte result = ArmyGroup.RandomPosList[index];
		ArmyGroup.RandomPosList.RemoveAt(index);
		return result;
	}

	// Token: 0x060022A9 RID: 8873 RVA: 0x004091D8 File Offset: 0x004073D8
	private void setupSoldierArray(EGroupKind groupKind)
	{
		Vector3 zero = Vector3.zero;
		if (groupKind == EGroupKind.Cavalry)
		{
			float num = 1f;
			zero.Set(-num, 0f, num);
			this.soldierArray[0] = zero;
			zero.Set(num, 0f, num);
			this.soldierArray[1] = zero;
			zero.Set(-num * 3f, 0f, -num);
			this.soldierArray[2] = zero;
			zero.Set(num * 3f, 0f, -num);
			this.soldierArray[3] = zero;
			zero.Set(-num * 3f, 0f, -num * 3.5f);
			this.soldierArray[4] = zero;
			zero.Set(num * 3f, 0f, -num * 3.5f);
			this.soldierArray[5] = zero;
		}
		else if (groupKind == EGroupKind.Catapults)
		{
			zero.Set(0f, 0f, 0f);
			this.soldierArray[0] = zero;
		}
		else if (groupKind == EGroupKind.Archer)
		{
			ArmyGroup.RandomPosList.Clear();
			for (byte b = 0; b < 9; b += 1)
			{
				ArmyGroup.RandomPosList.Add(b);
			}
			float num2 = 1.5f;
			zero.Set(0f, 0f, 0f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(-num2, 0f, -num2 * 1f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(0f, 0f, -num2 * 1f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(num2, 0f, -num2 * 1f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(-num2, 0f, -num2 * 2f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(0f, 0f, -num2 * 2f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(num2, 0f, -num2 * 2f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(-num2, 0f, -num2 * 3f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(num2, 0f, -num2 * 3f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
		}
		else
		{
			ArmyGroup.RandomPosList.Clear();
			for (byte b2 = 0; b2 < 12; b2 += 1)
			{
				ArmyGroup.RandomPosList.Add(b2);
			}
			float num3 = 1.5f;
			float num4 = 1.8f;
			zero.Set(0f, 0f, num3);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(-num3, 0f, 0f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(0f, 0f, 0f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(num3, 0f, 0f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(-num3, 0f, -num4 * 1f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(0f, 0f, -num4 * 1f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(num3, 0f, -num4 * 1f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(-num3, 0f, -num4 * 2f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(0f, 0f, -num4 * 2f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(num3, 0f, -num4 * 2f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(-num3, 0f, -num4 * 3f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
			zero.Set(num3, 0f, -num4 * 3f);
			this.soldierArray[(int)this.getRandowPos()] = zero;
		}
	}

	// Token: 0x060022AA RID: 8874 RVA: 0x00409750 File Offset: 0x00407950
	public virtual void Destroy()
	{
		this.soldierArray = null;
		this.Target = null;
		if (this.heroSoldier != null)
		{
			if (!this.heroSoldier.gameObject.activeSelf)
			{
				this.heroSoldier.gameObject.SetActive(true);
			}
			this.heroSoldier.Destroy();
			this.heroSoldier = null;
		}
		if (this.groupRoot != null)
		{
			UnityEngine.Object.Destroy(this.groupRoot.gameObject);
			this.groupRoot = null;
		}
		if (this.soldiers != null)
		{
			for (int i = 0; i < this.soldiers.Length; i++)
			{
				if (this.soldiers[i] != null)
				{
					this.soldiers[i].Destroy();
					this.soldiers[i] = null;
				}
			}
		}
	}

	// Token: 0x060022AB RID: 8875 RVA: 0x00409820 File Offset: 0x00407A20
	public virtual void Update(float deltaTime, float moveDeltaTime)
	{
		if (this.SoldierCount == 0)
		{
			if (this.heroSoldier != null)
			{
				this.heroSoldier.FSMController.Update(this.heroSoldier, this, deltaTime);
			}
			return;
		}
		this.checkMove(moveDeltaTime);
		FSMUnit fsmunit = null;
		if (this.ForceEnterFSM || this.lastState != this.m_State)
		{
			EStateName name = ArmyGroup.m_FSMMap[this.m_State];
			fsmunit = ArmyGroup.FSMMgr.getState(name);
			if (this.m_State == ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN || this.m_State == ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL)
			{
				this.bAttackMode = true;
			}
			else if (((WarManager.IsNpcModeEnable && this.Side != 0) || !this.hasLord) && (this.m_State == ArmyGroup.EGROUPSTATE.ATTACKER_RUN_AWAY || this.m_State == ArmyGroup.EGROUPSTATE.DEFENSER_RUN_AWAY))
			{
				this.LordRunAway(this.m_State == ArmyGroup.EGROUPSTATE.ATTACKER_RUN_AWAY);
			}
			this.ForceEnterFSM = false;
		}
		int num = this.SoldierCountDefault - this.CurrentSoldierCount;
		if (num != this.DeadCount)
		{
			int num2 = num - this.DeadCount;
			if (num2 > 5)
			{
			}
			this.DeadCount = num;
		}
		for (int i = 0; i < this.SoldierCount; i++)
		{
			if (i >= this.CurrentSoldierCount)
			{
				EStateName curFSM = this.soldiers[i].CurFSM;
				if (curFSM != EStateName.DIE && curFSM != EStateName.DYING)
				{
					this.soldiers[i].Flag = 2;
					if (this.AttackBy != null)
					{
						this.soldiers[i].Target = ((this.AttackBy.heroSoldier == null) ? this.AttackBy.soldiers[0] : this.AttackBy.heroSoldier);
					}
					else
					{
						this.soldiers[i].Target = null;
					}
					this.soldiers[i].FSMController = ArmyGroup.FSMMgr.getState(EStateName.DYING);
				}
			}
			else if (fsmunit != null)
			{
				this.soldiers[i].FSMController = fsmunit;
			}
			this.soldiers[i].FSMController.Update(this.soldiers[i], this, deltaTime);
			this.soldiers[i].Update(deltaTime);
		}
		if (this.heroSoldier != null)
		{
			if (!this.bAttackMode && this.hasLord)
			{
				this.SiegeModeDefenserLordRun(deltaTime);
			}
			else
			{
				if (this.CurrentSoldierCount != 0 && fsmunit != null && this.m_State != ArmyGroup.EGROUPSTATE.ATTACKER_RUN_AWAY && this.m_State != ArmyGroup.EGROUPSTATE.DEFENSER_RUN_AWAY)
				{
					if (this.heroSoldier.IsLord && this.m_State == ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN)
					{
						this.heroSoldier.FSMController = FSMManager.Instance.getState(EStateName.JUMP_FROM_WALL);
					}
					else
					{
						this.heroSoldier.FSMController = fsmunit;
					}
				}
				this.heroSoldier.FSMController.Update(this.heroSoldier, this, deltaTime);
				this.heroSoldier.Update(deltaTime);
			}
		}
		if (this.bInsideSkill)
		{
			if (this.heroSoldier != null)
			{
				((Lord)this.heroSoldier).bExtraScaleWork = false;
			}
			this.bInsideSkill = false;
		}
		this.OnceFlag = 0u;
		this.AttackBy = null;
		this.lastState = this.m_State;
	}

	// Token: 0x060022AC RID: 8876 RVA: 0x00409B74 File Offset: 0x00407D74
	public virtual void Reset()
	{
		this.CurrentSoldierCount = this.SoldierCountDefault;
		this.SoldierCount = this.SoldierCountDefault;
		this.DeadCount = 0;
		for (int i = 0; i < this.SoldierCount; i++)
		{
			if (!this.soldiers[i].gameObject.activeSelf)
			{
				this.soldiers[i].gameObject.SetActive(true);
			}
			Vector3 position = this.groupRoot.TransformPoint(this.soldierArray[i]);
			this.soldiers[i].transform.position = position;
			this.soldiers[i].transform.rotation = Quaternion.LookRotation(this.groupRoot.forward);
			this.soldiers[i].Reset();
		}
		if (this.heroSoldier != null)
		{
			this.heroSoldier.gameObject.SetActive(true);
			this.heroSoldier.transform.position = this.groupRoot.TransformPoint(this.HeroOffset);
			this.heroSoldier.ResetAnimSettingToDefault();
			this.heroSoldier.ResetAnimToIdle();
			this.heroSoldier.Reset();
		}
		this.CommonFlag = 0u;
		this.OnceFlag = 0u;
		this.m_State = ArmyGroup.EGROUPSTATE.IDLE;
	}

	// Token: 0x060022AD RID: 8877 RVA: 0x00409CB4 File Offset: 0x00407EB4
	private bool checkMove(float moveDeltaTime)
	{
		if (this.m_State == ArmyGroup.EGROUPSTATE.MOVING)
		{
			if (this.Target == null)
			{
				ArmyGroup.Vec3Instance = this.targetPosition;
			}
			else if (this.Target.GroupKind == EGroupKind.CastleGate)
			{
				ArmyGroup.Vec3Instance = this.targetPosition;
			}
			else
			{
				ArmyGroup.Vec3Instance = this.Target.groupRoot.position;
			}
			if (this.Target != null && this.Target.GroupKind == EGroupKind.CastleGate && (this.GroupKind == EGroupKind.Infantry || this.GroupKind == EGroupKind.Cavalry) && GameConstants.DistanceSquare(this.groupRoot.position, ArmyGroup.Vec3Instance) < 64f)
			{
				this.Attack(this.Target, false, 0);
			}
			else
			{
				if (this.Target == null || (this.GroupKind != EGroupKind.Infantry && this.GroupKind != EGroupKind.Cavalry) || GameConstants.DistanceSquare(this.groupRoot.position, ArmyGroup.Vec3Instance) >= 144f)
				{
					if (this.m_lastTargetPos != ArmyGroup.Vec3Instance)
					{
						this.updateDirection(ArmyGroup.Vec3Instance);
					}
					this.groupRoot.position = GameConstants.MoveTowards(this.groupRoot.position, ArmyGroup.Vec3Instance, this.MoveSpeed * moveDeltaTime);
					this.groupRoot.rotation = this.m_Direction;
					return true;
				}
				this.Attack(this.Target, false, 0);
			}
		}
		else
		{
			if (this.m_State == ArmyGroup.EGROUPSTATE.RETREAT_MOVING_SPREAD)
			{
				if (this.m_lastTargetPos != this.targetPosition)
				{
					this.updateDirection(this.targetPosition);
				}
				this.groupRoot.position = GameConstants.MoveTowards(this.groupRoot.position, this.targetPosition, this.MoveSpeed * moveDeltaTime);
				this.groupRoot.rotation = this.m_Direction;
				if (GameConstants.DistanceSquare(this.targetPosition, this.groupRoot.position) <= 0.001f)
				{
					this.targetPosition.x = ((this.Side != 1) ? 1000f : -1000f);
					this.m_State = ArmyGroup.EGROUPSTATE.RETREAT_MOVING;
					Quaternion quaternion = Quaternion.LookRotation(this.targetPosition - this.groupRoot.position);
					if (this.m_Direction != quaternion)
					{
						this.m_Direction = quaternion;
					}
					this.groupRoot.rotation = this.m_Direction;
					for (int i = 0; i < this.SoldierCount; i++)
					{
						this.soldiers[i].ActionMode = EActionMode.Personal;
					}
				}
				return true;
			}
			if (this.m_State == ArmyGroup.EGROUPSTATE.RETREAT_MOVING)
			{
				this.groupRoot.position = GameConstants.MoveTowards(this.groupRoot.position, this.targetPosition, this.MoveSpeed * moveDeltaTime);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060022AE RID: 8878 RVA: 0x00409F94 File Offset: 0x00408194
	public virtual void Attack(ArmyGroup target, bool bForceRetarget = false, byte param = 0)
	{
		if (this.Target != target)
		{
			bForceRetarget = true;
		}
		if (this.lastState == ArmyGroup.EGROUPSTATE.FIGHT && !bForceRetarget && param == 0)
		{
			this.OnceFlag |= 1u;
			if (this.Target == null)
			{
				this.Target = target;
			}
			return;
		}
		this.OnceFlag |= 1u;
		this.Target = target;
		this.m_State = ((param == 0) ? ArmyGroup.EGROUPSTATE.FIGHT : ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE);
		if (target.GroupKind == EGroupKind.Infantry || target.GroupKind == EGroupKind.Cavalry)
		{
			this.CenterWithTarget = this.groupRoot.position + (target.groupRoot.position - this.groupRoot.position) / 2f;
		}
		else if (target.GroupKind == EGroupKind.CastleGate)
		{
			float x = 52f - this.soldiers[0].AttackRadius;
			Vector3 a = new Vector3(x, 0f, this.groupRoot.position.z);
			this.CenterWithTarget = this.groupRoot.position + (a - this.groupRoot.position) / 2f;
		}
		else
		{
			this.CenterWithTarget = target.groupRoot.position;
		}
		if (bForceRetarget)
		{
			this.lastState = ArmyGroup.EGROUPSTATE.IDLE;
			for (int i = 0; i < this.CurrentSoldierCount; i++)
			{
				this.soldiers[i].ActionMode = EActionMode.Personal;
				this.soldiers[i].ResetTarget(true);
			}
			if (this.heroSoldier != null)
			{
				this.heroSoldier.ActionMode = EActionMode.Personal;
				this.heroSoldier.ResetTarget(false);
			}
		}
	}

	// Token: 0x060022AF RID: 8879 RVA: 0x0040A154 File Offset: 0x00408354
	public void PlaySkill(ushort skillID, ArmyGroup target)
	{
		this.Target = target;
		this.m_State = ArmyGroup.EGROUPSTATE.FIGHT;
		if (this.heroSoldier != null)
		{
			Lord lord = (Lord)this.heroSoldier;
			lord.PlaySkillAnim(skillID);
			this.particleMgr.Spawn(2009, lord.GetHitPointTrans(), Vector3.zero, 1f, true, true);
			AudioManager.Instance.PlaySFX(40039, 0f, PitchKind.NoPitch, lord.modelTrans, null);
			this.bInsideSkill = true;
		}
	}

	// Token: 0x060022B0 RID: 8880 RVA: 0x0040A1DC File Offset: 0x004083DC
	public virtual void AllDie(int param = 0)
	{
		this.CurrentSoldierCount = 0;
		if (this.heroSoldier != null)
		{
			this.heroSoldier.FSMController = FSMManager.Instance.getState(EStateName.LORD_DYING);
		}
	}

	// Token: 0x060022B1 RID: 8881 RVA: 0x0040A208 File Offset: 0x00408408
	public Vector3 GetBloodBarPos()
	{
		return (!this.bNpcMode || this.heroSoldier == null) ? this.soldiers[0].transform.position : this.heroSoldier.transform.position;
	}

	// Token: 0x060022B2 RID: 8882 RVA: 0x0040A248 File Offset: 0x00408448
	private Vector3 GetRandVector3(float max)
	{
		return new Vector3(UnityEngine.Random.Range(0f, max), UnityEngine.Random.Range(0f, max), UnityEngine.Random.Range(0f, max));
	}

	// Token: 0x060022B3 RID: 8883 RVA: 0x0040A27C File Offset: 0x0040847C
	public virtual void FireRange(ArmyGroup targetGroup, FlyingObjectManager mgr, FOKind kind, float ms, ushort skillID, byte param = 0)
	{
		ushort num = this.heroSoldierFO;
		if (skillID <= 7 && this.soldiers != null && !this.bNpcMode)
		{
			for (int i = 0; i < this.CurrentSoldierCount; i++)
			{
				Soldier soldier = this.soldiers[i];
				if (targetGroup.GroupKind != EGroupKind.CastleGate)
				{
					Transform end = (soldier.Target == null) ? targetGroup.groupRoot : soldier.Target.transform;
					mgr.addFlyingObject(kind, soldier.RangeFirePoint, end, ms, new Vector3(0f, 1f, 0f), null, ChaseType.CurveA, null);
				}
				else
				{
					float y = UnityEngine.Random.Range(5f, 10f);
					Vector3 vector = new Vector3(-3f, y, soldier.transform.position.z - 15f) + this.GetRandVector3(2f);
					mgr.addFlyingObject(kind, soldier.RangeFirePoint, this.Target.groupRoot, ms, vector, null, ChaseType.CurveA, null);
					if (soldier.hitParticleCount < 2)
					{
						soldier.hitParticlePos[(int)soldier.hitParticleCount] = this.Target.groupRoot.position + vector;
						Soldier soldier2 = soldier;
						soldier2.hitParticleCount += 1;
					}
				}
			}
		}
		if (this.heroSoldier != null)
		{
			Soldier soldier3 = this.heroSoldier;
			Transform modelTrans = ((Lord)this.heroSoldier).modelTrans;
			bool flag = !this.bAttackMode && this.hasLord;
			if (targetGroup.GroupKind != EGroupKind.CastleGate)
			{
				if (skillID <= 7 && this.heroSoldierFO != 0 && this.GroupKind != EGroupKind.Catapults && !flag)
				{
					Transform end2 = (soldier3.Target == null) ? targetGroup.groupRoot : soldier3.Target.transform;
					mgr.addFlyingObject((FOKind)(this.heroSoldierFO - 1), soldier3.RangeFirePoint, end2, ms, new Vector3(0f, 1f, 0f), modelTrans, ChaseType.CurveA, null);
				}
				else if (skillID > 7 && this.heroSoldierSkillFO != 0)
				{
					Transform end3 = (soldier3.Target == null) ? targetGroup.groupRoot : soldier3.Target.transform;
					Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
					GameObject gameObject = this.particleManager.Spawn(this.heroSoldierSkillFO, null, Vector3.zero, 1f, true, false);
					if (gameObject != null)
					{
						ChaseType curveType = (recordByKey.FlyType != 1) ? ChaseType.Straight : ChaseType.CurveA;
						mgr.addFlyingObject(FOKind.FreeParticle, soldier3.RangeFirePoint, end3, ms, new Vector3(0f, 1f, 0f), modelTrans, curveType, gameObject);
					}
				}
			}
			else if (skillID <= 7 && this.heroSoldierFO != 0)
			{
				float y2 = UnityEngine.Random.Range(5f, 10f);
				Vector3 vector2 = new Vector3(-3f, y2, soldier3.transform.position.z - 15f);
				mgr.addFlyingObject((FOKind)(this.heroSoldierFO - 1), soldier3.RangeFirePoint, this.Target.groupRoot, ms, vector2, modelTrans, ChaseType.CurveA, null);
				if (soldier3.hitParticleCount < 2)
				{
					soldier3.hitParticlePos[(int)soldier3.hitParticleCount] = this.Target.groupRoot.position + vector2;
					Soldier soldier4 = soldier3;
					soldier4.hitParticleCount += 1;
				}
			}
			else if (skillID > 7 && this.heroSoldierSkillFO != 0)
			{
				float y3 = UnityEngine.Random.Range(5f, 10f);
				Vector3 b = new Vector3(-3f, y3, soldier3.transform.position.z - 15f);
				Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
				GameObject gameObject2 = this.particleManager.Spawn(this.heroSoldierSkillFO, null, Vector3.zero, 1f, true, false);
				if (gameObject2 != null)
				{
					ChaseType curveType2 = (recordByKey2.FlyType != 1) ? ChaseType.Straight : ChaseType.CurveA;
					mgr.addFlyingObject(FOKind.FreeParticle, soldier3.RangeFirePoint, this.Target.groupRoot, ms, new Vector3(0f, 1f, 0f), modelTrans, curveType2, gameObject2);
				}
				if (soldier3.hitParticleCount < 2)
				{
					soldier3.hitParticlePos[(int)soldier3.hitParticleCount] = this.Target.groupRoot.position + b;
					Soldier soldier5 = soldier3;
					soldier5.hitParticleCount += 1;
				}
			}
		}
	}

	// Token: 0x060022B4 RID: 8884 RVA: 0x0040A754 File Offset: 0x00408954
	public void updateDirection(Vector3 curTargetPos)
	{
		this.m_lastTargetPos = curTargetPos;
		this.m_lastTargetPos.y = 0f;
		Vector3 vector = this.m_lastTargetPos - this.groupRoot.position;
		if (vector != Vector3.zero)
		{
			this.m_Direction = Quaternion.LookRotation(vector);
		}
	}

	// Token: 0x060022B5 RID: 8885 RVA: 0x0040A7AC File Offset: 0x004089AC
	public void Move(ArmyGroup target)
	{
		this.Target = target;
		if (this.Target != null)
		{
			Vector3 position;
			if (target.GroupKind == EGroupKind.CastleGate)
			{
				position = new Vector3(52f, 0f, this.groupRoot.position.z);
			}
			else
			{
				position = this.Target.groupRoot.position;
			}
			this.targetPosition = position;
			Quaternion quaternion = Quaternion.LookRotation(this.targetPosition - this.groupRoot.position);
			if (this.m_Direction != quaternion)
			{
				this.m_Direction = quaternion;
			}
			this.groupRoot.rotation = this.m_Direction;
			for (int i = 0; i < this.SoldierCount; i++)
			{
				if (this.soldiers[i].CurFSM != EStateName.DYING)
				{
					this.soldiers[i].ActionMode = EActionMode.Personal;
					this.soldiers[i].ResetTarget(true);
				}
			}
			if (this.heroSoldier != null)
			{
				this.heroSoldier.ActionMode = EActionMode.Personal;
				this.heroSoldier.ResetTarget(false);
			}
			this.m_State = ArmyGroup.EGROUPSTATE.MOVING;
		}
	}

	// Token: 0x060022B6 RID: 8886 RVA: 0x0040A8D0 File Offset: 0x00408AD0
	public void Move(Vector3 target, bool bRetreat = false)
	{
		this.Target = null;
		this.targetPosition = target;
		Quaternion quaternion = Quaternion.LookRotation(this.targetPosition - this.groupRoot.position);
		if (this.m_Direction != quaternion)
		{
			this.m_Direction = quaternion;
		}
		this.groupRoot.rotation = this.m_Direction;
		for (int i = 0; i < this.SoldierCount; i++)
		{
			this.soldiers[i].ActionMode = EActionMode.Personal;
			this.soldiers[i].ResetTarget(true);
		}
		if (this.heroSoldier != null)
		{
			this.heroSoldier.ActionMode = EActionMode.Personal;
			this.heroSoldier.ResetTarget(false);
		}
		if (bRetreat)
		{
			this.m_State = ArmyGroup.EGROUPSTATE.RETREAT_MOVING_SPREAD;
		}
		else
		{
			this.m_State = ArmyGroup.EGROUPSTATE.MOVING;
		}
	}

	// Token: 0x060022B7 RID: 8887 RVA: 0x0040A9A0 File Offset: 0x00408BA0
	public void setPosition(Vector3 pos, Vector3 faceTo, byte heroOffsetType = 0)
	{
		Quaternion rotation = Quaternion.LookRotation(faceTo - pos);
		this.groupRoot.transform.position = pos;
		this.groupRoot.transform.rotation = rotation;
		for (int i = 0; i < this.SoldierCount; i++)
		{
			Vector3 position = this.groupRoot.TransformPoint(this.soldierArray[i]);
			position.y = pos.y;
			this.soldiers[i].transform.position = position;
			this.soldiers[i].transform.rotation = rotation;
		}
		if (this.heroSoldier != null)
		{
			Vector3 position2 = (heroOffsetType != 0) ? Vector3.zero : this.HeroOffset;
			this.heroSoldier.transform.position = this.groupRoot.TransformPoint(position2);
			this.heroSoldier.transform.rotation = rotation;
		}
	}

	// Token: 0x060022B8 RID: 8888 RVA: 0x0040AA94 File Offset: 0x00408C94
	public void setPosition(float posX, float posY)
	{
		this.groupRoot.transform.position = new Vector3(posX, 0f, posY);
	}

	// Token: 0x060022B9 RID: 8889 RVA: 0x0040AAB4 File Offset: 0x00408CB4
	public void setPositionInstantlyIgnoreHeroAndAxisY(float posX, float posY, Vector3 faceTo)
	{
		Quaternion rotation = Quaternion.LookRotation(faceTo);
		this.groupRoot.transform.rotation = rotation;
		this.setPosition(posX, posY);
		for (int i = 0; i < this.SoldierCount; i++)
		{
			Vector3 position = this.groupRoot.TransformPoint(this.soldierArray[i]);
			this.soldiers[i].transform.position = position;
			this.soldiers[i].transform.rotation = rotation;
		}
	}

	// Token: 0x060022BA RID: 8890 RVA: 0x0040AB3C File Offset: 0x00408D3C
	public void setPositionAndMove(float posX, float posY)
	{
		this.setPosition(posX, posY);
		for (int i = 0; i < this.SoldierCount; i++)
		{
			this.soldiers[i].ActionMode = EActionMode.Personal;
			this.soldiers[i].FSMController.Enter(this.soldiers[i]);
		}
	}

	// Token: 0x060022BB RID: 8891 RVA: 0x0040AB90 File Offset: 0x00408D90
	public Vector3 getTransformPoint(int idx)
	{
		if (idx == 255)
		{
			return this.groupRoot.TransformPoint(this.HeroOffset);
		}
		return this.groupRoot.TransformPoint(this.soldierArray[idx]);
	}

	// Token: 0x060022BC RID: 8892 RVA: 0x0040ABD8 File Offset: 0x00408DD8
	public void resetLightmap(int curLightmapIdx)
	{
		if (this.lightmapIndex != curLightmapIdx)
		{
			int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
			int num = 1 + sceneLightmapSize;
			if (curLightmapIdx == num)
			{
				int num2 = 2 + sceneLightmapSize;
				for (int i = 0; i < this.SoldierCount; i++)
				{
					int num3 = (this.soldiers[i].CurAnim != ESheetMeshAnim.die) ? num : num2;
					this.soldiers[i].renderer.lightmapIndex = num3;
				}
				if (this.heroSoldier != null)
				{
					this.heroSoldier.renderer.lightmapIndex = num;
				}
			}
			else
			{
				for (int j = 0; j < this.SoldierCount; j++)
				{
					this.soldiers[j].renderer.lightmapIndex = curLightmapIdx;
				}
				if (this.heroSoldier != null)
				{
					this.heroSoldier.renderer.lightmapIndex = 255;
				}
			}
			this.lightmapIndex = curLightmapIdx;
		}
	}

	// Token: 0x060022BD RID: 8893 RVA: 0x0040ACCC File Offset: 0x00408ECC
	public void SoldierCallBack(int idx, int param)
	{
		if (this.m_State == ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL || this.m_State == ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN)
		{
			this.SoldierFlagCount++;
			if (this.SoldierFlagCount >= this.CurrentSoldierCount && (this.CommonFlag & 1u) != 0u)
			{
				this.CommonFlag ^= 1u;
			}
		}
	}

	// Token: 0x060022BE RID: 8894 RVA: 0x0040AD2C File Offset: 0x00408F2C
	public void SiegeModeDefenserLordInit()
	{
		this.heroSoldier.transform.position = new Vector3(55f, 7.6f, 15f);
		this.heroSoldier.LordAnimSetting(0);
		this.CommonTimer = (float)UnityEngine.Random.Range(2, 6);
		this.heroSoldier.PlayAnim(ESheetMeshAnim.idle, SAWrapMode.Loop, true, false, false);
	}

	// Token: 0x060022BF RID: 8895 RVA: 0x0040AD88 File Offset: 0x00408F88
	public void SiegeModeDefenserLordRun(float deltaTime)
	{
		if (this.CommonTimer > 0f)
		{
			this.CommonTimer -= deltaTime;
			if (this.CommonTimer <= 0f && this.GroupKind != EGroupKind.Archer && this.GroupKind != EGroupKind.Catapults)
			{
				this.heroSoldier.PlayAnim(ESheetMeshAnim.victory, SAWrapMode.Default, true, false, false);
			}
		}
		else
		{
			Animation animComponent = this.heroSoldier.getAnimComponent();
			if (animComponent != null)
			{
				float time = animComponent["victory"].time;
				if (time <= 0f)
				{
					this.CommonTimer = (float)UnityEngine.Random.Range(2, 6);
				}
			}
		}
		this.heroSoldier.Update(deltaTime);
	}

	// Token: 0x060022C0 RID: 8896 RVA: 0x0040AE40 File Offset: 0x00409040
	public void setLordAnimEnable(bool bEnable)
	{
		if (this.heroSoldier != null)
		{
			Animation animComponent = this.heroSoldier.getAnimComponent();
			if (animComponent != null)
			{
				float speed = (!bEnable) ? 0f : 1f;
				if (this.heroSoldier.lastAnim == ESheetMeshAnim.die)
				{
					animComponent["daze"].speed = speed;
				}
				else if (this.heroSoldier.lastAnim == ESheetMeshAnim.attack)
				{
					if (!bEnable)
					{
						animComponent["attack"].speed = 0f;
					}
					else
					{
						float num = (float)DataManager.Instance.HeroTable.GetRecordByKey(this.heroSoldierID).HeroAttackInfo[0].HitTime;
						float speed2 = num * Soldier.ARCHER_HITTIME_INVERSE;
						animComponent["attack"].speed = speed2;
					}
				}
				else
				{
					animComponent[this.heroSoldier.lastAnim.ToString()].speed = speed;
				}
				animComponent["idle"].speed = speed;
				animComponent["moving"].speed = speed;
			}
		}
	}

	// Token: 0x060022C1 RID: 8897 RVA: 0x0040AF6C File Offset: 0x0040916C
	public void BeforeDeadDisable()
	{
	}

	// Token: 0x060022C2 RID: 8898 RVA: 0x0040AF70 File Offset: 0x00409170
	public void LordRunAway(bool bAttacker)
	{
		if (this.heroSoldier != null && ((this.heroSoldier.IsLord && (!WarManager.IsNpcModeEnable || this.Side == 0)) || (this.heroSoldier.CurFSM != EStateName.LORD_DYING && this.heroSoldier.CurFSM != EStateName.DIE)))
		{
			Animation animComponent = this.heroSoldier.getAnimComponent();
			if (animComponent != null)
			{
				animComponent["moving"].layer = 1;
			}
			if (bAttacker)
			{
				this.heroSoldier.FSMController = FSMManager.Instance.getState(EStateName.ATTACKER_RUN_AWAY);
			}
			else
			{
				this.heroSoldier.FSMController = FSMManager.Instance.getState(EStateName.DEFENSER_RUN_AWAY);
			}
		}
	}

	// Token: 0x04006BA8 RID: 27560
	public int RowCount = 3;

	// Token: 0x04006BA9 RID: 27561
	public int SoldierCount = 9;

	// Token: 0x04006BAA RID: 27562
	public int CurrentSoldierCount = 9;

	// Token: 0x04006BAB RID: 27563
	public int SoldierCountDefault;

	// Token: 0x04006BAC RID: 27564
	public int DeadCount;

	// Token: 0x04006BAD RID: 27565
	public Vector3 targetPosition = Vector3.zero;

	// Token: 0x04006BAE RID: 27566
	protected Vector3 m_lastTargetPos;

	// Token: 0x04006BAF RID: 27567
	public byte TextureColor;

	// Token: 0x04006BB0 RID: 27568
	protected static Vector3 Vec3Instance = Vector3.zero;

	// Token: 0x04006BB1 RID: 27569
	protected static Quaternion QuatInstance = new Quaternion(0f, 0f, 0f, 1f);

	// Token: 0x04006BB2 RID: 27570
	public static byte[] ConstSoldierCount = new byte[]
	{
		12,
		9,
		6,
		1
	};

	// Token: 0x04006BB3 RID: 27571
	public static Vector3 ConstHeroOffset = new Vector3(0f, 0f, 3f);

	// Token: 0x04006BB4 RID: 27572
	public static float[] ConstSoldierSpeed = new float[]
	{
		5.5f,
		4.5f,
		7f,
		4.5f,
		0f
	};

	// Token: 0x04006BB5 RID: 27573
	public Vector3[] soldierArray;

	// Token: 0x04006BB6 RID: 27574
	public Soldier[] soldiers;

	// Token: 0x04006BB7 RID: 27575
	public Soldier heroSoldier;

	// Token: 0x04006BB8 RID: 27576
	protected ArmyGroup.EGROUPSTATE m_State = ArmyGroup.EGROUPSTATE.IDLE;

	// Token: 0x04006BB9 RID: 27577
	protected ArmyGroup.EGROUPSTATE lastState = ArmyGroup.EGROUPSTATE.IDLE;

	// Token: 0x04006BBA RID: 27578
	public ArmyGroup Target;

	// Token: 0x04006BBB RID: 27579
	public Soldier SoldierTarget;

	// Token: 0x04006BBC RID: 27580
	public Transform groupRoot;

	// Token: 0x04006BBD RID: 27581
	public Quaternion m_Direction = Quaternion.identity;

	// Token: 0x04006BBE RID: 27582
	public static FSMManager FSMMgr = null;

	// Token: 0x04006BBF RID: 27583
	public EGroupKind GroupKind = EGroupKind.Infantry;

	// Token: 0x04006BC0 RID: 27584
	public float MoveSpeed = 4.5f;

	// Token: 0x04006BC1 RID: 27585
	public Vector3 CenterWithTarget = Vector3.zero;

	// Token: 0x04006BC2 RID: 27586
	public uint OnceFlag;

	// Token: 0x04006BC3 RID: 27587
	public byte Side;

	// Token: 0x04006BC4 RID: 27588
	public byte Tier;

	// Token: 0x04006BC5 RID: 27589
	public byte Index;

	// Token: 0x04006BC6 RID: 27590
	public byte DataIndex;

	// Token: 0x04006BC7 RID: 27591
	private int lightmapIndex;

	// Token: 0x04006BC8 RID: 27592
	public int SoldierFlagCount;

	// Token: 0x04006BC9 RID: 27593
	public uint CommonFlag;

	// Token: 0x04006BCA RID: 27594
	public float CommonTimer;

	// Token: 0x04006BCB RID: 27595
	public bool HasHeroDisplay;

	// Token: 0x04006BCC RID: 27596
	public ushort heroSoldierID;

	// Token: 0x04006BCD RID: 27597
	public ushort heroSoldierFO;

	// Token: 0x04006BCE RID: 27598
	public ushort heroSoldierSkillFO;

	// Token: 0x04006BCF RID: 27599
	private bool hasLord;

	// Token: 0x04006BD0 RID: 27600
	public bool bAttackMode = true;

	// Token: 0x04006BD1 RID: 27601
	public bool bInsideSkill;

	// Token: 0x04006BD2 RID: 27602
	public ArmyGroup AttackBy;

	// Token: 0x04006BD3 RID: 27603
	public bool ForceEnterFSM;

	// Token: 0x04006BD4 RID: 27604
	protected Vector3 hitPointOffset = Vector3.zero;

	// Token: 0x04006BD5 RID: 27605
	public int m_HP = 100;

	// Token: 0x04006BD6 RID: 27606
	public int m_CurHP;

	// Token: 0x04006BD7 RID: 27607
	public int HpDefault;

	// Token: 0x04006BD8 RID: 27608
	protected WarParticleManager particleMgr;

	// Token: 0x04006BD9 RID: 27609
	protected static List<byte> RandomPosList = new List<byte>(16);

	// Token: 0x04006BDA RID: 27610
	public static Dictionary<ArmyGroup.EGROUPSTATE, EStateName> m_FSMMap = null;

	// Token: 0x04006BDB RID: 27611
	public bool bNpcMode;

	// Token: 0x0200070C RID: 1804
	public enum EGROUPSTATE
	{
		// Token: 0x04006BDD RID: 27613
		MOVING,
		// Token: 0x04006BDE RID: 27614
		IDLE,
		// Token: 0x04006BDF RID: 27615
		FIGHT,
		// Token: 0x04006BE0 RID: 27616
		FIGHT_IMMEDIATE,
		// Token: 0x04006BE1 RID: 27617
		IDLE_WITHOUT_CLUMP,
		// Token: 0x04006BE2 RID: 27618
		RETREAT_MOVING_SPREAD,
		// Token: 0x04006BE3 RID: 27619
		RETREAT_MOVING,
		// Token: 0x04006BE4 RID: 27620
		VICTORY,
		// Token: 0x04006BE5 RID: 27621
		MOVE_OUTOF_TOWN,
		// Token: 0x04006BE6 RID: 27622
		JUMP_FROM_WALL,
		// Token: 0x04006BE7 RID: 27623
		GO_CAPTIVING,
		// Token: 0x04006BE8 RID: 27624
		ATTACKER_RUN_AWAY,
		// Token: 0x04006BE9 RID: 27625
		DEFENSER_CHASING,
		// Token: 0x04006BEA RID: 27626
		DEFENSER_RUN_AWAY,
		// Token: 0x04006BEB RID: 27627
		ATTACKER_CHASING,
		// Token: 0x04006BEC RID: 27628
		DESTROYING,
		// Token: 0x04006BED RID: 27629
		DESTROYED
	}
}
