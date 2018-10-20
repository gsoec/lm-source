using System;
using UnityEngine;

// Token: 0x0200034D RID: 845
public class ForwardEffect : MotionEffect
{
	// Token: 0x06001165 RID: 4453 RVA: 0x001E85F0 File Offset: 0x001E67F0
	public void SetGameObject(GameObject go)
	{
		this.gameobject = go;
		Vector3 a = Vector3.zero;
		this.offsetCenter = new Vector3[this.gameobject.transform.childCount];
		this.spriteRender = new SpriteRenderer[this.gameobject.transform.childCount];
		this.oriScale = new Vector3[this.gameobject.transform.childCount];
		ushort num = 0;
		while ((int)num < this.gameobject.transform.childCount)
		{
			this.offsetCenter[(int)num] = this.gameobject.transform.GetChild((int)num).position;
			this.spriteRender[(int)num] = this.gameobject.transform.GetChild((int)num).gameObject.GetComponent<SpriteRenderer>();
			this.spriteRender[(int)num].sortingOrder = -1;
			this.oriScale[(int)num] = this.gameobject.transform.GetChild((int)num).localScale;
			a += this.offsetCenter[(int)num];
			num += 1;
		}
		a /= (float)num;
		for (int i = 0; i < this.offsetCenter.Length; i++)
		{
			this.offsetCenter[i] = a - this.offsetCenter[i];
			this.offsetCenter[i].Normalize();
		}
		this.bMove = true;
		this.CurTime = 0f;
	}

	// Token: 0x06001166 RID: 4454 RVA: 0x001E8784 File Offset: 0x001E6984
	public override bool UpdateRun(float delta)
	{
		for (int i = 0; i < this.gameobject.transform.childCount; i++)
		{
			this.gameobject.transform.GetChild(i).Translate(this.offsetCenter[i].normalized * delta * 7.5f);
			this.gameobject.transform.GetChild(i).localScale += this.oriScale[i] * (0.0009f * (this.CurTime / this.TotalTime));
			Color color = this.spriteRender[i].color;
			color.a = 1f - 1f * (this.CurTime / this.TotalTime);
			this.spriteRender[i].color = color;
		}
		this.CurTime += delta;
		if (this.CurTime > this.TotalTime)
		{
			this.CurTime = 0f;
			this.bMove = false;
		}
		return true;
	}

	// Token: 0x04003794 RID: 14228
	public GameObject gameobject;

	// Token: 0x04003795 RID: 14229
	public Vector3[] offsetCenter;

	// Token: 0x04003796 RID: 14230
	public SpriteRenderer[] spriteRender;

	// Token: 0x04003797 RID: 14231
	public Vector3[] oriScale;

	// Token: 0x04003798 RID: 14232
	public float TotalTime = 3f;

	// Token: 0x04003799 RID: 14233
	private float CurTime;
}
