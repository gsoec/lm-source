using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020001E0 RID: 480
public class BattleControllerPanel : Image, IPointerUpHandler, IPointerDownHandler, IEventSystemHandler
{
	// Token: 0x17000070 RID: 112
	// (set) Token: 0x060008CD RID: 2253 RVA: 0x000B5340 File Offset: 0x000B3540
	public BattleController battleController
	{
		set
		{
			this.BC = value;
		}
	}

	// Token: 0x060008CE RID: 2254 RVA: 0x000B534C File Offset: 0x000B354C
	public void OnPointerDown(PointerEventData eventData)
	{
	}

	// Token: 0x060008CF RID: 2255 RVA: 0x000B5350 File Offset: 0x000B3550
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.BC != null && !this.BC.StartAutoBattle && !this.BC.NextLevelWorking && this.BC.m_BattleState == BattleController.BattleState.BATTLE_FINISHED && this.BC.CheckNextLevel() && this.BC.movePlayerOutside(EMovePlayerOutside.Default))
		{
			this.BC.NextLevelWorking = true;
			GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.Battle);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 12, 0);
		}
	}

	// Token: 0x04001D70 RID: 7536
	private BattleController BC;
}
