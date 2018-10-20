using System;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x0200031C RID: 796
public class UIDonation : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler
{
	// Token: 0x06001037 RID: 4151 RVA: 0x001CE9A4 File Offset: 0x001CCBA4
	public override void OnOpen(int arg1, int arg2)
	{
		MallManager instance = MallManager.Instance;
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.AM = ActivityManager.Instance;
		StringManager instance2 = StringManager.Instance;
		this.m_transform = base.transform;
		this.tmpFont = this.GM.GetTTFFont();
		this.door = (this.GM.FindMenu(EGUIWindow.Door) as Door);
		Material material = this.door.LoadMaterial();
		if (this.DM.RoleAlliance.Id == 0u || this.AM.AllianceSummonAllianceID == 0u || this.DM.RoleAlliance.Id != this.AM.AllianceSummonAllianceID || this.AM.AllianceSummonData.EventState != EActivityState.EAS_Run)
		{
			this.bCloseMenu = true;
		}
		bool flag = true;
		for (int i = 0; i < 4; i++)
		{
			this.tmpDonateAmountData[i] = this.DM.DonateAmountTable.GetRecordByKey(this.AM.mAllianceDonationData[i].RequireIdx);
		}
		if (this.AM.bNeedSendUpData && !this.bCloseMenu)
		{
			this.AM.Send_ACTIVITY_AS_DONATE_BOARD();
			this.AM.bNeedSendUpData = false;
		}
		else
		{
			flag = false;
			for (int j = 0; j < 4; j++)
			{
				this.tmpDonationData[j] = this.AM.mAllianceDonationData[j];
				this.mDonation_TCount += this.tmpDonationData[j].DonateNumber;
				this.mDonationItemQty[j] = this.DM.GetCurItemQuantity(this.tmpDonationData[j].itemID, this.tmpDonationData[j].itemRank);
				this.mDonationMultiple[j] = this.tmpDonationData[j].Multiple;
			}
			if (this.AM.mSendAddCount > 0)
			{
				this.GM.ShowUILock(EUILock.UIDonation);
			}
		}
		this.tmpScore1 = this.AM.GetAllianceSummonScore_SDataByFactor(17, 1).Score1;
		this.tmpData = this.AM.AllianceSummonData;
		this.NowScoreStr = instance2.SpawnString(30);
		this.NextScoreStr = instance2.SpawnString(30);
		this.Cstr_Time = instance2.SpawnString(30);
		for (int k = 0; k < 4; k++)
		{
			this.Cstr_ItemNum[k] = instance2.SpawnString(30);
			this.Cstr_ItemName[k] = instance2.SpawnString(100);
			this.Cstr_MultipleHint[k] = instance2.SpawnString(200);
			this.Cstr_AddScore[k] = new CString[4];
			this.Cstr_AddScore[k][0] = instance2.SpawnString(30);
			this.Cstr_AddScore[k][1] = instance2.SpawnString(30);
			this.Cstr_AddScore[k][2] = instance2.SpawnString(30);
			this.Cstr_AddScore[k][3] = instance2.SpawnString(30);
		}
		Transform child = this.m_transform.GetChild(2);
		Image component = child.GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = material;
		if (this.GM.bOpenOnIPhoneX)
		{
			component.enabled = false;
		}
		child = this.m_transform.GetChild(2).GetChild(0);
		this.btn_EXIT = child.GetComponent<UIButton>();
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = material;
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		child = this.m_transform.GetChild(3);
		this.btn_I = child.GetComponent<UIButton>();
		this.btn_I.gameObject.AddComponent<ArabicItemTextureRot>();
		this.btn_I.m_Handler = this;
		this.btn_I.m_BtnID1 = 1;
		this.btn_I.m_EffectType = e_EffectType.e_Scale;
		this.btn_I.transition = Selectable.Transition.None;
		child = this.m_transform.GetChild(1);
		this.Main2T = child.GetChild(0);
		Transform child2 = child.GetChild(1).GetChild(3);
		this.text_Title = child2.GetComponent<UIText>();
		this.text_Title.font = this.tmpFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(14544u);
		child2 = child.GetChild(2);
		this.Img_Hint = child2.GetComponent<Image>();
		child2 = child.GetChild(2).GetChild(0);
		this.text_Hint = child2.GetComponent<UIText>();
		this.text_Hint.font = this.tmpFont;
		this.text_Hint.text = this.DM.mStringTable.GetStringByID(14545u);
		this.text_Hint.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_Hint.preferredHeight > this.text_Hint.rectTransform.sizeDelta.y)
		{
			this.Img_Hint.rectTransform.sizeDelta = new Vector2(this.Img_Hint.rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 10f);
		}
		for (int l = 0; l < 4; l++)
		{
			this.mShowEffectTime[l] = new float[4];
			this.text_AddScore[l] = new UIText[4];
			child2 = child.GetChild(3 + l);
			this.text_AddScore[l][0] = child2.GetComponent<UIText>();
			this.text_AddScore[l][0].font = this.tmpFont;
			child2 = child.GetChild(3 + l + 4);
			this.text_AddScore[l][1] = child2.GetComponent<UIText>();
			this.text_AddScore[l][1].font = this.tmpFont;
			child2 = child.GetChild(3 + l + 8);
			this.text_AddScore[l][2] = child2.GetComponent<UIText>();
			this.text_AddScore[l][2].font = this.tmpFont;
			child2 = child.GetChild(3 + l + 12);
			this.text_AddScore[l][3] = child2.GetComponent<UIText>();
			this.text_AddScore[l][3].font = this.tmpFont;
		}
		this.RBText[0] = this.Main2T.GetChild(3).GetComponent<UIText>();
		this.RBText[0].font = this.tmpFont;
		this.RBText[0].text = this.DM.mStringTable.GetStringByID(8116u);
		this.RBText[1] = this.Main2T.GetChild(4).GetComponent<UIText>();
		this.RBText[1].font = this.tmpFont;
		this.RBText[1].text = this.DM.mStringTable.GetStringByID(8117u);
		this.NowScoreText = this.Main2T.GetChild(5).GetComponent<UIText>();
		this.NowScoreText.font = this.tmpFont;
		this.NextScoreText = this.Main2T.GetChild(6).GetComponent<UIText>();
		this.NextScoreText.font = this.tmpFont;
		child2 = this.Main2T.GetChild(2);
		this.SliderNormal[0] = child2.GetChild(2).GetComponent<Image>();
		this.SliderNormal[1] = child2.GetChild(3).GetComponent<Image>();
		this.SliderNormal[2] = child2.GetChild(4).GetComponent<Image>();
		this.SliderFlash[0] = child2.GetChild(5).GetComponent<Image>();
		this.SliderFlash[1] = child2.GetChild(6).GetComponent<Image>();
		this.SliderFlash[2] = child2.GetChild(7).GetComponent<Image>();
		this.TopTriImage = child2.GetChild(11).GetComponent<Image>();
		this.StageScoreText[0] = child2.GetChild(12).GetComponent<UIText>();
		this.StageScoreText[0].font = this.tmpFont;
		this.StageScoreText[1] = child2.GetChild(13).GetComponent<UIText>();
		this.StageScoreText[1].font = this.tmpFont;
		this.StageScoreText[2] = child2.GetChild(14).GetComponent<UIText>();
		this.StageScoreText[2].font = this.tmpFont;
		this.StepScore[0] = (ulong)this.tmpData.RequireScore[0];
		this.StepScore[1] = (ulong)this.tmpData.RequireScore[1];
		this.StepScore[2] = (ulong)this.tmpData.RequireScore[2];
		for (int m = 0; m < 3; m++)
		{
			this.StageScore[m] = instance2.SpawnString(30);
			this.StageScore[m].uLongToFormat(this.StepScore[m], 1, true);
			this.StageScore[m].AppendFormat("{0}");
			this.StageScoreText[m].text = this.StageScore[m].ToString();
			if (this.tmpData.EventBonusType == EActEventBonusType.EAEBT_RequireScoreDown)
			{
				this.StageScoreText[m].color = this.GreenColor;
			}
		}
		this.AM.mAllianceDonation_Score = (uint)this.AM.AllianceSummonData.EventScore;
		this.mDonation_Score = (ulong)this.AM.mAllianceDonation_Score;
		this.SetStepScore(this.mDonation_Score);
		child = this.m_transform.GetChild(0);
		UIButtonHint uibuttonHint;
		for (int n = 0; n < 4; n++)
		{
			child2 = child.GetChild(n);
			this.PGO[n] = child2.gameObject;
			this.Img_MultipleBG[n] = child2.GetChild(1).GetComponent<Image>();
			this.btn_Item[n] = child2.GetChild(2).GetComponent<UIHIBtn>();
			this.GM.InitianHeroItemImg(this.btn_Item[n].transform, eHeroOrItem.Item, this.tmpDonationData[n].itemID, 0, this.tmpDonationData[n].itemRank, 0, true, true, true, false);
			this.mLbtn_ItemT[n] = child2.GetChild(3);
			this.mLbtn_ItemT[n].gameObject.AddComponent<UIButtonHint>();
			uibuttonHint = this.mLbtn_ItemT[n].gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = (ushort)n;
			this.Lbtn_Item[n] = child2.GetChild(3).GetChild(0).GetComponent<UILEBtn>();
			this.Lbtn_Item[n].gameObject.AddComponent<IgnoreRaycast>();
			this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpDonationData[n].itemID);
			this.bLEItem = this.GM.IsLeadItem(this.tmpEquip.EquipKind);
			this.GM.InitLordEquipImg(this.Lbtn_Item[n].transform, this.tmpDonationData[n].itemID, this.tmpDonationData[n].itemRank, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
			if (this.bLEItem)
			{
				this.mLbtn_ItemT[n].gameObject.SetActive(true);
				this.btn_Item[n].gameObject.SetActive(false);
			}
			else
			{
				this.btn_Item[n].gameObject.SetActive(true);
				this.btn_Item[n].transform.GetComponent<UIButtonHint>().m_Handler = this;
				this.btn_Item[n].transform.GetComponent<UIButtonHint>().m_eHint = EUIButtonHint.DownUpHandler;
				this.btn_Item[n].transform.GetComponent<UIButtonHint>().Parm1 = (ushort)n;
				this.mLbtn_ItemT[n].gameObject.SetActive(false);
			}
			this.btn_Exchange[n] = child2.GetChild(4).GetComponent<UIButton>();
			this.btn_Exchange[n].m_Handler = this;
			this.btn_Exchange[n].m_BtnID1 = 3;
			this.btn_Exchange[n].m_BtnID2 = n;
			this.btn_Exchange[n].SetButtonEffectType(e_EffectType.e_Scale);
			this.btn_Exchange[n].transition = Selectable.Transition.None;
			this.btn_Exchange_Scale[n] = this.btn_Exchange[n].gameObject.GetComponent<uButtonScale>();
			this.text_ItemExchange[n] = child2.GetChild(4).GetChild(0).GetComponent<UIText>();
			this.text_ItemExchange[n].font = this.tmpFont;
			this.text_ItemExchange[n].text = this.DM.mStringTable.GetStringByID(14546u);
			this.btn_Exchange[n].m_Text = this.text_ItemExchange[n];
			this.Img_Multiple[n] = new Image[3];
			this.Img_Multiple[n][0] = child2.GetChild(5).GetComponent<Image>();
			this.Img_Multiple[n][1] = child2.GetChild(5).GetChild(0).GetComponent<Image>();
			this.Img_Multiple[n][1].material = material;
			if (this.GM.IsArabic)
			{
				this.Img_Multiple[n][1].gameObject.AddComponent<ArabicItemTextureRot>();
			}
			this.Img_Multiple[n][2] = child2.GetChild(5).GetChild(1).GetComponent<Image>();
			this.Img_Multiple[n][2].material = material;
			if (this.GM.IsArabic)
			{
				this.Img_Multiple[n][2].gameObject.AddComponent<ArabicItemTextureRot>();
			}
			if (this.GM.IsArabic)
			{
				if (this.door != null)
				{
					this.door.SetPointTexture(this.mDonationMultiple[n], this.Img_Multiple[n][2]);
				}
				this.Img_Multiple[n][1].sprite = this.door.LoadSprite("UI_mall_x_001");
			}
			else
			{
				if (this.door != null)
				{
					this.door.SetPointTexture(this.mDonationMultiple[n], this.Img_Multiple[n][1]);
				}
				this.Img_Multiple[n][2].sprite = this.door.LoadSprite("UI_mall_x_001");
			}
			this.Img_MultipleHint[n] = child2.GetChild(9).GetComponent<Image>();
			this.text_MultipleHint[n] = child2.GetChild(9).GetChild(0).GetComponent<UIText>();
			this.text_MultipleHint[n].font = this.tmpFont;
			this.btn_MultipleHint[n] = child2.GetChild(6).GetComponent<UIButton>();
			this.btn_MultipleHint[n].m_Handler = this;
			this.btn_MultipleHint[n].m_BtnID1 = 4;
			this.btn_MultipleHint[n].m_BtnID2 = n;
			uibuttonHint = this.btn_MultipleHint[n].gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.ControlFadeOut = this.Img_MultipleHint[n].gameObject;
			this.text_ItemNum[n] = child2.GetChild(7).GetComponent<UIText>();
			this.text_ItemNum[n].font = this.tmpFont;
			this.Cstr_ItemNum[n].ClearString();
			int num = (int)this.tmpDonationData[n].DonateNumber + this.mDonationData[n];
			if (num >= this.tmpDonateAmountData[n].DonateAmount.Length)
			{
				num = this.tmpDonateAmountData[n].DonateAmount.Length - 1;
			}
			if (this.mDonationItemQty[n] < this.tmpDonateAmountData[n].DonateAmount[num])
			{
				this.btn_Exchange[n].ForTextChange(e_BtnType.e_ChangeText);
			}
			else
			{
				this.btn_Exchange[n].ForTextChange(e_BtnType.e_Normal);
			}
			this.Cstr_ItemNum[n].IntToFormat((long)this.tmpDonateAmountData[n].DonateAmount[num], 1, true);
			if (this.GM.IsArabic)
			{
				this.Cstr_ItemNum[n].AppendFormat("{0}x");
			}
			else
			{
				this.Cstr_ItemNum[n].AppendFormat("x{0}");
			}
			this.text_ItemNum[n].text = this.Cstr_ItemNum[n].ToString();
			this.text_ItemNum[n].SetAllDirty();
			this.text_ItemNum[n].cachedTextGenerator.Invalidate();
			this.text_ItemNum[n].cachedTextGeneratorForLayout.Invalidate();
			this.text_ItemNum[n].rectTransform.anchoredPosition = new Vector2(106f + this.text_ItemNum[n].preferredWidth / 2f, this.text_ItemNum[n].rectTransform.anchoredPosition.y);
			this.text_ItemName[n] = child2.GetChild(8).GetComponent<UIText>();
			this.text_ItemName[n].font = this.tmpFont;
			this.Cstr_ItemName[n].ClearString();
			this.Cstr_ItemName[n].IntToFormat((long)((ulong)this.tmpScore1), 1, true);
			this.Cstr_ItemName[n].AppendFormat(this.DM.mStringTable.GetStringByID(8121u));
			this.text_ItemName[n].text = this.Cstr_ItemName[n].ToString();
			this.text_ItemName[n].SetAllDirty();
			this.text_ItemName[n].cachedTextGenerator.Invalidate();
			if (!flag)
			{
				this.ChangeMultiple((byte)n, false);
				this.PGO[n].gameObject.SetActive(true);
			}
		}
		child2 = child.GetChild(4).GetChild(0);
		this.btn_CDTime = child2.GetComponent<UIButton>();
		this.btn_CDTime.m_Handler = this;
		this.btn_CDTime.m_BtnID1 = 2;
		uibuttonHint = this.btn_CDTime.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = this.Img_Hint.gameObject;
		child2 = child.GetChild(4).GetChild(2);
		this.text_Time = child2.GetComponent<UIText>();
		this.text_Time.font = this.tmpFont;
		this.Cstr_Time.ClearString();
		long num2 = this.AM.mAllianceDonation_EndTime - this.DM.ServerTime;
		if (num2 < 0L)
		{
			num2 = 0L;
		}
		this.Cstr_Time.IntToFormat(num2 / 3600L, 1, false);
		num2 %= 3600L;
		this.Cstr_Time.IntToFormat(num2 / 60L, 2, false);
		num2 %= 60L;
		this.Cstr_Time.IntToFormat(num2, 2, false);
		this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
		this.text_Time.text = this.Cstr_Time.ToString();
		this.text_Time.SetAllDirty();
		this.text_Time.cachedTextGenerator.Invalidate();
		this.GM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001038 RID: 4152 RVA: 0x001CFCE8 File Offset: 0x001CDEE8
	public void CheckItemQty()
	{
		for (int i = 0; i < 4; i++)
		{
			int num = (int)this.tmpDonationData[i].DonateNumber + this.mDonationData[i];
			if (num >= this.tmpDonateAmountData[i].DonateAmount.Length)
			{
				num = this.tmpDonateAmountData[i].DonateAmount.Length - 1;
			}
			if (this.mDonationItemQty[i] < this.tmpDonateAmountData[i].DonateAmount[num])
			{
				this.btn_Exchange[i].ForTextChange(e_BtnType.e_ChangeText);
			}
			else
			{
				this.btn_Exchange[i].ForTextChange(e_BtnType.e_Normal);
			}
		}
	}

