using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000315 RID: 789
public class UIAlliance_Permission : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x0600101C RID: 4124 RVA: 0x001C8CCC File Offset: 0x001C6ECC
	public override void OnOpen(int arg1, int arg2)
	{
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		UIText component = base.transform.GetChild(5).GetChild(0).GetComponent<UIText>();
		component.font = GUIManager.Instance.GetTTFFont();
		component.text = DataManager.Instance.mStringTable.GetStringByID(528u);
		this.m_TempText[this.m_TempTextIdx++] = component;
		Image component2 = base.transform.GetChild(13).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && component2)
		{
			component2.enabled = false;
		}
		UIButton component3 = base.transform.GetChild(13).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 1;
		component3.image.sprite = this.door.LoadSprite("UI_main_close");
		component3.image.material = this.door.LoadMaterial();
		component = base.transform.GetChild(12).GetChild(0).GetComponent<UIText>();
		component.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component;
		this.m_ScrollPanel = base.transform.GetChild(11).GetComponent<ScrollPanel>();
		List<float> list = new List<float>();
		for (int i = 0; i < 18; i++)
		{
			list.Add(41f);
		}
		this.m_ScrollPanel.IntiScrollPanel(440f, 0f, 0f, list, 12, this);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x0600101D RID: 4125 RVA: 0x001C8EB0 File Offset: 0x001C70B0
	public override void OnClose()
	{
	}

	// Token: 0x0600101E RID: 4126 RVA: 0x001C8EB4 File Offset: 0x001C70B4
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1 && this.door)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x0600101F RID: 4127 RVA: 0x001C8EEC File Offset: 0x001C70EC
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x06001020 RID: 4128 RVA: 0x001C8F18 File Offset: 0x001C7118
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (dataIdx >= 19 || dataIdx < 0)
		{
			return;
		}
		UIText component = item.transform.GetChild(0).GetComponent<UIText>();
		if (dataIdx < this.m_RowItemText.Length)
		{
			this.m_RowItemText[dataIdx] = component;
		}
		if (dataIdx < this.strArray.Length)
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(this.strArray[dataIdx]);
		}
		item.transform.GetChild(2).gameObject.SetActive(true);
		if (dataIdx <= 11)
		{
			item.transform.GetChild(3).gameObject.SetActive(true);
		}
		else
		{
			item.transform.GetChild(3).gameObject.SetActive(false);
		}
		if (dataIdx <= 3)
		{
			item.transform.GetChild(4).gameObject.SetActive(true);
		}
		else
		{
			item.transform.GetChild(4).gameObject.SetActive(false);
		}
		if (dataIdx == 0 || dataIdx == 1)
		{
			item.transform.GetChild(5).gameObject.SetActive(true);
		}
		else
		{
			item.transform.GetChild(5).gameObject.SetActive(false);
		}
		if (dataIdx == 0)
		{
			item.transform.GetChild(6).gameObject.SetActive(true);
		}
		else
		{
			item.transform.GetChild(6).gameObject.SetActive(false);
		}
	}

	// Token: 0x06001021 RID: 4129 RVA: 0x001C9090 File Offset: 0x001C7290
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001022 RID: 4130 RVA: 0x001C9094 File Offset: 0x001C7294
	public void Refresh_FontTexture()
	{
		if (this.m_TempText != null)
		{
			for (int i = 0; i < this.m_TempText.Length; i++)
			{
				if (this.m_TempText[i] != null && this.m_TempText[i].enabled)
				{
					this.m_TempText[i].enabled = false;
					this.m_TempText[i].enabled = true;
				}
			}
		}
		if (this.m_RowItemText != null)
		{
			for (int j = 0; j < this.m_RowItemText.Length; j++)
			{
				if (this.m_RowItemText[j] != null && this.m_RowItemText[j].enabled)
				{
					this.m_RowItemText[j].enabled = false;
					this.m_RowItemText[j].enabled = true;
				}
			}
		}
	}

	// Token: 0x040034BD RID: 13501
	private const int MaxTempTextNum = 2;

	// Token: 0x040034BE RID: 13502
	private const int MaxRowItemTexttNum = 19;

	// Token: 0x040034BF RID: 13503
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040034C0 RID: 13504
	private uint[] strArray = new uint[]
	{
		4775u,
		4628u,
		4776u,
		4777u,
		4778u,
		4779u,
		4780u,
		4783u,
		4784u,
		4785u,
		10071u,
		12635u,
		4786u,
		4787u,
		4788u,
		4789u,
		4790u,
		4791u,
		9567u
	};

	// Token: 0x040034C1 RID: 13505
	private Door door;

	// Token: 0x040034C2 RID: 13506
	private UIText[] m_TempText = new UIText[2];

	// Token: 0x040034C3 RID: 13507
	private int m_TempTextIdx;

	// Token: 0x040034C4 RID: 13508
	private UIText[] m_RowItemText = new UIText[19];
}
