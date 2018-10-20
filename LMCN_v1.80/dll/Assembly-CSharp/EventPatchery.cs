using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020007E0 RID: 2016
public class EventPatchery : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x060029DE RID: 10718 RVA: 0x004654BC File Offset: 0x004636BC
	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		if (this.ReceiveObj == null)
		{
			return;
		}
		this.ReceiveObj.OnPointerExit(eventData);
	}

	// Token: 0x060029DF RID: 10719 RVA: 0x004654D8 File Offset: 0x004636D8
	void IDragHandler.OnDrag(PointerEventData eventData)
	{
		if (this.ReceiveObj == null)
		{
			return;
		}
		this.ReceiveObj.OnDrag(eventData);
	}

	// Token: 0x060029E0 RID: 10720 RVA: 0x004654F4 File Offset: 0x004636F4
	void IEndDragHandler.OnEndDrag(PointerEventData eventData)
	{
		if (this.ReceiveObj == null)
		{
			return;
		}
		this.ReceiveObj.OnEndDrag(eventData);
	}

	// Token: 0x060029E1 RID: 10721 RVA: 0x00465510 File Offset: 0x00463710
	void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
	{
		if (this.ReceiveObj == null)
		{
			return;
		}
		this.ReceiveObj.OnBeginDrag(eventData);
	}

	// Token: 0x060029E2 RID: 10722 RVA: 0x0046552C File Offset: 0x0046372C
	public void SetEvnetObj(CScrollRect Obj)
	{
		this.ReceiveObj = new CSCrollReserve(Obj);
	}

	// Token: 0x0400754B RID: 30027
	private EventReceive ReceiveObj;
}
