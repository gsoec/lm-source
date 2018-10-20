using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004F3 RID: 1267
public class UIBarrack_Soldier : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUICalculatorHandler, IUIUnitRSliderHandler
{
	// Token: 0x06001956 RID: 6486 RVA: 0x002AACAC File Offset: 0x002A8EAC
	public void OnVauleChang(UnitResourcesSlider sender)
	{
		if (this.Img_SoldierArrow.IsActive())
		{
			this.Img_SoldierArrow.gameObject.SetActive(false);
		}
		this.Cstr.ClearString();
		StringManager.IntToStr(this.Cstr, sender.Value, 1, true);
		sender.m_inputText.text = this.Cstr.ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
		if (sender.m_ID == 1)
		{
			this.SetDRformURS(sender.GetComponent<Transform>(), (double)sender.Value);
		}
		else if (sender.Value == 0L)
		{
			this.btn_Soldier_Disband.ForTextChange(e_BtnType.e_ChangeText);
		}
		else if (this.btn_Soldier_Disband.m_BtnType == e_BtnType.e_ChangeText)
		{
			this.btn_Soldier_Disband.ForTextChange(e_BtnType.e_Normal);
		}
		if (this.mType == 0)
		{
			this.GUIM.Barrack_Soldier_SliderValue = sender.Value;
		}
	}

	// Token: 0x06001957 RID: 6487 RVA: 0x002AADA4 File Offset: 0x002A8FA4
	public void OnTextChang(UnitResourcesSlider sender)
	{
		if (this.Img_SoldierArrow.IsActive())
		{
			this.Img_SoldierArrow.gameObject.SetActive(false);
		}
		this.Cstr.ClearString();
		StringManager.IntToStr(this.Cstr, sender.Value, 1, true);
		if (sender.m_ID == 1)
		{
			this.SetDRformURS(sender.GetComponent<Transform>(), (double)sender.Value);
		}
		else if (sender.Value == 0L)
		{
			this.btn_Soldier_Disband.ForTextChange(e_BtnType.e_ChangeText);
		}
		else if (this.btn_Soldier_Disband.m_BtnType == e_BtnType.e_ChangeText)
		{
			this.btn_Soldier_Disband.ForTextChange(e_BtnType.e_Normal);
		}
		if (this.mType == 0)
		{
			this.GUIM.Barrack_Soldier_SliderValue = sender.Value;
		}
	}

