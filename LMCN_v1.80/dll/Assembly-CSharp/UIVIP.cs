using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006A8 RID: 1704
public class UIVIP : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x060020AD RID: 8365 RVA: 0x003E1EE8 File Offset: 0x003E00E8
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		for (int i = 0; i < 6; i++)
		{
			this.tmpString[i] = StringManager.Instance.SpawnString(30);
		}
		UIButton component = this.AGS_Form.GetChild(0).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.image.sprite = this.door.LoadSprite("UI_main_close");
		component.image.material = this.door.LoadMaterial();
		Image component2 = this.AGS_Form.GetChild(0).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.door.LoadMaterial();
		component2.enabled = !GUIManager.Instance.bOpenOnIPhoneX;
		UIText component3 = this.AGS_Form.GetChild(2).GetComponent<UIText>();
		component3.text = DataManager.Instance.mStringTable.GetStringByID(7701u);
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(3).GetComponent<UIText>();
		component3.text = DataManager.Instance.mStringTable.GetStringByID(7702u);
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIText>();
		component3.font = ttffont;
		component = this.AGS_Form.GetChild(5).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		this.Img_GetPoint = this.AGS_Form.GetChild(5).GetChild(0).GetComponent<Image>();
		component3 = this.AGS_Form.GetChild(5).GetChild(1).GetComponent<UIText>();
		component3.text = DataManager.Instance.mStringTable.GetStringByID(7704u);
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(7).GetComponent<UIText>();
		component3.font = ttffont;
		component = this.AGS_Form.GetChild(8).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component4 = component.gameObject.GetComponent<RectTransform>();
			component4.localScale = new Vector3(-1f, 1f, 1f);
			component4.anchoredPosition = new Vector2(component4.anchoredPosition.x + 44f, component4.anchoredPosition.y);
		}
		component3 = this.AGS_Form.GetChild(11).GetComponent<UIText>();
		component3.text = DataManager.Instance.mStringTable.GetStringByID(7705u);
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(14).GetChild(2).GetComponent<UIText>();
		component3.text = string.Empty;
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<UIText>();
		component3.text = DataManager.Instance.mStringTable.GetStringByID(7706u);
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(16).GetChild(0).GetChild(0).GetComponent<UIText>();
		component3.text = string.Empty;
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(15).GetChild(2).GetComponent<UIText>();
		component3.text = string.Empty;
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(15).GetChild(3).GetComponent<UIText>();
		component3.text = DataManager.Instance.mStringTable.GetStringByID(7707u);
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(16).GetChild(0).GetChild(1).GetComponent<UIText>();
		component3.text = string.Empty;
		component3.font = ttffont;
		component = this.AGS_Form.GetChild(17).GetComponent<UIButton>();
		component.m_Handler = this;
		this.LBtn = component.transform;
		this.MoveTime1 = this.LBtn.localPosition.x;
		component = this.AGS_Form.GetChild(18).GetComponent<UIButton>();
		component.m_Handler = this;
		this.RBtn = component.transform;
		this.MoveTime2 = this.RBtn.localPosition.x;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component5 = this.AGS_Form.GetChild(6).gameObject.GetComponent<RectTransform>();
			component5.localScale = new Vector3(-1f, 1f, 1f);
		}
		this.lastVipLevel = (ushort)(instance.VIPLevelTable.TableCount - 1);
		this.UpdateInfo();
		this.Ltext = StringManager.Instance.SpawnString(1200);
		this.Rtext = StringManager.Instance.SpawnString(1200);
		this.SetShowVip(0);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 8, 0);
	}

	// Token: 0x060020AE RID: 8366 RVA: 0x003E2424 File Offset: 0x003E0624
	private void UpdateInfo()
	{
		VIP_DataTbl recordByKey = DataManager.Instance.VIPLevelTable.GetRecordByKey((ushort)DataManager.Instance.RoleAttr.VIPLevel);
		UIText component = this.AGS_Form.GetChild(2).GetComponent<UIText>();
		this.tmpString[0].ClearString();
		this.tmpString[0].Append(DataManager.Instance.mStringTable.GetStringByID(7701u));
		int num = (int)(recordByKey.loginPoint + recordByKey.dailyAdd * (DataManager.Instance.RoleAttr.SuccessiveLoginDays + 1));
		if (num > 600)
		{
			num = 600;
		}
		this.tmpString[0].IntToFormat((long)num, 1, false);
		this.tmpString[0].AppendFormat("{0}");
		component.text = this.tmpString[0].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(3).GetComponent<UIText>();
		this.tmpString[1].ClearString();
		this.tmpString[1].Append(DataManager.Instance.mStringTable.GetStringByID(7702u));
		this.tmpString[1].IntToFormat((long)(DataManager.Instance.RoleAttr.SuccessiveLoginDays + 1), 1, true);
		this.tmpString[1].AppendFormat("{0}");
		component.text = this.tmpString[1].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIText>();
		this.tmpString[2].ClearString();
		if (recordByKey.VIPLevel > this.lastVipLevel)
		{
			this.tmpString[2].Append(DataManager.Instance.mStringTable.GetStringByID(7725u));
		}
		else
		{
			this.tmpString[2].Append(DataManager.Instance.mStringTable.GetStringByID(7703u));
			this.tmpString[2].IntToFormat((long)((ulong)DataManager.Instance.RoleAttr.VipPoint), 1, true);
			this.tmpString[2].IntToFormat((long)((ulong)recordByKey.VIPPoint), 1, true);
			this.tmpString[2].AppendFormat("{0} / {1}");
		}
		component.text = this.tmpString[2].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		RectTransform component2 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<RectTransform>();
		float num2 = DataManager.Instance.RoleAttr.VipPoint / recordByKey.VIPPoint;
		num2 = Mathf.Min(num2, 1f);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 422f);
		component = this.AGS_Form.GetChild(7).GetComponent<UIText>();
		this.tmpString[3].ClearString();
		this.tmpString[3].IntToFormat((long)recordByKey.VIPLevel, 1, false);
		this.tmpString[3].AppendFormat("{0}");
		component.text = this.tmpString[3].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
	}

	// Token: 0x060020AF RID: 8367 RVA: 0x003E2750 File Offset: 0x003E0950
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(3).GetComponent<UIText>();
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
		component = this.AGS_Form.GetChild(5).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(7).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(11).GetComponent<UIText>();
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
		component = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(15).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(15).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(16).GetChild(0).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(16).GetChild(0).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
	}

	// Token: 0x060020B0 RID: 8368 RVA: 0x003E2A34 File Offset: 0x003E0C34
	public override void OnClose()
	{
		for (int i = 0; i < this.tmpString.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.tmpString[i]);
		}
		StringManager.Instance.DeSpawnString(this.Ltext);
		StringManager.Instance.DeSpawnString(this.Rtext);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 7, 0);
	}

	// Token: 0x060020B1 RID: 8369 RVA: 0x003E2AA0 File Offset: 0x003E0CA0
	private void SetShowVip(ushort _targetLevel)
	{
		ushort viplevel = (ushort)DataManager.Instance.RoleAttr.VIPLevel;
		if (_targetLevel == 0)
		{
			_targetLevel = viplevel;
		}
		if (_targetLevel > this.lastVipLevel)
		{
			_targetLevel = this.lastVipLevel;
		}
		if (this.targetLevel == _targetLevel)
		{
			return;
		}
		this.targetLevel = _targetLevel;
		this.AGS_Form.GetChild(17).gameObject.SetActive(this.targetLevel != 1);
		this.AGS_Form.GetChild(18).gameObject.SetActive(this.targetLevel != this.lastVipLevel);
		DataManager instance = DataManager.Instance;
		VIP_DataTbl recordByKey = instance.VIPLevelTable.GetRecordByKey(this.targetLevel);
		VIP_DataTbl recordByKey2 = instance.VIPLevelTable.GetRecordByKey(this.targetLevel + 1);
		UIText component = this.AGS_Form.GetChild(14).GetChild(2).GetComponent<UIText>();
		this.tmpString[4].ClearString();
		this.tmpString[4].Append(DataManager.Instance.mStringTable.GetStringByID(7705u));
		this.tmpString[4].IntToFormat((long)recordByKey.VIPLevel, 1, false);
		this.tmpString[4].AppendFormat(" {0}");
		component.text = this.tmpString[4].ToString();
		if (recordByKey.VIPLevel > viplevel)
		{
			component.color = new Color(0.6f, 0.58f, 0.38f);
		}
		else
		{
			component.color = new Color(1f, 0.97f, 0.63f);
		}
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(15).GetChild(2).GetComponent<UIText>();
		this.tmpString[5].ClearString();
		this.tmpString[5].Append(DataManager.Instance.mStringTable.GetStringByID(7705u));
		this.tmpString[5].IntToFormat((long)recordByKey2.VIPLevel, 1, false);
		this.tmpString[5].AppendFormat(" {0}");
		component.text = this.tmpString[5].ToString();
		if (recordByKey2.VIPLevel > viplevel)
		{
			component.color = new Color(0.6f, 0.58f, 0.38f);
		}
		else
		{
			component.color = new Color(1f, 0.97f, 0.63f);
		}
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<UIText>();
		if (recordByKey.VIPLevel > viplevel)
		{
			component.color = new Color(0.6f, 0.58f, 0.38f);
		}
		else
		{
			component.color = new Color(1f, 0.97f, 0.63f);
		}
		component = this.AGS_Form.GetChild(15).GetChild(3).GetComponent<UIText>();
		if (recordByKey2.VIPLevel > viplevel)
		{
			component.color = new Color(0.6f, 0.58f, 0.38f);
		}
		else
		{
			component.color = new Color(1f, 0.97f, 0.63f);
		}
		Image component2 = this.AGS_Form.GetChild(14).GetChild(1).GetComponent<Image>();
		if (recordByKey.VIPLevel > viplevel)
		{
			component2.color = new Color(0.5f, 0.5f, 0.5f);
		}
		else
		{
			component2.color = new Color(1f, 1f, 1f);
		}
		component2 = this.AGS_Form.GetChild(15).GetChild(1).GetComponent<Image>();
		if (recordByKey2.VIPLevel > viplevel)
		{
			component2.color = new Color(0.5f, 0.5f, 0.5f);
		}
		else
		{
			component2.color = new Color(1f, 1f, 1f);
		}
		component2 = this.AGS_Form.GetChild(14).GetChild(4).GetComponent<Image>();
		if (recordByKey.VIPLevel > viplevel)
		{
			component2.color = new Color(0.5f, 0.5f, 0.5f);
		}
		else
		{
			component2.color = new Color(1f, 1f, 1f);
		}
		component2 = this.AGS_Form.GetChild(15).GetChild(4).GetComponent<Image>();
		if (recordByKey2.VIPLevel > viplevel)
		{
			component2.color = new Color(0.5f, 0.5f, 0.5f);
		}
		else
		{
			component2.color = new Color(1f, 1f, 1f);
		}
		component = this.AGS_Form.GetChild(16).GetChild(0).GetChild(0).GetComponent<UIText>();
		if (recordByKey.VIPLevel > viplevel)
		{
			component.color = new Color(0.7f, 0.7f, 0.7f);
		}
		else
		{
			component.color = new Color(1f, 1f, 1f);
		}
		this.CreateVipText(recordByKey.VIPLevel, this.Ltext);
		component.text = this.Ltext.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component.cachedTextGeneratorForLayout.Invalidate();
		float preferredHeight = component.preferredHeight;
		RectTransform component3 = this.AGS_Form.GetChild(16).GetChild(0).GetChild(0).GetComponent<RectTransform>();
		component3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, preferredHeight);
		component = this.AGS_Form.GetChild(16).GetChild(0).GetChild(1).GetComponent<UIText>();
		if (recordByKey2.VIPLevel > viplevel)
		{
			component.color = new Color(0.7f, 0.7f, 0.7f);
		}
		else
		{
			component.color = new Color(1f, 1f, 1f);
		}
		this.CreateVipText(recordByKey2.VIPLevel, this.Rtext);
		component.text = this.Rtext.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component.cachedTextGeneratorForLayout.Invalidate();
		preferredHeight = component.preferredHeight;
		component3 = this.AGS_Form.GetChild(16).GetChild(0).GetChild(1).GetComponent<RectTransform>();
		component3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, preferredHeight);
		component3 = this.AGS_Form.GetChild(16).GetChild(0).GetComponent<RectTransform>();
		component3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, preferredHeight);
		component = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<UIText>();
		if (recordByKey.VIPLevel > viplevel)
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(7707u);
			component.gameObject.SetActive(true);
		}
		else if (recordByKey.VIPLevel == viplevel)
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(7706u);
			component.gameObject.SetActive(true);
		}
		else
		{
			component.gameObject.SetActive(false);
		}
		component = this.AGS_Form.GetChild(15).GetChild(3).GetComponent<UIText>();
		if (recordByKey2.VIPLevel > viplevel)
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(7707u);
			component.gameObject.SetActive(true);
		}
		else if (recordByKey2.VIPLevel == viplevel)
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(7706u);
			component.gameObject.SetActive(true);
		}
		else
		{
			component.gameObject.SetActive(false);
		}
	}

	// Token: 0x060020B2 RID: 8370 RVA: 0x003E3258 File Offset: 0x003E1458
	private int CreateVipText(ushort targetLevel, CString str)
	{
		DataManager instance = DataManager.Instance;
		int num = 0;
		VIP_DataTbl recordByKey = instance.VIPLevelTable.GetRecordByKey((ushort)instance.RoleAttr.VIPLevel);
		VIP_DataTbl recordByKey2 = instance.VIPLevelTable.GetRecordByKey(targetLevel);
		CString cstring = StringManager.Instance.SpawnString(300);
		CString cstring2 = StringManager.Instance.SpawnString(300);
		string format;
		if (GUIManager.Instance.IsArabic)
		{
			format = "{0} . {1}\n";
		}
		else
		{
			format = "{0}. {1}\n";
		}
		string format2 = "<color=#00FFFF>{0}</color>";
		str.ClearString();
		if (recordByKey2.QuickCompleteMin > 0)
		{
			cstring.ClearString();
			num++;
			if (recordByKey.QuickCompleteMin == 0)
			{
				cstring2.ClearString();
				cstring2.IntToFormat((long)recordByKey2.QuickCompleteMin, 1, false);
				cstring2.AppendFormat(instance.mStringTable.GetStringByID(7710u));
				cstring.StringToFormat(cstring2);
				cstring.AppendFormat(format2);
			}
			else if (recordByKey2.QuickCompleteMin > recordByKey.QuickCompleteMin)
			{
				cstring2.ClearString();
				cstring2.IntToFormat((long)recordByKey2.QuickCompleteMin, 1, false);
				cstring2.AppendFormat(format2);
				cstring.StringToFormat(cstring2);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7710u));
			}
			else
			{
				cstring.IntToFormat((long)recordByKey2.QuickCompleteMin, 1, false);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7710u));
			}
			str.IntToFormat((long)num, 1, false);
			str.StringToFormat(cstring);
			str.AppendFormat(format);
		}
		if (recordByKey2.moraleBanner > 0)
		{
			cstring.ClearString();
			num++;
			if (recordByKey.moraleBanner == 0)
			{
				if (recordByKey2.moraleBanner == 255)
				{
					cstring2.ClearString();
					cstring2.AppendFormat(instance.mStringTable.GetStringByID(7721u));
					cstring.StringToFormat(cstring2);
					cstring.AppendFormat(format2);
				}
				else
				{
					cstring2.ClearString();
					cstring2.IntToFormat((long)recordByKey2.moraleBanner, 1, false);
					cstring2.AppendFormat(instance.mStringTable.GetStringByID(7711u));
					cstring.StringToFormat(cstring2);
					cstring.AppendFormat(format2);
				}
			}
			else if (recordByKey2.moraleBanner == 255)
			{
				if (recordByKey.moraleBanner != 255)
				{
					cstring.StringToFormat(instance.mStringTable.GetStringByID(7721u));
					cstring.AppendFormat(format2);
				}
				else
				{
					cstring.AppendFormat(instance.mStringTable.GetStringByID(7721u));
				}
			}
			else if (recordByKey2.moraleBanner > recordByKey.moraleBanner)
			{
				cstring2.ClearString();
				cstring2.IntToFormat((long)recordByKey2.moraleBanner, 1, false);
				cstring2.AppendFormat(format2);
				cstring.StringToFormat(cstring2);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7711u));
			}
			else
			{
				cstring.IntToFormat((long)recordByKey2.moraleBanner, 1, false);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7711u));
			}
			str.IntToFormat((long)num, 1, false);
			str.StringToFormat(cstring);
			str.AppendFormat(format);
		}
		if (recordByKey2.DailyResetElite > 0)
		{
			cstring.ClearString();
			num++;
			if (recordByKey.DailyResetElite == 0)
			{
				if (recordByKey2.DailyResetElite == 255)
				{
					cstring2.ClearString();
					cstring2.AppendFormat(instance.mStringTable.GetStringByID(7722u));
					cstring.StringToFormat(cstring2);
					cstring.AppendFormat(format2);
				}
				else
				{
					cstring2.ClearString();
					cstring2.IntToFormat((long)recordByKey2.moraleBanner, 1, false);
					cstring2.AppendFormat(instance.mStringTable.GetStringByID(7712u));
					cstring.StringToFormat(cstring2);
					cstring.AppendFormat(format2);
				}
			}
			else if (recordByKey2.DailyResetElite == 255)
			{
				if (recordByKey.moraleBanner != 255)
				{
					cstring.StringToFormat(instance.mStringTable.GetStringByID(7722u));
					cstring.AppendFormat(format2);
				}
				else
				{
					cstring.AppendFormat(instance.mStringTable.GetStringByID(7722u));
				}
			}
			else if (recordByKey2.DailyResetElite > recordByKey.DailyResetElite)
			{
				cstring2.ClearString();
				cstring2.IntToFormat((long)recordByKey2.DailyResetElite, 1, false);
				cstring2.AppendFormat(format2);
				cstring.StringToFormat(cstring2);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7712u));
			}
			else
			{
				cstring.IntToFormat((long)recordByKey2.DailyResetElite, 1, false);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7712u));
			}
			str.IntToFormat((long)num, 1, false);
			str.StringToFormat(cstring);
			str.AppendFormat(format);
		}
		if (recordByKey2.AutoDailyMission > 0)
		{
			cstring.ClearString();
			num++;
			if (recordByKey.AutoDailyMission == 0)
			{
				cstring.StringToFormat(instance.mStringTable.GetStringByID(7715u));
				cstring.AppendFormat(format2);
				str.IntToFormat((long)num, 1, false);
				str.StringToFormat(cstring);
				str.AppendFormat(format);
			}
			else
			{
				str.IntToFormat((long)num, 1, false);
				str.StringToFormat(instance.mStringTable.GetStringByID(7715u));
				str.AppendFormat(format);
			}
		}
		if (recordByKey2.AutoDailyAlliMission > 0)
		{
			cstring.ClearString();
			num++;
			if (recordByKey.AutoDailyAlliMission == 0)
			{
				cstring.StringToFormat(instance.mStringTable.GetStringByID(7716u));
				cstring.AppendFormat(format2);
				str.IntToFormat((long)num, 1, false);
				str.StringToFormat(cstring);
				str.AppendFormat(format);
			}
			else
			{
				str.IntToFormat((long)num, 1, false);
				str.StringToFormat(instance.mStringTable.GetStringByID(7716u));
				str.AppendFormat(format);
			}
		}
		if ((recordByKey2.UnlockBuySkill & 1) == 1)
		{
			cstring.ClearString();
			num++;
			if ((recordByKey.UnlockBuySkill & 1) != 1)
			{
				cstring.StringToFormat(instance.mStringTable.GetStringByID(7714u));
				cstring.AppendFormat(format2);
				str.IntToFormat((long)num, 1, false);
				str.StringToFormat(cstring);
				str.AppendFormat(format);
			}
			else
			{
				str.IntToFormat((long)num, 1, false);
				str.StringToFormat(instance.mStringTable.GetStringByID(7714u));
				str.AppendFormat(format);
			}
		}
		if (recordByKey2.AutoFightMission > 0)
		{
			cstring.ClearString();
			num++;
			if (recordByKey.AutoFightMission == 0)
			{
				cstring.StringToFormat(instance.mStringTable.GetStringByID(7717u));
				cstring.AppendFormat(format2);
			}
			else if (recordByKey2.AutoFightMission > recordByKey.AutoFightMission)
			{
				cstring2.ClearString();
				cstring2.IntToFormat((long)recordByKey2.AutoFightMission, 1, false);
				cstring2.AppendFormat(format2);
				cstring.StringToFormat(cstring2);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7717u));
			}
			else
			{
				cstring.IntToFormat((long)recordByKey2.AutoFightMission, 1, false);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7717u));
			}
			str.IntToFormat((long)num, 1, false);
			str.StringToFormat(cstring);
			str.AppendFormat(format);
		}
		if (recordByKey2.VipMission > 0)
		{
			cstring.ClearString();
			num++;
			if (recordByKey.VipMission == 0)
			{
				cstring2.ClearString();
				cstring2.IntToFormat((long)recordByKey2.VipMission, 1, false);
				cstring2.AppendFormat(instance.mStringTable.GetStringByID(7718u));
				cstring.StringToFormat(cstring2);
				cstring.AppendFormat(format2);
			}
			else if (recordByKey2.VipMission > recordByKey.VipMission)
			{
				cstring2.ClearString();
				cstring2.IntToFormat((long)recordByKey2.VipMission, 1, false);
				cstring2.AppendFormat(format2);
				cstring.StringToFormat(cstring2);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7718u));
			}
			else
			{
				cstring.IntToFormat((long)recordByKey2.VipMission, 1, false);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7718u));
			}
			str.IntToFormat((long)num, 1, false);
			str.StringToFormat(cstring);
			str.AppendFormat(format);
		}
		if (recordByKey2.DailyMission > 0)
		{
			cstring.ClearString();
			num++;
			if (recordByKey.DailyMission == 0)
			{
				cstring2.ClearString();
				cstring2.IntToFormat((long)recordByKey2.DailyMission, 1, false);
				cstring2.AppendFormat(instance.mStringTable.GetStringByID(7719u));
				cstring.StringToFormat(cstring2);
				cstring.AppendFormat(format2);
			}
			else if (recordByKey2.DailyMission > recordByKey.DailyMission)
			{
				cstring2.ClearString();
				cstring2.IntToFormat((long)recordByKey2.DailyMission, 1, false);
				cstring2.AppendFormat(format2);
				cstring.StringToFormat(cstring2);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7719u));
			}
			else
			{
				cstring.IntToFormat((long)recordByKey2.DailyMission, 1, false);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7719u));
			}
			str.IntToFormat((long)num, 1, false);
			str.StringToFormat(cstring);
			str.AppendFormat(format);
		}
		if (recordByKey2.AlliMission > 0)
		{
			cstring.ClearString();
			num++;
			if (recordByKey.AlliMission == 0)
			{
				cstring2.ClearString();
				cstring2.IntToFormat((long)recordByKey2.AlliMission, 1, false);
				cstring2.AppendFormat(instance.mStringTable.GetStringByID(7719u));
				cstring.StringToFormat(cstring2);
				cstring.AppendFormat(format2);
			}
			else if (recordByKey2.AlliMission > recordByKey.AlliMission)
			{
				cstring2.ClearString();
				cstring2.IntToFormat((long)recordByKey2.AlliMission, 1, false);
				cstring2.AppendFormat(format2);
				cstring.StringToFormat(cstring2);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7720u));
			}
			else
			{
				cstring.IntToFormat((long)recordByKey2.AlliMission, 1, false);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(7720u));
			}
			str.IntToFormat((long)num, 1, false);
			str.StringToFormat(cstring);
			str.AppendFormat(format);
		}
		for (int i = 0; i < 15; i++)
		{
			int num2 = i * 2;
			if (recordByKey2.Effects[num2] > 0)
			{
				Effect recordByKey3 = DataManager.Instance.EffectData.GetRecordByKey(recordByKey2.Effects[num2]);
				cstring.ClearString();
				num++;
				int num3 = (int)recordByKey2.Effects[num2 + 1];
				if (recordByKey3.ValueID == 4378)
				{
					num3 /= 100;
				}
				if (recordByKey.Effects[num2 + 1] == 0)
				{
					cstring2.ClearString();
					cstring2.Append(instance.mStringTable.GetStringByID((uint)recordByKey3.String_infoID));
					cstring2.IntToFormat((long)num3, 1, false);
					cstring2.AppendFormat("{0}");
					cstring2.Append(instance.mStringTable.GetStringByID((uint)recordByKey3.ValueID));
					cstring.StringToFormat(cstring2);
					cstring.AppendFormat(format2);
				}
				else if (recordByKey2.Effects[num2 + 1] > recordByKey.Effects[num2 + 1])
				{
					cstring2.ClearString();
					cstring2.IntToFormat((long)num3, 1, false);
					cstring2.AppendFormat(format2);
					cstring.Append(instance.mStringTable.GetStringByID((uint)recordByKey3.String_infoID));
					cstring.Append(cstring2);
					cstring.Append(instance.mStringTable.GetStringByID((uint)recordByKey3.ValueID));
				}
				else
				{
					cstring.Append(instance.mStringTable.GetStringByID((uint)recordByKey3.String_infoID));
					cstring.IntToFormat((long)num3, 1, false);
					cstring.AppendFormat("{0}");
					cstring.Append(instance.mStringTable.GetStringByID((uint)recordByKey3.ValueID));
				}
				str.IntToFormat((long)num, 1, false);
				str.StringToFormat(cstring);
				str.AppendFormat(format);
			}
		}
		StringManager.Instance.DeSpawnString(cstring2);
		StringManager.Instance.DeSpawnString(cstring);
		return num;
	}

	// Token: 0x060020B3 RID: 8371 RVA: 0x003E3F10 File Offset: 0x003E2110
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			this.door.CloseMenu(false);
			break;
		case 1:
		{
			int btnID = sender.m_BtnID2;
			if (btnID != 0)
			{
				if (btnID == 1)
				{
					GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7705u), DataManager.Instance.mStringTable.GetStringByID(7708u), null, null, 0, 0, true, true);
				}
			}
			else
			{
				GUIManager.Instance.OpenItemKindFilterUI(13, 1, 0);
			}
			break;
		}
		case 2:
		{
			int btnID = sender.m_BtnID2;
			if (btnID != 0)
			{
				if (btnID == 1)
				{
					this.SetShowVip(this.targetLevel + 1);
				}
			}
			else if (this.targetLevel > 1)
			{
				this.SetShowVip(this.targetLevel - 1);
			}
			break;
		}
		}
	}

	// Token: 0x060020B4 RID: 8372 RVA: 0x003E400C File Offset: 0x003E220C
	public void Update()
	{
		this.TmpTime += Time.smoothDeltaTime * 40f;
		if (this.TmpTime >= 40f)
		{
			this.TmpTime = 0f;
		}
		float num = (this.TmpTime <= 20f) ? this.TmpTime : (40f - this.TmpTime);
		if (num < 0f)
		{
			num = 0f;
		}
		this.Vec3Instance.Set(this.MoveTime1 - num, this.LBtn.localPosition.y, this.LBtn.localPosition.z);
		this.LBtn.localPosition = this.Vec3Instance;
		this.Vec3Instance.Set(this.MoveTime2 + num, this.RBtn.localPosition.y, this.RBtn.localPosition.z);
		this.RBtn.localPosition = this.Vec3Instance;
		this.GetPointTime += Time.smoothDeltaTime;
		if (this.GetPointTime >= 2f)
		{
			this.GetPointTime = 0f;
		}
		float a = (this.GetPointTime <= 1f) ? this.GetPointTime : (2f - this.GetPointTime);
		this.Img_GetPoint.color = new Color(1f, 1f, 1f, a);
	}

	// Token: 0x060020B5 RID: 8373 RVA: 0x003E4190 File Offset: 0x003E2390
	public override void UpdateUI(int arg1, int arg2)
	{
		this.UpdateInfo();
	}

	// Token: 0x060020B6 RID: 8374 RVA: 0x003E4198 File Offset: 0x003E2398
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
		}
		else
		{
			this.UpdateInfo();
		}
	}

	// Token: 0x04006716 RID: 26390
	private Transform AGS_Form;

	// Token: 0x04006717 RID: 26391
	private Door door;

	// Token: 0x04006718 RID: 26392
	private CString[] tmpString = new CString[8];

	// Token: 0x04006719 RID: 26393
	private ushort targetLevel;

	// Token: 0x0400671A RID: 26394
	private CString Ltext;

	// Token: 0x0400671B RID: 26395
	private CString Rtext;

	// Token: 0x0400671C RID: 26396
	private Transform LBtn;

	// Token: 0x0400671D RID: 26397
	private Transform RBtn;

	// Token: 0x0400671E RID: 26398
	private float TmpTime;

	// Token: 0x0400671F RID: 26399
	private Vector3 Vec3Instance;

	// Token: 0x04006720 RID: 26400
	private float MoveTime1;

	// Token: 0x04006721 RID: 26401
	private float MoveTime2;

	// Token: 0x04006722 RID: 26402
	private float GetPointTime;

	// Token: 0x04006723 RID: 26403
	private Image Img_GetPoint;

	// Token: 0x04006724 RID: 26404
	private ushort lastVipLevel;

	// Token: 0x020006A9 RID: 1705
	private enum e_AGS_UI_VIP_Editor
	{
		// Token: 0x04006726 RID: 26406
		CloseDeco,
		// Token: 0x04006727 RID: 26407
		bgPanel,
		// Token: 0x04006728 RID: 26408
		label1,
		// Token: 0x04006729 RID: 26409
		label2,
		// Token: 0x0400672A RID: 26410
		BarBG,
		// Token: 0x0400672B RID: 26411
		GetPoint,
		// Token: 0x0400672C RID: 26412
		VipStar,
		// Token: 0x0400672D RID: 26413
		VIPLevel,
		// Token: 0x0400672E RID: 26414
		VipInfo,
		// Token: 0x0400672F RID: 26415
		title,
		// Token: 0x04006730 RID: 26416
		TitleStar,
		// Token: 0x04006731 RID: 26417
		TitleText,
		// Token: 0x04006732 RID: 26418
		flag1,
		// Token: 0x04006733 RID: 26419
		flag2,
		// Token: 0x04006734 RID: 26420
		LeftPanel,
		// Token: 0x04006735 RID: 26421
		RightPanel,
		// Token: 0x04006736 RID: 26422
		ScrollPanel,
		// Token: 0x04006737 RID: 26423
		LBtn,
		// Token: 0x04006738 RID: 26424
		RBtn
	}

	// Token: 0x020006AA RID: 1706
	private enum e_AGS_BarBG
	{
		// Token: 0x0400673A RID: 26426
		Bar,
		// Token: 0x0400673B RID: 26427
		BarText
	}

	// Token: 0x020006AB RID: 1707
	private enum e_AGS_GetPoint
	{
		// Token: 0x0400673D RID: 26429
		OverImage,
		// Token: 0x0400673E RID: 26430
		Text
	}

	// Token: 0x020006AC RID: 1708
	private enum e_AGS_LeftPanel
	{
		// Token: 0x04006740 RID: 26432
		bgLight,
		// Token: 0x04006741 RID: 26433
		flagTitle,
		// Token: 0x04006742 RID: 26434
		flagLevel,
		// Token: 0x04006743 RID: 26435
		flagText,
		// Token: 0x04006744 RID: 26436
		flagbar
	}

	// Token: 0x020006AD RID: 1709
	private enum e_AGS_RightPanel
	{
		// Token: 0x04006746 RID: 26438
		bgLight,
		// Token: 0x04006747 RID: 26439
		flagTitle,
		// Token: 0x04006748 RID: 26440
		flagLevel,
		// Token: 0x04006749 RID: 26441
		flagText,
		// Token: 0x0400674A RID: 26442
		flagbar
	}

	// Token: 0x020006AE RID: 1710
	private enum e_AGS_ScrollPanel
	{
		// Token: 0x0400674C RID: 26444
		Panel
	}

	// Token: 0x020006AF RID: 1711
	private enum e_AGS_Panel
	{
		// Token: 0x0400674E RID: 26446
		LText,
		// Token: 0x0400674F RID: 26447
		RText
	}
}
