using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002B0 RID: 688
public class _UISummonMonsterInfo
{
	// Token: 0x06000DCB RID: 3531 RVA: 0x00161FAC File Offset: 0x001601AC
	public _UISummonMonsterInfo(UISummonMonster mainRef, GameObject go)
	{
		this.MainRef = mainRef;
		this.transform = go.transform;
		this.GO = go;
	}

	// Token: 0x06000DCC RID: 3532 RVA: 0x00161FE8 File Offset: 0x001601E8
	public void OnOpen(int arg1, int arg2)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 3);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			this.transform.GetChild(3).GetComponent<CustomImage>().enabled = false;
		}
		else
		{
			this.transform.GetChild(3).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		}
		this.transform.GetChild(3).GetChild(0).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		UIButton component = this.transform.GetChild(3).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this.MainRef;
		component.m_BtnID1 = 4;
		UIText component2 = this.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = mStringTable.GetStringByID(14527u);
		UIText[] refreshTextList = this.RefreshTextList;
		byte listindex;
		this.Listindex = (listindex = this.Listindex) + 1;
		refreshTextList[(int)listindex] = component2;
		this.transform.GetChild(1).gameObject.SetActive(false);
		this.ScrollR = this.transform.GetChild(2).GetComponent<RectTransform>();
		this.ScrollR.anchoredPosition = new Vector2(this.ScrollR.anchoredPosition.x, -54.5f);
		this.ScrollR.sizeDelta = new Vector2(this.ScrollR.sizeDelta.x, 487f);
		this.ContentR = this.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>();
		this.ContentR.sizeDelta = new Vector2(this.ContentR.sizeDelta.x, 487f);
		this.ContentR.GetChild(0).gameObject.SetActive(false);
		this.ContentR.GetChild(1).gameObject.SetActive(true);
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		for (int i = 0; i < 5; i++)
		{
			component2 = this.ContentR.GetChild(1).GetChild(i).GetComponent<UIText>();
			RectTransform rectTransform = component2.rectTransform;
			component2.font = ttffont;
			UIText[] refreshTextList2 = this.RefreshTextList;
			this.Listindex = (listindex = this.Listindex) + 1;
			refreshTextList2[(int)listindex] = component2;
			if (i <= 3)
			{
				component2.text = mStringTable.GetStringByID((uint)(14528 + i));
			}
			else
			{
				component2.text = mStringTable.GetStringByID(14532u);
			}
			rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, num2 - num3 - 10f);
			num2 = rectTransform.anchoredPosition.y;
			num3 = component2.preferredHeight + 4f;
			rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, num3);
			num += num3 + 20f;
		}
		if (num <= 447f)
		{
			this.ScrollR.GetComponent<CScrollRect>().enabled = false;
			this.ScrollR.GetComponent<Mask>().enabled = false;
			this.ScrollR.GetComponent<Image>().enabled = false;
		}
		else
		{
			this.ContentR.sizeDelta = new Vector2(this.ContentR.sizeDelta.x, num + 40f);
		}
	}

	// Token: 0x06000DCD RID: 3533 RVA: 0x00162380 File Offset: 0x00160580
	public void OnClose()
	{
	}

	// Token: 0x06000DCE RID: 3534 RVA: 0x00162384 File Offset: 0x00160584
	public void UpdateNetwork(byte[] meg)
	{
		if (meg[0] == 35)
		{
			for (int i = 0; i < this.RefreshTextList.Length; i++)
			{
				this.RefreshTextList[i].enabled = false;
				this.RefreshTextList[i].enabled = true;
			}
		}
	}

	// Token: 0x04002CF6 RID: 11510
	private Transform transform;

	// Token: 0x04002CF7 RID: 11511
	private RectTransform ContentR;

	// Token: 0x04002CF8 RID: 11512
	private RectTransform ScrollR;

	// Token: 0x04002CF9 RID: 11513
	private UIText[] RefreshTextList = new UIText[6];

	// Token: 0x04002CFA RID: 11514
	private byte Listindex;

	// Token: 0x04002CFB RID: 11515
	private GameObject GO;

	// Token: 0x04002CFC RID: 11516
	private UISummonMonster MainRef;

	// Token: 0x020002B1 RID: 689
	private enum UIControl
	{
		// Token: 0x04002CFE RID: 11518
		Background,
		// Token: 0x04002CFF RID: 11519
		Title,
		// Token: 0x04002D00 RID: 11520
		Scroll,
		// Token: 0x04002D01 RID: 11521
		Close
	}
}
