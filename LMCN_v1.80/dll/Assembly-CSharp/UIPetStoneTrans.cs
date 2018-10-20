using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200048D RID: 1165
public class UIPetStoneTrans : GUIWindow, UILoadImageHander, IUIButtonClickHandler, IUICalculatorHandler, IUIUnitRSliderHandler
{
	// Token: 0x170000A8 RID: 168
	// (get) Token: 0x0600179A RID: 6042 RVA: 0x002853E8 File Offset: 0x002835E8
	public Door door
	{
		get
		{
			if (this.m_door == null)
			{
				this.m_door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
			}
			return this.m_door;
		}
	}

	// Token: 0x0600179B RID: 6043 RVA: 0x00285418 File Offset: 0x00283618
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.m_transform = base.transform;
		Font ttffont = this.GM.GetTTFFont();
		this.StoneID = (ushort)arg1;
		this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.StoneID);
		this.TransID = this.tmpEquip.SyntheticParts[1].SyntheticItem;
		this.multiple = ((this.tmpEquip.SyntheticParts[2].SyntheticItem <= 0) ? 1 : this.tmpEquip.SyntheticParts[2].SyntheticItem);
		this.m_transform.GetChild(17).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(17).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(17).GetComponent<CustomImage>().enabled = false;
			((RectTransform)this.m_transform).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0f);
			((RectTransform)this.m_transform).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0f);
		}
		this.m_transform.GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(16).GetComponent<UIButton>().m_Handler = this;
		this.SliderT = this.m_transform.GetChild(15);
		this.LeftBtnT = this.m_transform.GetChild(5);
		this.GM.InitianHeroItemImg(this.LeftBtnT, eHeroOrItem.Item, this.StoneID, 0, 0, 0, false, true, true, false);
		this.RightBtnT = this.m_transform.GetChild(9);
		this.GM.InitianHeroItemImg(this.RightBtnT, eHeroOrItem.Item, this.TransID, 0, 0, 0, false, true, true, false);
		this.LHaveCountText = this.m_transform.GetChild(6).GetComponent<UIText>();
		this.LHaveCountText.font = ttffont;
		this.LHaveCountStr = StringManager.Instance.SpawnString(30);
		this.LCountText = this.m_transform.GetChild(7).GetComponent<UIText>();
		this.LCountText.font = ttffont;
		this.LCountStr = StringManager.Instance.SpawnString(30);
		this.RHaveCountText = this.m_transform.GetChild(10).GetComponent<UIText>();
		this.RHaveCountText.font = ttffont;
		this.RHaveCountStr = StringManager.Instance.SpawnString(30);
		this.RCountText = this.m_transform.GetChild(11).GetComponent<UIText>();
		this.RCountText.font = ttffont;
		this.RCountStr = StringManager.Instance.SpawnString(30);
		if (this.GM.IsArabic)
		{
			this.m_transform.GetChild(13).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.CountText = this.m_transform.GetChild(14).GetComponent<UIText>();
		this.CountText.font = ttffont;
		this.CountStr = StringManager.Instance.SpawnString(30);
		this.TitleText = this.m_transform.GetChild(2).GetComponent<UIText>();
		this.TitleText.font = ttffont;
		this.TitleText.text = this.DM.mStringTable.GetStringByID(14584u);
		this.SelectCountText = this.m_transform.GetChild(12).GetComponent<UIText>();
		this.SelectCountText.font = ttffont;
		this.SelectCountText.text = this.DM.mStringTable.GetStringByID(283u);
		this.InfoText = this.m_transform.GetChild(4).GetComponent<UIText>();
		this.InfoText.font = ttffont;
		this.InfoText.text = this.DM.mStringTable.GetStringByID(14585u);
		this.InfoText.color = Color.white;
		this.Btntext = this.m_transform.GetChild(16).GetChild(0).GetComponent<UIText>();
		this.Btntext.font = ttffont;
		this.Btntext.text = this.DM.mStringTable.GetStringByID(14586u);
		this.ResourcesStr = StringManager.Instance.SpawnString(30);
		this.SliderT = this.m_transform.GetChild(15);
		this.GM.InitUnitResourcesSlider(this.SliderT, eUnitSlider.AutoUse, 0u, (uint)this.DM.GetCurItemQuantity(this.StoneID, 0), 0.7f);
		this.m_Slider = this.SliderT.GetComponent<UnitResourcesSlider>();
		this.m_Slider.m_Handler = this;
		this.m_Slider.BtnInputText.m_Handler = this;
		this.m_Slider.BtnInputText.m_BtnID1 = 2;
		this.m_Slider.m_inputText.fontSize = 24;
		this.GM.SetUnitResourcesSliderSize(this.SliderT, eUnitSliderSize.Input, -42.4f, 32.8f, 84f, 33f, 0f, 0f);
		this.SetHaveCount();
		this.SetStoneCount();
		ushort num = (this.StoneCount <= 0) ? 0 : 1;
		this.SetUseCount(num);
		this.SetSlider(num);
		this.GM.UpdateUI(EGUIWindow.UI_Pet, 8, 0);
	}

	// Token: 0x0600179C RID: 6044 RVA: 0x00285980 File Offset: 0x00283B80
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.LCountStr);
		StringManager.Instance.DeSpawnString(this.RCountStr);
		StringManager.Instance.DeSpawnString(this.CountStr);
		StringManager.Instance.DeSpawnString(this.ResourcesStr);
		StringManager.Instance.DeSpawnString(this.MessageStr);
		StringManager.Instance.DeSpawnString(this.LHaveCountStr);
		StringManager.Instance.DeSpawnString(this.RHaveCountStr);
		this.GM.UpdateUI(EGUIWindow.UI_Pet, 7, 0);
		GUIManager.Instance.ClearCalculator();
	}

	// Token: 0x0600179D RID: 6045 RVA: 0x00285A20 File Offset: 0x00283C20
	public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
	{
		URS.m_slider.value = (double)mValue;
		URS.SliderValueChange();
	}

	// Token: 0x0600179E RID: 6046 RVA: 0x00285A38 File Offset: 0x00283C38
	public void OnVauleChang(UnitResourcesSlider sender)
	{
		StringManager.IntToStr(this.ResourcesStr, sender.Value, 1, true);
		sender.m_inputText.text = this.ResourcesStr.ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
		this.SetUseCount((ushort)sender.Value);
	}

	// Token: 0x0600179F RID: 6047 RVA: 0x00285A98 File Offset: 0x00283C98
	public void OnTextChang(UnitResourcesSlider sender)
	{
		StringManager.IntToStr(this.ResourcesStr, sender.Value, 1, true);
		this.m_Slider.m_inputText.text = this.ResourcesStr.ToString();
		this.m_Slider.m_inputText.SetAllDirty();
		this.m_Slider.m_inputText.cachedTextGenerator.Invalidate();
		this.SetUseCount((ushort)sender.Value);
	}

	// Token: 0x060017A0 RID: 6048 RVA: 0x00285B08 File Offset: 0x00283D08
	private void SetHaveCount()
	{
		this.LHaveCountStr.Length = 0;
		this.LHaveCountStr.IntToFormat((long)this.DM.GetCurItemQuantity(this.StoneID, 0), 1, true);
		this.LHaveCountStr.AppendFormat(this.DM.mStringTable.GetStringByID(79u));
		this.LHaveCountText.text = this.LHaveCountStr.ToString();
		this.LHaveCountText.SetAllDirty();
		this.LHaveCountText.cachedTextGenerator.Invalidate();
		this.RHaveCountStr.Length = 0;
		this.RHaveCountStr.IntToFormat((long)this.DM.GetCurItemQuantity(this.TransID, 0), 1, true);
		this.RHaveCountStr.AppendFormat(this.DM.mStringTable.GetStringByID(79u));
		this.RHaveCountText.text = this.RHaveCountStr.ToString();
		this.RHaveCountText.SetAllDirty();
		this.RHaveCountText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x060017A1 RID: 6049 RVA: 0x00285C0C File Offset: 0x00283E0C
	private void SetUseCount(ushort tmpCount)
	{
		this.UseCount = tmpCount;
		this.LCountStr.Length = 0;
		this.LCountStr.IntToFormat((long)this.UseCount, 1, true);
		if (this.GM.IsArabic)
		{
			this.LCountStr.AppendFormat("{0}x");
		}
		else
		{
			this.LCountStr.AppendFormat("x{0}");
		}
		this.LCountText.text = this.LCountStr.ToString();
		this.LCountText.SetAllDirty();
		this.LCountText.cachedTextGenerator.Invalidate();
		this.GetCount = (int)(this.UseCount * this.multiple);
		this.RCountStr.Length = 0;
		this.RCountStr.IntToFormat((long)this.GetCount, 1, true);
		if (this.GM.IsArabic)
		{
			this.RCountStr.AppendFormat("{0}x");
		}
		else
		{
			this.RCountStr.AppendFormat("x{0}");
		}
		this.RCountText.text = this.RCountStr.ToString();
		this.RCountText.SetAllDirty();
		this.RCountText.cachedTextGenerator.Invalidate();
		this.SetBtnColor();
	}

	// Token: 0x060017A2 RID: 6050 RVA: 0x00285D48 File Offset: 0x00283F48
	private void SetStoneCount()
	{
		this.StoneCount = this.DM.GetCurItemQuantity(this.StoneID, 0);
		if (this.CountText != null)
		{
			StringManager.IntToStr(this.CountStr, (long)this.StoneCount, 1, true);
			this.CountText.text = this.CountStr.ToString();
			this.CountText.SetAllDirty();
			this.CountText.cachedTextGenerator.Invalidate();
		}
		if (this.m_Slider != null)
		{
			this.m_Slider.m_slider.maxValue = (double)this.StoneCount;
			this.m_Slider.MaxValue = (long)this.StoneCount;
		}
		this.SetBtnColor();
	}

	// Token: 0x060017A3 RID: 6051 RVA: 0x00285E04 File Offset: 0x00284004
	private void SetSlider(ushort SetCount)
	{
		if (this.m_Slider != null)
		{
			this.m_Slider.m_slider.value = (double)SetCount;
			this.m_Slider.Value = (long)SetCount;
			this.ResourcesStr.Length = 0;
			StringManager.IntToStr(this.ResourcesStr, (long)SetCount, 1, true);
			this.m_Slider.m_inputText.text = this.ResourcesStr.ToString();
			this.m_Slider.m_inputText.SetAllDirty();
			this.m_Slider.m_inputText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x060017A4 RID: 6052 RVA: 0x00285EA0 File Offset: 0x002840A0
	private void SetBtnColor()
	{
		if (this.Btntext == null)
		{
			return;
		}
		if (this.StoneCount == 0 || this.UseCount == 0)
		{
			this.Btntext.color = Color.red;
		}
		else
		{
			this.Btntext.color = Color.white;
		}
	}

	// Token: 0x060017A5 RID: 6053 RVA: 0x00285EFC File Offset: 0x002840FC
	private void RefreshItemCount()
	{
		this.SetHaveCount();
		this.SetStoneCount();
		if (this.UseCount > this.StoneCount)
		{
			this.SetUseCount(this.StoneCount);
			this.SetSlider(this.StoneCount);
		}
	}

	// Token: 0x060017A6 RID: 6054 RVA: 0x00285F40 File Offset: 0x00284140
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Item)
			{
				if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
				{
					return;
				}
				if (this.TitleText != null && this.TitleText.enabled)
				{
					this.TitleText.enabled = false;
					this.TitleText.enabled = true;
				}
				if (this.LCountText != null && this.LCountText.enabled)
				{
					this.LCountText.enabled = false;
					this.LCountText.enabled = true;
				}
				if (this.RCountText != null && this.RCountText.enabled)
				{
					this.RCountText.enabled = false;
					this.RCountText.enabled = true;
				}
				if (this.SelectCountText != null && this.SelectCountText.enabled)
				{
					this.SelectCountText.enabled = false;
					this.SelectCountText.enabled = true;
				}
				if (this.CountText != null && this.CountText.enabled)
				{
					this.CountText.enabled = false;
					this.CountText.enabled = true;
				}
				if (this.InfoText != null && this.InfoText.enabled)
				{
					this.InfoText.enabled = false;
					this.InfoText.enabled = true;
				}
				if (this.Btntext != null && this.Btntext.enabled)
				{
					this.Btntext.enabled = false;
					this.Btntext.enabled = true;
				}
				if (this.LHaveCountText != null && this.LHaveCountText.enabled)
				{
					this.LHaveCountText.enabled = false;
					this.LHaveCountText.enabled = true;
				}
				if (this.RHaveCountText != null && this.RHaveCountText.enabled)
				{
					this.RHaveCountText.enabled = false;
					this.RHaveCountText.enabled = true;
				}
				return;
			}
			break;
		}
		this.RefreshItemCount();
	}

	// Token: 0x060017A7 RID: 6055 RVA: 0x00286188 File Offset: 0x00284388
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.SendTrans();
		}
	}

	// Token: 0x060017A8 RID: 6056 RVA: 0x002861B0 File Offset: 0x002843B0
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			if (sender.m_BtnID2 == 1)
			{
				this.GM.CloseMenu(EGUIWindow.UI_PetStoneTrans);
			}
			else if (sender.m_BtnID2 == 2)
			{
				if (this.StoneCount == 0)
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14568u), 255, true);
					return;
				}
				if (this.UseCount == 0)
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703u), 255, true);
					return;
				}
				if (this.GM.bCheckStoneTrans)
				{
					if (this.MessageStr == null)
					{
						this.MessageStr = StringManager.Instance.SpawnString(300);
					}
					this.MessageStr.Length = 0;
					CString cstring = StringManager.Instance.StaticString1024();
					UIItemInfo.SetNameProperties(null, null, cstring, null, ref this.tmpEquip, null);
					this.MessageStr.StringToFormat(cstring);
					this.MessageStr.IntToFormat((long)this.UseCount, 1, false);
					this.MessageStr.AppendFormat(this.DM.mStringTable.GetStringByID(14587u));
					this.GM.OpenCheckStoneTrans(this.MessageStr);
				}
				else
				{
					this.SendTrans();
				}
			}
		}
		else if (sender.m_BtnID1 == 2)
		{
			this.GM.m_UICalculator.m_CalculatorHandler = this;
			this.GM.m_UICalculator.OpenCalculator(this.m_Slider.MaxValue, this.m_Slider.Value, 260f, 100f, this.m_Slider, 0L);
		}
	}

	// Token: 0x060017A9 RID: 6057 RVA: 0x0028636C File Offset: 0x0028456C
	private void SendTrans()
	{
		if (this.UseCount == 0)
		{
			return;
		}
		if ((int)this.DM.GetCurItemQuantity(this.TransID, 0) + this.GetCount >= 65535)
		{
			this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(887u), 255, true);
			return;
		}
		this.DM.UseItem(this.StoneID, this.UseCount, 0, 0, 0, 0u, string.Empty, true);
		this.GM.CloseMenu(EGUIWindow.UI_PetStoneTrans);
	}

	// Token: 0x060017AA RID: 6058 RVA: 0x00286400 File Offset: 0x00284600
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		if (this.door)
		{
			img.sprite = this.door.LoadSprite(ImageName);
			img.material = this.door.LoadMaterial();
		}
	}

	// Token: 0x0400464D RID: 17997
	private Transform m_transform;

	// Token: 0x0400464E RID: 17998
	private DataManager DM;

	// Token: 0x0400464F RID: 17999
	private GUIManager GM;

	// Token: 0x04004650 RID: 18000
	private Door m_door;

	// Token: 0x04004651 RID: 18001
	private ushort StoneID;

	// Token: 0x04004652 RID: 18002
	private ushort TransID;

	// Token: 0x04004653 RID: 18003
	private ushort UseCount;

	// Token: 0x04004654 RID: 18004
	private ushort StoneCount;

	// Token: 0x04004655 RID: 18005
	private ushort multiple = 1;

	// Token: 0x04004656 RID: 18006
	private int GetCount;

	// Token: 0x04004657 RID: 18007
	private UIText TitleText;

	// Token: 0x04004658 RID: 18008
	private UIText LCountText;

	// Token: 0x04004659 RID: 18009
	private UIText RCountText;

	// Token: 0x0400465A RID: 18010
	private UIText SelectCountText;

	// Token: 0x0400465B RID: 18011
	private UIText CountText;

	// Token: 0x0400465C RID: 18012
	private UIText InfoText;

	// Token: 0x0400465D RID: 18013
	private UIText Btntext;

	// Token: 0x0400465E RID: 18014
	private UIText LHaveCountText;

	// Token: 0x0400465F RID: 18015
	private UIText RHaveCountText;

	// Token: 0x04004660 RID: 18016
	private CString LCountStr;

	// Token: 0x04004661 RID: 18017
	private CString RCountStr;

	// Token: 0x04004662 RID: 18018
	private CString CountStr;

	// Token: 0x04004663 RID: 18019
	private CString ResourcesStr;

	// Token: 0x04004664 RID: 18020
	private CString MessageStr;

	// Token: 0x04004665 RID: 18021
	private CString LHaveCountStr;

	// Token: 0x04004666 RID: 18022
	private CString RHaveCountStr;

	// Token: 0x04004667 RID: 18023
	private Transform SliderT;

	// Token: 0x04004668 RID: 18024
	private Transform LeftBtnT;

	// Token: 0x04004669 RID: 18025
	private Transform RightBtnT;

	// Token: 0x0400466A RID: 18026
	private UnitResourcesSlider m_Slider;

	// Token: 0x0400466B RID: 18027
	private Equip tmpEquip;
}
