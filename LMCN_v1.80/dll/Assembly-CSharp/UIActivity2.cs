using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002A6 RID: 678
public class UIActivity2 : GUIWindow, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler
{
	// Token: 0x06000D63 RID: 3427 RVA: 0x001462AC File Offset: 0x001444AC
	public override void OnOpen(int arg1, int arg2)
	{
		MallManager instance = MallManager.Instance;
		StringManager instance2 = StringManager.Instance;
		this.m_transform = base.transform;
		this.tmpFont = this.GM.GetTTFFont();
		this.NowScoreStr = instance2.SpawnString(30);
		this.NextScoreStr = instance2.SpawnString(30);
		this.m_transform.GetChild(4).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(4).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(4).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(5).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(5).gameObject.AddComponent<ArabicItemTextureRot>();
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(4).GetComponent<CustomImage>().enabled = false;
		}
		Transform child = this.m_transform.GetChild(1);
		this.Main2T = child.GetChild(0);
		this.NotOpenT = child.GetChild(1);
		this.Main2T.GetChild(26).GetComponent<UIButton>().m_Handler = this;
		this.Main2T.GetChild(28).GetComponent<UIButton>().m_Handler = this;
		this.SummonBtn = this.Main2T.GetChild(26).gameObject;
		this.SummonBtn2 = this.Main2T.GetChild(28).gameObject;
		this.SummonFlash = this.Main2T.GetChild(26).GetChild(0).gameObject;
		this.SummonAlert = this.Main2T.GetChild(27).gameObject;
		this.Main2T.GetChild(27).GetComponent<CustomImage>().hander = this;
		this.Main2T.GetChild(27).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.Main2T.GetChild(27).GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = this;
		Transform transform;
		if (arg1 >= 201 && arg1 <= 205)
		{
			if (arg1 - 201 >= this.AM.KvKActivityData.Length)
			{
				return;
			}
			this.ActivityIndex = (byte)arg1;
			this.tmpData = this.AM.KvKActivityData[arg1 - 201];
			if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalSoloEvent)
			{
				this.Main2T.GetChild(20).gameObject.SetActive(false);
				transform = child.GetChild(5);
				transform.gameObject.SetActive(true);
				this.RBText[1] = transform.GetChild(0).GetComponent<UIText>();
				this.RBText[1].font = this.tmpFont;
				this.RBText[1].text = this.DM.mStringTable.GetStringByID(9801u);
			}
			else if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalAllianceEvent)
			{
				this.Main2T.GetChild(20).gameObject.SetActive(false);
				transform = child.GetChild(7);
				transform.gameObject.SetActive(true);
				this.RBText[1] = transform.GetChild(0).GetComponent<UIText>();
				this.RBText[1].font = this.tmpFont;
				this.RBText[1].text = this.DM.mStringTable.GetStringByID(9803u);
			}
			else if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKSoloEvent)
			{
				this.Main2T.GetChild(20).gameObject.SetActive(false);
				transform = child.GetChild(6);
				transform.gameObject.SetActive(true);
				this.RBText[1] = transform.GetChild(0).GetComponent<UIText>();
				this.RBText[1].font = this.tmpFont;
				this.RBText[1].text = this.DM.mStringTable.GetStringByID(9804u);
			}
			else if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKAllianceEvent)
			{
				this.Main2T.GetChild(20).gameObject.SetActive(false);
				transform = child.GetChild(7);
				transform.gameObject.SetActive(true);
				this.RBText[1] = transform.GetChild(0).GetComponent<UIText>();
				this.RBText[1].font = this.tmpFont;
				this.RBText[1].text = this.DM.mStringTable.GetStringByID(9803u);
			}
			else if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKEvent)
			{
				this.Main2T.GetChild(20).gameObject.SetActive(false);
				transform = child.GetChild(8);
				transform.gameObject.SetActive(true);
				this.RBText[1] = transform.GetChild(0).GetComponent<UIText>();
				this.RBText[1].font = this.tmpFont;
				if (this.AM.IsMatchKvk())
				{
					this.RBText[1].text = this.DM.mStringTable.GetStringByID(12001u);
				}
				else
				{
					this.RBText[1].text = this.DM.mStringTable.GetStringByID(9802u);
				}
			}
		}
		else if (arg1 == 207)
		{
			this.ActivityIndex = (byte)arg1;
			this.tmpData = this.AM.KOWData;
			this.Main2T.GetChild(20).gameObject.SetActive(false);
			transform = child.GetChild(8);
			transform.gameObject.SetActive(true);
			this.RBText[1] = transform.GetChild(0).GetComponent<UIText>();
			this.RBText[1].font = this.tmpFont;
			this.RBText[1].text = this.DM.mStringTable.GetStringByID(10003u);
		}
		else if (arg1 == 208)
		{
			this.ActivityIndex = (byte)arg1;
			this.tmpData = this.AM.AllianceSummonData;
			this.Main2T.GetChild(20).gameObject.SetActive(false);
			transform = child.GetChild(4);
			transform.gameObject.SetActive(true);
			this.RBText[1] = transform.GetChild(3).GetComponent<UIText>();
			this.RBText[1].font = this.tmpFont;
			this.RBText[1].text = this.DM.mStringTable.GetStringByID(14501u);
			this.SetSummonBtnState();
			this.bSummonType = (this.tmpData.ActiveType == EActivityType.EAT_AllianceSummon);
		}
		else if (arg1 == 209)
		{
			this.ActivityIndex = (byte)arg1;
			this.tmpData = this.AM.NobilityActivityData;
			this.Main2T.GetChild(20).gameObject.SetActive(false);
			transform = child.GetChild(8);
			transform.gameObject.SetActive(true);
			this.RBText[1] = transform.GetChild(0).GetComponent<UIText>();
			this.RBText[1].font = this.tmpFont;
			this.RBText[1].text = this.DM.mStringTable.GetStringByID(11095u);
		}
		else if (arg1 >= 211 && arg1 <= 213)
		{
			if (arg1 - 211 >= this.AM.FIFAData.Length)
			{
				return;
			}
			this.ActivityIndex = (byte)arg1;
			this.tmpData = this.AM.FIFAData[arg1 - 211];
			bool flag = this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK;
			this.Main2T.GetChild(20).gameObject.SetActive(false);
			if (this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_SoloEvent)
			{
				if (flag)
				{
					transform = child.GetChild(6);
					transform.gameObject.SetActive(true);
					this.RBText[1] = transform.GetChild(0).GetComponent<UIText>();
				}
				else
				{
					transform = child.GetChild(2);
					transform.gameObject.SetActive(true);
					this.RBText[1] = transform.GetChild(1).GetComponent<UIText>();
				}
			}
			else if (this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_AllianceEvent)
			{
				if (flag)
				{
					transform = child.GetChild(7);
					transform.gameObject.SetActive(true);
					this.RBText[1] = transform.GetChild(0).GetComponent<UIText>();
				}
				else
				{
					transform = child.GetChild(4);
					transform.gameObject.SetActive(true);
					this.RBText[1] = transform.GetChild(3).GetComponent<UIText>();
				}
			}
			else if (this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_KingdomEvent)
			{
				if (flag)
				{
					transform = child.GetChild(8);
					transform.gameObject.SetActive(true);
					this.RBText[1] = transform.GetChild(0).GetComponent<UIText>();
				}
				else
				{
					transform = child.GetChild(4);
					transform.gameObject.SetActive(true);
					this.RBText[1] = transform.GetChild(3).GetComponent<UIText>();
				}
			}
			this.RBText[1].font = this.tmpFont;
			this.RBText[1].text = this.DM.mStringTable.GetStringByID((uint)this.tmpData.Name);
		}
		else
		{
			if (arg1 >= this.AM.ActivityData.Length)
			{
				return;
			}
			this.ActivityIndex = (byte)arg1;
			this.tmpData = this.AM.ActivityData[arg1];
			if (this.tmpData.ActiveType == EActivityType.EAT_SoloEvent)
			{
				this.Main2T.GetChild(20).gameObject.SetActive(false);
				transform = child.GetChild(2);
				transform.gameObject.SetActive(true);
				this.RBText[1] = transform.GetChild(1).GetComponent<UIText>();
				this.RBText[1].font = this.tmpFont;
				this.RBText[1].text = this.DM.mStringTable.GetStringByID(8101u);
			}
			else if (this.tmpData.ActiveType == EActivityType.EAT_InfernalEvent)
			{
				this.Main2T.GetChild(20).gameObject.SetActive(false);
				transform = child.GetChild(3);
				transform.gameObject.SetActive(true);
				this.RBText[1] = transform.GetChild(1).GetComponent<UIText>();
				this.RBText[1].font = this.tmpFont;
				this.RBText[1].text = this.DM.mStringTable.GetStringByID(8102u);
			}
		}
		this.RBText[0] = this.NotOpenT.GetChild(0).GetComponent<UIText>();
		this.RBText[0].font = this.tmpFont;
		this.RBText[0].text = this.DM.mStringTable.GetStringByID(8112u);
		this.RBText[4] = this.Main2T.GetChild(6).GetComponent<UIText>();
		this.RBText[4].font = this.tmpFont;
		this.RBText[4].text = this.DM.mStringTable.GetStringByID(8116u);
		this.RBText[5] = this.Main2T.GetChild(7).GetComponent<UIText>();
		this.RBText[5].font = this.tmpFont;
		this.RBText[5].text = this.DM.mStringTable.GetStringByID(8117u);
		this.NowScoreText = this.Main2T.GetChild(8).GetComponent<UIText>();
		this.NowScoreText.font = this.tmpFont;
		this.NextScoreText = this.Main2T.GetChild(9).GetComponent<UIText>();
		this.NextScoreText.font = this.tmpFont;
		transform = this.Main2T.GetChild(5);
		this.SliderNormal[0] = transform.GetChild(2).GetComponent<Image>();
		this.SliderNormal[1] = transform.GetChild(3).GetComponent<Image>();
		this.SliderNormal[2] = transform.GetChild(4).GetComponent<Image>();
		this.SliderFlash[0] = transform.GetChild(5).GetComponent<Image>();
		this.SliderFlash[1] = transform.GetChild(6).GetComponent<Image>();
		this.SliderFlash[2] = transform.GetChild(7).GetComponent<Image>();
		this.TopTriImage = transform.GetChild(11).GetComponent<Image>();
		this.StageScoreText[0] = transform.GetChild(12).GetComponent<UIText>();
		this.StageScoreText[0].font = this.tmpFont;
		this.StageScoreText[1] = transform.GetChild(13).GetComponent<UIText>();
		this.StageScoreText[1].font = this.tmpFont;
		this.StageScoreText[2] = transform.GetChild(14).GetComponent<UIText>();
		this.StageScoreText[2].font = this.tmpFont;
		this.StepScore[0] = (ulong)this.tmpData.RequireScore[0];
		this.StepScore[1] = (ulong)this.tmpData.RequireScore[1];
		this.StepScore[2] = (ulong)this.tmpData.RequireScore[2];
		for (int i = 0; i < 3; i++)
		{
			this.StageScore[i] = instance2.SpawnString(30);
			this.StageScore[i].uLongToFormat(this.StepScore[i], 1, true);
			this.StageScore[i].AppendFormat("{0}");
			this.StageScoreText[i].text = this.StageScore[i].ToString();
			if (this.tmpData.EventBonusType == EActEventBonusType.EAEBT_RequireScoreDown)
			{
				this.StageScoreText[i].color = this.GreenColor;
			}
		}
		if (this.tmpData.EventBonusType == EActEventBonusType.EAEBT_RequireScoreDown)
		{
			this.Main2T.GetChild(5).GetChild(15).gameObject.SetActive(true);
			UIButtonHint uibuttonHint = this.Main2T.GetChild(5).GetChild(15).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.ControlFadeOut = this.m_transform.GetChild(2).gameObject;
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 2;
			this.HintT3 = this.m_transform.GetChild(6).GetComponent<RectTransform>();
			this.RBText2[10] = this.HintT3.GetChild(0).GetComponent<UIText>();
			this.RBText2[10].font = this.tmpFont;
			this.RBText2[10].alignment = TextAnchor.UpperLeft;
			this.RBText2[10].text = this.DM.mStringTable.GetStringByID(8180u);
			float num = this.RBText2[10].preferredHeight + 1f;
			this.RBText2[10].rectTransform.sizeDelta = new Vector2(this.RBText2[10].rectTransform.sizeDelta.x, num);
			this.HintT3.sizeDelta = new Vector2(this.HintT3.sizeDelta.x, num + 30f);
		}
		this.RBText[6] = this.Main2T.GetChild(10).GetComponent<UIText>();
		this.RBText[6].font = this.tmpFont;
		this.RBText[6].text = this.DM.mStringTable.GetStringByID(8118u);
		UISpritesArray component = this.Main2T.GetComponent<UISpritesArray>();
		int num2 = 12;
		for (int j = 0; j < 5; j++)
		{
			transform = this.Main2T.GetChild(j + num2);
			int factor = (int)this.tmpData.GetScoreFactor[j].Factor;
			if (factor < component.m_Sprites.Length)
			{
				transform.GetComponent<Image>().sprite = component.m_Sprites[factor];
			}
			else
			{
				transform.GetComponent<Image>().sprite = component.m_Sprites[0];
			}
			this.FctorText1[j] = transform.GetChild(0).GetComponent<UIText>();
			this.FctorText1[j].font = this.tmpFont;
			this.FctorText1[j].text = this.GetScoreFactorStr(this.tmpData.GetScoreFactor[j].Factor);
			if ((this.tmpData.ActiveType == EActivityType.EAT_KingdomMatchEvent || this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK) && this.AM.MatchKingdomCount == 4)
			{
				this.FctorText2[j] = transform.GetChild(6).GetChild(0).GetComponent<UIText>();
				this.FctorText2[j].font = this.tmpFont;
				this.FctorText3[j] = transform.GetChild(5).GetChild(0).GetComponent<UIText>();
				this.FctorText3[j].font = this.tmpFont;
				if (this.tmpData.GetScoreFactor[j].BonusRate != 0)
				{
					transform.gameObject.SetActive(true);
					byte huntBonusRate = this.AM.GetHuntBonusRate(this.ActivityIndex, this.tmpData.GetScoreFactor[j].Factor);
					this.ScoreFactorRateStr2[j] = instance2.SpawnString(30);
					if (huntBonusRate > 1)
					{
						this.ScoreFactorRateStr2[j].IntToFormat((long)huntBonusRate, 1, false);
						if (this.GM.IsArabic)
						{
							this.ScoreFactorRateStr2[j].AppendFormat("{0}x");
						}
						else
						{
							this.ScoreFactorRateStr2[j].AppendFormat("x{0}");
						}
						transform.GetChild(6).GetComponent<RectTransform>().anchoredPosition -= new Vector2(35f, 0f);
						transform.GetChild(5).gameObject.SetActive(true);
					}
					this.FctorText3[j].text = this.ScoreFactorRateStr2[j].ToString();
					this.ScoreFactorRateStr[j] = instance2.SpawnString(30);
					if (this.tmpData.GetScoreFactor[j].BonusRate > 1)
					{
						this.ScoreFactorRateStr[j].IntToFormat((long)this.tmpData.GetScoreFactor[j].BonusRate, 1, false);
						if (this.GM.IsArabic)
						{
							this.ScoreFactorRateStr[j].AppendFormat("{0}x");
						}
						else
						{
							this.ScoreFactorRateStr[j].AppendFormat("x{0}");
						}
						transform.GetChild(6).gameObject.SetActive(true);
					}
					this.FctorText2[j].text = this.ScoreFactorRateStr[j].ToString();
					if (this.tmpData.GetScoreFactor[j].Factor == EGetScoreFactor.EGSF_Donate)
					{
						transform.GetComponent<UIButton>().m_EffectType = e_EffectType.e_Scale;
						transform.GetComponent<UIButton>().SoundIndex = 0;
						transform.GetComponent<UIButton>().m_Handler = this;
						transform.GetComponent<UIButton>().m_BtnID1 = 10;
						transform.GetComponent<UIButton>().m_BtnID2 = (int)this.tmpData.GetScoreFactor[j].Factor;
						transform.GetChild(4).gameObject.SetActive(true);
					}
					else
					{
						transform.GetComponent<UIButton>().m_BtnID2 = j;
						UIButtonHint uibuttonHint = transform.gameObject.AddComponent<UIButtonHint>();
						uibuttonHint.ControlFadeOut = this.m_transform.GetChild(2).gameObject;
						uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
						uibuttonHint.m_Handler = this;
						if (this.tmpData.GetScoreFactor[j].Factor == EGetScoreFactor.EGSF_WinNPCCity)
						{
							uibuttonHint.Parm1 = 3;
							this.StarObj = transform.GetChild(2).gameObject;
							this.StarObj2 = transform.GetChild(3).gameObject;
							this.SetNPCCityStarObj();
						}
						else
						{
							uibuttonHint.Parm1 = 0;
						}
					}
				}
				else
				{
					this.FctorText2[j].text = string.Empty;
				}
			}
			else
			{
				this.FctorText2[j] = transform.GetChild(1).GetComponent<UIText>();
				this.FctorText2[j].font = this.tmpFont;
				if (this.tmpData.GetScoreFactor[j].BonusRate != 0)
				{
					transform.gameObject.SetActive(true);
					this.ScoreFactorRateStr[j] = instance2.SpawnString(30);
					if (this.tmpData.GetScoreFactor[j].BonusRate > 1)
					{
						this.ScoreFactorRateStr[j].IntToFormat((long)this.tmpData.GetScoreFactor[j].BonusRate, 1, false);
						if (this.GM.IsArabic)
						{
							this.ScoreFactorRateStr[j].AppendFormat("{0}x");
						}
						else
						{
							this.ScoreFactorRateStr[j].AppendFormat("x{0}");
						}
					}
					this.FctorText2[j].text = this.ScoreFactorRateStr[j].ToString();
					if (this.tmpData.GetScoreFactor[j].Factor == EGetScoreFactor.EGSF_Donate)
					{
						transform.GetComponent<UIButton>().m_EffectType = e_EffectType.e_Scale;
						transform.GetComponent<UIButton>().SoundIndex = 0;
						transform.GetComponent<UIButton>().m_Handler = this;
						transform.GetComponent<UIButton>().m_BtnID1 = 10;
						transform.GetComponent<UIButton>().m_BtnID2 = (int)this.tmpData.GetScoreFactor[j].Factor;
						transform.GetChild(4).gameObject.SetActive(true);
					}
					else
					{
						transform.GetComponent<UIButton>().m_BtnID2 = j;
						UIButtonHint uibuttonHint = transform.gameObject.AddComponent<UIButtonHint>();
						uibuttonHint.ControlFadeOut = this.m_transform.GetChild(2).gameObject;
						uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
						uibuttonHint.m_Handler = this;
						if (this.tmpData.GetScoreFactor[j].Factor == EGetScoreFactor.EGSF_WinNPCCity)
						{
							uibuttonHint.Parm1 = 3;
							this.StarObj = transform.GetChild(2).gameObject;
							this.StarObj2 = transform.GetChild(3).gameObject;
							this.SetNPCCityStarObj();
						}
						else
						{
							uibuttonHint.Parm1 = 0;
						}
					}
				}
				else
				{
					this.FctorText2[j].text = string.Empty;
				}
			}
		}
		this.HintT = this.m_transform.GetChild(2).GetComponent<RectTransform>();
		int num3 = 0;
		for (int k = 0; k < 12; k++)
		{
			this.HintTextL[k] = this.HintT.GetChild(num3).GetComponent<UIText>();
			this.HintTextL[k].font = this.tmpFont;
			this.HintTextL[k].alignment = TextAnchor.UpperLeft;
			this.HintStrL[k] = instance2.SpawnString(100);
			num3++;
			this.HintTextR[k] = this.HintT.GetChild(num3).GetComponent<UIText>();
			this.HintTextR[k].font = this.tmpFont;
			this.HintTextR[k].alignment = TextAnchor.UpperRight;
			this.HintStrR[k] = instance2.SpawnString(50);
			num3++;
		}
		this.HintT.anchorMin = new Vector2(0f, 1f);
		this.HintT.anchorMax = new Vector2(0f, 1f);
		this.HintT.pivot = new Vector2(0f, 1f);
		RectTransform component2 = this.GM.m_UICanvas.GetComponent<RectTransform>();
		this.Sizex = component2.sizeDelta.x;
		this.Sizey = component2.sizeDelta.y;
		this.HintT.anchoredPosition = new Vector2(this.Sizex / 2f - 86f, -this.Sizey / 2f + 51f);
		this.HintGO = this.HintT.GetChild(24).gameObject;
		this.HintText1 = this.HintGO.transform.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.HintText1.font = this.tmpFont;
		this.HintStr1 = instance2.SpawnString(30);
		this.HintText2 = this.HintGO.transform.GetChild(1).GetComponent<UIText>();
		this.HintText2.font = this.tmpFont;
		this.HintStr2 = instance2.SpawnString(300);
		this.HintSPText = this.HintT.GetChild(25).GetComponent<UIText>();
		this.HintSPText.font = this.tmpFont;
		this.HintSPText.text = this.DM.mStringTable.GetStringByID(17521u);
		this.HintSPText.alignment = TextAnchor.UpperLeft;
		this.RBText[7] = this.Main2T.GetChild(18).GetComponent<UIText>();
		this.RBText[7].font = this.tmpFont;
		this.RBText[7].text = this.DM.mStringTable.GetStringByID(8119u);
		this.Main2T.GetChild(19).GetComponent<UIButton>().m_Handler = this;
		this.Main2T.GetChild(20).GetComponent<UIButton>().m_Handler = this;
		this.Main2T.GetChild(21).GetComponent<UIButton>().m_Handler = this;
		if (this.GM.IsArabic)
		{
			this.Main2T.GetChild(19).localScale = new Vector3(-1f, 1f, 1f);
		}
		for (int l = 0; l < 3; l++)
		{
			this.ItemCount[l] = (int)this.tmpData.DataLen[l];
		}
		this.ItemCountText = new CString[3][];
		this.ItemCountText[0] = new CString[this.ItemCount[0]];
		this.ItemCountText[1] = new CString[this.ItemCount[1]];
		this.ItemCountText[2] = new CString[this.ItemCount[2]];
		this.StepItemCountText[0] = new UIText[this.ItemCount[0]];
		this.StepItemCountText[1] = new UIText[this.ItemCount[1]];
		this.StepItemCountText[2] = new UIText[this.ItemCount[2]];
		float num4 = 0f;
		int num5 = 0;
		this.ContentT = this.Main2T.GetChild(22).GetChild(0);
		if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKEvent || (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_KingdomEvent))
		{
			this.RBText[4].enabled = false;
			this.RBText[5].enabled = false;
			this.NowScoreText.enabled = false;
			this.NextScoreText.enabled = false;
			this.Main2T.GetChild(5).gameObject.SetActive(false);
			this.Main2T.GetChild(19).gameObject.SetActive(false);
			this.ContentT.GetChild(0).gameObject.SetActive(false);
			this.ContentT.GetChild(1).gameObject.SetActive(false);
			this.ContentT.GetChild(2).gameObject.SetActive(false);
			if (this.tmpData.ActiveType == EActivityType.EAT_KingdomMatchEvent || this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK)
			{
				if (this.AM.MatchKingdomCount == 4)
				{
					this.bKVKForFourth = true;
					this.LoadSP("CT_MatchKVK_4");
					this.SPT.GetChild(4).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(5).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(6).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(7).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(8).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(9).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(10).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(11).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(12).gameObject.AddComponent<ArabicItemTextureRot>();
					if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
					{
						this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 682f);
					}
					else
					{
						this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 1357f);
					}
					this.SPT.gameObject.SetActive(true);
					this.Main2T.GetChild(11).gameObject.SetActive(true);
					this.RBText2[10] = this.Main2T.GetChild(11).GetComponent<UIText>();
					this.RBText2[10].font = this.tmpFont;
					if (this.tmpData.EventState == EActivityState.EAS_Prepare)
					{
						this.RBText2[10].text = this.DM.mStringTable.GetStringByID(9809u);
					}
					else if (this.tmpData.EventState == EActivityState.EAS_Run)
					{
						this.RBText2[10].text = this.DM.mStringTable.GetStringByID(9805u);
						this.Main2T.GetChild(21).gameObject.SetActive(true);
					}
					else if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
					{
						if (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && !this.AM.FIFA_bGetChampion)
						{
							this.RBText2[10].text = this.DM.mStringTable.GetStringByID(9811u);
						}
						else
						{
							this.Main2T.GetChild(20).gameObject.SetActive(true);
							this.Main2T.GetChild(20).GetComponent<RectTransform>().anchoredPosition += new Vector2(75f, 0f);
							this.RBText2[10].gameObject.SetActive(false);
							this.Main2T.GetChild(11).gameObject.SetActive(false);
							this.Main2T.GetChild(25).gameObject.SetActive(true);
							transform = this.Main2T.GetChild(25);
							long num6 = (long)this.AM.KingdomKvKRank;
							if (num6 <= 25L)
							{
								transform.GetChild(1).gameObject.SetActive(true);
								UIText component3 = transform.GetChild(1).GetComponent<UIText>();
								component3.font = this.tmpFont;
								component3.text = this.DM.mStringTable.GetStringByID(574u);
								this.SPT.GetChild(1).gameObject.SetActive(false);
								this.SPT.GetChild(21).gameObject.SetActive(false);
								this.SPT.GetChild(2).gameObject.SetActive(false);
								this.SPT.GetChild(22).gameObject.SetActive(false);
							}
							else if (num6 > 25L && num6 <= 50L)
							{
								transform.GetChild(2).gameObject.SetActive(true);
								UIText component3 = transform.GetChild(2).GetComponent<UIText>();
								component3.font = this.tmpFont;
								component3.text = this.DM.mStringTable.GetStringByID(576u);
								transform.GetChild(0).GetComponent<Image>().color = new Color(0.75f, 0.039f, 0.039f);
								this.SPT.GetChild(0).gameObject.SetActive(false);
								this.SPT.GetChild(20).gameObject.SetActive(false);
								this.SPT.GetChild(2).gameObject.SetActive(false);
								this.SPT.GetChild(22).gameObject.SetActive(false);
								this.SPT.GetChild(1).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, 332f);
								this.SPT.GetChild(21).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, 332f);
							}
							else
							{
								transform.GetChild(2).gameObject.SetActive(true);
								UIText component3 = transform.GetChild(2).GetComponent<UIText>();
								component3.font = this.tmpFont;
								component3.text = this.DM.mStringTable.GetStringByID(576u);
								transform.GetChild(0).GetComponent<Image>().color = new Color(0.75f, 0.039f, 0.039f);
								this.SPT.GetChild(0).gameObject.SetActive(false);
								this.SPT.GetChild(20).gameObject.SetActive(false);
								this.SPT.GetChild(1).gameObject.SetActive(false);
								this.SPT.GetChild(21).gameObject.SetActive(false);
								this.SPT.GetChild(2).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, 664f);
								this.SPT.GetChild(22).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, 664f);
							}
						}
					}
					else
					{
						this.RBText2[10].text = this.DM.mStringTable.GetStringByID(9811u);
					}
					this.RBText[7].text = this.DM.mStringTable.GetStringByID(12002u);
					if (this.DM.UserLanguage == GameLanguage.GL_Chs)
					{
						this.SPT.GetChild(4).GetComponent<UISpritesArray>().SetSpriteIndex(1);
					}
					else
					{
						this.SPT.GetChild(4).GetComponent<UISpritesArray>().SetSpriteIndex(0);
					}
					this.SPT.GetChild(9).GetComponent<UIButton>().m_Handler = this;
					this.SPT.GetChild(13).GetComponent<UIButton>().m_Handler = this;
					this.RBText4 = new UIText[(int)this.AM.MatchKingdomCount];
					this.kingdomIDstr = new CString[(int)this.AM.MatchKingdomCount];
					UIButton[] array = new UIButton[(int)(this.AM.MatchKingdomCount - 1)];
					UIButton[] array2 = new UIButton[(int)(this.AM.MatchKingdomCount - 1)];
					array[0] = this.SPT.GetChild(10).GetComponent<UIButton>();
					array[0].m_Handler = this;
					array2[0] = this.SPT.GetChild(14).GetComponent<UIButton>();
					array2[0].m_Handler = this;
					array[1] = this.SPT.GetChild(11).GetComponent<UIButton>();
					array[1].m_Handler = this;
					array2[1] = this.SPT.GetChild(15).GetComponent<UIButton>();
					array2[1].m_Handler = this;
					array[2] = this.SPT.GetChild(12).GetComponent<UIButton>();
					array[2].m_Handler = this;
					array2[2] = this.SPT.GetChild(16).GetComponent<UIButton>();
					array2[2].m_Handler = this;
					this.RBText4[0] = this.SPT.GetChild(13).GetChild(0).GetComponent<UIText>();
					this.RBText4[0].font = this.tmpFont;
					this.kingdomIDstr[0] = instance2.SpawnString(30);
					this.kingdomIDstr[0].IntToFormat((long)DataManager.MapDataController.kingdomData.kingdomID, 1, false);
					if (this.GM.IsArabic)
					{
						this.kingdomIDstr[0].AppendFormat("{0}#");
					}
					else
					{
						this.kingdomIDstr[0].AppendFormat("#{0}");
					}
					this.RBText4[0].text = this.kingdomIDstr[0].ToString();
					RectTransform component4 = this.SPT.GetChild(13).GetComponent<RectTransform>();
					component4.sizeDelta = new Vector2(this.RBText4[0].preferredWidth + 1f, 32f);
					if (this.tmpData.EventState == EActivityState.EAS_Prepare)
					{
						this.SPT.GetChild(12).GetComponent<UIButton>().SetButtonEffectType(e_EffectType.e_Scale);
						this.SPT.GetChild(17).gameObject.SetActive(true);
						this.SPT.GetChild(17).GetComponent<RectTransform>().sizeDelta = new Vector2(21f, 41f);
						this.SPT.GetChild(18).gameObject.SetActive(true);
						this.SPT.GetChild(18).GetComponent<RectTransform>().sizeDelta = new Vector2(21f, 41f);
						this.SPT.GetChild(19).gameObject.SetActive(true);
						this.SPT.GetChild(19).GetComponent<RectTransform>().sizeDelta = new Vector2(21f, 41f);
					}
					else
					{
						byte b = 0;
						for (int m = 1; m < this.AM.MatchKingdomID_4.Length; m++)
						{
							if (this.AM.MatchKingdomID_4[m] != 0)
							{
								this.SPT.GetChild((int)(b + 14)).gameObject.SetActive(true);
								this.RBText4[(int)(b + 1)] = this.SPT.GetChild((int)(b + 14)).GetChild(0).GetComponent<UIText>();
								this.RBText4[(int)(b + 1)].font = this.tmpFont;
								this.kingdomIDstr[(int)(b + 1)] = instance2.SpawnString(30);
								ushort num7 = this.AM.MatchKingdomID_4[m];
								array[(int)b].m_BtnID3 = (int)num7;
								array2[(int)b].m_BtnID3 = (int)num7;
								this.kingdomIDstr[(int)(b + 1)].IntToFormat((long)num7, 1, false);
								if (this.GM.IsArabic)
								{
									this.kingdomIDstr[(int)(b + 1)].AppendFormat("{0}#");
								}
								else
								{
									this.kingdomIDstr[(int)(b + 1)].AppendFormat("#{0}");
								}
								this.RBText4[(int)(b + 1)].text = this.kingdomIDstr[(int)(b + 1)].ToString();
								component4 = this.SPT.GetChild((int)(b + 14)).GetComponent<RectTransform>();
								component4.sizeDelta = new Vector2(this.RBText4[(int)(b + 1)].preferredWidth + 1f, 32f);
								b += 1;
							}
						}
						if (this.AM.MatchKingdomID_4[3] == 0)
						{
							this.SPT.GetChild(23).gameObject.SetActive(true);
							this.RBText4[3] = this.SPT.GetChild(23).GetComponent<UIText>();
							this.RBText4[3].font = this.tmpFont;
							this.RBText4[3].text = this.DM.mStringTable.GetStringByID(12061u);
							Image component5 = this.SPT.GetChild(12).GetComponent<Image>();
							component5.color = new Color(0f, 0f, 0f, 0.6f);
							this.SPT.GetChild(12).GetComponent<UIButton>().interactable = false;
						}
						else
						{
							this.SPT.GetChild(12).GetComponent<UIButton>().SetButtonEffectType(e_EffectType.e_Scale);
						}
					}
					int num8 = 0;
					this.HintT2 = this.m_transform.GetChild(3).GetComponent<RectTransform>();
					this.RBText2[num8] = this.HintT2.GetChild(0).GetComponent<UIText>();
					this.RBText2[num8].font = this.tmpFont;
					this.RBText2[num8].alignment = TextAnchor.UpperLeft;
					this.RBText2[num8].text = this.DM.mStringTable.GetStringByID(9818u);
					float num9 = this.RBText2[num8].preferredHeight + 1f;
					this.RBText2[num8].rectTransform.sizeDelta = new Vector2(this.RBText2[num8].rectTransform.sizeDelta.x, num9);
					this.HintT2.sizeDelta = new Vector2(this.HintT2.sizeDelta.x, num9 + 30f);
					num8++;
					this.kingdomPrizestr = new CString[3];
					UIButtonHint uibuttonHint;
					for (int n = 0; n < 3; n++)
					{
						transform = this.SPT.GetChild(n);
						transform.GetComponent<UIButton>().m_BtnID1 = 4;
						uibuttonHint = transform.GetChild(1).gameObject.AddComponent<UIButtonHint>();
						uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
						uibuttonHint.m_eHint = EUIButtonHint.CountDown;
						uibuttonHint.DelayTime = 0.2f;
						uibuttonHint.m_Handler = this;
						uibuttonHint.Parm1 = 1;
						uibuttonHint.ScrollID = 1;
						this.kingdomPrizestr[n] = instance2.SpawnString(50);
						if (n == 2)
						{
							this.kingdomPrizestr[n].IntToFormat(3L, 1, false);
							this.kingdomPrizestr[n].IntToFormat(4L, 1, false);
							this.kingdomPrizestr[n].AppendFormat(this.DM.mStringTable.GetStringByID(9139u));
						}
						else
						{
							this.kingdomPrizestr[n].IntToFormat((long)(n + 1), 1, false);
							this.kingdomPrizestr[n].AppendFormat(this.DM.mStringTable.GetStringByID(9138u));
						}
						this.RBText2[num8] = transform.GetChild(3).GetComponent<UIText>();
						this.RBText2[num8].font = this.tmpFont;
						this.RBText2[num8].text = this.kingdomPrizestr[n].ToString();
						num8++;
						this.RBText2[num8] = transform.GetChild(4).GetComponent<UIText>();
						this.RBText2[num8].font = this.tmpFont;
						if (n == 2)
						{
							this.RBText2[num8].text = this.DM.mStringTable.GetStringByID(12060u);
						}
						else
						{
							this.RBText2[num8].text = this.DM.mStringTable.GetStringByID((uint)(12008 + n));
						}
						num8++;
						transform = this.SPT.GetChild(n + 20);
						transform.GetComponent<UIButton>().m_BtnID1 = 4;
						uibuttonHint = transform.gameObject.AddComponent<UIButtonHint>();
						uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
						uibuttonHint.m_eHint = EUIButtonHint.CountDown;
						uibuttonHint.DelayTime = 0.2f;
						uibuttonHint.m_Handler = this;
						uibuttonHint.Parm1 = 1;
						uibuttonHint.ScrollID = 1;
						this.RBText2[num8] = transform.GetChild(0).GetComponent<UIText>();
						this.RBText2[num8].font = this.tmpFont;
						this.RBText2[num8].text = this.DM.mStringTable.GetStringByID((uint)(12011 + n));
						((RectTransform)transform).sizeDelta = new Vector2(this.GetBestLineWidth(this.RBText2[num8], 329f, 10) + 1f, ((RectTransform)transform).sizeDelta.y);
						num8++;
					}
					this.ShowRate = this.AM.GetHuntFactor[2][0].BonusRate;
					for (int num10 = 0; num10 < 6; num10++)
					{
						if (this.AM.GetHuntFactor[2][num10].Factor == EGetScoreFactor.EGSF_WonderOccupy)
						{
							this.ShowRate = this.AM.GetHuntFactor[2][num10].BonusRate;
						}
					}
					this.ReTimeImage = this.SPT.GetChild(24).GetComponent<Image>();
					this.ReTimeStr = instance2.SpawnString(30);
					this.ReTimeText = this.SPT.GetChild(25).GetComponent<UIText>();
					this.ReTimeText.font = this.tmpFont;
					this.ReImageDevil = this.SPT.GetChild(26).GetComponent<Image>();
					this.ReImageTarget = this.SPT.GetChild(27).GetComponent<Image>();
					this.ReImageDevilText = this.SPT.GetChild(27).GetChild(0).GetComponent<UIText>();
					this.ReImageDevilText.font = this.tmpFont;
					this.ReImageDevilStr = instance2.SpawnString(30);
					this.ReImageDevilStr.IntToFormat((long)this.ShowRate, 1, false);
					if (this.GM.IsArabic)
					{
						this.ReImageDevilStr.AppendFormat("{0}x");
					}
					else
					{
						this.ReImageDevilStr.AppendFormat("x{0}");
					}
					this.ReImageDevilText.text = this.ReImageDevilStr.ToString();
					this.KVKLine1 = this.SPT.GetChild(28).gameObject;
					this.KVKLine2 = this.SPT.GetChild(29).gameObject;
					this.SetKVKReTime();
					this.SetReLineAndPic();
					uibuttonHint = this.ReTimeImage.gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(2).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.3f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 5;
					uibuttonHint.Parm2 = 1;
					uibuttonHint.ScrollID = 1;
					uibuttonHint = this.ReTimeText.gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(2).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.3f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 5;
					uibuttonHint.Parm2 = 1;
					uibuttonHint.ScrollID = 1;
					uibuttonHint = this.ReImageDevil.gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(2).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.3f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 5;
					uibuttonHint.Parm2 = 2;
					uibuttonHint.ScrollID = 1;
					uibuttonHint = this.ReImageTarget.gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(2).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.3f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 5;
					uibuttonHint.Parm2 = 3;
					uibuttonHint.ScrollID = 1;
					this.HintT3 = this.m_transform.GetChild(6).GetComponent<RectTransform>();
					this.HintT3.anchoredPosition = new Vector2(23.5f, 60f);
					this.HintT3Text = this.HintT3.GetChild(0).GetComponent<UIText>();
					this.HintT3Text.font = this.tmpFont;
					this.HintT3Text.alignment = TextAnchor.UpperLeft;
					this.HintT3Str = instance2.SpawnString(300);
					this.LoadFIFA();
				}
				else if (this.AM.MatchKingdomCount == 3)
				{
					this.RBText4 = new UIText[(int)this.AM.MatchKingdomCount];
					this.LoadSP("CT_MatchKVK_3");
					this.SPT.GetChild(4).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(5).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(6).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(7).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(8).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(9).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(10).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(14).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(15).gameObject.AddComponent<ArabicItemTextureRot>();
					if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
					{
						this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 605f);
					}
					else
					{
						this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 917f);
					}
					this.SPT.gameObject.SetActive(true);
					this.Main2T.GetChild(11).gameObject.SetActive(true);
					this.RBText2[6] = this.Main2T.GetChild(11).GetComponent<UIText>();
					this.RBText2[6].font = this.tmpFont;
					if (this.tmpData.EventState == EActivityState.EAS_Prepare)
					{
						this.RBText2[6].text = this.DM.mStringTable.GetStringByID(9809u);
					}
					else if (this.tmpData.EventState == EActivityState.EAS_Run)
					{
						this.RBText2[6].text = this.DM.mStringTable.GetStringByID(9805u);
						this.Main2T.GetChild(21).gameObject.SetActive(true);
					}
					else if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
					{
						this.Main2T.GetChild(20).gameObject.SetActive(true);
						this.Main2T.GetChild(20).GetComponent<RectTransform>().anchoredPosition += new Vector2(75f, 0f);
						this.RBText2[6].gameObject.SetActive(false);
						this.Main2T.GetChild(11).gameObject.SetActive(false);
						this.Main2T.GetChild(25).gameObject.SetActive(true);
						transform = this.Main2T.GetChild(25);
						long num11 = (long)this.AM.KingdomKvKRank;
						if (num11 < 34L)
						{
							transform.GetChild(1).gameObject.SetActive(true);
							UIText component3 = transform.GetChild(1).GetComponent<UIText>();
							component3.font = this.tmpFont;
							component3.text = this.DM.mStringTable.GetStringByID(574u);
							this.SPT.GetChild(1).gameObject.SetActive(false);
							this.SPT.GetChild(17).gameObject.SetActive(false);
						}
						else
						{
							transform.GetChild(2).gameObject.SetActive(true);
							UIText component3 = transform.GetChild(2).GetComponent<UIText>();
							component3.font = this.tmpFont;
							component3.text = this.DM.mStringTable.GetStringByID(576u);
							transform.GetChild(0).GetComponent<Image>().color = new Color(0.75f, 0.039f, 0.039f);
							this.SPT.GetChild(0).gameObject.SetActive(false);
							this.SPT.GetChild(16).gameObject.SetActive(false);
							this.SPT.GetChild(1).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, 332f);
							this.SPT.GetChild(17).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, 332f);
						}
					}
					else
					{
						this.RBText2[6].text = this.DM.mStringTable.GetStringByID(9811u);
					}
					this.RBText[7].text = this.DM.mStringTable.GetStringByID(12002u);
					if (this.DM.UserLanguage == GameLanguage.GL_Chs)
					{
						this.SPT.GetChild(4).GetComponent<UISpritesArray>().SetSpriteIndex(1);
					}
					else
					{
						this.SPT.GetChild(4).GetComponent<UISpritesArray>().SetSpriteIndex(0);
					}
					this.SPT.GetChild(8).GetComponent<UIButton>().m_Handler = this;
					this.SPT.GetChild(11).GetComponent<UIButton>().m_Handler = this;
					UIButton[] array3 = new UIButton[(int)(this.AM.MatchKingdomCount - 1)];
					UIButton[] array4 = new UIButton[(int)(this.AM.MatchKingdomCount - 1)];
					array3[0] = this.SPT.GetChild(9).GetComponent<UIButton>();
					array3[0].m_Handler = this;
					array4[0] = this.SPT.GetChild(12).GetComponent<UIButton>();
					array4[0].m_Handler = this;
					array3[1] = this.SPT.GetChild(10).GetComponent<UIButton>();
					array3[1].m_Handler = this;
					array4[1] = this.SPT.GetChild(13).GetComponent<UIButton>();
					array4[1].m_Handler = this;
					KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.kingdomData.kingdomID);
					this.SPT.GetChild(8).GetComponent<UISpritesArray>().SetSpriteIndex((int)(recordByKey.mapID - 1));
					this.kingdomIDstr = new CString[(int)this.AM.MatchKingdomCount];
					this.RBText4[0] = this.SPT.GetChild(11).GetChild(0).GetComponent<UIText>();
					this.RBText4[0].font = this.tmpFont;
					this.kingdomIDstr[0] = instance2.SpawnString(30);
					this.kingdomIDstr[0].IntToFormat((long)DataManager.MapDataController.kingdomData.kingdomID, 1, false);
					if (this.GM.IsArabic)
					{
						this.kingdomIDstr[0].AppendFormat("{0}#");
					}
					else
					{
						this.kingdomIDstr[0].AppendFormat("#{0}");
					}
					this.RBText4[0].text = this.kingdomIDstr[0].ToString();
					RectTransform component6 = this.SPT.GetChild(11).GetComponent<RectTransform>();
					component6.sizeDelta = new Vector2(this.RBText4[0].preferredWidth + 1f, 32f);
					if (this.tmpData.EventState == EActivityState.EAS_Prepare)
					{
						this.SPT.GetChild(10).GetComponent<UIButton>().SetButtonEffectType(e_EffectType.e_Scale);
						this.SPT.GetChild(14).gameObject.SetActive(true);
						this.SPT.GetChild(15).gameObject.SetActive(true);
					}
					else
					{
						byte b2 = 0;
						int num12 = 0;
						while (num12 < (int)this.AM.MatchKingdomIDCount && num12 < this.AM.MatchKingdomID.Length && num12 < (int)this.AM.MatchKingdomCount)
						{
							if (this.AM.MatchKingdomID[num12] != 0 && this.AM.MatchKingdomID[num12] != DataManager.MapDataController.kingdomData.kingdomID)
							{
								this.SPT.GetChild((int)(b2 + 12)).gameObject.SetActive(true);
								this.RBText4[(int)(b2 + 1)] = this.SPT.GetChild((int)(b2 + 12)).GetChild(0).GetComponent<UIText>();
								this.RBText4[(int)(b2 + 1)].font = this.tmpFont;
								this.kingdomIDstr[(int)(b2 + 1)] = instance2.SpawnString(30);
								ushort num13 = this.AM.MatchKingdomID[num12];
								array3[(int)b2].m_BtnID3 = (int)num13;
								array4[(int)b2].m_BtnID3 = (int)num13;
								this.kingdomIDstr[(int)(b2 + 1)].IntToFormat((long)num13, 1, false);
								if (this.GM.IsArabic)
								{
									this.kingdomIDstr[(int)(b2 + 1)].AppendFormat("{0}#");
								}
								else
								{
									this.kingdomIDstr[(int)(b2 + 1)].AppendFormat("#{0}");
								}
								this.RBText4[(int)(b2 + 1)].text = this.kingdomIDstr[(int)(b2 + 1)].ToString();
								component6 = this.SPT.GetChild((int)(b2 + 12)).GetComponent<RectTransform>();
								component6.sizeDelta = new Vector2(this.RBText4[(int)(b2 + 1)].preferredWidth + 1f, 32f);
								b2 += 1;
							}
							num12++;
						}
						if (b2 + 1 < this.AM.MatchKingdomCount)
						{
							this.SPT.GetChild(18).gameObject.SetActive(true);
							this.RBText4[2] = this.SPT.GetChild(18).GetComponent<UIText>();
							this.RBText4[2].font = this.tmpFont;
							this.RBText4[2].text = this.DM.mStringTable.GetStringByID(12061u);
							Image component7 = this.SPT.GetChild(10).GetComponent<Image>();
							component7.color = new Color(0f, 0f, 0f, 0.6f);
							this.SPT.GetChild(10).GetComponent<UIButton>().interactable = false;
						}
						else
						{
							this.SPT.GetChild(10).GetComponent<UIButton>().SetButtonEffectType(e_EffectType.e_Scale);
						}
					}
					transform = this.SPT.GetChild(0);
					transform.GetComponent<UIButton>().m_BtnID1 = 4;
					UIButtonHint uibuttonHint = transform.GetChild(1).gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.2f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 1;
					uibuttonHint.ScrollID = 1;
					this.RBText2[0] = transform.GetChild(3).GetComponent<UIText>();
					this.RBText2[0].font = this.tmpFont;
					this.RBText2[0].text = this.DM.mStringTable.GetStringByID(12003u);
					this.RBText2[1] = transform.GetChild(4).GetComponent<UIText>();
					this.RBText2[1].font = this.tmpFont;
					this.RBText2[1].text = this.DM.mStringTable.GetStringByID(12008u);
					transform = this.SPT.GetChild(16);
					transform.GetComponent<UIButton>().m_BtnID1 = 4;
					uibuttonHint = transform.gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.2f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 1;
					uibuttonHint.ScrollID = 1;
					this.RBText2[2] = transform.GetChild(0).GetComponent<UIText>();
					this.RBText2[2].font = this.tmpFont;
					this.RBText2[2].text = this.DM.mStringTable.GetStringByID(12011u);
					((RectTransform)transform).sizeDelta = new Vector2(this.GetBestLineWidth(this.RBText2[2], 329f, 10) + 1f, ((RectTransform)transform).sizeDelta.y);
					transform = this.SPT.GetChild(1);
					transform.GetComponent<UIButton>().m_BtnID1 = 4;
					uibuttonHint = transform.GetChild(1).gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.2f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 1;
					uibuttonHint.ScrollID = 1;
					this.RBText2[3] = transform.GetChild(3).GetComponent<UIText>();
					this.RBText2[3].font = this.tmpFont;
					this.RBText2[3].text = this.DM.mStringTable.GetStringByID(12059u);
					this.RBText2[4] = transform.GetChild(4).GetComponent<UIText>();
					this.RBText2[4].font = this.tmpFont;
					this.RBText2[4].text = this.DM.mStringTable.GetStringByID(12060u);
					transform = this.SPT.GetChild(17);
					transform.GetComponent<UIButton>().m_BtnID1 = 4;
					uibuttonHint = transform.gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.2f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 1;
					uibuttonHint.ScrollID = 1;
					this.RBText2[5] = transform.GetChild(0).GetComponent<UIText>();
					this.RBText2[5].font = this.tmpFont;
					this.RBText2[5].text = this.DM.mStringTable.GetStringByID(12013u);
					((RectTransform)transform).sizeDelta = new Vector2(this.GetBestLineWidth(this.RBText2[5], 329f, 10) + 1f, ((RectTransform)transform).sizeDelta.y);
					this.HintT2 = this.m_transform.GetChild(3).GetComponent<RectTransform>();
					this.RBText2[10] = this.HintT2.GetChild(0).GetComponent<UIText>();
					this.RBText2[10].font = this.tmpFont;
					this.RBText2[10].alignment = TextAnchor.UpperLeft;
					this.RBText2[10].text = this.DM.mStringTable.GetStringByID(9818u);
					float num14 = this.RBText2[10].preferredHeight + 1f;
					this.RBText2[10].rectTransform.sizeDelta = new Vector2(this.RBText2[10].rectTransform.sizeDelta.x, num14);
					this.HintT2.sizeDelta = new Vector2(this.HintT2.sizeDelta.x, num14 + 30f);
					this.LoadFIFA();
				}
				else
				{
					this.RBText4 = new UIText[2];
					this.LoadSP("CT_MatchKVK_2");
					this.SPT.GetChild(4).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(5).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(6).gameObject.AddComponent<ArabicItemTextureRot>();
					this.SPT.GetChild(9).gameObject.AddComponent<ArabicItemTextureRot>();
					if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
					{
						this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 565f);
					}
					else
					{
						this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 877f);
					}
					this.SPT.gameObject.SetActive(true);
					this.Main2T.GetChild(11).gameObject.SetActive(true);
					this.RBText2[6] = this.Main2T.GetChild(11).GetComponent<UIText>();
					this.RBText2[6].font = this.tmpFont;
					if (this.tmpData.EventState == EActivityState.EAS_Prepare)
					{
						this.RBText2[6].text = this.DM.mStringTable.GetStringByID(9809u);
					}
					else if (this.tmpData.EventState == EActivityState.EAS_Run)
					{
						this.RBText2[6].text = this.DM.mStringTable.GetStringByID(9805u);
						this.Main2T.GetChild(21).gameObject.SetActive(true);
					}
					else if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
					{
						this.Main2T.GetChild(20).gameObject.SetActive(true);
						this.Main2T.GetChild(20).GetComponent<RectTransform>().anchoredPosition += new Vector2(75f, 0f);
						this.RBText2[6].gameObject.SetActive(false);
						this.Main2T.GetChild(11).gameObject.SetActive(false);
						this.Main2T.GetChild(25).gameObject.SetActive(true);
						transform = this.Main2T.GetChild(25);
						long num15 = (long)this.AM.KingdomKvKRank;
						if (num15 < 49L)
						{
							transform.GetChild(1).gameObject.SetActive(true);
							UIText component3 = transform.GetChild(1).GetComponent<UIText>();
							component3.font = this.tmpFont;
							component3.text = this.DM.mStringTable.GetStringByID(574u);
							this.SPT.GetChild(1).gameObject.SetActive(false);
							this.SPT.GetChild(11).gameObject.SetActive(false);
						}
						else
						{
							transform.GetChild(2).gameObject.SetActive(true);
							UIText component3 = transform.GetChild(2).GetComponent<UIText>();
							component3.font = this.tmpFont;
							component3.text = this.DM.mStringTable.GetStringByID(576u);
							transform.GetChild(0).GetComponent<Image>().color = new Color(0.75f, 0.039f, 0.039f);
							this.SPT.GetChild(0).gameObject.SetActive(false);
							this.SPT.GetChild(10).gameObject.SetActive(false);
							this.SPT.GetChild(1).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, 332f);
							this.SPT.GetChild(11).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, 332f);
						}
					}
					else
					{
						this.RBText2[6].text = this.DM.mStringTable.GetStringByID(9811u);
					}
					this.RBText[7].text = this.DM.mStringTable.GetStringByID(12002u);
					if (this.DM.UserLanguage == GameLanguage.GL_Chs)
					{
						this.SPT.GetChild(6).GetComponent<UISpritesArray>().SetSpriteIndex(1);
					}
					else
					{
						this.SPT.GetChild(6).GetComponent<UISpritesArray>().SetSpriteIndex(0);
					}
					this.SPT.GetChild(4).GetComponent<UIButton>().m_Handler = this;
					this.SPT.GetChild(7).GetComponent<UIButton>().m_Handler = this;
					UIButton component8 = this.SPT.GetChild(5).GetComponent<UIButton>();
					component8.m_Handler = this;
					UIButton component9 = this.SPT.GetChild(8).GetComponent<UIButton>();
					component9.m_Handler = this;
					KingdomMap recordByKey2 = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.kingdomData.kingdomID);
					this.SPT.GetChild(4).GetComponent<UISpritesArray>().SetSpriteIndex((int)(recordByKey2.mapID - 1));
					this.kingdomIDstr = new CString[2];
					this.RBText4[0] = this.SPT.GetChild(7).GetChild(0).GetComponent<UIText>();
					this.RBText4[0].font = this.tmpFont;
					this.kingdomIDstr[0] = instance2.SpawnString(30);
					this.kingdomIDstr[0].IntToFormat((long)DataManager.MapDataController.kingdomData.kingdomID, 1, false);
					if (this.GM.IsArabic)
					{
						this.kingdomIDstr[0].AppendFormat("{0}#");
					}
					else
					{
						this.kingdomIDstr[0].AppendFormat("#{0}");
					}
					this.RBText4[0].text = this.kingdomIDstr[0].ToString();
					RectTransform component10 = this.SPT.GetChild(7).GetComponent<RectTransform>();
					component10.sizeDelta = new Vector2(this.RBText4[0].preferredWidth + 1f, 32f);
					if (this.tmpData.EventState == EActivityState.EAS_Prepare)
					{
						this.SPT.GetChild(9).gameObject.SetActive(true);
					}
					else
					{
						this.SPT.GetChild(8).gameObject.SetActive(true);
						this.RBText4[1] = this.SPT.GetChild(8).GetChild(0).GetComponent<UIText>();
						this.RBText4[1].font = this.tmpFont;
						this.kingdomIDstr[1] = instance2.SpawnString(30);
						ushort num16 = 0;
						int num17 = 0;
						while (num17 < (int)this.AM.MatchKingdomIDCount && num17 < this.AM.MatchKingdomID.Length)
						{
							if (this.AM.MatchKingdomID[num17] != 0 && this.AM.MatchKingdomID[num17] != DataManager.MapDataController.kingdomData.kingdomID)
							{
								num16 = this.AM.MatchKingdomID[num17];
								break;
							}
							num17++;
						}
						component8.m_BtnID3 = (int)num16;
						component9.m_BtnID3 = (int)num16;
						this.kingdomIDstr[1].IntToFormat((long)num16, 1, false);
						if (this.GM.IsArabic)
						{
							this.kingdomIDstr[1].AppendFormat("{0}#");
						}
						else
						{
							this.kingdomIDstr[1].AppendFormat("#{0}");
						}
						this.RBText4[1].text = this.kingdomIDstr[1].ToString();
						component10 = this.SPT.GetChild(8).GetComponent<RectTransform>();
						component10.sizeDelta = new Vector2(this.RBText4[1].preferredWidth + 1f, 32f);
					}
					transform = this.SPT.GetChild(0);
					transform.GetComponent<UIButton>().m_BtnID1 = 4;
					UIButtonHint uibuttonHint = transform.GetChild(1).gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.2f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 1;
					uibuttonHint.ScrollID = 1;
					this.RBText2[0] = transform.GetChild(3).GetComponent<UIText>();
					this.RBText2[0].font = this.tmpFont;
					this.RBText2[0].text = this.DM.mStringTable.GetStringByID(12003u);
					this.RBText2[1] = transform.GetChild(4).GetComponent<UIText>();
					this.RBText2[1].font = this.tmpFont;
					this.RBText2[1].text = this.DM.mStringTable.GetStringByID(12008u);
					transform = this.SPT.GetChild(10);
					transform.GetComponent<UIButton>().m_BtnID1 = 4;
					uibuttonHint = transform.gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.2f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 1;
					uibuttonHint.ScrollID = 1;
					this.RBText2[2] = transform.GetChild(0).GetComponent<UIText>();
					this.RBText2[2].font = this.tmpFont;
					this.RBText2[2].text = this.DM.mStringTable.GetStringByID(12011u);
					((RectTransform)transform).sizeDelta = new Vector2(this.GetBestLineWidth(this.RBText2[2], 329f, 10) + 1f, ((RectTransform)transform).sizeDelta.y);
					transform = this.SPT.GetChild(1);
					transform.GetComponent<UIButton>().m_BtnID1 = 4;
					uibuttonHint = transform.GetChild(1).gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.2f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 1;
					uibuttonHint.ScrollID = 1;
					this.RBText2[3] = transform.GetChild(3).GetComponent<UIText>();
					this.RBText2[3].font = this.tmpFont;
					this.RBText2[3].text = this.DM.mStringTable.GetStringByID(12059u);
					this.RBText2[4] = transform.GetChild(4).GetComponent<UIText>();
					this.RBText2[4].font = this.tmpFont;
					this.RBText2[4].text = this.DM.mStringTable.GetStringByID(12060u);
					transform = this.SPT.GetChild(11);
					transform.GetComponent<UIButton>().m_BtnID1 = 4;
					uibuttonHint = transform.gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.2f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 1;
					uibuttonHint.ScrollID = 1;
					this.RBText2[5] = transform.GetChild(0).GetComponent<UIText>();
					this.RBText2[5].font = this.tmpFont;
					this.RBText2[5].text = this.DM.mStringTable.GetStringByID(12013u);
					((RectTransform)transform).sizeDelta = new Vector2(this.GetBestLineWidth(this.RBText2[5], 329f, 10) + 1f, ((RectTransform)transform).sizeDelta.y);
					this.HintT2 = this.m_transform.GetChild(3).GetComponent<RectTransform>();
					this.RBText2[10] = this.HintT2.GetChild(0).GetComponent<UIText>();
					this.RBText2[10].font = this.tmpFont;
					this.RBText2[10].alignment = TextAnchor.UpperLeft;
					this.RBText2[10].text = this.DM.mStringTable.GetStringByID(9818u);
					float num18 = this.RBText2[10].preferredHeight + 1f;
					this.RBText2[10].rectTransform.sizeDelta = new Vector2(this.RBText2[10].rectTransform.sizeDelta.x, num18);
					this.HintT2.sizeDelta = new Vector2(this.HintT2.sizeDelta.x, num18 + 30f);
					this.LoadFIFA();
				}
			}
			else
			{
				this.LoadSP("CT_WorldObject");
				if (this.tmpData.EventState != EActivityState.EAS_ReplayRanking)
				{
					this.Main2T.GetChild(20).gameObject.SetActive(false);
				}
				else
				{
					this.Main2T.GetChild(20).gameObject.SetActive(true);
					this.Main2T.GetChild(20).GetComponent<RectTransform>().anchoredPosition += new Vector2(75f, 0f);
				}
				this.SPT.gameObject.SetActive(true);
				this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 1017f);
				int num19 = 0;
				this.HintT2 = this.m_transform.GetChild(3).GetComponent<RectTransform>();
				this.RBText2[num19] = this.HintT2.GetChild(0).GetComponent<UIText>();
				this.RBText2[num19].font = this.tmpFont;
				this.RBText2[num19].alignment = TextAnchor.UpperLeft;
				this.RBText2[num19].text = this.DM.mStringTable.GetStringByID(9818u);
				float num20 = this.RBText2[num19].preferredHeight + 1f;
				this.RBText2[num19].rectTransform.sizeDelta = new Vector2(this.RBText2[num19].rectTransform.sizeDelta.x, num20);
				this.HintT2.sizeDelta = new Vector2(this.HintT2.sizeDelta.x, num20 + 30f);
				num19++;
				for (int num21 = 0; num21 < 3; num21++)
				{
					if (this.tmpData.EventState != EActivityState.EAS_ReplayRanking)
					{
						this.SPT.GetChild(num21).gameObject.SetActive(true);
						this.SPT.GetChild(num21 + 3).gameObject.SetActive(true);
					}
					transform = this.SPT.GetChild(num21);
					transform.GetComponent<UIButton>().m_BtnID1 = 4;
					UIButtonHint uibuttonHint = transform.GetChild(1).gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.2f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 1;
					uibuttonHint.ScrollID = 1;
					this.RBText2[num19] = transform.GetChild(3).GetComponent<UIText>();
					this.RBText2[num19].font = this.tmpFont;
					this.RBText2[num19].text = this.DM.mStringTable.GetStringByID((uint)(9812 + num21));
					num19++;
					this.RBText2[num19] = transform.GetChild(4).GetComponent<UIText>();
					this.RBText2[num19].font = this.tmpFont;
					this.RBText2[num19].text = this.DM.mStringTable.GetStringByID((uint)(12008 + num21));
					num19++;
					transform = this.SPT.GetChild(num21 + 3);
					transform.GetComponent<UIButton>().m_BtnID1 = 4;
					uibuttonHint = transform.gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.2f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 1;
					uibuttonHint.ScrollID = 1;
					this.RBText2[num19] = transform.GetChild(0).GetComponent<UIText>();
					this.RBText2[num19].font = this.tmpFont;
					this.RBText2[num19].text = this.DM.mStringTable.GetStringByID((uint)(12011 + num21));
					((RectTransform)transform).sizeDelta = new Vector2(this.GetBestLineWidth(this.RBText2[num19], 329f, 10) + 1f, ((RectTransform)transform).sizeDelta.y);
					num19++;
				}
				this.Main2T.GetChild(11).gameObject.SetActive(true);
				this.RBText2[num19] = this.Main2T.GetChild(11).GetComponent<UIText>();
				this.RBText2[num19].font = this.tmpFont;
				if (this.tmpData.EventState == EActivityState.EAS_Prepare)
				{
					this.RBText2[num19].text = this.DM.mStringTable.GetStringByID(9809u);
				}
				else if (this.tmpData.EventState == EActivityState.EAS_Run)
				{
					this.RBText2[num19].text = this.DM.mStringTable.GetStringByID(9805u);
					this.Main2T.GetChild(21).gameObject.SetActive(true);
				}
				else if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
				{
					long num22 = (long)this.AM.KingdomKvKRank;
					this.RankStr = instance2.SpawnString(200);
					this.RankStr.Length = 0;
					this.RankStr.IntToFormat(num22, 1, false);
					this.RankStr.AppendFormat(this.DM.mStringTable.GetStringByID(9820u));
					this.RBText2[num19].text = this.RankStr.ToString();
					this.RBText2[num19].SetAllDirty();
					this.RBText2[num19].cachedTextGenerator.Invalidate();
					this.RBText2[num19].cachedTextGeneratorForLayout.Invalidate();
					this.RBText2[num19].rectTransform.anchoredPosition = new Vector2(0f, this.RBText2[num19].rectTransform.anchoredPosition.y);
					this.RBText2[num19].alignment = TextAnchor.MiddleCenter;
					int num23 = 2;
					if (num22 <= 25L)
					{
						num23 = 0;
					}
					else if (num22 > 25L && num22 <= 50L)
					{
						num23 = 1;
					}
					RectTransform rectTransform = (RectTransform)this.SPT.GetChild(num23);
					rectTransform.gameObject.SetActive(true);
					rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -11f);
					this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, rectTransform.sizeDelta.y);
					rectTransform = (RectTransform)this.SPT.GetChild(num23 + 3);
					rectTransform.gameObject.SetActive(true);
					if (num23 == 1)
					{
						rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 197.3f);
					}
					else if (num23 == 2)
					{
						rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 214.8f);
					}
				}
				else
				{
					this.RBText2[num19].text = this.DM.mStringTable.GetStringByID(9811u);
				}
			}
			this.TimeSA = this.Main2T.GetChild(23).GetComponent<UISpritesArray>();
			this.TimeTitle = this.Main2T.GetChild(23).GetChild(0).GetComponent<UIText>();
			this.TimeTitle.font = this.tmpFont;
			this.TimeText = this.Main2T.GetChild(23).GetChild(1).GetComponent<UIText>();
			this.TimeText.font = this.tmpFont;
			this.TimeTitle2 = this.Main2T.GetChild(23).GetChild(2).GetComponent<UIText>();
			this.TimeTitle2.font = this.tmpFont;
			this.TimeTitle2.enabled = false;
			this.TimeTitle2.gameObject.SetActive(true);
			this.TimeStr = instance2.SpawnString(30);
			this.SetTimeTitle();
			this.SetTimeStr();
		}
		else if (this.tmpData.ActiveType == EActivityType.EAT_FIFA && this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_KingdomEvent)
		{
			this.LoadSP("CT_FIFA");
			this.bFIFA = true;
			this.RBText[4].enabled = false;
			this.RBText[5].enabled = false;
			this.NowScoreText.enabled = false;
			this.NextScoreText.enabled = false;
			this.Main2T.GetChild(5).gameObject.SetActive(false);
			this.Main2T.GetChild(19).gameObject.SetActive(false);
			this.Main2T.GetChild(20).gameObject.SetActive(false);
			this.ContentT.GetChild(0).gameObject.SetActive(false);
			this.ContentT.GetChild(1).gameObject.SetActive(false);
			this.ContentT.GetChild(2).gameObject.SetActive(false);
			this.RBText4 = new UIText[7];
			this.RBText4[0] = this.Main2T.GetChild(33).GetComponent<UIText>();
			this.RBText4[0].font = this.tmpFont;
			this.RBText4[0].gameObject.SetActive(true);
			if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
			{
				this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 565f);
				this.SPT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 565f);
				this.SetFIFATopText();
				this.Main2T.GetChild(20).gameObject.SetActive(true);
				this.Main2T.GetChild(20).GetComponent<RectTransform>().anchoredPosition += new Vector2(75f, 0f);
				if (this.LightImage == null)
				{
					this.LightImage = new Image[2];
					this.LightImage[0] = this.SPT.GetChild(1).GetChild(0).GetComponent<Image>();
					this.LightImage[1] = this.SPT.GetChild(1).GetChild(1).GetComponent<Image>();
				}
				this.RBText4[3] = this.SPT.GetChild(1).GetChild(2).GetChild(0).GetComponent<UIText>();
				this.RBText4[3].font = this.tmpFont;
				this.RBText4[3].text = this.DM.mStringTable.GetStringByID(12219u);
				this.GM.InitBadgeTotem(this.SPT.GetChild(1).GetChild(3).GetChild(0), this.AM.FIFA_AllianceEmblem);
				if (this.WaveStr[0] == null)
				{
					this.WaveStr[0] = StringManager.Instance.SpawnString(30);
					this.WaveStr[1] = StringManager.Instance.SpawnString(30);
				}
				UIButton component11 = this.SPT.GetChild(1).GetChild(6).GetComponent<UIButton>();
				component11.m_Handler = this;
				component11.m_BtnID1 = 7;
				component11.m_BtnID2 = 1;
				this.RBText4[4] = this.SPT.GetChild(1).GetChild(6).GetChild(0).GetComponent<UIText>();
				this.RBText4[4].font = this.tmpFont;
				this.RBText4[4].resizeTextMaxSize = 21;
				if (this.AM.FIFA_AllianceEmblem == 0)
				{
					if (this.AM.FIFA_bGetChampion)
					{
						this.WaveStr[0].Append(this.DM.mStringTable.GetStringByID(12061u));
					}
					else
					{
						this.WaveStr[0].Length = 0;
					}
					component11.interactable = false;
					this.SPT.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(false);
					this.SPT.GetChild(1).GetChild(6).GetChild(1).GetComponent<Image>().enabled = false;
				}
				else
				{
					this.WaveStr[0].StringToFormat(this.AM.FIFA_AllianceTag);
					this.WaveStr[0].StringToFormat(this.AM.FIFA_AllianceName);
					this.WaveStr[0].AppendFormat("[{0}]{1}");
				}
				this.RBText4[4].text = this.WaveStr[0].ToString();
				this.RBText4[4].SetAllDirty();
				this.RBText4[4].cachedTextGenerator.Invalidate();
				this.RBText4[4].cachedTextGeneratorForLayout.Invalidate();
				this.SPT.GetChild(1).GetChild(6).GetComponent<RectTransform>().sizeDelta = new Vector2(this.RBText4[4].preferredWidth + 1f, 43.5f);
				this.RBText4[5] = this.SPT.GetChild(1).GetChild(7).GetChild(0).GetComponent<UIText>();
				this.RBText4[5].font = this.tmpFont;
				this.RBText4[5].text = this.DM.mStringTable.GetStringByID(12220u);
				this.GM.InitianHeroItemImg(this.SPT.GetChild(1).GetChild(8), eHeroOrItem.Hero, this.AM.FIFA_PlayerHead, 11, 0, 0, false, false, true, false);
				component11 = this.SPT.GetChild(1).GetChild(11).GetComponent<UIButton>();
				component11.m_Handler = this;
				component11.m_BtnID1 = 7;
				component11.m_BtnID2 = 2;
				this.RBText4[6] = this.SPT.GetChild(1).GetChild(11).GetChild(0).GetComponent<UIText>();
				this.RBText4[6].font = this.tmpFont;
				this.RBText4[6].resizeTextMaxSize = 21;
				if (this.AM.FIFA_PlayerHead == 0)
				{
					if (this.AM.FIFA_bGetChampion)
					{
						this.WaveStr[1].Append(this.DM.mStringTable.GetStringByID(12061u));
					}
					else
					{
						this.WaveStr[1].Length = 0;
					}
					component11.interactable = false;
					this.SPT.GetChild(1).GetChild(8).gameObject.SetActive(false);
					this.SPT.GetChild(1).GetChild(12).gameObject.SetActive(true);
					this.SPT.GetChild(1).GetChild(11).GetChild(1).GetComponent<Image>().enabled = false;
				}
				else
				{
					GameConstants.FormatRoleName(this.WaveStr[1], this.AM.FIFA_PlayerName, this.AM.FIFA_PlayerAllianceTag, null, 0, 0, null, null, null, null);
				}
				this.RBText4[6].text = this.WaveStr[1].ToString();
				this.RBText4[6].SetAllDirty();
				this.RBText4[6].cachedTextGenerator.Invalidate();
				this.RBText4[6].cachedTextGeneratorForLayout.Invalidate();
				this.SPT.GetChild(1).GetChild(11).GetComponent<RectTransform>().sizeDelta = new Vector2(this.RBText4[6].preferredWidth + 1f, 43.5f);
				this.SPT.GetChild(1).gameObject.SetActive(true);
			}
			else
			{
				this.AM.Act2Pos = Vector2.zero;
				this.ContentT.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
				this.Main2T.GetChild(22).GetComponent<CScrollRect>().enabled = false;
				this.Main2T.GetChild(22).GetComponent<Mask>().enabled = false;
				this.Main2T.GetChild(22).GetComponent<Image>().enabled = false;
				this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 370f);
				this.SPT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 370f);
				this.FIFASP = this.SPT.GetChild(0).GetComponent<UISpritesArray>();
				this.SetFIFATopText();
				if (this.Npc_Node == null)
				{
					this.Npc_Parent = new Transform[4];
					this.Npc_Node = new UINPC[4];
					this.Npc_ABKey = new int[4];
				}
				for (int num24 = 0; num24 < 4; num24++)
				{
					transform = this.SPT.GetChild(0).GetChild(num24);
					transform.GetComponent<UIButton>().m_BtnID1 = 0;
					transform.GetComponent<UIButton>().m_Handler = this;
					UIButtonHint uibuttonHint = transform.gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.CountDown;
					uibuttonHint.DelayTime = 0.3f;
					uibuttonHint.m_Handler = this;
					uibuttonHint.Parm1 = 6;
					uibuttonHint.Parm2 = (byte)(num24 + 1);
					uibuttonHint.ScrollID = 1;
					this.Npc_Parent[num24] = transform;
					this.Npc_Node[num24] = new UINPC();
					this.Npc_Node[num24].SpawnNPC(Vector2.zero, 1f, 1, 210, UINPCState.UINPC_Idle, this.Npc_Parent[num24], ref this.Npc_ABKey[num24]);
				}
				for (int num25 = 0; num25 < 3; num25++)
				{
					this.ArrowImage[num25] = this.SPT.GetChild(0).GetChild(num25 + 4).GetComponent<Image>();
				}
				this.WaveText[0] = this.SPT.GetChild(0).GetChild(7).GetComponent<UIText>();
				this.WaveText[0].font = this.tmpFont;
				this.WaveText[1] = this.SPT.GetChild(0).GetChild(8).GetComponent<UIText>();
				this.WaveText[1].font = this.tmpFont;
				this.CheckNowWave(true);
				this.SPT.GetChild(0).gameObject.SetActive(true);
			}
			this.HintTFIFA = this.m_transform.GetChild(9).GetComponent<RectTransform>();
			this.WaveText[4] = this.HintTFIFA.GetChild(0).GetComponent<UIText>();
			this.WaveText[4].font = this.tmpFont;
			this.WaveText[4].alignment = TextAnchor.UpperLeft;
			this.TimeSA = this.Main2T.GetChild(23).GetComponent<UISpritesArray>();
			this.TimeTitle = this.Main2T.GetChild(23).GetChild(0).GetComponent<UIText>();
			this.TimeTitle.font = this.tmpFont;
			this.TimeText = this.Main2T.GetChild(23).GetChild(1).GetComponent<UIText>();
			this.TimeText.font = this.tmpFont;
			this.TimeTitle2 = this.Main2T.GetChild(23).GetChild(2).GetComponent<UIText>();
			this.TimeTitle2.font = this.tmpFont;
			this.TimeTitle2.enabled = false;
			this.TimeTitle2.gameObject.SetActive(true);
			this.TimeStr = instance2.SpawnString(30);
			this.SetTimeTitle();
			this.SetTimeStr();
		}
		else if (this.tmpData.ActiveType == EActivityType.EAT_KingOfTheWorld)
		{
			this.LoadSP("CT_KOWObject");
			this.RBText[4].enabled = false;
			this.RBText[5].enabled = false;
			this.NowScoreText.enabled = false;
			this.NextScoreText.enabled = false;
			this.Main2T.GetChild(5).gameObject.SetActive(false);
			this.Main2T.GetChild(19).gameObject.SetActive(false);
			if (this.tmpData.EventState != EActivityState.EAS_ReplayRanking)
			{
				this.Main2T.GetChild(20).gameObject.SetActive(false);
			}
			else
			{
				this.Main2T.GetChild(20).gameObject.SetActive(true);
				this.Main2T.GetChild(20).GetComponent<RectTransform>().anchoredPosition += new Vector2(75f, 0f);
			}
			this.ContentT.GetChild(0).gameObject.SetActive(false);
			this.ContentT.GetChild(1).gameObject.SetActive(false);
			this.ContentT.GetChild(2).gameObject.SetActive(false);
			this.SPT.gameObject.SetActive(true);
			this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 1017f);
			this.LightT = this.Main2T.GetChild(17).GetChild(0);
			this.HintT2 = this.m_transform.GetChild(3).GetComponent<RectTransform>();
			this.RBText2[7] = this.HintT2.GetChild(0).GetComponent<UIText>();
			this.RBText2[7].font = this.tmpFont;
			this.RBText2[7].alignment = TextAnchor.UpperLeft;
			this.RBText2[7].text = this.DM.mStringTable.GetStringByID(10006u);
			float num26 = this.RBText2[7].preferredHeight + 1f;
			this.RBText2[7].rectTransform.sizeDelta = new Vector2(this.RBText2[7].rectTransform.sizeDelta.x, num26);
			this.HintT2.sizeDelta = new Vector2(this.HintT2.sizeDelta.x, num26 + 30f);
			this.HintT2.anchoredPosition = new Vector2(-403f, 51f);
			this.RBText[6].text = this.DM.mStringTable.GetStringByID(10005u);
			this.Main2T.GetChild(11).gameObject.SetActive(true);
			this.RBText2[6] = this.Main2T.GetChild(11).GetComponent<UIText>();
			this.RBText2[6].font = this.tmpFont;
			this.Main2T.GetChild(17).gameObject.SetActive(true);
			transform = this.SPT;
			this.RBText3[0] = transform.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.RBText3[0].font = this.tmpFont;
			this.RBText3[0].text = this.DM.mStringTable.GetStringByID(9967u);
			this.RBText3[1] = transform.GetChild(4).GetComponent<UIText>();
			this.RBText3[1].font = this.tmpFont;
			this.RBText3[2] = transform.GetChild(5).GetComponent<UIText>();
			this.RBText3[2].font = this.tmpFont;
			this.RBText3[3] = transform.GetChild(6).GetComponent<UIText>();
			this.RBText3[3].font = this.tmpFont;
			this.RBText3[3].text = this.DM.mStringTable.GetStringByID(10008u);
			this.RBText3[7] = transform.GetChild(7).GetChild(0).GetComponent<UIText>();
			this.RBText3[7].font = this.tmpFont;
			this.ItemNameStr[4] = instance2.SpawnString(100);
			this.ItemNameStr[4].IntToFormat(2L, 1, false);
			this.ItemNameStr[4].AppendFormat(this.DM.mStringTable.GetStringByID(8150u));
			this.RBText3[7].text = this.ItemNameStr[4].ToString();
			this.RBText3[8] = transform.GetChild(9).GetChild(0).GetComponent<UIText>();
			this.RBText3[8].font = this.tmpFont;
			this.ItemNameStr[5] = instance2.SpawnString(100);
			this.ItemNameStr[5].IntToFormat(3L, 1, false);
			this.ItemNameStr[5].AppendFormat(this.DM.mStringTable.GetStringByID(8150u));
			this.RBText3[8].text = this.ItemNameStr[5].ToString();
			if (this.tmpData.EventPrizeID > 0)
			{
				KOFPrizeData recordByKey3 = this.DM.KOFPrize.GetRecordByKey(this.tmpData.EventPrizeID);
				if (recordByKey3.ID == this.tmpData.EventPrizeID)
				{
					Equip recordByKey4 = this.DM.EquipTable.GetRecordByKey(recordByKey3.PrizeItem[0].ItemID);
					if (recordByKey4.EquipKey == recordByKey3.PrizeItem[0].ItemID)
					{
						bool flag2 = this.GM.IsLeadItem(recordByKey4.EquipKind);
						if (flag2)
						{
							transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
							transform.GetChild(1).GetChild(1).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
							this.GM.InitLordEquipImg(transform.GetChild(1).GetChild(1), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
							this.GM.ChangeLordEquipImg(transform.GetChild(1).GetChild(1), recordByKey3.PrizeItem[0].ItemID, recordByKey3.PrizeItem[0].ItemRank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
							transform.GetChild(1).GetChild(1).GetComponent<UIButtonHint>().enabled = true;
							transform.GetChild(1).GetChild(1).GetComponent<UILEBtn>().m_Handler = this;
						}
						else
						{
							transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
							transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
							this.GM.InitianHeroItemImg(transform.GetChild(1).GetChild(0), eHeroOrItem.Item, recordByKey3.PrizeItem[0].ItemID, 0, recordByKey3.PrizeItem[0].ItemRank, 0, true, true, true, false);
							if (instance.CheckCanOpenDetail(recordByKey3.PrizeItem[0].ItemID))
							{
								transform.GetChild(1).GetChild(0).GetComponent<UIButtonHint>().enabled = false;
							}
							else
							{
								transform.GetChild(1).GetChild(0).GetComponent<UIButtonHint>().enabled = true;
							}
							transform.GetChild(1).GetChild(0).GetComponent<UIHIBtn>().m_Handler = this;
						}
					}
					this.ItemNameStr[0] = instance2.SpawnString(100);
					if (recordByKey3.PrizeItem[1].ItemID > 0)
					{
						recordByKey4 = this.DM.EquipTable.GetRecordByKey(recordByKey3.PrizeItem[1].ItemID);
						if (recordByKey4.EquipKey == recordByKey3.PrizeItem[1].ItemID)
						{
							this.ItemNameStr[0].IntToFormat((long)(recordByKey4.PropertiesInfo[1].Propertieskey * recordByKey4.PropertiesInfo[1].PropertiesValue * (ushort)recordByKey3.PrizeItem[1].ItemNum), 1, true);
							this.ItemNameStr[0].AppendFormat("x{0}");
						}
					}
					else
					{
						transform.GetChild(2).gameObject.SetActive(false);
					}
					this.RBText3[1].text = this.ItemNameStr[0].ToString();
					this.ItemNameStr[1] = instance2.SpawnString(100);
					if (recordByKey3.PrizeItem[2].ItemID > 0)
					{
						recordByKey4 = this.DM.EquipTable.GetRecordByKey(recordByKey3.PrizeItem[2].ItemID);
						if (recordByKey4.EquipKey == recordByKey3.PrizeItem[2].ItemID)
						{
							this.ItemNameStr[1].IntToFormat((long)(recordByKey4.PropertiesInfo[1].Propertieskey * recordByKey4.PropertiesInfo[1].PropertiesValue * (ushort)recordByKey3.PrizeItem[2].ItemNum), 1, true);
							this.ItemNameStr[1].AppendFormat("x{0}");
						}
					}
					else
					{
						transform.GetChild(3).gameObject.SetActive(false);
					}
					this.RBText3[2].text = this.ItemNameStr[1].ToString();
				}
			}
			if (this.tmpData.EventPrizeID2 > 0)
			{
				transform = this.SPT.GetChild(8);
				KOFPrizeData recordByKey5 = this.DM.KOFPrize.GetRecordByKey(this.tmpData.EventPrizeID2);
				if (recordByKey5.ID == this.tmpData.EventPrizeID2)
				{
					Equip recordByKey4 = this.DM.EquipTable.GetRecordByKey(recordByKey5.PrizeItem[0].ItemID);
					if (recordByKey4.EquipKey == recordByKey5.PrizeItem[0].ItemID)
					{
						bool flag3 = this.GM.IsLeadItem(recordByKey4.EquipKind);
						if (flag3)
						{
							transform.GetChild(1).gameObject.SetActive(true);
							transform.GetChild(1).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
							this.GM.InitLordEquipImg(transform.GetChild(1), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
							this.GM.ChangeLordEquipImg(transform.GetChild(1), recordByKey5.PrizeItem[0].ItemID, recordByKey5.PrizeItem[0].ItemRank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
							transform.GetChild(1).GetComponent<UIButtonHint>().enabled = true;
							transform.GetChild(1).GetComponent<UILEBtn>().m_Handler = this;
						}
						else
						{
							transform.GetChild(0).gameObject.SetActive(true);
							this.GM.InitianHeroItemImg(transform.GetChild(0), eHeroOrItem.Item, recordByKey5.PrizeItem[0].ItemID, 0, recordByKey5.PrizeItem[0].ItemRank, 0, true, true, true, false);
							if (instance.CheckCanOpenDetail(recordByKey5.PrizeItem[0].ItemID))
							{
								transform.GetChild(0).GetComponent<UIButtonHint>().enabled = false;
							}
							else
							{
								transform.GetChild(0).GetComponent<UIButtonHint>().enabled = true;
							}
							transform.GetChild(0).GetComponent<UIHIBtn>().m_Handler = this;
						}
					}
				}
			}
			if (this.tmpData.EventPrizeID3 > 0)
			{
				transform = this.SPT.GetChild(10);
				KOFPrizeData recordByKey6 = this.DM.KOFPrize.GetRecordByKey(this.tmpData.EventPrizeID3);
				if (recordByKey6.ID == this.tmpData.EventPrizeID3)
				{
					Equip recordByKey4 = this.DM.EquipTable.GetRecordByKey(recordByKey6.PrizeItem[0].ItemID);
					if (recordByKey4.EquipKey == recordByKey6.PrizeItem[0].ItemID)
					{
						bool flag4 = this.GM.IsLeadItem(recordByKey4.EquipKind);
						if (flag4)
						{
							transform.GetChild(1).gameObject.SetActive(true);
							transform.GetChild(1).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
							this.GM.InitLordEquipImg(transform.GetChild(1), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
							this.GM.ChangeLordEquipImg(transform.GetChild(1), recordByKey6.PrizeItem[0].ItemID, recordByKey6.PrizeItem[0].ItemRank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
							transform.GetChild(1).GetComponent<UIButtonHint>().enabled = true;
							transform.GetChild(1).GetComponent<UILEBtn>().m_Handler = this;
						}
						else
						{
							transform.GetChild(0).gameObject.SetActive(true);
							this.GM.InitianHeroItemImg(transform.GetChild(0), eHeroOrItem.Item, recordByKey6.PrizeItem[0].ItemID, 0, recordByKey6.PrizeItem[0].ItemRank, 0, true, true, true, false);
							if (instance.CheckCanOpenDetail(recordByKey6.PrizeItem[0].ItemID))
							{
								transform.GetChild(0).GetComponent<UIButtonHint>().enabled = false;
							}
							else
							{
								transform.GetChild(0).GetComponent<UIButtonHint>().enabled = true;
							}
							transform.GetChild(0).GetComponent<UIHIBtn>().m_Handler = this;
						}
					}
				}
			}
			if (this.RBText3[3].preferredHeight > 73f)
			{
				this.RBText3[3].rectTransform.sizeDelta = new Vector2(this.RBText3[3].rectTransform.sizeDelta.x, this.RBText3[3].preferredHeight + 1f);
				this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 735f + this.RBText3[3].preferredHeight);
				float num27 = this.RBText3[3].preferredHeight - 73f;
				this.SPT.GetChild(7).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -num27);
				this.SPT.GetChild(8).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -num27);
				this.SPT.GetChild(9).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -num27);
				this.SPT.GetChild(10).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -num27);
			}
			else
			{
				this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 805f);
			}
			if (this.tmpData.EventState == EActivityState.EAS_Prepare)
			{
				this.RBText2[6].text = this.DM.mStringTable.GetStringByID(10004u);
				this.Main2T.GetChild(21).gameObject.SetActive(true);
			}
			else if (this.tmpData.EventState == EActivityState.EAS_Run)
			{
				this.RBText2[6].text = this.DM.mStringTable.GetStringByID(10009u);
				this.Main2T.GetChild(21).gameObject.SetActive(true);
			}
			else if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
			{
				this.RBText2[6].gameObject.SetActive(false);
				this.SPT.gameObject.SetActive(false);
				this.Main2T.GetChild(24).gameObject.SetActive(true);
				this.RBText[7].text = this.DM.mStringTable.GetStringByID(10013u);
				if (this.AM.WKIcon > 0)
				{
					transform = this.Main2T.GetChild(24).GetChild(4);
					transform.GetComponent<UIButton>().m_Handler = this;
					this.ItemNameStr[2] = instance2.SpawnString(150);
					this.ItemNameStr[2].Append(this.AM.WKName);
					this.RBText3[4] = transform.GetChild(0).GetComponent<UIText>();
					this.RBText3[4].font = this.tmpFont;
					this.RBText3[4].text = this.ItemNameStr[2].ToString();
					Image component12 = transform.GetChild(0).GetChild(0).GetComponent<Image>();
					if (this.RBText3[4].preferredWidth + 4f > 251.3f)
					{
						component12.rectTransform.sizeDelta = new Vector2(251.3f, component12.rectTransform.sizeDelta.y);
					}
					else
					{
						component12.rectTransform.sizeDelta = new Vector2(this.RBText3[4].preferredWidth + 4f, component12.rectTransform.sizeDelta.y);
					}
					this.Main2T.GetChild(24).GetChild(6).GetComponent<UIButton>().m_Handler = this;
					this.ItemNameStr[3] = instance2.SpawnString(150);
					GameConstants.FormatRoleName(this.ItemNameStr[3], this.AM.WKName, this.AM.WKTag, null, 0, this.AM.WKKingdom, null, null, null, null);
					this.RBText3[5] = this.Main2T.GetChild(24).GetChild(6).GetChild(0).GetComponent<UIText>();
					this.RBText3[5].font = this.tmpFont;
					this.RBText3[5].text = this.ItemNameStr[3].ToString();
					component12 = this.Main2T.GetChild(24).GetChild(6).GetChild(0).GetChild(0).GetComponent<Image>();
					if (this.RBText3[5].preferredWidth + 4f > 400f)
					{
						component12.rectTransform.sizeDelta = new Vector2(400f, component12.rectTransform.sizeDelta.y);
					}
					else
					{
						component12.rectTransform.sizeDelta = new Vector2(this.RBText3[5].preferredWidth + 4f, component12.rectTransform.sizeDelta.y);
					}
					RectTransform rectTransform2 = (RectTransform)this.Main2T.GetChild(24).GetChild(6);
					rectTransform2.sizeDelta = new Vector2(component12.rectTransform.sizeDelta.x, rectTransform2.sizeDelta.y);
					rectTransform2.anchoredPosition = new Vector2(rectTransform2.sizeDelta.x / 2f, rectTransform2.anchoredPosition.y);
					this.RBText3[6] = this.Main2T.GetChild(24).GetChild(5).GetComponent<UIText>();
					this.RBText3[6].font = this.tmpFont;
					this.RBText3[6].alignment = TextAnchor.LowerRight;
					this.RBText3[6].text = this.DM.mStringTable.GetStringByID(10011u);
					this.ActorT = this.Main2T.GetChild(24).GetChild(0);
					this.sHero = this.DM.HeroTable.GetRecordByKey(this.AM.WKIcon);
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.IntToFormat((long)this.sHero.Modle, 5, false);
					cstring.AppendFormat("Role/hero_{0}");
					if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, this.sHero.Modle, false))
					{
						this.LoadAB(false);
					}
				}
				else
				{
					this.Main2T.GetChild(24).GetChild(4).gameObject.SetActive(false);
					this.Main2T.GetChild(24).GetChild(5).gameObject.SetActive(false);
					this.Main2T.GetChild(24).GetChild(6).gameObject.SetActive(false);
				}
			}
			else
			{
				this.RBText2[6].text = this.DM.mStringTable.GetStringByID(9811u);
			}
			transform = this.Main2T.GetChild(17).GetChild(1);
			transform.GetComponent<UIButton>().m_BtnID1 = 4;
			UIButtonHint uibuttonHint = transform.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 1;
			this.OtherAB = AssetManager.GetAssetBundle("UI/Yolk_006", out this.OtherAssetKey, false);
			if (this.OtherAB != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(this.OtherAB.mainAsset) as GameObject;
				RectTransform rectTransform3 = gameObject.transform as RectTransform;
				rectTransform3.anchoredPosition = new Vector2(18f, -29f);
				rectTransform3.sizeDelta = new Vector2(282f, 321f);
				Image component13 = gameObject.GetComponent<Image>();
				component13.material.renderQueue = 3000;
				gameObject.transform.SetParent(transform, false);
				gameObject.SetActive(true);
			}
			this.TimeSA = this.Main2T.GetChild(23).GetComponent<UISpritesArray>();
			this.TimeTitle = this.Main2T.GetChild(23).GetChild(0).GetComponent<UIText>();
			this.TimeTitle.font = this.tmpFont;
			this.TimeText = this.Main2T.GetChild(23).GetChild(1).GetComponent<UIText>();
			this.TimeText.font = this.tmpFont;
			this.TimeTitle2 = this.Main2T.GetChild(23).GetChild(2).GetComponent<UIText>();
			this.TimeTitle2.font = this.tmpFont;
			this.TimeTitle2.enabled = false;
			this.TimeTitle2.gameObject.SetActive(true);
			this.TimeStr = instance2.SpawnString(30);
			this.SetTimeTitle();
			this.SetTimeStr();
			this.GM.m_LordInfo.HideEquipVal = true;
		}
		else if (this.tmpData.ActiveType == EActivityType.EAT_AllianceSummon)
		{
			this.LoadSP("CT_AllianceSummon");
			this.ContentT.GetChild(0).gameObject.SetActive(false);
			this.ContentT.GetChild(1).gameObject.SetActive(false);
			this.ContentT.GetChild(2).gameObject.SetActive(false);
			this.SPT.gameObject.SetActive(true);
			this.Main2T.GetChild(19).gameObject.SetActive(false);
			this.SummonBtn2.SetActive(true);
			if (this.tmpData.EventState == EActivityState.EAS_Prepare)
			{
				this.Main2T.GetChild(28).gameObject.SetActive(false);
			}
			if (this.DM.RoleAlliance.Id == 0u || this.AM.AllianceSummonAllianceID == 0u || this.DM.RoleAlliance.Id != this.AM.AllianceSummonAllianceID)
			{
				this.Main2T.GetChild(28).GetComponent<Image>().color = Color.gray;
				this.Main2T.GetChild(28).GetComponent<UIButton>().interactable = false;
			}
			SummonInfo recordByKey7 = this.DM.SummonInfoData.GetRecordByKey(this.AM.AllianceSummonEventInfoID);
			for (int num28 = 0; num28 < 3; num28++)
			{
				transform = this.SPT.GetChild(num28);
				this.PrizeStageImg[num28] = transform.GetChild(1).GetComponent<Image>();
				if (this.GM.IsArabic)
				{
					this.PrizeStageImg[num28].rectTransform.localScale = new Vector3(-this.PrizeStageImg[num28].rectTransform.localScale.x, this.PrizeStageImg[num28].rectTransform.localScale.y, this.PrizeStageImg[num28].rectTransform.localScale.z);
					this.PrizeStageImg[num28].rectTransform.anchoredPosition += new Vector2(this.PrizeStageImg[num28].rectTransform.sizeDelta.x, 0f);
				}
				if (num28 < (int)this.nowStep)
				{
					this.PrizeStageImg[num28].gameObject.SetActive(true);
				}
				else
				{
					this.PrizeStageImg[num28].gameObject.SetActive(false);
				}
				this.StepText2[num28] = transform.GetChild(2).GetComponent<UIText>();
				this.StepText2[num28].font = this.tmpFont;
				this.TitleText2[num28] = instance2.SpawnString(30);
				this.TitleText2[num28].uLongToFormat(this.StepScore[num28], 1, true);
				this.TitleText2[num28].AppendFormat(this.DM.mStringTable.GetStringByID(8121u));
				this.StepText2[num28].text = this.TitleText2[num28].ToString();
				if (this.GM.IsArabic)
				{
					transform.GetChild(3).gameObject.AddComponent<ArabicItemTextureRot>();
				}
				UIButtonHint uibuttonHint = transform.GetChild(3).gameObject.AddComponent<UIButtonHint>();
				uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
				uibuttonHint.m_eHint = EUIButtonHint.CountDown;
				uibuttonHint.DelayTime = 0.2f;
				uibuttonHint.m_Handler = this;
				uibuttonHint.Parm1 = 1;
				uibuttonHint.ScrollID = 1;
				this.SetPointTexture(byte.MaxValue, transform.GetChild(4).GetComponent<Image>());
				if (this.GM.IsArabic)
				{
					transform.GetChild(4).gameObject.AddComponent<ArabicItemTextureRot>();
					transform.GetChild(5).gameObject.AddComponent<ArabicItemTextureRot>();
					transform.GetChild(6).gameObject.AddComponent<ArabicItemTextureRot>();
				}
				transform.GetChild(4).gameObject.SetActive(true);
				transform.GetChild(5).gameObject.SetActive(true);
				if (recordByKey7.PointData[num28].Point > 9 && recordByKey7.PointData[num28].Point < 100)
				{
					transform.GetChild(6).gameObject.SetActive(true);
					this.SetPointTexture(recordByKey7.PointData[num28].Point / 10, transform.GetChild(5).GetComponent<Image>());
					this.SetPointTexture(recordByKey7.PointData[num28].Point % 10, transform.GetChild(6).GetComponent<Image>());
				}
				else
				{
					this.SetPointTexture(recordByKey7.PointData[num28].Point % 10, transform.GetChild(5).GetComponent<Image>());
				}
			}
			transform = this.SPT;
			transform.GetChild(3).GetComponent<CustomImage>().hander = this;
			this.NoImgGO = transform.GetChild(3).gameObject;
			this.NoText1 = transform.GetChild(4).GetComponent<UIText>();
			this.NoText1.font = this.tmpFont;
			this.NoText2 = transform.GetChild(5).GetComponent<UIText>();
			this.NoText2.font = this.tmpFont;
			this.CheckAllianceID();
			this.TimeSA = this.Main2T.GetChild(23).GetComponent<UISpritesArray>();
			this.TimeTitle = this.Main2T.GetChild(23).GetChild(0).GetComponent<UIText>();
			this.TimeTitle.font = this.tmpFont;
			if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
			{
				this.SummonTimeObj = this.Main2T.GetChild(29).gameObject;
				this.RankReplayTitleText = this.Main2T.GetChild(29).GetChild(0).GetComponent<UIText>();
				this.RankReplayTitleText.font = this.tmpFont;
				this.TimeText = this.Main2T.GetChild(29).GetChild(1).GetComponent<UIText>();
				this.TimeText.font = this.tmpFont;
				this.RBText[4].enabled = false;
				this.RBText[5].enabled = false;
				this.NowScoreText.enabled = false;
				this.NextScoreText.enabled = false;
			}
			else
			{
				this.TimeText = this.Main2T.GetChild(23).GetChild(1).GetComponent<UIText>();
				this.TimeText.font = this.tmpFont;
			}
			this.TimeTitle2 = this.Main2T.GetChild(23).GetChild(2).GetComponent<UIText>();
			this.TimeTitle2.font = this.tmpFont;
			this.TimeTitle2.enabled = false;
			this.TimeTitle2.gameObject.SetActive(true);
			this.TimeStr = instance2.SpawnString(30);
			this.SetTimeTitle();
			this.SetTimeStr();
			this.SetStepScore(this.tmpData.EventScore);
			this.HintT2 = this.m_transform.GetChild(3).GetComponent<RectTransform>();
			this.RBText2[10] = this.HintT2.GetChild(0).GetComponent<UIText>();
			this.RBText2[10].font = this.tmpFont;
			this.RBText2[10].alignment = TextAnchor.UpperLeft;
			this.RBText2[10].text = this.DM.mStringTable.GetStringByID(14507u);
			float num29 = this.RBText2[10].preferredHeight + 1f;
			this.RBText2[10].rectTransform.sizeDelta = new Vector2(this.RBText2[10].rectTransform.sizeDelta.x, num29);
			this.HintT2.sizeDelta = new Vector2(this.HintT2.sizeDelta.x, num29 + 30f);
			this.HintT4 = this.m_transform.GetChild(7).GetComponent<RectTransform>();
			transform = this.m_transform.GetChild(7);
			this.RBText5[0] = transform.GetChild(1).GetComponent<UIText>();
			this.RBText5[0].font = this.tmpFont;
			this.RBText5[0].text = this.DM.mStringTable.GetStringByID(14540u);
			int num30 = 1;
			float num31 = 0f;
			float num32 = 0f;
			for (int num33 = 0; num33 < 5; num33++)
			{
				SummonScoreData allianceSummonScore_SDataByFactor = this.AM.GetAllianceSummonScore_SDataByFactor(16, (byte)(num33 + 1));
				this.RBText5[num30] = transform.GetChild(num33 + 2).GetChild(0).GetComponent<UIText>();
				this.RBText5[num30].font = this.tmpFont;
				this.Hint5Str[num30] = StringManager.Instance.SpawnString(200);
				this.Hint5Str[num30].IntToFormat((long)(num33 + 1), 1, false);
				this.Hint5Str[num30].AppendFormat(this.DM.mStringTable.GetStringByID(14541u));
				this.RBText5[num30].text = this.Hint5Str[num30].ToString();
				this.RBText5[num30].SetAllDirty();
				this.RBText5[num30].cachedTextGeneratorForLayout.Invalidate();
				float num34 = this.RBText5[num30].preferredWidth + 2f;
				if (num31 < num34)
				{
					num31 = num34;
				}
				num30++;
				this.RBText5[num30] = transform.GetChild(num33 + 2).GetChild(1).GetComponent<UIText>();
				this.RBText5[num30].font = this.tmpFont;
				this.Hint5Str[num30] = StringManager.Instance.SpawnString(50);
				this.Hint5Str[num30].IntToFormat((long)((ulong)allianceSummonScore_SDataByFactor.Score1), 1, true);
				this.Hint5Str[num30].AppendFormat(this.DM.mStringTable.GetStringByID(8145u));
				this.RBText5[num30].text = this.Hint5Str[num30].ToString();
				this.RBText5[num30].SetAllDirty();
				this.RBText5[num30].cachedTextGeneratorForLayout.Invalidate();
				float num35 = this.RBText5[num30].preferredWidth + 2f;
				num30++;
				this.RBText5[num30] = transform.GetChild(num33 + 2).GetChild(2).GetComponent<UIText>();
				this.RBText5[num30].font = this.tmpFont;
				this.Hint5Str[num30] = StringManager.Instance.SpawnString(100);
				num30++;
				float num36 = 88f + num34 + num35;
				if (num32 < num36)
				{
					num32 = num36;
				}
			}
			if (num32 > this.Sizex)
			{
				num32 = 38f + num31;
				for (int num37 = 0; num37 < 5; num37++)
				{
					transform.GetChild(num37 + 2).GetChild(1).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -30f);
				}
			}
			this.HintT4.sizeDelta = new Vector2(num32, this.HintT4.sizeDelta.y);
			if (num32 > this.Sizex)
			{
				this.HintT4.anchoredPosition = new Vector2(-(num32 - this.Sizex) / 2f, -this.Sizey / 2f + 200f);
			}
			else
			{
				this.HintT4.anchoredPosition = new Vector2(this.Sizex / 2f - 86f, -this.Sizey / 2f + 140f);
				if (this.HintT4.anchoredPosition.x + this.HintT4.sizeDelta.x > this.Sizex)
				{
					this.HintT4.anchoredPosition = new Vector2(this.Sizex - this.HintT4.sizeDelta.x, this.HintT4.anchoredPosition.y);
				}
				if (this.HintT4.anchoredPosition.x < 0f)
				{
					this.HintT4.anchoredPosition = new Vector2(0f, this.HintT4.anchoredPosition.y);
				}
			}
			this.SetNPCCityCombatTimes(false);
			this.SetMonsterState();
		}
		else if (this.tmpData.ActiveType == EActivityType.EAT_FederalEvent)
		{
			this.LoadSP("CT_NWObject");
			this.RBText[4].enabled = false;
			this.RBText[5].enabled = false;
			this.NowScoreText.enabled = false;
			this.NextScoreText.enabled = false;
			this.Main2T.GetChild(5).gameObject.SetActive(false);
			this.Main2T.GetChild(19).gameObject.SetActive(false);
			this.Main2T.GetChild(20).gameObject.SetActive(false);
			this.RightObject_KingdomBtn = this.Main2T.GetChild(20).gameObject;
			this.Main2T.GetChild(20).GetComponent<RectTransform>().anchoredPosition += new Vector2(75f, 0f);
			this.ContentT.GetChild(0).gameObject.SetActive(false);
			this.ContentT.GetChild(1).gameObject.SetActive(false);
			this.ContentT.GetChild(2).gameObject.SetActive(false);
			this.RBText[6].text = this.DM.mStringTable.GetStringByID(5043u);
			this.RBText[7].text = this.DM.mStringTable.GetStringByID(3649u);
			this.TimeSA = this.Main2T.GetChild(23).GetComponent<UISpritesArray>();
			this.TimeTitle = this.Main2T.GetChild(23).GetChild(0).GetComponent<UIText>();
			this.TimeTitle.font = this.tmpFont;
			this.TimeText = this.Main2T.GetChild(23).GetChild(1).GetComponent<UIText>();
			this.TimeText.font = this.tmpFont;
			this.TimeTitle2 = this.Main2T.GetChild(23).GetChild(2).GetComponent<UIText>();
			this.TimeTitle2.font = this.tmpFont;
			this.TimeTitle2.enabled = false;
			this.TimeTitle2.gameObject.SetActive(true);
			this.TimeStr = instance2.SpawnString(30);
			this.SetTimeTitle();
			this.SetTimeStr();
			this.Scroll = this.Main2T.GetChild(30).GetComponent<ScrollPanel>();
			this.UnitObjectT = this.Main2T.GetChild(31);
			this.UnitObjectT.GetChild(0).GetChild(1).GetComponent<UIText>().font = this.tmpFont;
			this.UnitObjectT.GetChild(0).GetChild(2).GetComponent<UIText>().font = this.tmpFont;
			for (int num38 = 0; num38 < 7; num38++)
			{
				this.bFindScrollComp[num38] = false;
			}
			this.Scroll.IntiScrollPanel(364f, 6f, 5f, this.NowHeightList, 7, this);
			this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
			UIButtonHint.scrollRect = this.cScrollRect;
			this.Scroll.gameObject.SetActive(true);
			this.Refresh_NWLeftList();
			transform = this.SPT;
			this.RightObject_Prize = transform.gameObject;
			this.RightObject_Part1 = transform.GetChild(0).gameObject;
			this.P1_TitleText = transform.GetChild(0).GetChild(2).GetComponent<UIText>();
			this.P1_TitleText.font = this.tmpFont;
			this.P2RC = transform.GetChild(1).GetComponent<RectTransform>();
			transform.GetChild(1).GetChild(0).GetComponent<UIButton>().m_Handler = this;
			transform.GetChild(1).GetChild(1).GetComponent<UIButton>().m_Handler = this;
			UIButtonHint uibuttonHint = transform.GetChild(1).GetChild(1).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
			uibuttonHint.m_eHint = EUIButtonHint.CountDown;
			uibuttonHint.DelayTime = 0.3f;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 4;
			uibuttonHint.ScrollID = 1;
			this.P2_WonderNameLeftImgRC = transform.GetChild(1).GetChild(3).GetComponent<RectTransform>();
			transform.GetChild(1).GetChild(3).GetComponent<UIButton>().m_Handler = this;
			uibuttonHint = transform.GetChild(1).GetChild(3).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
			uibuttonHint.m_eHint = EUIButtonHint.CountDown;
			uibuttonHint.DelayTime = 0.3f;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 4;
			uibuttonHint.ScrollID = 1;
			this.MyKingdom_prize = transform.GetChild(1).GetChild(2).gameObject;
			transform.GetChild(1).GetChild(2).GetComponent<UIButton>().m_Handler = this;
			uibuttonHint = transform.GetChild(1).GetChild(2).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
			uibuttonHint.m_eHint = EUIButtonHint.CountDown;
			uibuttonHint.DelayTime = 0.3f;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 4;
			uibuttonHint.ScrollID = 1;
			this.P2_KingdomIDText = transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<UIText>();
			this.P2_KingdomIDText.font = this.tmpFont;
			transform.GetChild(1).GetChild(4).GetComponent<UIButton>().m_Handler = this;
			uibuttonHint = transform.GetChild(1).GetChild(4).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
			uibuttonHint.m_eHint = EUIButtonHint.CountDown;
			uibuttonHint.DelayTime = 0.3f;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 4;
			uibuttonHint.ScrollID = 1;
			this.P2_WonderNameRC = transform.GetChild(1).GetChild(4).GetComponent<RectTransform>();
			this.P2_WonderNameText = transform.GetChild(1).GetChild(4).GetChild(0).GetComponent<UIText>();
			this.P2_WonderNameText.font = this.tmpFont;
			transform.GetChild(1).GetChild(5).GetComponent<UIButton>().m_Handler = this;
			this.P2_WonderPosRC = transform.GetChild(1).GetChild(5).GetComponent<RectTransform>();
			this.P2_WonderPosText = transform.GetChild(1).GetChild(5).GetChild(0).GetComponent<UIText>();
			this.P2_WonderPosText.font = this.tmpFont;
			this.P2_FightX = transform.GetChild(1).GetChild(6).gameObject;
			this.P3RC = transform.GetChild(2).GetComponent<RectTransform>();
			this.P3_1stItem = transform.GetChild(2).GetChild(2).GetComponent<RectTransform>();
			this.P3_2ndItem = transform.GetChild(2).GetChild(9).GetComponent<RectTransform>();
			this.P3_3rdItem = transform.GetChild(2).GetChild(11).GetComponent<RectTransform>();
			this.P3_1stItem.GetChild(1).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
			this.P3_1stItem.GetChild(1).GetComponent<UIButtonHint>().enabled = true;
			this.P3_1stItem.GetChild(1).GetComponent<UIButtonHint>().ScrollID = 1;
			this.P3_1stItem.GetChild(1).GetComponent<UILEBtn>().m_Handler = this;
			this.P3_2ndItem.GetChild(1).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
			this.P3_2ndItem.GetChild(1).GetComponent<UIButtonHint>().enabled = true;
			this.P3_2ndItem.GetChild(1).GetComponent<UIButtonHint>().ScrollID = 1;
			this.P3_2ndItem.GetChild(1).GetComponent<UILEBtn>().m_Handler = this;
			this.P3_3rdItem.GetChild(1).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
			this.P3_3rdItem.GetChild(1).GetComponent<UIButtonHint>().enabled = true;
			this.P3_3rdItem.GetChild(1).GetComponent<UIButtonHint>().ScrollID = 1;
			this.P3_3rdItem.GetChild(1).GetComponent<UILEBtn>().m_Handler = this;
			this.P3_1stItem.GetChild(0).GetComponent<UIHIBtn>().m_Handler = this;
			this.P3_2ndItem.GetChild(0).GetComponent<UIHIBtn>().m_Handler = this;
			this.P3_3rdItem.GetChild(0).GetComponent<UIHIBtn>().m_Handler = this;
			this.GM.InitianHeroItemImg(this.P3_1stItem.GetChild(0), eHeroOrItem.Item, 10, 0, 0, 0, true, true, true, false);
			this.GM.InitianHeroItemImg(this.P3_2ndItem.GetChild(0), eHeroOrItem.Item, 10, 0, 0, 0, true, true, true, false);
			this.GM.InitianHeroItemImg(this.P3_3rdItem.GetChild(0), eHeroOrItem.Item, 10, 0, 0, 0, true, true, true, false);
			this.GM.InitLordEquipImg(this.P3_1stItem.GetChild(1), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
			this.GM.InitLordEquipImg(this.P3_2ndItem.GetChild(1), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
			this.GM.InitLordEquipImg(this.P3_3rdItem.GetChild(1), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
			this.P3_ItemText = new UIText[3];
			this.P3_ItemText[0] = this.P3_1stItem.GetChild(2).GetComponent<UIText>();
			this.P3_ItemText[0].font = this.tmpFont;
			this.P3_ItemText[0].gameObject.SetActive(false);
			this.P3_ItemText[0].rectTransform.anchoredPosition = new Vector2(112f, -80f);
			this.P3_ItemText[1] = this.P3_2ndItem.GetChild(2).GetComponent<UIText>();
			this.P3_ItemText[1].font = this.tmpFont;
			this.P3_ItemText[1].gameObject.SetActive(false);
			this.P3_ItemText[1].rectTransform.anchoredPosition = new Vector2(112f, -80f);
			this.P3_ItemText[2] = this.P3_3rdItem.GetChild(2).GetComponent<UIText>();
			this.P3_ItemText[2].font = this.tmpFont;
			this.P3_ItemText[2].gameObject.SetActive(false);
			this.P3_ItemText[2].rectTransform.anchoredPosition = new Vector2(112f, -80f);
			this.P3_ItemStr = new CString[3];
			this.P3_ItemStr[0] = StringManager.Instance.SpawnString(30);
			this.P3_ItemStr[1] = StringManager.Instance.SpawnString(30);
			this.P3_ItemStr[2] = StringManager.Instance.SpawnString(30);
			this.RBText3[0] = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
			this.RBText3[0].font = this.tmpFont;
			this.RBText3[0].text = this.DM.mStringTable.GetStringByID(8119u);
			this.RBText3[1] = transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
			this.RBText3[1].font = this.tmpFont;
			this.RBText3[1].text = this.DM.mStringTable.GetStringByID(11057u);
			this.P3_CrystalText = transform.GetChild(2).GetChild(5).GetComponent<UIText>();
			this.P3_CrystalText.font = this.tmpFont;
			this.P3_MoneyText = transform.GetChild(2).GetChild(6).GetComponent<UIText>();
			this.P3_MoneyText.font = this.tmpFont;
			this.RBText3[2] = transform.GetChild(2).GetChild(7).GetComponent<UIText>();
			this.RBText3[2].font = this.tmpFont;
			this.RBText3[2].text = this.DM.mStringTable.GetStringByID(5037u);
			if (this.RBText3[2].preferredHeight > 73f)
			{
				this.RBText3[2].rectTransform.sizeDelta = new Vector2(this.RBText3[2].rectTransform.sizeDelta.x, this.RBText3[2].preferredHeight + 1f);
				this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 1100f + this.RBText3[2].preferredHeight);
				float num39 = this.RBText3[2].preferredHeight - 73f;
				transform.GetChild(2).GetChild(8).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -num39);
				transform.GetChild(2).GetChild(9).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -num39);
				transform.GetChild(2).GetChild(10).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -num39);
				transform.GetChild(2).GetChild(11).GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -num39);
			}
			else
			{
				this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 1175f);
			}
			this.ContentSize = this.ContentT.GetComponent<RectTransform>().sizeDelta;
			this.RBText3[3] = transform.GetChild(2).GetChild(8).GetChild(0).GetComponent<UIText>();
			this.RBText3[3].font = this.tmpFont;
			this.ItemNameStr[0] = instance2.SpawnString(100);
			this.ItemNameStr[0].IntToFormat(2L, 1, false);
			this.ItemNameStr[0].AppendFormat(this.DM.mStringTable.GetStringByID(8150u));
			this.RBText3[3].text = this.ItemNameStr[0].ToString();
			this.RBText3[4] = transform.GetChild(2).GetChild(10).GetChild(0).GetComponent<UIText>();
			this.RBText3[4].font = this.tmpFont;
			this.ItemNameStr[1] = instance2.SpawnString(100);
			this.ItemNameStr[1].IntToFormat(3L, 1, false);
			this.ItemNameStr[1].AppendFormat(this.DM.mStringTable.GetStringByID(8150u));
			this.RBText3[4].text = this.ItemNameStr[1].ToString();
			transform = this.Main2T.GetChild(32);
			this.RightObject_RP = transform.gameObject;
			this.ActorT = transform.GetChild(0);
			transform.GetChild(4).GetComponent<UIButton>().m_Handler = this;
			this.RP_NameText = transform.GetChild(4).GetChild(0).GetComponent<UIText>();
			this.RP_NameText.font = this.tmpFont;
			this.RP_NameImage = transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Image>();
			this.MyKingdom_RP = transform.GetChild(7).gameObject;
			transform.GetChild(7).GetComponent<UIButton>().m_Handler = this;
			transform.GetChild(7).GetComponent<UIButton>().m_BtnID2 = 2;
			uibuttonHint = transform.GetChild(7).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
			uibuttonHint.m_eHint = EUIButtonHint.CountDown;
			uibuttonHint.DelayTime = 0.3f;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 4;
			uibuttonHint.ScrollID = 1;
			this.RP_KingdomIDText = transform.GetChild(7).GetChild(1).GetComponent<UIText>();
			this.RP_KingdomIDText.font = this.tmpFont;
			transform.GetChild(8).GetComponent<UIButton>().m_Handler = this;
			this.NWText = this.Main2T.GetChild(33).GetComponent<UIText>();
			this.NWText.font = this.tmpFont;
			this.NWText.text = this.DM.mStringTable.GetStringByID(3734u);
			this.NWText.gameObject.SetActive(true);
			this.NW_New = this.Main2T.GetChild(34).GetComponent<Image>();
			this.NW_New.rectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
			this.HintNormal = this.m_transform.GetChild(3).GetComponent<RectTransform>();
			this.RBText3[5] = this.HintNormal.GetChild(0).GetComponent<UIText>();
			this.RBText3[5].font = this.tmpFont;
			this.RBText3[5].alignment = TextAnchor.UpperLeft;
			this.HintKingdom = this.m_transform.GetChild(8).GetComponent<RectTransform>();
			this.RBText3[6] = this.HintKingdom.GetChild(0).GetComponent<UIText>();
			this.RBText3[6].font = this.tmpFont;
			this.RBText3[6].text = this.DM.mStringTable.GetStringByID(3797u);
			this.HintObject = new GameObject[50];
			this.HintKingdomText = new UIText[50];
			this.HintKingdomStr = new CString[50];
			Transform child2 = this.HintKingdom.GetChild(1);
			this.HintTargetImageGO = this.HintKingdom.GetChild(2).gameObject;
			Vector2 anchoredPosition = child2.GetComponent<RectTransform>().anchoredPosition;
			for (int num40 = 1; num40 < 50; num40++)
			{
				this.HintObject[num40] = (UnityEngine.Object.Instantiate(child2.gameObject) as GameObject);
				this.HintObject[num40].SetActive(true);
				this.HintObject[num40].transform.SetParent(this.HintKingdom, false);
				this.HintObject[num40].GetComponent<RectTransform>().anchoredPosition = new Vector2(anchoredPosition.x + (float)(num40 % 4 * 120), anchoredPosition.y - (float)(num40 / 4 * 45));
				this.HintKingdomText[num40] = this.HintObject[num40].transform.GetChild(1).GetComponent<UIText>();
				this.HintKingdomText[num40].font = this.tmpFont;
				this.HintKingdomText[num40].color = Color.white;
				this.HintKingdomStr[num40] = StringManager.Instance.SpawnString(30);
			}
			this.HintObject[0] = child2.gameObject;
			this.HintKingdomStr[0] = StringManager.Instance.SpawnString(30);
			this.HintKingdomText[0] = this.HintKingdom.GetChild(1).GetChild(1).GetComponent<UIText>();
			this.HintKingdomText[0].font = this.tmpFont;
			this.HintKingdomText[0].color = Color.white;
			this.SetRight(this.AM.NW_UI_SelectIndex);
			this.bNobilityWar = true;
		}
		else
		{
			for (int num41 = 0; num41 < 3; num41++)
			{
				transform = this.ContentT.GetChild(num41);
				transform.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -num4);
				this.PrizeStageImg[num41] = transform.GetChild(1).GetComponent<Image>();
				if (this.GM.IsArabic)
				{
					this.PrizeStageImg[num41].rectTransform.localScale = new Vector3(-this.PrizeStageImg[num41].rectTransform.localScale.x, this.PrizeStageImg[num41].rectTransform.localScale.y, this.PrizeStageImg[num41].rectTransform.localScale.z);
					this.PrizeStageImg[num41].rectTransform.anchoredPosition += new Vector2(this.PrizeStageImg[num41].rectTransform.sizeDelta.x, 0f);
				}
				if (num41 < (int)this.nowStep)
				{
					this.PrizeStageImg[num41].gameObject.SetActive(true);
				}
				else
				{
					this.PrizeStageImg[num41].gameObject.SetActive(false);
				}
				this.StepText1[num41] = transform.GetChild(3).GetComponent<UIText>();
				this.StepText1[num41].font = this.tmpFont;
				this.GemCountText[num41] = instance2.SpawnString(30);
				if (this.tmpData.EventPrizeWorthData[num41].Crystal == 0u)
				{
					transform.GetChild(2).gameObject.SetActive(false);
					transform.GetChild(3).gameObject.SetActive(false);
				}
				else
				{
					this.GemCountText[num41].IntToFormat((long)((ulong)this.tmpData.EventPrizeWorthData[num41].Crystal), 1, true);
					if (this.GM.IsArabic)
					{
						this.GemCountText[num41].AppendFormat("{0}x");
					}
					else
					{
						this.GemCountText[num41].AppendFormat("x{0}");
					}
					this.StepText1[num41].text = this.GemCountText[num41].ToString();
					if (this.tmpData.EventBonusType == EActEventBonusType.EAEBT_Crystal)
					{
						transform.GetChild(8).gameObject.SetActive(true);
						this.StepText1[num41].color = this.GreenColor;
					}
				}
				this.StepText2[num41] = transform.GetChild(4).GetComponent<UIText>();
				this.StepText2[num41].font = this.tmpFont;
				this.TitleText2[num41] = instance2.SpawnString(30);
				this.TitleText2[num41].uLongToFormat(this.StepScore[num41], 1, true);
				this.TitleText2[num41].AppendFormat(this.DM.mStringTable.GetStringByID(8121u));
				this.StepText2[num41].text = this.TitleText2[num41].ToString();
				this.StepText3[num41] = transform.GetChild(5).GetComponent<UIText>();
				this.StepText3[num41].font = this.tmpFont;
				this.TotalpriceText[num41] = instance2.SpawnString(30);
				this.TotalpriceText[num41].uLongToFormat((ulong)this.tmpData.EventPrizeWorthData[num41].CrystalPrice, 1, true);
				this.TotalpriceText[num41].AppendFormat(this.DM.mStringTable.GetStringByID(8122u));
				this.StepText3[num41].text = this.TotalpriceText[num41].ToString();
				this.StepText4[num41] = transform.GetChild(6).GetComponent<UIText>();
				this.StepText4[num41].font = this.tmpFont;
				this.NoPriceText[num41] = instance2.SpawnString(30);
				if (this.tmpData.EventPrizeWorthData[num41].Priceless == 0)
				{
					transform.GetChild(6).gameObject.SetActive(false);
				}
				else
				{
					this.NoPriceText[num41].uLongToFormat((ulong)this.tmpData.EventPrizeWorthData[num41].Priceless, 1, false);
					this.NoPriceText[num41].AppendFormat(this.DM.mStringTable.GetStringByID(8123u));
					this.StepText4[num41].text = this.NoPriceText[num41].ToString();
				}
				float num42 = 0f;
				if (this.tmpData.EventPrizeWorthData[num41].Crystal == 0u && this.tmpData.EventPrizeWorthData[num41].Priceless == 0)
				{
					num42 = 33f;
					num4 -= 33f;
				}
				if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKAllianceEvent || this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_AllianceEvent)
				{
					transform.GetChild(2).gameObject.SetActive(false);
					transform.GetChild(3).gameObject.SetActive(false);
					this.StepText3[num41].gameObject.SetActive(false);
					this.StepText4[num41].gameObject.SetActive(false);
					num42 = 33f;
					num4 -= 33f;
				}
				int num43 = 0;
				Transform child2 = transform.GetChild(7);
				this.GM.InitianHeroItemImg(child2.GetChild(0), eHeroOrItem.Item, 1001, 0, 0, 0, false, true, true, false);
				child2.GetChild(2).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
				this.GM.InitLordEquipImg(child2.GetChild(2), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
				for (int num44 = 0; num44 < this.ItemCount[num41]; num44++)
				{
					Equip recordByKey4 = this.DM.EquipTable.GetRecordByKey(this.tmpData.DegreePrize[num5].ItemID);
					if (recordByKey4.EquipKind == 11 && recordByKey4.PropertiesInfo[0].Propertieskey == 6)
					{
						num5++;
					}
					else
					{
						GameObject gameObject2 = UnityEngine.Object.Instantiate(child2.gameObject) as GameObject;
						gameObject2.SetActive(true);
						gameObject2.transform.SetParent(transform, false);
						bool flag5 = this.GM.IsLeadItem(recordByKey4.EquipKind);
						if (flag5)
						{
							gameObject2.transform.GetChild(0).gameObject.SetActive(false);
							gameObject2.transform.GetChild(2).gameObject.SetActive(true);
							this.GM.ChangeLordEquipImg(gameObject2.transform.GetChild(2), this.tmpData.DegreePrize[num5].ItemID, this.tmpData.DegreePrize[num5].Rank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
						}
						else
						{
							this.GM.ChangeHeroItemImg(gameObject2.transform.GetChild(0), eHeroOrItem.Item, this.tmpData.DegreePrize[num5].ItemID, 0, this.tmpData.DegreePrize[num5].Rank, 0);
						}
						if (flag5)
						{
							gameObject2.transform.GetChild(2).GetComponent<UIButtonHint>().enabled = true;
							gameObject2.transform.GetChild(2).GetComponent<UILEBtn>().m_Handler = this;
						}
						else
						{
							if (instance.CheckCanOpenDetail(this.tmpData.DegreePrize[num5].ItemID))
							{
								gameObject2.transform.GetChild(0).GetComponent<UIButtonHint>().enabled = false;
							}
							else
							{
								gameObject2.transform.GetChild(0).GetComponent<UIButtonHint>().enabled = true;
							}
							gameObject2.transform.GetChild(0).GetComponent<UIHIBtn>().m_Handler = this;
						}
						RectTransform component14 = gameObject2.GetComponent<RectTransform>();
						component14.localPosition += new Vector3((float)(117 * (num43 % 4)), -70f * (float)(num43 / 4) + num42, 0f);
						if (num44 == 0 && this.tmpData.CheckPrizeFlag((byte)num41))
						{
							gameObject2.transform.GetChild(5).gameObject.SetActive(true);
						}
						bool flag6 = this.tmpData.CheckBonusType(this.tmpData.DegreePrize[num5].ItemID);
						if (flag6)
						{
							gameObject2.transform.GetChild(4).gameObject.SetActive(true);
						}
						if (this.tmpData.DegreePrize[num5].Num > 1)
						{
							UIText component3 = gameObject2.transform.GetChild(1).GetComponent<UIText>();
							component3.font = this.tmpFont;
							this.ItemCountText[num41][num44] = instance2.SpawnString(30);
							this.ItemCountText[num41][num44].IntToFormat((long)this.tmpData.DegreePrize[num5].Num, 1, false);
							if (this.GM.IsArabic)
							{
								this.ItemCountText[num41][num44].AppendFormat("{0}x");
							}
							else
							{
								this.ItemCountText[num41][num44].AppendFormat("x{0}");
							}
							component3.text = this.ItemCountText[num41][num44].ToString();
							this.StepItemCountText[num41][num44] = component3;
							if (flag6)
							{
								component3.color = this.GreenColor;
							}
						}
						else
						{
							gameObject2.transform.GetChild(1).GetComponent<UIText>().enabled = false;
						}
						if (this.ItemCount[num41] <= 1 && (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKAllianceEvent || this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_AllianceEvent))
						{
							this.ItemNameText[num41] = gameObject2.transform.GetChild(3).GetComponent<UIText>();
							this.ItemNameText[num41].font = this.tmpFont;
							this.ItemNameStr[num41] = instance2.SpawnString(100);
							this.ItemNameStr[num41].Append(this.DM.mStringTable.GetStringByID((uint)recordByKey4.EquipName));
							this.ItemNameText[num41].text = this.ItemNameStr[num41].ToString();
							this.ItemNameText[num41].SetAllDirty();
							this.ItemNameText[num41].gameObject.SetActive(true);
						}
						num43++;
						num5++;
					}
				}
				UnityEngine.Object.Destroy(child2.gameObject);
				if (num43 > 4)
				{
					float num45 = 70f * (float)(num43 / 4 - 1);
					if (num43 % 4 > 0)
					{
						num45 += 70f;
					}
					transform.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, num45);
					num4 += num45;
				}
			}
			this.ContentT.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, num4);
			this.TimeSA = this.Main2T.GetChild(23).GetComponent<UISpritesArray>();
			this.TimeTitle = this.Main2T.GetChild(23).GetChild(0).GetComponent<UIText>();
			this.TimeTitle.font = this.tmpFont;
			this.TimeText = this.Main2T.GetChild(23).GetChild(1).GetComponent<UIText>();
			this.TimeText.font = this.tmpFont;
			this.TimeTitle2 = this.Main2T.GetChild(23).GetChild(2).GetComponent<UIText>();
			this.TimeTitle2.font = this.tmpFont;
			this.TimeTitle2.enabled = false;
			this.TimeTitle2.gameObject.SetActive(true);
			this.TimeStr = instance2.SpawnString(30);
			this.SetTimeTitle();
			this.SetTimeStr();
			this.SetStepScore(this.tmpData.EventScore);
		}
		UIButtonHint.scrollRect2 = this.Main2T.GetChild(22).GetComponent<CScrollRect>();
		if (this.ContentT != null)
		{
			if (this.AM.Act2arg1 == arg1)
			{
				this.ContentT.GetComponent<RectTransform>().anchoredPosition = this.AM.Act2Pos;
			}
			else
			{
				this.AM.Act2arg1 = arg1;
			}
		}
		this.GM.UpdateUI(EGUIWindow.Door, 1, 2);
		if (!this.tmpData.bAskDetailData)
		{
			this.AM.ChangeStateReOpenMenu(this.ActivityIndex);
		}
		if (this.tmpData.EventState == EActivityState.EAS_None)
		{
			this.Main2T.gameObject.SetActive(false);
			this.NotOpenT.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000D64 RID: 3428 RVA: 0x0015042C File Offset: 0x0014E62C
	public override void OnClose()
	{
		StringManager instance = StringManager.Instance;
		instance.DeSpawnString(this.NowScoreStr);
		instance.DeSpawnString(this.NextScoreStr);
		for (int i = 0; i < 3; i++)
		{
			instance.DeSpawnString(this.StageScore[i]);
			instance.DeSpawnString(this.GemCountText[i]);
			instance.DeSpawnString(this.TitleText2[i]);
			instance.DeSpawnString(this.TotalpriceText[i]);
			instance.DeSpawnString(this.NoPriceText[i]);
			for (int j = 0; j < this.ItemCount[i]; j++)
			{
				instance.DeSpawnString(this.ItemCountText[i][j]);
			}
		}
		for (int k = 0; k < 5; k++)
		{
			if (this.ScoreFactorRateStr[k] != null)
			{
				instance.DeSpawnString(this.ScoreFactorRateStr[k]);
			}
			if (this.ScoreFactorRateStr2[k] != null)
			{
				instance.DeSpawnString(this.ScoreFactorRateStr2[k]);
			}
		}
		for (int l = 0; l < 12; l++)
		{
			if (this.HintStrL[l] != null)
			{
				instance.DeSpawnString(this.HintStrL[l]);
			}
			if (this.HintStrR[l] != null)
			{
				instance.DeSpawnString(this.HintStrR[l]);
			}
		}
		instance.DeSpawnString(this.TimeStr);
		instance.DeSpawnString(this.RankStr);
		instance.DeSpawnString(this.ReTimeStr);
		instance.DeSpawnString(this.HintT3Str);
		instance.DeSpawnString(this.ReImageDevilStr);
		instance.DeSpawnString(this.HintStr1);
		instance.DeSpawnString(this.HintStr2);
		if (this.P3_ItemStr != null)
		{
			for (int m = 0; m < this.P3_ItemStr.Length; m++)
			{
				instance.DeSpawnString(this.P3_ItemStr[m]);
			}
		}
		if (this.HintKingdomStr != null)
		{
			for (int n = 0; n < this.HintKingdomStr.Length; n++)
			{
				instance.DeSpawnString(this.HintKingdomStr[n]);
			}
		}
		if (this.kingdomIDstr != null)
		{
			for (int num = 0; num < this.kingdomIDstr.Length; num++)
			{
				instance.DeSpawnString(this.kingdomIDstr[num]);
			}
		}
		if (this.kingdomPrizestr != null)
		{
			for (int num2 = 0; num2 < this.kingdomPrizestr.Length; num2++)
			{
				instance.DeSpawnString(this.kingdomPrizestr[num2]);
			}
		}
		for (int num3 = 0; num3 < this.ItemNameStr.Length; num3++)
		{
			if (this.ItemNameStr[num3] != null)
			{
				instance.DeSpawnString(this.ItemNameStr[num3]);
			}
		}
		for (int num4 = 0; num4 < this.Hint5Str.Length; num4++)
		{
			if (this.Hint5Str[num4] != null)
			{
				instance.DeSpawnString(this.Hint5Str[num4]);
			}
		}
		for (int num5 = 0; num5 < this.CountTimeStr.Length; num5++)
		{
			if (this.CountTimeStr[num5] != null)
			{
				instance.DeSpawnString(this.CountTimeStr[num5]);
			}
		}
		for (int num6 = 0; num6 < this.WaveStr.Length; num6++)
		{
			if (this.WaveStr[num6] != null)
			{
				instance.DeSpawnString(this.WaveStr[num6]);
			}
		}
		if (this.BossGO != null)
		{
			ModelLoader.Instance.Unload(this.BossGO);
			this.BossGO = null;
		}
		if (this.ContentT != null)
		{
			this.AM.Act2Pos = this.ContentT.GetComponent<RectTransform>().anchoredPosition;
		}
		if (this.OtherAssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.OtherAssetKey, true);
			this.OtherAB = null;
			this.OtherAssetKey = 0;
		}
		if (this.SPAssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.SPAssetKey, true);
			this.SPGO = null;
			this.SPT = null;
			this.SPAssetKey = 0;
		}
		this.GM.m_LordInfo.HideEquipVal = false;
		if (this.Npc_Node != null)
		{
			for (int num7 = 0; num7 < this.Npc_Node.Length; num7++)
			{
				if (this.Npc_Node[num7] != null)
				{
					this.Npc_Node[num7].Release();
					this.Npc_Node[num7] = null;
					AssetManager.UnloadAssetBundle(this.Npc_ABKey[num7], true);
				}
			}
		}
	}

	// Token: 0x06000D65 RID: 3429 RVA: 0x001508B8 File Offset: 0x0014EAB8
	private void LoadSP(string ABName)
	{
		if (this.ContentT == null)
		{
			return;
		}
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UIActivity2", out this.SPAssetKey, false);
		if (assetBundle == null)
		{
			return;
		}
		this.SPGO = (UnityEngine.Object.Instantiate(assetBundle.Load(ABName)) as GameObject);
		this.SPGO.transform.SetParent(this.ContentT, false);
		this.SPT = this.SPGO.transform;
		((RectTransform)this.SPT).anchoredPosition = Vector2.zero;
	}

	// Token: 0x06000D66 RID: 3430 RVA: 0x0015094C File Offset: 0x0014EB4C
	private void LoadFIFA()
	{
		if (this.tmpData.ActiveType != EActivityType.EAT_FIFA_KVK || this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
		{
			return;
		}
		if (this.SPT == null)
		{
			return;
		}
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UIActivity2", out this.FIFAAssetKey, false);
		if (assetBundle == null)
		{
			return;
		}
		this.FIFAGO = (UnityEngine.Object.Instantiate(assetBundle.Load("FIFA")) as GameObject);
		this.FIFAGO.transform.SetParent(this.SPT, false);
		this.FIFAT = this.FIFAGO.transform;
		((RectTransform)this.FIFAT).anchoredPosition = Vector2.zero;
		this.FIFASP = this.FIFAT.GetComponent<UISpritesArray>();
		this.WaveText[2] = this.FIFAT.GetChild(1).GetComponent<UIText>();
		this.WaveText[2].font = this.tmpFont;
		this.WaveText[2].text = this.DM.mStringTable.GetStringByID(14745u);
		UIButton component = this.FIFAT.GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 7;
		component.m_BtnID2 = 3;
		this.WaveText[3] = this.FIFAT.GetChild(3).GetComponent<UIText>();
		this.WaveText[3].font = this.tmpFont;
		if (this.Npc_Node == null)
		{
			this.Npc_Parent = new Transform[4];
			this.Npc_Node = new UINPC[4];
			this.Npc_ABKey = new int[4];
		}
		for (int i = 0; i < 4; i++)
		{
			Transform child = this.FIFAT.GetChild(4).GetChild(i);
			if (this.tmpData.EventState < EActivityState.EAS_HomeStart || this.tmpData.EventState > EActivityState.EAS_StartRanking)
			{
				child.GetComponent<UIButton>().m_BtnID1 = 0;
				child.GetComponent<UIButton>().m_Handler = this;
				UIButtonHint uibuttonHint = child.gameObject.AddComponent<UIButtonHint>();
				uibuttonHint.ControlFadeOut = this.m_transform.GetChild(3).gameObject;
				uibuttonHint.m_eHint = EUIButtonHint.CountDown;
				uibuttonHint.DelayTime = 0.3f;
				uibuttonHint.m_Handler = this;
				uibuttonHint.Parm1 = 6;
				uibuttonHint.Parm2 = (byte)(i + 1);
				uibuttonHint.ScrollID = 1;
			}
			this.Npc_Parent[i] = child;
			this.Npc_Node[i] = new UINPC();
			this.Npc_Node[i].SpawnNPC(Vector2.zero, 1f, 1, 210, UINPCState.UINPC_Idle, this.Npc_Parent[i], ref this.Npc_ABKey[i]);
		}
		for (int j = 0; j < 3; j++)
		{
			this.ArrowImage[j] = this.FIFAT.GetChild(4).GetChild(j + 4).GetComponent<Image>();
		}
		this.WaveText[0] = this.FIFAT.GetChild(4).GetChild(7).GetComponent<UIText>();
		this.WaveText[0].font = this.tmpFont;
		this.WaveText[1] = this.FIFAT.GetChild(4).GetChild(8).GetComponent<UIText>();
		this.WaveText[1].font = this.tmpFont;
		this.CheckNowWave(true);
		this.FIFADeltaHeight = 0f;
		if (this.tmpData.EventState == EActivityState.EAS_Run && this.NowWave <= this.AM.WaveNum)
		{
			this.WaveText[3].gameObject.SetActive(true);
			this.WaveText[3].text = this.DM.mStringTable.GetStringByID(12243u);
			this.WaveText[3].SetAllDirty();
			this.WaveText[3].cachedTextGenerator.Invalidate();
			this.WaveText[3].cachedTextGeneratorForLayout.Invalidate();
			this.FIFADeltaHeight = this.WaveText[3].preferredHeight;
			((RectTransform)this.FIFAT.GetChild(4)).anchoredPosition += new Vector2(0f, -this.FIFADeltaHeight);
		}
		this.FIFADeltaHeight += 284f;
		this.HintTFIFA = this.m_transform.GetChild(9).GetComponent<RectTransform>();
		this.WaveText[4] = this.HintTFIFA.GetChild(0).GetComponent<UIText>();
		this.WaveText[4].font = this.tmpFont;
		this.WaveText[4].alignment = TextAnchor.UpperLeft;
		this.bFIFA = true;
		Vector2 b = new Vector2(0f, -this.FIFADeltaHeight);
		if (this.AM.MatchKingdomCount == 4)
		{
			((RectTransform)this.FIFAT).anchoredPosition = new Vector2(0f, -345f);
			this.SPT.GetChild(0).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(1).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(2).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(20).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(21).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(22).GetComponent<RectTransform>().anchoredPosition += b;
		}
		else if (this.AM.MatchKingdomCount == 3)
		{
			((RectTransform)this.FIFAT).anchoredPosition = new Vector2(0f, -272f);
			this.SPT.GetChild(0).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(1).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(16).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(17).GetComponent<RectTransform>().anchoredPosition += b;
		}
		else
		{
			((RectTransform)this.FIFAT).anchoredPosition = new Vector2(0f, -232f);
			this.SPT.GetChild(0).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(1).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(10).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(11).GetComponent<RectTransform>().anchoredPosition += b;
		}
		this.ContentT.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, this.FIFADeltaHeight);
	}

	// Token: 0x06000D67 RID: 3431 RVA: 0x00151094 File Offset: 0x0014F294
	private void HideFIFA_KvKBallInfo()
	{
		if (this.SPT == null || this.ContentT == null || this.WaveText[3] == null || this.FIFAT == null || !this.WaveText[3].gameObject.activeSelf)
		{
			return;
		}
		Vector2 b = new Vector2(0f, this.WaveText[3].preferredHeight);
		if (this.AM.MatchKingdomCount == 4)
		{
			this.SPT.GetChild(0).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(1).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(2).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(20).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(21).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(22).GetComponent<RectTransform>().anchoredPosition += b;
		}
		else if (this.AM.MatchKingdomCount == 3)
		{
			this.SPT.GetChild(0).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(1).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(16).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(17).GetComponent<RectTransform>().anchoredPosition += b;
		}
		else
		{
			this.SPT.GetChild(0).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(1).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(10).GetComponent<RectTransform>().anchoredPosition += b;
			this.SPT.GetChild(11).GetComponent<RectTransform>().anchoredPosition += b;
		}
		((RectTransform)this.FIFAT.GetChild(4)).anchoredPosition += b;
		this.ContentT.GetComponent<RectTransform>().sizeDelta -= b;
		this.WaveText[3].gameObject.SetActive(false);
	}

	// Token: 0x06000D68 RID: 3432 RVA: 0x00151378 File Offset: 0x0014F578
	private void SetRight(byte SelectIndex)
	{
		if (this.tmpData.GroupCount == 0)
		{
			return;
		}
		if (SelectIndex < 0 || SelectIndex >= this.tmpData.GroupCount)
		{
			return;
		}
		byte b = this.tmpData.NobilityGroupDataSortIndex[(int)SelectIndex];
		EActivityState eventState = this.tmpData.NobilityGroupData[(int)b].EventState;
		bool flag = this.AM.FederalActKingdomWonderID != 0 && this.tmpData.NobilityGroupData[(int)b].WonderID == this.AM.FederalActKingdomWonderID;
		if (this.AM.NW_UI_SelectWonderID == -1)
		{
			this.AM.NW_UI_SelectWonderID = (int)this.tmpData.NobilityGroupData[(int)b].WonderID;
		}
		this.NWText.text = this.DM.mStringTable.GetStringByID(3734u);
		this.NW_New.gameObject.SetActive(false);
		if (this.tmpData.EventState == EActivityState.EAS_Prepare || this.tmpData.EventState == EActivityState.EAS_Run)
		{
			byte b2 = this.tmpData.NobilityGroupDataIndex[(int)this.AM.FederalActKingdomWonderID];
			if (this.AM.FederalActKingdomID != 0 && this.tmpData.NobilityGroupData[(int)b2].EventState == EActivityState.EAS_ReplayRanking)
			{
				this.NWText.text = this.DM.mStringTable.GetStringByID(3714u);
				this.NWText.SetAllDirty();
				this.NWText.cachedTextGenerator.Invalidate();
				this.NWText.cachedTextGeneratorForLayout.Invalidate();
				this.NW_New.rectTransform.anchoredPosition = new Vector2(-(this.NWText.preferredWidth / 2f) - 30f, this.NW_New.rectTransform.anchoredPosition.y);
				this.NW_New.gameObject.SetActive(true);
			}
			else if (this.AM.FederalActKingdomID == 0)
			{
				this.NWText.text = this.DM.mStringTable.GetStringByID(1353u);
				this.NWText.SetAllDirty();
				this.NWText.cachedTextGenerator.Invalidate();
				this.NWText.cachedTextGeneratorForLayout.Invalidate();
				this.NW_New.rectTransform.anchoredPosition = new Vector2(-(this.NWText.preferredWidth / 2f) - 30f, this.NW_New.rectTransform.anchoredPosition.y);
				this.NW_New.gameObject.SetActive(true);
			}
			else if (this.GM.BuildingData.GetBuildData(8, 0).Level < 25)
			{
				this.NWText.text = this.DM.mStringTable.GetStringByID(3715u);
				this.NWText.SetAllDirty();
				this.NWText.cachedTextGenerator.Invalidate();
				this.NWText.cachedTextGeneratorForLayout.Invalidate();
				this.NW_New.rectTransform.anchoredPosition = new Vector2(-(this.NWText.preferredWidth / 2f) - 30f, this.NW_New.rectTransform.anchoredPosition.y);
				this.NW_New.gameObject.SetActive(true);
			}
			else if (this.AM.FederalActKingdomWonderID != this.AM.FederalHomeKingdomWonderID)
			{
				if (this.ItemNameStr[2] == null)
				{
					this.ItemNameStr[2] = StringManager.Instance.SpawnString(300);
				}
				this.ItemNameStr[2].Length = 0;
				this.ItemNameStr[2].IntToFormat((long)this.AM.FederalActKingdomID, 1, false);
				this.ItemNameStr[2].AppendFormat(this.DM.mStringTable.GetStringByID(3716u));
				this.NWText.text = this.ItemNameStr[2].ToString();
				this.NWText.SetAllDirty();
				this.NWText.cachedTextGenerator.Invalidate();
				this.NWText.cachedTextGeneratorForLayout.Invalidate();
				this.NW_New.rectTransform.anchoredPosition = new Vector2(-(this.NWText.preferredWidth / 2f) - 30f, this.NW_New.rectTransform.anchoredPosition.y);
				this.NW_New.gameObject.SetActive(true);
			}
		}
		if (eventState == EActivityState.EAS_Prepare || eventState == EActivityState.EAS_Run)
		{
			if ((eventState == EActivityState.EAS_Prepare && !this.tmpData.NobilityGroupData[(int)b].bAskPrizeData) || (eventState == EActivityState.EAS_Run && !this.tmpData.NobilityGroupData[(int)b].bAskKingdomData))
			{
				this.AM.Send_FEDERAL_ORDERDETAIL(this.tmpData.NobilityGroupData[(int)b].WonderID);
				return;
			}
			this.RightObject_RP.SetActive(false);
			this.RightObject_Prize.SetActive(true);
			this.RightObject_Part1.SetActive(false);
			this.NWText.gameObject.SetActive(true);
			this.RightObject_KingdomBtn.SetActive(false);
			bool flag2 = false;
			this.ContentT.GetComponent<RectTransform>().sizeDelta = this.ContentSize;
			this.ContentT.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			if (flag)
			{
				if (this.GM.BuildingData.GetBuildData(8, 0).Level < 25)
				{
					this.RightObject_Part1.SetActive(true);
					flag2 = true;
					this.P1_TitleText.text = this.DM.mStringTable.GetStringByID(3715u);
					this.ContentT.GetComponent<RectTransform>().sizeDelta = this.ContentSize + new Vector2(0f, 45f);
				}
				else if (this.tmpData.NobilityGroupData[(int)b].WonderID == this.AM.FederalActKingdomWonderID && this.AM.FederalActKingdomWonderID != this.AM.FederalHomeKingdomWonderID)
				{
					this.RightObject_Part1.SetActive(true);
					flag2 = true;
					if (this.ItemNameStr[2] == null)
					{
						this.ItemNameStr[2] = StringManager.Instance.SpawnString(300);
					}
					this.ItemNameStr[2].Length = 0;
					this.ItemNameStr[2].IntToFormat((long)this.AM.FederalActKingdomID, 1, false);
					this.ItemNameStr[2].AppendFormat(this.DM.mStringTable.GetStringByID(3716u));
					this.P1_TitleText.text = this.ItemNameStr[2].ToString();
					this.P1_TitleText.SetAllDirty();
					this.P1_TitleText.cachedTextGenerator.Invalidate();
					this.ContentT.GetComponent<RectTransform>().sizeDelta = this.ContentSize + new Vector2(0f, 45f);
				}
			}
			if (flag2)
			{
				this.P2RC.anchoredPosition = new Vector2(0f, -45f);
				this.P3RC.anchoredPosition = new Vector2(0f, -387f);
			}
			else
			{
				this.P2RC.anchoredPosition = new Vector2(0f, 0f);
				this.P3RC.anchoredPosition = new Vector2(0f, -342f);
			}
			this.RBText[7].text = this.DM.mStringTable.GetStringByID(3649u);
			this.RBText[7].SetAllDirty();
			this.RBText[7].cachedTextGenerator.Invalidate();
			if (flag)
			{
				if (this.ItemNameStr[3] == null)
				{
					this.ItemNameStr[3] = StringManager.Instance.SpawnString(300);
				}
				this.ItemNameStr[3].Length = 0;
				if (this.AM.FederalActKingdomWonderID != this.AM.FederalHomeKingdomWonderID)
				{
					this.ItemNameStr[3].IntToFormat((long)this.AM.FederalActKingdomID, 1, false);
				}
				else
				{
					this.ItemNameStr[3].IntToFormat((long)DataManager.MapDataController.kingdomData.kingdomID, 1, false);
				}
				this.ItemNameStr[3].AppendFormat(this.DM.mStringTable.GetStringByID(3650u));
				this.P2_KingdomIDText.text = this.ItemNameStr[3].ToString();
				this.P2_KingdomIDText.SetAllDirty();
				this.P2_KingdomIDText.cachedTextGenerator.Invalidate();
				this.P2_KingdomIDText.cachedTextGeneratorForLayout.Invalidate();
				this.MyKingdom_prize.SetActive(true);
			}
			else
			{
				this.MyKingdom_prize.SetActive(false);
			}
			this.P2_WonderNameText.text = DataManager.MapDataController.GetYolkName((ushort)this.tmpData.NobilityGroupData[(int)b].WonderID, this.tmpData.NobilityGroupData[(int)b].KingdomID).ToString();
			this.P2_WonderNameText.SetAllDirty();
			this.P2_WonderNameText.cachedTextGenerator.Invalidate();
			this.P2_WonderNameText.cachedTextGeneratorForLayout.Invalidate();
			this.P2_WonderNameRC.sizeDelta = new Vector2(this.P2_WonderNameText.preferredWidth + 1f, this.P2_WonderNameRC.sizeDelta.y);
			this.P2_WonderNameLeftImgRC.anchoredPosition = new Vector2(241f - (this.P2_WonderNameRC.sizeDelta.x + this.P2_WonderNameLeftImgRC.sizeDelta.x) / 2f, this.P2_WonderNameLeftImgRC.anchoredPosition.y);
			Vector2 yolkPos = DataManager.MapDataController.GetYolkPos((ushort)this.tmpData.NobilityGroupData[(int)b].WonderID, this.tmpData.NobilityGroupData[(int)b].KingdomID);
			if (this.ItemNameStr[4] == null)
			{
				this.ItemNameStr[4] = StringManager.Instance.SpawnString(30);
			}
			this.ItemNameStr[4].Length = 0;
			this.ItemNameStr[4].IntToFormat((long)this.tmpData.NobilityGroupData[(int)b].KingdomID, 1, false);
			this.ItemNameStr[4].IntToFormat((long)((int)yolkPos.x), 1, false);
			this.ItemNameStr[4].IntToFormat((long)((int)yolkPos.y), 1, false);
			if (this.GM.IsArabic)
			{
				this.ItemNameStr[4].AppendFormat("{0}:K {1}:X {2}:Y");
			}
			else
			{
				this.ItemNameStr[4].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
			}
			this.P2_WonderPosText.text = this.ItemNameStr[4].ToString();
			this.P2_WonderPosText.SetAllDirty();
			this.P2_WonderPosText.cachedTextGenerator.Invalidate();
			this.P2_WonderPosText.cachedTextGeneratorForLayout.Invalidate();
			this.P2_WonderPosRC.sizeDelta = new Vector2(this.P2_WonderPosText.preferredWidth + 1f, this.P2_WonderPosRC.sizeDelta.y);
			ushort itemID = this.tmpData.NobilityGroupData[(int)b].PreparePrize[0][0].ItemID;
			byte rank = this.tmpData.NobilityGroupData[(int)b].PreparePrize[0][0].Rank;
			byte num = this.tmpData.NobilityGroupData[(int)b].PreparePrize[0][0].Num;
			Equip recordByKey = this.DM.EquipTable.GetRecordByKey(itemID);
			if (recordByKey.EquipKey == itemID)
			{
				bool flag3 = this.GM.IsLeadItem(recordByKey.EquipKind);
				if (flag3)
				{
					this.P3_1stItem.GetChild(0).gameObject.SetActive(false);
					this.P3_1stItem.GetChild(1).gameObject.SetActive(true);
					this.GM.ChangeLordEquipImg(this.P3_1stItem.GetChild(1), itemID, rank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				}
				else
				{
					this.P3_1stItem.GetChild(0).gameObject.SetActive(true);
					this.P3_1stItem.GetChild(1).gameObject.SetActive(false);
					this.GM.ChangeHeroItemImg(this.P3_1stItem.GetChild(0), eHeroOrItem.Item, itemID, 0, rank, 0);
					if (MallManager.Instance.CheckCanOpenDetail(itemID))
					{
						this.P3_1stItem.GetChild(0).GetComponent<UIButtonHint>().enabled = false;
					}
					else
					{
						this.P3_1stItem.GetChild(0).GetComponent<UIButtonHint>().enabled = true;
					}
				}
				if (num > 1)
				{
					this.P3_ItemStr[0].Length = 0;
					this.P3_ItemStr[0].IntToFormat((long)num, 1, true);
					if (this.GM.IsArabic)
					{
						this.P3_ItemStr[0].AppendFormat("{0}x");
					}
					else
					{
						this.P3_ItemStr[0].AppendFormat("x{0}");
					}
					this.P3_ItemText[0].text = this.P3_ItemStr[0].ToString();
					this.P3_ItemText[0].SetAllDirty();
					this.P3_ItemText[0].cachedTextGenerator.Invalidate();
					this.P3_ItemText[0].gameObject.SetActive(true);
				}
				else
				{
					this.P3_ItemText[0].gameObject.SetActive(false);
				}
			}
			itemID = this.tmpData.NobilityGroupData[(int)b].PreparePrize[0][1].ItemID;
			rank = this.tmpData.NobilityGroupData[(int)b].PreparePrize[0][1].Rank;
			num = this.tmpData.NobilityGroupData[(int)b].PreparePrize[0][1].Num;
			if (this.ItemNameStr[5] == null)
			{
				this.ItemNameStr[5] = StringManager.Instance.SpawnString(100);
			}
			this.ItemNameStr[5].Length = 0;
			if (itemID > 0)
			{
				recordByKey = this.DM.EquipTable.GetRecordByKey(itemID);
				if (recordByKey.EquipKey == itemID)
				{
					this.ItemNameStr[5].IntToFormat((long)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue * (ushort)num), 1, true);
					this.ItemNameStr[5].AppendFormat("x{0}");
				}
			}
			this.P3_CrystalText.text = this.ItemNameStr[5].ToString();
			this.P3_CrystalText.SetAllDirty();
			this.P3_CrystalText.cachedTextGenerator.Invalidate();
			itemID = this.tmpData.NobilityGroupData[(int)b].PreparePrize[0][2].ItemID;
			rank = this.tmpData.NobilityGroupData[(int)b].PreparePrize[0][2].Rank;
			num = this.tmpData.NobilityGroupData[(int)b].PreparePrize[0][2].Num;
			if (this.ItemNameStr[6] == null)
			{
				this.ItemNameStr[6] = StringManager.Instance.SpawnString(100);
			}
			this.ItemNameStr[6].Length = 0;
			if (itemID > 0)
			{
				recordByKey = this.DM.EquipTable.GetRecordByKey(itemID);
				if (recordByKey.EquipKey == itemID)
				{
					this.ItemNameStr[6].IntToFormat((long)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue * (ushort)num), 1, true);
					this.ItemNameStr[6].AppendFormat("x{0}");
				}
			}
			this.P3_MoneyText.text = this.ItemNameStr[6].ToString();
			this.P3_MoneyText.SetAllDirty();
			this.P3_MoneyText.cachedTextGenerator.Invalidate();
			itemID = this.tmpData.NobilityGroupData[(int)b].PreparePrize[1][0].ItemID;
			rank = this.tmpData.NobilityGroupData[(int)b].PreparePrize[1][0].Rank;
			num = this.tmpData.NobilityGroupData[(int)b].PreparePrize[1][0].Num;
			recordByKey = this.DM.EquipTable.GetRecordByKey(itemID);
			if (recordByKey.EquipKey == itemID)
			{
				bool flag4 = this.GM.IsLeadItem(recordByKey.EquipKind);
				if (flag4)
				{
					this.P3_2ndItem.GetChild(0).gameObject.SetActive(false);
					this.P3_2ndItem.GetChild(1).gameObject.SetActive(true);
					this.GM.ChangeLordEquipImg(this.P3_2ndItem.GetChild(1), itemID, rank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				}
				else
				{
					this.P3_2ndItem.GetChild(0).gameObject.SetActive(true);
					this.P3_2ndItem.GetChild(1).gameObject.SetActive(false);
					this.GM.ChangeHeroItemImg(this.P3_2ndItem.GetChild(0), eHeroOrItem.Item, itemID, 0, rank, 0);
					if (MallManager.Instance.CheckCanOpenDetail(itemID))
					{
						this.P3_2ndItem.GetChild(0).GetComponent<UIButtonHint>().enabled = false;
					}
					else
					{
						this.P3_2ndItem.GetChild(0).GetComponent<UIButtonHint>().enabled = true;
					}
				}
				if (num > 1)
				{
					this.P3_ItemStr[1].Length = 0;
					this.P3_ItemStr[1].IntToFormat((long)num, 1, true);
					if (this.GM.IsArabic)
					{
						this.P3_ItemStr[1].AppendFormat("{0}x");
					}
					else
					{
						this.P3_ItemStr[1].AppendFormat("x{0}");
					}
					this.P3_ItemText[1].text = this.P3_ItemStr[1].ToString();
					this.P3_ItemText[1].SetAllDirty();
					this.P3_ItemText[1].cachedTextGenerator.Invalidate();
					this.P3_ItemText[1].gameObject.SetActive(true);
				}
				else
				{
					this.P3_ItemText[1].gameObject.SetActive(false);
				}
			}
			itemID = this.tmpData.NobilityGroupData[(int)b].PreparePrize[2][0].ItemID;
			rank = this.tmpData.NobilityGroupData[(int)b].PreparePrize[2][0].Rank;
			num = this.tmpData.NobilityGroupData[(int)b].PreparePrize[2][0].Num;
			recordByKey = this.DM.EquipTable.GetRecordByKey(itemID);
			if (recordByKey.EquipKey == itemID)
			{
				bool flag5 = this.GM.IsLeadItem(recordByKey.EquipKind);
				if (flag5)
				{
					this.P3_3rdItem.GetChild(0).gameObject.SetActive(false);
					this.P3_3rdItem.GetChild(1).gameObject.SetActive(true);
					this.GM.ChangeLordEquipImg(this.P3_3rdItem.GetChild(1), itemID, rank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				}
				else
				{
					this.P3_3rdItem.GetChild(0).gameObject.SetActive(true);
					this.P3_3rdItem.GetChild(1).gameObject.SetActive(false);
					this.GM.ChangeHeroItemImg(this.P3_3rdItem.GetChild(0), eHeroOrItem.Item, itemID, 0, rank, 0);
					if (MallManager.Instance.CheckCanOpenDetail(itemID))
					{
						this.P3_3rdItem.GetChild(0).GetComponent<UIButtonHint>().enabled = false;
					}
					else
					{
						this.P3_3rdItem.GetChild(0).GetComponent<UIButtonHint>().enabled = true;
					}
				}
				if (num > 1)
				{
					this.P3_ItemStr[2].Length = 0;
					this.P3_ItemStr[2].IntToFormat((long)num, 1, true);
					if (this.GM.IsArabic)
					{
						this.P3_ItemStr[2].AppendFormat("{0}x");
					}
					else
					{
						this.P3_ItemStr[2].AppendFormat("x{0}");
					}
					this.P3_ItemText[2].text = this.P3_ItemStr[2].ToString();
					this.P3_ItemText[2].SetAllDirty();
					this.P3_ItemText[2].cachedTextGenerator.Invalidate();
					this.P3_ItemText[2].gameObject.SetActive(true);
				}
				else
				{
					this.P3_ItemText[2].gameObject.SetActive(false);
				}
			}
			if (eventState == EActivityState.EAS_Run)
			{
				this.P2_FightX.SetActive(true);
			}
			else
			{
				this.P2_FightX.SetActive(false);
			}
			if (eventState == EActivityState.EAS_Run)
			{
				if (this.HintT2 != null)
				{
					this.HintT2.gameObject.SetActive(false);
				}
				this.HintT2 = this.HintKingdom;
				int num2 = 0;
				ushort num3 = 0;
				if (flag)
				{
					if (this.AM.FederalActKingdomWonderID != this.AM.FederalHomeKingdomWonderID)
					{
						num3 = this.AM.FederalActKingdomID;
					}
					else
					{
						num3 = DataManager.MapDataController.kingdomData.kingdomID;
					}
					this.HintObject[num2].SetActive(true);
					this.HintKingdomStr[num2].Length = 0;
					this.HintKingdomStr[num2].IntToFormat((long)num3, 1, false);
					this.HintKingdomStr[num2].AppendFormat("#{0}");
					this.HintKingdomText[num2].text = this.HintKingdomStr[num2].ToString();
					this.HintKingdomText[num2].SetAllDirty();
					this.HintKingdomText[num2].cachedTextGenerator.Invalidate();
					num2++;
					this.HintTargetImageGO.SetActive(true);
				}
				else
				{
					this.HintTargetImageGO.SetActive(false);
				}
				int num4 = 0;
				while (num4 < 50 && num2 < 50)
				{
					if (num4 >= (int)this.tmpData.NobilityGroupData[(int)b].FightKingdomCount)
					{
						this.HintObject[num2].SetActive(false);
						goto IL_1746;
					}
					if (!flag || num3 != this.tmpData.NobilityGroupData[(int)b].FightKingdomID[num4])
					{
						this.HintObject[num2].SetActive(true);
						this.HintKingdomStr[num2].Length = 0;
						this.HintKingdomStr[num2].IntToFormat((long)this.tmpData.NobilityGroupData[(int)b].FightKingdomID[num4], 1, false);
						this.HintKingdomStr[num2].AppendFormat("#{0}");
						this.HintKingdomText[num2].text = this.HintKingdomStr[num2].ToString();
						this.HintKingdomText[num2].SetAllDirty();
						this.HintKingdomText[num2].cachedTextGenerator.Invalidate();
						goto IL_1746;
					}
					IL_174C:
					num4++;
					continue;
					IL_1746:
					num2++;
					goto IL_174C;
				}
				this.HintKingdom.sizeDelta = new Vector2(this.HintKingdom.sizeDelta.x, (float)(118 + (this.tmpData.NobilityGroupData[(int)b].FightKingdomCount - 1) / 4 * 45));
				if (-(this.HintKingdom.anchoredPosition.y - this.HintKingdom.sizeDelta.y) > this.Sizey - 100f)
				{
					this.HintKingdom.anchoredPosition = new Vector2(this.HintKingdom.anchoredPosition.x, -this.Sizey + this.HintKingdom.sizeDelta.y + 100f);
				}
				if (this.HintKingdom.anchoredPosition.y > 0f)
				{
					this.HintKingdom.anchoredPosition = new Vector2(this.HintKingdom.anchoredPosition.x, 0f);
				}
			}
			else
			{
				if (this.HintT2 != null)
				{
					this.HintT2.gameObject.SetActive(false);
				}
				this.HintT2 = this.HintNormal;
				if (flag)
				{
					if (this.ItemNameStr[7] == null)
					{
						this.ItemNameStr[7] = StringManager.Instance.SpawnString(500);
					}
					this.ItemNameStr[7].Length = 0;
					this.ItemNameStr[7].IntToFormat((long)this.AM.FederalActKingdomID, 1, false);
					this.ItemNameStr[7].AppendFormat(this.DM.mStringTable.GetStringByID(3781u));
					this.RBText3[5].text = this.ItemNameStr[7].ToString();
					this.RBText3[5].SetAllDirty();
					this.RBText3[5].cachedTextGenerator.Invalidate();
				}
				else
				{
					this.RBText3[5].text = this.DM.mStringTable.GetStringByID(3754u);
				}
				float num5 = this.RBText3[5].preferredHeight + 1f;
				this.RBText3[5].rectTransform.sizeDelta = new Vector2(this.RBText3[5].rectTransform.sizeDelta.x, num5);
				this.HintT2.sizeDelta = new Vector2(this.HintT2.sizeDelta.x, num5 + 30f);
			}
		}
		else
		{
			if (!this.tmpData.NobilityGroupData[(int)b].bAskNobilityData)
			{
				this.AM.Send_FEDERAL_ORDERDETAIL(this.tmpData.NobilityGroupData[(int)b].WonderID);
				return;
			}
			this.RightObject_RP.SetActive(true);
			this.RightObject_Prize.SetActive(false);
			this.RightObject_Part1.SetActive(false);
			this.RightObject_KingdomBtn.SetActive(true);
			this.RBText[7].text = DataManager.MapDataController.GetYolkName((ushort)this.tmpData.NobilityGroupData[(int)b].WonderID, this.tmpData.NobilityGroupData[(int)b].KingdomID).ToString();
			this.RBText[7].SetAllDirty();
			this.RBText[7].cachedTextGenerator.Invalidate();
			if (this.HintT2 != null)
			{
				this.HintT2.gameObject.SetActive(false);
			}
			if (flag)
			{
				if (this.ItemNameStr[2] == null)
				{
					this.ItemNameStr[2] = StringManager.Instance.SpawnString(300);
				}
				this.ItemNameStr[2].Length = 0;
				if (this.AM.FederalActKingdomWonderID != this.AM.FederalHomeKingdomWonderID)
				{
					this.ItemNameStr[2].IntToFormat((long)this.AM.FederalActKingdomID, 1, false);
				}
				else
				{
					this.ItemNameStr[2].IntToFormat((long)DataManager.MapDataController.kingdomData.kingdomID, 1, false);
				}
				this.ItemNameStr[2].AppendFormat(this.DM.mStringTable.GetStringByID(3650u));
				this.RP_KingdomIDText.text = this.ItemNameStr[2].ToString();
				this.RP_KingdomIDText.SetAllDirty();
				this.RP_KingdomIDText.cachedTextGenerator.Invalidate();
				this.RP_KingdomIDText.cachedTextGeneratorForLayout.Invalidate();
				this.HintT2 = this.HintNormal;
				if (this.ItemNameStr[7] == null)
				{
					this.ItemNameStr[7] = StringManager.Instance.SpawnString(500);
				}
				this.ItemNameStr[7].Length = 0;
				this.ItemNameStr[7].IntToFormat((long)this.AM.FederalActKingdomID, 1, false);
				this.ItemNameStr[7].AppendFormat(this.DM.mStringTable.GetStringByID(3714u));
				this.RBText3[5].text = this.ItemNameStr[7].ToString();
				this.RBText3[5].SetAllDirty();
				this.RBText3[5].cachedTextGenerator.Invalidate();
				float num6 = this.RBText3[5].preferredHeight + 1f;
				this.RBText3[5].rectTransform.sizeDelta = new Vector2(this.RBText3[5].rectTransform.sizeDelta.x, num6);
				this.HintT2.sizeDelta = new Vector2(this.HintT2.sizeDelta.x, num6 + 30f);
				this.HintT2.anchoredPosition3D = new Vector3(this.HintT2.anchoredPosition3D.x, this.HintT2.anchoredPosition3D.y, -790f);
				this.MyKingdom_RP.SetActive(true);
			}
			else
			{
				this.MyKingdom_RP.SetActive(false);
			}
			if (this.ItemNameStr[3] == null)
			{
				this.ItemNameStr[3] = StringManager.Instance.SpawnString(150);
			}
			this.ItemNameStr[3].Length = 0;
			this.ItemNameStr[3].Append(this.DM.mStringTable.GetStringByID(11057u));
			this.ItemNameStr[3].Append(' ');
			this.ItemNameStr[3].Append(this.tmpData.NobilityGroupData[(int)b].NobilityName);
			this.RP_NameText.text = this.ItemNameStr[3].ToString();
			this.RP_NameText.SetAllDirty();
			this.RP_NameText.cachedTextGenerator.Invalidate();
			this.RP_NameText.cachedTextGeneratorForLayout.Invalidate();
			if (this.RP_NameText.preferredWidth + 4f > 251.3f)
			{
				this.RP_NameImage.rectTransform.sizeDelta = new Vector2(251.3f, this.RP_NameImage.rectTransform.sizeDelta.y);
			}
			else
			{
				this.RP_NameImage.rectTransform.sizeDelta = new Vector2(this.RP_NameText.preferredWidth + 4f, this.RP_NameImage.rectTransform.sizeDelta.y);
			}
			this.HeroID = this.tmpData.NobilityGroupData[(int)b].NobilityHeroID;
			this.sHero = this.DM.HeroTable.GetRecordByKey(this.tmpData.NobilityGroupData[(int)b].NobilityHeroID);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat((long)this.sHero.Modle, 5, false);
			cstring.AppendFormat("Role/hero_{0}");
			if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, this.sHero.Modle, false))
			{
				this.LoadAB(true);
			}
		}
	}

	// Token: 0x06000D69 RID: 3433 RVA: 0x001532E0 File Offset: 0x001514E0
	private void UpdateTime()
	{
		if (this.tmpData == null || this.tmpData.EventState == EActivityState.EAS_None)
		{
			return;
		}
		if (this.bNobilityWar)
		{
			for (int i = 0; i < 7; i++)
			{
				if (this.bFindScrollComp[i] && this.Scroll_Comp[i].ItemGO.activeInHierarchy && this.Scroll_Comp[i].bShowCountTime)
				{
					this.SetGroupTimeStr(i);
				}
			}
		}
		if (this.bKVKForFourth)
		{
			this.SetKVKReTime();
		}
		if (this.bFIFA)
		{
			this.SetWaveTimeText();
		}
	}

	// Token: 0x06000D6A RID: 3434 RVA: 0x00153390 File Offset: 0x00151590
	private void SetGroupTimeStr(int ScrollIndex)
	{
		if (this.tmpData.NobilityGroupData == null)
		{
			return;
		}
		byte b = this.tmpData.NobilityGroupDataSortIndex[(int)this.Scroll_Comp[ScrollIndex].DataIndex];
		if (b >= 0 && (int)b < this.tmpData.NobilityGroupData.Length)
		{
			switch (this.tmpData.NobilityGroupData[(int)b].EventState)
			{
			case EActivityState.EAS_None:
				this.tmpData.NobilityGroupData[(int)b].EventCountTime = 0L;
				break;
			case EActivityState.EAS_Run:
			case EActivityState.EAS_HomeStart:
			case EActivityState.EAS_HomeEnd:
			case EActivityState.EAS_StartRanking:
			case EActivityState.EAS_ReplayRanking:
				this.tmpData.NobilityGroupData[(int)b].EventCountTime = this.tmpData.NobilityGroupData[(int)b].EventBeginTime + (long)((ulong)this.tmpData.NobilityGroupData[(int)b].EventRequireTime) - this.DM.ServerTime;
				break;
			case EActivityState.EAS_Prepare:
				this.tmpData.NobilityGroupData[(int)b].EventCountTime = this.tmpData.NobilityGroupData[(int)b].EventBeginTime - this.DM.ServerTime;
				break;
			}
			if (this.tmpData.NobilityGroupData[(int)b].EventCountTime < 0L)
			{
				this.tmpData.NobilityGroupData[(int)b].EventCountTime = 0L;
			}
			this.CountTimeStr[ScrollIndex].Length = 0;
			if (this.tmpData.NobilityGroupData[(int)b].EventState == EActivityState.EAS_Prepare)
			{
				this.Scroll_Comp[ScrollIndex].CountTimeText.color = this.NW_YellowColor;
				this.CountTimeStr[ScrollIndex].Append(this.DM.mStringTable.GetStringByID(8111u));
			}
			else
			{
				this.Scroll_Comp[ScrollIndex].CountTimeText.color = this.NW_GreenColor;
				this.CountTimeStr[ScrollIndex].Append(this.DM.mStringTable.GetStringByID(8110u));
			}
			this.CountTimeStr[ScrollIndex].Append(' ');
			CString cstring = StringManager.Instance.StaticString1024();
			GameConstants.GetTimeString(cstring, (uint)this.tmpData.NobilityGroupData[(int)b].EventCountTime, false, false, true, false, true);
			this.CountTimeStr[ScrollIndex].Append(cstring);
			this.Scroll_Comp[ScrollIndex].CountTimeText.text = this.CountTimeStr[ScrollIndex].ToString();
			this.Scroll_Comp[ScrollIndex].CountTimeText.SetAllDirty();
			this.Scroll_Comp[ScrollIndex].CountTimeText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06000D6B RID: 3435 RVA: 0x00153658 File Offset: 0x00151858
	private void Refresh_NWLeftList()
	{
		if (this.tmpData.GroupCount == 0)
		{
			return;
		}
		this.NowHeightList.Clear();
		for (int i = 0; i < this.tmpData.NobilityGroupData.Length; i++)
		{
			this.NowHeightList.Add(78f);
		}
		this.Scroll.AddNewDataHeight(this.NowHeightList, true, true);
	}

	// Token: 0x06000D6C RID: 3436 RVA: 0x001536C4 File Offset: 0x001518C4
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId == 1 && panelObjectIdx < 7)
		{
			if (!this.bFindScrollComp[panelObjectIdx])
			{
				this.bFindScrollComp[panelObjectIdx] = true;
				Transform transform = item.transform;
				this.Scroll_Comp[panelObjectIdx].ItemGO = item;
				this.Scroll_Comp[panelObjectIdx].ScrollItem = transform.GetComponent<ScrollPanelItem>();
				this.Scroll_Comp[panelObjectIdx].ScrollItem.m_BtnID2 = panelObjectIdx;
				this.Scroll_Comp[panelObjectIdx].BackImage = transform.GetChild(0).GetComponent<Image>();
				this.Scroll_Comp[panelObjectIdx].SA = transform.GetChild(0).GetComponent<UISpritesArray>();
				this.Scroll_Comp[panelObjectIdx].MyGroupImg = transform.GetChild(0).GetChild(0).GetComponent<Image>();
				this.Scroll_Comp[panelObjectIdx].ActivityTimeText = transform.GetChild(0).GetChild(1).GetComponent<UIText>();
				this.Scroll_Comp[panelObjectIdx].CountTimeText = transform.GetChild(0).GetChild(2).GetComponent<UIText>();
				this.Scroll_Comp[panelObjectIdx].SelectImage = transform.GetChild(0).GetChild(3).GetComponent<Image>();
				this.CountTimeStr[panelObjectIdx] = StringManager.Instance.SpawnString(30);
			}
			if (this.tmpData.GroupCount == 0)
			{
				return;
			}
			if (dataIdx < 0 || dataIdx >= (int)this.tmpData.GroupCount)
			{
				return;
			}
			byte b = this.tmpData.NobilityGroupDataSortIndex[dataIdx];
			if (b < 0 || (int)b >= this.tmpData.NobilityGroupData.Length)
			{
				return;
			}
			bool flag = dataIdx == 0;
			bool flag2 = this.AM.FederalActKingdomWonderID != 0 && this.tmpData.NobilityGroupData[(int)b].WonderID == this.AM.FederalActKingdomWonderID;
			this.Scroll_Comp[panelObjectIdx].DataIndex = (byte)dataIdx;
			this.Scroll_Comp[panelObjectIdx].bShowCountTime = (flag || flag2);
			if (flag && this.tmpData.NobilityGroupData[(int)b].EventState == EActivityState.EAS_Prepare)
			{
				this.Scroll_Comp[panelObjectIdx].SA.SetSpriteIndex(1);
			}
			else if (flag && this.tmpData.NobilityGroupData[(int)b].EventState == EActivityState.EAS_Run)
			{
				this.Scroll_Comp[panelObjectIdx].SA.SetSpriteIndex(2);
			}
			else if (this.tmpData.NobilityGroupData[(int)b].EventState == EActivityState.EAS_ReplayRanking)
			{
				this.Scroll_Comp[panelObjectIdx].SA.SetSpriteIndex(3);
			}
			else
			{
				this.Scroll_Comp[panelObjectIdx].SA.SetSpriteIndex(0);
			}
			if (flag2)
			{
				this.Scroll_Comp[panelObjectIdx].MyGroupImg.gameObject.SetActive(true);
			}
			else
			{
				this.Scroll_Comp[panelObjectIdx].MyGroupImg.gameObject.SetActive(false);
			}
			this.Scroll_Comp[panelObjectIdx].ActivityTimeText.text = this.tmpData.NobilityGroupData[(int)b].EventTimeStr.ToString();
			if (this.tmpData.NobilityGroupData[(int)b].EventState != EActivityState.EAS_ReplayRanking && (flag || flag2))
			{
				this.Scroll_Comp[panelObjectIdx].ActivityTimeText.alignment = TextAnchor.UpperLeft;
				this.Scroll_Comp[panelObjectIdx].CountTimeText.gameObject.SetActive(true);
				this.SetGroupTimeStr(panelObjectIdx);
			}
			else
			{
				this.Scroll_Comp[panelObjectIdx].ActivityTimeText.alignment = TextAnchor.MiddleLeft;
				this.Scroll_Comp[panelObjectIdx].CountTimeText.gameObject.SetActive(false);
			}
			if (this.Scroll_Comp[panelObjectIdx].DataIndex == this.AM.NW_UI_SelectIndex)
			{
				this.Scroll_Comp[panelObjectIdx].SelectImage.gameObject.SetActive(true);
			}
			else
			{
				this.Scroll_Comp[panelObjectIdx].SelectImage.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06000D6D RID: 3437 RVA: 0x00153B10 File Offset: 0x00151D10
	private void Update()
	{
		if (this.bFIFA)
		{
			if (this.Npc_Node != null)
			{
				for (int i = 0; i < this.Npc_Node.Length; i++)
				{
					if (this.Npc_Node[i] != null)
					{
						this.Npc_Node[i].Run();
					}
				}
			}
			if (this.LightImage != null)
			{
				for (int j = 0; j < this.LightImage.Length; j++)
				{
					this.LightImage[j].rectTransform.Rotate(0f, 0f, Time.deltaTime * 20f, Space.Self);
				}
			}
		}
		else
		{
			if (this.tmpData == null || (this.tmpData.ActiveType != EActivityType.EAT_KingOfTheWorld && this.tmpData.ActiveType != EActivityType.EAT_FederalEvent))
			{
				return;
			}
			if (this.LightT != null)
			{
				this.LightT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
			}
			if (this.tmpData.ActiveType == EActivityType.EAT_KingOfTheWorld && (this.tmpData.EventState != EActivityState.EAS_ReplayRanking || this.AM.WKIcon == 0))
			{
				return;
			}
			if (this.tmpData.ActiveType == EActivityType.EAT_FederalEvent && this.HeroID == 0)
			{
				return;
			}
			if (!this.bABInitial && this.AR != null && this.AR.isDone)
			{
				this.bABInitial = true;
				((RectTransform)this.ActorT).anchoredPosition += new Vector2(0f, (float)(-(float)(1000 - this.sHero.CameraDistance)));
				this.BossGO = ModelLoader.Instance.Load(this.sHero.Modle, this.AB, (ushort)this.sHero.TextureNo);
				this.BossGO.transform.SetParent(this.ActorT, false);
				this.BossGO.transform.localPosition = new Vector3(0f, 0f, 0f);
				if (this.sHero.Camera_Horizontal == 0)
				{
					this.BossGO.transform.localRotation = new Quaternion(0f, -180f, 0f, 0f);
				}
				else
				{
					Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
					localRotation.eulerAngles = new Vector3(0f, (float)this.sHero.Camera_Horizontal, 0f);
					this.BossGO.transform.localRotation = localRotation;
				}
				this.BossGO.transform.localScale = new Vector3((float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate);
				this.GM.SetLayer(this.BossGO, 5);
				if (this.BossGO != null)
				{
					this.tmpAN = this.BossGO.GetComponent<Animation>();
					this.tmpAN.wrapMode = WrapMode.Loop;
					this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
					for (int k = 0; k < this.ANIndex.Length; k++)
					{
						byte b = (byte)this.ANIndex[k];
						if (this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[(int)b]) != null)
						{
							this.tmpAN[AnimationUnit.ANIM_STRING[(int)b]].layer = 1;
							this.tmpAN[AnimationUnit.ANIM_STRING[(int)b]].wrapMode = WrapMode.Once;
							this.ANList.Add(this.ANIndex[k]);
						}
					}
					this.tmpAN.clip = this.tmpAN.GetClip("idle");
					this.tmpAN.Play("idle");
					SkinnedMeshRenderer componentInChildren = this.BossGO.GetComponentInChildren<SkinnedMeshRenderer>();
					if (componentInChildren != null)
					{
						componentInChildren.useLightProbes = false;
						componentInChildren.updateWhenOffscreen = true;
					}
				}
			}
			if (this.bABInitial && this.BossGO != null)
			{
				if ((!this.tmpAN.IsPlaying(this.HeroAct) || this.HeroAct == "idle") && (double)this.ActionTimeRandom < 0.0001)
				{
					this.ActionTimeRandom = (float)UnityEngine.Random.Range(3, 7);
					this.ActionTime = 0f;
				}
				if ((double)this.ActionTimeRandom > 0.0001)
				{
					this.ActionTime += Time.smoothDeltaTime;
					if (this.ActionTime >= this.ActionTimeRandom)
					{
						this.HeroActionChang();
					}
				}
			}
		}
	}

	// Token: 0x06000D6E RID: 3438 RVA: 0x00153FD8 File Offset: 0x001521D8
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			if (this.tmpData != null)
			{
				this.SetStepScore(this.tmpData.EventScore);
				this.SetMonsterState();
			}
			break;
		case 2:
			if ((int)this.ActivityIndex == arg2)
			{
				if (this.tmpData.EventState == EActivityState.EAS_None)
				{
					this.Main2T.gameObject.SetActive(false);
					this.NotOpenT.gameObject.SetActive(true);
				}
				else
				{
					this.AM.ChangeStateReOpenMenu(this.ActivityIndex);
				}
				this.SetTimeTitle();
			}
			break;
		case 3:
			this.SetTimeStr();
			this.UpdateTime();
			break;
		case 4:
			this.SetMonsterState();
			break;
		case 5:
			this.SetNPCCityStarObj();
			this.SetNPCCityCombatTimes(false);
			break;
		case 6:
			if (this.AM.NW_UI_SelectWonderID != -1 && this.tmpData.GroupCount != 0 && this.AM.NW_UI_SelectIndex >= 0 && this.AM.NW_UI_SelectIndex < this.tmpData.GroupCount)
			{
				bool flag = false;
				byte b = this.tmpData.NobilityGroupDataSortIndex[(int)this.AM.NW_UI_SelectIndex];
				if ((int)this.tmpData.NobilityGroupData[(int)b].WonderID != this.AM.NW_UI_SelectWonderID)
				{
					for (byte b2 = 0; b2 < this.tmpData.GroupCount; b2 += 1)
					{
						b = this.tmpData.NobilityGroupDataSortIndex[(int)b2];
						if ((int)this.tmpData.NobilityGroupData[(int)b].WonderID == this.AM.NW_UI_SelectWonderID)
						{
							this.AM.NW_UI_SelectIndex = b2;
							flag = true;
						}
					}
				}
				else
				{
					flag = true;
				}
				if (!flag)
				{
					this.AM.NW_UI_SelectIndex = 0;
					this.AM.NW_UI_SelectWonderID = -1;
				}
			}
			this.Refresh_NWLeftList();
			this.SetRight(this.AM.NW_UI_SelectIndex);
			break;
		case 7:
			this.SetRight(this.AM.NW_UI_SelectIndex);
			break;
		case 8:
			if ((int)this.ActivityIndex == arg2)
			{
				if (this.tmpData.EventState == EActivityState.EAS_None)
				{
					this.Main2T.gameObject.SetActive(false);
					this.NotOpenT.gameObject.SetActive(true);
				}
				else
				{
					this.AM.ChangeStateReOpenMenu(this.ActivityIndex);
				}
				this.SetTimeTitle();
			}
			break;
		case 9:
			this.SetReLineAndPic();
			this.SetKVKReTime();
			break;
		case 10:
			if (this.ActivityIndex >= 211 && this.ActivityIndex <= 213)
			{
				if (this.tmpData.EventState == EActivityState.EAS_None)
				{
					this.Main2T.gameObject.SetActive(false);
					this.NotOpenT.gameObject.SetActive(true);
				}
				else
				{
					this.AM.ChangeStateReOpenMenu(this.ActivityIndex);
				}
				this.SetTimeTitle();
			}
			break;
		case 11:
			if (this.bFIFA)
			{
				this.CheckNowWave(true);
			}
			break;
		case 12:
			if (this.bFIFA)
			{
				this.SetFIFATopText();
			}
			break;
		}
	}

	// Token: 0x06000D6F RID: 3439 RVA: 0x00154334 File Offset: 0x00152534
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
		{
			EKVKActivityType kvkactiveType = this.tmpData.KVKActiveType;
			EActivityState eventState = this.tmpData.EventState;
			if (kvkactiveType != EKVKActivityType.EKAT_MAX && ((kvkactiveType == EKVKActivityType.EKAT_KvKEvent && eventState == EActivityState.EAS_None) || (kvkactiveType == EKVKActivityType.EKAT_KNormalSoloEvent && eventState == EActivityState.EAS_None) || (kvkactiveType == EKVKActivityType.EKAT_KNormalAllianceEvent && eventState == EActivityState.EAS_None) || (kvkactiveType == EKVKActivityType.EKAT_KvKSoloEvent && (eventState == EActivityState.EAS_None || eventState == EActivityState.EAS_ReplayRanking)) || (kvkactiveType == EKVKActivityType.EKAT_KvKAllianceEvent && (eventState == EActivityState.EAS_None || eventState == EActivityState.EAS_ReplayRanking))))
			{
				Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
				this.AM.Send_ACTIVITY_EVENT_LIST();
				if (door)
				{
					door.CloseMenu(false);
				}
			}
			if (this.tmpData.EventState == EActivityState.EAS_None)
			{
				this.Main2T.gameObject.SetActive(false);
				this.NotOpenT.gameObject.SetActive(true);
			}
			else
			{
				this.AM.ChangeStateReOpenMenu(this.ActivityIndex);
			}
			break;
		}
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				for (int i = 0; i < 7; i++)
				{
					if (this.bFindScrollComp[i])
					{
						if (this.Scroll_Comp[i].ActivityTimeText != null && this.Scroll_Comp[i].ActivityTimeText.enabled)
						{
							this.Scroll_Comp[i].ActivityTimeText.enabled = false;
							this.Scroll_Comp[i].ActivityTimeText.enabled = true;
						}
						if (this.Scroll_Comp[i].CountTimeText != null && this.Scroll_Comp[i].CountTimeText.enabled)
						{
							this.Scroll_Comp[i].CountTimeText.enabled = false;
							this.Scroll_Comp[i].CountTimeText.enabled = true;
						}
					}
				}
				for (int j = 0; j < this.ItemNameText.Length; j++)
				{
					if (this.ItemNameText[j] != null && this.ItemNameText[j].enabled)
					{
						this.ItemNameText[j].enabled = false;
						this.ItemNameText[j].enabled = true;
					}
				}
				for (int k = 0; k < this.RBText5.Length; k++)
				{
					if (this.RBText5[k] != null && this.RBText5[k].enabled)
					{
						this.RBText5[k].enabled = false;
						this.RBText5[k].enabled = true;
					}
				}
				if (this.RBText4 != null)
				{
					for (int l = 0; l < this.RBText4.Length; l++)
					{
						if (this.RBText4[l] != null && this.RBText4[l].enabled)
						{
							this.RBText4[l].enabled = false;
							this.RBText4[l].enabled = true;
						}
					}
				}
				for (int m = 0; m < this.RBText3.Length; m++)
				{
					if (this.RBText3[m] != null && this.RBText3[m].enabled)
					{
						this.RBText3[m].enabled = false;
						this.RBText3[m].enabled = true;
					}
				}
				for (int n = 0; n < this.RBText2.Length; n++)
				{
					if (this.RBText2[n] != null && this.RBText2[n].enabled)
					{
						this.RBText2[n].enabled = false;
						this.RBText2[n].enabled = true;
					}
				}
				for (int num = 0; num < this.RBText.Length; num++)
				{
					if (this.RBText[num] != null && this.RBText[num].enabled)
					{
						this.RBText[num].enabled = false;
						this.RBText[num].enabled = true;
					}
				}
				if (this.HintKingdomText != null)
				{
					for (int num2 = 0; num2 < this.HintKingdomText.Length; num2++)
					{
						if (this.HintKingdomText[num2] != null && this.HintKingdomText[num2].enabled)
						{
							this.HintKingdomText[num2].enabled = false;
							this.HintKingdomText[num2].enabled = true;
						}
					}
				}
				if (this.P3_ItemText != null)
				{
					for (int num3 = 0; num3 < this.P3_ItemText.Length; num3++)
					{
						if (this.P3_ItemText[num3] != null && this.P3_ItemText[num3].enabled)
						{
							this.P3_ItemText[num3].enabled = false;
							this.P3_ItemText[num3].enabled = true;
						}
					}
				}
				for (int num4 = 0; num4 < 5; num4++)
				{
					if (this.FctorText1[num4] != null && this.FctorText1[num4].enabled)
					{
						this.FctorText1[num4].enabled = false;
						this.FctorText1[num4].enabled = true;
					}
					if (this.FctorText2[num4] != null && this.FctorText2[num4].enabled)
					{
						this.FctorText2[num4].enabled = false;
						this.FctorText2[num4].enabled = true;
					}
					if (this.FctorText3[num4] != null && this.FctorText3[num4].enabled)
					{
						this.FctorText3[num4].enabled = false;
						this.FctorText3[num4].enabled = true;
					}
				}
				for (int num5 = 0; num5 < 3; num5++)
				{
					for (int num6 = 0; num6 < this.ItemCount[num5]; num6++)
					{
						if (this.StepItemCountText[num5] != null && this.StepItemCountText[num5][num6] != null && this.StepItemCountText[num5][num6].enabled)
						{
							this.StepItemCountText[num5][num6].enabled = false;
							this.StepItemCountText[num5][num6].enabled = true;
						}
					}
					if (this.StageScoreText[num5] != null && this.StageScoreText[num5].enabled)
					{
						this.StageScoreText[num5].enabled = false;
						this.StageScoreText[num5].enabled = true;
					}
					if (this.StepText1[num5] != null && this.StepText1[num5].enabled)
					{
						this.StepText1[num5].enabled = false;
						this.StepText1[num5].enabled = true;
					}
					if (this.StepText2[num5] != null && this.StepText2[num5].enabled)
					{
						this.StepText2[num5].enabled = false;
						this.StepText2[num5].enabled = true;
					}
					if (this.StepText3[num5] != null && this.StepText3[num5].enabled)
					{
						this.StepText3[num5].enabled = false;
						this.StepText3[num5].enabled = true;
					}
					if (this.StepText4[num5] != null && this.StepText4[num5].enabled)
					{
						this.StepText4[num5].enabled = false;
						this.StepText4[num5].enabled = true;
					}
				}
				for (int num7 = 0; num7 < 12; num7++)
				{
					if (this.HintTextL[num7] != null && this.HintTextL[num7].enabled)
					{
						this.HintTextL[num7].enabled = false;
						this.HintTextL[num7].enabled = true;
					}
					if (this.HintTextR[num7] != null && this.HintTextR[num7].enabled)
					{
						this.HintTextR[num7].enabled = false;
						this.HintTextR[num7].enabled = true;
					}
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
				if (this.TimeTitle != null && this.TimeTitle.enabled)
				{
					this.TimeTitle.enabled = false;
					this.TimeTitle.enabled = true;
				}
				if (this.TimeText != null && this.TimeText.enabled)
				{
					this.TimeText.enabled = false;
					this.TimeText.enabled = true;
				}
				if (this.RankReplayTitleText != null && this.RankReplayTitleText.enabled)
				{
					this.RankReplayTitleText.enabled = false;
					this.RankReplayTitleText.enabled = true;
				}
				if (this.P1_TitleText != null && this.P1_TitleText.enabled)
				{
					this.P1_TitleText.enabled = false;
					this.P1_TitleText.enabled = true;
				}
				if (this.P2_KingdomIDText != null && this.P2_KingdomIDText.enabled)
				{
					this.P2_KingdomIDText.enabled = false;
					this.P2_KingdomIDText.enabled = true;
				}
				if (this.P2_WonderNameText != null && this.P2_WonderNameText.enabled)
				{
					this.P2_WonderNameText.enabled = false;
					this.P2_WonderNameText.enabled = true;
				}
				if (this.P2_WonderPosText != null && this.P2_WonderPosText.enabled)
				{
					this.P2_WonderPosText.enabled = false;
					this.P2_WonderPosText.enabled = true;
				}
				if (this.P3_CrystalText != null && this.P3_CrystalText.enabled)
				{
					this.P3_CrystalText.enabled = false;
					this.P3_CrystalText.enabled = true;
				}
				if (this.P3_MoneyText != null && this.P3_MoneyText.enabled)
				{
					this.P3_MoneyText.enabled = false;
					this.P3_MoneyText.enabled = true;
				}
				if (this.RP_NameText != null && this.RP_NameText.enabled)
				{
					this.RP_NameText.enabled = false;
					this.RP_NameText.enabled = true;
				}
				if (this.RP_KingdomIDText != null && this.RP_KingdomIDText.enabled)
				{
					this.RP_KingdomIDText.enabled = false;
					this.RP_KingdomIDText.enabled = true;
				}
				if (this.NWText != null && this.NWText.enabled)
				{
					this.NWText.enabled = false;
					this.NWText.enabled = true;
				}
				if (this.HintT3Text != null && this.HintT3Text.enabled)
				{
					this.HintT3Text.enabled = false;
					this.HintT3Text.enabled = true;
				}
				if (this.ReTimeText != null && this.ReTimeText.enabled)
				{
					this.ReTimeText.enabled = false;
					this.ReTimeText.enabled = true;
				}
				if (this.ReImageDevilText != null && this.ReImageDevilText.enabled)
				{
					this.ReImageDevilText.enabled = false;
					this.ReImageDevilText.enabled = true;
				}
				if (this.HintText1 != null && this.HintText1.enabled)
				{
					this.HintText1.enabled = false;
					this.HintText1.enabled = true;
				}
				if (this.HintText2 != null && this.HintText2.enabled)
				{
					this.HintText2.enabled = false;
					this.HintText2.enabled = true;
				}
				if (this.HintSPText != null && this.HintSPText.enabled)
				{
					this.HintSPText.enabled = false;
					this.HintSPText.enabled = true;
				}
				if (this.WaveText != null)
				{
					for (int num8 = 0; num8 < this.WaveText.Length; num8++)
					{
						if (this.WaveText[num8] != null && this.WaveText[num8].enabled)
						{
							this.WaveText[num8].enabled = false;
							this.WaveText[num8].enabled = true;
						}
					}
				}
			}
			break;
		case NetworkNews.Refresh_Asset:
			if (meg[1] == 1 && meg[2] == 2 && GameConstants.ConvertBytesToUShort(meg, 3) == this.sHero.Modle)
			{
				this.LoadAB(true);
			}
			else if (meg[1] == 0 && meg[2] == 0 && GameConstants.ConvertBytesToUShort(meg, 3) == 1002)
			{
				this.LoadNPC_Node();
			}
			break;
		}
	}

	// Token: 0x06000D70 RID: 3440 RVA: 0x00155128 File Offset: 0x00153328
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		if (panelId == 1)
		{
			int btnID = gameObject.GetComponent<ScrollPanelItem>().m_BtnID2;
			if (btnID < 0 || btnID >= this.Scroll_Comp.Length)
			{
				return;
			}
			if (!this.bFindScrollComp[btnID] || this.AM.NW_UI_SelectIndex == this.Scroll_Comp[btnID].DataIndex)
			{
				return;
			}
			for (int i = 0; i < this.Scroll_Comp.Length; i++)
			{
				if (this.Scroll_Comp[i].DataIndex == this.AM.NW_UI_SelectIndex)
				{
					this.Scroll_Comp[i].SelectImage.gameObject.SetActive(false);
					break;
				}
			}
			this.AM.NW_UI_SelectIndex = this.Scroll_Comp[btnID].DataIndex;
			if (this.tmpData.GroupCount != 0 && this.AM.NW_UI_SelectIndex >= 0 && this.AM.NW_UI_SelectIndex < this.tmpData.GroupCount)
			{
				byte b = this.tmpData.NobilityGroupDataSortIndex[(int)this.AM.NW_UI_SelectIndex];
				this.AM.NW_UI_SelectWonderID = (int)this.tmpData.NobilityGroupData[(int)b].WonderID;
			}
			this.Scroll_Comp[btnID].SelectImage.gameObject.SetActive(true);
			this.SetRight(this.AM.NW_UI_SelectIndex);
		}
	}

	// Token: 0x06000D71 RID: 3441 RVA: 0x001552AC File Offset: 0x001534AC
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
			if (sender.m_BtnID2 == 1)
			{
				this.AM.Send_ACTIVITY_EVENT_LIST();
				if (door)
				{
					door.CloseMenu(false);
				}
			}
			else if (sender.m_BtnID2 == 2 && door)
			{
				if (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK)
				{
					if (this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_KingdomEvent)
					{
						door.OpenMenu(EGUIWindow.UI_Activity4, 1, 205, false);
					}
					else if (this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_SoloEvent)
					{
						door.OpenMenu(EGUIWindow.UI_Activity4, 1, 203, false);
					}
					else if (this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_AllianceEvent)
					{
						door.OpenMenu(EGUIWindow.UI_Activity4, 1, 204, false);
					}
				}
				else if (this.bFIFA)
				{
					door.OpenMenu(EGUIWindow.UI_FootBall_Info, 1, 0, false);
				}
				else
				{
					door.OpenMenu(EGUIWindow.UI_Activity4, 1, (int)this.ActivityIndex, false);
				}
			}
		}
		else if (sender.m_BtnID1 == 2)
		{
			if (sender.m_BtnID2 == 1)
			{
				if (this.ActivityIndex >= 201 && this.ActivityIndex <= 205)
				{
					this.AM.Send_ACTIVITY_KEVENT_RANKING_PRIZE(this.ActivityIndex);
				}
				else if (this.ActivityIndex >= 211 && this.ActivityIndex <= 213)
				{
					this.AM.Send_FIFA_RANKING_PRIZE(this.ActivityIndex);
				}
				else
				{
					this.AM.Send_ACTIVITY_RANKING_PRIZE(this.ActivityIndex);
				}
			}
			else if (sender.m_BtnID2 == 2)
			{
				Door door2 = this.GM.FindMenu(EGUIWindow.Door) as Door;
				if (this.ActivityIndex == 207)
				{
					if (door2)
					{
						door2.OpenMenu(EGUIWindow.UI_LeaderBoard, 7, 0, false);
					}
				}
				else if (this.ActivityIndex == 209)
				{
					byte b = this.tmpData.NobilityGroupDataSortIndex[(int)this.AM.NW_UI_SelectIndex];
					if (door2)
					{
						door2.OpenMenu(EGUIWindow.UI_NobilityOccupyBoard, (int)this.tmpData.NobilityGroupData[(int)b].WonderID, 0, false);
					}
				}
				else if (this.ActivityIndex == 213)
				{
					if (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK)
					{
						if (!this.AM.FIFA_bGetChampion)
						{
							this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14613u), 255, true);
							return;
						}
						if (door2)
						{
							UIFootBallBoard.NewOpen = true;
							door2.OpenMenu(EGUIWindow.UI_FootBallKVKBoard, 0, 0, false);
						}
					}
					else
					{
						if (!this.AM.FIFA_bGetChampion)
						{
							this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14613u), 255, true);
							return;
						}
						if (door2)
						{
							UIFootBallBoard.NewOpen = true;
							door2.OpenMenu(EGUIWindow.UI_FootBallBoard, 0, 0, false);
						}
					}
				}
				else
				{
					UILeaderBoard.NewOpen = true;
					if (door2)
					{
						if (this.AM.IsMatchKvk())
						{
							UIKingdomVSLBoard.NewOpen = true;
							door2.OpenMenu(EGUIWindow.UI_KingdomVSLBoard, 0, 0, false);
						}
						else
						{
							UIKVKLBoard.NewOpen = true;
							door2.OpenMenu(EGUIWindow.UI_KVKLBoard, 0, 0, false);
						}
					}
				}
			}
			else if (sender.m_BtnID2 == 3)
			{
				Door door2 = this.GM.FindMenu(EGUIWindow.Door) as Door;
				if (door2)
				{
					if (this.ActivityIndex == 207)
					{
						door2.GoToKingdom(this.AM.KOWKingdomID, -1);
					}
					else
					{
						door2.GoToKingdom(DataManager.MapDataController.OtherKingdomData.kingdomID, -1);
					}
				}
			}
		}
		else if (sender.m_BtnID1 == 3)
		{
			if (sender.m_BtnID2 == 1 && this.AM.WKName.Length > 0)
			{
				this.DM.ShowLordProfile(this.AM.WKName.ToString());
			}
		}
		else if (sender.m_BtnID1 == 4)
		{
			if (sender.m_BtnID2 == 1)
			{
				Door door3 = this.GM.FindMenu(EGUIWindow.Door) as Door;
				if (door3)
				{
					door3.GoToKingdom(DataManager.MapDataController.kingdomData.kingdomID, -1);
				}
			}
			else
			{
				if (this.tmpData.EventState == EActivityState.EAS_Prepare)
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12014u), 255, true);
					return;
				}
				Door door3 = this.GM.FindMenu(EGUIWindow.Door) as Door;
				if (door3)
				{
					door3.GoToKingdom((ushort)sender.m_BtnID3, -1);
				}
			}
		}
		else if (sender.m_BtnID1 == 5)
		{
			if (sender.m_BtnID2 == 1)
			{
				Door door4 = this.GM.FindMenu(EGUIWindow.Door) as Door;
				if (this.DM.RoleAlliance.Id > 0u)
				{
					if (door4)
					{
						door4.OpenMenu(EGUIWindow.UI_SummonMonster, 0, 0, true);
					}
				}
				else
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(689u), 255, true);
				}
			}
			else if (sender.m_BtnID2 == 2)
			{
				if (this.DM.RoleAlliance.Id == 0u || this.AM.AllianceSummonAllianceID == 0u || this.DM.RoleAlliance.Id != this.AM.AllianceSummonAllianceID)
				{
					return;
				}
				Door door5 = this.GM.FindMenu(EGUIWindow.Door) as Door;
				if (door5)
				{
					UIAlliHuntBoard.NewOpen = true;
					door5.OpenMenu(EGUIWindow.UI_AlliHuntBoard, 0, 0, false);
				}
			}
		}
		else if (sender.m_BtnID1 == 6)
		{
			if (this.tmpData == null || this.tmpData.GroupCount == 0)
			{
				return;
			}
			if (sender.m_BtnID2 == 1)
			{
				byte b2 = this.tmpData.NobilityGroupDataSortIndex[(int)this.AM.NW_UI_SelectIndex];
				Door door6 = this.GM.FindMenu(EGUIWindow.Door) as Door;
				if (door6)
				{
					door6.GoToWonder(this.tmpData.NobilityGroupData[(int)b2].KingdomID, this.tmpData.NobilityGroupData[(int)b2].WonderID);
				}
			}
			else if (sender.m_BtnID2 == 3)
			{
				byte b3 = this.tmpData.NobilityGroupDataSortIndex[(int)this.AM.NW_UI_SelectIndex];
				if (this.tmpData.NobilityGroupData[(int)b3].NobilityHeroID > 0)
				{
					this.DM.ShowLordProfile(this.tmpData.NobilityGroupData[(int)b3].NobilityName.ToString());
				}
			}
		}
		else if (sender.m_BtnID1 == 7)
		{
			if (sender.m_BtnID2 == 1)
			{
				if (this.AM.FIFA_AllianceEmblem > 0)
				{
					Door door7 = this.GM.FindMenu(EGUIWindow.Door) as Door;
					if (door7 != null)
					{
						door7.AllianceInfo(this.AM.FIFA_AllianceTag.ToString());
					}
				}
			}
			else if (sender.m_BtnID2 == 2)
			{
				if (this.AM.FIFA_PlayerHead > 0)
				{
					this.DM.ShowLordProfile(this.AM.FIFA_PlayerName.ToString());
				}
			}
			else if (sender.m_BtnID2 == 3)
			{
				Door door8 = this.GM.FindMenu(EGUIWindow.Door) as Door;
				if (door8)
				{
					door8.OpenMenu(EGUIWindow.UI_FootBall_Info, 1, 0, false);
				}
			}
		}
		else if (sender.m_BtnID1 == 10)
		{
			EGetScoreFactor btnID = (EGetScoreFactor)sender.m_BtnID2;
			if (btnID == EGetScoreFactor.EGSF_Donate)
			{
				if (this.tmpData.EventState == EActivityState.EAS_Prepare)
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8111u), 255, true);
					return;
				}
				if (this.DM.RoleAlliance.Id == 0u || this.AM.AllianceSummonAllianceID == 0u || this.DM.RoleAlliance.Id != this.AM.AllianceSummonAllianceID)
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1353u), 255, true);
					return;
				}
				if (this.tmpData.EventState != EActivityState.EAS_Run)
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1594u), 255, true);
					return;
				}
				Door door9 = this.GM.FindMenu(EGUIWindow.Door) as Door;
				if (door9)
				{
					door9.OpenMenu(EGUIWindow.UIDonation, 0, 0, false);
				}
			}
		}
	}

	// Token: 0x06000D72 RID: 3442 RVA: 0x00155BFC File Offset: 0x00153DFC
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x06000D73 RID: 3443 RVA: 0x00155C00 File Offset: 0x00153E00
	public void OnHIButtonClick(UIHIBtn sender)
	{
		MallManager.Instance.OpenDetail(sender.HIID);
	}

	// Token: 0x06000D74 RID: 3444 RVA: 0x00155C14 File Offset: 0x00153E14
	public override bool OnBackButtonClick()
	{
		this.AM.Send_ACTIVITY_EVENT_LIST();
		return false;
	}

	// Token: 0x06000D75 RID: 3445 RVA: 0x00155C24 File Offset: 0x00153E24
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.Parm1 == 1)
		{
			if (this.HintT2 != null)
			{
				this.HintT2.gameObject.SetActive(true);
			}
		}
		else if (sender.Parm1 == 2)
		{
			if (this.HintT3 != null)
			{
				this.HintT3.gameObject.SetActive(true);
			}
		}
		else if (sender.Parm1 == 3)
		{
			if (this.HintT4 != null)
			{
				this.SetNPCCityCombatTimes(true);
				this.HintT4.gameObject.SetActive(true);
			}
		}
		else if (sender.Parm1 == 4)
		{
			if (this.HintT2 != null)
			{
				this.HintT2.gameObject.SetActive(true);
			}
		}
		else if (sender.Parm1 == 5)
		{
			if (this.HintT3 == null)
			{
				return;
			}
			this.HintT3Str.Length = 0;
			if (sender.Parm2 == 1)
			{
				this.HintT3Str.Append(this.DM.mStringTable.GetStringByID(12092u));
			}
			else if (sender.Parm2 == 2)
			{
				if (this.tmpData.EventState == EActivityState.EAS_Prepare)
				{
					this.HintT3Str.AppendFormat(this.DM.mStringTable.GetStringByID(12093u));
				}
				else
				{
					this.HintT3Str.IntToFormat((long)this.AM.MatchKingdomID_4[(this.AM.KVKHuntOrder != 2) ? 2 : 1], 1, false);
					this.HintT3Str.AppendFormat(this.DM.mStringTable.GetStringByID(12090u));
				}
			}
			else if (sender.Parm2 == 3)
			{
				if (this.tmpData.EventState == EActivityState.EAS_Prepare)
				{
					this.HintT3Str.IntToFormat((long)this.ShowRate, 1, false);
					this.HintT3Str.AppendFormat(this.DM.mStringTable.GetStringByID(12094u));
				}
				else
				{
					this.HintT3Str.IntToFormat((long)this.AM.MatchKingdomID_4[(this.AM.KVKHuntOrder != 2) ? 1 : 2], 1, false);
					this.HintT3Str.IntToFormat((long)this.ShowRate, 1, false);
					this.HintT3Str.AppendFormat(this.DM.mStringTable.GetStringByID(12091u));
				}
			}
			this.HintT3Text.text = this.HintT3Str.ToString();
			this.HintT3Text.SetAllDirty();
			this.HintT3Text.cachedTextGenerator.Invalidate();
			this.HintT3Text.cachedTextGeneratorForLayout.Invalidate();
			float num = this.HintT3Text.preferredHeight + 1f;
			this.HintT3Text.rectTransform.sizeDelta = new Vector2(this.HintT3Text.rectTransform.sizeDelta.x, num);
			this.HintT3.sizeDelta = new Vector2(this.HintT3.sizeDelta.x, num + 30f);
			this.HintT3.gameObject.SetActive(true);
		}
		else if (sender.Parm1 == 6)
		{
			if (this.HintTFIFA != null)
			{
				if (this.WaveStr[3] == null)
				{
					this.WaveStr[3] = StringManager.Instance.SpawnString(300);
				}
				this.WaveStr[3].Length = 0;
				this.WaveStr[3].IntToFormat((long)sender.Parm2, 1, false);
				this.WaveStr[3].AppendFormat(this.DM.mStringTable.GetStringByID(12212u));
				this.WaveStr[3].Append("\n");
				long num2 = this.AM.FIFAData[2].EventBeginTime;
				num2 += (long)((ushort)(sender.Parm2 - 1) * this.AM.WaveIntervalMin * 60);
				this.WaveStr[3].Append(this.DM.mStringTable.GetStringByID(12213u));
				this.WaveStr[3].Append(GameConstants.GetDateTime(num2).ToString("MM/dd/yy HH:mm"));
				this.WaveStr[3].Append("\n");
				num2 += (long)(this.AM.WaveRequireMin * 60);
				this.WaveStr[3].Append(this.DM.mStringTable.GetStringByID(12214u));
				this.WaveStr[3].Append(GameConstants.GetDateTime(num2).ToString("MM/dd/yy HH:mm"));
				this.WaveText[4].text = this.WaveStr[3].ToString();
				this.WaveText[4].SetAllDirty();
				this.WaveText[4].cachedTextGenerator.Invalidate();
				this.WaveText[4].cachedTextGeneratorForLayout.Invalidate();
				float num3 = this.WaveText[4].preferredWidth + 1f;
				this.HintTFIFA.sizeDelta = new Vector2(num3 + 38f, this.HintTFIFA.sizeDelta.y);
				float num4 = this.WaveText[4].preferredHeight + 1f;
				this.WaveText[4].rectTransform.sizeDelta = new Vector2(this.WaveText[4].rectTransform.sizeDelta.x, num4);
				this.HintTFIFA.sizeDelta = new Vector2(this.HintTFIFA.sizeDelta.x, num4 + 30f);
				this.HintTFIFA.anchoredPosition = new Vector2(167f - this.HintTFIFA.sizeDelta.x / 2f, 142f);
				if (this.HintTFIFA.anchoredPosition.x + this.HintTFIFA.sizeDelta.x > this.Sizex)
				{
					this.HintTFIFA.anchoredPosition = new Vector2(this.Sizex - this.HintTFIFA.sizeDelta.x, this.HintTFIFA.anchoredPosition.y);
				}
				if (this.HintTFIFA.anchoredPosition.x < 0f)
				{
					this.HintTFIFA.anchoredPosition = new Vector2(0f, this.HintTFIFA.anchoredPosition.y);
				}
				this.HintTFIFA.gameObject.SetActive(true);
			}
		}
		else
		{
			UIButton uibutton = sender.m_Button as UIButton;
			byte b = (byte)uibutton.m_BtnID2;
			if ((int)b < this.tmpData.GetScoreFactor.Length)
			{
				EGetScoreFactor factor = this.tmpData.GetScoreFactor[(int)b].Factor;
				int scoreFactorCount = (int)this.GetScoreFactorCount(factor);
				if (scoreFactorCount > 0)
				{
					bool flag = false;
					if ((this.tmpData.ActiveType == EActivityType.EAT_KingdomMatchEvent || this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK) && this.AM.MatchKingdomCount == 4)
					{
						byte huntBonusRate = this.AM.GetHuntBonusRate(this.ActivityIndex, factor);
						if (huntBonusRate > 1)
						{
							this.HintStr1.Length = 0;
							this.HintStr1.IntToFormat((long)huntBonusRate, 1, false);
							if (this.GM.IsArabic)
							{
								this.HintStr1.AppendFormat("{0}x");
							}
							else
							{
								this.HintStr1.AppendFormat("x{0}");
							}
							this.HintText1.text = this.HintStr1.ToString();
							this.HintText1.SetAllDirty();
							this.HintText1.cachedTextGenerator.Invalidate();
							this.HintText1.cachedTextGeneratorForLayout.Invalidate();
							this.HintStr2.Length = 0;
							if (((this.ActivityIndex >= 203 && this.ActivityIndex <= 205) || (this.ActivityIndex >= 211 && this.ActivityIndex <= 213)) && this.tmpData.EventState != EActivityState.EAS_Run)
							{
								this.HintStr2.IntToFormat((long)huntBonusRate, 1, false);
								this.HintStr2.AppendFormat(this.DM.mStringTable.GetStringByID(12095u));
							}
							else if (this.ActivityIndex == 204 && factor == EGetScoreFactor.EGSF_WonderOccupy)
							{
								if (!this.AM.IsMatchKvk_kingdom(this.DM.RoleAlliance.KingdomID))
								{
									this.HintStr2.Append(this.DM.mStringTable.GetStringByID(12097u));
								}
								else
								{
									ushort num5 = 0;
									int num6 = 0;
									while (num6 < (int)this.AM.MatchKingdomIDCount && num6 < 6)
									{
										if (this.AM.MatchKingdomID[num6] == this.DM.RoleAlliance.KingdomID)
										{
											if (this.AM.KVKHuntOrder == 2)
											{
												if (num6 == 0)
												{
													num5 = this.AM.MatchKingdomID[(int)(this.AM.MatchKingdomIDCount - 1)];
												}
												else
												{
													num5 = this.AM.MatchKingdomID[num6 - 1];
												}
											}
											else if (num6 == (int)(this.AM.MatchKingdomIDCount - 1))
											{
												num5 = this.AM.MatchKingdomID[0];
											}
											else
											{
												num5 = this.AM.MatchKingdomID[num6 + 1];
											}
										}
										num6++;
									}
									this.HintStr2.IntToFormat((long)num5, 1, false);
									this.HintStr2.IntToFormat((long)huntBonusRate, 1, false);
									this.HintStr2.AppendFormat(this.DM.mStringTable.GetStringByID(12087u));
								}
							}
							else
							{
								this.HintStr2.IntToFormat((long)this.AM.MatchKingdomID_4[(this.AM.KVKHuntOrder != 2) ? 1 : 2], 1, false);
								this.HintStr2.IntToFormat((long)huntBonusRate, 1, false);
								this.HintStr2.AppendFormat(this.DM.mStringTable.GetStringByID(12088u));
							}
							this.HintText2.text = this.HintStr2.ToString();
							this.HintText2.SetAllDirty();
							this.HintText2.cachedTextGenerator.Invalidate();
							this.HintText2.cachedTextGeneratorForLayout.Invalidate();
							flag = true;
						}
					}
					float num7 = (float)((!flag) ? 0 : 55);
					this.HintGO.SetActive(flag);
					float num8 = 0f;
					float num9 = 30f;
					if (factor == EGetScoreFactor.EGSF_FIFAKVKWonder)
					{
						Color color = new Color32(byte.MaxValue, 247, 153, byte.MaxValue);
						float num10 = num8 - 38f;
						this.HintTextL[0].gameObject.SetActive(true);
						this.SetScoreFactorHintL(factor, 0, this.HintStrL[0]);
						this.HintTextL[0].color = Color.white;
						this.HintTextL[0].text = this.HintStrL[0].ToString();
						this.HintTextL[0].SetAllDirty();
						this.HintTextL[0].cachedTextGenerator.Invalidate();
						this.HintTextL[0].cachedTextGeneratorForLayout.Invalidate();
						float num11 = this.HintTextL[0].preferredWidth + 2f;
						this.HintTextR[0].gameObject.SetActive(true);
						this.SetScoreFactorHintR(factor, 0, this.HintStrR[0], (int)this.tmpData.GetScoreFactor[(int)b].BonusRate);
						this.HintTextR[0].color = Color.white;
						this.HintTextR[0].text = this.HintStrR[0].ToString();
						this.HintTextR[0].SetAllDirty();
						this.HintTextR[0].cachedTextGenerator.Invalidate();
						this.HintTextR[0].cachedTextGeneratorForLayout.Invalidate();
						float num12 = this.HintTextR[0].preferredWidth + 2f;
						float num13 = 88f + num11 + num12;
						num9 += 30f;
						this.HintTextL[3].gameObject.SetActive(true);
						this.SetScoreFactorHintL(factor, 3, this.HintStrL[3]);
						this.HintTextL[3].color = Color.white;
						this.HintTextL[3].text = this.HintStrL[3].ToString();
						this.HintTextL[3].SetAllDirty();
						this.HintTextL[3].cachedTextGenerator.Invalidate();
						this.HintTextL[3].cachedTextGeneratorForLayout.Invalidate();
						num11 = this.HintTextL[3].preferredWidth + 2f;
						this.HintTextR[3].gameObject.SetActive(true);
						this.SetScoreFactorHintR(factor, 3, this.HintStrR[3], (int)this.tmpData.GetScoreFactor[(int)b].BonusRate);
						this.HintTextR[3].color = Color.white;
						this.HintTextR[3].text = this.HintStrR[3].ToString();
						this.HintTextR[3].SetAllDirty();
						this.HintTextR[3].cachedTextGenerator.Invalidate();
						this.HintTextR[3].cachedTextGeneratorForLayout.Invalidate();
						num12 = this.HintTextR[3].preferredWidth + 2f;
						float num14 = 88f + num11 + num12;
						num9 += 30f;
						float num15 = (num13 <= num14) ? num14 : num13;
						if (num8 < num15)
						{
							num8 = num15;
						}
						this.HintT.sizeDelta = new Vector2(num8, num9 + num7);
						this.HintTextL[1].gameObject.SetActive(true);
						this.HintTextR[1].gameObject.SetActive(false);
						this.SetScoreFactorHintL(factor, 1, this.HintStrL[1]);
						this.HintTextL[1].color = color;
						this.HintTextL[1].text = this.HintStrL[1].ToString();
						this.HintTextL[1].SetAllDirty();
						this.HintTextL[1].cachedTextGenerator.Invalidate();
						this.HintTextL[1].cachedTextGeneratorForLayout.Invalidate();
						float num16 = this.HintTextL[1].preferredHeight + 1f;
						this.HintTextL[1].rectTransform.sizeDelta = new Vector2(this.HintTextL[1].rectTransform.sizeDelta.x, num16);
						num9 += num16;
						this.HintTextL[2].gameObject.SetActive(false);
						this.HintTextR[2].gameObject.SetActive(false);
						num9 += 30f;
						this.HintTextL[4].gameObject.SetActive(true);
						this.HintTextR[4].gameObject.SetActive(false);
						this.SetScoreFactorHintL(factor, 4, this.HintStrL[4]);
						this.HintTextL[4].color = color;
						this.HintTextL[4].text = this.HintStrL[4].ToString();
						this.HintTextL[4].SetAllDirty();
						this.HintTextL[4].cachedTextGenerator.Invalidate();
						this.HintTextL[4].cachedTextGeneratorForLayout.Invalidate();
						float num17 = this.HintTextL[4].preferredHeight + 1f;
						this.HintTextL[4].rectTransform.sizeDelta = new Vector2(this.HintTextL[4].rectTransform.sizeDelta.x, num17);
						num9 += num17;
						float num18 = -16f - num7;
						this.HintTextL[0].rectTransform.anchoredPosition = new Vector2(this.HintTextL[0].rectTransform.anchoredPosition.x, num18);
						this.HintTextR[0].rectTransform.anchoredPosition = new Vector2(this.HintTextR[0].rectTransform.anchoredPosition.x, num18);
						num18 -= 30f;
						this.HintTextL[1].rectTransform.anchoredPosition = new Vector2(this.HintTextL[1].rectTransform.anchoredPosition.x, num18);
						num18 -= 30f + num16;
						this.HintTextL[3].rectTransform.anchoredPosition = new Vector2(this.HintTextL[3].rectTransform.anchoredPosition.x, num18);
						this.HintTextR[3].rectTransform.anchoredPosition = new Vector2(this.HintTextR[3].rectTransform.anchoredPosition.x, num18);
						num18 -= 30f;
						this.HintTextL[4].rectTransform.anchoredPosition = new Vector2(this.HintTextL[4].rectTransform.anchoredPosition.x, num18);
						for (int i = 5; i < 12; i++)
						{
							this.HintTextL[i].gameObject.SetActive(false);
							this.HintTextR[i].gameObject.SetActive(false);
						}
					}
					else
					{
						for (int j = 0; j < 12; j++)
						{
							if (j < scoreFactorCount)
							{
								this.HintTextL[j].gameObject.SetActive(true);
								if (this.bSummonType)
								{
									this.SetScoreFactorHintL_AS(factor, j, this.HintStrL[j]);
								}
								else
								{
									this.SetScoreFactorHintL(factor, j, this.HintStrL[j]);
								}
								this.HintTextL[j].color = Color.white;
								this.HintTextL[j].rectTransform.sizeDelta = new Vector2(this.HintTextL[j].rectTransform.sizeDelta.x, 30f);
								this.HintTextL[j].text = this.HintStrL[j].ToString();
								this.HintTextL[j].SetAllDirty();
								this.HintTextL[j].cachedTextGenerator.Invalidate();
								this.HintTextL[j].cachedTextGeneratorForLayout.Invalidate();
								float num11 = this.HintTextL[j].preferredWidth + 2f;
								this.HintTextR[j].gameObject.SetActive(true);
								if (this.bSummonType)
								{
									this.SetScoreFactorHintR_AS(factor, j, this.HintStrR[j], (int)this.tmpData.GetScoreFactor[(int)b].BonusRate);
								}
								else
								{
									this.SetScoreFactorHintR(factor, j, this.HintStrR[j], (int)this.tmpData.GetScoreFactor[(int)b].BonusRate);
								}
								this.HintTextR[j].color = Color.white;
								this.HintTextR[j].rectTransform.sizeDelta = new Vector2(this.HintTextR[j].rectTransform.sizeDelta.x, 30f);
								this.HintTextR[j].text = this.HintStrR[j].ToString();
								this.HintTextR[j].SetAllDirty();
								this.HintTextR[j].cachedTextGenerator.Invalidate();
								this.HintTextR[j].cachedTextGeneratorForLayout.Invalidate();
								float num12 = this.HintTextR[j].preferredWidth + 2f;
								this.HintTextL[j].rectTransform.anchoredPosition = new Vector2(this.HintTextL[j].rectTransform.anchoredPosition.x, -16f - num7 - (float)(30 * j));
								this.HintTextR[j].rectTransform.anchoredPosition = new Vector2(this.HintTextR[j].rectTransform.anchoredPosition.x, -16f - num7 - (float)(30 * j));
								float num15 = 88f + num11 + num12;
								if (num8 < num15)
								{
									num8 = num15;
								}
								num9 += 30f;
							}
							else
							{
								this.HintTextL[j].gameObject.SetActive(false);
								this.HintTextR[j].gameObject.SetActive(false);
							}
						}
					}
					this.HintT.sizeDelta = new Vector2(num8, num9 + num7);
					this.HintSPText.gameObject.SetActive(false);
					this.HintT.anchoredPosition = new Vector2(this.Sizex / 2f - 86f, -this.Sizey / 2f + 51f);
					if (this.HintT.anchoredPosition.x + this.HintT.sizeDelta.x > this.Sizex)
					{
						this.HintT.anchoredPosition = new Vector2(this.Sizex - this.HintT.sizeDelta.x, this.HintT.anchoredPosition.y);
					}
					if (this.HintT.anchoredPosition.x < 0f)
					{
						this.HintT.anchoredPosition = new Vector2(0f, this.HintT.anchoredPosition.y);
					}
					if (-(this.HintT.anchoredPosition.y - this.HintT.sizeDelta.y) > this.Sizey - 100f)
					{
						this.HintT.anchoredPosition = new Vector2(this.HintT.anchoredPosition.x, -this.Sizey + this.HintT.sizeDelta.y + 100f);
					}
					if (this.HintT.anchoredPosition.y > 0f)
					{
						this.HintT.anchoredPosition = new Vector2(this.HintT.anchoredPosition.x, 0f);
					}
					this.HintT.gameObject.SetActive(true);
				}
			}
		}
	}

	// Token: 0x06000D76 RID: 3446 RVA: 0x00157308 File Offset: 0x00155508
	public void OnButtonUp(UIButtonHint sender)
	{
		if (sender.Parm1 == 1 || sender.Parm1 == 4)
		{
			if (this.HintT2 != null)
			{
				this.HintT2.gameObject.SetActive(false);
			}
		}
		else if (sender.Parm1 == 2)
		{
			if (this.HintT3 != null)
			{
				this.HintT3.gameObject.SetActive(false);
			}
		}
		else if (sender.Parm1 == 3)
		{
			if (this.HintT4 != null)
			{
				this.HintT4.gameObject.SetActive(false);
			}
		}
		else if (sender.Parm1 == 5)
		{
			if (this.HintT3 != null)
			{
				this.HintT3.gameObject.SetActive(false);
			}
		}
		else if (sender.Parm1 == 6)
		{
			if (this.HintTFIFA != null)
			{
				this.HintTFIFA.gameObject.SetActive(false);
			}
		}
		else
		{
			this.HintT.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000D77 RID: 3447 RVA: 0x00157434 File Offset: 0x00155634
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x06000D78 RID: 3448 RVA: 0x00157478 File Offset: 0x00155678
	private void SetTimeTitle()
	{
		if (this.tmpData.EventState == EActivityState.EAS_Prepare)
		{
			this.TimeSA.SetSpriteIndex(1);
			this.TimeTitle.enabled = true;
			this.TimeTitle.text = this.DM.mStringTable.GetStringByID(8111u);
		}
		else if (this.tmpData.EventState == EActivityState.EAS_Run)
		{
			this.TimeSA.SetSpriteIndex(0);
			this.TimeTitle.enabled = true;
			this.TimeTitle.text = this.DM.mStringTable.GetStringByID(8110u);
		}
		else if (this.tmpData.EventState == EActivityState.EAS_HomeEnd || this.tmpData.EventState == EActivityState.EAS_HomeStart || this.tmpData.EventState == EActivityState.EAS_StartRanking)
		{
			this.TimeSA.SetSpriteIndex(1);
			this.TimeTitle.enabled = true;
			this.TimeTitle.text = this.DM.mStringTable.GetStringByID(9810u);
		}
		else if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
		{
			this.TimeSA.SetSpriteIndex(1);
			if (this.tmpData.ActiveType == EActivityType.EAT_KingOfTheWorld)
			{
				this.TimeTitle.text = this.DM.mStringTable.GetStringByID(10010u);
			}
			else
			{
				this.TimeTitle.text = this.DM.mStringTable.GetStringByID(9819u);
			}
			this.TimeTitle.enabled = false;
			this.TimeTitle2.enabled = true;
			if (this.tmpData.ActiveType == EActivityType.EAT_KingOfTheWorld)
			{
				this.TimeTitle2.text = this.DM.mStringTable.GetStringByID(10010u);
			}
			else if (this.tmpData.ActiveType == EActivityType.EAT_AllianceSummon)
			{
				this.TimeTitle2.text = this.DM.mStringTable.GetStringByID(14520u);
			}
			else if (this.tmpData.ActiveType == EActivityType.EAT_FederalEvent)
			{
				this.TimeTitle2.text = this.DM.mStringTable.GetStringByID(5042u);
			}
			else if (this.tmpData.ActiveType == EActivityType.EAT_FIFA)
			{
				this.TimeTitle2.text = this.DM.mStringTable.GetStringByID(5042u);
			}
			else
			{
				this.TimeTitle2.text = this.DM.mStringTable.GetStringByID(9819u);
			}
		}
	}

	// Token: 0x06000D79 RID: 3449 RVA: 0x00157718 File Offset: 0x00155918
	private void SetTimeStr()
	{
		if (this.TimeText == null)
		{
			return;
		}
		this.TimeStr.Length = 0;
		if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking && this.tmpData.ActiveType != EActivityType.EAT_AllianceSummon)
		{
			this.TimeText.text = this.TimeStr.ToString();
			this.TimeText.SetAllDirty();
			this.TimeText.cachedTextGenerator.Invalidate();
		}
		else
		{
			GameConstants.GetTimeString(this.TimeStr, (uint)this.tmpData.EventCountTime, false, true, false, false, true);
			this.TimeText.text = this.TimeStr.ToString();
			this.TimeText.SetAllDirty();
			this.TimeText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06000D7A RID: 3450 RVA: 0x001577EC File Offset: 0x001559EC
	private void SetStepScore(ulong Score)
	{
		if (this.tmpData == null || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKEvent || this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_KingdomEvent || this.tmpData.ActiveType == EActivityType.EAT_KingOfTheWorld || this.tmpData.ActiveType == EActivityType.EAT_FederalEvent)
		{
			return;
		}
		this.nowScore = Score;
		this.NowScoreStr.Length = 0;
		this.NowScoreStr.uLongToFormat(Score, 1, true);
		this.NowScoreStr.AppendFormat("{0}");
		this.NowScoreText.text = this.NowScoreStr.ToString();
		this.NowScoreText.SetAllDirty();
		this.NowScoreText.cachedTextGenerator.Invalidate();
		for (int i = 0; i < 3; i++)
		{
			this.SliderNormal[i].fillAmount = 0f;
			this.SliderFlash[i].gameObject.SetActive(false);
			this.PrizeStageImg[i].gameObject.SetActive(false);
			if (this.tmpData.EventBonusType == EActEventBonusType.EAEBT_RequireScoreDown)
			{
				this.StageScoreText[i].color = this.GreenColor;
			}
			else
			{
				this.StageScoreText[i].color = Color.white;
			}
		}
		ulong x = 0UL;
		this.nowStep = 0;
		for (int j = 0; j < 3; j++)
		{
			if (this.nowScore >= this.StepScore[j])
			{
				this.nowStep += 1;
			}
		}
		if (this.nowStep < 3)
		{
			x = this.StepScore[(int)this.nowStep] - Score;
			if (this.nowStep == 0)
			{
				double num = this.StepScore[(int)this.nowStep];
				if (num > 0.0)
				{
					this.SliderNormal[(int)this.nowStep].fillAmount = (float)(Score / num);
				}
				else
				{
					this.SliderNormal[(int)this.nowStep].fillAmount = 0f;
				}
			}
			else
			{
				double num2 = this.StepScore[(int)this.nowStep] - this.StepScore[(int)(this.nowStep - 1)];
				if (num2 > 0.0)
				{
					this.SliderNormal[(int)this.nowStep].fillAmount = (float)((Score - this.StepScore[(int)(this.nowStep - 1)]) / num2);
				}
				else
				{
					this.SliderNormal[(int)this.nowStep].fillAmount = 0f;
				}
			}
			RectTransform rectTransform = this.SliderNormal[(int)this.nowStep].rectTransform;
			this.TopTriImage.rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x + rectTransform.sizeDelta.x * this.SliderNormal[(int)this.nowStep].fillAmount - 15f, this.TriLastPos.y);
		}
		else
		{
			this.TopTriImage.rectTransform.anchoredPosition = this.TriLastPos;
		}
		for (int k = 0; k < (int)this.nowStep; k++)
		{
			this.SliderNormal[k].fillAmount = 1f;
			this.SliderFlash[k].gameObject.SetActive(true);
			this.PrizeStageImg[k].gameObject.SetActive(true);
			this.StageScoreText[k].color = this.StageScoreColorY;
		}
		this.NextScoreStr.Length = 0;
		this.NextScoreStr.uLongToFormat(x, 1, true);
		this.NextScoreStr.AppendFormat("{0}");
		this.NextScoreText.text = this.NextScoreStr.ToString();
		this.NextScoreText.SetAllDirty();
		this.NextScoreText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000D7B RID: 3451 RVA: 0x00157BB4 File Offset: 0x00155DB4
	private void SetSummonBtnState()
	{
		if (this.ActivityIndex != 208)
		{
			return;
		}
		this.SummonBtn.SetActive(true);
		this.SummonFlash.SetActive(false);
		this.SummonAlert.SetActive(false);
	}

	// Token: 0x06000D7C RID: 3452 RVA: 0x00157BEC File Offset: 0x00155DEC
	public string GetScoreFactorStr(EGetScoreFactor Factor)
	{
		switch (Factor)
		{
		case EGetScoreFactor.EGSF_TrainingSoldier:
			return this.DM.mStringTable.GetStringByID(8124u);
		case EGetScoreFactor.EGSF_Research:
			return this.DM.mStringTable.GetStringByID(8125u);
		case EGetScoreFactor.EGSF_Building:
			return this.DM.mStringTable.GetStringByID(8126u);
		case EGetScoreFactor.EGSF_KillTroop:
			return this.DM.mStringTable.GetStringByID(8129u);
		case EGetScoreFactor.EGSF_Gather:
			return this.DM.mStringTable.GetStringByID(8130u);
		case EGetScoreFactor.EGSF_TrainingTrap:
			return this.DM.mStringTable.GetStringByID(8166u);
		case EGetScoreFactor.EGSF_NPC:
			return this.DM.mStringTable.GetStringByID(8127u);
		case EGetScoreFactor.EGSF_WonderOccupy:
			return this.DM.mStringTable.GetStringByID(9808u);
		case EGetScoreFactor.EGSF_KVKKillEnemy:
			return this.DM.mStringTable.GetStringByID(9806u);
		case EGetScoreFactor.EGSF_KVKNPC:
			return this.DM.mStringTable.GetStringByID(9807u);
		case EGetScoreFactor.EGSF_KVKGather:
			return this.DM.mStringTable.GetStringByID(12005u);
		case EGetScoreFactor.EGSF_Gamble:
			return this.DM.mStringTable.GetStringByID(9171u);
		case EGetScoreFactor.EGSF_CompleteInfernalEvent:
			return this.DM.mStringTable.GetStringByID(14536u);
		case EGetScoreFactor.EGSF_WinNPCCity:
			return this.DM.mStringTable.GetStringByID(14537u);
		case EGetScoreFactor.EGSF_Donate:
			return this.DM.mStringTable.GetStringByID(14544u);
		case EGetScoreFactor.EGSF_MakePetBox:
			return this.DM.mStringTable.GetStringByID(17516u);
		case EGetScoreFactor.EGSF_FIFAWonder:
			return this.DM.mStringTable.GetStringByID(12206u);
		case EGetScoreFactor.EGSF_FIFANPC:
			return this.DM.mStringTable.GetStringByID(12207u);
		case EGetScoreFactor.EGSF_FIFAKVKWonder:
			return this.DM.mStringTable.GetStringByID(12206u);
		case EGetScoreFactor.EGSF_FIFAKVKNPCCity:
			return this.DM.mStringTable.GetStringByID(14748u);
		}
		return string.Empty;
	}

	// Token: 0x06000D7D RID: 3453 RVA: 0x00157E20 File Offset: 0x00156020
	public byte GetScoreFactorCount(EGetScoreFactor Factor)
	{
		switch (Factor)
		{
		case EGetScoreFactor.EGSF_TrainingSoldier:
			return 4;
		case EGetScoreFactor.EGSF_Research:
			return 1;
		case EGetScoreFactor.EGSF_Building:
			return 1;
		case EGetScoreFactor.EGSF_KillTroop:
			return 8;
		case EGetScoreFactor.EGSF_Gather:
			return 6;
		case EGetScoreFactor.EGSF_TrainingTrap:
			return 4;
		case EGetScoreFactor.EGSF_NPC:
			return 10;
		case EGetScoreFactor.EGSF_WonderOccupy:
			if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKSoloEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalSoloEvent || (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_SoloEvent))
			{
				return 4;
			}
			return 2;
		case EGetScoreFactor.EGSF_KVKKillEnemy:
			return 8;
		case EGetScoreFactor.EGSF_KVKNPC:
			return 10;
		case EGetScoreFactor.EGSF_KVKGather:
			return 5;
		case EGetScoreFactor.EGSF_Gamble:
			return 2;
		case EGetScoreFactor.EGSF_CompleteInfernalEvent:
			return 1;
		case EGetScoreFactor.EGSF_MakePetBox:
			return 4;
		case EGetScoreFactor.EGSF_FIFAWonder:
			return 2;
		case EGetScoreFactor.EGSF_FIFANPC:
			return 5;
		case EGetScoreFactor.EGSF_FIFAKVKWonder:
			return 2;
		case EGetScoreFactor.EGSF_FIFAKVKNPCCity:
			return 5;
		}
		return 0;
	}

	// Token: 0x06000D7E RID: 3454 RVA: 0x00157F00 File Offset: 0x00156100
	public void SetScoreFactorHintL(EGetScoreFactor Factor, int index, CString tmpStr)
	{
		tmpStr.Length = 0;
		switch (Factor)
		{
		case EGetScoreFactor.EGSF_TrainingSoldier:
			tmpStr.IntToFormat((long)(index + 1), 1, false);
			tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8131u));
			break;
		case EGetScoreFactor.EGSF_Research:
			tmpStr.Append(this.DM.mStringTable.GetStringByID(8132u));
			break;
		case EGetScoreFactor.EGSF_Building:
			tmpStr.Append(this.DM.mStringTable.GetStringByID(8133u));
			break;
		case EGetScoreFactor.EGSF_KillTroop:
			if (index < 4)
			{
				tmpStr.IntToFormat((long)(index + 1), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8138u));
			}
			else
			{
				tmpStr.IntToFormat((long)(index - 3), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8160u));
			}
			break;
		case EGetScoreFactor.EGSF_Gather:
			switch (index)
			{
			case 0:
				tmpStr.Append(this.DM.mStringTable.GetStringByID(8139u));
				break;
			case 1:
				tmpStr.Append(this.DM.mStringTable.GetStringByID(8140u));
				break;
			case 2:
				tmpStr.Append(this.DM.mStringTable.GetStringByID(8141u));
				break;
			case 3:
				tmpStr.Append(this.DM.mStringTable.GetStringByID(8142u));
				break;
			case 4:
				tmpStr.Append(this.DM.mStringTable.GetStringByID(8143u));
				break;
			case 5:
				tmpStr.Append(this.DM.mStringTable.GetStringByID(8144u));
				break;
			}
			break;
		case EGetScoreFactor.EGSF_TrainingTrap:
			tmpStr.IntToFormat((long)(index + 1), 1, false);
			tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8167u));
			break;
		case EGetScoreFactor.EGSF_NPC:
			if (index < 5)
			{
				tmpStr.IntToFormat((long)(index + 1), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8134u));
			}
			else
			{
				tmpStr.IntToFormat((long)(index - 4), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8135u));
			}
			break;
		case EGetScoreFactor.EGSF_WonderOccupy:
			if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKSoloEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalSoloEvent || (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_SoloEvent))
			{
				if (index == 0)
				{
					tmpStr.Append(this.DM.mStringTable.GetStringByID(9829u));
				}
				else if (index == 1)
				{
					tmpStr.Append(this.DM.mStringTable.GetStringByID(9830u));
				}
				else if (index == 2)
				{
					tmpStr.Append(this.DM.mStringTable.GetStringByID(9832u));
				}
				else if (index == 3)
				{
					tmpStr.Append(this.DM.mStringTable.GetStringByID(9833u));
				}
			}
			else if (index == 0)
			{
				tmpStr.Append(this.DM.mStringTable.GetStringByID(9831u));
			}
			else if (index == 1)
			{
				tmpStr.Append(this.DM.mStringTable.GetStringByID(9834u));
			}
			break;
		case EGetScoreFactor.EGSF_KVKKillEnemy:
			if (index < 4)
			{
				tmpStr.IntToFormat((long)(index + 1), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(9835u));
			}
			else
			{
				tmpStr.IntToFormat((long)(index - 3), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(12006u));
			}
			break;
		case EGetScoreFactor.EGSF_KVKNPC:
			if (index < 5)
			{
				tmpStr.IntToFormat((long)(index + 1), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(9837u));
			}
			else
			{
				tmpStr.IntToFormat((long)(index - 4), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(9836u));
			}
			break;
		case EGetScoreFactor.EGSF_KVKGather:
		{
			byte facotr = (byte)Factor;
			uint score = this.AM.GetKVKActivityScore_SDataByFactor(facotr, (byte)(index + 1)).Score1;
			tmpStr.IntToFormat((long)((ulong)score), 1, true);
			tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID((uint)(12015 + index)));
			break;
		}
		case EGetScoreFactor.EGSF_Gamble:
			if (index == 1)
			{
				tmpStr.Append(this.DM.mStringTable.GetStringByID(9859u));
			}
			else if (index == 0)
			{
				tmpStr.Append(this.DM.mStringTable.GetStringByID(9860u));
			}
			break;
		case EGetScoreFactor.EGSF_CompleteInfernalEvent:
			tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(14539u));
			break;
		case EGetScoreFactor.EGSF_MakePetBox:
			tmpStr.Append(this.DM.mStringTable.GetStringByID((uint)(17517 + index)));
			break;
		case EGetScoreFactor.EGSF_FIFAWonder:
			tmpStr.Append(this.DM.mStringTable.GetStringByID((uint)(12215 + index)));
			break;
		case EGetScoreFactor.EGSF_FIFANPC:
			tmpStr.IntToFormat((long)(index + 1), 1, false);
			tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(12217u));
			break;
		case EGetScoreFactor.EGSF_FIFAKVKWonder:
			if (index == 0)
			{
				tmpStr.Append(this.DM.mStringTable.GetStringByID(12215u));
			}
			else if (index == 1)
			{
				byte level = 1;
				if (this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_AllianceEvent)
				{
					level = 3;
				}
				else if (this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_KingdomEvent)
				{
					level = 5;
				}
				byte facotr2 = (byte)Factor;
				uint score2 = this.AM.GetKVKActivityScore_SDataByFactor(facotr2, level).Score1;
				tmpStr.IntToFormat((long)((ulong)score2), 1, true);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(14746u));
			}
			else if (index == 3)
			{
				tmpStr.Append(this.DM.mStringTable.GetStringByID(12216u));
			}
			else if (index == 4)
			{
				byte b = 1;
				if (this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_AllianceEvent)
				{
					b = 3;
				}
				else if (this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_KingdomEvent)
				{
					b = 5;
				}
				byte facotr3 = (byte)Factor;
				uint score3 = this.AM.GetKVKActivityScore_SDataByFactor(facotr3, b + 1).Score1;
				tmpStr.IntToFormat((long)((ulong)score3), 1, true);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(14747u));
			}
			break;
		case EGetScoreFactor.EGSF_FIFAKVKNPCCity:
			tmpStr.IntToFormat((long)(index + 1), 1, false);
			tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(14749u));
			break;
		}
	}

	// Token: 0x06000D7F RID: 3455 RVA: 0x00158654 File Offset: 0x00156854
	public void SetScoreFactorHintR(EGetScoreFactor Factor, int index, CString tmpStr, int x)
	{
		tmpStr.Length = 0;
		switch (Factor)
		{
		case EGetScoreFactor.EGSF_TrainingSoldier:
			if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
			{
				byte facotr = (byte)Factor;
				uint num = 0u;
				switch (index)
				{
				case 0:
					num = this.AM.GetKVKActivityScore_SDataByFactor(facotr, 1).Score1;
					break;
				case 1:
					num = this.AM.GetKVKActivityScore_SDataByFactor(facotr, 2).Score1;
					break;
				case 2:
					num = this.AM.GetKVKActivityScore_SDataByFactor(facotr, 3).Score1;
					break;
				case 3:
					num = this.AM.GetKVKActivityScore_SDataByFactor(facotr, 4).Score1;
					break;
				}
				tmpStr.IntToFormat((long)((ulong)num * (ulong)((long)x)), 1, true);
			}
			else
			{
				switch (index)
				{
				case 0:
					tmpStr.IntToFormat((long)(1 * x), 1, true);
					break;
				case 1:
					tmpStr.IntToFormat((long)(2 * x), 1, true);
					break;
				case 2:
					tmpStr.IntToFormat((long)(5 * x), 1, true);
					break;
				case 3:
					tmpStr.IntToFormat((long)(15 * x), 1, true);
					break;
				}
			}
			break;
		case EGetScoreFactor.EGSF_Research:
			if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
			{
				byte facotr2 = (byte)Factor;
				uint score = this.AM.GetKVKActivityScore_SDataByFactor(facotr2, 1).Score1;
				tmpStr.IntToFormat((long)((ulong)score * (ulong)((long)x)), 1, true);
			}
			else
			{
				tmpStr.IntToFormat((long)(1 * x), 1, true);
			}
			break;
		case EGetScoreFactor.EGSF_Building:
			if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
			{
				byte facotr3 = (byte)Factor;
				uint score2 = this.AM.GetKVKActivityScore_SDataByFactor(facotr3, 1).Score1;
				tmpStr.IntToFormat((long)((ulong)score2 * (ulong)((long)x)), 1, true);
			}
			else
			{
				tmpStr.IntToFormat((long)(1 * x), 1, true);
			}
			break;
		case EGetScoreFactor.EGSF_KillTroop:
			switch (index)
			{
			case 0:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 1:
				tmpStr.IntToFormat((long)(2 * x), 1, true);
				break;
			case 2:
				tmpStr.IntToFormat((long)(5 * x), 1, true);
				break;
			case 3:
				tmpStr.IntToFormat((long)(15 * x), 1, true);
				break;
			case 4:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 5:
				tmpStr.IntToFormat((long)(2 * x), 1, true);
				break;
			case 6:
				tmpStr.IntToFormat((long)(5 * x), 1, true);
				break;
			case 7:
				tmpStr.IntToFormat((long)(15 * x), 1, true);
				break;
			}
			break;
		case EGetScoreFactor.EGSF_Gather:
			switch (index)
			{
			case 0:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 1:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 2:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 3:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 4:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 5:
				tmpStr.IntToFormat((long)(100 * x), 1, true);
				break;
			}
			break;
		case EGetScoreFactor.EGSF_TrainingTrap:
			switch (index)
			{
			case 0:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 1:
				tmpStr.IntToFormat((long)(2 * x), 1, true);
				break;
			case 2:
				tmpStr.IntToFormat((long)(5 * x), 1, true);
				break;
			case 3:
				tmpStr.IntToFormat((long)(15 * x), 1, true);
				break;
			}
			break;
		case EGetScoreFactor.EGSF_NPC:
		{
			uint num2;
			if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
			{
				byte facotr4 = (byte)Factor;
				if (index < 5)
				{
					num2 = this.AM.GetKVKActivityScore_SDataByFactor(facotr4, (byte)(index + 1)).Score2;
				}
				else
				{
					num2 = this.AM.GetKVKActivityScore_SDataByFactor(facotr4, (byte)(index - 4)).Score1;
				}
			}
			else if (index < 5)
			{
				num2 = this.DM.MonsterActivityScoreTable.GetRecordByIndex((int)((ushort)index)).FightPoint;
			}
			else
			{
				num2 = this.DM.MonsterActivityScoreTable.GetRecordByIndex((int)((ushort)(index - 5))).KillPoint;
			}
			tmpStr.IntToFormat((long)((ulong)num2 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_WonderOccupy:
		{
			uint num3 = 0u;
			byte facotr5 = (byte)Factor;
			if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKSoloEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalSoloEvent || (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_SoloEvent))
			{
				switch (index)
				{
				case 0:
					num3 = this.AM.GetKVKActivityScore_SDataByFactor(facotr5, 1).Score2;
					break;
				case 1:
					num3 = this.AM.GetKVKActivityScore_SDataByFactor(facotr5, 1).Score1;
					break;
				case 2:
					num3 = this.AM.GetKVKActivityScore_SDataByFactor(facotr5, 2).Score2;
					break;
				case 3:
					num3 = this.AM.GetKVKActivityScore_SDataByFactor(facotr5, 2).Score1;
					break;
				}
			}
			else if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKAllianceEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalAllianceEvent || (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_AllianceEvent))
			{
				if (index != 0)
				{
					if (index == 1)
					{
						num3 = this.AM.GetKVKActivityScore_SDataByFactor(facotr5, 4).Score1;
					}
				}
				else
				{
					num3 = this.AM.GetKVKActivityScore_SDataByFactor(facotr5, 3).Score1;
				}
			}
			else if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKEvent || (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_KingdomEvent))
			{
				if (index != 0)
				{
					if (index == 1)
					{
						num3 = this.AM.GetKVKActivityScore_SDataByFactor(facotr5, 4).Score2;
					}
				}
				else
				{
					num3 = this.AM.GetKVKActivityScore_SDataByFactor(facotr5, 3).Score2;
				}
			}
			tmpStr.IntToFormat((long)((ulong)num3 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_KVKKillEnemy:
		{
			byte facotr6 = (byte)Factor;
			uint score3;
			if (index < 4)
			{
				score3 = this.AM.GetKVKActivityScore_SDataByFactor(facotr6, (byte)(index + 1)).Score2;
			}
			else
			{
				score3 = this.AM.GetKVKActivityScore_SDataByFactor(facotr6, (byte)(index - 3)).Score2;
			}
			tmpStr.IntToFormat((long)((ulong)score3 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_KVKNPC:
		{
			byte facotr7 = (byte)Factor;
			uint num4;
			if (index < 5)
			{
				num4 = this.AM.GetKVKActivityScore_SDataByFactor(facotr7, (byte)(index + 1)).Score2;
			}
			else
			{
				num4 = this.AM.GetKVKActivityScore_SDataByFactor(facotr7, (byte)(index - 4)).Score1;
			}
			tmpStr.IntToFormat((long)((ulong)num4 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_KVKGather:
		{
			byte facotr8 = (byte)Factor;
			uint score4 = this.AM.GetKVKActivityScore_SDataByFactor(facotr8, (byte)(index + 1)).Score2;
			tmpStr.IntToFormat((long)((ulong)score4 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_Gamble:
		{
			uint score5 = this.AM.GetKVKActivityScore_SDataByFactor((byte)Factor, (byte)index).Score1;
			tmpStr.IntToFormat((long)((ulong)score5 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_CompleteInfernalEvent:
		{
			byte facotr9 = (byte)Factor;
			uint score6 = this.AM.GetKVKActivityScore_SDataByFactor(facotr9, 1).Score2;
			tmpStr.IntToFormat((long)((ulong)score6 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_MakePetBox:
		{
			byte facotr10 = (byte)Factor;
			uint score7 = this.AM.GetKVKActivityScore_SDataByFactor(facotr10, (byte)(index + 1)).Score1;
			tmpStr.IntToFormat((long)((ulong)score7 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_FIFAWonder:
		{
			byte facotr11 = (byte)Factor;
			uint score8 = this.AM.GetKVKActivityScore_SDataByFactor(facotr11, (byte)(index + 1)).Score1;
			tmpStr.IntToFormat((long)((ulong)score8 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_FIFANPC:
		{
			byte facotr12 = (byte)Factor;
			uint score9 = this.AM.GetKVKActivityScore_SDataByFactor(facotr12, (byte)(index + 1)).Score1;
			tmpStr.IntToFormat((long)((ulong)score9 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_FIFAKVKWonder:
		{
			byte facotr13 = (byte)Factor;
			byte b = 1;
			if (this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_AllianceEvent)
			{
				b = 3;
			}
			else if (this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_KingdomEvent)
			{
				b = 5;
			}
			if (index == 0)
			{
				uint score10 = this.AM.GetKVKActivityScore_SDataByFactor(facotr13, b).Score2;
				tmpStr.IntToFormat((long)((ulong)score10 * (ulong)((long)x)), 1, true);
			}
			else if (index == 3)
			{
				uint score11 = this.AM.GetKVKActivityScore_SDataByFactor(facotr13, b + 1).Score2;
				tmpStr.IntToFormat((long)((ulong)score11 * (ulong)((long)x)), 1, true);
			}
			break;
		}
		case EGetScoreFactor.EGSF_FIFAKVKNPCCity:
		{
			byte facotr14 = (byte)Factor;
			uint score12 = this.AM.GetKVKActivityScore_SDataByFactor(facotr14, (byte)(index + 1)).Score1;
			tmpStr.IntToFormat((long)((ulong)score12 * (ulong)((long)x)), 1, true);
			break;
		}
		}
		if (x > 1 && (this.tmpData.ActiveType == EActivityType.EAT_KingdomMatchEvent || this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK) && this.AM.MatchKingdomCount == 4)
		{
			tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(12096u));
		}
		else
		{
			tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8145u));
		}
	}

	// Token: 0x06000D80 RID: 3456 RVA: 0x001590A4 File Offset: 0x001572A4
	public void SetScoreFactorHintL_AS(EGetScoreFactor Factor, int index, CString tmpStr)
	{
		tmpStr.Length = 0;
		switch (Factor)
		{
		case EGetScoreFactor.EGSF_TrainingSoldier:
			tmpStr.IntToFormat((long)(index + 1), 1, false);
			tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8131u));
			break;
		case EGetScoreFactor.EGSF_Research:
			tmpStr.Append(this.DM.mStringTable.GetStringByID(8132u));
			break;
		case EGetScoreFactor.EGSF_Building:
			tmpStr.Append(this.DM.mStringTable.GetStringByID(8133u));
			break;
		case EGetScoreFactor.EGSF_KillTroop:
			if (index < 4)
			{
				tmpStr.IntToFormat((long)(index + 1), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8138u));
			}
			else
			{
				tmpStr.IntToFormat((long)(index - 3), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8160u));
			}
			break;
		case EGetScoreFactor.EGSF_Gather:
			switch (index)
			{
			case 0:
				tmpStr.Append(this.DM.mStringTable.GetStringByID(8139u));
				break;
			case 1:
				tmpStr.Append(this.DM.mStringTable.GetStringByID(8140u));
				break;
			case 2:
				tmpStr.Append(this.DM.mStringTable.GetStringByID(8141u));
				break;
			case 3:
				tmpStr.Append(this.DM.mStringTable.GetStringByID(8142u));
				break;
			case 4:
				tmpStr.Append(this.DM.mStringTable.GetStringByID(8143u));
				break;
			case 5:
				tmpStr.Append(this.DM.mStringTable.GetStringByID(8144u));
				break;
			}
			break;
		case EGetScoreFactor.EGSF_TrainingTrap:
			tmpStr.IntToFormat((long)(index + 1), 1, false);
			tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8167u));
			break;
		case EGetScoreFactor.EGSF_NPC:
			if (index < 5)
			{
				tmpStr.IntToFormat((long)(index + 1), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8134u));
			}
			else
			{
				tmpStr.IntToFormat((long)(index - 4), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8135u));
			}
			break;
		case EGetScoreFactor.EGSF_WonderOccupy:
			if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKSoloEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalSoloEvent || (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_SoloEvent))
			{
				if (index == 0)
				{
					tmpStr.Append(this.DM.mStringTable.GetStringByID(9829u));
				}
				else if (index == 1)
				{
					tmpStr.Append(this.DM.mStringTable.GetStringByID(9830u));
				}
				else if (index == 2)
				{
					tmpStr.Append(this.DM.mStringTable.GetStringByID(9832u));
				}
				else if (index == 3)
				{
					tmpStr.Append(this.DM.mStringTable.GetStringByID(9833u));
				}
			}
			else if (index == 0)
			{
				tmpStr.Append(this.DM.mStringTable.GetStringByID(9831u));
			}
			else if (index == 1)
			{
				tmpStr.Append(this.DM.mStringTable.GetStringByID(9834u));
			}
			break;
		case EGetScoreFactor.EGSF_KVKKillEnemy:
			if (index < 4)
			{
				tmpStr.IntToFormat((long)(index + 1), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(9835u));
			}
			else
			{
				tmpStr.IntToFormat((long)(index - 3), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(12006u));
			}
			break;
		case EGetScoreFactor.EGSF_KVKNPC:
			if (index < 5)
			{
				tmpStr.IntToFormat((long)(index + 1), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(9837u));
			}
			else
			{
				tmpStr.IntToFormat((long)(index - 4), 1, false);
				tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(9836u));
			}
			break;
		case EGetScoreFactor.EGSF_KVKGather:
		{
			byte facotr = (byte)Factor;
			uint score = this.AM.GetAllianceSummonScore_SDataByFactor(facotr, (byte)(index + 1)).Score1;
			tmpStr.IntToFormat((long)((ulong)score), 1, true);
			tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID((uint)(12015 + index)));
			break;
		}
		case EGetScoreFactor.EGSF_Gamble:
			if (index == 1)
			{
				tmpStr.Append(this.DM.mStringTable.GetStringByID(9859u));
			}
			else if (index == 0)
			{
				tmpStr.Append(this.DM.mStringTable.GetStringByID(9860u));
			}
			break;
		case EGetScoreFactor.EGSF_CompleteInfernalEvent:
			tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(14539u));
			break;
		case EGetScoreFactor.EGSF_MakePetBox:
			tmpStr.Append(this.DM.mStringTable.GetStringByID((uint)(17517 + index)));
			break;
		case EGetScoreFactor.EGSF_FIFAWonder:
			tmpStr.Append(this.DM.mStringTable.GetStringByID((uint)(12215 + index)));
			break;
		case EGetScoreFactor.EGSF_FIFANPC:
			tmpStr.IntToFormat((long)(index + 1), 1, false);
			tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(12217u));
			break;
		}
	}

	// Token: 0x06000D81 RID: 3457 RVA: 0x00159674 File Offset: 0x00157874
	public void SetScoreFactorHintR_AS(EGetScoreFactor Factor, int index, CString tmpStr, int x)
	{
		tmpStr.Length = 0;
		switch (Factor)
		{
		case EGetScoreFactor.EGSF_TrainingSoldier:
			if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
			{
				byte facotr = (byte)Factor;
				uint num = 0u;
				switch (index)
				{
				case 0:
					num = this.AM.GetAllianceSummonScore_SDataByFactor(facotr, 1).Score1;
					break;
				case 1:
					num = this.AM.GetAllianceSummonScore_SDataByFactor(facotr, 2).Score1;
					break;
				case 2:
					num = this.AM.GetAllianceSummonScore_SDataByFactor(facotr, 3).Score1;
					break;
				case 3:
					num = this.AM.GetAllianceSummonScore_SDataByFactor(facotr, 4).Score1;
					break;
				}
				tmpStr.IntToFormat((long)((ulong)num * (ulong)((long)x)), 1, true);
			}
			else
			{
				switch (index)
				{
				case 0:
					tmpStr.IntToFormat((long)(1 * x), 1, true);
					break;
				case 1:
					tmpStr.IntToFormat((long)(2 * x), 1, true);
					break;
				case 2:
					tmpStr.IntToFormat((long)(5 * x), 1, true);
					break;
				case 3:
					tmpStr.IntToFormat((long)(15 * x), 1, true);
					break;
				}
			}
			break;
		case EGetScoreFactor.EGSF_Research:
			if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
			{
				byte facotr2 = (byte)Factor;
				uint score = this.AM.GetAllianceSummonScore_SDataByFactor(facotr2, 1).Score1;
				tmpStr.IntToFormat((long)((ulong)score * (ulong)((long)x)), 1, true);
			}
			else
			{
				tmpStr.IntToFormat((long)(1 * x), 1, true);
			}
			break;
		case EGetScoreFactor.EGSF_Building:
			if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
			{
				byte facotr3 = (byte)Factor;
				uint score2 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr3, 1).Score1;
				tmpStr.IntToFormat((long)((ulong)score2 * (ulong)((long)x)), 1, true);
			}
			else
			{
				tmpStr.IntToFormat((long)(1 * x), 1, true);
			}
			break;
		case EGetScoreFactor.EGSF_KillTroop:
			switch (index)
			{
			case 0:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 1:
				tmpStr.IntToFormat((long)(2 * x), 1, true);
				break;
			case 2:
				tmpStr.IntToFormat((long)(5 * x), 1, true);
				break;
			case 3:
				tmpStr.IntToFormat((long)(15 * x), 1, true);
				break;
			case 4:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 5:
				tmpStr.IntToFormat((long)(2 * x), 1, true);
				break;
			case 6:
				tmpStr.IntToFormat((long)(5 * x), 1, true);
				break;
			case 7:
				tmpStr.IntToFormat((long)(15 * x), 1, true);
				break;
			}
			break;
		case EGetScoreFactor.EGSF_Gather:
			switch (index)
			{
			case 0:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 1:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 2:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 3:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 4:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 5:
				tmpStr.IntToFormat((long)(100 * x), 1, true);
				break;
			}
			break;
		case EGetScoreFactor.EGSF_TrainingTrap:
			switch (index)
			{
			case 0:
				tmpStr.IntToFormat((long)(1 * x), 1, true);
				break;
			case 1:
				tmpStr.IntToFormat((long)(2 * x), 1, true);
				break;
			case 2:
				tmpStr.IntToFormat((long)(5 * x), 1, true);
				break;
			case 3:
				tmpStr.IntToFormat((long)(15 * x), 1, true);
				break;
			}
			break;
		case EGetScoreFactor.EGSF_NPC:
		{
			byte facotr4 = (byte)Factor;
			uint num2;
			if (index < 5)
			{
				num2 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr4, (byte)(index + 1)).Score1;
			}
			else
			{
				num2 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr4, (byte)(index - 4)).Score2;
			}
			tmpStr.IntToFormat((long)((ulong)num2 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_WonderOccupy:
		{
			uint num3 = 0u;
			byte facotr5 = (byte)Factor;
			if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKSoloEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalSoloEvent || (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_SoloEvent))
			{
				switch (index)
				{
				case 0:
					num3 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr5, 1).Score2;
					break;
				case 1:
					num3 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr5, 1).Score1;
					break;
				case 2:
					num3 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr5, 2).Score2;
					break;
				case 3:
					num3 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr5, 2).Score1;
					break;
				}
			}
			else if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKAllianceEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalAllianceEvent || (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_AllianceEvent))
			{
				if (index != 0)
				{
					if (index == 1)
					{
						num3 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr5, 4).Score1;
					}
				}
				else
				{
					num3 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr5, 3).Score1;
				}
			}
			else if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKEvent || (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && this.tmpData.FIFAActiveType == EActivityKingdomEventType.EAKET_KingdomEvent))
			{
				if (index != 0)
				{
					if (index == 1)
					{
						num3 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr5, 4).Score2;
					}
				}
				else
				{
					num3 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr5, 3).Score2;
				}
			}
			tmpStr.IntToFormat((long)((ulong)num3 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_KVKKillEnemy:
		{
			byte facotr6 = (byte)Factor;
			uint score3;
			if (index < 4)
			{
				score3 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr6, (byte)(index + 1)).Score2;
			}
			else
			{
				score3 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr6, (byte)(index - 3)).Score2;
			}
			tmpStr.IntToFormat((long)((ulong)score3 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_KVKNPC:
		{
			byte facotr7 = (byte)Factor;
			uint num4;
			if (index < 5)
			{
				num4 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr7, (byte)(index + 1)).Score1;
			}
			else
			{
				num4 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr7, (byte)(index - 4)).Score2;
			}
			tmpStr.IntToFormat((long)((ulong)num4 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_KVKGather:
		{
			byte facotr8 = (byte)Factor;
			uint score4 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr8, (byte)(index + 1)).Score2;
			tmpStr.IntToFormat((long)((ulong)score4 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_Gamble:
		{
			uint score5 = this.AM.GetAllianceSummonScore_SDataByFactor((byte)Factor, (byte)index).Score1;
			tmpStr.IntToFormat((long)((ulong)score5 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_CompleteInfernalEvent:
		{
			byte facotr9 = (byte)Factor;
			uint score6 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr9, 1).Score1;
			tmpStr.IntToFormat((long)((ulong)score6 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_MakePetBox:
		{
			byte facotr10 = (byte)Factor;
			uint score7 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr10, (byte)(index + 1)).Score1;
			tmpStr.IntToFormat((long)((ulong)score7 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_FIFAWonder:
		{
			byte facotr11 = (byte)Factor;
			uint score8 = this.AM.GetKVKActivityScore_SDataByFactor(facotr11, (byte)(index + 1)).Score1;
			tmpStr.IntToFormat((long)((ulong)score8 * (ulong)((long)x)), 1, true);
			break;
		}
		case EGetScoreFactor.EGSF_FIFANPC:
		{
			byte facotr12 = (byte)Factor;
			uint score9 = this.AM.GetKVKActivityScore_SDataByFactor(facotr12, (byte)(index + 1)).Score1;
			tmpStr.IntToFormat((long)((ulong)score9 * (ulong)((long)x)), 1, true);
			break;
		}
		}
		tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8145u));
	}

	// Token: 0x06000D82 RID: 3458 RVA: 0x00159F28 File Offset: 0x00158128
	public void HeroActionChang()
	{
		if (this.BossGO == null)
		{
			return;
		}
		int index = UnityEngine.Random.Range(0, this.ANList.Count);
		byte b = (byte)this.ANList[index];
		AnimationClip animationClip = this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[(int)b]);
		this.HeroAct = AnimationUnit.ANIM_STRING[(int)b];
		if (this.ANList[index] == AnimationUnit.AnimName.SKILL1)
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
		}
		this.ActionTimeRandom = 0f;
		this.ActionTime = 0f;
	}

	// Token: 0x06000D83 RID: 3459 RVA: 0x00159FF8 File Offset: 0x001581F8
	public void LoadAB(bool ReLoad = false)
	{
		if (ReLoad && this.AB != null)
		{
			if (this.AssetKey != 0)
			{
				AssetManager.UnloadAssetBundle(this.AssetKey, true);
			}
			if (this.BossGO != null)
			{
				ModelLoader.Instance.Unload(this.BossGO);
			}
			this.AssetKey = 0;
			this.BossGO = null;
			this.AB = null;
			this.bABInitial = false;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)this.sHero.Modle, 5, false);
		cstring.AppendFormat("Role/hero_{0}");
		this.AB = AssetManager.GetAssetBundle(cstring, out this.AssetKey);
		if (this.AB != null)
		{
			this.AR = this.AB.LoadAsync("m", typeof(GameObject));
			this.bABInitial = false;
		}
	}

	// Token: 0x06000D84 RID: 3460 RVA: 0x0015A0E8 File Offset: 0x001582E8
	private float GetBestLineWidth(UIText tmpText, float MaxWidth, int minFontSize)
	{
		if (tmpText == null)
		{
			return MaxWidth;
		}
		while (tmpText.preferredWidth > MaxWidth && tmpText.fontSize > minFontSize)
		{
			tmpText.fontSize--;
			tmpText.SetLayoutDirty();
		}
		if (tmpText.fontSize <= minFontSize)
		{
			tmpText.fontSize = minFontSize;
			return MaxWidth;
		}
		return tmpText.preferredWidth;
	}

	// Token: 0x06000D85 RID: 3461 RVA: 0x0015A150 File Offset: 0x00158350
	private void CheckAllianceID()
	{
		if (this.ContentT == null || this.NoImgGO == null || this.NoText1 == null || this.NoText2 == null)
		{
			return;
		}
		if (!this.bSummonType)
		{
			return;
		}
		if (this.DM.RoleAlliance.Id == 0u)
		{
			this.SPT.GetChild(0).gameObject.SetActive(false);
			this.SPT.GetChild(1).gameObject.SetActive(false);
			this.SPT.GetChild(2).gameObject.SetActive(false);
			this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 364f);
			this.NoImgGO.SetActive(true);
			this.NoText1.gameObject.SetActive(false);
			this.NoText2.gameObject.SetActive(true);
			this.NoText2.text = this.DM.mStringTable.GetStringByID(1374u);
			this.NoText2.color = this.NoText1.color;
			return;
		}
		if (this.tmpData.EventState != EActivityState.EAS_Prepare && (this.AM.AllianceSummonAllianceID == 0u || this.DM.RoleAlliance.Id != this.AM.AllianceSummonAllianceID))
		{
			this.SPT.GetChild(0).gameObject.SetActive(false);
			this.SPT.GetChild(1).gameObject.SetActive(false);
			this.SPT.GetChild(2).gameObject.SetActive(false);
			this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 364f);
			this.NoImgGO.SetActive(true);
			this.NoText1.gameObject.SetActive(true);
			this.NoText1.text = this.DM.mStringTable.GetStringByID(1353u);
			this.NoText2.gameObject.SetActive(true);
			this.NoText2.text = this.DM.mStringTable.GetStringByID(1354u);
			this.NoText2.color = Color.white;
			return;
		}
		this.SPT.GetChild(0).gameObject.SetActive(true);
		this.SPT.GetChild(1).gameObject.SetActive(true);
		this.SPT.GetChild(2).gameObject.SetActive(true);
		this.NoImgGO.SetActive(false);
		this.NoText1.gameObject.SetActive(false);
		this.NoText2.gameObject.SetActive(false);
		this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 511f);
	}

	// Token: 0x06000D86 RID: 3462 RVA: 0x0015A444 File Offset: 0x00158644
	private void SetPointTexture(byte point, Image numImg)
	{
		if (!this.bSummonType)
		{
			return;
		}
		Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			if (point == 255)
			{
				numImg.sprite = door.LoadSprite("UI_mall_x_001");
			}
			else
			{
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.IntToFormat((long)point, 1, false);
				cstring.AppendFormat("UI_mall_{0}_001");
				numImg.sprite = door.LoadSprite(cstring);
			}
			numImg.material = door.LoadMaterial();
		}
	}

	// Token: 0x06000D87 RID: 3463 RVA: 0x0015A4D8 File Offset: 0x001586D8
	private void SetMonsterState()
	{
		if (!this.bSummonType || this.SummonFlash == null || this.SummonAlert == null)
		{
			return;
		}
		bool flag = this.AM.AllianceSummon_SummonData.MonsterEndTime > 0L;
		bool flag2 = this.AM.AllianceSummon_SummonData.CostPoint > 0 && this.AM.AllianceSummon_SummonData.SummonPoint / this.AM.AllianceSummon_SummonData.CostPoint >= 1;
		if (flag)
		{
			this.SummonFlash.SetActive(true);
		}
		else
		{
			this.SummonFlash.SetActive(false);
		}
		if (flag || flag2)
		{
			this.SummonAlert.SetActive(true);
		}
		else
		{
			this.SummonAlert.SetActive(false);
		}
		if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
		{
			if (this.SummonTimeObj == null || this.RankReplayTitleText == null)
			{
				return;
			}
			if (!this.SummonTimeObj.activeInHierarchy)
			{
				this.SummonTimeObj.SetActive(true);
			}
			if (flag || flag2)
			{
				this.SummonTimeObj.transform.GetChild(1).gameObject.SetActive(true);
				this.SummonTimeObj.transform.GetChild(2).gameObject.SetActive(true);
				this.RankReplayTitleText.text = this.DM.mStringTable.GetStringByID(14521u);
			}
			else
			{
				this.SummonTimeObj.transform.GetChild(1).gameObject.SetActive(false);
				this.SummonTimeObj.transform.GetChild(2).gameObject.SetActive(false);
				if (this.nowStep > 0)
				{
					this.RankReplayTitleText.text = this.DM.mStringTable.GetStringByID(14535u);
				}
				else
				{
					this.RankReplayTitleText.text = this.DM.mStringTable.GetStringByID(1594u);
				}
			}
		}
	}

	// Token: 0x06000D88 RID: 3464 RVA: 0x0015A6F8 File Offset: 0x001588F8
	private void SetNPCCityStarObj()
	{
		if (!this.bSummonType || this.StarObj == null || this.StarObj2 == null)
		{
			return;
		}
		bool flag = true;
		for (int i = 0; i < 5; i++)
		{
			SummonScoreData allianceSummonScore_SDataByFactor = this.AM.GetAllianceSummonScore_SDataByFactor(16, (byte)(i + 1));
			if ((uint)this.AM.NPCCityCombatTimes[i] < allianceSummonScore_SDataByFactor.Score2)
			{
				flag = false;
			}
		}
		this.StarObj.SetActive(!flag);
		this.StarObj2.SetActive(flag);
	}

	// Token: 0x06000D89 RID: 3465 RVA: 0x0015A798 File Offset: 0x00158998
	private void SetNPCCityCombatTimes(bool ForceSet = false)
	{
		if (!this.bSummonType || (!this.HintT4.gameObject.activeInHierarchy && !ForceSet))
		{
			return;
		}
		int num = 1;
		for (int i = 0; i < 5; i++)
		{
			SummonScoreData allianceSummonScore_SDataByFactor = this.AM.GetAllianceSummonScore_SDataByFactor(16, (byte)(i + 1));
			bool flag = (uint)this.AM.NPCCityCombatTimes[i] >= allianceSummonScore_SDataByFactor.Score2;
			if (flag)
			{
				this.RBText5[num].color = Color.yellow;
			}
			else
			{
				this.RBText5[num].color = Color.white;
			}
			num++;
			if (flag)
			{
				this.RBText5[num].color = Color.yellow;
			}
			else
			{
				this.RBText5[num].color = Color.white;
			}
			num++;
			this.Hint5Str[num].Length = 0;
			if (flag)
			{
				this.Hint5Str[num].Append(this.DM.mStringTable.GetStringByID(14543u));
				this.RBText5[num].color = Color.yellow;
			}
			else
			{
				this.Hint5Str[num].IntToFormat((long)((ulong)(allianceSummonScore_SDataByFactor.Score2 - (uint)this.AM.NPCCityCombatTimes[i])), 1, false);
				this.Hint5Str[num].AppendFormat(this.DM.mStringTable.GetStringByID(14542u));
				this.RBText5[num].color = Color.white;
			}
			this.RBText5[num].text = this.Hint5Str[num].ToString();
			this.RBText5[num].SetAllDirty();
			this.RBText5[num].cachedTextGeneratorForLayout.Invalidate();
			num++;
		}
	}

	// Token: 0x06000D8A RID: 3466 RVA: 0x0015A958 File Offset: 0x00158B58
	private void SetKVKReTime()
	{
		if (this.ReTimeText == null)
		{
			return;
		}
		if (this.tmpData.EventState != EActivityState.EAS_Run || this.AM.KVKReTime > this.tmpData.EventBeginTime + (long)((ulong)this.tmpData.EventReqiureTIme))
		{
			if (this.ReTimeImage.gameObject.activeInHierarchy || this.ReTimeText.gameObject.activeInHierarchy)
			{
				this.ReTimeImage.gameObject.SetActive(false);
				this.ReTimeText.gameObject.SetActive(false);
			}
			return;
		}
		long num = this.AM.KVKReTime - this.AM.ServerEventTime;
		if (num < 0L)
		{
			num = 0L;
		}
		this.ReTimeStr.Length = 0;
		GameConstants.GetTimeString(this.ReTimeStr, (uint)num, false, true, false, false, true);
		this.ReTimeText.text = this.ReTimeStr.ToString();
		this.ReTimeText.SetAllDirty();
		this.ReTimeText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000D8B RID: 3467 RVA: 0x0015AA70 File Offset: 0x00158C70
	private void SetReLineAndPic()
	{
		if (this.ReImageTarget == null)
		{
			return;
		}
		if (this.HintT3 != null)
		{
			this.HintT3.gameObject.SetActive(false);
		}
		if (this.HintT != null)
		{
			this.HintT.gameObject.SetActive(false);
		}
		if (this.tmpData.EventState != EActivityState.EAS_Run && this.tmpData.EventState != EActivityState.EAS_Prepare)
		{
			this.KVKLine1.SetActive(false);
			this.KVKLine2.SetActive(false);
			this.ReImageTarget.gameObject.SetActive(false);
			this.ReImageDevil.gameObject.SetActive(false);
			return;
		}
		this.ReImageTarget.gameObject.SetActive(true);
		this.ReImageDevil.gameObject.SetActive(true);
		if (this.AM.KVKHuntOrder == 2)
		{
			this.ReImageTarget.rectTransform.anchoredPosition = new Vector2(-167f, 174.5f);
			this.ReImageDevil.rectTransform.anchoredPosition = new Vector2(166f, 175f);
			this.ReImageDevil.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
			this.KVKLine1.SetActive(false);
			this.KVKLine2.SetActive(true);
		}
		else
		{
			this.ReImageTarget.rectTransform.anchoredPosition = new Vector2(167f, 174.5f);
			this.ReImageDevil.rectTransform.anchoredPosition = new Vector2(-166f, 175f);
			this.ReImageDevil.rectTransform.localScale = Vector3.one;
			this.KVKLine1.SetActive(true);
			this.KVKLine2.SetActive(false);
		}
	}

	// Token: 0x06000D8C RID: 3468 RVA: 0x0015AC50 File Offset: 0x00158E50
	private void CheckNowWave(bool ForceUpDate = false)
	{
		EActivityState fifastate = this.AM.GetFIFAState();
		if (fifastate == EActivityState.EAS_None)
		{
			return;
		}
		byte nowWave = this.NowWave;
		bool flag = this.bWaitNextWave;
		long waveTime = this.WaveTime;
		this.NowWave = 0;
		this.bWaitNextWave = false;
		this.WaveTime = 0L;
		if (fifastate == EActivityState.EAS_Prepare)
		{
			this.NowWave = 1;
			this.bWaitNextWave = true;
			this.WaveTime = this.AM.FIFAData[2].EventBeginTime;
		}
		else if (fifastate == EActivityState.EAS_Run)
		{
			long num = this.AM.FIFAData[2].EventBeginTime;
			long num2 = num + (long)((ulong)this.AM.FIFAData[2].EventReqiureTIme);
			long num3 = (long)(this.AM.WaveRequireMin * 60);
			long num4 = (long)((this.AM.WaveIntervalMin - this.AM.WaveRequireMin) * 60);
			if (num4 <= 0L)
			{
				return;
			}
			if (this.AM.ServerEventTime < num)
			{
				this.NowWave = 1;
				this.bWaitNextWave = false;
				this.WaveTime = num;
			}
			else if (this.AM.ServerEventTime >= num2)
			{
				this.NowWave = this.AM.WaveNum;
				this.bWaitNextWave = false;
				this.WaveTime = num2;
			}
			else
			{
				num2 = num + num3;
				for (byte b = 0; b < this.AM.WaveNum; b += 1)
				{
					if (this.AM.ServerEventTime >= num && this.AM.ServerEventTime < num2)
					{
						this.NowWave = b + 1;
						this.bWaitNextWave = false;
						this.WaveTime = num2;
						break;
					}
					num = num2;
					num2 += num4;
					if (this.AM.ServerEventTime >= num && this.AM.ServerEventTime < num2)
					{
						this.NowWave = b + 2;
						this.bWaitNextWave = true;
						this.WaveTime = num2;
						break;
					}
					num = num2;
					num2 += num3;
				}
			}
			if (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && this.NowWave > this.AM.WaveNum)
			{
				this.HideFIFA_KvKBallInfo();
			}
		}
		else if (this.tmpData.ActiveType != EActivityType.EAT_FIFA_KVK)
		{
			return;
		}
		if (ForceUpDate || this.NowWave != nowWave || flag != this.bWaitNextWave || waveTime != this.WaveTime)
		{
			this.SetWaveImage();
			this.SetWaveText();
			this.SetWaveTimeText();
		}
	}

	// Token: 0x06000D8D RID: 3469 RVA: 0x0015AEE4 File Offset: 0x001590E4
	private void SetWaveImage()
	{
		if (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && (this.NowWave > this.AM.WaveNum || (this.tmpData.EventState >= EActivityState.EAS_HomeStart && this.tmpData.EventState <= EActivityState.EAS_StartRanking)))
		{
			for (int i = 0; i < this.ArrowImage.Length; i++)
			{
				this.ArrowImage[i].sprite = this.FIFASP.m_Sprites[0];
			}
			if (this.Npc_Node != null)
			{
				for (int j = 0; j < this.Npc_Node.Length; j++)
				{
					this.Npc_Node[j].updateNPC(UINPCState.UINPC_Stop);
				}
			}
		}
		else
		{
			for (int k = 0; k < this.ArrowImage.Length; k++)
			{
				this.ArrowImage[k].sprite = this.FIFASP.m_Sprites[(!this.bWaitNextWave || this.NowWave <= 1 || k != (int)(this.NowWave - 2)) ? 0 : 1];
			}
			if (this.Npc_Node != null)
			{
				for (int l = 0; l < this.Npc_Node.Length; l++)
				{
					if (l + 1 == (int)this.NowWave)
					{
						if (this.bWaitNextWave)
						{
							this.Npc_Node[l].updateNPC(UINPCState.UINPC_Idle);
						}
						else
						{
							this.Npc_Node[l].updateNPC(UINPCState.UINPC_Attack);
						}
					}
					else
					{
						this.Npc_Node[l].updateNPC(UINPCState.UINPC_Stop);
					}
				}
			}
		}
	}

	// Token: 0x06000D8E RID: 3470 RVA: 0x0015B074 File Offset: 0x00159274
	private void SetWaveText()
	{
		if (this.WaveText == null || this.WaveText[0] == null)
		{
			return;
		}
		if (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && (this.NowWave > this.AM.WaveNum || (this.tmpData.EventState >= EActivityState.EAS_HomeStart && this.tmpData.EventState <= EActivityState.EAS_StartRanking)))
		{
			this.WaveText[0].text = this.DM.mStringTable.GetStringByID(14750u);
			this.WaveText[0].color = new Color32(byte.MaxValue, 108, 122, byte.MaxValue);
		}
		else
		{
			if (this.WaveStr[0] == null)
			{
				this.WaveStr[0] = StringManager.Instance.SpawnString(100);
			}
			this.WaveStr[0].Length = 0;
			this.WaveStr[0].IntToFormat((long)this.NowWave, 1, false);
			if (this.bWaitNextWave)
			{
				if (this.NowWave == this.AM.WaveNum)
				{
					this.WaveStr[0].AppendFormat(this.DM.mStringTable.GetStringByID(12239u));
				}
				else
				{
					this.WaveStr[0].AppendFormat(this.DM.mStringTable.GetStringByID(12208u));
				}
				this.WaveText[0].color = new Color32(byte.MaxValue, 108, 122, byte.MaxValue);
			}
			else
			{
				if (this.NowWave == this.AM.WaveNum)
				{
					this.WaveStr[0].AppendFormat(this.DM.mStringTable.GetStringByID(12238u));
				}
				else
				{
					this.WaveStr[0].AppendFormat(this.DM.mStringTable.GetStringByID(12211u));
				}
				this.WaveText[0].color = new Color32(20, 248, 85, byte.MaxValue);
			}
			this.WaveText[0].text = this.WaveStr[0].ToString();
			this.WaveText[0].SetAllDirty();
			this.WaveText[0].cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06000D8F RID: 3471 RVA: 0x0015B2D0 File Offset: 0x001594D0
	private void SetWaveTimeText()
	{
		if (this.WaveText == null || this.WaveText[1] == null)
		{
			return;
		}
		if (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK && (this.NowWave > this.AM.WaveNum || (this.tmpData.EventState >= EActivityState.EAS_HomeStart && this.tmpData.EventState <= EActivityState.EAS_StartRanking)))
		{
			this.WaveText[1].gameObject.SetActive(false);
		}
		else
		{
			if (this.WaveStr[1] == null)
			{
				this.WaveStr[1] = StringManager.Instance.SpawnString(30);
			}
			this.WaveText[1].gameObject.SetActive(true);
			this.WaveStr[1].Length = 0;
			uint num = (this.WaveTime <= this.AM.ServerEventTime) ? 0u : ((uint)(this.WaveTime - this.AM.ServerEventTime));
			GameConstants.GetTimeString(this.WaveStr[1], num, false, true, false, false, true);
			if (this.bWaitNextWave)
			{
				this.WaveText[1].color = new Color32(byte.MaxValue, 108, 122, byte.MaxValue);
			}
			else
			{
				this.WaveText[1].color = new Color32(20, 248, 85, byte.MaxValue);
			}
			this.WaveText[1].text = this.WaveStr[1].ToString();
			this.WaveText[1].SetAllDirty();
			this.WaveText[1].cachedTextGenerator.Invalidate();
			if (num == 0u)
			{
				this.CheckNowWave(false);
			}
		}
	}

	// Token: 0x06000D90 RID: 3472 RVA: 0x0015B484 File Offset: 0x00159684
	private void SetFIFATopText()
	{
		if (this.RBText4[0] == null || this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK)
		{
			return;
		}
		if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
		{
			if (this.DM.RoleAlliance.Id == 0u)
			{
				this.RBText4[0].text = this.DM.mStringTable.GetStringByID(1594u);
			}
			else if (this.DM.RoleAlliance.KingdomID != DataManager.MapDataController.kingdomData.kingdomID)
			{
				this.RBText4[0].text = this.DM.mStringTable.GetStringByID(12221u);
			}
			else if (this.AM.FIFA_AlliancePlace > 0 && this.AM.FIFA_AlliancePlace <= 30)
			{
				if (this.WaveStr[2] == null)
				{
					this.WaveStr[2] = StringManager.Instance.SpawnString(150);
				}
				this.WaveStr[2].IntToFormat((long)this.AM.FIFA_AlliancePlace, 1, false);
				this.WaveStr[2].AppendFormat(this.DM.mStringTable.GetStringByID(12218u));
				this.RBText4[0].text = this.WaveStr[2].ToString();
				this.RBText4[0].SetAllDirty();
				this.RBText4[0].cachedTextGenerator.Invalidate();
			}
			else
			{
				this.RBText4[0].text = this.DM.mStringTable.GetStringByID(12222u);
			}
		}
		else if (this.tmpData.EventState == EActivityState.EAS_Run)
		{
			this.RBText4[0].text = this.DM.mStringTable.GetStringByID(12243u);
		}
		else
		{
			this.RBText4[0].text = this.DM.mStringTable.GetStringByID(12205u);
		}
	}

	// Token: 0x06000D91 RID: 3473 RVA: 0x0015B694 File Offset: 0x00159894
	private void LoadNPC_Node()
	{
		if (this.Npc_Node != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (this.Npc_Node[i] != null && this.Npc_Node[i].bNeedReload)
				{
					this.Npc_Node[i].SpawnNPC(Vector2.zero, 1f, 1, 210, UINPCState.UINPC_Idle, this.Npc_Parent[i], ref this.Npc_ABKey[i]);
				}
			}
			this.SetWaveImage();
		}
	}

	// Token: 0x04002B9F RID: 11167
	private const byte StepCount = 3;

	// Token: 0x04002BA0 RID: 11168
	private const float ItemDeltaY = -70f;

	// Token: 0x04002BA1 RID: 11169
	private const byte FactorCount = 5;

	// Token: 0x04002BA2 RID: 11170
	private const byte HintCount = 12;

	// Token: 0x04002BA3 RID: 11171
	private const int UnitCount = 7;

	// Token: 0x04002BA4 RID: 11172
	private const int Npc_Count = 4;

	// Token: 0x04002BA5 RID: 11173
	private const byte Npc_ID = 210;

	// Token: 0x04002BA6 RID: 11174
	private const ushort Npc_PackID = 1002;

	// Token: 0x04002BA7 RID: 11175
	private Transform m_transform;

	// Token: 0x04002BA8 RID: 11176
	private Transform ContentT;

	// Token: 0x04002BA9 RID: 11177
	private Transform UnitObjectT;

	// Token: 0x04002BAA RID: 11178
	private DataManager DM = DataManager.Instance;

	// Token: 0x04002BAB RID: 11179
	private GUIManager GM = GUIManager.Instance;

	// Token: 0x04002BAC RID: 11180
	private ActivityManager AM = ActivityManager.Instance;

	// Token: 0x04002BAD RID: 11181
	private Font tmpFont;

	// Token: 0x04002BAE RID: 11182
	private Image TopTriImage;

	// Token: 0x04002BAF RID: 11183
	private Vector2 TriLastPos = new Vector2(395f, 9f);

	// Token: 0x04002BB0 RID: 11184
	private Image[] SliderNormal = new Image[3];

	// Token: 0x04002BB1 RID: 11185
	private Image[] SliderFlash = new Image[3];

	// Token: 0x04002BB2 RID: 11186
	private UIText[] StageScoreText = new UIText[3];

	// Token: 0x04002BB3 RID: 11187
	private CString[] StageScore = new CString[3];

	// Token: 0x04002BB4 RID: 11188
	private Color StageScoreColorY = new Color(1f, 0.945f, 0.203f);

	// Token: 0x04002BB5 RID: 11189
	private CString NowScoreStr;

	// Token: 0x04002BB6 RID: 11190
	private UIText NowScoreText;

	// Token: 0x04002BB7 RID: 11191
	private CString NextScoreStr;

	// Token: 0x04002BB8 RID: 11192
	private UIText NextScoreText;

	// Token: 0x04002BB9 RID: 11193
	private Image[] PrizeStageImg = new Image[3];

	// Token: 0x04002BBA RID: 11194
	private CString[] GemCountText = new CString[3];

	// Token: 0x04002BBB RID: 11195
	private CString[] TitleText2 = new CString[3];

	// Token: 0x04002BBC RID: 11196
	private CString[] TotalpriceText = new CString[3];

	// Token: 0x04002BBD RID: 11197
	private CString[] NoPriceText = new CString[3];

	// Token: 0x04002BBE RID: 11198
	private int[] ItemCount = new int[3];

	// Token: 0x04002BBF RID: 11199
	private CString[][] ItemCountText;

	// Token: 0x04002BC0 RID: 11200
	private CString RankStr;

	// Token: 0x04002BC1 RID: 11201
	private UISpritesArray TimeSA;

	// Token: 0x04002BC2 RID: 11202
	private UIText TimeTitle;

	// Token: 0x04002BC3 RID: 11203
	private UIText TimeTitle2;

	// Token: 0x04002BC4 RID: 11204
	private UIText TimeText;

	// Token: 0x04002BC5 RID: 11205
	private CString TimeStr;

	// Token: 0x04002BC6 RID: 11206
	private byte nowStep;

	// Token: 0x04002BC7 RID: 11207
	private ulong nowScore;

	// Token: 0x04002BC8 RID: 11208
	private ulong[] StepScore = new ulong[3];

	// Token: 0x04002BC9 RID: 11209
	private CString[] ScoreFactorRateStr = new CString[5];

	// Token: 0x04002BCA RID: 11210
	private CString[] ScoreFactorRateStr2 = new CString[5];

	// Token: 0x04002BCB RID: 11211
	private ActivityDataType tmpData;

	// Token: 0x04002BCC RID: 11212
	private byte ActivityIndex;

	// Token: 0x04002BCD RID: 11213
	private Transform Main2T;

	// Token: 0x04002BCE RID: 11214
	private Transform NotOpenT;

	// Token: 0x04002BCF RID: 11215
	private RectTransform HintT;

	// Token: 0x04002BD0 RID: 11216
	private RectTransform HintT2;

	// Token: 0x04002BD1 RID: 11217
	private RectTransform HintT3;

	// Token: 0x04002BD2 RID: 11218
	private RectTransform HintT4;

	// Token: 0x04002BD3 RID: 11219
	private UIText[] HintTextL = new UIText[12];

	// Token: 0x04002BD4 RID: 11220
	private UIText[] HintTextR = new UIText[12];

	// Token: 0x04002BD5 RID: 11221
	private CString[] HintStrL = new CString[12];

	// Token: 0x04002BD6 RID: 11222
	private CString[] HintStrR = new CString[12];

	// Token: 0x04002BD7 RID: 11223
	private UIText HintT3Text;

	// Token: 0x04002BD8 RID: 11224
	private UIText HintSPText;

	// Token: 0x04002BD9 RID: 11225
	private CString HintT3Str;

	// Token: 0x04002BDA RID: 11226
	private UIText[] RBText = new UIText[8];

	// Token: 0x04002BDB RID: 11227
	private UIText[] RBText2 = new UIText[11];

	// Token: 0x04002BDC RID: 11228
	private UIText[] RBText3 = new UIText[9];

	// Token: 0x04002BDD RID: 11229
	private UIText[] RBText4;

	// Token: 0x04002BDE RID: 11230
	private UIText[] RBText5 = new UIText[16];

	// Token: 0x04002BDF RID: 11231
	private UIText[] FctorText1 = new UIText[5];

	// Token: 0x04002BE0 RID: 11232
	private UIText[] FctorText2 = new UIText[5];

	// Token: 0x04002BE1 RID: 11233
	private UIText[] FctorText3 = new UIText[5];

	// Token: 0x04002BE2 RID: 11234
	private UIText[] StepText1 = new UIText[3];

	// Token: 0x04002BE3 RID: 11235
	private UIText[] StepText2 = new UIText[3];

	// Token: 0x04002BE4 RID: 11236
	private UIText[] StepText3 = new UIText[3];

	// Token: 0x04002BE5 RID: 11237
	private UIText[] StepText4 = new UIText[3];

	// Token: 0x04002BE6 RID: 11238
	private UIText[][] StepItemCountText = new UIText[3][];

	// Token: 0x04002BE7 RID: 11239
	private CString[] ItemNameStr = new CString[8];

	// Token: 0x04002BE8 RID: 11240
	private UIText[] ItemNameText = new UIText[3];

	// Token: 0x04002BE9 RID: 11241
	private float Sizex;

	// Token: 0x04002BEA RID: 11242
	private float Sizey;

	// Token: 0x04002BEB RID: 11243
	private GameObject BossGO;

	// Token: 0x04002BEC RID: 11244
	private int AssetKey;

	// Token: 0x04002BED RID: 11245
	private AssetBundle AB;

	// Token: 0x04002BEE RID: 11246
	private AssetBundleRequest AR;

	// Token: 0x04002BEF RID: 11247
	private bool bABInitial;

	// Token: 0x04002BF0 RID: 11248
	private Transform ActorT;

	// Token: 0x04002BF1 RID: 11249
	private Transform LightT;

	// Token: 0x04002BF2 RID: 11250
	private Hero sHero;

	// Token: 0x04002BF3 RID: 11251
	private Animation tmpAN;

	// Token: 0x04002BF4 RID: 11252
	private string HeroAct;

	// Token: 0x04002BF5 RID: 11253
	private float ActionTime;

	// Token: 0x04002BF6 RID: 11254
	private float ActionTimeRandom;

	// Token: 0x04002BF7 RID: 11255
	private AnimationUnit.AnimName[] ANIndex = new AnimationUnit.AnimName[]
	{
		AnimationUnit.AnimName.VICTORY
	};

	// Token: 0x04002BF8 RID: 11256
	private List<AnimationUnit.AnimName> ANList = new List<AnimationUnit.AnimName>();

	// Token: 0x04002BF9 RID: 11257
	private int OtherAssetKey;

	// Token: 0x04002BFA RID: 11258
	private AssetBundle OtherAB;

	// Token: 0x04002BFB RID: 11259
	private CString[] kingdomIDstr;

	// Token: 0x04002BFC RID: 11260
	private CString[] kingdomPrizestr;

	// Token: 0x04002BFD RID: 11261
	private Color GreenColor = new Color(0.07843f, 0.9725f, 0.3333f, 1f);

	// Token: 0x04002BFE RID: 11262
	private bool bSummonType;

	// Token: 0x04002BFF RID: 11263
	private GameObject SummonBtn;

	// Token: 0x04002C00 RID: 11264
	private GameObject SummonFlash;

	// Token: 0x04002C01 RID: 11265
	private GameObject SummonAlert;

	// Token: 0x04002C02 RID: 11266
	private GameObject SummonBtn2;

	// Token: 0x04002C03 RID: 11267
	private GameObject NoImgGO;

	// Token: 0x04002C04 RID: 11268
	private GameObject StarObj;

	// Token: 0x04002C05 RID: 11269
	private GameObject StarObj2;

	// Token: 0x04002C06 RID: 11270
	private GameObject SummonTimeObj;

	// Token: 0x04002C07 RID: 11271
	private UIText NoText1;

	// Token: 0x04002C08 RID: 11272
	private UIText NoText2;

	// Token: 0x04002C09 RID: 11273
	private UIText RankReplayTitleText;

	// Token: 0x04002C0A RID: 11274
	private CString[] Hint5Str = new CString[16];

	// Token: 0x04002C0B RID: 11275
	private bool bNobilityWar;

	// Token: 0x04002C0C RID: 11276
	private bool[] bFindScrollComp = new bool[7];

	// Token: 0x04002C0D RID: 11277
	private UnitComp_Act2[] Scroll_Comp = new UnitComp_Act2[7];

	// Token: 0x04002C0E RID: 11278
	private CString[] CountTimeStr = new CString[7];

	// Token: 0x04002C0F RID: 11279
	private List<float> NowHeightList = new List<float>();

	// Token: 0x04002C10 RID: 11280
	private ScrollPanel Scroll;

	// Token: 0x04002C11 RID: 11281
	private CScrollRect cScrollRect;

	// Token: 0x04002C12 RID: 11282
	private Color NW_YellowColor = new Color(0.9647f, 0.9333f, 0.749f, 1f);

	// Token: 0x04002C13 RID: 11283
	private Color NW_GreenColor = new Color(0f, 1f, 0f, 1f);

	// Token: 0x04002C14 RID: 11284
	private GameObject RightObject_Prize;

	// Token: 0x04002C15 RID: 11285
	private GameObject RightObject_RP;

	// Token: 0x04002C16 RID: 11286
	private GameObject RightObject_Part1;

	// Token: 0x04002C17 RID: 11287
	private GameObject HintTargetImageGO;

	// Token: 0x04002C18 RID: 11288
	private GameObject RightObject_KingdomBtn;

	// Token: 0x04002C19 RID: 11289
	private GameObject MyKingdom_prize;

	// Token: 0x04002C1A RID: 11290
	private GameObject MyKingdom_RP;

	// Token: 0x04002C1B RID: 11291
	private GameObject P2_FightX;

	// Token: 0x04002C1C RID: 11292
	private RectTransform P2RC;

	// Token: 0x04002C1D RID: 11293
	private RectTransform P3RC;

	// Token: 0x04002C1E RID: 11294
	private RectTransform P2_WonderNameLeftImgRC;

	// Token: 0x04002C1F RID: 11295
	private RectTransform P2_WonderNameRC;

	// Token: 0x04002C20 RID: 11296
	private RectTransform P2_WonderPosRC;

	// Token: 0x04002C21 RID: 11297
	private RectTransform P3_1stItem;

	// Token: 0x04002C22 RID: 11298
	private RectTransform P3_2ndItem;

	// Token: 0x04002C23 RID: 11299
	private RectTransform P3_3rdItem;

	// Token: 0x04002C24 RID: 11300
	private UIText P1_TitleText;

	// Token: 0x04002C25 RID: 11301
	private UIText P2_KingdomIDText;

	// Token: 0x04002C26 RID: 11302
	private UIText P2_WonderNameText;

	// Token: 0x04002C27 RID: 11303
	private UIText P2_WonderPosText;

	// Token: 0x04002C28 RID: 11304
	private UIText P3_CrystalText;

	// Token: 0x04002C29 RID: 11305
	private UIText P3_MoneyText;

	// Token: 0x04002C2A RID: 11306
	private UIText RP_NameText;

	// Token: 0x04002C2B RID: 11307
	private UIText RP_KingdomIDText;

	// Token: 0x04002C2C RID: 11308
	private UIText NWText;

	// Token: 0x04002C2D RID: 11309
	private Image RP_NameImage;

	// Token: 0x04002C2E RID: 11310
	private Image NW_New;

	// Token: 0x04002C2F RID: 11311
	private RectTransform HintKingdom;

	// Token: 0x04002C30 RID: 11312
	private RectTransform HintNormal;

	// Token: 0x04002C31 RID: 11313
	private GameObject[] HintObject;

	// Token: 0x04002C32 RID: 11314
	private UIText[] HintKingdomText;

	// Token: 0x04002C33 RID: 11315
	private UIText[] P3_ItemText;

	// Token: 0x04002C34 RID: 11316
	private CString[] HintKingdomStr;

	// Token: 0x04002C35 RID: 11317
	private CString[] P3_ItemStr;

	// Token: 0x04002C36 RID: 11318
	private ushort HeroID;

	// Token: 0x04002C37 RID: 11319
	private Vector2 ContentSize;

	// Token: 0x04002C38 RID: 11320
	private bool bKVKForFourth;

	// Token: 0x04002C39 RID: 11321
	private GameObject KVKLine1;

	// Token: 0x04002C3A RID: 11322
	private GameObject KVKLine2;

	// Token: 0x04002C3B RID: 11323
	private GameObject HintGO;

	// Token: 0x04002C3C RID: 11324
	private Image ReTimeImage;

	// Token: 0x04002C3D RID: 11325
	private Image ReImageDevil;

	// Token: 0x04002C3E RID: 11326
	private Image ReImageTarget;

	// Token: 0x04002C3F RID: 11327
	private UIText ReTimeText;

	// Token: 0x04002C40 RID: 11328
	private UIText ReImageDevilText;

	// Token: 0x04002C41 RID: 11329
	private UIText HintText1;

	// Token: 0x04002C42 RID: 11330
	private UIText HintText2;

	// Token: 0x04002C43 RID: 11331
	private CString ReTimeStr;

	// Token: 0x04002C44 RID: 11332
	private CString ReImageDevilStr;

	// Token: 0x04002C45 RID: 11333
	private CString HintStr1;

	// Token: 0x04002C46 RID: 11334
	private CString HintStr2;

	// Token: 0x04002C47 RID: 11335
	private byte ShowRate;

	// Token: 0x04002C48 RID: 11336
	private bool bFIFA;

	// Token: 0x04002C49 RID: 11337
	private byte NowWave;

	// Token: 0x04002C4A RID: 11338
	private bool bWaitNextWave;

	// Token: 0x04002C4B RID: 11339
	private long WaveTime;

	// Token: 0x04002C4C RID: 11340
	private CString[] WaveStr = new CString[4];

	// Token: 0x04002C4D RID: 11341
	private UIText[] WaveText = new UIText[5];

	// Token: 0x04002C4E RID: 11342
	private Image[] ArrowImage = new Image[3];

	// Token: 0x04002C4F RID: 11343
	private Image[] LightImage;

	// Token: 0x04002C50 RID: 11344
	private UISpritesArray FIFASP;

	// Token: 0x04002C51 RID: 11345
	public UINPC[] Npc_Node;

	// Token: 0x04002C52 RID: 11346
	public int[] Npc_ABKey;

	// Token: 0x04002C53 RID: 11347
	private Transform[] Npc_Parent;

	// Token: 0x04002C54 RID: 11348
	private Transform FIFAT;

	// Token: 0x04002C55 RID: 11349
	private GameObject FIFAGO;

	// Token: 0x04002C56 RID: 11350
	private int FIFAAssetKey;

	// Token: 0x04002C57 RID: 11351
	private RectTransform HintTFIFA;

	// Token: 0x04002C58 RID: 11352
	private float FIFADeltaHeight;

	// Token: 0x04002C59 RID: 11353
	private Transform SPT;

	// Token: 0x04002C5A RID: 11354
	private GameObject SPGO;

	// Token: 0x04002C5B RID: 11355
	private int SPAssetKey;
}
