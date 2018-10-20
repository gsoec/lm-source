using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004A5 RID: 1189
internal class UIShieldLog : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001835 RID: 6197 RVA: 0x0028C62C File Offset: 0x0028A82C
	public override void OnOpen(int arg1, int arg2)
	{
		Transform child = base.transform.GetChild(0);
		UIText[] array = new UIText[3];
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		this.m_TitleText = base.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_TitleText.font = GUIManager.Instance.GetTTFFont();
		this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID(11259u);
		this.m_EmptyTF = base.transform.GetChild(2);
		this.m_EmptyStr = this.m_EmptyTF.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.m_EmptyStr.font = GUIManager.Instance.GetTTFFont();
		this.m_EmptyStr.text = DataManager.Instance.mStringTable.GetStringByID(11264u);
		child = base.transform.GetChild(1);
		for (int i = 0; i < this.m_LebleText.Length; i++)
		{
			this.m_LebleText[i] = child.GetChild(0).GetChild(i).GetChild(0).GetComponent<UIText>();
			this.m_LebleText[i].font = GUIManager.Instance.GetTTFFont();
			this.m_LebleText[i].text = DataManager.Instance.mStringTable.GetStringByID((uint)(11260 + i));
		}
		for (int j = 0; j < this.m_ShieldLogObject.Length; j++)
		{
			this.m_ShieldLogObject[j] = new ShieldLogObject();
			int index = j + 1;
			Transform child2 = child.GetChild(index);
			for (int k = 0; k < array.Length; k++)
			{
				array[k] = child2.GetChild(k).GetChild(0).GetComponent<UIText>();
			}
			this.m_ShieldLogObject[j].Setup(array[0], array[1], array[2], child2);
		}
		Image component = base.transform.GetChild(3).GetComponent<Image>();
		component.sprite = door.LoadSprite("UI_main_close_base");
		component.material = door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && component)
		{
			component.enabled = false;
		}
		UIButton component2 = base.transform.GetChild(3).GetChild(0).GetComponent<UIButton>();
		component2.image.sprite = door.LoadSprite("UI_main_close");
		component2.image.material = door.LoadMaterial();
		component2.m_BtnID1 = 999;
		component2.m_Handler = this;
		ShieldLogManager.Instance.CheckDataState();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001836 RID: 6198 RVA: 0x0028C8E8 File Offset: 0x0028AAE8
	public override void OnClose()
	{
		if (this.m_ShieldLogObject != null)
		{
			for (int i = 0; i < this.m_ShieldLogObject.Length; i++)
			{
				if (this.m_ShieldLogObject[i] != null)
				{
					this.m_ShieldLogObject[i].DeSpawnString();
				}
			}
		}
	}

	// Token: 0x06001837 RID: 6199 RVA: 0x0028C934 File Offset: 0x0028AB34
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			this.UpdateData();
			break;
		case 3:
			this.ShowEmptyStr();
			break;
		}
	}

	// Token: 0x06001838 RID: 6200 RVA: 0x0028C974 File Offset: 0x0028AB74
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
			ShieldLogManager.Instance.CheckDataState();
		}
	}

	// Token: 0x06001839 RID: 6201 RVA: 0x0028C9B4 File Offset: 0x0028ABB4
	public void OnButtonClick(UIButton sender)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.CloseMenu(false);
		}
	}

	// Token: 0x0600183A RID: 6202 RVA: 0x0028C9E8 File Offset: 0x0028ABE8
	private void UpdateData()
	{
		for (int i = 0; i < 10; i++)
		{
			if (!ShieldLogManager.Instance.m_ShieldLogData[i].IsEmpty)
			{
				this.m_ShieldLogObject[i].SetEnableColor(ShieldLogManager.Instance.m_ShieldLogData[i].IsActive);
				this.m_ShieldLogObject[i].SetName(ShieldLogManager.Instance.m_ShieldLogData[i].ItemID);
				this.m_ShieldLogObject[i].SetBeginTime(ShieldLogManager.Instance.m_ShieldLogData[i].BeginTime);
				this.m_ShieldLogObject[i].SetEndTime(ShieldLogManager.Instance.m_ShieldLogData[i].EndTime);
			}
			else
			{
				this.m_ShieldLogObject[i].SetEmpty();
			}
			this.m_ShieldLogObject[i].Show();
		}
	}

	// Token: 0x0600183B RID: 6203 RVA: 0x0028CACC File Offset: 0x0028ACCC
	private void ShowEmptyStr()
	{
		for (int i = 0; i < 10; i++)
		{
			this.m_ShieldLogObject[i].Hide();
		}
		this.m_EmptyTF.gameObject.SetActive(true);
	}

	// Token: 0x0600183C RID: 6204 RVA: 0x0028CB0C File Offset: 0x0028AD0C
	private void Refresh_FontTexture()
	{
		if (this.m_TitleText != null && this.m_TitleText.enabled)
		{
			this.m_TitleText.enabled = false;
			this.m_TitleText.enabled = true;
		}
		if (this.m_LebleText != null)
		{
			for (int i = 0; i < this.m_LebleText.Length; i++)
			{
				if (this.m_LebleText[i] != null && this.m_LebleText[i].enabled)
				{
					this.m_LebleText[i].enabled = false;
					this.m_LebleText[i].enabled = true;
				}
			}
		}
		if (this.m_EmptyStr != null)
		{
			this.m_EmptyStr.enabled = false;
			this.m_EmptyStr.enabled = true;
		}
		if (this.m_ShieldLogObject != null)
		{
			for (int j = 0; j < this.m_ShieldLogObject.Length; j++)
			{
				if (this.m_ShieldLogObject[j] != null)
				{
					this.m_ShieldLogObject[j].Refresh_FontTexture();
				}
			}
		}
	}

	// Token: 0x04004734 RID: 18228
	private UIText m_EmptyStr;

	// Token: 0x04004735 RID: 18229
	private UIText m_TitleText;

	// Token: 0x04004736 RID: 18230
	private UIText[] m_LebleText = new UIText[3];

	// Token: 0x04004737 RID: 18231
	private Transform m_EmptyTF;

	// Token: 0x04004738 RID: 18232
	private UIButton m_ExitBtn;

	// Token: 0x04004739 RID: 18233
	private ShieldLogObject[] m_ShieldLogObject = new ShieldLogObject[10];

	// Token: 0x020004A6 RID: 1190
	private enum eUIShieldLog
	{
		// Token: 0x0400473B RID: 18235
		BgPanel,
		// Token: 0x0400473C RID: 18236
		Content,
		// Token: 0x0400473D RID: 18237
		EmptyStr,
		// Token: 0x0400473E RID: 18238
		Exit
	}
}
