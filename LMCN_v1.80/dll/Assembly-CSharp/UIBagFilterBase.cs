using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000815 RID: 2069
public class UIBagFilterBase : IUpDateScrollPanel, IUIButtonClickHandler, IUIHIBtnClickHandler
{
	// Token: 0x06002B15 RID: 11029 RVA: 0x004713B8 File Offset: 0x0046F5B8
	public virtual void OnOpen(int arg1, int arg2)
	{
		this.MessageStr = StringManager.Instance.SpawnString(300);
	}

	// Token: 0x06002B16 RID: 11030 RVA: 0x004713D0 File Offset: 0x0046F5D0
	public virtual void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.MessageStr);
		DataManager.Instance.UpdateLoadItemNotify();
	}

	// Token: 0x06002B17 RID: 11031 RVA: 0x004713F0 File Offset: 0x0046F5F0
	public virtual void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x06002B18 RID: 11032 RVA: 0x004713F4 File Offset: 0x0046F5F4
	public virtual void Update()
	{
	}

	// Token: 0x06002B19 RID: 11033 RVA: 0x004713F8 File Offset: 0x0046F5F8
	public virtual void UpdateNetwork(byte[] meg)
	{
		if (meg[0] == 35)
		{
			for (int i = 0; i < this.RefreshTextList.Count; i++)
			{
				if (this.RefreshTextList[i] != null && this.RefreshTextList[i].enabled)
				{
					this.RefreshTextList[i].enabled = false;
					this.RefreshTextList[i].enabled = true;
				}
			}
		}
	}

	// Token: 0x06002B1A RID: 11034 RVA: 0x0047147C File Offset: 0x0046F67C
	public virtual void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
	}

	// Token: 0x06002B1B RID: 11035 RVA: 0x00471480 File Offset: 0x0046F680
	public virtual void OnButtonClick(UIButton sender)
	{
	}

	// Token: 0x06002B1C RID: 11036 RVA: 0x00471484 File Offset: 0x0046F684
	public virtual void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06002B1D RID: 11037 RVA: 0x00471488 File Offset: 0x0046F688
	public virtual void UpdateTime(bool bOnSecond)
	{
	}

	// Token: 0x06002B1E RID: 11038 RVA: 0x0047148C File Offset: 0x0046F68C
	public virtual void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
	}

	// Token: 0x06002B1F RID: 11039 RVA: 0x00471490 File Offset: 0x0046F690
	public virtual void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06002B20 RID: 11040 RVA: 0x00471494 File Offset: 0x0046F694
	public void CheckMessage(ushort ItemID)
	{
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		uint num = 0u;
		uint num2 = 0u;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		Equip recordByKey = instance.EquipTable.GetRecordByKey(ItemID);
		ushort equipKind = (ushort)recordByKey.EquipKind;
		ushort propertieskey = recordByKey.PropertiesInfo[0].Propertieskey;
		for (int i = 0; i < instance.MaxBuffTableCount; i++)
		{
			ItemBuff recordByKey2 = instance.ItemBuffTable.GetRecordByKey(instance.m_RecvItemBuffData[i].ID);
			recordByKey = instance.EquipTable.GetRecordByKey(recordByKey2.BuffItemID);
			if ((byte)(equipKind - 1) == 13 && propertieskey == 1)
			{
				if (DataManager.Instance.bHaveWarBuff)
				{
					GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(9943u), 255, true);
					return;
				}
				for (int j = 0; j < (int)instance.MaxMarchEventNum; j++)
				{
					EMarchEventType type = instance.MarchEventData[j].Type;
					if ((instance.MarchEventData[j].IsAmbushCamp() || instance.MarchEventData[j].IsAmbushCampMarching() || instance.MarchEventData[j].IsAmbushCampReturn() || type == EMarchEventType.EMET_AttackMarching || type == EMarchEventType.EMET_ScoutMarching || type == EMarchEventType.EMET_InforceStanby || type == EMarchEventType.EMET_RallyStanby || (type >= EMarchEventType.EMET_InforceMarching && type <= EMarchEventType.EMET_RallyAttack) || (type == EMarchEventType.EMET_AttackReturn || type == EMarchEventType.EMET_RallyReturn || type == EMarchEventType.EMET_ScoutReturn || type == EMarchEventType.EMET_InfroceReturn || type == EMarchEventType.EMET_AttackRetreat || type == EMarchEventType.EMET_RallyRetreat) || ((type == EMarchEventType.EMET_Camp || type == EMarchEventType.EMET_CampMarching || type == EMarchEventType.EMET_CampReturn) && DataManager.MapDataController.getYolkIDbyPointCode(instance.MarchEventData[j].Point.zoneID, instance.MarchEventData[j].Point.pointID, 0) < 40)) && instance.MarchEventData[j].bRallyHost != 3 && instance.MarchEventData[j].bRallyHost != 4)
					{
						GUIManager.Instance.OpenMessageBox(instance.mStringTable.GetStringByID(614u), instance.mStringTable.GetStringByID(7647u), null, null, 0, 0, false, false, false, false, false);
						return;
					}
				}
				if (instance.TotalSoldier_Embassy > 0u || instance.PrisonerNum > 0 || AmbushManager.Instance.GetMaxTroop() > 0u)
				{
					instance2.OpenOKCancelBox(instance2.FindMenu(EGUIWindow.UI_BagFilter), instance.mStringTable.GetStringByID(614u), instance.mStringTable.GetStringByID(8240u), (int)ItemID, 0, instance.mStringTable.GetStringByID(3u), instance.mStringTable.GetStringByID(617u));
					return;
				}
			}
			if (instance.m_RecvItemBuffData[i].bEnable && recordByKey2.BuffKind == 3)
			{
				num = (uint)recordByKey2.BuffID;
			}
			if (!flag2 && (ushort)recordByKey.EquipKind == equipKind && recordByKey.PropertiesInfo[0].Propertieskey == propertieskey)
			{
				flag = (recordByKey2.BuffKind == 3);
				switch ((byte)(equipKind - 1))
				{
				case 9:
				{
					ECaseByCaseType ecaseByCaseType = (ECaseByCaseType)propertieskey;
					if (ecaseByCaseType == ECaseByCaseType.ECBCT_ExpPercent || ecaseByCaseType == ECaseByCaseType.ECBCT_Monster)
					{
						num2 = (uint)recordByKey2.BuffNameID;
					}
					break;
				}
				case 11:
				{
					ESpeedUpPercent espeedUpPercent = (ESpeedUpPercent)propertieskey;
					if (espeedUpPercent == ESpeedUpPercent.EUP_MARCH_SPEED || espeedUpPercent == ESpeedUpPercent.EUP_BUILD_SPEED || espeedUpPercent == ESpeedUpPercent.EUP_RESEARCH_SPEED || espeedUpPercent == ESpeedUpPercent.EUP_TRAINING_SPEED || espeedUpPercent == ESpeedUpPercent.EUP_RESOURCE_SPEED || espeedUpPercent == ESpeedUpPercent.EUP_TRAP_SPEED || espeedUpPercent == ESpeedUpPercent.EUP_PET_FUSION_SPEED)
					{
						num2 = (uint)recordByKey2.BuffNameID;
					}
					break;
				}
				case 13:
				{
					EShieldType eshieldType = (EShieldType)propertieskey;
					if ((eshieldType == EShieldType.EST_Shield && ShieldLogManager.Instance.HasShieldState()) || eshieldType == EShieldType.EST_Investigate)
					{
						num2 = (uint)recordByKey2.BuffNameID;
					}
					break;
				}
				case 14:
				{
					EDefenseType edefenseType = (EDefenseType)propertieskey;
					if (edefenseType == EDefenseType.EDT_Crafty || edefenseType == EDefenseType.EDT_Salaries || edefenseType == EDefenseType.EDT_TroopScale || edefenseType == EDefenseType.EDT_TroopAtk || edefenseType == EDefenseType.EDT_TorrpDef || edefenseType == EDefenseType.EDT_TroopAtk_Reduce || edefenseType == EDefenseType.EDT_TroopDef_Reduce)
					{
						num2 = (uint)recordByKey2.BuffNameID;
					}
					break;
				}
				case 15:
					num2 = (uint)recordByKey2.BuffNameID;
					break;
				}
				flag3 = instance.m_RecvItemBuffData[i].bEnable;
				flag2 = true;
			}
		}
		if (num2 > 0u)
		{
			this.MessageStr.ClearString();
			if (flag && num > 0u)
			{
				ItemBuff recordByKey2 = instance.ItemBuffTable.GetRecordByKey((ushort)num);
				recordByKey = instance.EquipTable.GetRecordByKey(recordByKey2.BuffItemID);
				num = (uint)recordByKey2.BuffNameID;
				this.MessageStr.StringToFormat(instance.mStringTable.GetStringByID(num2));
				this.MessageStr.StringToFormat(instance.mStringTable.GetStringByID(num));
				this.MessageStr.AppendFormat(instance.mStringTable.GetStringByID(7247u));
			}
			else
			{
				if (!flag3)
				{
					this.OnOKCancelBoxClick(true, (int)ItemID, 0);
					return;
				}
				this.MessageStr.StringToFormat(instance.mStringTable.GetStringByID(num2));
				this.MessageStr.StringToFormat(instance.mStringTable.GetStringByID(num2));
				this.MessageStr.AppendFormat(instance.mStringTable.GetStringByID(7247u));
			}
			instance2.OpenOKCancelBox(instance2.FindMenu(EGUIWindow.UI_BagFilter), instance.mStringTable.GetStringByID(614u), this.MessageStr.ToString(), (int)ItemID, 0, instance.mStringTable.GetStringByID(3u), instance.mStringTable.GetStringByID(617u));
		}
		else
		{
			this.OnOKCancelBoxClick(true, (int)ItemID, 0);
		}
	}

	// Token: 0x06002B21 RID: 11041 RVA: 0x00471A94 File Offset: 0x0046FC94
	public bool CheckItemEnergy(ushort ItemID, byte BuyAndUse)
	{
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		Equip recordByKey = instance.EquipTable.GetRecordByKey(ItemID);
		if (recordByKey.EquipKind - 1 == 9 && (byte)recordByKey.PropertiesInfo[0].Propertieskey == 30)
		{
			if (DataManager.Instance.RoleAttr.MonsterPoint == DataManager.Instance.GetMaxMonsterPoint())
			{
				return false;
			}
			if ((ulong)instance.RoleAttr.MonsterPoint + (ulong)((long)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue)) >= (ulong)instance.GetMaxMonsterPoint())
			{
				instance2.OpenOKCancelBox(instance2.FindMenu(EGUIWindow.UI_BagFilter), instance.mStringTable.GetStringByID(685u), instance.mStringTable.GetStringByID(8479u), (int)recordByKey.EquipKey, (int)BuyAndUse, instance.mStringTable.GetStringByID(3u), instance.mStringTable.GetStringByID(188u));
				return true;
			}
		}
		return false;
	}

	// Token: 0x06002B22 RID: 11042 RVA: 0x00471B9C File Offset: 0x0046FD9C
	protected void AddRefreshText(Text text)
	{
		this.RefreshTextList.Add(text);
	}

	// Token: 0x040076B3 RID: 30387
	public Transform transform;

	// Token: 0x040076B4 RID: 30388
	public Transform ThisTransform;

	// Token: 0x040076B5 RID: 30389
	public ushort UseTargetID;

	// Token: 0x040076B6 RID: 30390
	public CString MessageStr;

	// Token: 0x040076B7 RID: 30391
	private List<Text> RefreshTextList = new List<Text>(16);

	// Token: 0x02000816 RID: 2070
	public enum BagUpdateType
	{
		// Token: 0x040076B9 RID: 30393
		Item,
		// Token: 0x040076BA RID: 30394
		AutoUseRes,
		// Token: 0x040076BB RID: 30395
		Buy = 65536,
		// Token: 0x040076BC RID: 30396
		BuyConfirm,
		// Token: 0x040076BD RID: 30397
		SpeedupImmed,
		// Token: 0x040076BE RID: 30398
		BuyNumConfirm,
		// Token: 0x040076BF RID: 30399
		GiftShopErr
	}
}
