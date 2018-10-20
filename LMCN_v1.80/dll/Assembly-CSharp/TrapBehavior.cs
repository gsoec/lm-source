using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000741 RID: 1857
public class TrapBehavior
{
	// Token: 0x060023A1 RID: 9121 RVA: 0x00412EA4 File Offset: 0x004110A4
	protected TrapBehavior()
	{
	}

	// Token: 0x060023A2 RID: 9122 RVA: 0x00412EBC File Offset: 0x004110BC
	public virtual void setState(ETrapState state)
	{
		this.trapState = (byte)state;
	}

	// Token: 0x060023A3 RID: 9123 RVA: 0x00412EC8 File Offset: 0x004110C8
	public void checkHitParticle(ref Vector3 trapPos)
	{
		bool flag = false;
		for (int i = 0; i < this.targetPosCache.Count; i++)
		{
			if (GameConstants.DistanceSquare(trapPos, this.targetPosCache[i]) <= 10f)
			{
				flag = true;
				break;
			}
		}
		if (flag && this.particleManager != null)
		{
			this.particleManager.Spawn(this.hitParticleID, null, trapPos, 1f, true, false);
		}
	}

	// Token: 0x060023A4 RID: 9124 RVA: 0x00412F4C File Offset: 0x0041114C
	public virtual void Update(Transform[] traps, float deltaTime)
	{
	}

	// Token: 0x04006D16 RID: 27926
	protected byte trapState;

	// Token: 0x04006D17 RID: 27927
	protected float timer;

	// Token: 0x04006D18 RID: 27928
	protected Vector3[] oriPos;

	// Token: 0x04006D19 RID: 27929
	public WarParticleManager particleManager;

	// Token: 0x04006D1A RID: 27930
	public List<Vector3> targetPosCache = new List<Vector3>(10);

	// Token: 0x04006D1B RID: 27931
	public ushort hitParticleID;
}
