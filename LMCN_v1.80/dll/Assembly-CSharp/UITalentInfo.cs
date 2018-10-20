using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000679 RID: 1657
public class UITalentInfo : IUIButtonClickHandler
{
	// Token: 0x06001FE1 RID: 8161 RVA: 0x003CB9FC File Offset: 0x003C9BFC
	public UITalentInfo(RectTransform transform, byte SaveSlot)
	{
		this.ThisTransform = transform;
		this.SaveSlot = SaveSlot;
	}

	// Token: 0x06001FE2 RID: 8162 RVA: 0x003CBA34 File Offset: 0x003C9C34
	public void OnOpen(int arg1, int arg2)
	{
		Transform thisTransform = this.ThisTransform;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		DataManager instance = DataManager.Instance;
		this.TalentID = arg1;
		UIButton component = this.ThisTransform.GetChild(0).GetComponent<UIButton>();
		component.m_BtnID1 = 1;
		component.m_Handler = this;
		component = thisTransform.GetChild(7).GetComponent<UIButton>();
		component.m_BtnID1 = 0;
		component.m_Handler = this;
		if (GUIManager.Instance.IsArabic)
		{
			component.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			RectTransform component2 = this.ThisTransform.GetChild(0).GetComponent<RectTransform>();
			component2.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			component2.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		this.TalentIcon = thisTransform.GetChild(3).GetChild(1).GetComponent<Image>();
		this.Frame = thisTransform.GetChild(3).GetChild(3);
		this.Lock = thisTransform.GetChild(3).GetChild(3).GetChild(0);
		this.Black = thisTransform.GetChild(3).GetChild(2);
		this.DegreeRect = thisTransform.GetChild(3).GetChild(3).GetChild(1).GetComponent<RectTransform>();
		this.FullFrame = thisTransform.GetChild(3).GetChild(4);
		this.LevelText = thisTransform.GetChild(3).GetChild(6).GetComponent<UIText>();
		this.TalentName = thisTransform.GetChild(3).GetChild(5).GetComponent<UIText>();
		this.TalentPointText = thisTransform.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.TalentPointText.font = ttffont;
		UIButtonHint uibuttonHint = thisTransform.GetChild(2).GetChild(1).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = GUIManager.Instance.FindMenu(EGUIWindow.UI_Talent);
		if (GUIManager.Instance.IsArabic)
		{
			this.TalentIcon.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		this.EffectText = thisTransform.GetChild(5).GetComponent<UIText>();
		this.EffectNextText = thisTransform.GetChild(6).GetComponent<UIText>();
		this.ContText = thisTransform.GetChild(8).GetChild(0).GetComponent<UIText>();
		Text contText = this.ContText;
		Font font = ttffont;
		this.TalentName.font = font;
		font = font;
		this.LevelText.font = font;
		font = font;
		this.EffectText.font = font;
		font = font;
		this.EffectNextText.font = font;
		contText.font = font;
		this.ContText.fontStyle = FontStyle.Normal;
		this.LevelStr = StringManager.Instance.SpawnString(30);
		this.EffectStr = StringManager.Instance.SpawnString(100);
		this.EffectNextStr = StringManager.Instance.SpawnString(100);
		this.ContentStr = StringManager.Instance.SpawnString(150);
		this.NeedPointStr = StringManager.Instance.SpawnString(30);
		this.TalentPointStr = StringManager.Instance.SpawnString(30);
		this.MaxNeedPointStr = StringManager.Instance.SpawnString(30);
		this.LearnTrans = thisTransform.GetChild(9);
		this.ConfirmRect = this.LearnTrans.GetChild(0).GetComponent<RectTransform>();
		this.PointIcon = this.ConfirmRect.GetChild(0).GetComponent<Image>();
		this.LockIcon = this.ConfirmRect.GetChild(1).GetComponent<Image>();
		this.ConfirmBtn = this.ConfirmRect.GetComponent<UIButton>();
		this.ConfirmBtn.m_BtnID1 = 2;
		this.ConfirmBtn.m_Handler = this;
		this.NeedPointText = this.ConfirmRect.GetChild(2).GetComponent<UIText>();
		this.NeedPointText.font = ttffont;
		this.LearnText = this.ConfirmRect.GetChild(3).GetComponent<UIText>();
		this.LearnText.font = ttffont;
		this.LearnText.text = instance.mStringTable.GetStringByID(1506u);
		this.ConfirmMaxRect = this.LearnTrans.GetChild(1).GetComponent<RectTransform>();
		this.ConfirmMaxBtn = this.LearnTrans.GetChild(1).GetComponent<UIButton>();
		this.ConfirmMaxBtn.m_BtnID1 = 3;
		this.ConfirmMaxBtn.m_Handler = this;
		this.MaxNeedPointText = this.LearnTrans.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.MaxNeedPointText.font = ttffont;
		this.MaxLearnText = this.LearnTrans.GetChild(1).GetChild(2).GetComponent<UIText>();
		this.MaxLearnText.font = ttffont;
		this.MaxLearnText.text = instance.mStringTable.GetStringByID(10031u);
		this.ResetStateImg = thisTransform.GetChild(11).GetChild(0).GetComponent<Image>();
		this.ResetBtn = thisTransform.GetChild(11).GetComponent<UIButton>();
		this.ResetBtn.m_BtnID1 = 5;
		this.ResetBtn.m_Handler = this;
		this.ResearchFull = thisTransform.GetChild(10);
		this.LevelMaxText = this.ResearchFull.GetChild(0).GetComponent<UIText>();
		this.LevelMaxText.font = ttffont;
		this.LevelMaxText.text = instance.mStringTable.GetStringByID(1507u);
		this.LvLight = thisTransform.GetChild(12).GetComponent<CanvasGroup>();
		this.LvEffectRect = thisTransform.GetChild(13).GetComponent<RectTransform>();
		this.LvEffect = this.LvEffectRect.GetComponent<CanvasGroup>();
		this.UpdateTalentInfo();
		this.UpdateRoleTalentPoint();
		this.SetActive(true);
	}

	// Token: 0x06001FE3 RID: 8163 RVA: 0x003CBFE8 File Offset: 0x003CA1E8
	public void UpdateTalentInfo()
	{
		DataManager instance = DataManager.Instance;
		TalentTbl recordByKey = instance.TalentData.GetRecordByKey((ushort)this.TalentID);
		byte talentLevel = instance.GetTalentLevel(recordByKey.TalentID, this.SaveSlot);
		this.TalentName.text = instance.mStringTable.GetStringByID((uint)recordByKey.NameID);
		float num = 163f / (float)recordByKey.LevelMax;
		Vector2 sizeDelta = this.DegreeRect.sizeDelta;
		sizeDelta.x = num * (float)talentLevel;
		this.DegreeRect.sizeDelta = sizeDelta;
		this.LevelStr.ClearString();
		this.LevelStr.IntToFormat((long)talentLevel, 1, false);
		this.LevelStr.IntToFormat((long)recordByKey.LevelMax, 1, false);
		if (GUIManager.Instance.IsArabic)
		{
			this.LevelStr.AppendFormat("{1}/{0}");
		}
		else
		{
			this.LevelStr.AppendFormat("{0}/{1}");
		}
		this.LevelText.text = this.LevelStr.ToString();
		this.LevelText.SetAllDirty();
		this.LevelText.cachedTextGenerator.Invalidate();
		this.GraphicID = recordByKey.Graphic;
		if (GUIManager.Instance.TechMaterial == null)
		{
			this.TalentIcon.enabled = false;
		}
		else
		{
			this.TalentIcon.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
			this.TalentIcon.material = GUIManager.Instance.TechMaterial;
			this.TalentIcon.enabled = true;
		}
		this.NeedPointStr.ClearString();
		this.EffectStr.ClearString();
		this.EffectNextStr.ClearString();
		this.ContentStr.ClearString();
		uint num2 = 0u;
		byte level = Math.Max(1, talentLevel);
		TalentLevelTbl talentLevelTbl;
		if (instance.GetTalentLevelupData(out talentLevelTbl, (ushort)this.TalentID, level))
		{
			if (talentLevel > 0)
			{
				num2 += (uint)talentLevelTbl.EffectVal;
			}
			CString cstring = StringManager.Instance.StaticString1024();
			if (talentLevel == 0 && recordByKey.NeedTalentID > 0)
			{
				this.EffectStr.IntToFormat((long)recordByKey.NeedTalentLv, 1, false);
				this.EffectStr.StringToFormat(instance.mStringTable.GetStringByID((uint)instance.TalentData.GetRecordByKey(recordByKey.NeedTalentID).NameID));
				this.EffectStr.AppendFormat(instance.mStringTable.GetStringByID(1510u));
			}
			else if (talentLevelTbl.Effect <= 1000)
			{
				if (num2 > 0u)
				{
					GameConstants.GetEffectValue(cstring, talentLevelTbl.Effect, 0u, 6, num2);
					this.EffectStr.StringToFormat(cstring);
					this.EffectStr.AppendFormat(instance.mStringTable.GetStringByID(5012u));
				}
			}
			else
			{
				GameConstants.GetEffectValue(cstring, talentLevelTbl.Effect, 0u, 7, num2);
				this.EffectStr.StringToFormat(cstring);
				this.EffectStr.AppendFormat(instance.mStringTable.GetStringByID(5012u));
			}
			this.EffectText.text = this.EffectStr.ToString();
			this.EffectText.SetAllDirty();
			this.EffectText.cachedTextGenerator.Invalidate();
			GameConstants.GetEffectValue(this.ContentStr, talentLevelTbl.Effect, num2, 0, 0f);
			this.ContText.text = this.ContentStr.ToString();
			this.ContText.SetAllDirty();
			this.ContText.cachedTextGenerator.Invalidate();
		}
		if (talentLevel < recordByKey.LevelMax && instance.GetTalentLevelupData(out talentLevelTbl, (ushort)this.TalentID, talentLevel + 1))
		{
			num2 = (uint)((ushort)((uint)talentLevelTbl.EffectVal - num2));
			CString cstring2 = StringManager.Instance.StaticString1024();
			if (talentLevelTbl.Effect <= 1000)
			{
				GameConstants.GetEffectValue(cstring2, talentLevelTbl.Effect, 0u, 6, num2);
			}
			else
			{
				GameConstants.GetEffectValue(cstring2, talentLevelTbl.Effect, 0u, 7, num2);
			}
			GameConstants.GetEffectValue(this.ContentStr, talentLevelTbl.Effect, num2, 0, 0f);
			this.ContText.text = this.ContentStr.ToString();
			this.ContText.SetAllDirty();
			this.ContText.cachedTextGenerator.Invalidate();
			this.EffectNextStr.StringToFormat(cstring2);
			this.EffectNextStr.AppendFormat(instance.mStringTable.GetStringByID(5013u));
			this.EffectNextText.text = this.EffectNextStr.ToString();
			this.EffectNextText.SetAllDirty();
			this.EffectNextText.cachedTextGenerator.Invalidate();
			this.NeedPointStr.IntToFormat((long)talentLevelTbl.NeedPoint, 1, false);
			this.NeedPointStr.AppendFormat("{0}");
			this.NeedPointText.text = this.NeedPointStr.ToString();
			this.NeedPointText.SetAllDirty();
			this.NeedPointText.cachedTextGenerator.Invalidate();
			this.LearnTrans.gameObject.SetActive(true);
			this.ResearchFull.gameObject.SetActive(false);
			this.FullFrame.gameObject.SetActive(false);
			this.Frame.gameObject.SetActive(true);
		}
		else
		{
			this.EffectNextText.text = string.Empty;
			this.LearnTrans.gameObject.SetActive(false);
			this.ResearchFull.gameObject.SetActive(true);
			this.FullFrame.gameObject.SetActive(true);
			this.Frame.gameObject.SetActive(false);
			this.ResetBtn.gameObject.SetActive(true);
			this.ResetStateImg.color = Color.white;
		}
		this.SetBtnStyle(instance.CheckTalentState((ushort)this.TalentID, this.SaveSlot, 1), recordByKey.LevelMax);
	}

	// Token: 0x06001FE4 RID: 8164 RVA: 0x003CC5CC File Offset: 0x003CA7CC
	public void UpdateBtnStyle()
	{
		TalentTbl recordByKey = DataManager.Instance.TalentData.GetRecordByKey((ushort)this.TalentID);
		this.SetBtnStyle((byte)this.ConfirmBtn.m_BtnID3, recordByKey.LevelMax);
	}

	// Token: 0x06001FE5 RID: 8165 RVA: 0x003CC60C File Offset: 0x003CA80C
	private void SetBtnStyle(byte state, byte MaxLevel)
	{
		byte level = GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level;
		DataManager instance = DataManager.Instance;
		if ((state & 1) > 0)
		{
			TalentTbl recordByKey = instance.TalentData.GetRecordByKey((ushort)this.TalentID);
			this.ConfirmBtn.m_BtnID1 = 4;
			this.ConfirmBtn.m_BtnID2 = (int)recordByKey.NeedTalentID;
			this.ConfirmBtn.m_BtnID4 = (int)(recordByKey.NeedTalentLv - instance.GetTalentLevel(recordByKey.NeedTalentID, this.SaveSlot));
			this.ConfirmBtn.m_BtnID3 = (int)instance.CheckTalentState(recordByKey.NeedTalentID, this.SaveSlot, (byte)this.ConfirmBtn.m_BtnID4);
			this.ResetBtn.gameObject.SetActive(false);
			this.ConfirmMaxBtn.gameObject.SetActive(false);
			this.ConfirmRect.anchoredPosition = new Vector2(4f, this.ConfirmRect.anchoredPosition.y);
			this.ConfirmRect.sizeDelta = new Vector2(232f, this.ConfirmRect.sizeDelta.y);
			this.PointIcon.gameObject.SetActive(false);
			this.LockIcon.gameObject.SetActive(true);
			this.LearnText.text = instance.mStringTable.GetStringByID(10030u);
			this.NeedPointText.text = string.Empty;
		}
		else if (level < 16)
		{
			this.ConfirmBtn.m_BtnID1 = 2;
			this.ConfirmBtn.m_BtnID2 = this.TalentID;
			this.ConfirmBtn.m_BtnID3 = (int)state;
			this.ConfirmBtn.m_BtnID4 = 1;
			this.ConfirmMaxBtn.gameObject.SetActive(false);
			this.ConfirmRect.anchoredPosition = new Vector2(4f, this.ConfirmRect.anchoredPosition.y);
			this.ConfirmRect.sizeDelta = new Vector2(232f, this.ConfirmRect.sizeDelta.y);
			this.PointIcon.gameObject.SetActive(true);
			this.LockIcon.gameObject.SetActive(false);
			this.LearnText.text = instance.mStringTable.GetStringByID(1506u);
			this.UpdateResetBtnState(instance.GetTalentLevel((ushort)this.TalentID, this.SaveSlot));
		}
		else
		{
			this.ConfirmBtn.m_BtnID1 = 2;
			this.ConfirmBtn.m_BtnID2 = this.TalentID;
			this.ConfirmBtn.m_BtnID3 = (int)state;
			this.ConfirmBtn.m_BtnID4 = 1;
			this.ConfirmMaxBtn.gameObject.SetActive(true);
			this.ConfirmMaxBtn.m_BtnID2 = this.TalentID;
			instance.GetNeedTalentPoint((ushort)this.TalentID, ref MaxLevel, this.SaveSlot);
			this.ConfirmMaxBtn.m_BtnID4 = (int)(MaxLevel - instance.GetTalentLevel((ushort)this.TalentID, this.SaveSlot));
			byte addLevel = (byte)Mathf.Clamp(this.ConfirmMaxBtn.m_BtnID4, 1, (int)MaxLevel);
			this.ConfirmMaxBtn.m_BtnID3 = (int)instance.CheckTalentState((ushort)this.TalentID, this.SaveSlot, addLevel);
			this.MaxNeedPointStr.ClearString();
			this.MaxNeedPointStr.IntToFormat((long)this.ConfirmMaxBtn.m_BtnID4, 1, false);
			this.MaxNeedPointStr.AppendFormat("{0}");
			this.MaxNeedPointText.text = this.MaxNeedPointStr.ToString();
			this.MaxNeedPointText.SetAllDirty();
			this.MaxNeedPointText.cachedTextGenerator.Invalidate();
			if (this.SaveSlot > 0)
			{
				this.ConfirmRect.anchoredPosition = new Vector2(-44f, this.ConfirmRect.anchoredPosition.y);
				this.ConfirmRect.sizeDelta = new Vector2(165f, this.ConfirmRect.sizeDelta.y);
			}
			else
			{
				this.ConfirmRect.anchoredPosition = new Vector2(-105f, this.ConfirmRect.anchoredPosition.y);
				this.ConfirmRect.sizeDelta = new Vector2(180f, this.ConfirmRect.sizeDelta.y);
				this.ConfirmMaxRect.anchoredPosition = new Vector2(110f, this.ConfirmMaxRect.anchoredPosition.y);
			}
			this.UpdateResetBtnState(instance.GetTalentLevel((ushort)this.TalentID, this.SaveSlot));
			this.ConfirmMaxRect.sizeDelta = this.ConfirmRect.sizeDelta;
			this.PointIcon.gameObject.SetActive(true);
			this.LockIcon.gameObject.SetActive(false);
			this.LearnText.text = instance.mStringTable.GetStringByID(1506u);
		}
		ColorBlock colors = this.ConfirmBtn.colors;
		if ((state & 1) > 0)
		{
			this.Black.gameObject.SetActive(true);
			this.Lock.gameObject.SetActive(true);
		}
		else
		{
			this.Black.gameObject.SetActive(false);
			this.Lock.gameObject.SetActive(false);
		}
		colors.highlightedColor = colors.normalColor;
		this.ConfirmBtn.colors = colors;
	}

	// Token: 0x06001FE6 RID: 8166 RVA: 0x003CCB70 File Offset: 0x003CAD70
	private void UpdateResetBtnState(byte talentLv)
	{
		if (this.SaveSlot == 0)
		{
			this.ResetBtn.gameObject.SetActive(false);
		}
		else
		{
			this.ResetBtn.gameObject.SetActive(true);
			this.ResetBtn.m_BtnID2 = 0;
			if (talentLv > 0)
			{
				if (talentLv > DataManager.Instance.GetMinTalentLv((ushort)this.TalentID, this.SaveSlot))
				{
					this.ResetStateImg.color = Color.white;
				}
				else
				{
					this.ResetStateImg.color = Color.gray;
					this.ResetBtn.m_BtnID2 = 10182;
				}
			}
			else
			{
				this.ResetStateImg.color = Color.gray;
				this.ResetBtn.m_BtnID2 = 10180;
			}
		}
	}

	// Token: 0x06001FE7 RID: 8167 RVA: 0x003CCC3C File Offset: 0x003CAE3C
	public void UpdateRoleTalentPoint()
	{
		this.TalentPointStr.ClearString();
		if (this.SaveSlot == 0)
		{
			this.TalentPointStr.IntToFormat((long)DataManager.Instance.RoleTalentPoint, 1, false);
		}
		else
		{
			this.TalentPointStr.IntToFormat((long)DataManager.Instance.SaveTalentData[0].RoleTalentPoint, 1, false);
		}
		this.TalentPointStr.AppendFormat("{0}");
		this.TalentPointText.text = this.TalentPointStr.ToString();
		this.TalentPointText.SetAllDirty();
		this.TalentPointText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001FE8 RID: 8168 RVA: 0x003CCCE4 File Offset: 0x003CAEE4
	public void SetActive(bool bActive)
	{
		this.ThisTransform.gameObject.SetActive(bActive);
	}

	// Token: 0x06001FE9 RID: 8169 RVA: 0x003CCCF8 File Offset: 0x003CAEF8
	public void UpdateUI(int arge1, int arge2)
	{
		if (arge1 == -1)
		{
			this.TalentIcon.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
			this.TalentIcon.material = GUIManager.Instance.TechMaterial;
			this.TalentIcon.enabled = true;
		}
		else
		{
			this.TalentID = arge1;
			this.UpdateTalentInfo();
			this.SetActive(true);
		}
	}

	// Token: 0x06001FEA RID: 8170 RVA: 0x003CCD64 File Offset: 0x003CAF64
	private void ShowLevelupEffect()
	{
		this.StartTime = 0f;
		this.bLevelup = true;
		Vector2 anchoredPosition = this.LvEffectRect.anchoredPosition;
		anchoredPosition.y = 21f;
		this.LvEffectRect.anchoredPosition = anchoredPosition;
		AudioManager.Instance.PlayUISFX(UIKind.SkillLvelup);
	}

	// Token: 0x06001FEB RID: 8171 RVA: 0x003CCDB8 File Offset: 0x003CAFB8
	public void Update()
	{
		if (this.bLevelup)
		{
			float num = Mathf.Clamp(this.StartTime / this.TotalTime, 0f, 1f);
			float num2 = 260f * num;
			Vector2 anchoredPosition = this.LvEffectRect.anchoredPosition;
			anchoredPosition.y = 21f + num2;
			this.LvEffectRect.anchoredPosition = anchoredPosition;
			if (num < 0.5f)
			{
				this.LvEffect.alpha = 1f * num / 0.5f;
			}
			else
			{
				this.LvEffect.alpha = 1f - (num - 0.5f) / 0.5f;
			}
			num = Mathf.Clamp(this.StartTime / this.EffLightTime, 0f, 1f);
			if (num < 0.5f)
			{
				this.LvLight.alpha = 1f * num / 0.5f;
			}
			else
			{
				this.LvLight.alpha = 1f - (num - 0.5f) / 0.5f;
			}
			if (this.StartTime > this.TotalTime && this.StartTime > this.EffLightTime)
			{
				this.bLevelup = false;
			}
			this.StartTime += Time.smoothDeltaTime;
		}
	}

	// Token: 0x06001FEC RID: 8172 RVA: 0x003CCF00 File Offset: 0x003CB100
	public void TextRefresh()
	{
		this.TalentName.enabled = false;
		this.LevelText.enabled = false;
		this.EffectText.enabled = false;
		this.EffectNextText.enabled = false;
		this.ContText.enabled = false;
		this.NeedPointText.enabled = false;
		this.TalentPointText.enabled = false;
		this.LearnText.enabled = false;
		this.LevelMaxText.enabled = false;
		this.TalentName.enabled = true;
		this.LevelText.enabled = true;
		this.EffectText.enabled = true;
		this.EffectNextText.enabled = true;
		this.ContText.enabled = true;
		this.NeedPointText.enabled = true;
		this.TalentPointText.enabled = true;
		this.LearnText.enabled = true;
		this.LevelMaxText.enabled = true;
		this.MaxLearnText.enabled = false;
		this.MaxLearnText.enabled = true;
		this.MaxNeedPointText.enabled = false;
		this.MaxNeedPointText.enabled = true;
	}

	// Token: 0x06001FED RID: 8173 RVA: 0x003CD018 File Offset: 0x003CB218
	public void OnDestroy()
	{
		StringManager.Instance.DeSpawnString(this.LevelStr);
		StringManager.Instance.DeSpawnString(this.EffectStr);
		StringManager.Instance.DeSpawnString(this.EffectNextStr);
		StringManager.Instance.DeSpawnString(this.ContentStr);
		StringManager.Instance.DeSpawnString(this.NeedPointStr);
		StringManager.Instance.DeSpawnString(this.TalentPointStr);
		StringManager.Instance.DeSpawnString(this.MaxNeedPointStr);
	}

	// Token: 0x06001FEE RID: 8174 RVA: 0x003CD09C File Offset: 0x003CB29C
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
		{
			this.SetTalentSaveFlag();
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			int arg = this.TalentID << 16 | (int)this.SaveSlot;
			door.OpenMenu(EGUIWindow.UI_Information, -2, arg, false);
			GameConstants.GetBytes((ushort)this.TalentID, GUIManager.Instance.TalentSaved, 5);
			break;
		}
		case 1:
			DataManager.Instance.CheckTalentSend();
			GameConstants.GetBytes(0, GUIManager.Instance.TalentSaved, 5);
			this.SetActive(false);
			break;
		case 2:
		case 4:
		{
			GameConstants.GetBytes(0, GUIManager.Instance.TalentSaved, 5);
			ushort talentID = (ushort)sender.m_BtnID2;
			if ((sender.m_BtnID3 & 1) == 0)
			{
				if ((sender.m_BtnID3 & 8) > 0)
				{
					if (sender.m_BtnID1 == 2)
					{
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1504u), 255, true);
					}
					else
					{
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14709u), 255, true);
					}
				}
				else
				{
					if (this.SaveSlot == 0)
					{
						DataManager.Instance.sendAddTalentLevelQueue(talentID, (byte)sender.m_BtnID4, (byte)sender.m_BtnID1);
					}
					else
					{
						DataManager.Instance.sendTalentSaveQueue(talentID, this.SaveSlot, (byte)sender.m_BtnID4, (byte)sender.m_BtnID1);
					}
					this.ShowLevelupEffect();
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Talent, 0, 0);
				}
			}
			else if (sender.m_BtnID1 == 2)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1512u), 255, true);
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(10028u), 255, true);
			}
			break;
		}
		case 3:
		{
			GameConstants.GetBytes(0, GUIManager.Instance.TalentSaved, 5);
			ushort talentID2 = (ushort)sender.m_BtnID2;
			if ((sender.m_BtnID3 & 8) > 0)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1504u), 255, true);
			}
			else
			{
				if (this.SaveSlot == 0)
				{
					DataManager.Instance.sendAddTalentLevelQueue(talentID2, (byte)sender.m_BtnID4, (byte)sender.m_BtnID1);
				}
				else
				{
					DataManager.Instance.sendTalentSaveQueue(talentID2, this.SaveSlot, (byte)sender.m_BtnID4, 0);
				}
				this.ShowLevelupEffect();
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Talent, 0, 0);
			}
			break;
		}
		case 5:
			if (sender.m_BtnID2 > 0)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID((uint)sender.m_BtnID2), 255, true);
			}
			else
			{
				DataManager.Instance.ResetTalent((ushort)this.TalentID, this.SaveSlot);
			}
			break;
		}
	}

	// Token: 0x06001FEF RID: 8175 RVA: 0x003CD39C File Offset: 0x003CB59C
	public void SetTalentSaveFlag()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_WindowStack.Count > 0)
		{
			for (int i = door.m_WindowStack.Count - 1; i >= 0; i--)
			{
				GUIWindowStackData value = door.m_WindowStack[i];
				if (value.m_eWindow == EGUIWindow.UI_Talent)
				{
					value.m_Arg1 |= 32768;
					value.m_Arg2 = 1;
					door.m_WindowStack[i] = value;
					break;
				}
			}
		}
	}

	// Token: 0x040064AE RID: 25774
	private const float MaxWidth = 163f;

	// Token: 0x040064AF RID: 25775
	public int TalentID;

	// Token: 0x040064B0 RID: 25776
	private Image TalentIcon;

	// Token: 0x040064B1 RID: 25777
	private Image PointIcon;

	// Token: 0x040064B2 RID: 25778
	private Image LockIcon;

	// Token: 0x040064B3 RID: 25779
	private Image ResetStateImg;

	// Token: 0x040064B4 RID: 25780
	private UIText TalentName;

	// Token: 0x040064B5 RID: 25781
	private UIText LevelText;

	// Token: 0x040064B6 RID: 25782
	private UIText EffectText;

	// Token: 0x040064B7 RID: 25783
	private UIText EffectNextText;

	// Token: 0x040064B8 RID: 25784
	private UIText ContText;

	// Token: 0x040064B9 RID: 25785
	private UIText NeedPointText;

	// Token: 0x040064BA RID: 25786
	private UIText TalentPointText;

	// Token: 0x040064BB RID: 25787
	private UIText LearnText;

	// Token: 0x040064BC RID: 25788
	private UIText LevelMaxText;

	// Token: 0x040064BD RID: 25789
	private UIText MaxNeedPointText;

	// Token: 0x040064BE RID: 25790
	private UIText MaxLearnText;

	// Token: 0x040064BF RID: 25791
	private Transform Lock;

	// Token: 0x040064C0 RID: 25792
	private Transform Black;

	// Token: 0x040064C1 RID: 25793
	private Transform FullFrame;

	// Token: 0x040064C2 RID: 25794
	private Transform Frame;

	// Token: 0x040064C3 RID: 25795
	private Transform ResearchFull;

	// Token: 0x040064C4 RID: 25796
	private Transform LearnTrans;

	// Token: 0x040064C5 RID: 25797
	private RectTransform DegreeRect;

	// Token: 0x040064C6 RID: 25798
	private RectTransform LvEffectRect;

	// Token: 0x040064C7 RID: 25799
	private RectTransform ConfirmRect;

	// Token: 0x040064C8 RID: 25800
	private RectTransform ConfirmMaxRect;

	// Token: 0x040064C9 RID: 25801
	private CString LevelStr;

	// Token: 0x040064CA RID: 25802
	private CString EffectStr;

	// Token: 0x040064CB RID: 25803
	private CString EffectNextStr;

	// Token: 0x040064CC RID: 25804
	private CString ContentStr;

	// Token: 0x040064CD RID: 25805
	private CString NeedPointStr;

	// Token: 0x040064CE RID: 25806
	private CString TalentPointStr;

	// Token: 0x040064CF RID: 25807
	private CString MaxNeedPointStr;

	// Token: 0x040064D0 RID: 25808
	private UIButton ConfirmBtn;

	// Token: 0x040064D1 RID: 25809
	private UIButton ConfirmMaxBtn;

	// Token: 0x040064D2 RID: 25810
	private UIButton ResetBtn;

	// Token: 0x040064D3 RID: 25811
	private CanvasGroup LvLight;

	// Token: 0x040064D4 RID: 25812
	private CanvasGroup LvEffect;

	// Token: 0x040064D5 RID: 25813
	private bool bLevelup;

	// Token: 0x040064D6 RID: 25814
	private float StartTime;

	// Token: 0x040064D7 RID: 25815
	private float TotalTime = 0.6f;

	// Token: 0x040064D8 RID: 25816
	private float EffLightTime = 1f;

	// Token: 0x040064D9 RID: 25817
	private ushort GraphicID;

	// Token: 0x040064DA RID: 25818
	private byte SaveSlot;

	// Token: 0x040064DB RID: 25819
	public RectTransform ThisTransform;

	// Token: 0x0200067A RID: 1658
	private enum MainControl
	{
		// Token: 0x040064DD RID: 25821
		BackgroundBtn,
		// Token: 0x040064DE RID: 25822
		Background,
		// Token: 0x040064DF RID: 25823
		Point,
		// Token: 0x040064E0 RID: 25824
		TalentItem,
		// Token: 0x040064E1 RID: 25825
		Image,
		// Token: 0x040064E2 RID: 25826
		TotalEffect,
		// Token: 0x040064E3 RID: 25827
		NextEffect,
		// Token: 0x040064E4 RID: 25828
		Info,
		// Token: 0x040064E5 RID: 25829
		Content,
		// Token: 0x040064E6 RID: 25830
		Learn,
		// Token: 0x040064E7 RID: 25831
		LvMax,
		// Token: 0x040064E8 RID: 25832
		ResetBtn,
		// Token: 0x040064E9 RID: 25833
		LvupLight,
		// Token: 0x040064EA RID: 25834
		LvupEff
	}

	// Token: 0x0200067B RID: 1659
	private enum LeaveControl
	{
		// Token: 0x040064EC RID: 25836
		Direction,
		// Token: 0x040064ED RID: 25837
		SkillPic,
		// Token: 0x040064EE RID: 25838
		Black,
		// Token: 0x040064EF RID: 25839
		Frame,
		// Token: 0x040064F0 RID: 25840
		FrameFull,
		// Token: 0x040064F1 RID: 25841
		Name,
		// Token: 0x040064F2 RID: 25842
		LvText
	}

	// Token: 0x0200067C RID: 1660
	public enum ClickType
	{
		// Token: 0x040064F4 RID: 25844
		Info,
		// Token: 0x040064F5 RID: 25845
		Close,
		// Token: 0x040064F6 RID: 25846
		Confirm,
		// Token: 0x040064F7 RID: 25847
		ConfirmMax,
		// Token: 0x040064F8 RID: 25848
		ConfirmUnlock,
		// Token: 0x040064F9 RID: 25849
		Reset
	}

	// Token: 0x0200067D RID: 1661
	public enum LevelupStyle : byte
	{
		// Token: 0x040064FB RID: 25851
		eNone,
		// Token: 0x040064FC RID: 25852
		eLevelup,
		// Token: 0x040064FD RID: 25853
		eLevelupMax,
		// Token: 0x040064FE RID: 25854
		eUnLock
	}
}
