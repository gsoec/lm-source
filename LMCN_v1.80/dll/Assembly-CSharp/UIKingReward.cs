using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000855 RID: 2133
public class UIKingReward : UIFilterBase
{
	// Token: 0x06002C16 RID: 11286 RVA: 0x0048600C File Offset: 0x0048420C
	public override void OnOpen(int arg1, int arg2)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		base.OnOpen(arg1, arg2);
		if (arg1 > 0)
		{
			this.Who = new Nobility();
			if (arg2 == 1)
			{
				this.Who.IsKing = true;
			}
		}
		else if (DataManager.MapDataController.IsFocusWorldWar())
		{
			this.Who = new WorldKing();
		}
		else
		{
			this.Who = new King();
		}
		DataManager.Instance.KingGift.sendKingGiftInfo((byte)arg1);
		this.ThisTransform = base.SetFunc(this.transform.GetChild(4));
		this.ThisTransform.gameObject.SetActive(true);
		this.TitleText = this.ThisTransform.GetComponent<UIText>();
		this.TitleText.font = GUIManager.Instance.GetTTFFont();
		base.AddRefreshText(this.TitleText);
		this.TitleText.text = this.Who.TitleStr;
		this.MainText.text = this.Who.MainStr;
		this.OwnerStr = mStringTable.GetStringByID(5332u);
		this.ItemBtnString[0] = mStringTable.GetStringByID(9716u);
		this.ItemBtnString[1] = mStringTable.GetStringByID(9717u);
		this.SendName = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x06002C17 RID: 11287 RVA: 0x00486164 File Offset: 0x00484364
	public override void Init()
	{
		base.Init();
		this.ListBtn = new UIButton[this.FilterItem.Length];
		for (int i = 0; i < this.FilterItem.Length; i++)
		{
			this.FilterItem[i].ItemBtn.m_Handler = this;
			this.FilterItem[i].AutouseBtnTrans.GetChild(0).GetComponent<UIText>().text = this.ItemBtnString[1];
			this.ListBtn[i] = this.FilterItem[i].AutouseBtnTrans.GetComponent<UIButton>();
			this.ListBtn[i].m_BtnID1 = 1;
			base.SetItemType(i, UIFilterBase.eItemType.Use);
			this.FilterItem[i].BuyCaption.text = this.ItemBtnString[0];
			this.FilterItem[i].BuyBtn.m_BtnID1 = 0;
			this.FilterItem[i].BuyBtn.gameObject.SetActive(this.Who.IsKing);
			if (!this.Who.IsKing)
			{
				this.FilterItem[i].AutouseBtnTrans.anchoredPosition = new Vector2(669f, -59f);
			}
		}
		if (DataManager.Instance.KingGift.GetGiftList().Count == 0)
		{
			this.FilterScrollView.gameObject.SetActive(false);
		}
		else
		{
			this.UpdateRewardItem();
		}
	}

	// Token: 0x06002C18 RID: 11288 RVA: 0x004862DC File Offset: 0x004844DC
	private void UpdateRewardItem()
	{
		List<KingGiftInfo> giftList = DataManager.Instance.KingGift.GetGiftList();
		this.ItemsData.Clear();
		this.ItemsHeight.Clear();
		for (int i = 0; i < giftList.Count; i++)
		{
			this.ItemsData.Add(giftList[i].ItemID);
			this.ItemsHeight.Add(121f);
		}
		base.UpdateScrollItemsCount();
	}

	// Token: 0x06002C19 RID: 11289 RVA: 0x00486354 File Offset: 0x00484554
	public override void OnHIButtonClick(UIHIBtn sender)
	{
		if (sender.m_BtnID2 == 0)
		{
			return;
		}
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		door.OpenMenu(EGUIWindow.UI_OpenBox, 1, sender.m_BtnID2, false);
	}

