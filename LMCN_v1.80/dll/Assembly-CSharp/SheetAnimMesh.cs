using System;
using UnityEngine;

// Token: 0x02000736 RID: 1846
public class SheetAnimMesh
{
	// Token: 0x0600234A RID: 9034 RVA: 0x0040F080 File Offset: 0x0040D280
	protected SheetAnimMesh()
	{
	}

	// Token: 0x0600234B RID: 9035 RVA: 0x0040F09C File Offset: 0x0040D29C
	public SheetAnimMesh(EWarMeshKind meshKind, byte kind, byte tier, byte texNo = 0)
	{
		if (meshKind == EWarMeshKind.SOLDIER)
		{
			if (texNo == 3)
			{
				this.m_ModelID = this.createBuild(kind, tier);
			}
			else
			{
				this.m_ModelID = this.createActor(kind, tier, texNo);
			}
		}
		else if (meshKind == EWarMeshKind.FO)
		{
			this.m_ModelID = this.createFO(kind, tier);
		}
		this.stepIndex = 1;
		this.curAnim = ESheetMeshAnim.moving;
		if (meshKind == EWarMeshKind.SOLDIER && texNo != 3)
		{
			this.PlayAnim(ESheetMeshAnim.idle, SAWrapMode.Loop, true, false, false);
		}
		else
		{
			this.IsPlaying = false;
		}
	}

	// Token: 0x170000CD RID: 205
	// (get) Token: 0x0600234C RID: 9036 RVA: 0x0040F140 File Offset: 0x0040D340
	public GameObject gameObject
	{
		get
		{
			return this.transform ? this.transform.gameObject : null;
		}
	}

	// Token: 0x0600234D RID: 9037 RVA: 0x0040F164 File Offset: 0x0040D364
	private Material TexNoToMat(int TexID)
	{
		if (TexID >= 3)
		{
			return null;
		}
		return SheetAnimInfo.GetMaterial((ESheetMeshTexKind)TexID);
	}

	// Token: 0x0600234E RID: 9038 RVA: 0x0040F178 File Offset: 0x0040D378
	private ushort createActor(byte kind, byte tier, byte texNo)
	{
		ushort num = (ushort)(kind * 10 + tier);
		if (!SheetAnimInfo.Instance.containMesh(num))
		{
			SheetAnimInfo.Instance.createMesh(num);
		}
		this.MainObj = new GameObject("AnimMesh");
		this.meshShower = this.MainObj.AddComponent<MeshFilter>();
		MeshRenderer meshRenderer = this.MainObj.AddComponent<MeshRenderer>();
		meshRenderer.castShadows = false;
		meshRenderer.receiveShadows = false;
		meshRenderer.sharedMaterial = this.TexNoToMat((int)texNo);
		this.meshRenderer = meshRenderer.renderer;
		this.transform = this.MainObj.transform;
		sAnimInfo animInfo = SheetAnimInfo.Instance.getAnimInfo(num, 0);
		if (animInfo.animMesh != null)
		{
			this.keyframeCount = animInfo.keyframeCount;
			this.curAnimMesh = animInfo.animMesh;
			this.animLength = animInfo.animLength;
		}
		return num;
	}

	// Token: 0x0600234F RID: 9039 RVA: 0x0040F250 File Offset: 0x0040D450
	private ushort createFO(byte kind, byte tier)
	{
		ushort num = (ushort)(kind * 10 + tier);
		if (!SheetAnimInfo.Instance.containMesh(num * 10))
		{
			SheetAnimInfo.Instance.createAnimFO(num);
		}
		this.MainObj = new GameObject("AnimFO");
		this.meshShower = this.MainObj.AddComponent<MeshFilter>();
		MeshRenderer meshRenderer = this.MainObj.AddComponent<MeshRenderer>();
		meshRenderer.castShadows = false;
		meshRenderer.receiveShadows = false;
		meshRenderer.sharedMaterial = SheetAnimInfo.GetMaterial(ESheetMeshTexKind.WAR_BLUE);
		this.meshRenderer = meshRenderer.renderer;
		this.transform = this.MainObj.transform;
		sAnimInfo animFOInfo = SheetAnimInfo.Instance.getAnimFOInfo(num);
		if (animFOInfo.animMesh != null)
		{
			this.keyframeCount = animFOInfo.keyframeCount;
			this.curAnimMesh = animFOInfo.animMesh;
			this.animLength = animFOInfo.animLength;
		}
		return num;
	}

