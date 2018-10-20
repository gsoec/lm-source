using System;
using System.Collections.Generic;

// Token: 0x020004A1 RID: 1185
internal class ShieldLogManager
{
	// Token: 0x06001824 RID: 6180 RVA: 0x0028C020 File Offset: 0x0028A220
	public ShieldLogManager()
	{
		this.m_DataState = ShieldLogManager.eDataState.None;
		this.m_BecomeDue = default(ItemBuffData);
		this.m_BecomeDue.bEnable = false;
		this.m_KindByIcon[0] = new byte[1];
		this.m_KindByIcon[0][0] = 0;
		this.m_KindByIcon[1] = new byte[1];
		this.m_KindByIcon[1][0] = 1;
		this.m_KindByIcon[2] = new byte[2];
		this.m_KindByIcon[2][0] = 3;
		this.m_KindByIcon[2][1] = 4;
		this.m_KindByIcon[3] = new byte[1];
		this.m_KindByIcon[3][0] = 2;
		this.m_KindByIcon[4] = new byte[1];
		this.m_KindByIcon[4][0] = 5;
		this.m_KindByIcon[5] = new byte[3];
		this.m_KindByIcon[5][0] = 6;
		this.m_KindByIcon[5][1] = 8;
		this.m_KindByIcon[5][2] = 9;
		this.m_KindByIcon[6] = new byte[1];
		this.m_KindByIcon[6][0] = 7;
	}

	// Token: 0x170000AE RID: 174
	// (get) Token: 0x06001825 RID: 6181 RVA: 0x0028C140 File Offset: 0x0028A340
	public static ShieldLogManager Instance
	{
		get
		{
			if (ShieldLogManager.instance == null)
			{
				ShieldLogManager.instance = new ShieldLogManager();
			}
			return ShieldLogManager.instance;
		}
	}

