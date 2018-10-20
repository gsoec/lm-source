using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000478 RID: 1144
public class UIPetList : GUIWindow, IBuildingWindowType, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x0600172E RID: 5934 RVA: 0x0027E14C File Offset: 0x0027C34C
	void IUIButtonClickHandler.OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_PetBag, 0, 0, false);
			break;
		}
		case 1:
			GUIManager.Instance.OpenContinuousUI((ushort)sender.m_BtnID2, -1);
			break;
		case 2:
			PetManager.Instance.OpenPetUI(sender.m_BtnID3, (int)((ushort)sender.m_BtnID2));
			break;
		case 3:
		{
			StringTable mStringTable = DataManager.Instance.mStringTable;
			GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(16037u), mStringTable.GetStringByID(16036u), mStringTable.GetStringByID(4507u), this, 22, 0, true, false, true, false, false);
			break;
		}
		}
	}

	// Token: 0x0600172F RID: 5935 RVA: 0x0027E218 File Offset: 0x0027C418
	void IUpDateScrollPanel.UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.PetScrollItem[panelObjectIdx].bInit == 0)
		{
			this.PetScrollItem[panelObjectIdx] = new _PetItem(item.transform, this);
		}
		this.PetScrollItem[panelObjectIdx].SetData(dataIdx, this.ItemStart, this.ItemCount, this.LockCheckState);
	}

	// Token: 0x06001730 RID: 5936 RVA: 0x0027E27C File Offset: 0x0027C47C
	void IUpDateScrollPanel.ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001731 RID: 5937 RVA: 0x0027E280 File Offset: 0x0027C480
	void IBuildingWindowType.OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Upgrade)
		{
			this.ThisTransform.gameObject.SetActive(false);
		}
		else if (buildType == e_BuildType.Normal)
		{
			this.ThisTransform.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001732 RID: 5938 RVA: 0x0027E2C4 File Offset: 0x0027C4C4
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager instance = GUIManager.Instance;
		this.ThisTransform = base.transform.GetChild(0);
		Font ttffont = instance.GetTTFFont();
		for (int i = 0; i < 4; i++)
		{
			this.ThisTransform.GetChild(1).GetChild(i).GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>().font = ttffont;
			this.ThisTransform.GetChild(1).GetChild(i).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>().font = ttffont;
			this.ThisTransform.GetChild(1).GetChild(i).GetChild(1).GetChild(2).GetComponent<UIText>().font = ttffont;
			instance.InitianHeroItemImg(this.ThisTransform.GetChild(1).GetChild(i).GetChild(0).GetChild(0), eHeroOrItem.Pet, 0, 0, 0, 0, true, false, true, false);
			instance.InitianHeroItemImg(this.ThisTransform.GetChild(1).GetChild(i).GetChild(1).GetChild(1), eHeroOrItem.Item, 0, 0, 0, 0, false, false, true, false);
			this.ThisTransform.GetChild(1).GetChild(i).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>().font = ttffont;
			this.ThisTransform.GetChild(1).GetChild(i).GetChild(0).GetChild(0).GetComponent<UIHIBtn>().enabled = false;
			this.ThisTransform.GetChild(1).GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>().enabled = false;
			this.ThisTransform.GetChild(1).GetChild(i).GetChild(1).GetChild(1).GetComponent<UIHIBtn>().enabled = false;
			this.ThisTransform.GetChild(1).GetChild(i).GetChild(1).GetChild(1).GetComponent<Image>().enabled = false;
		}
		UIButton component = this.ThisTransform.GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 0;
		this.MsgObj = this.ThisTransform.GetChild(3).gameObject;
		this.MsgText = this.ThisTransform.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.MsgText.font = ttffont;
		this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(16093u);
		instance.UpdateUI(EGUIWindow.Door, 1, 4);
		this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		this.baseBuild.InitBuildingWindow(20, (ushort)arg1, 2, GUIManager.Instance.BuildingData.AllBuildsData[arg1].Level);
		this.baseBuild.baseTransform.SetAsFirstSibling();
	}

	// Token: 0x06001733 RID: 5939 RVA: 0x0027E5A4 File Offset: 0x0027C7A4
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.bInit > 0)
		{
			this.bInit -= 1;
			if (this.bInit == 0)
			{
				this.Scroll = this.ThisTransform.GetChild(0).GetComponent<ScrollPanel>();
				this.PetScrollItem = new _PetItem[4];
				this.Scroll.IntiScrollPanel(354f, 0f, 0f, this.Height, 4, this);
				this.PetScrollRect = this.Scroll.transform.GetChild(0).GetComponent<RectTransform>();
				this.Scroll.gameObject.SetActive(true);
				this.UpdatePetList();
				NewbieManager.CheckSpawnPetFromUI();
				if (NewbieManager.IsTeachWorking(ETeachKind.SPAWN_PET))
				{
					this.Scroll.GoTo(0, 0f);
				}
				else
				{
					this.Scroll.GoTo((int)PetManager.Instance.UISave[6], GameConstants.ConvertBytesToFloat(PetManager.Instance.UISave, 7));
				}
				this.baseBuild.MyUpdate(0, false);
				this.MsgText.enabled = false;
				this.MsgText.enabled = true;
			}
		}
	}

	// Token: 0x06001734 RID: 5940 RVA: 0x0027E6C4 File Offset: 0x0027C8C4
	public override void UpdateNetwork(byte[] meg)
	{
		if (this.bInit > 0)
		{
			return;
		}
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_Resource)
		{
			return;
		}
		if (networkNews == NetworkNews.Login || networkNews == NetworkNews.Refresh_AttribEffectVal)
		{
			if (networkNews == NetworkNews.Login)
			{
				this.SkipUpdate = 0;
				this.UpdatePetList();
			}
			this.baseBuild.MyUpdate(0, false);
		}
		else if (networkNews == NetworkNews.Refresh_BuildBase)
		{
			if (meg[1] == 1)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.CloseMenu(true);
			}
			else
			{
				this.baseBuild.MyUpdate(meg[1], false);
			}
		}
		else if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.MsgText.enabled = false;
			this.MsgText.enabled = true;
			for (int i = 0; i < this.PetScrollItem.Length; i++)
			{
				this.PetScrollItem[i].TextRefresh();
			}
			this.baseBuild.Refresh_FontTexture();
		}
		else if (networkNews == NetworkNews.Refresh_Pet || networkNews == NetworkNews.Refresh_Item)
		{
			this.UpdatePetList();
		}
	}

	// Token: 0x06001735 RID: 5941 RVA: 0x0027E7D0 File Offset: 0x0027C9D0
	public override void UpdateUI(int arg1, int arg2)
	{
		if (this.bInit > 0)
		{
			return;
		}
		for (int i = 0; i < 32; i++)
		{
			int num = arg1 >> i;
			if (num == 0)
			{
				break;
			}
			num &= 1;
			if (num != 0)
			{
				num <<= i;
				UIPetList.eUpdateUI eUpdateUI = (UIPetList.eUpdateUI)num;
				switch (eUpdateUI)
				{
				case UIPetList.eUpdateUI.updateList:
					this.UpdatePetList();
					break;
				case UIPetList.eUpdateUI.updateState:
				case UIPetList.eUpdateUI.updateStone:
					if (num == 4)
					{
						this.LockCheckState = 0;
					}
					for (int j = 0; j < this.PetScrollItem.Length; j++)
					{
						this.PetScrollItem[j].UpdatePetState(this.LockCheckState);
					}
					break;
				default:
					if (eUpdateUI != UIPetList.eUpdateUI.updateSkipUpdate)
					{
						if (eUpdateUI == UIPetList.eUpdateUI.Max)
						{
							return;
						}
					}
					else
					{
						this.SkipUpdate = 1;
					}
					break;
				case UIPetList.eUpdateUI.updateNewBook:
					if ((arg1 & 1) == 0)
					{
						this.UpdatePetList();
					}
					this.Scroll.GoTo(0, 0f);
					break;
				}
			}
		}
	}

	// Token: 0x06001736 RID: 5942 RVA: 0x0027E8E8 File Offset: 0x0027CAE8
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		if (this.PetScrollItem != null)
		{
			for (int i = 0; i < this.PetScrollItem.Length; i++)
			{
				this.PetScrollItem[i].OnDestroy();
			}
			PetManager instance = PetManager.Instance;
			instance.UISave[6] = (byte)this.Scroll.GetBeginIdx();
			GameConstants.GetBytes(this.PetScrollRect.anchoredPosition.y, instance.UISave, 7);
		}
	}

	// Token: 0x06001737 RID: 5943 RVA: 0x0027E980 File Offset: 0x0027CB80
	private void UpdatePetList()
	{
		if (this.SkipUpdate == 1)
		{
			return;
		}
		PetManager.Instance.SortPetItemData();
		PetManager.Instance.SortPetData();
		this.ItemStart = (int)DataManager.Instance.sortItemDataStart[17];
		int num = (int)DataManager.Instance.sortItemDataCount[17];
		this.ItemCount = num;
		if (this.ItemCount == 0)
		{
			this.ItemStart = 0;
			num = 1;
		}
		num += (int)PetManager.Instance.PetDataCount;
		num = (num >> 2) + Mathf.Clamp(num & 3, 0, 1);
		if (this.ItemCount == 0 && PetManager.Instance.PetDataCount == 0)
		{
			this.MsgObj.SetActive(true);
		}
		else
		{
			this.MsgObj.SetActive(false);
		}
		if (num > this.Height.Count)
		{
			num -= this.Height.Count;
			for (int i = 0; i < num; i++)
			{
				this.Height.Add(194f);
			}
		}
		else if (num < this.Height.Count)
		{
			num = this.Height.Count - num;
			this.Height.RemoveRange(this.Height.Count - num, num);
		}
		int beginIdx = this.Scroll.GetBeginIdx();
		Vector2 anchoredPosition = this.PetScrollRect.anchoredPosition;
		this.Scroll.AddNewDataHeight(this.Height, true, true);
		this.Scroll.GoTo(beginIdx, anchoredPosition.y);
	}

	// Token: 0x06001738 RID: 5944 RVA: 0x0027EAFC File Offset: 0x0027CCFC
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			GUIManager.Instance.BuildingData.ManorGuild((ushort)arg1, false);
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu(false);
		}
	}

	// Token: 0x0400456C RID: 17772
	private BuildingWindow baseBuild;

	// Token: 0x0400456D RID: 17773
	private GameObject MsgObj;

	// Token: 0x0400456E RID: 17774
	private UIText MsgText;

	// Token: 0x0400456F RID: 17775
	public Transform ThisTransform;

	// Token: 0x04004570 RID: 17776
	private RectTransform PetScrollRect;

	// Token: 0x04004571 RID: 17777
	private ScrollPanel Scroll;

	// Token: 0x04004572 RID: 17778
	private List<float> Height = new List<float>();

	// Token: 0x04004573 RID: 17779
	private int ItemCount;

	// Token: 0x04004574 RID: 17780
	private int ItemStart;

	// Token: 0x04004575 RID: 17781
	private byte LockCheckState;

	// Token: 0x04004576 RID: 17782
	private byte SkipUpdate;

	// Token: 0x04004577 RID: 17783
	private byte bInit = 2;

	// Token: 0x04004578 RID: 17784
	private _PetItem[] PetScrollItem;

	// Token: 0x02000479 RID: 1145
	private enum UIControl
	{
		// Token: 0x0400457A RID: 17786
		Scroll,
		// Token: 0x0400457B RID: 17787
		Item,
		// Token: 0x0400457C RID: 17788
		BageBtn,
		// Token: 0x0400457D RID: 17789
		Messsage
	}

	// Token: 0x0200047A RID: 1146
	public enum ClickType
	{
		// Token: 0x0400457F RID: 17791
		Bage,
		// Token: 0x04004580 RID: 17792
		CellItem,
		// Token: 0x04004581 RID: 17793
		CellPet,
		// Token: 0x04004582 RID: 17794
		CellDef
	}

	// Token: 0x0200047B RID: 1147
	public enum eUpdateUI
	{
		// Token: 0x04004584 RID: 17796
		updateList = 1,
		// Token: 0x04004585 RID: 17797
		updateState,
		// Token: 0x04004586 RID: 17798
		updateStone = 4,
		// Token: 0x04004587 RID: 17799
		updateNewBook = 8,
		// Token: 0x04004588 RID: 17800
		updateSkipUpdate = 16,
		// Token: 0x04004589 RID: 17801
		Max = 32
	}
}
