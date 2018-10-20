using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001ED RID: 493
public class RewardNode
{
	// Token: 0x060008F9 RID: 2297 RVA: 0x000B6EC0 File Offset: 0x000B50C0
	protected RewardNode()
	{
	}

	// Token: 0x060008FA RID: 2298 RVA: 0x000B6F18 File Offset: 0x000B5118
	public RewardNode(AssetBundle ab, RectTransform rt)
	{
		if (ab == null)
		{
			return;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(ab.mainAsset) as GameObject;
		this.rewardRoot = gameObject.transform;
		this.cap = this.rewardRoot.GetChild(0);
		this.uiRoot = rt;
		this.uiGlobalScale = GUIManager.Instance.m_UICanvas.scaleFactor;
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x000B6FC8 File Offset: 0x000B51C8
	// Note: this type is marked as 'beforefieldinit'.
	static RewardNode()
	{
		Vector2[,] array = new Vector2[4, 2];
		array[0, 0] = new Vector2(0f, 0f);
		array[0, 1] = new Vector2(-50f, -100f);
		array[1, 0] = new Vector2(0f, 0f);
		array[1, 1] = new Vector2(-50f, -100f);
		array[2, 0] = new Vector2(200f, -200f);
		array[2, 1] = new Vector2(-100f, -200f);
		array[3, 0] = new Vector2(200f, 200f);
		array[3, 1] = new Vector2(-100f, 200f);
		RewardNode.bezierCenterOffset = array;
	}

	// Token: 0x060008FC RID: 2300 RVA: 0x000B70B0 File Offset: 0x000B52B0
	public bool Update(float deltaTime)
	{
		if (this.sampleStep == 0 && this.uiStep == 0)
		{
			return false;
		}
		if (this.sampleStep == 1)
		{
			this.UpdateSampleControl();
			this.rewardRoot.position = this.Evaluate(deltaTime);
			this.timeStep += deltaTime;
			if (this.timeStep >= this.SampleTimeEnd)
			{
				this.rewardRoot.position = this.SamplePoint2;
				this.timeStep = 0f;
				this.sampleStep = 2;
			}
		}
		else if (this.sampleStep == 2)
		{
			this.timeStep += deltaTime;
			if (this.timeStep > 1f)
			{
				this.timeStep = 0f;
				this.sampleStep = 3;
			}
		}
		else if (this.sampleStep == 3)
		{
			float num = deltaTime * 180f;
			this.capAngle += num;
			this.cap.Rotate(-num, 0f, 0f);
			if (this.capAngle > 90f)
			{
				this.timeStep = 0f;
				this.sampleStep = 4;
			}
			if (this.capAngle > 45f && this.uiStep == 1)
			{
				this.iconWorldPos = this.cap.position;
				AudioManager.Instance.PlaySFX(11001, 0f, PitchKind.NoPitch, this.rewardRoot, null);
				this.createItemIcon();
				this.uiStep = 2;
			}
		}
		else if (this.sampleStep == 4)
		{
			this.timeStep += deltaTime;
			if (this.timeStep > 1f)
			{
				Vector3 position = this.rewardRoot.position;
				position.y -= deltaTime * 2f;
				this.rewardRoot.position = position;
				if (position.y < -1.5f)
				{
					this.sampleStep = 0;
					this.rewardRoot.gameObject.SetActive(false);
				}
			}
		}
		if (this.uiStep == 2)
		{
			this.uiTimeStep += deltaTime;
			Vector2 vector = Camera.main.WorldToScreenPoint(this.iconWorldPos);
			this.iconOffsetTmp = RewardNode.IconOffsetOnScaling * this.uiTimeStep;
			vector += this.iconOffsetTmp;
			vector /= this.uiGlobalScale;
			if (GUIManager.Instance.bOpenOnIPhoneX)
			{
				vector += new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			}
			if (GUIManager.Instance.IsArabic)
			{
				RectTransform canvasRT = GUIManager.Instance.pDVMgr.CanvasRT;
				vector.x -= (vector.x - canvasRT.sizeDelta.x * 0.5f) * 2f;
			}
			this.iconRt.anchoredPosition = vector;
			if (this.uiScaleStep < 0.900000036f)
			{
				this.uiScaleStep += deltaTime * 4f;
				if (this.uiScaleStep >= 0.900000036f)
				{
					this.uiScaleStep = 0.900000036f;
					this.uiStep = 3;
					this.uiTimeStep = 0f;
				}
				this.iconRt.localScale = new Vector3(this.uiScaleStep, this.uiScaleStep, this.uiScaleStep);
			}
		}
		else if (this.uiStep == 3)
		{
			Vector2 vector2 = Camera.main.WorldToScreenPoint(this.iconWorldPos);
			vector2 += this.iconOffsetTmp;
			vector2 /= this.uiGlobalScale;
			if (GUIManager.Instance.bOpenOnIPhoneX)
			{
				vector2 += new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			}
			if (GUIManager.Instance.IsArabic)
			{
				RectTransform canvasRT2 = GUIManager.Instance.pDVMgr.CanvasRT;
				vector2.x -= (vector2.x - canvasRT2.sizeDelta.x * 0.5f) * 2f;
			}
			this.iconRt.anchoredPosition = vector2;
			if (this.uiScaleStep > 0.6f)
			{
				this.uiScaleStep -= deltaTime * 3f;
				this.uiScaleStep = ((this.uiScaleStep > 0.6f) ? this.uiScaleStep : 0.6f);
				this.iconRt.localScale = new Vector3(this.uiScaleStep, this.uiScaleStep, this.uiScaleStep);
			}
			this.uiTimeStep += deltaTime;
			if (this.uiTimeStep > 1f)
			{
				this.bezierStart = vector2;
				int num2 = (RewardManager.getInstance.EndPointMode != ERewardEndPoint.Default) ? UnityEngine.Random.Range(2, 4) : UnityEngine.Random.Range(0, 2);
				this.bezierCenter = vector2 + RewardNode.bezierCenterOffset[num2, 0];
				this.bezierCenter2 = vector2 + RewardNode.bezierCenterOffset[num2, 1];
				this.uiTimeStep = 0f;
				this.uiScaleStep = 1f;
				this.uiStep = 4;
			}
		}
		else if (this.uiStep == 4)
		{
			this.iconRt.anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart, this.bezierCenter, this.bezierCenter2, RewardManager.getInstance.bezierEnd, 1.428f, this.uiTimeStep);
			float num3 = this.uiScaleStep * 0.6f;
			this.iconRt.localScale = new Vector3(num3, num3, num3);
			this.uiTimeStep += deltaTime;
			this.uiScaleStep -= deltaTime * 0.5f;
			if (this.uiTimeStep > 0.7f)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 7, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 1, 0);
				this.iconRt.gameObject.SetActive(false);
				this.uiStep = 0;
			}
		}
		return true;
	}

	// Token: 0x060008FD RID: 2301 RVA: 0x000B76C8 File Offset: 0x000B58C8
	private void createItemIcon()
	{
		if (this.iconRt == null)
		{
			GameObject gameObject = new GameObject("IconNode");
			if (this.ItemRank == 0)
			{
				this.HIObj = new GameObject("HIObj");
				this.HIObj.transform.SetParent(gameObject.transform, false);
				this.HIObj.AddComponent<UIHIBtn>();
				this.HIObj.AddComponent<Image>();
				GUIManager.Instance.InitianHeroItemImg(this.HIObj.transform, eHeroOrItem.Item, this.ItemID, 0, 0, 0, false, false, true, false);
			}
			else
			{
				this.LEObj = new GameObject("LEObj");
				this.LEObj.transform.SetParent(gameObject.transform, false);
				this.LEObj.AddComponent<UILEBtn>();
				this.LEObj.AddComponent<Image>();
				GUIManager.Instance.InitLordEquipImg(this.LEObj.transform, this.ItemID, this.ItemRank, eLordEquipDisplayKind.OnlyItem, false, false, 0, 0, 0, 0, 0, false);
			}
			gameObject.transform.SetParent(this.uiRoot, false);
			this.iconRt = gameObject.AddComponent<RectTransform>();
		}
		else
		{
			if (this.ItemRank == 0)
			{
				if (this.LEObj != null)
				{
					this.LEObj.SetActive(false);
				}
				if (this.HIObj == null)
				{
					this.HIObj = new GameObject("HIObj");
					this.HIObj.transform.SetParent(this.iconRt.gameObject.transform, false);
					this.HIObj.AddComponent<UIHIBtn>();
					this.HIObj.AddComponent<Image>();
					GUIManager.Instance.InitianHeroItemImg(this.HIObj.transform, eHeroOrItem.Item, this.ItemID, 0, 0, 0, false, false, true, false);
				}
				else
				{
					GUIManager.Instance.ChangeHeroItemImg(this.HIObj.transform, eHeroOrItem.Item, this.ItemID, 0, 0, 0);
					this.HIObj.SetActive(true);
				}
			}
			else
			{
				if (this.HIObj != null)
				{
					this.HIObj.SetActive(false);
				}
				if (this.LEObj == null)
				{
					this.LEObj = new GameObject("LEObj");
					this.LEObj.transform.SetParent(this.iconRt.gameObject.transform, false);
					this.LEObj.AddComponent<UILEBtn>();
					this.LEObj.AddComponent<Image>();
					GUIManager.Instance.InitLordEquipImg(this.LEObj.transform, this.ItemID, this.ItemRank, eLordEquipDisplayKind.OnlyItem, false, false, 0, 0, 0, 0, 0, false);
				}
				else
				{
					GUIManager.Instance.ChangeLordEquipImg(this.LEObj.transform, this.ItemID, this.ItemRank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
					this.LEObj.SetActive(true);
				}
			}
			this.iconRt.gameObject.SetActive(true);
		}
		Vector2 vector = Camera.main.WorldToScreenPoint(this.iconWorldPos);
		vector /= this.uiGlobalScale;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform canvasRT = GUIManager.Instance.pDVMgr.CanvasRT;
			vector.x -= (vector.x - canvasRT.sizeDelta.x * 0.5f) * 2f;
		}
		this.iconRt.anchoredPosition = vector;
		this.iconRt.localScale = new Vector3(0f, 0f, 0f);
		this.uiScaleStep = 0f;
		this.iconOffsetTmp = Vector2.zero;
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x000B7A6C File Offset: 0x000B5C6C
	public void FontRefresh()
	{
		if (this.iconRt != null && this.iconRt.gameObject.activeSelf && this.HIObj != null && this.HIObj.activeSelf)
		{
			UIHIBtn component = this.HIObj.GetComponent<UIHIBtn>();
			if (component != null)
			{
				component.Refresh_FontTexture();
			}
		}
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x000B7AE0 File Offset: 0x000B5CE0
	public void SetActive(bool value, bool bSetIcon = false)
	{
		this.rewardRoot.gameObject.SetActive(value);
		if (bSetIcon && this.iconRt != null)
		{
			this.iconRt.gameObject.SetActive(value);
		}
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x000B7B28 File Offset: 0x000B5D28
	public void Destroy()
	{
		if (this.rewardRoot != null)
		{
			UnityEngine.Object.Destroy(this.rewardRoot.gameObject);
			this.cap = null;
			this.rewardRoot = null;
		}
		if (this.iconRt != null)
		{
			UnityEngine.Object.Destroy(this.iconRt.gameObject);
			this.uiRoot = null;
			this.iconRt = null;
			this.LEObj = null;
			this.HIObj = null;
		}
	}

	// Token: 0x06000901 RID: 2305 RVA: 0x000B7BA4 File Offset: 0x000B5DA4
	public void InitNode(ushort itemID, Vector3 start, Vector3 end, byte itemRank = 0)
	{
		this.timeStep = 0f;
		this.sampleStep = 1;
		this.SamplePoint1 = start;
		this.SamplePoint2 = end;
		this.CurveHeight = Vector3.Distance(this.SamplePoint1, this.SamplePoint2) * 0.4f;
		this.rewardRoot.gameObject.SetActive(true);
		this.rewardRoot.rotation = new Quaternion(0f, 0f, 0f, 1f);
		this.cap.rotation = new Quaternion(0f, 0f, 0f, 1f);
		Vector3 a = new Vector3(Camera.main.transform.position.x, 0f, Camera.main.transform.position.z);
		Vector3 forward = a - start;
		this.rewardRoot.rotation = Quaternion.LookRotation(forward);
		this.capAngle = 0f;
		this.uiStep = 1;
		this.uiTimeStep = 0f;
		this.ItemID = itemID;
		this.ItemRank = itemRank;
		this.rewardRoot.localScale = Vector3.one;
		if (BattleController.IsGambleMode && BattleController.GambleMode == EGambleMode.Turbo)
		{
			this.rewardRoot.localScale = new Vector3(2f, 2f, 2f);
		}
	}

	// Token: 0x06000902 RID: 2306 RVA: 0x000B7D0C File Offset: 0x000B5F0C
	private void UpdateSampleControl()
	{
		Vector3 a = this.SamplePoint2 - this.SamplePoint1;
		this.SampleControl1 = this.SamplePoint1 + a * 0.25f;
		this.SampleControl2 = this.SamplePoint1 + a * 0.6f;
		this.SampleControl1.y = this.SampleControl1.y + this.CurveHeight;
		this.SampleControl2.y = this.SampleControl2.y + this.CurveHeight;
	}

	// Token: 0x06000903 RID: 2307 RVA: 0x000B7D94 File Offset: 0x000B5F94
	private Vector3 Evaluate(float deltaTime)
	{
		float num = 0f;
		float sampleTimeEnd = this.SampleTimeEnd;
		float d = (this.timeStep - num) / (sampleTimeEnd - num);
		Vector3 a = this.SamplePoint2 - (this.SampleControl2 - this.SampleControl1) * 3f - this.SamplePoint1;
		Vector3 a2 = 3f * (this.SampleControl2 + this.SamplePoint1) - 6f * this.SampleControl1;
		Vector3 a3 = (this.SampleControl1 - this.SamplePoint1) * 3f;
		return this.SamplePoint1 + d * (a3 + d * (a2 + d * a));
	}

	// Token: 0x04001DB6 RID: 7606
	private const float CAP_OPEN_SPEED = 180f;

	// Token: 0x04001DB7 RID: 7607
	private const float CHEST_DEEP_SPEED = 2f;

	// Token: 0x04001DB8 RID: 7608
	private const float BOX_IDLE_TIME = 1f;

	// Token: 0x04001DB9 RID: 7609
	private const float ICON_START_SCALE = 0.6f;

	// Token: 0x04001DBA RID: 7610
	private const float ICON_START_SCALE_2 = 0.900000036f;

	// Token: 0x04001DBB RID: 7611
	private static readonly Vector2 IconOffsetOnScaling = new Vector2(0f, 200f);

	// Token: 0x04001DBC RID: 7612
	private ushort ItemID;

	// Token: 0x04001DBD RID: 7613
	private byte ItemRank;

	// Token: 0x04001DBE RID: 7614
	private GameObject LEObj;

	// Token: 0x04001DBF RID: 7615
	private GameObject HIObj;

	// Token: 0x04001DC0 RID: 7616
	private float timeStep;

	// Token: 0x04001DC1 RID: 7617
	private float CurveHeight;

	// Token: 0x04001DC2 RID: 7618
	private Vector3 SamplePoint1;

	// Token: 0x04001DC3 RID: 7619
	private Vector3 SamplePoint2;

	// Token: 0x04001DC4 RID: 7620
	private Vector3 SampleControl1;

	// Token: 0x04001DC5 RID: 7621
	private Vector3 SampleControl2;

	// Token: 0x04001DC6 RID: 7622
	private byte sampleStep;

	// Token: 0x04001DC7 RID: 7623
	private float SampleTimeEnd = 0.5f;

	// Token: 0x04001DC8 RID: 7624
	private Transform rewardRoot;

	// Token: 0x04001DC9 RID: 7625
	private Transform cap;

	// Token: 0x04001DCA RID: 7626
	private float capAngle;

	// Token: 0x04001DCB RID: 7627
	private RectTransform uiRoot;

	// Token: 0x04001DCC RID: 7628
	private RectTransform iconRt;

	// Token: 0x04001DCD RID: 7629
	private Vector3 iconWorldPos = Vector3.zero;

	// Token: 0x04001DCE RID: 7630
	private byte uiStep;

	// Token: 0x04001DCF RID: 7631
	private float uiTimeStep;

	// Token: 0x04001DD0 RID: 7632
	private float uiGlobalScale;

	// Token: 0x04001DD1 RID: 7633
	private float uiScaleStep;

	// Token: 0x04001DD2 RID: 7634
	private Vector2 iconOffsetTmp = Vector2.zero;

	// Token: 0x04001DD3 RID: 7635
	private Vector2 bezierStart = Vector2.zero;

	// Token: 0x04001DD4 RID: 7636
	private Vector2 bezierCenter = Vector2.zero;

	// Token: 0x04001DD5 RID: 7637
	private Vector2 bezierCenter2 = Vector2.zero;

	// Token: 0x04001DD6 RID: 7638
	private static readonly Vector2[,] bezierCenterOffset;
}
