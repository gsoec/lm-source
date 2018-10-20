using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200041F RID: 1055
public class AffairMission : UIMissionItem
{
	// Token: 0x06001575 RID: 5493 RVA: 0x0024C7D8 File Offset: 0x0024A9D8
	public AffairMission(Transform transform, UISpritesArray spriteArray, _MissionTimeBar timebar)
	{
		this.transform = transform;
		this.TimeBar = timebar;
		this.SpriteArray = spriteArray;
		this.NameStr = StringManager.Instance.SpawnString(200);
		this.BarLink = transform.GetChild(2);
		this.ItemBtn = new UIButton[1];
		this.ItemBtn[0] = transform.GetComponent<UIButton>();
		this.ItemBtn[0].m_BtnID1 = 11;
		this.SelectTrans = transform.GetChild(4);
		this.Icon = transform.GetChild(0).GetComponent<Image>();
		this.NameText = transform.GetChild(1).GetComponent<UIText>();
		this.RewardBtn = transform.GetChild(3).GetComponent<UIButton>();
		this.RewardBtn.m_BtnID1 = 7;
		this.RewardBtn.m_Handler = this;
		this.RewardAlpha = transform.GetChild(3).GetChild(0).GetComponent<CanvasGroup>();
		this.NameText = transform.GetChild(1).GetComponent<UIText>();
		this.RewardText = transform.GetChild(3).GetChild(1).GetComponent<UIText>();
	}

	// Token: 0x06001576 RID: 5494 RVA: 0x0024C8E8 File Offset: 0x0024AAE8
	public void SetType(_eMissionType type)
	{
		this.MissionType = type;
		this.MissionData = DataManager.MissionDataManager.GetTimerMissionData(this.MissionType);
		this.VipComplete = DataManager.MissionDataManager.VipAutoComplete[(int)((byte)(this.MissionType - _eMissionType.Affair))];
		if (this.VipComplete == 1)
		{
			this.MissionData.ProcessIdx = byte.MaxValue;
			this.MissionData.MissionTime = -1L;
		}
	}