	// Token: 0x06002C1A RID: 11290 RVA: 0x00486390 File Offset: 0x00484590
	public override void OnButtonClick(UIButton sender)
	{
		UIKingReward.ClickType btnID = (UIKingReward.ClickType)sender.m_BtnID1;
		if (btnID != UIKingReward.ClickType.Reward)
		{
			if (btnID != UIKingReward.ClickType.List)
			{
				base.OnButtonClick(sender);
			}
			else
			{
				this.Who.CheckAndOpenList(sender.m_BtnID2);
			}
		}
		else if (this.Who.CheckReward())
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_Alliance_List, 6, sender.m_BtnID2, false);
		}
	}

	// Token: 0x06002C1B RID: 11291 RVA: 0x00486410 File Offset: 0x00484610
	public override void OnClose()
	{
		base.OnClose();
		StringManager.Instance.DeSpawnString(this.SendName);
	}

	// Token: 0x06002C1C RID: 11292 RVA: 0x0048642C File Offset: 0x0048462C
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
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

	// Token: 0x06002C1D RID: 11293 RVA: 0x00486494 File Offset: 0x00484694
	public override void UpdateUI(int arge1, int arge2)
	{
		if (arge2 == 1)
		{
			if (this.FilterScrollView != null)
			{
				Vector2 vector = Vector2.zero;
				vector = this.ScrollContent.anchoredPosition;
				int beginIdx = this.FilterScrollView.GetBeginIdx();
				this.FilterScrollView.gameObject.SetActive(true);
				this.UpdateRewardItem();
				this.FilterScrollView.GoTo(beginIdx, vector.y);
			}
		}
		else if (arge2 == 2)
		{
			if (DataManager.MapDataController.IsPeaceState(false, DataManager.Instance.KingGift.WonderID))
			{
				DataManager.Instance.KingGift.sendKingGiftInfo(DataManager.Instance.KingGift.WonderID);
			}
			else
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door != null)
				{
					door.CloseMenu_Alliance(EGUIWindow.UI_BagFilter);
				}
			}
		}
	}

	// Token: 0x06002C1E RID: 11294 RVA: 0x00486578 File Offset: 0x00484778
	public override void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		base.UpDateRowItem(item, dataIdx, panelObjectIdx, panelId);
		if (this.ItemsData.Count <= dataIdx)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		this.FilterItem[panelObjectIdx].KeyID = this.ItemsData[dataIdx];
		ushort keyID = this.FilterItem[panelObjectIdx].KeyID;
		this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = (int)keyID;
		Equip recordByKey = instance.EquipTable.GetRecordByKey(keyID);
		ushort remainCount = (ushort)instance.KingGift.GetGiftList()[dataIdx].GetRemainCount();
		GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[panelObjectIdx].ItemTrans, eHeroOrItem.Item, recordByKey.EquipKey, 0, 0, 0);
		this.FilterItem[panelObjectIdx].Name.text = instance.mStringTable.GetStringByID((uint)recordByKey.EquipName);
		if (recordByKey.EquipKind == 19)
		{
			this.FilterItem[panelObjectIdx].InfoTrans.gameObject.SetActive(true);
			this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = (int)recordByKey.EquipKey;
			GUIManager.Instance.SetItemScaleClickSound(this.FilterItem[panelObjectIdx].ItemBtn, true, true);
		}
		else if (recordByKey.EquipKind == 18 && (recordByKey.PropertiesInfo[2].Propertieskey < 1 || recordByKey.PropertiesInfo[2].Propertieskey > 3))
		{
			this.FilterItem[panelObjectIdx].NameStr.ClearString();
			this.FilterItem[panelObjectIdx].NameStr.StringToFormat(instance.mStringTable.GetStringByID(7732u + (uint)recordByKey.Color));
			this.FilterItem[panelObjectIdx].NameStr.AppendFormat(instance.mStringTable.GetStringByID(7739u));
			this.FilterItem[panelObjectIdx].NameStr.Append(instance.mStringTable.GetStringByID((uint)recordByKey.EquipName));
			this.FilterItem[panelObjectIdx].Name.text = this.FilterItem[panelObjectIdx].NameStr.ToString();
			this.FilterItem[panelObjectIdx].Name.SetAllDirty();
			this.FilterItem[panelObjectIdx].Name.cachedTextGenerator.Invalidate();
			this.FilterItem[panelObjectIdx].InfoTrans.gameObject.SetActive(true);
			this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = (int)recordByKey.EquipKey;
			GUIManager.Instance.SetItemScaleClickSound(this.FilterItem[panelObjectIdx].ItemBtn, true, true);
		}
		else
		{
			this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = 0;
			this.FilterItem[panelObjectIdx].InfoTrans.gameObject.SetActive(false);
		}
		this.FilterItem[panelObjectIdx].Content.text = instance.mStringTable.GetStringByID((uint)recordByKey.EquipInfo);
		this.FilterItem[panelObjectIdx].OwnerStr.ClearString();
		this.FilterItem[panelObjectIdx].OwnerStr.StringToFormat(this.OwnerStr);
		this.FilterItem[panelObjectIdx].OwnerStr.IntToFormat((long)remainCount, 1, true);
		this.FilterItem[panelObjectIdx].OwnerStr.AppendFormat("{0}{1}");
		this.FilterItem[panelObjectIdx].Owner.text = this.FilterItem[panelObjectIdx].OwnerStr.ToString();
		this.FilterItem[panelObjectIdx].Owner.SetAllDirty();
		this.FilterItem[panelObjectIdx].Owner.cachedTextGenerator.Invalidate();
		this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = (int)keyID;
		this.ListBtn[panelObjectIdx].m_BtnID2 = dataIdx;
	}

	// Token: 0x0400788D RID: 30861
	private UIText TitleText;

	// Token: 0x0400788E RID: 30862
	private string[] ItemBtnString = new string[2];

	// Token: 0x0400788F RID: 30863
	private UIButton[] ListBtn;

	// Token: 0x04007890 RID: 30864
	private CString SendName;

	// Token: 0x04007891 RID: 30865
	private _WhoReward Who;

	// Token: 0x02000856 RID: 2134
	private enum ClickType
	{
		// Token: 0x04007893 RID: 30867
		Reward,
		// Token: 0x04007894 RID: 30868
		List
	}
}
