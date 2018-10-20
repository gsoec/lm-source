using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x02000740 RID: 1856
public class WarCastle : ArmyGroup
{
	// Token: 0x06002390 RID: 9104 RVA: 0x00411C04 File Offset: 0x0040FE04
	public WarCastle(byte tier, Transform renderRoot, byte[] towerInfo)
	{
		this.groupRoot = new GameObject("Castle")
		{
			transform = 
			{
				position = new Vector3(55f, 0f, 15f),
				rotation = Quaternion.LookRotation(Vector3.left)
			}
		}.transform;
		this.buildCastleModel(tier, towerInfo);
		this.GroupKind = EGroupKind.CastleGate;
		this.m_State = ArmyGroup.EGROUPSTATE.IDLE;
	}

	// Token: 0x170000DF RID: 223
	// (get) Token: 0x06002391 RID: 9105 RVA: 0x0041203C File Offset: 0x0041023C
	// (set) Token: 0x06002392 RID: 9106 RVA: 0x00412044 File Offset: 0x00410244
	public override WarParticleManager particleManager
	{
		get
		{
			return this.particleMgr;
		}
		set
		{
			this.particleMgr = value;
			if (this.woodBehavior != null)
			{
				this.woodBehavior.particleManager = this.particleMgr;
			}
			if (this.suprsBehavior != null)
			{
				this.suprsBehavior.particleManager = this.particleMgr;
			}
		}
	}

	// Token: 0x170000E0 RID: 224
	// (get) Token: 0x06002393 RID: 9107 RVA: 0x00412090 File Offset: 0x00410290
	// (set) Token: 0x06002394 RID: 9108 RVA: 0x00412098 File Offset: 0x00410298
	public override int MaxHP
	{
		get
		{
			return this.m_HP;
		}
		set
		{
			this.m_HP = value;
			this.m_CurHP = this.m_HP;
		}
	}

	// Token: 0x170000E1 RID: 225
	// (get) Token: 0x06002395 RID: 9109 RVA: 0x004120B0 File Offset: 0x004102B0
	public override int CurHP
	{
		get
		{
			return this.m_CurHP;
		}
	}

	// Token: 0x170000E2 RID: 226
	// (set) Token: 0x06002396 RID: 9110 RVA: 0x004120B8 File Offset: 0x004102B8
	public override int GotHurt
	{
		set
		{
			this.m_CurHP -= value;
			this.m_CurHP = Mathf.Max(this.m_CurHP, 0);
		}
	}

