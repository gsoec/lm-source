using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005B6 RID: 1462
public class UIJail : GUIWindow, IBuildingWindowType, IUpDateScrollPanel, IUIButtonClickHandler, IUIHIBtnClickHandler
{
	// Token: 0x06001D11 RID: 7441 RVA: 0x0034288C File Offset: 0x00340A8C
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
		this.B_ID = (ushort)arg1;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIText component = this.AGS_Form.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7752u);
		component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component = this.AGS_Form.GetChild(2).GetChild(4).GetChild(0).GetComponent<UIText>();
		component.text = this.DM.mStringTable.GetStringByID(7753u);
		component.font = ttffont;
		component = this.AGS_Form.GetChild(2).GetChild(4).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component = this.AGS_Form.GetChild(2).GetChild(4).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		this.AGS_ScrollPanel = this.AGS_Form.GetChild(3).GetComponent<ScrollPanel>();
		component = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIText>();
		component.text = this.DM.mStringTable.GetStringByID(7755u);
		component.font = ttffont;
		component = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIText>();
		component.text = this.DM.mStringTable.GetStringByID(7756u);
		component.font = ttffont;
		this.AGS_Form.GetChild(5).gameObject.SetActive(false);
		component = this.AGS_Form.GetChild(5).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component = this.AGS_Form.GetChild(5).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component = this.AGS_Form.GetChild(5).GetChild(8).GetComponent<UIText>();
		component.font = ttffont;
		component = this.AGS_Form.GetChild(5).GetChild(9).GetComponent<UIText>();
		component.font = ttffont;
		UIButton component2 = this.AGS_Form.GetChild(5).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		for (int i = 0; i < 4; i++)
		{
			this.tmpString[i] = StringManager.Instance.SpawnString(30);
		}
		for (int j = 0; j < 4; j++)
		{
			this.SPName[j] = StringManager.Instance.SpawnString(30);
			this.SPLv[j] = StringManager.Instance.SpawnString(30);
			this.SPTime[j] = StringManager.Instance.SpawnString(30);
			this.SPStat[j] = StringManager.Instance.SpawnString(30);
		}
		this.updatePrisonerAmount();
		this.updateEff();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		if (!this.DM.Prisoner_Requested)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_PRISONER_LIST;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
		}
		else
		{
			this.UpdateScrollPanel(false);
			this.updateScrollPanelTimeBar();
		}
	}

	// Token: 0x06001D12 RID: 7442 RVA: 0x00342C20 File Offset: 0x00340E20
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		for (int i = 0; i < 4; i++)
		{
			StringManager.Instance.DeSpawnString(this.tmpString[i]);
		}
		for (int j = 0; j < 4; j++)
		{
			StringManager.Instance.DeSpawnString(this.SPName[j]);
			StringManager.Instance.DeSpawnString(this.SPLv[j]);
			StringManager.Instance.DeSpawnString(this.SPTime[j]);
			StringManager.Instance.DeSpawnString(this.SPStat[j]);
		}
	}

	// Token: 0x06001D13 RID: 7443 RVA: 0x00342CCC File Offset: 0x00340ECC
	public override void UpdateUI(int arg1, int arg2)
	{
		this.updatePrisonerAmount();
		this.updateEff();
		this.UpdateScrollPanel(false);
		this.updateScrollPanelTimeBar();
	}

	// Token: 0x06001D14 RID: 7444 RVA: 0x00342CE8 File Offset: 0x00340EE8
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_BuildBase)
			{
				if (networkNews != NetworkNews.Refresh_AttribEffectVal)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						if (this.baseBuild != null)
						{
							this.baseBuild.Refresh_FontTexture();
						}
						this.Refresh_FontTexture();
					}
				}
				else
				{
					if (this.baseBuild != null)
					{
						this.baseBuild.MyUpdate(0, false);
					}
					this.updateEff();
				}
			}
			else if (meg[1] == 1)
			{
				this.door.CloseMenu(true);
			}
			else if (this.baseBuild != null)
			{
				this.baseBuild.MyUpdate(meg[1], false);
			}
		}
		else
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_PRISONER_LIST;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
		}
	}

	// Token: 0x06001D15 RID: 7445 RVA: 0x00342DD8 File Offset: 0x00340FD8
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			this.updateScrollPanelTimeBar();
		}
	}

	// Token: 0x06001D16 RID: 7446 RVA: 0x00342DE8 File Offset: 0x00340FE8
	private void Start()
	{
		this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		byte level = GUIManager.Instance.BuildingData.AllBuildsData[(int)this.B_ID].Level;
		this.baseBuild.InitBuildingWindow(18, this.B_ID, 2, level);
		UnityEngine.Object.Destroy(this.AGS_Form.GetChild(0).gameObject);
		this.baseBuild.baseTransform.SetAsFirstSibling();
		this.NoReflashFont = true;
	}

	// Token: 0x06001D17 RID: 7447 RVA: 0x00342E7C File Offset: 0x0034107C
	public void Update()
	{
		this.NoReflashFont = false;
		if (this.ReflashFont)
		{
			this.Refresh_FontTexture();
		}
		this.updateScrollPanelLight();
	}

	// Token: 0x06001D18 RID: 7448 RVA: 0x00342E9C File Offset: 0x0034109C
	public void OnButtonClick(UIButton sender)
	{
		this.door.OpenMenu(EGUIWindow.UI_JailRoom, sender.m_BtnID1, 0, true);
	}

	// Token: 0x06001D19 RID: 7449 RVA: 0x00342EB4 File Offset: 0x003410B4
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06001D1A RID: 7450 RVA: 0x00342EB8 File Offset: 0x003410B8
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		byte b = this.DM.sortedPrisonerList[(int)this.SPdispIdx[dataIdx]];
		this.SPnowIdx[panelObjectIdx] = b;
		this.SPItem[panelObjectIdx] = item.transform;
		UIHIBtn component = item.transform.GetChild(1).GetComponent<UIHIBtn>();
		GUIManager.Instance.InitianHeroItemImg(component.transform, eHeroOrItem.Hero, this.DM.PrisonerList[(int)b].head, 11, 0, 0, false, false, true, false);
		UIText component2 = item.transform.GetChild(2).GetComponent<UIText>();
		this.SPLv[panelObjectIdx].ClearString();
		this.SPLv[panelObjectIdx].IntToFormat((long)this.DM.PrisonerList[(int)b].LordLevel, 1, false);
		this.SPLv[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7757u));
		component2.text = this.SPLv[panelObjectIdx].ToString();
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		component2 = item.transform.GetChild(3).GetComponent<UIText>();
		this.SPName[panelObjectIdx].ClearString();
		GameConstants.GetNameString(this.SPName[panelObjectIdx], this.DM.PrisonerList[(int)b].KingdomID, this.DM.PrisonerList[(int)b].name, this.DM.PrisonerList[(int)b].AlliTag, false);
		component2.text = this.SPName[panelObjectIdx].ToString();
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		component2 = item.transform.GetChild(8).GetComponent<UIText>();
		UISpritesArray component3 = item.transform.GetChild(6).GetComponent<UISpritesArray>();
		long num = this.DM.PrisonerList[(int)b].StartActionTime + (long)((ulong)this.DM.PrisonerList[(int)b].TotalTime) - this.DM.ServerTime;
		if (num < 0L)
		{
			num = 0L;
		}
		RectTransform component4 = item.transform.GetChild(6).GetComponent<RectTransform>();
		this.SPStat[panelObjectIdx].ClearString();
		switch (this.DM.PrisonerList[(int)b].nowStat)
		{
		case PrisonerState.WaitForRelease:
		{
			this.SPStat[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(7768u));
			component3.SetSpriteIndex(2);
			item.transform.GetChild(4).gameObject.SetActive(false);
			float num2 = (float)num / this.DM.PrisonerList[(int)b].TotalTime;
			num2 = Mathf.Clamp01(1f - num2);
			component4.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 255f);
			break;
		}
		case PrisonerState.WaitForExecute:
			if (num > 21600L)
			{
				num -= 21600L;
				this.SPStat[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(7759u));
				component3.SetSpriteIndex(1);
				item.transform.GetChild(4).gameObject.SetActive(false);
				float num2 = (float)num / (this.DM.PrisonerList[(int)b].TotalTime - 21600u);
				num2 = Mathf.Clamp01(1f - num2);
				component4.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 255f);
			}
			else
			{
				this.SPStat[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(7758u));
				component3.SetSpriteIndex(0);
				item.transform.GetChild(4).gameObject.SetActive(true);
				component3 = item.transform.GetChild(4).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(0);
				float num2 = (float)num / 21600f;
				num2 = Mathf.Clamp01(1f - num2);
				component4.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 255f);
			}
			break;
		case PrisonerState.Poisoned:
		{
			this.SPStat[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(15008u));
			component3.SetSpriteIndex(3);
			item.transform.GetChild(4).gameObject.SetActive(true);
			component3 = item.transform.GetChild(4).GetComponent<UISpritesArray>();
			component3.SetSpriteIndex(1);
			float num2 = (float)num / this.DM.PrisonerList[(int)b].TotalTime;
			num2 = Mathf.Clamp01(1f - num2);
			component4.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 255f);
			break;
		}
		}
		component2.text = this.SPStat[panelObjectIdx].ToString();
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		component2 = item.transform.GetChild(9).GetComponent<UIText>();
		this.SPTime[panelObjectIdx].ClearString();
		GameConstants.GetTimeString(this.SPTime[panelObjectIdx], (uint)num, true, true, true, false, true);
		component2.text = this.SPTime[panelObjectIdx].ToString();
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		UIButton component5 = item.transform.GetChild(0).GetComponent<UIButton>();
		component5.m_BtnID1 = (int)this.SPdispIdx[dataIdx];
		component5.m_Handler = this;
	}

	// Token: 0x06001D1B RID: 7451 RVA: 0x00343408 File Offset: 0x00341608
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001D1C RID: 7452 RVA: 0x0034340C File Offset: 0x0034160C
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
		{
			this.AGS_Form.GetChild(1).gameObject.SetActive(true);
			this.AGS_Form.GetChild(2).gameObject.SetActive(true);
			this.AGS_Form.GetChild(3).gameObject.SetActive(true);
			this.updatePrisonerAmount();
		}
		else
		{
			this.AGS_Form.GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).gameObject.SetActive(false);
			this.AGS_Form.GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(4).gameObject.SetActive(false);
		}
	}

	// Token: 0x06001D1D RID: 7453 RVA: 0x003434DC File Offset: 0x003416DC
	public void Refresh_FontTexture()
	{
		if (this.NoReflashFont)
		{
			this.ReflashFont = true;
			return;
		}
		UIText component = this.AGS_Form.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(4).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(4).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(4).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		if (this.AGS_ScrollPanel != null && this.AGS_ScrollPanel.gameObject.activeInHierarchy && this.AGS_ScrollPanel.transform.childCount > 1)
		{
			Transform child = this.AGS_ScrollPanel.transform.GetChild(0);
			for (int i = 0; i < child.childCount; i++)
			{
				Transform child2 = child.GetChild(i);
				if (child2.gameObject.activeInHierarchy)
				{
					component = child2.GetChild(2).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child2.GetChild(3).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child2.GetChild(8).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child2.GetChild(9).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
				}
			}
		}
	}

	// Token: 0x06001D1E RID: 7454 RVA: 0x00343850 File Offset: 0x00341A50
	public void UpdateScrollPanel(bool newList = false)
	{
		if (!this.scrollPanelInit)
		{
			this.scrollPanelInit = true;
			this.SPHeights = new List<float>();
			this.SPdispIdx = new List<byte>();
			this.AGS_ScrollPanel.IntiScrollPanel(260f, 0f, 0f, this.SPHeights, 4, this);
		}
		this.SPHeights.Clear();
		this.SPdispIdx.Clear();
		byte b = 0;
		while ((int)b < this.DM.PrisonerList.Length)
		{
			if (this.DM.PrisonerList[(int)this.DM.sortedPrisonerList[(int)b]].nowStat == PrisonerState.None)
			{
				break;
			}
			if (this.DM.PrisonerList[(int)this.DM.sortedPrisonerList[(int)b]].nowStat > PrisonerState.None)
			{
				this.SPHeights.Add(86f);
				this.SPdispIdx.Add(b);
			}
			b += 1;
		}
		this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeights, 260f, newList);
	}

	// Token: 0x06001D1F RID: 7455 RVA: 0x00343964 File Offset: 0x00341B64
	private void updateScrollPanelTimeBar()
	{
		for (int i = 0; i < 4; i++)
		{
			if (this.SPItem[i] != null)
			{
				RectTransform component = this.SPItem[i].GetChild(6).GetComponent<RectTransform>();
				long num = this.DM.PrisonerList[(int)this.SPnowIdx[i]].StartActionTime + (long)((ulong)this.DM.PrisonerList[(int)this.SPnowIdx[i]].TotalTime) - this.DM.ServerTime;
				if (num < 0L)
				{
					num = 0L;
				}
				UIText component2;
				switch (this.DM.PrisonerList[(int)this.SPnowIdx[i]].nowStat)
				{
				case PrisonerState.WaitForRelease:
				{
					float num2 = (float)num / this.DM.PrisonerList[(int)this.SPnowIdx[i]].TotalTime;
					num2 = Mathf.Clamp01(1f - num2);
					component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 255f);
					break;
				}
				case PrisonerState.WaitForExecute:
					if (num > 21600L)
					{
						num -= 21600L;
						float num2 = (float)num / (this.DM.PrisonerList[(int)this.SPnowIdx[i]].TotalTime - 21600u);
						num2 = Mathf.Clamp01(1f - num2);
						component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 255f);
						component2 = this.SPItem[i].GetChild(8).GetComponent<UIText>();
						this.SPStat[i].ClearString();
						this.SPStat[i].Append(this.DM.mStringTable.GetStringByID(7759u));
						component2.text = this.SPStat[i].ToString();
						component2.SetAllDirty();
						component2.cachedTextGenerator.Invalidate();
						this.SPItem[i].GetChild(6).GetComponent<UISpritesArray>().SetSpriteIndex(1);
						this.SPItem[i].GetChild(4).gameObject.SetActive(false);
					}
					else
					{
						float num2 = (float)num / 21600f;
						num2 = Mathf.Clamp01(1f - num2);
						component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 255f);
						component2 = this.SPItem[i].GetChild(8).GetComponent<UIText>();
						this.SPStat[i].ClearString();
						this.SPStat[i].Append(this.DM.mStringTable.GetStringByID(7758u));
						component2.text = this.SPStat[i].ToString();
						component2.SetAllDirty();
						component2.cachedTextGenerator.Invalidate();
						this.SPItem[i].GetChild(6).GetComponent<UISpritesArray>().SetSpriteIndex(0);
						this.SPItem[i].GetChild(4).gameObject.SetActive(true);
					}
					break;
				case PrisonerState.Poisoned:
				{
					float num2 = (float)num / this.DM.PrisonerList[(int)this.SPnowIdx[i]].TotalTime;
					num2 = Mathf.Clamp01(1f - num2);
					component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 255f);
					break;
				}
				}
				component2 = this.SPItem[i].GetChild(9).GetComponent<UIText>();
				this.SPTime[i].ClearString();
				GameConstants.GetTimeString(this.SPTime[i], (uint)num, true, true, true, false, true);
				component2.text = this.SPTime[i].ToString();
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				float preferredWidth = component2.preferredWidth;
				component2 = this.SPItem[i].GetChild(8).GetComponent<UIText>();
				component2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 235f - preferredWidth);
			}
		}
	}

	// Token: 0x06001D20 RID: 7456 RVA: 0x00343D20 File Offset: 0x00341F20
	private void updateScrollPanelLight()
	{
		if (this.SPItem[0] == null)
		{
			return;
		}
		this.GetPointTime += Time.smoothDeltaTime;
		if (this.GetPointTime >= 2f)
		{
			this.GetPointTime = 0f;
		}
		float a = (this.GetPointTime <= 1f) ? this.GetPointTime : (2f - this.GetPointTime);
		for (int i = 0; i < 4; i++)
		{
			if (this.SPItem[i] != null && this.SPItem[i].GetChild(4).gameObject.activeInHierarchy)
			{
				Image component = this.SPItem[i].GetChild(4).GetComponent<Image>();
				component.color = new Color(1f, 1f, 1f, a);
			}
		}
	}

	// Token: 0x06001D21 RID: 7457 RVA: 0x00343E08 File Offset: 0x00342008
	private void updatePrisonerAmount()
	{
		if (!this.DM.Prisoner_Requested)
		{
			this.AGS_Form.GetChild(4).gameObject.SetActive(false);
			this.AGS_Form.GetChild(4).gameObject.SetActive(false);
		}
		else if (this.baseBuild != null && (this.baseBuild.buildType == e_BuildType.Normal || this.baseBuild.buildType == e_BuildType.SelfUpgradeing || this.baseBuild.buildType == e_BuildType.SelfBackOuting))
		{
			if (this.DM.PrisonerNum == 0)
			{
				this.AGS_Form.GetChild(4).gameObject.SetActive(true);
				this.AGS_Form.GetChild(3).gameObject.SetActive(false);
			}
			else
			{
				this.AGS_Form.GetChild(4).gameObject.SetActive(false);
				this.AGS_Form.GetChild(3).gameObject.SetActive(true);
			}
		}
		UIText component = this.AGS_Form.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.tmpString[1].ClearString();
		this.tmpString[1].IntToFormat((long)this.DM.PrisonerNum, 1, false);
		this.tmpString[1].IntToFormat(30L, 1, false);
		this.tmpString[1].StringToFormat(this.DM.mStringTable.GetStringByID(7751u));
		this.tmpString[1].AppendFormat("{2}\n{0} / {1}");
		component.text = this.tmpString[1].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		DataManager.Instance.LevelUpTable.GetRecordByKey((ushort)this.DM.PrisonerHighestLevel);
		component = this.AGS_Form.GetChild(2).GetChild(4).GetChild(1).GetComponent<UIText>();
		this.tmpString[2].ClearString();
		if (GUIManager.Instance.BuildingData.GetBuildData(18, 0).Level == 25)
		{
			if (this.DM.PrisonerHighestLevel != 0)
			{
				float f = (float)this.DM.LevelUpTable.GetRecordByKey((ushort)this.DM.PrisonerHighestLevel).PrisonEffect / 100f;
				this.tmpString[2].FloatToFormat(f, 2, false);
			}
			else
			{
				this.tmpString[2].IntToFormat(0L, 1, false);
			}
			if (!GUIManager.Instance.IsArabic)
			{
				this.tmpString[2].AppendFormat("{0}%");
			}
			else
			{
				this.tmpString[2].AppendFormat("%{0}");
			}
			component.text = this.tmpString[2].ToString();
		}
		else
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(7797u);
		}
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(2).GetChild(4).GetChild(3).GetComponent<UIText>();
		this.tmpString[3].ClearString();
		this.tmpString[3].IntToFormat((long)this.DM.PrisonerHighestLevel, 1, false);
		this.tmpString[3].AppendFormat(this.DM.mStringTable.GetStringByID(7754u));
		component.text = this.tmpString[3].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001D22 RID: 7458 RVA: 0x00344194 File Offset: 0x00342394
	private void updateEff()
	{
		UIText component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetComponent<UIText>();
		this.tmpString[0].ClearString();
		GameConstants.GetTimeInfoString(this.tmpString[0], DataManager.Instance.AttribVal.GetEffectBaseValByEffectID(305));
		component.text = this.tmpString[0].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
	}

	// Token: 0x040058C2 RID: 22722
	private const float ScrollPanelHeight = 260f;

	// Token: 0x040058C3 RID: 22723
	private const float ScrollPanelUnitHeight = 86f;

	// Token: 0x040058C4 RID: 22724
	private Transform AGS_Form;

	// Token: 0x040058C5 RID: 22725
	private ScrollPanel AGS_ScrollPanel;

	// Token: 0x040058C6 RID: 22726
	private BuildingWindow baseBuild;

	// Token: 0x040058C7 RID: 22727
	private ushort B_ID;

	// Token: 0x040058C8 RID: 22728
	private Door door;

	// Token: 0x040058C9 RID: 22729
	private DataManager DM;

	// Token: 0x040058CA RID: 22730
	private CString[] tmpString = new CString[4];

	// Token: 0x040058CB RID: 22731
	private bool scrollPanelInit;

	// Token: 0x040058CC RID: 22732
	private List<float> SPHeights;

	// Token: 0x040058CD RID: 22733
	private List<byte> SPdispIdx;

	// Token: 0x040058CE RID: 22734
	private CString[] SPName = new CString[4];

	// Token: 0x040058CF RID: 22735
	private CString[] SPLv = new CString[4];

	// Token: 0x040058D0 RID: 22736
	private CString[] SPTime = new CString[4];

	// Token: 0x040058D1 RID: 22737
	private CString[] SPStat = new CString[4];

	// Token: 0x040058D2 RID: 22738
	private byte[] SPnowIdx = new byte[4];

	// Token: 0x040058D3 RID: 22739
	private Transform[] SPItem = new Transform[4];

	// Token: 0x040058D4 RID: 22740
	private bool ReflashFont;

	// Token: 0x040058D5 RID: 22741
	private bool NoReflashFont;

	// Token: 0x040058D6 RID: 22742
	private float GetPointTime;

	// Token: 0x020005B7 RID: 1463
	private enum e_AGS_UI_Jail_Editor
	{
		// Token: 0x040058D8 RID: 22744
		BuildingWindow,
		// Token: 0x040058D9 RID: 22745
		back,
		// Token: 0x040058DA RID: 22746
		header,
		// Token: 0x040058DB RID: 22747
		scrollview,
		// Token: 0x040058DC RID: 22748
		NoItem,
		// Token: 0x040058DD RID: 22749
		Scrollitem
	}

	// Token: 0x020005B8 RID: 1464
	private enum e_AGS_header
	{
		// Token: 0x040058DF RID: 22751
		IronBox,
		// Token: 0x040058E0 RID: 22752
		Chain1,
		// Token: 0x040058E1 RID: 22753
		Chain2,
		// Token: 0x040058E2 RID: 22754
		block1,
		// Token: 0x040058E3 RID: 22755
		block2,
		// Token: 0x040058E4 RID: 22756
		scrollbg
	}

	// Token: 0x020005B9 RID: 1465
	private enum e_AGS_IronBox
	{
		// Token: 0x040058E6 RID: 22758
		Text
	}

	// Token: 0x020005BA RID: 1466
	private enum e_AGS_block1
	{
		// Token: 0x040058E8 RID: 22760
		desc,
		// Token: 0x040058E9 RID: 22761
		Time,
		// Token: 0x040058EA RID: 22762
		icon
	}

	// Token: 0x020005BB RID: 1467
	private enum e_AGS_block2
	{
		// Token: 0x040058EC RID: 22764
		desc,
		// Token: 0x040058ED RID: 22765
		content,
		// Token: 0x040058EE RID: 22766
		icon,
		// Token: 0x040058EF RID: 22767
		desc2
	}

	// Token: 0x020005BC RID: 1468
	private enum e_AGS_NoItem
	{
		// Token: 0x040058F1 RID: 22769
		noOne,
		// Token: 0x040058F2 RID: 22770
		desc
	}

	// Token: 0x020005BD RID: 1469
	private enum e_AGS_Scrollitem
	{
		// Token: 0x040058F4 RID: 22772
		BG,
		// Token: 0x040058F5 RID: 22773
		UIHIBtn,
		// Token: 0x040058F6 RID: 22774
		Level,
		// Token: 0x040058F7 RID: 22775
		Name,
		// Token: 0x040058F8 RID: 22776
		BarBackLight,
		// Token: 0x040058F9 RID: 22777
		Barbg,
		// Token: 0x040058FA RID: 22778
		Bar,
		// Token: 0x040058FB RID: 22779
		UIButton,
		// Token: 0x040058FC RID: 22780
		FuncName,
		// Token: 0x040058FD RID: 22781
		Time
	}
}
