using System;
using UnityEngine;

// Token: 0x0200085E RID: 2142
public class UIBattleMessage : MonoBehaviour
{
	// Token: 0x06002C35 RID: 11317 RVA: 0x004885B8 File Offset: 0x004867B8
	private void Start()
	{
		this.m_Transform = base.transform;
		this.ButtonRC = (RectTransform)this.m_Transform.GetChild(3);
		this.OriginalPos = this.ButtonRC.anchoredPosition;
		this.to = this.OriginalPos - new Vector2(0f, 2f);
	}

	// Token: 0x06002C36 RID: 11318 RVA: 0x0048861C File Offset: 0x0048681C
	private void Update()
	{
		if (this.bMove)
		{
			this.deltatime1 -= Time.deltaTime;
			if (this.deltatime1 <= 0f)
			{
				this.bMove = false;
				this.deltatime1 = this.Duration;
				this.ButtonRC.anchoredPosition = this.OriginalPos;
				return;
			}
			this.deltatime2 -= Time.deltaTime;
			if (this.deltatime2 < 0f)
			{
				this.deltatime2 = this.halfTime;
				this.bMoveDown = !this.bMoveDown;
			}
			if (this.bMoveDown)
			{
				this.ButtonRC.anchoredPosition = Vector2.Lerp(this.ButtonRC.anchoredPosition, this.to, this.deltatime2);
			}
			else
			{
				this.ButtonRC.anchoredPosition = Vector2.Lerp(this.ButtonRC.anchoredPosition, this.OriginalPos, this.deltatime2);
			}
		}
		else
		{
			this.deltatime1 -= Time.deltaTime;
			if (this.deltatime1 <= 0f)
			{
				this.bMove = true;
				this.bMoveDown = true;
				this.deltatime1 = this.halfTime * 2f;
				this.deltatime2 = this.halfTime;
			}
		}
	}

	// Token: 0x040078E6 RID: 30950
	private Transform m_Transform;

	// Token: 0x040078E7 RID: 30951
	private RectTransform ButtonRC;

	// Token: 0x040078E8 RID: 30952
	private float Duration = 1.7f;

	// Token: 0x040078E9 RID: 30953
	private float halfTime = 0.15f;

	// Token: 0x040078EA RID: 30954
	private float deltatime1;

	// Token: 0x040078EB RID: 30955
	private float deltatime2;

	// Token: 0x040078EC RID: 30956
	private bool bMove;

	// Token: 0x040078ED RID: 30957
	private bool bMoveDown;

	// Token: 0x040078EE RID: 30958
	private Vector2 to;

	// Token: 0x040078EF RID: 30959
	private Vector2 OriginalPos;
}
