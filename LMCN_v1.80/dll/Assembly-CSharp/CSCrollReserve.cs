using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020007E2 RID: 2018
public class CSCrollReserve : EventReceive
{
	// Token: 0x060029E8 RID: 10728 RVA: 0x00465554 File Offset: 0x00463754
	public CSCrollReserve(CScrollRect scrollRect)
	{
		this.cscrollRect = scrollRect;
	}

	// Token: 0x060029E9 RID: 10729 RVA: 0x00465564 File Offset: 0x00463764
	public override void OnBeginDrag(PointerEventData eventData)
	{
		this.cscrollRect.OnBeginDrag(eventData);
	}

	// Token: 0x060029EA RID: 10730 RVA: 0x00465574 File Offset: 0x00463774
	public override void OnDrag(PointerEventData eventData)
	{
		this.cscrollRect.OnDrag(eventData);
	}

	// Token: 0x060029EB RID: 10731 RVA: 0x00465584 File Offset: 0x00463784
	public override void OnEndDrag(PointerEventData eventData)
	{
		this.cscrollRect.OnEndDrag(eventData);
	}

	// Token: 0x0400754C RID: 30028
	public CScrollRect cscrollRect;
}
