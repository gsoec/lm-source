using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003C0 RID: 960
public class LordEquipData
{
	// Token: 0x060013A7 RID: 5031 RVA: 0x0022E9D8 File Offset: 0x0022CBD8
	protected LordEquipData()
	{
		for (int i = 0; i < 200; i++)
		{
			this.LordEquip[i].Init();
		}
		this.EquipDic = new Dictionary<uint, int>();
	}

	// Token: 0x060013A9 RID: 5033 RVA: 0x0022EAF8 File Offset: 0x0022CCF8
	public bool isRoleEquipThis(uint Serial)
	{
		if (Serial == 0u)
		{
			return false;
		}
		for (int i = 0; i < LordEquipData.RoleEquipSerial.Length; i++)
		{
			if (LordEquipData.RoleEquipSerial[i] == Serial)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060013AA RID: 5034 RVA: 0x0022EB38 File Offset: 0x0022CD38
	public static LordEquipData Instance()
	{
		if (LordEquipData._instance == null)
		{
			LordEquipData._instance = new LordEquipData();
		}
		return LordEquipData._instance;
	}

	// Token: 0x060013AB RID: 5035 RVA: 0x0022EB54 File Offset: 0x0022CD54
	public bool LoadLordEquip(bool noLock = false)
	{
		if (!LordEquipData.EqDataReq)
		{
			if (noLock || GUIManager.Instance.ShowUILock(EUILock.LordEquip))
			{
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_LOADEQUIP;
				messagePacket.AddSeqId();
				messagePacket.Add(this.LastUpdateTime_Equip);
				messagePacket.Send(false);
			}
			return true;
		}
		return false;
	}

	// Token: 0x060013AC RID: 5036 RVA: 0x0022EBB8 File Offset: 0x0022CDB8
	public bool LoadLEGem(bool noLock = false)
	{
		if (!LordEquipData.GemDataReq)
		{
			if (noLock || GUIManager.Instance.ShowUILock(EUILock.LordEquip))
			{
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_ITEMGEM;
				messagePacket.AddSeqId();
				messagePacket.Add(this.LastUpdateTime_Gem);
				messagePacket.Send(false);
			}
			return true;
		}
		return false;
	}

	// Token: 0x060013AD RID: 5037 RVA: 0x0022EC1C File Offset: 0x0022CE1C
	public bool LoadLEMaterial(bool noLock = false)
	{
		if (!LordEquipData.MaterialDataReq)
		{
			if (noLock || GUIManager.Instance.ShowUILock(EUILock.LordEquip))
			{
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_ITEMMAT;
				messagePacket.AddSeqId();
				messagePacket.Add(this.LastUpdateTime_Material);
				messagePacket.Send(false);
			}
			return true;
		}
		return false;
	}

	// Token: 0x060013AE RID: 5038 RVA: 0x0022EC80 File Offset: 0x0022CE80
	public void Recv_MSG_RESP_LORDEQUIP(MessagePacket MP)
	{
		if (DataManager.Instance.mLordEquip == null)
		{
			DataManager.Instance.mLordEquip = LordEquipData.Instance();
		}
		switch (MP.ReadByte(-1))
		{
		case 0:
		{
			LordEquipData.EqDataReq = true;
			LordEquipData.SetItemTime(MP.ReadLong(-1));
			ushort num = MP.ReadUShort(-1);
			ushort num2 = MP.ReadUShort(-1);
			if (num == 0)
			{
				for (int i = 0; i < 200; i++)
				{
					this.LordEquip[i].Clear();
				}
			}
			for (int j = 0; j < (int)num2; j++)
			{
				this.LordEquip[(int)num + j].ItemID = MP.ReadUShort(-1);
				this.LordEquip[(int)num + j].Color = Math.Min(6, MP.ReadByte(-1));
				for (int k = 0; k < 4; k++)
				{
					this.LordEquip[(int)num + j].GemColor[k] = Math.Min(5, MP.ReadByte(-1));
				}
				for (int l = 0; l < 4; l++)
				{
					this.LordEquip[(int)num + j].Gem[l] = MP.ReadUShort(-1);
				}
				this.LordEquip[(int)num + j].SerialNO = MP.ReadUInt(-1);
			}
			return;
		}
		case 1:
			LordEquipData.EqDataReq = true;
			this.EvoCountingReq = true;
			this.QuickSetSerialCheck = false;
			this.ScanEquipUpdate();
			GUIManager.Instance.HideUILock(EUILock.LordEquip);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1, 0);
			return;
		case 2:
			this.EvoCountingReq = true;
			this.QuickSetSerialCheck = false;
			this.ScanEquipUpdate();
			GUIManager.Instance.HideUILock(EUILock.LordEquip);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge_Item, 1, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge_ActivityItem, 1, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquipSetEdit, 1, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1, 0);
			return;
		default:
			return;
		}
	}

