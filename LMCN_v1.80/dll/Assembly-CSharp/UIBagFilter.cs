using System;

// Token: 0x02000814 RID: 2068
public class UIBagFilter : GUIWindow
{
	// Token: 0x06002B0C RID: 11020 RVA: 0x00470BFC File Offset: 0x0046EDFC
	public override void OnOpen(int arg1, int arg2)
	{
		int arg3 = arg1 >> 16;
		arg1 &= 65535;
		this.Type = arg1;
		switch (this.Type)
		{
		case 0:
			this.UIWindow[0] = new UIBag();
			this.UIWindow[0].transform = base.transform;
			this.UIWindow[0].OnOpen(arg3, arg2);
			this.ActivateWindow = this.UIWindow[0];
			break;
		case 1:
			this.UIWindow[0] = new UIResourceFilter();
			this.UIWindow[0].transform = base.transform;
			this.UIWindow[0].OnOpen(arg3, arg2);
			this.ActivateWindow = this.UIWindow[0];
			break;
		case 2:
			this.UIWindow[0] = new UISpeedup();
			this.UIWindow[0].transform = base.transform;
			this.UIWindow[0].OnOpen(arg3, arg2);
			this.ActivateWindow = this.UIWindow[0];
			NewbieManager.CheckTeach(ETeachKind.TURBO, null, false);
			break;
		case 3:
			this.UIWindow[0] = new NumberConfirm();
			this.UIWindow[0].transform = base.transform;
			this.UIWindow[0].OnOpen(arg3, arg2);
			this.ActivateWindow = this.UIWindow[0];
			base.transform.GetChild(base.transform.childCount - 1).gameObject.SetActive(true);
			break;
		case 4:
			this.UIWindow[0] = new UIItemFilter();
			this.UIWindow[0].transform = base.transform;
			this.UIWindow[0].OnOpen(arg3, arg2);
			this.ActivateWindow = this.UIWindow[0];
			break;
		case 5:
		{
			DataManager instance = DataManager.Instance;
			ItemBuff recordByIndex = instance.ItemBuffTable.GetRecordByIndex(arg2);
			Equip recordByKey = instance.EquipTable.GetRecordByKey(recordByIndex.BuffItemID);
			if (recordByKey.EquipKind - 1 == 11 && recordByKey.PropertiesInfo[0].Propertieskey >= 13 && recordByKey.PropertiesInfo[0].Propertieskey <= 15)
			{
				this.UIWindow[0] = new UIKingBufferFilter();
			}
			else
			{
				this.UIWindow[0] = new UIBuffItemFilter();
			}
			this.UIWindow[0].transform = base.transform;
			this.UIWindow[0].OnOpen(arg3, arg2);
			this.ActivateWindow = this.UIWindow[0];
			break;
		}
		case 6:
			this.UIWindow[0] = new UIItemKindFilter();
			this.UIWindow[0].transform = base.transform;
			this.UIWindow[0].OnOpen(arg3, arg2);
			this.ActivateWindow = this.UIWindow[0];
			break;
		case 7:
			this.UIWindow[0] = new UIGemRemoveFilter();
			this.UIWindow[0].transform = base.transform;
			this.UIWindow[0].OnOpen(arg3, arg2);
			this.ActivateWindow = this.UIWindow[0];
			break;
		case 8:
			this.UIWindow[0] = new UIGiftStore();
			this.UIWindow[0].transform = base.transform;
			this.UIWindow[0].OnOpen(arg3, arg2);
			this.ActivateWindow = this.UIWindow[0];
			break;
		case 9:
			this.UIWindow[0] = new UIKingReward();
			this.UIWindow[0].transform = base.transform;
			this.UIWindow[0].OnOpen(arg3, arg2);
			this.ActivateWindow = this.UIWindow[0];
			break;
		}
	}

	// Token: 0x06002B0D RID: 11021 RVA: 0x00470F98 File Offset: 0x0046F198
	public override void OnClose()
	{
		for (int i = 0; i < this.UIWindow.Length; i++)
		{
			if (this.UIWindow[i] != null)
			{
				this.UIWindow[i].OnClose();
			}
		}
	}

	// Token: 0x06002B0E RID: 11022 RVA: 0x00470FD8 File Offset: 0x0046F1D8
	public void Update()
	{
		if (this.ActivateWindow != null)
		{
			this.ActivateWindow.Update();
		}
	}