	// Token: 0x06002350 RID: 9040 RVA: 0x0040F328 File Offset: 0x0040D528
	private ushort createBuild(byte kind, byte tier)
	{
		ushort num = (ushort)(kind * 10 + tier);
		if (!SheetAnimInfo.Instance.containMesh(num * 10))
		{
			SheetAnimInfo.Instance.createCastleGate(num);
		}
		this.MainObj = new GameObject("Build");
		this.meshShower = this.MainObj.AddComponent<MeshFilter>();
		MeshRenderer meshRenderer = this.MainObj.AddComponent<MeshRenderer>();
		meshRenderer.castShadows = false;
		meshRenderer.receiveShadows = false;
		meshRenderer.sharedMaterial = SheetAnimInfo.GetMaterial(ESheetMeshTexKind.WAR_BLUE);
		this.meshRenderer = meshRenderer.renderer;
		this.transform = this.MainObj.transform;
		sAnimInfo buildMesh = SheetAnimInfo.Instance.getBuildMesh(num);
		if (buildMesh.animMesh != null)
		{
			this.keyframeCount = buildMesh.keyframeCount;
			this.curAnimMesh = buildMesh.animMesh;
			this.animLength = buildMesh.animLength;
		}
		return num;
	}

	// Token: 0x06002351 RID: 9041 RVA: 0x0040F400 File Offset: 0x0040D600
	public virtual bool PlayAnim(ESheetMeshAnim eAnim, SAWrapMode mode = SAWrapMode.Loop, bool bRandomStartPoint = true, bool bForceReset = false, bool bBrokenFO = false)
	{
		if (eAnim != this.curAnim || !this.IsPlaying || this.playMode != mode)
		{
			sAnimInfo sAnimInfo;
			if (!bBrokenFO)
			{
				sAnimInfo = SheetAnimInfo.Instance.getAnimInfo(this.m_ModelID, (ushort)eAnim);
			}
			else
			{
				sAnimInfo = SheetAnimInfo.Instance.getAnimFOInfo(this.m_ModelID);
			}
			if (sAnimInfo.animMesh != null)
			{
				this.keyframeCount = sAnimInfo.keyframeCount;
				this.curAnimMesh = sAnimInfo.animMesh;
				this.animLength = sAnimInfo.animLength;
				this.m_DeltaTime = 0f;
				this.time = 0f;
				this.lastTime = 0f;
				this.stepIndex = ((!bRandomStartPoint) ? 1 : UnityEngine.Random.Range(1, (int)((float)this.keyframeCount * 0.5f)));
				this.meshShower.mesh = this.curAnimMesh[0];
				this.curAnim = eAnim;
				this.playMode = mode;
				this.IsPlaying = true;
			}
			else
			{
				this.IsPlaying = false;
			}
			return true;
		}
		if (bForceReset)
		{
			this.m_DeltaTime = 0f;
			this.time = 0f;
			this.lastTime = 0f;
			this.stepIndex = 1;
			this.meshShower.mesh = this.curAnimMesh[0];
			return true;
		}
		return false;
	}

	// Token: 0x06002352 RID: 9042 RVA: 0x0040F554 File Offset: 0x0040D754
	public virtual void Destroy()
	{
		this.transform = null;
		this.curAnimMesh = null;
		if (this.meshShower != null)
		{
			this.meshShower.mesh = null;
		}
		if (this.MainObj != null)
		{
			UnityEngine.Object.Destroy(this.MainObj);
			this.MainObj = null;
		}
	}

	// Token: 0x06002353 RID: 9043 RVA: 0x0040F5B0 File Offset: 0x0040D7B0
	public virtual void SampleAnimation(ESheetMeshAnim eAnim, float sampleTime)
	{
		this.PlayAnim(eAnim, SAWrapMode.Loop, false, false, false);
		this.IsPlaying = false;
		this.m_DeltaTime += sampleTime;
		this.lastTime = this.time;
		this.time += sampleTime;
		if (this.m_DeltaTime >= 0.025f)
		{
			float num = (this.m_DeltaTime - 0.025f) * 40f;
			this.stepIndex += (int)num + 1;
			if (this.stepIndex > this.keyframeCount)
			{
				this.stepIndex -= this.keyframeCount;
				if (this.stepIndex > this.keyframeCount)
				{
					this.stepIndex %= this.keyframeCount;
					this.stepIndex = Mathf.Max(this.stepIndex, 1);
				}
				this.time = 0f;
				this.lastTime = 0f;
			}
			this.fixedDeltaTime = this.m_DeltaTime - (0.025f + (float)((int)num) * 0.025f);
			this.m_DeltaTime = this.fixedDeltaTime;
			this.meshShower.mesh = this.curAnimMesh[this.stepIndex - 1];
		}
	}

