using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002E9 RID: 745
public class UIAlliance_List : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06000F1B RID: 3867 RVA: 0x001A757C File Offset: 0x001A577C
	public override void OnOpen(int arg1, int arg2)
	{
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.m_AllianceType = (eAllianceType)arg1;
		if (this.m_AllianceType == eAllianceType.eReward)
		{
			this.m_RewardItemID = (ushort)arg2;
		}
		else if (this.m_AllianceType == eAllianceType.ePublicMember)
		{
			this.m_AllianceID = (uint)arg2;
		}
		this.sb = new StringBuilder();
		this.m_Data = new List<int>();
		this.m_Group = new AllianceGroup[5];
		this.m_DemiseStr = StringManager.Instance.SpawnString(200);
		this.m_Expel = StringManager.Instance.SpawnString(100);
		this.m_RankName = StringManager.Instance.SpawnString(100);
		this.m_RewardCount = StringManager.Instance.SpawnString(100);
		this.m_ManagementName = StringManager.Instance.SpawnString(100);
		this.m_DemisePowerValue = StringManager.Instance.SpawnString(100);
		this.m_SpritesArray = base.transform.GetComponent<UISpritesArray>();
		UIText component = base.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		if (this.m_AllianceType == eAllianceType.eManagement || this.m_AllianceType == eAllianceType.eResourceTransport || this.m_AllianceType == eAllianceType.eReinforce || this.m_AllianceType == eAllianceType.eReward || this.m_AllianceType == eAllianceType.eAmbush)
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(4737u);
		}
		else if (this.m_AllianceType == eAllianceType.eApply)
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(4741u);
		}
		else if (this.m_AllianceType == eAllianceType.eDemise)
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(4744u);
		}
		else if (this.m_AllianceType == eAllianceType.ePublicMember)
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(4737u);
		}
		UIButton component2 = base.transform.GetChild(1).GetChild(1).GetComponent<UIButton>();
		component2.m_BtnID1 = 4;
		component2.m_Handler = this;
		component2.gameObject.AddComponent<ArabicItemTextureRot>();
		this.m_RewardCountText = base.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<UIText>();
		this.m_RewardCountText.font = ttffont;
		if (this.m_AllianceType == eAllianceType.eReward)
		{
			component2.gameObject.SetActive(false);
			base.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
			this.SetRewardCountText(this.GetGiftCount());
		}
		Image component3 = base.transform.GetChild(2).GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_close_base");
		component3.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && component3)
		{
			component3.enabled = false;
		}
		component2 = base.transform.GetChild(2).GetChild(0).GetComponent<UIButton>();
		component2.m_BtnID1 = 3;
		component2.m_Handler = this;
		component2.image.sprite = this.door.LoadSprite("UI_main_close");
		component2.image.material = this.door.LoadMaterial();
		component = base.transform.GetChild(4).GetChild(0).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component = base.transform.GetChild(4).GetChild(0).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component4 = base.transform.GetChild(4).GetChild(0).GetChild(1).GetComponent<RectTransform>();
			Vector2 anchoredPosition = component4.anchoredPosition;
			anchoredPosition.x = 88f;
			component4.anchoredPosition = anchoredPosition;
			Vector3 localScale = component4.localScale;
			localScale.x = -1f;
			component4.localScale = localScale;
			component4 = base.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<RectTransform>();
			localScale = component4.localScale;
			localScale.x = -1f;
			component4.localScale = localScale;
			base.transform.GetChild(4).GetChild(1).GetChild(10).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		UIHIBtn component5 = base.transform.GetChild(4).GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
		GUIManager.Instance.InitianHeroItemImg(component5.transform, eHeroOrItem.Hero, 1, 0, 0, 0, false, false, true, false);
		base.transform.GetChild(4).GetChild(1).GetChild(0).gameObject.AddComponent<IgnoreRaycast>();
		component = base.transform.GetChild(4).GetChild(1).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component = base.transform.GetChild(4).GetChild(1).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component = base.transform.GetChild(4).GetChild(1).GetChild(6).GetComponent<UIText>();
		component.font = ttffont;
		component = base.transform.GetChild(4).GetChild(1).GetChild(7).GetComponent<UIText>();
		component.font = ttffont;
		component = base.transform.GetChild(4).GetChild(1).GetChild(8).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component = base.transform.GetChild(4).GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component = base.transform.GetChild(4).GetChild(1).GetChild(10).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		this.m_ManagePanel = base.transform.GetChild(5);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			((RectTransform)this.m_ManagePanel).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)this.m_ManagePanel).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		this.m_ManagePanelNameText = this.m_ManagePanel.GetChild(3).GetComponent<UIText>();
		this.m_ManagePanelNameText.font = ttffont;
		this.m_ManagePanelGiftTf = this.m_ManagePanel.GetChild(4);
		if (this.m_ManagePanelGiftTf != null)
		{
			this.m_ManagePanelGiftRectTf = this.m_ManagePanelGiftTf.GetComponent<RectTransform>();
			if (this.m_ManagePanelGiftRectTf != null)
			{
				this.m_ManagePanelGiftRectTf.anchorMax = new Vector2(0.5f, 0.5f);
				this.m_ManagePanelGiftRectTf.anchorMin = new Vector2(0.5f, 0.5f);
				this.m_ManagePanelGiftRectTf.pivot = new Vector2(0.5f, 0.5f);
				this.m_ManagePanelGiftRectTf.anchoredPosition = new Vector2(135f, 124.5f);
			}
		}
		this.m_ManagePanelRankImage = this.m_ManagePanel.GetChild(2).GetComponent<Image>();
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform rectTransform = this.m_ManagePanelRankImage.rectTransform;
			Vector3 localScale2 = rectTransform.localScale;
			localScale2.x = -1f;
			rectTransform.localScale = localScale2;
		}
		component = this.m_ManagePanel.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4754u);
		component = this.m_ManagePanel.GetChild(4).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4755u);
		component2 = this.m_ManagePanel.GetChild(4).GetComponent<UIButton>();
		component2.m_BtnID1 = 101;
		component2.m_Handler = this;
		component2.gameObject.SetActive(false);
		component = this.m_ManagePanel.GetChild(5).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component2 = this.m_ManagePanel.GetChild(5).GetComponent<UIButton>();
		component2.m_BtnID1 = 103;
		component2.m_Handler = this;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4756u);
		component = this.m_ManagePanel.GetChild(6).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component2 = this.m_ManagePanel.GetChild(6).GetComponent<UIButton>();
		component2.m_BtnID1 = 104;
		component2.m_Handler = this;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4757u);
		component = this.m_ManagePanel.GetChild(7).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component2 = this.m_ManagePanel.GetChild(7).GetComponent<UIButton>();
		component2.m_BtnID1 = 105;
		component2.m_Handler = this;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4758u);
		component = this.m_ManagePanel.GetChild(8).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component2 = this.m_ManagePanel.GetChild(8).GetComponent<UIButton>();
		component2.m_BtnID1 = 106;
		component2.m_Handler = this;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4759u);
		component2 = this.m_ManagePanel.GetChild(9).GetComponent<UIButton>();
		component2.m_BtnID1 = 102;
		component2.image.sprite = this.door.LoadSprite("UI_main_close");
		component2.image.material = this.door.LoadMaterial();
		component2.m_Handler = this;
		component = this.m_ManagePanel.GetChild(10).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(9348u);
		component2 = this.m_ManagePanel.GetChild(10).GetComponent<UIButton>();
		component2.m_BtnID1 = 107;
		component2.m_Handler = this;
		component = this.m_ManagePanel.GetChild(11).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(9529u);
		component2 = this.m_ManagePanel.GetChild(11).GetComponent<UIButton>();
		component2.m_BtnID1 = 108;
		component2.m_Handler = this;
		HelperUIButton helperUIButton = this.m_ManagePanel.gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID1 = 102;
		IgnoreRaycast component6 = this.m_ManagePanel.GetChild(0).GetComponent<IgnoreRaycast>();
		UnityEngine.Object.Destroy(component6);
		this.m_RankChangePanel = base.transform.GetChild(6);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			((RectTransform)this.m_RankChangePanel).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)this.m_RankChangePanel).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		component = this.m_RankChangePanel.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4760u);
		this.m_RankChangePanelNameText = this.m_RankChangePanel.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.m_RankChangePanelNameText.font = ttffont;
		component = this.m_RankChangePanel.GetChild(3).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4762u);
		component = this.m_RankChangePanel.GetChild(4).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4763u);
		this.m_RankChangePanelBtnImages[3] = this.m_RankChangePanel.GetChild(4).GetComponent<Image>();
		this.m_RankChangePanelCheckImages[3] = this.m_RankChangePanel.GetChild(4).GetChild(2).GetComponent<Image>();
		component2 = this.m_RankChangePanel.GetChild(4).GetComponent<UIButton>();
		component2.m_BtnID1 = 201;
		component2.m_Handler = this;
		component = this.m_RankChangePanel.GetChild(5).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4764u);
		this.m_RankChangePanelBtnImages[2] = this.m_RankChangePanel.GetChild(5).GetComponent<Image>();
		this.m_RankChangePanelCheckImages[2] = this.m_RankChangePanel.GetChild(5).GetChild(2).GetComponent<Image>();
		component2 = this.m_RankChangePanel.GetChild(5).GetComponent<UIButton>();
		component2.m_BtnID1 = 202;
		component2.m_Handler = this;
		component = this.m_RankChangePanel.GetChild(6).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4765u);
		this.m_RankChangePanelBtnImages[1] = this.m_RankChangePanel.GetChild(6).GetComponent<Image>();
		this.m_RankChangePanelCheckImages[1] = this.m_RankChangePanel.GetChild(6).GetChild(2).GetComponent<Image>();
		component2 = this.m_RankChangePanel.GetChild(6).GetComponent<UIButton>();
		component2.m_BtnID1 = 203;
		component2.m_Handler = this;
		component = this.m_RankChangePanel.GetChild(7).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4766u);
		this.m_RankChangePanelBtnImages[0] = this.m_RankChangePanel.GetChild(7).GetComponent<Image>();
		this.m_RankChangePanelCheckImages[0] = this.m_RankChangePanel.GetChild(7).GetChild(2).GetComponent<Image>();
		component2 = this.m_RankChangePanel.GetChild(7).GetComponent<UIButton>();
		component2.m_BtnID1 = 204;
		component2.m_Handler = this;
		component = this.m_RankChangePanel.GetChild(8).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4767u);
		component2 = this.m_RankChangePanel.GetChild(8).GetComponent<UIButton>();
		component2.m_BtnID1 = 205;
		component2.m_Handler = this;
		component2 = this.m_RankChangePanel.GetChild(9).GetComponent<UIButton>();
		component2.m_BtnID1 = 206;
		component2.m_Handler = this;
		component2.image.sprite = this.door.LoadSprite("UI_main_close");
		component2.image.material = this.door.LoadMaterial();
		helperUIButton = this.m_RankChangePanel.gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID1 = 206;
		component6 = this.m_RankChangePanel.GetChild(0).GetComponent<IgnoreRaycast>();
		UnityEngine.Object.Destroy(component6);
		this.m_EmptyText = base.transform.GetChild(7);
		component = this.m_EmptyText.GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(595u);
		this.m_DemisePanel = base.transform.GetChild(8);
		CustomImage component7 = this.m_DemisePanel.GetChild(1).GetComponent<CustomImage>();
		component7.hander = GUIManager.Instance;
		component7 = this.m_DemisePanel.GetChild(1).GetChild(0).GetComponent<CustomImage>();
		component7.hander = GUIManager.Instance;
		component7 = this.m_DemisePanel.GetChild(1).GetChild(1).GetComponent<CustomImage>();
		component7.hander = GUIManager.Instance;
		this.m_DemiseHIbtn = this.m_DemisePanel.GetChild(1).GetChild(2).GetComponent<UIHIBtn>();
		GUIManager.Instance.InitianHeroItemImg(this.m_DemiseHIbtn.transform, eHeroOrItem.Hero, 1, 0, 0, 0, false, false, false, false);
		this.m_DemiseHIbtn.gameObject.AddComponent<IgnoreRaycast>();
		this.m_DemiseRankIcon = this.m_DemisePanel.GetChild(1).GetChild(3).GetComponent<Image>();
		UIButtonHint uibuttonHint = this.m_DemisePanel.GetChild(1).GetChild(3).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 1;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint = this.m_DemisePanel.GetChild(1).GetChild(4).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 2;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		component2 = this.m_DemisePanel.GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 209;
		component2 = this.m_DemisePanel.GetChild(2).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 209;
		component = this.m_DemisePanel.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(4u);
		component7 = this.m_DemisePanel.GetChild(2).GetChild(0).GetComponent<CustomImage>();
		component7.hander = GUIManager.Instance;
		this.m_DemiseBtn = this.m_DemisePanel.GetChild(2).GetChild(1).GetComponent<UIButton>();
		this.m_DemiseBtn.m_Handler = this;
		this.m_DemiseBtn.m_BtnID1 = 207;
		component = this.m_DemisePanel.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(3u);
		component7 = this.m_DemisePanel.GetChild(2).GetChild(1).GetComponent<CustomImage>();
		component7.hander = GUIManager.Instance;
		component2 = this.m_DemisePanel.GetChild(2).GetChild(2).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 209;
		component7 = this.m_DemisePanel.GetChild(2).GetChild(2).GetComponent<CustomImage>();
		component7.hander = GUIManager.Instance;
		this.m_DemiseTittle = this.m_DemisePanel.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.m_DemiseTittle.font = ttffont;
		this.m_DemiseTittle.text = DataManager.Instance.mStringTable.GetStringByID(685u);
		this.m_DemiseTittle2 = this.m_DemisePanel.GetChild(3).GetChild(1).GetComponent<UIText>();
		this.m_DemiseTittle2.font = ttffont;
		this.m_DemiseTittle2.text = DataManager.Instance.mStringTable.GetStringByID(16146u);
		this.m_DemisePlayerText = this.m_DemisePanel.GetChild(3).GetChild(2).GetComponent<UIText>();
		this.m_DemisePlayerText.font = ttffont;
		this.m_DemisePowerValueText = this.m_DemisePanel.GetChild(3).GetChild(3).GetComponent<UIText>();
		this.m_DemisePowerValueText.font = ttffont;
		this.m_DemiseInfoText = this.m_DemisePanel.GetChild(3).GetChild(4).GetComponent<UIText>();
		this.m_DemiseInfoText.font = ttffont;
		this.m_DemiseHintImage = this.m_DemisePanel.GetChild(4).GetComponent<Image>();
		this.m_DemiseHintText = this.m_DemisePanel.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.m_DemiseHintText.font = ttffont;
		if (GUIManager.Instance.IsArabic)
		{
			for (int i = 0; i < 4; i++)
			{
				RectTransform component8 = this.m_RankChangePanel.GetChild(4 + i).GetChild(0).GetComponent<RectTransform>();
				Vector2 anchoredPosition2 = component8.anchoredPosition;
				anchoredPosition2.x = 93f;
				component8.anchoredPosition = anchoredPosition2;
				Vector3 localScale3 = component8.localScale;
				localScale3.x = -1f;
				component8.localScale = localScale3;
				component8 = this.m_RankChangePanel.GetChild(4 + i).GetChild(2).GetComponent<RectTransform>();
				anchoredPosition2 = component8.anchoredPosition;
				anchoredPosition2.x = 447f;
				component8.anchoredPosition = anchoredPosition2;
				localScale3 = component8.localScale;
				localScale3.x = -1f;
				component8.localScale = localScale3;
			}
		}
		this.CheckEmptyStr();
		this.SetMgrData();
		List<float> list = new List<float>();
		for (int j = 0; j < this.m_Data.Count; j++)
		{
			if (this.m_Data[j] < 0)
			{
				list.Add(53f);
			}
			else
			{
				list.Add(74f);
			}
		}
		this.m_ScrollPanel = base.transform.GetChild(3).GetComponent<ScrollPanel>();
		this.m_ScrollPanel.IntiScrollPanel(506f, 6f, 0f, list, 10, this);
		this.m_Content = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
		this.m_AllianceMember = DataManager.Instance.RoleAlliance.Member;
		this.m_AllianceApplyMember = DataManager.Instance.RoleAlliance.Applicant;
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06000F1C RID: 3868 RVA: 0x001A8AD4 File Offset: 0x001A6CD4
	public override void OnClose()
	{
		for (int i = 0; i < 10; i++)
		{
			if (this.m_ItemStr[i] != null)
			{
				for (int j = 0; j < this.m_ItemStr[i].Length; j++)
				{
					if (this.m_ItemStr[i][j] != null)
					{
						StringManager.Instance.DeSpawnString(this.m_ItemStr[i][j]);
						this.m_ItemStr[i][j] = null;
					}
				}
			}
		}
		this.m_ItemStr = null;
		if (this.m_DemiseStr != null)
		{
			StringManager.Instance.DeSpawnString(this.m_DemiseStr);
			this.m_DemiseStr = null;
		}
		if (this.m_Expel != null)
		{
			StringManager.Instance.DeSpawnString(this.m_Expel);
			this.m_Expel = null;
		}
		if (this.m_RankName != null)
		{
			StringManager.Instance.DeSpawnString(this.m_RankName);
			this.m_RankName = null;
		}
		if (this.m_RewardCount != null)
		{
			StringManager.Instance.DeSpawnString(this.m_RewardCount);
			this.m_RewardCount = null;
		}
		if (this.m_ManagementName != null)
		{
			StringManager.Instance.DeSpawnString(this.m_ManagementName);
			this.m_ManagementName = null;
		}
		if (this.m_DemisePowerValue != null)
		{
			StringManager.Instance.DeSpawnString(this.m_DemisePowerValue);
			this.m_DemisePowerValue = null;
		}
		if (this.m_AllianceType != eAllianceType.eApply)
		{
			GUIManager.Instance.AllianceListTopIdx = this.m_ScrollPanel.GetTopIdx();
			GUIManager.Instance.AllienceListContentY = this.m_Content.anchoredPosition.y;
			int num = 0;
			while (num < this.m_Group.Length && num < GUIManager.Instance.AllienceListGroupOpen.Length)
			{
				GUIManager.Instance.AllienceListGroupOpen[num] = this.m_Group[num].bOpen;
				num++;
			}
		}
		if (this.bOpenDismissLeader)
		{
			GUIManager.Instance.CloseOKCancelBox();
		}
	}

	// Token: 0x06000F1D RID: 3869 RVA: 0x001A8CC0 File Offset: 0x001A6EC0
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 0)
		{
			if (this.m_AllianceType != eAllianceType.eApply)
			{
				for (int i = 0; i < this.m_Group.Length; i++)
				{
					if (this.bFirstUpdate)
					{
						if (i < GUIManager.Instance.AllienceListGroupOpen.Length)
						{
							this.m_Group[i].bOpen = GUIManager.Instance.AllienceListGroupOpen[i];
						}
					}
					else
					{
						this.m_Group[i].bOpen = true;
					}
				}
			}
			this.SetData();
			if (this.m_AllianceType == eAllianceType.eReward)
			{
				this.UpdateRewardData(this.m_RewardItemID);
			}
			List<float> list = new List<float>();
			for (int j = 0; j < this.m_Data.Count; j++)
			{
				if (this.m_Data[j] < 0)
				{
					list.Add(53f);
				}
				else
				{
					list.Add(74f);
				}
			}
			this.m_ScrollPanel.AddNewDataHeight(list, false, true);
			if (this.m_AllianceType != eAllianceType.eApply && this.bFirstUpdate)
			{
				this.m_ScrollPanel.GoTo(GUIManager.Instance.AllianceListTopIdx, GUIManager.Instance.AllienceListContentY);
				this.bFirstUpdate = false;
			}
			if (this.m_ManagePanel.gameObject.activeSelf)
			{
				for (int k = 0; k < this.m_Data.Count; k++)
				{
					if (this.m_Data[k] >= 0 && this.m_Data[k] < DataManager.Instance.AllianceMember.Length)
					{
						int num = this.m_Data[k];
						if (DataManager.Instance.AllianceMember[num].UserId == this.m_UserID)
						{
							AllianceRank rank = DataManager.Instance.AllianceMember[num].Rank;
							this.SetManagementPanel(rank, k);
							break;
						}
					}
				}
				if (this.m_AllianceMember > DataManager.Instance.RoleAlliance.Member)
				{
					if (this.m_ManagePanel.gameObject.activeSelf && !this.FindUserId(this.m_UserID))
					{
						this.OpenManagement(false, 0);
						this.OpenRankChange(false, 0);
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4750u), 255, true);
					}
				}
				else if (this.m_AllianceMember < DataManager.Instance.RoleAlliance.Member)
				{
				}
			}
			this.m_AllianceMember = DataManager.Instance.RoleAlliance.Member;
			this.CheckEmptyStr();
		}
		else if (arg1 == 1)
		{
			int removeIndex = DataManager.Instance.m_RemoveIndex;
			if (removeIndex >= 0 && removeIndex < this.m_Data.Count)
			{
				this.m_Data.RemoveAt(removeIndex);
				List<float> list2 = new List<float>();
				for (int l = 0; l < this.m_Data.Count; l++)
				{
					list2.Add(74f);
				}
				this.m_ScrollPanel.AddNewDataHeight(list2, false, true);
			}
			this.CheckEmptyStr();
		}
		else if (arg1 == 2)
		{
			if (this.door)
			{
				this.door.CloseMenu(false);
			}
		}
		else if (arg1 == 3)
		{
			if (this.m_SendRewardIdx >= 0 && this.m_SendRewardIdx < this.m_KingGiftInfoData.Length)
			{
				this.m_KingGiftInfoData[this.m_SendRewardIdx] = true;
			}
			List<float> list3 = new List<float>();
			for (int m = 0; m < this.m_Data.Count; m++)
			{
				if (this.m_Data[m] < 0)
				{
					list3.Add(53f);
				}
				else
				{
					list3.Add(74f);
				}
			}
			this.m_ScrollPanel.AddNewDataHeight(list3, false, true);
			this.SetRewardCountText(this.GetGiftCount());
		}
		else if (arg1 == 4)
		{
			this.m_SendRewardIdx = -1;
		}
		else if (arg1 == 5)
		{
			this.SetMgrData();
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(508u), DataManager.Instance.mStringTable.GetStringByID(9531u), DataManager.Instance.mStringTable.GetStringByID(508u), this, 0, 0, false, false, false, false, false);
		}
	}

	// Token: 0x06000F1E RID: 3870 RVA: 0x001A9138 File Offset: 0x001A7338
	public override void UpdateNetwork(byte[] meg)
	{
		List<float> list = new List<float>();
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Alliance)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
					this.RefreshAllianceListText();
				}
			}
			else
			{
				if (DataManager.Instance.RoleAlliance.Id == 0u && this.door)
				{
					this.door.CloseMenu(false);
					return;
				}
				if (DataManager.Instance.RoleAlliance.Member == 0)
				{
					DataManager.Instance.ResetAllianceMemberData();
				}
				else if (this.m_AllianceMember > DataManager.Instance.RoleAlliance.Member)
				{
					this.SetMgrData();
				}
				else if (this.m_AllianceMember < DataManager.Instance.RoleAlliance.Member)
				{
					this.SetMgrData();
				}
				if (this.m_AllianceType == eAllianceType.eApply)
				{
					if (DataManager.Instance.RoleAlliance.Applicant == 0)
					{
						this.m_AllianceApplyMember = DataManager.Instance.RoleAlliance.Applicant;
						DataManager.Instance.ResetAllianceMemberData();
					}
					else if (this.m_AllianceApplyMember != DataManager.Instance.RoleAlliance.Applicant)
					{
						this.m_AllianceApplyMember = DataManager.Instance.RoleAlliance.Applicant;
						this.SetMgrData();
					}
				}
			}
		}
		else
		{
			this.SetMgrData();
		}
	}

	// Token: 0x06000F1F RID: 3871 RVA: 0x001A92A0 File Offset: 0x001A74A0
	public void Refresh_FontTexture()
	{
		UIText component = base.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(4).GetChild(0).GetChild(4).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(4).GetChild(0).GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(4).GetChild(1).GetChild(4).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(4).GetChild(1).GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(4).GetChild(1).GetChild(6).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(4).GetChild(1).GetChild(7).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(4).GetChild(1).GetChild(8).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(4).GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(5).GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(5).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(5).GetChild(4).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(5).GetChild(5).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(5).GetChild(6).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(5).GetChild(7).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(5).GetChild(8).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(6).GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(6).GetChild(2).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(6).GetChild(3).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(6).GetChild(4).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(6).GetChild(5).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(6).GetChild(6).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(6).GetChild(7).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(6).GetChild(8).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(7).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		if (this.m_DemiseTittle != null && this.m_DemiseTittle.enabled)
		{
			this.m_DemiseTittle.enabled = false;
			this.m_DemiseTittle.enabled = true;
		}
		if (this.m_DemiseTittle2 != null && this.m_DemiseTittle2.enabled)
		{
			this.m_DemiseTittle2.enabled = false;
			this.m_DemiseTittle2.enabled = true;
		}
		if (this.m_DemisePlayerText != null && this.m_DemisePlayerText.enabled)
		{
			this.m_DemisePlayerText.enabled = false;
			this.m_DemisePlayerText.enabled = true;
		}
		if (this.m_DemisePowerValueText != null && this.m_DemisePowerValueText.enabled)
		{
			this.m_DemisePowerValueText.enabled = false;
			this.m_DemisePowerValueText.enabled = true;
		}
		if (this.m_DemiseInfoText != null && this.m_DemiseInfoText.enabled)
		{
			this.m_DemiseInfoText.enabled = false;
			this.m_DemiseInfoText.enabled = true;
		}
		if (this.m_DemiseHintText != null && this.m_DemiseHintText.enabled)
		{
			this.m_DemiseHintText.enabled = false;
			this.m_DemiseHintText.enabled = true;
		}
		if (this.m_DemiseHIbtn != null && this.m_DemiseHIbtn.enabled)
		{
			this.m_DemiseHIbtn.Refresh_FontTexture();
		}
	}

	// Token: 0x06000F20 RID: 3872 RVA: 0x001A9AB8 File Offset: 0x001A7CB8
	public void RefreshAllianceListText()
	{
		if (this.m_AllianceListText != null)
		{
			for (int i = 0; i < this.m_AllianceListText.Length; i++)
			{
				if (this.m_AllianceListText[i].BtnText1 != null && this.m_AllianceListText[i].BtnText1.enabled)
				{
					this.m_AllianceListText[i].BtnText1.enabled = false;
					this.m_AllianceListText[i].BtnText1.enabled = true;
				}
				if (this.m_AllianceListText[i].BtnText2 != null && this.m_AllianceListText[i].BtnText2.enabled)
				{
					this.m_AllianceListText[i].BtnText2.enabled = false;
					this.m_AllianceListText[i].BtnText2.enabled = true;
				}
				if (this.m_AllianceListText[i].KillNum != null && this.m_AllianceListText[i].KillNum.enabled)
				{
					this.m_AllianceListText[i].KillNum.enabled = false;
					this.m_AllianceListText[i].KillNum.enabled = true;
				}
				if (this.m_AllianceListText[i].LeaveTime != null && this.m_AllianceListText[i].LeaveTime.enabled)
				{
					this.m_AllianceListText[i].LeaveTime.enabled = false;
					this.m_AllianceListText[i].LeaveTime.enabled = true;
				}
				if (this.m_AllianceListText[i].Name != null && this.m_AllianceListText[i].Name.enabled)
				{
					this.m_AllianceListText[i].Name.enabled = false;
					this.m_AllianceListText[i].Name.enabled = true;
				}
				if (this.m_AllianceListText[i].Power != null && this.m_AllianceListText[i].Power.enabled)
				{
					this.m_AllianceListText[i].Power.enabled = false;
					this.m_AllianceListText[i].Power.enabled = true;
				}
			}
		}
		if (this.m_TempUIHIBtn != null)
		{
			for (int j = 0; j < this.m_TempUIHIBtn.Length; j++)
			{
				if (this.m_TempUIHIBtn[j] != null && this.m_TempUIHIBtn[j].enabled)
				{
					this.m_TempUIHIBtn[j].Refresh_FontTexture();
				}
			}
		}
	}

	// Token: 0x06000F21 RID: 3873 RVA: 0x001A9DA0 File Offset: 0x001A7FA0
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		eAllianceType allianceType = this.m_AllianceType;
		if (allianceType != eAllianceType.eManagement)
		{
			if (allianceType != eAllianceType.eApply)
			{
			}
		}
		else if (bOK)
		{
			if (arg1 == 1)
			{
				if (arg2 < this.m_Data.Count && this.m_Data[arg2] < DataManager.Instance.m_RecvDataIdx)
				{
					this.m_Expel.ClearString();
					StringManager.Instance.StringToFormat(DataManager.Instance.AllianceMember[this.m_Data[arg2]].Name);
					this.m_Expel.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4772u));
					GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(4768u), this.m_Expel.ToString(), 2, arg2, DataManager.Instance.mStringTable.GetStringByID(4774u), DataManager.Instance.mStringTable.GetStringByID(4773u));
				}
			}
			else if (arg1 == 2)
			{
				if (arg2 < this.m_Data.Count && this.m_Data[arg2] < DataManager.Instance.m_RecvDataIdx)
				{
					DataManager.Instance.m_RemoveIndex = arg1;
					DataManager.Instance.SendAllianceQuitMember(DataManager.Instance.AllianceMember[this.m_Data[arg2]].UserId);
					this.OpenManagement(false, 0);
				}
			}
			else if (arg1 == 3)
			{
				if (bOK)
				{
					if (this.m_Data[1] >= 0 && this.m_Data[1] < DataManager.Instance.AllianceMember.Length)
					{
						if (2000u > DataManager.Instance.RoleAttr.Diamond)
						{
							GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3966u), DataManager.Instance.mStringTable.GetStringByID(646u), DataManager.Instance.mStringTable.GetStringByID(3968u), this, 4, 0, true, false, false, false, false);
						}
						else if (!GUIManager.Instance.OpenCheckCrystal(2000u, 7, this.m_Data[1], -1))
						{
							DataManager.Instance.SendAllanceDismissLeader(DataManager.Instance.AllianceMember[this.m_Data[1]].UserId);
						}
					}
					this.bOpenDismissLeader = false;
				}
			}
			else if (arg1 == 4)
			{
				MallManager.Instance.Send_Mall_Info();
			}
		}
	}

	// Token: 0x06000F22 RID: 3874 RVA: 0x001AA040 File Offset: 0x001A8240
	public override bool OnBackButtonClick()
	{
		switch (this.m_AllianceType)
		{
		case eAllianceType.eDemise:
			return false;
		}
		return false;
	}

	// Token: 0x06000F23 RID: 3875 RVA: 0x001AA078 File Offset: 0x001A8278
	public void OpenManagement(bool bOpen, int dataIdx = 0)
	{
		if (dataIdx < this.m_Data.Count)
		{
			int num = this.m_Data[dataIdx];
			if (num >= 0 && num < DataManager.Instance.AllianceMember.Length)
			{
				this.m_SeletUserId = DataManager.Instance.AllianceMember[num].UserId;
				this.m_ManagePanelNameText.text = DataManager.Instance.AllianceMember[num].Name;
				this.m_ManagePanelIdx = dataIdx;
				this.SetManagementPanel(DataManager.Instance.AllianceMember[num].Rank, dataIdx);
			}
			if (bOpen)
			{
				this.m_ManagePanelGiftTf.gameObject.SetActive(this.ShowGiftBtn());
				this.m_ManagementName.ClearString();
				this.m_ManagementName.Append(DataManager.Instance.AllianceMember[num].Name);
			}
		}
		this.m_ManagePanel.gameObject.SetActive(bOpen);
	}

	// Token: 0x06000F24 RID: 3876 RVA: 0x001AA174 File Offset: 0x001A8374
	public void OpenRankChange(bool bOpen, int dataIdx = 0)
	{
		this.m_RankChangePanel.gameObject.SetActive(bOpen);
		if (dataIdx < this.m_Data.Count)
		{
			int num = this.m_Data[dataIdx];
			if (num >= 0 && num < DataManager.Instance.AllianceMember.Length)
			{
				this.SetSelectRank((int)DataManager.Instance.AllianceMember[num].Rank);
				this.SetRankChangePanel(num);
			}
		}
	}

	// Token: 0x06000F25 RID: 3877 RVA: 0x001AA1EC File Offset: 0x001A83EC
	public void SetManagementPanel(AllianceRank otherRank, int dataIdx)
	{
		UIButton component = this.m_ManagePanel.GetChild(5).GetComponent<UIButton>();
		UIButton component2 = this.m_ManagePanel.GetChild(6).GetComponent<UIButton>();
		UIButton component3 = this.m_ManagePanel.GetChild(7).GetComponent<UIButton>();
		UIButton component4 = this.m_ManagePanel.GetChild(8).GetComponent<UIButton>();
		UIButton component5 = this.m_ManagePanel.GetChild(10).GetComponent<UIButton>();
		UIButton component6 = this.m_ManagePanel.GetChild(11).GetComponent<UIButton>();
		AllianceRank rank = DataManager.Instance.RoleAlliance.Rank;
		this.m_UserID = DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId;
		component.m_BtnID2 = dataIdx;
		component2.m_BtnID2 = dataIdx;
		this.m_ManagePanelRankImage.sprite = this.m_SpritesArray.GetSprite((int)((byte)(otherRank + 1)));
		if (rank > otherRank && rank > AllianceRank.RANK2)
		{
			component3.ForTextChange(e_BtnType.e_Normal);
			component3.m_BtnID2 = dataIdx;
		}
		else
		{
			component3.ForTextChange(e_BtnType.e_ChangeText);
			component3.m_BtnID2 = 200;
		}
		if (rank >= AllianceRank.RANK4 && rank > otherRank)
		{
			component4.ForTextChange(e_BtnType.e_Normal);
			component4.m_BtnID2 = dataIdx;
		}
		else
		{
			component4.ForTextChange(e_BtnType.e_ChangeText);
			component4.m_BtnID2 = 200;
		}
		component5.m_BtnID2 = dataIdx;
		int num = this.IsTimeToRecall();
		if (this.IsKingOrConqueror())
		{
			component6.ForTextChange(e_BtnType.e_ChangeText);
			component6.m_BtnID2 = 201;
		}
		else if (num != 0)
		{
			component6.ForTextChange(e_BtnType.e_ChangeText);
			if (rank == AllianceRank.RANK1 || rank == AllianceRank.RANK2)
			{
				component6.m_BtnID2 = num;
			}
			else if (rank == AllianceRank.RANK3 || rank == AllianceRank.RANK4)
			{
				component6.m_BtnID2 = num;
			}
		}
		else
		{
			component6.ForTextChange(e_BtnType.e_Normal);
			component6.m_BtnID2 = dataIdx;
		}
		if (this.ShowCanonizedBtnByTableID() > 0)
		{
			this.SetManagementPos(eManagementType.IsKing);
		}
		else if (otherRank == AllianceRank.RANK5)
		{
			this.SetManagementPos(eManagementType.CanRecall);
		}
		else
		{
			this.SetManagementPos(eManagementType.Normal);
		}
	}

	// Token: 0x06000F26 RID: 3878 RVA: 0x001AA3F4 File Offset: 0x001A85F4
	private void SetManagementPos(eManagementType Type)
	{
		float[] array = new float[]
		{
			-17f,
			197f,
			128.5f,
			130f,
			124f,
			36.5f,
			-36.5f,
			-109.5f,
			-182.5f,
			195.5f,
			-233f,
			61f
		};
		float[] array2 = new float[]
		{
			-21f,
			222f,
			153f,
			154f,
			149f,
			-12f,
			-85f,
			-158f,
			-233f,
			220f,
			-233f,
			61f
		};
		float[] array3 = new float[]
		{
			-21f,
			222f,
			153f,
			154f,
			149f,
			61f,
			-12f,
			-85f,
			-158f,
			220f,
			-233f,
			61f
		};
		RectTransform rectTransform;
		Vector2 vector;
		for (int i = 0; i < 12; i++)
		{
			rectTransform = this.m_ManagePanel.GetChild(i).GetComponent<RectTransform>();
			vector = rectTransform.anchoredPosition;
			if (Type == eManagementType.IsKing)
			{
				vector.y = array3[i];
			}
			else if (Type == eManagementType.CanRecall)
			{
				vector.y = array2[i];
			}
			else
			{
				vector.y = array[i];
			}
			rectTransform.anchoredPosition = vector;
		}
		rectTransform = this.m_ManagePanel.GetChild(0).GetComponent<Image>().rectTransform;
		vector = rectTransform.sizeDelta;
		if (Type == eManagementType.IsKing)
		{
			vector.y = 550f;
			this.m_ManagePanel.GetChild(10).gameObject.SetActive(true);
			this.m_ManagePanel.GetChild(11).gameObject.SetActive(false);
		}
		else if (Type == eManagementType.CanRecall)
		{
			vector.y = 550f;
			this.m_ManagePanel.GetChild(10).gameObject.SetActive(false);
			this.m_ManagePanel.GetChild(11).gameObject.SetActive(true);
		}
		else if (Type == eManagementType.Normal)
		{
			vector.y = 476f;
			this.m_ManagePanel.GetChild(10).gameObject.SetActive(false);
			this.m_ManagePanel.GetChild(11).gameObject.SetActive(false);
		}
		rectTransform.sizeDelta = vector;
	}

	// Token: 0x06000F27 RID: 3879 RVA: 0x001AA5A8 File Offset: 0x001A87A8
	public void SetRankChangePanel(int mgrDataIdx)
	{
		if (mgrDataIdx >= DataManager.Instance.m_RecvDataIdx || mgrDataIdx < 0)
		{
			return;
		}
		this.m_RankChangePanelIdx = mgrDataIdx;
		UIButton component = this.m_RankChangePanel.GetChild(4).GetComponent<UIButton>();
		UIButton component2 = this.m_RankChangePanel.GetChild(5).GetComponent<UIButton>();
		UIButton component3 = this.m_RankChangePanel.GetChild(6).GetComponent<UIButton>();
		UIButton component4 = this.m_RankChangePanel.GetChild(7).GetComponent<UIButton>();
		AllianceRank rank = DataManager.Instance.RoleAlliance.Rank;
		AllianceRank rank2 = DataManager.Instance.AllianceMember[mgrDataIdx].Rank;
		this.m_RankName.ClearString();
		this.m_RankName.StringToFormat(DataManager.Instance.AllianceMember[mgrDataIdx].Name);
		this.m_RankName.IntToFormat((long)rank2, 1, false);
		this.m_RankName.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4761u));
		this.m_RankChangePanelNameText.text = this.m_RankName.ToString();
		this.m_RankChangePanelNameText.SetAllDirty();
		this.m_RankChangePanelNameText.cachedTextGenerator.Invalidate();
		if (rank > AllianceRank.RANK4)
		{
			component.ForTextChange(e_BtnType.e_Normal);
			component.m_BtnID2 = 100;
		}
		else
		{
			component.ForTextChange(e_BtnType.e_ChangeText);
			component.m_BtnID2 = 200;
		}
		if (rank > AllianceRank.RANK3)
		{
			component2.ForTextChange(e_BtnType.e_Normal);
			component2.m_BtnID2 = 100;
		}
		else
		{
			component2.ForTextChange(e_BtnType.e_ChangeText);
			component2.m_BtnID2 = 200;
		}
		if (rank > AllianceRank.RANK2)
		{
			component3.ForTextChange(e_BtnType.e_Normal);
			component3.m_BtnID2 = 100;
		}
		else
		{
			component3.ForTextChange(e_BtnType.e_ChangeText);
			component3.m_BtnID2 = 200;
		}
		if (rank > AllianceRank.RANK1)
		{
			component4.ForTextChange(e_BtnType.e_Normal);
			component4.m_BtnID2 = 100;
		}
		else
		{
			component4.ForTextChange(e_BtnType.e_ChangeText);
			component4.m_BtnID2 = 200;
		}
	}

	// Token: 0x06000F28 RID: 3880 RVA: 0x001AA78C File Offset: 0x001A898C
	public void SetSelectRank(int RankLv)
	{
		this.m_SelectRankLv = RankLv;
		for (int i = 0; i < this.m_RankChangePanelCheckImages.Length; i++)
		{
			if (this.m_RankChangePanelCheckImages[i].gameObject.activeSelf)
			{
				this.m_RankChangePanelCheckImages[i].gameObject.SetActive(false);
			}
			this.m_RankChangePanelBtnImages[i].sprite = this.m_SpritesArray.GetSprite(7);
		}
		if (this.m_SelectRankLv < 5)
		{
			this.m_RankChangePanelCheckImages[this.m_SelectRankLv - 1].gameObject.SetActive(true);
			this.m_RankChangePanelBtnImages[this.m_SelectRankLv - 1].sprite = this.m_SpritesArray.GetSprite(8);
		}
		this.m_Rank = (AllianceRank)RankLv;
	}

	// Token: 0x06000F29 RID: 3881 RVA: 0x001AA84C File Offset: 0x001A8A4C
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID2;
		int btnID2 = sender.m_BtnID1;
		switch (btnID2)
		{
		case 201:
			if (sender.m_BtnID2 == 200)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753u), 255, true);
			}
			else
			{
				this.SetSelectRank(4);
				this.m_Rank = AllianceRank.RANK4;
			}
			break;
		case 202:
			if (sender.m_BtnID2 == 200)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753u), 255, true);
			}
			else
			{
				this.SetSelectRank(3);
				this.m_Rank = AllianceRank.RANK3;
			}
			break;
		case 203:
			if (sender.m_BtnID2 == 200)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753u), 255, true);
			}
			else
			{
				this.SetSelectRank(2);
				this.m_Rank = AllianceRank.RANK2;
			}
			break;
		case 204:
			if (sender.m_BtnID2 == 200)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753u), 255, true);
			}
			else
			{
				this.SetSelectRank(1);
				this.m_Rank = AllianceRank.RANK1;
			}
			break;
		case 205:
			if (this.m_RankChangePanelIdx < DataManager.Instance.m_RecvDataIdx && this.m_RankChangePanelIdx >= 0)
			{
				if (DataManager.Instance.AllianceMember[this.m_RankChangePanelIdx].UserId == this.m_UserID && DataManager.Instance.AllianceMember[this.m_RankChangePanelIdx].Rank == this.m_Rank)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(797u), 255, true);
				}
				else
				{
					DataManager.Instance.SendAllianceModifyRank(this.m_UserID, this.m_Rank);
					this.OpenManagement(false, 0);
					this.OpenRankChange(false, 0);
				}
			}
			break;
		case 206:
			this.OpenRankChange(false, 0);
			break;
		case 207:
			this.OpneDemiseOKCancel(true);
			break;
		case 208:
			DataManager.Instance.SendAllianceStepDown(this.m_UserID);
			break;
		case 209:
			this.OpneDemiseOKCancel(false);
			break;
		default:
			switch (btnID2)
			{
			case 101:
				if (this.m_ManagePanelIdx < this.m_Data.Count)
				{
					int num = this.m_Data[this.m_ManagePanelIdx];
					if (num >= 0 && num < DataManager.Instance.AllianceMember.Length && this.m_ManagementName != null)
					{
						GUIManager.Instance.OpenSendGiftUI(DataManager.Instance.RoleAlliance.Tag, this.m_ManagementName);
					}
				}
				break;
			case 102:
				this.OpenManagement(false, 0);
				break;
			case 103:
				if (btnID >= 0 && btnID < this.m_Data.Count && this.m_Data[btnID] >= 0 && this.m_Data[btnID] < DataManager.Instance.m_RecvDataIdx && this.m_Data[btnID] >= 0)
				{
					DataManager.Instance.ShowLordProfile(DataManager.Instance.AllianceMember[this.m_Data[btnID]].Name);
				}
				break;
			case 104:
				if (this.door && this.m_Data[btnID] >= 0 && this.m_Data[btnID] < DataManager.Instance.AllianceMember.Length)
				{
					DataManager.Instance.Letter_ReplyName = DataManager.Instance.AllianceMember[this.m_Data[btnID]].Name;
					this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 2, 0, false);
				}
				break;
			case 105:
				if (sender.m_BtnID2 == 200)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753u), 255, true);
				}
				else
				{
					this.OpenRankChange(true, this.m_ManagePanelIdx);
				}
				break;
			case 106:
				if (sender.m_BtnID2 == 200)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753u), 255, true);
				}
				else if (btnID < this.m_Data.Count && this.m_Data[btnID] < DataManager.Instance.m_RecvDataIdx && this.m_Data[btnID] >= 0)
				{
					this.m_Expel.ClearString();
					StringManager.Instance.StringToFormat(DataManager.Instance.AllianceMember[this.m_Data[btnID]].Name);
					this.m_Expel.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4769u));
					GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(4768u), this.m_Expel.ToString(), 1, btnID, DataManager.Instance.mStringTable.GetStringByID(4771u), DataManager.Instance.mStringTable.GetStringByID(4770u));
				}
				break;
			case 107:
				if (btnID >= 0 && btnID < this.m_Data.Count && this.m_Data[btnID] < DataManager.Instance.m_RecvDataIdx && this.m_Data[btnID] >= 0)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.ClearString();
					cstring.StringToFormat(DataManager.Instance.AllianceMember[this.m_Data[btnID]].Name);
					cstring.AppendFormat("{0}");
					byte btnType = this.ShowCanonizedBtnByTableID();
					switch (btnType)
					{
					case 1:
						TitleManager.Instance.OpenTitleSet(cstring);
						break;
					case 2:
						TitleManager.Instance.OpenTitleListW(cstring);
						break;
					case 3:
					case 5:
					case 6:
					case 7:
						GUIManager.Instance.OpenCanonizedPanel(cstring, 1, (int)btnType);
						break;
					case 4:
						TitleManager.Instance.OpenNobilityTitleSet(cstring);
						break;
					}
				}
				break;
			case 108:
				if (sender.m_BtnID2 >= 200)
				{
					this.ShowMessage(sender.m_BtnID2);
				}
				else
				{
					int num2;
					if (DataManager.Instance.RoleAlliance.Rank == AllianceRank.RANK1 || DataManager.Instance.RoleAlliance.Rank == AllianceRank.RANK2)
					{
						num2 = 10;
					}
					else
					{
						num2 = 5;
					}
					GUIManager.Instance.MsgStr.ClearString();
					GUIManager.Instance.MsgStr.IntToFormat((long)num2, 1, false);
					GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9530u));
					GUIManager.Instance.OpenSpendWindow_Normal(this, DataManager.Instance.mStringTable.GetStringByID(9529u), GUIManager.Instance.MsgStr.ToString(), 2000, 3, 0, DataManager.Instance.mStringTable.GetStringByID(9537u), false);
					this.bOpenDismissLeader = true;
				}
				break;
			default:
				switch (btnID2)
				{
				case 1:
					if (this.m_AllianceType == eAllianceType.eApply)
					{
						DataManager.Instance.m_RemoveIndex = btnID;
						if (btnID >= 0 && btnID < this.m_Data.Count && this.m_Data[btnID] >= 0 && this.m_Data[btnID] < DataManager.Instance.AllianceMember.Length)
						{
							long userId = DataManager.Instance.AllianceMember[this.m_Data[btnID]].UserId;
							DataManager.Instance.SendAllianceApplyResult(2, userId);
						}
					}
					break;
				case 2:
					if (this.m_AllianceType == eAllianceType.eManagement)
					{
						this.OpenManagement(true, btnID);
					}
					else if (this.m_AllianceType == eAllianceType.eApply)
					{
						DataManager.Instance.m_RemoveIndex = btnID;
						if (btnID >= 0 && btnID < this.m_Data.Count && this.m_Data[btnID] >= 0 && this.m_Data[btnID] < DataManager.Instance.AllianceMember.Length)
						{
							long userId2 = DataManager.Instance.AllianceMember[this.m_Data[btnID]].UserId;
							DataManager.Instance.SendAllianceApplyResult(1, userId2);
						}
					}
					else if (this.m_AllianceType == eAllianceType.eDemise)
					{
						if (btnID >= 0 && btnID < this.m_Data.Count && this.m_Data[btnID] >= 0 && this.m_Data[btnID] < DataManager.Instance.AllianceMember.Length)
						{
							this.m_DemiseName = DataManager.Instance.AllianceMember[this.m_Data[btnID]].Name;
							DataManager.Instance.m_DemiseName = this.m_DemiseName;
							this.m_DemiseMember.Name = this.m_DemiseName;
							this.m_DemiseMember.Power = DataManager.Instance.AllianceMember[this.m_Data[btnID]].Power;
							this.m_DemiseMember.Head = DataManager.Instance.AllianceMember[this.m_Data[btnID]].Head;
							this.m_DemiseMember.Rank = DataManager.Instance.AllianceMember[this.m_Data[btnID]].Rank;
							this.m_UserID = DataManager.Instance.AllianceMember[this.m_Data[btnID]].UserId;
							this.m_DemiseMember.UserId = this.m_UserID;
							this.OpneDemiseOKCancel(true);
						}
					}
					else if (this.m_AllianceType == eAllianceType.ePublicMember)
					{
						if (this.door && btnID >= 0 && btnID < this.m_Data.Count && this.m_Data[btnID] < this.m_Data.Count && this.m_Data[btnID] >= 0)
						{
							DataManager.Instance.Letter_ReplyName = DataManager.Instance.AllianceMember[this.m_Data[btnID]].Name;
							this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 2, 0, false);
						}
					}
					else if (this.m_AllianceType == eAllianceType.eResourceTransport)
					{
						bool flag = GUIManager.Instance.CanResourceTransport();
						if (flag && this.door && btnID >= 0 && btnID < this.m_Data.Count && this.m_Data[btnID] < this.m_Data.Count && this.m_Data[btnID] >= 0)
						{
							DataManager.Instance.AllyMemberIdx = this.m_Data[btnID];
							DataManager.Instance.SendAllyPoint(DataManager.Instance.AllianceMember[this.m_Data[btnID]].Name);
						}
					}
					else if (this.m_AllianceType == eAllianceType.eReinforce)
					{
						bool flag2 = this.door.m_GroundInfo.ReinforceCheck();
						if (flag2 && this.door && btnID >= 0 && btnID < this.m_Data.Count && this.m_Data[btnID] < DataManager.Instance.AllianceMember.Length)
						{
							DataManager.Instance.ReinforceCheckType = eReinforceCheck.OpenReinforce_NoLoc;
							DataManager.Instance.m_InForceName = DataManager.Instance.AllianceMember[this.m_Data[btnID]].Name;
							DataManager.Instance.SendAllyInforceInfo(DataManager.Instance.m_InForceName);
						}
					}
					else if (this.m_AllianceType == eAllianceType.eReward)
					{
						if (btnID >= 0 && btnID < this.m_Data.Count && this.m_Data[btnID] < DataManager.Instance.AllianceMember.Length)
						{
							this.m_SendRewardIdx = this.m_Data[btnID];
							byte giftCount = this.GetGiftCount();
							if (DataManager.MapDataController.FocusKingdomID == ActivityManager.Instance.KOWKingdomID)
							{
								if (DataManager.Instance.KingGift.WonderID == 0 && DataManager.MapDataController.CheckWorldKingFunction(eWorldKingFunction.eReward))
								{
									if (giftCount > 0)
									{
										if (DataManager.MapDataController.OtherKingdomData.kingdomID == ActivityManager.Instance.KOWKingdomID)
										{
											DataManager.Instance.KingGift.SendKingGift(DataManager.Instance.AllianceMember[this.m_Data[btnID]].UserId, this.m_RewardItemID, true, false);
										}
										else
										{
											DataManager.Instance.KingGift.SendKingGift(DataManager.Instance.AllianceMember[this.m_Data[btnID]].UserId, this.m_RewardItemID, true, true);
										}
									}
									else
									{
										GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(744u), 255, true);
									}
								}
								else if (DataManager.MapDataController.CheckNobilityFunction(eNobilityFunction.eReward, DataManager.Instance.KingGift.WonderID))
								{
									if (giftCount > 0)
									{
										if (DataManager.MapDataController.OtherKingdomData.kingdomID == ActivityManager.Instance.KOWKingdomID)
										{
											DataManager.Instance.KingGift.SendNobilityGift(DataManager.Instance.AllianceMember[this.m_Data[btnID]].UserId, this.m_RewardItemID, false);
										}
										else
										{
											DataManager.Instance.KingGift.SendNobilityGift(DataManager.Instance.AllianceMember[this.m_Data[btnID]].UserId, this.m_RewardItemID, true);
										}
									}
									else
									{
										GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(744u), 255, true);
									}
								}
							}
							else if (giftCount > 0)
							{
								if (DataManager.MapDataController.CheckKingFunction(eKingFunction.eReward))
								{
									DataManager.Instance.KingGift.SendKingGift(DataManager.Instance.AllianceMember[this.m_Data[btnID]].UserId, this.m_RewardItemID, false, false);
								}
							}
							else
							{
								GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(744u), 255, true);
							}
						}
					}
					else if (this.m_AllianceType == eAllianceType.eAmbush && this.door && this.door.m_GroundInfo.CheckMarchEventDataCount() && btnID >= 0 && btnID < this.m_Data.Count && this.m_Data[btnID] < DataManager.Instance.AllianceMember.Length)
					{
						AmbushManager.Instance.SendAllyAmbushInfo(DataManager.Instance.AllianceMember[this.m_Data[btnID]].Name);
					}
					break;
				case 3:
					if (this.door)
					{
						this.door.CloseMenu(false);
					}
					break;
				case 4:
					switch (this.m_AllianceType)
					{
					case eAllianceType.eManagement:
					case eAllianceType.ePublicMember:
					case eAllianceType.eResourceTransport:
					case eAllianceType.eReinforce:
					case eAllianceType.eAmbush:
						if (this.door)
						{
							this.door.OpenMenu(EGUIWindow.UI_Alliance_Permission, 0, 0, false);
						}
						break;
					case eAllianceType.eApply:
						GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(4741u), DataManager.Instance.mStringTable.GetStringByID(800u), null, null, 0, 0, true, true);
						break;
					case eAllianceType.eDemise:
						GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(4744u), DataManager.Instance.mStringTable.GetStringByID(798u), null, null, 0, 0, true, true);
						break;
					}
					break;
				}
				break;
			}
			break;
		}
	}

	// Token: 0x06000F2A RID: 3882 RVA: 0x001AB8FC File Offset: 0x001A9AFC
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		AllianceMemberClientDataType[] allianceMember = DataManager.Instance.AllianceMember;
		if (dataIdx < this.m_Data.Count && panelObjectIdx < this.m_AllianceListText.Length)
		{
			if (this.m_Data[dataIdx] < 0)
			{
				item.GetComponent<RectTransform>().sizeDelta = new Vector2(829f, 53f);
				int num = Mathf.Abs(this.m_Data[dataIdx]) - 1;
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				if (this.m_ItemStr[panelObjectIdx] == null)
				{
					this.m_ItemStr[panelObjectIdx] = new CString[10];
				}
				if (this.m_ItemStr[panelObjectIdx][0] == null)
				{
					this.m_ItemStr[panelObjectIdx][0] = StringManager.Instance.SpawnString(4);
				}
				this.m_ItemStr[panelObjectIdx][0].ClearString();
				StringManager.Instance.IntToFormat((long)(num + 1), 1, false);
				this.m_ItemStr[panelObjectIdx][0].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4738u));
				this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4738u), num + 1);
				UIText component = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component.text = this.m_ItemStr[panelObjectIdx][0].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				item.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = this.m_SpritesArray.GetSprite(num + 2);
				if (this.m_ItemStr[panelObjectIdx] == null)
				{
					this.m_ItemStr[panelObjectIdx] = new CString[10];
				}
				if (this.m_ItemStr[panelObjectIdx][1] == null)
				{
					this.m_ItemStr[panelObjectIdx][1] = StringManager.Instance.SpawnString(2);
				}
				this.m_ItemStr[panelObjectIdx][1].ClearString();
				StringManager.Instance.IntToFormat((long)this.m_Group[num].Count, 1, false);
				this.m_ItemStr[panelObjectIdx][1].AppendFormat("{0}");
				component = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component.text = this.m_ItemStr[panelObjectIdx][1].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				if (this.m_Group[num].bOpen && this.m_Group[num].Count > 0)
				{
					item.transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = this.m_SpritesArray.GetSprite(0);
				}
				else
				{
					item.transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = this.m_SpritesArray.GetSprite(1);
				}
			}
			else
			{
				item.GetComponent<RectTransform>().sizeDelta = new Vector2(829f, 74f);
				item.transform.GetChild(1).gameObject.SetActive(true);
				item.transform.GetChild(0).gameObject.SetActive(false);
				UIHIBtn component2 = item.transform.GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
				ushort head = DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].Head;
				int num = (int)DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].Rank;
				GUIManager.Instance.ChangeHeroItemImg(component2.transform, eHeroOrItem.Hero, head, 11, 0, 0);
				Image component3 = item.transform.GetChild(1).GetChild(1).GetComponent<Image>();
				if (this.m_AllianceType != eAllianceType.eApply)
				{
					component3.sprite = this.m_SpritesArray.GetSprite(num + 1);
					component3.gameObject.SetActive(true);
				}
				else
				{
					component3.gameObject.SetActive(false);
				}
				if (this.m_ItemStr[panelObjectIdx] == null)
				{
					this.m_ItemStr[panelObjectIdx] = new CString[10];
				}
				if (this.m_ItemStr[panelObjectIdx][5] == null)
				{
					this.m_ItemStr[panelObjectIdx][5] = StringManager.Instance.SpawnString(200);
				}
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.ClearString();
				if ((this.m_AllianceType == eAllianceType.eManagement || this.m_AllianceType == eAllianceType.eResourceTransport || this.m_AllianceType == eAllianceType.eReinforce || this.m_AllianceType == eAllianceType.eReward) && DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].NickName != null && DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].NickName.Length != 0)
				{
					cstring.StringToFormat(DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].NickName);
					cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9097u));
				}
				CString cstring2 = StringManager.Instance.StaticString1024();
				cstring2.Append(DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].Name);
				GameConstants.FormatRoleName(this.m_ItemStr[panelObjectIdx][5], cstring2, null, cstring, 0, 0, null, null, null, null);
				UIText component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
				component.SetCheckArabic(true);
				component.text = this.m_ItemStr[panelObjectIdx][5].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.m_AllianceListText[panelObjectIdx].Name = component;
				if (this.m_ItemStr[panelObjectIdx] == null)
				{
					this.m_ItemStr[panelObjectIdx] = new CString[10];
				}
				if (this.m_ItemStr[panelObjectIdx][2] == null)
				{
					this.m_ItemStr[panelObjectIdx][2] = StringManager.Instance.SpawnString(20);
				}
				this.m_ItemStr[panelObjectIdx][2].ClearString();
				StringManager.Instance.uLongToFormat(DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].Power, 1, true);
				this.m_ItemStr[panelObjectIdx][2].AppendFormat("{0}");
				component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
				component.text = this.m_ItemStr[panelObjectIdx][2].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.m_AllianceListText[panelObjectIdx].Power = component;
				if (this.m_ItemStr[panelObjectIdx] == null)
				{
					this.m_ItemStr[panelObjectIdx] = new CString[10];
				}
				if (this.m_ItemStr[panelObjectIdx][3] == null)
				{
					this.m_ItemStr[panelObjectIdx][3] = StringManager.Instance.SpawnString(20);
				}
				this.m_ItemStr[panelObjectIdx][3].ClearString();
				StringManager.Instance.uLongToFormat(DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].TroopKillNum, 1, true);
				this.m_ItemStr[panelObjectIdx][3].AppendFormat("{0}");
				component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
				component.text = this.m_ItemStr[panelObjectIdx][3].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.m_AllianceListText[panelObjectIdx].KillNum = component;
				component = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
				this.m_AllianceListText[panelObjectIdx].LeaveTime = component;
				long num2 = 0L;
				if (allianceMember[this.m_Data[dataIdx]].LogoutTime != 0L && DataManager.Instance.ServerTime > allianceMember[this.m_Data[dataIdx]].LogoutTime)
				{
					num2 = DataManager.Instance.ServerTime - allianceMember[this.m_Data[dataIdx]].LogoutTime;
				}
				long num3 = 0L;
				long num4 = 0L;
				long num5 = 0L;
				if (num2 > 0L)
				{
					num5 = num2 / 60L;
					num3 = num5 / 60L;
					num4 = (long)Mathf.Clamp((float)(num3 / 24L), 0f, 99f);
				}
				if (this.m_ItemStr[panelObjectIdx] == null)
				{
					this.m_ItemStr[panelObjectIdx] = new CString[10];
				}
				if (this.m_ItemStr[panelObjectIdx][4] == null)
				{
					this.m_ItemStr[panelObjectIdx][4] = StringManager.Instance.SpawnString(200);
				}
				this.m_ItemStr[panelObjectIdx][4].ClearString();
				CString cstring3 = StringManager.Instance.StaticString1024();
				if (this.m_AllianceType != eAllianceType.eApply && this.m_AllianceType != eAllianceType.ePublicMember)
				{
					if (num4 > 0L)
					{
						cstring3.ClearString();
						if (GUIManager.Instance.IsArabic)
						{
							cstring3.IntToFormat(num4, 1, false);
							cstring3.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4739u));
							cstring3.AppendFormat("{0} {1}");
						}
						else
						{
							cstring3.IntToFormat(num4, 1, false);
							cstring3.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4739u));
						}
						this.m_ItemStr[panelObjectIdx][4].StringToFormat(cstring3);
						this.m_ItemStr[panelObjectIdx][4].AppendFormat("<color=#B4BEC1>{0}</color>");
						component.text = this.m_ItemStr[panelObjectIdx][4].ToString();
						component.gameObject.SetActive(true);
					}
					else if (num3 > 0L)
					{
						cstring3.ClearString();
						if (GUIManager.Instance.IsArabic)
						{
							cstring3.IntToFormat(num3, 1, false);
							cstring3.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(450u));
							cstring3.AppendFormat("{0} {1}");
						}
						else
						{
							cstring3.IntToFormat(num3, 1, false);
							cstring3.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(450u));
						}
						this.m_ItemStr[panelObjectIdx][4].StringToFormat(cstring3);
						this.m_ItemStr[panelObjectIdx][4].AppendFormat("<color=#B4BEC1>{0}</color>");
						component.text = this.m_ItemStr[panelObjectIdx][4].ToString();
						component.gameObject.SetActive(true);
					}
					else if (num5 > 0L)
					{
						cstring3.ClearString();
						if (GUIManager.Instance.IsArabic)
						{
							cstring3.IntToFormat(num5, 1, false);
							cstring3.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(447u));
							cstring3.AppendFormat("{0} {1}");
						}
						else
						{
							cstring3.IntToFormat(num5, 1, false);
							cstring3.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(447u));
						}
						this.m_ItemStr[panelObjectIdx][4].StringToFormat(cstring3);
						this.m_ItemStr[panelObjectIdx][4].AppendFormat("<color=#B4BEC1>{0}</color>");
						component.text = this.m_ItemStr[panelObjectIdx][4].ToString();
						component.gameObject.SetActive(true);
					}
					else
					{
						component.gameObject.SetActive(false);
					}
					component.SetAllDirty();
					component.cachedTextGenerator.Invalidate();
				}
				this.m_AllianceListText[panelObjectIdx].BtnText1 = item.transform.GetChild(1).GetChild(8).GetChild(0).GetComponent<UIText>();
				this.m_AllianceListText[panelObjectIdx].BtnText2 = item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>();
				if (this.m_AllianceType == eAllianceType.eManagement)
				{
					UIButton component4 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 1;
					component4.m_BtnID2 = dataIdx;
					component4.gameObject.SetActive(false);
					item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(4740u);
					component4 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 2;
					component4.m_BtnID2 = dataIdx;
					RectTransform component5 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
					component5.anchoredPosition = new Vector2(240.5f, component5.anchoredPosition.y);
					component5.sizeDelta = new Vector2(169f, 61f);
					if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId)
					{
						component4.gameObject.SetActive(false);
					}
					else
					{
						component4.gameObject.SetActive(true);
					}
					float[] array = new float[]
					{
						33f,
						98f,
						108f,
						303f,
						139f,
						139f,
						333f,
						480f,
						157.5f,
						320f
					};
					RectTransform component6;
					Vector2 vector;
					for (int i = 0; i < array.Length; i++)
					{
						component6 = item.transform.GetChild(1).GetChild(i).GetComponent<RectTransform>();
						vector = component6.anchoredPosition;
						vector.x = array[i];
						component6.anchoredPosition = vector;
					}
					if (GUIManager.Instance.IsArabic)
					{
						component6 = item.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
						vector = component6.anchoredPosition;
						vector.x = 134f;
						component6.anchoredPosition = vector;
					}
					component6 = item.transform.GetChild(1).GetChild(4).GetComponent<RectTransform>();
					vector = component6.sizeDelta;
					vector.x = 500f;
					component6.sizeDelta = vector;
					component6 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
					vector = component6.anchoredPosition;
					vector.x = 312f;
					component6.anchoredPosition = vector;
					component6 = item.transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
					vector = component6.anchoredPosition;
					vector.x = 487.5f;
					vector.y = -43f;
					component6.anchoredPosition = vector;
					vector = component6.sizeDelta;
					vector.x = 143f;
					component6.sizeDelta = vector;
					if (GUIManager.Instance.IsArabic)
					{
						component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
					}
				}
				else if (this.m_AllianceType == eAllianceType.eApply)
				{
					item.transform.GetChild(1).GetChild(8).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(4742u);
					UIButton component4 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 1;
					component4.m_BtnID2 = dataIdx;
					component4.gameObject.SetActive(true);
					item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(4743u);
					component4 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 2;
					component4.m_BtnID2 = dataIdx;
					component4.gameObject.SetActive(true);
				}
				else if (this.m_AllianceType == eAllianceType.eDemise)
				{
					UIButton component4 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 1;
					component4.m_BtnID2 = dataIdx;
					component4.gameObject.SetActive(false);
					item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(4747u);
					component4 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 2;
					component4.m_BtnID2 = dataIdx;
					component4.gameObject.SetActive(true);
					RectTransform component5 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
					component5.anchoredPosition = new Vector2(240.5f, component5.anchoredPosition.y);
					component5.sizeDelta = new Vector2(169f, 61f);
				}
				else if (this.m_AllianceType == eAllianceType.ePublicMember)
				{
					UIButton component4 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 1;
					component4.m_BtnID2 = dataIdx;
					component4.gameObject.SetActive(false);
					item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(4757u);
					component4 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 2;
					component4.m_BtnID2 = dataIdx;
					RectTransform component5 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
					component5.anchoredPosition = new Vector2(240.5f, component5.anchoredPosition.y);
					component5.sizeDelta = new Vector2(169f, 61f);
					if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId)
					{
						component4.gameObject.SetActive(false);
					}
					else
					{
						component4.gameObject.SetActive(true);
					}
					if (GUIManager.Instance.IsArabic)
					{
						RectTransform component7 = item.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
						Vector2 anchoredPosition = component7.anchoredPosition;
						anchoredPosition.x = 146f;
						component7.anchoredPosition = anchoredPosition;
					}
				}
				else if (this.m_AllianceType == eAllianceType.eResourceTransport)
				{
					UIButton component4 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 1;
					component4.m_BtnID2 = dataIdx;
					component4.gameObject.SetActive(false);
					item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(3951u);
					component4 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 2;
					component4.m_BtnID2 = dataIdx;
					RectTransform component5 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
					component5.anchoredPosition = new Vector2(240.5f, component5.anchoredPosition.y);
					component5.sizeDelta = new Vector2(169f, 61f);
					if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId)
					{
						component4.gameObject.SetActive(false);
					}
					else
					{
						component4.gameObject.SetActive(true);
					}
					float[] array2 = new float[]
					{
						33f,
						98f,
						108f,
						303f,
						139f,
						139f,
						333f,
						480f,
						157.5f,
						320f
					};
					RectTransform component8;
					Vector2 vector2;
					for (int j = 0; j < array2.Length; j++)
					{
						component8 = item.transform.GetChild(1).GetChild(j).GetComponent<RectTransform>();
						vector2 = component8.anchoredPosition;
						vector2.x = array2[j];
						component8.anchoredPosition = vector2;
					}
					if (GUIManager.Instance.IsArabic)
					{
						component8 = item.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
						vector2 = component8.anchoredPosition;
						vector2.x = 134f;
						component8.anchoredPosition = vector2;
					}
					component8 = item.transform.GetChild(1).GetChild(4).GetComponent<RectTransform>();
					vector2 = component8.sizeDelta;
					vector2.x = 500f;
					component8.sizeDelta = vector2;
					component8 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
					vector2 = component8.anchoredPosition;
					vector2.x = 312f;
					component8.anchoredPosition = vector2;
					component8 = item.transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
					vector2 = component8.anchoredPosition;
					vector2.x = 487.5f;
					vector2.y = -43f;
					component8.anchoredPosition = vector2;
					vector2 = component8.sizeDelta;
					vector2.x = 143f;
					component8.sizeDelta = vector2;
					if (GUIManager.Instance.IsArabic)
					{
						component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
					}
				}
				else if (this.m_AllianceType == eAllianceType.eReinforce)
				{
					UIButton component4 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 1;
					component4.m_BtnID2 = dataIdx;
					component4.gameObject.SetActive(false);
					item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(4859u);
					component4 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 2;
					component4.m_BtnID2 = dataIdx;
					RectTransform component5 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
					component5.anchoredPosition = new Vector2(240.5f, component5.anchoredPosition.y);
					component5.sizeDelta = new Vector2(169f, 61f);
					if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId)
					{
						component4.gameObject.SetActive(false);
					}
					else
					{
						component4.gameObject.SetActive(true);
					}
					float[] array3 = new float[]
					{
						33f,
						98f,
						108f,
						303f,
						139f,
						139f,
						333f,
						480f,
						157.5f,
						320f
					};
					RectTransform component9;
					Vector2 vector3;
					for (int k = 0; k < array3.Length; k++)
					{
						component9 = item.transform.GetChild(1).GetChild(k).GetComponent<RectTransform>();
						vector3 = component9.anchoredPosition;
						vector3.x = array3[k];
						component9.anchoredPosition = vector3;
					}
					if (GUIManager.Instance.IsArabic)
					{
						component9 = item.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
						vector3 = component9.anchoredPosition;
						vector3.x = 134f;
						component9.anchoredPosition = vector3;
					}
					component9 = item.transform.GetChild(1).GetChild(4).GetComponent<RectTransform>();
					vector3 = component9.sizeDelta;
					vector3.x = 500f;
					component9.sizeDelta = vector3;
					component9 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
					vector3 = component9.anchoredPosition;
					vector3.x = 312f;
					component9.anchoredPosition = vector3;
					component9 = item.transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
					vector3 = component9.anchoredPosition;
					vector3.x = 487.5f;
					vector3.y = -43f;
					component9.anchoredPosition = vector3;
					vector3 = component9.sizeDelta;
					vector3.x = 143f;
					component9.sizeDelta = vector3;
					if (GUIManager.Instance.IsArabic)
					{
						component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
					}
				}
				else if (this.m_AllianceType == eAllianceType.eReward)
				{
					UIButton component4 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 1;
					component4.m_BtnID2 = dataIdx;
					component4.gameObject.SetActive(false);
					item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9712u);
					component4 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 2;
					component4.m_BtnID2 = dataIdx;
					RectTransform component5 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
					component5.anchoredPosition = new Vector2(240.5f, component5.anchoredPosition.y);
					component5.sizeDelta = new Vector2(169f, 61f);
					if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId)
					{
						component4.gameObject.SetActive(false);
						item.transform.GetChild(1).GetChild(10).gameObject.SetActive(false);
					}
					else if (this.IsReward(this.m_Data[dataIdx]))
					{
						component4.gameObject.SetActive(false);
						component = item.transform.GetChild(1).GetChild(10).GetChild(0).GetComponent<UIText>();
						component.text = DataManager.Instance.mStringTable.GetStringByID(9713u);
						item.transform.GetChild(1).GetChild(10).gameObject.SetActive(true);
					}
					else
					{
						component4.gameObject.SetActive(true);
						item.transform.GetChild(1).GetChild(10).gameObject.SetActive(false);
					}
					float[] array4 = new float[]
					{
						33f,
						98f,
						108f,
						303f,
						139f,
						139f,
						333f,
						480f,
						157.5f,
						320f
					};
					RectTransform component10;
					Vector2 vector4;
					for (int l = 0; l < array4.Length; l++)
					{
						component10 = item.transform.GetChild(1).GetChild(l).GetComponent<RectTransform>();
						vector4 = component10.anchoredPosition;
						vector4.x = array4[l];
						component10.anchoredPosition = vector4;
					}
					if (GUIManager.Instance.IsArabic)
					{
						component10 = item.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
						vector4 = component10.anchoredPosition;
						vector4.x = 134f;
						component10.anchoredPosition = vector4;
					}
					component10 = item.transform.GetChild(1).GetChild(4).GetComponent<RectTransform>();
					vector4 = component10.sizeDelta;
					vector4.x = 500f;
					component10.sizeDelta = vector4;
					component10 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
					vector4 = component10.anchoredPosition;
					vector4.x = 312f;
					component10.anchoredPosition = vector4;
					component10 = item.transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
					vector4 = component10.anchoredPosition;
					vector4.x = 487.5f;
					vector4.y = -43f;
					component10.anchoredPosition = vector4;
					vector4 = component10.sizeDelta;
					vector4.x = 143f;
					component10.sizeDelta = vector4;
					if (GUIManager.Instance.IsArabic)
					{
						component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
					}
				}
				else if (this.m_AllianceType == eAllianceType.eAmbush)
				{
					UIButton component4 = item.transform.GetChild(1).GetChild(8).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 1;
					component4.m_BtnID2 = dataIdx;
					component4.gameObject.SetActive(false);
					item.transform.GetChild(1).GetChild(9).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9739u);
					component4 = item.transform.GetChild(1).GetChild(9).GetComponent<UIButton>();
					component4.m_Handler = this;
					component4.m_BtnID1 = 2;
					component4.m_BtnID2 = dataIdx;
					RectTransform component5 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
					component5.anchoredPosition = new Vector2(240.5f, component5.anchoredPosition.y);
					component5.sizeDelta = new Vector2(169f, 61f);
					if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[this.m_Data[dataIdx]].UserId)
					{
						component4.gameObject.SetActive(false);
					}
					else
					{
						component4.gameObject.SetActive(true);
					}
					float[] array5 = new float[]
					{
						33f,
						98f,
						108f,
						303f,
						139f,
						139f,
						333f,
						480f,
						157.5f,
						320f
					};
					RectTransform component11;
					Vector2 vector5;
					for (int m = 0; m < array5.Length; m++)
					{
						component11 = item.transform.GetChild(1).GetChild(m).GetComponent<RectTransform>();
						vector5 = component11.anchoredPosition;
						vector5.x = array5[m];
						component11.anchoredPosition = vector5;
					}
					if (GUIManager.Instance.IsArabic)
					{
						component11 = item.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
						vector5 = component11.anchoredPosition;
						vector5.x = 134f;
						component11.anchoredPosition = vector5;
					}
					component11 = item.transform.GetChild(1).GetChild(4).GetComponent<RectTransform>();
					vector5 = component11.sizeDelta;
					vector5.x = 500f;
					component11.sizeDelta = vector5;
					component11 = item.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
					vector5 = component11.anchoredPosition;
					vector5.x = 312f;
					component11.anchoredPosition = vector5;
					component11 = item.transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
					vector5 = component11.anchoredPosition;
					vector5.x = 487.5f;
					vector5.y = -43f;
					component11.anchoredPosition = vector5;
					vector5 = component11.sizeDelta;
					vector5.x = 143f;
					component11.sizeDelta = vector5;
					if (GUIManager.Instance.IsArabic)
					{
						component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
						component = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
						component.rectTransform.anchoredPosition = component.ArabicFixPos(component.rectTransform.anchoredPosition);
					}
				}
			}
		}
	}

	// Token: 0x06000F2B RID: 3883 RVA: 0x001ADB48 File Offset: 0x001ABD48
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		if (dataIndex < this.m_Data.Count)
		{
			if (this.m_Data[dataIndex] < 0)
			{
				int num = Mathf.Abs(this.m_Data[dataIndex]) - 1;
				if (this.m_Group[num].Count <= 0)
				{
					return;
				}
				if (this.m_Group[num].bOpen)
				{
					this.m_Group[num].bOpen = false;
				}
				else
				{
					this.m_Group[num].bOpen = true;
				}
				this.SetData();
				List<float> list = new List<float>();
				for (int i = 0; i < this.m_Data.Count; i++)
				{
					if (this.m_Data[i] < 0)
					{
						list.Add(53f);
					}
					else
					{
						list.Add(74f);
					}
				}
				this.m_ScrollPanel.AddNewDataHeight(list, false, true);
			}
			else if (dataIndex >= 0 && dataIndex < this.m_Data.Count && this.m_Data[dataIndex] >= 0 && this.m_Data[dataIndex] < DataManager.Instance.m_RecvDataIdx)
			{
				DataManager.Instance.ShowLordProfile(DataManager.Instance.AllianceMember[this.m_Data[dataIndex]].Name);
			}
		}
	}

	// Token: 0x06000F2C RID: 3884 RVA: 0x001ADCC0 File Offset: 0x001ABEC0
	private void SetMgrData()
	{
		switch (this.m_AllianceType)
		{
		case eAllianceType.eManagement:
		case eAllianceType.eResourceTransport:
		case eAllianceType.eReinforce:
		case eAllianceType.eReward:
		case eAllianceType.eAmbush:
		{
			int num = -5;
			for (int i = 0; i < 5; i++)
			{
				this.m_Data.Add(num);
				num++;
				this.m_Group[i].bOpen = false;
			}
			DataManager.Instance.SendAllianceMember();
			break;
		}
		case eAllianceType.eApply:
			DataManager.Instance.SendAllianceApplyMember();
			break;
		case eAllianceType.eDemise:
		{
			int num2 = -5;
			for (int j = 0; j < 5; j++)
			{
				this.m_Data.Add(num2);
				num2++;
				this.m_Group[j].bOpen = false;
			}
			DataManager.Instance.SendAllianceMember();
			break;
		}
		case eAllianceType.ePublicMember:
		{
			int num3 = -5;
			for (int k = 0; k < 5; k++)
			{
				this.m_Data.Add(num3);
				num3++;
				this.m_Group[k].bOpen = false;
				DataManager.Instance.SendAllianceOthorMemberInfo(this.m_AllianceID);
			}
			break;
		}
		}
	}

	// Token: 0x06000F2D RID: 3885 RVA: 0x001ADDF4 File Offset: 0x001ABFF4
	private void SetData()
	{
		switch (this.m_AllianceType)
		{
		case eAllianceType.eManagement:
		case eAllianceType.eResourceTransport:
		case eAllianceType.eReinforce:
		case eAllianceType.eReward:
		case eAllianceType.eAmbush:
			this.SetMenberData();
			break;
		case eAllianceType.eApply:
			this.SetAllianceApplyMember();
			break;
		case eAllianceType.eDemise:
			this.SetDemise();
			break;
		case eAllianceType.ePublicMember:
			this.SetMenberData();
			break;
		}
	}

	// Token: 0x06000F2E RID: 3886 RVA: 0x001ADE60 File Offset: 0x001AC060
	private void SetMenberData()
	{
		this.m_Data.Clear();
		for (int i = 0; i < this.m_Group.Length; i++)
		{
			this.m_Group[i].Count = 0;
		}
		int num = Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
		int num2 = 5;
		int[] array = new int[5];
		int num3 = 0;
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = 1;
		}
		int num4 = 0;
		for (int k = 0; k < num + 5; k++)
		{
			if (k == 0)
			{
				this.m_Data.Add(-num2);
			}
			else
			{
				int num5;
				if (num4 < num)
				{
					num5 = (int)DataManager.Instance.AllianceMember[num4].Rank;
					if (num5 < 1)
					{
						num4++;
						goto IL_161;
					}
				}
				else
				{
					num5 = 1;
				}
				if (num3 < array.Length && array[num3] == 1 && num5 != num2 && num2 != 0)
				{
					num2--;
					this.m_Data.Add(-num2);
					num3++;
				}
				else if (num4 < num)
				{
					if (this.m_Group[num5 - 1].bOpen)
					{
						this.m_Data.Add(num4);
					}
					num4++;
					AllianceGroup[] group = this.m_Group;
					int num6 = num5 - 1;
					group[num6].Count = group[num6].Count + 1;
				}
			}
			IL_161:;
		}
	}

	// Token: 0x06000F2F RID: 3887 RVA: 0x001ADFE0 File Offset: 0x001AC1E0
	private void SetAllianceApplyMember()
	{
		this.m_Data.Clear();
		for (int i = 0; i < this.m_Group.Length; i++)
		{
			this.m_Group[i].Count = 0;
		}
		int recvDataIdx = DataManager.Instance.m_RecvDataIdx;
		for (int j = 0; j < recvDataIdx; j++)
		{
			this.m_Data.Add(j);
		}
	}

	// Token: 0x06000F30 RID: 3888 RVA: 0x001AE04C File Offset: 0x001AC24C
	private void SetDemise()
	{
		this.m_Data.Clear();
		for (int i = 0; i < this.m_Group.Length; i++)
		{
			this.m_Group[i].Count = 0;
		}
		int num = Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
		int num2 = 4;
		int[] array = new int[5];
		int num3 = 1;
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = 1;
		}
		int num4 = 0;
		for (int k = 0; k < num + 4; k++)
		{
			if (k == 0)
			{
				this.m_Data.Add(-num2);
			}
			else
			{
				int num5;
				if (num4 < num)
				{
					num5 = (int)DataManager.Instance.AllianceMember[num4].Rank;
					if (num5 < 1 || num5 == 5)
					{
						num4++;
						goto IL_168;
					}
				}
				else
				{
					num5 = 1;
				}
				if (num3 < array.Length && array[num3] == 1 && num5 != num2 && num2 != 0)
				{
					num2--;
					this.m_Data.Add(-num2);
					num3++;
				}
				else if (num4 < num)
				{
					if (this.m_Group[num5 - 1].bOpen)
					{
						this.m_Data.Add(num4);
					}
					num4++;
					AllianceGroup[] group = this.m_Group;
					int num6 = num5 - 1;
					group[num6].Count = group[num6].Count + 1;
				}
			}
			IL_168:;
		}
	}

	// Token: 0x06000F31 RID: 3889 RVA: 0x001AE1D4 File Offset: 0x001AC3D4
	private bool FindUserId(long UserId)
	{
		bool result = false;
		for (int i = 0; i < this.m_Data.Count; i++)
		{
			int num = this.m_Data[i];
			if (num >= 0 && num < DataManager.Instance.AllianceMember.Length && DataManager.Instance.AllianceMember[num].UserId == UserId)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x06000F32 RID: 3890 RVA: 0x001AE24C File Offset: 0x001AC44C
	private void CheckEmptyStr()
	{
		if (this.m_AllianceType == eAllianceType.eApply)
		{
			if (DataManager.Instance.RoleAlliance.Applicant == 0)
			{
				this.m_EmptyText.gameObject.SetActive(true);
			}
			else
			{
				this.m_EmptyText.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06000F33 RID: 3891 RVA: 0x001AE2A0 File Offset: 0x001AC4A0
	private bool ShowGiftBtn()
	{
		return DataManager.Instance.CheckPrizeFlag(9);
	}

	// Token: 0x06000F34 RID: 3892 RVA: 0x001AE2B0 File Offset: 0x001AC4B0
	private void UpdateRewardData(ushort itemid)
	{
		DataManager instance = DataManager.Instance;
		List<KingGiftInfo> giftList = instance.KingGift.GetGiftList();
		int num = giftList.Count;
		for (int i = 0; i < num; i++)
		{
			if (giftList[i].ItemID == itemid)
			{
				this.m_KingGiftInfoIdx = i;
				break;
			}
		}
		if (this.m_KingGiftInfoIdx < giftList.Count)
		{
			num = (int)giftList[this.m_KingGiftInfoIdx].ListCount;
			Array.Clear(this.m_KingGiftInfoData, 0, this.m_KingGiftInfoData.Length);
			int num2 = 0;
			while (num2 < this.m_Data.Count && num2 < this.m_KingGiftInfoData.Length)
			{
				int num3 = this.m_Data[num2];
				for (int j = 0; j < num; j++)
				{
					if (num3 >= 0 && num3 < instance.AllianceMember.Length && instance.AllianceMember[num3].UserId == giftList[this.m_KingGiftInfoIdx].List[j].UserID)
					{
						this.m_KingGiftInfoData[num3] = true;
					}
				}
				num2++;
			}
		}
		this.SetRewardCountText(this.GetGiftCount());
	}

	// Token: 0x06000F35 RID: 3893 RVA: 0x001AE3F8 File Offset: 0x001AC5F8
	private bool IsReward(int dataIdx)
	{
		return dataIdx >= 0 && dataIdx < this.m_KingGiftInfoData.Length && this.m_KingGiftInfoData[dataIdx];
	}

	// Token: 0x06000F36 RID: 3894 RVA: 0x001AE41C File Offset: 0x001AC61C
	private byte GetGiftCount()
	{
		DataManager instance = DataManager.Instance;
		if (this.m_KingGiftInfoIdx < instance.KingGift.GetGiftList().Count)
		{
			return instance.KingGift.GetGiftList()[this.m_KingGiftInfoIdx].GetRemainCount();
		}
		return 0;
	}

	// Token: 0x06000F37 RID: 3895 RVA: 0x001AE468 File Offset: 0x001AC668
	private void SetRewardCountText(byte count)
	{
		if (this.m_RewardCount != null)
		{
			this.m_RewardCount.ClearString();
			this.m_RewardCount.IntToFormat((long)count, 1, false);
			this.m_RewardCount.AppendFormat("{0}");
			this.m_RewardCountText.text = this.m_RewardCount.ToString();
			this.m_RewardCountText.SetAllDirty();
			this.m_RewardCountText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06000F38 RID: 3896 RVA: 0x001AE4DC File Offset: 0x001AC6DC
	private bool IsKingOrConqueror()
	{
		DataManager instance = DataManager.Instance;
		bool result = false;
		for (int i = 0; i < instance.m_Wonders.Count; i++)
		{
			if (instance.m_Wonders[i].WonderID == 0)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x06000F39 RID: 3897 RVA: 0x001AE530 File Offset: 0x001AC730
	private int IsTimeToRecall()
	{
		int result = 0;
		DataManager instance = DataManager.Instance;
		long num = 0L;
		long num2 = 0L;
		if (this.m_Data.Count >= 2 && this.m_Data[1] >= 0 && this.m_Data[1] < instance.AllianceMember.Length)
		{
			num = instance.AllianceMember[this.m_Data[1]].LogoutTime;
			num2 = DataManager.Instance.ServerTime - num;
		}
		if (instance.RoleAlliance.Rank == AllianceRank.RANK1 || instance.RoleAlliance.Rank == AllianceRank.RANK2)
		{
			if (num == 0L || num2 < 864000L)
			{
				result = 204;
			}
		}
		else if ((instance.RoleAlliance.Rank == AllianceRank.RANK3 || instance.RoleAlliance.Rank == AllianceRank.RANK4) && (num == 0L || num2 < 432000L))
		{
			result = 203;
		}
		return result;
	}

	// Token: 0x06000F3A RID: 3898 RVA: 0x001AE62C File Offset: 0x001AC82C
	private void ShowMessage(int ErrorCode)
	{
		switch (ErrorCode)
		{
		case 201:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9532u), 255, true);
			break;
		case 203:
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.IntToFormat(5L, 1, false);
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9536u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
			break;
		}
		case 204:
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.IntToFormat(10L, 1, false);
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9536u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
			break;
		}
		}
	}

	// Token: 0x06000F3B RID: 3899 RVA: 0x001AE730 File Offset: 0x001AC930
	private byte ShowCanonizedBtnByTableID()
	{
		byte b = 0;
		byte[] array = new byte[]
		{
			0,
			1,
			2,
			4
		};
		if (DataManager.MapDataController.IsKing() || DataManager.MapDataController.IsKingdomChief())
		{
			b += array[1];
		}
		if (DataManager.MapDataController.IsWorldKing() || DataManager.MapDataController.IsWorldChief())
		{
			b += array[2];
		}
		if (DataManager.MapDataController.IsNobilityKing() || DataManager.MapDataController.IsNobilityChief())
		{
			b += array[3];
		}
		return b;
	}

	// Token: 0x06000F3C RID: 3900 RVA: 0x001AE7C4 File Offset: 0x001AC9C4
	private void OpneDemiseOKCancel(bool bShow)
	{
		if (bShow)
		{
			this.m_DemisePlayerText.text = this.m_DemiseMember.Name;
			this.m_DemisePowerValue.ClearString();
			this.m_DemisePowerValue.uLongToFormat(this.m_DemiseMember.Power, 1, true);
			this.m_DemisePowerValue.AppendFormat("{0}");
			this.m_DemisePowerValueText.text = this.m_DemisePowerValue.ToString();
			GUIManager.Instance.ChangeHeroItemImg(this.m_DemiseHIbtn.transform, eHeroOrItem.Hero, this.m_DemiseMember.Head, 11, 0, 0);
			this.m_DemiseRankIcon.sprite = this.m_SpritesArray.GetSprite((int)(1 + this.m_DemiseMember.Rank));
			if (this.m_DemisePanel.gameObject.activeSelf)
			{
				this.m_DemiseInfoText.text = DataManager.Instance.mStringTable.GetStringByID(16148u);
				this.m_DemiseBtn.m_BtnID1 = 208;
			}
			else
			{
				this.m_DemiseInfoText.text = DataManager.Instance.mStringTable.GetStringByID(16147u);
				this.m_DemiseBtn.m_BtnID1 = 207;
			}
		}
		this.m_DemisePanel.gameObject.SetActive(bShow);
	}

	// Token: 0x06000F3D RID: 3901 RVA: 0x001AE908 File Offset: 0x001ACB08
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.Parm1 == 1)
		{
			this.m_DemiseHintText.text = DataManager.Instance.mStringTable.GetStringByID(7346u);
		}
		else
		{
			this.m_DemiseHintText.text = DataManager.Instance.mStringTable.GetStringByID(7347u);
		}
		Vector2 sizeDelta = this.m_DemiseHintText.rectTransform.sizeDelta;
		sizeDelta.y = this.m_DemiseHintText.preferredHeight;
		this.m_DemiseHintText.rectTransform.sizeDelta = sizeDelta;
		this.m_DemiseHintImage.rectTransform.sizeDelta = sizeDelta + new Vector2(20f, 10f);
		this.m_DemiseHintText.transform.parent.gameObject.SetActive(true);
	}

	// Token: 0x06000F3E RID: 3902 RVA: 0x001AE9D8 File Offset: 0x001ACBD8
	public void OnButtonUp(UIButtonHint sender)
	{
		this.m_DemiseHintText.transform.parent.gameObject.SetActive(false);
	}

	// Token: 0x04003229 RID: 12841
	private const int MaxScrollPanelObj = 10;

	// Token: 0x0400322A RID: 12842
	private const int DismissLeaderMoney = 2000;

	// Token: 0x0400322B RID: 12843
	private Transform m_ManagePanel;

	// Token: 0x0400322C RID: 12844
	private Transform m_RankChangePanel;

	// Token: 0x0400322D RID: 12845
	private Transform m_EmptyText;

	// Token: 0x0400322E RID: 12846
	private Transform m_DemisePanel;

	// Token: 0x0400322F RID: 12847
	private Transform m_ManagePanelGiftTf;

	// Token: 0x04003230 RID: 12848
	private RectTransform m_ManagePanelGiftRectTf;

	// Token: 0x04003231 RID: 12849
	private UIText m_ManagePanelNameText;

	// Token: 0x04003232 RID: 12850
	private Image m_ManagePanelRankImage;

	// Token: 0x04003233 RID: 12851
	private UIText m_RankChangePanelNameText;

	// Token: 0x04003234 RID: 12852
	private Image[] m_RankChangePanelCheckImages = new Image[4];

	// Token: 0x04003235 RID: 12853
	private Image[] m_RankChangePanelBtnImages = new Image[4];

	// Token: 0x04003236 RID: 12854
	private int m_ManagePanelIdx;

	// Token: 0x04003237 RID: 12855
	private int m_SelectRankLv;

	// Token: 0x04003238 RID: 12856
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04003239 RID: 12857
	private UISpritesArray m_SpritesArray;

	// Token: 0x0400323A RID: 12858
	private AllianceGroup[] m_Group;

	// Token: 0x0400323B RID: 12859
	private List<int> m_Data;

	// Token: 0x0400323C RID: 12860
	private StringBuilder sb;

	// Token: 0x0400323D RID: 12861
	private eAllianceType m_AllianceType;

	// Token: 0x0400323E RID: 12862
	private long m_UserID;

	// Token: 0x0400323F RID: 12863
	private AllianceRank m_Rank;

	// Token: 0x04003240 RID: 12864
	private CString[][] m_ItemStr = new CString[10][];

	// Token: 0x04003241 RID: 12865
	private CString m_DemiseStr;

	// Token: 0x04003242 RID: 12866
	private CString m_Expel;

	// Token: 0x04003243 RID: 12867
	private CString m_RankName;

	// Token: 0x04003244 RID: 12868
	private CString m_RewardCount;

	// Token: 0x04003245 RID: 12869
	private CString m_DemisePowerValue;

	// Token: 0x04003246 RID: 12870
	private string m_DemiseName;

	// Token: 0x04003247 RID: 12871
	private AllianceMemberClientDataType m_DemiseMember = default(AllianceMemberClientDataType);

	// Token: 0x04003248 RID: 12872
	private uint m_AllianceID;

	// Token: 0x04003249 RID: 12873
	private byte m_AllianceMember;

	// Token: 0x0400324A RID: 12874
	private byte m_AllianceApplyMember;

	// Token: 0x0400324B RID: 12875
	private long m_SeletUserId;

	// Token: 0x0400324C RID: 12876
	private int m_RankChangePanelIdx;

	// Token: 0x0400324D RID: 12877
	private Door door;

	// Token: 0x0400324E RID: 12878
	private bool bFirstUpdate = true;

	// Token: 0x0400324F RID: 12879
	private RectTransform m_Content;

	// Token: 0x04003250 RID: 12880
	private AllianceListText[] m_AllianceListText = new AllianceListText[10];

	// Token: 0x04003251 RID: 12881
	private UIHIBtn[] m_TempUIHIBtn = new UIHIBtn[10];

	// Token: 0x04003252 RID: 12882
	private int m_SendRewardIdx = -1;

	// Token: 0x04003253 RID: 12883
	private ushort m_RewardItemID;

	// Token: 0x04003254 RID: 12884
	private int m_KingGiftInfoIdx;

	// Token: 0x04003255 RID: 12885
	private bool[] m_KingGiftInfoData = new bool[100];

	// Token: 0x04003256 RID: 12886
	private UIText m_RewardCountText;

	// Token: 0x04003257 RID: 12887
	private UIText m_DemiseTittle;

	// Token: 0x04003258 RID: 12888
	private UIText m_DemiseTittle2;

	// Token: 0x04003259 RID: 12889
	private UIText m_DemisePlayerText;

	// Token: 0x0400325A RID: 12890
	private UIText m_DemisePowerValueText;

	// Token: 0x0400325B RID: 12891
	private UIText m_DemiseInfoText;

	// Token: 0x0400325C RID: 12892
	private UIText m_DemiseHintText;

	// Token: 0x0400325D RID: 12893
	private Image m_DemiseHintImage;

	// Token: 0x0400325E RID: 12894
	private UIButton m_DemiseBtn;

	// Token: 0x0400325F RID: 12895
	private UIHIBtn m_DemiseHIbtn;

	// Token: 0x04003260 RID: 12896
	private Image m_DemiseRankIcon;

	// Token: 0x04003261 RID: 12897
	private bool bOpenDismissLeader;

	// Token: 0x04003262 RID: 12898
	private CString m_ManagementName;
}
