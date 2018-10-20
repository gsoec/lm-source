using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

// Token: 0x0200077E RID: 1918
public class NetworkManager : IDisposable
{
    // Token: 0x0600258A RID: 9610 RVA: 0x0042C460 File Offset: 0x0042A660
    private NetworkManager()
    {
        NetworkManager.Crypto.BlockSize = 64;
        NetworkManager.Crypto.FeedbackSize = 8;
        NetworkManager.Crypto.Mode = CipherMode.ECB;
        NetworkManager.Crypto.Padding = PaddingMode.None;
        NetworkManager.DES = NetworkManager.Crypto.CreateEncryptor(Encoding.ASCII.GetBytes("L*#)@!&8"), Encoding.UTF8.GetBytes("JeffHappy"));
        NetworkManager.SessionKey = new byte[128];
    }

    // Token: 0x0600258B RID: 9611 RVA: 0x0042C528 File Offset: 0x0042A728
    static NetworkManager()
    {
        NetworkManager.EnterTheMatrix(NetworkManager.Ivan, 5999, true);
        NetworkManager.SendList.Add(new MessageBuff(4096));
    }

    // Token: 0x0600258C RID: 9612 RVA: 0x0042C5F8 File Offset: 0x0042A7F8
    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Token: 0x0600258D RID: 9613 RVA: 0x0042C608 File Offset: 0x0042A808
    private void Dispose(bool disposing)
    {
        if (this.disposed)
        {
            return;
        }
        if (NetworkManager.socket != null)
        {
            if (NetworkManager.socket.Connected)
            {
                NetworkManager.socket.Shutdown(SocketShutdown.Both);
            }
            NetworkManager.socket.Close();
            NetworkManager.socket = null;
        }
        this.disposed = true;
    }

    // Token: 0x170000FD RID: 253
    // (get) Token: 0x0600258F RID: 9615 RVA: 0x0042C678 File Offset: 0x0042A878
    public static NetworkManager Instance
    {
        get
        {
            if (NetworkManager.instance == null)
            {
                NetworkManager.instance = new NetworkManager();
            }
            return NetworkManager.instance;
        }
    }

    // Token: 0x06002590 RID: 9616 RVA: 0x0042C694 File Offset: 0x0042A894
    public static void Destroy()
    {
        if (NetworkManager.Instance != null)
        {
            NetworkManager.Instance.Dispose();
        }
    }

    // Token: 0x06002592 RID: 9618 RVA: 0x0042C6DC File Offset: 0x0042A8DC
    public static void EnterTheMatrix(string IP, int Port, bool blinklogin = true)
    {
        if (Port == 5999 && GameConstants.IPMan.Length > 1)
        {
            IP = GameConstants.IPMan[UnityEngine.Random.Range(0, GameConstants.IPMan.Length)];
        }
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.ClearString();
        GameConstants.GetHostName(cstring, IP, (!blinklogin) ? "lm-proxy-" : "lm-login-");
        NetworkManager.ServerIP = IP;
        IPAddress[] array = null;
        try
        {
            array = Dns.GetHostAddresses(cstring.ToString());
        }
        catch (Exception ex)
        {
            Debug.Log("[EnterTheMatrix]:" + ex.Message);
        }
        NetworkManager.SendSAEA.RemoteEndPoint = null;
        if (array == null)
        {
            array = new IPAddress[1];
            if (IPAddress.TryParse(IP, out array[0]))
            {
                NetworkManager.ServerIP = array[0].ToString();
                NetworkManager.nowAddressFamily = array[0].AddressFamily;
                NetworkManager.SendSAEA.RemoteEndPoint = new IPEndPoint(array[0], Port);
            }
        }
        else if (array.Length > 0 && array[0] != null)
        {
            NetworkManager.ServerIP = array[0].ToString();
            NetworkManager.nowAddressFamily = array[0].AddressFamily;
            NetworkManager.SendSAEA.RemoteEndPoint = new IPEndPoint(array[0], Port);
        }
        NetworkManager.MatrixReloaded = (NetworkManager.Armageddon = false);
        cstring.ClearString();
    }

    // Token: 0x06002596 RID: 9622 RVA: 0x0042C8B0 File Offset: 0x0042AAB0
    public static void LogmeIn(string IGG, string Asskey)
    {
        NetworkManager.Godspeed = true;
        NetworkManager.UserPass = IGG;
        if (((NetworkManager.LastStage == LoginPhase.LP_Retry || NetworkManager.LastStage == LoginPhase.LP_IGG) && !NetworkManager.OnRecover()) || (!NetworkManager.Connecting && NetworkManager.OnRecover()))
        {
            return;
        }
        if (NetworkManager.Stage != LoginPhase.LP_Disconnect && NetworkManager.Stage != LoginPhase.LP_Fail && NetworkManager.Stage != LoginPhase.LP_OffGrid)
        {
            return;
        }
        if (Asskey != null && long.TryParse(IGG, out NetworkManager.LogID))
        {
            NetworkManager.UDID = Asskey;
            if (Asskey.Length >= 0)
            {
                NetworkManager.Instance.SetStage(LoginPhase.LP_Connecting, NetworkManager.LogID, false);
                return;
            }
        }
        // UpdateController.OnIGGLogin(IGGLoginCode.None);
    }

    // Token: 0x06002597 RID: 9623 RVA: 0x0042C96C File Offset: 0x0042AB6C
    public static void LetmeIn(string Why, byte Not = 0)
    {
        /*
        GameManager.OnRefresh(NetworkNews.Fallout, null);
        GUIManager.Instance.HideUILock(EUILock.All);
        GUIManager.Instance.CloseOKCancelBox();
        NetworkManager.Connecting = false;
        if (NetworkManager.OnRecover())
        {
            NetworkManager.LastStage = LoginPhase.LP_Retry;
            GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(101u), (Not <= 0) ? Why : UpdateController.MessageReturner, 2, DataManager.Instance.mStringTable.GetStringByID(103u), 0, 0, true, false, false, false, false);
        }
        else
        {
            NetworkManager.LastStage = LoginPhase.LP_IGG;
            GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(101u), (Not <= 0) ? Why : UpdateController.MessageReturner, 2, (!NetworkManager.RestInPiss) ? ((NetworkManager.Stage != LoginPhase.LP_EpicFail) ? null : DataManager.Instance.mStringTable.GetStringByID(103u)) : DataManager.Instance.mStringTable.GetStringByID(10062u), 0, 0, true, false, false, false, false);
        }
        */4
    }

