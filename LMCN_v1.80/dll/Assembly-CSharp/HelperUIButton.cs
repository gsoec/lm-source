using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020007E3 RID: 2019
public class HelperUIButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060029ED RID: 10733 RVA: 0x0046559C File Offset: 0x0046379C
	public void Start()
	{
		this.Button = base.gameObject.GetComponent<UIButton>();
		if (this.Button == null)
		{
			this.Button = base.gameObject.AddComponent<UIButton>();
		}
		this.Button.m_BtnID1 = this.m_BtnID1;
		this.Button.m_BtnID2 = this.m_BtnID2;
		this.Button.transition = Selectable.Transition.None;
		this.Img = base.transform.GetComponent<Image>();
	}

	// Token: 0x060029EE RID: 10734 RVA: 0x0046561C File Offset: 0x0046381C
	public void OnPointerClick(PointerEventData eventData)
	{
		if (!base.enabled || this.m_Handler == null || this.Button == null || this.Img == null)
		{
			return;
		}
		if (eventData.pointerEnter == this.Img.gameObject)
		{
			this.m_Handler.OnButtonClick(this.Button);
		}
	}

	// Token: 0x0400754D RID: 30029
	public IUIButtonClickHandler m_Handler;

	// Token: 0x0400754E RID: 30030
	public int m_BtnID1;

	// Token: 0x0400754F RID: 30031
	public int m_BtnID2;

	// Token: 0x04007550 RID: 30032
	public UIButton Button;

	// Token: 0x04007551 RID: 30033
	private Image Img;
}
