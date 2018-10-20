using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x020007CE RID: 1998
public class BuildingWindow : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUTimeBarOnTimer
{
	// Token: 0x06002929 RID: 10537 RVA: 0x0044E6BC File Offset: 0x0044C8BC
	private void Awake()
	{
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.GM = GUIManager.Instance;
		AssetBundle assetBundle = AssetManager.GetAssetBundle(this.abName, out this.abKey, false);
		if (assetBundle == null)
		{
			return;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(assetBundle.mainAsset);
		if (gameObject == null)
		{
			AssetManager.UnloadAssetBundle(this.abKey, true);
			return;
		}
		gameObject.transform.SetParent(base.transform, false);
		this.baseTransform = gameObject.transform;
		this.spArray = gameObject.transform.GetComponent<UISpritesArray>();
		this.titleText = gameObject.transform.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.mainTransform = gameObject.transform.GetChild(5);
		this.mainTransform_Bg = gameObject.transform.GetChild(2).GetComponent<Image>();
		this.mainTransform_Bg2 = gameObject.transform.GetChild(3).GetComponent<Image>();
		this.mainTransform_V = gameObject.transform.GetChild(5).GetChild(0);
		this.mainTransform_H = gameObject.transform.GetChild(5).GetChild(1);
		this.buildingTransformBG = gameObject.transform.GetChild(7);
		this.buildingTransform = gameObject.transform.GetChild(7).GetChild(0);
		if (this.GM.IsArabic)
		{
			this.buildingTransform.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.buildingInfoTransform = gameObject.transform.GetChild(10);
		this.uiButtonTransform = gameObject.transform.GetChild(9);
		if (GUIManager.Instance.IsArabic)
		{
			this.uiButtonTransform.GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.normalPanel = gameObject.transform.GetChild(15);
		this.buildingLvBG = gameObject.transform.GetChild(8);
		this.sliderImage = gameObject.transform.GetChild(8).GetChild(0).GetComponent<Image>();
		this.sliderBGImage = gameObject.transform.GetChild(8).GetComponent<Image>();
		this.lvText = gameObject.transform.GetChild(8).GetChild(1).GetComponent<UIText>();
		this.normalPanelInfoTf3 = this.normalPanel.GetChild(7);
		for (int i = 0; i < 4; i++)
		{
			this.normalPanelTitles[i] = this.normalPanel.GetChild(i * 2).GetComponent<UIText>();
			this.normalPanelInfosImage[i] = this.normalPanel.GetChild(i * 2 + 1).GetChild(0).GetComponent<Image>();
			this.normalPanelInfos[i] = this.normalPanel.GetChild(i * 2 + 1).GetChild(1).GetComponent<UIText>();
		}
		this.normallInfoPanel = gameObject.transform.GetChild(18);
		this.upgradePanel = gameObject.transform.GetChild(17);
		this.infoPanel = gameObject.transform.GetChild(19);
		Image component;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			component = gameObject.transform.GetChild(14).GetComponent<Image>();
			if (component)
			{
				component.enabled = false;
			}
		}
		this.exitBtn = gameObject.transform.GetChild(14).GetChild(0).GetComponent<UIButton>();
		this.exitBtn.m_BtnID1 = 3;
		this.exitBtn.m_Handler = this;
		this.exitBtn.image.sprite = this.door.LoadSprite("UI_main_close");
		this.exitBtn.image.material = this.door.LoadMaterial();
		component = gameObject.transform.GetChild(14).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = this.door.LoadMaterial();
		Transform child = gameObject.transform.GetChild(11);
		this.btnSpArray = child.GetComponent<UISpritesArray>();
		this.backOutBtnBgImage = child.GetComponent<Image>();
		this.backOutBtnImage = child.GetChild(0).GetComponent<Image>();
		this.backOutBtnImageRt = child.GetChild(0).GetComponent<RectTransform>();
		this.backOutBtnTextRt = child.GetChild(1).GetComponent<RectTransform>();
		this.backOutBtnText = child.GetChild(1).GetComponent<UIText>();
		this.backOutBtnText.font = GUIManager.Instance.GetTTFFont();
		this.backOutBtnMoneyText = child.GetChild(2).GetComponent<UIText>();
		this.backOutBtnMoneyText.font = GUIManager.Instance.GetTTFFont();
		this.backOutBtn = child.GetComponent<UIButton>();
		this.backOutBtn.m_BtnID1 = 1;
		this.backOutBtn.m_Handler = this;
		child = gameObject.transform.GetChild(12);
		this.upgradeBtnRect = child.GetComponent<RectTransform>();
		this.btnBGSpArray = child.GetComponent<UISpritesArray>();
		this.upgradeBtnBGImage = child.GetComponent<Image>();
		this.upgradeBtnImageRt = child.GetChild(0).GetComponent<RectTransform>();
		this.upgradeBtnText = child.GetChild(1).GetComponent<UIText>();
		this.upgradeBtnImage = child.GetChild(0).GetComponent<Image>();
		this.upgradeBtnText.font = GUIManager.Instance.GetTTFFont();
		this.upgradeBtn = gameObject.transform.GetChild(12).GetComponent<UIButton>();
		this.upgradeBtn.m_BtnID1 = 2;
		this.upgradeBtn.m_Handler = this;
		this.upgradeBtnTf = child;
		this.buildInfo = gameObject.transform.GetChild(9).GetChild(0).GetComponent<UIButton>();
		this.buildInfo.m_BtnID1 = 0;
		this.buildInfo.m_Handler = this;
		this.statistics = gameObject.transform.GetChild(9).GetChild(1).GetComponent<UIButton>();
		this.statistics.m_BtnID1 = 4;
		this.statistics.m_Handler = this;
		this.upgradePanelTitle = gameObject.transform.GetChild(16);
		this.upgradeScrollPanelTitle = gameObject.transform.GetChild(16).GetChild(1).GetComponent<UIText>();
		this.infoPanelTitle = gameObject.transform.GetChild(20);
		this.upgradeInfoScrollPanelTitle = gameObject.transform.GetChild(20).GetChild(1).GetComponent<UIText>();
		this.upgradePanelItem = gameObject.transform.GetChild(22);
		this.updateTimePanel = gameObject.transform.GetChild(21);
		this.timeTextTf1 = this.updateTimePanel.GetChild(0);
		this.timeTitleTf1 = this.updateTimePanel.GetChild(2);
		this.timeTextTf2 = this.updateTimePanel.GetChild(1);
		this.timeTitleTf2 = this.updateTimePanel.GetChild(3);
		this.updateTimeText1 = this.timeTextTf1.GetComponent<UIText>();
		this.updateTimeText2 = this.timeTextTf2.GetComponent<UIText>();
		this.updateTimeText1.font = GUIManager.Instance.GetTTFFont();
		this.updateTimeText2.font = GUIManager.Instance.GetTTFFont();
		UIText component2 = this.updateTimePanel.GetChild(2).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(3945u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.updateTimePanel.GetChild(3).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(3946u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_Mat = gameObject.transform.GetChild(23).GetChild(1).GetComponent<Image>().material;
		this.timeBar = gameObject.transform.GetChild(24).GetComponent<UITimeBar>();
		GUIManager.Instance.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.NormalType, string.Empty, string.Empty);
		GUIManager.Instance.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Free);
		this.timeBar.m_Handler = this;
		this.timeBar.m_TimeBarID = 1;
		this.timeBar.gameObject.SetActive(false);
		this.customCastleTf = gameObject.transform.GetChild(25);
		UIButton component3 = this.customCastleTf.GetComponent<UIButton>();
		component3.m_BtnID1 = 5;
		component3.m_Handler = this;
		component = this.customCastleTf.GetComponent<Image>();
		component.sprite = this.btnBGSpArray.m_Sprites[1];
		component = this.customCastleTf.GetChild(0).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_castle_icon_01");
		component.material = this.door.LoadMaterial();
		component.rectTransform.anchoredPosition = new Vector2(10f, -10f);
		component.SetNativeSize();
		this.exclamationTf = this.customCastleTf.GetChild(1);
		component = this.exclamationTf.GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_redbox_01");
		component.material = this.door.LoadMaterial();
		component = this.exclamationTf.GetChild(0).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_mess_ex_dark");
		component.material = this.door.LoadMaterial();
		component = this.exclamationTf.GetChild(0).GetChild(0).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_mess_ex_light");
		component.material = this.door.LoadMaterial();
		this.upgradeScrollPanel = gameObject.transform.GetChild(17).GetComponent<ScrollPanel>();
		this.infoScrollPanel = gameObject.transform.GetChild(19).GetComponent<ScrollPanel>();
		this.maxLvImage = gameObject.transform.GetChild(13);
		this.maxLvImageRotate = this.maxLvImage.GetChild(0);
		UIText component4 = this.maxLvImage.GetChild(2).GetComponent<UIText>();
		component4.font = GUIManager.Instance.GetTTFFont();
		component4.text = DataManager.Instance.mStringTable.GetStringByID(3831u);
		this.m_TempText[this.m_TempTextIdx++] = component4;
		GUIManager.Instance.AddSpriteAsset("BuildingWindow");
		this.uiMat = GUIManager.Instance.LoadMaterial("BuildingWindow", "BuildingWindow_m");
		this.tempString = StringManager.Instance.SpawnString(30);
		this.tempString3 = StringManager.Instance.SpawnString(30);
		this.tempString2 = StringManager.Instance.SpawnString(30);
		this.effectString = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x0600292A RID: 10538 RVA: 0x0044F1DC File Offset: 0x0044D3DC
	public void InitBuildingWindow(byte _buildID, ushort _manorID, byte _Style = 0, byte _buildLv = 1)
	{
		this.bIsTechWindow = false;
		this.buildID = _buildID;
		this.manorID = _manorID;
		this.style = _Style;
		this.buildLv = _buildLv;
		if (_buildID == 16)
		{
			this.buildLvMAx = 9;
		}
		this.m_UpgradeItem = new UpgradeItemObject[10];
		for (int i = 0; i < this.m_UpgradeItem.Length; i++)
		{
			this.m_UpgradeItem[i] = new UpgradeItemObject();
		}
		this.titleText.font = GUIManager.Instance.GetTTFFont();
		BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey((ushort)this.buildID);
		this.titleText.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.NameID);
		this.iconSpriteName = new string[]
		{
			"UI_main_res_house",
			"UI_main_res_food",
			"UI_main_res_stone",
			"UI_main_res_wood",
			"UI_main_res_iron",
			"UI_main_money_01",
			"UI_main_art_butt_up",
			"UI_main_art_butt_plus",
			"UI_main_res_noputup",
			"UI_main_xxx",
			"UI_main_art_butt_go",
			"UI_main_art_butt_go_icon"
		};
		this.iconBulidSpriteName = new string[]
		{
			string.Empty,
			"UI_main_res_wood",
			"UI_main_res_stone",
			"UI_main_res_iron",
			"UI_main_res_food",
			"UI_main_money_01"
		};
		this.upgradeScrollPanelTitle.font = GUIManager.Instance.GetTTFFont();
		this.upgradeScrollPanelTitle.text = DataManager.Instance.mStringTable.GetStringByID(3818u);
		this.upgradeInfoScrollPanelTitle.font = GUIManager.Instance.GetTTFFont();
		this.upgradeInfoScrollPanelTitle.text = DataManager.Instance.mStringTable.GetStringByID(3817u);
		this.upgradePanelData = new List<BuildInfoObject>();
		this.upgradeEffectData = new List<BuildInfoObject2>();
		if ((int)this.manorID < GUIManager.Instance.BuildingData.AllBuildsData.Length)
		{
			recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey(GUIManager.Instance.BuildingData.AllBuildsData[(int)this.manorID].BuildID);
		}
		DataManager.Instance.GetQueueBarTitle(EQueueBarIndex.Building, this.sb, ref this.m_TimeBarStr1, ref this.m_TimeBarStr2);
		if (_buildID == 6 || _buildID == 12)
		{
			this.statistics.gameObject.SetActive(true);
		}
		else
		{
			this.statistics.gameObject.SetActive(false);
		}
		if (GUIManager.Instance.GuideParm1 == 1 || GUIManager.Instance.GuideParm1 == 2)
		{
			if ((GUIManager.Instance.GuideParm1 == 1 && GUIManager.Instance.GuideParm2 == (ushort)_buildID) || (GUIManager.Instance.GuideParm1 == 2 && GUIManager.Instance.GuideParm2 == this.manorID))
			{
				this.GuideParm2 = GUIManager.Instance.GuideParm2;
				RectTransform component = this.upgradeBtn.gameObject.GetComponent<RectTransform>();
				GUIManager.Instance.GuideArrow(component, ArrowDirect.Ar_Up, 0f);
			}
			else
			{
				GUIManager.Instance.HideArrow(true);
				this.GuideParm2 = 0;
			}
		}
		this.MyUpdate(0, true);
		DataManager.Instance.OpenBagFilterByBuildingWindow = 0;
		DataManager.Instance.OpenBuildingWindowUpdateNoClose = 0;
	}

	// Token: 0x0600292B RID: 10539 RVA: 0x0044F530 File Offset: 0x0044D730
	public void InitTechWindow(byte _techID, byte _techLv)
	{
		this.bIsTechWindow = true;
		this.techID = _techID;
		this.techLv = _techLv;
		this.m_UpgradeItem = new UpgradeItemObject[10];
		for (int i = 0; i < this.m_UpgradeItem.Length; i++)
		{
			this.m_UpgradeItem[i] = new UpgradeItemObject();
		}
		TechDataTbl recordByKey = DataManager.Instance.TechData.GetRecordByKey((ushort)this.techID);
		this.titleText.font = GUIManager.Instance.GetTTFFont();
		this.titleText.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.TechName);
		this.iconSpriteName = new string[]
		{
			"UI_main_res_house",
			"UI_main_res_food",
			"UI_main_res_stone",
			"UI_main_res_wood",
			"UI_main_res_iron",
			"UI_main_money_01",
			"UI_main_art_butt_up",
			"UI_main_art_butt_plus",
			"UI_main_res_noputup",
			"UI_main_xxx",
			"UI_main_art_butt_go",
			"UI_main_art_butt_go_icon"
		};
		this.iconBulidSpriteName = new string[]
		{
			string.Empty,
			"UI_main_res_wood",
			"UI_main_res_stone",
			"UI_main_res_iron",
			"UI_main_res_food",
			"UI_main_money_01"
		};
		this.upgradeScrollPanelTitle.font = GUIManager.Instance.GetTTFFont();
		this.upgradeScrollPanelTitle.text = DataManager.Instance.mStringTable.GetStringByID(3818u);
		this.upgradeInfoScrollPanelTitle.font = GUIManager.Instance.GetTTFFont();
		this.upgradeInfoScrollPanelTitle.text = DataManager.Instance.mStringTable.GetStringByID(3817u);
		this.upgradePanelData = new List<BuildInfoObject>();
		this.upgradeEffectData = new List<BuildInfoObject2>();
		this.MyUpdate(0, true);
		DataManager.Instance.OpenBagFilterByBuildingWindow = 0;
	}

	// Token: 0x0600292C RID: 10540 RVA: 0x0044F710 File Offset: 0x0044D910
	private void Update()
	{
		if (this.maxLvImage.gameObject.activeSelf)
		{
			this.maxLvImageRotate.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		if (this.m_bNeedShow)
		{
			this.m_updateTime = this.m_BuildEndTime - DataManager.Instance.ServerTime;
			this.m_TimeTick += Time.deltaTime;
			if (this.m_TimeTick >= 1f)
			{
				this.m_TimeTick = 0f;
				this.m_updateTime -= 1L;
				if (this.m_updateTime > 0L)
				{
					for (int i = 0; i < this.m_UpgradeItem.Length; i++)
					{
						if (this.m_UpgradeItem[i].upgradeScrollPanelIconType == 6 && this.m_UpgradeItem[i].m_UpgradeItemTimeTexts.gameObject.activeSelf)
						{
							eTimerSpriteType eTimerSpriteType;
							if (!this.bIsTechWindow)
							{
								eTimerSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Building);
							}
							else
							{
								eTimerSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Researching);
							}
							if (eTimerSpriteType == eTimerSpriteType.Speed && this.m_updateTime <= (long)DataManager.Instance.GetFreeCompleteTime())
							{
								byte b;
								this.bUpdateFreeState = (b = this.bUpdateFreeState) + 1;
								if (b == 0)
								{
									if (this.bIsTechWindow)
									{
										eTimerSpriteType = eTimerSpriteType.Free;
									}
									else if (GUIManager.Instance.BuildingData.QueueBuildType == 1)
									{
										eTimerSpriteType = eTimerSpriteType.Free;
									}
								}
							}
							if (this.m_UpgradeItem[i].timerSpriteType != eTimerSpriteType)
							{
								this.SetTimeBarBtnSprite(eTimerSpriteType, i);
							}
							int ss = (int)this.m_updateTime % 60;
							int mm = (int)(this.m_updateTime / 60L) % 60;
							int hh = (int)(this.m_updateTime / 3600L) % 24;
							int dd = (int)this.m_updateTime / 86400;
							this.SetTime(dd, hh, mm, ss, this.tempString2, this.m_UpgradeItem[i].m_UpgradeItemTimeTexts);
							break;
						}
					}
				}
				else
				{
					this.totalUpgradeCount--;
					List<float> list = new List<float>();
					for (int j = 0; j < this.totalUpgradeCount; j++)
					{
						list.Add(59f);
					}
					this.upgradeScrollPanel.AddNewDataHeight(list, false, true);
					this.m_bNeedShow = false;
				}
			}
		}
		this.m_ResTimeTick += Time.deltaTime;
		if (this.m_ResTimeTick >= 1f)
		{
			bool flag = true;
			this.m_bGeneralConform_update = true;
			int num = 0;
			while (num < this.m_UpgradeItem.Length && num < this.upgradePanelData.Count)
			{
				int upgradeScrollPanelIconType = (int)this.m_UpgradeItem[num].upgradeScrollPanelIconType;
				int upgradeScrollPanelIconIdx = this.m_UpgradeItem[num].upgradeScrollPanelIconIdx;
				if (upgradeScrollPanelIconType == 8)
				{
					if (this.bIsTechWindow)
					{
						byte lv = (byte)Mathf.Clamp((int)(this.techLv + 1), 1, (int)this.techLvMax);
						bool flag2 = this.GetPetResourceStr(out this.upgradePanelData[upgradeScrollPanelIconIdx].text, this.techID, lv, out this.upgradePanelData[upgradeScrollPanelIconIdx].value);
						this.m_UpgradeItem[num].m_UpgradeItemTexts.text = this.upgradePanelData[upgradeScrollPanelIconIdx].text;
						if (!flag2)
						{
							flag = false;
						}
					}
				}
				else if (upgradeScrollPanelIconType > 0 && upgradeScrollPanelIconType <= 5)
				{
					bool flag2;
					if (this.bIsTechWindow)
					{
						byte lv = (byte)Mathf.Clamp((int)(this.techLv + 1), 1, (int)this.techLvMax);
						flag2 = this.GetResStr_Tech((ResourceType)((byte)upgradeScrollPanelIconType - 1), out this.upgradePanelData[upgradeScrollPanelIconIdx].text, this.techID, lv, out this.upgradePanelData[upgradeScrollPanelIconIdx].value);
						this.m_UpgradeItem[num].m_UpgradeItemTexts.text = this.upgradePanelData[upgradeScrollPanelIconIdx].text;
						if (!flag2)
						{
							flag = false;
						}
					}
					else
					{
						byte lv = (byte)Mathf.Clamp((int)(this.buildLv + 1), 1, (int)this.buildLvMAx);
						flag2 = this.GetResStr((ResourceType)((byte)upgradeScrollPanelIconType - 1), out this.upgradePanelData[upgradeScrollPanelIconIdx].text, this.buildID, lv, out this.upgradePanelData[upgradeScrollPanelIconIdx].value);
						this.m_UpgradeItem[num].m_UpgradeItemTexts.text = this.upgradePanelData[upgradeScrollPanelIconIdx].text;
						if (!flag2)
						{
							flag = false;
						}
					}
					if (this.m_UpgradeItem[num].m_UpgradeItemImageXs && this.m_UpgradeItem[num].m_UpgradeItemBtnImages)
					{
						this.m_UpgradeItem[num].m_UpgradeItemImageXs.enabled = !flag2;
						this.m_UpgradeItem[num].m_UpgradeItemBtnImages.enabled = !flag2;
					}
					if (!flag)
					{
						this.m_bGeneralConform_update = false;
					}
				}
				else if (upgradeScrollPanelIconType == 6 && this.m_UpgradeItem[num].upgradeScrollPanelbConform)
				{
					this.m_UpgradeItem[num].m_UpgradeItemImageXs.enabled = true;
					this.m_UpgradeItem[num].m_UpgradeItemBtnImages.enabled = true;
					this.upgradePanelData[upgradeScrollPanelIconIdx].btnType = 0;
				}
				num++;
			}
			if (this.backOutBtnType == e_FuncBtnType.AtOnce_Upgrade || this.backOutBtnType == e_FuncBtnType.AtOnce_Build || this.backOutBtnType == e_FuncBtnType.AtOnce_Research)
			{
				uint costCrystal = this.GetCostCrystal();
				this.sb.Length = 0;
				this.sb.AppendFormat("{0:N0}", costCrystal);
				this.backOutBtnMoneyText.text = this.sb.ToString();
			}
			this.CheckBtnState(this.upgradeBtnType);
			this.m_ResTimeTick = 0f;
		}
		if (this.m_TickBeginAnimBtnTime <= 2f)
		{
			this.m_TickBeginAnimBtnTime += Time.deltaTime;
		}
		if (this.m_TickBeginAnimBtnTime >= 2f && this.m_TickEndAnimBtnTime <= 1f)
		{
			this.m_TickEndAnimBtnTime += Time.deltaTime;
		}
		int num2 = 0;
		while (num2 < this.m_UpgradeItem.Length && num2 < this.upgradePanelData.Count)
		{
			int upgradeScrollPanelIconIdx2 = this.m_UpgradeItem[num2].upgradeScrollPanelIconIdx;
			if (this.m_UpgradeItem[num2] != null && this.m_UpgradeItem[num2].m_TweenRotation != null)
			{
				if (this.upgradePanelData[upgradeScrollPanelIconIdx2].btnType == 4 && this.m_TickBeginAnimBtnTime >= 2f)
				{
					if (!this.m_UpgradeItem[num2].m_TweenRotation.enabled)
					{
						this.m_UpgradeItem[num2].m_TweenRotation.enabled = true;
						this.m_UpgradeItem[num2].m_TweenRotation.factor = 0f;
					}
					float num3 = 0.1f;
					if (this.m_TickEndAnimBtnTime >= 1f && Mathf.Abs(this.m_UpgradeItem[num2].m_UpgradeItemBtnRect.localRotation.z) <= num3)
					{
						this.m_TickEndAnimBtnTime = 0f;
						this.m_TickBeginAnimBtnTime = 0f;
					}
				}
				else
				{
					this.m_UpgradeItem[num2].m_UpgradeItemBtnRect.localRotation = default(Quaternion);
					this.m_UpgradeItem[num2].m_TweenRotation.enabled = false;
				}
			}
			num2++;
		}
	}