    // Token: 0x06002598 RID: 9624 RVA: 0x0042CA7C File Offset: 0x0042AC7C
    public static void Resume(bool Resume)
    {
        if (((NetworkManager.RestInPiss || (!Resume && (NetworkManager.LastStage == LoginPhase.LP_IGG || NetworkManager.LastStage == LoginPhase.LP_Retry))) && !NetworkManager.CallOfDirty) || ((!Resume || GameManager.ActiveGameplay is UpdateController) && NetworkManager.CallOfDirty))
        {
            Application.Quit();
        }
        else if (NetworkManager.Stage == LoginPhase.LP_EpicFail)
        {
            NetworkManager.LastStage = LoginPhase.LP_Pending;
            DataManager.msgBuffer[0] = 1;
            DataManager.msgBuffer[1] = 28;
            GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
        }
        else if (UpdateController.WebClient.FileReady)
        {
            UpdateController.Consent(Resume);
        }
        else if (UpdateController.WebClient.FileError)
        {
            UpdateController.Consent(false);
        }
        else if (UpdateController.WebClient.FileLength > 0L)
        {
            UpdateController.WebClient.Processed = true;
        }
        else if (Resume && !NetworkManager.CallOfDirty)
        {
            NetworkManager.MatrixReloaded = true;
        }
        else
        {
            NetworkManager.MatrixReboot = true;
        }
    }

    // Token: 0x06002599 RID: 9625 RVA: 0x0042CB7C File Offset: 0x0042AD7C
    public static void LockMe(bool On = true)
    {
        GUIManager.Instance.HideUILock(EUILock.Network);
        if (On)
        {
            GUIManager.Instance.ShowUILock(EUILock.Network);
        }
    }

    // Token: 0x0600259A RID: 9626 RVA: 0x0042CB9C File Offset: 0x0042AD9C
    public static void Freeze(bool Frosty)
    {
        if (NetworkManager.Stage != LoginPhase.LP_Auto || !Frosty)
        {
            NetworkManager.Instance.FrozenTime = ((!Frosty) ? 0f : 15f);
        }
    }

    // Token: 0x0600259B RID: 9627 RVA: 0x0042CBD0 File Offset: 0x0042ADD0
    public static void MakeBeat(long time = 15L)
    {
        NetworkManager.ServerTime = (double)DataManager.Instance.ServerTime;
        NetworkManager.PickupTime = Time.realtimeSinceStartup;
        NetworkManager.instance.BeatTime = (float)time;
        NetworkManager.Instance.LinkTime = 0f;
    }

