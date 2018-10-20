using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000699 RID: 1689
public class UITermOfService : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06002061 RID: 8289 RVA: 0x003D500C File Offset: 0x003D320C
	void IUIButtonClickHandler.OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 0)
		{
			UpdateController.OnToSAgreement();
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_TermOfService);
		}
		else
		{
			string pUrl = "https://lm.176.com/agreement.php";
			IGGSDKPlugin.LoadWebView(pUrl);
		}
	}

	// Token: 0x06002062 RID: 8290 RVA: 0x003D5050 File Offset: 0x003D3250
	public override void OnOpen(int arg1, int arg2)
	{
		Font ttffont = GUIManager.Instance.GetTTFFont();
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.TitleText = base.transform.GetChild(3).GetComponent<UIText>();
		this.TitleText.font = ttffont;
		this.TitleText.text = mStringTable.GetStringByID(14753u);
		UIButton component = base.transform.GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 0;
		this.Btn2Text = base.transform.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.Btn2Text.font = ttffont;
		this.Btn2Text.text = mStringTable.GetStringByID(14757u);
		this.ServicesText.Init(base.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>(), base.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>(), base.transform.GetChild(4).GetComponent<UIText>(), 291.2f, ttffont);
		this.ServicesText.Button.m_Handler = this;
		this.ServicesText.Button.m_BtnID1 = 1;
		this.ServicesText.SetText(mStringTable.GetStringByID(14763u));
		this.Scroll = base.transform.GetChild(5).GetComponent<CScrollRect>();
		this.ScrollContRect = base.transform.GetChild(5).GetChild(0).GetComponent<RectTransform>();
		this.ContText = base.transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.ContText.font = ttffont;
		this.UpdateContent();
	}

	// Token: 0x06002063 RID: 8291 RVA: 0x003D51FC File Offset: 0x003D33FC
	private void UpdateContent()
	{
		bool flag = DataManager.Instance.ShowTermsOfService == 1;
		if (flag)
		{
			this.ContText.text = DataManager.Instance.mStringTable.GetStringByID(14756u);
		}
		else
		{
			this.ContText.text = DataManager.Instance.mStringTable.GetStringByID(14760u);
		}
		this.ContText.SetLayoutDirty();
		this.ContText.cachedTextGeneratorForLayout.Invalidate();
		RectTransform rectTransform = this.ContText.rectTransform;
		float preferredHeight = this.ContText.preferredHeight;
		if (this.ScrollContRect.sizeDelta.y < preferredHeight)
		{
			this.ScrollContRect.sizeDelta = new Vector2(this.ScrollContRect.sizeDelta.x, this.ContText.preferredHeight);
			rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, this.ScrollContRect.sizeDelta.y);
		}
		else
		{
			this.Scroll.enabled = false;
		}
	}

	// Token: 0x06002064 RID: 8292 RVA: 0x003D5324 File Offset: 0x003D3524
	public override bool OnBackButtonClick()
	{
		return true;
	}

	// Token: 0x06002065 RID: 8293 RVA: 0x003D5328 File Offset: 0x003D3528
	public override void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x06002066 RID: 8294 RVA: 0x003D532C File Offset: 0x003D352C
	public override void UpdateNetwork(byte[] meg)
	{
		if (meg[0] == 35)
		{
			this.TitleText.enabled = false;
			this.TitleText.enabled = true;
			this.ContText.enabled = false;
			this.ContText.enabled = true;
			this.Btn2Text.enabled = false;
			this.Btn2Text.enabled = true;
			this.ServicesText.TextRefresh();
		}
	}

	// Token: 0x04006601 RID: 26113
	private UIText TitleText;

	// Token: 0x04006602 RID: 26114
	private UIText ContText;

	// Token: 0x04006603 RID: 26115
	private UIText Btn2Text;

	// Token: 0x04006604 RID: 26116
	private CScrollRect Scroll;

	// Token: 0x04006605 RID: 26117
	private RectTransform ScrollContRect;

	// Token: 0x04006606 RID: 26118
	private UISummonMonster._TextUnderLine ServicesText;

	// Token: 0x0200069A RID: 1690
	private enum UIControl
	{
		// Token: 0x04006608 RID: 26120
		BackFrame,
		// Token: 0x04006609 RID: 26121
		Btn1,
		// Token: 0x0400660A RID: 26122
		Btn2,
		// Token: 0x0400660B RID: 26123
		Title,
		// Token: 0x0400660C RID: 26124
		Text,
		// Token: 0x0400660D RID: 26125
		Scroll
	}

	// Token: 0x0200069B RID: 1691
	private enum Clicktype
	{
		// Token: 0x0400660F RID: 26127
		Accept,
		// Token: 0x04006610 RID: 26128
		TermOfService
	}
}
