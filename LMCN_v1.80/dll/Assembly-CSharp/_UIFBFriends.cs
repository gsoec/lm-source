using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000403 RID: 1027
public struct _UIFBFriends : _CheckTextHandle
{
	// Token: 0x06001510 RID: 5392 RVA: 0x00240A54 File Offset: 0x0023EC54
	public _UIFBFriends(Transform transform, Font font, IUIButtonClickHandler handle, Transform blockTrans)
	{
		this.recttransform = (transform as RectTransform);
		this.gameobject = transform.gameObject;
		this.Title = this.recttransform.GetChild(1).GetComponent<UIText>();
		this.Title.font = font;
		this.Title.text = DataManager.Instance.mStringTable.GetStringByID(12159u);
		this.Friends = new _UIFBFriends._Friend[10];
		int i;
		for (i = 0; i < 10; i++)
		{
			this.Friends[i] = new _UIFBFriends._Friend(this.recttransform.GetChild(2 + i), font, handle, blockTrans);
		}
		this.TipText = this.recttransform.GetChild(i + 2).GetComponent<UIText>();
		this.TipText.font = font;
		this.TipText.text = DataManager.Instance.mStringTable.GetStringByID(12166u);
	}

	// Token: 0x06001511 RID: 5393 RVA: 0x00240B4C File Offset: 0x0023ED4C
	float _CheckTextHandle.TextLenCheck(UIText mText, CString Str)
	{
		int fontSize = mText.fontSize;
		float preferredWidth = mText.preferredWidth;
		float x = mText.rectTransform.sizeDelta.x;
		if (preferredWidth > x)
		{
			for (int i = 1; i <= 2; i++)
			{
				mText.fontSize = fontSize - i;
				mText.SetLayoutDirty();
				mText.cachedTextGeneratorForLayout.Invalidate();
				preferredWidth = mText.preferredWidth;
				if (preferredWidth <= x)
				{
					break;
				}
			}
			if (preferredWidth > x)
			{
				while (preferredWidth > x)
				{
					Str.Substring(Str.ToString(), 0, Str.Length - 2);
					mText.text = Str.ToString();
					mText.SetAllDirty();
					mText.cachedTextGenerator.Invalidate();
					mText.cachedTextGeneratorForLayout.Invalidate();
					preferredWidth = mText.preferredWidth;
				}
				Str.Append("...");
				mText.text = Str.ToString();
				mText.SetAllDirty();
				mText.cachedTextGenerator.Invalidate();
				mText.cachedTextGeneratorForLayout.Invalidate();
				preferredWidth = mText.preferredWidth;
				while (preferredWidth > x && mText.fontSize > 4)
				{
					mText.fontSize--;
					mText.SetLayoutDirty();
					mText.cachedTextGeneratorForLayout.Invalidate();
					preferredWidth = mText.preferredWidth;
					if (preferredWidth <= x)
					{
						break;
					}
				}
			}
		}
		return preferredWidth;
	}

	// Token: 0x1700009C RID: 156
	// (set) Token: 0x06001512 RID: 5394 RVA: 0x00240CA0 File Offset: 0x0023EEA0
	public float Top
	{
		set
		{
			this.recttransform.anchoredPosition = new Vector2(this.recttransform.anchoredPosition.x, value);
			for (byte b = 0; b < 10; b += 1)
			{
				this.Friends[(int)b].NameText.Top = value;
			}
		}
	}

	// Token: 0x1700009D RID: 157
	// (get) Token: 0x06001513 RID: 5395 RVA: 0x00240CFC File Offset: 0x0023EEFC
	public float Width
	{
		get
		{
			return this.recttransform.sizeDelta.x;
		}
	}

	// Token: 0x1700009E RID: 158
	// (get) Token: 0x06001514 RID: 5396 RVA: 0x00240D1C File Offset: 0x0023EF1C
	// (set) Token: 0x06001515 RID: 5397 RVA: 0x00240D3C File Offset: 0x0023EF3C
	public float Height
	{
		get
		{
			return this.recttransform.sizeDelta.y;
		}
		set
		{
			this.recttransform.sizeDelta = new Vector2(this.recttransform.sizeDelta.x, value);
		}
	}

