using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006B0 RID: 1712
public class UIVIPLevelUP : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x060020B8 RID: 8376 RVA: 0x003E41DC File Offset: 0x003E23DC
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		byte b = (byte)arg1;
		this.LevelText = StringManager.Instance.SpawnString(50);
		this.LevelText.ClearString();
		this.LevelText.IntToFormat((long)b, 1, false);
		this.LevelText.AppendFormat("{0}");
		this.LevelUpText = StringManager.Instance.SpawnString(50);
		this.PointText = StringManager.Instance.SpawnString(50);
		this.PointText2 = StringManager.Instance.SpawnString(50);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		this.Light = this.AGS_Form.GetChild(0).GetComponent<Image>();
		this.Light.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 176);
		this.BG_Rt = (this.AGS_Form.GetChild(1) as RectTransform);
		UIButton component = this.AGS_Form.GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		this.CloseBtn = component;
		UIText component2 = this.AGS_Form.GetChild(3).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(5797u);
		this.Light = this.AGS_Form.GetChild(4).GetComponent<Image>();
		component2 = this.AGS_Form.GetChild(5).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = this.LevelText.ToString();
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component3 = this.AGS_Form.GetChild(5).GetComponent<RectTransform>();
			component3.localScale = new Vector3(-1f, 1f, 1f);
			component3.anchoredPosition = new Vector2(component3.anchoredPosition.x + 142f, component3.anchoredPosition.y);
			component3 = this.AGS_Form.GetChild(5).GetChild(0).GetComponent<RectTransform>();
			component3.localEulerAngles = new Vector3(0f, 180f, 0f);
		}
		switch (arg2)
		{
		case 0:
		{
			this.AGS_Form.GetChild(6).gameObject.SetActive(true);
			this.AGS_Form.GetChild(7).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).gameObject.SetActive(false);
			int num = arg1 >> 16;
			b = (byte)(arg1 & 65535);
			this.LevelUpText.ClearString();
			this.LevelUpText.IntToFormat((long)num, 1, false);
			this.LevelUpText.IntToFormat((long)b, 1, false);
			if (GUIManager.Instance.IsArabic)
			{
				this.LevelUpText.AppendFormat("<color=#35F76CFF>{1} VIP ←</color>{0} VIP ");
			}
			else
			{
				this.LevelUpText.AppendFormat("VIP {0} <color=#35F76CFF>→ VIP {1}</color>");
			}
			component2 = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIText>();
			component2.font = ttffont;
			component2.text = this.LevelUpText.ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			component = this.AGS_Form.GetChild(6).GetChild(2).GetComponent<UIButton>();
			component.m_Handler = this;
			component.m_EffectType = e_EffectType.e_Scale;
			component.m_BtnID1 = 1;
			component2 = this.AGS_Form.GetChild(6).GetChild(2).GetChild(0).GetComponent<UIText>();
			component2.font = ttffont;
			component2.text = DataManager.Instance.mStringTable.GetStringByID(7706u);
			if (GUIManager.Instance.IsArabic)
			{
				RectTransform component4 = this.AGS_Form.GetChild(6).GetChild(0).GetComponent<RectTransform>();
				component4.localScale = new Vector3(-1f, 1f, 1f);
				component4.anchoredPosition = new Vector2(component4.anchoredPosition.x + 52f, component4.anchoredPosition.y);
			}
			break;
		}
		case 1:
		{
			component2 = this.AGS_Form.GetChild(3).GetComponent<UIText>();
			component2.text = DataManager.Instance.mStringTable.GetStringByID(7705u);
			this.AGS_Form.GetChild(6).gameObject.SetActive(false);
			this.AGS_Form.GetChild(7).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).gameObject.SetActive(false);
			VIP_DataTbl recordByKey = DataManager.Instance.VIPLevelTable.GetRecordByKey((ushort)DataManager.Instance.RoleAttr.VIPLevel);
			int num2 = (int)(recordByKey.loginPoint + recordByKey.dailyAdd * DataManager.Instance.RoleAttr.SuccessiveLoginDays);
			if (num2 > 600)
			{
				num2 = 600;
			}
			this.PointText.ClearString();
			this.PointText.IntToFormat((long)num2, 1, false);
			this.PointText.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7742u));
			num2 += (int)recordByKey.dailyAdd;
			if (num2 > 600)
			{
				num2 = 600;
			}
			this.PointText2.ClearString();
			this.PointText2.IntToFormat((long)num2, 1, false);
			this.PointText2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7740u));
			this.LevelUpText.ClearString();
			this.LevelUpText.IntToFormat((long)(DataManager.Instance.RoleAttr.SuccessiveLoginDays + 1), 1, false);
			this.LevelUpText.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7741u));
			component2 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
			component2.font = ttffont;
			component2.text = this.PointText.ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			component2 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<UIText>();
			component2.font = ttffont;
			component2.text = this.LevelUpText.ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			component2 = this.AGS_Form.GetChild(7).GetChild(2).GetComponent<UIText>();
			component2.font = ttffont;
			component2.text = this.PointText2.ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			component2 = this.AGS_Form.GetChild(7).GetChild(3).GetComponent<UIText>();
			component2.font = ttffont;
			component2.text = DataManager.Instance.mStringTable.GetStringByID(7743u);
			break;
		}
		case 2:
		{
			this.AGS_Form.GetChild(6).gameObject.SetActive(false);
			this.AGS_Form.GetChild(7).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).gameObject.SetActive(true);
			this.LevelUpText.ClearString();
			this.LevelUpText.IntToFormat((long)(b - 1), 1, false);
			this.LevelUpText.IntToFormat((long)b, 1, false);
			if (GUIManager.Instance.IsArabic)
			{
				this.LevelUpText.AppendFormat("<color=#35F76CFF>{1} VIP ←</color>{0} VIP ");
			}
			else
			{
				this.LevelUpText.AppendFormat("VIP {0} <color=#35F76CFF>→ VIP {1}</color>");
			}
			VIP_DataTbl recordByKey2 = DataManager.Instance.VIPLevelTable.GetRecordByKey((ushort)(DataManager.Instance.RoleAttr.VIPLevel - 1));
			int num3 = (int)(recordByKey2.loginPoint + recordByKey2.dailyAdd * DataManager.Instance.RoleAttr.SuccessiveLoginDays);
			if (num3 > 600)
			{
				num3 = 600;
			}
			this.PointText.ClearString();
			this.PointText.IntToFormat((long)num3, 1, false);
			this.PointText.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7742u));
			component2 = this.AGS_Form.GetChild(8).GetChild(1).GetComponent<UIText>();
			component2.font = ttffont;
			component2.text = this.LevelUpText.ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			component2 = this.AGS_Form.GetChild(8).GetChild(2).GetComponent<UIText>();
			component2.font = ttffont;
			component2.text = this.PointText.ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			component2 = this.AGS_Form.GetChild(8).GetChild(3).GetComponent<UIText>();
			component2.font = ttffont;
			component2.text = DataManager.Instance.mStringTable.GetStringByID(7743u);
			if (GUIManager.Instance.IsArabic)
			{
				RectTransform component5 = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<RectTransform>();
				component5.localScale = new Vector3(-1f, 1f, 1f);
				component5.anchoredPosition = new Vector2(component5.anchoredPosition.x + 52f, component5.anchoredPosition.y);
			}
			break;
		}
		}
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			RectTransform component6 = this.AGS_Form.GetChild(0).GetComponent<RectTransform>();
			component6.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			component6.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		AudioManager.Instance.PlayUISFX(UIKind.DominanceLevelup);
		GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
		GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, SpeciallyEffect_Kind.AddVIP_Point, 0, 0, true, 2f);
		GUIManager.Instance.LoadLvUpLight(base.transform.GetChild(0));
	}

	// Token: 0x060020B9 RID: 8377 RVA: 0x003E4C30 File Offset: 0x003E2E30
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.LevelText);
		StringManager.Instance.DeSpawnString(this.LevelUpText);
		StringManager.Instance.DeSpawnString(this.PointText);
		StringManager.Instance.DeSpawnString(this.PointText2);
		GUIManager.Instance.ReleaseLvUpLight();
	}

	// Token: 0x060020BA RID: 8378 RVA: 0x003E4C8C File Offset: 0x003E2E8C
	private void Update()
	{
		this.Light.transform.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
	}

	// Token: 0x060020BB RID: 8379 RVA: 0x003E4CC4 File Offset: 0x003E2EC4
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x060020BC RID: 8380 RVA: 0x003E4CF0 File Offset: 0x003E2EF0
	public void OnButtonClick(UIButton sender)
	{
		GUIManager.Instance.CloseMenu(EGUIWindow.UI_VipLevelUp);
		int btnID = sender.m_BtnID1;
		if (btnID == 1)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.ClearWindowStack();
			door.OpenMenu(EGUIWindow.UI_VIP, 0, 0, false);
		}
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
	}

	// Token: 0x060020BD RID: 8381 RVA: 0x003E4D50 File Offset: 0x003E2F50
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(5).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(2).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(7).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(7).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(8).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(8).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(8).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
	}

	// Token: 0x04006750 RID: 26448
	private Transform AGS_Form;

	// Token: 0x04006751 RID: 26449
	private CString LevelText;

	// Token: 0x04006752 RID: 26450
	private CString LevelUpText;

	// Token: 0x04006753 RID: 26451
	private CString PointText;

	// Token: 0x04006754 RID: 26452
	private CString PointText2;

	// Token: 0x04006755 RID: 26453
	private Image Light;

	// Token: 0x04006756 RID: 26454
	public UIButton CloseBtn;

	// Token: 0x04006757 RID: 26455
	public RectTransform BG_Rt;

	// Token: 0x020006B1 RID: 1713
	private enum e_AGS_UI_VIPLevelUP_Editor
	{
		// Token: 0x04006759 RID: 26457
		BackCover,
		// Token: 0x0400675A RID: 26458
		BG,
		// Token: 0x0400675B RID: 26459
		CloseBtn,
		// Token: 0x0400675C RID: 26460
		Title,
		// Token: 0x0400675D RID: 26461
		Light,
		// Token: 0x0400675E RID: 26462
		VIPICON,
		// Token: 0x0400675F RID: 26463
		LVUPGroup,
		// Token: 0x04006760 RID: 26464
		EXPGroup,
		// Token: 0x04006761 RID: 26465
		DailyGroup
	}

	// Token: 0x020006B2 RID: 1714
	private enum e_AGS_LVUPGroup
	{
		// Token: 0x04006763 RID: 26467
		SmallVip,
		// Token: 0x04006764 RID: 26468
		LevelText,
		// Token: 0x04006765 RID: 26469
		UIButton
	}

	// Token: 0x020006B3 RID: 1715
	private enum e_AGS_EXPGroup
	{
		// Token: 0x04006767 RID: 26471
		AcqurePoint,
		// Token: 0x04006768 RID: 26472
		Contiune,
		// Token: 0x04006769 RID: 26473
		Tomorrow,
		// Token: 0x0400676A RID: 26474
		Tips
	}

	// Token: 0x020006B4 RID: 1716
	private enum e_AGS_DailyGroup
	{
		// Token: 0x0400676C RID: 26476
		SmallVip,
		// Token: 0x0400676D RID: 26477
		LevelText,
		// Token: 0x0400676E RID: 26478
		AcqurePoint,
		// Token: 0x0400676F RID: 26479
		Tips
	}
}
