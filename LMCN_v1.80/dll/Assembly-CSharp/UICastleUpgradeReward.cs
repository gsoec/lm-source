using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000525 RID: 1317
public class UICastleUpgradeReward : GUIWindow, IUIButtonClickHandler, IUIHIBtnClickHandler
{
	// Token: 0x06001A40 RID: 6720 RVA: 0x002C80A4 File Offset: 0x002C62A4
	private void Start()
	{
	}

	// Token: 0x06001A41 RID: 6721 RVA: 0x002C80A8 File Offset: 0x002C62A8
	private void Update()
	{
		this.truningLight.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
	}

	// Token: 0x06001A42 RID: 6722 RVA: 0x002C80DC File Offset: 0x002C62DC
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		Font ttffont = this.GM.GetTTFFont();
		for (int i = 0; i < 10; i++)
		{
			this.str[i] = StringManager.Instance.SpawnString(30);
		}
		CastleUpgradeRewardTbl recordByKey = this.DM.CastleUpgradeRewardTable.GetRecordByKey((ushort)arg1);
		this.mArg1 = (ushort)arg1;
		this.panel = base.transform;
		this.ExitBtn = this.panel.GetChild(2).GetComponent<RectTransform>();
		UIButton component = this.panel.GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		Transform child = this.panel.GetChild(1);
		this.truningLight = child.GetChild(0);
		UIText component2 = child.GetChild(4).GetComponent<UIText>();
		component2.text = this.DM.mStringTable.GetStringByID(5777u);
		component2.font = ttffont;
		component2 = child.GetChild(5).GetComponent<UIText>();
		component2.text = this.DM.mStringTable.GetStringByID(5797u);
		component2.font = ttffont;
		component2 = child.GetChild(3).GetComponent<UIText>();
		this.str[0].ClearString();
		this.str[0].IntToFormat((long)arg1, 2, true);
		this.str[0].AppendFormat("{0}");
		component2.text = this.str[0].ToString();
		component2.font = ttffont;
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		child = this.panel.GetChild(3);
		if (recordByKey.UnlockBuilding != 0)
		{
			component2 = child.GetChild(0).GetComponent<UIText>();
			component2.text = this.DM.mStringTable.GetStringByID(9777u);
			component2.font = ttffont;
			component2 = child.GetChild(2).GetComponent<UIText>();
			component2.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.UnlockBuilding);
			component2.font = ttffont;
		}
		else
		{
			RectTransform component3 = child.GetComponent<RectTransform>();
			Vector2 vector = component3.anchoredPosition;
			child.gameObject.SetActive(false);
			child = this.panel.GetChild(4);
			component3 = child.GetComponent<RectTransform>();
			vector -= component3.anchoredPosition;
			vector.x = 0f;
			component3.anchoredPosition += vector;
			child = this.panel.GetChild(5);
			component3 = child.GetComponent<RectTransform>();
			component3.anchoredPosition += vector;
			child = this.panel.GetChild(0);
			component3 = child.GetComponent<RectTransform>();
			float size = component3.rect.height - vector.y;
			component3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
		}
		int num = 0;
		child = this.panel.GetChild(4);
		component2 = child.GetChild(0).GetComponent<UIText>();
		component2.text = this.DM.mStringTable.GetStringByID(5779u);
		component2.font = ttffont;
		UIHIBtn component4 = child.GetChild(1).GetComponent<UIHIBtn>();
		component4.m_BtnID1 = (int)recordByKey.Item1;
		component4.m_BtnID2 = 0;
		component4.m_Handler = this;
		component4.HeroOrItem = 1;
		component4.HIID = recordByKey.Item1;
		this.GM.InitianHeroItemImg(component4.transform, eHeroOrItem.Item, recordByKey.Item1, 0, 0, 0, false, false, true, false);
		UIButtonHint uibuttonHint = component4.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.UIHIBtn;
		uibuttonHint.m_HIBtnOffset = new Vector2(25f, -25f);
		uibuttonHint.m_ForcePos = true;
		component2 = child.GetChild(2).GetComponent<UIText>();
		this.str[1].ClearString();
		this.str[1].IntToFormat((long)recordByKey.Item1Count, 1, false);
		if (this.GM.IsArabic)
		{
			this.str[1].AppendFormat("{0}x");
		}
		else
		{
			this.str[1].AppendFormat("x{0}");
		}
		component2.text = this.str[1].ToString();
		component2.font = ttffont;
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		num++;
		if (recordByKey.Item2 == 0)
		{
			child.GetChild(3).gameObject.SetActive(false);
			child.GetChild(4).gameObject.SetActive(false);
		}
		else
		{
			component4 = child.GetChild(3).GetComponent<UIHIBtn>();
			component4.m_BtnID1 = (int)recordByKey.Item2;
			component4.m_BtnID2 = 0;
			component4.m_Handler = this;
			component4.HeroOrItem = 1;
			component4.HIID = recordByKey.Item2;
			this.GM.InitianHeroItemImg(component4.transform, eHeroOrItem.Item, recordByKey.Item2, 0, 0, 0, false, true, true, false);
			uibuttonHint = component4.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.UIHIBtn;
			uibuttonHint.m_HIBtnOffset = new Vector2(25f, -25f);
			uibuttonHint.m_ForcePos = true;
			component2 = child.GetChild(4).GetComponent<UIText>();
			this.str[2].ClearString();
			this.str[2].IntToFormat((long)recordByKey.Item2Count, 1, false);
			if (this.GM.IsArabic)
			{
				this.str[2].AppendFormat("{0}x");
			}
			else
			{
				this.str[2].AppendFormat("x{0}");
			}
			component2.text = this.str[2].ToString();
			component2.font = ttffont;
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			num++;
		}
		if (recordByKey.Item3 == 0)
		{
			child.GetChild(5).gameObject.SetActive(false);
			child.GetChild(6).gameObject.SetActive(false);
		}
		else
		{
			component4 = child.GetChild(5).GetComponent<UIHIBtn>();
			component4.m_BtnID1 = (int)recordByKey.Item3;
			component4.m_BtnID2 = 0;
			component4.m_Handler = this;
			component4.HeroOrItem = 1;
			component4.HIID = recordByKey.Item3;
			this.GM.InitianHeroItemImg(component4.transform, eHeroOrItem.Item, recordByKey.Item3, 0, 0, 0, false, true, true, false);
			uibuttonHint = component4.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.UIHIBtn;
			uibuttonHint.m_HIBtnOffset = new Vector2(25f, -25f);
			uibuttonHint.m_ForcePos = true;
			component2 = child.GetChild(6).GetComponent<UIText>();
			this.str[3].ClearString();
			this.str[3].IntToFormat((long)recordByKey.Item3Count, 1, false);
			if (this.GM.IsArabic)
			{
				this.str[3].AppendFormat("{0}x");
			}
			else
			{
				this.str[3].AppendFormat("x{0}");
			}
			component2.text = this.str[3].ToString();
			component2.font = ttffont;
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			num++;
		}
		if (recordByKey.Item4 == 0)
		{
			child.GetChild(7).gameObject.SetActive(false);
			child.GetChild(8).gameObject.SetActive(false);
		}
		else
		{
			component4 = child.GetChild(7).GetComponent<UIHIBtn>();
			component4.m_BtnID1 = (int)recordByKey.Item4;
			component4.m_BtnID2 = 0;
			component4.m_Handler = this;
			component4.HeroOrItem = 1;
			component4.HIID = recordByKey.Item4;
			this.GM.InitianHeroItemImg(component4.transform, eHeroOrItem.Item, recordByKey.Item4, 0, 0, 0, false, true, true, false);
			uibuttonHint = component4.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.UIHIBtn;
			uibuttonHint.m_HIBtnOffset = new Vector2(25f, -25f);
			uibuttonHint.m_ForcePos = true;
			component2 = child.GetChild(8).GetComponent<UIText>();
			this.str[4].ClearString();
			this.str[4].IntToFormat((long)recordByKey.Item4Count, 1, false);
			if (this.GM.IsArabic)
			{
				this.str[4].AppendFormat("{0}x");
			}
			else
			{
				this.str[4].AppendFormat("x{0}");
			}
			component2.text = this.str[4].ToString();
			component2.font = ttffont;
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			num++;
		}
		float num2 = (float)(30 - 84 * num / 2);
		for (int j = 0; j < num; j++)
		{
			RectTransform component3 = child.GetChild(j * 2 + 1).GetComponent<RectTransform>();
			Vector2 vector = component3.anchoredPosition;
			vector.x = num2 + (float)(84 * j);
			component3.anchoredPosition = vector;
			component3 = child.GetChild(j * 2 + 2).GetComponent<RectTransform>();
			vector = component3.anchoredPosition;
			vector.x = num2 + (float)(84 * j) + 25f;
			component3.anchoredPosition = vector;
		}
		child = this.panel.GetChild(5);
		component2 = child.GetChild(0).GetComponent<UIText>();
		component2.text = this.DM.mStringTable.GetStringByID(5780u);
		component2.font = ttffont;
		string format;
		if (!GUIManager.Instance.IsArabic)
		{
			format = "+{0}";
		}
		else
		{
			format = "{0}+";
		}
		component2 = child.GetChild(8).GetComponent<UIText>();
		this.str[5].ClearString();
		this.str[5].IntToFormat((long)((ulong)recordByKey.Gold), 1, true);
		this.str[5].AppendFormat(format);
		component2.text = this.str[5].ToString();
		component2.font = ttffont;
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		component2 = child.GetChild(9).GetComponent<UIText>();
		this.str[6].ClearString();
		this.str[6].IntToFormat((long)((ulong)recordByKey.Grain), 1, true);
		this.str[6].AppendFormat(format);
		component2.text = this.str[6].ToString();
		component2.font = ttffont;
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		component2 = child.GetChild(10).GetComponent<UIText>();
		this.str[7].ClearString();
		this.str[7].IntToFormat((long)((ulong)recordByKey.Rock), 1, true);
		this.str[7].AppendFormat(format);
		component2.text = this.str[7].ToString();
		component2.font = ttffont;
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		component2 = child.GetChild(11).GetComponent<UIText>();
		this.str[8].ClearString();
		this.str[8].IntToFormat((long)((ulong)recordByKey.Wood), 1, true);
		this.str[8].AppendFormat(format);
		component2.text = this.str[8].ToString();
		component2.font = ttffont;
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		component2 = child.GetChild(12).GetComponent<UIText>();
		this.str[9].ClearString();
		this.str[9].IntToFormat((long)((ulong)recordByKey.Iron), 1, true);
		this.str[9].AppendFormat(format);
		component2.text = this.str[9].ToString();
		component2.font = ttffont;
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		this.panel.GetChild(1).SetAsLastSibling();
		this.panel.GetChild(1).SetAsLastSibling();
		AudioManager.Instance.PlayUISFX(UIKind.DominanceLevelup);
		int num3 = 0;
		Array.Clear(this.GM.SE_Kind, 0, this.GM.SE_Kind.Length);
		for (int k = 0; k < 5; k++)
		{
			this.GM.SE_Kind[num3] = SpeciallyEffect_Kind.Food + (int)((byte)k);
			num3++;
		}
		this.GM.m_SpeciallyEffect.mResValue[0] = recordByKey.Grain;
		this.GM.m_SpeciallyEffect.mResValue[1] = recordByKey.Rock;
		this.GM.m_SpeciallyEffect.mResValue[2] = recordByKey.Wood;
		this.GM.m_SpeciallyEffect.mResValue[3] = recordByKey.Iron;
		this.GM.m_SpeciallyEffect.mResValue[4] = recordByKey.Gold;
		Array.Clear(this.GM.SE_ItemID, 0, this.GM.SE_ItemID.Length);
		this.GM.SE_ItemID[0] = recordByKey.Item1;
		if (recordByKey.Item2 != 0)
		{
			this.GM.SE_ItemID[1] = recordByKey.Item2;
		}
		if (recordByKey.Item3 != 0)
		{
			this.GM.SE_ItemID[2] = recordByKey.Item3;
		}
		this.GM.mStartV2 = new Vector2(this.GM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, this.GM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
		this.GM.m_SpeciallyEffect.AddIconShow(this.GM.mStartV2, this.GM.SE_Kind, this.GM.SE_ItemID, true);
		this.GM.LoadLvUpLight(base.transform);
		NewbieManager.BuildCastleImmediate = false;
		if (this.GM.bOpenOnIPhoneX)
		{
			RectTransform component5 = this.panel.GetComponent<RectTransform>();
			component5.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			component5.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
	}

	// Token: 0x06001A43 RID: 6723 RVA: 0x002C8EDC File Offset: 0x002C70DC
	public override void OnClose()
	{
		for (int i = 0; i < 10; i++)
		{
			if (this.str[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.str[i]);
				this.str[i] = null;
			}
		}
		this.GM.ReleaseLvUpLight();
	}

	// Token: 0x06001A44 RID: 6724 RVA: 0x002C8F30 File Offset: 0x002C7130
	public void OnButtonClick(UIButton sender)
	{
		this.GM.CloseMenu(EGUIWindow.UI_CastleUpgradeReward);
		NewbieManager.CheckTreasBoxUpgrade();
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
	}

	// Token: 0x06001A45 RID: 6725 RVA: 0x002C8F50 File Offset: 0x002C7150
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06001A46 RID: 6726 RVA: 0x002C8F54 File Offset: 0x002C7154
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x06001A47 RID: 6727 RVA: 0x002C8F80 File Offset: 0x002C7180
	public void Refresh_FontTexture()
	{
		UIText component = this.panel.GetChild(2).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(2).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(3).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(3).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(3).GetChild(4).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(3).GetChild(6).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(3).GetChild(8).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(4).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(4).GetChild(8).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(4).GetChild(9).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(4).GetChild(10).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(4).GetChild(11).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(4).GetChild(12).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(5).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(5).GetChild(4).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.panel.GetChild(5).GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		for (int i = 0; i < this.panel.GetChild(3).childCount; i++)
		{
			UIHIBtn component2 = this.panel.GetChild(3).GetChild(i).GetComponent<UIHIBtn>();
			if (component2 != null)
			{
				component2.Refresh_FontTexture();
			}
		}
	}

	// Token: 0x04004DD1 RID: 19921
	private const int strCount = 10;

	// Token: 0x04004DD2 RID: 19922
	private Transform panel;

	// Token: 0x04004DD3 RID: 19923
	private GUIManager GM = GUIManager.Instance;

	// Token: 0x04004DD4 RID: 19924
	private DataManager DM = DataManager.Instance;

	// Token: 0x04004DD5 RID: 19925
	private Transform truningLight;

	// Token: 0x04004DD6 RID: 19926
	private CString[] str = new CString[10];

	// Token: 0x04004DD7 RID: 19927
	public RectTransform ExitBtn;

	// Token: 0x04004DD8 RID: 19928
	private ushort mArg1;
}
