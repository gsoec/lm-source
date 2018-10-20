using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200056F RID: 1391
public class UISimpleItemInfo : IUIHIBtnClickHandler
{
	// Token: 0x06001BB9 RID: 7097 RVA: 0x0031383C File Offset: 0x00311A3C
	public void Load()
	{
		UnityEngine.Object @object = GUIManager.Instance.m_ManagerAssetBundle.Load("UISimpleItemInfo");
		if (@object == null)
		{
			return;
		}
		GUIManager instance = GUIManager.Instance;
		Font ttffont = instance.GetTTFFont();
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
		gameObject.transform.SetParent(GUIManager.Instance.m_ItemInfoLayer, false);
		gameObject.SetActive(false);
		this.m_RectTransform = (RectTransform)gameObject.transform;
		this.m_BackRect = this.m_RectTransform.GetChild(0).GetComponent<RectTransform>();
		this.m_BackRect.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		this.Canvasgroup = this.m_RectTransform.GetComponent<CanvasGroup>();
		Transform child = this.m_RectTransform.GetChild(1);
		child.GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		this.InfoIcon = child.GetChild(0).GetComponent<CustomImage>();
		this.InfoIcon.hander = instance.m_ItemInfo;
		this.m_ItemBtn = child.GetComponent<UIHIBtn>();
		this.m_ItemBtn.m_Handler = this;
		instance.InitianHeroItemImg(child, eHeroOrItem.Item, 0, 0, 0, 0, false, false, true, true);
		this.ItemBtnRayCast = child.GetComponent<CanvasGroup>();
		this.ItemGo = child.gameObject;
		this.m_ItemRect = child.GetComponent<RectTransform>();
		this.InfoIcon.transform.SetAsLastSibling();
		this.m_HeroBtn = this.m_BackRect.GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
		instance.InitianHeroItemImg(this.m_HeroBtn.transform, eHeroOrItem.Hero, 0, 0, 0, 0, true, false, true, false);
		this.m_HeroBtn.transform.GetChild(0).gameObject.SetActive(true);
		this.CNBossIconObj = this.m_BackRect.GetChild(1).GetChild(2).gameObject;
		child = this.m_BackRect.GetChild(2);
		this.m_Name = child.GetComponent<UIText>();
		this.m_Name.font = ttffont;
		child = this.m_BackRect.GetChild(0).GetChild(0);
		this.m_OwnedText = child.GetComponent<UIText>();
		this.m_OwnedText.font = ttffont;
		child = this.m_BackRect.GetChild(3);
		this.m_Properties = child.GetComponent<UIText>();
		this.m_Properties.font = ttffont;
		this.m_BackRect.GetChild(0).GetChild(1).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		this.BossIcon = this.m_BackRect.GetChild(1).GetChild(1).GetComponent<CustomImage>();
		this.BossIcon.hander = instance.m_ItemInfo;
		this.m_BackRect.GetChild(1).GetChild(2).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		if (instance.IsArabic)
		{
			this.BossIcon.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		child = this.m_BackRect.GetChild(0).GetChild(2);
		this.m_Price = child.GetComponent<UIText>();
		this.m_Price.font = ttffont;
		child = this.m_BackRect.GetChild(1).GetChild(3);
		this.m_HeroLV = child.GetComponent<UIText>();
		this.m_HeroLV.font = ttffont;
		this.ItemPanel = (this.m_BackRect.GetChild(0) as RectTransform);
		this.HeroPanel = (this.m_BackRect.GetChild(1) as RectTransform);
		this.m_ItemLvText = this.ItemPanel.GetChild(3).GetComponent<UIText>();
		this.m_ItemLvText.font = ttffont;
		this.m_ItemKindText = this.ItemPanel.GetChild(4).GetComponent<UIText>();
		this.m_ItemKindText.font = ttffont;
		this.m_HeroName = this.HeroPanel.GetChild(4).GetComponent<UIText>();
		this.m_HeroName.font = ttffont;
		this.m_HeroName.color = new Color(0.624f, 0.91f, 0.922f);
		this.m_Coin = this.m_BackRect.GetChild(0).GetChild(1).GetComponent<Image>();
		this.OriHeight = this.m_BackRect.sizeDelta.y;
		this.rectProperties = this.m_Properties.rectTransform;
		this.OriTextHeight = this.rectProperties.sizeDelta.y;
		this.NameStr = StringManager.Instance.SpawnString(100);
		this.PropertiesStr = new CString(500);
		this.HeroNameStr = StringManager.Instance.SpawnString(30);
		this.OwnedStr = StringManager.Instance.SpawnString(30);
		this.PriceStr = StringManager.Instance.SpawnString(30);
		this.AddionalStr = new CString(500);
	}

	// Token: 0x06001BBA RID: 7098 RVA: 0x00313D0C File Offset: 0x00311F0C
	public void Unload()
	{
		if (this.m_RectTransform == null)
		{
			return;
		}
		UnityEngine.Object.Destroy(this.m_RectTransform.gameObject);
		this.m_RectTransform = null;
		this.m_ItemBtn = null;
		this.m_Name = null;
		this.m_OwnedText = null;
		this.m_Properties = null;
		this.m_Price = null;
		this.m_ButtonHint = null;
		StringManager.Instance.DeSpawnString(this.NameStr);
		StringManager.Instance.DeSpawnString(this.HeroNameStr);
		StringManager.Instance.DeSpawnString(this.OwnedStr);
		StringManager.Instance.DeSpawnString(this.PriceStr);
	}

	// Token: 0x06001BBB RID: 7099 RVA: 0x00313DB0 File Offset: 0x00311FB0
	public void Show(UIButtonHint hint, ushort ItemID, int Num = -1, UIButtonHint.ePosition position = UIButtonHint.ePosition.Original, Vector3? upsetPoint = null)
	{
		if (hint == null)
		{
			return;
		}
		if (GUIManager.Instance.m_LordInfo.m_ButtonHint != null)
		{
			GUIManager.Instance.m_LordInfo.Hide(GUIManager.Instance.m_LordInfo.m_ButtonHint);
		}
		DataManager instance = DataManager.Instance;
		RectTransform x = hint.transform as RectTransform;
		Equip recordByKey = instance.EquipTable.GetRecordByKey(ItemID);
		if (x == null || recordByKey.EquipKey != ItemID)
		{
			return;
		}
		if (recordByKey.EquipKind - 1 == 4 && GUIManager.Instance.FindMenu(EGUIWindow.Door) != null)
		{
			this.HeroID = recordByKey.SyntheticParts[0].SyntheticItem;
			this.ItemBtnRayCast.blocksRaycasts = true;
			this.InfoIcon.gameObject.SetActive(true);
		}
		else
		{
			this.ItemBtnRayCast.blocksRaycasts = false;
			this.InfoIcon.gameObject.SetActive(false);
		}
		if (this.m_HeroBtn.gameObject.activeSelf)
		{
			this.ItemGo.SetActive(true);
			this.ItemPanel.gameObject.SetActive(true);
			this.HeroPanel.gameObject.SetActive(false);
		}
		ushort num;
		if (Num == -1)
		{
			num = instance.GetCurItemQuantity(ItemID, 0);
		}
		else
		{
			num = (ushort)Num;
		}
		this.m_RectTransform.gameObject.SetActive(true);
		this.m_RectTransform.SetAsLastSibling();
		GUIManager.Instance.ChangeHeroItemImg(this.m_ItemBtn.transform, eHeroOrItem.Item, ItemID, 0, 0, 0);
		UIItemInfo.SetNameProperties(this.m_Name, this.m_Properties, this.NameStr, this.PropertiesStr, ref recordByKey, this.AddionalStr);
		if (this.AddionalStr.Length > 0)
		{
			this.PropertiesStr.Append(this.AddionalStr);
			this.m_Properties.text = this.PropertiesStr.ToString();
			this.m_Properties.SetAllDirty();
			this.m_Properties.cachedTextGenerator.Invalidate();
		}
		Vector2 sizeDelta = this.rectProperties.sizeDelta;
		float num2 = this.m_Properties.preferredHeight - this.OriTextHeight;
		sizeDelta.y = this.m_Properties.preferredHeight;
		this.rectProperties.sizeDelta = sizeDelta;
		sizeDelta = this.m_BackRect.sizeDelta;
		sizeDelta.y = Mathf.Max(this.OriHeight, this.OriHeight + num2);
		this.m_BackRect.sizeDelta = sizeDelta;
		this.HeroNameStr.ClearString();
		EItemType eitemType = (EItemType)(recordByKey.EquipKind - 1);
		switch (eitemType)
		{
		case EItemType.EIT_SingleNumSynEquip:
		case EItemType.EIT_MultiNumSynEquip:
			this.HeroNameStr.IntToFormat((long)recordByKey.NeedLv, 1, false);
			this.HeroNameStr.AppendFormat(instance.mStringTable.GetStringByID(148u));
			this.m_ItemLvText.text = this.HeroNameStr.ToString();
			this.m_ItemLvText.SetAllDirty();
			this.m_ItemLvText.cachedTextGenerator.Invalidate();
			this.m_ItemLvText.color = new Color(0.46f, 1f, 1f);
			this.m_ItemKindText.text = instance.mStringTable.GetStringByID(886u);
			break;
		case EItemType.EIT_SynBook:
			this.m_ItemKindText.text = instance.mStringTable.GetStringByID(255u);
			break;
		case EItemType.EIT_SynBaseEquip:
			this.m_ItemKindText.text = instance.mStringTable.GetStringByID(254u);
			break;
		case EItemType.EIT_HeroStone:
			this.m_ItemKindText.text = instance.mStringTable.GetStringByID(256u);
			break;
		case EItemType.EIT_Consumables:
			this.m_ItemKindText.text = instance.mStringTable.GetStringByID(253u);
			break;
		default:
			if (eitemType != EItemType.EIT_EnhanceStone)
			{
				this.m_ItemKindText.text = string.Empty;
			}
			else
			{
				this.m_ItemKindText.text = instance.mStringTable.GetStringByID(16050u);
			}
			break;
		case EItemType.EIT_CaseByCase:
		{
			ECaseByCaseType ecaseByCaseType = (ECaseByCaseType)recordByKey.PropertiesInfo[0].Propertieskey;
			if (ecaseByCaseType == ECaseByCaseType.ECBCT_PetCore)
			{
				this.m_ItemKindText.text = instance.mStringTable.GetStringByID(14654u);
			}
			else if (ecaseByCaseType == ECaseByCaseType.ECBCT_PetMaterial)
			{
				this.m_ItemKindText.text = instance.mStringTable.GetStringByID(879u);
			}
			else
			{
				this.m_ItemKindText.text = string.Empty;
			}
			break;
		}
		}
		if ((recordByKey.EquipKind != 18 || recordByKey.PropertiesInfo[2].Propertieskey < 1 || recordByKey.PropertiesInfo[2].Propertieskey > 2) && (recordByKey.EquipKind != 11 || recordByKey.PropertiesInfo[0].Propertieskey < 6 || recordByKey.PropertiesInfo[0].Propertieskey > 7))
		{
			if (recordByKey.EquipKind == 19 && recordByKey.PropertiesInfo[3].Propertieskey == 1)
			{
				this.m_OwnedText.text = string.Empty;
			}
			else
			{
				this.OwnedStr.ClearString();
				this.OwnedStr.Append("(");
				this.OwnedStr.IntToFormat((long)num, 1, true);
				this.OwnedStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(79u));
				this.OwnedStr.Append(")");
				this.m_OwnedText.color = Color.white;
				this.m_OwnedText.text = this.OwnedStr.ToString();
				this.m_OwnedText.SetAllDirty();
				this.m_OwnedText.cachedTextGenerator.Invalidate();
			}
		}
		else
		{
			this.m_OwnedText.text = string.Empty;
		}
		if (recordByKey.RecoverPrice > 0u)
		{
			this.PriceStr.ClearString();
			this.PriceStr.IntToFormat((long)((ulong)recordByKey.RecoverPrice), 1, true);
			this.PriceStr.AppendFormat("{0}");
			this.m_Price.text = this.PriceStr.ToString();
			this.m_Price.SetAllDirty();
			this.m_Price.cachedTextGenerator.Invalidate();
			this.m_Coin.enabled = true;
		}
		else
		{
			this.m_Coin.enabled = false;
			this.m_Price.text = string.Empty;
		}
		hint.GetTipPosition(this.m_BackRect, position, upsetPoint);
		this.m_ItemRect.anchoredPosition = this.m_BackRect.anchoredPosition + this.ItemPosUpset;
		float num3 = -this.m_BackRect.anchoredPosition3D.y + this.m_BackRect.sizeDelta.y;
		if (num3 > GUIManager.Instance.m_MessageBoxLayer.rect.size.y)
		{
			this.m_Properties.fontSize = 18 - Convert.ToInt32((num3 - GUIManager.Instance.m_MessageBoxLayer.rect.size.y) * 0.038f);
			Vector2 sizeDelta2 = this.m_Properties.rectTransform.sizeDelta;
			sizeDelta2.y = Mathf.Max(66f, this.m_Properties.preferredHeight);
			this.m_Properties.rectTransform.sizeDelta = sizeDelta2;
			sizeDelta2 = this.m_BackRect.sizeDelta;
			sizeDelta2.y = Mathf.Max(186f, 123.6f + this.m_Properties.preferredHeight + 14.4f);
			this.m_BackRect.sizeDelta = sizeDelta2;
		}
		this.m_ButtonHint = hint;
		this.Canvasgroup.alpha = 1f;
	}

