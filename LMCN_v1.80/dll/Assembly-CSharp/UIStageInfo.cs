using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004BB RID: 1211
public class UIStageInfo : GUIWindow, UILoadImageHander, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x0600186E RID: 6254 RVA: 0x0028F93C File Offset: 0x0028DB3C
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.DS = DataManager.StageDataController;
		this.GM = GUIManager.Instance;
		this.SM = StringManager.Instance;
		this.m_transform = base.transform;
		Font ttffont = this.GM.GetTTFFont();
		this.tmpString = this.SM.SpawnString(150);
		this.tmpString2 = this.SM.SpawnString(150);
		this.tmpString3 = this.SM.SpawnString(30);
		this.SArray1 = this.m_transform.GetComponent<UISpritesArray>();
		Transform child = this.m_transform.GetChild(26);
		this.SArray1 = child.GetComponent<UISpritesArray>();
		this.SArray2 = child.GetChild(0).GetComponent<UISpritesArray>();
		this.SArray1.SetSpriteIndex(1);
		this.SArray2.SetSpriteIndex(1);
		child.GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(21).GetComponent<UIButton>().m_Handler = this;
		this.Play10T = this.m_transform.GetChild(24);
		this.Play10T.GetComponent<UIButton>().m_Handler = this;
		this.Play1T = this.m_transform.GetChild(25);
		this.Play1T.GetComponent<UIButton>().m_Handler = this;
		this.Play10TextT = this.m_transform.GetChild(53);
		this.Play10Text = this.Play10TextT.GetComponent<UIText>();
		this.Play10Text.font = ttffont;
		this.Play1TextT = this.m_transform.GetChild(54);
		this.Play1Text = this.Play1TextT.GetComponent<UIText>();
		this.Play1Text.font = ttffont;
		this.TicketImgT2 = this.m_transform.GetChild(43);
		this.m_transform.GetChild(27).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(28).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(8).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(8).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(8).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(8).GetComponent<CustomImage>().enabled = false;
		}
		this.TicketImgT = this.m_transform.GetChild(10);
		this.TicketNumT = this.m_transform.GetChild(44);
		this.TicketNum = this.TicketNumT.GetComponent<UIText>();
		this.TicketNum.font = ttffont;
		this.TicketNum.text = this.DM.mStringTable.GetStringByID(151u);
		this.StageName = this.m_transform.GetChild(45).GetComponent<UIText>();
		this.StageName.font = ttffont;
		this.StageName2 = this.m_transform.GetChild(46).GetComponent<UIText>();
		this.StageName2.font = ttffont;
		this.Power = this.m_transform.GetChild(47).GetComponent<UIText>();
		this.Power.font = ttffont;
		this.Times = this.m_transform.GetChild(48).GetComponent<UIText>();
		this.Times.font = ttffont;
		this.Story = this.m_transform.GetChild(52).GetComponent<UIText>();
		this.Story.font = ttffont;
		this.Rewards = this.m_transform.GetChild(49).GetComponent<UIText>();
		this.Rewards.font = ttffont;
		this.Rewards.text = this.DM.mStringTable.GetStringByID(48u);
		this.Enemy = this.m_transform.GetChild(50).GetComponent<UIText>();
		this.Enemy.font = ttffont;
		this.Enemy.text = this.DM.mStringTable.GetStringByID(49u);
		this.Enemy.gameObject.SetActive(false);
		this.NPCName = this.m_transform.GetChild(51).GetComponent<UIText>();
		this.NPCName.font = ttffont;
		this.BossImg1 = this.m_transform.GetChild(40);
		this.BossImg2 = this.m_transform.GetChild(41);
		if (this.DM.UserLanguage == GameLanguage.GL_Chs)
		{
			UISpritesArray component = this.m_transform.GetChild(41).GetComponent<UISpritesArray>();
			this.m_transform.GetChild(40).GetChild(1).GetComponent<Image>().sprite = component.m_Sprites[1];
			this.m_transform.GetChild(41).GetComponent<Image>().sprite = component.m_Sprites[1];
		}
		if (this.GM.IsArabic)
		{
			this.m_transform.GetChild(40).GetChild(1).GetComponent<Image>().rectTransform.localScale = new Vector3(-1f, 1f, 1f);
			this.m_transform.GetChild(41).GetComponent<Image>().rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		int stagePoint = this.DS.GetStagePoint(0, 0);
		if (stagePoint >= 3 && this.DS._stageMode != StageMode.Dare)
		{
			this.Play10T.gameObject.SetActive(true);
			this.Play1T.gameObject.SetActive(true);
			this.Play10TextT.gameObject.SetActive(true);
			this.Play1TextT.gameObject.SetActive(true);
			this.TicketImgT.gameObject.SetActive(true);
			this.TicketNumT.gameObject.SetActive(true);
		}
		this.NormalObj = this.m_transform.GetChild(2).gameObject;
		this.EliteObj1 = this.m_transform.GetChild(3).gameObject;
		this.EliteObj2 = this.m_transform.GetChild(19).gameObject;
		this.DareObj1 = this.m_transform.GetChild(4).gameObject;
		this.DareObj2 = this.m_transform.GetChild(20).gameObject;
		if (this.DS._stageMode == StageMode.Lean)
		{
			this.m_transform.GetChild(48).gameObject.SetActive(true);
			this.NormalObj.SetActive(false);
			this.EliteObj1.SetActive(true);
			this.EliteObj2.SetActive(true);
			this.DareObj1.SetActive(false);
			this.DareObj2.SetActive(false);
			this.StageName.rectTransform.localPosition += new Vector3(0f, -3f, 0f);
			this.StageName.color = new Color(1f, 0.9686f, 0.6f);
		}
		else if (this.DS._stageMode == StageMode.Dare)
		{
			this.m_transform.GetChild(48).gameObject.SetActive(true);
			this.NormalObj.SetActive(false);
			this.EliteObj1.SetActive(false);
			this.EliteObj2.SetActive(false);
			this.DareObj1.SetActive(true);
			this.DareObj2.SetActive(true);
			this.m_transform.GetChild(16).gameObject.SetActive(false);
			this.m_transform.GetChild(17).gameObject.SetActive(false);
			this.StageName.rectTransform.localPosition += new Vector3(0f, -3f, 0f);
			this.StageName.color = new Color(1f, 0.9686f, 0.6f);
		}
		else
		{
			this.NormalObj.SetActive(true);
			this.EliteObj1.SetActive(false);
			this.EliteObj2.SetActive(false);
			this.DareObj1.SetActive(false);
			this.DareObj2.SetActive(false);
			this.StageName.color = new Color(0.6706f, 0.9882f, 1f);
		}
		byte stageMode = (byte)this.DS._stageMode;
		int num;
		if (this.DS._stageMode != StageMode.Dare && this.DS.currentPointID % GameConstants.LinePointNum[(int)stageMode] == 0 && this.DS.currentPointID <= this.DS.StageRecord[(int)stageMode])
		{
			num = 12;
			for (int i = 0; i < stagePoint; i++)
			{
				this.StarT[i] = this.m_transform.GetChild(num + i);
				this.StarT[i].gameObject.SetActive(true);
			}
		}
		Level levelBycurrentPointID = this.DS.GetLevelBycurrentPointID(0);
		Stage recordByKey = this.DS.StageTable.GetRecordByKey(levelBycurrentPointID.LevelInfoNo);
		this.StageName.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.StageName);
		this.StageNameStr = this.SM.SpawnString(30);
		this.StageNameStr.IntToFormat((long)this.DS.currentChapterID, 1, false);
		int num2 = (int)(this.DS.currentPointID % GameConstants.StagePointNum[(int)stageMode]);
		int num3 = (num2 != 0) ? num2 : ((int)GameConstants.StagePointNum[(int)stageMode]);
		this.StageNameStr.IntToFormat((long)((stageMode != 1) ? num3 : (num3 * 3)), 1, false);
		if (this.GM.IsArabic)
		{
			this.StageNameStr.AppendFormat("{1}-{0}");
		}
		else
		{
			this.StageNameStr.AppendFormat("{0}-{1}");
		}
		this.StageName2.text = this.StageNameStr.ToString();
		if (this.DS._stageMode != StageMode.Dare)
		{
			this.Story.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.StageDesc);
			this.NPCName.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.TalkMan);
		}
		this.OpenRefresh();
		this.tmpString2.Length = 0;
		this.tmpString2.IntToFormat((long)this.NeedMorale, 1, false);
		this.tmpString2.AppendFormat(this.DM.mStringTable.GetStringByID(46u));
		this.Power.text = this.tmpString2.ToString();
		num = 35;
		for (int j = 0; j < 5; j++)
		{
			this.EnemyBtnT[j] = this.m_transform.GetChild(num + j);
			this.EnemyBtnT[j].GetComponent<UIHIBtn>().m_Handler = this;
		}
		if (this.DS._stageMode != StageMode.Dare)
		{
			RewardScore recordByKey2 = this.DM.RewardScoreTable.GetRecordByKey(levelBycurrentPointID.TreasureNo);
			for (int k = 0; k < 6; k++)
			{
				if (recordByKey2.Rewards[k] != 0)
				{
					this.RewardCount += 1;
				}
			}
			if (recordByKey2.Rewards[6] != 0)
			{
				this.bHaveTargetItem = true;
				this.RewardBtnT[0] = this.m_transform.GetChild(29);
				this.RBRewardBtn[0] = this.RewardBtnT[0].GetComponent<UIHIBtn>();
				this.RewardBtnT[0].GetComponent<UIHIBtn>().m_Handler = this;
				this.GM.InitianHeroItemImg(this.RewardBtnT[0], eHeroOrItem.Item, recordByKey2.Rewards[6], 0, 0, 0, true, true, true, false);
				this.RewardBtnT[0].gameObject.SetActive(true);
				if (this.RewardCount >= 5)
				{
					this.ScrollT = this.m_transform.GetChild(34);
					UIButtonHint.m_scrollRect = this.ScrollT.gameObject.GetComponent<ScrollRect>();
					Transform child2 = this.ScrollT.GetChild(0);
					this.ScrollT.gameObject.SetActive(true);
					int num4 = 1;
					for (int l = 1; l <= 6; l++)
					{
						if (recordByKey2.Rewards[l - 1] != 0 && num4 < this.RewardBtnT.Length)
						{
							this.RewardBtnT[num4] = child2.GetChild(num4 - 1);
							this.RBRewardBtn[num4] = this.RewardBtnT[num4].GetComponent<UIHIBtn>();
							this.RewardBtnT[num4].GetComponent<UIHIBtn>().m_Handler = this;
							this.GM.InitianHeroItemImg(this.RewardBtnT[num4], eHeroOrItem.Item, recordByKey2.Rewards[l - 1], 0, 0, 0, true, true, true, false);
							this.RewardBtnT[num4].gameObject.SetActive(true);
							num4++;
						}
					}
					RectTransform component2 = child2.GetComponent<RectTransform>();
					this.tmpVec2.Set(this.IconDelta * (float)this.RewardCount - 7f, component2.sizeDelta.y);
					component2.sizeDelta = this.tmpVec2;
				}
				else
				{
					num = 29;
					for (int m = 0; m < 4; m++)
					{
						this.RewardBtnT[m + 1] = this.m_transform.GetChild(num + m + 1);
						this.RBRewardBtn[m + 1] = this.RewardBtnT[m + 1].GetComponent<UIHIBtn>();
						this.RewardBtnT[m + 1].GetComponent<UIHIBtn>().m_Handler = this;
					}
					int num5 = 1;
					for (int n = 0; n < 6; n++)
					{
						if (recordByKey2.Rewards[n] != 0 && num5 < this.RewardBtnT.Length)
						{
							this.GM.InitianHeroItemImg(this.RewardBtnT[num5], eHeroOrItem.Item, recordByKey2.Rewards[n], 0, 0, 0, true, true, true, false);
							this.RewardBtnT[num5].gameObject.SetActive(true);
							num5++;
						}
					}
				}
			}
			else if (this.RewardCount > 5)
			{
				this.ScrollT = this.m_transform.GetChild(34);
				UIButtonHint.m_scrollRect = this.ScrollT.gameObject.GetComponent<ScrollRect>();
				RectTransform component3 = this.ScrollT.GetComponent<RectTransform>();
				this.tmpVec3.Set(25f, -6f, component3.localPosition.z);
				component3.localPosition = this.tmpVec3;
				this.tmpVec2.Set(500f, this.IconSize);
				component3.sizeDelta = this.tmpVec2;
				this.ScrollT.gameObject.SetActive(true);
				Transform child3 = this.ScrollT.GetChild(0);
				int num6 = 0;
				for (int num7 = 0; num7 < 6; num7++)
				{
					if (recordByKey2.Rewards[num7] != 0 && num6 < this.RewardBtnT.Length)
					{
						this.RewardBtnT[num6] = child3.GetChild(num7);
						this.RBRewardBtn[num6] = this.RewardBtnT[num6].GetComponent<UIHIBtn>();
						this.RewardBtnT[num6].GetComponent<UIHIBtn>().m_Handler = this;
						this.GM.InitianHeroItemImg(this.RewardBtnT[num6], eHeroOrItem.Item, recordByKey2.Rewards[num7], 0, 0, 0, true, true, true, false);
						this.RewardBtnT[num6].gameObject.SetActive(true);
						num6++;
					}
				}
				component3 = child3.GetComponent<RectTransform>();
				component3.sizeDelta = new Vector2(this.IconDelta * (float)this.RewardCount - 7f, component3.sizeDelta.y);
			}
			else
			{
				num = 29;
				for (int num8 = 0; num8 < 5; num8++)
				{
					this.RewardBtnT[num8] = this.m_transform.GetChild(num + num8);
					this.RBRewardBtn[num8] = this.RewardBtnT[num8].GetComponent<UIHIBtn>();
					this.RewardBtnT[num8].GetComponent<UIHIBtn>().m_Handler = this;
				}
				this.GM.InitianHeroItemImg(this.RewardBtnT[0], eHeroOrItem.Item, recordByKey2.Rewards[0], 0, 0, 0, true, true, true, false);
				RectTransform component4 = this.RewardBtnT[0].GetComponent<RectTransform>();
				this.tmpVec3.Set(-177f, -6f, component4.localPosition.z);
				component4.localPosition = this.tmpVec3;
				this.tmpVec2.Set(this.IconSize, this.IconSize);
				component4.sizeDelta = this.tmpVec2;
				this.RewardBtnT[0].gameObject.SetActive(true);
				int num9 = 0;
				for (int num10 = 0; num10 < 6; num10++)
				{
					if (recordByKey2.Rewards[num10] != 0 && num9 < this.RewardBtnT.Length)
					{
						this.GM.InitianHeroItemImg(this.RewardBtnT[num9], eHeroOrItem.Item, recordByKey2.Rewards[num10], 0, 0, 0, true, true, true, false);
						component4 = this.RewardBtnT[num9].GetComponent<RectTransform>();
						this.tmpVec3.Set(-177f + this.IconDelta * (float)num9, -6f, component4.localPosition.z);
						component4.localPosition = this.tmpVec3;
						this.RewardBtnT[num9].gameObject.SetActive(true);
						num9++;
					}
				}
			}
		}
		if (levelBycurrentPointID.Team[2] != 0)
		{
			int num11 = 1;
			int num12 = 0;
			HeroTeam recordByKey3 = this.DM.TeamTable.GetRecordByKey(levelBycurrentPointID.Team[2]);
			for (int num13 = 0; num13 < 20; num13++)
			{
				if (num11 <= 4 && recordByKey3.Arrays[num13].Type == 2)
				{
					if (this.GM.InitianHeroItemImg(this.EnemyBtnT[num11], eHeroOrItem.Hero, recordByKey3.Arrays[num13].Hero, 1, 0, 0, true, true, true, false))
					{
						UIHIBtn component5 = this.EnemyBtnT[num11].GetComponent<UIHIBtn>();
						component5.m_BtnID1 = (int)levelBycurrentPointID.Team[2];
						component5.m_BtnID2 = num13;
						num11++;
						this.EnemyCount += 1;
					}
				}
				else if (recordByKey3.Arrays[num13].Type == 3 && num12 == 0 && this.GM.InitianHeroItemImg(this.EnemyBtnT[num12], eHeroOrItem.Hero, recordByKey3.Arrays[num13].Hero, recordByKey3.HeroStar, 0, 0, true, true, true, false))
				{
					UIHIBtn component6 = this.EnemyBtnT[num12].GetComponent<UIHIBtn>();
					component6.m_BtnID1 = (int)levelBycurrentPointID.Team[2];
					component6.m_BtnID2 = num13;
					this.ActionTime = 0f;
					this.ActionTimeRandom = 2f;
					this.sHero = this.DM.HeroTable.GetRecordByKey(recordByKey3.Arrays[num13].Hero);
					CString cstring = this.SM.StaticString1024();
					cstring.IntToFormat((long)this.sHero.Modle, 5, false);
					cstring.AppendFormat("Role/hero_{0}");
					if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, this.sHero.Modle, false))
					{
						this.LoadAB(false);
					}
					Vector3 vector = this.m_transform.GetChild(55).localPosition + new Vector3(0f, 0f, -37f);
					RectTransform canvasRT = this.GM.pDVMgr.CanvasRT;
					RectTransform component7 = this.m_transform.GetChild(0).GetComponent<RectTransform>();
					float new_x = (-(canvasRT.sizeDelta.x * 0.5f) + (component7.localPosition.x - component7.sizeDelta.x * 0.5f)) * 0.5f;
					vector.Set(new_x, vector.y, vector.z);
					this.ActorPos = vector;
					float x = vector.x;
					if (this.StarT[0] != null)
					{
						RectTransform component8 = this.StarT[0].GetComponent<RectTransform>();
						vector = component8.localPosition;
						vector.Set(x, vector.y, vector.z);
						component8.localPosition = vector;
					}
					if (this.StarT[1] != null)
					{
						RectTransform component9 = this.StarT[1].GetComponent<RectTransform>();
						vector = component9.localPosition;
						vector.Set(x - 44f, vector.y, vector.z);
						component9.localPosition = vector;
					}
					if (this.StarT[2] != null)
					{
						RectTransform component10 = this.StarT[2].GetComponent<RectTransform>();
						vector = component10.localPosition;
						vector.Set(x + 44f, vector.y, vector.z);
						component10.localPosition = vector;
					}
					RectTransform component11 = this.BossImg1.GetComponent<RectTransform>();
					vector = component11.localPosition;
					vector.Set(x - 46f, vector.y, -490f);
					component11.localPosition = vector;
					num12++;
					this.EnemyCount += 1;
				}
			}
		}
		if (this.DS._stageMode == StageMode.Dare)
		{
			this.SetRewardOrEnemy();
			this.Power.enabled = false;
			this.m_transform.GetChild(15).gameObject.SetActive(false);
			this.m_transform.GetChild(26).gameObject.SetActive(false);
			this.m_transform.GetChild(6).gameObject.SetActive(false);
			this.m_transform.GetChild(7).gameObject.SetActive(false);
			this.m_transform.GetChild(9).gameObject.SetActive(false);
			Vector2 b = new Vector2(0f, 54f);
			((RectTransform)this.m_transform.GetChild(5)).anchoredPosition += b;
			((RectTransform)this.m_transform.GetChild(35)).anchoredPosition += b;
			((RectTransform)this.m_transform.GetChild(36)).anchoredPosition += b;
			((RectTransform)this.m_transform.GetChild(37)).anchoredPosition += b;
			((RectTransform)this.m_transform.GetChild(38)).anchoredPosition += b;
			((RectTransform)this.m_transform.GetChild(39)).anchoredPosition += b;
			((RectTransform)this.m_transform.GetChild(41)).anchoredPosition += b;
			((RectTransform)this.m_transform.GetChild(50)).anchoredPosition += b;
			this.m_transform.GetChild(58).gameObject.SetActive(true);
			this.NodusTitle = this.m_transform.GetChild(58).GetChild(0).GetComponent<UIText>();
			this.NodusTitle.font = ttffont;
			this.NodusTitle.text = this.DM.mStringTable.GetStringByID(10005u);
			for (int num14 = 0; num14 < 8; num14++)
			{
				this.ConditionGO[num14] = this.m_transform.GetChild(59 + num14).gameObject;
				this.ConditionBtn[num14] = this.m_transform.GetChild(59 + num14).GetChild(0).GetComponent<UIButton>();
				this.ConditionBtn[num14].m_Handler = this;
				UIButtonHint uibuttonHint = this.ConditionBtn[num14].gameObject.AddComponent<UIButtonHint>();
				uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
				uibuttonHint.m_DownUpHandler = this;
			}
			this.HinString = this.SM.SpawnString(1024);
			if (this.DS.StageDareMode(this.DS.currentPointID) == StageMode.Lean)
			{
				for (int num15 = 0; num15 < 3; num15++)
				{
					this.NodusBtn[num15] = this.m_transform.GetChild(67 + num15).GetComponent<UIButton>();
					this.NodusBtn[num15].m_Handler = this;
					this.NodusBtn[num15].m_BtnID1 = 11;
					this.NodusBtn[num15].m_BtnID2 = num15 + 1;
					this.NodusBtn[num15].gameObject.SetActive(true);
					this.NodusBtnLight[num15] = this.m_transform.GetChild(67 + num15).GetChild(0).gameObject;
					this.NodusBtnLock[num15] = this.m_transform.GetChild(67 + num15).GetChild(2).gameObject;
				}
				this.TicketImgT = this.m_transform.GetChild(11);
				this.TicketImgT.gameObject.SetActive(true);
				this.m_transform.GetChild(11).GetChild(0).gameObject.SetActive(true);
				this.NodusTitle2 = this.m_transform.GetChild(11).GetChild(0).GetComponent<UIText>();
				this.NodusTitle2.font = ttffont;
				this.NodusTitle2.text = this.DM.mStringTable.GetStringByID(1006u);
			}
			this.SetNodus(-1);
		}
		Door x2 = this.GM.FindMenu(EGUIWindow.Door) as Door;
		if (x2 != null)
		{
			RectTransform canvasRT2 = this.GM.pDVMgr.CanvasRT;
			RectTransform component12 = this.m_transform.GetChild(1).GetComponent<RectTransform>();
			Vector3 localPosition = this.m_transform.GetChild(21).localPosition;
			float num16 = (component12.localPosition.x + component12.sizeDelta.x * 0.5f + canvasRT2.sizeDelta.x * 0.5f) * 0.5f;
			localPosition.Set(num16, localPosition.y, localPosition.z);
			this.m_transform.GetChild(21).localPosition = localPosition;
			localPosition = this.m_transform.GetChild(22).localPosition;
			localPosition.Set(num16 - 46.5f, localPosition.y, localPosition.z);
			this.m_transform.GetChild(22).localPosition = localPosition;
			localPosition = this.m_transform.GetChild(23).localPosition;
			localPosition.Set(num16 + 46.5f, localPosition.y, localPosition.z);
			this.m_transform.GetChild(23).localPosition = localPosition;
			if (this.DS._stageMode != StageMode.Dare)
			{
				localPosition = this.TicketImgT.localPosition;
				localPosition.Set(num16, localPosition.y, localPosition.z);
				this.TicketImgT.localPosition = localPosition;
				localPosition = this.TicketImgT2.localPosition;
				localPosition.Set(num16, localPosition.y, localPosition.z);
				this.TicketImgT2.localPosition = localPosition;
				localPosition = this.TicketNumT.localPosition;
				localPosition.Set(num16 + 1.5f, localPosition.y, localPosition.z);
				this.TicketNumT.localPosition = localPosition;
				localPosition = this.m_transform.GetChild(25).localPosition;
				localPosition.Set(num16 + 2f, localPosition.y, localPosition.z);
				this.m_transform.GetChild(25).localPosition = localPosition;
				localPosition = this.m_transform.GetChild(24).localPosition;
				localPosition.Set(num16 + 2f, localPosition.y, localPosition.z);
				this.m_transform.GetChild(24).localPosition = localPosition;
				localPosition = this.m_transform.GetChild(53).localPosition;
				localPosition.Set(num16 + 21f, localPosition.y, localPosition.z);
				this.m_transform.GetChild(53).localPosition = localPosition;
				localPosition = this.m_transform.GetChild(54).localPosition;
				localPosition.Set(num16 + 21f, localPosition.y, localPosition.z);
				this.m_transform.GetChild(54).localPosition = localPosition;
			}
			else if (this.NodusBtn[0] != null)
			{
				localPosition = this.TicketImgT.localPosition;
				localPosition.Set(num16, localPosition.y, localPosition.z);
				this.TicketImgT.localPosition = localPosition;
				localPosition = this.NodusBtn[0].transform.localPosition;
				localPosition.Set(num16 + 2f, localPosition.y, localPosition.z);
				this.NodusBtn[0].transform.localPosition = localPosition;
				localPosition = this.NodusBtn[1].transform.localPosition;
				localPosition.Set(num16 + 2f, localPosition.y, localPosition.z);
				this.NodusBtn[1].transform.localPosition = localPosition;
				localPosition = this.NodusBtn[2].transform.localPosition;
				localPosition.Set(num16 + 2f, localPosition.y, localPosition.z);
				this.NodusBtn[2].transform.localPosition = localPosition;
			}
		}
		this.GM.UpdateUI(EGUIWindow.Door, 1, 6);
		if (!NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, this, false) && (int)this.DM.RoleAttr.Morale >= this.NeedMorale)
		{
			NewbieManager.CheckWipeOutTeach();
		}
	}

	// Token: 0x0600186F RID: 6255 RVA: 0x00291734 File Offset: 0x0028F934
	public override void OnClose()
	{
		if (this.tmpString != null)
		{
			this.SM.DeSpawnString(this.tmpString);
			this.tmpString = null;
		}
		if (this.tmpString2 != null)
		{
			this.SM.DeSpawnString(this.tmpString2);
			this.tmpString2 = null;
		}
		if (this.tmpString3 != null)
		{
			this.SM.DeSpawnString(this.tmpString3);
			this.tmpString3 = null;
		}
		if (this.StageNameStr != null)
		{
			this.SM.DeSpawnString(this.StageNameStr);
			this.StageNameStr = null;
		}
		if (this.HinString != null)
		{
			this.SM.DeSpawnString(this.HinString);
			this.HinString = null;
		}
		if (this.BossGO != null)
		{
			ModelLoader.Instance.Unload(this.BossGO);
			this.BossGO = null;
		}
		if (this.AssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey, true);
		}
	}

	// Token: 0x06001870 RID: 6256 RVA: 0x00291834 File Offset: 0x0028FA34
	public override bool OnBackButtonClick()
	{
		this.DS.ReBackCurrentChapter();
		return false;
	}

	// Token: 0x06001871 RID: 6257 RVA: 0x00291844 File Offset: 0x0028FA44
	private void Update()
	{
		if (!this.bABInitial && this.AR != null && this.AR.isDone)
		{
			this.bABInitial = true;
			this.BossGO = ModelLoader.Instance.Load(this.sHero.Modle, this.AB, (ushort)this.sHero.TextureNo);
			this.BossGO.transform.SetParent(this.m_transform, false);
			this.BossGO.transform.localPosition = this.ActorPos;
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
				for (int i = 0; i < this.ANIndex.Length; i++)
				{
					byte b = (byte)this.ANIndex[i];
					if (this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[(int)b]) != null)
					{
						this.tmpAN[AnimationUnit.ANIM_STRING[(int)b]].layer = 1;
						this.tmpAN[AnimationUnit.ANIM_STRING[(int)b]].wrapMode = WrapMode.Once;
						this.ANList.Add(this.ANIndex[i]);
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

	// Token: 0x06001872 RID: 6258 RVA: 0x00291B70 File Offset: 0x0028FD70
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			switch (networkNews)
			{
			case NetworkNews.Refresh_Morale:
			case NetworkNews.Refresh_VIP:
				break;
			case NetworkNews.Refresh_MonsterPoint:
				return;
			case NetworkNews.Refresh_FontTextureRebuilt:
				if (this.TicketNum != null && this.TicketNum.enabled)
				{
					this.TicketNum.enabled = false;
					this.TicketNum.enabled = true;
				}
				if (this.StageName != null && this.StageName.enabled)
				{
					this.StageName.enabled = false;
					this.StageName.enabled = true;
				}
				if (this.StageName2 != null && this.StageName2.enabled)
				{
					this.StageName2.enabled = false;
					this.StageName2.enabled = true;
				}
				if (this.Power != null && this.Power.enabled)
				{
					this.Power.enabled = false;
					this.Power.enabled = true;
				}
				if (this.Times != null && this.Times.enabled)
				{
					this.Times.enabled = false;
					this.Times.enabled = true;
				}
				if (this.Story != null && this.Story.enabled)
				{
					this.Story.enabled = false;
					this.Story.enabled = true;
				}
				if (this.Rewards != null && this.Rewards.enabled)
				{
					this.Rewards.enabled = false;
					this.Rewards.enabled = true;
				}
				if (this.Enemy != null && this.Enemy.enabled)
				{
					this.Enemy.enabled = false;
					this.Enemy.enabled = true;
				}
				if (this.NPCName != null && this.NPCName.enabled)
				{
					this.NPCName.enabled = false;
					this.NPCName.enabled = true;
				}
				if (this.Play10Text != null && this.Play10Text.enabled)
				{
					this.Play10Text.enabled = false;
					this.Play10Text.enabled = true;
				}
				if (this.Play1Text != null && this.Play1Text.enabled)
				{
					this.Play1Text.enabled = false;
					this.Play1Text.enabled = true;
				}
				if (this.RBRewardBtn != null)
				{
					for (int i = 0; i < this.RBRewardBtn.Length; i++)
					{
						if (this.RBRewardBtn[i] != null)
						{
							this.RBRewardBtn[i].Refresh_FontTexture();
						}
					}
				}
				if (this.NodusTitle != null && this.NodusTitle.enabled)
				{
					this.NodusTitle.enabled = false;
					this.NodusTitle.enabled = true;
				}
				if (this.NodusTitle2 != null && this.NodusTitle2.enabled)
				{
					this.NodusTitle2.enabled = false;
					this.NodusTitle2.enabled = true;
				}
				return;
			default:
				return;
			}
			break;
		case NetworkNews.Refresh_Asset:
			if (meg[1] == 1 && meg[2] == 2 && GameConstants.ConvertBytesToUShort(meg, 3) == this.sHero.Modle)
			{
				this.LoadAB(true);
			}
			return;
		}
		this.OpenRefresh();
		this.SetNodusBtnState();
	}

	// Token: 0x06001873 RID: 6259 RVA: 0x00291F2C File Offset: 0x0029012C
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

	// Token: 0x06001874 RID: 6260 RVA: 0x00291FFC File Offset: 0x002901FC
	private void SetRewardOrEnemy()
	{
		if (this.RewardOrEnemy == 0)
		{
			this.RewardOrEnemy = 1;
			this.Rewards.gameObject.SetActive(false);
			this.Enemy.gameObject.SetActive(true);
			this.BossImg2.gameObject.SetActive(true);
			this.SArray1.SetSpriteIndex(0);
			this.SArray2.SetSpriteIndex(0);
			for (int i = 0; i < 7; i++)
			{
				if (this.RewardBtnT[i] != null)
				{
					this.RewardBtnT[i].gameObject.SetActive(false);
				}
			}
			if (this.ScrollT != null)
			{
				this.ScrollT.gameObject.SetActive(false);
			}
			for (int j = 0; j < (int)this.EnemyCount; j++)
			{
				this.EnemyBtnT[j].gameObject.SetActive(true);
			}
		}
		else if (this.RewardOrEnemy == 1)
		{
			this.RewardOrEnemy = 0;
			this.Rewards.gameObject.SetActive(true);
			this.Enemy.gameObject.SetActive(false);
			this.BossImg2.gameObject.SetActive(false);
			this.SArray1.SetSpriteIndex(1);
			this.SArray2.SetSpriteIndex(1);
			for (int k = 0; k < (int)this.EnemyCount; k++)
			{
				this.EnemyBtnT[k].gameObject.SetActive(false);
			}
			int num = 0;
			int num2 = (int)this.RewardCount;
			if (this.bHaveTargetItem)
			{
				this.RewardBtnT[0].gameObject.SetActive(true);
				num = 1;
				num2++;
			}
			if (this.ScrollT != null)
			{
				this.ScrollT.gameObject.SetActive(true);
			}
			for (int l = num; l < num2; l++)
			{
				if (this.RewardBtnT[l] != null)
				{
					this.RewardBtnT[l].gameObject.SetActive(true);
				}
			}
		}
	}

	// Token: 0x06001875 RID: 6261 RVA: 0x00292208 File Offset: 0x00290408
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (sender.m_BtnID1 != 2)
		{
			if (sender.m_BtnID1 == 3)
			{
			}
		}
	}

	// Token: 0x06001876 RID: 6262 RVA: 0x00292228 File Offset: 0x00290428
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			bool flag = this.DS._stageMode == StageMode.Lean;
			if (flag && this.MaxStageTimes != 255 && this.StageTimes >= this.MaxStageTimes)
			{
				this.GM.MsgStr.Length = 0;
				this.GM.MsgStr.IntToFormat((long)this.MaxStageTimes, 1, false);
				this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(811u));
				this.GM.OpenOKCancelBox(8, this.DM.mStringTable.GetStringByID(5811u), this.GM.MsgStr.ToString(), 0, 0, this.DM.mStringTable.GetStringByID(4507u), this.DM.mStringTable.GetStringByID(617u));
				return;
			}
			if (sender.m_BtnID2 == 1)
			{
				if (this.DS._stageMode == StageMode.Dare || (int)this.DM.RoleAttr.Morale >= this.NeedMorale)
				{
					Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
					if (door != null)
					{
						AssetManager.UnloadAssetBundle(this.AssetKey, true);
						this.AssetKey = 0;
						if (this.GM.bBackInPreviewModel)
						{
							this.GM.bBackInPreviewModel = !this.GM.bBackInPreviewModel;
							this.GM.BackInPreviewHight = 0f;
						}
						door.OpenMenu(EGUIWindow.UI_BattleHeroSelect, 0, 0, true);
					}
				}
				else
				{
					this.GM.UseOrSpend(this.MoraleItemID, this.DM.mStringTable.GetStringByID(1505u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
				}
			}
			else if (sender.m_BtnID2 == 2)
			{
				if ((int)this.DM.RoleAttr.Morale >= this.NeedMorale)
				{
					this.GM.SendQuickBattle(GUIManager.EQuickFightKind.EQFK_Normal, (!flag) ? GUIManager.EStageKind.ESK_Normal : GUIManager.EStageKind.ESK_Advance, this.DS.currentPointID);
					this.DM.QBMorale = (ushort)this.NeedMorale;
				}
				else
				{
					this.GM.UseOrSpend(this.MoraleItemID, this.DM.mStringTable.GetStringByID(1505u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
				}
			}
			else if (sender.m_BtnID2 == 3)
			{
				if ((int)this.DM.RoleAttr.Morale >= this.NeedMorale)
				{
					this.GM.SendQuickBattle(GUIManager.EQuickFightKind.EQFK_VIP, (!flag) ? GUIManager.EStageKind.ESK_Normal : GUIManager.EStageKind.ESK_Advance, this.DS.currentPointID);
					this.DM.QBMorale = (ushort)this.NeedMorale;
				}
				else
				{
					this.GM.UseOrSpend(this.MoraleItemID, this.DM.mStringTable.GetStringByID(1505u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
				}
			}
		}
		else if (sender.m_BtnID1 == 4)
		{
			if (sender.m_BtnID2 == 1)
			{
				this.SetRewardOrEnemy();
			}
			else if (sender.m_BtnID2 == 2)
			{
			}
		}
		else if (sender.m_BtnID1 == 5)
		{
			this.DS.ReBackCurrentChapter();
			AssetManager.UnloadAssetBundle(this.AssetKey, true);
			this.AssetKey = 0;
			(this.GM.FindMenu(EGUIWindow.Door) as Door).CloseMenu(false);
		}
		else if (sender.m_BtnID1 == 11)
		{
			this.SetNodus(sender.m_BtnID2);
		}
	}

	// Token: 0x06001877 RID: 6263 RVA: 0x002925CC File Offset: 0x002907CC
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		if (uibutton != null)
		{
			this.DS.GetStageConditionString(this.HinString, (byte)uibutton.m_BtnID2, (ushort)uibutton.m_BtnID3, (ushort)uibutton.m_BtnID4, this.ConditionKey);
			this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 280f, 20, this.HinString, Vector2.zero);
		}
	}

	// Token: 0x06001878 RID: 6264 RVA: 0x00292644 File Offset: 0x00290844
	public void OnButtonUp(UIButtonHint sender)
	{
		this.GM.m_Hint.Hide(false);
	}

	// Token: 0x06001879 RID: 6265 RVA: 0x00292658 File Offset: 0x00290858
	public void OpenRefresh()
	{
		if (this.DS._stageMode != StageMode.Dare)
		{
			Chapter recordByKey = this.DS.ChapterTable.GetRecordByKey((ushort)this.DS.currentChapterID);
			if (this.DS._stageMode == StageMode.Lean)
			{
				this.MaxStageTimes = (int)this.DM.VIPLevelTable.GetRecordByKey((ushort)this.DM.RoleAttr.VIPLevel).DailyResetElite;
				this.StageTimes = (this.DS.StageInfo[1][(int)(this.DS.currentPointID - 1)] >> 2 & 63);
				this.tmpString.Length = 0;
				if (this.MaxStageTimes == 255)
				{
					this.tmpString.Append(this.DM.mStringTable.GetStringByID(5810u));
				}
				else
				{
					this.CanFightStageTimes = this.MaxStageTimes - this.StageTimes;
					if (this.CanFightStageTimes <= 0)
					{
						this.CanFightStageTimes = 0;
						this.tmpString.StringToFormat("<color=#ff0000>0</color>");
					}
					else
					{
						this.tmpString.IntToFormat((long)this.CanFightStageTimes, 1, false);
					}
					this.tmpString.IntToFormat((long)this.MaxStageTimes, 1, false);
					this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(47u));
				}
				this.Times.text = this.tmpString.ToString();
				this.Times.SetAllDirty();
				this.Times.cachedTextGenerator.Invalidate();
			}
			this.NeedMorale = (int)(recordByKey.Power * ((this.DS._stageMode != StageMode.Lean) ? 1 : 2));
			int num = (int)this.DM.RoleAttr.Morale / this.NeedMorale;
			if (this.DS._stageMode == StageMode.Lean)
			{
				if (this.MaxStageTimes == 255)
				{
					if (num > 10)
					{
						num = 10;
					}
				}
				else if (num > this.CanFightStageTimes)
				{
					num = this.CanFightStageTimes;
				}
			}
			StringManager.IntToStr(this.tmpString3, (long)((num <= 10) ? num : 10), 1, false);
			this.Play10Text.text = this.tmpString3.ToString();
			this.Play10Text.SetAllDirty();
			this.Play10Text.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x0600187A RID: 6266 RVA: 0x002928C4 File Offset: 0x00290AC4
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x0600187B RID: 6267 RVA: 0x00292908 File Offset: 0x00290B08
	public override void ReOnOpen()
	{
	}

	// Token: 0x0600187C RID: 6268 RVA: 0x0029290C File Offset: 0x00290B0C
	public void SetNodus(int Nodus)
	{
		int num = 0;
		LevelEX levelEXBycurrentPointID = this.DS.GetLevelEXBycurrentPointID(0);
		if (this.DS.StageDareMode(this.DS.currentPointID) == StageMode.Lean)
		{
			int stagePoint = this.DS.GetStagePoint(0, 0);
			if (Nodus == -1)
			{
				if (this.GM.UIPointID == this.DS.currentPointID && this.GM.UINodus != 0)
				{
					Nodus = (int)this.DS.currentNodus;
					if (Nodus > this.DS.GetStagePoint(0, 0) + 1)
					{
						Nodus = stagePoint + 1;
					}
				}
				else
				{
					Nodus = stagePoint + 1;
				}
			}
			if (Nodus > 3)
			{
				Nodus = 3;
			}
			if (Nodus > this.DS.GetStagePoint(0, 0) + 1)
			{
				this.GM.MsgStr.Length = 0;
				this.GM.MsgStr.IntToFormat((long)(this.DS.GetStagePoint(0, 0) + 1), 1, false);
				this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(1034u));
				this.GM.AddHUDMessage(this.GM.MsgStr.ToString(), 255, true);
				return;
			}
			this.DS.currentNodus = (byte)Nodus;
			this.GM.UIPointID = this.DS.currentPointID;
			this.GM.UINodus = (byte)Nodus;
			if (Nodus == 1)
			{
				this.ConditionKey = levelEXBycurrentPointID.NodusOneID;
			}
			else if (Nodus == 2)
			{
				this.ConditionKey = levelEXBycurrentPointID.NodusTwoID;
			}
			else if (Nodus == 3)
			{
				this.ConditionKey = levelEXBycurrentPointID.NodusThrID;
			}
			this.SetNodusBtnState();
		}
		else
		{
			this.ConditionKey = levelEXBycurrentPointID.NodusTwoID;
			this.DS.currentNodus = 0;
		}
		StageConditionData recordByKey = this.DS.StageConditionDataTable.GetRecordByKey(this.ConditionKey);
		for (int i = 0; i < 7; i++)
		{
			if (recordByKey.ConditionArray[i].ConditionID > 0)
			{
				this.ConditionBtn[i].image.sprite = this.DS.GetStageConditionSprite(recordByKey.ConditionArray[i].ConditionID, recordByKey.ConditionArray[i].FactorA, recordByKey.ConditionArray[i].FactorB);
				this.ConditionBtn[i].image.material = this.DS.GetStageConditionMaterial(recordByKey.ConditionArray[i].ConditionID);
				this.ConditionBtn[i].m_BtnID2 = (int)recordByKey.ConditionArray[i].ConditionID;
				this.ConditionBtn[i].m_BtnID3 = (int)recordByKey.ConditionArray[i].FactorA;
				this.ConditionBtn[i].m_BtnID4 = (int)recordByKey.ConditionArray[i].FactorB;
				this.ConditionBtn[i].gameObject.SetActive(true);
				this.ConditionGO[i].gameObject.SetActive(true);
				num++;
			}
			else
			{
				this.ConditionGO[i].gameObject.SetActive(false);
			}
		}
		if (num < 8)
		{
			this.ConditionBtn[num].image.sprite = this.DS.GetStageConditionSprite(byte.MaxValue, 0, 0);
			this.ConditionBtn[num].image.material = this.DS.GetStageConditionMaterial(byte.MaxValue);
			this.ConditionBtn[num].m_BtnID2 = 255;
			this.ConditionBtn[num].gameObject.SetActive(true);
			this.ConditionGO[num].gameObject.SetActive(true);
		}
	}

	// Token: 0x0600187D RID: 6269 RVA: 0x00292CE4 File Offset: 0x00290EE4
	private void SetNodusBtnState()
	{
		if (this.NodusBtn[0] != null)
		{
			int stagePoint = this.DS.GetStagePoint(0, 0);
			for (int i = 0; i < this.NodusBtn.Length; i++)
			{
				if (i + 1 == (int)this.DS.currentNodus)
				{
					this.NodusBtnLight[i].SetActive(true);
				}
				else
				{
					this.NodusBtnLight[i].SetActive(false);
				}
				if (i > stagePoint)
				{
					this.NodusBtnLock[i].SetActive(true);
				}
				else
				{
					this.NodusBtnLock[i].SetActive(false);
				}
			}
		}
	}

	// Token: 0x0600187E RID: 6270 RVA: 0x00292D88 File Offset: 0x00290F88
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
		CString cstring = this.SM.StaticString1024();
		cstring.IntToFormat((long)this.sHero.Modle, 5, false);
		cstring.AppendFormat("Role/hero_{0}");
		this.AB = AssetManager.GetAssetBundle(cstring, out this.AssetKey);
		if (this.AB != null)
		{
			this.AR = this.AB.LoadAsync("m", typeof(GameObject));
			this.bABInitial = false;
		}
	}

	// Token: 0x040047FA RID: 18426
	private Transform m_transform;

	// Token: 0x040047FB RID: 18427
	public Transform Play10T;

	// Token: 0x040047FC RID: 18428
	public Transform Play1T;

	// Token: 0x040047FD RID: 18429
	public Transform Play10TextT;

	// Token: 0x040047FE RID: 18430
	public Transform Play1TextT;

	// Token: 0x040047FF RID: 18431
	public Transform TicketImgT;

	// Token: 0x04004800 RID: 18432
	public Transform TicketNumT;

	// Token: 0x04004801 RID: 18433
	public Transform TicketImgT2;

	// Token: 0x04004802 RID: 18434
	public Transform ScrollT;

	// Token: 0x04004803 RID: 18435
	private Transform[] RewardBtnT = new Transform[7];

	// Token: 0x04004804 RID: 18436
	private Transform[] EnemyBtnT = new Transform[5];

	// Token: 0x04004805 RID: 18437
	private Transform BossImg1;

	// Token: 0x04004806 RID: 18438
	private Transform BossImg2;

	// Token: 0x04004807 RID: 18439
	private Transform[] StarT = new Transform[3];

	// Token: 0x04004808 RID: 18440
	private UIText TicketNum;

	// Token: 0x04004809 RID: 18441
	private UIText StageName;

	// Token: 0x0400480A RID: 18442
	private UIText StageName2;

	// Token: 0x0400480B RID: 18443
	private UIText Power;

	// Token: 0x0400480C RID: 18444
	private UIText Times;

	// Token: 0x0400480D RID: 18445
	private UIText Story;

	// Token: 0x0400480E RID: 18446
	private UIText Rewards;

	// Token: 0x0400480F RID: 18447
	private UIText Enemy;

	// Token: 0x04004810 RID: 18448
	private UIText NPCName;

	// Token: 0x04004811 RID: 18449
	private UIText Play10Text;

	// Token: 0x04004812 RID: 18450
	private UIText Play1Text;

	// Token: 0x04004813 RID: 18451
	private GameObject NormalObj;

	// Token: 0x04004814 RID: 18452
	private GameObject EliteObj1;

	// Token: 0x04004815 RID: 18453
	private GameObject EliteObj2;

	// Token: 0x04004816 RID: 18454
	private GameObject DareObj1;

	// Token: 0x04004817 RID: 18455
	private GameObject DareObj2;

	// Token: 0x04004818 RID: 18456
	private CString tmpString;

	// Token: 0x04004819 RID: 18457
	private CString tmpString2;

	// Token: 0x0400481A RID: 18458
	private CString StageNameStr;

	// Token: 0x0400481B RID: 18459
	private CString tmpString3;

	// Token: 0x0400481C RID: 18460
	private int AssetKey;

	// Token: 0x0400481D RID: 18461
	private byte RewardOrEnemy;

	// Token: 0x0400481E RID: 18462
	private byte EnemyCount;

	// Token: 0x0400481F RID: 18463
	private byte RewardCount;

	// Token: 0x04004820 RID: 18464
	private Vector2 tmpVec2 = Vector2.zero;

	// Token: 0x04004821 RID: 18465
	private Vector3 tmpVec3 = Vector3.zero;

	// Token: 0x04004822 RID: 18466
	private bool bHaveTargetItem;

	// Token: 0x04004823 RID: 18467
	private UISpritesArray SArray1;

	// Token: 0x04004824 RID: 18468
	private UISpritesArray SArray2;

	// Token: 0x04004825 RID: 18469
	private float IconSize = 80f;

	// Token: 0x04004826 RID: 18470
	private float IconDelta = 87f;

	// Token: 0x04004827 RID: 18471
	private int NeedMorale;

	// Token: 0x04004828 RID: 18472
	private int StageTimes;

	// Token: 0x04004829 RID: 18473
	private int MaxStageTimes;

	// Token: 0x0400482A RID: 18474
	private int CanFightStageTimes;

	// Token: 0x0400482B RID: 18475
	private GameObject BossGO;

	// Token: 0x0400482C RID: 18476
	private AssetBundle AB;

	// Token: 0x0400482D RID: 18477
	private AssetBundleRequest AR;

	// Token: 0x0400482E RID: 18478
	private bool bABInitial;

	// Token: 0x0400482F RID: 18479
	private Vector3 ActorPos;

	// Token: 0x04004830 RID: 18480
	private Hero sHero;

	// Token: 0x04004831 RID: 18481
	private Animation tmpAN;

	// Token: 0x04004832 RID: 18482
	private string HeroAct;

	// Token: 0x04004833 RID: 18483
	private float ActionTime;

	// Token: 0x04004834 RID: 18484
	private float ActionTimeRandom;

	// Token: 0x04004835 RID: 18485
	private AnimationUnit.AnimName[] ANIndex = new AnimationUnit.AnimName[]
	{
		AnimationUnit.AnimName.ATTACK,
		AnimationUnit.AnimName.SKILL1,
		AnimationUnit.AnimName.SKILL2,
		AnimationUnit.AnimName.SKILL3,
		AnimationUnit.AnimName.VICTORY
	};

	// Token: 0x04004836 RID: 18486
	private List<AnimationUnit.AnimName> ANList = new List<AnimationUnit.AnimName>();

	// Token: 0x04004837 RID: 18487
	private ushort MoraleItemID = 1115;

	// Token: 0x04004838 RID: 18488
	private UIHIBtn[] RBRewardBtn = new UIHIBtn[7];

	// Token: 0x04004839 RID: 18489
	private DataManager DM;

	// Token: 0x0400483A RID: 18490
	private StageManager DS;

	// Token: 0x0400483B RID: 18491
	private GUIManager GM;

	// Token: 0x0400483C RID: 18492
	private StringManager SM;

	// Token: 0x0400483D RID: 18493
	private ushort ConditionKey;

	// Token: 0x0400483E RID: 18494
	private UIButton[] NodusBtn = new UIButton[3];

	// Token: 0x0400483F RID: 18495
	private GameObject[] NodusBtnLight = new GameObject[3];

	// Token: 0x04004840 RID: 18496
	private GameObject[] NodusBtnLock = new GameObject[3];

	// Token: 0x04004841 RID: 18497
	private UIButton[] ConditionBtn = new UIButton[8];

	// Token: 0x04004842 RID: 18498
	private GameObject[] ConditionGO = new GameObject[8];

	// Token: 0x04004843 RID: 18499
	private Text NodusTitle;

	// Token: 0x04004844 RID: 18500
	private Text NodusTitle2;

	// Token: 0x04004845 RID: 18501
	private CString HinString;
}
