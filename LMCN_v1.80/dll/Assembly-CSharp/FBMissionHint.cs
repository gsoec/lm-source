using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020003FC RID: 1020
public class FBMissionHint
{
	// Token: 0x060014FA RID: 5370 RVA: 0x0023FDE4 File Offset: 0x0023DFE4
	public FBMissionHint(Transform transform, Font font)
	{
		this.gameobject = transform.gameObject;
		this.NameText = transform.GetChild(0).GetComponent<UIText>();
		this.NameText.font = font;
		this.TitleText = transform.GetChild(1).GetComponent<UIText>();
		this.TitleText.font = font;
		this.TitleText.text = DataManager.Instance.mStringTable.GetStringByID(12157u);
		this.MissionItem[0] = new _UIFBMissionAim(transform.GetChild(2), font);
		this.MissionItem[1] = new _UIFBMissionAim(transform.GetChild(3), font);
		this.DeliverRect = (transform.GetChild(4) as RectTransform);
		this.DeliverObj = this.DeliverRect.gameObject;
		this.MissionPrice[0] = new _UIFBMissionPrice(transform.GetChild(5), font);
		this.MissionPrice[1] = new _UIFBMissionPrice(transform.GetChild(6), font);
		this.MissionPrice[0].SetTitle(DataManager.Instance.mStringTable.GetStringByID(12164u));
		this.MissionPrice[1].SetTitle(DataManager.Instance.mStringTable.GetStringByID(12158u));
	}

