using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000428 RID: 1064
public class ManorMissionKind : ManorAimMission
{
	// Token: 0x0600159A RID: 5530 RVA: 0x0024E04C File Offset: 0x0024C24C
	public ManorMissionKind(Transform transform, eUIMissionKind Kind, UISpritesArray SpriteArray) : base(transform)
	{
		this.Kind = Kind;
		this.transform = transform;
		this.TitleText = transform.GetChild(0).GetComponent<UIText>();
		this.TitleText.text = DataManager.Instance.mStringTable.GetStringByID((uint)(1533 + Kind));
		this.MissionSlot = new _MissionSlot[ManorAimMission.MaxSlot];
		Image component = transform.GetComponent<Image>();
		component.sprite = SpriteArray.GetSprite(1);
		for (int i = 0; i < ManorAimMission.MaxSlot; i++)
		{
			this.MissionSlot[i] = new _MissionSlot();
			this.MissionSlot[i].Init(transform.GetChild(1 + i), this);
			this.MissionSlot[i].Reward.gameObject.SetActive(false);
			this.ItemBtn[i] = this.MissionSlot[i].ItemBtn;
			this.ItemBtn[i].m_BtnID4 = i;
			component = this.MissionSlot[i].transform.GetComponent<Image>();
			component.sprite = SpriteArray.GetSprite(3);
		}
		this.MissionData = DataManager.MissionDataManager.UIManorAimKind[(int)((byte)Kind)];
		this.MissionIDs = new ushort[ManorAimMission.MaxSlot];
	}

	// Token: 0x0600159B RID: 5531 RVA: 0x0024E180 File Offset: 0x0024C380
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
				ManorAimTbl recordByKey = missionDataManager.ManorAimTable.GetRecordByKey(this.MissionIDs[(int)num]);
				this.ItemBtn[(int)num].m_BtnID2 = this.DataIndex;
				missionDataManager.GetNarrative(cstring, ref recordByKey);
				this.MissionSlot[(int)num].SetText(cstring);
				this.MissionSlot[(int)num].Reward.m_BtnID3 = (int)this.MissionIDs[(int)num];
				this.ItemBtn[(int)num].m_BtnID3 = (int)this.MissionIDs[(int)num];
			}
			else
			{
				this.MissionSlot[(int)num].transform.gameObject.SetActive(false);
			}
			num += 1;
		}
	}

	// Token: 0x0600159C RID: 5532 RVA: 0x0024E26C File Offset: 0x0024C46C
	public override void Destroy()
	{
		for (int i = 0; i < ManorAimMission.MaxSlot; i++)
		{
			this.MissionSlot[i].Destroy();
		}
	}

	// Token: 0x0600159D RID: 5533 RVA: 0x0024E29C File Offset: 0x0024C49C
	public override float GetHeight()
	{
		this.SlotCount = 0;
		MissionManager missionDataManager = DataManager.MissionDataManager;
		int saveIndex = (int)this.MissionData.SaveIndex;
		ushort num = 0;
		while ((int)num < this.MissionSlot.Length)
		{
			if ((this.MissionIDs[this.SlotCount] = missionDataManager.GetUIMissionItemKind(this.Kind, ref saveIndex)) != 65535)
			{
				if (num == 0)
				{
					this.MissionData.SaveIndex = (ushort)(saveIndex - 1);
				}
				this.SlotCount++;
			}
			num += 1;
		}
		if (this.SlotCount == 0)
		{
			this.transform.gameObject.SetActive(false);
			return 0f;
		}
		this.transform.gameObject.SetActive(true);
		return 39f + 64f * (float)this.SlotCount;
	}

	// Token: 0x0600159E RID: 5534 RVA: 0x0024E370 File Offset: 0x0024C570
	public override void SetSelect(bool bSelect, int index, uint[] reward = null, ushort[] rewardItem = null, ushort[] count = null)
	{
		this.SelectTrans = this.MissionSlot[index].SelectTrans;
		this.SelectTrans.gameObject.SetActive(bSelect);
		base.SetSelect(bSelect, index, reward, rewardItem, count);
	}

	// Token: 0x0600159F RID: 5535 RVA: 0x0024E3B0 File Offset: 0x0024C5B0
	public override void TextRefresh()
	{
		base.TextRefresh();
		for (int i = 0; i < this.MissionSlot.Length; i++)
		{
			this.MissionSlot[i].NameText.enabled = false;
			this.MissionSlot[i].NameText.enabled = true;
		}
	}

	// Token: 0x04003FC9 RID: 16329
	private eUIMissionKind Kind;

	// Token: 0x04003FCA RID: 16330
	private _UIClassificationTbl MissionData;

	// Token: 0x04003FCB RID: 16331
	private _MissionSlot[] MissionSlot;

	// Token: 0x04003FCC RID: 16332
	private ushort[] MissionIDs;

	// Token: 0x02000429 RID: 1065
	private enum UIControl
	{
		// Token: 0x04003FCE RID: 16334
		Title,
		// Token: 0x04003FCF RID: 16335
		Mission1,
		// Token: 0x04003FD0 RID: 16336
		Mission2,
		// Token: 0x04003FD1 RID: 16337
		Mission3,
		// Token: 0x04003FD2 RID: 16338
		Mission4,
		// Token: 0x04003FD3 RID: 16339
		Mission5,
		// Token: 0x04003FD4 RID: 16340
		Select
	}
}
