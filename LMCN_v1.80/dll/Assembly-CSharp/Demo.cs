using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class Demo : MonoBehaviour
{
	// Token: 0x06000002 RID: 2 RVA: 0x000020F4 File Offset: 0x000002F4
	private void Awake()
	{
		Screen.SetResolution(480, 854, true);
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002108 File Offset: 0x00000308
	private void Update()
	{
		base.transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * 90f));
	}

	// Token: 0x06000004 RID: 4 RVA: 0x0000213C File Offset: 0x0000033C
	private void OnGUI()
	{
		GUI.Label(new Rect(5f, 5f, 300f, 50f), "UnityVersion:" + Application.unityVersion);
	}
}