	// Token: 0x06001039 RID: 4153 RVA: 0x001CFD94 File Offset: 0x001CDF94
	public void SetDonate(byte mIdx)
	{
		if (mIdx < 0 || (int)mIdx >= this.mValueScale.Length)
		{
			return;
		}
		this.ChangeMultiple(mIdx, true);
		byte[] array = this.mDonationDataCount;
		array[(int)mIdx] = array[(int)mIdx] + 1;
		int num;
		if (!this.bShowChangValue[(int)mIdx] && this.mValueScale[(int)mIdx] > 0f)
		{
			this.mDonationData[(int)mIdx]++;
			this.Cstr_ItemNum[(int)mIdx].ClearString();
			num = (int)this.tmpDonationData[(int)mIdx].DonateNumber + this.mDonationData[(int)mIdx];
			if (num >= this.tmpDonateAmountData[(int)mIdx].DonateAmount.Length)
			{
				num = this.tmpDonateAmountData[(int)mIdx].DonateAmount.Length - 1;
			}
			this.Cstr_ItemNum[(int)mIdx].IntToFormat((long)this.tmpDonateAmountData[(int)mIdx].DonateAmount[num], 1, true);
			if (this.GM.IsArabic)
			{
				this.Cstr_ItemNum[(int)mIdx].AppendFormat("{0}x");
				this.text_ItemNum[(int)mIdx].rectTransform.localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				this.Cstr_ItemNum[(int)mIdx].AppendFormat("x{0}");
				this.text_ItemNum[(int)mIdx].rectTransform.localScale = new Vector3(1f, 1f, 1f);
			}
			this.text_ItemNum[(int)mIdx].text = this.Cstr_ItemNum[(int)mIdx].ToString();
			this.text_ItemNum[(int)mIdx].SetAllDirty();
			this.text_ItemNum[(int)mIdx].cachedTextGenerator.Invalidate();
			this.text_ItemNum[(int)mIdx].cachedTextGeneratorForLayout.Invalidate();
			this.text_ItemNum[(int)mIdx].rectTransform.anchoredPosition = new Vector2(106f + this.text_ItemNum[(int)mIdx].preferredWidth / 2f, this.text_ItemNum[(int)mIdx].rectTransform.anchoredPosition.y);
		}
		num = (int)this.tmpDonationData[(int)mIdx].DonateNumber + this.mDonationData[(int)mIdx];
		if (num >= this.tmpDonateAmountData[(int)mIdx].DonateAmount.Length)
		{
			num = this.tmpDonateAmountData[(int)mIdx].DonateAmount.Length - 1;
		}
		if (this.mDonationItemQty[(int)mIdx] >= this.tmpDonateAmountData[(int)mIdx].DonateAmount[num])
		{
			ushort[] array2 = this.mDonationItemQty;
			array2[(int)mIdx] = array2[(int)mIdx] - this.tmpDonateAmountData[(int)mIdx].DonateAmount[num];
		}
		else
		{
			this.mDonationItemQty[(int)mIdx] = 0;
		}
		if (this.mDonationItemQty[(int)mIdx] < this.tmpDonateAmountData[(int)mIdx].DonateAmount[num])
		{
			this.btn_Exchange[(int)mIdx].ForTextChange(e_BtnType.e_ChangeText);
		}
		else
		{
			this.btn_Exchange[(int)mIdx].ForTextChange(e_BtnType.e_Normal);
		}
		this.bShowChangValue[(int)mIdx] = false;
		this.mValueScale[(int)mIdx] = 0.2f;
		if (this.mSendCDTime == 0f)
		{
			this.mSendCDTime = 2f;
		}
		this.mDonation_Index[(int)((UIntPtr)this.mCountValue)] = mIdx + 1;
		this.mCountValue += 1u;
	}