	// Token: 0x06001516 RID: 5398 RVA: 0x00240D70 File Offset: 0x0023EF70
	public void Show(byte ID, byte count)
	{
		this.gameobject.SetActive(true);
		for (byte b = 0; b < 10; b += 1)
		{
			if (b < count)
			{
				this.Friends[(int)b].TextHandle = this;
				this.Friends[(int)b].Show(ID, b);
			}
			else
			{
				this.Friends[(int)b].Hide();
			}
		}
		this.Height = 507f - (float)(4 - ((int)(count / 3) + Mathf.Clamp((int)(count % 3), 0, 1))) * 88f;
	}

	// Token: 0x06001517 RID: 5399 RVA: 0x00240E0C File Offset: 0x0023F00C
	public void Hide()
	{
		this.gameobject.SetActive(false);
	}

	// Token: 0x06001518 RID: 5400 RVA: 0x00240E1C File Offset: 0x0023F01C
	public void UpdateData()
	{
		if (!this.gameobject.activeSelf)
		{
			return;
		}
		for (byte b = 0; b < 10; b += 1)
		{
			this.Friends[(int)b].UpdateData();
		}
	}

	// Token: 0x06001519 RID: 5401 RVA: 0x00240E60 File Offset: 0x0023F060
	public void UpdateTime()
	{
		if (!this.gameobject.activeSelf)
		{
			return;
		}
		for (byte b = 0; b < 10; b += 1)
		{
			this.Friends[(int)b].UpdateTime();
		}
	}

	// Token: 0x0600151A RID: 5402 RVA: 0x00240EA4 File Offset: 0x0023F0A4
	public void TextRefresh()
	{
		this.Title.enabled = false;
		this.Title.enabled = true;
		for (byte b = 0; b < 10; b += 1)
		{
			this.Friends[(int)b].TextRefresh();
		}
	}

	// Token: 0x0600151B RID: 5403 RVA: 0x00240EF0 File Offset: 0x0023F0F0
	public void Destroy()
	{
		for (byte b = 0; b < 10; b += 1)
		{
			this.Friends[(int)b].Destroy();
		}
	}

	// Token: 0x04003E03 RID: 15875
	private UIText Title;

	// Token: 0x04003E04 RID: 15876
	private UIText TipText;

	// Token: 0x04003E05 RID: 15877
	private GameObject gameobject;

	// Token: 0x04003E06 RID: 15878
	private RectTransform recttransform;

	// Token: 0x04003E07 RID: 15879
	private _UIFBFriends._Friend[] Friends;

