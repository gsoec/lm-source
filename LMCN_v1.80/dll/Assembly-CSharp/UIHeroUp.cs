using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005A0 RID: 1440
internal class UIHeroUp : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001C81 RID: 7297 RVA: 0x00325E58 File Offset: 0x00324058
	public void UpdateScrollPanel(bool bMoveToTop = true)
	{
		List<float> list = new List<float>();
		for (int i = 0; i < this.GM.m_HerodLvUpData.Count; i++)
		{
			list.Add(96f);
		}
		this.m_ScrollPanel.AddNewDataHeight(list, bMoveToTop, true);
	}

	// Token: 0x06001C82 RID: 7298 RVA: 0x00325EA8 File Offset: 0x003240A8
	public void InitUI()
	{
		for (int i = 0; i < 7; i++)
		{
			if (this.m_ScrollItem[i].Str == null)
			{
				this.m_ScrollItem[i].Str = StringManager.Instance.SpawnString(80);
			}
		}
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			Transform child = base.transform.GetChild(0);
			if (child != null)
			{
				((RectTransform)child).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
				((RectTransform)child).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
			}
		}
		this.m_Light = base.transform.GetChild(0).GetChild(4).GetComponent<Image>();
		this.m_LightTf = base.transform.GetChild(0).GetChild(4);
		UIText component = base.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
		component.font = this.TTF;
		component.text = this.DM.mStringTable.GetStringByID(5911u);
		component = base.transform.GetChild(3).GetChild(1).GetComponent<UIText>();
		component.font = this.TTF;
		component.text = this.DM.mStringTable.GetStringByID(5912u);
		if (GUIManager.Instance.IsArabic)
		{
			component.rectTransform.anchoredPosition = component.ArabicFixPos(new Vector2(64f, 210f));
		}
		UIButton component2 = base.transform.GetChild(4).GetComponent<UIButton>();
		component2.m_Handler = this;
		UIHIBtn component3 = base.transform.GetChild(2).GetChild(1).GetComponent<UIHIBtn>();
		GUIManager.Instance.InitianHeroItemImg(component3.transform, eHeroOrItem.Hero, 1, 1, 1, 1, false, false, true, false);
		this.m_ScrollPanel = base.transform.GetChild(1).GetComponent<ScrollPanel>();
		List<float> list = new List<float>();
		for (int j = 0; j < this.GM.m_HerodLvUpData.Count; j++)
		{
			list.Add(96f);
		}
		this.m_ScrollPanel.IntiScrollPanel(330f, 1f, 0f, list, 7, this);
	}

	// Token: 0x06001C83 RID: 7299 RVA: 0x00326100 File Offset: 0x00324300
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		this.GM = GUIManager.Instance;
		this.DM = DataManager.Instance;
		this.m_Door = (this.GM.FindMenu(EGUIWindow.Door) as Door);
		this.TTF = this.GM.GetTTFFont();
		this.GM.bOpenHeroLvUp = true;
		this.InitUI();
		this.GM.LoadLvUpLight(base.transform.GetChild(0).GetChild(0));
		AudioManager.Instance.PlayUISFX(UIKind.DominanceLevelup);
	}

	// Token: 0x06001C84 RID: 7300 RVA: 0x00326198 File Offset: 0x00324398
	public override void OnClose()
	{
		this.GM.bOpenHeroLvUp = false;
		this.GM.m_HerodLvUpData.Clear();
		for (int i = 0; i < 7; i++)
		{
			if (this.m_ScrollItem[i].Str != null)
			{
				StringManager.Instance.DeSpawnString(this.m_ScrollItem[i].Str);
				this.m_ScrollItem[i].Str = null;
			}
		}
		this.GM.ReleaseLvUpLight();
	}

	// Token: 0x06001C85 RID: 7301 RVA: 0x00326224 File Offset: 0x00324424
	public override void UpdateUI(int arg1, int arg2)
	{
		this.UpdateScrollPanel(false);
	}

	// Token: 0x06001C86 RID: 7302 RVA: 0x00326230 File Offset: 0x00324430
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x06001C87 RID: 7303 RVA: 0x0032625C File Offset: 0x0032445C
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 0)
		{
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_HeroUp);
			GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		}
	}

	// Token: 0x06001C88 RID: 7304 RVA: 0x0032628C File Offset: 0x0032448C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (dataIdx < this.GM.m_HerodLvUpData.Count)
		{
			ushort heroID = this.GM.m_HerodLvUpData[dataIdx].HeroID;
			byte beginLv = this.GM.m_HerodLvUpData[dataIdx].BeginLv;
			byte targetLv = this.GM.m_HerodLvUpData[dataIdx].TargetLv;
			byte circle = 0;
			if (this.DM.curHeroData.ContainsKey((uint)heroID))
			{
				circle = this.DM.curHeroData[(uint)heroID].Star;
			}
			if (this.m_ScrollItem[panelObjectIdx].HeroBtn == null)
			{
				this.m_ScrollItem[panelObjectIdx].HeroBtn = item.transform.GetChild(1).GetComponent<UIHIBtn>();
				this.m_ScrollItem[panelObjectIdx].LvText = item.transform.GetChild(2).GetComponent<UIText>();
				this.m_ScrollItem[panelObjectIdx].LvText.font = this.TTF;
				this.m_TempText[panelObjectIdx] = this.m_ScrollItem[panelObjectIdx].LvText;
			}
			GUIManager.Instance.ChangeHeroItemImg(this.m_ScrollItem[panelObjectIdx].HeroBtn.transform, eHeroOrItem.Hero, heroID, circle, 0, 0);
			this.m_ScrollItem[panelObjectIdx].Str.ClearString();
			this.m_ScrollItem[panelObjectIdx].Str.IntToFormat((long)beginLv, 1, false);
			this.m_ScrollItem[panelObjectIdx].Str.IntToFormat((long)targetLv, 1, false);
			this.m_ScrollItem[panelObjectIdx].Str.AppendFormat(this.DM.mStringTable.GetStringByID(5913u));
			this.m_ScrollItem[panelObjectIdx].LvText.text = this.m_ScrollItem[panelObjectIdx].Str.ToString();
			this.m_ScrollItem[panelObjectIdx].LvText.SetAllDirty();
			this.m_ScrollItem[panelObjectIdx].LvText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001C89 RID: 7305 RVA: 0x003264C4 File Offset: 0x003246C4
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001C8A RID: 7306 RVA: 0x003264C8 File Offset: 0x003246C8
	private void Update()
	{
		if (this.m_Light.gameObject.activeSelf)
		{
			this.m_LightTf.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
	}

	// Token: 0x06001C8B RID: 7307 RVA: 0x00326510 File Offset: 0x00324710
	private void Refresh_FontTexture()
	{
		if (this.m_TempText != null)
		{
			for (int i = 0; i < this.m_TempText.Length; i++)
			{
				if (this.m_TempText[i] != null && this.m_TempText[i].enabled)
				{
					this.m_TempText[i].enabled = false;
					this.m_TempText[i].enabled = true;
				}
			}
		}
		if (this.m_ScrollItem != null)
		{
			for (int j = 0; j < this.m_ScrollItem.Length; j++)
			{
				if (this.m_ScrollItem != null)
				{
					if (this.m_ScrollItem[j].LvText != null && this.m_ScrollItem[j].LvText.enabled)
					{
						this.m_ScrollItem[j].LvText.enabled = false;
						this.m_ScrollItem[j].LvText.enabled = true;
					}
					if (this.m_ScrollItem[j].HeroBtn != null && this.m_ScrollItem[j].HeroBtn.enabled)
					{
						this.m_ScrollItem[j].HeroBtn.Refresh_FontTexture();
					}
				}
			}
		}
	}

	// Token: 0x0400563B RID: 22075
	private const float ItemHeight = 96f;

	// Token: 0x0400563C RID: 22076
	private const float PanelHight = 330f;

	// Token: 0x0400563D RID: 22077
	private const int PanelObjCount = 7;

	// Token: 0x0400563E RID: 22078
	private const int MaxTempTextNum = 7;

	// Token: 0x0400563F RID: 22079
	private GUIManager GM;

	// Token: 0x04005640 RID: 22080
	private DataManager DM;

	// Token: 0x04005641 RID: 22081
	private Door m_Door;

	// Token: 0x04005642 RID: 22082
	private Font TTF;

	// Token: 0x04005643 RID: 22083
	private Image m_Light;

	// Token: 0x04005644 RID: 22084
	private Transform m_LightTf;

	// Token: 0x04005645 RID: 22085
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04005646 RID: 22086
	private UIHeroUp.sScrollItem[] m_ScrollItem = new UIHeroUp.sScrollItem[7];

	// Token: 0x04005647 RID: 22087
	private UIText[] m_TempText = new UIText[7];

	// Token: 0x04005648 RID: 22088
	private int m_TempTextIdx;

	// Token: 0x020005A1 RID: 1441
	private struct sScrollItem
	{
		// Token: 0x04005649 RID: 22089
		public UIHIBtn HeroBtn;

		// Token: 0x0400564A RID: 22090
		public UIText LvText;

		// Token: 0x0400564B RID: 22091
		public CString Str;
	}
}
