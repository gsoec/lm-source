using System;
using UnityEngine;

// Token: 0x020003C4 RID: 964
public class MerchantmanManager
{
	// Token: 0x06001413 RID: 5139 RVA: 0x00234588 File Offset: 0x00232788
	private MerchantmanManager()
	{
	}

	// Token: 0x17000094 RID: 148
	// (get) Token: 0x06001414 RID: 5140 RVA: 0x002345A8 File Offset: 0x002327A8
	public static MerchantmanManager Instance
	{
		get
		{
			if (MerchantmanManager.instance == null)
			{
				MerchantmanManager.instance = new MerchantmanManager();
			}
			return MerchantmanManager.instance;
		}
	}

	// Token: 0x06001415 RID: 5141 RVA: 0x002345C4 File Offset: 0x002327C4
	public void SendReQusetBlackMarket_Data()
	{
		GUIManager.Instance.ShowUILock(EUILock.BlackMarket);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUSET_BLACKMARKET_DATA;
		messagePacket.AddSeqId();
		messagePacket.Add(1);
		messagePacket.Send(false);
	}

	// Token: 0x06001416 RID: 5142 RVA: 0x0023460C File Offset: 0x0023280C
	public void RecvBlackMarket_Data(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.BlackMarket);
		MP.ReadLong(-1);
		this.TradeLocks = MP.ReadByte(-1);
		this.TradeStatus = MP.ReadByte(-1);
		for (int i = 0; i < 4; i++)
		{
			this.MerchantmanData[i].itemID = MP.ReadUShort(-1);
			this.MerchantmanData[i].itemCount = MP.ReadUShort(-1);
			this.MerchantmanData[i].ResourceKind = MP.ReadByte(-1);
			this.MerchantmanData[i].ResourceCount = MP.ReadUInt(-1);
			this.MerchantmanData[i].Rare = MP.ReadByte(-1);
		}
		this.ExtraData = MP.ReadByte(-1);
		this.ExtraTreasureID = MallManager.Instance.TreasureIDTransToNew(MP.ReadUInt(-1));
		if (this.ExtraData != 1)
		{
			this.ClearSendCheckBuy();
			this.bNeedUpDateExtra = false;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 1, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_OpenBox, 3, 0);
			GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
		}
	}

	// Token: 0x06001417 RID: 5143 RVA: 0x00234740 File Offset: 0x00232940
	public void SendReQusetBlackMarket_Lock(byte mlock)
	{
		GUIManager.Instance.ShowUILock(EUILock.BlackMarket);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_BLACKMARKET_LOCK;
		messagePacket.AddSeqId();
		messagePacket.Add(mlock);
		messagePacket.Send(false);
	}

	// Token: 0x06001418 RID: 5144 RVA: 0x00234788 File Offset: 0x00232988
	public void RecvBlackMarket_Lock(MessagePacket MP)
	{
		byte tradeLocks = MP.ReadByte(-1);
		this.TradeLocks = tradeLocks;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 3, 0);
		GUIManager.Instance.HideUILock(EUILock.BlackMarket);
	}

	// Token: 0x06001419 RID: 5145 RVA: 0x002347C0 File Offset: 0x002329C0
	public void SendReQusetBlackMarket_Buy(byte mIdx, bool checkPay = true, bool bPay = false)
	{
		if (bPay && checkPay && (DataManager.Instance.MySysSetting.mPaySetting & 4) == 0)
		{
			GUIManager.Instance.OpenMenu(EGUIWindow.UI_PaySetting, (int)mIdx, 255, false, true, false);
			return;
		}
		GUIManager.Instance.ShowUILock(EUILock.BlackMarket);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_BLACKMARKET_BUY;
		messagePacket.AddSeqId();
		messagePacket.Add(mIdx);
		messagePacket.Send(false);
	}

	// Token: 0x0600141A RID: 5146 RVA: 0x00234840 File Offset: 0x00232A40
	public void RecvBlackMarket_Buy(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			byte b2 = MP.ReadByte(-1);
			byte b3 = b2 - this.TradeStatus;
			for (int i = 0; i < 4; i++)
			{
				if ((b3 >> i & 1) == 1)
				{
					MP.ReadUShort(-1);
					MP.ReadUShort(-1);
					byte b4 = MP.ReadByte(-1);
					b4 = (byte)Mathf.Clamp((int)b4, 0, DataManager.Instance.Resource.Length - 1);
					DataManager.Instance.Resource[(int)b4].Stock = MP.ReadUInt(-1);
					this.TradeStatus = b2;
				}
			}
			GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 2, 0);
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1500u), 18, true);
			GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
			AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
			FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_CARGO_SHIP_EXCHANGE);
		}
		else if (b == 1)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 4, 0);
		}
		else if (b == 2)
		{
			this.MerchantmanExtraData.LocksBought = MP.ReadByte(-1);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 1, 0);
			this.SendCheckBuy = 1;
			DataManager dataManager = DataManager.Instance;
			string stringByID = dataManager.mStringTable.GetStringByID(8874u);
			string productPriceByID = IGGGameSDK.Instance.GetProductPriceByID((int)MallManager.Instance.SmallID);
			if ((DataManager.Instance.MySysSetting.mPaySetting & 1) > 0)
			{
				if (IGGSDKPlugin.isWXAppInstalled())
				{
					GUIManager.Instance.HideUILock(EUILock.Mall);
					if (IGGGameSDK.Instance.GetRealNameSW() == 1)
					{
						if (!RealNameHelp.Instance.CheckOpenRealNameDlg())
						{
							GUIManager.Instance.ShowUILock(EUILock.WeChatPay);
							if (AntiAddictive.Instance.IsNonage())
							{
								IGGSDKPlugin.WeChatPay(MallManager.Instance.SmallID.ToString(), stringByID, productPriceByID, true, IGGGameSDK.Instance.GetMinorsDailySpendAmount());
							}
							else
							{
								IGGSDKPlugin.WeChatPay(MallManager.Instance.SmallID.ToString(), stringByID, productPriceByID);
							}
						}
					}
					else
					{
						GUIManager.Instance.ShowUILock(EUILock.WeChatPay);
						IGGSDKPlugin.WeChatPay(MallManager.Instance.SmallID.ToString(), stringByID, productPriceByID);
					}
				}
				else
				{
					GUIManager.Instance.OpenMessageBox(dataManager.mStringTable.GetStringByID(614u), dataManager.mStringTable.GetStringByID(9525u), null, null, 0, 0, false, false, false, false, false);
				}
			}
			else if ((DataManager.Instance.MySysSetting.mPaySetting & 2) > 0)
			{
				GUIManager.Instance.HideUILock(EUILock.Mall);
				if (IGGGameSDK.Instance.GetRealNameSW() == 1)
				{
					if (!RealNameHelp.Instance.CheckOpenRealNameDlg())
					{
						GUIManager.Instance.ShowUILock(EUILock.AliPay);
						if (AntiAddictive.Instance.IsNonage())
						{
							IGGSDKPlugin.AliPay(MallManager.Instance.SmallID.ToString(), stringByID, productPriceByID, true, IGGGameSDK.Instance.GetMinorsDailySpendAmount());
						}
						else
						{
							IGGSDKPlugin.AliPay(MallManager.Instance.SmallID.ToString(), stringByID, productPriceByID);
						}
					}
				}
				else
				{
					GUIManager.Instance.ShowUILock(EUILock.AliPay);
					IGGSDKPlugin.AliPay(MallManager.Instance.SmallID.ToString(), stringByID, productPriceByID);
				}
			}
		}
		else if (b == 3)
		{
			AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
			AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
			this.MerchantmanExtraData.LocksBought = MP.ReadByte(-1);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 1, 0);
			this.ClearSendCheckBuy();
			FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_CARGO_SHIP_EXCHANGE);
		}
		else if (b == 4)
		{
			this.MerchantmanExtraData.LocksBought = MP.ReadByte(-1);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 1, 0);
		}
		GUIManager.Instance.HideUILock(EUILock.BlackMarket);
	}

	// Token: 0x0600141B RID: 5147 RVA: 0x00234C50 File Offset: 0x00232E50
	public void RecvExtraTrade(MessagePacket MP)
	{
		bool flag = false;
		if (this.ExtraData == 0)
		{
			flag = true;
		}
		this.bNeedUpDateExtra = false;
		this.ExtraData = 1;
		this.MerchantmanExtraData.TradePos = MP.ReadByte(-1);
		this.MerchantmanExtraData.LocksBought = MP.ReadByte(-1);
		this.MerchantmanExtraData.itemID = MP.ReadUShort(-1);
		this.MerchantmanExtraData.Discount = MP.ReadByte(-1);
		if (this.MerchantmanExtraData.Discount > 3)
		{
			this.MerchantmanExtraData.Discount = 3;
		}
		this.MerchantmanExtraData.DataLen = MP.ReadByte(-1);
		if (this.MerchantmanExtraData.DataLen > 200)
		{
			this.MerchantmanExtraData.DataLen = 0;
		}
		for (int i = 0; i < (int)this.MerchantmanExtraData.DataLen; i++)
		{
			this.MerchantmanExtraData.ItemContain[i].ItemID = MP.ReadUShort(-1);
			this.MerchantmanExtraData.ItemContain[i].Num = MP.ReadUShort(-1);
			this.MerchantmanExtraData.ItemContain[i].ItemRank = MP.ReadByte(-1);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 1, 0);
		if (flag)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 5, 0);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_OpenBox, 2, 0);
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
		GUIManager.Instance.HideUILock(EUILock.BlackMarket);
	}

	// Token: 0x0600141C RID: 5148 RVA: 0x00234DD8 File Offset: 0x00232FD8
	public void RecvExtraChange(MessagePacket MP)
	{
		if (this.ExtraData == 1)
		{
			this.bNeedUpDateExtra = true;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_OpenBox, 1, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 6, 0);
		}
	}

	// Token: 0x0600141D RID: 5149 RVA: 0x00234E14 File Offset: 0x00233014
	public void SendReQusetBlackMarket_ExtraLock(byte block)
	{
		GUIManager.Instance.ShowUILock(EUILock.BlackMarket);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_BLACKMARKET_EXTRA_LOCK;
		messagePacket.AddSeqId();
		messagePacket.Add(block);
		messagePacket.Send(false);
	}

	// Token: 0x0600141E RID: 5150 RVA: 0x00234E5C File Offset: 0x0023305C
	public bool CheckbWaitBuy(bool bShowMessage = false)
	{
		if (this.bLockBuy)
		{
			if (bShowMessage)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(656u), 255, true);
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600141F RID: 5151 RVA: 0x00234EA4 File Offset: 0x002330A4
	public void ClearSendCheckBuy()
	{
		this.SendCheckBuy = 0;
		this.bLockBuy = false;
	}

	// Token: 0x06001420 RID: 5152 RVA: 0x00234EB4 File Offset: 0x002330B4
	~MerchantmanManager()
	{
	}

	// Token: 0x04003C7B RID: 15483
	private static MerchantmanManager instance;

	// Token: 0x04003C7C RID: 15484
	public BlackMarketTradeData[] MerchantmanData = new BlackMarketTradeData[4];

	// Token: 0x04003C7D RID: 15485
	public byte TradeLocks;

	// Token: 0x04003C7E RID: 15486
	public byte TradeStatus;

	// Token: 0x04003C7F RID: 15487
	public byte ExtraData;

	// Token: 0x04003C80 RID: 15488
	public BlackMarketExtraTradeData MerchantmanExtraData = new BlackMarketExtraTradeData(0);

	// Token: 0x04003C81 RID: 15489
	public byte SendCheckBuy;

	// Token: 0x04003C82 RID: 15490
	public bool bLockBuy;

	// Token: 0x04003C83 RID: 15491
	public bool bNeedUpDateExtra;

	// Token: 0x04003C84 RID: 15492
	public uint ExtraTreasureID;
}
