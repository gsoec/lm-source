using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200051A RID: 1306
public class UICastleSkin : UICastleSkinWindow, IUIButtonDownUpHandler
{
	// Token: 0x06001A0E RID: 6670 RVA: 0x002C2E20 File Offset: 0x002C1020
	public override void OnOpen(int arg1, int arg2)
	{
		base.OnOpen(arg1, arg2);
		GUIManager instance = GUIManager.Instance;
		Font ttffont = instance.GetTTFFont();
		this.MainTitle.text = this.DM.mStringTable.GetStringByID(9682u);
		this.EnhanceObj = base.transform.GetChild(0).gameObject;
		for (int i = 0; i < this.EnhanceImg.Length; i++)
		{
			this.EnhanceImg[i] = base.transform.GetChild(0).GetChild(0).GetChild(i).GetComponent<Image>();
		}
		this.InfoHint = base.transform.GetChild(0).GetChild(2).gameObject.AddComponent<UIButtonHint>();
		this.InfoHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.InfoHint.m_Handler = this;
		this.InfoHint.m_ForcePos = true;
		this.InfoHint.m_HIBtnOffset = new Vector2(142f, -134f);
		this.InfoHint.ControlFadeOut = this.Hint.ThisTransform.gameObject;
		this.InfoHint.Parm1 = 1;
		UIButton component = base.transform.GetChild(0).GetChild(1).GetComponent<UIButton>();
		component.m_BtnID1 = 0;
		component.m_Handler = this;
		this.EnhanceBtnObj = component.gameObject;
		this.EnhanceNoticeObj = base.transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
		this.Name = base.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.Name.font = ttffont;
		this.pixelsPerUnit = this.Name.pixelsPerUnit;
		this.InfoRect = base.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<RectTransform>();
		this.InfoObj = this.InfoRect.gameObject;
		this.InfoHint = base.transform.GetChild(1).gameObject.AddComponent<UIButtonHint>();
		this.InfoHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.InfoHint.m_Handler = this;
		this.InfoHint.m_ForcePos = true;
		this.InfoHint.m_HIBtnOffset = new Vector2(142f, -134f);
		this.InfoHint.ControlFadeOut = this.Hint.ThisTransform.gameObject;
		if (instance.IsArabic)
		{
			base.transform.GetChild(1).GetChild(0).GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
		}
		this.InfoAlpha = base.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<CanvasGroup>();
		this.CastleImg = base.transform.GetChild(2).GetComponent<Image>();
		this.CastleRect = this.CastleImg.rectTransform;
		this.InUseImg = base.transform.GetChild(3).GetComponent<Image>();
		if (instance.IsArabic)
		{
			this.CastleImg.rectTransform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
		}
		this.NextObj = base.transform.GetChild(4).gameObject;
		this.NextBtn = base.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
		this.NextBtn.m_Handler = this;
		this.NextBtn.m_BtnID1 = 3;
		bool flag = false;
		this.PriceStr = StringManager.Instance.SpawnString(30);
		Transform child = base.transform.GetChild(6);
		component = child.GetComponent<UIButton>();
		component.m_BtnID1 = 2;
		component.m_Handler = this;
		this.BuyObj = child.gameObject;
		if (flag)
		{
			child.GetChild(0).gameObject.SetActive(false);
			child.GetChild(2).gameObject.SetActive(true);
			child.GetChild(3).gameObject.SetActive(true);
			this.PriceText = child.GetChild(3).GetComponent<Text>();
			this.PriceText.font = ttffont;
		}
		else
		{
			this.PriceText = child.GetChild(0).GetComponent<Text>();
			this.PriceText.font = ttffont;
		}
		if (instance.IsArabic)
		{
			this.PriceText.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		this.BuyText = child.GetChild(1).GetComponent<UIText>();
		this.BuyText.font = ttffont;
		this.BuyText.text = this.DM.mStringTable.GetStringByID(284u);
		if (instance.IsArabic)
		{
			this.BuyText.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		this.UseObj = base.transform.GetChild(5).gameObject;
		this.UseBtnImg = base.transform.GetChild(5).GetComponent<Image>();
		this.UseBtn = base.transform.GetChild(5).GetComponent<UIButton>();
		this.UseBtn.m_BtnID1 = 1;
		this.UseBtn.m_Handler = this;
		this.UseText = base.transform.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.UseText.font = ttffont;
		this.ExclamationCount = this.buildsData.castleSkin.GetExclamationCount();
		this.UpdateViewData(false);
		if (this.CastleLv >= 9 && this.buildsData.castleSkin.UnlockCastleSkinNotice == 0)
		{
			this.buildsData.castleSkin.UnlockCastleSkinNotice = 1;
			this.buildsData.castleSkin.SaveCastleSkinSave();
			this.buildsData.UpdateBuildState(5, 255);
		}
	}

	// Token: 0x06001A0F RID: 6671 RVA: 0x002C33F8 File Offset: 0x002C15F8
	protected override void SetLargeSize(int screenWidth)
	{
		base.SetLargeSize(screenWidth);
		RectTransform component = base.transform.GetChild(5).GetComponent<RectTransform>();
		float num = 0.3125f * (float)screenWidth;
		if (num * 2f + component.sizeDelta.x < (float)screenWidth)
		{
			component.anchoredPosition = new Vector2(num, component.anchoredPosition.y);
		}
		component = base.transform.GetChild(6).GetComponent<RectTransform>();
		if (num * 2f + component.sizeDelta.x < (float)screenWidth)
		{
			component.anchoredPosition = new Vector2(num, component.anchoredPosition.y);
		}
	}

	// Token: 0x06001A10 RID: 6672 RVA: 0x002C34AC File Offset: 0x002C16AC
	public override void Initial()
	{
		base.Initial();
		this.buildsData.castleSkin.SaveCastleSkinSave();
		if (this.AllCastleID.Length > 6)
		{
			this.updateNextBtn = 1;
		}
	}

	// Token: 0x06001A11 RID: 6673 RVA: 0x002C34DC File Offset: 0x002C16DC
	private void UpdateNextBtnState()
	{
		if (!this.buildsData.castleSkin.CheckShowExclamation(false))
		{
			this.updateNextBtn = 0;
			this.NextObj.SetActive(false);
			return;
		}
		int num = this.CastleView.GetBeginIdx();
		num = Mathf.Clamp(num, 0, this.AllCastleID.Length - 1);
		this.NextBtn.m_BtnID2 = 0;
		for (int i = num + 5; i < this.AllCastleID.Length; i++)
		{
			if (!this.CastleView.CheckInPanel(i, false) && !this.buildsData.castleSkin.CheckSelect((byte)this.AllCastleID[i]))
			{
				this.NextBtn.m_BtnID2 = i;
				break;
			}
		}
		if (this.NextBtn.m_BtnID2 > 0)
		{
			this.NextObj.SetActive(true);
		}
		else
		{
			this.NextObj.SetActive(false);
		}
	}

	// Token: 0x06001A12 RID: 6674 RVA: 0x002C35C8 File Offset: 0x002C17C8
	private void UpdateEnhance(bool bReset = false)
	{
		byte castleEnhance = this.buildsData.castleSkin.GetCastleEnhance((byte)this.SelectedCastleID);
		if (!this.buildsData.castleSkin.CheckUnlock((byte)this.SelectedCastleID))
		{
			this.EnhanceObj.SetActive(false);
			return;
		}
		if (!this.DM.CheckPrizeFlag(21))
		{
			this.EnhanceNoticeObj.SetActive(true);
		}
		this.EnhanceObj.SetActive(true);
		if (this.Rank != castleEnhance)
		{
			this.Rank = castleEnhance;
			if (!bReset)
			{
				int num = (int)this.Rank;
				while (this.Rank < castleEnhance)
				{
					this.EnhanceImg[num].sprite = this.StarArray.GetSprite(1);
					num++;
				}
			}
			else
			{
				byte b = 0;
				while ((int)b < this.EnhanceImg.Length)
				{
					if (this.Rank > b)
					{
						this.EnhanceImg[(int)b].sprite = this.StarArray.GetSprite(1);
					}
					else
					{
						this.EnhanceImg[(int)b].sprite = this.StarArray.GetSprite(0);
					}
					b += 1;
				}
			}
		}
	}

	// Token: 0x06001A13 RID: 6675 RVA: 0x002C36F0 File Offset: 0x002C18F0
	private void UpdateViewData(bool bForce = false)
	{
		if (bForce)
		{
			this.CurUseCastleID = 0;
		}
		else if ((ushort)this.CurUseCastleID != this.SelectedCastleID)
		{
			this.ResetEffect();
			this.RetrieveEffect();
		}
		if ((ushort)this.CurUseCastleID != this.SelectedCastleID)
		{
			this.CurUseCastleID = (byte)this.SelectedCastleID;
			CastleSkinTbl recordByKey = this.buildsData.castleSkin.CastleSkinTable.GetRecordByKey((ushort)this.CurUseCastleID);
			this.Name.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.Name);
			this.CastleImg.sprite = this.buildsData.castleSkin.GetUISprite(recordByKey.Graphic, this.CastleLv);
			this.CastleImg.material = this.buildsData.castleSkin.GetUIMaterial(recordByKey.Graphic, this.CastleLv);
			this.CastleImg.SetNativeSize();
			this.UpdateEnhance(true);
			this.ItemID = (ushort)recordByKey.ItemID;
			this.UnlockPercentage = recordByKey.UnlockPercentage;
			this.PreViewPercentage = recordByKey.PreViewPercentage;
			this.UpdateUseBtnState();
			this.UpdateEnhanceBtnState();
			this.DelayUpdateText = 2;
			if (this.CurUseCastleID == this.buildsData.CastleID)
			{
				this.InUseImg.enabled = true;
			}
			else
			{
				this.InUseImg.enabled = false;
			}
		}
	}

	// Token: 0x06001A14 RID: 6676 RVA: 0x002C3858 File Offset: 0x002C1A58
	private void UpdateUseBtnState()
	{
		if (this.buildsData.castleSkin.CheckUnlock(this.CurUseCastleID))
		{
			this.UseObj.SetActive(true);
			this.BuyObj.SetActive(false);
			if (this.CurUseCastleID == this.buildsData.CastleID)
			{
				this.UseText.text = this.DM.mStringTable.GetStringByID(7444u);
				this.UseBtn.interactable = false;
				this.UseBtnImg.color = Color.gray;
				this.UseText.color = new Color(0.898f, 0f, 0.31f);
			}
			else
			{
				this.UseText.text = this.DM.mStringTable.GetStringByID(924u);
				this.UseBtn.interactable = true;
				this.UseBtnImg.color = Color.white;
				this.UseText.color = Color.white;
			}
		}
		else
		{
			this.UseObj.SetActive(false);
			this.BuyObj.SetActive(true);
			this.SetPrice((uint)this.ItemID);
		}
	}

	// Token: 0x06001A15 RID: 6677 RVA: 0x002C3984 File Offset: 0x002C1B84
	private void UpdateEnhanceBtnState()
	{
		byte castleEnhance = this.buildsData.castleSkin.GetCastleEnhance(this.CurUseCastleID);
		if (this.CastleLv >= 25 && this.buildsData.castleSkin.CheckUnlock(this.CurUseCastleID))
		{
			this.EnhanceObj.SetActive(true);
		}
		else
		{
			this.EnhanceObj.SetActive(false);
		}
		float num;
		if (this.EnhanceObj.activeSelf)
		{
			this.InfoHint.Parm1 = 1;
			num = (float)this.UnlockPercentage * 0.01f;
		}
		else
		{
			this.InfoHint.Parm1 = 0;
			num = (float)this.PreViewPercentage * 0.01f;
		}
		this.CastleImg.transform.localScale = new Vector3(num, num, num);
	}

	// Token: 0x06001A16 RID: 6678 RVA: 0x002C3A50 File Offset: 0x002C1C50
	public void SetPrice(uint TreasureID)
	{
		TreasureID = MallManager.Instance.TreasureIDTransToNew(TreasureID);
		this.PriceStr.Length = 0;
		string productPaltformPriceByID = MallManager.Instance.GetProductPaltformPriceByID((int)TreasureID);
		string productPriceByID = MallManager.Instance.GetProductPriceByID((int)TreasureID);
		if (productPaltformPriceByID != null && productPaltformPriceByID != string.Empty)
		{
			this.PriceStr.Append(productPaltformPriceByID);
		}
		else
		{
			if (productPriceByID == null)
			{
				double f = 0.0;
				this.NeedUpDate = true;
				this.PriceStr.DoubleToFormat(f, 2, true);
			}
			else
			{
				this.PriceStr.StringToFormat(productPriceByID);
			}
			string currency = MallManager.Instance.GetCurrency((int)TreasureID);
			if (currency != null)
			{
				this.PriceStr.StringToFormat(currency);
				if (MallManager.Instance.bChangePosCurrency(currency))
				{
					this.PriceStr.AppendFormat("{0} {1}");
				}
				else
				{
					this.PriceStr.AppendFormat("{1} {0}");
				}
			}
			else
			{
				this.PriceStr.AppendFormat("${0}");
			}
		}
		this.PriceText.text = this.PriceStr.ToString();
		this.PriceText.SetAllDirty();
		this.PriceText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001A17 RID: 6679 RVA: 0x002C3B88 File Offset: 0x002C1D88
	public override void OnButtonClick(UIButton sender)
	{
		base.OnButtonClick(sender);
		UICastleSkin.ClickType btnID = (UICastleSkin.ClickType)sender.m_BtnID1;
		if (btnID == UICastleSkin.ClickType.Enhance)
		{
			if (!this.DM.CheckPrizeFlag(21))
			{
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
				messagePacket.AddSeqId();
				messagePacket.Add(21);
				messagePacket.Send(false);
				DataManager dm = this.DM;
				dm.RoleAttr.PrizeFlag = (dm.RoleAttr.PrizeFlag | 2097152u);
				this.buildsData.UpdateBuildState(5, 255);
			}
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door)
			{
				door.OpenMenu(EGUIWindow.UI_CastleStrengthen, 0, 0, true);
			}
		}
		else if (btnID == UICastleSkin.ClickType.Use)
		{
			GUIManager.Instance.ShowUILock(EUILock.CastleSkin);
			MessagePacket messagePacket2 = new MessagePacket(1024);
			messagePacket2.Protocol = Protocol._MSG_REQUEST_CASTLE_SKIN_CHANGE;
			messagePacket2.AddSeqId();
			messagePacket2.Add(this.CurUseCastleID - 1);
			messagePacket2.Send(false);
		}
		else if (btnID == UICastleSkin.ClickType.Buy)
		{
			if (this.ItemID == 0 || MallManager.Instance.CheckbWaitBuy_Castle(true))
			{
				return;
			}
			MallManager.Instance.SendCheckCastleID = (ushort)this.CurUseCastleID;
			MallManager.Instance.Send_SPTREASURE_PREBUY_CHECK(ESpcialTreasureType.ESTST_CastleSkin, (uint)this.ItemID, true);
		}
		else if (btnID == UICastleSkin.ClickType.Next)
		{
			base.GoToScroll(this.NextBtn.m_BtnID2, (ushort)this.CurUseCastleID);
			this.UpdateViewData(false);
			this.UpdateNextBtnState();
		}
	}

	// Token: 0x06001A18 RID: 6680 RVA: 0x002C3D08 File Offset: 0x002C1F08
	public override void OnInfoClick(UIButton sender)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		GUIManager.Instance.OpenMessageBoxEX(mStringTable.GetStringByID(9691u), mStringTable.GetStringByID(9683u), null, null, 0, 0, true, true);
	}

