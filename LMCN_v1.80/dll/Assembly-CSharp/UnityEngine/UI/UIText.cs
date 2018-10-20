using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
	// Token: 0x02000885 RID: 2181
	[AddComponentMenu("UI/UIText", 35)]
	public class UIText : Text
	{
		// Token: 0x17000170 RID: 368
		// (get) Token: 0x06002D47 RID: 11591 RVA: 0x0048FC38 File Offset: 0x0048DE38
		// (set) Token: 0x06002D48 RID: 11592 RVA: 0x0048FC40 File Offset: 0x0048DE40
		public bool bEmoji
		{
			get
			{
				return this._bEmoji;
			}
			set
			{
				this._bEmoji = value;
				if (this._bEmoji && this.m_Emoji == null)
				{
					this.m_Emoji = new UIEmoji();
				}
			}
		}

		// Token: 0x06002D49 RID: 11593 RVA: 0x0048FC78 File Offset: 0x0048DE78
		public UIEmoji GetEmoji()
		{
			return this.m_Emoji;
		}

		// Token: 0x06002D4A RID: 11594 RVA: 0x0048FC80 File Offset: 0x0048DE80
		protected override void Start()
		{
			this.AdjuestUI();
		}

		// Token: 0x06002D4B RID: 11595 RVA: 0x0048FC88 File Offset: 0x0048DE88
		protected override void UpdateGeometry()
		{
			if (base.font != null)
			{
				base.UpdateGeometry();
				if (this.bEmoji && this.m_Emoji != null)
				{
					this.m_Emoji.ShowEmojiImage();
				}
			}
		}

		// Token: 0x06002D4C RID: 11596 RVA: 0x0048FCD0 File Offset: 0x0048DED0
		protected override void OnFillVBO(List<UIVertex> vbo)
		{
			base.OnFillVBO(vbo);
			if (GUIManager.Instance.IsArabic || this.bArabicStr == 1)
			{
				if (this.CheckText == eTextCheck.Text_None)
				{
					if (ArabicTransfer.Instance.IsArabicStr(this.m_Text))
					{
						this.CheckText = eTextCheck.Text_Arabic;
					}
					else
					{
						this.CheckText = eTextCheck.Text_NonArabic;
					}
				}
				if ((byte)(this.CheckText & eTextCheck.Text_Arabic) > 0)
				{
					this.AdjuestArabicVBOHeight(vbo);
				}
			}
		}

		// Token: 0x06002D4D RID: 11597 RVA: 0x0048FD48 File Offset: 0x0048DF48
		private void AdjuestArabicVBOHeight(List<UIVertex> vbo)
		{
			IList<UILineInfo> lines = base.cachedTextGenerator.lines;
			if (lines.Count > 1)
			{
				IList<UICharInfo> characters = base.cachedTextGenerator.characters;
				int num = lines.Count - 1;
				int num2 = 0;
				float num3 = 1f / base.pixelsPerUnit;
				while (num > -1 && num2 < lines.Count)
				{
					UILineInfo uilineInfo = lines[num];
					int num4 = lines[num2].startCharIdx;
					int num5 = (num2 < lines.Count - 1) ? lines[num2 + 1].startCharIdx : characters.Count;
					int num6 = uilineInfo.startCharIdx;
					int num7 = (num < lines.Count - 1) ? lines[num + 1].startCharIdx : characters.Count;
					if (num4 < this.m_Text.Length && this.m_Text[num4] == '<')
					{
						if (num4 + 14 < num5 && this.m_Text[num4 + 14] == '>')
						{
							int i;
							for (i = 0; i < this.CheckColorStr.Length; i++)
							{
								if (this.CheckColorStr[i] != this.m_Text[num4 + i + 1])
								{
									break;
								}
							}
							if (i == this.CheckColorStr.Length && num4 + 14 + 1 < num5)
							{
								num4 += 15;
							}
						}
						else if (num4 + 16 < num5 && this.m_Text[num4 + 16] == '>')
						{
							int j;
							for (j = 0; j < this.CheckColorStr.Length; j++)
							{
								if (this.CheckColorStr[j] != this.m_Text[num4 + j + 1])
								{
									break;
								}
							}
							if (j == this.CheckColorStr.Length && num4 + 16 + 1 < num5)
							{
								num4 += 17;
							}
						}
					}
					if (num6 < this.m_Text.Length && this.m_Text[num6] == '<')
					{
						if (num6 + 14 < num7 && this.m_Text[num6 + 14] == '>')
						{
							int k;
							for (k = 0; k < this.CheckColorStr.Length; k++)
							{
								if (this.CheckColorStr[k] != this.m_Text[num6 + k + 1])
								{
									break;
								}
							}
							if (k == this.CheckColorStr.Length && num6 + 14 + 1 < num7)
							{
								num6 += 15;
							}
						}
						else if (num6 + 16 < num7 && this.m_Text[num6 + 16] == '>')
						{
							int l;
							for (l = 0; l < this.CheckColorStr.Length; l++)
							{
								if (this.CheckColorStr[l] != this.m_Text[num6 + l + 1])
								{
									break;
								}
							}
							if (l == this.CheckColorStr.Length && num6 + 16 + 1 < num7)
							{
								num6 += 17;
							}
						}
					}
					float num8 = characters[num4].cursorPos.y - characters[num6].cursorPos.y;
					num8 *= num3;
					for (int m = (num < lines.Count - 1) ? (lines[num + 1].startCharIdx - 1) : ((vbo.Count >> 2) - 1); m >= uilineInfo.startCharIdx; m--)
					{
						for (int n = 0; n < 4; n++)
						{
							UIVertex value = vbo[(m << 2) + n];
							value.position += Vector3.up * num8;
							vbo[(m << 2) + n] = value;
						}
					}
					num--;
					num2++;
				}
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x06002D4E RID: 11598 RVA: 0x004901A8 File Offset: 0x0048E3A8
		// (set) Token: 0x06002D4F RID: 11599 RVA: 0x004901B0 File Offset: 0x0048E3B0
		public override string text
		{
			get
			{
				return this.m_Text;
			}
			set
			{
				bool isArabic = GUIManager.Instance.IsArabic;
				this.CheckText = eTextCheck.Text_None;
				if (string.IsNullOrEmpty(value))
				{
					if (!string.IsNullOrEmpty(this.m_Text))
					{
						this.m_Text = string.Empty;
						this.CheckStr = string.Empty;
						this.SetVerticesDirty();
					}
				}
				else
				{
					if (isArabic || this.bArabicStr == 1)
					{
						if (this.CheckStr != value)
						{
							this.InitArabicCString(value);
							this.m_Text = ArabicTransfer.Instance.Transfer(value, this.tmpArabicStr);
							this.CheckStr = value;
							this.SetVerticesDirty();
							this.SetLayoutDirty();
							base.cachedTextGenerator.Invalidate();
							base.cachedTextGeneratorForLayout.Invalidate();
							this.CheckText = ArabicTransfer.Instance.TextState;
						}
					}
					else if (this.m_Text != value)
					{
						this.m_Text = value;
						this.SetVerticesDirty();
						this.SetLayoutDirty();
					}
					if (this.bEmoji && this.m_Emoji != null)
					{
						this.m_Emoji.CheckEmojiText();
					}
				}
			}
		}

		// Token: 0x06002D50 RID: 11600 RVA: 0x004902D0 File Offset: 0x0048E4D0
		public void SetCheckArabic(bool check)
		{
			if (check)
			{
				this.bArabicStr = 1;
			}
			else
			{
				this.bArabicStr = 0;
			}
		}

		// Token: 0x06002D51 RID: 11601 RVA: 0x004902EC File Offset: 0x0048E4EC
		private void InitArabicCString(string str)
		{
			int length = str.Length;
			if (this.tmpArabicStr == null)
			{
				this.tmpArabicStr = StringManager.Instance.SpawnString(length);
			}
			else if (this.tmpArabicStr.MaxLength < length)
			{
				StringManager.Instance.DeSpawnString(this.tmpArabicStr);
				this.tmpArabicStr = StringManager.Instance.SpawnString(length);
			}
		}

		// Token: 0x06002D52 RID: 11602 RVA: 0x00490354 File Offset: 0x0048E554
		public void AdjuestUI()
		{
			if (!GUIManager.Instance.IsArabic || base.transform.localScale.x < 0f)
			{
				return;
			}
			this.OriPosition = base.rectTransform.anchoredPosition;
			float x = base.transform.localScale.x;
			base.transform.localScale = new Vector3(base.transform.localScale.x * -1f, base.transform.localScale.y, base.transform.localScale.z);
			TextAnchor alignment = base.alignment;
			switch (alignment)
			{
			case TextAnchor.UpperLeft:
				alignment = TextAnchor.UpperRight;
				break;
			case TextAnchor.UpperRight:
				alignment = TextAnchor.UpperLeft;
				break;
			case TextAnchor.MiddleLeft:
				alignment = TextAnchor.MiddleRight;
				break;
			case TextAnchor.MiddleRight:
				alignment = TextAnchor.MiddleLeft;
				break;
			case TextAnchor.LowerLeft:
				alignment = TextAnchor.LowerRight;
				break;
			case TextAnchor.LowerRight:
				alignment = TextAnchor.LowerLeft;
				break;
			}
			base.alignment = alignment;
			Vector2 anchoredPosition = base.rectTransform.anchoredPosition;
			float width = base.rectTransform.rect.width;
			if (base.rectTransform.pivot.x == 0.5f)
			{
				return;
			}
			if (base.rectTransform.anchorMax.x == 1f && base.rectTransform.anchorMin.x == 0f)
			{
				float num = width * (2f * base.rectTransform.pivot.x - 1f) * x;
				base.rectTransform.offsetMax = new Vector2(base.rectTransform.offsetMax.x - num, base.rectTransform.offsetMax.y);
				base.rectTransform.offsetMin = new Vector2(base.rectTransform.offsetMin.x - num, base.rectTransform.offsetMin.y);
			}
			else
			{
				anchoredPosition.x = (anchoredPosition.x - 2f * base.rectTransform.pivot.x * width + width) * x;
				base.rectTransform.anchoredPosition = anchoredPosition;
			}
		}

		// Token: 0x06002D53 RID: 11603 RVA: 0x004905CC File Offset: 0x0048E7CC
		public Vector2 ArabicFixPos(Vector2 pos)
		{
			if (!GUIManager.Instance.IsArabic || base.rectTransform.localScale.x >= 0f)
			{
				return pos;
			}
			float num = base.rectTransform.localScale.x * -1f;
			float width = base.rectTransform.rect.width;
			pos.x = (pos.x - 2f * base.rectTransform.pivot.x * width + width) * num;
			return pos;
		}

		// Token: 0x06002D54 RID: 11604 RVA: 0x00490668 File Offset: 0x0048E868
		public void UpdateArabicPos()
		{
			if (base.rectTransform.localScale.x >= 0f)
			{
				return;
			}
			Vector2 vector = this.OriPosition;
			vector = this.ArabicFixPos(vector);
			base.rectTransform.anchoredPosition = vector;
		}

		// Token: 0x06002D55 RID: 11605 RVA: 0x004906B0 File Offset: 0x0048E8B0
		public override void SetAllDirty()
		{
			if (this.tmpArabicStr != null && (GUIManager.Instance.IsArabic || this.bArabicStr == 1))
			{
				this.InitArabicCString(this.CheckStr);
				this.m_Text = ArabicTransfer.Instance.Transfer(this.CheckStr, this.tmpArabicStr);
				this.CheckText = ArabicTransfer.Instance.TextState;
			}
			base.SetAllDirty();
		}

		// Token: 0x06002D56 RID: 11606 RVA: 0x00490724 File Offset: 0x0048E924
		public void SetText(string str, eTextCheck check = eTextCheck.Text_None)
		{
			if (str == null)
			{
				return;
			}
			if (check == eTextCheck.Text_None || (byte)(check & eTextCheck.Text_Arabic) > 0)
			{
				this.text = str;
			}
			else if (GUIManager.Instance.IsArabic || this.bArabicStr == 1)
			{
				if (this.CheckStr != str)
				{
					this.m_Text = str;
					this.CheckStr = str;
					this.CheckText = check;
					this.SetVerticesDirty();
					this.SetLayoutDirty();
				}
			}
			else if (this.m_Text != str)
			{
				this.m_Text = str;
				this.CheckText = check;
				this.SetVerticesDirty();
				this.SetLayoutDirty();
			}
		}

		// Token: 0x06002D57 RID: 11607 RVA: 0x004907D4 File Offset: 0x0048E9D4
		public eTextCheck GetTextState()
		{
			if (this.bArabicStr == 1 && this.CheckText == eTextCheck.Text_None)
			{
				this.SetAllDirty();
			}
			return this.CheckText;
		}

		// Token: 0x06002D58 RID: 11608 RVA: 0x004907FC File Offset: 0x0048E9FC
		protected override void OnDestroy()
		{
			if (this.tmpArabicStr != null)
			{
				StringManager.Instance.DeSpawnString(this.tmpArabicStr);
			}
			base.OnDestroy();
		}

		// Token: 0x040079F0 RID: 31216
		private bool _bEmoji;

		// Token: 0x040079F1 RID: 31217
		private UIEmoji m_Emoji;

		// Token: 0x040079F2 RID: 31218
		private byte bArabicStr;

		// Token: 0x040079F3 RID: 31219
		private eTextCheck CheckText;

		// Token: 0x040079F4 RID: 31220
		private CString tmpArabicStr;

		// Token: 0x040079F5 RID: 31221
		private Vector2 OriPosition;

		// Token: 0x040079F6 RID: 31222
		private string CheckStr = string.Empty;

		// Token: 0x040079F7 RID: 31223
		private string CheckColorStr = "color=#";
	}
}
