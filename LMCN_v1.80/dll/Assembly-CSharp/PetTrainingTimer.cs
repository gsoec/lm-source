using System;

// Token: 0x0200048E RID: 1166
internal class PetTrainingTimer
{
	// Token: 0x060017AC RID: 6060 RVA: 0x00286448 File Offset: 0x00284648
	public void Init(UITimeBar timer, UIButton traningBtn, UIButton ReceiveBtn, int timerID)
	{
		this.m_Timer = timer;
		this.m_TrainingBtn = traningBtn;
		this.m_ReceiveBtn = ReceiveBtn;
		this.m_State = PetManager.EPetTrainDataState.Empty;
		this.m_Timer.m_TimeBarID = timerID;
		GUIManager.Instance.CreateTimerBar(this.m_Timer, 0L, 0L, 0L, eTimeBarType.CancelType, DataManager.Instance.mStringTable.GetStringByID(17113u), DataManager.Instance.mStringTable.GetStringByID(17113u));
		this.m_Timer.m_FuntionBtn.gameObject.SetActive(false);
	}

	// Token: 0x060017AD RID: 6061 RVA: 0x002864D4 File Offset: 0x002846D4
	public void SetCancelBtnID(int dataIdx, int panelObjectIdx)
	{
		this.m_Timer.m_CancelBtn.m_BtnID2 = dataIdx;
		this.m_Timer.m_CancelBtn.m_BtnID3 = panelObjectIdx;
	}

	// Token: 0x060017AE RID: 6062 RVA: 0x00286504 File Offset: 0x00284704
	public void SetTrainBtnID(int dataIdx, int panelObjectIdx)
	{
		this.m_TrainingBtn.m_BtnID2 = dataIdx;
		this.m_TrainingBtn.m_BtnID3 = panelObjectIdx;
	}

	// Token: 0x060017AF RID: 6063 RVA: 0x00286520 File Offset: 0x00284720
	public void SetReceiveBtnID(int dataIdx, int panelObjectIdx)
	{
		this.m_ReceiveBtn.m_BtnID2 = dataIdx;
		this.m_ReceiveBtn.m_BtnID3 = panelObjectIdx;
	}

	// Token: 0x060017B0 RID: 6064 RVA: 0x0028653C File Offset: 0x0028473C
	public void SetTimer(long begin, long require, string petName, IUTimeBarOnTimer hander)
	{
		if (this.m_Timer != null)
		{
			this.m_Timer.m_Handler = hander;
			GUIManager.Instance.SetTimerBar(this.m_Timer, begin, begin + require, 0L, eTimeBarType.CancelType, DataManager.Instance.mStringTable.GetStringByID(17113u), petName);
		}
	}

	// Token: 0x060017B1 RID: 6065 RVA: 0x00286594 File Offset: 0x00284794
	public void SetState(PetManager.EPetTrainDataState state)
	{
		this.m_State = state;
		switch (this.m_State)
		{
		case PetManager.EPetTrainDataState.Empty:
			this.m_Timer.gameObject.SetActive(false);
			this.m_TrainingBtn.gameObject.SetActive(true);
			this.m_ReceiveBtn.gameObject.SetActive(false);
			break;
		case PetManager.EPetTrainDataState.Training:
			this.m_Timer.gameObject.SetActive(true);
			this.m_TrainingBtn.gameObject.SetActive(false);
			this.m_ReceiveBtn.gameObject.SetActive(false);
			break;
		case PetManager.EPetTrainDataState.CanReceive:
			this.m_Timer.gameObject.SetActive(false);
			this.m_TrainingBtn.gameObject.SetActive(false);
			this.m_ReceiveBtn.gameObject.SetActive(true);
			break;
		case PetManager.EPetTrainDataState.Received:
			this.m_Timer.gameObject.SetActive(false);
			this.m_TrainingBtn.gameObject.SetActive(true);
			this.m_ReceiveBtn.gameObject.SetActive(false);
			break;
		}
	}

	// Token: 0x060017B2 RID: 6066 RVA: 0x002866AC File Offset: 0x002848AC
	public void OnTimer()
	{
		this.SetState(PetManager.EPetTrainDataState.CanReceive);
	}

	// Token: 0x060017B3 RID: 6067 RVA: 0x002866B8 File Offset: 0x002848B8
	public void onFinish()
	{
		this.SetState(PetManager.EPetTrainDataState.Received);
	}

	// Token: 0x060017B4 RID: 6068 RVA: 0x002866C4 File Offset: 0x002848C4
	public void OnClose()
	{
		if (this.m_Timer != null)
		{
			GUIManager.Instance.RemoverTimeBaarToList(this.m_Timer);
		}
	}

	// Token: 0x060017B5 RID: 6069 RVA: 0x002866E8 File Offset: 0x002848E8
	public void RefreshFontTexture()
	{
		if (this.m_Timer)
		{
			this.m_Timer.Refresh_FontTexture();
		}
	}

	// Token: 0x0400466C RID: 18028
	private UITimeBar m_Timer;

	// Token: 0x0400466D RID: 18029
	private UIButton m_TrainingBtn;

	// Token: 0x0400466E RID: 18030
	private UIButton m_ReceiveBtn;

	// Token: 0x0400466F RID: 18031
	private PetManager.EPetTrainDataState m_State;

	// Token: 0x0200048F RID: 1167
	public enum eTrainingState
	{
		// Token: 0x04004671 RID: 18033
		Empty,
		// Token: 0x04004672 RID: 18034
		Training,
		// Token: 0x04004673 RID: 18035
		CanReceive,
		// Token: 0x04004674 RID: 18036
		Received,
		// Token: 0x04004675 RID: 18037
		Closed,
		// Token: 0x04004676 RID: 18038
		NextOpne
	}
}
