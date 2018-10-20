using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000637 RID: 1591
public class UIMiniMap : GUIWindow, IPointerUpHandler, IPointerDownHandler, IEventSystemHandler, IUIButtonClickHandler
{
	// Token: 0x06001EB1 RID: 7857 RVA: 0x003AA53C File Offset: 0x003A873C
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.ActM = ActivityManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.mMaT = this.door.LoadMaterial();
		this.mCanvasRT = this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.mIPhoneX_DeltaX = this.GUIM.IPhoneX_DeltaX;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		for (int i = 0; i < 5; i++)
		{
			this.Cstr_Lv[i] = StringManager.Instance.SpawnString(100);
		}
		this.mTitle[0] = this.DM.mStringTable.GetStringByID(497u);
		this.mTitle[1] = this.DM.mStringTable.GetStringByID(495u);
		this.Tmp = this.GameT.GetChild(0);
		UIButton component = this.Tmp.GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 0;
		cstring.ClearString();
		cstring.AppendFormat("UI_main_black");
		component.image.sprite = this.door.LoadSprite(cstring);
		component.image.material = this.mMaT;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Tmp.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.Tmp.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.Tmp = this.GameT.GetChild(1);
		this.P1 = this.Tmp.GetComponent<Image>();
		this.FootBall_T = this.Tmp.GetChild(0);
		this.ImgFootBall = this.FootBall_T.GetChild(0).GetComponent<Image>();
		this.text_FootBallTitle = this.FootBall_T.GetChild(1).GetComponent<UIText>();
		this.text_FootBallTitle.font = this.TTFont;
		ushort num;
		if (DataManager.MapDataController.FocusKingdomID != 0)
		{
			num = DataManager.MapDataController.FocusKingdomID;
		}
		else
		{
			num = DataManager.MapDataController.OtherKingdomData.kingdomID;
		}
		if (this.ActM.GetFIFAState() == EActivityState.EAS_Run && !DataManager.MapDataController.IsFocusWorldWar() && !this.ActM.bPassLastWave)
		{
			if (this.ActM.IsInKvK(0, false) && !this.ActM.IsMatchKvk_kingdom(num))
			{
				this.FootBall_T.gameObject.SetActive(false);
			}
			else
			{
				this.FootBall_T.gameObject.SetActive(true);
				if (this.ActM.NowWaveEndTime != 0L)
				{
					this.text_FootBallTitle.text = this.DM.mStringTable.GetStringByID(17525u);
				}
				else
				{
					this.text_FootBallTitle.text = this.DM.mStringTable.GetStringByID(17526u);
				}
				this.text_FootBallTitle.SetAllDirty();
				this.text_FootBallTitle.cachedTextGenerator.Invalidate();
				this.text_FootBallTitle.cachedTextGeneratorForLayout.Invalidate();
				float num2 = 500f;
				if (this.text_FootBallTitle.preferredWidth > this.text_FootBallTitle.rectTransform.sizeDelta.x)
				{
					if (this.text_FootBallTitle.preferredWidth < num2)
					{
						num2 = this.text_FootBallTitle.preferredWidth + 1f;
					}
					this.text_FootBallTitle.rectTransform.sizeDelta = new Vector2(num2, this.text_FootBallTitle.rectTransform.sizeDelta.y);
					this.ImgFootBall.rectTransform.anchoredPosition = new Vector2(-num2 / 2f - 14f, this.ImgFootBall.rectTransform.anchoredPosition.y);
				}
			}
		}
		else
		{
			this.FootBall_T.gameObject.SetActive(false);
		}
		this.Tmp = this.GameT.GetChild(2);
		this.P2 = this.Tmp.GetComponent<Image>();
		for (int j = 0; j < 5; j++)
		{
			this.Tmp1 = this.Tmp.GetChild(j).GetChild(0);
			this.text_Lv[j] = this.Tmp1.GetComponent<UIText>();
			this.text_Lv[j].font = this.TTFont;
			this.Cstr_Lv[j].ClearString();
			this.Cstr_Lv[j].Append(this.DM.mStringTable.GetStringByID(4549u));
			this.Cstr_Lv[j].IntToFormat((long)(j + 1), 1, false);
			this.Cstr_Lv[j].AppendFormat(" {0}");
			this.text_Lv[j].text = this.Cstr_Lv[j].ToString();
		}
		this.Tmp = this.GameT.GetChild(3);
		Image component2;
		for (int k = 0; k < 7; k++)
		{
			this.Tmp1 = this.Tmp.GetChild(0 + k);
			component2 = this.Tmp1.GetComponent<Image>();
			this.Img_W[k] = this.Tmp1.GetComponent<Image>();
			this.btn_W[k] = this.Tmp1.GetChild(0).GetComponent<UIButton>();
			if (this.door.TileMapController != null && this.door.TileMapController.yolk != null && DataManager.MapDataController.CheckYolk((ushort)k, num))
			{
				component2.sprite = this.door.TileMapController.yolk.getMapTileYolkSprite((byte)k);
				component2.material = this.door.TileMapController.yolk.getMapTileYolkMaterial((byte)k);
			}
			this.btn_W[k].m_Handler = this;
			this.btn_W[k].m_BtnID1 = 3;
			this.btn_W[k].m_BtnID2 = k;
			this.text_WonderName[k] = this.Tmp1.GetChild(1).GetComponent<UIText>();
			this.text_WonderName[k].font = this.TTFont;
			this.text_WonderName[k].text = DataManager.MapDataController.GetYolkName((ushort)k, num).ToString();
			this.text_WonderName[k].rectTransform.sizeDelta = new Vector2(180f, this.text_WonderName[k].rectTransform.sizeDelta.y);
			this.Img_W[k].rectTransform.anchorMax = new Vector2(0f, 1f);
			this.Img_W[k].rectTransform.anchorMin = new Vector2(0f, 1f);
			this.Img_W[k].rectTransform.pivot = new Vector2(0f, 1f);
			this.SetWonderPos(num, (byte)k, this.Img_W[k].rectTransform);
			if ((k == 0 && !DataManager.MapDataController.CheckYolk((ushort)k, num)) || (k > 0 && (DataManager.MapDataController.IsFocusWorldWar() || !DataManager.MapDataController.CheckYolk((ushort)k, num))))
			{
				component2.gameObject.SetActive(false);
			}
		}
		this.Federal_T = this.Tmp.GetChild(7);
		if (DataManager.MapDataController.IsFocusWorldWar())
		{
			this.Federal_T.gameObject.SetActive(true);
		}
		this.Federal_FightRT = this.Federal_T.GetChild(31).GetComponent<RectTransform>();
		this.Federal_HomeRT = this.Federal_T.GetChild(32).GetComponent<RectTransform>();
		this.Federal_BGRT = this.Federal_T.GetChild(0).GetComponent<RectTransform>();
		if (this.GUIM.IsArabic)
		{
			this.Federal_FightRT.gameObject.AddComponent<ArabicItemTextureRot>();
			this.Federal_HomeRT.gameObject.AddComponent<ArabicItemTextureRot>();
			this.Federal_BGRT.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		for (int l = 0; l < 30; l++)
		{
			this.Tmp1 = this.Federal_T.GetChild(1 + l);
			if (this.GUIM.IsArabic)
			{
				this.Tmp1.gameObject.AddComponent<ArabicItemTextureRot>();
			}
			this.Img_Federal[l] = this.Tmp1.GetComponent<Image>();
			this.btn_FederalW[l] = this.Tmp1.GetChild(0).GetComponent<UIButton>();
			this.btn_FederalW[l].m_Handler = this;
			this.btn_FederalW[l].m_BtnID1 = 4;
			this.btn_FederalW[l].m_BtnID2 = this.mWonderNum + l;
			this.text_Federal_WonderName[l] = this.Tmp1.GetChild(1).GetComponent<UIText>();
			this.text_Federal_WonderName[l].font = this.TTFont;
			this.mtextOutline[l] = this.text_Federal_WonderName[l].transform.GetComponent<Outline>();
			if (this.door.TileMapController != null && this.door.TileMapController.yolk != null && DataManager.MapDataController.IsFocusWorldWar() && DataManager.MapDataController.CheckYolk((ushort)(this.mWonderNum + l), num))
			{
				this.Img_Federal[l].gameObject.SetActive(true);
				this.Img_Federal[l].sprite = this.door.TileMapController.yolk.getMapTileYolkSprite((byte)(this.mWonderNum + l));
				this.Img_Federal[l].material = this.door.TileMapController.yolk.getMapTileYolkMaterial((byte)(this.mWonderNum + l));
				this.text_Federal_WonderName[l].text = DataManager.MapDataController.GetYolkName((ushort)(this.mWonderNum + l), num).ToString();
				this.SetWonderPos(num, (byte)(this.mWonderNum + l), this.Img_Federal[l].rectTransform);
				this.mtextOutline[l].enabled = false;
			}
		}
		if (DataManager.MapDataController.IsFocusWorldWar())
		{
			if (this.ActM.FederalFightingWonderID != 0)
			{
				this.Federal_FightRT.gameObject.SetActive(true);
			}
			if (this.ActM.FederalHomeKingdomWonderID != 0)
			{
				this.Federal_HomeRT.gameObject.SetActive(true);
				this.Federal_BGRT.gameObject.SetActive(true);
			}
			this.UpdataFederalActivity(true);
		}
		this.Tmp1 = this.Tmp.GetChild(8);
		this.NewCenterPosRT = this.Tmp1.GetComponent<RectTransform>();
		this.Img_NewCenterPos = this.Tmp1.GetComponent<Image>();
		this.Tmp1 = this.Tmp.GetChild(9);
		this.btn_Castle = this.Tmp1.GetComponent<UIButton>();
		this.CastleRT = this.Tmp1.GetComponent<RectTransform>();
		this.btn_Castle.m_Handler = this;
		this.btn_Castle.m_BtnID1 = 2;
		this.Tmp1 = this.Tmp.GetChild(9).GetChild(0);
		this.Img_Castle = this.Tmp1.GetComponent<Image>();
		this.Tmp1 = this.Tmp.GetChild(9).GetChild(0).GetChild(0);
		this.text_Castle = this.Tmp1.GetComponent<UIText>();
		this.text_Castle.font = this.TTFont;
		this.text_Castle.text = this.DM.mStringTable.GetStringByID(496u);
		this.text_Castle.SetAllDirty();
		this.text_Castle.cachedTextGenerator.Invalidate();
		this.text_Castle.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_Castle.preferredWidth > this.text_Castle.rectTransform.sizeDelta.x)
		{
			this.text_Castle.rectTransform.sizeDelta = new Vector2(this.text_Castle.preferredWidth + 1f, this.text_Castle.rectTransform.sizeDelta.y);
			this.Img_Castle.rectTransform.sizeDelta = new Vector2(this.text_Castle.preferredWidth + 21f, this.Img_Castle.rectTransform.sizeDelta.y);
		}
		this.Tmp1 = this.Tmp.GetChild(10);
		this.btn_Page = this.Tmp1.GetComponent<UIButton>();
		this.btn_Page.m_Handler = this;
		this.btn_Page.m_BtnID1 = 1;
		this.btn_Page.m_EffectType = e_EffectType.e_Scale;
		this.btn_Page.transition = Selectable.Transition.None;
		if (DataManager.MapDataController.IsFocusWorldWar())
		{
			this.btn_Page.gameObject.SetActive(false);
		}
		this.Tmp1 = this.Tmp.GetChild(11);
		this.text_Title = this.Tmp1.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.mTitle[0];
		this.Tmp = this.GameT.GetChild(4);
		component2 = this.Tmp.GetComponent<Image>();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_close_base");
		component2.sprite = this.door.LoadSprite(cstring);
		component2.material = this.mMaT;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component2.enabled = false;
		}
		this.Tmp = this.GameT.GetChild(4).GetChild(0);
		this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_close");
		this.btn_EXIT.image.sprite = this.door.LoadSprite(cstring);
		this.btn_EXIT.image.material = this.mMaT;
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
		{
			this.CastleRT.gameObject.SetActive(true);
		}
		else
		{
			this.CastleRT.gameObject.SetActive(false);
		}
		this.SetCastle();
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 1);
	}

	// Token: 0x06001EB2 RID: 7858 RVA: 0x003AB430 File Offset: 0x003A9630
	public override void OnClose()
	{
		for (int i = 0; i < 5; i++)
		{
			if (this.Cstr_Lv[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Lv[i]);
			}
		}
		for (int j = 0; j < 7; j++)
		{
			if (this.door.TileMapController != null && this.door.TileMapController.yolk != null)
			{
				this.btn_W[j].image.sprite = null;
				this.btn_W[j].image.material = null;
			}
		}
		for (int k = 0; k < 30; k++)
		{
			if (this.door.TileMapController != null && this.door.TileMapController.yolk != null)
			{
				this.btn_FederalW[k].image.sprite = null;
				this.btn_FederalW[k].image.material = null;
			}
		}
	}

	// Token: 0x06001EB3 RID: 7859 RVA: 0x003AB538 File Offset: 0x003A9738
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.bResourse)
			{
				this.SetPage();
			}
			else if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 1:
			this.SetPage();
			break;
		case 2:
			this.SetNewCenterPos(65534, 0, 0);
			break;
		case 3:
			this.SetNewCenterPos((ushort)sender.m_BtnID2, 0, 0);
			break;
		case 4:
			this.SetNewCenterPos((ushort)sender.m_BtnID2, 0, 0);
			break;
		}
	}

	// Token: 0x06001EB4 RID: 7860 RVA: 0x003AB5E8 File Offset: 0x003A97E8
	public void SetWonderPos(ushort KID, byte mWonderID, RectTransform mRT)
	{
		this.TcenterID = DataManager.MapDataController.GetYolkPos((ushort)mWonderID, KID);
		if (this.GUIM.IsArabic)
		{
			float num = this.TcenterID.x / 510f * 600f + (this.mCanvasRT.sizeDelta.x / 2f - 300f);
			float num2 = num - this.mCanvasRT.sizeDelta.x / 2f;
			mRT.anchoredPosition = new Vector2(num - num2 * 2f - mRT.sizeDelta.x / 2f - this.mIPhoneX_DeltaX, -this.TcenterID.y / 1022f * 600f - (this.mCanvasRT.sizeDelta.y / 2f - 300f) + mRT.sizeDelta.y / 2f);
		}
		else
		{
			mRT.anchoredPosition = new Vector2(this.TcenterID.x / 510f * 600f + (this.mCanvasRT.sizeDelta.x / 2f - 300f) - mRT.sizeDelta.x / 2f - this.mIPhoneX_DeltaX, -this.TcenterID.y / 1022f * 600f - (this.mCanvasRT.sizeDelta.y / 2f - 300f) + mRT.sizeDelta.y / 2f);
		}
	}

	// Token: 0x06001EB5 RID: 7861 RVA: 0x003AB7A8 File Offset: 0x003A99A8
	public void UpdataFederalActivity(bool SetAll = true)
	{
		int num = (int)this.ActM.FederalFightingWonderID - this.mWonderNum;
		if (num < 0 || num >= this.Img_Federal.Length)
		{
			num = 0;
		}
		this.Federal_FightRT.anchoredPosition = new Vector2(this.Img_Federal[num].rectTransform.anchoredPosition.x + (this.Img_Federal[num].rectTransform.sizeDelta.x - this.Federal_FightRT.sizeDelta.x) / 2f, this.Img_Federal[num].rectTransform.anchoredPosition.y + 40f);
		if (SetAll)
		{
			this.text_Federal_WonderName[(int)this.mFederal_Home].color = new Color(0.486f, 0.294f, 0.149f);
			this.mtextOutline[(int)this.mFederal_Home].enabled = false;
			int num2 = (int)this.ActM.FederalHomeKingdomWonderID - this.mWonderNum;
			if (num2 < 0 || num2 >= this.text_Federal_WonderName.Length)
			{
				num2 = 0;
			}
			this.mFederal_Home = (ushort)num2;
			if (this.ActM.FederalHomeKingdomWonderID != 0)
			{
				this.mtextOutline[(int)this.mFederal_Home].enabled = true;
				this.text_Federal_WonderName[(int)this.mFederal_Home].color = new Color(0f, 0.894f, 1f);
			}
			if (this.ActM.FederalFightingWonderID == 0 || num != num2)
			{
				this.Federal_HomeRT.anchoredPosition = new Vector2(this.Img_Federal[num2].rectTransform.anchoredPosition.x + (this.Img_Federal[num2].rectTransform.sizeDelta.x - this.Federal_HomeRT.sizeDelta.x) / 2f, this.Img_Federal[num2].rectTransform.anchoredPosition.y + 34f);
			}
			else
			{
				this.Federal_HomeRT.anchoredPosition = new Vector2(this.Federal_FightRT.anchoredPosition.x + this.Federal_FightRT.sizeDelta.x - 7f, this.Federal_FightRT.anchoredPosition.y - (this.Federal_FightRT.sizeDelta.y - this.Federal_HomeRT.sizeDelta.y) + 3f);
			}
			if (!this.Img_Federal[num2].gameObject.activeInHierarchy)
			{
				this.Federal_BGRT.gameObject.SetActive(false);
			}
			this.Federal_BGRT.anchoredPosition = new Vector2(this.Img_Federal[num2].rectTransform.anchoredPosition.x - (this.Federal_BGRT.sizeDelta.x - this.Img_Federal[num].rectTransform.sizeDelta.x) / 2f, this.Img_Federal[num2].rectTransform.anchoredPosition.y + (this.Federal_BGRT.sizeDelta.y - this.Img_Federal[num].rectTransform.sizeDelta.y) / 2f + 2f);
		}
	}

	// Token: 0x06001EB6 RID: 7862 RVA: 0x003ABB20 File Offset: 0x003A9D20
	public void SetPage()
	{
		this.bResourse = !this.bResourse;
		if (this.bResourse)
		{
			for (int i = 0; i < 7; i++)
			{
				this.btn_W[i].image.color = new Color(1f, 1f, 1f, 0.3f);
				this.text_WonderName[i].gameObject.SetActive(false);
			}
			this.P1.gameObject.SetActive(false);
			this.P2.gameObject.SetActive(true);
			this.text_Title.text = this.mTitle[1];
			this.btn_Page.gameObject.SetActive(false);
		}
		else
		{
			for (int j = 0; j < 7; j++)
			{
				this.btn_W[j].image.color = new Color(1f, 1f, 1f, 1f);
				this.text_WonderName[j].gameObject.SetActive(true);
			}
			this.P1.gameObject.SetActive(true);
			ushort kingdomID;
			if (DataManager.MapDataController.FocusKingdomID != 0)
			{
				kingdomID = DataManager.MapDataController.FocusKingdomID;
			}
			else
			{
				kingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
			}
			if (this.ActM.GetFIFAState() == EActivityState.EAS_Run && !DataManager.MapDataController.IsFocusWorldWar() && !this.ActM.bPassLastWave)
			{
				if (this.ActM.IsInKvK(0, false) && !this.ActM.IsMatchKvk_kingdom(kingdomID))
				{
					this.FootBall_T.gameObject.SetActive(false);
				}
				else
				{
					this.FootBall_T.gameObject.SetActive(true);
					if (this.ActM.NowWaveEndTime != 0L)
					{
						this.text_FootBallTitle.text = this.DM.mStringTable.GetStringByID(17525u);
					}
					else
					{
						this.text_FootBallTitle.text = this.DM.mStringTable.GetStringByID(17526u);
					}
					this.text_FootBallTitle.SetAllDirty();
					this.text_FootBallTitle.cachedTextGenerator.Invalidate();
					this.text_FootBallTitle.cachedTextGeneratorForLayout.Invalidate();
					float num = 500f;
					if (this.text_FootBallTitle.preferredWidth > this.text_FootBallTitle.rectTransform.sizeDelta.x)
					{
						if (this.text_FootBallTitle.preferredWidth < num)
						{
							num = this.text_FootBallTitle.preferredWidth + 1f;
						}
						this.text_FootBallTitle.rectTransform.sizeDelta = new Vector2(num, this.text_FootBallTitle.rectTransform.sizeDelta.y);
						this.ImgFootBall.rectTransform.anchoredPosition = new Vector2(-num / 2f - 14f, this.ImgFootBall.rectTransform.anchoredPosition.y);
					}
				}
			}
			else
			{
				this.FootBall_T.gameObject.SetActive(false);
			}
			this.P2.gameObject.SetActive(false);
			this.text_Title.text = this.mTitle[0];
			this.btn_Page.gameObject.SetActive(true);
		}
		this.text_Title.SetAllDirty();
		this.text_Title.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001EB7 RID: 7863 RVA: 0x003ABE94 File Offset: 0x003AA094
	public void SetCastle()
	{
		this.TcenterID = GameConstants.getTileMapPosbyMapID(this.DM.RoleAttr.CapitalPoint);
		if (this.GUIM.IsArabic)
		{
			float num = this.TcenterID.x / 512f * 600f + (this.mCanvasRT.sizeDelta.x / 2f - 300f);
			float num2 = num - this.mCanvasRT.sizeDelta.x / 2f;
			this.CastleRT.anchoredPosition = new Vector2(num - num2 * 2f - this.mIPhoneX_DeltaX, -this.TcenterID.y / 1024f * 600f - (this.mCanvasRT.sizeDelta.y / 2f - 300f));
		}
		else
		{
			this.CastleRT.anchoredPosition = new Vector2(this.TcenterID.x / 512f * 600f + (this.mCanvasRT.sizeDelta.x / 2f - 300f) - this.mIPhoneX_DeltaX, -this.TcenterID.y / 1024f * 600f - (this.mCanvasRT.sizeDelta.y / 2f - 300f));
		}
		this.TcenterID = this.GUIM.mNewCenterPos;
		if (this.GUIM.IsArabic)
		{
			float num3 = this.TcenterID.x / 512f * 600f + (this.mCanvasRT.sizeDelta.x / 2f - 300f);
			float num4 = num3 - this.mCanvasRT.sizeDelta.x / 2f;
			this.NewCenterPosRT.anchoredPosition = new Vector2(num3 - num4 * 2f - this.mIPhoneX_DeltaX, -this.TcenterID.y / 1024f * 600f - (this.mCanvasRT.sizeDelta.y / 2f - 300f));
		}
		else
		{
			this.NewCenterPosRT.anchoredPosition = new Vector2(this.TcenterID.x / 512f * 600f + (this.mCanvasRT.sizeDelta.x / 2f - 300f) - this.mIPhoneX_DeltaX, -this.TcenterID.y / 1024f * 600f - (this.mCanvasRT.sizeDelta.y / 2f - 300f));
		}
	}

	// Token: 0x06001EB8 RID: 7864 RVA: 0x003AC174 File Offset: 0x003AA374
	public void OnPointerDown(PointerEventData eventData)
	{
		this.bSetPosShow = false;
		this.PosX = (this.PosY = 0);
	}

	// Token: 0x06001EB9 RID: 7865 RVA: 0x003AC198 File Offset: 0x003AA398
	public void OnPointerUp(PointerEventData eventData)
	{
		if (Mathf.Abs(eventData.pressPosition.x - eventData.position.x) < 50f && Mathf.Abs(eventData.pressPosition.y - eventData.position.y) < 50f)
		{
			Vector2 vector;
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(this.P1.rectTransform, eventData.position, eventData.pressEventCamera, out vector))
			{
				return;
			}
			float num;
			if (this.GUIM.IsArabic)
			{
				num = (300f - vector.x) / 600f * 510f;
			}
			else
			{
				num = (vector.x + 300f) / 600f * 510f;
			}
			float num2 = (600f - (vector.y + 300f)) / 600f * 1022f;
			num = Mathf.Clamp(num, 0f, 510f);
			num2 = Mathf.Clamp(num2, 0f, 1022f);
			if (DataManager.MapDataController.CheckKingdomID(DataManager.MapDataController.FocusKingdomID) && GameConstants.CheckTileMapPos((int)num, (int)num2))
			{
				this.SetNewCenterPos(ushort.MaxValue, (int)num, (int)num2);
			}
		}
	}

	// Token: 0x06001EBA RID: 7866 RVA: 0x003AC2F4 File Offset: 0x003AA4F4
	public void SetNewCenterPos(ushort mType = 65535, int mPosX = 0, int mPosY = 0)
	{
		this.PosX = mPosX;
		this.PosY = mPosY;
		this.bSetPosShow = true;
		this.mShowTime = 0f;
		this.mGoToType = mType;
		if (mType == 65535)
		{
			this.TcenterID.Set((float)this.PosX, (float)this.PosY);
		}
		else if (mType == 65534)
		{
			this.TcenterID = GameConstants.getTileMapPosbyMapID(this.DM.RoleAttr.CapitalPoint);
		}
		else
		{
			this.TcenterID = DataManager.MapDataController.GetYolkPos(mType, DataManager.MapDataController.FocusKingdomID);
		}
		this.PosX = (int)this.TcenterID.x;
		this.PosY = (int)this.TcenterID.y;
		if (this.GUIM.IsArabic)
		{
			float num = this.TcenterID.x / 512f * 600f + (this.mCanvasRT.sizeDelta.x / 2f - 300f);
			float num2 = num - this.mCanvasRT.sizeDelta.x / 2f;
			this.NewCenterPosRT.anchoredPosition = new Vector2(num - num2 * 2f - this.mIPhoneX_DeltaX, -this.TcenterID.y / 1024f * 600f - (this.mCanvasRT.sizeDelta.y / 2f - 300f));
		}
		else
		{
			this.NewCenterPosRT.anchoredPosition = new Vector2(this.TcenterID.x / 512f * 600f + (this.mCanvasRT.sizeDelta.x / 2f - 300f) - this.mIPhoneX_DeltaX, -this.TcenterID.y / 1024f * 600f - (this.mCanvasRT.sizeDelta.y / 2f - 300f));
		}
		this.NewCenterPosRT.localScale = new Vector3(3f, 3f, 3f);
		this.Img_NewCenterPos.color = new Color(1f, 1f, 1f, 0f);
	}

	// Token: 0x06001EBB RID: 7867 RVA: 0x003AC550 File Offset: 0x003AA750
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 0:
		{
			ushort num;
			if (DataManager.MapDataController.FocusKingdomID != 0)
			{
				num = DataManager.MapDataController.FocusKingdomID;
			}
			else
			{
				num = DataManager.MapDataController.OtherKingdomData.kingdomID;
			}
			for (int i = 0; i < 40; i++)
			{
				if (i == 0)
				{
					this.Img_W[i].gameObject.SetActive(DataManager.MapDataController.CheckYolk((ushort)i, num));
				}
				else if (DataManager.MapDataController.IsFocusWorldWar())
				{
					if (i < this.Img_W.Length)
					{
						this.Img_W[i].gameObject.SetActive(false);
					}
					if (i < this.Img_Federal.Length + 1)
					{
						this.Img_Federal[i - 1].gameObject.SetActive(DataManager.MapDataController.CheckYolk((ushort)i, num));
						if (this.Img_Federal[i - 1].gameObject.activeSelf)
						{
							this.Img_Federal[i - 1].sprite = this.door.TileMapController.yolk.getMapTileYolkSprite((byte)i);
							this.Img_Federal[i - 1].material = this.door.TileMapController.yolk.getMapTileYolkMaterial((byte)i);
							this.text_Federal_WonderName[i - 1].text = DataManager.MapDataController.GetYolkName((ushort)i, num).ToString();
							this.SetWonderPos(num, (byte)i, this.Img_Federal[i - 1].rectTransform);
							this.mtextOutline[i - 1].enabled = false;
						}
					}
				}
				else
				{
					if (i < this.Img_W.Length)
					{
						this.Img_W[i].gameObject.SetActive(DataManager.MapDataController.CheckYolk((ushort)i, num));
					}
					if (i < this.Img_Federal.Length + 1)
					{
						this.Img_Federal[i - 1].gameObject.SetActive(false);
					}
				}
				if (i < this.Img_W.Length && this.Img_W[i] != null && this.Img_W[i].gameObject.activeSelf && this.Img_W[i].sprite == null)
				{
					this.Img_W[i].sprite = this.door.TileMapController.yolk.getMapTileYolkSprite((byte)i);
					this.Img_W[i].material = this.door.TileMapController.yolk.getMapTileYolkMaterial((byte)i);
				}
			}
			if (DataManager.MapDataController.IsFocusWorldWar())
			{
				if (this.ActM.FederalFightingWonderID != 0)
				{
					this.Federal_FightRT.gameObject.SetActive(true);
				}
				else
				{
					this.Federal_FightRT.gameObject.SetActive(false);
				}
				if (this.ActM.FederalHomeKingdomWonderID != 0)
				{
					this.Federal_HomeRT.gameObject.SetActive(true);
					this.Federal_BGRT.gameObject.SetActive(true);
				}
				else
				{
					this.Federal_HomeRT.gameObject.SetActive(false);
					this.Federal_BGRT.gameObject.SetActive(false);
				}
				this.UpdataFederalActivity(true);
			}
			break;
		}
		case 1:
			if (DataManager.MapDataController.IsFocusWorldWar())
			{
				if (this.ActM.FederalFightingWonderID != 0)
				{
					this.Federal_FightRT.gameObject.SetActive(true);
				}
				else
				{
					this.Federal_FightRT.gameObject.SetActive(false);
				}
				if (this.ActM.FederalHomeKingdomWonderID != 0)
				{
					this.Federal_HomeRT.gameObject.SetActive(true);
					this.Federal_BGRT.gameObject.SetActive(true);
				}
				else
				{
					this.Federal_HomeRT.gameObject.SetActive(false);
					this.Federal_BGRT.gameObject.SetActive(false);
				}
				this.UpdataFederalActivity(true);
			}
			break;
		case 2:
			if (this.ActM.GetFIFAState() == EActivityState.EAS_Run && !DataManager.MapDataController.IsFocusWorldWar() && !this.ActM.bPassLastWave)
			{
				ushort kingdomID;
				if (DataManager.MapDataController.FocusKingdomID != 0)
				{
					kingdomID = DataManager.MapDataController.FocusKingdomID;
				}
				else
				{
					kingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
				}
				if (this.ActM.IsInKvK(0, false) && !this.ActM.IsMatchKvk_kingdom(kingdomID))
				{
					this.FootBall_T.gameObject.SetActive(false);
				}
				else
				{
					if (this.P1.gameObject.activeInHierarchy)
					{
						this.FootBall_T.gameObject.SetActive(true);
					}
					if (this.ActM.NowWaveEndTime != 0L)
					{
						this.text_FootBallTitle.text = this.DM.mStringTable.GetStringByID(17525u);
					}
					else
					{
						this.text_FootBallTitle.text = this.DM.mStringTable.GetStringByID(17526u);
					}
					this.text_FootBallTitle.SetAllDirty();
					this.text_FootBallTitle.cachedTextGenerator.Invalidate();
					this.text_FootBallTitle.cachedTextGeneratorForLayout.Invalidate();
					float num2 = 500f;
					if (this.text_FootBallTitle.preferredWidth < num2)
					{
						num2 = this.text_FootBallTitle.preferredWidth + 1f;
					}
					this.text_FootBallTitle.rectTransform.sizeDelta = new Vector2(num2, this.text_FootBallTitle.rectTransform.sizeDelta.y);
					this.ImgFootBall.rectTransform.anchoredPosition = new Vector2(-num2 / 2f - 14f, this.ImgFootBall.rectTransform.anchoredPosition.y);
				}
			}
			else
			{
				this.FootBall_T.gameObject.SetActive(false);
			}
			break;
		}
	}

	// Token: 0x06001EBC RID: 7868 RVA: 0x003ACB2C File Offset: 0x003AAD2C
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
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				this.CastleRT.gameObject.SetActive(true);
			}
			else
			{
				this.CastleRT.gameObject.SetActive(false);
			}
			this.SetCastle();
			ushort num;
			if (DataManager.MapDataController.FocusKingdomID != 0)
			{
				num = DataManager.MapDataController.FocusKingdomID;
			}
			else
			{
				num = DataManager.MapDataController.OtherKingdomData.kingdomID;
			}
			for (int i = 0; i < 40; i++)
			{
				if (i == 0)
				{
					this.Img_W[i].gameObject.SetActive(DataManager.MapDataController.CheckYolk((ushort)i, num));
				}
				else if (DataManager.MapDataController.IsFocusWorldWar())
				{
					if (i < this.Img_W.Length)
					{
						this.Img_W[i].gameObject.SetActive(false);
					}
					if (i < this.Img_Federal.Length + 1)
					{
						this.Img_Federal[i - 1].gameObject.SetActive(DataManager.MapDataController.CheckYolk((ushort)i, num));
						if (this.Img_Federal[i - 1].gameObject.activeSelf)
						{
							this.Img_Federal[i - 1].sprite = this.door.TileMapController.yolk.getMapTileYolkSprite((byte)i);
							this.Img_Federal[i - 1].material = this.door.TileMapController.yolk.getMapTileYolkMaterial((byte)i);
							this.text_Federal_WonderName[i - 1].text = DataManager.MapDataController.GetYolkName((ushort)i, num).ToString();
							this.SetWonderPos(num, (byte)i, this.Img_Federal[i - 1].rectTransform);
							this.mtextOutline[i - 1].enabled = false;
						}
					}
				}
				else
				{
					if (i < this.Img_W.Length)
					{
						this.Img_W[i].gameObject.SetActive(DataManager.MapDataController.CheckYolk((ushort)i, num));
					}
					if (i < this.Img_Federal.Length + 1)
					{
						this.Img_Federal[i - 1].gameObject.SetActive(false);
					}
				}
				if (i < this.Img_W.Length && this.Img_W[i] != null && this.Img_W[i].gameObject.activeSelf && this.Img_W[i].sprite == null)
				{
					this.Img_W[i].sprite = this.door.TileMapController.yolk.getMapTileYolkSprite((byte)i);
					this.Img_W[i].material = this.door.TileMapController.yolk.getMapTileYolkMaterial((byte)i);
				}
			}
			if (DataManager.MapDataController.IsFocusWorldWar())
			{
				if (this.ActM.FederalFightingWonderID != 0)
				{
					this.Federal_FightRT.gameObject.SetActive(true);
				}
				else
				{
					this.Federal_FightRT.gameObject.SetActive(false);
				}
				if (this.ActM.FederalHomeKingdomWonderID != 0)
				{
					this.Federal_HomeRT.gameObject.SetActive(true);
					this.Federal_BGRT.gameObject.SetActive(true);
				}
				else
				{
					this.Federal_HomeRT.gameObject.SetActive(false);
					this.Federal_BGRT.gameObject.SetActive(false);
				}
				this.UpdataFederalActivity(true);
			}
		}
	}

	// Token: 0x06001EBD RID: 7869 RVA: 0x003ACEC0 File Offset: 0x003AB0C0
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Castle != null && this.text_Castle.enabled)
		{
			this.text_Castle.enabled = false;
			this.text_Castle.enabled = true;
		}
		if (this.text_FootBallTitle != null && this.text_FootBallTitle.enabled)
		{
			this.text_FootBallTitle.enabled = false;
			this.text_FootBallTitle.enabled = true;
		}
		for (int i = 0; i < 5; i++)
		{
			if (this.text_Lv[i] != null && this.text_Lv[i].enabled)
			{
				this.text_Lv[i].enabled = false;
				this.text_Lv[i].enabled = true;
			}
		}
		for (int j = 0; j < 7; j++)
		{
			if (this.text_WonderName[j] != null && this.text_WonderName[j].enabled)
			{
				this.text_WonderName[j].enabled = false;
				this.text_WonderName[j].enabled = true;
			}
		}
		for (int k = 0; k < 30; k++)
		{
			if (this.text_Federal_WonderName[k] != null && this.text_Federal_WonderName[k].enabled)
			{
				this.text_Federal_WonderName[k].enabled = false;
				this.text_Federal_WonderName[k].enabled = true;
			}
		}
	}

	// Token: 0x06001EBE RID: 7870 RVA: 0x003AD074 File Offset: 0x003AB274
	private void Start()
	{
	}

	// Token: 0x06001EBF RID: 7871 RVA: 0x003AD078 File Offset: 0x003AB278
	private void Update()
	{
	}

	// Token: 0x06001EC0 RID: 7872 RVA: 0x003AD07C File Offset: 0x003AB27C
	public override void UpdateTime(bool bOnSecond)
	{
		if (!bOnSecond && this.bSetPosShow && this.door != null)
		{
			this.mShowTime += Time.smoothDeltaTime;
			if (this.mShowTime < 0.1f)
			{
				this.mscaleValue = Mathf.Lerp(2.5f, 1f, this.mShowTime / 0.1f);
				this.malphaValue = Mathf.Lerp(0f, 1f, this.mShowTime / 0.1f);
			}
			else
			{
				this.mscaleValue = 1f;
				this.malphaValue = 1f;
			}
			this.NewCenterPosRT.localScale = new Vector3(this.mscaleValue, this.mscaleValue, this.mscaleValue);
			this.Img_NewCenterPos.color = new Color(1f, 1f, 1f, this.malphaValue);
			if (this.mShowTime >= 0.1f)
			{
				this.bSetPosShow = false;
				this.mShowTime = 0f;
				this.door.CheckFocusGroup();
				DataManager.MapDataController.FocusGroupID = 10;
				this.door.GoToMapID(DataManager.MapDataController.FocusKingdomID, GameConstants.TileMapPosToMapID(this.PosX, this.PosY), 0, 1, true);
			}
		}
	}

	// Token: 0x04006135 RID: 24885
	private Transform GameT;

	// Token: 0x04006136 RID: 24886
	private Transform Tmp;

	// Token: 0x04006137 RID: 24887
	private Transform Tmp1;

	// Token: 0x04006138 RID: 24888
	private Transform Federal_T;

	// Token: 0x04006139 RID: 24889
	private Transform FootBall_T;

	// Token: 0x0400613A RID: 24890
	private RectTransform CastleRT;

	// Token: 0x0400613B RID: 24891
	private RectTransform mCanvasRT;

	// Token: 0x0400613C RID: 24892
	private RectTransform Federal_FightRT;

	// Token: 0x0400613D RID: 24893
	private RectTransform Federal_HomeRT;

	// Token: 0x0400613E RID: 24894
	private RectTransform Federal_BGRT;

	// Token: 0x0400613F RID: 24895
	private RectTransform NewCenterPosRT;

	// Token: 0x04006140 RID: 24896
	private DataManager DM;

	// Token: 0x04006141 RID: 24897
	private GUIManager GUIM;

	// Token: 0x04006142 RID: 24898
	private ActivityManager ActM;

	// Token: 0x04006143 RID: 24899
	private Font TTFont;

	// Token: 0x04006144 RID: 24900
	private Door door;

	// Token: 0x04006145 RID: 24901
	private Material mMaT;

	// Token: 0x04006146 RID: 24902
	private UIButton btn_EXIT;

	// Token: 0x04006147 RID: 24903
	private UIButton[] btn_W = new UIButton[7];

	// Token: 0x04006148 RID: 24904
	private UIButton btn_Page;

	// Token: 0x04006149 RID: 24905
	private UIButton btn_Castle;

	// Token: 0x0400614A RID: 24906
	private UIButton[] btn_FederalW = new UIButton[30];

	// Token: 0x0400614B RID: 24907
	private Image P1;

	// Token: 0x0400614C RID: 24908
	private Image P2;

	// Token: 0x0400614D RID: 24909
	private Image Img_Castle;

	// Token: 0x0400614E RID: 24910
	private Image Img_NewCenterPos;

	// Token: 0x0400614F RID: 24911
	private Image[] Img_Federal = new Image[30];

	// Token: 0x04006150 RID: 24912
	private Image[] Img_W = new Image[7];

	// Token: 0x04006151 RID: 24913
	private Image ImgFootBall;

	// Token: 0x04006152 RID: 24914
	private UIText text_Castle;

	// Token: 0x04006153 RID: 24915
	private UIText text_Title;

	// Token: 0x04006154 RID: 24916
	private UIText[] text_Lv = new UIText[5];

	// Token: 0x04006155 RID: 24917
	private UIText[] text_WonderName = new UIText[7];

	// Token: 0x04006156 RID: 24918
	private UIText[] text_Federal_WonderName = new UIText[30];

	// Token: 0x04006157 RID: 24919
	private UIText text_FootBallTitle;

	// Token: 0x04006158 RID: 24920
	private Outline[] mtextOutline = new Outline[30];

	// Token: 0x04006159 RID: 24921
	private CString[] Cstr_Lv = new CString[5];

	// Token: 0x0400615A RID: 24922
	private string[] mTitle = new string[2];

	// Token: 0x0400615B RID: 24923
	private bool bResourse;

	// Token: 0x0400615C RID: 24924
	private ushort mFederal_Home;

	// Token: 0x0400615D RID: 24925
	private Vector2 TcenterID = Vector2.zero;

	// Token: 0x0400615E RID: 24926
	private int mWonderNum = 1;

	// Token: 0x0400615F RID: 24927
	private int PosX;

	// Token: 0x04006160 RID: 24928
	private int PosY;

	// Token: 0x04006161 RID: 24929
	private bool bSetPosShow;

	// Token: 0x04006162 RID: 24930
	private float mShowTime;

	// Token: 0x04006163 RID: 24931
	private float mscaleValue;

	// Token: 0x04006164 RID: 24932
	private float malphaValue;

	// Token: 0x04006165 RID: 24933
	private ushort mGoToType;

	// Token: 0x04006166 RID: 24934
	private float mIPhoneX_DeltaX;
}
