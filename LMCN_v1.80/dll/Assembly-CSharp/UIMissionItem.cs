using System;
using UnityEngine;

// Token: 0x0200041E RID: 1054
public abstract class UIMissionItem : IUIButtonClickHandler
{
	// Token: 0x0600156E RID: 5486
	public abstract void SetMissionData(int Index);

	// Token: 0x0600156F RID: 5487
	public abstract void Destroy();

	// Token: 0x06001570 RID: 5488
	public abstract void Update();

	// Token: 0x06001571 RID: 5489
	public abstract float GetHeight();

	// Token: 0x06001572 RID: 5490
	public abstract void SetSelect(bool bSelect, int index = 0, uint[] reward = null, ushort[] rewardItem = null, ushort[] count = null);

	// Token: 0x06001573 RID: 5491
	public abstract void OnButtonClick(UIButton sender);

	// Token: 0x06001574 RID: 5492
	public abstract void TextRefresh();

	// Token: 0x04003F8E RID: 16270
	public Transform transform;

	// Token: 0x04003F8F RID: 16271
	public UIButton[] ItemBtn;

	// Token: 0x04003F90 RID: 16272
	public int DataIndex;

	// Token: 0x04003F91 RID: 16273
	public iMissionTimeDelta TimeHandle;
}
