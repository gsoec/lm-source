using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006C1 RID: 1729
public class UIWonderLand : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06002113 RID: 8467 RVA: 0x003ED91C File Offset: 0x003EBB1C
	public override void OnOpen(int arg1, int arg2)
	{
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.door.UpdateUI(1, 2);
		Image component = base.transform.GetChild(1).GetChild(6).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			((RectTransform)base.transform.GetChild(3)).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)base.transform.GetChild(3)).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
			component.enabled = false;
		}
		component = base.transform.GetChild(1).GetChild(6).GetChild(0).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close");
		component.material = this.door.LoadMaterial();
		component = base.transform.GetChild(3).GetChild(0).GetChild(4).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close");
		component.material = this.door.LoadMaterial();
		this.m_scroll = base.transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<ScrollPanel>();
		this.m_scroll.IntiScrollPanel(298f, 6f, 0f, this.ItemsHeight, 6, this);
		base.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(19).GetChild(5).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(20).GetChild(4).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(20).GetChild(3).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(20).GetChild(2).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(20).GetChild(1).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(20).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(6).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(3).GetChild(0).GetChild(4).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(21).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(16).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(14).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(3).GetComponent<UIButton>().m_Handler = this;
		this.m_label[18] = base.transform.GetChild(3).GetChild(0).GetChild(3).GetChild(1).GetComponent<Text>();
		this.m_label[18].font = GUIManager.Instance.GetTTFFont();
		this.m_label[17] = base.transform.GetChild(3).GetChild(0).GetChild(2).GetComponent<Text>();
		this.m_label[17].font = GUIManager.Instance.GetTTFFont();
		this.m_label[16] = base.transform.GetChild(1).GetChild(19).GetChild(14).GetComponent<Text>();
		this.m_label[16].font = GUIManager.Instance.GetTTFFont();
		this.m_label[15] = base.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>();
		this.m_label[15].font = GUIManager.Instance.GetTTFFont();
		this.m_label[0] = base.transform.GetChild(1).GetChild(15).GetChild(0).GetComponent<Text>();
		this.m_label[0].font = GUIManager.Instance.GetTTFFont();
		this.m_label[1] = base.transform.GetChild(1).GetChild(15).GetChild(1).GetComponent<Text>();
		this.m_label[1].font = GUIManager.Instance.GetTTFFont();
		this.m_label[2] = base.transform.GetChild(1).GetChild(15).GetChild(2).GetComponent<Text>();
		this.m_label[2].font = GUIManager.Instance.GetTTFFont();
		Vector2 anchoredPosition = this.m_label[2].rectTransform.anchoredPosition;
		anchoredPosition.x = 150f;
		this.m_label[2].rectTransform.anchoredPosition = anchoredPosition;
		this.m_label[3] = base.transform.GetChild(1).GetChild(15).GetChild(3).GetComponent<Text>();
		this.m_label[3].font = GUIManager.Instance.GetTTFFont();
		this.m_label[27] = base.transform.GetChild(1).GetChild(15).GetChild(4).GetComponent<Text>();
		this.m_label[27].font = GUIManager.Instance.GetTTFFont();
		this.m_label[26] = base.transform.GetChild(1).GetChild(23).GetChild(0).GetComponent<Text>();
		this.m_label[26].font = GUIManager.Instance.GetTTFFont();
		this.m_label[25] = base.transform.GetChild(1).GetChild(24).GetChild(0).GetComponent<Text>();
		this.m_label[25].font = GUIManager.Instance.GetTTFFont();
		this.m_label[4] = base.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(0).GetComponent<Text>();
		this.m_label[4].font = GUIManager.Instance.GetTTFFont();
		this.m_label[5] = base.transform.GetChild(1).GetChild(19).GetChild(5).GetChild(0).GetComponent<Text>();
		this.m_label[5].font = GUIManager.Instance.GetTTFFont();
		this.m_label[5].rectTransform.sizeDelta -= new Vector2(70f, 10f);
		this.m_label[6] = base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(0).GetChild(0).GetComponent<Text>();
		this.m_label[6].font = GUIManager.Instance.GetTTFFont();
		this.m_label[7] = base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(0).GetChild(1).GetComponent<Text>();
		this.m_label[7].font = GUIManager.Instance.GetTTFFont();
		this.m_label[8] = base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(2).GetComponent<Text>();
		this.m_label[8].font = GUIManager.Instance.GetTTFFont();
		this.m_label[9] = base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(6).GetComponent<Text>();
		this.m_label[9].font = GUIManager.Instance.GetTTFFont();
		this.m_label[10] = base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(7).GetComponent<Text>();
		this.m_label[10].font = GUIManager.Instance.GetTTFFont();
		this.m_label[11] = base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(8).GetComponent<Text>();
		this.m_label[11].font = GUIManager.Instance.GetTTFFont();
		this.m_label[12] = base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(9).GetComponent<Text>();
		this.m_label[12].font = GUIManager.Instance.GetTTFFont();
		this.m_label[13] = base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(10).GetComponent<Text>();
		this.m_label[13].font = GUIManager.Instance.GetTTFFont();
		this.m_label[14] = base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(11).GetComponent<Text>();
		this.m_label[14].font = GUIManager.Instance.GetTTFFont();
		this.m_CrownBack = base.transform.GetChild(1).GetChild(19).GetChild(9).GetChild(0).GetComponent<Image>();
		this.m_Dukedom = base.transform.GetChild(1).GetChild(19).GetChild(15).GetChild(0).GetComponent<Image>();
		this.m_Defeater = base.transform.GetChild(1).GetChild(19).GetChild(10).GetChild(0).GetComponent<Image>();
		this.m_MyEmperor = base.transform.GetChild(1).GetChild(19).GetChild(12).GetChild(0).GetComponent<Image>();
		this.m_UIHint = base.transform.GetChild(1).GetChild(22).gameObject.AddComponent<UIButtonHint>();
		this.m_WorldWarZ = base.transform.GetChild(1).GetChild(23).GetComponent<Image>();
		this.m_WorldPiss = base.transform.GetChild(1).GetChild(24).GetComponent<Image>();
		this.m_UIHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_UIHint.m_Handler = this;
		for (int i = 0; i < 7; i++)
		{
			this.ItemTag[i] = new Text[6];
		}
		for (int j = 0; j <= 4; j++)
		{
			this.m_label[j + 20] = base.transform.GetChild(1).GetChild(20).GetChild(j).GetChild(1).GetComponent<Text>();
			this.m_label[j + 20].text = this.DM.mStringTable.GetStringByID((uint)(j + 9324));
			this.m_label[j + 20].rectTransform.sizeDelta += new Vector2(11f, 1f);
			this.m_label[j + 20].font = GUIManager.Instance.GetTTFFont();
		}
		this.mHeroAct[0] = "idle";
		this.mHeroAct[1] = "moving";
		this.mHeroAct[2] = "attack";
		this.mHeroAct[3] = "skill_1";
		this.mHeroAct[4] = "skill_2";
		this.mHeroAct[5] = "skill_3";
		this.mHeroAct[6] = "victory";
		this.Duke = base.transform.GetChild(3).gameObject;
		this.Hero_Pos = base.transform.GetChild(1).GetChild(8);
		this.Hero_PosRT = this.Hero_Pos.GetComponent<RectTransform>();
		this.Transformer = base.transform.GetChild(1).GetChild(14).GetChild(1);
		Text text = this.m_label[6];
		TextAnchor alignment = TextAnchor.UpperLeft;
		this.m_label[7].alignment = alignment;
		text.alignment = alignment;
		Text text2 = this.m_label[0];
		string stringByID = this.DM.mStringTable.GetStringByID(7232u);
		this.m_label[16].text = stringByID;
		text2.text = stringByID;
		this.m_label[1].text = this.DM.mStringTable.GetStringByID(7233u);
		this.m_label[27].text = this.DM.mStringTable.GetStringByID(9373u);
		this.m_label[18].text = this.DM.mStringTable.GetStringByID(11062u);
		this.nowMapPoint = DataManager.MapDataController.LayoutMapInfo[arg1];
		if ((int)this.nowMapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
		{
			this.mapYolk = DataManager.MapDataController.YolkPointTable[(int)this.nowMapPoint.tableID];
		}
		if ((int)this.mapYolk.WonderID < DataManager.MapDataController.MapWondersInfoTable.TableCount)
		{
			this.m_label[15].text = DataManager.MapDataController.GetYolkName((ushort)this.mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID).ToString();
		}
		this.WonderBra = DataManager.MapDataController.MapWondersInfoTable.GetRecordByIndex((int)this.mapYolk.WonderID);
		UIWonderLand.MapPointID = arg1;
		if (GUIManager.Instance.IsArabic)
		{
			base.transform.GetChild(1).GetChild(16).gameObject.AddComponent<ArabicItemTextureRot>();
			Transform component2 = base.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(0).GetComponent<RectTransform>();
			Vector3 localScale = new Vector3(-1f, 1f, 1f);
			base.transform.GetChild(1).GetChild(19).GetChild(5).GetChild(0).GetComponent<RectTransform>().localScale = localScale;
			component2.localScale = localScale;
		}
		for (int k = 0; k < 10; k++)
		{
			this.m_Str[k] = StringManager.Instance.SpawnString(100);
		}
		this.m_KingStr = StringManager.Instance.SpawnString(100);
		this.Refresh(0);
		this.UpdateTime(true);
		this.Duke.transform.SetParent(GUIManager.Instance.m_SecWindowLayer, false);
		base.transform.GetChild(1).GetChild(19).GetChild(6).gameObject.transform.localPosition -= new Vector3(this.m_label[0].preferredWidth, 0f, 0f);
		base.transform.GetChild(1).GetChild(19).GetChild(7).gameObject.transform.localPosition -= new Vector3(this.m_label[1].preferredWidth, 0f, 0f);
		base.transform.GetChild(1).GetChild(19).GetChild(11).gameObject.transform.localPosition -= new Vector3(this.m_label[27].preferredWidth, 0f, 0f);
		base.transform.GetChild(1).GetChild(19).GetChild(13).gameObject.transform.localPosition -= new Vector3(this.m_label[16].preferredWidth / 2f, 0f, 0f);
		if (this.WonderBra.Effect != null)
		{
			for (int l = 0; l < 3; l++)
			{
				if (this.WonderBra.Effect[l].Effect > 0)
				{
					this.effect = this.DM.EffectData.GetRecordByKey(this.WonderBra.Effect[l].Effect);
					this.m_label[9 + l].text = this.DM.mStringTable.GetStringByID((uint)this.effect.StringID);
					this.m_Str[5 + l].FloatToFormat((float)this.WonderBra.Effect[l].Value / 100f, -1, true);
					this.m_Str[5 + l].AppendFormat((!GUIManager.Instance.IsArabic) ? "+{0}%" : "%{0}+");
					this.m_label[12 + l].text = this.m_Str[5 + l].ToString();
					this.m_label[12 + l].SetAllDirty();
					this.m_label[12 + l].cachedTextGenerator.Invalidate();
					this.m_label[12 + l].transform.localPosition -= new Vector3(5f, 0f, 0f);
					if (this.WonderBra.Effect[l].Icon == 1)
					{
						base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(3 + l).GetChild(0).gameObject.SetActive(true);
						base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(3 + l).GetChild(1).gameObject.SetActive(false);
						base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(3 + l).GetChild(2).gameObject.SetActive(false);
					}
					else if (this.WonderBra.Effect[l].Icon == 2)
					{
						base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(3 + l).GetChild(0).gameObject.SetActive(false);
						base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(3 + l).GetChild(1).gameObject.SetActive(true);
						base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(3 + l).GetChild(2).gameObject.SetActive(false);
					}
					else
					{
						base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(3 + l).GetChild(0).gameObject.SetActive(false);
						base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(3 + l).GetChild(1).gameObject.SetActive(false);
						base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(3 + l).GetChild(2).gameObject.SetActive(true);
					}
				}
			}
		}
	}

	// Token: 0x06002114 RID: 8468 RVA: 0x003EECC8 File Offset: 0x003ECEC8
	private void Refresh(int arg1 = 0)
	{
		this.m_UIHint.ControlFadeOut = this.m_WorldWarZ.gameObject;
		if ((int)this.nowMapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
		{
			this.mapYolk = DataManager.MapDataController.YolkPointTable[(int)this.nowMapPoint.tableID];
		}
		if (DataManager.MapDataController.IsFocusWorldWar())
		{
			if (this.mapYolk.WonderID > 0)
			{
				this.m_label[15].text = DataManager.MapDataController.GetYolkName((ushort)this.mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID).ToString();
				for (int i = 0; i <= 4; i++)
				{
					this.m_label[i + 20].text = this.DM.mStringTable.GetStringByID((uint)(i + 11058));
				}
			}
			else
			{
				this.m_label[15].text = this.DM.mStringTable.GetStringByID(9990u);
				for (int j = 0; j <= 4; j++)
				{
					this.m_label[j + 20].text = this.DM.mStringTable.GetStringByID((uint)(j + 11026));
				}
			}
			base.transform.GetChild(1).GetChild(19).GetChild(1).gameObject.SetActive(false);
			base.transform.GetChild(1).GetChild(19).GetChild(2).gameObject.SetActive(false);
			base.transform.GetChild(1).GetChild(19).GetChild(3).gameObject.SetActive(true);
			base.transform.GetChild(1).GetChild(19).GetChild(3).GetComponent<Image>().enabled = (this.mapYolk.WonderID == 0);
			base.transform.GetChild(1).GetChild(19).GetChild(3).GetChild(0).gameObject.SetActive(this.mapYolk.WonderID > 0);
			base.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(1).gameObject.SetActive(true);
			base.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(1).GetComponent<Image>().enabled = (this.mapYolk.WonderID == 0);
			base.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(1).GetChild(0).gameObject.SetActive(this.mapYolk.WonderID > 0);
			base.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(2).gameObject.SetActive(false);
			for (int k = 0; k <= 4; k++)
			{
				base.transform.GetChild(1).GetChild(20).GetChild(k).GetChild(0).GetComponent<Image>().enabled = false;
				base.transform.GetChild(1).GetChild(20).GetChild(k).GetChild(0).GetChild(0).gameObject.SetActive(true);
				base.transform.GetChild(1).GetChild(20).GetChild(k).GetChild(0).GetChild(0).GetComponent<Image>().enabled = (this.mapYolk.WonderID == 0);
				base.transform.GetChild(1).GetChild(20).GetChild(k).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(this.mapYolk.WonderID > 0);
			}
		}
		else
		{
			if ((int)this.mapYolk.WonderID < DataManager.MapDataController.MapWondersInfoTable.TableCount)
			{
				this.m_label[15].text = DataManager.MapDataController.GetYolkName((ushort)this.mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID).ToString();
			}
			for (int l = 0; l <= 4; l++)
			{
				this.m_label[l + 20].text = this.DM.mStringTable.GetStringByID((uint)(l + 9324));
				base.transform.GetChild(1).GetChild(20).GetChild(l).GetChild(0).GetComponent<Image>().enabled = true;
				base.transform.GetChild(1).GetChild(20).GetChild(l).GetChild(0).GetChild(0).gameObject.SetActive(false);
			}
			base.transform.GetChild(1).GetChild(19).GetChild(1).gameObject.SetActive(true);
			base.transform.GetChild(1).GetChild(19).GetChild(2).gameObject.SetActive(true);
			base.transform.GetChild(1).GetChild(19).GetChild(3).gameObject.SetActive(false);
			base.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(2).gameObject.SetActive(true);
			base.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(1).gameObject.SetActive(false);
		}
		if (this.mapYolk.WonderState > 0)
		{
			if (ActivityManager.Instance.IsInKvK(0, true) && !DataManager.MapDataController.IsFocusWorldWar())
			{
				base.transform.GetChild(1).GetChild(15).GetChild(0).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(15).GetChild(1).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(15).GetChild(4).gameObject.SetActive(true);
				base.transform.GetChild(1).GetChild(19).GetChild(6).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(7).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(11).gameObject.SetActive(true);
				base.transform.GetChild(1).GetChild(19).GetChild(13).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(14).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(15).gameObject.SetActive(true);
				this.m_label[26].text = this.DM.mStringTable.GetStringByID(9902u);
				this.m_label[3].text = this.DM.mStringTable.GetStringByID(9901u);
				this.m_label[2].color = this.m_label[27].color;
			}
			else
			{
				base.transform.GetChild(1).GetChild(15).GetChild(0).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(15).GetChild(1).gameObject.SetActive(true);
				base.transform.GetChild(1).GetChild(15).GetChild(4).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(6).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(7).gameObject.SetActive(true);
				base.transform.GetChild(1).GetChild(19).GetChild(11).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(13).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(14).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(15).gameObject.SetActive(true);
				this.m_label[26].text = this.DM.mStringTable.GetStringByID((!DataManager.MapDataController.IsFocusWorldWar()) ? 9397u : 11033u);
				this.m_label[3].text = this.DM.mStringTable.GetStringByID(9901u);
				this.m_label[2].color = this.m_label[1].color;
			}
			this.m_WorldPiss.gameObject.SetActive(false);
		}
		else
		{
			if (DataManager.MapDataController.IsFocusWorldWar())
			{
				base.transform.GetChild(1).GetChild(19).GetChild(7).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(6).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(11).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(13).gameObject.SetActive(true);
				base.transform.GetChild(1).GetChild(19).GetChild(14).gameObject.SetActive(true);
				base.transform.GetChild(1).GetChild(15).gameObject.SetActive(false);
				this.m_UIHint.ControlFadeOut = this.m_WorldPiss.gameObject;
				this.m_WorldWarZ.gameObject.SetActive(false);
			}
			else
			{
				base.transform.GetChild(1).GetChild(15).GetChild(0).gameObject.SetActive(true);
				base.transform.GetChild(1).GetChild(15).GetChild(1).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(15).GetChild(4).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(7).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(6).gameObject.SetActive(true);
				base.transform.GetChild(1).GetChild(19).GetChild(11).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(13).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(19).GetChild(14).gameObject.SetActive(false);
				base.transform.GetChild(1).GetChild(15).gameObject.SetActive(true);
				this.m_WorldPiss.gameObject.SetActive(false);
			}
			Text text = this.m_label[25];
			string stringByID = this.DM.mStringTable.GetStringByID(9399u);
			this.m_label[26].text = stringByID;
			text.text = stringByID;
			this.m_label[3].text = this.DM.mStringTable.GetStringByID(7248u);
			this.m_label[2].color = this.m_label[0].color;
			if (this.m_label[25].preferredWidth > this.m_label[25].rectTransform.sizeDelta.x)
			{
				this.m_label[25].rectTransform.sizeDelta = new Vector2(this.m_label[25].preferredWidth, this.m_label[25].rectTransform.sizeDelta.y);
				this.m_WorldPiss.rectTransform.sizeDelta = new Vector2(this.m_label[25].preferredWidth + 14f, this.m_label[25].rectTransform.sizeDelta.y + 10f);
			}
			if (this.m_label[25].preferredHeight > this.m_label[25].rectTransform.sizeDelta.y)
			{
				this.m_label[25].rectTransform.sizeDelta = new Vector2(this.m_label[25].rectTransform.sizeDelta.x, this.m_label[25].preferredHeight);
				this.m_WorldPiss.rectTransform.sizeDelta = new Vector2(this.m_label[25].rectTransform.sizeDelta.x + 14f, this.m_label[25].preferredHeight + 10f);
			}
		}
		for (int m = 0; m < 10; m++)
		{
			base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(2 + m).gameObject.SetActive(this.mapYolk.WonderID > 0 && !DataManager.MapDataController.IsFocusWorldWar());
		}
		base.transform.GetChild(1).GetChild(20).gameObject.SetActive(DataManager.MapDataController.IsFocusWorldWar() || this.mapYolk.WonderID == 0);
		base.transform.GetChild(1).GetChild(13).gameObject.SetActive(this.mapYolk.WonderID > 0 && !DataManager.MapDataController.IsFocusWorldWar());
		base.transform.GetChild(1).GetChild(19).GetChild(15).gameObject.SetActive(false);
		base.transform.GetChild(1).GetChild(19).GetChild(12).gameObject.SetActive(false);
		base.transform.GetChild(1).GetChild(19).GetChild(10).gameObject.SetActive(false);
		base.transform.GetChild(1).GetChild(19).GetChild(9).gameObject.SetActive(false);
		this.m_label[8].text = this.DM.mStringTable.GetStringByID(7249u);
		if (this.m_label[26].preferredWidth > this.m_label[26].rectTransform.sizeDelta.x)
		{
			this.m_label[26].rectTransform.sizeDelta = new Vector2(this.m_label[26].preferredWidth, this.m_label[26].rectTransform.sizeDelta.y);
			this.m_WorldWarZ.rectTransform.sizeDelta = new Vector2(this.m_label[26].preferredWidth + 14f, this.m_label[26].rectTransform.sizeDelta.y + 10f);
		}
		if (this.m_label[26].preferredHeight > this.m_label[26].rectTransform.sizeDelta.y)
		{
			this.m_label[26].rectTransform.sizeDelta = new Vector2(this.m_label[26].rectTransform.sizeDelta.x, this.m_label[26].preferredHeight);
			this.m_WorldWarZ.rectTransform.sizeDelta = new Vector2(this.m_label[26].rectTransform.sizeDelta.x + 14f, this.m_label[26].preferredHeight + 10f);
		}
		if (this.mapYolk.WonderAllianceTag == null || this.mapYolk.WonderAllianceTag.Length == 0)
		{
			this.m_Str[4].ClearString();
			this.m_Str[4].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(245u));
			this.m_Str[4].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4600u));
			this.m_label[6].text = this.m_Str[4].ToString();
			this.m_label[6].SetAllDirty();
			this.m_label[6].cachedTextGenerator.Invalidate();
			base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(0).GetComponent<Image>().enabled = false;
			base.transform.GetChild(1).GetChild(14).GetComponent<Image>().enabled = false;
			this.Transformer.gameObject.SetActive(false);
		}
		else if (DataManager.Instance.RoleAlliance.KingdomID > 0 || DataManager.Instance.RoleAlliance.Id == 0u)
		{
			this.m_Str[1].ClearString();
			if (DataManager.Instance.RoleAlliance.KingdomID == this.mapYolk.AllianceKingdomID)
			{
				this.m_Str[1].StringToFormat(this.mapYolk.WonderAllianceTag);
				this.m_Str[1].StringToFormat(this.mapYolk.OwnerAllianceName);
				if (GUIManager.Instance.IsArabic)
				{
					this.m_Str[1].AppendFormat("{1} [{0}]");
				}
				else
				{
					this.m_Str[1].AppendFormat("[{0}] {1}");
				}
			}
			else
			{
				CString cstring = StringManager.Instance.StaticString1024();
				CString cstring2 = StringManager.Instance.StaticString1024();
				CString cstring3 = StringManager.Instance.StaticString1024();
				cstring2.Append(this.mapYolk.OwnerAllianceName);
				cstring3.Append(this.mapYolk.WonderAllianceTag);
				GUIManager.Instance.FormatRoleNameForChat(cstring, cstring2, cstring3, this.mapYolk.AllianceKingdomID, GUIManager.Instance.IsArabic);
				this.m_Str[1].Append(cstring);
			}
			this.m_Str[4].ClearString();
			this.m_Str[4].StringToFormat(this.m_Str[1]);
			this.m_Str[4].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4600u));
			this.m_label[6].text = this.m_Str[4].ToString();
			this.m_label[6].SetAllDirty();
			this.m_label[6].cachedTextGenerator.Invalidate();
			base.transform.GetChild(1).GetChild(19).GetChild(8).GetChild(0).GetComponent<Image>().enabled = true;
			base.transform.GetChild(1).GetChild(14).GetComponent<Image>().enabled = true;
			this.Transformer.gameObject.SetActive(true);
			int num = (int)(this.mapYolk.OwnerEmblem & 7);
			int num2 = this.mapYolk.OwnerEmblem >> 3 & 7;
			int num3 = num2 * 8 + num + 1;
			if (num3 > 64)
			{
				num3 = 64;
			}
			int num4 = (this.mapYolk.OwnerEmblem >> 6 & 63) + 1;
			if (num4 > 64)
			{
				num4 = 64;
			}
			GUIManager.Instance.SetBadgeTotemImg(this.Transformer, num3, num4);
		}
		else
		{
			this.Transformer.gameObject.SetActive(false);
		}
		this.m_Str[0].ClearString();
		this.m_Str[2].ClearString();
		CString cstring4 = StringManager.Instance.StaticString1024();
		DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.FocusKingdomID, ref cstring4);
		if (DataManager.MapDataController.kingdomData.kingdomID != DataManager.MapDataController.FocusKingdomID)
		{
			this.m_Str[0].IntToFormat((long)DataManager.MapDataController.FocusKingdomID, 1, false);
		}
		this.m_Str[0].StringToFormat(cstring4);
		if (DataManager.MapDataController.kingdomData.kingdomID != DataManager.MapDataController.FocusKingdomID)
		{
			this.m_Str[0].AppendFormat("#{0} {1}");
		}
		else
		{
			this.m_Str[0].AppendFormat("{0}");
		}
		this.m_Str[2].StringToFormat(this.m_Str[0]);
		this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4509u));
		this.m_label[7].text = this.m_Str[2].ToString();
		this.m_label[7].SetAllDirty();
		this.m_label[7].cachedTextGenerator.Invalidate();
		RectTransform rectTransform = this.m_label[7].rectTransform;
		Vector2 sizeDelta = new Vector2(320f, 30f);
		this.m_label[6].rectTransform.sizeDelta = sizeDelta;
		rectTransform.sizeDelta = sizeDelta;
		this.m_label[7].rectTransform.anchoredPosition = new Vector2(this.m_label[7].rectTransform.anchoredPosition.x, -65f);
		this.m_label[6].rectTransform.anchoredPosition = new Vector2(this.m_label[6].rectTransform.anchoredPosition.x, -20f);
		if (this.mapYolk.OwnerName == null || (this.mapYolk.OwnerName.Length == 0 && this.mapYolk.WonderLeader == null) || this.mapYolk.WonderLeader.Length == 0)
		{
			base.transform.GetChild(1).GetChild(19).GetChild(5).GetChild(0).GetChild(0).gameObject.SetActive(false);
			this.m_label[5].text = DataManager.Instance.mStringTable.GetStringByID((!DataManager.MapDataController.IsFocusWorldWar()) ? 7250u : 11019u);
			this.Destroy();
		}
		else
		{
			if (this.AB == null || arg1 > 0 || this.head != this.mapYolk.LeaderHead)
			{
				this.Destroy();
				this.ActionTime = 0f;
				this.ActionTimeRandom = 2f;
				this.head = this.mapYolk.LeaderHead;
				this.sHero = this.DM.HeroTable.GetRecordByKey(this.mapYolk.LeaderHead);
				if (this.DM.CheckHero3DMesh(this.head))
				{
					this.ABIsDone = false;
					cstring4.ClearString();
					cstring4.IntToFormat((long)this.sHero.Modle, 5, false);
					cstring4.AppendFormat("Role/hero_{0}");
					this.AB = AssetManager.GetAssetBundle(cstring4, out this.AssetKey);
					if (this.AB != null)
					{
						this.AR = this.AB.LoadAsync("m", typeof(GameObject));
					}
				}
			}
			base.transform.GetChild(1).GetChild(19).GetChild(5).GetChild(0).GetChild(0).gameObject.SetActive(true);
			if (this.mapYolk.WonderLeader != null && this.mapYolk.WonderLeader.Length > 0)
			{
				this.m_label[5].text = this.mapYolk.WonderLeader.ToString();
			}
			else
			{
				this.m_label[5].text = this.mapYolk.OwnerName.ToString();
			}
			if (this.mapYolk.WonderID == 0 || DataManager.MapDataController.IsFocusWorldWar())
			{
				this.m_KingStr.ClearString();
				if (DataManager.MapDataController.IsFocusWorldWar())
				{
					if (this.mapYolk.WonderState > 0)
					{
						this.m_KingStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(11031u));
						base.transform.GetChild(1).GetChild(19).GetChild(9).gameObject.SetActive(false);
						base.transform.GetChild(1).GetChild(19).GetChild(10).gameObject.SetActive(false);
						base.transform.GetChild(1).GetChild(19).GetChild(12).gameObject.SetActive(false);
					}
					else
					{
						this.m_KingStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((this.mapYolk.WonderID <= 0) ? 9967u : 11057u));
						base.transform.GetChild(1).GetChild(19).GetChild(9).gameObject.SetActive(false);
						base.transform.GetChild(1).GetChild(19).GetChild(10).gameObject.SetActive(false);
						base.transform.GetChild(1).GetChild(19).GetChild(12).gameObject.SetActive(this.mapYolk.WonderID == 0);
						base.transform.GetChild(1).GetChild(19).GetChild(15).gameObject.SetActive(this.mapYolk.WonderID != 0);
					}
				}
				else if (DataManager.MapDataController.IsFocusKing(DataManager.MapDataController.YolkPointTable[0].LeaderHomeKingdomID))
				{
					this.m_KingStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9322u));
					base.transform.GetChild(1).GetChild(19).GetChild(9).gameObject.SetActive(true);
					base.transform.GetChild(1).GetChild(19).GetChild(10).gameObject.SetActive(false);
					base.transform.GetChild(1).GetChild(19).GetChild(12).gameObject.SetActive(false);
				}
				else
				{
					this.m_KingStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9323u));
					base.transform.GetChild(1).GetChild(19).GetChild(9).gameObject.SetActive(false);
					base.transform.GetChild(1).GetChild(19).GetChild(10).gameObject.SetActive(true);
					base.transform.GetChild(1).GetChild(19).GetChild(12).gameObject.SetActive(false);
				}
				if (DataManager.MapDataController.kingdomData.kingdomID != this.mapYolk.LeaderHomeKingdomID && this.mapYolk.LeaderHomeKingdomID > 0)
				{
					this.m_KingStr.IntToFormat((long)this.mapYolk.LeaderHomeKingdomID, 1, false);
				}
				this.m_KingStr.StringToFormat(this.m_label[5].text);
				if (DataManager.MapDataController.kingdomData.kingdomID != this.mapYolk.LeaderHomeKingdomID && this.mapYolk.LeaderHomeKingdomID > 0)
				{
					this.m_KingStr.AppendFormat("<color=white>{0}</color> #{1} {2}");
				}
				else
				{
					this.m_KingStr.AppendFormat("<color=white>{0}</color> {1}");
				}
				this.m_label[5].text = this.m_KingStr.ToString();
			}
		}
		this.m_label[5].SetAllDirty();
		this.m_label[5].cachedTextGenerator.Invalidate();
		if (this.mapYolk.OwnerName == null || (this.mapYolk.OwnerName.Length == 0 && this.mapYolk.WonderLeader == null) || this.mapYolk.WonderLeader.Length == 0)
		{
			base.transform.GetChild(1).GetChild(19).GetChild(0).gameObject.SetActive(false);
			base.transform.GetChild(1).GetChild(19).GetChild(4).GetComponent<Image>().enabled = false;
			base.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(0).gameObject.SetActive(false);
		}
		else
		{
			this.m_Str[3].ClearString();
			this.m_Str[3].IntToFormat((long)this.mapYolk.LeaderKingdomID, 1, false);
			Vector2 tileMapPosbyMapID = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.mapYolk.LeaderPos.zoneID, this.mapYolk.LeaderPos.pointID));
			this.m_Str[3].IntToFormat((long)((int)tileMapPosbyMapID.x), 1, false);
			this.m_Str[3].IntToFormat((long)((int)tileMapPosbyMapID.y), 1, false);
			this.m_Str[3].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
			this.m_label[4].text = this.m_Str[3].ToString();
			this.m_label[4].SetAllDirty();
			this.m_label[4].cachedTextGenerator.Invalidate();
			base.transform.GetChild(1).GetChild(19).GetChild(0).gameObject.SetActive(true);
			base.transform.GetChild(1).GetChild(19).GetChild(4).GetComponent<Image>().enabled = true;
			base.transform.GetChild(1).GetChild(19).GetChild(4).GetChild(0).gameObject.SetActive(true);
		}
		for (int n = 4; n < 6; n++)
		{
			((RectTransform)base.transform.GetChild(1).GetChild(19).GetChild(n).GetChild(0).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_label[n].preferredWidth, this.m_label[5].rectTransform.sizeDelta.x), 3f);
		}
	}

	// Token: 0x06002115 RID: 8469 RVA: 0x003F0BCC File Offset: 0x003EEDCC
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		int i = 0;
		int num = dataIdx * 5;
		while (i < 5)
		{
			item.transform.GetChild(0).GetChild(i * 3).gameObject.SetActive(false);
			item.transform.GetChild(0).GetChild(i * 3 + 1).gameObject.SetActive(false);
			item.transform.GetChild(0).GetChild(i * 3 + 2).gameObject.SetActive(false);
			this.ItemTag[panelObjectIdx][i] = item.transform.GetChild(0).GetChild(i * 3 + 2).GetComponent<Text>();
			this.ItemTag[panelObjectIdx][i].font = this.Font;
			if (num < (int)DukeNukem.Dukedom)
			{
				if (GUIManager.Instance.IsArabic)
				{
					this.ItemTag[panelObjectIdx][i].text = DukeNukem.Kid[num] + "#";
				}
				else
				{
					this.ItemTag[panelObjectIdx][i].text = "#" + DukeNukem.Kid[num];
				}
				if (DukeNukem.Kid[num] == DataManager.MapDataController.kingdomData.kingdomID)
				{
					item.transform.GetChild(0).GetChild(i * 3 + 1).gameObject.SetActive(true);
				}
				item.transform.GetChild(0).GetChild(i * 3 + 2).gameObject.SetActive(true);
				item.transform.GetChild(0).GetChild(i * 3).gameObject.SetActive(true);
			}
			i++;
			num++;
		}
	}

	// Token: 0x06002116 RID: 8470 RVA: 0x003F0D74 File Offset: 0x003EEF74
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06002117 RID: 8471 RVA: 0x003F0D78 File Offset: 0x003EEF78
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (arg1 == 5 && bOK && DataManager.MapDataController.CheckKingFunction(eKingFunction.eAmnesty))
		{
			if ((DataManager.MapDataController.YolkPointTable[0].WonderFlag & 32) == 0)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1464u), 255, true);
				return;
			}
			DataManager.Instance.SendAmnesty();
		}
	}

	// Token: 0x06002118 RID: 8472 RVA: 0x003F0DF0 File Offset: 0x003EEFF0
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			this.m_Str[0].ClearString();
			if (this.mapYolk.StateBegin > 0UL && DataManager.Instance.ServerTime - (long)((ulong)this.mapYolk.StateDuring) <= (long)this.mapYolk.StateBegin)
			{
				GameConstants.GetTimeString(this.m_Str[0], (uint)(this.mapYolk.StateBegin + (ulong)this.mapYolk.StateDuring - (ulong)DataManager.Instance.ServerTime), false, false, true, false, true);
				this.m_label[2].text = this.m_Str[0].ToString();
			}
			else
			{
				this.m_label[2].text = DataManager.Instance.mStringTable.GetStringByID(9321u);
			}
			this.m_label[2].SetAllDirty();
			this.m_label[2].cachedTextGenerator.Invalidate();
		}
		if (this.m_CrownBack)
		{
			if ((double)(this.TeaTime += Time.smoothDeltaTime) > 1.8)
			{
				this.TeaTime = 0.2f;
			}
			Graphic myEmperor = this.m_MyEmperor;
			Color color = new Color(1f, 1f, 1f, (this.TeaTime <= 1f) ? this.TeaTime : (2f - this.TeaTime));
			this.m_Defeater.color = color;
			color = color;
			this.m_Dukedom.color = color;
			color = color;
			this.m_CrownBack.color = color;
			myEmperor.color = color;
		}
	}

	// Token: 0x06002119 RID: 8473 RVA: 0x003F0F90 File Offset: 0x003EF190
	private void SetFilterName(byte Filter)
	{
		UIWonderLand.FilterIdx = Filter;
		base.transform.GetChild(1).GetChild(3).GetChild(17).GetChild(1).gameObject.SetActive(Filter == 0);
		base.transform.GetChild(1).GetChild(3).GetChild(20).gameObject.SetActive(UIWonderLand.FilterIdx > 0);
		if (UIWonderLand.FilterIdx > 0)
		{
			base.transform.GetChild(1).GetChild(3).GetChild(17).GetChild(0).GetComponent<Text>().text = this.DM.GetLanguageStr(Filter);
		}
		else
		{
			base.transform.GetChild(1).GetChild(3).GetChild(17).GetChild(0).GetComponent<Text>().text = string.Empty;
		}
	}

	// Token: 0x0600211A RID: 8474 RVA: 0x003F1070 File Offset: 0x003EF270
	private static void SearchChange(string input)
	{
		AllianceHint.FilterName = input;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceHint, 15, 0);
	}

	// Token: 0x0600211B RID: 8475 RVA: 0x003F1088 File Offset: 0x003EF288
	private void ValueChange(string input)
	{
		if (input != string.Empty)
		{
			UIWonderLand.ValueChanged();
		}
		this.SetLimit(input);
	}

	// Token: 0x0600211C RID: 8476 RVA: 0x003F10A8 File Offset: 0x003EF2A8
	public void RevokeApplyList(uint revoke)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		GUIManager.Instance.ShowUILock(EUILock.AllianceCreate);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_USER_CANCELAPPLY;
		messagePacket.AddSeqId();
		messagePacket.Add(revoke);
		messagePacket.Send(false);
	}

	// Token: 0x0600211D RID: 8477 RVA: 0x003F10F0 File Offset: 0x003EF2F0
	public void RequestApplyList()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_APPLYALLIANCELIST;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x0600211E RID: 8478 RVA: 0x003F1124 File Offset: 0x003EF324
	public void RequestFederalOrder()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_ORDERKINGDOMS;
		messagePacket.AddSeqId();
		messagePacket.Add(this.mapYolk.WonderID);
		if (messagePacket.Send(false))
		{
			GUIManager.Instance.ShowUILock(EUILock.AllianceCreate);
		}
	}

	// Token: 0x0600211F RID: 8479 RVA: 0x003F1178 File Offset: 0x003EF378
	public void OnButtonUp(UIButtonHint sender)
	{
		if (this.m_WorldWarZ)
		{
			sender.ControlFadeOut.SetActive(false);
		}
	}

	// Token: 0x06002120 RID: 8480 RVA: 0x003F1198 File Offset: 0x003EF398
	public void OnButtonDown(UIButtonHint sender)
	{
		if (this.m_WorldWarZ)
		{
			sender.ControlFadeOut.SetActive(true);
		}
	}

	// Token: 0x06002121 RID: 8481 RVA: 0x003F11B8 File Offset: 0x003EF3B8
	public override void OnClose()
	{
		UnityEngine.Object.Destroy(this.Duke);
		DukeNukem.Kid = null;
		for (int i = 0; i < 10; i++)
		{
			if (this.m_Str[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_Str[i]);
			}
		}
		StringManager.Instance.DeSpawnString(this.m_KingStr);
		this.m_WorldPiss = (this.m_WorldWarZ = null);
		this.Destroy();
	}

	// Token: 0x06002122 RID: 8482 RVA: 0x003F1230 File Offset: 0x003EF430
	public override void UpdateUI(int arg1, int arg2)
	{
		if (GUIManager.Instance.HideUILock(EUILock.AllianceCreate))
		{
			this.ItemsHeight.Clear();
			this.Duke.SetActive(true);
			this.Duke.transform.GetChild(0).GetChild(0).gameObject.SetActive(DukeNukem.Result == 0);
			this.Duke.transform.GetChild(0).GetChild(2).gameObject.SetActive(DukeNukem.Result != 0);
			if (DukeNukem.Result == 0)
			{
				for (int i = 0; i < (int)DukeNukem.Dukedom; i += 5)
				{
					this.ItemsHeight.Add(66f);
				}
				for (int j = 0; j < (int)DukeNukem.Dukedom; j++)
				{
					if (DukeNukem.Kid[j] == DataManager.MapDataController.kingdomData.kingdomID)
					{
						DukeNukem.Kid[j] = DukeNukem.Kid[0];
						DukeNukem.Kid[0] = DataManager.MapDataController.kingdomData.kingdomID;
						Array.Sort<ushort>(DukeNukem.Kid, 1, (int)(DukeNukem.Dukedom - 1));
						this.m_scroll.AddNewDataHeight(this.ItemsHeight, true, true);
						return;
					}
				}
				Array.Sort<ushort>(DukeNukem.Kid);
				this.m_scroll.AddNewDataHeight(this.ItemsHeight, true, true);
			}
			else if (DukeNukem.Result == 2)
			{
				this.m_label[17].text = DataManager.Instance.mStringTable.GetStringByID((ActivityManager.Instance.FederalActKingdomWonderID != this.mapYolk.WonderID) ? 11079u : 11075u);
			}
			else if (DukeNukem.Result == 1)
			{
				this.m_label[17].text = DataManager.Instance.mStringTable.GetStringByID(11155u);
			}
			else
			{
				this.m_label[17].text = DataManager.Instance.mStringTable.GetStringByID(1049u);
			}
			return;
		}
		this.Refresh(arg1);
	}

	// Token: 0x06002123 RID: 8483 RVA: 0x003F143C File Offset: 0x003EF63C
	public override bool OnBackButtonClick()
	{
		if (!this.Duke.activeInHierarchy)
		{
			return false;
		}
		this.Duke.SetActive(false);
		return true;
	}

	// Token: 0x06002124 RID: 8484 RVA: 0x003F1460 File Offset: 0x003EF660
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
		this.AR = null;
		AssetManager.UnloadAssetBundle(this.AssetKey, true);
	}

	// Token: 0x06002125 RID: 8485 RVA: 0x003F14E4 File Offset: 0x003EF6E4
	protected void Update()
	{
		if (this.AR != null && !this.ABIsDone && this.AR.isDone)
		{
			this.ABIsDone = true;
			this.go = (GameObject)UnityEngine.Object.Instantiate(this.AR.asset);
			this.go.transform.SetParent(this.Hero_Pos, false);
			Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
			localRotation.eulerAngles = new Vector3(0f, (float)this.sHero.Camera_Horizontal, 0f);
			this.go.transform.localRotation = localRotation;
			this.go.transform.localScale = new Vector3((float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate);
			this.go.transform.localPosition = Vector3.zero;
			GUIManager.Instance.SetLayer(this.go, 5);
			this.Hero_PosRT.anchoredPosition = new Vector2(this.Hero_PosRT.anchoredPosition.x, (float)(-180 - (int)(1000 - this.sHero.CameraDistance)));
			this.Tmp = this.Hero_Pos.GetChild(this.Hero_Pos.childCount - 1);
			this.Hero_Model = this.Tmp.GetComponent<Transform>();
			if (this.Hero_Model != null)
			{
				this.tmpAN = this.Hero_Model.GetComponent<Animation>();
				this.tmpAN.wrapMode = WrapMode.Loop;
				this.tmpAN.Play(this.mHeroAct[0]);
				this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
				this.tmpAN.clip = this.tmpAN.GetClip(this.mHeroAct[0]);
				if (this.Hero_Pos.gameObject.activeSelf)
				{
					SkinnedMeshRenderer componentInChildren = this.Hero_Model.GetComponentInChildren<SkinnedMeshRenderer>();
					componentInChildren.updateWhenOffscreen = true;
					componentInChildren.useLightProbes = false;
				}
			}
		}
		if (this.ABIsDone && this.Hero_Model != null && (!this.tmpAN.IsPlaying(this.HeroAct) || this.HeroAct == "idle") && (double)this.ActionTimeRandom < 0.0001)
		{
			this.ActionTimeRandom = (float)UnityEngine.Random.Range(3, 7);
			this.ActionTime = 0f;
		}
		if ((double)this.ActionTimeRandom > 0.0001)
		{
			this.ActionTime += Time.smoothDeltaTime;
			if (this.ActionTime >= this.ActionTimeRandom)
			{
				this.HeroActionChang(false);
			}
		}
		if (this.ABIsDone && this.Hero_Model != null && this.MovingTimer > 0f)
		{
			this.MovingTimer -= Time.deltaTime;
			if (this.MovingTimer <= 0f)
			{
				this.tmpAN.CrossFade("idle");
				this.HeroAct = "idle";
			}
		}
		if (this.door && this.mapYolk.WonderState == 2)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06002126 RID: 8486 RVA: 0x003F184C File Offset: 0x003EFA4C
	public void HeroActionChang(bool bAddShowEffect = false)
	{
		if (this.ABIsDone && this.Hero_Model != null)
		{
			this.tmpAN = this.Hero_Model.GetComponent<Animation>();
			this.tmpAN.wrapMode = WrapMode.Loop;
			if (this.HeroAct == this.mHeroAct[1])
			{
				this.tmpAN.CrossFade("idle");
			}
			if (this.tmpAN.GetClip(this.mHeroAct[2]) != null)
			{
				this.HeroAct = this.mHeroAct[2];
				this.tmpAN[this.mHeroAct[2]].layer = 1;
				this.tmpAN[this.mHeroAct[2]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(this.mHeroAct[3]) != null)
			{
				this.HeroAct = this.mHeroAct[3];
				this.tmpAN[this.mHeroAct[3]].layer = 1;
				this.tmpAN[this.mHeroAct[3]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[4]) != null)
			{
				this.HeroAct = this.mHeroAct[4];
				this.tmpAN[this.mHeroAct[4]].layer = 1;
				this.tmpAN[this.mHeroAct[4]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(this.mHeroAct[5]) != null)
			{
				this.HeroAct = this.mHeroAct[5];
				this.tmpAN[this.mHeroAct[5]].layer = 1;
				this.tmpAN[this.mHeroAct[5]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(this.mHeroAct[6]) != null)
			{
				this.HeroAct = this.mHeroAct[6];
				this.tmpAN[this.mHeroAct[6]].layer = 1;
				this.tmpAN[this.mHeroAct[6]].wrapMode = WrapMode.Once;
			}
			int num;
			if (!bAddShowEffect)
			{
				num = UnityEngine.Random.Range(1, 7);
			}
			else
			{
				num = 6;
			}
			AnimationClip animationClip = this.tmpAN.GetClip(this.mHeroAct[(int)((byte)num)]);
			this.HeroAct = this.mHeroAct[(int)((byte)num)];
			if (num == 3)
			{
				AnimationClip clip = this.tmpAN.GetClip(this.HeroAct + "_ch");
				if (clip != null)
				{
					animationClip = null;
				}
			}
			if (animationClip != null)
			{
				this.tmpAN.CrossFade(animationClip.name);
				this.MovingTimer = 0f;
				if (num == 1)
				{
					this.MovingTimer = 2f;
				}
			}
			this.ActionTimeRandom = 0f;
			this.ActionTime = 0f;
		}
	}

	// Token: 0x06002127 RID: 8487 RVA: 0x003F1B4C File Offset: 0x003EFD4C
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Fallout:
			if (this.Duke.activeInHierarchy)
			{
				this.Duke.SetActive(false);
			}
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Alliance)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					for (int i = 0; i < 28; i++)
					{
						if (this.m_label[i] != null && this.m_label[i].enabled)
						{
							this.m_label[i].enabled = false;
							this.m_label[i].enabled = true;
						}
					}
					for (int j = 0; j < 7; j++)
					{
						int num = 0;
						while (j < 6)
						{
							if (this.ItemTag[j][num] != null && this.ItemTag[j][num].enabled)
							{
								this.ItemTag[j][num].enabled = false;
								this.ItemTag[j][num].enabled = true;
							}
							j++;
						}
					}
				}
			}
			else
			{
				this.Refresh(0);
			}
			break;
		case NetworkNews.Refresh_Asset:
			if (meg[1] == 1 && meg[2] == 2 && GameConstants.ConvertBytesToUShort(meg, 3) == this.head)
			{
				this.Refresh((int)this.head);
			}
			break;
		}
	}

	// Token: 0x06002128 RID: 8488 RVA: 0x003F1CB8 File Offset: 0x003EFEB8
	public void OnButtonClick(UIButton sender)
	{
		if (this.door)
		{
			if (DataManager.MapDataController.IsFocusWorldWar())
			{
				if (this.mapYolk.WonderID > 0)
				{
					switch (sender.m_BtnID2)
					{
					case 1:
						ActivityManager.Instance.Send_ACTIVITY_REQUEST_FEDERAL_PRIZE(this.mapYolk.WonderID);
						return;
					case 2:
						TitleManager.Instance.OpenNobilityTitleList((ushort)this.mapYolk.WonderID);
						return;
					case 3:
						if (DataManager.MapDataController.IsPeaceState(true, this.mapYolk.WonderID))
						{
							this.door.OpenMenu(EGUIWindow.UI_BagFilter, 9 | (int)this.mapYolk.WonderID << 16, (DataManager.CompareStr(this.mapYolk.WonderLeader, this.DM.RoleAttr.Name) == 0 || DataManager.CompareStr(this.mapYolk.OwnerName, this.DM.RoleAttr.Name) == 0) ? 1 : 0, false);
						}
						return;
					case 4:
						this.door.OpenMenu(EGUIWindow.UI_NobilityBoard, 0, (int)this.mapYolk.WonderID, false);
						return;
					case 5:
						this.RequestFederalOrder();
						return;
					}
				}
				switch (sender.m_BtnID2)
				{
				case 1:
					this.door.OpenMenu(EGUIWindow.UI_WonderReward, 0, 0, false);
					return;
				case 2:
					TitleManager.Instance.OpenTitleListN(0);
					return;
				case 3:
					TitleManager.Instance.OpenTitleListW(null);
					return;
				case 4:
					if (DataManager.MapDataController.IsPeaceState(true, 0))
					{
						this.door.OpenMenu(EGUIWindow.UI_BagFilter, 9, 0, false);
					}
					return;
				case 5:
					this.door.OpenMenu(EGUIWindow.UI_LeaderBoard, 6, 0, false);
					return;
				}
			}
			if (sender.m_BtnID2 == 1)
			{
				TitleManager.Instance.OpenTitleList();
			}
			else if (sender.m_BtnID2 == 2)
			{
				DataManager.Instance.SendKingdomBullitin_Info(false);
			}
			else if (sender.m_BtnID2 == 3)
			{
				if (DataManager.MapDataController.IsInMyKingdom(true))
				{
					this.door.OpenMenu(EGUIWindow.UI_BuffList, 3, 0, false);
				}
			}
			else if (sender.m_BtnID2 == 4)
			{
				if (DataManager.MapDataController.IsPeaceState(true, 0))
				{
					this.door.OpenMenu(EGUIWindow.UI_BagFilter, 9, 0, false);
				}
			}
			else if (sender.m_BtnID2 == 5)
			{
				if (DataManager.MapDataController.CheckKingFunction(eKingFunction.eAmnesty))
				{
					if ((DataManager.MapDataController.YolkPointTable[0].WonderFlag & 32) == 0)
					{
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1464u), 255, true);
						return;
					}
					GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(1458u), DataManager.Instance.mStringTable.GetStringByID(1459u), sender.m_BtnID2, 0, DataManager.Instance.mStringTable.GetStringByID(3737u), DataManager.Instance.mStringTable.GetStringByID(3736u));
				}
			}
			else if (sender.m_BtnID1 == 4)
			{
				if (this.mapYolk.WonderAllianceTag != null && this.mapYolk.WonderAllianceTag.Length > 0)
				{
					this.door.AllianceInfo(this.mapYolk.WonderAllianceTag.ToString());
				}
			}
			else if (sender.m_BtnID1 == 5)
			{
				if (this.mapYolk.WonderLeader != null && this.mapYolk.WonderLeader.Length > 0)
				{
					this.DM.ShowLordProfile(this.mapYolk.WonderLeader.ToString());
				}
				else if (this.mapYolk.OwnerName != null && this.mapYolk.OwnerName.Length > 0)
				{
					this.DM.ShowLordProfile(this.mapYolk.OwnerName.ToString());
				}
			}
			else if (sender.m_BtnID1 == 3)
			{
				this.door.CloseMenu(false);
			}
			else if (sender.m_BtnID1 == 2)
			{
				this.door.GoToPointCode(this.mapYolk.LeaderKingdomID, this.mapYolk.LeaderPos.zoneID, this.mapYolk.LeaderPos.pointID, 0);
			}
			else if (sender.m_BtnID1 == 1)
			{
				this.door.OpenMenu(EGUIWindow.UI_WonderInfo, UIWonderLand.MapPointID, 0, false);
			}
			else
			{
				this.Duke.SetActive(false);
				this.Refresh(0);
			}
			return;
		}
	}

	// Token: 0x06002129 RID: 8489 RVA: 0x003F2174 File Offset: 0x003F0374
	public void SetLimit(string limit)
	{
		this.Path.Length = 0;
		this.m_limit.text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4614u), this.m_input.characterLimit - Encoding.UTF8.GetByteCount(limit)).ToString();
	}

	// Token: 0x0600212A RID: 8490 RVA: 0x003F21DC File Offset: 0x003F03DC
	public void ClearName()
	{
		this.m_search.text = (UIWonderLand.SearchName = (UIWonderLand.SeekName = string.Empty));
		this.m_default[2].text = this.DM.mStringTable.GetStringByID(736u);
	}

	// Token: 0x0600212B RID: 8491 RVA: 0x003F2228 File Offset: 0x003F0428
	public void ClearLanguage()
	{
		UIWonderLand.SeekKind = byte.MaxValue;
		this.m_filter.text = (UIWonderLand.SearchLang = string.Empty);
		this.m_default[2].text = this.DM.mStringTable.GetStringByID(736u);
		UIWonderLand.GenuineLang = (UIWonderLand.SeekLang = this.DM.GetUserLanguageID());
	}

	// Token: 0x0600212C RID: 8492 RVA: 0x003F2290 File Offset: 0x003F0490
	public static int Sequencing(Protocol type = Protocol._MSG_INVALID)
	{
		UIWonderLand.Incoming = type;
		if (type > Protocol._MSG_INVALID)
		{
			return (int)((type != Protocol._MSG_RESP_ALLIANCE_TAGCHECK) ? UIWonderLand.Naming : UIWonderLand.Tagging);
		}
		return (int)((UIWonderLand.Checking != Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK) ? UIWonderLand.Naming : UIWonderLand.Tagging);
	}

	// Token: 0x0600212D RID: 8493 RVA: 0x003F22E4 File Offset: 0x003F04E4
	public static byte Sequencing(byte arg1)
	{
		if (UIWonderLand.Incoming == Protocol._MSG_RESP_ALLIANCE_TAGCHECK || UIWonderLand.Incoming == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK)
		{
			UIWonderLand.GenuineTag = arg1;
		}
		else
		{
			UIWonderLand.GenuineName = arg1;
		}
		return arg1;
	}

	// Token: 0x0600212E RID: 8494 RVA: 0x003F2324 File Offset: 0x003F0524
	public static void ValueChanged()
	{
		if (UIWonderLand.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK)
		{
			UIWonderLand.Tagging += 1;
		}
		else
		{
			UIWonderLand.Naming += 1;
		}
		UIWonderLand.CheckTime = 1f;
	}

	// Token: 0x0600212F RID: 8495 RVA: 0x003F236C File Offset: 0x003F056C
	protected void CheckAll()
	{
		UIWonderLand.Checking = Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK;
		this.CheckName(UIWonderLand.ValidTag);
		UIWonderLand.Checking = Protocol._MSG_REQUEST_ALLIANCE_NAMECHACK;
		this.CheckName(UIWonderLand.ValidName);
	}

	// Token: 0x06002130 RID: 8496 RVA: 0x003F23A4 File Offset: 0x003F05A4
	protected void CheckName(string name)
	{
		UIWonderLand.CheckTime = 0f;
		if ((UIWonderLand.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK && name.Length == 3) || (UIWonderLand.Checking != Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK && name.Length >= 3))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = UIWonderLand.Checking;
			messagePacket.AddSeqId();
			messagePacket.Add((byte)UIWonderLand.Sequencing(Protocol._MSG_INVALID));
			if (UIWonderLand.Checking != Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK)
			{
				messagePacket.Add((byte)Encoding.UTF8.GetByteCount(name));
			}
			messagePacket.Add(name, (UIWonderLand.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK) ? 3 : 20);
			messagePacket.Send(false);
		}
		else
		{
			UIWonderLand.Incoming = UIWonderLand.Checking;
			UIWonderLand.Sequencing(2);
			this.UpdateUI(2, 2);
		}
	}

	// Token: 0x06002131 RID: 8497 RVA: 0x003F2480 File Offset: 0x003F0680
	public static void OpenAllianceBox(byte Type, int CharLimit, bool CheckOnly, long Para)
	{
		InputBox inputBox = GUIManager.Instance.OpenMenu(EGUIWindow.UI_AllianceInput, (int)Type, (!CheckOnly) ? 0 : 1, false, true, false) as InputBox;
		if (inputBox)
		{
			inputBox.SetLimit(CharLimit);
			inputBox.ItemID = Para;
		}
	}

	// Token: 0x04006854 RID: 26708
	private int AssetKey;

	// Token: 0x04006855 RID: 26709
	private AssetBundle AB;

	// Token: 0x04006856 RID: 26710
	private AssetBundleRequest AR;

	// Token: 0x04006857 RID: 26711
	private float ActionTime;

	// Token: 0x04006858 RID: 26712
	private float ActionTimeRandom;

	// Token: 0x04006859 RID: 26713
	private float MovingTimer;

	// Token: 0x0400685A RID: 26714
	private bool ABIsDone;

	// Token: 0x0400685B RID: 26715
	private Hero sHero;

	// Token: 0x0400685C RID: 26716
	private string HeroAct;

	// Token: 0x0400685D RID: 26717
	private GameObject go;

	// Token: 0x0400685E RID: 26718
	private GameObject Duke;

	// Token: 0x0400685F RID: 26719
	private RectTransform Hero_PosRT;

	// Token: 0x04006860 RID: 26720
	private Transform Tmp;

	// Token: 0x04006861 RID: 26721
	private Transform Hero_Model;

	// Token: 0x04006862 RID: 26722
	private Transform Hero_3D;

	// Token: 0x04006863 RID: 26723
	private Transform Hero_Pos;

	// Token: 0x04006864 RID: 26724
	private Animation tmpAN;

	// Token: 0x04006865 RID: 26725
	protected Door door;

	// Token: 0x04006866 RID: 26726
	protected Text[] m_label = new Text[28];

	// Token: 0x04006867 RID: 26727
	protected Text m_limit;

	// Token: 0x04006868 RID: 26728
	protected Text m_title;

	// Token: 0x04006869 RID: 26729
	protected Text m_error;

	// Token: 0x0400686A RID: 26730
	protected Text m_filter;

	// Token: 0x0400686B RID: 26731
	protected Text m_search;

	// Token: 0x0400686C RID: 26732
	protected Text m_button;

	// Token: 0x0400686D RID: 26733
	protected Text m_content;

	// Token: 0x0400686E RID: 26734
	protected Text[] m_default = new Text[3];

	// Token: 0x0400686F RID: 26735
	protected Text m_descript;

	// Token: 0x04006870 RID: 26736
	protected Image m_Dukedom;

	// Token: 0x04006871 RID: 26737
	protected Image m_Defeater;

	// Token: 0x04006872 RID: 26738
	protected Image m_MyEmperor;

	// Token: 0x04006873 RID: 26739
	protected Image m_CrownBack;

	// Token: 0x04006874 RID: 26740
	protected Image m_WorldWarZ;

	// Token: 0x04006875 RID: 26741
	protected Image m_WorldPiss;

	// Token: 0x04006876 RID: 26742
	protected InputField s_input;

	// Token: 0x04006877 RID: 26743
	protected InputField m_input;

	// Token: 0x04006878 RID: 26744
	protected ScrollPanel m_scroll;

	// Token: 0x04006879 RID: 26745
	protected ScrollPanelItem[] m_panel;

	// Token: 0x0400687A RID: 26746
	protected UISpritesArray USArray;

	// Token: 0x0400687B RID: 26747
	protected UIButtonHint m_UIHint;

	// Token: 0x0400687C RID: 26748
	protected Transform Transformer;

	// Token: 0x0400687D RID: 26749
	protected Transform Tick;

	// Token: 0x0400687E RID: 26750
	protected Transform Invalid;

	// Token: 0x0400687F RID: 26751
	protected Transform TagTick;

	// Token: 0x04006880 RID: 26752
	protected Transform TagInvalid;

	// Token: 0x04006881 RID: 26753
	protected RectTransform Join;

	// Token: 0x04006882 RID: 26754
	protected RectTransform NameTick;

	// Token: 0x04006883 RID: 26755
	protected RectTransform NameInvalid;

	// Token: 0x04006884 RID: 26756
	protected RectTransform SearchRT;

	// Token: 0x04006885 RID: 26757
	protected RectTransform SearchList;

	// Token: 0x04006886 RID: 26758
	protected RectTransform ApplyList;

	// Token: 0x04006887 RID: 26759
	protected Vector3 SearchPosition;

	// Token: 0x04006888 RID: 26760
	protected Vector2 SearchSize;

	// Token: 0x04006889 RID: 26761
	protected Text Name;

	// Token: 0x0400688A RID: 26762
	protected Text Tag;

	// Token: 0x0400688B RID: 26763
	protected Text[][] ItemTag = new Text[7][];

	// Token: 0x0400688C RID: 26764
	protected float TeaTime;

	// Token: 0x0400688D RID: 26765
	public static float CheckTime;

	// Token: 0x0400688E RID: 26766
	public static float Scrolling;

	// Token: 0x0400688F RID: 26767
	public static long Proceeding;

	// Token: 0x04006890 RID: 26768
	public static long Pending;

	// Token: 0x04006891 RID: 26769
	public static byte Pulling;

	// Token: 0x04006892 RID: 26770
	public static byte Tagging;

	// Token: 0x04006893 RID: 26771
	public static byte Naming;

	// Token: 0x04006894 RID: 26772
	public static bool Clearing;

	// Token: 0x04006895 RID: 26773
	public static bool Shooting;

	// Token: 0x04006896 RID: 26774
	public static int Positioning;

	// Token: 0x04006897 RID: 26775
	public static Protocol Checking;

	// Token: 0x04006898 RID: 26776
	public static Protocol Incoming;

	// Token: 0x04006899 RID: 26777
	public static string Text;

	// Token: 0x0400689A RID: 26778
	public static string pendingText;

	// Token: 0x0400689B RID: 26779
	public static string FilterName;

	// Token: 0x0400689C RID: 26780
	public static string ValidName;

	// Token: 0x0400689D RID: 26781
	public static string ValidTag;

	// Token: 0x0400689E RID: 26782
	public static string SeekName;

	// Token: 0x0400689F RID: 26783
	public static string SearchName;

	// Token: 0x040068A0 RID: 26784
	public static string SearchLang;

	// Token: 0x040068A1 RID: 26785
	public static byte GenuineLang;

	// Token: 0x040068A2 RID: 26786
	public static byte GenuineName;

	// Token: 0x040068A3 RID: 26787
	public static byte GenuineTag;

	// Token: 0x040068A4 RID: 26788
	public static byte SetRequest;

	// Token: 0x040068A5 RID: 26789
	public static byte FilterIdx;

	// Token: 0x040068A6 RID: 26790
	public static byte SearchIdx;

	// Token: 0x040068A7 RID: 26791
	public static byte SeekKind;

	// Token: 0x040068A8 RID: 26792
	public static byte SeekLang;

	// Token: 0x040068A9 RID: 26793
	public static int SearchNum;

	// Token: 0x040068AA RID: 26794
	public static int MapPointID;

	// Token: 0x040068AB RID: 26795
	public static AllianceSearch[] Search;

	// Token: 0x040068AC RID: 26796
	public DataManager DM = DataManager.Instance;

	// Token: 0x040068AD RID: 26797
	public Font Font = GUIManager.Instance.GetTTFFont();

	// Token: 0x040068AE RID: 26798
	public StringBuilder Path = new StringBuilder();

	// Token: 0x040068AF RID: 26799
	private List<float> ItemsHeight = new List<float>();

	// Token: 0x040068B0 RID: 26800
	private string[] mHeroAct = new string[7];

	// Token: 0x040068B1 RID: 26801
	private CString[] m_Str = new CString[10];

	// Token: 0x040068B2 RID: 26802
	private CString m_KingStr;

	// Token: 0x040068B3 RID: 26803
	private WondersInfoTbl WonderBra;

	// Token: 0x040068B4 RID: 26804
	private MapPoint nowMapPoint;

	// Token: 0x040068B5 RID: 26805
	private MapYolk mapYolk;

	// Token: 0x040068B6 RID: 26806
	private Effect effect;

	// Token: 0x040068B7 RID: 26807
	private ushort head;

	// Token: 0x040068B8 RID: 26808
	private uint time;
}
