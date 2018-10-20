using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200033A RID: 826
public class UIArena_Info : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x060010D0 RID: 4304 RVA: 0x001DF18C File Offset: 0x001DD38C
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.AM = ArenaManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		Material material = this.door.LoadMaterial();
		this.Cstr_NowCD = StringManager.Instance.SpawnString(30);
		this.Cstr_NextCD = StringManager.Instance.SpawnString(30);
		for (int i = 0; i < 2; i++)
		{
			this.Cstr_NowTopic_Info[i] = StringManager.Instance.SpawnString(100);
			this.Cstr_NextTopic_Info[i] = StringManager.Instance.SpawnString(100);
		}
		Transform child = this.GameT.GetChild(0);
		Transform child2 = child.GetChild(0).GetChild(0);
		this.text_Title = child2.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(9111u);
		child2 = child.GetChild(1).GetChild(0);
		this.text_Info = child2.GetComponent<UIText>();
		this.text_Info.font = this.TTFont;
		this.text_Info.text = this.DM.mStringTable.GetStringByID(9112u);
		child = this.GameT.GetChild(1);
		this.ImgNowCD = child.GetChild(0).GetComponent<Image>();
		for (int j = 0; j < 2; j++)
		{
			child2 = child.GetChild(0).GetChild(j);
			this.text_NowCD[j] = child2.GetComponent<UIText>();
			this.text_NowCD[j].font = this.TTFont;
		}
		this.text_NowCD[0].text = this.DM.mStringTable.GetStringByID(9114u);
		child2 = child.GetChild(1);
		this.text_NowTopic = child2.GetComponent<UIText>();
		this.text_NowTopic.font = this.TTFont;
		this.text_NowTopic.text = this.DM.mStringTable.GetStringByID(9113u);
		child2 = child.GetChild(2);
		this.text_Close = child2.GetComponent<UIText>();
		this.text_Close.font = this.TTFont;
		this.text_Close.text = this.DM.mStringTable.GetStringByID(9109u);
		for (int k = 0; k < 2; k++)
		{
			child2 = child.GetChild(3 + k);
			this.text_NowTopic_Info[k] = child2.GetComponent<UIText>();
			this.text_NowTopic_Info[k].font = this.TTFont;
			this.Cstr_NowTopic_Info[k].ClearString();
		}
		child = this.GameT.GetChild(2);
		this.ImgNextCD = child.GetChild(0).GetComponent<Image>();
		for (int l = 0; l < 2; l++)
		{
			child2 = child.GetChild(0).GetChild(l);
			this.text_NextCD[l] = child2.GetComponent<UIText>();
			this.text_NextCD[l].font = this.TTFont;
		}
		this.text_NextCD[0].text = this.DM.mStringTable.GetStringByID(9121u);
		child2 = child.GetChild(1);
		this.text_NextTopic = child2.GetComponent<UIText>();
		this.text_NextTopic.font = this.TTFont;
		this.text_NextTopic.text = this.DM.mStringTable.GetStringByID(9117u);
		for (int m = 0; m < 2; m++)
		{
			child2 = child.GetChild(2 + m);
			this.text_NextTopic_Info[m] = child2.GetComponent<UIText>();
			this.text_NextTopic_Info[m].font = this.TTFont;
		}
		this.SetTopic();
		child = this.GameT.GetChild(3);
		Image component = child.GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = material;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component.enabled = false;
		}
		child = this.GameT.GetChild(3).GetChild(0);
		this.btn_EXIT = child.GetComponent<UIButton>();
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = material;
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x060010D1 RID: 4305 RVA: 0x001DF65C File Offset: 0x001DD85C
	public void SetTopic()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		for (int i = 0; i < 2; i++)
		{
			this.text_NextTopic_Info[i].gameObject.SetActive(true);
		}
		this.Cstr_NowTopic_Info[0].ClearString();
		this.Cstr_NowTopic_Info[1].ClearString();
		this.Cstr_NextTopic_Info[0].ClearString();
		this.Cstr_NextTopic_Info[1].ClearString();
		if (!this.AM.bArenaKVK)
		{
			this.ImgNowCD.gameObject.SetActive(true);
			this.ImgNextCD.gameObject.SetActive(false);
			for (int j = 0; j < 2; j++)
			{
				this.text_NowTopic_Info[j].gameObject.SetActive(true);
			}
			if (this.AM.m_NowArenaTopicID[0] != 0 && this.AM.m_NowArenaTopicID[1] != 0)
			{
				this.Cstr_NowTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200u + (uint)this.AM.m_NowArenaTopicID[0]));
				this.Cstr_NowTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200u + (uint)this.AM.m_NowArenaTopicID[1]));
				this.Cstr_NowTopic_Info[0].AppendFormat(this.DM.mStringTable.GetStringByID(9115u));
			}
			else
			{
				if (this.AM.m_NowArenaTopicID[0] != 0)
				{
					this.Cstr_NowTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200u + (uint)this.AM.m_NowArenaTopicID[0]));
				}
				else
				{
					this.Cstr_NowTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200u + (uint)this.AM.m_NowArenaTopicID[1]));
				}
				this.Cstr_NowTopic_Info[0].AppendFormat(this.DM.mStringTable.GetStringByID(9152u));
			}
			this.text_NowTopic_Info[0].text = this.Cstr_NowTopic_Info[0].ToString();
			this.text_NowTopic_Info[0].SetAllDirty();
			this.text_NowTopic_Info[0].cachedTextGenerator.Invalidate();
			this.text_NowTopic_Info[0].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_NowTopic_Info[0].preferredHeight > this.text_NowTopic_Info[0].rectTransform.sizeDelta.y)
			{
				this.text_NowTopic_Info[0].rectTransform.sizeDelta = new Vector2(this.text_NowTopic_Info[0].rectTransform.sizeDelta.x, this.text_NowTopic_Info[0].preferredHeight + 1f);
			}
			this.text_NowTopic_Info[1].rectTransform.anchoredPosition = new Vector2(this.text_NowTopic_Info[0].rectTransform.anchoredPosition.x, this.text_NowTopic_Info[0].rectTransform.anchoredPosition.y - (this.text_NowTopic_Info[0].preferredHeight + 1f + 14f));
			cstring.ClearString();
			cstring2.ClearString();
			if (this.AM.m_NowTopicEffect[0].Effect != 0 && this.AM.m_NowTopicEffect[1].Effect != 0)
			{
				GameConstants.GetEffectValue(cstring, this.AM.m_NowTopicEffect[0].Effect, (uint)this.AM.m_NowTopicEffect[0].Value, 10, 0f);
				GameConstants.GetEffectValue(cstring2, this.AM.m_NowTopicEffect[1].Effect, (uint)this.AM.m_NowTopicEffect[1].Value, 10, 0f);
				this.Cstr_NowTopic_Info[1].StringToFormat(cstring);
				this.Cstr_NowTopic_Info[1].StringToFormat(cstring2);
				this.Cstr_NowTopic_Info[1].AppendFormat(this.DM.mStringTable.GetStringByID(9116u));
			}
			else
			{
				if (this.AM.m_NowTopicEffect[0].Effect != 0)
				{
					GameConstants.GetEffectValue(cstring, this.AM.m_NowTopicEffect[0].Effect, (uint)this.AM.m_NowTopicEffect[0].Value, 10, 0f);
				}
				else
				{
					GameConstants.GetEffectValue(cstring, this.AM.m_NowTopicEffect[1].Effect, (uint)this.AM.m_NowTopicEffect[1].Value, 10, 0f);
				}
				this.Cstr_NowTopic_Info[1].StringToFormat(cstring);
				this.Cstr_NowTopic_Info[1].AppendFormat(this.DM.mStringTable.GetStringByID(9153u));
			}
			this.text_NowTopic_Info[1].text = this.Cstr_NowTopic_Info[1].ToString();
			this.text_NowTopic_Info[1].SetAllDirty();
			this.text_NowTopic_Info[1].cachedTextGenerator.Invalidate();
			this.text_NowTopic_Info[1].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_NowTopic_Info[1].preferredHeight > this.text_NowTopic_Info[1].rectTransform.sizeDelta.y)
			{
				this.text_NowTopic_Info[1].rectTransform.sizeDelta = new Vector2(this.text_NowTopic_Info[1].rectTransform.sizeDelta.x, this.text_NowTopic_Info[1].preferredHeight + 1f);
			}
			if (this.AM.m_NextArenaTopicID[0] != 0 && this.AM.m_NextArenaTopicID[1] != 0)
			{
				this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200u + (uint)this.AM.m_NextArenaTopicID[0]));
				this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200u + (uint)this.AM.m_NextArenaTopicID[1]));
				this.Cstr_NextTopic_Info[0].AppendFormat(this.DM.mStringTable.GetStringByID(9115u));
			}
			else
			{
				if (this.AM.m_NextArenaTopicID[0] != 0)
				{
					this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200u + (uint)this.AM.m_NextArenaTopicID[0]));
				}
				else
				{
					this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200u + (uint)this.AM.m_NextArenaTopicID[1]));
				}
				this.Cstr_NextTopic_Info[0].AppendFormat(this.DM.mStringTable.GetStringByID(9152u));
			}
			this.text_NextTopic_Info[0].text = this.Cstr_NextTopic_Info[0].ToString();
			this.text_NextTopic_Info[0].SetAllDirty();
			this.text_NextTopic_Info[0].cachedTextGenerator.Invalidate();
			this.text_NextTopic_Info[0].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_NextTopic_Info[0].preferredHeight > this.text_NextTopic_Info[0].rectTransform.sizeDelta.y)
			{
				this.text_NextTopic_Info[0].rectTransform.sizeDelta = new Vector2(this.text_NextTopic_Info[0].rectTransform.sizeDelta.x, this.text_NextTopic_Info[0].preferredHeight + 1f);
			}
			this.text_NextTopic_Info[1].rectTransform.anchoredPosition = new Vector2(this.text_NextTopic_Info[0].rectTransform.anchoredPosition.x, this.text_NextTopic_Info[0].rectTransform.anchoredPosition.y - (this.text_NextTopic_Info[0].preferredHeight + 1f + 14f));
			cstring.ClearString();
			cstring2.ClearString();
			if (this.AM.m_NextTopicEffect[0].Effect != 0 && this.AM.m_NextTopicEffect[1].Effect != 0)
			{
				GameConstants.GetEffectValue(cstring, this.AM.m_NextTopicEffect[0].Effect, (uint)this.AM.m_NextTopicEffect[0].Value, 10, 0f);
				GameConstants.GetEffectValue(cstring2, this.AM.m_NextTopicEffect[1].Effect, (uint)this.AM.m_NextTopicEffect[1].Value, 10, 0f);
				this.Cstr_NextTopic_Info[1].StringToFormat(cstring);
				this.Cstr_NextTopic_Info[1].StringToFormat(cstring2);
				this.Cstr_NextTopic_Info[1].AppendFormat(this.DM.mStringTable.GetStringByID(9116u));
			}
			else
			{
				if (this.AM.m_NextTopicEffect[0].Effect != 0)
				{
					GameConstants.GetEffectValue(cstring, this.AM.m_NextTopicEffect[0].Effect, (uint)this.AM.m_NextTopicEffect[0].Value, 10, 0f);
				}
				else
				{
					GameConstants.GetEffectValue(cstring, this.AM.m_NextTopicEffect[1].Effect, (uint)this.AM.m_NextTopicEffect[1].Value, 10, 0f);
				}
				this.Cstr_NextTopic_Info[1].StringToFormat(cstring);
				this.Cstr_NextTopic_Info[1].AppendFormat(this.DM.mStringTable.GetStringByID(9153u));
			}
			this.text_NextTopic_Info[1].text = this.Cstr_NextTopic_Info[1].ToString();
			this.text_NextTopic_Info[1].SetAllDirty();
			this.text_NextTopic_Info[1].cachedTextGenerator.Invalidate();
			this.text_NextTopic_Info[1].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_NextTopic_Info[1].preferredHeight > this.text_NextTopic_Info[1].rectTransform.sizeDelta.y)
			{
				this.text_NextTopic_Info[1].rectTransform.sizeDelta = new Vector2(this.text_NextTopic_Info[1].rectTransform.sizeDelta.x, this.text_NextTopic_Info[1].preferredHeight + 1f);
			}
		}
		else
		{
			this.text_Close.gameObject.SetActive(true);
			this.ImgNowCD.gameObject.SetActive(false);
			for (int k = 0; k < 2; k++)
			{
				this.text_NowTopic_Info[k].gameObject.SetActive(false);
			}
			if (this.AM.m_NextArenaTopicID[0] != 0 && this.AM.m_NextArenaTopicID[1] != 0)
			{
				this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200u + (uint)this.AM.m_NextArenaTopicID[0]));
				this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200u + (uint)this.AM.m_NextArenaTopicID[1]));
				this.Cstr_NextTopic_Info[0].AppendFormat(this.DM.mStringTable.GetStringByID(9115u));
			}
			else
			{
				if (this.AM.m_NextArenaTopicID[0] != 0)
				{
					this.Cstr_NextTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200u + (uint)this.AM.m_NextArenaTopicID[0]));
				}
				else
				{
					this.Cstr_NowTopic_Info[0].StringToFormat(this.DM.mStringTable.GetStringByID(9200u + (uint)this.AM.m_NextArenaTopicID[1]));
				}
				this.Cstr_NextTopic_Info[0].AppendFormat(this.DM.mStringTable.GetStringByID(9152u));
			}
			this.text_NextTopic_Info[0].text = this.Cstr_NextTopic_Info[0].ToString();
			this.text_NextTopic_Info[0].SetAllDirty();
			this.text_NextTopic_Info[0].cachedTextGenerator.Invalidate();
			this.text_NextTopic_Info[0].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_NextTopic_Info[0].preferredHeight > this.text_NextTopic_Info[0].rectTransform.sizeDelta.y)
			{
				this.text_NextTopic_Info[0].rectTransform.sizeDelta = new Vector2(this.text_NextTopic_Info[0].rectTransform.sizeDelta.x, this.text_NextTopic_Info[0].preferredHeight + 1f);
			}
			this.text_NextTopic_Info[1].rectTransform.anchoredPosition = new Vector2(this.text_NextTopic_Info[0].rectTransform.anchoredPosition.x, this.text_NextTopic_Info[0].rectTransform.anchoredPosition.y - (this.text_NextTopic_Info[0].preferredHeight + 1f + 14f));
			cstring.ClearString();
			cstring2.ClearString();
			if (this.AM.m_NextTopicEffect[0].Effect != 0 && this.AM.m_NextTopicEffect[1].Effect != 0)
			{
				GameConstants.GetEffectValue(cstring, this.AM.m_NowTopicEffect[0].Effect, (uint)this.AM.m_NextTopicEffect[0].Value, 10, 0f);
				GameConstants.GetEffectValue(cstring2, this.AM.m_NowTopicEffect[1].Effect, (uint)this.AM.m_NextTopicEffect[1].Value, 10, 0f);
				this.Cstr_NextTopic_Info[1].StringToFormat(cstring);
				this.Cstr_NextTopic_Info[1].StringToFormat(cstring2);
				this.Cstr_NextTopic_Info[1].AppendFormat(this.DM.mStringTable.GetStringByID(9116u));
			}
			else
			{
				if (this.AM.m_NextTopicEffect[0].Effect != 0)
				{
					GameConstants.GetEffectValue(cstring, this.AM.m_NextTopicEffect[0].Effect, (uint)this.AM.m_NextTopicEffect[0].Value, 10, 0f);
				}
				else
				{
					GameConstants.GetEffectValue(cstring, this.AM.m_NextTopicEffect[1].Effect, (uint)this.AM.m_NextTopicEffect[1].Value, 10, 0f);
				}
				this.Cstr_NextTopic_Info[1].StringToFormat(cstring);
				this.Cstr_NextTopic_Info[1].AppendFormat(this.DM.mStringTable.GetStringByID(9153u));
			}
			this.text_NextTopic_Info[1].text = this.Cstr_NextTopic_Info[1].ToString();
			this.text_NextTopic_Info[1].SetAllDirty();
			this.text_NextTopic_Info[1].cachedTextGenerator.Invalidate();
			this.text_NextTopic_Info[1].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_NextTopic_Info[1].preferredHeight > this.text_NextTopic_Info[1].rectTransform.sizeDelta.y)
			{
				this.text_NextTopic_Info[1].rectTransform.sizeDelta = new Vector2(this.text_NextTopic_Info[1].rectTransform.sizeDelta.x, this.text_NextTopic_Info[1].preferredHeight + 1f);
			}
		}
		if (this.ImgNowCD.IsActive())
		{
			this.Cstr_NowCD.ClearString();
			if (this.AM.m_NowArenaTopicEndTime >= this.DM.ServerTime)
			{
				if ((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) / 86400L > 0L)
				{
					this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) / 86400L, 1, false);
					this.Cstr_NowCD.AppendFormat("{0}d");
				}
				else
				{
					this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) % 86400L / 3600L, 2, false);
					this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) % 3600L / 60L, 2, false);
					this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) % 60L, 2, false);
					this.Cstr_NowCD.AppendFormat("{0}:{1}:{2}");
				}
			}
			else
			{
				this.Cstr_NowCD.IntToFormat(0L, 2, false);
				this.Cstr_NowCD.IntToFormat(0L, 2, false);
				this.Cstr_NowCD.IntToFormat(0L, 2, false);
				this.Cstr_NowCD.AppendFormat("{0}:{1}:{2}");
			}
			this.text_NowCD[1].text = this.Cstr_NowCD.ToString();
			this.text_NowCD[1].SetAllDirty();
			this.text_NowCD[1].cachedTextGenerator.Invalidate();
		}
		if (this.ImgNextCD.IsActive())
		{
			this.Cstr_NextCD.ClearString();
			long num;
			if (this.text_Close.IsActive())
			{
				num = this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime;
			}
			else
			{
				num = this.AM.m_NextArenaTopicBeginTime - this.DM.ServerTime;
			}
			if (num >= this.DM.ServerTime)
			{
				if (num / 86400L > 0L)
				{
					this.Cstr_NextCD.IntToFormat(num / 86400L, 1, false);
					this.Cstr_NextCD.AppendFormat("{0}d");
				}
				else
				{
					this.Cstr_NextCD.IntToFormat(num % 86400L / 3600L, 2, false);
					this.Cstr_NextCD.IntToFormat(num % 3600L / 60L, 2, false);
					this.Cstr_NextCD.IntToFormat(num % 60L, 2, false);
					this.Cstr_NextCD.AppendFormat("{0}:{1}:{2}");
				}
			}
			else
			{
				this.Cstr_NextCD.IntToFormat(0L, 2, false);
				this.Cstr_NextCD.IntToFormat(0L, 2, false);
				this.Cstr_NextCD.IntToFormat(0L, 2, false);
				this.Cstr_NextCD.AppendFormat("{0}:{1}:{2}");
			}
			this.text_NextCD[1].text = this.Cstr_NextCD.ToString();
			this.text_NextCD[1].SetAllDirty();
			this.text_NextCD[1].cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x060010D2 RID: 4306 RVA: 0x001E0970 File Offset: 0x001DEB70
	public override void OnClose()
	{
		if (this.Cstr_NowCD != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_NowCD);
		}
		if (this.Cstr_NextCD != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_NextCD);
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.Cstr_NowTopic_Info[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_NowTopic_Info[i]);
			}
			if (this.Cstr_NextTopic_Info[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_NextTopic_Info[i]);
			}
		}
	}

	// Token: 0x060010D3 RID: 4307 RVA: 0x001E0A08 File Offset: 0x001DEC08
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.ImgNowCD.IsActive())
		{
			this.Cstr_NowCD.ClearString();
			if (this.AM.m_NowArenaTopicEndTime >= this.DM.ServerTime)
			{
				if ((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) / 86400L > 0L)
				{
					this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) / 86400L, 1, false);
					this.Cstr_NowCD.AppendFormat("{0}d");
				}
				else
				{
					this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) % 86400L / 3600L, 2, false);
					this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) % 3600L / 60L, 2, false);
					this.Cstr_NowCD.IntToFormat((this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime) % 60L, 2, false);
					this.Cstr_NowCD.AppendFormat("{0}:{1}:{2}");
				}
			}
			else
			{
				this.Cstr_NowCD.IntToFormat(0L, 2, false);
				this.Cstr_NowCD.IntToFormat(0L, 2, false);
				this.Cstr_NowCD.IntToFormat(0L, 2, false);
				this.Cstr_NowCD.AppendFormat("{0}:{1}:{2}");
			}
			this.text_NowCD[1].text = this.Cstr_NowCD.ToString();
			this.text_NowCD[1].SetAllDirty();
			this.text_NowCD[1].cachedTextGenerator.Invalidate();
		}
		if (this.ImgNextCD.IsActive())
		{
			this.Cstr_NextCD.ClearString();
			long num;
			if (this.text_Close.IsActive())
			{
				num = this.AM.m_NowArenaTopicEndTime - this.DM.ServerTime;
			}
			else
			{
				num = this.AM.m_NextArenaTopicBeginTime - this.DM.ServerTime;
			}
			if (num >= this.DM.ServerTime)
			{
				if (num / 86400L > 0L)
				{
					this.Cstr_NextCD.IntToFormat(num / 86400L, 1, false);
					this.Cstr_NextCD.AppendFormat("{0}d");
				}
				else
				{
					this.Cstr_NextCD.IntToFormat(num % 86400L / 3600L, 2, false);
					this.Cstr_NextCD.IntToFormat(num % 3600L / 60L, 2, false);
					this.Cstr_NextCD.IntToFormat(num % 60L, 2, false);
					this.Cstr_NextCD.AppendFormat("{0}:{1}:{2}");
				}
			}
			else
			{
				this.Cstr_NextCD.IntToFormat(0L, 2, false);
				this.Cstr_NextCD.IntToFormat(0L, 2, false);
				this.Cstr_NextCD.IntToFormat(0L, 2, false);
				this.Cstr_NextCD.AppendFormat("{0}:{1}:{2}");
			}
			this.text_NextCD[1].text = this.Cstr_NextCD.ToString();
			this.text_NextCD[1].SetAllDirty();
			this.text_NextCD[1].cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x060010D4 RID: 4308 RVA: 0x001E0D50 File Offset: 0x001DEF50
	public void OnButtonClick(UIButton sender)
	{
		GUIArena_Info btnID = (GUIArena_Info)sender.m_BtnID1;
		if (btnID == GUIArena_Info.btn_EXIT)
		{
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x060010D5 RID: 4309 RVA: 0x001E0D94 File Offset: 0x001DEF94
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
			this.SetTopic();
		}
	}

	// Token: 0x060010D6 RID: 4310 RVA: 0x001E0DD0 File Offset: 0x001DEFD0
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_NowTopic != null && this.text_NowTopic.enabled)
		{
			this.text_NowTopic.enabled = false;
			this.text_NowTopic.enabled = true;
		}
		if (this.text_NextTopic != null && this.text_NextTopic.enabled)
		{
			this.text_NextTopic.enabled = false;
			this.text_NextTopic.enabled = true;
		}
		if (this.text_Info != null && this.text_Info.enabled)
		{
			this.text_Info.enabled = false;
			this.text_Info.enabled = true;
		}
		if (this.text_Close != null && this.text_Close.enabled)
		{
			this.text_Close.enabled = false;
			this.text_Close.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_NowTopic_Info[i] != null && this.text_NowTopic_Info[i].enabled)
			{
				this.text_NowTopic_Info[i].enabled = false;
				this.text_NowTopic_Info[i].enabled = true;
			}
			if (this.text_NextTopic_Info[i] != null && this.text_NextTopic_Info[i].enabled)
			{
				this.text_NextTopic_Info[i].enabled = false;
				this.text_NextTopic_Info[i].enabled = true;
			}
			if (this.text_NowCD[i] != null && this.text_NowCD[i].enabled)
			{
				this.text_NowCD[i].enabled = false;
				this.text_NowCD[i].enabled = true;
			}
			if (this.text_NextCD[i] != null && this.text_NextCD[i].enabled)
			{
				this.text_NextCD[i].enabled = false;
				this.text_NextCD[i].enabled = true;
			}
		}
	}

	// Token: 0x060010D7 RID: 4311 RVA: 0x001E1010 File Offset: 0x001DF210
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 1)
		{
			if (arg1 == 2)
			{
				this.AM.bArenaKVK = ActivityManager.Instance.IsInKvK(0, false);
				this.SetTopic();
			}
		}
		else
		{
			this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9162u), 255, true);
			this.SetTopic();
		}
	}

	// Token: 0x060010D8 RID: 4312 RVA: 0x001E1088 File Offset: 0x001DF288
	private void Start()
	{
	}

	// Token: 0x060010D9 RID: 4313 RVA: 0x001E108C File Offset: 0x001DF28C
	private void Update()
	{
	}

	// Token: 0x040036DB RID: 14043
	private DataManager DM;

	// Token: 0x040036DC RID: 14044
	private GUIManager GUIM;

	// Token: 0x040036DD RID: 14045
	private ArenaManager AM;

	// Token: 0x040036DE RID: 14046
	private Transform GameT;

	// Token: 0x040036DF RID: 14047
	private Door door;

	// Token: 0x040036E0 RID: 14048
	private Font TTFont;

	// Token: 0x040036E1 RID: 14049
	private UIButton btn_EXIT;

	// Token: 0x040036E2 RID: 14050
	private Image ImgNowCD;

	// Token: 0x040036E3 RID: 14051
	private Image ImgNextCD;

	// Token: 0x040036E4 RID: 14052
	private UIText text_Title;

	// Token: 0x040036E5 RID: 14053
	private UIText text_NowTopic;

	// Token: 0x040036E6 RID: 14054
	private UIText text_NextTopic;

	// Token: 0x040036E7 RID: 14055
	private UIText text_Info;

	// Token: 0x040036E8 RID: 14056
	private UIText text_Close;

	// Token: 0x040036E9 RID: 14057
	private UIText[] text_NowTopic_Info = new UIText[2];

	// Token: 0x040036EA RID: 14058
	private UIText[] text_NextTopic_Info = new UIText[2];

	// Token: 0x040036EB RID: 14059
	private UIText[] text_NowCD = new UIText[2];

	// Token: 0x040036EC RID: 14060
	private UIText[] text_NextCD = new UIText[2];

	// Token: 0x040036ED RID: 14061
	private CString Cstr_NowCD;

	// Token: 0x040036EE RID: 14062
	private CString Cstr_NextCD;

	// Token: 0x040036EF RID: 14063
	private CString[] Cstr_NowTopic_Info = new CString[2];

	// Token: 0x040036F0 RID: 14064
	private CString[] Cstr_NextTopic_Info = new CString[2];
}