	// Token: 0x0600292D RID: 10541 RVA: 0x0044FE94 File Offset: 0x0044E094
	public void SetUIPos(int style)
	{
		if (style == 2)
		{
			if (this.buildID == 8 || this.buildID == 21)
			{
				this.mainTransform_H.GetComponent<Image>().gameObject.SetActive(true);
				this.mainTransform_H.GetComponent<Image>().enabled = false;
				this.mainTransform_Bg.gameObject.SetActive(true);
				this.mainTransform_Bg2.gameObject.SetActive(true);
				this.mainTransform_V.gameObject.SetActive(false);
			}
			else
			{
				this.mainTransform_Bg.gameObject.SetActive(false);
				this.mainTransform_Bg2.gameObject.SetActive(false);
				this.mainTransform_V.gameObject.SetActive(false);
				this.mainTransform_H.gameObject.SetActive(true);
			}
			this.buildingTransformBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(-241.5f, -236.5f);
			this.uiButtonTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(-101f, -270f);
			this.buildingLvBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(-241.5f, -290f);
			this.updateTimePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(55f, -192f);
		}
		else
		{
			this.mainTransform_Bg.gameObject.SetActive(false);
			this.mainTransform_Bg2.gameObject.SetActive(false);
			this.mainTransform_V.gameObject.SetActive(true);
			this.mainTransform_H.gameObject.SetActive(false);
			this.buildingTransformBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(223.5f, 121.5f);
			this.uiButtonTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(363f, 86f);
			this.buildingLvBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(212f, 78f);
			this.updateTimePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(254f, -163f);
		}
	}

