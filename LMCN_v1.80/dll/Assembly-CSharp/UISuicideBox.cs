using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000664 RID: 1636
public class UISuicideBox : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001F79 RID: 8057 RVA: 0x003C1B94 File Offset: 0x003BFD94
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
		}
		else
		{
			UISuicideBox.SendRefresh();
		}
	}

	// Token: 0x06001F7A RID: 8058 RVA: 0x003C1BD0 File Offset: 0x003BFDD0
	public override void OnOpen(int arg1, int arg2)
	{
		this.TransCache = base.transform;
		GUIManager instance = GUIManager.Instance;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		DataManager instance2 = DataManager.Instance;
		CustomImage component = this.TransCache.transform.GetComponent<CustomImage>();
		component.hander = instance;
		Transform child = this.TransCache.transform.GetChild(0);
		component = child.GetComponent<CustomImage>();
		component.hander = instance;
		component = child.GetChild(0).GetComponent<CustomImage>();
		component.hander = instance;
		component = child.GetChild(1).GetComponent<CustomImage>();
		component.hander = instance;
		this.TitleText = child.GetChild(2).GetComponent<UIText>();
		this.TitleText.font = ttffont;
		this.TitleText.text = instance2.mStringTable.GetStringByID(15006u);
		this.Text1Text = child.GetChild(3).GetComponent<UIText>();
		this.Text1Text.font = ttffont;
		this.Text1Str = StringManager.Instance.SpawnString(200);
		this.Text2Text = child.GetChild(4).GetComponent<UIText>();
		this.Text2Text.font = ttffont;
		this.Text2Text.text = instance2.mStringTable.GetStringByID(15004u);
		this.SendBtnBackImg = child.GetChild(5).GetComponent<CustomImage>();
		this.SendBtnBackImg.hander = instance;
		this.SendBtn = child.GetChild(5).GetComponent<UIButton>();
		this.SendBtn.m_Handler = this;
		this.SendBtn.m_BtnID1 = 1;
		this.NeedText = child.GetChild(5).GetChild(1).GetComponent<UIText>();
		this.NeedText.font = ttffont;
		this.UseText = child.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.UseText.font = ttffont;
		this.UseText.text = instance2.mStringTable.GetStringByID(15006u);
		this.NeedCtStr = StringManager.Instance.SpawnString(30);
		Transform child2 = child.GetChild(6);
		component = child2.GetChild(1).GetComponent<CustomImage>();
		component.hander = instance;
		this.ItemNameText = child2.GetChild(0).GetComponent<UIText>();
		this.ItemNameText.font = ttffont;
		this.ItemNameText.text = instance2.mStringTable.GetStringByID(11577u);
		this.ItemCountText = child2.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.ItemCountText.font = ttffont;
		this.ItemCountStr = StringManager.Instance.SpawnString(30);
		GUIManager.Instance.InitianHeroItemImg(child2.GetChild(2), eHeroOrItem.Item, 1317, 0, 0, 0, false, false, true, false);
		this.CheckSuicideItem();
		component = child.GetChild(7).GetComponent<CustomImage>();
		component.hander = instance;
		this.CloseBtn = child.GetChild(7).GetComponent<UIButton>();
		this.CloseBtn.m_Handler = this;
		this.CloseBtn.m_BtnID1 = 2;
	}

	// Token: 0x06001F7B RID: 8059 RVA: 0x003C1EC4 File Offset: 0x003C00C4
	public override void OnClose()
	{
		if (this.Text1Str != null)
		{
			StringManager.Instance.DeSpawnString(this.Text1Str);
		}
		if (this.ItemCountStr != null)
		{
			StringManager.Instance.DeSpawnString(this.ItemCountStr);
		}
		if (this.NeedCtStr != null)
		{
			StringManager.Instance.DeSpawnString(this.NeedCtStr);
		}
	}

	// Token: 0x06001F7C RID: 8060 RVA: 0x003C1F28 File Offset: 0x003C0128
	public static bool OpenSelf(bool bCameraMode = false)
	{
		return GUIManager.Instance.OpenMenu(EGUIWindow.UI_SuicideBox, 0, 0, bCameraMode, true, false);
	}

	// Token: 0x06001F7D RID: 8061 RVA: 0x003C1F50 File Offset: 0x003C0150
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			if (sender.m_BtnID2 == 1)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(15007u), 255, true);
			}
			else
			{
				DataManager.Instance.UseItem(1317, this.NeedItemCt, 0, 0, 0, 0u, string.Empty, true);
			}
		}
		else if (sender.m_BtnID1 == 2)
		{
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_SuicideBox);
		}
	}

	// Token: 0x06001F7E RID: 8062 RVA: 0x003C1FE0 File Offset: 0x003C01E0
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 0)
		{
			this.CheckSuicideItem();
		}
	}

	// Token: 0x06001F7F RID: 8063 RVA: 0x003C2008 File Offset: 0x003C0208
	public void Refresh_FontTexture()
	{
		if (this.TitleText != null && this.TitleText.enabled)
		{
			this.TitleText.enabled = false;
			this.TitleText.enabled = true;
		}
		if (this.Text2Text != null && this.Text2Text.enabled)
		{
			this.Text2Text.enabled = false;
			this.Text2Text.enabled = true;
		}
		if (this.ItemNameText != null && this.ItemNameText.enabled)
		{
			this.ItemNameText.enabled = false;
			this.ItemNameText.enabled = true;
		}
		if (this.ItemCountText != null && this.ItemCountText.enabled)
		{
			this.ItemCountText.enabled = false;
			this.ItemCountText.enabled = true;
		}
		if (this.Text1Text != null && this.Text1Text.enabled)
		{
			this.Text1Text.enabled = false;
			this.Text1Text.enabled = true;
		}
		if (this.NeedText != null && this.NeedText.enabled)
		{
			this.NeedText.enabled = false;
			this.NeedText.enabled = true;
		}
		if (this.UseText != null && this.UseText.enabled)
		{
			this.UseText.enabled = false;
			this.UseText.enabled = true;
		}
	}

	// Token: 0x06001F80 RID: 8064 RVA: 0x003C21A4 File Offset: 0x003C03A4
	public void CheckSuicideItem()
	{
		int curItemQuantity = (int)DataManager.Instance.GetCurItemQuantity(1317, 0);
		this.ItemCountStr.ClearString();
		this.ItemCountStr.Append(DataManager.Instance.mStringTable.GetStringByID(281u));
		this.ItemCountStr.IntToFormat((long)curItemQuantity, 1, true);
		this.ItemCountStr.AppendFormat("{0}");
		this.ItemCountText.text = this.ItemCountStr.ToString();
		this.ItemCountText.SetAllDirty();
		this.ItemCountText.cachedTextGenerator.Invalidate();
		int num = 24;
		this.Text1Str.ClearString();
		this.Text1Str.IntToFormat((long)num, 1, true);
		this.Text1Str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(15003u));
		this.Text1Text.text = this.Text1Str.ToString();
		this.Text1Text.SetAllDirty();
		this.Text1Text.cachedTextGenerator.Invalidate();
		this.NeedItemCt = UISuicideBox.ItemRequire;
		this.NeedCtStr.ClearString();
		this.NeedCtStr.IntToFormat((long)this.NeedItemCt, 1, true);
		this.NeedCtStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(15005u));
		this.NeedText.text = this.NeedCtStr.ToString();
		this.NeedText.SetAllDirty();
		this.NeedText.cachedTextGenerator.Invalidate();
		this.SetSendButtonColor(curItemQuantity);
	}

	// Token: 0x06001F81 RID: 8065 RVA: 0x003C2330 File Offset: 0x003C0530
	private void SetSendButtonColor(int itemCt)
	{
		if (itemCt < (int)this.NeedItemCt)
		{
			this.SendBtn.m_BtnID2 = 1;
			this.NeedText.color = new Color(0.898f, 0f, 0.31f);
			this.NeedText.color *= Color.gray;
			this.UseText.color = Color.gray;
			this.SendBtnBackImg.color = Color.gray;
		}
		else
		{
			this.SendBtn.m_BtnID2 = 0;
			this.NeedText.color = Color.white;
			this.UseText.color = Color.white;
			this.SendBtnBackImg.color = Color.white;
		}
	}

	// Token: 0x06001F82 RID: 8066 RVA: 0x003C23F0 File Offset: 0x003C05F0
	public static void RespSuicideNumByPowerBoard(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.LordInfo);
		int num = MP.ReadInt(-1);
		UISuicideBox.ItemRequire = MP.ReadUShort(-1);
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_SuicideBox) != null)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuicideBox, 0, 0);
		}
		else
		{
			UISuicideBox.OpenSelf(false);
		}
	}

	// Token: 0x06001F83 RID: 8067 RVA: 0x003C2458 File Offset: 0x003C0658
	public static void SendRefresh()
	{
		if (GUIManager.Instance.ShowUILock(EUILock.LordInfo))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_SUICIDENUM_BY_POWER_BOARD;
			messagePacket.AddSeqId();
			messagePacket.Add(DataManager.Instance.RoleAttr.Power);
			messagePacket.Send(false);
		}
	}

	// Token: 0x04006390 RID: 25488
	public const ushort SuicideItemID = 1317;

	// Token: 0x04006391 RID: 25489
	public Transform TransCache;

	// Token: 0x04006392 RID: 25490
	public UIText TitleText;

	// Token: 0x04006393 RID: 25491
	public UIText Text1Text;

	// Token: 0x04006394 RID: 25492
	public UIText Text2Text;

	// Token: 0x04006395 RID: 25493
	private CString Text1Str;

	// Token: 0x04006396 RID: 25494
	public UIText ItemNameText;

	// Token: 0x04006397 RID: 25495
	public UIText ItemCountText;

	// Token: 0x04006398 RID: 25496
	private CString ItemCountStr;

	// Token: 0x04006399 RID: 25497
	public UIButton SendBtn;

	// Token: 0x0400639A RID: 25498
	public CustomImage SendBtnBackImg;

	// Token: 0x0400639B RID: 25499
	private CString NeedCtStr;

	// Token: 0x0400639C RID: 25500
	public UIText NeedText;

	// Token: 0x0400639D RID: 25501
	public UIText UseText;

	// Token: 0x0400639E RID: 25502
	private ushort NeedItemCt;

	// Token: 0x0400639F RID: 25503
	public UIButton CloseBtn;

	// Token: 0x040063A0 RID: 25504
	public static ushort ItemRequire;
}
