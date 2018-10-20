using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020007ED RID: 2029
public class ScrollPanelItem : Selectable, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06002A0E RID: 10766 RVA: 0x004671A0 File Offset: 0x004653A0
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this.m_Handler != null)
		{
			this.m_Handler.ButtonOnClick(this);
		}
	}

	// Token: 0x06002A0F RID: 10767 RVA: 0x004671BC File Offset: 0x004653BC
	protected override void DoStateTransition(Selectable.SelectionState state, bool instant)
	{
		base.DoStateTransition(state, instant);
		if (this.m_StateTransitionHandler != null)
		{
			this.m_StateTransitionHandler.OnStateTransition((byte)state, instant);
		}
	}

	// Token: 0x0400756A RID: 30058
	public IScrollPanelItemHandler m_Handler;

	// Token: 0x0400756B RID: 30059
	public IUIStateTransition m_StateTransitionHandler;

	// Token: 0x0400756C RID: 30060
	public int m_BtnID1;

	// Token: 0x0400756D RID: 30061
	public int m_BtnID2;

	// Token: 0x0400756E RID: 30062
	public byte SoundIndex;
}
