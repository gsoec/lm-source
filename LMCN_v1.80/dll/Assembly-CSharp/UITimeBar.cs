using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200088B RID: 2187
public class UITimeBar : MonoBehaviour, IUIButtonClickHandler
{
	// Token: 0x06002D62 RID: 11618 RVA: 0x00490BE8 File Offset: 0x0048EDE8
	public void InitTimeBar()
	{
		this.m_TimerSpriteType = eTimerSpriteType.Speed;
		this.m_Type = eTimeBarType.NormalType;
		if (this.m_CancelBtn != null)
		{
			this.m_CancelBtn.m_BtnID1 = 1;
			this.m_CancelBtn.m_Handler = this;
		}
		if (this.m_FuntionBtn != null)
		{
			this.m_FuntionBtn.m_BtnID1 = 2;
			this.m_FuntionBtn.m_Handler = this;
		}
		if (this.m_TitleText && this.m_CanvasGroup == null)
		{
			this.m_CanvasGroup = this.m_TitleText.gameObject.AddComponent<CanvasGroup>();
		}
	}

	// Token: 0x06002D63 RID: 11619 RVA: 0x00490C8C File Offset: 0x0048EE8C
	public unsafe void SetChar(string s, int index, char ch)
	{
		if (index < 0 || index >= s.Length)
		{
			return;
		}
		fixed (string text = s)
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				ptr[index] = ch;
				text = null;
				return;
			}
		}
	}

	// Token: 0x06002D64 RID: 11620 RVA: 0x00490CC4 File Offset: 0x0048EEC4
	public void SetValue(long begin, long target)
	{
		this.SetTargetTime(target);
		this.SetBeginTime(begin);
	}

	// Token: 0x06002D65 RID: 11621 RVA: 0x00490CD4 File Offset: 0x0048EED4
	private void SetTargetTime(long target)
	{
		this.m_TargetValue = target;
	}

	// Token: 0x06002D66 RID: 11622 RVA: 0x00490CE0 File Offset: 0x0048EEE0
	private void SetBeginTime(long begin)
	{
		this.m_BeginValue = begin;
	}

	// Token: 0x06002D67 RID: 11623 RVA: 0x00490CEC File Offset: 0x0048EEEC
	public void SetFunctionBtn()
	{
		if (this.m_CancelBtn != null)
		{
			this.m_CancelBtn.m_BtnID1 = 1;
		}
		if (this.m_FuntionBtn != null)
		{
			this.m_FuntionBtn.m_BtnID1 = 2;
		}
	}

	// Token: 0x06002D68 RID: 11624 RVA: 0x00490D34 File Offset: 0x0048EF34
	public void SetTime(int dd, int hh, int mm, int ss)
	{
		if (this.m_TimeText != null && dd >= 0 && hh >= 0 && mm >= 0 && ss >= 0)
		{
			this.tempStringCount = 0;
			if (dd > 0)
			{
				if (dd < 10)
				{
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd]);
				}
				else if (dd < 100)
				{
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd / 10]);
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd % 10]);
				}
				else if (dd < 1000)
				{
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd / 100]);
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd % 100 / 10]);
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd % 10]);
				}
				else if (dd < 10000)
				{
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd / 1000]);
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd / 100 % 10]);
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd / 10 % 10]);
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[dd % 10]);
				}
				this.SetChar(this.tempString, this.tempStringCount++, this.numChar[10]);
				if (this.m_Type == eTimeBarType.SpeedupType)
				{
					if (dd > 0)
					{
						this.SetChar(this.tempString, this.tempStringCount++, ' ');
						if (hh > 0)
						{
							this.SetChar(this.tempString, this.tempStringCount++, this.numChar[hh / 10]);
						}
					}
					if (hh > 0)
					{
						if (dd <= 0)
						{
							this.SetChar(this.tempString, this.tempStringCount++, this.numChar[hh / 10]);
						}
						this.SetChar(this.tempString, this.tempStringCount++, this.numChar[hh % 10]);
						this.SetChar(this.tempString, this.tempStringCount++, ':');
					}
					if (hh > 0 || mm >= 10)
					{
						this.SetChar(this.tempString, this.tempStringCount++, this.numChar[mm / 10]);
					}
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[mm % 10]);
					this.SetChar(this.tempString, this.tempStringCount++, ':');
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[ss / 10]);
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[ss % 10]);
				}
			}
			else
			{
				if (hh > 0)
				{
					if (hh >= 10)
					{
						this.SetChar(this.tempString, this.tempStringCount++, this.numChar[hh / 10]);
					}
					this.SetChar(this.tempString, this.tempStringCount++, this.numChar[hh % 10]);
					this.SetChar(this.tempString, this.tempStringCount++, ':');
				}
				this.SetChar(this.tempString, this.tempStringCount++, this.numChar[mm / 10]);
				this.SetChar(this.tempString, this.tempStringCount++, this.numChar[mm % 10]);
				this.SetChar(this.tempString, this.tempStringCount++, ':');
				this.SetChar(this.tempString, this.tempStringCount++, this.numChar[ss / 10]);
				this.SetChar(this.tempString, this.tempStringCount++, this.numChar[ss % 10]);
			}
			this.SetChar(this.tempString, this.tempStringCount++, '\0');
		}
		this.m_TimeText.text = this.tempString;
		if (this.m_Type == eTimeBarType.IconType && this.m_TimerSpriteType != eTimerSpriteType.Idle)
		{
			float num = 0f;
			int length = this.tempString.Length;
			CharacterInfo characterInfo = default(CharacterInfo);
			GUIManager.Instance.GetTTFFont().RequestCharactersInTexture(this.tempString, 18);
			int num2 = 0;
			while (num2 < this.tempStringCount && this.tempStringCount < length)
			{
				if (GUIManager.Instance.GetTTFFont().GetCharacterInfo(this.tempString[num2], out characterInfo, 18))
				{
					num += characterInfo.width;
				}
				else
				{
					num += 16f;
				}
				num2++;
			}
			Vector2 sizeDelta = this.m_TimeText.rectTransform.sizeDelta;
			sizeDelta.x = num;
			this.m_TimeText.rectTransform.sizeDelta = sizeDelta;
			sizeDelta = ((RectTransform)base.transform).sizeDelta;
			sizeDelta.x = sizeDelta.x - 40f - 20f - num;
			this.m_TitleText.rectTransform.sizeDelta = sizeDelta;
			this.m_TitleText.SetAllDirty();
			this.m_TitleText.cachedTextGeneratorForLayout.Invalidate();
			this.m_TitleText.cachedTextGenerator.Invalidate();
		}
		if (this.m_Type == eTimeBarType.CancelType)
		{
			float preferredWidth = this.m_TimeText.preferredWidth;
			Vector2 sizeDelta2 = this.m_TimeText.rectTransform.sizeDelta;
			sizeDelta2.x = preferredWidth;
			this.m_TimeText.rectTransform.sizeDelta = sizeDelta2;
			sizeDelta2 = ((RectTransform)base.transform).sizeDelta;
			sizeDelta2.x = 200f - preferredWidth;
			this.m_TitleText.rectTransform.sizeDelta = sizeDelta2;
			this.m_TitleText.SetAllDirty();
			this.m_TitleText.cachedTextGeneratorForLayout.Invalidate();
			this.m_TitleText.cachedTextGenerator.Invalidate();
		}
		if (this.m_Type == eTimeBarType.NormalType)
		{
			float preferredWidth2 = this.m_TimeText.preferredWidth;
			Vector2 sizeDelta3 = this.m_TimeText.rectTransform.sizeDelta;
			sizeDelta3.x = preferredWidth2;
			this.m_TimeText.rectTransform.sizeDelta = sizeDelta3;
			sizeDelta3 = ((RectTransform)base.transform).sizeDelta;
			sizeDelta3.x = 240f - preferredWidth2;
			this.m_TitleText.rectTransform.sizeDelta = sizeDelta3;
			this.m_TitleText.SetAllDirty();
			this.m_TitleText.cachedTextGeneratorForLayout.Invalidate();
			this.m_TitleText.cachedTextGenerator.Invalidate();
		}
		if (this.m_TitleText != null)
		{
			this.m_TitleText.UpdateArabicPos();
		}
		if (this.m_TimeText != null)
		{
			this.m_TimeText.UpdateArabicPos();
		}
		this.m_TimeText.SetAllDirty();
		this.m_TimeText.cachedTextGeneratorForLayout.Invalidate();
		this.m_TimeText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002D69 RID: 11625 RVA: 0x004915C8 File Offset: 0x0048F7C8
	public bool UpdateTime(double nowTime)
	{
		if (this.m_NotifyTime != 0L && DataManager.Instance.ServerTime >= this.m_NotifyTime)
		{
			this.m_NotifyTime = 0L;
			if (this.m_Handler != null)
			{
				this.m_Handler.OnNotify(this);
			}
		}
		if (this.m_TargetValue == 0L)
		{
			if (this.m_Type == eTimeBarType.IconType)
			{
				this.m_SliderImage.fillAmount = 0f;
			}
			else
			{
				this.m_SliderRectTransform.sizeDelta = new Vector2(0f, this.TimeBarSizeY);
			}
		}
		else
		{
			double num;
			if (nowTime - (double)this.m_BeginValue > (double)(this.m_TargetValue - this.m_BeginValue))
			{
				num = (double)(this.m_TargetValue - this.m_BeginValue);
			}
			else if (nowTime - (double)this.m_BeginValue < 0.0)
			{
				num = 0.0;
			}
			else
			{
				num = nowTime - (double)this.m_BeginValue;
			}
			long num2 = this.m_TargetValue - this.m_BeginValue;
			this.valueSize = (float)(num / (double)num2);
			if (this.m_Type == eTimeBarType.IconType)
			{
				if (this.m_SliderRectTransform != null)
				{
					this.m_SliderRectTransform.sizeDelta = new Vector2(this.TimeBarSizeX, this.TimeBarSizeY);
					if (this.m_SliderImage != null)
					{
						this.m_SliderImage.fillAmount = this.valueSize;
					}
				}
			}
			else if (this.m_SliderRectTransform != null)
			{
				this.m_SliderRectTransform.sizeDelta = new Vector2(this.valueSize * this.TimeBarSizeX, this.TimeBarSizeY);
			}
		}
		double num3;
		if ((double)this.m_TargetValue - nowTime > (double)(this.m_TargetValue - this.m_BeginValue))
		{
			num3 = (double)(this.m_TargetValue - this.m_BeginValue);
		}
		else if ((double)this.m_TargetValue - nowTime < 0.0)
		{
			num3 = 0.0;
		}
		else
		{
			num3 = (double)this.m_TargetValue - nowTime;
		}
		if (num3 < 0.0)
		{
			return false;
		}
		if (nowTime > (double)this.m_BeginValue && nowTime >= (double)this.m_TargetValue)
		{
			if (this.m_Handler != null)
			{
				this.m_Handler.OnTimer(this);
			}
			this.SetTime(0, 0, 0, 0);
			return true;
		}
		return false;
	}

	// Token: 0x06002D6A RID: 11626 RVA: 0x0049181C File Offset: 0x0048FA1C
	public void UpdateTimeText(long nowTime)
	{
		double num;
		if (this.m_TargetValue - nowTime > this.m_TargetValue - this.m_BeginValue)
		{
			num = (double)(this.m_TargetValue - this.m_BeginValue);
		}
		else if (this.m_TargetValue - nowTime < 0L)
		{
			num = 0.0;
		}
		else
		{
			num = (double)(this.m_TargetValue - nowTime);
		}
		if (num >= 0.0)
		{
			int ss = (int)num % 60;
			int mm = (int)(num / 60.0) % 60;
			int hh = (int)(num % 86400.0) / 3600;
			int dd = (int)num / 86400;
			this.SetTime(dd, hh, mm, ss);
		}
	}

	// Token: 0x06002D6B RID: 11627 RVA: 0x004918CC File Offset: 0x0048FACC
	private void Update()
	{
	}

	// Token: 0x06002D6C RID: 11628 RVA: 0x004918D0 File Offset: 0x0048FAD0
	public void OnButtonClick(UIButton sender)
	{
		Door x = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		int btnID = sender.m_BtnID1;
		if (btnID != 1)
		{
			if (btnID == 2)
			{
				if (x != null && this.m_Handler != null)
				{
					this.m_Handler.Onfunc(this);
				}
			}
		}
		else if (this.m_Handler != null)
		{
			this.m_Handler.OnCancel(this);
		}
	}

	// Token: 0x06002D6D RID: 11629 RVA: 0x0049194C File Offset: 0x0048FB4C
	public int GetTextIndex()
	{
		return this.m_TextIdx;
	}

	// Token: 0x06002D6E RID: 11630 RVA: 0x00491954 File Offset: 0x0048FB54
	public void SetFlashCount(float count, int TextIdx)
	{
	}

	// Token: 0x06002D6F RID: 11631 RVA: 0x00491958 File Offset: 0x0048FB58
	public void ResetTickTime()
	{
	}

	// Token: 0x06002D70 RID: 11632 RVA: 0x0049195C File Offset: 0x0048FB5C
	public void SetTitleText()
	{
		int textIdx = GUIManager.Instance.m_TextIdx;
		if (textIdx >= 0 && textIdx < this.m_Titles.Length)
		{
			this.m_Title = this.m_Titles[textIdx];
			this.m_TitleText.text = this.m_Title;
			this.m_TitleText.SetAllDirty();
			this.m_TitleText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06002D71 RID: 11633 RVA: 0x004919C4 File Offset: 0x0048FBC4
	public void SetTitleTextColor()
	{
		if (this.m_CanvasGroup != null)
		{
			this.m_CanvasGroup.alpha = GUIManager.Instance.m_FlashCount;
		}
	}

	// Token: 0x06002D72 RID: 11634 RVA: 0x004919F8 File Offset: 0x0048FBF8
	public void Refresh_FontTexture()
	{
		if (this.m_TitleText != null && this.m_TitleText.enabled)
		{
			this.m_TitleText.enabled = false;
			this.m_TitleText.enabled = true;
		}
		if (this.m_TimeText != null && this.m_TimeText.enabled)
		{
			this.m_TimeText.enabled = false;
			this.m_TimeText.enabled = true;
		}
		if (this.m_FuntionBtn != null && this.m_FuntionBtn.transform.childCount > 0)
		{
			UIText component = this.m_FuntionBtn.transform.GetChild(0).GetComponent<UIText>();
			if (component != null && component.enabled)
			{
				component.enabled = false;
				component.enabled = true;
			}
		}
	}

	// Token: 0x04007A0F RID: 31247
	public float TimeBarSizeX = 300f;

	// Token: 0x04007A10 RID: 31248
	public float TimeBarSizeY = 40f;

	// Token: 0x04007A11 RID: 31249
	private long m_TargetValue;

	// Token: 0x04007A12 RID: 31250
	private long m_BeginValue;

	// Token: 0x04007A13 RID: 31251
	private string m_Title = "Upgrading";

	// Token: 0x04007A14 RID: 31252
	public string[] m_Titles = new string[]
	{
		string.Empty,
		string.Empty
	};

	// Token: 0x04007A15 RID: 31253
	private int m_TextIdx;

	// Token: 0x04007A16 RID: 31254
	private float m_TickTime = 1f;

	// Token: 0x04007A17 RID: 31255
	private string tempString = new string('\0', 15);

	// Token: 0x04007A18 RID: 31256
	private char[] numChar = new char[]
	{
		'0',
		'1',
		'2',
		'3',
		'4',
		'5',
		'6',
		'7',
		'8',
		'9',
		'd'
	};

	// Token: 0x04007A19 RID: 31257
	private int tempStringCount;

	// Token: 0x04007A1A RID: 31258
	private float m_BeginChangeTime = 3f;

	// Token: 0x04007A1B RID: 31259
	private float m_ChangeTime;

	// Token: 0x04007A1C RID: 31260
	private float m_FlashCount;

	// Token: 0x04007A1D RID: 31261
	public Image m_FlashImage;

	// Token: 0x04007A1E RID: 31262
	public IUTimeBarOnTimer m_Handler;

	// Token: 0x04007A1F RID: 31263
	public int m_TimeBarID;

	// Token: 0x04007A20 RID: 31264
	public int m_ListID;

	// Token: 0x04007A21 RID: 31265
	public RectTransform m_SliderRectTransform;

	// Token: 0x04007A22 RID: 31266
	public Image m_BackgroundImage;

	// Token: 0x04007A23 RID: 31267
	public Image m_SliderImage;

	// Token: 0x04007A24 RID: 31268
	public UIText m_TitleText;

	// Token: 0x04007A25 RID: 31269
	public UIText m_TimeText;

	// Token: 0x04007A26 RID: 31270
	public int m_Tag;

	// Token: 0x04007A27 RID: 31271
	public long m_NotifyTime;

	// Token: 0x04007A28 RID: 31272
	public UIButton m_CancelBtn;

	// Token: 0x04007A29 RID: 31273
	public UIButton m_FuntionBtn;

	// Token: 0x04007A2A RID: 31274
	public float valueSize;

	// Token: 0x04007A2B RID: 31275
	public eTimeBarType m_Type;

	// Token: 0x04007A2C RID: 31276
	public eTimerSpriteType m_TimerSpriteType;

	// Token: 0x04007A2D RID: 31277
	private CanvasGroup m_CanvasGroup;
}