	// Token: 0x06002397 RID: 9111 RVA: 0x004120E8 File Offset: 0x004102E8
	private void buildCastleModel(byte tier, byte[] towerInfo)
	{
		GameObject gameObject = new GameObject();
		this.castleRoot = gameObject.transform;
		this.castleRoot.parent = this.groupRoot;
		this.castleRoot.localPosition = Vector3.zero;
		tier *= 10;
		byte b = 1;
		Vector3 rotate = new Vector3(0f, 270f, 0f);
		this.StringInstance.Length = 0;
		this.StringInstance.AppendFormat("Role/Castle_{0:000}", (int)(tier + b));
		AssetBundle assetBundle = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
		if (assetBundle != null)
		{
			this.cacheBuild(this.loadModel(assetBundle, Vector3.zero, rotate), 4);
			this.cacheBuild(this.loadModel(assetBundle, new Vector3(0f, 0f, 0.1f), new Vector3(0f, 90f, 0f)), 5);
			this.bundleList[4] = assetBundle;
		}
		b += 1;
		this.StringInstance.Length = 0;
		this.StringInstance.AppendFormat("Role/Castle_{0:000}", (int)(tier + b));
		assetBundle = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
		if (assetBundle != null)
		{
			this.cacheBuild(this.loadModel(assetBundle, Vector3.zero, rotate), 6);
			this.bundleList[5] = assetBundle;
		}
		b += 1;
		for (int i = 0; i < 4; i++)
		{
			if (towerInfo[i] != 0)
			{
				byte b2 = towerInfo[i] - 1;
				if (this.bundleList[(int)b2] == null)
				{
					this.StringInstance.Length = 0;
					this.StringInstance.AppendFormat("Role/Castle_{0:000}", (int)(towerInfo[i] * 10 + b));
					this.bundleList[(int)b2] = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
				}
				GameObject gameObject2 = null;
				if (this.bundleList[(int)b2] != null)
				{
					gameObject2 = this.loadModel(this.bundleList[(int)b2], new Vector3(0f, 0f, this.TOWER_Y[i]), rotate);
					this.cacheBuild(gameObject2, (byte)(0 + i));
				}
				if (gameObject2 != null)
				{
					Vector3 vector = gameObject2.transform.position + new Vector3(-3f, 5f, -1f);
					this.towerFirePoint[i] = vector;
					this.ActiveTowerCount++;
				}
			}
		}
		b += 1;
		this.StringInstance.Length = 0;
		this.StringInstance.AppendFormat("Role/Castle_{0:000}", (int)(tier + b));
		assetBundle = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
		if (assetBundle != null)
		{
			for (int j = 0; j < 2; j++)
			{
				this.cacheBuild(this.loadModel(assetBundle, new Vector3(0f, 0f, this.ARCHER_Y[j]), rotate), (byte)(7 + j));
			}
			this.bundleList[6] = assetBundle;
		}
		b += 1;
		if (towerInfo[4] != 0)
		{
			this.StringInstance.Length = 0;
			this.StringInstance.AppendFormat("Role/Castle_{0:000}", (int)(towerInfo[4] * 10 + b));
			assetBundle = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
			if (assetBundle != null)
			{
				Vector3[] array = this.spursPosLowLv;
				if (towerInfo[4] == 2 || towerInfo[4] == 4)
				{
					array = this.spursPosHighLv;
				}
				for (int k = 0; k < 5; k++)
				{
					this.spursList[k] = this.loadModel(assetBundle, array[k], rotate).transform;
				}
				this.bundleList[7] = assetBundle;
			}
			if (towerInfo[4] == 2 || towerInfo[4] == 4)
			{
				this.suprsBehavior = new SuprsHighLv(this.spursPosHighLv);
			}
			else
			{
				this.suprsBehavior = new SuprsLowLv(this.spursPosLowLv);
			}
		}
		b += 1;
		if (towerInfo[5] != 0)
		{
			this.StringInstance.Length = 0;
			this.StringInstance.AppendFormat("Role/Castle_{0:000}", (int)(towerInfo[5] * 10 + b));
			assetBundle = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
			if (assetBundle != null)
			{
				byte b3 = (towerInfo[5] != 1 && towerInfo[5] != 3) ? 3 : 9;
				for (int l = 0; l < (int)b3; l++)
				{
					GameObject gameObject3 = this.loadModel(assetBundle, this.woodPos[l], rotate);
					this.woodList[l] = gameObject3.transform;
					gameObject3.SetActive(false);
				}
				this.bundleList[8] = assetBundle;
				this.woodBehavior = new WoodRun(this.woodPos, b3);
			}
		}
	}

