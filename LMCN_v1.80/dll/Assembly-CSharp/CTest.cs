using System;
using UnityEngine;

// Token: 0x0200042E RID: 1070
public class CTest : UIMissionItem
{
	// Token: 0x060015B6 RID: 5558 RVA: 0x0024FC6C File Offset: 0x0024DE6C
	public CTest(Transform transform)
	{
		this.transform = transform;
		this.TimerBar = transform.GetChild(1).GetComponent<UITimeBar>();
		GUIManager.Instance.CreateTimerBar(this.TimerBar, 0L, 0L, 0L, eTimeBarType.UIMission, string.Empty, string.Empty);
	}

	// Token: 0x060015B7 RID: 5559 RVA: 0x0024FCBC File Offset: 0x0024DEBC
	public override void SetMissionData(int Index)
	{
	}

	// Token: 0x060015B8 RID: 5560 RVA: 0x0024FCC0 File Offset: 0x0024DEC0
	public override void Destroy()
	{
		GUIManager.Instance.RemoverTimeBaarToList(this.TimerBar);
	}

	// Token: 0x060015B9 RID: 5561 RVA: 0x0024FCD4 File Offset: 0x0024DED4
	public override void Update()
	{
	}

	// Token: 0x060015BA RID: 5562 RVA: 0x0024FCD8 File Offset: 0x0024DED8
	public override float GetHeight()
	{
		return 106f;
	}

	// Token: 0x060015BB RID: 5563 RVA: 0x0024FCE0 File Offset: 0x0024DEE0
	public override void SetSelect(bool bSelect, int index, uint[] reward = null, ushort[] rewardItem = null, ushort[] count = null)
	{
	}

	// Token: 0x060015BC RID: 5564 RVA: 0x0024FCE4 File Offset: 0x0024DEE4
	public override void OnButtonClick(UIButton sender)
	{
	}

	// Token: 0x060015BD RID: 5565 RVA: 0x0024FCE8 File Offset: 0x0024DEE8
	public override void TextRefresh()
	{
	}

	// Token: 0x0400400E RID: 16398
	private UITimeBar TimerBar;

	// Token: 0x0200042F RID: 1071
	private enum UIControl
	{
		// Token: 0x04004010 RID: 16400
		MissionPic,
		// Token: 0x04004011 RID: 16401
		TimeBar,
		// Token: 0x04004012 RID: 16402
		Btn,
		// Token: 0x04004013 RID: 16403
		MissionName,
		// Token: 0x04004014 RID: 16404
		Select
	}
}
