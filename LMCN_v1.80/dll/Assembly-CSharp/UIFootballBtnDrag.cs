using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000877 RID: 2167
public class UIFootballBtnDrag : Selectable, IPointerUpHandler, IDragHandler, IPointerDownHandler, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06002CFE RID: 11518 RVA: 0x0048E2FC File Offset: 0x0048C4FC
	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);
		this.isPointerDown = true;
		if (this.m_DHandler != null && eventData.pointerId < 1)
		{
			this.m_DHandler.OnPointerDown(this);
		}
	}

	// Token: 0x06002CFF RID: 11519 RVA: 0x0048E330 File Offset: 0x0048C530
	public override void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);
		if (this.IsActive() && this.IsInteractable() && this.m_DHandler != null && eventData.pointerId < 1)
		{
			this.isPointerDown = false;
			this.m_DHandler.OnPointerUp(eventData);
		}
	}

	// Token: 0x06002D00 RID: 11520 RVA: 0x0048E384 File Offset: 0x0048C584
	public void OnDrag(PointerEventData eventData)
	{
		if (this.m_DHandler != null)
		{
			this.m_DHandler.OnDrag(eventData);
		}
	}

	// Token: 0x06002D01 RID: 11521 RVA: 0x0048E3A0 File Offset: 0x0048C5A0
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this.m_DHandler != null)
		{
			this.m_DHandler.OnPointerClick(this);
		}
	}

	// Token: 0x04007996 RID: 31126
	public IUIFootballBtnDrag m_DHandler;

	// Token: 0x04007997 RID: 31127
	public int m_BtnID1;

	// Token: 0x04007998 RID: 31128
	public int m_BtnID2;

	// Token: 0x04007999 RID: 31129
	public int m_BtnID3;

	// Token: 0x0400799A RID: 31130
	public int m_BtnID4;

	// Token: 0x0400799B RID: 31131
	public bool isPointerDown;
}