	// Token: 0x0600292E RID: 10542 RVA: 0x004500A8 File Offset: 0x0044E2A8
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		int arg3 = 101;
		switch (arg1)
		{
		case 101:
			this.bOpenBackOutCheckBox = false;
			if (bOK)
			{
				if (arg2 != 1)
				{
					if (arg2 == 2)
					{
						if (DataManager.Instance.queueBarData[0].bActive)
						{
							GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(3969u), DataManager.Instance.mStringTable.GetStringByID(3970u), 102, 1, DataManager.Instance.mStringTable.GetStringByID(4024u), DataManager.Instance.mStringTable.GetStringByID(4025u));
						}
						else
						{
							GUIManager.Instance.BuildingData.sendBuildDismantle(this.manorID);
						}
					}
				}
				else if (DataManager.Instance.GetCurItemQuantity(1076, 0) > 0)
				{
					GUIManager.Instance.BuildingData.sendBuildDismantleImmediate(this.manorID);
				}
				else if (DataManager.Instance.RoleAttr.Diamond >= this.m_BackOutCostCrystal)
				{
					GUIManager.Instance.BuildingData.sendBuildDismantleImmediate(this.manorID);
				}
				else
				{
					this.sb.Length = 0;
					if (this.backOutBtnType == e_FuncBtnType.BackOut)
					{
						this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3857u), DataManager.Instance.mStringTable.GetStringByID(3828u));
					}
					GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3966u), this.sb.ToString(), DataManager.Instance.mStringTable.GetStringByID(3968u), this, 103, 0, true, false, false, false, false);
				}
			}
			break;
		case 102:
			if (bOK)
			{
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 0, false);
			}
			break;
		case 103:
			if (bOK)
			{
				MallManager.Instance.Send_Mall_Info();
			}
			break;
		case 104:
			if (this.bIsTechWindow)
			{
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 1, false);
			}
			break;
		case 105:
			if (bOK)
			{
				if (GUIManager.Instance.BuildingData.BuildingManorID == this.manorID)
				{
					GUIManager.Instance.BuildingData.sendBuildFinish();
				}
				else if (!GUIManager.Instance.OpenCheckCrystal(this.GetCostCrystal(), 4, (int)this.manorID, (int)this.buildID))
				{
					GUIManager.Instance.BuildingData.sendBuildCompleteImmediate(this.manorID, (ushort)this.buildID);
				}
			}
			break;
		case 106:
			if (bOK)
			{
				if (this.upgradeBtnType == e_FuncBtnType.Speed)
				{
					GUIManager.Instance.BuildingData.sendStartBuilding(this.manorID, (ushort)this.buildID);
				}
				else if (this.upgradeBtnType == e_FuncBtnType.Free)
				{
					GUIManager.Instance.BuildingData.sendBuildCompleteFree();
				}
				if (this.upgradeBtnType == e_FuncBtnType.Upgrade || this.upgradeBtnType == e_FuncBtnType.Build)
				{
					GUIManager.Instance.BuildingData.sendStartBuilding(this.manorID, (ushort)this.buildID);
				}
			}
			break;
		case 107:
			if (bOK)
			{
				if (GUIManager.Instance.BuildingData.BuildingManorID == this.manorID)
				{
					GUIManager.Instance.BuildingData.sendBuildFinish();
				}
				else if (!GUIManager.Instance.OpenCheckCrystal(this.GetCostCrystal(), 4, (int)this.manorID, (int)this.buildID))
				{
					GUIManager.Instance.BuildingData.sendBuildCompleteImmediate(this.manorID, (ushort)this.buildID);
				}
			}
			break;
		case 108:
			if (bOK)
			{
				if (this.upgradeBtnType == e_FuncBtnType.Speed)
				{
					GUIManager.Instance.BuildingData.sendStartBuilding(this.manorID, (ushort)this.buildID);
				}
				else if (this.upgradeBtnType == e_FuncBtnType.Free)
				{
					GUIManager.Instance.BuildingData.sendBuildCompleteFree();
				}
				if (this.upgradeBtnType == e_FuncBtnType.Upgrade || this.upgradeBtnType == e_FuncBtnType.Build)
				{
					GUIManager.Instance.BuildingData.sendStartBuilding(this.manorID, (ushort)this.buildID);
				}
			}
			break;
		default:
			switch (arg1)
			{
			case 0:
			case 1:
				if (bOK)
				{
					if (GUIManager.Instance.BuildingData.QueueBuildType == 1)
					{
						GUIManager.Instance.BuildingData.sendBuildingCancel();
					}
					else
					{
						GUIManager.Instance.BuildingData.sendBuildDismantleCancel();
					}
				}
				this.bOpenBackOutCheckBox = false;
				break;
			default:
				if (arg1 == 14)
				{
					if (bOK)
					{
						DataManager.Instance.sendTechnologyResearchCancel();
					}
				}
				break;
			case 5:
			{
				int arg4;
				if (bOK)
				{
					arg4 = 1;
				}
				else
				{
					arg4 = 2;
				}
				uint strength = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort)this.buildID, this.buildLv).Strength;
				this.sb.Length = 0;
				this.bOpenBackOutCheckBox = true;
				BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey((ushort)this.buildID);
				if (recordByKey.Kind == 1 || recordByKey.Kind == 2 || recordByKey.Kind == 6)
				{
					this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3963u), strength);
					GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(3962u), this.sb.ToString(), arg3, arg4, DataManager.Instance.mStringTable.GetStringByID(4021u), DataManager.Instance.mStringTable.GetStringByID(4022u));
				}
				break;
			}
			}
			break;
		}
	}

	// Token: 0x0600292F RID: 10543 RVA: 0x00450680 File Offset: 0x0044E880
	public void OnButtonClick(UIButton sender)
	{
		this.GuideParm2 = 0;
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		int btnID = sender.m_BtnID1;
		switch (btnID)
		{
		case 0:
			if (this.buildID == 20)
			{
				GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(12110u), DataManager.Instance.mStringTable.GetStringByID(12117u), null, null, 0, 0, true, true);
			}
			else
			{
				if (this.buildID == 12 || this.buildID == 6)
				{
					GUIManager.Instance.BuildingData.GuideSoldierID = 0;
				}
				if (this.buildType == e_BuildType.Upgrade || this.buildType == e_BuildType.Upgrade_Tech || this.buildType == e_BuildType.Upgradeing)
				{
					DataManager.Instance.OpenBagFilterByBuildingWindow = 1;
				}
				if (this.bIsTechWindow)
				{
					this.door.OpenMenu(EGUIWindow.UI_Information, -1, (int)this.techID, false);
				}
				else
				{
					this.door.OpenMenu(EGUIWindow.UI_Information, (int)this.buildID, (int)this.manorID, false);
				}
			}
			break;
		case 1:
			if (!this.bIsTechWindow)
			{
				if (sender.m_BtnID2 == 101)
				{
					GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5707u), DataManager.Instance.mStringTable.GetStringByID(5702u), null, null, 0, 0, false, false, false, false, false);
				}
				else if (sender.m_BtnID2 == 102)
				{
					GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5707u), DataManager.Instance.mStringTable.GetStringByID(12104u), null, null, 0, 0, false, false, false, false, false);
				}
				else if (sender.m_BtnID2 != 100)
				{
					if (this.backOutBtnType == e_FuncBtnType.Cancel)
					{
						GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(12049u), DataManager.Instance.mStringTable.GetStringByID(3961u), 0, 0, DataManager.Instance.mStringTable.GetStringByID(3964u), DataManager.Instance.mStringTable.GetStringByID(3965u));
					}
					else if (this.backOutBtnType == e_FuncBtnType.Cancel_BackOut)
					{
						this.bOpenBackOutCheckBox = true;
						GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(12050u), DataManager.Instance.mStringTable.GetStringByID(3921u), 1, 0, DataManager.Instance.mStringTable.GetStringByID(3964u), DataManager.Instance.mStringTable.GetStringByID(3965u));
					}
					else if (this.backOutBtnType == e_FuncBtnType.BackOut)
					{
						uint num = 0u;
						for (byte b = 1; b <= this.buildLv; b += 1)
						{
							num += GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort)this.buildID, b).BuildTime;
						}
						uint effectBaseVal;
						uint effectBaseVal2;
						if (this.bIsTechWindow)
						{
							effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESEARCH_SPEED);
							effectBaseVal2 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESEARCH_SPEED_DEBUFF);
						}
						else
						{
							effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_CONSTRUCTION_SPEED);
							effectBaseVal2 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_CONSTRUCTION_SPEED_DEBUFF);
						}
						long num3;
						if (effectBaseVal >= effectBaseVal2)
						{
							uint num2 = effectBaseVal - effectBaseVal2;
							num3 = (long)((ulong)num * 10000UL / ((ulong)num2 + 10000UL) + (ulong)((long)Mathf.Clamp((int)((ulong)num * 10000UL % ((ulong)num2 + 10000UL)), 0, 1)));
						}
						else
						{
							uint num2 = effectBaseVal2 - effectBaseVal;
							if (num2 > 9900u)
							{
								num2 = 9900u;
							}
							num3 = (long)((ulong)num * 10000UL / (10000UL - (ulong)num2) + (ulong)((long)Mathf.Clamp((int)((ulong)num * 10000UL % (10000UL - (ulong)num2)), 0, 1)));
						}
						this.m_BackOutTime = (uint)(num3 / 2L + (long)Mathf.Clamp((int)(num3 % 2L), 0, 1));
						if (this.m_BackOutTime < 300u)
						{
							this.m_BackOutTime = 300u;
						}
						int num4 = (int)(this.m_BackOutTime % 60u);
						int num5 = (int)(this.m_BackOutTime / 60u % 60u);
						int num6 = (int)(this.m_BackOutTime / 3600u % 24u);
						int num7 = (int)(this.m_BackOutTime / 86400u);
						ushort inKey = DataManager.Instance.TotalShopItemData.Find(1076);
						this.m_BackOutCostCrystal = DataManager.Instance.StoreData.GetRecordByKey(inKey).Price;
						GUIManager.Instance.OpenSpendWindow_ItemID2(this, DataManager.Instance.mStringTable.GetStringByID(3922u), 1076, 1075, this.m_BackOutCostCrystal, (ushort)num7, (byte)num6, (byte)num5, (byte)num4, true, 5, 0, DataManager.Instance.mStringTable.GetStringByID(5788u), DataManager.Instance.mStringTable.GetStringByID(5786u), DataManager.Instance.mStringTable.GetStringByID(5787u));
					}
					else if (this.backOutBtnType == e_FuncBtnType.AtOnce_Upgrade || this.backOutBtnType == e_FuncBtnType.AtOnce_Build)
					{
						uint costCrystal = this.GetCostCrystal();
						if (DataManager.Instance.RoleAttr.Diamond >= costCrystal)
						{
							if (this.buildID == 8 && this.buildLv == 8 && DataManager.Instance.HasNewbieShield())
							{
								this.OpenCheckBycastleLv8(107);
							}
							else if (GUIManager.Instance.BuildingData.BuildingManorID == this.manorID)
							{
								GUIManager.Instance.BuildingData.sendBuildFinish();
							}
							else if (!GUIManager.Instance.OpenCheckCrystal(costCrystal, 4, (int)this.manorID, (int)this.buildID))
							{
								GUIManager.Instance.BuildingData.sendBuildCompleteImmediate(this.manorID, (ushort)this.buildID);
							}
						}
						else
						{
							this.sb.Length = 0;
							if (this.backOutBtnType == e_FuncBtnType.AtOnce_Upgrade)
							{
								this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3857u), DataManager.Instance.mStringTable.GetStringByID(3822u));
							}
							if (this.backOutBtnType == e_FuncBtnType.AtOnce_Build)
							{
								this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3857u), DataManager.Instance.mStringTable.GetStringByID(3820u));
							}
							GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3966u), this.sb.ToString(), DataManager.Instance.mStringTable.GetStringByID(3968u), this, 103, 0, true, false, false, false, false);
						}
					}
				}
				else if (DataManager.Instance.queueBarData[0].bActive)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(3819u), 255, true);
				}
				else
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5771u), 255, true);
				}
			}
			else if (sender.m_BtnID2 != 100)
			{
				if (this.backOutBtnType == e_FuncBtnType.AtOnce_Research)
				{
					uint costCrystal2 = this.GetCostCrystal();
					if (DataManager.Instance.RoleAttr.Diamond >= costCrystal2)
					{
						if (!GUIManager.Instance.OpenCheckCrystal(costCrystal2, 3, (int)this.techID, -1))
						{
							DataManager.Instance.sendTechnologyResearchCompleteImmediate((ushort)this.techID);
						}
					}
					else
					{
						GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(3966u), DataManager.Instance.mStringTable.GetStringByID(646u), 103, 0, DataManager.Instance.mStringTable.GetStringByID(3968u), DataManager.Instance.mStringTable.GetStringByID(4025u));
					}
				}
				else if (this.backOutBtnType == e_FuncBtnType.Cancel_Research)
				{
					GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(5023u), DataManager.Instance.mStringTable.GetStringByID(5024u), 14, 0, DataManager.Instance.mStringTable.GetStringByID(5026u), DataManager.Instance.mStringTable.GetStringByID(5025u));
				}
			}
			else
			{
				CString cstring = StringManager.Instance.StaticString1024();
				if (DataManager.Instance.queueBarData[1].bActive)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5017u), 255, true);
				}
				else if (!DataManager.Instance.CheckTechKind((ushort)DataManager.Instance.TechData.GetRecordByKey((ushort)this.techID).Kind, cstring))
				{
					GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
				}
				else
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5771u), 255, true);
				}
			}
			break;
		case 2:
			if (sender.m_BtnID2 != 100)
			{
				if (!this.bIsTechWindow)
				{
					if (this.buildID == 12 || this.buildID == 6)
					{
						GUIManager.Instance.BuildingData.GuideSoldierID = 0;
					}
					if (this.buildType == e_BuildType.Normal)
					{
						if (this.manorID == GUIManager.Instance.BuildingData.BuildingManorID && this.buildID != 0)
						{
							this.SetBuildType(e_BuildType.Upgradeing, eTimerSpriteType.Speed);
						}
						else
						{
							this.SetBuildType(e_BuildType.Upgrade, eTimerSpriteType.Speed);
						}
					}
					else if (this.buildType == e_BuildType.Upgrade)
					{
						if (GUIManager.Instance.BuildingData.CheckLevelupRule((ushort)this.buildID, this.buildLv + 1) == 0)
						{
							if (this.buildID == 8 && this.buildLv == 8 && DataManager.Instance.HasNewbieShield())
							{
								this.OpenCheckBycastleLv8(108);
							}
							else
							{
								GUIManager.Instance.HideArrow(false);
								if (this.upgradeBtnType == e_FuncBtnType.Speed)
								{
									GUIManager.Instance.BuildingData.sendStartBuilding(this.manorID, (ushort)this.buildID);
								}
								else if (this.upgradeBtnType == e_FuncBtnType.Free)
								{
									GUIManager.Instance.BuildingData.sendBuildCompleteFree();
								}
								if (this.upgradeBtnType == e_FuncBtnType.Upgrade || this.upgradeBtnType == e_FuncBtnType.Build)
								{
									GUIManager.Instance.BuildingData.sendStartBuilding(this.manorID, (ushort)this.buildID);
								}
							}
						}
					}
					else if (this.upgradeBtnType == e_FuncBtnType.Speed)
					{
						this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 0, false);
					}
					else if (this.upgradeBtnType == e_FuncBtnType.Free)
					{
						GUIManager.Instance.BuildingData.sendBuildCompleteFree();
					}
					else if (this.upgradeBtnType == e_FuncBtnType.Help)
					{
						DataManager.Instance.SendAllianceHelp(1);
					}
				}
				else if (this.buildType == e_BuildType.Upgrade_Tech)
				{
					if (DataManager.Instance.ResearchTech > 0)
					{
						this.sb.Length = 0;
						TechDataTbl recordByKey = DataManager.Instance.TechData.GetRecordByKey(DataManager.Instance.ResearchTech);
						this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(5028u), DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.TechName));
						GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(5027u), this.sb.ToString(), 104, 0, DataManager.Instance.mStringTable.GetStringByID(5025u), DataManager.Instance.mStringTable.GetStringByID(5026u));
					}
					else if (this.upgradeBtnType == e_FuncBtnType.Research)
					{
						DataManager.Instance.sendTechnologyResearchStart((ushort)this.techID);
					}
					else if (this.upgradeBtnType == e_FuncBtnType.Free)
					{
						DataManager.Instance.sendTechnologyCompleteFree();
					}
				}
				else if (this.buildType == e_BuildType.Upgradeing_Tech)
				{
					if (this.upgradeBtnType == e_FuncBtnType.Free)
					{
						DataManager.Instance.sendTechnologyCompleteFree();
					}
					else if (this.upgradeBtnType == e_FuncBtnType.Speed)
					{
						this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 1, false);
					}
					else if (this.upgradeBtnType == e_FuncBtnType.Help)
					{
						DataManager.Instance.SendAllianceHelp(0);
					}
				}
			}
			else
			{
				if (!this.bIsTechWindow)
				{
					if (DataManager.Instance.queueBarData[0].bActive)
					{
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(3819u), 255, true);
					}
					else
					{
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5771u), 255, true);
					}
				}
				else
				{
					CString cstring2 = StringManager.Instance.StaticString1024();
					if (DataManager.Instance.queueBarData[1].bActive)
					{
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5017u), 255, true);
					}
					else if (!DataManager.Instance.CheckTechKind((ushort)DataManager.Instance.TechData.GetRecordByKey((ushort)this.techID).Kind, cstring2))
					{
						GUIManager.Instance.AddHUDMessage(cstring2.ToString(), 255, true);
					}
					else
					{
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5771u), 255, true);
					}
				}
				GUIManager.Instance.HideArrow(false);
			}
			break;
		case 3:
			this.Exit();
			break;
		case 4:
		{
			if (this.buildID == 12 || this.buildID == 6)
			{
				GUIManager.Instance.BuildingData.GuideSoldierID = 0;
			}
			byte b2 = this.buildID;
			if (b2 != 6)
			{
				if (b2 == 12)
				{
					this.door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 2, 0, false);
					DataManager.Instance.OpenBagFilterByBuildingWindow = this.CheckNowOpenEBuildTypeWindow(this.buildType);
					DataManager.Instance.OriginalBuildType = this.buildType;
				}
			}
			else
			{
				this.door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 3, 0, false);
				DataManager.Instance.OpenBagFilterByBuildingWindow = this.CheckNowOpenEBuildTypeWindow(this.buildType);
				DataManager.Instance.OriginalBuildType = this.buildType;
			}
			break;
		}
		case 5:
			this.door.OpenMenu(EGUIWindow.UI_CastleSkin, 0, 0, true);
			break;
		default:
			switch (btnID)
			{
			case 101:
			{
				eTimerSpriteType queueBarSpriteType;
				if (!this.bIsTechWindow)
				{
					queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Building);
				}
				else
				{
					queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Researching);
				}
				if (queueBarSpriteType == eTimerSpriteType.Free)
				{
					DataManager.Instance.OpenBuildingWindowUpdateNoClose = 1;
					if (this.bIsTechWindow)
					{
						DataManager.Instance.sendTechnologyCompleteFree();
					}
					else
					{
						GUIManager.Instance.BuildingData.sendBuildCompleteFree();
					}
				}
				else if (queueBarSpriteType == eTimerSpriteType.Help)
				{
					DataManager.Instance.OpenBuildingWindowUpdateNoClose = 1;
					if (!this.bIsTechWindow)
					{
						DataManager.Instance.SendAllianceHelp(1);
					}
					else
					{
						DataManager.Instance.SendAllianceHelp(0);
					}
				}
				else if (queueBarSpriteType == eTimerSpriteType.Speed)
				{
					DataManager.Instance.OpenBagFilterByBuildingWindow = 2;
					if (this.bIsTechWindow)
					{
						this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 1, false);
					}
					else
					{
						this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 0, false);
					}
					DataManager.Instance.OriginalBuildType = this.buildType;
				}
				break;
			}
			case 102:
			{
				int btnID2 = sender.m_BtnID2;
				if (btnID2 >= this.upgradePanelData.Count)
				{
					return;
				}
				byte iconType = this.upgradePanelData[btnID2].iconType;
				uint value = this.upgradePanelData[btnID2].value;
				uint itemID = this.upgradePanelData[btnID2].itemID;
				if (this.door)
				{
					DataManager.Instance.OpenBagFilterByBuildingWindow = 2;
					if (this.upgradePanelData[btnID2].iconType == 8)
					{
						this.door.OpenMenu(EGUIWindow.UI_BagFilter, 655361, (int)value, false);
					}
					else if (this.upgradePanelData[btnID2].iconType == 7)
					{
						GUIManager.Instance.OpenItemFilterUI((ushort)itemID, (ushort)value);
					}
					else if (this.upgradePanelData[btnID2].iconType == 9)
					{
						GUIManager.Instance.OpenItemFilterUI((ushort)itemID, (ushort)value);
					}
					else
					{
						this.door.OpenMenu(EGUIWindow.UI_BagFilter, 1 + ((int)(4 + iconType) << 16), (int)value, false);
					}
					this.SaveScrollPostion();
				}
				DataManager.Instance.OriginalBuildType = this.buildType;
				break;
			}
			case 104:
			{
				int btnID3 = sender.m_BtnID2;
				if (btnID3 < this.upgradePanelData.Count && this.upgradePanelData[btnID3].btnType == 4)
				{
					if (this.bIsTechWindow && this.upgradePanelData[btnID3].buildID == 0)
					{
						ushort num8 = this.upgradePanelData[btnID3].techID;
						GUIManager.Instance.HideArrow(false);
						GUIManager.Instance.GuideParm1 = 3;
						GUIManager.Instance.GuideParm2 = num8;
						GUIManager.Instance.OpenTechTree(num8, false);
					}
					else
					{
						ushort num8 = this.upgradePanelData[btnID3].buildID;
						GUIManager.Instance.BuildingData.ManorGuild((ushort)((byte)num8), false);
						GUIManager.Instance.HideArrow(false);
						GUIManager.Instance.GuideParm1 = 1;
						GUIManager.Instance.GuideParm2 = num8;
						this.door.CloseMenu(true);
					}
				}
				break;
			}
			}
			break;
		}
	}

	// Token: 0x06002930 RID: 10544 RVA: 0x0045189C File Offset: 0x0044FA9C
	public void OnTimer(UITimeBar sender)
	{
		int timeBarID = sender.m_TimeBarID;
		if (timeBarID == 1)
		{
			this.timeBar.gameObject.SetActive(false);
		}
	}

	// Token: 0x06002931 RID: 10545 RVA: 0x004518D4 File Offset: 0x0044FAD4
	public void OnNotify(UITimeBar sender)
	{
		if (this.bIsTechWindow)
		{
			eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Researching);
			GUIManager.Instance.SetTimerSpriteType(this.timeBar, queueBarSpriteType);
			this.SetBuildType(this.buildType, queueBarSpriteType);
		}
		else
		{
			eTimerSpriteType queueBarSpriteType2 = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Building);
			GUIManager.Instance.SetTimerSpriteType(this.timeBar, queueBarSpriteType2);
			this.SetBuildType(this.buildType, queueBarSpriteType2);
		}
	}

	// Token: 0x06002932 RID: 10546 RVA: 0x00451948 File Offset: 0x0044FB48
	public void Onfunc(UITimeBar sender)
	{
	}

	// Token: 0x06002933 RID: 10547 RVA: 0x0045194C File Offset: 0x0044FB4C
	public void OnCancel(UITimeBar sender)
	{
	}

	// Token: 0x06002934 RID: 10548 RVA: 0x00451950 File Offset: 0x0044FB50
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (item.transform.parent.parent == this.upgradeScrollPanel.transform)
		{
			if (dataIdx < this.totalUpgradeCount)
			{
				if (dataIdx == 0)
				{
					this.m_bNeedShow = false;
					if (this.upgradePanelData[dataIdx].iconType == 6)
					{
						this.m_TimeObjectIdx = panelObjectIdx;
						this.m_bNeedShow = true;
						this.m_TimeTick = 1f;
					}
				}
				if (this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTexts == null)
				{
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTexts = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(2).GetComponent<UIText>();
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTimeTexts = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(4).GetComponent<UIText>();
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(0).GetComponent<Image>();
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnRect = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(1).GetComponent<RectTransform>();
					this.m_UpgradeItem[panelObjectIdx].m_TweenRotation = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(1).GetComponent<uTweenRotation>();
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(1).GetComponent<UIButton>().image;
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(1).GetComponent<UIButton>();
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_Handler = this;
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText.font = GUIManager.Instance.GetTTFFont();
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText.text = DataManager.Instance.mStringTable.GetStringByID(5892u);
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTexts.font = GUIManager.Instance.GetTTFFont();
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTexts.supportRichText = true;
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTimeTexts.font = GUIManager.Instance.GetTTFFont();
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTimeTexts.supportRichText = true;
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImageXs = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(5).GetComponent<Image>();
				}
				if (this.door)
				{
					this.m_UpgradeItem[panelObjectIdx].upgradeScrollPanelbConform = this.upgradePanelData[dataIdx].bConform;
					this.m_UpgradeItem[panelObjectIdx].upgradeScrollPanelIconType = this.upgradePanelData[dataIdx].iconType;
					this.m_UpgradeItem[panelObjectIdx].upgradeScrollPanelIconIdx = dataIdx;
					this.upgradePanelData[dataIdx].panelObjectIdx = panelObjectIdx;
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImageXs.enabled = !this.upgradePanelData[dataIdx].bConform;
					if (this.upgradePanelData[dataIdx].iconType == 6)
					{
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.sprite = this.door.LoadSprite(this.iconSpriteName[8]);
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.material = this.door.LoadMaterial();
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.SetNativeSize();
					}
					else if (this.upgradePanelData[dataIdx].iconType >= 0 && this.upgradePanelData[dataIdx].iconType <= 5)
					{
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.sprite = this.door.LoadSprite(this.iconSpriteName[(int)this.upgradePanelData[dataIdx].iconType]);
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.material = this.door.LoadMaterial();
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.SetNativeSize();
					}
					else if (this.upgradePanelData[dataIdx].iconType == 7)
					{
						if (this.bIsTechWindow)
						{
							this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.sprite = this.GM.LoadFrameSprite("icon015");
						}
						else
						{
							this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.sprite = this.GM.LoadFrameSprite("icon020");
						}
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.material = GUIManager.Instance.GetFrameMaterial();
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.SetNativeSize();
					}
					else if (this.bIsTechWindow && this.upgradePanelData[dataIdx].iconType == 8)
					{
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.sprite = this.door.LoadSprite(this.petResIcon);
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.material = this.door.LoadMaterial();
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.SetNativeSize();
					}
					else if (this.bIsTechWindow && this.upgradePanelData[dataIdx].iconType == 9)
					{
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.sprite = this.GM.LoadFrameSprite("icon020");
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.material = GUIManager.Instance.GetFrameMaterial();
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.SetNativeSize();
					}
					this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText.enabled = false;
					this.m_UpgradeItem[panelObjectIdx].m_TweenRotation.enabled = false;
					if (this.upgradePanelData[dataIdx].btnType == 0)
					{
						eTimerSpriteType queueBarSpriteType;
						if (!this.bIsTechWindow)
						{
							queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Building);
						}
						else
						{
							queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Researching);
						}
						this.SetTimeBarBtnSprite(queueBarSpriteType, panelObjectIdx);
						if (!this.upgradePanelData[dataIdx].bConform)
						{
							this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.enabled = true;
						}
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID1 = 101;
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID2 = dataIdx;
					}
					else if (this.upgradePanelData[dataIdx].btnType == 1)
					{
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.sprite = this.door.LoadSprite(this.iconSpriteName[7]);
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.material = this.door.LoadMaterial();
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.SetNativeSize();
						if (!this.upgradePanelData[dataIdx].bConform)
						{
							this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.enabled = true;
						}
						else
						{
							this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.enabled = false;
						}
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID1 = 102;
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID2 = dataIdx;
					}
					else if (this.upgradePanelData[dataIdx].btnType == 2)
					{
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.material = this.door.LoadMaterial();
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.enabled = false;
					}
					else if (this.upgradePanelData[dataIdx].btnType == 3)
					{
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.sprite = this.door.LoadSprite(this.iconSpriteName[6]);
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.material = this.door.LoadMaterial();
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.SetNativeSize();
						if (!this.upgradePanelData[dataIdx].bConform)
						{
							this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.enabled = true;
						}
						else
						{
							this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.enabled = false;
						}
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID1 = 103;
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID2 = dataIdx;
					}
					else if (this.upgradePanelData[dataIdx].btnType == 4)
					{
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.sprite = this.door.LoadSprite(this.iconSpriteName[10]);
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.material = this.door.LoadMaterial();
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.rectTransform.sizeDelta = new Vector2(69f, 47f);
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText.enabled = true;
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.type = Image.Type.Sliced;
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText.text = DataManager.Instance.mStringTable.GetStringByID(5892u);
						if (!this.upgradePanelData[dataIdx].bConform)
						{
							this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.enabled = true;
							this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText.enabled = true;
						}
						else
						{
							this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText.enabled = false;
							this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.enabled = false;
						}
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID1 = 104;
						this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID2 = dataIdx;
					}
				}
				this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTexts.text = this.upgradePanelData[dataIdx].text;
				this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTimeTexts.text = string.Empty;
			}
		}
		else if (item.transform.parent.parent == this.infoScrollPanel.transform && dataIdx < this.totalUpgradeEffectCount && this.m_UpgradeInfoItemTexts != null)
		{
			ArabicItemTextureRot arabicItemTextureRot;
			if (this.m_UpgradeInfoItemTexts[panelObjectIdx] == null)
			{
				this.m_UpgradeInfoItemTexts[panelObjectIdx] = this.infoScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(0).GetComponent<UIText>();
				this.m_UpgradeInfoItemImages[panelObjectIdx] = this.infoScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(1).GetComponent<Image>();
				arabicItemTextureRot = this.m_UpgradeInfoItemImages[panelObjectIdx].gameObject.GetComponent<ArabicItemTextureRot>();
				if (arabicItemTextureRot == null)
				{
					arabicItemTextureRot = this.m_UpgradeInfoItemImages[panelObjectIdx].gameObject.AddComponent<ArabicItemTextureRot>();
				}
				if (arabicItemTextureRot)
				{
					arabicItemTextureRot.enabled = false;
				}
				this.m_UpgradeInfoItemTexts[panelObjectIdx].font = GUIManager.Instance.GetTTFFont();
				this.m_UpgradeInfoItemTexts[panelObjectIdx].supportRichText = true;
			}
			this.m_UpgradeInfoItemTexts[panelObjectIdx].text = this.upgradeEffectData[dataIdx].text;
			this.m_UpgradeInfoItemImages[panelObjectIdx].gameObject.SetActive(true);
			arabicItemTextureRot = this.m_UpgradeInfoItemImages[panelObjectIdx].GetComponent<ArabicItemTextureRot>();
			if (arabicItemTextureRot)
			{
				arabicItemTextureRot.enabled = false;
			}
			if (this.upgradeEffectData[dataIdx].iconType == 1)
			{
				this.m_UpgradeInfoItemImages[panelObjectIdx].sprite = this.spArray.m_Sprites[1];
				this.m_UpgradeInfoItemImages[panelObjectIdx].material = this.m_Mat;
				this.m_UpgradeInfoItemImages[panelObjectIdx].SetNativeSize();
			}
			else
			{
				if (this.upgradeEffectData[dataIdx].iconType == 55)
				{
					arabicItemTextureRot.enabled = true;
				}
				this.m_UpgradeInfoItemImages[panelObjectIdx].sprite = this.GetSpriteByEffect(this.upgradeEffectData[dataIdx].iconType);
				this.m_UpgradeInfoItemImages[panelObjectIdx].material = GUIManager.Instance.GetFrameMaterial();
				this.m_UpgradeInfoItemImages[panelObjectIdx].SetNativeSize();
			}
		}
	}

	// Token: 0x06002935 RID: 10549 RVA: 0x004525E0 File Offset: 0x004507E0
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06002936 RID: 10550 RVA: 0x004525E4 File Offset: 0x004507E4
	public void DestroyBuildingWindow()
	{
		AssetManager.UnloadAssetBundle(this.abKey, true);
		if (this.GM.upgradePanelDataPool != null)
		{
			for (int i = this.upgradePanelData.Count - 1; i >= 0; i--)
			{
				this.GM.upgradePanelDataPool.despawn(this.upgradePanelData[i]);
				this.upgradePanelData.RemoveAt(i);
			}
		}
		if (this.GM.upgradeEffectDataPool != null)
		{
			for (int j = this.upgradeEffectData.Count - 1; j >= 0; j--)
			{
				this.GM.upgradeEffectDataPool.despawn(this.upgradeEffectData[j]);
				this.upgradeEffectData.RemoveAt(j);
			}
		}
		this.upgradePanelData = null;
		this.upgradeEffectData = null;
		GUIManager.Instance.RemoverTimeBaarToList(this.timeBar);
		GUIManager.Instance.RemoveSpriteAsset("BuildingWindow");
		if (DataManager.Instance.OpenBagFilterByBuildingWindow == 1)
		{
			DataManager.Instance.OriginalBuildType = this.buildType;
		}
		else
		{
			DataManager.Instance.OriginalBuildType = e_BuildType.Normal;
		}
		StringManager.Instance.DeSpawnString(this.tempString);
		StringManager.Instance.DeSpawnString(this.tempString2);
		StringManager.Instance.DeSpawnString(this.tempString3);
		StringManager.Instance.DeSpawnString(this.effectString);
	}

	// Token: 0x06002937 RID: 10551 RVA: 0x0045274C File Offset: 0x0045094C
	public void MyUpdate(byte close = 0, bool bSetBuildType = false)
	{
		if (close >= 1)
		{
			if (close == 1)
			{
				this.door.CloseMenu(true);
			}
			else if (close == 2)
			{
				this.door.CloseMenu(false);
			}
			else if (close == 3 && this.manorID == this.GM.BuildingData.BuildingManorID)
			{
				this.door.CloseMenu(false);
			}
			if (this.bOpenBackOutCheckBox)
			{
				GUIManager.Instance.CloseOKCancelBox();
			}
			return;
		}
		if (!this.bIsTechWindow)
		{
			if (GUIManager.Instance.BuildingData.AllBuildsData.Length <= (int)this.manorID)
			{
				return;
			}
			this.buildLv = GUIManager.Instance.BuildingData.AllBuildsData[(int)this.manorID].Level;
			if (this.door)
			{
				this.sliderBGImage.material = this.door.LoadMaterial();
				this.sliderBGImage.sprite = this.door.LoadSprite("UI_main_up_box");
				this.sliderBGImage.type = Image.Type.Sliced;
				this.sliderImage.material = this.door.LoadMaterial();
				if (this.buildLv >= this.buildLvMAx)
				{
					this.sliderImage.sprite = this.door.LoadSprite("UI_main_up_blood_b");
				}
				else
				{
					this.sliderImage.sprite = this.door.LoadSprite("UI_main_up_blood_a");
				}
				this.sliderImage.type = Image.Type.Sliced;
				this.sliderImage.GetComponent<RectTransform>().sizeDelta = new Vector2((float)this.buildLv / (float)this.buildLvMAx * 136f, 13f);
				this.sb.Length = 0;
				if (this.buildLv >= this.buildLvMAx)
				{
					this.sb.Append(DataManager.Instance.mStringTable.GetStringByID(3831u));
				}
				else if (GUIManager.Instance.IsArabic)
				{
					this.sb.AppendFormat("{0}/{1}", this.buildLvMAx, this.buildLv);
				}
				else
				{
					this.sb.AppendFormat("{0}/{1}", this.buildLv, this.buildLvMAx);
				}
				this.lvText.font = GUIManager.Instance.GetTTFFont();
				this.lvText.text = this.sb.ToString();
			}
			if (this.buildID == 6)
			{
				this.buildingTransform.GetComponent<RectTransform>().localScale = new Vector2(0.7f, 0.7f);
				this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 10f);
			}
			else if (this.buildID == 8)
			{
				this.buildingTransform.GetComponent<RectTransform>().localScale = new Vector2(0.4f, 0.4f);
				this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(2f, 4f);
			}
			else if (this.buildID == 10)
			{
				this.buildingTransform.GetComponent<RectTransform>().localScale = new Vector2(0.6f, 0.6f);
				this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 20f);
			}
			else if (this.buildID == 11)
			{
				this.buildingTransform.GetComponent<RectTransform>().localScale = new Vector2(0.6f, 0.6f);
				this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 10f);
			}
			else if (this.buildID == 12)
			{
				this.buildingTransform.GetComponent<RectTransform>().localScale = new Vector2(0.8f, 0.8f);
				this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 20f);
			}
			else if (this.buildID == 15)
			{
				this.buildingTransform.GetComponent<RectTransform>().localScale = new Vector2(0.7f, 0.7f);
				this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 15f);
			}
			else if (this.buildID == 16)
			{
				this.buildingTransform.GetComponent<RectTransform>().localScale = new Vector2(0.6f, 0.6f);
				this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 10f);
			}
			else if (this.buildID == 18)
			{
				this.buildingTransform.GetComponent<RectTransform>().localScale = new Vector2(0.65f, 0.65f);
				this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 10f);
			}
			else if (this.buildID == 19)
			{
				this.buildingTransform.GetComponent<RectTransform>().localScale = new Vector2(0.65f, 0.65f);
				this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 10f);
			}
			else if (this.buildID == 20)
			{
				this.buildingTransform.GetComponent<RectTransform>().localScale = new Vector2(0.61f, 0.61f);
				this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 10f);
			}
			else if (this.buildID == 21)
			{
				this.buildingTransform.GetComponent<RectTransform>().localScale = new Vector2(0.8f, 0.8f);
				this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 10f);
			}
			else if (this.buildID == 22)
			{
				this.buildingTransform.GetComponent<RectTransform>().localScale = new Vector2(0.7f, 0.7f);
				this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 10f);
			}
			else if (this.buildID == 23)
			{
				this.buildingTransform.GetComponent<RectTransform>().localScale = new Vector2(0.7f, 0.7f);
				this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 15f);
			}
			Image component = this.buildingTransform.GetComponent<Image>();
			if (this.buildID == 8)
			{
				component.sprite = GUIManager.Instance.BuildingData.castleSkin.GetUISprite(0, this.buildLv);
				component.material = GUIManager.Instance.BuildingData.castleSkin.GetUIMaterial(0, this.buildLv);
			}
			else
			{
				component.sprite = GUIManager.Instance.BuildingData.GetBuildSprite((ushort)this.buildID, this.buildLv);
				component.material = GUIManager.Instance.BuildingData.mapspriteManager.SpriteUIMaterial;
			}
			component.SetNativeSize();
			if (this.style == 1)
			{
				this.SetNormalPanel();
				this.SetNormalInfoPanel();
			}
			component = this.upgradePanelItem.GetChild(5).GetComponent<Image>();
			component.sprite = this.door.LoadSprite(this.iconSpriteName[9]);
			component.material = this.door.LoadMaterial();
			component.SetNativeSize();
			this.SetUpgradePanel();
			this.SetUpgradeInfoPanel();
			if (DataManager.Instance.OpenBagFilterByBuildingWindow == 1)
			{
				if (DataManager.Instance.OriginalBuildType == e_BuildType.SelfUpgradeing)
				{
					if (GUIManager.Instance.BuildingData.BuildingManorID == this.manorID)
					{
						this.SetBuildType(DataManager.Instance.OriginalBuildType, eTimerSpriteType.Speed);
					}
					else
					{
						this.SetBuildType(e_BuildType.Upgrade, eTimerSpriteType.Speed);
					}
				}
				else
				{
					this.SetBuildType(DataManager.Instance.OriginalBuildType, eTimerSpriteType.Speed);
				}
			}
			else if (GUIManager.Instance.BuildingData.BuildingManorID == this.manorID)
			{
				long startTime = DataManager.Instance.queueBarData[0].StartTime;
				long num = startTime + (long)((ulong)DataManager.Instance.queueBarData[0].TotalTime);
				long notifyTime = num - (long)DataManager.Instance.FreeCompletePeriod;
				eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Building);
				DataManager.Instance.GetQueueBarTitle(EQueueBarIndex.Building, this.sb, ref this.m_TimeBarStr1, ref this.m_TimeBarStr2);
				GUIManager.Instance.SetTimerSpriteType(this.timeBar, queueBarSpriteType);
				GUIManager.Instance.SetTimerBar(this.timeBar, startTime, num, notifyTime, eTimeBarType.NormalType, this.m_TimeBarStr1, this.m_TimeBarStr2);
				this.timeBar.gameObject.SetActive(true);
				if (GUIManager.Instance.BuildingData.QueueBuildType == 1)
				{
					this.SetBuildType(e_BuildType.SelfUpgradeing, queueBarSpriteType);
				}
				else
				{
					this.SetBuildType(e_BuildType.SelfBackOuting, queueBarSpriteType);
				}
			}
			else if (GUIManager.Instance.BuildingData.BuildingManorID != 0 && GUIManager.Instance.BuildingData.AllBuildsData[(int)this.manorID].BuildID != 0)
			{
				long startTime2 = DataManager.Instance.queueBarData[0].StartTime;
				long num2 = startTime2 + (long)((ulong)DataManager.Instance.queueBarData[0].TotalTime);
				long notifyTime2 = num2 - (long)DataManager.Instance.FreeCompletePeriod;
				eTimerSpriteType queueBarSpriteType2 = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Building);
				GUIManager.Instance.SetTimerSpriteType(this.timeBar, queueBarSpriteType2);
				GUIManager.Instance.SetTimerBar(this.timeBar, startTime2, num2, notifyTime2, eTimeBarType.NormalType, this.m_TimeBarStr1, this.m_TimeBarStr2);
				this.timeBar.gameObject.SetActive(true);
				this.SetBuildType(this.buildType, queueBarSpriteType2);
			}
			else if (GUIManager.Instance.BuildingData.AllBuildsData[(int)this.manorID].BuildID == 0)
			{
				this.SetBuildType(e_BuildType.Upgrade, eTimerSpriteType.Speed);
			}
			else
			{
				this.timeBar.gameObject.SetActive(false);
				if (this.buildType == e_BuildType.SelfUpgradeing)
				{
					this.SetBuildType(e_BuildType.Normal, eTimerSpriteType.Speed);
				}
				else
				{
					this.SetBuildType(this.buildType, eTimerSpriteType.Speed);
				}
			}
			this.SetUpdateTimeText();
		}
		else
		{
			Image component2 = this.upgradePanelItem.GetChild(5).GetComponent<Image>();
			component2.sprite = this.door.LoadSprite(this.iconSpriteName[9]);
			component2.material = this.door.LoadMaterial();
			component2.SetNativeSize();
			this.SetUpdateTimeText();
			this.SetUpgradePanel_Tech();
			this.SetUpgradeInfoPanel_Tech();
			this.buildingLvBG.gameObject.SetActive(false);
			this.buildingTransformBG.gameObject.SetActive(false);
			if (DataManager.Instance.ResearchTech == (ushort)this.techID)
			{
				long startTime3 = DataManager.Instance.queueBarData[1].StartTime;
				long num3 = startTime3 + (long)((ulong)DataManager.Instance.queueBarData[1].TotalTime);
				long notifyTime3 = num3 - (long)DataManager.Instance.FreeCompletePeriod;
				DataManager.Instance.GetQueueBarTitle(EQueueBarIndex.Researching, this.sb, ref this.m_TimeBarStr1, ref this.m_TimeBarStr2);
				eTimerSpriteType queueBarSpriteType3 = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Researching);
				GUIManager.Instance.SetTimerSpriteType(this.timeBar, queueBarSpriteType3);
				GUIManager.Instance.SetTimerBar(this.timeBar, startTime3, num3, notifyTime3, eTimeBarType.NormalType, this.m_TimeBarStr1, this.m_TimeBarStr2);
				this.timeBar.gameObject.SetActive(true);
				this.SetBuildType(e_BuildType.Upgradeing_Tech, queueBarSpriteType3);
			}
			else
			{
				this.techLv = DataManager.Instance.GetTechLevel((ushort)this.techID);
				this.timeBar.gameObject.SetActive(false);
				this.SetBuildType(e_BuildType.Upgrade_Tech, eTimerSpriteType.Speed);
			}
		}
	}

	// Token: 0x06002938 RID: 10552 RVA: 0x00453368 File Offset: 0x00451568
	private void SetNormalPanel()
	{
		int num = 0;
		ResourceType resourceType = ResourceType.Grain;
		AttribValManager attribVal = DataManager.Instance.AttribVal;
		uint num2 = 0u;
		uint num3 = 0u;
		if (this.buildID == 1)
		{
			resourceType = ResourceType.Wood;
			num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_WOOD_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
			num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_WOOD_PRODUCTION_PERCENT_DEBUFF);
		}
		if (this.buildID == 2)
		{
			resourceType = ResourceType.Rock;
			num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ROCK_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
			num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ROCK_PRODUCTION_PERCENT_DEBUFF);
		}
		if (this.buildID == 3)
		{
			resourceType = ResourceType.Steel;
			num2 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STEEL_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
			num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STEEL_PRODUCTION_PERCENT_DEBUFF);
		}
		if (this.buildID == 4)
		{
			resourceType = ResourceType.Grain;
			num2 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_FOOD_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
			num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_FOOD_PRODUCTION_PERCENT_DEBUFF);
		}
		if (this.buildID == 5)
		{
			resourceType = ResourceType.Money;
			num2 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONEY_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
			num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONEY_PRODUCTION_PERCENT_DEBUFF);
		}
		if (this.buildID == 4)
		{
			this.normalPanelInfoTf3.gameObject.SetActive(true);
			this.normalPanelTitles[3].gameObject.SetActive(true);
		}
		else
		{
			this.normalPanelInfoTf3.gameObject.SetActive(false);
			this.normalPanelTitles[3].gameObject.SetActive(false);
		}
		for (int i = 0; i < 4; i++)
		{
			this.normalPanelTitles[i].font = GUIManager.Instance.GetTTFFont();
			this.normalPanelInfos[i].font = GUIManager.Instance.GetTTFFont();
			this.normalPanelInfosImage[i].material = this.door.LoadMaterial();
		}
		byte level = (byte)Mathf.Clamp((int)this.buildLv, 1, (int)this.buildLvMAx);
		BuildLevelRequest buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort)this.buildID, level);
		this.sb.Length = 0;
		GameConstants.GetEffectValue(this.sb, buildLevelRequestData.Effect1, 0u, 0, 0f, 0L);
		this.normalPanelTitles[num].text = this.sb.ToString();
		uint num4;
		ulong num5;
		if (num3 > num2)
		{
			num4 = num3 - num2;
			if (num4 > 9900u)
			{
				num4 = 9900u;
			}
			num5 = (ulong)buildLevelRequestData.Value1 * 10000UL - (ulong)buildLevelRequestData.Value1 * (ulong)num4;
		}
		else
		{
			num4 = num2 - num3;
			num5 = (ulong)buildLevelRequestData.Value1 * 10000UL + (ulong)buildLevelRequestData.Value1 * (ulong)num4;
		}
		num4 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_CURSE);
		if (num4 > 9900u)
		{
			num4 = 9900u;
		}
		num5 = (10000UL * num5 - num5 * (ulong)num4) / 100000000UL;
		if (this.buildLv == 0)
		{
			this.normalPanelInfos[num].text = "0";
		}
		else
		{
			this.normalPanelInfos[num].text = num5.ToString("N0");
		}
		if ((int)this.buildID < this.iconBulidSpriteName.Length)
		{
			this.normalPanelInfosImage[num].sprite = this.door.LoadSprite(this.iconBulidSpriteName[(int)this.buildID]);
		}
		this.normalPanelInfosImage[num].SetNativeSize();
		num++;
		if (this.buildID == 4)
		{
			this.normalPanelTitles[num].text = DataManager.Instance.mStringTable.GetStringByID(3830u);
			this.sb.Length = 0;
			if (DataManager.Instance.AttribVal.TotalSoldierConsume > 0UL)
			{
				this.sb.AppendFormat("<color=#F63954>-{0:N0}</color>", DataManager.Instance.AttribVal.TotalSoldierConsume);
			}
			else
			{
				this.sb.AppendFormat("{0:N0}", DataManager.Instance.AttribVal.TotalSoldierConsume);
			}
			this.normalPanelInfos[num].text = this.sb.ToString();
			this.normalPanelInfosImage[num].material = this.uiMat;
			this.normalPanelInfosImage[num].sprite = this.spArray.m_Sprites[2];
			this.normalPanelInfosImage[num].SetNativeSize();
			num++;
		}
		switch (resourceType)
		{
		case ResourceType.Grain:
			this.normalPanelTitles[num].text = DataManager.Instance.mStringTable.GetStringByID(5792u);
			break;
		case ResourceType.Rock:
			this.normalPanelTitles[num].text = DataManager.Instance.mStringTable.GetStringByID(5793u);
			break;
		case ResourceType.Wood:
			this.normalPanelTitles[num].text = DataManager.Instance.mStringTable.GetStringByID(5794u);
			break;
		case ResourceType.Steel:
			this.normalPanelTitles[num].text = DataManager.Instance.mStringTable.GetStringByID(5795u);
			break;
		case ResourceType.Money:
			this.normalPanelTitles[num].text = DataManager.Instance.mStringTable.GetStringByID(5796u);
			break;
		}
		this.normalPanelInfos[num].text = DataManager.Instance.Resource[(int)resourceType].Capacity.ToString("N0");
		this.normalPanelInfosImage[num].material = this.uiMat;
		this.normalPanelInfosImage[num].sprite = this.spArray.m_Sprites[3];
		this.normalPanelInfosImage[num].SetNativeSize();
		num++;
		this.normalPanelTitles[num].text = DataManager.Instance.mStringTable.GetStringByID(3832u);
		long num6 = DataManager.MissionDataManager.UpdateResourceInfo(resourceType);
		this.normalPanelInfos[num].text = num6.ToString("N0");
		if ((int)this.buildID < this.iconBulidSpriteName.Length)
		{
			this.normalPanelInfosImage[num].sprite = this.door.LoadSprite(this.iconBulidSpriteName[(int)this.buildID]);
		}
		this.normalPanelInfosImage[num].SetNativeSize();
		num++;
	}

	// Token: 0x06002939 RID: 10553 RVA: 0x004539C8 File Offset: 0x00451BC8
	private bool GetResStr(ResourceType resType, out string text, byte id, byte lv, out uint value)
	{
		bool flag = false;
		value = 0u;
		BuildLevelRequest buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort)id, lv);
		if (resType == ResourceType.Grain)
		{
			value = buildLevelRequestData.RequestFood;
			flag = (buildLevelRequestData.RequestFood <= DataManager.Instance.Resource[(int)resType].Stock);
		}
		else if (resType == ResourceType.Rock)
		{
			value = buildLevelRequestData.RequestRock;
			flag = (buildLevelRequestData.RequestRock <= DataManager.Instance.Resource[(int)resType].Stock);
		}
		else if (resType == ResourceType.Wood)
		{
			value = buildLevelRequestData.RequestWood;
			flag = (buildLevelRequestData.RequestWood <= DataManager.Instance.Resource[(int)resType].Stock);
		}
		else if (resType == ResourceType.Steel)
		{
			value = buildLevelRequestData.RequestIron;
			flag = (buildLevelRequestData.RequestIron <= DataManager.Instance.Resource[(int)resType].Stock);
		}
		else if (resType == ResourceType.Money)
		{
			value = buildLevelRequestData.RequestGold;
			flag = (buildLevelRequestData.RequestGold <= DataManager.Instance.Resource[(int)resType].Stock);
		}
		this.sb.Length = 0;
		if (flag)
		{
			if (this.GM.IsArabic)
			{
				this.sb.AppendFormat("{0:N0} / {1:N0}", value, DataManager.Instance.Resource[(int)resType].Stock);
			}
			else
			{
				this.sb.AppendFormat("{0:N0} / {1:N0}", DataManager.Instance.Resource[(int)resType].Stock, value);
			}
			this.m_CostCrystal[(int)resType] = 0u;
		}
		else
		{
			if (this.GM.IsArabic)
			{
				this.sb.AppendFormat("{0:N0} / <color=#F63954>{1:N0}</color>  ", value, DataManager.Instance.Resource[(int)resType].Stock);
			}
			else
			{
				this.sb.AppendFormat("<color=#F63954>{0:N0}</color> / {1:N0} ", DataManager.Instance.Resource[(int)resType].Stock, value);
			}
			this.m_CostCrystal[(int)resType] = value - DataManager.Instance.Resource[(int)resType].Stock;
		}
		text = this.sb.ToString();
		return flag;
	}

	// Token: 0x0600293A RID: 10554 RVA: 0x00453C40 File Offset: 0x00451E40
	private bool GetResStr_Tech(ResourceType resType, out string text, byte id, byte lv, out uint value)
	{
		bool flag = false;
		TechLevelTbl techLevelTbl;
		bool techLevelupData = DataManager.Instance.GetTechLevelupData(out techLevelTbl, (ushort)id, lv);
		value = 0u;
		if (resType == ResourceType.Grain)
		{
			value = techLevelTbl.Grain;
			flag = (techLevelTbl.Grain <= DataManager.Instance.Resource[(int)resType].Stock);
		}
		else if (resType == ResourceType.Rock)
		{
			value = techLevelTbl.Rock;
			flag = (techLevelTbl.Rock <= DataManager.Instance.Resource[(int)resType].Stock);
		}
		else if (resType == ResourceType.Wood)
		{
			value = techLevelTbl.Wood;
			flag = (techLevelTbl.Wood <= DataManager.Instance.Resource[(int)resType].Stock);
		}
		else if (resType == ResourceType.Steel)
		{
			value = techLevelTbl.Iron;
			flag = (techLevelTbl.Iron <= DataManager.Instance.Resource[(int)resType].Stock);
		}
		else if (resType == ResourceType.Money)
		{
			value = techLevelTbl.Gold;
			flag = (techLevelTbl.Gold <= DataManager.Instance.Resource[(int)resType].Stock);
		}
		this.sb.Length = 0;
		if (flag)
		{
			this.m_CostCrystal[(int)resType] = 0u;
			if (this.GM.IsArabic)
			{
				this.sb.AppendFormat("{0:N0} / {1:N0}", value, DataManager.Instance.Resource[(int)resType].Stock);
			}
			else
			{
				this.sb.AppendFormat("{0:N0} / {1:N0}", DataManager.Instance.Resource[(int)resType].Stock, value);
			}
		}
		else
		{
			if (this.GM.IsArabic)
			{
				this.sb.AppendFormat("{0:N0} / <color=#F63954>{1:N0}</color>  ", value, DataManager.Instance.Resource[(int)resType].Stock);
			}
			else
			{
				this.sb.AppendFormat("<color=#F63954>{0:N0}</color> / {1:N0} ", DataManager.Instance.Resource[(int)resType].Stock, value);
			}
			this.m_CostCrystal[(int)resType] = value - DataManager.Instance.Resource[(int)resType].Stock;
		}
		text = this.sb.ToString();
		return flag;
	}

	// Token: 0x0600293B RID: 10555 RVA: 0x00453EB8 File Offset: 0x004520B8
	private bool GetPetResourceStr(out string text, byte id, byte lv, out uint value)
	{
		int num = 8;
		bool flag = false;
		TechLevelExTbl techLevelExTbl;
		bool techLevelupDataEx = DataManager.Instance.GetTechLevelupDataEx(out techLevelExTbl, (ushort)id, lv);
		value = 0u;
		if (techLevelupDataEx)
		{
			value = techLevelExTbl.PetResource;
			flag = (value <= DataManager.Instance.PetResource.Stock);
			this.sb.Length = 0;
			if (flag)
			{
				this.m_CostCrystal[num] = 0u;
				if (this.GM.IsArabic)
				{
					this.sb.AppendFormat("{0:N0} / {1:N0}", value, DataManager.Instance.PetResource.Stock);
				}
				else
				{
					this.sb.AppendFormat("{0:N0} / {1:N0}", DataManager.Instance.PetResource.Stock, value);
				}
			}
			else
			{
				if (this.GM.IsArabic)
				{
					this.sb.AppendFormat("{0:N0} / <color=#F63954>{1:N0}</color>  ", value, DataManager.Instance.PetResource.Stock);
				}
				else
				{
					this.sb.AppendFormat("<color=#F63954>{0:N0}</color> / {1:N0} ", DataManager.Instance.PetResource.Stock, value);
				}
				this.m_CostCrystal[num] = value - DataManager.Instance.PetResource.Stock;
			}
		}
		text = this.sb.ToString();
		return flag;
	}

	// Token: 0x0600293C RID: 10556 RVA: 0x00454034 File Offset: 0x00452234
	private void SetUpgradePanel()
	{
		this.m_bSpecialConform = true;
		this.m_bGeneralConform = true;
		this.m_CostCrystal[7] = 0u;
		byte b = (byte)Mathf.Clamp((int)(this.buildLv + 1), 1, (int)this.buildLvMAx);
		BuildLevelRequest buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort)this.buildID, b);
		int num = 0;
		int num2 = 0;
		ushort groupID = buildLevelRequestData.GroupID;
		this.upgradeDataIdx = 0;
		if (groupID > 0)
		{
			GUIManager.Instance.BuildingData.GetLevelRequestGroupIndex(groupID, ref num, ref num2);
		}
		if (DataManager.Instance.queueBarData[0].bActive)
		{
			this.totalUpgradeCount = num2 + 1;
		}
		else
		{
			this.totalUpgradeCount = num2;
		}
		if (buildLevelRequestData.RequestFood > 0u)
		{
			this.totalUpgradeCount++;
		}
		if (buildLevelRequestData.RequestWood > 0u)
		{
			this.totalUpgradeCount++;
		}
		if (buildLevelRequestData.RequestRock > 0u)
		{
			this.totalUpgradeCount++;
		}
		if (buildLevelRequestData.RequestIron > 0u)
		{
			this.totalUpgradeCount++;
		}
		if (buildLevelRequestData.RequestGold > 0u)
		{
			this.totalUpgradeCount++;
		}
		for (int i = 0; i < this.upgradePanelData.Count; i++)
		{
			this.GM.upgradePanelDataPool.despawn(this.upgradePanelData[i]);
		}
		this.upgradePanelData.Clear();
		if (this.upgradePanelData.Count < this.totalUpgradeCount)
		{
			int num3 = this.totalUpgradeCount - this.upgradePanelData.Count;
			for (int j = 0; j < num3; j++)
			{
				this.upgradePanelData.Add(this.GM.upgradePanelDataPool.spawn());
			}
		}
		if (DataManager.Instance.queueBarData[0].bActive)
		{
			this.upgradePanelData[this.upgradeDataIdx].type = 2;
			this.upgradePanelData[this.upgradeDataIdx].iconType = 6;
			this.upgradePanelData[this.upgradeDataIdx].btnType = 0;
			this.upgradePanelData[this.upgradeDataIdx].bConform = false;
			this.m_BuildStartTime = DataManager.Instance.queueBarData[0].StartTime;
			this.m_BuildEndTime = this.m_BuildStartTime + (long)((ulong)DataManager.Instance.queueBarData[0].TotalTime);
			this.sb.Length = 0;
			this.sb.AppendFormat("<color=#F63954>{0}</color>", DataManager.Instance.mStringTable.GetStringByID(3819u));
			this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
			this.m_bGeneralConform = false;
			this.upgradePanelData[this.upgradeDataIdx].bConform = this.m_bGeneralConform;
			this.upgradeDataIdx++;
		}
		else
		{
			this.m_BuildStartTime = 0L;
			this.m_BuildEndTime = 0L;
		}
		for (int k = num; k < num + num2; k++)
		{
			this.upgradePanelData[this.upgradeDataIdx].type = 2;
			this.upgradePanelData[this.upgradeDataIdx].btnType = 4;
			this.upgradePanelData[this.upgradeDataIdx].buildID = 0;
			this.upgradePanelData[this.upgradeDataIdx].techID = 0;
			this.sb.Length = 0;
			BuildLevelRequestGroup recordByIndex = DataManager.Instance.BuildsLevelRequestGroup.GetRecordByIndex(k);
			if (recordByIndex.ConditionType == 1)
			{
				BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey(recordByIndex.Condition);
				this.upgradePanelData[this.upgradeDataIdx].buildID = recordByKey.BuildID;
				int num4 = GUIManager.Instance.BuildingData.AllBuildsData.Length;
				byte b2 = 0;
				for (int l = 0; l < num4; l++)
				{
					ushort num5 = GUIManager.Instance.BuildingData.AllBuildsData[l].BuildID;
					if (num5 != 0 && num5 == recordByKey.BuildID)
					{
						b2 = (byte)Mathf.Max((int)b2, (int)GUIManager.Instance.BuildingData.AllBuildsData[l].Level);
					}
				}
				bool flag = recordByIndex.Num <= (ushort)b2;
				this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
				if (flag)
				{
					this.sb.AppendFormat("{0} : {1}{2} ", DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.NameID), DataManager.Instance.mStringTable.GetStringByID(32u), recordByIndex.Num);
				}
				else
				{
					this.m_bSpecialConform = false;
					this.sb.AppendFormat("<color=#F63954>{0}: {1}{2}</color> ", DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.NameID), DataManager.Instance.mStringTable.GetStringByID(32u), recordByIndex.Num);
				}
				this.upgradePanelData[this.upgradeDataIdx].iconType = 0;
				this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
			}
			else if (recordByIndex.ConditionType == 2)
			{
				Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(recordByIndex.Condition);
				ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(recordByIndex.Condition, 0);
				if (curItemQuantity >= recordByIndex.Num)
				{
					this.upgradePanelData[this.upgradeDataIdx].bConform = true;
					this.sb.AppendFormat("{0} : {1:N0} / {2:N0} ", DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey2.EquipName), curItemQuantity, recordByIndex.Num);
				}
				else
				{
					this.upgradePanelData[this.upgradeDataIdx].bConform = false;
					this.m_bGeneralConform = false;
					this.sb.AppendFormat("{0} : <color=#F63954>{1:N0}</color> / {2:N0} ", DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey2.EquipName), curItemQuantity, recordByIndex.Num);
					ushort inKey = DataManager.Instance.TotalShopItemData.Find(recordByKey2.EquipKey);
					StoreTbl recordByKey3 = DataManager.Instance.StoreData.GetRecordByKey(inKey);
					this.m_CostCrystal[7] += (uint)((ulong)recordByKey3.Price * (ulong)((long)(recordByIndex.Num - curItemQuantity)));
				}
				this.upgradePanelData[this.upgradeDataIdx].iconType = 7;
				this.upgradePanelData[this.upgradeDataIdx].btnType = 1;
				this.upgradePanelData[this.upgradeDataIdx].itemID = (uint)recordByKey2.EquipKey;
				this.upgradePanelData[this.upgradeDataIdx].value = (uint)recordByIndex.Num;
				this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
			}
			this.upgradeDataIdx++;
		}
		if (buildLevelRequestData.RequestFood > 0u)
		{
			this.upgradePanelData[this.upgradeDataIdx].type = 3;
			this.upgradePanelData[this.upgradeDataIdx].iconType = 1;
			this.upgradePanelData[this.upgradeDataIdx].btnType = 1;
			bool flag = this.GetResStr(ResourceType.Grain, out this.upgradePanelData[this.upgradeDataIdx].text, this.buildID, b, out this.upgradePanelData[this.upgradeDataIdx].value);
			if (!flag)
			{
				this.m_bGeneralConform_update = false;
			}
			this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
			this.upgradeDataIdx++;
		}
		if (buildLevelRequestData.RequestRock > 0u)
		{
			this.upgradePanelData[this.upgradeDataIdx].type = 3;
			this.upgradePanelData[this.upgradeDataIdx].iconType = 2;
			this.upgradePanelData[this.upgradeDataIdx].btnType = 1;
			bool flag = this.GetResStr(ResourceType.Rock, out this.upgradePanelData[this.upgradeDataIdx].text, this.buildID, b, out this.upgradePanelData[this.upgradeDataIdx].value);
			if (!flag)
			{
				this.m_bGeneralConform_update = false;
			}
			this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
			this.upgradeDataIdx++;
		}
		if (buildLevelRequestData.RequestWood > 0u)
		{
			this.upgradePanelData[this.upgradeDataIdx].type = 3;
			this.upgradePanelData[this.upgradeDataIdx].iconType = 3;
			this.upgradePanelData[this.upgradeDataIdx].btnType = 1;
			bool flag = this.GetResStr(ResourceType.Wood, out this.upgradePanelData[this.upgradeDataIdx].text, this.buildID, b, out this.upgradePanelData[this.upgradeDataIdx].value);
			if (!flag)
			{
				this.m_bGeneralConform_update = false;
			}
			this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
			this.upgradeDataIdx++;
		}
		if (buildLevelRequestData.RequestIron > 0u)
		{
			this.upgradePanelData[this.upgradeDataIdx].type = 3;
			this.upgradePanelData[this.upgradeDataIdx].iconType = 4;
			this.upgradePanelData[this.upgradeDataIdx].btnType = 1;
			bool flag = this.GetResStr(ResourceType.Steel, out this.upgradePanelData[this.upgradeDataIdx].text, this.buildID, b, out this.upgradePanelData[this.upgradeDataIdx].value);
			if (!flag)
			{
				this.m_bGeneralConform_update = false;
			}
			this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
			this.upgradeDataIdx++;
		}
		if (buildLevelRequestData.RequestGold > 0u)
		{
			this.upgradePanelData[this.upgradeDataIdx].type = 3;
			this.upgradePanelData[this.upgradeDataIdx].iconType = 5;
			this.upgradePanelData[this.upgradeDataIdx].btnType = 1;
			bool flag = this.GetResStr(ResourceType.Money, out this.upgradePanelData[this.upgradeDataIdx].text, this.buildID, b, out this.upgradePanelData[this.upgradeDataIdx].value);
			if (!flag)
			{
				this.m_bGeneralConform_update = false;
			}
			this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
			this.upgradeDataIdx++;
		}
		List<float> list = new List<float>();
		for (int m = 0; m < this.totalUpgradeCount; m++)
		{
			list.Add(59f);
		}
		if (this.upgradeScrollPanel.m_PanelObjects == null)
		{
			this.upgradeScrollPanel.IntiScrollPanel(456f, 0f, 0f, list, 10, this);
			this.upgradeScrollPanel.GoTo(this.GM.m_BuildingTopIdx, this.GM.m_BuildingPosY);
			this.ClearScrollPostionSave();
		}
		else
		{
			this.upgradeScrollPanel.AddNewDataHeight(list, false, true);
		}
	}

	// Token: 0x0600293D RID: 10557 RVA: 0x00454C00 File Offset: 0x00452E00
	private void SetUpgradePanel_Tech()
	{
		this.m_bSpecialConform = true;
		this.m_bGeneralConform = true;
		byte b = (byte)Mathf.Clamp((int)(this.techLv + 1), 1, (int)this.techLvMax);
		TechLevelTbl techLevelTbl;
		bool techLevelupData = DataManager.Instance.GetTechLevelupData(out techLevelTbl, (ushort)this.techID, b);
		TechLevelExTbl techLevelExTbl;
		bool techLevelupDataEx = DataManager.Instance.GetTechLevelupDataEx(out techLevelExTbl, (ushort)this.techID, b);
		this.totalUpgradeCount = 0;
		this.upgradeDataIdx = 0;
		if (techLevelupData)
		{
			if (DataManager.Instance.queueBarData[1].bActive)
			{
				this.totalUpgradeCount++;
			}
			if (techLevelTbl.ResearchLevel > 0)
			{
				this.totalUpgradeCount++;
			}
			if (techLevelTbl.RequireTechID1 != 0)
			{
				this.totalUpgradeCount++;
			}
			if (techLevelTbl.RequireTechID2 != 0)
			{
				this.totalUpgradeCount++;
			}
			if (techLevelTbl.RequireTechID3 != 0)
			{
				this.totalUpgradeCount++;
			}
			if (techLevelTbl.RequireTechID4 != 0)
			{
				this.totalUpgradeCount++;
			}
			if (techLevelTbl.Grain != 0u)
			{
				this.totalUpgradeCount++;
			}
			if (techLevelTbl.Rock != 0u)
			{
				this.totalUpgradeCount++;
			}
			if (techLevelTbl.Wood != 0u)
			{
				this.totalUpgradeCount++;
			}
			if (techLevelTbl.Iron != 0u)
			{
				this.totalUpgradeCount++;
			}
			if (techLevelTbl.Gold != 0u)
			{
				this.totalUpgradeCount++;
			}
			if (techLevelupDataEx && techLevelExTbl.PetResource > 0u)
			{
				this.totalUpgradeCount++;
			}
			if (techLevelupDataEx && techLevelExTbl.RequireItem > 0)
			{
				this.totalUpgradeCount++;
			}
			for (int i = 0; i < this.upgradePanelData.Count; i++)
			{
				this.GM.upgradePanelDataPool.despawn(this.upgradePanelData[i]);
			}
			this.upgradePanelData.Clear();
			for (int j = 0; j < this.totalUpgradeCount; j++)
			{
				this.upgradePanelData.Add(this.GM.upgradePanelDataPool.spawn());
			}
			this.sb.Length = 0;
			if (DataManager.Instance.queueBarData[1].bActive)
			{
				this.upgradePanelData[this.upgradeDataIdx].type = 2;
				this.upgradePanelData[this.upgradeDataIdx].iconType = 6;
				this.upgradePanelData[this.upgradeDataIdx].btnType = 0;
				this.m_BuildStartTime = DataManager.Instance.queueBarData[1].StartTime;
				this.m_BuildEndTime = this.m_BuildStartTime + (long)((ulong)DataManager.Instance.queueBarData[1].TotalTime);
				this.sb.Length = 0;
				this.sb.AppendFormat("<color=#F63954>{0}</color>", DataManager.Instance.mStringTable.GetStringByID(5017u));
				this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
				this.m_bGeneralConform = false;
				this.upgradePanelData[this.upgradeDataIdx].bConform = this.m_bGeneralConform;
				this.upgradeDataIdx++;
			}
			else
			{
				this.m_BuildStartTime = 0L;
				this.m_BuildEndTime = 0L;
			}
			this.upgradePanelData[this.upgradeDataIdx].type = 2;
			this.upgradePanelData[this.upgradeDataIdx].iconType = 0;
			this.upgradePanelData[this.upgradeDataIdx].buildID = 10;
			this.upgradePanelData[this.upgradeDataIdx].techID = 0;
			this.upgradePanelData[this.upgradeDataIdx].btnType = 4;
			ushort num = (ushort)GUIManager.Instance.BuildingData.GetBuildData(10, 0).Level;
			this.sb.Length = 0;
			ushort id = DataManager.Instance.BuildsTypeData.GetRecordByKey(10).NameID;
			if (num >= (ushort)techLevelTbl.ResearchLevel)
			{
				this.upgradePanelData[this.upgradeDataIdx].bConform = true;
				this.sb.AppendFormat("{0} : {1}{2} ", DataManager.Instance.mStringTable.GetStringByID((uint)id), DataManager.Instance.mStringTable.GetStringByID(32u), techLevelTbl.ResearchLevel);
			}
			else
			{
				this.m_bSpecialConform = false;
				this.upgradePanelData[this.upgradeDataIdx].bConform = false;
				this.sb.AppendFormat("<color=#F63954>{0}: {1}{2}</color> ", DataManager.Instance.mStringTable.GetStringByID((uint)id), DataManager.Instance.mStringTable.GetStringByID(32u), techLevelTbl.ResearchLevel);
			}
			this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
			this.upgradeDataIdx++;
			if (techLevelTbl.RequireTechID1 != 0)
			{
				num = (ushort)DataManager.Instance.GetTechLevel(techLevelTbl.RequireTechID1);
				this.sb.Length = 0;
				id = DataManager.Instance.TechData.GetRecordByKey(techLevelTbl.RequireTechID1).TechName;
				if (num >= (ushort)techLevelTbl.RequireTechLv1)
				{
					this.sb.AppendFormat("{0} : {1}{2} ", DataManager.Instance.mStringTable.GetStringByID((uint)id), DataManager.Instance.mStringTable.GetStringByID(32u), techLevelTbl.RequireTechLv1);
					this.upgradePanelData[this.upgradeDataIdx].bConform = true;
				}
				else
				{
					this.m_bSpecialConform = false;
					this.upgradePanelData[this.upgradeDataIdx].bConform = false;
					this.sb.AppendFormat("<color=#F63954>{0}: {1}{2}</color> ", DataManager.Instance.mStringTable.GetStringByID((uint)id), DataManager.Instance.mStringTable.GetStringByID(32u), techLevelTbl.RequireTechLv1);
				}
				this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
				this.upgradePanelData[this.upgradeDataIdx].type = 2;
				this.upgradePanelData[this.upgradeDataIdx].iconType = 7;
				this.upgradePanelData[this.upgradeDataIdx].btnType = 4;
				this.upgradePanelData[this.upgradeDataIdx].buildID = 0;
				this.upgradePanelData[this.upgradeDataIdx].techID = techLevelTbl.RequireTechID1;
				this.upgradeDataIdx++;
			}
			if (techLevelTbl.RequireTechID2 != 0)
			{
				num = (ushort)DataManager.Instance.GetTechLevel(techLevelTbl.RequireTechID2);
				this.sb.Length = 0;
				id = DataManager.Instance.TechData.GetRecordByKey(techLevelTbl.RequireTechID2).TechName;
				if (num >= (ushort)techLevelTbl.RequireTechLv2)
				{
					this.sb.AppendFormat("{0} : {1}{2} ", DataManager.Instance.mStringTable.GetStringByID((uint)id), DataManager.Instance.mStringTable.GetStringByID(32u), techLevelTbl.RequireTechLv2);
					this.upgradePanelData[this.upgradeDataIdx].bConform = true;
				}
				else
				{
					this.m_bSpecialConform = false;
					this.upgradePanelData[this.upgradeDataIdx].bConform = false;
					this.sb.AppendFormat("<color=#F63954>{0}: {1}{2}</color> ", DataManager.Instance.mStringTable.GetStringByID((uint)id), DataManager.Instance.mStringTable.GetStringByID(32u), techLevelTbl.RequireTechLv2);
				}
				this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
				this.upgradePanelData[this.upgradeDataIdx].type = 2;
				this.upgradePanelData[this.upgradeDataIdx].iconType = 7;
				this.upgradePanelData[this.upgradeDataIdx].btnType = 4;
				this.upgradePanelData[this.upgradeDataIdx].buildID = 0;
				this.upgradePanelData[this.upgradeDataIdx].techID = techLevelTbl.RequireTechID2;
				this.upgradeDataIdx++;
			}
			if (techLevelTbl.RequireTechID3 != 0)
			{
				num = (ushort)DataManager.Instance.GetTechLevel(techLevelTbl.RequireTechID3);
				this.sb.Length = 0;
				id = DataManager.Instance.TechData.GetRecordByKey(techLevelTbl.RequireTechID3).TechName;
				if (num >= (ushort)techLevelTbl.RequireTechLv3)
				{
					this.sb.AppendFormat("{0} : {1}{2} ", DataManager.Instance.mStringTable.GetStringByID((uint)id), DataManager.Instance.mStringTable.GetStringByID(32u), techLevelTbl.RequireTechLv3);
					this.upgradePanelData[this.upgradeDataIdx].bConform = true;
				}
				else
				{
					this.m_bSpecialConform = false;
					this.upgradePanelData[this.upgradeDataIdx].bConform = false;
					this.sb.AppendFormat("<color=#F63954>{0}: {1}{2}</color> ", DataManager.Instance.mStringTable.GetStringByID((uint)id), DataManager.Instance.mStringTable.GetStringByID(32u), techLevelTbl.RequireTechLv3);
				}
				this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
				this.upgradePanelData[this.upgradeDataIdx].type = 2;
				this.upgradePanelData[this.upgradeDataIdx].iconType = 7;
				this.upgradePanelData[this.upgradeDataIdx].btnType = 4;
				this.upgradePanelData[this.upgradeDataIdx].buildID = 0;
				this.upgradePanelData[this.upgradeDataIdx].techID = techLevelTbl.RequireTechID3;
				this.upgradeDataIdx++;
			}
			if (techLevelTbl.RequireTechID4 != 0)
			{
				num = (ushort)DataManager.Instance.GetTechLevel(techLevelTbl.RequireTechID4);
				this.sb.Length = 0;
				id = DataManager.Instance.TechData.GetRecordByKey(techLevelTbl.RequireTechID4).TechName;
				if (num >= (ushort)techLevelTbl.RequireTechLv4)
				{
					this.upgradePanelData[this.upgradeDataIdx].bConform = true;
					this.sb.AppendFormat("{0} : {1}{2} ", DataManager.Instance.mStringTable.GetStringByID((uint)id), DataManager.Instance.mStringTable.GetStringByID(32u), techLevelTbl.RequireTechLv4);
				}
				else
				{
					this.m_bSpecialConform = false;
					this.upgradePanelData[this.upgradeDataIdx].bConform = false;
					this.sb.AppendFormat("<color=#F63954>{0}: {1}{2}</color> ", DataManager.Instance.mStringTable.GetStringByID((uint)id), DataManager.Instance.mStringTable.GetStringByID(32u), techLevelTbl.RequireTechLv4);
				}
				this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
				this.upgradePanelData[this.upgradeDataIdx].type = 2;
				this.upgradePanelData[this.upgradeDataIdx].iconType = 7;
				this.upgradePanelData[this.upgradeDataIdx].btnType = 4;
				this.upgradePanelData[this.upgradeDataIdx].buildID = 0;
				this.upgradePanelData[this.upgradeDataIdx].techID = techLevelTbl.RequireTechID4;
				this.upgradeDataIdx++;
			}
			if (!DataManager.Instance.CheckTechKind((ushort)DataManager.Instance.TechData.GetRecordByKey((ushort)this.techID).Kind, null))
			{
				this.m_bSpecialConform = false;
			}
			if (techLevelupDataEx && techLevelExTbl.PetResource > 0u)
			{
				this.upgradePanelData[this.upgradeDataIdx].type = 3;
				this.upgradePanelData[this.upgradeDataIdx].iconType = 8;
				this.upgradePanelData[this.upgradeDataIdx].btnType = 1;
				bool flag = this.GetPetResourceStr(out this.upgradePanelData[this.upgradeDataIdx].text, this.techID, b, out this.upgradePanelData[this.upgradeDataIdx].value);
				if (!flag)
				{
					this.m_bGeneralConform_update = false;
				}
				this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
				this.upgradeDataIdx++;
			}
			if (techLevelupDataEx && techLevelExTbl.RequireItem > 0)
			{
				this.sb.Length = 0;
				Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(techLevelExTbl.RequireItem);
				ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(techLevelExTbl.RequireItem, 0);
				bool flag = curItemQuantity >= techLevelExTbl.Num;
				if (flag)
				{
					this.upgradePanelData[this.upgradeDataIdx].bConform = true;
					this.sb.AppendFormat("{0} : {1:N0} / {2:N0} ", DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.EquipName), curItemQuantity, techLevelExTbl.Num);
					this.m_CostCrystal[9] = 0u;
				}
				else
				{
					this.upgradePanelData[this.upgradeDataIdx].bConform = false;
					this.m_bGeneralConform = false;
					this.sb.AppendFormat("{0} : <color=#F63954>{1:N0}</color> / {2:N0} ", DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.EquipName), curItemQuantity, techLevelExTbl.Num);
					ushort inKey = DataManager.Instance.TotalShopItemData.Find(recordByKey.EquipKey);
					StoreTbl recordByKey2 = DataManager.Instance.StoreData.GetRecordByKey(inKey);
					this.m_CostCrystal[9] = (uint)((ulong)recordByKey2.Price * (ulong)((long)(techLevelExTbl.Num - curItemQuantity)));
				}
				this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
				this.upgradePanelData[this.upgradeDataIdx].type = 4;
				this.upgradePanelData[this.upgradeDataIdx].iconType = 9;
				this.upgradePanelData[this.upgradeDataIdx].btnType = 1;
				this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
				this.upgradePanelData[this.upgradeDataIdx].value = (uint)techLevelExTbl.Num;
				this.upgradePanelData[this.upgradeDataIdx].itemID = (uint)techLevelExTbl.RequireItem;
				this.upgradeDataIdx++;
			}
			if (techLevelTbl.Grain > 0u)
			{
				this.upgradePanelData[this.upgradeDataIdx].type = 3;
				this.upgradePanelData[this.upgradeDataIdx].iconType = 1;
				this.upgradePanelData[this.upgradeDataIdx].btnType = 1;
				bool flag = this.GetResStr_Tech(ResourceType.Grain, out this.upgradePanelData[this.upgradeDataIdx].text, this.techID, b, out this.upgradePanelData[this.upgradeDataIdx].value);
				if (!flag)
				{
					this.m_bGeneralConform_update = false;
				}
				this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
				this.upgradeDataIdx++;
			}
			if (techLevelTbl.Rock > 0u)
			{
				this.upgradePanelData[this.upgradeDataIdx].type = 3;
				this.upgradePanelData[this.upgradeDataIdx].iconType = 2;
				this.upgradePanelData[this.upgradeDataIdx].btnType = 1;
				bool flag = this.GetResStr_Tech(ResourceType.Rock, out this.upgradePanelData[this.upgradeDataIdx].text, this.techID, b, out this.upgradePanelData[this.upgradeDataIdx].value);
				if (!flag)
				{
					this.m_bGeneralConform_update = false;
				}
				this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
				this.upgradeDataIdx++;
			}
			if (techLevelTbl.Wood > 0u)
			{
				this.upgradePanelData[this.upgradeDataIdx].type = 3;
				this.upgradePanelData[this.upgradeDataIdx].iconType = 3;
				this.upgradePanelData[this.upgradeDataIdx].btnType = 1;
				bool flag = this.GetResStr_Tech(ResourceType.Wood, out this.upgradePanelData[this.upgradeDataIdx].text, this.techID, b, out this.upgradePanelData[this.upgradeDataIdx].value);
				if (!flag)
				{
					this.m_bGeneralConform_update = false;
				}
				this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
				this.upgradeDataIdx++;
			}
			if (techLevelTbl.Iron > 0u)
			{
				this.upgradePanelData[this.upgradeDataIdx].type = 3;
				this.upgradePanelData[this.upgradeDataIdx].iconType = 4;
				this.upgradePanelData[this.upgradeDataIdx].btnType = 1;
				bool flag = this.GetResStr_Tech(ResourceType.Steel, out this.upgradePanelData[this.upgradeDataIdx].text, this.techID, b, out this.upgradePanelData[this.upgradeDataIdx].value);
				if (!flag)
				{
					this.m_bGeneralConform_update = false;
				}
				this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
				this.upgradeDataIdx++;
			}
			if (techLevelTbl.Gold > 0u)
			{
				this.upgradePanelData[this.upgradeDataIdx].type = 3;
				this.upgradePanelData[this.upgradeDataIdx].iconType = 5;
				this.upgradePanelData[this.upgradeDataIdx].btnType = 1;
				bool flag = this.GetResStr_Tech(ResourceType.Money, out this.upgradePanelData[this.upgradeDataIdx].text, this.techID, b, out this.upgradePanelData[this.upgradeDataIdx].value);
				if (!flag)
				{
					this.m_bGeneralConform_update = false;
				}
				this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
				this.upgradeDataIdx++;
			}
			List<float> list = new List<float>();
			for (int k = 0; k < this.totalUpgradeCount; k++)
			{
				list.Add(59f);
			}
			if (this.upgradeScrollPanel.m_PanelObjects == null)
			{
				this.upgradeScrollPanel.IntiScrollPanel(456f, 0f, 0f, list, 10, this);
				this.upgradeScrollPanel.GoTo(this.GM.m_BuildingTopIdx, this.GM.m_BuildingPosY);
				this.ClearScrollPostionSave();
			}
			else
			{
				this.upgradeScrollPanel.AddNewDataHeight(list, false, true);
			}
		}
	}

	// Token: 0x0600293E RID: 10558 RVA: 0x00455FCC File Offset: 0x004541CC
	private void SetNormalInfoPanel()
	{
		UIText component = this.normallInfoPanel.GetChild(0).GetComponent<UIText>();
		component.font = GUIManager.Instance.GetTTFFont();
		BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey((ushort)this.buildID);
		component.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.UIExplain);
		this.m_SetNormalInfoPanelText = component;
	}

	// Token: 0x0600293F RID: 10559 RVA: 0x00456034 File Offset: 0x00454234
	private void SetUpgradeInfoPanel()
	{
		this.upgradeEffectIdx = 0;
		BuildLevelRequest buildLevelRequest;
		if (this.buildLv > 0)
		{
			buildLevelRequest = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort)this.buildID, this.buildLv);
		}
		else
		{
			buildLevelRequest = default(BuildLevelRequest);
		}
		BuildLevelRequest buildLevelRequest2;
		if (this.buildLv < this.buildLvMAx)
		{
			buildLevelRequest2 = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort)this.buildID, this.buildLv + 1);
		}
		else
		{
			buildLevelRequest2 = default(BuildLevelRequest);
		}
		this.totalUpgradeEffectCount = 0;
		if (buildLevelRequest2.Strength != buildLevelRequest.Strength)
		{
			this.totalUpgradeEffectCount++;
		}
		if (this.buildID == 13 || buildLevelRequest2.Value1 != buildLevelRequest.Value1 || buildLevelRequest2.Effect1 > 1000)
		{
			this.totalUpgradeEffectCount++;
		}
		if (this.buildID != 13)
		{
			if (buildLevelRequest2.Value2 != buildLevelRequest.Value2 || buildLevelRequest2.Effect2 > 1000)
			{
				this.totalUpgradeEffectCount++;
			}
			if (buildLevelRequest2.Value3 != buildLevelRequest.Value3 || buildLevelRequest2.Effect3 > 1000)
			{
				this.totalUpgradeEffectCount++;
			}
			if (buildLevelRequest2.Value4 != buildLevelRequest.Value4 || buildLevelRequest2.Effect4 > 1000)
			{
				this.totalUpgradeEffectCount++;
			}
			if (buildLevelRequest2.Value5 != 0 && buildLevelRequest2.Value5 > 1000)
			{
				this.totalUpgradeEffectCount++;
			}
			if (buildLevelRequest2.ExtValue1 != buildLevelRequest.ExtValue1 || buildLevelRequest2.ExtEffect1 > 1000)
			{
				this.totalUpgradeEffectCount++;
			}
			if (buildLevelRequest2.ExtValue2 != buildLevelRequest.ExtValue2 || buildLevelRequest2.ExtEffect2 > 1000)
			{
				this.totalUpgradeEffectCount++;
			}
		}
		for (int i = 0; i < this.upgradeEffectData.Count; i++)
		{
			this.GM.upgradeEffectDataPool.despawn(this.upgradeEffectData[i]);
		}
		this.upgradeEffectData.Clear();
		for (int j = 0; j < this.totalUpgradeEffectCount; j++)
		{
			this.upgradeEffectData.Add(this.GM.upgradeEffectDataPool.spawn());
		}
		if (buildLevelRequest2.Strength != buildLevelRequest.Strength)
		{
			this.sb.Length = 0;
			uint num = buildLevelRequest2.Strength - buildLevelRequest.Strength;
			this.sb.AppendFormat("{0}{1:N0}", DataManager.Instance.mStringTable.GetStringByID(4020u), num);
			this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
			this.upgradeEffectData[this.upgradeEffectIdx].iconType = 1;
			this.upgradeEffectIdx++;
		}
		if (this.buildID == 13)
		{
			this.sb.Length = 0;
			this.sb.AppendFormat("{0}", DataManager.Instance.mStringTable.GetStringByID(5766u));
			this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
			this.upgradeEffectData[this.upgradeEffectIdx].iconType = 269;
			this.upgradeEffectIdx++;
		}
		else
		{
			if (buildLevelRequest2.Value1 != buildLevelRequest.Value1 || buildLevelRequest.Effect1 > 1000)
			{
				this.sb.Length = 0;
				Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.Effect1);
				uint num = buildLevelRequest2.Value1 - buildLevelRequest.Value1;
				if (this.buildID == 18)
				{
					num /= 60u;
					uint num2 = num % 60u;
					uint num3 = num / 60u % 24u;
					uint num4 = num / 1440u;
					GameConstants.GetEffectValue(this.sb, buildLevelRequest2.Effect1, 0u, 0, 0f, 0L);
					if (num4 > 0u)
					{
						if (num3 > 0u)
						{
							this.sb.AppendFormat("{0}d{1}h", num4, num3);
						}
						else
						{
							this.sb.AppendFormat("{0}h", num3);
						}
					}
					else if (num3 > 0u)
					{
						this.sb.AppendFormat("{0}h", num3);
					}
					else if (num2 > 0u)
					{
						this.sb.AppendFormat("{0}m", num2);
					}
				}
				else
				{
					GameConstants.GetEffectValue(this.sb, buildLevelRequest2.Effect1, num, 7, 0f, 0L);
				}
				this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
				this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
				this.upgradeEffectIdx++;
			}
			if (buildLevelRequest2.Value2 != buildLevelRequest.Value2 || buildLevelRequest2.Effect2 > 1000)
			{
				this.sb.Length = 0;
				Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.Effect2);
				uint num = 0u;
				long mValue = (long)((ulong)buildLevelRequest2.Value2 - (ulong)buildLevelRequest.Value2);
				GameConstants.GetEffectValue(this.sb, buildLevelRequest2.Effect2, num, 7, 0f, mValue);
				this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
				this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
				this.upgradeEffectIdx++;
			}
			if (buildLevelRequest2.Value3 != buildLevelRequest.Value3 || buildLevelRequest2.Effect3 > 1000)
			{
				this.sb.Length = 0;
				Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.Effect3);
				uint num = (uint)(buildLevelRequest2.Value3 - buildLevelRequest.Value3);
				GameConstants.GetEffectValue(this.sb, buildLevelRequest2.Effect3, num, 7, 0f, 0L);
				this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
				this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
				this.upgradeEffectIdx++;
			}
			if (buildLevelRequest2.Value4 != buildLevelRequest.Value4 || buildLevelRequest2.Effect4 > 1000)
			{
				this.sb.Length = 0;
				Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.Effect4);
				uint num = (uint)(buildLevelRequest2.Value4 - buildLevelRequest.Value4);
				GameConstants.GetEffectValue(this.sb, buildLevelRequest2.Effect4, num, 7, 0f, 0L);
				this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
				this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
				this.upgradeEffectIdx++;
			}
			if (buildLevelRequest2.Value5 != 0 && buildLevelRequest2.Value5 > 1000)
			{
				this.sb.Length = 0;
				Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.Value5);
				uint num = (uint)(buildLevelRequest2.Value5 - buildLevelRequest.Value5);
				GameConstants.GetEffectValue(this.sb, buildLevelRequest2.Value5, 0u, 0, 0f, 0L);
				this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
				this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
				this.upgradeEffectIdx++;
			}
			if (buildLevelRequest2.ExtValue1 != buildLevelRequest.ExtValue1 || buildLevelRequest2.ExtEffect1 > 1000)
			{
				this.sb.Length = 0;
				Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.ExtEffect1);
				uint num = buildLevelRequest2.ExtValue1 - buildLevelRequest.ExtValue1;
				GameConstants.GetEffectValue(this.sb, buildLevelRequest2.ExtEffect1, num, 7, 0f, 0L);
				this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
				this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
				this.upgradeEffectIdx++;
			}
			if (buildLevelRequest2.ExtValue2 != buildLevelRequest.ExtValue2 || buildLevelRequest2.ExtEffect2 > 1000)
			{
				this.sb.Length = 0;
				Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.ExtEffect2);
				uint num = (uint)(buildLevelRequest2.ExtValue2 - buildLevelRequest.ExtValue2);
				GameConstants.GetEffectValue(this.sb, buildLevelRequest2.ExtEffect2, num, 7, 0f, 0L);
				this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
				this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
				this.upgradeEffectIdx++;
			}
		}
		List<float> list = new List<float>();
		this.m_UpgradeInfoItemTexts = new UIText[this.m_MaxUpgradeInfoItemCount];
		this.m_UpgradeInfoItemImages = new Image[this.m_MaxUpgradeInfoItemCount];
		for (int k = 0; k < this.totalUpgradeEffectCount; k++)
		{
			list.Add(39f);
		}
		if (this.infoScrollPanel.m_PanelObjects == null)
		{
			this.infoScrollPanel.IntiScrollPanel(142.5f, 0f, 15f, list, this.m_MaxUpgradeInfoItemCount, this);
		}
		else
		{
			this.infoScrollPanel.AddNewDataHeight(list, true, true);
		}
	}

	// Token: 0x06002940 RID: 10560 RVA: 0x00456AAC File Offset: 0x00454CAC
	private void SetUpgradeInfoPanel_Tech()
	{
		TechLevelTbl techLevelTbl;
		if (this.techLv > 0)
		{
			DataManager.Instance.GetTechLevelupData(out techLevelTbl, (ushort)this.techID, this.techLv);
		}
		else
		{
			techLevelTbl = default(TechLevelTbl);
		}
		TechLevelTbl techLevelTbl2;
		if (this.techLv < this.techLvMax)
		{
			DataManager.Instance.GetTechLevelupData(out techLevelTbl2, (ushort)this.techID, this.techLv + 1);
		}
		else
		{
			techLevelTbl2 = default(TechLevelTbl);
		}
		this.totalUpgradeEffectCount = 1;
		if (techLevelTbl2.EffectVal != techLevelTbl.EffectVal || techLevelTbl2.Effect > 1000)
		{
			this.totalUpgradeEffectCount++;
		}
		for (int i = 0; i < this.upgradeEffectData.Count; i++)
		{
			this.GM.upgradeEffectDataPool.despawn(this.upgradeEffectData[i]);
		}
		this.upgradeEffectData.Clear();
		for (int j = 0; j < this.totalUpgradeEffectCount; j++)
		{
			this.upgradeEffectData.Add(this.GM.upgradeEffectDataPool.spawn());
		}
		this.upgradeEffectIdx = 0;
		if (techLevelTbl2.Strength != techLevelTbl.Strength)
		{
			this.sb.Length = 0;
			this.sb.AppendFormat("{0}{1:N0}", DataManager.Instance.mStringTable.GetStringByID(4020u), techLevelTbl2.Strength - techLevelTbl.Strength);
			this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
			this.upgradeEffectData[this.upgradeEffectIdx].iconType = 1;
			this.upgradeEffectIdx++;
		}
		if (this.techID == 43)
		{
			this.sb.Length = 0;
			this.sb.AppendFormat("{0}", DataManager.Instance.mStringTable.GetStringByID(5033u));
			this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
			Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(techLevelTbl2.Effect);
			this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
			this.upgradeEffectIdx++;
		}
		else if (techLevelTbl2.EffectVal != techLevelTbl.EffectVal || techLevelTbl2.Effect > 1000)
		{
			this.sb.Length = 0;
			Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(techLevelTbl2.Effect);
			uint num = techLevelTbl2.EffectVal - techLevelTbl.EffectVal;
			GameConstants.GetEffectValue(this.sb, techLevelTbl2.Effect, num, 7, num, 0L);
			this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
			this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
			this.upgradeEffectIdx++;
		}
		List<float> list = new List<float>();
		this.m_UpgradeInfoItemTexts = new UIText[this.m_MaxUpgradeInfoItemCount];
		this.m_UpgradeInfoItemImages = new Image[this.m_MaxUpgradeInfoItemCount];
		for (int k = 0; k < this.totalUpgradeEffectCount; k++)
		{
			list.Add(39f);
		}
		if (this.infoScrollPanel.m_PanelObjects == null)
		{
			this.infoScrollPanel.IntiScrollPanel(142.5f, 0f, 0f, list, this.m_MaxUpgradeInfoItemCount, this);
		}
		else
		{
			this.infoScrollPanel.AddNewDataHeight(list, true, true);
		}
	}

	// Token: 0x06002941 RID: 10561 RVA: 0x00456E7C File Offset: 0x0045507C
	public void SetTime(int dd, int hh, int mm, int ss, CString _tempString, UIText text)
	{
		if (dd >= 0 && hh >= 0 && mm >= 0 && ss >= 0)
		{
			_tempString.ClearString();
			if (dd > 0)
			{
				_tempString.IntToFormat((long)dd, 1, false);
				_tempString.AppendFormat("{0}d ");
			}
			_tempString.IntToFormat((long)hh, 2, false);
			_tempString.IntToFormat((long)mm, 2, false);
			_tempString.IntToFormat((long)ss, 2, false);
			_tempString.AppendFormat("{0}:{1}:{2}");
		}
		text.text = _tempString.ToString();
		text.SetAllDirty();
		text.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002942 RID: 10562 RVA: 0x00456F20 File Offset: 0x00455120
	private uint GetCostCrystal()
	{
		uint num = 0u;
		for (int i = 0; i < 5; i++)
		{
			num += DataManager.Instance.GetResourceExchange((PriceListType)i, this.m_CostCrystal[i]);
		}
		num += DataManager.Instance.GetResourceExchange(PriceListType.Time, this.m_CostCrystal[6]);
		num += this.m_CostCrystal[7];
		num += DataManager.Instance.GetResourceExchange(PriceListType.PetResource, this.m_CostCrystal[8]);
		return num + this.m_CostCrystal[9];
	}

	// Token: 0x06002943 RID: 10563 RVA: 0x00456F9C File Offset: 0x0045519C
	private void SetUpdateTimeText()
	{
		this.m_CostCrystal[5] = 0u;
		if (this.bIsTechWindow)
		{
			TechLevelTbl techLevelTbl;
			DataManager.Instance.GetTechLevelupData(out techLevelTbl, (ushort)this.techID, this.techLv + 1);
			this.m_CostCrystal[5] = techLevelTbl.LevelupTime;
		}
		else
		{
			BuildLevelRequest buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort)this.buildID, this.buildLv + 1);
			this.m_CostCrystal[5] = buildLevelRequestData.BuildTime;
		}
		if (this.m_CostCrystal[5] >= 0u)
		{
			int ss = (int)(this.m_CostCrystal[5] % 60u);
			int mm = (int)(this.m_CostCrystal[5] / 60u % 60u);
			int hh = (int)(this.m_CostCrystal[5] / 3600u % 24u);
			int dd = (int)(this.m_CostCrystal[5] / 86400u);
			this.SetTime(dd, hh, mm, ss, this.tempString, this.updateTimeText1);
			uint effectBaseVal;
			uint effectBaseVal2;
			if (this.bIsTechWindow)
			{
				effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESEARCH_SPEED);
				effectBaseVal2 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESEARCH_SPEED_DEBUFF);
			}
			else
			{
				effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_CONSTRUCTION_SPEED);
				effectBaseVal2 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_CONSTRUCTION_SPEED_DEBUFF);
			}
			long num2;
			if (effectBaseVal >= effectBaseVal2)
			{
				uint num = effectBaseVal - effectBaseVal2;
				num2 = (long)((ulong)this.m_CostCrystal[5] * 10000UL / ((ulong)num + 10000UL) + (ulong)((long)Mathf.Clamp((int)((ulong)this.m_CostCrystal[5] * 10000UL % ((ulong)num + 10000UL)), 0, 1)));
			}
			else
			{
				uint num = effectBaseVal2 - effectBaseVal;
				if (num > 9900u)
				{
					num = 9900u;
				}
				num2 = (long)((ulong)this.m_CostCrystal[5] * 10000UL / (10000UL - (ulong)num) + (ulong)((long)Mathf.Clamp((int)((ulong)this.m_CostCrystal[5] * 10000UL % (10000UL - (ulong)num)), 0, 1)));
			}
			this.m_CostCrystal[6] = (uint)num2;
			ss = (int)num2 % 60;
			mm = (int)(num2 / 60L) % 60;
			hh = (int)(num2 / 3600L) % 24;
			dd = (int)num2 / 86400;
			this.SetTime(dd, hh, mm, ss, this.tempString3, this.updateTimeText2);
		}
	}

	// Token: 0x06002944 RID: 10564 RVA: 0x004571F0 File Offset: 0x004553F0
	private void SetFuncBtnType()
	{
		this.backOutBtnText.fontSize = 19;
		this.backOutBtnText.resizeTextMaxSize = 19;
		this.backOutBtnTextRt.anchoredPosition = new Vector2(-2f, -30f);
		this.backOutBtnText.color = new Color(1f, 0.968f, 0.6f);
		this.backOutBtn.interactable = true;
		this.backOutBtn.ForTextChange(e_BtnType.e_Normal);
		this.backOutBtn.m_BtnID2 = 200;
		this.backOutBtnMoneyText.gameObject.SetActive(false);
		this.backOutBtn.gameObject.SetActive(true);
		this.backOutBtnImage.enabled = true;
		this.backOutBtnText.enabled = true;
		e_FuncBtnType e_FuncBtnType = this.backOutBtnType;
		switch (e_FuncBtnType)
		{
		case e_FuncBtnType.Cancel:
		case e_FuncBtnType.Cancel_BackOut:
			this.backOutBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3827u);
			this.backOutBtnImage.sprite = this.btnSpArray.m_Sprites[0];
			this.backOutBtnImage.material = this.uiMat;
			this.backOutBtnImage.SetNativeSize();
			this.backOutBtnBgImage.sprite = this.btnBGSpArray.m_Sprites[0];
			this.backOutBtnImageRt.anchoredPosition = new Vector2(15f, -11f);
			break;
		default:
			switch (e_FuncBtnType)
			{
			case e_FuncBtnType.AtOnce_Upgrade:
			{
				this.backOutBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3822u);
				this.backOutBtnImage.sprite = this.btnSpArray.m_Sprites[4];
				this.backOutBtnImage.material = this.uiMat;
				this.backOutBtnImage.SetNativeSize();
				this.backOutBtnBgImage.sprite = this.btnBGSpArray.m_Sprites[3];
				this.backOutBtnImageRt.anchoredPosition = new Vector2(6f, -3f);
				this.backOutBtnTextRt.anchoredPosition = new Vector2(-2f, -30f);
				this.backOutBtnMoneyText.gameObject.SetActive(true);
				uint costCrystal = this.GetCostCrystal();
				this.sb.Length = 0;
				this.sb.AppendFormat("{0:N0}", costCrystal);
				this.backOutBtnMoneyText.text = this.sb.ToString();
				if (!this.m_bSpecialConform)
				{
					this.backOutBtn.ForTextChange(e_BtnType.e_ChangeText);
					this.backOutBtn.m_BtnID2 = 100;
				}
				break;
			}
			case e_FuncBtnType.AtOnce_Build:
			{
				this.backOutBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3820u);
				this.backOutBtnImage.sprite = this.btnSpArray.m_Sprites[4];
				this.backOutBtnImage.material = this.uiMat;
				this.backOutBtnImage.SetNativeSize();
				this.backOutBtnBgImage.sprite = this.btnBGSpArray.m_Sprites[3];
				this.backOutBtnImageRt.anchoredPosition = new Vector2(6f, -3f);
				this.backOutBtnTextRt.anchoredPosition = new Vector2(-2f, -30f);
				this.backOutBtnMoneyText.gameObject.SetActive(true);
				uint costCrystal = this.GetCostCrystal();
				this.sb.Length = 0;
				this.sb.AppendFormat("{0:N0}", costCrystal);
				this.backOutBtnMoneyText.text = this.sb.ToString();
				if (!this.m_bSpecialConform)
				{
					this.backOutBtn.ForTextChange(e_BtnType.e_ChangeText);
					this.backOutBtn.m_BtnID2 = 100;
				}
				break;
			}
			case e_FuncBtnType.AtOnce_Research:
			{
				this.backOutBtnText.text = DataManager.Instance.mStringTable.GetStringByID(5022u);
				this.backOutBtnImage.sprite = this.btnSpArray.m_Sprites[4];
				this.backOutBtnImage.material = this.uiMat;
				this.backOutBtnImage.SetNativeSize();
				this.backOutBtnBgImage.sprite = this.btnBGSpArray.m_Sprites[3];
				this.backOutBtnImageRt.anchoredPosition = new Vector2(6f, -3f);
				this.backOutBtnTextRt.anchoredPosition = new Vector2(-2f, -30f);
				this.backOutBtnMoneyText.gameObject.SetActive(true);
				uint costCrystal = this.GetCostCrystal();
				this.sb.Length = 0;
				this.sb.AppendFormat("{0:N0}", costCrystal);
				this.backOutBtnMoneyText.text = this.sb.ToString();
				if (!this.m_bSpecialConform)
				{
					this.backOutBtn.ForTextChange(e_BtnType.e_ChangeText);
					this.backOutBtn.m_BtnID2 = 100;
				}
				break;
			}
			case e_FuncBtnType.Cancel_Research:
				this.backOutBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3827u);
				this.backOutBtnImage.sprite = this.btnSpArray.m_Sprites[11];
				this.backOutBtnImage.material = this.uiMat;
				this.backOutBtnImage.SetNativeSize();
				this.backOutBtnBgImage.sprite = this.btnBGSpArray.m_Sprites[0];
				this.backOutBtnImageRt.anchoredPosition = new Vector2(30f, -14f);
				break;
			}
			break;
		case e_FuncBtnType.BackOut:
		{
			this.backOutBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3828u);
			this.backOutBtnImage.sprite = this.btnSpArray.m_Sprites[1];
			this.backOutBtnImage.material = this.uiMat;
			this.backOutBtnImage.SetNativeSize();
			this.backOutBtnBgImage.sprite = this.btnBGSpArray.m_Sprites[0];
			this.backOutBtnImageRt.anchoredPosition = new Vector2(15f, -2f);
			BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey((ushort)this.buildID);
			if (recordByKey.Kind == 3 || recordByKey.Kind == 4 || recordByKey.Kind == 5)
			{
				this.backOutBtn.gameObject.SetActive(false);
			}
			if (this.buildID == 7)
			{
				int num = DataManager.Instance.mSoldier_Hospital.Length;
				for (int i = 0; i < num; i++)
				{
					if (DataManager.Instance.mSoldier_Hospital[i] != 0u)
					{
						this.backOutBtn.m_BtnID2 = 101;
						break;
					}
				}
			}
			if (this.buildID == 23)
			{
				int num2 = PetManager.Instance.m_PetTrainingData.Length;
				for (int j = 0; j < num2; j++)
				{
					if (PetManager.Instance.m_PetTrainingData[j].m_State == PetManager.EPetTrainDataState.Training || PetManager.Instance.m_PetTrainingData[j].m_State == PetManager.EPetTrainDataState.CanReceive)
					{
						this.backOutBtn.m_BtnID2 = 102;
						break;
					}
				}
			}
			break;
		}
		}
		this.upgradeBtn.gameObject.SetActive(true);
		this.maxLvImage.gameObject.SetActive(false);
		this.upgradeBtn.m_BtnID2 = 200;
		this.upgradeBtn.ForTextChange(e_BtnType.e_Normal);
		if (this.GM.IsArabic)
		{
			this.upgradeBtnImageRt.localScale = new Vector3(1f, 1f, 1f);
		}
		switch (this.upgradeBtnType)
		{
		case e_FuncBtnType.Free:
			this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3826u);
			this.upgradeBtnImage.sprite = this.btnSpArray.m_Sprites[6];
			this.upgradeBtnImage.SetNativeSize();
			this.upgradeBtnBGImage.sprite = this.btnBGSpArray.m_Sprites[5];
			if (this.GM.IsArabic)
			{
				this.upgradeBtnImageRt.localScale = new Vector3(-1f, 1f, 1f);
				this.upgradeBtnImageRt.anchoredPosition = new Vector2(90f, -2f);
			}
			else
			{
				this.upgradeBtnImageRt.anchoredPosition = new Vector2(20f, -2f);
			}
			break;
		case e_FuncBtnType.Speed:
			this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3825u);
			this.upgradeBtnImage.sprite = this.btnSpArray.m_Sprites[2];
			this.upgradeBtnImage.SetNativeSize();
			this.upgradeBtnBGImage.sprite = this.btnBGSpArray.m_Sprites[1];
			if (this.GM.IsArabic)
			{
				this.upgradeBtnImageRt.localScale = new Vector3(-1f, 1f, 1f);
				this.upgradeBtnImageRt.anchoredPosition = new Vector2(85f, -11f);
			}
			else
			{
				this.upgradeBtnImageRt.anchoredPosition = new Vector2(26f, -11f);
			}
			break;
		case e_FuncBtnType.Help:
			this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3824u);
			this.upgradeBtnImage.sprite = this.btnSpArray.m_Sprites[5];
			this.upgradeBtnImage.SetNativeSize();
			this.upgradeBtnBGImage.sprite = this.btnBGSpArray.m_Sprites[4];
			this.upgradeBtnImageRt.anchoredPosition = new Vector2(16f, -11f);
			break;
		case e_FuncBtnType.Disable:
			this.upgradeBtn.gameObject.SetActive(false);
			break;
		case e_FuncBtnType.MaxLv:
			this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3831u);
			this.maxLvImage.gameObject.SetActive(true);
			this.upgradeBtn.gameObject.SetActive(false);
			break;
		case e_FuncBtnType.Upgrade:
			this.upgradeBtnImage.sprite = this.btnSpArray.m_Sprites[3];
			this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3823u);
			this.upgradeBtnImage.SetNativeSize();
			this.upgradeBtnBGImage.sprite = this.btnBGSpArray.m_Sprites[2];
			this.upgradeBtnImageRt.anchoredPosition = new Vector2(15f, -8f);
			if (this.buildType == e_BuildType.Upgrade && (!this.m_bGeneralConform || !this.m_bSpecialConform || !this.m_bGeneralConform_update))
			{
				this.upgradeBtn.m_BtnID2 = 100;
				this.upgradeBtn.ForTextChange(e_BtnType.e_ChangeText);
			}
			break;
		case e_FuncBtnType.Build:
			this.upgradeBtnImage.sprite = this.btnSpArray.m_Sprites[3];
			this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3821u);
			this.upgradeBtnImage.SetNativeSize();
			this.upgradeBtnBGImage.sprite = this.btnBGSpArray.m_Sprites[2];
			this.upgradeBtnImageRt.anchoredPosition = new Vector2(15f, -8f);
			if (this.buildType == e_BuildType.Upgrade && (!this.m_bGeneralConform || !this.m_bSpecialConform || !this.m_bGeneralConform_update))
			{
				this.upgradeBtn.ForTextChange(e_BtnType.e_ChangeText);
				this.upgradeBtn.m_BtnID2 = 100;
			}
			break;
		case e_FuncBtnType.Research:
			this.upgradeBtnImage.sprite = this.btnSpArray.m_Sprites[10];
			this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(5021u);
			this.upgradeBtnImage.SetNativeSize();
			this.upgradeBtnBGImage.sprite = this.btnBGSpArray.m_Sprites[2];
			this.upgradeBtnImageRt.anchoredPosition = new Vector2(30f, -20f);
			if (this.buildType == e_BuildType.Upgrade_Tech && (!this.m_bGeneralConform || !this.m_bSpecialConform || !this.m_bGeneralConform_update))
			{
				this.upgradeBtn.m_BtnID2 = 100;
				this.upgradeBtn.ForTextChange(e_BtnType.e_ChangeText);
			}
			break;
		}
	}

	// Token: 0x06002945 RID: 10565 RVA: 0x00457E54 File Offset: 0x00456054
	private void SetBuildType(e_BuildType _buildType, eTimerSpriteType _SpriteType = eTimerSpriteType.Speed)
	{
		this.buildType = _buildType;
		this.SetCustomCastleBtn(this.buildType);
		switch (this.buildType)
		{
		case e_BuildType.Normal:
			this.normallInfoPanel.gameObject.SetActive(true);
			this.normalPanel.gameObject.SetActive(true);
			this.upgradePanel.gameObject.SetActive(false);
			this.infoPanel.gameObject.SetActive(false);
			this.timeBar.gameObject.SetActive(false);
			this.upgradePanelTitle.gameObject.SetActive(false);
			this.infoPanelTitle.gameObject.SetActive(false);
			this.updateTimePanel.gameObject.SetActive(false);
			if (this.buildID > 0 && this.buildID <= 7)
			{
				this.normalPanel.gameObject.SetActive(true);
			}
			else
			{
				this.normalPanel.gameObject.SetActive(false);
			}
			if (this.buildLv == 0)
			{
				this.backOutBtnType = e_FuncBtnType.Cancel;
			}
			else
			{
				this.backOutBtnType = e_FuncBtnType.BackOut;
			}
			if (this.buildLvMAx == this.buildLv)
			{
				this.upgradeBtnType = e_FuncBtnType.MaxLv;
			}
			else
			{
				this.upgradeBtnType = e_FuncBtnType.Upgrade;
			}
			if (this.buildID == 7)
			{
				this.normalPanel.gameObject.SetActive(false);
				this.normallInfoPanel.gameObject.SetActive(false);
			}
			break;
		case e_BuildType.Upgrade:
			this.normallInfoPanel.gameObject.SetActive(false);
			this.normalPanel.gameObject.SetActive(false);
			if (this.buildLv == this.buildLvMAx)
			{
				this.upgradePanel.gameObject.SetActive(false);
			}
			else
			{
				this.upgradePanel.gameObject.SetActive(true);
			}
			this.infoPanel.gameObject.SetActive(true);
			this.timeBar.gameObject.SetActive(false);
			this.upgradePanelTitle.gameObject.SetActive(true);
			this.infoPanelTitle.gameObject.SetActive(true);
			this.updateTimePanel.gameObject.SetActive(this.m_bSpecialConform);
			if (this.manorID == GUIManager.Instance.BuildingData.BuildingManorID && this.buildID != 0)
			{
				if (DataManager.Instance.mPlayHelpDataType[1].Kind == 0)
				{
					this.upgradeBtnType = e_FuncBtnType.Help;
				}
				else
				{
					this.upgradeBtnType = e_FuncBtnType.Speed;
				}
			}
			else if (GUIManager.Instance.BuildingData.AllBuildsData[(int)this.manorID].BuildID == 0)
			{
				this.upgradeBtnType = e_FuncBtnType.Build;
				this.backOutBtnType = e_FuncBtnType.AtOnce_Build;
			}
			else
			{
				if (this.buildLv < this.buildLvMAx)
				{
					this.upgradeBtnType = e_FuncBtnType.Upgrade;
				}
				else
				{
					this.upgradeBtnType = e_FuncBtnType.MaxLv;
				}
				this.backOutBtnType = e_FuncBtnType.AtOnce_Upgrade;
			}
			break;
		case e_BuildType.Upgradeing:
			this.normallInfoPanel.gameObject.SetActive(false);
			this.normalPanel.gameObject.SetActive(false);
			if (this.buildLv == this.buildLvMAx)
			{
				this.upgradePanel.gameObject.SetActive(false);
			}
			else
			{
				this.upgradePanel.gameObject.SetActive(true);
			}
			this.infoPanel.gameObject.SetActive(true);
			this.timeBar.gameObject.SetActive(true);
			this.upgradePanelTitle.gameObject.SetActive(true);
			this.infoPanelTitle.gameObject.SetActive(true);
			this.updateTimePanel.gameObject.SetActive(false);
			this.backOutBtnType = e_FuncBtnType.Cancel;
			if (DataManager.Instance.mPlayHelpDataType[1].Kind == 0)
			{
				this.upgradeBtnType = e_FuncBtnType.Help;
			}
			else
			{
				this.upgradeBtnType = e_FuncBtnType.Speed;
			}
			break;
		case e_BuildType.SelfUpgradeing:
		case e_BuildType.SelfBackOuting:
			this.normallInfoPanel.gameObject.SetActive(true);
			this.normalPanel.gameObject.SetActive(true);
			this.upgradePanel.gameObject.SetActive(false);
			this.infoPanel.gameObject.SetActive(false);
			this.timeBar.gameObject.SetActive(true);
			this.upgradePanelTitle.gameObject.SetActive(false);
			this.infoPanelTitle.gameObject.SetActive(false);
			this.updateTimePanel.gameObject.SetActive(false);
			if (this.buildID > 0 && this.buildID <= 7)
			{
				this.normalPanel.gameObject.SetActive(true);
			}
			else
			{
				this.normalPanel.gameObject.SetActive(false);
			}
			if (this.buildType == e_BuildType.SelfBackOuting)
			{
				this.backOutBtnType = e_FuncBtnType.Cancel_BackOut;
			}
			else
			{
				this.backOutBtnType = e_FuncBtnType.Cancel;
			}
			if (_SpriteType == eTimerSpriteType.Speed)
			{
				this.upgradeBtnType = e_FuncBtnType.Speed;
			}
			else if (_SpriteType == eTimerSpriteType.Help)
			{
				this.upgradeBtnType = e_FuncBtnType.Help;
			}
			else if (_SpriteType == eTimerSpriteType.Free)
			{
				this.upgradeBtnType = e_FuncBtnType.Free;
			}
			if (this.buildID == 7)
			{
				this.normalPanel.gameObject.SetActive(false);
				this.normallInfoPanel.gameObject.SetActive(false);
			}
			break;
		case e_BuildType.Upgrade_Tech:
			this.normallInfoPanel.gameObject.SetActive(false);
			this.normalPanel.gameObject.SetActive(false);
			if (this.buildLv == this.buildLvMAx)
			{
				this.upgradePanel.gameObject.SetActive(false);
			}
			else
			{
				this.upgradePanel.gameObject.SetActive(true);
			}
			this.infoPanel.gameObject.SetActive(true);
			this.timeBar.gameObject.SetActive(false);
			this.upgradePanelTitle.gameObject.SetActive(true);
			this.infoPanelTitle.gameObject.SetActive(true);
			this.updateTimePanel.gameObject.SetActive(this.m_bSpecialConform);
			this.upgradeBtnType = e_FuncBtnType.Research;
			this.backOutBtnType = e_FuncBtnType.AtOnce_Research;
			break;
		case e_BuildType.Upgradeing_Tech:
			this.normallInfoPanel.gameObject.SetActive(false);
			this.normalPanel.gameObject.SetActive(false);
			if (this.techLv == this.techLvMax)
			{
				this.upgradePanel.gameObject.SetActive(false);
			}
			else
			{
				this.upgradePanel.gameObject.SetActive(true);
			}
			this.infoPanel.gameObject.SetActive(true);
			this.timeBar.gameObject.SetActive(true);
			this.upgradePanelTitle.gameObject.SetActive(true);
			this.infoPanelTitle.gameObject.SetActive(true);
			this.updateTimePanel.gameObject.SetActive(false);
			this.backOutBtnType = e_FuncBtnType.Cancel_Research;
			if (_SpriteType == eTimerSpriteType.Speed)
			{
				this.upgradeBtnType = e_FuncBtnType.Speed;
			}
			else if (_SpriteType == eTimerSpriteType.Help)
			{
				this.upgradeBtnType = e_FuncBtnType.Help;
			}
			else if (_SpriteType == eTimerSpriteType.Free)
			{
				this.upgradeBtnType = e_FuncBtnType.Free;
			}
			break;
		}
		if (this.style == 2)
		{
			if (this.buildType == e_BuildType.Normal || this.buildType == e_BuildType.SelfUpgradeing || this.buildType == e_BuildType.SelfBackOuting)
			{
				this.normalPanel.gameObject.SetActive(false);
				this.infoPanel.gameObject.SetActive(false);
				this.upgradePanelTitle.gameObject.SetActive(false);
				this.infoPanelTitle.gameObject.SetActive(false);
				this.buildingInfoTransform.gameObject.SetActive(false);
				this.SetUIPos(2);
			}
			else
			{
				this.buildingInfoTransform.gameObject.SetActive(true);
				this.SetUIPos(1);
			}
		}
		this.SetFuncBtnType();
		if (this.m_Handler != null)
		{
			this.m_Handler.OnTypeChange(this.buildType);
		}
	}

	// Token: 0x06002946 RID: 10566 RVA: 0x00458610 File Offset: 0x00456810
	private void Exit()
	{
		if (this.buildType == e_BuildType.Upgrade && GUIManager.Instance.BuildingData.AllBuildsData[(int)this.manorID].BuildID != 0)
		{
			this.SetBuildType(e_BuildType.Normal, eTimerSpriteType.Speed);
			GUIManager.Instance.HideArrow(false);
		}
		else if (this.door != null)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06002947 RID: 10567 RVA: 0x00458684 File Offset: 0x00456884
	private Sprite GetSpriteByEffect(ushort effectId)
	{
		Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(effectId);
		Sprite sprite;
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			this.effectString.ClearString();
			this.effectString.IntToFormat((long)recordByKey.EffectIcon, 3, false);
			this.effectString.AppendFormat("icon{0}_cn");
			sprite = this.GM.LoadFrameSprite(this.effectString);
			if (sprite == null)
			{
				this.effectString.ClearString();
				this.effectString.IntToFormat((long)recordByKey.EffectIcon, 3, false);
				this.effectString.AppendFormat("icon{0}");
				sprite = this.GM.LoadFrameSprite(this.effectString);
			}
		}
		else
		{
			this.effectString.ClearString();
			this.effectString.IntToFormat((long)recordByKey.EffectIcon, 3, false);
			this.effectString.AppendFormat("icon{0}");
			sprite = this.GM.LoadFrameSprite(this.effectString);
		}
		if (sprite == null)
		{
			sprite = this.GM.LoadFrameSprite("icon001");
		}
		return sprite;
	}

	// Token: 0x06002948 RID: 10568 RVA: 0x004587AC File Offset: 0x004569AC
	private void CheckBtnState(e_FuncBtnType bTnType)
	{
		if ((bTnType == e_FuncBtnType.Upgrade || bTnType == e_FuncBtnType.Build || bTnType == e_FuncBtnType.Research) && (this.buildType == e_BuildType.Upgrade || this.buildType == e_BuildType.Upgrade_Tech))
		{
			if (this.m_bGeneralConform && this.m_bGeneralConform_update && this.m_bSpecialConform)
			{
				this.upgradeBtn.m_BtnID2 = 200;
				this.upgradeBtn.ForTextChange(e_BtnType.e_Normal);
			}
			else
			{
				this.upgradeBtn.m_BtnID2 = 100;
				this.upgradeBtn.ForTextChange(e_BtnType.e_ChangeText);
			}
		}
	}

	// Token: 0x06002949 RID: 10569 RVA: 0x00458844 File Offset: 0x00456A44
	private byte CheckNowOpenEBuildTypeWindow(e_BuildType buildType)
	{
		if (buildType != e_BuildType.Upgrade && buildType != e_BuildType.Upgradeing)
		{
			return 0;
		}
		return 1;
	}

	// Token: 0x0600294A RID: 10570 RVA: 0x0045886C File Offset: 0x00456A6C
	private void OpenCheckBycastleLv6(int arg)
	{
		ushort id;
		if (DataManager.Instance.RoleAlliance.Id == 0u || DataManager.Instance.RoleAlliance.KingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
		{
			id = 5894;
		}
		else
		{
			id = 8593;
		}
		GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(5893u), DataManager.Instance.mStringTable.GetStringByID((uint)id), arg, 0, DataManager.Instance.mStringTable.GetStringByID(8595u), DataManager.Instance.mStringTable.GetStringByID(8596u));
	}

	// Token: 0x0600294B RID: 10571 RVA: 0x0045891C File Offset: 0x00456B1C
	private void OpenCheckBycastleLv8(int arg)
	{
		GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(5893u), DataManager.Instance.mStringTable.GetStringByID(9723u), arg, 0, DataManager.Instance.mStringTable.GetStringByID(5895u), DataManager.Instance.mStringTable.GetStringByID(5896u));
	}

	// Token: 0x0600294C RID: 10572 RVA: 0x00458988 File Offset: 0x00456B88
	private void SetTimeBarBtnSprite(eTimerSpriteType type, int Idx)
	{
		if (Idx < this.m_UpgradeItem.Length && this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages && this.m_UpgradeItem[Idx].m_UpgradeItemBtnText)
		{
			this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages.rectTransform.localScale = new Vector3(1f, 1f, 1f);
			if (type == eTimerSpriteType.Help)
			{
				this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages.sprite = this.door.LoadSprite("UI_main_queue_butt_help");
				this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.text = DataManager.Instance.mStringTable.GetStringByID(781u);
				this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.enabled = true;
				this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.SetAllDirty();
				this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.cachedTextGenerator.Invalidate();
			}
			else if (type == eTimerSpriteType.Free)
			{
				this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages.sprite = this.door.LoadSprite("UI_main_queue_butt_end");
				this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.text = DataManager.Instance.mStringTable.GetStringByID(780u);
				this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.enabled = true;
				this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.SetAllDirty();
				this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.cachedTextGenerator.Invalidate();
			}
			else
			{
				if (this.GM.IsArabic)
				{
					this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
				}
				this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages.sprite = this.door.LoadSprite("UI_main_queue_butt_up");
				this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.enabled = false;
			}
			this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages.rectTransform.sizeDelta = new Vector2(69f, 47f);
			this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages.material = this.door.LoadMaterial();
			this.m_UpgradeItem[Idx].timerSpriteType = type;
		}
	}

	// Token: 0x0600294D RID: 10573 RVA: 0x00458BE0 File Offset: 0x00456DE0
	public void Refresh_FontTexture()
	{
		if (this.backOutBtnText != null && this.backOutBtnText.enabled)
		{
			this.backOutBtnText.enabled = false;
			this.backOutBtnText.enabled = true;
		}
		if (this.backOutBtnMoneyText != null && this.backOutBtnMoneyText.enabled)
		{
			this.backOutBtnMoneyText.enabled = false;
			this.backOutBtnMoneyText.enabled = true;
		}
		if (this.upgradeBtnText != null && this.upgradeBtnText.enabled)
		{
			this.upgradeBtnText.enabled = false;
			this.upgradeBtnText.enabled = true;
		}
		if (this.titleText != null && this.titleText.enabled)
		{
			this.titleText.enabled = false;
			this.titleText.enabled = true;
		}
		if (this.updateTimeText1 != null && this.updateTimeText1.enabled)
		{
			this.updateTimeText1.enabled = false;
			this.updateTimeText1.enabled = true;
		}
		if (this.updateTimeText2 != null && this.updateTimeText2.enabled)
		{
			this.updateTimeText2.enabled = false;
			this.updateTimeText2.enabled = true;
		}
		if (this.lvText != null && this.lvText.enabled)
		{
			this.lvText.enabled = false;
			this.lvText.enabled = true;
		}
		int num = 0;
		while (this.normalPanelTitles != null && num < this.normalPanelTitles.Length)
		{
			if (this.normalPanelTitles[num] != null && this.normalPanelTitles[num].enabled)
			{
				this.normalPanelTitles[num].enabled = false;
				this.normalPanelTitles[num].enabled = true;
			}
			num++;
		}
		int num2 = 0;
		while (this.normalPanelInfos != null && num2 < this.normalPanelInfos.Length)
		{
			if (this.normalPanelInfos[num2] != null && this.normalPanelInfos[num2].enabled)
			{
				this.normalPanelInfos[num2].enabled = false;
				this.normalPanelInfos[num2].enabled = true;
			}
			num2++;
		}
		if (this.upgradeScrollPanelTitle != null && this.upgradeScrollPanelTitle.enabled)
		{
			this.upgradeScrollPanelTitle.enabled = false;
			this.upgradeScrollPanelTitle.enabled = true;
		}
		int num3 = 0;
		while (this.m_UpgradeInfoItemTexts != null && num3 < this.m_UpgradeInfoItemTexts.Length)
		{
			if (this.m_UpgradeInfoItemTexts[num3] != null && this.m_UpgradeInfoItemTexts[num3].enabled)
			{
				this.m_UpgradeInfoItemTexts[num3].enabled = false;
				this.m_UpgradeInfoItemTexts[num3].enabled = true;
			}
			num3++;
		}
		if (this.upgradeInfoScrollPanelTitle != null && this.upgradeInfoScrollPanelTitle.enabled)
		{
			this.upgradeInfoScrollPanelTitle.enabled = false;
			this.upgradeInfoScrollPanelTitle.enabled = true;
		}
		int num4 = 0;
		while (this.m_UpgradeItem != null && num4 < this.m_UpgradeItem.Length)
		{
			if (this.m_UpgradeItem[num4].m_UpgradeItemTexts != null && this.m_UpgradeItem[num4].m_UpgradeItemTexts.enabled)
			{
				this.m_UpgradeItem[num4].m_UpgradeItemTexts.enabled = false;
				this.m_UpgradeItem[num4].m_UpgradeItemTexts.enabled = true;
			}
			if (this.m_UpgradeItem[num4].m_UpgradeItemBtnText != null && this.m_UpgradeItem[num4].m_UpgradeItemBtnText.enabled)
			{
				this.m_UpgradeItem[num4].m_UpgradeItemBtnText.enabled = false;
				this.m_UpgradeItem[num4].m_UpgradeItemBtnText.enabled = true;
			}
			if (this.m_UpgradeItem[num4].m_UpgradeItemTimeTexts != null && this.m_UpgradeItem[num4].m_UpgradeItemTimeTexts.enabled)
			{
				this.m_UpgradeItem[num4].m_UpgradeItemTimeTexts.enabled = false;
				this.m_UpgradeItem[num4].m_UpgradeItemTimeTexts.enabled = true;
			}
			num4++;
		}
		for (int i = 0; i < this.m_TempText.Length; i++)
		{
			if (this.m_TempText[i] != null && this.m_TempText[i].enabled)
			{
				this.m_TempText[i].enabled = false;
				this.m_TempText[i].enabled = true;
			}
		}
		if (this.m_SetNormalInfoPanelText != null && this.m_SetNormalInfoPanelText.enabled)
		{
			this.m_SetNormalInfoPanelText.enabled = false;
			this.m_SetNormalInfoPanelText.enabled = true;
		}
		if (this.timeBar != null && this.timeBar.enabled)
		{
			this.timeBar.Refresh_FontTexture();
		}
	}

	// Token: 0x0600294E RID: 10574 RVA: 0x00459108 File Offset: 0x00457308
	private void SaveScrollPostion()
	{
		if (this.upgradeScrollPanel != null && this.upgradeScrollPanel.m_PanelObjects != null)
		{
			this.GM.m_BuildingTopIdx = this.upgradeScrollPanel.GetTopIdx();
			this.GM.m_BuildingPosY = this.upgradeScrollPanel.GetContentPos();
		}
	}

	// Token: 0x0600294F RID: 10575 RVA: 0x00459164 File Offset: 0x00457364
	private void ClearScrollPostionSave()
	{
		this.GM.m_BuildingTopIdx = 0;
		this.GM.m_BuildingPosY = 0f;
	}

	// Token: 0x06002950 RID: 10576 RVA: 0x00459184 File Offset: 0x00457384
	private void SetCustomCastleBtn(e_BuildType _buildType)
	{
		if ((_buildType == e_BuildType.Normal || _buildType == e_BuildType.SelfUpgradeing) && this.buildID == 8 && GUIManager.Instance.BuildingData.castleSkin.CheckShowCastleSkin())
		{
			this.customCastleTf.gameObject.SetActive(true);
			this.exclamationTf.gameObject.SetActive(GUIManager.Instance.BuildingData.castleSkin.CheckShowExclamation(true));
		}
		else
		{
			this.customCastleTf.gameObject.SetActive(false);
		}
	}

	// Token: 0x040073E2 RID: 29666
	private const int m_MaxUpgradeItemCount = 10;

	// Token: 0x040073E3 RID: 29667
	private const float m_DuringTime = 2f;

	// Token: 0x040073E4 RID: 29668
	private const float m_AnimBtnTime = 1f;

	// Token: 0x040073E5 RID: 29669
	private const int MaxTempTextNum = 5;

	// Token: 0x040073E6 RID: 29670
	private byte buildID;

	// Token: 0x040073E7 RID: 29671
	private byte style = 1;

	// Token: 0x040073E8 RID: 29672
	private byte buildLv;

	// Token: 0x040073E9 RID: 29673
	private ushort manorID;

	// Token: 0x040073EA RID: 29674
	private byte buildLvMAx = 25;

	// Token: 0x040073EB RID: 29675
	public e_BuildType buildType;

	// Token: 0x040073EC RID: 29676
	private string abName = "UI/BuildingWindow";

	// Token: 0x040073ED RID: 29677
	private int abKey;

	// Token: 0x040073EE RID: 29678
	private Material uiMat;

	// Token: 0x040073EF RID: 29679
	public Image mainTransform_Bg;

	// Token: 0x040073F0 RID: 29680
	public Image mainTransform_Bg2;

	// Token: 0x040073F1 RID: 29681
	public Transform mainTransform;

	// Token: 0x040073F2 RID: 29682
	public Transform mainTransform_V;

	// Token: 0x040073F3 RID: 29683
	public Transform mainTransform_H;

	// Token: 0x040073F4 RID: 29684
	private Transform buildingTransform;

	// Token: 0x040073F5 RID: 29685
	private Transform buildingTransformBG;

	// Token: 0x040073F6 RID: 29686
	private Transform buildingInfoTransform;

	// Token: 0x040073F7 RID: 29687
	private Transform uiButtonTransform;

	// Token: 0x040073F8 RID: 29688
	private Transform normalPanel;

	// Token: 0x040073F9 RID: 29689
	private Transform upgradePanel;

	// Token: 0x040073FA RID: 29690
	private Transform upgradePanelItem;

	// Token: 0x040073FB RID: 29691
	private Transform updateTimePanel;

	// Token: 0x040073FC RID: 29692
	private Transform timeTextTf1;

	// Token: 0x040073FD RID: 29693
	private Transform timeTitleTf1;

	// Token: 0x040073FE RID: 29694
	private Transform timeTextTf2;

	// Token: 0x040073FF RID: 29695
	private Transform timeTitleTf2;

	// Token: 0x04007400 RID: 29696
	private Transform infoPanel;

	// Token: 0x04007401 RID: 29697
	private Transform buildingLvBG;

	// Token: 0x04007402 RID: 29698
	public UIButton exitBtn;

	// Token: 0x04007403 RID: 29699
	private UIButton backOutBtn;

	// Token: 0x04007404 RID: 29700
	public UIButton upgradeBtn;

	// Token: 0x04007405 RID: 29701
	public RectTransform upgradeBtnRect;

	// Token: 0x04007406 RID: 29702
	private UIButton buildInfo;

	// Token: 0x04007407 RID: 29703
	private UIButton statistics;

	// Token: 0x04007408 RID: 29704
	private UIText backOutBtnText;

	// Token: 0x04007409 RID: 29705
	private UIText backOutBtnMoneyText;

	// Token: 0x0400740A RID: 29706
	private UIText upgradeBtnText;

	// Token: 0x0400740B RID: 29707
	private Image backOutBtnBgImage;

	// Token: 0x0400740C RID: 29708
	private Image upgradeBtnBGImage;

	// Token: 0x0400740D RID: 29709
	private Image backOutBtnImage;

	// Token: 0x0400740E RID: 29710
	private Image upgradeBtnImage;

	// Token: 0x0400740F RID: 29711
	private Transform exclamationTf;

	// Token: 0x04007410 RID: 29712
	private RectTransform backOutBtnImageRt;

	// Token: 0x04007411 RID: 29713
	private RectTransform upgradeBtnImageRt;

	// Token: 0x04007412 RID: 29714
	private RectTransform backOutBtnTextRt;

	// Token: 0x04007413 RID: 29715
	private UIText titleText;

	// Token: 0x04007414 RID: 29716
	private Image sliderBGImage;

	// Token: 0x04007415 RID: 29717
	private Image sliderImage;

	// Token: 0x04007416 RID: 29718
	private Transform maxLvImage;

	// Token: 0x04007417 RID: 29719
	private Transform upgradeBtnTf;

	// Token: 0x04007418 RID: 29720
	private Transform maxLvImageRotate;

	// Token: 0x04007419 RID: 29721
	private UIText updateTimeText1;

	// Token: 0x0400741A RID: 29722
	private UIText updateTimeText2;

	// Token: 0x0400741B RID: 29723
	private UIText lvText;

	// Token: 0x0400741C RID: 29724
	private UISpritesArray spArray;

	// Token: 0x0400741D RID: 29725
	private UISpritesArray btnSpArray;

	// Token: 0x0400741E RID: 29726
	private UISpritesArray btnBGSpArray;

	// Token: 0x0400741F RID: 29727
	private Material m_Mat;

	// Token: 0x04007420 RID: 29728
	private e_FuncBtnType backOutBtnType;

	// Token: 0x04007421 RID: 29729
	private e_FuncBtnType upgradeBtnType = e_FuncBtnType.Speed;

	// Token: 0x04007422 RID: 29730
	private UIText[] normalPanelTitles = new UIText[4];

	// Token: 0x04007423 RID: 29731
	private UIText[] normalPanelInfos = new UIText[4];

	// Token: 0x04007424 RID: 29732
	private Image[] normalPanelInfosImage = new Image[4];

	// Token: 0x04007425 RID: 29733
	private Transform normalPanelInfoTf3;

	// Token: 0x04007426 RID: 29734
	private Transform upgradePanelTitle;

	// Token: 0x04007427 RID: 29735
	private Transform infoPanelTitle;

	// Token: 0x04007428 RID: 29736
	private UITimeBar timeBar;

	// Token: 0x04007429 RID: 29737
	private ScrollPanel infoScrollPanel;

	// Token: 0x0400742A RID: 29738
	private ScrollPanel upgradeScrollPanel;

	// Token: 0x0400742B RID: 29739
	private Transform normallInfoPanel;

	// Token: 0x0400742C RID: 29740
	private StringBuilder sb = new StringBuilder();

	// Token: 0x0400742D RID: 29741
	private List<BuildInfoObject> upgradePanelData;

	// Token: 0x0400742E RID: 29742
	private int totalUpgradeCount;

	// Token: 0x0400742F RID: 29743
	private int upgradeDataIdx;

	// Token: 0x04007430 RID: 29744
	private List<BuildInfoObject2> upgradeEffectData;

	// Token: 0x04007431 RID: 29745
	private int totalUpgradeEffectCount;

	// Token: 0x04007432 RID: 29746
	private int upgradeEffectIdx;

	// Token: 0x04007433 RID: 29747
	public IBuildingWindowType m_Handler;

	// Token: 0x04007434 RID: 29748
	public Transform baseTransform;

	// Token: 0x04007435 RID: 29749
	private UIText upgradeScrollPanelTitle;

	// Token: 0x04007436 RID: 29750
	private UpgradeItemObject[] m_UpgradeItem;

	// Token: 0x04007437 RID: 29751
	private int m_MaxUpgradeInfoItemCount = 6;

	// Token: 0x04007438 RID: 29752
	private UIText[] m_UpgradeInfoItemTexts;

	// Token: 0x04007439 RID: 29753
	private Image[] m_UpgradeInfoItemImages;

	// Token: 0x0400743A RID: 29754
	private UIText upgradeInfoScrollPanelTitle;

	// Token: 0x0400743B RID: 29755
	private string[] iconSpriteName;

	// Token: 0x0400743C RID: 29756
	private string[] iconBulidSpriteName;

	// Token: 0x0400743D RID: 29757
	private string petResIcon = "UI_main_Force";

	// Token: 0x0400743E RID: 29758
	private Transform customCastleTf;

	// Token: 0x0400743F RID: 29759
	private CString tempString;

	// Token: 0x04007440 RID: 29760
	private CString tempString3;

	// Token: 0x04007441 RID: 29761
	private CString effectString;

	// Token: 0x04007442 RID: 29762
	private CString tempString2;

	// Token: 0x04007443 RID: 29763
	private float m_TimeTick = 1f;

	// Token: 0x04007444 RID: 29764
	private long m_BuildStartTime;

	// Token: 0x04007445 RID: 29765
	private long m_BuildEndTime;

	// Token: 0x04007446 RID: 29766
	private int m_TimeObjectIdx;

	// Token: 0x04007447 RID: 29767
	private bool m_bNeedShow;

	// Token: 0x04007448 RID: 29768
	private long m_updateTime;

	// Token: 0x04007449 RID: 29769
	private uint m_BackOutTime;

	// Token: 0x0400744A RID: 29770
	private uint m_BackOutCostCrystal;

	// Token: 0x0400744B RID: 29771
	private float m_ResTimeTick = 1f;

	// Token: 0x0400744C RID: 29772
	private int[] m_ResUpdateTextsIdx = new int[]
	{
		-1,
		-1,
		-1,
		-1,
		-1
	};

	// Token: 0x0400744D RID: 29773
	private bool m_bSpecialConform;

	// Token: 0x0400744E RID: 29774
	private bool m_bGeneralConform;

	// Token: 0x0400744F RID: 29775
	private bool m_bGeneralConform_update = true;

	// Token: 0x04007450 RID: 29776
	private bool bIsTechWindow;

	// Token: 0x04007451 RID: 29777
	private byte techID;

	// Token: 0x04007452 RID: 29778
	private byte techLv;

	// Token: 0x04007453 RID: 29779
	private byte techLvMax = 25;

	// Token: 0x04007454 RID: 29780
	private uint[] m_CostCrystal = new uint[10];

	// Token: 0x04007455 RID: 29781
	private string m_TimeBarStr1;

	// Token: 0x04007456 RID: 29782
	private string m_TimeBarStr2;

	// Token: 0x04007457 RID: 29783
	private bool bOpenBackOutCheckBox;

	// Token: 0x04007458 RID: 29784
	private ushort GuideParm2;

	// Token: 0x04007459 RID: 29785
	private float m_TickBeginAnimBtnTime = 2f;

	// Token: 0x0400745A RID: 29786
	private float m_TickEndAnimBtnTime = 1f;

	// Token: 0x0400745B RID: 29787
	private Door door;

	// Token: 0x0400745C RID: 29788
	private GUIManager GM;

	// Token: 0x0400745D RID: 29789
	private UIText[] m_TempText = new UIText[5];

	// Token: 0x0400745E RID: 29790
	private int m_TempTextIdx;

	// Token: 0x0400745F RID: 29791
	private UIText m_SetNormalInfoPanelText;

	// Token: 0x04007460 RID: 29792
	private byte bUpdateFreeState;
}