	// Token: 0x06001958 RID: 6488 RVA: 0x002AAE6C File Offset: 0x002A906C
	public override void OnOpen(int arg1, int arg2)
	{
		this.Pos[0] = -42f;
		this.Pos[1] = -61f;
		this.Pos[2] = -70f;
		this.Pos[3] = -80f;
		this.Pos[4] = -87f;
		this.Width[0] = 66f;
		this.Width[1] = 90f;
		this.Width[2] = 114f;
		this.Width[3] = 134f;
		this.Width[4] = 150f;
		this.RD_ID = (byte)arg1;
		if (this.RD_ID > 16)
		{
			this.mType = 1;
		}
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.TTFont = this.GUIM.GetTTFFont();
		BuildTypeData recordByKey = this.DM.BuildsTypeData.GetRecordByKey(6);
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.AssetName = "BuildingWindow";
		Material material = this.GUIM.AddSpriteAsset(this.AssetName);
		Material material2 = this.door.LoadMaterial();
		Material material3;
		if (this.mType == 0)
		{
			this.AssetName1 = "UI_arms";
			material3 = this.GUIM.AddSpriteAsset(this.AssetName1);
		}
		else
		{
			this.AssetName1 = "UI_trap";
			material3 = this.GUIM.AddSpriteAsset(this.AssetName1);
		}
		CString cstring = StringManager.Instance.StaticString1024();
		this.Cstr = StringManager.Instance.SpawnString(30);
		this.Cstr_D = StringManager.Instance.SpawnString(30);
		this.Cstr_D2 = StringManager.Instance.SpawnString(30);
		this.Cstr_UnitRS = StringManager.Instance.SpawnString(30);
		this.Cstr_Gemstone = StringManager.Instance.SpawnString(30);
		this.Cstr_Hint_Info = StringManager.Instance.SpawnString(200);
		this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)this.RD_ID);
		this.RD_Kind = this.tmpSD.SoldierKind;
		this.RD_Rank = this.tmpSD.Tier;
		this.Resources[0] = this.tmpSD.FoodRequire;
		this.Resources[1] = this.tmpSD.StoneRequire;
		this.Resources[2] = this.tmpSD.WoodRequire;
		this.Resources[3] = this.tmpSD.IronRequire;
		this.Resources[4] = this.tmpSD.MoneyRequire;
		this.Resources[5] = this.tmpSD.TimeRequire;
		this.UnitSoldier[0] = (uint)this.tmpSD.Strength;
		this.UnitSoldier[1] = (uint)this.tmpSD.Salaries;
		this.UnitSoldier[2] = (uint)this.tmpSD.Traffic;
		if (this.mType == 0)
		{
			this.mSoldierArms[0] = 3841u + (uint)this.RD_Kind;
			this.mSoldierArms[2] = 3866u + (uint)this.RD_Kind;
		}
		else
		{
			this.mSoldierArms[0] = 11154u + (uint)this.RD_Kind;
			this.mSoldierArms[2] = 4933u + (uint)this.RD_Kind;
		}
		this.mSoldierArms[1] = 3859u + (uint)this.RD_Kind;
		for (int i = 0; i < 16; i++)
		{
			this.mSoldierProperty[i] = new byte[4];
		}
		if (this.mType == 0)
		{
			this.mSoldierProperty[0][0] = 1;
			this.mSoldierProperty[0][1] = 1;
			this.mSoldierProperty[0][2] = 1;
			this.mSoldierProperty[0][3] = 4;
			this.mSoldierProperty[1][0] = 2;
			this.mSoldierProperty[1][1] = 2;
			this.mSoldierProperty[1][2] = 2;
			this.mSoldierProperty[1][3] = 3;
			this.mSoldierProperty[2][0] = 3;
			this.mSoldierProperty[2][1] = 3;
			this.mSoldierProperty[2][2] = 3;
			this.mSoldierProperty[2][3] = 2;
			this.mSoldierProperty[3][0] = 4;
			this.mSoldierProperty[3][1] = 4;
			this.mSoldierProperty[3][2] = 4;
			this.mSoldierProperty[3][3] = 0;
			this.mSoldierProperty[4][0] = 1;
			this.mSoldierProperty[4][1] = 1;
			this.mSoldierProperty[4][2] = 1;
			this.mSoldierProperty[4][3] = 4;
			this.mSoldierProperty[5][0] = 2;
			this.mSoldierProperty[5][1] = 2;
			this.mSoldierProperty[5][2] = 2;
			this.mSoldierProperty[5][3] = 3;
			this.mSoldierProperty[6][0] = 3;
			this.mSoldierProperty[6][1] = 3;
			this.mSoldierProperty[6][2] = 3;
			this.mSoldierProperty[6][3] = 2;
			this.mSoldierProperty[7][0] = 4;
			this.mSoldierProperty[7][1] = 4;
			this.mSoldierProperty[7][2] = 4;
			this.mSoldierProperty[7][3] = 1;
			this.mSoldierProperty[8][0] = 1;
			this.mSoldierProperty[8][1] = 1;
			this.mSoldierProperty[8][2] = 1;
			this.mSoldierProperty[8][3] = 4;
			this.mSoldierProperty[9][0] = 2;
			this.mSoldierProperty[9][1] = 2;
			this.mSoldierProperty[9][2] = 2;
			this.mSoldierProperty[9][3] = 4;
			this.mSoldierProperty[10][0] = 3;
			this.mSoldierProperty[10][1] = 3;
			this.mSoldierProperty[10][2] = 3;
			this.mSoldierProperty[10][3] = 3;
			this.mSoldierProperty[11][0] = 4;
			this.mSoldierProperty[11][1] = 4;
			this.mSoldierProperty[11][2] = 4;
			this.mSoldierProperty[11][3] = 2;
			this.mSoldierProperty[12][0] = 1;
			this.mSoldierProperty[12][1] = 1;
			this.mSoldierProperty[12][2] = 1;
			this.mSoldierProperty[12][3] = 3;
			this.mSoldierProperty[13][0] = 2;
			this.mSoldierProperty[13][1] = 2;
			this.mSoldierProperty[13][2] = 2;
			this.mSoldierProperty[13][3] = 3;
			this.mSoldierProperty[14][0] = 3;
			this.mSoldierProperty[14][1] = 3;
			this.mSoldierProperty[14][2] = 3;
			this.mSoldierProperty[14][3] = 1;
			this.mSoldierProperty[15][0] = 4;
			this.mSoldierProperty[15][1] = 4;
			this.mSoldierProperty[15][2] = 4;
			this.mSoldierProperty[15][3] = 0;
		}
		else
		{
			this.mSoldierProperty[0][0] = 1;
			this.mSoldierProperty[0][1] = 1;
			this.mSoldierProperty[0][2] = 1;
			this.mSoldierProperty[0][3] = 0;
			this.mSoldierProperty[1][0] = 2;
			this.mSoldierProperty[1][1] = 2;
			this.mSoldierProperty[1][2] = 2;
			this.mSoldierProperty[1][3] = 0;
			this.mSoldierProperty[2][0] = 3;
			this.mSoldierProperty[2][1] = 3;
			this.mSoldierProperty[2][2] = 3;
			this.mSoldierProperty[2][3] = 0;
			this.mSoldierProperty[3][0] = 4;
			this.mSoldierProperty[3][1] = 4;
			this.mSoldierProperty[3][2] = 4;
			this.mSoldierProperty[3][3] = 0;
			this.mSoldierProperty[4][0] = 1;
			this.mSoldierProperty[4][1] = 1;
			this.mSoldierProperty[4][2] = 1;
			this.mSoldierProperty[4][3] = 0;
			this.mSoldierProperty[5][0] = 2;
			this.mSoldierProperty[5][1] = 2;
			this.mSoldierProperty[5][2] = 2;
			this.mSoldierProperty[5][3] = 0;
			this.mSoldierProperty[6][0] = 3;
			this.mSoldierProperty[6][1] = 3;
			this.mSoldierProperty[6][2] = 3;
			this.mSoldierProperty[6][3] = 0;
			this.mSoldierProperty[7][0] = 4;
			this.mSoldierProperty[7][1] = 4;
			this.mSoldierProperty[7][2] = 4;
			this.mSoldierProperty[7][3] = 0;
			this.mSoldierProperty[8][0] = 1;
			this.mSoldierProperty[8][1] = 1;
			this.mSoldierProperty[8][2] = 1;
			this.mSoldierProperty[8][3] = 0;
			this.mSoldierProperty[9][0] = 2;
			this.mSoldierProperty[9][1] = 2;
			this.mSoldierProperty[9][2] = 2;
			this.mSoldierProperty[9][3] = 0;
			this.mSoldierProperty[10][0] = 3;
			this.mSoldierProperty[10][1] = 3;
			this.mSoldierProperty[10][2] = 3;
			this.mSoldierProperty[10][3] = 0;
			this.mSoldierProperty[11][0] = 4;
			this.mSoldierProperty[11][1] = 4;
			this.mSoldierProperty[11][2] = 4;
			this.mSoldierProperty[11][3] = 0;
		}
		this.StrId[0] = 3845;
		if (this.mType == 0 && this.RD_Kind != 3)
		{
			this.StrId[1] = 3847;
		}
		else
		{
			this.StrId[1] = 8531;
		}
		this.StrId[2] = 3846;
		this.StrId[3] = 3848;
		byte buildNumByID = this.GUIM.BuildingData.GetBuildNumByID(6);
		this.BarrackMax = 0u;
		uint effectBaseVal2;
		int num;
		if (this.mType == 0)
		{
			this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY);
			uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY_PERCENT);
			this.BarrackMax = this.BarrackMax * (10000u + effectBaseVal) / 10000u;
			effectBaseVal2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED);
			num = (int)((this.RD_Rank - 1) * 4 + this.RD_Kind);
			uint num2 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM)(79 + num));
			if (num2 >= 9900u)
			{
				num2 = 9900u;
			}
			this.tmpEGA_Cost = 1f - num2 / 10000f;
		}
		else
		{
			this.mBD = this.GUIM.BuildingData.GetBuildData(12, 0);
			this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData(12, this.mBD.Level);
			uint num3 = 0u;
			if (this.DM.queueBarData[14].bActive)
			{
				num3 += this.DM.TrapTrainingQty;
			}
			if (this.DM.queueBarData[15].bActive)
			{
				num3 += this.DM.Trap_TreatmentQuantity;
			}
			this.BarrackMax = this.mBR.Value1 - this.DM.TrapTotal - num3;
			effectBaseVal2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_TRAINING_SPEED);
		}
		float num4 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED_DEBUFF);
		float num5 = 10000u + effectBaseVal2 - num4;
		if (num5 <= 100f)
		{
			num5 = 100f;
		}
		this.tmpEGA = 10000f / num5;
		if (this.tmpSD.Science != 0 && this.DM.GetTechLevel(this.tmpSD.Science) == 0)
		{
			this.bRDOutput = false;
		}
		this.UnitMax = this.CheckMax(this.BarrackMax);
		this.GameT = base.gameObject.transform;
		this.spArray = this.GameT.GetComponent<UISpritesArray>();
		this.Tmp = this.GameT.GetChild(0);
		this.Bg1 = this.Tmp.GetComponent<Image>();
		this.Bg1.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_04");
		this.Bg1.material = material;
		this.Tmp1 = this.Tmp.GetChild(0);
		this.Bg_T[0] = this.Tmp1.GetComponent<Image>();
		this.Bg_T[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_10");
		this.Bg_T[0].material = material;
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.Bg_T[2] = this.Tmp2.GetComponent<Image>();
		this.Bg_T[2].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_12");
		this.Bg_T[2].material = material;
		this.Tmp2 = this.Tmp1.GetChild(1);
		this.Bg_T[3] = this.Tmp2.GetComponent<Image>();
		this.Bg_T[3].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_12");
		this.Bg_T[3].material = material;
		this.Tmp2 = this.Tmp1.GetChild(2);
		this.text_Arms[1] = this.Tmp2.GetComponent<UIText>();
		this.text_Arms[1].font = this.TTFont;
		this.text_Arms[1].text = this.DM.mStringTable.GetStringByID(3838u);
		this.Tmp2 = this.Tmp1.GetChild(3);
		this.text_Arms[2] = this.Tmp2.GetComponent<UIText>();
		this.text_Arms[2].font = this.TTFont;
		this.text_Arms[2].text = this.DM.mStringTable.GetStringByID(this.mSoldierArms[0]);
		this.Tmp2 = this.Tmp1.GetChild(4);
		this.text_Arms[3] = this.Tmp2.GetComponent<UIText>();
		this.text_Arms[3].font = this.TTFont;
		this.text_Arms[3].text = this.DM.mStringTable.GetStringByID(3839u);
		this.Tmp2 = this.Tmp1.GetChild(5);
		this.text_Arms[4] = this.Tmp2.GetComponent<UIText>();
		this.text_Arms[4].font = this.TTFont;
		this.text_Arms[4].text = this.DM.mStringTable.GetStringByID(this.mSoldierArms[1]);
		this.Tmp2 = this.Tmp1.GetChild(6);
		this.text_Arms[5] = this.Tmp2.GetComponent<UIText>();
		this.text_Arms[5].font = this.TTFont;
		this.text_Arms[5].text = this.DM.mStringTable.GetStringByID(3840u);
		this.Tmp2 = this.Tmp1.GetChild(7);
		this.text_Arms[6] = this.Tmp2.GetComponent<UIText>();
		this.text_Arms[6].font = this.TTFont;
		this.text_Arms[6].text = this.DM.mStringTable.GetStringByID(this.mSoldierArms[2]);
		this.Tmp2 = this.Tmp1.GetChild(8);
		this.text_Arms[0] = this.Tmp2.GetComponent<UIText>();
		this.text_Arms[0].font = this.TTFont;
		this.text_Arms[0].text = this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name);
		this.Tmp2 = this.Tmp1.GetChild(9).GetChild(0);
		this.Img_Icon1 = this.Tmp2.GetComponent<Image>();
		this.Img_Icon1.sprite = this.spArray.m_Sprites[(int)(4 + this.RD_Kind)];
		this.Img_Icon1.gameObject.SetActive(true);
		this.Tmp2 = this.Tmp1.GetChild(9).GetChild(1);
		this.btn_Hint_Info = this.Tmp2.GetComponent<UIButton>();
		RectTransform component = this.Tmp2.GetComponent<RectTransform>();
		this.btn_Hint_Info.m_Handler = this;
		this.btn_Hint_Info.m_BtnID1 = 15;
		this.btn_Hint_Info.gameObject.SetActive(true);
		if (this.text_Arms[2].preferredWidth + 36f < 250f)
		{
			this.text_Arms[2].rectTransform.sizeDelta = new Vector2(this.text_Arms[2].preferredWidth + 1f, this.text_Arms[2].rectTransform.sizeDelta.y);
			float num6 = (this.text_Arms[2].preferredWidth + 36f) / 2f;
			this.text_Arms[2].rectTransform.anchoredPosition = new Vector2(-259.5f + num6 - (this.text_Arms[2].preferredWidth + 1f) / 2f, this.text_Arms[2].rectTransform.anchoredPosition.y);
			this.Img_Icon1.rectTransform.anchoredPosition = new Vector2(-(num6 - 16.5f), this.Img_Icon1.rectTransform.anchoredPosition.y);
			component.sizeDelta = new Vector2(this.text_Arms[2].preferredWidth + 36f, component.sizeDelta.y);
		}
		else
		{
			this.text_Arms[2].rectTransform.sizeDelta = new Vector2(215f, this.text_Arms[2].rectTransform.sizeDelta.y);
			float num6 = 125f;
			this.text_Arms[2].rectTransform.anchoredPosition = new Vector2(-259.5f + num6 - 107.5f, this.text_Arms[2].rectTransform.anchoredPosition.y);
			this.Img_Icon1.rectTransform.anchoredPosition = new Vector2(-(num6 - 16.5f), this.Img_Icon1.rectTransform.anchoredPosition.y);
			component.sizeDelta = new Vector2(250f, component.sizeDelta.y);
		}
		this.Tmp2 = this.Tmp1.GetChild(10).GetChild(0);
		this.Img_Icon2[0] = this.Tmp2.GetComponent<Image>();
		this.tmpbtnHint = this.Img_Icon2[0].gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.tmpbtnHint.m_Handler = this;
		this.tmpbtnHint.Parm1 = 1;
		this.Tmp2 = this.Tmp1.GetChild(10).GetChild(1);
		this.Img_Icon2[1] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(10).GetChild(2);
		this.Img_Icon2[2] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(10).GetChild(3);
		this.Img_Icon2[3] = this.Tmp2.GetComponent<Image>();
		if (this.mType == 0)
		{
			if (this.RD_Kind < 2)
			{
				this.Img_Icon2[0].sprite = this.spArray.m_Sprites[(int)(5 + this.RD_Kind)];
				this.tmpbtnHint.Parm2 = this.RD_ID + 4;
			}
			else if (this.RD_Kind == 2)
			{
				this.Img_Icon2[0].sprite = this.spArray.m_Sprites[4];
				this.tmpbtnHint.Parm2 = this.RD_ID - 8;
			}
			else
			{
				this.Img_Icon2[0].sprite = this.spArray.m_Sprites[11];
				this.tmpbtnHint.Parm2 = 29;
			}
			if (this.RD_Kind != 3)
			{
				this.Img_Icon2[1].sprite = this.spArray.m_Sprites[7];
				this.tmpbtnHint = this.Img_Icon2[1].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 1;
				this.tmpbtnHint.Parm2 = 13;
			}
			else
			{
				this.Img_Icon2[1].sprite = this.spArray.m_Sprites[8];
				this.tmpbtnHint = this.Img_Icon2[1].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 1;
				this.tmpbtnHint.Parm2 = 17;
				this.Img_Icon2[2].sprite = this.spArray.m_Sprites[9];
				this.tmpbtnHint = this.Img_Icon2[2].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 1;
				this.tmpbtnHint.Parm2 = 21;
				this.Img_Icon2[3].sprite = this.spArray.m_Sprites[10];
				this.tmpbtnHint = this.Img_Icon2[3].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 1;
				this.tmpbtnHint.Parm2 = 25;
			}
		}
		else if (this.RD_Kind == 4)
		{
			this.Img_Icon2[0].sprite = this.spArray.m_Sprites[6];
			this.tmpbtnHint.Parm2 = 9;
		}
		else if (this.RD_Kind == 5)
		{
			this.Img_Icon2[0].sprite = this.spArray.m_Sprites[5];
			this.tmpbtnHint.Parm2 = 5;
		}
		else
		{
			this.Img_Icon2[0].sprite = this.spArray.m_Sprites[4];
			this.tmpbtnHint.Parm2 = 1;
		}
		this.Img_Icon2[0].gameObject.SetActive(true);
		this.text_Arms[4].gameObject.SetActive(false);
		if (this.RD_Kind < 3)
		{
			this.Img_Icon2[1].gameObject.SetActive(true);
			this.Img_Icon2[0].rectTransform.anchoredPosition = new Vector2(-16.5f, this.Img_Icon2[0].rectTransform.anchoredPosition.y);
			this.Img_Icon2[1].rectTransform.anchoredPosition = new Vector2(16.5f, this.Img_Icon2[1].rectTransform.anchoredPosition.y);
		}
		else
		{
			this.Img_Icon2[1].gameObject.SetActive(false);
			this.Img_Icon2[2].gameObject.SetActive(false);
			this.Img_Icon2[3].gameObject.SetActive(false);
			if (this.RD_Kind == 3)
			{
				this.Img_Icon2[0].rectTransform.anchoredPosition = new Vector2(-50.5f, this.Img_Icon2[0].rectTransform.anchoredPosition.y);
				this.Img_Icon2[0].rectTransform.sizeDelta = new Vector2(34f, 34f);
				this.Img_Icon2[1].rectTransform.anchoredPosition = new Vector2(-16.5f, this.Img_Icon2[1].rectTransform.anchoredPosition.y);
				this.Img_Icon2[2].rectTransform.anchoredPosition = new Vector2(16.5f, this.Img_Icon2[2].rectTransform.anchoredPosition.y);
				this.Img_Icon2[3].rectTransform.anchoredPosition = new Vector2(49.5f, this.Img_Icon2[3].rectTransform.anchoredPosition.y);
				this.Img_Icon2[1].gameObject.SetActive(true);
				this.Img_Icon2[2].gameObject.SetActive(true);
				this.Img_Icon2[3].gameObject.SetActive(true);
			}
			else
			{
				this.Img_Icon2[0].rectTransform.anchoredPosition = new Vector2(0f, this.Img_Icon2[0].rectTransform.anchoredPosition.y);
				this.Img_Icon2[0].SetNativeSize();
			}
		}
		this.Tmp2 = this.Tmp1.GetChild(11).GetChild(0);
		this.Img_Icon3[0] = this.Tmp2.GetComponent<Image>();
		this.tmpbtnHint = this.Img_Icon3[0].gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.tmpbtnHint.m_Handler = this;
		this.tmpbtnHint.Parm1 = 1;
		this.Tmp2 = this.Tmp1.GetChild(11).GetChild(1);
		this.Img_Icon3[1] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(11).GetChild(2);
		this.Img_Icon3[2] = this.Tmp2.GetComponent<Image>();
		if (this.mType == 0)
		{
			if (this.RD_Kind < 3)
			{
				if (this.RD_Kind == 0)
				{
					this.Img_Icon3[0].sprite = this.spArray.m_Sprites[6];
					this.tmpbtnHint.Parm2 = 9;
					this.Img_Icon3[1].sprite = this.spArray.m_Sprites[10];
					this.tmpbtnHint = this.Img_Icon3[1].gameObject.AddComponent<UIButtonHint>();
					this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
					this.tmpbtnHint.m_Handler = this;
					this.tmpbtnHint.Parm1 = 1;
					this.tmpbtnHint.Parm2 = 25;
				}
				else if (this.RD_Kind == 1)
				{
					this.Img_Icon3[0].sprite = this.spArray.m_Sprites[4];
					this.tmpbtnHint.Parm2 = 1;
					this.Img_Icon3[1].sprite = this.spArray.m_Sprites[9];
					this.tmpbtnHint = this.Img_Icon3[1].gameObject.AddComponent<UIButtonHint>();
					this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
					this.tmpbtnHint.m_Handler = this;
					this.tmpbtnHint.Parm1 = 1;
					this.tmpbtnHint.Parm2 = 21;
				}
				else if (this.RD_Kind == 2)
				{
					this.Img_Icon3[0].sprite = this.spArray.m_Sprites[5];
					this.tmpbtnHint.Parm2 = 5;
					this.Img_Icon3[1].sprite = this.spArray.m_Sprites[8];
					this.tmpbtnHint = this.Img_Icon3[1].gameObject.AddComponent<UIButtonHint>();
					this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
					this.tmpbtnHint.m_Handler = this;
					this.tmpbtnHint.Parm1 = 1;
					this.tmpbtnHint.Parm2 = 17;
				}
				this.Img_Icon3[2].sprite = this.spArray.m_Sprites[11];
				this.tmpbtnHint = this.Img_Icon3[2].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 1;
				this.tmpbtnHint.Parm2 = 29;
			}
			else
			{
				this.Img_Icon3[0].sprite = this.spArray.m_Sprites[4];
				this.tmpbtnHint.Parm2 = 1;
				this.Img_Icon3[1].sprite = this.spArray.m_Sprites[5];
				this.tmpbtnHint = this.Img_Icon3[1].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 1;
				this.tmpbtnHint.Parm2 = 5;
				this.Img_Icon3[2].sprite = this.spArray.m_Sprites[6];
				this.tmpbtnHint = this.Img_Icon3[2].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 1;
				this.tmpbtnHint.Parm2 = 9;
			}
		}
		else
		{
			if (this.RD_Kind == 5)
			{
				this.Img_Icon3[0].sprite = this.spArray.m_Sprites[7];
			}
			else if (this.RD_Kind == 6)
			{
				this.Img_Icon3[0].sprite = this.spArray.m_Sprites[7];
			}
			else
			{
				this.Img_Icon3[0].sprite = this.spArray.m_Sprites[7];
			}
			this.tmpbtnHint.Parm2 = 13;
		}
		this.Img_Icon3[0].gameObject.SetActive(true);
		this.text_Arms[6].gameObject.SetActive(false);
		if (this.mType == 0)
		{
			this.Img_Icon3[1].gameObject.SetActive(true);
			this.Img_Icon3[2].gameObject.SetActive(true);
			this.Img_Icon3[0].rectTransform.anchoredPosition = new Vector2(-33f, this.Img_Icon3[0].rectTransform.anchoredPosition.y);
			if (this.RD_Kind != 3)
			{
				this.Img_Icon3[2].rectTransform.anchoredPosition = new Vector2(34f, this.Img_Icon3[2].rectTransform.anchoredPosition.y);
				this.Img_Icon3[2].rectTransform.sizeDelta = new Vector2(34f, 34f);
			}
			else
			{
				this.Img_Icon3[2].rectTransform.anchoredPosition = new Vector2(33f, this.Img_Icon3[2].rectTransform.anchoredPosition.y);
				this.Img_Icon3[2].SetNativeSize();
			}
		}
		else
		{
			this.Img_Icon3[1].gameObject.SetActive(false);
			this.Img_Icon3[2].gameObject.SetActive(false);
			this.Img_Icon3[0].rectTransform.anchoredPosition = new Vector2(0f, this.Img_Icon3[0].rectTransform.anchoredPosition.y);
		}
		this.Tmp2 = this.Tmp1.GetChild(12);
		this.Img_ArmyHint = this.Tmp2.GetComponent<Image>();
		if (this.mType == 0)
		{
			this.Img_ArmyHint.sprite = this.door.LoadSprite("UI_EO_icon_01");
		}
		else
		{
			this.Img_ArmyHint.sprite = this.door.LoadSprite("UI_EO_icon_02");
		}
		this.Img_ArmyHint.material = this.door.LoadMaterial();
		this.tmpbtnHint = this.Img_ArmyHint.gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.tmpbtnHint.m_Handler = this;
		this.tmpbtnHint.Parm1 = 2;
		this.Img_ArmyHint.gameObject.SetActive(true);
		this.Tmp1 = this.Tmp.GetChild(1);
		this.Property[0] = this.Tmp1.GetComponent<Image>();
		this.Property[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_27");
		MaskableGraphic maskableGraphic = this.Property[0];
		Material material4 = material;
		this.Bg_T[3].material = material4;
		maskableGraphic.material = material4;
		int num7;
		if (this.mType == 0)
		{
			num7 = (int)this.mSoldierProperty[(int)(this.tmpSD.SoldierKey - 1)][0];
		}
		else
		{
			num7 = (int)this.mSoldierProperty[(int)(this.tmpSD.SoldierKey - 17)][0];
		}
		for (int j = 0; j < num7; j++)
		{
			this.Tmp2 = this.Tmp1.GetChild(j);
			this.Property[j + 1] = this.Tmp2.GetComponent<Image>();
			this.Property[j + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_06");
			MaskableGraphic maskableGraphic2 = this.Property[j + 1];
			material4 = material;
			this.Bg_T[3].material = material4;
			maskableGraphic2.material = material4;
		}
		for (int k = num7; k < 4; k++)
		{
			this.Tmp2 = this.Tmp1.GetChild(k);
			this.Property[k + 1] = this.Tmp2.GetComponent<Image>();
			this.Property[k + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_07");
			this.Property[k + 1].material = material;
		}
		this.Tmp1 = this.Tmp.GetChild(2);
		this.Property1[0] = this.Tmp1.GetComponent<Image>();
		this.Property1[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_27");
		this.Property1[0].material = material;
		if (this.mType == 0)
		{
			num7 = (int)this.mSoldierProperty[(int)(this.tmpSD.SoldierKey - 1)][1];
		}
		else
		{
			num7 = (int)this.mSoldierProperty[(int)(this.tmpSD.SoldierKey - 17)][1];
		}
		for (int l = 0; l < num7; l++)
		{
			this.Tmp2 = this.Tmp1.GetChild(l);
			this.Property1[l + 1] = this.Tmp2.GetComponent<Image>();
			this.Property1[l + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_06");
			this.Property1[l + 1].material = material;
		}
		for (int m = num7; m < 4; m++)
		{
			this.Tmp2 = this.Tmp1.GetChild(m);
			this.Property1[m + 1] = this.Tmp2.GetComponent<Image>();
			this.Property1[m + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_07");
			this.Property1[m + 1].material = material;
		}
		this.Tmp1 = this.Tmp.GetChild(3);
		this.Property2[0] = this.Tmp1.GetComponent<Image>();
		this.Property2[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_27");
		this.Property2[0].material = material;
		if (this.mType == 0)
		{
			num7 = (int)this.mSoldierProperty[(int)(this.tmpSD.SoldierKey - 1)][2];
		}
		else
		{
			num7 = (int)this.mSoldierProperty[(int)(this.tmpSD.SoldierKey - 17)][2];
		}
		for (int n = 0; n < num7; n++)
		{
			this.Tmp2 = this.Tmp1.GetChild(n);
			this.Property2[n + 1] = this.Tmp2.GetComponent<Image>();
			this.Property2[n + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_06");
			this.Property2[n + 1].material = material;
		}
		for (int num8 = num7; num8 < 4; num8++)
		{
			this.Tmp2 = this.Tmp1.GetChild(num8);
			this.Property2[num8 + 1] = this.Tmp2.GetComponent<Image>();
			this.Property2[num8 + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_07");
			this.Property2[num8 + 1].material = material;
		}
		this.Tmp1 = this.Tmp.GetChild(4);
		this.Property3[0] = this.Tmp1.GetComponent<Image>();
		this.Property3[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_27");
		this.Property3[0].material = material;
		if (this.mType == 0)
		{
			num7 = (int)this.mSoldierProperty[(int)(this.tmpSD.SoldierKey - 1)][3];
		}
		else
		{
			num7 = (int)this.mSoldierProperty[(int)(this.tmpSD.SoldierKey - 17)][3];
		}
		for (int num9 = 0; num9 < num7; num9++)
		{
			this.Tmp2 = this.Tmp1.GetChild(num9);
			this.Property3[num9 + 1] = this.Tmp2.GetComponent<Image>();
			this.Property3[num9 + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_06");
			this.Property3[num9 + 1].material = material;
		}
		for (int num10 = num7; num10 < 4; num10++)
		{
			this.Tmp2 = this.Tmp1.GetChild(num10);
			this.Property3[num10 + 1] = this.Tmp2.GetComponent<Image>();
			this.Property3[num10 + 1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_icon_07");
			this.Property3[num10 + 1].material = material;
		}
		this.Tmp1 = this.Tmp.GetChild(5);
		this.Img_Soldier[0] = this.Tmp1.GetComponent<Image>();
		this.tmpString.Length = 0;
		this.tmpString.AppendFormat("q{0}", this.tmpSD.Icon);
		this.Img_Soldier[0].sprite = this.GUIM.LoadSprite(this.AssetName1, this.tmpString.ToString());
		this.Img_Soldier[0].material = material3;
		this.Tmp2 = this.Tmp1.GetChild(0);
		Image component2 = this.Tmp2.GetComponent<Image>();
		component2.sprite = this.GUIM.LoadSprite(this.AssetName1, this.tmpString.ToString());
		component2.material = material3;
		if (this.GUIM.IsArabic)
		{
			component2.transform.localScale = new Vector3(-1f, component2.transform.localScale.y, component2.transform.localScale.z);
		}
		this.Tmp2 = this.Tmp1.GetChild(1);
		this.Img_Soldier[2] = this.Tmp2.GetComponent<Image>();
		this.Img_Soldier[2].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_20");
		this.Img_Soldier[2].material = material;
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.text_SoldierNum = this.Tmp3.GetComponent<UIText>();
		this.text_SoldierNum.font = this.TTFont;
		if (this.mType == 0)
		{
			this.tmpString.Length = 0;
			GameConstants.FormatValue(this.tmpString, this.DM.RoleAttr.m_Soldier[(int)(this.RD_ID - 1)]);
		}
		else
		{
			this.tmpString.Length = 0;
			GameConstants.FormatValue(this.tmpString, this.DM.mTrapQty[(int)(this.RD_ID - 17)]);
		}
		this.text_SoldierNum.text = this.tmpString.ToString();
		this.Tmp2 = this.Tmp1.GetChild(2);
		this.Img_Soldier[4] = this.Tmp2.GetComponent<Image>();
		this.Img_Soldier[4].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_13");
		this.Img_Soldier[4].material = material;
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.text_Disband[0] = this.Tmp3.GetComponent<UIText>();
		this.text_Disband[0].font = this.TTFont;
		this.tmpString.Length = 0;
		this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3875u), this.UnitSoldier[0]);
		this.text_Disband[0].text = this.tmpString.ToString();
		if (this.mType == 1)
		{
			this.Img_Soldier[4].gameObject.SetActive(false);
		}
		this.Tmp2 = this.Tmp1.GetChild(3);
		this.Img_Soldier[5] = this.Tmp2.GetComponent<Image>();
		this.Img_Soldier[5].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_13");
		this.Img_Soldier[5].material = material;
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.text_Disband[1] = this.Tmp3.GetComponent<UIText>();
		this.text_Disband[1].font = this.TTFont;
		this.tmpString.Length = 0;
		if (this.mType == 0)
		{
			this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3874u), this.UnitSoldier[1]);
		}
		else
		{
			this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3875u), this.UnitSoldier[0]);
		}
		this.text_Disband[1].text = this.tmpString.ToString();
		this.Tmp2 = this.Tmp1.GetChild(4);
		this.Img_Soldier[6] = this.Tmp2.GetComponent<Image>();
		this.Img_Soldier[6].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_13");
		this.Img_Soldier[6].material = material;
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.text_Disband[2] = this.Tmp3.GetComponent<UIText>();
		this.text_Disband[2].font = this.TTFont;
		this.tmpString.Length = 0;
		this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3876u), this.UnitSoldier[2]);
		this.text_Disband[2].text = this.tmpString.ToString();
		if (this.mType == 1)
		{
			this.Img_Soldier[6].gameObject.SetActive(false);
		}
		this.Tmp2 = this.Tmp1.GetChild(5);
		this.btn_Disband = this.Tmp2.GetComponent<UIButton>();
		this.btn_Disband.image.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_butt_07");
		this.btn_Disband.image.material = material;
		this.btn_Disband.m_Handler = this;
		this.btn_Disband.m_BtnID1 = 1;
		this.btn_Disband.m_EffectType = e_EffectType.e_Scale;
		this.btn_Disband.transition = Selectable.Transition.None;
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.text_Disband[3] = this.Tmp3.GetComponent<UIText>();
		this.text_Disband[3].font = this.TTFont;
		this.btn_Disband.m_Text = this.text_Disband[3];
		if (this.mType == 0)
		{
			this.text_Disband[3].text = this.DM.mStringTable.GetStringByID(3877u);
			if (this.DM.RoleAttr.m_Soldier[(int)(this.RD_ID - 1)] == 0u)
			{
				this.btn_Disband.ForTextChange(e_BtnType.e_ChangeText);
			}
			else
			{
				this.btn_Disband.ForTextChange(e_BtnType.e_Normal);
			}
		}
		else
		{
			this.text_Disband[3].text = this.DM.mStringTable.GetStringByID(3772u);
			if (this.DM.mTrapQty[(int)(this.RD_ID - 17)] == 0u)
			{
				this.btn_Disband.ForTextChange(e_BtnType.e_ChangeText);
			}
			else
			{
				this.btn_Disband.ForTextChange(e_BtnType.e_Normal);
			}
		}
		this.Tmp1 = this.Tmp.GetChild(6);
		this.Bg2 = this.Tmp1.GetComponent<Image>();
		this.Bg2.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_19");
		this.Bg2.material = material;
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_Title = this.Tmp2.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		if (this.mType == 0)
		{
			this.text_Title.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.NameID);
		}
		else
		{
			this.text_Title.text = this.DM.mStringTable.GetStringByID(3748u);
		}
		for (int num11 = 0; num11 < 4; num11++)
		{
			cstring.ClearString();
			cstring.IntToFormat((long)(num11 + 1), 1, false);
			cstring.AppendFormat("UI_con_icons_0{0}");
			this.Tmp1 = this.Tmp.GetChild(7 + num11);
			this.btn_Hint[num11] = this.Tmp1.GetComponent<UIButton>();
			this.btn_Hint[num11].m_Handler = this;
			this.btn_Hint[num11].m_BtnID1 = 7 + num11;
			this.btn_Hint[num11].image.sprite = this.GUIM.LoadSprite("BuildingWindow", cstring);
			this.btn_Hint[num11].image.material = material;
			this.tmpbtnHint = this.btn_Hint[num11].gameObject.AddComponent<UIButtonHint>();
			this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
			this.tmpbtnHint.m_Handler = this;
			this.tmpbtnHint.Parm1 = 0;
			this.Img_Hint[num11] = this.Tmp1.GetChild(0).GetComponent<Image>();
			this.tmpbtnHint.ControlFadeOut = this.Img_Hint[num11].gameObject;
			this.Img_Hint[num11].sprite = this.door.LoadSprite("UI_main_box_012");
			this.Img_Hint[num11].material = material2;
			this.text_Hint[num11] = this.Tmp1.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.text_Hint[num11].font = this.TTFont;
			this.text_Hint[num11].text = this.DM.mStringTable.GetStringByID((uint)this.StrId[num11]);
			component = this.Img_Hint[num11].transform.GetComponent<RectTransform>();
			RectTransform component3 = this.text_Hint[num11].transform.GetComponent<RectTransform>();
			float num12 = Mathf.Clamp(this.text_Hint[num11].preferredWidth, 0f, component3.sizeDelta.x);
			component.sizeDelta = new Vector2(num12 + 20f, component.sizeDelta.y);
			component = this.text_Hint[num11].transform.GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(num12 + 20f, component.sizeDelta.y);
		}
		this.Tmp1 = this.Tmp.GetChild(11);
		component2 = this.Tmp1.GetComponent<Image>();
		component2.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_divider_02");
		component2.material = material;
		this.Tmp = this.GameT.GetChild(1);
		this.Training_BG = this.Tmp.GetComponent<Image>();
		this.Training_BG.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_04");
		this.Training_BG.material = material;
		this.Img_LockBG = this.Tmp.GetChild(0).GetComponent<Image>();
		this.Img_Lock = this.Tmp.GetChild(3).GetComponent<Image>();
		this.btn_Lock = this.Tmp.GetChild(4).GetComponent<UIButton>();
		this.btn_Lock.m_Handler = this;
		this.btn_Lock.m_BtnID1 = 13;
		this.btn_Lock.m_EffectType = e_EffectType.e_Scale;
		this.btn_Lock.transition = Selectable.Transition.None;
		this.LockPanel = this.Tmp.GetChild(5);
		UIButton component4 = this.LockPanel.GetChild(0).GetComponent<UIButton>();
		component4.m_Handler = this;
		component4.m_BtnID1 = 14;
		component4 = this.LockPanel.GetChild(1).GetComponent<UIButton>();
		component4.m_Handler = this;
		component4.m_BtnID1 = 14;
		this.Tmp1 = this.Tmp.GetChild(1);
		this.Tf1 = this.Tmp1.GetComponent<Transform>();
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.Img_Resources = this.Tmp2.GetComponent<Image>();
		this.Img_Resources.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_28");
		this.Img_Resources.material = material;
		this.Tmp2 = this.Tmp1.GetChild(1);
		this.m_DResources = this.Tmp2.GetComponent<DemandResources>();
		this.GUIM.InitDemandResources(this.Tmp2, 555f, 111f, true);
		this.Tmp2 = this.Tmp1.GetChild(2);
		this.m_UnitRS = this.Tmp2.GetComponent<UnitResourcesSlider>();
		this.GUIM.InitUnitResourcesSlider(this.Tmp2, eUnitSlider.Barrack, 0u, this.BarrackMax, 0.7f);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.BtnIncrease, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_01"), material);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.BtnLessen, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_02"), material);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.Input, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_05"), material);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_sliderBG1, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_03"), material);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_sliderBG2, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_04"), material);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_Img, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_06"), material);
		this.m_UnitRS.BtnInputText.m_Handler = this;
		this.m_UnitRS.BtnInputText.m_BtnID1 = 11;
		if (this.mType == 1)
		{
			this.GUIM.SetUnitResourcesSliderImg(this.Tmp2, eUnitSliderSize.m_micon, this.GUIM.LoadSprite("BuildingWindow", "UI_wall_trap_01"), material);
		}
		this.m_UnitRS.m_Handler = this;
		this.m_UnitRS.m_ID = 1;
		this.Tmp2 = this.Tmp1.GetChild(3);
		this.Img_TrainingCompleted[0] = this.Tmp2.GetComponent<Image>();
		this.Img_TrainingCompleted[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_16");
		this.Img_TrainingCompleted[0].material = material;
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.Img_TrainingCompleted[1] = this.Tmp3.GetComponent<Image>();
		this.Img_TrainingCompleted[1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_17");
		this.Img_TrainingCompleted[1].material = material;
		this.Tmp3 = this.Tmp2.GetChild(1);
		this.Img_TrainingCompleted[2] = this.Tmp3.GetComponent<Image>();
		this.Img_TrainingCompleted[2].sprite = this.door.LoadSprite("UI_main_money_02");
		this.Img_TrainingCompleted[2].material = material2;
		this.Img_TrainingCompleted[2].SetNativeSize();
		this.Tmp3 = this.Tmp2.GetChild(2);
		this.text_Gemstone = this.Tmp3.GetComponent<UIText>();
		this.text_Gemstone.font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(4);
		this.Img_Training[0] = this.Tmp2.GetComponent<Image>();
		this.Img_Training[0].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_16");
		this.Img_Training[0].material = material;
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.Img_TrainingCompleted[1] = this.Tmp3.GetComponent<Image>();
		this.Img_TrainingCompleted[1].sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_17");
		this.Img_TrainingCompleted[1].material = material;
		this.Tmp3 = this.Tmp2.GetChild(1);
		this.text_Time = this.Tmp3.GetComponent<UIText>();
		this.text_Time.font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(5);
		this.btn_TrainingCompleted = this.Tmp2.GetComponent<UIButton>();
		this.btn_TrainingCompleted.image.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_butt_07");
		this.btn_TrainingCompleted.image.material = material;
		this.btn_TrainingCompleted.m_Handler = this;
		this.btn_TrainingCompleted.m_BtnID1 = 3;
		this.btn_TrainingCompleted.m_EffectType = e_EffectType.e_Scale;
		this.btn_TrainingCompleted.transition = Selectable.Transition.None;
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.text_TrainingCompleted = this.Tmp3.GetComponent<UIText>();
		this.text_TrainingCompleted.font = this.TTFont;
		if (this.mType == 0)
		{
			this.text_TrainingCompleted.text = this.DM.mStringTable.GetStringByID(3851u);
		}
		else
		{
			this.text_TrainingCompleted.text = this.DM.mStringTable.GetStringByID(3773u);
		}
		this.btn_TrainingCompleted.m_Text = this.text_TrainingCompleted;
		this.Tmp2 = this.Tmp1.GetChild(6);
		this.btn_Training = this.Tmp2.GetComponent<UIButton>();
		this.btn_Training.image.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_butt_07");
		this.btn_Training.image.material = material;
		this.btn_Training.m_Handler = this;
		this.btn_Training.m_BtnID1 = 2;
		this.btn_Training.m_EffectType = e_EffectType.e_Scale;
		this.btn_Training.transition = Selectable.Transition.None;
		this.Img_SoldierArrow = this.Tmp2.GetChild(0).GetComponent<Image>();
		this.Tmp3 = this.Tmp2.GetChild(1);
		this.text_Training = this.Tmp3.GetComponent<UIText>();
		this.text_Training.font = this.TTFont;
		if (this.mType == 0)
		{
			this.text_Training.text = this.DM.mStringTable.GetStringByID(3850u);
		}
		else
		{
			this.text_Training.text = this.DM.mStringTable.GetStringByID(3774u);
		}
		this.btn_Training.m_Text = this.text_Training;
		this.Tmp1 = this.Tmp.GetChild(2);
		this.Tf2 = this.Tmp1.GetComponent<Transform>();
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.Img_RDLock = this.Tmp2.GetComponent<Image>();
		this.Img_RDLock.sprite = this.door.LoadSprite("UI_main_lock");
		this.Img_RDLock.material = material2;
		this.Img_RDLock.SetNativeSize();
		this.Tmp2 = this.Tmp1.GetChild(1);
		this.btn_RD = this.Tmp2.GetComponent<UIButton>();
		this.btn_RD.image.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_butt_07");
		this.btn_RD.image.material = material;
		this.btn_RD.m_Handler = this;
		this.btn_RD.m_BtnID1 = 4;
		this.btn_RD.m_EffectType = e_EffectType.e_Scale;
		this.btn_RD.transition = Selectable.Transition.None;
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.text_RDbtn = this.Tmp3.GetComponent<UIText>();
		this.text_RDbtn.font = this.TTFont;
		this.text_RDbtn.text = this.DM.mStringTable.GetStringByID(3849u);
		this.Tmp2 = this.Tmp1.GetChild(2);
		this.text_RD = this.Tmp2.GetComponent<UIText>();
		this.text_RD.font = this.TTFont;
		this.tmpString.Length = 0;
		if (this.mType == 0)
		{
			this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3858u), this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
		}
		else
		{
			this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3775u), this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
		}
		this.text_RD.text = this.tmpString.ToString();
		this.Tmp = this.GameT.GetChild(2);
		this.Img_EXIT = this.Tmp.GetComponent<Image>();
		this.Img_EXIT.sprite = this.door.LoadSprite("UI_main_close_base");
		this.Img_EXIT.material = material2;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Img_EXIT.enabled = false;
		}
		this.Tmp = this.GameT.GetChild(2).GetChild(0);
		this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = material2;
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.Tmp = this.GameT.GetChild(3);
		this.ImgDisbandblack = this.Tmp.GetComponent<Image>();
		this.ImgDisbandblack.sprite = this.door.LoadSprite("UI_main_black");
		this.ImgDisbandblack.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.ImgDisbandblack.rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.ImgDisbandblack.rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		HelperUIButton helperUIButton = this.ImgDisbandblack.gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID1 = 5;
		this.Tmp1 = this.Tmp.GetChild(0);
		component2 = this.Tmp1.GetComponent<Image>();
		component2.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_29");
		component2.material = material;
		this.Tmp2 = this.Tmp1.GetChild(0);
		component2 = this.Tmp2.GetComponent<Image>();
		component2.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_title_orange");
		component2.material = material;
		this.Tmp3 = this.Tmp2.GetChild(0);
		this.text_Disband_Title = this.Tmp3.GetComponent<UIText>();
		this.text_Disband_Title.font = this.TTFont;
		if (this.mType == 0)
		{
			this.text_Disband_Title.text = this.DM.mStringTable.GetStringByID(4068u);
		}
		else
		{
			this.text_Disband_Title.text = this.DM.mStringTable.GetStringByID(3772u);
		}
		this.Tmp1 = this.Tmp.GetChild(1);
		component2 = this.Tmp1.GetComponent<Image>();
		component2.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_06");
		component2.material = material;
		this.Tmp1 = this.Tmp.GetChild(2);
		component2 = this.Tmp1.GetComponent<Image>();
		component2.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_13");
		component2.material = material;
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_Disband_Name = this.Tmp2.GetComponent<UIText>();
		this.text_Disband_Name.font = this.TTFont;
		this.text_Disband_Name.text = this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name);
		this.Tmp1 = this.Tmp.GetChild(3);
		this.ImgDisband_Soldier = this.Tmp1.GetComponent<Image>();
		this.tmpString.Length = 0;
		this.tmpString.AppendFormat("q{0}", this.tmpSD.Icon);
		this.ImgDisband_Soldier.sprite = this.GUIM.LoadSprite(this.AssetName1, this.tmpString.ToString());
		this.ImgDisband_Soldier.material = material3;
		if (this.GUIM.IsArabic)
		{
			this.ImgDisband_Soldier.transform.localScale = new Vector3(-1f, this.ImgDisband_Soldier.transform.localScale.y, this.ImgDisband_Soldier.transform.localScale.z);
		}
		this.Tmp1 = this.Tmp.GetChild(4);
		component2 = this.Tmp1.GetComponent<Image>();
		component2.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_20");
		component2.material = material;
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_Disband_Num = this.Tmp2.GetComponent<UIText>();
		this.text_Disband_Num.font = this.TTFont;
		this.tmpString.Length = 0;
		if (this.mType == 0)
		{
			GameConstants.FormatValue(this.tmpString, this.DM.RoleAttr.m_Soldier[(int)(this.RD_ID - 1)]);
		}
		else
		{
			GameConstants.FormatValue(this.tmpString, this.DM.mTrapQty[(int)(this.RD_ID - 17)]);
		}
		this.text_Disband_Num.text = this.tmpString.ToString();
		this.Tmp1 = this.Tmp.GetChild(5);
		this.m_DisbandSlider = this.Tmp1.GetComponent<UnitResourcesSlider>();
		this.tmpValue = 0u;
		if (this.mType == 0)
		{
			this.tmpValue = this.DM.RoleAttr.m_Soldier[(int)(this.RD_ID - 1)];
		}
		else
		{
			this.tmpValue = this.DM.mTrapQty[(int)(this.RD_ID - 17)];
		}
		this.GUIM.InitUnitResourcesSlider(this.Tmp1, eUnitSlider.Other, 0u, this.tmpValue, 0.7f);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.BtnIncrease, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_01"), material);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.BtnLessen, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_02"), material);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.Input, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_05"), material);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_sliderBG1, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_03"), material);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_sliderBG2, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_04"), material);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_Img, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_06"), material);
		this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.m_Img, 5f, 52.5f, 22f, 28f, 0f, 0f);
		this.m_DisbandSlider.BtnInputText.m_Handler = this;
		this.m_DisbandSlider.BtnInputText.m_BtnID1 = 12;
		this.m_DisbandSlider.m_Handler = this;
		this.m_DisbandSlider.m_ID = 2;
		component = this.m_DisbandSlider.m_TotalText.transform.GetComponent<RectTransform>();
		if (this.m_DisbandSlider.m_TotalText.preferredWidth > component.sizeDelta.x)
		{
			component.sizeDelta = new Vector2(this.m_DisbandSlider.m_TotalText.preferredWidth + 1f, component.sizeDelta.y);
		}
		component.anchoredPosition = new Vector2(269f, component.anchoredPosition.y);
		num = 0;
		if (this.tmpValue / 1000u > 0u)
		{
			if (this.tmpValue / 100000000u > 0u)
			{
				num = 4;
			}
			else if (this.tmpValue / 10000000u > 0u)
			{
				num = 3;
			}
			else if (this.tmpValue / 10000u > 0u)
			{
				num = 2;
			}
			else
			{
				num = 1;
			}
		}
		this.DisbandSliderRT = this.m_DisbandSlider.GetComponent<Transform>().GetChild(3).GetComponent<RectTransform>();
		this.DisbandSliderRT.anchoredPosition = new Vector2(this.Pos[num], this.DisbandSliderRT.anchoredPosition.y);
		this.DisbandSliderRT.sizeDelta = new Vector2(this.Width[num], this.DisbandSliderRT.sizeDelta.y);
		this.Tmp1 = this.Tmp.GetChild(6);
		this.btn_Soldier_Disband = this.Tmp1.GetComponent<UIButton>();
		this.btn_Soldier_Disband.m_Handler = this;
		this.btn_Soldier_Disband.m_BtnID1 = 6;
		this.btn_Soldier_Disband.image.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_butt_07");
		this.btn_Soldier_Disband.image.material = material;
		this.btn_Soldier_Disband.m_EffectType = e_EffectType.e_Scale;
		this.btn_Soldier_Disband.transition = Selectable.Transition.None;
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_tmpStr = this.Tmp2.GetComponent<UIText>();
		this.text_tmpStr.font = this.TTFont;
		if (this.mType == 0)
		{
			this.text_tmpStr.text = this.DM.mStringTable.GetStringByID(4050u);
		}
		else
		{
			this.text_tmpStr.text = this.DM.mStringTable.GetStringByID(3772u);
		}
		this.btn_Soldier_Disband.m_Text = this.text_tmpStr;
		this.Tmp1 = this.Tmp.GetChild(7);
		this.btn_Soldier_Exit = this.Tmp1.GetComponent<UIButton>();
		this.btn_Soldier_Exit.m_Handler = this;
		this.btn_Soldier_Exit.m_BtnID1 = 5;
		this.btn_Soldier_Exit.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_Soldier_Exit.image.material = material2;
		this.btn_Soldier_Exit.m_EffectType = e_EffectType.e_Scale;
		this.btn_Soldier_Exit.transition = Selectable.Transition.None;
		this.Tmp = this.GameT.GetChild(4);
		this.Img_Hint_Info = this.Tmp.GetComponent<Image>();
		this.Img_Hint_Info.sprite = this.door.LoadSprite("UI_main_box_012");
		this.Img_Hint_Info.material = material2;
		this.tmpbtnHint = this.btn_Hint_Info.gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.tmpbtnHint.m_Handler = this;
		this.tmpbtnHint.ControlFadeOut = this.Img_Hint_Info.gameObject;
		this.tmpbtnHint.Parm1 = 1;
		this.tmpbtnHint.Parm2 = this.RD_ID;
		this.text_Hint_Info = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.text_Hint_Info.font = this.TTFont;
		this.Cstr_Hint_Info.ClearString();
		if (this.mType == 0)
		{
			this.Cstr_Hint_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint)((ushort)(3841 + (int)this.RD_Kind))));
		}
		else
		{
			this.Cstr_Hint_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint)((ushort)(11154 + (int)this.RD_Kind))));
		}
		this.Cstr_Hint_Info.AppendFormat(this.DM.mStringTable.GetStringByID(11157u));
		this.text_Hint_Info.text = this.Cstr_Hint_Info.ToString();
		this.text_Hint_Info.SetAllDirty();
		this.text_Hint_Info.cachedTextGenerator.Invalidate();
		this.text_Hint_Info.cachedTextGeneratorForLayout.Invalidate();
		this.text_Hint_Info.rectTransform.sizeDelta = new Vector2(this.text_Hint_Info.rectTransform.sizeDelta.x, this.text_Hint_Info.preferredHeight + 1f);
		this.Img_Hint_Info.rectTransform.sizeDelta = new Vector2(this.Img_Hint_Info.rectTransform.sizeDelta.x, this.text_Hint_Info.preferredHeight + 21f);
		if (this.bRDOutput)
		{
			this.Tf1.gameObject.SetActive(true);
			this.Tf2.gameObject.SetActive(false);
			uint num13;
			if (this.DM.bSoldierSave && this.DM.bSetExpediton)
			{
				num13 = this.DM.tmpSoldierTrainingQty;
			}
			else
			{
				num13 = this.UnitMax;
			}
			this.DM.bSoldierSave = false;
			this.DM.bSetExpediton = false;
			uint num14 = num13;
			bool flag = NewbieManager.IsTeachWorking(ETeachKind.SPAWN_SOLDIERS);
			if (flag)
			{
				num14 = 20u;
			}
			else if (this.DM.GuideSoldierNum != 0 && (uint)this.DM.GuideSoldierNum < num13)
			{
				num14 = (uint)this.DM.GuideSoldierNum;
			}
			this.Cstr.ClearString();
			StringManager.IntToStr(this.Cstr, (long)((ulong)num14), 1, true);
			if (num13 > 0u || flag || this.GUIM.Barrack_Soldier_Lock == 1)
			{
				if (this.mType == 0)
				{
					if (this.GUIM.Barrack_Soldier_Lock == 2)
					{
						this.GUIM.Barrack_Soldier_SliderValue = (long)((ulong)num14);
					}
					else if (this.GUIM.Barrack_Soldier_Lock == 1 && this.GUIM.Barrack_Soldier_SliderValue <= (long)((ulong)this.BarrackMax))
					{
						num14 = (uint)this.GUIM.Barrack_Soldier_SliderValue;
					}
					else
					{
						this.GUIM.Barrack_Soldier_Lock = 2;
						this.GUIM.Barrack_Soldier_SliderValue = (long)((ulong)num14);
					}
				}
				this.m_UnitRS.m_slider.value = num14;
				this.m_UnitRS.Value = (long)((ulong)num14);
			}
			this.m_UnitRS.m_inputText.text = this.Cstr.ToString();
			this.m_UnitRS.m_inputText.SetAllDirty();
			this.m_UnitRS.m_inputText.cachedTextGenerator.Invalidate();
			this.SetDRformURS(this.m_UnitRS.GetComponent<Transform>(), num14);
		}
		else
		{
			this.Tf1.gameObject.SetActive(false);
			this.Tf2.gameObject.SetActive(true);
		}
		if (this.GUIM.BuildingData.GuideSoldierID != 0)
		{
			this.GUIM.BuildingData.GuideSoldierID = 0;
		}
		if (this.DM.GuideSoldierNum != 0 && !NewbieManager.IsWorking())
		{
			this.Img_SoldierArrow.gameObject.SetActive(true);
			this.DM.GuideSoldierNum = 0;
		}
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		if (this.mType == 0)
		{
			NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIERS, this, false);
			if (this.GUIM.Barrack_Soldier_Lock == 2 && !NewbieManager.IsWorking() && this.bRDOutput)
			{
				NewbieManager.CheckSpawnSoldierDetail();
			}
		}
		this.UpdateLcokBtnType();
	}

	// Token: 0x06001959 RID: 6489 RVA: 0x002AF79C File Offset: 0x002AD99C
	public uint CheckMax(uint MaxValue)
	{
		uint[] array = new uint[5];
		for (int i = 0; i < 5; i++)
		{
			array[i] = this.DM.Resource[i].Stock;
		}
		uint num = MaxValue;
		if (this.Resources[0] > 0)
		{
			uint num2 = array[0] / GameConstants.appCeil((float)this.Resources[0] * this.tmpEGA_Cost);
			if (num2 < num)
			{
				num = num2;
			}
		}
		if (this.Resources[1] > 0)
		{
			uint num3 = array[1] / GameConstants.appCeil((float)this.Resources[1] * this.tmpEGA_Cost);
			if (num3 < num)
			{
				num = num3;
			}
		}
		if (this.Resources[2] > 0)
		{
			uint num4 = array[2] / GameConstants.appCeil((float)this.Resources[2] * this.tmpEGA_Cost);
			if (num4 < num)
			{
				num = num4;
			}
		}
		if (this.Resources[3] > 0)
		{
			uint num5 = array[3] / GameConstants.appCeil((float)this.Resources[3] * this.tmpEGA_Cost);
			if (num5 < num)
			{
				num = num5;
			}
		}
		if (this.Resources[4] > 0)
		{
			uint num6 = array[4] / GameConstants.appCeil((float)this.Resources[4] * this.tmpEGA_Cost);
			if (num6 < num)
			{
				num = num6;
			}
		}
		return num;
	}

	// Token: 0x0600195A RID: 6490 RVA: 0x002AF8F0 File Offset: 0x002ADAF0
	public override void OnClose()
	{
		if (this.AssetName != null)
		{
			GUIManager.Instance.RemoveSpriteAsset(this.AssetName);
		}
		if (this.AssetName1 != null)
		{
			GUIManager.Instance.RemoveSpriteAsset(this.AssetName1);
		}
		if (this.Cstr != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr);
		}
		if (this.Cstr_D != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_D);
		}
		if (this.Cstr_D2 != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_D2);
		}
		if (this.Cstr_UnitRS != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_UnitRS);
		}
		if (this.Cstr_Gemstone != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Gemstone);
		}
		if (this.Cstr_Hint_Info != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Hint_Info);
		}
		if (this.DM.bSoldierSave)
		{
			this.DM.tmpSoldierTrainingQty = (uint)this.m_UnitRS.Value;
		}
		this.GUIM.ClearCalculator();
	}

	// Token: 0x0600195B RID: 6491 RVA: 0x002AFA10 File Offset: 0x002ADC10
	public void SetDRformURS(Transform URST, double value)
	{
		UnitResourcesSlider component = URST.GetComponent<UnitResourcesSlider>();
		if (component != null)
		{
			for (int i = 0; i < 5; i++)
			{
				this.Rvalue[i] = (long)(value * GameConstants.appCeil((float)this.Resources[i] * this.tmpEGA_Cost));
			}
			this.GUIM.SetDemandResourcesText(this.m_DResources.GetComponent<Transform>(), this.Rvalue);
			this.btn_Training.ForTextChange(e_BtnType.e_Normal);
			this.btn_TrainingCompleted.ForTextChange(e_BtnType.e_Normal);
			uint num = 0u;
			this.UnitMax = this.CheckMax(this.BarrackMax);
			if (value == 0.0)
			{
				this.btn_TrainingCompleted.ForTextChange(e_BtnType.e_ChangeText);
			}
			else if (value > this.UnitMax)
			{
				bool flag = false;
				for (int j = 0; j < 5; j++)
				{
					if (this.Rvalue[j] > (long)((ulong)this.DM.Resource[j].Stock))
					{
						num += this.DM.GetResourceExchange((PriceListType)j, (uint)this.Rvalue[j] - this.DM.Resource[j].Stock);
						flag = true;
					}
				}
				if (flag)
				{
					this.btn_Training.ForTextChange(e_BtnType.e_ChangeText);
				}
			}
			uint num2 = (uint)value * (uint)this.Resources[5];
			num2 = GameConstants.appCeil(num2 * this.tmpEGA);
			num += this.DM.GetResourceExchange(PriceListType.Time, num2);
			this.Cstr_Gemstone.ClearString();
			this.Cstr_Gemstone.IntToFormat((long)((ulong)num), 1, true);
			this.Cstr_Gemstone.AppendFormat("{0}");
			this.text_Gemstone.text = this.Cstr_Gemstone.ToString();
			this.text_Gemstone.SetAllDirty();
			this.text_Gemstone.cachedTextGenerator.Invalidate();
			this.tmpString.Length = 0;
			if (this.mType == 0)
			{
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(3944u));
			}
			else
			{
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(3792u));
			}
			this.tmpValue = num2 / 3600u;
			if (this.tmpValue < 24u)
			{
				this.tmpString.AppendFormat("{0:00}:{1:00}:{2:00}", this.tmpValue % 60u, num2 / 60u % 60u, num2 % 60u);
			}
			else if (this.GUIM.IsArabic)
			{
				this.tmpString.AppendFormat("{0:00}:{1:00}:{2:00} {3}d", new object[]
				{
					this.tmpValue % 24u,
					num2 / 60u % 60u,
					num2 % 60u,
					this.tmpValue / 24u
				});
			}
			else
			{
				this.tmpString.AppendFormat("{0}d {1:00}:{2:00}:{3:00}", new object[]
				{
					this.tmpValue / 24u,
					this.tmpValue % 24u,
					num2 / 60u % 60u,
					num2 % 60u
				});
			}
			this.text_Time.text = this.tmpString.ToString();
			this.text_Time.SetAllDirty();
			this.text_Time.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x0600195C RID: 6492 RVA: 0x002AFD90 File Offset: 0x002ADF90
	public bool CheckDiamondToSend()
	{
		bool result = false;
		this.needDiamond = 0u;
		long[] array = new long[5];
		long value = this.m_UnitRS.Value;
		for (int i = 0; i < 5; i++)
		{
			array[i] = (long)((float)(value * (long)this.Resources[i]) * this.tmpEGA_Cost);
			if (array[i] > (long)((ulong)this.DM.Resource[i].Stock))
			{
				this.needDiamond += this.DM.GetResourceExchange((PriceListType)i, (uint)array[i] - this.DM.Resource[i].Stock);
			}
		}
		uint num = (uint)value * (uint)this.Resources[5];
		num = GameConstants.appCeil(num * this.tmpEGA);
		this.needDiamond += this.DM.GetResourceExchange(PriceListType.Time, num);
		this.Cstr_Gemstone.ClearString();
		this.Cstr_Gemstone.IntToFormat((long)((ulong)this.needDiamond), 1, true);
		this.Cstr_Gemstone.AppendFormat("{0}");
		this.text_Gemstone.text = this.Cstr_Gemstone.ToString();
		this.text_Gemstone.SetAllDirty();
		this.text_Gemstone.cachedTextGenerator.Invalidate();
		if (this.DM.RoleAttr.Diamond >= this.needDiamond)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x0600195D RID: 6493 RVA: 0x002AFEEC File Offset: 0x002AE0EC
	public bool CheckMaxTroops()
	{
		bool result = false;
		long num = this.DM.SoldierTotal;
		for (int i = 0; i < this.DM.MarchEventData.Length; i++)
		{
			for (int j = 0; j < this.DM.MarchEventData[i].TroopData.Length; j++)
			{
				if (this.DM.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
				{
					for (int k = 0; k < this.DM.MarchEventData[i].TroopData[j].Length; k++)
					{
						num += (long)((ulong)this.DM.MarchEventData[i].TroopData[j][k]);
					}
				}
			}
		}
		if (this.DM.queueBarData[10].bActive)
		{
			num += (long)((ulong)this.DM.SoldierQuantity);
		}
		for (int l = 0; l < 16; l++)
		{
			num += (long)((ulong)this.DM.mSoldier_Hospital[l]);
		}
		if (num + this.m_UnitRS.Value <= (long)((ulong)-94967296))
		{
			result = true;
		}
		return result;
	}

	// Token: 0x0600195E RID: 6494 RVA: 0x002B0028 File Offset: 0x002AE228
	public void OnButtonClick(UIButton sender)
	{
		if (this.Img_SoldierArrow.IsActive())
		{
			this.Img_SoldierArrow.gameObject.SetActive(false);
		}
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 1:
			if (this.mType == 0)
			{
				if (sender.m_BtnType == e_BtnType.e_Normal)
				{
					this.ImgDisbandblack.gameObject.SetActive(true);
					this.m_DisbandSlider.m_slider.maxValue = this.DM.RoleAttr.m_Soldier[(int)(this.RD_ID - 1)];
					this.m_DisbandSlider.m_slider.value = 0.0;
					this.Cstr_D2.ClearString();
					StringManager.IntToStr(this.Cstr_D2, 0L, 1, true);
					this.m_DisbandSlider.m_inputText.text = this.Cstr_D2.ToString();
					this.m_DisbandSlider.m_inputText.SetAllDirty();
					this.m_DisbandSlider.m_inputText.cachedTextGenerator.Invalidate();
					this.btn_Soldier_Disband.ForTextChange(e_BtnType.e_ChangeText);
				}
			}
			else if (sender.m_BtnType == e_BtnType.e_Normal)
			{
				this.ImgDisbandblack.gameObject.SetActive(true);
				this.Cstr_D2.ClearString();
				StringManager.IntToStr(this.Cstr_D2, 0L, 1, true);
				this.m_DisbandSlider.m_slider.maxValue = this.DM.mTrapQty[(int)(this.RD_ID - 17)];
				this.m_DisbandSlider.m_slider.value = 0.0;
				this.m_DisbandSlider.m_inputText.text = this.Cstr_D2.ToString();
				this.m_DisbandSlider.m_inputText.SetAllDirty();
				this.m_DisbandSlider.m_inputText.cachedTextGenerator.Invalidate();
				this.btn_Soldier_Disband.ForTextChange(e_BtnType.e_ChangeText);
			}
			break;
		case 2:
			if (this.mType == 0)
			{
				if (this.DM.queueBarData[10].bActive)
				{
					this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(3928u), this.DM.mStringTable.GetStringByID(3855u), 1, 0, this.DM.mStringTable.GetStringByID(4027u), this.DM.mStringTable.GetStringByID(4028u));
				}
				else
				{
					byte buildNumByID = this.GUIM.BuildingData.GetBuildNumByID(6);
					RoleBuildingData buildData = this.GUIM.BuildingData.GetBuildData(6, 0);
					if (buildNumByID == 0)
					{
						this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4992u), 255, true);
						return;
					}
					if (buildNumByID == 1 && this.GUIM.BuildingData.AllBuildsData[(int)this.GUIM.BuildingData.BuildingManorID].BuildID == 6 && buildData.Level < 1)
					{
						this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4992u), 255, true);
						return;
					}
					this.TrainingMax = (uint)this.m_UnitRS.Value;
					if (this.TrainingMax == 0u)
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703u), 255, true);
						return;
					}
					if (!this.CheckMaxTroops())
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(3923u), 255, true);
						return;
					}
					if (sender.m_BtnType == e_BtnType.e_Normal && GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
					{
						this.DM.SoldierTrainingQty = (uint)this.m_UnitRS.Value;
						MessagePacket messagePacket = new MessagePacket(1024);
						messagePacket.Protocol = Protocol._MSG_REQUEST_TRAINING_;
						messagePacket.AddSeqId();
						messagePacket.Add(this.RD_Kind);
						messagePacket.Add(this.RD_Rank - 1);
						messagePacket.Add(this.TrainingMax);
						messagePacket.Send(false);
						if (this.door != null)
						{
							this.door.CloseMenu(false);
						}
					}
					else if (sender.m_BtnType == e_BtnType.e_ChangeText)
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(3942u), 255, true);
					}
				}
			}
			else if (this.DM.queueBarData[14].bActive)
			{
				this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(3738u), this.DM.mStringTable.GetStringByID(3739u), 5, 0, this.DM.mStringTable.GetStringByID(3740u), null);
			}
			else
			{
				this.TrainingMax = (uint)this.m_UnitRS.Value;
				if (this.TrainingMax == 0u)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703u), 255, true);
					return;
				}
				if (sender.m_BtnType == e_BtnType.e_Normal && GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
				{
					this.DM.TrapTrainingQty = (uint)this.m_UnitRS.Value;
					MessagePacket messagePacket2 = new MessagePacket(1024);
					messagePacket2.Protocol = Protocol._MSG_REQUEST_TRAPCONSTRUCT;
					messagePacket2.AddSeqId();
					messagePacket2.Add(this.RD_Kind - 4);
					messagePacket2.Add(this.RD_Rank - 1);
					messagePacket2.Add(this.TrainingMax);
					messagePacket2.Send(false);
					if (this.door != null)
					{
						this.door.CloseMenu(false);
					}
				}
				else if (sender.m_BtnType == e_BtnType.e_ChangeText)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(3942u), 255, true);
				}
			}
			break;
		case 3:
			if (this.mType == 0)
			{
				byte buildNumByID2 = this.GUIM.BuildingData.GetBuildNumByID(6);
				RoleBuildingData buildData2 = this.GUIM.BuildingData.GetBuildData(6, 0);
				if (buildNumByID2 == 0)
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4992u), 255, true);
					return;
				}
				if (buildNumByID2 == 1 && this.GUIM.BuildingData.AllBuildsData[(int)this.GUIM.BuildingData.BuildingManorID].BuildID == 6 && buildData2.Level < 1)
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4992u), 255, true);
					return;
				}
				if (sender.m_BtnType == e_BtnType.e_Normal)
				{
					if (!this.CheckDiamondToSend())
					{
						this.tmpString.Length = 0;
						this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3857u), this.DM.mStringTable.GetStringByID(3851u));
						this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966u), this.tmpString.ToString(), this.DM.mStringTable.GetStringByID(3968u), this, 2, 0, true, false, false, false, false);
						return;
					}
					if (!this.CheckMaxTroops())
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(3923u), 255, true);
						return;
					}
					if (!this.GUIM.OpenCheckCrystal(this.needDiamond, 5, (int)((int)this.m_eWindow << 16 | EGUIWindow.UI_VipLevelUp), -1))
					{
						this.SendTrainImmed();
					}
				}
				else if (this.m_UnitRS.Value == 0L)
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703u), 255, true);
					return;
				}
			}
			else if (sender.m_BtnType == e_BtnType.e_Normal)
			{
				if (!this.CheckDiamondToSend())
				{
					this.tmpString.Length = 0;
					this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(3857u), this.DM.mStringTable.GetStringByID(3773u));
					this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966u), this.tmpString.ToString(), this.DM.mStringTable.GetStringByID(3968u), this, 2, 0, true, false, false, false, false);
					return;
				}
				if (!this.GUIM.OpenCheckCrystal(this.needDiamond, 5, (int)((int)this.m_eWindow << 16 | EGUIWindow.UI_LeaderBoard), -1))
				{
					this.SendTrackImmed();
				}
			}
			else if (this.m_UnitRS.Value == 0L)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703u), 255, true);
				return;
			}
			break;
		case 4:
			this.GUIM.OpenTechTree(this.tmpSD.Science, true);
			break;
		case 5:
			this.ImgDisbandblack.gameObject.SetActive(false);
			break;
		case 6:
			if (this.mType == 0)
			{
				byte buildNumByID3 = this.GUIM.BuildingData.GetBuildNumByID(6);
				if (buildNumByID3 == 0)
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4997u), 255, true);
					return;
				}
				if (buildNumByID3 == 1 && this.GUIM.BuildingData.AllBuildsData[(int)this.GUIM.BuildingData.BuildingManorID].BuildID == 6 && this.GUIM.BuildingData.AllBuildsData[(int)this.GUIM.BuildingData.BuildingManorID].Level < 1)
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4998u), 255, true);
					return;
				}
				if (sender.m_BtnType == e_BtnType.e_Normal)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.ClearString();
					cstring.uLongToFormat((ulong)this.m_DisbandSlider.m_slider.value, 1, true);
					cstring.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
					cstring.uLongToFormat((ulong)((double)this.tmpSD.Strength * this.m_DisbandSlider.m_slider.value), 1, true);
					cstring.AppendFormat(this.DM.mStringTable.GetStringByID(4052u));
					this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4051u), cstring.ToString(), 3, 0, this.DM.mStringTable.GetStringByID(4053u), this.DM.mStringTable.GetStringByID(4054u));
				}
			}
			else if (sender.m_BtnType == e_BtnType.e_Normal)
			{
				CString cstring2 = StringManager.Instance.StaticString1024();
				cstring2.ClearString();
				cstring2.uLongToFormat((ulong)this.m_DisbandSlider.m_slider.value, 1, true);
				cstring2.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
				cstring2.uLongToFormat((ulong)((double)this.tmpSD.Strength * this.m_DisbandSlider.m_slider.value), 1, true);
				cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(3798u));
				this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(3796u), cstring2.ToString(), 7, 0, this.DM.mStringTable.GetStringByID(4053u), this.DM.mStringTable.GetStringByID(4054u));
			}
			break;
		case 11:
			this.GUIM.m_UICalculator.m_CalculatorHandler = this;
			this.GUIM.m_UICalculator.OpenCalculator(this.m_UnitRS.MaxValue, this.m_UnitRS.Value, -283f, -45f, this.m_UnitRS, 0L);
			break;
		case 12:
			this.GUIM.m_UICalculator.m_CalculatorHandler = this;
			this.GUIM.m_UICalculator.OpenCalculator(this.m_DisbandSlider.MaxValue, this.m_DisbandSlider.Value, -283f, 0f, this.m_DisbandSlider, 0L);
			break;
		case 13:
		{
			if (this.GUIM.Barrack_Soldier_Lock == 2)
			{
				this.GUIM.Barrack_Soldier_Lock = 1;
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9773u), 255, true);
			}
			else if (this.GUIM.Barrack_Soldier_Lock == 1)
			{
				this.GUIM.Barrack_Soldier_Lock = 2;
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9774u), 255, true);
			}
			this.UpdateLcokBtnType();
			CString cstring3 = StringManager.Instance.StaticString1024();
			cstring3.ClearString();
			cstring3.IntToFormat(NetworkManager.UserID, 1, false);
			cstring3.AppendFormat("{0}_Barrack_Soldier_Lock_UseID");
			PlayerPrefs.SetString(cstring3.ToString(), NetworkManager.UserID.ToString());
			cstring3.ClearString();
			cstring3.IntToFormat(NetworkManager.UserID, 1, false);
			cstring3.AppendFormat("{0}_Barrack_Soldier_Lock");
			PlayerPrefs.SetString(cstring3.ToString(), this.GUIM.Barrack_Soldier_Lock.ToString());
			cstring3.ClearString();
			cstring3.IntToFormat(NetworkManager.UserID, 1, false);
			cstring3.AppendFormat("{0}_Barrack_SliderValue");
			PlayerPrefs.SetString(cstring3.ToString(), this.GUIM.Barrack_Soldier_SliderValue.ToString());
			if (this.GUIM.Barrack_Soldier_Lock == 2 && !NewbieManager.IsWorking())
			{
				NewbieManager.CheckSpawnSoldierDetail();
			}
			break;
		}
		case 14:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9773u), 255, true);
			break;
		}
	}

	// Token: 0x0600195F RID: 6495 RVA: 0x002B0ED4 File Offset: 0x002AF0D4
	private void SendTrainImmed()
	{
		if (GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_TRAINING_IMMEDIATELY;
			messagePacket.AddSeqId();
			messagePacket.Add(this.RD_Kind);
			messagePacket.Add(this.RD_Rank - 1);
			messagePacket.Add((uint)this.m_UnitRS.Value);
			messagePacket.Send(false);
		}
	}

	// Token: 0x06001960 RID: 6496 RVA: 0x002B0F44 File Offset: 0x002AF144
	private void SendTrackImmed()
	{
		if (GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_INSTANTTRAPCONSTRUCT;
			messagePacket.AddSeqId();
			messagePacket.Add(this.RD_Kind - 4);
			messagePacket.Add(this.RD_Rank - 1);
			messagePacket.Add((uint)this.m_UnitRS.Value);
			messagePacket.Send(false);
		}
	}

	// Token: 0x06001961 RID: 6497 RVA: 0x002B0FB8 File Offset: 0x002AF1B8
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.Parm1 == 0)
		{
			UIButton uibutton = sender.m_Button as UIButton;
			switch (uibutton.m_BtnID1)
			{
			case 7:
			case 8:
			case 9:
			case 10:
			{
				int num = uibutton.m_BtnID1 - 7;
				if (this.tmpHintIdx != num)
				{
					if (this.tmpHintIdx >= 0 && this.Img_Hint[this.tmpHintIdx].IsActive())
					{
						this.Img_Hint[this.tmpHintIdx].gameObject.SetActive(false);
					}
					this.tmpHintIdx = num;
					this.Img_Hint[num].gameObject.SetActive(true);
				}
				break;
			}
			}
		}
		else if (sender.Parm1 == 1)
		{
			ushort num2 = 0;
			if (sender.Parm2 < 29)
			{
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)sender.Parm2);
				num2 = (ushort)this.tmpSD.SoldierKind;
			}
			this.Cstr_Hint_Info.ClearString();
			if (sender.Parm2 < 17)
			{
				this.Cstr_Hint_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint)(3841 + num2)));
			}
			else if (sender.Parm2 < 29)
			{
				this.Cstr_Hint_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint)(11154 + num2)));
			}
			else
			{
				this.Cstr_Hint_Info.StringToFormat(this.DM.mStringTable.GetStringByID(3895u));
			}
			this.Cstr_Hint_Info.AppendFormat(this.DM.mStringTable.GetStringByID(11157u));
			this.text_Hint_Info.text = this.Cstr_Hint_Info.ToString();
			this.text_Hint_Info.SetAllDirty();
			this.text_Hint_Info.cachedTextGenerator.Invalidate();
			this.text_Hint_Info.cachedTextGeneratorForLayout.Invalidate();
			this.text_Hint_Info.rectTransform.sizeDelta = new Vector2(this.text_Hint_Info.rectTransform.sizeDelta.x, this.text_Hint_Info.preferredHeight + 1f);
			this.Img_Hint_Info.rectTransform.sizeDelta = new Vector2(this.Img_Hint_Info.rectTransform.sizeDelta.x, this.text_Hint_Info.preferredHeight + 21f);
			this.Img_Hint_Info.gameObject.SetActive(true);
			sender.GetTipPosition(this.Img_Hint_Info.rectTransform, UIButtonHint.ePosition.Original, null);
		}
		else
		{
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintArmy, 0, 0f, 0, this.mType, 0, Vector2.zero, UIButtonHint.ePosition.Original);
		}
	}

	// Token: 0x06001962 RID: 6498 RVA: 0x002B1288 File Offset: 0x002AF488
	public void OnButtonUp(UIButtonHint sender)
	{
		if (sender.Parm1 == 0)
		{
			UIButton uibutton = sender.m_Button as UIButton;
			switch (uibutton.m_BtnID1)
			{
			case 7:
			case 8:
			case 9:
			case 10:
			{
				int num = uibutton.m_BtnID1 - 7;
				if (this.Img_Hint[num].IsActive())
				{
					this.Img_Hint[num].gameObject.SetActive(false);
				}
				break;
			}
			}
		}
		this.tmpHintIdx = -1;
		this.Img_Hint_Info.gameObject.SetActive(false);
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x06001963 RID: 6499 RVA: 0x002B132C File Offset: 0x002AF52C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			switch (arg1)
			{
			case 1:
				this.DM.bSoldierSave = true;
				this.DM.bSetExpediton = true;
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 10, false);
				break;
			case 2:
				MallManager.Instance.Send_Mall_Info();
				break;
			case 3:
				if (GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
				{
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.Protocol = Protocol._MSG_REQUEST_TROOPDISMISS;
					messagePacket.AddSeqId();
					messagePacket.Add(this.RD_Kind);
					messagePacket.Add(this.RD_Rank - 1);
					messagePacket.Add((uint)this.m_DisbandSlider.Value);
					messagePacket.Send(false);
					this.ImgDisbandblack.gameObject.SetActive(false);
				}
				break;
			case 5:
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 14, false);
				break;
			case 7:
				if (GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
				{
					MessagePacket messagePacket2 = new MessagePacket(1024);
					messagePacket2.Protocol = Protocol._MSG_REQUEST_TRAPDESTROY;
					messagePacket2.AddSeqId();
					messagePacket2.Add(this.RD_Kind - 4);
					messagePacket2.Add(this.RD_Rank - 1);
					messagePacket2.Add((uint)this.m_DisbandSlider.Value);
					messagePacket2.Send(false);
					this.ImgDisbandblack.gameObject.SetActive(false);
				}
				break;
			}
		}
	}

	// Token: 0x06001964 RID: 6500 RVA: 0x002B14B8 File Offset: 0x002AF6B8
	public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
	{
		URS.m_slider.value = (double)mValue;
		URS.SliderValueChange();
		if (this.mType == 0)
		{
			this.GUIM.Barrack_Soldier_SliderValue = mValue;
		}
	}

	// Token: 0x06001965 RID: 6501 RVA: 0x002B14F0 File Offset: 0x002AF6F0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			this.UpdateLcokBtnType();
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Soldier)
			{
				if (networkNews != NetworkNews.Refresh_AttribEffectVal)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						if (this.m_DResources != null)
						{
							this.m_DResources.Refresh_FontTexture();
						}
						if (this.m_UnitRS != null)
						{
							this.m_UnitRS.Refresh_FontTexture();
						}
						if (this.m_DisbandSlider != null)
						{
							this.m_DisbandSlider.Refresh_FontTexture();
						}
						this.Refresh_FontTexture();
					}
				}
				else
				{
					uint effectBaseVal2;
					if (this.mType == 0)
					{
						this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY);
						uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY_PERCENT);
						this.BarrackMax = this.BarrackMax * (10000u + effectBaseVal) / 10000u;
						effectBaseVal2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED);
						this.m_UnitRS.MaxValue = (long)((ulong)this.BarrackMax);
						this.m_UnitRS.m_slider.maxValue = this.BarrackMax;
						this.Cstr_UnitRS.ClearString();
						StringManager.IntToStr(this.Cstr_UnitRS, (long)((ulong)this.BarrackMax), 1, true);
						this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
						this.m_UnitRS.m_TotalText.SetAllDirty();
						this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
						int num = (int)((this.RD_Rank - 1) * 4 + this.RD_Kind);
						uint num2 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM)(79 + num));
						if (num2 >= 9900u)
						{
							num2 = 9900u;
						}
						this.tmpEGA_Cost = 1f - num2 / 10000f;
					}
					else
					{
						this.mBD = this.GUIM.BuildingData.GetBuildData(12, 0);
						this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData(12, this.mBD.Level);
						uint num3 = 0u;
						if (this.DM.queueBarData[14].bActive)
						{
							num3 += this.DM.TrapTrainingQty;
						}
						if (this.DM.queueBarData[15].bActive)
						{
							num3 += this.DM.Trap_TreatmentQuantity;
						}
						this.BarrackMax = this.mBR.Value1 - this.DM.TrapTotal - num3;
						this.m_UnitRS.m_slider.maxValue = this.BarrackMax;
						this.Cstr_UnitRS.ClearString();
						StringManager.IntToStr(this.Cstr_UnitRS, (long)((ulong)this.BarrackMax), 1, true);
						this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
						this.m_UnitRS.m_TotalText.SetAllDirty();
						this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
						effectBaseVal2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_TRAINING_SPEED);
					}
					float num4 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED_DEBUFF);
					float num5 = 10000u + effectBaseVal2 - num4;
					if (num5 <= 100f)
					{
						num5 = 100f;
					}
					this.tmpEGA = 10000f / num5;
					this.UnitMax = this.CheckMax(this.BarrackMax);
					this.SetDRformURS(this.m_UnitRS.GetComponent<Transform>(), this.m_UnitRS.m_slider.value);
					this.UpdateLcokBtnType();
				}
			}
			else
			{
				uint num6;
				if (this.mType == 0)
				{
					num6 = this.DM.RoleAttr.m_Soldier[(int)(this.RD_ID - 1)];
					this.BarrackMax = 0u;
					byte buildNumByID = this.GUIM.BuildingData.GetBuildNumByID(6);
					for (int i = 0; i < (int)buildNumByID; i++)
					{
						this.mBD = this.GUIM.BuildingData.GetBuildData(6, (ushort)i);
						this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData(6, this.mBD.Level);
						this.BarrackMax += this.mBR.Value1;
					}
					this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY);
					uint effectBaseVal3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY_PERCENT);
					this.BarrackMax = this.BarrackMax * (10000u + effectBaseVal3) / 10000u;
					this.m_UnitRS.MaxValue = (long)((ulong)this.BarrackMax);
					this.m_UnitRS.m_slider.maxValue = this.BarrackMax;
					this.Cstr_UnitRS.ClearString();
					StringManager.IntToStr(this.Cstr_UnitRS, (long)((ulong)this.BarrackMax), 1, true);
					this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
					this.m_UnitRS.m_TotalText.SetAllDirty();
					this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
				}
				else
				{
					num6 = this.DM.mTrapQty[(int)(this.RD_ID - 17)];
					this.mBD = this.GUIM.BuildingData.GetBuildData(12, 0);
					this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData(12, this.mBD.Level);
					uint num7 = 0u;
					if (this.DM.queueBarData[14].bActive)
					{
						num7 += this.DM.TrapTrainingQty;
					}
					if (this.DM.queueBarData[15].bActive)
					{
						num7 += this.DM.Trap_TreatmentQuantity;
					}
					this.BarrackMax = this.mBR.Value1 - this.DM.TrapTotal - num7;
					this.m_UnitRS.MaxValue = (long)((ulong)this.BarrackMax);
					this.m_UnitRS.m_slider.maxValue = this.BarrackMax;
					this.Cstr_UnitRS.ClearString();
					StringManager.IntToStr(this.Cstr_UnitRS, (long)((ulong)this.BarrackMax), 1, true);
					this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
					this.m_UnitRS.m_TotalText.SetAllDirty();
					this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
				}
				this.UnitMax = this.CheckMax(this.BarrackMax);
				this.SetDRformURS(this.m_UnitRS.GetComponent<Transform>(), this.m_UnitRS.m_slider.value);
				this.tmpString.Length = 0;
				GameConstants.FormatValue(this.tmpString, num6);
				this.text_SoldierNum.text = this.tmpString.ToString();
				this.text_Disband_Num.text = this.tmpString.ToString();
				if (num6 == 0u)
				{
					this.btn_Disband.ForTextChange(e_BtnType.e_ChangeText);
				}
				else
				{
					this.btn_Disband.ForTextChange(e_BtnType.e_Normal);
				}
				this.m_DisbandSlider.m_slider.maxValue = num6;
				this.Cstr_D2.ClearString();
				StringManager.IntToStr(this.Cstr_D2, (long)this.m_DisbandSlider.m_slider.value, 1, true);
				this.m_DisbandSlider.m_inputText.text = this.Cstr_D2.ToString();
				this.m_DisbandSlider.m_inputText.SetAllDirty();
				this.m_DisbandSlider.m_inputText.cachedTextGenerator.Invalidate();
				this.Cstr_D.ClearString();
				StringManager.IntToStr(this.Cstr_D, (long)((ulong)num6), 1, true);
				this.m_DisbandSlider.m_TotalText.text = this.Cstr_D.ToString();
				this.m_DisbandSlider.m_TotalText.SetAllDirty();
				this.m_DisbandSlider.m_TotalText.cachedTextGenerator.Invalidate();
				this.m_DisbandSlider.m_TotalText.cachedTextGeneratorForLayout.Invalidate();
				RectTransform component = this.m_DisbandSlider.m_TotalText.transform.GetComponent<RectTransform>();
				if (this.m_DisbandSlider.m_TotalText.preferredWidth > component.sizeDelta.x)
				{
					component.sizeDelta = new Vector2(this.m_DisbandSlider.m_TotalText.preferredWidth + 1f, component.sizeDelta.y);
				}
				int num8 = 0;
				if (num6 / 1000u > 0u)
				{
					if (num6 / 100000000u > 0u)
					{
						num8 = 4;
					}
					else if (num6 / 10000000u > 0u)
					{
						num8 = 3;
					}
					else if (num6 / 10000u > 0u)
					{
						num8 = 2;
					}
					else
					{
						num8 = 1;
					}
				}
				this.DisbandSliderRT.anchoredPosition = new Vector2(this.Pos[num8], this.DisbandSliderRT.anchoredPosition.y);
				this.DisbandSliderRT.sizeDelta = new Vector2(this.Width[num8], this.DisbandSliderRT.sizeDelta.y);
			}
			break;
		}
	}

	// Token: 0x06001966 RID: 6502 RVA: 0x002B1E34 File Offset: 0x002B0034
	public void Refresh_FontTexture()
	{
		if (this.text_tmpStr != null && this.text_tmpStr.enabled)
		{
			this.text_tmpStr.enabled = false;
			this.text_tmpStr.enabled = true;
		}
		if (this.text_SoldierNum != null && this.text_SoldierNum.enabled)
		{
			this.text_SoldierNum.enabled = false;
			this.text_SoldierNum.enabled = true;
		}
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Training != null && this.text_Training.enabled)
		{
			this.text_Training.enabled = false;
			this.text_Training.enabled = true;
		}
		if (this.text_TrainingCompleted != null && this.text_TrainingCompleted.enabled)
		{
			this.text_TrainingCompleted.enabled = false;
			this.text_TrainingCompleted.enabled = true;
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
		if (this.text_Disband_Name != null && this.text_Disband_Name.enabled)
		{
			this.text_Disband_Name.enabled = false;
			this.text_Disband_Name.enabled = true;
		}
		if (this.text_Disband_Num != null && this.text_Disband_Num.enabled)
		{
			this.text_Disband_Num.enabled = false;
			this.text_Disband_Num.enabled = true;
		}
		if (this.text_Disband_Title != null && this.text_Disband_Title.enabled)
		{
			this.text_Disband_Title.enabled = false;
			this.text_Disband_Title.enabled = true;
		}
		if (this.text_Hint_Info != null && this.text_Hint_Info.enabled)
		{
			this.text_Hint_Info.enabled = false;
			this.text_Hint_Info.enabled = true;
		}
		for (int i = 0; i < 4; i++)
		{
			if (this.text_Disband[i] != null && this.text_Disband[i].enabled)
			{
				this.text_Disband[i].enabled = false;
				this.text_Disband[i].enabled = true;
			}
			if (this.text_Hint[i] != null && this.text_Hint[i].enabled)
			{
				this.text_Hint[i].enabled = false;
				this.text_Hint[i].enabled = true;
			}
		}
		for (int j = 0; j < 7; j++)
		{
			if (this.text_Arms[j] != null && this.text_Arms[j].enabled)
			{
				this.text_Arms[j].enabled = false;
				this.text_Arms[j].enabled = true;
			}
		}
	}

	// Token: 0x06001967 RID: 6503 RVA: 0x002B2210 File Offset: 0x002B0410
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 100)
		{
			if (arg1 != 101)
			{
				if (arg1 == 1)
				{
					if (this.GUIM.Barrack_Soldier_Lock == 2)
					{
						uint effectBaseVal2;
						if (this.mType == 0)
						{
							this.BarrackMax = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY);
							uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY_PERCENT);
							this.BarrackMax = this.BarrackMax * (10000u + effectBaseVal) / 10000u;
							effectBaseVal2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED);
							this.m_UnitRS.MaxValue = (long)((ulong)this.BarrackMax);
							this.m_UnitRS.m_slider.maxValue = this.BarrackMax;
							this.Cstr_UnitRS.ClearString();
							StringManager.IntToStr(this.Cstr_UnitRS, (long)((ulong)this.BarrackMax), 1, true);
							this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
							this.m_UnitRS.m_TotalText.SetAllDirty();
							this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
							int num = (int)((this.RD_Rank - 1) * 4 + this.RD_Kind);
							uint num2 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM)(79 + num));
							if (num2 >= 9900u)
							{
								num2 = 9900u;
							}
							this.tmpEGA_Cost = 1f - num2 / 10000f;
						}
						else
						{
							this.mBD = this.GUIM.BuildingData.GetBuildData(12, 0);
							this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData(12, this.mBD.Level);
							uint num3 = 0u;
							if (this.DM.queueBarData[14].bActive)
							{
								num3 += this.DM.TrapTrainingQty;
							}
							if (this.DM.queueBarData[15].bActive)
							{
								num3 += this.DM.Trap_TreatmentQuantity;
							}
							this.BarrackMax = this.mBR.Value1 - this.DM.TrapTotal - num3;
							this.m_UnitRS.m_slider.maxValue = this.BarrackMax;
							this.Cstr_UnitRS.ClearString();
							StringManager.IntToStr(this.Cstr_UnitRS, (long)((ulong)this.BarrackMax), 1, true);
							this.m_UnitRS.m_TotalText.text = this.Cstr_UnitRS.ToString();
							this.m_UnitRS.m_TotalText.SetAllDirty();
							this.m_UnitRS.m_TotalText.cachedTextGenerator.Invalidate();
							effectBaseVal2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_TRAINING_SPEED);
						}
						float num4 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED_DEBUFF);
						float num5 = 10000u + effectBaseVal2 - num4;
						if (num5 <= 100f)
						{
							num5 = 100f;
						}
						this.tmpEGA = 10000f / num5;
						this.UnitMax = this.CheckMax(this.BarrackMax);
						this.Cstr.ClearString();
						StringManager.IntToStr(this.Cstr, (long)((ulong)this.UnitMax), 1, true);
						this.m_UnitRS.m_slider.value = this.UnitMax;
						this.m_UnitRS.Value = (long)((ulong)this.UnitMax);
						this.m_UnitRS.m_inputText.text = this.Cstr.ToString();
						this.m_UnitRS.m_inputText.SetAllDirty();
						this.m_UnitRS.m_inputText.cachedTextGenerator.Invalidate();
						this.SetDRformURS(this.m_UnitRS.GetComponent<Transform>(), this.UnitMax);
					}
				}
			}
			else
			{
				this.SendTrackImmed();
			}
		}
		else
		{
			this.SendTrainImmed();
		}
	}

	// Token: 0x06001968 RID: 6504 RVA: 0x002B25F4 File Offset: 0x002B07F4
	private void SetLockBtnType(int tpye = 0)
	{
		if (this.LockPanel == null || this.btn_Lock == null || this.Img_Lock == null || this.spArray == null)
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
			this.SetLockValue();
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

	// Token: 0x06001969 RID: 6505 RVA: 0x002B279C File Offset: 0x002B099C
	private void UpdateLcokBtnType()
	{
		if (this.GUIM.BuildingData.GetBuildData(8, 0).Level < 18 || !this.bRDOutput || this.mType == 1)
		{
			this.SetLockBtnType(0);
		}
		else
		{
			this.SetLockBtnType(this.GUIM.Barrack_Soldier_Lock);
		}
	}

	// Token: 0x0600196A RID: 6506 RVA: 0x002B2800 File Offset: 0x002B0A00
	private void SetLockValue()
	{
		this.Cstr.ClearString();
		StringManager.IntToStr(this.Cstr, this.GUIM.Barrack_Soldier_SliderValue, 1, true);
		this.m_UnitRS.m_slider.value = (double)this.GUIM.Barrack_Soldier_SliderValue;
		this.m_UnitRS.Value = this.GUIM.Barrack_Soldier_SliderValue;
		this.m_UnitRS.m_inputText.text = this.Cstr.ToString();
		this.m_UnitRS.m_inputText.SetAllDirty();
		this.m_UnitRS.m_inputText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x04004B0A RID: 19210
	private Transform GameT;

	// Token: 0x04004B0B RID: 19211
	private Transform Tf1;

	// Token: 0x04004B0C RID: 19212
	private Transform Tf2;

	// Token: 0x04004B0D RID: 19213
	private Transform Tmp;

	// Token: 0x04004B0E RID: 19214
	private Transform Tmp1;

	// Token: 0x04004B0F RID: 19215
	private Transform Tmp2;

	// Token: 0x04004B10 RID: 19216
	private Transform Tmp3;

	// Token: 0x04004B11 RID: 19217
	private Transform LockPanel;

	// Token: 0x04004B12 RID: 19218
	private RectTransform DisbandSliderRT;

	// Token: 0x04004B13 RID: 19219
	private UIButton btn_EXIT;

	// Token: 0x04004B14 RID: 19220
	private UIButton btn_Disband;

	// Token: 0x04004B15 RID: 19221
	public UIButton btn_Training;

	// Token: 0x04004B16 RID: 19222
	private UIButton btn_TrainingCompleted;

	// Token: 0x04004B17 RID: 19223
	private UIButton btn_RD;

	// Token: 0x04004B18 RID: 19224
	private UIButton btn_Soldier_Exit;

	// Token: 0x04004B19 RID: 19225
	private UIButton btn_Soldier_Disband;

	// Token: 0x04004B1A RID: 19226
	private UIButton[] btn_Hint = new UIButton[4];

	// Token: 0x04004B1B RID: 19227
	private UIButtonHint tmpbtnHint;

	// Token: 0x04004B1C RID: 19228
	private UIButton btn_Lock;

	// Token: 0x04004B1D RID: 19229
	private UIButton btn_Hint_Info;

	// Token: 0x04004B1E RID: 19230
	private DemandResources m_DResources;

	// Token: 0x04004B1F RID: 19231
	public UnitResourcesSlider m_UnitRS;

	// Token: 0x04004B20 RID: 19232
	private UnitResourcesSlider m_DisbandSlider;

	// Token: 0x04004B21 RID: 19233
	private Image Bg1;

	// Token: 0x04004B22 RID: 19234
	private Image[] Bg_T = new Image[5];

	// Token: 0x04004B23 RID: 19235
	private Image Bg2;

	// Token: 0x04004B24 RID: 19236
	private Image Training_BG;

	// Token: 0x04004B25 RID: 19237
	private Image Img_EXIT;

	// Token: 0x04004B26 RID: 19238
	private Image Img_SoldierArrow;

	// Token: 0x04004B27 RID: 19239
	private Image Img_Lock;

	// Token: 0x04004B28 RID: 19240
	private Image Img_LockBG;

	// Token: 0x04004B29 RID: 19241
	private Image[] Img_Soldier = new Image[7];

	// Token: 0x04004B2A RID: 19242
	private Image[] Property = new Image[5];

	// Token: 0x04004B2B RID: 19243
	private Image[] Property1 = new Image[5];

	// Token: 0x04004B2C RID: 19244
	private Image[] Property2 = new Image[5];

	// Token: 0x04004B2D RID: 19245
	private Image[] Property3 = new Image[5];

	// Token: 0x04004B2E RID: 19246
	private Image[] Img_TrainingCompleted = new Image[3];

	// Token: 0x04004B2F RID: 19247
	private Image[] Img_Training = new Image[2];

	// Token: 0x04004B30 RID: 19248
	private Image Img_Resources;

	// Token: 0x04004B31 RID: 19249
	private Image Img_RDLock;

	// Token: 0x04004B32 RID: 19250
	private Image ImgDisbandblack;

	// Token: 0x04004B33 RID: 19251
	private Image ImgDisband_Soldier;

	// Token: 0x04004B34 RID: 19252
	private Image[] Img_Hint = new Image[4];

	// Token: 0x04004B35 RID: 19253
	private Image Img_Icon1;

	// Token: 0x04004B36 RID: 19254
	private Image[] Img_Icon2 = new Image[4];

	// Token: 0x04004B37 RID: 19255
	private Image[] Img_Icon3 = new Image[3];

	// Token: 0x04004B38 RID: 19256
	private Image Img_Hint_Info;

	// Token: 0x04004B39 RID: 19257
	private Image Img_ArmyHint;

	// Token: 0x04004B3A RID: 19258
	private UIText[] text_Arms = new UIText[7];

	// Token: 0x04004B3B RID: 19259
	private UIText[] text_Disband = new UIText[4];

	// Token: 0x04004B3C RID: 19260
	private UIText text_SoldierNum;

	// Token: 0x04004B3D RID: 19261
	private UIText text_Title;

	// Token: 0x04004B3E RID: 19262
	private UIText text_Training;

	// Token: 0x04004B3F RID: 19263
	private UIText text_TrainingCompleted;

	// Token: 0x04004B40 RID: 19264
	private UIText text_Gemstone;

	// Token: 0x04004B41 RID: 19265
	private UIText text_Time;

	// Token: 0x04004B42 RID: 19266
	private UIText text_RD;

	// Token: 0x04004B43 RID: 19267
	private UIText text_RDbtn;

	// Token: 0x04004B44 RID: 19268
	private UIText text_Disband_Name;

	// Token: 0x04004B45 RID: 19269
	private UIText text_Disband_Num;

	// Token: 0x04004B46 RID: 19270
	private UIText text_Disband_Title;

	// Token: 0x04004B47 RID: 19271
	private UIText[] text_Hint = new UIText[4];

	// Token: 0x04004B48 RID: 19272
	private UIText text_tmpStr;

	// Token: 0x04004B49 RID: 19273
	private UIText text_Hint_Info;

	// Token: 0x04004B4A RID: 19274
	private UISpritesArray spArray;

	// Token: 0x04004B4B RID: 19275
	private DataManager DM;

	// Token: 0x04004B4C RID: 19276
	private GUIManager GUIM;

	// Token: 0x04004B4D RID: 19277
	private Font TTFont;

	// Token: 0x04004B4E RID: 19278
	private StringBuilder tmpString = new StringBuilder();

	// Token: 0x04004B4F RID: 19279
	private byte RD_ID;

	// Token: 0x04004B50 RID: 19280
	private byte RD_Kind;

	// Token: 0x04004B51 RID: 19281
	private byte RD_Rank;

	// Token: 0x04004B52 RID: 19282
	private uint UnitMax;

	// Token: 0x04004B53 RID: 19283
	private uint BarrackMax;

	// Token: 0x04004B54 RID: 19284
	private uint TrainingMax;

	// Token: 0x04004B55 RID: 19285
	private bool bRDOutput = true;

	// Token: 0x04004B56 RID: 19286
	private ushort[] Resources = new ushort[6];

	// Token: 0x04004B57 RID: 19287
	private uint[] UnitSoldier = new uint[3];

	// Token: 0x04004B58 RID: 19288
	private uint[] mSoldierArms = new uint[3];

	// Token: 0x04004B59 RID: 19289
	private byte[][] mSoldierProperty = new byte[16][];

	// Token: 0x04004B5A RID: 19290
	private float[] Pos = new float[5];

	// Token: 0x04004B5B RID: 19291
	private float[] Width = new float[5];

	// Token: 0x04004B5C RID: 19292
	private ushort[] StrId = new ushort[4];

	// Token: 0x04004B5D RID: 19293
	private string AssetName;

	// Token: 0x04004B5E RID: 19294
	private string AssetName1;

	// Token: 0x04004B5F RID: 19295
	private Door door;

	// Token: 0x04004B60 RID: 19296
	private SoldierData tmpSD;

	// Token: 0x04004B61 RID: 19297
	private CString Cstr;

	// Token: 0x04004B62 RID: 19298
	private CString Cstr_D;

	// Token: 0x04004B63 RID: 19299
	private CString Cstr_D2;

	// Token: 0x04004B64 RID: 19300
	private CString Cstr_UnitRS;

	// Token: 0x04004B65 RID: 19301
	private CString Cstr_Gemstone;

	// Token: 0x04004B66 RID: 19302
	private CString Cstr_Hint_Info;

	// Token: 0x04004B67 RID: 19303
	private RoleBuildingData mBD;

	// Token: 0x04004B68 RID: 19304
	private BuildLevelRequest mBR;

	// Token: 0x04004B69 RID: 19305
	private int mType;

	// Token: 0x04004B6A RID: 19306
	private int tmpHintIdx = -1;

	// Token: 0x04004B6B RID: 19307
	private uint tmpValue;

	// Token: 0x04004B6C RID: 19308
	private float tmpEGA;

	// Token: 0x04004B6D RID: 19309
	private float tmpEGA_Cost = 1f;

	// Token: 0x04004B6E RID: 19310
	private uint needDiamond;

	// Token: 0x04004B6F RID: 19311
	private long[] Rvalue = new long[5];
}
