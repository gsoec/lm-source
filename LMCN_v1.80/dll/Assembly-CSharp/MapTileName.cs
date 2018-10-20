using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200025F RID: 607
public class MapTileName
{
	// Token: 0x06000B2E RID: 2862 RVA: 0x000F2CF4 File Offset: 0x000F0EF4
	public MapTileName(Transform parentLayout, Vector2 inipos, Vector2 testsize)
	{
		GameObject gameObject = new GameObject("name");
		this.NameRectTransform = gameObject.AddComponent<RectTransform>();
		this.NameRectTransform.SetParent(parentLayout, false);
		this.NameRectTransform.localPosition = inipos;
		this.NameGameObject = gameObject;
		gameObject = new GameObject("nameText");
		this.NameText = gameObject.AddComponent<UIText>();
		Outline outline = gameObject.AddComponent<Outline>();
		this.NameText.font = GUIManager.Instance.GetTTFFont();
		this.NameText.alignment = TextAnchor.MiddleCenter;
		this.NameText.resizeTextForBestFit = true;
		this.NameText.resizeTextMaxSize = 24;
		this.TitleString = new CString(32);
		outline.effectColor = new Color(0f, 0f, 0f, 0.5f);
		RectTransform rectTransform = gameObject.transform as RectTransform;
		rectTransform.sizeDelta = testsize;
		rectTransform.localScale = Vector3.one;
		if (GUIManager.Instance.IsArabic)
		{
			rectTransform.localRotation = MapTileName.NameTextlocalRotation;
		}
		rectTransform.SetParent(this.NameRectTransform, false);
		this.NameGameObject.SetActive(false);
	}

	// Token: 0x06000B30 RID: 2864 RVA: 0x000F2E48 File Offset: 0x000F1048
	public void Release()
	{
		if (this.mapEmoji != null)
		{
			GUIManager.Instance.pushEmojiIcon(this.mapEmoji);
			this.mapEmoji = null;
		}
		if (this.mapEmojiBack != null)
		{
			GUIManager.Instance.pushEmojiIcon(this.mapEmojiBack);
			this.mapEmojiBack = null;
		}
		if (this.TimeString != null)
		{
			StringManager.Instance.DeSpawnString(this.TimeString);
			this.TimeString = null;
		}
		this.NameGameObject = null;
		this.NameRectTransform = null;
		this.NameText = null;
		this.TitleString = null;
	}

	// Token: 0x06000B31 RID: 2865 RVA: 0x000F2ED8 File Offset: 0x000F10D8
	public void updateName(CString Name, CString Tag, Color textcolor, Vector2 pos, ushort kingdomID = 0, CString First = null)
	{
		this.updateName(Name, Tag, textcolor, kingdomID, First);
		this.updateName(pos);
	}

	// Token: 0x06000B32 RID: 2866 RVA: 0x000F2EF0 File Offset: 0x000F10F0
	public void updateName(CString Name, CString Tag, Color textcolor, ushort kingdomID = 0, CString First = null)
	{
		this.updateName(textcolor);
		this.updateName(Name, Tag, kingdomID, First);
	}

	// Token: 0x06000B33 RID: 2867 RVA: 0x000F2F08 File Offset: 0x000F1108
	public void updateName(CString Name, CString Tag, ELineColor textcolor)
	{
		this.updateName(MapTileBloodName.lineNameColor[(int)textcolor]);
		this.updateName(Name, Tag, 0, null);
	}

