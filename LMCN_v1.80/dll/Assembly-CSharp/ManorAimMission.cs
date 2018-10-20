using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000423 RID: 1059
public class ManorAimMission : UIMissionItem
{
	// Token: 0x06001583 RID: 5507 RVA: 0x0024D6AC File Offset: 0x0024B8AC
	public ManorAimMission(Transform transform)
	{
		this.transform = transform;
		this.ItemBtn = new UIButton[ManorAimMission.MaxSlot];
	}

	// Token: 0x06001585 RID: 5509 RVA: 0x0024D6D4 File Offset: 0x0024B8D4
	public override void SetMissionData(int Index)
	{
	}

	// Token: 0x06001586 RID: 5510 RVA: 0x0024D6D8 File Offset: 0x0024B8D8
	public override void Destroy()
	{
	}

	// Token: 0x06001587 RID: 5511 RVA: 0x0024D6DC File Offset: 0x0024B8DC
	public override void Update()
	{
	}

	// Token: 0x06001588 RID: 5512 RVA: 0x0024D6E0 File Offset: 0x0024B8E0
	public override float GetHeight()
	{
		return 106f;
	}

	// Token: 0x06001589 RID: 5513 RVA: 0x0024D6E8 File Offset: 0x0024B8E8
	public override void SetSelect(bool bSelect, int index = 0, uint[] reward = null, ushort[] rewardItem = null, ushort[] count = null)
	{
		if (reward == null || !bSelect)
		{
			return;
		}
		Array.Clear(reward, 0, reward.Length);
		Array.Clear(rewardItem, 0, rewardItem.Length);
		Array.Clear(count, 0, count.Length);
		uint effectBaseValByEffectID = DataManager.Instance.AttribVal.GetEffectBaseValByEffectID(304);
		if (!this.transform.gameObject.activeSelf)
		{
			return;
		}
		MissionManager missionDataManager = DataManager.MissionDataManager;
		ManorAimTbl recordByKey = missionDataManager.ManorAimTable.GetRecordByKey((ushort)this.ItemBtn[index].m_BtnID3);
		for (int i = 0; i < recordByKey.RewardResource.Length; i++)
		{
			reward[3 + i] = recordByKey.RewardResource[i];
		}
		for (int j = 0; j < recordByKey.RewardItems.Length; j++)
		{
			rewardItem[j] = recordByKey.RewardItems[j].ItemID;
			count[j] = (ushort)recordByKey.RewardItems[j].Quantity;
		}
		reward[1] = recordByKey.Force;
		reward[0] = recordByKey.Exp;
		reward[0] = reward[0] * (10000u + effectBaseValByEffectID) / 10000u;
		reward[2] = (uint)recordByKey.RewardMorale;
	}

	// Token: 0x0600158A RID: 5514 RVA: 0x0024D818 File Offset: 0x0024BA18
	public override void OnButtonClick(UIButton sender)
	{
	}

	// Token: 0x0600158B RID: 5515 RVA: 0x0024D81C File Offset: 0x0024BA1C
	public override void TextRefresh()
	{
		this.TitleText.enabled = false;
		this.TitleText.enabled = true;
	}

	// Token: 0x04003FB1 RID: 16305
	protected Transform SelectTrans;

	// Token: 0x04003FB2 RID: 16306
	protected UIText TitleText;

	// Token: 0x04003FB3 RID: 16307
	public static readonly int MaxSlot = 5;

	// Token: 0x04003FB4 RID: 16308
	public int SlotCount;
}
