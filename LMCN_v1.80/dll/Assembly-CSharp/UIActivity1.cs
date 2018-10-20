using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002A2 RID: 674
public class UIActivity1 : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
	// Token: 0x06000D4B RID: 3403 RVA: 0x0013B840 File Offset: 0x00139A40
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_transform = base.transform;
		this.tmpFont = this.GM.GetTTFFont();
		this.m_transform.GetChild(2).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(2).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(2).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(3).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(3).gameObject.AddComponent<ArabicItemTextureRot>();
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(2).GetComponent<CustomImage>().enabled = false;
		}
		Transform child = this.m_transform.GetChild(1);
		this.BgText = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.BgText.font = this.tmpFont;
		this.BgText.text = this.DM.mStringTable.GetStringByID(8108u);
		this.ScrollT = child.GetChild(0);
		this.ContentT = this.ScrollT.GetChild(0);
		this.ContentRC = this.ContentT.GetComponent<RectTransform>();
		Transform child2 = this.ContentT.GetChild(0);
		this.UnitObject = child2.gameObject;
		this.SetAllObject();
		if (this.ContentT != null)
		{
			if (this.AM.Act1arg1 == arg1)
			{
				this.ContentT.GetComponent<RectTransform>().anchoredPosition = this.AM.Act1Pos;
			}
			else
			{
				this.AM.Act1arg1 = arg1;
			}
		}
		this.UnitObject.SetActive(false);
		this.GM.UpdateUI(EGUIWindow.Door, 1, 2);
		if (!this.AM.bAskSecondData && !this.AM.bReOpen && !this.AM.AW_bWaitOpenNext)
		{
			this.AM.Send_ACTIVITY_EVENT_LIST();
		}
	}

	// Token: 0x06000D4C RID: 3404 RVA: 0x0013BA58 File Offset: 0x00139C58
	public override void OnClose()
	{
		this.ReleaseStr();
		if (this.NewsObj != null)
		{
			if (this.NewsObj.RewardStr != null)
			{
				StringManager.Instance.DeSpawnString(this.NewsObj.RewardStr);
				this.NewsObj.RewardStr = null;
			}
			if (this.NewsObj.InfoStr != null)
			{
				StringManager.Instance.DeSpawnString(this.NewsObj.InfoStr);
				this.NewsObj.InfoStr = null;
			}
			if (this.NewsObj.BtnStr != null)
			{
				StringManager.Instance.DeSpawnString(this.NewsObj.BtnStr);
				this.NewsObj.BtnStr = null;
			}
			if (this.NewsObj.FlashStr != null)
			{
				StringManager.Instance.DeSpawnString(this.NewsObj.FlashStr);
				this.NewsObj.FlashStr = null;
			}
		}
		if (this.ContentT != null)
		{
			this.AM.Act1Pos = this.ContentT.GetComponent<RectTransform>().anchoredPosition;
		}
	}

	// Token: 0x06000D4D RID: 3405 RVA: 0x0013BB6C File Offset: 0x00139D6C
	private void SetAllObject()
	{
		this.NowLeft = 116.5f;
		this.ContentRC.sizeDelta = new Vector2(34f, this.ContentRC.sizeDelta.y);
		this.bShowFirstBuy = false;
		if (this.NewsObj == null)
		{
			this.SpawnUnitObject(-1, -1);
		}
		else
		{
			this.NowLeft += 199f;
			this.ContentRC.sizeDelta += new Vector2(199f, 0f);
		}
		for (int i = 0; i < 5; i++)
		{
			if (!this.AM.bOpenCSActivity[i] && this.AM.CSActivityData[i].EventBeginTime > 0L)
			{
				this.SpawnUnitObject(254, i);
			}
		}
		if (!this.AM.bOpenFirstBuyActivity && MallManager.Instance.PaidDollar == 0L && this.GM.BuildingData.GetBuildData(8, 0).Level < 17)
		{
			this.SpawnUnitObject(253, -1);
		}
		for (int j = 0; j < 5; j++)
		{
			if (!this.AM.bOpenSPActivity[j] && this.AM.SPActivityData[j].EventBeginTime > 0L)
			{
				this.SpawnUnitObject(255, j);
			}
		}
		EActivityState fifastate = this.AM.GetFIFAState();
		if (!this.AM.bOpenFIFAActivity && fifastate == EActivityState.EAS_Prepare)
		{
			this.SpawnUnitObject(213, -1);
		}
		EActivityState eactivityState = (fifastate == EActivityState.EAS_None || this.AM.FIFAData[2].ActiveType != EActivityType.EAT_FIFA_KVK) ? this.AM.GetKvKState() : EActivityState.EAS_None;
		if (!this.AM.bOpenKvKActivity && eactivityState == EActivityState.EAS_Prepare)
		{
			this.SpawnUnitObject(205, -1);
		}
		byte level = this.GM.BuildingData.GetBuildData(8, 0).Level;
		if (level >= 20)
		{
			if (this.AM.KOWData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(207, -1);
			}
			if (this.AM.NobilityActivityData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(209, -1);
			}
			if (this.AM.AllianceSummonData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(208, -1);
			}
			if (this.AM.AllyMobilizationData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(206, -1);
			}
			if (this.AM.AllianceWarData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(210, -1);
			}
			if (eactivityState == EActivityState.EAS_Run || eactivityState == EActivityState.EAS_HomeStart || eactivityState == EActivityState.EAS_HomeEnd || eactivityState == EActivityState.EAS_StartRanking)
			{
				this.SpawnUnitObject(205, -1);
				if (this.DM.RoleAlliance.Id != 0u)
				{
					this.SpawnUnitObject(204, -1);
				}
				this.SpawnUnitObject(203, -1);
			}
			if (fifastate == EActivityState.EAS_Run || fifastate == EActivityState.EAS_HomeStart || fifastate == EActivityState.EAS_HomeEnd || fifastate == EActivityState.EAS_StartRanking)
			{
				this.SpawnUnitObject(213, -1);
				if (this.DM.RoleAlliance.Id != 0u)
				{
					this.SpawnUnitObject(212, -1);
				}
				this.SpawnUnitObject(211, -1);
			}
			int num = this.AM.ActivityData.Length;
			for (int k = 0; k < num; k++)
			{
				this.SpawnUnitObject(k, -1);
			}
			if (this.AM.KvKActivityData[0].EventBeginTime > 0L)
			{
				this.SpawnUnitObject(201, -1);
			}
			if (this.AM.KvKActivityData[1].EventBeginTime > 0L)
			{
				this.SpawnUnitObject(202, -1);
			}
		}
		else if (level >= 13 && level <= 19)
		{
			if (this.AM.AllianceSummonData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(208, -1);
			}
			if (this.AM.AllyMobilizationData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(206, -1);
			}
			if (this.AM.AllianceWarData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(210, -1);
			}
			if (eactivityState == EActivityState.EAS_Run || eactivityState == EActivityState.EAS_HomeStart || eactivityState == EActivityState.EAS_HomeEnd || eactivityState == EActivityState.EAS_StartRanking)
			{
				this.SpawnUnitObject(205, -1);
				if (this.DM.RoleAlliance.Id != 0u)
				{
					this.SpawnUnitObject(204, -1);
				}
				this.SpawnUnitObject(203, -1);
			}
			if (fifastate == EActivityState.EAS_Run || fifastate == EActivityState.EAS_HomeStart || fifastate == EActivityState.EAS_HomeEnd || fifastate == EActivityState.EAS_StartRanking)
			{
				this.SpawnUnitObject(213, -1);
				if (this.DM.RoleAlliance.Id != 0u)
				{
					this.SpawnUnitObject(212, -1);
				}
				this.SpawnUnitObject(211, -1);
			}
			int num2 = this.AM.ActivityData.Length;
			for (int l = 0; l < num2; l++)
			{
				this.SpawnUnitObject(l, -1);
			}
			if (this.AM.KvKActivityData[0].EventBeginTime > 0L)
			{
				this.SpawnUnitObject(201, -1);
			}
			if (this.AM.KvKActivityData[1].EventBeginTime > 0L)
			{
				this.SpawnUnitObject(202, -1);
			}
			if (this.AM.KOWData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(207, -1);
			}
			if (this.AM.NobilityActivityData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(209, -1);
			}
		}
		else
		{
			if (this.AM.AllianceSummonData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(208, -1);
			}
			if (this.AM.AllianceWarData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(210, -1);
			}
			if (eactivityState == EActivityState.EAS_Run || eactivityState == EActivityState.EAS_HomeStart || eactivityState == EActivityState.EAS_HomeEnd || eactivityState == EActivityState.EAS_StartRanking)
			{
				this.SpawnUnitObject(205, -1);
				if (this.DM.RoleAlliance.Id != 0u)
				{
					this.SpawnUnitObject(204, -1);
				}
				this.SpawnUnitObject(203, -1);
			}
			if (fifastate == EActivityState.EAS_Run || fifastate == EActivityState.EAS_HomeStart || fifastate == EActivityState.EAS_HomeEnd || fifastate == EActivityState.EAS_StartRanking)
			{
				this.SpawnUnitObject(213, -1);
				if (this.DM.RoleAlliance.Id != 0u)
				{
					this.SpawnUnitObject(212, -1);
				}
				this.SpawnUnitObject(211, -1);
			}
			int num3 = this.AM.ActivityData.Length;
			for (int m = 0; m < num3; m++)
			{
				this.SpawnUnitObject(m, -1);
			}
			if (this.AM.KvKActivityData[0].EventBeginTime > 0L)
			{
				this.SpawnUnitObject(201, -1);
			}
			if (this.AM.KvKActivityData[1].EventBeginTime > 0L)
			{
				this.SpawnUnitObject(202, -1);
			}
			if (this.AM.AllyMobilizationData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(206, -1);
			}
			if (this.AM.KOWData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(207, -1);
			}
			if (this.AM.NobilityActivityData.EventState != EActivityState.EAS_None)
			{
				this.SpawnUnitObject(209, -1);
			}
		}
		if (eactivityState == EActivityState.EAS_ReplayRanking || (this.AM.bOpenKvKActivity && eactivityState == EActivityState.EAS_Prepare))
		{
			this.SpawnUnitObject(205, -1);
		}
		if (fifastate == EActivityState.EAS_ReplayRanking || (this.AM.bOpenFIFAActivity && fifastate == EActivityState.EAS_Prepare))
		{
			this.SpawnUnitObject(213, -1);
		}
		for (int n = 0; n < 5; n++)
		{
			if (this.AM.bOpenCSActivity[n] && this.AM.CSActivityData[n].EventBeginTime > 0L)
			{
				this.SpawnUnitObject(254, n);
			}
		}
		if (this.AM.bOpenFirstBuyActivity && MallManager.Instance.PaidDollar == 0L && this.GM.BuildingData.GetBuildData(8, 0).Level < 17)
		{
			this.SpawnUnitObject(253, -1);
		}
		for (int num4 = 0; num4 < 5; num4++)
		{
			if (this.AM.bOpenSPActivity[num4] && this.AM.SPActivityData[num4].EventBeginTime > 0L)
			{
				this.SpawnUnitObject(255, num4);
			}
		}
		if (this.ScrollT != null)
		{
			this.ScrollT.GetComponent<CScrollRect>().enabled = true;
		}
	}

	// Token: 0x06000D4E RID: 3406 RVA: 0x0013C464 File Offset: 0x0013A664
	private void ReleaseStr()
	{
		for (int i = 0; i < this.AllObject.Count; i++)
		{
			if (this.AllObject[i].RewardStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AllObject[i].RewardStr);
				this.AllObject[i].RewardStr = null;
			}
			if (this.AllObject[i].InfoStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AllObject[i].InfoStr);
				this.AllObject[i].InfoStr = null;
			}
			if (this.AllObject[i].BtnStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AllObject[i].BtnStr);
				this.AllObject[i].BtnStr = null;
			}
			if (this.AllObject[i].FlashStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AllObject[i].FlashStr);
				this.AllObject[i].FlashStr = null;
			}
		}
		for (int j = 0; j < this.KVKObj.Length; j++)
		{
			if (this.KVKObj[j] != null)
			{
				if (this.KVKObj[j].RewardStr != null)
				{
					StringManager.Instance.DeSpawnString(this.KVKObj[j].RewardStr);
					this.KVKObj[j].RewardStr = null;
				}
				if (this.KVKObj[j].InfoStr != null)
				{
					StringManager.Instance.DeSpawnString(this.KVKObj[j].InfoStr);
					this.KVKObj[j].InfoStr = null;
				}
				if (this.KVKObj[j].BtnStr != null)
				{
					StringManager.Instance.DeSpawnString(this.KVKObj[j].BtnStr);
					this.KVKObj[j].BtnStr = null;
				}
				if (this.KVKObj[j].FlashStr != null)
				{
					StringManager.Instance.DeSpawnString(this.KVKObj[j].FlashStr);
					this.KVKObj[j].FlashStr = null;
				}
			}
		}
		for (int k = 0; k < this.CSObj.Length; k++)
		{
			if (this.CSObj[k] != null)
			{
				if (this.CSObj[k].RewardStr != null)
				{
					StringManager.Instance.DeSpawnString(this.CSObj[k].RewardStr);
					this.CSObj[k].RewardStr = null;
				}
				if (this.CSObj[k].InfoStr != null)
				{
					StringManager.Instance.DeSpawnString(this.CSObj[k].InfoStr);
					this.CSObj[k].InfoStr = null;
				}
				if (this.CSObj[k].BtnStr != null)
				{
					StringManager.Instance.DeSpawnString(this.CSObj[k].BtnStr);
					this.CSObj[k].BtnStr = null;
				}
				if (this.CSObj[k].FlashStr != null)
				{
					StringManager.Instance.DeSpawnString(this.CSObj[k].FlashStr);
					this.CSObj[k].FlashStr = null;
				}
			}
		}
		for (int l = 0; l < this.SPObj.Length; l++)
		{
			if (this.SPObj[l] != null)
			{
				if (this.SPObj[l].RewardStr != null)
				{
					StringManager.Instance.DeSpawnString(this.SPObj[l].RewardStr);
					this.SPObj[l].RewardStr = null;
				}
				if (this.SPObj[l].InfoStr != null)
				{
					StringManager.Instance.DeSpawnString(this.SPObj[l].InfoStr);
					this.SPObj[l].InfoStr = null;
				}
				if (this.SPObj[l].BtnStr != null)
				{
					StringManager.Instance.DeSpawnString(this.SPObj[l].BtnStr);
					this.SPObj[l].BtnStr = null;
				}
				if (this.SPObj[l].FlashStr != null)
				{
					StringManager.Instance.DeSpawnString(this.SPObj[l].FlashStr);
					this.SPObj[l].FlashStr = null;
				}
			}
		}
		if (this.AMObj != null)
		{
			if (this.AMObj.RewardStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AMObj.RewardStr);
				this.AMObj.RewardStr = null;
			}
			if (this.AMObj.InfoStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AMObj.InfoStr);
				this.AMObj.InfoStr = null;
			}
			if (this.AMObj.BtnStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AMObj.BtnStr);
				this.AMObj.BtnStr = null;
			}
			if (this.AMObj.FlashStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AMObj.FlashStr);
				this.AMObj.FlashStr = null;
			}
			if (this.AMObj.AllyRankTextStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AMObj.AllyRankTextStr);
				this.AMObj.AllyRankTextStr = null;
			}
		}
		if (this.KOWObj != null)
		{
			if (this.KOWObj.RewardStr != null)
			{
				StringManager.Instance.DeSpawnString(this.KOWObj.RewardStr);
				this.KOWObj.RewardStr = null;
			}
			if (this.KOWObj.InfoStr != null)
			{
				StringManager.Instance.DeSpawnString(this.KOWObj.InfoStr);
				this.KOWObj.InfoStr = null;
			}
			if (this.KOWObj.BtnStr != null)
			{
				StringManager.Instance.DeSpawnString(this.KOWObj.BtnStr);
				this.KOWObj.BtnStr = null;
			}
			if (this.KOWObj.FlashStr != null)
			{
				StringManager.Instance.DeSpawnString(this.KOWObj.FlashStr);
				this.KOWObj.FlashStr = null;
			}
			if (this.KOWObj.AllyRankTextStr != null)
			{
				StringManager.Instance.DeSpawnString(this.KOWObj.AllyRankTextStr);
				this.KOWObj.AllyRankTextStr = null;
			}
		}
		if (this.SumObj != null)
		{
			if (this.SumObj.RewardStr != null)
			{
				StringManager.Instance.DeSpawnString(this.SumObj.RewardStr);
				this.SumObj.RewardStr = null;
			}
			if (this.SumObj.InfoStr != null)
			{
				StringManager.Instance.DeSpawnString(this.SumObj.InfoStr);
				this.SumObj.InfoStr = null;
			}
			if (this.SumObj.BtnStr != null)
			{
				StringManager.Instance.DeSpawnString(this.SumObj.BtnStr);
				this.SumObj.BtnStr = null;
			}
			if (this.SumObj.FlashStr != null)
			{
				StringManager.Instance.DeSpawnString(this.SumObj.FlashStr);
				this.SumObj.FlashStr = null;
			}
			if (this.SumObj.AllyRankTextStr != null)
			{
				StringManager.Instance.DeSpawnString(this.SumObj.AllyRankTextStr);
				this.SumObj.AllyRankTextStr = null;
			}
		}
		if (this.NWObj != null)
		{
			if (this.NWObj.RewardStr != null)
			{
				StringManager.Instance.DeSpawnString(this.NWObj.RewardStr);
				this.NWObj.RewardStr = null;
			}
			if (this.NWObj.InfoStr != null)
			{
				StringManager.Instance.DeSpawnString(this.NWObj.InfoStr);
				this.NWObj.InfoStr = null;
			}
			if (this.NWObj.BtnStr != null)
			{
				StringManager.Instance.DeSpawnString(this.NWObj.BtnStr);
				this.NWObj.BtnStr = null;
			}
			if (this.NWObj.FlashStr != null)
			{
				StringManager.Instance.DeSpawnString(this.NWObj.FlashStr);
				this.NWObj.FlashStr = null;
			}
			if (this.NWObj.AllyRankTextStr != null)
			{
				StringManager.Instance.DeSpawnString(this.NWObj.AllyRankTextStr);
				this.NWObj.AllyRankTextStr = null;
			}
		}
		if (this.AWObj != null)
		{
			if (this.AWObj.RewardStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AWObj.RewardStr);
				this.AWObj.RewardStr = null;
			}
			if (this.AWObj.InfoStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AWObj.InfoStr);
				this.AWObj.InfoStr = null;
			}
			if (this.AWObj.BtnStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AWObj.BtnStr);
				this.AWObj.BtnStr = null;
			}
			if (this.AWObj.FlashStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AWObj.FlashStr);
				this.AWObj.FlashStr = null;
			}
			if (this.AWObj.AllyRankTextStr != null)
			{
				StringManager.Instance.DeSpawnString(this.AWObj.AllyRankTextStr);
				this.AWObj.AllyRankTextStr = null;
			}
		}
		if (this.FBObj != null)
		{
			if (this.FBObj.RewardStr != null)
			{
				StringManager.Instance.DeSpawnString(this.FBObj.RewardStr);
				this.FBObj.RewardStr = null;
			}
			if (this.FBObj.InfoStr != null)
			{
				StringManager.Instance.DeSpawnString(this.FBObj.InfoStr);
				this.FBObj.InfoStr = null;
			}
			if (this.FBObj.BtnStr != null)
			{
				StringManager.Instance.DeSpawnString(this.FBObj.BtnStr);
				this.FBObj.BtnStr = null;
			}
			if (this.FBObj.FlashStr != null)
			{
				StringManager.Instance.DeSpawnString(this.FBObj.FlashStr);
				this.FBObj.FlashStr = null;
			}
			if (this.FBObj.AllyRankTextStr != null)
			{
				StringManager.Instance.DeSpawnString(this.FBObj.AllyRankTextStr);
				this.FBObj.AllyRankTextStr = null;
			}
		}
		for (int m = 0; m < this.FIFAObj.Length; m++)
		{
			if (this.FIFAObj[m] != null)
			{
				if (this.FIFAObj[m].RewardStr != null)
				{
					StringManager.Instance.DeSpawnString(this.FIFAObj[m].RewardStr);
					this.FIFAObj[m].RewardStr = null;
				}
				if (this.FIFAObj[m].InfoStr != null)
				{
					StringManager.Instance.DeSpawnString(this.FIFAObj[m].InfoStr);
					this.FIFAObj[m].InfoStr = null;
				}
				if (this.FIFAObj[m].BtnStr != null)
				{
					StringManager.Instance.DeSpawnString(this.FIFAObj[m].BtnStr);
					this.FIFAObj[m].BtnStr = null;
				}
				if (this.FIFAObj[m].FlashStr != null)
				{
					StringManager.Instance.DeSpawnString(this.FIFAObj[m].FlashStr);
					this.FIFAObj[m].FlashStr = null;
				}
			}
		}
	}

	// Token: 0x06000D4F RID: 3407 RVA: 0x0013CFF0 File Offset: 0x0013B1F0
	private void ResetAll()
	{
		if (this.ScrollT != null)
		{
			this.ScrollT.GetComponent<CScrollRect>().StopMovement();
			this.ScrollT.GetComponent<CScrollRect>().enabled = false;
		}
		for (int i = 0; i < this.AllObject.Count; i++)
		{
			this.AllObject[i].mRC.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(this.AllObject[i].mRC.gameObject);
		}
		for (int j = 0; j < this.CSObj.Length; j++)
		{
			if (this.CSObj[j] != null)
			{
				this.CSObj[j].mRC.gameObject.SetActive(false);
				UnityEngine.Object.Destroy(this.CSObj[j].mRC.gameObject);
			}
		}
		for (int k = 0; k < this.SPObj.Length; k++)
		{
			if (this.SPObj[k] != null)
			{
				this.SPObj[k].mRC.gameObject.SetActive(false);
				UnityEngine.Object.Destroy(this.SPObj[k].mRC.gameObject);
			}
		}
		for (int l = 0; l < this.KVKObj.Length; l++)
		{
			if (this.KVKObj[l] != null)
			{
				this.KVKObj[l].mRC.gameObject.SetActive(false);
				UnityEngine.Object.Destroy(this.KVKObj[l].mRC.gameObject);
			}
		}
		if (this.AMObj != null)
		{
			this.AMObj.mRC.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(this.AMObj.mRC.gameObject);
		}
		if (this.KOWObj != null)
		{
			this.KOWObj.mRC.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(this.KOWObj.mRC.gameObject);
		}
		if (this.SumObj != null)
		{
			this.SumObj.mRC.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(this.SumObj.mRC.gameObject);
		}
		if (this.NWObj != null)
		{
			this.NWObj.mRC.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(this.NWObj.mRC.gameObject);
		}
		if (this.AWObj != null)
		{
			this.AWObj.mRC.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(this.AWObj.mRC.gameObject);
		}
		if (this.FBObj != null)
		{
			this.FBObj.mRC.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(this.FBObj.mRC.gameObject);
		}
		for (int m = 0; m < this.FIFAObj.Length; m++)
		{
			if (this.FIFAObj[m] != null)
			{
				this.FIFAObj[m].mRC.gameObject.SetActive(false);
				UnityEngine.Object.Destroy(this.FIFAObj[m].mRC.gameObject);
			}
		}
		this.ReleaseStr();
		for (int n = 0; n < this.CSObj.Length; n++)
		{
			this.CSObj[n] = null;
		}
		for (int num = 0; num < this.SPObj.Length; num++)
		{
			this.SPObj[num] = null;
		}
		this.AllObject.Clear();
		for (int num2 = 0; num2 < this.KVKObj.Length; num2++)
		{
			this.KVKObj[num2] = null;
		}
		this.AMObj = null;
		this.KOWObj = null;
		this.SumObj = null;
		this.NWObj = null;
		this.AWObj = null;
		this.FBObj = null;
		for (int num3 = 0; num3 < this.FIFAObj.Length; num3++)
		{
			this.FIFAObj[num3] = null;
		}
		this.SetAllObject();
	}

	// Token: 0x06000D50 RID: 3408 RVA: 0x0013D400 File Offset: 0x0013B600
	private void SpawnUnitObject(int index, int index2 = -1)
	{
		UnitComp3 unitComp = new UnitComp3();
		unitComp.RewardStr = StringManager.Instance.SpawnString(50);
		unitComp.InfoStr = StringManager.Instance.SpawnString(50);
		unitComp.BtnStr = StringManager.Instance.SpawnString(50);
		unitComp.FlashStr = StringManager.Instance.SpawnString(10);
		GameObject gameObject = UnityEngine.Object.Instantiate(this.UnitObject) as GameObject;
		gameObject.SetActive(true);
		gameObject.transform.SetParent(this.ContentT, false);
		gameObject.transform.GetChild(8).GetComponent<CustomImage>().hander = this;
		gameObject.transform.GetChild(8).GetComponent<RectTransform>().anchoredPosition += new Vector2(-3f, 0f);
		gameObject.transform.GetChild(8).GetChild(0).GetComponent<CustomImage>().hander = this;
		gameObject.transform.GetChild(8).GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = this;
		gameObject.transform.GetChild(9).GetComponent<CustomImage>().hander = this;
		if (index == -1)
		{
			UIButton component = gameObject.GetComponent<UIButton>();
			component.m_BtnID2 = index;
			component.m_Handler = this;
			unitComp.SA = gameObject.GetComponent<UISpritesArray>();
			unitComp.SA.SetSpriteIndex(4);
			unitComp.mRC = gameObject.GetComponent<RectTransform>();
			unitComp.mRC.anchoredPosition = new Vector3(this.NowLeft, -251.5f, 0f);
			this.NowLeft += 199f;
			Transform transform = gameObject.transform;
			unitComp.SA2 = transform.GetChild(1).GetComponent<UISpritesArray>();
			unitComp.SA2.SetSpriteIndex(0);
			unitComp.SA2.m_Image.rectTransform.sizeDelta += new Vector2(0f, 160f);
			unitComp.SA2.m_Image.enabled = true;
			transform.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			Transform child = transform.GetChild(2);
			unitComp.ScoreGO = child.gameObject;
			unitComp.SliderNormal = new Image[3];
			unitComp.SliderFlash = new Image[3];
			unitComp.SliderNormal[0] = child.GetChild(2).GetComponent<Image>();
			unitComp.SliderNormal[1] = child.GetChild(3).GetComponent<Image>();
			unitComp.SliderNormal[2] = child.GetChild(4).GetComponent<Image>();
			unitComp.SliderFlash[0] = child.GetChild(5).GetComponent<Image>();
			unitComp.SliderFlash[1] = child.GetChild(6).GetComponent<Image>();
			unitComp.SliderFlash[2] = child.GetChild(7).GetComponent<Image>();
			child.gameObject.SetActive(false);
			unitComp.NameText = transform.GetChild(3).GetComponent<UIText>();
			unitComp.NameText.font = this.tmpFont;
			unitComp.NameText.text = this.DM.mStringTable.GetStringByID(8168u);
			unitComp.RewardText = transform.GetChild(4).GetComponent<UIText>();
			unitComp.RewardText.font = this.tmpFont;
			unitComp.RewardText.enabled = false;
			unitComp.InfoText = transform.GetChild(5).GetComponent<UIText>();
			unitComp.InfoText.font = this.tmpFont;
			unitComp.InfoText.enabled = false;
			unitComp.BtnText1 = transform.GetChild(6).GetComponent<UIText>();
			unitComp.BtnText1.font = this.tmpFont;
			unitComp.BtnText1.enabled = false;
			unitComp.BtnText2 = transform.GetChild(7).GetComponent<UIText>();
			unitComp.BtnText2.font = this.tmpFont;
			unitComp.BtnText2.enabled = false;
			unitComp.FlashRC = gameObject.transform.GetChild(9).GetComponent<RectTransform>();
			unitComp.FlashText = gameObject.transform.GetChild(9).GetChild(0).GetComponent<UIText>();
			unitComp.FlashText.font = this.tmpFont;
			this.NewsObj = unitComp;
			this.CheckNews();
		}
		else if (index == 253)
		{
			this.bShowFirstBuy = true;
			UIButton component2 = gameObject.GetComponent<UIButton>();
			component2.m_BtnID2 = 18;
			component2.m_Handler = this;
			unitComp.SA = gameObject.GetComponent<UISpritesArray>();
			unitComp.mRC = gameObject.GetComponent<RectTransform>();
			unitComp.mRC.anchoredPosition = new Vector3(this.NowLeft, -251.5f, 0f);
			this.NowLeft += 199f;
			Transform transform = gameObject.transform;
			unitComp.MainImg = transform.GetChild(1).GetComponent<Image>();
			unitComp.SA2 = transform.GetChild(1).GetComponent<UISpritesArray>();
			transform.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			Transform child = transform.GetChild(2);
			unitComp.ScoreGO = child.gameObject;
			unitComp.SliderNormal = new Image[3];
			unitComp.SliderFlash = new Image[3];
			unitComp.SliderNormal[0] = child.GetChild(2).GetComponent<Image>();
			unitComp.SliderNormal[1] = child.GetChild(3).GetComponent<Image>();
			unitComp.SliderNormal[2] = child.GetChild(4).GetComponent<Image>();
			unitComp.SliderFlash[0] = child.GetChild(5).GetComponent<Image>();
			unitComp.SliderFlash[1] = child.GetChild(6).GetComponent<Image>();
			unitComp.SliderFlash[2] = child.GetChild(7).GetComponent<Image>();
			child.gameObject.SetActive(false);
			unitComp.NameText = transform.GetChild(3).GetComponent<UIText>();
			unitComp.NameText.font = this.tmpFont;
			unitComp.RewardText = transform.GetChild(4).GetComponent<UIText>();
			unitComp.RewardText.font = this.tmpFont;
			unitComp.RewardText.enabled = false;
			unitComp.InfoText = transform.GetChild(5).GetComponent<UIText>();
			unitComp.InfoText.font = this.tmpFont;
			unitComp.InfoText.rectTransform.sizeDelta += new Vector2(0f, 30f);
			unitComp.InfoText.text = "test middle text";
			unitComp.BtnText1 = transform.GetChild(6).GetComponent<UIText>();
			unitComp.BtnText1.font = this.tmpFont;
			unitComp.BtnText1.rectTransform.sizeDelta = new Vector2(unitComp.BtnText1.rectTransform.sizeDelta.x, 55f);
			unitComp.BtnText1.text = this.DM.mStringTable.GetStringByID(10184u);
			unitComp.BtnText2 = transform.GetChild(7).GetComponent<UIText>();
			unitComp.BtnText2.font = this.tmpFont;
			unitComp.BtnText2.enabled = false;
			unitComp.FlashGO = gameObject.transform.GetChild(8).gameObject;
			unitComp.FlashGO.SetActive(!this.AM.bClickFirstBuyActivity);
			this.FBObj = unitComp;
			this.SetName(index, index2);
			this.SetMiddleText(index, index2);
			this.SetBackImg(index, index2);
			this.SetMainImg(index, index2);
		}
		else if (index == 254 || index == 255)
		{
			bool flag = index == 254;
			SPActivityDataType spactivityDataType = (!flag) ? this.AM.SPActivityData[index2] : this.AM.CSActivityData[index2];
			UIButton component3 = gameObject.GetComponent<UIButton>();
			if (index == 254)
			{
				component3.m_BtnID2 = 3;
			}
			else
			{
				component3.m_BtnID2 = 2;
			}
			component3.m_BtnID3 = index2;
			component3.m_Handler = this;
			component3.m_Handler = this;
			unitComp.SA = gameObject.GetComponent<UISpritesArray>();
			unitComp.mRC = gameObject.GetComponent<RectTransform>();
			unitComp.mRC.anchoredPosition = new Vector3(this.NowLeft, -251.5f, 0f);
			this.NowLeft += 199f;
			Transform transform = gameObject.transform;
			unitComp.MainImg = transform.GetChild(1).GetComponent<Image>();
			unitComp.SA2 = transform.GetChild(1).GetComponent<UISpritesArray>();
			transform.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			Transform child = transform.GetChild(2);
			unitComp.ScoreGO = child.gameObject;
			unitComp.SliderNormal = new Image[3];
			unitComp.SliderFlash = new Image[3];
			unitComp.SliderNormal[0] = child.GetChild(2).GetComponent<Image>();
			unitComp.SliderNormal[1] = child.GetChild(3).GetComponent<Image>();
			unitComp.SliderNormal[2] = child.GetChild(4).GetComponent<Image>();
			unitComp.SliderFlash[0] = child.GetChild(5).GetComponent<Image>();
			unitComp.SliderFlash[1] = child.GetChild(6).GetComponent<Image>();
			unitComp.SliderFlash[2] = child.GetChild(7).GetComponent<Image>();
			child.gameObject.SetActive(false);
			unitComp.NameText = transform.GetChild(3).GetComponent<UIText>();
			unitComp.NameText.font = this.tmpFont;
			unitComp.NameText.text = this.DM.mStringTable.GetStringByID((uint)spactivityDataType.Name);
			unitComp.RewardText = transform.GetChild(4).GetComponent<UIText>();
			unitComp.RewardText.font = this.tmpFont;
			unitComp.RewardText.enabled = false;
			unitComp.InfoText = transform.GetChild(5).GetComponent<UIText>();
			unitComp.InfoText.font = this.tmpFont;
			unitComp.InfoText.rectTransform.sizeDelta += new Vector2(0f, 30f);
			unitComp.InfoText.text = "test middle text";
			unitComp.BtnText1 = transform.GetChild(6).GetComponent<UIText>();
			unitComp.BtnText1.font = this.tmpFont;
			unitComp.BtnText2 = transform.GetChild(7).GetComponent<UIText>();
			unitComp.BtnText2.font = this.tmpFont;
			unitComp.FlashGO = gameObject.transform.GetChild(8).gameObject;
			if (flag)
			{
				this.CSObj[index2] = unitComp;
			}
			else
			{
				this.SPObj[index2] = unitComp;
			}
			this.SetText(index, index2);
			this.SetMiddleText(index, index2);
			this.SetBackImg(index, index2);
			this.SetMainImg(index, index2);
		}
		else if (index >= 201 && index <= 204)
		{
			ActivityDataType activityDataType = this.AM.KvKActivityData[index - 201];
			UIButton component4 = gameObject.GetComponent<UIButton>();
			component4.m_BtnID2 = 11;
			component4.m_BtnID3 = index;
			component4.m_Handler = this;
			unitComp.SA = gameObject.GetComponent<UISpritesArray>();
			unitComp.mRC = gameObject.GetComponent<RectTransform>();
			unitComp.mRC.anchoredPosition = new Vector3(this.NowLeft, -251.5f, 0f);
			this.NowLeft += 199f;
			Transform transform = gameObject.transform;
			if (index >= 203 && index <= 204)
			{
				transform.GetChild(0).gameObject.SetActive(true);
			}
			unitComp.MainImg = transform.GetChild(1).GetComponent<Image>();
			unitComp.SA2 = transform.GetChild(1).GetComponent<UISpritesArray>();
			transform.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			Transform child = transform.GetChild(2);
			unitComp.ScoreGO = child.gameObject;
			unitComp.SliderNormal = new Image[3];
			unitComp.SliderFlash = new Image[3];
			unitComp.SliderNormal[0] = child.GetChild(2).GetComponent<Image>();
			unitComp.SliderNormal[1] = child.GetChild(3).GetComponent<Image>();
			unitComp.SliderNormal[2] = child.GetChild(4).GetComponent<Image>();
			unitComp.SliderFlash[0] = child.GetChild(5).GetComponent<Image>();
			unitComp.SliderFlash[1] = child.GetChild(6).GetComponent<Image>();
			unitComp.SliderFlash[2] = child.GetChild(7).GetComponent<Image>();
			unitComp.NameText = transform.GetChild(3).GetComponent<UIText>();
			unitComp.NameText.font = this.tmpFont;
			unitComp.NameText.text = this.DM.mStringTable.GetStringByID((uint)activityDataType.Name);
			unitComp.RewardText = transform.GetChild(4).GetComponent<UIText>();
			unitComp.RewardText.font = this.tmpFont;
			unitComp.InfoText = transform.GetChild(5).GetComponent<UIText>();
			unitComp.InfoText.font = this.tmpFont;
			unitComp.BtnText1 = transform.GetChild(6).GetComponent<UIText>();
			unitComp.BtnText1.font = this.tmpFont;
			unitComp.BtnText2 = transform.GetChild(7).GetComponent<UIText>();
			unitComp.BtnText2.font = this.tmpFont;
			this.KVKObj[index - 201] = unitComp;
			this.SetText(index, -1);
			this.SetBackImg(index, -1);
			this.SetMainImg(index, -1);
		}
		else if (index == 205)
		{
			ActivityDataType activityDataType2 = this.AM.KvKActivityData[index - 201];
			UIButton component5 = gameObject.GetComponent<UIButton>();
			component5.m_BtnID2 = 11;
			component5.m_BtnID3 = index;
			component5.m_Handler = this;
			unitComp.SA = gameObject.GetComponent<UISpritesArray>();
			unitComp.mRC = gameObject.GetComponent<RectTransform>();
			unitComp.mRC.anchoredPosition = new Vector3(this.NowLeft, -251.5f, 0f);
			this.NowLeft += 199f;
			Transform transform = gameObject.transform;
			transform.GetChild(0).gameObject.SetActive(true);
			unitComp.MainImg = transform.GetChild(1).GetComponent<Image>();
			unitComp.SA2 = transform.GetChild(1).GetComponent<UISpritesArray>();
			transform.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			Transform child = transform.GetChild(2);
			unitComp.ScoreGO = child.gameObject;
			unitComp.SliderNormal = new Image[3];
			unitComp.SliderFlash = new Image[3];
			unitComp.SliderNormal[0] = child.GetChild(2).GetComponent<Image>();
			unitComp.SliderNormal[1] = child.GetChild(3).GetComponent<Image>();
			unitComp.SliderNormal[2] = child.GetChild(4).GetComponent<Image>();
			unitComp.SliderFlash[0] = child.GetChild(5).GetComponent<Image>();
			unitComp.SliderFlash[1] = child.GetChild(6).GetComponent<Image>();
			unitComp.SliderFlash[2] = child.GetChild(7).GetComponent<Image>();
			child.gameObject.SetActive(false);
			unitComp.NameText = transform.GetChild(3).GetComponent<UIText>();
			unitComp.NameText.font = this.tmpFont;
			unitComp.NameText.text = this.DM.mStringTable.GetStringByID((uint)activityDataType2.Name);
			unitComp.RewardText = transform.GetChild(4).GetComponent<UIText>();
			unitComp.RewardText.font = this.tmpFont;
			unitComp.RewardText.enabled = false;
			unitComp.InfoText = transform.GetChild(5).GetComponent<UIText>();
			unitComp.InfoText.font = this.tmpFont;
			unitComp.InfoText.rectTransform.sizeDelta += new Vector2(0f, 30f);
			unitComp.InfoText.text = "test middle text";
			unitComp.BtnText1 = transform.GetChild(6).GetComponent<UIText>();
			unitComp.BtnText1.font = this.tmpFont;
			unitComp.BtnText2 = transform.GetChild(7).GetComponent<UIText>();
			unitComp.BtnText2.font = this.tmpFont;
			this.KVKObj[4] = unitComp;
			this.SetText(index, -1);
			this.SetMiddleText(index, -1);
			this.SetBackImg(index, -1);
			this.SetMainImg(index, -1);
		}
		else if (index == 206)
		{
			ActivityDataType allyMobilizationData = this.AM.AllyMobilizationData;
			UIButton component6 = gameObject.GetComponent<UIButton>();
			component6.m_BtnID2 = 12;
			component6.m_BtnID3 = index;
			component6.m_Handler = this;
			unitComp.SA = gameObject.GetComponent<UISpritesArray>();
			unitComp.mRC = gameObject.GetComponent<RectTransform>();
			unitComp.mRC.anchoredPosition = new Vector3(this.NowLeft, -251.5f, 0f);
			this.NowLeft += 199f;
			Transform transform = gameObject.transform;
			unitComp.MainImg = transform.GetChild(1).GetComponent<Image>();
			unitComp.SA2 = transform.GetChild(1).GetComponent<UISpritesArray>();
			transform.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			unitComp.AllyRankImg = transform.GetChild(11).GetChild(0).GetComponent<Image>();
			unitComp.AllyRankImg.transform.parent.gameObject.SetActive(true);
			this.GM.SetAllyRankImage(unitComp.AllyRankImg, this.DM.RoleAlliance.AMRank);
			Transform child = transform.GetChild(10);
			unitComp.ScoreGO = child.gameObject;
			unitComp.RankSlider = child.GetChild(0).GetComponent<Image>();
			unitComp.RankSlider2 = child.GetChild(1).GetComponent<Image>();
			unitComp.RankText = child.GetChild(2).GetChild(0).GetComponent<UIText>();
			unitComp.RankText.font = this.tmpFont;
			unitComp.ScoreGO.SetActive(true);
			transform.GetChild(2).gameObject.SetActive(false);
			unitComp.NameText = transform.GetChild(3).GetComponent<UIText>();
			unitComp.NameText.font = this.tmpFont;
			unitComp.NameText.text = this.DM.mStringTable.GetStringByID((uint)allyMobilizationData.Name);
			unitComp.RewardText = transform.GetChild(4).GetComponent<UIText>();
			unitComp.RewardText.font = this.tmpFont;
			unitComp.RewardText.enabled = false;
			unitComp.InfoText = transform.GetChild(5).GetComponent<UIText>();
			unitComp.InfoText.font = this.tmpFont;
			unitComp.BtnText1 = transform.GetChild(6).GetComponent<UIText>();
			unitComp.BtnText1.font = this.tmpFont;
			unitComp.BtnText2 = transform.GetChild(7).GetComponent<UIText>();
			unitComp.BtnText2.font = this.tmpFont;
			unitComp.FlashGO = gameObject.transform.GetChild(8).gameObject;
			this.AMObj = unitComp;
			this.SetText(index, -1);
			this.SetMiddleText(index, -1);
			this.SetBackImg(index, -1);
			this.SetMainImg(index, -1);
			this.CheckAMShowHint();
		}
		else if (index == 207)
		{
			ActivityDataType kowdata = this.AM.KOWData;
			UIButton component7 = gameObject.GetComponent<UIButton>();
			component7.m_BtnID2 = 13;
			component7.m_BtnID3 = index2;
			component7.m_Handler = this;
			unitComp.SA = gameObject.GetComponent<UISpritesArray>();
			unitComp.mRC = gameObject.GetComponent<RectTransform>();
			unitComp.mRC.anchoredPosition = new Vector3(this.NowLeft, -251.5f, 0f);
			this.NowLeft += 199f;
			Transform transform = gameObject.transform;
			transform.GetChild(0).gameObject.SetActive(true);
			unitComp.MainImg = transform.GetChild(1).GetComponent<Image>();
			unitComp.SA2 = transform.GetChild(1).GetComponent<UISpritesArray>();
			transform.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			Transform child = transform.GetChild(2);
			unitComp.ScoreGO = child.gameObject;
			unitComp.SliderNormal = new Image[3];
			unitComp.SliderFlash = new Image[3];
			unitComp.SliderNormal[0] = child.GetChild(2).GetComponent<Image>();
			unitComp.SliderNormal[1] = child.GetChild(3).GetComponent<Image>();
			unitComp.SliderNormal[2] = child.GetChild(4).GetComponent<Image>();
			unitComp.SliderFlash[0] = child.GetChild(5).GetComponent<Image>();
			unitComp.SliderFlash[1] = child.GetChild(6).GetComponent<Image>();
			unitComp.SliderFlash[2] = child.GetChild(7).GetComponent<Image>();
			child.gameObject.SetActive(false);
			unitComp.NameText = transform.GetChild(3).GetComponent<UIText>();
			unitComp.NameText.font = this.tmpFont;
			unitComp.NameText.text = this.DM.mStringTable.GetStringByID((uint)kowdata.Name);
			unitComp.RewardText = transform.GetChild(4).GetComponent<UIText>();
			unitComp.RewardText.font = this.tmpFont;
			unitComp.RewardText.enabled = false;
			unitComp.InfoText = transform.GetChild(5).GetComponent<UIText>();
			unitComp.InfoText.font = this.tmpFont;
			unitComp.InfoText.rectTransform.sizeDelta += new Vector2(0f, 30f);
			unitComp.InfoText.text = "test middle text";
			unitComp.BtnText1 = transform.GetChild(6).GetComponent<UIText>();
			unitComp.BtnText1.font = this.tmpFont;
			unitComp.BtnText2 = transform.GetChild(7).GetComponent<UIText>();
			unitComp.BtnText2.font = this.tmpFont;
			unitComp.FlashGO = gameObject.transform.GetChild(8).gameObject;
			this.KOWObj = unitComp;
			this.SetText(index, -1);
			this.SetMiddleText(index, -1);
			this.SetBackImg(index, -1);
			this.SetMainImg(index, -1);
		}
		else if (index == 208)
		{
			ActivityDataType allianceSummonData = this.AM.AllianceSummonData;
			UIButton component8 = gameObject.GetComponent<UIButton>();
			component8.m_BtnID2 = 14;
			component8.m_BtnID3 = index;
			component8.m_Handler = this;
			unitComp.SA = gameObject.GetComponent<UISpritesArray>();
			unitComp.mRC = gameObject.GetComponent<RectTransform>();
			unitComp.mRC.anchoredPosition = new Vector3(this.NowLeft, -251.5f, 0f);
			this.NowLeft += 199f;
			Transform transform = gameObject.transform;
			unitComp.MainImg = transform.GetChild(1).GetComponent<Image>();
			unitComp.SA2 = transform.GetChild(1).GetComponent<UISpritesArray>();
			transform.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			Transform child = transform.GetChild(2);
			unitComp.ScoreGO = child.gameObject;
			unitComp.SliderNormal = new Image[3];
			unitComp.SliderFlash = new Image[3];
			unitComp.SliderNormal[0] = child.GetChild(2).GetComponent<Image>();
			unitComp.SliderNormal[1] = child.GetChild(3).GetComponent<Image>();
			unitComp.SliderNormal[2] = child.GetChild(4).GetComponent<Image>();
			unitComp.SliderFlash[0] = child.GetChild(5).GetComponent<Image>();
			unitComp.SliderFlash[1] = child.GetChild(6).GetComponent<Image>();
			unitComp.SliderFlash[2] = child.GetChild(7).GetComponent<Image>();
			unitComp.NameText = transform.GetChild(3).GetComponent<UIText>();
			unitComp.NameText.font = this.tmpFont;
			unitComp.NameText.text = this.DM.mStringTable.GetStringByID((uint)allianceSummonData.Name);
			unitComp.RewardText = transform.GetChild(4).GetComponent<UIText>();
			unitComp.RewardText.font = this.tmpFont;
			unitComp.RewardText.enabled = false;
			unitComp.InfoText = transform.GetChild(5).GetComponent<UIText>();
			unitComp.InfoText.font = this.tmpFont;
			unitComp.BtnText1 = transform.GetChild(6).GetComponent<UIText>();
			unitComp.BtnText1.font = this.tmpFont;
			unitComp.BtnText2 = transform.GetChild(7).GetComponent<UIText>();
			unitComp.BtnText2.font = this.tmpFont;
			unitComp.FlashGO = gameObject.transform.GetChild(8).gameObject;
			this.SumObj = unitComp;
			this.SetText(index, -1);
			this.SetBackImg(index, -1);
			this.SetMainImg(index, -1);
		}
		else if (index == 209)
		{
			ActivityDataType nobilityActivityData = this.AM.NobilityActivityData;
			UIButton component9 = gameObject.GetComponent<UIButton>();
			component9.m_BtnID2 = 15;
			component9.m_BtnID3 = index2;
			component9.m_Handler = this;
			unitComp.SA = gameObject.GetComponent<UISpritesArray>();
			unitComp.mRC = gameObject.GetComponent<RectTransform>();
			unitComp.mRC.anchoredPosition = new Vector3(this.NowLeft, -251.5f, 0f);
			this.NowLeft += 199f;
			Transform transform = gameObject.transform;
			transform.GetChild(0).gameObject.SetActive(true);
			unitComp.MainImg = transform.GetChild(1).GetComponent<Image>();
			unitComp.SA2 = transform.GetChild(1).GetComponent<UISpritesArray>();
			transform.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			Transform child = transform.GetChild(2);
			unitComp.ScoreGO = child.gameObject;
			unitComp.SliderNormal = new Image[3];
			unitComp.SliderFlash = new Image[3];
			unitComp.SliderNormal[0] = child.GetChild(2).GetComponent<Image>();
			unitComp.SliderNormal[1] = child.GetChild(3).GetComponent<Image>();
			unitComp.SliderNormal[2] = child.GetChild(4).GetComponent<Image>();
			unitComp.SliderFlash[0] = child.GetChild(5).GetComponent<Image>();
			unitComp.SliderFlash[1] = child.GetChild(6).GetComponent<Image>();
			unitComp.SliderFlash[2] = child.GetChild(7).GetComponent<Image>();
			child.gameObject.SetActive(false);
			unitComp.NameText = transform.GetChild(3).GetComponent<UIText>();
			unitComp.NameText.font = this.tmpFont;
			unitComp.NameText.text = this.DM.mStringTable.GetStringByID((uint)nobilityActivityData.Name);
			unitComp.RewardText = transform.GetChild(4).GetComponent<UIText>();
			unitComp.RewardText.font = this.tmpFont;
			unitComp.RewardText.enabled = false;
			unitComp.InfoText = transform.GetChild(5).GetComponent<UIText>();
			unitComp.InfoText.font = this.tmpFont;
			unitComp.InfoText.rectTransform.sizeDelta += new Vector2(0f, 30f);
			unitComp.InfoText.text = "test middle text";
			unitComp.BtnText1 = transform.GetChild(6).GetComponent<UIText>();
			unitComp.BtnText1.font = this.tmpFont;
			unitComp.BtnText2 = transform.GetChild(7).GetComponent<UIText>();
			unitComp.BtnText2.font = this.tmpFont;
			unitComp.FlashGO = gameObject.transform.GetChild(8).gameObject;
			this.NWObj = unitComp;
			this.SetText(index, -1);
			this.SetMiddleText(index, -1);
			this.SetBackImg(index, -1);
			this.SetMainImg(index, -1);
			this.CheckNWShowHint();
		}
		else if (index == 210)
		{
			ActivityDataType allianceWarData = this.AM.AllianceWarData;
			UIButton component10 = gameObject.GetComponent<UIButton>();
			component10.m_BtnID2 = 16;
			component10.m_BtnID3 = index2;
			component10.m_Handler = this;
			unitComp.SA = gameObject.GetComponent<UISpritesArray>();
			unitComp.mRC = gameObject.GetComponent<RectTransform>();
			unitComp.mRC.anchoredPosition = new Vector3(this.NowLeft, -251.5f, 0f);
			this.NowLeft += 199f;
			Transform transform = gameObject.transform;
			unitComp.MainImg = transform.GetChild(1).GetComponent<Image>();
			unitComp.SA2 = transform.GetChild(1).GetComponent<UISpritesArray>();
			transform.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			unitComp.AllyRankImg = transform.GetChild(11).GetChild(0).GetComponent<Image>();
			unitComp.AllyRankImg.transform.parent.gameObject.SetActive(true);
			this.GM.SetAllyWarRankImage(unitComp.AllyRankImg, this.AM.AW_Rank);
			unitComp.AllyRankText = transform.GetChild(11).GetChild(0).GetChild(0).GetComponent<UIText>();
			unitComp.AllyRankText.font = this.tmpFont;
			unitComp.AllyRankTextStr = StringManager.Instance.SpawnString(30);
			unitComp.AllyRankTextStr.Length = 0;
			int num = (int)((this.AM.AW_Rank <= 0) ? 1 : this.AM.AW_Rank);
			unitComp.AllyRankTextStr.IntToFormat((long)num, 1, false);
			unitComp.AllyRankTextStr.AppendFormat("{0}");
			unitComp.AllyRankText.text = unitComp.AllyRankTextStr.ToString();
			unitComp.AllyRankText.gameObject.SetActive(true);
			if (this.AM.AW_Rank >= 21 && this.AM.AW_Rank <= 25)
			{
				unitComp.AllyRankText.rectTransform.anchoredPosition = new Vector2(0f, 0f);
			}
			else
			{
				unitComp.AllyRankText.rectTransform.anchoredPosition = new Vector2(0f, 5f);
			}
			Transform child = transform.GetChild(2);
			unitComp.ScoreGO = child.gameObject;
			unitComp.SliderNormal = new Image[3];
			unitComp.SliderFlash = new Image[3];
			unitComp.SliderNormal[0] = child.GetChild(2).GetComponent<Image>();
			unitComp.SliderNormal[1] = child.GetChild(3).GetComponent<Image>();
			unitComp.SliderNormal[2] = child.GetChild(4).GetComponent<Image>();
			unitComp.SliderFlash[0] = child.GetChild(5).GetComponent<Image>();
			unitComp.SliderFlash[1] = child.GetChild(6).GetComponent<Image>();
			unitComp.SliderFlash[2] = child.GetChild(7).GetComponent<Image>();
			child.gameObject.SetActive(false);
			unitComp.NameText = transform.GetChild(3).GetComponent<UIText>();
			unitComp.NameText.font = this.tmpFont;
			unitComp.NameText.text = this.DM.mStringTable.GetStringByID((uint)allianceWarData.Name);
			unitComp.RewardText = transform.GetChild(4).GetComponent<UIText>();
			unitComp.RewardText.font = this.tmpFont;
			unitComp.RewardText.enabled = false;
			unitComp.InfoText = transform.GetChild(5).GetComponent<UIText>();
			unitComp.InfoText.font = this.tmpFont;
			unitComp.InfoText.rectTransform.sizeDelta += new Vector2(0f, 30f);
			unitComp.BtnText1 = transform.GetChild(6).GetComponent<UIText>();
			unitComp.BtnText1.font = this.tmpFont;
			unitComp.BtnText2 = transform.GetChild(7).GetComponent<UIText>();
			unitComp.BtnText2.font = this.tmpFont;
			unitComp.FlashGO = gameObject.transform.GetChild(8).gameObject;
			this.AWObj = unitComp;
			this.SetText(index, -1);
			this.SetMiddleText(index, -1);
			this.SetBackImg(index, -1);
			this.SetMainImg(index, -1);
			this.CheckAWShowHint();
		}
		else if (index == 213)
		{
			ActivityDataType activityDataType3 = this.AM.FIFAData[index - 211];
			UIButton component11 = gameObject.GetComponent<UIButton>();
			component11.m_BtnID2 = 17;
			component11.m_BtnID3 = index;
			component11.m_Handler = this;
			unitComp.SA = gameObject.GetComponent<UISpritesArray>();
			unitComp.mRC = gameObject.GetComponent<RectTransform>();
			unitComp.mRC.anchoredPosition = new Vector3(this.NowLeft, -251.5f, 0f);
			this.NowLeft += 199f;
			Transform transform = gameObject.transform;
			if (activityDataType3.ActiveType == EActivityType.EAT_FIFA_KVK)
			{
				transform.GetChild(0).gameObject.SetActive(true);
			}
			unitComp.MainImg = transform.GetChild(1).GetComponent<Image>();
			unitComp.SA2 = transform.GetChild(1).GetComponent<UISpritesArray>();
			transform.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			Transform child = transform.GetChild(2);
			unitComp.ScoreGO = child.gameObject;
			unitComp.SliderNormal = new Image[3];
			unitComp.SliderFlash = new Image[3];
			unitComp.SliderNormal[0] = child.GetChild(2).GetComponent<Image>();
			unitComp.SliderNormal[1] = child.GetChild(3).GetComponent<Image>();
			unitComp.SliderNormal[2] = child.GetChild(4).GetComponent<Image>();
			unitComp.SliderFlash[0] = child.GetChild(5).GetComponent<Image>();
			unitComp.SliderFlash[1] = child.GetChild(6).GetComponent<Image>();
			unitComp.SliderFlash[2] = child.GetChild(7).GetComponent<Image>();
			child.gameObject.SetActive(false);
			unitComp.NameText = transform.GetChild(3).GetComponent<UIText>();
			unitComp.NameText.font = this.tmpFont;
			unitComp.NameText.text = this.DM.mStringTable.GetStringByID((uint)activityDataType3.Name);
			unitComp.RewardText = transform.GetChild(4).GetComponent<UIText>();
			unitComp.RewardText.font = this.tmpFont;
			unitComp.RewardText.enabled = false;
			unitComp.InfoText = transform.GetChild(5).GetComponent<UIText>();
			unitComp.InfoText.font = this.tmpFont;
			unitComp.InfoText.rectTransform.sizeDelta += new Vector2(0f, 30f);
			unitComp.InfoText.text = "test middle text";
			unitComp.BtnText1 = transform.GetChild(6).GetComponent<UIText>();
			unitComp.BtnText1.font = this.tmpFont;
			unitComp.BtnText2 = transform.GetChild(7).GetComponent<UIText>();
			unitComp.BtnText2.font = this.tmpFont;
			unitComp.FlashGO = gameObject.transform.GetChild(8).gameObject;
			this.FIFAObj[index - 211] = unitComp;
			this.SetText(index, -1);
			this.SetMiddleText(index, -1);
			this.SetBackImg(index, -1);
			this.SetMainImg(index, -1);
			this.CheckFIFAShowHint();
		}
		else if (index >= 211 && index <= 212)
		{
			ActivityDataType activityDataType4 = this.AM.FIFAData[index - 211];
			UIButton component12 = gameObject.GetComponent<UIButton>();
			component12.m_BtnID2 = 17;
			component12.m_BtnID3 = index;
			component12.m_Handler = this;
			unitComp.SA = gameObject.GetComponent<UISpritesArray>();
			unitComp.mRC = gameObject.GetComponent<RectTransform>();
			unitComp.mRC.anchoredPosition = new Vector3(this.NowLeft, -251.5f, 0f);
			this.NowLeft += 199f;
			Transform transform = gameObject.transform;
			if (activityDataType4.ActiveType == EActivityType.EAT_FIFA_KVK)
			{
				transform.GetChild(0).gameObject.SetActive(true);
			}
			unitComp.MainImg = transform.GetChild(1).GetComponent<Image>();
			unitComp.SA2 = transform.GetChild(1).GetComponent<UISpritesArray>();
			transform.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			Transform child = transform.GetChild(2);
			unitComp.ScoreGO = child.gameObject;
			unitComp.SliderNormal = new Image[3];
			unitComp.SliderFlash = new Image[3];
			unitComp.SliderNormal[0] = child.GetChild(2).GetComponent<Image>();
			unitComp.SliderNormal[1] = child.GetChild(3).GetComponent<Image>();
			unitComp.SliderNormal[2] = child.GetChild(4).GetComponent<Image>();
			unitComp.SliderFlash[0] = child.GetChild(5).GetComponent<Image>();
			unitComp.SliderFlash[1] = child.GetChild(6).GetComponent<Image>();
			unitComp.SliderFlash[2] = child.GetChild(7).GetComponent<Image>();
			unitComp.NameText = transform.GetChild(3).GetComponent<UIText>();
			unitComp.NameText.font = this.tmpFont;
			unitComp.NameText.text = this.DM.mStringTable.GetStringByID((uint)activityDataType4.Name);
			unitComp.RewardText = transform.GetChild(4).GetComponent<UIText>();
			unitComp.RewardText.font = this.tmpFont;
			unitComp.InfoText = transform.GetChild(5).GetComponent<UIText>();
			unitComp.InfoText.font = this.tmpFont;
			unitComp.BtnText1 = transform.GetChild(6).GetComponent<UIText>();
			unitComp.BtnText1.font = this.tmpFont;
			unitComp.BtnText2 = transform.GetChild(7).GetComponent<UIText>();
			unitComp.BtnText2.font = this.tmpFont;
			this.FIFAObj[index - 211] = unitComp;
			this.SetText(index, -1);
			this.SetBackImg(index, -1);
			this.SetMainImg(index, -1);
		}
		else
		{
			ActivityDataType activityDataType5 = this.AM.ActivityData[index];
			UIButton component13 = gameObject.GetComponent<UIButton>();
			component13.m_BtnID2 = 1;
			component13.m_BtnID3 = index;
			component13.m_Handler = this;
			unitComp.SA = gameObject.GetComponent<UISpritesArray>();
			unitComp.mRC = gameObject.GetComponent<RectTransform>();
			unitComp.mRC.anchoredPosition = new Vector3(this.NowLeft, -251.5f, 0f);
			this.NowLeft += 199f;
			Transform transform = gameObject.transform;
			unitComp.MainImg = transform.GetChild(1).GetComponent<Image>();
			unitComp.SA2 = transform.GetChild(1).GetComponent<UISpritesArray>();
			transform.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			Transform child = transform.GetChild(2);
			unitComp.ScoreGO = child.gameObject;
			unitComp.SliderNormal = new Image[3];
			unitComp.SliderFlash = new Image[3];
			unitComp.SliderNormal[0] = child.GetChild(2).GetComponent<Image>();
			unitComp.SliderNormal[1] = child.GetChild(3).GetComponent<Image>();
			unitComp.SliderNormal[2] = child.GetChild(4).GetComponent<Image>();
			unitComp.SliderFlash[0] = child.GetChild(5).GetComponent<Image>();
			unitComp.SliderFlash[1] = child.GetChild(6).GetComponent<Image>();
			unitComp.SliderFlash[2] = child.GetChild(7).GetComponent<Image>();
			unitComp.NameText = transform.GetChild(3).GetComponent<UIText>();
			unitComp.NameText.font = this.tmpFont;
			unitComp.NameText.text = this.DM.mStringTable.GetStringByID((uint)activityDataType5.Name);
			unitComp.RewardText = transform.GetChild(4).GetComponent<UIText>();
			unitComp.RewardText.font = this.tmpFont;
			unitComp.InfoText = transform.GetChild(5).GetComponent<UIText>();
			unitComp.InfoText.font = this.tmpFont;
			unitComp.BtnText1 = transform.GetChild(6).GetComponent<UIText>();
			unitComp.BtnText1.font = this.tmpFont;
			unitComp.BtnText2 = transform.GetChild(7).GetComponent<UIText>();
			unitComp.BtnText2.font = this.tmpFont;
			this.AllObject.Add(unitComp);
			this.SetText(index, -1);
			this.SetBackImg(index, -1);
			this.SetMainImg(index, -1);
		}
		this.ContentRC.sizeDelta += new Vector2(199f, 0f);
	}

	// Token: 0x06000D51 RID: 3409 RVA: 0x0013FB34 File Offset: 0x0013DD34
	private void SetMainImg(int index, int index2 = -1)
	{
		if (index == 254 || index == 255)
		{
			bool flag = index == 254;
			SPActivityDataType spactivityDataType = (!flag) ? this.AM.SPActivityData[index2] : this.AM.CSActivityData[index2];
			UnitComp3 unitComp = (!flag) ? this.SPObj[index2] : this.CSObj[index2];
			if (unitComp == null)
			{
				return;
			}
			if (this.AM.bDownLoadPic1)
			{
				if (this.AM.bUpDatePic1)
				{
					this.AM.m_ActivityListAsset.UnloadAsset();
					this.AM.bUpDatePic1 = false;
				}
				if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
				{
					this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
				}
				unitComp.MainImg.sprite = this.AM.LoadActivityListSprite(spactivityDataType.DetailPic);
				if (unitComp.MainImg.sprite == null)
				{
					unitComp.MainImg.sprite = this.AM.LoadActivityListSprite(0);
				}
				unitComp.MainImg.material = this.AM.GetActivityListMaterial();
				if (this.AM.m_ActivityListAsset.m_Material == null || unitComp.MainImg.sprite == null)
				{
					unitComp.MainImg.enabled = false;
				}
				else
				{
					unitComp.MainImg.enabled = true;
				}
			}
			else
			{
				unitComp.MainImg.enabled = false;
			}
		}
		else if (index == 253)
		{
			SPActivityDataType fbactivityData = this.AM.FBActivityData;
			UnitComp3 fbobj = this.FBObj;
			if (fbobj == null)
			{
				return;
			}
			if (this.AM.bDownLoadPic1)
			{
				if (this.AM.bUpDatePic1)
				{
					this.AM.m_ActivityListAsset.UnloadAsset();
					this.AM.bUpDatePic1 = false;
				}
				if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
				{
					this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
				}
				fbobj.MainImg.sprite = this.AM.LoadActivityListSprite(fbactivityData.DetailPic);
				if (fbobj.MainImg.sprite == null)
				{
					fbobj.MainImg.sprite = this.AM.LoadActivityListSprite(0);
				}
				fbobj.MainImg.material = this.AM.GetActivityListMaterial();
				if (this.AM.m_ActivityListAsset.m_Material == null || fbobj.MainImg.sprite == null)
				{
					fbobj.MainImg.enabled = false;
				}
				else
				{
					fbobj.MainImg.enabled = true;
				}
			}
			else
			{
				fbobj.MainImg.enabled = false;
			}
		}
		else if (index >= 201 && index <= 205)
		{
			index -= 201;
			UnitComp3 unitComp2 = this.KVKObj[index];
			if (unitComp2 == null)
			{
				return;
			}
			ActivityDataType activityDataType = this.AM.KvKActivityData[index];
			if (this.AM.bDownLoadPic1)
			{
				if (this.AM.bUpDatePic1)
				{
					this.AM.m_ActivityListAsset.UnloadAsset();
					this.AM.bUpDatePic1 = false;
				}
				if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
				{
					this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
				}
				unitComp2.MainImg.sprite = this.AM.LoadActivityListSprite(activityDataType.Pic);
				if (unitComp2.MainImg.sprite == null)
				{
					unitComp2.MainImg.sprite = this.AM.LoadActivityListSprite(0);
				}
				unitComp2.MainImg.material = this.AM.GetActivityListMaterial();
				if (this.AM.m_ActivityListAsset.m_Material == null || unitComp2.MainImg.sprite == null)
				{
					unitComp2.MainImg.enabled = false;
				}
				else
				{
					unitComp2.MainImg.enabled = true;
				}
			}
			else
			{
				unitComp2.MainImg.enabled = false;
			}
		}
		else if (index == 206)
		{
			UnitComp3 amobj = this.AMObj;
			if (amobj == null)
			{
				return;
			}
			ActivityDataType allyMobilizationData = this.AM.AllyMobilizationData;
			if (this.AM.bDownLoadPic1)
			{
				if (this.AM.bUpDatePic1)
				{
					this.AM.m_ActivityListAsset.UnloadAsset();
					this.AM.bUpDatePic1 = false;
				}
				if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
				{
					this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
				}
				amobj.MainImg.sprite = this.AM.LoadActivityListSprite(allyMobilizationData.Pic);
				if (amobj.MainImg.sprite == null)
				{
					amobj.MainImg.sprite = this.AM.LoadActivityListSprite(0);
				}
				amobj.MainImg.material = this.AM.GetActivityListMaterial();
				if (this.AM.m_ActivityListAsset.m_Material == null || amobj.MainImg.sprite == null)
				{
					amobj.MainImg.enabled = false;
				}
				else
				{
					amobj.MainImg.enabled = true;
				}
			}
			else
			{
				amobj.MainImg.enabled = false;
			}
		}
		else if (index == 207)
		{
			UnitComp3 kowobj = this.KOWObj;
			if (kowobj == null)
			{
				return;
			}
			ActivityDataType kowdata = this.AM.KOWData;
			if (this.AM.bDownLoadPic1)
			{
				if (this.AM.bUpDatePic1)
				{
					this.AM.m_ActivityListAsset.UnloadAsset();
					this.AM.bUpDatePic1 = false;
				}
				if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
				{
					this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
				}
				kowobj.MainImg.sprite = this.AM.LoadActivityListSprite(kowdata.Pic);
				if (kowobj.MainImg.sprite == null)
				{
					kowobj.MainImg.sprite = this.AM.LoadActivityListSprite(0);
				}
				kowobj.MainImg.material = this.AM.GetActivityListMaterial();
				if (this.AM.m_ActivityListAsset.m_Material == null || kowobj.MainImg.sprite == null)
				{
					kowobj.MainImg.enabled = false;
				}
				else
				{
					kowobj.MainImg.enabled = true;
				}
			}
			else
			{
				kowobj.MainImg.enabled = false;
			}
		}
		else if (index == 208)
		{
			UnitComp3 sumObj = this.SumObj;
			if (sumObj == null)
			{
				return;
			}
			ActivityDataType allianceSummonData = this.AM.AllianceSummonData;
			if (this.AM.bDownLoadPic1)
			{
				if (this.AM.bUpDatePic1)
				{
					this.AM.m_ActivityListAsset.UnloadAsset();
					this.AM.bUpDatePic1 = false;
				}
				if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
				{
					this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
				}
				sumObj.MainImg.sprite = this.AM.LoadActivityListSprite(allianceSummonData.Pic);
				if (sumObj.MainImg.sprite == null)
				{
					sumObj.MainImg.sprite = this.AM.LoadActivityListSprite(0);
				}
				sumObj.MainImg.material = this.AM.GetActivityListMaterial();
				if (this.AM.m_ActivityListAsset.m_Material == null || sumObj.MainImg.sprite == null)
				{
					sumObj.MainImg.enabled = false;
				}
				else
				{
					sumObj.MainImg.enabled = true;
				}
			}
			else
			{
				sumObj.MainImg.enabled = false;
			}
		}
		else if (index == 209)
		{
			UnitComp3 nwobj = this.NWObj;
			if (nwobj == null)
			{
				return;
			}
			ActivityDataType nobilityActivityData = this.AM.NobilityActivityData;
			if (this.AM.bDownLoadPic1)
			{
				if (this.AM.bUpDatePic1)
				{
					this.AM.m_ActivityListAsset.UnloadAsset();
					this.AM.bUpDatePic1 = false;
				}
				if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
				{
					this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
				}
				nwobj.MainImg.sprite = this.AM.LoadActivityListSprite(nobilityActivityData.Pic);
				if (nwobj.MainImg.sprite == null)
				{
					nwobj.MainImg.sprite = this.AM.LoadActivityListSprite(0);
				}
				nwobj.MainImg.material = this.AM.GetActivityListMaterial();
				if (this.AM.m_ActivityListAsset.m_Material == null || nwobj.MainImg.sprite == null)
				{
					nwobj.MainImg.enabled = false;
				}
				else
				{
					nwobj.MainImg.enabled = true;
				}
			}
			else
			{
				nwobj.MainImg.enabled = false;
			}
		}
		else if (index == 210)
		{
			UnitComp3 awobj = this.AWObj;
			if (awobj == null)
			{
				return;
			}
			ActivityDataType allianceWarData = this.AM.AllianceWarData;
			if (this.AM.bDownLoadPic1)
			{
				if (this.AM.bUpDatePic1)
				{
					this.AM.m_ActivityListAsset.UnloadAsset();
					this.AM.bUpDatePic1 = false;
				}
				if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
				{
					this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
				}
				awobj.MainImg.sprite = this.AM.LoadActivityListSprite(allianceWarData.Pic);
				if (awobj.MainImg.sprite == null)
				{
					awobj.MainImg.sprite = this.AM.LoadActivityListSprite(0);
				}
				awobj.MainImg.material = this.AM.GetActivityListMaterial();
				if (this.AM.m_ActivityListAsset.m_Material == null || awobj.MainImg.sprite == null)
				{
					awobj.MainImg.enabled = false;
				}
				else
				{
					awobj.MainImg.enabled = true;
				}
			}
			else
			{
				awobj.MainImg.enabled = false;
			}
		}
		else if (index >= 211 && index <= 213)
		{
			index -= 211;
			UnitComp3 unitComp3 = this.FIFAObj[index];
			if (unitComp3 == null)
			{
				return;
			}
			ActivityDataType activityDataType2 = this.AM.FIFAData[index];
			if (this.AM.bDownLoadPic1)
			{
				if (this.AM.bUpDatePic1)
				{
					this.AM.m_ActivityListAsset.UnloadAsset();
					this.AM.bUpDatePic1 = false;
				}
				if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
				{
					this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
				}
				unitComp3.MainImg.sprite = this.AM.LoadActivityListSprite(activityDataType2.Pic);
				if (unitComp3.MainImg.sprite == null)
				{
					unitComp3.MainImg.sprite = this.AM.LoadActivityListSprite(0);
				}
				unitComp3.MainImg.material = this.AM.GetActivityListMaterial();
				if (this.AM.m_ActivityListAsset.m_Material == null || unitComp3.MainImg.sprite == null)
				{
					unitComp3.MainImg.enabled = false;
				}
				else
				{
					unitComp3.MainImg.enabled = true;
				}
			}
			else
			{
				unitComp3.MainImg.enabled = false;
			}
		}
		else
		{
			if (index < 0 || index >= this.AllObject.Count)
			{
				return;
			}
			ActivityDataType activityDataType3 = this.AM.ActivityData[index];
			UnitComp3 unitComp4 = this.AllObject[index];
			if (this.AM.bDownLoadPic1)
			{
				if (this.AM.bUpDatePic1)
				{
					this.AM.m_ActivityListAsset.UnloadAsset();
					this.AM.bUpDatePic1 = false;
				}
				if (this.AM.m_ActivityListAsset.m_AssetBundleKey == 0)
				{
					this.AM.m_ActivityListAsset.InitialAsset("UIActivityBack_1");
				}
				unitComp4.MainImg.sprite = this.AM.LoadActivityListSprite(activityDataType3.Pic);
				if (unitComp4.MainImg.sprite == null)
				{
					unitComp4.MainImg.sprite = this.AM.LoadActivityListSprite(0);
				}
				unitComp4.MainImg.material = this.AM.GetActivityListMaterial();
				if (this.AM.m_ActivityListAsset.m_Material == null || unitComp4.MainImg.sprite == null)
				{
					unitComp4.MainImg.enabled = false;
				}
				else
				{
					unitComp4.MainImg.enabled = true;
				}
			}
			else
			{
				unitComp4.MainImg.enabled = false;
			}
		}
	}

	// Token: 0x06000D52 RID: 3410 RVA: 0x00140934 File Offset: 0x0013EB34
	private void SetBackImg(int index, int index2 = -1)
	{
		if (index == 254 || index == 255)
		{
			bool flag = index == 254;
			UnitComp3 unitComp = (!flag) ? this.SPObj[index2] : this.CSObj[index2];
			if (unitComp == null)
			{
				return;
			}
			if (flag)
			{
				unitComp.BtnText1.text = this.DM.mStringTable.GetStringByID(8109u);
				unitComp.SA.SetSpriteIndex(0);
				unitComp.FlashGO.SetActive(this.AM.bShowNewCSActivity[index2]);
			}
			else
			{
				unitComp.BtnText1.text = this.DM.mStringTable.GetStringByID(8110u);
				unitComp.SA.SetSpriteIndex(1);
				unitComp.FlashGO.SetActive(this.AM.bShowNewSPActivity[index2]);
			}
		}
		else if (index == 253)
		{
			UnitComp3 fbobj = this.FBObj;
			if (fbobj == null)
			{
				return;
			}
			fbobj.SA.SetSpriteIndex(1);
		}
		else if (index >= 201 && index <= 205)
		{
			index -= 201;
			UnitComp3 unitComp2 = this.KVKObj[index];
			if (unitComp2 == null)
			{
				return;
			}
			ActivityDataType activityDataType = this.AM.KvKActivityData[index];
			if (activityDataType.EventState == EActivityState.EAS_Run)
			{
				unitComp2.BtnText1.text = this.DM.mStringTable.GetStringByID(8110u);
				unitComp2.SA.SetSpriteIndex(1);
			}
			else if (activityDataType.EventState == EActivityState.EAS_Prepare)
			{
				unitComp2.BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				unitComp2.SA.SetSpriteIndex(2);
			}
			else if (activityDataType.EventState == EActivityState.EAS_HomeEnd || activityDataType.EventState == EActivityState.EAS_HomeStart || activityDataType.EventState == EActivityState.EAS_StartRanking)
			{
				unitComp2.BtnText1.text = this.DM.mStringTable.GetStringByID(9810u);
				unitComp2.SA.SetSpriteIndex(2);
			}
			else if (activityDataType.EventState == EActivityState.EAS_ReplayRanking)
			{
				unitComp2.BtnText1.text = this.DM.mStringTable.GetStringByID(9819u);
				unitComp2.SA.SetSpriteIndex(2);
			}
			else
			{
				unitComp2.BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				unitComp2.SA.SetSpriteIndex(3);
			}
			if (activityDataType.EventState == EActivityState.EAS_ReplayRanking)
			{
				unitComp2.BtnText1.rectTransform.sizeDelta = new Vector2(unitComp2.BtnText1.rectTransform.sizeDelta.x, 55f);
			}
			else
			{
				unitComp2.BtnText1.rectTransform.sizeDelta = new Vector2(unitComp2.BtnText1.rectTransform.sizeDelta.x, 31.5f);
			}
		}
		else if (index == 206)
		{
			UnitComp3 amobj = this.AMObj;
			if (amobj == null)
			{
				return;
			}
			ActivityDataType allyMobilizationData = this.AM.AllyMobilizationData;
			if (allyMobilizationData.EventState == EActivityState.EAS_Run)
			{
				amobj.BtnText1.text = this.DM.mStringTable.GetStringByID(8110u);
				amobj.SA.SetSpriteIndex(1);
			}
			else if (allyMobilizationData.EventState == EActivityState.EAS_Prepare)
			{
				amobj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				amobj.SA.SetSpriteIndex(2);
			}
			else if (allyMobilizationData.EventState == EActivityState.EAS_ReplayRanking)
			{
				amobj.BtnText1.text = this.DM.mStringTable.GetStringByID(747u);
				amobj.SA.SetSpriteIndex(2);
			}
			else
			{
				amobj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				amobj.SA.SetSpriteIndex(3);
			}
			if (allyMobilizationData.EventState == EActivityState.EAS_ReplayRanking)
			{
				amobj.BtnText1.rectTransform.sizeDelta = new Vector2(amobj.BtnText1.rectTransform.sizeDelta.x, 55f);
			}
			else
			{
				amobj.BtnText1.rectTransform.sizeDelta = new Vector2(amobj.BtnText1.rectTransform.sizeDelta.x, 31.5f);
			}
		}
		else if (index == 207)
		{
			UnitComp3 kowobj = this.KOWObj;
			if (kowobj == null)
			{
				return;
			}
			ActivityDataType kowdata = this.AM.KOWData;
			if (kowdata.EventState == EActivityState.EAS_Run)
			{
				kowobj.BtnText1.text = this.DM.mStringTable.GetStringByID(8110u);
				kowobj.SA.SetSpriteIndex(1);
			}
			else if (kowdata.EventState == EActivityState.EAS_Prepare)
			{
				kowobj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				kowobj.SA.SetSpriteIndex(2);
			}
			else if (kowdata.EventState == EActivityState.EAS_ReplayRanking)
			{
				kowobj.BtnText1.text = this.DM.mStringTable.GetStringByID(10010u);
				kowobj.SA.SetSpriteIndex(2);
			}
			else
			{
				kowobj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				kowobj.SA.SetSpriteIndex(3);
			}
			if (kowdata.EventState == EActivityState.EAS_ReplayRanking)
			{
				kowobj.BtnText1.rectTransform.sizeDelta = new Vector2(kowobj.BtnText1.rectTransform.sizeDelta.x, 55f);
			}
			else
			{
				kowobj.BtnText1.rectTransform.sizeDelta = new Vector2(kowobj.BtnText1.rectTransform.sizeDelta.x, 31.5f);
			}
		}
		else if (index == 208)
		{
			UnitComp3 sumObj = this.SumObj;
			if (sumObj == null)
			{
				return;
			}
			ActivityDataType allianceSummonData = this.AM.AllianceSummonData;
			if (allianceSummonData.EventState == EActivityState.EAS_Run)
			{
				sumObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8110u);
				sumObj.SA.SetSpriteIndex(1);
			}
			else if (allianceSummonData.EventState == EActivityState.EAS_Prepare)
			{
				sumObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				sumObj.SA.SetSpriteIndex(2);
			}
			else if (allianceSummonData.EventState == EActivityState.EAS_ReplayRanking)
			{
				sumObj.BtnText1.text = this.DM.mStringTable.GetStringByID(14520u);
				sumObj.SA.SetSpriteIndex(2);
			}
			else
			{
				sumObj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				sumObj.SA.SetSpriteIndex(3);
			}
			if (allianceSummonData.EventState == EActivityState.EAS_ReplayRanking)
			{
				sumObj.BtnText1.rectTransform.sizeDelta = new Vector2(sumObj.BtnText1.rectTransform.sizeDelta.x, 55f);
			}
			else
			{
				sumObj.BtnText1.rectTransform.sizeDelta = new Vector2(sumObj.BtnText1.rectTransform.sizeDelta.x, 31.5f);
			}
			bool flag2 = this.AM.AllianceSummon_SummonData.MonsterEndTime > 0L;
			if (this.AM.AllianceSummon_SummonData.MonsterID > 0 && (flag2 || (this.AM.AllianceSummon_SummonData.CostPoint > 0 && this.AM.AllianceSummon_SummonData.SummonPoint / this.AM.AllianceSummon_SummonData.CostPoint >= 1)))
			{
				sumObj.FlashGO.SetActive(true);
			}
			else
			{
				sumObj.FlashGO.SetActive(false);
			}
		}
		else if (index == 209)
		{
			UnitComp3 nwobj = this.NWObj;
			if (nwobj == null)
			{
				return;
			}
			ActivityDataType nobilityActivityData = this.AM.NobilityActivityData;
			if (nobilityActivityData.EventState == EActivityState.EAS_Run)
			{
				nwobj.BtnText1.text = this.DM.mStringTable.GetStringByID(8110u);
				nwobj.SA.SetSpriteIndex(1);
			}
			else if (nobilityActivityData.EventState == EActivityState.EAS_Prepare)
			{
				nwobj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				nwobj.SA.SetSpriteIndex(2);
			}
			else if (nobilityActivityData.EventState == EActivityState.EAS_ReplayRanking)
			{
				nwobj.BtnText1.text = this.DM.mStringTable.GetStringByID(5042u);
				nwobj.SA.SetSpriteIndex(2);
			}
			else
			{
				nwobj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				nwobj.SA.SetSpriteIndex(3);
			}
			if (nobilityActivityData.EventState == EActivityState.EAS_ReplayRanking)
			{
				nwobj.BtnText1.rectTransform.sizeDelta = new Vector2(nwobj.BtnText1.rectTransform.sizeDelta.x, 55f);
			}
			else
			{
				nwobj.BtnText1.rectTransform.sizeDelta = new Vector2(nwobj.BtnText1.rectTransform.sizeDelta.x, 31.5f);
			}
		}
		else if (index == 210)
		{
			UnitComp3 awobj = this.AWObj;
			if (awobj == null)
			{
				return;
			}
			EAllianceWarState aw_State = this.AM.AW_State;
			if (aw_State == EAllianceWarState.EAWS_SignUp)
			{
				awobj.BtnText1.text = this.DM.mStringTable.GetStringByID(17001u);
				awobj.SA.SetSpriteIndex(1);
			}
			else if (aw_State == EAllianceWarState.EAWS_Prepare)
			{
				awobj.BtnText1.text = this.DM.mStringTable.GetStringByID(17030u);
				awobj.SA.SetSpriteIndex(1);
			}
			else if (aw_State == EAllianceWarState.EAWS_Run)
			{
				awobj.BtnText1.text = this.DM.mStringTable.GetStringByID(8110u);
				awobj.SA.SetSpriteIndex(1);
			}
			else if (aw_State == EAllianceWarState.EAWS_Replay)
			{
				if (this.DM.RoleAlliance.Id != 0u && this.DM.RoleAlliance.Id == this.AM.AW_SignUpAllianceID && this.AM.AW_NowAllianceEnterWar != 0 && this.AM.AW_GetGift == 0)
				{
					awobj.BtnText1.text = this.DM.mStringTable.GetStringByID(747u);
				}
				else
				{
					awobj.BtnText1.text = this.DM.mStringTable.GetStringByID(14608u);
				}
				awobj.SA.SetSpriteIndex(2);
				awobj.BtnText1.rectTransform.sizeDelta = new Vector2(awobj.BtnText1.rectTransform.sizeDelta.x, 55f);
			}
			else
			{
				awobj.BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				awobj.SA.SetSpriteIndex(3);
			}
		}
		else if (index >= 211 && index <= 213)
		{
			index -= 211;
			UnitComp3 unitComp3 = this.FIFAObj[index];
			if (unitComp3 == null)
			{
				return;
			}
			ActivityDataType activityDataType2 = this.AM.FIFAData[index];
			if (activityDataType2.EventState == EActivityState.EAS_Run)
			{
				unitComp3.BtnText1.text = this.DM.mStringTable.GetStringByID(8110u);
				unitComp3.SA.SetSpriteIndex(1);
			}
			else if (activityDataType2.EventState == EActivityState.EAS_Prepare)
			{
				unitComp3.BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				unitComp3.SA.SetSpriteIndex(2);
			}
			else if (activityDataType2.EventState == EActivityState.EAS_HomeEnd || activityDataType2.EventState == EActivityState.EAS_HomeStart || activityDataType2.EventState == EActivityState.EAS_StartRanking)
			{
				unitComp3.BtnText1.text = this.DM.mStringTable.GetStringByID(9810u);
				unitComp3.SA.SetSpriteIndex(2);
			}
			else if (activityDataType2.EventState == EActivityState.EAS_ReplayRanking)
			{
				if (activityDataType2.ActiveType == EActivityType.EAT_FIFA_KVK)
				{
					unitComp3.BtnText1.text = this.DM.mStringTable.GetStringByID(9819u);
				}
				else
				{
					unitComp3.BtnText1.text = this.DM.mStringTable.GetStringByID(5042u);
				}
				unitComp3.SA.SetSpriteIndex(2);
			}
			else
			{
				unitComp3.BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				unitComp3.SA.SetSpriteIndex(3);
			}
			if (activityDataType2.EventState == EActivityState.EAS_ReplayRanking)
			{
				unitComp3.BtnText1.rectTransform.sizeDelta = new Vector2(unitComp3.BtnText1.rectTransform.sizeDelta.x, 55f);
			}
			else
			{
				unitComp3.BtnText1.rectTransform.sizeDelta = new Vector2(unitComp3.BtnText1.rectTransform.sizeDelta.x, 31.5f);
			}
		}
		else
		{
			if (index < 0 || index >= this.AllObject.Count)
			{
				return;
			}
			ActivityDataType activityDataType3 = this.AM.ActivityData[index];
			if (activityDataType3.EventState == EActivityState.EAS_Run)
			{
				this.AllObject[index].BtnText1.text = this.DM.mStringTable.GetStringByID(8110u);
				this.AllObject[index].SA.SetSpriteIndex(1);
			}
			else if (activityDataType3.EventState == EActivityState.EAS_Prepare)
			{
				this.AllObject[index].BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				this.AllObject[index].SA.SetSpriteIndex(2);
			}
			else
			{
				this.AllObject[index].BtnText1.text = this.DM.mStringTable.GetStringByID(8111u);
				this.AllObject[index].SA.SetSpriteIndex(3);
			}
		}
	}

	// Token: 0x06000D53 RID: 3411 RVA: 0x00141870 File Offset: 0x0013FA70
	private void SetText(int index, int index2 = -1)
	{
		this.SetName(index, index2);
		this.SetScoreText(index);
		this.SetTimeText(index, index2);
	}

	// Token: 0x06000D54 RID: 3412 RVA: 0x0014188C File Offset: 0x0013FA8C
	private void SetName(int index, int index2 = -1)
	{
		if (index == 254 || index == 255)
		{
			bool flag = index == 254;
			UnitComp3 unitComp = (!flag) ? this.SPObj[index2] : this.CSObj[index2];
			if (unitComp == null)
			{
				return;
			}
			SPActivityDataType spactivityDataType = (!flag) ? this.AM.SPActivityData[index2] : this.AM.CSActivityData[index2];
			unitComp.NameText.text = this.DM.mStringTable.GetStringByID((uint)spactivityDataType.Name);
		}
		else if (index == 253)
		{
			UnitComp3 fbobj = this.FBObj;
			if (fbobj == null)
			{
				return;
			}
			SPActivityDataType fbactivityData = this.AM.FBActivityData;
			fbobj.NameText.text = this.DM.mStringTable.GetStringByID((uint)fbactivityData.Name);
		}
		else if (index >= 201 && index <= 205)
		{
			index -= 201;
			UnitComp3 unitComp2 = this.KVKObj[index];
			if (unitComp2 == null)
			{
				return;
			}
			unitComp2.NameText.text = this.DM.mStringTable.GetStringByID((uint)this.AM.KvKActivityData[index].Name);
		}
		else if (index == 206)
		{
			UnitComp3 amobj = this.AMObj;
			if (amobj == null)
			{
				return;
			}
			amobj.NameText.text = this.DM.mStringTable.GetStringByID((uint)this.AM.AllyMobilizationData.Name);
		}
		else if (index == 207)
		{
			UnitComp3 kowobj = this.KOWObj;
			if (kowobj == null)
			{
				return;
			}
			kowobj.NameText.text = this.DM.mStringTable.GetStringByID((uint)this.AM.KOWData.Name);
		}
		else if (index == 208)
		{
			UnitComp3 sumObj = this.SumObj;
			if (sumObj == null)
			{
				return;
			}
			sumObj.NameText.text = this.DM.mStringTable.GetStringByID((uint)this.AM.AllianceSummonData.Name);
		}
		else if (index == 209)
		{
			UnitComp3 nwobj = this.NWObj;
			if (nwobj == null)
			{
				return;
			}
			nwobj.NameText.text = this.DM.mStringTable.GetStringByID((uint)this.AM.NobilityActivityData.Name);
		}
		else if (index == 210)
		{
			UnitComp3 awobj = this.AWObj;
			if (awobj == null)
			{
				return;
			}
			awobj.NameText.text = this.DM.mStringTable.GetStringByID((uint)this.AM.AllianceWarData.Name);
		}
		else if (index >= 211 && index <= 213)
		{
			index -= 211;
			UnitComp3 unitComp3 = this.FIFAObj[index];
			if (unitComp3 == null)
			{
				return;
			}
			unitComp3.NameText.text = this.DM.mStringTable.GetStringByID((uint)this.AM.FIFAData[index].Name);
		}
		else
		{
			if (index < 0 || index >= this.AllObject.Count)
			{
				return;
			}
			this.AllObject[index].NameText.text = this.DM.mStringTable.GetStringByID((uint)this.AM.ActivityData[index].Name);
		}
	}

	// Token: 0x06000D55 RID: 3413 RVA: 0x00141C0C File Offset: 0x0013FE0C
	private void SetScoreText(int index)
	{
		if (index >= 201 && index <= 204)
		{
			index -= 201;
			UnitComp3 unitComp = this.KVKObj[index];
			if (unitComp == null)
			{
				return;
			}
			ActivityDataType activityDataType = this.AM.KvKActivityData[index];
			if (activityDataType.EventState == EActivityState.EAS_None)
			{
				unitComp.InfoText.text = this.DM.mStringTable.GetStringByID(8112u);
				unitComp.RewardText.enabled = false;
				if (unitComp.ScoreGO.activeInHierarchy)
				{
					unitComp.ScoreGO.SetActive(false);
				}
			}
			else
			{
				unitComp.RewardText.enabled = true;
				if (!unitComp.ScoreGO.activeInHierarchy)
				{
					unitComp.ScoreGO.SetActive(true);
				}
				unitComp.RewardStr.Length = 0;
				if (activityDataType.KVKActiveType != EKVKActivityType.EKAT_KvKAllianceEvent)
				{
					unitComp.RewardStr.IntToFormat((long)((ulong)activityDataType.EventAllDegreePrizeWorthData.CrystalPrice), 1, true);
					unitComp.RewardStr.AppendFormat(this.DM.mStringTable.GetStringByID(8113u));
				}
				unitComp.RewardText.text = unitComp.RewardStr.ToString();
				unitComp.RewardText.SetAllDirty();
				unitComp.RewardText.cachedTextGenerator.Invalidate();
				for (int i = 0; i < 3; i++)
				{
					unitComp.SliderNormal[i].fillAmount = 0f;
					unitComp.SliderFlash[i].gameObject.SetActive(false);
				}
				int num = 0;
				for (int j = 0; j < 3; j++)
				{
					if (activityDataType.EventScore >= (ulong)activityDataType.RequireScore[j])
					{
						num++;
					}
				}
				if (num < 3)
				{
					if (num == 0)
					{
						double num2 = activityDataType.RequireScore[num];
						if (num2 > 0.0)
						{
							unitComp.SliderNormal[num].fillAmount = (float)(activityDataType.EventScore / num2);
						}
						else
						{
							unitComp.SliderNormal[num].fillAmount = 0f;
						}
					}
					else
					{
						double num3 = activityDataType.RequireScore[num] - activityDataType.RequireScore[num - 1];
						if (num3 > 0.0)
						{
							unitComp.SliderNormal[num].fillAmount = (float)((activityDataType.EventScore - (ulong)activityDataType.RequireScore[num - 1]) / num3);
						}
						else
						{
							unitComp.SliderNormal[num].fillAmount = 0f;
						}
					}
				}
				for (int k = 0; k < num; k++)
				{
					unitComp.SliderNormal[k].fillAmount = 1f;
					unitComp.SliderFlash[k].gameObject.SetActive(true);
				}
				unitComp.InfoStr.Length = 0;
				if (num == 3)
				{
					unitComp.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8114u));
				}
				else
				{
					unitComp.InfoStr.uLongToFormat((ulong)activityDataType.RequireScore[num] - activityDataType.EventScore, 1, true);
					unitComp.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8115u));
				}
				unitComp.InfoText.text = unitComp.InfoStr.ToString();
				unitComp.InfoText.SetAllDirty();
				unitComp.InfoText.cachedTextGenerator.Invalidate();
			}
		}
		else if (index != 205 && index != 207 && index != 209 && index != 210 && index != 213 && index != 253 && index != 254 && index != 255)
		{
			if (index == 206)
			{
				UnitComp3 amobj = this.AMObj;
				if (amobj == null)
				{
					return;
				}
				ActivityDataType allyMobilizationData = this.AM.AllyMobilizationData;
				MobilizationManager instance = MobilizationManager.Instance;
				amobj.RewardStr.Length = 0;
				amobj.InfoStr.Length = 0;
				if (this.DM.RoleAlliance.Id <= 0u)
				{
					amobj.RankSlider2.gameObject.SetActive(false);
					amobj.RankSlider.fillAmount = 0f;
					StringManager.ulongToStr(amobj.RewardStr, 0UL, 1, false);
					amobj.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(689u));
				}
				else if (allyMobilizationData.EventState == EActivityState.EAS_ReplayRanking)
				{
					if (instance.AMCompleteDegree == this.DM.RoleAlliance.AMMaxDegree)
					{
						amobj.RankSlider.fillAmount = 1f;
						amobj.RankSlider2.gameObject.SetActive(true);
						StringManager.ulongToStr(amobj.RewardStr, (ulong)instance.AMCompleteDegree, 1, false);
					}
					else
					{
						amobj.RankSlider2.gameObject.SetActive(false);
						amobj.RankSlider.fillAmount = this.GetFillAmount();
						StringManager.ulongToStr(amobj.RewardStr, (ulong)instance.AMCompleteDegree, 1, false);
					}
				}
				else if (instance.AMCompleteDegree == this.DM.RoleAlliance.AMMaxDegree)
				{
					amobj.RankSlider.fillAmount = 1f;
					amobj.RankSlider2.gameObject.SetActive(true);
					StringManager.ulongToStr(amobj.RewardStr, (ulong)instance.AMCompleteDegree, 1, false);
					amobj.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8114u));
				}
				else
				{
					amobj.RankSlider2.gameObject.SetActive(false);
					amobj.RankSlider.fillAmount = this.GetFillAmount();
					StringManager.ulongToStr(amobj.RewardStr, (ulong)instance.AMCompleteDegree, 1, false);
					amobj.InfoStr.uLongToFormat((ulong)(instance.CompleteScore - instance.AMScore), 1, true);
					amobj.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8115u));
				}
				amobj.RankText.text = amobj.RewardStr.ToString();
				amobj.RankText.SetAllDirty();
				amobj.RankText.cachedTextGenerator.Invalidate();
				amobj.InfoText.text = amobj.InfoStr.ToString();
				amobj.InfoText.SetAllDirty();
				amobj.InfoText.cachedTextGenerator.Invalidate();
			}
			else if (index == 208)
			{
				UnitComp3 sumObj = this.SumObj;
				if (sumObj == null)
				{
					return;
				}
				ActivityDataType allianceSummonData = this.AM.AllianceSummonData;
				if (allianceSummonData.EventState == EActivityState.EAS_None)
				{
					sumObj.InfoText.text = this.DM.mStringTable.GetStringByID(8112u);
					if (sumObj.ScoreGO.activeInHierarchy)
					{
						sumObj.ScoreGO.SetActive(false);
					}
				}
				else
				{
					if (!sumObj.ScoreGO.activeInHierarchy)
					{
						sumObj.ScoreGO.SetActive(true);
					}
					for (int l = 0; l < 3; l++)
					{
						sumObj.SliderNormal[l].fillAmount = 0f;
						sumObj.SliderFlash[l].gameObject.SetActive(false);
					}
					int num4 = 0;
					for (int m = 0; m < 3; m++)
					{
						if (allianceSummonData.EventScore >= (ulong)allianceSummonData.RequireScore[m])
						{
							num4++;
						}
					}
					if (num4 < 3)
					{
						if (num4 == 0)
						{
							double num5 = allianceSummonData.RequireScore[num4];
							if (num5 > 0.0)
							{
								sumObj.SliderNormal[num4].fillAmount = (float)(allianceSummonData.EventScore / num5);
							}
							else
							{
								sumObj.SliderNormal[num4].fillAmount = 0f;
							}
						}
						else
						{
							double num6 = allianceSummonData.RequireScore[num4] - allianceSummonData.RequireScore[num4 - 1];
							if (num6 > 0.0)
							{
								sumObj.SliderNormal[num4].fillAmount = (float)((allianceSummonData.EventScore - (ulong)allianceSummonData.RequireScore[num4 - 1]) / num6);
							}
							else
							{
								sumObj.SliderNormal[num4].fillAmount = 0f;
							}
						}
					}
					for (int n = 0; n < num4; n++)
					{
						sumObj.SliderNormal[n].fillAmount = 1f;
						sumObj.SliderFlash[n].gameObject.SetActive(true);
					}
					sumObj.InfoStr.Length = 0;
					if (this.DM.RoleAlliance.Id <= 0u)
					{
						sumObj.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(689u));
					}
					else if (allianceSummonData.EventState != EActivityState.EAS_ReplayRanking)
					{
						if (num4 == 3)
						{
							sumObj.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8114u));
						}
						else
						{
							sumObj.InfoStr.uLongToFormat((ulong)allianceSummonData.RequireScore[num4] - allianceSummonData.EventScore, 1, true);
							sumObj.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8115u));
						}
					}
					sumObj.InfoText.text = sumObj.InfoStr.ToString();
					sumObj.InfoText.SetAllDirty();
					sumObj.InfoText.cachedTextGenerator.Invalidate();
				}
			}
			else if (index >= 211 && index <= 212)
			{
				index -= 211;
				UnitComp3 unitComp2 = this.FIFAObj[index];
				if (unitComp2 == null)
				{
					return;
				}
				ActivityDataType activityDataType2 = this.AM.FIFAData[index];
				if (activityDataType2.EventState == EActivityState.EAS_None)
				{
					unitComp2.InfoText.text = this.DM.mStringTable.GetStringByID(8112u);
					unitComp2.RewardText.enabled = false;
					if (unitComp2.ScoreGO.activeInHierarchy)
					{
						unitComp2.ScoreGO.SetActive(false);
					}
				}
				else
				{
					unitComp2.RewardText.enabled = true;
					if (!unitComp2.ScoreGO.activeInHierarchy)
					{
						unitComp2.ScoreGO.SetActive(true);
					}
					unitComp2.RewardStr.Length = 0;
					if (activityDataType2.FIFAActiveType != EActivityKingdomEventType.EAKET_AllianceEvent)
					{
						unitComp2.RewardStr.IntToFormat((long)((ulong)activityDataType2.EventAllDegreePrizeWorthData.CrystalPrice), 1, true);
						unitComp2.RewardStr.AppendFormat(this.DM.mStringTable.GetStringByID(8113u));
					}
					unitComp2.RewardText.text = unitComp2.RewardStr.ToString();
					unitComp2.RewardText.SetAllDirty();
					unitComp2.RewardText.cachedTextGenerator.Invalidate();
					for (int num7 = 0; num7 < 3; num7++)
					{
						unitComp2.SliderNormal[num7].fillAmount = 0f;
						unitComp2.SliderFlash[num7].gameObject.SetActive(false);
					}
					int num8 = 0;
					for (int num9 = 0; num9 < 3; num9++)
					{
						if (activityDataType2.EventScore >= (ulong)activityDataType2.RequireScore[num9])
						{
							num8++;
						}
					}
					if (num8 < 3)
					{
						if (num8 == 0)
						{
							double num10 = activityDataType2.RequireScore[num8];
							if (num10 > 0.0)
							{
								unitComp2.SliderNormal[num8].fillAmount = (float)(activityDataType2.EventScore / num10);
							}
							else
							{
								unitComp2.SliderNormal[num8].fillAmount = 0f;
							}
						}
						else
						{
							double num11 = activityDataType2.RequireScore[num8] - activityDataType2.RequireScore[num8 - 1];
							if (num11 > 0.0)
							{
								unitComp2.SliderNormal[num8].fillAmount = (float)((activityDataType2.EventScore - (ulong)activityDataType2.RequireScore[num8 - 1]) / num11);
							}
							else
							{
								unitComp2.SliderNormal[num8].fillAmount = 0f;
							}
						}
					}
					for (int num12 = 0; num12 < num8; num12++)
					{
						unitComp2.SliderNormal[num12].fillAmount = 1f;
						unitComp2.SliderFlash[num12].gameObject.SetActive(true);
					}
					unitComp2.InfoStr.Length = 0;
					if (num8 == 3)
					{
						unitComp2.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8114u));
					}
					else
					{
						unitComp2.InfoStr.uLongToFormat((ulong)activityDataType2.RequireScore[num8] - activityDataType2.EventScore, 1, true);
						unitComp2.InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8115u));
					}
					unitComp2.InfoText.text = unitComp2.InfoStr.ToString();
					unitComp2.InfoText.SetAllDirty();
					unitComp2.InfoText.cachedTextGenerator.Invalidate();
				}
			}
			else
			{
				if (index < 0 || index >= this.AllObject.Count)
				{
					return;
				}
				ActivityDataType activityDataType3 = this.AM.ActivityData[index];
				if (activityDataType3.EventState == EActivityState.EAS_None)
				{
					this.AllObject[index].InfoText.text = this.DM.mStringTable.GetStringByID(8112u);
					this.AllObject[index].RewardText.enabled = false;
					if (this.AllObject[index].ScoreGO.activeInHierarchy)
					{
						this.AllObject[index].ScoreGO.SetActive(false);
					}
				}
				else
				{
					this.AllObject[index].RewardText.enabled = true;
					if (!this.AllObject[index].ScoreGO.activeInHierarchy)
					{
						this.AllObject[index].ScoreGO.SetActive(true);
					}
					this.AllObject[index].RewardStr.Length = 0;
					this.AllObject[index].RewardStr.IntToFormat((long)((ulong)activityDataType3.EventAllDegreePrizeWorthData.CrystalPrice), 1, true);
					this.AllObject[index].RewardStr.AppendFormat(this.DM.mStringTable.GetStringByID(8113u));
					this.AllObject[index].RewardText.text = this.AllObject[index].RewardStr.ToString();
					this.AllObject[index].RewardText.SetAllDirty();
					this.AllObject[index].RewardText.cachedTextGenerator.Invalidate();
					for (int num13 = 0; num13 < 3; num13++)
					{
						this.AllObject[index].SliderNormal[num13].fillAmount = 0f;
						this.AllObject[index].SliderFlash[num13].gameObject.SetActive(false);
					}
					int num14 = 0;
					for (int num15 = 0; num15 < 3; num15++)
					{
						if (activityDataType3.EventScore >= (ulong)activityDataType3.RequireScore[num15])
						{
							num14++;
						}
					}
					if (num14 < 3)
					{
						if (num14 == 0)
						{
							double num16 = activityDataType3.RequireScore[num14];
							if (num16 > 0.0)
							{
								this.AllObject[index].SliderNormal[num14].fillAmount = (float)(activityDataType3.EventScore / num16);
							}
							else
							{
								this.AllObject[index].SliderNormal[num14].fillAmount = 0f;
							}
						}
						else
						{
							double num17 = activityDataType3.RequireScore[num14] - activityDataType3.RequireScore[num14 - 1];
							if (num17 > 0.0)
							{
								this.AllObject[index].SliderNormal[num14].fillAmount = (float)((activityDataType3.EventScore - (ulong)activityDataType3.RequireScore[num14 - 1]) / num17);
							}
							else
							{
								this.AllObject[index].SliderNormal[num14].fillAmount = 0f;
							}
						}
					}
					for (int num18 = 0; num18 < num14; num18++)
					{
						this.AllObject[index].SliderNormal[num18].fillAmount = 1f;
						this.AllObject[index].SliderFlash[num18].gameObject.SetActive(true);
					}
					this.AllObject[index].InfoStr.Length = 0;
					if (num14 == 3)
					{
						this.AllObject[index].InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8114u));
					}
					else
					{
						this.AllObject[index].InfoStr.uLongToFormat((ulong)activityDataType3.RequireScore[num14] - activityDataType3.EventScore, 1, true);
						this.AllObject[index].InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(8115u));
					}
					this.AllObject[index].InfoText.text = this.AllObject[index].InfoStr.ToString();
					this.AllObject[index].InfoText.SetAllDirty();
					this.AllObject[index].InfoText.cachedTextGenerator.Invalidate();
				}
			}
		}
	}

	// Token: 0x06000D56 RID: 3414 RVA: 0x00142DE0 File Offset: 0x00140FE0
	private void SetTimeText(int index, int index2 = -1)
	{
		if (index == 254 || index == 255)
		{
			bool flag = index == 254;
			SPActivityDataType spactivityDataType = (!flag) ? this.AM.SPActivityData[index2] : this.AM.CSActivityData[index2];
			UnitComp3 unitComp = (!flag) ? this.SPObj[index2] : this.CSObj[index2];
			if (unitComp == null)
			{
				return;
			}
			long num;
			if (flag)
			{
				num = spactivityDataType.EventBeginTime - this.DM.ServerTime;
			}
			else
			{
				num = spactivityDataType.EventEndTime - this.DM.ServerTime;
			}
			if (num < 0L)
			{
				num = 0L;
			}
			unitComp.BtnStr.Length = 0;
			GameConstants.GetTimeString(unitComp.BtnStr, (uint)num, false, true, false, false, true);
			unitComp.BtnText2.text = unitComp.BtnStr.ToString();
			unitComp.BtnText2.SetAllDirty();
			unitComp.BtnText2.cachedTextGenerator.Invalidate();
		}
		else if (index != 253)
		{
			if (index >= 201 && index <= 205)
			{
				index -= 201;
				UnitComp3 unitComp2 = this.KVKObj[index];
				if (unitComp2 == null)
				{
					return;
				}
				ActivityDataType activityDataType = this.AM.KvKActivityData[index];
				unitComp2.BtnStr.Length = 0;
				if (activityDataType.EventState != EActivityState.EAS_ReplayRanking)
				{
					GameConstants.GetTimeString(unitComp2.BtnStr, (uint)activityDataType.EventCountTime, false, true, false, false, true);
				}
				unitComp2.BtnText2.text = unitComp2.BtnStr.ToString();
				unitComp2.BtnText2.SetAllDirty();
				unitComp2.BtnText2.cachedTextGenerator.Invalidate();
			}
			else if (index >= 211 && index <= 213)
			{
				index -= 211;
				UnitComp3 unitComp3 = this.FIFAObj[index];
				if (unitComp3 == null)
				{
					return;
				}
				ActivityDataType activityDataType2 = this.AM.FIFAData[index];
				unitComp3.BtnStr.Length = 0;
				if (activityDataType2.EventState != EActivityState.EAS_ReplayRanking)
				{
					GameConstants.GetTimeString(unitComp3.BtnStr, (uint)activityDataType2.EventCountTime, false, true, false, false, true);
				}
				unitComp3.BtnText2.text = unitComp3.BtnStr.ToString();
				unitComp3.BtnText2.SetAllDirty();
				unitComp3.BtnText2.cachedTextGenerator.Invalidate();
			}
			else if (index == 206)
			{
				UnitComp3 amobj = this.AMObj;
				if (amobj == null)
				{
					return;
				}
				ActivityDataType allyMobilizationData = this.AM.AllyMobilizationData;
				amobj.BtnStr.Length = 0;
				if (allyMobilizationData.EventState != EActivityState.EAS_ReplayRanking)
				{
					GameConstants.GetTimeString(amobj.BtnStr, (uint)allyMobilizationData.EventCountTime, false, true, false, false, true);
				}
				amobj.BtnText2.text = amobj.BtnStr.ToString();
				amobj.BtnText2.SetAllDirty();
				amobj.BtnText2.cachedTextGenerator.Invalidate();
			}
			else if (index == 207)
			{
				UnitComp3 kowobj = this.KOWObj;
				if (kowobj == null)
				{
					return;
				}
				ActivityDataType kowdata = this.AM.KOWData;
				kowobj.BtnStr.Length = 0;
				if (kowdata.EventState != EActivityState.EAS_ReplayRanking)
				{
					GameConstants.GetTimeString(kowobj.BtnStr, (uint)kowdata.EventCountTime, false, true, false, false, true);
				}
				kowobj.BtnText2.text = kowobj.BtnStr.ToString();
				kowobj.BtnText2.SetAllDirty();
				kowobj.BtnText2.cachedTextGenerator.Invalidate();
			}
			else if (index == 208)
			{
				UnitComp3 sumObj = this.SumObj;
				if (sumObj == null)
				{
					return;
				}
				ActivityDataType allianceSummonData = this.AM.AllianceSummonData;
				sumObj.BtnStr.Length = 0;
				if (allianceSummonData.EventState != EActivityState.EAS_ReplayRanking)
				{
					GameConstants.GetTimeString(sumObj.BtnStr, (uint)allianceSummonData.EventCountTime, false, true, false, false, true);
				}
				sumObj.BtnText2.text = sumObj.BtnStr.ToString();
				sumObj.BtnText2.SetAllDirty();
				sumObj.BtnText2.cachedTextGenerator.Invalidate();
			}
			else if (index == 209)
			{
				UnitComp3 nwobj = this.NWObj;
				if (nwobj == null)
				{
					return;
				}
				ActivityDataType nobilityActivityData = this.AM.NobilityActivityData;
				nwobj.BtnStr.Length = 0;
				if (nobilityActivityData.EventState != EActivityState.EAS_ReplayRanking)
				{
					GameConstants.GetTimeString(nwobj.BtnStr, (uint)nobilityActivityData.EventCountTime, false, true, false, false, true);
				}
				nwobj.BtnText2.text = nwobj.BtnStr.ToString();
				nwobj.BtnText2.SetAllDirty();
				nwobj.BtnText2.cachedTextGenerator.Invalidate();
			}
			else if (index == 210)
			{
				UnitComp3 awobj = this.AWObj;
				if (awobj == null)
				{
					return;
				}
				ActivityDataType allianceWarData = this.AM.AllianceWarData;
				awobj.BtnStr.Length = 0;
				if (this.AM.AW_State != EAllianceWarState.EAWS_Replay)
				{
					GameConstants.GetTimeString(awobj.BtnStr, (uint)allianceWarData.EventCountTime, false, true, false, false, true);
				}
				awobj.BtnText2.text = awobj.BtnStr.ToString();
				awobj.BtnText2.SetAllDirty();
				awobj.BtnText2.cachedTextGenerator.Invalidate();
			}
			else
			{
				if (index < 0 || index >= this.AllObject.Count)
				{
					return;
				}
				ActivityDataType activityDataType3 = this.AM.ActivityData[index];
				this.AllObject[index].BtnStr.Length = 0;
				GameConstants.GetTimeString(this.AllObject[index].BtnStr, (uint)activityDataType3.EventCountTime, false, true, false, false, true);
				this.AllObject[index].BtnText2.text = this.AllObject[index].BtnStr.ToString();
				this.AllObject[index].BtnText2.SetAllDirty();
				this.AllObject[index].BtnText2.cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x06000D57 RID: 3415 RVA: 0x00143400 File Offset: 0x00141600
	private void SetMiddleText(int index, int index2 = -1)
	{
		if (index == 254 || index == 255)
		{
			bool flag = index == 254;
			SPActivityDataType spactivityDataType = (!flag) ? this.AM.SPActivityData[index2] : this.AM.CSActivityData[index2];
			UnitComp3 unitComp = (!flag) ? this.SPObj[index2] : this.CSObj[index2];
			if (unitComp == null)
			{
				return;
			}
			if (spactivityDataType.bDownLoadStr)
			{
				if (spactivityDataType.bUpDateStr)
				{
					if (this.AM.CSActivityData[index2].DetailStr == spactivityDataType.DetailStr)
					{
						this.AM.CSActivityData[index2].UnloadStrAB();
					}
					if (this.AM.SPActivityData[index2].DetailStr == spactivityDataType.DetailStr)
					{
						this.AM.SPActivityData[index2].UnloadStrAB();
					}
					spactivityDataType.bUpDateStr = false;
				}
				if (spactivityDataType.m_StrAssetBundleKey == 0)
				{
					spactivityDataType.InitialABString();
				}
				if (spactivityDataType.DownLoadStr != null)
				{
					byte b = (byte)((int)(this.DM.UserLanguage - GameLanguage.GL_Eng) * spactivityDataType.DownLoadStr.Count);
					if ((int)b >= spactivityDataType.DownLoadStr.Content.Length || spactivityDataType.DownLoadStr.Content[(int)b] == string.Empty)
					{
						b = 0;
					}
					unitComp.InfoText.text = spactivityDataType.DownLoadStr.Content[(int)b];
				}
			}
			else
			{
				unitComp.InfoText.text = string.Empty;
			}
		}
		else if (index == 253)
		{
			UnitComp3 fbobj = this.FBObj;
			if (fbobj == null)
			{
				return;
			}
			SPActivityDataType fbactivityData = this.AM.FBActivityData;
			if (fbactivityData.bDownLoadStr)
			{
				if (fbactivityData.bUpDateStr)
				{
					if (this.AM.FBActivityData.DetailStr == fbactivityData.DetailStr)
					{
						this.AM.FBActivityData.UnloadStrAB();
					}
					fbactivityData.bUpDateStr = false;
				}
				if (fbactivityData.m_StrAssetBundleKey == 0)
				{
					fbactivityData.InitialABString();
				}
				if (fbactivityData.DownLoadStr != null)
				{
					byte b2 = (byte)((int)(this.DM.UserLanguage - GameLanguage.GL_Eng) * fbactivityData.DownLoadStr.Count);
					if ((int)b2 >= fbactivityData.DownLoadStr.Content.Length || fbactivityData.DownLoadStr.Content[(int)b2] == string.Empty)
					{
						b2 = 0;
					}
					fbobj.InfoText.text = fbactivityData.DownLoadStr.Content[(int)b2];
				}
			}
			else
			{
				fbobj.InfoText.text = string.Empty;
			}
		}
		else if (index == 205)
		{
			if (this.KVKObj[4] != null)
			{
				this.KVKObj[4].InfoText.text = this.DM.mStringTable.GetStringByID(9847u);
			}
		}
		else if (index == 207)
		{
			if (this.KOWObj != null)
			{
				this.KOWObj.InfoText.text = this.DM.mStringTable.GetStringByID(10017u);
			}
		}
		else if (index == 208)
		{
			if (this.SumObj != null)
			{
				this.SumObj.InfoText.text = this.DM.mStringTable.GetStringByID(10017u);
			}
		}
		else if (index == 209)
		{
			if (this.NWObj != null)
			{
				this.NWObj.InfoText.text = this.DM.mStringTable.GetStringByID(5041u);
			}
		}
		else if (index == 210)
		{
			if (this.AWObj != null)
			{
				if (this.DM.RoleAlliance.Id == 0u)
				{
					this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(689u);
					return;
				}
				EAllianceWarState aw_State = this.AM.AW_State;
				if (aw_State == EAllianceWarState.EAWS_SignUp)
				{
					this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(14602u);
				}
				else if (aw_State == EAllianceWarState.EAWS_Prepare)
				{
					this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(14603u);
				}
				else if (aw_State == EAllianceWarState.EAWS_Run)
				{
					if (this.AM.AW_Round == 1)
					{
						this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(14604u);
					}
					else if (this.AM.AW_Round == 2)
					{
						this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(14605u);
					}
					else if (this.AM.AW_Round == 3)
					{
						this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(14606u);
					}
					else if (this.AM.AW_Round == 4)
					{
						this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(14607u);
					}
					else
					{
						this.AWObj.InfoText.text = string.Empty;
					}
				}
				else if (aw_State == EAllianceWarState.EAWS_Replay)
				{
					this.AWObj.InfoText.text = this.DM.mStringTable.GetStringByID(5042u);
				}
				else
				{
					this.AWObj.InfoText.text = string.Empty;
				}
			}
		}
		else if (index == 213 && this.FIFAObj[2] != null)
		{
			ActivityDataType activityDataType = this.AM.FIFAData[index - 211];
			if (activityDataType.ActiveType == EActivityType.EAT_FIFA_KVK)
			{
				this.FIFAObj[2].InfoText.text = this.DM.mStringTable.GetStringByID(9847u);
			}
			else
			{
				this.FIFAObj[2].InfoText.text = this.DM.mStringTable.GetStringByID(12204u);
			}
		}
	}

	// Token: 0x06000D58 RID: 3416 RVA: 0x00143A60 File Offset: 0x00141C60
	private void CheckNews()
	{
		if (this.NewsObj == null)
		{
			return;
		}
		long num = (long)((ulong)this.AM.ShowNewsNo);
		if (num <= 0L)
		{
			this.NewsObj.FlashRC.gameObject.SetActive(false);
		}
		else
		{
			this.NewsObj.FlashStr.ClearString();
			this.NewsObj.FlashStr.IntToFormat(num, 1, false);
			this.NewsObj.FlashStr.AppendFormat("{0}");
			this.NewsObj.FlashText.text = this.NewsObj.FlashStr.ToString();
			this.NewsObj.FlashText.SetAllDirty();
			this.NewsObj.FlashText.cachedTextGenerator.Invalidate();
			this.NewsObj.FlashText.cachedTextGeneratorForLayout.Invalidate();
			this.NewsObj.FlashRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.NewsObj.FlashText.preferredWidth), 51f);
			this.NewsObj.FlashRC.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000D59 RID: 3417 RVA: 0x00143B84 File Offset: 0x00141D84
	private void CheckAMShowHint()
	{
		if (this.AMObj != null)
		{
			this.AMObj.FlashGO.SetActive(this.AM.bShowAMHint);
		}
	}

	// Token: 0x06000D5A RID: 3418 RVA: 0x00143BB8 File Offset: 0x00141DB8
	private void CheckNWShowHint()
	{
		if (this.NWObj != null)
		{
			this.NWObj.FlashGO.SetActive(this.AM.bForceNWActivity);
		}
	}

	// Token: 0x06000D5B RID: 3419 RVA: 0x00143BEC File Offset: 0x00141DEC
	private void CheckAWShowHint()
	{
		if (this.AWObj != null)
		{
			this.AWObj.FlashGO.SetActive(this.AM.bShowAWHint);
		}
	}

	// Token: 0x06000D5C RID: 3420 RVA: 0x00143C20 File Offset: 0x00141E20
	private void CheckFIFAShowHint()
	{
		if (this.FIFAObj[2] != null)
		{
			this.FIFAObj[2].FlashGO.SetActive(this.AM.bShowFIFAHint);
		}
	}

	// Token: 0x06000D5D RID: 3421 RVA: 0x00143C58 File Offset: 0x00141E58
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			for (int i = 0; i < this.AM.ActivityData.Length; i++)
			{
				this.SetTimeText(i, -1);
			}
			for (int j = 201; j <= 213; j++)
			{
				this.SetTimeText(j, -1);
			}
			for (int k = 0; k < 5; k++)
			{
				this.SetTimeText(254, k);
			}
			for (int l = 0; l < 5; l++)
			{
				this.SetTimeText(255, l);
			}
		}
		else if (arg1 == 2)
		{
			this.SetScoreText(arg2);
		}
		else if (arg1 == 3)
		{
			if (arg2 >= 201 && arg2 <= 205)
			{
				ActivityDataType activityDataType = this.AM.KvKActivityData[arg2 - 201];
				if (activityDataType.EventState == EActivityState.EAS_Prepare)
				{
					this.AM.Send_ACTIVITY_KEVENT_LIST_SINGLE((byte)arg2);
				}
				else
				{
					this.SetText(arg2, -1);
					this.SetBackImg(arg2, -1);
					this.SetMainImg(arg2, -1);
				}
			}
			else if (arg2 == 206)
			{
				ActivityDataType allyMobilizationData = this.AM.AllyMobilizationData;
				if (allyMobilizationData.EventState == EActivityState.EAS_Prepare)
				{
					this.AM.Send_ACTIVITY_EVENT_LIST_SINGLE(6);
				}
				else
				{
					this.SetText(arg2, -1);
					this.SetBackImg(arg2, -1);
					this.SetMainImg(arg2, -1);
				}
			}
			else if (arg2 == 207)
			{
				ActivityDataType kowdata = this.AM.KOWData;
				if (kowdata.EventState == EActivityState.EAS_Prepare)
				{
					this.AM.Send_ACTIVITY_EVENT_LIST_SINGLE(7);
				}
				else
				{
					this.SetText(arg2, -1);
					this.SetBackImg(arg2, -1);
					this.SetMainImg(arg2, -1);
				}
			}
			else if (arg2 == 208)
			{
				ActivityDataType allianceSummonData = this.AM.AllianceSummonData;
				if (allianceSummonData.EventState == EActivityState.EAS_Prepare)
				{
					this.AM.Send_ACTIVITY_EVENT_LIST_SINGLE(11);
				}
				else
				{
					this.SetText(arg2, -1);
					this.SetBackImg(arg2, -1);
					this.SetMainImg(arg2, -1);
				}
			}
			else if (arg2 == 209)
			{
				ActivityDataType nobilityActivityData = this.AM.NobilityActivityData;
				if (nobilityActivityData.EventState == EActivityState.EAS_Prepare)
				{
					this.AM.Send_ACTIVITY_EVENT_LIST_SINGLE(12);
				}
				else
				{
					this.SetText(arg2, -1);
					this.SetBackImg(arg2, -1);
					this.SetMainImg(arg2, -1);
				}
			}
			else if (arg2 == 210)
			{
				ActivityDataType allianceWarData = this.AM.AllianceWarData;
				if (allianceWarData.EventState == EActivityState.EAS_Prepare)
				{
					this.AM.Send_ACTIVITY_EVENT_LIST_SINGLE(13);
				}
				else
				{
					this.SetText(arg2, -1);
					this.SetBackImg(arg2, -1);
					this.SetMainImg(arg2, -1);
				}
			}
			else if (arg2 >= 211 && arg2 <= 213)
			{
				ActivityDataType activityDataType2 = this.AM.FIFAData[arg2 - 211];
				if (activityDataType2.EventState == EActivityState.EAS_Prepare)
				{
					this.AM.Send_FIFA_LIST_SINGLE((byte)arg2);
				}
				else
				{
					this.SetText(arg2, -1);
					this.SetBackImg(arg2, -1);
					this.SetMainImg(arg2, -1);
				}
			}
			else
			{
				if (arg2 < 0 || arg2 >= this.AllObject.Count)
				{
					return;
				}
				ActivityDataType activityDataType3 = this.AM.ActivityData[arg2];
				if (activityDataType3.EventState == EActivityState.EAS_Prepare)
				{
					this.AM.Send_ACTIVITY_EVENT_LIST_SINGLE((byte)arg2);
				}
				else
				{
					this.SetText(arg2, -1);
					this.SetBackImg(arg2, -1);
					this.SetMainImg(arg2, -1);
				}
			}
		}
		else if (arg1 == 4)
		{
			this.SetText(arg2, -1);
			this.SetBackImg(arg2, -1);
			this.SetMainImg(arg2, -1);
		}
		else if (arg1 == 5)
		{
			this.ResetAll();
		}
		else if (arg1 == 6)
		{
			for (int m = 0; m < this.AM.CSActivityData.Length; m++)
			{
				if (this.AM.CSActivityData[m].EventBeginTime > 0L)
				{
					this.SetMainImg(254, m);
				}
			}
			for (int n = 0; n < this.AM.SPActivityData.Length; n++)
			{
				if (this.AM.SPActivityData[n].EventBeginTime > 0L)
				{
					this.SetMainImg(255, n);
				}
			}
			for (int num = 201; num <= 213; num++)
			{
				this.SetMainImg(num, -1);
			}
			this.SetMainImg(253, -1);
		}
		else if (arg1 == 7)
		{
			for (int num2 = 0; num2 < this.AM.CSActivityData.Length; num2++)
			{
				if (this.AM.CSActivityData[num2].EventBeginTime > 0L)
				{
					this.SetMiddleText(254, num2);
				}
			}
			for (int num3 = 0; num3 < this.AM.SPActivityData.Length; num3++)
			{
				if (this.AM.SPActivityData[num3].EventBeginTime > 0L)
				{
					this.SetMiddleText(255, num3);
				}
			}
			for (int num4 = 205; num4 <= 213; num4++)
			{
				this.SetMiddleText(num4, -1);
			}
			this.SetMainImg(253, -1);
		}
		else if (arg1 == 8)
		{
			this.CheckNews();
		}
		else if (arg1 == 9)
		{
			this.SetText(254, arg2);
			this.SetBackImg(254, arg2);
			this.SetMainImg(254, arg2);
		}
		else if (arg1 == 10)
		{
			this.SetText(255, arg2);
			this.SetBackImg(255, arg2);
			this.SetMainImg(255, arg2);
		}
		else if (arg1 == 11)
		{
			this.CheckAMShowHint();
		}
		else if (arg1 == 12)
		{
			if (this.AMObj != null)
			{
				this.GM.SetAllyRankImage(this.AMObj.AllyRankImg, this.DM.RoleAlliance.AMRank);
			}
		}
		else if (arg1 == 13)
		{
			this.SetBackImg(arg2, -1);
		}
		else if (arg1 == 14)
		{
			this.CheckNWShowHint();
		}
		else if (arg1 == 15)
		{
			if (this.AWObj != null)
			{
				this.GM.SetAllyWarRankImage(this.AWObj.AllyRankImg, this.AM.AW_Rank);
			}
		}
		else if (arg1 == 16)
		{
			this.CheckAWShowHint();
		}
		else if (arg1 == 17)
		{
			this.SetText(210, -1);
			this.SetMiddleText(210, -1);
			this.SetBackImg(210, -1);
			this.SetMainImg(210, -1);
		}
		else if (arg1 == 18)
		{
			this.CheckFIFAShowHint();
		}
		else if (arg1 == 19 && this.bShowFirstBuy && this.GM.BuildingData.GetBuildData(8, 0).Level >= 17)
		{
			this.ResetAll();
		}
	}

	// Token: 0x06000D5E RID: 3422 RVA: 0x00144380 File Offset: 0x00142580
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			this.AM.Send_ACTIVITY_EVENT_LIST();
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				if (this.BgText != null && this.BgText.enabled)
				{
					this.BgText.enabled = false;
					this.BgText.enabled = true;
				}
				for (int i = 0; i < this.AllObject.Count; i++)
				{
					if (this.AllObject[i] != null)
					{
						if (this.AllObject[i].NameText != null && this.AllObject[i].NameText.enabled)
						{
							this.AllObject[i].NameText.enabled = false;
							this.AllObject[i].NameText.enabled = true;
						}
						if (this.AllObject[i].RewardText != null && this.AllObject[i].RewardText.enabled)
						{
							this.AllObject[i].RewardText.enabled = false;
							this.AllObject[i].RewardText.enabled = true;
						}
						if (this.AllObject[i].InfoText != null && this.AllObject[i].InfoText.enabled)
						{
							this.AllObject[i].InfoText.enabled = false;
							this.AllObject[i].InfoText.enabled = true;
						}
						if (this.AllObject[i].BtnText1 != null && this.AllObject[i].BtnText1.enabled)
						{
							this.AllObject[i].BtnText1.enabled = false;
							this.AllObject[i].BtnText1.enabled = true;
						}
						if (this.AllObject[i].BtnText2 != null && this.AllObject[i].BtnText2.enabled)
						{
							this.AllObject[i].BtnText2.enabled = false;
							this.AllObject[i].BtnText2.enabled = true;
						}
					}
				}
				for (int j = 0; j < this.CSObj.Length; j++)
				{
					if (this.CSObj[j] != null)
					{
						if (this.CSObj[j].NameText != null && this.CSObj[j].NameText.enabled)
						{
							this.CSObj[j].NameText.enabled = false;
							this.CSObj[j].NameText.enabled = true;
						}
						if (this.CSObj[j].RewardText != null && this.CSObj[j].RewardText.enabled)
						{
							this.CSObj[j].RewardText.enabled = false;
							this.CSObj[j].RewardText.enabled = true;
						}
						if (this.CSObj[j].InfoText != null && this.CSObj[j].InfoText.enabled)
						{
							this.CSObj[j].InfoText.enabled = false;
							this.CSObj[j].InfoText.enabled = true;
						}
						if (this.CSObj[j].BtnText1 != null && this.CSObj[j].BtnText1.enabled)
						{
							this.CSObj[j].BtnText1.enabled = false;
							this.CSObj[j].BtnText1.enabled = true;
						}
						if (this.CSObj[j].BtnText2 != null && this.CSObj[j].BtnText2.enabled)
						{
							this.CSObj[j].BtnText2.enabled = false;
							this.CSObj[j].BtnText2.enabled = true;
						}
					}
				}
				for (int k = 0; k < this.SPObj.Length; k++)
				{
					if (this.SPObj[k] != null)
					{
						if (this.SPObj[k].NameText != null && this.SPObj[k].NameText.enabled)
						{
							this.SPObj[k].NameText.enabled = false;
							this.SPObj[k].NameText.enabled = true;
						}
						if (this.SPObj[k].RewardText != null && this.SPObj[k].RewardText.enabled)
						{
							this.SPObj[k].RewardText.enabled = false;
							this.SPObj[k].RewardText.enabled = true;
						}
						if (this.SPObj[k].InfoText != null && this.SPObj[k].InfoText.enabled)
						{
							this.SPObj[k].InfoText.enabled = false;
							this.SPObj[k].InfoText.enabled = true;
						}
						if (this.SPObj[k].BtnText1 != null && this.SPObj[k].BtnText1.enabled)
						{
							this.SPObj[k].BtnText1.enabled = false;
							this.SPObj[k].BtnText1.enabled = true;
						}
						if (this.SPObj[k].BtnText2 != null && this.SPObj[k].BtnText2.enabled)
						{
							this.SPObj[k].BtnText2.enabled = false;
							this.SPObj[k].BtnText2.enabled = true;
						}
					}
				}
				for (int l = 0; l < this.KVKObj.Length; l++)
				{
					if (this.KVKObj[l] != null)
					{
						if (this.KVKObj[l].NameText != null && this.KVKObj[l].NameText.enabled)
						{
							this.KVKObj[l].NameText.enabled = false;
							this.KVKObj[l].NameText.enabled = true;
						}
						if (this.KVKObj[l].RewardText != null && this.KVKObj[l].RewardText.enabled)
						{
							this.KVKObj[l].RewardText.enabled = false;
							this.KVKObj[l].RewardText.enabled = true;
						}
						if (this.KVKObj[l].InfoText != null && this.KVKObj[l].InfoText.enabled)
						{
							this.KVKObj[l].InfoText.enabled = false;
							this.KVKObj[l].InfoText.enabled = true;
						}
						if (this.KVKObj[l].BtnText1 != null && this.KVKObj[l].BtnText1.enabled)
						{
							this.KVKObj[l].BtnText1.enabled = false;
							this.KVKObj[l].BtnText1.enabled = true;
						}
						if (this.KVKObj[l].BtnText2 != null && this.KVKObj[l].BtnText2.enabled)
						{
							this.KVKObj[l].BtnText2.enabled = false;
							this.KVKObj[l].BtnText2.enabled = true;
						}
					}
				}
				for (int m = 0; m < this.FIFAObj.Length; m++)
				{
					if (this.FIFAObj[m] != null)
					{
						if (this.FIFAObj[m].NameText != null && this.FIFAObj[m].NameText.enabled)
						{
							this.FIFAObj[m].NameText.enabled = false;
							this.FIFAObj[m].NameText.enabled = true;
						}
						if (this.FIFAObj[m].RewardText != null && this.FIFAObj[m].RewardText.enabled)
						{
							this.FIFAObj[m].RewardText.enabled = false;
							this.FIFAObj[m].RewardText.enabled = true;
						}
						if (this.FIFAObj[m].InfoText != null && this.FIFAObj[m].InfoText.enabled)
						{
							this.FIFAObj[m].InfoText.enabled = false;
							this.FIFAObj[m].InfoText.enabled = true;
						}
						if (this.FIFAObj[m].BtnText1 != null && this.FIFAObj[m].BtnText1.enabled)
						{
							this.FIFAObj[m].BtnText1.enabled = false;
							this.FIFAObj[m].BtnText1.enabled = true;
						}
						if (this.FIFAObj[m].BtnText2 != null && this.FIFAObj[m].BtnText2.enabled)
						{
							this.FIFAObj[m].BtnText2.enabled = false;
							this.FIFAObj[m].BtnText2.enabled = true;
						}
					}
				}
				if (this.NewsObj != null && this.NewsObj.NameText != null && this.NewsObj.NameText.enabled)
				{
					this.NewsObj.NameText.enabled = false;
					this.NewsObj.NameText.enabled = true;
				}
				if (this.AMObj != null)
				{
					if (this.AMObj.NameText != null && this.AMObj.NameText.enabled)
					{
						this.AMObj.NameText.enabled = false;
						this.AMObj.NameText.enabled = true;
					}
					if (this.AMObj.RewardText != null && this.AMObj.RewardText.enabled)
					{
						this.AMObj.RewardText.enabled = false;
						this.AMObj.RewardText.enabled = true;
					}
					if (this.AMObj.InfoText != null && this.AMObj.InfoText.enabled)
					{
						this.AMObj.InfoText.enabled = false;
						this.AMObj.InfoText.enabled = true;
					}
					if (this.AMObj.BtnText1 != null && this.AMObj.BtnText1.enabled)
					{
						this.AMObj.BtnText1.enabled = false;
						this.AMObj.BtnText1.enabled = true;
					}
					if (this.AMObj.BtnText2 != null && this.AMObj.BtnText2.enabled)
					{
						this.AMObj.BtnText2.enabled = false;
						this.AMObj.BtnText2.enabled = true;
					}
					if (this.AMObj.RankText != null && this.AMObj.RankText.enabled)
					{
						this.AMObj.RankText.enabled = false;
						this.AMObj.RankText.enabled = true;
					}
					if (this.AMObj.AllyRankText != null && this.AMObj.AllyRankText.enabled)
					{
						this.AMObj.AllyRankText.enabled = false;
						this.AMObj.AllyRankText.enabled = true;
					}
				}
				if (this.KOWObj != null)
				{
					if (this.KOWObj.NameText != null && this.KOWObj.NameText.enabled)
					{
						this.KOWObj.NameText.enabled = false;
						this.KOWObj.NameText.enabled = true;
					}
					if (this.KOWObj.RewardText != null && this.KOWObj.RewardText.enabled)
					{
						this.KOWObj.RewardText.enabled = false;
						this.KOWObj.RewardText.enabled = true;
					}
					if (this.KOWObj.InfoText != null && this.KOWObj.InfoText.enabled)
					{
						this.KOWObj.InfoText.enabled = false;
						this.KOWObj.InfoText.enabled = true;
					}
					if (this.KOWObj.BtnText1 != null && this.KOWObj.BtnText1.enabled)
					{
						this.KOWObj.BtnText1.enabled = false;
						this.KOWObj.BtnText1.enabled = true;
					}
					if (this.KOWObj.BtnText2 != null && this.KOWObj.BtnText2.enabled)
					{
						this.KOWObj.BtnText2.enabled = false;
						this.KOWObj.BtnText2.enabled = true;
					}
					if (this.KOWObj.RankText != null && this.KOWObj.RankText.enabled)
					{
						this.KOWObj.RankText.enabled = false;
						this.KOWObj.RankText.enabled = true;
					}
					if (this.KOWObj.AllyRankText != null && this.KOWObj.AllyRankText.enabled)
					{
						this.KOWObj.AllyRankText.enabled = false;
						this.KOWObj.AllyRankText.enabled = true;
					}
				}
				if (this.SumObj != null)
				{
					if (this.SumObj.NameText != null && this.SumObj.NameText.enabled)
					{
						this.SumObj.NameText.enabled = false;
						this.SumObj.NameText.enabled = true;
					}
					if (this.SumObj.RewardText != null && this.SumObj.RewardText.enabled)
					{
						this.SumObj.RewardText.enabled = false;
						this.SumObj.RewardText.enabled = true;
					}
					if (this.SumObj.InfoText != null && this.SumObj.InfoText.enabled)
					{
						this.SumObj.InfoText.enabled = false;
						this.SumObj.InfoText.enabled = true;
					}
					if (this.SumObj.BtnText1 != null && this.SumObj.BtnText1.enabled)
					{
						this.SumObj.BtnText1.enabled = false;
						this.SumObj.BtnText1.enabled = true;
					}
					if (this.SumObj.BtnText2 != null && this.SumObj.BtnText2.enabled)
					{
						this.SumObj.BtnText2.enabled = false;
						this.SumObj.BtnText2.enabled = true;
					}
					if (this.SumObj.RankText != null && this.SumObj.RankText.enabled)
					{
						this.SumObj.RankText.enabled = false;
						this.SumObj.RankText.enabled = true;
					}
					if (this.SumObj.AllyRankText != null && this.SumObj.AllyRankText.enabled)
					{
						this.SumObj.AllyRankText.enabled = false;
						this.SumObj.AllyRankText.enabled = true;
					}
				}
				if (this.NWObj != null)
				{
					if (this.NWObj.NameText != null && this.NWObj.NameText.enabled)
					{
						this.NWObj.NameText.enabled = false;
						this.NWObj.NameText.enabled = true;
					}
					if (this.NWObj.RewardText != null && this.NWObj.RewardText.enabled)
					{
						this.NWObj.RewardText.enabled = false;
						this.NWObj.RewardText.enabled = true;
					}
					if (this.NWObj.InfoText != null && this.NWObj.InfoText.enabled)
					{
						this.NWObj.InfoText.enabled = false;
						this.NWObj.InfoText.enabled = true;
					}
					if (this.NWObj.BtnText1 != null && this.NWObj.BtnText1.enabled)
					{
						this.NWObj.BtnText1.enabled = false;
						this.NWObj.BtnText1.enabled = true;
					}
					if (this.NWObj.BtnText2 != null && this.NWObj.BtnText2.enabled)
					{
						this.NWObj.BtnText2.enabled = false;
						this.NWObj.BtnText2.enabled = true;
					}
					if (this.NWObj.RankText != null && this.NWObj.RankText.enabled)
					{
						this.NWObj.RankText.enabled = false;
						this.NWObj.RankText.enabled = true;
					}
					if (this.NWObj.FlashText != null && this.NWObj.FlashText.enabled)
					{
						this.NWObj.FlashText.enabled = false;
						this.NWObj.FlashText.enabled = true;
					}
					if (this.NWObj.AllyRankText != null && this.NWObj.AllyRankText.enabled)
					{
						this.NWObj.AllyRankText.enabled = false;
						this.NWObj.AllyRankText.enabled = true;
					}
				}
				if (this.AWObj != null)
				{
					if (this.AWObj.NameText != null && this.AWObj.NameText.enabled)
					{
						this.AWObj.NameText.enabled = false;
						this.AWObj.NameText.enabled = true;
					}
					if (this.AWObj.RewardText != null && this.AWObj.RewardText.enabled)
					{
						this.AWObj.RewardText.enabled = false;
						this.AWObj.RewardText.enabled = true;
					}
					if (this.AWObj.InfoText != null && this.AWObj.InfoText.enabled)
					{
						this.AWObj.InfoText.enabled = false;
						this.AWObj.InfoText.enabled = true;
					}
					if (this.AWObj.BtnText1 != null && this.AWObj.BtnText1.enabled)
					{
						this.AWObj.BtnText1.enabled = false;
						this.AWObj.BtnText1.enabled = true;
					}
					if (this.AWObj.BtnText2 != null && this.AWObj.BtnText2.enabled)
					{
						this.AWObj.BtnText2.enabled = false;
						this.AWObj.BtnText2.enabled = true;
					}
					if (this.AWObj.RankText != null && this.AWObj.RankText.enabled)
					{
						this.AWObj.RankText.enabled = false;
						this.AWObj.RankText.enabled = true;
					}
					if (this.AWObj.FlashText != null && this.AWObj.FlashText.enabled)
					{
						this.AWObj.FlashText.enabled = false;
						this.AWObj.FlashText.enabled = true;
					}
					if (this.AWObj.AllyRankText != null && this.AWObj.AllyRankText.enabled)
					{
						this.AWObj.AllyRankText.enabled = false;
						this.AWObj.AllyRankText.enabled = true;
					}
				}
				if (this.FBObj != null)
				{
					if (this.FBObj.NameText != null && this.FBObj.NameText.enabled)
					{
						this.FBObj.NameText.enabled = false;
						this.FBObj.NameText.enabled = true;
					}
					if (this.FBObj.RewardText != null && this.FBObj.RewardText.enabled)
					{
						this.FBObj.RewardText.enabled = false;
						this.FBObj.RewardText.enabled = true;
					}
					if (this.FBObj.InfoText != null && this.FBObj.InfoText.enabled)
					{
						this.FBObj.InfoText.enabled = false;
						this.FBObj.InfoText.enabled = true;
					}
					if (this.FBObj.BtnText1 != null && this.FBObj.BtnText1.enabled)
					{
						this.FBObj.BtnText1.enabled = false;
						this.FBObj.BtnText1.enabled = true;
					}
					if (this.FBObj.BtnText2 != null && this.FBObj.BtnText2.enabled)
					{
						this.FBObj.BtnText2.enabled = false;
						this.FBObj.BtnText2.enabled = true;
					}
					if (this.FBObj.RankText != null && this.FBObj.RankText.enabled)
					{
						this.FBObj.RankText.enabled = false;
						this.FBObj.RankText.enabled = true;
					}
					if (this.FBObj.FlashText != null && this.FBObj.FlashText.enabled)
					{
						this.FBObj.FlashText.enabled = false;
						this.FBObj.FlashText.enabled = true;
					}
					if (this.FBObj.AllyRankText != null && this.FBObj.AllyRankText.enabled)
					{
						this.FBObj.AllyRankText.enabled = false;
						this.FBObj.AllyRankText.enabled = true;
					}
				}
			}
			break;
		}
	}

	// Token: 0x06000D5F RID: 3423 RVA: 0x00145BA0 File Offset: 0x00143DA0
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
			if (sender.m_BtnID2 == 1)
			{
				if (door)
				{
					door.CloseMenu(false);
				}
			}
			else if (sender.m_BtnID2 == 2 && door)
			{
				door.OpenMenu(EGUIWindow.UI_Activity4, 1, 100, false);
			}
		}
		else if (sender.m_BtnID1 == 2)
		{
			Door door2 = this.GM.FindMenu(EGUIWindow.Door) as Door;
			if (sender.m_BtnID2 == 1)
			{
				this.AM.Send_ACTIVITY_EVENT_DETAIL((byte)sender.m_BtnID3);
			}
			else if (sender.m_BtnID2 == 2)
			{
				if (door2)
				{
					door2.OpenMenu(EGUIWindow.UI_Activity3, 255, sender.m_BtnID3, false);
					this.AM.SaveActivity(1, sender.m_BtnID3, false);
				}
			}
			else if (sender.m_BtnID2 == 3)
			{
				if (door2)
				{
					door2.OpenMenu(EGUIWindow.UI_Activity3, 254, sender.m_BtnID3, false);
					this.AM.SaveActivity(0, sender.m_BtnID3, false);
				}
			}
			else if (sender.m_BtnID2 == -1)
			{
				this.AM.ClearNewsNo();
				IGGSDKPlugin.GoToNews(GameConstants.GlobalEditionTWNewsUrl, GameConstants.GlobalEditionNewsUrlKey, (int)DataManager.MapDataController.kingdomData.kingdomID);
			}
			else if (sender.m_BtnID2 == 11)
			{
				this.AM.Send_ACTIVITY_KEVENT_DETAIL((byte)sender.m_BtnID3);
			}
			else if (sender.m_BtnID2 == 12)
			{
				if (this.AM.bForceAMActivity)
				{
					this.AM.SavebForceAMActivity(MobilizationManager.Instance.AMGoldState == 2);
					this.AM.CheckAMShowHint();
				}
				door2.OpenMenu(EGUIWindow.UI_Alliance_Mobilization, 0, 0, false);
			}
			else if (sender.m_BtnID2 == 13)
			{
				if (this.AM.KOWData.EventState == EActivityState.EAS_ReplayRanking && !this.AM.KOWData.bAskDetailData)
				{
					this.AM.Send_KINGOFTHEWORLD_KINGINFO();
				}
				else
				{
					door2.OpenMenu(EGUIWindow.UI_Activity2, 207, 0, true);
				}
			}
			else if (sender.m_BtnID2 == 14)
			{
				if (door2)
				{
					door2.OpenMenu(EGUIWindow.UI_Activity2, 208, 0, false);
				}
			}
			else if (sender.m_BtnID2 == 15)
			{
				if (this.AM.bForceNWActivity)
				{
					this.AM.SavebForceNWActivity(false);
					this.AM.CheckNWShowHint();
				}
				this.AM.Send_FEDERAL_ORDERLIST();
			}
			else if (sender.m_BtnID2 == 16)
			{
				this.AM.CheckAWActivityFlash();
				this.AM.OpenAllianceWarDetail();
			}
			else if (sender.m_BtnID2 == 17)
			{
				if (this.AM.bForceFIFAActivity)
				{
					this.AM.SavebForceFIFAActivity(false);
					this.AM.CheckFIFAShowHint();
				}
				this.AM.Send_FIFA_DETAIL((byte)sender.m_BtnID3);
			}
			else if (sender.m_BtnID2 == 18)
			{
				if (!this.AM.bClickFirstBuyActivity)
				{
					this.AM.SavebClickFirstBuyActivity();
				}
				if (door2)
				{
					door2.OpenMenu(EGUIWindow.UI_Activity3, 253, 0, false);
				}
			}
		}
	}

	// Token: 0x06000D60 RID: 3424 RVA: 0x00145F18 File Offset: 0x00144118
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x06000D61 RID: 3425 RVA: 0x00145F5C File Offset: 0x0014415C
	public float GetFillAmount()
	{
		MobilizationManager instance = MobilizationManager.Instance;
		if (instance.CompleteScore == 0u)
		{
			return 0f;
		}
		if (instance.AMCompleteDegree == 0)
		{
			return (float)(instance.AMScore / instance.CompleteScore);
		}
		MobilizationDegreeData recordByIndex = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int)(instance.AMCompleteDegree - 1));
		if (instance.AMScore == recordByIndex.MissionDegreeScore)
		{
			return 0f;
		}
		return (float)((instance.AMScore - recordByIndex.MissionDegreeScore) / (instance.CompleteScore - recordByIndex.MissionDegreeScore));
	}

	// Token: 0x04002B4B RID: 11083
	private const float Delta = 17f;

	// Token: 0x04002B4C RID: 11084
	private const float unitWidth = 199f;

	// Token: 0x04002B4D RID: 11085
	private Transform m_transform;

	// Token: 0x04002B4E RID: 11086
	private Transform ScrollT;

	// Token: 0x04002B4F RID: 11087
	private Transform ContentT;

	// Token: 0x04002B50 RID: 11088
	private RectTransform ContentRC;

	// Token: 0x04002B51 RID: 11089
	private GameObject UnitObject;

	// Token: 0x04002B52 RID: 11090
	private DataManager DM = DataManager.Instance;

	// Token: 0x04002B53 RID: 11091
	private GUIManager GM = GUIManager.Instance;

	// Token: 0x04002B54 RID: 11092
	private ActivityManager AM = ActivityManager.Instance;

	// Token: 0x04002B55 RID: 11093
	private Font tmpFont;

	// Token: 0x04002B56 RID: 11094
	private UIText BgText;

	// Token: 0x04002B57 RID: 11095
	private float NowLeft;

	// Token: 0x04002B58 RID: 11096
	private UnitComp3 NewsObj;

	// Token: 0x04002B59 RID: 11097
	private UnitComp3[] CSObj = new UnitComp3[5];

	// Token: 0x04002B5A RID: 11098
	private UnitComp3[] SPObj = new UnitComp3[5];

	// Token: 0x04002B5B RID: 11099
	private UnitComp3[] KVKObj = new UnitComp3[5];

	// Token: 0x04002B5C RID: 11100
	private UnitComp3[] FIFAObj = new UnitComp3[3];

	// Token: 0x04002B5D RID: 11101
	private UnitComp3 AMObj;

	// Token: 0x04002B5E RID: 11102
	private UnitComp3 KOWObj;

	// Token: 0x04002B5F RID: 11103
	private UnitComp3 SumObj;

	// Token: 0x04002B60 RID: 11104
	private UnitComp3 NWObj;

	// Token: 0x04002B61 RID: 11105
	private UnitComp3 AWObj;

	// Token: 0x04002B62 RID: 11106
	private UnitComp3 FBObj;

	// Token: 0x04002B63 RID: 11107
	private List<UnitComp3> AllObject = new List<UnitComp3>();

	// Token: 0x04002B64 RID: 11108
	private bool bShowFirstBuy;
}
