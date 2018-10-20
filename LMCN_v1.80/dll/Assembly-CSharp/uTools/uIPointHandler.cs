using System;
using UnityEngine.EventSystems;

namespace uTools
{
	// Token: 0x02000803 RID: 2051
	public interface uIPointHandler : IPointerUpHandler, IPointerDownHandler, IPointerClickHandler, IPointerExitHandler, IEventSystemHandler, IPointerEnterHandler
	{
		// Token: 0x06002A9D RID: 10909
		void OnPointerEnter(PointerEventData eventData);

		// Token: 0x06002A9E RID: 10910
		void OnPointerDown(PointerEventData eventData);

		// Token: 0x06002A9F RID: 10911
		void OnPointerClick(PointerEventData eventData);

		// Token: 0x06002AA0 RID: 10912
		void OnPointerUp(PointerEventData eventData);

		// Token: 0x06002AA1 RID: 10913
		void OnPointerExit(PointerEventData eventData);
	}
}
