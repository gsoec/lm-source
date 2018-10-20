using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000755 RID: 1877
public class HUDMessageMgr : Hudhandle
{
	// Token: 0x0600241E RID: 9246 RVA: 0x0041E0F8 File Offset: 0x0041C2F8
	private void CloneValue(HUDItem Src, HUDItem Target)
	{
		Target.ThisTransform.gameObject.SetActive(Src.ThisTransform.gameObject.activeSelf);
		Target.Alpha.alpha = Src.Alpha.alpha;
		Target.DelayTime = Src.DelayTime;
		Target.FadeTime = Src.FadeTime;
		Target.Icon.sprite = Src.Icon.sprite;
		Target.Icon.material = Src.Icon.material;
		Target.CloneText(Src.MsgStr.ToString());
		Target.MsgText.color = Src.MsgText.color;
		Target.ShowIconTime = Src.ShowIconTime;
		Target.bColseItem = Src.bColseItem;
		Target.MP3Sound = Src.MP3Sound;
		Target.SFXKind = Src.SFXKind;
	}

	// Token: 0x0600241F RID: 9247 RVA: 0x0041E1D8 File Offset: 0x0041C3D8
	public void AddMessageQueqe(string Msg, ushort Type, bool bCheckSame = true)
	{
		if (this.HUDQueue.Count == 0)
		{
			this.LatestQueueCstr.ClearString();
		}
		if (bCheckSame && this.CheckLaseSame(Msg, this.LatestQueueCstr.ToString()))
		{
			return;
		}
		if (this.UseCount == 0 && this.HUDQueue.Count == 0)
		{
			this.AddMessage(Msg, Type, bCheckSame);
		}
		else if (!this.HUDQueue.Push(Msg, Type))
		{
			string msg;
			ushort type;
			this.HUDQueue.Pop(out msg, out type);
			this.AddMessageDirect(msg, type, true);
			this.HUDQueue.Push(Msg, Type);
		}
		else
		{
			this.LatestQueueCstr.ClearString();
			this.LatestQueueCstr.Append(Msg);
			this.CheckQueue();
		}
	}

	// Token: 0x06002420 RID: 9248 RVA: 0x0041E2A4 File Offset: 0x0041C4A4
	public void AddMessage(string Msg, ushort Type, bool bCheckSame = true)
	{
		if (!this.bInit)
		{
			this.Init();
			this.bInit = true;
		}
		if (this.HUDQueue.Count > 0)
		{
			this.AddMessageQueqe(Msg, Type, bCheckSame);
		}
		else
		{
			this.AddMessageDirect(Msg, Type, bCheckSame);
		}
	}

	// Token: 0x06002421 RID: 9249 RVA: 0x0041E2F4 File Offset: 0x0041C4F4
	private void AddMessageDirect(string Msg, ushort Type, bool bCheckSame = true)
	{
		if (!this.bInit)
		{
			this.Init();
			this.bInit = true;
		}
		this.QueueTime = 0f;
		if (bCheckSame && this.HudMessage[0].ThisTransform.gameObject.activeSelf && this.LatestType == Type)
		{
			if (Msg == this.LatestStr)
			{
				this.HudMessage[0].AddMessage(Msg, Type);
				return;
			}
			bool flag = this.CheckLaseSame(Msg, this.LatestCstr.ToString());
			if (flag)
			{
				this.HudMessage[0].AddMessage(Msg, Type);
				return;
			}
		}
		if (this.UseCount < 3)
		{
			for (byte b = this.UseCount; b > 0; b -= 1)
			{
				this.CloneValue(this.HudMessage[(int)(b - 1)], this.HudMessage[(int)b]);
			}
			this.HudMessage[0].AddMessage(Msg, Type);
		}
		else
		{
			this.UseCount = 2;
			for (byte b2 = this.UseCount; b2 > 0; b2 -= 1)
			{
				this.CloneValue(this.HudMessage[(int)(b2 - 1)], this.HudMessage[(int)b2]);
			}
			this.HudMessage[0].AddMessage(Msg, Type);
		}
		this.LatestStr = Msg;
		this.LatestCstr.ClearString();
		this.LatestCstr.StringToFormat(Msg);
		this.LatestCstr.AppendFormat("{0}");
		this.LatestType = Type;
		this.UseCount += 1;
		if (this.UseCount == 1 && !this.BackRect.gameObject.activeSelf)
		{
			this.BackRect.gameObject.SetActive(true);
			this.bFirstShow = true;
			this.FirstShowTime = 0f;
		}
		this.BackCanvasGroup.alpha = 1f;
		this.UpdateBackSize();
	}

