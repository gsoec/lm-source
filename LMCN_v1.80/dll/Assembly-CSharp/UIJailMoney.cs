using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005BE RID: 1470
public class UIJailMoney : GUIWindow, IUIButtonClickHandler, IUICalculatorHandler
{
	// Token: 0x06001D24 RID: 7460 RVA: 0x0034421C File Offset: 0x0034241C
	public override void OnOpen(int arg1, int arg2)
	{
		this.OpenKind = (UIJailMoney.eOpenKind)arg1;
		this.PrisonerDMIdx = (byte)arg2;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIButton component = this.AGS_Form.GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		this.haveGold = StringManager.Instance.SpawnString(30);
		this.PopString = StringManager.Instance.SpawnString(200);
		this.MoneyText = StringManager.Instance.SpawnString(30);
		UIJailMoney.eOpenKind openKind = this.OpenKind;
		UIText component2;
		if (openKind != UIJailMoney.eOpenKind.Ransom)
		{
			if (openKind == UIJailMoney.eOpenKind.Bounty)
			{
				component2 = this.AGS_Form.GetChild(9).GetComponent<UIText>();
				component2.font = ttffont;
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7781u);
				component2 = this.AGS_Form.GetChild(10).GetComponent<UIText>();
				component2.font = ttffont;
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7783u);
				component2 = this.AGS_Form.GetChild(14).GetComponent<UIText>();
				component2.font = ttffont;
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7782u);
			}
		}
		else
		{
			component2 = this.AGS_Form.GetChild(9).GetComponent<UIText>();
			component2.font = ttffont;
			component2.text = DataManager.Instance.mStringTable.GetStringByID(7769u);
			component2 = this.AGS_Form.GetChild(10).GetComponent<UIText>();
			component2.font = ttffont;
			component2.text = DataManager.Instance.mStringTable.GetStringByID(7765u);
			component2 = this.AGS_Form.GetChild(14).GetComponent<UIText>();
			component2.font = ttffont;
			component2.text = DataManager.Instance.mStringTable.GetStringByID(7770u);
		}
		component = this.AGS_Form.GetChild(11).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 2;
		component2 = this.AGS_Form.GetChild(11).GetChild(0).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = string.Empty;
		this.MoneyTextField = component2;
		component2 = this.AGS_Form.GetChild(11).GetChild(1).GetComponent<UIText>();
		component2.font = ttffont;
		RectTransform component3 = this.AGS_Form.GetChild(11).GetComponent<RectTransform>();
		openKind = this.OpenKind;
		if (openKind != UIJailMoney.eOpenKind.Ransom)
		{
			if (openKind == UIJailMoney.eOpenKind.Bounty)
			{
				component3.anchoredPosition = new Vector2(-125f, -22f);
				this.haveGold.ClearString();
				this.haveGold.IntToFormat((long)((ulong)DataManager.Instance.Resource[4].Stock), 1, true);
				if (!GUIManager.Instance.IsArabic)
				{
					this.haveGold.AppendFormat("/ {0}");
				}
				else
				{
					this.haveGold.AppendFormat("{0} /");
				}
				component2.text = this.haveGold.ToString();
			}
		}
		else
		{
			component3.anchoredPosition = new Vector2(-63f, -22f);
			component2.gameObject.SetActive(false);
		}
		component2 = this.AGS_Form.GetChild(12).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(7772u);
		component = this.AGS_Form.GetChild(13).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component2 = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(5026u);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			component3 = this.AGS_Form.GetChild(0).GetComponent<RectTransform>();
			component3.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			component3.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
	}

	// Token: 0x06001D25 RID: 7461 RVA: 0x00344644 File Offset: 0x00342844
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.PopString);
		StringManager.Instance.DeSpawnString(this.haveGold);
		StringManager.Instance.DeSpawnString(this.MoneyText);
		if (this.openOkBox)
		{
			GUIManager.Instance.CloseOKCancelBox();
		}
		if (GUIManager.Instance.Obj_UICalculator != null)
		{
			UnityEngine.Object.Destroy(GUIManager.Instance.Obj_UICalculator);
			GUIManager.Instance.Obj_UICalculator = null;
			GUIManager.Instance.m_UICalculator.mUnitRslider = null;
		}
	}

	// Token: 0x06001D26 RID: 7462 RVA: 0x003446D8 File Offset: 0x003428D8
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID2)
		{
		case 0:
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_JailMoney);
			break;
		case 1:
		{
			UIJailMoney.eOpenKind openKind = this.OpenKind;
			if (openKind != UIJailMoney.eOpenKind.Ransom)
			{
				if (openKind == UIJailMoney.eOpenKind.Bounty)
				{
					if (this.MoneyAmount < 10000u)
					{
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7795u), 255, true);
						return;
					}
					if (DataManager.Instance.Resource[4].Stock < this.MoneyAmount)
					{
						return;
					}
					if ((ulong)this.MoneyAmount + (ulong)DataManager.Instance.beCaptured.Bounty > (ulong)-1)
					{
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7796u), 255, true);
						return;
					}
					this.PopString.ClearString();
					this.PopString.IntToFormat((long)((ulong)this.MoneyAmount), 1, false);
					this.PopString.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7779u));
					this.PopString.Append("\n");
					this.PopString.Append(DataManager.Instance.mStringTable.GetStringByID(7780u));
					GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(7781u), this.PopString.ToString(), 1, 0, null, null);
					this.openOkBox = true;
				}
			}
			else
			{
				if (this.MoneyAmount < 10000u)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7794u), 255, true);
					return;
				}
				this.PopString.ClearString();
				this.PopString.IntToFormat((long)((ulong)this.MoneyAmount), 1, false);
				this.PopString.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7766u));
				this.PopString.Append("\n");
				this.PopString.Append(DataManager.Instance.mStringTable.GetStringByID(7771u));
				GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(7769u), this.PopString.ToString(), 0, 0, null, null);
				this.openOkBox = true;
			}
			break;
		}
		case 2:
			if (this.OpenKind == UIJailMoney.eOpenKind.Bounty)
			{
				GUIManager.Instance.m_UICalculator.m_CalculatorHandler = this;
				GUIManager.Instance.m_UICalculator.OpenCalculator((long)((ulong)DataManager.Instance.Resource[4].Stock), 10000L, 350f, 0f, null, 10000L);
			}
			else
			{
				GUIManager.Instance.m_UICalculator.m_CalculatorHandler = this;
				GUIManager.Instance.m_UICalculator.OpenCalculator(999999999L, 10000L, 350f, 0f, null, 10000L);
			}
			break;
		}
	}

	// Token: 0x06001D27 RID: 7463 RVA: 0x003449E8 File Offset: 0x00342BE8
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		this.openOkBox = false;
		if (bOK)
		{
			if (arg1 != 0)
			{
				if (arg1 == 1)
				{
					Debug.Log("賞金:" + this.MoneyAmount);
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.Protocol = Protocol._MSG_REQUEST_CHANGE_BOUNTY;
					messagePacket.AddSeqId();
					messagePacket.Add(this.MoneyAmount);
					messagePacket.Send(false);
					GUIManager.Instance.CloseMenu(EGUIWindow.UI_JailMoney);
				}
			}
			else
			{
				Debug.Log("贖金:" + this.MoneyAmount);
				MessagePacket messagePacket2 = new MessagePacket(1024);
				messagePacket2.Protocol = Protocol._MSG_REQUEST_CHANGE_RANSOM;
				messagePacket2.AddSeqId();
				messagePacket2.Add(this.PrisonerDMIdx);
				messagePacket2.Add(this.MoneyAmount);
				messagePacket2.Send(false);
				GUIManager.Instance.CloseMenu(EGUIWindow.UI_JailMoney);
			}
		}
	}

	// Token: 0x06001D28 RID: 7464 RVA: 0x00344AD8 File Offset: 0x00342CD8
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x06001D29 RID: 7465 RVA: 0x00344B04 File Offset: 0x00342D04
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(9).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(10).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(11).GetChild(0).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(11).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(12).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
	}

	// Token: 0x06001D2A RID: 7466 RVA: 0x00344CB4 File Offset: 0x00342EB4
	public void SetMoney(uint money)
	{
		this.MoneyAmount = money;
		this.MoneyText.ClearString();
		StringManager.IntToStr(this.MoneyText, (long)((ulong)this.MoneyAmount), 1, true);
		this.MoneyTextField.text = this.MoneyText.ToString();
		this.MoneyTextField.SetAllDirty();
		this.MoneyTextField.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001D2B RID: 7467 RVA: 0x00344D1C File Offset: 0x00342F1C
	public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS = null)
	{
		this.SetMoney((uint)mValue);
	}

	// Token: 0x040058FE RID: 22782
	private Transform AGS_Form;

	// Token: 0x040058FF RID: 22783
	private UIJailMoney.eOpenKind OpenKind;

	// Token: 0x04005900 RID: 22784
	private uint MoneyAmount;

	// Token: 0x04005901 RID: 22785
	private byte PrisonerDMIdx;

	// Token: 0x04005902 RID: 22786
	private CString haveGold;

	// Token: 0x04005903 RID: 22787
	private CString PopString;

	// Token: 0x04005904 RID: 22788
	private CString MoneyText;

	// Token: 0x04005905 RID: 22789
	private UIText MoneyTextField;

	// Token: 0x04005906 RID: 22790
	private bool openOkBox;

	// Token: 0x020005BF RID: 1471
	public enum eOpenKind
	{
		// Token: 0x04005908 RID: 22792
		Ransom,
		// Token: 0x04005909 RID: 22793
		Bounty
	}

	// Token: 0x020005C0 RID: 1472
	private enum e_AGS_UI_JailMoney_Editor
	{
		// Token: 0x0400590B RID: 22795
		Black,
		// Token: 0x0400590C RID: 22796
		Image,
		// Token: 0x0400590D RID: 22797
		deco1,
		// Token: 0x0400590E RID: 22798
		deco2,
		// Token: 0x0400590F RID: 22799
		deco3,
		// Token: 0x04005910 RID: 22800
		deco4,
		// Token: 0x04005911 RID: 22801
		deco5,
		// Token: 0x04005912 RID: 22802
		TopBar,
		// Token: 0x04005913 RID: 22803
		ButtomBar,
		// Token: 0x04005914 RID: 22804
		TitleText,
		// Token: 0x04005915 RID: 22805
		FuncText,
		// Token: 0x04005916 RID: 22806
		deco6,
		// Token: 0x04005917 RID: 22807
		FuncDisp,
		// Token: 0x04005918 RID: 22808
		UIButton,
		// Token: 0x04005919 RID: 22809
		Text
	}

	// Token: 0x020005C1 RID: 1473
	private enum e_AGS_deco6
	{
		// Token: 0x0400591B RID: 22811
		MoneyText,
		// Token: 0x0400591C RID: 22812
		TotalMoney,
		// Token: 0x0400591D RID: 22813
		coin
	}

	// Token: 0x020005C2 RID: 1474
	private enum e_AGS_UIButton
	{
		// Token: 0x0400591F RID: 22815
		Text
	}
}
