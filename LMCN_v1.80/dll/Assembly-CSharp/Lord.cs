using System;
using System.Text;
using UnityEngine;

// Token: 0x0200073A RID: 1850
public class Lord : Soldier
{
	// Token: 0x06002374 RID: 9076 RVA: 0x0040FFD8 File Offset: 0x0040E1D8
	public Lord(ushort heroID, byte kind, byte tier, byte side, bool isLord, byte param = 0)
	{
		uint num = (uint)((uint)heroID << 16);
		int num2 = (int)(side | ((!isLord) ? 0 : 2));
		num |= (uint)((uint)num2 << 8);
		GameObject gameObject = new GameObject((num | (uint)param).ToString());
		this.transform = gameObject.transform;
		StringBuilder stringBuilder = new StringBuilder(64);
		stringBuilder.Length = 0;
		this.lordID = heroID;
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(heroID);
		stringBuilder.AppendFormat("Role/hero_{0:00000}", recordByKey.Modle);
		AssetBundle assetBundle = AssetManager.GetAssetBundle(stringBuilder.ToString(), out this.assetKey, false);
		GameObject gameObject2 = ModelLoader.Instance.Load(recordByKey.Modle, assetBundle, (ushort)recordByKey.TextureNo);
		this.modelTrans = gameObject2.transform;
		this.modelTrans.parent = this.transform;
		this.lordScale = Lord.constLordScale * ((float)recordByKey.Scale * 0.01f);
		this.modelTrans.localScale = this.lordScale;
		this.modelTrans.position = Vector3.zero;
		this.skinRenderer = gameObject2.GetComponentInChildren<SkinnedMeshRenderer>();
		this.animComponent = gameObject2.GetComponent<Animation>();
		AnimationState animationState = this.animComponent["idle"];
		animationState.wrapMode = WrapMode.Loop;
		animationState.layer = 0;
		if (this.animComponent.GetClip("moving") == null)
		{
			AnimationClip clip = this.animComponent.GetClip("idle");
			this.animComponent.AddClip(clip, "moving");
		}
		animationState = this.animComponent["moving"];
		animationState.layer = 0;
		animationState.wrapMode = WrapMode.Loop;
		animationState = this.animComponent["attack"];
		if (kind == 1 || kind == 3)
		{
			animationState.layer = 0;
			animationState.wrapMode = WrapMode.Loop;
			this.FreezeLen = Mathf.Clamp(animationState.length * 0.2f, 0.1f, 0.2f);
			this.FreezePoint = (float)recordByKey.HeroAttackInfo[0].HitTime * 0.001f;
		}
		else
		{
			animationState.layer = 1;
			if (kind == 2)
			{
				float num3 = (float)recordByKey.HeroAttackInfo[0].HitTime;
				this.attackAnimSpeedRate = num3 * Soldier.ARCHER_HITTIME_INVERSE;
				animationState.speed = this.attackAnimSpeedRate;
			}
		}
		animationState = this.animComponent["daze"];
		animationState.wrapMode = WrapMode.Loop;
		animationState.layer = 1;
		Transform[] componentsInChildren = gameObject2.GetComponentsInChildren<Transform>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].name == AnimationUnit.HIT_POINT_ROOTBONE)
			{
				this.HitPointRoot = componentsInChildren[i];
			}
			else if (componentsInChildren[i].name == AnimationUnit.FLY_WEAPON_ROOTBONE)
			{
				this.WPRoot = componentsInChildren[i];
			}
		}
		if (this.HitPointRoot == null)
		{
			this.HitPointRoot = this.modelTrans;
		}
		if (this.WPRoot == null)
		{
			this.WPRoot = this.modelTrans;
		}
		this.SoldierKind = kind;
		this.SoldierTier = tier;
		this.IsHeroSoldier = true;
		base.createShadow((float)recordByKey.Radius * 0.01f * 3f);
	}

	// Token: 0x170000D9 RID: 217
	// (get) Token: 0x06002376 RID: 9078 RVA: 0x00410374 File Offset: 0x0040E574
	public override Vector3 RangeFirePoint
	{
		get
		{
			return this.WPRoot.position;
		}
	}

	// Token: 0x170000DA RID: 218
	// (get) Token: 0x06002377 RID: 9079 RVA: 0x00410384 File Offset: 0x0040E584
	public override ESheetMeshAnim CurAnim
	{
		get
		{
			return ESheetMeshAnim.idle;
		}
	}

	// Token: 0x170000DB RID: 219
	// (get) Token: 0x06002378 RID: 9080 RVA: 0x00410388 File Offset: 0x0040E588
	public override float AnimLength
	{
		get
		{
			return this.animComponent[this.lastAnim.ToString()].length;
		}
	}

	// Token: 0x170000DC RID: 220
	// (get) Token: 0x06002379 RID: 9081 RVA: 0x004103B8 File Offset: 0x0040E5B8
	public override Renderer renderer
	{
		get
		{
			return this.skinRenderer;
		}
	}

	// Token: 0x0600237A RID: 9082 RVA: 0x004103C0 File Offset: 0x0040E5C0
	public override void Destroy()
	{
		if (this.animComponent != null)
		{
			ModelLoader.Instance.Unload(this.animComponent.gameObject);
			AssetManager.UnloadAssetBundle(this.assetKey, true);
		}
		base.Target = null;
		base.Destroy();
	}

	// Token: 0x0600237B RID: 9083 RVA: 0x0041040C File Offset: 0x0040E60C
	public override void Update(float delteTime)
	{
		float? num = this.extraLordScale;
		if (num != null)
		{
			if (this.extraLordScale.Value <= 1f)
			{
				this.modelTrans.localScale = this.lordScale;
				this.extraLordScale = null;
			}
			else if (this.bExtraScaleWork)
			{
				this.modelTrans.localScale = this.lordScale * this.extraLordScale.Value;
				float? num2 = this.extraLordScale;
				this.extraLordScale = ((num2 == null) ? null : new float?(num2.Value - delteTime * 2f));
			}
		}
		float? num3 = this.specHitPoint;
		if (num3 != null)
		{
			float num4 = this.specHitPointCounter;
			this.specHitPointCounter += delteTime;
			if (num4 < this.specHitPoint.Value && this.specHitPointCounter >= this.specHitPoint.Value)
			{
				this.specHitPointCounter = 0f;
				this.specHitPoint = null;
			}
		}
		if (this.ParticleFlag > 0)
		{
			ushort num5 = this.ParticleFlag;
			this.ParticleFlag = 0;
			if ((this.CurAnim != ESheetMeshAnim.die || this.DieState != 1) && this.Parent.particleManager != null)
			{
				if (num5 == 1)
				{
					num5 = (ushort)UnityEngine.Random.Range(2001, 2005);
				}
				this.Parent.particleManager.Spawn(num5, null, base.hitPoint, 1f, true, false);
			}
		}
		if (this.animComponent != null)
		{
			if (this.CurFSM == EStateName.MELEE_FIGHT_IMMEDIATE && !this.animComponent.IsPlaying("attack"))
			{
				base.AnimOnceNotify(ESheetMeshAnim.attack);
			}
			else if (!this.animComponent.isPlaying && this.lastAnim != ESheetMeshAnim.die)
			{
				this.animComponent.CrossFade("idle");
			}
			if (this.bCheckHitPoint)
			{
				float time = this.animComponent["attack"].time;
				if (this.FreezePoint >= this.lastTime && this.FreezePoint <= time)
				{
					this.animComponent["attack"].speed = 0f;
					this.bHitPointFreezeWork = true;
					this.bCheckHitPoint = false;
					this.FreezeCounter = 0f;
				}
				this.lastTime = time;
			}
			if (this.bHitPointFreezeWork)
			{
				if (this.FreezeCounter >= this.FreezeLen)
				{
					this.animComponent["attack"].speed = 1f;
					this.bHitPointFreezeWork = false;
				}
				else
				{
					this.FreezeCounter += delteTime;
				}
			}
		}
	}

	// Token: 0x0600237C RID: 9084 RVA: 0x004106E4 File Offset: 0x0040E8E4
	public Vector3 GetHitPoint()
	{
		return this.HitPointRoot.position;
	}

	// Token: 0x0600237D RID: 9085 RVA: 0x004106F4 File Offset: 0x0040E8F4
	public Transform GetHitPointTrans()
	{
		return this.HitPointRoot;
	}

	// Token: 0x0600237E RID: 9086 RVA: 0x004106FC File Offset: 0x0040E8FC
	public override bool PlayAnim(ESheetMeshAnim eAnim, SAWrapMode mode = SAWrapMode.Loop, bool bRandomStartPoint = true, bool bForceReset = false, bool bBrokenFO = false)
	{
		if (!(this.animComponent != null))
		{
			return false;
		}
		if (!bForceReset && this.lastAnim == ESheetMeshAnim.die)
		{
			return false;
		}
		mode = ((eAnim != ESheetMeshAnim.die) ? mode : SAWrapMode.Once);
		this.animComponent[eAnim.ToString()].wrapMode = ((mode != SAWrapMode.Loop) ? WrapMode.Once : WrapMode.Loop);
		if (eAnim == ESheetMeshAnim.attack)
		{
			this.animComponent.CrossFade("idle");
		}
		if (eAnim == ESheetMeshAnim.die && this.IsLord && (!WarManager.IsNpcModeEnable || this.Parent == null || this.Parent.Side == 0))
		{
			this.animComponent.CrossFade("daze");
		}
		else if (eAnim == ESheetMeshAnim.attack && this.animComponent.IsPlaying("attack"))
		{
			AnimationState animationState = this.animComponent.CrossFadeQueued("attack", 0.3f, QueueMode.PlayNow);
			animationState.speed = ((this.attackAnimSpeedRate <= 0.001f) ? 1f : this.attackAnimSpeedRate);
			this.bCheckHitPoint = true;
			this.lastTime = 0f;
		}
		else
		{
			if (eAnim == ESheetMeshAnim.attack)
			{
				this.animComponent["attack"].speed = 1f;
				this.bCheckHitPoint = true;
				this.lastTime = 0f;
			}
			if (eAnim == ESheetMeshAnim.die)
			{
				this.animComponent.CrossFade(eAnim.ToString(), 0.1f, PlayMode.StopAll);
			}
			else
			{
				this.animComponent.CrossFade(eAnim.ToString());
			}
		}
		this.lastAnim = eAnim;
		this.bExtraScaleWork = true;
		return true;
	}

	// Token: 0x0600237F RID: 9087 RVA: 0x004108BC File Offset: 0x0040EABC
	public void PlaySkillAnim(ushort skillID)
	{
		if (this.animComponent == null)
		{
			return;
		}
		Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
		int num = 2;
		AnimationClip clip = this.animComponent.GetClip(AnimationUnit.ANIM_STRING[num + (int)recordByKey.StateAddition]);
		if (clip != null)
		{
			string animation = AnimationUnit.ANIM_STRING[num + (int)recordByKey.StateAddition];
			this.animComponent.CrossFade("idle");
			AnimationState animationState = this.animComponent.CrossFadeQueued(animation, 0.1f, QueueMode.PlayNow);
			animationState.layer = 1;
			animationState.wrapMode = WrapMode.Default;
			ushort num2 = (ushort)(animationState.length * 1000f);
			if (num2 != 0 && num2 != recordByKey.StateValue)
			{
				float num3 = (float)((recordByKey.StateValue != 0) ? recordByKey.StateValue : num2);
				float speed = (float)num2 / num3;
				animationState.speed = speed;
				this.specHitPoint = new float?((float)recordByKey.StateIncreaseValue * 0.001f);
			}
			this.lastAnim = ESheetMeshAnim.attack;
			this.extraLordScale = new float?(1.5f);
			this.modelTrans.localScale = this.lordScale * this.extraLordScale.Value;
			this.bExtraScaleWork = false;
		}
	}

	// Token: 0x06002380 RID: 9088 RVA: 0x00410A04 File Offset: 0x0040EC04
	public override void SampleAnimation(ESheetMeshAnim eAnim, float sampleTime)
	{
		if (this.animComponent != null)
		{
			this.animComponent.Stop();
			this.animComponent.CrossFade("idle");
		}
	}

	// Token: 0x06002381 RID: 9089 RVA: 0x00410A40 File Offset: 0x0040EC40
	public override void LordAnimSetting(byte type)
	{
		if (this.animComponent == null)
		{
			return;
		}
		if (type == 0)
		{
			this.animComponent["victory"].wrapMode = WrapMode.Default;
			this.animComponent["victory"].layer = 1;
		}
		else if (type == 1)
		{
			this.animComponent["victory"].wrapMode = WrapMode.Loop;
			this.animComponent["victory"].layer = 1;
		}
		else if (type == 2)
		{
			this.animComponent["victory"].wrapMode = WrapMode.Loop;
			this.animComponent["victory"].layer = 0;
		}
		this.animComponent["idle"].wrapMode = WrapMode.Loop;
		this.animComponent["idle"].layer = 0;
	}

	// Token: 0x06002382 RID: 9090 RVA: 0x00410B30 File Offset: 0x0040ED30
	public override Animation getAnimComponent()
	{
		return this.animComponent;
	}

	// Token: 0x06002383 RID: 9091 RVA: 0x00410B38 File Offset: 0x0040ED38
	public override void ResetAnimToIdle()
	{
		if (this.animComponent != null)
		{
			this.animComponent.Stop();
			this.animComponent["idle"].wrapMode = WrapMode.Loop;
			this.animComponent.CrossFade("idle", 0.3f, PlayMode.StopSameLayer);
			this.lastAnim = ESheetMeshAnim.idle;
		}
	}

	// Token: 0x06002384 RID: 9092 RVA: 0x00410B94 File Offset: 0x0040ED94
	public override void ResetAnimSettingToDefault()
	{
		AnimationState animationState = this.animComponent["idle"];
		animationState.wrapMode = WrapMode.Loop;
		animationState.layer = 0;
		animationState = this.animComponent["moving"];
		animationState.layer = 0;
		animationState.speed = 1f;
		animationState.wrapMode = WrapMode.Loop;
		animationState = this.animComponent["attack"];
		if (this.SoldierKind == 1 || this.SoldierKind == 3)
		{
			animationState.layer = 0;
			animationState.wrapMode = WrapMode.Loop;
			animationState.speed = 1f;
		}
		else
		{
			animationState.layer = 1;
			if (this.SoldierKind == 2)
			{
				float num = (float)DataManager.Instance.HeroTable.GetRecordByKey(this.Parent.heroSoldierID).HeroAttackInfo[0].HitTime;
				this.attackAnimSpeedRate = num * Soldier.ARCHER_HITTIME_INVERSE;
				animationState.speed = this.attackAnimSpeedRate;
			}
		}
		animationState = this.animComponent["daze"];
		animationState.wrapMode = WrapMode.Loop;
		animationState.layer = 1;
	}

	// Token: 0x06002385 RID: 9093 RVA: 0x00410CAC File Offset: 0x0040EEAC
	public override void RunAnimSpeedUp()
	{
		this.animComponent["moving"].speed = 2f;
	}

	// Token: 0x04006CB1 RID: 27825
	public const int constLordScaleVal = 3;

	// Token: 0x04006CB2 RID: 27826
	private const float constLordSkilllScale = 1.5f;

	// Token: 0x04006CB3 RID: 27827
	public Animation animComponent;

	// Token: 0x04006CB4 RID: 27828
	public SkinnedMeshRenderer skinRenderer;

	// Token: 0x04006CB5 RID: 27829
	public int assetKey;

	// Token: 0x04006CB6 RID: 27830
	public ushort lordID;

	// Token: 0x04006CB7 RID: 27831
	public float? specHitPoint;

	// Token: 0x04006CB8 RID: 27832
	public float specHitPointCounter;

	// Token: 0x04006CB9 RID: 27833
	private static readonly Vector3 constLordScale = new Vector3(3f, 3f, 3f);

	// Token: 0x04006CBA RID: 27834
	public float? extraLordScale;

	// Token: 0x04006CBB RID: 27835
	public bool bExtraScaleWork = true;

	// Token: 0x04006CBC RID: 27836
	public Vector3 lordScale = Vector3.one;

	// Token: 0x04006CBD RID: 27837
	public Transform modelTrans;

	// Token: 0x04006CBE RID: 27838
	public Transform HitPointRoot;

	// Token: 0x04006CBF RID: 27839
	public Transform WPRoot;

	// Token: 0x04006CC0 RID: 27840
	public bool bCheckHitPoint;

	// Token: 0x04006CC1 RID: 27841
	public bool bHitPointFreezeWork;

	// Token: 0x04006CC2 RID: 27842
	public float FreezePoint;

	// Token: 0x04006CC3 RID: 27843
	public float FreezeLen;

	// Token: 0x04006CC4 RID: 27844
	public float FreezeCounter;
}