	// Token: 0x06002398 RID: 9112 RVA: 0x004125D0 File Offset: 0x004107D0
	private GameObject loadModel(AssetBundle bundle, Vector3 pos, Vector3 rotate)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(bundle.mainAsset) as GameObject;
		int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
		int lightmapIndex = 2 + sceneLightmapSize;
		MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
		ESheetMeshTexKind kind = (!WarManager.IsNpcModeEnable) ? ESheetMeshTexKind.WAR_BLUE : ESheetMeshTexKind.WAR_GRAY;
		component.material = SheetAnimInfo.GetMaterial(kind);
		component.lightmapIndex = lightmapIndex;
		gameObject.transform.parent = this.castleRoot;
		gameObject.transform.localPosition = pos;
		gameObject.transform.Rotate(rotate);
		return gameObject;
	}

	// Token: 0x06002399 RID: 9113 RVA: 0x00412658 File Offset: 0x00410858
	private void cacheBuild(GameObject go, byte idx)
	{
		if (go != null && idx < 9)
		{
			this.buildList[(int)idx] = go.transform;
		}
	}

	// Token: 0x0600239A RID: 9114 RVA: 0x00412688 File Offset: 0x00410888
	public override void Update(float deltaTime, float moveDeltaTime)
	{
		if (this.m_State == ArmyGroup.EGROUPSTATE.DESTROYING)
		{
			float x = UnityEngine.Random.Range(-0.5f, 0.5f);
			float z = UnityEngine.Random.Range(-0.5f, 0.5f);
			float num = this.castleRoot.localPosition.y - deltaTime * 5.3f;
			this.castleRoot.localPosition = new Vector3(x, num, z);
			this.MoveSpeed += 30f * deltaTime;
			if (this.MoveSpeed <= 20f)
			{
				this.castleRoot.Rotate(0f, 0f, -30f * deltaTime);
			}
			if (num <= -16f)
			{
				this.m_State = ArmyGroup.EGROUPSTATE.DESTROYED;
			}
		}
		else
		{
			if (this.suprsBehavior != null)
			{
				this.suprsBehavior.Update(this.spursList, deltaTime);
			}
			if (this.woodBehavior != null)
			{
				this.woodBehavior.Update(this.woodList, deltaTime);
			}
			if (this.towerDisplayFlag != 0)
			{
				for (int i = 0; i < 4; i++)
				{
					if ((this.towerDisplayFlag >> i & 1) != 0)
					{
						Vector3 localPosition = this.buildList[i].localPosition;
						localPosition.y -= deltaTime * 5f;
						float x2 = UnityEngine.Random.Range(-0.5f, 0.5f);
						float num2 = UnityEngine.Random.Range(-0.5f, 0.5f);
						Vector3 localPosition2 = new Vector3(x2, localPosition.y, this.TOWER_Y[i] + num2);
						this.buildList[i].localPosition = localPosition2;
						this.buildList[i].Rotate(20f * deltaTime, 0f, 0f);
						if (localPosition.y <= -16f)
						{
							this.towerDisplayFlag ^= 1 << i;
						}
					}
				}
			}
		}
	}

	// Token: 0x0600239B RID: 9115 RVA: 0x0041286C File Offset: 0x00410A6C
	public override void Destroy()
	{
		for (int i = 0; i < 9; i++)
		{
			if (this.buildList[i] != null)
			{
				UnityEngine.Object.Destroy(this.buildList[i].gameObject);
			}
		}
		for (int j = 0; j < this.bundleList.Length; j++)
		{
			if (this.bundleList[j] != null)
			{
				this.bundleList[j].Unload(true);
			}
		}
		this.buildList = null;
		this.bundleList = null;
		if (this.castleRoot != null)
		{
			UnityEngine.Object.Destroy(this.castleRoot.gameObject);
		}
		this.suprsBehavior = null;
		this.woodBehavior = null;
		base.Destroy();
	}

	// Token: 0x0600239C RID: 9116 RVA: 0x00412930 File Offset: 0x00410B30
	public override void AllDie(int param = 0)
	{
		if (param == 0)
		{
			base.AllDie(0);
			for (int i = 0; i < this.spursList.Length; i++)
			{
				if (this.spursList[i] != null)
				{
					this.spursList[i].gameObject.SetActive(false);
				}
			}
			if (this.suprsBehavior != null)
			{
				this.suprsBehavior.setState(ETrapState.STOP);
			}
			if (this.woodBehavior != null)
			{
				this.woodBehavior.setState(ETrapState.STOP);
			}
			for (int j = 0; j < this.woodList.Length; j++)
			{
				if (this.woodList[j] != null)
				{
					this.woodList[j].gameObject.SetActive(false);
				}
			}
			Vector3 position = this.groupRoot.transform.position + new Vector3(-3f, 3f, 0f);
			this.particleManager.Spawn(2007, this.groupRoot, position, 1f, true, false);
			for (int k = 0; k < this.fireParticle.Count; k++)
			{
				this.particleManager.DeSpawn(this.fireParticle[k]);
			}
			this.fireParticle.Clear();
			if (this.FireSoundKey < 21)
			{
				AudioManager.Instance.StopSFX(this.FireSoundKey, true);
			}
			AudioManager.Instance.PlaySFX(20010, 0f, PitchKind.NoPitch, this.groupRoot, null);
			this.MoveSpeed = 0f;
			this.m_State = ArmyGroup.EGROUPSTATE.DESTROYING;
		}
		else if (param > 0 && param <= 4)
		{
			Vector3 position2 = this.buildList[param - 1].position;
			position2.y = 2f;
			position2.x -= 3f;
			position2.z -= 2f;
			GameObject gameObject = this.particleManager.Spawn(2008, this.buildList[param - 1], position2, 1f, true, false);
			if (gameObject != null)
			{
				this.fireParticle.Add(gameObject);
			}
			this.towerDisplayFlag |= 1 << param - 1;
			this.DestroyedTowerCount++;
			byte fireSoundKey = 0;
			if (this.FireSoundKey < 21)
			{
				AudioManager.Instance.PlaySFXLoop(20009, out fireSoundKey, this.groupRoot, SFXEffect.HighPassFilter, 0f);
				this.FireSoundKey = fireSoundKey;
			}
			AudioManager.Instance.SetFireSize((float)this.DestroyedTowerCount / (float)this.ActiveTowerCount);
		}
	}

	// Token: 0x0600239D RID: 9117 RVA: 0x00412BE0 File Offset: 0x00410DE0
	public override void FireRange(ArmyGroup targetGroup, FlyingObjectManager mgr, FOKind kind, float ms, ushort skillID, byte param = 0)
	{
		if (this.Target.GroupKind != EGroupKind.CastleGate && param > 0 && param <= 4)
		{
			int currentSoldierCount = this.Target.CurrentSoldierCount;
			for (int i = 0; i < 5; i++)
			{
				Vector3 begin = this.towerFirePoint[(int)(param - 1)] + this.towerFireOffset[i];
				int num = (i < currentSoldierCount) ? i : (currentSoldierCount - 1);
				mgr.addFlyingObject(kind, begin, this.Target.soldiers[num].transform, ms, new Vector3(0f, 1f, 0f), null, ChaseType.Straight, null);
			}
		}
	}

	// Token: 0x0600239E RID: 9118 RVA: 0x00412C9C File Offset: 0x00410E9C
	public override void Attack(ArmyGroup target, bool bForceRetarget = false, byte param = 0)
	{
		if (param == 5 && this.suprsBehavior != null)
		{
			this.suprsBehavior.setState(ETrapState.START);
		}
		if (param == 6 && this.woodBehavior != null)
		{
			this.woodBehavior.setState(ETrapState.START);
		}
	}

	// Token: 0x0600239F RID: 9119 RVA: 0x00412CE8 File Offset: 0x00410EE8
	public void cacheTrapHitPos(byte trapKind, ArmyGroup ag)
	{
		TrapBehavior trapBehavior = (trapKind != 0) ? this.woodBehavior : this.suprsBehavior;
		if (trapBehavior != null)
		{
			int currentSoldierCount = ag.CurrentSoldierCount;
			Vector3 vector = Vector3.zero;
			for (int i = 0; i < currentSoldierCount; i++)
			{
				vector += ag.soldiers[i].transform.position;
			}
			vector /= (float)currentSoldierCount;
			trapBehavior.targetPosCache.Add(vector);
		}
	}

	// Token: 0x060023A0 RID: 9120 RVA: 0x00412D60 File Offset: 0x00410F60
	public override void Reset()
	{
		this.groupRoot.gameObject.SetActive(true);
		this.castleRoot.localPosition = Vector3.zero;
		this.castleRoot.rotation = new Quaternion(0f, 0f, 0f, 1f);
		this.towerDisplayFlag = 0;
		for (int i = 0; i < 4; i++)
		{
			if (this.buildList[i] != null)
			{
				this.buildList[i].localPosition = new Vector3(0f, 0f, this.TOWER_Y[i]);
				this.buildList[i].rotation = new Quaternion(0f, 0f, 0f, 1f);
				this.buildList[i].Rotate(0f, 270f, 0f);
			}
		}
		for (int j = 0; j < this.fireParticle.Count; j++)
		{
			this.particleManager.DeSpawn(this.fireParticle[j]);
		}
		this.fireParticle.Clear();
		if (this.FireSoundKey < 21)
		{
			AudioManager.Instance.StopSFX(this.FireSoundKey, true);
		}
	}

	// Token: 0x04006D01 RID: 27905
	private StringBuilder StringInstance = new StringBuilder(64);

	// Token: 0x04006D02 RID: 27906
	public ArmyGroup[] archerDefenser;

	// Token: 0x04006D03 RID: 27907
	private Transform[] buildList = new Transform[9];

	// Token: 0x04006D04 RID: 27908
	private AssetBundle[] bundleList = new AssetBundle[9];

	// Token: 0x04006D05 RID: 27909
	private Transform[] spursList = new Transform[5];

	// Token: 0x04006D06 RID: 27910
	private Transform[] woodList = new Transform[9];

	// Token: 0x04006D07 RID: 27911
	private readonly float[] TOWER_Y = new float[]
	{
		11.62f,
		-11.62f,
		22.47f,
		-22.47f
	};

	// Token: 0x04006D08 RID: 27912
	private readonly float[] ARCHER_Y = new float[]
	{
		16.97f,
		-16.97f
	};

	// Token: 0x04006D09 RID: 27913
	private Vector3[] towerFirePoint = new Vector3[4];

	// Token: 0x04006D0A RID: 27914
	private readonly Vector3[] towerFireOffset = new Vector3[]
	{
		new Vector3(0f, 0f, 0f),
		new Vector3(0f, 0.5f, 0f),
		new Vector3(0f, -0.5f, 0f),
		new Vector3(0.5f, 0f, 0f),
		new Vector3(-0.5f, 0f, 0f)
	};

	// Token: 0x04006D0B RID: 27915
	private readonly Vector3[] spursPosLowLv = new Vector3[]
	{
		new Vector3(-0.75f, -6f, 0f),
		new Vector3(-0.75f, -6f, 9.13f),
		new Vector3(-0.75f, -6f, -9.13f),
		new Vector3(-0.75f, -6f, 18.26f),
		new Vector3(-0.75f, -6f, -18.26f)
	};

	// Token: 0x04006D0C RID: 27916
	private readonly Vector3[] spursPosHighLv = new Vector3[]
	{
		new Vector3(-6.75f, -5f, 0f),
		new Vector3(-8.47f, -5f, 9.13f),
		new Vector3(-9.34f, -5f, -9.13f),
		new Vector3(-5.14f, -5f, 18.26f),
		new Vector3(-6.75f, -5f, -18.26f)
	};

	// Token: 0x04006D0D RID: 27917
	private readonly Vector3[] woodPos = new Vector3[]
	{
		new Vector3(-2.5f, 6f, 0f),
		new Vector3(-2.5f, 6f, -12f),
		new Vector3(-2.5f, 6f, 12f),
		new Vector3(-2.5f, 6f, -3f),
		new Vector3(-2.5f, 6f, 3f),
		new Vector3(-2.5f, 6f, -15f),
		new Vector3(-2.5f, 6f, 15f),
		new Vector3(-2.5f, 6f, -9f),
		new Vector3(-2.5f, 6f, 9f)
	};

	// Token: 0x04006D0E RID: 27918
	private Transform castleRoot;

	// Token: 0x04006D0F RID: 27919
	private TrapBehavior suprsBehavior;

	// Token: 0x04006D10 RID: 27920
	private TrapBehavior woodBehavior;

	// Token: 0x04006D11 RID: 27921
	private List<GameObject> fireParticle = new List<GameObject>(4);

	// Token: 0x04006D12 RID: 27922
	private int towerDisplayFlag;

	// Token: 0x04006D13 RID: 27923
	private int ActiveTowerCount;

	// Token: 0x04006D14 RID: 27924
	private int DestroyedTowerCount;

	// Token: 0x04006D15 RID: 27925
	private byte FireSoundKey = 10;
}
