using System;
using UnityEngine;

// Token: 0x0200070D RID: 1805
public class BrokenFO : SheetAnimMesh
{
	// Token: 0x060022C3 RID: 8899 RVA: 0x0040B034 File Offset: 0x00409234
	public BrokenFO(byte kind, byte tier) : base(EWarMeshKind.FO, kind, tier, 0)
	{
		this.transform.gameObject.SetActive(false);
		this.animNotify = new SheetAnimMesh.AnimNotify(this.AnimOnceNotify);
	}

	// Token: 0x060022C4 RID: 8900 RVA: 0x0040B070 File Offset: 0x00409270
	public bool Play(Transform trans)
	{
		this.transform.gameObject.SetActive(true);
		this.transform.position = trans.position;
		this.transform.rotation = trans.rotation;
		this.IsPlaying = true;
		return this.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Once, false, true, true);
	}

	// Token: 0x060022C5 RID: 8901 RVA: 0x0040B0C4 File Offset: 0x004092C4
	public bool Play(Vector3 pos, Vector3 dir)
	{
		this.transform.gameObject.SetActive(true);
		this.transform.position = pos;
		this.transform.rotation = Quaternion.LookRotation(dir);
		this.IsPlaying = true;
		return this.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Once, false, true, true);
	}

	// Token: 0x060022C6 RID: 8902 RVA: 0x0040B114 File Offset: 0x00409314
	public bool Play(Vector3 pos, Quaternion qua)
	{
		this.transform.gameObject.SetActive(true);
		this.transform.position = pos;
		this.transform.rotation = qua;
		this.IsPlaying = true;
		return this.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Once, false, true, true);
	}

	// Token: 0x060022C7 RID: 8903 RVA: 0x0040B15C File Offset: 0x0040935C
	public void AnimOnceNotify(ESheetMeshAnim finishAnim)
	{
		this.transform.gameObject.SetActive(false);
	}
}