	// Token: 0x06001BBC RID: 7100 RVA: 0x003145BC File Offset: 0x003127BC
	public void ShowHero(UIButtonHint hint, ushort HeroID, ushort TeamIndex, ushort ArrayIndex)
	{
		if (hint == null)
		{
			return;
		}
		RectTransform rectTransform = hint.transform as RectTransform;
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		this.m_RectTransform.gameObject.SetActive(true);
		this.m_RectTransform.SetAsLastSibling();
		if (this.m_ItemBtn.gameObject.activeSelf)
		{
			this.ItemGo.SetActive(false);
			this.ItemPanel.gameObject.SetActive(false);
			this.HeroPanel.gameObject.SetActive(true);
		}
		HeroTeam recordByKey = instance.TeamTable.GetRecordByKey(TeamIndex);
		Hero recordByKey2 = instance.HeroTable.GetRecordByKey(recordByKey.Arrays[(int)ArrayIndex].Hero);
		if (recordByKey2.HeroTitle > 0)
		{
			this.m_Name.text = instance.mStringTable.GetStringByID((uint)recordByKey2.HeroTitle);
		}
		if (recordByKey.Arrays[(int)ArrayIndex].Type == 3)
		{
			this.BossIcon.gameObject.SetActive(true);
			instance2.ChangeHeroItemImg(this.m_HeroBtn.transform, eHeroOrItem.Hero, recordByKey2.HeroKey, recordByKey.HeroStar, 0, 0);
		}
		else
		{
			this.BossIcon.gameObject.SetActive(false);
			GUIManager.Instance.ChangeHeroItemImg(this.m_HeroBtn.transform, eHeroOrItem.Hero, recordByKey2.HeroKey, 1, 0, 0);
		}
		if (instance.UserLanguage == GameLanguage.GL_Chs)
		{
			this.CNBossIconObj.SetActive(this.BossIcon.gameObject.activeSelf);
			this.BossIcon.gameObject.SetActive(false);
		}
		instance2.tmpString.Remove(0, instance2.tmpString.Length);
		this.m_HeroLV.text = instance2.tmpString.AppendFormat(instance.mStringTable.GetStringByID(52u), recordByKey.HeroLevel).ToString();
		this.m_HeroName.text = instance.mStringTable.GetStringByID((uint)recordByKey2.HeroName);
		this.m_Properties.text = instance.mStringTable.GetStringByID((uint)recordByKey2.Summary);
		Vector2 sizeDelta = this.m_Properties.rectTransform.sizeDelta;
		sizeDelta.y = Mathf.Max(66f, this.m_Properties.preferredHeight);
		this.m_Properties.rectTransform.sizeDelta = sizeDelta;
		sizeDelta = this.m_BackRect.sizeDelta;
		sizeDelta.y = Mathf.Max(180f, 117.6f + this.m_Properties.preferredHeight + 14.4f);
		this.m_BackRect.sizeDelta = sizeDelta;
		hint.GetTipPosition(this.m_BackRect, UIButtonHint.ePosition.Original, null);
		float num = -this.m_BackRect.anchoredPosition3D.y + this.m_BackRect.sizeDelta.y;
		if (num > GUIManager.Instance.m_MessageBoxLayer.rect.size.y)
		{
			this.m_Properties.fontSize = 18 - Convert.ToInt32((num - GUIManager.Instance.m_MessageBoxLayer.rect.size.y) * 0.038f);
			sizeDelta = this.m_Properties.rectTransform.sizeDelta;
			sizeDelta.y = Mathf.Max(66f, this.m_Properties.preferredHeight);
			this.m_Properties.rectTransform.sizeDelta = sizeDelta;
			sizeDelta = this.m_BackRect.sizeDelta;
			sizeDelta.y = Mathf.Max(180f, 117.6f + this.m_Properties.preferredHeight + 14.4f);
			this.m_BackRect.sizeDelta = sizeDelta;
		}
		this.m_ButtonHint = hint;
		this.Canvasgroup.alpha = 1f;
	}

