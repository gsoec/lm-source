using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200084E RID: 2126
public class UISpeedup : UIFilterBase, IUIButtonDownUpHandler
{
	// Token: 0x06002BEE RID: 11246 RVA: 0x004833D0 File Offset: 0x004815D0
	public unsafe override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		this.QueueBar = (EQueueBarIndex)arg2;
		this.TimeStr = StringManager.Instance.SpawnString(200);
		this.HelpStr = StringManager.Instance.SpawnString(30);
		base.OnOpen(arg1, arg2);
		this.ThisTransform = base.SetFunc(this.transform.GetChild(3));
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.ThisTransform.gameObject.SetActive(true);
		this.MainText.font = ttffont;
		this.HelpObj = this.ThisTransform.GetChild(1).gameObject;
		this.HelpText = this.ThisTransform.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.HelpText.font = ttffont;
		base.AddRefreshText(this.HelpText);
		UIButtonHint uibuttonHint = this.ThisTransform.GetChild(1).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 14701;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		bool active = true;
		EQueueBarIndex queueBar = this.QueueBar;
		switch (queueBar)
		{
		case EQueueBarIndex.Training:
			this.Speedup = new TrainingSpeedup(this.QueueBar);
			break;
		case EQueueBarIndex.HeroEnhance:
			this.Speedup = new HeroEnhanceSpeedup(this.QueueBar);
			break;
		case EQueueBarIndex.HeroEvolution:
			this.Speedup = new HeroStarupSpeedup(this.QueueBar);
			break;
		case EQueueBarIndex.Treatmenting:
			this.Speedup = new TreatmentingSpeedup(this.QueueBar);
			break;
		case EQueueBarIndex.Manufacturing:
			this.Speedup = new TrapSpeedup(this.QueueBar);
			break;
		case EQueueBarIndex.TrapRepair:
			this.Speedup = new FixTrapSpeedup(this.QueueBar);
			break;
		case EQueueBarIndex.WallRepair:
			this.Speedup = new FixwallSpeedup(this.QueueBar);
			break;
		default:
			if (queueBar != EQueueBarIndex.Building)
			{
				if (queueBar != EQueueBarIndex.Researching)
				{
					active = false;
					this.Speedup = new MarchGropSpeedup(arg2);
					this.QueueBar = (EQueueBarIndex)this.Speedup.QueueBar;
					if (this.Speedup.QueueBar == 255)
					{
						MarchGropSpeedup marchGropSpeedup = this.Speedup as MarchGropSpeedup;
						if (marchGropSpeedup.mapline != null && marchGropSpeedup.mapline.lineFlag != 12)
						{
							this.bException = true;
						}
					}
				}
				else
				{
					this.Speedup = new ResearchSpeedup(this.QueueBar);
					this.CheckHelpbarShow();
				}
			}
			else
			{
				this.Speedup = new BuildSpeedup(this.QueueBar);
				this.CheckHelpbarShow();
			}
			break;
		case EQueueBarIndex.Forging:
			this.Speedup = new ForgingSpeedup(this.QueueBar);
			break;
		case EQueueBarIndex.AffairMission:
			this.Speedup = new MissionAffairSpeedup(this.QueueBar);
			break;
		case EQueueBarIndex.AllianceMission:
			this.Speedup = new MissionAllianceSpeedup(this.QueueBar);
			break;
		case EQueueBarIndex.VIPMission:
			this.Speedup = new MissionVIPSpeedup(this.QueueBar);
			break;
		case EQueueBarIndex.LordReturn:
			this.Speedup = new HeroLeavePrison(this.QueueBar);
			break;
		case EQueueBarIndex.PetFusion:
			this.Speedup = new PetItemCraftSpeed(this.QueueBar);
			break;
		case EQueueBarIndex.PetEvolution:
			this.Speedup = new PetEvolutionSpeed(this.QueueBar);
			break;
		}
		this.SortObj.SetActive(active);
		this.UseTargetID = (ushort)this.Speedup.UseTarget;
		this.MainText.text = this.Speedup.MainTitleStr;
		string text = string.Empty;
		string empty = string.Empty;
		this.timebar = this.ThisTransform.GetChild(0).GetComponent<UITimeBar>();
		instance.GetQueueBarTitle(this.QueueBar, instance2.tmpString, ref text, ref empty);
		instance2.CreateTimerBar(this.timebar, 0L, 0L, 0L, eTimeBarType.SpeedupType, text, empty);
		if (arg2 < 100)
		{
			if (this.QueueBar >= (EQueueBarIndex)instance.queueBarData.Length)
			{
				this.bForceClose = 1;
				this.ThisTransform.gameObject.SetActive(false);
				return;
			}
			fixed (QueueBarData* ptr = &instance.queueBarData[(int)((byte)this.QueueBar)])
			{
				instance2.SetTimerBar(this.timebar, ptr->StartTime, ptr->StartTime + (long)((ulong)ptr->TotalTime), 0L, eTimeBarType.SpeedupType, text, empty);
				this.LeftTime = ptr->StartTime + (long)((ulong)ptr->TotalTime) - instance.ServerTime;
			}
		}
		else
		{
			text = instance.mStringTable.GetStringByID(4914u);
			if (this.Speedup.Name != null)
			{
				this.CheckNameID = this.Speedup.Name.GetHashCode(false);
			}
			instance2.SetTimerBar(this.timebar, this.Speedup.StartTime, this.Speedup.StartTime + (long)((ulong)this.Speedup.TotalTime), 0L, eTimeBarType.SpeedupType, text, text);
			this.LeftTime = this.Speedup.StartTime + (long)((ulong)this.Speedup.TotalTime) - instance.ServerTime;
		}
		if (this.LeftTime < 0L)
		{
			this.bForceClose = 1;
			this.ThisTransform.gameObject.SetActive(false);
		}
		if (this.Speedup.bFreeSpeedup && this.LeftTime <= (long)instance.GetFreeCompleteTime())
		{
			this.bUseImmediateFree = true;
		}
		else
		{
			this.bUseImmediateFree = false;
		}
		if (!this.bUseImmediateFree)
		{
			if (!this.Speedup.bImmediate)
			{
				this.MoneyIdx = -1;
			}
			else
			{
				this.MoneyIdx = 0;
			}
			if (this.Speedup.bFreeSpeedup)
			{
				this.FreeIdx = 1;
			}
			else
			{
				this.FreeIdx = -1;
			}
		}
		else
		{
			this.MoneyIdx = -1;
			this.FreeIdx = 0;
			instance2.SetTimerSpriteType(this.timebar, eTimerSpriteType.Free);
		}
	}

	// Token: 0x06002BEF RID: 11247 RVA: 0x004839C4 File Offset: 0x00481BC4
	public override void Init()
	{
		base.Init();
		if (!this.bException)
		{
			this.UpdateSpeedupItem(false);
		}
		else
		{
			this.FilterScrollView.gameObject.SetActive(false);
			UIText component = this.MessageTrans.GetChild(0).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(10049u);
			Vector2 sizeDelta = this.MessageTrans.sizeDelta;
			sizeDelta.x = component.preferredWidth + 165f;
			if (sizeDelta.x > 770f)
			{
				sizeDelta.x = 770f;
			}
			this.MessageTrans.sizeDelta = sizeDelta;
			this.MessageTrans.gameObject.SetActive(true);
		}
		this.UpdateTime(true);
	}

	// Token: 0x06002BF0 RID: 11248 RVA: 0x00483A8C File Offset: 0x00481C8C
	private void CheckHelpbarShow()
	{
		if (this.QueueBar != EQueueBarIndex.Building && this.QueueBar != EQueueBarIndex.Researching)
		{
			return;
		}
		if (this.Speedup is MarchGropSpeedup)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		byte b = 0;
		if (this.QueueBar == EQueueBarIndex.Building)
		{
			b = 1;
		}
		if (instance.RoleAlliance.Id > 0u && ((instance.mPlayHelpDataType[(int)b].Kind == 1 && instance.mPlayHelpDataType[(int)b].HelpMax != 0 && instance.mPlayHelpDataType[(int)b].AlreadyHelperNum == instance.mPlayHelpDataType[(int)b].HelpMax) || instance.mPlayHelpDataType[(int)b].Kind == 2))
		{
			this.HelpObj.SetActive(true);
			this.UpdateHelpNum();
		}
		else
		{
			this.HelpObj.SetActive(false);
		}
	}

	// Token: 0x06002BF1 RID: 11249 RVA: 0x00483B78 File Offset: 0x00481D78
	private void UpdateHelpNum()
	{
		if (!this.HelpObj.activeSelf)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		this.HelpStr.ClearString();
		if (this.QueueBar == EQueueBarIndex.Building)
		{
			this.HelpStr.IntToFormat((long)instance.mPlayHelpDataType[1].AlreadyHelperNum, 1, false);
			this.HelpStr.IntToFormat((long)instance.mPlayHelpDataType[1].HelpMax, 1, false);
		}
		else if (this.QueueBar == EQueueBarIndex.Researching)
		{
			this.HelpStr.IntToFormat((long)instance.mPlayHelpDataType[0].AlreadyHelperNum, 1, false);
			this.HelpStr.IntToFormat((long)instance.mPlayHelpDataType[0].HelpMax, 1, false);
		}
		if (GUIManager.Instance.IsArabic)
		{
			this.HelpStr.AppendFormat("{1} / {0}");
		}
		else
		{
			this.HelpStr.AppendFormat("{0} / {1}");
		}
		this.HelpText.text = this.HelpStr.ToString();
		this.HelpText.SetAllDirty();
		this.HelpText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002BF2 RID: 11250 RVA: 0x00483CA8 File Offset: 0x00481EA8
	public void UpdateSpeedupItem(bool bForceUpdate = false)
	{
		if (bForceUpdate && this.BuyAndUse > 0)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		Vector2 vector = Vector2.zero;
		int itemidx = 0;
		instance.SortResourceFilterData();
		if (bForceUpdate)
		{
			vector = this.ScrollContent.anchoredPosition;
			itemidx = this.FilterScrollView.GetBeginIdx();
		}
		this.ItemsHeight.Clear();
		this.ItemsData.Clear();
		this.UpdateState.Clear();
		int num = 0;
		if (this.MoneyIdx >= 0)
		{
			this.UpdateState.Add(0);
			this.ItemsData.Add(0);
			this.ItemsHeight.Add(121f);
			num++;
		}
		if (this.FreeIdx >= 0)
		{
			this.UpdateState.Add(0);
			this.ItemsData.Add(0);
			this.ItemsHeight.Add(121f);
			num++;
		}
		this.MaxSpeedupTimeItem = 0L;
		this.BagCount = -1;
		byte sort = 0;
		if (this.SortObj.activeSelf)
		{
			sort = this.SortType;
		}
		this.SetItemData(instance.sortItemData, instance.sortItemDataStart[12], instance.sortItemDataCount[12], false, sort, num);
		this.BagCount = this.ItemsHeight.Count;
		num = this.BagCount;
		this.MaxSpeedupTimeItem = 0L;
		this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[6], instance.SortSotreDataCount[6], false, sort, num);
		this.Speedup.CustomSort(this.ItemsData, this.BagCount);
		base.UpdateScrollItemsCount();
		if (bForceUpdate)
		{
			this.FilterScrollView.GoTo(itemidx, vector.y);
		}
	}

	// Token: 0x06002BF3 RID: 11251 RVA: 0x00483E50 File Offset: 0x00482050
	public override bool CheckItemRule(ushort id)
	{
		Equip recordByKey;
		if (this.BagCount == -1)
		{
			if (DataManager.Instance.GetCurItemQuantity(id, 0) == 0)
			{
				return false;
			}
			recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(id);
			if (recordByKey.PropertiesInfo[0].Propertieskey != (ushort)this.Speedup.FilterType && recordByKey.PropertiesInfo[0].Propertieskey != (ushort)this.Speedup.FilterType2)
			{
				return false;
			}
		}
		else
		{
			StoreTbl recordByKey2 = DataManager.Instance.StoreData.GetRecordByKey(id);
			recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
			if (recordByKey.PropertiesInfo[0].Propertieskey != (ushort)this.Speedup.FilterType && recordByKey.PropertiesInfo[0].Propertieskey != (ushort)this.Speedup.FilterType2)
			{
				return false;
			}
			if (recordByKey2.AddDiamondBuy != 0 && recordByKey2.Filter != 2 && this.Speedup.SkipFilterTime == 0)
			{
				long num = (long)(recordByKey.PropertiesInfo[1].Propertieskey * 60);
				if (this.LeftTime < num && this.MaxSpeedupTimeItem == 0L)
				{
					this.MaxSpeedupTimeItem = num;
				}
			}
			if (recordByKey2.AddDiamondBuy == 0 || recordByKey2.Filter == 2 || DataManager.Instance.GetCurItemQuantity(recordByKey2.ItemID, 0) > 0)
			{
				return false;
			}
		}
		if (this.Speedup.SkipFilterTime == 0)
		{
			long num2 = (long)(recordByKey.PropertiesInfo[1].Propertieskey * 60);
			if (this.LeftTime < num2)
			{
				if (this.MaxSpeedupTimeItem == 0L)
				{
					this.MaxSpeedupTimeItem = num2;
				}
				else if (this.MaxSpeedupTimeItem < num2)
				{
					return false;
				}
			}
		}
		this.UpdateState.Add(0);
		return true;
	}

	// Token: 0x06002BF4 RID: 11252 RVA: 0x0048403C File Offset: 0x0048223C
	public override void UpdateUI(int arge1, int arge2)
	{
		if (arge1 == 65537)
		{
			base.UpdateUI(arge1, arge2);
			return;
		}
		if (arge1 == 65538)
		{
			this.Speedup.SendImmediate();
			return;
		}
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		BuildsData buildingData = GUIManager.Instance.BuildingData;
		if (arge2 != 100)
		{
			if (this.QueueBar == (EQueueBarIndex)arge2)
			{
				if (buildingData.QueueBuildType == 2 && buildingData.AllBuildsData[(int)buildingData.OpenUiManorID].Level == 0)
				{
					door.CloseMenu(true);
				}
				else
				{
					door.CloseMenu(false);
				}
			}
		}
		else if (this.Speedup.Rally == 1)
		{
			DataManager instance = DataManager.Instance;
			byte queueBar = this.Speedup.QueueBar;
			if (arge1 == -1 || instance.WarTroop.Count <= (int)queueBar)
			{
				door.CloseMenu(false);
			}
			else if (instance.WarTroop.Count > (int)queueBar)
			{
				if (instance.WarTroop[(int)queueBar].MarchTime.BeginTime + (long)((ulong)instance.WarTroop[(int)queueBar].MarchTime.RequireTime) < instance.ServerTime || this.CheckNameID != instance.WarTroop[(int)queueBar].AllyNameID)
				{
					door.CloseMenu(false);
				}
				else
				{
					GUIManager.Instance.SetTimerBar(this.timebar, instance.WarTroop[(int)queueBar].MarchTime.BeginTime, instance.WarTroop[(int)queueBar].MarchTime.BeginTime + (long)((ulong)instance.WarTroop[(int)queueBar].MarchTime.RequireTime), 0L, eTimeBarType.SpeedupType, instance.mStringTable.GetStringByID(4914u), instance.mStringTable.GetStringByID(4914u));
				}
			}
		}
		else if (this.Speedup.Rally == 2)
		{
			if (arge1 == -1)
			{
				door.CloseMenu(false);
			}
			else
			{
				DataManager instance2 = DataManager.Instance;
				bool flag = false;
				if (this.Speedup.Name == null || this.CheckNameID != this.Speedup.Name.GetHashCode(false))
				{
					if (instance2.WarHall[0] == null)
					{
						return;
					}
					byte b = 0;
					while ((int)b < instance2.WarHall[0].Count)
					{
						if (instance2.WarHall[0][(int)b].AllyNameID == this.CheckNameID)
						{
							this.Speedup.QueueBar = (byte)(instance2.queueBarData.Length + (int)b);
							flag = true;
							break;
						}
						b += 1;
					}
				}
				else if (this.Speedup.Name != null && this.CheckNameID == this.Speedup.Name.GetHashCode(false))
				{
					flag = true;
				}
				if (!flag || this.Speedup.StartTime + (long)((ulong)this.Speedup.TotalTime) < instance2.ServerTime)
				{
					door.CloseMenu(false);
				}
			}
		}
		this.UpdateHelpNum();
	}

	// Token: 0x06002BF5 RID: 11253 RVA: 0x00484354 File Offset: 0x00482554
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_Item:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (this.Speedup.UseTarget == _UseItemTarget.Rally)
			{
				this.UpdateSpeedupItem(true);
			}
			else if (this.Speedup.QueueBar == 30)
			{
				door.GoToGroup(8, 0, true);
				door.CloseMenu(false);
			}
			else if (this.Speedup.QueueBar >= 2 && this.Speedup.QueueBar <= 9)
			{
				door.GoToGroup((int)(this.Speedup.QueueBar - 2), 0, true);
				door.CloseMenu(false);
			}
			else if (this.Speedup.Rally == 2 && this.Speedup.QueueBar >= 22 && this.Speedup.QueueBar <= 29)
			{
				door.GoToGroup((int)(this.Speedup.QueueBar - 22), 0, true);
				door.CloseMenu(false);
			}
			else
			{
				this.UpdateSpeedupItem(true);
			}
			break;
		}
		default:
			if (networkNews != NetworkNews.Login)
			{
				if (networkNews != NetworkNews.Refresh_QBarTime)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						if (this.timebar != null)
						{
							this.timebar.Refresh_FontTexture();
						}
					}
				}
				else if (this.Speedup.Rally > 0)
				{
					if (this.Speedup.StartTime + (long)((ulong)this.Speedup.TotalTime) < DataManager.Instance.ServerTime)
					{
						Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
						door2.CloseMenu(false);
						return;
					}
					GUIManager.Instance.SetTimerBar(this.timebar, this.Speedup.StartTime, this.Speedup.StartTime + (long)((ulong)this.Speedup.TotalTime), 0L, eTimeBarType.SpeedupType, this.timebar.m_Titles[0], this.timebar.m_Titles[1]);
					this.UpdateTime(true);
					this.UpdateSpeedupItem(true);
					return;
				}
				else
				{
					if (this.QueueBar >= (EQueueBarIndex)DataManager.Instance.queueBarData.Length)
					{
						return;
					}
					this.UpdateQueuebarTime();
				}
			}
			else
			{
				this.BuyAndUse = 0;
				if (this.Speedup.UseTarget == _UseItemTarget.Rally)
				{
					Door door3 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					door3.CloseMenu(true);
				}
				else if (this.Speedup.UseTarget == _UseItemTarget.SunLordequip)
				{
					LordEquipData.Instance().LoadLordEquip(false);
				}
				else
				{
					DataManager.Instance.SortResourceFilterData();
					this.UpdateSpeedupItem(true);
				}
				this.UpdateQueuebarTime();
				this.CheckHelpbarShow();
			}
			break;
		case NetworkNews.Refresh_Alliance:
			this.CheckHelpbarShow();
			break;
		}
	}

	// Token: 0x06002BF6 RID: 11254 RVA: 0x00484618 File Offset: 0x00482818
	public unsafe void UpdateQueuebarTime()
	{
		if (this.QueueBar >= (EQueueBarIndex)DataManager.Instance.queueBarData.Length)
		{
			return;
		}
		fixed (QueueBarData* ptr = &DataManager.Instance.queueBarData[(int)((byte)this.QueueBar)])
		{
			GUIManager.Instance.SetTimerBar(this.timebar, ptr->StartTime, ptr->StartTime + (long)((ulong)ptr->TotalTime), 0L, eTimeBarType.SpeedupType, this.timebar.m_Titles[0], this.timebar.m_Titles[1]);
			if (this.Speedup.SkipFilterTime == 0)
			{
				this.UpdateTime(true);
				if (this.BuyAndUse == 1)
				{
					this.BuyAndUse = 0;
					this.UpdateSpeedupItem(true);
					this.BuyAndUse = 1;
				}
				else
				{
					this.UpdateSpeedupItem(true);
				}
			}
		}
	}

	// Token: 0x06002BF7 RID: 11255 RVA: 0x004846DC File Offset: 0x004828DC
	public override void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		base.UpDateRowItem(item, dataIdx, panelObjectIdx, panelId);
		if (this.ItemsData.Count == 0 || this.bException)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		this.FilterItem[panelObjectIdx].BuyImage.sprite = this.FilterSpriteArr.GetSprite(3);
		if ((int)this.FreeIdx == dataIdx)
		{
			this.SetFreeImmediate(panelObjectIdx);
		}
		else if ((int)this.MoneyIdx == dataIdx)
		{
			this.SetMoneyImmediate(panelObjectIdx);
		}
		else
		{
			this.UpdateState[panelObjectIdx] = 0;
			base.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Use);
			Color color = this.FilterItem[panelObjectIdx].Name.color;
			color.r = 1f;
			color.g = 0.933f;
			color.b = 0.62f;
			this.FilterItem[panelObjectIdx].Name.color = color;
			this.FilterItem[panelObjectIdx].BuyCaption.enabled = true;
			this.FilterItem[panelObjectIdx].BuyBtn.enabled = true;
			this.FilterItem[panelObjectIdx].KeyID = this.ItemsData[dataIdx];
			Equip recordByKey;
			if (this.BagCount > dataIdx)
			{
				base.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Use);
				recordByKey = instance.EquipTable.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
				this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = (int)this.FilterItem[panelObjectIdx].KeyID;
				ushort curItemQuantity = instance.GetCurItemQuantity(recordByKey.EquipKey, 0);
				if (recordByKey.EquipKind - 1 == 11)
				{
					if (curItemQuantity <= 1 || ((byte)recordByKey.PropertiesInfo[0].Propertieskey != 1 && (byte)recordByKey.PropertiesInfo[0].Propertieskey != 12 && (byte)recordByKey.PropertiesInfo[0].Propertieskey != 17 && (byte)recordByKey.PropertiesInfo[0].Propertieskey != 18 && (byte)recordByKey.PropertiesInfo[0].Propertieskey != 21 && (byte)recordByKey.PropertiesInfo[0].Propertieskey != 22 && this.FilterItem[panelObjectIdx].AutouseBtnTrans.gameObject.activeSelf))
					{
						this.FilterItem[panelObjectIdx].AutouseBtnTrans.gameObject.SetActive(false);
					}
				}
				else if ((curItemQuantity <= 1 || recordByKey.Hide > 0) && this.FilterItem[panelObjectIdx].AutouseBtnTrans.gameObject.activeSelf)
				{
					this.FilterItem[panelObjectIdx].AutouseBtnTrans.gameObject.SetActive(false);
				}
			}
			else
			{
				base.SetItemType(panelObjectIdx, UIFilterBase.eItemType.BuyAndUse);
				StoreTbl recordByKey2 = instance.StoreData.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
				recordByKey = instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
				this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID3 = (int)recordByKey2.ID;
				this.FilterItem[panelObjectIdx].BuyPriceStr.ClearString();
				this.FilterItem[panelObjectIdx].BuyPriceStr.IntToFormat((long)((ulong)recordByKey2.Price), 1, true);
				this.FilterItem[panelObjectIdx].BuyPriceStr.AppendFormat("{0}");
				this.FilterItem[panelObjectIdx].BuyPrice.text = this.FilterItem[panelObjectIdx].BuyPriceStr.ToString();
				this.FilterItem[panelObjectIdx].BuyPrice.SetAllDirty();
				this.FilterItem[panelObjectIdx].BuyPrice.cachedTextGenerator.Invalidate();
				this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = (int)recordByKey2.ItemID;
				this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID3 = (int)this.FilterItem[panelObjectIdx].KeyID;
			}
			GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[panelObjectIdx].ItemTrans, eHeroOrItem.Item, recordByKey.EquipKey, 0, 0, 0);
			this.FilterItem[panelObjectIdx].Name.text = instance.mStringTable.GetStringByID((uint)recordByKey.EquipName);
			this.FilterItem[panelObjectIdx].Content.text = instance.mStringTable.GetStringByID((uint)recordByKey.EquipInfo);
			this.FilterItem[panelObjectIdx].OwnerStr.ClearString();
			this.FilterItem[panelObjectIdx].OwnerStr.StringToFormat(this.OwnerStr);
			this.FilterItem[panelObjectIdx].OwnerStr.IntToFormat((long)instance.GetCurItemQuantity(recordByKey.EquipKey, 0), 1, true);
			this.FilterItem[panelObjectIdx].OwnerStr.AppendFormat("{0}{1}");
			this.FilterItem[panelObjectIdx].Owner.text = this.FilterItem[panelObjectIdx].OwnerStr.ToString();
			this.FilterItem[panelObjectIdx].Owner.SetAllDirty();
			this.FilterItem[panelObjectIdx].Owner.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06002BF8 RID: 11256 RVA: 0x00484C5C File Offset: 0x00482E5C
	private void SetFreeImmediate(int index)
	{
		if (index < 0)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		this.FreePanelIndex = index;
		base.SetItemType(index, UIFilterBase.eItemType.Use);
		if (this.bUseImmediateFree)
		{
			this.FilterItem[index].Content.text = instance.mStringTable.GetStringByID(230u);
			this.FilterItem[index].BuyCaption.text = instance.mStringTable.GetStringByID(229u);
			this.UpdateState[index] = 0;
		}
		else
		{
			this.FilterItem[index].Content.text = string.Empty;
			this.UpdateState[index] = 1;
		}
		Color color = this.FilterItem[index].Name.color;
		color.r = 0.886f;
		color.g = 0.608f;
		color.b = 1f;
		this.FilterItem[index].Name.color = color;
		this.FilterItem[index].BuyImage.sprite = this.FilterSpriteArr.GetSprite(2);
		this.FilterItem[index].Lock.gameObject.SetActive(!this.bUseImmediateFree);
		this.FilterItem[index].BuyCaption.enabled = this.bUseImmediateFree;
		this.FilterItem[index].BuyBtn.enabled = this.bUseImmediateFree;
		this.FilterItem[index].BuyBtn.m_BtnID1 = 301;
		GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[index].ItemTrans, eHeroOrItem.Item, 1109, 0, 0, 0);
		this.FilterItem[index].Name.text = instance.mStringTable.GetStringByID(227u);
		this.FilterItem[index].AutouseBtnTrans.gameObject.SetActive(false);
		this.FilterItem[index].Owner.text = string.Empty;
		this.UpdateTime(true);
	}

	// Token: 0x06002BF9 RID: 11257 RVA: 0x00484E8C File Offset: 0x0048308C
	private void SetMoneyImmediate(int index)
	{
		if (index < 0)
		{
			return;
		}
		this.UpdateState[index] = 2;
		GUIManager instance = GUIManager.Instance;
		this.MoneyPanelIndex = index;
		this.FilterItem[index].Content.text = this.Speedup.CompleteImmContStr;
		base.SetItemType(index, UIFilterBase.eItemType.BuyAndUse);
		this.FilterItem[index].BuyCaption.text = this.Speedup.CompleteImmBntStr;
		this.FilterItem[index].BuyCaption.enabled = true;
		if (this.QueueBar == EQueueBarIndex.Building)
		{
			if (instance.BuildingData.QueueBuildType == 1)
			{
				GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[index].ItemTrans, eHeroOrItem.Item, 1108, 0, 0, 0);
			}
			else
			{
				GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[index].ItemTrans, eHeroOrItem.Item, 1075, 0, 0, 0);
			}
		}
		else
		{
			GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[index].ItemTrans, eHeroOrItem.Item, 1108, 0, 0, 0);
		}
		this.FilterItem[index].Name.text = this.Speedup.CompleteImmBntStr;
		this.FilterItem[index].BuyBtn.enabled = true;
		this.FilterItem[index].BuyBtn.m_BtnID1 = 302;
		this.FilterItem[index].Owner.text = string.Empty;
		this.UpdateTime(true);
	}

	// Token: 0x06002BFA RID: 11258 RVA: 0x00485024 File Offset: 0x00483224
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.bForceClose == 1)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu(false);
			this.bForceClose = 0;
			return;
		}
		if (!bOnSecond || this.PassInit > 0)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		if (this.Speedup.bImmediate || this.Speedup.bFreeSpeedup)
		{
			this.LeftTime = instance.queueBarData[(int)this.Speedup.QueueBar].StartTime + (long)((ulong)instance.queueBarData[(int)this.Speedup.QueueBar].TotalTime) - instance.ServerTime;
		}
		if (this.Speedup.bFreeSpeedup && this.bUseImmediateFree != this.LeftTime <= (long)instance.GetFreeCompleteTime())
		{
			this.bUseImmediateFree = !this.bUseImmediateFree;
			if (!this.bUseImmediateFree)
			{
				if (this.Speedup.bImmediate)
				{
					this.MoneyIdx = 0;
				}
				else
				{
					this.MoneyIdx = -1;
				}
				this.FreeIdx = 1;
			}
			else
			{
				this.FreeIdx = 0;
				this.MoneyIdx = -1;
				GUIManager.Instance.SetTimerSpriteType(this.timebar, eTimerSpriteType.Free);
			}
			this.UpdateSpeedupItem(false);
		}
		for (int i = 0; i < this.UpdateState.Count; i++)
		{
			byte b = this.UpdateState[i];
			if (b != 1)
			{
				if (b == 2)
				{
					if (this.LeftTime > 0L)
					{
						if (this.QueueBar == EQueueBarIndex.PetFusion)
						{
							this.Cost = instance.GetResourceExchange(PriceListType.PetFusion, (uint)this.LeftTime);
						}
						else
						{
							this.Cost = instance.GetResourceExchange(PriceListType.Time, (uint)this.LeftTime);
						}
					}
					else
					{
						this.Cost = 0u;
					}
					this.FilterItem[this.MoneyPanelIndex].BuyPriceStr.ClearString();
					this.FilterItem[this.MoneyPanelIndex].BuyPriceStr.IntToFormat((long)((ulong)this.Cost), 1, true);
					this.FilterItem[this.MoneyPanelIndex].BuyPriceStr.AppendFormat("{0}");
					this.FilterItem[this.MoneyPanelIndex].BuyPrice.text = this.FilterItem[this.MoneyPanelIndex].BuyPriceStr.ToString();
					this.FilterItem[this.MoneyPanelIndex].BuyPrice.SetAllDirty();
					this.FilterItem[this.MoneyPanelIndex].BuyPrice.cachedTextGenerator.Invalidate();
					this.FilterItem[this.MoneyPanelIndex].Content.text = this.Speedup.CompleteImmContStr;
					this.FilterItem[this.MoneyPanelIndex].Content.SetAllDirty();
					this.FilterItem[this.MoneyPanelIndex].Content.cachedTextGenerator.Invalidate();
				}
			}
			else
			{
				long num = this.LeftTime - (long)instance.GetFreeCompleteTime();
				TimeSpan timeSpan = new TimeSpan(num * 10000000L);
				this.TimeStr.ClearString();
				this.TimeStr.Append(instance.mStringTable.GetStringByID(228u));
				if (timeSpan.Days > 0)
				{
					this.TimeStr.IntToFormat((long)timeSpan.Days, 1, false);
					this.TimeStr.AppendFormat("{0}d ");
				}
				this.TimeStr.IntToFormat((long)timeSpan.Hours, 2, false);
				this.TimeStr.IntToFormat((long)timeSpan.Minutes, 2, false);
				this.TimeStr.IntToFormat((long)timeSpan.Seconds, 2, false);
				this.TimeStr.AppendFormat("{0}:{1}:{2}</color>");
				this.FilterItem[this.FreePanelIndex].Content.text = this.TimeStr.ToString();
				this.FilterItem[this.FreePanelIndex].Content.SetAllDirty();
				this.FilterItem[this.FreePanelIndex].Content.cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x06002BFB RID: 11259 RVA: 0x0048547C File Offset: 0x0048367C
	public override void OnButtonClick(UIButton sender)
	{
		GUIManager instance = GUIManager.Instance;
		DataManager instance2 = DataManager.Instance;
		instance.BagTagSaved[9] = this.Speedup.QueueBar;
		this.BuyAndUse = 0;
		UIFilterBase.FilterBaseClickType btnID = (UIFilterBase.FilterBaseClickType)sender.m_BtnID1;
		if (btnID != UIFilterBase.FilterBaseClickType.Exit)
		{
			if (sender.m_BtnID1 == 301)
			{
				this.Speedup.SendImmediateFree();
			}
			else if (sender.m_BtnID1 == 302)
			{
				if (this.Cost <= instance2.RoleAttr.Diamond)
				{
					if (this.Cost > 0u && !GUIManager.Instance.OpenCheckCrystal(this.Cost, 1, 65538, -1))
					{
						this.Speedup.SendImmediate();
					}
				}
				else
				{
					string stringByID = instance2.mStringTable.GetStringByID(3968u);
					instance.OpenMessageBox(instance2.mStringTable.GetStringByID(3966u), instance2.mStringTable.GetStringByID(646u), stringByID, instance.FindMenu(EGUIWindow.UI_BagFilter), 0, 0, true, false, false, false, false);
				}
			}
		}
		base.OnButtonClick(sender);
		if (sender.m_BtnID1 == 1003)
		{
			instance.UpdateUI(EGUIWindow.UI_BagFilter, 3, (!this.Speedup.bFreeSpeedup) ? 1073741824 : 1073741825);
		}
	}

	// Token: 0x06002BFC RID: 11260 RVA: 0x004855D8 File Offset: 0x004837D8
	public override void SendPack(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 1002:
			this.BuyAndUse = 0;
			if (this.Speedup.Rally == 2)
			{
				DataManager.Instance.SpeedupRally((ushort)sender.m_BtnID2, this.UseTargetID, this.Speedup.Name);
			}
			else if (this.Speedup.Rally == 1)
			{
				DataManager.Instance.UseItem((ushort)sender.m_BtnID2, 1, this.UseTargetID, (ushort)this.Speedup.QueueBar, 0, 0u, string.Empty, true);
			}
			else
			{
				DataManager.Instance.UseItem((ushort)sender.m_BtnID2, 1, this.UseTargetID, 0, 0, 0u, string.Empty, true);
			}
			break;
		case 1004:
			this.BuyAndUse = 1;
			if (this.Speedup.Rally == 1)
			{
				this.CheckBuy(1, (ushort)sender.m_BtnID3, (ushort)sender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), (int)this.UseTargetID, (int)this.Speedup.QueueBar << 16, 0u);
			}
			else
			{
				this.CheckBuy(1, (ushort)sender.m_BtnID3, (ushort)sender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), (int)this.UseTargetID, 0, 0u);
			}
			break;
		case 1006:
			this.UpdateSpeedupItem(true);
			return;
		}
	}

	// Token: 0x06002BFD RID: 11261 RVA: 0x00485744 File Offset: 0x00483944
	public override void OnClose()
	{
		base.OnClose();
		GUIManager.Instance.RemoverTimeBaarToList(this.timebar);
		StringManager.Instance.DeSpawnString(this.TimeStr);
		StringManager.Instance.DeSpawnString(this.HelpStr);
	}

	// Token: 0x06002BFE RID: 11262 RVA: 0x0048578C File Offset: 0x0048398C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			MallManager.Instance.Send_Mall_Info();
		}
	}

	// Token: 0x06002BFF RID: 11263 RVA: 0x004857A0 File Offset: 0x004839A0
	public void OnButtonDown(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 277f, 20, (int)sender.Parm1, 0, Vector2.zero, UIButtonHint.ePosition.Original);
	}

	// Token: 0x06002C00 RID: 11264 RVA: 0x004857D4 File Offset: 0x004839D4
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x0400786F RID: 30831
	private SpeedupBase Speedup;

	// Token: 0x04007870 RID: 30832
	private GameObject HelpObj;

	// Token: 0x04007871 RID: 30833
	private UIText HelpText;

	// Token: 0x04007872 RID: 30834
	private CString TimeStr;

	// Token: 0x04007873 RID: 30835
	private CString HelpStr;

	// Token: 0x04007874 RID: 30836
	private bool bUseImmediateFree;

	// Token: 0x04007875 RID: 30837
	private bool bException;

	// Token: 0x04007876 RID: 30838
	private EQueueBarIndex QueueBar;

	// Token: 0x04007877 RID: 30839
	private short FreeIdx;

	// Token: 0x04007878 RID: 30840
	private short MoneyIdx;

	// Token: 0x04007879 RID: 30841
	private UITimeBar timebar;

	// Token: 0x0400787A RID: 30842
	private long LeftTime;

	// Token: 0x0400787B RID: 30843
	private long MaxSpeedupTimeItem;

	// Token: 0x0400787C RID: 30844
	private uint Cost;

	// Token: 0x0400787D RID: 30845
	private int MoneyPanelIndex;

	// Token: 0x0400787E RID: 30846
	private int FreePanelIndex;

	// Token: 0x0400787F RID: 30847
	private int BagCount;

	// Token: 0x04007880 RID: 30848
	private int CheckNameID;

	// Token: 0x04007881 RID: 30849
	private byte BuyAndUse;

	// Token: 0x04007882 RID: 30850
	private List<byte> UpdateState = new List<byte>();

	// Token: 0x04007883 RID: 30851
	private byte bForceClose;

	// Token: 0x0200084F RID: 2127
	private enum CompleteImmieateType
	{
		// Token: 0x04007885 RID: 30853
		Free = 301,
		// Token: 0x04007886 RID: 30854
		Money
	}
}