	// Token: 0x060014FB RID: 5371 RVA: 0x0023FF68 File Offset: 0x0023E168
	public void Show(ushort ID)
	{
		this.gameobject.SetActive(true);
		FBMissionTbl recordByKey = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(ID);
		this.NameText.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.Name);
		this.MissionItem[0].Set(ref recordByKey, 0);
		this.MissionItem[1].Set(ref recordByKey, 1);
		this.MissionItem[1].Top = -(-this.MissionItem[0].Top + this.MissionItem[0].Height + 5f);
		this.OwnPriceID = recordByKey.OwnPrice;
		this.FriendPriceID = recordByKey.FriendPrice;
		this.MissionPrice[0].Show(this.OwnPriceID);
		this.MissionPrice[1].Show(this.FriendPriceID);
		if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 7)
		{
			this.SetStyle(FBMissionHint._Style.OwnPrice, this.MissionItem[1].Top - this.MissionItem[1].Height);
		}
		else if (!DataManager.FBMissionDataManager.IsInTime() || DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex == 12)
		{
			this.SetStyle(FBMissionHint._Style.FriendPrice, this.MissionItem[1].Top - this.MissionItem[1].Height);
		}
		else
		{
			this.SetStyle(FBMissionHint._Style.Both, this.MissionItem[1].Top - this.MissionItem[1].Height);
		}
	}

	// Token: 0x060014FC RID: 5372 RVA: 0x0024012C File Offset: 0x0023E32C
	private void SetStyle(FBMissionHint._Style style, float beginTop)
	{
		if (style == FBMissionHint._Style.OwnPrice)
		{
			beginTop -= 28f;
			this.DeliverObj.SetActive(false);
			this.MissionPrice[0].Show(this.OwnPriceID);
			this.MissionPrice[0].Top = beginTop;
			this.MissionPrice[1].Hide();
			this.Height = -beginTop + 97f + 30f;
		}
		else if (style == FBMissionHint._Style.FriendPrice)
		{
			beginTop -= 26f;
			this.DeliverObj.SetActive(true);
			this.DeliverRect.anchoredPosition = new Vector2(this.DeliverRect.anchoredPosition.x, beginTop);
			this.MissionPrice[0].Hide();
			this.MissionPrice[1].Show(this.FriendPriceID);
			this.MissionPrice[1].Top = beginTop - this.DeliverRect.sizeDelta.y - 18f;
			this.Height = -this.MissionPrice[1].Top + 97f + 30f;
		}
		else if (style == FBMissionHint._Style.Both)
		{
			beginTop -= 28f;
			this.MissionPrice[0].Show(this.OwnPriceID);
			this.MissionPrice[0].Top = beginTop;
			this.DeliverObj.SetActive(true);
			this.DeliverRect.anchoredPosition = new Vector2(this.DeliverRect.anchoredPosition.x, this.MissionPrice[0].Top - 97f - 18f);
			this.MissionPrice[1].Show(this.FriendPriceID);
			this.MissionPrice[1].Top = this.DeliverRect.anchoredPosition.y - this.DeliverRect.sizeDelta.y - 18f;
			this.Height = -this.MissionPrice[1].Top + 97f + 30f;
		}
	}

	// Token: 0x060014FD RID: 5373 RVA: 0x00240364 File Offset: 0x0023E564
	public void Hide()
	{
		this.gameobject.SetActive(false);
	}

	// Token: 0x060014FE RID: 5374 RVA: 0x00240374 File Offset: 0x0023E574
	public void TextRefresh()
	{
		this.NameText.enabled = false;
		this.NameText.enabled = true;
		this.TitleText.enabled = false;
		this.TitleText.enabled = true;
		this.MissionItem[0].TextRefresh();
		this.MissionItem[1].TextRefresh();
		this.MissionPrice[0].TextRefresh();
		this.MissionPrice[1].TextRefresh();
	}

	// Token: 0x060014FF RID: 5375 RVA: 0x002403F8 File Offset: 0x0023E5F8
	public void Destroy()
	{
		this.MissionItem[0].OnClose();
		this.MissionItem[1].OnClose();
		this.MissionPrice[0].OnClose();
		this.MissionPrice[1].OnClose();
	}

	// Token: 0x06001500 RID: 5376 RVA: 0x0024044C File Offset: 0x0023E64C
	public void UpdateData()
	{
		if (!this.gameobject.activeSelf)
		{
			return;
		}
		this.MissionItem[0].UpdateData();
		this.MissionItem[1].UpdateData();
	}

	// Token: 0x04003DD8 RID: 15832
	public GameObject gameobject;

	// Token: 0x04003DD9 RID: 15833
	private GameObject DeliverObj;

	// Token: 0x04003DDA RID: 15834
	private RectTransform DeliverRect;

	// Token: 0x04003DDB RID: 15835
	private _UIFBMissionAim[] MissionItem = new _UIFBMissionAim[2];

	// Token: 0x04003DDC RID: 15836
	private _UIFBMissionPrice[] MissionPrice = new _UIFBMissionPrice[2];

	// Token: 0x04003DDD RID: 15837
	private UIText TitleText;

	// Token: 0x04003DDE RID: 15838
	private UIText NameText;

	// Token: 0x04003DDF RID: 15839
	public float Height;

	// Token: 0x04003DE0 RID: 15840
	public float Width = 437f;

	// Token: 0x04003DE1 RID: 15841
	private ushort OwnPriceID;

	// Token: 0x04003DE2 RID: 15842
	private ushort FriendPriceID;

	// Token: 0x020003FD RID: 1021
	private enum UIControl
	{
		// Token: 0x04003DE4 RID: 15844
		Name,
		// Token: 0x04003DE5 RID: 15845
		Title,
		// Token: 0x04003DE6 RID: 15846
		Item1,
		// Token: 0x04003DE7 RID: 15847
		Item2,
		// Token: 0x04003DE8 RID: 15848
		Deliver,
		// Token: 0x04003DE9 RID: 15849
		OwnPrice,
		// Token: 0x04003DEA RID: 15850
		FriendPrice
	}

	// Token: 0x020003FE RID: 1022
	private enum _Style
	{
		// Token: 0x04003DEC RID: 15852
		OwnPrice,
		// Token: 0x04003DED RID: 15853
		FriendPrice,
		// Token: 0x04003DEE RID: 15854
		Both
	}
}
