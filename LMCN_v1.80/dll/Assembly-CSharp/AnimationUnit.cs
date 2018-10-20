using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x020001CC RID: 460
public class AnimationUnit : MonoBehaviour
{
	// Token: 0x1700004E RID: 78
	// (get) Token: 0x0600079F RID: 1951 RVA: 0x000A3BA8 File Offset: 0x000A1DA8
	// (set) Token: 0x0600079E RID: 1950 RVA: 0x000A3B9C File Offset: 0x000A1D9C
	public ushort NpcID
	{
		get
		{
			return this.m_NpcID;
		}
		set
		{
			this.m_NpcID = value;
		}
	}

	// Token: 0x1700004F RID: 79
	// (get) Token: 0x060007A1 RID: 1953 RVA: 0x000A3BBC File Offset: 0x000A1DBC
	// (set) Token: 0x060007A0 RID: 1952 RVA: 0x000A3BB0 File Offset: 0x000A1DB0
	public bool IsBoss
	{
		get
		{
			return this.m_bIsBoss;
		}
		set
		{
			this.m_bIsBoss = value;
		}
	}

	// Token: 0x17000050 RID: 80
	// (get) Token: 0x060007A3 RID: 1955 RVA: 0x000A3BD0 File Offset: 0x000A1DD0
	// (set) Token: 0x060007A2 RID: 1954 RVA: 0x000A3BC4 File Offset: 0x000A1DC4
	public bool IsEnemy
	{
		get
		{
			return this.m_bIsEnemy;
		}
		set
		{
			this.m_bIsEnemy = value;
		}
	}

	// Token: 0x17000051 RID: 81
	// (get) Token: 0x060007A4 RID: 1956 RVA: 0x000A3BD8 File Offset: 0x000A1DD8
	// (set) Token: 0x060007A5 RID: 1957 RVA: 0x000A3BE0 File Offset: 0x000A1DE0
	public float MovingDeltaTime
	{
		get
		{
			return this.m_MovingDeltaTime;
		}
		set
		{
			this.m_MovingDeltaTime = value;
		}
	}

	// Token: 0x17000052 RID: 82
	// (get) Token: 0x060007A6 RID: 1958 RVA: 0x000A3BEC File Offset: 0x000A1DEC
	public float ScaleRate
	{
		get
		{
			return this.m_NpcScale;
		}
	}

	// Token: 0x17000053 RID: 83
	// (get) Token: 0x060007A7 RID: 1959 RVA: 0x000A3BF4 File Offset: 0x000A1DF4
	public bool hasRangeParticlePos
	{
		get
		{
			return this.m_RangeParticlePosTemp != Vector3.zero;
		}
	}

	// Token: 0x17000054 RID: 84
	// (get) Token: 0x060007A8 RID: 1960 RVA: 0x000A3C08 File Offset: 0x000A1E08
	public AnimationUnit.EState DisplayState
	{
		get
		{
			return this.m_DisplayState;
		}
	}

	// Token: 0x17000055 RID: 85
	// (get) Token: 0x060007A9 RID: 1961 RVA: 0x000A3C10 File Offset: 0x000A1E10
	public bool IsMaxSkillLooping
	{
		get
		{
			return this.bMaxSkillLooping;
		}
	}

	// Token: 0x17000056 RID: 86
	// (get) Token: 0x060007AA RID: 1962 RVA: 0x000A3C18 File Offset: 0x000A1E18
	public byte DeadBodyHidingFlag
	{
		get
		{
			return this.m_bDeadBodyHiding;
		}
	}

	// Token: 0x17000057 RID: 87
	// (get) Token: 0x060007AB RID: 1963 RVA: 0x000A3C20 File Offset: 0x000A1E20
	public AnimationState CurAnimState
	{
		get
		{
			return this.m_CurAnimState;
		}
	}

	// Token: 0x17000058 RID: 88
	// (get) Token: 0x060007AC RID: 1964 RVA: 0x000A3C28 File Offset: 0x000A1E28
	// (set) Token: 0x060007AD RID: 1965 RVA: 0x000A3C30 File Offset: 0x000A1E30
	public int hitParticle
	{
		get
		{
			return this.m_dwHitParticle;
		}
		set
		{
			this.m_dwHitParticle = value;
		}
	}

	// Token: 0x17000059 RID: 89
	// (get) Token: 0x060007AE RID: 1966 RVA: 0x000A3C3C File Offset: 0x000A1E3C
	public Vector3 FlyRootPos
	{
		get
		{
			if (this.m_FlyRoot != null)
			{
				return this.m_FlyRoot.position;
			}
			return this.modelRoot.position;
		}
	}

	// Token: 0x1700005A RID: 90
	// (get) Token: 0x060007AF RID: 1967 RVA: 0x000A3C74 File Offset: 0x000A1E74
	public Transform WP
	{
		get
		{
			if (this.m_FlyRoot != null)
			{
				return this.m_FlyRoot;
			}
			return this.modelRoot;
		}
	}

	// Token: 0x1700005B RID: 91
	// (set) Token: 0x060007B0 RID: 1968 RVA: 0x000A3C94 File Offset: 0x000A1E94
	public GameObject Shadow
	{
		set
		{
			this.m_ShadowObj = value;
			if (this.m_ShadowObj != null)
			{
				this.m_ShadowTrans = this.m_ShadowObj.transform;
			}
		}
	}

	// Token: 0x1700005C RID: 92
	// (get) Token: 0x060007B2 RID: 1970 RVA: 0x000A3CCC File Offset: 0x000A1ECC
	// (set) Token: 0x060007B1 RID: 1969 RVA: 0x000A3CC0 File Offset: 0x000A1EC0
	public GameObject Target
	{
		get
		{
			return this.m_Target;
		}
		set
		{
			this.m_Target = value;
		}
	}

	// Token: 0x1700005D RID: 93
	// (get) Token: 0x060007B4 RID: 1972 RVA: 0x000A3CE0 File Offset: 0x000A1EE0
	// (set) Token: 0x060007B3 RID: 1971 RVA: 0x000A3CD4 File Offset: 0x000A1ED4
	public Vector3 TargetPos
	{
		get
		{
			return this.m_targetPos;
		}
		set
		{
			this.m_targetPos = value;
		}
	}

	// Token: 0x1700005E RID: 94
	// (get) Token: 0x060007B5 RID: 1973 RVA: 0x000A3CE8 File Offset: 0x000A1EE8
	public Animation getAnimation
	{
		get
		{
			return this.m_Animation;
		}
	}

	// Token: 0x1700005F RID: 95
	// (get) Token: 0x060007B6 RID: 1974 RVA: 0x000A3CF0 File Offset: 0x000A1EF0
	// (set) Token: 0x060007B7 RID: 1975 RVA: 0x000A3CF8 File Offset: 0x000A1EF8
	public HERO_STATE_ENUM heroState
	{
		get
		{
			return this.m_HeroState;
		}
		set
		{
			this.m_HeroState = value;
		}
	}

	// Token: 0x17000060 RID: 96
	// (get) Token: 0x060007B8 RID: 1976 RVA: 0x000A3D04 File Offset: 0x000A1F04
	// (set) Token: 0x060007B9 RID: 1977 RVA: 0x000A3D0C File Offset: 0x000A1F0C
	public bool IsFreeze
	{
		get
		{
			return this.m_bIsFreeze;
		}
		set
		{
			this.m_bIsFreeze = value;
		}
	}

	// Token: 0x17000061 RID: 97
	// (get) Token: 0x060007BA RID: 1978 RVA: 0x000A3D18 File Offset: 0x000A1F18
	public float BoundingHight
	{
		get
		{
			return this.m_BoundingHight * this.m_NpcScale;
		}
	}

	// Token: 0x17000062 RID: 98
	// (get) Token: 0x060007BB RID: 1979 RVA: 0x000A3D28 File Offset: 0x000A1F28
	public Vector3 Position
	{
		get
		{
			return base.transform.position;
		}
	}

	// Token: 0x17000063 RID: 99
	// (get) Token: 0x060007BC RID: 1980 RVA: 0x000A3D38 File Offset: 0x000A1F38
	public Transform ModelRoot
	{
		get
		{
			return this.modelRoot;
		}
	}

	// Token: 0x17000064 RID: 100
	// (get) Token: 0x060007BD RID: 1981 RVA: 0x000A3D40 File Offset: 0x000A1F40
	public Transform HitPointRoot
	{
		get
		{
			if (this.m_hitParticleRoot != null)
			{
				return this.m_hitParticleRoot;
			}
			return this.modelRoot;
		}
	}

	// Token: 0x17000065 RID: 101
	// (get) Token: 0x060007BE RID: 1982 RVA: 0x000A3D60 File Offset: 0x000A1F60
	public Renderer getRenderer
	{
		get
		{
			return this.m_ModelRenderer;
		}
	}

	// Token: 0x060007BF RID: 1983 RVA: 0x000A3D68 File Offset: 0x000A1F68
	public static Transform GetSkeletalTrans(GameObject rootGo, string skeletal_name)
	{
		AnimationUnit.SkeletalTransCache.Clear();
		rootGo.GetComponentsInChildren<Transform>(true, AnimationUnit.SkeletalTransCache);
		for (int i = 0; i < AnimationUnit.SkeletalTransCache.Count; i++)
		{
			if (AnimationUnit.SkeletalTransCache[i].name == skeletal_name)
			{
				return AnimationUnit.SkeletalTransCache[i];
			}
		}
		return null;
	}

