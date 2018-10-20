using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200062F RID: 1583
public class UIMarket_Help : GUIWindow, IUIButtonClickHandler, IUICalculatorHandler, IUIUnitRSliderHandler
{
	// Token: 0x06001E8E RID: 7822 RVA: 0x003A6260 File Offset: 0x003A4460
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.SM = StringManager.Instance;
		this.GM = GUIManager.Instance;
		this.ST = this.DM.mStringTable;
		Font ttffont = this.GM.GetTTFFont();
		this.m_transform = base.transform;
		this.door = (this.GM.FindMenu(EGUIWindow.Door) as Door);
		byte b = 1;
		ushort hiid = 1;
		this.NameStr = this.SM.SpawnString(30);
		if (arg1 == 1)
		{
			MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[arg2];
			PlayerPoint playerPoint = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID];
			this.NameStr.Append(playerPoint.playerName);
			b = playerPoint.allianceRank;
			hiid = playerPoint.portraitID;
			GameConstants.MapIDToPointCode(arg2, out this.DesPoint.zoneID, out this.DesPoint.pointID);
		}
		else if (arg1 == 2)
		{
			AllianceMemberClientDataType allianceMemberClientDataType = this.DM.AllianceMember[arg2];
			this.NameStr.Append(allianceMemberClientDataType.Name);
			b = (byte)allianceMemberClientDataType.Rank;
			hiid = allianceMemberClientDataType.Head;
			this.DesPoint = this.DM.AllyMemberLoc;
		}
		else if (arg1 == 3)
		{
			this.NameStr.Append(this.DM.mLordProfile.PlayerName);
			b = this.DM.mLordProfile.AlliRank;
			hiid = this.DM.mLordProfile.Head;
			this.DesPoint = this.DM.AllyMemberLoc;
		}
		else
		{
			this.NameStr.Append("TestHelpName");
		}
		this.mBD = this.GM.BuildingData.GetBuildData(17, 0);
		this.mBR = this.GM.BuildingData.GetBuildLevelRequestData(17, this.mBD.Level);
		UIButton component = this.m_transform.GetChild(9).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1;
		this.HelpButton = this.m_transform.GetChild(10).GetComponent<UIButton>();
		this.HelpButton.m_Handler = this;
		this.HelpButton.m_BtnID1 = 2;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(9).GetComponent<Image>().enabled = false;
		}
		this.RBText[5] = this.m_transform.GetChild(11).GetComponent<UIText>();
		this.RBText[5].font = ttffont;
		this.RBText[5].text = this.DM.mStringTable.GetStringByID(4040u);
		this.HelpButtonText = this.HelpButton.transform.GetChild(0).GetComponent<UIText>();
		this.HelpButtonText.font = ttffont;
		this.HelpButtonText.text = this.DM.mStringTable.GetStringByID(4039u);
		this.HelpButton.m_Text = this.HelpButtonText;
		this.HelpButton.ForTextChange(e_BtnType.e_ChangeText);
		this.RBText[6] = this.m_transform.GetChild(12).GetComponent<UIText>();
		this.RBText[6].font = ttffont;
		this.RBText[6].text = this.NameStr.ToString();
		UISpritesArray component2 = this.m_transform.GetChild(3).GetComponent<UISpritesArray>();
		component2.SetSpriteIndex((int)(b - 1));
		if (this.GM.IsArabic)
		{
			((RectTransform)this.m_transform.GetChild(3)).localScale = new Vector3(-1f, 1f, 1f);
		}
		GUIManager.Instance.InitianHeroItemImg(this.m_transform.GetChild(4), eHeroOrItem.Hero, hiid, 11, 0, 0, false, false, true, false);
		this.LTaxText = this.m_transform.GetChild(13).GetComponent<UIText>();
		this.LTaxText.font = ttffont;
		this.TaxStr = this.SM.SpawnString(30);
		this.TaxText = this.m_transform.GetChild(14).GetComponent<UIText>();
		this.TaxText.font = ttffont;
		this.TaxStr2 = this.SM.SpawnString(30);
		this.TaxStr2.Length = 0;
		StringManager.IntToStr(this.TaxStr2, 0L, 1, false);
		this.TaxText.text = this.TaxStr2.ToString();
		this.RBText[7] = this.m_transform.GetChild(15).GetComponent<UIText>();
		this.RBText[7].font = ttffont;
		this.RBText[7].text = this.DM.mStringTable.GetStringByID(4038u);
		this.LoadingMax = this.GetMaxLoading();
		this.LoadingText = this.m_transform.GetChild(16).GetComponent<UIText>();
		this.LoadingText.font = ttffont;
		this.LoadingStr2 = this.SM.SpawnString(30);
		this.RefreshTax();
		this.AddSpeedText = this.m_transform.GetChild(18).GetComponent<UIText>();
		this.AddSpeedText.font = ttffont;
		this.BootsStr = this.SM.SpawnString(30);
		this.TotalTimeText = this.m_transform.GetChild(17).GetComponent<UIText>();
		this.TotalTimeText.font = ttffont;
		this.TimeStr = this.SM.SpawnString(30);
		this.RefreshSpeed();
		this.m_DResourcesT = this.m_transform.GetChild(19);
		this.m_DResources = this.m_DResourcesT.GetComponent<DemandResources>();
		this.GM.InitDemandResources(this.m_DResourcesT, 489f, 100f, false);
		for (int i = 0; i < 5; i++)
		{
			this.m_DResources.TextResources[i].fontSize = 14;
		}
		this.GM.SetDemandResourcesText(this.m_DResources.GetComponent<Transform>(), this.lSendResource);
		Transform child = this.m_transform.GetChild(20).GetChild(0);
		for (int j = 0; j < 5; j++)
		{
			this.lResource[j] = (long)((ulong)this.DM.Resource[j].Stock);
			this.ResourcesStr[j] = this.SM.SpawnString(30);
			Transform child2 = child.GetChild(j);
			Transform child3 = child2.GetChild(0);
			Image component3 = child3.GetChild(0).GetComponent<Image>();
			component3.sprite = this.GM.m_ItemIconSpriteAsset.LoadSprite((ushort)(1001 + j));
			component3.material = this.GM.m_ItemIconSpriteAsset.GetMaterial();
			component3 = child3.GetChild(1).GetComponent<Image>();
			component3.material = this.GM.GetFrameMaterial();
			component3.sprite = this.GM.LoadFrameSprite("if001");
			this.RBText[j] = child2.GetChild(1).GetComponent<UIText>();
			this.RBText[j].font = ttffont;
			this.RBText[j].text = this.DM.mStringTable.GetStringByID((uint)(3952 + j));
			child3 = child2.GetChild(2);
			this.GM.InitUnitResourcesSlider(child3, eUnitSlider.MarketHelp, 0u, (uint)this.lResource[j], 0.7f);
			this.m_Slider[j] = child3.GetComponent<UnitResourcesSlider>();
			this.m_Slider[j].m_Handler = this;
			this.m_Slider[j].m_ID = j;
			this.m_Slider[j].BtnInputText.m_Handler = this;
			this.m_Slider[j].BtnInputText.m_BtnID1 = 3;
			this.m_Slider[j].BtnInputText.m_BtnID2 = j;
			this.GM.SetUnitResourcesSliderSize(child3, eUnitSliderSize.Input, 85f, 26f, 110f, 26f, 0f, 0f);
		}
		if (this.GM.m_OpenResourceMenu)
		{
			for (int k = 0; k < 5; k++)
			{
				if (this.GM.m_SaveResource[k] > 0u)
				{
					this.CheckResource(k, (long)((ulong)this.GM.m_SaveResource[k]));
					this.SetSlider(k, (long)((ulong)this.GM.m_SaveResource[k]));
				}
			}
		}
		else
		{
			this.GM.m_OpenResourceMenu = true;
		}
		this.RefreshResource(false);
		this.GM.UpdateUI(EGUIWindow.Door, 1, 2);
		this.bOpen = true;
	}

	// Token: 0x06001E8F RID: 7823 RVA: 0x003A6B0C File Offset: 0x003A4D0C
	public override void OnClose()
	{
		if (this.NameStr != null)
		{
			StringManager.Instance.DeSpawnString(this.NameStr);
		}
		if (this.TaxStr != null)
		{
			StringManager.Instance.DeSpawnString(this.TaxStr);
		}
		if (this.TaxStr2 != null)
		{
			StringManager.Instance.DeSpawnString(this.TaxStr2);
		}
		if (this.LoadingStr2 != null)
		{
			StringManager.Instance.DeSpawnString(this.LoadingStr2);
		}
		if (this.TimeStr != null)
		{
			StringManager.Instance.DeSpawnString(this.TimeStr);
		}
		if (this.BootsStr != null)
		{
			StringManager.Instance.DeSpawnString(this.BootsStr);
		}
		for (int i = 0; i < 5; i++)
		{
			if (this.ResourcesStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.ResourcesStr[i]);
			}
		}
		GUIManager.Instance.ClearCalculator();
	}

	// Token: 0x06001E90 RID: 7824 RVA: 0x003A6C00 File Offset: 0x003A4E00
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		this.bOpenOkCancelBox = false;
		if (bOK)
		{
			int num = 0;
			uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
			for (int i = 0; i < 8; i++)
			{
				if (this.DM.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
				{
					num++;
				}
			}
			if ((long)num >= (long)((ulong)effectBaseVal))
			{
				this.GM.MsgStr.Length = 0;
				this.GM.MsgStr.IntToFormat((long)((ulong)effectBaseVal), 1, false);
				this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(3959u));
				this.GM.OpenMessageBox(this.ST.GetStringByID(3967u), this.GM.MsgStr.ToString(), this.ST.GetStringByID(4034u), null, 0, 0, false, false, false, false, false);
				return;
			}
			if (this.GM.BuildingData.GetBuildData(17, 0).Level <= 0)
			{
				this.GM.OpenMessageBox(this.ST.GetStringByID(4834u), this.ST.GetStringByID(4835u), this.ST.GetStringByID(4836u), null, 0, 0, false, false, false, false, false);
				return;
			}
			bool flag = true;
			for (int j = 0; j < 5; j++)
			{
				if (this.lSendResource[j] > 0L)
				{
					flag = false;
				}
			}
			if (flag)
			{
				this.GM.OpenMessageBox(this.ST.GetStringByID(4829u), this.ST.GetStringByID(3870u), this.ST.GetStringByID(4831u), null, 0, 0, false, false, false, false, false);
				return;
			}
			this.SendHelp();
		}
	}

	// Token: 0x06001E91 RID: 7825 RVA: 0x003A6DDC File Offset: 0x003A4FDC
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.door.CloseMenu(false);
			if (arg2 != 0)
			{
				if (arg2 == 1)
				{
					this.GM.MsgStr.Length = 0;
					uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
					this.GM.MsgStr.IntToFormat((long)((ulong)effectBaseVal), 1, false);
					this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(3959u));
					this.GM.OpenMessageBox(this.ST.GetStringByID(3967u), this.GM.MsgStr.ToString(), this.ST.GetStringByID(4034u), null, 0, 0, false, false, false, false, false);
				}
				else if (arg2 == 4)
				{
					this.GM.OpenMessageBox(this.ST.GetStringByID(5715u), this.ST.GetStringByID(5716u), this.ST.GetStringByID(5717u), null, 0, 0, false, false, false, false, false);
				}
				else if (arg2 == 5)
				{
					this.GM.OpenMessageBox(this.ST.GetStringByID(4032u), this.ST.GetStringByID(3957u), this.ST.GetStringByID(4033u), null, 0, 0, false, false, false, false, false);
				}
				else if (arg2 == 6)
				{
					this.GM.OpenMessageBox(this.ST.GetStringByID(4834u), this.ST.GetStringByID(4835u), this.ST.GetStringByID(4836u), null, 0, 0, false, false, false, false, false);
				}
				else if (arg2 == 8)
				{
					this.GM.OpenMessageBox(this.ST.GetStringByID(4829u), this.ST.GetStringByID(3870u), this.ST.GetStringByID(4831u), null, 0, 0, false, false, false, false, false);
				}
				else if (arg2 == 11)
				{
					this.GM.OpenMessageBox(this.ST.GetStringByID(4829u), this.ST.GetStringByID(5920u), this.ST.GetStringByID(4831u), null, 0, 0, false, false, false, false, false);
				}
				else
				{
					this.GM.MsgStr.Length = 0;
					this.GM.MsgStr.IntToFormat((long)arg2, 1, false);
					this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(12068u));
					this.GM.OpenMessageBox(this.ST.GetStringByID(4829u), this.GM.MsgStr.ToString(), this.ST.GetStringByID(4831u), null, 0, 0, false, false, false, false, false);
				}
			}
			for (int i = 0; i < 5; i++)
			{
				this.GM.m_SaveResource[i] = 0u;
			}
			this.GM.m_OpenResourceMenu = false;
		}
		else if (arg1 == 2)
		{
			this.RefreshTax();
			this.RefreshResource(false);
			this.RefreshSpeed();
		}
	}

	// Token: 0x06001E92 RID: 7826 RVA: 0x003A7114 File Offset: 0x003A5314
	public override void UpdateNetwork(byte[] meg)
	{
		if (!this.bOpen)
		{
			return;
		}
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_BuildBase:
			this.RefreshTax();
			this.RefreshResource(false);
			break;
		default:
			if (networkNews != NetworkNews.Login)
			{
				if (networkNews != NetworkNews.Refresh_Resource)
				{
					if (networkNews != NetworkNews.Refresh_BuffList)
					{
						if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
						{
							if (this.HelpButtonText != null && this.HelpButtonText.enabled)
							{
								this.HelpButtonText.enabled = false;
								this.HelpButtonText.enabled = true;
							}
							if (this.TaxText != null && this.TaxText.enabled)
							{
								this.TaxText.enabled = false;
								this.TaxText.enabled = true;
							}
							if (this.LoadingText != null && this.LoadingText.enabled)
							{
								this.LoadingText.enabled = false;
								this.LoadingText.enabled = true;
							}
							if (this.LTaxText != null && this.LTaxText.enabled)
							{
								this.LTaxText.enabled = false;
								this.LTaxText.enabled = true;
							}
							if (this.AddSpeedText != null && this.AddSpeedText.enabled)
							{
								this.AddSpeedText.enabled = false;
								this.AddSpeedText.enabled = true;
							}
							if (this.TotalTimeText != null && this.TotalTimeText.enabled)
							{
								this.TotalTimeText.enabled = false;
								this.TotalTimeText.enabled = true;
							}
							for (int i = 0; i < this.RBText.Length; i++)
							{
								if (this.RBText[i] != null && this.RBText[i].enabled)
								{
									this.RBText[i].enabled = false;
									this.RBText[i].enabled = true;
								}
							}
							if (this.m_DResources != null)
							{
								this.m_DResources.Refresh_FontTexture();
							}
							for (int j = 0; j < this.m_Slider.Length; j++)
							{
								if (this.m_Slider[j] != null)
								{
									this.m_Slider[j].Refresh_FontTexture();
								}
							}
						}
					}
					else
					{
						this.RefreshSpeed();
					}
				}
				else
				{
					this.RefreshResource(true);
				}
			}
			else
			{
				this.RefreshTax();
				this.RefreshResource(false);
				this.RefreshSpeed();
			}
			break;
		case NetworkNews.Refresh_Technology:
			this.RefreshTax();
			this.RefreshResource(false);
			this.RefreshSpeed();
			break;
		}
	}

	// Token: 0x06001E93 RID: 7827 RVA: 0x003A73CC File Offset: 0x003A55CC
	public override bool OnBackButtonClick()
	{
		for (int i = 0; i < 5; i++)
		{
			this.GM.m_SaveResource[i] = 0u;
		}
		this.GM.m_OpenResourceMenu = false;
		return false;
	}

	// Token: 0x06001E94 RID: 7828 RVA: 0x003A7408 File Offset: 0x003A5608
	public void RefreshResource(bool FromNetWork = false)
	{
		this.GM.SetDemandResourcesText(this.m_DResources.transform, this.lSendResource);
		long num = (long)Math.Ceiling((double)(this.LoadingMax * 100L) / (100.0 - this.Tax));
		for (int i = 0; i < 5; i++)
		{
			long num2 = (long)((ulong)this.DM.Resource[i].Stock);
			bool flag = (!FromNetWork || this.OpenIndex != i) && !this.bOpenOkCancelBox;
			if (flag && this.lSendResource[i] > num2)
			{
				this.CheckResource(i, num2);
			}
			if (num < num2)
			{
				num2 = num;
			}
			if (flag)
			{
				this.m_Slider[i].m_slider.maxValue = (double)num2;
			}
			this.m_Slider[i].MaxValue = num2;
		}
	}

	// Token: 0x06001E95 RID: 7829 RVA: 0x003A74E8 File Offset: 0x003A56E8
	public void RefreshSpeed()
	{
		this.BootsStr.Length = 0;
		this.BootsStr.StringToFormat(this.DM.mStringTable.GetStringByID(4999u));
		int num = (int)(this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED) + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRADE_MARCH_SPEED) - this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_DEBUFF));
		int effectBaseVal = (int)this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_CURSE);
		this.BootsStr.IntToFormat((long)(num / 100), 1, false);
		this.BootsStr.AppendFormat("{0} : <color=#1FF984>{1}%</color>");
		this.AddSpeedText.text = this.BootsStr.ToString();
		this.AddSpeedText.SetAllDirty();
		this.AddSpeedText.cachedTextGenerator.Invalidate();
		Vector2 tileMapPosbyMapID = GameConstants.getTileMapPosbyMapID(DataManager.Instance.RoleAttr.CapitalPoint);
		Vector2 tileMapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(this.DesPoint.zoneID, this.DesPoint.pointID);
		float num2 = Vector2.Distance(tileMapPosbyMapID, tileMapPosbyPointCode);
		float num3 = 14f * this.GATTR_INC_PERCENTAGE(1f, (float)effectBaseVal) / this.GATTR_INC_PERCENTAGE(1f, (float)num);
		uint sec = (uint)Mathf.Ceil(num3 * num2);
		this.TimeStr.Length = 0;
		GameConstants.GetTimeString(this.TimeStr, sec, false, false, true, false, true);
		this.TotalTimeText.text = this.TimeStr.ToString();
		this.TotalTimeText.SetAllDirty();
		this.TotalTimeText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001E96 RID: 7830 RVA: 0x003A7680 File Offset: 0x003A5880
	public void RefreshTax()
	{
		this.mBD = this.GM.BuildingData.GetBuildData(17, 0);
		this.mBR = this.GM.BuildingData.GetBuildLevelRequestData(17, this.mBD.Level);
		uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_TRADE_TAX_REDUCTION);
		if (this.mBR.Value2 >= effectBaseVal)
		{
			this.Tax = (this.mBR.Value2 - effectBaseVal) / 100.0;
		}
		this.TaxStr.Length = 0;
		this.TaxStr.DoubleToFormat(this.Tax, 1, false);
		this.TaxStr.AppendFormat(this.DM.mStringTable.GetStringByID(4037u));
		this.LTaxText.text = this.TaxStr.ToString();
		this.LTaxText.SetAllDirty();
		this.LTaxText.cachedTextGenerator.Invalidate();
		if (this.bOpen)
		{
			this.TotalTax = 0L;
			for (int i = 0; i < 5; i++)
			{
				this.lTaxResource[i] = (long)Math.Ceiling((double)this.lSendResource[i] * this.Tax / 100.0);
				this.TotalTax += this.lTaxResource[i];
			}
			this.TotalLoading = this.TotalSend - this.TotalTax;
		}
		this.TaxStr2.Length = 0;
		this.TaxStr2.IntToFormat(this.TotalTax, 1, true);
		if (this.GM.IsArabic)
		{
			this.TaxStr2.AppendFormat("{0}-");
		}
		else
		{
			this.TaxStr2.AppendFormat("-{0}");
		}
		this.TaxText.text = this.TaxStr2.ToString();
		this.TaxText.SetAllDirty();
		this.TaxText.cachedTextGenerator.Invalidate();
		this.LoadingMax = this.GetMaxLoading();
		this.LoadingStr2.Length = 0;
		this.LoadingStr2.IntToFormat(this.TotalLoading, 1, true);
		this.LoadingStr2.IntToFormat(this.LoadingMax, 1, true);
		if (this.GM.IsArabic)
		{
			this.LoadingStr2.AppendFormat("{1} / {0}");
		}
		else
		{
			this.LoadingStr2.AppendFormat("{0} / {1}");
		}
		this.LoadingText.text = this.LoadingStr2.ToString();
		this.LoadingText.SetAllDirty();
		this.LoadingText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001E97 RID: 7831 RVA: 0x003A7920 File Offset: 0x003A5B20
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 1:
			for (int i = 0; i < 5; i++)
			{
				this.GM.m_SaveResource[i] = 0u;
			}
			this.GM.m_OpenResourceMenu = false;
			this.door.CloseMenu(false);
			break;
		case 2:
			if (this.TotalLoading > 0L)
			{
				this.GM.MsgStr.Length = 0;
				this.GM.MsgStr.StringToFormat(this.TimeStr);
				this.GM.MsgStr.StringToFormat(this.NameStr);
				this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(3958u));
				this.GM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(3972u), this.GM.MsgStr.ToString(), 0, 0, null, null);
				this.bOpenOkCancelBox = true;
			}
			break;
		case 3:
			this.GM.m_UICalculator.m_CalculatorHandler = this;
			this.GM.m_UICalculator.OpenCalculator(this.m_Slider[sender.m_BtnID2].MaxValue, this.m_Slider[sender.m_BtnID2].Value, 260f, 100f, this.m_Slider[sender.m_BtnID2], 0L);
			this.OpenIndex = sender.m_BtnID2;
			break;
		}
	}

	// Token: 0x06001E98 RID: 7832 RVA: 0x003A7AAC File Offset: 0x003A5CAC
	public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
	{
		URS.m_slider.value = (double)mValue;
		URS.SliderValueChange();
		this.OpenIndex = -1;
	}

	// Token: 0x06001E99 RID: 7833 RVA: 0x003A7AC8 File Offset: 0x003A5CC8
	public void OnVauleChang(UnitResourcesSlider sender)
	{
		int id = sender.m_ID;
		if (!this.CheckResourceMax(id, sender))
		{
			return;
		}
		StringManager.IntToStr(this.ResourcesStr[id], sender.Value, 1, true);
		sender.m_inputText.text = this.ResourcesStr[id].ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
		this.CheckResource(id, sender.Value);
	}

	// Token: 0x06001E9A RID: 7834 RVA: 0x003A7B40 File Offset: 0x003A5D40
	public void OnTextChang(UnitResourcesSlider sender)
	{
		int id = sender.m_ID;
		if (!this.CheckResourceMax(id, sender))
		{
			return;
		}
		StringManager.IntToStr(this.ResourcesStr[id], sender.Value, 1, true);
		this.m_Slider[id].m_inputText.text = this.ResourcesStr[id].ToString();
		this.m_Slider[id].m_inputText.SetAllDirty();
		this.m_Slider[id].m_inputText.cachedTextGenerator.Invalidate();
		this.CheckResource(id, sender.Value);
	}

	// Token: 0x06001E9B RID: 7835 RVA: 0x003A7BD0 File Offset: 0x003A5DD0
	public bool CheckResourceMax(int index, UnitResourcesSlider sender)
	{
		if (sender.Value <= this.lSendResource[index])
		{
			return true;
		}
		if (this.TotalLoading >= this.LoadingMax && sender.Value - this.lSendResource[index] == 1L)
		{
			long num = 0L;
			int num2 = -1;
			for (int i = 0; i < 5; i++)
			{
				if (i != index && this.lSendResource[i] > num)
				{
					num = this.lSendResource[i];
					num2 = i;
				}
			}
			if (num2 != -1)
			{
				this.CheckResource(num2, this.lSendResource[num2] - 1L);
				this.SetSlider(num2, this.lSendResource[num2] - 1L);
				return true;
			}
			return false;
		}
		else
		{
			byte b = 0;
			long num3 = this.TotalSend - this.lSendResource[index];
			long num4 = 0L;
			long num5 = (long)Math.Ceiling((double)sender.Value * this.Tax / 100.0);
			for (int j = 0; j < 5; j++)
			{
				if (j != index && this.lSendResource[j] != 0L)
				{
					num4 += this.lTaxResource[j];
					b += 1;
				}
			}
			long num6 = num3 + sender.Value - (num4 + num5);
			if (num6 > this.LoadingMax)
			{
				long num7 = (long)Math.Ceiling((double)(this.LoadingMax - (sender.Value - num5)) * 100.0 / (100.0 - this.Tax));
				long num8 = num7;
				for (int k = 0; k < 5; k++)
				{
					if (k != index && this.lSendResource[k] != 0L)
					{
						b -= 1;
						long num9;
						if (b == 0)
						{
							num9 = num8;
						}
						else
						{
							num9 = (long)((double)num7 * ((double)this.lSendResource[k] / (double)num3));
							num8 -= num9;
						}
						this.CheckResource(k, num9);
						this.SetSlider(k, num9);
					}
				}
				this.CheckResource(index, sender.Value);
				this.SetSlider(index, sender.Value);
				return false;
			}
			return true;
		}
	}

	// Token: 0x06001E9C RID: 7836 RVA: 0x003A7DE0 File Offset: 0x003A5FE0
	public void CheckResource(int index, long Value)
	{
		this.TotalSend -= this.lSendResource[index];
		this.lTaxResource[index] = (long)Math.Ceiling((double)Value * this.Tax / 100.0);
		this.lSendResource[index] = Value;
		this.GM.m_SaveResource[index] = (uint)Value;
		this.TotalSend += this.lSendResource[index];
		this.TotalTax = 0L;
		for (int i = 0; i < 5; i++)
		{
			this.TotalTax += this.lTaxResource[i];
		}
		this.TotalLoading = this.TotalSend - this.TotalTax;
		if (this.TotalLoading > 0L)
		{
			this.HelpButton.ForTextChange(e_BtnType.e_Normal);
		}
		else
		{
			this.HelpButton.ForTextChange(e_BtnType.e_ChangeText);
		}
		this.TaxStr2.Length = 0;
		this.TaxStr2.IntToFormat(this.TotalTax, 1, true);
		if (this.GM.IsArabic)
		{
			this.TaxStr2.AppendFormat("{0}-");
		}
		else
		{
			this.TaxStr2.AppendFormat("-{0}");
		}
		this.TaxText.text = this.TaxStr2.ToString();
		this.TaxText.SetAllDirty();
		this.TaxText.cachedTextGenerator.Invalidate();
		this.LoadingStr2.Length = 0;
		this.LoadingStr2.IntToFormat(this.TotalLoading, 1, true);
		this.LoadingStr2.IntToFormat(this.LoadingMax, 1, true);
		if (this.GM.IsArabic)
		{
			this.LoadingStr2.AppendFormat("{1} / {0}");
		}
		else
		{
			this.LoadingStr2.AppendFormat("{0} / {1}");
		}
		this.LoadingText.text = this.LoadingStr2.ToString();
		this.LoadingText.SetAllDirty();
		this.LoadingText.cachedTextGenerator.Invalidate();
		this.GM.SetDemandResourcesText(this.m_DResources.transform, this.lSendResource);
	}

	// Token: 0x06001E9D RID: 7837 RVA: 0x003A7FFC File Offset: 0x003A61FC
	private float GATTR_INC_PERCENTAGE(float Val, float Percent)
	{
		return Val * (10000f + Percent) / 10000f;
	}

	// Token: 0x06001E9E RID: 7838 RVA: 0x003A8010 File Offset: 0x003A6210
	public void SendHelp()
	{
		if (this.GM.ShowUILock(EUILock.Scout))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_SEND_RESHELP;
			messagePacket.AddSeqId();
			messagePacket.Add(this.DesPoint.zoneID);
			messagePacket.Add(this.DesPoint.pointID);
			for (int i = 0; i < 5; i++)
			{
				this.GM.m_SendResource[i] = (uint)this.lSendResource[i];
				messagePacket.Add(this.GM.m_SendResource[i]);
			}
			messagePacket.Send(false);
		}
	}

	// Token: 0x06001E9F RID: 7839 RVA: 0x003A80B0 File Offset: 0x003A62B0
	private void SetSlider(int index, long Value)
	{
		this.m_Slider[index].m_slider.value = (double)Value;
		this.m_Slider[index].Value = Value;
		StringManager.IntToStr(this.ResourcesStr[index], Value, 1, true);
		this.m_Slider[index].m_inputText.text = this.ResourcesStr[index].ToString();
		this.m_Slider[index].m_inputText.SetAllDirty();
		this.m_Slider[index].m_inputText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001EA0 RID: 7840 RVA: 0x003A8138 File Offset: 0x003A6338
	private long GetMaxLoading()
	{
		uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_TRADE_CAPACITY);
		uint effectBaseVal2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_TRADE_CAPACITY_PERCENT);
		return (long)(effectBaseVal * ((10000u + effectBaseVal2) / 10000.0));
	}

	// Token: 0x040060AF RID: 24751
	private Transform m_transform;

	// Token: 0x040060B0 RID: 24752
	private Transform m_DResourcesT;

	// Token: 0x040060B1 RID: 24753
	private CString NameStr;

	// Token: 0x040060B2 RID: 24754
	private CString TaxStr;

	// Token: 0x040060B3 RID: 24755
	private CString TaxStr2;

	// Token: 0x040060B4 RID: 24756
	private CString LoadingStr2;

	// Token: 0x040060B5 RID: 24757
	private CString TimeStr;

	// Token: 0x040060B6 RID: 24758
	private CString BootsStr;

	// Token: 0x040060B7 RID: 24759
	private CString[] ResourcesStr = new CString[5];

	// Token: 0x040060B8 RID: 24760
	private UIText HelpButtonText;

	// Token: 0x040060B9 RID: 24761
	private UIText TaxText;

	// Token: 0x040060BA RID: 24762
	private UIText LoadingText;

	// Token: 0x040060BB RID: 24763
	private UIText LTaxText;

	// Token: 0x040060BC RID: 24764
	private UIText AddSpeedText;

	// Token: 0x040060BD RID: 24765
	private UIText TotalTimeText;

	// Token: 0x040060BE RID: 24766
	private UIButton HelpButton;

	// Token: 0x040060BF RID: 24767
	private DemandResources m_DResources;

	// Token: 0x040060C0 RID: 24768
	private UnitResourcesSlider[] m_Slider = new UnitResourcesSlider[5];

	// Token: 0x040060C1 RID: 24769
	private int OpenIndex = -1;

	// Token: 0x040060C2 RID: 24770
	private RoleBuildingData mBD;

	// Token: 0x040060C3 RID: 24771
	private BuildLevelRequest mBR;

	// Token: 0x040060C4 RID: 24772
	private GUIManager GM;

	// Token: 0x040060C5 RID: 24773
	private DataManager DM;

	// Token: 0x040060C6 RID: 24774
	private StringManager SM;

	// Token: 0x040060C7 RID: 24775
	private StringTable ST;

	// Token: 0x040060C8 RID: 24776
	private long[] lResource = new long[5];

	// Token: 0x040060C9 RID: 24777
	private long[] lTaxResource = new long[5];

	// Token: 0x040060CA RID: 24778
	private long[] lSendResource = new long[5];

	// Token: 0x040060CB RID: 24779
	private double Tax;

	// Token: 0x040060CC RID: 24780
	private long TotalTax;

	// Token: 0x040060CD RID: 24781
	private long TotalLoading;

	// Token: 0x040060CE RID: 24782
	private long LoadingMax;

	// Token: 0x040060CF RID: 24783
	private long TotalSend;

	// Token: 0x040060D0 RID: 24784
	private Door door;

	// Token: 0x040060D1 RID: 24785
	private PointCode DesPoint;

	// Token: 0x040060D2 RID: 24786
	private bool bOpen;

	// Token: 0x040060D3 RID: 24787
	private bool bOpenOkCancelBox;

	// Token: 0x040060D4 RID: 24788
	private UIText[] RBText = new UIText[8];
}
