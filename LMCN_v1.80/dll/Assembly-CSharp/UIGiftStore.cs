using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000850 RID: 2128
public class UIGiftStore : UIBag
{
	// Token: 0x06002C02 RID: 11266 RVA: 0x004857F0 File Offset: 0x004839F0
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager instance = GUIManager.Instance;
		UIBag.ClickType clickType = (UIBag.ClickType)(instance.BagTagSaved[0] & 3);
		if (clickType != UIBag.ClickType.ShopTag)
		{
			instance.BagTagSaved[0] = 1;
		}
		base.OnOpen(arg1, arg2);
		this.MainTitle.text = DataManager.Instance.mStringTable.GetStringByID(9092u);
		this.ThisTransform.GetChild(2).gameObject.SetActive(false);
		RectTransform component = this.ThisTransform.GetChild(3).GetComponent<RectTransform>();
		for (int i = 0; i < component.childCount; i++)
		{
			component.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector2(-329f + (float)(149 * i), 146.5f);
		}
		component = this.ThisTransform.GetChild(4).GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(-31f, 116.5f);
		component = this.ThisTransform.GetChild(5).GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(-31f, -97f);
		component = this.ThisTransform.GetChild(6).GetChild(0).GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(776f, 426f);
		component.anchoredPosition = new Vector2(-30.78f, -98.3f);
		this.TitleText = this.ThisTransform.GetChild(6).GetChild(1).GetComponent<UIText>();
		this.TitleText.font = instance.GetTTFFont();
		this.TitleText.gameObject.SetActive(true);
		base.AddRefreshText(this.TitleText);
		this.ThisTransform.GetChild(8).GetChild(1).gameObject.SetActive(false);
		this.ReceiveName = StringManager.Instance.SpawnString(100);
		this.SendName = StringManager.Instance.SpawnString(30);
		this.SetReceiveName(instance.SendTag, instance.SendName);
	}

	// Token: 0x06002C03 RID: 11267 RVA: 0x004859DC File Offset: 0x00483BDC
	public void SetReceiveName(CString Tag, CString Name)
	{
		this.SendName.ClearString();
		this.SendName.Append(Name);
		this.ReceiveName.ClearString();
		this.ReceiveName.StringToFormat(Tag);
		this.ReceiveName.StringToFormat(Name);
		this.ReceiveName.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9094u));
		this.TitleText.text = this.ReceiveName.ToString();
		this.TitleText.SetAllDirty();
		this.TitleText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002C04 RID: 11268 RVA: 0x00485A78 File Offset: 0x00483C78
	protected override void ChangeBagTag(UIBag.ClickType Tag)
	{
		base.ChangeBagTag(Tag);
		this.MainTitle.text = DataManager.Instance.mStringTable.GetStringByID(9092u);
		byte b = 0;
		while ((int)b < this.ScrollItem.Length)
		{
			this.ScrollItem[(int)b].BuyUseBtn.m_BtnID1 = 14;
			b += 1;
		}
	}

	// Token: 0x06002C05 RID: 11269 RVA: 0x00485AE0 File Offset: 0x00483CE0
	public override void OnButtonClick(UIButton sender)
	{
		base.OnButtonClick(sender);
		if (sender.m_BtnID1 == 14)
		{
			StringTable mStringTable = DataManager.Instance.mStringTable;
			if (this.ShopType == 1 && this.ScrollItem[sender.m_BtnID2].ItemPrice > DataManager.Instance.RoleAttr.Diamond)
			{
				GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(3966u), mStringTable.GetStringByID(646u), 4, mStringTable.GetStringByID(4507u), 0, 0, true, false, false, false, false);
				return;
			}
			this.SelBuyIndex = (byte)sender.m_BtnID2;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 10, (int)this.ScrollItem[sender.m_BtnID2].ItemSN << 16 | (int)(16 | this.ShopType));
		}
	}

	// Token: 0x06002C06 RID: 11270 RVA: 0x00485BB4 File Offset: 0x00483DB4
	public override void OnClose()
	{
		base.OnClose();
		StringManager.Instance.DeSpawnString(this.ReceiveName);
		StringManager.Instance.DeSpawnString(this.SendName);
	}

	// Token: 0x06002C07 RID: 11271 RVA: 0x00485BEC File Offset: 0x00483DEC
	public override void UpdateUI(int arge1, int arge2)
	{
		int num = arge1 >> 16;
		if (num != 1)
		{
			return;
		}
		if (arge1 == 65537)
		{
			ushort b = (ushort)(arge2 >> 16);
			ushort num2 = (ushort)(arge2 & 65535);
			if (this.ScrollItem[(int)this.SelBuyIndex].ItemID != num2)
			{
				byte b2 = 0;
				while ((int)b2 < this.ScrollItem.Length)
				{
					if (this.ScrollItem[(int)b2].ItemID == num2)
					{
						this.SelBuyIndex = b2;
						break;
					}
					b2 += 1;
				}
			}
			DataManager.Instance.sendBuySendItem(this.ShopType, this.ScrollItem[(int)this.SelBuyIndex].ItemSN, this.ScrollItem[(int)this.SelBuyIndex].ItemID, this.SendName, (ushort)Mathf.Max(1, (int)b));
		}
		else if (arge1 == 65540)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)DataManager.Instance.EquipTable.GetRecordByKey(this.ScrollItem[(int)this.SelBuyIndex].ItemID).EquipName));
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9697u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
		}
		else
		{
			base.UpdateUI(arge1, arge2);
		}
	}

	// Token: 0x06002C08 RID: 11272 RVA: 0x00485D64 File Offset: 0x00483F64
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Refresh)
		{
			if (networkNews == NetworkNews.Refresh_Alliance)
			{
				if (DataManager.Instance.RoleAlliance.Id == 0u)
				{
					Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					if (door != null)
					{
						door.CloseMenu_Alliance(EGUIWindow.UI_BagFilter);
					}
				}
			}
		}
		else
		{
			base.ChangeObjTag(this.CurrentObjTag, true, false);
		}
	}

	// Token: 0x04007887 RID: 30855
	private UIText TitleText;

	// Token: 0x04007888 RID: 30856
	private CString ReceiveName;

	// Token: 0x04007889 RID: 30857
	private CString SendName;
}
