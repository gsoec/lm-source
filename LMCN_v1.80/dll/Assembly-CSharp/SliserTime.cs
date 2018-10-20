using System;

// Token: 0x020001EF RID: 495
internal struct SliserTime
{
	// Token: 0x06000905 RID: 2309 RVA: 0x000B7EC0 File Offset: 0x000B60C0
	public SliserTime(int i)
	{
		this.mpSliderValue = 0f;
		this.time = 0f;
		this.bShowIconEffect = 0;
	}

	// Token: 0x04001DDE RID: 7646
	public float time;

	// Token: 0x04001DDF RID: 7647
	public float mpSliderValue;

	// Token: 0x04001DE0 RID: 7648
	public byte bShowIconEffect;
}
