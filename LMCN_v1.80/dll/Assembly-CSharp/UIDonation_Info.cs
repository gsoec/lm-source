using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200031E RID: 798
public class UIDonation_Info : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x0600104B RID: 4171 RVA: 0x001D32EC File Offset: 0x001D14EC
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		Material material = this.door.LoadMaterial();
		StringManager instance = StringManager.Instance;
		this.Cstr_Info = instance.SpawnString(1024);
		Transform child = this.GameT.GetChild(0);
		Transform child2 = child.GetChild(1);
		this.text_Title = child2.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(14544u);
		child = this.GameT.GetChild(1);
		child2 = child.GetChild(0);
		this.Content_RT = child2.GetComponent<RectTransform>();
		Transform child3 = child2.GetChild(0);
		this.text_Info = child3.GetComponent<UIText>();
		this.text_Info.font = this.TTFont;
		this.Cstr_Info.ClearString();
		this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14551u));
		this.Cstr_Info.Append("\n\n");
		this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14552u));
		this.Cstr_Info.Append("\n\n");
		this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14553u));
		this.text_Info.text = this.Cstr_Info.ToString();
		this.text_Info.SetAllDirty();
		this.text_Info.cachedTextGenerator.Invalidate();
		this.text_Info.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_Info.preferredHeight > this.text_Info.rectTransform.sizeDelta.y)
		{
			this.text_Info.rectTransform.sizeDelta = new Vector2(this.text_Info.rectTransform.sizeDelta.x, this.text_Info.preferredHeight);
			this.Content_RT.sizeDelta = new Vector2(this.Content_RT.sizeDelta.x, this.text_Info.preferredHeight);
		}
		child = this.GameT.GetChild(2);
		Image component = child.GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = material;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component.enabled = false;
		}
		child = this.GameT.GetChild(2).GetChild(0);
		this.btn_EXIT = child.GetComponent<UIButton>();
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = material;
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x0600104C RID: 4172 RVA: 0x001D363C File Offset: 0x001D183C
	public override void OnClose()
	{
	}

	// Token: 0x0600104D RID: 4173 RVA: 0x001D3640 File Offset: 0x001D1840
	public void OnButtonClick(UIButton sender)
	{
		GUIDonation_Info btnID = (GUIDonation_Info)sender.m_BtnID1;
		if (btnID == GUIDonation_Info.btn_EXIT)
		{
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x0600104E RID: 4174 RVA: 0x001D3684 File Offset: 0x001D1884
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

	// Token: 0x0600104F RID: 4175 RVA: 0x001D36BC File Offset: 0x001D18BC
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

	// Token: 0x06001050 RID: 4176 RVA: 0x001D373C File Offset: 0x001D193C
	private void Start()
	{
	}

	// Token: 0x06001051 RID: 4177 RVA: 0x001D3740 File Offset: 0x001D1940
	private void Update()
	{
	}

	// Token: 0x040035A1 RID: 13729
	private DataManager DM;

	// Token: 0x040035A2 RID: 13730
	private GUIManager GUIM;

	// Token: 0x040035A3 RID: 13731
	private Transform GameT;

	// Token: 0x040035A4 RID: 13732
	private Door door;

	// Token: 0x040035A5 RID: 13733
	private Font TTFont;

	// Token: 0x040035A6 RID: 13734
	private UISpritesArray SArray;

	// Token: 0x040035A7 RID: 13735
	private RectTransform Content_RT;

	// Token: 0x040035A8 RID: 13736
	private RectTransform P1_RT;

	// Token: 0x040035A9 RID: 13737
	private RectTransform P2_RT;

	// Token: 0x040035AA RID: 13738
	private UIButton btn_EXIT;

	// Token: 0x040035AB RID: 13739
	private UIText text_Title;

	// Token: 0x040035AC RID: 13740
	private UIText text_Info;

	// Token: 0x040035AD RID: 13741
	private CString Cstr_Info;

	// Token: 0x040035AE RID: 13742
	private int tmpItemNum;
}
