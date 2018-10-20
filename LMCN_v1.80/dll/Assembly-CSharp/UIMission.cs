using System;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x02000417 RID: 1047
public class UIMission : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x0600154B RID: 5451 RVA: 0x00248DF8 File Offset: 0x00246FF8
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager instance = GUIManager.Instance;
		DataManager instance2 = DataManager.Instance;
		Font ttffont = instance.GetTTFFont();
		instance.UpdateUI(EGUIWindow.Door, 1, 2);
		if (instance.bOpenOnIPhoneX)
		{
			base.transform.GetChild(11).GetComponent<CustomImage>().enabled = false;
		}
		else
		{
			base.transform.GetChild(11).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		}
		base.transform.GetChild(11).GetChild(0).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		UIButton component = base.transform.GetChild(11).GetChild(0).GetComponent<UIButton>();
		component.m_BtnID1 = 5;
		component.m_Handler = this;
		this.TextRefresh[0] = base.transform.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.TextRefresh[0].font = ttffont;
		this.TextRefresh[0].text = instance2.mStringTable.GetStringByID(1521u);
		this.RewardRect = base.transform.GetChild(5).GetComponent<RectTransform>();
		this.RewardPriceRect = base.transform.GetChild(5).GetChild(2).GetComponent<RectTransform>();
		this.TextRefresh[1] = base.transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.TextRefresh[1].font = ttffont;
		this.TextRefresh[1].text = instance2.mStringTable.GetStringByID(1527u);
		this.PriceList = this.RewardPriceRect.anchoredPosition;
		this.RewardBk = base.transform.GetChild(5).GetChild(1).GetComponent<Image>();
		for (int i = 0; i < this.RewardItems.Length; i++)
		{
			this.RewardItems[i] = base.transform.GetChild(5).GetChild(1).GetChild(i).GetComponent<RectTransform>();
			this.RewardNum[i] = this.RewardItems[i].GetChild(0).GetComponent<UIText>();
			this.RewardNum[i].font = ttffont;
			this.RewardNumStr[i] = StringManager.Instance.SpawnString(30);
		}
		this.TagControl = new UIMission._TagControl[4];
		for (int j = 0; j < 4; j++)
		{
			this.TagControl[j].Btn = base.transform.GetChild(3).GetChild(j).GetComponent<UIButton>();
			this.TagControl[j].Btn.m_BtnID1 = 0 + j;
			this.TagControl[j].Btn.m_Handler = this;
			this.TagControl[j].Title = base.transform.GetChild(3).GetChild(j).GetChild(1).GetComponent<UIText>();
			this.TagControl[j].Title.font = ttffont;
			this.TagControl[j].Title.text = instance2.mStringTable.GetStringByID((uint)(1523 + j));
			base.transform.GetChild(3).GetChild(4 + j).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
			this.TagControl[j].Init();
			this.TagControl[j].TagAlpha = base.transform.GetChild(3).GetChild(j).GetChild(0).GetComponent<CanvasGroup>();
			this.TagControl[j].Tip = base.transform.GetChild(3).GetChild(4 + j);
			this.TagControl[j].Notice = base.transform.GetChild(3).GetChild(8 + j);
			this.TagControl[j].Notice.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
			this.TagControl[j].Notice.GetChild(0).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
			this.TagControl[j].Notice.GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
			this.TagControl[j].NumText = this.TagControl[j].Tip.GetChild(0).GetComponent<UIText>();
			this.TagControl[j].NumText.font = ttffont;
			this.TagControl[j].SetNum(DataManager.MissionDataManager.AccessMissionCount[j]);
			this.UpdateTagInfo(j);
		}
		this.UpgradeAlliancObj = base.transform.GetChild(3).GetChild(base.transform.GetChild(3).childCount - 1).gameObject;
		this.UpgradeTweenPosition = this.UpgradeAlliancObj.transform.GetChild(0).GetComponent<uTweenPosition>();
		this.UpgradeTweenAlpha = this.UpgradeAlliancObj.transform.GetChild(0).GetComponent<uTweenAlpha>();
		this.TagTextColor = this.TagControl[0].Title.color;
		this.HintRect = base.transform.GetChild(12).GetComponent<RectTransform>();
		this.HintText = this.HintRect.GetChild(0).GetComponent<UIText>();
		this.HintText.font = ttffont;
		base.transform.GetChild(12).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
	}

	// Token: 0x0600154C RID: 5452 RVA: 0x00249398 File Offset: 0x00247598
	public void Init()
	{
		GUIManager instance = GUIManager.Instance;
		Font ttffont = instance.GetTTFFont();
		this.ItemController = new UIMissionItemController(this, base.transform.GetChild(6), 8);
		this.ItemController.NoMissionText.font = ttffont;
		this.ItemController.AllianceBoundRateText.font = ttffont;
		this.ItemController.TimeText.font = ttffont;
		this.ItemController.ItemSample[1] = base.transform.GetChild(8);
		this.ItemController.ItemSample[0] = base.transform.GetChild(10);
		this.ItemController.ItemSample[2] = base.transform.GetChild(9);
		this.ItemController.ItemSample[3] = base.transform.GetChild(4);
		this.ItemController.ItemSample[2].GetChild(0).GetComponent<UIText>().font = ttffont;
		this.ItemController.ItemSample[2].GetChild(3).GetComponent<UIText>().font = ttffont;
		this.ItemController.ItemSample[0].GetChild(0).GetComponent<UIText>().font = ttffont;
		for (int i = 0; i < ManorAimMission.MaxSlot; i++)
		{
			this.ItemController.ItemSample[0].GetChild(1 + i).GetChild(0).GetComponent<UIText>().font = ttffont;
			this.ItemController.ItemSample[0].GetChild(1 + i).GetChild(1).GetChild(1).GetComponent<UIText>().font = ttffont;
		}
		this.ItemController.ItemSample[1].GetChild(3).GetChild(1).GetComponent<UIText>().font = ttffont;
		this.ItemController.ItemSample[1].GetChild(1).GetComponent<UIText>().font = ttffont;
		this.ItemController.ItemSample[3].GetChild(0).GetChild(1).GetComponent<UIText>().font = ttffont;
		this.ItemController.ItemSample[3].GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttffont;
		this.ItemController.ItemSample[3].GetChild(10).GetChild(0).GetComponent<UIText>().font = ttffont;
		base.transform.GetChild(6).GetChild(4).GetChild(0).GetChild(0).GetChild(1).GetComponent<UIText>().font = ttffont;
		base.transform.GetChild(6).GetChild(4).GetChild(0).GetChild(0).GetChild(2).GetComponent<UIText>().font = ttffont;
		base.transform.GetChild(6).GetChild(4).GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>().font = ttffont;
		base.transform.GetChild(6).GetChild(4).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>().font = ttffont;
		base.transform.GetChild(6).GetChild(4).GetChild(1).GetChild(0).GetChild(2).GetComponent<UIText>().font = ttffont;
		base.transform.GetChild(6).GetChild(4).GetChild(1).GetChild(0).GetChild(3).GetComponent<UIText>().font = ttffont;
		base.transform.GetChild(4).GetChild(3).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttffont;
		base.transform.GetChild(4).GetChild(4).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttffont;
		base.transform.GetChild(4).GetChild(5).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttffont;
		base.transform.GetChild(4).GetChild(6).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttffont;
		base.transform.GetChild(4).GetChild(7).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttffont;
		base.transform.GetChild(4).GetChild(8).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttffont;
		base.transform.GetChild(4).GetChild(9).GetChild(1).GetChild(0).GetComponent<UIText>().font = ttffont;
		this.TimeHandle = this.ItemController;
		this.Reward = new uint[9];
		this.RewardIcon = new Sprite[9];
		this.RewardHintText = new ushort[9];
		this.RewardItemID = new ushort[3];
		this.RewardItemCount = new ushort[3];
		Door door = instance.FindMenu(EGUIWindow.Door) as Door;
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			this.RewardIcon[0] = door.LoadSprite("UI_main_res_exp_cn");
		}
		else
		{
			this.RewardIcon[0] = door.LoadSprite("UI_main_res_exp");
		}
		this.RewardIcon[1] = door.LoadSprite("UI_main_res_strength");
		this.RewardIcon[2] = door.LoadSprite("UI_main_money_03");
		this.RewardIcon[3] = door.LoadSprite("UI_main_res_food");
		this.RewardIcon[4] = door.LoadSprite("UI_main_res_stone");
		this.RewardIcon[5] = door.LoadSprite("UI_main_res_wood");
		this.RewardIcon[6] = door.LoadSprite("UI_main_res_iron");
		this.RewardIcon[7] = door.LoadSprite("UI_main_money_01");
		this.RewardIcon[8] = door.LoadSprite("UI_main_res_league");
		this.RewardHintText[0] = 1522;
		this.RewardHintText[1] = 1564;
		this.RewardHintText[2] = 1600;
		this.RewardHintText[3] = 1581;
		this.RewardHintText[4] = 1582;
		this.RewardHintText[5] = 1583;
		this.RewardHintText[6] = 1584;
		this.RewardHintText[7] = 1529;
		this.RewardHintText[8] = 1592;
		Material iconMat = door.LoadMaterial();
		this.ArabicRot = base.transform.GetChild(5).GetChild(2).GetChild(0).GetChild(0).GetComponent<ArabicItemTextureRot>();
		for (int j = 0; j < this.RewardData.Length; j++)
		{
			this.RewardData[j] = new UIMission._Reward(base.transform.GetChild(5).GetChild(2).GetChild(j), iconMat);
			this.RewardData[j].RewardText.font = ttffont;
			this.RewardData[j].Hint.m_Handler = this;
			this.RewardData[j].Hint.ControlFadeOut = this.HintRect.gameObject;
		}
		for (int k = 0; k < this.RewardItems.Length; k++)
		{
			if (k < this.RewardItems.Length >> 1)
			{
				instance.InitianHeroItemImg(this.RewardItems[k], eHeroOrItem.Item, 0, 0, 0, 0, false, true, true, false);
				this.RewardHIBtn[k] = this.RewardItems[k].GetComponent<UIHIBtn>();
			}
			else
			{
				instance.InitLordEquipImg(this.RewardItems[k], 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
				this.RewardItems[k].gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
			}
		}
		if (DataManager.Instance.RoleAlliance.Id == 0u && instance.MissionSaved == 2)
		{
			GUIManager guimanager = instance;
			guimanager.MissionSaved -= 1;
		}
		this.OnButtonClick(this.TagControl[(int)instance.MissionSaved].Btn);
	}

	// Token: 0x0600154D RID: 5453 RVA: 0x00249B78 File Offset: 0x00247D78
	public void OnButtonClick(UIButton sender)
	{
		if (this.ItemController == null)
		{
			return;
		}
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		int currentTag = (int)this.ItemController.CurrentTag;
		bool flag = false;
		switch (sender.m_BtnID1)
		{
		case 0:
		case 1:
		case 2:
			flag = this.ItemController.ChangeTag((eMissionClickType)sender.m_BtnID1, false);
			if (flag)
			{
				this.UpdatAllianceUpGrade();
				if (!this.RewardRect.gameObject.activeSelf)
				{
					this.RewardRect.gameObject.SetActive(true);
				}
			}
			break;
		case 3:
			flag = this.ItemController.ChangeTag((eMissionClickType)sender.m_BtnID1, false);
			if (flag)
			{
				this.UpdatAllianceUpGrade();
				if (this.RewardRect.gameObject.activeSelf)
				{
					this.RewardRect.gameObject.SetActive(false);
				}
			}
			break;
		case 5:
			door.CloseMenu(false);
			break;
		case 11:
		{
			this.SelectBtn = sender;
			this.ItemController.SetSelect(sender.m_BtnID2, sender.m_BtnID4, this.Reward, this.RewardItemID, this.RewardItemCount);
			byte b = 0;
			int num = 0;
			for (int i = 0; i < this.RewardItemID.Length; i++)
			{
				if (this.RewardItemID[i] == 0)
				{
					this.UsedRewardItem[i] = null;
				}
				else
				{
					Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.RewardItemID[i]);
					int num2;
					if (!GUIManager.Instance.IsLeadItem(recordByKey.EquipKind))
					{
						num2 = (int)b;
						this.RewardItems[num2].gameObject.SetActive(true);
						this.UsedRewardItem[i] = this.RewardItems[num2];
						GUIManager.Instance.ChangeHeroItemImg(this.RewardItems[num2], eHeroOrItem.Item, this.RewardItemID[i], 0, 0, 0);
					}
					else
					{
						num2 = (int)(b + 3);
						this.RewardItems[num2].gameObject.SetActive(true);
						this.UsedRewardItem[i] = this.RewardItems[num2];
						GUIManager.Instance.ChangeLordEquipImg(this.RewardItems[num2], this.RewardItemID[i], (byte)(this.ItemController.GetQuality(sender.m_BtnID2, sender.m_BtnID4) + 1), eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
					}
					this.RewardNumStr[num2].ClearString();
					this.RewardNumStr[num2].IntToFormat((long)this.RewardItemCount[i], 1, false);
					if (GUIManager.Instance.IsArabic)
					{
						this.RewardNumStr[num2].AppendFormat("{0}x");
					}
					else
					{
						this.RewardNumStr[num2].AppendFormat("x{0}");
					}
					this.RewardNum[num2].text = this.RewardNumStr[num2].ToString();
					this.RewardNum[num2].SetAllDirty();
					num |= 1 << num2;
					UIText[] rewardNum = this.RewardNum;
					byte b2 = b;
					b = b2 + 1;
					rewardNum[(int)b2].cachedTextGenerator.Invalidate();
				}
			}
			switch (b)
			{
			case 1:
			{
				Vector2 anchoredPosition = this.UsedRewardItem[0].anchoredPosition;
				anchoredPosition.x = 1f;
				this.UsedRewardItem[0].anchoredPosition = anchoredPosition;
				break;
			}
			case 2:
			{
				Vector2 anchoredPosition = this.UsedRewardItem[0].anchoredPosition;
				anchoredPosition.x = -50.5f;
				this.UsedRewardItem[0].anchoredPosition = anchoredPosition;
				anchoredPosition = this.UsedRewardItem[1].anchoredPosition;
				anchoredPosition.x = 58.5f;
				this.UsedRewardItem[1].anchoredPosition = anchoredPosition;
				break;
			}
			case 3:
			{
				Vector2 anchoredPosition = this.UsedRewardItem[0].anchoredPosition;
				anchoredPosition.x = -84f;
				this.UsedRewardItem[0].anchoredPosition = anchoredPosition;
				anchoredPosition = this.UsedRewardItem[1].anchoredPosition;
				anchoredPosition.x = 1f;
				this.UsedRewardItem[1].anchoredPosition = anchoredPosition;
				anchoredPosition = this.UsedRewardItem[2].anchoredPosition;
				anchoredPosition.x = 86f;
				this.UsedRewardItem[2].anchoredPosition = anchoredPosition;
				break;
			}
			}
			for (int j = 0; j < this.RewardItems.Length; j++)
			{
				if ((num & 1 << j) == 0)
				{
					this.RewardItems[j].transform.gameObject.SetActive(false);
				}
			}
			if (b == 0)
			{
				this.RewardBk.enabled = false;
			}
			else
			{
				this.RewardBk.enabled = true;
			}
			b = 0;
			for (int k = 0; k < this.Reward.Length; k++)
			{
				if (this.Reward[k] != 0u)
				{
					if (this.RewardData.Length <= (int)b)
					{
						break;
					}
					if (k == 0)
					{
						if (GUIManager.Instance.IsArabic)
						{
							this.ArabicRot.enabled = true;
						}
						else
						{
							this.ArabicRot.enabled = false;
						}
					}
					this.RewardData[(int)b].SetReward(this.RewardIcon[k], this.Reward[k], this.RewardHintText[k]);
					b += 1;
				}
			}
			for (int l = (int)b; l < this.RewardData.Length; l++)
			{
				this.RewardData[l].transform.gameObject.SetActive(false);
			}
			if (this.RewardBk.enabled)
			{
				this.RewardPriceRect.anchoredPosition = this.PriceList;
			}
			else
			{
				Vector2 anchoredPosition = this.PriceList;
				anchoredPosition.y = (float)(b * 20 - 200);
				this.RewardPriceRect.anchoredPosition = anchoredPosition;
			}
			break;
		}
		case 13:
			DataManager.MissionDataManager.AchievementMgr.OpenAchievementUI();
			break;
		}
		if (flag && currentTag < this.TagControl.Length)
		{
			this.TagControl[currentTag].TagAlpha.alpha = 0f;
			this.TagControl[currentTag].Title.color = this.TagTextColor;
		}
		if (this.ItemController.CurrentTag < (eMissionClickType)this.TagControl.Length)
		{
			this.TagControl[(int)this.ItemController.CurrentTag].Title.color = Color.white;
		}
	}

	// Token: 0x0600154E RID: 5454 RVA: 0x0024A208 File Offset: 0x00248408
	public void OnButtonDown(UIButtonHint sender)
	{
		this.HintText.text = DataManager.Instance.mStringTable.GetStringByID((uint)sender.Parm1);
		Vector2 vector = this.HintRect.sizeDelta;
		vector.y = this.HintText.preferredHeight + 16f;
		this.HintRect.sizeDelta = vector;
		sender.GetTipPosition(this.HintRect, UIButtonHint.ePosition.Original, null);
		vector = this.HintRect.anchoredPosition;
		vector.x -= 292f;
		vector.y -= 33f;
		this.HintRect.anchoredPosition = vector;
		this.HintRect.gameObject.SetActive(true);
		AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
	}

	// Token: 0x0600154F RID: 5455 RVA: 0x0024A2D8 File Offset: 0x002484D8
	public void OnButtonUp(UIButtonHint sender)
	{
		this.HintRect.gameObject.SetActive(false);
	}

	// Token: 0x06001550 RID: 5456 RVA: 0x0024A2EC File Offset: 0x002484EC
	public override void OnClose()
	{
		if (this.ItemController != null)
		{
			GUIManager.Instance.MissionSaved = (byte)this.ItemController.CurrentTag;
			this.ItemController.Destroy();
		}
		for (int i = 0; i < this.TagControl.Length; i++)
		{
			this.TagControl[i].Destroy();
		}
		for (int j = 0; j < this.RewardData.Length; j++)
		{
			this.RewardData[j].Destroy();
		}
		for (int k = 0; k < this.RewardNumStr.Length; k++)
		{
			StringManager.Instance.DeSpawnString(this.RewardNumStr[k]);
		}
		DataManager.Instance.UpdateLoadItemNotify();
	}

	// Token: 0x06001551 RID: 5457 RVA: 0x0024A3B0 File Offset: 0x002485B0
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.ItemController == null)
		{
			return;
		}
		this.ItemController.UpdateItem(dataIdx, panelObjectIdx);
	}

	// Token: 0x06001552 RID: 5458 RVA: 0x0024A3CC File Offset: 0x002485CC
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001553 RID: 5459 RVA: 0x0024A3D0 File Offset: 0x002485D0
	private void Update()
	{
		if (this.DelayInit > 0)
		{
			this.DelayInit -= 1;
			if (this.DelayInit == 0)
			{
				this.Init();
			}
		}
		else
		{
			this.ItemController.Update();
			float deltaTime = this.TimeHandle.GetDeltaTime();
			float alpha = (deltaTime <= 1f) ? deltaTime : (2f - deltaTime);
			this.TagControl[(int)this.ItemController.CurrentTag].TagAlpha.alpha = alpha;
		}
	}

	// Token: 0x06001554 RID: 5460 RVA: 0x0024A460 File Offset: 0x00248660
	public void UpdateTagInfo(int TagIndex)
	{
		if (TagIndex >= 1)
		{
			if (((int)DataManager.MissionDataManager.MissionNotice & 1 << TagIndex) > 0)
			{
				this.TagControl[TagIndex].Notice.gameObject.SetActive(true);
				this.TagControl[TagIndex].SetNum(0);
			}
			else if (TagIndex == 2 && DataManager.Instance.RoleAlliance.Id == 0u)
			{
				this.TagControl[TagIndex].Notice.gameObject.SetActive(false);
				this.TagControl[TagIndex].SetNum(0);
			}
			else
			{
				this.TagControl[TagIndex].Notice.gameObject.SetActive(false);
				this.TagControl[TagIndex].SetNum(DataManager.MissionDataManager.AccessMissionCount[TagIndex]);
			}
		}
		else if (TagIndex == 0)
		{
			if (DataManager.MissionDataManager.GetRewardCount(1) > 0)
			{
				this.TagControl[TagIndex].Notice.gameObject.SetActive(true);
			}
			else
			{
				this.TagControl[TagIndex].Notice.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001555 RID: 5461 RVA: 0x0024A5A0 File Offset: 0x002487A0
	public void UpdatAllianceUpGrade()
	{
		if (this.ItemController == null)
		{
			return;
		}
		bool flag = false;
		if (DataManager.MissionDataManager.AllianceMissionBonusRate > 100)
		{
			flag = true;
		}
		for (int i = 0; i < this.RewardData.Length; i++)
		{
			if (this.ItemController.CurrentTag == eMissionClickType.Tag3)
			{
				this.RewardData[i].UpgradeObj.SetActive(flag);
				if (flag)
				{
					this.RewardData[i].RewardText.color = new Color(0.318f, 0.89f, 0.412f);
					this.RewardData[i].textOutline.enabled = true;
				}
				else
				{
					this.RewardData[i].RewardText.color = new Color(0.733f, 0.941f, 1f);
					this.RewardData[i].textOutline.enabled = false;
				}
			}
			else
			{
				this.RewardData[i].UpgradeObj.SetActive(false);
				this.RewardData[i].textOutline.enabled = false;
				this.RewardData[i].RewardText.color = new Color(0.733f, 0.941f, 1f);
			}
		}
		this.UpgradeAlliancObj.SetActive(flag);
		if (!flag)
		{
			this.UpgradeTweenPosition.Reset();
			this.UpgradeTweenAlpha.Reset();
		}
		else
		{
			this.UpgradeTweenPosition.easeType = EaseType.linear;
			this.UpgradeTweenPosition.loopStyle = LoopStyle.Loop;
			this.UpgradeTweenPosition.duration = 1.2f;
			this.UpgradeTweenAlpha.easeType = EaseType.none;
			this.UpgradeTweenAlpha.loopStyle = LoopStyle.Loop;
			this.UpgradeTweenAlpha.duration = 1.2f;
		}
	}

	// Token: 0x06001556 RID: 5462 RVA: 0x0024A778 File Offset: 0x00248978
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 4 && arg2 == 0)
		{
			this.UpdatAllianceUpGrade();
			for (int i = 0; i < this.TagControl.Length; i++)
			{
				this.UpdateTagInfo(i);
			}
		}
		else if (arg1 == 16)
		{
			this.UpdateTagInfo(0);
		}
		else if (arg1 == 32)
		{
			if (this.SelectBtn != null)
			{
				this.OnButtonClick(this.SelectBtn);
			}
		}
		else if (arg1 > 0 && arg2 < this.TagControl.Length)
		{
			this.UpdateTagInfo(arg2);
		}
		if (this.ItemController != null)
		{
			this.ItemController.Update(arg1, arg2);
		}
	}

	// Token: 0x06001557 RID: 5463 RVA: 0x0024A830 File Offset: 0x00248A30
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_VIP:
			break;
		default:
			if (networkNews != NetworkNews.Login)
			{
				return;
			}
			break;
		case NetworkNews.Refresh_FontTextureRebuilt:
			for (int i = 0; i < this.TextRefresh.Length; i++)
			{
				this.TextRefresh[i].enabled = false;
				this.TextRefresh[i].enabled = true;
			}
			for (int j = 0; j < this.TagControl.Length; j++)
			{
				this.TagControl[j].NumText.enabled = false;
				this.TagControl[j].NumText.enabled = true;
				this.TagControl[j].Title.enabled = false;
				this.TagControl[j].Title.enabled = true;
			}
			for (int k = 0; k < this.RewardNum.Length; k++)
			{
				this.RewardNum[k].enabled = false;
				this.RewardNum[k].enabled = true;
			}
			if (this.HintText.enabled)
			{
				this.HintText.enabled = false;
				this.HintText.enabled = true;
			}
			if (this.ItemController != null)
			{
				for (int l = 0; l < this.RewardHIBtn.Length; l++)
				{
					if (this.RewardHIBtn[l].gameObject.activeSelf)
					{
						this.RewardHIBtn[l].Refresh_FontTexture();
					}
				}
				for (int m = 0; m < this.RewardData.Length; m++)
				{
					if (this.RewardData[m].transform.gameObject.activeSelf)
					{
						this.RewardData[m].RewardText.enabled = false;
						this.RewardData[m].RewardText.enabled = true;
					}
				}
				this.ItemController.TextRefresh();
			}
			return;
		}
		this.UpdateUI(4, 0);
	}

	// Token: 0x04003F27 RID: 16167
	public UIMissionItemController ItemController;

	// Token: 0x04003F28 RID: 16168
	private Image RewardBk;

	// Token: 0x04003F29 RID: 16169
	private RectTransform[] RewardItems = new RectTransform[6];

	// Token: 0x04003F2A RID: 16170
	private UIHIBtn[] RewardHIBtn = new UIHIBtn[3];

	// Token: 0x04003F2B RID: 16171
	private RectTransform[] UsedRewardItem = new RectTransform[3];

	// Token: 0x04003F2C RID: 16172
	private UIText[] RewardNum = new UIText[6];

	// Token: 0x04003F2D RID: 16173
	private CString[] RewardNumStr = new CString[6];

	// Token: 0x04003F2E RID: 16174
	private UIMission._Reward[] RewardData = new UIMission._Reward[7];

	// Token: 0x04003F2F RID: 16175
	private RectTransform RewardPriceRect;

	// Token: 0x04003F30 RID: 16176
	private RectTransform RewardRect;

	// Token: 0x04003F31 RID: 16177
	public RectTransform HintRect;

	// Token: 0x04003F32 RID: 16178
	private UIText HintText;

	// Token: 0x04003F33 RID: 16179
	private UIMission._TagControl[] TagControl;

	// Token: 0x04003F34 RID: 16180
	private uint[] Reward;

	// Token: 0x04003F35 RID: 16181
	private ushort[] RewardItemID;

	// Token: 0x04003F36 RID: 16182
	private ushort[] RewardItemCount;

	// Token: 0x04003F37 RID: 16183
	private ushort[] RewardHintText;

	// Token: 0x04003F38 RID: 16184
	private Sprite[] RewardIcon;

	// Token: 0x04003F39 RID: 16185
	private byte DelayInit = 2;

	// Token: 0x04003F3A RID: 16186
	private Vector2 PriceList;

	// Token: 0x04003F3B RID: 16187
	private iMissionTimeDelta TimeHandle;

	// Token: 0x04003F3C RID: 16188
	private Color TagTextColor;

	// Token: 0x04003F3D RID: 16189
	private UIText[] TextRefresh = new UIText[2];

	// Token: 0x04003F3E RID: 16190
	private ArabicItemTextureRot ArabicRot;

	// Token: 0x04003F3F RID: 16191
	private GameObject UpgradeAlliancObj;

	// Token: 0x04003F40 RID: 16192
	private uTweener UpgradeTweenPosition;

	// Token: 0x04003F41 RID: 16193
	private uTweener UpgradeTweenAlpha;

	// Token: 0x04003F42 RID: 16194
	private UIButton SelectBtn;

	// Token: 0x02000418 RID: 1048
	private struct _TagControl
	{
		// Token: 0x06001558 RID: 5464 RVA: 0x0024AA40 File Offset: 0x00248C40
		public void Init()
		{
			this.NumStr = StringManager.Instance.SpawnString(30);
		}

		// Token: 0x06001559 RID: 5465 RVA: 0x0024AA54 File Offset: 0x00248C54
		public void SetNum(byte Num)
		{
			if (Num == 0)
			{
				this.Tip.gameObject.SetActive(false);
				return;
			}
			this.Tip.gameObject.SetActive(true);
			this.NumStr.ClearString();
			this.NumStr.IntToFormat((long)Num, 1, false);
			this.NumStr.AppendFormat("{0}");
			this.NumText.text = this.NumStr.ToString();
			this.NumText.SetAllDirty();
			this.NumText.cachedTextGenerator.Invalidate();
		}

		// Token: 0x0600155A RID: 5466 RVA: 0x0024AAE8 File Offset: 0x00248CE8
		public void Destroy()
		{
			StringManager.Instance.DeSpawnString(this.NumStr);
		}

		// Token: 0x04003F43 RID: 16195
		public UIButton Btn;

		// Token: 0x04003F44 RID: 16196
		public CanvasGroup TagAlpha;

		// Token: 0x04003F45 RID: 16197
		public CString NumStr;

		// Token: 0x04003F46 RID: 16198
		public UIText NumText;

		// Token: 0x04003F47 RID: 16199
		public UIText Title;

		// Token: 0x04003F48 RID: 16200
		public Transform Notice;

		// Token: 0x04003F49 RID: 16201
		public Transform Tip;
	}

	// Token: 0x02000419 RID: 1049
	private struct _Reward
	{
		// Token: 0x0600155B RID: 5467 RVA: 0x0024AAFC File Offset: 0x00248CFC
		public _Reward(Transform trans, Material IconMat)
		{
			this.transform = trans;
			this.Icon = this.transform.GetChild(0).GetComponent<Image>();
			this.Icon.material = IconMat;
			this.RewardText = this.transform.GetChild(1).GetComponent<UIText>();
			this.textOutline = this.transform.GetChild(1).GetComponent<Outline>();
			this.RewardStr = StringManager.Instance.SpawnString(30);
			this.Hint = this.transform.gameObject.AddComponent<UIButtonHint>();
			this.Hint.m_eHint = EUIButtonHint.DownUpHandler;
			this.HintRect = this.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
			this.UpgradeObj = this.transform.GetChild(2).gameObject;
		}

		// Token: 0x0600155C RID: 5468 RVA: 0x0024ABCC File Offset: 0x00248DCC
		public void Destroy()
		{
			StringManager.Instance.DeSpawnString(this.RewardStr);
		}

		// Token: 0x0600155D RID: 5469 RVA: 0x0024ABE0 File Offset: 0x00248DE0
		public void SetReward(Sprite sprite, uint Num, ushort HintID)
		{
			this.Hint.Parm1 = HintID;
			this.transform.gameObject.SetActive(true);
			this.RewardStr.ClearString();
			this.RewardStr.IntToFormat((long)((ulong)Num), 1, true);
			if (GUIManager.Instance.IsArabic)
			{
				this.RewardStr.AppendFormat("{0} +");
			}
			else
			{
				this.RewardStr.AppendFormat("+ {0}");
			}
			this.Icon.sprite = sprite;
			this.Icon.SetNativeSize();
			this.RewardText.text = this.RewardStr.ToString();
			this.RewardText.SetAllDirty();
			this.RewardText.cachedTextGenerator.Invalidate();
			this.RewardText.cachedTextGeneratorForLayout.Invalidate();
			Vector2 offsetMax = this.HintRect.offsetMax;
			offsetMax.x = 14f + this.RewardText.preferredWidth;
			this.HintRect.offsetMax = offsetMax;
		}

		// Token: 0x04003F4A RID: 16202
		public Transform transform;

		// Token: 0x04003F4B RID: 16203
		public Image Icon;

		// Token: 0x04003F4C RID: 16204
		public UIText RewardText;

		// Token: 0x04003F4D RID: 16205
		public CString RewardStr;

		// Token: 0x04003F4E RID: 16206
		public UIButtonHint Hint;

		// Token: 0x04003F4F RID: 16207
		private RectTransform HintRect;

		// Token: 0x04003F50 RID: 16208
		public GameObject UpgradeObj;

		// Token: 0x04003F51 RID: 16209
		public Outline textOutline;
	}

	// Token: 0x0200041A RID: 1050
	private enum UIControl
	{
		// Token: 0x04003F53 RID: 16211
		Background,
		// Token: 0x04003F54 RID: 16212
		Google,
		// Token: 0x04003F55 RID: 16213
		Title,
		// Token: 0x04003F56 RID: 16214
		Tag,
		// Token: 0x04003F57 RID: 16215
		VIP,
		// Token: 0x04003F58 RID: 16216
		Reward,
		// Token: 0x04003F59 RID: 16217
		MissionList,
		// Token: 0x04003F5A RID: 16218
		Item,
		// Token: 0x04003F5B RID: 16219
		Affair,
		// Token: 0x04003F5C RID: 16220
		Recommand,
		// Token: 0x04003F5D RID: 16221
		Complete,
		// Token: 0x04003F5E RID: 16222
		Close,
		// Token: 0x04003F5F RID: 16223
		Hint
	}
}