	// Token: 0x0600103A RID: 4154 RVA: 0x001D00C8 File Offset: 0x001CE2C8
	public void ChangeMultiple(byte mIdx, bool bShow = false)
	{
		this.Cstr_ItemName[(int)mIdx].ClearString();
		if (this.mDonationMultiple[(int)mIdx] > 1)
		{
			this.Img_Multiple[(int)mIdx][0].color = new Color(1f, 1f, 1f, 1f);
			this.Img_Multiple[(int)mIdx][1].color = new Color(1f, 1f, 1f, 1f);
			this.Img_Multiple[(int)mIdx][2].color = new Color(1f, 1f, 1f, 1f);
			if (this.GM.IsArabic)
			{
				this.text_ItemName[(int)mIdx].rectTransform.localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				this.text_ItemName[(int)mIdx].rectTransform.localScale = new Vector3(1f, 1f, 1f);
			}
			if (bShow)
			{
				this.mMultipleScale[(int)mIdx] = 0.2f;
				this.mShowStatus[(int)mIdx] = 4;
			}
			this.Img_MultipleHint[(int)mIdx].gameObject.SetActive(false);
			this.Img_MultipleBG[(int)mIdx].gameObject.SetActive(true);
			this.btn_MultipleHint[(int)mIdx].gameObject.SetActive(true);
			this.Cstr_MultipleHint[(int)mIdx].ClearString();
			if (this.GM.IsArabic)
			{
				if (this.door != null)
				{
					this.door.SetPointTexture(this.mDonationMultiple[(int)mIdx], this.Img_Multiple[(int)mIdx][2]);
				}
				this.Img_Multiple[(int)mIdx][1].sprite = this.door.LoadSprite("UI_mall_x_001");
			}
			else
			{
				if (this.door != null)
				{
					this.door.SetPointTexture(this.mDonationMultiple[(int)mIdx], this.Img_Multiple[(int)mIdx][1]);
				}
				this.Img_Multiple[(int)mIdx][2].sprite = this.door.LoadSprite("UI_mall_x_001");
			}
			this.Cstr_MultipleHint[(int)mIdx].IntToFormat((long)this.mDonationMultiple[(int)mIdx], 1, true);
			this.Cstr_MultipleHint[(int)mIdx].AppendFormat(this.DM.mStringTable.GetStringByID(14547u));
			this.text_MultipleHint[(int)mIdx].text = this.Cstr_MultipleHint[(int)mIdx].ToString();
			this.text_MultipleHint[(int)mIdx].SetAllDirty();
			this.text_MultipleHint[(int)mIdx].cachedTextGenerator.Invalidate();
			this.text_MultipleHint[(int)mIdx].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_MultipleHint[(int)mIdx].preferredHeight > 170f)
			{
				this.Img_MultipleHint[(int)mIdx].rectTransform.sizeDelta = new Vector2(this.Img_MultipleHint[(int)mIdx].rectTransform.sizeDelta.x, 180f);
			}
			else
			{
				this.Img_MultipleHint[(int)mIdx].rectTransform.sizeDelta = new Vector2(this.Img_MultipleHint[(int)mIdx].rectTransform.sizeDelta.x, this.text_MultipleHint[(int)mIdx].preferredHeight + 10f);
			}
			this.Img_Multiple[(int)mIdx][0].gameObject.SetActive(true);
			this.text_ItemName[(int)mIdx].color = this.mColor_G;
		}
		else
		{
			if (this.GM.IsArabic)
			{
				this.text_ItemName[(int)mIdx].rectTransform.localScale = new Vector3(-0.85f, 0.85f, 0.85f);
			}
			else
			{
				this.text_ItemName[(int)mIdx].rectTransform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
			}
			this.text_ItemName[(int)mIdx].color = Color.white;
			this.Img_MultipleBG[(int)mIdx].gameObject.SetActive(false);
			this.btn_MultipleHint[(int)mIdx].gameObject.SetActive(false);
		}
		this.Cstr_ItemName[(int)mIdx].IntToFormat((long)((ulong)(this.tmpScore1 * (uint)this.mDonationMultiple[(int)mIdx])), 1, true);
		this.Cstr_ItemName[(int)mIdx].AppendFormat(this.DM.mStringTable.GetStringByID(8121u));
		this.text_ItemName[(int)mIdx].text = this.Cstr_ItemName[(int)mIdx].ToString();
		this.text_ItemName[(int)mIdx].SetAllDirty();
		this.text_ItemName[(int)mIdx].cachedTextGenerator.Invalidate();
	}

	// Token: 0x0600103B RID: 4155 RVA: 0x001D0538 File Offset: 0x001CE738
	public void CheckDonate(int result)
	{
		if (result == 0)
		{
			this.mDonation_Score = (ulong)this.AM.mAllianceDonation_Score;
			this.SetStepScore(this.mDonation_Score + this.mAddScore);
			if (this.mCountValue == 0u)
			{
				for (int i = 0; i < 4; i++)
				{
					this.tmpDonationData[i] = this.AM.mAllianceDonationData[i];
					this.mDonationItemQty[i] = this.DM.GetCurItemQuantity(this.tmpDonationData[i].itemID, this.tmpDonationData[i].itemRank);
					this.mDonationMultiple[i] = this.tmpDonationData[i].Multiple;
					this.ChangeMultiple((byte)i, false);
					this.mMultipleScale[i] = 0f;
					this.mShowStatus[i] = 0;
					if (this.mDonationMultiple[i] == 1)
					{
						this.Img_Multiple[i][0].gameObject.SetActive(false);
						this.Img_MultipleHint[i].gameObject.SetActive(false);
					}
					this.Cstr_ItemNum[i].ClearString();
					int num = (int)this.tmpDonationData[i].DonateNumber;
					if (num >= this.tmpDonateAmountData[i].DonateAmount.Length)
					{
						num = this.tmpDonateAmountData[i].DonateAmount.Length - 1;
					}
					if (this.mDonationItemQty[i] < this.tmpDonateAmountData[i].DonateAmount[num])
					{
						this.btn_Exchange[i].ForTextChange(e_BtnType.e_ChangeText);
					}
					else
					{
						this.btn_Exchange[i].ForTextChange(e_BtnType.e_Normal);
					}
					this.Cstr_ItemNum[i].IntToFormat((long)this.tmpDonateAmountData[i].DonateAmount[num], 1, true);
					if (this.GM.IsArabic)
					{
						this.Cstr_ItemNum[i].AppendFormat("{0}x");
					}
					else
					{
						this.Cstr_ItemNum[i].AppendFormat("x{0}");
					}
					this.text_ItemNum[i].text = this.Cstr_ItemNum[i].ToString();
					this.text_ItemNum[i].SetAllDirty();
					this.text_ItemNum[i].cachedTextGenerator.Invalidate();
					this.text_ItemNum[i].cachedTextGeneratorForLayout.Invalidate();
					this.text_ItemNum[i].rectTransform.anchoredPosition = new Vector2(106f + this.text_ItemNum[i].preferredWidth / 2f, this.text_ItemNum[i].rectTransform.anchoredPosition.y);
					if (this.GM.IsArabic)
					{
						this.text_ItemNum[i].rectTransform.localScale = new Vector3(-1f, 1f, 1f);
					}
					else
					{
						this.text_ItemNum[i].rectTransform.localScale = new Vector3(1f, 1f, 1f);
					}
				}
				this.CheckItemQty();
			}
		}
		else if (result == 1)
		{
			this.mDonation_TCount = 0;
			for (int j = 0; j < 4; j++)
			{
				this.tmpDonationData[j] = this.AM.mAllianceDonationData[j];
				this.mDonation_TCount += this.tmpDonationData[j].DonateNumber;
				this.tmpDonateAmountData[j] = this.DM.DonateAmountTable.GetRecordByKey(this.AM.mAllianceDonationData[j].RequireIdx);
				this.mDonationItemQty[j] = this.DM.GetCurItemQuantity(this.tmpDonationData[j].itemID, this.tmpDonationData[j].itemRank);
				this.mDonationDataCount[j] = 0;
				this.mAddScore = 0UL;
				this.mDonation_Score = (ulong)this.AM.mAllianceDonation_Score;
				this.SetStepScore(this.mDonation_Score);
				this.mDonationMultiple[j] = this.tmpDonationData[j].Multiple;
				this.ChangeMultiple((byte)j, false);
				this.mMultipleScale[j] = 0f;
				this.mShowStatus[j] = 0;
				if (this.mDonationMultiple[j] == 1)
				{
					this.Img_Multiple[j][0].gameObject.SetActive(false);
				}
				this.mValueScale[j] = 0f;
				this.bShowChangValue[j] = true;
				this.Cstr_ItemNum[j].ClearString();
				int num = (int)this.tmpDonationData[j].DonateNumber;
				if (num >= this.tmpDonateAmountData[j].DonateAmount.Length)
				{
					num = this.tmpDonateAmountData[j].DonateAmount.Length - 1;
				}
				if (this.mDonationItemQty[j] < this.tmpDonateAmountData[j].DonateAmount[num])
				{
					this.btn_Exchange[j].ForTextChange(e_BtnType.e_ChangeText);
				}
				else
				{
					this.btn_Exchange[j].ForTextChange(e_BtnType.e_Normal);
				}
				this.Cstr_ItemNum[j].IntToFormat((long)this.tmpDonateAmountData[j].DonateAmount[num], 1, true);
				if (this.GM.IsArabic)
				{
					this.Cstr_ItemNum[j].AppendFormat("{0}x");
				}
				else
				{
					this.Cstr_ItemNum[j].AppendFormat("x{0}");
				}
				this.text_ItemNum[j].text = this.Cstr_ItemNum[j].ToString();
				this.text_ItemNum[j].SetAllDirty();
				this.text_ItemNum[j].cachedTextGenerator.Invalidate();
				this.text_ItemNum[j].cachedTextGeneratorForLayout.Invalidate();
				this.text_ItemNum[j].rectTransform.anchoredPosition = new Vector2(106f + this.text_ItemNum[j].preferredWidth / 2f, this.text_ItemNum[j].rectTransform.anchoredPosition.y);
				if (this.GM.IsArabic)
				{
					this.text_ItemNum[j].rectTransform.localScale = new Vector3(-1f, 1f, 1f);
				}
				else
				{
					this.text_ItemNum[j].rectTransform.localScale = new Vector3(1f, 1f, 1f);
				}
				this.Img_MultipleHint[j].gameObject.SetActive(false);
			}
			this.mCountValue = 0u;
			Array.Clear(this.mDonation_Index, 0, this.mDonation_Index.Length);
			this.mSendCDTime = 0f;
		}
	}

	// Token: 0x0600103C RID: 4156 RVA: 0x001D0BD4 File Offset: 0x001CEDD4
	private void SetStepScore(ulong Score)
	{
		this.nowScore = Score;
		this.NowScoreStr.Length = 0;
		this.NowScoreStr.uLongToFormat(Score, 1, true);
		this.NowScoreStr.AppendFormat("{0}");
		this.NowScoreText.text = this.NowScoreStr.ToString();
		this.NowScoreText.SetAllDirty();
		this.NowScoreText.cachedTextGenerator.Invalidate();
		ulong x = 0UL;
		this.nowStep = 0;
		for (int i = 0; i < 3; i++)
		{
			if (this.nowScore >= this.StepScore[i])
			{
				this.nowStep += 1;
			}
		}
		if (this.nowStep < 3)
		{
			x = this.StepScore[(int)this.nowStep] - Score;
			if (this.nowStep == 0)
			{
				this.SliderNormal[(int)this.nowStep].fillAmount = (float)(Score / this.StepScore[(int)this.nowStep]);
			}
			else
			{
				this.SliderNormal[(int)this.nowStep].fillAmount = (float)((Score - this.StepScore[(int)(this.nowStep - 1)]) / (this.StepScore[(int)this.nowStep] - this.StepScore[(int)(this.nowStep - 1)]));
			}
			RectTransform rectTransform = this.SliderNormal[(int)this.nowStep].rectTransform;
			this.TopTriImage.rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + rectTransform.sizeDelta.x * this.SliderNormal[(int)this.nowStep].fillAmount - 15f, this.TriLastPos.y);
		}
		else
		{
			this.TopTriImage.rectTransform.anchoredPosition = this.TriLastPos;
		}
		for (int j = 0; j < (int)this.nowStep; j++)
		{
			this.SliderNormal[j].fillAmount = 1f;
			this.SliderFlash[j].gameObject.SetActive(true);
			this.StageScoreText[j].color = this.StageScoreColorY;
		}
		this.NextScoreStr.Length = 0;
		this.NextScoreStr.uLongToFormat(x, 1, true);
		this.NextScoreStr.AppendFormat("{0}");
		this.NextScoreText.text = this.NextScoreStr.ToString();
		this.NextScoreText.SetAllDirty();
		this.NextScoreText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x0600103D RID: 4157 RVA: 0x001D0E4C File Offset: 0x001CF04C
	public override void OnClose()
	{
		if (!this.AM.bNeedSendUpData && this.AM.NeedSendUpDataTime < 0f)
		{
			this.AM.NeedSendUpDataTime = 180f;
		}
		if (this.mCountValue > 0u)
		{
			this.SendDonationValue();
		}
		if (this.NowScoreStr != null)
		{
			StringManager.Instance.DeSpawnString(this.NowScoreStr);
		}
		if (this.NextScoreStr != null)
		{
			StringManager.Instance.DeSpawnString(this.NextScoreStr);
		}
		if (this.Cstr_Time != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Time);
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.StageScore[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.StageScore[i]);
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (this.Cstr_ItemNum[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemNum[j]);
			}
			if (this.Cstr_ItemName[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemName[j]);
			}
			if (this.Cstr_MultipleHint[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_MultipleHint[j]);
			}
			if (this.Cstr_AddScore[j][0] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_AddScore[j][0]);
			}
			if (this.Cstr_AddScore[j][1] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_AddScore[j][1]);
			}
			if (this.Cstr_AddScore[j][2] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_AddScore[j][2]);
			}
			if (this.Cstr_AddScore[j][3] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_AddScore[j][3]);
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (this.btn_Item[k] != null && this.btn_Item[k].enabled)
			{
				this.btn_Item[k].Refresh_FontTexture();
			}
		}
		for (int l = 0; l < 4; l++)
		{
			if (this.Lbtn_Item[l] != null && this.Lbtn_Item[l].enabled)
			{
				LordEquipData.ResetLordEquipFont(this.Lbtn_Item[l]);
			}
		}
	}

	// Token: 0x0600103E RID: 4158 RVA: 0x001D10B0 File Offset: 0x001CF2B0
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
		{
			this.Cstr_Time.ClearString();
			long num = this.AM.mAllianceDonation_EndTime - this.DM.ServerTime;
			if (num < 0L)
			{
				num = 0L;
			}
			this.Cstr_Time.IntToFormat(num / 3600L, 1, false);
			num %= 3600L;
			this.Cstr_Time.IntToFormat(num / 60L, 2, false);
			num %= 60L;
			this.Cstr_Time.IntToFormat(num, 2, false);
			this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
			this.text_Time.text = this.Cstr_Time.ToString();
			this.text_Time.SetAllDirty();
			this.text_Time.cachedTextGenerator.Invalidate();
			bool flag = false;
			if (!this.DM.mLordEquip.LoadLordEquip(false) && !this.DM.mLordEquip.LoadLEMaterial(false))
			{
				this.CheckDonate(1);
				flag = true;
			}
			if (flag)
			{
				for (int i = 0; i < 4; i++)
				{
					this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpDonationData[i].itemID);
					this.bLEItem = this.GM.IsLeadItem(this.tmpEquip.EquipKind);
					if (this.bLEItem)
					{
						this.GM.ChangeLordEquipImg(this.Lbtn_Item[i].transform, this.tmpDonationData[i].itemID, this.tmpDonationData[i].itemRank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
						this.mLbtn_ItemT[i].gameObject.SetActive(true);
						this.btn_Item[i].gameObject.SetActive(false);
					}
					else
					{
						this.GM.ChangeHeroItemImg(this.btn_Item[i].transform, eHeroOrItem.Item, this.tmpDonationData[i].itemID, 0, this.tmpDonationData[i].itemRank, 0);
						this.btn_Item[i].gameObject.SetActive(true);
						this.mLbtn_ItemT[i].gameObject.SetActive(false);
					}
					this.PGO[i].gameObject.SetActive(true);
				}
			}
			break;
		}
		case 2:
			this.CheckDonate(arg2);
			break;
		case 3:
			if (this.mDonation_Score < (ulong)this.AM.mAllianceDonation_Score)
			{
				this.mDonation_Score = (ulong)this.AM.mAllianceDonation_Score;
			}
			this.SetStepScore(this.mDonation_Score + this.mAddScore);
			break;
		case 4:
			this.AM.Send_ACTIVITY_AS_DONATE_BOARD();
			this.AM.bNeedSendUpData = false;
			this.mCountValue = 0u;
			Array.Clear(this.mDonation_Index, 0, this.mDonation_Index.Length);
			break;
		case 5:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		}
	}

	// Token: 0x0600103F RID: 4159 RVA: 0x001D13C0 File Offset: 0x001CF5C0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Item)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
		}
		else if (this.DM.RoleAlliance.Id == 0u || this.AM.AllianceSummonAllianceID == 0u || this.DM.RoleAlliance.Id != this.AM.AllianceSummonAllianceID || this.AM.AllianceSummonData.EventState != EActivityState.EAS_Run)
		{
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
		}
		else
		{
			this.tmpData = this.AM.AllianceSummonData;
			this.StepScore[0] = (ulong)this.tmpData.RequireScore[0];
			this.StepScore[1] = (ulong)this.tmpData.RequireScore[1];
			this.StepScore[2] = (ulong)this.tmpData.RequireScore[2];
			for (int i = 0; i < 3; i++)
			{
				this.StageScore[i].ClearString();
				this.StageScore[i].uLongToFormat(this.StepScore[i], 1, true);
				this.StageScore[i].AppendFormat("{0}");
				this.StageScoreText[i].text = this.StageScore[i].ToString();
				if (this.tmpData.EventBonusType == EActEventBonusType.EAEBT_RequireScoreDown)
				{
					this.StageScoreText[i].color = this.GreenColor;
				}
			}
			this.AM.mAllianceDonation_Score = (uint)this.AM.AllianceSummonData.EventScore;
			this.mDonation_Score = (ulong)this.AM.mAllianceDonation_Score;
			this.SetStepScore(this.mDonation_Score);
			this.AM.Send_ACTIVITY_AS_DONATE_BOARD();
			this.AM.bNeedSendUpData = false;
			if (!this.DM.mLordEquip.LoadLordEquip(false))
			{
				this.bEqDataReq = true;
				if (!this.DM.mLordEquip.LoadLEMaterial(false))
				{
					this.bMaterialDataReq = true;
				}
				else if (this.bEqDataReq && this.bMaterialDataReq)
				{
					this.CheckDonate(1);
				}
			}
		}
	}

	// Token: 0x06001040 RID: 4160 RVA: 0x001D1608 File Offset: 0x001CF808
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
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UIDonation_Info, 0, 0, false);
			}
			break;
		case 3:
		{
			if (sender.m_BtnType == e_BtnType.e_ChangeText)
			{
				this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14549u), 255, true);
				return;
			}
			this.mExchange = (byte)sender.m_BtnID2;
			if (this.btn_Exchange_Scale[(int)this.mExchange] != null && this.btn_Exchange_Scale[(int)this.mExchange].enabled)
			{
				this.mBtnCD[(int)this.mExchange] = 0.2f;
				this.btn_Exchange_Scale[(int)this.mExchange].enabled = false;
			}
			this.mAddScore += (ulong)(this.tmpScore1 * (uint)this.mDonationMultiple[(int)this.mExchange]);
			this.SetStepScore(this.mDonation_Score + this.mAddScore);
			byte[] array = this.tmpAddScoreIdx;
			byte b = this.mExchange;
			array[(int)b] = array[(int)b] + 1;
			if (this.tmpAddScoreIdx[(int)this.mExchange] > 3)
			{
				this.tmpAddScoreIdx[(int)this.mExchange] = 0;
			}
			this.Cstr_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].ClearString();
			this.Cstr_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].IntToFormat((long)((ulong)(this.tmpScore1 * (uint)this.mDonationMultiple[(int)this.mExchange])), 1, true);
			if (this.GM.IsArabic)
			{
				this.Cstr_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].AppendFormat("{0}+");
			}
			else
			{
				this.Cstr_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].AppendFormat("+{0}");
			}
			this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].text = this.Cstr_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].ToString();
			this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].SetAllDirty();
			this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].cachedTextGenerator.Invalidate();
			if (this.mExchange < 2)
			{
				this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].rectTransform.anchoredPosition = new Vector2(this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].rectTransform.anchoredPosition.x, 20f);
			}
			else
			{
				this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].rectTransform.anchoredPosition = new Vector2(this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].rectTransform.anchoredPosition.x, -168f);
			}
			if (this.mDonationMultiple[(int)this.mExchange] > 1)
			{
				this.mMultipleScale[(int)this.mExchange] = 0.5f;
				this.mShowStatus[(int)this.mExchange] = 1;
				if (this.GM.IsArabic)
				{
					this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].rectTransform.localScale = new Vector3(-1f, 1f, 1f);
				}
				else
				{
					this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].rectTransform.localScale = new Vector3(1f, 1f, 1f);
				}
				this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].color = this.mColor_G;
				this.tmptestY = 1.2f;
				AudioManager.Instance.PlaySFX(3408, 0f, PitchKind.NoPitch, null, null);
			}
			else
			{
				if (this.GM.IsArabic)
				{
					this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].rectTransform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
				}
				else
				{
					this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].rectTransform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
				}
				this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].color = this.StageScoreColorY;
				this.tmptestY = 1f;
				AudioManager.Instance.PlayUISFX(UIKind.Gambling_Hit);
			}
			this.mShowEffectTime[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]] = 0f;
			this.text_AddScore[(int)this.mExchange][(int)this.tmpAddScoreIdx[(int)this.mExchange]].gameObject.SetActive(true);
			this.mDonationMultiple[(int)this.mExchange] = 1;
			ushort num = GameConstants.RandomValue(this.AM.mAllianceDonation_RandomSeed, this.AM.mAllianceDonation_Gap, this.mDonation_TCount);
			for (int i = 0; i < this.AM.mDonateChanceData.Count; i++)
			{
				if (num <= this.AM.mDonateChanceData[i])
				{
					this.mDonationMultiple[(int)this.mExchange] = (byte)(1 + i);
					break;
				}
			}
			this.mDonation_TCount += 1;
			this.SetDonate(this.mExchange);
			float num2 = this.GM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f;
			float num3 = this.GM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f;
			this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpDonationData[(int)this.mExchange].itemID);
			this.bLEItem = this.GM.IsLeadItem(this.tmpEquip.EquipKind);
			float num4 = 0f;
			if (this.GM.bOpenOnIPhoneX)
			{
				num4 = this.GM.IPhoneX_DeltaX;
			}
			num2 -= num4;
			switch (this.mExchange)
			{
			case 0:
			{
				Vector2 mV = new Vector2(num2 - 344f, num3 - 14f);
				this.GM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(num2 + 132f, -(num3 - 168f));
				if (this.bLEItem)
				{
					this.GM.SE_Item_L_Color[0] = this.tmpDonationData[(int)this.mExchange].itemRank;
					this.GM.m_SpeciallyEffect.AddIconShow(false, mV, SpeciallyEffect_Kind.Donation_Item_Material, 0, this.tmpDonationData[(int)this.mExchange].itemID, true, 2f);
				}
				else
				{
					this.GM.m_SpeciallyEffect.AddIconShow(false, mV, SpeciallyEffect_Kind.Donation_Item, 0, this.tmpDonationData[(int)this.mExchange].itemID, true, 2f);
				}
				break;
			}
			case 1:
			{
				Vector2 mV2 = new Vector2(num2 + 65f, num3 - 14f);
				this.GM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(num2 + 132f, -(num3 - 168f));
				if (this.bLEItem)
				{
					this.GM.SE_Item_L_Color[0] = this.tmpDonationData[(int)this.mExchange].itemRank;
					this.GM.m_SpeciallyEffect.AddIconShow(false, mV2, SpeciallyEffect_Kind.Donation_Item_Material, 0, this.tmpDonationData[(int)this.mExchange].itemID, true, 2f);
				}
				else
				{
					this.GM.m_SpeciallyEffect.AddIconShow(false, mV2, SpeciallyEffect_Kind.Donation_Item, 0, this.tmpDonationData[(int)this.mExchange].itemID, true, 2f);
				}
				break;
			}
			case 2:
			{
				Vector2 mV3 = new Vector2(num2 - 344f, num3 + 174f);
				this.GM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(num2 + 132f, -(num3 - 168f));
				if (this.bLEItem)
				{
					this.GM.SE_Item_L_Color[0] = this.tmpDonationData[(int)this.mExchange].itemRank;
					this.GM.m_SpeciallyEffect.AddIconShow(false, mV3, SpeciallyEffect_Kind.Donation_Item_Material, 0, this.tmpDonationData[(int)this.mExchange].itemID, true, 2f);
				}
				else
				{
					this.GM.m_SpeciallyEffect.AddIconShow(false, mV3, SpeciallyEffect_Kind.Donation_Item, 0, this.tmpDonationData[(int)this.mExchange].itemID, true, 2f);
				}
				break;
			}
			case 3:
			{
				Vector2 mV4 = new Vector2(num2 + 65f, num3 + 174f);
				this.GM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(num2 + 132f, -(num3 - 168f));
				if (this.bLEItem)
				{
					this.GM.SE_Item_L_Color[0] = this.tmpDonationData[(int)this.mExchange].itemRank;
					this.GM.m_SpeciallyEffect.AddIconShow(false, mV4, SpeciallyEffect_Kind.Donation_Item_Material, 0, this.tmpDonationData[(int)this.mExchange].itemID, true, 2f);
				}
				else
				{
					this.GM.m_SpeciallyEffect.AddIconShow(false, mV4, SpeciallyEffect_Kind.Donation_Item, 0, this.tmpDonationData[(int)this.mExchange].itemID, true, 2f);
				}
				break;
			}
			}
			break;
		}
		}
	}

	// Token: 0x06001041 RID: 4161 RVA: 0x001D207C File Offset: 0x001D027C
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x06001042 RID: 4162 RVA: 0x001D2080 File Offset: 0x001D0280
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06001043 RID: 4163 RVA: 0x001D2084 File Offset: 0x001D0284
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		if (uibutton != null)
		{
			switch (uibutton.m_BtnID1)
			{
			case 2:
				this.Img_Hint.gameObject.SetActive(true);
				break;
			case 4:
				if (uibutton.m_BtnID2 >= 0 && uibutton.m_BtnID2 < this.Img_MultipleHint.Length)
				{
					this.Img_MultipleHint[uibutton.m_BtnID2].gameObject.SetActive(true);
				}
				break;
			}
		}
		else
		{
			this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpDonationData[(int)sender.Parm1].itemID);
			this.bLEItem = this.GM.IsLeadItem(this.tmpEquip.EquipKind);
			if (this.bLEItem)
			{
				this.GM.m_LordInfo.Show(sender, this.tmpDonationData[(int)sender.Parm1].itemID, this.tmpDonationData[(int)sender.Parm1].itemRank, (int)this.mDonationItemQty[(int)sender.Parm1]);
			}
			else
			{
				this.GM.m_SimpleItemInfo.Show(sender, this.tmpDonationData[(int)sender.Parm1].itemID, (int)this.mDonationItemQty[(int)sender.Parm1], UIButtonHint.ePosition.Original, null);
			}
		}
	}

	// Token: 0x06001044 RID: 4164 RVA: 0x001D2200 File Offset: 0x001D0400
	public void OnButtonUp(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		if (uibutton != null)
		{
			switch (uibutton.m_BtnID1)
			{
			case 2:
				this.Img_Hint.gameObject.SetActive(false);
				break;
			case 4:
				if (uibutton.m_BtnID2 >= 0 && uibutton.m_BtnID2 < this.Img_MultipleHint.Length)
				{
					this.Img_MultipleHint[uibutton.m_BtnID2].gameObject.SetActive(false);
				}
				break;
			}
		}
		else
		{
			this.GM.m_LordInfo.Hide(sender);
			this.GM.m_SimpleItemInfo.Hide(sender);
		}
	}

	// Token: 0x06001045 RID: 4165 RVA: 0x001D22C0 File Offset: 0x001D04C0
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			if (this.mCountValue > 0u)
			{
				this.mSendCDTime -= 1f;
				if (this.mSendCDTime == 0f)
				{
					this.SendDonationValue();
				}
			}
			if (this.text_Time != null)
			{
				this.Cstr_Time.ClearString();
				long num = this.AM.mAllianceDonation_EndTime - this.DM.ServerTime;
				if (num < 0L)
				{
					num = 0L;
				}
				this.Cstr_Time.IntToFormat(num / 3600L, 1, false);
				num %= 3600L;
				this.Cstr_Time.IntToFormat(num / 60L, 2, false);
				num %= 60L;
				this.Cstr_Time.IntToFormat(num, 2, false);
				this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
				this.text_Time.text = this.Cstr_Time.ToString();
				this.text_Time.SetAllDirty();
				this.text_Time.cachedTextGenerator.Invalidate();
			}
		}
		if (this.bCloseMenu && this.door != null)
		{
			this.door.CloseMenu(false);
		}
		for (int i = 0; i < 4; i++)
		{
			if (this.mBtnCD[i] > 0f && this.btn_Exchange_Scale[i] != null)
			{
				this.mBtnCD[i] -= Time.smoothDeltaTime;
				if (this.mBtnCD[i] < 0f)
				{
					this.btn_Exchange_Scale[i].enabled = true;
				}
			}
			if (this.mValueScale[i] > 0f && this.text_ItemNum[i] != null)
			{
				this.mValueScale[i] -= Time.smoothDeltaTime;
				float num2;
				if (this.mValueScale[i] >= 0.1f)
				{
					float t = (0.2f - this.mValueScale[i]) * 10f;
					num2 = Mathf.Lerp(1f, 1.5f, t);
				}
				else if (this.mValueScale[i] < 0f)
				{
					this.mValueScale[i] = 0f;
					num2 = 1f;
				}
				else
				{
					if (!this.bShowChangValue[i])
					{
						if (this.mDonationData[i] < (int)this.mDonationDataCount[i])
						{
							this.mDonationData[i]++;
						}
						this.Cstr_ItemNum[i].ClearString();
						int num3 = (int)this.tmpDonationData[i].DonateNumber + this.mDonationData[i];
						if (num3 >= this.tmpDonateAmountData[i].DonateAmount.Length)
						{
							num3 = this.tmpDonateAmountData[i].DonateAmount.Length - 1;
						}
						this.Cstr_ItemNum[i].IntToFormat((long)this.tmpDonateAmountData[i].DonateAmount[num3], 1, true);
						if (this.GM.IsArabic)
						{
							this.Cstr_ItemNum[i].AppendFormat("{0}x");
						}
						else
						{
							this.Cstr_ItemNum[i].AppendFormat("x{0}");
						}
						this.text_ItemNum[i].text = this.Cstr_ItemNum[i].ToString();
						this.text_ItemNum[i].SetAllDirty();
						this.text_ItemNum[i].cachedTextGenerator.Invalidate();
						this.text_ItemNum[i].cachedTextGeneratorForLayout.Invalidate();
						this.text_ItemNum[i].rectTransform.anchoredPosition = new Vector2(106f + this.text_ItemNum[i].preferredWidth / 2f, this.text_ItemNum[i].rectTransform.anchoredPosition.y);
						this.bShowChangValue[i] = true;
					}
					float t = (0.1f - this.mValueScale[i]) * 10f;
					num2 = Mathf.Lerp(1.5f, 1f, t);
				}
				if (this.GM.IsArabic)
				{
					this.text_ItemNum[i].rectTransform.localScale = new Vector3(-num2, num2, num2);
				}
				else
				{
					this.text_ItemNum[i].rectTransform.localScale = new Vector3(num2, num2, num2);
				}
			}
			if (this.mMultipleScale[i] > 0f && this.Img_Multiple[i][0].gameObject.activeSelf)
			{
				if (this.mShowStatus[i] == 1)
				{
					if (this.mMultipleScale[i] >= 0.4f)
					{
						this.mMultipleScale[i] -= Time.smoothDeltaTime;
						float num2 = Mathf.Lerp(1f, 1.5f, 20f * (0.5f - this.mMultipleScale[i]));
						this.Img_Multiple[i][0].rectTransform.localScale = new Vector3(num2, num2, num2);
					}
					else
					{
						this.mShowStatus[i] = 2;
					}
				}
				else if (this.mShowStatus[i] == 2)
				{
					if (this.mMultipleScale[i] > 0.2f)
					{
						this.mMultipleScale[i] -= Time.smoothDeltaTime;
					}
					else
					{
						this.mShowStatus[i] = 3;
					}
				}
				else if (this.mShowStatus[i] == 3)
				{
					if (this.mMultipleScale[i] > 0f)
					{
						this.mMultipleScale[i] -= Time.smoothDeltaTime;
						if (this.mMultipleScale[i] <= 0f)
						{
							this.mShowStatus[i] = 0;
							this.mMultipleScale[i] = 0f;
							this.Img_Multiple[i][0].color = new Color(1f, 1f, 1f, 1f);
							this.Img_Multiple[i][1].color = new Color(1f, 1f, 1f, 1f);
							this.Img_Multiple[i][2].color = new Color(1f, 1f, 1f, 1f);
							this.Img_Multiple[i][0].gameObject.SetActive(false);
							this.Img_MultipleHint[i].gameObject.SetActive(false);
							this.Img_Multiple[i][0].rectTransform.localScale = new Vector3(1f, 1f, 1f);
						}
						else
						{
							this.Img_Multiple[i][0].color = new Color(1f, 1f, 1f, this.mMultipleScale[i] * 5f);
							this.Img_Multiple[i][1].color = new Color(1f, 1f, 1f, this.mMultipleScale[i] * 5f);
							this.Img_Multiple[i][2].color = new Color(1f, 1f, 1f, this.mMultipleScale[i] * 5f);
						}
					}
				}
				else if (this.mShowStatus[i] == 4)
				{
					if (this.mMultipleScale[i] >= 0.1f)
					{
						this.mMultipleScale[i] -= Time.smoothDeltaTime;
						float num2 = Mathf.Lerp(1f, 1.3f, 20f * (0.2f - this.mMultipleScale[i]));
						if (this.GM.IsArabic)
						{
							this.text_ItemName[i].rectTransform.localScale = new Vector3(-num2, num2, num2);
						}
						else
						{
							this.text_ItemName[i].rectTransform.localScale = new Vector3(num2, num2, num2);
						}
						this.Img_Multiple[i][0].rectTransform.localScale = new Vector3(num2, num2, num2);
					}
					else
					{
						this.mShowStatus[i] = 5;
					}
				}
				else if (this.mShowStatus[i] == 5 && this.mMultipleScale[i] > 0f)
				{
					this.mMultipleScale[i] -= Time.smoothDeltaTime;
					float num2;
					if (this.mMultipleScale[i] <= 0f)
					{
						this.mShowStatus[i] = 0;
						this.mMultipleScale[i] = 0f;
						num2 = 1f;
					}
					else
					{
						num2 = Mathf.Lerp(1.3f, 1f, 10f * (0.1f - this.mMultipleScale[i]));
					}
					if (this.GM.IsArabic)
					{
						this.text_ItemName[i].rectTransform.localScale = new Vector3(-num2, num2, num2);
					}
					else
					{
						this.text_ItemName[i].rectTransform.localScale = new Vector3(num2, num2, num2);
					}
					this.Img_Multiple[i][0].rectTransform.localScale = new Vector3(num2, num2, num2);
				}
			}
			for (int j = 0; j < 4; j++)
			{
				if (this.text_AddScore[i] != null && this.text_AddScore[i][j] != null && this.text_AddScore[i][j].IsActive())
				{
					this.mShowEffectTime[i][j] += Time.smoothDeltaTime;
					int num3;
					if (i < 2)
					{
						num3 = 20;
					}
					else
					{
						num3 = -168;
					}
					if (this.text_AddScore[i][j].rectTransform.anchoredPosition.y >= (float)num3 + 40f * this.tmptestY && this.text_AddScore[i][j].rectTransform.anchoredPosition.y < (float)num3 + 70f * this.tmptestY)
					{
						this.text_AddScore[i][j].color = new Color(this.text_AddScore[i][j].color.r, this.text_AddScore[i][j].color.g, this.text_AddScore[i][j].color.b, ((float)num3 + 70f * this.tmptestY - this.text_AddScore[i][j].rectTransform.anchoredPosition.y) / (30f * this.tmptestY));
					}
					else if (this.text_AddScore[i][j].rectTransform.anchoredPosition.y >= (float)num3 + 70f * this.tmptestY)
					{
						this.text_AddScore[i][j].gameObject.SetActive(false);
					}
					this.text_AddScore[i][j].rectTransform.anchoredPosition = new Vector2(this.text_AddScore[i][j].rectTransform.anchoredPosition.x, (float)num3 + this.mShowEffectTime[i][j] * (70f * this.tmptestY));
				}
			}
		}
	}

	// Token: 0x06001046 RID: 4166 RVA: 0x001D2E0C File Offset: 0x001D100C
	public void SendDonationValue()
	{
		this.mDonation_Score += this.mAddScore;
		this.mAddScore = 0UL;
		this.mSendCDTime = 0f;
		ushort num = 0;
		for (int i = 0; i < 4; i++)
		{
			num += this.tmpDonationData[i].DonateNumber;
			BoardData[] array = this.tmpDonationData;
			int num2 = i;
			array[num2].DonateNumber = array[num2].DonateNumber + (ushort)this.mDonationDataCount[i];
			this.mDonationData[i] = 0;
			this.mDonationDataCount[i] = 0;
		}
		this.AM.Send_ACTIVITY_AS_DONATE_DATA(num, (byte)this.mCountValue, this.mDonation_Index);
		Array.Clear(this.mDonation_Index, 0, this.mDonation_Index.Length);
		this.mCountValue = 0u;
	}

	// Token: 0x06001047 RID: 4167 RVA: 0x001D2ED0 File Offset: 0x001D10D0
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.NowScoreText != null && this.NowScoreText.enabled)
		{
			this.NowScoreText.enabled = false;
			this.NowScoreText.enabled = true;
		}
		if (this.NextScoreText != null && this.NextScoreText.enabled)
		{
			this.NextScoreText.enabled = false;
			this.NextScoreText.enabled = true;
		}
		if (this.text_Hint != null && this.text_Hint.enabled)
		{
			this.text_Hint.enabled = false;
			this.text_Hint.enabled = true;
		}
		if (this.text_Time != null && this.text_Time.enabled)
		{
			this.text_Time.enabled = false;
			this.text_Time.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.RBText[i] != null && this.RBText[i].enabled)
			{
				this.RBText[i].enabled = false;
				this.RBText[i].enabled = true;
			}
		}
		for (int j = 0; j < 3; j++)
		{
			if (this.StageScoreText[j] != null && this.StageScoreText[j].enabled)
			{
				this.StageScoreText[j].enabled = false;
				this.StageScoreText[j].enabled = true;
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (this.text_ItemExchange[k] != null && this.text_ItemExchange[k].enabled)
			{
				this.text_ItemExchange[k].enabled = false;
				this.text_ItemExchange[k].enabled = true;
			}
			if (this.text_ItemNum[k] != null && this.text_ItemNum[k].enabled)
			{
				this.text_ItemNum[k].enabled = false;
				this.text_ItemNum[k].enabled = true;
			}
			if (this.text_ItemName[k] != null && this.text_ItemName[k].enabled)
			{
				this.text_ItemName[k].enabled = false;
				this.text_ItemName[k].enabled = true;
			}
			if (this.text_MultipleHint[k] != null && this.text_MultipleHint[k].enabled)
			{
				this.text_MultipleHint[k].enabled = false;
				this.text_MultipleHint[k].enabled = true;
			}
			if (this.text_AddScore[k][0] != null && this.text_AddScore[k][0].enabled)
			{
				this.text_AddScore[k][0].enabled = false;
				this.text_AddScore[k][0].enabled = true;
			}
			if (this.text_AddScore[k][1] != null && this.text_AddScore[k][1].enabled)
			{
				this.text_AddScore[k][1].enabled = false;
				this.text_AddScore[k][1].enabled = true;
			}
			if (this.text_AddScore[k][2] != null && this.text_AddScore[k][2].enabled)
			{
				this.text_AddScore[k][2].enabled = false;
				this.text_AddScore[k][2].enabled = true;
			}
			if (this.text_AddScore[k][3] != null && this.text_AddScore[k][3].enabled)
			{
				this.text_AddScore[k][3].enabled = false;
				this.text_AddScore[k][3].enabled = true;
			}
		}
	}

	// Token: 0x06001048 RID: 4168 RVA: 0x001D32DC File Offset: 0x001D14DC
	private void Start()
	{
	}

	// Token: 0x06001049 RID: 4169 RVA: 0x001D32E0 File Offset: 0x001D14E0
	private void Update()
	{
	}

	// Token: 0x0400354D RID: 13645
	private const byte StepCount = 3;

	// Token: 0x0400354E RID: 13646
	private const int PCount = 4;

	// Token: 0x0400354F RID: 13647
	private const byte FactorCount = 5;

	// Token: 0x04003550 RID: 13648
	private Transform m_transform;

	// Token: 0x04003551 RID: 13649
	private Transform Main2T;

	// Token: 0x04003552 RID: 13650
	private Transform[] mLbtn_ItemT = new Transform[4];

	// Token: 0x04003553 RID: 13651
	private DataManager DM;

	// Token: 0x04003554 RID: 13652
	private GUIManager GM;

	// Token: 0x04003555 RID: 13653
	private ActivityManager AM;

	// Token: 0x04003556 RID: 13654
	private Font tmpFont;

	// Token: 0x04003557 RID: 13655
	private Door door;

	// Token: 0x04003558 RID: 13656
	private UIButton btn_EXIT;

	// Token: 0x04003559 RID: 13657
	private UIButton btn_I;

	// Token: 0x0400355A RID: 13658
	private UIButton btn_CDTime;

	// Token: 0x0400355B RID: 13659
	private UIButton[] btn_Exchange = new UIButton[4];

	// Token: 0x0400355C RID: 13660
	private UIButton[] btn_MultipleHint = new UIButton[4];

	// Token: 0x0400355D RID: 13661
	private uButtonScale[] btn_Exchange_Scale = new uButtonScale[4];

	// Token: 0x0400355E RID: 13662
	private Image TopTriImage;

	// Token: 0x0400355F RID: 13663
	private Image Img_Hint;

	// Token: 0x04003560 RID: 13664
	private Image[] SliderNormal = new Image[3];

	// Token: 0x04003561 RID: 13665
	private Image[] SliderFlash = new Image[3];

	// Token: 0x04003562 RID: 13666
	private Image[] Img_MultipleBG = new Image[4];

	// Token: 0x04003563 RID: 13667
	private Image[][] Img_Multiple = new Image[4][];

	// Token: 0x04003564 RID: 13668
	private Image[] Img_MultipleHint = new Image[4];

	// Token: 0x04003565 RID: 13669
	private UIText text_Title;

	// Token: 0x04003566 RID: 13670
	private UIText NowScoreText;

	// Token: 0x04003567 RID: 13671
	private UIText NextScoreText;

	// Token: 0x04003568 RID: 13672
	private UIText text_Hint;

	// Token: 0x04003569 RID: 13673
	private UIText text_Time;

	// Token: 0x0400356A RID: 13674
	private UIText[] StageScoreText = new UIText[3];

	// Token: 0x0400356B RID: 13675
	private UIText[] RBText = new UIText[2];

	// Token: 0x0400356C RID: 13676
	private UIText[] text_ItemExchange = new UIText[4];

	// Token: 0x0400356D RID: 13677
	private UIText[] text_ItemNum = new UIText[4];

	// Token: 0x0400356E RID: 13678
	private UIText[] text_ItemName = new UIText[4];

	// Token: 0x0400356F RID: 13679
	private UIText[] text_MultipleHint = new UIText[4];

	// Token: 0x04003570 RID: 13680
	private UIText[][] text_AddScore = new UIText[4][];

	// Token: 0x04003571 RID: 13681
	private Vector2 TriLastPos = new Vector2(395f, 9f);

	// Token: 0x04003572 RID: 13682
	private CString[] StageScore = new CString[3];

	// Token: 0x04003573 RID: 13683
	private CString NowScoreStr;

	// Token: 0x04003574 RID: 13684
	private CString NextScoreStr;

	// Token: 0x04003575 RID: 13685
	private CString Cstr_Time;

	// Token: 0x04003576 RID: 13686
	private CString[] Cstr_ItemNum = new CString[4];

	// Token: 0x04003577 RID: 13687
	private CString[] Cstr_ItemName = new CString[4];

	// Token: 0x04003578 RID: 13688
	private CString[] Cstr_MultipleHint = new CString[4];

	// Token: 0x04003579 RID: 13689
	private CString[][] Cstr_AddScore = new CString[4][];

	// Token: 0x0400357A RID: 13690
	private GameObject[] PGO = new GameObject[4];

	// Token: 0x0400357B RID: 13691
	private UIHIBtn[] btn_Item = new UIHIBtn[4];

	// Token: 0x0400357C RID: 13692
	private UILEBtn[] Lbtn_Item = new UILEBtn[4];

	// Token: 0x0400357D RID: 13693
	private byte nowStep;

	// Token: 0x0400357E RID: 13694
	private ulong nowScore;

	// Token: 0x0400357F RID: 13695
	private ulong[] StepScore = new ulong[3];

	// Token: 0x04003580 RID: 13696
	private ActivityDataType tmpData;

	// Token: 0x04003581 RID: 13697
	private byte mExchange;

	// Token: 0x04003582 RID: 13698
	private float[] mBtnCD = new float[4];

	// Token: 0x04003583 RID: 13699
	private float[] mValueScale = new float[4];

	// Token: 0x04003584 RID: 13700
	private float[] mMultipleScale = new float[4];

	// Token: 0x04003585 RID: 13701
	private int[] mShowStatus = new int[4];

	// Token: 0x04003586 RID: 13702
	private bool[] bShowChangValue = new bool[4];

	// Token: 0x04003587 RID: 13703
	private uint mCountValue;

	// Token: 0x04003588 RID: 13704
	private int[] mDonationData = new int[4];

	// Token: 0x04003589 RID: 13705
	private byte[] mDonationDataCount = new byte[4];

	// Token: 0x0400358A RID: 13706
	private byte[] mDonationMultiple = new byte[4];

	// Token: 0x0400358B RID: 13707
	private byte[] mDonation_Index = new byte[50];

	// Token: 0x0400358C RID: 13708
	private float mSendCDTime;

	// Token: 0x0400358D RID: 13709
	private ulong mAddScore;

	// Token: 0x0400358E RID: 13710
	private ulong mDonation_Score;

	// Token: 0x0400358F RID: 13711
	private BoardData[] tmpDonationData = new BoardData[4];

	// Token: 0x04003590 RID: 13712
	private uint tmpScore1;

	// Token: 0x04003591 RID: 13713
	private DonateAmountData[] tmpDonateAmountData = new DonateAmountData[4];

	// Token: 0x04003592 RID: 13714
	private ushort[] mDonationItemQty = new ushort[4];

	// Token: 0x04003593 RID: 13715
	private ushort mDonation_TCount;

	// Token: 0x04003594 RID: 13716
	public float[][] mShowEffectTime = new float[4][];

	// Token: 0x04003595 RID: 13717
	private bool bLEItem;

	// Token: 0x04003596 RID: 13718
	private Equip tmpEquip;

	// Token: 0x04003597 RID: 13719
	private Color mColor_G = new Color(0.078f, 0.973f, 0.333f);

	// Token: 0x04003598 RID: 13720
	private Color GreenColor = new Color(0.07843f, 0.9725f, 0.3333f, 1f);

	// Token: 0x04003599 RID: 13721
	private Color StageScoreColorY = new Color(1f, 0.945f, 0.203f);

	// Token: 0x0400359A RID: 13722
	private bool bEqDataReq;

	// Token: 0x0400359B RID: 13723
	private bool bMaterialDataReq;

	// Token: 0x0400359C RID: 13724
	private bool bCloseMenu;

	// Token: 0x0400359D RID: 13725
	private float tmptestY = 1f;

	// Token: 0x0400359E RID: 13726
	private byte[] tmpAddScoreIdx = new byte[4];
}
