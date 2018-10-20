using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200027C RID: 636
public class UIMonsterInfo : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06000C28 RID: 3112 RVA: 0x001184E4 File Offset: 0x001166E4
	public override void OnOpen(int arg1, int arg2)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 3);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			base.transform.GetChild(3).GetComponent<CustomImage>().enabled = false;
		}
		else
		{
			base.transform.GetChild(3).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		}
		base.transform.GetChild(3).GetChild(0).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		UIButton component = base.transform.GetChild(3).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		this.MonsterType = (UIMapMonster.eMonsterType)arg2;
		MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey((ushort)arg1);
		UIText component2 = base.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = mStringTable.GetStringByID(8354u);
		UIText[] refreshTextList = this.RefreshTextList;
		byte listindex;
		this.Listindex = (listindex = this.Listindex) + 1;
		refreshTextList[(int)listindex] = component2;
		component2 = base.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = mStringTable.GetStringByID((uint)recordByKey.NameID);
		UIText[] refreshTextList2 = this.RefreshTextList;
		this.Listindex = (listindex = this.Listindex) + 1;
		refreshTextList2[(int)listindex] = component2;
		this.ContentR = base.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>();
		Image component3 = this.ContentR.GetChild(0).GetChild(3).GetComponent<Image>();
		float num = 0f;
		CString cstring;
		for (int i = 0; i < 3; i++)
		{
			cstring = StringManager.Instance.SpawnString(360);
			cstring.ClearString();
			component2 = this.ContentR.GetChild(0).GetChild(i).GetComponent<UIText>();
			component2.font = ttffont;
			UIText[] refreshTextList3 = this.RefreshTextList;
			this.Listindex = (listindex = this.Listindex) + 1;
			refreshTextList3[(int)listindex] = component2;
			cstring.StringToFormat(mStringTable.GetStringByID((uint)(8355 + i)));
			cstring.StringToFormat(mStringTable.GetStringByID((uint)recordByKey.Content[i]));
			cstring.AppendFormat("{0}{1}");
			component2.text = cstring.ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			component2.cachedTextGeneratorForLayout.Invalidate();
			num += component2.preferredHeight;
			this.InfoStr.Add(cstring);
		}
		float num2 = 0f;
		if (component2.preferredHeight + component2.rectTransform.anchoredPosition.y * -1f > component3.rectTransform.anchoredPosition.y * -1f)
		{
			num2 = component2.preferredHeight - component2.rectTransform.sizeDelta.y;
			component3.rectTransform.anchoredPosition = new Vector2(component3.rectTransform.anchoredPosition.x, component3.rectTransform.anchoredPosition.y - num2);
			component2.rectTransform.sizeDelta = new Vector2(component2.rectTransform.sizeDelta.x, component2.rectTransform.sizeDelta.y + num2);
		}
		cstring = StringManager.Instance.SpawnString(700);
		component2 = this.ContentR.GetChild(0).GetChild(4).GetComponent<UIText>();
		component2.font = ttffont;
		UIText[] refreshTextList4 = this.RefreshTextList;
		this.Listindex = (listindex = this.Listindex) + 1;
		refreshTextList4[(int)listindex] = component2;
		if (this.MonsterType == UIMapMonster.eMonsterType.ResourceMonster)
		{
			cstring.StringToFormat(mStringTable.GetStringByID(8340u));
			cstring.StringToFormat(mStringTable.GetStringByID(8359u));
			cstring.StringToFormat(mStringTable.GetStringByID(8360u));
			cstring.StringToFormat(mStringTable.GetStringByID(8334u));
			cstring.AppendFormat("{0}\n{1}\n{2}\n{3}");
		}
		else if (this.MonsterType == UIMapMonster.eMonsterType.SummonMonster)
		{
			cstring.StringToFormat(mStringTable.GetStringByID(8340u));
			cstring.StringToFormat(mStringTable.GetStringByID(8358u));
			cstring.StringToFormat(mStringTable.GetStringByID(8360u));
			cstring.StringToFormat(mStringTable.GetStringByID(8334u));
			cstring.AppendFormat("{0}\n{1}\n{2}\n{3}");
		}
		else
		{
			cstring.StringToFormat(mStringTable.GetStringByID(8340u));
			cstring.StringToFormat(mStringTable.GetStringByID(8358u));
			cstring.StringToFormat(mStringTable.GetStringByID(8359u));
			cstring.StringToFormat(mStringTable.GetStringByID(8360u));
			cstring.StringToFormat(mStringTable.GetStringByID(8334u));
			cstring.AppendFormat("{0}\n{1}\n{2}\n{3}\n{4}");
		}
		component2.text = cstring.ToString();
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		component2.cachedTextGeneratorForLayout.Invalidate();
		this.InfoStr.Add(cstring);
		if (num2 > 0f)
		{
			component2.rectTransform.anchoredPosition = new Vector2(component2.rectTransform.anchoredPosition.x, component2.rectTransform.anchoredPosition.y - num2);
			component2.rectTransform.sizeDelta = new Vector2(component2.rectTransform.sizeDelta.x, component2.rectTransform.sizeDelta.y - num2);
		}
		if (num + component2.preferredHeight <= 399f)
		{
			base.transform.GetChild(2).GetComponent<CScrollRect>().enabled = false;
			base.transform.GetChild(2).GetComponent<Mask>().enabled = false;
			base.transform.GetChild(2).GetComponent<Image>().enabled = false;
		}
		else
		{
			component2.rectTransform.sizeDelta = new Vector2(component2.rectTransform.sizeDelta.x, component2.preferredHeight);
			this.ContentR.sizeDelta = new Vector2(this.ContentR.sizeDelta.x, num + component2.preferredHeight + 40f);
			if (component2.preferredHeight >= 219f)
			{
				this.ContentR.anchoredPosition = new Vector2(this.ContentR.anchoredPosition.x, 16f);
			}
		}
	}

	// Token: 0x06000C29 RID: 3113 RVA: 0x00118BA4 File Offset: 0x00116DA4
	public override void OnClose()
	{
		for (int i = 0; i < this.InfoStr.Count; i++)
		{
			StringManager.Instance.DeSpawnString(this.InfoStr[i]);
		}
	}

	// Token: 0x06000C2A RID: 3114 RVA: 0x00118BE4 File Offset: 0x00116DE4
	public void OnButtonClick(UIButton sender)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		door.CloseMenu(false);
	}

	// Token: 0x06000C2B RID: 3115 RVA: 0x00118C0C File Offset: 0x00116E0C
	public override void UpdateNetwork(byte[] meg)
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

	// Token: 0x04002815 RID: 10261
	private RectTransform ContentR;

	// Token: 0x04002816 RID: 10262
	private List<CString> InfoStr = new List<CString>();

	// Token: 0x04002817 RID: 10263
	private UIText[] RefreshTextList = new UIText[6];

	// Token: 0x04002818 RID: 10264
	private byte Listindex;

	// Token: 0x04002819 RID: 10265
	private UIMapMonster.eMonsterType MonsterType;

	// Token: 0x0200027D RID: 637
	private enum UIControl
	{
		// Token: 0x0400281B RID: 10267
		Background,
		// Token: 0x0400281C RID: 10268
		Title,
		// Token: 0x0400281D RID: 10269
		Scroll,
		// Token: 0x0400281E RID: 10270
		Close
	}
}
