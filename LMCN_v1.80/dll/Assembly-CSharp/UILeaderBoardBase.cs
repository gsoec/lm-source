using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020003A9 RID: 937
public class UILeaderBoardBase : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x0600137B RID: 4987 RVA: 0x0022B980 File Offset: 0x00229B80
	public override void OnOpen(int arg1, int arg2)
	{
		this.door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
		this.SPHeight = new List<float>();
		this.DataReady = false;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		Image component2 = this.AGS_Form.GetChild(8).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.door.LoadMaterial();
		component2.enabled = !GUIManager.Instance.bOpenOnIPhoneX;
		component2 = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close");
		component2.material = this.door.LoadMaterial();
		UIButton component3 = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		UIHIBtn component4 = this.AGS_Form.GetChild(3).GetChild(0).GetComponent<UIHIBtn>();
		component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component3 = this.AGS_Form.GetChild(11).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 7;
		component3.gameObject.SetActive(false);
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component5 = component3.transform.GetComponent<RectTransform>();
			component5.localScale = new Vector3(-1f, 1f, 1f);
		}
		component3 = this.AGS_Form.GetChild(12).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 9;
		component3.gameObject.SetActive(false);
		component3 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 2;
		component3.m_BtnID2 = 1;
		this.POPLight1 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<Image>();
		component3 = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 2;
		component3.m_BtnID2 = 2;
		this.POPLight3 = this.AGS_Form.GetChild(4).GetChild(1).GetChild(0).GetComponent<Image>();
		component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AGS_Panel1 = this.AGS_Form.GetChild(6).GetChild(0).GetComponent<ScrollPanel>();
		this.AGS_Panel1.m_ScrollPanelID = 1;
		component3 = this.AGS_Form.GetChild(6).GetChild(1).GetChild(1).GetComponent<UIButton>();
		component3.m_Handler = this;
		this.AGS_Form.GetChild(6).GetChild(1).GetChild(1).GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
		component4 = this.AGS_Form.GetChild(6).GetChild(1).GetChild(3).GetComponent<UIHIBtn>();
		component = this.AGS_Form.GetChild(6).GetChild(1).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(6).GetChild(1).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(6).GetChild(1).GetChild(6).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AGS_Panel2 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<ScrollPanel>();
		this.AGS_Panel2.m_ScrollPanelID = 2;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetChild(6).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetChild(7).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(6).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(7).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component.gameObject.SetActive(false);
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(9).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component.gameObject.SetActive(false);
		component3 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(10).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		component3 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(11).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		UIButtonHint uibuttonHint = component3.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.UIArena_Hint;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
		this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(3).gameObject.SetActive(false);
		this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(8).gameObject.SetActive(false);
		component3 = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3 = this.AGS_Form.GetChild(9).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		component3.m_BtnID1 = 99;
		component3.gameObject.SetActive(false);
		component = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(11025u);
		Transform child = this.AGS_Form.GetChild(13).GetChild(1);
		if (child != null)
		{
			child.gameObject.SetActive(false);
		}
		component = this.AGS_Form.GetChild(15).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component6 = component3.gameObject.GetComponent<RectTransform>();
			component6.localScale = new Vector3(-1f, 1f, 1f);
			component6.anchoredPosition = new Vector2(component6.anchoredPosition.x + 44f, component6.anchoredPosition.y);
			component6 = this.AGS_Form.GetChild(12).gameObject.GetComponent<RectTransform>();
			component6.localScale = new Vector3(-1f, 1f, 1f);
		}
		Transform child2 = this.AGS_Form.GetChild(3).GetChild(0);
		GUIManager.Instance.InitianHeroItemImg(child2, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, 11, 0, 0, false, false, true, false);
		child2.gameObject.SetActive(false);
		child2 = this.AGS_Form.GetChild(3).GetChild(1);
		GUIManager.Instance.InitBadgeTotem(child2, DataManager.Instance.RoleAlliance.Emblem);
		child2.gameObject.SetActive(false);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x0600137C RID: 4988 RVA: 0x0022C2D4 File Offset: 0x0022A4D4
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.Ranking);
		StringManager.Instance.DeSpawnString(this.RankValue);
		for (int i = 0; i < this.SortTextArray.GetLength(0); i++)
		{
			for (int j = 0; j < this.SortTextArray.GetLength(1); j++)
			{
				StringManager.Instance.DeSpawnString(this.SortTextArray[i, j]);
			}
		}
	}

	// Token: 0x0600137D RID: 4989 RVA: 0x0022C358 File Offset: 0x0022A558
	public virtual void OnButtonClick(UIButton sender)
	{
	}

	// Token: 0x0600137E RID: 4990 RVA: 0x0022C35C File Offset: 0x0022A55C
	public virtual void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
	}

	// Token: 0x0600137F RID: 4991 RVA: 0x0022C360 File Offset: 0x0022A560
	public virtual void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001380 RID: 4992 RVA: 0x0022C364 File Offset: 0x0022A564
	public virtual void OnButtonDown(UIButtonHint sender)
	{
	}

	// Token: 0x06001381 RID: 4993 RVA: 0x0022C368 File Offset: 0x0022A568
	public virtual void OnButtonUp(UIButtonHint sender)
	{
	}

	// Token: 0x06001382 RID: 4994 RVA: 0x0022C36C File Offset: 0x0022A56C
	protected virtual void CreateBoard()
	{
	}

	// Token: 0x06001383 RID: 4995 RVA: 0x0022C370 File Offset: 0x0022A570
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		if (this.AGS_Panel1 != null && this.AGS_Panel1.gameObject.activeInHierarchy)
		{
			Transform child = this.AGS_Panel1.transform.GetChild(0);
			for (int i = 0; i < child.childCount; i++)
			{
				Transform child2 = child.GetChild(i);
				if (child2.gameObject.activeInHierarchy)
				{
					component = child2.GetChild(4).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child2.GetChild(5).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child2.GetChild(6).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
				}
			}
		}
		if (this.AGS_Panel2 != null && this.AGS_Panel2.gameObject.activeInHierarchy)
		{
			Transform child3 = this.AGS_Panel2.transform.GetChild(0);
			for (int j = 0; j < child3.childCount; j++)
			{
				Transform child4 = child3.GetChild(j);
				if (child4.GetChild(0).gameObject.activeInHierarchy)
				{
					component = child4.GetChild(0).GetChild(4).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(0).GetChild(5).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(0).GetChild(6).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(0).GetChild(7).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
				}
				if (child4.GetChild(1).gameObject.activeInHierarchy)
				{
					component = child4.GetChild(1).GetChild(4).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(1).GetChild(5).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(1).GetChild(6).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(1).GetChild(7).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(1).GetChild(9).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
				}
			}
		}
		component = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetChild(4).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(15).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
	}

	// Token: 0x06001384 RID: 4996 RVA: 0x0022C96C File Offset: 0x0022AB6C
	protected void SetOpenType(UILeaderBoardBase.e_OpenType openType)
	{
		if (openType != UILeaderBoardBase.e_OpenType.BoardTypes)
		{
			if (openType == UILeaderBoardBase.e_OpenType.BoardContent)
			{
				this.AGS_Form.GetChild(6).gameObject.SetActive(false);
				this.AGS_Form.GetChild(7).gameObject.SetActive(true);
			}
		}
		else
		{
			this.AGS_Form.GetChild(6).gameObject.SetActive(true);
			this.AGS_Form.GetChild(7).gameObject.SetActive(false);
		}
	}

	// Token: 0x06001385 RID: 4997 RVA: 0x0022C9F4 File Offset: 0x0022ABF4
	protected void SetDefaultSize()
	{
		RectTransform component = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
		int num = UILeaderBoardBase.CommonBoardSize[0];
		RectTransform component2 = component.GetChild(0).GetChild(5).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)(num + UILeaderBoardBase.CommonBoardSize[1] / 2), component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoardBase.CommonBoardSize[1]);
		component2 = component.GetChild(0).GetChild(1).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoardBase.CommonBoardSize[1]);
		component2 = component.GetChild(1).GetChild(5).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)(num + 10), component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UILeaderBoardBase.CommonBoardSize[1] - 20));
		component2 = component.GetChild(1).GetChild(1).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoardBase.CommonBoardSize[1]);
		num += UILeaderBoardBase.CommonBoardSize[1];
		component2 = component.GetChild(0).GetChild(6).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)(num + UILeaderBoardBase.CommonBoardSize[2] / 2), component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoardBase.CommonBoardSize[2]);
		component2 = component.GetChild(0).GetChild(2).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoardBase.CommonBoardSize[2]);
		component2 = component.GetChild(1).GetChild(6).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)(num + 10), component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UILeaderBoardBase.CommonBoardSize[2] - 96));
		component2.GetComponent<UIText>().alignment = TextAnchor.MiddleRight;
		component2 = component.GetChild(1).GetChild(2).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoardBase.CommonBoardSize[2]);
	}

	// Token: 0x04003BA7 RID: 15271
	protected Transform AGS_Form;

	// Token: 0x04003BA8 RID: 15272
	protected ScrollPanel AGS_Panel1;

	// Token: 0x04003BA9 RID: 15273
	protected ScrollPanel AGS_Panel2;

	// Token: 0x04003BAA RID: 15274
	protected Door door;

	// Token: 0x04003BAB RID: 15275
	protected float GetPointTime;

	// Token: 0x04003BAC RID: 15276
	protected Image POPLight1;

	// Token: 0x04003BAD RID: 15277
	protected Image POPLight3;

	// Token: 0x04003BAE RID: 15278
	protected bool LoadComplet;

	// Token: 0x04003BAF RID: 15279
	protected bool DataReady;

	// Token: 0x04003BB0 RID: 15280
	protected List<float> SPHeight;

	// Token: 0x04003BB1 RID: 15281
	protected CString[,] SortTextArray = new CString[4, 12];

	// Token: 0x04003BB2 RID: 15282
	protected CString Ranking;

	// Token: 0x04003BB3 RID: 15283
	protected CString RankValue;

	// Token: 0x04003BB4 RID: 15284
	public static int[] TopIndex = new int[21];

	// Token: 0x04003BB5 RID: 15285
	private static readonly int[] CommonBoardSize = new int[]
	{
		102,
		385,
		289
	};

	// Token: 0x020003AA RID: 938
	protected enum e_AGS_UI_LeaderBoard_Editor
	{
		// Token: 0x04003BB7 RID: 15287
		BGFrame,
		// Token: 0x04003BB8 RID: 15288
		BGFrameTitle,
		// Token: 0x04003BB9 RID: 15289
		Laurel,
		// Token: 0x04003BBA RID: 15290
		PlayerSelf,
		// Token: 0x04003BBB RID: 15291
		SwitchTags,
		// Token: 0x04003BBC RID: 15292
		CenterText,
		// Token: 0x04003BBD RID: 15293
		FunctionlPanel,
		// Token: 0x04003BBE RID: 15294
		LeaderBoardPanel,
		// Token: 0x04003BBF RID: 15295
		exitImage,
		// Token: 0x04003BC0 RID: 15296
		iButton,
		// Token: 0x04003BC1 RID: 15297
		AMRank,
		// Token: 0x04003BC2 RID: 15298
		RankReward,
		// Token: 0x04003BC3 RID: 15299
		BoardSwitch,
		// Token: 0x04003BC4 RID: 15300
		EmptyDial,
		// Token: 0x04003BC5 RID: 15301
		ScoreChange,
		// Token: 0x04003BC6 RID: 15302
		RankUpDown
	}

	// Token: 0x020003AB RID: 939
	protected enum e_AGS_PlayerSelf
	{
		// Token: 0x04003BC8 RID: 15304
		UIHIBtn,
		// Token: 0x04003BC9 RID: 15305
		Alliance,
		// Token: 0x04003BCA RID: 15306
		Position,
		// Token: 0x04003BCB RID: 15307
		Power
	}

	// Token: 0x020003AC RID: 940
	protected enum e_AGS_SwitchTags
	{
		// Token: 0x04003BCD RID: 15309
		Players,
		// Token: 0x04003BCE RID: 15310
		Alliance
	}

	// Token: 0x020003AD RID: 941
	protected enum e_AGS_FunctionlPanel
	{
		// Token: 0x04003BD0 RID: 15312
		Panel1,
		// Token: 0x04003BD1 RID: 15313
		Panel1Item,
		// Token: 0x04003BD2 RID: 15314
		KingdomIcon
	}

	// Token: 0x020003AE RID: 942
	protected enum e_AGS_Panel1Item
	{
		// Token: 0x04003BD4 RID: 15316
		TitleBG,
		// Token: 0x04003BD5 RID: 15317
		ColBG,
		// Token: 0x04003BD6 RID: 15318
		Alliance,
		// Token: 0x04003BD7 RID: 15319
		UIHIBtn,
		// Token: 0x04003BD8 RID: 15320
		Title,
		// Token: 0x04003BD9 RID: 15321
		Name,
		// Token: 0x04003BDA RID: 15322
		Value,
		// Token: 0x04003BDB RID: 15323
		Arrow
	}

	// Token: 0x020003AF RID: 943
	protected enum e_AGS_LeaderBoardPanel
	{
		// Token: 0x04003BDD RID: 15325
		Panel2,
		// Token: 0x04003BDE RID: 15326
		Panel2Item
	}

	// Token: 0x020003B0 RID: 944
	protected enum e_AGS_Panel2Item
	{
		// Token: 0x04003BE0 RID: 15328
		Title,
		// Token: 0x04003BE1 RID: 15329
		Block
	}

	// Token: 0x020003B1 RID: 945
	public enum e_AGS_Block
	{
		// Token: 0x04003BE3 RID: 15331
		BG1,
		// Token: 0x04003BE4 RID: 15332
		BG2,
		// Token: 0x04003BE5 RID: 15333
		BG3,
		// Token: 0x04003BE6 RID: 15334
		BG4,
		// Token: 0x04003BE7 RID: 15335
		Rank,
		// Token: 0x04003BE8 RID: 15336
		Name,
		// Token: 0x04003BE9 RID: 15337
		KindVar,
		// Token: 0x04003BEA RID: 15338
		change,
		// Token: 0x04003BEB RID: 15339
		updown,
		// Token: 0x04003BEC RID: 15340
		updowntext,
		// Token: 0x04003BED RID: 15341
		SearchBtn,
		// Token: 0x04003BEE RID: 15342
		ArenaBtn,
		// Token: 0x04003BEF RID: 15343
		ArenaBGBtn
	}

	// Token: 0x020003B2 RID: 946
	protected enum e_AGS_ScoreChange
	{
		// Token: 0x04003BF1 RID: 15345
		name,
		// Token: 0x04003BF2 RID: 15346
		score,
		// Token: 0x04003BF3 RID: 15347
		scorefly,
		// Token: 0x04003BF4 RID: 15348
		updown,
		// Token: 0x04003BF5 RID: 15349
		updownRanking
	}

	// Token: 0x020003B3 RID: 947
	protected enum e_OpenType
	{
		// Token: 0x04003BF7 RID: 15351
		BoardTypes,
		// Token: 0x04003BF8 RID: 15352
		BoardContent
	}

	// Token: 0x020003B4 RID: 948
	protected enum UIRecallMemoryPos
	{
		// Token: 0x04003BFA RID: 15354
		PlayerPower,
		// Token: 0x04003BFB RID: 15355
		PlayerKills,
		// Token: 0x04003BFC RID: 15356
		AlliancePower,
		// Token: 0x04003BFD RID: 15357
		ALLianceKill,
		// Token: 0x04003BFE RID: 15358
		Arena,
		// Token: 0x04003BFF RID: 15359
		KVKKingdom,
		// Token: 0x04003C00 RID: 15360
		KVKAllianceRank,
		// Token: 0x04003C01 RID: 15361
		KVKAllianceMemberRank,
		// Token: 0x04003C02 RID: 15362
		World_PlayerPower,
		// Token: 0x04003C03 RID: 15363
		World_PlayerKills,
		// Token: 0x04003C04 RID: 15364
		World_AlliancePower,
		// Token: 0x04003C05 RID: 15365
		World_ALLianceKill,
		// Token: 0x04003C06 RID: 15366
		AlliancePublic,
		// Token: 0x04003C07 RID: 15367
		MobilizationGroupBoard,
		// Token: 0x04003C08 RID: 15368
		MobilizationAllianceBoard,
		// Token: 0x04003C09 RID: 15369
		KingOfWorldHistoryBoard,
		// Token: 0x04003C0A RID: 15370
		AllianceHunt,
		// Token: 0x04003C0B RID: 15371
		AllianceVSGroup,
		// Token: 0x04003C0C RID: 15372
		AllianceVSAlli,
		// Token: 0x04003C0D RID: 15373
		AllianceWarGroup,
		// Token: 0x04003C0E RID: 15374
		MobilizationAllianceWorldBoard,
		// Token: 0x04003C0F RID: 15375
		Max
	}
}
