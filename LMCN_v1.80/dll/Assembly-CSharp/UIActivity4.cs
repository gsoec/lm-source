using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002A8 RID: 680
public class UIActivity4 : GUIWindow, UILoadImageHander, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler
{
	// Token: 0x06000DA2 RID: 3490 RVA: 0x0015D17C File Offset: 0x0015B37C
	public override void OnOpen(int arg1, int arg2)
	{
		MallManager instance = MallManager.Instance;
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.SM = StringManager.Instance;
		this.AM = ActivityManager.Instance;
		this.m_transform = base.transform;
		Font ttffont = this.GM.GetTTFFont();
		this.m_transform.GetChild(2).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(2).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(2).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(3).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(3).gameObject.AddComponent<ArabicItemTextureRot>();
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(2).GetComponent<CustomImage>().enabled = false;
		}
		if (arg1 == 1)
		{
			Transform child = this.m_transform.GetChild(1);
			this.OutText[0] = child.GetChild(2).GetComponent<UIText>();
			this.OutText[0].font = ttffont;
			this.OutText[0].text = this.DM.mStringTable.GetStringByID(8146u);
			this.OutText[1] = child.GetChild(3).GetComponent<UIText>();
			this.OutText[1].font = ttffont;
			this.OutText[2] = child.GetChild(4).GetComponent<UIText>();
			this.OutText[2].font = ttffont;
			this.OutText[2].text = this.DM.mStringTable.GetStringByID(8147u);
			this.OutText[3] = child.GetChild(5).GetChild(0).GetChild(1).GetComponent<UIText>();
			this.OutText[3].font = ttffont;
			if (arg2 == 100)
			{
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(8164u);
				this.OutText[3].text = this.DM.mStringTable.GetStringByID(8165u);
			}
			else if (arg2 == 0)
			{
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(8161u);
				this.OutText[3].text = this.DM.mStringTable.GetStringByID(8162u);
			}
			else if (arg2 == 1)
			{
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(8161u);
				this.OutText[3].text = this.DM.mStringTable.GetStringByID(8163u);
			}
			else if (arg2 == 201)
			{
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(9827u);
				this.OutText[3].text = this.DM.mStringTable.GetStringByID(8163u);
			}
			else if (arg2 == 202)
			{
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(9823u);
				this.OutText[3].text = this.DM.mStringTable.GetStringByID(9824u);
			}
			else if (arg2 == 203)
			{
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(9825u);
				this.OutText[3].text = this.DM.mStringTable.GetStringByID(8163u);
			}
			else if (arg2 == 204)
			{
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(9823u);
				this.OutText[3].text = this.DM.mStringTable.GetStringByID(9824u);
			}
			else if (arg2 == 205)
			{
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(9821u);
				this.OutText[3].text = this.DM.mStringTable.GetStringByID(9822u);
			}
			else if (arg2 == 207)
			{
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(10014u);
				this.OutText[3].text = this.DM.mStringTable.GetStringByID(10015u);
			}
			else if (arg2 == 208)
			{
				this.OutText[0].text = this.DM.mStringTable.GetStringByID(14523u);
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(14524u);
				this.InfoStr = StringManager.Instance.SpawnString(1500);
				this.InfoStr.Append(this.DM.mStringTable.GetStringByID(14525u));
				this.InfoStr.Append("\n\n");
				this.InfoStr.Append(this.DM.mStringTable.GetStringByID(14526u));
				this.OutText[3].text = this.InfoStr.ToString();
			}
			else if (arg2 == 209)
			{
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(5038u);
				this.OutText[3].text = this.DM.mStringTable.GetStringByID(5039u);
			}
			else if (arg2 == 211)
			{
				this.OutText[1].rectTransform.sizeDelta = new Vector2(720f, 51.2f);
				this.OutText[1].rectTransform.anchoredPosition = new Vector2(0f, 164f);
				this.OutText[1].resizeTextForBestFit = true;
				this.OutText[1].resizeTextMaxSize = 19;
				this.OutText[1].resizeTextMinSize = 10;
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(12230u);
				this.OutText[3].text = this.DM.mStringTable.GetStringByID(12231u);
			}
			else if (arg2 == 212)
			{
				this.OutText[1].rectTransform.sizeDelta = new Vector2(720f, 51.2f);
				this.OutText[1].rectTransform.anchoredPosition = new Vector2(0f, 164f);
				this.OutText[1].resizeTextForBestFit = true;
				this.OutText[1].resizeTextMaxSize = 19;
				this.OutText[1].resizeTextMinSize = 10;
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(12227u);
				this.OutText[3].text = this.DM.mStringTable.GetStringByID(12228u);
			}
			else if (arg2 == 213)
			{
				this.OutText[0].text = this.DM.mStringTable.GetStringByID(12225u);
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(12223u);
				this.OutText[3].text = this.DM.mStringTable.GetStringByID(12224u);
			}
			this.OutText[3].rectTransform.sizeDelta = new Vector2(this.OutText[3].rectTransform.sizeDelta.x, this.OutText[3].preferredHeight);
			RectTransform component = child.GetChild(5).GetChild(0).GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(component.sizeDelta.x, this.OutText[3].preferredHeight + 12f);
		}
		else if (arg1 == 2)
		{
			this.bPrize = true;
			if (arg2 >= 201 && arg2 <= 205)
			{
				if (arg2 - 201 >= this.AM.KvKActivityData.Length)
				{
					return;
				}
				this.ActivityIndex = (byte)arg2;
				this.tmpData = this.AM.KvKActivityData[arg2 - 201];
			}
			else if (arg2 == 206)
			{
				this.PrizeCount = 5;
				this.ActivityIndex = (byte)arg2;
				this.tmpData = this.AM.AllyMobilizationData;
			}
			else if (arg2 == 210)
			{
				this.PrizeCount = 5;
				this.ActivityIndex = (byte)arg2;
				this.tmpData = this.AM.AllianceWarData;
			}
			else if (arg2 >= 211 && arg2 <= 213)
			{
				if (arg2 - 211 >= this.AM.FIFAData.Length)
				{
					return;
				}
				this.ActivityIndex = (byte)arg2;
				this.tmpData = this.AM.FIFAData[arg2 - 211];
			}
			else
			{
				this.tmpData = this.AM.ActivityData[arg2];
				this.ActivityIndex = (byte)arg2;
			}
			this.STitleText = new UIText[this.PrizeCount];
			this.SGemCountText = new UIText[this.PrizeCount];
			this.STotalpriceText = new UIText[this.PrizeCount];
			this.SNoPriceText = new UIText[this.PrizeCount];
			Transform child = this.m_transform.GetChild(1);
			this.OutText[0] = child.GetChild(2).GetComponent<UIText>();
			this.OutText[0].font = ttffont;
			this.OutText[0].text = this.DM.mStringTable.GetStringByID(8148u);
			this.OutText[1] = child.GetChild(3).GetComponent<UIText>();
			this.OutText[1].font = ttffont;
			this.OutText[1].resizeTextForBestFit = true;
			this.OutText[1].resizeTextMaxSize = 19;
			this.OutText[1].resizeTextMinSize = 10;
			if (arg2 == 206)
			{
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(1365u);
			}
			else if (arg2 == 210)
			{
				this.OutText[1].rectTransform.anchoredPosition = new Vector2(0f, 169.4f);
				this.OutText[1].rectTransform.sizeDelta = new Vector2(750f, 65f);
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(17028u);
			}
			else if (arg2 >= 203 && arg2 <= 205 && this.AM.IsMatchKvk())
			{
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(8176u);
			}
			else if (arg2 >= 211 && arg2 <= 213 && this.AM.IsInFIFA(0, false))
			{
				if (this.tmpData.ActiveType == EActivityType.EAT_FIFA_KVK)
				{
					this.OutText[1].text = this.DM.mStringTable.GetStringByID(8176u);
				}
				else if (arg2 == 211)
				{
					this.OutText[1].text = this.DM.mStringTable.GetStringByID(12229u);
				}
				else if (arg2 == 212)
				{
					this.OutText[1].text = this.DM.mStringTable.GetStringByID(12226u);
				}
				else
				{
					this.OutText[1].text = this.DM.mStringTable.GetStringByID(12226u);
				}
			}
			else
			{
				this.OutText[1].text = this.DM.mStringTable.GetStringByID(8155u);
			}
			this.OutText[2] = child.GetChild(4).GetComponent<UIText>();
			this.OutText[2].font = ttffont;
			this.OutText[2].text = this.DM.mStringTable.GetStringByID(8149u);
			child.GetChild(5).GetChild(0).GetChild(1).gameObject.SetActive(false);
			this.TitleText = new CString[this.PrizeCount];
			this.GemCountText = new CString[this.PrizeCount];
			this.TotalpriceText = new CString[this.PrizeCount];
			this.NoPriceText = new CString[this.PrizeCount];
			this.ItemCount = new int[this.PrizeCount];
			for (int i = 0; i < this.PrizeCount; i++)
			{
				this.ItemCount[i] = (int)this.tmpData.RankingPrizeDataLen[i];
			}
			this.ItemCountText = new CString[this.PrizeCount][];
			this.SItemCountText = new UIText[this.PrizeCount][];
			for (int j = 0; j < this.PrizeCount; j++)
			{
				this.ItemCountText[j] = new CString[this.ItemCount[j]];
				this.SItemCountText[j] = new UIText[this.ItemCount[j]];
			}
			float num = 0f;
			float num2 = 30f;
			this.ContentT = child.GetChild(5).GetChild(0);
			int num3 = 0;
			int num4 = 0;
			for (int k = 0; k < this.PrizeCount; k++)
			{
				if (this.ActivityIndex == 210)
				{
					num4++;
					GameObject gameObject = UnityEngine.Object.Instantiate(this.ContentT.GetChild(0).gameObject) as GameObject;
					gameObject.SetActive(true);
					gameObject.transform.SetParent(this.ContentT, false);
					Transform transform = gameObject.transform;
					transform.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -num - (181f - num2 + 3f) * (float)k);
					this.STitleText[k] = transform.GetChild(3).GetComponent<UIText>();
					this.STitleText[k].font = ttffont;
					this.TitleText[k] = this.SM.SpawnString(30);
					if (k <= 1)
					{
						transform.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(k);
						this.TitleText[k].IntToFormat((long)(k + 1), 1, false);
						this.TitleText[k].AppendFormat(this.DM.mStringTable.GetStringByID(8150u));
					}
					else
					{
						byte b = 1;
						byte b2 = 1;
						if (k == 2)
						{
							b = 3;
							b2 = 4;
						}
						else if (k == 3)
						{
							b = 5;
							b2 = 8;
						}
						else if (k == 4)
						{
							b = 9;
							b2 = 16;
						}
						transform.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(3);
						this.TitleText[k].IntToFormat((long)b, 1, false);
						this.TitleText[k].IntToFormat((long)b2, 1, false);
						this.TitleText[k].AppendFormat(this.DM.mStringTable.GetStringByID(8151u));
					}
					this.STitleText[k].text = this.TitleText[k].ToString();
					this.SGemCountText[k] = transform.GetChild(2).GetComponent<UIText>();
					this.SGemCountText[k].font = ttffont;
					this.GemCountText[k] = this.SM.SpawnString(30);
					transform.GetChild(1).gameObject.SetActive(false);
					transform.GetChild(2).gameObject.SetActive(false);
					this.STotalpriceText[k] = transform.GetChild(4).GetComponent<UIText>();
					this.STotalpriceText[k].font = ttffont;
					this.TotalpriceText[k] = this.SM.SpawnString(30);
					transform.GetChild(4).gameObject.SetActive(false);
					this.SNoPriceText[k] = transform.GetChild(5).GetComponent<UIText>();
					this.SNoPriceText[k].font = ttffont;
					this.NoPriceText[k] = this.SM.SpawnString(30);
					transform.GetChild(5).gameObject.SetActive(false);
					int num5 = 0;
					Transform child2 = transform.GetChild(6);
					this.GM.InitianHeroItemImg(child2.GetChild(0), eHeroOrItem.Item, 1001, 0, 0, 0, false, true, true, false);
					child2.GetChild(2).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
					this.GM.InitLordEquipImg(child2.GetChild(2), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
					for (int l = 0; l < this.ItemCount[k]; l++)
					{
						if (this.tmpData.RankingPrize[num3].ItemID == 0)
						{
							num3++;
						}
						else
						{
							Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpData.RankingPrize[num3].ItemID);
							if (recordByKey.EquipKind == 11 && recordByKey.PropertiesInfo[0].Propertieskey == 6)
							{
								num3++;
							}
							else
							{
								GameObject gameObject2 = UnityEngine.Object.Instantiate(child2.gameObject) as GameObject;
								gameObject2.SetActive(true);
								gameObject2.transform.SetParent(transform, false);
								bool flag = this.GM.IsLeadItem(recordByKey.EquipKind);
								if (flag)
								{
									gameObject2.transform.GetChild(0).gameObject.SetActive(false);
									gameObject2.transform.GetChild(2).gameObject.SetActive(true);
									this.GM.ChangeLordEquipImg(gameObject2.transform.GetChild(2), this.tmpData.RankingPrize[num3].ItemID, this.tmpData.RankingPrize[num3].Rank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
								}
								else
								{
									this.GM.ChangeHeroItemImg(gameObject2.transform.GetChild(0), eHeroOrItem.Item, this.tmpData.RankingPrize[num3].ItemID, 0, this.tmpData.RankingPrize[num3].Rank, 0);
									this.ItemHIBtn.Add(gameObject2.transform.GetChild(0).GetComponent<UIHIBtn>());
								}
								if (flag)
								{
									gameObject2.transform.GetChild(2).GetComponent<UIButtonHint>().enabled = true;
									gameObject2.transform.GetChild(2).GetComponent<UILEBtn>().m_Handler = this;
								}
								else
								{
									if (instance.CheckCanOpenDetail(this.tmpData.RankingPrize[num3].ItemID))
									{
										gameObject2.transform.GetChild(0).GetComponent<UIButtonHint>().enabled = false;
									}
									else
									{
										gameObject2.transform.GetChild(0).GetComponent<UIButtonHint>().enabled = true;
									}
									gameObject2.transform.GetChild(0).GetComponent<UIHIBtn>().m_Handler = this;
								}
								RectTransform component2 = gameObject2.GetComponent<RectTransform>();
								component2.localPosition += new Vector3((float)(91 * (num5 % 5)), -62f * (float)(num5 / 5) + num2, 0f);
								this.SItemCountText[k][l] = gameObject2.transform.GetChild(1).GetComponent<UIText>();
								this.SItemCountText[k][l].font = ttffont;
								this.ItemCountText[k][l] = this.SM.SpawnString(30);
								this.ItemCountText[k][l].IntToFormat((long)this.tmpData.RankingPrize[num3].Num, 1, false);
								if (this.GM.IsArabic)
								{
									this.ItemCountText[k][l].AppendFormat("{0}x");
								}
								else
								{
									this.ItemCountText[k][l].AppendFormat("x{0}");
								}
								this.SItemCountText[k][l].text = this.ItemCountText[k][l].ToString();
								num5++;
								num3++;
							}
						}
					}
					UnityEngine.Object.Destroy(child2.gameObject);
					if (num5 > 5)
					{
						float num6 = 62f * (float)(num5 / 5 - 1);
						if (num5 % 5 > 0)
						{
							num6 += 62f;
						}
						transform.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, num6);
						num += num6;
					}
				}
				else
				{
					if (num3 < this.tmpData.RankingPrize.Length && this.tmpData.RankingPrize[num3].ItemID == 0)
					{
						break;
					}
					num4++;
					GameObject gameObject3 = UnityEngine.Object.Instantiate(this.ContentT.GetChild(0).gameObject) as GameObject;
					gameObject3.SetActive(true);
					gameObject3.transform.SetParent(this.ContentT, false);
					Transform transform = gameObject3.transform;
					transform.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -num - 184f * (float)k);
					this.SGemCountText[k] = transform.GetChild(2).GetComponent<UIText>();
					this.SGemCountText[k].font = ttffont;
					this.GemCountText[k] = this.SM.SpawnString(30);
					if (this.tmpData.RankPrizeWorthData[k].Crystal == 0u)
					{
						transform.GetChild(1).gameObject.SetActive(false);
						transform.GetChild(2).gameObject.SetActive(false);
					}
					else
					{
						this.GemCountText[k].IntToFormat((long)((ulong)this.tmpData.RankPrizeWorthData[k].Crystal), 1, true);
						if (this.GM.IsArabic)
						{
							this.GemCountText[k].AppendFormat("{0}x");
						}
						else
						{
							this.GemCountText[k].AppendFormat("x{0}");
						}
						this.SGemCountText[k].text = this.GemCountText[k].ToString();
					}
					this.STitleText[k] = transform.GetChild(3).GetComponent<UIText>();
					this.STitleText[k].font = ttffont;
					this.TitleText[k] = this.SM.SpawnString(30);
					byte b3 = 1;
					byte b4 = 1;
					if (this.ActivityIndex == 206)
					{
						if (k <= 2)
						{
							transform.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(k);
						}
						else
						{
							transform.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(3);
						}
						this.TitleText[k].IntToFormat((long)(k + 1), 1, false);
						this.TitleText[k].AppendFormat(this.DM.mStringTable.GetStringByID(8150u));
					}
					else
					{
						if (k == 3)
						{
							b3 = 4;
							b4 = 10;
						}
						else if (k == 4)
						{
							b3 = 11;
							b4 = 30;
						}
						else if (k == 5)
						{
							b3 = 31;
							b4 = 50;
						}
						else if (k == 6)
						{
							b3 = 51;
							b4 = 100;
							this.TitleText[k].IntToFormat(51L, 1, false);
							this.TitleText[k].IntToFormat(100L, 1, false);
						}
						if (k <= 2)
						{
							transform.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(k);
							this.TitleText[k].IntToFormat((long)(k + 1), 1, false);
							this.TitleText[k].AppendFormat(this.DM.mStringTable.GetStringByID(8150u));
						}
						else
						{
							transform.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(3);
							this.TitleText[k].IntToFormat((long)b3, 1, false);
							this.TitleText[k].IntToFormat((long)b4, 1, false);
							this.TitleText[k].AppendFormat(this.DM.mStringTable.GetStringByID(8151u));
						}
					}
					this.STitleText[k].text = this.TitleText[k].ToString();
					this.STotalpriceText[k] = transform.GetChild(4).GetComponent<UIText>();
					this.STotalpriceText[k].font = ttffont;
					this.TotalpriceText[k] = this.SM.SpawnString(30);
					this.TotalpriceText[k].uLongToFormat((ulong)this.tmpData.RankPrizeWorthData[k].CrystalPrice, 1, true);
					this.TotalpriceText[k].AppendFormat(this.DM.mStringTable.GetStringByID(8122u));
					this.STotalpriceText[k].text = this.TotalpriceText[k].ToString();
					this.SNoPriceText[k] = transform.GetChild(5).GetComponent<UIText>();
					this.SNoPriceText[k].font = ttffont;
					this.NoPriceText[k] = this.SM.SpawnString(30);
					if (this.tmpData.RankPrizeWorthData[k].Priceless == 0)
					{
						transform.GetChild(5).gameObject.SetActive(false);
					}
					else
					{
						this.NoPriceText[k].uLongToFormat((ulong)this.tmpData.RankPrizeWorthData[k].Priceless, 1, false);
						this.NoPriceText[k].AppendFormat(this.DM.mStringTable.GetStringByID(8123u));
						this.SNoPriceText[k].text = this.NoPriceText[k].ToString();
					}
					int num5 = 0;
					Transform child2 = transform.GetChild(6);
					this.GM.InitianHeroItemImg(child2.GetChild(0), eHeroOrItem.Item, 1001, 0, 0, 0, false, true, true, false);
					child2.GetChild(2).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
					this.GM.InitLordEquipImg(child2.GetChild(2), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
					for (int m = 0; m < this.ItemCount[k]; m++)
					{
						Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpData.RankingPrize[num3].ItemID);
						if (recordByKey.EquipKind == 11 && recordByKey.PropertiesInfo[0].Propertieskey == 6)
						{
							num3++;
						}
						else
						{
							GameObject gameObject4 = UnityEngine.Object.Instantiate(child2.gameObject) as GameObject;
							gameObject4.SetActive(true);
							gameObject4.transform.SetParent(transform, false);
							bool flag2 = this.GM.IsLeadItem(recordByKey.EquipKind);
							if (flag2)
							{
								gameObject4.transform.GetChild(0).gameObject.SetActive(false);
								gameObject4.transform.GetChild(2).gameObject.SetActive(true);
								this.GM.ChangeLordEquipImg(gameObject4.transform.GetChild(2), this.tmpData.RankingPrize[num3].ItemID, this.tmpData.RankingPrize[num3].Rank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
							}
							else
							{
								this.GM.ChangeHeroItemImg(gameObject4.transform.GetChild(0), eHeroOrItem.Item, this.tmpData.RankingPrize[num3].ItemID, 0, this.tmpData.RankingPrize[num3].Rank, 0);
								this.ItemHIBtn.Add(gameObject4.transform.GetChild(0).GetComponent<UIHIBtn>());
							}
							if (flag2)
							{
								gameObject4.transform.GetChild(2).GetComponent<UIButtonHint>().enabled = true;
								gameObject4.transform.GetChild(2).GetComponent<UILEBtn>().m_Handler = this;
							}
							else
							{
								if (instance.CheckCanOpenDetail(this.tmpData.RankingPrize[num3].ItemID))
								{
									gameObject4.transform.GetChild(0).GetComponent<UIButtonHint>().enabled = false;
								}
								else
								{
									gameObject4.transform.GetChild(0).GetComponent<UIButtonHint>().enabled = true;
								}
								gameObject4.transform.GetChild(0).GetComponent<UIHIBtn>().m_Handler = this;
							}
							RectTransform component3 = gameObject4.GetComponent<RectTransform>();
							component3.localPosition += new Vector3((float)(91 * (num5 % 5)), -62f * (float)(num5 / 5), 0f);
							this.SItemCountText[k][m] = gameObject4.transform.GetChild(1).GetComponent<UIText>();
							this.SItemCountText[k][m].font = ttffont;
							this.ItemCountText[k][m] = this.SM.SpawnString(30);
							this.ItemCountText[k][m].IntToFormat((long)this.tmpData.RankingPrize[num3].Num, 1, false);
							if (this.GM.IsArabic)
							{
								this.ItemCountText[k][m].AppendFormat("{0}x");
							}
							else
							{
								this.ItemCountText[k][m].AppendFormat("x{0}");
							}
							this.SItemCountText[k][m].text = this.ItemCountText[k][m].ToString();
							num5++;
							num3++;
						}
					}
					UnityEngine.Object.Destroy(child2.gameObject);
					if (num5 > 5)
					{
						float num7 = 62f * (float)(num5 / 5 - 1);
						if (num5 % 5 > 0)
						{
							num7 += 62f;
						}
						transform.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, num7);
						num += num7;
					}
				}
			}
			if (this.ActivityIndex == 210)
			{
				this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(this.ContentT.GetComponent<RectTransform>().sizeDelta.x, num + 4f + (float)(3 * (num4 - 1)) + (float)num4 * (181f - num2));
			}
			else
			{
				this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(this.ContentT.GetComponent<RectTransform>().sizeDelta.x, num + 4f + (float)(3 * (num4 - 1)) + (float)num4 * 181f);
			}
			if (this.ActivityIndex == 210 && this.AM.AW_PrizeGroupID > 0)
			{
				UIButtonHint uibuttonHint = this.m_transform.GetChild(4).gameObject.AddComponent<UIButtonHint>();
				uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
				uibuttonHint.m_Handler = this;
				this.m_transform.GetChild(4).gameObject.SetActive(true);
			}
		}
		if (this.bPrize && this.ContentT != null)
		{
			if (this.AM.Act4arg2 == arg2)
			{
				this.ContentT.GetComponent<RectTransform>().anchoredPosition = this.AM.Act4Pos;
			}
			else
			{
				this.AM.Act4arg2 = arg2;
			}
		}
		this.GM.UpdateUI(EGUIWindow.Door, 1, 6);
	}

	// Token: 0x06000DA3 RID: 3491 RVA: 0x0015F190 File Offset: 0x0015D390
	public override void OnClose()
	{
		if (this.bPrize)
		{
			for (int i = 0; i < this.PrizeCount; i++)
			{
				this.SM.DeSpawnString(this.TitleText[i]);
				this.SM.DeSpawnString(this.GemCountText[i]);
				this.SM.DeSpawnString(this.TotalpriceText[i]);
				this.SM.DeSpawnString(this.NoPriceText[i]);
				for (int j = 0; j < this.ItemCount[i]; j++)
				{
					this.SM.DeSpawnString(this.ItemCountText[i][j]);
				}
			}
			if (this.ContentT != null)
			{
				this.AM.Act4Pos = this.ContentT.GetComponent<RectTransform>().anchoredPosition;
			}
		}
		else
		{
			this.SM.DeSpawnString(this.InfoStr);
		}
	}

	// Token: 0x06000DA4 RID: 3492 RVA: 0x0015F284 File Offset: 0x0015D484
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			if (!this.bPrize)
			{
				return;
			}
			if (this.tmpData.EventState == EActivityState.EAS_None)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door)
				{
					door.CloseMenu(false);
				}
			}
			else
			{
				ActivityManager.Instance.ChangeStateReOpenPrize(this.ActivityIndex);
			}
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				for (int i = 0; i < this.OutText.Length; i++)
				{
					if (this.OutText != null && this.OutText[i] != null && this.OutText[i].enabled)
					{
						this.OutText[i].enabled = false;
						this.OutText[i].enabled = true;
					}
				}
				if (!this.bPrize)
				{
					return;
				}
				for (int j = 0; j < this.ItemHIBtn.Count; j++)
				{
					this.ItemHIBtn[j].Refresh_FontTexture();
				}
				for (int k = 0; k < this.PrizeCount; k++)
				{
					if (this.STitleText != null && this.STitleText[k] != null && this.STitleText[k].enabled)
					{
						this.STitleText[k].enabled = false;
						this.STitleText[k].enabled = true;
					}
					if (this.SGemCountText != null && this.SGemCountText[k] != null && this.SGemCountText[k].enabled)
					{
						this.SGemCountText[k].enabled = false;
						this.SGemCountText[k].enabled = true;
					}
					if (this.STotalpriceText != null && this.STotalpriceText[k] != null && this.STotalpriceText[k].enabled)
					{
						this.STotalpriceText[k].enabled = false;
						this.STotalpriceText[k].enabled = true;
					}
					if (this.SNoPriceText != null && this.SNoPriceText[k] != null && this.SNoPriceText[k].enabled)
					{
						this.SNoPriceText[k].enabled = false;
						this.SNoPriceText[k].enabled = true;
					}
					if (this.ItemCount != null && this.SItemCountText != null)
					{
						for (int l = 0; l < this.ItemCount[k]; l++)
						{
							if (this.SItemCountText[k] != null && this.SItemCountText[k][l] != null && this.SItemCountText[k][l].enabled)
							{
								this.SItemCountText[k][l].enabled = false;
								this.SItemCountText[k][l].enabled = true;
							}
						}
					}
				}
			}
			break;
		}
	}

	// Token: 0x06000DA5 RID: 3493 RVA: 0x0015F588 File Offset: 0x0015D788
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			if (!this.bPrize)
			{
				return;
			}
			if ((int)this.ActivityIndex == arg2 && this.tmpData.EventState == EActivityState.EAS_Prepare)
			{
				ActivityManager.Instance.ChangeStateReOpenPrize(this.ActivityIndex);
			}
			break;
		case 2:
			if (!this.bPrize)
			{
				return;
			}
			if ((int)this.ActivityIndex == arg2)
			{
				ActivityManager.Instance.ChangeStateReOpenPrize(this.ActivityIndex);
			}
			break;
		case 3:
			if (!this.bPrize)
			{
				return;
			}
			if (this.ActivityIndex >= 211 && this.ActivityIndex <= 213 && this.tmpData.EventState == EActivityState.EAS_Prepare)
			{
				ActivityManager.Instance.ChangeStateReOpenPrize(this.ActivityIndex);
			}
			break;
		}
	}

	// Token: 0x06000DA6 RID: 3494 RVA: 0x0015F670 File Offset: 0x0015D870
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			if (sender.m_BtnID2 == 1)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door)
				{
					door.CloseMenu(false);
				}
			}
			else if (sender.m_BtnID2 == 2)
			{
			}
		}
	}

	// Token: 0x06000DA7 RID: 3495 RVA: 0x0015F6CC File Offset: 0x0015D8CC
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x06000DA8 RID: 3496 RVA: 0x0015F6D0 File Offset: 0x0015D8D0
	public void OnHIButtonClick(UIHIBtn sender)
	{
		MallManager.Instance.OpenDetail(sender.HIID);
	}

	// Token: 0x06000DA9 RID: 3497 RVA: 0x0015F6E4 File Offset: 0x0015D8E4
	public void OnButtonDown(UIButtonHint sender)
	{
		if (this.ActivityIndex == 210 && this.AM.AW_PrizeGroupID > 0)
		{
			CString cstring = StringManager.Instance.SpawnString(300);
			cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(17029u));
			cstring.AppendFormat(this.DM.mStringTable.GetStringByID(1003u));
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, cstring, Vector2.zero);
		}
	}

	// Token: 0x06000DAA RID: 3498 RVA: 0x0015F778 File Offset: 0x0015D978
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(sender);
	}

	// Token: 0x06000DAB RID: 3499 RVA: 0x0015F790 File Offset: 0x0015D990
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x04002C78 RID: 11384
	private const float ItemDeltaY = -62f;

	// Token: 0x04002C79 RID: 11385
	private const float ObjectY = 181f;

	// Token: 0x04002C7A RID: 11386
	private Transform m_transform;

	// Token: 0x04002C7B RID: 11387
	private Transform ContentT;

	// Token: 0x04002C7C RID: 11388
	private DataManager DM;

	// Token: 0x04002C7D RID: 11389
	private GUIManager GM;

	// Token: 0x04002C7E RID: 11390
	private StringManager SM;

	// Token: 0x04002C7F RID: 11391
	private ActivityManager AM;

	// Token: 0x04002C80 RID: 11392
	private CString[] TitleText;

	// Token: 0x04002C81 RID: 11393
	private CString[] GemCountText;

	// Token: 0x04002C82 RID: 11394
	private CString[] TotalpriceText;

	// Token: 0x04002C83 RID: 11395
	private CString[] NoPriceText;

	// Token: 0x04002C84 RID: 11396
	private int PrizeCount = 7;

	// Token: 0x04002C85 RID: 11397
	private int[] ItemCount;

	// Token: 0x04002C86 RID: 11398
	private CString[][] ItemCountText;

	// Token: 0x04002C87 RID: 11399
	private bool bPrize;

	// Token: 0x04002C88 RID: 11400
	private byte ActivityIndex;

	// Token: 0x04002C89 RID: 11401
	private ActivityDataType tmpData;

	// Token: 0x04002C8A RID: 11402
	private UIText[] OutText = new UIText[4];

	// Token: 0x04002C8B RID: 11403
	private UIText[] STitleText;

	// Token: 0x04002C8C RID: 11404
	private UIText[] SGemCountText;

	// Token: 0x04002C8D RID: 11405
	private UIText[] STotalpriceText;

	// Token: 0x04002C8E RID: 11406
	private UIText[] SNoPriceText;

	// Token: 0x04002C8F RID: 11407
	private UIText[][] SItemCountText;

	// Token: 0x04002C90 RID: 11408
	private List<UIHIBtn> ItemHIBtn = new List<UIHIBtn>();

	// Token: 0x04002C91 RID: 11409
	private CString InfoStr;
}
