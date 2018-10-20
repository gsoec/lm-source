using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000638 RID: 1592
public class UIMonsterCrypt : GUIWindow, IUIButtonClickHandler, IUIHIBtnClickHandler
{
	// Token: 0x06001EC2 RID: 7874 RVA: 0x003AD214 File Offset: 0x003AB414
	void IUIHIBtnClickHandler.OnHIButtonClick(UIHIBtn sender)
	{
		if (sender.m_BtnID2 == 0)
		{
			return;
		}
		GamblingManager.Instance.OpenMenu(EGUIWindow.UI_OpenBox, 1, sender.m_BtnID2, false);
	}

	// Token: 0x06001EC3 RID: 7875 RVA: 0x003AD238 File Offset: 0x003AB438
	public override void OnOpen(int arg1, int arg2)
	{
		RewardManager.getInstance.rootLayer.gameObject.SetActive(false);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MonsterLayerObj = base.transform.GetChild(0).gameObject;
		this.MonsterTrans = base.transform.GetChild(0).GetChild(0);
		this.Title = base.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.Title.font = ttffont;
		if (BattleController.GambleMode == EGambleMode.Normal)
		{
			this.Title.text = mStringTable.GetStringByID(9175u);
		}
		else
		{
			this.Title.text = mStringTable.GetStringByID(9176u);
		}
		this.AddRefreshText(this.Title);
		this.CryptText = base.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<UIText>();
		this.CryptText.font = ttffont;
		this.AddRefreshText(this.CryptText);
		this.CryptRect = base.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<RectTransform>();
		this.MessageText = base.transform.GetChild(2).GetComponent<UIText>();
		this.MessageText.font = ttffont;
		this.AddRefreshText(this.MessageText);
		this.MessageText.text = mStringTable.GetStringByID(9177u);
		this.PriceTitle = base.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.PriceTitle.font = ttffont;
		this.AddRefreshText(this.PriceTitle);
		this.PriceTitle.text = mStringTable.GetStringByID(1590u);
		this.PriceCont = base.transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<RectTransform>();
		this.PriceScroll = this.PriceCont.parent.GetComponent<CScrollRect>();
		UIButton component = base.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			base.transform.GetChild(4).GetComponent<Image>().enabled = false;
		}
		this.PriceStr = StringManager.Instance.SpawnString(30);
		this.UpdateCrypt();
		this.CheckInit();
		this.InitPrice();
		UIHintMask.bPassThrough = true;
	}

	// Token: 0x06001EC4 RID: 7876 RVA: 0x003AD4B4 File Offset: 0x003AB6B4
	public override void OnClose()
	{
		if (this.AssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey, true);
		}
		StringManager.Instance.DeSpawnString(this.PriceStr);
		UnityEngine.Object.Destroy(this.MonsterLayerObj);
		RewardManager.getInstance.rootLayer.gameObject.SetActive(true);
		UIHintMask.bPassThrough = false;
	}

	// Token: 0x06001EC5 RID: 7877 RVA: 0x003AD510 File Offset: 0x003AB710
	private void OnEnable()
	{
		if (this.MonsterLayerObj != null)
		{
			this.MonsterLayerObj.SetActive(true);
		}
	}

	// Token: 0x06001EC6 RID: 7878 RVA: 0x003AD530 File Offset: 0x003AB730
	private void OnDisable()
	{
		if (this.MonsterLayerObj != null)
		{
			this.MonsterLayerObj.SetActive(false);
		}
	}

	// Token: 0x06001EC7 RID: 7879 RVA: 0x003AD550 File Offset: 0x003AB750
	public override void UpdateTime(bool bOnSecond)
	{
		if (!this.bABInitial && this.AR != null && this.AR.isDone)
		{
			this.MonsterGo = (GameObject)UnityEngine.Object.Instantiate(this.AR.asset);
			this.MonsterGo.transform.SetParent(this.MonsterTrans, false);
			Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
			localRotation.eulerAngles = new Vector3(26f, 180f, -4.7101f);
			this.MonsterGo.transform.localRotation = localRotation;
			this.MonsterGo.transform.localScale = new Vector3(450f, 450f, 450f);
			this.MonsterGo.transform.localPosition = new Vector3(0f, 0f, 0f);
			GUIManager.Instance.SetLayer(this.MonsterGo, 5);
			if (this.MonsterGo != null && this.MonsterGo.gameObject.activeSelf)
			{
				SkinnedMeshRenderer componentInChildren = this.MonsterGo.GetComponentInChildren<SkinnedMeshRenderer>();
				componentInChildren.useLightProbes = false;
				componentInChildren.updateWhenOffscreen = true;
			}
			this.bABInitial = true;
			this.PlayGambleBoxAnim();
		}
	}

	// Token: 0x06001EC8 RID: 7880 RVA: 0x003AD6A4 File Offset: 0x003AB8A4
	private void PlayGambleBoxAnim()
	{
		this.MonsterAN = this.MonsterGo.GetComponent<Animation>();
		int num;
		switch (GamblingManager.Instance.m_GambleBoxAnim)
		{
		case GambleBoxAnim.status_1:
			num = 1;
			break;
		case GambleBoxAnim.status_2:
			num = 2;
			break;
		case GambleBoxAnim.status_3:
			num = 3;
			break;
		default:
			num = 0;
			break;
		}
		if (this.MonsterAN != null)
		{
			this.MonsterAN.wrapMode = WrapMode.Loop;
			this.MonsterAN[this.anim[num]].layer = 1;
			this.MonsterAN[this.anim[num]].wrapMode = WrapMode.Loop;
			this.MonsterAN.Play(this.anim[num]);
			this.MonsterAN.clip = this.MonsterAN.GetClip(this.anim[num]);
			if (GUIManager.Instance.m_OtherCanvasTransform != null)
			{
				this.MonsterLayerObj.transform.SetParent(GUIManager.Instance.m_OtherCanvasTransform);
				RectTransform rectTransform = this.MonsterLayerObj.transform as RectTransform;
				rectTransform.anchorMin = Vector2.zero;
				rectTransform.anchorMax = Vector2.one;
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				rectTransform.anchoredPosition3D = Vector3.zero;
				rectTransform.localScale = Vector3.one;
				rectTransform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			}
		}
	}

	// Token: 0x06001EC9 RID: 7881 RVA: 0x003AD828 File Offset: 0x003ABA28
	private void Set3Denvironment()
	{
		DataManager.msgBuffer[0] = 84;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		GUIManager.Instance.m_UICanvas.renderMode = RenderMode.ScreenSpaceCamera;
		GUIManager.Instance.SetCanvasChanged();
	}

	// Token: 0x06001ECA RID: 7882 RVA: 0x003AD85C File Offset: 0x003ABA5C
	public override void UpdateNetwork(byte[] meg)
	{
		if (meg[0] == 35)
		{
			for (int i = 0; i < this.RefreshTextArray.Count; i++)
			{
				this.RefreshTextArray[i].enabled = false;
				this.RefreshTextArray[i].enabled = true;
			}
		}
	}

	// Token: 0x06001ECB RID: 7883 RVA: 0x003AD8B4 File Offset: 0x003ABAB4
	public override void UpdateUI(int arg1, int arg2)
	{
		this.UpdateCrypt();
	}

	// Token: 0x06001ECC RID: 7884 RVA: 0x003AD8BC File Offset: 0x003ABABC
	private void UpdateCrypt()
	{
		this.PriceStr.ClearString();
		if (BattleController.GambleMode == EGambleMode.Turbo)
		{
			this.PriceStr.IntToFormat((long)((ulong)GamblingManager.Instance.m_GambleGameInfo.Prize), 1, true);
		}
		else
		{
			float num = GamblingManager.Instance.m_GambleGameInfo.SmallCost / GamblingManager.Instance.m_GambleGameInfo.BigCost;
			this.PriceStr.IntToFormat((long)(GamblingManager.Instance.m_GambleGameInfo.Prize * num), 1, true);
		}
		this.PriceStr.AppendFormat("{0}");
		this.CryptText.text = this.PriceStr.ToString();
		this.CryptText.SetAllDirty();
		this.CryptText.cachedTextGenerator.Invalidate();
		this.CryptText.cachedTextGeneratorForLayout.Invalidate();
		float x = this.CryptText.preferredWidth * -0.5f - 24.5f;
		this.CryptRect.anchoredPosition = new Vector2(x, this.CryptRect.anchoredPosition.y);
	}

	// Token: 0x06001ECD RID: 7885 RVA: 0x003AD9D8 File Offset: 0x003ABBD8
	private void InitPrice()
	{
		DataManager instance = DataManager.Instance;
		byte b = 0;
		DataIndexTbl dataIndexTbl = default(DataIndexTbl);
		int gambleMode = (int)BattleController.GambleMode;
		CExternalTableWithWordKey<MonsterPriceTbl>[] gambleMonsterPriceTable = DataManager.Instance.GambleMonsterPriceTable;
		if (!GamblingManager.Instance.GetMonsterPriceGroupIndex(GamblingManager.Instance.m_GambleEventSave.GroupID, ref dataIndexTbl) || gambleMode >= gambleMonsterPriceTable.Length)
		{
			return;
		}
		for (int i = 0; i < (int)dataIndexTbl.Num; i++)
		{
			MonsterPriceTbl recordByIndex = gambleMonsterPriceTable[gambleMode].GetRecordByIndex((int)(dataIndexTbl.BeginIdx - 1) + i);
			Equip recordByKey = instance.EquipTable.GetRecordByKey(recordByIndex.Item);
			if (!GUIManager.Instance.IsLeadItem(recordByKey.EquipKind))
			{
				UIHIBtn component;
				if ((int)b < this.PriceCont.GetChild(0).GetChild(0).childCount)
				{
					GUIManager.Instance.ChangeHeroItemImg(this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b), eHeroOrItem.Item, recordByKey.EquipKey, 0, 0, 0);
					this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b).gameObject.SetActive(true);
					component = this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b).GetComponent<UIHIBtn>();
				}
				else
				{
					RectTransform rectTransform = UnityEngine.Object.Instantiate(this.PriceCont.GetChild(0).GetChild(0).GetChild(0)) as RectTransform;
					rectTransform.SetParent(this.PriceCont.GetChild(0).GetChild(0));
					rectTransform.anchoredPosition3D = new Vector3(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y, 0f);
					Quaternion localRotation = rectTransform.localRotation;
					localRotation.eulerAngles = Vector3.zero;
					rectTransform.localRotation = localRotation;
					rectTransform.localScale = Vector3.one;
					rectTransform.anchoredPosition = new Vector2((float)(36 + 74 * i), -37f);
					rectTransform.gameObject.SetActive(true);
					GUIManager.Instance.ChangeHeroItemImg(rectTransform, eHeroOrItem.Item, recordByKey.EquipKey, 0, 0, 0);
					this.AddRefreshText(rectTransform.GetChild(4).GetComponent<UIText>());
					component = rectTransform.GetComponent<UIHIBtn>();
					component.GetComponent<UIButtonHint>().enabled = true;
					GUIManager.Instance.SetItemScaleClickSound(component, false, true);
				}
				EItemType eitemType = (EItemType)(recordByKey.EquipKind - 1);
				if (eitemType == EItemType.EIT_ComboTreasureBox || (eitemType == EItemType.EIT_MaterialTreasureBox && recordByKey.PropertiesInfo[0].Propertieskey == 4) || (eitemType == EItemType.EIT_MaterialTreasureBox && (recordByKey.PropertiesInfo[2].Propertieskey < 1 || recordByKey.PropertiesInfo[2].Propertieskey > 3)))
				{
					component.m_BtnID2 = (int)recordByKey.EquipKey;
					component.m_Handler = this;
					component.GetComponent<UIButtonHint>().enabled = false;
					EventPatchery component2 = component.gameObject.GetComponent<EventPatchery>();
					if (component2 == null)
					{
						component.gameObject.AddComponent<EventPatchery>().SetEvnetObj(this.PriceScroll);
					}
					else
					{
						component2.SetEvnetObj(this.PriceScroll);
					}
					GUIManager.Instance.SetItemScaleClickSound(component, true, true);
				}
			}
			else if ((int)b < this.PriceCont.GetChild(0).GetChild(1).childCount)
			{
				GUIManager.Instance.ChangeLordEquipImg(this.PriceCont.GetChild(0).GetChild(1).GetChild((int)b), recordByKey.EquipKey, recordByIndex.Rank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				this.PriceCont.GetChild(0).GetChild(1).GetChild((int)b).gameObject.SetActive(true);
			}
			else
			{
				RectTransform rectTransform = UnityEngine.Object.Instantiate(this.PriceCont.GetChild(0).GetChild(1).GetChild(0)) as RectTransform;
				rectTransform.SetParent(this.PriceCont.GetChild(0).GetChild(1));
				rectTransform.anchoredPosition3D = new Vector3(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y, 0f);
				Quaternion localRotation2 = rectTransform.localRotation;
				localRotation2.eulerAngles = Vector3.zero;
				rectTransform.localRotation = localRotation2;
				rectTransform.localScale = Vector3.one;
				rectTransform.anchoredPosition = new Vector2((float)(36 + 74 * i), -37f);
				rectTransform.gameObject.SetActive(true);
				GUIManager.Instance.ChangeLordEquipImg(rectTransform, recordByKey.EquipKey, recordByIndex.Rank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
			}
			b += 1;
		}
		float num = 4f + 74f * (float)b;
		if (this.PriceCont.sizeDelta.x < num)
		{
			Vector2 sizeDelta = this.PriceCont.sizeDelta;
			sizeDelta.x = num + 4f;
			this.PriceCont.sizeDelta = sizeDelta;
		}
		else
		{
			this.PriceScroll.enabled = false;
		}
	}

	// Token: 0x06001ECE RID: 7886 RVA: 0x003ADED0 File Offset: 0x003AC0D0
	private void CheckInit()
	{
		GUIManager instance = GUIManager.Instance;
		UIButtonHint.scrollRect = this.PriceScroll;
		for (byte b = 0; b < 8; b += 1)
		{
			instance.InitianHeroItemImg(this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b), eHeroOrItem.Item, 0, 0, 0, 0, true, true, true, false);
			this.AddRefreshText(this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b).GetChild(4).GetComponent<UIText>());
		}
		for (byte b2 = 0; b2 < 8; b2 += 1)
		{
			instance.InitLordEquipImg(this.PriceCont.GetChild(0).GetChild(1).GetChild((int)b2), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
			this.PriceCont.GetChild(0).GetChild(1).GetChild((int)b2).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
		}
		this.AB = AssetManager.GetAssetBundle("Role/gamblebox", out this.AssetKey, false);
		if (this.AB != null)
		{
			this.AR = this.AB.LoadAsync("m", typeof(GameObject));
		}
	}

	// Token: 0x06001ECF RID: 7887 RVA: 0x003AE000 File Offset: 0x003AC200
	public void AddRefreshText(UIText text)
	{
		this.RefreshTextArray.Add(text);
	}

	// Token: 0x06001ED0 RID: 7888 RVA: 0x003AE010 File Offset: 0x003AC210
	public void OnButtonClick(UIButton sender)
	{
		GamblingManager.Instance.CloseMenu(false);
	}

	// Token: 0x04006167 RID: 24935
	private GameObject MonsterLayerObj;

	// Token: 0x04006168 RID: 24936
	private UIText Title;

	// Token: 0x04006169 RID: 24937
	private UIText CryptText;

	// Token: 0x0400616A RID: 24938
	private UIText MessageText;

	// Token: 0x0400616B RID: 24939
	private UIText PriceTitle;

	// Token: 0x0400616C RID: 24940
	private CString PriceStr;

	// Token: 0x0400616D RID: 24941
	private Transform MonsterTrans;

	// Token: 0x0400616E RID: 24942
	private RectTransform CryptRect;

	// Token: 0x0400616F RID: 24943
	private RectTransform PriceCont;

	// Token: 0x04006170 RID: 24944
	private CScrollRect PriceScroll;

	// Token: 0x04006171 RID: 24945
	private List<UIText> RefreshTextArray = new List<UIText>();

	// Token: 0x04006172 RID: 24946
	private AssetBundle AB;

	// Token: 0x04006173 RID: 24947
	private AssetBundleRequest AR;

	// Token: 0x04006174 RID: 24948
	private int AssetKey;

	// Token: 0x04006175 RID: 24949
	private bool bABInitial;

	// Token: 0x04006176 RID: 24950
	private GameObject MonsterGo;

	// Token: 0x04006177 RID: 24951
	private Animation MonsterAN;

	// Token: 0x04006178 RID: 24952
	private string[] anim = new string[]
	{
		"idle",
		"status_1",
		"status_2",
		"status_3"
	};

	// Token: 0x02000639 RID: 1593
	private enum UIControl
	{
		// Token: 0x0400617A RID: 24954
		MonsterCrpt,
		// Token: 0x0400617B RID: 24955
		Info,
		// Token: 0x0400617C RID: 24956
		DownMessage,
		// Token: 0x0400617D RID: 24957
		Price,
		// Token: 0x0400617E RID: 24958
		Close
	}

	// Token: 0x0200063A RID: 1594
	private enum EInfo
	{
		// Token: 0x04006180 RID: 24960
		Background,
		// Token: 0x04006181 RID: 24961
		Title,
		// Token: 0x04006182 RID: 24962
		Reward
	}
}
