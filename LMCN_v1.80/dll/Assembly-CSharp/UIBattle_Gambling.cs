using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001F6 RID: 502
public class UIBattle_Gambling : GUIWindow, IUIButtonClickHandler, IUIUpdatePos, IUIHIBtnClickHandler
{
	// Token: 0x06000948 RID: 2376 RVA: 0x000BDCA4 File Offset: 0x000BBEA4
	public UIBattle_Gambling()
	{
		int[] array = new int[4];
		array[0] = 3;
		array[1] = 2;
		array[2] = 1;
		this.animR_Idle_Idx = array;
		this.animR_S1 = new int[]
		{
			2,
			8,
			10,
			80
		};
		this.animR_S1_Idx = new int[]
		{
			3,
			2,
			0,
			1
		};
		this.animR_S2 = new int[]
		{
			2,
			8,
			10,
			80
		};
		this.animR_S2_Idx = new int[]
		{
			0,
			3,
			1,
			2
		};
		this.animR_S3 = new int[]
		{
			2,
			8,
			10,
			80
		};
		this.animR_S3_Idx = new int[]
		{
			0,
			1,
			2,
			3
		};
		this.anim_R = new int[4];
		this.anim_Idx = new int[4];
		this.DisplayQueue = new List<byte>();
		base();
	}

	// Token: 0x0600094A RID: 2378 RVA: 0x000BDEB8 File Offset: 0x000BC0B8
	public override void OnOpen(int arg1, int arg2)
	{
		this.SpawnString();
		this.InitUI();
		this.InitSP();
		this.UpdateUI(3, 0);
		this.UpdateUI(2, 0);
		this.DisplayQueue.Clear();
		this.TextDisplayTime = null;
		UIHintMask.bPassThrough = false;
		this.GUIM.CheckBattleAttackState();
	}

	// Token: 0x0600094B RID: 2379 RVA: 0x000BDF14 File Offset: 0x000BC114
	public override void OnClose()
	{
		if (this.BGT != null)
		{
			UnityEngine.Object.Destroy(this.BGT.gameObject);
		}
		GUIManager.Instance.pDVMgr.EndMoveBossText();
		AssetManager.UnloadAssetBundle(this.AssetKey, true);
		AssetManager.UnloadAssetBundle(this.AssetKey2, true);
		this.DeSpawnString();
		if (this.EffectObj != null)
		{
			for (int i = 0; i < this.EffectObj.Length; i++)
			{
				ParticleManager.Instance.DeSpawn(this.EffectObj[i]);
				this.EffectObj[i] = null;
			}
		}
		this.mItemList.Clear();
		if (GamblingManager.Instance.m_QueueGamebleItem != null)
		{
			GamblingManager.Instance.m_QueueGamebleItem.Clear();
		}
		UIHintMask.bPassThrough = true;
		LordEquipData.Instance().Scan_MaterialOrEquipIncreace();
	}

