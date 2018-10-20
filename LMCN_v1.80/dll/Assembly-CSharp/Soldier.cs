using System;
using UnityEngine;

// Token: 0x02000739 RID: 1849
public class Soldier : SheetAnimMesh
{
	// Token: 0x06002355 RID: 9045 RVA: 0x0040F8A8 File Offset: 0x0040DAA8
	protected Soldier()
	{
	}

	// Token: 0x06002356 RID: 9046 RVA: 0x0040F904 File Offset: 0x0040DB04
	public Soldier(byte kind, byte tier, byte side) : base(EWarMeshKind.SOLDIER, kind, tier, side)
	{
		this.animNotify = new SheetAnimMesh.AnimNotify(this.AnimOnceNotify);
		this.SoldierKind = kind;
		this.SoldierTier = tier;
		if (kind != 4)
		{
			this.createShadow((kind != 3) ? 0.75f : 1.5f);
		}
	}

	// Token: 0x06002357 RID: 9047 RVA: 0x0040F9A4 File Offset: 0x0040DBA4
	// Note: this type is marked as 'beforefieldinit'.
	static Soldier()
	{
		Vector3[,] array = new Vector3[2, 4];
		array[0, 0] = new Vector3(0.18f, 1.407f, 0.393f);
		array[0, 1] = new Vector3(0.244f, 1.572f, 0.713f);
		array[0, 2] = new Vector3(0.087f, 1.162f, 0.53f);
		array[0, 3] = new Vector3(0.1f, 1.403f, 0.112f);
		array[1, 0] = new Vector3(0f, 4.817f, -0.444f);
		array[1, 1] = new Vector3(0f, 6.889f, -6.819f);
		array[1, 2] = new Vector3(0f, 6.236f, -3.515f);
		array[1, 3] = new Vector3(0f, 5.339f, 2.517f);
		Soldier.rangeFirePoint = array;
		Soldier.hitPointOffset = new Vector3[]
		{
			new Vector3(0f, 3f, 0f),
			new Vector3(0f, 2.5f, 0f),
			new Vector3(0f, 5f, 0f),
			new Vector3(0f, 3.5f, 0f)
		};
		Soldier.attackRadius = new float[]
		{
			3f,
			110f,
			6.3f,
			110f
		};
		Soldier.hitRadius = new float[]
		{
			0.9f,
			0.9f,
			1.5f,
			1.5f
		};
	}

	// Token: 0x170000CE RID: 206
	// (get) Token: 0x06002358 RID: 9048 RVA: 0x0040FB64 File Offset: 0x0040DD64
	// (set) Token: 0x06002359 RID: 9049 RVA: 0x0040FB6C File Offset: 0x0040DD6C
	public Soldier Target
	{
		get
		{
			return this.m_Target;
		}
		set
		{
			this.m_Target = value;
			this.bNewTargetDirty = true;
		}
	}

	// Token: 0x170000CF RID: 207
	// (get) Token: 0x0600235A RID: 9050 RVA: 0x0040FB7C File Offset: 0x0040DD7C
	public bool IsMoveDirty
	{
		get
		{
			return Time.frameCount - this.LastMovingFrame <= 1;
		}
	}

	// Token: 0x170000D0 RID: 208
	// (get) Token: 0x0600235B RID: 9051 RVA: 0x0040FB90 File Offset: 0x0040DD90
	public virtual Vector3 RangeFirePoint
	{
		get
		{
			if (this.SoldierKind == 4 || this.SoldierKind == 2)
			{
				int num = (this.SoldierKind != 4) ? 0 : 1;
				return this.transform.TransformPoint(Soldier.rangeFirePoint[num, (int)(this.SoldierTier - 1)]);
			}
			return Vector3.zero;
		}
	}

	// Token: 0x170000D1 RID: 209
	// (get) Token: 0x0600235C RID: 9052 RVA: 0x0040FBF0 File Offset: 0x0040DDF0
	// (set) Token: 0x0600235D RID: 9053 RVA: 0x0040FBF8 File Offset: 0x0040DDF8
	public FSMUnit FSMController
	{
		get
		{
			return this.m_FSMController;
		}
		set
		{
			if (this.CurFSM != EStateName.KICKBACK || this.Flag != 1)
			{
				this.m_FSMController = value;
				this.CurFSM = this.m_FSMController.StateName;
				this.m_FSMController.Enter(this);
			}
		}
	}

	// Token: 0x170000D2 RID: 210
	// (get) Token: 0x0600235E RID: 9054 RVA: 0x0040FC38 File Offset: 0x0040DE38
	// (set) Token: 0x0600235F RID: 9055 RVA: 0x0040FC58 File Offset: 0x0040DE58
	public bool EnableShadow
	{
		get
		{
			return this.shadowObj && this.shadowObj.activeSelf;
		}
		set
		{
			if (this.shadowObj)
			{
				this.shadowObj.SetActive(value);
			}
		}
	}

	// Token: 0x170000D3 RID: 211
	// (get) Token: 0x06002360 RID: 9056 RVA: 0x0040FC78 File Offset: 0x0040DE78
	public virtual ESheetMeshAnim CurAnim
	{
		get
		{
			return this.curAnim;
		}
	}