	// Token: 0x06001BBD RID: 7101 RVA: 0x003149A8 File Offset: 0x00312BA8
	public void Hide(UIButtonHint hint)
	{
		if (this.m_ButtonHint != hint || this.m_RectTransform == null)
		{
			return;
		}
		this.m_RectTransform.gameObject.SetActive(false);
		GUIManager.Instance.ChangeHeroItemImg(this.m_ItemBtn.transform, eHeroOrItem.Item, 0, 0, 0, 0);
		this.m_ItemBtn.transform.gameObject.SetActive(true);
		UIText name = this.m_Name;
		string empty = string.Empty;
		this.m_Properties.text = empty;
		name.text = empty;
		this.m_ButtonHint = null;
		Vector2 sizeDelta = this.m_Properties.rectTransform.sizeDelta;
		sizeDelta.y = this.OriTextHeight;
		this.m_Properties.rectTransform.sizeDelta = sizeDelta;
		sizeDelta = this.m_BackRect.sizeDelta;
		sizeDelta.y = this.OriHeight;
		this.m_BackRect.sizeDelta = sizeDelta;
		this.m_Properties.fontSize = 18;
		this.m_HeroName.fontSize = 22;
		this.m_HeroName.resizeTextMaxSize = 22;
	}

	// Token: 0x06001BBE RID: 7102 RVA: 0x00314ABC File Offset: 0x00312CBC
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (this.HeroID == 0)
		{
			return;
		}
		if (this.m_ButtonHint != null)
		{
			this.m_ButtonHint.OnCloseHint();
		}
		GUIManager.Instance.OpenPreviewHeroInfo(this.HeroID, true, 60, 8, 5, 63, 0);
		this.HeroID = 0;
	}

	// Token: 0x06001BBF RID: 7103 RVA: 0x00314B10 File Offset: 0x00312D10
	public void TextRefresh()
	{
		if (this.m_RectTransform == null || !this.m_RectTransform.gameObject.activeSelf)
		{
			return;
		}
		this.m_Name.enabled = false;
		this.m_Name.enabled = true;
		this.m_ItemLvText.enabled = false;
		this.m_ItemLvText.enabled = true;
		this.m_ItemKindText.enabled = false;
		this.m_ItemKindText.enabled = true;
		this.m_OwnedText.enabled = false;
		this.m_OwnedText.enabled = true;
		this.m_Properties.enabled = false;
		this.m_Properties.enabled = true;
		this.m_Price.enabled = false;
		this.m_Price.enabled = true;
		this.m_HeroName.enabled = false;
		this.m_HeroName.enabled = true;
		this.m_HeroLV.enabled = false;
		this.m_HeroLV.enabled = true;
	}

	// Token: 0x04005410 RID: 21520
	public RectTransform m_RectTransform;

	// Token: 0x04005411 RID: 21521
	public RectTransform m_BackRect;

	// Token: 0x04005412 RID: 21522
	public RectTransform m_ItemRect;

	// Token: 0x04005413 RID: 21523
	public RectTransform ItemPanel;

	// Token: 0x04005414 RID: 21524
	public RectTransform HeroPanel;

	// Token: 0x04005415 RID: 21525
	public RectTransform rectProperties;

	// Token: 0x04005416 RID: 21526
	public UIHIBtn m_ItemBtn;

	// Token: 0x04005417 RID: 21527
	public UIHIBtn m_HeroBtn;

	// Token: 0x04005418 RID: 21528
	public UIText m_Name;

	// Token: 0x04005419 RID: 21529
	public UIText m_ItemLvText;

	// Token: 0x0400541A RID: 21530
	public UIText m_ItemKindText;

	// Token: 0x0400541B RID: 21531
	public UIText m_OwnedText;

	// Token: 0x0400541C RID: 21532
	public UIText m_Properties;

	// Token: 0x0400541D RID: 21533
	public UIText m_Price;

	// Token: 0x0400541E RID: 21534
	public UIText m_HeroName;

	// Token: 0x0400541F RID: 21535
	public UIText m_HeroLV;

	// Token: 0x04005420 RID: 21536
	public Image m_Coin;

	// Token: 0x04005421 RID: 21537
	public UIButtonHint m_ButtonHint;

	// Token: 0x04005422 RID: 21538
	public CustomImage BossIcon;

	// Token: 0x04005423 RID: 21539
	public CustomImage InfoIcon;

	// Token: 0x04005424 RID: 21540
	public CanvasGroup Canvasgroup;

	// Token: 0x04005425 RID: 21541
	public CanvasGroup ItemBtnRayCast;

	// Token: 0x04005426 RID: 21542
	private float OriHeight;

	// Token: 0x04005427 RID: 21543
	private float OriTextHeight;

	// Token: 0x04005428 RID: 21544
	private CString NameStr;

	// Token: 0x04005429 RID: 21545
	private CString PropertiesStr;

	// Token: 0x0400542A RID: 21546
	private CString HeroNameStr;

	// Token: 0x0400542B RID: 21547
	private CString OwnedStr;

	// Token: 0x0400542C RID: 21548
	private CString PriceStr;

	// Token: 0x0400542D RID: 21549
	private CString AddionalStr;

	// Token: 0x0400542E RID: 21550
	private GameObject CNBossIconObj;

	// Token: 0x0400542F RID: 21551
	private GameObject ItemGo;

	// Token: 0x04005430 RID: 21552
	private Vector2 ItemPosUpset = new Vector2(61f, -59f);

	// Token: 0x04005431 RID: 21553
	private ushort HeroID;

	// Token: 0x02000570 RID: 1392
	private enum IgnoreControl
	{
		// Token: 0x04005433 RID: 21555
		Ignore,
		// Token: 0x04005434 RID: 21556
		ItemBtn
	}

	// Token: 0x02000571 RID: 1393
	private enum UIControl
	{
		// Token: 0x04005436 RID: 21558
		ItemPanel,
		// Token: 0x04005437 RID: 21559
		HeroPanel,
		// Token: 0x04005438 RID: 21560
		Name,
		// Token: 0x04005439 RID: 21561
		Properties
	}

	// Token: 0x02000572 RID: 1394
	private enum ItemControl
	{
		// Token: 0x0400543B RID: 21563
		Own,
		// Token: 0x0400543C RID: 21564
		CoinIcon,
		// Token: 0x0400543D RID: 21565
		Price,
		// Token: 0x0400543E RID: 21566
		ItemLv,
		// Token: 0x0400543F RID: 21567
		ItemKind
	}

	// Token: 0x02000573 RID: 1395
	private enum HeroControl
	{
		// Token: 0x04005441 RID: 21569
		HeroObj,
		// Token: 0x04005442 RID: 21570
		BossIcon,
		// Token: 0x04005443 RID: 21571
		BossIconCN,
		// Token: 0x04005444 RID: 21572
		LV,
		// Token: 0x04005445 RID: 21573
		HeroName
	}
}
