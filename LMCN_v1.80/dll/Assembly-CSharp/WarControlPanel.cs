using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000746 RID: 1862
public class WarControlPanel : Image, IPointerUpHandler, IPointerDownHandler, IEventSystemHandler
{
	// Token: 0x170000E3 RID: 227
	// (set) Token: 0x060023B0 RID: 9136 RVA: 0x00413B54 File Offset: 0x00411D54
	public WarManager warManager
	{
		set
		{
			this.WM = value;
		}
	}

	// Token: 0x060023B1 RID: 9137 RVA: 0x00413B60 File Offset: 0x00411D60
	public void OnPointerDown(PointerEventData eventData)
	{
		if (this.WM != null && this.WM.m_WarState == WarManager.WarState.RUNNING)
		{
			this.WM.checkPickHero(true);
		}
	}

	// Token: 0x060023B2 RID: 9138 RVA: 0x00413B98 File Offset: 0x00411D98
	public void OnPointerUp(PointerEventData eventData)
	{
	}

	// Token: 0x04006D2D RID: 27949
	private WarManager WM;
}