	// Token: 0x060013AF RID: 5039 RVA: 0x0022EECC File Offset: 0x0022D0CC
	public void Recv_MSG_RESP_Gem(MessagePacket MP)
	{
		if (DataManager.Instance.mLordEquip == null)
		{
			DataManager.Instance.mLordEquip = LordEquipData.Instance();
		}
		switch (MP.ReadByte(-1))
		{
		case 0:
		{
			LordEquipData.GemDataReq = true;
			LordEquipData.SetGemTime(MP.ReadLong(-1));
			ushort num = MP.ReadUShort(-1);
			ushort num2 = MP.ReadUShort(-1);
			if ((int)(num2 + num) > this.LEGem.Length)
			{
				return;
			}
			if (num == 0)
			{
				for (int i = 0; i < this.LEGem.Length; i++)
				{
					this.LEGem[i].Clear();
				}
			}
			for (int j = 0; j < (int)num2; j++)
			{
				this.LEGem[(int)num + j].ItemID = MP.ReadUShort(-1);
				this.LEGem[(int)num + j].Color = Math.Min(5, MP.ReadByte(-1));
				this.LEGem[(int)num + j].Quantity = MP.ReadUShort(-1);
			}
			return;
		}
		case 1:
			LordEquipData.GemDataReq = true;
			GUIManager.Instance.HideUILock(EUILock.LordEquip);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 2, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1, 0);
			return;
		case 2:
			GUIManager.Instance.HideUILock(EUILock.LordEquip);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 2, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1, 0);
			return;
		default:
			return;
		}
	}

	// Token: 0x060013B0 RID: 5040 RVA: 0x0022F050 File Offset: 0x0022D250
	public void Recv_MSG_RESP_ITEMMAT(MessagePacket MP)
	{
		if (DataManager.Instance.mLordEquip == null)
		{
			DataManager.Instance.mLordEquip = LordEquipData.Instance();
		}
		switch (MP.ReadByte(-1))
		{
		case 0:
		{
			LordEquipData.MaterialDataReq = true;
			LordEquipData.SetMatTime(MP.ReadLong(-1));
			ushort num = MP.ReadUShort(-1);
			ushort num2 = MP.ReadUShort(-1);
			if ((int)(num2 + num) > this.LEMaterial.Length)
			{
				return;
			}
			if (num == 0)
			{
				for (int i = 0; i < this.LEMaterial.Length; i++)
				{
					this.LEMaterial[i].Clear();
				}
				if (!this.MatCountingCache)
				{
					this.StartMaterialCache();
				}
				this.MatValue.Clear();
			}
			for (int j = 0; j < (int)num2; j++)
			{
				this.LEMaterial[(int)num + j].ItemID = MP.ReadUShort(-1);
				this.LEMaterial[(int)num + j].Color = Math.Min(5, MP.ReadByte(-1));
				this.LEMaterial[(int)num + j].Quantity = MP.ReadUShort(-1);
				double num3 = (double)this.LEMaterial[(int)num + j].Quantity * Math.Pow(4.0, (double)(this.LEMaterial[(int)num + j].Color - 1));
				int num4;
				if (this.MatValue.TryGetValue(this.LEMaterial[(int)num + j].ItemID, out num4))
				{
					num4 += (int)num3;
					this.MatValue.Remove(this.LEMaterial[(int)num + j].ItemID);
					this.MatValue.Add(this.LEMaterial[(int)num + j].ItemID, num4);
				}
				else
				{
					this.MatValue.Add(this.LEMaterial[(int)num + j].ItemID, (int)num3);
				}
			}
			return;
		}
		case 1:
			LordEquipData.MaterialDataReq = true;
			this.EvoCountingReq = true;
			this.ScanEquipUpdate();
			GUIManager.Instance.HideUILock(EUILock.LordEquip);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 3, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetFusion, 3, 0);
			return;
		case 2:
			this.EvoCountingReq = true;
			this.ScanEquipUpdate();
			GUIManager.Instance.HideUILock(EUILock.LordEquip);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 3, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge_Item, 2, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge_ActivityItem, 2, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetFusion, 3, 0);
			return;
		default:
			return;
		}
	}

	// Token: 0x060013B1 RID: 5041 RVA: 0x0022F31C File Offset: 0x0022D51C
	public void Recv_MSG_RESP_LORDEQUIP_EX(MessagePacket MP)
	{
		LordEquipData.SetItemTime(MP.ReadLong(-1));
		ushort num = MP.ReadUShort(-1);
		for (int i = 0; i < (int)num; i++)
		{
			uint serial = MP.ReadUInt(-1);
			long time = MP.ReadLong(-1);
			LordEquipData.updateEquipTime(serial, time);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquipSetEdit, 3, 0);
	}

	// Token: 0x060013B2 RID: 5042 RVA: 0x0022F394 File Offset: 0x0022D594
	public static void AddItem(MessagePacket MP)
	{
		if (!LordEquipData.EqDataReq)
		{
			return;
		}
		ushort num = MP.ReadUShort(-1);
		if (num == 0)
		{
			return;
		}
		ItemLordEquip itemLordEquip = default(ItemLordEquip);
		itemLordEquip.Init();
		itemLordEquip.ItemID = num;
		itemLordEquip.Color = MP.ReadByte(-1);
		for (int i = 0; i < 4; i++)
		{
			itemLordEquip.GemColor[i] = MP.ReadByte(-1);
		}
		for (int j = 0; j < 4; j++)
		{
			itemLordEquip.Gem[j] = MP.ReadUShort(-1);
		}
		itemLordEquip.SerialNO = MP.ReadUInt(-1);
		for (int k = 0; k < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; k++)
		{
			if (LordEquipData._instance.LordEquip[k].ItemID == 0)
			{
				LordEquipData._instance.LordEquip[k] = itemLordEquip.Clone();
				return;
			}
		}
	}

	// Token: 0x060013B3 RID: 5043 RVA: 0x0022F490 File Offset: 0x0022D690
	public static void DeleteItem(MessagePacket MP)
	{
		if (!LordEquipData.EqDataReq)
		{
			return;
		}
		uint num = MP.ReadUInt(-1);
		if (num == 0u)
		{
			return;
		}
		for (int i = 0; i < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; i++)
		{
			if (LordEquipData._instance.LordEquip[i].SerialNO == num)
			{
				LordEquipData._instance.LordEquip[i].Clear();
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1, 1);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquipSetEdit, 3, 0);
				LordEquipData._instance.ScanEquipUpdate();
				return;
			}
		}
	}

	// Token: 0x060013B4 RID: 5044 RVA: 0x0022F53C File Offset: 0x0022D73C
	public static void Recv_MSG_RESP_ONLORDEQUIP_INFO(MessagePacket MP)
	{
		for (int i = 0; i < 8; i++)
		{
			LordEquipData.RoleEquip[i].Init();
			LordEquipData.RoleEquip[i].ItemID = MP.ReadUShort(-1);
			LordEquipData.RoleEquip[i].Color = Math.Min(6, MP.ReadByte(-1));
			for (int j = 0; j < 4; j++)
			{
				LordEquipData.RoleEquip[i].GemColor[j] = Math.Min(5, MP.ReadByte(-1));
			}
			for (int k = 0; k < 4; k++)
			{
				LordEquipData.RoleEquip[i].Gem[k] = MP.ReadUShort(-1);
			}
			LordEquipData.RoleEquipSerial[i] = MP.ReadUInt(-1);
		}
		DataManager.Instance.AttribVal.UpdateLordEquipData();
	}

	// Token: 0x060013B5 RID: 5045 RVA: 0x0022F618 File Offset: 0x0022D818
	public void ChangeEquip(byte equipPos, uint serial)
	{
		if (GUIManager.Instance.ShowUILock(EUILock.LordEquip))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_PUTON_TAKEOFF_LORDEQUIP;
			messagePacket.AddSeqId();
			messagePacket.Add(equipPos);
			messagePacket.Add(serial);
			messagePacket.Send(false);
		}
	}

	// Token: 0x060013B6 RID: 5046 RVA: 0x0022F668 File Offset: 0x0022D868
	public void Recv_MSG_RESP_PUTON_TAKEOFF_LORDEQUIP(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = b;
		if (b2 != 0)
		{
			return;
		}
		byte b3 = MP.ReadByte(-1);
		uint num = MP.ReadUInt(-1);
		LordEquipData.RoleEquipSerial[(int)b3] = num;
		LordEquipData.RoleEquip[(int)b3].Clear();
		if (num != 0u)
		{
			for (int i = 0; i < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; i++)
			{
				if (this.LordEquip[i].SerialNO == num)
				{
					LordEquipData.RoleEquip[(int)b3] = this.LordEquip[i].CloneSerial();
				}
			}
		}
		DataManager.Instance.AttribVal.UpdateLordEquipData();
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_LordEquip) != null)
		{
			Door door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
			door.CloseMenu(false);
		}
		GUIManager.Instance.HideUILock(EUILock.LordEquip);
		AudioManager.Instance.PlayUISFX(UIKind.EquipTake);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
	}

	// Token: 0x060013B7 RID: 5047 RVA: 0x0022F784 File Offset: 0x0022D984
	public static void ResetData()
	{
		LordEquipData.EqDataReq = false;
		LordEquipData.GemDataReq = false;
		LordEquipData.MaterialDataReq = false;
		GUIWindow x = GUIManager.Instance.FindMenu(EGUIWindow.UI_Anvil);
		if (x == null)
		{
			DataManager.Instance.RemoveDoorUIStack(EGUIWindow.UI_Anvil);
		}
		LordEquipData.Instance().LoadLordEquip(true);
		LordEquipData.Instance().LoadLEMaterial(true);
		LordEquipData.Instance().LoadLEGem(true);
		LordEquipData.Instance().LordEquipSetsCount = 0;
	}

	// Token: 0x060013B8 RID: 5048 RVA: 0x0022F7F8 File Offset: 0x0022D9F8
	public void upgradeMaterial(ushort itemID, byte targetColor, ushort Quantity)
	{
		byte data = (DataManager.Instance.EquipTable.GetRecordByKey(itemID).EquipKind != 20) ? 1 : 0;
		if (GUIManager.Instance.ShowUILock(EUILock.LordEquip))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_SYN_MATGEM;
			messagePacket.AddSeqId();
			messagePacket.Add(data);
			messagePacket.Add(itemID);
			messagePacket.Add(targetColor);
			messagePacket.Add(Quantity);
			messagePacket.Send(false);
		}
	}

	// Token: 0x060013B9 RID: 5049 RVA: 0x0022F880 File Offset: 0x0022DA80
	public void Recv_MSG_LORD_RESPSYN_MATGEM(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = b;
		if (b2 != 0)
		{
			return;
		}
		byte b3 = MP.ReadByte(-1);
		ushort itemID = MP.ReadUShort(-1);
		byte color = Math.Min(5, MP.ReadByte(-1));
		ushort quantity = MP.ReadUShort(-1);
		LordEquipData.setItemQuantity(itemID, color, quantity, 0L);
		itemID = MP.ReadUShort(-1);
		color = Math.Min(5, MP.ReadByte(-1));
		quantity = MP.ReadUShort(-1);
		LordEquipData.setItemQuantity(itemID, color, quantity, 0L);
		long num = MP.ReadLong(-1);
		if (b3 == 0)
		{
			LordEquipData.SetMatTime(num);
		}
		else
		{
			LordEquipData.SetGemTime(num);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 1, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, (b3 != 0) ? 2 : 3, 1);
		GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1, 0);
		AudioManager.Instance.PlayUISFX(UIKind.EquipFoundry);
		GUIManager.Instance.HideUILock(EUILock.LordEquip);
	}

	// Token: 0x060013BA RID: 5050 RVA: 0x0022F980 File Offset: 0x0022DB80
	public void CombineEquip(ushort itemID, uint Serial)
	{
		if (GUIManager.Instance.ShowUILock(EUILock.LordEquip))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_SYN_LORDEQUIP;
			messagePacket.AddSeqId();
			messagePacket.Add(itemID);
			messagePacket.Add(Serial);
			messagePacket.Send(false);
		}
	}

	// Token: 0x060013BB RID: 5051 RVA: 0x0022F9D0 File Offset: 0x0022DBD0
	public void Recv_MSG_RESP_SYN_LORDEQUIP(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = b;
		if (b2 != 0)
		{
			return;
		}
		DataManager.Instance.RoleAttr.LordEquipEventData.Init();
		DataManager.Instance.RoleAttr.LordEquipEventData.ItemID = MP.ReadUShort(-1);
		DataManager.Instance.RoleAttr.LordEquipEventData.Color = Math.Min(6, MP.ReadByte(-1));
		for (int i = 0; i < 4; i++)
		{
			DataManager.Instance.RoleAttr.LordEquipEventData.GemColor[i] = Math.Min(5, MP.ReadByte(-1));
		}
		for (int j = 0; j < 4; j++)
		{
			DataManager.Instance.RoleAttr.LordEquipEventData.Gem[j] = MP.ReadUShort(-1);
		}
		DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO = MP.ReadUInt(-1);
		DataManager.Instance.RoleAttr.LordEquipEventTime.BeginTime = MP.ReadLong(-1);
		DataManager.Instance.RoleAttr.LordEquipEventTime.RequireTime = MP.ReadUInt(-1);
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Forging, true, DataManager.Instance.RoleAttr.LordEquipEventTime.BeginTime, DataManager.Instance.RoleAttr.LordEquipEventTime.RequireTime);
		for (int k = 0; k < 4; k++)
		{
			ushort itemID = MP.ReadUShort(-1);
			byte color = Math.Min(6, MP.ReadByte(-1));
			ushort quantity = MP.ReadUShort(-1);
			LordEquipData.setItemQuantity(itemID, color, quantity, 0L);
		}
		uint stock = MP.ReadUInt(-1);
		DataManager.Instance.Resource[4].Stock = stock;
		LordEquipData.SetMatTime(MP.ReadLong(-1));
		for (int l = 0; l < 8; l++)
		{
			if (LordEquipData.RoleEquipSerial[l] == DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO)
			{
				LordEquipData.RoleEquipSerial[l] = 0u;
				LordEquipData.RoleEquip[l].Clear();
				DataManager.Instance.AttribVal.UpdateLordEquipData();
				break;
			}
		}
		this.ScanEquipUpdate();
		GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
		UIAnvil.OpenKind = eUI_Anvil_OpenKind.NowForging;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 2, 0);
		AudioManager.Instance.PlayUISFX(UIKind.EquipFoundry);
		GUIManager.Instance.HideUILock(EUILock.LordEquip);
		FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_EQUIPMENT_FORGED);
	}

	// Token: 0x060013BC RID: 5052 RVA: 0x0022FC50 File Offset: 0x0022DE50
	public static void CancelCombine()
	{
		if (GUIManager.Instance.ShowUILock(EUILock.LordEquip))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_SYN_LORDEQUIP_EVENT_CANCEL;
			messagePacket.AddSeqId();
			messagePacket.Add(DataManager.Instance.RoleAttr.LordEquipEventData.ItemID);
			messagePacket.Add(DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO);
			messagePacket.Send(false);
		}
	}

	// Token: 0x060013BD RID: 5053 RVA: 0x0022FCC8 File Offset: 0x0022DEC8
	public void Recv_MSG_RESP_SYN_LORDEQUIP_EVENT_CANCEL(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = b;
		if (b2 != 0)
		{
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			ushort itemID = MP.ReadUShort(-1);
			byte color = Math.Min(6, MP.ReadByte(-1));
			ushort quantity = MP.ReadUShort(-1);
			LordEquipData.setItemQuantity(itemID, color, quantity, 0L);
		}
		DataManager.Instance.Resource[4].Stock = MP.ReadUInt(-1);
		LordEquipData.SetMatTime(MP.ReadLong(-1));
		int equipIndex = this.GetEquipIndex(DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO);
		if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.NowForging && equipIndex < 0)
		{
			UIAnvil.preSetID = DataManager.Instance.RoleAttr.LordEquipEventData.ItemID;
		}
		LordEquipData.CleanForgeQuere();
		this.ScanEquipUpdate();
		GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 3, equipIndex);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge, 1, 0);
		GUIManager.Instance.HideUILock(EUILock.LordEquip);
	}

	// Token: 0x060013BE RID: 5054 RVA: 0x0022FDDC File Offset: 0x0022DFDC
	public void Recv_MSG_RESP_SYN_LORDEQUIP_EVENT_COMPLETE(MessagePacket MP)
	{
		ItemLordEquip equip = default(ItemLordEquip);
		equip.Init();
		equip.ItemID = MP.ReadUShort(-1);
		equip.Color = Math.Min(6, MP.ReadByte(-1));
		for (int i = 0; i < 4; i++)
		{
			equip.GemColor[i] = Math.Min(5, MP.ReadByte(-1));
		}
		for (int j = 0; j < 4; j++)
		{
			equip.Gem[j] = MP.ReadUShort(-1);
		}
		equip.SerialNO = MP.ReadUInt(-1);
		LordEquipData.ShowItemFinish(equip);
		int num = -1;
		long lastUpdateTime_Equip = MP.ReadLong(-1);
		if (LordEquipData.EqDataReq)
		{
			num = LordEquipData.updateEquip(equip);
			this.LastUpdateTime_Equip = lastUpdateTime_Equip;
		}
		LordEquipData.CleanForgeQuere();
		this.ScanEquipUpdate();
		GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Anvil) != null)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 3, num);
		}
		else if (num >= 0)
		{
			UIAnvil.preSetIndex = (ushort)num;
			UIAnvil.OpenKind = eUI_Anvil_OpenKind.UpgradeItem;
		}
		else
		{
			DataManager.Instance.RemoveDoorUIStack(EGUIWindow.UI_Anvil);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge, 1, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquipSetEdit, 1, 0);
		GUIManager.Instance.HideUILock(EUILock.LordEquip);
	}

	// Token: 0x060013BF RID: 5055 RVA: 0x0022FF44 File Offset: 0x0022E144
	public void QuickCombine(ushort itemID, uint Serial)
	{
		if (GUIManager.Instance.ShowUILock(EUILock.LordEquip))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_SYN_LORDEQUIP_INSTANT;
			messagePacket.AddSeqId();
			messagePacket.Add(itemID);
			messagePacket.Add(Serial);
			messagePacket.Send(false);
		}
	}

	// Token: 0x060013C0 RID: 5056 RVA: 0x0022FF94 File Offset: 0x0022E194
	public static void Recv_MSG_RESP_SYN_LORDEQUIP_INSTANT(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = b;
		if (b2 != 0)
		{
			return;
		}
		ItemLordEquip equip = default(ItemLordEquip);
		equip.Init();
		equip.ItemID = MP.ReadUShort(-1);
		equip.Color = Math.Min(6, MP.ReadByte(-1));
		for (int i = 0; i < 4; i++)
		{
			equip.GemColor[i] = Math.Min(5, MP.ReadByte(-1));
		}
		for (int j = 0; j < 4; j++)
		{
			equip.Gem[j] = MP.ReadUShort(-1);
		}
		equip.SerialNO = MP.ReadUInt(-1);
		LordEquipData.ShowItemFinish(equip);
		for (int k = 0; k < 4; k++)
		{
			ushort itemID = MP.ReadUShort(-1);
			byte color = Math.Min(6, MP.ReadByte(-1));
			ushort quantity = MP.ReadUShort(-1);
			LordEquipData.setItemQuantity(itemID, color, quantity, 0L);
		}
		DataManager.Instance.Resource[4].Stock = MP.ReadUInt(-1);
		GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eInstantCraftLordEquip);
		long lastUpdateTime_Equip = MP.ReadLong(-1);
		int arg = 0;
		if (LordEquipData.EqDataReq)
		{
			arg = LordEquipData.updateEquip(equip);
			LordEquipData._instance.LastUpdateTime_Equip = lastUpdateTime_Equip;
		}
		LordEquipData.SetMatTime(MP.ReadLong(-1));
		for (int l = 0; l < 8; l++)
		{
			if (LordEquipData.RoleEquipSerial[l] == equip.SerialNO)
			{
				LordEquipData.RoleEquipSerial[l] = 0u;
				LordEquipData.RoleEquip[l].Clear();
				DataManager.Instance.AttribVal.UpdateLordEquipData();
				break;
			}
		}
		LordEquipData.CleanForgeQuere();
		LordEquipData.Instance().ScanEquipUpdate();
		GameManager.OnRefresh(NetworkNews.Refresh, null);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 5, arg);
		AudioManager.Instance.PlayUISFX(UIKind.EquipFoundry);
		GUIManager.Instance.HideUILock(EUILock.LordEquip);
		FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_EQUIPMENT_FORGED);
	}

	// Token: 0x060013C1 RID: 5057 RVA: 0x0023019C File Offset: 0x0022E39C
	public static void QuickCombineinForge()
	{
		if (GUIManager.Instance.ShowUILock(EUILock.LordEquip))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_FINISH_SYN_LORDEQUIP_EVENT;
			messagePacket.AddSeqId();
			messagePacket.Add(DataManager.Instance.RoleAttr.LordEquipEventData.ItemID);
			messagePacket.Add(DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO);
			messagePacket.Send(false);
		}
	}

	// Token: 0x060013C2 RID: 5058 RVA: 0x00230214 File Offset: 0x0022E414
	public static void Recv_MSG_RESP_FINISH_SYN_LORDEQUIP_EVENT(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = b;
		if (b2 != 0)
		{
			return;
		}
		ItemLordEquip equip = default(ItemLordEquip);
		equip.Init();
		equip.ItemID = MP.ReadUShort(-1);
		equip.Color = Math.Min(6, MP.ReadByte(-1));
		for (int i = 0; i < 4; i++)
		{
			equip.GemColor[i] = Math.Min(5, MP.ReadByte(-1));
		}
		for (int j = 0; j < 4; j++)
		{
			equip.Gem[j] = MP.ReadUShort(-1);
		}
		equip.SerialNO = MP.ReadUInt(-1);
		LordEquipData.ShowItemFinish(equip);
		GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eCraftLordEquipInstantFinish);
		long lastUpdateTime_Equip = MP.ReadLong(-1);
		int arg = -1;
		if (LordEquipData.EqDataReq)
		{
			arg = LordEquipData.updateEquip(equip);
			LordEquipData._instance.LastUpdateTime_Equip = lastUpdateTime_Equip;
		}
		LordEquipData.CleanForgeQuere();
		LordEquipData.Instance().ScanEquipUpdate();
		GameManager.OnRefresh(NetworkNews.Refresh, null);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 3, arg);
		AudioManager.Instance.PlayUISFX(UIKind.EquipFoundry);
		GUIManager.Instance.HideUILock(EUILock.LordEquip);
	}

	// Token: 0x060013C3 RID: 5059 RVA: 0x00230350 File Offset: 0x0022E550
	public void DeleteEquip(uint Serial)
	{
		if (GUIManager.Instance.ShowUILock(EUILock.LordEquip))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_DECOMPOSE_LORDEQUIP;
			messagePacket.AddSeqId();
			messagePacket.Add(Serial);
			messagePacket.Send(false);
		}
	}

	// Token: 0x060013C4 RID: 5060 RVA: 0x0023039C File Offset: 0x0022E59C
	public void Recv_MSG_RESP_DECOMPOSE_LORDEQUIP(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = b;
		if (b2 != 0)
		{
			return;
		}
		byte b3 = MP.ReadByte(-1);
		ushort num = MP.ReadUShort(-1);
		byte color = Math.Min(6, MP.ReadByte(-1));
		ushort quantity = MP.ReadUShort(-1);
		LordEquipData.setItemQuantity(num, color, quantity, 0L);
		uint serial = MP.ReadUInt(-1);
		LordEquipData.SetItemTime(MP.ReadLong(-1));
		LordEquipData.SetMatTime(MP.ReadLong(-1));
		int equipIndex = this.GetEquipIndex(serial);
		CString msgStr = GUIManager.Instance.MsgStr;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(num);
		GameConstants.GetColoredLordEquipString(cstring, ref recordByKey, color);
		if (this.LordEquip[equipIndex].Color == 6)
		{
			recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.LordEquip[equipIndex].ItemID);
			LordEquipExtendData recordByKey2 = DataManager.Instance.LordEquipExtendTable.GetRecordByKey(recordByKey.NewGemEffect[0]);
			if (recordByKey.NewGemEffect[0] == recordByKey2.ID)
			{
				recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey2.SyntheticParts[(int)b3].ItemId);
				msgStr.ClearString();
				msgStr.StringToFormat(cstring);
				msgStr.IntToFormat((long)recordByKey2.SyntheticParts[(int)b3].Num, 1, false);
				msgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7507u));
			}
		}
		else
		{
			recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.LordEquip[equipIndex].ItemID);
			msgStr.ClearString();
			msgStr.StringToFormat(cstring);
			msgStr.IntToFormat((long)recordByKey.SyntheticParts[(int)b3].SyntheticItemNum, 1, false);
			msgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7507u));
		}
		GUIManager.Instance.AddHUDMessage(msgStr.ToString(), 255, true);
		this.LordEquip[equipIndex].Clear();
		this.ScanEquipUpdate();
		this.QuickSetSerialCheck = false;
		GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1, 1);
		GUIManager.Instance.HideUILock(EUILock.LordEquip);
	}

	// Token: 0x060013C5 RID: 5061 RVA: 0x00230600 File Offset: 0x0022E800
	public void InlayGem(ushort GemID, byte GemColor, uint ItemSerial, byte Pos)
	{
		if (GUIManager.Instance.ShowUILock(EUILock.LordEquip))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_INLAY_LORDEQUIP;
			messagePacket.AddSeqId();
			messagePacket.Add(GemID);
			messagePacket.Add(GemColor);
			messagePacket.Add(ItemSerial);
			messagePacket.Add(Pos);
			messagePacket.Send(false);
		}
	}

	// Token: 0x060013C6 RID: 5062 RVA: 0x00230660 File Offset: 0x0022E860
	public void Recv_MSG_RESP_INLAY_LORDEQUIP(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = b;
		if (b2 != 0)
		{
			if (b2 != 9)
			{
				return;
			}
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(16142u), 255, true);
			GUIManager.Instance.HideUILock(EUILock.LordEquip);
		}
		else
		{
			ushort num = MP.ReadUShort(-1);
			byte color = Math.Min(6, MP.ReadByte(-1));
			ushort quantity = MP.ReadUShort(-1);
			LordEquipData.setItemQuantity(num, color, quantity, 0L);
			ItemLordEquip equip = default(ItemLordEquip);
			equip.Init();
			equip.ItemID = MP.ReadUShort(-1);
			equip.Color = Math.Min(6, MP.ReadByte(-1));
			for (int i = 0; i < 4; i++)
			{
				equip.GemColor[i] = Math.Min(5, MP.ReadByte(-1));
			}
			for (int j = 0; j < 4; j++)
			{
				equip.Gem[j] = MP.ReadUShort(-1);
			}
			equip.SerialNO = MP.ReadUInt(-1);
			LordEquipData.updateEquip(equip);
			LordEquipData.SetItemTime(MP.ReadLong(-1));
			LordEquipData.SetGemTime(MP.ReadLong(-1));
			if (DataManager.Instance.EquipTable.GetRecordByKey(num).NewGem > 0)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(16133u), 255, true);
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7480u), 255, true);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1, 0);
			GUIManager.Instance.HideUILock(EUILock.LordEquip);
		}
	}

	// Token: 0x060013C7 RID: 5063 RVA: 0x0023082C File Offset: 0x0022EA2C
	public void RemoveGameFree(uint ItemSerial, byte Pos)
	{
		if (GUIManager.Instance.ShowUILock(EUILock.LordEquip))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_FREE_TAKEOFF_GEM;
			messagePacket.AddSeqId();
			messagePacket.Add(Pos);
			messagePacket.Add(ItemSerial);
			messagePacket.Send(false);
		}
	}

	// Token: 0x060013C8 RID: 5064 RVA: 0x0023087C File Offset: 0x0022EA7C
	public void Recv_MSG_RESP_FREE_TAKEOFF_GEM(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = b;
		if (b2 != 0)
		{
			return;
		}
		ItemLordEquip equip = default(ItemLordEquip);
		equip.Init();
		equip.ItemID = MP.ReadUShort(-1);
		equip.Color = Math.Min(6, MP.ReadByte(-1));
		for (int i = 0; i < 4; i++)
		{
			equip.GemColor[i] = Math.Min(5, MP.ReadByte(-1));
		}
		for (int j = 0; j < 4; j++)
		{
			equip.Gem[j] = MP.ReadUShort(-1);
		}
		equip.SerialNO = MP.ReadUInt(-1);
		LordEquipData.updateEquip(equip);
		LordEquipData.SetItemTime(MP.ReadLong(-1));
		byte b3 = MP.ReadByte(-1);
		if (b3 == 3)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(16140u), 255, true);
		}
		else
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7485u), 255, true);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1, 0);
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter) != null)
		{
			Door door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
			door.CloseMenu(false);
		}
		GUIManager.Instance.HideUILock(EUILock.LordEquip);
	}

	// Token: 0x060013C9 RID: 5065 RVA: 0x002309F0 File Offset: 0x0022EBF0
	public void Recv_Gem_TAKEOFF(MessagePacket MP)
	{
		ushort itemID = MP.ReadUShort(-1);
		byte color = Math.Min(6, MP.ReadByte(-1));
		ushort quantity = MP.ReadUShort(-1);
		LordEquipData.setItemQuantity(itemID, color, quantity, 0L);
		ItemLordEquip equip = default(ItemLordEquip);
		equip.Init();
		equip.ItemID = MP.ReadUShort(-1);
		equip.Color = Math.Min(6, MP.ReadByte(-1));
		for (int i = 0; i < 4; i++)
		{
			equip.GemColor[i] = Math.Min(5, MP.ReadByte(-1));
		}
		for (int j = 0; j < 4; j++)
		{
			equip.Gem[j] = MP.ReadUShort(-1);
		}
		equip.SerialNO = MP.ReadUInt(-1);
		LordEquipData.updateEquip(equip);
		LordEquipData.SetItemTime(MP.ReadLong(-1));
		LordEquipData.SetGemTime(MP.ReadLong(-1));
		byte b = MP.ReadByte(-1);
		if (b == 3)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(16140u), 255, true);
		}
		else
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7485u), 255, true);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1, 0);
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter) != null)
		{
			Door door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
			door.CloseMenu(false);
		}
		GUIManager.Instance.HideUILock(EUILock.LordEquip);
	}

	// Token: 0x060013CA RID: 5066 RVA: 0x00230B84 File Offset: 0x0022ED84
	public void DeComposeMaterial(ushort itemID, byte targetColor, ushort Quantity)
	{
		byte data = (DataManager.Instance.EquipTable.GetRecordByKey(itemID).EquipKind != 20) ? 1 : 0;
		if (GUIManager.Instance.ShowUILock(EUILock.LordEquip))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_DECOMPOSE_MATGEM;
			messagePacket.AddSeqId();
			messagePacket.Add(data);
			messagePacket.Add(itemID);
			messagePacket.Add(targetColor);
			messagePacket.Add(Quantity);
			messagePacket.Send(false);
		}
	}

	// Token: 0x060013CB RID: 5067 RVA: 0x00230C0C File Offset: 0x0022EE0C
	public void Recv_MSG_LORD_RESPDECOMPOSE_MATGEM(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = b;
		if (b2 != 0)
		{
			return;
		}
		byte b3 = MP.ReadByte(-1);
		ushort itemID = MP.ReadUShort(-1);
		byte color = Math.Min(6, MP.ReadByte(-1));
		ushort quantity = MP.ReadUShort(-1);
		LordEquipData.setItemQuantity(itemID, color, quantity, 0L);
		itemID = MP.ReadUShort(-1);
		color = Math.Min(6, MP.ReadByte(-1));
		quantity = MP.ReadUShort(-1);
		LordEquipData.setItemQuantity(itemID, color, quantity, 0L);
		long num = MP.ReadLong(-1);
		if (b3 == 0)
		{
			LordEquipData.SetMatTime(num);
		}
		else
		{
			LordEquipData.SetGemTime(num);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 1, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, (b3 != 0) ? 2 : 3, 1);
		AudioManager.Instance.PlayUISFX(UIKind.EquipFoundry);
		GUIManager.Instance.HideUILock(EUILock.LordEquip);
	}

	// Token: 0x060013CC RID: 5068 RVA: 0x00230CFC File Offset: 0x0022EEFC
	public void RESP_ALL_LORDEQUIP_MEMORY(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		int num = (int)((b + 1) * 10);
		if (this.LordEquipSets.Length < num)
		{
			Array.Resize<LordEquipSet>(ref this.LordEquipSets, num);
		}
		int num2 = (int)MP.ReadByte(-1);
		num2 += (int)(b * 10);
		this.LordEquipSetsCount = num2;
		for (int i = (int)(b * 10); i < num2; i++)
		{
			if (this.LordEquipSets[i] == null)
			{
				this.LordEquipSets[i] = new LordEquipSet();
			}
			if (this.LordEquipSets[i].Name == null)
			{
				this.LordEquipSets[i].Name = StringManager.Instance.SpawnString(30);
			}
			MP.ReadStringPlus((int)GameConstants.MAX_TALENT_CACHE_NAME_BYTE, this.LordEquipSets[i].Name, -1);
			for (int j = 0; j < 8; j++)
			{
				this.LordEquipSets[i].SerialNO[j] = MP.ReadUInt(-1);
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquipSetSelect, 0, 0);
	}

	// Token: 0x060013CD RID: 5069 RVA: 0x00230E04 File Offset: 0x0022F004
	public void RESP_LORDEQUIP_CHANGE(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			for (int i = 0; i < LordEquipData.RoleEquipSerial.Length; i++)
			{
				LordEquipData.RoleEquipSerial[i] = MP.ReadUInt(-1);
				if (LordEquipData.RoleEquipSerial[i] == 0u)
				{
					LordEquipData.RoleEquip[i].Clear();
				}
				else
				{
					for (int j = 0; j < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; j++)
					{
						if (this.LordEquip[j].SerialNO == LordEquipData.RoleEquipSerial[i])
						{
							LordEquipData.RoleEquip[i] = this.LordEquip[j].CloneSerial();
						}
					}
				}
			}
		}
		GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(927u), 255, true);
		DataManager.Instance.AttribVal.UpdateLordEquipData();
		AudioManager.Instance.PlayUISFX(UIKind.EquipTake);
		GUIManager.Instance.HideUILock(EUILock.LordInfo);
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_LordEquipSetSelect) != null)
		{
			Door door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
			if (door != null)
			{
				door.CloseMenu(false);
			}
		}
	}

	// Token: 0x060013CE RID: 5070 RVA: 0x00230F50 File Offset: 0x0022F150
	public static ushort getItemQuantity(ushort ItemID, byte color)
	{
		byte equipKind = DataManager.Instance.EquipTable.GetRecordByKey(ItemID).EquipKind;
		if (equipKind != 20)
		{
			if (equipKind != 27)
			{
				if (!LordEquipData.EqDataReq)
				{
					return 0;
				}
				ushort num = 0;
				for (int i = 0; i < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; i++)
				{
					if (LordEquipData._instance.LordEquip[i].ItemID == ItemID && LordEquipData._instance.LordEquip[i].Color == color)
					{
						num += 1;
					}
				}
				return num;
			}
			else
			{
				if (!LordEquipData.GemDataReq)
				{
					return 0;
				}
				for (int j = 0; j < LordEquipData._instance.LEGem.Length; j++)
				{
					if (LordEquipData._instance.LEGem[j].ItemID == ItemID && LordEquipData._instance.LEGem[j].Color == color)
					{
						return LordEquipData._instance.LEGem[j].Quantity;
					}
				}
			}
		}
		else
		{
			if (!LordEquipData.MaterialDataReq)
			{
				return 0;
			}
			for (int k = 0; k < LordEquipData._instance.LEMaterial.Length; k++)
			{
				if (LordEquipData._instance.LEMaterial[k].ItemID == ItemID && LordEquipData._instance.LEMaterial[k].Color == color)
				{
					return LordEquipData._instance.LEMaterial[k].Quantity;
				}
			}
		}
		return 0;
	}

	// Token: 0x060013CF RID: 5071 RVA: 0x002310F4 File Offset: 0x0022F2F4
	public static void setItemQuantity(ushort ItemID, byte color, ushort Quantity, long lastUpdateTime = 0L)
	{
		byte equipKind = DataManager.Instance.EquipTable.GetRecordByKey(ItemID).EquipKind;
		if (equipKind != 20)
		{
			if (equipKind == 27)
			{
				if (color > 5)
				{
					return;
				}
				if (!LordEquipData.GemDataReq)
				{
					return;
				}
				for (int i = 0; i < LordEquipData._instance.LEGem.Length; i++)
				{
					if (LordEquipData._instance.LEGem[i].ItemID == ItemID && LordEquipData._instance.LEGem[i].Color == color)
					{
						if (Quantity == 0)
						{
							LordEquipData._instance.LEGem[i].Clear();
						}
						else
						{
							LordEquipData._instance.LEGem[i].Quantity = Quantity;
						}
						if (lastUpdateTime != 0L)
						{
							LordEquipData.SetGemTime(lastUpdateTime);
							GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 2, 0);
						}
						return;
					}
				}
				for (int j = 0; j < LordEquipData._instance.LEGem.Length; j++)
				{
					if (LordEquipData._instance.LEGem[j].ItemID == 0)
					{
						LordEquipData._instance.LEGem[j].ItemID = ItemID;
						LordEquipData._instance.LEGem[j].Color = color;
						LordEquipData._instance.LEGem[j].Quantity = Quantity;
						if (lastUpdateTime != 0L)
						{
							LordEquipData.SetGemTime(lastUpdateTime);
							GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 2, 0);
						}
						return;
					}
				}
			}
		}
		else
		{
			if (color > 5)
			{
				return;
			}
			if (!LordEquipData.MaterialDataReq)
			{
				return;
			}
			for (int k = 0; k < LordEquipData._instance.LEMaterial.Length; k++)
			{
				if (LordEquipData._instance.LEMaterial[k].ItemID == ItemID && LordEquipData._instance.LEMaterial[k].Color == color)
				{
					if (Quantity == 0)
					{
						LordEquipData._instance.LEMaterial[k].Clear();
					}
					else
					{
						LordEquipData._instance.LEMaterial[k].Quantity = Quantity;
					}
					LordEquipData._instance.CountMat(ItemID);
					if (lastUpdateTime != 0L)
					{
						LordEquipData.SetMatTime(lastUpdateTime);
						GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 3, 0);
						GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 1, 0);
					}
					return;
				}
			}
			if (Quantity == 0)
			{
				return;
			}
			for (int l = 0; l < LordEquipData._instance.LEMaterial.Length; l++)
			{
				if (LordEquipData._instance.LEMaterial[l].ItemID == 0)
				{
					LordEquipData._instance.LEMaterial[l].ItemID = ItemID;
					LordEquipData._instance.LEMaterial[l].Color = color;
					LordEquipData._instance.LEMaterial[l].Quantity = Quantity;
					if (lastUpdateTime != 0L)
					{
						LordEquipData.SetMatTime(lastUpdateTime);
						GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 3, 0);
						GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 1, 0);
					}
					LordEquipData._instance.CountMat(ItemID);
					return;
				}
			}
		}
	}

	// Token: 0x060013D0 RID: 5072 RVA: 0x00231414 File Offset: 0x0022F614
	public static void SetItemTime(long time)
	{
		if (LordEquipData.EqDataReq)
		{
			LordEquipData._instance.LastUpdateTime_Equip = time;
		}
	}

	// Token: 0x060013D1 RID: 5073 RVA: 0x0023142C File Offset: 0x0022F62C
	public static void SetGemTime(long time)
	{
		if (LordEquipData.GemDataReq)
		{
			LordEquipData._instance.LastUpdateTime_Gem = time;
		}
	}

	// Token: 0x060013D2 RID: 5074 RVA: 0x00231444 File Offset: 0x0022F644
	public static void SetMatTime(long time)
	{
		if (LordEquipData.MaterialDataReq)
		{
			LordEquipData._instance.LastUpdateTime_Material = time;
		}
	}

	// Token: 0x060013D3 RID: 5075 RVA: 0x0023145C File Offset: 0x0022F65C
	public static int updateEquip(ItemLordEquip equip)
	{
		equip.Color = Math.Min(equip.Color, 6);
		if (equip.SerialNO != 0u)
		{
			for (int i = 0; i < 8; i++)
			{
				if (LordEquipData.RoleEquipSerial[i] == equip.SerialNO)
				{
					LordEquipData.RoleEquip[i] = equip.CloneSerial();
					DataManager.Instance.AttribVal.UpdateLordEquipData();
					break;
				}
			}
		}
		if (LordEquipData.EqDataReq)
		{
			for (int j = 0; j < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; j++)
			{
				if (LordEquipData._instance.LordEquip[j].SerialNO == equip.SerialNO)
				{
					equip.ExpireTime = LordEquipData._instance.LordEquip[j].ExpireTime;
					LordEquipData._instance.LordEquip[j] = equip.Clone();
					return j;
				}
			}
			for (int k = 0; k < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; k++)
			{
				if (LordEquipData._instance.LordEquip[k].SerialNO == 0u)
				{
					LordEquipData._instance.LordEquip[k] = equip.Clone();
					return k;
				}
			}
		}
		return -1;
	}

	// Token: 0x060013D4 RID: 5076 RVA: 0x002315B8 File Offset: 0x0022F7B8
	public static int updateEquipTime(uint Serial, long time)
	{
		if (Serial == 0u)
		{
			return -1;
		}
		if (LordEquipData.EqDataReq)
		{
			for (int i = 0; i < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; i++)
			{
				if (LordEquipData._instance.LordEquip[i].SerialNO == Serial)
				{
					LordEquipData._instance.LordEquip[i].ExpireTime = time;
					LordEquipData._instance.EquipExpireTime.Add(time);
					LordEquipData._instance.EquipExpireTime.Sort(new Comparison<long>(LordEquipData.timeSort));
					return i;
				}
			}
		}
		return -1;
	}

	// Token: 0x060013D5 RID: 5077 RVA: 0x00231658 File Offset: 0x0022F858
	public static void CheckEquipExpired()
	{
		ushort num = 0;
		for (int i = 0; i < LordEquipData._instance.EquipExpireTime.Count; i++)
		{
			if (DataManager.Instance.ServerTime < LordEquipData._instance.EquipExpireTime[i])
			{
				break;
			}
			num += 1;
		}
		if (num == 0)
		{
			return;
		}
		long serverTime = DataManager.Instance.ServerTime;
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_LORDEQUIP_CHECKEXPIRE;
		messagePacket.AddSeqId();
		messagePacket.Add(num);
		for (int j = 0; j < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; j++)
		{
			if (LordEquipData._instance.LordEquip[j].ExpireTime > 0L && LordEquipData._instance.LordEquip[j].ExpireTime <= serverTime)
			{
				messagePacket.Add(LordEquipData._instance.LordEquip[j].SerialNO);
			}
		}
		messagePacket.Send(false);
	}

	// Token: 0x060013D6 RID: 5078 RVA: 0x00231768 File Offset: 0x0022F968
	public static long getEquipTime(uint Serial)
	{
		if (Serial == 0u)
		{
			return 0L;
		}
		if (LordEquipData.EqDataReq)
		{
			for (int i = 0; i < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; i++)
			{
				if (LordEquipData._instance.LordEquip[i].SerialNO == Serial)
				{
					return LordEquipData._instance.LordEquip[i].ExpireTime;
				}
			}
		}
		return 0L;
	}

	// Token: 0x060013D7 RID: 5079 RVA: 0x002317DC File Offset: 0x0022F9DC
	public static void CleanForgeQuere()
	{
		DataManager.Instance.RoleAttr.LordEquipEventData.Clear();
		DataManager.Instance.RoleAttr.LordEquipEventTime.BeginTime = 0L;
		DataManager.Instance.RoleAttr.LordEquipEventTime.RequireTime = 0u;
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Forging, false, DataManager.Instance.RoleAttr.LordEquipEventTime.BeginTime, DataManager.Instance.RoleAttr.LordEquipEventTime.RequireTime);
	}

	// Token: 0x060013D8 RID: 5080 RVA: 0x00231860 File Offset: 0x0022FA60
	public static void ShowItemFinish(ItemLordEquip equip)
	{
		CString msgStr = GUIManager.Instance.MsgStr;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		GameConstants.GetColoredLordEquipString(cstring, equip.ItemID, equip.Color);
		msgStr.ClearString();
		msgStr.StringToFormat(cstring);
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Anvil) != null || GUIManager.Instance.FindMenu(EGUIWindow.UI_Forge) != null)
		{
			msgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7448u));
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(7447u), msgStr.ToString(), null, null, 0, 0, false, false, false, false, false);
		}
		else
		{
			msgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7510u));
			GUIManager.Instance.AddHUDMessage(msgStr.ToString(), 10, true);
		}
	}

	// Token: 0x060013D9 RID: 5081 RVA: 0x00231954 File Offset: 0x0022FB54
	public int GetEquipIndex(uint serial)
	{
		if (serial == 0u)
		{
			return -1;
		}
		for (byte b = 0; b < DataManager.Instance.RoleAttr.LordEquipBagSize; b += 1)
		{
			if (this.LordEquip[(int)b].SerialNO == serial)
			{
				return (int)b;
			}
		}
		return -1;
	}

	// Token: 0x060013DA RID: 5082 RVA: 0x002319A4 File Offset: 0x0022FBA4
	public int GetEquipPos(ushort itemid)
	{
		switch (DataManager.Instance.EquipTable.GetRecordByKey(itemid).EquipKind)
		{
		case 21:
			return 0;
		case 22:
			return 1;
		case 23:
			return 2;
		case 24:
			return 3;
		case 25:
			return 4;
		case 26:
			return 5;
		default:
			return -1;
		}
	}

	// Token: 0x060013DB RID: 5083 RVA: 0x00231A00 File Offset: 0x0022FC00
	public static void GetEffectList(ItemLordEquip item, List<LordEquipEffectSet> effList, byte overrideColor = 0, byte addPart = 0, bool checkSPRule = false)
	{
		if (item.ItemID == 0)
		{
			return;
		}
		if (item.Color == 0)
		{
			return;
		}
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(item.ItemID);
		byte b = item.Color;
		if (overrideColor > 0)
		{
			b = overrideColor;
		}
		if (GameConstants.IsBetween((int)b, 1, 5))
		{
			for (int i = 0; i < 6; i++)
			{
				if (recordByKey.PropertiesInfo[i].PropertiesValue > 0)
				{
					LordEquipEffectSet lordEquipEffectSet = LordEquipData.GetSingleEquipEffect(recordByKey.PropertiesInfo[i].Propertieskey, b);
					LordEquipData.AddEquipEffect(effList, lordEquipEffectSet);
				}
			}
		}
		else if (b == 6 && recordByKey.NewGemEffect[0] > 0)
		{
			LordEquipExtendData recordByKey2 = DataManager.Instance.LordEquipExtendTable.GetRecordByKey(recordByKey.NewGemEffect[0]);
			if (recordByKey.NewGemEffect[0] == recordByKey2.ID)
			{
				for (int j = 0; j < 6; j++)
				{
					if (recordByKey2.PropertiesInfo[j].PropertiesValue > 0)
					{
						LordEquipData.AddEquipEffect(effList, new LordEquipEffectSet
						{
							EffectID = recordByKey2.PropertiesInfo[j].Propertieskey,
							EffectValue = recordByKey2.PropertiesInfo[j].PropertiesValue
						});
					}
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (item.Gem[k] != 0)
			{
				Equip recordByKey3 = DataManager.Instance.EquipTable.GetRecordByKey(item.Gem[k]);
				for (int l = 0; l < 6; l++)
				{
					if (recordByKey3.PropertiesInfo[l].PropertiesValue > 0)
					{
						LordEquipEffectSet lordEquipEffectSet = LordEquipData.GetSingleEquipEffect(recordByKey3.PropertiesInfo[l].Propertieskey, item.GemColor[k]);
						LordEquipData.AddEquipEffect(effList, lordEquipEffectSet);
					}
				}
				if (recordByKey3.NewGem > 0)
				{
					for (int m = 0; m < 3; m++)
					{
						if (recordByKey3.NewGemEffect[m] > 0)
						{
							LordEquipEffectSet lordEquipEffectSet = new LordEquipEffectSet();
							lordEquipEffectSet.EffectID = recordByKey3.NewGemEffect[m];
							lordEquipEffectSet.FromPart = addPart;
							SpecialEffect recordByKey4 = DataManager.Instance.SpecialEffectTable.GetRecordByKey(recordByKey3.NewGemEffect[m]);
							if (checkSPRule)
							{
								byte descType = recordByKey4.DescType;
								if (descType == 1)
								{
									if (recordByKey4.ColorEffect[(int)(item.GemColor[k] - 1)] < (ushort)item.Color)
									{
										goto IL_2E1;
									}
								}
							}
							if (recordByKey4.ID == recordByKey3.NewGemEffect[m] && GameConstants.IsBetween((int)item.GemColor[k], 1, 5))
							{
								lordEquipEffectSet.EffectID = (ushort)recordByKey4.NewGemEffectID;
								lordEquipEffectSet.EffectValue = recordByKey4.ColorEffect[(int)(item.GemColor[k] - 1)];
								lordEquipEffectSet.isNewGemEffect = 1;
								LordEquipData.AddEquipEffect(effList, lordEquipEffectSet);
							}
						}
						IL_2E1:;
					}
				}
			}
		}
	}

	// Token: 0x060013DC RID: 5084 RVA: 0x00231D0C File Offset: 0x0022FF0C
	public static void GetEffectList(LordEquipMaterial gem, List<LordEquipEffectSet> effList)
	{
		LordEquipData.GetEffectList(gem.ItemID, gem.Color, effList);
	}

	// Token: 0x060013DD RID: 5085 RVA: 0x00231D24 File Offset: 0x0022FF24
	public static void GetEffectList(ushort ItemID, byte color, List<LordEquipEffectSet> effList)
	{
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(ItemID);
		if (recordByKey.EquipKind == 27 && recordByKey.NewGem > 0)
		{
			for (int i = 0; i < 3; i++)
			{
				LordEquipEffectSet lordEquipEffectSet = new LordEquipEffectSet();
				lordEquipEffectSet.isNewGemEffect = 1;
				SpecialEffect recordByKey2 = DataManager.Instance.SpecialEffectTable.GetRecordByKey(recordByKey.NewGemEffect[i]);
				if (recordByKey2.ID == recordByKey.NewGemEffect[i] && GameConstants.IsBetween((int)color, 1, 5))
				{
					lordEquipEffectSet.EffectID = (ushort)recordByKey2.NewGemEffectID;
					lordEquipEffectSet.EffectValue = recordByKey2.ColorEffect[(int)(color - 1)];
					LordEquipData.AddEquipEffect(effList, lordEquipEffectSet);
				}
			}
		}
		if (GameConstants.IsBetween((int)color, 1, 5))
		{
			for (int j = 0; j < 6; j++)
			{
				if (recordByKey.PropertiesInfo[j].PropertiesValue > 0)
				{
					LordEquipEffectSet lordEquipEffectSet = LordEquipData.GetSingleEquipEffect(recordByKey.PropertiesInfo[j].Propertieskey, color);
					LordEquipData.AddEquipEffect(effList, lordEquipEffectSet);
				}
			}
		}
		else if (color == 6 && recordByKey.NewGemEffect[0] > 0)
		{
			LordEquipExtendData recordByKey3 = DataManager.Instance.LordEquipExtendTable.GetRecordByKey(recordByKey.NewGemEffect[0]);
			if (recordByKey.NewGemEffect[0] == recordByKey3.ID)
			{
				for (int k = 0; k < 6; k++)
				{
					if (recordByKey3.PropertiesInfo[k].PropertiesValue > 0)
					{
						LordEquipData.AddEquipEffect(effList, new LordEquipEffectSet
						{
							EffectID = recordByKey3.PropertiesInfo[k].Propertieskey,
							EffectValue = recordByKey3.PropertiesInfo[k].PropertiesValue
						});
					}
				}
			}
		}
		if (recordByKey.EquipKind == 27 && recordByKey.EquipInfo != 0)
		{
			LordEquipData.AddEquipEffect(effList, new LordEquipEffectSet
			{
				isNewGemEffect = 2,
				EffectID = recordByKey.EquipInfo,
				EffectValue = 0
			});
		}
	}

	// Token: 0x060013DE RID: 5086 RVA: 0x00231F34 File Offset: 0x00230134
	public static void GetEffectCompareList(ItemLordEquip item, ItemLordEquip newItem, out List<LordEquipEffectCompareSet> effCompareList)
	{
		effCompareList = new List<LordEquipEffectCompareSet>();
		List<LordEquipEffectSet> list = new List<LordEquipEffectSet>();
		List<LordEquipEffectSet> list2 = new List<LordEquipEffectSet>();
		LordEquipData.GetEffectList(newItem, list, 0, 0, false);
		LordEquipData.GetEffectList(item, list2, 0, 0, false);
		for (int i = 0; i < list.Count; i++)
		{
			bool flag = false;
			for (int j = 0; j < list2.Count; j++)
			{
				if (list[i].EffectID == list2[j].EffectID && list2[j].isNewGemEffect == list[i].isNewGemEffect)
				{
					if (list[i].isNewGemEffect == 0)
					{
						flag = true;
						if (list[i].EffectValue == list2[j].EffectValue)
						{
							effCompareList.Add(new LordEquipEffectCompareSet(list[i].EffectID, (int)list[i].EffectValue, true, 0, false, 0));
						}
						else
						{
							effCompareList.Add(new LordEquipEffectCompareSet(list[i].EffectID, (int)(list[i].EffectValue - list2[j].EffectValue), false, 0, false, 0));
						}
					}
					else
					{
						flag = true;
						byte descType = DataManager.Instance.SpecialEffectTable.GetRecordByKey(list[i].EffectID).DescType;
						if (descType != 1)
						{
							if (list[i].EffectValue == list2[j].EffectValue)
							{
								LordEquipEffectCompareSet lordEquipEffectCompareSet = new LordEquipEffectCompareSet(list[i].EffectID, (int)list[i].EffectValue, true, 0, false, 1);
								lordEquipEffectCompareSet.onCompareNewSide = 1;
								effCompareList.Add(lordEquipEffectCompareSet);
							}
							else
							{
								LordEquipEffectCompareSet lordEquipEffectCompareSet2 = new LordEquipEffectCompareSet(list[i].EffectID, (int)list[i].EffectValue, false, 0, false, 1);
								lordEquipEffectCompareSet2.useForceColor = 1;
								lordEquipEffectCompareSet2.onCompareNewSide = 1;
								effCompareList.Add(lordEquipEffectCompareSet2);
								lordEquipEffectCompareSet2 = new LordEquipEffectCompareSet(list2[j].EffectID, (int)list2[j].EffectValue, false, 0, false, 1);
								lordEquipEffectCompareSet2.useForceColor = 2;
								lordEquipEffectCompareSet2.onCompareNewSide = 0;
								effCompareList.Add(lordEquipEffectCompareSet2);
							}
						}
						else if (list[i].EffectValue == list2[j].EffectValue && list[i].EffectValue >= (ushort)newItem.Color && list2[j].EffectValue >= (ushort)item.Color)
						{
							LordEquipEffectCompareSet lordEquipEffectCompareSet3 = new LordEquipEffectCompareSet(list[i].EffectID, (int)list[i].EffectValue, true, 0, false, 1);
							lordEquipEffectCompareSet3.onCompareNewSide = 1;
							effCompareList.Add(lordEquipEffectCompareSet3);
						}
						else
						{
							if (list[i].EffectValue >= (ushort)newItem.Color)
							{
								LordEquipEffectCompareSet lordEquipEffectCompareSet3 = new LordEquipEffectCompareSet(list[i].EffectID, (int)list[i].EffectValue, false, 0, false, 1);
								lordEquipEffectCompareSet3.useForceColor = 1;
								lordEquipEffectCompareSet3.onCompareNewSide = 1;
								effCompareList.Add(lordEquipEffectCompareSet3);
							}
							if (list2[j].EffectValue >= (ushort)item.Color)
							{
								LordEquipEffectCompareSet lordEquipEffectCompareSet3 = new LordEquipEffectCompareSet(list2[j].EffectID, (int)list2[j].EffectValue, false, 0, false, 1);
								lordEquipEffectCompareSet3.useForceColor = 2;
								lordEquipEffectCompareSet3.onCompareNewSide = 0;
								effCompareList.Add(lordEquipEffectCompareSet3);
							}
						}
					}
				}
			}
			if (!flag)
			{
				if (list[i].isNewGemEffect == 0)
				{
					effCompareList.Add(new LordEquipEffectCompareSet(list[i].EffectID, (int)list[i].EffectValue, false, 0, false, list[i].isNewGemEffect));
				}
				else
				{
					byte descType = DataManager.Instance.SpecialEffectTable.GetRecordByKey(list[i].EffectID).DescType;
					if (descType != 1)
					{
						effCompareList.Add(new LordEquipEffectCompareSet(list[i].EffectID, (int)list[i].EffectValue, false, 0, false, list[i].isNewGemEffect));
					}
					else if (list[i].EffectValue >= (ushort)newItem.Color)
					{
						LordEquipEffectCompareSet lordEquipEffectCompareSet4 = new LordEquipEffectCompareSet(list[i].EffectID, (int)list[i].EffectValue, false, 0, false, 1);
						lordEquipEffectCompareSet4.useForceColor = 1;
						lordEquipEffectCompareSet4.onCompareNewSide = 1;
						effCompareList.Add(lordEquipEffectCompareSet4);
					}
				}
			}
		}
		for (int k = 0; k < list2.Count; k++)
		{
			bool flag = false;
			for (int l = 0; l < list.Count; l++)
			{
				if (list2[k].EffectID == list[l].EffectID && list2[k].isNewGemEffect == list[l].isNewGemEffect)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				if (list2[k].isNewGemEffect == 1)
				{
					byte descType = DataManager.Instance.SpecialEffectTable.GetRecordByKey(list2[k].EffectID).DescType;
					if (descType != 1)
					{
						LordEquipEffectCompareSet lordEquipEffectCompareSet5 = new LordEquipEffectCompareSet(list2[k].EffectID, (int)list2[k].EffectValue, false, 0, false, 1);
						lordEquipEffectCompareSet5.useForceColor = 2;
						lordEquipEffectCompareSet5.onCompareNewSide = 0;
						effCompareList.Add(lordEquipEffectCompareSet5);
					}
					else if (list2[k].EffectValue >= (ushort)item.Color)
					{
						LordEquipEffectCompareSet lordEquipEffectCompareSet6 = new LordEquipEffectCompareSet(list2[k].EffectID, (int)list2[k].EffectValue, false, 0, false, 1);
						lordEquipEffectCompareSet6.useForceColor = 2;
						lordEquipEffectCompareSet6.onCompareNewSide = 0;
						effCompareList.Add(lordEquipEffectCompareSet6);
					}
				}
				else
				{
					LordEquipEffectCompareSet item2 = new LordEquipEffectCompareSet(list2[k].EffectID, (int)(-(int)list2[k].EffectValue), false, 0, false, list2[k].isNewGemEffect);
					effCompareList.Add(item2);
				}
			}
		}
	}

	// Token: 0x060013DF RID: 5087 RVA: 0x00232570 File Offset: 0x00230770
	public static void AddEquipEffect(List<LordEquipEffectSet> effList, LordEquipEffectSet add)
	{
		if (add.EffectID == 0)
		{
			return;
		}
		for (int i = 0; i < effList.Count; i++)
		{
			if (effList[i].EffectID == add.EffectID && add.isNewGemEffect == 0 && effList[i].isNewGemEffect == 0)
			{
				effList[i].EffectValue = effList[i].EffectValue + add.EffectValue;
				return;
			}
		}
		effList.Add(add);
	}

	// Token: 0x060013E0 RID: 5088 RVA: 0x002325FC File Offset: 0x002307FC
	public static LordEquipEffectSet GetSingleEquipEffect(ushort EquipEffectID, byte color)
	{
		LordEquipEffectSet lordEquipEffectSet = new LordEquipEffectSet();
		LordEquipEffectData recordByKey = DataManager.Instance.LordEquipEffectTable.GetRecordByKey(EquipEffectID);
		lordEquipEffectSet.EffectID = recordByKey.EffectID;
		lordEquipEffectSet.EffectValue = 0;
		if (color == 0)
		{
			return lordEquipEffectSet;
		}
		if (color >= 5)
		{
			lordEquipEffectSet.EffectValue = recordByKey.RarePercent[4];
		}
		else
		{
			lordEquipEffectSet.EffectValue = recordByKey.RarePercent[(int)(color - 1)];
		}
		return lordEquipEffectSet;
	}

	// Token: 0x060013E1 RID: 5089 RVA: 0x0023266C File Offset: 0x0023086C
	public static string GetItemKindTalkID(byte ItemKind)
	{
		switch (ItemKind)
		{
		case 20:
		case 27:
			return DataManager.Instance.mStringTable.GetStringByID(7454u);
		case 21:
			return DataManager.Instance.mStringTable.GetStringByID(7431u);
		case 22:
			return DataManager.Instance.mStringTable.GetStringByID(7432u);
		case 23:
			return DataManager.Instance.mStringTable.GetStringByID(7433u);
		case 24:
			return DataManager.Instance.mStringTable.GetStringByID(7434u);
		case 25:
			return DataManager.Instance.mStringTable.GetStringByID(7435u);
		case 26:
			return DataManager.Instance.mStringTable.GetStringByID(7436u);
		default:
			return string.Empty;
		}
	}

	// Token: 0x060013E2 RID: 5090 RVA: 0x00232744 File Offset: 0x00230944
	public static int EffectCompare(LordEquipEffectCompareSet x, LordEquipEffectCompareSet y)
	{
		if (x.group == y.group)
		{
			if (x.fromPart == y.fromPart)
			{
				return 0;
			}
			if (x.fromPart > y.fromPart)
			{
				return 1;
			}
			return -1;
		}
		else
		{
			if (x.group > y.group)
			{
				return 1;
			}
			return -1;
		}
	}

	// Token: 0x060013E3 RID: 5091 RVA: 0x002327A0 File Offset: 0x002309A0
	public static void EffectTitleListCreater(List<LordEquipEffectCompareSet> list)
	{
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].isNewGemEffect == 1)
			{
				list[i].group = byte.MaxValue;
			}
			else
			{
				for (int j = 0; j < DataManager.Instance.LordEquipEffectFilter.TableCount; j++)
				{
					LordEquipEffectFilterData recordByIndex = DataManager.Instance.LordEquipEffectFilter.GetRecordByIndex(j);
					if (list[i].EffectID == recordByIndex.effectID)
					{
						list[i].group = recordByIndex.effectType;
					}
				}
			}
		}
		list.Sort(new Comparison<LordEquipEffectCompareSet>(LordEquipData.EffectCompare));
		byte b = 0;
		for (int k = 0; k < list.Count; k++)
		{
			if (list[k].group > b)
			{
				b = list[k].group;
				list.Insert(k, new LordEquipEffectCompareSet(0, 0, false, b, true, 0));
			}
		}
	}

	// Token: 0x060013E4 RID: 5092 RVA: 0x002328AC File Offset: 0x00230AAC
	public static void effectListAddToEffectCompareList(List<LordEquipEffectSet> effList, List<LordEquipEffectCompareSet> list)
	{
		for (int i = 0; i < effList.Count; i++)
		{
			list.Add(new LordEquipEffectCompareSet(effList[i]));
		}
	}

	// Token: 0x060013E5 RID: 5093 RVA: 0x002328E4 File Offset: 0x00230AE4
	public bool CheckItemEnough(Equip mEquip, byte mcolor)
	{
		if (!LordEquipData.MaterialDataReq || !LordEquipData.EqDataReq)
		{
			return false;
		}
		if (mcolor > 1 && LordEquipData.getItemQuantity(mEquip.EquipKey, mcolor - 1) <= 0)
		{
			return false;
		}
		if (GameConstants.IsBetween((int)mcolor, 1, 5))
		{
			for (int i = 0; i < 4; i++)
			{
				if (mEquip.SyntheticParts[i].SyntheticItem > 0 && LordEquipData.getItemQuantity(mEquip.SyntheticParts[i].SyntheticItem, mcolor) < (ushort)mEquip.SyntheticParts[i].SyntheticItemNum)
				{
					return false;
				}
			}
		}
		else
		{
			if (mcolor != 6 || mEquip.NewGemEffect[0] <= 0)
			{
				return false;
			}
			LordEquipExtendData recordByKey = DataManager.Instance.LordEquipExtendTable.GetRecordByKey(mEquip.NewGemEffect[0]);
			if (mEquip.NewGemEffect[0] == recordByKey.ID)
			{
				for (int j = 0; j < 4; j++)
				{
					if (recordByKey.SyntheticParts[j].ItemId > 0 && LordEquipData.getItemQuantity(recordByKey.SyntheticParts[j].ItemId, recordByKey.SyntheticParts[j].Color) < (ushort)recordByKey.SyntheticParts[j].Num)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	// Token: 0x060013E6 RID: 5094 RVA: 0x00232A4C File Offset: 0x00230C4C
	public bool CheckMaterialEnough(ushort itemID, byte color, ushort number, bool AllColors)
	{
		if (!LordEquipData.MaterialDataReq)
		{
			return false;
		}
		if (AllColors)
		{
			if (!this.MatCountingCache)
			{
				this.StartMaterialCache();
			}
			int num;
			return this.MatValue.TryGetValue(itemID, out num) && (double)number * Math.Pow(4.0, (double)(color - 1)) <= (double)num;
		}
		return LordEquipData.getItemQuantity(itemID, color) >= number;
	}

	// Token: 0x060013E7 RID: 5095 RVA: 0x00232ABC File Offset: 0x00230CBC
	public bool CheckItemUpgradeReady(ItemLordEquip item)
	{
		if (!LordEquipData.MaterialDataReq || !LordEquipData.EqDataReq)
		{
			return false;
		}
		if (item.ItemID == 0)
		{
			return false;
		}
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(item.ItemID);
		if (item.SerialNO == DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO)
		{
			return false;
		}
		if (GameConstants.IsBetween((int)item.Color, 1, 4))
		{
			for (int i = 0; i < 4; i++)
			{
				if (recordByKey.SyntheticParts != null && recordByKey.SyntheticParts[i].SyntheticItem > 0 && !this.CheckMaterialEnough(recordByKey.SyntheticParts[i].SyntheticItem, item.Color + 1, (ushort)recordByKey.SyntheticParts[i].SyntheticItemNum, true))
				{
					return false;
				}
			}
		}
		else
		{
			if (item.Color != 5 || recordByKey.NewGemEffect[0] <= 0)
			{
				return false;
			}
			if (DataManager.Instance.GetTechLevel(227) == 0)
			{
				return false;
			}
			LordEquipExtendData recordByKey2 = DataManager.Instance.LordEquipExtendTable.GetRecordByKey(recordByKey.NewGemEffect[0]);
			if (recordByKey.NewGemEffect[0] == recordByKey2.ID)
			{
				for (int j = 0; j < 4; j++)
				{
					if (recordByKey2.SyntheticParts != null && recordByKey2.SyntheticParts[j].ItemId > 0 && !this.CheckMaterialEnough(recordByKey2.SyntheticParts[j].ItemId, recordByKey2.SyntheticParts[j].Color, (ushort)recordByKey2.SyntheticParts[j].Num, true))
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	// Token: 0x060013E8 RID: 5096 RVA: 0x00232C94 File Offset: 0x00230E94
	public void StartMaterialCache()
	{
		if (!LordEquipData.EqDataReq)
		{
			return;
		}
		if (!LordEquipData.MaterialDataReq)
		{
			return;
		}
		if (!this.EvoCountingReq)
		{
			return;
		}
		this.EvoCountingReq = false;
		this.MatCountingCache = true;
		if (this.MatValue == null)
		{
			this.MatValue = new Dictionary<ushort, int>();
		}
	}

	// Token: 0x060013E9 RID: 5097 RVA: 0x00232CE8 File Offset: 0x00230EE8
	public void CountMat(ushort itemID)
	{
		if (!LordEquipData.MaterialDataReq)
		{
			return;
		}
		if (!this.MatCountingCache)
		{
			return;
		}
		this.MatValue.Remove(itemID);
		double num = 0.0;
		for (int i = 0; i < this.LEMaterial.Length; i++)
		{
			if (this.LEMaterial[i].ItemID == itemID)
			{
				num += (double)this.LEMaterial[i].Quantity * Math.Pow(4.0, (double)(this.LEMaterial[i].Color - 1));
			}
		}
		if (num > 0.0)
		{
			this.MatValue.Add(itemID, (int)num);
		}
	}

	// Token: 0x060013EA RID: 5098 RVA: 0x00232DA8 File Offset: 0x00230FA8
	public void Scan_MaterialOrEquipIncreace()
	{
		if (this.isEquipEvoReady)
		{
			return;
		}
		this.ScanEquipUpdate();
	}

	// Token: 0x060013EB RID: 5099 RVA: 0x00232DBC File Offset: 0x00230FBC
	public void ScanEquipUpdate()
	{
		if (!this.MatCountingCache)
		{
			this.StartMaterialCache();
		}
		this.isEquipEvoReady = false;
		for (int i = 0; i < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; i++)
		{
			if (this.CheckItemUpgradeReady(this.LordEquip[i]))
			{
				this.isEquipEvoReady = true;
				break;
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 0, 0);
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
	}

	// Token: 0x060013EC RID: 5100 RVA: 0x00232E5C File Offset: 0x0023105C
	public bool isItemCombineReady(Equip itemData, byte mcolor)
	{
		if (!LordEquipData.MaterialDataReq || !LordEquipData.EqDataReq)
		{
			return false;
		}
		if (GameConstants.IsBetween((int)mcolor, 1, 5))
		{
			for (int i = 0; i < 4; i++)
			{
				if (itemData.SyntheticParts[i].SyntheticItem > 0 && LordEquipData.getItemQuantity(itemData.SyntheticParts[i].SyntheticItem, mcolor) < (ushort)itemData.SyntheticParts[i].SyntheticItemNum)
				{
					return false;
				}
			}
		}
		else
		{
			if (mcolor != 6 || itemData.NewGemEffect[0] <= 0)
			{
				return false;
			}
			LordEquipExtendData recordByKey = DataManager.Instance.LordEquipExtendTable.GetRecordByKey(itemData.NewGemEffect[0]);
			if (itemData.NewGemEffect[0] == recordByKey.ID)
			{
				for (int j = 0; j < 4; j++)
				{
					if (recordByKey.SyntheticParts[j].ItemId > 0 && LordEquipData.getItemQuantity(recordByKey.SyntheticParts[j].ItemId, recordByKey.SyntheticParts[j].Color) < (ushort)recordByKey.SyntheticParts[j].Num)
					{
						return false;
					}
				}
			}
		}
		return mcolor <= 1 || LordEquipData.getItemQuantity(itemData.EquipKey, mcolor - 1) > 0;
	}

	// Token: 0x060013ED RID: 5101 RVA: 0x00232FC4 File Offset: 0x002311C4
	public bool isItemCombineReady(ushort itemID, byte mcolor)
	{
		if (!LordEquipData.MaterialDataReq || !LordEquipData.EqDataReq)
		{
			return false;
		}
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(itemID);
		return this.isItemCombineReady(recordByKey, mcolor);
	}

	// Token: 0x060013EE RID: 5102 RVA: 0x00233000 File Offset: 0x00231200
	public void SetDictionary(bool Reset)
	{
		this.EquipDic.Clear();
		if (Reset)
		{
			return;
		}
		for (int i = 0; i < LordEquipData.RoleEquipSerial.Length; i++)
		{
			if (LordEquipData.RoleEquipSerial[i] > 0u)
			{
				this.EquipDic.Add(LordEquipData.RoleEquipSerial[i], i + 1);
			}
		}
	}

	// Token: 0x060013EF RID: 5103 RVA: 0x0023305C File Offset: 0x0023125C
	public static int ItemSort(ushort x, ushort y)
	{
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(LordEquipData._instance.LordEquip[(int)x].ItemID);
		Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(LordEquipData._instance.LordEquip[(int)y].ItemID);
		if (recordByKey.EquipKind < recordByKey2.EquipKind)
		{
			return -1;
		}
		if (recordByKey.EquipKind > recordByKey2.EquipKind)
		{
			return 1;
		}
		bool flag = LordEquipData._instance.EquipDic.ContainsKey(LordEquipData._instance.LordEquip[(int)x].SerialNO);
		bool flag2 = LordEquipData._instance.EquipDic.ContainsKey(LordEquipData._instance.LordEquip[(int)y].SerialNO);
		if (flag && !flag2)
		{
			return -1;
		}
		if (flag2 && !flag)
		{
			return 1;
		}
		if (flag && flag2)
		{
			int num;
			LordEquipData._instance.EquipDic.TryGetValue(LordEquipData._instance.LordEquip[(int)x].SerialNO, out num);
			int num2;
			LordEquipData._instance.EquipDic.TryGetValue(LordEquipData._instance.LordEquip[(int)y].SerialNO, out num2);
			if (num > num2)
			{
				return 1;
			}
			if (num < num2)
			{
				return -1;
			}
		}
		if (recordByKey.NeedLv < recordByKey2.NeedLv)
		{
			return 1;
		}
		if (recordByKey.NeedLv > recordByKey2.NeedLv)
		{
			return -1;
		}
		if (LordEquipData._instance.LordEquip[(int)x].ItemID < LordEquipData._instance.LordEquip[(int)y].ItemID)
		{
			return 1;
		}
		if (LordEquipData._instance.LordEquip[(int)x].ItemID > LordEquipData._instance.LordEquip[(int)y].ItemID)
		{
			return -1;
		}
		if (LordEquipData._instance.LordEquip[(int)x].Color < LordEquipData._instance.LordEquip[(int)y].Color)
		{
			return 1;
		}
		if (LordEquipData._instance.LordEquip[(int)x].Color > LordEquipData._instance.LordEquip[(int)y].Color)
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x060013F0 RID: 5104 RVA: 0x002332A4 File Offset: 0x002314A4
	public static int GemSort(ushort x, ushort y)
	{
		if (LordEquipData._instance.LEGem[(int)x].ItemID < LordEquipData._instance.LEGem[(int)y].ItemID)
		{
			return 1;
		}
		if (LordEquipData._instance.LEGem[(int)x].ItemID > LordEquipData._instance.LEGem[(int)y].ItemID)
		{
			return -1;
		}
		if (LordEquipData._instance.LEGem[(int)x].Color < LordEquipData._instance.LEGem[(int)y].Color)
		{
			return -1;
		}
		if (LordEquipData._instance.LEGem[(int)x].Color > LordEquipData._instance.LEGem[(int)y].Color)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x060013F1 RID: 5105 RVA: 0x00233378 File Offset: 0x00231578
	public static int MatSort(ushort x, ushort y)
	{
		if (LordEquipData._instance.LEMaterial[(int)x].ItemID < LordEquipData._instance.LEMaterial[(int)y].ItemID)
		{
			return 1;
		}
		if (LordEquipData._instance.LEMaterial[(int)x].ItemID > LordEquipData._instance.LEMaterial[(int)y].ItemID)
		{
			return -1;
		}
		if (LordEquipData._instance.LEMaterial[(int)x].Color < LordEquipData._instance.LEMaterial[(int)y].Color)
		{
			return -1;
		}
		if (LordEquipData._instance.LEMaterial[(int)x].Color > LordEquipData._instance.LEMaterial[(int)y].Color)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x060013F2 RID: 5106 RVA: 0x0023344C File Offset: 0x0023164C
	public static int timeSort(long x, long y)
	{
		if (x < y)
		{
			return -1;
		}
		if (y > x)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x060013F3 RID: 5107 RVA: 0x00233464 File Offset: 0x00231664
	public bool HaveEquipSpace()
	{
		bool flag = DataManager.Instance.RoleAttr.LordEquipEventData.ItemID != 0;
		for (int i = 0; i < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; i++)
		{
			if (this.LordEquip[i].SerialNO == 0u)
			{
				if (!flag)
				{
					return true;
				}
				flag = false;
			}
		}
		return false;
	}

	// Token: 0x060013F4 RID: 5108 RVA: 0x002334D4 File Offset: 0x002316D4
	public static bool OpenItemSource(ushort itemID)
	{
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(itemID);
		if (recordByKey.ActivitySuitIndex != 0)
		{
			if (MallManager.Instance.FindAndOpenMall((int)recordByKey.ActivitySuitIndex))
			{
				return true;
			}
			GUIManager.Instance.OpenItemKindFilterUI(18, 1, recordByKey.ActivitySuitIndex);
		}
		else
		{
			GUIManager.Instance.OpenItemKindFilterUI(18, 1, 0);
		}
		return true;
	}

	// Token: 0x060013F5 RID: 5109 RVA: 0x00233540 File Offset: 0x00231740
	public static int CheckHaveEquipKind(byte Kind, bool CheckRole = true)
	{
		if (!LordEquipData.EqDataReq)
		{
			return 0;
		}
		bool flag = false;
		for (int i = 0; i < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; i++)
		{
			if (LordEquipData._instance.LordEquip[i].ItemID != 0)
			{
				Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(LordEquipData._instance.LordEquip[i].ItemID);
				if (recordByKey.EquipKind == Kind)
				{
					if (!CheckRole || !LordEquipData._instance.isRoleEquipThis(LordEquipData._instance.LordEquip[i].SerialNO))
					{
						flag = true;
						if (LordEquipData._instance.LordEquip[i].SerialNO != DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO)
						{
							if (DataManager.Instance.RoleAttr.Level >= recordByKey.NeedLv)
							{
								return 1;
							}
						}
					}
				}
			}
		}
		return (!flag) ? 0 : 2;
	}

	// Token: 0x060013F6 RID: 5110 RVA: 0x0023365C File Offset: 0x0023185C
	public static void ResetLordEquipFont(UILEBtn lebtn)
	{
		if (!lebtn.gameObject.activeInHierarchy)
		{
			return;
		}
		if (lebtn.Name != null && lebtn.Name.gameObject.activeInHierarchy)
		{
			lebtn.Name.enabled = false;
			lebtn.Name.enabled = true;
		}
		if (lebtn.Quantity != null && lebtn.Quantity.gameObject.activeInHierarchy)
		{
			lebtn.Quantity.enabled = false;
			lebtn.Quantity.enabled = true;
		}
		if (lebtn.Level != null && lebtn.Level.gameObject.activeInHierarchy)
		{
			lebtn.Level.enabled = false;
			lebtn.Level.enabled = true;
		}
	}

	// Token: 0x060013F7 RID: 5111 RVA: 0x00233734 File Offset: 0x00231934
	public static void ResetLordEquipFont(Transform tf)
	{
		UILEBtn component = tf.GetComponent<UILEBtn>();
		if (component != null)
		{
			LordEquipData.ResetLordEquipFont(component);
		}
	}

	// Token: 0x060013F8 RID: 5112 RVA: 0x0023375C File Offset: 0x0023195C
	public void OpenForgeSet(ushort SetNo, byte Color)
	{
		int num = DataManager.Instance.ActivitylistEquip.BinarySearch(SetNo, DataManager.Instance.mActSortItem);
		if (num >= 0)
		{
			this.ForgeActivity_mKind = (byte)(num + 1);
		}
		else
		{
			num = 0;
			this.ForgeActivity_mKind = 1;
		}
		if (Color == 4 && this.IsCheckTechLevel())
		{
			Color = 5;
		}
		this.ForgeActivity_mColor = Color;
		this.ForgeActivity_KindScrollIdx = num;
		this.ForgeActivity_KindScroll_Y = (float)(79 * this.ForgeActivity_KindScrollIdx);
		if (DataManager.Instance.ActivitylistEquip.Count - this.ForgeActivity_KindScrollIdx < 5)
		{
			this.ForgeActivity_KindScroll_Y = (float)(79 * (DataManager.Instance.ActivitylistEquip.Count - 5) + 32);
		}
		Door door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_Forge_ActivityItem, 0, 0, false);
		}
	}

	// Token: 0x060013F9 RID: 5113 RVA: 0x0023383C File Offset: 0x00231A3C
	public void CheckQuickSets()
	{
		if (this.QuickSetSerialCheck)
		{
			return;
		}
		if (!LordEquipData.EqDataReq)
		{
			return;
		}
		if (this.LordEquipSetsCount < 1)
		{
			return;
		}
		this.QuickSetSerialCheck = true;
		for (int i = 0; i < this.LordEquipSetsCount; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				if (this.LordEquipSets[i].SerialNO[j] > 0u)
				{
					bool flag = false;
					for (int k = 0; k < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; k++)
					{
						if (this.LordEquip[k].SerialNO == this.LordEquipSets[i].SerialNO[j])
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						this.LordEquipSets[i].SerialNO[j] = 0u;
					}
				}
			}
		}
	}

	// Token: 0x060013FA RID: 5114 RVA: 0x00233918 File Offset: 0x00231B18
	public static void GetNewGemEffectString(CString CStr, byte newGemEffectID, int newGemEffectValue, bool isEven = true, byte isForceColor = 0)
	{
		SpecialEffect recordByIndex = DataManager.Instance.SpecialEffectTable.GetRecordByIndex(0);
		for (int i = 0; i < DataManager.Instance.SpecialEffectTable.TableCount; i++)
		{
			recordByIndex = DataManager.Instance.SpecialEffectTable.GetRecordByIndex(i);
			if (recordByIndex.NewGemEffectID == newGemEffectID)
			{
				break;
			}
		}
		if (recordByIndex.NewGemEffectID != newGemEffectID)
		{
			CStr.Append(DataManager.Instance.mStringTable.GetStringByID(11251u));
			return;
		}
		byte descType = recordByIndex.DescType;
		if (descType != 1)
		{
			CStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(11251u));
			if (isForceColor == 1)
			{
				CStr.AppendFormat("<color=#35F76CFF>+{0}</color>");
			}
			else if (isForceColor == 2)
			{
				CStr.AppendFormat("<color=#FF656EFF>-{0}</color>");
			}
			else if (isEven)
			{
				CStr.AppendFormat("<color=#FFF799FF>{0}</color>");
			}
			else if (newGemEffectValue > 0)
			{
				CStr.AppendFormat("<color=#35F76CFF>+{0}</color>");
			}
			else
			{
				CStr.AppendFormat("<color=#FF656EFF>-{0}</color>");
			}
		}
		else
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			if (GameConstants.IsBetween(newGemEffectValue, 1, 5))
			{
				cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)(11245 + newGemEffectValue)));
				cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByIndex.DescStringID));
			}
			else if (newGemEffectValue > 5)
			{
				cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(11265u));
				cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByIndex.DescStringID));
			}
			CStr.StringToFormat(cstring);
			if (isForceColor == 1)
			{
				CStr.AppendFormat("<color=#35F76CFF>+{0}</color>");
			}
			else if (isForceColor == 2)
			{
				CStr.AppendFormat("<color=#FF656EFF>-{0}</color>");
			}
			else if (isEven)
			{
				CStr.AppendFormat("<color=#FFF799FF>{0}</color>");
			}
			else
			{
				CStr.AppendFormat("<color=#35F76CFF>+{0}</color>");
			}
		}
	}

	// Token: 0x060013FB RID: 5115 RVA: 0x00233B38 File Offset: 0x00231D38
	public void GetMaterialEnough(ref byte tmpCount, ref byte tmpEnoughCount, byte mColor, int idx, Equip tmpEQ)
	{
		if (mColor > 4 && tmpEQ.NewGemEffect[0] > 0)
		{
			LordEquipExtendData recordByKey = DataManager.Instance.LordEquipExtendTable.GetRecordByKey(tmpEQ.NewGemEffect[0]);
			if (tmpEQ.NewGemEffect[0] == recordByKey.ID && recordByKey.SyntheticParts[idx].ItemId > 0)
			{
				tmpCount += 1;
				if (this.CheckMaterialEnough(recordByKey.SyntheticParts[idx].ItemId, recordByKey.SyntheticParts[idx].Color, (ushort)recordByKey.SyntheticParts[idx].Num, true))
				{
					tmpEnoughCount += 1;
				}
			}
		}
		else if (tmpEQ.SyntheticParts[idx].SyntheticItem > 0)
		{
			tmpCount += 1;
			if (this.CheckMaterialEnough(tmpEQ.SyntheticParts[idx].SyntheticItem, mColor + 1, (ushort)tmpEQ.SyntheticParts[idx].SyntheticItemNum, true))
			{
				tmpEnoughCount += 1;
			}
		}
	}

	// Token: 0x060013FC RID: 5116 RVA: 0x00233C58 File Offset: 0x00231E58
	public bool IsCheckTechLevel()
	{
		bool result = false;
		if (DataManager.Instance.GetTechLevel(227) > 0)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x04003C40 RID: 15424
	private const float limitRequestTime = 10f;

	// Token: 0x04003C41 RID: 15425
	public const ushort MaterialStackMax = 65535;

	// Token: 0x04003C42 RID: 15426
	public const byte MaxLordEquip = 200;

	// Token: 0x04003C43 RID: 15427
	public const ushort LordEquipEffectTypeTalkID = 8484;

	// Token: 0x04003C44 RID: 15428
	private static LordEquipData _instance = null;

	// Token: 0x04003C45 RID: 15429
	public readonly double[] forgeGold = new double[]
	{
		0.0,
		1.0,
		2.0,
		4.0,
		7.0,
		11.0,
		21.0
	};

	// Token: 0x04003C46 RID: 15430
	public readonly double[] forgeTime = new double[]
	{
		0.0,
		1.0,
		2.0,
		4.0,
		7.0,
		11.0,
		21.0
	};

	// Token: 0x04003C47 RID: 15431
	public ItemLordEquip[] LordEquip = new ItemLordEquip[200];

	// Token: 0x04003C48 RID: 15432
	public LordEquipMaterial[] LEGem = new LordEquipMaterial[1000];

	// Token: 0x04003C49 RID: 15433
	public LordEquipMaterial[] LEMaterial = new LordEquipMaterial[1000];

	// Token: 0x04003C4A RID: 15434
	public static uint[] RoleEquipSerial = new uint[8];

	// Token: 0x04003C4B RID: 15435
	public static LordEquipSerialData[] RoleEquip = new LordEquipSerialData[8];

	// Token: 0x04003C4C RID: 15436
	public LordEquipSet[] LordEquipSets = new LordEquipSet[10];

	// Token: 0x04003C4D RID: 15437
	public int LordEquipSetsCount;

	// Token: 0x04003C4E RID: 15438
	private bool MatCountingCache;

	// Token: 0x04003C4F RID: 15439
	private bool EvoCountingReq = true;

	// Token: 0x04003C50 RID: 15440
	public Dictionary<ushort, int> MatValue;

	// Token: 0x04003C51 RID: 15441
	public bool isEquipEvoReady;

	// Token: 0x04003C52 RID: 15442
	private long LastUpdateTime_Equip = -1L;

	// Token: 0x04003C53 RID: 15443
	private long LastUpdateTime_Gem = -1L;

	// Token: 0x04003C54 RID: 15444
	private long LastUpdateTime_Material = -1L;

	// Token: 0x04003C55 RID: 15445
	public static bool EqDataReq = false;

	// Token: 0x04003C56 RID: 15446
	public static bool GemDataReq = false;

	// Token: 0x04003C57 RID: 15447
	public static bool MaterialDataReq = false;

	// Token: 0x04003C58 RID: 15448
	public bool ForgeItem_bLvFilter = true;

	// Token: 0x04003C59 RID: 15449
	public byte ForgeItem_mEquip;

	// Token: 0x04003C5A RID: 15450
	public byte ForgeItem_mColor;

	// Token: 0x04003C5B RID: 15451
	public ushort ForgeItem_mSeletedFilter;

	// Token: 0x04003C5C RID: 15452
	public int ForgeItem_ScrollIdx;

	// Token: 0x04003C5D RID: 15453
	public byte ForgeActivity_mColor;

	// Token: 0x04003C5E RID: 15454
	public byte ForgeActivity_mKind;

	// Token: 0x04003C5F RID: 15455
	public int ForgeActivity_ScrollIdx;

	// Token: 0x04003C60 RID: 15456
	public int ForgeActivity_KindScrollIdx;

	// Token: 0x04003C61 RID: 15457
	public float ForgeActivity_KindScroll_Y;

	// Token: 0x04003C62 RID: 15458
	public bool QuickSetSerialCheck;

	// Token: 0x04003C63 RID: 15459
	private Dictionary<uint, int> EquipDic;

	// Token: 0x04003C64 RID: 15460
	public List<long> EquipExpireTime = new List<long>();
}