	// Token: 0x06001826 RID: 6182 RVA: 0x0028C15C File Offset: 0x0028A35C
	public void RecvShieldLogList(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		for (int i = 0; i < 10; i++)
		{
			this.m_ShieldLogData[i].Clear();
			if (i < (int)b)
			{
				this.m_ShieldLogData[i].ItemID = MP.ReadUShort(-1);
				this.m_ShieldLogData[i].BeginTime = MP.ReadLong(-1);
				this.m_ShieldLogData[i].EndTime = MP.ReadLong(-1);
				this.m_ShieldLogData[i].CheckActive();
				this.m_ShieldLogData[i].SetEmpty(false);
			}
			else
			{
				this.m_ShieldLogData[i].ItemID = 0;
				this.m_ShieldLogData[i].BeginTime = 0L;
				this.m_ShieldLogData[i].EndTime = 0L;
				this.m_ShieldLogData[i].SetEmpty(true);
			}
		}
		if (b > 0)
		{
			this.m_DataState = ShieldLogManager.eDataState.Ready;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_ShieldLog, (int)this.m_DataState, 0);
		}
		else
		{
			this.m_DataState = ShieldLogManager.eDataState.Empty;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_ShieldLog, (int)this.m_DataState, 0);
		}
	}

	// Token: 0x06001827 RID: 6183 RVA: 0x0028C29C File Offset: 0x0028A49C
	public void SendShieldLogList()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_SHIELD_LOG_LIST;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06001828 RID: 6184 RVA: 0x0028C2D0 File Offset: 0x0028A4D0
	public void CheckDataState()
	{
		if (this.m_DataState == ShieldLogManager.eDataState.None || this.m_DataState == ShieldLogManager.eDataState.Dirty)
		{
			this.SendShieldLogList();
		}
		else if (this.m_DataState == ShieldLogManager.eDataState.Ready)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_ShieldLog, 1, 0);
		}
		else if (this.m_DataState == ShieldLogManager.eDataState.Empty)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_ShieldLog, 3, 0);
		}
	}

	// Token: 0x06001829 RID: 6185 RVA: 0x0028C340 File Offset: 0x0028A540
	public void OnLoginFinish()
	{
		this.m_DataState = ShieldLogManager.eDataState.None;
	}

	// Token: 0x0600182A RID: 6186 RVA: 0x0028C34C File Offset: 0x0028A54C
	public void RefreshActiveData()
	{
		if (this.m_ShieldLogData != null)
		{
			this.m_ShieldLogData[0].CheckActive();
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_ShieldLog, (int)this.m_DataState, 0);
	}

	// Token: 0x0600182B RID: 6187 RVA: 0x0028C38C File Offset: 0x0028A58C
	private byte[] GetKindByIconIdx(byte idx)
	{
		if (idx > 0 && idx < 7)
		{
			return this.m_KindByIcon[(int)idx];
		}
		return this.m_KindByIcon[0];
	}

	// Token: 0x0600182C RID: 6188 RVA: 0x0028C3B0 File Offset: 0x0028A5B0
	public void SetBecomeDueBuffData(byte iconIdx)
	{
		DataManager dataManager = DataManager.Instance;
		List<ItemBuffData> list = new List<ItemBuffData>();
		byte[] kindByIconIdx = this.GetKindByIconIdx(iconIdx);
		for (int i = 0; i < dataManager.m_RecvItemBuffData.Length; i++)
		{
			if (dataManager.m_RecvItemBuffData[i].bEnable)
			{
				for (int j = 0; j < kindByIconIdx.Length; j++)
				{
					if (kindByIconIdx[j] == dataManager.m_RecvItemBuffData[i].Kind)
					{
						list.Add(dataManager.m_RecvItemBuffData[i]);
					}
				}
			}
		}
		list.Sort(new TargetTimeComparer());
		if (list.Count != 0)
		{
			this.m_BecomeDue = list[0];
		}
		else
		{
			this.m_BecomeDue.bEnable = false;
		}
	}

	// Token: 0x0600182D RID: 6189 RVA: 0x0028C480 File Offset: 0x0028A680
	public void GetBecomeDueTimeString(CString str)
	{
		DataManager dataManager = DataManager.Instance;
		this.GetTimeString(str, (uint)(this.m_BecomeDue.TargetTime - dataManager.ServerTime));
	}

	// Token: 0x0600182E RID: 6190 RVA: 0x0028C4B0 File Offset: 0x0028A6B0
	public bool IsNeedShowBecomeDue()
	{
		return this.m_BecomeDue.bEnable;
	}

	// Token: 0x0600182F RID: 6191 RVA: 0x0028C4C0 File Offset: 0x0028A6C0
	public bool HasShieldState()
	{
		DataManager dataManager = DataManager.Instance;
		return dataManager.m_ShieldIdx >= 0 && dataManager.m_ShieldIdx < dataManager.m_RecvItemBuffData.Length && dataManager.m_RecvItemBuffData[dataManager.m_ShieldIdx].bEnable;
	}

	// Token: 0x06001830 RID: 6192 RVA: 0x0028C50C File Offset: 0x0028A70C
	~ShieldLogManager()
	{
	}

	// Token: 0x06001831 RID: 6193 RVA: 0x0028C544 File Offset: 0x0028A744
	private void GetTimeString(CString CStr, uint sec)
	{
		if (sec > 86400u)
		{
			CStr.IntToFormat((long)(sec / 86400u), 1, false);
			CStr.AppendFormat("{0}d");
			return;
		}
		uint num = sec % 86400u;
		if (num >= 3600u)
		{
			CStr.IntToFormat((long)(num / 3600u), 1, false);
			CStr.AppendFormat("{0}h");
			return;
		}
		num %= 3600u;
		CStr.IntToFormat((long)(num / 60u), 2, false);
		CStr.AppendFormat("{0}:");
		num %= 60u;
		CStr.IntToFormat((long)((ulong)num), 2, false);
		CStr.AppendFormat("{0}");
	}

	// Token: 0x04004720 RID: 18208
	public const int MAX_SHIELD_LOG = 10;

	// Token: 0x04004721 RID: 18209
	public ShieldLogManager.eDataState m_DataState;

	// Token: 0x04004722 RID: 18210
	public ShieldLogModel[] m_ShieldLogData = new ShieldLogModel[10];

	// Token: 0x04004723 RID: 18211
	private ItemBuffData m_BecomeDue;

	// Token: 0x04004724 RID: 18212
	private byte[][] m_KindByIcon = new byte[7][];

	// Token: 0x04004725 RID: 18213
	private static ShieldLogManager instance;

	// Token: 0x020004A2 RID: 1186
	private enum eBuffIcon
	{
		// Token: 0x04004727 RID: 18215
		None,
		// Token: 0x04004728 RID: 18216
		Shield,
		// Token: 0x04004729 RID: 18217
		Military,
		// Token: 0x0400472A RID: 18218
		Economy,
		// Token: 0x0400472B RID: 18219
		KingdomBuff,
		// Token: 0x0400472C RID: 18220
		BattleBuff,
		// Token: 0x0400472D RID: 18221
		WarBuff,
		// Token: 0x0400472E RID: 18222
		Max
	}

	// Token: 0x020004A3 RID: 1187
	public enum eDataState
	{
		// Token: 0x04004730 RID: 18224
		None,
		// Token: 0x04004731 RID: 18225
		Ready,
		// Token: 0x04004732 RID: 18226
		Dirty,
		// Token: 0x04004733 RID: 18227
		Empty
	}
}
