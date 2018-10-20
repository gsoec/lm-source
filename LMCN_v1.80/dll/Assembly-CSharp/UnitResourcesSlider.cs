using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200088D RID: 2189
public class UnitResourcesSlider : MonoBehaviour, IUISliderBehavior
{
	// Token: 0x06002D76 RID: 11638 RVA: 0x00491B20 File Offset: 0x0048FD20
	public void SetMinValue(long mValue)
	{
		this.MinValue = mValue;
	}

	// Token: 0x06002D77 RID: 11639 RVA: 0x00491B2C File Offset: 0x0048FD2C
	private void Start()
	{
		if (this.m_slider != null)
		{
			this.m_slider.onValueChanged.AddListener(delegate(double fvalue)
			{
				this.SliderValueChange();
			});
			this.m_slider.wholeNumbers = this.bNumber;
		}
	}

	// Token: 0x06002D78 RID: 11640 RVA: 0x00491B78 File Offset: 0x0048FD78
	public void OnButtonDown(UIButton sender)
	{
		if (sender == this.BtnIncrease && !this.bBtnDown)
		{
			this.bBtnDown = true;
			this.bBtnIncrease = true;
		}
		else if (sender == this.BtnLessen && !this.bBtnDown)
		{
			this.bBtnDown = true;
			this.bBtnIncrease = false;
		}
	}

	// Token: 0x06002D79 RID: 11641 RVA: 0x00491BE0 File Offset: 0x0048FDE0
	public void OnButtonUp(UIButton sender)
	{
		if (sender == this.BtnIncrease && this.bBtnIncrease && this.bBtnDown)
		{
			if (this.tmpTime < 0.5f && this.Value < this.MaxValue)
			{
				this.bRefrash = false;
				this.Value += 1L;
				this.m_slider.value = (double)this.Value;
			}
			this.tmpTime = 0f;
			this.tmpTime2 = 0f;
			this.tmpTime3 = 0.1f;
			this.bBtnDown = false;
			this.mAddValueTotal = 2L;
			this.mAddValueCount = 0L;
		}
		else if (sender == this.BtnLessen && !this.bBtnIncrease && this.bBtnDown)
		{
			if (this.tmpTime < 0.5f && this.Value <= this.MaxValue && this.Value > this.MinValue)
			{
				this.bRefrash = false;
				this.Value -= 1L;
				this.m_slider.value = (double)this.Value;
			}
			this.bBtnDown = false;
			this.tmpTime = 0f;
			this.tmpTime2 = 0f;
			this.tmpTime3 = 0.1f;
			this.mAddValueTotal = 2L;
			this.mAddValueCount = 0L;
		}
	}

	// Token: 0x06002D7A RID: 11642 RVA: 0x00491D54 File Offset: 0x0048FF54
	private void InputFieldChange(string tmpStr)
	{
	}

	// Token: 0x06002D7B RID: 11643 RVA: 0x00491D58 File Offset: 0x0048FF58
	public void SliderValueChange()
	{
		if (this.bRefrash)
		{
			this.Value = (long)this.m_slider.value;
			this.Input = this.Value;
		}
		else
		{
			this.bRefrash = true;
		}
		this.m_Handler.OnVauleChang(this);
	}

	// Token: 0x06002D7C RID: 11644 RVA: 0x00491DA8 File Offset: 0x0048FFA8
	public void Refresh_FontTexture()
	{
		if (this.m_inputText != null && this.m_inputText.enabled)
		{
			this.m_inputText.enabled = false;
			this.m_inputText.enabled = true;
		}
		if (this.m_TotalText != null && this.m_TotalText.enabled)
		{
			this.m_TotalText.enabled = false;
			this.m_TotalText.enabled = true;
		}
	}

