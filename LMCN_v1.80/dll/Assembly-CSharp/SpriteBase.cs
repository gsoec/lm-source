using System;
using UnityEngine;

// Token: 0x0200034F RID: 847
public abstract class SpriteBase
{
	// Token: 0x06001168 RID: 4456 RVA: 0x001E88AC File Offset: 0x001E6AAC
	public virtual GameObject InitialSprite(MapSpriteManager mapspriteManager)
	{
		return null;
	}

	// Token: 0x06001169 RID: 4457
	public abstract void SetSprite(ushort ID, byte Class);

	// Token: 0x0600116A RID: 4458
	public abstract void Destroy();

	// Token: 0x0600116B RID: 4459 RVA: 0x001E88B0 File Offset: 0x001E6AB0
	public virtual void Update(byte meg)
	{
	}

	// Token: 0x0600116C RID: 4460 RVA: 0x001E88B4 File Offset: 0x001E6AB4
	public virtual void Hide()
	{
	}

	// Token: 0x0600116D RID: 4461 RVA: 0x001E88B8 File Offset: 0x001E6AB8
	public virtual void UpdateSpriteFrame()
	{
	}

	// Token: 0x040037A2 RID: 14242
	public ushort Index;

	// Token: 0x040037A3 RID: 14243
	public int HashID;

	// Token: 0x040037A4 RID: 14244
	public MapSpriteManager mapspriteManager;
}
