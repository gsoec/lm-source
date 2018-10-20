using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000424 RID: 1060
public class ReCommandMission : ManorAimMission
{
	// Token: 0x0600158C RID: 5516 RVA: 0x0024D838 File Offset: 0x0024BA38
	public ReCommandMission(Transform transform, UISpritesArray SpriteArray) : base(transform)
	{
		this.transform = transform;
		this.SpriteArray = SpriteArray;
		this.TitleText = transform.GetChild(0).GetComponent<UIText>();
		this.TitleText.text = DataManager.Instance.mStringTable.GetStringByID(1531u);
		this.MissionPic = transform.GetChild(2).GetComponent<Image>();
		this.MissionName = transform.GetChild(3).GetComponent<UIText>();
		this.NarrativeStr = StringManager.Instance.SpawnString(100);
		this.SelectTrans = transform.GetChild(4);
		this.ItemBtn[0] = transform.GetChild(1).GetComponent<UIButton>();
		this.ItemBtn[0].m_BtnID1 = 11;
	}

	// Token: 0x0600158D RID: 5517 RVA: 0x0024D8F4 File Offset: 0x0024BAF4
	public override void SetMissionData(int Index)
	{
		if (!this.transform.gameObject.activeSelf)
		{
			return;
		}
		MissionManager missionDataManager = DataManager.MissionDataManager;
		ushort reCommandMissionID = missionDataManager.GetReCommandMissionID();
		this.ItemBtn[0].m_BtnID3 = (int)reCommandMissionID;
		ManorAimTbl recordByKey = missionDataManager.ManorAimTable.GetRecordByKey(reCommandMissionID);
		missionDataManager.GetNarrative(this.NarrativeStr, ref recordByKey);
		this.MissionName.text = this.NarrativeStr.ToString();
		this.MissionName.SetAllDirty();
		this.MissionName.cachedTextGenerator.Invalidate();
		this.MissionPic.sprite = this.SpriteArray.GetSprite((int)(6 + recordByKey.UIKind));
	}

	// Token: 0x0600158E RID: 5518 RVA: 0x0024D9A0 File Offset: 0x0024BBA0
	public override void Destroy()
	{
		StringManager.Instance.DeSpawnString(this.NarrativeStr);
	}

	// Token: 0x0600158F RID: 5519 RVA: 0x0024D9B4 File Offset: 0x0024BBB4
	public override float GetHeight()
	{
		if (DataManager.MissionDataManager.GetReCommandMissionID() == 65535)
		{
			this.transform.gameObject.SetActive(false);
			return 0f;
		}
		this.transform.gameObject.SetActive(true);
		return 136f;
	}

	// Token: 0x06001590 RID: 5520 RVA: 0x0024DA04 File Offset: 0x0024BC04
	public override void SetSelect(bool bSelect, int index = 0, uint[] reward = null, ushort[] rewardItem = null, ushort[] count = null)
	{
		this.SelectTrans.gameObject.SetActive(bSelect);
		base.SetSelect(bSelect, index, reward, rewardItem, count);
	}

	// Token: 0x06001591 RID: 5521 RVA: 0x0024DA30 File Offset: 0x0024BC30
	public override void TextRefresh()
	{
		base.TextRefresh();
		this.MissionName.enabled = false;
		this.MissionName.enabled = true;
	}

	// Token: 0x04003FB5 RID: 16309
	private Image MissionPic;

	// Token: 0x04003FB6 RID: 16310
	private UIText MissionName;

	// Token: 0x04003FB7 RID: 16311
	private CString NarrativeStr;

	// Token: 0x04003FB8 RID: 16312
	private UISpritesArray SpriteArray;

	// Token: 0x02000425 RID: 1061
	public enum UIControl
	{
		// Token: 0x04003FBA RID: 16314
		Title,
		// Token: 0x04003FBB RID: 16315
		Background,
		// Token: 0x04003FBC RID: 16316
		MissionPic,
		// Token: 0x04003FBD RID: 16317
		MissionName,
		// Token: 0x04003FBE RID: 16318
		Select
	}
}
