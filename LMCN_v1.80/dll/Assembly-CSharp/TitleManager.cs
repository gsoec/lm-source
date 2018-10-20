using System;

// Token: 0x020007BD RID: 1981
internal class TitleManager
{
	// Token: 0x060028C8 RID: 10440 RVA: 0x00449748 File Offset: 0x00447948
	private TitleManager()
	{
	}

	// Token: 0x17000112 RID: 274
	// (get) Token: 0x060028C9 RID: 10441 RVA: 0x004497CC File Offset: 0x004479CC
	public static TitleManager Instance
	{
		get
		{
			if (TitleManager.instance == null)
			{
				TitleManager.instance = new TitleManager();
			}
			return TitleManager.instance;
		}
	}

	// Token: 0x060028CA RID: 10442 RVA: 0x004497E8 File Offset: 0x004479E8
	~TitleManager()
	{
	}

	// Token: 0x060028CB RID: 10443 RVA: 0x00449820 File Offset: 0x00447A20
	public void KingdomTitle_Error(byte Result)
	{
		switch (Result)
		{
		}
	}

	// Token: 0x060028CC RID: 10444 RVA: 0x00449898 File Offset: 0x00447A98
	public void WNTitle_Error(byte Result, bool bRemove = false)
	{
		switch (Result)
		{
		case 1:
		case 2:
		case 3:
		case 5:
		case 6:
		{
			CString cstring = StringManager.Instance.StaticString1024();
			if (bRemove)
			{
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(7010u));
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(5349u));
			}
			else
			{
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(11045u));
			}
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
			break;
		}
		case 4:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(11039u), 255, true);
			break;
		}
	}

	// Token: 0x060028CD RID: 10445 RVA: 0x00449974 File Offset: 0x00447B74
	public void NobilityTitle_Error(byte Result)
	{
		switch (Result)
		{
		}
	}

	// Token: 0x060028CE RID: 10446 RVA: 0x004499D8 File Offset: 0x00447BD8
	public void InitialTitleName(byte Count)
	{
		if (this.RecvTitleName == null)
		{
			this.RecvTitleNameNoTag = new CString[(int)Count];
			this.RecvTitleName = new CString[(int)Count];
			this.RecvTitleIcon = new ushort[(int)Count];
			for (int i = 0; i < (int)Count; i++)
			{
				this.RecvTitleIcon[i] = 0;
				this.RecvTitleName[i] = new CString(25);
				this.RecvTitleNameNoTag[i] = new CString(14);
			}
		}
	}

	// Token: 0x060028CF RID: 10447 RVA: 0x00449A50 File Offset: 0x00447C50
	public void Send_KingdomTitle_Change(ushort TitleID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_KINGDOM_TITLE_CHANGE;
		messagePacket.AddSeqId();
		messagePacket.Add(this.OpenTitleName.ToString(), 13);
		messagePacket.Add(TitleID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Title);
	}

	// Token: 0x060028D0 RID: 10448 RVA: 0x00449AA8 File Offset: 0x00447CA8
	public void Recv_KingdomTitle_Change(MessagePacket MP)
	{
		GUIManager guimanager = GUIManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != 0)
			{
				int num2 = (int)(num - 1);
				if (num2 < this.RecvTitleIcon.Length)
				{
					this.RecvTitleIcon[num2] = 0;
					this.RecvTitleName[num2].Length = 0;
					this.RecvTitleNameNoTag[num2].Length = 0;
				}
			}
			ushort num3 = MP.ReadUShort(-1);
			if (num3 != 0)
			{
				int num4 = (int)(num3 - 1);
				if (num4 < this.RecvTitleIcon.Length)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					this.RecvTitleNameNoTag[num4].Length = 0;
					this.RecvTitleIcon[num4] = MP.ReadUShort(-1);
					MP.ReadStringPlus(13, this.RecvTitleNameNoTag[num4], -1);
					MP.ReadStringPlus(3, cstring, -1);
					this.RecvTitleName[num4].Length = 0;
					if (this.RecvTitleIcon[num4] != 0)
					{
						if (guimanager.IsArabic)
						{
							this.RecvTitleName[num4].Append(this.RecvTitleNameNoTag[num4]);
						}
						if (cstring.Length != 0)
						{
							this.RecvTitleName[num4].StringToFormat(cstring);
							this.RecvTitleName[num4].AppendFormat("[{0}]");
						}
						if (!guimanager.IsArabic)
						{
							this.RecvTitleName[num4].Append(this.RecvTitleNameNoTag[num4]);
						}
					}
					if (DataManager.CompareStr(this.RecvTitleNameNoTag[num4], DataManager.Instance.mLordProfile.PlayerName) == 0)
					{
						DataManager.Instance.mLordProfile.Title = num3;
					}
				}
			}
			guimanager.UpdateUI(EGUIWindow.UI_Title, 0, 0);
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.Append(DataManager.Instance.mStringTable.GetStringByID(11046u));
			guimanager.AddHUDMessage(cstring2.ToString(), 255, true);
		}
		else
		{
			CString cstring3 = StringManager.Instance.StaticString1024();
			cstring3.Append(DataManager.Instance.mStringTable.GetStringByID(11045u));
			guimanager.AddHUDMessage(cstring3.ToString(), 255, true);
			this.KingdomTitle_Error(b);
		}
		guimanager.HideUILock(EUILock.Title);
	}

	// Token: 0x060028D1 RID: 10449 RVA: 0x00449CD4 File Offset: 0x00447ED4
	public void Recv_KingdomTitle_ChangeByOthers(MessagePacket MP)
	{
		if (this.RecvTitleName == null)
		{
			return;
		}
		GUIManager guimanager = GUIManager.Instance;
		if (MP.ReadByte(-1) == 0)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != 0)
			{
				int num2 = (int)(num - 1);
				if (num2 < this.RecvTitleIcon.Length)
				{
					this.RecvTitleIcon[num2] = 0;
					this.RecvTitleName[num2].Length = 0;
					this.RecvTitleNameNoTag[num2].Length = 0;
				}
			}
			ushort num3 = MP.ReadUShort(-1);
			if (num3 != 0)
			{
				int num4 = (int)(num3 - 1);
				if (num4 < this.RecvTitleIcon.Length)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					this.RecvTitleNameNoTag[num4].Length = 0;
					this.RecvTitleIcon[num4] = MP.ReadUShort(-1);
					MP.ReadStringPlus(13, this.RecvTitleNameNoTag[num4], -1);
					MP.ReadStringPlus(3, cstring, -1);
					this.RecvTitleName[num4].Length = 0;
					if (this.RecvTitleIcon[num4] != 0)
					{
						if (guimanager.IsArabic)
						{
							this.RecvTitleName[num4].Append(this.RecvTitleNameNoTag[num4]);
						}
						if (cstring.Length != 0)
						{
							this.RecvTitleName[num4].StringToFormat(cstring);
							this.RecvTitleName[num4].AppendFormat("[{0}]");
						}
						if (!guimanager.IsArabic)
						{
							this.RecvTitleName[num4].Append(this.RecvTitleNameNoTag[num4]);
						}
					}
					if (DataManager.CompareStr(this.RecvTitleNameNoTag[num4], DataManager.Instance.mLordProfile.PlayerName) == 0)
					{
						DataManager.Instance.mLordProfile.Title = num3;
					}
				}
			}
			guimanager.UpdateUI(EGUIWindow.UI_Title, 1, 0);
		}
	}

	// Token: 0x060028D2 RID: 10450 RVA: 0x00449E80 File Offset: 0x00448080
	public void Send_KingdomTitle_Remove(ushort TitleID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_KINGDOM_TITLE_REMOVE;
		messagePacket.AddSeqId();
		messagePacket.Add(TitleID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Title);
	}

	// Token: 0x060028D3 RID: 10451 RVA: 0x00449EC8 File Offset: 0x004480C8
	public void Recv_KingdomTitle_Remove(MessagePacket MP)
	{
		GUIManager guimanager = GUIManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != 0)
			{
				int num2 = (int)(num - 1);
				if (num2 < this.RecvTitleIcon.Length)
				{
					this.RecvTitleIcon[num2] = 0;
					this.RecvTitleName[num2].Length = 0;
					this.RecvTitleNameNoTag[num2].Length = 0;
				}
				guimanager.UpdateUI(EGUIWindow.UI_Title, 0, 0);
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(7010u));
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(5348u));
				guimanager.AddHUDMessage(cstring.ToString(), 255, true);
			}
		}
		else
		{
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.Append(DataManager.Instance.mStringTable.GetStringByID(7010u));
			cstring2.Append(DataManager.Instance.mStringTable.GetStringByID(5349u));
			guimanager.AddHUDMessage(cstring2.ToString(), 255, true);
			this.KingdomTitle_Error(b);
		}
		guimanager.HideUILock(EUILock.Title);
	}

	// Token: 0x060028D4 RID: 10452 RVA: 0x00449FF8 File Offset: 0x004481F8
	public void Recv_KingdomTitle_RemoveByOthers(MessagePacket MP)
	{
		if (this.RecvTitleName == null)
		{
			return;
		}
		GUIManager guimanager = GUIManager.Instance;
		if (MP.ReadByte(-1) == 0)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != 0)
			{
				int num2 = (int)(num - 1);
				if (num2 < this.RecvTitleIcon.Length)
				{
					this.RecvTitleIcon[num2] = 0;
					this.RecvTitleName[num2].Length = 0;
					this.RecvTitleNameNoTag[num2].Length = 0;
				}
				guimanager.UpdateUI(EGUIWindow.UI_Title, 1, 0);
			}
		}
	}

	// Token: 0x060028D5 RID: 10453 RVA: 0x0044A074 File Offset: 0x00448274
	public void Send_KingdomTitle_List_King()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_HOMEKINGDOM_TITLE_LIST;
		messagePacket.AddSeqId();
		messagePacket.Add(DataManager.Instance.RoleAttr.Name.ToString(), 13);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Title);
	}

	// Token: 0x060028D6 RID: 10454 RVA: 0x0044A0D0 File Offset: 0x004482D0
	public void Send_KingdomTitle_List()
	{
		MessagePacket messagePacket;
		if (DataManager.MapDataController.FocusKingdomID == 0 || DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
		{
			messagePacket = new MessagePacket(1024);
		}
		else
		{
			messagePacket = MessagePacket.GetGuestMessagePack();
		}
		messagePacket.Protocol = Protocol._MSG_REQUEST_KINGDOM_TITLE_LIST;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Title);
	}

	// Token: 0x060028D7 RID: 10455 RVA: 0x0044A148 File Offset: 0x00448348
	public void Recv_KingdomTitle_List(MessagePacket MP)
	{
		GUIManager guimanager = GUIManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			byte b2 = MP.ReadByte(-1);
			this.InitialTitleName(b2);
			for (int i = 0; i < (int)b2; i++)
			{
				if (i >= this.RecvTitleName.Length)
				{
					break;
				}
				CString cstring = StringManager.Instance.StaticString1024();
				this.RecvTitleNameNoTag[i].Length = 0;
				this.RecvTitleIcon[i] = MP.ReadUShort(-1);
				MP.ReadStringPlus(13, this.RecvTitleNameNoTag[i], -1);
				MP.ReadStringPlus(3, cstring, -1);
				this.RecvTitleName[i].Length = 0;
				if (this.RecvTitleIcon[i] != 0)
				{
					if (guimanager.IsArabic)
					{
						this.RecvTitleName[i].Append(this.RecvTitleNameNoTag[i]);
					}
					if (cstring.Length != 0)
					{
						this.RecvTitleName[i].StringToFormat(cstring);
						this.RecvTitleName[i].AppendFormat("[{0}]");
					}
					if (!guimanager.IsArabic)
					{
						this.RecvTitleName[i].Append(this.RecvTitleNameNoTag[i]);
					}
				}
			}
			Door door = guimanager.FindMenu(EGUIWindow.Door) as Door;
			if (door && !door.OpenMenu(EGUIWindow.UI_Title, (int)this.WaitTitleList, 0, false))
			{
				guimanager.UpdateUI(EGUIWindow.UI_Title, 0, 0);
			}
			this.WaitTitleList = 0;
		}
		else
		{
			this.KingdomTitle_Error(b);
		}
		guimanager.HideUILock(EUILock.Title);
	}

	// Token: 0x060028D8 RID: 10456 RVA: 0x0044A2C8 File Offset: 0x004484C8
	public void Recv_KingdomTitle_Get(MessagePacket MP)
	{
		DataManager dataManager = DataManager.Instance;
		dataManager.RoleAttr.KingdomTitle = MP.ReadUShort(-1);
		if (dataManager.RoleAttr.KingdomTitle > 1)
		{
			TitleData recordByKey = dataManager.TitleData.GetRecordByKey(dataManager.RoleAttr.KingdomTitle);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(dataManager.mStringTable.GetStringByID((uint)recordByKey.StringID));
			cstring.AppendFormat(dataManager.mStringTable.GetStringByID(9368u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
		}
		if (DataManager.MapDataController.IsKingdomChief())
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Title, 4, 0);
		}
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Wonder);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 1, 0);
	}

	// Token: 0x060028D9 RID: 10457 RVA: 0x0044A3A0 File Offset: 0x004485A0
	public void OpenTitleList()
	{
		this.WaitTitleList = 1;
		this.Send_KingdomTitle_List();
	}

	// Token: 0x060028DA RID: 10458 RVA: 0x0044A3B0 File Offset: 0x004485B0
	public void OpenTitleSet(CString OpenName)
	{
		this.WaitTitleList = 2;
		this.OpenTitleName.Length = 0;
		this.OpenTitleName.Append(OpenName);
		if (DataManager.MapDataController.kingdomData.kingdomID != DataManager.MapDataController.FocusKingdomID)
		{
			this.Send_KingdomTitle_List_King();
		}
		else
		{
			this.Send_KingdomTitle_List();
		}
	}

	// Token: 0x060028DB RID: 10459 RVA: 0x0044A40C File Offset: 0x0044860C
	public void InitialTitleNameW(byte Count)
	{
		if (this.RecvTitleNameW == null)
		{
			this.RecvTitleNameNoTagW = new CString[(int)Count];
			this.RecvTitleNameW = new CString[(int)Count];
			this.RecvTitleIconW = new ushort[(int)Count];
			this.RecvTitleKingdomW = new ushort[(int)Count];
			for (int i = 0; i < (int)Count; i++)
			{
				this.RecvTitleKingdomW[i] = 0;
				this.RecvTitleIconW[i] = 0;
				this.RecvTitleNameW[i] = new CString(25);
				this.RecvTitleNameNoTagW[i] = new CString(14);
			}
		}
	}

	// Token: 0x060028DC RID: 10460 RVA: 0x0044A498 File Offset: 0x00448698
	public void Send_WorldTitle_Change(ushort TitleID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_WORLD_TITLE_CHANGE;
		messagePacket.AddSeqId();
		messagePacket.Add(this.OpenTitleNameW.ToString(), 13);
		messagePacket.Add(TitleID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Title);
	}

	// Token: 0x060028DD RID: 10461 RVA: 0x0044A4F0 File Offset: 0x004486F0
	public void Recv_WorldTitle_Change(MessagePacket MP)
	{
		GUIManager guimanager = GUIManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != 0)
			{
				int num2 = (int)(num - 1);
				if (num2 < this.RecvTitleIconW.Length)
				{
					this.RecvTitleIconW[num2] = 0;
					this.RecvTitleKingdomW[num2] = 0;
					this.RecvTitleNameW[num2].Length = 0;
					this.RecvTitleNameNoTagW[num2].Length = 0;
				}
			}
			ushort num3 = MP.ReadUShort(-1);
			if (num3 != 0)
			{
				int num4 = (int)(num3 - 1);
				if (num4 < this.RecvTitleIconW.Length)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					this.RecvTitleNameNoTagW[num4].Length = 0;
					this.RecvTitleIconW[num4] = MP.ReadUShort(-1);
					this.RecvTitleKingdomW[num4] = MP.ReadUShort(-1);
					MP.ReadStringPlus(13, this.RecvTitleNameNoTagW[num4], -1);
					MP.ReadStringPlus(3, cstring, -1);
					this.RecvTitleNameW[num4].Length = 0;
					if (this.RecvTitleIconW[num4] != 0)
					{
						ushort kingdomID = DataManager.MapDataController.kingdomData.kingdomID;
						GameConstants.FormatRoleName(this.RecvTitleNameW[num4], this.RecvTitleNameNoTagW[num4], cstring, null, 0, (kingdomID == this.RecvTitleKingdomW[num4]) ? 0 : this.RecvTitleKingdomW[num4], null, null, null, null);
					}
				}
			}
			guimanager.UpdateUI(EGUIWindow.UI_Title, 0, 0);
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.Append(DataManager.Instance.mStringTable.GetStringByID(11046u));
			guimanager.AddHUDMessage(cstring2.ToString(), 255, true);
		}
		else
		{
			this.WNTitle_Error(b, false);
		}
		guimanager.HideUILock(EUILock.Title);
	}

	// Token: 0x060028DE RID: 10462 RVA: 0x0044A6A4 File Offset: 0x004488A4
	public void Recv_WorldTitle_ChangeByOthers(MessagePacket MP)
	{
		if (this.RecvTitleNameW == null)
		{
			return;
		}
		GUIManager guimanager = GUIManager.Instance;
		if (MP.ReadByte(-1) == 0)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != 0)
			{
				int num2 = (int)(num - 1);
				if (num2 < this.RecvTitleIconW.Length)
				{
					this.RecvTitleIconW[num2] = 0;
					this.RecvTitleKingdomW[num2] = 0;
					this.RecvTitleNameW[num2].Length = 0;
					this.RecvTitleNameNoTagW[num2].Length = 0;
				}
			}
			ushort num3 = MP.ReadUShort(-1);
			if (num3 != 0)
			{
				int num4 = (int)(num3 - 1);
				if (num4 < this.RecvTitleIconW.Length)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					this.RecvTitleNameNoTagW[num4].Length = 0;
					this.RecvTitleIconW[num4] = MP.ReadUShort(-1);
					this.RecvTitleKingdomW[num4] = MP.ReadUShort(-1);
					MP.ReadStringPlus(13, this.RecvTitleNameNoTagW[num4], -1);
					MP.ReadStringPlus(3, cstring, -1);
					this.RecvTitleNameW[num4].Length = 0;
					if (this.RecvTitleIconW[num4] != 0)
					{
						ushort kingdomID = DataManager.MapDataController.kingdomData.kingdomID;
						GameConstants.FormatRoleName(this.RecvTitleNameW[num4], this.RecvTitleNameNoTagW[num4], cstring, null, 0, (kingdomID == this.RecvTitleKingdomW[num4]) ? 0 : this.RecvTitleKingdomW[num4], null, null, null, null);
					}
				}
			}
			guimanager.UpdateUI(EGUIWindow.UI_Title, 2, 0);
		}
	}

	// Token: 0x060028DF RID: 10463 RVA: 0x0044A814 File Offset: 0x00448A14
	public void Send_WorldTitle_Remove(ushort TitleID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_WORLD_TITLE_REMOVE;
		messagePacket.AddSeqId();
		messagePacket.Add(TitleID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Title);
	}

	// Token: 0x060028E0 RID: 10464 RVA: 0x0044A85C File Offset: 0x00448A5C
	public void Recv_WorldTitle_Remove(MessagePacket MP)
	{
		GUIManager guimanager = GUIManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != 0)
			{
				int num2 = (int)(num - 1);
				if (num2 < this.RecvTitleIconW.Length)
				{
					this.RecvTitleIconW[num2] = 0;
					this.RecvTitleNameW[num2].Length = 0;
					this.RecvTitleNameNoTagW[num2].Length = 0;
				}
				guimanager.UpdateUI(EGUIWindow.UI_Title, 0, 0);
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(7010u));
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(5348u));
				guimanager.AddHUDMessage(cstring.ToString(), 255, true);
			}
		}
		else
		{
			this.WNTitle_Error(b, true);
		}
		guimanager.HideUILock(EUILock.Title);
	}

	// Token: 0x060028E1 RID: 10465 RVA: 0x0044A938 File Offset: 0x00448B38
	public void Recv_WorldTitle_RemoveByOthers(MessagePacket MP)
	{
		if (this.RecvTitleNameW == null)
		{
			return;
		}
		GUIManager guimanager = GUIManager.Instance;
		if (MP.ReadByte(-1) == 0)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != 0)
			{
				int num2 = (int)(num - 1);
				if (num2 < this.RecvTitleIconW.Length)
				{
					this.RecvTitleIconW[num2] = 0;
					this.RecvTitleNameW[num2].Length = 0;
					this.RecvTitleNameNoTagW[num2].Length = 0;
				}
				guimanager.UpdateUI(EGUIWindow.UI_Title, 2, 0);
			}
		}
	}

	// Token: 0x060028E2 RID: 10466 RVA: 0x0044A9B4 File Offset: 0x00448BB4
	public void Send_WorldTitle_List()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_WORLD_TITLE_LIST;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Title);
	}

	// Token: 0x060028E3 RID: 10467 RVA: 0x0044A9F4 File Offset: 0x00448BF4
	public void Recv_WorldTitle_List(MessagePacket MP)
	{
		GUIManager guimanager = GUIManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			byte b2 = MP.ReadByte(-1);
			this.InitialTitleNameW(b2);
			for (int i = 0; i < (int)b2; i++)
			{
				if (i >= this.RecvTitleNameW.Length)
				{
					break;
				}
				CString cstring = StringManager.Instance.StaticString1024();
				this.RecvTitleNameNoTagW[i].Length = 0;
				this.RecvTitleIconW[i] = MP.ReadUShort(-1);
				this.RecvTitleKingdomW[i] = MP.ReadUShort(-1);
				MP.ReadStringPlus(13, this.RecvTitleNameNoTagW[i], -1);
				MP.ReadStringPlus(3, cstring, -1);
				this.RecvTitleNameW[i].Length = 0;
				if (this.RecvTitleIconW[i] != 0)
				{
					ushort kingdomID = DataManager.MapDataController.kingdomData.kingdomID;
					GameConstants.FormatRoleName(this.RecvTitleNameW[i], this.RecvTitleNameNoTagW[i], cstring, null, 0, (kingdomID == this.RecvTitleKingdomW[i]) ? 0 : this.RecvTitleKingdomW[i], null, null, null, null);
				}
			}
			Door door = guimanager.FindMenu(EGUIWindow.Door) as Door;
			if (door && !door.OpenMenu(EGUIWindow.UI_Title, (int)this.WaitTitleList, 0, false))
			{
				guimanager.UpdateUI(EGUIWindow.UI_Title, 0, 0);
			}
			this.WaitTitleList = 0;
		}
		else
		{
			this.WNTitle_Error(b, false);
		}
		guimanager.HideUILock(EUILock.Title);
	}

	// Token: 0x060028E4 RID: 10468 RVA: 0x0044AB60 File Offset: 0x00448D60
	public void Recv_WorldTitle_Get(MessagePacket MP)
	{
		DataManager dataManager = DataManager.Instance;
		dataManager.RoleAttr.WorldTitle_Personal = MP.ReadUShort(-1);
		if (dataManager.RoleAttr.WorldTitle_Personal > 1)
		{
			TitleData recordByKey = dataManager.TitleDataW.GetRecordByKey(dataManager.RoleAttr.WorldTitle_Personal);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(dataManager.mStringTable.GetStringByID((uint)recordByKey.StringID));
			cstring.AppendFormat(dataManager.mStringTable.GetStringByID(9368u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
		}
		if (DataManager.MapDataController.IsWorldChief())
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Title, 4, 0);
		}
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Wonder);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 1, 0);
	}

	// Token: 0x060028E5 RID: 10469 RVA: 0x0044AC38 File Offset: 0x00448E38
	public void OpenTitleListW(CString OpenName = null)
	{
		if (OpenName == null)
		{
			this.WaitTitleList = 3;
		}
		else
		{
			this.WaitTitleList = 4;
			this.OpenTitleNameW.Length = 0;
			this.OpenTitleNameW.Append(OpenName);
		}
		this.Send_WorldTitle_List();
	}

	// Token: 0x060028E6 RID: 10470 RVA: 0x0044AC74 File Offset: 0x00448E74
	public void InitialTitleNameN(byte Count)
	{
		if (this.RecvTitleKingdomID == null)
		{
			this.RecvTitleKingdomID = new ushort[(int)Count];
			this.RecvTitleNameN = new CString[(int)Count];
			for (int i = 0; i < (int)Count; i++)
			{
				this.RecvTitleKingdomID[i] = 0;
				this.RecvTitleNameN[i] = new CString(25);
			}
		}
	}

	// Token: 0x060028E7 RID: 10471 RVA: 0x0044ACD0 File Offset: 0x00448ED0
	public void Send_NationalTitle_Change(ushort KingdomID, ushort TitleID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_NATIONAL_TITLE_CHANGE;
		messagePacket.AddSeqId();
		messagePacket.Add(KingdomID);
		messagePacket.Add(TitleID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Title);
	}

	// Token: 0x060028E8 RID: 10472 RVA: 0x0044AD1C File Offset: 0x00448F1C
	public void Recv_NationalTitle_Change(MessagePacket MP)
	{
		GUIManager guimanager = GUIManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != 0)
			{
				int num2 = (int)(num - 1);
				if (num2 < this.RecvTitleKingdomID.Length)
				{
					CString tmpS = StringManager.Instance.StaticString1024();
					this.RecvTitleKingdomID[num2] = MP.ReadUShort(-1);
					this.RecvTitleNameN[num2].Length = 0;
					if (this.RecvTitleKingdomID[num2] != 0)
					{
						DataManager.MapDataController.GetKingdomName(this.RecvTitleKingdomID[num2], ref tmpS);
						this.RecvTitleNameN[num2].IntToFormat((long)this.RecvTitleKingdomID[num2], 1, false);
						this.RecvTitleNameN[num2].StringToFormat(tmpS);
						this.RecvTitleNameN[num2].AppendFormat("#{0} {1}");
					}
				}
			}
			guimanager.UpdateUI(EGUIWindow.UI_Title, 0, 0);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.Append(DataManager.Instance.mStringTable.GetStringByID(11046u));
			guimanager.AddHUDMessage(cstring.ToString(), 255, true);
			this.NTitleCount += 1;
			if (!this.CheckGivetNTile() && DataManager.Instance.RoleAttr.WorldTitle_Personal == 1)
			{
				DataManager.msgBuffer[0] = 128;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
		}
		else
		{
			this.WNTitle_Error(b, false);
		}
		guimanager.HideUILock(EUILock.Title);
	}

	// Token: 0x060028E9 RID: 10473 RVA: 0x0044AE84 File Offset: 0x00449084
	public void Send_NationalTitle_List()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_NATIONAL_TITLE_LIST;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Title);
	}

	// Token: 0x060028EA RID: 10474 RVA: 0x0044AEC4 File Offset: 0x004490C4
	public void Recv_NationalTitle_List(MessagePacket MP)
	{
		GUIManager guimanager = GUIManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			this.WKNameNoTag.Length = 0;
			this.WKName.Length = 0;
			this.WKIcon = MP.ReadUShort(-1);
			this.WKKingdom = MP.ReadUShort(-1);
			MP.ReadStringPlus(13, this.WKNameNoTag, -1);
			MP.ReadStringPlus(3, cstring, -1);
			if (this.WKIcon != 0)
			{
				ushort kingdomID = DataManager.MapDataController.kingdomData.kingdomID;
				GameConstants.FormatRoleName(this.WKName, this.WKNameNoTag, cstring, null, 0, (kingdomID == this.WKKingdom) ? 0 : this.WKKingdom, null, null, null, null);
			}
			byte b2 = MP.ReadByte(-1);
			this.InitialTitleNameN(b2);
			for (int i = 0; i < (int)b2; i++)
			{
				if (i >= this.RecvTitleKingdomID.Length)
				{
					break;
				}
				CString tmpS = StringManager.Instance.StaticString1024();
				this.RecvTitleKingdomID[i] = MP.ReadUShort(-1);
				this.RecvTitleNameN[i].Length = 0;
				if (this.RecvTitleKingdomID[i] != 0)
				{
					DataManager.MapDataController.GetKingdomName(this.RecvTitleKingdomID[i], ref tmpS);
					this.RecvTitleNameN[i].IntToFormat((long)this.RecvTitleKingdomID[i], 1, false);
					this.RecvTitleNameN[i].StringToFormat(tmpS);
					this.RecvTitleNameN[i].AppendFormat("#{0} {1}");
				}
			}
			Door door = guimanager.FindMenu(EGUIWindow.Door) as Door;
			if (door && !door.OpenMenu(EGUIWindow.UI_Title, (int)this.WaitTitleList, 0, false))
			{
				guimanager.UpdateUI(EGUIWindow.UI_Title, 0, 0);
			}
			this.WaitTitleList = 0;
		}
		else
		{
			this.WNTitle_Error(b, false);
		}
		guimanager.HideUILock(EUILock.Title);
	}

	// Token: 0x060028EB RID: 10475 RVA: 0x0044B0AC File Offset: 0x004492AC
	public void Recv_NationalTitle_Get(MessagePacket MP)
	{
		DataManager dataManager = DataManager.Instance;
		dataManager.RoleAttr.WorldTitle_Country = MP.ReadUShort(-1);
		if (dataManager.RoleAttr.WorldTitle_Country > 0)
		{
			TitleData recordByKey = dataManager.TitleDataN.GetRecordByKey(dataManager.RoleAttr.WorldTitle_Country);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(dataManager.mStringTable.GetStringByID((uint)recordByKey.StringID));
			cstring.AppendFormat(dataManager.mStringTable.GetStringByID(11015u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
		}
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Wonder);
		DataManager.Instance.UpdateItemBuffIcon();
		GameManager.OnRefresh(NetworkNews.Refresh_BuffList, null);
	}

	// Token: 0x060028EC RID: 10476 RVA: 0x0044B16C File Offset: 0x0044936C
	public void Recv_NationalTitle_Count(MessagePacket MP)
	{
		this.NTitleCount = MP.ReadUShort(-1);
	}

	// Token: 0x060028ED RID: 10477 RVA: 0x0044B17C File Offset: 0x0044937C
	public void OpenTitleListN(ushort KingdomID = 0)
	{
		if (KingdomID == 0)
		{
			this.WaitTitleList = 5;
		}
		else
		{
			this.WaitTitleList = 6;
			this.OpenKingdomID = KingdomID;
		}
		this.Send_NationalTitle_List();
	}

	// Token: 0x060028EE RID: 10478 RVA: 0x0044B1B0 File Offset: 0x004493B0
	public bool CheckGivetNTile()
	{
		return (int)this.NTitleCount < DataManager.Instance.TitleDataN.TableCount;
	}

	// Token: 0x060028EF RID: 10479 RVA: 0x0044B1CC File Offset: 0x004493CC
	public void InitialNobilityTitleName(byte Count)
	{
		if (this.RecvNobilityTitleName == null)
		{
			this.RecvNobilityTitleNameNoTag = new CString[(int)Count];
			this.RecvNobilityTitleName = new CString[(int)Count];
			this.RecvNobilityKingdomID = new ushort[(int)Count];
			this.RecvNobilityTitleIcon = new ushort[(int)Count];
			for (int i = 0; i < (int)Count; i++)
			{
				this.RecvNobilityTitleIcon[i] = 0;
				this.RecvNobilityKingdomID[i] = 0;
				this.RecvNobilityTitleName[i] = new CString(25);
				this.RecvNobilityTitleNameNoTag[i] = new CString(14);
			}
		}
	}

	// Token: 0x060028F0 RID: 10480 RVA: 0x0044B258 File Offset: 0x00449458
	public void Send_NobilityTitle_Change(ushort TitleID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_NOBILITY_TITLE_CHANGE;
		messagePacket.AddSeqId();
		messagePacket.Add(this.OpenNobilityTitleName.ToString(), 13);
		messagePacket.Add(TitleID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Title);
	}

	// Token: 0x060028F1 RID: 10481 RVA: 0x0044B2B0 File Offset: 0x004494B0
	public void Recv_NobilityTitle_Change(MessagePacket MP)
	{
		GUIManager guimanager = GUIManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != 0)
			{
				int num2 = (int)(num - 1);
				if (num2 < this.RecvNobilityTitleIcon.Length)
				{
					this.RecvNobilityTitleIcon[num2] = 0;
					this.RecvNobilityTitleName[num2].Length = 0;
					this.RecvNobilityTitleNameNoTag[num2].Length = 0;
				}
			}
			ushort num3 = MP.ReadUShort(-1);
			if (num3 != 0)
			{
				int num4 = (int)(num3 - 1);
				if (num4 < this.RecvNobilityTitleIcon.Length)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					this.RecvNobilityTitleNameNoTag[num4].Length = 0;
					this.RecvNobilityTitleIcon[num4] = MP.ReadUShort(-1);
					this.RecvNobilityKingdomID[num4] = MP.ReadUShort(-1);
					MP.ReadStringPlus(13, this.RecvNobilityTitleNameNoTag[num4], -1);
					MP.ReadStringPlus(3, cstring, -1);
					this.RecvNobilityTitleName[num4].Length = 0;
					if (this.RecvNobilityTitleIcon[num4] != 0)
					{
						ushort kingdomID = DataManager.MapDataController.kingdomData.kingdomID;
						GameConstants.FormatRoleName(this.RecvNobilityTitleName[num4], this.RecvNobilityTitleNameNoTag[num4], cstring, null, 0, (kingdomID == this.RecvNobilityKingdomID[num4]) ? 0 : this.RecvNobilityKingdomID[num4], null, null, null, null);
					}
					if (DataManager.CompareStr(this.RecvNobilityTitleNameNoTag[num4], DataManager.Instance.mLordProfile.PlayerName) == 0)
					{
						DataManager.Instance.mLordProfile.NobilityTitle = num3;
					}
				}
			}
			guimanager.UpdateUI(EGUIWindow.UI_Title, 0, 0);
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.Append(DataManager.Instance.mStringTable.GetStringByID(11046u));
			guimanager.AddHUDMessage(cstring2.ToString(), 255, true);
		}
		else
		{
			CString cstring3 = StringManager.Instance.StaticString1024();
			cstring3.Append(DataManager.Instance.mStringTable.GetStringByID(11045u));
			guimanager.AddHUDMessage(cstring3.ToString(), 255, true);
			this.NobilityTitle_Error(b);
		}
		guimanager.HideUILock(EUILock.Title);
	}

	// Token: 0x060028F2 RID: 10482 RVA: 0x0044B4C8 File Offset: 0x004496C8
	public void Recv_NobilityTitle_ChangeByOthers(MessagePacket MP)
	{
		if (this.RecvNobilityTitleName == null)
		{
			return;
		}
		GUIManager guimanager = GUIManager.Instance;
		if (MP.ReadByte(-1) == 0)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != 0)
			{
				int num2 = (int)(num - 1);
				if (num2 < this.RecvNobilityTitleIcon.Length)
				{
					this.RecvNobilityTitleIcon[num2] = 0;
					this.RecvNobilityTitleName[num2].Length = 0;
					this.RecvNobilityTitleNameNoTag[num2].Length = 0;
				}
			}
			ushort num3 = MP.ReadUShort(-1);
			if (num3 != 0)
			{
				int num4 = (int)(num3 - 1);
				if (num4 < this.RecvNobilityTitleIcon.Length)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					this.RecvNobilityTitleNameNoTag[num4].Length = 0;
					this.RecvNobilityTitleIcon[num4] = MP.ReadUShort(-1);
					this.RecvNobilityKingdomID[num4] = MP.ReadUShort(-1);
					MP.ReadStringPlus(13, this.RecvNobilityTitleNameNoTag[num4], -1);
					MP.ReadStringPlus(3, cstring, -1);
					this.RecvNobilityTitleName[num4].Length = 0;
					if (this.RecvNobilityTitleIcon[num4] != 0)
					{
						ushort kingdomID = DataManager.MapDataController.kingdomData.kingdomID;
						GameConstants.FormatRoleName(this.RecvNobilityTitleName[num4], this.RecvNobilityTitleNameNoTag[num4], cstring, null, 0, (kingdomID == this.RecvNobilityKingdomID[num4]) ? 0 : this.RecvNobilityKingdomID[num4], null, null, null, null);
					}
					if (DataManager.CompareStr(this.RecvNobilityTitleNameNoTag[num4], DataManager.Instance.mLordProfile.PlayerName) == 0)
					{
						DataManager.Instance.mLordProfile.NobilityTitle = num3;
					}
				}
			}
			guimanager.UpdateUI(EGUIWindow.UI_Title, 3, 0);
		}
	}

	// Token: 0x060028F3 RID: 10483 RVA: 0x0044B660 File Offset: 0x00449860
	public void Send_NobilityTitle_Remove(ushort TitleID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_NOBILITY_TITLE_REMOVE;
		messagePacket.AddSeqId();
		messagePacket.Add(TitleID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Title);
	}

	// Token: 0x060028F4 RID: 10484 RVA: 0x0044B6A8 File Offset: 0x004498A8
	public void Recv_NobilityTitle_Remove(MessagePacket MP)
	{
		GUIManager guimanager = GUIManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != 0)
			{
				int num2 = (int)(num - 1);
				if (num2 < this.RecvNobilityTitleIcon.Length)
				{
					this.RecvNobilityTitleIcon[num2] = 0;
					this.RecvNobilityKingdomID[num2] = 0;
					this.RecvNobilityTitleName[num2].Length = 0;
					this.RecvNobilityTitleNameNoTag[num2].Length = 0;
				}
				guimanager.UpdateUI(EGUIWindow.UI_Title, 0, 0);
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(7010u));
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(5348u));
				guimanager.AddHUDMessage(cstring.ToString(), 255, true);
			}
		}
		else
		{
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.Append(DataManager.Instance.mStringTable.GetStringByID(7010u));
			cstring2.Append(DataManager.Instance.mStringTable.GetStringByID(5349u));
			guimanager.AddHUDMessage(cstring2.ToString(), 255, true);
			this.NobilityTitle_Error(b);
		}
		guimanager.HideUILock(EUILock.Title);
	}

	// Token: 0x060028F5 RID: 10485 RVA: 0x0044B7E0 File Offset: 0x004499E0
	public void Recv_NobilityTitle_RemoveByOthers(MessagePacket MP)
	{
		if (this.RecvNobilityTitleName == null)
		{
			return;
		}
		GUIManager guimanager = GUIManager.Instance;
		if (MP.ReadByte(-1) == 0)
		{
			ushort num = MP.ReadUShort(-1);
			if (num != 0)
			{
				int num2 = (int)(num - 1);
				if (num2 < this.RecvNobilityTitleIcon.Length)
				{
					this.RecvNobilityTitleIcon[num2] = 0;
					this.RecvNobilityKingdomID[num2] = 0;
					this.RecvNobilityTitleName[num2].Length = 0;
					this.RecvNobilityTitleNameNoTag[num2].Length = 0;
				}
				guimanager.UpdateUI(EGUIWindow.UI_Title, 3, 0);
			}
		}
	}

	// Token: 0x060028F6 RID: 10486 RVA: 0x0044B868 File Offset: 0x00449A68
	public void Send_NobilityTitle_List_King(ushort WonderID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_NOBILITY_TITLE_LIST_BY_GROUP;
		messagePacket.AddSeqId();
		messagePacket.Add(WonderID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Title);
	}

	// Token: 0x060028F7 RID: 10487 RVA: 0x0044B8B0 File Offset: 0x00449AB0
	public void Send_NobilityTitle_List()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_NOBILITY_TITLE_LIST;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Title);
	}

	// Token: 0x060028F8 RID: 10488 RVA: 0x0044B8F0 File Offset: 0x00449AF0
	public void Recv_NobilityTitle_List(MessagePacket MP)
	{
		GUIManager guimanager = GUIManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			byte b2 = MP.ReadByte(-1);
			this.InitialNobilityTitleName(b2);
			for (int i = 0; i < (int)b2; i++)
			{
				if (i >= this.RecvNobilityTitleName.Length)
				{
					break;
				}
				CString cstring = StringManager.Instance.StaticString1024();
				this.RecvNobilityTitleNameNoTag[i].Length = 0;
				this.RecvNobilityTitleIcon[i] = MP.ReadUShort(-1);
				this.RecvNobilityKingdomID[i] = MP.ReadUShort(-1);
				MP.ReadStringPlus(13, this.RecvNobilityTitleNameNoTag[i], -1);
				MP.ReadStringPlus(3, cstring, -1);
				this.RecvNobilityTitleName[i].Length = 0;
				if (this.RecvNobilityTitleIcon[i] != 0)
				{
					ushort kingdomID = DataManager.MapDataController.kingdomData.kingdomID;
					GameConstants.FormatRoleName(this.RecvNobilityTitleName[i], this.RecvNobilityTitleNameNoTag[i], cstring, null, 0, (kingdomID == this.RecvNobilityKingdomID[i]) ? 0 : this.RecvNobilityKingdomID[i], null, null, null, null);
				}
			}
			Door door = guimanager.FindMenu(EGUIWindow.Door) as Door;
			if (door && !door.OpenMenu(EGUIWindow.UI_Title, (int)this.WaitTitleList, 0, false))
			{
				guimanager.UpdateUI(EGUIWindow.UI_Title, 0, 0);
			}
			this.WaitTitleList = 0;
		}
		else
		{
			this.NobilityTitle_Error(b);
		}
		guimanager.HideUILock(EUILock.Title);
	}

	// Token: 0x060028F9 RID: 10489 RVA: 0x0044BA5C File Offset: 0x00449C5C
	public void Recv_NobilityTitle_Get(MessagePacket MP)
	{
		DataManager dataManager = DataManager.Instance;
		dataManager.RoleAttr.NobilityTitle = MP.ReadUShort(-1);
		if (dataManager.RoleAttr.NobilityTitle > 1)
		{
			TitleData recordByKey = dataManager.TitleDataF.GetRecordByKey(dataManager.RoleAttr.NobilityTitle);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(dataManager.mStringTable.GetStringByID((uint)recordByKey.StringID));
			cstring.AppendFormat(dataManager.mStringTable.GetStringByID(9368u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
		}
		if (DataManager.MapDataController.IsNobilityChief())
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Title, 4, 0);
		}
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Wonder);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 1, 0);
	}

	// Token: 0x060028FA RID: 10490 RVA: 0x0044BB34 File Offset: 0x00449D34
	public void OpenNobilityTitleList(ushort WonderID)
	{
		this.WaitTitleList = 7;
		this.OpenWonderID = WonderID;
		this.Send_NobilityTitle_List_King(WonderID);
	}

	// Token: 0x060028FB RID: 10491 RVA: 0x0044BB4C File Offset: 0x00449D4C
	public void OpenNobilityTitleSet(CString OpenName)
	{
		this.WaitTitleList = 8;
		this.OpenNobilityTitleName.Length = 0;
		this.OpenNobilityTitleName.Append(OpenName);
		if (ActivityManager.Instance.CheckCanonizationNoility(DataManager.MapDataController.OtherKingdomData.kingdomID))
		{
			this.Send_NobilityTitle_List();
		}
		else
		{
			this.Send_NobilityTitle_List_King((ushort)ActivityManager.Instance.FederalActKingdomWonderID);
		}
	}

	// Token: 0x0400731B RID: 29467
	private static TitleManager instance;

	// Token: 0x0400731C RID: 29468
	public byte WaitTitleList;

	// Token: 0x0400731D RID: 29469
	public int[] NowTitleIndex = new int[]
	{
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1
	};

	// Token: 0x0400731E RID: 29470
	public float[] NowTitlePos = new float[]
	{
		-1f,
		-1f,
		-1f,
		-1f,
		-1f,
		-1f,
		-1f,
		-1f
	};

	// Token: 0x0400731F RID: 29471
	public CString OpenTitleName = new CString(14);

	// Token: 0x04007320 RID: 29472
	public CString[] RecvTitleNameNoTag;

	// Token: 0x04007321 RID: 29473
	public CString[] RecvTitleName;

	// Token: 0x04007322 RID: 29474
	public ushort[] RecvTitleIcon;

	// Token: 0x04007323 RID: 29475
	public CString OpenTitleNameW = new CString(14);

	// Token: 0x04007324 RID: 29476
	public CString[] RecvTitleNameNoTagW;

	// Token: 0x04007325 RID: 29477
	public CString[] RecvTitleNameW;

	// Token: 0x04007326 RID: 29478
	public ushort[] RecvTitleIconW;

	// Token: 0x04007327 RID: 29479
	public ushort[] RecvTitleKingdomW;

	// Token: 0x04007328 RID: 29480
	public ushort OpenKingdomID;

	// Token: 0x04007329 RID: 29481
	public ushort[] RecvTitleKingdomID;

	// Token: 0x0400732A RID: 29482
	public CString[] RecvTitleNameN;

	// Token: 0x0400732B RID: 29483
	public CString WKNameNoTag = new CString(14);

	// Token: 0x0400732C RID: 29484
	public CString WKName = new CString(25);

	// Token: 0x0400732D RID: 29485
	public ushort WKIcon;

	// Token: 0x0400732E RID: 29486
	public ushort WKKingdom;

	// Token: 0x0400732F RID: 29487
	public ushort NTitleCount;

	// Token: 0x04007330 RID: 29488
	public ushort OpenWonderID;

	// Token: 0x04007331 RID: 29489
	public CString OpenNobilityTitleName = new CString(14);

	// Token: 0x04007332 RID: 29490
	public CString[] RecvNobilityTitleNameNoTag;

	// Token: 0x04007333 RID: 29491
	public CString[] RecvNobilityTitleName;

	// Token: 0x04007334 RID: 29492
	public ushort[] RecvNobilityKingdomID;

	// Token: 0x04007335 RID: 29493
	public ushort[] RecvNobilityTitleIcon;
}
