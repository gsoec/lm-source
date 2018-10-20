using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000212 RID: 530
public class UIMonster_Crypt_3 : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x060009B0 RID: 2480 RVA: 0x000C90EC File Offset: 0x000C72EC
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		ushort id = 9171;
		ushort id2 = 9178;
		this.OpenKind = (eMC3_OpenKind)arg1;
		if (this.OpenKind == eMC3_OpenKind.ePetInfo)
		{
			id = 16071;
			id2 = 16070;
		}
		Transform child = this.GameT.GetChild(0);
		Transform child2 = child.GetChild(2);
		this.text_Title = child2.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID((uint)id);
		child = this.GameT.GetChild(1);
		child2 = child.GetChild(0);
		this.Content_RT = child2.GetComponent<RectTransform>();
		Transform child3 = child2.GetChild(0);
		this.text_Info = child3.GetComponent<UIText>();
		this.text_Info.font = this.TTFont;
		this.text_Info.text = this.DM.mStringTable.GetStringByID((uint)id2);
		if (this.text_Info.preferredHeight > this.text_Info.rectTransform.sizeDelta.y)
		{
			this.text_Info.rectTransform.sizeDelta = new Vector2(this.text_Info.rectTransform.sizeDelta.x, this.text_Info.preferredHeight);
			this.Content_RT.sizeDelta = new Vector2(this.Content_RT.sizeDelta.x, this.text_Info.preferredHeight);
		}
		child = this.GameT.GetChild(2).GetChild(0);
		this.btn_EXIT = child.GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.GameT.GetChild(2).GetComponent<Image>().enabled = false;
		}
	}

	// Token: 0x060009B1 RID: 2481 RVA: 0x000C9328 File Offset: 0x000C7528
	public override void OnClose()
	{
	}

	// Token: 0x060009B2 RID: 2482 RVA: 0x000C932C File Offset: 0x000C752C
	public void OnButtonClick(UIButton sender)
	{
		GUIArena_Info btnID = (GUIArena_Info)sender.m_BtnID1;
		if (btnID == GUIArena_Info.btn_EXIT)
		{
			if (this.OpenKind == eMC3_OpenKind.eNormal)
			{
				GamblingManager.Instance.CloseMenu(false);
			}
			else if (this.OpenKind == eMC3_OpenKind.ePetInfo)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door)
				{
					door.CloseMenu(false);
				}
			}
		}
	}

	// Token: 0x060009B3 RID: 2483 RVA: 0x000C939C File Offset: 0x000C759C
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
	}

	// Token: 0x060009B4 RID: 2484 RVA: 0x000C93D4 File Offset: 0x000C75D4
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Info != null && this.text_Info.enabled)
		{
			this.text_Info.enabled = false;
			this.text_Info.enabled = true;
		}
	}

	// Token: 0x04002061 RID: 8289
	private DataManager DM;

	// Token: 0x04002062 RID: 8290
	private GUIManager GUIM;

	// Token: 0x04002063 RID: 8291
	private Transform GameT;

	// Token: 0x04002064 RID: 8292
	private Font TTFont;

	// Token: 0x04002065 RID: 8293
	private UISpritesArray SArray;

	// Token: 0x04002066 RID: 8294
	private RectTransform Content_RT;

	// Token: 0x04002067 RID: 8295
	private RectTransform P1_RT;

	// Token: 0x04002068 RID: 8296
	private RectTransform P2_RT;

	// Token: 0x04002069 RID: 8297
	private UIButton btn_EXIT;

	// Token: 0x0400206A RID: 8298
	private UIText text_Title;

	// Token: 0x0400206B RID: 8299
	private UIText text_Info;

	// Token: 0x0400206C RID: 8300
	private int tmpItemNum;

	// Token: 0x0400206D RID: 8301
	private eMC3_OpenKind OpenKind;
}