	// Token: 0x02000404 RID: 1028
	private struct _Friend
	{
		// Token: 0x0600151C RID: 5404 RVA: 0x00240F24 File Offset: 0x0023F124
		public _Friend(Transform transform, Font font, IUIButtonClickHandler handle, Transform blockTrans)
		{
			this.gameobject = transform.gameObject;
			this.IconTrans = transform.GetChild(0);
			this.LinkNameText = transform.GetChild(1).GetComponent<UIText>();
			this.LinkNameText.font = font;
			this.OriLinkFontSize = this.LinkNameText.fontSize;
			this.NameStr = StringManager.Instance.SpawnString(64);
			this.LinkStr = StringManager.Instance.SpawnString(128);
			this.TimeStr = StringManager.Instance.SpawnString(30);
			this.NameText = default(_TextUnderLine);
			this.NameText.Init(transform.GetChild(2).GetComponent<RectTransform>(), font);
			this.NameText.Button.m_Handler = handle;
			this.TextHandle = null;
			this.TimeText = transform.GetChild(3).GetComponent<UIText>();
			this.TimeText.font = font;
			transform.GetChild(2).SetParent(blockTrans);
			this.BeiginTime = 0L;
			this.RequireTime = 0u;
			this.friend = null;
			this.Icon = null;
			this.ID = (this.Index = 0);
			this.TimeTextDefSize = this.TimeText.rectTransform.sizeDelta;
			this.TimeText.AdjuestUI();
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x0024106C File Offset: 0x0023F26C
		public void TextRefresh()
		{
			this.LinkNameText.enabled = false;
			this.LinkNameText.enabled = true;
			this.TimeText.enabled = false;
			this.TimeText.enabled = true;
			this.NameText.TextRefresh();
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x002410B4 File Offset: 0x0023F2B4
		public void Show(byte id, byte index)
		{
			this.gameobject.SetActive(true);
			this.ID = id;
			this.Index = index;
			DataManager.FBMissionDataManager.GetFriendSocialInfo(this.ID, (int)this.Index, out this.friend, true);
			if (this.friend != null)
			{
				if (this.Icon != null)
				{
					GUIManager.Instance.pushEmojiIcon(this.Icon);
				}
				this.Icon = DataManager.FBMissionDataManager.GetFriendEmoji((ushort)this.friend.IconNo);
				if (this.Icon != null)
				{
					this.Icon.EmojiTransform.SetParent(this.IconTrans, false);
					float iconScale = this.GetIconScale(this.Icon);
					this.Icon.EmojiTransform.localPosition = Vector3.zero;
					this.Icon.EmojiTransform.localScale = new Vector3(iconScale, iconScale, iconScale);
				}
				this.NameText.gameobject.SetActive(true);
				GameConstants.FormatRoleName(this.NameStr, this.friend.Name, this.friend.AllianceTag, null, 0, 0, null, null, null, null);
				this.LinkNameText.fontSize = this.OriLinkFontSize;
				this.LinkNameText.text = this.friend.SocialName.ToString();
				this.LinkNameText.SetAllDirty();
				this.LinkNameText.cachedTextGenerator.Invalidate();
				this.LinkNameText.cachedTextGeneratorForLayout.Invalidate();
				if (this.TextHandle != null)
				{
					this.NameText.TextHandle = this.TextHandle;
					this.NameText.SetText(this.NameStr.ToString());
					this.NameText.Button.m_BtnID1 = (int)id;
					this.NameText.Button.m_BtnID2 = (int)index;
					this.LinkStr.ClearString();
					this.LinkStr.Append(this.friend.SocialName);
					this.TextHandle.TextLenCheck(this.LinkNameText, this.LinkStr);
				}
				this.BeiginTime = this.friend.MissionTime.BeginTime;
				this.RequireTime = this.friend.MissionTime.RequireTime;
				this.UpdateTime();
			}
			else
			{
				this.LinkNameText.text = string.Empty;
				this.NameText.SetText(string.Empty);
				this.TimeText.text = string.Empty;
			}
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x0024131C File Offset: 0x0023F51C
		private float GetIconScale(EmojiUnit icon)
		{
			float result = 0f;
			if (icon != null)
			{
				Rect rect = icon.EmojiImage.rectTransform.rect;
				float num = (rect.width >= rect.height) ? rect.width : rect.height;
				result = 46f / num;
			}
			return result;
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x00241378 File Offset: 0x0023F578
		public void UpdateData()
		{
			if (!this.gameobject.activeSelf)
			{
				return;
			}
			if (this.friend != null && DataManager.FBMissionDataManager.UpdateFriendSerialNo == this.friend.UserSerialNo)
			{
				this.Show(this.ID, this.Index);
			}
		}

		// Token: 0x06001521 RID: 5409 RVA: 0x002413D0 File Offset: 0x0023F5D0
		public void UpdateTime()
		{
			if (!this.gameobject.activeSelf)
			{
				return;
			}
			long num = this.BeiginTime + (long)((ulong)this.RequireTime) - DataManager.Instance.ServerTime;
			long num2 = 0L;
			byte b = 0;
			this.TimeStr.ClearString();
			if (this.BeiginTime == 0L)
			{
				this.TimeStr.Append(DataManager.Instance.mStringTable.GetStringByID(12192u));
				b = 1;
			}
			else if (num < 0L)
			{
				this.TimeStr.Append("00:00");
			}
			else
			{
				num2 = num / 86400L;
				if (num > 86400L)
				{
					this.TimeStr.IntToFormat(num2, 1, false);
					this.TimeStr.AppendFormat("{0}d");
				}
				else if (num > 3600L)
				{
					this.TimeStr.IntToFormat(num / 3600L, 1, false);
					this.TimeStr.AppendFormat("{0}h");
				}
				else
				{
					this.TimeStr.IntToFormat(num / 60L, 2, false);
					this.TimeStr.IntToFormat(num % 60L, 2, false);
					this.TimeStr.AppendFormat("{0}:{1}");
				}
			}
			if (this.BeiginTime == 0L)
			{
				this.TimeText.color = Color.gray;
			}
			else if (num2 < 3L)
			{
				this.TimeText.color = new Color32(239, 58, 84, byte.MaxValue);
			}
			else
			{
				this.TimeText.color = Color.white;
			}
			if (b == 1)
			{
				this.TimeText.rectTransform.sizeDelta = new Vector2(this.TimeTextDefSize.x * 3f, this.TimeTextDefSize.y);
				if (GUIManager.Instance.IsArabic)
				{
					this.TimeText.alignment = TextAnchor.MiddleRight;
				}
				else
				{
					this.TimeText.alignment = TextAnchor.MiddleLeft;
				}
			}
			else
			{
				this.TimeText.rectTransform.sizeDelta = this.TimeTextDefSize;
				this.TimeText.alignment = TextAnchor.MiddleCenter;
			}
			this.TimeText.UpdateArabicPos();
			this.TimeText.text = this.TimeStr.ToString();
			this.TimeText.SetAllDirty();
			this.TimeText.cachedTextGenerator.Invalidate();
		}

		// Token: 0x06001522 RID: 5410 RVA: 0x00241634 File Offset: 0x0023F834
		public void Hide()
		{
			this.gameobject.SetActive(false);
			this.NameText.gameobject.SetActive(false);
		}

		// Token: 0x06001523 RID: 5411 RVA: 0x00241654 File Offset: 0x0023F854
		public void Destroy()
		{
			this.NameText.OnClose();
			StringManager.Instance.DeSpawnString(this.LinkStr);
			StringManager.Instance.DeSpawnString(this.NameStr);
			StringManager.Instance.DeSpawnString(this.TimeStr);
			if (this.Icon != null)
			{
				GUIManager.Instance.pushEmojiIcon(this.Icon);
			}
		}

		// Token: 0x04003E08 RID: 15880
		private GameObject gameobject;

		// Token: 0x04003E09 RID: 15881
		private UIText LinkNameText;

		// Token: 0x04003E0A RID: 15882
		private UIText TimeText;

		// Token: 0x04003E0B RID: 15883
		private CString NameStr;

		// Token: 0x04003E0C RID: 15884
		private CString LinkStr;

		// Token: 0x04003E0D RID: 15885
		private CString TimeStr;

		// Token: 0x04003E0E RID: 15886
		public _TextUnderLine NameText;

		// Token: 0x04003E0F RID: 15887
		private int OriLinkFontSize;

		// Token: 0x04003E10 RID: 15888
		public _CheckTextHandle TextHandle;

		// Token: 0x04003E11 RID: 15889
		private long BeiginTime;

		// Token: 0x04003E12 RID: 15890
		private uint RequireTime;

		// Token: 0x04003E13 RID: 15891
		private Transform IconTrans;

		// Token: 0x04003E14 RID: 15892
		private SocialFriend friend;

		// Token: 0x04003E15 RID: 15893
		private EmojiUnit Icon;

		// Token: 0x04003E16 RID: 15894
		private byte ID;

		// Token: 0x04003E17 RID: 15895
		private byte Index;

		// Token: 0x04003E18 RID: 15896
		private Vector2 TimeTextDefSize;
	}
}
