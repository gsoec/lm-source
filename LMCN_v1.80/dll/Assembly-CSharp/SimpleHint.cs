using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000581 RID: 1409
public class SimpleHint : HintStyleBase
{
	// Token: 0x06001BFE RID: 7166 RVA: 0x00319634 File Offset: 0x00317834
	public SimpleHint(RectTransform transform)
	{
		this.rectTrans = transform;
		this.ContText = this.rectTrans.GetChild(0).GetComponent<UIText>();
		this.ContText.font = GUIManager.Instance.GetTTFFont();
		this.Content = new CString(512);
		this.HintFrameSprite = GUIManager.Instance.LoadFrameSprite("UI_main_box_012");
		this.HintFrameMat = GUIManager.Instance.GetFrameMaterial();
	}

	// Token: 0x06001BFF RID: 7167 RVA: 0x003196BC File Offset: 0x003178BC
	public override void SetStyle(byte style)
	{
	}

	// Token: 0x06001C00 RID: 7168 RVA: 0x003196C0 File Offset: 0x003178C0
	public override Vector2 GetSize()
	{
		return this.Size;
	}

	// Token: 0x06001C01 RID: 7169 RVA: 0x003196C8 File Offset: 0x003178C8
	public override void SetContent(int kind, int fontsize, float width, int Parm1, int Parm2 = 0)
	{
		this.ContText.fontSize = fontsize;
		this.Size.x = width;
		if (this.KindArray[kind] == null)
		{
			this.CreateStyle(kind);
		}
		this.ContText.text = this.KindArray[kind].SetContent(this.Content, Parm1, Parm2);
		if (this.Content.Length > 0)
		{
			this.ContText.SetAllDirty();
			this.ContText.cachedTextGenerator.Invalidate();
			this.ContText.cachedTextGeneratorForLayout.Invalidate();
		}
		this.Size.y = this.ContText.preferredHeight + 16f;
		if (this.ContText.cachedTextGeneratorForLayout.lineCount == 1)
		{
			this.Size.x = this.ContText.preferredWidth + 16f;
		}
		else if ((byte)kind == 3 && this.ContText.preferredWidth + 16f < width)
		{
			this.Size.x = this.ContText.preferredWidth + 16f;
		}
	}

	// Token: 0x06001C02 RID: 7170 RVA: 0x003197F0 File Offset: 0x003179F0
	public override void SetContent(int kind, int fontsize, float width, CString cont)
	{
		this.ContText.fontSize = fontsize;
		this.Size.x = width;
		this.Content.ClearString();
		this.Content.Append(cont);
		this.ContText.text = this.Content.ToString();
		this.ContText.SetAllDirty();
		this.ContText.cachedTextGenerator.Invalidate();
		this.ContText.cachedTextGeneratorForLayout.Invalidate();
		this.Size.y = this.ContText.preferredHeight + 16f;
		if (this.ContText.cachedTextGeneratorForLayout.lineCount == 1)
		{
			this.Size.x = this.ContText.preferredWidth + 16f;
		}
		else if ((byte)kind == 3 && this.ContText.preferredWidth + 16f < width)
		{
			this.Size.x = this.ContText.preferredWidth + 16f;
		}
	}

	// Token: 0x06001C03 RID: 7171 RVA: 0x003198FC File Offset: 0x00317AFC
	private void CreateStyle(int kind)
	{
		switch ((byte)kind)
		{
		case 0:
			this.KindArray[kind] = new NormalSimpleHint();
			break;
		case 1:
			this.KindArray[kind] = new KingdomSimpleHint();
			break;
		case 2:
			this.KindArray[kind] = new CastleSkinHint();
			break;
		case 3:
			this.KindArray[kind] = new ArmyKindHint();
			break;
		}
	}

	// Token: 0x06001C04 RID: 7172 RVA: 0x00319970 File Offset: 0x00317B70
	public override void TextRefresh()
	{
		this.ContText.enabled = false;
		this.ContText.enabled = true;
	}

	// Token: 0x040054C9 RID: 21705
	private CString Content;

	// Token: 0x040054CA RID: 21706
	private UIText ContText;

	// Token: 0x040054CB RID: 21707
	private SimpleHintKind[] KindArray = new SimpleHintKind[4];

	// Token: 0x02000582 RID: 1410
	public enum eKind : byte
	{
		// Token: 0x040054CD RID: 21709
		eNormal,
		// Token: 0x040054CE RID: 21710
		eKingdomMap,
		// Token: 0x040054CF RID: 21711
		eCastleSkin,
		// Token: 0x040054D0 RID: 21712
		eArmy,
		// Token: 0x040054D1 RID: 21713
		Max
	}
}
