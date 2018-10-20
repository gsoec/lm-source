using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000426 RID: 1062
public class AchieveTarget : ManorAimMission
{
	// Token: 0x06001592 RID: 5522 RVA: 0x0024DA50 File Offset: 0x0024BC50
	public AchieveTarget(Transform transform, Sprite Background) : base(transform)
	{
		this.transform = transform;
		this.TitleText = transform.GetChild(0).GetComponent<UIText>();
		this.TitleText.text = DataManager.Instance.mStringTable.GetStringByID(1532u);
		this.MissionSlot = new _MissionSlot[ManorAimMission.MaxSlot];
		this.BtnText = new UIText[ManorAimMission.MaxSlot];
		Image component = transform.GetComponent<Image>();
		component.sprite = Background;
		for (int i = 0; i < ManorAimMission.MaxSlot; i++)
		{
			this.MissionSlot[i] = new _MissionSlot();
			this.MissionSlot[i].Init(transform.GetChild(1 + i), this);
			this.ItemBtn[i] = this.MissionSlot[i].ItemBtn;
			this.ItemBtn[i].m_BtnID2 = 1;
			this.ItemBtn[i].m_BtnID4 = i;
			this.BtnText[i] = this.MissionSlot[i].transform.GetChild(1).GetChild(1).GetComponent<UIText>();
		}
	}

	// Token: 0x06001593 RID: 5523 RVA: 0x0024DB5C File Offset: 0x0024BD5C
	public override void SetMissionData(int Index)
	{
		if (!this.transform.gameObject.activeSelf)
		{
			return;
		}
		this.DataIndex = Index;
		MissionManager missionDataManager = DataManager.MissionDataManager;
		CString cstring = StringManager.Instance.StaticString1024();
		ushort num = 0;
		while ((int)num < this.MissionSlot.Length)
		{
			if (this.SlotCount > (int)num)
			{
				ushort missionID = missionDataManager.GetMissionID(missionDataManager.RewardList.Priority[(int)num]);
				ManorAimTbl recordByKey = missionDataManager.ManorAimTable.GetRecordByKey(missionID);
				missionDataManager.GetNarrative(cstring, ref recordByKey);
				this.MissionSlot[(int)num].TimdHandle = this.TimeHandle;
				this.MissionSlot[(int)num].SetText(cstring);
				this.MissionSlot[(int)num].transform.gameObject.SetActive(true);
				this.MissionSlot[(int)num].Reward.m_BtnID3 = (int)missionID;
				this.ItemBtn[(int)num].m_BtnID3 = (int)missionID;
			}
			else
			{
				this.MissionSlot[(int)num].transform.gameObject.SetActive(false);
			}
			num += 1;
		}
	}

	// Token: 0x06001594 RID: 5524 RVA: 0x0024DC70 File Offset: 0x0024BE70
	public override void Destroy()
	{
		for (int i = 0; i < ManorAimMission.MaxSlot; i++)
		{
			this.MissionSlot[i].Destroy();
		}
	}

	// Token: 0x06001595 RID: 5525 RVA: 0x0024DCA0 File Offset: 0x0024BEA0
	public override void Update()
	{
		for (int i = 0; i < ManorAimMission.MaxSlot; i++)
		{
			this.MissionSlot[i].Update();
		}
	}

	// Token: 0x06001596 RID: 5526 RVA: 0x0024DCD0 File Offset: 0x0024BED0
	public override float GetHeight()
	{
		this.SlotCount = (int)DataManager.MissionDataManager.GetRewardCount(ManorAimMission.MaxSlot);
		if (this.SlotCount == 0)
		{
			this.transform.gameObject.SetActive(false);
			return 0f;
		}
		this.transform.gameObject.SetActive(true);
		return 39f + 64f * (float)this.SlotCount;
	}

	// Token: 0x06001597 RID: 5527 RVA: 0x0024DD38 File Offset: 0x0024BF38
	public override void SetSelect(bool bSelect, int index, uint[] reward = null, ushort[] rewardItem = null, ushort[] count = null)
	{
		this.SelectTrans = this.MissionSlot[index].SelectTrans;
		this.SelectTrans.gameObject.SetActive(bSelect);
		base.SetSelect(bSelect, index, reward, rewardItem, count);
	}

	// Token: 0x06001598 RID: 5528 RVA: 0x0024DD78 File Offset: 0x0024BF78
	public override void OnButtonClick(UIButton sender)
	{
		ushort num = (ushort)sender.m_BtnID3;
		ManorAimTbl recordByKey = DataManager.MissionDataManager.ManorAimTable.GetRecordByKey(num);
		if (recordByKey.MissionKind - 1 == 0)
		{
			DataManager.MissionDataManager.sendMissionComplete(num, GUIManager.Instance.BuildingData.GetBuildData(recordByKey.Parm1, 0).ManorID);
		}
		else
		{
			DataManager.MissionDataManager.sendMissionComplete(num, 0);
		}
		RectTransform component = this.transform.parent.parent.parent.parent.GetComponent<RectTransform>();
		RectTransform component2 = this.transform.parent.parent.parent.GetComponent<RectTransform>();
		RectTransform component3 = this.transform.parent.GetComponent<RectTransform>();
		RectTransform component4 = this.transform.GetComponent<RectTransform>();
		RectTransform component5 = sender.transform.parent.GetComponent<RectTransform>();
		RectTransform component6 = sender.transform.GetComponent<RectTransform>();
		RectTransform component7 = this.transform.parent.parent.GetComponent<RectTransform>();
		GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x / 2f + component.anchoredPosition.x - component.sizeDelta.x / 2f + component2.anchoredPosition.x + component3.anchoredPosition.x + component4.anchoredPosition.x + component5.anchoredPosition.x + component6.anchoredPosition.x, GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.y / 2f - component7.anchoredPosition.y - component.anchoredPosition.y - component.sizeDelta.y / 2f - component2.anchoredPosition.y - component3.anchoredPosition.y - component4.anchoredPosition.y - component5.anchoredPosition.y - component6.anchoredPosition.y);
	}

	// Token: 0x06001599 RID: 5529 RVA: 0x0024DFDC File Offset: 0x0024C1DC
	public override void TextRefresh()
	{
		base.TextRefresh();
		for (int i = 0; i < this.MissionSlot.Length; i++)
		{
			this.MissionSlot[i].NameText.enabled = false;
			this.MissionSlot[i].NameText.enabled = true;
			this.BtnText[i].enabled = false;
			this.BtnText[i].enabled = true;
		}
	}

	// Token: 0x04003FBF RID: 16319
	private _MissionSlot[] MissionSlot;

	// Token: 0x04003FC0 RID: 16320
	private UIText[] BtnText;

	// Token: 0x02000427 RID: 1063
	public enum UIControl
	{
		// Token: 0x04003FC2 RID: 16322
		Title,
		// Token: 0x04003FC3 RID: 16323
		Mission1,
		// Token: 0x04003FC4 RID: 16324
		Mission2,
		// Token: 0x04003FC5 RID: 16325
		Mission3,
		// Token: 0x04003FC6 RID: 16326
		Mission4,
		// Token: 0x04003FC7 RID: 16327
		Mission5,
		// Token: 0x04003FC8 RID: 16328
		Select
	}
}
