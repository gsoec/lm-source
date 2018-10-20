using System;
using UnityEngine;

// Token: 0x0200004E RID: 78
public class ChaseManager
{
	// Token: 0x06000217 RID: 535 RVA: 0x0001D218 File Offset: 0x0001B418
	private ChaseManager()
	{
		this.ChasePool = new ObjectPool<Chase>(new Chase(), (int)this.ChasePoolCont, false);
		this.UsedChaseArray = new Chase[(int)this.ChasePoolCont];
		this.Initial();
	}

	// Token: 0x06000219 RID: 537 RVA: 0x0001D268 File Offset: 0x0001B468
	private void Initial()
	{
		this.ChaseIndex = 0;
		this.StopAllChase = false;
	}

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x0600021A RID: 538 RVA: 0x0001D278 File Offset: 0x0001B478
	public static ChaseManager Instance
	{
		get
		{
			if (ChaseManager.instance == null)
			{
				ChaseManager.instance = new ChaseManager();
			}
			return ChaseManager.instance;
		}
	}

	// Token: 0x0600021B RID: 539 RVA: 0x0001D294 File Offset: 0x0001B494
	public void AddChase(Vector3 Source, Transform Target, float TotalTime, ushort ParticleID, float ParticleScale, ChaseType CurveType = ChaseType.Straight)
	{
		if (!this.GetEmptyObjectIdx())
		{
			return;
		}
		this.UsedChaseArray[(int)this.SelChaseIdx] = this.ChasePool.spawn();
		if (this.UsedChaseArray[(int)this.SelChaseIdx] != null)
		{
			this.UsedChaseArray[(int)this.SelChaseIdx].AddParticleChase(Source, Target.position, TotalTime, ParticleID, ParticleScale, CurveType);
		}
		if (this.UsedChaseArray[(int)this.SelChaseIdx].SourceObj == null)
		{
			this.ChasePool.despawn(this.UsedChaseArray[(int)this.SelChaseIdx]);
			this.UsedChaseArray[(int)this.SelChaseIdx] = null;
		}
	}

	// Token: 0x0600021C RID: 540 RVA: 0x0001D33C File Offset: 0x0001B53C
	public void AddChase(Vector3 Source, Vector3 Target, float TotalTime, ushort ParticleID, float ParticleScale, ChaseType CurveType = ChaseType.Straight)
	{
		if (!this.GetEmptyObjectIdx())
		{
			return;
		}
		this.UsedChaseArray[(int)this.SelChaseIdx] = this.ChasePool.spawn();
		if (this.UsedChaseArray[(int)this.SelChaseIdx] != null)
		{
			this.UsedChaseArray[(int)this.SelChaseIdx].AddParticleChase(Source, Target, TotalTime, ParticleID, ParticleScale, CurveType);
		}
		if (this.UsedChaseArray[(int)this.SelChaseIdx].SourceObj == null)
		{
			this.ChasePool.despawn(this.UsedChaseArray[(int)this.SelChaseIdx]);
			this.UsedChaseArray[(int)this.SelChaseIdx] = null;
		}
	}

	// Token: 0x0600021D RID: 541 RVA: 0x0001D3E0 File Offset: 0x0001B5E0
	private bool GetEmptyObjectIdx()
	{
		for (int i = 0; i < (int)this.ChasePoolCont; i++)
		{
			if (this.UsedChaseArray[(int)this.ChaseIndex] == null)
			{
				this.SelChaseIdx = this.ChaseIndex;
				this.ChaseIndex += 1;
				if (this.ChaseIndex >= this.ChasePoolCont)
				{
					this.ChaseIndex = 0;
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600021E RID: 542 RVA: 0x0001D44C File Offset: 0x0001B64C
	public void Clear()
	{
		for (int i = 0; i < (int)this.ChasePoolCont; i++)
		{
			if (this.UsedChaseArray[i] != null)
			{
				this.UsedChaseArray[i].StopParticle();
				this.ChasePool.despawn(this.UsedChaseArray[i]);
				this.UsedChaseArray[i] = null;
			}
		}
	}

	// Token: 0x0600021F RID: 543 RVA: 0x0001D4A8 File Offset: 0x0001B6A8
	public void Update()
	{
		if (this.StopAllChase)
		{
			return;
		}
		for (int i = 0; i < (int)this.ChasePoolCont; i++)
		{
			if (this.UsedChaseArray[i] != null)
			{
				if (this.UsedChaseArray[i].bMove)
				{
					this.UsedChaseArray[i].Update();
				}
				else
				{
					this.ChasePool.despawn(this.UsedChaseArray[i]);
					this.UsedChaseArray[i] = null;
				}
			}
		}
	}

	// Token: 0x06000220 RID: 544 RVA: 0x0001D528 File Offset: 0x0001B728
	public void DestroyAll()
	{
		for (int i = 0; i < (int)this.ChasePoolCont; i++)
		{
			this.UsedChaseArray[i] = null;
		}
		ChaseManager.instance = null;
	}

	// Token: 0x06000221 RID: 545 RVA: 0x0001D55C File Offset: 0x0001B75C
	public void SetStopAllParticleChase(bool Stop)
	{
		this.StopAllChase = Stop;
		for (int i = 0; i < (int)this.ChasePoolCont; i++)
		{
			if (this.UsedChaseArray[i] != null)
			{
				ParticleManager.Instance.Pause(this.UsedChaseArray[i].SourceObj, Stop);
			}
		}
	}

	// Token: 0x0400040D RID: 1037
	private Chase[] UsedChaseArray;

	// Token: 0x0400040E RID: 1038
	private ushort ChasePoolCont = 50;

	// Token: 0x0400040F RID: 1039
	private ushort ChaseIndex;

	// Token: 0x04000410 RID: 1040
	private static ChaseManager instance;

	// Token: 0x04000411 RID: 1041
	private bool StopAllChase;

	// Token: 0x04000412 RID: 1042
	public ObjectPool<Chase> ChasePool;

	// Token: 0x04000413 RID: 1043
	private ushort SelChaseIdx;
}
