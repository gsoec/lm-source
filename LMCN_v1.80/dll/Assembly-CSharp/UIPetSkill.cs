using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000462 RID: 1122
public class UIPetSkill : PetBuff, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x060016A2 RID: 5794 RVA: 0x00270A74 File Offset: 0x0026EC74
	public override void OnOpen(int arg1, int arg2)
	{
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			((RectTransform)base.transform).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)base.transform).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		DataManager.msgBuffer[0] = 96;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		UIPetSkill.nowKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)arg1);
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		base.transform.GetChild(0).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(0).GetComponent<CustomImage>().hander = this;
		base.transform.GetChild(4).GetChild(9).GetChild(2).GetChild(1).GetComponent<Text>().font = this.Font;
		base.transform.GetChild(1).GetChild(7).GetChild(1).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(7).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(7).GetChild(0).GetComponent<CustomImage>().hander = this;
		base.transform.GetChild(4).GetChild(8).GetChild(0).GetComponent<Text>().font = this.Font;
		base.transform.GetChild(4).GetChild(9).GetChild(0).GetComponent<Text>().font = this.Font;
		base.transform.GetChild(4).GetChild(9).GetChild(1).GetComponent<Text>().font = this.Font;
		base.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(0).GetChild(0).GetComponent<Text>().font = this.Font;
		base.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(1).GetChild(0).GetComponent<Text>().font = this.Font;
		this.m_UIHint = base.transform.GetChild(1).GetChild(26).GetChild(6).gameObject.AddComponent<UIButtonHint>();
		this.m_UIHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_UIHint.m_Handler = this;
		base.transform.GetChild(1).GetChild(26).GetChild(5).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(26).GetChild(5).GetComponent<UIButton>().m_BtnID1 = 1;
		this.m_label[1] = base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(0).GetComponent<Text>();
		this.m_label[1].font = this.Font;
		this.m_label[1].text = this.DM.mStringTable.GetStringByID(94u);
		this.m_label[2] = base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(1).GetComponent<Text>();
		this.m_label[2].font = this.Font;
		this.m_label[2].text = this.DM.mStringTable.GetStringByID(94u);
		this.m_label[3] = base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(2).GetComponent<Text>();
		this.m_label[3].text = ((!GUIManager.Instance.IsArabic) ? "x1" : "1x");
		this.m_label[3].font = this.Font;
		this.m_label[4] = base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(3).GetComponent<Text>();
		this.m_label[4].font = this.Font;
		this.m_label[4].text = this.DM.mStringTable.GetStringByID(94u);
		this.m_label[5] = base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(4).GetComponent<Text>();
		this.m_label[5].text = ((!GUIManager.Instance.IsArabic) ? "x1" : "1x");
		this.m_label[5].font = this.Font;
		this.m_Active = base.transform.GetChild(4).GetChild(9).GetChild(2).GetComponent<UIButton>();
		this.m_Active.m_Handler = this;
		this.m_label[0] = base.transform.GetChild(1).GetChild(8).GetChild(1).GetComponent<Text>();
		this.m_label[0].font = this.Font;
		this.m_label[10] = base.transform.GetChild(1).GetChild(26).GetChild(0).GetComponent<Text>();
		this.m_label[10].font = this.Font;
		this.m_label[11] = base.transform.GetChild(1).GetChild(26).GetChild(1).GetComponent<Text>();
		this.m_label[11].font = this.Font;
		this.m_label[12] = base.transform.GetChild(1).GetChild(26).GetChild(4).GetComponent<Text>();
		this.m_label[12].font = this.Font;
		this.m_Dukedom = base.transform.GetChild(1).GetChild(8).GetChild(0).gameObject.GetComponent<Image>();
		this.GM.InitianHeroItemImg(base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(0).GetChild(0).transform, eHeroOrItem.Item, 0, 0, 0, 0, false, false, true, false);
		for (int i = 0; i < this.m_Str.Length; i++)
		{
			this.m_Str[i] = StringManager.Instance.SpawnString(500);
			this.m_Buffer[i] = StringManager.Instance.SpawnString(300);
		}
		this.SkillInfo = StringManager.Instance.SpawnString(1024);
		if (GUIManager.Instance.IsArabic)
		{
			base.transform.GetChild(1).GetChild(7).GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.m_scroll = base.transform.GetChild(1).GetChild(9).GetComponent<ScrollPanel_Horizontal>();
		this.m_scroll.IntiScrollPanel(298f, 6f, 0f, this.ItemsHeight, 10, this);
		this.m_scroll.gameObject.SetActive(true);
		this.SkillRect = this.m_scroll.transform.GetChild(0).GetComponent<RectTransform>();
		UIPetSkill.nowMapPoint = arg1;
		this.nowCasting = arg2;
		this.Refresh(0);
	}

	// Token: 0x060016A3 RID: 5795 RVA: 0x002711F0 File Offset: 0x0026F3F0
	private void RequestFatigue()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_FATIGUE;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x060016A4 RID: 5796 RVA: 0x00271224 File Offset: 0x0026F424
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

	// Token: 0x060016A5 RID: 5797 RVA: 0x00271288 File Offset: 0x0026F488
	private void RefreshSkill()
	{
		PetBuff.PetSkills.Clear();
		for (int i = 0; i < PetBuff.PetSkillList.Length; i++)
		{
			if (PetBuff.PetSkillList[i] == null)
			{
				PetBuff.PetSkillList[i] = new List<PetBuff.PetSkillData>();
			}
			else
			{
				PetBuff.PetSkillList[i].Clear();
			}
		}
		for (int j = 0; j < (int)PetManager.Instance.PetDataCount; j++)
		{
			PetData petData = PetManager.Instance.GetPetData((int)((byte)j));
			if (petData != null)
			{
				PetTbl recordByKey = PetManager.Instance.PetTable.GetRecordByKey(petData.ID);
				byte b = 0;
				while (recordByKey.PetSkill != null && (int)b < recordByKey.PetSkill.Length)
				{
					if (recordByKey.PetSkill[(int)b] > 0 && petData.SkillLv != null && (int)b < petData.SkillLv.Length && petData.SkillLv[(int)b] > 0)
					{
						PetSkillTbl recordByKey2 = PetManager.Instance.PetSkillTable.GetRecordByKey(recordByKey.PetSkill[(int)b]);
						if (recordByKey2.Type > 0 && recordByKey2.Subject == 1 && recordByKey2.Class >= 1 && (int)recordByKey2.Class <= PetBuff.PetSkillList.Length)
						{
							PetBuff.PetSkillList[(int)(recordByKey2.Class - 1)].Add(new PetBuff.PetSkillData((uint)recordByKey.PetSkill[(int)b], b, recordByKey2.Subject, petData.ID));
						}
					}
					b += 1;
				}
			}
		}
	}

	// Token: 0x060016A6 RID: 5798 RVA: 0x00271410 File Offset: 0x0026F610
	private void Refresh(int arg1 = 0)
	{
		if (this.door && !this.m_Dukedom.sprite && UIPetSkill.nowMapPoint < DataManager.MapDataController.LayoutMapInfo.Length)
		{
			MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[UIPetSkill.nowMapPoint];
			if ((int)mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
			{
				bool flag = DataManager.MapDataController.IsEnemy(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomID);
				this.door.TileMapController.getTileMapSprite(ref this.m_Dukedom, DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)UIPetSkill.nowMapPoint), (int)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].level, (DataManager.MapDataController.OtherKingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_KVK || !flag) ? DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].cityOutward : CITY_OUTWARD.CO_EMEMY);
				this.m_Dukedom.material = (UnityEngine.Object.Instantiate(this.door.TileMapController.TileSprites.m_Image.material) as Material);
				this.m_Dukedom.material.renderQueue = 3000;
				if (flag)
				{
					if (DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag != null && DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag.Length > 0)
					{
						GameConstants.FormatRoleName(this.m_Str[0], DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName, DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag, null, 0, DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomID, null, null, null, null);
					}
					else
					{
						GameConstants.FormatRoleName(this.m_Str[0], DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName, null, null, 0, DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomID, null, null, null, null);
					}
				}
				else if (DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag != null && DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag.Length > 0)
				{
					GameConstants.FormatRoleName(this.m_Str[0], DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName, DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag, null, 0, 0, null, null, null, null);
				}
				else
				{
					StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName);
					this.m_Str[0].AppendFormat("{0}");
				}
				this.m_label[0].text = this.m_Str[0].ToString();
				this.m_label[0].SetAllDirty();
				this.m_label[0].cachedTextGenerator.Invalidate();
				this.m_Dukedom.SetNativeSize();
				this.m_Dukedom.enabled = true;
			}
		}
		this.m_Active.m_BtnID2 = 1;
		this.ItemsHeight.Clear();
		PetBuff.PetSkills.Clear();
		base.SetSkill(true);
		int i = 0;
		int btnID = 0;
		while (i < PetBuff.PetSkillList.Length)
		{
			for (int j = 0; j < PetBuff.PetSkillList[i].Count; j++)
			{
				if ((int)PetBuff.PetSkillList[i][j].Subject == this.nowCasting)
				{
					PetBuff.PetSkills.Add(new PetBuff.PetSkill(PetBuff.PetSkillList[i][j].Id, btnID++, (byte)i, PetBuff.PetSkillList[i][j].Slot, PetBuff.PetSkillList[i][j].Pet));
					if (PetBuff.PetSkillList[i][j].Id == (uint)UIPetSkill.nowSkillId)
					{
						this.m_Active.m_BtnID2 = btnID;
					}
					this.ItemsHeight.Add(90f);
				}
			}
			i++;
		}
		this.m_scroll.AddNewDataHeight(this.ItemsHeight, true, true);
		if (this.m_Active.m_BtnID2 > 1)
		{
			this.m_scroll.GoTo(UIPetSkill.Positioning, UIPetSkill.Scrolling);
		}
		this.OnButtonClick(this.m_Active);
	}

	// Token: 0x060016A7 RID: 5799 RVA: 0x002718F8 File Offset: 0x0026FAF8
	protected void SetStage()
	{
	}

	// Token: 0x060016A8 RID: 5800 RVA: 0x002718FC File Offset: 0x0026FAFC
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (dataIdx < 0 || dataIdx >= PetBuff.PetSkills.Count || panelObjectIdx >= this.m_panel.Length)
		{
			return;
		}
		if (!this.m_panel[panelObjectIdx].Init)
		{
			this.m_panel[panelObjectIdx].Init = true;
			this.m_panel[panelObjectIdx].Item = item;
			item.transform.GetChild(9).GetChild(2).gameObject.GetComponent<UIButton>().m_Handler = this;
			if (UIPetSkill.nowSkillId == 0)
			{
			}
		}
		this.m_panel[panelObjectIdx].ID = dataIdx;
		item.transform.GetChild(8).gameObject.SetActive(false);
		item.transform.GetChild(9).gameObject.SetActive(true);
		item.transform.GetChild(9).GetChild(2).gameObject.GetComponent<UIButton>().m_BtnID2 = dataIdx + 1;
		item.transform.GetChild(9).GetChild(2).GetChild(2).gameObject.SetActive(this.currentBtnID > 0 && this.currentBtnID <= PetBuff.PetSkills.Count && this.currentBtnID == dataIdx);
		this.SetPanelItem(panelObjectIdx, true);
		this.m_CrownBack = item.transform.GetChild(9).GetChild(2).gameObject.GetComponent<Image>();
		PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey((ushort)PetBuff.PetSkills[dataIdx].ID);
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)recordByKey.Icon, 5, false);
		cstring.AppendFormat("s{0}");
		this.m_Defeater = this.m_CrownBack.transform.GetChild(0).GetComponent<Image>();
		this.m_Defeater.sprite = this.GM.LoadFrameSprite("sk");
		this.m_Defeater.material = this.GM.GetFrameMaterial();
		this.m_CrownBack.sprite = this.GM.LoadSkillSprite(cstring);
		this.m_CrownBack.material = this.GM.GetSkillMaterial();
	}

	// Token: 0x060016A9 RID: 5801 RVA: 0x00271B3C File Offset: 0x0026FD3C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK && this.door)
		{
			if (arg2 > 0)
			{
				this.UpdateUI(0, 0);
				if (GUIManager.Instance.BuildingData.GetBuildNumByID(22) == 0)
				{
					GUIManager.Instance.BuildingData.ManorGuild(22, false);
				}
				else
				{
					this.door.OpenMenu(EGUIWindow.UI_PetFusion, 1, arg1, false);
				}
			}
			else
			{
				this.UpdateUI(11, 0);
			}
		}
	}

	// Token: 0x060016AA RID: 5802 RVA: 0x00271BC0 File Offset: 0x0026FDC0
	private void Check()
	{
	}

	// Token: 0x060016AB RID: 5803 RVA: 0x00271BC4 File Offset: 0x0026FDC4
	public void onUse(ushort PetId, ushort SkillId)
	{
		PetTbl recordByKey = PetManager.Instance.PetTable.GetRecordByKey(PetId);
		DataManager.MapDataController.UseMapWeapon(recordByKey.HeroID, SkillId);
	}

	// Token: 0x060016AC RID: 5804 RVA: 0x00271BF8 File Offset: 0x0026FDF8
	public void onSelect(ushort DamageId)
	{
		ushort zoneID;
		byte pointID;
		GameConstants.MapIDToPointCode(UIPetSkill.nowMapPoint, out zoneID, out pointID);
		DataManager.MapDataController.ShowDamageRange(zoneID, pointID, DamageId);
	}

	// Token: 0x060016AD RID: 5805 RVA: 0x00271C24 File Offset: 0x0026FE24
	public static void onFinish()
	{
		if (UIPetSkill.nowPetId > 0 && UIPetSkill.nowSkillId > 0)
		{
			ushort data;
			byte data2;
			GameConstants.MapIDToPointCode(UIPetSkill.nowMapPoint, out data, out data2);
			GUIManager.Instance.ShowUILock(EUILock.PetSkill);
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_USE;
			messagePacket.AddSeqId();
			messagePacket.Add(data);
			messagePacket.Add(data2);
			messagePacket.Add(UIPetSkill.nowPetId);
			messagePacket.Add(UIPetSkill.nowSkillId);
			messagePacket.Send(false);
			UIPetSkill.nowMapPoint = (int)(UIPetSkill.nowPetId = 0);
		}
	}

	// Token: 0x060016AE RID: 5806 RVA: 0x00271CB8 File Offset: 0x0026FEB8
	private static void SearchChange(string input)
	{
	}

	// Token: 0x060016AF RID: 5807 RVA: 0x00271CBC File Offset: 0x0026FEBC
	public static void RecvPetSkill(MessagePacket MP)
	{
	}

	// Token: 0x060016B0 RID: 5808 RVA: 0x00271CC0 File Offset: 0x0026FEC0
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

	// Token: 0x060016B1 RID: 5809 RVA: 0x00271D08 File Offset: 0x0026FF08
	public void OnButtonDown(UIButtonHint sender)
	{
		this.SkillInfo.ClearString();
		this.SkillInfo.Append(this.DM.mStringTable.GetStringByID((sender.Parm1 <= 0) ? 12561u : 12560u));
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 250f, 16, this.SkillInfo, Vector2.zero);
	}

	// Token: 0x060016B2 RID: 5810 RVA: 0x00271D7C File Offset: 0x0026FF7C
	public static void ResetID()
	{
	}

	// Token: 0x060016B3 RID: 5811 RVA: 0x00271D80 File Offset: 0x0026FF80
	public override void OnClose()
	{
		this.bEnd = true;
		DataManager.MapDataController.HideDamageRange();
		DataManager.msgBuffer[0] = 97;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		UIPetSkill.Scrolling = this.SkillRect.anchoredPosition.x;
		UIPetSkill.Positioning = this.m_scroll.GetTopIdx();
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
		}
		if (this.SkillInfo != null)
		{
			StringManager.Instance.DeSpawnString(this.SkillInfo);
		}
		this.Destroy();
	}

	// Token: 0x060016B4 RID: 5812 RVA: 0x00271E5C File Offset: 0x0027005C
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			this.UpdateUI(10, 0);
			if (this.m_panel != null)
			{
				for (int i = 0; i < this.m_panel.Length; i++)
				{
					this.SetPanelItem(i, false);
				}
			}
		}
	}

	// Token: 0x060016B5 RID: 5813 RVA: 0x00271EA4 File Offset: 0x002700A4
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 5)
		{
			if (this.currentBtnID > 0 && this.currentBtnID <= PetBuff.PetSkills.Count)
			{
				PetData petData = PetManager.Instance.FindPetData(PetBuff.PetSkills[this.currentBtnID - 1].Pet);
				PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey((ushort)PetBuff.PetSkills[this.currentBtnID - 1].ID);
				if (this.m_panel != null)
				{
					for (int i = 0; i < this.m_panel.Length; i++)
					{
						if (this.m_panel[i].Init && this.m_panel[i].Item && this.m_panel[i].ID >= 0 && this.m_panel[i].ID < PetBuff.PetSkills.Count)
						{
							this.m_panel[i].Item.transform.GetChild(9).GetChild(2).GetChild(2).gameObject.SetActive(PetBuff.PetSkills[this.currentBtnID - 1].ID == PetBuff.PetSkills[this.m_panel[i].ID].ID);
						}
					}
				}
				this.GM.ChangeHeroItemImg(base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(0).GetChild(0).transform, eHeroOrItem.Item, recordByKey.Diamond, 0, 0, 0);
				if (petData != null && petData.SkillLv != null)
				{
					this.m_Str[1].ClearString();
					this.m_Str[1].IntToFormat((long)petData.SkillLv[(int)PetBuff.PetSkills[this.currentBtnID - 1].Slot], 1, false);
					this.m_Str[1].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
					this.m_Str[1].AppendFormat(this.DM.mStringTable.GetStringByID(268u));
					base.transform.GetChild(1).GetChild(26).GetChild(0).GetComponent<Text>().text = this.m_Str[1].ToString();
					this.PM.FormatSkillContent(UIPetSkill.nowSkillId, petData.SkillLv[(int)PetBuff.PetSkills[this.currentBtnID - 1].Slot], this.m_Str[2], 0);
				}
				else
				{
					base.transform.GetChild(1).GetChild(26).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID((uint)recordByKey.Name);
				}
				base.transform.GetChild(1).GetChild(26).GetChild(0).GetComponent<Text>().SetAllDirty();
				base.transform.GetChild(1).GetChild(26).GetChild(0).GetComponent<Text>().cachedTextGenerator.Invalidate();
				base.transform.GetChild(1).GetChild(26).GetChild(1).GetComponent<Text>().text = this.m_Str[2].ToString();
				base.transform.GetChild(1).GetChild(26).GetChild(1).GetComponent<Text>().SetAllDirty();
				base.transform.GetChild(1).GetChild(26).GetChild(1).GetComponent<Text>().cachedTextGenerator.Invalidate();
				ushort curItemQuantity = this.DM.GetCurItemQuantity(recordByKey.Diamond, 0);
				base.transform.GetChild(1).GetChild(26).GetChild(4).GetComponent<Text>().text = string.Format(this.DM.mStringTable.GetStringByID(12559u), curItemQuantity);
				base.transform.GetChild(1).GetChild(26).GetChild(4).gameObject.SetActive(recordByKey.Diamond > 0);
				base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(0).gameObject.SetActive(recordByKey.Diamond == 0);
				base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).gameObject.SetActive(recordByKey.Diamond > 0);
				base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(2).gameObject.SetActive(curItemQuantity > 0);
				base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(4).gameObject.SetActive(curItemQuantity == 0);
				this.UpdateUI(10, 1);
			}
		}
		else if (arg1 == 6)
		{
			UIPetSkill.Scrolling = this.SkillRect.anchoredPosition.x;
			UIPetSkill.Positioning = this.m_scroll.GetTopIdx();
			this.Refresh(0);
		}
		else if (arg1 == 10)
		{
			long num = PetBuff.CheckSkillCD(UIPetSkill.nowSkillId);
			if (this.currentBtnID > 0 && this.currentBtnID <= PetBuff.PetSkills.Count && num == 0L)
			{
				if (arg2 > 0 || !base.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(1).gameObject.activeSelf)
				{
					PetSkillTbl recordByKey2 = PetManager.Instance.PetSkillTable.GetRecordByKey(UIPetSkill.nowSkillId);
					PetSkillCoolTbl recordByKey3 = this.PM.PetSkillCoolTable.GetRecordByKey(recordByKey2.CoolDown);
					PetData petData2 = PetManager.Instance.FindPetData(UIPetSkill.nowPetId);
					if (petData2 != null && petData2.SkillLv != null)
					{
						byte b = petData2.SkillLv[(int)PetBuff.PetSkills[this.currentBtnID - 1].Slot];
						if (b > 0 && (int)b <= recordByKey3.CoolBySkillLv.Length)
						{
							this.m_Str[3].ClearString();
							this.PM.FormatCoolTime(recordByKey3.CoolBySkillLv[(int)(b - 1)], this.m_Str[3], 0);
							base.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(1).GetChild(0).GetComponent<Text>().text = this.m_Str[3].ToString();
							base.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(1).GetChild(0).GetComponent<Text>().cachedTextGenerator.Invalidate();
							base.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(1).GetChild(0).GetComponent<Text>().SetAllDirty();
						}
					}
				}
			}
			else
			{
				this.m_Str[3].ClearString();
				GameConstants.GetTimeString(this.m_Str[3], (uint)num, false, true, false, false, true);
				base.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(0).GetChild(0).GetComponent<Text>().text = this.m_Str[3].ToString();
				base.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(0).GetChild(0).GetComponent<Text>().cachedTextGenerator.Invalidate();
				base.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(0).GetChild(0).GetComponent<Text>().SetAllDirty();
			}
			if (num > 0L || base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(4).gameObject.activeSelf)
			{
				base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(1).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(3).gameObject.SetActive(true);
			}
			else
			{
				base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(3).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(1).gameObject.SetActive(true);
			}
			if (base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(0).GetChild(0).childCount > 1)
			{
				base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = ((num <= 0L) ? Color.white : Color.gray);
				base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(0).GetChild(0).GetChild(1).GetComponent<Image>().color = ((num <= 0L) ? Color.white : Color.gray);
			}
			base.transform.GetChild(1).GetChild(26).GetChild(5).GetComponent<Image>().color = ((num <= 0L) ? Color.white : Color.gray);
			base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(1).GetComponent<Text>().color = base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(1).GetChild((num <= 0L) ? 0 : 1).GetComponent<Text>().color;
			base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(2).GetComponent<Text>().color = base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(2).GetChild((num <= 0L) ? 0 : 1).GetComponent<Text>().color;
			base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(3).GetComponent<Text>().color = base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(3).GetChild((num <= 0L) ? 0 : 1).GetComponent<Text>().color;
			base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(4).GetComponent<Text>().color = base.transform.GetChild(1).GetChild(26).GetChild(5).GetChild(1).GetChild(4).GetChild((num <= 0L) ? 0 : 1).GetComponent<Text>().color;
			base.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(1).gameObject.SetActive(num == 0L);
			base.transform.GetChild(1).GetChild(26).GetChild(6).GetChild(0).gameObject.SetActive(num > 0L);
			if (this.m_UIHint)
			{
				this.m_UIHint.Parm1 = ((num <= 0L) ? 0 : 1);
			}
		}
		else if (arg1 == 11)
		{
			if (UIPetSkill.nowSkillId > 0)
			{
				PetSkillTbl recordByKey4 = PetManager.Instance.PetSkillTable.GetRecordByKey(UIPetSkill.nowSkillId);
				if (recordByKey4.Type == 1 && recordByKey4.Class >= 1 && (int)recordByKey4.Class <= PetBuff.PetSkillList.Length && this.PM.CoolDownData != null && this.PM.BuffInfoData != null)
				{
					if (this.PM.CDFinder != null && this.PM.CDFinder.ContainsKey(UIPetSkill.nowSkillId))
					{
						this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12575u), 255, true);
					}
					else if (this.PM.m_PetMarchEventData.PetID > 0 && (ulong)this.PM.m_PetMarchEventData.MarchEventTime.RequireTime + (ulong)this.PM.m_PetMarchEventData.MarchEventTime.BeginTime >= (ulong)this.DM.ServerTime)
					{
						this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12576u), 255, true);
					}
					else if (recordByKey4.Diamond > 0 && this.DM.GetCurItemQuantity(recordByKey4.Diamond, 0) == 0)
					{
						this.GM.MsgStr.ClearString();
						this.GM.MsgStr.StringToFormat(this.DM.mStringTable.GetStringByID(14654u));
						this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(1545u));
						this.GM.OpenMessageBox(this.GM.MsgStr.ToString(), this.DM.mStringTable.GetStringByID(12571u), this.DM.mStringTable.GetStringByID(3968u), this, (int)recordByKey4.Diamond, (int)UIPetSkill.nowSkillId, true, false, false, false, false);
					}
					else if (this.PM.BuffImmune.BeginTime > 0L && arg2 > 0)
					{
						this.GM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4840u), this.DM.mStringTable.GetStringByID(12573u), 0, 0, null, null);
					}
					else
					{
						this.onUse(UIPetSkill.nowPetId, UIPetSkill.nowSkillId);
						this.UpdateUI(0, 0);
					}
				}
			}
		}
		else if (arg1 != 12 || arg2 == UIPetSkill.nowMapPoint)
		{
			GUIManager.Instance.CloseMenu(this.m_eWindow);
			GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		}
	}

	// Token: 0x060016B6 RID: 5814 RVA: 0x00272DE8 File Offset: 0x00270FE8
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x060016B7 RID: 5815 RVA: 0x00272DEC File Offset: 0x00270FEC
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

	// Token: 0x060016B8 RID: 5816 RVA: 0x00272E5C File Offset: 0x0027105C
	public void OnDisable()
	{
	}

	// Token: 0x060016B9 RID: 5817 RVA: 0x00272E60 File Offset: 0x00271060
	private void OnEnable()
	{
	}

	// Token: 0x060016BA RID: 5818 RVA: 0x00272E64 File Offset: 0x00271064
	protected void Update()
	{
		if (this.bExit)
		{
			if (this.door)
			{
				this.door.CloseMenu(false);
				GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			}
			return;
		}
		if (this.bEnd || this.bReturn)
		{
			return;
		}
	}

	// Token: 0x060016BB RID: 5819 RVA: 0x00272EBC File Offset: 0x002710BC
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Refresh_Item)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				for (int i = 0; i < this.m_label.Length; i++)
				{
					if (this.m_label[i] != null && this.m_label[i].enabled)
					{
						this.m_label[i].enabled = false;
						this.m_label[i].enabled = true;
					}
				}
			}
		}
		else
		{
			this.UpdateUI(5, 0);
		}
	}

	// Token: 0x060016BC RID: 5820 RVA: 0x00272F54 File Offset: 0x00271154
	protected void SetPanelItem(int idx, bool force = false)
	{
		if (this.m_panel != null && this.m_panel[idx].Init && this.m_panel[idx].Item && this.PM.CoolDownData != null && this.PM.BuffInfoData != null && (this.m_panel[idx].Item.activeInHierarchy || force) && this.m_panel[idx].ID >= 0 && this.m_panel[idx].ID < PetBuff.PetSkills.Count)
		{
			this.m_Buffer[idx].ClearString();
			long num = PetBuff.CheckSkillCD((ushort)PetBuff.PetSkills[this.m_panel[idx].ID].ID);
			GameConstants.GetTimeStringShort(this.m_Buffer[idx], (uint)num);
			this.m_panel[idx].Item.transform.GetChild(9).GetChild(2).GetComponent<Image>().color = ((num <= 0L) ? Color.white : Color.gray);
			this.m_panel[idx].Item.transform.GetChild(9).GetChild(2).GetChild(1).GetComponent<Text>().text = ((num <= 0L) ? string.Empty : this.m_Buffer[idx].ToString());
			this.m_panel[idx].Item.transform.GetChild(9).GetChild(2).GetChild(1).GetComponent<Text>().cachedTextGenerator.Invalidate();
			this.m_panel[idx].Item.transform.GetChild(9).GetChild(2).GetChild(1).GetComponent<Text>().SetAllDirty();
		}
	}

	// Token: 0x060016BD RID: 5821 RVA: 0x0027315C File Offset: 0x0027135C
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 > 0)
		{
			this.UpdateUI(11, 1);
			return;
		}
		if (sender.m_BtnID2 > 0 && sender.m_BtnID2 <= PetBuff.PetSkills.Count)
		{
			this.currentBtnID = sender.m_BtnID2;
			UIPetSkill.nowPetId = PetBuff.PetSkills[sender.m_BtnID2 - 1].Pet;
			UIPetSkill.nowSkillId = (ushort)PetBuff.PetSkills[sender.m_BtnID2 - 1].ID;
			PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey((ushort)PetBuff.PetSkills[sender.m_BtnID2 - 1].ID);
			this.onSelect(PetManager.Instance.MapDamageEffTable.GetRecordByKey(recordByKey.DamageRange).RangeTbID);
			this.m_CrownBack = base.transform.GetChild(1).GetChild(26).GetChild(3).gameObject.GetComponent<Image>();
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat((long)recordByKey.Icon, 5, false);
			cstring.AppendFormat("s{0}");
			this.m_Defeater = this.m_CrownBack.transform.GetChild(0).GetComponent<Image>();
			this.m_Defeater.sprite = this.GM.LoadFrameSprite("sk");
			this.m_Defeater.material = this.GM.GetFrameMaterial();
			this.m_CrownBack.sprite = this.GM.LoadSkillSprite(cstring);
			this.m_CrownBack.material = this.GM.GetSkillMaterial();
			this.UpdateUI(5, 0);
			return;
		}
		if (sender.m_BtnID3 > 0)
		{
			this.SkillInfo.ClearString();
			this.SkillInfo.Append(this.DM.mStringTable.GetStringByID(12585u));
			this.SkillInfo.Append("\n");
			this.SkillInfo.Append(this.DM.mStringTable.GetStringByID(12586u));
			this.SkillInfo.Append("\n");
			this.SkillInfo.Append(this.DM.mStringTable.GetStringByID(12591u));
			this.SkillInfo.Append("\n");
			this.SkillInfo.Append(this.DM.mStringTable.GetStringByID(12583u));
			this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(12562u), this.SkillInfo.ToString(), null, null, 0, 0, true, true);
			return;
		}
		this.UpdateUI(0, 0);
	}

	// Token: 0x060016BE RID: 5822 RVA: 0x00273410 File Offset: 0x00271610
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (sender.m_BtnID1 != 1)
		{
			if (sender.m_BtnID1 == 2)
			{
			}
		}
	}

	// Token: 0x060016BF RID: 5823 RVA: 0x00273430 File Offset: 0x00271630
	public void RequestApplyList()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_FATIGUE;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x060016C0 RID: 5824 RVA: 0x00273464 File Offset: 0x00271664
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x040043FD RID: 17405
	private GameObject go;

	// Token: 0x040043FE RID: 17406
	private GameObject Duke;

	// Token: 0x040043FF RID: 17407
	private RectTransform Hero_PosRT;

	// Token: 0x04004400 RID: 17408
	private Transform Tmp;

	// Token: 0x04004401 RID: 17409
	private Transform Hero_Model;

	// Token: 0x04004402 RID: 17410
	private Transform Hero_Pos;

	// Token: 0x04004403 RID: 17411
	private Transform HintButt;

	// Token: 0x04004404 RID: 17412
	private ScrollPanel_Horizontal m_scroll;

	// Token: 0x04004405 RID: 17413
	private PetBuff.SkillPanelItem[] m_panel = new PetBuff.SkillPanelItem[10];

	// Token: 0x04004406 RID: 17414
	private Animation tmpAN;

	// Token: 0x04004407 RID: 17415
	private double PauseTime;

	// Token: 0x04004408 RID: 17416
	private bool bDisabled;

	// Token: 0x04004409 RID: 17417
	protected bool bRequest;

	// Token: 0x0400440A RID: 17418
	protected bool bReturn;

	// Token: 0x0400440B RID: 17419
	protected bool bExit;

	// Token: 0x0400440C RID: 17420
	protected bool bEnd;

	// Token: 0x0400440D RID: 17421
	protected Door door;

	// Token: 0x0400440E RID: 17422
	protected Text[] m_label = new Text[28];

	// Token: 0x0400440F RID: 17423
	protected Text m_limit;

	// Token: 0x04004410 RID: 17424
	protected Text m_title;

	// Token: 0x04004411 RID: 17425
	protected Text m_error;

	// Token: 0x04004412 RID: 17426
	protected Text m_filter;

	// Token: 0x04004413 RID: 17427
	protected Text m_search;

	// Token: 0x04004414 RID: 17428
	protected Text m_button;

	// Token: 0x04004415 RID: 17429
	protected Text m_content;

	// Token: 0x04004416 RID: 17430
	protected Text[] m_default = new Text[3];

	// Token: 0x04004417 RID: 17431
	protected Text m_descript;

	// Token: 0x04004418 RID: 17432
	protected Image m_Dukedom;

	// Token: 0x04004419 RID: 17433
	protected Image m_Defeater;

	// Token: 0x0400441A RID: 17434
	protected Image m_MyEmperor;

	// Token: 0x0400441B RID: 17435
	protected Image m_CrownBack;

	// Token: 0x0400441C RID: 17436
	protected Image m_WorldWarZ;

	// Token: 0x0400441D RID: 17437
	protected Image m_WorldPiss;

	// Token: 0x0400441E RID: 17438
	protected UIButton m_Active;

	// Token: 0x0400441F RID: 17439
	protected UISpritesArray USArray;

	// Token: 0x04004420 RID: 17440
	protected UIButtonHint m_UIHint;

	// Token: 0x04004421 RID: 17441
	protected Transform Transformer;

	// Token: 0x04004422 RID: 17442
	protected static int Positioning;

	// Token: 0x04004423 RID: 17443
	protected static float Scrolling;

	// Token: 0x04004424 RID: 17444
	protected RectTransform SkillRect;

	// Token: 0x04004425 RID: 17445
	public GUIManager GM = GUIManager.Instance;

	// Token: 0x04004426 RID: 17446
	public PetManager PM = PetManager.Instance;

	// Token: 0x04004427 RID: 17447
	public DataManager DM = DataManager.Instance;

	// Token: 0x04004428 RID: 17448
	public NetworkManager NM = NetworkManager.Instance;

	// Token: 0x04004429 RID: 17449
	public Font Font = GUIManager.Instance.GetTTFFont();

	// Token: 0x0400442A RID: 17450
	public StringBuilder Path = new StringBuilder();

	// Token: 0x0400442B RID: 17451
	private List<float> ItemsHeight = new List<float>();

	// Token: 0x0400442C RID: 17452
	private CString[] m_Str = new CString[10];

	// Token: 0x0400442D RID: 17453
	private CString[] m_Buffer = new CString[10];

	// Token: 0x0400442E RID: 17454
	public static POINT_KIND nowKind;

	// Token: 0x0400442F RID: 17455
	public static int nowMapPoint;

	// Token: 0x04004430 RID: 17456
	private static ushort nowSkillId;

	// Token: 0x04004431 RID: 17457
	private static ushort nowPetId;

	// Token: 0x04004432 RID: 17458
	private CString SkillInfo;

	// Token: 0x04004433 RID: 17459
	private int currentBtnID;

	// Token: 0x04004434 RID: 17460
	private int nowCasting;

	// Token: 0x04004435 RID: 17461
	private Effect effect;

	// Token: 0x04004436 RID: 17462
	private ushort head;

	// Token: 0x04004437 RID: 17463
	private uint time;

	// Token: 0x02000463 RID: 1123
	protected enum SkillType : byte
	{

	}
}
