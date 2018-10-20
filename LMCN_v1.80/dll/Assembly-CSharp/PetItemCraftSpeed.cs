using System;

// Token: 0x0200084C RID: 2124
public class PetItemCraftSpeed : SpeedupBase
{
	// Token: 0x06002BE7 RID: 11239 RVA: 0x00483264 File Offset: 0x00481464
	public PetItemCraftSpeed(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(14667u);
		this.CompleteImmContStr = mStringTable.GetStringByID(14668u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(14658u);
		this.bFreeSpeedup = false;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.ItemCraft;
		this.FilterType = 22;
	}

	// Token: 0x06002BE8 RID: 11240 RVA: 0x004832DC File Offset: 0x004814DC
	public override void SendImmediate()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ITEMCRAFT_START;
		messagePacket.AddSeqId();
		messagePacket.Add(0);
		messagePacket.Add(0);
		messagePacket.Add(2);
		messagePacket.Send(false);
	}

	// Token: 0x06002BE9 RID: 11241 RVA: 0x00483324 File Offset: 0x00481524
	public override void SendImmediateFree()
	{
	}
}