	// Token: 0x06002354 RID: 9044 RVA: 0x0040F6E0 File Offset: 0x0040D8E0
	public virtual void Update(float delteTime)
	{
		if (!this.IsPlaying)
		{
			return;
		}
		delteTime *= this.speed;
		this.m_DeltaTime += delteTime;
		this.lastTime = this.time;
		this.time += delteTime;
		if (this.m_DeltaTime >= 0.025f)
		{
			float num = (this.m_DeltaTime - 0.025f) * 40f;
			this.stepIndex += (int)num + 1;
			if (this.stepIndex > this.keyframeCount)
			{
				if (this.playMode != SAWrapMode.Loop)
				{
					if (this.playMode == SAWrapMode.Once)
					{
						this.meshShower.mesh = this.curAnimMesh[this.keyframeCount - 1];
						this.IsPlaying = false;
						if (this.animNotify != null)
						{
							this.animNotify(this.curAnim);
						}
						return;
					}
					if (this.playMode == SAWrapMode.Default)
					{
						ESheetMeshAnim finishAnim = this.curAnim;
						this.PlayAnim(ESheetMeshAnim.idle, SAWrapMode.Loop, true, false, false);
						if (this.animNotify != null)
						{
							this.animNotify(finishAnim);
						}
					}
				}
				else
				{
					ESheetMeshAnim esheetMeshAnim = this.curAnim;
					this.stepIndex -= this.keyframeCount;
					if (this.stepIndex > this.keyframeCount)
					{
						this.stepIndex %= this.keyframeCount;
						this.stepIndex = Mathf.Max(this.stepIndex, 1);
					}
					this.time = 0f;
					this.lastTime = 0f;
				}
			}
			this.fixedDeltaTime = this.m_DeltaTime - (0.025f + (float)((int)num) * 0.025f);
			this.m_DeltaTime = this.fixedDeltaTime;
			this.meshShower.mesh = this.curAnimMesh[this.stepIndex - 1];
		}
	}

	// Token: 0x04006C71 RID: 27761
	public const float TIMESTEP = 0.025f;

	// Token: 0x04006C72 RID: 27762
	public const float INVERSE_TIMESTEP = 40f;

	// Token: 0x04006C73 RID: 27763
	public int keyframeCount;

	// Token: 0x04006C74 RID: 27764
	public MeshFilter meshShower;

	// Token: 0x04006C75 RID: 27765
	protected float animLength;

	// Token: 0x04006C76 RID: 27766
	public int stepIndex;

	// Token: 0x04006C77 RID: 27767
	public float m_DeltaTime;

	// Token: 0x04006C78 RID: 27768
	public float fixedDeltaTime;

	// Token: 0x04006C79 RID: 27769
	public Mesh[] curAnimMesh;

	// Token: 0x04006C7A RID: 27770
	protected ESheetMeshAnim curAnim;

	// Token: 0x04006C7B RID: 27771
	public ushort m_ModelID;

	// Token: 0x04006C7C RID: 27772
	public Transform transform;

	// Token: 0x04006C7D RID: 27773
	public bool IsPlaying = true;

	// Token: 0x04006C7E RID: 27774
	public SAWrapMode playMode;

	// Token: 0x04006C7F RID: 27775
	protected Renderer meshRenderer;

	// Token: 0x04006C80 RID: 27776
	private GameObject MainObj;

	// Token: 0x04006C81 RID: 27777
	protected float time;

	// Token: 0x04006C82 RID: 27778
	protected float lastTime;

	// Token: 0x04006C83 RID: 27779
	public float speed = 1f;

	// Token: 0x04006C84 RID: 27780
	public SheetAnimMesh.AnimNotify animNotify;

	// Token: 0x02000895 RID: 2197
	// (Invoke) Token: 0x06002D9C RID: 11676
	public delegate void AnimNotify(ESheetMeshAnim finishAnim);
}