    // Token: 0x0600259C RID: 9628 RVA: 0x0042CC08 File Offset: 0x0042AE08
    public static void HeartBeat()
    {
        NetworkManager.instance.BeatTime = 0f;
        NetworkManager.instance.LinkTime = 10f;
        MessagePacket messagePacket = new MessagePacket(1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVE;
        messagePacket.AddSeqId();
        messagePacket.Send(false);
    }

    // Token: 0x0600259D RID: 9629 RVA: 0x0042CC58 File Offset: 0x0042AE58
    public static void TimeOut()
    {
        if (NetworkManager.LastStage != LoginPhase.LP_Retry && NetworkManager.LastStage != LoginPhase.LP_IGG)
        {
            NetworkManager.MatrixReloaded = true;
        }
    }

    // Token: 0x0600259E RID: 9630 RVA: 0x0042CC78 File Offset: 0x0042AE78
    public static Buffer<byte> RetrieveSize(int len)
    {
        if (len > 4096 - NetworkManager.write_pos)
        {
            return new Buffer<byte>(len);
        }
        Buffer<byte> result = new Buffer<byte>(NetworkManager.SendData, NetworkManager.write_pos, len);
        NetworkManager.write_pos += len;
        return result;
    }

    // Token: 0x0600259F RID: 9631 RVA: 0x0042CCBC File Offset: 0x0042AEBC
    public static bool OnReady()
    {
        return NetworkManager.nowAddressFamily == AddressFamily.InterNetworkV6 || Application.internetReachability != NetworkReachability.NotReachable;
    }

    // Token: 0x060025A0 RID: 9632 RVA: 0x0042CCD8 File Offset: 0x0042AED8
    public static bool Connected()
    {
        return NetworkManager.Stage == LoginPhase.LP_InGame;
    }

    // Token: 0x060025A1 RID: 9633 RVA: 0x0042CCE4 File Offset: 0x0042AEE4
    public static void Send(MessagePacket MP)
    {
        NetworkManager.SendBuff.Enqueue(MP);
    }

    // Token: 0x060025A2 RID: 9634 RVA: 0x0042CCF4 File Offset: 0x0042AEF4
    public static void Cipher(byte[] Codon, int Offset, int Size, int Durex = 0)
    {
        if (NetworkManager.Stage >= LoginPhase.LP_Role && Durex > 0)
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

    // Token: 0x060025A3 RID: 9635 RVA: 0x0042CD98 File Offset: 0x0042AF98
    public static void Reload(bool isPause = true)
    {
        if (NetworkManager.LastStage != LoginPhase.LP_Retry && NetworkManager.LastStage != LoginPhase.LP_IGG && NetworkManager.Stage > LoginPhase.LP_Disconnect && !NetworkManager.Connecting && NetworkManager.Instance.ConnectTime == 0f && !IGGGameSDK.Instance.NotConnect)
        {
            NetworkManager.MatrixReloaded = true;
        }
    }

    // Token: 0x060025A4 RID: 9636 RVA: 0x0042CDFC File Offset: 0x0042AFFC
    public static bool OnContinue()
    {
        return NetworkManager.DieHard || NetworkManager.OnRecover();
    }

    // Token: 0x060025A5 RID: 9637 RVA: 0x0042CE10 File Offset: 0x0042B010
    public static bool OnRecover()
    {
        return (NetworkManager.LastStage == LoginPhase.LP_InGame || NetworkManager.LastStage == LoginPhase.LP_Role || NetworkManager.LastStage == LoginPhase.LP_Retry) && !NetworkManager.CallOfDirty;
    }

    // Token: 0x060025A6 RID: 9638 RVA: 0x0042CE44 File Offset: 0x0042B044
    public static void OnDrop()
    {
        NetworkManager.Instance.SetStage(LoginPhase.LP_OffGrid, 0L, false);
    }

    // Token: 0x060025A7 RID: 9639 RVA: 0x0042CE58 File Offset: 0x0042B058
    public static void Messenger(long Id, byte type = 0)
    {
        NetworkManager.Messenger(DataManager.Instance.mStringTable.GetStringByID((uint)Id), type);
    }

    // Token: 0x060025A8 RID: 9640 RVA: 0x0042CE74 File Offset: 0x0042B074
    public static void Messenger(string Msg, byte type = 0)
    {
        GUIManager.Instance.AddHUDMessage(Msg, (ushort)type, true);
    }

    // Token: 0x060025A9 RID: 9641 RVA: 0x0042CE84 File Offset: 0x0042B084
    public static void Login(MessagePacket Mp)
    {
        NetworkManager.ServerPort = Mp.ReadInt(-1);
        NetworkManager.UserID = Mp.ReadLong(-1);
        NetworkManager.ServerIP = Mp.ReadString(16, -1);
        DataManager.Instance.ServerVersionMajor = Mp.ReadByte(-1);
        DataManager.Instance.ServerVersionMinor = Mp.ReadByte(-1);
        DataManager.Instance.ServerVersionPatch = Mp.ReadUShort(-1);
        DataManager.Instance.ShowTermsOfService = Mp.ReadByte(-1);
        NetworkManager.Disconnect();
        NetworkManager.EnterTheMatrix(NetworkManager.ServerIP, NetworkManager.ServerPort, false);
        if (DataManager.Instance.ShowTermsOfService == 0 || NetworkManager.OnContinue())
        {
            NetworkManager.Instance.SetStage(LoginPhase.LP_Logging, 0L, false);
        }
        else
        {
            UpdateController.OnOpenTermsOfService();
        }
    }

    // Token: 0x060025AA RID: 9642 RVA: 0x0042CF44 File Offset: 0x0042B144
    public void SetStage(LoginPhase Phase, long Kind = 0L, bool Force = false)
    {
        if ((NetworkManager.Stage == Phase && Phase != LoginPhase.LP_Updating) || (Phase == LoginPhase.LP_ReEntry && (AssetManager.Instance.AssetManagerState < AssetState.Run || GameManager.ActiveGameplay == null)))
        {
            return;
        }
        NetworkManager.Stage = Phase;
        switch (NetworkManager.Stage)
        {
            case LoginPhase.LP_Checking:
                this.CheckTime = 5f;
                AssetManager.Instance.AssetManagerState = AssetState.Load;
                long.TryParse(PlayerPrefs.GetString("UserID"), out NetworkManager.UserID);
                break;
            case LoginPhase.LP_Updating:
                this.CheckTime = 5f;
                this.UpdateTime = 15f;
                break;
            case LoginPhase.LP_Preparing:
                this.CheckTime = (this.UpdateTime = 0f);
                break;
            case LoginPhase.LP_Disconnect:
            case LoginPhase.LP_ReConnect:
                this.Refurbishment = this.ReplyConnect;
                NetworkManager.MatrixReloaded = (NetworkManager.CallOfDirty = false);
                this.BeatTime = (this.LinkTime = (this.LockTime = (this.FrozenTime = (this.RetryTime = (float)(NetworkManager.read_pos = (NetworkManager.parse_pos = 0))))));
                if (!Force)
                {
                    NetworkManager.EnterTheMatrix(NetworkManager.Ivan, 5999, true);
                }
                MessagePacket.Clear();
                NetworkManager.Disconnect();
                if (NetworkManager.OnRecover() || NetworkManager.DieHard)
                {
                    UpdateController.OnIGGLogin(false);
                }
                else
                {
                    NetworkManager.LockMe(false);
                    if ((NetworkManager.LastStage == LoginPhase.LP_IGG || NetworkManager.Connecting || this.Refurbishment) && !NetworkManager.MatrixReboot)
                    {
                        UpdateController.OnIGGLogin(false);
                    }
                    else
                    {
                        NetworkManager.LastStage = (NetworkManager.Stage = LoginPhase.LP_Disconnect);
                    }
                }
                break;
            case LoginPhase.LP_Connecting:
                NetworkManager.UserID = Kind;
                this.BeatTime = (this.LinkTime = 0f);
                NetworkManager.Inception = (NetworkManager.DieHard = false);
                NetworkManager.CallOfDirty = (NetworkManager.Connecting = false);
                if (NetworkManager.OnReady())
                {
                    NetworkManager.ConnectEx();
                }
                else
                {
                    this.SetStage(LoginPhase.LP_Fail, 31L, false);
                }
                break;
            case LoginPhase.LP_Connected:
                {
                    this.ConnectTime = 15f;
                    this.ReplyConnect = false;
                    MessagePacket messagePacket = new MessagePacket(1024);
                    messagePacket.Protocol = Protocol._MSG_LOGIN_LOGINTOL;
                    messagePacket.Add(NetworkManager.UserID);
                    messagePacket.Add((byte)GameConstants.Version[1]);
                    messagePacket.Add((byte)GameConstants.Version[0]);
                    messagePacket.Add(GameConstants.Version[2]);
                    messagePacket.Add((byte)NetworkManager.UDID.Length);
                    messagePacket.Add(NetworkManager.UDID, NetworkManager.SessionKey.Length);
                    messagePacket.Add(3);
                    File.Delete(AssetManager.persistentDataPath + Path.AltDirectorySeparatorChar + "Download.apk");
                    messagePacket.Add((byte)DataManager.Instance.UserLanguage);
                    messagePacket.Send(true);
                    break;
                }
            case LoginPhase.LP_ReEntry:
                Application.Quit();
                this.SetStage(LoginPhase.LP_Fallout, 0L, false);
                this.SetStage(LoginPhase.LP_Disconnect, 0L, false);
                Camera.main.backgroundColor = Color.clear;
                GameManager.SwitchGameplay(GameplayKind.Update);
                NetworkManager.MatrixReloaded = (NetworkManager.MatrixReboot = (NetworkManager.RestInPiss = false));
                break;
            case LoginPhase.LP_Logging:
                {
                    NetworkManager.ConnectEx();
                    MessagePacket messagePacket2 = new MessagePacket(1024);
                    messagePacket2.Protocol = Protocol._MSG_LOGIN_LOGINTOP;
                    messagePacket2.Add(NetworkManager.UserID);
                    messagePacket2.Add(NetworkManager.Version);
                    messagePacket2.Add((DataManager.Instance.BattleSeqID == 0UL) ? 0 : 1);
                    messagePacket2.Add(DataManager.Instance.bRecvKingdom);
                    messagePacket2.Add((byte)NetworkManager.UDID.Length);
                    messagePacket2.Add(NetworkManager.UDID, NetworkManager.SessionKey.Length);
                    messagePacket2.Add(SocialManager.Instance.InviterIGGId);
                    messagePacket2.Add(SocialManager.Instance.InviterName, 41);
                    messagePacket2.Add((byte)Kind);
                    messagePacket2.Send(true);
                    break;
                }
            case LoginPhase.LP_Login:
                if (Kind == 0L)
                {
                    this.SetStage(LoginPhase.LP_Role, 0L, false);
                }
                else if (Kind == 8L)
                {
                    this.SetStage(LoginPhase.LP_KickAss, 0L, false);
                }
                else
                {
                    NetworkManager.RestInPiss = (NetworkManager.CallOfDirty = (Kind == 110L));
                    if (Kind == 9L || Kind == 14L)
                    {
                        this.SetStage(LoginPhase.LP_KissAss, (Kind != 9L) ? 999L : 109L, true);
                    }
                    else
                    {
                        this.SetStage(LoginPhase.LP_Fail, 100L + Kind, false);
                    }
                }
                break;
            case LoginPhase.LP_Logon:
                if (NetworkManager.OnRecover())
                {
                    NetworkManager.Stage = LoginPhase.LP_Disconnect;
                }
                else
                {
                    NetworkManager.LastStage = (NetworkManager.Stage = LoginPhase.LP_Disconnect);
                }
                NetworkManager.LockMe(true);
                NetworkManager.Connecting = true;
                UpdateController.OnIGGLogin(true);
                break;
            case LoginPhase.LP_Role:
                NetworkManager.CheckRole();
                break;
            case LoginPhase.LP_Auto:
                NetworkManager.AutoLogin = true;
                this.ReplyConnect = false;
                if (NetworkManager.OnReady() || Kind > 0L || Force)
                {
                    NetworkManager.LockMe(true);
                    NetworkManager.Connecting = true;
                    if (NetworkManager.OnRecover())
                    {
                        NetworkManager.Stage = LoginPhase.LP_Disconnect;
                    }
                    else
                    {
                        NetworkManager.LastStage = (NetworkManager.Stage = LoginPhase.LP_Disconnect);
                    }
                }
                else
                {
                    this.SetStage(LoginPhase.LP_Fail, 31L, false);
                }
                break;
            case LoginPhase.LP_BBS:
                NetworkManager.Connecting = false;
                NetworkManager.LastStage = LoginPhase.LP_Fail;
                GUIManager.Instance.CloseOKCancelBox();
                this.SetStage(LoginPhase.LP_Disconnect, 0L, Force);
                break;
            case LoginPhase.LP_GG:
                NetworkManager.LastStage = NetworkManager.Stage;
                NetworkManager.RestInPiss = Force;
                this.ConnectTime = (this.FrozenTime = (this.LinkTime = (this.LockTime = (this.BeatTime = (this.RetryTime = 0f)))));
                NetworkManager.EnterTheMatrix(NetworkManager.Ivan, 5999, true);
                NetworkManager.Disconnect();
                NetworkManager.LetmeIn(string.Format(DataManager.Instance.mStringTable.GetStringByID(10056u), Kind), 0);
                break;
            case LoginPhase.LP_InGame:
                NetworkManager.SendOK();
                this.ConnectTime = (float)(NetworkManager.JudgmentDay = 0L);
                PlayerPrefs.SetInt("Inception", 0);
                PlayerPrefs.SetString("UserID", NetworkManager.UserID.ToString());
                DataManager.StageDataController.CheckFirstInChapter();
                if (DataManager.Instance.RoleAttr.BattleID != DataManager.Instance.BattleSeqID)
                {
                    GameManager.OnRefresh(NetworkNews.Refresh_BattleFail, null);
                }
                if (NetworkManager.OnRecover())
                {
                    GUIManager.Instance.HideUILock(EUILock.All);
                    GameManager.OnRefresh(NetworkNews.Login, null);
                }
                else
                {
                    GameManager.OnLogin();
                }
                NetworkManager.LastStage = NetworkManager.Stage;
                break;
            case LoginPhase.LP_OnLine:
                NetworkManager.Inception = true;
                this.ConnectTime = 0f;
                NetworkManager.SendOK();
                break;
            case LoginPhase.LP_OffGrid:
                this.BeatTime = (this.LinkTime = (this.LockTime = (this.FrozenTime = (this.RetryTime = 0f))));
                NetworkManager.EnterTheMatrix(NetworkManager.Ivan, 5999, true);
                NetworkManager.Disconnect();
                this.ConnectTime = (this.BeatTime = 0f);
                if (NetworkManager.DieHard)
                {
                    NetworkManager.MatrixReloaded = true;
                }
                else if (Kind == 0L && !Force)
                {
                    NetworkManager.LetmeIn(string.Format("{0}: {1}{2}{3}", new object[]
                    {
                    DataManager.Instance.mStringTable.GetStringByID(108u),
                    NetworkManager.ServerPort,
                    (NetworkManager.Sequence <= NetworkManager.ServerPort) ? ((NetworkManager.Sequence != NetworkManager.ServerPort) ? 1 : 0) : 0,
                    (!NetworkManager.Bizarre) ? 0 : 1
                    }), 0);
                }
                else
                {
                    NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID((uint)((!Force) ? 108L : ((Kind <= 0L) ? 109L : Kind))), (Force && Kind <= 0L) ? 1 : 0);
                }
                break;
            case LoginPhase.LP_KickAss:
                NetworkManager.MatrixReloaded = true;
                NetworkManager.DieHard = true;
                break;
            case LoginPhase.LP_KissAss:
                NetworkManager.CallOfDirty = !Force;
                NetworkManager.RestInPiss = Force;
                NetworkManager.LastStage = NetworkManager.Stage;
                this.SetStage(LoginPhase.LP_OffGrid, Kind, true);
                break;
            case LoginPhase.LP_Fallout:
                if (Kind > 0L)
                {
                    GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(103u), DataManager.Instance.mStringTable.GetStringByID(826u), null, null, 0, 0, false, false, false, false, false);
                }
                if (NetworkManager.LastStage != LoginPhase.LP_IGG)
                {
                    NetworkManager.LastStage = LoginPhase.LP_Fail;
                }
                break;
            case LoginPhase.LP_EpicFail:
                this.UpdateTime = 0f;
                DataManager.msgBuffer[0] = 1;
                DataManager.msgBuffer[1] = 27;
                DataManager.msgBuffer[2] = (byte)Kind;
                GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
                if (Force)
                {
                    NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(8474u), 0);
                }
                break;
            case LoginPhase.LP_Fatal:
                this.SetStage(LoginPhase.LP_Fail, 10055L, Force);
                break;
            case LoginPhase.LP_Fail:
                NetworkManager.EnterTheMatrix(NetworkManager.Ivan, 5999, true);
                NetworkManager.Disconnect();
                this.ConnectTime = (this.BeatTime = 0f);
                if (Kind > 10000L)
                {
                    NetworkManager.LetmeIn(string.Format("{0}: {1}{2}{3}{4}", new object[]
                    {
                    DataManager.Instance.mStringTable.GetStringByID((uint)Kind),
                    (!Force) ? 2 : 1,
                    (!NetworkManager.Ragnarok) ? ((NetworkManager.Sequence <= NetworkManager.ServerPort) ? 1 : 0) : 2,
                    (!NetworkManager.Ragnarok) ? 0 : ((NetworkManager.Sequence <= NetworkManager.ServerPort) ? 1 : 0),
                    (!NetworkManager.Bizarre) ? 0 : 1
                    }), 0);
                }
                else if (Kind > 200L)
                {
                    NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(((long)UpdateController.UpdateFallback != (Kind -= 100L)) ? ((uint)Kind) : 8474u), 0);
                }
                else if (Kind >= 100L || (Force && Kind > 1L))
                {
                    NetworkManager.JudgmentDay = Kind;
                    if (Kind == 106L)
                    {
                        NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(57u), 0);
                    }
                    else if (Kind == 102L)
                    {
                        NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(912u), 0);
                    }
                    else if (Kind == 113L)
                    {
                        NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(998u), 0);
                    }
                    else if (Kind == 103L)
                    {
                        NetworkManager.LetmeIn(string.Format(DataManager.Instance.mStringTable.GetStringByID(10058u), Kind -= 100L, DataManager.Instance.mStringTable.GetStringByID(10054u)), 0);
                    }
                    else if (Kind == 115L)
                    {
                        NetworkManager.LetmeIn(string.Format(DataManager.Instance.mStringTable.GetStringByID(10058u), Kind -= 100L, DataManager.Instance.mStringTable.GetStringByID(10053u)), 0);
                    }
                    else if (Kind == 110L)
                    {
                        NetworkManager.LetmeIn(string.Format(DataManager.Instance.mStringTable.GetStringByID(10058u), Kind -= 100L, DataManager.Instance.mStringTable.GetStringByID(10052u)), 0);
                    }
                    else
                    {
                        NetworkManager.LetmeIn(string.Format(DataManager.Instance.mStringTable.GetStringByID(10056u), Kind -= 100L), 0);
                    }
                }
                else if (Kind > 10L)
                {
                    NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(102u), 0);
                }
                else if (Kind > 1L)
                {
                    NetworkManager.LetmeIn(this.BlackHawkDown[0], 1);
                }
                else if (Kind == 1L && NetworkManager.JudgmentDay == 113L)
                {
                    NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(998u), 0);
                }
                else if (Kind > 0L || !NetworkManager.OnRecover())
                {
                    NetworkManager.LetmeIn(string.Format("{0}: {1}{2}{3}{4}", new object[]
                    {
                    DataManager.Instance.mStringTable.GetStringByID(107u),
                    NetworkManager.ServerPort,
                    (!Force) ? ((NetworkManager.Sequence <= NetworkManager.ServerPort) ? 1 : 0) : 2,
                    (NetworkManager.Sequence <= NetworkManager.ServerPort) ? ((NetworkManager.Sequence != NetworkManager.ServerPort) ? 1 : 0) : 0,
                    (!NetworkManager.Bizarre) ? 0 : 1
                    }), 0);
                }
                else
                {
                    NetworkManager.MatrixReboot = true;
                }
                break;
            case LoginPhase.LP_Lost:
                if (!NetworkManager.CallOfDirty)
                {
                    this.SetStage(LoginPhase.LP_Login, 110L, false);
                }
                break;
        }
    }

    // Token: 0x060025AB RID: 9643 RVA: 0x0042DC94 File Offset: 0x0042BE94
    public static void SendName(string name)
    {
        ushort data = 0;
        byte data2 = 1;
        NetworkManager.UserName = "南港隊長Sucks";
        MessagePacket messagePacket = new MessagePacket(1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_CREATEROLE;
        messagePacket.AddSeqId();
        messagePacket.Add(NetworkManager.UserID);
        messagePacket.Add(NetworkManager.UserName, 13);
        messagePacket.Add(data);
        messagePacket.Add(data2);
        messagePacket.Send(false);
    }

    // Token: 0x060025AC RID: 9644 RVA: 0x0042DCFC File Offset: 0x0042BEFC
    public static void SendOK()
    {
        NetworkManager.instance.LinkTime = 0f;
        NetworkManager.instance.BeatTime = 15f;
        long serverTime = DataManager.Instance.RoleAttr.ServerTime;
        DataManager.Instance.ServerTime = serverTime;
        NetworkManager.ServerTime = (double)serverTime;
        NetworkManager.PickupTime = Time.realtimeSinceStartup;
        MessagePacket messagePacket = new MessagePacket(1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_CLIENTINITOVER;
        messagePacket.AddSeqId();
        messagePacket.Add(NetworkManager.UserID);
        messagePacket.Send(false);
    }

    // Token: 0x060025AD RID: 9645 RVA: 0x0042DD84 File Offset: 0x0042BF84
    public static void CheckRole()
    {
        MessagePacket messagePacket = new MessagePacket(1024);
        messagePacket.AddSeqId();
        messagePacket.Add(NetworkManager.UserID);
        messagePacket.Add((DataManager.Instance.BattleSeqID == 0UL) ? 0 : 1);
        messagePacket.Send(false);
    }

    // Token: 0x060025AE RID: 9646 RVA: 0x0042DDD4 File Offset: 0x0042BFD4
    public static void ConnectEx()
    {
        try
        {
            NetworkManager.LockMe(true);
            if (NetworkManager.socket != null)
            {
                NetworkManager.Disconnect();
            }
            NetworkManager.Instance.ConnectTime = (float)(NetworkManager.Sequence = 15);
            NetworkManager.Bizarre = NetworkManager.ServerIP.Equals("69.25.100.20");
            NetworkManager.ServerPort = ((NetworkManager.Stage != LoginPhase.LP_Connecting) ? 2 : 1);
            if (NetworkManager.SendSAEA.RemoteEndPoint == null)
            {
                NetworkManager.Armageddon = (NetworkManager.Ragnarok = true);
            }
            else
            {
                NetworkManager.Ragnarok = false;
                NetworkManager.socket = new Socket(NetworkManager.nowAddressFamily, SocketType.Stream, ProtocolType.Tcp)
                {
                    Blocking = false,
                    SendTimeout = 0,
                    ReceiveTimeout = 0
                };
                try
                {
                    NetworkManager.socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.Debug, true);
                    NetworkManager.socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, NetworkManager.LOL);
                }
                catch
                {
                }
                finally
                {
                    if (NetworkManager.socket.BeginConnect(NetworkManager.SendSAEA.RemoteEndPoint, new AsyncCallback(NetworkManager.ConnectCallback), NetworkManager.socket).CompletedSynchronously)
                    {
                        NetworkManager.ConnectCallback(null);
                    }
                }
            }
        }
        catch
        {
            NetworkManager.Armageddon = (NetworkManager.Ragnarok = true);
        }
    }

    // Token: 0x060025AF RID: 9647 RVA: 0x0042DF4C File Offset: 0x0042C14C
    private static void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            if (!NetworkManager.Armageddon && ar != null && NetworkManager.socket != null && NetworkManager.socket.Handle.ToInt32() != -1 && (Socket)ar.AsyncState == NetworkManager.socket)
            {
                NetworkManager.Instance.ConnectTime = (float)(NetworkManager.Sequence = 0);
                if (((Socket)ar.AsyncState).Connected)
                {
                    if (NetworkManager.Stage != LoginPhase.LP_Logging)
                    {
                        NetworkManager.Instance.ReplyConnect = true;
                    }
                    else
                    {
                        NetworkManager.Instance.ConnectTime = 15f;
                    }
                    try
                    {
                        NetworkManager.socket.EndConnect(ar);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    if (NetworkManager.Armageddon)
                    {
                        if (ar == null)
                        {
                            goto IL_EC;
                        }
                    }
                    try
                    {
                        if (ar != null)
                        {
                            NetworkManager.socket.EndConnect(ar);
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        NetworkManager.LostInSpace = true;
                    }
                }
            IL_EC:;
            }
        }
        catch
        {
            NetworkManager.Armageddon = true;
        }
    }

    // Token: 0x060025B0 RID: 9648 RVA: 0x0042E0BC File Offset: 0x0042C2BC
    public static void SendSocket(MessagePacket pak)
    {
        if (NetworkPeeper.Stage < LoginPhase.LP_Connected || pak == null)
        {
            return;
        }
        if (pak.Length > pak.Offset)
        {
            pak.Offset += NetworkPeeper.Sucket.Send(pak.Data.GetBuffer(), pak.Data.GetIndex(pak.Offset), pak.Length - pak.Offset, SocketFlags.None, out NetworkManager.SucketError);
            if (pak.Length <= pak.Offset)
            {
                NetworkPeeper.SendBuff.Dequeue();
                NetworkManager.Cleansing();
            }
        }
    }

    // Token: 0x060025B1 RID: 9649 RVA: 0x0042E154 File Offset: 0x0042C354
    public static void Cleansing()
    {
        if (NetworkPeeper.SendBuff.Count == 0 && NetworkManager.SendBuff.Count == 0)
        {
            NetworkManager.write_pos = 0;
        }
    }

    // Token: 0x060025B2 RID: 9650 RVA: 0x0042E188 File Offset: 0x0042C388
    public static void Disconnect()
    {
        NetworkManager.Instance.ConnectTime = 0f;
        NetworkManager.write_pos = 0;
        if (NetworkManager.socket != null)
        {
            NetworkManager.socket.Close();
            NetworkManager.socket = null;
        }
        NetworkManager.Instance.ReplyConnect = (NetworkManager.Sending = false);
        NetworkManager.LostInSpace = (NetworkManager.Armageddon = false);
        NetworkManager.SendBuff.Clear();
        MessagePacket.Clear();
        NetworkManager.Stage = LoginPhase.LP_Disconnect;
    }

    // Token: 0x060025B3 RID: 9651 RVA: 0x0042E204 File Offset: 0x0042C404
    public static void SendPacket(MessagePacket pak)
    {
        if (NetworkManager.Stage < LoginPhase.LP_Connected || pak == null)
        {
            return;
        }
        if (pak.Length > pak.Offset)
        {
            NetworkManager.Sending = true;
            SocketError socketError;
            pak.Offset += NetworkManager.socket.Send(pak.Data.GetBuffer(), pak.Data.GetIndex(pak.Offset), pak.Length - pak.Offset, SocketFlags.None, out socketError);
            if (pak.Length <= pak.Offset)
            {
                if (pak.Protocol == Protocol._MSG_LOGIN_LOGINTOL || pak.Protocol == Protocol._MSG_LOGIN_LOGINTOP)
                {
                    NetworkManager.Sequence = NetworkManager.ServerPort;
                }
                NetworkManager.SendBuff.Dequeue();
                if (NetworkPeeper.SendBuff.Count == 0 && NetworkManager.SendBuff.Count == 0)
                {
                    NetworkManager.write_pos = 0;
                }
                NetworkManager.Sending = false;
            }
        }
        else
        {
            NetworkManager.Sending = false;
        }
    }

    // Token: 0x060025B4 RID: 9652 RVA: 0x0042E300 File Offset: 0x0042C500
    public static void CheckBuffer()
    {
        try
        {
            if (NetworkManager.socket != null && NetworkManager.socket.Connected)
            {
                if (NetworkManager.socket.Poll(0, SelectMode.SelectWrite) && NetworkManager.SendBuff.Count > 0)
                {
                    NetworkManager.SendPacket((MessagePacket)NetworkManager.SendBuff.Peek());
                }
                while (NetworkManager.socket != null && NetworkManager.socket.Poll(0, SelectMode.SelectRead))
                {
                    if (NetworkManager.read_pos >= 4096)
                    {
                        if (NetworkManager.parse_pos > 0)
                        {
                            Buffer.BlockCopy(NetworkManager.ReadData, NetworkManager.parse_pos, NetworkManager.ReadData, 0, NetworkManager.read_pos -= NetworkManager.parse_pos);
                        }
                        else
                        {
                            NetworkManager.Resume(true);
                        }
                        NetworkManager.parse_pos = 0;
                        break;
                    }
                    SocketError socketError;
                    int num = NetworkManager.socket.Receive(NetworkManager.ReadData, NetworkManager.read_pos, NetworkManager.ReadData.Length - NetworkManager.read_pos, SocketFlags.None, out socketError);
                    if (num == 0)
                    {
                        NetworkManager.OnDrop();
                        break;
                    }
                    if (NetworkManager.read_pos + num > 4096)
                    {
                        break;
                    }
                    NetworkManager.read_pos += num;
                    while (NetworkManager.read_pos - NetworkManager.parse_pos >= 4)
                    {
                        ushort num2 = GameConstants.ConvertBytesToUShort(NetworkManager.ReadData, NetworkManager.parse_pos);
                        if (num2 < 4 || num2 > 4096)
                        {
                            NetworkManager.parse_pos += 4;
                        }
                        else
                        {
                            if ((int)num2 > NetworkManager.read_pos - NetworkManager.parse_pos)
                            {
                                break;
                            }
                            MessagePacket messagePacket = new MessagePacket(ref NetworkManager.ReadData, NetworkManager.parse_pos + 4, (int)(num2 - 4));
                            messagePacket.Protocol = (Protocol)GameConstants.ConvertBytesToUShort(NetworkManager.ReadData, NetworkManager.parse_pos + 2);
                            NetworkManager.Cipher(NetworkManager.ReadData, messagePacket.Data.GetIndex(0), messagePacket.Length, 0);
                            NetworkManager.parse_pos += (int)num2;
                            DispatchManager.Dispatcher(messagePacket);
                        }
                    }
                    if (NetworkManager.parse_pos > 0)
                    {
                        Buffer.BlockCopy(NetworkManager.ReadData, NetworkManager.parse_pos, NetworkManager.ReadData, 0, NetworkManager.read_pos -= NetworkManager.parse_pos);
                    }
                    NetworkManager.parse_pos = 0;
                }
            }
        }
        catch
        {
            NetworkManager.parse_pos = (NetworkManager.read_pos = 0);
        }
    }

    // Token: 0x060025B5 RID: 9653 RVA: 0x0042E55C File Offset: 0x0042C75C
    private static void ProcessSend(SocketAsyncEventArgs e)
    {
        MessagePacket messagePacket = e.UserToken as MessagePacket;
        messagePacket.Offset += e.BytesTransferred;
        if (messagePacket.Length > messagePacket.Offset)
        {
            NetworkManager.SendPacket(messagePacket);
        }
        else
        {
            NetworkManager.SendBuff.Dequeue();
            NetworkManager.Sending = false;
            NetworkManager.CheckBuffer();
        }
    }

    // Token: 0x060025B6 RID: 9654 RVA: 0x0042E5BC File Offset: 0x0042C7BC
    private static void ProcessReceive(SocketAsyncEventArgs e)
    {
        if (e.BytesTransferred > 0)
        {
            if (NetworkManager.read_pos + e.BytesTransferred <= 4096)
            {
                Buffer.BlockCopy(e.Buffer, 0, NetworkManager.ReadData, NetworkManager.read_pos, e.BytesTransferred);
                int num = (int)GameConstants.ConvertBytesToUShort(NetworkManager.ReadData, NetworkManager.parse_pos);
                NetworkManager.read_pos += e.BytesTransferred;
                if (num <= NetworkManager.read_pos - NetworkManager.parse_pos)
                {
                    NetworkManager.parse_pos += num;
                }
                if (!NetworkManager.socket.ReceiveAsync(e))
                {
                    NetworkManager.ProcessReceive(e);
                }
            }
        }
    }

    // Token: 0x060025B7 RID: 9655 RVA: 0x0042E660 File Offset: 0x0042C860
    private static void IO_Completed(object sender, SocketAsyncEventArgs e)
    {
        switch (e.LastOperation)
        {
            case SocketAsyncOperation.Receive:
                if (e.SocketError == SocketError.Success)
                {
                    NetworkManager.ProcessReceive(e);
                }
                break;
            case SocketAsyncOperation.Send:
                if (e.SocketError == SocketError.Success)
                {
                    NetworkManager.ProcessSend(e);
                }
                break;
        }
    }

    // Token: 0x060025B8 RID: 9656 RVA: 0x0042E6C0 File Offset: 0x0042C8C0
    public void Update()
    {
        NetworkManager.DeltaTime = -NetworkManager.RealTime + (NetworkManager.RealTime = Time.realtimeSinceStartup);
        if (NetworkManager.ServerTime > 0.0)
        {
            NetworkManager.ServerTime += (double)NetworkManager.DeltaTime;
            if ((NetworkManager.SynchTime = NetworkManager.RealTime - NetworkManager.PickupTime) >= 1f)
            {
                DataManager.Instance.ServerTime = (long)NetworkManager.ServerTime;
                NetworkManager.PickupTime = NetworkManager.RealTime;
            }
        }
        DownloadController.Check();
        DataManager.Instance.Update();
        if (NetworkManager.MatrixReboot)
        {
            this.SetStage(LoginPhase.LP_ReEntry, 0L, false);
        }
        else if ((NetworkManager.MatrixReloaded || (NetworkManager.Connected() && this.LockTime > 0f && (this.LockTime -= NetworkManager.DeltaTime) <= 0f) || (this.LinkTime > 0f && (this.LinkTime -= NetworkManager.DeltaTime) <= 0f) || (NetworkManager.Connected() && this.FrozenTime > 0f && (this.FrozenTime -= NetworkManager.DeltaTime) <= 0f)) && !IGGGameSDK.Instance.NotConnect)
        {
            this.SetStage(LoginPhase.LP_ReConnect, 0L, false);
        }
        else if (this.ReplyConnect)
        {
            this.SetStage(LoginPhase.LP_Connected, 0L, false);
        }
        else
        {
            if (this.BeatTime > 0f && (this.BeatTime -= NetworkManager.DeltaTime) <= 0f && !IGGGameSDK.Instance.NotConnect)
            {
                NetworkManager.HeartBeat();
            }
            else if (NetworkManager.Connecting && ((this.LockTime > 0f && (this.LockTime -= NetworkManager.DeltaTime) <= 0f) || (this.FrozenTime > 0f && (this.FrozenTime -= NetworkManager.DeltaTime) <= 0f)) && !IGGGameSDK.Instance.NotConnect)
            {
                this.SetStage(LoginPhase.LP_GG, 0L, false);
            }
            else if (NetworkManager.LostInSpace || (this.ConnectTime > 0f && (this.ConnectTime -= NetworkManager.DeltaTime) <= 0f))
            {
                this.SetStage(LoginPhase.LP_Fail, 1L, NetworkManager.LostInSpace);
            }
            else if (NetworkManager.Armageddon)
            {
                this.SetStage(LoginPhase.LP_Fatal, 0L, NetworkManager.Stage == LoginPhase.LP_Connecting);
            }
            if (this.CheckTime > 0f)
            {
                this.CheckTime -= NetworkManager.DeltaTime;
            }
            if (this.CheckTime < 0f)
            {
                this.CheckTime = 0f;
            }
            if (this.UpdateTime > 0f && (this.UpdateTime -= NetworkManager.DeltaTime) <= 0f)
            {
                this.SetStage(LoginPhase.LP_EpicFail, 0L, false);
            }
            else if (this.RequestTime > 0f && (this.RequestTime -= NetworkManager.DeltaTime) <= 0f)
            {
                DownloadController.Fallback();
            }
            NetworkManager.CheckBuffer();
        }
    }

    // Token: 0x060025B9 RID: 9657 RVA: 0x0042EA38 File Offset: 0x0042CC38
    public static void Peeping(MessagePacket Mp)
    {
        switch (Mp.ReadByte(-1))
        {
            case 0:
                NetworkManager.guest.Enter(Mp);
                return;
            case 1:
                NetworkManager.guest.Resume(true);
                return;
            case 2:
                GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(103u), DataManager.Instance.mStringTable.GetStringByID(911u), null, null, 0, 0, false, false, false, false, false);
                break;
            default:
                GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(103u), string.Format(DataManager.Instance.mStringTable.GetStringByID(10183u), Mp.Data[0]), null, null, 0, 0, false, false, false, false, false);
                break;
        }
        NetworkManager.guest.Drop(false);
        GameManager.OnRefresh(NetworkNews.GuestConnectFail, null);
    }

    // Token: 0x060025BA RID: 9658 RVA: 0x0042EB20 File Offset: 0x0042CD20
    public bool ViewKingdom(ushort KingdomId)
    {
        return NetworkManager.guest.View(KingdomId, false);
    }

    // Token: 0x060025BB RID: 9659 RVA: 0x0042EB30 File Offset: 0x0042CD30
    public void ViewClose()
    {
        NetworkManager.guest.Drop(false);
    }

    // Token: 0x0400701D RID: 28701
    public const int Ivanhole = 5999;

    // Token: 0x0400701E RID: 28702
    public const int VALIDATECODE = 25;

    // Token: 0x0400701F RID: 28703
    public const byte TTL = 15;

    // Token: 0x04007020 RID: 28704
    public const ushort SOCKET_BUFFER = 4096;

    // Token: 0x04007021 RID: 28705
    protected string[] BlackHawkDown = new string[]
    {
        "GameServer Down",
        "ProxyServer Down",
        "ProxyServer Drop",
        "KingdomServer Down",
        "DbServer Down",
        "Network Down",
        "Server Drop",
        "Servo Error"
    };

    // Token: 0x04007022 RID: 28706
    public static string Ivan = GameConstants.IPMan[0];

    // Token: 0x04007023 RID: 28707
    public static byte[] SessionKey;

    // Token: 0x04007024 RID: 28708
    public static ICryptoTransform DES;

    // Token: 0x04007025 RID: 28709
    private static NetworkPeeper guest = null;

    // Token: 0x04007026 RID: 28710
    private static NetworkManager instance = null;

    // Token: 0x04007027 RID: 28711
    public static string UserName;

    // Token: 0x04007028 RID: 28712
    public static string UserPass;

    // Token: 0x04007029 RID: 28713
    public static string AccountName;

    // Token: 0x0400702A RID: 28714
    public static string AccountPass;

    // Token: 0x0400702B RID: 28715
    public static string UDID;

    // Token: 0x0400702C RID: 28716
    public static double ServerTime;

    // Token: 0x0400702D RID: 28717
    public static float PickupTime;

    // Token: 0x0400702E RID: 28718
    public static float SynchTime;

    // Token: 0x0400702F RID: 28719
    public static float DeltaTime;

    // Token: 0x04007030 RID: 28720
    public static float RealTime;

    // Token: 0x04007031 RID: 28721
    public float BeatTime;

    // Token: 0x04007032 RID: 28722
    public float LinkTime;

    // Token: 0x04007033 RID: 28723
    public float LockTime;

    // Token: 0x04007034 RID: 28724
    public float RetryTime;

    // Token: 0x04007035 RID: 28725
    public float ReloadTime;

    // Token: 0x04007036 RID: 28726
    public float FrozenTime;

    // Token: 0x04007037 RID: 28727
    public float CheckTime;

    // Token: 0x04007038 RID: 28728
    public float UpdateTime;

    // Token: 0x04007039 RID: 28729
    public float RequestTime;

    // Token: 0x0400703A RID: 28730
    public float ConnectTime;

    // Token: 0x0400703B RID: 28731
    private bool ReplyConnect;

    // Token: 0x0400703C RID: 28732
    public bool Refurbishment;

    // Token: 0x0400703D RID: 28733
    private static Socket socket;

    // Token: 0x0400703E RID: 28734
    private bool disposed;

    // Token: 0x0400703F RID: 28735
    private static LoginPhase Stage;

    // Token: 0x04007040 RID: 28736
    public static LoginPhase LastStage;

    // Token: 0x04007041 RID: 28737
    private static UpdateController Updater;

    // Token: 0x04007042 RID: 28738
    public static Queue SendBuff = new Queue();

    // Token: 0x04007043 RID: 28739
    public static Queue RecvBuff = new Queue();

    // Token: 0x04007044 RID: 28740
    public static bool Sending = false;

    // Token: 0x04007045 RID: 28741
    public static bool Receive = false;

    // Token: 0x04007046 RID: 28742
    public static bool Recving = false;

    // Token: 0x04007047 RID: 28743
    public static List<MessageBuff> SendList = new List<MessageBuff>(1);

    // Token: 0x04007048 RID: 28744
    public static byte[] ReadData = new byte[4096];

    // Token: 0x04007049 RID: 28745
    public static byte[] SendData = new byte[4096];

    // Token: 0x0400704A RID: 28746
    public static int read_pos;

    // Token: 0x0400704B RID: 28747
    public static int parse_pos;

    // Token: 0x0400704C RID: 28748
    public static int write_pos;

    // Token: 0x0400704D RID: 28749
    private static long JudgmentDay;

    // Token: 0x0400704E RID: 28750
    private static bool Armageddon;

    // Token: 0x0400704F RID: 28751
    private static bool Bizarre;

    // Token: 0x04007050 RID: 28752
    private static bool DieHard;

    // Token: 0x04007051 RID: 28753
    private static bool Ragnarok;

    // Token: 0x04007052 RID: 28754
    private static bool Godspeed;

    // Token: 0x04007053 RID: 28755
    private static bool Inception;

    // Token: 0x04007054 RID: 28756
    private static bool Connecting;

    // Token: 0x04007055 RID: 28757
    private static bool CallOfDirty;

    // Token: 0x04007056 RID: 28758
    private static bool RestInPiss = false;

    // Token: 0x04007057 RID: 28759
    private static bool LostInSpace;

    // Token: 0x04007058 RID: 28760
    private static bool MatrixReboot;

    // Token: 0x04007059 RID: 28761
    private static bool MatrixReloaded;

    // Token: 0x0400705A RID: 28762
    private static string ServerIP;

    // Token: 0x0400705B RID: 28763
    private static int ServerPort;

    // Token: 0x0400705C RID: 28764
    public static byte ServerNum;

    // Token: 0x0400705D RID: 28765
    public static string[] RoyalHost;

    // Token: 0x0400705E RID: 28766
    public static byte[] Veronica = new byte[25];

    // Token: 0x0400705F RID: 28767
    public static uint Version;

    // Token: 0x04007060 RID: 28768
    public static long UserID;

    // Token: 0x04007061 RID: 28769
    public static long LogID;

    // Token: 0x04007062 RID: 28770
    public static long PlayerID;

    // Token: 0x04007063 RID: 28771
    public static uint ServerID;

    // Token: 0x04007064 RID: 28772
    public static int Sequence;

    // Token: 0x04007065 RID: 28773
    public static string IP;

    // Token: 0x04007066 RID: 28774
    public static IPEndPoint EndPoint;

    // Token: 0x04007067 RID: 28775
    public static SocketError SucketError;

    // Token: 0x04007068 RID: 28776
    public static LingerOption LOL = new LingerOption(false, 0);

    // Token: 0x04007069 RID: 28777
    public static SocketAsyncEventArgs SendSAEA = new SocketAsyncEventArgs();

    // Token: 0x0400706A RID: 28778
    public static DESCryptoServiceProvider Crypto = new DESCryptoServiceProvider();

    // Token: 0x0400706B RID: 28779
    public static AddressFamily nowAddressFamily = AddressFamily.InterNetwork;

    // Token: 0x0400706C RID: 28780
    public static bool AutoLogin;

    // Token: 0x0200077F RID: 1919
    public class PBuffer
    {
        // Token: 0x0400706D RID: 28781
        public byte[] Data = new byte[4096];

        // Token: 0x0400706E RID: 28782
        public int read;
    }
}
