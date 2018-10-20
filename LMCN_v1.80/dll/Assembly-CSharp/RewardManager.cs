using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001EC RID: 492
public class RewardManager
{
	// Token: 0x060008EF RID: 2287 RVA: 0x000B6A98 File Offset: 0x000B4C98
	private RewardManager()
	{
	}

	// Token: 0x17000072 RID: 114
	// (get) Token: 0x060008F1 RID: 2289 RVA: 0x000B6AE0 File Offset: 0x000B4CE0
	public bool IsWorking
	{
		get
		{
			return this.rewardWorkingList.Count > 0;
		}
	}

	// Token: 0x17000073 RID: 115
	// (get) Token: 0x060008F2 RID: 2290 RVA: 0x000B6AF0 File Offset: 0x000B4CF0
	public static RewardManager getInstance
	{
		get
		{
			if (RewardManager.m_Self == null)
			{
				RewardManager.m_Self = new RewardManager();
			}
			return RewardManager.m_Self;
		}
	}

	// Token: 0x060008F3 RID: 2291 RVA: 0x000B6B0C File Offset: 0x000B4D0C
	public void Init(ERewardEndPoint mode = ERewardEndPoint.GambleMode)
	{
		RectTransform canvasRT = GUIManager.Instance.pDVMgr.CanvasRT;
		this.ScreenSize = canvasRT.sizeDelta;
		this.EndPointMode = ERewardEndPoint.Default;
		if (mode == ERewardEndPoint.GambleMode)
		{
			this.bezierEnd = GamblingManager.Instance.m_ItemPos;
			this.bezierEnd.y = this.ScreenSize.y + this.bezierEnd.y;
			this.EndPointMode = ERewardEndPoint.GambleMode;
		}
		else
		{
			this.bezierEnd = new Vector2(42f, this.ScreenSize.y - 79f);
		}
		this.rewardBundle = AssetManager.GetAssetBundle("Role/chest", 0L);
		GameObject gameObject = new GameObject("RewardManager");
		this.rootLayer = gameObject.AddComponent<RectTransform>();
		this.rootLayer.pivot = new Vector2(0.5f, 0.5f);
		this.rootLayer.anchorMin = new Vector2(0f, 0f);
		this.rootLayer.anchorMax = new Vector2(0f, 0f);
		this.rootLayer.SetParent(GUIManager.Instance.m_WindowsTransform, false);
		this.rootLayer.SetAsFirstSibling();
	}

	// Token: 0x060008F4 RID: 2292 RVA: 0x000B6C3C File Offset: 0x000B4E3C
	public void Free()
	{
		for (int i = 0; i < this.rewardWorkingList.Count; i++)
		{
			if (this.rewardWorkingList[i] != null)
			{
				this.rewardWorkingList[i].Destroy();
			}
		}
		this.rewardWorkingList.Clear();
		for (int j = 0; j < this.rewardFreeList.Count; j++)
		{
			if (this.rewardFreeList[j] != null)
			{
				this.rewardFreeList[j].Destroy();
			}
		}
		this.rewardFreeList.Clear();
		if (this.rootLayer != null)
		{
			UnityEngine.Object.Destroy(this.rootLayer.gameObject);
			this.rootLayer = null;
		}
		if (this.rewardBundle != null)
		{
			this.rewardBundle.Unload(true);
			this.rewardBundle = null;
		}
	}

	// Token: 0x060008F5 RID: 2293 RVA: 0x000B6D28 File Offset: 0x000B4F28
	public void Update(float deltaTime)
	{
		for (int i = this.rewardWorkingList.Count - 1; i >= 0; i--)
		{
			if (!this.rewardWorkingList[i].Update(deltaTime))
			{
				RewardNode rewardNode = this.rewardWorkingList[i];
				this.rewardWorkingList.RemoveAt(i);
				rewardNode.SetActive(false, false);
				this.rewardFreeList.Add(rewardNode);
			}
		}
	}

	// Token: 0x060008F6 RID: 2294 RVA: 0x000B6D98 File Offset: 0x000B4F98
	public void Clear()
	{
		for (int i = this.rewardWorkingList.Count - 1; i >= 0; i--)
		{
			RewardNode rewardNode = this.rewardWorkingList[i];
			this.rewardWorkingList.RemoveAt(i);
			rewardNode.SetActive(false, true);
			this.rewardFreeList.Add(rewardNode);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 1, 0);
		}
	}

	// Token: 0x060008F7 RID: 2295 RVA: 0x000B6E04 File Offset: 0x000B5004
	public void FontRefresh()
	{
		for (int i = this.rewardWorkingList.Count - 1; i >= 0; i--)
		{
			RewardNode rewardNode = this.rewardWorkingList[i];
			if (rewardNode != null)
			{
				rewardNode.FontRefresh();
			}
		}
	}

	// Token: 0x060008F8 RID: 2296 RVA: 0x000B6E48 File Offset: 0x000B5048
	public void addReward(ushort itemID, Vector3 startPos, Vector3 endPos, byte itemRank = 0)
	{
		RewardNode rewardNode;
		if (this.rewardFreeList.Count > 0)
		{
			int index = this.rewardFreeList.Count - 1;
			rewardNode = this.rewardFreeList[index];
			this.rewardFreeList.RemoveAt(index);
		}
		else
		{
			rewardNode = new RewardNode(this.rewardBundle, this.rootLayer);
		}
		rewardNode.InitNode(itemID, startPos, endPos, itemRank);
		this.rewardWorkingList.Add(rewardNode);
	}

	// Token: 0x04001DAE RID: 7598
	private AssetBundle rewardBundle;

	// Token: 0x04001DAF RID: 7599
	private List<RewardNode> rewardWorkingList = new List<RewardNode>(64);

	// Token: 0x04001DB0 RID: 7600
	private List<RewardNode> rewardFreeList = new List<RewardNode>(64);

	// Token: 0x04001DB1 RID: 7601
	public RectTransform rootLayer;

	// Token: 0x04001DB2 RID: 7602
	public Vector2 bezierEnd = Vector2.zero;

	// Token: 0x04001DB3 RID: 7603
	public Vector2 ScreenSize = Vector2.zero;

	// Token: 0x04001DB4 RID: 7604
	public ERewardEndPoint EndPointMode;

	// Token: 0x04001DB5 RID: 7605
	private static RewardManager m_Self;
}
