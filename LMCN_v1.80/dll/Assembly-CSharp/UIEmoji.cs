using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200086C RID: 2156
public class UIEmoji
{
	// Token: 0x06002C6D RID: 11373 RVA: 0x0048A1FC File Offset: 0x004883FC
	public void InitSetting(bool mbOneLine, float mTextWidthMax)
	{
		this.bOneLine = mbOneLine;
		this.TextWidthMax = mTextWidthMax;
	}

	// Token: 0x06002C6E RID: 11374 RVA: 0x0048A20C File Offset: 0x0048840C
	public int GetEmojiCount()
	{
		return this.emojiReplacements.Count;
	}

	// Token: 0x06002C6F RID: 11375 RVA: 0x0048A21C File Offset: 0x0048841C
	private int GetSurrogateMaxSize(string str, int beginID)
	{
		int i;
		for (i = 0; i < 4; i++)
		{
			int num = beginID + i;
			if (num >= str.Length)
			{
				break;
			}
			if (!char.IsSurrogate(str[num]))
			{
				break;
			}
		}
		return i;
	}

	// Token: 0x06002C70 RID: 11376 RVA: 0x0048A26C File Offset: 0x0048846C
	public void CheckEmojiText()
	{
		this.mString = this.m_Text;
		DataManager instance = DataManager.Instance;
		this.emojiReplacements.Clear();
		int i = 0;
		GUIManager instance2 = GUIManager.Instance;
		this.tmpType = 0;
		this.bHasCut = -1;
		this.TextWidth = 0f;
		this.tmpSb.Length = 0;
		instance2.MsgStr.ClearString();
		while (i < this.mString.Length)
		{
			if (this.mString[i] == '\0' || (this.bOneLine && this.mString[i] == '\n'))
			{
				i += this.mString.Length;
				break;
			}
			int num = this.GetSurrogateMaxSize(this.mString, i);
			bool flag;
			bool flag2;
			if (num == 4)
			{
				flag = char.IsSurrogatePair(this.mString[i], this.mString[i + 1]);
				flag2 = char.IsSurrogatePair(this.mString[i + 2], this.mString[i + 3]);
			}
			else if (num >= 2)
			{
				flag = char.IsSurrogatePair(this.mString[i], this.mString[i + 1]);
				flag2 = false;
			}
			else
			{
				flag2 = (flag = false);
			}
			if (flag && flag2)
			{
				string text = Convert.ToString(char.ConvertToUtf32(this.mString[i], this.mString[i + 1]), 16) + "-" + Convert.ToString(char.ConvertToUtf32(this.mString[i + 2], this.mString[i + 3]), 16);
				if (instance2.m_EmojiSpriteAsset.m_Dict.ContainsKey(text.GetHashCode()))
				{
					this.tmpSb.Append(UIEmoji.emSpace);
					this.emojiReplacements.Add(new UIEmoji.PosStringTuple(this.tmpSb.Length - 1, text));
					i += 4;
					continue;
				}
			}
			if (flag)
			{
				string text = Convert.ToString(char.ConvertToUtf32(this.mString, i), 16);
				if (instance2.m_EmojiSpriteAsset.m_Dict.ContainsKey(text.GetHashCode()))
				{
					this.tmpSb.Append(UIEmoji.emSpace);
					this.emojiReplacements.Add(new UIEmoji.PosStringTuple(this.tmpSb.Length - 1, text));
					i += 2;
					continue;
				}
				num = 1;
			}
			if (num == 1)
			{
				int num2 = (int)(this.mString[i] - '\ud800');
				if (num2 < 0 || num2 > 2047)
				{
					string text = Convert.ToString((int)this.mString[i], 16);
					this.tmpSb.Append(UIEmoji.emSpace);
					this.emojiReplacements.Add(new UIEmoji.PosStringTuple(this.tmpSb.Length - 1, text));
					i++;
					continue;
				}
			}
			if (this.mString[i] == '<' && (this.mString[i + 1] == 'c' || this.mString[i + 1] == '/'))
			{
				if (this.mString[i + 1] == 'c')
				{
					this.tmpType = 1;
				}
				else if (this.tmpType == 1)
				{
					this.tmpType = 0;
				}
				this.tmpSb.Append(this.mString[i]);
				this.tmpSb.Append(this.mString[i + 1]);
				int num3 = 2;
				while (this.mString[i + num3] != '>' && i + num3 < this.mString.Length)
				{
					this.tmpSb.Append(this.mString[i + num3]);
					num3++;
				}
				i += num3;
			}
			else
			{
				if (!instance.isNotEmojiCharacter(this.mString[i]))
				{
					this.tmpSb.Append(" ");
				}
				else
				{
					this.tmpSb.Append(this.mString[i]);
				}
				i++;
				if (this.bHasCut != -1 && this.tmpType == 1)
				{
					this.tmpSb.Append("</color>");
				}
			}
		}
		this.m_Text = this.tmpSb.ToString();
		if (this.bOneLine)
		{
			this.CheckTextWidth();
		}
		this.m_UIText.SetAllDirty();
		this.m_UIText.cachedTextGenerator.Invalidate();
		Vector2 vector = new Vector2(0f, 0f);
		Vector2 vector2 = new Vector2(1f, 1f);
		Quaternion localRotation = default(Quaternion);
		if (this.mEmojiT == null)
		{
			GameObject gameObject = new GameObject("Emoji");
			gameObject.layer = 5;
			RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
			this.mEmojiT = gameObject.transform;
			gameObject.transform.SetParent(this.m_UIText.transform, false);
			rectTransform.sizeDelta = new Vector2(this.TextWidthMax, 30f);
			rectTransform.anchorMin = new Vector2(0f, 1f);
			rectTransform.anchorMax = new Vector2(0f, 1f);
			rectTransform.pivot = new Vector2(0f, 1f);
		}
		else if (this.mEmojiT.childCount != 0)
		{
			for (int j = 0; j < this.mEmojiT.childCount; j++)
			{
				Image image = this.mEmojiT.GetChild(j).GetComponent<Image>();
				image.enabled = false;
			}
		}
		for (int k = 0; k < this.emojiReplacements.Count; k++)
		{
			int pos = this.emojiReplacements[k].pos;
			if (this.mEmojiT.childCount <= k)
			{
				GameObject gameObject = new GameObject("Img");
				gameObject.layer = 5;
				gameObject.transform.SetParent(this.mEmojiT);
				RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0f, 1f);
				rectTransform.anchorMax = new Vector2(0f, 1f);
				rectTransform.pivot = new Vector2(0f, 1f);
				rectTransform.sizeDelta = new Vector2(36f, 36f);
				Image image = gameObject.AddComponent<Image>();
				image.sprite = instance2.LoadEmojiSprite(this.emojiReplacements[k].emoji);
				image.material = instance2.GetEmojiMaterial();
				localRotation.eulerAngles = Vector3.zero;
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localRotation = localRotation;
			}
			else
			{
				Image image = this.mEmojiT.GetChild(k).GetComponent<Image>();
				image.sprite = instance2.LoadEmojiSprite(this.emojiReplacements[k].emoji);
				image.enabled = true;
			}
		}
	}

	// Token: 0x06002C71 RID: 11377 RVA: 0x0048A9B4 File Offset: 0x00488BB4
	public void CheckTextWidth()
	{
		this.m_UIText.font.RequestCharactersInTexture(this.m_Text, this.m_UIText.fontSize);
		CharacterInfo characterInfo = default(CharacterInfo);
		this.mString = this.m_Text;
		int i = 0;
		int num = 0;
		int length = this.tmpSb.Length;
		this.tmpSb.Length = 0;
		while (i < this.mString.Length)
		{
			if (this.mString[i] == '<' && (this.mString[i + 1] == 'c' || this.mString[i + 1] == '/'))
			{
				if (this.mString[i + 1] == 'c')
				{
					this.tmpType = 1;
				}
				else if (this.tmpType == 1)
				{
					this.tmpType = 0;
				}
				this.tmpSb.Append(this.mString[i]);
				this.tmpSb.Append(this.mString[i + 1]);
				int num2 = 2;
				while (this.mString[i + num2] != '>' && i + num2 < this.mString.Length)
				{
					this.tmpSb.Append(this.mString[i + num2]);
					num2++;
				}
				if (i + num2 < this.mString.Length)
				{
					this.tmpSb.Append(this.mString[i + num2]);
					num2++;
				}
				i += num2;
			}
			else
			{
				if (this.m_UIText.font.GetCharacterInfo(this.mString[i], out characterInfo, this.m_UIText.fontSize))
				{
					if (this.TextWidth + characterInfo.width < this.TextWidthMax)
					{
						if (this.mString[i] == UIEmoji.emSpace)
						{
							num++;
						}
						this.tmpSb.Append(this.mString[i]);
						this.TextWidth += characterInfo.width;
						i++;
					}
					else
					{
						this.bHasCut = i;
						this.tmpSb.Append("...");
						i += this.mString.Length;
					}
				}
				else
				{
					this.tmpSb.Append(this.mString[i]);
					this.TextWidth += (float)this.m_UIText.fontSize;
					i++;
				}
				if (this.bHasCut != -1)
				{
					if (this.tmpType == 1)
					{
						this.tmpSb.Append("</color>");
					}
					else if (this.tmpType == 2)
					{
						this.tmpSb.Append(">");
					}
				}
			}
		}
		this.m_Text = this.tmpSb.ToString();
		if (this.emojiReplacements.Count != 0)
		{
			for (int j = this.emojiReplacements.Count - 1; j >= num; j--)
			{
				this.emojiReplacements.RemoveAt(j);
			}
		}
	}

	// Token: 0x06002C72 RID: 11378 RVA: 0x0048ACF0 File Offset: 0x00488EF0
	public void ShowEmojiImage()
	{
		this.m_UIText.font.RequestCharactersInTexture(this.m_Text, this.m_UIText.fontSize);
		CharacterInfo characterInfo = default(CharacterInfo);
		GUIManager instance = GUIManager.Instance;
		TextGenerator cachedTextGenerator = this.m_UIText.cachedTextGenerator;
		Vector3 localPosition = default(Vector3);
		Quaternion localRotation = default(Quaternion);
		this.mString = this.m_Text;
		TextGenerationSettings generationSettings = this.m_UIText.GetGenerationSettings(Vector2.zero);
		float num = 36f;
		if (this.m_UIText.font.GetCharacterInfo(UIEmoji.emSpace, out characterInfo, this.m_UIText.fontSize))
		{
			num = characterInfo.width / 36f;
		}
		for (int i = 0; i < this.emojiReplacements.Count; i++)
		{
			int pos = this.emojiReplacements[i].pos;
			float num2 = 0f;
			int num3 = 0;
			Image component = this.mEmojiT.GetChild(i).GetComponent<Image>();
			component.sprite = instance.LoadEmojiSprite(this.emojiReplacements[i].emoji);
			if (pos >= cachedTextGenerator.characterCount)
			{
				localPosition = Vector3.zero;
			}
			else
			{
				if (!this.bOneLine)
				{
					for (int j = cachedTextGenerator.lines.Count - 1; j > 0; j--)
					{
						if (pos > cachedTextGenerator.lines[j].startCharIdx)
						{
							num3 = cachedTextGenerator.lines[j].startCharIdx;
							break;
						}
					}
				}
				this.mString = this.m_Text.Substring(num3, pos - num3);
				float x = this.m_UIText.cachedTextGeneratorForLayout.GetPreferredWidth(this.mString, generationSettings) / this.m_UIText.pixelsPerUnit;
				if (!this.bOneLine)
				{
					for (int k = 0; k < cachedTextGenerator.lines.Count; k++)
					{
						if (pos == cachedTextGenerator.lines[k].startCharIdx)
						{
							x = 0f;
							break;
						}
					}
					num2 = cachedTextGenerator.characters[pos].cursorPos.y;
					num2 -= cachedTextGenerator.characters[0].cursorPos.y;
				}
				localPosition = new Vector3(x, num2, 0f);
			}
			component.transform.localPosition = localPosition;
			localRotation.eulerAngles = Vector3.zero;
			component.transform.localRotation = localRotation;
			component.transform.localScale = new Vector3(num, num, num);
		}
	}

	// Token: 0x06002C73 RID: 11379 RVA: 0x0048AFD0 File Offset: 0x004891D0
	private void Start()
	{
	}

	// Token: 0x06002C74 RID: 11380 RVA: 0x0048AFD4 File Offset: 0x004891D4
	private void Update()
	{
	}

	// Token: 0x0400793F RID: 31039
	public string mString = string.Empty;

	// Token: 0x04007940 RID: 31040
	public string mString2 = string.Empty;

	// Token: 0x04007941 RID: 31041
	private List<UIEmoji.PosStringTuple> emojiReplacements = new List<UIEmoji.PosStringTuple>();

	// Token: 0x04007942 RID: 31042
	private static char emSpace = '\u2001';

	// Token: 0x04007943 RID: 31043
	private float TextWidth;

	// Token: 0x04007944 RID: 31044
	public float TextWidthMax;

	// Token: 0x04007945 RID: 31045
	public bool bOneLine;

	// Token: 0x04007946 RID: 31046
	private StringBuilder tmpSb = new StringBuilder();

	// Token: 0x04007947 RID: 31047
	private Transform mEmojiT;

	// Token: 0x04007948 RID: 31048
	private byte tmpType;

	// Token: 0x04007949 RID: 31049
	private int bHasCut = -1;

	// Token: 0x0400794A RID: 31050
	public UIText m_UIText;

	// Token: 0x0400794B RID: 31051
	private string m_Text;

	// Token: 0x0200086D RID: 2157
	private struct PosStringTuple
	{
		// Token: 0x06002C75 RID: 11381 RVA: 0x0048AFD8 File Offset: 0x004891D8
		public PosStringTuple(int p, string s)
		{
			this.pos = p;
			this.emoji = s;
		}

		// Token: 0x0400794C RID: 31052
		public int pos;

		// Token: 0x0400794D RID: 31053
		public string emoji;
	}
}
