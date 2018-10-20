using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020003FA RID: 1018
public struct _UIFBMissionPrice
{
	// Token: 0x060014EE RID: 5358 RVA: 0x0023F9B8 File Offset: 0x0023DBB8
	public _UIFBMissionPrice(Transform transform, Font font)
	{
		this.gameobject = transform.gameObject;
		this.recttransform = (transform as RectTransform);
		this.Title = transform.GetChild(0).GetComponent<UIText>();
		this.Title.font = font;
		this.Price = new _UIFBMissionPrice._UIPrice[4];
		GUIManager instance = GUIManager.Instance;
		for (int i = 0; i < 4; i++)
		{
			this.Price[i] = new _UIFBMissionPrice._UIPrice(instance, transform.GetChild(i + 1), font);
		}
	}

	// Token: 0x17000097 RID: 151
	// (get) Token: 0x060014F0 RID: 5360 RVA: 0x0023FA74 File Offset: 0x0023DC74
	// (set) Token: 0x060014EF RID: 5359 RVA: 0x0023FA40 File Offset: 0x0023DC40
	public float Top
	{
		get
		{
			return this.recttransform.anchoredPosition.y;
		}
		set
		{
			this.recttransform.anchoredPosition = new Vector2(this.recttransform.anchoredPosition.x, value);
		}
	}

	// Token: 0x060014F1 RID: 5361 RVA: 0x0023FA94 File Offset: 0x0023DC94
	public void Show(ushort ItemID)
	{
		DataManager instance = DataManager.Instance;
		Equip recordByKey = instance.EquipTable.GetRecordByKey(ItemID);
		ComboBox recordByKey2 = instance.ComboBoxTable.GetRecordByKey(recordByKey.PropertiesInfo[1].Propertieskey);
		for (int i = 0; i < 4; i++)
		{
			if (recordByKey2.ItemData[i].ItemID == 0)
			{
				this.Price[i].gameobject.SetActive(false);
			}
			else
			{
				this.Price[i].gameobject.SetActive(true);
				this.Price[i].SetPrice(recordByKey2.ItemData[i].ItemID, recordByKey2.ItemData[i].ItemCount);
			}
		}
		this.gameobject.SetActive(true);
	}

	// Token: 0x060014F2 RID: 5362 RVA: 0x0023FB70 File Offset: 0x0023DD70
	public void SetTitle(string title)
	{
		this.Title.text = title;
		this.Title.SetLayoutDirty();
		this.Title.cachedTextGeneratorForLayout.Invalidate();
		if (this.Title.preferredWidth > this.Title.rectTransform.rect.width)
		{
			this.Title.resizeTextForBestFit = true;
			int fontSize = this.Title.fontSize;
			this.Title.resizeTextMaxSize = fontSize;
			this.Title.resizeTextMinSize = fontSize - 8;
		}
	}

	// Token: 0x060014F3 RID: 5363 RVA: 0x0023FC00 File Offset: 0x0023DE00
	public void Hide()
	{
		this.gameobject.SetActive(false);
	}

	// Token: 0x060014F4 RID: 5364 RVA: 0x0023FC10 File Offset: 0x0023DE10
	public void TextRefresh()
	{
		this.Title.enabled = false;
		this.Title.enabled = true;
		for (int i = 0; i < 4; i++)
		{
			this.Price[i].TextRefresh();
		}
	}

	// Token: 0x060014F5 RID: 5365 RVA: 0x0023FC58 File Offset: 0x0023DE58
	public void OnClose()
	{
		for (int i = 0; i < 4; i++)
		{
			this.Price[i].OnClose();
		}
	}

	// Token: 0x04003DCD RID: 15821
	private GameObject gameobject;

	// Token: 0x04003DCE RID: 15822
	private RectTransform recttransform;

	// Token: 0x04003DCF RID: 15823
	private UIText Title;

	// Token: 0x04003DD0 RID: 15824
	private _UIFBMissionPrice._UIPrice[] Price;

	// Token: 0x020003FB RID: 1019
	public struct _UIPrice
	{
		// Token: 0x060014F6 RID: 5366 RVA: 0x0023FC88 File Offset: 0x0023DE88
		public _UIPrice(GUIManager GM, Transform transform, Font font)
		{
			this.GM = GM;
			this.gameobject = transform.gameObject;
			this.ItemTrans = transform.GetChild(0);
			this.ItemBtn = this.ItemTrans.GetComponent<UIHIBtn>();
			this.NumText = transform.GetChild(1).GetComponent<UIText>();
			this.NumText.font = font;
			GM.InitianHeroItemImg(this.ItemTrans, eHeroOrItem.Item, 0, 0, 0, 0, false, false, false, false);
			this.NumStr = StringManager.Instance.SpawnString(30);
		}

		// Token: 0x060014F7 RID: 5367 RVA: 0x0023FD0C File Offset: 0x0023DF0C
		public void SetPrice(ushort ItemID, ushort Num)
		{
			this.GM.ChangeHeroItemImg(this.ItemTrans, eHeroOrItem.Item, ItemID, 0, 0, 0);
			this.NumText.text = string.Empty;
			this.NumStr.ClearString();
			this.NumStr.IntToFormat((long)Num, 1, false);
			if (this.GM.IsArabic)
			{
				this.NumStr.AppendFormat("{0}x");
			}
			else
			{
				this.NumStr.AppendFormat("x{0}");
			}
			this.NumText.text = this.NumStr.ToString();
		}

		// Token: 0x060014F8 RID: 5368 RVA: 0x0023FDA8 File Offset: 0x0023DFA8
		public void TextRefresh()
		{
			this.ItemBtn.Refresh_FontTexture();
			this.NumText.enabled = false;
			this.NumText.enabled = true;
		}

		// Token: 0x060014F9 RID: 5369 RVA: 0x0023FDD0 File Offset: 0x0023DFD0
		public void OnClose()
		{
			StringManager.Instance.DeSpawnString(this.NumStr);
		}

		// Token: 0x04003DD1 RID: 15825
		public const float Height = 97f;

		// Token: 0x04003DD2 RID: 15826
		public GameObject gameobject;

		// Token: 0x04003DD3 RID: 15827
		private Transform ItemTrans;

		// Token: 0x04003DD4 RID: 15828
		private UIHIBtn ItemBtn;

		// Token: 0x04003DD5 RID: 15829
		private UIText NumText;

		// Token: 0x04003DD6 RID: 15830
		private CString NumStr;

		// Token: 0x04003DD7 RID: 15831
		private GUIManager GM;
	}
}
