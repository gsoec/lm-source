using System;
using UnityEngine;

// Token: 0x0200034A RID: 842
public class MotionEffect : IMotionUpdate
{
	// Token: 0x06001158 RID: 4440 RVA: 0x001E82B4 File Offset: 0x001E64B4
	public static byte SetStack(MotionEffect e)
	{
		MotionEffect.SpriteStack[(int)MotionEffect.Index] = e;
		byte index = MotionEffect.Index;
		MotionEffect.Index += 1;
		if ((int)MotionEffect.Index >= MotionEffect.SpriteStack.Length)
		{
			MotionEffect.Index = 0;
		}
		return index;
	}

	// Token: 0x06001159 RID: 4441 RVA: 0x001E82F8 File Offset: 0x001E64F8
	public static void RemoveStack(byte Index)
	{
		MotionEffect.SpriteStack[(int)Index] = null;
	}

	// Token: 0x0600115A RID: 4442 RVA: 0x001E8304 File Offset: 0x001E6504
	public static void Update()
	{
		for (int i = 0; i < MotionEffect.SpriteStack.Length; i++)
		{
			if (MotionEffect.SpriteStack[i] != null && !MotionEffect.SpriteStack[i].Motion.UpdateRun(Time.deltaTime))
			{
				MotionEffect.SpriteStack[i] = null;
			}
		}
	}

	// Token: 0x0600115B RID: 4443 RVA: 0x001E8358 File Offset: 0x001E6558
	public virtual bool UpdateRun(float delta)
	{
		return true;
	}

	// Token: 0x0400378A RID: 14218
	public static MotionEffect[] SpriteStack = new MotionEffect[4];

	// Token: 0x0400378B RID: 14219
	public static byte Index = 0;

	// Token: 0x0400378C RID: 14220
	public IMotionUpdate Motion;

	// Token: 0x0400378D RID: 14221
	public bool bMove;
}
