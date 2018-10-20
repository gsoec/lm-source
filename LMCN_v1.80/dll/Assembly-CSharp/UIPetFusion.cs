using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x0200046A RID: 1130
public class UIPetFusion : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUICalculatorHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler, IUIUnitRSliderHandler
{
	// Token: 0x060016DA RID: 5850 RVA: 0x002740EC File Offset: 0x002722EC
	public void OnVauleChang(UnitResourcesSlider sender)
	{
		this.Cstr.ClearString();
		StringManager.IntToStr(this.Cstr, sender.Value, 1, true);
		sender.m_inputText.text = this.Cstr.ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
		this.SetDRformURS((double)sender.Value);
	}

	// Token: 0x060016DB RID: 5851 RVA: 0x00274158 File Offset: 0x00272358
	public void OnTextChang(UnitResourcesSlider sender)
	{
		this.Cstr.ClearString();
		StringManager.IntToStr(this.Cstr, sender.Value, 1, true);
		this.SetDRformURS((double)sender.Value);
	}

	// Token: 0x060016DC RID: 5852 RVA: 0x00274194 File Offset: 0x00272394
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.PM = PetManager.Instance;
		this.GameT = base.gameObject.transform;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.spArray = this.GameT.GetComponent<UISpritesArray>();
		this.PM.SortPetData();
		Material material = this.door.LoadMaterial();
		this.AssetName = "UIPetFusion";
		this.GUIM.AddSpriteAsset(this.AssetName);
		Material mmaterial = this.GUIM.LoadMaterial(this.AssetName, "UI_co_contract_tower_m");
		this.Cstr = StringManager.Instance.SpawnString(30);
		this.Cstr_Gemstone = StringManager.Instance.SpawnString(30);
		this.Cstr_Time = StringManager.Instance.SpawnString(30);
		this.Cstr_RD = StringManager.Instance.SpawnString(200);
		this.Cstr_FusionNeedQty = StringManager.Instance.SpawnString(30);
		this.Cstr_SkillNeedQty = StringManager.Instance.SpawnString(30);
		this.Cstr_SkillItemQty = StringManager.Instance.SpawnString(30);
		this.Cstr_Info = StringManager.Instance.SpawnString(1024);
		this.Cstr_UnitRS = StringManager.Instance.SpawnString(30);
		this.Cstr_Name = StringManager.Instance.SpawnString(200);
		for (int i = 0; i < 3; i++)
		{
			this.Cstr_SkillItemNeedQty[i] = StringManager.Instance.SpawnString(30);
		}
		for (int j = 0; j < 8; j++)
		{
			this.Cstr_SkillItem[j] = StringManager.Instance.SpawnString(30);
			this.Cstr_SkillItemName[j] = StringManager.Instance.SpawnString(30);
		}
		this.mType = (byte)arg1;
		this.mFusionlist.Clear();
		for (int k = 0; k < this.DM.FusionDataTable.TableCount; k++)
		{
			this.tmpFD = this.DM.FusionDataTable.GetRecordByKey((ushort)(k + 1));
			if (this.mType == 0 && this.tmpFD.Fusion_Kind == 0)
			{
				this.mFusionlist.Add(this.tmpFD.ID);
			}
			else if (this.mType > 0 && this.tmpFD.Fusion_Kind > 0)
			{
				this.mSkilllist.Add(this.tmpFD.ID);
			}
		}
		if (this.mType == 0)
		{
			if (this.PM.mPetFusionItemID != -1)
			{
				for (int l = 0; l < this.mFusionlist.Count; l++)
				{
					if (this.PM.mPetFusionItemID == (int)this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[l]).Fusion_ItemID)
					{
						this.tmpItemCraftIndex = (ushort)l;
						break;
					}
				}
			}
		}
		else if (this.mType == 1)
		{
			this.FusionlistItemData = new CHashTable<ushort, ushort>(this.mSkilllist.Count, true);
			for (int m = 0; m < this.mSkilllist.Count; m++)
			{
				this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mSkilllist[m]);
				this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
				this.FusionlistItemData.Add(this.tmpEquip.SyntheticParts[0].SyntheticItem, this.tmpFD.ID);
			}
			for (int n = 0; n < this.PM.sortPetData.Count; n++)
			{
				this.tmpPetD = this.PM.PetTable.GetRecordByKey(this.PM.GetPetData((int)this.PM.sortPetData[n]).ID);
				ushort num = 0;
				for (int num2 = 0; num2 < 4; num2++)
				{
					if (this.tmpPetD.PetSkill[num2] > 0)
					{
						num = this.PM.PetSkillTable.GetRecordByKey(this.tmpPetD.PetSkill[num2]).Diamond;
					}
					if (num > 0)
					{
						this.mFusionlist.Add(this.FusionlistItemData.Find(this.tmpPetD.ID));
						break;
					}
				}
			}
			if (arg2 != 0)
			{
				this.PM.mPetSkillItemID = arg2;
			}
			if (this.PM.mPetSkillItemID != -1)
			{
				for (int num3 = 0; num3 < this.mFusionlist.Count; num3++)
				{
					if (this.PM.mPetSkillItemID == (int)this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[num3]).Fusion_ItemID)
					{
						this.tmpItemCraftIndex = (ushort)num3;
						break;
					}
				}
			}
		}
		this.Tmp = this.GameT.GetChild(0);
		this.Tmp1 = this.Tmp.GetChild(0);
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_Title = this.Tmp2.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(14651u);
		this.Tmp1 = this.Tmp.GetChild(1);
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.btn_ItemInfo = this.Tmp2.GetComponent<UIButton>();
		this.btn_ItemInfo.m_Handler = this;
		this.btn_ItemInfo.m_BtnID1 = 8;
		this.btn_ItemInfo.SetButtonEffectType(e_EffectType.e_Scale);
		this.btn_ItemInfo.transition = Selectable.Transition.None;
		this.btn_Scale = this.Tmp2.GetComponent<uButtonScale>();
		this.Tmp2 = this.Tmp1.GetChild(0).GetChild(0);
		this.Hbtn_Fusion[0] = this.Tmp2.GetComponent<UIHIBtn>();
		this.GUIM.InitianHeroItemImg(this.Hbtn_Fusion[0].transform, eHeroOrItem.Item, 1, 0, 0, 0, false, false, false, false);
		this.Tmp2 = this.Tmp1.GetChild(0).GetChild(1);
		this.Img_Fusion_Info[0] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(0).GetChild(1).GetChild(0);
		this.Img_Fusion_Info[1] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(1);
		this.btn_Add[0] = this.Tmp2.GetComponent<UIButton>();
		this.btn_Add[0].m_Handler = this;
		this.btn_Add[0].m_BtnID1 = 9;
		this.btn_Add[0].SetButtonEffectType(e_EffectType.e_Scale);
		this.btn_Add[0].transition = Selectable.Transition.None;
		this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0);
		this.Img_Fusion_R[0] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0).GetChild(0);
		this.Img_Fusion_Add[0] = this.Tmp2.GetComponent<Image>();
		this.Img_Fusion_Add[0].sprite = this.door.LoadSprite("UI_con_icon_05");
		this.Img_Fusion_Add[0].material = this.door.LoadMaterial();
		this.Img_Fusion_Add[0].SetNativeSize();
		this.Img_Fusion_Add[0].gameObject.SetActive(false);
		this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0).GetChild(1);
		this.text_FusionNeedQty = this.Tmp2.GetComponent<UIText>();
		this.text_FusionNeedQty.font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(2);
		this.mFusionItemRT = this.Tmp2.GetComponent<RectTransform>();
		this.btn_Add[1] = this.Tmp2.GetComponent<UIButton>();
		this.btn_Add[1].m_Handler = this;
		this.btn_Add[1].m_BtnID1 = 9;
		this.btn_Add[1].SetButtonEffectType(e_EffectType.e_Scale);
		this.btn_Add[1].transition = Selectable.Transition.None;
		this.Tmp2 = this.Tmp1.GetChild(2).GetChild(0);
		this.Img_Fusion_R[1] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(2).GetChild(0).GetChild(0);
		this.Img_Fusion_Add[1] = this.Tmp2.GetComponent<Image>();
		this.Img_Fusion_Add[1].sprite = this.door.LoadSprite("UI_con_icon_05");
		this.Img_Fusion_Add[1].material = this.door.LoadMaterial();
		this.Img_Fusion_Add[1].SetNativeSize();
		this.Img_Fusion_Add[1].gameObject.SetActive(false);
		this.Tmp2 = this.Tmp1.GetChild(2).GetChild(0).GetChild(1);
		this.text_SkillNeedQty = this.Tmp2.GetComponent<UIText>();
		this.text_SkillNeedQty.font = this.TTFont;
		for (int num4 = 0; num4 < 3; num4++)
		{
			this.Tmp2 = this.Tmp1.GetChild(3 + num4);
			this.mHIbtnItemRT[num4] = this.Tmp2.GetComponent<RectTransform>();
			this.btn_Skill_ItemStore[num4] = this.Tmp2.GetComponent<UIButton>();
			this.btn_Skill_ItemStore[num4].m_Handler = this;
			this.btn_Skill_ItemStore[num4].m_BtnID1 = 12;
			this.btn_Skill_ItemStore[num4].m_BtnID2 = num4;
			this.btn_Skill_ItemStore[num4].SetButtonEffectType(e_EffectType.e_Scale);
			this.btn_Skill_ItemStore[num4].transition = Selectable.Transition.None;
			this.Hbtn_Need[num4] = this.Tmp2.GetChild(0).GetComponent<UIHIBtn>();
			this.Hbtn_Need[num4].m_BtnID2 = num4;
			this.Hbtn_Need[num4].m_Handler = this;
			this.GUIM.InitianHeroItemImg(this.Hbtn_Need[num4].transform, eHeroOrItem.Item, 1, 0, 0, 0, false, true, false, false);
			this.Lbtn_Need[num4] = this.Tmp2.GetChild(1).GetComponent<UILEBtn>();
			this.GUIM.InitLordEquipImg(this.Lbtn_Need[num4].transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
			this.Lbtn_Need[num4].gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
			this.Img_Skill_ItemStore[num4] = this.Tmp2.GetChild(2).GetComponent<Image>();
			this.text_NeedQty[num4] = this.Tmp2.GetChild(3).GetComponent<UIText>();
			this.text_NeedQty[num4].font = this.TTFont;
		}
		this.Tmp2 = this.Tmp1.GetChild(6);
		this.text_FusionName = this.Tmp2.GetComponent<UIText>();
		this.text_FusionName.font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(7);
		this.text_SkillName = this.Tmp2.GetComponent<UIText>();
		this.text_SkillName.font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(8);
		this.text_SkillItemQty = this.Tmp2.GetComponent<UIText>();
		this.text_SkillItemQty.font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(9);
		this.text_Type = this.Tmp2.GetComponent<UIText>();
		this.text_Type.font = this.TTFont;
		this.text_Type.text = this.DM.mStringTable.GetStringByID((uint)((ushort)(14653 + (int)this.mType)));
		this.Tmp2 = this.Tmp1.GetChild(10);
		this.Hbtn_Fusion[1] = this.Tmp2.GetComponent<UIHIBtn>();
		this.GUIM.InitianHeroItemImg(this.Hbtn_Fusion[1].transform, eHeroOrItem.Item, 1, 0, 0, 0, true, true, true, false);
		this.Tmp1 = this.Tmp.GetChild(2).GetChild(1);
		this.btn_I = this.Tmp1.GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_I.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_I.m_Handler = this;
		this.btn_I.m_BtnID1 = 10;
		this.btn_I.m_EffectType = e_EffectType.e_Scale;
		this.btn_I.transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(2).GetChild(3).GetChild(0);
		this.Img_PetSkill[0] = this.Tmp1.GetComponent<Image>();
		this.Img_PetSkill[0].material = this.GUIM.GetSkillMaterial();
		this.Tmp1 = this.Tmp.GetChild(2).GetChild(3).GetChild(1);
		this.Img_PetSkill[1] = this.Tmp1.GetComponent<Image>();
		this.Img_PetSkill[1].sprite = this.GUIM.LoadFrameSprite("sk");
		this.Img_PetSkill[1].material = this.GUIM.GetFrameMaterial();
		this.Tmp1 = this.Tmp.GetChild(2).GetChild(4);
		this.btn_Skill = this.Tmp1.GetComponent<UIButton>();
		this.btn_Skill.m_BtnID1 = 11;
		this.btn_Skill.m_Handler = this;
		UIButtonHint uibuttonHint = this.btn_Skill.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		if (this.mType == 0)
		{
			this.Tmp.GetChild(2).GetChild(2).gameObject.SetActive(false);
			this.Tmp.GetChild(2).GetChild(3).gameObject.SetActive(false);
			this.btn_Skill.gameObject.SetActive(false);
		}
		this.Tmp1 = this.Tmp.GetChild(3);
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_Kind = this.Tmp2.GetComponent<UIText>();
		this.text_Kind.font = this.TTFont;
		this.text_Kind.text = this.DM.mStringTable.GetStringByID(14656u);
		this.Tmp1 = this.Tmp.GetChild(4);
		this.m_ScrollPanel = this.Tmp1.GetChild(0).GetComponent<ScrollPanel>();
		this.m_ScrollPanel.m_ScrollPanelID = 1;
		this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0);
		UIHIBtn component = this.Tmp2.GetComponent<UIHIBtn>();
		this.GUIM.InitianHeroItemImg(component.transform, eHeroOrItem.Item, 1, 0, 0, 0, false, false, false, false);
		this.Tmp2 = this.Tmp1.GetChild(1).GetChild(6);
		UIButton component2 = this.Tmp2.GetComponent<UIButton>();
		component2.m_BtnID1 = 7;
		this.Tmp2 = this.Tmp1.GetChild(1).GetChild(1);
		UIText component3 = this.Tmp2.GetComponent<UIText>();
		component3.font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(1).GetChild(2);
		component3 = this.Tmp2.GetComponent<UIText>();
		component3.font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(1).GetChild(3);
		component3 = this.Tmp2.GetComponent<UIText>();
		component3.font = this.TTFont;
		this.tmplist.Clear();
		for (int num5 = 0; num5 < this.mFusionlist.Count; num5++)
		{
			this.tmplist.Add(80f);
		}
		this.m_ScrollPanel.IntiScrollPanel(433f, 0f, 0f, this.tmplist, 8, this);
		this.mContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
		CScrollRect component4 = this.m_ScrollPanel.GetComponent<CScrollRect>();
		this.BarrackMax = 0u;
		uint num6 = 0u;
		uint effectBaseVal;
		if (this.mType == 0)
		{
			this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETLOEETRY_TRAINING_CAPACITY);
			effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETLOEETRY_MAKE_SPEED);
		}
		else
		{
			this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_PETSKILL_SKILLCASTITEMMAKE);
			effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETSKILL_MAKE_SKILLSTONE_SPEED);
		}
		this.BarrackMax = this.BarrackMax * (10000u + num6) / 10000u;
		this.bRDOutput = this.CheckFusion(this.tmpItemCraftIndex);
		uint num7 = 0u;
		Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
		if (this.mType == 0 && recordByKey.Color >= 1 && recordByKey.Color <= 4)
		{
			num7 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM)(166 + recordByKey.Color - 1));
		}
		if (num7 >= 9900u)
		{
			num7 = 9900u;
		}
		this.tmpEGA_Cost = 1f - num7 / 10000f;
		float num8 = 0f;
		float num9 = 10000u + effectBaseVal - num8;
		if (num9 <= 100f)
		{
			num9 = 100f;
		}
		this.tmpEGA = 10000f / num9;
		this.UnitMax = this.CheckMax(this.BarrackMax);
		this.Tmp = this.GameT.GetChild(1);
		this.DResourcesT = this.Tmp.GetChild(1);
		this.m_DResources = this.DResourcesT.GetComponent<DemandResources>();
		this.GUIM.InitDemandResources(this.DResourcesT, 555f, 111f, true);
		this.RD_T = this.Tmp.GetChild(2);
		this.Tmp2 = this.RD_T.GetChild(0);
		this.m_UnitRS = this.Tmp2.GetComponent<UnitResourcesSlider>();
		this.GUIM.InitUnitResourcesSlider(this.Tmp2, eUnitSlider.Barrack, 0u, this.BarrackMax, 0.7f);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.BtnIncrease, this.spArray.m_Sprites[4], mmaterial);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.BtnLessen, this.spArray.m_Sprites[5], mmaterial);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.Input, this.spArray.m_Sprites[8], mmaterial);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_sliderBG1, this.spArray.m_Sprites[6], mmaterial);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_sliderBG2, this.spArray.m_Sprites[7], mmaterial);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_Img, this.spArray.m_Sprites[9], mmaterial);
		if (this.mType == 0)
		{
			this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_micon, this.spArray.m_Sprites[11], mmaterial);
			this.GUIM.SetUnitResourcesSliderSize(this.Tmp2, eUnitSliderSize.m_micon, -95f, 33f, 40f, 40f, 0f, 0f);
		}
		else
		{
			this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_micon, this.spArray.m_Sprites[10], mmaterial);
		}
		this.m_UnitRS.BtnInputText.m_Handler = this;
		this.m_UnitRS.BtnInputText.m_BtnID1 = 6;
		this.m_UnitRS.m_Handler = this;
		this.m_UnitRS.m_ID = 1;
		this.Tmp2 = this.RD_T.GetChild(1);
		this.Img_FusionCompleted[0] = this.Tmp2.GetComponent<Image>();
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.Img_FusionCompleted[1] = this.Tmp3.GetComponent<Image>();
		this.Tmp3 = this.Tmp2.GetChild(1);
		this.Img_FusionCompleted[2] = this.Tmp3.GetComponent<Image>();
		this.Img_FusionCompleted[2].sprite = this.door.LoadSprite("UI_main_money_02");
		this.Img_FusionCompleted[2].material = material;
		this.Img_FusionCompleted[2].SetNativeSize();
		this.Tmp3 = this.Tmp2.GetChild(2);
		this.text_Gemstone = this.Tmp3.GetComponent<UIText>();
		this.text_Gemstone.font = this.TTFont;
		this.Tmp2 = this.RD_T.GetChild(2);
		this.Img_Fusion[0] = this.Tmp2.GetComponent<Image>();
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.Img_Fusion[1] = this.Tmp3.GetComponent<Image>();
		this.Tmp3 = this.Tmp2.GetChild(1);
		this.text_Time = this.Tmp3.GetComponent<UIText>();
		this.text_Time.font = this.TTFont;
		this.Tmp2 = this.RD_T.GetChild(3);
		this.btn_FusionCompleted = this.Tmp2.GetComponent<UIButton>();
		this.btn_FusionCompleted.m_Handler = this;
		this.btn_FusionCompleted.m_BtnID1 = 4;
		this.btn_FusionCompleted.SetButtonEffectType(e_EffectType.e_Scale);
		this.btn_FusionCompleted.transition = Selectable.Transition.None;
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.text_FusionCompleted = this.Tmp3.GetComponent<UIText>();
		this.text_FusionCompleted.font = this.TTFont;
		this.text_FusionCompleted.text = this.DM.mStringTable.GetStringByID(14658u);
		this.btn_FusionCompleted.m_Text = this.text_FusionCompleted;
		this.Tmp2 = this.RD_T.GetChild(4);
		this.btn_Fusion = this.Tmp2.GetComponent<UIButton>();
		this.btn_Fusion.m_Handler = this;
		this.btn_Fusion.m_BtnID1 = 3;
		this.btn_Fusion.SetButtonEffectType(e_EffectType.e_Scale);
		this.btn_Fusion.transition = Selectable.Transition.None;
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.text_Fusion = this.Tmp3.GetComponent<UIText>();
		this.text_Fusion.font = this.TTFont;
		this.text_Fusion.text = this.DM.mStringTable.GetStringByID(14657u);
		this.btn_Fusion.m_Text = this.text_Fusion;
		this.Tmp1 = this.Tmp.GetChild(3);
		this.NotRD_T = this.Tmp1.GetComponent<Transform>();
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.Img_RDLock = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(1);
		this.btn_RD = this.Tmp2.GetComponent<UIButton>();
		this.btn_RD.m_Handler = this;
		this.btn_RD.m_BtnID1 = 5;
		this.btn_RD.SetButtonEffectType(e_EffectType.e_Scale);
		this.btn_RD.transition = Selectable.Transition.None;
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.text_RDbtn = this.Tmp3.GetComponent<UIText>();
		this.text_RDbtn.font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(2);
		this.text_RD = this.Tmp2.GetComponent<UIText>();
		this.text_RD.font = this.TTFont;
		this.Img_LockBG = this.Tmp.GetChild(0).GetComponent<Image>();
		this.Img_Lock = this.Tmp.GetChild(4).GetComponent<Image>();
		this.btn_Lock = this.Tmp.GetChild(5).GetComponent<UIButton>();
		this.btn_Lock.m_Handler = this;
		this.btn_Lock.m_BtnID1 = 1;
		this.btn_Lock.SetButtonEffectType(e_EffectType.e_Scale);
		this.btn_Lock.transition = Selectable.Transition.None;
		this.LockPanel = this.Tmp.GetChild(6);
		UIButton component5 = this.LockPanel.GetChild(0).GetComponent<UIButton>();
		component5.m_Handler = this;
		component5.m_BtnID1 = 2;
		component5 = this.LockPanel.GetChild(1).GetComponent<UIButton>();
		component5.m_Handler = this;
		component5.m_BtnID1 = 2;
		this.Tmp = this.GameT.GetChild(2);
		this.Img_EXIT = this.Tmp.GetComponent<Image>();
		this.Img_EXIT.sprite = this.door.LoadSprite("UI_main_close_base");
		this.Img_EXIT.material = material;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Img_EXIT.enabled = false;
		}
		this.Tmp = this.GameT.GetChild(2).GetChild(0);
		this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = material;
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.SetButtonEffectType(e_EffectType.e_Scale);
		this.btn_EXIT.transition = Selectable.Transition.None;
		if (this.mType == 0)
		{
			this.Img_Fusion_Info[0].gameObject.SetActive(true);
			this.text_FusionName.gameObject.SetActive(true);
			if (this.PM.mUIFusion_Y > -1f)
			{
				this.m_ScrollPanel.GoTo(this.PM.mUIFusion_Idx, this.PM.mUIFusion_Y);
			}
			this.btn_ItemInfo.gameObject.SetActive(true);
			this.Hbtn_Fusion[1].gameObject.SetActive(false);
		}
		else
		{
			this.Img_Fusion_Info[0].gameObject.SetActive(false);
			this.text_SkillName.gameObject.SetActive(true);
			this.m_ScrollPanel.GoTo((int)this.tmpItemCraftIndex);
			this.btn_ItemInfo.gameObject.SetActive(false);
			this.Hbtn_Fusion[1].gameObject.SetActive(true);
		}
		this.text_SkillItemQty.gameObject.SetActive(true);
		this.ReSetFusionData(this.mFusionlist[(int)this.tmpItemCraftIndex], true);
		this.UpdateLcokBtnType();
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 4);
	}

	// Token: 0x060016DD RID: 5853 RVA: 0x00275C50 File Offset: 0x00273E50
	public void ReSetFusionData(ushort mKey, bool bReSet = false)
	{
		if (this.bRDOutput)
		{
			this.Img_Fusion_R[0].color = Color.white;
			this.Img_Fusion_Add[0].color = Color.white;
			this.text_FusionNeedQty.color = Color.white;
			if (this.mType == 0)
			{
				this.Hbtn_Fusion[0].HIImage.color = Color.white;
				this.Hbtn_Fusion[0].CircleImage.color = Color.white;
				this.text_FusionName.color = Color.white;
			}
			else
			{
				this.Hbtn_Fusion[1].HIImage.color = Color.white;
				this.Hbtn_Fusion[1].CircleImage.color = Color.white;
				this.Img_Fusion_R[1].color = Color.white;
				this.Img_Fusion_Add[1].color = Color.white;
				this.text_SkillNeedQty.color = Color.white;
				this.text_SkillName.color = Color.white;
				for (int i = 0; i < 3; i++)
				{
					this.Hbtn_Need[i].HIImage.color = Color.white;
					this.Hbtn_Need[i].CircleImage.color = Color.white;
					this.Lbtn_Need[i].BackPanel.color = Color.white;
					this.Lbtn_Need[i].LEImage.color = Color.white;
					this.text_NeedQty[i].color = Color.white;
				}
				this.Img_PetSkill[0].color = Color.white;
				this.Img_PetSkill[1].color = Color.white;
			}
			this.text_SkillItemQty.color = this.c_ItemQty;
			for (int j = 0; j < 5; j++)
			{
				this.m_DResources.BtnResources[j].color = Color.white;
				this.m_DResources.ImgResources[j].color = Color.white;
				this.m_DResources.TextResources[j].color = Color.white;
			}
		}
		else
		{
			this.Img_Fusion_R[0].color = Color.gray;
			this.Img_Fusion_Add[0].color = Color.gray;
			this.text_FusionNeedQty.color = Color.gray;
			if (this.mType == 0)
			{
				this.Hbtn_Fusion[0].HIImage.color = Color.gray;
				this.Hbtn_Fusion[0].CircleImage.color = Color.gray;
				this.text_FusionName.color = Color.gray;
			}
			else
			{
				this.Hbtn_Fusion[1].HIImage.color = Color.gray;
				this.Hbtn_Fusion[1].CircleImage.color = Color.gray;
				this.Img_Fusion_R[1].color = Color.gray;
				this.Img_Fusion_Add[1].color = Color.gray;
				this.text_SkillNeedQty.color = Color.gray;
				this.text_SkillName.color = Color.gray;
				for (int k = 0; k < 3; k++)
				{
					this.Hbtn_Need[k].HIImage.color = Color.gray;
					this.Hbtn_Need[k].CircleImage.color = Color.gray;
					this.Lbtn_Need[k].BackPanel.color = Color.gray;
					this.Lbtn_Need[k].LEImage.color = Color.gray;
					this.text_NeedQty[k].color = Color.gray;
				}
				this.Img_PetSkill[0].color = Color.gray;
				this.Img_PetSkill[1].color = Color.gray;
			}
			this.text_SkillItemQty.color = Color.gray;
			for (int l = 0; l < 5; l++)
			{
				this.m_DResources.BtnResources[l].color = Color.gray;
				this.m_DResources.ImgResources[l].color = Color.gray;
				this.m_DResources.TextResources[l].color = Color.gray;
			}
		}
		this.mItemCount = 0;
		this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(mKey);
		if (this.tmpFD.Fusion_Kind == 2)
		{
			for (int m = 0; m < 3; m++)
			{
				if (this.tmpFD.ItemData[m].ItemCount > 0)
				{
					this.mItemCount += 1;
					this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.ItemData[m].ItemID);
					byte equipKind = this.tmpEquip.EquipKind;
					bool flag = this.GUIM.IsLeadItem(equipKind);
					if (this.btn_Skill_ItemStore[m] != null)
					{
						this.btn_Skill_ItemStore[m].gameObject.SetActive(true);
						this.Img_Skill_ItemStore[m].gameObject.SetActive(this.DM.TotalShopItemData.Find(this.tmpFD.ItemData[m].ItemID) != 0);
					}
					if (flag)
					{
						this.GUIM.ChangeLordEquipImg(this.Lbtn_Need[m].transform, this.tmpFD.ItemData[m].ItemID, this.tmpFD.ItemData[m].Rank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
						this.Lbtn_Need[m].gameObject.SetActive(true);
						this.Hbtn_Need[m].gameObject.SetActive(false);
					}
					else
					{
						this.GUIM.ChangeHeroItemImg(this.Hbtn_Need[m].transform, eHeroOrItem.Item, this.tmpFD.ItemData[m].ItemID, 0, this.tmpFD.ItemData[m].Rank, 0);
						this.Lbtn_Need[m].gameObject.SetActive(false);
						this.Hbtn_Need[m].gameObject.SetActive(true);
					}
					this.text_NeedQty[m].gameObject.SetActive(true);
				}
				else
				{
					this.Hbtn_Need[m].gameObject.SetActive(false);
					this.Lbtn_Need[m].gameObject.SetActive(false);
					this.text_NeedQty[m].gameObject.SetActive(false);
					if (this.btn_Skill_ItemStore[m] != null)
					{
						this.btn_Skill_ItemStore[m].gameObject.SetActive(false);
					}
				}
			}
		}
		else
		{
			for (int n = 0; n < 3; n++)
			{
				this.Hbtn_Need[n].gameObject.SetActive(false);
				this.Lbtn_Need[n].gameObject.SetActive(false);
				this.text_NeedQty[n].gameObject.SetActive(false);
			}
		}
		if (this.mItemCount == 1)
		{
			this.mFusionItemRT.anchoredPosition = new Vector2(50.5f, -182f);
			this.mHIbtnItemRT[0].anchoredPosition = new Vector2(208.5f, -182f);
		}
		else if (this.mItemCount == 2)
		{
			this.mFusionItemRT.anchoredPosition = new Vector2(-28.5f, -182f);
			this.mHIbtnItemRT[0].anchoredPosition = new Vector2(129.5f, -182f);
			this.mHIbtnItemRT[1].anchoredPosition = new Vector2(287.5f, -182f);
		}
		else if (this.mItemCount == 3)
		{
			this.mFusionItemRT.anchoredPosition = new Vector2(-73.5f, -182f);
			this.mHIbtnItemRT[0].anchoredPosition = new Vector2(56.5f, -182f);
			this.mHIbtnItemRT[1].anchoredPosition = new Vector2(187.5f, -182f);
			this.mHIbtnItemRT[2].anchoredPosition = new Vector2(318.5f, -182f);
		}
		this.UnitMax = this.CheckMax(this.BarrackMax);
		this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
		if (this.mType == 0)
		{
			this.PM.mPetFusionItemID = (int)this.tmpFD.Fusion_ItemID;
			this.text_FusionName.text = this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName);
			this.text_FusionName.SetAllDirty();
			this.text_FusionName.cachedTextGenerator.Invalidate();
			this.btn_Scale.enabled = true;
		}
		else
		{
			this.PM.mPetSkillItemID = (int)this.tmpFD.Fusion_ItemID;
			UIItemInfo.SetNameProperties(this.text_SkillName, null, this.Cstr_Name, null, ref this.tmpEquip, null);
			this.text_SkillName.SetAllDirty();
			this.text_SkillName.cachedTextGenerator.Invalidate();
			this.btn_Scale.enabled = false;
			this.tmpPetD = this.PM.PetTable.GetRecordByKey(this.tmpEquip.SyntheticParts[0].SyntheticItem);
			this.skill = this.PM.PetSkillTable.GetRecordByKey(this.tmpPetD.PetSkill[2]);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.Append('s');
			cstring.IntToFormat((long)this.skill.Icon, 5, false);
			cstring.AppendFormat("{0}");
			this.Img_PetSkill[0].sprite = this.GUIM.LoadSkillSprite(cstring);
		}
		this.Quantity = this.DM.GetCurItemQuantity(this.tmpFD.Fusion_ItemID, 0);
		this.Cstr_SkillItemQty.ClearString();
		this.Cstr_SkillItemQty.IntToFormat((long)this.Quantity, 1, true);
		this.Cstr_SkillItemQty.AppendFormat(this.DM.mStringTable.GetStringByID(79u));
		this.text_SkillItemQty.text = this.Cstr_SkillItemQty.ToString();
		this.text_SkillItemQty.SetAllDirty();
		this.text_SkillItemQty.cachedTextGenerator.Invalidate();
		uint num;
		if (this.bRDOutput)
		{
			if (this.DM.bSoldierSave && this.DM.bSetExpediton)
			{
				num = this.PM.m_FusionQty;
			}
			else if (!bReSet)
			{
				num = (uint)this.m_UnitRS.m_slider.value;
			}
			else
			{
				num = this.UnitMax;
			}
		}
		else
		{
			num = 1u;
		}
		uint num2 = num;
		if (this.bRDOutput)
		{
			this.NotRD_T.gameObject.SetActive(false);
			this.RD_T.gameObject.SetActive(true);
			if (this.tmpFD.Fusion_Kind < 2)
			{
				this.m_DResources.gameObject.SetActive(true);
			}
			else if (this.tmpFD.Fusion_Kind == 2)
			{
				this.m_DResources.gameObject.SetActive(false);
			}
			this.DM.bSoldierSave = false;
			this.DM.bSetExpediton = false;
			this.Cstr.ClearString();
			if (this.mType == 0)
			{
				if (num2 > 0u || this.PM.Fusion_Lock == 1)
				{
					if (this.PM.Fusion_Lock == 2)
					{
						this.PM.Fusion_SliderValue = (long)((ulong)num2);
					}
					else if (this.PM.Fusion_Lock == 1 && this.PM.Fusion_SliderValue <= (long)((ulong)this.BarrackMax))
					{
						num2 = (uint)this.PM.Fusion_SliderValue;
					}
					else
					{
						this.PM.Fusion_Lock = 2;
						this.PM.Fusion_SliderValue = (long)((ulong)num2);
					}
				}
			}
			else if (num2 > 0u || this.PM.FusionSkill_Lock == 1)
			{
				if (this.PM.FusionSkill_Lock == 2)
				{
					this.PM.FusionSkill_SliderValue = (long)((ulong)num2);
				}
				else if (this.PM.FusionSkill_Lock == 1 && this.PM.FusionSkill_SliderValue <= (long)((ulong)this.BarrackMax))
				{
					num2 = (uint)this.PM.FusionSkill_SliderValue;
				}
				else
				{
					this.PM.FusionSkill_Lock = 2;
					this.PM.FusionSkill_SliderValue = (long)((ulong)num2);
				}
			}
			this.m_UnitRS.m_slider.value = num2;
			this.m_UnitRS.Value = (long)((ulong)num2);
			StringManager.IntToStr(this.Cstr, (long)((ulong)num2), 1, true);
			this.m_UnitRS.m_inputText.text = this.Cstr.ToString();
			this.m_UnitRS.m_inputText.SetAllDirty();
			this.m_UnitRS.m_inputText.cachedTextGenerator.Invalidate();
		}
		else
		{
			if (this.mType == 0)
			{
				this.Cstr_RD.ClearString();
				this.Cstr_RD.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.TechData.GetRecordByKey(this.tmpFD.Science).TechName));
				this.Cstr_RD.AppendFormat(this.DM.mStringTable.GetStringByID(3775u));
				this.text_RD.text = this.Cstr_RD.ToString();
				this.text_RDbtn.text = this.DM.mStringTable.GetStringByID(3776u);
			}
			else
			{
				this.text_RD.text = this.DM.mStringTable.GetStringByID(14665u);
				this.text_RDbtn.text = this.DM.mStringTable.GetStringByID(14666u);
			}
			this.text_RD.SetAllDirty();
			this.text_RD.cachedTextGenerator.Invalidate();
			this.text_RDbtn.SetAllDirty();
			this.text_RDbtn.cachedTextGenerator.Invalidate();
			this.NotRD_T.gameObject.SetActive(true);
			this.RD_T.gameObject.SetActive(false);
		}
		if (this.tmpFD.Fusion_Kind < 2)
		{
			this.m_DResources.gameObject.SetActive(true);
			this.btn_Add[0].gameObject.SetActive(true);
			this.btn_Add[1].gameObject.SetActive(false);
		}
		else
		{
			this.m_DResources.gameObject.SetActive(false);
			this.btn_Add[0].gameObject.SetActive(false);
			this.btn_Add[1].gameObject.SetActive(true);
		}
		this.SetDRformURS(num2);
	}

	// Token: 0x060016DE RID: 5854 RVA: 0x00276B30 File Offset: 0x00274D30
	public uint CheckMax(uint MaxValue)
	{
		uint[] array = new uint[6];
		uint num = MaxValue;
		array[5] = (uint)this.DM.PetResource.CurrentStock;
		if (this.tmpFD.Fusion_Kind < 2)
		{
			for (int i = 0; i < 5; i++)
			{
				array[i] = this.DM.Resource[i].Stock;
			}
			if (this.Resources[0] > 0u)
			{
				uint num2 = array[0] / GameConstants.appCeil(this.Resources[0] * this.tmpEGA_Cost);
				if (num2 < num)
				{
					num = num2;
				}
			}
			if (this.Resources[1] > 0u)
			{
				uint num3 = array[1] / GameConstants.appCeil(this.Resources[1] * this.tmpEGA_Cost);
				if (num3 < num)
				{
					num = num3;
				}
			}
			if (this.Resources[2] > 0u)
			{
				uint num4 = array[2] / GameConstants.appCeil(this.Resources[2] * this.tmpEGA_Cost);
				if (num4 < num)
				{
					num = num4;
				}
			}
			if (this.Resources[3] > 0u)
			{
				uint num5 = array[3] / GameConstants.appCeil(this.Resources[3] * this.tmpEGA_Cost);
				if (num5 < num)
				{
					num = num5;
				}
			}
			if (this.Resources[4] > 0u)
			{
				uint num6 = array[4] / GameConstants.appCeil(this.Resources[4] * this.tmpEGA_Cost);
				if (num6 < num)
				{
					num = num6;
				}
			}
		}
		else
		{
			for (int j = 0; j < (int)this.mItemCount; j++)
			{
				if (this.m_NeedItem[j].ItemCount > 0)
				{
					ushort curItemQuantity = this.DM.GetCurItemQuantity(this.tmpFD.ItemData[j].ItemID, this.tmpFD.ItemData[j].Rank);
					uint num7 = (uint)curItemQuantity / GameConstants.appCeil((float)this.m_NeedItem[j].ItemCount * this.tmpEGA_Cost);
					if (num7 < num)
					{
						num = num7;
					}
				}
			}
		}
		if (this.Resources[6] > 0u)
		{
			uint num7 = array[5] / GameConstants.appCeil(this.Resources[6] * this.tmpEGA_Cost);
			if (num7 < num)
			{
				num = num7;
			}
		}
		return num;
	}

	// Token: 0x060016DF RID: 5855 RVA: 0x00276D90 File Offset: 0x00274F90
	public bool CheckFusion(ushort mIndex)
	{
		bool result = false;
		if (this.mFusionlist.Count > (int)mIndex)
		{
			if (!this.PM.bActFusioncutdown)
			{
				this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int)mIndex]);
			}
			else
			{
				this.tmpFD = this.DM.FusionDataTable_Act.GetRecordByKey(this.mFusionlist[(int)mIndex]);
			}
			Array.Clear(this.m_NeedItem, 0, this.m_NeedItem.Length);
			if (this.tmpFD.Fusion_Kind < 2)
			{
				this.Resources[0] = this.tmpFD.FoodRequire;
				this.Resources[1] = this.tmpFD.StoneRequire;
				this.Resources[2] = this.tmpFD.WoodRequire;
				this.Resources[3] = this.tmpFD.IronRequire;
				this.Resources[4] = this.tmpFD.MoneyRequire;
			}
			else
			{
				for (int i = 0; i < 3; i++)
				{
					this.m_NeedItem[i] = this.tmpFD.ItemData[i];
				}
			}
			this.Resources[5] = this.tmpFD.TimeRequire;
			this.Resources[6] = this.tmpFD.PetRequire;
			if (this.mType == 0 && (this.tmpFD.Science == 0 || this.DM.GetTechLevel(this.tmpFD.Science) > 0))
			{
				result = true;
			}
			if (this.mType == 1)
			{
				this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
				this.CurPetData = this.PM.FindPetData(this.tmpEquip.SyntheticParts[0].SyntheticItem);
				result = (this.CurPetData != null && this.CurPetData.Enhance == 2);
			}
			if (this.mType == 0)
			{
				this.GUIM.ChangeHeroItemImg(this.Hbtn_Fusion[0].transform, eHeroOrItem.Item, this.tmpFD.Fusion_ItemID, 0, 0, 0);
			}
			else
			{
				this.GUIM.ChangeHeroItemImg(this.Hbtn_Fusion[1].transform, eHeroOrItem.Item, this.tmpFD.Fusion_ItemID, 0, 0, 0);
			}
		}
		return result;
	}

	// Token: 0x060016E0 RID: 5856 RVA: 0x00277004 File Offset: 0x00275204
	public void SetDRformURS(double value)
	{
		if (this.DResourcesT == null)
		{
			return;
		}
		if (this.bRDOutput)
		{
			if (this.mType == 0)
			{
				this.PM.Fusion_SliderValue = (long)value;
			}
			else
			{
				this.PM.FusionSkill_SliderValue = (long)value;
			}
		}
		if (this.tmpFD.Fusion_Kind < 2)
		{
			for (int i = 0; i < 5; i++)
			{
				this.Rvalue[i] = (long)(value * GameConstants.appCeil(this.Resources[i] * this.tmpEGA_Cost));
			}
			this.GUIM.SetDemandResourcesText(this.DResourcesT, this.Rvalue);
		}
		this.SetPetResourcesText(value);
		this.btn_Fusion.ForTextChange(e_BtnType.e_Normal);
		this.btn_FusionCompleted.ForTextChange(e_BtnType.e_Normal);
		this.needDiamond = 0u;
		this.UnitMax = this.CheckMax(this.BarrackMax);
		if (value == 0.0)
		{
			this.btn_FusionCompleted.ForTextChange(e_BtnType.e_ChangeText);
		}
		else if (value > this.UnitMax)
		{
			bool flag = false;
			for (int j = 0; j < 5; j++)
			{
				if (this.Rvalue[j] > (long)((ulong)this.DM.Resource[j].Stock))
				{
					this.needDiamond += this.DM.GetResourceExchange((PriceListType)j, (uint)this.Rvalue[j] - this.DM.Resource[j].Stock);
					flag = true;
				}
			}
			this.Rvalue[5] = (long)(value * GameConstants.appCeil(this.Resources[6] * this.tmpEGA_Cost));
			if ((double)this.Rvalue[5] > this.DM.PetResource.CurrentStock)
			{
				this.needDiamond += this.DM.GetResourceExchange(PriceListType.PetResource, (uint)((double)this.Rvalue[5] - this.DM.PetResource.CurrentStock));
				flag = true;
			}
			for (int k = 0; k < 3; k++)
			{
				if (this.tmpFD.ItemData[k].ItemID > 0)
				{
					ushort num = this.DM.TotalShopItemData.Find(this.tmpFD.ItemData[k].ItemID);
					ushort curItemQuantity = this.DM.GetCurItemQuantity(this.tmpFD.ItemData[k].ItemID, this.tmpFD.ItemData[k].Rank);
					if (num > 0 && value * (double)this.tmpFD.ItemData[k].ItemCount > (double)curItemQuantity)
					{
						this.tmpST = this.DM.StoreData.GetRecordByKey(num);
						this.needDiamond += (uint)(this.tmpST.Price * (value * (double)this.tmpFD.ItemData[k].ItemCount - (double)curItemQuantity));
					}
				}
			}
			if (flag || !this.IsItemenough)
			{
				this.btn_Fusion.ForTextChange(e_BtnType.e_ChangeText);
			}
		}
		uint num2 = (uint)value * this.Resources[5];
		num2 = GameConstants.appCeil(num2 * this.tmpEGA);
		this.needDiamond += this.DM.GetResourceExchange(PriceListType.PetFusion, num2);
		this.Cstr_Gemstone.ClearString();
		this.Cstr_Gemstone.IntToFormat((long)((ulong)this.needDiamond), 1, true);
		this.Cstr_Gemstone.AppendFormat("{0}");
		this.text_Gemstone.text = this.Cstr_Gemstone.ToString();
		this.text_Gemstone.SetAllDirty();
		this.text_Gemstone.cachedTextGenerator.Invalidate();
		if (this.DM.RoleAttr.Diamond > this.needDiamond)
		{
			this.btn_FusionCompleted.ForTextChange(e_BtnType.e_Normal);
		}
		this.Cstr_Time.ClearString();
		this.Cstr_Time.Append(this.DM.mStringTable.GetStringByID(14659u));
		this.tmpValue = num2 / 3600u;
		if (this.tmpValue < 24u)
		{
			this.Cstr_Time.IntToFormat((long)((ulong)(this.tmpValue % 60u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num2 / 60u % 60u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num2 % 60u)), 2, false);
			this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
		}
		else if (this.GUIM.IsArabic)
		{
			this.Cstr_Time.IntToFormat((long)((ulong)(this.tmpValue % 24u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num2 / 60u % 60u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num2 % 60u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(this.tmpValue / 24u)), 1, false);
			this.Cstr_Time.AppendFormat("{0}:{1}:{2} {3}d");
		}
		else
		{
			this.Cstr_Time.IntToFormat((long)((ulong)(this.tmpValue / 24u)), 1, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(this.tmpValue % 24u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num2 / 60u % 60u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num2 % 60u)), 2, false);
			this.Cstr_Time.AppendFormat("{0}d {1}:{2}:{3}");
		}
		this.text_Time.text = this.Cstr_Time.ToString();
		this.text_Time.SetAllDirty();
		this.text_Time.cachedTextGenerator.Invalidate();
	}

	// Token: 0x060016E1 RID: 5857 RVA: 0x002775B0 File Offset: 0x002757B0
	public void SetPetResourcesText(double value)
	{
		this.IsItemenough = true;
		this.IsItemenough_Store = true;
		this.Rvalue[5] = (long)(value * GameConstants.appCeil(this.Resources[6] * this.tmpEGA_Cost));
		if (this.tmpFD.Fusion_Kind < 2)
		{
			this.Cstr_FusionNeedQty.ClearString();
			if (this.DM.PetResource.CurrentStock < (double)this.Rvalue[5])
			{
				if (this.GUIM.IsArabic)
				{
					GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint)this.Rvalue[5]);
					this.Cstr_FusionNeedQty.Append("/<color=#E5004F>");
					GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint)this.DM.PetResource.CurrentStock);
					this.Cstr_FusionNeedQty.Append("</color>");
				}
				else
				{
					this.Cstr_FusionNeedQty.Append("<color=#E5004F>");
					GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint)this.DM.PetResource.CurrentStock);
					this.Cstr_FusionNeedQty.AppendFormat("</color>/");
					GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint)this.Rvalue[5]);
				}
				this.Img_Fusion_Add[0].gameObject.SetActive(true);
			}
			else
			{
				if (this.GUIM.IsArabic)
				{
					GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint)this.Rvalue[5]);
					this.Cstr_FusionNeedQty.AppendFormat("/");
					GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint)this.DM.PetResource.CurrentStock);
				}
				else
				{
					GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint)this.DM.PetResource.CurrentStock);
					this.Cstr_FusionNeedQty.AppendFormat("/");
					GameConstants.FormatResourceValue(this.Cstr_FusionNeedQty, (uint)this.Rvalue[5]);
				}
				this.Img_Fusion_Add[0].gameObject.SetActive(false);
			}
			this.text_FusionNeedQty.text = this.Cstr_FusionNeedQty.ToString();
			this.text_FusionNeedQty.SetAllDirty();
			this.text_FusionNeedQty.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.Cstr_SkillNeedQty.ClearString();
			if (this.DM.PetResource.CurrentStock < (double)this.Rvalue[5])
			{
				if (this.GUIM.IsArabic)
				{
					GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint)this.Rvalue[5]);
					this.Cstr_SkillNeedQty.Append("/<color=#E5004F>");
					GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint)this.DM.PetResource.CurrentStock);
					this.Cstr_SkillNeedQty.Append("</color>");
				}
				else
				{
					this.Cstr_SkillNeedQty.Append("<color=#E5004F>");
					GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint)this.DM.PetResource.CurrentStock);
					this.Cstr_SkillNeedQty.AppendFormat("</color>/");
					GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint)this.Rvalue[5]);
				}
				this.Img_Fusion_Add[1].gameObject.SetActive(true);
			}
			else
			{
				if (this.GUIM.IsArabic)
				{
					GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint)this.Rvalue[5]);
					this.Cstr_SkillNeedQty.AppendFormat("/");
					GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint)this.DM.PetResource.CurrentStock);
				}
				else
				{
					GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint)this.DM.PetResource.CurrentStock);
					this.Cstr_SkillNeedQty.AppendFormat("/");
					GameConstants.FormatResourceValue(this.Cstr_SkillNeedQty, (uint)this.Rvalue[5]);
				}
				this.Img_Fusion_Add[1].gameObject.SetActive(false);
			}
			this.text_SkillNeedQty.text = this.Cstr_SkillNeedQty.ToString();
			this.text_SkillNeedQty.SetAllDirty();
			this.text_SkillNeedQty.cachedTextGenerator.Invalidate();
			for (int i = 0; i < 3; i++)
			{
				this.Rvalue[5] = (long)(value * GameConstants.appCeil((float)this.tmpFD.ItemData[i].ItemCount * this.tmpEGA_Cost));
				this.Cstr_SkillItemNeedQty[i].ClearString();
				if (this.tmpFD.ItemData[i].ItemCount > 0)
				{
					this.Quantity = this.DM.GetCurItemQuantity(this.tmpFD.ItemData[i].ItemID, this.tmpFD.ItemData[i].Rank);
					if ((long)this.Quantity < this.Rvalue[5])
					{
						if (this.GUIM.IsArabic)
						{
							GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[i], (uint)this.Rvalue[5]);
							this.Cstr_SkillItemNeedQty[i].Append("/<color=#E5004F>");
							GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[i], (uint)this.Quantity);
							this.Cstr_SkillItemNeedQty[i].Append("</color>");
						}
						else
						{
							this.Cstr_SkillItemNeedQty[i].Append("<color=#E5004F>");
							GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[i], (uint)this.Quantity);
							this.Cstr_SkillItemNeedQty[i].AppendFormat("</color>/");
							GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[i], (uint)this.Rvalue[5]);
						}
						this.IsItemenough = false;
						if (this.IsItemenough_Store && this.DM.TotalShopItemData.Find(this.tmpFD.ItemData[i].ItemID) == 0)
						{
							this.IsItemenough_Store = false;
						}
					}
					else if (this.GUIM.IsArabic)
					{
						GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[i], (uint)this.Rvalue[5]);
						this.Cstr_SkillItemNeedQty[i].AppendFormat("/");
						GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[i], (uint)this.Quantity);
					}
					else
					{
						GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[i], (uint)this.Quantity);
						this.Cstr_SkillItemNeedQty[i].AppendFormat("/");
						GameConstants.FormatResourceValue(this.Cstr_SkillItemNeedQty[i], (uint)this.Rvalue[5]);
					}
				}
				this.text_NeedQty[i].text = this.Cstr_SkillItemNeedQty[i].ToString();
				this.text_NeedQty[i].SetAllDirty();
				this.text_NeedQty[i].cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x060016E2 RID: 5858 RVA: 0x00277C1C File Offset: 0x00275E1C
	public bool CheckCanFusion(ushort mIdxID)
	{
		bool result = false;
		this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(mIdxID);
		this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
		this.CurPetData = this.PM.FindPetData(this.tmpEquip.SyntheticParts[0].SyntheticItem);
		if (this.CurPetData != null && this.CurPetData.Enhance > 1)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x060016E3 RID: 5859 RVA: 0x00277CAC File Offset: 0x00275EAC
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.tmpItem[panelObjectIdx] == null)
		{
			this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
			this.Hbtn_btn[panelObjectIdx] = item.transform.GetChild(0).GetComponent<UIHIBtn>();
			this.text_ItemName[panelObjectIdx] = item.transform.GetChild(1).GetComponent<UIText>();
			this.text_ItemNameSkill[panelObjectIdx] = item.transform.GetChild(2).GetComponent<UIText>();
			this.text_ItemCount[panelObjectIdx] = item.transform.GetChild(3).GetComponent<UIText>();
			this.tmpImgLock[panelObjectIdx] = item.transform.GetChild(4).GetComponent<Image>();
			this.tmpImgSelect[panelObjectIdx] = item.transform.GetChild(5).GetComponent<Image>();
			this.btn_Contract[panelObjectIdx] = item.transform.GetChild(6).GetComponent<UIButton>();
			this.btn_Contract[panelObjectIdx].m_Handler = this;
		}
		if (this.Hbtn_btn[panelObjectIdx] && dataIdx < this.mFusionlist.Count)
		{
			if ((int)this.tmpItemCraftIndex == dataIdx)
			{
				this.tmpImgSelect[panelObjectIdx].gameObject.SetActive(true);
				this.ItemSelect = 0f;
				this.mItemIdx = dataIdx;
				this.mItemIdx2 = panelObjectIdx;
			}
			else
			{
				this.tmpImgSelect[panelObjectIdx].gameObject.SetActive(false);
				this.tmpImgSelect[panelObjectIdx].color = new Color(1f, 1f, 1f, 0f);
			}
			this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[dataIdx]);
			this.GUIM.ChangeHeroItemImg(this.Hbtn_btn[panelObjectIdx].transform, eHeroOrItem.Item, this.tmpFD.Fusion_ItemID, 0, 0, 0);
			this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
			if (this.mType == 0)
			{
				if (this.tmpFD.Science != 0 && this.DM.GetTechLevel(this.tmpFD.Science) == 0)
				{
					this.tmpImgLock[panelObjectIdx].gameObject.SetActive(true);
					this.Hbtn_btn[panelObjectIdx].HIImage.color = Color.gray;
					this.Hbtn_btn[panelObjectIdx].CircleImage.color = Color.gray;
					this.text_ItemName[panelObjectIdx].color = Color.gray;
				}
				else
				{
					this.tmpImgLock[panelObjectIdx].gameObject.SetActive(false);
					this.Hbtn_btn[panelObjectIdx].HIImage.color = Color.white;
					this.Hbtn_btn[panelObjectIdx].CircleImage.color = Color.white;
					this.text_ItemName[panelObjectIdx].color = Color.white;
				}
				this.text_ItemName[panelObjectIdx].text = this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName);
				this.text_ItemName[panelObjectIdx].SetAllDirty();
				this.text_ItemName[panelObjectIdx].cachedTextGenerator.Invalidate();
				this.text_ItemName[panelObjectIdx].gameObject.SetActive(true);
				this.text_ItemNameSkill[panelObjectIdx].gameObject.SetActive(false);
				this.text_ItemCount[panelObjectIdx].gameObject.SetActive(false);
			}
			else
			{
				this.Cstr_SkillItemName[panelObjectIdx].ClearString();
				UIItemInfo.SetNameProperties(this.text_ItemNameSkill[panelObjectIdx], null, this.Cstr_SkillItemName[panelObjectIdx], null, ref this.tmpEquip, null);
				this.text_ItemNameSkill[panelObjectIdx].SetAllDirty();
				this.text_ItemNameSkill[panelObjectIdx].cachedTextGenerator.Invalidate();
				this.Quantity = this.DM.GetCurItemQuantity(this.tmpFD.Fusion_ItemID, 0);
				this.Cstr_SkillItem[panelObjectIdx].ClearString();
				this.Cstr_SkillItem[panelObjectIdx].IntToFormat((long)this.Quantity, 1, true);
				if (this.GUIM.IsArabic)
				{
					this.Cstr_SkillItem[panelObjectIdx].AppendFormat("{0}x");
				}
				else
				{
					this.Cstr_SkillItem[panelObjectIdx].AppendFormat("x{0}");
				}
				this.text_ItemCount[panelObjectIdx].text = this.Cstr_SkillItem[panelObjectIdx].ToString();
				this.text_ItemCount[panelObjectIdx].SetAllDirty();
				this.text_ItemCount[panelObjectIdx].cachedTextGenerator.Invalidate();
				this.text_ItemName[panelObjectIdx].gameObject.SetActive(false);
				this.text_ItemNameSkill[panelObjectIdx].gameObject.SetActive(true);
				this.text_ItemCount[panelObjectIdx].gameObject.SetActive(true);
				if (!this.CheckCanFusion(this.mFusionlist[dataIdx]))
				{
					this.tmpImgLock[panelObjectIdx].gameObject.SetActive(true);
					this.text_ItemNameSkill[panelObjectIdx].color = Color.gray;
					this.text_ItemCount[panelObjectIdx].color = Color.gray;
					this.Hbtn_btn[panelObjectIdx].HIImage.color = Color.gray;
					this.Hbtn_btn[panelObjectIdx].CircleImage.color = Color.gray;
				}
				else
				{
					this.tmpImgLock[panelObjectIdx].gameObject.SetActive(false);
					this.text_ItemNameSkill[panelObjectIdx].color = Color.white;
					this.text_ItemCount[panelObjectIdx].color = Color.white;
					this.Hbtn_btn[panelObjectIdx].HIImage.color = Color.white;
					this.Hbtn_btn[panelObjectIdx].CircleImage.color = Color.white;
				}
			}
		}
	}

	// Token: 0x060016E4 RID: 5860 RVA: 0x0027822C File Offset: 0x0027642C
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x060016E5 RID: 5861 RVA: 0x00278230 File Offset: 0x00276430
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 1:
		{
			ushort id = 14684;
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			if (this.mType == 0)
			{
				if (this.PM.Fusion_Lock == 2)
				{
					this.PM.Fusion_Lock = 1;
				}
				else if (this.PM.Fusion_Lock == 1)
				{
					this.PM.Fusion_Lock = 2;
					id = 14685;
				}
				cstring.IntToFormat(NetworkManager.UserID, 1, false);
				cstring.AppendFormat("{0}_Fusion_Lock_UseID");
				PlayerPrefs.SetString(cstring.ToString(), NetworkManager.UserID.ToString());
				cstring.ClearString();
				cstring.IntToFormat(NetworkManager.UserID, 1, false);
				cstring.AppendFormat("{0}_Fusion_Lock");
				PlayerPrefs.SetString(cstring.ToString(), this.PM.Fusion_Lock.ToString());
				cstring.ClearString();
				cstring.IntToFormat(NetworkManager.UserID, 1, false);
				cstring.AppendFormat("{0}_Fusion_SliderValue");
				PlayerPrefs.SetString(cstring.ToString(), this.PM.Fusion_SliderValue.ToString());
			}
			else
			{
				if (this.PM.FusionSkill_Lock == 2)
				{
					this.PM.FusionSkill_Lock = 1;
				}
				else if (this.PM.FusionSkill_Lock == 1)
				{
					this.PM.FusionSkill_Lock = 2;
					id = 14685;
				}
				cstring.IntToFormat(NetworkManager.UserID, 1, false);
				cstring.AppendFormat("{0}_FusionSkill_Lock_UseID");
				PlayerPrefs.SetString(cstring.ToString(), NetworkManager.UserID.ToString());
				cstring.ClearString();
				cstring.IntToFormat(NetworkManager.UserID, 1, false);
				cstring.AppendFormat("{0}_FusionSkill_Lock");
				PlayerPrefs.SetString(cstring.ToString(), this.PM.FusionSkill_Lock.ToString());
				cstring.ClearString();
				cstring.IntToFormat(NetworkManager.UserID, 1, false);
				cstring.AppendFormat("{0}_FusionSkill_SliderValue");
				PlayerPrefs.SetString(cstring.ToString(), this.PM.FusionSkill_SliderValue.ToString());
			}
			this.GUIM.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID((uint)id), 255, true);
			this.UpdateLcokBtnType();
			break;
		}
		case 2:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14684u), 255, true);
			break;
		case 3:
			if (this.DM.queueBarData[34].bActive)
			{
				this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(14660u), this.DM.mStringTable.GetStringByID(14661u), 0, 0, this.DM.mStringTable.GetStringByID(3925u), this.DM.mStringTable.GetStringByID(3926u));
			}
			else
			{
				this.FusionQty = (uint)this.m_UnitRS.Value;
				if (this.FusionQty == 0u)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703u), 255, true);
					return;
				}
				if (!this.CheckMaxItem())
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(887u), 255, true);
					return;
				}
				if (sender.m_BtnType == e_BtnType.e_Normal && GUIManager.Instance.ShowUILock(EUILock.PetFusion))
				{
					this.PM.m_ItemCraftQty = (ushort)this.m_UnitRS.Value;
					this.PM.SendItemCraft_Start(this.mFusionlist[(int)this.tmpItemCraftIndex], (ushort)this.FusionQty, 0);
					if (this.door != null)
					{
						this.door.CloseMenu(false);
					}
				}
				else if (sender.m_BtnType == e_BtnType.e_ChangeText)
				{
					if (!this.IsItemenough)
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(14686u), 255, true);
					}
					else
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(3942u), 255, true);
					}
				}
			}
			break;
		case 4:
			this.FusionQty = (uint)this.m_UnitRS.Value;
			if (this.FusionQty == 0u)
			{
				GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703u), 255, true);
				return;
			}
			if (sender.m_BtnType == e_BtnType.e_Normal)
			{
				if (!this.CheckMaxItem())
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(887u), 255, true);
					return;
				}
				if (!this.IsItemenough_Store)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(14686u), 255, true);
					return;
				}
				if (this.DM.RoleAttr.Diamond >= this.needDiamond)
				{
					this.PM.m_ItemCraftQty = (ushort)this.m_UnitRS.Value;
					if (!this.GUIM.OpenCheckCrystal(this.needDiamond, 5, (int)((int)this.m_eWindow << 16 | EGUIWindow.UI_VipLevelUp), -1) && GUIManager.Instance.ShowUILock(EUILock.PetFusion))
					{
						this.PM.SendItemCraft_Start(this.mFusionlist[(int)this.tmpItemCraftIndex], (ushort)this.FusionQty, 1);
					}
				}
				else
				{
					GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(3966u), DataManager.Instance.mStringTable.GetStringByID(646u), 1, 0, DataManager.Instance.mStringTable.GetStringByID(3968u), DataManager.Instance.mStringTable.GetStringByID(4025u));
				}
			}
			break;
		case 5:
			if (this.mType == 0)
			{
				this.GUIM.OpenTechTree(this.tmpFD.Science, true);
			}
			else
			{
				this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int)this.tmpItemCraftIndex]);
				this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
				this.PM.OpenPetUI(0, (int)this.tmpEquip.SyntheticParts[0].SyntheticItem);
			}
			break;
		case 6:
			this.GUIM.m_UICalculator.m_CalculatorHandler = this;
			this.GUIM.m_UICalculator.OpenCalculator(this.m_UnitRS.MaxValue, this.m_UnitRS.Value, -283f, -45f, this.m_UnitRS, 0L);
			break;
		case 7:
		{
			this.Tmp = sender.gameObject.transform.parent;
			int btnID = this.Tmp.GetComponent<ScrollPanelItem>().m_BtnID1;
			if (btnID == -1)
			{
				return;
			}
			this.tmpItemCraftIndex = (ushort)btnID;
			if (this.mItemIdx != -1)
			{
				this.tmpImgSelect[this.mItemIdx2].gameObject.SetActive(false);
				this.tmpImgSelect[this.mItemIdx2].color = new Color(1f, 1f, 1f, 0f);
			}
			this.mItemIdx = btnID;
			this.mItemIdx2 = this.Tmp.GetComponent<ScrollPanelItem>().m_BtnID2;
			this.tmpImgSelect[this.mItemIdx2].gameObject.SetActive(true);
			this.ItemSelect = 0f;
			this.bRDOutput = this.CheckFusion((ushort)btnID);
			this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int)this.tmpItemCraftIndex]);
			uint num = 0u;
			Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
			if (this.mType == 0 && recordByKey.Color >= 1 && recordByKey.Color <= 4)
			{
				num = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM)(166 + recordByKey.Color - 1));
			}
			if (num >= 9900u)
			{
				num = 9900u;
			}
			this.tmpEGA_Cost = 1f - num / 10000f;
			this.ReSetFusionData(this.mFusionlist[btnID], true);
			this.UpdateLcokBtnType();
			break;
		}
		case 8:
			this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int)this.tmpFD.Fusion_ItemID, false);
			break;
		case 9:
		{
			this.DM.bSoldierSave = true;
			this.DM.bSetExpediton = true;
			int arg = (int)(this.m_UnitRS.m_slider.value * GameConstants.appCeil(this.Resources[6] * this.tmpEGA_Cost));
			if (!this.bRDOutput)
			{
				arg = (int)(1u * GameConstants.appCeil(this.Resources[6] * this.tmpEGA_Cost));
			}
			this.door.OpenMenu(EGUIWindow.UI_BagFilter, 655361, arg, false);
			break;
		}
		case 10:
			if (this.mType == 0)
			{
				this.Cstr_Info.ClearString();
				this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14677u));
				this.Cstr_Info.Append("\n");
				this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14678u));
				this.Cstr_Info.Append("\n");
				this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14679u));
				this.Cstr_Info.Append("\n");
				this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14680u));
				this.Cstr_Info.Append("\n");
				this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(14671u), this.Cstr_Info.ToString(), null, null, 0, 0, true, true);
			}
			else
			{
				this.Cstr_Info.ClearString();
				this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14682u));
				this.Cstr_Info.Append("\n");
				this.Cstr_Info.Append(this.DM.mStringTable.GetStringByID(14681u));
				this.Cstr_Info.Append("\n");
				this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(14672u), this.Cstr_Info.ToString(), null, null, 0, 0, true, true);
			}
			break;
		case 12:
			this.DM.bSoldierSave = true;
			this.DM.bSetExpediton = true;
			if (sender.m_BtnID2 < this.btn_Skill_ItemStore.Length && this.btn_Skill_ItemStore[sender.m_BtnID2] != null)
			{
				ushort num2 = (ushort)(this.m_UnitRS.m_slider.value * GameConstants.appCeil((float)this.tmpFD.ItemData[sender.m_BtnID2].ItemCount * this.tmpEGA_Cost));
				if (!this.bRDOutput)
				{
					num2 = (ushort)(1u * GameConstants.appCeil((float)this.tmpFD.ItemData[sender.m_BtnID2].ItemCount * this.tmpEGA_Cost));
				}
				GUIManager.Instance.OpenItemFilterUI(this.tmpFD.ItemData[sender.m_BtnID2].ItemID, num2);
			}
			break;
		}
	}

	// Token: 0x060016E6 RID: 5862 RVA: 0x00278E30 File Offset: 0x00277030
	public bool CheckMaxItem()
	{
		bool result = false;
		ushort num = this.DM.GetCurItemQuantity(this.tmpFD.Fusion_ItemID, 0);
		if (this.DM.queueBarData[34].bActive && this.PM.ItemCraftID == this.mFusionlist[(int)this.tmpItemCraftIndex])
		{
			num += this.PM.ItemCraftCount;
		}
		if ((long)num + this.m_UnitRS.Value <= 65535L)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x060016E7 RID: 5863 RVA: 0x00278EC0 File Offset: 0x002770C0
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 != 0)
			{
				if (arg1 == 1)
				{
					MallManager.Instance.Send_Mall_Info();
				}
			}
			else
			{
				this.DM.bSoldierSave = true;
				this.DM.bSetExpediton = true;
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 34, false);
			}
		}
	}

	// Token: 0x060016E8 RID: 5864 RVA: 0x00278F28 File Offset: 0x00277128
	public void OnButtonDown(UIButtonHint sender)
	{
		this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int)this.tmpItemCraftIndex]);
		this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
		this.tmpPetD = this.PM.PetTable.GetRecordByKey(this.tmpEquip.SyntheticParts[0].SyntheticItem);
		this.CurPetData = this.PM.FindPetData(this.tmpEquip.SyntheticParts[0].SyntheticItem);
		if (this.CurPetData != null)
		{
			int num = 0;
			for (int i = 3; i > 0; i--)
			{
				if (this.PM.PetSkillTable.GetRecordByKey(this.tmpPetD.PetSkill[i]).Diamond > 0)
				{
					num = i;
				}
			}
			this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.CurentLv, this.tmpPetD.ID, this.tmpPetD.PetSkill[num], this.CurPetData.SkillLv[num], Vector2.zero, UIButtonHint.ePosition.Original);
		}
	}

	// Token: 0x060016E9 RID: 5865 RVA: 0x0027905C File Offset: 0x0027725C
	public void OnButtonUp(UIButtonHint sender)
	{
		this.GUIM.m_Hint.Hide(true);
	}

	// Token: 0x060016EA RID: 5866 RVA: 0x00279070 File Offset: 0x00277270
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x060016EB RID: 5867 RVA: 0x00279074 File Offset: 0x00277274
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x060016EC RID: 5868 RVA: 0x00279078 File Offset: 0x00277278
	public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
	{
		URS.m_slider.value = (double)mValue;
		URS.SliderValueChange();
		if (this.mType == 0)
		{
			this.PM.Fusion_SliderValue = mValue;
		}
		else
		{
			this.PM.FusionSkill_SliderValue = mValue;
		}
	}

	// Token: 0x060016ED RID: 5869 RVA: 0x002790B8 File Offset: 0x002772B8
	public override void OnClose()
	{
		if (this.mType == 0)
		{
			this.PM.mUIFusion_Y = this.mContentRT.anchoredPosition.y;
			this.PM.mUIFusion_Idx = this.m_ScrollPanel.GetTopIdx();
		}
		if (this.AssetName != null)
		{
			GUIManager.Instance.RemoveSpriteAsset(this.AssetName);
		}
		if (this.Cstr != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr);
		}
		if (this.Cstr_Gemstone != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Gemstone);
		}
		if (this.Cstr_Time != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Time);
		}
		if (this.Cstr_RD != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_RD);
		}
		if (this.Cstr_FusionNeedQty != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_FusionNeedQty);
		}
		if (this.Cstr_SkillNeedQty != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_SkillNeedQty);
		}
		if (this.Cstr_SkillItemQty != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_SkillItemQty);
		}
		if (this.Cstr_Info != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Info);
		}
		if (this.Cstr_UnitRS != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_UnitRS);
		}
		if (this.Cstr_Name != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Name);
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.Cstr_SkillItemNeedQty[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_SkillItemNeedQty[i]);
			}
		}
		for (int j = 0; j < 8; j++)
		{
			if (this.Cstr_SkillItem[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_SkillItem[j]);
			}
			if (this.Cstr_SkillItemName[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_SkillItemName[j]);
			}
		}
		if (this.DM.bSoldierSave)
		{
			this.PM.m_FusionQty = (uint)this.m_UnitRS.Value;
		}
		this.GUIM.ClearCalculator();
	}

	// Token: 0x060016EE RID: 5870 RVA: 0x002792F0 File Offset: 0x002774F0
	public override void UpdateTime(bool bOnSecond)
	{
		for (int i = 0; i < 8; i++)
		{
			if (this.tmpImgSelect[i] != null && this.tmpImgSelect[i].gameObject.activeSelf)
			{
				this.ItemSelect += Time.smoothDeltaTime;
				if (this.ItemSelect >= 0f)
				{
					if (this.ItemSelect >= 2f)
					{
						this.ItemSelect = 0f;
					}
					float a = (this.ItemSelect <= 1f) ? this.ItemSelect : (2f - this.ItemSelect);
					this.tmpImgSelect[i].color = new Color(1f, 1f, 1f, a);
				}
			}
		}
		if (this.mType == 0 && this.Img_Fusion_Info[0] != null && this.Img_Fusion_Info[0].gameObject.activeSelf && this.Img_Fusion_Info[1] != null)
		{
			this.ItemInfo += Time.smoothDeltaTime;
			if (this.ItemInfo >= 2f)
			{
				this.ItemInfo = 0f;
			}
			float a2 = (this.ItemInfo <= 1f) ? this.ItemInfo : (2f - this.ItemInfo);
			this.Img_Fusion_Info[1].color = new Color(1f, 1f, 1f, a2);
		}
	}

	// Token: 0x060016EF RID: 5871 RVA: 0x00279480 File Offset: 0x00277680
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Type != null && this.text_Type.enabled)
		{
			this.text_Type.enabled = false;
			this.text_Type.enabled = true;
		}
		if (this.text_Kind != null && this.text_Kind.enabled)
		{
			this.text_Kind.enabled = false;
			this.text_Kind.enabled = true;
		}
		if (this.text_Fusion != null && this.text_Fusion.enabled)
		{
			this.text_Fusion.enabled = false;
			this.text_Fusion.enabled = true;
		}
		if (this.text_FusionCompleted != null && this.text_FusionCompleted.enabled)
		{
			this.text_FusionCompleted.enabled = false;
			this.text_FusionCompleted.enabled = true;
		}
		if (this.text_Gemstone != null && this.text_Gemstone.enabled)
		{
			this.text_Gemstone.enabled = false;
			this.text_Gemstone.enabled = true;
		}
		if (this.text_Time != null && this.text_Time.enabled)
		{
			this.text_Time.enabled = false;
			this.text_Time.enabled = true;
		}
		if (this.text_RD != null && this.text_RD.enabled)
		{
			this.text_RD.enabled = false;
			this.text_RD.enabled = true;
		}
		if (this.text_RDbtn != null && this.text_RDbtn.enabled)
		{
			this.text_RDbtn.enabled = false;
			this.text_RDbtn.enabled = true;
		}
		if (this.text_FusionName != null && this.text_FusionName.enabled)
		{
			this.text_FusionName.enabled = false;
			this.text_FusionName.enabled = true;
		}
		if (this.text_FusionNeedQty != null && this.text_FusionNeedQty.enabled)
		{
			this.text_FusionNeedQty.enabled = false;
			this.text_FusionNeedQty.enabled = true;
		}
		if (this.text_SkillNeedQty != null && this.text_SkillNeedQty.enabled)
		{
			this.text_SkillNeedQty.enabled = false;
			this.text_SkillNeedQty.enabled = true;
		}
		if (this.text_SkillName != null && this.text_SkillName.enabled)
		{
			this.text_SkillName.enabled = false;
			this.text_SkillName.enabled = true;
		}
		if (this.text_SkillItemQty != null && this.text_SkillItemQty.enabled)
		{
			this.text_SkillItemQty.enabled = false;
			this.text_SkillItemQty.enabled = true;
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.text_NeedQty[i] != null && this.text_NeedQty[i].enabled)
			{
				this.text_NeedQty[i].enabled = false;
				this.text_NeedQty[i].enabled = true;
			}
		}
		for (int j = 0; j < 8; j++)
		{
			if (this.text_ItemName[j] != null && this.text_ItemName[j].enabled)
			{
				this.text_ItemName[j].enabled = false;
				this.text_ItemName[j].enabled = true;
			}
			if (this.text_ItemNameSkill[j] != null && this.text_ItemNameSkill[j].enabled)
			{
				this.text_ItemNameSkill[j].enabled = false;
				this.text_ItemNameSkill[j].enabled = true;
			}
			if (this.text_ItemCount[j] != null && this.text_ItemCount[j].enabled)
			{
				this.text_ItemCount[j].enabled = false;
				this.text_ItemCount[j].enabled = true;
			}
		}
		for (int k = 0; k < 2; k++)
		{
			if (this.Hbtn_Fusion[k] != null && this.Hbtn_Fusion[k].enabled)
			{
				this.Hbtn_Fusion[k].Refresh_FontTexture();
			}
		}
		for (int l = 0; l < 3; l++)
		{
			if (this.Hbtn_Need[l] != null && this.Hbtn_Need[l].enabled)
			{
				this.Hbtn_Need[l].Refresh_FontTexture();
			}
		}
		for (int m = 0; m < 8; m++)
		{
			if (this.Hbtn_btn[m] != null && this.Hbtn_btn[m].enabled)
			{
				this.Hbtn_btn[m].Refresh_FontTexture();
			}
		}
	}

	// Token: 0x060016F0 RID: 5872 RVA: 0x002799A8 File Offset: 0x00277BA8
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_Technology:
			if (this.mType == 0)
			{
				this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int)this.tmpItemCraftIndex]);
				if (this.DM.CheckResearchTech == this.tmpFD.Science)
				{
					this.bRDOutput = this.CheckFusion(this.tmpItemCraftIndex);
					this.ReSetFusionData(this.mFusionlist[(int)this.tmpItemCraftIndex], false);
					this.UpdateLcokBtnType();
				}
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			}
			break;
		default:
			if (networkNews != NetworkNews.Login)
			{
				if (networkNews != NetworkNews.Refresh_Item)
				{
					if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
					{
						if (networkNews == NetworkNews.Refresh_Pet)
						{
							this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
							this.bRDOutput = this.CheckFusion(this.tmpItemCraftIndex);
							this.ReSetFusionData(this.mFusionlist[(int)this.tmpItemCraftIndex], false);
							this.UpdateLcokBtnType();
						}
					}
					else
					{
						if (this.m_DResources != null)
						{
							this.m_DResources.Refresh_FontTexture();
						}
						if (this.m_UnitRS != null)
						{
							this.m_UnitRS.Refresh_FontTexture();
						}
						this.Refresh_FontTexture();
					}
				}
				else
				{
					this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
					this.bRDOutput = this.CheckFusion(this.tmpItemCraftIndex);
					this.ReSetFusionData(this.mFusionlist[(int)this.tmpItemCraftIndex], false);
					this.UpdateLcokBtnType();
				}
			}
			else
			{
				this.PM.SortPetData();
				this.UpdateLcokBtnType();
			}
			break;
		case NetworkNews.Refresh_AttribEffectVal:
		{
			uint effectBaseVal;
			if (this.mType == 0)
			{
				this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETLOEETRY_TRAINING_CAPACITY);
				effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETLOEETRY_MAKE_SPEED);
			}
			else
			{
				this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_PETSKILL_SKILLCASTITEMMAKE);
				effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETSKILL_MAKE_SKILLSTONE_SPEED);
			}
			this.m_UnitRS.MaxValue = (long)((ulong)this.BarrackMax);
			this.m_UnitRS.m_slider.maxValue = this.BarrackMax;
			this.Cstr_UnitRS.ClearString();
			StringManager.IntToStr(this.Cstr_UnitRS, (long)((ulong)this.BarrackMax), 1, true);
			this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
			this.m_UnitRS.m_TotalText.SetAllDirty();
			this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
			float num = 0f;
			float num2 = 10000u + effectBaseVal - num;
			if (num2 <= 100f)
			{
				num2 = 100f;
			}
			this.tmpEGA = 10000f / num2;
			this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int)this.tmpItemCraftIndex]);
			uint num3 = 0u;
			Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
			if (this.mType == 0 && recordByKey.Color >= 1 && recordByKey.Color <= 4)
			{
				num3 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM)(166 + recordByKey.Color - 1));
			}
			if (num3 >= 9900u)
			{
				num3 = 9900u;
			}
			this.tmpEGA_Cost = 1f - num3 / 10000f;
			this.UnitMax = this.CheckMax(this.BarrackMax);
			if (this.bRDOutput)
			{
				this.SetDRformURS(this.m_UnitRS.m_slider.value);
			}
			else
			{
				this.SetDRformURS(1.0);
			}
			this.UpdateLcokBtnType();
			break;
		}
		}
	}

	// Token: 0x060016F1 RID: 5873 RVA: 0x00279DA8 File Offset: 0x00277FA8
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
		{
			if ((this.mType == 0 && this.PM.Fusion_Lock == 1) || (this.mType == 1 && this.PM.FusionSkill_Lock == 1))
			{
				return;
			}
			uint effectBaseVal;
			if (this.mType == 0)
			{
				this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETLOEETRY_TRAINING_CAPACITY);
				effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETLOEETRY_MAKE_SPEED);
			}
			else
			{
				this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_PETSKILL_SKILLCASTITEMMAKE);
				effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETSKILL_MAKE_SKILLSTONE_SPEED);
			}
			float num = 0f;
			float num2 = 10000u + effectBaseVal - num;
			if (num2 <= 100f)
			{
				num2 = 100f;
			}
			this.tmpEGA = 10000f / num2;
			this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int)this.tmpItemCraftIndex]);
			uint num3 = 0u;
			Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpFD.Fusion_ItemID);
			if (this.mType == 0 && recordByKey.Color >= 1 && recordByKey.Color <= 4)
			{
				num3 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM)(166 + recordByKey.Color - 1));
			}
			if (num3 >= 9900u)
			{
				num3 = 9900u;
			}
			this.tmpEGA_Cost = 1f - num3 / 10000f;
			this.UnitMax = this.CheckMax(this.BarrackMax);
			this.Cstr.ClearString();
			StringManager.IntToStr(this.Cstr, (long)((ulong)this.UnitMax), 1, true);
			this.m_UnitRS.m_slider.value = this.UnitMax;
			this.m_UnitRS.Value = (long)((ulong)this.UnitMax);
			this.m_UnitRS.m_inputText.text = this.Cstr.ToString();
			this.m_UnitRS.m_inputText.SetAllDirty();
			this.m_UnitRS.m_inputText.cachedTextGenerator.Invalidate();
			this.SetDRformURS(this.UnitMax);
			this.Quantity = this.DM.GetCurItemQuantity(this.tmpFD.Fusion_ItemID, 0);
			this.Cstr_SkillItemQty.ClearString();
			this.Cstr_SkillItemQty.IntToFormat((long)this.Quantity, 1, true);
			this.Cstr_SkillItemQty.AppendFormat(this.DM.mStringTable.GetStringByID(79u));
			this.text_SkillItemQty.text = this.Cstr_SkillItemQty.ToString();
			this.text_SkillItemQty.SetAllDirty();
			this.text_SkillItemQty.cachedTextGenerator.Invalidate();
			break;
		}
		case 2:
			this.tmpFD = this.DM.FusionDataTable.GetRecordByKey(this.mFusionlist[(int)this.tmpItemCraftIndex]);
			this.Quantity = this.DM.GetCurItemQuantity(this.tmpFD.Fusion_ItemID, 0);
			this.Cstr_SkillItemQty.ClearString();
			this.Cstr_SkillItemQty.IntToFormat((long)this.Quantity, 1, true);
			this.Cstr_SkillItemQty.AppendFormat(this.DM.mStringTable.GetStringByID(79u));
			this.text_SkillItemQty.text = this.Cstr_SkillItemQty.ToString();
			this.text_SkillItemQty.SetAllDirty();
			this.text_SkillItemQty.cachedTextGenerator.Invalidate();
			break;
		case 3:
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			this.bRDOutput = this.CheckFusion(this.tmpItemCraftIndex);
			this.ReSetFusionData(this.mFusionlist[(int)this.tmpItemCraftIndex], false);
			this.UpdateLcokBtnType();
			break;
		default:
			if (arg1 == 100)
			{
				if (GUIManager.Instance.ShowUILock(EUILock.PetFusion))
				{
					this.PM.SendItemCraft_Start(this.mFusionlist[(int)this.tmpItemCraftIndex], (ushort)this.FusionQty, 1);
				}
			}
			break;
		}
	}

	// Token: 0x060016F2 RID: 5874 RVA: 0x0027A1E0 File Offset: 0x002783E0
	private void SetLockBtnType(int tpye = 0)
	{
		if (this.LockPanel == null || this.btn_Lock == null || this.Img_Lock == null)
		{
			return;
		}
		if (tpye == 0)
		{
			this.LockPanel.gameObject.SetActive(false);
			this.Img_Lock.gameObject.SetActive(false);
			this.btn_Lock.gameObject.SetActive(false);
			this.Img_LockBG.gameObject.SetActive(false);
		}
		else if (tpye == 1)
		{
			this.btn_Lock.image.sprite = this.spArray.GetSprite(1);
			this.Img_Lock.sprite = this.spArray.GetSprite(3);
			this.btn_Lock.gameObject.SetActive(true);
			this.Img_Lock.gameObject.SetActive(true);
			this.LockPanel.gameObject.SetActive(true);
			this.Img_LockBG.gameObject.SetActive(true);
			if (this.bRDOutput)
			{
				this.SetLockValue();
			}
		}
		else if (tpye == 2)
		{
			this.btn_Lock.image.sprite = this.spArray.GetSprite(0);
			this.Img_Lock.sprite = this.spArray.GetSprite(2);
			this.btn_Lock.gameObject.SetActive(true);
			this.Img_Lock.gameObject.SetActive(true);
			this.LockPanel.gameObject.SetActive(false);
			this.Img_LockBG.gameObject.SetActive(false);
		}
	}

	// Token: 0x060016F3 RID: 5875 RVA: 0x0027A384 File Offset: 0x00278584
	private void UpdateLcokBtnType()
	{
		if (this.GUIM.BuildingData.GetBuildData(8, 0).Level < 18 || !this.bRDOutput)
		{
			this.SetLockBtnType(0);
		}
		else if (this.mType == 0)
		{
			this.SetLockBtnType(this.PM.Fusion_Lock);
		}
		else
		{
			this.SetLockBtnType(this.PM.FusionSkill_Lock);
		}
	}

	// Token: 0x060016F4 RID: 5876 RVA: 0x0027A3FC File Offset: 0x002785FC
	private void SetLockValue()
	{
		this.Cstr.ClearString();
		if (this.mType == 0)
		{
			StringManager.IntToStr(this.Cstr, this.PM.Fusion_SliderValue, 1, true);
			this.m_UnitRS.m_slider.value = (double)this.PM.Fusion_SliderValue;
			this.m_UnitRS.Value = this.PM.Fusion_SliderValue;
		}
		else
		{
			StringManager.IntToStr(this.Cstr, this.PM.FusionSkill_SliderValue, 1, true);
			this.m_UnitRS.m_slider.value = (double)this.PM.FusionSkill_SliderValue;
			this.m_UnitRS.Value = this.PM.FusionSkill_SliderValue;
		}
		this.m_UnitRS.m_inputText.text = this.Cstr.ToString();
		this.m_UnitRS.m_inputText.SetAllDirty();
		this.m_UnitRS.m_inputText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x060016F5 RID: 5877 RVA: 0x0027A4FC File Offset: 0x002786FC
	private void Start()
	{
	}

	// Token: 0x060016F6 RID: 5878 RVA: 0x0027A500 File Offset: 0x00278700
	private void Update()
	{
	}

	// Token: 0x0400445D RID: 17501
	private DataManager DM;

	// Token: 0x0400445E RID: 17502
	private GUIManager GUIM;

	// Token: 0x0400445F RID: 17503
	private PetManager PM;

	// Token: 0x04004460 RID: 17504
	private Transform GameT;

	// Token: 0x04004461 RID: 17505
	private Transform Tmp;

	// Token: 0x04004462 RID: 17506
	private Transform Tmp1;

	// Token: 0x04004463 RID: 17507
	private Transform Tmp2;

	// Token: 0x04004464 RID: 17508
	private Transform Tmp3;

	// Token: 0x04004465 RID: 17509
	private Transform RD_T;

	// Token: 0x04004466 RID: 17510
	private Transform NotRD_T;

	// Token: 0x04004467 RID: 17511
	private Transform LockPanel;

	// Token: 0x04004468 RID: 17512
	private Transform DResourcesT;

	// Token: 0x04004469 RID: 17513
	private RectTransform mContentRT;

	// Token: 0x0400446A RID: 17514
	private RectTransform mFusionItemRT;

	// Token: 0x0400446B RID: 17515
	private RectTransform[] mHIbtnItemRT = new RectTransform[3];

	// Token: 0x0400446C RID: 17516
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x0400446D RID: 17517
	private Door door;

	// Token: 0x0400446E RID: 17518
	private UISpritesArray spArray;

	// Token: 0x0400446F RID: 17519
	private UIButton btn_EXIT;

	// Token: 0x04004470 RID: 17520
	private UIButton btn_Lock;

	// Token: 0x04004471 RID: 17521
	private UIButton btn_Fusion;

	// Token: 0x04004472 RID: 17522
	private UIButton btn_FusionCompleted;

	// Token: 0x04004473 RID: 17523
	private UIButton btn_RD;

	// Token: 0x04004474 RID: 17524
	private UIButton btn_ItemInfo;

	// Token: 0x04004475 RID: 17525
	private UIButton btn_I;

	// Token: 0x04004476 RID: 17526
	private UIButton btn_Skill;

	// Token: 0x04004477 RID: 17527
	private UIButton[] btn_Add = new UIButton[2];

	// Token: 0x04004478 RID: 17528
	private UIButton[] btn_Skill_ItemStore = new UIButton[3];

	// Token: 0x04004479 RID: 17529
	private UIButton[] btn_Contract = new UIButton[8];

	// Token: 0x0400447A RID: 17530
	private uButtonScale btn_Scale;

	// Token: 0x0400447B RID: 17531
	private Image Img_EXIT;

	// Token: 0x0400447C RID: 17532
	private Image Img_Lock;

	// Token: 0x0400447D RID: 17533
	private Image Img_LockBG;

	// Token: 0x0400447E RID: 17534
	private Image[] Img_FusionCompleted = new Image[3];

	// Token: 0x0400447F RID: 17535
	private Image[] Img_Fusion = new Image[2];

	// Token: 0x04004480 RID: 17536
	private Image[] Img_Fusion_Info = new Image[2];

	// Token: 0x04004481 RID: 17537
	private Image[] Img_Fusion_R = new Image[2];

	// Token: 0x04004482 RID: 17538
	private Image[] Img_Fusion_Add = new Image[2];

	// Token: 0x04004483 RID: 17539
	private Image[] Img_PetSkill = new Image[2];

	// Token: 0x04004484 RID: 17540
	private Image Img_RDLock;

	// Token: 0x04004485 RID: 17541
	private Image[] tmpImgSelect = new Image[8];

	// Token: 0x04004486 RID: 17542
	private Image[] tmpImgLock = new Image[8];

	// Token: 0x04004487 RID: 17543
	private Image[] Img_Skill_ItemStore = new Image[3];

	// Token: 0x04004488 RID: 17544
	private UIText text_Title;

	// Token: 0x04004489 RID: 17545
	private UIText text_Type;

	// Token: 0x0400448A RID: 17546
	private UIText text_Kind;

	// Token: 0x0400448B RID: 17547
	private UIText text_Fusion;

	// Token: 0x0400448C RID: 17548
	private UIText text_FusionCompleted;

	// Token: 0x0400448D RID: 17549
	private UIText text_Gemstone;

	// Token: 0x0400448E RID: 17550
	private UIText text_Time;

	// Token: 0x0400448F RID: 17551
	private UIText text_RD;

	// Token: 0x04004490 RID: 17552
	private UIText text_RDbtn;

	// Token: 0x04004491 RID: 17553
	private UIText text_FusionName;

	// Token: 0x04004492 RID: 17554
	private UIText text_FusionNeedQty;

	// Token: 0x04004493 RID: 17555
	private UIText text_SkillNeedQty;

	// Token: 0x04004494 RID: 17556
	private UIText text_SkillName;

	// Token: 0x04004495 RID: 17557
	private UIText text_SkillItemQty;

	// Token: 0x04004496 RID: 17558
	private UIText[] text_NeedQty = new UIText[3];

	// Token: 0x04004497 RID: 17559
	private UIText[] text_ItemName = new UIText[8];

	// Token: 0x04004498 RID: 17560
	private UIText[] text_ItemNameSkill = new UIText[8];

	// Token: 0x04004499 RID: 17561
	private UIText[] text_ItemCount = new UIText[8];

	// Token: 0x0400449A RID: 17562
	private UIHIBtn[] Hbtn_Fusion = new UIHIBtn[2];

	// Token: 0x0400449B RID: 17563
	private UIHIBtn[] Hbtn_Need = new UIHIBtn[3];

	// Token: 0x0400449C RID: 17564
	private UILEBtn[] Lbtn_Need = new UILEBtn[3];

	// Token: 0x0400449D RID: 17565
	private UIHIBtn[] Hbtn_btn = new UIHIBtn[8];

	// Token: 0x0400449E RID: 17566
	private DemandResources m_DResources;

	// Token: 0x0400449F RID: 17567
	private UnitResourcesSlider m_UnitRS;

	// Token: 0x040044A0 RID: 17568
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040044A1 RID: 17569
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[8];

	// Token: 0x040044A2 RID: 17570
	private List<float> tmplist = new List<float>();

	// Token: 0x040044A3 RID: 17571
	private List<ushort> mFusionlist = new List<ushort>();

	// Token: 0x040044A4 RID: 17572
	private List<ushort> mSkilllist = new List<ushort>();

	// Token: 0x040044A5 RID: 17573
	private CString Cstr;

	// Token: 0x040044A6 RID: 17574
	private CString Cstr_Gemstone;

	// Token: 0x040044A7 RID: 17575
	private CString Cstr_Time;

	// Token: 0x040044A8 RID: 17576
	private CString Cstr_RD;

	// Token: 0x040044A9 RID: 17577
	private CString Cstr_FusionNeedQty;

	// Token: 0x040044AA RID: 17578
	private CString Cstr_SkillNeedQty;

	// Token: 0x040044AB RID: 17579
	private CString Cstr_SkillItemQty;

	// Token: 0x040044AC RID: 17580
	private CString Cstr_Info;

	// Token: 0x040044AD RID: 17581
	private CString Cstr_UnitRS;

	// Token: 0x040044AE RID: 17582
	private CString Cstr_Name;

	// Token: 0x040044AF RID: 17583
	private CString[] Cstr_SkillItemNeedQty = new CString[3];

	// Token: 0x040044B0 RID: 17584
	private CString[] Cstr_SkillItem = new CString[8];

	// Token: 0x040044B1 RID: 17585
	private CString[] Cstr_SkillItemName = new CString[8];

	// Token: 0x040044B2 RID: 17586
	private byte mType;

	// Token: 0x040044B3 RID: 17587
	private uint[] Resources = new uint[7];

	// Token: 0x040044B4 RID: 17588
	private byte RD_Kind;

	// Token: 0x040044B5 RID: 17589
	private byte RD_Rank;

	// Token: 0x040044B6 RID: 17590
	private uint UnitMax;

	// Token: 0x040044B7 RID: 17591
	private uint BarrackMax;

	// Token: 0x040044B8 RID: 17592
	private uint FusionQty;

	// Token: 0x040044B9 RID: 17593
	private float tmpEGA_Cost = 1f;

	// Token: 0x040044BA RID: 17594
	private float tmpEGA;

	// Token: 0x040044BB RID: 17595
	private long[] Rvalue = new long[6];

	// Token: 0x040044BC RID: 17596
	private uint tmpValue;

	// Token: 0x040044BD RID: 17597
	private bool bRDOutput = true;

	// Token: 0x040044BE RID: 17598
	private ushort Quantity;

	// Token: 0x040044BF RID: 17599
	private ushort tmpItemCraftIndex;

	// Token: 0x040044C0 RID: 17600
	private byte mItemCount;

	// Token: 0x040044C1 RID: 17601
	private bool IsItemenough = true;

	// Token: 0x040044C2 RID: 17602
	private bool IsItemenough_Store = true;

	// Token: 0x040044C3 RID: 17603
	private uint needDiamond;

	// Token: 0x040044C4 RID: 17604
	private ComboBoxItem[] m_NeedItem = new ComboBoxItem[3];

	// Token: 0x040044C5 RID: 17605
	private float ItemSelect;

	// Token: 0x040044C6 RID: 17606
	private float ItemInfo;

	// Token: 0x040044C7 RID: 17607
	private int mItemIdx = -1;

	// Token: 0x040044C8 RID: 17608
	private int mItemIdx2 = -1;

	// Token: 0x040044C9 RID: 17609
	private Equip tmpEquip;

	// Token: 0x040044CA RID: 17610
	private PetTbl tmpPetD;

	// Token: 0x040044CB RID: 17611
	private FusionData tmpFD;

	// Token: 0x040044CC RID: 17612
	private PetSkillTbl skill;

	// Token: 0x040044CD RID: 17613
	private RoleBuildingData mBD;

	// Token: 0x040044CE RID: 17614
	private BuildLevelRequest mBR;

	// Token: 0x040044CF RID: 17615
	private PetData CurPetData;

	// Token: 0x040044D0 RID: 17616
	private CHashTable<ushort, ushort> FusionlistItemData;

	// Token: 0x040044D1 RID: 17617
	private string AssetName;

	// Token: 0x040044D2 RID: 17618
	private ushort mPetSkillIcon;

	// Token: 0x040044D3 RID: 17619
	private StoreTbl tmpST;

	// Token: 0x040044D4 RID: 17620
	private Color c_ItemQty = new Color(0.549f, 0.878f, 1f);
}
