using System;
using UnityEngine;

// Token: 0x0200057B RID: 1403
public class HintStyleBase
{
	// Token: 0x06001BEF RID: 7151 RVA: 0x003192A4 File Offset: 0x003174A4
	public virtual void SetStyle(byte style)
	{
	}

	// Token: 0x06001BF0 RID: 7152 RVA: 0x003192A8 File Offset: 0x003174A8
	public virtual Vector2 GetSize()
	{
		return Vector2.zero;
	}

	// Token: 0x06001BF1 RID: 7153 RVA: 0x003192B0 File Offset: 0x003174B0
	public virtual void SetContent(int kind, int fontsize, float width, int Parm1, int Parm2 = 0)
	{
	}

	// Token: 0x06001BF2 RID: 7154 RVA: 0x003192B4 File Offset: 0x003174B4
	public virtual void SetContent(int kind, int fontsize, float width, CString cont)
	{
	}

	// Token: 0x06001BF3 RID: 7155 RVA: 0x003192B8 File Offset: 0x003174B8
	public virtual void SetActive(bool active)
	{
		this.rectTrans.gameObject.SetActive(active);
	}

	// Token: 0x06001BF4 RID: 7156 RVA: 0x003192CC File Offset: 0x003174CC
	public virtual void TextRefresh()
	{
	}

	// Token: 0x040054C4 RID: 21700
	public RectTransform rectTrans;

	// Token: 0x040054C5 RID: 21701
	protected Vector2 Size;

	// Token: 0x040054C6 RID: 21702
	public Sprite HintFrameSprite;

	// Token: 0x040054C7 RID: 21703
	public Material HintFrameMat;
}
