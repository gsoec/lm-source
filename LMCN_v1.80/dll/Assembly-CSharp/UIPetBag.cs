using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x02000458 RID: 1112
public class UIPetBag : GUIWindow, IUpDateScrollPanel, IUIButtonScaleHandler2, IUIButtonClickHandler, IUIHIBtnUpDownHandler
{
	// Token: 0x06001677 RID: 5751 RVA: 0x0026B210 File Offset: 0x00269410
	void IUIButtonClickHandler.OnButtonClick(UIButton sender)
	{
		UIPetBag.ClickType btnID = (UIPetBag.ClickType)sender.m_BtnID1;
		if (btnID != UIPetBag.ClickType.Exit)
		{
			this.UpdateTag((UIPetBag.ClickType)sender.m_BtnID1, false);
		}
		else
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu(false);
		}
	}

	// Token: 0x06001678 RID: 5752 RVA: 0x0026B260 File Offset: 0x00269460
	void IUIHIBtnUpDownHandler.OnHIButtonDown(UIHIBtn sender)
	{
		this.SelBtn = sender;
	}

	// Token: 0x06001679 RID: 5753 RVA: 0x0026B26C File Offset: 0x0026946C
	void IUIHIBtnUpDownHandler.OnHIButtonUp(UIHIBtn sender)
	{
	}

	// Token: 0x0600167A RID: 5754 RVA: 0x0026B270 File Offset: 0x00269470
	void IUIButtonScaleHandler2.OnFinish()
	{
		if (this.SelBtn != null)
		{
			GUIManager.Instance.m_ItemInfo.Show(EUIItemInfo.ItemList, this.SelBtn.HIID, 0, 0);
		}
	}

	// Token: 0x0600167B RID: 5755 RVA: 0x0026B2AC File Offset: 0x002694AC
	void IUpDateScrollPanel.UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		int num = dataIdx * 8;
		int num2 = panelObjectIdx * 8;
		ushort[] sortPetItemData = PetManager.Instance.sortPetItemData;
		for (int i = 0; i < 8; i++)
		{
			if (this.ItemArray[num2 + i] == null)
			{
				this.ItemArray[num2 + i] = item.transform.GetChild(i).GetComponent<UIHIBtn>();
				this.ItemArray[num2 + i].m_UpDownHandler = this;
				this.ItemArray[num2 + i].gameObject.AddComponent<EventPatchery>().SetEvnetObj(this.PetScroll.GetComponent<CScrollRect>());
				this.ItemArray[num2 + i].GetComponent<uButtonScale>().m_Handler = this;
			}
			if (num + i < (int)this.Count)
			{
				this.ItemArray[num2 + i].gameObject.SetActive(true);
				ushort itemID = PetManager.Instance.GetItemData((int)sortPetItemData[(int)this.Start + num + i]).ItemID;
				GUIManager.Instance.ChangeHeroItemImg(this.ItemArray[num2 + i].transform, eHeroOrItem.Item, itemID, 0, 0, (int)DataManager.Instance.GetCurItemQuantity(itemID, 0));
			}
			else
			{
				this.ItemArray[num2 + i].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x0600167C RID: 5756 RVA: 0x0026B3EC File Offset: 0x002695EC
	void IUpDateScrollPanel.ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x0600167D RID: 5757 RVA: 0x0026B3F0 File Offset: 0x002695F0
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager instance = GUIManager.Instance;
		Font ttffont = instance.GetTTFFont();
		Image image = base.transform.GetChild(8).GetComponent<Image>();
		StringTable mStringTable = DataManager.Instance.mStringTable;
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			if (instance.bOpenOnIPhoneX)
			{
				image.enabled = false;
			}
			else
			{
				image.sprite = door.LoadSprite("UI_main_close_base");
				image.material = door.LoadMaterial();
			}
			UIButton component = base.transform.GetChild(8).GetChild(0).GetComponent<UIButton>();
			component.m_BtnID1 = 4;
			component.m_Handler = this;
			image = component.image;
			image.sprite = door.LoadSprite("UI_main_close");
			image.material = door.LoadMaterial();
		}
		this.TitleText = base.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.TitleText.font = ttffont;
		this.TitleText.text = mStringTable.GetStringByID(16079u);
		this.Tag = new UIPetBag._Tag[4];
		for (int i = 0; i < this.Tag.Length; i++)
		{
			UIButton component = base.transform.GetChild(3 + i).GetComponent<UIButton>();
			component.m_BtnID1 = 0 + i;
			component.m_Handler = this;
			this.Tag[i].Alpha = base.transform.GetChild(3 + i).GetChild(0).GetComponent<CanvasGroup>();
			this.Tag[i].Caption = base.transform.GetChild(3 + i).GetChild(1).GetComponent<UIText>();
			this.Tag[i].Caption.font = ttffont;
		}
		this.TageColor = this.Tag[0].Caption.color;
		PetManager instance2 = PetManager.Instance;
		this.CurTag = (UIPetBag.ClickType)instance2.UISave[0];
		if (this.CurTag > UIPetBag.ClickType.Tage4)
		{
			this.CurTag = UIPetBag.ClickType.Tage4;
		}
		this.Tag[0].Caption.text = mStringTable.GetStringByID(253u);
		this.Tag[1].Caption.text = mStringTable.GetStringByID(14654u);
		this.Tag[2].Caption.text = mStringTable.GetStringByID(879u);
		this.Tag[3].Caption.text = mStringTable.GetStringByID(16050u);
		this.NoItemObj = base.transform.GetChild(7).gameObject;
		this.MsgText = base.transform.GetChild(7).GetChild(0).GetComponent<UIText>();
		this.MsgText.font = ttffont;
		this.MsgText.text = mStringTable.GetStringByID(744u);
		int childCount = base.transform.GetChild(2).childCount;
		for (int j = 0; j < childCount; j++)
		{
			instance.InitianHeroItemImg(base.transform.GetChild(2).GetChild(j), eHeroOrItem.Item, 0, 0, 0, 0, true, false, true, true);
			UnityEngine.Object.DestroyImmediate(base.transform.GetChild(2).GetChild(j).GetComponent<IgnoreRaycast>(), false);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
	}

	// Token: 0x0600167E RID: 5758 RVA: 0x0026B76C File Offset: 0x0026996C
	public override void OnClose()
	{
		if (this.PetScrollRect != null)
		{
			PetManager instance = PetManager.Instance;
			instance.UISave[0] = (byte)this.CurTag;
			instance.UISave[1] = (byte)this.PetScroll.GetBeginIdx();
			GameConstants.GetBytes(this.PetScrollRect.anchoredPosition.y, instance.UISave, 2);
		}
	}

	// Token: 0x0600167F RID: 5759 RVA: 0x0026B7D4 File Offset: 0x002699D4
	private void UpdateTag(UIPetBag.ClickType tag, bool bForce = false)
	{
		if (!bForce && tag == this.CurTag)
		{
			return;
		}
		PetManager.Instance.SortPetItemData();
		if (tag != this.CurTag)
		{
			this.Tag[(int)this.CurTag].Alpha.alpha = 0f;
			this.Tag[(int)this.CurTag].Caption.color = this.TageColor;
			this.tabBtnColorA = 1f;
			this.tabBtnTime = 0f;
		}
		this.CurTag = tag;
		this.Tag[(int)this.CurTag].Caption.color = Color.white;
		if (this.bInit > 0)
		{
			return;
		}
		this.Count = 0;
		if (this.CurTag == UIPetBag.ClickType.Tage1)
		{
			this.Start = DataManager.Instance.sortItemDataStart[5];
			this.Count = DataManager.Instance.sortItemDataCount[5];
		}
		else if (this.CurTag == UIPetBag.ClickType.Tage2)
		{
			this.Start = DataManager.Instance.sortItemDataStart[0];
			this.Count = DataManager.Instance.sortItemDataCount[0];
		}
		else if (this.CurTag == UIPetBag.ClickType.Tage3)
		{
			this.Start = DataManager.Instance.sortItemDataStart[1];
			this.Count = DataManager.Instance.sortItemDataCount[1];
		}
		if (this.CurTag == UIPetBag.ClickType.Tage4)
		{
			this.Start = DataManager.Instance.sortItemDataStart[28];
			this.Count = DataManager.Instance.sortItemDataCount[28];
		}
		if (this.Count > 0)
		{
			ushort num = this.Count;
			num = (ushort)((num >> 3) + (((num & 7) <= 0) ? 0 : 1));
			this.ScrollHeight.Clear();
			for (int i = 0; i < (int)num; i++)
			{
				this.ScrollHeight.Add(80f);
			}
			this.PetScroll.gameObject.SetActive(true);
			this.NoItemObj.SetActive(false);
			if (bForce)
			{
				Vector2 anchoredPosition = this.PetScrollRect.anchoredPosition;
				int beginIdx = this.PetScroll.GetBeginIdx();
				this.PetScroll.AddNewDataHeight(this.ScrollHeight, true, true);
				this.PetScroll.GoTo(beginIdx, anchoredPosition.y);
			}
			else
			{
				this.PetScroll.AddNewDataHeight(this.ScrollHeight, true, true);
			}
		}
		else
		{
			this.PetScroll.gameObject.SetActive(false);
			this.NoItemObj.SetActive(true);
		}
	}

	// Token: 0x06001680 RID: 5760 RVA: 0x0026BA5C File Offset: 0x00269C5C
	public override void UpdateNetwork(byte[] meg)
	{
		if (this.bInit > 0)
		{
			return;
		}
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Login || networkNews == NetworkNews.Refresh_Item)
		{
			this.UpdateTag(this.CurTag, true);
		}
		else if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			for (int i = 0; i < this.ItemArray.Length; i++)
			{
				if (this.ItemArray[i] != null)
				{
					this.ItemArray[i].Refresh_FontTexture();
				}
			}
			for (int j = 0; j < this.Tag.Length; j++)
			{
				this.Tag[j].Caption.enabled = false;
				this.Tag[j].Caption.enabled = true;
			}
			this.MsgText.enabled = false;
			this.MsgText.enabled = true;
			this.TitleText.enabled = false;
			this.TitleText.enabled = true;
		}
	}

	// Token: 0x06001681 RID: 5761 RVA: 0x0026BB54 File Offset: 0x00269D54
	public override void UpdateUI(int arg1, int arg2)
	{
		if (PetManager.Instance.PetDataCount == 0)
		{
			StringTable mStringTable = DataManager.Instance.mStringTable;
			GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(17138u), mStringTable.GetStringByID(17139u), mStringTable.GetStringByID(3968u), this, 22, 255, true, false, true, false, false);
		}
	}

	// Token: 0x06001682 RID: 5762 RVA: 0x0026BBB4 File Offset: 0x00269DB4
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK && arg2 == 255)
		{
			GUIManager.Instance.BuildingData.ManorGuild((ushort)arg1, false);
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu(true);
		}
	}

	// Token: 0x06001683 RID: 5763 RVA: 0x0026BBFC File Offset: 0x00269DFC
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.bInit > 0)
		{
			this.bInit -= 1;
			if (this.bInit == 0)
			{
				this.ItemArray = new UIHIBtn[64];
				this.PetScroll = base.transform.GetChild(1).GetComponent<ScrollPanel>();
				this.PetScroll.IntiScrollPanel(465.3f, 3f, 9f, this.ScrollHeight, 8, this);
				this.PetScrollRect = this.PetScroll.transform.GetChild(0).GetComponent<RectTransform>();
				this.UpdateTag(this.CurTag, true);
				if (this.PetScroll.gameObject.activeSelf)
				{
					Vector2 anchoredPosition = this.PetScrollRect.anchoredPosition;
					anchoredPosition.y = GameConstants.ConvertBytesToFloat(PetManager.Instance.UISave, 2);
					this.PetScroll.GoTo((int)PetManager.Instance.UISave[1], anchoredPosition.y);
				}
				for (int i = 0; i < this.Tag.Length; i++)
				{
					this.Tag[i].Caption.enabled = false;
					this.Tag[i].Caption.enabled = true;
				}
				this.MsgText.enabled = false;
				this.MsgText.enabled = true;
				this.TitleText.enabled = false;
				this.TitleText.enabled = true;
			}
		}
		this.tabBtnTime += Time.deltaTime;
		if (this.tabBtnTime >= 0.05f)
		{
			this.tabBtnColorA += 0.05f;
			if (this.tabBtnColorA >= 2f)
			{
				this.tabBtnColorA = 0f;
			}
			float alpha = (this.tabBtnColorA <= 1f) ? this.tabBtnColorA : (2f - this.tabBtnColorA);
			this.Tag[(int)this.CurTag].Alpha.alpha = alpha;
			this.tabBtnTime = 0f;
		}
	}

	// Token: 0x04004382 RID: 17282
	private const byte ItemCountHSize = 8;

	// Token: 0x04004383 RID: 17283
	private ScrollPanel PetScroll;

	// Token: 0x04004384 RID: 17284
	private RectTransform PetScrollRect;

	// Token: 0x04004385 RID: 17285
	private List<float> ScrollHeight = new List<float>();

	// Token: 0x04004386 RID: 17286
	private UIHIBtn[] ItemArray;

	// Token: 0x04004387 RID: 17287
	private UIHIBtn SelBtn;

	// Token: 0x04004388 RID: 17288
	private UIText MsgText;

	// Token: 0x04004389 RID: 17289
	private UIText TitleText;

	// Token: 0x0400438A RID: 17290
	private GameObject NoItemObj;

	// Token: 0x0400438B RID: 17291
	private UIPetBag.ClickType CurTag;

	// Token: 0x0400438C RID: 17292
	private ushort Start;

	// Token: 0x0400438D RID: 17293
	private ushort Count;

	// Token: 0x0400438E RID: 17294
	private Color TageColor;

	// Token: 0x0400438F RID: 17295
	private byte bInit = 2;

	// Token: 0x04004390 RID: 17296
	private UIPetBag._Tag[] Tag;

	// Token: 0x04004391 RID: 17297
	private float tabBtnColorA = 1f;

	// Token: 0x04004392 RID: 17298
	private float tabBtnTime;

	// Token: 0x02000459 RID: 1113
	private enum UIControl
	{
		// Token: 0x04004394 RID: 17300
		Background,
		// Token: 0x04004395 RID: 17301
		ItemView,
		// Token: 0x04004396 RID: 17302
		Item,
		// Token: 0x04004397 RID: 17303
		Tage1,
		// Token: 0x04004398 RID: 17304
		Tage2,
		// Token: 0x04004399 RID: 17305
		Tage3,
		// Token: 0x0400439A RID: 17306
		Tage4,
		// Token: 0x0400439B RID: 17307
		Message,
		// Token: 0x0400439C RID: 17308
		Exit
	}

	// Token: 0x0200045A RID: 1114
	private enum ClickType
	{
		// Token: 0x0400439E RID: 17310
		Tage1,
		// Token: 0x0400439F RID: 17311
		Tage2,
		// Token: 0x040043A0 RID: 17312
		Tage3,
		// Token: 0x040043A1 RID: 17313
		Tage4,
		// Token: 0x040043A2 RID: 17314
		Exit
	}

	// Token: 0x0200045B RID: 1115
	private struct _Tag
	{
		// Token: 0x040043A3 RID: 17315
		public CanvasGroup Alpha;

		// Token: 0x040043A4 RID: 17316
		public UIText Caption;
	}
}
