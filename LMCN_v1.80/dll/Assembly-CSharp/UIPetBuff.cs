using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000460 RID: 1120
public class UIPetBuff : PetBuff, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x06001687 RID: 5767 RVA: 0x0026BEFC File Offset: 0x0026A0FC
	public override void OnOpen(int arg1, int arg2)
	{
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		if (this.door)
		{
			this.door.UpdateUI(1, 4);
		}
		if (arg1 > 0)
		{
			base.transform.GetChild(1).gameObject.SetActive(false);
			base.transform.GetChild(4).gameObject.SetActive(false);
			base.transform.GetChild(2).gameObject.SetActive(true);
			this.m_Backdoor = base.transform.GetChild(2).GetChild(2).GetComponent<Image>();
			this.m_label[0] = base.transform.GetChild(2).GetChild(3).GetChild(0).GetComponent<Text>();
			this.m_label[0].text = this.DM.mStringTable.GetStringByID((arg1 <= 1) ? 10118u : 12552u);
			this.m_label[0].font = this.Font;
			this.m_label[1] = base.transform.GetChild(2).GetChild(5).GetChild(2).GetChild(0).GetComponent<Text>();
			this.m_label[1].font = this.Font;
			this.m_label[2] = base.transform.GetChild(2).GetChild(5).GetChild(2).GetChild(1).GetComponent<Text>();
			this.m_label[2].font = this.Font;
			base.transform.GetChild(2).GetChild(2).GetChild(0).gameObject.GetComponent<UIButton>().m_Handler = this;
			base.transform.GetChild(2).GetChild(2).GetChild(0).gameObject.GetComponent<UIButton>().m_Handler = this;
			if (arg1 > 1)
			{
				this.m_label[2].text = this.DM.mStringTable.GetStringByID(12588u);
				this.ItemsHeight.Add(this.m_label[2].preferredHeight + 20f);
				this.m_label[2].text = this.DM.mStringTable.GetStringByID(12589u);
				this.ItemsHeight.Add(this.m_label[2].preferredHeight);
				this.m_label[2].text = this.DM.mStringTable.GetStringByID(12590u);
				this.ItemsHeight.Add(this.m_label[2].preferredHeight);
				this.m_label[2].text = this.DM.mStringTable.GetStringByID(12591u);
				this.ItemsHeight.Add(this.m_label[2].preferredHeight);
			}
			else
			{
				for (int i = 0; i <= 12; i++)
				{
					if (i == 0 || i == 5 || i == 8)
					{
						this.m_label[1].text = this.DM.mStringTable.GetStringByID((uint)(i + 12579));
						this.ItemsHeight.Add(this.m_label[1].preferredHeight);
					}
					else
					{
						this.m_label[2].text = this.DM.mStringTable.GetStringByID((uint)(i + 12579));
						this.ItemsHeight.Add(this.m_label[2].preferredHeight + (float)((i != 4 && i != 7 && i != 9) ? 0 : 20));
					}
				}
			}
			this.m_label[1].text = string.Empty;
			this.m_label[2].text = string.Empty;
			this.type = arg1;
			this.m_scroll = base.transform.GetChild(2).GetChild(4).GetComponent<ScrollPanel>();
			this.m_scroll.IntiScrollPanel(298f, 3f, 0f, this.ItemsHeight, this.ItemsHeight.Count, this);
			this.m_scroll.gameObject.SetActive(true);
		}
		if (!this.m_Backdoor)
		{
			this.m_Backdoor = base.transform.GetChild(1).GetChild(6).GetComponent<Image>();
		}
		this.m_Backdoor.transform.GetChild(0).gameObject.GetComponent<UIButton>().m_Handler = this;
		this.m_Backdoor.sprite = this.door.LoadSprite("UI_main_close_base");
		this.m_Backdoor.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			this.m_Backdoor.enabled = false;
		}
		this.m_Backdoor = this.m_Backdoor.transform.GetChild(0).GetComponent<Image>();
		this.m_Backdoor.sprite = this.door.LoadSprite("UI_main_close");
		this.m_Backdoor.material = this.door.LoadMaterial();
		if (this.m_scroll)
		{
			return;
		}
		this.m_label[20] = base.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>();
		this.m_label[20].text = this.DM.mStringTable.GetStringByID(12551u);
		this.m_label[20].font = this.Font;
		this.m_label[21] = base.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>();
		this.m_label[21].text = this.DM.mStringTable.GetStringByID(12550u);
		this.m_label[21].font = this.Font;
		this.m_label[10] = base.transform.GetChild(4).GetChild(2).GetChild(0).GetChild(0).GetComponent<Text>();
		this.m_label[10].text = this.DM.mStringTable.GetStringByID(12552u);
		this.m_label[10].font = this.Font;
		this.m_label[11] = base.transform.GetChild(4).GetChild(2).GetChild(2).GetChild(0).GetComponent<Text>();
		this.m_label[11].text = this.DM.mStringTable.GetStringByID(12557u);
		this.m_label[11].font = this.Font;
		this.m_label[1] = base.transform.GetChild(4).GetChild(2).GetChild(3).GetChild(1).GetComponent<Text>();
		this.m_label[1].text = this.DM.mStringTable.GetStringByID(12558u);
		this.m_label[1].font = this.Font;
		this.m_label[2] = base.transform.GetChild(4).GetChild(2).GetChild(2).GetChild(2).GetComponent<Text>();
		this.m_label[2].font = this.Font;
		this.m_label[2] = base.transform.GetChild(4).GetChild(2).GetChild(3).GetChild(2).GetComponent<Text>();
		this.m_label[2].font = this.Font;
		this.m_label[2].text = this.DM.mStringTable.GetStringByID(6097u);
		this.m_label[2] = base.transform.GetChild(4).GetChild(2).GetChild(3).GetChild(3).GetComponent<Text>();
		this.m_label[2].font = this.Font;
		this.m_label[3] = base.transform.GetChild(4).GetChild(3).GetChild(0).GetChild(0).GetComponent<Text>();
		this.m_label[3].text = this.DM.mStringTable.GetStringByID(12553u);
		this.m_label[3].font = this.Font;
		this.m_label[3] = base.transform.GetChild(4).GetChild(3).GetChild(2).GetComponent<Text>();
		this.m_label[3].font = this.Font;
		this.m_label[3] = base.transform.GetChild(4).GetChild(3).GetChild(3).GetChild(1).GetComponent<Text>();
		this.m_label[3].font = this.Font;
		this.m_label[3] = base.transform.GetChild(4).GetChild(3).GetChild(3).GetChild(2).GetComponent<Text>();
		this.m_label[3].font = this.Font;
		this.m_label[4] = base.transform.GetChild(4).GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>();
		this.m_label[4].text = this.DM.mStringTable.GetStringByID(12554u);
		this.m_label[4].font = this.Font;
		this.m_label[5] = base.transform.GetChild(4).GetChild(4).GetChild(2).GetComponent<Text>();
		this.m_label[5].font = this.Font;
		this.m_label[6] = base.transform.GetChild(4).GetChild(4).GetChild(3).GetComponent<Text>();
		this.m_label[6].font = this.Font;
		this.m_label[6] = base.transform.GetChild(4).GetChild(4).GetChild(4).GetChild(1).GetComponent<Text>();
		this.m_label[6].text = this.DM.mStringTable.GetStringByID(6097u);
		this.m_label[6].font = this.Font;
		this.m_label[6] = base.transform.GetChild(4).GetChild(4).GetChild(4).GetChild(2).GetComponent<Text>();
		this.m_label[6].font = this.Font;
		this.m_label[6] = base.transform.GetChild(4).GetChild(4).GetChild(4).GetChild(4).GetComponent<Text>();
		this.m_label[6].font = this.Font;
		this.m_label[7] = base.transform.GetChild(4).GetChild(4).GetChild(6).GetComponent<Text>();
		this.m_label[7].font = this.Font;
		this.m_label[8] = base.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(0).GetComponent<Text>();
		this.m_label[8].text = this.DM.mStringTable.GetStringByID(94u);
		this.m_label[8].font = this.Font;
		this.m_label[8] = base.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(1).GetComponent<Text>();
		this.m_label[8].text = this.DM.mStringTable.GetStringByID(94u);
		this.m_label[8].font = this.Font;
		this.m_label[9] = base.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(2).GetChild(1).GetComponent<Text>();
		this.m_label[9].text = this.DM.mStringTable.GetStringByID(94u);
		this.m_label[9].font = this.Font;
		this.m_label[9] = base.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(2).GetChild(2).GetComponent<Text>();
		this.m_label[9].text = ((!GUIManager.Instance.IsArabic) ? "x1" : "1x");
		this.m_label[9].font = this.Font;
		this.m_label[9] = base.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(2).GetChild(3).GetComponent<Text>();
		this.m_label[9].text = this.DM.mStringTable.GetStringByID(94u);
		this.m_label[9].font = this.Font;
		this.m_label[9] = base.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(2).GetChild(4).GetComponent<Text>();
		this.m_label[9].text = ((!GUIManager.Instance.IsArabic) ? "x1" : "1x");
		this.m_label[9].font = this.Font;
		this.m_label[11] = base.transform.GetChild(4).GetChild(4).GetChild(9).GetComponent<Text>();
		this.m_label[11].text = ((!GUIManager.Instance.IsArabic) ? "x1" : "1x");
		this.m_label[11].font = this.Font;
		this.m_label[11] = base.transform.GetChild(4).GetChild(4).GetChild(10).GetComponent<Text>();
		this.m_label[11].font = this.Font;
		this.m_Dukedom = base.transform.GetChild(1).GetChild(19).GetComponent<Image>();
		if (GUIManager.Instance.IsArabic)
		{
			base.transform.GetChild(1).GetChild(16).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.GM.InitianHeroItemImg(base.transform.GetChild(4).GetChild(4).GetChild(7).GetChild(2).GetChild(0).GetChild(0).transform, eHeroOrItem.Item, 0, 0, 0, 0, false, false, true, false);
		base.transform.GetChild(1).GetChild(6).GetChild(0).gameObject.GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(16).gameObject.GetComponent<UIButton>().m_Handler = this;
		this.m_UIHint = base.transform.GetChild(4).GetChild(4).GetChild(5).gameObject.AddComponent<UIButtonHint>();
		this.m_UIHint.m_eHint = EUIButtonHint.CountDown;
		this.m_UIHint.DelayTime = 0.3f;
		this.m_UIHint = base.transform.GetChild(4).GetChild(3).GetChild(4).gameObject.AddComponent<UIButtonHint>();
		this.m_UIHint.m_eHint = EUIButtonHint.CountDown;
		this.m_UIHint.DelayTime = 0.3f;
		this.m_UIHint.Parm2 = 1;
		this.m_UIHint = base.transform.GetChild(4).GetChild(4).GetChild(8).gameObject.AddComponent<UIButtonHint>();
		this.m_UIHint.m_eHint = EUIButtonHint.CountDown;
		this.m_UIHint.DelayTime = 0.3f;
		this.m_UIHint.Parm2 = 2;
		for (int j = 0; j < 10; j++)
		{
			this.m_itemrow[j] = new Text[10];
			this.m_Str[j] = StringManager.Instance.SpawnString(500);
			this.m_Buffer[j] = StringManager.Instance.SpawnString(300);
			this.m_Cooling[j] = StringManager.Instance.SpawnString(300);
			this.m_Couting[j] = StringManager.Instance.SpawnString(300);
		}
		this.m_KingStr = StringManager.Instance.SpawnString(300);
		this.m_scroll = base.transform.GetChild(1).GetChild(9).GetComponent<ScrollPanel>();
		this.m_scroll.IntiScrollPanel(298f, 0f, 0f, this.ItemsHeight, 8, this);
		this.m_scroll.gameObject.SetActive(true);
		this.SkillRect = this.m_scroll.transform.GetChild(0).GetComponent<RectTransform>();
		UIButtonHint.scrollRect = this.m_scroll.GetComponent<CScrollRect>();
		this.RequestFatigue();
		this.Refresh(0);
		NewbieManager.CheckPetSkillFromUI();
	}

	// Token: 0x06001688 RID: 5768 RVA: 0x0026CFB8 File Offset: 0x0026B1B8
	public void RequestFatigue()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_FATIGUE;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06001689 RID: 5769 RVA: 0x0026CFEC File Offset: 0x0026B1EC
	public void RequestSkillUse(ushort pet, ushort skill, ushort zone = 0, byte point = 0)
	{
		PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey(skill);
		if (this.PM.UseSkill(skill, pet, true) && recordByKey.Type == 1 && recordByKey.Class >= 1 && (int)recordByKey.Class <= PetBuff.PetSkillList.Length && this.PM.CoolDownData != null && this.PM.BuffInfoData != null)
		{
			if (this.PM.CDFinder != null && this.PM.CDFinder.ContainsKey(skill))
			{
				this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12575u), 255, true);
			}
			else if (recordByKey.Diamond > 0 && this.DM.GetCurItemQuantity(recordByKey.Diamond, 0) == 0)
			{
				this.GM.MsgStr.ClearString();
				this.GM.MsgStr.StringToFormat(this.DM.mStringTable.GetStringByID(14654u));
				this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(1545u));
				this.GM.OpenMessageBox(this.GM.MsgStr.ToString(), this.DM.mStringTable.GetStringByID(12571u), this.DM.mStringTable.GetStringByID(3968u), this, (int)recordByKey.Diamond, (int)skill, true, false, false, false, false);
			}
			else
			{
				if (recordByKey.Subject == 1)
				{
					GameConstants.MapIDToPointCode(this.DM.RoleAttr.CapitalPoint, out zone, out point);
				}
				GUIManager.Instance.ShowUILock(EUILock.PetSkill);
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_USE;
				messagePacket.AddSeqId();
				messagePacket.Add(zone);
				messagePacket.Add(point);
				messagePacket.Add(pet);
				messagePacket.Add(skill);
				messagePacket.Send(false);
			}
		}
	}

	// Token: 0x0600168A RID: 5770 RVA: 0x0026D208 File Offset: 0x0026B408
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x0600168B RID: 5771 RVA: 0x0026D20C File Offset: 0x0026B40C
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
		img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
		img.material = GUIManager.Instance.GetFrameMaterial();
	}

	// Token: 0x0600168C RID: 5772 RVA: 0x0026D270 File Offset: 0x0026B470
	private void Refresh(int arg1 = 0)
	{
		this.ItemsHeight.Clear();
		this.ItemsHeight.Add(124f);
		PetBuff.PetSkills.Clear();
		PetBuff.PetSkills.Add(new PetBuff.PetSkill(0u, 0, 0, 0, 0));
		int i = 0;
		int num = 1;
		while (i < this.PM.BuffInfo.Count)
		{
			if (this.PM.NegBuff.ContainsKey(this.PM.BuffInfo[i].SkillID))
			{
				this.ItemsHeight.Add((float)((num <= 1) ? 135 : 100));
				PetBuff.PetSkills.Add(new PetBuff.PetSkill(0u, num++, 0, 0, (ushort)i));
			}
			i++;
		}
		base.SetSkill(false);
		for (int j = 0; j < PetBuff.PetSkillList.Length; j++)
		{
			int k = 0;
			int num2 = 0;
			while (k < PetBuff.PetSkillList[j].Count)
			{
				if (PetBuff.PetSkillList[j][k].Subject == 1)
				{
					this.ItemsHeight.Add((float)((num2 <= 0) ? 135 : 100));
					PetBuff.PetSkills.Add(new PetBuff.PetSkill(PetBuff.PetSkillList[j][k].Id, num2++, (byte)j, PetBuff.PetSkillList[j][k].Slot, PetBuff.PetSkillList[j][k].Pet));
				}
				k++;
			}
		}
		this.m_scroll.AddNewDataHeight(this.ItemsHeight, true, true);
		this.m_scroll.GoTo(UIPetBuff.Positioning, UIPetBuff.Scrolling);
	}

	// Token: 0x0600168D RID: 5773 RVA: 0x0026D440 File Offset: 0x0026B640
	protected void SetPanelItem()
	{
		if (this.m_panel != null)
		{
			for (int i = 0; i < this.m_panel.Length; i++)
			{
				if (this.m_panel[i].Init && this.m_panel[i].Item && this.m_panel[i].ID >= 0 && this.m_panel[i].ID < PetBuff.PetSkills.Count)
				{
					PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey((ushort)PetBuff.PetSkills[this.m_panel[i].ID].ID);
					if (recordByKey.Diamond > 0)
					{
						ushort curItemQuantity = this.DM.GetCurItemQuantity(recordByKey.Diamond, 0);
						this.m_panel[i].Item.transform.GetChild(4).GetChild(6).GetComponent<Text>().text = string.Format(this.DM.mStringTable.GetStringByID(12559u), curItemQuantity);
						this.m_panel[i].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(4).gameObject.SetActive(curItemQuantity == 0);
						this.m_panel[i].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(2).gameObject.SetActive(curItemQuantity > 0);
					}
				}
			}
		}
	}

	// Token: 0x0600168E RID: 5774 RVA: 0x0026D5F4 File Offset: 0x0026B7F4
	protected void SetPanelItem(int idx, bool force = false)
	{
		if (this.m_panel != null && this.m_panel[idx].Init && this.m_panel[idx].Item && this.PM.CoolDownData != null && this.PM.BuffInfoData != null && (this.m_panel[idx].Item.activeInHierarchy || force) && this.m_panel[idx].ID >= 0 && this.m_panel[idx].ID < PetBuff.PetSkills.Count)
		{
			this.m_Buffer[idx].ClearString();
			if (PetBuff.PetSkills[this.m_panel[idx].ID].ID > 0u)
			{
				uint num2;
				long num;
				GameConstants.GetTimeString(this.m_Buffer[idx], (uint)(num = PetBuff.CheckSkillBuff((ushort)PetBuff.PetSkills[this.m_panel[idx].ID].ID, out num2)), false, false, true, false, true);
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(2).GetComponent<Text>().text = this.m_Buffer[idx].ToString();
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(2).GetComponent<Text>().cachedTextGenerator.Invalidate();
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(2).GetComponent<Text>().SetAllDirty();
				if (num2 > 0u && num > 0L)
				{
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(0).GetChild(0).GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Math.Min((uint)((ulong)num2 - (ulong)num), num2) * 341f / num2, 19f);
				}
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(2).gameObject.SetActive(num == 0L);
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(3).gameObject.SetActive(num == 0L);
				byte index;
				if (num > 0L && !this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).gameObject.activeSelf && this.PM.PosBuff.TryGetValue((ushort)PetBuff.PetSkills[this.m_panel[idx].ID].ID, out index))
				{
					PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.PM.BuffInfo[(int)index].SkillID);
					this.PM.FormatSkillContent(this.PM.BuffInfo[(int)index].SkillID, this.PM.BuffInfo[(int)index].Level, this.m_Str[idx], (recordByKey.Status <= 0) ? 0 : 1);
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(4).GetComponent<Text>().text = this.m_Str[idx].ToString();
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(4).GetComponent<Text>().cachedTextGenerator.Invalidate();
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(4).GetComponent<Text>().SetAllDirty();
				}
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(5).gameObject.GetComponent<UIButtonHint>().Parm2 = ((num <= 0L) ? 0 : 1);
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).gameObject.SetActive(num > 0L);
				long num3 = PetBuff.CheckSkillCD((ushort)PetBuff.PetSkills[this.m_panel[idx].ID].ID);
				if (num3 == 0L)
				{
					PetSkillCoolTbl recordByKey2 = this.PM.PetSkillCoolTable.GetRecordByKey(this.m_panel[idx].CoolDown);
					PetData petData = PetManager.Instance.FindPetData(PetBuff.PetSkills[this.m_panel[idx].ID].Pet);
					if (petData != null && petData.SkillLv != null && (force || !this.m_panel[idx].Item.transform.GetChild(4).GetChild(8).GetChild(1).gameObject.activeSelf))
					{
						this.m_Couting[idx].ClearString();
						byte b = petData.SkillLv[(int)PetBuff.PetSkills[this.m_panel[idx].ID].Slot];
						if (b > 0 && (int)b <= recordByKey2.CoolBySkillLv.Length)
						{
							this.PM.FormatCoolTime(recordByKey2.CoolBySkillLv[(int)(b - 1)], this.m_Couting[idx], 0);
							this.m_panel[idx].Item.transform.GetChild(4).GetChild(10).GetComponent<Text>().text = this.m_Couting[idx].ToString();
							this.m_panel[idx].Item.transform.GetChild(4).GetChild(10).GetComponent<Text>().cachedTextGenerator.Invalidate();
							this.m_panel[idx].Item.transform.GetChild(4).GetChild(10).GetComponent<Text>().SetAllDirty();
						}
					}
				}
				else
				{
					this.m_Couting[idx].ClearString();
					GameConstants.GetTimeString(this.m_Couting[idx], (uint)num3, false, true, false, false, true);
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(9).GetComponent<Text>().text = this.m_Couting[idx].ToString();
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(9).GetComponent<Text>().cachedTextGenerator.Invalidate();
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(9).GetComponent<Text>().SetAllDirty();
				}
				if (this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).gameObject.activeSelf)
				{
					if (num3 > 0L || this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(4).gameObject.activeSelf)
					{
						this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(1).gameObject.SetActive(false);
						this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(3).gameObject.SetActive(true);
					}
					else
					{
						this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(3).gameObject.SetActive(false);
						this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(1).gameObject.SetActive(true);
					}
				}
				else if (num3 > 0L)
				{
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(0).gameObject.SetActive(false);
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(1).gameObject.SetActive(true);
				}
				else
				{
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(1).gameObject.SetActive(false);
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(0).gameObject.SetActive(true);
				}
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(8).gameObject.GetComponent<UIButtonHint>().Parm1 = ((num3 <= 0L) ? 0 : 1);
				if (this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(0).GetChild(0).childCount > 1)
				{
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>().color = ((num3 <= 0L) ? Color.white : Color.gray);
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = ((num3 <= 0L) ? Color.white : Color.gray);
				}
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetComponent<Image>().color = ((num3 <= 0L) ? Color.white : Color.gray);
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(0).GetComponent<Text>().color = this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(0).GetChild((num3 <= 0L) ? 0 : 1).GetComponent<Text>().color;
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(1).GetComponent<Text>().color = this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(1).GetChild((num3 <= 0L) ? 0 : 1).GetComponent<Text>().color;
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(1).GetComponent<Text>().color = this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(1).GetChild((num3 <= 0L) ? 0 : 1).GetComponent<Text>().color;
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(2).GetComponent<Text>().color = this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(2).GetChild((num3 <= 0L) ? 0 : 1).GetComponent<Text>().color;
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(3).GetComponent<Text>().color = this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(3).GetChild((num3 <= 0L) ? 0 : 1).GetComponent<Text>().color;
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(4).GetComponent<Text>().color = this.m_panel[idx].Item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(4).GetChild((num3 <= 0L) ? 0 : 1).GetComponent<Text>().color;
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(8).GetChild(1).gameObject.SetActive(num3 == 0L);
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(8).GetChild(0).gameObject.SetActive(num3 > 0L);
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(10).gameObject.SetActive(num3 == 0L);
				this.m_panel[idx].Item.transform.GetChild(4).GetChild(9).gameObject.SetActive(num3 > 0L);
			}
			else if (PetBuff.PetSkills[this.m_panel[idx].ID].Idx > 0)
			{
				long num;
				GameConstants.GetTimeString(this.m_Buffer[idx], (uint)(num = base.CheckSkillBuff((byte)PetBuff.PetSkills[this.m_panel[idx].ID].Pet)), false, false, true, false, true);
				this.m_panel[idx].Item.transform.GetChild(3).GetChild(3).GetChild(2).GetComponent<Text>().text = this.m_Buffer[idx].ToString();
				this.m_panel[idx].Item.transform.GetChild(3).GetChild(3).GetChild(2).GetComponent<Text>().cachedTextGenerator.Invalidate();
				this.m_panel[idx].Item.transform.GetChild(3).GetChild(3).GetChild(2).GetComponent<Text>().SetAllDirty();
				if ((int)PetBuff.PetSkills[this.m_panel[idx].ID].Pet < this.PM.BuffInfo.Count && this.PM.BuffInfo[(int)PetBuff.PetSkills[this.m_panel[idx].ID].Pet].RequireTime > 0u)
				{
					this.m_panel[idx].Item.transform.GetChild(3).GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Math.Min((uint)((ulong)this.PM.BuffInfo[(int)PetBuff.PetSkills[this.m_panel[idx].ID].Pet].RequireTime - (ulong)num), this.PM.BuffInfo[(int)PetBuff.PetSkills[this.m_panel[idx].ID].Pet].RequireTime) * 341f / this.PM.BuffInfo[(int)PetBuff.PetSkills[this.m_panel[idx].ID].Pet].RequireTime, 19f);
				}
			}
			else
			{
				if (this.PM.BuffImmune.BeginTime > 0L && this.PM.BuffImmune.RequireTime > 0u)
				{
					long num;
					GameConstants.GetTimeString(this.m_Buffer[idx], (uint)(num = PetBuff.CheckSkillBuff(0)), false, false, true, false, true);
					this.m_panel[idx].Item.transform.GetChild(2).GetChild(3).GetChild(3).GetComponent<Text>().text = this.m_Buffer[idx].ToString();
					this.m_panel[idx].Item.transform.GetChild(2).GetChild(3).GetChild(3).GetComponent<Text>().cachedTextGenerator.Invalidate();
					this.m_panel[idx].Item.transform.GetChild(2).GetChild(3).GetChild(3).GetComponent<Text>().SetAllDirty();
					this.m_panel[idx].Item.transform.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Math.Min((uint)((ulong)this.PM.BuffImmune.RequireTime - (ulong)num), this.PM.BuffImmune.RequireTime) * 341f / this.PM.BuffImmune.RequireTime, 19f);
				}
				else
				{
					this.m_panel[idx].Item.transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<Image>().rectTransform.sizeDelta = new Vector2((float)Math.Min((int)DataManager.Instance.RoleAttr.PetSkillFatigue, 480) / 480f * 341f, 19f);
					this.m_Buffer[idx].IntToFormat((long)DataManager.Instance.RoleAttr.PetSkillFatigue, 1, false);
					this.m_Buffer[idx].IntToFormat(480L, 1, false);
					this.m_Buffer[idx].AppendFormat((!GUIManager.Instance.IsArabic) ? "{0} / {1}" : "{1} / {0}");
					this.m_panel[idx].Item.transform.GetChild(2).GetChild(2).GetChild(2).GetComponent<Text>().text = this.m_Buffer[idx].ToString();
					this.m_panel[idx].Item.transform.GetChild(2).GetChild(2).GetChild(2).GetComponent<Text>().cachedTextGenerator.Invalidate();
					this.m_panel[idx].Item.transform.GetChild(2).GetChild(2).GetChild(2).GetComponent<Text>().SetAllDirty();
				}
				this.m_panel[idx].Item.transform.GetChild(2).GetChild(2).gameObject.SetActive(this.PM.BuffImmune.BeginTime <= 0L);
				this.m_panel[idx].Item.transform.GetChild(2).GetChild(3).gameObject.SetActive(this.PM.BuffImmune.BeginTime > 0L);
			}
		}
	}

	// Token: 0x0600168F RID: 5775 RVA: 0x0026EB18 File Offset: 0x0026CD18
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId > 0)
		{
			this.m_label[panelObjectIdx + 1] = item.transform.GetChild(2).GetChild(((dataIdx != 0 && dataIdx != 5 && dataIdx != 8) || this.type != 1) ? 1 : 0).GetComponent<Text>();
			this.m_label[panelObjectIdx + 1].text = this.DM.mStringTable.GetStringByID((uint)(((this.type <= 1) ? 12579 : 12588) + dataIdx));
			return;
		}
		if (dataIdx < 0 || dataIdx >= PetBuff.PetSkills.Count || panelObjectIdx >= this.m_panel.Length)
		{
			return;
		}
		if (!this.m_panel[panelObjectIdx].Init)
		{
			item.transform.GetChild(4).GetChild(8).gameObject.GetComponent<UIButtonHint>().m_Handler = this;
			item.transform.GetChild(4).GetChild(5).gameObject.GetComponent<UIButtonHint>().m_Handler = this;
			item.transform.GetChild(3).GetChild(4).gameObject.GetComponent<UIButtonHint>().m_Handler = this;
			item.transform.GetChild(4).GetChild(7).gameObject.GetComponent<UIButton>().m_Handler = this;
			item.transform.GetChild(2).gameObject.GetComponent<UIButton>().m_Handler = this;
			this.m_panel[panelObjectIdx].Text = new Text[25];
			this.m_panel[panelObjectIdx].Text[0] = item.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[1] = item.transform.GetChild(2).GetChild(2).GetChild(0).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[2] = item.transform.GetChild(2).GetChild(2).GetChild(2).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[3] = item.transform.GetChild(2).GetChild(3).GetChild(1).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[4] = item.transform.GetChild(2).GetChild(3).GetChild(2).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[5] = item.transform.GetChild(2).GetChild(3).GetChild(3).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[6] = item.transform.GetChild(3).GetChild(0).GetChild(0).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[7] = item.transform.GetChild(3).GetChild(2).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[8] = item.transform.GetChild(3).GetChild(3).GetChild(1).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[9] = item.transform.GetChild(3).GetChild(3).GetChild(2).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[10] = item.transform.GetChild(4).GetChild(0).GetChild(0).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[11] = item.transform.GetChild(4).GetChild(2).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[12] = item.transform.GetChild(4).GetChild(3).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[13] = item.transform.GetChild(4).GetChild(4).GetChild(1).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[14] = item.transform.GetChild(4).GetChild(4).GetChild(2).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[15] = item.transform.GetChild(4).GetChild(4).GetChild(4).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[16] = item.transform.GetChild(4).GetChild(6).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[17] = item.transform.GetChild(4).GetChild(7).GetChild(0).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[18] = item.transform.GetChild(4).GetChild(7).GetChild(1).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[19] = item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(1).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[20] = item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(2).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[21] = item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(3).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[22] = item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(4).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[23] = item.transform.GetChild(4).GetChild(9).gameObject.GetComponent<UIText>();
			this.m_panel[panelObjectIdx].Text[24] = item.transform.GetChild(4).GetChild(10).gameObject.GetComponent<UIText>();
			Text text = this.m_panel[panelObjectIdx].Text[12];
			int resizeTextMinSize = this.m_panel[panelObjectIdx].Text[7].resizeTextMinSize;
			this.m_panel[panelObjectIdx].Text[7].fontSize = resizeTextMinSize;
			text.fontSize = resizeTextMinSize;
			this.m_panel[panelObjectIdx].Item = item;
			this.m_panel[panelObjectIdx].Init = true;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		item.transform.GetChild(2).gameObject.SetActive(PetBuff.PetSkills[dataIdx].ID == 0u && PetBuff.PetSkills[dataIdx].Idx == 0);
		item.transform.GetChild(3).gameObject.SetActive(PetBuff.PetSkills[dataIdx].ID == 0u && PetBuff.PetSkills[dataIdx].Idx > 0);
		item.transform.GetChild(4).gameObject.SetActive(PetBuff.PetSkills[dataIdx].ID > 0u);
		this.m_panel[panelObjectIdx].ID = dataIdx;
		if (PetBuff.PetSkills[dataIdx].ID > 0u)
		{
			PetData petData = PetManager.Instance.FindPetData(PetBuff.PetSkills[dataIdx].Pet);
			PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey((ushort)PetBuff.PetSkills[dataIdx].ID);
			this.GM.ChangeHeroItemImg(item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(0).GetChild(0).transform, eHeroOrItem.Item, recordByKey.Diamond, 0, 0, 0);
			if (petData != null && petData.SkillLv != null)
			{
				this.m_Cooling[panelObjectIdx].ClearString();
				this.m_Cooling[panelObjectIdx].IntToFormat((long)petData.SkillLv[(int)PetBuff.PetSkills[dataIdx].Slot], 1, false);
				this.m_Cooling[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
				this.m_Cooling[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(268u));
				item.transform.GetChild(4).GetChild(2).GetComponent<Text>().text = this.m_Cooling[panelObjectIdx].ToString();
				item.transform.GetChild(4).GetChild(2).GetComponent<Text>().SetAllDirty();
				item.transform.GetChild(4).GetChild(2).GetComponent<Text>().cachedTextGenerator.Invalidate();
				this.PM.FormatSkillContent((ushort)PetBuff.PetSkills[dataIdx].ID, petData.SkillLv[(int)PetBuff.PetSkills[dataIdx].Slot], this.m_Str[panelObjectIdx], 0);
			}
			else
			{
				item.transform.GetChild(4).GetChild(2).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID((uint)recordByKey.Name);
			}
			if (PetBuff.PetSkills[dataIdx].Idx == 0 && PetBuff.PetSkills[dataIdx].Class > 0)
			{
				if (PetBuff.PetSkills[dataIdx].Class == 1)
				{
					item.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(12578u);
				}
				else if ((int)PetBuff.PetSkills[dataIdx].Class < PetBuff.PetSkillList.Length)
				{
					item.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID((uint)PetBuff.PetSkills[dataIdx].Class + 12552u);
				}
			}
			if (recordByKey.Diamond > 0)
			{
				ushort curItemQuantity = this.DM.GetCurItemQuantity(recordByKey.Diamond, 0);
				item.transform.GetChild(4).GetChild(6).GetComponent<Text>().text = string.Format(this.DM.mStringTable.GetStringByID(12559u), curItemQuantity);
				item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(4).gameObject.SetActive(curItemQuantity == 0);
				item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(2).gameObject.SetActive(curItemQuantity > 0);
			}
			item.transform.GetChild(4).localPosition = ((PetBuff.PetSkills[dataIdx].Idx <= 0) ? Vector3.zero : new Vector3(0f, 35f, 0f));
			item.transform.GetChild(4).GetChild(13).gameObject.SetActive(dataIdx + 1 < PetBuff.PetSkills.Count && PetBuff.PetSkills[dataIdx + 1].Idx > 0);
			item.transform.GetChild(4).GetChild(0).gameObject.SetActive(PetBuff.PetSkills[dataIdx].Idx == 0);
			item.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
			item.transform.GetChild(4).GetChild(3).GetComponent<Text>().text = this.m_Str[panelObjectIdx].ToString();
			item.transform.GetChild(4).GetChild(3).GetComponent<Text>().SetAllDirty();
			item.transform.GetChild(4).GetChild(3).GetComponent<Text>().cachedTextGenerator.Invalidate();
			item.transform.GetChild(4).GetChild(6).gameObject.SetActive(recordByKey.Diamond > 0);
			item.transform.GetChild(4).GetChild(7).GetChild(0).gameObject.SetActive(recordByKey.Diamond == 0);
			item.transform.GetChild(4).GetChild(7).GetChild(1).gameObject.SetActive(recordByKey.Diamond == 0);
			item.transform.GetChild(4).GetChild(7).GetChild(2).gameObject.SetActive(recordByKey.Diamond > 0);
			item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(1).gameObject.SetActive(false);
			item.transform.GetChild(4).GetChild(7).GetChild(2).GetChild(3).gameObject.SetActive(false);
			byte index;
			if (this.PM.PosBuff.TryGetValue((ushort)PetBuff.PetSkills[dataIdx].ID, out index))
			{
				item.transform.GetChild(4).GetChild(5).gameObject.GetComponent<UIButtonHint>().Parm2 = 1;
				this.PM.FormatSkillContent((ushort)PetBuff.PetSkills[dataIdx].ID, this.PM.BuffInfo[(int)index].Level, this.m_Str[panelObjectIdx], (recordByKey.Status <= 0) ? 0 : 1);
				item.transform.GetChild(4).GetChild(4).GetChild(4).GetComponent<Text>().text = this.m_Str[panelObjectIdx].ToString();
				item.transform.GetChild(4).GetChild(4).GetChild(4).GetComponent<Text>().cachedTextGenerator.Invalidate();
				item.transform.GetChild(4).GetChild(4).GetChild(4).GetComponent<Text>().SetAllDirty();
			}
			else
			{
				item.transform.GetChild(4).GetChild(5).gameObject.GetComponent<UIButtonHint>().Parm2 = 0;
			}
			item.transform.GetChild(4).GetChild(5).gameObject.GetComponent<UIButtonHint>().Parm1 = (ushort)dataIdx;
			item.transform.GetChild(4).GetChild(7).gameObject.GetComponent<UIButton>().m_BtnID2 = dataIdx + 1;
			this.m_CrownBack = item.transform.GetChild(4).GetChild(5).gameObject.GetComponent<Image>();
			cstring.IntToFormat((long)recordByKey.Icon, 5, false);
			cstring.AppendFormat("s{0}");
			this.m_panel[panelObjectIdx].CoolDown = recordByKey.CoolDown;
		}
		else if (PetBuff.PetSkills[dataIdx].Idx > 0 && (int)PetBuff.PetSkills[dataIdx].Pet < this.PM.BuffInfo.Count)
		{
			item.transform.GetChild(3).GetChild(0).gameObject.SetActive(PetBuff.PetSkills[dataIdx].Idx == 1);
			item.transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition = ((PetBuff.PetSkills[dataIdx].Idx <= 1) ? Vector2.zero : new Vector2(0f, 35f));
			PetSkillTbl recordByKey2 = PetManager.Instance.PetSkillTable.GetRecordByKey(this.PM.BuffInfo[(int)PetBuff.PetSkills[dataIdx].Pet].SkillID);
			this.PM.FormatSkillContent(this.PM.BuffInfo[(int)PetBuff.PetSkills[dataIdx].Pet].SkillID, this.PM.BuffInfo[(int)PetBuff.PetSkills[dataIdx].Pet].Level, this.m_Str[panelObjectIdx], (recordByKey2.Status <= 0) ? 0 : 1);
			item.transform.GetChild(3).GetChild(2).GetComponent<Text>().text = this.m_Str[panelObjectIdx].ToString();
			item.transform.GetChild(3).GetChild(2).GetComponent<Text>().SetAllDirty();
			item.transform.GetChild(3).GetChild(2).GetComponent<Text>().cachedTextGenerator.Invalidate();
			item.transform.GetChild(3).GetChild(3).GetChild(1).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(6097u);
			item.transform.GetChild(3).GetChild(4).gameObject.GetComponent<UIButtonHint>().Parm1 = (ushort)dataIdx;
			item.transform.GetChild(3).GetChild(2).GetComponent<Text>().supportRichText = true;
			this.m_CrownBack = item.transform.GetChild(3).GetChild(4).gameObject.GetComponent<Image>();
			cstring.IntToFormat((long)recordByKey2.Icon, 5, false);
			cstring.AppendFormat("s{0}");
		}
		this.SetPanelItem(panelObjectIdx, true);
		if (cstring.Length > 0)
		{
			this.m_Defeater = this.m_CrownBack.transform.GetChild(0).GetComponent<Image>();
			this.m_Defeater.sprite = this.GM.LoadFrameSprite("sk");
			this.m_Defeater.material = this.GM.GetFrameMaterial();
			this.m_CrownBack.sprite = this.GM.LoadSkillSprite(cstring);
			this.m_CrownBack.material = this.GM.GetSkillMaterial();
		}
	}

	// Token: 0x06001690 RID: 5776 RVA: 0x0026FE3C File Offset: 0x0026E03C
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond && this.m_panel != null)
		{
			for (int i = 0; i < this.m_panel.Length; i++)
			{
				this.SetPanelItem(i, false);
			}
		}
	}

	// Token: 0x06001691 RID: 5777 RVA: 0x0026FE7C File Offset: 0x0026E07C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK && this.door)
		{
			if (GUIManager.Instance.BuildingData.GetBuildNumByID(22) == 0)
			{
				this.door.CloseMenu(false);
				GUIManager.Instance.BuildingData.ManorGuild(22, false);
			}
			else
			{
				this.door.OpenMenu(EGUIWindow.UI_PetFusion, 1, arg1, false);
			}
		}
	}

	// Token: 0x06001692 RID: 5778 RVA: 0x0026FEEC File Offset: 0x0026E0EC
	public void onFinish()
	{
	}

	// Token: 0x06001693 RID: 5779 RVA: 0x0026FEF0 File Offset: 0x0026E0F0
	private static void SearchChange(string input)
	{
	}

	// Token: 0x06001694 RID: 5780 RVA: 0x0026FEF4 File Offset: 0x0026E0F4
	public void OnButtonUp(UIButtonHint sender)
	{
		if (this.m_WorldWarZ)
		{
			sender.ControlFadeOut.SetActive(false);
		}
		if (GUIManager.Instance.m_Hint != null)
		{
			GUIManager.Instance.m_Hint.Hide(true);
		}
	}

	// Token: 0x06001695 RID: 5781 RVA: 0x0026FF3C File Offset: 0x0026E13C
	public void OnButtonDown(UIButtonHint sender)
	{
		this.HintButt = sender.transform;
		if (sender.Parm1 >= 0 && (int)sender.Parm1 < PetBuff.PetSkills.Count && this.PM.CoolDownData != null && this.PM.BuffInfoData != null)
		{
			if (sender.Parm2 > 1)
			{
				this.m_KingStr.ClearString();
				this.m_KingStr.Append(this.DM.mStringTable.GetStringByID((sender.Parm1 <= 0) ? 12561u : 12560u));
				GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 250f, 16, this.m_KingStr, Vector2.zero);
			}
			else if (sender.Parm2 > 0)
			{
				byte index;
				if (PetBuff.PetSkills[(int)sender.Parm1].ID > 0u && (this.PM.PosBuff.TryGetValue((ushort)PetBuff.PetSkills[(int)sender.Parm1].ID, out index) || this.PM.NegBuff.TryGetValue((ushort)PetBuff.PetSkills[(int)sender.Parm1].ID, out index)))
				{
					GUIManager.Instance.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.State, PetBuff.PetSkills[(int)sender.Parm1].Pet, this.PM.BuffInfo[(int)index].SkillID, this.PM.BuffInfo[(int)index].Level, Vector2.zero, UIButtonHint.ePosition.Original);
				}
				else if ((int)PetBuff.PetSkills[(int)sender.Parm1].Pet < this.PM.BuffInfo.Count)
				{
					GUIManager.Instance.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.State, PetBuff.PetSkills[(int)sender.Parm1].Pet, this.PM.BuffInfo[(int)PetBuff.PetSkills[(int)sender.Parm1].Pet].SkillID, this.PM.BuffInfo[(int)PetBuff.PetSkills[(int)sender.Parm1].Pet].Level, Vector2.zero, UIButtonHint.ePosition.Original);
				}
			}
			else
			{
				PetData petData = PetManager.Instance.FindPetData(PetBuff.PetSkills[(int)sender.Parm1].Pet);
				PetTbl recordByKey = PetManager.Instance.PetTable.GetRecordByKey(PetBuff.PetSkills[(int)sender.Parm1].Pet);
				int num = 0;
				while (num < 4 && num < recordByKey.PetSkill.Length)
				{
					if ((uint)recordByKey.PetSkill[num] == PetBuff.PetSkills[(int)sender.Parm1].ID && petData != null)
					{
						GUIManager.Instance.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.CurentLv, PetBuff.PetSkills[(int)sender.Parm1].Pet, (ushort)PetBuff.PetSkills[(int)sender.Parm1].ID, petData.SkillLv[num], Vector2.zero, UIButtonHint.ePosition.Original);
						break;
					}
					num++;
				}
			}
		}
	}

	// Token: 0x06001696 RID: 5782 RVA: 0x002702BC File Offset: 0x0026E4BC
	public override void OnClose()
	{
		this.bEnd = true;
		if (this.type == 0)
		{
			PetBuff.Refreshed = true;
			UIPetBuff.Scrolling = this.SkillRect.anchoredPosition.y;
			UIPetBuff.Positioning = this.m_scroll.GetTopIdx();
			PetBuff.UpdateSkill(0);
			UnityEngine.Object.Destroy(this.Duke);
			for (int i = 0; i < 10; i++)
			{
				if (this.m_Str[i] != null)
				{
					StringManager.Instance.DeSpawnString(this.m_Str[i]);
				}
				if (this.m_Buffer[i] != null)
				{
					StringManager.Instance.DeSpawnString(this.m_Buffer[i]);
				}
				if (this.m_Cooling[i] != null)
				{
					StringManager.Instance.DeSpawnString(this.m_Cooling[i]);
				}
				if (this.m_Couting[i] != null)
				{
					StringManager.Instance.DeSpawnString(this.m_Couting[i]);
				}
			}
			StringManager.Instance.DeSpawnString(this.m_KingStr);
			Time.timeScale = 1f;
			this.Destroy();
		}
	}

	// Token: 0x06001697 RID: 5783 RVA: 0x002703D0 File Offset: 0x0026E5D0
	public override void UpdateUI(int arg1, int arg2)
	{
		if (!this.m_scroll || this.m_scroll.m_ScrollPanelID > 0)
		{
			return;
		}
		if (arg1 == 2)
		{
			this.SetPanelItem(0, false);
		}
		if (arg1 == 5)
		{
			this.SetPanelItem();
		}
		else if (arg1 == 6)
		{
			UIPetBuff.Scrolling = this.SkillRect.anchoredPosition.y;
			UIPetBuff.Positioning = this.m_scroll.GetTopIdx();
			this.Refresh(0);
		}
		if (arg1 == 10)
		{
			GUIManager.Instance.m_Arena_Hint.ShowHint(1, this.HintButt.GetComponent<RectTransform>());
		}
	}

	// Token: 0x06001698 RID: 5784 RVA: 0x0027047C File Offset: 0x0026E67C
	protected void UpdateItem(int idx, bool force = false)
	{
		if (this.m_panel != null && this.m_panel[idx].Init && this.m_panel[idx].Item && this.PM.CoolDownData != null && this.PM.BuffInfoData != null && (this.m_panel[idx].Item.activeInHierarchy || force) && this.m_panel[idx].ID >= 0 && this.m_panel[idx].ID < PetBuff.PetSkills.Count)
		{
			if (PetBuff.PetSkills[this.m_panel[idx].ID].ID > 0u)
			{
				if (this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).gameObject.activeSelf)
				{
					this.m_panel[idx].Item.transform.GetChild(4).GetChild(4).GetChild(0).GetComponent<Image>().color = this.m_Dukedom.color;
				}
			}
			else if (PetBuff.PetSkills[this.m_panel[idx].ID].Idx > 0)
			{
				this.m_panel[idx].Item.transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<Image>().color = this.m_Dukedom.color;
			}
			else if (this.PM.BuffImmune.BeginTime > 0L && this.PM.BuffImmune.RequireTime > 0u)
			{
				this.m_panel[idx].Item.transform.GetChild(2).GetChild(3).GetChild(0).GetComponent<Image>().color = this.m_Dukedom.color;
			}
		}
	}

	// Token: 0x06001699 RID: 5785 RVA: 0x002706B0 File Offset: 0x0026E8B0
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x0600169A RID: 5786 RVA: 0x002706B4 File Offset: 0x0026E8B4
	public void Destroy()
	{
		if (this.go != null)
		{
			this.go.transform.SetParent(this.Hero_Pos.parent, false);
			UnityEngine.Object.Destroy(this.go);
		}
		if (this.Hero_Model != null)
		{
			UnityEngine.Object.Destroy(this.Hero_Model);
		}
		this.Hero_Model = null;
		this.go = null;
	}

	// Token: 0x0600169B RID: 5787 RVA: 0x00270724 File Offset: 0x0026E924
	public void OnDisable()
	{
	}

	// Token: 0x0600169C RID: 5788 RVA: 0x00270728 File Offset: 0x0026E928
	private void OnEnable()
	{
	}

	// Token: 0x0600169D RID: 5789 RVA: 0x0027072C File Offset: 0x0026E92C
	protected void Update()
	{
		if (this.bExit)
		{
			if (this.door)
			{
				this.door.CloseMenu(false);
			}
			return;
		}
		if (this.bEnd || this.bReturn)
		{
			return;
		}
		if (this.m_panel != null)
		{
			for (int i = 0; i < this.m_panel.Length; i++)
			{
				this.UpdateItem(i, false);
			}
		}
	}

	// Token: 0x0600169E RID: 5790 RVA: 0x002707A4 File Offset: 0x0026E9A4
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
			break;
		case NetworkNews.Fallout:
			break;
		default:
			if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
			{
				if (networkNews != NetworkNews.Refresh_RecvAllianceInfo)
				{
				}
			}
			else if (!this.bEnd)
			{
				if (this.m_title && this.m_title.enabled)
				{
					this.m_title.enabled = !this.m_title.enabled;
					this.m_title.enabled = !this.m_title.enabled;
				}
				if (this.m_panel != null)
				{
					for (int i = 0; i < this.m_panel.Length; i++)
					{
						this.m_panel[i].Rebuilt();
					}
				}
				for (int j = 0; j < 28; j++)
				{
					if (this.m_label[j] != null && this.m_label[j].enabled)
					{
						this.m_label[j].enabled = false;
						this.m_label[j].enabled = true;
					}
				}
			}
			break;
		case NetworkNews.Refresh_Asset:
			break;
		case NetworkNews.Refresh_Item:
			this.UpdateUI(5, 0);
			break;
		case NetworkNews.Refresh_Alliance:
			break;
		}
	}

	// Token: 0x0600169F RID: 5791 RVA: 0x00270910 File Offset: 0x0026EB10
	public void OnButtonClick(UIButton sender)
	{
		if (this.door)
		{
			if (sender.m_BtnID2 > 0)
			{
				if (sender.m_BtnID2 <= PetBuff.PetSkills.Count)
				{
					this.RequestSkillUse(PetBuff.PetSkills[sender.m_BtnID2 - 1].Pet, (ushort)PetBuff.PetSkills[sender.m_BtnID2 - 1].ID, 0, 0);
				}
			}
			else if (sender.m_BtnID3 > 0)
			{
				this.door.OpenMenu(EGUIWindow.UI_PetShield, sender.m_BtnID3, 0, false);
			}
			else
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x060016A0 RID: 5792 RVA: 0x002709C8 File Offset: 0x0026EBC8
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x040043C2 RID: 17346
	private GameObject go;

	// Token: 0x040043C3 RID: 17347
	private GameObject Duke;

	// Token: 0x040043C4 RID: 17348
	private RectTransform Hero_PosRT;

	// Token: 0x040043C5 RID: 17349
	private Transform Tmp;

	// Token: 0x040043C6 RID: 17350
	private Transform Hero_Model;

	// Token: 0x040043C7 RID: 17351
	private Transform Hero_3D;

	// Token: 0x040043C8 RID: 17352
	private Transform Hero_Pos;

	// Token: 0x040043C9 RID: 17353
	private Transform HintButt;

	// Token: 0x040043CA RID: 17354
	private ScrollPanel m_scroll;

	// Token: 0x040043CB RID: 17355
	private PetBuff.SkillPanelItem[] m_panel = new PetBuff.SkillPanelItem[8];

	// Token: 0x040043CC RID: 17356
	private Animation tmpAN;

	// Token: 0x040043CD RID: 17357
	protected bool bRequest;

	// Token: 0x040043CE RID: 17358
	protected bool bReturn;

	// Token: 0x040043CF RID: 17359
	protected bool bExit;

	// Token: 0x040043D0 RID: 17360
	protected bool bEnd;

	// Token: 0x040043D1 RID: 17361
	protected Door door;

	// Token: 0x040043D2 RID: 17362
	protected Text[] m_label = new Text[28];

	// Token: 0x040043D3 RID: 17363
	protected Text m_fatigue;

	// Token: 0x040043D4 RID: 17364
	protected Text m_limit;

	// Token: 0x040043D5 RID: 17365
	protected Text m_title;

	// Token: 0x040043D6 RID: 17366
	protected Text m_error;

	// Token: 0x040043D7 RID: 17367
	protected Text m_filter;

	// Token: 0x040043D8 RID: 17368
	protected Text m_search;

	// Token: 0x040043D9 RID: 17369
	protected Text m_button;

	// Token: 0x040043DA RID: 17370
	protected Text m_content;

	// Token: 0x040043DB RID: 17371
	protected Text[] m_default = new Text[3];

	// Token: 0x040043DC RID: 17372
	protected Text[][] m_itemrow = new Text[10][];

	// Token: 0x040043DD RID: 17373
	protected Text m_descript;

	// Token: 0x040043DE RID: 17374
	protected Image m_Dukedom;

	// Token: 0x040043DF RID: 17375
	protected Image m_Backdoor;

	// Token: 0x040043E0 RID: 17376
	protected Image m_Defeater;

	// Token: 0x040043E1 RID: 17377
	protected Image m_MyEmperor;

	// Token: 0x040043E2 RID: 17378
	protected Image m_CrownBack;

	// Token: 0x040043E3 RID: 17379
	protected Image m_WorldWarZ;

	// Token: 0x040043E4 RID: 17380
	protected Image m_WorldPiss;

	// Token: 0x040043E5 RID: 17381
	protected UISpritesArray USArray;

	// Token: 0x040043E6 RID: 17382
	protected UIButtonHint m_UIHint;

	// Token: 0x040043E7 RID: 17383
	protected Transform Transformer;

	// Token: 0x040043E8 RID: 17384
	protected static int Positioning;

	// Token: 0x040043E9 RID: 17385
	protected static float Scrolling;

	// Token: 0x040043EA RID: 17386
	protected RectTransform SkillRect;

	// Token: 0x040043EB RID: 17387
	public GUIManager GM = GUIManager.Instance;

	// Token: 0x040043EC RID: 17388
	public PetManager PM = PetManager.Instance;

	// Token: 0x040043ED RID: 17389
	public DataManager DM = DataManager.Instance;

	// Token: 0x040043EE RID: 17390
	public NetworkManager NM = NetworkManager.Instance;

	// Token: 0x040043EF RID: 17391
	public Font Font = GUIManager.Instance.GetTTFFont();

	// Token: 0x040043F0 RID: 17392
	public StringBuilder Path = new StringBuilder();

	// Token: 0x040043F1 RID: 17393
	private List<float> ItemsHeight = new List<float>();

	// Token: 0x040043F2 RID: 17394
	private string[] mHeroAct = new string[7];

	// Token: 0x040043F3 RID: 17395
	private CString[] m_Couting = new CString[10];

	// Token: 0x040043F4 RID: 17396
	private CString[] m_Cooling = new CString[10];

	// Token: 0x040043F5 RID: 17397
	private CString[] m_Buffer = new CString[10];

	// Token: 0x040043F6 RID: 17398
	private CString[] m_Str = new CString[10];

	// Token: 0x040043F7 RID: 17399
	private CString m_KingStr;

	// Token: 0x040043F8 RID: 17400
	private Effect effect;

	// Token: 0x040043F9 RID: 17401
	private ushort head;

	// Token: 0x040043FA RID: 17402
	private uint time;

	// Token: 0x040043FB RID: 17403
	private int type;

	// Token: 0x02000461 RID: 1121
	protected enum SkillKind : byte
	{

	}
}
