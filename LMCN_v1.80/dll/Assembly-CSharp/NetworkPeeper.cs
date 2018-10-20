using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using UnityEngine;

// Token: 0x0200077D RID: 1917
public class NetworkPeeper
{
	// Token: 0x0600257D RID: 9597 RVA: 0x0042BA58 File Offset: 0x00429C58
	public bool View(ushort Id, bool Force = false)
	{
		if (NetworkPeeper.Stage < LoginPhase.LP_Connecting || NetworkPeeper.Stage > LoginPhase.LP_Logging || Force)
		{
			this.Drop(false);
			this.ID = Id;
			NetworkPeeper.Stage = LoginPhase.LP_Connecting;
			this.ConnectTime = 15f;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_GUESTLOGIN_REQUESTIPTOP;
			messagePacket.AddSeqId();
			messagePacket.Add(Id);
			messagePacket.Add(NetworkManager.UDID, NetworkManager.UDID.Length);
			return messagePacket.Send(false);
		}
		return false;
	}

	// Token: 0x0600257E RID: 9598 RVA: 0x0042BAE4 File Offset: 0x00429CE4
	protected bool Connect()
	{
		if (this.LostInSpace)
		{
			this.Drop(true);
		}
		else if (this.LifeProbing)
		{
			if (NetworkPeeper.Stage == LoginPhase.LP_Connecting)
			{
				GuestMessagePacket.Sequence = 0;
				NetworkPeeper.Stage = LoginPhase.LP_Connected;
				this.ConnectTime = 15f;
				MessagePacket guestMessagePack = MessagePacket.GetGuestMessagePack();
				guestMessagePack.Protocol = Protocol._MSG_GUESTLOGIN_LOGIN;
				guestMessagePack.Add(NetworkManager.UserID);
				guestMessagePack.Add(NetworkManager.UDID, NetworkManager.UDID.Length);
				guestMessagePack.Send(true);
			}
			return this.LifeProbing = false;
		}
		return true;
	}

	// Token: 0x0600257F RID: 9599 RVA: 0x0042BB7C File Offset: 0x00429D7C
	public bool Connecting()
	{
		return NetworkPeeper.Stage > LoginPhase.LP_Disconnect && NetworkPeeper.Stage < LoginPhase.LP_InGame;
	}

	// Token: 0x06002580 RID: 9600 RVA: 0x0042BB98 File Offset: 0x00429D98
	public bool Connected()
	{
		return NetworkPeeper.Stage == LoginPhase.LP_InGame;
	}

	// Token: 0x06002581 RID: 9601 RVA: 0x0042BBA4 File Offset: 0x00429DA4
	public void Resume(bool sure = true)
	{
		if (NetworkPeeper.Stage == LoginPhase.LP_Connecting || NetworkPeeper.Stage == LoginPhase.LP_Connected)
		{
			this.View(this.ID, sure);
		}
	}

	// Token: 0x06002582 RID: 9602 RVA: 0x0042BBD8 File Offset: 0x00429DD8
	public void Drop(bool Force = false)
	{
		if (NetworkPeeper.Sucket != null)
		{
			NetworkPeeper.Sucket.Close();
			NetworkPeeper.Sucket = null;
		}
		NetworkPeeper.SendBuff.Clear();
		NetworkManager.Cleansing();
		NetworkPeeper.Stage = LoginPhase.LP_Disconnect;
		this.LostInSpace = (this.LifeProbing = false);
		this.BeatTime = (this.LinkTime = (this.ConnectTime = (float)(this.Result = 0)));
		if (Force)
		{
			GameManager.OnRefresh(NetworkNews.GuestLost, null);
		}
	}