	// Token: 0x170000D4 RID: 212
	// (get) Token: 0x06002361 RID: 9057 RVA: 0x0040FC80 File Offset: 0x0040DE80
	public virtual float AnimLength
	{
		get
		{
			return this.animLength;
		}
	}

	// Token: 0x170000D5 RID: 213
	// (get) Token: 0x06002362 RID: 9058 RVA: 0x0040FC88 File Offset: 0x0040DE88
	public virtual Renderer renderer
	{
		get
		{
			return this.meshRenderer;
		}
	}

	// Token: 0x170000D6 RID: 214
	// (get) Token: 0x06002363 RID: 9059 RVA: 0x0040FC90 File Offset: 0x0040DE90
	public Vector3 hitPoint
	{
		get
		{
			return this.transform.TransformPoint(Soldier.hitPointOffset[(int)(this.SoldierKind - 1)]) + new Vector3(UnityEngine.Random.Range(-1.5f, 1.5f), 0f, UnityEngine.Random.Range(-1.5f, 1.5f));
		}
	}

	// Token: 0x170000D7 RID: 215
	// (get) Token: 0x06002364 RID: 9060 RVA: 0x0040FCEC File Offset: 0x0040DEEC
	public float Radius
	{
		get
		{
			return Soldier.hitRadius[(int)(this.SoldierKind - 1)];
		}
	}

	// Token: 0x170000D8 RID: 216
	// (get) Token: 0x06002365 RID: 9061 RVA: 0x0040FCFC File Offset: 0x0040DEFC
	public float AttackRadius
	{
		get
		{
			if (this.Index == 255 && (this.SoldierKind == 1 || this.SoldierKind == 3))
			{
				return Soldier.attackRadius[2];
			}
			return Soldier.attackRadius[(int)(this.SoldierKind - 1)];
		}
	}

	// Token: 0x06002366 RID: 9062 RVA: 0x0040FD48 File Offset: 0x0040DF48
	protected void createShadow(float radius)
	{
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/shadow", out Soldier.shadowABKey, false);
		this.shadowObj = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
		this.shadowObj.transform.parent = this.transform;
		MeshFilter component = this.shadowObj.GetComponent<MeshFilter>();
		component.mesh = GameConstants.CreatePlane(this.transform.forward, this.transform.right, new Rect(0f, 0f, 1f, 1f), new Color(1f, 1f, 1f, 0.5f), radius);
	}

	// Token: 0x06002367 RID: 9063 RVA: 0x0040FDF4 File Offset: 0x0040DFF4
	public override void Destroy()
	{
		this.Target = null;
		base.Destroy();
	}

	// Token: 0x06002368 RID: 9064 RVA: 0x0040FE04 File Offset: 0x0040E004
	public override void Update(float delteTime)
	{
		if (this.ParticleFlag > 0)
		{
			ushort num = this.ParticleFlag;
			this.ParticleFlag = 0;
			if ((this.CurAnim != ESheetMeshAnim.die || this.DieState != 1) && this.Parent.particleManager != null)
			{
				if (num == 1)
				{
					num = (ushort)UnityEngine.Random.Range(2001, 2005);
				}
				this.Parent.particleManager.Spawn(num, null, this.hitPoint, 1f, true, false);
			}
		}
		base.Update(delteTime);
	}

	// Token: 0x06002369 RID: 9065 RVA: 0x0040FE94 File Offset: 0x0040E094
	public void ResetTarget(bool bResetSpread = false)
	{
		this.Target = null;
		this.SpreadPos = Vector3.zero;
		this.SpreadMode = ((!bResetSpread) ? this.SpreadMode : ESpreadMode.Enable);
	}

	// Token: 0x0600236A RID: 9066 RVA: 0x0040FECC File Offset: 0x0040E0CC
	public void AnimOnceNotify(ESheetMeshAnim finishAnim)
	{
		if (finishAnim == ESheetMeshAnim.die)
		{
			this.DieState = 1;
		}
		else if (this.CurFSM == EStateName.MELEE_FIGHT_IMMEDIATE)
		{
			this.FSMController = FSMManager.Instance.getState(EStateName.TRYFIGHT);
		}
		else if (this.SoldierKind == 4 && finishAnim == ESheetMeshAnim.attack && this.Parent != null)
		{
			int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
			int curLightmapIdx = 2 + sceneLightmapSize;
			this.Parent.resetLightmap(curLightmapIdx);
		}
	}

	// Token: 0x0600236B RID: 9067 RVA: 0x0040FF48 File Offset: 0x0040E148
	public void NotifyingParent(int param = 0)
	{
		if (this.pListener != null)
		{
			this.pListener((int)this.Index, param);
		}
	}

	// Token: 0x0600236C RID: 9068 RVA: 0x0040FF68 File Offset: 0x0040E168
	public virtual float LastAnimTime()
	{
		return this.lastTime;
	}