	// Token: 0x06001A19 RID: 6681 RVA: 0x002C3D48 File Offset: 0x002C1F48
	public override void UpdateUI(int arg1, int arg2)
	{
		base.UpdateUI(arg1, arg2);
		if (arg1 == 1)
		{
			if (this.AllCastleID == null)
			{
				this.SelectedCastleID = this.buildsData.castleSkin.ActiveCastleID;
			}
			else
			{
				for (int i = 0; i < this.AllCastleID.Length; i++)
				{
					if (this.AllCastleID[i] == this.buildsData.castleSkin.ActiveCastleID)
					{
						base.GoToScroll(i, 0);
						break;
					}
				}
			}
			this.UpdateViewData(false);
			this.ScrollToPosition = 1;
		}
		else if (arg1 == 2 || arg1 == 3)
		{
			if ((int)this.CurUseCastleID == arg2)
			{
				this.UpdateViewData(true);
				if (arg1 == 2)
				{
					this.SetEffect(1);
				}
				else
				{
					this.SetEffect(2);
				}
			}
		}
		else
		{
			this.UpdateViewData(true);
		}
	}

	// Token: 0x06001A1A RID: 6682 RVA: 0x002C3E28 File Offset: 0x002C2028
	private void SetEffect(byte id)
	{
		if (this.ShowEffect > 0)
		{
			this.ResetEffect();
		}
		this.ShowEffect = id;
		this.DestScale = this.CastleRect.localScale.x;
		this.OriCastlePos = this.CastleRect.anchoredPosition;
		this.CastleRect.localScale = Vector3.zero;
		this.CastleRect.pivot = new Vector2(0.5f, 0.5f);
		this.CastleRect.anchoredPosition = new Vector2(this.CastleRect.anchoredPosition.x, this.CastleRect.anchoredPosition.y + this.CastleRect.sizeDelta.y * this.DestScale * 0.5f);
		this.ShowTime = 0f;
		if (this.ShowEffect == 1)
		{
			this.ShowTotalTime = 0.4f;
		}
		else
		{
			this.RetrieveEffect();
			this.EffectObj = ParticleManager.Instance.Spawn(429, this.CastleRect, new Vector3(0f, 0f, -850f), 1f, true, true, true);
			GUIManager.Instance.SetLayer(this.EffectObj, 5);
			this.ShowTotalTime = 0.2f;
		}
	}