	// Token: 0x06002583 RID: 9603 RVA: 0x0042BC58 File Offset: 0x00429E58
	public void Enter(MessagePacket MP)
	{
		if (NetworkPeeper.Stage != LoginPhase.LP_Connecting)
		{
			this.LostInSpace = true;
			return;
		}
		AddressFamily addressFamily = AddressFamily.Unknown;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		string text = MP.ReadString(16, MP.Offset + 4);
		GameConstants.GetHostName(cstring, text, "lm-proxy-");
		IPAddress[] array = null;
		try
		{
			array = Dns.GetHostAddresses(cstring.ToString());
		}
		catch (Exception ex)
		{
			Debug.Log("[Enter]:" + ex.Message);
		}
		if (array == null)
		{
			array = new IPAddress[1];
			if (IPAddress.TryParse(text, out array[0]))
			{
				addressFamily = array[0].AddressFamily;
			}
		}
		else if (array.Length > 0 && array[0] != null)
		{
			addressFamily = array[0].AddressFamily;
		}
		cstring.ClearString();
		if (addressFamily == AddressFamily.Unknown)
		{
			this.LostInSpace = true;
			return;
		}
		this.ConnectTime = 15f;
		NetworkPeeper.Sucket = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp)
		{
			Blocking = false,
			SendTimeout = 0,
			ReceiveTimeout = 0
		};
		try
		{
			NetworkPeeper.Sucket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Debug, true);
			NetworkPeeper.Sucket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, NetworkManager.LOL);
		}
		catch
		{
		}
		if (NetworkPeeper.Sucket.BeginConnect(array[0], MP.ReadInt(-1), new AsyncCallback(this.ConnectCallback), NetworkPeeper.Sucket).CompletedSynchronously)
		{
			this.ConnectCallback(null);
		}
	}

	// Token: 0x06002584 RID: 9604 RVA: 0x0042BE04 File Offset: 0x0042A004
	public void Login(MessagePacket MP)
	{
		switch (this.Result = MP.ReadByte(-1))
		{
		case 0:
			NetworkPeeper.Stage = LoginPhase.LP_InGame;
			DataManager.MapDataController.FocusKingdomTime = MP.ReadULong(-1);
			DataManager.MapDataController.FocusKingdomPeriod = (KINGDOM_PERIOD)MP.ReadByte(-1);
			if (DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
			{
				DataManager.MapDataController.OtherKingdomData.kingdomPeriod = DataManager.MapDataController.FocusKingdomPeriod;
			}
			if (DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				DataManager.MapDataController.kingdomData.kingdomPeriod = DataManager.MapDataController.FocusKingdomPeriod;
			}
			this.ConnectTime = 0f;
			this.HeartBeat(15L);
			GameConstants.GetBytes(NetworkManager.GuestController.ID, DataManager.msgBuffer, 0);
			GameManager.OnGuestLogin();
			return;
		case 1:
			this.Resume(true);
			return;
		case 5:
			this.Drop(false);
			GameManager.OnRefresh(NetworkNews.GuestConnectFail, null);
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(101u), DataManager.Instance.mStringTable.GetStringByID(911u), null, null, 0, 0, false, false, false, false, false);
			return;
		}
		this.LostInSpace = true;
	}

	// Token: 0x06002585 RID: 9605 RVA: 0x0042BF74 File Offset: 0x0042A174
	private void ConnectCallback(IAsyncResult ar)
	{
		if (ar == null || NetworkPeeper.Sucket == null || NetworkPeeper.Sucket.Handle.ToInt32() == -1 || (Socket)ar.AsyncState != NetworkPeeper.Sucket)
		{
			return;
		}
		if (((Socket)ar.AsyncState).Connected && NetworkPeeper.Stage != LoginPhase.LP_Logging)
		{
			this.LifeProbing = true;
		}
		else if (ar != null)
		{
			try
			{
				NetworkPeeper.Sucket.EndConnect(ar);
			}
			catch
			{
			}
			this.LostInSpace = true;
		}
	}

	// Token: 0x06002586 RID: 9606 RVA: 0x0042C02C File Offset: 0x0042A22C
	public void MakeBeat(MessagePacket MP, long time = 15L)
	{
		NetworkPeeper.ServerTime = MP.ReadLong(-1);
		this.BeatTime = (float)time;
		this.LinkTime = 0f;
	}

	// Token: 0x06002587 RID: 9607 RVA: 0x0042C050 File Offset: 0x0042A250
	public void HeartBeat(long time = 15L)
	{
		this.BeatTime = 0f;
		this.LinkTime = (float)time;
		MessagePacket guestMessagePack = MessagePacket.GetGuestMessagePack();
		guestMessagePack.Protocol = Protocol._MSG_REQUEST_ACTIVE;
		guestMessagePack.AddSeqId();
		guestMessagePack.Send(false);
	}

	// Token: 0x06002588 RID: 9608 RVA: 0x0042C090 File Offset: 0x0042A290
	public static void Cipher(byte[] Codon, int Offset, int Size, int Durex = 0)
	{
		if (NetworkPeeper.Stage >= LoginPhase.LP_Role && Durex > 0)
		{
			using (MemoryStream memoryStream = new MemoryStream(Codon, Offset, Size >> 3 << 3, false, false))
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, NetworkManager.DES, CryptoStreamMode.Read))
				{
					cryptoStream.Read(Codon, Offset, memoryStream.Capacity);
				}
			}
		}
	}

	// Token: 0x06002589 RID: 9609 RVA: 0x0042C134 File Offset: 0x0042A334
	public void CheckBuffer()
	{
		if (this.LostInSpace || (this.ConnectTime > 0f && (this.ConnectTime -= NetworkManager.DeltaTime) <= 0f) || (this.LinkTime > 0f && (this.LinkTime -= NetworkManager.DeltaTime) <= 0f))
		{
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(101u), DataManager.Instance.mStringTable.GetStringByID(274u) + ":" + this.Result, null, null, 0, 0, false, false, false, false, false);
			this.Drop(true);
		}
		else if (this.Connect() && NetworkPeeper.Sucket != null && NetworkPeeper.Sucket.Connected)
		{
			if (this.BeatTime > 0f && (this.BeatTime -= NetworkManager.DeltaTime) <= 0f)
			{
				this.HeartBeat(15L);
			}
			if (NetworkPeeper.Sucket.Poll(0, SelectMode.SelectWrite) && NetworkPeeper.SendBuff.Count > 0)
			{
				NetworkManager.SendSocket((MessagePacket)NetworkPeeper.SendBuff.Peek());
			}
			while (NetworkPeeper.Sucket != null && NetworkPeeper.Sucket.Poll(0, SelectMode.SelectRead))
			{
				if (NetworkPeeper.read_pos >= 4096)
				{
					if (NetworkPeeper.parse_pos > 0)
					{
						Buffer.BlockCopy(NetworkPeeper.ReadData, NetworkPeeper.parse_pos, NetworkPeeper.ReadData, 0, NetworkPeeper.read_pos -= NetworkPeeper.parse_pos);
					}
					else
					{
						this.Drop(true);
					}
					NetworkPeeper.parse_pos = 0;
					return;
				}
				int num = NetworkPeeper.Sucket.Receive(NetworkPeeper.ReadData, NetworkPeeper.read_pos, NetworkPeeper.ReadData.Length - NetworkPeeper.read_pos, SocketFlags.None, out NetworkManager.SucketError);
				if (num == 0)
				{
					this.Drop(true);
					break;
				}
				if (NetworkPeeper.read_pos + num > 4096)
				{
					break;
				}
				NetworkPeeper.read_pos += num;
				while (NetworkPeeper.read_pos - NetworkPeeper.parse_pos >= 4)
				{
					ushort num2 = GameConstants.ConvertBytesToUShort(NetworkPeeper.ReadData, NetworkPeeper.parse_pos);
					if (num2 < 4 || num2 > 4096)
					{
						NetworkPeeper.parse_pos += 4;
					}
					else
					{
						if ((int)num2 > NetworkPeeper.read_pos - NetworkPeeper.parse_pos)
						{
							break;
						}
						MessagePacket messagePacket = new MessagePacket(ref NetworkPeeper.ReadData, NetworkPeeper.parse_pos + 4, (int)(num2 - 4));
						messagePacket.Protocol = (Protocol)GameConstants.ConvertBytesToUShort(NetworkPeeper.ReadData, NetworkPeeper.parse_pos + 2);
						NetworkManager.Cipher(NetworkPeeper.ReadData, messagePacket.Data.GetIndex(0), messagePacket.Length, 0);
						NetworkPeeper.parse_pos += (int)num2;
						DispatchManager.GuestDispatcher(messagePacket);
					}
				}
				if (NetworkPeeper.parse_pos > 0)
				{
					Buffer.BlockCopy(NetworkPeeper.ReadData, NetworkPeeper.parse_pos, NetworkPeeper.ReadData, 0, NetworkPeeper.read_pos -= NetworkPeeper.parse_pos);
				}
				NetworkPeeper.parse_pos = 0;
			}
		}
	}

	// Token: 0x0400700E RID: 28686
	public static Socket Sucket;

	// Token: 0x0400700F RID: 28687
	public static LoginPhase Stage;

	// Token: 0x04007010 RID: 28688
	public static Queue SendBuff = new Queue();

	// Token: 0x04007011 RID: 28689
	public static byte[] ReadData = new byte[4096];

	// Token: 0x04007012 RID: 28690
	public static int parse_pos;

	// Token: 0x04007013 RID: 28691
	public static int read_pos;

	// Token: 0x04007014 RID: 28692
	public ushort ID;

	// Token: 0x04007015 RID: 28693
	public byte Result;

	// Token: 0x04007016 RID: 28694
	public int Sequence;

	// Token: 0x04007017 RID: 28695
	public float BeatTime;

	// Token: 0x04007018 RID: 28696
	public float LinkTime;

	// Token: 0x04007019 RID: 28697
	public float ConnectTime;

	// Token: 0x0400701A RID: 28698
	private bool LifeProbing;

	// Token: 0x0400701B RID: 28699
	private bool LostInSpace;

	// Token: 0x0400701C RID: 28700
	public static long ServerTime;
}
