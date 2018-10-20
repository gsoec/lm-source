using System;
using UnityEngine;

// Token: 0x020007E4 RID: 2020
public class IgnoreRaycast : MonoBehaviour, ICanvasRaycastFilter
{
	// Token: 0x060029F0 RID: 10736 RVA: 0x00465698 File Offset: 0x00463898
	public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
	{
		return false;
	}
}
