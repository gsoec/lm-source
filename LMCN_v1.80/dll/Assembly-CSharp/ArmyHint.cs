using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000583 RID: 1411
public class ArmyHint : HintStyleBase
{
	// Token: 0x06001C05 RID: 7173 RVA: 0x0031998C File Offset: 0x00317B8C
	public ArmyHint(RectTransform transform)
	{
		this.rectTrans = transform;
		this.P1 = this.rectTrans.GetChild(0);
		this.ContText[0] = this.P1.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.ContText[0].font = GUIManager.Instance.GetTTFFont();
		this.ContText[0].text = DataManager.Instance.mStringTable.GetStringByID(11161u);
		this.ContText[1] = this.P1.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.ContText[1].font = GUIManager.Instance.GetTTFFont();
		this.ContText[1].text = DataManager.Instance.mStringTable.GetStringByID(11166u);
		this.P2 = this.rectTrans.GetChild(1);
		this.ContText[2] = this.P2.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.ContText[2].font = GUIManager.Instance.GetTTFFont();
		this.ContText[2].text = DataManager.Instance.mStringTable.GetStringByID(11161u);
		this.ContText[3] = this.P2.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.ContText[3].font = GUIManager.Instance.GetTTFFont();
		this.ContText[3].text = DataManager.Instance.mStringTable.GetStringByID(11166u);
	}

	// Token: 0x06001C06 RID: 7174 RVA: 0x00319B34 File Offset: 0x00317D34
	public override void SetStyle(byte style)
	{
	}

	// Token: 0x06001C07 RID: 7175 RVA: 0x00319B38 File Offset: 0x00317D38
	public override Vector2 GetSize()
	{
		return this.Size;
	}

	// Token: 0x06001C08 RID: 7176 RVA: 0x00319B40 File Offset: 0x00317D40
	public override void SetContent(int kind, int fontsize, float width, int Parm1, int Parm2 = 0)
	{
		if (Parm1 == 0)
		{
			this.Size = new Vector2(547f, 339f);
			this.P1.gameObject.SetActive(true);
			this.P2.gameObject.SetActive(false);
		}
		else
		{
			this.Size = new Vector2(449f, 330f);
			this.P1.gameObject.SetActive(false);
			this.P2.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001C09 RID: 7177 RVA: 0x00319BC8 File Offset: 0x00317DC8
	public override void TextRefresh()
	{
		for (int i = 0; i < 4; i++)
		{
			if (this.ContText[i] != null && this.ContText[i].enabled)
			{
				this.ContText[i].enabled = false;
				this.ContText[i].enabled = true;
			}
		}
	}

	// Token: 0x040054D2 RID: 21714
	private Transform P1;

	// Token: 0x040054D3 RID: 21715
	private Transform P2;

	// Token: 0x040054D4 RID: 21716
	private UIText[] ContText = new UIText[4];
}