	// Token: 0x0600094C RID: 2380 RVA: 0x000BDFE8 File Offset: 0x000BC1E8
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
			this.UpdateUI(3, 0);
			this.UpdateUI(2, 0);
			this.UpdateMoney();
			this.CDTime = 0f;
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Item)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				this.UpdateUI(8, 0);
			}
			break;
		case NetworkNews.Refresh:
			this.UpdateMoney();
			break;
		}
	}

	// Token: 0x0600094D RID: 2381 RVA: 0x000BE068 File Offset: 0x000BC268
	public void Refresh_FontTexture()
	{
		if (this.text_Hint != null && this.text_Hint.enabled)
		{
			this.text_Hint.enabled = false;
			this.text_Hint.enabled = true;
		}
		if (this.text_Hint2 != null && this.text_Hint2.enabled)
		{
			this.text_Hint2.enabled = false;
			this.text_Hint2.enabled = true;
		}
		if (this.btn_ChangeModel_Normal != null && this.btn_ChangeModel_Normal.enabled)
		{
			this.btn_ChangeModel_Normal.enabled = false;
			this.btn_ChangeModel_Normal.enabled = true;
		}
		if (this.btn_ChangeModel_Turbo != null && this.btn_ChangeModel_Turbo.enabled)
		{
			this.btn_ChangeModel_Turbo.enabled = false;
			this.btn_ChangeModel_Turbo.enabled = true;
		}
		if (this.text_TimeValue != null && this.text_TimeValue.enabled)
		{
			this.text_TimeValue.enabled = false;
			this.text_TimeValue.enabled = true;
		}
		if (this.text_CostValue != null && this.text_CostValue.enabled)
		{
			this.text_CostValue.enabled = false;
			this.text_CostValue.enabled = true;
		}
		if (this.textNpcHpValue != null && this.textNpcHpValue.enabled)
		{
			this.textNpcHpValue.enabled = false;
			this.textNpcHpValue.enabled = true;
		}
		if (this.textNpcHpName != null && this.textNpcHpName.enabled)
		{
			this.textNpcHpName.enabled = false;
			this.textNpcHpName.enabled = true;
		}
		if (this.mJackPotUI != null)
		{
			for (int i = 0; i < this.mJackPotUI.Length; i++)
			{
				if (this.mJackPotUI[i].Name != null && this.mJackPotUI[i].Name.enabled)
				{
					this.mJackPotUI[i].Name.enabled = false;
					this.mJackPotUI[i].Name.enabled = true;
				}
				if (this.mJackPotUI[i].Num != null && this.mJackPotUI[i].Num.enabled)
				{
					this.mJackPotUI[i].Num.enabled = false;
					this.mJackPotUI[i].Num.enabled = true;
				}
				if (this.mJackPotUI[i].Time != null && this.mJackPotUI[i].Time.enabled)
				{
					this.mJackPotUI[i].Time.enabled = false;
					this.mJackPotUI[i].Time.enabled = true;
				}
			}
		}
		for (int j = 0; j < 6; j++)
		{
			if (this.text_ItmeNum[j] != null && this.text_ItmeNum[j].enabled)
			{
				this.text_ItmeNum[j].enabled = false;
				this.text_ItmeNum[j].enabled = true;
			}
		}
		if (this.btn_Item != null)
		{
			for (int k = 0; k < this.btn_Item.Length; k++)
			{
				if (this.btn_Item[k] != null)
				{
					this.btn_Item[k].Refresh_FontTexture();
				}
			}
		}
		if (this.btn_Item2 != null)
		{
			for (int l = 0; l < this.btn_Item2.Length; l++)
			{
				if (this.btn_Item2[l] != null)
				{
					LordEquipData.ResetLordEquipFont(this.btn_Item2[l]);
				}
			}
		}
		if (this.RunningText != null)
		{
			if (this.RunningText.m_RunningText1 != null && this.RunningText.m_RunningText1.enabled)
			{
				this.RunningText.m_RunningText1.enabled = false;
				this.RunningText.m_RunningText1.enabled = true;
			}
			if (this.RunningText.m_RunningText2 != null && this.RunningText.m_RunningText2.enabled)
			{
				this.RunningText.m_RunningText2.enabled = false;
				this.RunningText.m_RunningText2.enabled = true;
			}
		}
		if (this.text_ComboCount != null && this.text_ComboCount.enabled)
		{
			this.text_ComboCount.enabled = false;
			this.text_ComboCount.enabled = true;
		}
		if (this.text_Combo != null && this.text_Combo.enabled)
		{
			this.text_Combo.enabled = false;
			this.text_Combo.enabled = true;
		}
		if (this.textPrize != null && this.textPrize.enabled)
		{
			this.textPrize.enabled = false;
			this.textPrize.enabled = true;
		}
		if (this.text_ChangeModel_Normal != null && this.text_ChangeModel_Normal.enabled)
		{
			this.text_ChangeModel_Normal.enabled = false;
			this.text_ChangeModel_Normal.enabled = true;
		}
		if (this.text_ChangeModel_Turbo != null && this.text_ChangeModel_Turbo.enabled)
		{
			this.text_ChangeModel_Turbo.enabled = false;
			this.text_ChangeModel_Turbo.enabled = true;
		}
		if (this.textDimPanle != null && this.textDimPanle.enabled)
		{
			this.textDimPanle.enabled = false;
			this.textDimPanle.enabled = true;
		}
		if (this.SPName != null && this.SPName.enabled)
		{
			this.SPName.enabled = false;
			this.SPName.enabled = true;
		}
		if (this.SPScore != null && this.SPScore.enabled)
		{
			this.SPScore.enabled = false;
			this.SPScore.enabled = true;
		}
		if (this.SPScoreFly != null && this.SPScoreFly.enabled)
		{
			this.SPScoreFly.enabled = false;
			this.SPScoreFly.enabled = true;
		}
		if (this.SPRank != null && this.SPRank.enabled)
		{
			this.SPRank.enabled = false;
			this.SPRank.enabled = true;
		}
	}

	// Token: 0x0600094E RID: 2382 RVA: 0x000BE750 File Offset: 0x000BC950
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 0:
			this.UpdatePrizeText();
			break;
		case 1:
			this.AddItem();
			break;
		case 2:
			this.UpdateJackPotData();
			break;
		case 3:
			this.UpdatePrizeText();
			this.UpdateBtnSprite();
			this.UpdateGambleCost(0);
			this.SetNpcHP(UIBattle_Gambling.eHpType.Normal);
			this.SetNpcName();
			this.UpdateCurCostValue();
			break;
		case 4:
			this.bCanInput = true;
			this.SetInputOff(false);
			break;
		case 5:
			this.bCanInput = false;
			this.SetInputOff(true);
			break;
		case 6:
			this.SetNpcHP(UIBattle_Gambling.eHpType.Normal);
			this.SetNpcName();
			break;
		case 7:
			this.SetNpcHP(UIBattle_Gambling.eHpType.Zero);
			this.SetNpcName();
			break;
		case 8:
			this.UpdateCurCostValue();
			this.UpdateGambleCost(arg2);
			break;
		case 9:
			this.UpdateJackPot_Self();
			break;
		case 10:
			this.P_T.gameObject.SetActive(true);
			this.BGT.gameObject.SetActive(false);
			this.GUIM.m_BottomLayer.gameObject.SetActive(true);
			break;
		case 11:
			this.P_T.gameObject.SetActive(false);
			this.BGT.gameObject.SetActive(true);
			this.GUIM.m_BottomLayer.gameObject.SetActive(false);
			break;
		case 12:
			this.SendUse();
			break;
		case 13:
			this.CloseUI();
			break;
		case 14:
			this.SetGambleBoxAnim(GambleBoxAnim.idle);
			this.bSpecialNpc = false;
			break;
		case 15:
			this.SetGambleBoxAnim(GambleBoxAnim.status_3);
			this.bSpecialNpc = true;
			break;
		case 16:
			this.SetNpcParticleType(NpcParticleType.None);
			break;
		case 17:
			GUIManager.Instance.pDVMgr.ShowBossText(false);
			break;
		case 18:
		case 20:
			GUIManager.Instance.pDVMgr.BeginMoveBossText();
			break;
		case 19:
			if (arg2 == 2)
			{
				this.DisplayQueue.Add(1);
			}
			else
			{
				GUIManager.Instance.pDVMgr.ShowGodText(false);
				this.TextDisplayTime = new float?(1f);
			}
			break;
		case 21:
			if (this.DisplayQueue.Count > 0)
			{
				this.DisplayQueue.RemoveAt(0);
				GUIManager.Instance.pDVMgr.ShowGodText(false);
				this.TextDisplayTime = new float?(1f);
			}
			break;
		case 22:
			this.bfadeout = false;
			this.mStatus = 0;
			this.mComboTime = 0f;
			if (this.text_ComboCount != null)
			{
				this.text_ComboCount.gameObject.SetActive(false);
			}
			if (this.text_Combo != null)
			{
				this.text_Combo.gameObject.SetActive(false);
			}
			break;
		case 23:
			GamblingManager.Instance.CloseMenu(true);
			break;
		}
	}

	// Token: 0x0600094F RID: 2383 RVA: 0x000BEA5C File Offset: 0x000BCC5C
	public void OnButtonClick(UIButton sender)
	{
		if (this.ShowPrizeTime > 0f)
		{
			return;
		}
		if (!this.ShowSP && !this.bCanInput && sender.m_BtnID1 != 0)
		{
			return;
		}
		switch (sender.m_BtnID1)
		{
		case 0:
			this.CloseUI();
			break;
		case 1:
			if (DataManager.Instance.RoleAttr.ScardStar >= GamblingManager.Instance.GetCost() || NewbieManager.IsTeachWorking(ETeachKind.GAMBLING1))
			{
				if (!GamblingManager.Instance.bIsFirstOpen && !NewbieManager.IsTeachWorking(ETeachKind.GAMBLING1) && !NewbieManager.IsTeachWorking(ETeachKind.GAMBLING2))
				{
					this.GUIM.OpenCheckGamble();
				}
				else
				{
					this.SendUse();
				}
			}
			else
			{
				this.OpennFilterUI();
			}
			break;
		case 2:
			if (DataManager.Instance.RoleAttr.ScardStar >= GamblingManager.Instance.GetCost() || NewbieManager.IsTeachWorking(ETeachKind.GAMBLING1))
			{
				this.SendUse();
			}
			else
			{
				this.OpennFilterUI();
			}
			break;
		case 3:
			if (GamblingManager.Instance.GambleMode != UIBattle_Gambling.eMode.Normal)
			{
				if (GamblingManager.Instance.GetRemainFreePlay(UIBattle_Gambling.eMode.Turbo) > 0)
				{
					GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5882u), DataManager.Instance.mStringTable.GetStringByID(9172u), null, null, 0, 0, false, false, false, false, false);
					return;
				}
				if (GamblingManager.Instance.IsSpecialType(UIBattle_Gambling.eMode.Turbo))
				{
					GUIManager.Instance.MsgStr.ClearString();
					this.SetNpcName(this.mStr[26]);
					GUIManager.Instance.MsgStr.StringToFormat(this.mStr[26]);
					GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9173u));
					GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5882u), GUIManager.Instance.MsgStr.ToString(), null, null, 0, 0, false, false, false, false, false);
					return;
				}
				this.SetBtnType(UIBattle_Gambling.eMode.Normal);
				this.GUIM.m_HUDMessage.MapHud.AddGambleMsg();
			}
			break;
		case 4:
			if (GamblingManager.Instance.GambleMode != UIBattle_Gambling.eMode.Turbo)
			{
				if (!DataManager.Instance.CheckPrizeFlag(9))
				{
					GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5882u), DataManager.Instance.mStringTable.GetStringByID(9183u), null, null, 0, 0, false, false, false, false, false);
					return;
				}
				if (GamblingManager.Instance.GetRemainFreePlay(UIBattle_Gambling.eMode.Normal) > 0)
				{
					GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5882u), DataManager.Instance.mStringTable.GetStringByID(9172u), null, null, 0, 0, false, false, false, false, false);
					return;
				}
				if (GamblingManager.Instance.IsSpecialType(UIBattle_Gambling.eMode.Normal))
				{
					GUIManager.Instance.MsgStr.ClearString();
					this.SetNpcName(this.mStr[26]);
					GUIManager.Instance.MsgStr.StringToFormat(this.mStr[26]);
					GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9173u));
					GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5882u), GUIManager.Instance.MsgStr.ToString(), null, null, 0, 0, false, false, false, false, false);
					return;
				}
				this.SetBtnType(UIBattle_Gambling.eMode.Turbo);
				this.GUIM.m_HUDMessage.MapHud.AddGambleMsg();
			}
			break;
		case 6:
			GamblingManager.Instance.OpenMenu(EGUIWindow.UI_MonsterCrypt, 0, 0, false);
			break;
		case 7:
			GamblingManager.Instance.OpenMenu(EGUIWindow.UI_Monster_Crypt_3, 0, 0, false);
			break;
		case 8:
			GUIManager.Instance.OpenItemKindFilterUI(10, 40, 0);
			break;
		case 9:
			this.RestSP();
			break;
		case 10:
			GamblingManager.Instance.bOpenTreasure = 1;
			GamblingManager.Instance.CloseMenu(false);
			this.CloseUI();
			break;
		}
	}

	// Token: 0x06000950 RID: 2384 RVA: 0x000BEE98 File Offset: 0x000BD098
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06000951 RID: 2385 RVA: 0x000BEE9C File Offset: 0x000BD09C
	public void UpdatePos(RectTransform Rect, RectTransform HintRect)
	{
		Vector2 anchoredPosition = ((RectTransform)Rect.parent.transform).anchoredPosition;
		HintRect.anchoredPosition = new Vector2(anchoredPosition.x - 18f, anchoredPosition.y + 197f);
	}

	// Token: 0x06000952 RID: 2386 RVA: 0x000BEEE4 File Offset: 0x000BD0E4
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			if (this.ShowPrizeTime > 0f)
			{
				this.ShowPrizeTime -= 1f;
			}
			else
			{
				this.ShowPrizeTime = 0f;
			}
			if (this.CDTime > 0f)
			{
				this.CDTime -= 1f;
			}
			else
			{
				this.CDTime = 10f;
				GamblingManager.Instance.Send_MSG_REQUEST_GAMBLE_PRIZE();
			}
			if (this.RandIdleTime > 0f)
			{
				this.RandIdleTime -= 1f;
			}
			else
			{
				this.RandNpcIdle();
				this.RandIdleTime = 10f;
			}
			this.UpdateTime();
		}
	}

	// Token: 0x06000953 RID: 2387 RVA: 0x000BEFA4 File Offset: 0x000BD1A4
	public override bool OnBackButtonClick()
	{
		this.OnButtonClick(this.btn_EXIT);
		return false;
	}

	// Token: 0x06000954 RID: 2388 RVA: 0x000BEFB4 File Offset: 0x000BD1B4
	private void Update()
	{
		float? textDisplayTime = this.TextDisplayTime;
		if (textDisplayTime != null)
		{
			float? textDisplayTime2 = this.TextDisplayTime;
			this.TextDisplayTime = ((textDisplayTime2 == null) ? null : new float?(textDisplayTime2.Value - Time.deltaTime));
			if (this.TextDisplayTime.Value <= 0f)
			{
				this.UpdateUI(20, 0);
				this.TextDisplayTime = null;
			}
		}
		if (this.bOpenEnd)
		{
			if (!this.ABIsDone && this.AR != null && this.AR.isDone)
			{
				this.go2 = (GameObject)UnityEngine.Object.Instantiate(this.AR.asset);
				this.go2.transform.SetParent(this.Hero_Pos, false);
				Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
				localRotation.eulerAngles = new Vector3(11.9199f, 157.7f, 355.7f);
				this.go2.transform.localRotation = localRotation;
				this.go2.transform.localScale = new Vector3(245f, 245f, 245f);
				this.go2.transform.localPosition = new Vector3(0f, 0f, 0f);
				GUIManager.Instance.SetLayer(this.go2, 5);
				this.Tmp = this.Hero_Pos.GetChild(0);
				this.Hero_Model = this.Tmp.GetComponent<Transform>();
				if (this.Hero_Model != null)
				{
					this.tmpAN = this.Hero_Model.GetComponent<Animation>();
					this.tmpAN.wrapMode = WrapMode.Default;
					this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
					this.tmpAN[this.NpcActStr[0]].layer = 0;
					this.tmpAN[this.NpcActStr[6]].layer = 0;
					this.tmpAN[this.NpcActStr[1]].layer = 1;
					this.tmpAN[this.NpcActStr[2]].layer = 1;
					this.tmpAN[this.NpcActStr[3]].layer = 1;
					this.tmpAN[this.NpcActStr[4]].layer = 2;
					this.tmpAN[this.NpcActStr[5]].layer = 2;
					this.tmpAN[this.NpcActStr[0]].wrapMode = WrapMode.Loop;
					this.tmpAN[this.NpcActStr[6]].wrapMode = WrapMode.Loop;
					if (this.bFreeMode)
					{
						this.SetNpcAnim(UIBattle_Gambling.NpcAct.v_idle);
					}
					else
					{
						this.SetNpcAnim(UIBattle_Gambling.NpcAct.idle);
					}
					if (this.Hero_Pos.gameObject.activeSelf)
					{
						SkinnedMeshRenderer componentInChildren = this.Hero_Model.GetComponentInChildren<SkinnedMeshRenderer>();
						componentInChildren.useLightProbes = false;
						componentInChildren.updateWhenOffscreen = true;
					}
				}
				this.ABIsDone = true;
			}
			if (!this.ABIsDone_Prize && this.Prize_AR != null && this.Prize_AR.isDone)
			{
				this.go = (GameObject)UnityEngine.Object.Instantiate(this.Prize_AR.asset);
				this.go.transform.SetParent(this.PrizePos3D, false);
				Quaternion localRotation2 = new Quaternion(0f, 0f, 0f, 0f);
				localRotation2.eulerAngles = new Vector3(26f, 180f, -4.7101f);
				this.go.transform.localRotation = localRotation2;
				this.go.transform.localScale = new Vector3(450f, 450f, 450f);
				this.go.transform.localPosition = new Vector3(0f, 0f, 0f);
				GUIManager.Instance.SetLayer(this.go, 5);
				Transform child = this.PrizePos3D.GetChild(0);
				this.Prize_Modle = child.GetComponent<Transform>();
				if (this.Prize_Modle != null)
				{
					if (this.PrizePos3D.gameObject.activeSelf)
					{
						SkinnedMeshRenderer componentInChildren2 = this.Prize_Modle.GetComponentInChildren<SkinnedMeshRenderer>();
						componentInChildren2.useLightProbes = false;
						componentInChildren2.updateWhenOffscreen = true;
					}
					if (GamblingManager.Instance.IsSpecialType(GamblingManager.Instance.GambleMode))
					{
						GamblingManager.Instance.m_GambleBoxAnim = GambleBoxAnim.status_3;
					}
					if (GamblingManager.Instance.m_GambleBoxAnim != GambleBoxAnim.None)
					{
						this.SetGambleBoxAnim(GamblingManager.Instance.m_GambleBoxAnim);
					}
				}
				this.ABIsDone_Prize = true;
			}
			this.UpdateSP();
			this.UpdateCombo();
			if (this.bNpcAttackVictory)
			{
				this.SetNpcAnim(UIBattle_Gambling.NpcAct.victory);
			}
			this.mShitfHelper.Update();
		}
	}

	// Token: 0x06000955 RID: 2389 RVA: 0x000BF498 File Offset: 0x000BD698
	private void SpawnString()
	{
		for (int i = 0; i < this.mStr.Length; i++)
		{
			this.mStr[i] = StringManager.Instance.SpawnString(30);
		}
		this.mStrComboCount = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x06000956 RID: 2390 RVA: 0x000BF4E4 File Offset: 0x000BD6E4
	private void DeSpawnString()
	{
		for (int i = 0; i < this.mStr.Length; i++)
		{
			if (this.mStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.mStr[i]);
				this.mStr[i] = null;
			}
		}
		if (this.mStrComboCount != null)
		{
			StringManager.Instance.DeSpawnString(this.mStrComboCount);
		}
	}

	// Token: 0x06000957 RID: 2391 RVA: 0x000BF550 File Offset: 0x000BD750
	private void InitUI()
	{
		this.GUIM = GUIManager.Instance;
		this.TTFont = this.GUIM.GetTTFFont();
		this.GameT = base.gameObject.transform;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			((RectTransform)this.GameT).offsetMin = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)this.GameT).offsetMax = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		this.alertBlock = this.GameT.GetChild(0);
		this.P_T = this.GameT.GetChild(1);
		this.SPBgTF = this.GameT.GetChild(3);
		this.SPT = this.GameT.GetChild(3).GetChild(0);
		this.ComboT = this.GameT.GetChild(2);
		this.BGT = this.GameT.GetChild(4);
		this.RunningText = this.GameT.GetChild(5).GetComponent<UIRunningTextEX>();
		this.InputOff = this.GameT.GetChild(6);
		this.InputOff.gameObject.SetActive(false);
		this.DimPanle = this.GameT.GetChild(7);
		this.IPhoneXPanel = this.GameT.GetChild(8);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			this.IPhoneXPanel.gameObject.SetActive(true);
		}
		this.textDimPanle = this.DimPanle.GetChild(0).GetChild(1).GetComponent<UIText>();
		this.textDimPanle.font = this.TTFont;
		this.btnDimPanle = this.DimPanle.GetChild(0).GetChild(2).GetComponent<UIButton>();
		this.btnDimPanle.m_Handler = this;
		this.btnDimPanle.m_BtnID1 = 10;
		this.btn_SP = this.GameT.GetChild(3).GetComponent<UIButton>();
		this.btn_SP.m_Handler = this;
		this.btn_SP.m_BtnID1 = 9;
		this.DimPanle.SetParent(GUIManager.Instance.m_WindowsTransform, false);
		this.UpdateMoney();
		this.alertBlock_T = this.alertBlock.GetChild(0).GetComponent<Image>();
		this.alertBlock_B = this.alertBlock.GetChild(1).GetComponent<Image>();
		this.alertBlock_R = this.alertBlock.GetChild(2).GetComponent<Image>();
		this.alertBlock_L = this.alertBlock.GetChild(3).GetComponent<Image>();
		this.BGT.SetParent(GUIManager.Instance.m_WindowsTransform);
		this.BGT.localRotation = Quaternion.identity;
		this.BGT.localScale = Vector3.one;
		this.BGT.localPosition = Vector3.zero;
		int num = -1;
		if (GUIManager.Instance.m_ChatBox != null)
		{
			num = GUIManager.Instance.m_ChatBox.GetSiblingIndex();
		}
		if (num != -1)
		{
			this.BGT.SetSiblingIndex(num);
		}
		this.P_T.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 2000f);
		this.mSpArray = this.GameT.GetComponent<UISpritesArray>();
		this.btn_Hint = this.P_T.GetChild(1).GetComponent<UIButton>();
		this.btn_Hint.m_Handler = this;
		this.btn_Hint.m_BtnID1 = 1;
		this.btn_Hint2 = this.P_T.GetChild(2).GetComponent<UIButton>();
		this.btn_Hint2.m_Handler = this;
		this.btn_Hint2.m_BtnID1 = 2;
		this.btn_Hint.m_EffectType = e_EffectType.e_Scale;
		this.btn_Hint.transition = Selectable.Transition.None;
		float x = ((RectTransform)this.GUIM.m_UICanvas.transform).sizeDelta.x;
		float num2 = Mathf.Clamp(x - 853f, 0f, 1920f);
		float x2 = Mathf.Clamp(num2 * 0.077f + 146f, 146f, 233f);
		Vector2 sizeDelta = this.P_T.GetChild(2).GetComponent<RectTransform>().sizeDelta;
		sizeDelta.x = x2;
		this.P_T.GetChild(2).GetComponent<RectTransform>().sizeDelta = sizeDelta;
		this.Img_Hint2 = this.P_T.GetChild(2).GetComponent<Image>();
		this.Img_Hint2Flash = this.P_T.GetChild(2).GetChild(0).GetComponent<Image>();
		this.text_Hint = this.P_T.GetChild(2).GetChild(2).GetComponent<UIText>();
		this.text_Hint.font = this.TTFont;
		this.text_Hint2 = this.P_T.GetChild(2).GetChild(3).GetComponent<UIText>();
		this.text_Hint2.font = this.TTFont;
		this.text_Hint2.text = DataManager.Instance.mStringTable.GetStringByID(94u);
		this.Img_Hint2_Black = this.P_T.GetChild(2).GetChild(4).GetComponent<Image>();
		this.btn_ItemList = this.P_T.GetChild(3).GetComponent<UIButton>();
		this.btn_ItemList.m_Handler = this;
		this.btn_ItemList.m_BtnID1 = 6;
		this.ImgPrize = this.P_T.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
		this.textPrize = this.P_T.GetChild(3).GetChild(0).GetChild(0).GetChild(1).GetComponent<UIText>();
		this.textPrize.font = this.TTFont;
		this.Hero_Pos = this.P_T.GetChild(5);
		this.Particle_Pos[0] = this.P_T.GetChild(6).GetChild(0);
		this.Particle_Pos[1] = this.P_T.GetChild(6).GetChild(1);
		this.Particle_Pos[4] = this.P_T.GetChild(6).GetChild(4);
		this.Particle_Pos[5] = this.P_T.GetChild(6).GetChild(5);
		this.Particle_Pos[2] = this.P_T.GetChild(6).GetChild(2);
		this.Particle_Pos[3] = this.P_T.GetChild(6).GetChild(3);
		this.Particle_Pos[1].gameObject.SetActive(false);
		this.Particle_Pos[4].gameObject.SetActive(false);
		this.Particle_Pos[5].gameObject.SetActive(false);
		this.Particle_Pos[2].gameObject.SetActive(false);
		this.Particle_Pos[3].gameObject.SetActive(false);
		this.EffectObj[0] = ParticleManager.Instance.Spawn(408, this.Particle_Pos[0].transform, Vector3.zero, 1f, true, true, true);
		if (this.EffectObj[0] != null)
		{
			GUIManager.Instance.SetLayer(this.EffectObj[0], 5);
			this.EffectObj[0].transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
		}
		this.EffectObj[1] = ParticleManager.Instance.Spawn(409, this.Particle_Pos[1].transform, Vector3.zero, 1f, true, true, true);
		if (this.EffectObj[1] != null)
		{
			GUIManager.Instance.SetLayer(this.EffectObj[1], 5);
			this.EffectObj[1].transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
		}
		this.EffectObj[2] = ParticleManager.Instance.Spawn(413, this.Particle_Pos[2].transform, Vector3.zero, 1f, true, true, true);
		if (this.EffectObj[2] != null)
		{
			GUIManager.Instance.SetLayer(this.EffectObj[2], 5);
			this.EffectObj[2].transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
		}
		this.EffectObj[3] = ParticleManager.Instance.Spawn(415, this.Particle_Pos[3].transform, Vector3.zero, 1f, true, true, true);
		if (this.EffectObj[3] != null)
		{
			GUIManager.Instance.SetLayer(this.EffectObj[3], 5);
			this.EffectObj[3].transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
		}
		this.EffectObj[4] = ParticleManager.Instance.Spawn(417, this.Particle_Pos[4].transform, Vector3.zero, 1f, true, true, true);
		if (this.EffectObj[4] != null)
		{
			GUIManager.Instance.SetLayer(this.EffectObj[4], 5);
			this.EffectObj[4].transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
		}
		this.EffectObj[4] = ParticleManager.Instance.Spawn(418, this.Particle_Pos[5].transform, Vector3.zero, 1f, true, true, true);
		if (this.EffectObj[4] != null)
		{
			GUIManager.Instance.SetLayer(this.EffectObj[4], 5);
			this.EffectObj[4].transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
		}
		this.PrizePos3D = this.P_T.GetChild(7);
		this.AB = AssetManager.GetAssetBundle("Role/Priest", out this.AssetKey, false);
		if (this.AB != null)
		{
			this.AR = this.AB.LoadAsync("Priest", typeof(GameObject));
			this.ABIsDone = false;
		}
		this.Prize_AB = AssetManager.GetAssetBundle("Role/gamblebox", out this.AssetKey2, false);
		if (this.Prize_AB != null)
		{
			this.Prize_AR = this.Prize_AB.LoadAsync("m", typeof(GameObject));
			this.ABIsDone_Prize = false;
		}
		this.Img_ChangeNormal = this.P_T.GetChild(8).GetComponent<Image>();
		this.Img_ChangeNormalFlash = this.P_T.GetChild(8).GetChild(0).GetComponent<Image>();
		this.btn_ChangeModel_Normal = this.P_T.GetChild(8).GetComponent<UIButton>();
		this.btn_ChangeModel_Normal.m_Handler = this;
		this.btn_ChangeModel_Normal.m_BtnID1 = 3;
		this.btn_ChangeModel_Normal.m_EffectType = e_EffectType.e_Scale;
		this.btn_ChangeModel_Normal.transition = Selectable.Transition.None;
		this.text_ChangeModel_Normal = this.P_T.GetChild(8).GetChild(1).GetComponent<UIText>();
		this.text_ChangeModel_Normal.font = this.TTFont;
		this.text_ChangeModel_Normal.text = DataManager.Instance.mStringTable.GetStringByID(9169u);
		this.Img_ChangeTurbo = this.P_T.GetChild(9).GetComponent<Image>();
		this.Img_ChangeTurboFlash = this.P_T.GetChild(9).GetChild(0).GetComponent<Image>();
		this.btn_ChangeModel_Turbo = this.P_T.GetChild(9).GetComponent<UIButton>();
		this.btn_ChangeModel_Turbo.m_Handler = this;
		this.btn_ChangeModel_Turbo.m_BtnID1 = 4;
		this.btn_ChangeModel_Turbo.m_EffectType = e_EffectType.e_Scale;
		this.btn_ChangeModel_Turbo.transition = Selectable.Transition.None;
		this.text_ChangeModel_Turbo = this.P_T.GetChild(9).GetChild(1).GetComponent<UIText>();
		this.text_ChangeModel_Turbo.font = this.TTFont;
		this.text_ChangeModel_Turbo.text = DataManager.Instance.mStringTable.GetStringByID(9170u);
		this.AlertPanel = this.P_T.GetChild(9).GetChild(2);
		for (int i = 0; i < this.btn_Item_Rect.Length; i++)
		{
			this.btn_Item_Rect[i] = this.P_T.GetChild(11).GetChild(i).GetComponent<RectTransform>();
		}
		for (int j = 0; j < this.btn_Item.Length; j++)
		{
			this.btn_Item[j] = this.P_T.GetChild(11).GetChild(j).GetChild(0).GetComponent<UIHIBtn>();
			this.GUIM.InitianHeroItemImg(this.btn_Item[j].transform, eHeroOrItem.Item, 1, 0, 0, 0, false, false, true, false);
			this.text_ItmeNum[j] = this.P_T.GetChild(11).GetChild(j).GetChild(2).GetComponent<UIText>();
			this.text_ItmeNum[j].font = this.TTFont;
			UIButtonHint uibuttonHint = this.btn_Item[j].gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_ForcePos = true;
			uibuttonHint.m_HintPosHandler = this;
			uibuttonHint.m_HIBtnOffset = new Vector2(this.btn_Item_Rect[j].anchoredPosition.x - 49f, this.btn_Item_Rect[j].anchoredPosition.y + 228f);
			this.btn_Item[j].gameObject.name = "~";
			this.btn_Item2[j] = this.P_T.GetChild(11).GetChild(j).GetChild(1).GetComponent<UILEBtn>();
			uibuttonHint = this.btn_Item2[j].gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.UILeBtn;
			uibuttonHint.m_ForcePos = true;
			uibuttonHint.m_HintPosHandler = this;
			uibuttonHint.m_HIBtnOffset = new Vector2(this.btn_Item_Rect[j].anchoredPosition.x - 49f, this.btn_Item_Rect[j].anchoredPosition.y + 228f);
			this.GUIM.InitLordEquipImg(this.btn_Item2[j].transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
			this.btn_Item2[j].gameObject.name = "~";
		}
		this.mShitfHelper.Init(this.btn_Item_Rect);
		this.btn_InfoBtn = this.P_T.GetChild(13).GetComponent<UIButton>();
		this.btn_InfoBtn.m_BtnID1 = 7;
		this.btn_InfoBtn.m_Handler = this;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component = this.P_T.GetChild(13).GetComponent<RectTransform>();
			Vector2 anchoredPosition = component.anchoredPosition;
			anchoredPosition.x = 51f;
			component.anchoredPosition = anchoredPosition;
			Vector3 localScale = component.localScale;
			localScale.x *= -1f;
			component.localScale = localScale;
		}
		this.mJackPotDataPanel = this.P_T.GetChild(14).gameObject;
		for (int k = 0; k < 3; k++)
		{
			this.mJackPotUI[k].obj = this.P_T.GetChild(14).GetChild(0).GetChild(k).gameObject;
			this.mJackPotUI[k].Name = this.P_T.GetChild(14).GetChild(0).GetChild(k).GetChild(0).GetComponent<UIText>();
			this.mJackPotUI[k].Num = this.P_T.GetChild(14).GetChild(0).GetChild(k).GetChild(1).GetComponent<UIText>();
			this.mJackPotUI[k].Time = this.P_T.GetChild(14).GetChild(0).GetChild(k).GetChild(2).GetComponent<UIText>();
			this.mJackPotUI[k].Name.font = this.TTFont;
			this.mJackPotUI[k].Num.font = this.TTFont;
			this.mJackPotUI[k].Time.font = this.TTFont;
		}
		GamblingManager.Instance.m_ItemPos = this.btn_Item_Rect[0].anchoredPosition + new Vector2(31f, -31f);
		this.text_TimeValue = this.P_T.GetChild(12).GetChild(0).GetChild(1).GetComponent<UIText>();
		this.text_TimeValue.font = this.TTFont;
		this.text_CostValue = this.P_T.GetChild(12).GetChild(1).GetChild(1).GetComponent<UIText>();
		this.text_CostValue.font = this.TTFont;
		this.btn_Filter = this.P_T.GetChild(12).GetChild(1).GetChild(2).GetComponent<UIButton>();
		this.btn_Filter.m_BtnID1 = 8;
		this.btn_Filter.m_Handler = this;
		this.Img_ItemListT = this.P_T.GetChild(16).GetComponent<Image>();
		this.mNpcHp = this.P_T.GetChild(18).gameObject;
		this.imgNpcHpSlider = this.P_T.GetChild(18).GetChild(0).GetChild(0).GetComponent<Image>();
		this.textNpcHpName = this.P_T.GetChild(18).GetChild(1).GetComponent<UIText>();
		this.textNpcHpName.font = this.TTFont;
		this.textNpcHpValue = this.P_T.GetChild(18).GetChild(2).GetComponent<UIText>();
		this.textNpcHpValue.font = this.TTFont;
		Image component2 = this.P_T.GetChild(13).GetComponent<Image>();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			Image component3 = this.P_T.GetChild(19).GetComponent<Image>();
			if (component3)
			{
				component3.enabled = false;
			}
		}
		this.btn_EXIT = this.P_T.GetChild(19).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.RunningText.m_RunningText1.font = this.TTFont;
		this.RunningText.m_RunningText2.font = this.TTFont;
		if ((DataManager.Instance.RoleAttr.PrizeFlag & 2u) > 0u)
		{
			this.RunningText.CheckAddStr();
		}
		this.ComboT.gameObject.SetActive(true);
		this.text_ComboCount = this.ComboT.GetChild(0).GetComponent<UIText>();
		this.text_ComboCount.font = this.TTFont;
		this.text_ComboCount.fontStyle = FontStyle.Italic;
		this.text_Combo = this.ComboT.GetChild(1).GetComponent<UIText>();
		this.text_Combo.font = this.TTFont;
		this.text_Combo.text = DataManager.Instance.mStringTable.GetStringByID(9185u);
		this.text_Combo.fontStyle = FontStyle.Italic;
		this.text_Combo.rectTransform.anchoredPosition = new Vector2(this.text_Combo.rectTransform.anchoredPosition.x, -60f);
		this.text_Combo.rectTransform.sizeDelta = new Vector2(200f, this.text_Combo.rectTransform.sizeDelta.y);
		this.text_ComboCount.gameObject.SetActive(false);
		this.text_Combo.gameObject.SetActive(false);
		this.bOpenEnd = true;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 6);
	}

	// Token: 0x06000958 RID: 2392 RVA: 0x000C094C File Offset: 0x000BEB4C
	private void InitSP()
	{
		float num = 0f;
		for (int i = 0; i < this.SPShowTiming.Length; i++)
		{
			num += this.SPShowTiming[i];
			this.SPShowTiming[i] = num;
		}
		for (int j = 0; j < this.SPStrings.Length; j++)
		{
			int num2 = Mathf.Clamp(22 + j, 22, 25);
			this.SPStrings[j] = this.mStr[num2];
			if (this.SPStrings[j] != null)
			{
				this.SPStrings[j].ClearString();
			}
		}
		this.SPStrings[0].Append(DataManager.Instance.mStringTable.GetStringByID(9181u));
		this.SPName = this.SPT.GetChild(0).GetComponent<UIText>();
		this.SPName.font = this.TTFont;
		this.SPName.text = this.SPStrings[0].ToString();
		this.SPName.SetAllDirty();
		this.SPName.cachedTextGenerator.Invalidate();
		this.SPScore = this.SPT.GetChild(1).GetComponent<UIText>();
		this.SPScore.font = this.TTFont;
		this.SPStrings[1].IntToFormat((long)((ulong)UIBattle_Gambling.SPScoreValue), 1, true);
		this.SPStrings[1].AppendFormat("{0}");
		this.SPScore.text = this.SPStrings[1].ToString();
		this.SPScore.SetAllDirty();
		this.SPScore.cachedTextGenerator.Invalidate();
		this.SPScoreFly = this.SPT.GetChild(2).GetComponent<UIText>();
		this.SPScoreFly.font = this.TTFont;
		this.SPStrings[2].IntToFormat((long)((ulong)UIBattle_Gambling.SPScoreFlyValue), 1, true);
		this.SPStrings[2].AppendFormat("{0}");
		this.SPScoreFly.text = this.SPStrings[2].ToString();
		this.SPScoreFly.SetAllDirty();
		this.SPScoreFly.cachedTextGenerator.Invalidate();
		this.SPFly = this.SPScoreFly.rectTransform;
		this.SPRank = this.SPT.GetChild(4).GetComponent<UIText>();
		this.SPBG = this.SPT.GetComponent<Image>();
		this.SPRankUpDown = this.SPT.GetChild(3).GetComponent<Image>();
		this.SPReady = true;
		this.SPShowTime = 0f;
		this.SPShowPhase = 0f;
		this.SPBgTF.gameObject.SetActive(false);
	}

	// Token: 0x06000959 RID: 2393 RVA: 0x000C0BE0 File Offset: 0x000BEDE0
	private void UpdateSP()
	{
		if (this.ShowSP)
		{
			this.SPShowTime += Time.smoothDeltaTime;
			if (this.SPShowTime < this.SPShowTiming[0])
			{
				if (this.SPShowPhase < 1f)
				{
					this.SPShowPhase = 1f;
					this.SPBG.gameObject.SetActive(true);
					this.SPBgTF.gameObject.SetActive(true);
					this.SPScoreFly.gameObject.SetActive(false);
					this.SPRankUpDown.gameObject.SetActive(false);
					this.SPBG.gameObject.SetActive(true);
					if (!GUIManager.Instance.IsArabic)
					{
						this.SPScore.rectTransform.localScale = new Vector2(2f, 2f) * 0.6f;
					}
					else
					{
						this.SPScore.rectTransform.localScale = new Vector2(-2f, 2f) * 0.6f;
					}
					this.SPName.text = this.SPStrings[0].ToString();
					this.SPName.SetAllDirty();
					this.SPName.cachedTextGenerator.Invalidate();
					this.SPStrings[1].ClearString();
					this.SPStrings[1].IntToFormat((long)((ulong)UIBattle_Gambling.SPScoreValue), 1, true);
					this.SPStrings[1].AppendFormat("{0}");
					this.SPScore.text = this.SPStrings[1].ToString();
					this.SPScore.SetAllDirty();
					this.SPScore.cachedTextGenerator.Invalidate();
					this.SPStrings[2].ClearString();
					this.SPStrings[2].IntToFormat((long)((ulong)UIBattle_Gambling.SPScoreFlyValue), 1, true);
					this.SPStrings[2].AppendFormat("{0}");
					this.SPScoreFly.text = this.SPStrings[2].ToString();
					this.SPScoreFly.SetAllDirty();
					this.SPScoreFly.cachedTextGenerator.Invalidate();
				}
				float num = Mathf.InverseLerp(0f, this.SPShowTiming[0], this.SPShowTime);
				Color color = this.SPBG.color;
				color.a = num * 0.8f;
				this.SPBG.color = color;
				color = this.SPName.color;
				color.a = num;
				this.SPName.color = color;
				color = Color.white;
				color.a = num;
				this.SPScore.color = color;
				this.Particle_Pos[3].gameObject.SetActive(true);
			}
			else if (this.SPShowTime < this.SPShowTiming[2])
			{
				Color color2;
				if (this.SPShowPhase < 2f)
				{
					this.SPShowPhase = 2f;
					this.SPScoreFly.gameObject.SetActive(true);
					this.SPStrings[3].ClearString();
					this.SPStrings[3].IntToFormat(Math.Abs((long)((ulong)UIBattle_Gambling.SPRankChange)), 1, true);
					this.SPStrings[3].AppendFormat("{0}");
					this.SPRank.text = this.SPStrings[3].ToString();
					this.SPRank.SetAllDirty();
					this.SPRank.cachedTextGenerator.Invalidate();
					if (UIBattle_Gambling.SPRankChange > 0u)
					{
						this.SPRank.gameObject.SetActive(true);
						this.SPRankUpDown.GetComponent<UISpritesArray>().SetSpriteIndex(0);
						this.SPRankUpDown.gameObject.SetActive(true);
					}
					else if (UIBattle_Gambling.SPRankChange < 0u)
					{
						this.SPRank.gameObject.SetActive(true);
						this.SPRankUpDown.GetComponent<UISpritesArray>().SetSpriteIndex(1);
						this.SPRankUpDown.gameObject.SetActive(true);
					}
					else
					{
						this.SPRank.gameObject.SetActive(false);
					}
					color2 = Color.white;
					color2.a = 0f;
					this.SPRank.color = color2;
					this.SPRankUpDown.color = color2;
				}
				float num2 = Mathf.InverseLerp(this.SPShowTiming[2], this.SPShowTiming[1], this.SPShowTime);
				color2 = this.SPScoreFly.color;
				color2.a = num2;
				this.SPScoreFly.color = color2;
				num2 = Mathf.InverseLerp(this.SPShowTiming[0], this.SPShowTiming[2], this.SPShowTime);
				this.SPScoreFly.rectTransform.anchoredPosition = Vector2.Lerp(new Vector2(0f, -265f), this.SPScore.rectTransform.anchoredPosition, num2);
			}
			else if (this.SPShowTime < this.SPShowTiming[3])
			{
				if (this.SPShowPhase < 3f)
				{
					this.SPShowPhase = 3f;
					this.SPScoreFly.gameObject.SetActive(false);
					this.SPScore.color = Color.yellow;
				}
				if (!GUIManager.Instance.IsArabic)
				{
					this.SPScore.rectTransform.localScale = new Vector2(2f, 2f) * Mathf.Lerp(0.5f, 0.8f, Mathf.InverseLerp(this.SPShowTiming[2], this.SPShowTiming[3], this.SPShowTime));
				}
				else
				{
					this.SPScore.rectTransform.localScale = new Vector2(-2f, 2f) * Mathf.Lerp(0.5f, 0.8f, Mathf.InverseLerp(this.SPShowTiming[2], this.SPShowTiming[3], this.SPShowTime));
				}
			}
			else if (this.SPShowTime < this.SPShowTiming[4])
			{
				if (this.SPShowPhase < 4f)
				{
					this.SPShowPhase = 4f;
					AudioManager.Instance.PlaySFX(40050, 0f, PitchKind.NoPitch, null, null);
				}
				this.SPStrings[1].ClearString();
				this.SPStrings[1].IntToFormat((long)((int)Mathf.Lerp(UIBattle_Gambling.SPScoreValue, UIBattle_Gambling.SPScoreValue + UIBattle_Gambling.SPScoreFlyValue, Mathf.InverseLerp(this.SPShowTiming[3], this.SPShowTiming[4], this.SPShowTime))), 1, true);
				this.SPStrings[1].AppendFormat("{0}");
				this.SPScore.text = this.SPStrings[1].ToString();
				this.SPScore.SetAllDirty();
				this.SPScore.cachedTextGenerator.Invalidate();
			}
			else if (this.SPShowTime < this.SPShowTiming[5])
			{
				if (this.SPShowPhase < 5f)
				{
					this.SPShowPhase = 5f;
					this.SPStrings[1].ClearString();
					this.SPStrings[1].IntToFormat((long)((ulong)(UIBattle_Gambling.SPScoreValue + UIBattle_Gambling.SPScoreFlyValue)), 1, true);
					this.SPStrings[1].AppendFormat("{0}");
					this.SPScore.text = this.SPStrings[1].ToString();
					this.SPScore.SetAllDirty();
					this.SPScore.cachedTextGenerator.Invalidate();
					AudioManager.Instance.PlaySFX(40049, 0f, PitchKind.NoPitch, null, null);
				}
				float a = Mathf.InverseLerp(this.SPShowTiming[4], this.SPShowTiming[5], this.SPShowTime);
				Color white = Color.white;
				white.a = a;
				this.SPRank.color = white;
				this.SPRankUpDown.color = white;
				if (!GUIManager.Instance.IsArabic)
				{
					this.SPScore.rectTransform.localScale = new Vector2(2f, 2f) * Mathf.Lerp(0.6f, 2f, Mathf.InverseLerp(this.SPShowTiming[4], this.SPShowTiming[5], this.SPShowTime));
				}
				else
				{
					this.SPScore.rectTransform.localScale = new Vector2(-2f, 2f) * Mathf.Lerp(0.6f, 2f, Mathf.InverseLerp(this.SPShowTiming[4], this.SPShowTiming[5], this.SPShowTime));
				}
			}
			else if (this.SPShowTime < this.SPShowTiming[6])
			{
				this.SPRankUpDown.rectTransform.anchoredPosition = new Vector2(-37f - this.SPScore.preferredWidth, this.SPRankUpDown.rectTransform.anchoredPosition.y);
				if (!GUIManager.Instance.IsArabic)
				{
					this.SPScore.rectTransform.localScale = new Vector2(2f, 2f) * Mathf.Lerp(2f, 1f, Mathf.InverseLerp(this.SPShowTiming[5], this.SPShowTiming[6], this.SPShowTime));
				}
				else
				{
					this.SPScore.rectTransform.localScale = new Vector2(-2f, 2f) * Mathf.Lerp(2f, 1f, Mathf.InverseLerp(this.SPShowTiming[5], this.SPShowTiming[6], this.SPShowTime));
				}
			}
			else if (this.SPShowTime < this.SPShowTiming[7])
			{
				if (!GUIManager.Instance.IsArabic)
				{
					this.SPScore.rectTransform.localScale = new Vector2(2f, 2f);
				}
				else
				{
					this.SPScore.rectTransform.localScale = new Vector2(-2f, 2f);
				}
			}
		}
	}

	// Token: 0x0600095A RID: 2394 RVA: 0x000C15CC File Offset: 0x000BF7CC
	private void RestSP()
	{
		this.SPBG.gameObject.SetActive(false);
		this.SPBgTF.gameObject.SetActive(false);
		this.ShowSP = false;
		this.SPShowTime = 0f;
		this.Particle_Pos[3].gameObject.SetActive(false);
	}

	// Token: 0x0600095B RID: 2395 RVA: 0x000C1620 File Offset: 0x000BF820
	private void UpdatePrizeText()
	{
		float num = GamblingManager.Instance.m_GambleGameInfo.SmallCost / GamblingManager.Instance.m_GambleGameInfo.BigCost;
		uint num2;
		if (GamblingManager.Instance.GambleMode == UIBattle_Gambling.eMode.Normal)
		{
			num2 = (uint)(GamblingManager.Instance.m_GambleGameInfo.Prize * num);
		}
		else
		{
			num2 = GamblingManager.Instance.m_GambleGameInfo.Prize;
		}
		this.mStr[0].ClearString();
		this.mStr[0].IntToFormat((long)((ulong)num2), 1, true);
		this.mStr[0].AppendFormat("{0}");
		this.textPrize.text = this.mStr[0].ToString();
		this.textPrize.SetAllDirty();
		this.textPrize.cachedTextGeneratorForLayout.Invalidate();
		this.textPrize.cachedTextGenerator.Invalidate();
		this.SetCenterText(this.ImgPrize, this.textPrize, 221.7f);
	}

	// Token: 0x0600095C RID: 2396 RVA: 0x000C1718 File Offset: 0x000BF918
	private void AddItem()
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		if (this.mItemList != null && GamblingManager.Instance.m_QueueGamebleItem.Count > 0)
		{
			CommonItemDataType item;
			item.ItemID = GamblingManager.Instance.m_QueueGamebleItem[0].ItemID;
			item.Num = GamblingManager.Instance.m_QueueGamebleItem[0].Num;
			item.ItemRank = GamblingManager.Instance.m_QueueGamebleItem[0].ItemRank;
			GamblingManager.Instance.m_QueueGamebleItem.RemoveAt(0);
			this.mItemList.Insert(0, item);
		}
		if (this.mItemList.Count >= 2)
		{
			this.mShitfHelper.Start();
		}
		this.UpdateItems();
	}

	// Token: 0x0600095D RID: 2397 RVA: 0x000C17F0 File Offset: 0x000BF9F0
	private void UpdateItems()
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		if (this.mItemList != null)
		{
			int num = 0;
			if (this.mShitfHelper != null)
			{
				num = this.mShitfHelper.GetAddItemIdx();
			}
			int num2 = Mathf.Clamp(12 + num, 12, 17);
			this.mStr[num2].ClearString();
			if (this.mItemList[0].Num > 1)
			{
				this.mStr[num2].IntToFormat((long)this.mItemList[0].Num, 1, false);
				if (this.GUIM.IsArabic)
				{
					this.mStr[num2].AppendFormat("{0}X");
				}
				else
				{
					this.mStr[num2].AppendFormat("X{0}");
				}
			}
			this.text_ItmeNum[num].text = this.mStr[num2].ToString();
			this.text_ItmeNum[num].SetAllDirty();
			this.text_ItmeNum[num].cachedTextGenerator.Invalidate();
			Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.mItemList[0].ItemID);
			bool flag = this.GUIM.IsLeadItem(recordByKey.EquipKind);
			this.btn_Item_Rect[num].gameObject.SetActive(true);
			if (flag)
			{
				this.GUIM.ChangeLordEquipImg(this.btn_Item2[num].transform, this.mItemList[0].ItemID, this.mItemList[0].ItemRank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				this.btn_Item[num].gameObject.SetActive(false);
				this.btn_Item2[num].gameObject.SetActive(true);
			}
			else
			{
				this.GUIM.ChangeHeroItemImg(this.btn_Item[num].transform, eHeroOrItem.Item, this.mItemList[0].ItemID, 0, this.mItemList[0].ItemRank, 0);
				this.btn_Item[num].gameObject.SetActive(true);
				this.btn_Item2[num].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x0600095E RID: 2398 RVA: 0x000C1A30 File Offset: 0x000BFC30
	private void UpdateJackPotData()
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		if (GamblingManager.Instance.m_GamebleJackpots != null)
		{
			int count = GamblingManager.Instance.m_GamebleJackpots.Count;
			int num = 0;
			while (num < count && num < this.mJackPotUI.Length)
			{
				int num2 = Mathf.Clamp(1 + num, 1, 3);
				this.mStr[num2].ClearString();
				GameConstants.FormatRoleName(this.mStr[num2], GamblingManager.Instance.m_GamebleJackpots[num].Name, GamblingManager.Instance.m_GamebleJackpots[num].Tag, null, 0, (GamblingManager.Instance.m_GamebleJackpots[num].KingdomID != DataManager.MapDataController.kingdomData.kingdomID) ? GamblingManager.Instance.m_GamebleJackpots[num].KingdomID : 0, null, null, null, null);
				this.mJackPotUI[num].Name.text = this.mStr[num2].ToString();
				num2 = Mathf.Clamp(7 + num, 7, 9);
				this.mStr[num2].ClearString();
				long time = DataManager.Instance.ServerTime - GamblingManager.Instance.m_GamebleJackpots[num].WonTime;
				DataManager.Instance.SetSBTime(time, this.mStr[num2]);
				this.mJackPotUI[num].Time.text = this.mStr[num2].ToString();
				num2 = Mathf.Clamp(4 + num, 4, 6);
				this.mStr[num2].ClearString();
				GameConstants.FormatResourceValue(this.mStr[num2], GamblingManager.Instance.m_GamebleJackpots[num].PrizeWins);
				this.mJackPotUI[num].Num.text = this.mStr[num2].ToString();
				this.mJackPotUI[num].Name.SetAllDirty();
				this.mJackPotUI[num].Name.cachedTextGenerator.Invalidate();
				this.mJackPotUI[num].Num.SetAllDirty();
				this.mJackPotUI[num].Num.cachedTextGenerator.Invalidate();
				this.mJackPotUI[num].Time.SetAllDirty();
				this.mJackPotUI[num].Time.cachedTextGenerator.Invalidate();
				this.mJackPotUI[num].obj.SetActive(true);
				num++;
			}
			if (count > 0 && !this.mJackPotDataPanel.gameObject.activeSelf)
			{
				this.mJackPotDataPanel.gameObject.SetActive(true);
			}
		}
	}

	// Token: 0x0600095F RID: 2399 RVA: 0x000C1CEC File Offset: 0x000BFEEC
	private void SetNpcHP(UIBattle_Gambling.eHpType type = UIBattle_Gambling.eHpType.Normal)
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		this.mNpcHp.gameObject.SetActive(true);
		int num = Mathf.Clamp((int)GamblingManager.Instance.GambleMode, 0, GamblingManager.Instance.m_GambleGameInfo.GambleData.Length - 1);
		if (GamblingManager.Instance.m_GambleGameInfo.GambleData[num].Stage <= 10)
		{
			byte npcHpByStage = 11 - GamblingManager.Instance.m_GambleGameInfo.GambleData[num].Stage;
			if (type == UIBattle_Gambling.eHpType.Normal)
			{
				this.SetNpcHpByStage(npcHpByStage);
			}
			else if (type == UIBattle_Gambling.eHpType.Full)
			{
				this.SetNpcHpByStage(10);
			}
			else if (type == UIBattle_Gambling.eHpType.Zero)
			{
				this.SetNpcHpByStage(0);
			}
			return;
		}
		this.mNpcHp.gameObject.SetActive(false);
	}

	// Token: 0x06000960 RID: 2400 RVA: 0x000C1DC8 File Offset: 0x000BFFC8
	private void SetNpcHpByStage(byte stage)
	{
		this.mStr[10].ClearString();
		float num = (float)stage / 10f;
		if (num >= 0.0001f)
		{
			this.mStr[10].FloatToFormat(num * 100f, 2, true);
		}
		else if (num <= 0f)
		{
			this.mStr[10].FloatToFormat(0f, -1, true);
		}
		else
		{
			this.mStr[10].FloatToFormat(0.01f, -1, true);
		}
		this.mStr[10].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(884u));
		this.imgNpcHpSlider.rectTransform.sizeDelta = new Vector2(338f * num, 16f);
		this.textNpcHpValue.text = this.mStr[10].ToString();
		this.textNpcHpValue.SetAllDirty();
		this.textNpcHpValue.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000961 RID: 2401 RVA: 0x000C1ED0 File Offset: 0x000C00D0
	private void SetNpcName()
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		int num = Mathf.Clamp((int)GamblingManager.Instance.GambleMode, 0, GamblingManager.Instance.m_GambleGameInfo.GambleData.Length - 1);
		ushort monsterID = GamblingManager.Instance.m_GambleEventSave.MonsterID;
		this.mStr[11].ClearString();
		MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(monsterID);
		this.mStr[11].ClearString();
		this.mStr[11].StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.NameID));
		this.mStr[11].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9168u));
		this.textNpcHpName.text = this.mStr[11].ToString();
		this.textNpcHpName.SetAllDirty();
		this.textNpcHpName.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000962 RID: 2402 RVA: 0x000C1FC8 File Offset: 0x000C01C8
	private void UpdateBtnSprite()
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		if (GamblingManager.Instance.GambleMode == UIBattle_Gambling.eMode.Normal)
		{
			this.btn_ChangeModel_Normal.image.sprite = this.mSpArray.GetSprite(0);
			this.btn_ChangeModel_Turbo.image.sprite = this.mSpArray.GetSprite(2);
			this.Img_ChangeNormalFlash.gameObject.SetActive(true);
			this.Img_ChangeTurboFlash.gameObject.SetActive(false);
		}
		else
		{
			this.btn_ChangeModel_Normal.image.sprite = this.mSpArray.GetSprite(0);
			this.btn_ChangeModel_Turbo.image.sprite = this.mSpArray.GetSprite(2);
			this.Img_ChangeNormalFlash.gameObject.SetActive(false);
			this.Img_ChangeTurboFlash.gameObject.SetActive(true);
		}
		this.CheckAlertType();
	}

	// Token: 0x06000963 RID: 2403 RVA: 0x000C20B0 File Offset: 0x000C02B0
	private void UpdateGambleCost(int arg = 0)
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		uint cost = GamblingManager.Instance.GetCost();
		if (DataManager.Instance.RoleAttr.ScardStar < cost)
		{
			this.btn_Hint2.ForTextChange(e_BtnType.e_ChangeText);
		}
		else
		{
			this.btn_Hint2.ForTextChange(e_BtnType.e_Normal);
		}
		this.mStr[18].ClearString();
		if (cost == 0u)
		{
			this.mStr[18].Append(DataManager.Instance.mStringTable.GetStringByID(780u));
		}
		else
		{
			this.mStr[18].IntToFormat((long)((ulong)cost), 1, true);
			this.mStr[18].AppendFormat("{0}");
		}
		this.text_Hint.text = this.mStr[18].ToString();
		this.text_Hint.SetAllDirty();
		this.text_Hint.cachedTextGenerator.Invalidate();
		this.Img_Hint2.sprite = this.mSpArray.GetSprite(4);
		this.Img_Hint2Flash.gameObject.SetActive(false);
		if (cost == 0u)
		{
			if (GamblingManager.Instance.GetRemainFreePlay(GamblingManager.Instance.GambleMode) > 0)
			{
				this.Img_Hint2.sprite = this.mSpArray.GetSprite(5);
				this.Img_Hint2Flash.sprite = this.mSpArray.GetSprite(7);
				this.SetNpcParticleType(NpcParticleType.TypeS);
			}
			else if (GamblingManager.Instance.IsDailyFreeScardStar(GamblingManager.Instance.GambleMode))
			{
				this.Img_Hint2.sprite = this.mSpArray.GetSprite(4);
				this.Img_Hint2Flash.sprite = this.mSpArray.GetSprite(6);
			}
			this.Img_Hint2Flash.gameObject.SetActive(true);
			if (GamblingManager.Instance.GetRemainFreePlay(GamblingManager.Instance.GambleMode) > 0)
			{
				if (!this.bFreeMode && this.ABIsDone && this.Hero_Model != null)
				{
					this.SetNpcAnim(UIBattle_Gambling.NpcAct.victory);
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 19, arg);
				}
				this.bFreeMode = true;
			}
			else if (GamblingManager.Instance.IsDailyFreeScardStar(GamblingManager.Instance.GambleMode))
			{
				this.bFreeMode = false;
			}
		}
		else
		{
			if (this.bFreeMode && this.ABIsDone && this.Hero_Model != null)
			{
				this.SetNpcAnim(UIBattle_Gambling.NpcAct.idle);
			}
			this.bFreeMode = false;
		}
		this.mCount = (int)(GamblingManager.Instance.mComboMax - GamblingManager.Instance.GetRemainFreePlay(GamblingManager.Instance.GambleMode));
		if (this.mCount > 0 && !this.bfadeout)
		{
			this.AddCombo();
		}
		NewbieManager.CheckGambleElite();
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x000C2380 File Offset: 0x000C0580
	private void SetBtnType(UIBattle_Gambling.eMode m)
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		if (m == UIBattle_Gambling.eMode.Normal)
		{
			GamblingManager.Instance.GambleMode = UIBattle_Gambling.eMode.Normal;
			GamblingManager.Instance.saveGambleMode();
			BattleNetwork.RefreshGambleMode(EGambleMode.Normal);
		}
		else
		{
			GamblingManager.Instance.GambleMode = UIBattle_Gambling.eMode.Turbo;
			GamblingManager.Instance.saveGambleMode();
			BattleNetwork.RefreshGambleMode(EGambleMode.Turbo);
		}
	}

	// Token: 0x06000965 RID: 2405 RVA: 0x000C23DC File Offset: 0x000C05DC
	private void UpdateCurCostValue()
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		this.mStr[20].ClearString();
		GameConstants.FormatResourceValue(this.mStr[20], DataManager.Instance.RoleAttr.ScardStar);
		this.text_CostValue.text = this.mStr[20].ToString();
		this.text_CostValue.SetAllDirty();
		this.text_CostValue.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000966 RID: 2406 RVA: 0x000C2454 File Offset: 0x000C0654
	private void UpdateTime()
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		long beginTime = GamblingManager.Instance.m_GambleEventSave.BeginTime;
		long num = (long)((ulong)GamblingManager.Instance.m_GambleEventSave.RequireTime);
		long num2 = beginTime + num;
		long num3;
		if (num2 > DataManager.Instance.ServerTime)
		{
			num3 = num2 - DataManager.Instance.ServerTime;
		}
		else
		{
			num3 = 0L;
		}
		this.mStr[19].ClearString();
		GameConstants.GetTimeString(this.mStr[19], (uint)num3, false, true, false, false, true);
		this.text_TimeValue.text = this.mStr[19].ToString();
		this.text_TimeValue.SetAllDirty();
		this.text_TimeValue.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000967 RID: 2407 RVA: 0x000C2514 File Offset: 0x000C0714
	private void SetGambleBoxAnim(GambleBoxAnim boxAnim)
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		int num = 0;
		if (boxAnim == GambleBoxAnim.idle)
		{
			num = 0;
		}
		else if (boxAnim == GambleBoxAnim.status_1)
		{
			num = 1;
		}
		else if (boxAnim == GambleBoxAnim.status_2)
		{
			num = 2;
		}
		else if (boxAnim == GambleBoxAnim.status_3)
		{
			num = 3;
		}
		this.SetPrize_ModleAnim(this.anim[num]);
	}

	// Token: 0x06000968 RID: 2408 RVA: 0x000C2570 File Offset: 0x000C0770
	private void RandGambleBoxAnim(GambleBoxAnim boxAnim)
	{
		if (!this.bOpenEnd || this.bSpecialNpc)
		{
			return;
		}
		int num = 0;
		if (boxAnim == GambleBoxAnim.idle || boxAnim == GambleBoxAnim.None)
		{
			this.anim_Idx = this.animR_Idle_Idx;
			this.anim_R = this.animR_Idle;
		}
		else if (boxAnim == GambleBoxAnim.status_1)
		{
			this.anim_R = this.animR_S1;
			this.anim_Idx = this.animR_S1_Idx;
		}
		else if (boxAnim == GambleBoxAnim.status_2)
		{
			this.anim_Idx = this.animR_S2_Idx;
			this.anim_R = this.animR_S2;
		}
		else if (boxAnim == GambleBoxAnim.status_3)
		{
			this.anim_Idx = this.animR_S3_Idx;
			this.anim_R = this.animR_S3;
		}
		if (this.Prize_Modle != null)
		{
			int num2 = UnityEngine.Random.Range(1, 101);
			int num3 = 1;
			int num4 = 1;
			this.debugIdx = num2;
			for (int i = 0; i < this.anim_Idx.Length; i++)
			{
				num4 += this.anim_R[i];
				if (num2 >= num3 && num2 < num4)
				{
					num = this.anim_Idx[i];
					break;
				}
				num3 = num4;
			}
			this.SetPrize_ModleAnim(this.anim[num]);
		}
	}

	// Token: 0x06000969 RID: 2409 RVA: 0x000C26A4 File Offset: 0x000C08A4
	private void SetPrize_ModleAnim(string animStr)
	{
		if (this.Prize_Modle != null)
		{
			this.tmpAN_Prize = this.Prize_Modle.GetComponent<Animation>();
			if (this.tmpAN_Prize != null)
			{
				this.tmpAN_Prize.wrapMode = WrapMode.Loop;
				this.tmpAN_Prize[animStr].layer = 1;
				this.tmpAN_Prize[animStr].wrapMode = WrapMode.Loop;
				this.tmpAN_Prize.CrossFade(animStr);
				this.tmpAN_Prize.clip = this.tmpAN_Prize.GetClip(animStr);
			}
			if (string.Compare(animStr, this.anim[0]) == 0)
			{
				GamblingManager.Instance.m_GambleBoxAnim = GambleBoxAnim.idle;
				this.Particle_Pos[2].gameObject.SetActive(false);
			}
			else
			{
				if (string.Compare(animStr, this.anim[1]) == 0)
				{
					GamblingManager.Instance.m_GambleBoxAnim = GambleBoxAnim.status_1;
				}
				if (string.Compare(animStr, this.anim[2]) == 0)
				{
					GamblingManager.Instance.m_GambleBoxAnim = GambleBoxAnim.status_2;
				}
				if (string.Compare(animStr, this.anim[3]) == 0)
				{
					GamblingManager.Instance.m_GambleBoxAnim = GambleBoxAnim.status_3;
				}
				this.Particle_Pos[2].gameObject.SetActive(true);
			}
		}
	}

	// Token: 0x0600096A RID: 2410 RVA: 0x000C27DC File Offset: 0x000C09DC
	private void SetNpcParticleType(NpcParticleType type)
	{
		if (type == NpcParticleType.Type1)
		{
			if (!this.Particle_Pos[0].gameObject.activeSelf)
			{
				this.Particle_Pos[0].gameObject.SetActive(true);
			}
			this.Particle_Pos[1].gameObject.SetActive(false);
			this.Particle_Pos[4].gameObject.SetActive(false);
			this.Particle_Pos[5].gameObject.SetActive(false);
		}
		else if (type == NpcParticleType.Type2)
		{
			if (!this.Particle_Pos[4].gameObject.activeSelf)
			{
				this.Particle_Pos[4].gameObject.SetActive(true);
			}
			this.Particle_Pos[0].gameObject.SetActive(false);
			this.Particle_Pos[1].gameObject.SetActive(false);
			this.Particle_Pos[5].gameObject.SetActive(false);
		}
		else if (type == NpcParticleType.Type3)
		{
			if (!this.Particle_Pos[5].gameObject.activeSelf)
			{
				this.Particle_Pos[5].gameObject.SetActive(true);
			}
			this.Particle_Pos[0].gameObject.SetActive(false);
			this.Particle_Pos[1].gameObject.SetActive(false);
			this.Particle_Pos[4].gameObject.SetActive(false);
		}
		else if (type == NpcParticleType.TypeS)
		{
			if (!this.Particle_Pos[1].gameObject.activeSelf)
			{
				this.Particle_Pos[1].gameObject.SetActive(true);
			}
			this.Particle_Pos[0].gameObject.SetActive(false);
			this.Particle_Pos[4].gameObject.SetActive(false);
			this.Particle_Pos[5].gameObject.SetActive(false);
		}
		else if (type == NpcParticleType.None)
		{
			this.Particle_Pos[1].gameObject.SetActive(false);
			this.Particle_Pos[0].gameObject.SetActive(false);
			this.Particle_Pos[4].gameObject.SetActive(false);
			this.Particle_Pos[5].gameObject.SetActive(false);
		}
		GamblingManager.Instance.m_NpcParticleType = type;
	}

	// Token: 0x0600096B RID: 2411 RVA: 0x000C2A04 File Offset: 0x000C0C04
	private void RandNpcParticleType()
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		int num = 0;
		if (GamblingManager.Instance.m_NpcParticleType == NpcParticleType.None)
		{
			this.anim_Idx = this.animR_Idle_Idx;
			this.anim_R = this.animR_Idle;
		}
		else if (GamblingManager.Instance.m_NpcParticleType == NpcParticleType.Type1)
		{
			this.anim_Idx = this.animR_S1_Idx;
			this.anim_R = this.animR_S1;
		}
		else if (GamblingManager.Instance.m_NpcParticleType == NpcParticleType.Type2)
		{
			this.anim_Idx = this.animR_S2_Idx;
			this.anim_R = this.animR_S2;
		}
		else if (GamblingManager.Instance.m_NpcParticleType == NpcParticleType.Type3)
		{
			this.anim_Idx = this.animR_S3_Idx;
			this.anim_R = this.animR_S3;
		}
		int num2 = UnityEngine.Random.Range(1, 101);
		int num3 = 1;
		int num4 = 1;
		this.debugIdx_P = num2;
		for (int i = 0; i < this.anim_Idx.Length; i++)
		{
			num4 += this.anim_R[i];
			if (num2 >= num3 && num2 < num4)
			{
				num = this.anim_Idx[i];
				break;
			}
			num3 = num4;
		}
		if (num == 3)
		{
			this.SetNpcParticleType(NpcParticleType.Type3);
		}
		else if (num == 2)
		{
			this.SetNpcParticleType(NpcParticleType.Type2);
		}
		else if (num == 1)
		{
			this.SetNpcParticleType(NpcParticleType.Type1);
		}
		else if (num == 0)
		{
			this.SetNpcParticleType(NpcParticleType.None);
		}
		if (BattleController.GambleMode == EGambleMode.Normal)
		{
			AudioManager.Instance.PlaySFX(DataManager.Instance.SkillTable.GetRecordByKey(858).HitSound, 0f, PitchKind.NoPitch, null, null);
		}
		else
		{
			AudioManager.Instance.PlaySFX(DataManager.Instance.SkillTable.GetRecordByKey(859).HitSound, 0f, PitchKind.NoPitch, null, null);
		}
	}

	// Token: 0x0600096C RID: 2412 RVA: 0x000C2BF0 File Offset: 0x000C0DF0
	private void UpdateJackPot_Self()
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		this.ShowSP = true;
		this.SPShowPhase = 0f;
		UIBattle_Gambling.SPRankChange = 2u;
		this.SPShowTime = 0f;
		UIBattle_Gambling.SPScoreValue = 0u;
		if (GamblingManager.Instance.m_GamebleJackpots.Count > 0)
		{
			UIBattle_Gambling.SPScoreFlyValue = GamblingManager.Instance.m_GamebleJackpots[0].PrizeWins;
			AudioManager.Instance.PlaySFX(41026, 0f, PitchKind.NoPitch, null, null);
		}
		this.SPT.gameObject.SetActive(true);
		this.ShowPrizeTime = 3f;
	}

	// Token: 0x0600096D RID: 2413 RVA: 0x000C2C9C File Offset: 0x000C0E9C
	private void SendUse()
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		if (this.ABIsDone && this.Hero_Model != null && !this.tmpAN.IsPlaying(this.NpcActStr[4]))
		{
			this.mNpcAct = UIBattle_Gambling.NpcAct.attack;
			if (this.tmpAN.GetClip(this.mNpcAct.ToString()) != null)
			{
				this.SetNpcAnim(this.mNpcAct);
			}
			GamblingManager.Instance.Send_MSG_REQUEST_GAMBLE_STARTGAME((byte)GamblingManager.Instance.GambleMode);
			if (GamblingManager.Instance.m_GambleBoxAnim == GambleBoxAnim.None || GamblingManager.Instance.m_GambleBoxAnim == GambleBoxAnim.idle)
			{
				this.RandGambleBoxAnim(GamblingManager.Instance.m_GambleBoxAnim);
			}
			else if (GamblingManager.Instance.m_GambleBoxAnim == GambleBoxAnim.status_1)
			{
				this.RandGambleBoxAnim(GamblingManager.Instance.m_GambleBoxAnim);
			}
			else if (GamblingManager.Instance.m_GambleBoxAnim == GambleBoxAnim.status_2)
			{
				this.RandGambleBoxAnim(GamblingManager.Instance.m_GambleBoxAnim);
			}
			else if (GamblingManager.Instance.m_GambleBoxAnim == GambleBoxAnim.status_3)
			{
				this.RandGambleBoxAnim(GamblingManager.Instance.m_GambleBoxAnim);
			}
			this.RandNpcParticleType();
		}
	}

	// Token: 0x0600096E RID: 2414 RVA: 0x000C2DDC File Offset: 0x000C0FDC
	private void OpennFilterUI()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9642u));
		cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(1545u));
		cstring2.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9642u));
		cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(1546u));
		this.GUIM.OpenMessageBox(cstring.ToString(), cstring2.ToString(), DataManager.Instance.mStringTable.GetStringByID(5723u), this, 1, 0, true, false, false, false, false);
	}

	// Token: 0x0600096F RID: 2415 RVA: 0x000C2E9C File Offset: 0x000C109C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 == 1)
			{
				GUIManager.Instance.OpenItemKindFilterUI(10, 40, 0);
			}
		}
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x000C2ED4 File Offset: 0x000C10D4
	private void SetNpcName(CString str)
	{
		str.ClearString();
		ushort teamID = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(GamblingManager.Instance.BattleMonsterID).MapTeamInfo[0].TeamID;
		HeroTeam recordByKey = DataManager.Instance.TeamTable.GetRecordByKey(teamID);
		Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey.Arrays[10].Hero);
		str.Append(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey2.HeroName));
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x000C2F64 File Offset: 0x000C1164
	private void SetCenterText(Image image, UIText text, float width)
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		float num = 10f;
		float x = (width - (image.rectTransform.sizeDelta.x + text.preferredWidth + num)) / 2f;
		image.rectTransform.anchoredPosition = new Vector2(x, image.rectTransform.anchoredPosition.y);
		text.rectTransform.anchoredPosition = new Vector2(image.rectTransform.anchoredPosition.x + image.rectTransform.sizeDelta.x + num, text.rectTransform.anchoredPosition.y);
		text.UpdateArabicPos();
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x000C3024 File Offset: 0x000C1224
	public void CloseUI()
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		this.GUIM.CloseMenu(EGUIWindow.UI_Battle_Gambling);
		this.GUIM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
	}

	// Token: 0x06000973 RID: 2419 RVA: 0x000C3060 File Offset: 0x000C1260
	private void SetInputOff(bool bOff)
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		this.InputOff.gameObject.SetActive(bOff);
		this.Img_Hint2_Black.gameObject.SetActive(bOff);
	}

	// Token: 0x06000974 RID: 2420 RVA: 0x000C309C File Offset: 0x000C129C
	private void AddCombo()
	{
		this.text_ComboCount.gameObject.SetActive(true);
		this.text_Combo.gameObject.SetActive(true);
		this.text_ComboCount.color = new Color(1f, 0.89f, 0.38f, 1f);
		this.text_Combo.color = new Color(1f, 0.89f, 0.38f, 1f);
		this.mStatus = 1;
		this.mComboTime = 0f;
		this.text_ComboCount.resizeTextMaxSize = 150;
		this.text_ComboCount.rectTransform.anchoredPosition = new Vector2(this.text_ComboCount.rectTransform.anchoredPosition.x, 0f);
		StringManager.IntToStr(this.mStrComboCount, (long)this.mCount, 1, false);
		this.text_ComboCount.text = this.mStrComboCount.ToString();
		this.text_ComboCount.SetAllDirty();
		this.text_ComboCount.cachedTextGenerator.Invalidate();
		this.text_Combo.resizeTextMaxSize = 45;
		this.mtextHeight = this.text_Combo.preferredHeight;
		if (this.mCount == (int)GamblingManager.Instance.mComboMax)
		{
			this.bfadeout = true;
			GamblingManager.Instance.mComboMax = 0;
			this.mCount = 0;
		}
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x000C31FC File Offset: 0x000C13FC
	private void UpdateCombo()
	{
		if (this.mStatus > 0 && this.text_ComboCount != null && this.text_Combo != null)
		{
			if (this.mStatus == 1)
			{
				if (this.mComboTime <= 0.05f)
				{
					this.mComboTime += Time.smoothDeltaTime;
					float t = this.mComboTime / 0.05f;
					float num = Mathf.Lerp(0.39f, 1f, t);
					if (this.GUIM.IsArabic)
					{
						this.text_ComboCount.rectTransform.localScale = new Vector3(-num, num, num);
					}
					else
					{
						this.text_ComboCount.rectTransform.localScale = new Vector3(num, num, num);
					}
					float num2 = Mathf.Lerp(0.32f, 1f, t);
					if (this.GUIM.IsArabic)
					{
						this.text_Combo.rectTransform.localScale = new Vector3(-num2, num2, num2);
					}
					else
					{
						this.text_Combo.rectTransform.localScale = new Vector3(num2, num2, num2);
					}
					float y = Mathf.Lerp(0f, 20f, t);
					this.text_ComboCount.rectTransform.anchoredPosition = new Vector2(this.text_ComboCount.rectTransform.anchoredPosition.x, y);
				}
				else
				{
					this.mStatus = 2;
					this.mtextHeight = this.text_Combo.preferredHeight;
					this.mtextTopHeight = this.text_ComboCount.rectTransform.anchoredPosition.y;
					this.mComboTime = 0f;
				}
			}
			else if (this.mStatus == 2)
			{
				if (this.mComboTime <= 0.2f)
				{
					this.mComboTime += Time.smoothDeltaTime;
					float t = this.mComboTime / 0.2f;
					float num = Mathf.Lerp(1f, 0.6f, t);
					if (this.GUIM.IsArabic)
					{
						this.text_ComboCount.rectTransform.localScale = new Vector3(-num, num, num);
					}
					else
					{
						this.text_ComboCount.rectTransform.localScale = new Vector3(num, num, num);
					}
					float num2 = Mathf.Lerp(1f, 0.67f, t);
					if (this.GUIM.IsArabic)
					{
						this.text_Combo.rectTransform.localScale = new Vector3(-num2, num2, num2);
					}
					else
					{
						this.text_Combo.rectTransform.localScale = new Vector3(num2, num2, num2);
					}
					float y = Mathf.Lerp(20f, 0f, t);
					this.text_ComboCount.rectTransform.anchoredPosition = new Vector2(this.text_ComboCount.rectTransform.anchoredPosition.x, y);
				}
				else
				{
					this.mStatus = 3;
					this.mComboTime = 0f;
				}
			}
			else if (this.mStatus == 3 && this.bfadeout)
			{
				if (this.mComboTime < 2f)
				{
					this.mComboTime += Time.smoothDeltaTime;
					this.text_ComboCount.color = new Color(1f, 0.89f, 0.38f, 2f - this.mComboTime);
					this.text_Combo.color = new Color(1f, 0.89f, 0.38f, 2f - this.mComboTime);
				}
				else
				{
					this.bfadeout = false;
					this.mStatus = 0;
					this.mComboTime = 0f;
					this.text_ComboCount.gameObject.SetActive(false);
					this.text_Combo.gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06000976 RID: 2422 RVA: 0x000C35D8 File Offset: 0x000C17D8
	private void UpdateMoney()
	{
		if (this.textDimPanle != null)
		{
			this.mStr[27].ClearString();
			GameConstants.FormatResourceValue(this.mStr[27], DataManager.Instance.RoleAttr.Diamond);
			this.textDimPanle.text = this.mStr[27].ToString();
			this.textDimPanle.SetAllDirty();
			this.textDimPanle.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06000977 RID: 2423 RVA: 0x000C3658 File Offset: 0x000C1858
	private void CheckAlertType()
	{
		if (GamblingManager.Instance.GambleMode == UIBattle_Gambling.eMode.Normal)
		{
			if (GamblingManager.Instance.IsDailyFreeScardStar(UIBattle_Gambling.eMode.Turbo))
			{
				this.AlertPanel.gameObject.SetActive(true);
			}
			else
			{
				this.AlertPanel.gameObject.SetActive(false);
			}
		}
		else
		{
			this.AlertPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x000C36C4 File Offset: 0x000C18C4
	private void RandNpcIdle()
	{
		int npcAnim = UnityEngine.Random.Range(1, 4);
		if (!this.Particle_Pos[1].gameObject.activeSelf)
		{
			this.SetNpcAnim((UIBattle_Gambling.NpcAct)npcAnim);
		}
	}

	// Token: 0x06000979 RID: 2425 RVA: 0x000C36F8 File Offset: 0x000C18F8
	private void SetNpcAnim(UIBattle_Gambling.NpcAct act)
	{
		if (!this.tmpAN)
		{
			return;
		}
		if (act == UIBattle_Gambling.NpcAct.victory)
		{
			if (this.tmpAN.IsPlaying(this.NpcActStr[4]))
			{
				this.bNpcAttackVictory = true;
			}
			else
			{
				this.bNpcAttackVictory = false;
				this.tmpAN.CrossFade(this.NpcActStr[5]);
				this.tmpAN.CrossFade(this.NpcActStr[6]);
				this.tmpAN.clip = this.tmpAN.GetClip(this.NpcActStr[6]);
			}
		}
		else if (act == UIBattle_Gambling.NpcAct.attack)
		{
			this.RandIdleTime = 10f;
			this.tmpAN.CrossFade(this.NpcActStr[(int)((byte)act)]);
		}
		else if (act == UIBattle_Gambling.NpcAct.idle)
		{
			this.tmpAN.CrossFade(this.NpcActStr[(int)((byte)act)]);
			this.tmpAN.clip = this.tmpAN.GetClip(this.NpcActStr[(int)((byte)act)]);
		}
		else
		{
			this.tmpAN.CrossFade(this.NpcActStr[(int)((byte)act)]);
		}
		this.mNpcAct = act;
	}

	// Token: 0x0600097A RID: 2426 RVA: 0x000C3818 File Offset: 0x000C1A18
	public void SetAlertImageAlpha(float Alpha)
	{
		if (GUIManager.Instance.m_AlertImageIndex == 0 && this.alertBlock != null && this.alertBlock.gameObject.activeSelf)
		{
			Color color = new Color(1f, 1f, 1f, Alpha);
			if (this.alertBlock_T != null)
			{
				this.alertBlock_T.color = color;
			}
			if (this.alertBlock_B != null)
			{
				this.alertBlock_B.color = color;
			}
			if (this.alertBlock_L != null)
			{
				this.alertBlock_L.color = color;
			}
			if (this.alertBlock_R != null)
			{
				this.alertBlock_R.color = color;
			}
		}
	}

	// Token: 0x0600097B RID: 2427 RVA: 0x000C38E8 File Offset: 0x000C1AE8
	public void SetAlertBlock(bool bOpenAlertBlock)
	{
		this.alertBlock.gameObject.SetActive(bOpenAlertBlock);
	}

	// Token: 0x04001EBF RID: 7871
	private const int MaxBtnItem = 6;

	// Token: 0x04001EC0 RID: 7872
	private const float MaxRandIdleTime = 10f;

	// Token: 0x04001EC1 RID: 7873
	private const float TextDisplayShowTime = 1f;

	// Token: 0x04001EC2 RID: 7874
	public readonly string[] NpcActStr = new string[]
	{
		"idle",
		"idle02",
		"idle03",
		"idle04",
		"attack",
		"victory",
		"v_idle"
	};

	// Token: 0x04001EC3 RID: 7875
	private Transform GameT;

	// Token: 0x04001EC4 RID: 7876
	private Transform Tmp;

	// Token: 0x04001EC5 RID: 7877
	private Transform P_T;

	// Token: 0x04001EC6 RID: 7878
	private Transform SPT;

	// Token: 0x04001EC7 RID: 7879
	private Transform InputOff;

	// Token: 0x04001EC8 RID: 7880
	private Transform Hero_Pos;

	// Token: 0x04001EC9 RID: 7881
	private Transform IPhoneXPanel;

	// Token: 0x04001ECA RID: 7882
	public Transform DimPanle;

	// Token: 0x04001ECB RID: 7883
	private Transform[] Particle_Pos = new Transform[6];

	// Token: 0x04001ECC RID: 7884
	private Transform PrizePos3D;

	// Token: 0x04001ECD RID: 7885
	private Transform Hero_Model;

	// Token: 0x04001ECE RID: 7886
	private Transform Prize_Modle;

	// Token: 0x04001ECF RID: 7887
	private Transform BGT;

	// Token: 0x04001ED0 RID: 7888
	private Transform AlertPanel;

	// Token: 0x04001ED1 RID: 7889
	private Transform ItemListT;

	// Token: 0x04001ED2 RID: 7890
	private Transform GoldHintT;

	// Token: 0x04001ED3 RID: 7891
	private Transform SPBgTF;

	// Token: 0x04001ED4 RID: 7892
	private AssetBundle AB;

	// Token: 0x04001ED5 RID: 7893
	private AssetBundle Prize_AB;

	// Token: 0x04001ED6 RID: 7894
	private AssetBundleRequest AR;

	// Token: 0x04001ED7 RID: 7895
	private AssetBundleRequest Prize_AR;

	// Token: 0x04001ED8 RID: 7896
	private UIButton btn_EXIT;

	// Token: 0x04001ED9 RID: 7897
	public UIButton btn_Hint;

	// Token: 0x04001EDA RID: 7898
	public UIButton btn_Hint2;

	// Token: 0x04001EDB RID: 7899
	private UIButton btn_ItemList;

	// Token: 0x04001EDC RID: 7900
	private UIButton btn_ChangeModel_Normal;

	// Token: 0x04001EDD RID: 7901
	public UIButton btn_ChangeModel_Turbo;

	// Token: 0x04001EDE RID: 7902
	private UIButton btn_InfoBtn;

	// Token: 0x04001EDF RID: 7903
	private Image Img_GoldHint;

	// Token: 0x04001EE0 RID: 7904
	public Image Img_ItemListT;

	// Token: 0x04001EE1 RID: 7905
	private Image Img_Hint2Flash;

	// Token: 0x04001EE2 RID: 7906
	private Image Img_Hint2;

	// Token: 0x04001EE3 RID: 7907
	private Image Img_Hint2_Black;

	// Token: 0x04001EE4 RID: 7908
	private Image Img_ChangeNormalFlash;

	// Token: 0x04001EE5 RID: 7909
	private Image Img_ChangeNormal;

	// Token: 0x04001EE6 RID: 7910
	private Image Img_ChangeTurboFlash;

	// Token: 0x04001EE7 RID: 7911
	private Image Img_ChangeTurbo;

	// Token: 0x04001EE8 RID: 7912
	private UIText text_Hint;

	// Token: 0x04001EE9 RID: 7913
	private UIText text_Hint2;

	// Token: 0x04001EEA RID: 7914
	private UIText text_ChangeModel_Normal;

	// Token: 0x04001EEB RID: 7915
	private UIText text_ChangeModel_Turbo;

	// Token: 0x04001EEC RID: 7916
	private UIText text_TimeValue;

	// Token: 0x04001EED RID: 7917
	private UIText text_CostValue;

	// Token: 0x04001EEE RID: 7918
	private UIButton btn_Filter;

	// Token: 0x04001EEF RID: 7919
	private UIButton btn_SP;

	// Token: 0x04001EF0 RID: 7920
	private UIText textPrize;

	// Token: 0x04001EF1 RID: 7921
	private Image ImgPrize;

	// Token: 0x04001EF2 RID: 7922
	private UIText[] text_ItmeNum = new UIText[6];

	// Token: 0x04001EF3 RID: 7923
	private RectTransform[] btn_Item_Rect = new RectTransform[6];

	// Token: 0x04001EF4 RID: 7924
	public UIHIBtn[] btn_Item = new UIHIBtn[6];

	// Token: 0x04001EF5 RID: 7925
	private UILEBtn[] btn_Item2 = new UILEBtn[6];

	// Token: 0x04001EF6 RID: 7926
	private ShitfHelper mShitfHelper = new ShitfHelper();

	// Token: 0x04001EF7 RID: 7927
	private GameObject mJackPotDataPanel;

	// Token: 0x04001EF8 RID: 7928
	private UIBattle_Gambling.JackPotUI[] mJackPotUI = new UIBattle_Gambling.JackPotUI[3];

	// Token: 0x04001EF9 RID: 7929
	private GameObject mNpcHp;

	// Token: 0x04001EFA RID: 7930
	private UIText textNpcHpValue;

	// Token: 0x04001EFB RID: 7931
	private UIText textNpcHpName;

	// Token: 0x04001EFC RID: 7932
	private Image imgNpcHpSlider;

	// Token: 0x04001EFD RID: 7933
	private UISpritesArray mSpArray;

	// Token: 0x04001EFE RID: 7934
	private GUIManager GUIM;

	// Token: 0x04001EFF RID: 7935
	private Door door;

	// Token: 0x04001F00 RID: 7936
	private Font TTFont;

	// Token: 0x04001F01 RID: 7937
	private CString[] mStr = new CString[28];

	// Token: 0x04001F02 RID: 7938
	private CString[] SPStrings = new CString[4];

	// Token: 0x04001F03 RID: 7939
	private GameObject go2;

	// Token: 0x04001F04 RID: 7940
	private GameObject go;

	// Token: 0x04001F05 RID: 7941
	private int AssetKey;

	// Token: 0x04001F06 RID: 7942
	private int AssetKey2;

	// Token: 0x04001F07 RID: 7943
	private bool bOpenEnd;

	// Token: 0x04001F08 RID: 7944
	private bool ABIsDone;

	// Token: 0x04001F09 RID: 7945
	private bool ABIsDone_Prize;

	// Token: 0x04001F0A RID: 7946
	private bool bCanInput = true;

	// Token: 0x04001F0B RID: 7947
	private Animation tmpAN;

	// Token: 0x04001F0C RID: 7948
	private Animation tmpAN_Prize;

	// Token: 0x04001F0D RID: 7949
	private UIBattle_Gambling.NpcAct mNpcAct;

	// Token: 0x04001F0E RID: 7950
	private bool bNpcAttackVictory;

	// Token: 0x04001F0F RID: 7951
	private GameObject[] EffectObj = new GameObject[5];

	// Token: 0x04001F10 RID: 7952
	private float CDTime;

	// Token: 0x04001F11 RID: 7953
	private float ShowPrizeTime;

	// Token: 0x04001F12 RID: 7954
	private float RandIdleTime = 10f;

	// Token: 0x04001F13 RID: 7955
	private List<CommonItemDataType> mItemList = new List<CommonItemDataType>();

	// Token: 0x04001F14 RID: 7956
	private Image SPBG;

	// Token: 0x04001F15 RID: 7957
	private Image SPRankUpDown;

	// Token: 0x04001F16 RID: 7958
	private UIText SPName;

	// Token: 0x04001F17 RID: 7959
	private UIText SPScore;

	// Token: 0x04001F18 RID: 7960
	private UIText SPScoreFly;

	// Token: 0x04001F19 RID: 7961
	private UIText SPRank;

	// Token: 0x04001F1A RID: 7962
	private RectTransform SPFly;

	// Token: 0x04001F1B RID: 7963
	private bool bAdjustSPRankUpDownPos;

	// Token: 0x04001F1C RID: 7964
	private bool SPReady;

	// Token: 0x04001F1D RID: 7965
	private bool ShowSP;

	// Token: 0x04001F1E RID: 7966
	private float[] SPShowTiming = new float[]
	{
		0.4f,
		0.2f,
		0.05f,
		0.1f,
		0.4f,
		0.1f,
		0.1f,
		0.8f,
		0.4f
	};

	// Token: 0x04001F1F RID: 7967
	private float SPShowTime;

	// Token: 0x04001F20 RID: 7968
	private float SPShowPhase;

	// Token: 0x04001F21 RID: 7969
	public static uint SPScoreValue;

	// Token: 0x04001F22 RID: 7970
	public static uint SPScoreFlyValue;

	// Token: 0x04001F23 RID: 7971
	public static uint SPRankChange;

	// Token: 0x04001F24 RID: 7972
	private string[] anim = new string[]
	{
		"idle",
		"status_1",
		"status_2",
		"status_3"
	};

	// Token: 0x04001F25 RID: 7973
	private int[] animR_Idle = new int[]
	{
		1,
		3,
		8,
		88
	};

	// Token: 0x04001F26 RID: 7974
	private int[] animR_Idle_Idx;

	// Token: 0x04001F27 RID: 7975
	private int[] animR_S1;

	// Token: 0x04001F28 RID: 7976
	private int[] animR_S1_Idx;

	// Token: 0x04001F29 RID: 7977
	private int[] animR_S2;

	// Token: 0x04001F2A RID: 7978
	private int[] animR_S2_Idx;

	// Token: 0x04001F2B RID: 7979
	private int[] animR_S3;

	// Token: 0x04001F2C RID: 7980
	private int[] animR_S3_Idx;

	// Token: 0x04001F2D RID: 7981
	private int[] anim_R;

	// Token: 0x04001F2E RID: 7982
	private int[] anim_Idx;

	// Token: 0x04001F2F RID: 7983
	private bool bSpecialNpc;

	// Token: 0x04001F30 RID: 7984
	public UIRunningTextEX RunningText;

	// Token: 0x04001F31 RID: 7985
	private bool bFreeMode;

	// Token: 0x04001F32 RID: 7986
	private List<byte> DisplayQueue;

	// Token: 0x04001F33 RID: 7987
	private float? TextDisplayTime;

	// Token: 0x04001F34 RID: 7988
	private Transform ComboT;

	// Token: 0x04001F35 RID: 7989
	private UIText text_ComboCount;

	// Token: 0x04001F36 RID: 7990
	private UIText text_Combo;

	// Token: 0x04001F37 RID: 7991
	private UIText textDimPanle;

	// Token: 0x04001F38 RID: 7992
	private UIButton btnDimPanle;

	// Token: 0x04001F39 RID: 7993
	private CString mStrComboCount;

	// Token: 0x04001F3A RID: 7994
	private int CountMax;

	// Token: 0x04001F3B RID: 7995
	private float mComboTime;

	// Token: 0x04001F3C RID: 7996
	private int mStatus;

	// Token: 0x04001F3D RID: 7997
	private int mCount;

	// Token: 0x04001F3E RID: 7998
	private bool bfadeout;

	// Token: 0x04001F3F RID: 7999
	private float mtextHeight;

	// Token: 0x04001F40 RID: 8000
	private float mtextTopHeight;

	// Token: 0x04001F41 RID: 8001
	private float tmpY;

	// Token: 0x04001F42 RID: 8002
	private Transform alertBlock;

	// Token: 0x04001F43 RID: 8003
	private Image alertBlock_T;

	// Token: 0x04001F44 RID: 8004
	private Image alertBlock_B;

	// Token: 0x04001F45 RID: 8005
	private Image alertBlock_L;

	// Token: 0x04001F46 RID: 8006
	private Image alertBlock_R;

	// Token: 0x04001F47 RID: 8007
	private float mShiftTime;

	// Token: 0x04001F48 RID: 8008
	private int debugIdx;

	// Token: 0x04001F49 RID: 8009
	private int debugIdx_P;

	// Token: 0x020001F7 RID: 503
	private enum GUIGambling_btn
	{
		// Token: 0x04001F4B RID: 8011
		btn_EXIT,
		// Token: 0x04001F4C RID: 8012
		btn_Hint,
		// Token: 0x04001F4D RID: 8013
		btn_Hint2,
		// Token: 0x04001F4E RID: 8014
		btn_ChangeModel_Normal,
		// Token: 0x04001F4F RID: 8015
		btn_ChangeModel_Turbo,
		// Token: 0x04001F50 RID: 8016
		btn_GoldHint,
		// Token: 0x04001F51 RID: 8017
		btn_ItemList,
		// Token: 0x04001F52 RID: 8018
		btn_Info,
		// Token: 0x04001F53 RID: 8019
		btn_Filter,
		// Token: 0x04001F54 RID: 8020
		btn_SP,
		// Token: 0x04001F55 RID: 8021
		btn_Dim
	}

	// Token: 0x020001F8 RID: 504
	private enum eGamblingUI
	{
		// Token: 0x04001F57 RID: 8023
		ChangBg,
		// Token: 0x04001F58 RID: 8024
		btn_hit1,
		// Token: 0x04001F59 RID: 8025
		btn_hit2,
		// Token: 0x04001F5A RID: 8026
		btn_ItemList,
		// Token: 0x04001F5B RID: 8027
		DirectionalLight,
		// Token: 0x04001F5C RID: 8028
		HeroPos,
		// Token: 0x04001F5D RID: 8029
		ParticlePos,
		// Token: 0x04001F5E RID: 8030
		PrizePos3D,
		// Token: 0x04001F5F RID: 8031
		btn_chang,
		// Token: 0x04001F60 RID: 8032
		btn_chang2,
		// Token: 0x04001F61 RID: 8033
		Text_chang,
		// Token: 0x04001F62 RID: 8034
		ItemT,
		// Token: 0x04001F63 RID: 8035
		InfoImage,
		// Token: 0x04001F64 RID: 8036
		InofBtn,
		// Token: 0x04001F65 RID: 8037
		JackPotData,
		// Token: 0x04001F66 RID: 8038
		T_goldHint,
		// Token: 0x04001F67 RID: 8039
		Img_ItemList,
		// Token: 0x04001F68 RID: 8040
		Image,
		// Token: 0x04001F69 RID: 8041
		NpcHp,
		// Token: 0x04001F6A RID: 8042
		EXIT_BG
	}

	// Token: 0x020001F9 RID: 505
	private enum eGamblingStr
	{
		// Token: 0x04001F6C RID: 8044
		Prize,
		// Token: 0x04001F6D RID: 8045
		JackPotName1,
		// Token: 0x04001F6E RID: 8046
		JackPotName2,
		// Token: 0x04001F6F RID: 8047
		JackPotName3,
		// Token: 0x04001F70 RID: 8048
		JackPotNum1,
		// Token: 0x04001F71 RID: 8049
		JackPotNum2,
		// Token: 0x04001F72 RID: 8050
		JackPotNum3,
		// Token: 0x04001F73 RID: 8051
		JackPotTime1,
		// Token: 0x04001F74 RID: 8052
		JackPotTime2,
		// Token: 0x04001F75 RID: 8053
		JackPotTime3,
		// Token: 0x04001F76 RID: 8054
		NpcHPValue,
		// Token: 0x04001F77 RID: 8055
		NpcName,
		// Token: 0x04001F78 RID: 8056
		ItemNum1,
		// Token: 0x04001F79 RID: 8057
		ItemNum2,
		// Token: 0x04001F7A RID: 8058
		ItemNum3,
		// Token: 0x04001F7B RID: 8059
		ItemNum4,
		// Token: 0x04001F7C RID: 8060
		ItemNum5,
		// Token: 0x04001F7D RID: 8061
		ItemNum6,
		// Token: 0x04001F7E RID: 8062
		GambleCost,
		// Token: 0x04001F7F RID: 8063
		TimeValue,
		// Token: 0x04001F80 RID: 8064
		AllCostValue,
		// Token: 0x04001F81 RID: 8065
		MesgBox,
		// Token: 0x04001F82 RID: 8066
		SPStrings1,
		// Token: 0x04001F83 RID: 8067
		SPStrings2,
		// Token: 0x04001F84 RID: 8068
		SPStrings3,
		// Token: 0x04001F85 RID: 8069
		SPStrings4,
		// Token: 0x04001F86 RID: 8070
		MesgBox_NpcNmae,
		// Token: 0x04001F87 RID: 8071
		DimStr,
		// Token: 0x04001F88 RID: 8072
		Max
	}

	// Token: 0x020001FA RID: 506
	private enum eBtnSprite
	{
		// Token: 0x04001F8A RID: 8074
		Normal_Off,
		// Token: 0x04001F8B RID: 8075
		Normal_On,
		// Token: 0x04001F8C RID: 8076
		Turbo_Off,
		// Token: 0x04001F8D RID: 8077
		Turbo_On,
		// Token: 0x04001F8E RID: 8078
		Btn_Yellow,
		// Token: 0x04001F8F RID: 8079
		Btn_Purple,
		// Token: 0x04001F90 RID: 8080
		Btn_Yellow_Flash,
		// Token: 0x04001F91 RID: 8081
		Btn_Purple_Flash
	}

	// Token: 0x020001FB RID: 507
	public enum eMode
	{
		// Token: 0x04001F93 RID: 8083
		Turbo,
		// Token: 0x04001F94 RID: 8084
		Normal,
		// Token: 0x04001F95 RID: 8085
		Max
	}

	// Token: 0x020001FC RID: 508
	private enum eHpType
	{
		// Token: 0x04001F97 RID: 8087
		Normal,
		// Token: 0x04001F98 RID: 8088
		Full,
		// Token: 0x04001F99 RID: 8089
		Zero
	}

	// Token: 0x020001FD RID: 509
	private enum eParticle
	{
		// Token: 0x04001F9B RID: 8091
		eNpc01,
		// Token: 0x04001F9C RID: 8092
		eNpc02,
		// Token: 0x04001F9D RID: 8093
		eGamebleBox,
		// Token: 0x04001F9E RID: 8094
		eNpc03,
		// Token: 0x04001F9F RID: 8095
		eJackPot,
		// Token: 0x04001FA0 RID: 8096
		eMax
	}

	// Token: 0x020001FE RID: 510
	private enum ePlayType
	{
		// Token: 0x04001FA2 RID: 8098
		Normal,
		// Token: 0x04001FA3 RID: 8099
		Free,
		// Token: 0x04001FA4 RID: 8100
		Special
	}

	// Token: 0x020001FF RID: 511
	private enum ParticlePos
	{
		// Token: 0x04001FA6 RID: 8102
		NpcPos1,
		// Token: 0x04001FA7 RID: 8103
		NpcPos2,
		// Token: 0x04001FA8 RID: 8104
		BoxPos1,
		// Token: 0x04001FA9 RID: 8105
		JackPot,
		// Token: 0x04001FAA RID: 8106
		NpcPos3,
		// Token: 0x04001FAB RID: 8107
		NpcPos4,
		// Token: 0x04001FAC RID: 8108
		NpcMax
	}

	// Token: 0x02000200 RID: 512
	private enum NpcAct
	{
		// Token: 0x04001FAE RID: 8110
		idle,
		// Token: 0x04001FAF RID: 8111
		idle02,
		// Token: 0x04001FB0 RID: 8112
		idle03,
		// Token: 0x04001FB1 RID: 8113
		idle04,
		// Token: 0x04001FB2 RID: 8114
		attack,
		// Token: 0x04001FB3 RID: 8115
		victory,
		// Token: 0x04001FB4 RID: 8116
		v_idle
	}

	// Token: 0x02000201 RID: 513
	private struct JackPotUI
	{
		// Token: 0x04001FB5 RID: 8117
		public UIText Name;

		// Token: 0x04001FB6 RID: 8118
		public UIText Num;

		// Token: 0x04001FB7 RID: 8119
		public UIText Time;

		// Token: 0x04001FB8 RID: 8120
		public GameObject obj;
	}
}
