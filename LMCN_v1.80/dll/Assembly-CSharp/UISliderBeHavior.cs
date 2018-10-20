using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000882 RID: 2178
public class UISliderBeHavior : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06002D3E RID: 11582 RVA: 0x0048FA34 File Offset: 0x0048DC34
	private void Awake()
	{
		this.m_Button = base.GetComponent<Selectable>();
	}

	// Token: 0x06002D3F RID: 11583 RVA: 0x0048FA44 File Offset: 0x0048DC44
	public void OnPointerDown(PointerEventData eventData)
	{
		if (!base.enabled || !base.gameObject.activeInHierarchy || (this.m_Button != null && !this.m_Button.IsInteractable()))
		{
			return;
		}
		if (this.m_Handler != null)
		{
			IUISliderBehavior iuisliderBehavior = this.m_Handler as IUISliderBehavior;
			if (iuisliderBehavior != null)
			{
				iuisliderBehavior.OnButtonDown(this.m_Button as UIButton);
			}
		}
	}

	// Token: 0x06002D40 RID: 11584 RVA: 0x0048FAC4 File Offset: 0x0048DCC4
	public void OnPointerUp(PointerEventData eventData)
	{
		if (!base.enabled || !base.gameObject.activeInHierarchy || (this.m_Button != null && !this.m_Button.IsInteractable()))
		{
			return;
		}
		if (this.m_Handler != null)
		{
			IUISliderBehavior iuisliderBehavior = this.m_Handler as IUISliderBehavior;
			if (iuisliderBehavior != null)
			{
				iuisliderBehavior.OnButtonUp(this.m_Button as UIButton);
			}
		}
	}

	// Token: 0x06002D41 RID: 11585 RVA: 0x0048FB44 File Offset: 0x0048DD44
	public void OnPointerExit(PointerEventData eventData)
	{
		if (this.m_Handler != null)
		{
			IUISliderBehavior iuisliderBehavior = this.m_Handler as IUISliderBehavior;
			if (iuisliderBehavior != null)
			{
				iuisliderBehavior.OnButtonUp(this.m_Button as UIButton);
			}
		}
	}

	// Token: 0x06002D42 RID: 11586 RVA: 0x0048FB88 File Offset: 0x0048DD88
	public void OnDrag(PointerEventData eventData)
	{
	}

	// Token: 0x040079E4 RID: 31204
	public Selectable m_Button;

	// Token: 0x040079E5 RID: 31205
	public MonoBehaviour m_Handler;
}
