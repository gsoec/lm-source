using System;
using UnityEngine;

// Token: 0x02000046 RID: 70
public class ProjectorShadowDummy : MonoBehaviour
{
	// Token: 0x060001C6 RID: 454 RVA: 0x0001ABC8 File Offset: 0x00018DC8
	public void OnPreRender()
	{
		base.transform.localPosition = this._ShadowLocalOffset;
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x0001ABDC File Offset: 0x00018DDC
	private void OnRenderObject()
	{
		if (this._RotationOffsetApplied)
		{
			base.transform.rotation = this._InbetweenRotation;
			this._RotationOffsetApplied = false;
		}
	}

	// Token: 0x040003D4 RID: 980
	public Vector3 _ShadowLocalOffset;

	// Token: 0x040003D5 RID: 981
	public float _RotationAngleOffset;

	// Token: 0x040003D6 RID: 982
	private Quaternion _AngleOffset;

	// Token: 0x040003D7 RID: 983
	private Quaternion _InbetweenRotation;

	// Token: 0x040003D8 RID: 984
	private bool _RotationOffsetApplied;
}