	// Token: 0x06001A1B RID: 6683 RVA: 0x002C3F7C File Offset: 0x002C217C
	private void ResetEffect()
	{
		if (this.ShowEffect == 0)
		{
			return;
		}
		this.CastleRect.localScale = new Vector3(this.DestScale, this.DestScale, this.DestScale);
		this.CastleRect.anchoredPosition = this.OriCastlePos;
		this.CastleRect.pivot = new Vector2(0.5f, 0f);
		if (this.ShowEffect == 1)
		{
			this.RetrieveEffect();
			this.EffectObj = ParticleManager.Instance.Spawn(428, this.CastleRect, new Vector3(0f, this.CastleRect.sizeDelta.y * this.DestScale * 0.5f, -850f), 1f, true, true, true);
			GUIManager.Instance.SetLayer(this.EffectObj, 5);
		}
		else if (this.EffectObj != null && this.EffectObj.activeSelf)
		{
			this.EffectObj.transform.localPosition = new Vector3(0f, this.CastleRect.sizeDelta.y * this.DestScale * 0.5f, -850f);
		}
		this.ShowEffect = 0;
	}

	// Token: 0x06001A1C RID: 6684 RVA: 0x002C40C4 File Offset: 0x002C22C4
	private void RetrieveEffect()
	{
		if (this.EffectObj != null && this.EffectObj.activeSelf)
		{
			this.EffectObj.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			this.EffectObj.transform.localPosition = new Vector3(0f, 0f, -50f);
		}
	}