	// Token: 0x06001577 RID: 5495 RVA: 0x0024C958 File Offset: 0x0024AB58
	public override void SetMissionData(int Index)
	{
		MissionManager missionDataManager = DataManager.MissionDataManager;
		DataManager instance = DataManager.Instance;
		this.SetSelect(false, 0, null, null, null);
		this.DataIndex = Index;
		this.ItemBtn[0].m_BtnID2 = this.DataIndex;
		AffairNarrativeTbl recordByIndex;
		if (this.MissionType == _eMissionType.Affair)
		{
			recordByIndex = missionDataManager.AffairNarrativeTable.GetRecordByIndex((int)this.MissionData.TimeMission[this.DataIndex].ID);
		}
		else
		{
			recordByIndex = missionDataManager.AllianceNarrativeTable.GetRecordByIndex((int)this.MissionData.TimeMission[this.DataIndex].ID);
		}
		this.RewardBtn.m_BtnID2 = this.DataIndex;
		if (recordByIndex.Quality > 0)
		{
			this.Icon.sprite = this.SpriteArray.GetSprite((int)(recordByIndex.Quality - 1));
		}
		this.NameStr.ClearString();
		this.RewardBtn.m_BtnID2 = this.DataIndex;
		switch (recordByIndex.Quality)
		{
		case 1:
			this.NameStr.StringToFormat("<color=#dfe0e0ff>");
			break;
		case 2:
			this.NameStr.StringToFormat("<color=#51e369ff>");
			break;
		case 3:
			this.NameStr.StringToFormat("<color=#5ccff5ff>");
			break;
		case 4:
			this.NameStr.StringToFormat("<color=#c881ffff>");
			break;
		case 5:
			this.NameStr.StringToFormat("<color=#f5d94fff>");
			break;
		}
		this.NameStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByIndex.Narrative));
		this.NameStr.AppendFormat("{0}{1}</color>");
		if (this.VipComplete == 1 && (this.MissionData.TimeMission[this.DataIndex].State == _eTimerMissionState.Wait || this.MissionData.TimeMission[this.DataIndex].State == _eTimerMissionState.Countdown))
		{
			this.MissionData.TimeMission[this.DataIndex].State = _eTimerMissionState.AutoComplete;
		}
		switch (this.MissionData.TimeMission[this.DataIndex].State)
		{
		case _eTimerMissionState.Wait:
		{
			CString tmpS = missionDataManager.FormatMissionTime((uint)recordByIndex.TotalTime);
			if (this.MissionData.ProcessIdx == 255 && ((int)missionDataManager.MissionNotice & 1 << (int)((byte)this.MissionType)) == 0)
			{
				this.RewardBtn.gameObject.SetActive(true);
			}
			else
			{
				this.RewardBtn.gameObject.SetActive(false);
			}
			this.RewardText.text = instance.mStringTable.GetStringByID(1541u);
			this.RewardBtn.m_BtnID1 = 8;
			this.RewardBtn.m_BtnID2 = (int)this.MissionType;
			this.RewardBtn.m_BtnID3 = this.DataIndex;
			this.NameStr.StringToFormat("\n");
			this.NameStr.StringToFormat(tmpS);
			this.NameStr.AppendFormat("{0}{1}");
			this.RewardAlpha.alpha = 0f;
			if (this.BarLink.childCount > 0)
			{
				this.TimeBar.transform.gameObject.SetActive(false);
			}
			goto IL_5F7;
		}
		case _eTimerMissionState.Reward:
			this.RewardText.text = instance.mStringTable.GetStringByID(1542u);
			this.RewardBtn.m_BtnID1 = 7;
			this.RewardBtn.m_BtnID2 = (int)this.MissionType;
			this.RewardBtn.m_BtnID3 = this.DataIndex;
			this.RewardBtn.gameObject.SetActive(true);
			if (this.BarLink.childCount > 0)
			{
				this.TimeBar.transform.gameObject.SetActive(false);
			}
			goto IL_5F7;
		case _eTimerMissionState.Countdown:
		{
			this.RewardBtn.gameObject.SetActive(false);
			if (this.BarLink.childCount == 0)
			{
				this.TimeBar.transform.SetParent(this.BarLink);
			}
			this.TimeBar.transform.gameObject.SetActive(true);
			this.TimeBar.transform.anchoredPosition = new Vector2(21.21f, -9.34f);
			this.TimeBar.Speed.m_Handler = this;
			this.TimeBar.Speed.m_BtnID2 = (int)this.MissionType;
			this.TimeBar.Speed.m_BtnID3 = this.DataIndex;
			byte b = (this.MissionType != _eMissionType.Affair) ? 20 : 19;
			GUIManager.Instance.SetTimerBar(this.TimeBar.TimeBar, instance.queueBarData[(int)b].StartTime, instance.queueBarData[(int)b].StartTime + (long)((ulong)instance.queueBarData[(int)b].TotalTime), 0L, eTimeBarType.UIMission, this.TimeBar.TimeBar.m_Titles[0], this.TimeBar.TimeBar.m_Titles[1]);
			goto IL_5F7;
		}
		case _eTimerMissionState.AutoComplete:
			this.RewardText.text = instance.mStringTable.GetStringByID(1543u);
			this.RewardBtn.m_BtnID1 = 7;
			this.RewardBtn.m_BtnID2 = (int)this.MissionType;
			this.RewardBtn.m_BtnID3 = this.DataIndex;
			this.RewardBtn.gameObject.SetActive(true);
			if (this.BarLink.childCount > 0)
			{
				this.TimeBar.transform.gameObject.SetActive(false);
			}
			goto IL_5F7;
		}
		if (this.BarLink.childCount > 0 && this.TimeBar.Speed.m_BtnID2 != this.DataIndex)
		{
			this.TimeBar.transform.gameObject.SetActive(false);
		}
		IL_5F7:
		this.NameText.text = this.NameStr.ToString();
		this.NameText.SetAllDirty();
		this.NameText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001578 RID: 5496 RVA: 0x0024CF90 File Offset: 0x0024B190
	public override void Destroy()
	{
		StringManager.Instance.DeSpawnString(this.NameStr);
		this.NameStr = null;
	}

	// Token: 0x06001579 RID: 5497 RVA: 0x0024CFAC File Offset: 0x0024B1AC
	public override void Update()
	{
		if (this.MissionData.TimeMission[this.DataIndex].State == _eTimerMissionState.Reward || this.MissionData.TimeMission[this.DataIndex].State == _eTimerMissionState.AutoComplete)
		{
			float deltaTime = this.TimeHandle.GetDeltaTime();
			float alpha = (deltaTime <= 1f) ? deltaTime : (2f - deltaTime);
			this.RewardAlpha.alpha = alpha;
		}
	}

	// Token: 0x0600157A RID: 5498 RVA: 0x0024D02C File Offset: 0x0024B22C
	public override float GetHeight()
	{
		return 73f;
	}

	// Token: 0x0600157B RID: 5499 RVA: 0x0024D034 File Offset: 0x0024B234
	public override void SetSelect(bool bSelect, int index = 0, uint[] reward = null, ushort[] rewardItem = null, ushort[] count = null)
	{
		this.SelectTrans.gameObject.SetActive(bSelect);
		if (reward == null || !bSelect)
		{
			return;
		}
		MissionManager missionDataManager = DataManager.MissionDataManager;
		Array.Clear(reward, 0, reward.Length);
		Array.Clear(rewardItem, 0, rewardItem.Length);
		ProbabilityTbl recordByIndex = missionDataManager.ProbabilityTable.GetRecordByIndex((int)this.MissionData.TimeMission[this.DataIndex].Quality);
		byte level = GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level;
		if (this.MissionType == _eMissionType.Affair)
		{
			AffairCardinalTbl recordByIndex2 = missionDataManager.AffairCardinalTable.GetRecordByIndex((int)this.MissionData.TimeMission[this.DataIndex].Base);
			if (recordByIndex2.ResourceCardinal != null)
			{
				for (int i = 0; i < recordByIndex2.ResourceCardinal.Length; i++)
				{
					reward[3 + i] = recordByIndex2.ResourceCardinal[i] * (uint)recordByIndex.Multiple * (uint)level;
				}
			}
			reward[0] = recordByIndex2.Exp * (uint)recordByIndex.Multiple * (uint)level;
			reward[0] = DataManager.Instance.GetExpAddition(reward[0]);
		}
		else
		{
			AllianceCardinalTbl recordByIndex3 = missionDataManager.AllianceCardinalTable.GetRecordByIndex((int)this.MissionData.TimeMission[this.DataIndex].Base);
			if (recordByIndex3.ResourceCardinal != null)
			{
				for (int j = 0; j < recordByIndex3.ResourceCardinal.Length; j++)
				{
					reward[3 + j] = (uint)((ulong)(recordByIndex3.ResourceCardinal[j] * (uint)recordByIndex.Multiple * (uint)level) * (ulong)((long)missionDataManager.AllianceMissionBonusRate) / 100UL);
				}
			}
			reward[8] = (uint)((long)(recordByIndex3.AllianceMoney * (ushort)recordByIndex.Multiple) * (long)missionDataManager.AllianceMissionBonusRate / 100L);
			reward[0] = recordByIndex3.Exp * (uint)recordByIndex.Multiple * (uint)level;
			reward[0] = (uint)((ulong)DataManager.Instance.GetExpAddition(reward[0]) * (ulong)((long)missionDataManager.AllianceMissionBonusRate) / 100UL);
		}
		rewardItem[0] = this.MissionData.TimeMission[this.DataIndex].ItemID;
		if (rewardItem[0] > 0)
		{
			count[0] = 1;
		}
	}

	// Token: 0x0600157C RID: 5500 RVA: 0x0024D258 File Offset: 0x0024B458
	public override void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 6:
		{
			int arg = 19;
			if (this.MissionType == _eMissionType.Alliance)
			{
				arg = 20;
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_BagFilter, 2, arg, false);
			Debug.Log("Speed Mission");
			break;
		}
		case 7:
		{
			DataManager.MissionDataManager.sendTimeMissionReward(this.MissionType, (byte)(sender.m_BtnID3 + 1));
			RectTransform component = this.transform.parent.parent.parent.parent.GetComponent<RectTransform>();
			RectTransform component2 = this.transform.parent.parent.parent.GetComponent<RectTransform>();
			RectTransform component3 = this.transform.parent.parent.GetComponent<RectTransform>();
			RectTransform component4 = this.transform.parent.transform.GetComponent<RectTransform>();
			RectTransform component5 = this.transform.GetComponent<RectTransform>();
			RectTransform component6 = sender.transform.GetComponent<RectTransform>();
			GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x / 2f + component.anchoredPosition.x - component.sizeDelta.x / 2f + component2.anchoredPosition.x + component5.anchoredPosition.x + component6.anchoredPosition.x, GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.y / 2f - component.anchoredPosition.y - component.sizeDelta.y / 2f - component2.anchoredPosition.y - component3.anchoredPosition.y - component4.anchoredPosition.y - component6.anchoredPosition.y);
			Debug.Log("Reward Mission");
			break;
		}
		case 8:
			DataManager.MissionDataManager.sendTimeMissionStart(this.MissionType, (byte)(sender.m_BtnID3 + 1));
			break;
		}
	}

	// Token: 0x0600157D RID: 5501 RVA: 0x0024D4B0 File Offset: 0x0024B6B0
	public override void TextRefresh()
	{
		this.NameText.enabled = false;
		this.NameText.enabled = true;
		this.RewardText.enabled = false;
		this.RewardText.enabled = true;
	}

	// Token: 0x04003F92 RID: 16274
	private Transform SelectTrans;

	// Token: 0x04003F93 RID: 16275
	private Transform BarLink;

	// Token: 0x04003F94 RID: 16276
	private UISpritesArray SpriteArray;

	// Token: 0x04003F95 RID: 16277
	private Image Icon;

	// Token: 0x04003F96 RID: 16278
	private CanvasGroup RewardAlpha;

	// Token: 0x04003F97 RID: 16279
	private UIButton RewardBtn;

	// Token: 0x04003F98 RID: 16280
	private UIText NameText;

	// Token: 0x04003F99 RID: 16281
	private UIText RewardText;

	// Token: 0x04003F9A RID: 16282
	private CString NameStr;

	// Token: 0x04003F9B RID: 16283
	private TimerTypeMission MissionData;

	// Token: 0x04003F9C RID: 16284
	private _MissionTimeBar TimeBar;

	// Token: 0x04003F9D RID: 16285
	private _eMissionType MissionType;

	// Token: 0x04003F9E RID: 16286
	private byte VipComplete;

	// Token: 0x02000420 RID: 1056
	public enum UIControl
	{
		// Token: 0x04003FA0 RID: 16288
		MissionPic,
		// Token: 0x04003FA1 RID: 16289
		MissionName,
		// Token: 0x04003FA2 RID: 16290
		BarLink,
		// Token: 0x04003FA3 RID: 16291
		Reward,
		// Token: 0x04003FA4 RID: 16292
		Select
	}
}