	// Token: 0x06002B0F RID: 11023 RVA: 0x00470FF0 File Offset: 0x0046F1F0
	public override void UpdateUI(int arge1, int arge2)
	{
		switch (arge1)
		{
		case 0:
			if (arge2 == 0)
			{
				if (this.UIWindow[1] == null)
				{
					GUIManager.Instance.CloseMenu(EGUIWindow.UI_BagFilter);
				}
				else
				{
					this.UIWindow[1].ThisTransform.gameObject.SetActive(false);
					this.ActivateWindow = this.UIWindow[0];
				}
			}
			else if (arge2 == -1)
			{
				if (this.UIWindow[2] == null)
				{
					GUIManager.Instance.CloseMenu(EGUIWindow.UI_BagFilter);
				}
				else
				{
					this.UIWindow[2].ThisTransform.gameObject.SetActive(false);
					this.ActivateWindow = this.UIWindow[0];
				}
			}
			break;
		default:
			if (arge1 != 10)
			{
				if (this.ActivateWindow is NumberConfirm)
				{
					this.UIWindow[0].UpdateUI(arge1, arge2);
				}
				else
				{
					this.ActivateWindow.UpdateUI(arge1, arge2);
				}
			}
			else
			{
				if (this.UIWindow[2] == null)
				{
					this.UIWindow[2] = new BuyNumConfirm();
					this.UIWindow[2].transform = base.transform;
					this.UIWindow[2].OnOpen(arge2, (int)this.UIWindow[0].UseTargetID);
					this.UIWindow[2].ThisTransform.SetParent(GUIManager.Instance.m_SecWindowLayer);
				}
				else if (!this.UIWindow[2].ThisTransform.gameObject.activeSelf)
				{
					(this.UIWindow[2] as BuyNumConfirm).UpdateData(arge2);
				}
				else
				{
					this.UIWindow[2].UpdateUI(arge2, (int)this.UIWindow[0].UseTargetID);
				}
				this.UIWindow[2].ThisTransform.gameObject.SetActive(true);
				this.ActivateWindow = this.UIWindow[2];
			}
			break;
		case 3:
			if (this.UIWindow[1] == null)
			{
				this.UIWindow[1] = new NumberConfirm();
				this.UIWindow[1].transform = base.transform;
				this.UIWindow[1].OnOpen(arge2, (int)this.UIWindow[0].UseTargetID);
				this.UIWindow[1].ThisTransform.SetParent(GUIManager.Instance.m_SecWindowLayer);
			}
			else
			{
				this.UIWindow[1].UpdateUI(arge2, (int)this.UIWindow[0].UseTargetID);
			}
			this.UIWindow[1].ThisTransform.gameObject.SetActive(true);
			this.ActivateWindow = this.UIWindow[1];
			break;
		}
	}

	// Token: 0x06002B10 RID: 11024 RVA: 0x0047128C File Offset: 0x0046F48C
	public override void UpdateNetwork(byte[] meg)
	{
		if (this.UIWindow[0] != null)
		{
			this.UIWindow[0].UpdateNetwork(meg);
		}
		if (this.UIWindow[1] != null)
		{
			this.UIWindow[1].UpdateNetwork(meg);
		}
		if (this.UIWindow[2] != null)
		{
			this.UIWindow[2].UpdateNetwork(meg);
		}
	}

	// Token: 0x06002B11 RID: 11025 RVA: 0x004712EC File Offset: 0x0046F4EC
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.UIWindow[0] != null)
		{
			this.UIWindow[0].UpdateTime(bOnSecond);
		}
		if (this.UIWindow[1] != null)
		{
			this.UIWindow[1].UpdateTime(bOnSecond);
		}
	}

	// Token: 0x06002B12 RID: 11026 RVA: 0x00471330 File Offset: 0x0046F530
	public override bool OnBackButtonClick()
	{
		if (this.UIWindow[1] != null && this.UIWindow[1].ThisTransform.gameObject.activeSelf)
		{
			this.UIWindow[1].ThisTransform.gameObject.SetActive(false);
			this.ActivateWindow = this.UIWindow[0];
			return true;
		}
		return false;
	}

	// Token: 0x06002B13 RID: 11027 RVA: 0x00471390 File Offset: 0x0046F590
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		this.ActivateWindow.OnOKCancelBoxClick(bOK, arg1, arg2);
	}

	// Token: 0x040076B0 RID: 30384
	private UIBagFilterBase[] UIWindow = new UIBagFilterBase[3];

	// Token: 0x040076B1 RID: 30385
	public UIBagFilterBase ActivateWindow;

	// Token: 0x040076B2 RID: 30386
	public int Type;
}
