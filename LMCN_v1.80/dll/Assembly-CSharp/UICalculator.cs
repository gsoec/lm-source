using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200086B RID: 2155
public class UICalculator : IUIButtonClickHandler
{
	// Token: 0x06002C65 RID: 11365 RVA: 0x00489814 File Offset: 0x00487A14
	public void OpenCalculator(long mMaxValue, long mValue, float PosX = 0f, float PosY = 0f, UnitResourcesSlider URS = null, long mMinValue = 0L)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		if (this.GUIM.Obj_UICalculator != null)
		{
			return;
		}
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		UnityEngine.Object @object = this.GUIM.m_CalculatorAssetBundle.Load("UICalculator");
		if (@object == null)
		{
			return;
		}
		if (this.GUIM.m_CalculatorStr == null)
		{
			this.GUIM.m_CalculatorStr = StringManager.Instance.SpawnString(30);
		}
		this.GUIM.Obj_UICalculator = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.GUIM.Obj_UICalculator.transform.SetParent(this.GUIM.m_SecWindowLayer, false);
		if (URS != null)
		{
			this.mUnitRslider = URS;
		}
		this.bOpen = true;
		RectTransform component = this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>();
		UIButton component2 = this.GUIM.Obj_UICalculator.transform.GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 1;
		component2.image.color = new Color(1f, 1f, 1f, 0f);
		component2.m_EffectType = e_EffectType.e_Scale;
		component2.transition = Selectable.Transition.None;
		Image component3 = this.GUIM.Obj_UICalculator.transform.GetChild(1).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			component3.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		this.CalculatorRT = this.GUIM.Obj_UICalculator.transform.GetChild(1).GetComponent<RectTransform>();
		if (PosX > 0f && PosX + 137f >= component.sizeDelta.x / 2f)
		{
			PosX = component.sizeDelta.x / 2f - 137f;
		}
		else if (PosX < 0f && PosX - 137f < -component.sizeDelta.x / 2f)
		{
			PosX = -component.sizeDelta.x / 2f + 137f;
		}
		if (PosY > 0f && PosY - 163f >= 163f)
		{
			PosY = component.sizeDelta.y / 2f - 163f;
		}
		else if (PosY < 0f && PosY - 163f < -component.sizeDelta.y)
		{
			PosY = -component.sizeDelta.y / 2f + 163f;
		}
		this.CalculatorRT.anchoredPosition = new Vector2(PosX, PosY);
		Transform child = this.GUIM.Obj_UICalculator.transform.GetChild(1);
		for (int i = 0; i < 9; i++)
		{
			component2 = child.GetChild(i).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 2 + i;
			component2.m_EffectType = e_EffectType.e_Scale;
			component2.transition = Selectable.Transition.None;
			this.text_Str[i] = child.GetChild(i).GetChild(0).GetComponent<Text>();
			this.text_Str[i].font = this.GUIM.GetTTFFont();
			this.text_Str[i].text = (i + 1).ToString();
		}
		component2 = child.GetChild(9).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 11;
		component2.m_EffectType = e_EffectType.e_Scale;
		component2.transition = Selectable.Transition.None;
		this.text_Str[9] = child.GetChild(9).GetChild(0).GetComponent<Text>();
		this.text_Str[9].font = this.GUIM.GetTTFFont();
		this.text_Str[9].text = GameConstants.numChar[0].ToString();
		component2 = child.GetChild(10).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 12;
		component2.m_EffectType = e_EffectType.e_Scale;
		component2.transition = Selectable.Transition.None;
		component3 = child.GetChild(10).GetChild(0).GetComponent<Image>();
		component3.SetNativeSize();
		component2 = child.GetChild(11).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 13;
		component2.m_EffectType = e_EffectType.e_Scale;
		component2.transition = Selectable.Transition.None;
		component3 = child.GetChild(11).GetChild(0).GetComponent<Image>();
		component3.SetNativeSize();
		this.MaxValue = mMaxValue;
		this.tmpValue = mValue;
		this.MinValue = mMinValue;
		component3 = child.GetChild(12).GetComponent<Image>();
		this.ImgRT = child.GetChild(12).GetChild(0).GetComponent<RectTransform>();
		component3 = child.GetChild(12).GetChild(0).GetComponent<Image>();
		this.text_Value = child.GetChild(12).GetChild(1).GetComponent<Text>();
		this.text_Value.font = this.GUIM.GetTTFFont();
		this.GUIM.m_CalculatorStr.ClearString();
		StringManager.IntToStr(this.GUIM.m_CalculatorStr, this.tmpValue, 1, true);
		this.text_Value.text = this.GUIM.m_CalculatorStr.ToString();
		this.text_Value.SetAllDirty();
		this.text_Value.cachedTextGenerator.Invalidate();
		this.text_Value.cachedTextGeneratorForLayout.Invalidate();
		this.ImgRT.sizeDelta = new Vector2(this.text_Value.preferredWidth + 4f, this.ImgRT.sizeDelta.y);
	}

	// Token: 0x06002C66 RID: 11366 RVA: 0x00489DF4 File Offset: 0x00487FF4
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 1:
			UnityEngine.Object.Destroy(this.GUIM.Obj_UICalculator);
			this.GUIM.Obj_UICalculator = null;
			this.mUnitRslider = null;
			break;
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
			this.SetNum(sender.m_BtnID1 - 1);
			break;
		case 11:
			this.SetNum(sender.m_BtnID1 - 11);
			break;
		case 12:
			if (this.bOpen)
			{
				this.bOpen = false;
				this.ImgRT.gameObject.SetActive(false);
				this.tmpValue = 0L;
			}
			else
			{
				this.tmpValue /= 10L;
			}
			this.GUIM.m_CalculatorStr.ClearString();
			StringManager.IntToStr(this.GUIM.m_CalculatorStr, this.tmpValue, 1, true);
			this.text_Value.text = this.GUIM.m_CalculatorStr.ToString();
			this.text_Value.SetAllDirty();
			this.text_Value.cachedTextGenerator.Invalidate();
			break;
		case 13:
			if (this.tmpValue < this.MinValue)
			{
				this.GUIM.MsgStr.ClearString();
				this.GUIM.MsgStr.IntToFormat(this.MinValue, 1, false);
				this.GUIM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(8537u));
				this.GUIM.AddHUDMessage(this.GUIM.MsgStr.ToString(), 255, true);
				return;
			}
			if (this.mUnitRslider != null)
			{
				this.m_CalculatorHandler.OnCalculatorVauleChang(0, this.tmpValue, this.mUnitRslider);
			}
			else if (this.m_CalculatorHandler != null)
			{
				this.m_CalculatorHandler.OnCalculatorVauleChang(0, this.tmpValue, null);
			}
			UnityEngine.Object.Destroy(this.GUIM.Obj_UICalculator);
			this.GUIM.Obj_UICalculator = null;
			this.mUnitRslider = null;
			break;
		}
	}

	// Token: 0x06002C67 RID: 11367 RVA: 0x0048A034 File Offset: 0x00488234
	public void SetNum(int mNum)
	{
		if (this.bOpen)
		{
			this.bOpen = false;
			this.ImgRT.gameObject.SetActive(false);
			this.tmpValue = (long)mNum;
		}
		else if (this.tmpValue * 10L + (long)mNum < this.MaxValue)
		{
			this.tmpValue = (long)((ulong)((uint)(this.tmpValue * 10L + (long)mNum)));
		}
		else
		{
			this.tmpValue = this.MaxValue;
		}
		this.GUIM.m_CalculatorStr.ClearString();
		StringManager.IntToStr(this.GUIM.m_CalculatorStr, this.tmpValue, 1, true);
		this.text_Value.text = this.GUIM.m_CalculatorStr.ToString();
		this.text_Value.SetAllDirty();
		this.text_Value.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002C68 RID: 11368 RVA: 0x0048A110 File Offset: 0x00488310
	public void TextRefresh()
	{
		if (this.text_Value != null && this.text_Value.enabled)
		{
			this.text_Value.enabled = false;
			this.text_Value.enabled = true;
		}
		for (int i = 0; i < 10; i++)
		{
			if (this.text_Str[i] != null && this.text_Str[i].enabled)
			{
				this.text_Str[i].enabled = false;
				this.text_Str[i].enabled = true;
			}
		}
	}

	// Token: 0x06002C69 RID: 11369 RVA: 0x0048A1AC File Offset: 0x004883AC
	private void Start()
	{
	}

	// Token: 0x06002C6A RID: 11370 RVA: 0x0048A1B0 File Offset: 0x004883B0
	private void Update()
	{
	}

	// Token: 0x0400792F RID: 31023
	private DataManager DM;

	// Token: 0x04007930 RID: 31024
	private GUIManager GUIM;

	// Token: 0x04007931 RID: 31025
	private Door door;

	// Token: 0x04007932 RID: 31026
	public IUICalculatorHandler m_CalculatorHandler;

	// Token: 0x04007933 RID: 31027
	private RectTransform ImgRT;

	// Token: 0x04007934 RID: 31028
	public RectTransform CalculatorRT;

	// Token: 0x04007935 RID: 31029
	public UnitResourcesSlider mUnitRslider;

	// Token: 0x04007936 RID: 31030
	private Text text_Value;

	// Token: 0x04007937 RID: 31031
	private Text[] text_Str = new Text[12];

	// Token: 0x04007938 RID: 31032
	public byte mKXY;

	// Token: 0x04007939 RID: 31033
	public ushort[] KXY_Value = new ushort[3];

	// Token: 0x0400793A RID: 31034
	public long tmpValue;

	// Token: 0x0400793B RID: 31035
	public long MinValue;

	// Token: 0x0400793C RID: 31036
	public long MaxValue;

	// Token: 0x0400793D RID: 31037
	public byte OpenKind;

	// Token: 0x0400793E RID: 31038
	public bool bOpen = true;
}
