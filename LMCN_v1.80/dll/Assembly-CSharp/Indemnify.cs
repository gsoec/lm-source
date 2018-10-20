using System;
using UnityEngine;

// Token: 0x02000376 RID: 886
public class Indemnify
{
	// Token: 0x1700008C RID: 140
	// (get) Token: 0x0600127D RID: 4733 RVA: 0x002096E4 File Offset: 0x002078E4
	// (set) Token: 0x0600127C RID: 4732 RVA: 0x002096CC File Offset: 0x002078CC
	public static INDEMNIFY_STATE UIStatus
	{
		get
		{
			if (Indemnify.m_Self != null)
			{
				return Indemnify.m_Self.bTriggered;
			}
			return INDEMNIFY_STATE.None;
		}
		set
		{
			if (Indemnify.m_Self != null)
			{
				Indemnify.m_Self.bTriggered = value;
			}
		}
	}

	// Token: 0x1700008D RID: 141
	// (get) Token: 0x0600127E RID: 4734 RVA: 0x002096FC File Offset: 0x002078FC
	public static Indemnify Instance
	{
		get
		{
			if (Indemnify.m_Self == null)
			{
				Indemnify.m_Self = new Indemnify();
			}
			return Indemnify.m_Self;
		}
	}

	// Token: 0x0600127F RID: 4735 RVA: 0x00209718 File Offset: 0x00207918
	public static void UpdateNetwork(byte[] meg)
	{
		if (meg[0] == 2 && Indemnify.m_Self != null && Indemnify.UIStatus == INDEMNIFY_STATE.ShowingTalk)
		{
			GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x / 2f, GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.y - 150f);
			Indemnify.m_Self.EffectDelay = 0f;
			Indemnify.m_Self.EffectIndex = 0;
			Indemnify.IsEffectShow = true;
			if (Indemnify.m_Self.HasIndemnify())
			{
				Indemnify.UIStatus = INDEMNIFY_STATE.ShowButton;
			}
			else
			{
				Indemnify.UIStatus = INDEMNIFY_STATE.None;
			}
			ActivityGiftManager.Instance.CheckShowActivityGiftEffect();
		}
	}

	// Token: 0x06001280 RID: 4736 RVA: 0x002097EC File Offset: 0x002079EC
	public static void UpdateRun()
	{
		if (Indemnify.m_Self == null)
		{
			return;
		}
		if (Indemnify.IsEffectShow)
		{
			if (Indemnify.m_Self.EffectDelay <= 0f)
			{
				GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, Indemnify.m_Self.EffectKind[Indemnify.m_Self.EffectIndex], 0, 0, true, 2f);
				Indemnify.m_Self.EffectIndex++;
				Indemnify.m_Self.EffectDelay = UnityEngine.Random.Range(0.1f, 0.3f);
				if (Indemnify.m_Self.EffectIndex >= Indemnify.m_Self.EffectKind.Length)
				{
					Indemnify.IsEffectShow = false;
					GUIManager.Instance.UpdateUI(EGUIWindow.Door, 21, 0);
				}
			}
			else
			{
				Indemnify.m_Self.EffectDelay -= Time.deltaTime;
			}
		}
	}

	// Token: 0x06001281 RID: 4737 RVA: 0x002098D0 File Offset: 0x00207AD0
	private bool HasIndemnify()
	{
		for (int i = 0; i < 4; i++)
		{
			if (this.ResourceCache[i] != 0L)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001282 RID: 4738 RVA: 0x00209900 File Offset: 0x00207B00
	public void CheckIndemnify(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		this.TriggerTime = MP.ReadLong(-1);
		for (int i = 0; i < 4; i++)
		{
			this.ResourceCache[i] = MP.ReadLong(-1);
			if (this.ResourceCache[i] != 0L && this.bTriggered == INDEMNIFY_STATE.None)
			{
				this.bTriggered = INDEMNIFY_STATE.Triggered;
			}
		}
		if (b != 0 && this.bTriggered == INDEMNIFY_STATE.Triggered)
		{
			if (this.CheckTriggered(this.TriggerTime))
			{
				this.bTriggered = INDEMNIFY_STATE.ShowButton;
			}
		}
		else
		{
			FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.SUPPLY_CHEST, 0L, 0UL);
		}
		this.SaveTriggerTime();
		if (!this.HasIndemnify() && this.bTriggered != INDEMNIFY_STATE.None)
		{
			this.bTriggered = INDEMNIFY_STATE.None;
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 21, 0);
		}
		GameManager.OnRefresh(NetworkNews.Refresh_IndemnifyResources, null);
		Indemnify.CheckShowIndemnify();
		Debug.LogWarning("CheckIndemnify");
		Debug.LogWarning(this.ResourceCache[0].ToString());
		Debug.LogWarning(this.ResourceCache[1].ToString());
		Debug.LogWarning(this.ResourceCache[2].ToString());
		Debug.LogWarning(this.ResourceCache[3].ToString());
	}

	// Token: 0x06001283 RID: 4739 RVA: 0x00209A40 File Offset: 0x00207C40
	public void SaveTriggerTime()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.uLongToFormat((ulong)DataManager.Instance.RoleAttr.UserId, 1, false);
		cstring.AppendFormat(Indemnify.INDEMNIFY_TIME_SAVE_NAME);
		PlayerPrefs.SetString(cstring.ToString(), this.TriggerTime.ToString());
	}

	// Token: 0x06001284 RID: 4740 RVA: 0x00209A98 File Offset: 0x00207C98
	public bool CheckTriggered(long time)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.uLongToFormat((ulong)DataManager.Instance.RoleAttr.UserId, 1, false);
		cstring.AppendFormat(Indemnify.INDEMNIFY_TIME_SAVE_NAME);
		long num = 0L;
		long.TryParse(PlayerPrefs.GetString(cstring.ToString(), "0"), out num);
		return num >= time;
	}

	// Token: 0x06001285 RID: 4741 RVA: 0x00209B04 File Offset: 0x00207D04
	public void CheckIndemnifyResource(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			DataManager.Instance.Resource[0].Stock = MP.ReadUInt(-1);
			DataManager.Instance.Resource[1].Stock = MP.ReadUInt(-1);
			DataManager.Instance.Resource[2].Stock = MP.ReadUInt(-1);
			DataManager.Instance.Resource[3].Stock = MP.ReadUInt(-1);
			GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
			Array.Clear(this.ResourceCache, 0, 4);
			this.AddResourceEffect();
			GUIManager instance = GUIManager.Instance;
			instance.CloseMenu(EGUIWindow.UI_TreasureBox);
			instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			this.bTriggered = INDEMNIFY_STATE.None;
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 21, 0);
			Debug.LogWarning("CheckIndemnifyResource");
			FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.COLLECT_EXTRA_SUPPLIES, 0L, 0UL);
		}
	}

	// Token: 0x06001286 RID: 4742 RVA: 0x00209BDC File Offset: 0x00207DDC
	public void AddResourceEffect()
	{
		Array.Clear(GUIManager.Instance.SE_Kind, 0, GUIManager.Instance.SE_Kind.Length);
		Array.Clear(GUIManager.Instance.m_SpeciallyEffect.mResValue, 0, GUIManager.Instance.m_SpeciallyEffect.mResValue.Length);
		Array.Clear(GUIManager.Instance.SE_ItemID, 0, GUIManager.Instance.SE_ItemID.Length);
		GUIManager.Instance.SE_Kind[0] = SpeciallyEffect_Kind.Food;
		GUIManager.Instance.SE_Kind[1] = SpeciallyEffect_Kind.Stone;
		GUIManager.Instance.SE_Kind[2] = SpeciallyEffect_Kind.Wood;
		GUIManager.Instance.SE_Kind[3] = SpeciallyEffect_Kind.Iron;
		GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x / 2f, GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.y - 150f);
		GUIManager.Instance.m_SpeciallyEffect.AddIconShow(GUIManager.Instance.mStartV2, GUIManager.Instance.SE_Kind, GUIManager.Instance.SE_ItemID, true);
	}

	// Token: 0x06001287 RID: 4743 RVA: 0x00209D0C File Offset: 0x00207F0C
	public static void CheckShowIndemnify()
	{
		if (Indemnify.UIStatus == INDEMNIFY_STATE.Triggered)
		{
			bool flag = true;
			if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
			{
				flag = false;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (!(door != null) || door.m_eMode != EUIOriginMode.Show || door.m_eMapMode != EUIOriginMapMode.OriginMap)
			{
				flag = false;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				flag = false;
			}
			if (!MallManager.Instance.bCanOpenMain)
			{
				flag = false;
			}
			if (!(GameManager.ActiveGameplay is Origin))
			{
				flag = false;
			}
			if (!NewbieManager.IsWorking() && flag)
			{
				int arg = UnityEngine.Random.Range(22, 30);
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.ClearString();
				cstring.uLongToFormat((ulong)DataManager.Instance.RoleAttr.UserId, 1, false);
				cstring.AppendFormat(Indemnify.INDEMNIFY_SAVE_NAME);
				if (PlayerPrefs.GetInt(cstring.ToString()) == 0)
				{
					arg = 22;
					PlayerPrefs.SetInt(cstring.ToString(), 1);
				}
				Indemnify.TriggerCount++;
				GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, arg, 0);
				Indemnify.UIStatus = INDEMNIFY_STATE.ShowingTalk;
			}
		}
	}

	// Token: 0x06001288 RID: 4744 RVA: 0x00209E48 File Offset: 0x00208048
	public static void SendRequestIndemnify()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_INDEMNIFY;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x040039CE RID: 14798
	private static readonly string INDEMNIFY_SAVE_NAME = "Indemnify{0}";

	// Token: 0x040039CF RID: 14799
	private static readonly string INDEMNIFY_TIME_SAVE_NAME = "IndemnifyTime{0}";

	// Token: 0x040039D0 RID: 14800
	public long TriggerTime;

	// Token: 0x040039D1 RID: 14801
	public long[] ResourceCache = new long[4];

	// Token: 0x040039D2 RID: 14802
	public static int TriggerCount;

	// Token: 0x040039D3 RID: 14803
	public float EffectDelay;

	// Token: 0x040039D4 RID: 14804
	public int EffectIndex;

	// Token: 0x040039D5 RID: 14805
	public SpeciallyEffect_Kind[] EffectKind = new SpeciallyEffect_Kind[]
	{
		SpeciallyEffect_Kind.Food,
		SpeciallyEffect_Kind.Wood,
		SpeciallyEffect_Kind.Iron,
		SpeciallyEffect_Kind.Stone
	};

	// Token: 0x040039D6 RID: 14806
	private INDEMNIFY_STATE bTriggered;

	// Token: 0x040039D7 RID: 14807
	public static bool IsEffectShow;

	// Token: 0x040039D8 RID: 14808
	private static Indemnify m_Self;
}
