using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200020D RID: 525
internal class sHudMsg
{
	// Token: 0x0600098D RID: 2445 RVA: 0x000C45C0 File Offset: 0x000C27C0
	public sHudMsg(int len = 0)
	{
		this.Pos = Vector2.zero;
		this.ColorA = 1f;
		this.time = 0f;
		this.Enable = false;
		this.Trnas = null;
		this.Idx = -1;
		this.Msg = null;
		this.Bg = null;
	}

	// Token: 0x04002001 RID: 8193
	public Vector2 Pos;

	// Token: 0x04002002 RID: 8194
	public float ColorA;

	// Token: 0x04002003 RID: 8195
	public float time;

	// Token: 0x04002004 RID: 8196
	public bool Enable;

	// Token: 0x04002005 RID: 8197
	public Transform Trnas;

	// Token: 0x04002006 RID: 8198
	public int Idx;

	// Token: 0x04002007 RID: 8199
	public UIText Msg;

	// Token: 0x04002008 RID: 8200
	public Image Bg;
}
