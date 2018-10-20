using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using uTools;

// Token: 0x02000216 RID: 534
public class UISettlement : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x060009B6 RID: 2486 RVA: 0x000C96CC File Offset: 0x000C78CC
	public override void OnOpen(int arg1, int arg2)
	{
		this.GM.FindMenu(EGUIWindow.UI_Battle).gameObject.SetActive(false);
		Time.timeScale = 1f;
		this.GM.CloseABColor();
		this.m_transform = base.transform;
		Font ttffont = this.GM.GetTTFFont();
		Camera.main.cullingMask &= -2;
		Camera.main.orthographic = true;
		this.GM.SetCanvasChanged();
		this.SArray = this.m_transform.GetComponent<UISpritesArray>();
		if (arg1 == 1)
		{
			this.OpenKind = (int)this.AM.BattleResult;
			this.bArena = true;
		}
		else if (arg1 == 2)
		{
			this.OpenKind = (int)this.DM.lastBattleResult;
			this.bChallenge = true;
		}
		else
		{
			this.OpenKind = (int)this.DM.lastBattleResult;
		}
		this.bSendServer = (arg2 == 1);
		if (this.bChallenge)
		{
			byte b = this.DM.BattleFailureIndex;
			this.ConditionKey = this.DM.BattleConditionKey;
			this.m_transform.GetChild(9).gameObject.SetActive(false);
			this.m_transform.GetChild(10).gameObject.SetActive(false);
			this.m_transform.GetChild(11).gameObject.SetActive(false);
			int num = 15;
			for (int i = num; i <= 21; i++)
			{
				this.m_transform.GetChild(i).gameObject.SetActive(false);
			}
			this.m_transform.GetChild(38).gameObject.SetActive(false);
			this.m_transform.GetChild(40).gameObject.SetActive(false);
			this.m_transform.GetChild(41).gameObject.SetActive(false);
			this.m_transform.GetChild(42).gameObject.SetActive(false);
			this.m_transform.GetChild(65).gameObject.SetActive(false);
			this.m_transform.GetChild(66).gameObject.SetActive(false);
			this.m_transform.GetChild(67).gameObject.SetActive(false);
			this.m_transform.GetChild(28).gameObject.SetActive(false);
			if (this.OpenKind == 0)
			{
				if (b == 0)
				{
					this.m_transform.GetChild(29).GetComponent<UIButton>().m_Handler = this;
					this.m_transform.GetChild(9).gameObject.SetActive(false);
					this.m_transform.GetChild(10).gameObject.SetActive(false);
					this.m_transform.GetChild(11).gameObject.SetActive(false);
					num = 15;
					for (int j = num; j <= 21; j++)
					{
						this.m_transform.GetChild(j).gameObject.SetActive(false);
					}
					this.m_transform.GetChild(28).gameObject.SetActive(false);
					this.m_transform.GetChild(40).gameObject.SetActive(false);
					this.m_transform.GetChild(41).gameObject.SetActive(false);
					this.m_transform.GetChild(42).gameObject.SetActive(false);
					this.m_transform.GetChild(8).gameObject.SetActive(false);
					this.m_transform.GetChild(37).gameObject.SetActive(false);
					this.m_transform.GetChild(30).GetComponent<Image>().sprite = this.SArray.m_Sprites[1];
					this.m_transform.GetChild(30).GetComponent<UIButton>().m_Handler = this;
					num = 3;
					for (int k = num; k <= 7; k++)
					{
						this.m_transform.GetChild(k).GetComponent<UISpritesArray>().SetSpriteIndex(1);
					}
					Transform child = this.m_transform.GetChild(58);
					child.gameObject.SetActive(true);
					child.GetChild(6).GetComponent<UIButton>().m_Handler = this;
					this.RBText[0] = child.GetChild(8).GetComponent<UIText>();
					if (this.bArena)
					{
						this.RBText[0].text = this.DM.mStringTable.GetStringByID(9150u);
					}
					else
					{
						this.RBText[0].text = this.DM.mStringTable.GetStringByID(51u);
					}
					this.RBText[0].font = ttffont;
					this.LightT = child.GetChild(7);
					ushort num2 = DataManager.StageDataController.StageRecord[0];
					this.RandomList[0] = 4;
					this.RandomList[1] = 5;
					this.RandomList[2] = 7;
					this.RandomList[3] = 8;
					this.RandomIndex = this.RandomList[UnityEngine.Random.Range(0, 4)];
					if (this.RandomIndex < this.TipTotalCount)
					{
						child.GetChild(3).GetComponent<UISpritesArray>().SetSpriteIndex((this.DM.UserLanguage != GameLanguage.GL_Chs) ? this.RandomIndex : (this.RandomIndex + this.TipTotalCount));
						child.GetChild(3).GetComponent<Image>().SetNativeSize();
						if (this.GM.IsArabic)
						{
							child.GetChild(3).localScale = new Vector3(-1f, 1f, 1f);
						}
						this.RBText[1] = child.GetChild(4).GetComponent<UIText>();
						this.RBText[1].text = this.DM.mStringTable.GetStringByID((uint)this.TipTitleID[this.RandomIndex]);
						this.RBText[1].font = ttffont;
						this.RBText[2] = child.GetChild(5).GetComponent<UIText>();
						this.RBText[2].text = this.DM.mStringTable.GetStringByID((uint)this.TipID[this.RandomIndex]);
						this.RBText[2].font = ttffont;
						if (this.RandomIndex >= 5)
						{
							child.GetChild(6).gameObject.SetActive(false);
						}
					}
				}
				else
				{
					this.m_transform.GetChild(29).GetComponent<UIButton>().m_Handler = this;
					this.m_transform.GetChild(8).gameObject.SetActive(false);
					this.m_transform.GetChild(37).gameObject.SetActive(false);
					this.m_transform.GetChild(30).GetComponent<Image>().sprite = this.SArray.m_Sprites[1];
					this.m_transform.GetChild(30).GetComponent<UIButton>().m_Handler = this;
					num = 3;
					for (int l = num; l <= 7; l++)
					{
						this.m_transform.GetChild(l).GetComponent<UISpritesArray>().SetSpriteIndex(1);
					}
					Transform child = this.m_transform.GetChild(58);
					child.gameObject.SetActive(true);
					child.GetChild(3).gameObject.SetActive(false);
					child.GetChild(4).gameObject.SetActive(false);
					child.GetChild(5).gameObject.SetActive(false);
					child.GetChild(6).gameObject.SetActive(false);
					this.RBText[0] = child.GetChild(8).GetComponent<UIText>();
					this.RBText[0].text = this.DM.mStringTable.GetStringByID(51u);
					this.RBText[0].font = ttffont;
					this.LightT = child.GetChild(7);
					this.m_transform.GetChild(70).gameObject.SetActive(true);
					if (this.GM.IsArabic)
					{
						this.m_transform.GetChild(70).localScale = new Vector3(-1f, 1f, 1f);
					}
					Image component = this.m_transform.GetChild(70).GetChild(0).GetComponent<Image>();
					this.m_transform.GetChild(71).gameObject.SetActive(true);
					this.RBText[1] = this.m_transform.GetChild(71).GetChild(0).GetComponent<UIText>();
					this.RBText[1].font = ttffont;
					this.RBText[1].text = this.DM.mStringTable.GetStringByID(12055u);
					bool flag = false;
					this.ConditionStr = StringManager.Instance.SpawnString(300);
					if (b != 0)
					{
						b -= 1;
						StageConditionData recordByKey = this.DS.StageConditionDataTable.GetRecordByKey(this.ConditionKey);
						if (b < 8)
						{
							this.DS.GetStageConditionString(this.ConditionStr, recordByKey.ConditionArray[(int)b].ConditionID, recordByKey.ConditionArray[(int)b].FactorA, recordByKey.ConditionArray[(int)b].FactorB, this.ConditionKey);
							component.sprite = this.DS.GetStageConditionSprite(recordByKey.ConditionArray[(int)b].ConditionID, recordByKey.ConditionArray[(int)b].FactorA, recordByKey.ConditionArray[(int)b].FactorB);
							component.material = this.DS.GetStageConditionMaterial(recordByKey.ConditionArray[(int)b].ConditionID);
							flag = true;
						}
					}
					if (!flag)
					{
						this.ConditionStr.Append(this.DM.mStringTable.GetStringByID(13516u));
						component.sprite = this.DS.GetStageConditionSprite(byte.MaxValue, 0, 0);
						component.material = this.DS.GetStageConditionMaterial(byte.MaxValue);
					}
					this.m_transform.GetChild(72).gameObject.SetActive(true);
					this.RBText[2] = this.m_transform.GetChild(72).GetComponent<UIText>();
					this.RBText[2].font = ttffont;
					this.RBText[2].text = this.ConditionStr.ToString();
					if (GameConstants.IsBigStyle())
					{
						this.RBText[2].resizeTextMinSize = 10;
						this.RBText[2].resizeTextMaxSize = 32;
					}
					else
					{
						this.RBText[2].resizeTextMinSize = 8;
						this.RBText[2].resizeTextMaxSize = 22;
					}
				}
				AudioManager.Instance.LoadAndPlayBGM(BGMType.WarDefeat, 0, false);
			}
			else
			{
				this.GM.UIPointID = 0;
				this.GM.UINodus = 0;
				this.m_transform.GetChild(29).gameObject.SetActive(false);
				this.m_transform.GetChild(30).GetComponent<Image>().sprite = this.SArray.m_Sprites[1];
				this.m_transform.GetChild(30).GetComponent<UIButton>().m_Handler = this;
				this.m_transform.GetChild(37).gameObject.SetActive(true);
				this.RBText[4] = this.m_transform.GetChild(37).GetComponent<UIText>();
				this.RBText[4].text = this.DM.mStringTable.GetStringByID(50u);
				this.RBText[4].font = ttffont;
				this.LightT = this.m_transform.GetChild(8);
				this.HinString = StringManager.Instance.SpawnString(1024);
				for (int m = 0; m < 8; m++)
				{
					this.ConditionRC[m] = (RectTransform)this.m_transform.GetChild(73 + m);
					this.ConditionBackImg[m] = this.m_transform.GetChild(73 + m).GetComponent<Image>();
					this.ConditionBtn[m] = this.m_transform.GetChild(73 + m).GetChild(0).GetComponent<UIButton>();
					this.ConditionBtn[m].m_BtnID1 = 10;
					this.ConditionBtn[m].m_Handler = this;
					UIButtonHint uibuttonHint = this.ConditionBtn[m].gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
					uibuttonHint.m_DownUpHandler = this;
					this.ConditionImg[m] = this.m_transform.GetChild(73 + m).GetChild(0).GetComponent<Image>();
					this.ConditionCheckImg[m] = this.m_transform.GetChild(73 + m).GetChild(1).GetComponent<Image>();
					this.ConditionCheckImg[m].enabled = false;
					if (this.GM.IsArabic)
					{
						this.ConditionCheckImg[m].gameObject.AddComponent<ArabicItemTextureRot>();
					}
				}
				int num3 = 0;
				StageConditionData recordByKey2 = this.DS.StageConditionDataTable.GetRecordByKey(this.ConditionKey);
				for (int n = 0; n < 8; n++)
				{
					if (recordByKey2.ConditionArray[n].ConditionID > 0)
					{
						this.ConditionImg[n].sprite = this.DS.GetStageConditionSprite(recordByKey2.ConditionArray[n].ConditionID, recordByKey2.ConditionArray[n].FactorA, recordByKey2.ConditionArray[n].FactorB);
						this.ConditionImg[n].material = this.DS.GetStageConditionMaterial(recordByKey2.ConditionArray[n].ConditionID);
						this.ConditionImg[n].color = new Color(1f, 1f, 1f, 0f);
						this.ConditionBackImg[n].color = new Color(1f, 1f, 1f, 0f);
						this.ConditionBtn[n].m_BtnID2 = (int)recordByKey2.ConditionArray[n].ConditionID;
						this.ConditionBtn[n].m_BtnID3 = (int)recordByKey2.ConditionArray[n].FactorA;
						this.ConditionBtn[n].m_BtnID4 = (int)recordByKey2.ConditionArray[n].FactorB;
						num3++;
					}
				}
				if (num3 < 8)
				{
					this.ConditionImg[num3].sprite = this.DS.GetStageConditionSprite(byte.MaxValue, 0, 0);
					this.ConditionImg[num3].material = this.DS.GetStageConditionMaterial(byte.MaxValue);
					this.ConditionImg[num3].color = new Color(1f, 1f, 1f, 0f);
					this.ConditionBackImg[num3].color = new Color(1f, 1f, 1f, 0f);
					this.ConditionBtn[num3].m_BtnID2 = 255;
					num3++;
				}
				this.ConditionCount = num3;
				if (this.ConditionCount == 1)
				{
					this.ConditionRC[0].anchoredPosition = new Vector2(0f, this.ConditionRC[0].anchoredPosition.y);
					this.ConditionRC[0].gameObject.SetActive(true);
				}
				else
				{
					float num4 = 86f;
					float num5 = 20f;
					float num6 = -(((float)this.ConditionCount * num4 + (float)(this.ConditionCount - 1) * num5) / 2f) + num4 / 2f;
					for (int num7 = 0; num7 < this.ConditionCount; num7++)
					{
						this.ConditionRC[num7].anchoredPosition = new Vector2(num6, this.MoveBeginPos);
						num6 += num4 + num5;
						this.ConditionRC[num7].gameObject.SetActive(true);
					}
				}
				this.HeroCount = this.DM.heroCount;
				this.PlayIndex = 0;
				this.PlayTime = 0f;
				this.NowMoveIndex = 0;
				this.m_transform.GetChild(30).gameObject.SetActive(false);
				AudioManager.Instance.LoadAndPlayBGM(BGMType.WarVictory, 0, false);
			}
		}
		else
		{
			if (this.OpenKind == 0)
			{
				this.m_transform.GetChild(9).gameObject.SetActive(false);
				this.m_transform.GetChild(10).gameObject.SetActive(false);
				this.m_transform.GetChild(11).gameObject.SetActive(false);
				int num = 15;
				for (int num8 = num; num8 <= 21; num8++)
				{
					this.m_transform.GetChild(num8).gameObject.SetActive(false);
				}
				this.m_transform.GetChild(28).gameObject.SetActive(false);
				this.m_transform.GetChild(29).gameObject.SetActive(false);
				this.m_transform.GetChild(40).gameObject.SetActive(false);
				this.m_transform.GetChild(41).gameObject.SetActive(false);
				this.m_transform.GetChild(42).gameObject.SetActive(false);
				this.m_transform.GetChild(8).gameObject.SetActive(false);
				this.m_transform.GetChild(37).gameObject.SetActive(false);
				this.m_transform.GetChild(30).GetComponent<Image>().sprite = this.SArray.m_Sprites[1];
				this.m_transform.GetChild(30).GetComponent<UIButton>().m_Handler = this;
				num = 3;
				for (int num9 = num; num9 <= 7; num9++)
				{
					this.m_transform.GetChild(num9).GetComponent<UISpritesArray>().SetSpriteIndex(1);
				}
				Transform child = this.m_transform.GetChild(58);
				child.gameObject.SetActive(true);
				child.GetChild(6).GetComponent<UIButton>().m_Handler = this;
				this.RBText[0] = child.GetChild(8).GetComponent<UIText>();
				if (this.bArena)
				{
					this.RBText[0].text = this.DM.mStringTable.GetStringByID(9150u);
				}
				else
				{
					this.RBText[0].text = this.DM.mStringTable.GetStringByID(51u);
				}
				this.RBText[0].font = ttffont;
				this.LightT = child.GetChild(7);
				if (this.bArena)
				{
					this.RandomIndex = 5;
				}
				else
				{
					ushort num10 = DataManager.StageDataController.StageRecord[0];
					if (num10 >= 18)
					{
						this.RandomList[this.TipCount] = 2;
						this.TipCount++;
						this.RandomList[this.TipCount] = 3;
						this.TipCount++;
						this.RandomList[this.TipCount] = 7;
						this.TipCount++;
					}
					if (num10 >= 36)
					{
						this.RandomList[this.TipCount] = 4;
						this.TipCount++;
						this.RandomList[this.TipCount] = 8;
						this.TipCount++;
					}
					if (num10 >= 54)
					{
						this.RandomList[this.TipCount] = 5;
						this.TipCount++;
					}
					if (this.DM.RoleAttr.Level >= 15)
					{
						this.RandomList[this.TipCount] = 6;
						this.TipCount++;
					}
					this.RandomIndex = this.RandomList[UnityEngine.Random.Range(1, this.TipCount)];
				}
				if (this.RandomIndex < this.TipTotalCount)
				{
					child.GetChild(3).GetComponent<UISpritesArray>().SetSpriteIndex((this.DM.UserLanguage != GameLanguage.GL_Chs) ? this.RandomIndex : (this.RandomIndex + this.TipTotalCount));
					child.GetChild(3).GetComponent<Image>().SetNativeSize();
					if (this.GM.IsArabic)
					{
						child.GetChild(3).localScale = new Vector3(-1f, 1f, 1f);
					}
					this.RBText[1] = child.GetChild(4).GetComponent<UIText>();
					this.RBText[1].text = this.DM.mStringTable.GetStringByID((uint)this.TipTitleID[this.RandomIndex]);
					this.RBText[1].font = ttffont;
					this.RBText[2] = child.GetChild(5).GetComponent<UIText>();
					this.RBText[2].text = this.DM.mStringTable.GetStringByID((uint)this.TipID[this.RandomIndex]);
					this.RBText[2].font = ttffont;
					if (this.RandomIndex >= 5)
					{
						child.GetChild(6).gameObject.SetActive(false);
					}
				}
				AudioManager.Instance.LoadAndPlayBGM(BGMType.WarDefeat, 0, false);
			}
			else
			{
				this.PlayIndex = 0;
				int num = 15;
				for (int num11 = num; num11 <= 21; num11++)
				{
					this.m_transform.GetChild(num11).gameObject.SetActive(false);
				}
				this.m_transform.GetChild(38).gameObject.SetActive(false);
				this.m_transform.GetChild(40).gameObject.SetActive(false);
				this.m_transform.GetChild(41).gameObject.SetActive(false);
				this.m_transform.GetChild(42).gameObject.SetActive(false);
				this.m_transform.GetChild(30).gameObject.SetActive(false);
				if (this.bArena)
				{
					this.bHideItem = true;
					this.m_transform.GetChild(67).gameObject.SetActive(false);
					num = 15;
					for (int num12 = num; num12 < num + 4; num12++)
					{
						this.m_transform.GetChild(num12).gameObject.SetActive(false);
					}
					Vector2 b2 = new Vector2(0f, -76f);
					num = 31;
					for (int num13 = num; num13 < num + 5; num13++)
					{
						this.m_transform.GetChild(num13).GetComponent<RectTransform>().anchoredPosition += b2;
					}
					num = 43;
					for (int num14 = num; num14 < num + 5; num14++)
					{
						this.m_transform.GetChild(num14).GetComponent<RectTransform>().anchoredPosition += b2;
					}
					num = 48;
					for (int num15 = num; num15 < num + 5; num15++)
					{
						this.m_transform.GetChild(num15).GetComponent<RectTransform>().anchoredPosition += b2;
					}
					num = 53;
					for (int num16 = num; num16 < num + 5; num16++)
					{
						this.m_transform.GetChild(num16).GetComponent<RectTransform>().anchoredPosition += b2;
					}
					num = 59;
					for (int num17 = num; num17 < num + 5; num17++)
					{
						this.m_transform.GetChild(num17).GetComponent<RectTransform>().anchoredPosition += b2;
					}
				}
				this.m_transform.GetChild(28).gameObject.SetActive(false);
				this.m_transform.GetChild(29).gameObject.SetActive(false);
				this.m_transform.GetChild(28).GetComponent<UIButton>().m_Handler = this;
				this.m_transform.GetChild(29).GetComponent<UIButton>().m_Handler = this;
				this.m_transform.GetChild(30).GetComponent<Image>().sprite = this.SArray.m_Sprites[1];
				this.m_transform.GetChild(30).GetComponent<UIButton>().m_Handler = this;
				this.m_transform.GetChild(1).gameObject.SetActive(true);
				this.RBText[0] = this.m_transform.GetChild(40).GetComponent<UIText>();
				this.RBText[0].text = this.DM.RoleAttr.Level.ToString();
				this.RBText[0].font = ttffont;
				this.GetEXPStr = StringManager.Instance.SpawnString(30);
				this.GetEXPStr.IntToFormat((long)((ulong)this.GetExp(false, this.DM.RoleAttr.Level, this.DM.RoleAttr.Exp, this.DM.KingOldLv, this.DM.KingOldExp)), 1, true);
				this.GetEXPStr.AppendFormat(this.DM.mStringTable.GetStringByID(54u));
				this.RBText[1] = this.m_transform.GetChild(41).GetComponent<UIText>();
				this.RBText[1].text = this.GetEXPStr.ToString();
				this.RBText[1].font = ttffont;
				this.RBText[1].resizeTextForBestFit = true;
				this.RBText[1].resizeTextMaxSize = 26;
				this.GetMoneyStr = StringManager.Instance.SpawnString(30);
				this.GetMoneyStr.IntToFormat((long)((ulong)this.DM.RWMoney), 1, true);
				this.GetMoneyStr.AppendFormat(this.DM.mStringTable.GetStringByID(54u));
				this.RBText[2] = this.m_transform.GetChild(42).GetComponent<UIText>();
				this.RBText[2].text = this.GetMoneyStr.ToString();
				this.RBText[2].font = ttffont;
				this.RBText[2].resizeTextForBestFit = true;
				this.RBText[2].resizeTextMaxSize = 26;
				this.RBText[3] = this.m_transform.GetChild(38).GetComponent<UIText>();
				this.RBText[3].text = this.DM.mStringTable.GetStringByID(323u);
				this.RBText[3].font = ttffont;
				this.RBText[4] = this.m_transform.GetChild(37).GetComponent<UIText>();
				this.RBText[4].text = this.DM.mStringTable.GetStringByID(50u);
				this.RBText[4].font = ttffont;
				this.m_HintBox = this.m_transform.GetChild(68).GetComponent<Image>();
				this.m_HintBox.rectTransform.sizeDelta = new Vector2(350f, 60f);
				this.m_HintText = this.m_transform.GetChild(68).GetChild(0).GetComponent<UIText>();
				this.m_HintText.font = this.GM.GetTTFFont();
				this.m_HintText.horizontalOverflow = HorizontalWrapMode.Wrap;
				UIButton component2 = this.m_transform.GetChild(65).GetComponent<UIButton>();
				this.HintRC[0] = this.m_transform.GetChild(65).GetComponent<RectTransform>();
				UIButtonHint uibuttonHint2 = component2.gameObject.AddComponent<UIButtonHint>();
				uibuttonHint2.m_eHint = EUIButtonHint.DownUpHandler;
				uibuttonHint2.m_Handler = this;
				uibuttonHint2.ControlFadeOut = this.m_HintBox.gameObject;
				component2 = this.m_transform.GetChild(66).GetComponent<UIButton>();
				this.HintRC[1] = this.m_transform.GetChild(66).GetComponent<RectTransform>();
				uibuttonHint2 = component2.gameObject.AddComponent<UIButtonHint>();
				uibuttonHint2.m_eHint = EUIButtonHint.DownUpHandler;
				uibuttonHint2.m_Handler = this;
				uibuttonHint2.ControlFadeOut = this.m_HintBox.gameObject;
				component2 = this.m_transform.GetChild(67).GetComponent<UIButton>();
				this.HintRC[2] = this.m_transform.GetChild(67).GetComponent<RectTransform>();
				uibuttonHint2 = component2.gameObject.AddComponent<UIButtonHint>();
				uibuttonHint2.m_eHint = EUIButtonHint.DownUpHandler;
				uibuttonHint2.m_Handler = this;
				uibuttonHint2.ControlFadeOut = this.m_HintBox.gameObject;
				if (this.DM.UserLanguage == GameLanguage.GL_Chs)
				{
					this.m_transform.GetChild(19).GetComponent<UISpritesArray>().SetSpriteIndex(0);
					this.m_transform.GetChild(20).GetComponent<UISpritesArray>().SetSpriteIndex(0);
				}
				if (this.GM.IsArabic)
				{
					RectTransform rectTransform = (RectTransform)this.m_transform.GetChild(19);
					rectTransform.localScale = new Vector3(-1f, 1f, 1f);
					rectTransform.anchoredPosition += new Vector2(rectTransform.sizeDelta.x, 0f);
					rectTransform = (RectTransform)this.m_transform.GetChild(20);
					rectTransform.localScale = new Vector3(-1f, 1f, 1f);
					rectTransform.anchoredPosition += new Vector2(rectTransform.sizeDelta.x, 0f);
				}
				this.LightT = this.m_transform.GetChild(8);
			}
			if (this.bHideItem)
			{
				for (int num18 = 0; num18 < 5; num18++)
				{
					if (this.AM.ArenaPlayingData.MyHeroData[num18].ID > 0)
					{
						this.HeroCount += 1;
					}
				}
			}
			else
			{
				this.HeroCount = this.DM.heroCount;
			}
		}
		if (this.GM.bOpenOnIPhoneX)
		{
			((RectTransform)this.m_transform).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0f);
			((RectTransform)this.m_transform).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0f);
		}
		this.GM.HideChatBox();
	}

	// Token: 0x060009B7 RID: 2487 RVA: 0x000CB470 File Offset: 0x000C9670
	public override void OnClose()
	{
		Camera.main.cullingMask |= 1;
		Camera.main.orthographic = false;
		this.GM.SetCanvasChanged();
		if (this.RankStr != null)
		{
			StringManager.Instance.DeSpawnString(this.RankStr);
		}
		if (this.GetEXPStr != null)
		{
			StringManager.Instance.DeSpawnString(this.GetEXPStr);
		}
		if (this.GetMoneyStr != null)
		{
			StringManager.Instance.DeSpawnString(this.GetMoneyStr);
		}
		for (int i = 0; i < this.LVStr.Length; i++)
		{
			if (this.LVStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.LVStr[i]);
			}
		}
		for (int j = 0; j < this.ExpStr.Length; j++)
		{
			if (this.ExpStr[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.ExpStr[j]);
			}
		}
		if (this.ConditionStr != null)
		{
			StringManager.Instance.DeSpawnString(this.ConditionStr);
		}
		if (DataManager.StageDataController._stageMode == StageMode.Dare)
		{
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_ChallegeTreasure);
		}
		if (this.HinString != null)
		{
			StringManager.Instance.DeSpawnString(this.HinString);
			this.HinString = null;
		}
	}

	// Token: 0x060009B8 RID: 2488 RVA: 0x000CB5CC File Offset: 0x000C97CC
	public void onFinisf1()
	{
		AudioManager.Instance.PlayUISFX(UIKind.StartThree_One);
	}

	// Token: 0x060009B9 RID: 2489 RVA: 0x000CB5E0 File Offset: 0x000C97E0
	public void onFinisf2()
	{
		AudioManager.Instance.PlayUISFX(UIKind.StartThree_Two);
	}

	// Token: 0x060009BA RID: 2490 RVA: 0x000CB5F4 File Offset: 0x000C97F4
	public void onFinisf3()
	{
		AudioManager.Instance.PlayUISFX(UIKind.StartThree_Three);
	}

	// Token: 0x060009BB RID: 2491 RVA: 0x000CB608 File Offset: 0x000C9808
	private void PlayStar(int tmpIndex)
	{
		this.m_transform.GetChild(tmpIndex).gameObject.SetActive(true);
		uTweenScale uTweenScale = uTweenScale.Begin(this.m_transform.GetChild(tmpIndex).gameObject, new Vector3(2.7f, 2.7f, 2.7f), Vector3.one, 0.3f, 0f);
		if (uTweenScale)
		{
			uTweenScale.easeType = EaseType.easeInQuart;
			if (tmpIndex == 12)
			{
				uTweenScale.onFinished = new UnityEvent();
				uTweenScale.onFinished.AddListener(delegate
				{
					this.onFinisf1();
				});
			}
			else if (tmpIndex == 13)
			{
				uTweenScale.onFinished = new UnityEvent();
				uTweenScale.onFinished.AddListener(delegate
				{
					this.onFinisf2();
				});
			}
			else if (tmpIndex == 14)
			{
				uTweenScale.onFinished = new UnityEvent();
				uTweenScale.onFinished.AddListener(delegate
				{
					this.onFinisf3();
				});
			}
		}
	}

	// Token: 0x060009BC RID: 2492 RVA: 0x000CB700 File Offset: 0x000C9900
	private void Update()
	{
		if (this.LightT != null)
		{
			this.LightT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		if (this.bChallenge)
		{
			if (this.OpenKind != 0)
			{
				if (this.PlayIndex != -1)
				{
					if (this.PlayIndex == 0)
					{
						this.PlayTime += Time.smoothDeltaTime;
						if (this.PlayTime >= 0.2f)
						{
							this.PlayTime = 0f;
							this.PlayIndex++;
							return;
						}
						return;
					}
					else if (this.PlayIndex == 1)
					{
						if (this.NowMoveIndex >= 8)
						{
							this.PlayTime = 0f;
							this.PlayIndex++;
							return;
						}
						if (this.ConditionRC[0] == null)
						{
							return;
						}
						float t = this.PlayTime / this.PlayTotalTime;
						this.ConditionRC[this.NowMoveIndex].anchoredPosition = new Vector2(this.ConditionRC[this.NowMoveIndex].anchoredPosition.x, Mathf.Lerp(this.MoveBeginPos, this.MoveEndPos, t));
						Color color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, t));
						this.ConditionBackImg[this.NowMoveIndex].color = color;
						this.ConditionImg[this.NowMoveIndex].color = color;
						this.PlayTime += Time.smoothDeltaTime;
						if (this.PlayTime >= this.PlayTotalTime)
						{
							AudioManager.Instance.PlayUISFX(UIKind.UIPrompt);
							this.ConditionRC[this.NowMoveIndex].anchoredPosition = new Vector2(this.ConditionRC[this.NowMoveIndex].anchoredPosition.x, this.MoveEndPos);
							this.ConditionBackImg[this.NowMoveIndex].color = Color.white;
							this.ConditionImg[this.NowMoveIndex].color = Color.white;
							this.ConditionCheckImg[this.NowMoveIndex].enabled = true;
							this.NowMoveIndex++;
							if (this.NowMoveIndex >= this.ConditionCount)
							{
								this.PlayTime = 0f;
								this.PlayIndex++;
								return;
							}
							this.PlayTime = 0f;
						}
						return;
					}
					else
					{
						if (this.PlayIndex == 2)
						{
							for (byte b = 0; b < this.HeroCount; b += 1)
							{
								ushort heroID = this.DM.heroBattleData[(int)b].HeroID;
								if (this.DM.curHeroData.ContainsKey((uint)heroID))
								{
									Hero recordByKey = this.DM.HeroTable.GetRecordByKey(heroID);
									CString cstring = StringManager.Instance.StaticString1024();
									cstring.ClearString();
									cstring.IntToFormat((long)recordByKey.Modle, 5, false);
									cstring.AppendFormat("Role/hero_{0}");
									this.AB[(int)b] = AssetManager.GetAssetBundle(cstring, out this.AssetKey[(int)b]);
									this.AR[(int)b] = this.AB[(int)b].LoadAsync("m", typeof(GameObject));
									this.bABInitial[(int)b] = false;
								}
							}
							this.PlayIndex++;
							return;
						}
						if (this.PlayIndex == 3)
						{
							if (this.LoadHeroCount < this.HeroCount)
							{
								int num = 59;
								for (byte b2 = 0; b2 < this.HeroCount; b2 += 1)
								{
									if (!this.bABInitial[(int)b2] && this.AR[(int)b2] != null && this.AR[(int)b2].isDone)
									{
										ushort heroID2 = this.DM.heroBattleData[(int)b2].HeroID;
										Hero recordByKey2 = this.DM.HeroTable.GetRecordByKey(heroID2);
										GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.AR[(int)b2].asset);
										gameObject.transform.SetParent(this.m_transform.GetChild(num + (int)b2), false);
										gameObject.transform.localPosition = Vector3.zero;
										gameObject.transform.localRotation = new Quaternion(0f, -180f, 0f, 0f);
										float num2 = 125f * (float)recordByKey2.Scale * 0.01f;
										gameObject.transform.localScale = new Vector3(num2, num2, num2);
										this.GM.SetLayer(gameObject, 5);
										if (gameObject != null)
										{
											Animation component = gameObject.GetComponent<Animation>();
											component.wrapMode = WrapMode.Loop;
											component.Play("victory");
											gameObject.GetComponentInChildren<SkinnedMeshRenderer>().useLightProbes = false;
											this.PlayerGO[(int)b2] = gameObject;
										}
										this.bABInitial[(int)b2] = true;
										this.LoadHeroCount += 1;
									}
								}
							}
							else
							{
								this.PlayIndex++;
							}
							return;
						}
						if (this.PlayIndex != 4)
						{
							this.PlayIndex = -1;
							return;
						}
						this.PlayTime += Time.smoothDeltaTime;
						if (this.PlayTime >= 1f)
						{
							this.PlayTime = 0f;
							this.PlayIndex++;
							return;
						}
						return;
					}
				}
				else if (this.NowStep == 0)
				{
					this.NowStep = 1;
					this.m_transform.GetChild(30).gameObject.SetActive(true);
					this.GM.OpenChallegeRewardUI();
				}
			}
		}
		else
		{
			if (this.OpenKind != 0 && this.PlayIndex != -1)
			{
				this.PlayTime += Time.smoothDeltaTime;
				if (this.PlayTime >= this.PlayWaitTime)
				{
					this.PlayTime = 0f;
					if (this.PlayIndex == 0)
					{
						this.PlayWaitTime = 0.1f;
						this.m_transform.GetChild(37).gameObject.SetActive(true);
						this.PlayIndex++;
						return;
					}
					if (this.PlayIndex == 1)
					{
						this.PlayWaitTime = 0.2f;
						this.PlayIndex++;
						return;
					}
					if (this.PlayIndex == 3 || this.PlayIndex == 5)
					{
						this.PlayWaitTime = 0.05f;
						this.PlayIndex++;
						return;
					}
					if (this.PlayIndex == 2)
					{
						if (this.OpenKind == 1)
						{
							this.PlayIndex = 7;
							this.PlayWaitTime = 0.35f;
						}
						else
						{
							this.PlayIndex++;
							this.PlayWaitTime = 0.3f;
						}
						this.PlayStar(12);
						return;
					}
					if (this.PlayIndex == 4)
					{
						if (this.OpenKind == 2)
						{
							this.PlayIndex = 7;
							this.PlayWaitTime = 0.35f;
						}
						else
						{
							this.PlayIndex++;
							this.PlayWaitTime = 0.3f;
						}
						this.PlayStar(13);
						return;
					}
					if (this.PlayIndex == 6)
					{
						this.PlayIndex = 7;
						this.PlayWaitTime = 0.35f;
						this.PlayStar(14);
						return;
					}
					if (this.PlayIndex == 7)
					{
						AudioManager.Instance.LoadAndPlayBGM(BGMType.WarVictory, 0, false);
						this.PlayWaitTime = 0.2f;
						this.PlayIndex++;
						return;
					}
					Font ttffont = this.GM.GetTTFFont();
					if (!this.bHideItem)
					{
						int num3 = 15;
						for (int i = num3; i <= 21; i++)
						{
							this.m_transform.GetChild(i).gameObject.SetActive(true);
						}
						this.m_transform.GetChild(38).gameObject.SetActive(true);
						this.m_transform.GetChild(40).gameObject.SetActive(true);
						this.m_transform.GetChild(41).gameObject.SetActive(true);
						this.m_transform.GetChild(42).gameObject.SetActive(true);
						this.m_transform.GetChild(30).gameObject.SetActive(true);
						if (BattleNetwork.battlePointID % GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode] == 0)
						{
							this.m_transform.GetChild(29).gameObject.SetActive(true);
						}
						num3 = 22;
						for (int j = 0; j < 6; j++)
						{
							this.RewardBtnT[j] = this.m_transform.GetChild(num3 + j);
							this.RewardBtnT[j].GetComponent<UIHIBtn>().m_Handler = this;
						}
						this.SetReward();
						this.RBRewardBtn = new UIHIBtn[(int)this.RewardCount];
						if (this.RewardCount > 6)
						{
							Transform child = this.m_transform.GetChild(36);
							UIButtonHint.m_scrollRect = child.GetComponent<ScrollRect>();
							child.gameObject.SetActive(true);
							child = child.GetChild(0);
							RectTransform component2 = child.GetComponent<RectTransform>();
							component2.sizeDelta = new Vector2((float)(93 * this.RewardCount - 13), component2.sizeDelta.y);
							for (ushort num4 = 0; num4 < (ushort)this.RewardCount; num4 += 1)
							{
								this.GM.InitianHeroItemImg(child.GetChild((int)num4), eHeroOrItem.Item, this.RewardArray[(int)num4].ID, 0, 0, (int)this.RewardArray[(int)num4].count, true, true, true, false);
								this.RBRewardBtn[(int)num4] = child.GetChild((int)num4).GetComponent<UIHIBtn>();
								child.GetChild((int)num4).GetComponent<UIHIBtn>().m_Handler = this;
							}
							for (int k = (int)this.RewardCount; k < 10; k++)
							{
								child.GetChild(k).gameObject.SetActive(false);
							}
						}
						else
						{
							for (ushort num5 = 0; num5 < (ushort)this.RewardCount; num5 += 1)
							{
								Transform child = this.m_transform.GetChild((int)(22 + num5));
								this.GM.InitianHeroItemImg(child, eHeroOrItem.Item, this.RewardArray[(int)num5].ID, 0, 0, (int)this.RewardArray[(int)num5].count, true, true, true, false);
								this.RBRewardBtn[(int)num5] = child.GetComponent<UIHIBtn>();
								child.GetComponent<UIHIBtn>().m_Handler = this;
								child.gameObject.SetActive(true);
							}
						}
						if (this.RewardCount == 0)
						{
							this.RBText[5] = this.m_transform.GetChild(39).GetComponent<UIText>();
							this.RBText[5].text = this.DM.mStringTable.GetStringByID(1598u);
							this.RBText[5].font = ttffont;
							this.RBText[5].gameObject.SetActive(true);
						}
					}
					else
					{
						this.m_transform.GetChild(19).gameObject.SetActive(true);
						this.m_transform.GetChild(20).gameObject.SetActive(true);
						this.m_transform.GetChild(40).gameObject.SetActive(true);
						this.m_transform.GetChild(41).gameObject.SetActive(true);
						this.m_transform.GetChild(30).gameObject.SetActive(true);
						this.RankStr = StringManager.Instance.SpawnString(30);
						StringManager.IntToStr(this.RankStr, (long)((ulong)this.AM.ArenaPlayingData.ChangePlace), 1, false);
						this.RankText = this.m_transform.GetChild(69).GetChild(0).GetComponent<UIText>();
						this.RankText.font = ttffont;
						this.RankText.text = this.RankStr.ToString();
						this.m_transform.GetChild(69).gameObject.SetActive(true);
					}
					for (byte b3 = 0; b3 < this.HeroCount; b3 += 1)
					{
						ushort num6;
						if (this.bHideItem)
						{
							num6 = this.AM.ArenaPlayingData.MyHeroData[(int)b3].ID;
						}
						else
						{
							num6 = this.DM.heroBattleData[(int)b3].HeroID;
						}
						if (this.DM.curHeroData.ContainsKey((uint)num6))
						{
							Hero recordByKey3 = this.DM.HeroTable.GetRecordByKey(num6);
							CString cstring2 = StringManager.Instance.StaticString1024();
							cstring2.ClearString();
							cstring2.IntToFormat((long)recordByKey3.Modle, 5, false);
							cstring2.AppendFormat("Role/hero_{0}");
							this.AB[(int)b3] = AssetManager.GetAssetBundle(cstring2, out this.AssetKey[(int)b3]);
							this.AR[(int)b3] = this.AB[(int)b3].LoadAsync("m", typeof(GameObject));
							this.bABInitial[(int)b3] = false;
							this.LVStr[(int)b3] = StringManager.Instance.SpawnString(30);
							this.LVStr[(int)b3].Length = 0;
							this.LVStr[(int)b3].IntToFormat((long)this.DM.curHeroData[(uint)num6].Level, 1, false);
							this.LVStr[(int)b3].AppendFormat(this.DM.mStringTable.GetStringByID(53u));
							Transform child = this.m_transform.GetChild((int)(48 + b3));
							this.RBLvText[(int)b3] = child.GetComponent<UIText>();
							this.RBLvText[(int)b3].text = this.LVStr[(int)b3].ToString();
							this.RBLvText[(int)b3].font = ttffont;
							child.gameObject.SetActive(true);
							if (this.DM.heroLv[(int)b3] < this.DM.curHeroData[(uint)num6].Level)
							{
								this.LVUPT[(int)b3] = this.m_transform.GetChild((int)(53 + b3));
								this.LVUPT[(int)b3].gameObject.SetActive(true);
								this.LVUPShadow[(int)b3] = this.LVUPT[(int)b3].GetComponent<Shadow>();
								this.LVUPShadow[(int)b3].effectColor = new Color(this.LVUPShadow[(int)b3].effectColor.r, this.LVUPShadow[(int)b3].effectColor.g, this.LVUPShadow[(int)b3].effectColor.b, 0f);
								this.LVUPOutline[(int)b3] = this.LVUPT[(int)b3].GetComponent<Outline>();
								this.LVUPOutline[(int)b3].effectColor = new Color(this.LVUPOutline[(int)b3].effectColor.r, this.LVUPOutline[(int)b3].effectColor.g, this.LVUPOutline[(int)b3].effectColor.b, 0f);
								this.LVUPText2[(int)b3] = this.LVUPT[(int)b3].GetComponent<UIText>();
								this.LVUPText2[(int)b3].color = new Color(this.LVUPText2[(int)b3].color.r, this.LVUPText2[(int)b3].color.g, this.LVUPText2[(int)b3].color.b, 0f);
								this.LVUPText2[(int)b3].text = this.DM.mStringTable.GetStringByID(1555u);
								this.LVUPText2[(int)b3].font = ttffont;
								this.EndY[(int)b3] = this.LVUPT[(int)b3].localPosition.y - 10f;
								this.LvUPMove[(int)b3] = 1;
								this.LvUPPlayTime[(int)b3] = this.LVUPFadeTime;
								this.LVUPT[(int)b3].localPosition = new Vector3(this.LVUPT[(int)b3].localPosition.x, this.LVUPT[(int)b3].localPosition.y + 200f, this.LVUPT[(int)b3].localPosition.z - 252f);
							}
							uint exp = this.GetExp(true, this.DM.curHeroData[(uint)num6].Level, this.DM.curHeroData[(uint)num6].Exp, this.DM.heroLv[(int)b3], this.DM.heroExp[(int)b3]);
							this.ExpStr[(int)b3] = StringManager.Instance.SpawnString(30);
							this.ExpStr[(int)b3].Length = 0;
							this.ExpStr[(int)b3].IntToFormat((long)((ulong)exp), 1, true);
							this.ExpStr[(int)b3].AppendFormat(this.DM.mStringTable.GetStringByID(55u));
							child = this.m_transform.GetChild((int)(43 + b3));
							child.GetComponent<UIText>().text = this.ExpStr[(int)b3].ToString();
							this.RBText[6] = child.GetComponent<UIText>();
							this.RBText[6].text = this.ExpStr[(int)b3].ToString();
							this.RBText[6].font = ttffont;
							this.RBText[6].resizeTextForBestFit = true;
							this.RBText[6].resizeTextMaxSize = 24;
							child.gameObject.SetActive(true);
							child = this.m_transform.GetChild((int)(31 + b3));
							child.GetComponent<Slider>().value = this.DM.curHeroData[(uint)num6].Exp / this.DM.LevelUpTable.GetRecordByKey((ushort)this.DM.curHeroData[(uint)num6].Level).HeroExp;
							child.gameObject.SetActive(true);
							this.FadeImage[(int)b3] = child.GetChild(1).GetComponent<Image>();
							this.MoveImage[(int)b3] = child.GetChild(2).GetComponent<Image>();
							this.MoveImage[(int)b3].rectTransform.localScale = new Vector3(1f, 1.5f, 1f);
							this.LvUPPos = this.MoveImage[(int)b3].rectTransform.localPosition.y + 75f;
							this.ActorNum += 1;
						}
					}
					this.PlayIndex = -1;
				}
				return;
			}
			if (this.OpenKind != 0 && this.LoadHeroCount < this.HeroCount)
			{
				int num7 = 59;
				for (byte b4 = 0; b4 < this.HeroCount; b4 += 1)
				{
					if (!this.bABInitial[(int)b4] && this.AR[(int)b4] != null && this.AR[(int)b4].isDone)
					{
						ushort inKey;
						if (this.bHideItem)
						{
							inKey = this.AM.ArenaPlayingData.MyHeroData[(int)b4].ID;
						}
						else
						{
							inKey = this.DM.heroBattleData[(int)b4].HeroID;
						}
						Hero recordByKey4 = this.DM.HeroTable.GetRecordByKey(inKey);
						GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(this.AR[(int)b4].asset);
						gameObject2.transform.SetParent(this.m_transform.GetChild(num7 + (int)b4), false);
						gameObject2.transform.localPosition = Vector3.zero;
						gameObject2.transform.localRotation = new Quaternion(0f, -180f, 0f, 0f);
						float num8 = 125f * (float)recordByKey4.Scale * 0.01f;
						gameObject2.transform.localScale = new Vector3(num8, num8, num8);
						this.GM.SetLayer(gameObject2, 5);
						if (gameObject2 != null)
						{
							Animation component3 = gameObject2.GetComponent<Animation>();
							component3.wrapMode = WrapMode.Loop;
							component3.Play("victory");
							gameObject2.GetComponentInChildren<SkinnedMeshRenderer>().useLightProbes = false;
							this.PlayerGO[(int)b4] = gameObject2;
						}
						this.bABInitial[(int)b4] = true;
						this.LoadHeroCount += 1;
						if (this.EndY[(int)b4] != -1f)
						{
							AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
						}
					}
				}
			}
			bool flag = false;
			float smoothDeltaTime = Time.smoothDeltaTime;
			for (int l = 0; l < (int)this.HeroCount; l++)
			{
				if (this.bABInitial[l])
				{
					if (this.EndY[l] != -1f)
					{
						flag = true;
						if (Math.Abs(this.LVUPT[l].localPosition.y - this.EndY[l]) < 1f)
						{
							this.EndY[l] = -1f;
						}
						else
						{
							Vector3 localPosition = this.LVUPT[l].localPosition;
							localPosition[1] = Mathf.SmoothDamp(localPosition.y, this.EndY[l], ref this.PageMoveSpeed, 0.135f, float.PositiveInfinity, smoothDeltaTime);
							this.LVUPT[l].localPosition = localPosition;
							if (Mathf.Abs(Mathf.Abs(localPosition[0]) - Mathf.Abs(this.EndY[l])) <= 1f)
							{
								this.EndY[l] = -1f;
							}
						}
						this.colorA += smoothDeltaTime;
						if (this.colorA >= 1f || this.EndY[l] == -1f)
						{
							this.colorA = 1f;
						}
						this.LVUPShadow[l].effectColor = new Color(this.LVUPShadow[l].effectColor.r, this.LVUPShadow[l].effectColor.g, this.LVUPShadow[l].effectColor.b, this.colorA);
						this.LVUPOutline[l].effectColor = new Color(this.LVUPOutline[l].effectColor.r, this.LVUPOutline[l].effectColor.g, this.LVUPOutline[l].effectColor.b, this.colorA);
						this.LVUPText2[l].color = new Color(this.LVUPText2[l].color.r, this.LVUPText2[l].color.g, this.LVUPText2[l].color.b, this.colorA);
					}
					if (this.LvUPMove[l] == 1)
					{
						flag = true;
						if (!this.FadeImage[l].gameObject.activeInHierarchy)
						{
							this.FadeImage[l].gameObject.SetActive(true);
						}
						if (!this.MoveImage[l].gameObject.activeInHierarchy)
						{
							this.MoveImage[l].gameObject.SetActive(true);
						}
						this.LvUPPlayTime[l] -= smoothDeltaTime;
						float num9 = this.LVUPFadeTime * 0.5f;
						float num10 = 1f / this.LVUPFadeTime * 2f;
						if (this.LvUPPlayTime[l] >= num9)
						{
							this.LvUPMoveSpeed[l] += smoothDeltaTime;
							Color color2 = this.FadeImage[l].color;
							color2.a = Mathf.Lerp(0f, 1f, this.LvUPMoveSpeed[l] * num10);
							this.FadeImage[l].color = color2;
						}
						else if (this.LvUPPlayTime[l] < num9 && this.LvUPPlayTime[l] >= 0f)
						{
							this.LvUPMoveSpeed[l] += smoothDeltaTime;
							Color color3 = this.FadeImage[l].color;
							color3.a = 1f - Mathf.Lerp(0f, 1f, this.LvUPMoveSpeed[l] * num10 - 1f);
							this.FadeImage[l].color = color3;
						}
						this.LvUPMoveSpeed2[l] += smoothDeltaTime;
						num9 = this.LVUPMoveTime * 0.5f;
						num10 = 1f / this.LVUPMoveTime;
						if (this.LvUPPlayTime[l] >= this.LVUPFadeTime - num9)
						{
							Color color4 = this.MoveImage[l].color;
							color4.a = Mathf.Lerp(0f, 1f, this.LvUPMoveSpeed2[l] * num10 * 2f);
							this.MoveImage[l].color = color4;
						}
						else if (this.LvUPPlayTime[l] < this.LVUPFadeTime - num9 && this.LvUPPlayTime[l] >= this.LVUPFadeTime - this.LVUPMoveTime)
						{
							Color color5 = this.MoveImage[l].color;
							color5.a = 1f - Mathf.Lerp(0f, 1f, this.LvUPMoveSpeed2[l] * num10 * 2f - 1f);
							this.MoveImage[l].color = color5;
						}
						if (this.LvUPPlayTime[l] >= this.LVUPFadeTime - this.LVUPMoveTime)
						{
							Vector3 localPosition2 = this.MoveImage[l].rectTransform.localPosition;
							localPosition2.y = this.LvUPPos + Mathf.Lerp(0f, 1f, this.LvUPMoveSpeed2[l] * num10) * this.LvUPMoveDelta;
							this.MoveImage[l].rectTransform.localPosition = localPosition2;
						}
						if (this.LvUPPlayTime[l] <= 0f)
						{
							this.LVUPIniTial(l);
						}
					}
				}
			}
			if (this.OpenKind != 0 && this.NowStep == 0 && !flag && this.LoadHeroCount == this.HeroCount && this.DM.RoleAttr.Level >= this.DM.KingOldLv + 1)
			{
				this.NowStep = 1;
			}
		}
		if (this.bHintOpen > 0)
		{
			this.SetHint();
		}
	}

	// Token: 0x060009BD RID: 2493 RVA: 0x000CD1CC File Offset: 0x000CB3CC
	private void LVUPIniTial(int i)
	{
		this.LvUPMove[i] = 0;
		this.LvUPPlayTime[i] = -1f;
		Color color = this.FadeImage[i].color;
		color.a = 0f;
		this.FadeImage[i].color = color;
		this.FadeImage[i].gameObject.SetActive(false);
		color = this.MoveImage[i].color;
		color.a = 0f;
		this.MoveImage[i].color = color;
		this.MoveImage[i].gameObject.SetActive(false);
		Vector3 localPosition = this.MoveImage[i].rectTransform.localPosition;
		localPosition.y = this.LvUPPos;
		this.MoveImage[i].rectTransform.localPosition = localPosition;
		this.LvUPMoveSpeed[i] = 0f;
		this.LvUPMoveSpeed2[i] = 0f;
	}

	// Token: 0x060009BE RID: 2494 RVA: 0x000CD2B4 File Offset: 0x000CB4B4
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (sender.m_BtnID1 != 2)
		{
			if (sender.m_BtnID1 == 3)
			{
			}
		}
	}

	// Token: 0x060009BF RID: 2495 RVA: 0x000CD2D4 File Offset: 0x000CB4D4
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			if (sender.m_BtnID2 != 1)
			{
				if (sender.m_BtnID2 == 2)
				{
					if (DataManager.StageDataController._stageMode != StageMode.Dare)
					{
						DataManager instance = DataManager.Instance;
						if (DataManager.StageDataController._stageMode == StageMode.Lean)
						{
							VIP_DataTbl recordByKey = DataManager.Instance.VIPLevelTable.GetRecordByKey((ushort)DataManager.Instance.RoleAttr.VIPLevel);
							int num = DataManager.StageDataController.StageInfo[1][(int)(BattleNetwork.battlePointID - 1)] >> 2 & 63;
							if (recordByKey.DailyResetElite != 255 && num >= (int)recordByKey.DailyResetElite)
							{
								this.GM.AddHUDMessage(instance.mStringTable.GetStringByID(1599u), 255, true);
								return;
							}
						}
						int num2 = (int)(DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort)DataManager.StageDataController.currentChapterID).Power * ((DataManager.StageDataController._stageMode != StageMode.Lean) ? 1 : 2));
						if ((int)instance.RoleAttr.Morale < num2)
						{
							ushort itemID = 1115;
							this.GM.UseOrSpend(itemID, instance.mStringTable.GetStringByID(1505u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
							return;
						}
					}
					if (this.bSendServer)
					{
						BattleNetwork.bReplay = true;
						BattleNetwork.sendInitBattle();
					}
					else
					{
						GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleReplay_Dare);
						AudioManager.Instance.LoadAndPlayBGM(BGMType.War, 1, false);
					}
					this.GM.ShowChatBox();
				}
				else if (sender.m_BtnID2 == 3)
				{
					this.CloseFunc();
				}
				else if (sender.m_BtnID2 == 4 && this.RandomIndex < 5)
				{
					this.GM.RandomIndex = this.RandomIndex;
					this.CloseFunc();
				}
			}
		}
	}

	// Token: 0x060009C0 RID: 2496 RVA: 0x000CD4B8 File Offset: 0x000CB6B8
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		if (uibutton == null)
		{
			return;
		}
		if (uibutton.m_BtnID1 == 10)
		{
			if (this.NowStep == 1)
			{
				this.DS.GetStageConditionString(this.HinString, (byte)uibutton.m_BtnID2, (ushort)uibutton.m_BtnID3, (ushort)uibutton.m_BtnID4, this.ConditionKey);
				this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 280f, 20, this.HinString, Vector2.zero);
			}
		}
		else
		{
			if (uibutton.m_BtnID1 < 0 || uibutton.m_BtnID1 > 3)
			{
				return;
			}
			this.bHintOpen = (byte)uibutton.m_BtnID1;
			Vector2 anchoredPosition = this.HintRC[(int)(this.bHintOpen - 1)].anchoredPosition;
			anchoredPosition.y += 50f;
			this.m_HintBox.rectTransform.anchoredPosition = anchoredPosition;
			this.m_HintBox.gameObject.SetActive(true);
			this.HintTime = 2f;
			this.SetHint();
		}
	}

	// Token: 0x060009C1 RID: 2497 RVA: 0x000CD5D0 File Offset: 0x000CB7D0
	public void OnButtonUp(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		if (uibutton == null)
		{
			return;
		}
		if (uibutton.m_BtnID1 == 10)
		{
			this.GM.m_Hint.Hide(false);
		}
		else
		{
			this.m_HintBox.gameObject.SetActive(false);
			this.bHintOpen = 0;
		}
	}

	// Token: 0x060009C2 RID: 2498 RVA: 0x000CD634 File Offset: 0x000CB834
	private void SetHint()
	{
		this.HintTime += Time.deltaTime;
		if (this.HintTime < 1f)
		{
			return;
		}
		this.HintTime = 0f;
		if (this.bHintOpen == 1)
		{
			this.m_HintText.text = this.DM.mStringTable.GetStringByID(1517u);
		}
		else if (this.bHintOpen == 2)
		{
			this.m_HintText.text = this.DM.mStringTable.GetStringByID(1518u);
		}
		else if (this.bHintOpen == 3)
		{
			this.m_HintText.text = this.DM.mStringTable.GetStringByID(1580u);
		}
		this.m_HintBox.rectTransform.sizeDelta = new Vector2(350f, this.m_HintText.preferredHeight + 31f);
		if (this.m_HintBox.rectTransform.sizeDelta.y > 150f)
		{
			Vector2 anchoredPosition = this.HintRC[(int)(this.bHintOpen - 1)].anchoredPosition;
			anchoredPosition.y += 50f + (this.m_HintBox.rectTransform.sizeDelta.y - 140f);
			this.m_HintBox.rectTransform.anchoredPosition = anchoredPosition;
		}
	}

	// Token: 0x060009C3 RID: 2499 RVA: 0x000CD7A4 File Offset: 0x000CB9A4
	private uint GetExp(bool bHero, byte NowLv, uint NowExp, byte OldLv, uint OldExp)
	{
		uint num;
		if (NowLv == OldLv)
		{
			num = NowExp - OldExp;
		}
		else if (bHero)
		{
			num = this.DM.LevelUpTable.GetRecordByKey((ushort)OldLv).HeroExp - OldExp + NowExp;
			for (int i = (int)(OldLv + 1); i < (int)NowLv; i++)
			{
				num += this.DM.LevelUpTable.GetRecordByKey((ushort)i).HeroExp;
			}
		}
		else
		{
			num = this.DM.LevelUpTable.GetRecordByKey((ushort)OldLv).KingdomExp - OldExp + NowExp;
			for (int j = (int)(OldLv + 1); j < (int)NowLv; j++)
			{
				num += this.DM.LevelUpTable.GetRecordByKey((ushort)j).KingdomExp;
			}
		}
		return num;
	}

	// Token: 0x060009C4 RID: 2500 RVA: 0x000CD878 File Offset: 0x000CBA78
	private void SetReward()
	{
		Array.Clear(this.RewardArray, 0, this.RewardArray.Length);
		int num = (int)(this.DM.RewardLen[0] + this.DM.RewardLen[1] + this.DM.RewardLen[2] + this.DM.RewardLen[3]);
		int num2 = 0;
		while (num2 < num && num2 < 128)
		{
			for (int i = 0; i < 10; i++)
			{
				if (this.RewardArray[i].ID == 0)
				{
					this.RewardArray[i].ID = this.DM.RewardData[num2];
					this.RewardArray[i].count = 1;
					this.RewardCount += 1;
					break;
				}
				if (this.RewardArray[i].ID == this.DM.RewardData[num2])
				{
					sRewardData[] rewardArray = this.RewardArray;
					int num3 = i;
					rewardArray[num3].count = rewardArray[num3].count + 1;
					break;
				}
			}
			num2++;
		}
		if (this.RewardCount > 10)
		{
			this.RewardCount = 10;
		}
	}

	// Token: 0x060009C5 RID: 2501 RVA: 0x000CD9B4 File Offset: 0x000CBBB4
	private void CloseFunc()
	{
		if (this.bChallenge && this.OpenKind != 0 && this.PlayIndex != -1)
		{
			return;
		}
		this.GM.CheckSynIsOpned();
		if (this.OpenKind == 0)
		{
			for (int i = 0; i < (int)this.ActorNum; i++)
			{
				AssetManager.UnloadAssetBundle(this.AssetKey[i], true);
			}
			DataManager.Instance.SendExitBattle();
		}
		else
		{
			this.GM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
		}
	}

	// Token: 0x060009C6 RID: 2502 RVA: 0x000CDA40 File Offset: 0x000CBC40
	public override bool OnBackButtonClick()
	{
		this.CloseFunc();
		return true;
	}

	// Token: 0x060009C7 RID: 2503 RVA: 0x000CDA4C File Offset: 0x000CBC4C
	private float easeOutQuad(float start, float end, float value)
	{
		end -= start;
		return -end * value * (value - 2f) + start;
	}

	// Token: 0x060009C8 RID: 2504 RVA: 0x000CDA64 File Offset: 0x000CBC64
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			for (int i = 0; i < this.RBText.Length; i++)
			{
				if (this.RBText[i] != null && this.RBText[i].enabled)
				{
					this.RBText[i].enabled = false;
					this.RBText[i].enabled = true;
				}
			}
			for (int j = 0; j < this.RBLvText.Length; j++)
			{
				if (this.RBLvText[j] != null && this.RBLvText[j].enabled)
				{
					this.RBLvText[j].enabled = false;
					this.RBLvText[j].enabled = true;
				}
			}
			if (this.RBRewardBtn != null)
			{
				for (int k = 0; k < this.RBRewardBtn.Length; k++)
				{
					this.RBRewardBtn[k].Refresh_FontTexture();
				}
			}
			if (this.RankText != null && this.RankText.enabled)
			{
				this.RankText.enabled = false;
				this.RankText.enabled = true;
			}
		}
	}

	// Token: 0x0400209F RID: 8351
	private const byte RewardNum = 10;

	// Token: 0x040020A0 RID: 8352
	private Transform m_transform;

	// Token: 0x040020A1 RID: 8353
	private GUIManager GM = GUIManager.Instance;

	// Token: 0x040020A2 RID: 8354
	private DataManager DM = DataManager.Instance;

	// Token: 0x040020A3 RID: 8355
	private ArenaManager AM = ArenaManager.Instance;

	// Token: 0x040020A4 RID: 8356
	private StageManager DS = DataManager.StageDataController;

	// Token: 0x040020A5 RID: 8357
	private AssetBundle[] AB = new AssetBundle[5];

	// Token: 0x040020A6 RID: 8358
	private AssetBundleRequest[] AR = new AssetBundleRequest[5];

	// Token: 0x040020A7 RID: 8359
	private bool[] bABInitial = new bool[5];

	// Token: 0x040020A8 RID: 8360
	private int[] AssetKey = new int[5];

	// Token: 0x040020A9 RID: 8361
	private GameObject[] PlayerGO = new GameObject[5];

	// Token: 0x040020AA RID: 8362
	private Transform[] RewardBtnT = new Transform[7];

	// Token: 0x040020AB RID: 8363
	private Transform LightT;

	// Token: 0x040020AC RID: 8364
	private byte LoadHeroCount;

	// Token: 0x040020AD RID: 8365
	private byte RewardCount;

	// Token: 0x040020AE RID: 8366
	private sRewardData[] RewardArray = new sRewardData[10];

	// Token: 0x040020AF RID: 8367
	private int OpenKind;

	// Token: 0x040020B0 RID: 8368
	private byte ActorNum;

	// Token: 0x040020B1 RID: 8369
	private bool bHideItem;

	// Token: 0x040020B2 RID: 8370
	private byte HeroCount;

	// Token: 0x040020B3 RID: 8371
	private UISpritesArray SArray;

	// Token: 0x040020B4 RID: 8372
	private byte NowStep;

	// Token: 0x040020B5 RID: 8373
	private float LVUPFadeTime = 1.6f;

	// Token: 0x040020B6 RID: 8374
	private float LVUPMoveTime = 1.2f;

	// Token: 0x040020B7 RID: 8375
	private float LvUPPos = 138f;

	// Token: 0x040020B8 RID: 8376
	private float LvUPMoveDelta = 280f;

	// Token: 0x040020B9 RID: 8377
	private byte[] LvUPMove = new byte[5];

	// Token: 0x040020BA RID: 8378
	private float[] LvUPMoveSpeed = new float[5];

	// Token: 0x040020BB RID: 8379
	private float[] LvUPMoveSpeed2 = new float[5];

	// Token: 0x040020BC RID: 8380
	private float[] LvUPPlayTime = new float[]
	{
		-1f,
		-1f,
		-1f,
		-1f,
		-1f
	};

	// Token: 0x040020BD RID: 8381
	private float[] LvUPPlayPos = new float[]
	{
		-1f,
		-1f,
		-1f,
		-1f,
		-1f
	};

	// Token: 0x040020BE RID: 8382
	private float[] EndY = new float[]
	{
		-1f,
		-1f,
		-1f,
		-1f,
		-1f
	};

	// Token: 0x040020BF RID: 8383
	private Image[] MoveImage = new Image[5];

	// Token: 0x040020C0 RID: 8384
	private Image[] FadeImage = new Image[5];

	// Token: 0x040020C1 RID: 8385
	private Transform[] LVUPT = new Transform[5];

	// Token: 0x040020C2 RID: 8386
	private UIText[] LVUPText2 = new UIText[5];

	// Token: 0x040020C3 RID: 8387
	private Outline[] LVUPOutline = new Outline[5];

	// Token: 0x040020C4 RID: 8388
	private Shadow[] LVUPShadow = new Shadow[5];

	// Token: 0x040020C5 RID: 8389
	public float PageMoveSpeed;

	// Token: 0x040020C6 RID: 8390
	public float colorA;

	// Token: 0x040020C7 RID: 8391
	private int TipCount = 2;

	// Token: 0x040020C8 RID: 8392
	private int TipTotalCount = 9;

	// Token: 0x040020C9 RID: 8393
	private ushort[] TipTitleID = new ushort[]
	{
		1545,
		1547,
		1549,
		1551,
		1553,
		1585,
		1587,
		3647,
		3645
	};

	// Token: 0x040020CA RID: 8394
	private ushort[] TipID = new ushort[]
	{
		1546,
		1548,
		1550,
		1552,
		1554,
		1586,
		1588,
		3648,
		3646
	};

	// Token: 0x040020CB RID: 8395
	private int[] RandomList = new int[]
	{
		0,
		1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1
	};

	// Token: 0x040020CC RID: 8396
	private int RandomIndex = -1;

	// Token: 0x040020CD RID: 8397
	private int PlayIndex = -1;

	// Token: 0x040020CE RID: 8398
	private float PlayTime;

	// Token: 0x040020CF RID: 8399
	private float PlayWaitTime;

	// Token: 0x040020D0 RID: 8400
	private RectTransform[] HintRC = new RectTransform[3];

	// Token: 0x040020D1 RID: 8401
	private Image m_HintBox;

	// Token: 0x040020D2 RID: 8402
	private UIText m_HintText;

	// Token: 0x040020D3 RID: 8403
	private byte bHintOpen;

	// Token: 0x040020D4 RID: 8404
	private float HintTime;

	// Token: 0x040020D5 RID: 8405
	private UIText[] RBText = new UIText[7];

	// Token: 0x040020D6 RID: 8406
	private UIText[] RBLvText = new UIText[5];

	// Token: 0x040020D7 RID: 8407
	private UIHIBtn[] RBRewardBtn;

	// Token: 0x040020D8 RID: 8408
	private UIText RankText;

	// Token: 0x040020D9 RID: 8409
	private CString RankStr;

	// Token: 0x040020DA RID: 8410
	private CString GetEXPStr;

	// Token: 0x040020DB RID: 8411
	private CString GetMoneyStr;

	// Token: 0x040020DC RID: 8412
	private CString ConditionStr;

	// Token: 0x040020DD RID: 8413
	private CString[] LVStr = new CString[5];

	// Token: 0x040020DE RID: 8414
	private CString[] ExpStr = new CString[5];

	// Token: 0x040020DF RID: 8415
	private bool bArena;

	// Token: 0x040020E0 RID: 8416
	private bool bChallenge;

	// Token: 0x040020E1 RID: 8417
	private bool bSendServer;

	// Token: 0x040020E2 RID: 8418
	private ushort ConditionKey;

	// Token: 0x040020E3 RID: 8419
	private float MoveBeginPos = -29f;

	// Token: 0x040020E4 RID: 8420
	private float MoveEndPos = -129f;

	// Token: 0x040020E5 RID: 8421
	private int ConditionCount;

	// Token: 0x040020E6 RID: 8422
	private int NowMoveIndex = -1;

	// Token: 0x040020E7 RID: 8423
	private float PlayTotalTime = 0.3f;

	// Token: 0x040020E8 RID: 8424
	private RectTransform[] ConditionRC = new RectTransform[8];

	// Token: 0x040020E9 RID: 8425
	private UIButton[] ConditionBtn = new UIButton[8];

	// Token: 0x040020EA RID: 8426
	private Image[] ConditionBackImg = new Image[8];

	// Token: 0x040020EB RID: 8427
	private Image[] ConditionImg = new Image[8];

	// Token: 0x040020EC RID: 8428
	private Image[] ConditionCheckImg = new Image[8];

	// Token: 0x040020ED RID: 8429
	private CString HinString;
}