	// Token: 0x06000B34 RID: 2868 RVA: 0x000F2F38 File Offset: 0x000F1138
	public void updateName(CString Name, CString Tag, ushort kingdomID = 0, CString First = null)
	{
		if (!this.NameGameObject.activeSelf)
		{
			this.NameGameObject.SetActive(true);
		}
		if (Name == null || Name.Length == 0)
		{
			this.NameText.gameObject.SetActive(false);
			return;
		}
		this.NameText.gameObject.SetActive(true);
		this.TitleString.ClearString();
		if (GUIManager.Instance.IsArabic)
		{
			if (First != null && First.Length != 0)
			{
				this.TitleString.Append(' ');
				this.TitleString.Append(First);
				if (Tag != null && Tag.Length != 0)
				{
					if (ArabicTransfer.Instance.IsArabicStr(Name.ToString()))
					{
						if (kingdomID != 0)
						{
							this.TitleString.Append('#');
							this.TitleString.Append(kingdomID.ToString());
							this.TitleString.Append(' ');
						}
						this.TitleString.Append(Name);
						this.TitleString.Append('[');
						this.TitleString.Append(Tag);
						this.TitleString.Append(']');
					}
					else
					{
						if (kingdomID != 0)
						{
							this.TitleString.Append('#');
							this.TitleString.Append(kingdomID.ToString());
							this.TitleString.Append(' ');
						}
						this.TitleString.Append(Name);
						this.TitleString.Append('[');
						this.TitleString.Append(Tag);
						this.TitleString.Append(']');
					}
				}
				else if (ArabicTransfer.Instance.IsArabicStr(Name.ToString()))
				{
					if (kingdomID != 0)
					{
						this.TitleString.Append('#');
						this.TitleString.Append(kingdomID.ToString());
						this.TitleString.Append(' ');
					}
					this.TitleString.Append(Name);
				}
				else
				{
					if (kingdomID != 0)
					{
						this.TitleString.Append(' ');
						this.TitleString.Append(kingdomID.ToString());
						this.TitleString.Append('#');
					}
					this.TitleString.Append(Name);
				}
			}
			else if (Tag != null && Tag.Length != 0)
			{
				if (ArabicTransfer.Instance.IsArabicStr(Name.ToString()))
				{
					if (kingdomID != 0)
					{
						this.TitleString.Append('#');
						this.TitleString.Append(kingdomID.ToString());
						this.TitleString.Append(' ');
					}
					this.TitleString.Append(Name);
					this.TitleString.Append('[');
					this.TitleString.Append(Tag);
					this.TitleString.Append(']');
				}
				else
				{
					this.TitleString.Append('[');
					this.TitleString.Append(Tag);
					this.TitleString.Append(']');
					this.TitleString.Append(Name);
					if (kingdomID != 0)
					{
						this.TitleString.Append(' ');
						this.TitleString.Append(kingdomID.ToString());
						this.TitleString.Append('#');
					}
				}
			}
			else if (ArabicTransfer.Instance.IsArabicStr(Name.ToString()))
			{
				if (kingdomID != 0)
				{
					this.TitleString.Append('#');
					this.TitleString.Append(kingdomID.ToString());
					this.TitleString.Append(' ');
				}
				this.TitleString.Append(Name);
			}
			else
			{
				this.TitleString.Append(Name);
				if (kingdomID != 0)
				{
					this.TitleString.Append(' ');
					this.TitleString.Append(kingdomID.ToString());
					this.TitleString.Append('#');
				}
			}
		}
		else
		{
			if (First != null && First.Length != 0)
			{
				this.TitleString.Append(First);
				this.TitleString.Append(' ');
			}
			if (kingdomID != 0)
			{
				this.TitleString.Append('#');
				this.TitleString.Append(kingdomID.ToString());
				this.TitleString.Append(' ');
			}
			if (Tag != null && Tag.Length != 0)
			{
				this.TitleString.Append('[');
				this.TitleString.Append(Tag);
				this.TitleString.Append(']');
			}
			this.TitleString.Append(Name);
		}
		this.NameText.text = this.TitleString.ToString();
		this.NameText.SetAllDirty();
		this.NameText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000B35 RID: 2869 RVA: 0x000F33D8 File Offset: 0x000F15D8
	public void updateName(Color textcolor)
	{
		if (!this.NameGameObject.activeSelf)
		{
			this.NameGameObject.SetActive(true);
		}
		this.NameText.color = textcolor;
	}

	// Token: 0x06000B36 RID: 2870 RVA: 0x000F3410 File Offset: 0x000F1610
	public void updateName(Vector2 pos)
	{
		if (!this.NameGameObject.activeSelf)
		{
			return;
		}
		this.NameRectTransform.anchoredPosition = pos + Vector2.up * this.NameOffset;
	}

	// Token: 0x06000B37 RID: 2871 RVA: 0x000F3450 File Offset: 0x000F1650
	public void updateNamePos(Vector2 pos)
	{
		if (!this.NameGameObject.activeSelf)
		{
			this.NameGameObject.SetActive(true);
		}
		Vector2 vector = pos - this.NameRectTransform.anchoredPosition;
		if (Mathf.Abs(vector.x) > 8f || Mathf.Abs(vector.y) > 8f)
		{
			this.NameRectTransform.anchoredPosition = pos;
		}
	}

	// Token: 0x06000B38 RID: 2872 RVA: 0x000F34C8 File Offset: 0x000F16C8
	public void SetActive(bool active)
	{
		this.NameGameObject.SetActive(active);
	}

	// Token: 0x06000B39 RID: 2873 RVA: 0x000F34D8 File Offset: 0x000F16D8
	public void NameTextRebuilt()
	{
		if (this.NameGameObject.activeSelf)
		{
			if (this.NameText != null && this.NameText.enabled)
			{
				this.NameText.enabled = false;
				this.NameText.enabled = true;
			}
			if (this.bloodtextID > 0)
			{
				Transform child = this.NameRectTransform.GetChild(this.bloodtextID);
				Text component = child.GetChild(4).GetComponent<Text>();
				if (component != null && component.enabled)
				{
					component.enabled = false;
					component.enabled = true;
				}
				component = child.GetChild(3).GetComponent<Text>();
				if (component != null && component.enabled)
				{
					component.enabled = false;
					component.enabled = true;
				}
			}
		}
	}

	// Token: 0x040024ED RID: 9453
	private static Quaternion NameTextlocalRotation = new Quaternion(0f, -180f, 0f, 0f);

	// Token: 0x040024EE RID: 9454
	public RectTransform NameRectTransform;

	// Token: 0x040024EF RID: 9455
	public float NameOffset;

	// Token: 0x040024F0 RID: 9456
	public EmojiUnit mapEmoji;

	// Token: 0x040024F1 RID: 9457
	public EmojiUnit mapEmojiBack;

	// Token: 0x040024F2 RID: 9458
	public int bloodtextID = -1;

	// Token: 0x040024F3 RID: 9459
	public short pointID = -1;

	// Token: 0x040024F4 RID: 9460
	public CString TimeString;

	// Token: 0x040024F5 RID: 9461
	private GameObject NameGameObject;

	// Token: 0x040024F6 RID: 9462
	private UIText NameText;

	// Token: 0x040024F7 RID: 9463
	private CString TitleString;
}
