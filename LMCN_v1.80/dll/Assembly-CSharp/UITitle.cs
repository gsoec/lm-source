using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006A1 RID: 1697
public class UITitle : GUIWindow, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler, IUIHIBtnClickHandler
{
	// Token: 0x06002068 RID: 8296 RVA: 0x003D5420 File Offset: 0x003D3620
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.TM = TitleManager.Instance;
		this.m_transform = base.transform;
		this.tmpFont = this.GM.GetTTFFont();
		this.m_transform.GetChild(5).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(5).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(5).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(5).GetComponent<CustomImage>().enabled = false;
		}
		this.GM.InitianHeroItemImg(this.m_transform.GetChild(4).GetChild(6), eHeroOrItem.Hero, 1, 5, 0, 0, true, true, true, false);
		this.Scroll = this.m_transform.GetChild(3).GetComponent<ScrollPanel>();
		for (int i = 0; i < 8; i++)
		{
			this.bFindScrollComp[i] = false;
		}
		this.OpenKind = (byte)arg1;
		if (this.OpenKind == 1)
		{
			this.NowTitleKind = eNowTitleKind.eKVK;
			this.bKingOpen = (DataManager.MapDataController.IsKing() && DataManager.MapDataController.IsInMyAllianceKingdom(false));
			this.bChiefOpen = (DataManager.MapDataController.IsKingdomChief() && DataManager.MapDataController.IsInMyAllianceKingdom(false));
			Transform child = this.m_transform.GetChild(1);
			child.gameObject.SetActive(true);
			this.m_transform.GetChild(6).gameObject.SetActive(true);
			this.m_transform.GetChild(6).GetComponent<UIButton>().m_Handler = this;
			this.m_transform.GetChild(6).gameObject.AddComponent<ArabicItemTextureRot>();
			this.rebuild_Title = child.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.rebuild_Title.font = this.tmpFont;
			this.rebuild_Title.text = this.DM.mStringTable.GetStringByID(9324u);
			this.GM.InitianHeroItemImg(child.GetChild(5), eHeroOrItem.Hero, this.TM.RecvTitleIcon[0], 5, 0, 0, true, false, true, false);
			if (this.TM.RecvTitleIcon[0] == 0)
			{
				child.GetChild(6).gameObject.SetActive(true);
				child.GetChild(5).gameObject.SetActive(false);
			}
			else
			{
				child.GetChild(5).GetComponent<UIHIBtn>().m_Handler = this;
				child.GetChild(5).GetComponent<UIHIBtn>().transition = Selectable.Transition.None;
			}
			UISpritesArray component = child.GetChild(7).GetComponent<UISpritesArray>();
			component.SetSpriteIndex(0);
			component = child.GetChild(7).GetChild(0).GetComponent<UISpritesArray>();
			component.SetSpriteIndex(0);
			TitleData recordByKey = this.DM.TitleData.GetRecordByKey(1);
			Image component2 = child.GetChild(10).GetComponent<Image>();
			component2.sprite = this.GM.LoadTitleSprite(recordByKey.IconID, eTitleKind.KvkTitle);
			component2.material = this.GM.GetTitleMaterial();
			this.KingNameStr = StringManager.Instance.SpawnString(150);
			this.KingNameStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.StringID));
			this.KingNameStr.StringToFormat(this.TM.RecvTitleName[0]);
			this.KingNameStr.AppendFormat(this.NameAppend);
			this.rebuild_Name = child.GetChild(11).GetComponent<UIText>();
			this.rebuild_Name.font = this.tmpFont;
			this.rebuild_Name.text = this.KingNameStr.ToString();
			this.KingEff1Str = StringManager.Instance.SpawnString(200);
			GameConstants.GetEffectValue(this.KingEff1Str, recordByKey.Effects[0].EffectID, (uint)recordByKey.Effects[0].Value, 14, 0f);
			this.rebuild_Eff[0] = child.GetChild(12).GetComponent<UIText>();
			this.rebuild_Eff[0].font = this.tmpFont;
			this.rebuild_Eff[0].text = this.KingEff1Str.ToString();
			if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey.Effects[0].EffectID).StatusIcon == 0)
			{
				this.rebuild_Eff[0].color = this.GoogEffColor;
			}
			else
			{
				this.rebuild_Eff[0].color = this.BadEffColor;
			}
			if (recordByKey.Effects[1].EffectID != 0)
			{
				this.KingEff2Str = StringManager.Instance.SpawnString(200);
				GameConstants.GetEffectValue(this.KingEff2Str, recordByKey.Effects[1].EffectID, (uint)recordByKey.Effects[1].Value, 14, 0f);
				this.rebuild_Eff[1] = child.GetChild(13).GetComponent<UIText>();
				this.rebuild_Eff[1].font = this.tmpFont;
				this.rebuild_Eff[1].text = this.KingEff2Str.ToString();
				if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey.Effects[1].EffectID).StatusIcon == 0)
				{
					this.rebuild_Eff[1].color = this.GoogEffColor;
				}
				else
				{
					this.rebuild_Eff[1].color = this.BadEffColor;
				}
			}
			else
			{
				this.rebuild_Eff[1].gameObject.SetActive(false);
			}
			if (recordByKey.Effects[2].EffectID != 0)
			{
				this.KingEff3Str = StringManager.Instance.SpawnString(200);
				GameConstants.GetEffectValue(this.KingEff3Str, recordByKey.Effects[2].EffectID, (uint)recordByKey.Effects[2].Value, 14, 0f);
				this.rebuild_Eff[2] = child.GetChild(14).GetComponent<UIText>();
				this.rebuild_Eff[2].font = this.tmpFont;
				this.rebuild_Eff[2].text = this.KingEff3Str.ToString();
				if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey.Effects[2].EffectID).StatusIcon == 0)
				{
					this.rebuild_Eff[2].color = this.GoogEffColor;
				}
				else
				{
					this.rebuild_Eff[2].color = this.BadEffColor;
				}
			}
			else
			{
				this.rebuild_Eff[2].gameObject.SetActive(false);
			}
			if (this.bKingOpen || this.bChiefOpen)
			{
				Vector2 b = new Vector2(62f, 0f);
				this.m_transform.GetChild(4).GetChild(5).GetComponent<RectTransform>().anchoredPosition -= b;
				this.m_transform.GetChild(4).GetChild(6).GetComponent<RectTransform>().anchoredPosition -= b;
				this.m_transform.GetChild(4).GetChild(9).GetComponent<RectTransform>().anchoredPosition -= b;
				b = new Vector2(19f, 0f);
				this.m_transform.GetChild(4).GetChild(1).GetComponent<RectTransform>().anchoredPosition -= b;
				this.m_transform.GetChild(4).GetChild(2).GetComponent<RectTransform>().anchoredPosition -= b;
				this.m_transform.GetChild(4).GetChild(3).GetComponent<RectTransform>().anchoredPosition -= b;
				this.m_transform.GetChild(4).GetChild(4).GetComponent<RectTransform>().anchoredPosition -= b;
				this.m_transform.GetChild(4).GetChild(10).GetComponent<RectTransform>().anchoredPosition -= b;
			}
			this.Scroll.IntiScrollPanel(381f, 0f, 0f, this.NowHeightList, 8, this);
		}
		else if (this.OpenKind == 2)
		{
			this.NowTitleKind = eNowTitleKind.eKVK;
			this.bKingOpen = true;
			this.bChiefOpen = DataManager.MapDataController.IsKingdomChief();
			Transform child = this.m_transform.GetChild(2);
			child.gameObject.SetActive(true);
			this.rebuild_Title = child.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.rebuild_Title.font = this.tmpFont;
			this.rebuild_Title.text = this.DM.mStringTable.GetStringByID(9348u);
			RectTransform component3 = this.m_transform.GetChild(3).GetComponent<RectTransform>();
			component3.anchoredPosition = new Vector2(0f, -44f);
			component3.sizeDelta = new Vector2(829f, 526f);
			Vector2 b2 = new Vector2(62f, 0f);
			this.m_transform.GetChild(4).GetChild(5).GetComponent<RectTransform>().anchoredPosition -= b2;
			this.m_transform.GetChild(4).GetChild(6).GetComponent<RectTransform>().anchoredPosition -= b2;
			this.m_transform.GetChild(4).GetChild(9).GetComponent<RectTransform>().anchoredPosition -= b2;
			b2 = new Vector2(19f, 0f);
			this.m_transform.GetChild(4).GetChild(1).GetComponent<RectTransform>().anchoredPosition -= b2;
			this.m_transform.GetChild(4).GetChild(2).GetComponent<RectTransform>().anchoredPosition -= b2;
			this.m_transform.GetChild(4).GetChild(3).GetComponent<RectTransform>().anchoredPosition -= b2;
			this.m_transform.GetChild(4).GetChild(4).GetComponent<RectTransform>().anchoredPosition -= b2;
			this.m_transform.GetChild(4).GetChild(10).GetComponent<RectTransform>().anchoredPosition -= b2;
			this.Scroll.IntiScrollPanel(526f, 0f, 0f, this.NowHeightList, 8, this);
		}
		else if (this.OpenKind == 3)
		{
			this.NowTitleKind = eNowTitleKind.eWorld;
			this.bKingOpen = DataManager.MapDataController.IsWorldKing();
			this.bChiefOpen = DataManager.MapDataController.IsWorldChief();
			Transform child = this.m_transform.GetChild(1);
			child.gameObject.SetActive(true);
			this.m_transform.GetChild(6).gameObject.SetActive(true);
			this.m_transform.GetChild(6).GetComponent<UIButton>().m_Handler = this;
			this.m_transform.GetChild(6).gameObject.AddComponent<ArabicItemTextureRot>();
			this.rebuild_Title = child.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.rebuild_Title.font = this.tmpFont;
			this.rebuild_Title.text = this.DM.mStringTable.GetStringByID(11028u);
			this.GM.InitianHeroItemImg(child.GetChild(5), eHeroOrItem.Hero, this.TM.RecvTitleIconW[0], 5, 0, 0, true, false, true, false);
			if (this.TM.RecvTitleIconW[0] == 0)
			{
				child.GetChild(6).gameObject.SetActive(true);
				child.GetChild(5).gameObject.SetActive(false);
			}
			else
			{
				child.GetChild(5).GetComponent<UIHIBtn>().m_Handler = this;
				child.GetChild(5).GetComponent<UIHIBtn>().transition = Selectable.Transition.None;
			}
			child.GetChild(7).gameObject.SetActive(false);
			child.GetChild(8).gameObject.SetActive(true);
			TitleData recordByKey2 = this.DM.TitleDataW.GetRecordByKey(1);
			Image component2 = child.GetChild(10).GetComponent<Image>();
			component2.sprite = this.GM.LoadTitleSprite(recordByKey2.IconID, eTitleKind.WorldTitle);
			component2.material = this.GM.GetTitleMaterial();
			this.KingNameStr = StringManager.Instance.SpawnString(150);
			this.KingNameStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey2.StringID));
			this.KingNameStr.StringToFormat(this.TM.RecvTitleNameW[0]);
			this.KingNameStr.AppendFormat(this.NameAppend);
			this.rebuild_Name = child.GetChild(11).GetComponent<UIText>();
			this.rebuild_Name.font = this.tmpFont;
			this.rebuild_Name.text = this.KingNameStr.ToString();
			this.KingEff1Str = StringManager.Instance.SpawnString(200);
			GameConstants.GetEffectValue(this.KingEff1Str, recordByKey2.Effects[0].EffectID, (uint)recordByKey2.Effects[0].Value, 14, 0f);
			this.rebuild_Eff[0] = child.GetChild(12).GetComponent<UIText>();
			this.rebuild_Eff[0].font = this.tmpFont;
			this.rebuild_Eff[0].text = this.KingEff1Str.ToString();
			if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey2.Effects[0].EffectID).StatusIcon == 0)
			{
				this.rebuild_Eff[0].color = this.GoogEffColor;
			}
			else
			{
				this.rebuild_Eff[0].color = this.BadEffColor;
			}
			if (recordByKey2.Effects[1].EffectID != 0)
			{
				this.KingEff2Str = StringManager.Instance.SpawnString(200);
				GameConstants.GetEffectValue(this.KingEff2Str, recordByKey2.Effects[1].EffectID, (uint)recordByKey2.Effects[1].Value, 14, 0f);
				this.rebuild_Eff[1] = child.GetChild(13).GetComponent<UIText>();
				this.rebuild_Eff[1].font = this.tmpFont;
				this.rebuild_Eff[1].text = this.KingEff2Str.ToString();
				if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey2.Effects[1].EffectID).StatusIcon == 0)
				{
					this.rebuild_Eff[1].color = this.GoogEffColor;
				}
				else
				{
					this.rebuild_Eff[1].color = this.BadEffColor;
				}
			}
			else
			{
				this.rebuild_Eff[1].gameObject.SetActive(false);
			}
			if (recordByKey2.Effects[2].EffectID != 0)
			{
				this.KingEff3Str = StringManager.Instance.SpawnString(200);
				GameConstants.GetEffectValue(this.KingEff3Str, recordByKey2.Effects[2].EffectID, (uint)recordByKey2.Effects[2].Value, 14, 0f);
				this.rebuild_Eff[2] = child.GetChild(14).GetComponent<UIText>();
				this.rebuild_Eff[2].font = this.tmpFont;
				this.rebuild_Eff[2].text = this.KingEff3Str.ToString();
				if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey2.Effects[2].EffectID).StatusIcon == 0)
				{
					this.rebuild_Eff[2].color = this.GoogEffColor;
				}
				else
				{
					this.rebuild_Eff[2].color = this.BadEffColor;
				}
			}
			else
			{
				this.rebuild_Eff[2].gameObject.SetActive(false);
			}
			if (this.bKingOpen || this.bChiefOpen)
			{
				Vector2 b3 = new Vector2(62f, 0f);
				this.m_transform.GetChild(4).GetChild(5).GetComponent<RectTransform>().anchoredPosition -= b3;
				this.m_transform.GetChild(4).GetChild(6).GetComponent<RectTransform>().anchoredPosition -= b3;
				this.m_transform.GetChild(4).GetChild(9).GetComponent<RectTransform>().anchoredPosition -= b3;
				b3 = new Vector2(19f, 0f);
				this.m_transform.GetChild(4).GetChild(1).GetComponent<RectTransform>().anchoredPosition -= b3;
				this.m_transform.GetChild(4).GetChild(2).GetComponent<RectTransform>().anchoredPosition -= b3;
				this.m_transform.GetChild(4).GetChild(3).GetComponent<RectTransform>().anchoredPosition -= b3;
				this.m_transform.GetChild(4).GetChild(4).GetComponent<RectTransform>().anchoredPosition -= b3;
				this.m_transform.GetChild(4).GetChild(10).GetComponent<RectTransform>().anchoredPosition -= b3;
			}
			this.Scroll.IntiScrollPanel(381f, 0f, 0f, this.NowHeightList, 8, this);
		}
		else if (this.OpenKind == 4)
		{
			this.NowTitleKind = eNowTitleKind.eWorld;
			this.bKingOpen = true;
			this.bChiefOpen = DataManager.MapDataController.IsWorldChief();
			Transform child = this.m_transform.GetChild(2);
			child.gameObject.SetActive(true);
			this.rebuild_Title = child.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.rebuild_Title.font = this.tmpFont;
			this.rebuild_Title.text = this.DM.mStringTable.GetStringByID(11028u);
			RectTransform component4 = this.m_transform.GetChild(3).GetComponent<RectTransform>();
			component4.anchoredPosition = new Vector2(0f, -44f);
			component4.sizeDelta = new Vector2(829f, 526f);
			Vector2 b4 = new Vector2(62f, 0f);
			this.m_transform.GetChild(4).GetChild(5).GetComponent<RectTransform>().anchoredPosition -= b4;
			this.m_transform.GetChild(4).GetChild(6).GetComponent<RectTransform>().anchoredPosition -= b4;
			this.m_transform.GetChild(4).GetChild(9).GetComponent<RectTransform>().anchoredPosition -= b4;
			b4 = new Vector2(19f, 0f);
			this.m_transform.GetChild(4).GetChild(1).GetComponent<RectTransform>().anchoredPosition -= b4;
			this.m_transform.GetChild(4).GetChild(2).GetComponent<RectTransform>().anchoredPosition -= b4;
			this.m_transform.GetChild(4).GetChild(3).GetComponent<RectTransform>().anchoredPosition -= b4;
			this.m_transform.GetChild(4).GetChild(4).GetComponent<RectTransform>().anchoredPosition -= b4;
			this.m_transform.GetChild(4).GetChild(10).GetComponent<RectTransform>().anchoredPosition -= b4;
			this.Scroll.IntiScrollPanel(526f, 0f, 0f, this.NowHeightList, 8, this);
		}
		else if (this.OpenKind == 5)
		{
			this.NowTitleKind = eNowTitleKind.eNational;
			this.bKingOpen = DataManager.MapDataController.IsWorldKing();
			this.bChiefOpen = DataManager.MapDataController.IsWorldChief();
			Transform child = this.m_transform.GetChild(1);
			child.gameObject.SetActive(true);
			this.m_transform.GetChild(6).gameObject.SetActive(true);
			this.m_transform.GetChild(6).GetComponent<UIButton>().m_Handler = this;
			this.m_transform.GetChild(6).gameObject.AddComponent<ArabicItemTextureRot>();
			this.rebuild_Title = child.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.rebuild_Title.font = this.tmpFont;
			this.rebuild_Title.text = this.DM.mStringTable.GetStringByID(11027u);
			this.GM.InitianHeroItemImg(child.GetChild(5), eHeroOrItem.Hero, this.TM.WKIcon, 5, 0, 0, true, false, true, false);
			if (this.TM.WKIcon == 0)
			{
				child.GetChild(6).gameObject.SetActive(true);
				child.GetChild(5).gameObject.SetActive(false);
			}
			else
			{
				child.GetChild(5).GetComponent<UIHIBtn>().m_Handler = this;
				child.GetChild(5).GetComponent<UIHIBtn>().transition = Selectable.Transition.None;
			}
			child.GetChild(7).gameObject.SetActive(false);
			child.GetChild(8).gameObject.SetActive(true);
			TitleData recordByKey3 = this.DM.TitleDataW.GetRecordByKey(1);
			Image component2 = child.GetChild(10).GetComponent<Image>();
			component2.sprite = this.GM.LoadTitleSprite(recordByKey3.IconID, eTitleKind.WorldTitle);
			component2.material = this.GM.GetTitleMaterial();
			this.KingNameStr = StringManager.Instance.SpawnString(150);
			this.KingNameStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey3.StringID));
			this.KingNameStr.StringToFormat(this.TM.WKName);
			this.KingNameStr.AppendFormat(this.NameAppend);
			this.rebuild_Name = child.GetChild(11).GetComponent<UIText>();
			this.rebuild_Name.font = this.tmpFont;
			this.rebuild_Name.text = this.KingNameStr.ToString();
			this.rebuild_Name.rectTransform.anchoredPosition += new Vector2(0f, -40f);
			child.GetChild(12).gameObject.SetActive(false);
			child.GetChild(13).gameObject.SetActive(false);
			child.GetChild(14).gameObject.SetActive(false);
			if (this.bKingOpen || this.bChiefOpen)
			{
				Vector2 b5 = new Vector2(62f, 0f);
				this.m_transform.GetChild(4).GetChild(5).GetComponent<RectTransform>().anchoredPosition -= b5;
				this.m_transform.GetChild(4).GetChild(6).GetComponent<RectTransform>().anchoredPosition -= b5;
				this.m_transform.GetChild(4).GetChild(9).GetComponent<RectTransform>().anchoredPosition -= b5;
				b5 = new Vector2(19f, 0f);
				this.m_transform.GetChild(4).GetChild(1).GetComponent<RectTransform>().anchoredPosition -= b5;
				this.m_transform.GetChild(4).GetChild(2).GetComponent<RectTransform>().anchoredPosition -= b5;
				this.m_transform.GetChild(4).GetChild(3).GetComponent<RectTransform>().anchoredPosition -= b5;
				this.m_transform.GetChild(4).GetChild(4).GetComponent<RectTransform>().anchoredPosition -= b5;
				this.m_transform.GetChild(4).GetChild(10).GetComponent<RectTransform>().anchoredPosition -= b5;
			}
			this.Scroll.IntiScrollPanel(381f, 0f, 0f, this.NowHeightList, 8, this);
		}
		else if (this.OpenKind == 6)
		{
			this.NowTitleKind = eNowTitleKind.eNational;
			this.bKingOpen = true;
			this.bChiefOpen = DataManager.MapDataController.IsWorldChief();
			Transform child = this.m_transform.GetChild(2);
			child.gameObject.SetActive(true);
			this.rebuild_Title = child.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.rebuild_Title.font = this.tmpFont;
			this.rebuild_Title.text = this.DM.mStringTable.GetStringByID(11027u);
			RectTransform component5 = this.m_transform.GetChild(3).GetComponent<RectTransform>();
			component5.anchoredPosition = new Vector2(0f, -44f);
			component5.sizeDelta = new Vector2(829f, 526f);
			Vector2 b6 = new Vector2(62f, 0f);
			this.m_transform.GetChild(4).GetChild(5).GetComponent<RectTransform>().anchoredPosition -= b6;
			this.m_transform.GetChild(4).GetChild(6).GetComponent<RectTransform>().anchoredPosition -= b6;
			this.m_transform.GetChild(4).GetChild(9).GetComponent<RectTransform>().anchoredPosition -= b6;
			b6 = new Vector2(19f, 0f);
			this.m_transform.GetChild(4).GetChild(1).GetComponent<RectTransform>().anchoredPosition -= b6;
			this.m_transform.GetChild(4).GetChild(2).GetComponent<RectTransform>().anchoredPosition -= b6;
			this.m_transform.GetChild(4).GetChild(3).GetComponent<RectTransform>().anchoredPosition -= b6;
			this.m_transform.GetChild(4).GetChild(4).GetComponent<RectTransform>().anchoredPosition -= b6;
			this.m_transform.GetChild(4).GetChild(10).GetComponent<RectTransform>().anchoredPosition -= b6;
			this.Scroll.IntiScrollPanel(526f, 0f, 0f, this.NowHeightList, 8, this);
		}
		else if (this.OpenKind == 7)
		{
			this.NowTitleKind = eNowTitleKind.eNobility;
			this.bKingOpen = (DataManager.MapDataController.IsNobilityKing() && this.TM.OpenWonderID == (ushort)ActivityManager.Instance.FederalActKingdomWonderID);
			this.bChiefOpen = (DataManager.MapDataController.IsNobilityChief() && this.TM.OpenWonderID == (ushort)ActivityManager.Instance.FederalActKingdomWonderID);
			Transform child = this.m_transform.GetChild(1);
			child.gameObject.SetActive(true);
			this.m_transform.GetChild(6).gameObject.SetActive(true);
			this.m_transform.GetChild(6).GetComponent<UIButton>().m_Handler = this;
			this.m_transform.GetChild(6).gameObject.AddComponent<ArabicItemTextureRot>();
			this.rebuild_Title = child.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.rebuild_Title.font = this.tmpFont;
			this.rebuild_Title.text = this.DM.mStringTable.GetStringByID(11059u);
			this.GM.InitianHeroItemImg(child.GetChild(5), eHeroOrItem.Hero, this.TM.RecvNobilityTitleIcon[0], 5, 0, 0, true, false, true, false);
			if (this.TM.RecvNobilityTitleIcon[0] == 0)
			{
				child.GetChild(6).gameObject.SetActive(true);
				child.GetChild(5).gameObject.SetActive(false);
			}
			else
			{
				child.GetChild(5).GetComponent<UIHIBtn>().m_Handler = this;
				child.GetChild(5).GetComponent<UIHIBtn>().transition = Selectable.Transition.None;
			}
			child.GetChild(7).gameObject.SetActive(false);
			child.GetChild(9).gameObject.SetActive(true);
			TitleData recordByKey4 = this.DM.TitleDataF.GetRecordByKey(1);
			Image component2 = child.GetChild(10).GetComponent<Image>();
			component2.sprite = this.GM.LoadTitleSprite(recordByKey4.IconID, eTitleKind.NobilityTitle);
			component2.material = this.GM.GetTitleMaterial();
			this.KingNameStr = StringManager.Instance.SpawnString(150);
			this.KingNameStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey4.StringID));
			this.KingNameStr.StringToFormat(this.TM.RecvNobilityTitleName[0]);
			this.KingNameStr.AppendFormat(this.NameAppend);
			this.rebuild_Name = child.GetChild(11).GetComponent<UIText>();
			this.rebuild_Name.font = this.tmpFont;
			this.rebuild_Name.text = this.KingNameStr.ToString();
			this.KingEff1Str = StringManager.Instance.SpawnString(200);
			GameConstants.GetEffectValue(this.KingEff1Str, recordByKey4.Effects[0].EffectID, (uint)recordByKey4.Effects[0].Value, 14, 0f);
			this.rebuild_Eff[0] = child.GetChild(12).GetComponent<UIText>();
			this.rebuild_Eff[0].font = this.tmpFont;
			this.rebuild_Eff[0].text = this.KingEff1Str.ToString();
			if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey4.Effects[0].EffectID).StatusIcon == 0)
			{
				this.rebuild_Eff[0].color = this.GoogEffColor;
			}
			else
			{
				this.rebuild_Eff[0].color = this.BadEffColor;
			}
			if (recordByKey4.Effects[1].EffectID != 0)
			{
				this.KingEff2Str = StringManager.Instance.SpawnString(200);
				GameConstants.GetEffectValue(this.KingEff2Str, recordByKey4.Effects[1].EffectID, (uint)recordByKey4.Effects[1].Value, 14, 0f);
				this.rebuild_Eff[1] = child.GetChild(13).GetComponent<UIText>();
				this.rebuild_Eff[1].font = this.tmpFont;
				this.rebuild_Eff[1].text = this.KingEff2Str.ToString();
				if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey4.Effects[1].EffectID).StatusIcon == 0)
				{
					this.rebuild_Eff[1].color = this.GoogEffColor;
				}
				else
				{
					this.rebuild_Eff[1].color = this.BadEffColor;
				}
			}
			else
			{
				this.rebuild_Eff[1].gameObject.SetActive(false);
			}
			if (recordByKey4.Effects[2].EffectID != 0)
			{
				this.KingEff3Str = StringManager.Instance.SpawnString(200);
				GameConstants.GetEffectValue(this.KingEff3Str, recordByKey4.Effects[2].EffectID, (uint)recordByKey4.Effects[2].Value, 14, 0f);
				this.rebuild_Eff[2] = child.GetChild(14).GetComponent<UIText>();
				this.rebuild_Eff[2].font = this.tmpFont;
				this.rebuild_Eff[2].text = this.KingEff3Str.ToString();
				if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey4.Effects[2].EffectID).StatusIcon == 0)
				{
					this.rebuild_Eff[2].color = this.GoogEffColor;
				}
				else
				{
					this.rebuild_Eff[2].color = this.BadEffColor;
				}
			}
			else
			{
				this.rebuild_Eff[2].gameObject.SetActive(false);
			}
			if (this.bKingOpen || this.bChiefOpen)
			{
				Vector2 b7 = new Vector2(62f, 0f);
				this.m_transform.GetChild(4).GetChild(5).GetComponent<RectTransform>().anchoredPosition -= b7;
				this.m_transform.GetChild(4).GetChild(6).GetComponent<RectTransform>().anchoredPosition -= b7;
				this.m_transform.GetChild(4).GetChild(9).GetComponent<RectTransform>().anchoredPosition -= b7;
				b7 = new Vector2(19f, 0f);
				this.m_transform.GetChild(4).GetChild(1).GetComponent<RectTransform>().anchoredPosition -= b7;
				this.m_transform.GetChild(4).GetChild(2).GetComponent<RectTransform>().anchoredPosition -= b7;
				this.m_transform.GetChild(4).GetChild(3).GetComponent<RectTransform>().anchoredPosition -= b7;
				this.m_transform.GetChild(4).GetChild(4).GetComponent<RectTransform>().anchoredPosition -= b7;
				this.m_transform.GetChild(4).GetChild(10).GetComponent<RectTransform>().anchoredPosition -= b7;
			}
			this.Scroll.IntiScrollPanel(381f, 0f, 0f, this.NowHeightList, 8, this);
		}
		else if (this.OpenKind == 8)
		{
			this.NowTitleKind = eNowTitleKind.eNobility;
			this.bKingOpen = true;
			this.bChiefOpen = DataManager.MapDataController.IsNobilityChief();
			Transform child = this.m_transform.GetChild(2);
			child.gameObject.SetActive(true);
			this.rebuild_Title = child.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.rebuild_Title.font = this.tmpFont;
			this.rebuild_Title.text = this.DM.mStringTable.GetStringByID(11059u);
			RectTransform component6 = this.m_transform.GetChild(3).GetComponent<RectTransform>();
			component6.anchoredPosition = new Vector2(0f, -44f);
			component6.sizeDelta = new Vector2(829f, 526f);
			Vector2 b8 = new Vector2(62f, 0f);
			this.m_transform.GetChild(4).GetChild(5).GetComponent<RectTransform>().anchoredPosition -= b8;
			this.m_transform.GetChild(4).GetChild(6).GetComponent<RectTransform>().anchoredPosition -= b8;
			this.m_transform.GetChild(4).GetChild(9).GetComponent<RectTransform>().anchoredPosition -= b8;
			b8 = new Vector2(19f, 0f);
			this.m_transform.GetChild(4).GetChild(1).GetComponent<RectTransform>().anchoredPosition -= b8;
			this.m_transform.GetChild(4).GetChild(2).GetComponent<RectTransform>().anchoredPosition -= b8;
			this.m_transform.GetChild(4).GetChild(3).GetComponent<RectTransform>().anchoredPosition -= b8;
			this.m_transform.GetChild(4).GetChild(4).GetComponent<RectTransform>().anchoredPosition -= b8;
			this.m_transform.GetChild(4).GetChild(10).GetComponent<RectTransform>().anchoredPosition -= b8;
			this.Scroll.IntiScrollPanel(526f, 0f, 0f, this.NowHeightList, 8, this);
		}
		this.RefreshList(true, true);
		if (this.TM.WaitTitleList == 0)
		{
			this.TM.WaitTitleList = this.OpenKind;
			if (this.NowTitleKind == eNowTitleKind.eKVK)
			{
				this.TM.Send_KingdomTitle_List();
			}
			else if (this.NowTitleKind == eNowTitleKind.eWorld)
			{
				this.TM.Send_WorldTitle_List();
			}
			else if (this.NowTitleKind == eNowTitleKind.eNational)
			{
				this.TM.Send_NationalTitle_List();
			}
			else if (this.NowTitleKind == eNowTitleKind.eNobility)
			{
				if (this.OpenKind == 7)
				{
					this.TM.Send_NobilityTitle_List_King(this.TM.OpenWonderID);
				}
				else if (ActivityManager.Instance.CheckCanonizationNoility(DataManager.MapDataController.OtherKingdomData.kingdomID))
				{
					this.TM.Send_NobilityTitle_List();
				}
				else
				{
					this.TM.Send_NobilityTitle_List_King((ushort)ActivityManager.Instance.FederalActKingdomWonderID);
				}
			}
		}
		this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
		if ((int)this.OpenKind <= this.TM.NowTitleIndex.Length && this.TM.NowTitleIndex[(int)(this.OpenKind - 1)] != -1)
		{
			this.Scroll.GoTo(this.TM.NowTitleIndex[(int)(this.OpenKind - 1)], this.TM.NowTitlePos[(int)(this.OpenKind - 1)]);
		}
		this.GM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06002069 RID: 8297 RVA: 0x003D7A74 File Offset: 0x003D5C74
	public override void OnClose()
	{
		if ((int)this.OpenKind <= this.TM.NowTitleIndex.Length)
		{
			this.TM.NowTitleIndex[(int)(this.OpenKind - 1)] = this.Scroll.GetTopIdx();
			this.TM.NowTitlePos[(int)(this.OpenKind - 1)] = this.cScrollRect.content.anchoredPosition.y;
		}
		for (int i = 7; i >= 0; i--)
		{
			if (this.bFindScrollComp[i])
			{
				if (this.ScrollComp[i].ShowNameStr != null)
				{
					StringManager.Instance.DeSpawnString(this.ScrollComp[i].ShowNameStr);
					this.ScrollComp[i].ShowNameStr = null;
				}
				if (this.ScrollComp[i].Eff1Str != null)
				{
					StringManager.Instance.DeSpawnString(this.ScrollComp[i].Eff1Str);
					this.ScrollComp[i].Eff1Str = null;
				}
				if (this.ScrollComp[i].Eff2Str != null)
				{
					StringManager.Instance.DeSpawnString(this.ScrollComp[i].Eff2Str);
					this.ScrollComp[i].Eff2Str = null;
				}
				if (this.ScrollComp[i].Eff3Str != null)
				{
					StringManager.Instance.DeSpawnString(this.ScrollComp[i].Eff3Str);
					this.ScrollComp[i].Eff3Str = null;
				}
			}
		}
		if (this.KingNameStr != null)
		{
			StringManager.Instance.DeSpawnString(this.KingNameStr);
		}
		if (this.KingEff1Str != null)
		{
			StringManager.Instance.DeSpawnString(this.KingEff1Str);
		}
		if (this.KingEff2Str != null)
		{
			StringManager.Instance.DeSpawnString(this.KingEff2Str);
		}
		if (this.KingEff3Str != null)
		{
			StringManager.Instance.DeSpawnString(this.KingEff3Str);
		}
	}

	// Token: 0x0600206A RID: 8298 RVA: 0x003D7C84 File Offset: 0x003D5E84
	private void RefreshList(bool GoToTop = true, bool bStopMove = true)
	{
		int num = 0;
		if (this.NowTitleKind == eNowTitleKind.eKVK)
		{
			num = this.TM.RecvTitleIcon.Length - 1;
		}
		else if (this.NowTitleKind == eNowTitleKind.eWorld)
		{
			num = this.TM.RecvTitleIconW.Length - 1;
		}
		else if (this.NowTitleKind == eNowTitleKind.eNational)
		{
			num = this.TM.RecvTitleKingdomID.Length;
		}
		else if (this.NowTitleKind == eNowTitleKind.eNobility)
		{
			num = this.TM.RecvNobilityTitleIcon.Length - 1;
		}
		this.NowHeightList.Clear();
		TitleData recordByKey = this.DM.TitleData.GetRecordByKey(1);
		for (int i = 0; i < num; i++)
		{
			int num2 = (int)this.DM.TitleSortData.GetRecordByIndex(i + 1).TitleID[(int)this.NowTitleKind];
			if (this.NowTitleKind == eNowTitleKind.eKVK)
			{
				recordByKey = this.DM.TitleData.GetRecordByKey((ushort)num2);
			}
			else if (this.NowTitleKind == eNowTitleKind.eWorld)
			{
				recordByKey = this.DM.TitleDataW.GetRecordByKey((ushort)num2);
			}
			else if (this.NowTitleKind == eNowTitleKind.eNational)
			{
				recordByKey = this.DM.TitleDataN.GetRecordByKey((ushort)num2);
			}
			else if (this.NowTitleKind == eNowTitleKind.eNobility)
			{
				recordByKey = this.DM.TitleDataF.GetRecordByKey((ushort)num2);
			}
			if (recordByKey.Effects[2].EffectID > 0)
			{
				this.NowHeightList.Add(125f);
			}
			else
			{
				this.NowHeightList.Add(100f);
			}
		}
		if (this.NowHeightList.Count > 0)
		{
			this.Scroll.AddNewDataHeight(this.NowHeightList, GoToTop, bStopMove);
		}
	}

	// Token: 0x0600206B RID: 8299 RVA: 0x003D7E54 File Offset: 0x003D6054
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				for (int i = 0; i < 3; i++)
				{
					if (this.rebuild_Eff != null && this.rebuild_Eff[i] != null && this.rebuild_Eff[i].enabled)
					{
						this.rebuild_Eff[i].enabled = false;
						this.rebuild_Eff[i].enabled = true;
					}
				}
				if (this.rebuild_Title != null && this.rebuild_Title.enabled)
				{
					this.rebuild_Title.enabled = false;
					this.rebuild_Title.enabled = true;
				}
				if (this.rebuild_Name != null && this.rebuild_Name.enabled)
				{
					this.rebuild_Name.enabled = false;
					this.rebuild_Name.enabled = true;
				}
				for (int j = 0; j < 8; j++)
				{
					if (this.bFindScrollComp[j])
					{
						if (this.ScrollComp[j].PlayerName != null && this.ScrollComp[j].PlayerName.enabled)
						{
							this.ScrollComp[j].PlayerName.enabled = false;
							this.ScrollComp[j].PlayerName.enabled = true;
						}
						if (this.ScrollComp[j].Eff1 != null && this.ScrollComp[j].Eff1.enabled)
						{
							this.ScrollComp[j].Eff1.enabled = false;
							this.ScrollComp[j].Eff1.enabled = true;
						}
						if (this.ScrollComp[j].Eff2 != null && this.ScrollComp[j].Eff2.enabled)
						{
							this.ScrollComp[j].Eff2.enabled = false;
							this.ScrollComp[j].Eff2.enabled = true;
						}
						if (this.ScrollComp[j].Eff3 != null && this.ScrollComp[j].Eff3.enabled)
						{
							this.ScrollComp[j].Eff3.enabled = false;
							this.ScrollComp[j].Eff3.enabled = true;
						}
						if (this.ScrollComp[j].BigText != null && this.ScrollComp[j].BigText.enabled)
						{
							this.ScrollComp[j].BigText.enabled = false;
							this.ScrollComp[j].BigText.enabled = true;
						}
					}
				}
			}
		}
		else
		{
			this.SendNewData();
		}
	}

	// Token: 0x0600206C RID: 8300 RVA: 0x003D8174 File Offset: 0x003D6374
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 0:
			this.RefreshList(false, false);
			break;
		case 1:
			if (this.OpenKind == 1 || this.OpenKind == 2)
			{
				this.RefreshList(false, false);
			}
			break;
		case 2:
			if (this.OpenKind == 3 || this.OpenKind == 4)
			{
				this.RefreshList(false, false);
			}
			break;
		case 3:
			if (this.OpenKind == 7 || this.OpenKind == 8)
			{
				this.RefreshList(false, false);
			}
			break;
		case 4:
			this.SendNewData();
			break;
		}
	}

	// Token: 0x0600206D RID: 8301 RVA: 0x003D822C File Offset: 0x003D642C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < 8)
		{
			if (!this.bFindScrollComp[panelObjectIdx])
			{
				this.bFindScrollComp[panelObjectIdx] = true;
				Transform transform = item.transform;
				this.ScrollComp[panelObjectIdx].BaseRC = transform.GetComponent<RectTransform>();
				this.ScrollComp[panelObjectIdx].BackSA = transform.GetChild(0).GetComponent<UISpritesArray>();
				this.ScrollComp[panelObjectIdx].RankImage = transform.GetChild(1).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].RankImage.material = this.GM.GetTitleMaterial();
				this.ScrollComp[panelObjectIdx].PlayerName = transform.GetChild(2).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].PlayerName.font = this.tmpFont;
				this.ScrollComp[panelObjectIdx].Eff1 = transform.GetChild(3).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].Eff1.font = this.tmpFont;
				this.ScrollComp[panelObjectIdx].Eff2 = transform.GetChild(4).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].Eff2.font = this.tmpFont;
				this.ScrollComp[panelObjectIdx].Eff3 = transform.GetChild(10).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].Eff3.font = this.tmpFont;
				this.ScrollComp[panelObjectIdx].PlayerPic = transform.GetChild(6).GetComponent<UIHIBtn>();
				this.ScrollComp[panelObjectIdx].PlayerBack = transform.GetChild(5).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].ShowNameStr = StringManager.Instance.SpawnString(150);
				this.ScrollComp[panelObjectIdx].Eff1Str = StringManager.Instance.SpawnString(200);
				this.ScrollComp[panelObjectIdx].Eff2Str = StringManager.Instance.SpawnString(200);
				this.ScrollComp[panelObjectIdx].Eff3Str = StringManager.Instance.SpawnString(200);
				transform.GetChild(7).GetComponent<UIButton>().m_Handler = this;
				this.ScrollComp[panelObjectIdx].BigText = transform.GetChild(8).GetChild(0).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].BigText.font = this.tmpFont;
				this.ScrollComp[panelObjectIdx].NoPic = transform.GetChild(9).GetComponent<Image>();
				if (this.NowTitleKind == eNowTitleKind.eNational)
				{
					transform.GetChild(9).GetComponent<UISpritesArray>().SetSpriteIndex(1);
				}
				if ((this.OpenKind == 1 || this.OpenKind == 3 || this.OpenKind == 5 || this.OpenKind == 7) && !this.bKingOpen && !this.bChiefOpen)
				{
					this.ScrollComp[panelObjectIdx].LastBtn = transform.GetChild(7).GetComponent<UIButton>();
					this.ScrollComp[panelObjectIdx].LastBtn.m_Handler = this;
					this.ScrollComp[panelObjectIdx].LastBtn.gameObject.SetActive(true);
				}
				else
				{
					this.ScrollComp[panelObjectIdx].LastBtn = transform.GetChild(8).GetComponent<UIButton>();
					this.ScrollComp[panelObjectIdx].LastBtn.m_Handler = this;
					this.ScrollComp[panelObjectIdx].LastBtn.gameObject.SetActive(true);
				}
				if (this.bKingOpen || this.bChiefOpen)
				{
					this.ScrollComp[panelObjectIdx].BigText.text = this.DM.mStringTable.GetStringByID(7010u);
				}
			}
			TitleData recordByKey = this.DM.TitleData.GetRecordByKey(1);
			if (this.NowTitleKind == eNowTitleKind.eKVK)
			{
				dataIdx = (int)(this.DM.TitleSortData.GetRecordByIndex(dataIdx + 1).TitleID[(int)this.NowTitleKind] - 1);
				if (dataIdx < 0 || dataIdx >= this.TM.RecvTitleIcon.Length)
				{
					return;
				}
				recordByKey = this.DM.TitleData.GetRecordByKey((ushort)(dataIdx + 1));
				if ((int)recordByKey.ID != dataIdx + 1)
				{
					return;
				}
				this.ScrollComp[panelObjectIdx].RankImage.sprite = this.GM.LoadTitleSprite(recordByKey.IconID, eTitleKind.KvkTitle);
			}
			else if (this.NowTitleKind == eNowTitleKind.eWorld)
			{
				dataIdx = (int)(this.DM.TitleSortData.GetRecordByIndex(dataIdx + 1).TitleID[(int)this.NowTitleKind] - 1);
				if (dataIdx < 0 || dataIdx >= this.TM.RecvTitleIconW.Length)
				{
					return;
				}
				recordByKey = this.DM.TitleDataW.GetRecordByKey((ushort)(dataIdx + 1));
				if ((int)recordByKey.ID != dataIdx + 1)
				{
					return;
				}
				this.ScrollComp[panelObjectIdx].RankImage.sprite = this.GM.LoadTitleSprite(recordByKey.IconID, eTitleKind.WorldTitle);
			}
			else if (this.NowTitleKind == eNowTitleKind.eNational)
			{
				dataIdx = (int)(this.DM.TitleSortData.GetRecordByIndex(dataIdx).TitleID[(int)this.NowTitleKind] - 1);
				if (dataIdx < 0 || dataIdx >= this.TM.RecvTitleKingdomID.Length)
				{
					return;
				}
				recordByKey = this.DM.TitleDataN.GetRecordByKey((ushort)(dataIdx + 1));
				if ((int)recordByKey.ID != dataIdx + 1)
				{
					return;
				}
				this.ScrollComp[panelObjectIdx].RankImage.sprite = this.GM.LoadTitleSprite(recordByKey.IconID, eTitleKind.KingdomTitle);
			}
			else if (this.NowTitleKind == eNowTitleKind.eNobility)
			{
				dataIdx = (int)(this.DM.TitleSortData.GetRecordByIndex(dataIdx + 1).TitleID[(int)this.NowTitleKind] - 1);
				if (dataIdx < 0 || dataIdx >= this.TM.RecvNobilityTitleIcon.Length)
				{
					return;
				}
				recordByKey = this.DM.TitleDataF.GetRecordByKey((ushort)(dataIdx + 1));
				if ((int)recordByKey.ID != dataIdx + 1)
				{
					return;
				}
				this.ScrollComp[panelObjectIdx].RankImage.sprite = this.GM.LoadTitleSprite(recordByKey.IconID, eTitleKind.NobilityTitle);
			}
			this.ScrollComp[panelObjectIdx].BackSA.SetSpriteIndex((int)recordByKey.isDebuff);
			this.ScrollComp[panelObjectIdx].LastBtn.m_BtnID2 = dataIdx;
			if (this.GetIcon(dataIdx) != 0)
			{
				this.ScrollComp[panelObjectIdx].ShowNameStr.Length = 0;
				this.ScrollComp[panelObjectIdx].ShowNameStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.StringID));
				this.ScrollComp[panelObjectIdx].ShowNameStr.StringToFormat(this.GetTitleName(dataIdx));
				this.ScrollComp[panelObjectIdx].ShowNameStr.AppendFormat(this.NameAppend);
				this.ScrollComp[panelObjectIdx].PlayerPic.gameObject.SetActive(true);
				this.ScrollComp[panelObjectIdx].PlayerBack.gameObject.SetActive(true);
				this.ScrollComp[panelObjectIdx].NoPic.gameObject.SetActive(false);
				if (this.NowTitleKind == eNowTitleKind.eNational)
				{
					GUIManager.Instance.ChangeWonderImg(this.ScrollComp[panelObjectIdx].PlayerPic.transform, 0, this.GetIcon(dataIdx));
				}
				else
				{
					this.GM.ChangeHeroItemImg(this.ScrollComp[panelObjectIdx].PlayerPic.transform, eHeroOrItem.Hero, this.GetIcon(dataIdx), 5, 0, 0);
				}
				if (this.OpenKind == 1 || this.OpenKind == 3 || this.OpenKind == 7)
				{
					this.ScrollComp[panelObjectIdx].LastBtn.gameObject.SetActive(true);
					if (this.bChiefOpen)
					{
						if (DataManager.CompareStr(this.DM.RoleAttr.Name, this.GetTitleNameNoTag(dataIdx)) == 0)
						{
							this.ScrollComp[panelObjectIdx].LastBtn.interactable = false;
							this.ScrollComp[panelObjectIdx].BigText.color = Color.gray;
						}
						else
						{
							this.ScrollComp[panelObjectIdx].LastBtn.interactable = true;
							this.ScrollComp[panelObjectIdx].BigText.color = Color.white;
						}
					}
				}
				else if (this.OpenKind == 2 || this.OpenKind == 4 || this.OpenKind == 8)
				{
					this.ScrollComp[panelObjectIdx].LastBtn.gameObject.SetActive(true);
					this.ScrollComp[panelObjectIdx].BigText.text = this.DM.mStringTable.GetStringByID(9349u);
					if (DataManager.CompareStr(this.GetOpenTitleName(), this.GetTitleNameNoTag(dataIdx)) == 0 || (this.bChiefOpen && DataManager.CompareStr(this.DM.RoleAttr.Name, this.GetTitleNameNoTag(dataIdx)) == 0))
					{
						this.ScrollComp[panelObjectIdx].LastBtn.interactable = false;
						this.ScrollComp[panelObjectIdx].BigText.color = Color.gray;
					}
					else
					{
						this.ScrollComp[panelObjectIdx].LastBtn.interactable = true;
						this.ScrollComp[panelObjectIdx].BigText.color = Color.white;
					}
				}
				else if (this.OpenKind == 5)
				{
					this.ScrollComp[panelObjectIdx].LastBtn.gameObject.SetActive(false);
				}
				else if (this.OpenKind == 6)
				{
					this.ScrollComp[panelObjectIdx].LastBtn.gameObject.SetActive(false);
				}
			}
			else
			{
				this.ScrollComp[panelObjectIdx].ShowNameStr.Length = 0;
				this.ScrollComp[panelObjectIdx].ShowNameStr.Append(this.DM.mStringTable.GetStringByID((uint)recordByKey.StringID));
				this.ScrollComp[panelObjectIdx].PlayerPic.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].PlayerBack.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].NoPic.gameObject.SetActive(true);
				if (this.OpenKind == 1 || this.OpenKind == 3 || this.OpenKind == 5 || this.OpenKind == 7)
				{
					this.ScrollComp[panelObjectIdx].LastBtn.gameObject.SetActive(false);
				}
				else if (this.OpenKind == 2 || this.OpenKind == 4 || this.OpenKind == 6 || this.OpenKind == 8)
				{
					this.ScrollComp[panelObjectIdx].LastBtn.gameObject.SetActive(true);
					this.ScrollComp[panelObjectIdx].BigText.text = this.DM.mStringTable.GetStringByID(9350u);
					this.ScrollComp[panelObjectIdx].LastBtn.interactable = true;
					this.ScrollComp[panelObjectIdx].BigText.color = Color.white;
				}
			}
			this.ScrollComp[panelObjectIdx].PlayerName.text = this.ScrollComp[panelObjectIdx].ShowNameStr.ToString();
			this.ScrollComp[panelObjectIdx].PlayerName.SetAllDirty();
			this.ScrollComp[panelObjectIdx].PlayerName.cachedTextGenerator.Invalidate();
			if (recordByKey.Effects[0].EffectID != 0)
			{
				this.ScrollComp[panelObjectIdx].Eff1Str.Length = 0;
				GameConstants.GetEffectValue(this.ScrollComp[panelObjectIdx].Eff1Str, recordByKey.Effects[0].EffectID, (uint)recordByKey.Effects[0].Value, 14, 0f);
				this.ScrollComp[panelObjectIdx].Eff1.text = this.ScrollComp[panelObjectIdx].Eff1Str.ToString();
				this.ScrollComp[panelObjectIdx].Eff1.SetAllDirty();
				this.ScrollComp[panelObjectIdx].Eff1.cachedTextGenerator.Invalidate();
				if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey.Effects[0].EffectID).StatusIcon == 0)
				{
					this.ScrollComp[panelObjectIdx].Eff1.color = this.GoogEffColor;
				}
				else
				{
					this.ScrollComp[panelObjectIdx].Eff1.color = this.BadEffColor;
				}
			}
			else
			{
				this.ScrollComp[panelObjectIdx].Eff1.gameObject.SetActive(false);
			}
			if (recordByKey.Effects[1].EffectID != 0)
			{
				this.ScrollComp[panelObjectIdx].Eff2.gameObject.SetActive(true);
				this.ScrollComp[panelObjectIdx].Eff2Str.Length = 0;
				GameConstants.GetEffectValue(this.ScrollComp[panelObjectIdx].Eff2Str, recordByKey.Effects[1].EffectID, (uint)recordByKey.Effects[1].Value, 14, 0f);
				this.ScrollComp[panelObjectIdx].Eff2.text = this.ScrollComp[panelObjectIdx].Eff2Str.ToString();
				this.ScrollComp[panelObjectIdx].Eff2.SetAllDirty();
				this.ScrollComp[panelObjectIdx].Eff2.cachedTextGenerator.Invalidate();
				if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey.Effects[1].EffectID).StatusIcon == 0)
				{
					this.ScrollComp[panelObjectIdx].Eff2.color = this.GoogEffColor;
				}
				else
				{
					this.ScrollComp[panelObjectIdx].Eff2.color = this.BadEffColor;
				}
			}
			else
			{
				this.ScrollComp[panelObjectIdx].Eff2.gameObject.SetActive(false);
			}
			if (recordByKey.Effects[2].EffectID != 0)
			{
				this.ScrollComp[panelObjectIdx].BaseRC.sizeDelta = new Vector2(829f, 125f);
				this.ScrollComp[panelObjectIdx].Eff3.gameObject.SetActive(true);
				this.ScrollComp[panelObjectIdx].Eff3Str.Length = 0;
				GameConstants.GetEffectValue(this.ScrollComp[panelObjectIdx].Eff3Str, recordByKey.Effects[2].EffectID, (uint)recordByKey.Effects[2].Value, 14, 0f);
				this.ScrollComp[panelObjectIdx].Eff3.text = this.ScrollComp[panelObjectIdx].Eff3Str.ToString();
				this.ScrollComp[panelObjectIdx].Eff3.SetAllDirty();
				this.ScrollComp[panelObjectIdx].Eff3.cachedTextGenerator.Invalidate();
				if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey.Effects[2].EffectID).StatusIcon == 0)
				{
					this.ScrollComp[panelObjectIdx].Eff3.color = this.GoogEffColor;
				}
				else
				{
					this.ScrollComp[panelObjectIdx].Eff3.color = this.BadEffColor;
				}
			}
			else
			{
				this.ScrollComp[panelObjectIdx].BaseRC.sizeDelta = new Vector2(829f, 100f);
				this.ScrollComp[panelObjectIdx].Eff3.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x0600206E RID: 8302 RVA: 0x003D92F8 File Offset: 0x003D74F8
	private void SendNewData()
	{
		if (this.bKingOpen || this.bChiefOpen)
		{
			if (this.OpenKind == 1)
			{
				this.TM.Send_KingdomTitle_List();
			}
			else if (this.OpenKind == 2)
			{
				if (DataManager.MapDataController.kingdomData.kingdomID != DataManager.MapDataController.FocusKingdomID)
				{
					this.TM.Send_KingdomTitle_List_King();
				}
				else
				{
					this.TM.Send_KingdomTitle_List();
				}
			}
			else if (this.OpenKind == 3 || this.OpenKind == 4)
			{
				this.TM.Send_WorldTitle_List();
			}
			else if (this.OpenKind == 7)
			{
				this.TM.Send_NobilityTitle_List_King(this.TM.OpenWonderID);
			}
			else if (this.OpenKind == 8)
			{
				if (ActivityManager.Instance.CheckCanonizationNoility(DataManager.MapDataController.OtherKingdomData.kingdomID))
				{
					this.TM.Send_NobilityTitle_List();
				}
				else
				{
					this.TM.Send_NobilityTitle_List_King((ushort)ActivityManager.Instance.FederalActKingdomWonderID);
				}
			}
		}
	}

	// Token: 0x0600206F RID: 8303 RVA: 0x003D9420 File Offset: 0x003D7620
	private bool CheckDataLength(int dataIdx)
	{
		if (this.NowTitleKind == eNowTitleKind.eKVK)
		{
			if (dataIdx < 0 || dataIdx >= this.TM.RecvTitleIcon.Length)
			{
				return false;
			}
		}
		else if (this.NowTitleKind == eNowTitleKind.eWorld)
		{
			if (dataIdx < 0 || dataIdx >= this.TM.RecvTitleIconW.Length)
			{
				return false;
			}
		}
		else if (this.NowTitleKind == eNowTitleKind.eNational)
		{
			if (dataIdx < 0 || dataIdx >= this.TM.RecvTitleKingdomID.Length)
			{
				return false;
			}
		}
		else if (this.NowTitleKind == eNowTitleKind.eNobility && (dataIdx < 0 || dataIdx >= this.TM.RecvNobilityTitleIcon.Length))
		{
			return false;
		}
		return true;
	}

	// Token: 0x06002070 RID: 8304 RVA: 0x003D94DC File Offset: 0x003D76DC
	private ushort GetIcon(int dataIdx)
	{
		if (this.NowTitleKind == eNowTitleKind.eKVK)
		{
			if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleIcon.Length)
			{
				return this.TM.RecvTitleIcon[dataIdx];
			}
		}
		else if (this.NowTitleKind == eNowTitleKind.eWorld)
		{
			if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleIconW.Length)
			{
				return this.TM.RecvTitleIconW[dataIdx];
			}
		}
		else if (this.NowTitleKind == eNowTitleKind.eNational)
		{
			if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleKingdomID.Length)
			{
				return this.TM.RecvTitleKingdomID[dataIdx];
			}
		}
		else if (this.NowTitleKind == eNowTitleKind.eNobility && dataIdx >= 0 && dataIdx < this.TM.RecvNobilityTitleIcon.Length)
		{
			return this.TM.RecvNobilityTitleIcon[dataIdx];
		}
		return 0;
	}

	// Token: 0x06002071 RID: 8305 RVA: 0x003D95C8 File Offset: 0x003D77C8
	private CString GetOpenTitleName()
	{
		if (this.NowTitleKind == eNowTitleKind.eKVK)
		{
			return this.TM.OpenTitleName;
		}
		if (this.NowTitleKind == eNowTitleKind.eWorld)
		{
			return this.TM.OpenTitleNameW;
		}
		if (this.NowTitleKind == eNowTitleKind.eNobility)
		{
			return this.TM.OpenNobilityTitleName;
		}
		return null;
	}

	// Token: 0x06002072 RID: 8306 RVA: 0x003D9620 File Offset: 0x003D7820
	private CString GetTitleName(int dataIdx)
	{
		if (this.NowTitleKind == eNowTitleKind.eKVK)
		{
			if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleName.Length)
			{
				return this.TM.RecvTitleName[dataIdx];
			}
		}
		else if (this.NowTitleKind == eNowTitleKind.eWorld)
		{
			if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleNameW.Length)
			{
				return this.TM.RecvTitleNameW[dataIdx];
			}
		}
		else if (this.NowTitleKind == eNowTitleKind.eNational)
		{
			if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleNameN.Length)
			{
				return this.TM.RecvTitleNameN[dataIdx];
			}
		}
		else if (this.NowTitleKind == eNowTitleKind.eNobility && dataIdx >= 0 && dataIdx < this.TM.RecvNobilityTitleName.Length)
		{
			return this.TM.RecvNobilityTitleName[dataIdx];
		}
		return null;
	}

	// Token: 0x06002073 RID: 8307 RVA: 0x003D970C File Offset: 0x003D790C
	private CString GetTitleNameNoTag(int dataIdx)
	{
		if (this.NowTitleKind == eNowTitleKind.eKVK)
		{
			if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleNameNoTag.Length)
			{
				return this.TM.RecvTitleNameNoTag[dataIdx];
			}
		}
		else if (this.NowTitleKind == eNowTitleKind.eWorld)
		{
			if (dataIdx >= 0 && dataIdx < this.TM.RecvTitleNameNoTagW.Length)
			{
				return this.TM.RecvTitleNameNoTagW[dataIdx];
			}
		}
		else if (this.NowTitleKind == eNowTitleKind.eNobility && dataIdx >= 0 && dataIdx < this.TM.RecvNobilityTitleNameNoTag.Length)
		{
			return this.TM.RecvNobilityTitleNameNoTag[dataIdx];
		}
		return null;
	}

	// Token: 0x06002074 RID: 8308 RVA: 0x003D97C0 File Offset: 0x003D79C0
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		if (this.OpenKind == 1)
		{
			dataIndex = (int)(this.DM.TitleSortData.GetRecordByIndex(dataIndex + 1).TitleID[(int)this.NowTitleKind] - 1);
			if (dataIndex < 0 || dataIndex >= this.TM.RecvTitleIcon.Length || this.TM.RecvTitleIcon[dataIndex] == 0)
			{
				return;
			}
			if (this.GM.FindMenu(EGUIWindow.UI_LordInfo))
			{
				this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
			}
			DataManager.Instance.ShowLordProfile(this.TM.RecvTitleNameNoTag[dataIndex].ToString());
		}
		else if (this.OpenKind == 3)
		{
			dataIndex = (int)(this.DM.TitleSortData.GetRecordByIndex(dataIndex + 1).TitleID[(int)this.NowTitleKind] - 1);
			if (dataIndex < 0 || dataIndex >= this.TM.RecvTitleIconW.Length || this.TM.RecvTitleIconW[dataIndex] == 0)
			{
				return;
			}
			if (this.GM.FindMenu(EGUIWindow.UI_LordInfo))
			{
				this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
			}
			DataManager.Instance.ShowLordProfile(this.TM.RecvTitleNameNoTagW[dataIndex].ToString());
		}
		else if (this.OpenKind == 7)
		{
			dataIndex = (int)(this.DM.TitleSortData.GetRecordByIndex(dataIndex + 1).TitleID[(int)this.NowTitleKind] - 1);
			if (dataIndex < 0 || dataIndex >= this.TM.RecvNobilityTitleIcon.Length || this.TM.RecvNobilityTitleIcon[dataIndex] == 0)
			{
				return;
			}
			if (this.GM.FindMenu(EGUIWindow.UI_LordInfo))
			{
				this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
			}
			DataManager.Instance.ShowLordProfile(this.TM.RecvNobilityTitleNameNoTag[dataIndex].ToString());
		}
	}

	// Token: 0x06002075 RID: 8309 RVA: 0x003D99B4 File Offset: 0x003D7BB4
	public void OnButtonClick(UIButton sender)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (sender.m_BtnID1 == 1)
		{
			if (door)
			{
				door.CloseMenu(false);
			}
		}
		else if (sender.m_BtnID1 == 2)
		{
			int btnID = sender.m_BtnID2;
			if (this.OpenKind == 1)
			{
				if (btnID < 0 || btnID >= this.TM.RecvTitleIcon.Length)
				{
					return;
				}
				if (this.GM.FindMenu(EGUIWindow.UI_LordInfo))
				{
					this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
				}
				DataManager.Instance.ShowLordProfile(this.TM.RecvTitleNameNoTag[btnID].ToString());
			}
			else if (this.OpenKind == 3)
			{
				if (btnID < 0 || btnID >= this.TM.RecvTitleIconW.Length)
				{
					return;
				}
				if (this.GM.FindMenu(EGUIWindow.UI_LordInfo))
				{
					this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
				}
				DataManager.Instance.ShowLordProfile(this.TM.RecvTitleNameNoTagW[btnID].ToString());
			}
			else if (this.OpenKind == 7)
			{
				if (btnID < 0 || btnID >= this.TM.RecvNobilityTitleIcon.Length)
				{
					return;
				}
				if (this.GM.FindMenu(EGUIWindow.UI_LordInfo))
				{
					this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
				}
				DataManager.Instance.ShowLordProfile(this.TM.RecvNobilityTitleNameNoTag[btnID].ToString());
			}
		}
		else if (sender.m_BtnID1 == 3)
		{
			int btnID2 = sender.m_BtnID2;
			if (!this.CheckDataLength(btnID2))
			{
				return;
			}
			if (this.NowTitleKind == eNowTitleKind.eKVK)
			{
				if (this.OpenKind == 1 && (this.bKingOpen || this.bChiefOpen))
				{
					this.TM.Send_KingdomTitle_Remove((ushort)(btnID2 + 1));
				}
				else
				{
					this.TM.Send_KingdomTitle_Change((ushort)(btnID2 + 1));
				}
			}
			else if (this.NowTitleKind == eNowTitleKind.eWorld)
			{
				if (this.OpenKind == 3 && (this.bKingOpen || this.bChiefOpen))
				{
					this.TM.Send_WorldTitle_Remove((ushort)(btnID2 + 1));
				}
				else
				{
					this.TM.Send_WorldTitle_Change((ushort)(btnID2 + 1));
				}
			}
			else if (this.OpenKind == 6)
			{
				this.tmpDadaIndex = btnID2;
				this.GM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(9350u), this.DM.mStringTable.GetStringByID(11009u), 0, 0, this.DM.mStringTable.GetStringByID(3925u), this.DM.mStringTable.GetStringByID(3926u));
			}
			else if (this.NowTitleKind == eNowTitleKind.eNobility)
			{
				if (this.OpenKind == 7 && (this.bKingOpen || this.bChiefOpen))
				{
					this.TM.Send_NobilityTitle_Remove((ushort)(btnID2 + 1));
				}
				else
				{
					this.TM.Send_NobilityTitle_Change((ushort)(btnID2 + 1));
				}
			}
		}
		else if (sender.m_BtnID1 == 4)
		{
			if (this.NowTitleKind == eNowTitleKind.eKVK)
			{
				this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(9324u), this.DM.mStringTable.GetStringByID(9367u), null, null, 0, 0, false, true);
			}
			else if (this.NowTitleKind == eNowTitleKind.eWorld)
			{
				this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(11028u), this.DM.mStringTable.GetStringByID(11005u), null, null, 0, 0, false, true);
			}
			else if (this.NowTitleKind == eNowTitleKind.eNational)
			{
				this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(11027u), this.DM.mStringTable.GetStringByID(11006u), null, null, 0, 0, false, true);
			}
			else if (this.NowTitleKind == eNowTitleKind.eNobility)
			{
				this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(11059u), this.DM.mStringTable.GetStringByID(11076u), null, null, 0, 0, false, true);
			}
		}
	}

	// Token: 0x06002076 RID: 8310 RVA: 0x003D9E20 File Offset: 0x003D8020
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			this.TM.Send_NationalTitle_Change(this.TM.OpenKingdomID, (ushort)(this.tmpDadaIndex + 1));
		}
	}

	// Token: 0x06002077 RID: 8311 RVA: 0x003D9E48 File Offset: 0x003D8048
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (sender.m_BtnID1 == 5)
		{
			if (this.GM.FindMenu(EGUIWindow.UI_LordInfo))
			{
				this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
			}
			if (this.OpenKind == 1)
			{
				DataManager.Instance.ShowLordProfile(this.TM.RecvTitleNameNoTag[0].ToString());
			}
			else if (this.OpenKind == 3)
			{
				DataManager.Instance.ShowLordProfile(this.TM.RecvTitleNameNoTagW[0].ToString());
			}
			else if (this.OpenKind == 5)
			{
				DataManager.Instance.ShowLordProfile(this.TM.WKNameNoTag.ToString());
			}
			else if (this.OpenKind == 7)
			{
				DataManager.Instance.ShowLordProfile(this.TM.RecvNobilityTitleNameNoTag[0].ToString());
			}
		}
	}

	// Token: 0x06002078 RID: 8312 RVA: 0x003D9F34 File Offset: 0x003D8134
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x0400664E RID: 26190
	private const int UnitCount = 8;

	// Token: 0x0400664F RID: 26191
	private Transform m_transform;

	// Token: 0x04006650 RID: 26192
	private DataManager DM;

	// Token: 0x04006651 RID: 26193
	private GUIManager GM;

	// Token: 0x04006652 RID: 26194
	private TitleManager TM;

	// Token: 0x04006653 RID: 26195
	private Font tmpFont;

	// Token: 0x04006654 RID: 26196
	private ScrollPanel Scroll;

	// Token: 0x04006655 RID: 26197
	private CScrollRect cScrollRect;

	// Token: 0x04006656 RID: 26198
	private List<float> NowHeightList = new List<float>();

	// Token: 0x04006657 RID: 26199
	private byte OpenKind;

	// Token: 0x04006658 RID: 26200
	private eNowTitleKind NowTitleKind = eNowTitleKind.Max;

	// Token: 0x04006659 RID: 26201
	private bool[] bFindScrollComp = new bool[8];

	// Token: 0x0400665A RID: 26202
	private UnitComp_Title[] ScrollComp = new UnitComp_Title[8];

	// Token: 0x0400665B RID: 26203
	private CString KingNameStr;

	// Token: 0x0400665C RID: 26204
	private CString KingEff1Str;

	// Token: 0x0400665D RID: 26205
	private CString KingEff2Str;

	// Token: 0x0400665E RID: 26206
	private CString KingEff3Str;

	// Token: 0x0400665F RID: 26207
	private UIText rebuild_Title;

	// Token: 0x04006660 RID: 26208
	private UIText rebuild_Name;

	// Token: 0x04006661 RID: 26209
	private UIText[] rebuild_Eff = new UIText[3];

	// Token: 0x04006662 RID: 26210
	private string NameAppend = "{0} <color=#FFF373>{1}</color>";

	// Token: 0x04006663 RID: 26211
	private Color GoogEffColor = new Color(0.2078f, 0.9686f, 0.4235f);

	// Token: 0x04006664 RID: 26212
	private Color BadEffColor = new Color(1f, 0.3294f, 0.4157f);

	// Token: 0x04006665 RID: 26213
	private bool bKingOpen;

	// Token: 0x04006666 RID: 26214
	private bool bChiefOpen;

	// Token: 0x04006667 RID: 26215
	private int tmpDadaIndex;
}