	// Token: 0x0600236D RID: 9069 RVA: 0x0040FF70 File Offset: 0x0040E170
	public virtual float CurAnimTime()
	{
		return this.time;
	}

	// Token: 0x0600236E RID: 9070 RVA: 0x0040FF78 File Offset: 0x0040E178
	public virtual void LordAnimSetting(byte type)
	{
	}

	// Token: 0x0600236F RID: 9071 RVA: 0x0040FF7C File Offset: 0x0040E17C
	public virtual Animation getAnimComponent()
	{
		return null;
	}

	// Token: 0x06002370 RID: 9072 RVA: 0x0040FF80 File Offset: 0x0040E180
	public virtual void ResetAnimToIdle()
	{
	}

	// Token: 0x06002371 RID: 9073 RVA: 0x0040FF84 File Offset: 0x0040E184
	public virtual void ResetAnimSettingToDefault()
	{
	}

	// Token: 0x06002372 RID: 9074 RVA: 0x0040FF88 File Offset: 0x0040E188
	public virtual void Reset()
	{
		this.DieState = 0;
		this.Flag = 0;
		this.speed = 1f;
		this.EnableShadow = true;
		this.ActionMode = EActionMode.Team;
		this.LastMovingFrame = 0;
		this.FSMController = FSMManager.Instance.getState(EStateName.IDLE);
	}

	// Token: 0x06002373 RID: 9075 RVA: 0x0040FFD4 File Offset: 0x0040E1D4
	public virtual void RunAnimSpeedUp()
	{
	}

	// Token: 0x04006C8B RID: 27787
	public static int shadowABKey = 0;

	// Token: 0x04006C8C RID: 27788
	protected GameObject shadowObj;

	// Token: 0x04006C8D RID: 27789
	public EActionMode ActionMode;

	// Token: 0x04006C8E RID: 27790
	public ArmyGroup Parent;

	// Token: 0x04006C8F RID: 27791
	public ushort Index;

	// Token: 0x04006C90 RID: 27792
	protected FSMUnit m_FSMController;

	// Token: 0x04006C91 RID: 27793
	public Vector3 SpreadPos = Vector3.zero;

	// Token: 0x04006C92 RID: 27794
	public ESpreadMode SpreadMode;

	// Token: 0x04006C93 RID: 27795
	public float DyingValue;

	// Token: 0x04006C94 RID: 27796
	public Vector3 LastTargetPos = Vector3.zero;

	// Token: 0x04006C95 RID: 27797
	public byte DieState;

	// Token: 0x04006C96 RID: 27798
	public EStateName CurFSM = EStateName.IDLE;

	// Token: 0x04006C97 RID: 27799
	public ushort ParticleFlag;

	// Token: 0x04006C98 RID: 27800
	public Vector3[] hitParticlePos = new Vector3[2];

	// Token: 0x04006C99 RID: 27801
	public byte hitParticleCount;

	// Token: 0x04006C9A RID: 27802
	public float Timer;

	// Token: 0x04006C9B RID: 27803
	public byte Flag;

	// Token: 0x04006C9C RID: 27804
	public byte SoldierKind;

	// Token: 0x04006C9D RID: 27805
	public byte SoldierTier;

	// Token: 0x04006C9E RID: 27806
	public ESheetMeshAnim lastAnim = ESheetMeshAnim.all;

	// Token: 0x04006C9F RID: 27807
	public float fightTimer;

	// Token: 0x04006CA0 RID: 27808
	public bool IsLord;

	// Token: 0x04006CA1 RID: 27809
	public bool IsHeroSoldier;

	// Token: 0x04006CA2 RID: 27810
	public int LastMovingFrame;

	// Token: 0x04006CA3 RID: 27811
	public bool bFakeSoldier;

	// Token: 0x04006CA4 RID: 27812
	public Vector3 Direction = Vector3.zero;

	// Token: 0x04006CA5 RID: 27813
	public bool bRotateDirty;

	// Token: 0x04006CA6 RID: 27814
	public byte CaptiveFlag;

	// Token: 0x04006CA7 RID: 27815
	public Vector3 CaptivePos = Vector3.zero;

	// Token: 0x04006CA8 RID: 27816
	protected Soldier m_Target;

	// Token: 0x04006CA9 RID: 27817
	public bool bNewTargetDirty;

	// Token: 0x04006CAA RID: 27818
	public float attackAnimSpeedRate;

	// Token: 0x04006CAB RID: 27819
	public static float ARCHER_HITTIME_INVERSE = 0.00125f;

	// Token: 0x04006CAC RID: 27820
	protected static readonly Vector3[,] rangeFirePoint;

	// Token: 0x04006CAD RID: 27821
	private static readonly Vector3[] hitPointOffset;

	// Token: 0x04006CAE RID: 27822
	private static readonly float[] attackRadius;

	// Token: 0x04006CAF RID: 27823
	private static readonly float[] hitRadius;

	// Token: 0x04006CB0 RID: 27824
	public Soldier.ParentListener pListener;

	// Token: 0x02000896 RID: 2198
	// (Invoke) Token: 0x06002DA0 RID: 11680
	public delegate void ParentListener(int idx, int param);
}