	// Token: 0x06001A1D RID: 6685 RVA: 0x002C4138 File Offset: 0x002C2338
	private void UpdateEffect()
	{
		if (this.ShowEffect == 1)
		{
			this.ShowTime += Time.deltaTime;
			float num = this.ShowTime / this.ShowTotalTime;
			if (num < 1f)
			{
				num *= this.DestScale;
				this.CastleRect.localScale = new Vector3(num, num, num);
			}
			else
			{
				this.ResetEffect();
			}
		}
		else if (this.ShowEffect == 2)
		{
			float num2 = 0.2f * this.DestScale;
			this.ShowTime += Time.deltaTime;
			float num3 = this.ShowTime / this.ShowTotalTime;
			float num4 = 0.65f;
			if (num3 <= num4)
			{
				num3 = this.DestScale + num2 * num3;
				this.CastleRect.localScale = new Vector3(num3, num3, num3);
			}
			else if (num3 < 1f)
			{
				num3 = this.DestScale + num2 * num4 - this.DestScale * num2 * (num3 - num4);
				this.CastleRect.localScale = new Vector3(num3, num3, num3);
			}
			else
			{
				this.ResetEffect();
			}
		}
	}

	// Token: 0x06001A1E RID: 6686 RVA: 0x002C4254 File Offset: 0x002C2454
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Name.enabled = false;
			this.BuyText.enabled = false;
			this.UseText.enabled = false;
			this.PriceText.enabled = false;
			this.Name.enabled = true;
			this.BuyText.enabled = true;
			this.UseText.enabled = true;
			this.PriceText.enabled = true;
		}
		else if (networkNews == NetworkNews.Refresh_BuildBase)
		{
			this.UpdateEnhanceBtnState();
		}
	}

	// Token: 0x06001A1F RID: 6687 RVA: 0x002C42E8 File Offset: 0x002C24E8
	public override void ClassticalCastleChanged()
	{
		this.CastleImg.sprite = this.buildsData.castleSkin.GetUISprite(0, this.CastleLv);
		this.CastleImg.material = this.buildsData.castleSkin.GetUIMaterial(0, this.CastleLv);
	}

	// Token: 0x06001A20 RID: 6688 RVA: 0x002C433C File Offset: 0x002C253C
	public override void UpdateTime(bool bOnSecond)
	{
		base.UpdateTime(bOnSecond);
		if (this.NeedUpDate && bOnSecond && IGGGameSDK.Instance.bPaymentReady)
		{
			this.NeedUpDate = false;
			this.SetPrice((uint)this.ItemID);
		}
		if (this.DelayUpdateText > 0)
		{
			this.DelayUpdateText -= 1;
			if (this.DelayUpdateText == 0)
			{
				UICharInfo[] charactersArray = this.Name.cachedTextGenerator.GetCharactersArray();
				IList<UILineInfo> lines = this.Name.cachedTextGenerator.lines;
				if (charactersArray.Length > 0)
				{
					float num = float.MaxValue;
					for (int i = 0; i < lines.Count; i++)
					{
						if (num > charactersArray[lines[i].startCharIdx].cursorPos.x)
						{
							num = charactersArray[lines[i].startCharIdx].cursorPos.x;
						}
					}
					if (GUIManager.Instance.IsArabic)
					{
						this.InfoRect.anchoredPosition = new Vector2(-(num / this.pixelsPerUnit - this.Name.rectTransform.sizeDelta.x * 0.5f - 25f), this.InfoRect.anchoredPosition.y);
					}
					else
					{
						this.InfoRect.anchoredPosition = new Vector2(num / this.pixelsPerUnit - this.Name.rectTransform.sizeDelta.x * 0.5f - 25f, this.InfoRect.anchoredPosition.y);
					}
					if (!this.InfoObj.activeSelf)
					{
						this.InfoObj.SetActive(true);
					}
				}
			}
		}
		if (this.updateNextBtn == 1 && this.updateBtnNextStateTime >= 0f)
		{
			this.updateBtnNextStateTime -= Time.deltaTime;
			if (this.updateBtnNextStateTime <= 0f)
			{
				this.UpdateNextBtnState();
				this.updateBtnNextStateTime = 0.5f;
			}
		}
		this.UpdateEffect();
		float alpha = (this.DeltaTime <= 1f) ? this.DeltaTime : (2f - this.DeltaTime);
		this.InfoAlpha.alpha = alpha;
	}

	// Token: 0x06001A21 RID: 6689 RVA: 0x002C4598 File Offset: 0x002C2798
	public override void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		base.ButtonOnClick(gameObject, dataIndex, panelId);
		this.NeedUpDate = false;
		this.UpdateViewData(false);
	}

	// Token: 0x06001A22 RID: 6690 RVA: 0x002C45B4 File Offset: 0x002C27B4
	public override void OnClose()
	{
		base.OnClose();
		this.RetrieveEffect();
		StringManager.Instance.DeSpawnString(this.PriceStr);
		if (this.ExclamationCount != this.buildsData.castleSkin.GetExclamationCount())
		{
			this.buildsData.castleSkin.SortDirty();
		}
	}

	// Token: 0x06001A23 RID: 6691 RVA: 0x002C460C File Offset: 0x002C280C
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.Parm1 == 0)
		{
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 2, 240f, 20, (int)this.CurUseCastleID, 0, Vector2.zero, UIButtonHint.ePosition.Original);
		}
		else
		{
			sender.GetTipPosition(this.Hint.ThisTransform, UIButtonHint.ePosition.Original, null);
			this.Hint.Show((ushort)this.CurUseCastleID);
		}
		AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
	}

	// Token: 0x06001A24 RID: 6692 RVA: 0x002C4688 File Offset: 0x002C2888
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
		this.Hint.Hide();
	}

	// Token: 0x04004D2A RID: 19754
	private BuildsData buildsData = GUIManager.Instance.BuildingData;

	// Token: 0x04004D2B RID: 19755
	private DataManager DM = DataManager.Instance;

	// Token: 0x04004D2C RID: 19756
	private RectTransform InfoRect;

	// Token: 0x04004D2D RID: 19757
	private RectTransform CastleRect;

	// Token: 0x04004D2E RID: 19758
	private byte Rank;

	// Token: 0x04004D2F RID: 19759
	private byte CurUseCastleID = byte.MaxValue;

	// Token: 0x04004D30 RID: 19760
	private UIText Name;

	// Token: 0x04004D31 RID: 19761
	private UIText BuyText;

	// Token: 0x04004D32 RID: 19762
	private UIText UseText;

	// Token: 0x04004D33 RID: 19763
	private Text PriceText;

	// Token: 0x04004D34 RID: 19764
	private GameObject UseObj;

	// Token: 0x04004D35 RID: 19765
	private GameObject BuyObj;

	// Token: 0x04004D36 RID: 19766
	private GameObject EnhanceObj;

	// Token: 0x04004D37 RID: 19767
	private GameObject EnhanceBtnObj;

	// Token: 0x04004D38 RID: 19768
	private GameObject EnhanceNoticeObj;

	// Token: 0x04004D39 RID: 19769
	private GameObject InfoObj;

	// Token: 0x04004D3A RID: 19770
	private GameObject NextObj;

	// Token: 0x04004D3B RID: 19771
	private Image CastleImg;

	// Token: 0x04004D3C RID: 19772
	private Image UseBtnImg;

	// Token: 0x04004D3D RID: 19773
	private Image InUseImg;

	// Token: 0x04004D3E RID: 19774
	private Image[] EnhanceImg = new Image[5];

	// Token: 0x04004D3F RID: 19775
	private CanvasGroup InfoAlpha;

	// Token: 0x04004D40 RID: 19776
	private UIButton UseBtn;

	// Token: 0x04004D41 RID: 19777
	private UIButton NextBtn;

	// Token: 0x04004D42 RID: 19778
	private byte DelayUpdateText;

	// Token: 0x04004D43 RID: 19779
	private byte UnlockPercentage;

	// Token: 0x04004D44 RID: 19780
	private byte PreViewPercentage;

	// Token: 0x04004D45 RID: 19781
	private byte updateNextBtn;

	// Token: 0x04004D46 RID: 19782
	private byte ExclamationCount;

	// Token: 0x04004D47 RID: 19783
	private float pixelsPerUnit;

	// Token: 0x04004D48 RID: 19784
	private float updateBtnNextStateTime;

	// Token: 0x04004D49 RID: 19785
	private UIButtonHint InfoHint;

	// Token: 0x04004D4A RID: 19786
	private CString PriceStr;

	// Token: 0x04004D4B RID: 19787
	private bool NeedUpDate;

	// Token: 0x04004D4C RID: 19788
	private ushort ItemID;

	// Token: 0x04004D4D RID: 19789
	private GameObject EffectObj;

	// Token: 0x04004D4E RID: 19790
	private byte ShowEffect;

	// Token: 0x04004D4F RID: 19791
	private float ShowTotalTime;

	// Token: 0x04004D50 RID: 19792
	private float ShowTime;

	// Token: 0x04004D51 RID: 19793
	private float DestScale;

	// Token: 0x04004D52 RID: 19794
	private Vector2 OriCastlePos;

	// Token: 0x0200051B RID: 1307
	private enum UIControl
	{
		// Token: 0x04004D54 RID: 19796
		Enhance,
		// Token: 0x04004D55 RID: 19797
		Name,
		// Token: 0x04004D56 RID: 19798
		CastleImg,
		// Token: 0x04004D57 RID: 19799
		InUse,
		// Token: 0x04004D58 RID: 19800
		Last,
		// Token: 0x04004D59 RID: 19801
		Use,
		// Token: 0x04004D5A RID: 19802
		Buy
	}

	// Token: 0x0200051C RID: 1308
	private enum ClickType
	{
		// Token: 0x04004D5C RID: 19804
		Enhance,
		// Token: 0x04004D5D RID: 19805
		Use,
		// Token: 0x04004D5E RID: 19806
		Buy,
		// Token: 0x04004D5F RID: 19807
		Next
	}
}