	// Token: 0x060007C0 RID: 1984 RVA: 0x000A3DD0 File Offset: 0x000A1FD0
	public void initComponent(ushort NpcID)
	{
		if (AnimationUnit.m_ChannelSkillKindList == null)
		{
			AnimationUnit.m_ChannelSkillKindList = new CHashSet<byte>(10, false);
			AnimationUnit.m_ChannelSkillKindList.Add(10);
			AnimationUnit.m_ChannelSkillKindList.Add(11);
			AnimationUnit.m_ChannelSkillKindList.Add(12);
			AnimationUnit.m_ChannelSkillKindList.Add(13);
			AnimationUnit.m_ChannelSkillKindList.Add(14);
			AnimationUnit.m_ChannelSkillKindList.Add(15);
			AnimationUnit.m_ChannelSkillKindList.Add(57);
			AnimationUnit.m_ChannelSkillKindList.Add(58);
			AnimationUnit.m_ChannelSkillKindList.Add(59);
			AnimationUnit.m_ChannelSkillKindList.Add(60);
		}
		if (!this.IsInitialized)
		{
			this.m_Animation = base.GetComponentInChildren<Animation>();
			this.m_Animation.cullingType = AnimationCullingType.AlwaysAnimate;
			this.modelRoot = base.transform.FindChild("AnimationObject");
			this.BipTrans = this.modelRoot.GetChild(0);
			this.m_ModelRenderer = base.GetComponentInChildren<SkinnedMeshRenderer>().transform.renderer;
			Transform[] componentsInChildren = this.modelRoot.gameObject.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].name == AnimationUnit.FLY_WEAPON_ROOTBONE)
				{
					this.m_FlyRoot = componentsInChildren[i];
				}
				else if (componentsInChildren[i].name == AnimationUnit.HIT_POINT_ROOTBONE)
				{
					this.m_hitParticleRoot = componentsInChildren[i];
				}
			}
			if (this.m_FlyRoot == null)
			{
				this.m_FlyRoot = this.BipTrans;
			}
			if (this.m_hitParticleRoot == null)
			{
				this.m_hitParticleRoot = this.BipTrans;
			}
			if (this.m_Animation != null)
			{
				this.initAnimation();
			}
		}
		this.m_NpcID = NpcID;
		this.m_ChannelSkillFlag = 0;
		if (!this.m_Animation.enabled)
		{
			this.m_Animation.enabled = true;
		}
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID);
		this.m_AttackAnimInfo.Clear();
		for (uint num = 0u; num < 5u; num += 1u)
		{
			uint val = (uint)((int)recordByKey.HeroAttackInfo[(int)((UIntPtr)num)].HitTime << 16 | (int)(num + 1u));
			this.m_AttackAnimInfo.Add(recordByKey.AttackPower[(int)((UIntPtr)num)], val);
			if (num == 1u)
			{
				this.m_MaxSkillID = recordByKey.AttackPower[(int)((UIntPtr)num)];
			}
		}
		AnimationUnit.QuatInstance.Set(0f, 0f, 0f, 1f);
		this.modelRoot.localPosition = Vector3.zero;
		this.modelRoot.localRotation = AnimationUnit.QuatInstance;
		this.bKnockBacking = false;
		this.m_BoundingHight = (float)recordByKey.Height * 0.01f;
		this.m_lastTargetPos = base.transform.position;
		this.m_targetPos = AnimationUnit.NON_TARGET_POS;
		this.movePos = null;
		this.m_NpcScale = 1f;
		this.m_ScaleTemp = 1f;
		this.m_bIsFreeze = false;
		this.m_bIsStateFreeze = false;
		this.m_bIsInHurricane = AnimationUnit.EBuffStatus.NONE;
		this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.NONE;
		this.IsCharging = false;
		this.m_Direction = base.transform.rotation;
		this.m_bMoveSpeedFix = true;
		if (this.m_ShadowObj != null)
		{
			this.m_ShadowObj.SetActive(true);
		}
		this.m_bDeadBodyHiding = 0;
		this.m_HeroState = HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
		this.changeAnim(AnimationUnit.AnimName.IDLE, 0.1f);
		base.enabled = true;
		this.IsInitialized = true;
	}

	// Token: 0x060007C1 RID: 1985 RVA: 0x000A415C File Offset: 0x000A235C
	public void resetComponent()
	{
		this.m_Target = null;
		this.m_LastRangeParticleTick = 0u;
		this.m_LastRangeHitSoundTick = 0u;
		this.cleanAttackParticle();
		this.cleanStateParticle();
		this.StateColorSkin = 0u;
		this.m_LastSkinStateID = 0;
		this.m_CurStateKey = 0u;
		this.m_SpecialEffList = 0u;
		this.m_DisplayState = AnimationUnit.EState.NONE;
		this.m_CurMoveSpeed = 2f;
		this.IsCharging = false;
		if (this.ResidentEffect != null)
		{
			ParticleManager.Instance.DeSpawn(this.ResidentEffect);
			this.ResidentEffect = null;
		}
		if (!this.modelRoot.gameObject.activeSelf)
		{
			this.modelRoot.gameObject.SetActive(true);
		}
	}

	// Token: 0x060007C2 RID: 1986 RVA: 0x000A4210 File Offset: 0x000A2410
	public void cleanAttackParticle()
	{
		if (this.m_RangeHitParticleObj != null)
		{
			ParticleManager.Instance.DeSpawn(this.m_RangeHitParticleObj);
			this.m_RangeHitParticleObj = null;
		}
		if (this.m_FightParticleObj != null)
		{
			ParticleManager.Instance.DeSpawn(this.m_FightParticleObj);
			this.m_FightParticleObj = null;
		}
		if (this.m_PreFireParticleObj != null)
		{
			ParticleManager.Instance.DeSpawn(this.m_PreFireParticleObj);
			this.m_PreFireParticleObj = null;
		}
	}

	// Token: 0x060007C3 RID: 1987 RVA: 0x000A4298 File Offset: 0x000A2498
	public void cleanStateParticle()
	{
		this.m_StateParticleList.Clear();
		this.m_StateParticlePosList.Clear();
		this.m_StateRotationParticleList.Clear();
		for (uint num = 0u; num < 10u; num += 1u)
		{
			GameObject gameObject = (GameObject)this.m_StateParticleMap.Values[(int)((UIntPtr)num)].particle;
			if (gameObject != null)
			{
				ParticleManager.Instance.DeSpawn(gameObject);
			}
		}
		this.m_StateParticleMap.Clear();
		this.StateEffList.Clear();
		this.m_CurSEIndex = 0;
		this.StateColorSkin = 0u;
		this.m_LastSkinStateID = 0;
		this.m_ModelRenderer.lightmapIndex = -1;
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x000A4348 File Offset: 0x000A2548
	private void Update()
	{
		this.updateAnimation();
		Vector3 position = this.BipTrans.position;
		position.y = 0f;
		this.m_ShadowTrans.position = position;
		if (this.m_HitSoundFlag != 0)
		{
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID);
			if (recordByKey.HeroKey == this.m_NpcID && recordByKey.HurtSound != 0 && UnityEngine.Random.Range(0, 100) <= this.controller.hitSoundTriggerRate)
			{
				AudioManager.Instance.PlaySFX(recordByKey.HurtSound, 0f, PitchKind.SpeechSound, base.transform, null);
			}
			this.m_HitSoundFlag = 0;
		}
		for (int i = 0; i < this.m_StateRotationParticleList.Count; i++)
		{
			this.m_StateRotationParticleList[i].position = this.m_hitParticleRoot.position;
			Quaternion rotation = Quaternion.LookRotation(Camera.main.transform.position - this.m_hitParticleRoot.position);
			this.m_StateRotationParticleList[i].rotation = rotation;
		}
		for (int j = 0; j < this.m_StateParticleList.Count; j++)
		{
			byte b = this.m_StateParticlePosList[j];
			if (b == 0)
			{
				this.m_StateParticleList[j].position = this.m_hitParticleRoot.position;
			}
			else if (b == 4)
			{
				this.m_StateParticleList[j].position = base.transform.position;
			}
		}
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x000A44F0 File Offset: 0x000A26F0
	private void OnDestroy()
	{
		this.resetComponent();
	}

	// Token: 0x060007C6 RID: 1990 RVA: 0x000A44F8 File Offset: 0x000A26F8
	private void updateAnimation()
	{
		if (!this.IsInitialized || Time.timeScale <= 0.001f)
		{
			return;
		}
		float smoothDeltaTime = Time.smoothDeltaTime;
		if (this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_LOOP || this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_IDLE)
		{
			if (this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_LOOP)
			{
				if (this.m_VictoryDelay > 0.001f)
				{
					this.m_VictoryDelay -= smoothDeltaTime;
				}
				else if (this.m_CurAnimName != AnimationUnit.AnimName.VICTORY)
				{
					this.changeAnim(AnimationUnit.AnimName.VICTORY, 0.1f);
				}
			}
			if (base.transform.rotation != this.m_Direction)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.m_Direction, smoothDeltaTime * 10f);
			}
			return;
		}
		if (this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_WAITING_SUPPORT)
		{
			return;
		}
		if (this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_SUPPORT_DISPLAY)
		{
			if (Vector3.Distance(this.modelRoot.localPosition, this.m_targetPos) > 0.0001f)
			{
				this.modelRoot.localPosition = Vector3.MoveTowards(this.modelRoot.localPosition, this.m_targetPos, smoothDeltaTime * 20f);
			}
			else
			{
				this.heroState = HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
				this.changeAnim(AnimationUnit.AnimName.IDLE, 0.1f);
				if (this.m_SupportType == 1)
				{
					ParticleManager.Instance.Spawn(296, null, this.Position, 1f, true, false, true);
				}
				if (this.ResidentEffect != null)
				{
					this.ResidentEffect.SetActive(true);
				}
				if (BattleController.IsGambleMode)
				{
					AudioManager.Instance.PlaySFX(1106, 0f, PitchKind.NoPitch, null, null);
				}
			}
			return;
		}
		if (this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_FINISHING_SPREAD)
		{
			if (!this.checkMove())
			{
				this.setState(HERO_STATE_ENUM.HERO_COMMANDS_IDLE, null, 0, 0, 0);
			}
		}
		else if (this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_PVPNPC_IDLE)
		{
			if (this.m_VictoryDelay > 0.001f)
			{
				this.m_VictoryDelay -= smoothDeltaTime;
			}
			else
			{
				this.m_Animation.CrossFade(AnimationUnit.ANIM_STRING[8]);
				this.m_VictoryDelay = UnityEngine.Random.Range(2f, 4f);
			}
			if (base.transform.rotation != this.m_Direction)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.m_Direction, smoothDeltaTime * 10f);
			}
			return;
		}
		if (this.m_bIsFreeze)
		{
			return;
		}
		bool flag = false;
		if ((this.m_SpecialEffList & 192u) != 0u)
		{
			flag = true;
		}
		if (!flag)
		{
			if (this.m_bDeadBodyHiding != 0)
			{
				Vector3 position = base.transform.position;
				if (this.m_bDeadBodyHiding == 1)
				{
					if (this.m_ShadowObj != null)
					{
						this.m_ShadowObj.SetActive(false);
					}
					this.resetComponent();
					this.m_bDeadBodyHiding = 2;
				}
				AnimationUnit.Vec3Instance.Set(position.x, -1f, position.z);
				base.transform.position = Vector3.MoveTowards(base.transform.position, AnimationUnit.Vec3Instance, smoothDeltaTime);
				if (base.transform.position.y <= -1f)
				{
					base.enabled = false;
					base.gameObject.SetActive(false);
					if (this.m_bDeadBodyHiding == 2)
					{
						this.m_bDeadBodyHiding = 3;
					}
				}
				return;
			}
			if (this.m_ScaleWorkingState == 1)
			{
				if (this.m_ScaleTemp <= 1f)
				{
					this.m_ScaleTemp = 1f;
					this.m_ScaleWorkingState = 0;
				}
				else
				{
					this.m_ScaleTemp -= 0.5f * smoothDeltaTime;
				}
				float num = this.m_NpcScale * this.m_ScaleTemp;
				AnimationUnit.Vec3Instance.Set(num, num, num);
				this.modelRoot.localScale = AnimationUnit.Vec3Instance;
			}
			if (this.m_bIsInHurricane != AnimationUnit.EBuffStatus.NONE)
			{
				if (this.m_bIsInHurricane == AnimationUnit.EBuffStatus.BEGIN)
				{
					if (this.m_bIsInHitFlying != AnimationUnit.EBuffStatus.NONE)
					{
						this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.NONE;
					}
					this.Vec3HurricaneUse = Vector3.zero;
					this.Vec3HurricaneUse.y = 2.5f;
					this.modelRoot.localPosition = Vector3.MoveTowards(this.modelRoot.localPosition, this.Vec3HurricaneUse, smoothDeltaTime * 5f);
					this.modelRoot.Rotate(Vector3.up, 1440f * smoothDeltaTime, Space.Self);
				}
				else
				{
					this.Vec3HurricaneUse = Vector3.zero;
					this.modelRoot.localPosition = Vector3.MoveTowards(this.modelRoot.localPosition, this.Vec3HurricaneUse, smoothDeltaTime * this.m_HurricanFinishSpeed);
					this.modelRoot.Rotate(Vector3.up, 1440f * smoothDeltaTime, Space.Self);
					if (this.modelRoot.localPosition.y <= 0.001f)
					{
						AnimationUnit.QuatInstance.Set(0f, 0f, 0f, 1f);
						this.modelRoot.localRotation = AnimationUnit.QuatInstance;
						this.modelRoot.localPosition = Vector3.zero;
						this.m_bIsInHurricane = AnimationUnit.EBuffStatus.NONE;
					}
				}
			}
			else if (this.m_bIsInHitFlying != AnimationUnit.EBuffStatus.NONE)
			{
				this.RunHitFly(smoothDeltaTime);
			}
			else if (this.m_bShakeSelf != 0)
			{
				this.m_ShakeCounter -= smoothDeltaTime;
				if (this.m_ShakeCounter <= 0f)
				{
					this.m_bShakeSelf = 0;
					this.modelRoot.localPosition = Vector3.zero;
				}
				else if (this.m_bShakeSelf == 1)
				{
					this.m_bShakeSelf = 2;
					AnimationUnit.Vec3Instance.Set(this.m_ShakeCounter * 0.45f, 0f, -this.m_ShakeCounter * 0.45f);
					this.modelRoot.localPosition = AnimationUnit.Vec3Instance;
				}
				else
				{
					this.m_bShakeSelf = 1;
					AnimationUnit.Vec3Instance.Set(-this.m_ShakeCounter * 0.45f, 0f, this.m_ShakeCounter * 0.45f);
					this.modelRoot.localPosition = AnimationUnit.Vec3Instance;
				}
			}
			if (this.m_IsAttacking)
			{
				if (this.m_HitPointTime >= 1E-05f && this.m_DeltaTimeCounter < this.m_HitPointTime && this.m_CurAnimState.time >= this.m_HitPointTime)
				{
					if (this.m_CurAnimName != AnimationUnit.AnimName.SKILL1 || (this.IsEnemy && !this.controller.IsType(EBattleType.PVP)))
					{
						this.checkFireParticle();
						if (this.m_ChannelSkillFlag == 1)
						{
							AnimationUnit.StringInstance.Length = 0;
							AnimationUnit.StringInstance.Append(AnimationUnit.ANIM_STRING[(int)this.m_CurAnimName]);
							AnimationUnit.StringInstance.Append("_ch");
							string text = AnimationUnit.StringInstance.ToString();
							AnimationClip clip = this.m_Animation.GetClip(text);
							if (clip != null)
							{
								this.m_Animation.CrossFade(text);
								this.m_CurAnimState = this.m_Animation[text];
							}
							else
							{
								this.m_CurAnimState.speed = 0f;
							}
							this.m_ChannelSkillFlag = 2;
							this.m_HitPointTime = 0f;
						}
					}
					else if (this.pListener != null)
					{
						this.pListener(this, EAUCallBack.MAXSKILL_HITPOINT, 0);
					}
				}
				if (this.m_LastHitPointTime > 0.0001f)
				{
					if (this.m_DeltaTimeCounter < this.m_LastHitPointTime && this.m_CurAnimState.time >= this.m_LastHitPointTime && (this.m_bIsEnemy || this.m_CurAnimName != AnimationUnit.AnimName.SKILL1 || this.m_LastHitPointTime != this.m_HitPointTime) && this.m_bHitPointSlowDown)
					{
						this.setAttackSlowDown();
					}
					if (this.bSlowMotion)
					{
						this.slowMotionCounter -= smoothDeltaTime;
						if (this.slowMotionCounter <= 0f)
						{
							this.bSlowMotion = false;
							float num2 = this.m_CurAnimState.time + this.slowMotionTime - this.slowMotionCounter;
							if (num2 < this.m_CurAnimState.length)
							{
								this.m_CurAnimState.speed = (this.m_CurAnimState.length - this.m_CurAnimState.time) / (this.m_CurAnimState.length - num2) * this.m_AnimTimeScale;
								this.m_LastHitPointTime = 0f;
							}
						}
					}
				}
				this.m_DeltaTimeCounter = this.m_CurAnimState.time;
			}
		}
		else if ((this.m_SpecialEffList & 128u) == 0u)
		{
			this.RunHitFly(smoothDeltaTime);
		}
		if (!this.checkMove())
		{
			if (!flag && !this.m_Animation.isPlaying)
			{
				if (this.m_HeroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
				{
					this.changeAnim(AnimationUnit.AnimName.IDLE, 0.1f);
					this.m_HeroState = HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
				}
				else
				{
					this.m_Animation.enabled = false;
					if (!NewbieManager.IsNewbie)
					{
						this.m_bDeadBodyHiding = 1;
					}
					else if (DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID).Modle != 232)
					{
						this.m_bDeadBodyHiding = 1;
					}
				}
			}
			if (base.transform.rotation != this.m_Direction)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.m_Direction, smoothDeltaTime * 8f);
			}
		}
	}

	// Token: 0x060007C7 RID: 1991 RVA: 0x000A4E60 File Offset: 0x000A3060
	public void RunHitFly(float _deltaTime)
	{
		if (this.m_bIsInHitFlying != AnimationUnit.EBuffStatus.NONE)
		{
			if (this.m_bIsInHitFlying == AnimationUnit.EBuffStatus.BEGIN)
			{
				this.Vec3HitFlyingUse = Vector3.zero;
				this.Vec3HitFlyingUse.y = 5.5f;
				this.m_HitFlyingTime += _deltaTime;
				if (this.m_HitFlyingTime >= this.m_HitFlyingLength)
				{
					this.m_HitFlyingTime = this.m_HitFlyingLength;
					this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.END;
				}
				this.modelRoot.localPosition = GameConstants.QuadraticBezierCurves(Vector3.zero, this.Vec3HitFlyingUse, Vector3.zero, 1f / this.m_HitFlyingLength, this.m_HitFlyingTime);
			}
			else
			{
				AnimationUnit.QuatInstance.Set(0f, 0f, 0f, 1f);
				this.modelRoot.localRotation = AnimationUnit.QuatInstance;
				this.modelRoot.localPosition = Vector3.zero;
				this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.NONE;
			}
		}
	}

	// Token: 0x060007C8 RID: 1992 RVA: 0x000A4F50 File Offset: 0x000A3150
	public void checkFireParticle()
	{
		if (this.m_FightParticleID != 0)
		{
			if (this.m_FightParticlePos == 1)
			{
				this.m_FightParticleObj = ParticleManager.Instance.Spawn(this.m_FightParticleID, this.m_FlyRoot, Vector3.zero, 1f, true, true, true);
			}
			else if (this.m_FightParticlePos == 2)
			{
				this.m_FightParticleObj = ParticleManager.Instance.Spawn(this.m_FightParticleID, this.m_hitParticleRoot, Vector3.zero, 1f, true, true, true);
			}
			else
			{
				this.m_FightParticleObj = ParticleManager.Instance.Spawn(this.m_FightParticleID, base.transform, base.transform.position, 1f, true, false, true);
			}
			if (this.m_FightParticleObj != null)
			{
				Transform child = this.m_FightParticleObj.transform.GetChild(0);
				ParticleSystem component = child.GetComponent<ParticleSystem>();
				if (component != null && !component.loop)
				{
					this.m_FightParticleObj = null;
				}
			}
		}
	}

	// Token: 0x060007C9 RID: 1993 RVA: 0x000A5054 File Offset: 0x000A3254
	public void checkPreFireParticle(ushort skillID)
	{
		if (skillID == 0)
		{
			return;
		}
		Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
		if (recordByKey.PreFireParticle != 0)
		{
			if (recordByKey.PreFireParticlePos == 1)
			{
				this.m_PreFireParticleObj = ParticleManager.Instance.Spawn(recordByKey.PreFireParticle, this.m_FlyRoot, Vector3.zero, 1f, true, true, true);
			}
			else if (recordByKey.PreFireParticlePos == 2)
			{
				this.m_PreFireParticleObj = ParticleManager.Instance.Spawn(recordByKey.PreFireParticle, this.m_hitParticleRoot, Vector3.zero, 1f, true, true, true);
			}
			else
			{
				this.m_PreFireParticleObj = ParticleManager.Instance.Spawn(recordByKey.PreFireParticle, base.transform, base.transform.position, 1f, true, false, true);
			}
			if (this.m_PreFireParticleObj != null)
			{
				Transform child = this.m_PreFireParticleObj.transform.GetChild(0);
				ParticleSystem component = child.GetComponent<ParticleSystem>();
				if (component != null && !component.loop)
				{
					this.m_PreFireParticleObj = null;
				}
			}
		}
	}

	// Token: 0x060007CA RID: 1994 RVA: 0x000A5178 File Offset: 0x000A3378
	public void playUltraLoopAnim(bool bPlay)
	{
		if (bPlay)
		{
			AnimationUnit.StringInstance.Length = 0;
			AnimationUnit.StringInstance.Append(AnimationUnit.ANIM_STRING[(int)this.m_CurAnimName]);
			AnimationUnit.StringInstance.Append("_w");
			string text = AnimationUnit.StringInstance.ToString();
			AnimationClip clip = this.m_Animation.GetClip(text);
			if (clip != null)
			{
				this.m_CurAnimState.speed = 0.3f;
				this.m_Animation.CrossFade(text, 0.1f);
				this.m_CurAnimState = this.m_Animation[text];
				this.bMaxSkillLooping = true;
			}
			else
			{
				this.m_CurAnimState.speed = 0f;
				this.bMaxSkillLooping = true;
			}
			this.m_HitPointTime = 0f;
		}
		else if (this.bMaxSkillLooping && !this.checkChannelSkillAnim() && this.m_CurAnimState.speed != 0f)
		{
			float time = (float)DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID).HeroAttackInfo[1].HitTime * 0.001f;
			this.changeAnim(AnimationUnit.AnimName.SKILL1, 0.1f);
			this.m_CurAnimState.time = time;
		}
	}

	// Token: 0x060007CB RID: 1995 RVA: 0x000A52BC File Offset: 0x000A34BC
	public bool checkChannelSkillAnim()
	{
		if (this.m_ChannelSkillFlag == 1)
		{
			AnimationUnit.StringInstance.Length = 0;
			AnimationUnit.StringInstance.Append(AnimationUnit.ANIM_STRING[(int)this.m_CurAnimName]);
			AnimationUnit.StringInstance.Append("_ch");
			string text = AnimationUnit.StringInstance.ToString();
			AnimationClip clip = this.m_Animation.GetClip(text);
			if (clip != null)
			{
				this.m_Animation.CrossFade(text, 0.1f);
				this.m_CurAnimState = this.m_Animation[text];
			}
			else
			{
				this.m_CurAnimState.speed = 0f;
			}
			this.m_ChannelSkillFlag = 2;
			this.m_HitPointTime = 0f;
			return true;
		}
		return false;
	}

	// Token: 0x060007CC RID: 1996 RVA: 0x000A5378 File Offset: 0x000A3578
	public void playUltraHitSound()
	{
		if (this.m_FightSoundID != 0)
		{
			AudioManager.Instance.PlaySFX(this.m_FightSoundID, 0f, PitchKind.NoPitch, base.transform, null);
		}
	}

	// Token: 0x060007CD RID: 1997 RVA: 0x000A53B8 File Offset: 0x000A35B8
	public void setStateFreeze(bool bEnable)
	{
		this.m_bIsStateFreeze = bEnable;
		if (!this.m_bIsStateFreeze && this.m_bIsFreeze != this.m_bIsStateFreeze)
		{
			return;
		}
		if (this.m_bIsStateFreeze && this.m_bIsFreeze == this.m_bIsStateFreeze)
		{
			return;
		}
		this.freeze(this.m_bIsStateFreeze);
		if (!bEnable)
		{
			this.changeAnim(AnimationUnit.AnimName.IDLE, 0.1f);
		}
	}

	// Token: 0x060007CE RID: 1998 RVA: 0x000A5424 File Offset: 0x000A3624
	public void setMaxSkillFreeze(bool bEnable)
	{
		this.m_bIsFreeze = bEnable;
		if (!this.m_bIsFreeze && this.m_bIsFreeze != this.m_bIsStateFreeze)
		{
			return;
		}
		if (this.m_bIsFreeze && this.m_bIsFreeze == this.m_bIsStateFreeze)
		{
			return;
		}
		this.freeze(this.m_bIsFreeze);
	}

	// Token: 0x060007CF RID: 1999 RVA: 0x000A5480 File Offset: 0x000A3680
	public void freeze(bool bEnable)
	{
		if (bEnable)
		{
			if (this.m_CurAnimState.speed >= 1E-05f)
			{
				this.m_OldSpeed = this.m_CurAnimState.speed;
				this.m_OldAnimName = this.m_CurAnimName;
			}
			this.m_CurAnimState.speed = 0f;
		}
		else if (this.m_CurAnimName == this.m_OldAnimName)
		{
			this.m_CurAnimState.speed = this.m_OldSpeed;
		}
		else
		{
			this.resetAnimationSpeed();
		}
	}

	// Token: 0x060007D0 RID: 2000 RVA: 0x000A5508 File Offset: 0x000A3708
	private bool checkMove()
	{
		if (this.m_bMoveDirty)
		{
			if (!(this.m_Target != null) && this.m_targetPos.x < 0f)
			{
				Vector3? vector = this.movePos;
				if (vector == null)
				{
					return false;
				}
			}
			Vector3? vector2 = this.movePos;
			if (vector2 != null)
			{
				AnimationUnit.Vec3Instance = this.movePos.Value;
			}
			else if (this.m_targetPos.x >= 0f)
			{
				AnimationUnit.Vec3Instance = this.m_targetPos;
			}
			else if (this.m_Target != null)
			{
				AnimationUnit.Vec3Instance = this.m_Target.transform.position;
			}
			if (!(base.transform.position == AnimationUnit.Vec3Instance))
			{
				float num = (!this.m_bMoveSpeedFix) ? Time.smoothDeltaTime : this.m_MovingDeltaTime;
				if (this.m_lastTargetPos != AnimationUnit.Vec3Instance)
				{
					if (this.bKnockBacking)
					{
						this.m_lastTargetPos = AnimationUnit.Vec3Instance;
						this.m_lastTargetPos.y = 0f;
					}
					else
					{
						this.updateDirection(AnimationUnit.Vec3Instance);
					}
				}
				base.transform.position = GameConstants.MoveTowards(base.transform.position, this.m_lastTargetPos, this.m_CurMoveSpeed * num);
				if (this.m_Direction != base.transform.rotation)
				{
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.m_Direction, 8f * num);
				}
				return true;
			}
			if (this.m_CurAnimName == AnimationUnit.AnimName.RUN)
			{
				this.changeAnim(AnimationUnit.AnimName.IDLE, 0.1f);
				this.m_HeroState = HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
			}
			this.m_bMoveDirty = false;
			this.m_Target = null;
		}
		return false;
	}

	// Token: 0x060007D1 RID: 2001 RVA: 0x000A56F0 File Offset: 0x000A38F0
	public void SetWaitIdle()
	{
		this.m_Animation["idle"].speed = 1f;
		this.m_Animation["idle"].wrapMode = WrapMode.Loop;
		this.m_CurAnimState = this.m_Animation.CrossFadeQueued("idle");
		this.m_IsAttacking = false;
		this.m_CurAnimName = AnimationUnit.AnimName.IDLE;
		this.bMaxSkillLooping = false;
		this.m_ChannelSkillFlag = 0;
	}

	// Token: 0x060007D2 RID: 2002 RVA: 0x000A5760 File Offset: 0x000A3960
	public void SetupResidentEffect(ushort EffID)
	{
		if (this.ResidentEffect != null)
		{
			ParticleManager.Instance.DeSpawn(this.ResidentEffect);
		}
		this.ResidentEffect = ParticleManager.Instance.Spawn(EffID, base.transform, Vector3.zero, 1f, true, true, false);
	}

	// Token: 0x060007D3 RID: 2003 RVA: 0x000A57B4 File Offset: 0x000A39B4
	private void changeAnim(AnimationUnit.AnimName an, float fadeLength = 0.1f)
	{
		if (an != AnimationUnit.AnimName.RUN && this.m_bMoveDirty)
		{
			this.m_bMoveDirty = false;
		}
		if (this.m_bIsInHurricane == AnimationUnit.EBuffStatus.END || this.m_bIsInHitFlying == AnimationUnit.EBuffStatus.END)
		{
			if (this.m_bIsInHurricane == AnimationUnit.EBuffStatus.END)
			{
				this.m_bIsInHurricane = AnimationUnit.EBuffStatus.NONE;
			}
			if (this.m_bIsInHitFlying == AnimationUnit.EBuffStatus.END)
			{
				this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.NONE;
			}
			if (this.m_bIsInHurricane == AnimationUnit.EBuffStatus.NONE && this.m_bIsInHitFlying == AnimationUnit.EBuffStatus.NONE)
			{
				AnimationUnit.QuatInstance.Set(0f, 0f, 0f, 1f);
				this.modelRoot.localRotation = AnimationUnit.QuatInstance;
				this.modelRoot.localPosition = Vector3.zero;
			}
		}
		AnimationClip clip = this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[(int)an]);
		if (clip == null)
		{
			if (an == AnimationUnit.AnimName.SKILL1 || an == AnimationUnit.AnimName.SKILL2 || an == AnimationUnit.AnimName.SKILL3)
			{
				an = AnimationUnit.AnimName.ATTACK;
			}
			else
			{
				an = AnimationUnit.AnimName.IDLE;
			}
		}
		this.m_Animation.CrossFade(AnimationUnit.ANIM_STRING[(int)an], fadeLength);
		this.m_CurAnimState = this.m_Animation[AnimationUnit.ANIM_STRING[(int)an]];
		this.m_IsAttacking = false;
		this.m_CurAnimName = an;
		this.bMaxSkillLooping = false;
		if (this.m_bIsFreeze || this.m_bIsStateFreeze)
		{
			this.m_OldSpeed = this.m_AnimTimeScale;
			this.m_CurAnimState.speed = 0f;
		}
		else
		{
			this.resetAnimationSpeed();
		}
		if (this.m_ChannelSkillFlag == 2)
		{
			this.m_ChannelSkillFlag = 0;
		}
		if (this.m_ChannelSkillFlag != 1)
		{
			if (this.m_RangeHitParticleObj || this.m_FightParticleObj)
			{
				this.m_CurMoveSpeed = 2f;
			}
			this.cleanAttackParticle();
		}
		if (this.m_ScaleWorkingState == 2)
		{
			this.m_ScaleWorkingState = 1;
		}
	}

	// Token: 0x060007D4 RID: 2004 RVA: 0x000A598C File Offset: 0x000A3B8C
	private void resetAnimationSpeed()
	{
		float speed = this.m_AnimTimeScale;
		if (this.m_CurAnimName == AnimationUnit.AnimName.RUN)
		{
			float num = 1f + (this.m_CurMoveSpeed - 2f) * 0.2f;
			speed = 1f / this.m_NpcScale * num;
		}
		else if (this.m_CurAnimName != AnimationUnit.AnimName.ATTACK && this.m_CurAnimName != AnimationUnit.AnimName.SKILL1 && this.m_CurAnimName != AnimationUnit.AnimName.SKILL2 && this.m_CurAnimName != AnimationUnit.AnimName.SKILL3)
		{
			speed = 1f;
		}
		this.m_CurAnimState.speed = speed;
	}

	// Token: 0x060007D5 RID: 2005 RVA: 0x000A5A1C File Offset: 0x000A3C1C
	private void initAnimation()
	{
		this.m_Animation.wrapMode = WrapMode.Loop;
		AnimationClip clip = this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[2]);
		if (clip)
		{
			this.m_Animation[AnimationUnit.ANIM_STRING[2]].wrapMode = WrapMode.Once;
		}
		clip = this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[3]);
		if (clip)
		{
			this.m_Animation[AnimationUnit.ANIM_STRING[3]].wrapMode = WrapMode.Once;
		}
		clip = this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[4]);
		if (clip)
		{
			this.m_Animation[AnimationUnit.ANIM_STRING[4]].wrapMode = WrapMode.Once;
		}
		clip = this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[5]);
		if (clip)
		{
			this.m_Animation[AnimationUnit.ANIM_STRING[5]].wrapMode = WrapMode.Once;
		}
		clip = this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[6]);
		if (clip)
		{
			this.m_Animation[AnimationUnit.ANIM_STRING[6]].wrapMode = WrapMode.Once;
		}
		clip = this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[7]);
		if (clip)
		{
			this.m_Animation[AnimationUnit.ANIM_STRING[7]].wrapMode = WrapMode.Once;
		}
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x000A5B7C File Offset: 0x000A3D7C
	public void setAttackSlowDown()
	{
		if (this.m_IsAttacking)
		{
			this.slowMotionTime = this.m_CurAnimState.length * 0.2f;
			this.slowMotionTime = Mathf.Clamp(this.slowMotionTime, 0.1f, 0.2f);
			if (this.m_CurAnimState.time + this.slowMotionTime < this.m_CurAnimState.length)
			{
				this.slowMotionCounter = this.slowMotionTime;
				this.m_CurAnimState.speed = 0f;
				this.bSlowMotion = true;
			}
		}
	}

	// Token: 0x060007D7 RID: 2007 RVA: 0x000A5C0C File Offset: 0x000A3E0C
	public bool checkRangeHitParticle(ushort skillID, Transform targetPos, uint curTick, byte fromSide)
	{
		if (this.m_RangeHitParticleObj != null)
		{
			return false;
		}
		if (skillID == 0 || curTick == this.m_LastRangeParticleTick)
		{
			return false;
		}
		Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
		if (recordByKey.RangeHitParticle == 0)
		{
			return false;
		}
		byte skillKind = recordByKey.SkillKind;
		if (skillKind == 13)
		{
			AnimationUnit.Vec3Instance.Set(11.9f, 0f, 5.5f);
			this.m_RangeHitParticleObj = ParticleManager.Instance.Spawn(recordByKey.RangeHitParticle, null, AnimationUnit.Vec3Instance, 1f, true, false, true);
			if (this.m_RangeHitParticleObj != null)
			{
				if (fromSide == 0)
				{
					AnimationUnit.QuatInstance.Set(0f, 0.7f, 0f, 0.7f);
				}
				else
				{
					AnimationUnit.QuatInstance.Set(0f, -0.7f, 0f, 0.7f);
				}
				this.m_RangeHitParticleObj.transform.rotation = AnimationUnit.QuatInstance;
			}
		}
		if (this.m_RangeHitParticleObj != null)
		{
			Transform child = this.m_RangeHitParticleObj.transform.GetChild(0);
			ParticleSystem component = child.GetComponent<ParticleSystem>();
			if (component != null && !component.loop)
			{
				this.m_RangeHitParticleObj = null;
			}
		}
		this.m_LastRangeParticleTick = curTick;
		return true;
	}

	// Token: 0x060007D8 RID: 2008 RVA: 0x000A5D78 File Offset: 0x000A3F78
	public bool checkRangeHitParticle_position(ushort skillID, Vector3 targetPos, uint curTick, byte fromSide)
	{
		if (this.m_RangeHitParticleObj != null)
		{
			return false;
		}
		if (skillID == 0)
		{
			return false;
		}
		Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
		if (recordByKey.RangeHitParticle == 0)
		{
			return false;
		}
		byte skillKind = recordByKey.SkillKind;
		switch (skillKind)
		{
		case 1:
		case 2:
		case 3:
			this.m_RangeHitParticleObj = ParticleManager.Instance.Spawn(recordByKey.RangeHitParticle, base.transform, base.transform.position, 1f, true, false, true);
			goto IL_2E7;
		case 4:
			break;
		case 5:
			goto IL_104;
		default:
			switch (skillKind)
			{
			case 57:
				goto IL_1B5;
			default:
				if (skillKind != 51)
				{
					if (skillKind != 52)
					{
						goto IL_2E7;
					}
					goto IL_104;
				}
				break;
			case 59:
				goto IL_249;
			}
			break;
		case 10:
			goto IL_1B5;
		case 12:
			goto IL_249;
		}
		this.m_RangeHitParticleObj = ParticleManager.Instance.Spawn(recordByKey.RangeHitParticle, base.transform, targetPos, 1f, true, false, true);
		goto IL_2E7;
		IL_104:
		AnimationUnit.Vec3Instance.Set(11.9f, 0f, 5.5f);
		this.m_RangeHitParticleObj = ParticleManager.Instance.Spawn(recordByKey.RangeHitParticle, null, AnimationUnit.Vec3Instance, 1f, true, false, true);
		if (this.m_RangeHitParticleObj != null)
		{
			if (fromSide == 0)
			{
				AnimationUnit.QuatInstance.Set(0f, 0.7f, 0f, 0.7f);
			}
			else
			{
				AnimationUnit.QuatInstance.Set(0f, -0.7f, 0f, 0.7f);
			}
			this.m_RangeHitParticleObj.transform.rotation = AnimationUnit.QuatInstance;
		}
		goto IL_2E7;
		IL_1B5:
		this.m_RangeHitParticleObj = ParticleManager.Instance.Spawn(recordByKey.RangeHitParticle, null, targetPos, 1f, true, false, true);
		if (this.m_RangeHitParticleObj != null)
		{
			if (fromSide == 0)
			{
				AnimationUnit.QuatInstance.Set(0f, 0.7f, 0f, 0.7f);
			}
			else
			{
				AnimationUnit.QuatInstance.Set(0f, -0.7f, 0f, 0.7f);
			}
			this.m_RangeHitParticleObj.transform.rotation = AnimationUnit.QuatInstance;
		}
		goto IL_2E7;
		IL_249:
		this.m_RangeHitParticleObj = ParticleManager.Instance.Spawn(recordByKey.RangeHitParticle, null, base.transform.position, 1f, true, false, true);
		if (this.m_RangeHitParticleObj != null)
		{
			if (fromSide == 0)
			{
				AnimationUnit.QuatInstance.Set(0f, 0.7f, 0f, 0.7f);
			}
			else
			{
				AnimationUnit.QuatInstance.Set(0f, -0.7f, 0f, 0.7f);
			}
			this.m_RangeHitParticleObj.transform.rotation = AnimationUnit.QuatInstance;
		}
		IL_2E7:
		if (this.m_RangeHitParticleObj != null)
		{
			Transform child = this.m_RangeHitParticleObj.transform.GetChild(0);
			ParticleSystem component = child.GetComponent<ParticleSystem>();
			if (component != null && !component.loop)
			{
				this.m_RangeHitParticleObj = null;
			}
		}
		this.m_LastRangeParticleTick = curTick;
		return true;
	}

	// Token: 0x060007D9 RID: 2009 RVA: 0x000A60BC File Offset: 0x000A42BC
	public void checkRangeHitSound(ushort skillID, uint curTick)
	{
		if (skillID == 0 || curTick == this.m_LastRangeHitSoundTick)
		{
			return;
		}
		Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
		if (recordByKey.SkillKey == skillID && recordByKey.HitSound != 0)
		{
			AudioManager.Instance.PlaySFX(recordByKey.HitSound, 0f, PitchKind.Hit, base.transform, null);
		}
		this.m_LastRangeHitSoundTick = curTick;
	}

	// Token: 0x060007DA RID: 2010 RVA: 0x000A6134 File Offset: 0x000A4334
	public void setState(HERO_STATE_ENUM state, GameObject target = null, int paramA = 0, int paramB = 0, int paramC = 0)
	{
		if (this.m_HeroState == HERO_STATE_ENUM.HERO_COMMANDS_DIE && this.m_CurAnimName == AnimationUnit.AnimName.DIE)
		{
			return;
		}
		HERO_STATE_ENUM heroState = this.m_HeroState;
		this.m_HeroState = state;
		switch (state)
		{
		case HERO_STATE_ENUM.HERO_COMMANDS_IDLE:
		{
			if (target != null)
			{
				this.updateDirection(target.transform.position);
			}
			float fadeLength = 0.1f;
			if (paramA != 0)
			{
				fadeLength = (float)paramA * 0.01f;
			}
			this.changeAnim(AnimationUnit.AnimName.IDLE, fadeLength);
			break;
		}
		case HERO_STATE_ENUM.HERO_COMMANDS_MOVE:
			this.m_targetPos = AnimationUnit.NON_TARGET_POS;
			this.m_Target = target;
			this.m_bMoveDirty = true;
			this.changeAnim(AnimationUnit.AnimName.RUN, (DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID).Modle != 251) ? 0.1f : 0.5f);
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_ATTACK:
			this.Attack(target, (ushort)paramA);
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_GETHIT:
		{
			byte b = (byte)(paramC & 1);
			byte b2 = (byte)(paramC >> 1 & 1);
			byte b3 = (byte)(paramC >> 2 & 1);
			byte b4 = (byte)(paramC >> 3 & 1);
			if (b2 != 0)
			{
				if (b != 0)
				{
					if (this.m_ChannelSkillFlag == 0 && (this.m_SpecialEffList & 1473u) == 0u)
					{
						this.changeAnim(AnimationUnit.AnimName.PAIN, 0.2f);
						this.m_HitSoundFlag = 1;
						if (this.m_CurAnimState != null)
						{
							float length = this.m_CurAnimState.length;
							this.m_CurAnimState.speed = length / 0.7f;
						}
					}
				}
				else if (heroState == HERO_STATE_ENUM.HERO_COMMANDS_IDLE && (this.m_SpecialEffList & 1473u) == 0u && this.m_CurAnimName != AnimationUnit.AnimName.SKILL1)
				{
					this.changeAnim(AnimationUnit.AnimName.PAIN, 0.1f);
					this.m_HitSoundFlag = 1;
				}
				this.m_ShakeCounter = 0.2f;
				if (this.m_bShakeSelf == 0)
				{
					this.m_bShakeSelf = 1;
				}
			}
			this.m_HeroState = heroState;
			if (b4 != 0)
			{
				ParticleManager.Instance.Spawn(63, base.transform, this.HitPointRoot.position, 1f, true, false, true);
			}
			else
			{
				this.playHitParticle(paramA, b3 == 1);
			}
			break;
		}
		case HERO_STATE_ENUM.HERO_COMMANDS_DIE:
			if (!this.modelRoot.gameObject.activeSelf)
			{
				this.modelRoot.gameObject.SetActive(true);
			}
			this.cleanStateParticle();
			this.CleanStateDisplay();
			this.m_HeroState = HERO_STATE_ENUM.HERO_COMMANDS_DIE;
			this.m_SpecialEffList = 0u;
			if (this.m_bIsStateFreeze)
			{
				this.setStateFreeze(false);
			}
			this.StateColorSkin = 0u;
			this.m_LastSkinStateID = 0;
			this.changeAnim(AnimationUnit.AnimName.DIE, 0.1f);
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE:
		{
			Buff recordByKey = DataManager.Instance.BuffTable.GetRecordByKey((ushort)paramA);
			uint num = (uint)((ushort)paramA & ushort.MaxValue);
			num |= (uint)((uint)recordByKey.SpecialEffects << 24);
			num |= (uint)((uint)recordByKey.ReplaceGroups << 16);
			if (paramB == 1)
			{
				AnimationUnit.EState specialEffects = (AnimationUnit.EState)recordByKey.SpecialEffects;
				if (specialEffects == AnimationUnit.EState.BANISH || specialEffects == AnimationUnit.EState.HURRICANE)
				{
					this.cleanStateParticle();
					this.cleanAttackParticle();
				}
				if (this.m_ChannelSkillFlag == 2)
				{
					Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(this.m_ChannelSkillID);
					uint num2 = (recordByKey.SpecialEffects == 0) ? 0u : (1u << (int)(recordByKey.SpecialEffects - 1));
					if (recordByKey2.HurtKind == 0 && (num2 & 1513u) != 0u)
					{
						this.cleanAttackParticle();
					}
					else if (recordByKey2.HurtKind == 1 && (num2 & 1509u) != 0u)
					{
						this.cleanAttackParticle();
					}
					else if ((num2 & 1473u) != 0u)
					{
						this.cleanAttackParticle();
					}
				}
				GameObject gameObject = null;
				ushort particle = recordByKey.Particle;
				bool flag = this.m_StateParticleMap.ContainsKey(num);
				if (particle != 0 && !flag)
				{
					AnimationUnit.QuatInstance.Set(0f, 0f, 0f, 1f);
					bool flag2 = recordByKey.FaceCamera != 0;
					if (recordByKey.ParticlePos == 1)
					{
						gameObject = ParticleManager.Instance.Spawn(particle, this.m_FlyRoot, Vector3.zero, this.m_NpcScale, true, !flag2, true);
					}
					else if (recordByKey.ParticlePos == 2)
					{
						gameObject = ParticleManager.Instance.Spawn(particle, this.HitPointRoot, Vector3.zero, this.m_NpcScale, true, !flag2, true);
					}
					else if (recordByKey.ParticlePos == 3)
					{
						gameObject = ParticleManager.Instance.Spawn(particle, base.transform, Vector3.zero, this.m_NpcScale, true, !flag2, true);
					}
					else
					{
						gameObject = ParticleManager.Instance.Spawn(particle, base.transform, base.transform.position, this.m_NpcScale, true, false, true);
					}
					if (gameObject != null)
					{
						if (recordByKey.ParticlePos == 3)
						{
							gameObject.transform.localRotation = Quaternion.identity;
						}
						else
						{
							gameObject.transform.rotation = AnimationUnit.QuatInstance;
						}
						if (flag2)
						{
							this.m_StateRotationParticleList.Add(gameObject.transform);
						}
						else
						{
							this.m_StateParticleList.Add(gameObject.transform);
							this.m_StateParticlePosList.Add(recordByKey.ParticlePos);
						}
					}
				}
				if (flag)
				{
					AnimationUnit.EStateNode value = this.m_StateParticleMap[num];
					value.refCount += 1;
					this.m_StateParticleMap[num] = value;
				}
				else
				{
					AnimationUnit.EStateNode val = default(AnimationUnit.EStateNode);
					val.refCount = 1;
					val.particle = gameObject;
					this.m_StateParticleMap.Add(num, val);
					if (recordByKey.SpecialEffects != 0)
					{
						if (recordByKey.SpecialEffects == 8)
						{
							this.CleanStateDisplay();
						}
						uint specialEffList = this.m_SpecialEffList;
						this.m_SpecialEffList |= 1u << (int)(recordByKey.SpecialEffects - 1);
						if (this.m_SpecialEffList != specialEffList)
						{
							this.updateStateDisplay(recordByKey.SpecialEffects, false);
						}
						if (recordByKey.SpecialEffects == 11)
						{
							this.m_HitFlyingLength = (float)recordByKey.Length * 0.001f;
							this.m_HitFlyingTime = 0f;
							if (!this.IsCharging)
							{
								this.m_bMoveDirty = false;
							}
							if ((this.m_SpecialEffList & 192u) == 0u)
							{
								this.changeAnim(AnimationUnit.AnimName.PAIN, 0.2f);
								if (this.m_CurAnimState != null && this.m_CurAnimName == AnimationUnit.AnimName.PAIN)
								{
									float length2 = this.m_CurAnimState.length;
									this.m_CurAnimState.speed = length2 / (this.m_HitFlyingLength * 0.5f);
								}
							}
						}
					}
					if (recordByKey.SpecialEffects > 0 && recordByKey.SpecialEffects <= 6)
					{
						if (!this.StateEffList.Contains(recordByKey.SpecialEffects) && this.m_CurSEIndex < 6)
						{
							this.StateEffList.Insert(this.m_CurSEIndex, recordByKey.SpecialEffects);
							this.m_CurSEIndex++;
						}
					}
					else if (recordByKey.EffectNumber > 0 && recordByKey.EffectNumber <= 200)
					{
						byte item = recordByKey.EffectNumber + 6;
						if (this.StateEffList.Count < 10 && !this.StateEffList.Contains(item))
						{
							this.StateEffList.Add(item);
						}
					}
					if (recordByKey.ColorModify != 0)
					{
						if (this.StateColorSkin != 0u)
						{
							Buff recordByKey3 = DataManager.Instance.BuffTable.GetRecordByKey(this.m_LastSkinStateID);
							if (recordByKey.ReplaceGroups > recordByKey3.ReplaceGroups)
							{
								this.StateColorSkin = (uint)recordByKey.ColorModify;
								this.m_LastSkinStateID = recordByKey.BuffKey;
							}
						}
						else
						{
							this.StateColorSkin = (uint)recordByKey.ColorModify;
							this.m_LastSkinStateID = recordByKey.BuffKey;
						}
					}
				}
			}
			else
			{
				AnimationUnit.EStateNode value2 = this.m_StateParticleMap[num];
				value2.refCount -= 1;
				bool flag3 = false;
				if (value2.refCount <= 0)
				{
					ushort particle2 = recordByKey.Particle;
					if (particle2 != 0)
					{
						GameObject gameObject2 = (GameObject)value2.particle;
						if (gameObject2 != null)
						{
							if (recordByKey.FaceCamera != 0)
							{
								for (int i = 0; i < this.m_StateRotationParticleList.Count; i++)
								{
									if (this.m_StateRotationParticleList[i] == gameObject2.transform)
									{
										this.m_StateRotationParticleList.RemoveAt(i);
										break;
									}
								}
							}
							else
							{
								for (int j = 0; j < this.m_StateParticleList.Count; j++)
								{
									if (this.m_StateParticleList[j] == gameObject2.transform)
									{
										this.m_StateParticleList.RemoveAt(j);
										this.m_StateParticlePosList.RemoveAt(j);
										break;
									}
								}
							}
							ParticleManager.Instance.DeSpawn(gameObject2);
						}
					}
					this.m_StateParticleMap.Remove(num);
					flag3 = true;
				}
				else
				{
					this.m_StateParticleMap[num] = value2;
				}
				if (flag3)
				{
					if (recordByKey.SpecialEffects != 0)
					{
						bool flag4 = false;
						for (int k = 0; k < this.m_StateParticleMap.Keys.Length; k++)
						{
							if (this.m_StateParticleMap.Keys[k] != 0u)
							{
								byte b5 = (byte)(this.m_StateParticleMap.Keys[k] >> 24);
								if (b5 == recordByKey.SpecialEffects)
								{
									flag4 = true;
									break;
								}
							}
						}
						if (!flag4)
						{
							this.m_SpecialEffList &= ~(1u << (int)(recordByKey.SpecialEffects - 1));
							this.updateStateDisplay(recordByKey.SpecialEffects, true);
							if (recordByKey.SpecialEffects == 9)
							{
								if (recordByKey.StepTime != 0)
								{
									this.m_HurricanFinishSpeed = 1f / ((float)recordByKey.StepTime * 0.001f) * this.modelRoot.localPosition.y;
								}
								else
								{
									this.m_HurricanFinishSpeed = 1000f;
								}
							}
						}
					}
					if (this.StateEffList.Count > 0)
					{
						if (recordByKey.SpecialEffects > 0 && recordByKey.SpecialEffects <= 6)
						{
							if (this.StateEffList.Contains(recordByKey.SpecialEffects))
							{
								this.StateEffList.Remove(recordByKey.SpecialEffects);
								this.m_CurSEIndex = ((this.m_CurSEIndex <= 0) ? 0 : (this.m_CurSEIndex - 1));
							}
						}
						else if (recordByKey.EffectNumber > 0 && recordByKey.EffectNumber <= 200)
						{
							byte b6 = recordByKey.EffectNumber + 6;
							if (this.StateEffList.Contains(b6))
							{
								bool flag5 = false;
								for (int l = 0; l < this.m_StateParticleMap.Keys.Length; l++)
								{
									if (this.m_StateParticleMap.Keys[l] != 0u)
									{
										ushort inKey = (ushort)(this.m_StateParticleMap.Keys[l] & 65535u);
										if (DataManager.Instance.BuffTable.GetRecordByKey(inKey).EffectNumber + 6 == b6)
										{
											flag5 = true;
											break;
										}
									}
								}
								if (!flag5)
								{
									this.StateEffList.Remove(b6);
								}
							}
						}
					}
					if (this.StateColorSkin != 0u && this.m_LastSkinStateID == recordByKey.BuffKey)
					{
						int num3 = 0;
						this.StateColorSkin = 0u;
						this.m_LastSkinStateID = 0;
						if (this.m_StateParticleMap.Count > 0)
						{
							for (int m = 0; m < this.m_StateParticleMap.Keys.Length; m++)
							{
								if (this.m_StateParticleMap.Keys[m] != 0u)
								{
									ushort inKey2 = (ushort)(this.m_StateParticleMap.Keys[m] & 65535u);
									Buff recordByKey4 = DataManager.Instance.BuffTable.GetRecordByKey(inKey2);
									if (recordByKey4.ColorModify != 0 && (int)recordByKey4.ReplaceGroups > num3)
									{
										num3 = (int)recordByKey4.ReplaceGroups;
										this.StateColorSkin = (uint)recordByKey4.ColorModify;
										this.m_LastSkinStateID = recordByKey4.BuffKey;
										break;
									}
								}
							}
						}
					}
				}
			}
			break;
		}
		case HERO_STATE_ENUM.HERO_COMMANDS_STOP_CHANNEL:
			if (this.m_ChannelSkillFlag != 0)
			{
				int num4 = this.m_FrontAnimTemp & 65535;
				float time = (float)(this.m_FrontAnimTemp >> 16) * 0.001f;
				this.changeAnim((AnimationUnit.AnimName)num4, 0.1f);
				this.m_CurAnimState.time = time;
				this.m_ChannelSkillFlag = 0;
			}
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_POINT:
		{
			Skill recordByKey5 = DataManager.Instance.SkillTable.GetRecordByKey((ushort)paramA);
			if (recordByKey5.SkillKind == 16 || recordByKey5.SkillKind == 17)
			{
				base.transform.position = this.m_targetPos;
			}
			else
			{
				this.m_bMoveDirty = true;
				this.m_CurMoveSpeed *= 10f;
			}
			break;
		}
		case HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_POINT_END:
			if (base.transform.position != this.m_targetPos)
			{
				base.transform.position = this.m_targetPos;
			}
			if (this.m_ChannelSkillFlag != 0)
			{
				int num5 = this.m_FrontAnimTemp & 65535;
				float time2 = (float)(this.m_FrontAnimTemp >> 16) * 0.001f;
				this.changeAnim((AnimationUnit.AnimName)num5, 0.1f);
				this.m_CurAnimState.time = time2;
				this.m_ChannelSkillFlag = 0;
			}
			this.m_CurMoveSpeed = 2f;
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_TARGET:
		{
			Skill recordByKey6 = DataManager.Instance.SkillTable.GetRecordByKey((ushort)paramA);
			if (recordByKey6.SkillKind == 16 || recordByKey6.SkillKind == 17)
			{
				base.transform.position = this.m_targetPos;
			}
			else
			{
				this.m_bMoveDirty = true;
				this.m_CurMoveSpeed *= 10f;
			}
			break;
		}
		case HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_TARGET_END:
			if (base.transform.position != this.m_targetPos)
			{
				base.transform.position = this.m_targetPos;
			}
			if (this.m_ChannelSkillFlag != 0)
			{
				int num6 = this.m_FrontAnimTemp & 65535;
				float time3 = (float)(this.m_FrontAnimTemp >> 16) * 0.001f;
				this.changeAnim((AnimationUnit.AnimName)num6, 0.1f);
				this.m_CurAnimState.time = time3;
				this.m_ChannelSkillFlag = 0;
			}
			this.m_CurMoveSpeed = 2f;
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_KNOCK_BACK:
			this.m_CurMoveSpeed = 2f;
			this.m_CurMoveSpeed *= 6f;
			this.bKnockBacking = true;
			if (!this.m_bIsFreeze && !this.IsStateDisplay(AnimationUnit.EState.FREEZE))
			{
				this.changeAnim(AnimationUnit.AnimName.PAIN, 0.1f);
				float num7 = Vector3.Distance(base.transform.position, this.m_targetPos);
				if (num7 >= 0.001f && this.m_CurMoveSpeed >= 0.001f)
				{
					float num8 = num7 / this.m_CurMoveSpeed;
					float speed = this.m_CurAnimState.length / num8;
					this.m_CurAnimState.speed = speed;
				}
				this.m_Direction = Quaternion.LookRotation(base.transform.position - this.m_targetPos);
			}
			this.m_bMoveDirty = true;
			this.IsCharging = true;
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_KNOCK_BACK_END:
			this.m_CurMoveSpeed = 2f;
			this.bKnockBacking = false;
			AnimationUnit.Vec3Instance = this.modelRoot.position;
			AnimationUnit.Vec3Instance.y = 0f;
			this.modelRoot.position = AnimationUnit.Vec3Instance;
			this.updateStateDisplay((byte)this.m_DisplayState, false);
			this.IsCharging = false;
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_VICTORY:
		{
			AnimationUnit.Vec3Instance.Set(Camera.main.transform.position.x, 0f, Camera.main.transform.position.z);
			Vector3 forward = AnimationUnit.Vec3Instance - base.transform.position;
			this.m_Direction = Quaternion.LookRotation(forward);
			this.cleanStateParticle();
			this.m_VictoryDelay = UnityEngine.Random.Range(0f, 0.2f);
			this.m_HeroState = HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_LOOP;
			break;
		}
		case HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_IDLE:
		{
			float num9 = 100f;
			AnimationUnit.Vec3Instance.Set(base.transform.position.x + num9, 0f, base.transform.position.z);
			this.m_targetPos = AnimationUnit.Vec3Instance;
			this.m_Target = null;
			Vector3 forward2 = AnimationUnit.Vec3Instance - base.transform.position;
			this.m_Direction = Quaternion.LookRotation(forward2);
			this.cleanStateParticle();
			break;
		}
		case HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_RUN:
			this.m_bMoveDirty = true;
			this.m_bMoveSpeedFix = false;
			this.m_CurMoveSpeed = 10f;
			this.changeAnim(AnimationUnit.AnimName.RUN, 0.1f);
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_RUN_GAMBLE:
			this.m_targetPos = Vector3.right * 1000f;
			this.cleanStateParticle();
			this.m_bMoveDirty = true;
			this.m_bMoveSpeedFix = false;
			this.m_CurMoveSpeed = 10f;
			this.changeAnim(AnimationUnit.AnimName.RUN, 0.1f);
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_PVPNPC_IDLE:
			this.m_Animation["victory"].wrapMode = WrapMode.Once;
			this.m_Animation["victory"].layer = 1;
			this.m_Animation["idle"].wrapMode = WrapMode.Loop;
			this.m_Animation["idle"].layer = 0;
			this.changeAnim(AnimationUnit.AnimName.IDLE, 0.3f);
			this.m_VictoryDelay = UnityEngine.Random.Range(1f, 3f);
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_DAZE:
			if (heroState == HERO_STATE_ENUM.HERO_COMMANDS_DIE)
			{
				this.m_HeroState = HERO_STATE_ENUM.HERO_COMMANDS_DIE;
			}
			else if (!this.m_bIsFreeze && (this.m_SpecialEffList & 192u) == 0u)
			{
				this.changeAnim(AnimationUnit.AnimName.DAZE, 0.1f);
			}
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_WAITING_SUPPORT:
			this.m_SupportType = paramA;
			this.modelRoot.gameObject.SetActive(false);
			this.m_targetPos = this.modelRoot.localPosition;
			if (this.m_SupportType == 1)
			{
				Vector3 vector = this.m_targetPos;
				vector.y = 10f;
				float f = UnityEngine.Random.Range(0f, 360f);
				Vector3 a = new Vector3(Mathf.Cos(f), 0f, Mathf.Sin(f));
				a.Normalize();
				vector += a * 3f;
				this.modelRoot.localPosition = vector;
			}
			else if (this.m_SupportType == 2)
			{
				Vector3 targetPos = this.m_targetPos;
				targetPos.y = -3f;
				this.modelRoot.localPosition = targetPos;
				ParticleManager.Instance.Spawn(297, null, this.Position, 1f, true, false, true);
			}
			if (BattleController.IsGambleMode)
			{
				base.transform.LookAt(Vector3.left);
			}
			if (this.ResidentEffect != null)
			{
				this.ResidentEffect.SetActive(false);
			}
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_SUPPORT_DISPLAY:
			this.m_targetPos = Vector3.zero;
			this.modelRoot.gameObject.SetActive(true);
			this.changeAnim(AnimationUnit.AnimName.RUN, 0.1f);
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_FINISHING_SPREAD:
			this.m_bMoveDirty = true;
			this.m_bMoveSpeedFix = false;
			this.m_CurMoveSpeed = 2f;
			this.changeAnim(AnimationUnit.AnimName.RUN, 0.1f);
			break;
		case HERO_STATE_ENUM.HERO_COMMANDS_GAMBLEFAILED:
			this.changeAnim(AnimationUnit.AnimName.DAZE, 0.1f);
			break;
		}
	}

	// Token: 0x060007DB RID: 2011 RVA: 0x000A7550 File Offset: 0x000A5750
	public bool IsStateDisplay(AnimationUnit.EState eff)
	{
		return eff != AnimationUnit.EState.NONE && (this.m_SpecialEffList >> (int)((byte)eff - 1) & 1u) != 0u;
	}

	// Token: 0x060007DC RID: 2012 RVA: 0x000A7570 File Offset: 0x000A5770
	public void CleanStateDisplay()
	{
		for (int i = 0; i < 9; i++)
		{
			if (((ulong)this.m_SpecialEffList & (ulong)(1L << (i & 31))) != 0UL)
			{
				this.updateStateDisplay((byte)(i + 1), true);
			}
		}
		if (this.IsStateDisplay(AnimationUnit.EState.HURRICANE) || this.IsStateDisplay(AnimationUnit.EState.HITFLYING))
		{
			AnimationUnit.QuatInstance.Set(0f, 0f, 0f, 1f);
			this.modelRoot.localRotation = AnimationUnit.QuatInstance;
			this.modelRoot.localPosition = Vector3.zero;
			this.m_bIsInHurricane = AnimationUnit.EBuffStatus.NONE;
			this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.NONE;
		}
		this.m_SpecialEffList = 0u;
	}

	// Token: 0x060007DD RID: 2013 RVA: 0x000A761C File Offset: 0x000A581C
	public void updateStateDisplay(byte specialEff, bool bRemove)
	{
		if (!bRemove)
		{
			switch (specialEff)
			{
			case 1:
				this.changeAnim(AnimationUnit.AnimName.DAZE, 0.1f);
				this.m_DisplayState = AnimationUnit.EState.DAZE;
				break;
			case 2:
				if (this.m_CurAnimName == AnimationUnit.AnimName.RUN)
				{
					this.m_bMoveDirty = false;
					this.changeAnim(AnimationUnit.AnimName.IDLE, 0.1f);
				}
				break;
			case 7:
				this.setStateFreeze(true);
				this.m_bMoveDirty = false;
				this.m_DisplayState = AnimationUnit.EState.FREEZE;
				break;
			case 8:
				this.modelRoot.gameObject.SetActive(false);
				this.m_bMoveDirty = false;
				this.m_DisplayState = AnimationUnit.EState.BANISH;
				break;
			case 9:
				this.m_DisplayState = AnimationUnit.EState.HURRICANE;
				this.m_bMoveDirty = false;
				this.m_bIsInHurricane = AnimationUnit.EBuffStatus.BEGIN;
				break;
			case 11:
				this.m_DisplayState = AnimationUnit.EState.HITFLYING;
				this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.BEGIN;
				break;
			}
		}
		else
		{
			this.m_DisplayState = AnimationUnit.EState.NONE;
			switch (specialEff)
			{
			case 1:
				this.changeAnim(AnimationUnit.AnimName.IDLE, 0.1f);
				this.heroState = HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
				break;
			case 2:
				if (this.m_CurAnimName == AnimationUnit.AnimName.RUN)
				{
					this.m_bMoveDirty = true;
				}
				break;
			case 7:
				this.setStateFreeze(false);
				break;
			case 8:
				this.modelRoot.gameObject.SetActive(true);
				this.changeAnim(AnimationUnit.AnimName.IDLE, 0.1f);
				this.heroState = HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
				break;
			case 9:
				this.m_bIsInHurricane = AnimationUnit.EBuffStatus.END;
				break;
			case 11:
				this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.END;
				break;
			}
		}
	}

	// Token: 0x060007DE RID: 2014 RVA: 0x000A77D8 File Offset: 0x000A59D8
	public void updateDirection(Vector3 curTargetPos)
	{
		this.m_lastTargetPos = curTargetPos;
		this.m_lastTargetPos.y = 0f;
		this.Forward = this.m_lastTargetPos - base.transform.position;
		if (this.Forward != Vector3.zero)
		{
			this.m_Direction = Quaternion.LookRotation(this.Forward);
		}
	}

	// Token: 0x060007DF RID: 2015 RVA: 0x000A7840 File Offset: 0x000A5A40
	public void Attack(GameObject target, ushort skillID)
	{
		this.m_Target = target;
		Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
		if (recordByKey.SkillKind == 61)
		{
			if (this.m_SpecialEffList != 0u)
			{
				this.CleanStateDisplay();
				this.cleanStateParticle();
				this.m_SpecialEffList = 0u;
			}
			if (this.m_bIsStateFreeze)
			{
				this.setStateFreeze(false);
			}
		}
		int num = 2;
		uint num2 = this.m_AttackAnimInfo.Find(skillID);
		if (num2 != 0u)
		{
			num += (int)((num2 & 65535u) - 1u);
		}
		if (this.m_ChannelSkillFlag != 0)
		{
			this.m_ChannelSkillFlag = 0;
		}
		if (num2 >> 16 != 0u)
		{
			this.changeAnim((AnimationUnit.AnimName)num, 0.2f);
		}
		this.m_IsAttacking = true;
		this.m_DeltaTimeCounter = 0f;
		this.setupAttack(ref recordByKey, (int)skillID, num, num2);
		if (this.m_Target != null)
		{
			this.updateDirection(this.m_Target.transform.position);
		}
	}

	// Token: 0x060007E0 RID: 2016 RVA: 0x000A7930 File Offset: 0x000A5B30
	private void setupAttack(ref Skill sSkill, int skillID, int attackPos, uint skillKey)
	{
		this.m_HitPointTime = (skillKey >> 16) * 0.001f;
		int num = attackPos - 2;
		int attackAnimation = (int)DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID).HeroAttackInfo[num].AttackAnimation;
		if (attackAnimation == 0)
		{
			this.m_LastHitPointTime = this.m_HitPointTime;
		}
		else
		{
			Combo recordByKey = DataManager.Instance.ComboTable.GetRecordByKey((ushort)attackAnimation);
			this.m_LastHitPointTime = (float)recordByKey.HitPoint[(int)(recordByKey.Count - 1)] * 0.001f;
		}
		if (sSkill.IsShake == 0)
		{
			this.m_bHitPointSlowDown = false;
		}
		else
		{
			this.m_bHitPointSlowDown = true;
		}
		this.m_FightParticleID = sSkill.FireParticle;
		this.m_FightParticlePos = sSkill.FireParticlePos;
		this.m_FightSoundID = sSkill.UltraHitSound;
		this.m_FightSoundDelay = sSkill.FireSoundDelay;
		byte skillKind = sSkill.SkillKind;
		if (AnimationUnit.m_ChannelSkillKindList.Find(skillKind))
		{
			this.m_ChannelSkillFlag = 1;
			this.m_ChannelSkillID = (ushort)skillID;
			this.m_FrontAnimTemp = (int)((skillKey & 4294901760u) | (uint)attackPos);
		}
		if ((int)this.m_MaxSkillID == skillID)
		{
			ParticleManager.Instance.Spawn(16, this.HitPointRoot, Vector3.zero, 1f, true, true, true);
		}
		this.checkPreFireParticle((ushort)skillID);
		if (UnityEngine.Random.Range(0, 4) == 0 && sSkill.FireVocal != 0)
		{
			AudioManager.Instance.PlaySFX(sSkill.FireVocal, (float)sSkill.FireVocalDelay * 0.001f, PitchKind.NoPitch, base.transform, null);
		}
		if (sSkill.FireSound != 0)
		{
			AudioManager.Instance.PlaySFX(sSkill.FireSound, (float)sSkill.FireSoundDelay * 0.001f, PitchKind.NoPitch, base.transform, null);
		}
	}

	// Token: 0x060007E1 RID: 2017 RVA: 0x000A7B00 File Offset: 0x000A5D00
	public void playMaxSkill()
	{
		if (this.m_MaxSkillID != 0)
		{
			this.Attack(this.m_Target, this.m_MaxSkillID);
		}
	}

	// Token: 0x060007E2 RID: 2018 RVA: 0x000A7B20 File Offset: 0x000A5D20
	public bool IsUltraSkill(ushort skillID)
	{
		return this.m_MaxSkillID == skillID;
	}

	// Token: 0x060007E3 RID: 2019 RVA: 0x000A7B2C File Offset: 0x000A5D2C
	private void playHitParticle(int skillID, bool bIsState)
	{
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID);
		float num = this.m_NpcScale;
		if (recordByKey.HeroKey == this.m_NpcID && recordByKey.HitParticleScaleRate != 0)
		{
			num *= (float)recordByKey.HitParticleScaleRate * 0.01f;
		}
		if (bIsState)
		{
			Buff recordByKey2 = DataManager.Instance.BuffTable.GetRecordByKey((ushort)skillID);
			if (recordByKey2.HitParticle != 0)
			{
				ParticleManager.Instance.Spawn(recordByKey2.HitParticle, base.transform, this.HitPointRoot.position, num, true, false, true);
			}
		}
		else
		{
			Skill recordByKey3 = DataManager.Instance.SkillTable.GetRecordByKey((ushort)skillID);
			if (recordByKey3.HitParticle != 0)
			{
				byte hitParticlePos = recordByKey3.HitParticlePos;
				if (hitParticlePos != 1)
				{
					if (hitParticlePos != 2)
					{
						ParticleManager.Instance.Spawn(recordByKey3.HitParticle, base.transform, base.transform.position, num, true, false, true);
					}
					else
					{
						ParticleManager.Instance.Spawn(recordByKey3.HitParticle, base.transform, this.HitPointRoot.position, num, true, false, true);
					}
				}
				else
				{
					ParticleManager.Instance.Spawn(recordByKey3.HitParticle, this.m_FlyRoot, Vector3.zero, num, true, true, true);
				}
			}
		}
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x000A7C90 File Offset: 0x000A5E90
	public void setPositionInstantly(Vector3 pos)
	{
		base.transform.position = pos;
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x000A7CA0 File Offset: 0x000A5EA0
	public void setNpcScale(float rate)
	{
		AnimationUnit.Vec3Instance.Set(rate, rate, rate);
		this.modelRoot.localScale = AnimationUnit.Vec3Instance;
		this.m_NpcScale = rate;
	}

	// Token: 0x060007E6 RID: 2022 RVA: 0x000A7CD4 File Offset: 0x000A5ED4
	public void setScaleInstantly(float rate)
	{
		float num = rate * this.m_NpcScale;
		AnimationUnit.Vec3Instance.Set(num, num, num);
		this.modelRoot.localScale = AnimationUnit.Vec3Instance;
		this.m_ScaleTemp = rate;
		this.m_ScaleWorkingState = 2;
	}

	// Token: 0x060007E7 RID: 2023 RVA: 0x000A7D18 File Offset: 0x000A5F18
	public void restoreScale(bool bScale)
	{
		this.m_ScaleWorkingState = 2;
	}

	// Token: 0x060007E8 RID: 2024 RVA: 0x000A7D24 File Offset: 0x000A5F24
	public bool checkCanUseMaxSkill()
	{
		return this.m_DisplayState != AnimationUnit.EState.DAZE && this.m_DisplayState != AnimationUnit.EState.FREEZE && this.m_DisplayState != AnimationUnit.EState.BANISH && this.m_DisplayState != AnimationUnit.EState.HURRICANE && this.m_DisplayState != AnimationUnit.EState.HITFLYING;
	}

	// Token: 0x04001C02 RID: 7170
	private const ushort MAX_SKILL_FIRING_PARTICLE = 16;

	// Token: 0x04001C03 RID: 7171
	private const int m_ChannelSkillKindCount = 10;

	// Token: 0x04001C04 RID: 7172
	public const float MOVE_SPEED = 2f;

	// Token: 0x04001C05 RID: 7173
	public const float ROTATE_SPEED = 8f;

	// Token: 0x04001C06 RID: 7174
	public const float SUPPORT_HIDE_DIST_Y = 3f;

	// Token: 0x04001C07 RID: 7175
	public const float SUPPORT_SHOWTIMES_FROM_GROUND = 3f;

	// Token: 0x04001C08 RID: 7176
	public const float SUPPORT_HIDE_HEIGHT = 10f;

	// Token: 0x04001C09 RID: 7177
	public const float SUPPORT_SHOWTIMES_FROM_SKY = 20f;

	// Token: 0x04001C0A RID: 7178
	public const float SUPPORT_RANDOM_OFFSET_XZ = 3f;

	// Token: 0x04001C0B RID: 7179
	private const float SHAKE_RANGE = 0.45f;

	// Token: 0x04001C0C RID: 7180
	private const float SHAKE_TIME = 0.2f;

	// Token: 0x04001C0D RID: 7181
	private const uint CC_STATE = 1473u;

	// Token: 0x04001C0E RID: 7182
	private const uint STATE_INTERRUPT_MAGIC = 1509u;

	// Token: 0x04001C0F RID: 7183
	private const uint STATE_INTERRUPT_PHYS = 1513u;

	// Token: 0x04001C10 RID: 7184
	public const int MAX_SPECIAL_EFFECT = 6;

	// Token: 0x04001C11 RID: 7185
	public static readonly string[] ANIM_STRING = new string[]
	{
		"idle",
		"moving",
		"attack",
		"skill_1",
		"skill_2",
		"skill_3",
		"hurt",
		"die",
		"victory",
		"daze"
	};

	// Token: 0x04001C12 RID: 7186
	public static readonly string FLY_WEAPON_ROOTBONE = "wp";

	// Token: 0x04001C13 RID: 7187
	public static readonly string HIT_POINT_ROOTBONE = "Bip01 Spine1";

	// Token: 0x04001C14 RID: 7188
	private static Vector3 Vec3Instance = new Vector3(0f, 0f, 0f);

	// Token: 0x04001C15 RID: 7189
	private static Quaternion QuatInstance = new Quaternion(0f, 0f, 0f, 1f);

	// Token: 0x04001C16 RID: 7190
	private static StringBuilder StringInstance = new StringBuilder(64);

	// Token: 0x04001C17 RID: 7191
	private static readonly Vector3 NON_TARGET_POS = new Vector3(-1f, -1f, -1f);

	// Token: 0x04001C18 RID: 7192
	private static CHashSet<byte> m_ChannelSkillKindList = null;

	// Token: 0x04001C19 RID: 7193
	public Vector3? movePos;

	// Token: 0x04001C1A RID: 7194
	private Vector3 m_targetPos;

	// Token: 0x04001C1B RID: 7195
	private Vector3 m_lastTargetPos;

	// Token: 0x04001C1C RID: 7196
	private Quaternion m_Direction;

	// Token: 0x04001C1D RID: 7197
	public Vector3 Forward = Vector3.zero;

	// Token: 0x04001C1E RID: 7198
	private bool m_bMoveDirty;

	// Token: 0x04001C1F RID: 7199
	private bool m_bMoveSpeedFix = true;

	// Token: 0x04001C20 RID: 7200
	public BattleController controller;

	// Token: 0x04001C21 RID: 7201
	private float m_VictoryDelay;

	// Token: 0x04001C22 RID: 7202
	private ushort m_NpcID;

	// Token: 0x04001C23 RID: 7203
	private CHashTable<ushort, uint> m_AttackAnimInfo = new CHashTable<ushort, uint>(5, false);

	// Token: 0x04001C24 RID: 7204
	private float m_CurMoveSpeed = 2f;

	// Token: 0x04001C25 RID: 7205
	private bool m_bIsBoss;

	// Token: 0x04001C26 RID: 7206
	private bool m_bIsEnemy;

	// Token: 0x04001C27 RID: 7207
	private float m_MovingDeltaTime;

	// Token: 0x04001C28 RID: 7208
	private byte m_ScaleWorkingState;

	// Token: 0x04001C29 RID: 7209
	private float m_ScaleTemp = 1f;

	// Token: 0x04001C2A RID: 7210
	private float m_NpcScale = 1f;

	// Token: 0x04001C2B RID: 7211
	private float m_AnimTimeScale = 1f;

	// Token: 0x04001C2C RID: 7212
	private Transform modelRoot;

	// Token: 0x04001C2D RID: 7213
	private byte m_bShakeSelf;

	// Token: 0x04001C2E RID: 7214
	private float m_ShakeCounter = 0.2f;

	// Token: 0x04001C2F RID: 7215
	private Transform BipTrans;

	// Token: 0x04001C30 RID: 7216
	private float m_HitPointTime;

	// Token: 0x04001C31 RID: 7217
	private float m_LastHitPointTime;

	// Token: 0x04001C32 RID: 7218
	private bool bKnockBacking;

	// Token: 0x04001C33 RID: 7219
	private ushort m_FightParticleID;

	// Token: 0x04001C34 RID: 7220
	private byte m_FightParticlePos;

	// Token: 0x04001C35 RID: 7221
	private GameObject m_FightParticleObj;

	// Token: 0x04001C36 RID: 7222
	private GameObject m_PreFireParticleObj;

	// Token: 0x04001C37 RID: 7223
	private ushort m_FightSoundID;

	// Token: 0x04001C38 RID: 7224
	private ushort m_FightSoundDelay;

	// Token: 0x04001C39 RID: 7225
	private uint m_LastRangeHitSoundTick;

	// Token: 0x04001C3A RID: 7226
	private byte m_HitSoundFlag;

	// Token: 0x04001C3B RID: 7227
	private bool m_bHitPointSlowDown;

	// Token: 0x04001C3C RID: 7228
	private float m_OldSpeed = 1f;

	// Token: 0x04001C3D RID: 7229
	private AnimationUnit.AnimName m_OldAnimName = AnimationUnit.AnimName.DIE;

	// Token: 0x04001C3E RID: 7230
	private bool bSlowMotion;

	// Token: 0x04001C3F RID: 7231
	private float slowMotionCounter;

	// Token: 0x04001C40 RID: 7232
	private float slowMotionTime;

	// Token: 0x04001C41 RID: 7233
	private int m_FrontAnimTemp;

	// Token: 0x04001C42 RID: 7234
	private byte m_ChannelSkillFlag;

	// Token: 0x04001C43 RID: 7235
	private ushort m_ChannelSkillID;

	// Token: 0x04001C44 RID: 7236
	private Vector3 m_RangeParticlePosTemp = Vector3.zero;

	// Token: 0x04001C45 RID: 7237
	private CHashTable<uint, AnimationUnit.EStateNode> m_StateParticleMap = new CHashTable<uint, AnimationUnit.EStateNode>(10, true);

	// Token: 0x04001C46 RID: 7238
	private List<Transform> m_StateRotationParticleList = new List<Transform>(10);

	// Token: 0x04001C47 RID: 7239
	private List<Transform> m_StateParticleList = new List<Transform>(10);

	// Token: 0x04001C48 RID: 7240
	private List<byte> m_StateParticlePosList = new List<byte>(10);

	// Token: 0x04001C49 RID: 7241
	private AnimationUnit.EBuffStatus m_bIsInHurricane;

	// Token: 0x04001C4A RID: 7242
	private float m_HurricanFinishSpeed;

	// Token: 0x04001C4B RID: 7243
	private Vector3 Vec3HurricaneUse = Vector3.zero;

	// Token: 0x04001C4C RID: 7244
	private AnimationUnit.EBuffStatus m_bIsInHitFlying;

	// Token: 0x04001C4D RID: 7245
	private float m_HitFlyingLength;

	// Token: 0x04001C4E RID: 7246
	private float m_HitFlyingTime;

	// Token: 0x04001C4F RID: 7247
	private Vector3 Vec3HitFlyingUse = Vector3.zero;

	// Token: 0x04001C50 RID: 7248
	private uint m_CurStateKey;

	// Token: 0x04001C51 RID: 7249
	private uint m_SpecialEffList;

	// Token: 0x04001C52 RID: 7250
	private AnimationUnit.EState m_DisplayState;

	// Token: 0x04001C53 RID: 7251
	public List<byte> StateEffList = new List<byte>(10);

	// Token: 0x04001C54 RID: 7252
	private int m_CurSEIndex;

	// Token: 0x04001C55 RID: 7253
	private ushort m_LastSkinStateID;

	// Token: 0x04001C56 RID: 7254
	public uint StateColorSkin;

	// Token: 0x04001C57 RID: 7255
	public GameObject ResidentEffect;

	// Token: 0x04001C58 RID: 7256
	private int m_SupportType;

	// Token: 0x04001C59 RID: 7257
	public AnimationUnit.AnimName m_CurAnimName;

	// Token: 0x04001C5A RID: 7258
	private AnimationState m_CurAnimState;

	// Token: 0x04001C5B RID: 7259
	private bool m_IsAttacking;

	// Token: 0x04001C5C RID: 7260
	private float m_DeltaTimeCounter;

	// Token: 0x04001C5D RID: 7261
	private byte m_bDeadBodyHiding;

	// Token: 0x04001C5E RID: 7262
	private ushort m_MaxSkillID;

	// Token: 0x04001C5F RID: 7263
	private bool bMaxSkillLooping;

	// Token: 0x04001C60 RID: 7264
	private Transform m_hitParticleRoot;

	// Token: 0x04001C61 RID: 7265
	private int m_dwHitParticle = -1;

	// Token: 0x04001C62 RID: 7266
	private Transform m_FlyRoot;

	// Token: 0x04001C63 RID: 7267
	private uint m_LastRangeParticleTick;

	// Token: 0x04001C64 RID: 7268
	private GameObject m_ShadowObj;

	// Token: 0x04001C65 RID: 7269
	private Transform m_ShadowTrans;

	// Token: 0x04001C66 RID: 7270
	private GameObject m_RangeHitParticleObj;

	// Token: 0x04001C67 RID: 7271
	private GameObject m_Target;

	// Token: 0x04001C68 RID: 7272
	private Animation m_Animation;

	// Token: 0x04001C69 RID: 7273
	private HERO_STATE_ENUM m_HeroState;

	// Token: 0x04001C6A RID: 7274
	private bool m_bIsStateFreeze;

	// Token: 0x04001C6B RID: 7275
	private bool m_bIsFreeze;

	// Token: 0x04001C6C RID: 7276
	private float m_BoundingHight;

	// Token: 0x04001C6D RID: 7277
	private Renderer m_ModelRenderer;

	// Token: 0x04001C6E RID: 7278
	public AnimationUnit.ParentListener pListener;

	// Token: 0x04001C6F RID: 7279
	public bool IsInitialized;

	// Token: 0x04001C70 RID: 7280
	public bool IsCharging;

	// Token: 0x04001C71 RID: 7281
	public static List<Transform> SkeletalTransCache = new List<Transform>(50);

	// Token: 0x020001CD RID: 461
	public enum AnimName : byte
	{
		// Token: 0x04001C73 RID: 7283
		IDLE,
		// Token: 0x04001C74 RID: 7284
		RUN,
		// Token: 0x04001C75 RID: 7285
		ATTACK,
		// Token: 0x04001C76 RID: 7286
		SKILL1,
		// Token: 0x04001C77 RID: 7287
		SKILL2,
		// Token: 0x04001C78 RID: 7288
		SKILL3,
		// Token: 0x04001C79 RID: 7289
		PAIN,
		// Token: 0x04001C7A RID: 7290
		DIE,
		// Token: 0x04001C7B RID: 7291
		VICTORY,
		// Token: 0x04001C7C RID: 7292
		DAZE
	}

	// Token: 0x020001CE RID: 462
	public enum EState
	{
		// Token: 0x04001C7E RID: 7294
		NONE,
		// Token: 0x04001C7F RID: 7295
		DAZE,
		// Token: 0x04001C80 RID: 7296
		MOVELOCK,
		// Token: 0x04001C81 RID: 7297
		MAGICLOCK,
		// Token: 0x04001C82 RID: 7298
		PHYSLOCK,
		// Token: 0x04001C83 RID: 7299
		LOSESPIRIT,
		// Token: 0x04001C84 RID: 7300
		ADDICT,
		// Token: 0x04001C85 RID: 7301
		FREEZE,
		// Token: 0x04001C86 RID: 7302
		BANISH,
		// Token: 0x04001C87 RID: 7303
		HURRICANE,
		// Token: 0x04001C88 RID: 7304
		MOCK,
		// Token: 0x04001C89 RID: 7305
		HITFLYING
	}

	// Token: 0x020001CF RID: 463
	public enum EBuffStatus
	{
		// Token: 0x04001C8B RID: 7307
		NONE,
		// Token: 0x04001C8C RID: 7308
		BEGIN,
		// Token: 0x04001C8D RID: 7309
		STEP,
		// Token: 0x04001C8E RID: 7310
		END
	}

	// Token: 0x020001D0 RID: 464
	private struct EStateNode
	{
		// Token: 0x04001C8F RID: 7311
		public byte refCount;

		// Token: 0x04001C90 RID: 7312
		public UnityEngine.Object particle;
	}

	// Token: 0x02000891 RID: 2193
	// (Invoke) Token: 0x06002D8C RID: 11660
	public delegate void ParentListener(AnimationUnit au, EAUCallBack type, int param = 0);
}
