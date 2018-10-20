using System;
using UnityEngine.EventSystems;

// Token: 0x02000876 RID: 2166
public interface IUIFootballBtnDrag
{
	// Token: 0x06002CF9 RID: 11513
	void OnPointerDown(UIFootballBtnDrag sender);

	// Token: 0x06002CFA RID: 11514
	void OnPointerUp(PointerEventData eventData);

	// Token: 0x06002CFB RID: 11515
	void OnDrag(PointerEventData eventData);

	// Token: 0x06002CFC RID: 11516
	void OnPointerClick(UIFootballBtnDrag sender);
}
