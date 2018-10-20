using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200063F RID: 1599
public class UIPaySetting : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001EE1 RID: 7905 RVA: 0x003B0850 File Offset: 0x003AEA50
	void IUIButtonClickHandler.OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 1:
		case 2:
			this.PaySetting = (byte)((int)(this.PaySetting & 4) + sender.m_BtnID1);
			if (this.BuyID == 0u)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(964u), 255, true);
			}
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_PaySetting);
			break;
		case 3:
			this.PaySetting = 0;
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_PaySetting);
			break;
		case 4:
			this.PaySetting ^= 4;
			this.CheckObj.gameObject.SetActive(!this.CheckObj.gameObject.activeSelf);
			if ((this.PaySetting & 1) > 0 || (this.PaySetting & 2) > 0)
			{
				if ((this.PaySetting & 4) > 0)
				{
					DataManager instance = DataManager.Instance;
					instance.MySysSetting.mPaySetting = (instance.MySysSetting.mPaySetting | 4);
				}
				else
				{
					DataManager instance2 = DataManager.Instance;
					instance2.MySysSetting.mPaySetting = (instance2.MySysSetting.mPaySetting & 251);
				}
				PlayerPrefs.SetString("Other_mPaySetting", DataManager.Instance.MySysSetting.mPaySetting.ToString());
			}
			break;
		}
	}

	// Token: 0x06001EE2 RID: 7906 RVA: 0x003B09A8 File Offset: 0x003AEBA8
	public override void OnOpen(int arg1, int arg2)
	{
		Transform child = base.transform.GetChild(0);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.BuyID = (uint)arg1;
		this.Type = (byte)arg2;
		this.RefreshText[0] = child.GetChild(0).GetChild(2).GetComponent<UIText>();
		this.RefreshText[0].font = ttffont;
		this.RefreshText[0].text = mStringTable.GetStringByID(960u);
		this.RefreshText[1] = child.GetChild(3).GetChild(2).GetComponent<UIText>();
		this.RefreshText[1].font = ttffont;
		this.RefreshText[1].resizeTextForBestFit = true;
		this.RefreshText[1].resizeTextMaxSize = 26;
		this.RefreshText[1].text = mStringTable.GetStringByID(9514u);
		Vector2 sizeDelta = this.RefreshText[1].rectTransform.sizeDelta;
		sizeDelta.y = 36f;
		this.RefreshText[1].rectTransform.sizeDelta = sizeDelta;
		this.RefreshText[2] = child.GetChild(3).GetChild(3).GetComponent<UIText>();
		this.RefreshText[2].font = ttffont;
		this.RefreshText[2].resizeTextForBestFit = true;
		this.RefreshText[2].resizeTextMaxSize = 26;
		this.RefreshText[2].text = mStringTable.GetStringByID(961u);
		sizeDelta = this.RefreshText[2].rectTransform.sizeDelta;
		sizeDelta.y = 36f;
		this.RefreshText[2].rectTransform.sizeDelta = sizeDelta;
		this.RefreshText[3] = child.GetChild(3).GetChild(4).GetComponent<UIText>();
		this.RefreshText[3].font = ttffont;
		this.RefreshText[3].text = mStringTable.GetStringByID(965u);
		this.RefreshText[4] = child.GetChild(3).GetChild(5).GetComponent<UIText>();
		this.RefreshText[4].font = ttffont;
		this.RefreshText[4].resizeTextForBestFit = true;
		this.RefreshText[4].resizeTextMaxSize = 26;
		this.RefreshText[5] = child.GetChild(3).GetChild(6).GetComponent<UIText>();
		this.RefreshText[5].font = ttffont;
		this.RefreshText[5].resizeTextForBestFit = true;
		this.RefreshText[5].resizeTextMaxSize = 26;
		if (GUIManager.Instance.IsArabic)
		{
			child.GetChild(3).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
			child.GetChild(3).GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			child.GetChild(4).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.CheckObj = child.GetChild(4).GetChild(0).gameObject;
		UIButton component = child.GetChild(4).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 4;
		this.PaySetting = DataManager.Instance.MySysSetting.mPaySetting;
		this.CheckObj.SetActive((this.PaySetting & 4) > 0);
		if ((this.PaySetting & 1) > 0)
		{
			this.RefreshText[4].text = mStringTable.GetStringByID(968u);
		}
		else if ((this.PaySetting & 2) > 0)
		{
			this.RefreshText[5].text = mStringTable.GetStringByID(968u);
		}
		UIButton[] array = new UIButton[4];
		array[0] = child.GetComponent<UIButton>();
		array[1] = child.GetChild(1).GetComponent<UIButton>();
		array[1].m_BtnID1 = 1;
		array[1].m_Handler = this;
		array[2] = child.GetChild(2).GetComponent<UIButton>();
		array[2].m_BtnID1 = 2;
		array[2].m_Handler = this;
		array[3] = child.GetChild(5).GetComponent<UIButton>();
		array[3].m_BtnID1 = 3;
		array[3].m_Handler = this;
		child.GetChild(3).GetChild(3).SetParent(array[2].transform, false);
		child.GetChild(3).GetChild(2).SetParent(array[1].transform, false);
		child.GetChild(3).GetChild(1).SetParent(array[2].transform, false);
		child.GetChild(3).GetChild(0).SetParent(array[1].transform, false);
		RectTransform component2 = array[2].transform.GetChild(0).GetComponent<RectTransform>();
		Vector2 anchoredPosition = component2.anchoredPosition;
		anchoredPosition.y = 0f;
		component2.anchoredPosition = anchoredPosition;
		component2 = array[2].transform.GetChild(1).GetComponent<RectTransform>();
		anchoredPosition = component2.anchoredPosition;
		anchoredPosition.y = 0f;
		component2.anchoredPosition = anchoredPosition;
		component2 = array[1].transform.GetChild(0).GetComponent<RectTransform>();
		anchoredPosition = component2.anchoredPosition;
		anchoredPosition.y = 0f;
		component2.anchoredPosition = anchoredPosition;
		component2 = array[1].transform.GetChild(1).GetComponent<RectTransform>();
		anchoredPosition = component2.anchoredPosition;
		anchoredPosition.y = 0f;
		component2.anchoredPosition = anchoredPosition;
	}

	// Token: 0x06001EE3 RID: 7907 RVA: 0x003B0EE0 File Offset: 0x003AF0E0
	public override void UpdateNetwork(byte[] meg)
	{
		if (meg[0] == 35)
		{
			for (int i = 0; i < this.RefreshText.Length; i++)
			{
				this.RefreshText[i].enabled = false;
				this.RefreshText[i].enabled = true;
			}
		}
	}

	// Token: 0x06001EE4 RID: 7908 RVA: 0x003B0F2C File Offset: 0x003AF12C
	public override void OnClose()
	{
		if (this.PaySetting > 0)
		{
			DataManager.Instance.MySysSetting.mPaySetting = this.PaySetting;
			PlayerPrefs.SetString("Other_mPaySetting", DataManager.Instance.MySysSetting.mPaySetting.ToString());
			if (this.Type == 255)
			{
				MerchantmanManager.Instance.SendReQusetBlackMarket_Buy((byte)this.BuyID, false, false);
				return;
			}
			if (this.BuyID > 0u)
			{
				if (this.Type == 0)
				{
					MallManager.Instance.Send_Mall_Check((ushort)this.BuyID, false);
				}
				else
				{
					MallManager.Instance.Send_SPTREASURE_PREBUY_CHECK((ESpcialTreasureType)(this.Type - 1), this.BuyID, false);
				}
			}
		}
	}

	// Token: 0x040061CA RID: 25034
	private uint BuyID;

	// Token: 0x040061CB RID: 25035
	private GameObject CheckObj;

	// Token: 0x040061CC RID: 25036
	private UIText[] RefreshText = new UIText[6];

	// Token: 0x040061CD RID: 25037
	private byte PaySetting;

	// Token: 0x040061CE RID: 25038
	private byte Type;

	// Token: 0x02000640 RID: 1600
	private enum UIControl
	{
		// Token: 0x040061D0 RID: 25040
		Background,
		// Token: 0x040061D1 RID: 25041
		WeChatPay,
		// Token: 0x040061D2 RID: 25042
		AliPay,
		// Token: 0x040061D3 RID: 25043
		Icon,
		// Token: 0x040061D4 RID: 25044
		Check,
		// Token: 0x040061D5 RID: 25045
		Close
	}

	// Token: 0x02000641 RID: 1601
	private enum ClickType
	{
		// Token: 0x040061D7 RID: 25047
		WeChat = 1,
		// Token: 0x040061D8 RID: 25048
		Ali,
		// Token: 0x040061D9 RID: 25049
		Close,
		// Token: 0x040061DA RID: 25050
		Check
	}
}
