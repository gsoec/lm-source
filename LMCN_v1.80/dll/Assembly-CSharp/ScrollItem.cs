using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020007E6 RID: 2022
public class ScrollItem : Selectable, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x060029F3 RID: 10739 RVA: 0x004656A4 File Offset: 0x004638A4
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this.IsActive() && this.IsInteractable() && this.m_Handler != null)
		{
			if ((this.SoundIndex & 64) > 0)
			{
				int enumSoundIndex = (int)this.SoundIndex & -65;
				AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex)enumSoundIndex);
			}
			this.m_Handler.ButtonOnClick(this);
		}
	}

	// Token: 0x04007552 RID: 30034
	public IScrollItemHandler m_Handler;

	// Token: 0x04007553 RID: 30035
	public int m_BtnID1;

	// Token: 0x04007554 RID: 30036
	public byte SoundIndex;
}
