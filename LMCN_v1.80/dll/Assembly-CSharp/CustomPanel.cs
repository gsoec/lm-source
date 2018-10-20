using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020007DD RID: 2013
public class CustomPanel : MonoBehaviour, IUpDateScrollPanel, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x060029CB RID: 10699 RVA: 0x0045BF10 File Offset: 0x0045A110
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		this.TmpT = item.GetComponent<Transform>().parent.GetChild(panelObjectIdx);
		if (this.tmplistIdx.Count > 0 && this.tmplistIdx.Count >= dataIdx)
		{
			if (this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 != 0)
			{
				this.TmpT.GetChild(this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 - 1).gameObject.SetActive(false);
			}
			switch (this.tmplistIdx[dataIdx])
			{
			case CustomPanel_Ptype.P1_Title:
				this.Tmp_PT = this.TmpT.GetChild(0);
				this.Tmp_PT.gameObject.SetActive(true);
				this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 1;
				this.Text_Title[panelObjectIdx][0] = this.Tmp_PT.GetChild(1).GetComponent<UIText>();
				this.Text_Title[panelObjectIdx][0].text = this.mListItemStr1[dataIdx];
				this.Text_Title[panelObjectIdx][1] = this.Tmp_PT.GetChild(2).GetComponent<UIText>();
				this.Text_Title[panelObjectIdx][1].text = this.mListItemStr2[dataIdx];
				this.Img_TitleBG[panelObjectIdx] = this.Tmp_PT.GetChild(3).GetComponent<Image>();
				this.Img_TitleBG2[panelObjectIdx] = this.Tmp_PT.GetChild(4).GetComponent<Image>();
				this.tmpbtnHint = this.Tmp_PT.GetChild(3).GetComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
				this.tmpbtnHint.DelayTime = 0.2f;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 2;
				if (this.mListItemHint[dataIdx] >= 254)
				{
					this.Img_TitleBG[panelObjectIdx].gameObject.SetActive(true);
					this.Img_TitleBG2[panelObjectIdx].gameObject.SetActive(true);
					if (this.mListItemHint[dataIdx] == 255)
					{
						this.tmpbtnHint.Parm2 = 0;
						this.Img_TitleBG[panelObjectIdx].sprite = this.mSprite[7];
						this.Img_TitleBG2[panelObjectIdx].sprite = this.mSprite[7];
					}
					else
					{
						this.tmpbtnHint.Parm2 = 1;
						this.Img_TitleBG[panelObjectIdx].sprite = this.mSprite[8];
						this.Img_TitleBG2[panelObjectIdx].sprite = this.mSprite[8];
					}
					if (this.Text_Title[panelObjectIdx][0].preferredWidth + 1f > 225f)
					{
						this.Img_TitleBG[panelObjectIdx].rectTransform.sizeDelta = new Vector2(260f, this.Img_TitleBG[panelObjectIdx].rectTransform.sizeDelta.y);
						this.Img_TitleBG2[panelObjectIdx].rectTransform.anchoredPosition = new Vector2(234f, this.Img_TitleBG2[panelObjectIdx].rectTransform.anchoredPosition.y);
					}
					else
					{
						this.Img_TitleBG[panelObjectIdx].rectTransform.sizeDelta = new Vector2(36f + this.Text_Title[panelObjectIdx][0].preferredWidth, this.Img_TitleBG[panelObjectIdx].rectTransform.sizeDelta.y);
						this.Img_TitleBG2[panelObjectIdx].rectTransform.anchoredPosition = new Vector2(10f + this.Text_Title[panelObjectIdx][0].preferredWidth, this.Img_TitleBG2[panelObjectIdx].rectTransform.anchoredPosition.y);
					}
				}
				else
				{
					this.Img_TitleBG[panelObjectIdx].gameObject.SetActive(false);
					this.Img_TitleBG2[panelObjectIdx].gameObject.SetActive(false);
				}
				break;
			case CustomPanel_Ptype.P2_Text:
				this.Tmp_PT = this.TmpT.GetChild(1);
				this.Tmp_PT.gameObject.SetActive(true);
				this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 2;
				this.Text_TextStr[panelObjectIdx][0] = this.Tmp_PT.GetChild(0).GetComponent<UIText>();
				this.Text_TextStr[panelObjectIdx][0].text = this.mListItemStr1[dataIdx];
				this.Text_TextStr[panelObjectIdx][0].SetAllDirty();
				this.Text_TextStr[panelObjectIdx][0].cachedTextGeneratorForLayout.Invalidate();
				this.Text_TextStr[panelObjectIdx][1] = this.Tmp_PT.GetChild(1).GetComponent<UIText>();
				this.Text_TextStr[panelObjectIdx][1].text = this.mListItemStr2[dataIdx];
				this.Img_BG[panelObjectIdx] = this.Tmp_PT.GetChild(2).GetComponent<Image>();
				this.tmpbtnHint = this.Tmp_PT.GetChild(2).GetComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
				this.tmpbtnHint.DelayTime = 0.2f;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 1;
				this.tmpbtnHint.Parm2 = this.mListItemHint[dataIdx] - 1;
				this.Img_Icon[panelObjectIdx] = this.Tmp_PT.GetChild(2).GetChild(0).GetComponent<Image>();
				this.Text_Rank[panelObjectIdx] = this.Tmp_PT.GetChild(2).GetChild(1).GetComponent<UIText>();
				if (this.mListItemHint[dataIdx] > 0)
				{
					byte b = (this.mListItemHint[dataIdx] - 1) / 4;
					this.Img_BG[panelObjectIdx].gameObject.SetActive(true);
					if ((int)b < this.mSprite.Length)
					{
						this.Img_Icon[panelObjectIdx].sprite = this.mSprite[(int)b];
						this.Text_Rank[panelObjectIdx].text = ((int)((this.mListItemHint[dataIdx] - 1) % 4 + 1)).ToString();
					}
					else
					{
						this.Text_Rank[panelObjectIdx].text = string.Empty;
					}
					if (this.Text_TextStr[panelObjectIdx][0].preferredWidth < 217f)
					{
						this.Img_BG[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.Text_TextStr[panelObjectIdx][0].preferredWidth + 35f, this.Img_BG[panelObjectIdx].rectTransform.sizeDelta.y);
					}
					else
					{
						this.Img_BG[panelObjectIdx].rectTransform.sizeDelta = new Vector2(250f, this.Img_BG[panelObjectIdx].rectTransform.sizeDelta.y);
					}
				}
				else
				{
					this.Img_BG[panelObjectIdx].gameObject.SetActive(false);
				}
				break;
			case CustomPanel_Ptype.P3_Hero:
				this.Tmp_PT = this.TmpT.GetChild(2);
				this.Tmp_PT.gameObject.SetActive(true);
				this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 3;
				if (this.mKindCustomPanel != 10)
				{
					if (this.mKindCustomPanel == 5)
					{
						this.MainHeroID = this.DM.MainHero;
					}
					else if (this.mKindCustomPanel == 0)
					{
						this.MainHeroID = this.DM.GetLeaderID();
					}
					else if (this.DM.m_WT_WithSupremeLeader != 0)
					{
						this.MainHeroID = this.mHeroID[0];
					}
				}
				else
				{
					this.MainHeroID = this.mHeroID[0];
				}
				for (int i = 0; i < this.HEROCount; i++)
				{
					this.Tmp_PT.GetChild(i).gameObject.SetActive(true);
					this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.mHeroID[i]);
					this.tmpImg = this.Tmp_PT.GetChild(i).GetChild(0).GetComponent<Image>();
					this.tmpImg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
					this.ImgHero = this.Tmp_PT.GetChild(i).GetChild(1).GetComponent<Image>();
					this.ImgHeroF = this.Tmp_PT.GetChild(i).GetChild(2).GetComponent<Image>();
					this.tmpString.Length = 0;
					this.tmpString2.Length = 0;
					if ((this.mCustomPanel_LV < 23 && this.mKindCustomPanel != 5) || (this.mKindCustomPanel == 5 && this.mCustomPanel_LV < 8))
					{
						this.tmpString.AppendFormat("hf00{0}", 1);
					}
					else
					{
						switch (this.mKindCustomPanel)
						{
						case 1:
						case 2:
						case 3:
						case 5:
						case 10:
						case 11:
						case 12:
							this.tmpString.AppendFormat("hf00{0}", this.mHeroStar[i]);
							this.tmpString2.AppendFormat("hf10{0}", this.mHeroRank[i]);
							goto IL_A31;
						}
						this.mHeroData = this.DM.curHeroData[(uint)this.mHeroID[i]];
						this.tmpString.AppendFormat("hf00{0}", this.mHeroData.Star);
						this.tmpString2.AppendFormat("hf10{0}", this.mHeroData.Enhance);
					}
					IL_A31:
					this.ImgHero.sprite = this.GUIM.LoadFrameSprite(this.tmpString.ToString());
					this.ImgHeroF.sprite = this.GUIM.LoadFrameSprite(this.tmpString2.ToString());
					if ((this.mCustomPanel_LV >= 23 && this.mKindCustomPanel != 5) || (this.mKindCustomPanel == 5 && this.mCustomPanel_LV >= 8))
					{
						this.ImgHeroF.gameObject.SetActive(true);
					}
					if (i == 0)
					{
						if (this.MainHeroID == this.mHeroID[i])
						{
							this.tmpImg = this.Tmp_PT.GetChild(i).GetChild(3).GetComponent<Image>();
							this.tmpImg.gameObject.SetActive(true);
							this.tmpImg = this.Tmp_PT.GetChild(i).GetChild(4).GetComponent<Image>();
							this.tmpImg.gameObject.SetActive(true);
							this.ImgShowMain = this.tmpImg;
							this.bLeaderHero = true;
						}
						else
						{
							this.tmpImg = this.Tmp_PT.GetChild(i).GetChild(3).GetComponent<Image>();
							this.tmpImg.gameObject.SetActive(false);
							this.tmpImg = this.Tmp_PT.GetChild(i).GetChild(4).GetComponent<Image>();
							this.tmpImg.gameObject.SetActive(false);
							this.bLeaderHero = false;
						}
					}
				}
				if (this.HEROCount < 5)
				{
					for (int j = this.HEROCount; j < 5; j++)
					{
						this.TmpT = this.Tmp_PT.GetChild(j);
						this.TmpT.gameObject.SetActive(false);
					}
				}
				break;
			case CustomPanel_Ptype.P4_Resources:
				this.Tmp_PT = this.TmpT.GetChild(3);
				this.Tmp_PT.gameObject.SetActive(true);
				this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 4;
				for (int k = 0; k < 5; k++)
				{
					this.Text_Resources[panelObjectIdx][k] = this.Tmp_PT.GetChild(5 + k).GetComponent<UIText>();
					this.tmpString.Length = 0;
					if (this.mRes[k] != 0u)
					{
						GameConstants.FormatResourceValue(this.tmpString, this.mRes[k]);
						this.Text_Resources[panelObjectIdx][k].text = this.tmpString.ToString();
					}
					else
					{
						this.Text_Resources[panelObjectIdx][k].text = "-";
					}
				}
				if (this.mKindCustomPanel == 5 && this.mCustomPanel_LV < 2)
				{
					this.Tmp_PT.GetChild(4).gameObject.SetActive(false);
					this.Tmp_PT.GetChild(9).gameObject.SetActive(false);
				}
				else
				{
					this.Tmp_PT.GetChild(4).gameObject.SetActive(true);
					this.Tmp_PT.GetChild(9).gameObject.SetActive(true);
				}
				break;
			case CustomPanel_Ptype.P5_Text_Info:
			{
				this.Tmp_PT = this.TmpT.GetChild(4);
				this.Tmp_PT.gameObject.SetActive(true);
				this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 5;
				this.Text_Info[panelObjectIdx] = this.Tmp_PT.GetChild(0).GetComponent<UIText>();
				this.Text_Info[panelObjectIdx].text = this.mListItemStr1[dataIdx];
				this.tmpRC = this.TmpT.GetComponent<RectTransform>();
				float y = this.tmpRC.sizeDelta.y - 10f;
				this.tmpRC = this.Tmp_PT.GetChild(0).GetComponent<RectTransform>();
				this.tmpRC.sizeDelta = new Vector2(this.tmpRC.sizeDelta.x, y);
				break;
			}
			case CustomPanel_Ptype.P_End:
				this.Tmp_PT = this.TmpT.GetChild(5);
				this.Tmp_PT.gameObject.SetActive(true);
				this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 6;
				this.Text_End[panelObjectIdx] = this.Tmp_PT.GetChild(1).GetComponent<UIText>();
				this.Text_End[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(7641u);
				break;
			case CustomPanel_Ptype.P2_Text_LeftAlign:
				this.Tmp_PT = this.TmpT.GetChild(1);
				this.Tmp_PT.gameObject.SetActive(true);
				this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 2;
				this.Text_LeftAlign[panelObjectIdx][0] = this.Tmp_PT.GetChild(0).GetComponent<UIText>();
				this.Text_LeftAlign[panelObjectIdx][0].text = this.mListItemStr1[dataIdx];
				this.Text_LeftAlign[panelObjectIdx][0].alignment = TextAnchor.MiddleLeft;
				this.Text_LeftAlign[panelObjectIdx][1] = this.Tmp_PT.GetChild(1).GetComponent<UIText>();
				this.Text_LeftAlign[panelObjectIdx][1].text = this.mListItemStr2[dataIdx];
				break;
			case CustomPanel_Ptype.P3_Hero_C:
				this.Tmp_PT = this.TmpT.GetChild(2);
				this.Tmp_PT.gameObject.SetActive(true);
				this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 3;
				this.HEROCount = (int)this.DM.CantonmentHeroCount;
				for (int l = 0; l < this.HEROCount; l++)
				{
					this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.DM.CantonmentHero[l].HeroID);
					this.tmpImg = this.Tmp_PT.GetChild(l).GetChild(0).GetComponent<Image>();
					this.tmpImg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
					this.ImgHero = this.Tmp_PT.GetChild(l).GetChild(1).GetComponent<Image>();
					this.ImgHeroF = this.Tmp_PT.GetChild(l).GetChild(2).GetComponent<Image>();
					this.tmpString.Length = 0;
					this.tmpString2.Length = 0;
					if ((this.mCustomPanel_LV < 23 && this.mKindCustomPanel != 5) || (this.mKindCustomPanel == 5 && this.mCustomPanel_LV < 8))
					{
						this.tmpString.AppendFormat("hf00{0}", 1);
					}
					else
					{
						this.tmpString.AppendFormat("hf00{0}", this.DM.CantonmentHero[l].Star);
						this.tmpString2.AppendFormat("hf10{0}", this.DM.CantonmentHero[l].Rank);
					}
					this.ImgHero.sprite = this.GUIM.LoadFrameSprite(this.tmpString.ToString());
					this.ImgHeroF.sprite = this.GUIM.LoadFrameSprite(this.tmpString2.ToString());
					if ((this.mCustomPanel_LV >= 23 && this.mKindCustomPanel != 5) || (this.mKindCustomPanel == 5 && this.mCustomPanel_LV >= 8))
					{
						this.ImgHeroF.gameObject.SetActive(true);
					}
					if (l == 0 && this.DM.CantonmentMainHero == this.DM.CantonmentHero[l].HeroID)
					{
						this.tmpImg = this.Tmp_PT.GetChild(l).GetChild(3).GetComponent<Image>();
						this.tmpImg.gameObject.SetActive(true);
						this.tmpImg = this.Tmp_PT.GetChild(l).GetChild(4).GetComponent<Image>();
						this.tmpImg.gameObject.SetActive(true);
						this.ImgShowMain_C = this.tmpImg;
					}
					else if (this.ImgShowMain_C != null)
					{
						this.ImgShowMain_C.gameObject.SetActive(false);
					}
				}
				if (this.HEROCount < 5)
				{
					for (int m = this.HEROCount; m < 5; m++)
					{
						this.TmpT = this.Tmp_PT.GetChild(m);
						this.TmpT.gameObject.SetActive(false);
					}
				}
				break;
			case CustomPanel_Ptype.P6_Item:
			{
				this.Tmp_PT = this.TmpT.GetChild(6);
				this.Tmp_PT.gameObject.SetActive(true);
				this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 7;
				NPCPrizeData recordByKey = DataManager.Instance.NPCPrize.GetRecordByKey(this.RewardID);
				this.ImgNpcItem = this.Tmp_PT.GetChild(0).GetComponent<Image>();
				UnityEngine.Object.Destroy(this.ImgNpcItem.GetComponent<IgnoreRaycast>());
				UIButton component = this.Tmp_PT.GetChild(0).GetChild(0).GetComponent<UIButton>();
				UIButtonHint uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
				uibuttonHint.m_eHint = EUIButtonHint.CountDown;
				uibuttonHint.Parm1 = 12030;
				uibuttonHint.DelayTime = 0.2f;
				uibuttonHint.m_DownUpHandler = this.UpDownHandle;
				NPCPrizeData recordByKey2 = this.DM.NPCPrize.GetRecordByKey(this.RewardID);
				this.ImgNpcItem.sprite = this.GUIM.m_LeadItemIconSpriteAsset.LoadSprite(recordByKey2.PicNo);
				this.ImgNpcItem.material = this.GUIM.m_LeadItemIconSpriteAsset.GetMaterial();
				component.image.sprite = this.GUIM.m_LeadItemIconSpriteAsset.LoadSprite(recordByKey2.PicNo);
				component.image.material = this.GUIM.m_LeadItemIconSpriteAsset.GetMaterial();
				this.Text_NpcItem = this.Tmp_PT.GetChild(1).GetComponent<UIText>();
				this.Text_NpcItem.text = this.DM.mStringTable.GetStringByID((uint)recordByKey2.Element);
				RectTransform component2 = component.transform.GetComponent<RectTransform>();
				component2.sizeDelta = new Vector2(100f + this.Text_NpcItem.preferredWidth, component2.sizeDelta.y);
				break;
			}
			case CustomPanel_Ptype.P3_Hero_Npc:
				this.Tmp_PT = this.TmpT.GetChild(2);
				this.Tmp_PT.gameObject.SetActive(true);
				this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 3;
				for (int n = 0; n < 5; n++)
				{
					if (this.mHead[n] != null)
					{
						UnityEngine.Object.Destroy(this.mHead[n]);
						this.mHead[n] = null;
					}
				}
				for (int num = 0; num < this.HEROCount; num++)
				{
					this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.mHeroID[num]);
					this.tmpImg = this.Tmp_PT.GetChild(num).GetChild(0).GetComponent<Image>();
					this.tmpImg.rectTransform.pivot = new Vector2(0.5f, 0.5f);
					if (this.tmpHero.Graph < 50000)
					{
						this.tmpImg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
					}
					else
					{
						CString cstring = StringManager.Instance.StaticString1024();
						cstring.ClearString();
						cstring.IntToFormat((long)this.tmpHero.Graph, 1, false);
						cstring.AppendFormat("UI/MapNPCHead_{0}");
						if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.UI, AssetType.NPCHead, this.tmpHero.Graph, false))
						{
							AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.mAssetKey[num]);
							if (assetBundle != null && this.mHead[num] == null)
							{
								this.mHead[num] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
							}
							if (this.mHead[num] != null)
							{
								this.mHead[num].transform.SetParent(this.tmpImg.transform);
								this.mHead[num].gameObject.SetActive(true);
								this.mHead[num].transform.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0f);
								this.mHead[num].transform.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 1f);
								this.mHead[num].transform.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 0f);
								this.mHead[num].transform.localPosition = new Vector3(0f, 0f, 0f);
								this.mHead[num].transform.localScale = new Vector3(1f, 1f, 1f);
							}
						}
					}
					this.ImgHero = this.Tmp_PT.GetChild(num).GetChild(1).GetComponent<Image>();
					this.ImgHeroF = this.Tmp_PT.GetChild(num).GetChild(2).GetComponent<Image>();
					this.tmpString.Length = 0;
					this.tmpString2.Length = 0;
					if ((this.mCustomPanel_LV < 23 && this.mKindCustomPanel != 5) || (this.mKindCustomPanel == 5 && this.mCustomPanel_LV < 8))
					{
						this.tmpString.AppendFormat("hf00{0}", 1);
					}
					else
					{
						this.tmpString.AppendFormat("hf00{0}", this.mHeroStar[num]);
						this.tmpString2.AppendFormat("hf10{0}", this.mHeroRank[num]);
					}
					this.ImgHero.sprite = this.GUIM.LoadFrameSprite(this.tmpString.ToString());
					this.ImgHeroF.sprite = this.GUIM.LoadFrameSprite(this.tmpString2.ToString());
					if ((this.mCustomPanel_LV >= 23 && this.mKindCustomPanel != 5) || (this.mKindCustomPanel == 5 && this.mCustomPanel_LV >= 8))
					{
						this.ImgHeroF.gameObject.SetActive(true);
					}
					if (num == 0 && this.DM.CantonmentMainHero == this.DM.CantonmentHero[num].HeroID)
					{
						this.tmpImg = this.Tmp_PT.GetChild(num).GetChild(3).GetComponent<Image>();
						this.tmpImg.gameObject.SetActive(true);
						this.tmpImg = this.Tmp_PT.GetChild(num).GetChild(4).GetComponent<Image>();
						this.tmpImg.gameObject.SetActive(true);
						this.ImgShowMain_C = this.tmpImg;
					}
					else if (this.ImgShowMain_C != null)
					{
						this.ImgShowMain_C.gameObject.SetActive(false);
					}
				}
				if (this.HEROCount < 5)
				{
					for (int num2 = this.HEROCount; num2 < 5; num2++)
					{
						this.TmpT = this.Tmp_PT.GetChild(num2);
						this.TmpT.gameObject.SetActive(false);
					}
				}
				break;
			case CustomPanel_Ptype.P_PetSkill:
			{
				this.Tmp_PT = this.TmpT.GetChild(7);
				this.Tmp_PT.gameObject.SetActive(true);
				this.TmpT.GetComponent<ScrollPanelItem>().m_BtnID2 = 7;
				this.Hbtn_Pet = this.Tmp_PT.GetChild(0).GetComponent<UIHIBtn>();
				this.GUIM.ChangeHeroItemImg(this.Hbtn_Pet.transform, eHeroOrItem.Pet, this.DM.m_WT_PetID, this.DM.m_WT_PetEnhance, 0, 0);
				PetManager instance = PetManager.Instance;
				PetTbl recordByKey3 = instance.PetTable.GetRecordByKey(this.DM.m_WT_PetID);
				PetSkillTbl recordByKey4 = instance.PetSkillTable.GetRecordByKey(this.DM.m_WT_PetSkillID);
				this.Text_PetName = this.Tmp_PT.GetChild(1).GetComponent<UIText>();
				this.Text_PetName.text = this.DM.mStringTable.GetStringByID((uint)recordByKey3.Name);
				this.Text_PetSkill = this.Tmp_PT.GetChild(2).GetComponent<UIText>();
				this.tmpString.Length = 0;
				this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(268u), this.DM.m_WT_PetSkillLv, this.DM.mStringTable.GetStringByID((uint)recordByKey4.Name));
				this.Text_PetSkill.text = this.tmpString.ToString();
				this.Text_PetSkillEffect = this.Tmp_PT.GetChild(3).GetComponent<UIText>();
				this.Cstr_SkillEffect.ClearString();
				instance.FormatSkillContent(this.DM.m_WT_PetSkillID, this.DM.m_WT_PetSkillLv, this.Cstr_SkillEffect, 0);
				this.Text_PetSkillEffect.text = this.Cstr_SkillEffect.ToString();
				break;
			}
			}
		}
	}

	// Token: 0x060029CC RID: 10700 RVA: 0x0045D9F0 File Offset: 0x0045BBF0
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x060029CD RID: 10701 RVA: 0x0045D9F4 File Offset: 0x0045BBF4
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.Parm1 == 1)
		{
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 3, 277f, 20, (int)sender.Parm2, 0, new Vector2(70f, 0f), UIButtonHint.ePosition.Original);
		}
		else if (sender.Parm1 == 2)
		{
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintArmy, 0, 0f, 0, (int)sender.Parm2, 0, Vector2.zero, UIButtonHint.ePosition.Original);
		}
	}

	// Token: 0x060029CE RID: 10702 RVA: 0x0045DA74 File Offset: 0x0045BC74
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x060029CF RID: 10703 RVA: 0x0045DA88 File Offset: 0x0045BC88
	public ScrollPanel getScrollPanel()
	{
		return this.mScrollPanel;
	}

	// Token: 0x060029D0 RID: 10704 RVA: 0x0045DA90 File Offset: 0x0045BC90
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x060029D1 RID: 10705 RVA: 0x0045DA94 File Offset: 0x0045BC94
	private void Awake()
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		Material material = this.door.LoadMaterial();
		AssetBundle assetBundle = AssetManager.GetAssetBundle(this.abName, out this.abKey, false);
		if (assetBundle == null)
		{
			return;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(assetBundle.mainAsset);
		if (gameObject == null)
		{
			AssetManager.UnloadAssetBundle(this.abKey, true);
			return;
		}
		this.SDM = DataManager.StageDataController;
		gameObject.transform.SetParent(base.transform, false);
		this.baseTransform = gameObject.transform;
		this.mSprite[0] = this.door.LoadSprite("UI_legion_icon_a");
		this.mSprite[1] = this.door.LoadSprite("UI_legion_icon_b");
		this.mSprite[2] = this.door.LoadSprite("UI_legion_icon_c");
		this.mSprite[3] = this.door.LoadSprite("UI_legion_icon_d");
		this.mSprite[4] = this.door.LoadSprite("UI_legion_icon_e");
		this.mSprite[5] = this.door.LoadSprite("UI_legion_icon_f");
		this.mSprite[6] = this.door.LoadSprite("UI_legion_icon_g");
		this.mSprite[7] = this.door.LoadSprite("UI_EO_icon_01");
		this.mSprite[8] = this.door.LoadSprite("UI_EO_icon_02");
		Material frameMaterial = this.GUIM.GetFrameMaterial();
		Material material2 = this.GUIM.m_IconSpriteAsset.GetMaterial();
		for (int i = 0; i < 16; i++)
		{
			this.Text_Title[i] = new UIText[2];
			this.Text_TextStr[i] = new UIText[2];
			this.Text_LeftAlign[i] = new UIText[2];
			this.Text_Resources[i] = new UIText[5];
		}
		Transform child = this.baseTransform.GetChild(0);
		this.mScrollPanel = child.GetComponent<ScrollPanel>();
		this.tmpImg = child.GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_011");
		this.tmpImg.material = material;
		child = this.baseTransform.GetChild(1);
		this.tmpImg = child.GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_011");
		this.tmpImg.material = material;
		child = this.baseTransform.GetChild(1).GetChild(0);
		this.tmpImg = child.GetChild(0).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_011");
		this.tmpImg.material = material;
		this.tmpText = child.GetChild(1).GetComponent<UIText>();
		this.tmpText.font = this.TTFont;
		this.tmpText = child.GetChild(2).GetComponent<UIText>();
		this.tmpText.font = this.TTFont;
		this.tmpImg = child.GetChild(3).GetComponent<Image>();
		this.tmpImg.sprite = this.mSprite[7];
		this.tmpImg.material = material;
		this.tmpbtnHint = this.tmpImg.gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
		this.tmpbtnHint.DelayTime = 0.2f;
		this.tmpbtnHint.m_Handler = this;
		this.tmpbtnHint.Parm1 = 2;
		this.tmpImg = child.GetChild(4).GetComponent<Image>();
		this.tmpImg.sprite = this.mSprite[7];
		this.tmpImg.material = material;
		child = this.baseTransform.GetChild(1).GetChild(1);
		this.tmpText = child.GetChild(0).GetComponent<UIText>();
		this.tmpText.font = this.TTFont;
		this.tmpText = child.GetChild(1).GetComponent<UIText>();
		this.tmpText.font = this.TTFont;
		this.tmpImg = child.GetChild(2).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_011");
		this.tmpImg.material = material;
		this.tmpbtnHint = this.tmpImg.gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
		this.tmpbtnHint.DelayTime = 0.2f;
		this.tmpbtnHint.m_Handler = this;
		this.tmpbtnHint.Parm1 = 1;
		this.tmpImg = child.GetChild(2).GetChild(0).GetComponent<Image>();
		this.tmpImg.sprite = this.mSprite[0];
		this.tmpImg.material = material;
		this.tmpText = child.GetChild(2).GetChild(1).GetComponent<UIText>();
		this.tmpText.font = this.TTFont;
		child = this.baseTransform.GetChild(1).GetChild(2);
		Transform child2 = child.GetChild(0).GetChild(0);
		this.tmpImg = child2.GetComponent<Image>();
		this.tmpImg.material = material2;
		this.tmpRC = this.tmpImg.GetComponent<RectTransform>();
		this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
		this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.tmpImg = child.GetChild(0).GetChild(1).GetComponent<Image>();
		this.tmpImg.sprite = this.GUIM.LoadFrameSprite("hf001");
		this.tmpImg.material = frameMaterial;
		this.tmpRC = this.tmpImg.GetComponent<RectTransform>();
		this.tmpRC.anchorMin = Vector2.zero;
		this.tmpRC.anchorMax = new Vector2(1f, 1f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.tmpImg = child.GetChild(0).GetChild(2).GetComponent<Image>();
		this.tmpImg.sprite = this.GUIM.LoadFrameSprite("hf001");
		this.tmpImg.material = frameMaterial;
		this.tmpImg = child.GetChild(0).GetChild(3).GetComponent<Image>();
		this.tmpImg.sprite = this.GUIM.LoadFrameSprite("UI_legion_icon_12");
		this.tmpImg.material = frameMaterial;
		this.tmpImg = child.GetChild(0).GetChild(4).GetComponent<Image>();
		this.tmpImg.sprite = this.GUIM.LoadFrameSprite("UI_legion_icon_13");
		this.tmpImg.material = frameMaterial;
		for (int j = 1; j < 5; j++)
		{
			child2 = child.GetChild(j).GetChild(0);
			this.tmpImg = child2.GetComponent<Image>();
			this.tmpRC = this.tmpImg.GetComponent<RectTransform>();
			this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
			this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.tmpImg.material = material2;
			this.tmpImg = child.GetChild(j).GetChild(1).GetComponent<Image>();
			this.tmpImg.sprite = this.GUIM.LoadFrameSprite("hf001");
			this.tmpImg.material = frameMaterial;
			this.tmpRC = this.tmpImg.GetComponent<RectTransform>();
			this.tmpRC.anchorMin = Vector2.zero;
			this.tmpRC.anchorMax = new Vector2(1f, 1f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.tmpImg = child.GetChild(j).GetChild(2).GetComponent<Image>();
			this.tmpImg.sprite = this.GUIM.LoadFrameSprite("hf001");
			this.tmpImg.material = frameMaterial;
		}
		child = this.baseTransform.GetChild(1).GetChild(3);
		this.tmpImg = child.GetChild(0).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_res_food");
		this.tmpImg.material = material;
		this.tmpImg = child.GetChild(1).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_res_stone");
		this.tmpImg.material = material;
		this.tmpImg = child.GetChild(2).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_res_wood");
		this.tmpImg.material = material;
		this.tmpImg = child.GetChild(3).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_res_iron");
		this.tmpImg.material = material;
		this.tmpImg = child.GetChild(4).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_money_01");
		this.tmpImg.material = material;
		for (int k = 0; k < 5; k++)
		{
			this.tmpText = child.GetChild(5 + k).GetComponent<UIText>();
			this.tmpText.font = this.TTFont;
		}
		child = this.baseTransform.GetChild(1).GetChild(4);
		this.tmpText_Info = child.GetChild(0).GetComponent<UIText>();
		this.tmpText_Info.font = this.TTFont;
		child = this.baseTransform.GetChild(1).GetChild(5);
		this.tmpImg = child.GetChild(0).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_011");
		this.tmpImg.material = material;
		this.tmpText = child.GetChild(1).GetComponent<UIText>();
		this.tmpText.font = this.TTFont;
		child = this.baseTransform.GetChild(1).GetChild(6);
		this.tmpImg = child.GetChild(0).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_box_011");
		this.tmpImg.material = material;
		this.tmpText = child.GetChild(1).GetComponent<UIText>();
		this.tmpText.font = this.TTFont;
		child = this.baseTransform.GetChild(1).GetChild(7);
		UIHIBtn component = child.GetChild(0).GetComponent<UIHIBtn>();
		component.m_Handler = this;
		this.GUIM.InitianHeroItemImg(component.transform, eHeroOrItem.Pet, 0, 0, 0, 0, true, true, true, false);
		this.tmpText = child.GetChild(1).GetComponent<UIText>();
		this.tmpText.font = this.TTFont;
		this.tmpText = child.GetChild(2).GetComponent<UIText>();
		this.tmpText.font = this.TTFont;
		this.tmpText = child.GetChild(3).GetComponent<UIText>();
		this.tmpText.font = this.TTFont;
		this.Cstr_SkillEffect = StringManager.Instance.SpawnString(200);
	}

	// Token: 0x060029D2 RID: 10706 RVA: 0x0045E660 File Offset: 0x0045C860
	public void SetPVE_Data(ushort mIdx)
	{
		this.mCS = this.SDM.CorpsStageTable.GetRecordByKey(mIdx);
		this.mCSB = this.SDM.CorpsStageBattleTable.GetRecordByKey(mIdx);
		this.HEROCount = 0;
		this.mWT_StrengthenCount = 0;
		for (int i = 0; i < 5; i++)
		{
			if (this.mCS.Heros[i].HeroID != 0)
			{
				this.HEROCount++;
			}
			if (this.mCSB.PropertiesInfo[i].Propertieskey != 0)
			{
				this.mEffectID[i] = this.mCSB.PropertiesInfo[i].Propertieskey;
				this.mWT_StrengthenCount++;
			}
		}
		this.InfoID = (uint)this.mCS.Info;
	}

	// Token: 0x060029D3 RID: 10707 RVA: 0x0045E73C File Offset: 0x0045C93C
	public void SetPanelData(List<int> _DataIdx, bool bCustomH = false, bool bOpen = true, int mLV = 0, int mKind = 0, float mHeight = 0f)
	{
		if (mKind != 0)
		{
			this.mKindCustomPanel = mKind;
		}
		if (mLV != 0)
		{
			this.mCustomPanel_LV = (ushort)mLV;
		}
		this.CurrentPanelHeight = 0f;
		this.tmplist.Clear();
		this.tmplistIdx.Clear();
		this.mListItemStr1.Clear();
		this.mListItemStr2.Clear();
		this.mListItemHint.Clear();
		for (int i = 0; i < _DataIdx.Count; i++)
		{
			if (_DataIdx[i] != 4)
			{
				this.tmplistIdx.Add(CustomPanel_Ptype.P1_Title);
				if (_DataIdx[i] == 8 || _DataIdx[i] == 26)
				{
					this.mListItemHint.Add(byte.MaxValue);
				}
				else if (_DataIdx[i] == 7 || _DataIdx[i] == 28)
				{
					this.mListItemHint.Add(254);
				}
				else
				{
					this.mListItemHint.Add(0);
				}
			}
			else
			{
				this.tmplistIdx.Add(CustomPanel_Ptype.P_End);
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemHint.Add(0);
			}
			switch (_DataIdx[i])
			{
			case 1:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				if (this.mKindCustomPanel == 1 || this.mKindCustomPanel == 2 || this.mKindCustomPanel == 3)
				{
					this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4018u));
				}
				else if (this.mKindCustomPanel == 7 || this.mKindCustomPanel == 8)
				{
					this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(3882u));
				}
				else if (this.mKindCustomPanel == 11)
				{
					this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9728u));
				}
				else if (this.mKindCustomPanel == 12)
				{
					this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9919u));
				}
				this.tmpString.Length = 0;
				if (this.mCustomPanel_LV < 13)
				{
					this.tmpString.Append(this.DM.mStringTable.GetStringByID(4010u));
					this.tmpString.Append(this.DM.mStringTable.GetStringByID(3931u));
				}
				else if (this.mCustomPanel_LV >= 13 && this.mCustomPanel_LV < 21)
				{
					this.tmpString.Append(this.DM.mStringTable.GetStringByID(4010u));
					GameConstants.FormatEstimateValue(this.tmpString, this.DM.m_WT_TotalForce);
				}
				else
				{
					this.tmpString.Append(this.DM.mStringTable.GetStringByID(4010u));
					this.tmpString.AppendFormat("{0:N0}", this.DM.m_WT_TroopTotal);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				int num = 0;
				uint num2 = 0u;
				if (this.mCustomPanel_LV < 15)
				{
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
				}
				else if (this.mCustomPanel_LV >= 15 && this.mCustomPanel_LV < 17)
				{
					uint[] array = new uint[4];
					Array.Clear(array, 0, array.Length);
					for (int j = 0; j < 16; j++)
					{
						if ((this.DM.m_WT_TrooFlag >> j & 1) == 1)
						{
							int num3 = j / 4;
							array[num3] += 1u;
							if ((ulong)num2 < (ulong)((long)num3))
							{
								num2 = (uint)num3;
							}
						}
					}
					for (int k = 0; k < 4; k++)
					{
						if (array[k] > 0u)
						{
							num++;
							this.tmpString.Length = 0;
							if (this.mCustomPanel_LV < 15)
							{
								this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(3931u));
							}
							else if (this.mCustomPanel_LV >= 15)
							{
								SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(k * 4 + 1));
								this.tmpString.Append(this.DM.mStringTable.GetStringByID((uint)((ushort)(3841 + (int)recordByKey.SoldierKind))));
								this.mListItemStr1.Add(this.tmpString.ToString());
							}
							if (this.mCustomPanel_LV < 17)
							{
								this.mListItemStr2.Add(this.DM.mStringTable.GetStringByID(3931u));
							}
							if ((ulong)num2 == (ulong)((long)k))
							{
								this.tmplist.Add(40f);
								this.CurrentPanelHeight += 40f;
							}
							else
							{
								this.tmplist.Add(32f);
								this.CurrentPanelHeight += 32f;
							}
							this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
							this.mListItemHint.Add(0);
						}
					}
				}
				else
				{
					for (int l = 0; l < 16; l++)
					{
						int num3 = 3 - l / 4 + l % 4 * 4;
						int num4 = 4 - l / 4 + l % 4 * 4;
						if (this.DM.m_WT_TroopData[num3] > 0u)
						{
							num++;
							num2 += this.DM.m_WT_TroopData[num3];
							this.tmpString.Length = 0;
							SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)num4);
							this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
							if (this.mCustomPanel_LV >= 17 && this.mCustomPanel_LV <= 20)
							{
								this.tmpString.Length = 0;
								GameConstants.FormatEstimateValue(this.tmpString, this.DM.m_WT_TroopData[num3]);
								this.mListItemStr2.Add(this.tmpString.ToString());
							}
							else if (this.mCustomPanel_LV > 20)
							{
								this.tmpString.Length = 0;
								this.tmpString.AppendFormat("{0:N0}", this.DM.m_WT_TroopData[num3]);
								this.mListItemStr2.Add(this.tmpString.ToString());
							}
							if (num2 == this.DM.m_WT_TroopTotal)
							{
								this.tmplist.Add(40f);
								this.CurrentPanelHeight += 40f;
							}
							else
							{
								this.tmplist.Add(32f);
								this.CurrentPanelHeight += 32f;
							}
							this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
							this.mListItemHint.Add((byte)num4);
						}
					}
				}
				break;
			}
			case 2:
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				if (this.mKindCustomPanel == 5)
				{
					this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5358u));
				}
				else
				{
					this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4019u));
				}
				this.tmpString.Length = 0;
				if (this.mCustomPanel_LV < 13 && this.mKindCustomPanel != 5)
				{
					this.tmpString.Append(this.DM.mStringTable.GetStringByID(4011u));
					this.tmpString.Append(this.DM.mStringTable.GetStringByID(3931u));
				}
				else
				{
					if (this.mKindCustomPanel == 5)
					{
						this.HEROCount = (int)this.DM.DefenseHeroCount;
					}
					else if (this.mKindCustomPanel == 1 || this.mKindCustomPanel == 2 || this.mKindCustomPanel == 3 || this.mKindCustomPanel == 12 || this.mKindCustomPanel == 11)
					{
						this.HEROCount = (int)this.DM.m_WT_HeroNum;
					}
					else
					{
						this.HEROCount = 0;
					}
					this.tmpString.Append(this.DM.mStringTable.GetStringByID(4011u));
					this.tmpString.Append(this.HEROCount);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				if (this.mCustomPanel_LV >= 19 || this.mKindCustomPanel == 5)
				{
					bool flag = true;
					if (this.mKindCustomPanel == 5)
					{
						if (this.mCustomPanel_LV < 8)
						{
							flag = false;
						}
						else
						{
							for (int m = 0; m < this.HEROCount; m++)
							{
								this.mHeroID[m] = this.DM.DefenseHero[m].HeroID;
								this.mHeroRank[m] = this.DM.DefenseHero[m].Rank;
								this.mHeroStar[m] = this.DM.DefenseHero[m].Star;
							}
						}
					}
					else
					{
						this.HEROCount = (int)this.DM.m_WT_HeroNum;
						for (int n = 0; n < (int)this.DM.m_WT_HeroNum; n++)
						{
							this.mHeroID[n] = this.DM.m_WT_HeroID[n];
							if (this.mCustomPanel_LV >= 23)
							{
								this.mHeroRank[n] = this.DM.m_WT_HeroRank[n].Rank;
								this.mHeroStar[n] = this.DM.m_WT_HeroRank[n].Medal;
							}
							else
							{
								this.mHeroRank[n] = 1;
								this.mHeroStar[n] = 1;
							}
						}
					}
					if (this.HEROCount > 0 && flag)
					{
						this.mListItemStr1.Add("1");
						this.mListItemStr2.Add("1");
						this.tmplist.Add(127f);
						this.CurrentPanelHeight += 127f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P3_Hero);
						this.mListItemHint.Add(0);
					}
					else
					{
						this.tmplist.Add(40f);
						this.CurrentPanelHeight += 40f;
						this.mListItemStr1.Add("-");
						this.mListItemStr2.Add("-");
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add(0);
					}
				}
				break;
			case 3:
				this.tmplist.Add(38f);
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5357u));
				this.mListItemStr2.Add(string.Empty);
				this.CurrentPanelHeight += 38f;
				for (int num5 = 0; num5 < 5; num5++)
				{
					this.mRes[num5] = this.DM.ScoutResource[num5];
				}
				this.tmplist.Add(93f);
				this.CurrentPanelHeight += 93f;
				this.mListItemStr1.Add(string.Empty);
				this.mListItemStr2.Add(string.Empty);
				this.tmplistIdx.Add(CustomPanel_Ptype.P4_Resources);
				this.mListItemHint.Add(0);
				break;
			case 5:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5359u));
				this.mListItemStr2.Add(string.Empty);
				int num6 = 0;
				if (this.mCustomPanel_LV >= 10)
				{
					int num7 = 0;
					while (num7 < (int)this.DM.StrengthenCount && num7 < 14)
					{
						num6++;
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add(0);
						Equip recordByKey2 = this.DM.EquipTable.GetRecordByKey(this.DM.Strengthen_Info[num7].ItemID);
						this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey2.EquipName));
						this.tmpString.Length = 0;
						if (this.DM.Strengthen_Info[num7].Time >= 86400u)
						{
							if (this.GUIM.IsArabic)
							{
								this.tmpString.AppendFormat("{0:00}:{1:00}:{2:00} {3}d", new object[]
								{
									this.DM.Strengthen_Info[num7].Time % 86400u / 3600u,
									this.DM.Strengthen_Info[num7].Time % 3600u / 60u,
									this.DM.Strengthen_Info[num7].Time % 60u,
									this.DM.Strengthen_Info[num7].Time / 86400u
								});
							}
							else
							{
								this.tmpString.AppendFormat("{0}d {1:00}:{2:00}:{3:00}", new object[]
								{
									this.DM.Strengthen_Info[num7].Time / 86400u,
									this.DM.Strengthen_Info[num7].Time % 86400u / 3600u,
									this.DM.Strengthen_Info[num7].Time % 3600u / 60u,
									this.DM.Strengthen_Info[num7].Time % 60u
								});
							}
						}
						else
						{
							this.tmpString.AppendFormat("{0:00}:{1:00}:{2:00}", this.DM.Strengthen_Info[num7].Time / 3600u, this.DM.Strengthen_Info[num7].Time % 3600u / 60u, this.DM.Strengthen_Info[num7].Time % 60u);
						}
						this.mListItemStr2.Add(this.tmpString.ToString());
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						num7++;
					}
				}
				if (num6 != 0)
				{
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
				}
				else
				{
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplist.Add(32f);
					this.CurrentPanelHeight += 32f;
				}
				break;
			}
			case 6:
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5361u));
				this.mListItemStr2.Add(string.Empty);
				this.tmpString.Length = 0;
				if (this.mCustomPanel_LV >= 6 && this.mCustomPanel_LV < 10)
				{
					this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5363u));
					this.tmpString.Length = 0;
					if (this.GUIM.IsArabic)
					{
						this.tmpString.AppendFormat("%{0}", this.DM.WallStatus);
					}
					else
					{
						this.tmpString.AppendFormat("{0}%", this.DM.WallStatus);
					}
					this.mListItemStr2.Add(this.tmpString.ToString());
				}
				else if (this.mCustomPanel_LV >= 10)
				{
					this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5363u));
					this.tmpString.Length = 0;
					if (this.GUIM.IsArabic)
					{
						this.tmpString.AppendFormat("{0:N0}/", this.DM.WallMaxValue);
						this.tmpString.AppendFormat("{0:N0}", this.DM.WallValue);
					}
					else
					{
						this.tmpString.AppendFormat("{0:N0}/", this.DM.WallValue);
						this.tmpString.AppendFormat("{0:N0}", this.DM.WallMaxValue);
					}
					this.mListItemStr2.Add(this.tmpString.ToString());
				}
				this.tmplist.Add(40f);
				this.CurrentPanelHeight += 40f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				this.mListItemHint.Add(0);
				break;
			case 7:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5364u));
				this.tmpString.Length = 0;
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(5365u));
				if (this.mCustomPanel_LV >= 9)
				{
					this.tmpString.AppendFormat("{0:N0}", this.DM.TrapsNum);
					this.mListItemStr2.Add(this.tmpString.ToString());
				}
				else if (this.mCustomPanel_LV >= 2)
				{
					GameConstants.FormatEstimateValue(this.tmpString, this.DM.TrapsNum);
					this.mListItemStr2.Add(this.tmpString.ToString());
				}
				else
				{
					this.mListItemStr2.Add(this.DM.mStringTable.GetStringByID(3931u));
				}
				int num8 = 0;
				for (int num9 = 0; num9 < 12; num9++)
				{
					int num10 = 3 - num9 / 3 + num9 % 3 * 4;
					if ((this.DM.TrapsFlag >> num10 & 1) == 1)
					{
						num8++;
						SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num10 + 17));
						this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
						this.tmpString.Length = 0;
						if (this.mCustomPanel_LV >= 9)
						{
							this.tmpString.Length = 0;
							this.tmpString.AppendFormat("{0:N0}", this.DM.TrapsInfo[num10]);
							this.mListItemStr2.Add(this.tmpString.ToString());
						}
						else
						{
							this.tmpString.Length = 0;
							GameConstants.FormatEstimateValue(this.tmpString, this.DM.TrapsInfo[num10]);
							this.mListItemStr2.Add(this.tmpString.ToString());
						}
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add((byte)(num10 + 17));
					}
				}
				if (num8 != 0)
				{
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
				}
				else
				{
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplist.Add(32f);
					this.CurrentPanelHeight += 32f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
				}
				break;
			}
			case 8:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5366u));
				this.tmpString.Length = 0;
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(5368u));
				if (this.mCustomPanel_LV >= 1 && this.mCustomPanel_LV < 9)
				{
					GameConstants.FormatEstimateValue(this.tmpString, this.DM.DefenseNum);
				}
				else if (this.mCustomPanel_LV >= 9)
				{
					this.tmpString.AppendFormat("{0:N0}", this.DM.DefenseNum);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				int num11 = (int)this.DM.TroopsFlag;
				int num12 = 0;
				if (this.mCustomPanel_LV >= 2 && this.mCustomPanel_LV < 4)
				{
					byte[] array2 = new byte[4];
					for (int num13 = 0; num13 < 4; num13++)
					{
						array2[num13] = (byte)(num11 & 7);
						num11 >>= 4;
						for (int num14 = 0; num14 < (int)array2[num13]; num14++)
						{
							num12++;
							this.tmpString.Length = 0;
							SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num14 + 1 + num13 * 4));
							this.tmpString.Append(this.DM.mStringTable.GetStringByID((uint)((ushort)(3841 + (int)recordByKey.SoldierKind))));
							this.mListItemStr1.Add(this.tmpString.ToString());
							this.mListItemStr2.Add("-");
							this.tmplist.Add(32f);
							this.CurrentPanelHeight += 32f;
							this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
							this.mListItemHint.Add(0);
						}
					}
					if (num12 != 0)
					{
						this.tmplist.RemoveAt(this.tmplist.Count - 1);
						this.tmplist.Add(40f);
						this.CurrentPanelHeight += 40f;
					}
					else
					{
						this.mListItemStr1.Add("-");
						this.mListItemStr2.Add("-");
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add(0);
					}
				}
				else if (this.mCustomPanel_LV >= 4)
				{
					for (int num15 = 0; num15 < 16; num15++)
					{
						int num10 = 3 - num15 / 4 + num15 % 4 * 4;
						if ((num11 >> num10 & 1) == 1)
						{
							num12++;
							this.tmpString.Length = 0;
							SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num10 + 1));
							this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
							if (this.mCustomPanel_LV >= 9)
							{
								this.tmpString.Length = 0;
								this.tmpString.AppendFormat("{0:N0}", this.DM.TroopsInfo[num10]);
								this.mListItemStr2.Add(this.tmpString.ToString());
							}
							else if (this.mCustomPanel_LV >= 5)
							{
								this.tmpString.Length = 0;
								GameConstants.FormatEstimateValue(this.tmpString, this.DM.TroopsInfo[num10]);
								this.mListItemStr2.Add(this.tmpString.ToString());
							}
							else
							{
								this.mListItemStr2.Add("-");
							}
							this.tmplist.Add(32f);
							this.CurrentPanelHeight += 32f;
							this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
							this.mListItemHint.Add((byte)(num10 + 1));
						}
					}
					if (num12 != 0)
					{
						this.tmplist.RemoveAt(this.tmplist.Count - 1);
						this.tmplist.Add(40f);
						this.CurrentPanelHeight += 40f;
					}
					else
					{
						this.mListItemStr1.Add("-");
						this.mListItemStr2.Add("-");
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add(0);
					}
				}
				break;
			}
			case 9:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5367u));
				this.tmpString.Length = 0;
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(5368u));
				if (this.mCustomPanel_LV >= 10)
				{
					this.tmpString.AppendFormat("{0:N0}", this.DM.ReinforceNum);
				}
				else if (this.mCustomPanel_LV >= 3)
				{
					GameConstants.FormatEstimateValue(this.tmpString, this.DM.ReinforceNum);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				int reinforceFlag = (int)this.DM.ReinforceFlag;
				int num16 = 0;
				for (int num17 = 0; num17 < 16; num17++)
				{
					int num10 = 3 - num17 / 4 + num17 % 4 * 4;
					if ((reinforceFlag >> num10 & 1) == 1)
					{
						num16++;
						this.tmpString.Length = 0;
						SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num10 + 1));
						this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
						if (this.mCustomPanel_LV >= 10)
						{
							this.tmpString.Length = 0;
							this.tmpString.AppendFormat("{0:N0}", this.DM.ReinforceInfo[num10]);
							this.mListItemStr2.Add(this.tmpString.ToString());
						}
						else if (this.mCustomPanel_LV >= 6)
						{
							this.tmpString.Length = 0;
							GameConstants.FormatEstimateValue(this.tmpString, this.DM.ReinforceInfo[num10]);
							this.mListItemStr2.Add(this.tmpString.ToString());
						}
						else
						{
							this.mListItemStr2.Add("-");
						}
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add((byte)(num10 + 1));
					}
				}
				if (num16 != 0)
				{
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
				}
				else
				{
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplist.Add(32f);
					this.CurrentPanelHeight += 32f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
				}
				break;
			}
			case 10:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5369u));
				this.mListItemStr2.Add(string.Empty);
				int num18 = 0;
				if (this.DM.ReinforcePlayerCount != 0)
				{
					for (int num19 = 0; num19 < (int)this.DM.ReinforcePlayerCount; num19++)
					{
						num18++;
						this.mListItemStr1.Add(this.DM.ReinforcePlayerName[num19].ToString());
						this.mListItemStr2.Add(string.Empty);
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add(0);
					}
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
				}
				else
				{
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplist.Add(32f);
					this.CurrentPanelHeight += 32f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
				}
				break;
			}
			case 11:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5370u));
				this.tmpString.Length = 0;
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(5365u));
				this.tmpString.AppendFormat("{0:N0}", this.DM.H_TrapsNum);
				this.mListItemStr2.Add(this.tmpString.ToString());
				int h_TrapsFlag = (int)this.DM.H_TrapsFlag;
				int num20 = 0;
				for (int num21 = 0; num21 < 12; num21++)
				{
					int num10 = 3 - num21 / 3 + num21 % 3 * 4;
					if ((h_TrapsFlag >> num10 & 1) == 1)
					{
						num20++;
						this.tmpString.Length = 0;
						SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num10 + 17));
						this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
						if (this.mCustomPanel_LV >= 10)
						{
							this.tmpString.Length = 0;
							this.tmpString.AppendFormat("{0:N0}", this.DM.H_TrapsInfo[num10]);
							this.mListItemStr2.Add(this.tmpString.ToString());
						}
						else if (this.mCustomPanel_LV >= 5)
						{
							this.tmpString.Length = 0;
							GameConstants.FormatEstimateValue(this.tmpString, this.DM.H_TrapsInfo[num10]);
							this.mListItemStr2.Add(this.tmpString.ToString());
						}
						else
						{
							this.mListItemStr2.Add("-");
						}
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add((byte)(num10 + 17));
					}
				}
				if (num20 != 0)
				{
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
				}
				else
				{
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplist.Add(32f);
					this.CurrentPanelHeight += 32f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
				}
				break;
			}
			case 12:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5372u));
				this.tmpString.Length = 0;
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(5373u));
				this.tmpString.AppendFormat("{0:N0}", this.DM.H_TroopsNum);
				this.mListItemStr2.Add(this.tmpString.ToString());
				int h_TroopsFlag = (int)this.DM.H_TroopsFlag;
				int num22 = 0;
				for (int num23 = 0; num23 < 16; num23++)
				{
					int num10 = 3 - num23 / 4 + num23 % 4 * 4;
					if ((h_TroopsFlag >> num10 & 1) == 1)
					{
						num22++;
						this.tmpString.Length = 0;
						SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num10 + 1));
						this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
						if (this.mCustomPanel_LV >= 10)
						{
							this.tmpString.Length = 0;
							this.tmpString.AppendFormat("{0:N0}", this.DM.H_TroopsInfo[num10]);
							this.mListItemStr2.Add(this.tmpString.ToString());
						}
						else if (this.mCustomPanel_LV >= 5)
						{
							this.tmpString.Length = 0;
							GameConstants.FormatEstimateValue(this.tmpString, this.DM.H_TroopsInfo[num10]);
							this.mListItemStr2.Add(this.tmpString.ToString());
						}
						else
						{
							this.mListItemStr2.Add("-");
						}
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add((byte)(num10 + 1));
					}
				}
				if (num22 != 0)
				{
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
				}
				else
				{
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplist.Add(32f);
					this.CurrentPanelHeight += 32f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
				}
				break;
			}
			case 13:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5374u));
				this.tmpString.Length = 0;
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(5368u));
				if (this.mCustomPanel_LV >= 2 && this.mCustomPanel_LV < 9)
				{
					GameConstants.FormatEstimateValue(this.tmpString, this.DM.MusterNum);
				}
				else if (this.mCustomPanel_LV >= 9)
				{
					this.tmpString.AppendFormat("{0:N0}", this.DM.MusterNum);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				int musterFlag = (int)this.DM.MusterFlag;
				int num24 = 0;
				for (int num25 = 0; num25 < 16; num25++)
				{
					int num10 = 3 - num25 / 4 + num25 % 4 * 4;
					if ((musterFlag >> num10 & 1) == 1)
					{
						num24++;
						this.tmpString.Length = 0;
						SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num10 + 1));
						this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
						if (this.mCustomPanel_LV >= 10)
						{
							this.tmpString.Length = 0;
							this.tmpString.AppendFormat("{0:N0}", this.DM.MusterInfo[num10]);
							this.mListItemStr2.Add(this.tmpString.ToString());
						}
						else if (this.mCustomPanel_LV >= 5)
						{
							this.tmpString.Length = 0;
							GameConstants.FormatEstimateValue(this.tmpString, this.DM.MusterInfo[num10]);
							this.mListItemStr2.Add(this.tmpString.ToString());
						}
						else
						{
							this.mListItemStr2.Add("-");
						}
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add((byte)(num10 + 1));
					}
				}
				if (num24 != 0)
				{
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
				}
				else
				{
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplist.Add(32f);
					this.CurrentPanelHeight += 32f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
				}
				break;
			}
			case 14:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5376u));
				this.mListItemStr2.Add(string.Empty);
				int num26 = 0;
				while (num26 < (int)this.DM.BuildingCount && num26 < this.DM.BuildInfo.Length)
				{
					BuildTypeData recordByKey3 = this.DM.BuildsTypeData.GetRecordByKey(this.DM.BuildInfo[num26].BuildID);
					this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey3.NameID));
					this.tmpString.Length = 0;
					this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(7003u), this.DM.BuildInfo[num26].Lv);
					this.mListItemStr2.Add(this.tmpString.ToString());
					this.tmplist.Add(32f);
					this.CurrentPanelHeight += 32f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
					num26++;
				}
				if (this.DM.BuildingCount != 0)
				{
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
				}
				break;
			}
			case 15:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add("123");
				this.mListItemStr2.Add(string.Empty);
				int num27 = 13;
				for (int num28 = 0; num28 < num27; num28++)
				{
					this.mListItemStr1.Add("789");
					this.mListItemStr2.Add("147");
					if (num27 < 2 || num28 == num27 - 1)
					{
						this.tmplist.Add(40f);
						this.CurrentPanelHeight += 40f;
					}
					else
					{
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
					}
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
				}
				break;
			}
			case 16:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(812u));
				this.mListItemStr2.Add(string.Empty);
				int num29 = 0;
				for (int num30 = 3; num30 >= 0; num30--)
				{
					for (int num31 = 0; num31 < 4; num31++)
					{
						if (this.DM.MarchEventData[this.DataIdx].TroopData[num31][num30] != 0u)
						{
							num29++;
							int num32 = num31 * 4 + num30;
							SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num32 + 1));
							this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
							this.tmpString.Length = 0;
							this.tmpString.AppendFormat("{0:N0}", this.DM.MarchEventData[this.DataIdx].TroopData[num31][num30]);
							this.mListItemStr2.Add(this.tmpString.ToString());
							this.mListItemHint.Add((byte)(num32 + 1));
						}
					}
				}
				for (int num33 = 0; num33 < num29; num33++)
				{
					if (num29 < 2 || num33 == num29 - 1)
					{
						this.tmplist.Add(40f);
						this.CurrentPanelHeight += 40f;
					}
					else
					{
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
					}
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				}
				break;
			}
			case 17:
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(572u));
				this.mListItemStr2.Add(string.Empty);
				this.HEROCount = 0;
				for (int num34 = 0; num34 < 5; num34++)
				{
					if (this.DM.MarchEventData[this.DataIdx].HeroID[num34] != 0)
					{
						this.mHeroID[num34] = this.DM.MarchEventData[this.DataIdx].HeroID[num34];
						this.HEROCount++;
					}
				}
				this.mListItemStr1.Add(string.Empty);
				this.mListItemStr2.Add(string.Empty);
				this.tmplist.Add(127f);
				this.CurrentPanelHeight += 127f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P3_Hero);
				this.mListItemHint.Add(0);
				break;
			case 18:
			{
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4927u));
				this.mListItemStr2.Add(string.Empty);
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				this.mListItemHint.Add(0);
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5798u));
				this.tmpString.Length = 0;
				if (!GUIManager.Instance.IsArabic)
				{
					this.tmpString.AppendFormat("{0:N0} / {1:N0}", this.DM.m_WallRepairNowValue, this.DM.m_WallRepairMaxValue);
				}
				else
				{
					this.tmpString.AppendFormat("{1:N0} / {0:N0}", this.DM.m_WallRepairNowValue, this.DM.m_WallRepairMaxValue);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				this.tmplist.Add(40f);
				this.CurrentPanelHeight += 40f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				this.mListItemHint.Add(0);
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5799u));
				uint num35 = 0u;
				RoleBuildingData buildData = this.GUIM.BuildingData.GetBuildData(12, 0);
				if (this.GUIM.BuildingData.GetBuildNumByID(12) > 0)
				{
					num35 = this.GUIM.BuildingData.GetBuildLevelRequestData(buildData.BuildID, buildData.Level).Value1;
				}
				this.tmpString.Length = 0;
				if (!GUIManager.Instance.IsArabic)
				{
					this.tmpString.AppendFormat("{0:N0} / {1:N0}", this.DM.TrapTotal, num35);
				}
				else
				{
					this.tmpString.AppendFormat("{1:N0} / {0:N0}", this.DM.TrapTotal, num35);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				this.tmplist.Add(40f);
				this.CurrentPanelHeight += 40f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				this.mListItemHint.Add(0);
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5800u));
				int maxDefenders = this.DM.GetMaxDefenders();
				int num36 = 0;
				for (int num37 = 0; num37 < this.DM.GetMaxDefenders(); num37++)
				{
					if (this.DM.m_DefendersID[num37] > 0)
					{
						num36++;
					}
				}
				this.tmpString.Length = 0;
				if (!GUIManager.Instance.IsArabic)
				{
					this.tmpString.AppendFormat("{0:N0} / {1:N0}", num36, maxDefenders);
				}
				else
				{
					this.tmpString.AppendFormat("{1:N0} / {0:N0}", num36, maxDefenders);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				this.tmplist.Add(40f);
				this.CurrentPanelHeight += 40f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				this.mListItemHint.Add(0);
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5801u));
				this.tmpString.Length = 0;
				if (!GUIManager.Instance.IsArabic)
				{
					this.tmpString.AppendFormat("{0:N0} / {1:N0}", this.DM.TrapHospitalTotal, num35);
				}
				else
				{
					this.tmpString.AppendFormat("{1:N0} / {0:N0}", this.DM.TrapHospitalTotal, num35);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				this.tmplist.Add(40f);
				this.CurrentPanelHeight += 40f;
				break;
			}
			case 19:
			{
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4932u));
				this.mListItemStr2.Add(string.Empty);
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				float num38 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_TRAINING_SPEED);
				float f = num38 / (10000f + num38) * 100f;
				num38 /= 100f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				this.mListItemHint.Add(0);
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4933u));
				this.tmpString.Length = 0;
				if (!GUIManager.Instance.IsArabic)
				{
					this.tmpString.AppendFormat("{0}%", num38);
				}
				else
				{
					this.tmpString.AppendFormat("%{0}", num38);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				this.tmplist.Add(40f);
				this.CurrentPanelHeight += 40f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				this.mListItemHint.Add(0);
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4934u));
				this.tmpString.Length = 0;
				CString cstring = new CString(10);
				cstring.FloatToFormat(f, 1, false);
				if (!GUIManager.Instance.IsArabic)
				{
					cstring.AppendFormat("-{0}%");
				}
				else
				{
					cstring.AppendFormat("%{0}-");
				}
				this.tmpString.Append(cstring.ToString());
				this.mListItemStr2.Add(this.tmpString.ToString());
				this.tmplist.Add(40f);
				this.CurrentPanelHeight += 40f;
				break;
			}
			case 20:
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4935u));
				this.mListItemStr2.Add(string.Empty);
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				if (this.DM.TrapTotal == 0u)
				{
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
				}
				else
				{
					for (int num39 = 0; num39 < this.DM.mTrapQty.Length; num39++)
					{
						if (this.DM.mTrapQty[(int)GameConstants.trapSortByTeir[num39]] != 0u)
						{
							this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
							this.mListItemHint.Add(GameConstants.trapSortByTeir[num39] + 17);
							SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(GameConstants.trapSortByTeir[num39] + 17));
							this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
							this.tmpString.Length = 0;
							this.tmpString.AppendFormat("{0:N0}", this.DM.mTrapQty[(int)GameConstants.trapSortByTeir[num39]]);
							this.mListItemStr2.Add(this.tmpString.ToString());
							this.tmplist.Add(40f);
							this.CurrentPanelHeight += 40f;
						}
					}
				}
				break;
			case 21:
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4936u));
				this.mListItemStr2.Add(string.Empty);
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				if (this.DM.TrapHospitalTotal == 0u)
				{
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
				}
				else
				{
					for (int num40 = 0; num40 < this.DM.mTrap_Hospital.Length; num40++)
					{
						if (this.DM.mTrap_Hospital[(int)GameConstants.trapSortByTeir[num40]] != 0u)
						{
							this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
							this.mListItemHint.Add(GameConstants.trapSortByTeir[num40] + 17);
							SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(GameConstants.trapSortByTeir[num40] + 17));
							this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
							this.tmpString.Length = 0;
							this.tmpString.AppendFormat("{0:N0}", this.DM.mTrap_Hospital[(int)GameConstants.trapSortByTeir[num40]]);
							this.mListItemStr2.Add(this.tmpString.ToString());
							this.tmplist.Add(40f);
							this.CurrentPanelHeight += 40f;
						}
					}
				}
				break;
			case 22:
			{
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4918u));
				this.mListItemStr2.Add(string.Empty);
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				long num41 = this.DM.SoldierTotal;
				for (int num42 = 0; num42 < this.DM.MarchEventData.Length; num42++)
				{
					for (int num43 = 0; num43 < this.DM.MarchEventData[num42].TroopData.Length; num43++)
					{
						if (this.DM.MarchEventData[num42].Type != EMarchEventType.EMET_Standby)
						{
							for (int num44 = 0; num44 < this.DM.MarchEventData[num42].TroopData[num43].Length; num44++)
							{
								num41 += (long)((ulong)this.DM.MarchEventData[num42].TroopData[num43][num44]);
							}
						}
					}
				}
				uint[] hideTroopData = HideArmyManager.Instance.GetHideTroopData();
				for (int num45 = 0; num45 < hideTroopData.Length; num45++)
				{
					num41 += (long)((ulong)hideTroopData[num45]);
				}
				this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				this.mListItemHint.Add(0);
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4919u));
				this.tmpString.Length = 0;
				this.tmpString.AppendFormat("{0:N0}", num41);
				this.mListItemStr2.Add(this.tmpString.ToString());
				this.tmplist.Add(40f);
				this.CurrentPanelHeight += 40f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				this.mListItemHint.Add(0);
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4920u));
				this.tmpString.Length = 0;
				if (this.DM.AttribVal.TotalSoldierConsume == 0UL)
				{
					this.tmpString.AppendFormat("<color=#ffffffff>{0:N0}</color>", this.DM.AttribVal.TotalSoldierConsume);
				}
				else if (!GUIManager.Instance.IsArabic)
				{
					this.tmpString.AppendFormat("<color=#ff6e7eff>-{0:N0}</color>", this.DM.AttribVal.TotalSoldierConsume);
				}
				else
				{
					this.tmpString.AppendFormat("<color=#ff6e7eff>{0:N0}-</color>", this.DM.AttribVal.TotalSoldierConsume);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				this.tmplist.Add(40f);
				this.CurrentPanelHeight += 40f;
				break;
			}
			case 23:
			{
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4921u));
				this.mListItemStr2.Add(string.Empty);
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				float num46 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED);
				uint num47 = (uint)(num46 / (10000f + num46) * 100f);
				num46 /= 100f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				this.mListItemHint.Add(0);
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4922u));
				this.tmpString.Length = 0;
				if (!GUIManager.Instance.IsArabic)
				{
					this.tmpString.AppendFormat("{0}%", num46);
				}
				else
				{
					this.tmpString.AppendFormat("%{0}", num46);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				this.tmplist.Add(40f);
				this.CurrentPanelHeight += 40f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				this.mListItemHint.Add(0);
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4923u));
				this.tmpString.Length = 0;
				CString cstring2 = new CString(10);
				cstring2.FloatToFormat(num47, 1, false);
				if (!GUIManager.Instance.IsArabic)
				{
					cstring2.AppendFormat("-{0}%");
				}
				else
				{
					cstring2.AppendFormat("%{0}-");
				}
				this.tmpString.Append(cstring2.ToString());
				this.mListItemStr2.Add(this.tmpString.ToString());
				this.tmplist.Add(40f);
				this.CurrentPanelHeight += 40f;
				uint num48 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY) * (10000u + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAINING_CAPACITY_PERCENT)) / 10000u;
				this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				this.mListItemHint.Add(0);
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4924u));
				this.tmpString.Length = 0;
				this.tmpString.AppendFormat("{0:N0}", num48);
				this.mListItemStr2.Add(this.tmpString.ToString());
				this.tmplist.Add(40f);
				this.CurrentPanelHeight += 40f;
				break;
			}
			case 24:
			{
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4925u));
				this.mListItemStr2.Add(string.Empty);
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				long num49 = this.DM.SoldierTotal;
				uint[] array3 = new uint[16];
				for (int num50 = 0; num50 < this.DM.RoleAttr.m_Soldier.Length; num50++)
				{
					array3[num50] = this.DM.RoleAttr.m_Soldier[num50];
				}
				for (int num51 = 0; num51 < this.DM.MarchEventData.Length; num51++)
				{
					if (this.DM.MarchEventData[num51].Type != EMarchEventType.EMET_Standby)
					{
						int num52 = 0;
						for (int num53 = 0; num53 < this.DM.MarchEventData[num51].TroopData.Length; num53++)
						{
							for (int num54 = 0; num54 < this.DM.MarchEventData[num51].TroopData[num53].Length; num54++)
							{
								array3[num52++] += this.DM.MarchEventData[num51].TroopData[num53][num54];
								num49 += (long)((ulong)this.DM.MarchEventData[num51].TroopData[num53][num54]);
							}
						}
					}
				}
				uint[] hideTroopData2 = HideArmyManager.Instance.GetHideTroopData();
				for (int num55 = 0; num55 < hideTroopData2.Length; num55++)
				{
					array3[num55] += hideTroopData2[num55];
					num49 += (long)((ulong)hideTroopData2[num55]);
				}
				if (num49 == 0L)
				{
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
				}
				else
				{
					for (int num56 = 0; num56 < this.DM.RoleAttr.m_Soldier.Length; num56++)
					{
						if (array3[(int)GameConstants.troopSortByTeir[num56]] != 0u)
						{
							this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
							this.mListItemHint.Add(GameConstants.troopSortByTeir[num56] + 1);
							SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(GameConstants.troopSortByTeir[num56] + 1));
							this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
							this.tmpString.Length = 0;
							this.tmpString.AppendFormat("{0:N0}", array3[(int)GameConstants.troopSortByTeir[num56]]);
							this.mListItemStr2.Add(this.tmpString.ToString());
							this.tmplist.Add(40f);
							this.CurrentPanelHeight += 40f;
						}
					}
				}
				break;
			}
			case 25:
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4019u));
				this.tmpString.Length = 0;
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(4011u));
				this.tmpString.Append(this.HEROCount);
				this.mListItemStr2.Add(this.tmpString.ToString());
				for (int num57 = 0; num57 < this.HEROCount; num57++)
				{
					this.mHeroID[num57] = this.mCS.Heros[num57].HeroID;
					this.mHeroRank[num57] = this.mCS.Heros[num57].Rank;
					this.mHeroStar[num57] = this.mCS.Heros[num57].Star;
				}
				this.mListItemStr1.Add("1");
				this.mListItemStr2.Add("1");
				this.tmplist.Add(127f);
				this.CurrentPanelHeight += 127f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P3_Hero);
				this.mListItemHint.Add(0);
				break;
			case 26:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5324u));
				this.tmpString.Length = 0;
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(4010u));
				this.tmpString.AppendFormat("{0:N0}", this.SDM.mStageTroopsAmount);
				this.mListItemStr2.Add(this.tmpString.ToString());
				int num58 = 0;
				Array.Clear(this.mWT_Troops, 0, this.mWT_Troops.Length);
				for (int num59 = 0; num59 < (int)this.SDM.mStageTroopsCount; num59++)
				{
					if (this.SDM.NowCombatStageInfo[num59].Amount > 0u)
					{
						this.mWT_Troops[(int)(this.SDM.NowCombatStageInfo[num59].SoldierTableID - 1)] = (byte)(num59 + 1);
					}
				}
				for (int num60 = 0; num60 < 16; num60++)
				{
					int num10 = 3 - num60 / 4 + num60 % 4 * 4;
					if (this.mWT_Troops[num10] > 0)
					{
						SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)this.SDM.NowCombatStageInfo[(int)(this.mWT_Troops[num10] - 1)].SoldierTableID);
						this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
						this.tmpString.Length = 0;
						this.tmpString.AppendFormat("{0:N0}", this.SDM.NowCombatStageInfo[(int)(this.mWT_Troops[num10] - 1)].Amount);
						this.mListItemStr2.Add(this.tmpString.ToString());
						num58++;
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add(this.SDM.NowCombatStageInfo[(int)(this.mWT_Troops[num10] - 1)].SoldierTableID);
					}
				}
				if (num58 == 0)
				{
					this.tmplistIdx.RemoveAt(this.tmplistIdx.Count - 1);
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.CurrentPanelHeight -= 38f;
					this.mListItemStr1.RemoveAt(this.mListItemStr1.Count - 1);
					this.mListItemStr2.RemoveAt(this.mListItemStr2.Count - 1);
					this.mListItemHint.RemoveAt(this.mListItemHint.Count - 1);
				}
				else
				{
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 8f;
				}
				break;
			}
			case 27:
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5361u));
				this.mListItemStr2.Add(string.Empty);
				this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				this.mListItemHint.Add(0);
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5363u));
				this.tmpString.Length = 0;
				if (this.GUIM.IsArabic)
				{
					this.tmpString.AppendFormat("{0:N0}/", this.mCSB.MaxWall);
					this.tmpString.AppendFormat("{0:N0}", this.SDM.CorpsStageWallDefence);
				}
				else
				{
					this.tmpString.AppendFormat("{0:N0}/", this.SDM.CorpsStageWallDefence);
					this.tmpString.AppendFormat("{0:N0}", this.mCSB.MaxWall);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				this.tmplist.Add(40f);
				this.CurrentPanelHeight += 40f;
				break;
			case 28:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5364u));
				this.tmpString.Length = 0;
				this.tmpString.Length = 0;
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(5365u));
				this.tmpString.AppendFormat(" {0:N0}", this.SDM.mStageTrapsAmount);
				this.mListItemStr2.Add(this.tmpString.ToString());
				Array.Clear(this.mWT_Traps, 0, this.mWT_Traps.Length);
				int num61 = 0;
				for (int num62 = (int)this.SDM.mStageTroopsCount; num62 < (int)(this.SDM.mStageTroopsCount + this.SDM.mStageTrapsCount); num62++)
				{
					if (this.SDM.NowCombatStageInfo[num62].Amount > 0u)
					{
						this.mWT_Traps[(int)(this.SDM.NowCombatStageInfo[num62].SoldierTableID - 17)] = (byte)(num62 + 1);
					}
				}
				for (int num63 = 0; num63 < 12; num63++)
				{
					int num10 = 3 - num63 / 3 + num63 % 3 * 4;
					if (this.mWT_Traps[num10] > 0)
					{
						SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)this.SDM.NowCombatStageInfo[(int)(this.mWT_Traps[num10] - 1)].SoldierTableID);
						this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
						this.tmpString.Length = 0;
						this.tmpString.AppendFormat("{0:N0}", this.SDM.NowCombatStageInfo[(int)(this.mWT_Traps[num10] - 1)].Amount);
						this.mListItemStr2.Add(this.tmpString.ToString());
						num61++;
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add(this.SDM.NowCombatStageInfo[(int)(this.mWT_Traps[num10] - 1)].SoldierTableID);
					}
				}
				if (num61 == 0)
				{
					this.tmplistIdx.RemoveAt(this.tmplistIdx.Count - 1);
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.CurrentPanelHeight -= 38f;
					this.mListItemStr1.RemoveAt(this.mListItemStr1.Count - 1);
					this.mListItemStr2.RemoveAt(this.mListItemStr2.Count - 1);
					this.mListItemHint.RemoveAt(this.mListItemHint.Count - 1);
				}
				else
				{
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 8f;
				}
				break;
			}
			case 29:
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5359u));
				this.tmpString.Length = 0;
				this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(5360u), this.mWT_StrengthenCount);
				this.mListItemStr2.Add(this.tmpString.ToString());
				for (int num64 = 0; num64 < this.mWT_StrengthenCount; num64++)
				{
					this.tmpString.Length = 0;
					GameConstants.GetEffectValue(this.tmpString, this.mEffectID[num64], 0u, 0, 0f, 0L);
					this.mListItemStr1.Add(this.tmpString.ToString());
					this.mListItemStr2.Add(string.Empty);
					this.tmplist.Add(32f);
					this.CurrentPanelHeight += 32f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
				}
				if (this.mWT_StrengthenCount == 0)
				{
					this.tmplistIdx.RemoveAt(this.tmplistIdx.Count - 1);
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.CurrentPanelHeight -= 38f;
					this.mListItemStr1.RemoveAt(this.mListItemStr1.Count - 1);
					this.mListItemStr2.RemoveAt(this.mListItemStr2.Count - 1);
					this.mListItemHint.RemoveAt(this.mListItemHint.Count - 1);
				}
				else
				{
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 8f;
				}
				break;
			case 30:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(7358u));
				this.mListItemStr2.Add(string.Empty);
				this.tmpString.Length = 0;
				this.tmpText_Info.text = this.DM.mStringTable.GetStringByID(this.InfoID);
				float num65 = this.tmpText_Info.preferredHeight;
				num65 += 10f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(this.InfoID));
				this.mListItemStr2.Add(string.Empty);
				this.tmplist.Add(num65);
				this.CurrentPanelHeight += num65;
				this.tmplistIdx.Add(CustomPanel_Ptype.P5_Text_Info);
				this.mListItemHint.Add(0);
				break;
			}
			case 31:
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(7791u));
				this.mListItemStr2.Add(this.DM.mStringTable.GetStringByID(7790u));
				for (int num66 = 0; num66 < this.DM.MapPrisoners.Count; num66++)
				{
					this.mListItemStr1.Add(this.DM.MapPrisoners[num66].TagName.ToString());
					this.tmpString.Length = 0;
					this.tmpString.AppendFormat("{0:N0}", this.DM.MapPrisoners[num66].Bounty);
					this.mListItemStr2.Add(this.tmpString.ToString());
					this.tmplist.Add(32f);
					this.CurrentPanelHeight += 32f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text_LeftAlign);
					this.mListItemHint.Add(0);
				}
				break;
			case 32:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9046u));
				this.tmpString.Length = 0;
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(5368u));
				if (this.mCustomPanel_LV >= 2 && this.mCustomPanel_LV < 9)
				{
					GameConstants.FormatEstimateValue(this.tmpString, this.DM.CaveNum);
				}
				else if (this.mCustomPanel_LV >= 9)
				{
					this.tmpString.AppendFormat("{0:N0}", this.DM.CaveNum);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				int num67 = 0;
				if (this.DM.bCaveMainHero)
				{
					this.tmplist.Add(32f);
					this.CurrentPanelHeight += 32f;
					this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(351u));
					this.mListItemStr2.Add(string.Empty);
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
					num67++;
				}
				int num68 = (int)this.DM.CaveFlag;
				if (this.mCustomPanel_LV >= 2 && this.mCustomPanel_LV < 4)
				{
					byte[] array4 = new byte[4];
					for (int num69 = 0; num69 < 4; num69++)
					{
						array4[num69] = (byte)(num68 & 7);
						num68 >>= 4;
						for (int num70 = 0; num70 < (int)array4[num69]; num70++)
						{
							num67++;
							this.tmpString.Length = 0;
							SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num70 + 1 + num69 * 4));
							this.tmpString.Append(this.DM.mStringTable.GetStringByID((uint)((ushort)(3841 + (int)recordByKey.SoldierKind))));
							this.mListItemStr1.Add(this.tmpString.ToString());
							this.mListItemStr2.Add("-");
							this.tmplist.Add(32f);
							this.CurrentPanelHeight += 32f;
							this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
							this.mListItemHint.Add(0);
						}
					}
					if (num67 != 0)
					{
						this.tmplist.RemoveAt(this.tmplist.Count - 1);
						this.tmplist.Add(40f);
						this.CurrentPanelHeight += 40f;
					}
					else
					{
						this.mListItemStr1.Add("-");
						this.mListItemStr2.Add("-");
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add(0);
					}
				}
				else if (this.mCustomPanel_LV >= 4)
				{
					for (int num71 = 0; num71 < 16; num71++)
					{
						int num10 = 3 - num71 / 4 + num71 % 4 * 4;
						if ((num68 >> num10 & 1) == 1)
						{
							num67++;
							this.tmpString.Length = 0;
							SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num10 + 1));
							this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
							if (this.mCustomPanel_LV >= 9)
							{
								this.tmpString.Length = 0;
								this.tmpString.AppendFormat("{0:N0}", this.DM.CaveInfo[num10]);
								this.mListItemStr2.Add(this.tmpString.ToString());
							}
							else if (this.mCustomPanel_LV >= 5)
							{
								this.tmpString.Length = 0;
								GameConstants.FormatEstimateValue(this.tmpString, this.DM.CaveInfo[num10]);
								this.mListItemStr2.Add(this.tmpString.ToString());
							}
							else
							{
								this.mListItemStr2.Add("-");
							}
							this.tmplist.Add(32f);
							this.CurrentPanelHeight += 32f;
							this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
							this.mListItemHint.Add((byte)(num10 + 1));
						}
					}
					if (num67 != 0)
					{
						this.tmplist.RemoveAt(this.tmplist.Count - 1);
						this.tmplist.Add(40f);
						this.CurrentPanelHeight += 40f;
					}
					else
					{
						this.mListItemStr1.Add("-");
						this.mListItemStr2.Add("-");
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
						this.mListItemHint.Add(0);
					}
				}
				break;
			}
			case 33:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(812u));
				this.mListItemStr2.Add(string.Empty);
				int num72 = 0;
				uint[] array5 = new uint[16];
				array5 = HideArmyManager.Instance.GetHideTroopData();
				for (int num73 = 0; num73 < 16; num73++)
				{
					int num10 = 3 - num73 / 4 + num73 % 4 * 4;
					if (array5[num10] != 0u)
					{
						num72++;
						SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num10 + 1));
						this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
						this.tmpString.Length = 0;
						this.tmpString.AppendFormat("{0:N0}", array5[num10]);
						this.mListItemStr2.Add(this.tmpString.ToString());
						this.mListItemHint.Add((byte)(num10 + 1));
					}
				}
				for (int num74 = 0; num74 < num72; num74++)
				{
					if (num72 < 2 || num74 == num72 - 1)
					{
						this.tmplist.Add(40f);
						this.CurrentPanelHeight += 40f;
					}
					else
					{
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
					}
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
				}
				break;
			}
			case 34:
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(8587u));
				this.mListItemStr2.Add(string.Empty);
				this.HEROCount = 1;
				this.mHeroID[0] = this.DM.GetLeaderID();
				this.mListItemStr1.Add(string.Empty);
				this.mListItemStr2.Add(string.Empty);
				this.tmplist.Add(127f);
				this.CurrentPanelHeight += 127f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P3_Hero);
				this.mListItemHint.Add(0);
				break;
			case 35:
			{
				List<KingGiftInfo> giftList = DataManager.Instance.KingGift.GetGiftList();
				if (giftList.Count > this.DataIdx)
				{
					this.tmplist.Add(38f);
					this.CurrentPanelHeight += 38f;
					this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9711u));
					this.mListItemStr2.Add(string.Empty);
					KingGiftInfo kingGiftInfo = giftList[this.DataIdx];
					KingGiftInfo.GiftList[] list = kingGiftInfo.List;
					int listCount = (int)kingGiftInfo.ListCount;
					MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[0];
					for (int num75 = 0; num75 < listCount; num75++)
					{
						list[num75].TageName.ClearString();
						list[num75].TageName.StringToFormat(mapYolk.WonderAllianceTag);
						list[num75].TageName.StringToFormat(list[num75].Name);
						if (this.GUIM.IsArabic)
						{
							list[num75].TageName.AppendFormat("{1}[{0}]");
						}
						else
						{
							list[num75].TageName.AppendFormat("[{0}]{1}");
						}
						this.mListItemStr1.Add(list[num75].TageName.ToString());
						this.mListItemStr2.Add(string.Empty);
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P5_Text_Info);
						this.mListItemHint.Add(0);
					}
				}
				break;
			}
			case 36:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9734u));
				this.tmpString.Length = 0;
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(5368u));
				if (this.mCustomPanel_LV >= 3 && this.mCustomPanel_LV < 10)
				{
					GameConstants.FormatEstimateValue(this.tmpString, this.DM.CantonmentNum);
				}
				else if (this.mCustomPanel_LV >= 10)
				{
					this.tmpString.AppendFormat("{0:N0}", this.DM.CantonmentNum);
				}
				this.mListItemStr2.Add(this.tmpString.ToString());
				int cantonmentFlag = (int)this.DM.CantonmentFlag;
				int num76 = 0;
				if (this.mCustomPanel_LV >= 4)
				{
					for (int num77 = 0; num77 < 16; num77++)
					{
						int num10 = 3 - num77 / 4 + num77 % 4 * 4;
						if ((cantonmentFlag >> num10 & 1) == 1)
						{
							num76++;
							this.tmpString.Length = 0;
							SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num10 + 1));
							this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
							if (this.mCustomPanel_LV >= 10)
							{
								this.tmpString.Length = 0;
								this.tmpString.AppendFormat("{0:N0}", this.DM.CantonmentInfo[num10]);
								this.mListItemStr2.Add(this.tmpString.ToString());
							}
							else if (this.mCustomPanel_LV >= 6)
							{
								this.tmpString.Length = 0;
								GameConstants.FormatEstimateValue(this.tmpString, this.DM.CantonmentInfo[num10]);
								this.mListItemStr2.Add(this.tmpString.ToString());
							}
							else
							{
								this.mListItemStr2.Add("-");
							}
							this.tmplist.Add(32f);
							this.CurrentPanelHeight += 32f;
							this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
							this.mListItemHint.Add((byte)(num10 + 1));
						}
					}
				}
				if (num76 != 0)
				{
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
				}
				else
				{
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplist.Add(32f);
					this.CurrentPanelHeight += 32f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
				}
				break;
			}
			case 37:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9747u));
				this.tmpString.Length = 0;
				int cantonmentHeroCount = (int)this.DM.CantonmentHeroCount;
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(4011u));
				this.tmpString.Append(cantonmentHeroCount);
				this.mListItemStr2.Add(this.tmpString.ToString());
				bool flag2 = true;
				if (this.mCustomPanel_LV < 8)
				{
					flag2 = false;
				}
				if (cantonmentHeroCount > 0 && flag2)
				{
					this.mListItemStr1.Add("1");
					this.mListItemStr2.Add("1");
					this.tmplist.Add(127f);
					this.CurrentPanelHeight += 127f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P3_Hero_C);
					this.mListItemHint.Add(0);
				}
				else
				{
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
				}
				break;
			}
			case 38:
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9746u));
				this.mListItemStr2.Add(string.Empty);
				if (this.DM.CantonmentPlayerName != null && this.DM.CantonmentPlayerName.Length != 0)
				{
					this.mListItemStr1.Add(this.DM.CantonmentPlayerName.ToString());
					this.mListItemStr2.Add(string.Empty);
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
				}
				else
				{
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplist.Add(32f);
					this.CurrentPanelHeight += 32f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
				}
				break;
			case 39:
			{
				List<KingGiftInfo> giftList2 = DataManager.Instance.KingGift.GetGiftList();
				if (giftList2.Count > this.DataIdx)
				{
					this.tmplist.Add(38f);
					this.CurrentPanelHeight += 38f;
					this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9711u));
					this.mListItemStr2.Add(string.Empty);
					KingGiftInfo kingGiftInfo2 = giftList2[this.DataIdx];
					KingGiftInfo.GiftList[] list2 = kingGiftInfo2.List;
					int listCount2 = (int)kingGiftInfo2.ListCount;
					for (int num78 = 0; num78 < listCount2; num78++)
					{
						list2[num78].TageName.ClearString();
						list2[num78].TageName.StringToFormat(list2[num78].Tag);
						list2[num78].TageName.StringToFormat(list2[num78].Name);
						if (this.GUIM.IsArabic)
						{
							list2[num78].TageName.AppendFormat("{1}[{0}]");
						}
						else
						{
							list2[num78].TageName.AppendFormat("[{0}]{1}");
						}
						this.mListItemStr1.Add(list2[num78].TageName.ToString());
						this.mListItemStr2.Add(string.Empty);
						this.tmplist.Add(32f);
						this.CurrentPanelHeight += 32f;
						this.tmplistIdx.Add(CustomPanel_Ptype.P5_Text_Info);
						this.mListItemHint.Add(0);
					}
				}
				break;
			}
			case 40:
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(9595u));
				this.mListItemStr2.Add(string.Empty);
				this.mListItemStr1.Add("1");
				this.mListItemStr2.Add("1");
				this.tmplist.Add(102f);
				this.CurrentPanelHeight += 102f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P6_Item);
				this.mListItemHint.Add(0);
				break;
			case 41:
			{
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(4019u));
				this.HEROCount = 5;
				this.tmpString.Length = 0;
				this.tmpString.Append(this.DM.mStringTable.GetStringByID(4011u));
				this.tmpString.Append(this.HEROCount);
				this.mListItemStr2.Add(this.tmpString.ToString());
				bool flag3 = true;
				if (this.mCustomPanel_LV >= 19 || this.mKindCustomPanel == 5)
				{
					if (this.mCustomPanel_LV < 8)
					{
						flag3 = false;
					}
					else
					{
						for (int num79 = 0; num79 < this.HEROCount; num79++)
						{
							this.mHeroID[num79] = this.DM.DefenseHero[num79].HeroID;
							this.mHeroRank[num79] = this.DM.DefenseHero[num79].Rank;
							this.mHeroStar[num79] = (byte)Mathf.Clamp((int)this.DM.DefenseHero[num79].Star, 1, 5);
						}
					}
				}
				if (this.HEROCount > 0 && flag3)
				{
					this.mListItemStr1.Add("1");
					this.mListItemStr2.Add("1");
					this.tmplist.Add(127f);
					this.CurrentPanelHeight += 127f;
					this.tmplistIdx.Add(CustomPanel_Ptype.P3_Hero_Npc);
					this.mListItemHint.Add(0);
				}
				else
				{
					this.tmplist.Add(40f);
					this.CurrentPanelHeight += 40f;
					this.mListItemStr1.Add("-");
					this.mListItemStr2.Add("-");
					this.tmplistIdx.Add(CustomPanel_Ptype.P2_Text);
					this.mListItemHint.Add(0);
				}
				break;
			}
			case 42:
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(5387u));
				this.tmpString.Length = 0;
				this.mListItemStr2.Add(string.Empty);
				this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(5388u), this.GUIM.GetPointName_Letter((POINT_KIND)this.InfoID));
				this.mListItemStr1.Add(this.tmpString.ToString());
				this.mListItemStr2.Add(string.Empty);
				this.tmplist.Add(102f);
				this.CurrentPanelHeight += 102f;
				this.tmplistIdx.Add(CustomPanel_Ptype.P5_Text_Info);
				this.mListItemHint.Add(0);
				break;
			case 43:
				this.tmplist.Add(38f);
				this.CurrentPanelHeight += 38f;
				this.mListItemStr1.Add(this.DM.mStringTable.GetStringByID(12102u));
				this.tmpString.Length = 0;
				this.tmpString.Append(string.Empty);
				this.tmplistIdx.Add(CustomPanel_Ptype.P_PetSkill);
				this.mListItemHint.Add(0);
				this.mListItemStr1.Add(string.Empty);
				this.mListItemStr2.Add(string.Empty);
				this.tmplist.Add(180f);
				this.CurrentPanelHeight += 180f;
				break;
			}
		}
		this.mCustomH = bCustomH;
		this.mOpen = bOpen;
		this.mHeight = mHeight;
	}

	// Token: 0x060029D4 RID: 10708 RVA: 0x00464BF4 File Offset: 0x00462DF4
	public void InitScrollPanel()
	{
		int num = 0;
		RectTransform component = this.mScrollPanel.transform.GetComponent<RectTransform>();
		if (this.mCustomH)
		{
			component.sizeDelta = new Vector2(component.sizeDelta.x, this.CurrentPanelHeight);
			if (this.tmplist.Count >= 14)
			{
				num = 16;
			}
			else
			{
				num = this.tmplist.Count + 2;
			}
			if (this.mOpen)
			{
				this.mScrollPanel.IntiScrollPanel(this.CurrentPanelHeight, 0f, 0f, this.tmplist, num, this);
				UIButtonHint.scrollRect = this.mScrollPanel.transform.GetComponent<CScrollRect>();
			}
			else
			{
				this.mScrollPanel.AddNewDataHeight(this.tmplist, true, true);
			}
			this.mScrollPanel.gameObject.SetActive(true);
		}
		else
		{
			if (this.mOpen)
			{
				if (this.mKindCustomPanel == 5)
				{
					num = 16;
				}
				else if (this.tmplist.Count >= 14)
				{
					num = 16;
				}
				else
				{
					num = this.tmplist.Count + 2;
				}
				if (this.mHeight != 0f && this.mHeight > 160f)
				{
					component.sizeDelta = new Vector2(component.sizeDelta.x, this.mHeight - 10f);
					this.mScrollPanel.IntiScrollPanel(this.mHeight, 0f, 0f, this.tmplist, num, this);
				}
				else
				{
					this.mScrollPanel.IntiScrollPanel(396f, 0f, 0f, this.tmplist, num, this);
				}
				UIButtonHint.scrollRect = this.mScrollPanel.transform.GetComponent<CScrollRect>();
			}
			else if (this.mKindCustomPanel == 5)
			{
				this.mScrollPanel.AddNewDataHeight(this.tmplist, true, true);
			}
			else
			{
				this.mScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			}
			this.mScrollPanel.gameObject.SetActive(true);
		}
		this.ScrollPanelCount = num;
	}

	// Token: 0x060029D5 RID: 10709 RVA: 0x00464E18 File Offset: 0x00463018
	public void Destroy()
	{
		AssetManager.UnloadAssetBundle(this.abKey, true);
		this.tmplist = null;
		this.tmplistIdx = null;
		this.mListItemStr1 = null;
		this.mListItemStr2 = null;
		for (int i = 0; i < 5; i++)
		{
			if (this.mHead[i] != null)
			{
				UnityEngine.Object.Destroy(this.mHead[i]);
			}
			this.mHead[i] = null;
		}
		if (this.Cstr_SkillEffect != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_SkillEffect);
		}
	}

	// Token: 0x060029D6 RID: 10710 RVA: 0x00464EA4 File Offset: 0x004630A4
	public void Refresh_FontTexture()
	{
		if (this.tmpText_Info != null && this.tmpText_Info.enabled)
		{
			this.tmpText_Info.enabled = false;
			this.tmpText_Info.enabled = true;
		}
		if (this.Text_NpcItem != null && this.Text_NpcItem.enabled)
		{
			this.Text_NpcItem.enabled = false;
			this.Text_NpcItem.enabled = true;
		}
		if (this.Text_PetName != null && this.Text_PetName.enabled)
		{
			this.Text_PetName.enabled = false;
			this.Text_PetName.enabled = true;
		}
		if (this.Text_PetSkill != null && this.Text_PetSkill.enabled)
		{
			this.Text_PetSkill.enabled = false;
			this.Text_PetSkill.enabled = true;
		}
		if (this.Text_PetSkillEffect != null && this.Text_PetSkillEffect.enabled)
		{
			this.Text_PetSkillEffect.enabled = false;
			this.Text_PetSkillEffect.enabled = true;
		}
		for (int i = 0; i < 16; i++)
		{
			if (this.Text_Info[i] != null && this.Text_Info[i].enabled)
			{
				this.Text_Info[i].enabled = false;
				this.Text_Info[i].enabled = true;
			}
			if (this.Text_End[i] != null && this.Text_End[i].enabled)
			{
				this.Text_End[i].enabled = false;
				this.Text_End[i].enabled = true;
			}
			for (int j = 0; j < 2; j++)
			{
				if (this.Text_Title[i][j] != null && this.Text_Title[i][j].enabled)
				{
					this.Text_Title[i][j].enabled = false;
					this.Text_Title[i][j].enabled = true;
				}
				if (this.Text_TextStr[i][j] != null && this.Text_TextStr[i][j].enabled)
				{
					this.Text_TextStr[i][j].enabled = false;
					this.Text_TextStr[i][j].enabled = true;
				}
				if (this.Text_LeftAlign[i][j] != null && this.Text_LeftAlign[i][j].enabled)
				{
					this.Text_LeftAlign[i][j].enabled = false;
					this.Text_LeftAlign[i][j].enabled = true;
				}
			}
			for (int k = 0; k < 5; k++)
			{
				if (this.Text_Resources[i][k] != null && this.Text_Resources[i][k].enabled)
				{
					this.Text_Resources[i][k].enabled = false;
					this.Text_Resources[i][k].enabled = true;
				}
			}
		}
	}

	// Token: 0x060029D7 RID: 10711 RVA: 0x004651AC File Offset: 0x004633AC
	public void SetNpcImg()
	{
		if (this.TmpT != null && this.TmpT.parent != null)
		{
			for (int i = 0; i < this.TmpT.parent.childCount; i++)
			{
				int btnID = this.TmpT.parent.GetChild(i).GetComponent<ScrollPanelItem>().m_BtnID1;
				int btnID2 = this.TmpT.parent.GetChild(i).GetComponent<ScrollPanelItem>().m_BtnID2;
				if (this.TmpT.parent.GetChild(i).gameObject.activeSelf && btnID2 == 3)
				{
					this.UpDateRowItem(this.TmpT.transform.gameObject, btnID, i, 0);
				}
			}
		}
	}

	// Token: 0x060029D8 RID: 10712 RVA: 0x00465280 File Offset: 0x00463480
	private void Start()
	{
	}

	// Token: 0x060029D9 RID: 10713 RVA: 0x00465284 File Offset: 0x00463484
	private void Update()
	{
		if (this.bLeaderHero)
		{
			this.ShowTime += Time.smoothDeltaTime;
			if (this.ShowTime >= 0f)
			{
				if (this.ShowTime >= 2f)
				{
					this.ShowTime = 0f;
				}
				float a = (this.ShowTime <= 1f) ? this.ShowTime : (2f - this.ShowTime);
				this.ImgShowMain.color = new Color(1f, 1f, 1f, a);
			}
		}
		if (this.ImgShowMain_C != null && this.ImgShowMain_C.gameObject.activeSelf)
		{
			this.ShowTime_C += Time.smoothDeltaTime;
			if (this.ShowTime_C >= 0f)
			{
				if (this.ShowTime_C >= 2f)
				{
					this.ShowTime_C = 0f;
				}
				float a2 = (this.ShowTime_C <= 1f) ? this.ShowTime_C : (2f - this.ShowTime_C);
				this.ImgShowMain_C.color = new Color(1f, 1f, 1f, a2);
			}
		}
	}

	// Token: 0x040074F0 RID: 29936
	private Transform baseTransform;

	// Token: 0x040074F1 RID: 29937
	private Transform TmpT;

	// Token: 0x040074F2 RID: 29938
	private Transform Tmp_PT;

	// Token: 0x040074F3 RID: 29939
	private RectTransform tmpRC;

	// Token: 0x040074F4 RID: 29940
	private DataManager DM;

	// Token: 0x040074F5 RID: 29941
	private GUIManager GUIM;

	// Token: 0x040074F6 RID: 29942
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x040074F7 RID: 29943
	private UIText tmpText;

	// Token: 0x040074F8 RID: 29944
	public UIText tmpText_Info;

	// Token: 0x040074F9 RID: 29945
	public UIText[][] Text_Title = new UIText[16][];

	// Token: 0x040074FA RID: 29946
	public UIText[][] Text_TextStr = new UIText[16][];

	// Token: 0x040074FB RID: 29947
	public UIText[][] Text_LeftAlign = new UIText[16][];

	// Token: 0x040074FC RID: 29948
	public UIText[][] Text_Resources = new UIText[16][];

	// Token: 0x040074FD RID: 29949
	public UIText[] Text_Info = new UIText[16];

	// Token: 0x040074FE RID: 29950
	public UIText[] Text_End = new UIText[16];

	// Token: 0x040074FF RID: 29951
	public UIText[] Text_Rank = new UIText[16];

	// Token: 0x04007500 RID: 29952
	public UIText Text_NpcItem;

	// Token: 0x04007501 RID: 29953
	public UIText Text_PetName;

	// Token: 0x04007502 RID: 29954
	public UIText Text_PetSkill;

	// Token: 0x04007503 RID: 29955
	public UIText Text_PetSkillEffect;

	// Token: 0x04007504 RID: 29956
	private Image tmpImg;

	// Token: 0x04007505 RID: 29957
	private Image ImgShowMain;

	// Token: 0x04007506 RID: 29958
	private Image ImgShowMain_C;

	// Token: 0x04007507 RID: 29959
	private Image ImgHero;

	// Token: 0x04007508 RID: 29960
	private Image ImgHeroF;

	// Token: 0x04007509 RID: 29961
	private Image ImgNpcItem;

	// Token: 0x0400750A RID: 29962
	private Image[] Img_Icon = new Image[16];

	// Token: 0x0400750B RID: 29963
	private Image[] Img_BG = new Image[16];

	// Token: 0x0400750C RID: 29964
	private Image[] Img_TitleBG = new Image[16];

	// Token: 0x0400750D RID: 29965
	private Image[] Img_TitleBG2 = new Image[16];

	// Token: 0x0400750E RID: 29966
	private Sprite[] mSprite = new Sprite[9];

	// Token: 0x0400750F RID: 29967
	private UIButtonHint[] m_ItemHint = new UIButtonHint[16];

	// Token: 0x04007510 RID: 29968
	private ScrollPanel mScrollPanel;

	// Token: 0x04007511 RID: 29969
	private string abName = "UI/CustomPanel";

	// Token: 0x04007512 RID: 29970
	private int abKey;

	// Token: 0x04007513 RID: 29971
	private Door door;

	// Token: 0x04007514 RID: 29972
	private List<float> tmplist = new List<float>();

	// Token: 0x04007515 RID: 29973
	private List<CustomPanel_Ptype> tmplistIdx = new List<CustomPanel_Ptype>();

	// Token: 0x04007516 RID: 29974
	private List<string> mListItemStr1 = new List<string>();

	// Token: 0x04007517 RID: 29975
	private List<string> mListItemStr2 = new List<string>();

	// Token: 0x04007518 RID: 29976
	private List<byte> mListItemHint = new List<byte>();

	// Token: 0x04007519 RID: 29977
	private int mKindCustomPanel;

	// Token: 0x0400751A RID: 29978
	private ushort mCustomPanel_LV;

	// Token: 0x0400751B RID: 29979
	private Hero tmpHero;

	// Token: 0x0400751C RID: 29980
	private StringBuilder tmpString = new StringBuilder();

	// Token: 0x0400751D RID: 29981
	private StringBuilder tmpString2 = new StringBuilder();

	// Token: 0x0400751E RID: 29982
	private ushort[] mHeroID = new ushort[5];

	// Token: 0x0400751F RID: 29983
	private byte[] mHeroRank = new byte[5];

	// Token: 0x04007520 RID: 29984
	private byte[] mHeroStar = new byte[5];

	// Token: 0x04007521 RID: 29985
	private uint[] mRes = new uint[5];

	// Token: 0x04007522 RID: 29986
	private CurHeroData mHeroData;

	// Token: 0x04007523 RID: 29987
	private StageManager SDM;

	// Token: 0x04007524 RID: 29988
	private CorpsStage mCS;

	// Token: 0x04007525 RID: 29989
	private CorpsStageBattle mCSB;

	// Token: 0x04007526 RID: 29990
	private int HEROCount = 5;

	// Token: 0x04007527 RID: 29991
	private bool bLeaderHero;

	// Token: 0x04007528 RID: 29992
	private float ShowTime;

	// Token: 0x04007529 RID: 29993
	private float ShowTime_C;

	// Token: 0x0400752A RID: 29994
	public ushort MainHeroID;

	// Token: 0x0400752B RID: 29995
	public int DataIdx;

	// Token: 0x0400752C RID: 29996
	public CombatReport Report;

	// Token: 0x0400752D RID: 29997
	public int mWT_StrengthenCount;

	// Token: 0x0400752E RID: 29998
	public ushort[] mEffectID = new ushort[5];

	// Token: 0x0400752F RID: 29999
	public uint InfoID;

	// Token: 0x04007530 RID: 30000
	public byte[] mWT_Troops = new byte[16];

	// Token: 0x04007531 RID: 30001
	public byte[] mWT_Traps = new byte[12];

	// Token: 0x04007532 RID: 30002
	private GameObject[] mHead = new GameObject[5];

	// Token: 0x04007533 RID: 30003
	private int[] mAssetKey = new int[5];

	// Token: 0x04007534 RID: 30004
	private int ScrollPanelCount;

	// Token: 0x04007535 RID: 30005
	public ushort RewardID;

	// Token: 0x04007536 RID: 30006
	public IUIButtonDownUpHandler UpDownHandle;

	// Token: 0x04007537 RID: 30007
	private UIButtonHint tmpbtnHint;

	// Token: 0x04007538 RID: 30008
	private UIHIBtn Hbtn_Pet;

	// Token: 0x04007539 RID: 30009
	private CString Cstr_SkillEffect;

	// Token: 0x0400753A RID: 30010
	public float CurrentPanelHeight;

	// Token: 0x0400753B RID: 30011
	private bool mCustomH;

	// Token: 0x0400753C RID: 30012
	private bool mOpen;

	// Token: 0x0400753D RID: 30013
	private float mHeight;
}
