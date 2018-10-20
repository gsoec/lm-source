using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000508 RID: 1288
internal class UICanonizedPanel : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x060019CD RID: 6605 RVA: 0x002BE1D4 File Offset: 0x002BC3D4
	public override void OnOpen(int arg1, int arg2)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		Transform child = base.transform.GetChild(0);
		this.background = child.GetComponent<Image>();
		this.background.sprite = GUIManager.Instance.LoadFrameSprite("UI_kmap_black_01");
		this.background.material = GUIManager.Instance.GetFrameMaterial();
		this.background.type = Image.Type.Sliced;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			((RectTransform)child).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)child).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		UIButton component = base.transform.GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 0;
		this.panelRt = base.transform.GetChild(1).GetComponent<RectTransform>();
		Image component2 = base.transform.GetChild(1).GetComponent<Image>();
		component2.sprite = GUIManager.Instance.LoadFrameSprite("UI_league_box_11");
		component2.material = GUIManager.Instance.GetFrameMaterial();
		component2.type = Image.Type.Sliced;
		this.btnRect1 = base.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>();
		component2 = base.transform.GetChild(1).GetChild(0).GetComponent<Image>();
		component2.sprite = GUIManager.Instance.LoadFrameSprite("UI_con_butt_08");
		component2.material = GUIManager.Instance.GetFrameMaterial();
		component2.type = Image.Type.Sliced;
		this.text1 = base.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text1.font = GUIManager.Instance.GetTTFFont();
		this.text1.text = DataManager.Instance.mStringTable.GetStringByID(11007u);
		component = base.transform.GetChild(1).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1;
		this.btnRect2 = base.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
		component2 = base.transform.GetChild(1).GetChild(1).GetComponent<Image>();
		component2.sprite = GUIManager.Instance.LoadFrameSprite("UI_con_butt_08");
		component2.material = GUIManager.Instance.GetFrameMaterial();
		component2.type = Image.Type.Sliced;
		this.text2 = base.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text2.font = GUIManager.Instance.GetTTFFont();
		this.text2.text = DataManager.Instance.mStringTable.GetStringByID(11077u);
		component = base.transform.GetChild(1).GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 2;
		this.btnRect3 = base.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
		component2 = base.transform.GetChild(1).GetChild(2).GetComponent<Image>();
		component2.sprite = GUIManager.Instance.LoadFrameSprite("UI_con_butt_08");
		component2.material = GUIManager.Instance.GetFrameMaterial();
		component2.type = Image.Type.Sliced;
		this.text3 = base.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<UIText>();
		this.text3.font = GUIManager.Instance.GetTTFFont();
		this.text3.text = DataManager.Instance.mStringTable.GetStringByID(11008u);
		component = base.transform.GetChild(1).GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 3;
		if (arg1 == 0)
		{
			this.background.color = new Color(1f, 1f, 1f, 0f);
			this.panelRt.anchoredPosition = new Vector2(1.5f, -87.5f);
		}
		else if (arg1 == 1)
		{
			this.background.color = new Color(1f, 1f, 1f, 0.698f);
		}
		this.SetBtnPos(arg2);
	}

	// Token: 0x060019CE RID: 6606 RVA: 0x002BE620 File Offset: 0x002BC820
	public override void OnClose()
	{
	}

	// Token: 0x060019CF RID: 6607 RVA: 0x002BE624 File Offset: 0x002BC824
	public override void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x060019D0 RID: 6608 RVA: 0x002BE628 File Offset: 0x002BC828
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x060019D1 RID: 6609 RVA: 0x002BE654 File Offset: 0x002BC854
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
	}

	// Token: 0x060019D2 RID: 6610 RVA: 0x002BE658 File Offset: 0x002BC858
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x060019D3 RID: 6611 RVA: 0x002BE65C File Offset: 0x002BC85C
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_CanonizedPanel);
			break;
		case 1:
			TitleManager.Instance.OpenTitleListW(GUIManager.Instance.CanonizedName);
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_CanonizedPanel);
			break;
		case 2:
			TitleManager.Instance.OpenNobilityTitleSet(GUIManager.Instance.CanonizedName);
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_CanonizedPanel);
			break;
		case 3:
			TitleManager.Instance.OpenTitleSet(GUIManager.Instance.CanonizedName);
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_CanonizedPanel);
			break;
		}
	}

	// Token: 0x060019D4 RID: 6612 RVA: 0x002BE718 File Offset: 0x002BC918
	private void SetBtnPos(int type)
	{
		float[] array = new float[]
		{
			40.5f,
			-40.5f
		};
		float[] array2 = new float[]
		{
			75f,
			0f,
			-75f
		};
		Vector2 sizeDelta = this.panelRt.sizeDelta;
		sizeDelta.y = 213f;
		this.panelRt.sizeDelta = sizeDelta;
		switch (type)
		{
		case 3:
		{
			this.btnRect1.gameObject.SetActive(true);
			this.btnRect2.gameObject.SetActive(false);
			this.btnRect3.gameObject.SetActive(true);
			Vector2 anchoredPosition = this.btnRect1.anchoredPosition;
			anchoredPosition.y = array[0];
			this.btnRect1.anchoredPosition = anchoredPosition;
			anchoredPosition = this.btnRect3.anchoredPosition;
			anchoredPosition.y = array[1];
			this.btnRect3.anchoredPosition = anchoredPosition;
			break;
		}
		case 5:
		{
			this.btnRect1.gameObject.SetActive(false);
			this.btnRect2.gameObject.SetActive(true);
			this.btnRect3.gameObject.SetActive(true);
			Vector2 anchoredPosition = this.btnRect2.anchoredPosition;
			anchoredPosition.y = array[0];
			this.btnRect2.anchoredPosition = anchoredPosition;
			anchoredPosition = this.btnRect3.anchoredPosition;
			anchoredPosition.y = array[1];
			this.btnRect3.anchoredPosition = anchoredPosition;
			break;
		}
		case 6:
		{
			this.btnRect1.gameObject.SetActive(true);
			this.btnRect2.gameObject.SetActive(true);
			this.btnRect3.gameObject.SetActive(false);
			Vector2 anchoredPosition = this.btnRect1.anchoredPosition;
			anchoredPosition.y = array[0];
			this.btnRect1.anchoredPosition = anchoredPosition;
			anchoredPosition = this.btnRect2.anchoredPosition;
			anchoredPosition.y = array[1];
			this.btnRect2.anchoredPosition = anchoredPosition;
			break;
		}
		case 7:
		{
			this.btnRect1.gameObject.SetActive(true);
			this.btnRect2.gameObject.SetActive(true);
			this.btnRect3.gameObject.SetActive(true);
			Vector2 anchoredPosition = this.btnRect1.anchoredPosition;
			anchoredPosition.y = array2[0];
			this.btnRect1.anchoredPosition = anchoredPosition;
			anchoredPosition = this.btnRect2.anchoredPosition;
			anchoredPosition.y = array2[1];
			this.btnRect2.anchoredPosition = anchoredPosition;
			anchoredPosition = this.btnRect3.anchoredPosition;
			anchoredPosition.y = array2[2];
			this.btnRect3.anchoredPosition = anchoredPosition;
			sizeDelta = this.panelRt.sizeDelta;
			sizeDelta.y = 273f;
			this.panelRt.sizeDelta = sizeDelta;
			break;
		}
		}
	}

	// Token: 0x060019D5 RID: 6613 RVA: 0x002BE9D4 File Offset: 0x002BCBD4
	private void Refresh_FontTexture()
	{
		if (this.text1 != null && this.text1.enabled)
		{
			this.text1.enabled = false;
			this.text1.enabled = true;
		}
		if (this.text2 != null && this.text2.enabled)
		{
			this.text2.enabled = false;
			this.text2.enabled = true;
		}
		if (this.text3 != null && this.text3.enabled)
		{
			this.text3.enabled = false;
			this.text3.enabled = true;
		}
	}

	// Token: 0x04004C90 RID: 19600
	private RectTransform btnRect1;

	// Token: 0x04004C91 RID: 19601
	private RectTransform btnRect2;

	// Token: 0x04004C92 RID: 19602
	private RectTransform btnRect3;

	// Token: 0x04004C93 RID: 19603
	private UIText text1;

	// Token: 0x04004C94 RID: 19604
	private UIText text2;

	// Token: 0x04004C95 RID: 19605
	private UIText text3;

	// Token: 0x04004C96 RID: 19606
	private Image background;

	// Token: 0x04004C97 RID: 19607
	private RectTransform panelRt;

	// Token: 0x02000509 RID: 1289
	private enum eUICanonizedPanel
	{
		// Token: 0x04004C99 RID: 19609
		Background,
		// Token: 0x04004C9A RID: 19610
		Panel
	}

	// Token: 0x0200050A RID: 1290
	private enum eBtn
	{
		// Token: 0x04004C9C RID: 19612
		Exit,
		// Token: 0x04004C9D RID: 19613
		Function1,
		// Token: 0x04004C9E RID: 19614
		Function2,
		// Token: 0x04004C9F RID: 19615
		Function3
	}
}
