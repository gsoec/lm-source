using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020007F8 RID: 2040
public class SpeciallyEffect
{
	// Token: 0x06002A4E RID: 10830 RVA: 0x0046A26C File Offset: 0x0046846C
	public void Load()
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		UnityEngine.Object @object = this.GUIM.m_EffectAssetBundle.Load("SpeciallyEffect");
		if (@object == null)
		{
			return;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
		gameObject.transform.SetParent(this.GUIM.m_WindowTopLayer, false);
		gameObject.SetActive(false);
		this.m_RectTransform = (gameObject.transform as RectTransform);
		for (int i = 0; i < 5; i++)
		{
			this.m_ItmeTransform[i] = this.m_RectTransform.GetChild(i);
			this.m_IconRT[i] = new RectTransform[7];
			this.m_IconRT1[i] = new RectTransform[7];
			this.m_IconRT2[i] = new RectTransform[7];
			this.m_IconRT3[i] = new RectTransform[7];
			this.m_IconRT4[i] = new RectTransform[7];
			this.EffectIcon[i] = new Image[7];
			this.EffectIcon1[i] = new Image[7];
			this.EffectIcon2[i] = new Image[7];
			this.EffectIcon3[i] = new Image[7];
			this.EffectIcon4[i] = new Image[7];
			this.m_Item[i] = new UIHIBtn[3];
			this.m_Item_L[i] = new UILEBtn[3];
			this.m_ItemRT[i] = new RectTransform[3];
			this.m_Item_LRT[i] = new RectTransform[3];
			this.Timer[i] = new float[10];
			this.mMoveKind[i] = new byte[10];
			this.bezierStart[i] = new Vector2[10];
			this.bezierCenter[i] = new Vector2[10];
			this.bezierCenter2[i] = new Vector2[10];
			this.bezierEnd[i] = new Vector2[10];
			this.mKindEnd[i] = new byte[10];
			this.m_Icon[i] = new bool[10];
			this.m_Itme2T[i] = new Transform[7];
			this.mV2Start[i] = new Vector2[7];
			this.mCDTimer[i] = new float[7];
			this.tmpKindNum[i] = new byte[7];
			this.tmpResQty[i] = new byte[7];
			this.tmpKindEndNum[i] = new byte[10];
			this.mEndTime[i] = new float[10];
			for (int j = 0; j < 7; j++)
			{
				this.EffectIcon[i][j] = this.m_ItmeTransform[i].GetChild(j).GetComponent<Image>();
				this.EffectIcon[i][j].gameObject.SetActive(false);
				this.m_IconRT[i][j] = this.m_ItmeTransform[i].GetChild(j).GetComponent<RectTransform>();
				this.m_Itme2T[i][j] = this.m_ItmeTransform[i].GetChild(13 + j);
				this.m_Itme2T[i][j].gameObject.SetActive(false);
				this.EffectIcon1[i][j] = this.m_Itme2T[i][j].GetChild(0).GetComponent<Image>();
				this.EffectIcon2[i][j] = this.m_Itme2T[i][j].GetChild(1).GetComponent<Image>();
				this.EffectIcon3[i][j] = this.m_Itme2T[i][j].GetChild(2).GetComponent<Image>();
				this.EffectIcon4[i][j] = this.m_Itme2T[i][j].GetChild(3).GetComponent<Image>();
				this.EffectIcon1[i][j].gameObject.SetActive(false);
				this.EffectIcon2[i][j].gameObject.SetActive(false);
				this.EffectIcon3[i][j].gameObject.SetActive(false);
				this.EffectIcon4[i][j].gameObject.SetActive(false);
				this.m_IconRT1[i][j] = this.m_Itme2T[i][j].GetChild(0).GetComponent<RectTransform>();
				this.m_IconRT2[i][j] = this.m_Itme2T[i][j].GetChild(1).GetComponent<RectTransform>();
				this.m_IconRT3[i][j] = this.m_Itme2T[i][j].GetChild(2).GetComponent<RectTransform>();
				this.m_IconRT4[i][j] = this.m_Itme2T[i][j].GetChild(3).GetComponent<RectTransform>();
			}
			for (int k = 0; k < 3; k++)
			{
				this.m_Item[i][k] = this.m_ItmeTransform[i].GetChild(7 + k).GetComponent<UIHIBtn>();
				this.m_ItemRT[i][k] = this.m_ItmeTransform[i].GetChild(7 + k).GetComponent<RectTransform>();
				this.GUIM.InitianHeroItemImg(this.m_Item[i][k].transform, eHeroOrItem.Item, 0, 0, 0, 0, true, true, true, false);
				this.m_Item[i][k].gameObject.SetActive(false);
				this.m_Item_L[i][k] = this.m_ItmeTransform[i].GetChild(10 + k).GetComponent<UILEBtn>();
				this.m_Item_LRT[i][k] = this.m_ItmeTransform[i].GetChild(10 + k).GetComponent<RectTransform>();
				this.GUIM.InitLordEquipImg(this.m_Item_L[i][k].transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
				this.m_Item_L[i][k].gameObject.SetActive(false);
			}
		}
		this.m_ImgBG = this.m_RectTransform.GetChild(5).GetComponent<Image>();
		this.m_BGRectTransform = this.m_RectTransform.GetChild(5).GetComponent<RectTransform>();
		this.mCanvasRT = this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>();
	}

	// Token: 0x06002A4F RID: 10831 RVA: 0x0046A7F0 File Offset: 0x004689F0
	public void InitSE_Mat()
	{
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.m_Mat = this.door.LoadMaterial();
		this.m_ImgBG.sprite = this.door.LoadSprite("UI_m_light_001");
		this.m_ImgBG.material = this.m_Mat;
		this.m_ImgBG.SetNativeSize();
		this.mCanvasRT = this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>();
		for (int i = 0; i < 5; i++)
		{
			this.m_ResourceIconT[i] = this.door.m_ResourceIcon[i].transform;
		}
		for (int j = 0; j < 6; j++)
		{
			this.m_FuncButtonT[j] = this.door.m_FuncRC[j].transform;
		}
		this.ItemV2 = this.m_FuncButtonT[0].GetComponent<RectTransform>().anchoredPosition;
		this.m_HeadImageT = this.door.m_HeadImage.transform;
		this.m_PowerImageT = this.door.m_PowerBtn.transform;
		this.m_DiamondIconT = this.door.m_DiamondIcon.transform;
		this.m_MoraleIconT = this.door.m_MoraleIcon.transform;
		this.m_VipIconT = this.door.m_VIPIcon.transform;
		for (int k = 0; k < 5; k++)
		{
			for (int l = 0; l < 7; l++)
			{
				this.EffectIcon[k][l].sprite = this.door.LoadSprite("UI_m_light_001");
				this.EffectIcon[k][l].material = this.m_Mat;
				this.EffectIcon1[k][l].sprite = this.door.LoadSprite("UI_m_light_001");
				this.EffectIcon1[k][l].material = this.m_Mat;
				this.EffectIcon2[k][l].sprite = this.door.LoadSprite("UI_m_light_001");
				this.EffectIcon2[k][l].material = this.m_Mat;
				this.EffectIcon3[k][l].sprite = this.door.LoadSprite("UI_m_light_001");
				this.EffectIcon3[k][l].material = this.m_Mat;
				this.EffectIcon4[k][l].sprite = this.door.LoadSprite("UI_m_light_001");
				this.EffectIcon4[k][l].material = this.m_Mat;
			}
		}
	}

	// Token: 0x06002A50 RID: 10832 RVA: 0x0046AA80 File Offset: 0x00468C80
	public void UnLoad()
	{
		if (this.m_RectTransform == null)
		{
			return;
		}
		UnityEngine.Object.Destroy(this.m_RectTransform.gameObject);
	}

	// Token: 0x06002A51 RID: 10833 RVA: 0x0046AAB0 File Offset: 0x00468CB0
	public void AddIconShow(Vector2 mV2, SpeciallyEffect_Kind[] Kind, ushort[] ItemID, bool bShowImg = true)
	{
		if (bShowImg && this.door == null)
		{
			return;
		}
		this.tmpKindLineNum[this.mNum] = 0;
		this.mCount[this.mNum] = 0;
		this.bShowImgBG = bShowImg;
		for (int i = 0; i < Kind.Length; i++)
		{
			this.m_Itme2T[this.mNum][i].gameObject.SetActive(false);
			this.EffectIcon[this.mNum][i].gameObject.SetActive(false);
			this.EffectIcon1[this.mNum][i].gameObject.SetActive(false);
			this.EffectIcon2[this.mNum][i].gameObject.SetActive(false);
			this.EffectIcon3[this.mNum][i].gameObject.SetActive(false);
			this.EffectIcon4[this.mNum][i].gameObject.SetActive(false);
			if (Kind[i] != SpeciallyEffect_Kind.Kind)
			{
				this.AddIconShow(true, mV2, Kind[i], i, 0, bShowImg, 2f);
				this.tmpKindLineNum[this.mNum]++;
			}
			else
			{
				this.mKindEnd[this.mNum][i] = 0;
				this.tmpKindEndNum[this.mNum][i] = 0;
			}
		}
		for (int j = 0; j < ItemID.Length; j++)
		{
			this.m_Item[this.mNum][j].gameObject.SetActive(false);
			this.m_Item_L[this.mNum][j].gameObject.SetActive(false);
			if (ItemID[j] != 0)
			{
				this.tmpEQ = this.DM.EquipTable.GetRecordByKey(ItemID[j]);
				if (this.tmpEQ.EquipKind == 20 || this.tmpEQ.EquipKind == 27)
				{
					this.AddIconShow(true, mV2, SpeciallyEffect_Kind.Item_Material, j + 7, ItemID[j], bShowImg, 2f);
				}
				else if (this.tmpEQ.EquipKind == 6 && this.tmpEQ.PropertiesInfo[0].Propertieskey == 5)
				{
					this.AddIconShow(true, mV2, SpeciallyEffect_Kind.PetSkill_PetItem, j + 7, ItemID[j], bShowImg, 2f);
				}
				else
				{
					this.AddIconShow(true, mV2, SpeciallyEffect_Kind.Item, j + 7, ItemID[j], bShowImg, 2f);
				}
			}
			else
			{
				this.mKindEnd[this.mNum][j + 7] = 0;
				this.tmpKindEndNum[this.mNum][j + 7] = 0;
			}
		}
		if (this.mNum < 4)
		{
			this.mNum++;
		}
		else
		{
			this.mNum = 0;
		}
		if (this.mIteCount < 5)
		{
			this.mIteCount++;
		}
	}

	// Token: 0x06002A52 RID: 10834 RVA: 0x0046AD74 File Offset: 0x00468F74
	public void AddIconShow(bool bMission, Vector2 mV2, SpeciallyEffect_Kind Kind, int Idx = 0, ushort ItemID = 0, bool bShowImg = true, float EndTime = 2f)
	{
		if (Kind != SpeciallyEffect_Kind.TreasureBoxEX && this.door == null)
		{
			return;
		}
		if (bShowImg && this.door == null)
		{
			return;
		}
		if (!bShowImg)
		{
			this.m_ImgBG.gameObject.SetActive(false);
		}
		this.bShowImgBG = bShowImg;
		float num = 0f;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			num = this.GUIM.IPhoneX_DeltaX;
		}
		Vector2 vector = new Vector2(mV2.x - num, -mV2.y);
		if (Idx == 0)
		{
			this.tmpCountKind = 0;
			this.m_RectTransform.gameObject.SetActive(true);
			this.m_RectTransform.SetAsLastSibling();
			this.m_ItmeTransform[this.mNum].gameObject.SetActive(true);
			if (!bMission && (Kind == SpeciallyEffect_Kind.Item || Kind == SpeciallyEffect_Kind.Item_Material || Kind == SpeciallyEffect_Kind.AddVIP || Kind == SpeciallyEffect_Kind.TreasureBox2 || Kind == SpeciallyEffect_Kind.Donation_Item || Kind == SpeciallyEffect_Kind.Donation_Item_Material || Kind == SpeciallyEffect_Kind.PetSkill_PetItem))
			{
				Idx += 7;
			}
			this.m_BGRectTransform.anchoredPosition = vector;
			if (this.bShowImgBG)
			{
				this.m_ImgBG.gameObject.SetActive(true);
				this.m_ImgBG.color = new Color(1f, 1f, 1f, 1f);
			}
			this.mBGTimer = 0f;
		}
		if (this.tmpKindLineNum[this.mNum] == 0)
		{
			this.tmpCountKind = 0;
			this.m_RectTransform.gameObject.SetActive(true);
			this.m_RectTransform.SetAsLastSibling();
			this.m_ItmeTransform[this.mNum].gameObject.SetActive(true);
			this.m_BGRectTransform.anchoredPosition = vector;
			if (this.bShowImgBG)
			{
				this.m_ImgBG.gameObject.SetActive(true);
				this.m_ImgBG.color = new Color(1f, 1f, 1f, 1f);
			}
			this.mBGTimer = 0f;
		}
		this.Timer[this.mNum][Idx] = 0f;
		this.bezierStart[this.mNum][Idx] = vector;
		this.mMoveKind[this.mNum][Idx] = 2;
		this.tmpKindEndNum[this.mNum][Idx] = 0;
		this.mEndTime[this.mNum][Idx] = EndTime;
		switch (Kind)
		{
		case SpeciallyEffect_Kind.Power:
			if (this.door.m_eMode == EUIOriginMode.Show)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(20f + num, -26f);
				this.mKindEnd[this.mNum][Idx] = 1;
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(0f + num, 0f);
				this.mKindEnd[this.mNum][Idx] = 0;
			}
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_strength");
			break;
		case SpeciallyEffect_Kind.Diamond:
			if (this.door.m_eMode == EUIOriginMode.Show)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(126f + num, -56f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(60f + num, -20f);
			}
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_money_02");
			this.mKindEnd[this.mNum][Idx] = 2;
			break;
		case SpeciallyEffect_Kind.Morale:
			if (this.door.m_eMode == EUIOriginMode.Show)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(126f + num, -90f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(60f + num, -50f);
			}
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_money_03");
			this.mKindEnd[this.mNum][Idx] = 3;
			break;
		case SpeciallyEffect_Kind.LeadExp:
			if (this.door.m_eMode == EUIOriginMode.Show)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(58f + num, -78f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(0f + num, 0f);
			}
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
			{
				this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_exp_cn");
			}
			else
			{
				this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_exp");
			}
			this.mKindEnd[this.mNum][Idx] = 4;
			break;
		case SpeciallyEffect_Kind.LeadCoin:
			if (this.door.m_eMode == EUIOriginMode.Show)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(58f + num, -78f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(0f + num, 0f);
			}
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_end_icon_003");
			this.mKindEnd[this.mNum][Idx] = 5;
			break;
		case SpeciallyEffect_Kind.Item:
			if (this.door.m_eMode == EUIOriginMode.Show && this.door.m_bShowFuncButton != 0)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x + this.ItemV2.x - 78f - num - num, -(this.mCanvasRT.sizeDelta.y - this.ItemV2.y - 10f));
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 23f - num - num, -this.mCanvasRT.sizeDelta.y + 44f);
			}
			this.GUIM.ChangeHeroItemImg(this.m_Item[this.mNum][Idx - 7].transform, eHeroOrItem.Item, ItemID, 0, 0, 0);
			this.mKindEnd[this.mNum][Idx] = 6;
			break;
		case SpeciallyEffect_Kind.Item_Material:
			this.bezierEnd[this.mNum][Idx] = new Vector2(-60f + num, 60f);
			this.GUIM.ChangeLordEquipImg(this.m_Item_L[this.mNum][Idx - 7].transform, ItemID, this.GUIM.SE_Item_L_Color[Idx - 7], eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
			this.mKindEnd[this.mNum][Idx] = 7;
			break;
		case SpeciallyEffect_Kind.HeroExp:
			if (this.door.m_eMode == EUIOriginMode.Show && this.door.m_bShowFuncButton != 0)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 123f - num - num, -this.mCanvasRT.sizeDelta.y + 44f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 23f - num - num, -this.mCanvasRT.sizeDelta.y + 44f);
			}
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("icon010");
			this.mKindEnd[this.mNum][Idx] = 8;
			break;
		case SpeciallyEffect_Kind.Other:
			this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 23f - num - num, -this.mCanvasRT.sizeDelta.y + 44f);
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("icon001");
			this.mKindEnd[this.mNum][Idx] = 0;
			break;
		case SpeciallyEffect_Kind.AllianceMoney:
			if (this.door.m_eMode == EUIOriginMode.Show && this.door.m_bShowFuncButton != 0)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 600f - num - num, -this.mCanvasRT.sizeDelta.y + 44f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 23f - num - num, -this.mCanvasRT.sizeDelta.y + 44f);
			}
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_league");
			this.mKindEnd[this.mNum][Idx] = 10;
			break;
		case SpeciallyEffect_Kind.Alliance_Speed_Money:
		case SpeciallyEffect_Kind.Alliance_Speed_Money2:
			this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_league");
			this.mKindEnd[this.mNum][Idx] = 11;
			break;
		case SpeciallyEffect_Kind.Alliance_Gift_Key:
			this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_league_key_01");
			this.mKindEnd[this.mNum][Idx] = 12;
			break;
		case SpeciallyEffect_Kind.Alliance_Gift:
			this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_league_icon_02");
			this.mKindEnd[this.mNum][Idx] = 13;
			break;
		case SpeciallyEffect_Kind.AddVIP:
			this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
			this.GUIM.ChangeHeroItemImg(this.m_Item[this.mNum][Idx - 7].transform, eHeroOrItem.Item, ItemID, 0, 0, 0);
			this.mKindEnd[this.mNum][Idx] = 14;
			break;
		case SpeciallyEffect_Kind.AddVIP_Point:
			if (this.door.m_eMode == EUIOriginMode.Show)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(125f + num, -120f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(0f + num, 0f);
			}
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("icon039");
			this.mKindEnd[this.mNum][Idx] = 15;
			break;
		case SpeciallyEffect_Kind.Food:
			if (Indemnify.IsEffectShow)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -370f);
			}
			else if (this.door.m_eMode == EUIOriginMode.Show)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -20f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 30f - num - num, -30f);
			}
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_food");
			this.mKindEnd[this.mNum][Idx] = ((!Indemnify.IsEffectShow) ? 16 : 0);
			break;
		case SpeciallyEffect_Kind.Stone:
			if (Indemnify.IsEffectShow)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -370f);
			}
			else if (this.door.m_eMode == EUIOriginMode.Show && this.door.m_bShowFuncButton != 0)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -56f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 30f - num - num, -30f);
			}
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_stone");
			this.mKindEnd[this.mNum][Idx] = ((!Indemnify.IsEffectShow) ? 17 : 0);
			break;
		case SpeciallyEffect_Kind.Wood:
			if (Indemnify.IsEffectShow)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -370f);
			}
			else if (this.door.m_eMode == EUIOriginMode.Show && this.door.m_bShowFuncButton != 0)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -90f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 30f - num - num, -30f);
			}
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_wood");
			this.mKindEnd[this.mNum][Idx] = ((!Indemnify.IsEffectShow) ? 18 : 0);
			break;
		case SpeciallyEffect_Kind.Iron:
			if (Indemnify.IsEffectShow)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -370f);
			}
			else if (this.door.m_eMode == EUIOriginMode.Show && this.door.m_bShowFuncButton != 0)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -124f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 30f - num - num, -30f);
			}
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_res_iron");
			this.mKindEnd[this.mNum][Idx] = ((!Indemnify.IsEffectShow) ? 19 : 0);
			break;
		case SpeciallyEffect_Kind.Money:
			if (this.door.m_eMode == EUIOriginMode.Show)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 20f - num - num, -160f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(this.mCanvasRT.sizeDelta.x - 30f - num - num, -30f);
			}
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_money_01");
			this.mKindEnd[this.mNum][Idx] = 20;
			break;
		case SpeciallyEffect_Kind.MobilizationMission:
			this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_mall_box_a_02");
			this.mKindEnd[this.mNum][Idx] = 21;
			break;
		case SpeciallyEffect_Kind.TreasureBox2:
			if (this.door.m_eMode == EUIOriginMode.Show)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(126f + num, -90f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(60f + num, -50f);
			}
			this.GUIM.ChangeHeroItemImg(this.m_Item[this.mNum][Idx - 7].transform, eHeroOrItem.Item, ItemID, 0, 0, 0);
			this.mKindEnd[this.mNum][Idx] = 23;
			break;
		case SpeciallyEffect_Kind.TreasureBoxEX:
			this.EffectIcon[this.mNum][Idx].sprite = this.GUIM.LoadFrameSprite("UI_main_money_02");
			this.EffectIcon[this.mNum][Idx].material = this.GUIM.GetFrameMaterial();
			this.bezierEnd[this.mNum][Idx] = new Vector2(60f + num, -20f);
			break;
		case SpeciallyEffect_Kind.Donation_Item:
			this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
			this.GUIM.ChangeHeroItemImg(this.m_Item[this.mNum][Idx - 7].transform, eHeroOrItem.Item, ItemID, 0, 0, 0);
			this.mKindEnd[this.mNum][Idx] = 25;
			break;
		case SpeciallyEffect_Kind.Donation_Item_Material:
			this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
			this.GUIM.ChangeLordEquipImg(this.m_Item_L[this.mNum][Idx - 7].transform, ItemID, this.GUIM.SE_Item_L_Color[Idx - 7], eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
			this.mKindEnd[this.mNum][Idx] = 26;
			break;
		case SpeciallyEffect_Kind.CastleStrengrten:
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_c_star_01");
			this.bezierEnd[this.mNum][Idx] = this.UI_bezieEnd;
			this.mKindEnd[this.mNum][Idx] = 27;
			break;
		case SpeciallyEffect_Kind.PetSkill_Morale:
			if (this.door.m_eMode == EUIOriginMode.Show)
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(126f + num, -90f);
			}
			else
			{
				this.bezierEnd[this.mNum][Idx] = new Vector2(0f + num, 0f);
			}
			this.EffectIcon[this.mNum][Idx].sprite = this.door.LoadSprite("UI_main_money_03");
			this.mKindEnd[this.mNum][Idx] = 28;
			break;
		case SpeciallyEffect_Kind.PetSkill_PetItem:
			this.bezierEnd[this.mNum][Idx] = new Vector2(-60f + num, 60f);
			this.GUIM.ChangeHeroItemImg(this.m_Item[this.mNum][Idx - 7].transform, eHeroOrItem.Item, ItemID, 0, 0, 0);
			this.mKindEnd[this.mNum][Idx] = 29;
			break;
		}
		if (Kind == SpeciallyEffect_Kind.Item || Kind == SpeciallyEffect_Kind.AddVIP || Kind == SpeciallyEffect_Kind.TreasureBox2 || Kind == SpeciallyEffect_Kind.Donation_Item || Kind == SpeciallyEffect_Kind.PetSkill_PetItem)
		{
			this.m_Item[this.mNum][Idx - 7].gameObject.SetActive(false);
			this.m_ItemRT[this.mNum][Idx - 7].anchoredPosition = this.bezierStart[this.mNum][Idx];
			this.m_Item_L[this.mNum][Idx - 7].gameObject.SetActive(false);
			this.m_Item_LRT[this.mNum][Idx - 7].anchoredPosition = this.bezierStart[this.mNum][Idx];
		}
		else if (Kind == SpeciallyEffect_Kind.Item_Material || Kind == SpeciallyEffect_Kind.Donation_Item_Material)
		{
			this.m_Item[this.mNum][Idx - 7].gameObject.SetActive(false);
			this.m_ItemRT[this.mNum][Idx - 7].anchoredPosition = this.bezierStart[this.mNum][Idx];
			this.m_Item_L[this.mNum][Idx - 7].gameObject.SetActive(false);
			this.m_Item_LRT[this.mNum][Idx - 7].anchoredPosition = this.bezierStart[this.mNum][Idx];
		}
		else
		{
			if (Kind != SpeciallyEffect_Kind.TreasureBoxEX && this.door != null)
			{
				this.EffectIcon[this.mNum][Idx].material = this.m_Mat;
			}
			this.EffectIcon[this.mNum][Idx].gameObject.SetActive(false);
			this.EffectIcon[this.mNum][Idx].SetNativeSize();
			this.EffectIcon[this.mNum][Idx].color = new Color(1f, 1f, 1f, 1f);
			this.m_IconRT[this.mNum][Idx].anchoredPosition = this.bezierStart[this.mNum][Idx];
			this.tmpKindNum[this.mNum][Idx] = 0;
			if (this.GUIM.IsArabic && (Kind == SpeciallyEffect_Kind.AddVIP_Point || Kind == SpeciallyEffect_Kind.HeroExp || Kind == SpeciallyEffect_Kind.LeadExp || Kind == SpeciallyEffect_Kind.Alliance_Gift))
			{
				this.m_IconRT[this.mNum][Idx].localScale = new Vector3(-1.3f, 1.3f, 1.3f);
			}
			else if (Kind == SpeciallyEffect_Kind.CastleStrengrten)
			{
				this.m_IconRT[this.mNum][Idx].localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				this.m_IconRT[this.mNum][Idx].localScale = new Vector3(1.3f, 1.3f, 1.3f);
			}
			if (Kind == SpeciallyEffect_Kind.CastleStrengrten)
			{
				if (this.mParticleEffect[this.mNum] != null)
				{
					ParticleManager.Instance.DeSpawn(this.mParticleEffect[this.mNum]);
					this.mParticleEffect[this.mNum] = null;
				}
				this.mParticleEffect[this.mNum] = ParticleManager.Instance.Spawn(426, this.m_IconRT[this.mNum][Idx].transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
				this.GUIM.SetLayer(this.mParticleEffect[this.mNum], 5);
				this.mParticleEffect[this.mNum].transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			}
			this.mCDTimer[this.mNum][Idx] = 0f;
			if (Kind == SpeciallyEffect_Kind.Diamond || Kind == SpeciallyEffect_Kind.Food || Kind == SpeciallyEffect_Kind.Stone || Kind == SpeciallyEffect_Kind.Wood || Kind == SpeciallyEffect_Kind.Iron || Kind == SpeciallyEffect_Kind.Money || Kind == SpeciallyEffect_Kind.Alliance_Speed_Money2)
			{
				this.tmpResQty[this.mNum][Idx] = 0;
				if (Kind == SpeciallyEffect_Kind.Diamond)
				{
					this.tmpResValue = this.mDiamondValue;
				}
				else if (Kind == SpeciallyEffect_Kind.Alliance_Speed_Money2)
				{
					if (this.DM.AllianceMoneyBonusRate / 100 < 3)
					{
						this.tmpResValue = (uint)(1000 * (this.DM.AllianceMoneyBonusRate / 100));
					}
					else if (this.DM.AllianceMoneyBonusRate / 100 == 3)
					{
						this.tmpResValue = 10000u;
					}
					else if (this.DM.AllianceMoneyBonusRate / 100 >= 4)
					{
						this.tmpResValue = 100000u;
					}
				}
				else
				{
					this.tmpResValue = this.mResValue[Kind - SpeciallyEffect_Kind.Food];
				}
				if (this.tmpResValue >= 1000u && this.tmpResValue < 3000u)
				{
					this.tmpResQty[this.mNum][Idx] = 1;
				}
				else if (this.tmpResValue >= 3000u && this.tmpResValue < 10000u)
				{
					this.tmpResQty[this.mNum][Idx] = 2;
				}
				else if (this.tmpResValue >= 10000u && this.tmpResValue < 100000u)
				{
					this.tmpResQty[this.mNum][Idx] = 3;
				}
				else if (this.tmpResValue >= 100000u)
				{
					this.tmpResQty[this.mNum][Idx] = 4;
				}
				else
				{
					this.tmpResQty[this.mNum][Idx] = 0;
				}
				if (this.tmpResQty[this.mNum][Idx] > 0)
				{
					this.m_Itme2T[this.mNum][Idx].gameObject.SetActive(true);
					this.mCDTimer[this.mNum][Idx] = 0f;
					this.EffectIcon1[this.mNum][Idx].sprite = this.EffectIcon[this.mNum][Idx].sprite;
					this.EffectIcon1[this.mNum][Idx].material = this.m_Mat;
					this.EffectIcon1[this.mNum][Idx].SetNativeSize();
					this.EffectIcon2[this.mNum][Idx].sprite = this.EffectIcon[this.mNum][Idx].sprite;
					this.EffectIcon2[this.mNum][Idx].material = this.m_Mat;
					this.EffectIcon2[this.mNum][Idx].SetNativeSize();
					this.EffectIcon3[this.mNum][Idx].sprite = this.EffectIcon[this.mNum][Idx].sprite;
					this.EffectIcon3[this.mNum][Idx].material = this.m_Mat;
					this.EffectIcon3[this.mNum][Idx].SetNativeSize();
					this.EffectIcon4[this.mNum][Idx].sprite = this.EffectIcon[this.mNum][Idx].sprite;
					this.EffectIcon4[this.mNum][Idx].material = this.m_Mat;
					this.EffectIcon4[this.mNum][Idx].SetNativeSize();
					this.EffectIcon1[this.mNum][Idx].gameObject.SetActive(false);
					this.EffectIcon2[this.mNum][Idx].gameObject.SetActive(false);
					this.EffectIcon3[this.mNum][Idx].gameObject.SetActive(false);
					this.EffectIcon4[this.mNum][Idx].gameObject.SetActive(false);
				}
				else
				{
					this.m_Itme2T[this.mNum][Idx].gameObject.SetActive(false);
				}
				this.m_IconRT1[this.mNum][Idx].anchoredPosition = this.bezierStart[this.mNum][Idx];
				this.m_IconRT1[this.mNum][Idx].localScale = new Vector3(1.3f, 1.3f, 1.3f);
				this.m_IconRT2[this.mNum][Idx].anchoredPosition = this.bezierStart[this.mNum][Idx];
				this.m_IconRT2[this.mNum][Idx].localScale = new Vector3(1.3f, 1.3f, 1.3f);
				this.m_IconRT3[this.mNum][Idx].anchoredPosition = this.bezierStart[this.mNum][Idx];
				this.m_IconRT3[this.mNum][Idx].localScale = new Vector3(1.3f, 1.3f, 1.3f);
				this.m_IconRT4[this.mNum][Idx].anchoredPosition = this.bezierStart[this.mNum][Idx];
				this.m_IconRT4[this.mNum][Idx].localScale = new Vector3(1.3f, 1.3f, 1.3f);
			}
		}
		if (Kind == SpeciallyEffect_Kind.Donation_Item || Kind == SpeciallyEffect_Kind.Donation_Item_Material)
		{
			this.bezierCenter[this.mNum][Idx] = vector;
			this.bezierCenter2[this.mNum][Idx] = vector + new Vector2(0f, 100f);
		}
		else
		{
			Vector2 vector2 = this.bezierStart[this.mNum][Idx] - this.bezierEnd[this.mNum][Idx];
			if (vector2.x > 0f && vector2.y < 0f)
			{
				this.bezierCenter[this.mNum][Idx] = vector;
				this.bezierCenter2[this.mNum][Idx] = vector + new Vector2(-100f, -100f);
			}
			else if (vector2.x > 0f && vector2.y > 0f)
			{
				this.bezierCenter[this.mNum][Idx] = vector;
				this.bezierCenter2[this.mNum][Idx] = vector + new Vector2(-100f, 100f);
			}
			else if (vector2.x < 0f && vector2.y > 0f)
			{
				this.bezierCenter[this.mNum][Idx] = vector;
				this.bezierCenter2[this.mNum][Idx] = vector + new Vector2(100f, 100f);
			}
			else if (vector2.x < 0f && vector2.y < 0f)
			{
				this.bezierCenter[this.mNum][Idx] = vector;
				this.bezierCenter2[this.mNum][Idx] = vector + new Vector2(100f, -100f);
				if (-this.bezierStart[this.mNum][Idx].y + 100f > this.mCanvasRT.sizeDelta.y)
				{
					this.bezierCenter2[this.mNum][Idx] = vector + new Vector2(100f, 100f);
				}
			}
		}
		this.tmpCountKind++;
		this.mCount[this.mNum]++;
		if (!bMission)
		{
			this.tmpKindLineNum[this.mNum] = 0;
			if (this.mNum < 4)
			{
				this.mNum++;
			}
			else
			{
				this.mNum = 0;
			}
			if (this.mIteCount < 5)
			{
				this.mIteCount++;
			}
		}
	}

	// Token: 0x06002A53 RID: 10835 RVA: 0x0046D058 File Offset: 0x0046B258
	public void ClearAllEffect()
	{
		this.mItemlist.Clear();
		for (int i = 0; i < 5; i++)
		{
			this.tmpKindLineNum[i] = 0;
			for (int j = 0; j < 10; j++)
			{
				this.m_Icon[i][j] = false;
				this.tmpKindEndNum[i][j] = 0;
				this.mKindEnd[i][j] = 0;
				this.Timer[i][j] = 0f;
				this.mMoveKind[i][j] = 0;
				if (j < 7)
				{
					this.tmpResQty[i][j] = 0;
					this.EffectIcon[i][j].gameObject.SetActive(false);
					this.EffectIcon1[i][j].gameObject.SetActive(false);
					this.EffectIcon2[i][j].gameObject.SetActive(false);
					this.EffectIcon3[i][j].gameObject.SetActive(false);
					this.EffectIcon4[i][j].gameObject.SetActive(false);
				}
				else
				{
					this.m_Item[i][j - 7].gameObject.SetActive(false);
					this.m_Item_L[i][j - 7].gameObject.SetActive(false);
				}
			}
			this.mCount[i] = 0;
			this.m_ItmeTransform[i].gameObject.SetActive(false);
			if (this.mParticleEffect[i] != null)
			{
				ParticleManager.Instance.DeSpawn(this.mParticleEffect[i]);
				this.mParticleEffect[i] = null;
			}
		}
		this.mNum = 0;
		this.mIteCount = 0;
		this.m_RectTransform.gameObject.SetActive(false);
		MallManager.Instance.mMonthTreasure_CDTime = 0f;
	}

	// Token: 0x06002A54 RID: 10836 RVA: 0x0046D200 File Offset: 0x0046B400
	public void HideIcon(int Idx, int mItemIdx, bool bItem = false, bool bLItem = false)
	{
		if (this.mParticleEffect[Idx] != null && this.mKindEnd[Idx][mItemIdx] == 0)
		{
			ParticleManager.Instance.DeSpawn(this.mParticleEffect[Idx]);
			this.mParticleEffect[Idx] = null;
		}
		if (!bItem)
		{
			this.EffectIcon[Idx][mItemIdx].gameObject.SetActive(false);
			this.tmpKindEndNum[Idx][mItemIdx] = 2;
			this.m_Icon[Idx][mItemIdx] = true;
		}
		else
		{
			this.m_Item_L[Idx][mItemIdx].gameObject.SetActive(false);
			this.m_Item[Idx][mItemIdx].gameObject.SetActive(false);
			this.tmpKindEndNum[Idx][mItemIdx + 7] = 2;
			this.m_Icon[Idx][mItemIdx + 7] = true;
		}
		this.Timer[Idx][mItemIdx] = 0f;
	}

	// Token: 0x06002A55 RID: 10837 RVA: 0x0046D2D4 File Offset: 0x0046B4D4
	public void UpdateRun()
	{
		if (this.m_RectTransform == null || !this.m_RectTransform.gameObject.activeSelf)
		{
			return;
		}
		if (this.door != null && this.m_ImgBG.gameObject.activeSelf)
		{
			this.m_ImgBG.color = new Color(1f, 1f, 1f, 1f - this.mBGTimer);
			this.mBGTimer += Time.smoothDeltaTime;
			if (this.mBGTimer > 1f)
			{
				this.mBGTimer = 0f;
				this.m_ImgBG.gameObject.SetActive(false);
			}
		}
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 10; j++)
			{
				this.Timer[i][j] += Time.smoothDeltaTime;
				if (j < 7)
				{
					if (this.m_Itme2T[i][j].gameObject.activeSelf)
					{
						this.mCDTimer[i][j] += Time.smoothDeltaTime;
						if (this.mCDTimer[i][j] > this.TimeParameters1 * (float)j + this.mRes_Time && this.tmpResQty[i][j] > 0)
						{
							if (this.EffectIcon1[i][j].gameObject.activeSelf)
							{
								if (this.mCDTimer[i][j] < this.mEndTime[i][j] + this.TimeParameters1 * (float)j + this.mRes_Time)
								{
									this.m_IconRT1[i][j].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[i][j], this.bezierCenter[i][j], this.bezierCenter2[i][j], this.bezierEnd[i][j], 1f / this.mEndTime[i][j], this.mCDTimer[i][j] - (this.TimeParameters1 * (float)j + this.mRes_Time));
								}
								else
								{
									this.m_IconRT1[i][j].gameObject.SetActive(false);
								}
							}
							else
							{
								this.EffectIcon1[i][j].gameObject.SetActive(true);
							}
						}
						if (this.mCDTimer[i][j] > this.TimeParameters1 * (float)j + this.mRes_Time * 2f && this.tmpResQty[i][j] > 1)
						{
							if (this.EffectIcon2[i][j].gameObject.activeSelf)
							{
								if (this.mCDTimer[i][j] < this.mEndTime[i][j] + this.TimeParameters1 * (float)j + this.mRes_Time * 2f)
								{
									this.m_IconRT2[i][j].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[i][j], this.bezierCenter[i][j], this.bezierCenter2[i][j], this.bezierEnd[i][j], 1f / this.mEndTime[i][j], this.mCDTimer[i][j] - (this.TimeParameters1 * (float)j + this.mRes_Time * 2f));
								}
								else
								{
									this.m_IconRT2[i][j].gameObject.SetActive(false);
								}
							}
							else
							{
								this.EffectIcon2[i][j].gameObject.SetActive(true);
							}
						}
						if (this.mCDTimer[i][j] > this.TimeParameters1 * (float)j + this.mRes_Time * 3f && this.tmpResQty[i][j] > 2)
						{
							if (this.EffectIcon3[i][j].gameObject.activeSelf)
							{
								if (this.mCDTimer[i][j] < this.mEndTime[i][j] + this.TimeParameters1 * (float)j + this.mRes_Time * 3f)
								{
									this.m_IconRT3[i][j].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[i][j], this.bezierCenter[i][j], this.bezierCenter2[i][j], this.bezierEnd[i][j], 1f / this.mEndTime[i][j], this.mCDTimer[i][j] - (this.TimeParameters1 * (float)j + this.mRes_Time * 3f));
								}
								else
								{
									this.m_IconRT3[i][j].gameObject.SetActive(false);
								}
							}
							else
							{
								this.EffectIcon3[i][j].gameObject.SetActive(true);
							}
						}
						if (this.mCDTimer[i][j] > this.TimeParameters1 * (float)j + this.mRes_Time * 4f && this.tmpResQty[i][j] > 3)
						{
							if (this.EffectIcon4[i][j].gameObject.activeSelf)
							{
								if (this.mCDTimer[i][j] < this.mEndTime[i][j] + this.TimeParameters1 * (float)j + this.mRes_Time * 4f)
								{
									this.m_IconRT4[i][j].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[i][j], this.bezierCenter[i][j], this.bezierCenter2[i][j], this.bezierEnd[i][j], 1f / this.mEndTime[i][j], this.mCDTimer[i][j] - (this.TimeParameters1 * (float)j + this.mRes_Time * 4f));
								}
								else
								{
									this.m_IconRT4[i][j].gameObject.SetActive(false);
								}
							}
							else
							{
								this.EffectIcon4[i][j].gameObject.SetActive(true);
							}
						}
						if (this.mCDTimer[i][j] >= this.TimeParameters1 * (float)j + this.mEndTime[i][j] + this.mRes_Time * (float)(this.tmpResQty[i][j] + 1))
						{
							this.m_Itme2T[i][j].gameObject.SetActive(false);
						}
					}
					if (this.EffectIcon[i][j].gameObject.activeSelf)
					{
						if (this.mMoveKind[i][j] == 2)
						{
							this.m_IconRT[i][j].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[i][j], this.bezierCenter[i][j], this.bezierCenter2[i][j], this.bezierEnd[i][j], 1f / this.mEndTime[i][j], this.Timer[i][j] - this.TimeParameters1 * (float)j);
							if (this.Timer[i][j] > this.mEndTime[i][j] + this.TimeParameters1 * (float)j)
							{
								this.mMoveKind[i][j] = 0;
								this.HideIcon(i, j, false, false);
							}
						}
					}
					else if (this.mMoveKind[i][j] != 0 && this.Timer[i][j] > this.TimeParameters1 * (float)j)
					{
						this.EffectIcon[i][j].gameObject.SetActive(true);
					}
				}
				else if (this.mKindEnd[i][j] == 6 || this.mKindEnd[i][j] == 23 || this.mKindEnd[i][j] == 25 || this.mKindEnd[i][j] == 29)
				{
					if (this.m_Item[i][j - 7].gameObject.activeSelf)
					{
						if (this.mMoveKind[i][j] == 2)
						{
							this.m_ItemRT[i][j - 7].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[i][j], this.bezierCenter[i][j], this.bezierCenter2[i][j], this.bezierEnd[i][j], 1f / this.mEndTime[i][j], this.Timer[i][j] - this.TimeParameters1 * (float)(this.tmpKindLineNum[i] + (j - 7)));
							if (this.Timer[i][j] > this.mEndTime[i][j] + this.TimeParameters1 * (float)(this.tmpKindLineNum[i] + (j - 7)))
							{
								this.mMoveKind[i][j] = 0;
								this.HideIcon(i, j - 7, true, false);
							}
						}
					}
					else if (this.mMoveKind[i][j] != 0 && this.Timer[i][j] > this.TimeParameters1 * (float)(this.tmpKindLineNum[i] + (j - 7)))
					{
						this.m_Item[i][j - 7].gameObject.SetActive(true);
					}
				}
				else if (this.mKindEnd[i][j] == 7 || this.mKindEnd[i][j] == 26)
				{
					if (this.m_Item_L[i][j - 7].gameObject.activeSelf)
					{
						if (this.mMoveKind[i][j] == 2)
						{
							this.m_Item_LRT[i][j - 7].anchoredPosition = GameConstants.CubicBezierCurves(this.bezierStart[i][j], this.bezierCenter[i][j], this.bezierCenter2[i][j], this.bezierEnd[i][j], 1f / this.mEndTime[i][j], this.Timer[i][j] - this.TimeParameters1 * (float)(this.tmpKindLineNum[i] + (j - 7)));
							if (this.Timer[i][j] > this.mEndTime[i][j] + this.TimeParameters1 * (float)(this.tmpKindLineNum[i] + (j - 7)))
							{
								this.mMoveKind[i][j] = 0;
								this.HideIcon(i, j - 7, true, true);
							}
						}
					}
					else if (this.mMoveKind[i][j] != 0 && this.Timer[i][j] > this.TimeParameters1 * (float)(this.tmpKindLineNum[i] + (j - 7)))
					{
						this.m_Item_L[i][j - 7].gameObject.SetActive(true);
					}
				}
				if (this.m_Icon[i][j])
				{
					this.UpdateRunIcon(i, j);
				}
			}
		}
	}

	// Token: 0x06002A56 RID: 10838 RVA: 0x0046DD9C File Offset: 0x0046BF9C
	public void UpdateRunIcon(int i, int j)
	{
		this.ScaleParameters = 2f;
		switch (this.mKindEnd[i][j])
		{
		case 1:
			this.m_IconT = this.m_PowerImageT;
			goto IL_2D9;
		case 2:
			this.m_IconT = this.m_DiamondIconT;
			goto IL_2D9;
		case 3:
		case 23:
			this.m_IconT = this.m_MoraleIconT;
			goto IL_2D9;
		case 4:
			this.m_IconT = this.m_HeadImageT;
			this.ScaleParameters = 1f;
			goto IL_2D9;
		case 5:
			this.m_IconT = this.m_HeadImageT;
			this.ScaleParameters = 1f;
			goto IL_2D9;
		case 6:
			this.m_IconT = this.m_FuncButtonT[1];
			goto IL_2D9;
		case 8:
			this.m_IconT = this.m_FuncButtonT[0];
			goto IL_2D9;
		case 10:
			this.m_IconT = this.m_FuncButtonT[5];
			goto IL_2D9;
		case 11:
		case 22:
			this.m_IconT = this.mUITransform;
			goto IL_2D9;
		case 12:
			this.m_IconT = this.mUIGiftKeyValueform;
			goto IL_2D9;
		case 13:
			this.m_IconT = this.mUIGiftform;
			goto IL_2D9;
		case 15:
			this.m_IconT = this.m_VipIconT;
			goto IL_2D9;
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
			this.m_IconT = this.m_ResourceIconT[(int)(this.mKindEnd[i][j] - 16)];
			goto IL_2D9;
		case 27:
			if (this.mParticleEffect[i] != null)
			{
				ParticleManager.Instance.DeSpawn(this.mParticleEffect[i]);
				this.mParticleEffect[i] = null;
			}
			this.tmpKindEndNum[i][j] = 0;
			this.m_Icon[i][j] = false;
			this.mKindEnd[i][j] = 0;
			this.mCount[i]--;
			if (this.mCount[i] == 0)
			{
				this.m_ItmeTransform[i].gameObject.SetActive(false);
				this.mIteCount--;
				if (this.mIteCount == 0)
				{
					this.m_RectTransform.gameObject.SetActive(false);
				}
			}
			this.GUIM.UpdateUI(EGUIWindow.UI_CastleStrengthen, 2, 0);
			goto IL_2D9;
		}
		this.tmpKindEndNum[i][j] = 0;
		this.m_Icon[i][j] = false;
		this.mKindEnd[i][j] = 0;
		this.mCount[i]--;
		if (this.mCount[i] == 0)
		{
			this.m_ItmeTransform[i].gameObject.SetActive(false);
			this.mIteCount--;
			if (this.mIteCount == 0)
			{
				this.m_RectTransform.gameObject.SetActive(false);
			}
		}
		IL_2D9:
		if (this.m_IconT != null && !this.m_IconT.gameObject.activeSelf)
		{
			this.tmpKindEndNum[i][j] = 0;
			this.m_Icon[i][j] = false;
			this.mKindEnd[i][j] = 0;
			this.mCount[i]--;
			if (this.mCount[i] == 0)
			{
				this.m_ItmeTransform[i].gameObject.SetActive(false);
				this.mIteCount--;
				if (this.mIteCount == 0)
				{
					this.m_RectTransform.gameObject.SetActive(false);
				}
			}
		}
		if (this.m_IconT != null && this.tmpKindEndNum[i][j] > 0)
		{
			if (this.Timer[i][j] < 0.075f)
			{
				if (GUIManager.Instance.IsArabic && this.m_IconT == this.mUIGiftKeyValueform)
				{
					this.m_IconT.localScale = new Vector3(-(1f + this.Timer[i][j] * this.ScaleParameters), 1f + this.Timer[i][j] * this.ScaleParameters, 1f + this.Timer[i][j] * this.ScaleParameters);
				}
				else
				{
					this.m_IconT.localScale = new Vector3(1f + this.Timer[i][j] * this.ScaleParameters, 1f + this.Timer[i][j] * this.ScaleParameters, 1f + this.Timer[i][j] * this.ScaleParameters);
				}
			}
			else if (this.Timer[i][j] < 0.15f)
			{
				if (GUIManager.Instance.IsArabic && this.m_IconT == this.mUIGiftKeyValueform)
				{
					this.m_IconT.localScale = new Vector3(-(1.15f - this.Timer[i][j] * this.ScaleParameters), 1.15f - this.Timer[i][j] * this.ScaleParameters, 1.15f - this.Timer[i][j] * this.ScaleParameters);
				}
				else
				{
					this.m_IconT.localScale = new Vector3(1.15f - this.Timer[i][j] * this.ScaleParameters, 1.15f - this.Timer[i][j] * this.ScaleParameters, 1.15f - this.Timer[i][j] * this.ScaleParameters);
				}
			}
			else
			{
				if (this.m_IconT == this.mUIGiftKeyValueform && GUIManager.Instance.IsArabic)
				{
					this.m_IconT.localScale = new Vector3(-1f, 1f, 1f);
				}
				else
				{
					this.m_IconT.localScale = new Vector3(1f, 1f, 1f);
				}
				this.Timer[i][j] = 0f;
				byte[] array = this.tmpKindEndNum[i];
				array[j] -= 1;
				if (this.tmpKindEndNum[i][j] == 0)
				{
					this.m_Icon[i][j] = false;
					this.mKindEnd[i][j] = 0;
					this.mCount[i]--;
					if (this.mCount[i] == 0)
					{
						this.m_ItmeTransform[i].gameObject.SetActive(false);
						this.mIteCount--;
						if (this.mIteCount == 0)
						{
							this.m_RectTransform.gameObject.SetActive(false);
						}
					}
				}
			}
		}
	}

	// Token: 0x06002A57 RID: 10839 RVA: 0x0046E42C File Offset: 0x0046C62C
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (this.m_Item[i] != null && this.m_Item[i][j] != null && this.m_Item[i][j].enabled)
				{
					this.m_Item[i][j].Refresh_FontTexture();
				}
			}
		}
	}

	// Token: 0x040075DB RID: 30171
	private DataManager DM;

	// Token: 0x040075DC RID: 30172
	private GUIManager GUIM;

	// Token: 0x040075DD RID: 30173
	private Door door;

	// Token: 0x040075DE RID: 30174
	public RectTransform m_RectTransform;

	// Token: 0x040075DF RID: 30175
	public RectTransform mCanvasRT;

	// Token: 0x040075E0 RID: 30176
	public Transform[] m_ItmeTransform = new Transform[7];

	// Token: 0x040075E1 RID: 30177
	public Transform[][] m_Itme2T = new Transform[5][];

	// Token: 0x040075E2 RID: 30178
	public RectTransform[][] m_IconRT = new RectTransform[5][];

	// Token: 0x040075E3 RID: 30179
	public Image[][] EffectIcon = new Image[5][];

	// Token: 0x040075E4 RID: 30180
	public float[][] Timer = new float[5][];

	// Token: 0x040075E5 RID: 30181
	private Vector2[][] bezierStart = new Vector2[5][];

	// Token: 0x040075E6 RID: 30182
	private Vector2[][] bezierCenter = new Vector2[5][];

	// Token: 0x040075E7 RID: 30183
	private Vector2[][] bezierCenter2 = new Vector2[5][];

	// Token: 0x040075E8 RID: 30184
	private Vector2[][] bezierEnd = new Vector2[5][];

	// Token: 0x040075E9 RID: 30185
	public int mNum;

	// Token: 0x040075EA RID: 30186
	public int[] mCount = new int[5];

	// Token: 0x040075EB RID: 30187
	public int mIteCount;

	// Token: 0x040075EC RID: 30188
	public UIHIBtn[][] m_Item = new UIHIBtn[5][];

	// Token: 0x040075ED RID: 30189
	public UILEBtn[][] m_Item_L = new UILEBtn[5][];

	// Token: 0x040075EE RID: 30190
	public RectTransform[][] m_ItemRT = new RectTransform[5][];

	// Token: 0x040075EF RID: 30191
	public RectTransform[][] m_Item_LRT = new RectTransform[5][];

	// Token: 0x040075F0 RID: 30192
	public byte[][] mMoveKind = new byte[5][];

	// Token: 0x040075F1 RID: 30193
	public RectTransform m_BGRectTransform;

	// Token: 0x040075F2 RID: 30194
	public Image m_ImgBG;

	// Token: 0x040075F3 RID: 30195
	public float mBGTimer;

	// Token: 0x040075F4 RID: 30196
	public Vector2 UI_bezieEnd;

	// Token: 0x040075F5 RID: 30197
	public RectTransform[][] m_IconRT1 = new RectTransform[5][];

	// Token: 0x040075F6 RID: 30198
	public RectTransform[][] m_IconRT2 = new RectTransform[5][];

	// Token: 0x040075F7 RID: 30199
	public RectTransform[][] m_IconRT3 = new RectTransform[5][];

	// Token: 0x040075F8 RID: 30200
	public RectTransform[][] m_IconRT4 = new RectTransform[5][];

	// Token: 0x040075F9 RID: 30201
	public Image[][] EffectIcon1 = new Image[5][];

	// Token: 0x040075FA RID: 30202
	public Image[][] EffectIcon2 = new Image[5][];

	// Token: 0x040075FB RID: 30203
	public Image[][] EffectIcon3 = new Image[5][];

	// Token: 0x040075FC RID: 30204
	public Image[][] EffectIcon4 = new Image[5][];

	// Token: 0x040075FD RID: 30205
	private Equip tmpEQ;

	// Token: 0x040075FE RID: 30206
	public Vector2[][] mV2Start = new Vector2[5][];

	// Token: 0x040075FF RID: 30207
	private Material m_Mat;

	// Token: 0x04007600 RID: 30208
	public int tmpCountKind;

	// Token: 0x04007601 RID: 30209
	public float[][] mCDTimer = new float[5][];

	// Token: 0x04007602 RID: 30210
	public float mRes_Time = 0.1f;

	// Token: 0x04007603 RID: 30211
	public byte[][] tmpKindNum = new byte[5][];

	// Token: 0x04007604 RID: 30212
	public int[] tmpKindLineNum = new int[5];

	// Token: 0x04007605 RID: 30213
	public float TimeParameters1 = 0.5f;

	// Token: 0x04007606 RID: 30214
	public bool[][] m_Icon = new bool[5][];

	// Token: 0x04007607 RID: 30215
	public byte[][] mKindEnd = new byte[5][];

	// Token: 0x04007608 RID: 30216
	public Transform[] m_ResourceIconT = new Transform[5];

	// Token: 0x04007609 RID: 30217
	public Transform[] m_FuncButtonT = new Transform[6];

	// Token: 0x0400760A RID: 30218
	public Transform m_HeadImageT;

	// Token: 0x0400760B RID: 30219
	public Transform m_PowerImageT;

	// Token: 0x0400760C RID: 30220
	public Transform m_DiamondIconT;

	// Token: 0x0400760D RID: 30221
	public Transform m_MoraleIconT;

	// Token: 0x0400760E RID: 30222
	public Transform m_VipIconT;

	// Token: 0x0400760F RID: 30223
	public Transform m_IconT;

	// Token: 0x04007610 RID: 30224
	public byte[][] tmpResQty = new byte[5][];

	// Token: 0x04007611 RID: 30225
	public float ScaleParameters = 2f;

	// Token: 0x04007612 RID: 30226
	public byte[][] tmpKindEndNum = new byte[5][];

	// Token: 0x04007613 RID: 30227
	public uint[] mResValue = new uint[5];

	// Token: 0x04007614 RID: 30228
	public uint tmpResValue;

	// Token: 0x04007615 RID: 30229
	public uint mDiamondValue;

	// Token: 0x04007616 RID: 30230
	public Transform mUITransform;

	// Token: 0x04007617 RID: 30231
	public Transform mUIGiftform;

	// Token: 0x04007618 RID: 30232
	public Transform mUIGiftKeyValueform;

	// Token: 0x04007619 RID: 30233
	public bool mAddVIP;

	// Token: 0x0400761A RID: 30234
	public bool mAddGiftExp;

	// Token: 0x0400761B RID: 30235
	public bool mAddGiftPoint;

	// Token: 0x0400761C RID: 30236
	public Vector2 ItemV2;

	// Token: 0x0400761D RID: 30237
	public bool bShowImgBG = true;

	// Token: 0x0400761E RID: 30238
	public float[][] mEndTime = new float[5][];

	// Token: 0x0400761F RID: 30239
	private GameObject[] mParticleEffect = new GameObject[5];

	// Token: 0x04007620 RID: 30240
	public List<PlayerProfileEquip> mItemlist = new List<PlayerProfileEquip>();

	// Token: 0x04007621 RID: 30241
	public float m_ItemNextTime = 1f;
}
