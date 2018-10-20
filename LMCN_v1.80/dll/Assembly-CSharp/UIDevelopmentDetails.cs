using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200053F RID: 1343
public class UIDevelopmentDetails : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001AB9 RID: 6841 RVA: 0x002D66FC File Offset: 0x002D48FC
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.mOpenType = (EDevelopmentDetail_OpenKind)arg1;
		this.DataIdx = arg2;
		Transform transform = base.gameObject.transform;
		this.tmpImg = transform.GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_black");
		this.tmpImg.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.tmpImg.rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.tmpbtn = transform.GetChild(0).GetComponent<UIButton>();
		this.tmpbtn.m_Handler = this;
		this.tmpbtn.m_BtnID1 = 1;
		this.tmpbtn.image.sprite = this.door.LoadSprite("UI_main_black");
		this.tmpbtn.image.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			transform.GetChild(0).GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			transform.GetChild(0).GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.Tmp = transform.GetChild(1);
		this.tmpImg = this.Tmp.GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_009");
		this.tmpImg.material = this.door.LoadMaterial();
		this.Img_BGRT = this.Tmp.GetComponent<RectTransform>();
		this.Tmp1 = this.Tmp.GetChild(0);
		this.tmpImg = this.Tmp1.GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_con_title_orange");
		this.tmpImg.material = this.door.LoadMaterial();
		this.Img_Panel = this.Tmp.GetChild(1).GetComponent<Image>();
		this.Img_Panel.sprite = this.door.LoadSprite("UI_main_box_010");
		this.Img_Panel.material = this.door.LoadMaterial();
		this.Img_PanelRT = this.Tmp.GetChild(1).GetComponent<RectTransform>();
		this.text_Title = this.Tmp.GetChild(2).GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.tmpImg = transform.GetChild(2).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
			this.tmpImg.rectTransform.anchoredPosition = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.btn_EXIT = transform.GetChild(2).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 1;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.door.LoadMaterial();
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		switch (this.mOpenType)
		{
		case EDevelopmentDetail_OpenKind.WatchTower:
			this.tmpPanel = this.Img_Panel.gameObject.AddComponent<CustomPanel>();
			this.text_Title.text = this.DM.mStringTable.GetStringByID(4042u);
			this._DataIdx.Clear();
			this._DataIdx.Add(15);
			break;
		case EDevelopmentDetail_OpenKind.ArmyInfo:
		{
			this.tmpPanel = this.Img_Panel.gameObject.AddComponent<CustomPanel>();
			this.tmpPanel.DataIdx = this.DataIdx;
			this.text_Title.text = this.DM.mStringTable.GetStringByID(570u);
			this._DataIdx.Clear();
			if (this.DM.MarchEventData[this.DataIdx].Type != EMarchEventType.EMET_HitMonsterMarching && this.DM.MarchEventData[this.DataIdx].Type != EMarchEventType.EMET_HitMonsterReturn && this.DM.MarchEventData[this.DataIdx].Type != EMarchEventType.EMET_HitMonsterRetreat)
			{
				this._DataIdx.Add(16);
			}
			int num = 0;
			for (int i = 0; i < 5; i++)
			{
				if (this.DM.MarchEventData[this.DataIdx].HeroID[i] != 0)
				{
					num++;
				}
			}
			if (num > 0)
			{
				this._DataIdx.Add(17);
			}
			break;
		}
		case EDevelopmentDetail_OpenKind.Home_Wall_TrapInfo:
			this.tmpPanel = this.Img_Panel.gameObject.AddComponent<CustomPanel>();
			this.text_Title.text = this.DM.mStringTable.GetStringByID(4926u);
			this._DataIdx.Clear();
			this._DataIdx.Add(18);
			this._DataIdx.Add(19);
			this._DataIdx.Add(20);
			this._DataIdx.Add(21);
			break;
		case EDevelopmentDetail_OpenKind.Home_ArmyInfo:
			this.tmpPanel = this.Img_Panel.gameObject.AddComponent<CustomPanel>();
			this.text_Title.text = this.DM.mStringTable.GetStringByID(4917u);
			this._DataIdx.Clear();
			this._DataIdx.Add(22);
			this._DataIdx.Add(23);
			this._DataIdx.Add(24);
			break;
		case EDevelopmentDetail_OpenKind.Home_WatchTower:
			this.tmpPanel = this.Img_Panel.gameObject.AddComponent<CustomPanel>();
			this.text_Title.text = this.DM.mStringTable.GetStringByID(7225u);
			this.tmpPanel.SetPVE_Data(DataManager.StageDataController.StageRecord[2] + 1);
			this._DataIdx.Clear();
			this._DataIdx.Add(30);
			this._DataIdx.Add(25);
			this._DataIdx.Add(29);
			this._DataIdx.Add(27);
			this._DataIdx.Add(28);
			this._DataIdx.Add(26);
			NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, this, false);
			break;
		case EDevelopmentDetail_OpenKind.JailPrisoners:
			this.tmpPanel = this.Img_Panel.gameObject.AddComponent<CustomPanel>();
			this.text_Title.text = this.DM.mStringTable.GetStringByID(7789u);
			this._DataIdx.Clear();
			this._DataIdx.Add(31);
			break;
		case EDevelopmentDetail_OpenKind.CaveInfo:
			this.tmpPanel = this.Img_Panel.gameObject.AddComponent<CustomPanel>();
			this.text_Title.text = this.DM.mStringTable.GetStringByID(570u);
			this._DataIdx.Clear();
			this._DataIdx.Add(33);
			if (HideArmyManager.Instance.IsLordInShelter())
			{
				this._DataIdx.Add(34);
			}
			break;
		case EDevelopmentDetail_OpenKind.KingRewardList:
		{
			this.tmpPanel = this.Img_Panel.gameObject.AddComponent<CustomPanel>();
			this.tmpPanel.DataIdx = this.DataIdx;
			ushort itemID = DataManager.Instance.KingGift.GetGiftList()[this.DataIdx].ItemID;
			this.text_Title.text = this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(itemID).EquipName);
			this._DataIdx.Clear();
			this._DataIdx.Add(35);
			break;
		}
		case EDevelopmentDetail_OpenKind.WorldKingRewardList:
		case EDevelopmentDetail_OpenKind.NobilityRewardList:
		{
			this.tmpPanel = this.Img_Panel.gameObject.AddComponent<CustomPanel>();
			this.tmpPanel.DataIdx = this.DataIdx;
			ushort itemID2 = DataManager.Instance.KingGift.GetGiftList()[this.DataIdx].ItemID;
			this.text_Title.text = this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(itemID2).EquipName);
			this._DataIdx.Clear();
			this._DataIdx.Add(39);
			break;
		}
		}
		switch (this.mOpenType)
		{
		case EDevelopmentDetail_OpenKind.Home_WatchTower:
			this.tmpPanel.SetPanelData(this._DataIdx, true, true, 1110, 10, 0f);
			goto IL_9C2;
		case EDevelopmentDetail_OpenKind.CaveInfo:
		{
			RoleBuildingData buildData = this.GUIM.BuildingData.GetBuildData(13, 0);
			this.tmpPanel.SetPanelData(this._DataIdx, true, true, (int)buildData.Level, 0, 0f);
			goto IL_9C2;
		}
		}
		this.tmpPanel.SetPanelData(this._DataIdx, true, true, 1110, 0, 0f);
		IL_9C2:
		this.PreResizeForm();
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 6);
	}

	// Token: 0x06001ABA RID: 6842 RVA: 0x002D70E0 File Offset: 0x002D52E0
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID == 1)
		{
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x06001ABB RID: 6843 RVA: 0x002D7124 File Offset: 0x002D5324
	public override void UpdateUI(int arg1, int arg2)
	{
		this.ReflashContent(arg1, arg2);
	}

	// Token: 0x06001ABC RID: 6844 RVA: 0x002D7130 File Offset: 0x002D5330
	public override void UpdateNetwork(byte[] meg)
	{
		if (this.bOpen)
		{
			this.UpdateLater = true;
			return;
		}
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				if (this.tmpPanel != null)
				{
					this.tmpPanel.Refresh_FontTexture();
					this.Refresh_FontTexture();
				}
				if (this.text_Title != null && this.text_Title.enabled)
				{
					this.text_Title.enabled = false;
					this.text_Title.enabled = true;
				}
			}
			break;
		}
		switch (this.mOpenType)
		{
		case EDevelopmentDetail_OpenKind.WatchTower:
		case EDevelopmentDetail_OpenKind.ArmyInfo:
			return;
		case EDevelopmentDetail_OpenKind.Home_Wall_TrapInfo:
		case EDevelopmentDetail_OpenKind.Home_ArmyInfo:
			networkNews = (NetworkNews)meg[0];
			if (networkNews == NetworkNews.Refresh_Resource || networkNews == NetworkNews.Refresh_ServerTime)
			{
				return;
			}
			break;
		}
		this.ReflashContent(0, 0);
	}

	// Token: 0x06001ABD RID: 6845 RVA: 0x002D7224 File Offset: 0x002D5424
	public void Refresh_FontTexture()
	{
		if (this.tmpPanel.tmpText_Info != null && this.tmpPanel.tmpText_Info.enabled)
		{
			this.tmpPanel.tmpText_Info.enabled = false;
			this.tmpPanel.tmpText_Info.enabled = true;
		}
		for (int i = 0; i < 6; i++)
		{
			if (this.tmpPanel.Text_Info[i] != null && this.tmpPanel.Text_Info[i].enabled)
			{
				this.tmpPanel.Text_Info[i].enabled = false;
				this.tmpPanel.Text_Info[i].enabled = true;
			}
			if (this.tmpPanel.Text_End[i] != null && this.tmpPanel.Text_End[i].enabled)
			{
				this.tmpPanel.Text_End[i].enabled = false;
				this.tmpPanel.Text_End[i].enabled = true;
			}
			for (int j = 0; j < 2; j++)
			{
				if (this.tmpPanel.Text_Title[i][j] != null && this.tmpPanel.Text_Title[i][j].enabled)
				{
					this.tmpPanel.Text_Title[i][j].enabled = false;
					this.tmpPanel.Text_Title[i][j].enabled = true;
				}
				if (this.tmpPanel.Text_TextStr[i][j] != null && this.tmpPanel.Text_TextStr[i][j].enabled)
				{
					this.tmpPanel.Text_TextStr[i][j].enabled = false;
					this.tmpPanel.Text_TextStr[i][j].enabled = true;
				}
				if (this.tmpPanel.Text_LeftAlign[i][j] != null && this.tmpPanel.Text_LeftAlign[i][j].enabled)
				{
					this.tmpPanel.Text_LeftAlign[i][j].enabled = false;
					this.tmpPanel.Text_LeftAlign[i][j].enabled = true;
				}
			}
			for (int k = 0; k < 5; k++)
			{
				if (this.tmpPanel.Text_Resources[i][k] != null && this.tmpPanel.Text_Resources[i][k].enabled)
				{
					this.tmpPanel.Text_Resources[i][k].enabled = false;
					this.tmpPanel.Text_Resources[i][k].enabled = true;
				}
			}
		}
	}

	// Token: 0x06001ABE RID: 6846 RVA: 0x002D74D4 File Offset: 0x002D56D4
	public override void OnClose()
	{
		this._DataIdx = null;
		if (this.tmpPanel != null)
		{
			this.tmpPanel.Destroy();
		}
		if (this.mOpenType == EDevelopmentDetail_OpenKind.JailPrisoners)
		{
			for (int i = 0; i < this.DM.MapPrisoners.Count; i++)
			{
				StringManager.Instance.DeSpawnString(this.DM.MapPrisoners[i].TagName);
				this.DM.MapPrisoners[i].TagName = null;
			}
			this.DM.MapPrisoners.Clear();
		}
	}

	// Token: 0x06001ABF RID: 6847 RVA: 0x002D757C File Offset: 0x002D577C
	private void Start()
	{
	}

	// Token: 0x06001AC0 RID: 6848 RVA: 0x002D7580 File Offset: 0x002D5780
	private void Update()
	{
		if (this.bOpen)
		{
			this.tmpPanel.InitScrollPanel();
			this.Custom_PanelRT = this.tmpPanel.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
			this.Custom_ContentRT = this.tmpPanel.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RectTransform>();
			this.ResizeForm();
			this.bOpen = false;
			if (this.UpdateLater)
			{
				this.ReflashContent(0, 0);
			}
			this.bOpenEnd = true;
		}
	}

	// Token: 0x06001AC1 RID: 6849 RVA: 0x002D7614 File Offset: 0x002D5814
	private void PreResizeForm()
	{
		float num = this.tmpPanel.CurrentPanelHeight - 149f;
		if (num < 0f)
		{
			num = 0f;
		}
		else if (num > 312f)
		{
			num = 312f;
		}
		this.Img_BGRT.sizeDelta = new Vector2(this.Img_BGRT.sizeDelta.x, 269f + num);
		this.Img_PanelRT.sizeDelta = new Vector2(this.Img_PanelRT.sizeDelta.x, 160f + num);
	}

	// Token: 0x06001AC2 RID: 6850 RVA: 0x002D76B0 File Offset: 0x002D58B0
	private void ResizeForm()
	{
		if (this.Custom_ContentRT.sizeDelta.y <= 149f)
		{
			this.Custom_PanelRT.sizeDelta = new Vector2(this.Custom_PanelRT.sizeDelta.x, 149f);
		}
		else
		{
			float num = this.Custom_ContentRT.sizeDelta.y - 149f;
			if (num > 312f)
			{
				float num2 = this.Custom_ContentRT.sizeDelta.y - (num - 312f);
				if (num2 > 461f)
				{
					num2 = 461f;
				}
				this.Custom_PanelRT.sizeDelta = new Vector2(this.Custom_PanelRT.sizeDelta.x, num2);
				num = 312f;
			}
			this.Img_BGRT.sizeDelta = new Vector2(this.Img_BGRT.sizeDelta.x, 269f + num);
			this.Img_PanelRT.sizeDelta = new Vector2(this.Img_PanelRT.sizeDelta.x, 160f + num);
		}
	}

	// Token: 0x06001AC3 RID: 6851 RVA: 0x002D77DC File Offset: 0x002D59DC
	private void ReflashContent(int arg1, int arg2)
	{
		switch (this.mOpenType)
		{
		case EDevelopmentDetail_OpenKind.ArmyInfo:
			if (arg1 != 1)
			{
				if (arg1 == 2)
				{
					if (this.mOpenType == EDevelopmentDetail_OpenKind.ArmyInfo && this.DM.MarchEventData[this.DataIdx].Type == EMarchEventType.EMET_Standby)
					{
						this.door.CloseMenu(false);
						return;
					}
				}
			}
			else if (this.DataIdx == arg2 && this.bOpenEnd)
			{
				this._DataIdx.Clear();
				this._DataIdx.Add(16);
				int num = 0;
				for (int i = 0; i < 5; i++)
				{
					if (this.DM.MarchEventData[this.DataIdx].HeroID[i] != 0)
					{
						num++;
					}
				}
				if (num > 0)
				{
					this._DataIdx.Add(17);
				}
				this.tmpPanel.SetPanelData(this._DataIdx, true, false, 1110, 0, 0f);
			}
			break;
		case EDevelopmentDetail_OpenKind.Home_Wall_TrapInfo:
			this._DataIdx.Clear();
			this._DataIdx.Add(18);
			this._DataIdx.Add(19);
			this._DataIdx.Add(20);
			this._DataIdx.Add(21);
			this.tmpPanel.SetPanelData(this._DataIdx, false, false, 0, 0, 0f);
			break;
		case EDevelopmentDetail_OpenKind.Home_ArmyInfo:
			this._DataIdx.Clear();
			this._DataIdx.Add(22);
			this._DataIdx.Add(23);
			this._DataIdx.Add(24);
			this.tmpPanel.SetPanelData(this._DataIdx, false, false, 0, 0, 0f);
			break;
		case EDevelopmentDetail_OpenKind.CaveInfo:
			if (arg1 == 6 && this.door != null)
			{
				this.door.CloseMenu(false);
				return;
			}
			break;
		case EDevelopmentDetail_OpenKind.KingRewardList:
			if (arg1 == 1 && this.door != null)
			{
				this.door.CloseMenu(false);
				return;
			}
			break;
		}
		if (this.bOpenEnd)
		{
			this.ResizeForm();
		}
	}

	// Token: 0x04004F3A RID: 20282
	private DataManager DM;

	// Token: 0x04004F3B RID: 20283
	private GUIManager GUIM;

	// Token: 0x04004F3C RID: 20284
	private Transform Tmp;

	// Token: 0x04004F3D RID: 20285
	private Transform Tmp1;

	// Token: 0x04004F3E RID: 20286
	private RectTransform Img_BGRT;

	// Token: 0x04004F3F RID: 20287
	private RectTransform Img_PanelRT;

	// Token: 0x04004F40 RID: 20288
	private RectTransform Custom_PanelRT;

	// Token: 0x04004F41 RID: 20289
	private RectTransform Custom_ContentRT;

	// Token: 0x04004F42 RID: 20290
	public UIButton btn_EXIT;

	// Token: 0x04004F43 RID: 20291
	private UIButton tmpbtn;

	// Token: 0x04004F44 RID: 20292
	private Image tmpImg;

	// Token: 0x04004F45 RID: 20293
	private Image Img_Panel;

	// Token: 0x04004F46 RID: 20294
	private UIText text_Title;

	// Token: 0x04004F47 RID: 20295
	public CustomPanel tmpPanel;

	// Token: 0x04004F48 RID: 20296
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x04004F49 RID: 20297
	private Door door;

	// Token: 0x04004F4A RID: 20298
	private List<int> _DataIdx = new List<int>();

	// Token: 0x04004F4B RID: 20299
	private bool bOpen = true;

	// Token: 0x04004F4C RID: 20300
	private bool bOpenEnd;

	// Token: 0x04004F4D RID: 20301
	private bool UpdateLater;

	// Token: 0x04004F4E RID: 20302
	private EDevelopmentDetail_OpenKind mOpenType;

	// Token: 0x04004F4F RID: 20303
	private int DataIdx;
}