	// Token: 0x06002422 RID: 9250 RVA: 0x0041E4D4 File Offset: 0x0041C6D4
	private unsafe bool CheckLaseSame(string Msg, string CompareStr)
	{
		if (Msg == null || CompareStr == null)
		{
			return false;
		}
		fixed (string text = Msg)
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				fixed (string text2 = CompareStr)
				{
					fixed (char* ptr2 = text2 + RuntimeHelpers.OffsetToStringData / 2)
					{
						for (int i = 0; i < CompareStr.Length; i++)
						{
							if (ptr2[i] == '\0')
							{
								return ptr[i] == '\0';
							}
							if (Msg.Length <= i || ptr[i] != ptr2[i])
							{
								return false;
							}
						}
						text = null;
						text2 = null;
						return true;
					}
				}
			}
		}
	}

	// Token: 0x06002423 RID: 9251 RVA: 0x0041E564 File Offset: 0x0041C764
	public void Init()
	{
		if (this.bInit)
		{
			return;
		}
		this.MessageSource = HUDMessageMgr.eMessageSource.Direct;
		GameObject gameObject = UnityEngine.Object.Instantiate(GUIManager.Instance.m_ManagerAssetBundle.Load("UIHUD")) as GameObject;
		gameObject.transform.SetParent(GUIManager.Instance.m_HUDsTransform, false);
		Transform transform = gameObject.transform;
		this.BackCanvasGroup = transform.GetChild(0).GetComponent<CanvasGroup>();
		this.BackRect = transform.GetChild(0).GetComponent<RectTransform>();
		CustomImage component = transform.GetChild(0).GetComponent<CustomImage>();
		GUIManager.Instance.m_ItemInfo.LoadCustomImage(component, component.ImageName, component.TextureName);
		if (this.MapHud == null)
		{
			this.MapHud = new _MapHud();
		}
		this.MapHud.Init(transform.GetChild(1));
		if (this.HUDQueue == null)
		{
			this.HUDQueue = new HUDQueueItem();
		}
		this.UseCount = 0;
		this.bFirstShow = false;
		for (int i = 0; i < 3; i++)
		{
			if (this.HudMessage[i] == null)
			{
				this.HudMessage[i] = new HUDItem();
			}
			this.HudMessage[i].Init(i, transform.GetChild(transform.childCount - i - 1));
			this.HudMessage[i].Handle = this;
		}
		this.BackMaxWidth = 713f;
		this.BackOriPos = this.BackRect.anchoredPosition;
		if (this.LatestCstr == null)
		{
			this.LatestCstr = StringManager.Instance.SpawnString(200);
		}
		if (this.LatestQueueCstr == null)
		{
			this.LatestQueueCstr = StringManager.Instance.SpawnString(200);
		}
		this.bInit = true;
	}

	// Token: 0x06002424 RID: 9252 RVA: 0x0041E714 File Offset: 0x0041C914
	public void UpdateBackSize()
	{
		if (this.UseCount == 2 && !this.HudMessage[1].ThisTransform.gameObject.activeSelf)
		{
			this.MinBackHeight = 120;
		}
		else
		{
			this.MinBackHeight = Mathf.Max(40, (int)(this.UseCount * 40));
			if (this.MinBackHeight == 80)
			{
				if (!this.HudMessage[2].ThisTransform.gameObject.activeSelf)
				{
					this.DesirePos = (int)this.BackOriPos.y;
				}
				else if (!this.HudMessage[0].ThisTransform.gameObject.activeSelf)
				{
					this.DesirePos = (int)this.BackOriPos.y + 40;
				}
			}
			else if (this.MinBackHeight == 40)
			{
				if (this.HudMessage[0].ThisTransform.gameObject.activeSelf)
				{
					this.DesirePos = (int)this.BackOriPos.y;
				}
				else if (this.HudMessage[1].ThisTransform.gameObject.activeSelf)
				{
					this.DesirePos = (int)this.BackOriPos.y + 40;
				}
				else if (this.HudMessage[2].ThisTransform.gameObject.activeSelf)
				{
					this.DesirePos = (int)this.BackOriPos.y + 80;
				}
			}
			else if (this.MinBackHeight == 120)
			{
				this.DesirePos = (int)this.BackOriPos.y;
			}
		}
	}

	// Token: 0x06002425 RID: 9253 RVA: 0x0041E8B0 File Offset: 0x0041CAB0
	public void Update()
	{
		if (this.BackRect == null)
		{
			return;
		}
		if (this.MapHud != null)
		{
			this.MapHud.Update();
		}
		this.CheckQueue();
		float num = 0.5f;
		if (this.BackRect == null || !this.BackRect.gameObject.activeSelf)
		{
			return;
		}
		Vector2 sizeDelta = this.BackRect.sizeDelta;
		Vector2 anchoredPosition = this.BackRect.anchoredPosition;
		float unscaledDeltaTime = Time.unscaledDeltaTime;
		if (this.bFirstShow)
		{
			sizeDelta.y = 40f;
			sizeDelta.x = EasingEffect.Linear(this.FirstShowTime, 0f, this.BackMaxWidth, this.MaxFirstShowTime);
			this.FirstShowTime += unscaledDeltaTime;
			if (this.FirstShowTime > this.MaxFirstShowTime)
			{
				this.bFirstShow = false;
				this.FadeoutTime = 0f;
				sizeDelta.x = this.BackMaxWidth;
			}
			this.BackRect.sizeDelta = sizeDelta;
			return;
		}
		int num2 = (int)((float)this.MinBackHeight - sizeDelta.y);
		int num3 = (int)((float)this.DesirePos - anchoredPosition.y);
		if (num2 > 0)
		{
			sizeDelta.y += (float)this.MinBackHeight * unscaledDeltaTime * 5f;
			if (sizeDelta.y > (float)this.MinBackHeight)
			{
				sizeDelta.y = (float)this.MinBackHeight;
			}
			this.BackRect.sizeDelta = sizeDelta;
		}
		if (num3 > 0)
		{
			anchoredPosition.y += (float)this.MinBackHeight * unscaledDeltaTime * 5f;
			if (anchoredPosition.y > (float)this.DesirePos)
			{
				anchoredPosition.y = (float)this.DesirePos;
			}
			this.BackRect.anchoredPosition = anchoredPosition;
		}
		for (int i = 0; i < 3; i++)
		{
			this.HudMessage[i].Update();
		}
		num2 = (int)((float)this.MinBackHeight - sizeDelta.y);
		if (num2 < 0)
		{
			sizeDelta.y -= (float)this.MinBackHeight * unscaledDeltaTime * 5f;
			if (sizeDelta.y < (float)this.MinBackHeight)
			{
				sizeDelta.y = (float)this.MinBackHeight;
			}
			this.BackRect.sizeDelta = sizeDelta;
		}
		if (num3 < 0)
		{
			anchoredPosition.y -= (float)this.MinBackHeight * unscaledDeltaTime * 5f;
			if (anchoredPosition.y < (float)this.DesirePos)
			{
				anchoredPosition.y = (float)this.DesirePos;
			}
			this.BackRect.anchoredPosition = anchoredPosition;
		}
		if (this.UseCount == 0 && num2 == 0)
		{
			this.BackCanvasGroup.alpha = 1f - this.FadeoutTime / num;
			this.FadeoutTime += unscaledDeltaTime;
			if (this.FadeoutTime > num)
			{
				sizeDelta.Set(0f, this.BackRect.sizeDelta.y);
				this.BackRect.sizeDelta = sizeDelta;
				anchoredPosition.y = this.BackOriPos.y;
				this.BackRect.anchoredPosition = anchoredPosition;
				this.BackRect.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06002426 RID: 9254 RVA: 0x0041EC00 File Offset: 0x0041CE00
	public void TextRefresh()
	{
		if (this.MapHud != null)
		{
			this.MapHud.MsgText.enabled = false;
			this.MapHud.MsgText.enabled = true;
		}
		for (int i = 0; i < this.HudMessage.Length; i++)
		{
			if (this.HudMessage[i] != null)
			{
				this.HudMessage[i].MsgText.enabled = false;
				this.HudMessage[i].MsgText.enabled = true;
			}
		}
	}

	// Token: 0x06002427 RID: 9255 RVA: 0x0041EC8C File Offset: 0x0041CE8C
	private void CheckQueue()
	{
		if (this.HUDQueue == null)
		{
			return;
		}
		if (this.HUDQueue.Count > 0)
		{
			this.MessageSource = HUDMessageMgr.eMessageSource.Queue;
			this.QueueTime += Time.deltaTime;
		}
		else
		{
			this.MessageSource = HUDMessageMgr.eMessageSource.Direct;
		}
		if (this.QueueTime >= this.ShowQueueTime && this.MessageSource == HUDMessageMgr.eMessageSource.Queue && this.UseCount < 3)
		{
			string text;
			ushort type;
			this.HUDQueue.Pop(out text, out type);
			if (text != null)
			{
				this.AddMessageDirect(text, type, true);
				this.QueueTime = 0f;
			}
		}
	}

	// Token: 0x06002428 RID: 9256 RVA: 0x0041ED30 File Offset: 0x0041CF30
	public static float Quintic(float t, float b, float c, float d)
	{
		float num = (t /= d) * t;
		float num2 = num * t;
		return b + c * (-22.5975f * num2 * num + 22.5975f * num * num + t);
	}

	// Token: 0x06002429 RID: 9257 RVA: 0x0041ED64 File Offset: 0x0041CF64
	public void Destroy()
	{
		if (this.BackRect == null)
		{
			return;
		}
		this.MapHud.Destroy();
		this.HUDQueue.Destroy();
		for (int i = 0; i < this.HudMessage.Length; i++)
		{
			this.HudMessage[i].Destroy();
		}
		UnityEngine.Object.Destroy(this.BackRect.parent.gameObject);
		this.BackRect = null;
		this.bInit = false;
		this.FadeoutTime = 0f;
		StringManager.Instance.DeSpawnString(this.LatestQueueCstr);
		StringManager.Instance.DeSpawnString(this.LatestCstr);
		this.LatestQueueCstr = null;
		this.LatestCstr = null;
	}

	// Token: 0x0600242A RID: 9258 RVA: 0x0041EE20 File Offset: 0x0041D020
	public void OnDestroyMessage(int Index)
	{
		this.UseCount -= 1;
		this.UpdateBackSize();
	}

	// Token: 0x04006E03 RID: 28163
	public const byte MAX = 3;

	// Token: 0x04006E04 RID: 28164
	private bool bInit;

	// Token: 0x04006E05 RID: 28165
	public static readonly Color[] HUDColor = new Color[]
	{
		Color.yellow,
		Color.red
	};

	// Token: 0x04006E06 RID: 28166
	public CanvasGroup BackCanvasGroup;

	// Token: 0x04006E07 RID: 28167
	public RectTransform BackRect;

	// Token: 0x04006E08 RID: 28168
	private HUDItem[] HudMessage = new HUDItem[3];

	// Token: 0x04006E09 RID: 28169
	private bool bFirstShow;

	// Token: 0x04006E0A RID: 28170
	private byte UseCount;

	// Token: 0x04006E0B RID: 28171
	private int MinBackHeight;

	// Token: 0x04006E0C RID: 28172
	private int DesirePos;

	// Token: 0x04006E0D RID: 28173
	public float FirstShowTime;

	// Token: 0x04006E0E RID: 28174
	public float MaxFirstShowTime = 0.1f;

	// Token: 0x04006E0F RID: 28175
	public float FadeoutTime;

	// Token: 0x04006E10 RID: 28176
	public float BackMaxWidth;

	// Token: 0x04006E11 RID: 28177
	private Vector2 BackOriPos;

	// Token: 0x04006E12 RID: 28178
	private string LatestStr;

	// Token: 0x04006E13 RID: 28179
	private CString LatestCstr;

	// Token: 0x04006E14 RID: 28180
	private CString LatestQueueCstr;

	// Token: 0x04006E15 RID: 28181
	private ushort LatestType;

	// Token: 0x04006E16 RID: 28182
	public _MapHud MapHud;

	// Token: 0x04006E17 RID: 28183
	public HUDQueueItem HUDQueue;

	// Token: 0x04006E18 RID: 28184
	private float QueueTime;

	// Token: 0x04006E19 RID: 28185
	private float ShowQueueTime = 2.5f;

	// Token: 0x04006E1A RID: 28186
	private HUDMessageMgr.eMessageSource MessageSource;

	// Token: 0x02000756 RID: 1878
	private enum eMessageSource
	{
		// Token: 0x04006E1C RID: 28188
		Direct,
		// Token: 0x04006E1D RID: 28189
		Queue
	}
}