	// Token: 0x06002D7D RID: 11645 RVA: 0x00491E28 File Offset: 0x00490028
	private void Update()
	{
		if (this.bBtnDown)
		{
			this.tmpTime += Time.smoothDeltaTime;
			if (this.bBtnIncrease && this.Value < this.MaxValue)
			{
				if (this.tmpTime >= 0.5f)
				{
					this.bRefrash = false;
					if (this.tmpTime < 2f)
					{
						this.Value += 1L;
					}
					else if (this.tmpTime > 4f)
					{
						if (0.0008f * this.tmpTime * (float)this.MaxValue > (float)this.mAddValueTotal)
						{
							this.Value += (long)(0.0008f * this.tmpTime * (float)this.MaxValue);
						}
						else
						{
							this.Value += this.mAddValueTotal;
						}
					}
					else
					{
						this.mAddValueCount += 1L;
						if (this.mAddValueCount > 2L)
						{
							this.mAddValueCount = 0L;
							this.mAddValueTotal += 1L;
						}
						this.Value += this.mAddValueTotal;
					}
					if (this.Value > this.MaxValue)
					{
						this.Value = this.MaxValue;
						this.m_slider.value = (double)this.Value;
					}
					else
					{
						this.m_slider.value = (double)this.Value;
					}
				}
			}
			else if (!this.bBtnIncrease && this.Value > this.MinValue && this.tmpTime >= 0.5f)
			{
				this.bRefrash = false;
				if (this.tmpTime < 2f)
				{
					this.Value -= 1L;
				}
				else if (this.tmpTime > 4f)
				{
					if (0.0008f * this.tmpTime * (float)this.MaxValue > (float)this.mAddValueTotal)
					{
						this.Value -= (long)(0.0008f * this.tmpTime * (float)this.MaxValue);
					}
					else
					{
						this.Value -= this.mAddValueTotal;
					}
				}
				else
				{
					this.mAddValueCount += 1L;
					if (this.mAddValueCount > 2L)
					{
						this.mAddValueCount = 0L;
						this.mAddValueTotal += 1L;
					}
					this.Value -= this.mAddValueTotal;
				}
				if (this.Value < this.MinValue)
				{
					this.Value = this.MinValue;
				}
				this.m_slider.value = (double)this.Value;
			}
		}
	}

	// Token: 0x04007A2E RID: 31278
	public UIButton BtnIncrease;

	// Token: 0x04007A2F RID: 31279
	public UIButton BtnLessen;

	// Token: 0x04007A30 RID: 31280
	public UIButton BtnInputText;

	// Token: 0x04007A31 RID: 31281
	public CSlider m_slider;

	// Token: 0x04007A32 RID: 31282
	public InputField m_inputfield;

	// Token: 0x04007A33 RID: 31283
	public UIText m_inputText;

	// Token: 0x04007A34 RID: 31284
	public UIText m_TotalText;

	// Token: 0x04007A35 RID: 31285
	public bool bBtnDown;

	// Token: 0x04007A36 RID: 31286
	public bool bBtnIncrease;

	// Token: 0x04007A37 RID: 31287
	public float tmpTime;

	// Token: 0x04007A38 RID: 31288
	public float tmpTime2;

	// Token: 0x04007A39 RID: 31289
	public float tmpTime3 = 0.1f;

	// Token: 0x04007A3A RID: 31290
	public long Value;

	// Token: 0x04007A3B RID: 31291
	public long MaxValue;

	// Token: 0x04007A3C RID: 31292
	public uint Speed = 3u;

	// Token: 0x04007A3D RID: 31293
	public byte Type;

	// Token: 0x04007A3E RID: 31294
	public long Input = -1L;

	// Token: 0x04007A3F RID: 31295
	public IUIUnitRSliderHandler m_Handler;

	// Token: 0x04007A40 RID: 31296
	public int m_ID;

	// Token: 0x04007A41 RID: 31297
	public bool bRefrash = true;

	// Token: 0x04007A42 RID: 31298
	public bool bNumber = true;

	// Token: 0x04007A43 RID: 31299
	public long BigMaxValue;

	// Token: 0x04007A44 RID: 31300
	private long MinValue;

	// Token: 0x04007A45 RID: 31301
	private long mAddValueTotal = 2L;

	// Token: 0x04007A46 RID: 31302
	private long mAddValueCount;
}
