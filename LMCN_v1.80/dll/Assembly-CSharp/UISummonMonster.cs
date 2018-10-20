using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002A9 RID: 681
public class UISummonMonster : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x06000DAD RID: 3501 RVA: 0x0015F82C File Offset: 0x0015DA2C
	void IUIHIBtnClickHandler.OnHIButtonClick(UIHIBtn sender)
	{
		if (sender.m_BtnID2 == 0)
		{
			return;
		}
		MallManager.Instance.OpenDetail(sender.HIID);
	}

	// Token: 0x06000DAE RID: 3502 RVA: 0x0015F84C File Offset: 0x0015DA4C
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
		this.MainObj = base.transform.GetChild(0).gameObject;
		this.InfoObj = base.transform.GetChild(1).gameObject;
		Transform child = base.transform.GetChild(0);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		UIButtonHint uibuttonHint = child.GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 14507;
		uibuttonHint.Parm2 = 66;
		this.SummonMonsterTimesText = child.GetChild(0).GetChild(1).GetComponent<UIText>();
		this.SummonMonsterTimesText.font = ttffont;
		this.TitleText = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.TitleText.font = ttffont;
		this.TitleText.text = DataManager.Instance.mStringTable.GetStringByID(14503u);
		this.MonsterNameText = child.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.MonsterNameText.font = ttffont;
		this.MonsterEffTran = child.GetChild(3);
		this.MonsterObj = child.GetChild(4).gameObject;
		this.MonsterTrans = child.GetChild(4).GetChild(0).GetComponent<RectTransform>();
		this.OriMonsterPos = this.MonsterTrans.anchoredPosition3D;
		this.MonsterPositionText.Init(child.GetChild(4).GetChild(1).GetChild(1).GetComponent<RectTransform>(), child.GetChild(4).GetChild(1).GetChild(0), 241f, ttffont);
		this.MonsterPositionText.Button.m_Handler = this;
		this.MonsterPositionText.Button.m_BtnID1 = 1;
		UIButton component = child.GetChild(4).GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 2;
		uibuttonHint = child.GetChild(4).GetChild(3).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 14508;
		this.LeftTimeTitleText = child.GetChild(4).GetChild(3).GetChild(0).GetComponent<UIText>();
		this.LeftTimeTitleText.font = ttffont;
		this.LeftTimeTitleText.text = DataManager.Instance.mStringTable.GetStringByID(8110u);
		this.LeftTimeText = child.GetChild(4).GetChild(3).GetChild(1).GetComponent<UIText>();
		this.LeftTimeText.font = ttffont;
		this.LeftTimeObj = this.LeftTimeText.gameObject;
		this.MonstIconTrans = child.GetChild(5);
		GUIManager.Instance.InitianHeroItemImg(this.MonstIconTrans, eHeroOrItem.Hero, 0, 1, 0, 0, false, false, false, false);
		component = child.GetChild(6).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 3;
		if (GUIManager.Instance.IsArabic)
		{
			component.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		this.SummonOrMove = child.GetChild(7).GetComponent<UIButton>();
		this.SummonOrMove.m_Handler = this;
		this.CostIntoObj = child.GetChild(7).GetChild(0).gameObject;
		this.SummonCostText = child.GetChild(7).GetChild(0).GetChild(1).GetComponent<UIText>();
		this.SummonCostText.font = ttffont;
		this.CaptionRect = child.GetChild(7).GetChild(1).GetComponent<RectTransform>();
		this.CaptionText = this.CaptionRect.GetComponent<UIText>();
		this.CaptionText.font = ttffont;
		UILoadImageHander itemInfo = GUIManager.Instance.m_ItemInfo;
		child.GetChild(8).GetComponent<CustomImage>().hander = itemInfo;
		child.GetChild(8).GetChild(0).GetComponent<CustomImage>().hander = itemInfo;
		child.GetChild(8).GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = itemInfo;
		this.NoticeObj = child.GetChild(8).gameObject;
		this.PriceTitleText.Init(child.GetChild(9).GetChild(4).GetChild(1).GetComponent<RectTransform>(), child.GetChild(9).GetChild(4).GetChild(0), 372.5f, ttffont);
		this.PriceTitleText.SetText(DataManager.Instance.mStringTable.GetStringByID(14505u));
		uibuttonHint = this.PriceTitleText.Button.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 14509;
		this.MonsterPriceTrans = child.GetChild(9).GetChild(3);
		GUIManager.Instance.InitianHeroItemImg(this.MonsterPriceTrans, eHeroOrItem.Item, 0, 0, 0, 0, false, false, true, false);
		this.MonsterPriceBtn = this.MonsterPriceTrans.GetComponent<UIHIBtn>();
		this.MonsterPriceBtn.m_Handler = this;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			child.GetChild(10).GetComponent<CustomImage>().enabled = false;
		}
		else
		{
			child.GetChild(10).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		}
		child.GetChild(10).GetChild(0).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		component = child.GetChild(10).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 5;
		this.ArrChatStr = StringManager.Instance.SpawnString(30);
		this.MonsterNameStr = StringManager.Instance.SpawnString(30);
		this.PositionStr = StringManager.Instance.SpawnString(30);
		this.SummonCostStr = StringManager.Instance.SpawnString(30);
		this.SummonMonsterTimesStr = StringManager.Instance.SpawnString(30);
		this.LeftTimeStr = StringManager.Instance.SpawnString(30);
		this.AnList = new AnimationUnit.AnimName[this.ANIndex.Length];
		this.MonsterAct = StringManager.Instance.SpawnString(30);
		this.MonsterAct.Append(AnimationUnit.ANIM_STRING[0]);
		this.IdleHash = this.MonsterAct.GetHashCode(false);
		int num = 0;
		this.MonsterEffect[num] = ParticleManager.Instance.Spawn(419, this.MonstIconTrans, new Vector3(0f, 0f, -800f), 1.6f, true, true, true);
		this.MonsterEffect[num].transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
		GUIManager.Instance.SetLayer(this.MonsterEffect[num], 5);
		this.UpdateStyle();
	}

	// Token: 0x06000DAF RID: 3503 RVA: 0x0015FEEC File Offset: 0x0015E0EC
	private void UpdateStyle()
	{
		ActivityManager instance = ActivityManager.Instance;
		this.SummonLeftTime = instance.AllianceSummon_SummonData.MonsterEndTime;
		if (this.SummonLeftTime < DataManager.Instance.ServerTime)
		{
			this.SummonLeftTime = 0L;
		}
		this.MonsterKingdomID = (int)instance.AllianceSummon_SummonData.MonsterPos.KingdomID;
		this.MonsterMapID = GameConstants.PointCodeToMapID(instance.AllianceSummon_SummonData.MonsterPos.CombatPoint.zoneID, instance.AllianceSummon_SummonData.MonsterPos.CombatPoint.pointID);
		if (this.DelayParm == UISummonMonster.eDelayParm.SummonWait || this.DelayParm == UISummonMonster.eDelayParm.MonsterScaleIn || this.DelayParm == UISummonMonster.eDelayParm.MonsterScaleInSound)
		{
			return;
		}
		ushort monsterID = instance.AllianceSummon_SummonData.MonsterID;
		this.NeedPoint = instance.AllianceSummon_SummonData.CostPoint;
		this.PriceID = instance.AllianceSummon_SummonData.GiftID;
		if (DataManager.Instance.RoleAlliance.Id == 0u)
		{
			this.bCloseUI = 1;
		}
		else if (this.SummonLeftTime == 0L)
		{
			if (monsterID != this.MonsterID || this.Style != UISummonMonster.BtnStyle.Summon)
			{
				this.DestroyAB();
				this.MonsterID = monsterID;
				this.SetStyle(UISummonMonster.BtnStyle.Summon);
			}
			else
			{
				int num = 0;
				if (!this.MonsterEffect[num].activeSelf)
				{
					this.MonsterEffect[num].SetActive(true);
				}
			}
		}
		else if (monsterID != this.MonsterID || this.Style != UISummonMonster.BtnStyle.Move)
		{
			this.DestroyAB();
			this.MonsterID = monsterID;
			this.SetStyle(UISummonMonster.BtnStyle.Move);
		}
		else
		{
			this.UpdateMonsterPosition();
			int num2 = 3;
			if (this.MonsterEffect[num2] != null && !this.MonsterEffect[num2].activeSelf)
			{
				this.MonsterEffect[num2].SetActive(true);
			}
		}
		this.UpdateSummonMonsterTimes();
	}

	// Token: 0x06000DB0 RID: 3504 RVA: 0x001600C0 File Offset: 0x0015E2C0
	private void SetStyle(UISummonMonster.BtnStyle Style)
	{
		this.Style = Style;
		if (Style == UISummonMonster.BtnStyle.Move)
		{
			this.CostIntoObj.SetActive(false);
			this.CaptionRect.anchoredPosition = Vector2.zero;
			this.CaptionRect.sizeDelta = new Vector2(197f, 90.1f);
			this.MonsterObj.SetActive(true);
			this.MonstIconTrans.gameObject.SetActive(false);
			if (this.MainObj.activeSelf)
			{
				this.UpdateMonster();
			}
			else
			{
				this.SetDelay(0f, UISummonMonster.eDelayParm.WaitChangeMove);
			}
			this.CaptionText.text = DataManager.Instance.mStringTable.GetStringByID(834u);
			this.SummonOrMove.m_BtnID1 = 1;
			this.UpdateSummonLeftTime();
		}
		else
		{
			this.CostIntoObj.SetActive(true);
			this.CaptionRect.anchoredPosition = new Vector2(0f, -26f);
			this.CaptionRect.sizeDelta = new Vector2(197f, 35f);
			this.MonsterObj.SetActive(false);
			this.MonstIconTrans.gameObject.SetActive(true);
			if (this.MainObj.activeSelf)
			{
				this.UpdateMonsterIcon();
			}
			else
			{
				this.SetDelay(0f, UISummonMonster.eDelayParm.WaitChangeSummon);
			}
			this.CaptionText.text = DataManager.Instance.mStringTable.GetStringByID(14504u);
			this.SummonOrMove.m_BtnID1 = 0;
			int num = 3;
			if (this.MonsterEffect[num] != null)
			{
				this.MonsterEffect[num].SetActive(false);
			}
			num = 1;
			if (this.MonsterEffect[num] != null)
			{
				this.MonsterEffect[num].SetActive(false);
			}
			num = 0;
			if (!this.MonsterEffect[num].activeSelf)
			{
				this.MonsterEffect[num].SetActive(true);
			}
		}
		this.UpdateSummonMonsterTimes();
		this.InitPrice();
	}

	// Token: 0x06000DB1 RID: 3505 RVA: 0x001602B0 File Offset: 0x0015E4B0
	public override void ReOnOpen()
	{
		base.transform.gameObject.SetActive(true);
		this.CheckMonsterSkin();
	}

	// Token: 0x06000DB2 RID: 3506 RVA: 0x001602CC File Offset: 0x0015E4CC
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		this.UpdateStyle();
	}

	// Token: 0x06000DB3 RID: 3507 RVA: 0x001602D4 File Offset: 0x0015E4D4
	private void CheckMonsterSkin()
	{
		if (this.Style == UISummonMonster.BtnStyle.Summon)
		{
			return;
		}
		if (this.MonsterGo != null && this.MonsterSkin == null)
		{
			this.MonsterSkin = this.MonsterGo.GetComponentInChildren<SkinnedMeshRenderer>();
			if (this.MonsterSkin != null)
			{
				this.MonsterSkin.useLightProbes = false;
			}
		}
		if (this.MonsterAN != null)
		{
			this.MonsterAN.enabled = false;
			this.MonsterAN.enabled = true;
		}
	}

	// Token: 0x06000DB4 RID: 3508 RVA: 0x00160368 File Offset: 0x0015E568
	public override void OnClose()
	{
		if (this.Info != null)
		{
			this.Info.OnClose();
		}
		StringManager.Instance.DeSpawnString(this.ArrChatStr);
		StringManager.Instance.DeSpawnString(this.MonsterNameStr);
		StringManager.Instance.DeSpawnString(this.PositionStr);
		StringManager.Instance.DeSpawnString(this.SummonCostStr);
		StringManager.Instance.DeSpawnString(this.SummonMonsterTimesStr);
		StringManager.Instance.DeSpawnString(this.LeftTimeStr);
		int num = 0;
		ParticleManager.Instance.DeSpawn(this.MonsterEffect[num]);
		this.MonsterEffect[num] = null;
		num = 3;
		ParticleManager.Instance.DeSpawn(this.MonsterEffect[num]);
		this.MonsterEffect[num] = null;
		num = 1;
		ParticleManager.Instance.DeSpawn(this.MonsterEffect[num]);
		this.MonsterEffect[num] = null;
		num = 2;
		if (this.MonsterEffect[num] != null && this.MonsterEffect[num].activeSelf)
		{
			this.MonsterEffect[num].transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			this.MonsterEffect[num].transform.localPosition = new Vector3(0f, 0f, -50f);
		}
		if (!this.MainObj.activeSelf)
		{
			this.MainObj.SetActive(true);
		}
		this.DestroyAB();
	}

	// Token: 0x06000DB5 RID: 3509 RVA: 0x001604DC File Offset: 0x0015E6DC
	private void DestroyAB()
	{
		if (this.MonsterGo != null)
		{
			if (!this.MainObj.activeSelf)
			{
				bool activeSelf = base.transform.gameObject.activeSelf;
				if (!activeSelf)
				{
					base.transform.gameObject.SetActive(!activeSelf);
				}
				this.MainObj.SetActive(true);
				ModelLoader.Instance.Unload(this.MonsterGo);
				this.MainObj.SetActive(false);
				if (!activeSelf)
				{
					base.transform.gameObject.SetActive(activeSelf);
				}
			}
			else
			{
				ModelLoader.Instance.Unload(this.MonsterGo);
			}
		}
		if (this.AssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey, true);
		}
		this.MonsterGo = null;
		this.AssetKey = 0;
	}

	// Token: 0x06000DB6 RID: 3510 RVA: 0x001605B0 File Offset: 0x0015E7B0
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.bCloseUI == 1)
		{
			this.bCloseUI = 0;
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.CloseMenu_Alliance(this.m_eWindow);
			}
			return;
		}
		if (!base.isActiveAndEnabled)
		{
			return;
		}
		if (!this.MainObj.activeSelf)
		{
			return;
		}
		this.UpdateDelayTime();
		if (bOnSecond)
		{
			this.UpdateSummonLeftTime();
		}
		if (this.Style == UISummonMonster.BtnStyle.Move)
		{
			if (this.MonsterGo == null && this.AR != null && this.AR.isDone)
			{
				Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.HeroID);
				this.MonsterGo = ModelLoader.Instance.Load(recordByKey.Modle, this.AB, (ushort)recordByKey.TextureNo);
				if (this.MonsterGo == null)
				{
					return;
				}
				this.MonsterGo.transform.SetParent(this.MonsterTrans, false);
				if (recordByKey.Camera_Horizontal == 0)
				{
					this.MonsterGo.transform.localRotation = new Quaternion(0f, -180f, 0f, 0f);
				}
				else
				{
					Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
					localRotation.eulerAngles = new Vector3(0f, (float)recordByKey.Camera_Horizontal, 0f);
					this.MonsterGo.transform.localRotation = localRotation;
				}
				this.MonsterGo.transform.localScale = new Vector3((float)recordByKey.CameraScaleRate, (float)recordByKey.CameraScaleRate, (float)recordByKey.CameraScaleRate);
				GUIManager.Instance.SetLayer(this.MonsterGo, 5);
				if (this.MonsterGo != null)
				{
					this.MonsterAN = this.MonsterGo.GetComponent<Animation>();
					this.MonsterAN.wrapMode = WrapMode.Loop;
					this.MonsterAN.cullingType = AnimationCullingType.AlwaysAnimate;
					for (int i = 0; i < this.ANIndex.Length; i++)
					{
						byte b = (byte)this.ANIndex[i];
						if (this.MonsterAN.GetClip(AnimationUnit.ANIM_STRING[(int)b]) != null)
						{
							this.MonsterAN[AnimationUnit.ANIM_STRING[(int)b]].layer = 1;
							this.MonsterAN[AnimationUnit.ANIM_STRING[(int)b]].wrapMode = WrapMode.Once;
							this.AnList[i] = this.ANIndex[i];
						}
					}
					this.MonsterAN.clip = this.MonsterAN.GetClip(this.MonsterAct.ToString());
					this.MonsterAN.Play(this.MonsterAct.ToString());
					this.MonsterSkin = this.MonsterGo.GetComponentInChildren<SkinnedMeshRenderer>();
					if (this.MonsterSkin != null)
					{
						this.MonsterSkin.useLightProbes = false;
					}
				}
				if (this.MonsterEffect[3] == null)
				{
					this.MonsterEffect[3] = ParticleManager.Instance.Spawn(422, this.MonsterTrans, new Vector3(0f, 240f, -85.9f), 1f, true, true, true);
					this.MonsterEffect[3].transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
					GUIManager.Instance.SetLayer(this.MonsterEffect[3], 5);
				}
				else
				{
					this.MonsterEffect[3].SetActive(true);
				}
			}
			if (this.MonsterAN != null && this.MonsterGo != null)
			{
				if ((!this.MonsterAN.IsPlaying(this.MonsterAct.ToString()) || this.MonsterAct.GetHashCode(false) == this.IdleHash) && this.ActionTimeRandom < 0.0001f)
				{
					this.ActionTimeRandom = (float)UnityEngine.Random.Range(3, 7);
					this.ActionTime = 0f;
				}
				if (this.ActionTimeRandom > 0.0001f)
				{
					this.ActionTime += Time.smoothDeltaTime;
					if (this.ActionTime >= this.ActionTimeRandom)
					{
						this.MonsterActionChang();
					}
				}
			}
		}
	}

	// Token: 0x06000DB7 RID: 3511 RVA: 0x001609FC File Offset: 0x0015EBFC
	private void UpdateDelayTime()
	{
		if (this.DelayTime >= 0f)
		{
			this.DelayTime -= Time.deltaTime;
			if (this.DelayTime < 0f)
			{
				switch (this.DelayParm)
				{
				case UISummonMonster.eDelayParm.MonsterScaleIn:
					this.DestroyAB();
					this.SetStyle(UISummonMonster.BtnStyle.Move);
					if (this.AssetKey == 0)
					{
						this.DelayParm = UISummonMonster.eDelayParm.SummonSuccessWait;
					}
					else
					{
						AudioManager.Instance.PlayUISFX(UIKind.SummonSuccess);
						int num = 1;
						if (this.MonsterEffect[num] != null)
						{
							this.MonsterEffect[num].SetActive(false);
						}
						num = 2;
						this.MonsterEffect[num] = ParticleManager.Instance.Spawn(421, this.MonsterEffTran, new Vector3(0f, 0f, -850f), 1.6f, true, true, true);
						GUIManager.Instance.SetLayer(this.MonsterEffect[num], 5);
						this.MonsterTrans.localScale = Vector3.zero;
					}
					break;
				case UISummonMonster.eDelayParm.WaitChangeSummon:
					this.DestroyAB();
					this.SetStyle(UISummonMonster.BtnStyle.Summon);
					break;
				case UISummonMonster.eDelayParm.WaitChangeMove:
					this.DestroyAB();
					this.SetStyle(UISummonMonster.BtnStyle.Move);
					break;
				case UISummonMonster.eDelayParm.SendSummon:
				{
					int num2 = 1;
					if (this.MonsterEffect[num2] == null)
					{
						this.MonsterEffect[num2] = ParticleManager.Instance.Spawn(420, this.MonstIconTrans, Vector3.zero, 1.6f, true, true, true);
						GUIManager.Instance.SetLayer(this.MonsterEffect[num2], 5);
					}
					else
					{
						this.MonsterEffect[num2].SetActive(true);
					}
					AudioManager.Instance.PlayUISFX(UIKind.Summoning);
					this.SetDelay(0.7f, UISummonMonster.eDelayParm.SummonWait);
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AS_SUMMON;
					messagePacket.AddSeqId();
					messagePacket.Send(false);
					break;
				}
				case UISummonMonster.eDelayParm.MonsterScaleInSound:
					this.SetDelay(0.2f, UISummonMonster.eDelayParm.MonsterScaleIn);
					break;
				}
			}
		}
		if (this.DelayParm == UISummonMonster.eDelayParm.MonsterScaleIn && this.DelayTime < 0f)
		{
			this.DelayTime -= Time.deltaTime;
			float num3 = -(this.DelayTime / this.ShowScaleTime);
			if (num3 < 1f)
			{
				this.MonsterTrans.localScale = Vector3.one * num3;
				this.MonsterTrans.anchoredPosition3D = new Vector3(this.OriMonsterPos.x, this.OriMonsterPos.y * num3, this.OriMonsterPos.z);
			}
			else
			{
				this.DelayParm = UISummonMonster.eDelayParm.None;
				this.MonsterTrans.localScale = Vector3.one;
				this.MonsterTrans.anchoredPosition3D = this.OriMonsterPos;
				this.UpdateStyle();
				if (this.SummonLeftTime > 0L)
				{
					this.UpdateSummonLeftTime();
					if (this.DelayParm2 == UISummonMonster.eDelayParm.WaitSummonTime && this.SummonLeftTime > 0L)
					{
						this.DelayParm2 = UISummonMonster.eDelayParm.None;
						this.LeftTimeObj.SetActive(true);
					}
				}
			}
		}
	}

	// Token: 0x06000DB8 RID: 3512 RVA: 0x00160D0C File Offset: 0x0015EF0C
	public void MonsterActionChang()
	{
		if (this.MonsterGo == null)
		{
			return;
		}
		int num = UnityEngine.Random.Range(0, this.AnList.Length);
		this.MonsterAct.ClearString();
		this.MonsterAct.Append(AnimationUnit.ANIM_STRING[(int)this.AnList[num]]);
		AnimationClip animationClip = this.MonsterAN.GetClip(this.MonsterAct.ToString());
		if (this.AnList[num] == AnimationUnit.AnimName.SKILL1)
		{
			this.MonsterAct.Append("_ch");
			AnimationClip clip = this.MonsterAN.GetClip(this.MonsterAct.ToString());
			if (clip != null)
			{
				animationClip = null;
			}
		}
		if (animationClip != null)
		{
			this.MonsterAN.CrossFade(animationClip.name);
		}
		this.ActionTimeRandom = 0f;
		this.ActionTime = 0f;
	}

	// Token: 0x06000DB9 RID: 3513 RVA: 0x00160DEC File Offset: 0x0015EFEC
	private void UpdateMonster()
	{
		if (this.MonsterID == 0)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.MonsterID);
		CString cstring = StringManager.Instance.StaticString1024();
		this.MonsterTrans.localScale = Vector3.one;
		this.MonsterTrans.anchoredPosition3D = this.OriMonsterPos;
		this.HeroID = recordByKey.ModelID;
		this.Modle = instance.HeroTable.GetRecordByKey(this.HeroID).Modle;
		cstring.IntToFormat((long)this.Modle, 5, false);
		cstring.AppendFormat("Role/hero_{0}");
		this.MonsterGo = null;
		this.AR = null;
		if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, this.Modle, true))
		{
			this.AB = AssetManager.GetAssetBundle(cstring, out this.AssetKey);
			if (this.AB != null)
			{
				this.AR = this.AB.LoadAsync("m", typeof(GameObject));
			}
		}
		this.MonsterNameStr.ClearString();
		this.MonsterNameStr.Append(instance.mStringTable.GetStringByID((uint)recordByKey.NameID));
		this.MonsterNameText.text = this.MonsterNameStr.ToString();
		this.MonsterNameText.SetAllDirty();
		this.MonsterNameText.cachedTextGenerator.Invalidate();
		this.UpdateMonsterPosition();
		this.MonsterAct.ClearString();
		this.MonsterAct.Append(AnimationUnit.ANIM_STRING[0]);
	}

	// Token: 0x06000DBA RID: 3514 RVA: 0x00160F78 File Offset: 0x0015F178
	private void UpdateMonsterPosition()
	{
		DataManager instance = DataManager.Instance;
		Vector2 tileMapPosbySpriteID = GameConstants.getTileMapPosbySpriteID(this.MonsterMapID);
		this.PositionStr.ClearString();
		this.PositionStr.StringToFormat(instance.mStringTable.GetStringByID(4504u));
		this.PositionStr.IntToFormat((long)this.MonsterKingdomID, 1, false);
		this.PositionStr.StringToFormat(instance.mStringTable.GetStringByID(4505u));
		this.PositionStr.IntToFormat((long)((int)tileMapPosbySpriteID.x), 1, false);
		this.PositionStr.StringToFormat(instance.mStringTable.GetStringByID(4506u));
		this.PositionStr.IntToFormat((long)((int)tileMapPosbySpriteID.y), 1, false);
		if (GUIManager.Instance.IsArabic)
		{
			this.PositionStr.AppendFormat("{5}{4} {3}{2} {1}{0}");
		}
		else
		{
			this.PositionStr.AppendFormat("{0}{1} {2}{3} {4}{5}");
		}
		this.MonsterPositionText.SetText(this.PositionStr.ToString());
		this.MonsterPositionText.Button.m_BtnID3 = this.MonsterKingdomID;
		this.MonsterPositionText.Button.m_BtnID2 = this.MonsterMapID;
		this.SummonOrMove.m_BtnID3 = this.MonsterPositionText.Button.m_BtnID3;
		this.SummonOrMove.m_BtnID2 = this.MonsterPositionText.Button.m_BtnID2;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(instance.RoleAlliance.Tag);
		cstring.StringToFormat(this.MonsterNameStr);
		cstring.AppendFormat("[{0}]{1}");
		this.ArrChatStr.ClearString();
		this.ArrChatStr.StringToFormat(cstring);
		this.ArrChatStr.StringToFormat(instance.mStringTable.GetStringByID(4504u));
		this.ArrChatStr.IntToFormat((long)this.MonsterKingdomID, 1, false);
		this.ArrChatStr.StringToFormat(instance.mStringTable.GetStringByID(4505u));
		this.ArrChatStr.IntToFormat((long)((int)tileMapPosbySpriteID.x), 1, false);
		this.ArrChatStr.StringToFormat(instance.mStringTable.GetStringByID(4506u));
		this.ArrChatStr.IntToFormat((long)((int)tileMapPosbySpriteID.y), 1, false);
		if (GUIManager.Instance.IsArabic)
		{
			this.ArrChatStr.AppendFormat("{0} {2}{1} {4}{3} {6}{5}");
		}
		else
		{
			this.ArrChatStr.AppendFormat("{0} {1}{2} {3}{4} {5}{6}");
		}
	}

	// Token: 0x06000DBB RID: 3515 RVA: 0x00161200 File Offset: 0x0015F400
	private void UpdateMonsterIcon()
	{
		if (this.MonsterID == 0)
		{
			return;
		}
		MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.MonsterID);
		this.HeroID = recordByKey.ModelID;
		CString cstring = StringManager.Instance.StaticString1024();
		this.HeroHead = DataManager.Instance.HeroTable.GetRecordByKey(this.HeroID).Graph;
		cstring.ClearString();
		cstring.IntToFormat((long)this.HeroHead, 1, false);
		cstring.AppendFormat("UI/MapNPCHead_{0}");
		this.MonstIconTrans.GetChild(0).gameObject.SetActive(false);
		if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.UI, AssetType.NPCHead, this.HeroHead, false))
		{
			this.AB = AssetManager.GetAssetBundle(cstring, out this.AssetKey);
			if (this.AB != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(this.AB.mainAsset) as GameObject;
				gameObject.SetActive(true);
				Transform transform = gameObject.transform;
				transform.SetParent(this.MonstIconTrans);
				transform.SetAsFirstSibling();
				transform.localPosition = Vector3.zero;
				transform.localScale = Vector3.one;
				transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			}
		}
		this.MonsterNameStr.ClearString();
		this.MonsterNameStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.NameID));
		this.MonsterNameText.text = this.MonsterNameStr.ToString();
		this.MonsterNameText.SetAllDirty();
		this.MonsterNameText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000DBC RID: 3516 RVA: 0x001613A4 File Offset: 0x0015F5A4
	public void UpdateSummonMonsterTimes()
	{
		ushort summonPoint = (ushort)ActivityManager.Instance.AllianceSummon_SummonData.SummonPoint;
		if (this.Style == UISummonMonster.BtnStyle.Summon)
		{
			if (summonPoint >= (ushort)this.NeedPoint)
			{
				this.SummonCostText.color = Color.white;
				this.NoticeObj.SetActive(true);
			}
			else
			{
				this.SummonCostText.color = Color.red;
				this.NoticeObj.SetActive(false);
			}
			this.SummonCostStr.ClearString();
			this.SummonCostStr.IntToFormat((long)this.NeedPoint, 1, false);
			this.SummonCostStr.AppendFormat("{0}");
			this.SummonCostText.text = this.SummonCostStr.ToString();
			this.SummonCostText.SetAllDirty();
			this.SummonCostText.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.NoticeObj.SetActive(true);
		}
		this.SummonMonsterTimesStr.ClearString();
		this.SummonMonsterTimesStr.IntToFormat((long)summonPoint, 1, false);
		this.SummonMonsterTimesStr.AppendFormat("{0}");
		this.SummonMonsterTimesText.text = this.SummonMonsterTimesStr.ToString();
		this.SummonMonsterTimesText.SetAllDirty();
		this.SummonMonsterTimesText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000DBD RID: 3517 RVA: 0x001614E4 File Offset: 0x0015F6E4
	public void InitPrice()
	{
		GUIManager.Instance.ChangeHeroItemImg(this.MonsterPriceTrans, eHeroOrItem.Item, this.PriceID, 0, 0, 0);
		this.MonsterPriceBtn.m_BtnID2 = (int)this.PriceID;
	}

	// Token: 0x06000DBE RID: 3518 RVA: 0x0016151C File Offset: 0x0015F71C
	public void UpdateSummonLeftTime()
	{
		if (this.Style == UISummonMonster.BtnStyle.Move)
		{
			long serverTime = DataManager.Instance.ServerTime;
			if (this.SummonLeftTime >= serverTime)
			{
				this.LeftTimeStr.ClearString();
				this.LeftTimeStr.Append(DataManager.MissionDataManager.FormatMissionTime((uint)(this.SummonLeftTime - serverTime)));
				this.LeftTimeText.text = this.LeftTimeStr.ToString();
				this.LeftTimeText.SetAllDirty();
				this.LeftTimeText.cachedTextGenerator.Invalidate();
			}
			else
			{
				this.LeftTimeStr.ClearString();
				this.LeftTimeStr.Append("0:00");
				this.LeftTimeText.text = this.LeftTimeStr.ToString();
				this.LeftTimeText.SetAllDirty();
				this.LeftTimeText.cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x06000DBF RID: 3519 RVA: 0x001615F8 File Offset: 0x0015F7F8
	private bool CheckAlliance()
	{
		if (DataManager.Instance.RoleAlliance.Id == 0u)
		{
			this.bCloseUI = 1;
			return false;
		}
		return true;
	}

	// Token: 0x06000DC0 RID: 3520 RVA: 0x00161618 File Offset: 0x0015F818
	public override void UpdateNetwork(byte[] meg)
	{
		if (this.Info != null)
		{
			this.Info.UpdateNetwork(meg);
		}
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
			if (this.CheckAlliance())
			{
				if (this.Style == UISummonMonster.BtnStyle.Summon && this.MonsterEffect[1] != null)
				{
					this.MonsterEffect[1].SetActive(false);
				}
			}
			break;
		case NetworkNews.Fallout:
		{
			int num = 0;
			this.MonsterEffect[num].SetActive(false);
			num = 3;
			if (this.MonsterEffect[num] != null)
			{
				this.MonsterEffect[num].SetActive(false);
			}
			break;
		}
		default:
			if (networkNews != NetworkNews.Refresh_Alliance)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.SummonMonsterTimesText.enabled = false;
					this.TitleText.enabled = false;
					this.MonsterNameText.enabled = false;
					this.SummonCostText.enabled = false;
					this.CaptionText.enabled = false;
					this.LeftTimeTitleText.enabled = false;
					this.LeftTimeText.enabled = false;
					this.SummonMonsterTimesText.enabled = true;
					this.TitleText.enabled = true;
					this.MonsterNameText.enabled = true;
					this.SummonCostText.enabled = true;
					this.CaptionText.enabled = true;
					this.LeftTimeTitleText.enabled = true;
					this.LeftTimeText.enabled = true;
					this.MonsterPositionText.TextRefresh();
					this.PriceTitleText.TextRefresh();
				}
			}
			else
			{
				if (meg[1] >= 36 && meg[1] <= 39)
				{
					this.UpdateStyle();
				}
				if (meg[1] == 39)
				{
					this.UpdateMonsterPosition();
					this.UpdateSummonLeftTime();
					if (this.DelayParm2 == UISummonMonster.eDelayParm.WaitSummonTime && this.SummonLeftTime > 0L)
					{
						this.DelayParm2 = UISummonMonster.eDelayParm.None;
						this.LeftTimeObj.SetActive(true);
					}
				}
			}
			break;
		case NetworkNews.Refresh_Asset:
			if (this.Style == UISummonMonster.BtnStyle.Move && meg[1] == 1 && meg[2] == 2 && GameConstants.ConvertBytesToUShort(meg, 3) == this.Modle)
			{
				this.MonsterAct.ClearString();
				this.MonsterAct.Append(AnimationUnit.ANIM_STRING[0]);
				this.DestroyAB();
				this.UpdateMonster();
				if (this.DelayParm == UISummonMonster.eDelayParm.SummonSuccessWait)
				{
					this.SetDelay(0f, UISummonMonster.eDelayParm.MonsterScaleIn);
				}
			}
			else if (this.Style == UISummonMonster.BtnStyle.Summon && meg[1] == 0 && meg[2] == 1 && GameConstants.ConvertBytesToUShort(meg, 3) == this.HeroHead)
			{
				this.DestroyAB();
				this.UpdateMonsterIcon();
			}
			break;
		}
	}

	// Token: 0x06000DC1 RID: 3521 RVA: 0x001618C0 File Offset: 0x0015FAC0
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 0:
			if (this.Style == UISummonMonster.BtnStyle.Summon)
			{
				if (this.MainObj.activeSelf)
				{
					if (this.DelayTime > 0f && this.DelayParm == UISummonMonster.eDelayParm.SummonWait)
					{
						this.SetDelay(this.DelayTime, UISummonMonster.eDelayParm.MonsterScaleInSound);
					}
					else
					{
						this.SetDelay(0f, UISummonMonster.eDelayParm.MonsterScaleInSound);
					}
				}
				else
				{
					this.SetDelay(0f, UISummonMonster.eDelayParm.WaitChangeMove);
				}
				if (this.SummonLeftTime == 0L)
				{
					this.LeftTimeObj.SetActive(false);
					this.DelayParm2 = UISummonMonster.eDelayParm.WaitSummonTime;
				}
			}
			break;
		case 1:
			this.UpdateStyle();
			break;
		case 2:
		{
			this.UpdateStyle();
			int num = 0;
			this.MonsterEffect[num].SetActive(false);
			num = 3;
			if (this.MonsterEffect[num] != null)
			{
				this.MonsterEffect[num].SetActive(false);
			}
			break;
		}
		case 3:
			this.CheckAlliance();
			break;
		default:
			if (arg1 < 0)
			{
				int num2 = 1;
				if (this.MonsterEffect[num2] != null)
				{
					this.MonsterEffect[num2].SetActive(false);
				}
			}
			break;
		}
	}

	// Token: 0x06000DC2 RID: 3522 RVA: 0x001619F8 File Offset: 0x0015FBF8
	private void SetDelay(float delayTime, UISummonMonster.eDelayParm Parm)
	{
		this.DelayTime = delayTime;
		this.DelayParm = Parm;
	}

	// Token: 0x06000DC3 RID: 3523 RVA: 0x00161A08 File Offset: 0x0015FC08
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.DelayParm == UISummonMonster.eDelayParm.SummonWait || this.DelayParm == UISummonMonster.eDelayParm.MonsterScaleIn || this.DelayParm == UISummonMonster.eDelayParm.MonsterScaleInSound)
			{
				return;
			}
			if (DataManager.Instance.RoleAlliance.Rank < AllianceRank.RANK4)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4753u), 255, true);
			}
			else if (ActivityManager.Instance.AllianceSummon_SummonData.SummonPoint < this.NeedPoint)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14511u), 255, true);
			}
			else
			{
				GUIManager.Instance.ShowUILock(EUILock.Battle);
				AudioManager.Instance.PlayUISFX(UIKind.Summoning);
				this.SetDelay(0.2f, UISummonMonster.eDelayParm.SendSummon);
			}
			break;
		case 1:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.GoToMapID((ushort)sender.m_BtnID3, sender.m_BtnID2, 0, 1, true);
			break;
		}
		case 2:
		{
			Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			base.transform.gameObject.SetActive(false);
			door2.OpenMenu(EGUIWindow.UI_Chat, (int)(GUIManager.Instance.ChannelIndex + 1), 0, false);
			UIChat uichat = (UIChat)GUIManager.Instance.FindMenu(EGUIWindow.UI_Chat);
			uichat.SetInputText(this.ArrChatStr.ToString());
			break;
		}
		case 3:
			if (this.Info == null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(this.m_AssetBundle.Load("UIMonsterInfo")) as GameObject;
				this.Info = new _UISummonMonsterInfo(this, gameObject);
				this.Info.OnOpen(0, 0);
				gameObject.transform.SetParent(this.InfoObj.transform, false);
			}
			this.SetInfoVisible(true);
			break;
		case 4:
			this.SetInfoVisible(false);
			break;
		case 5:
		{
			Door door3 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door3 != null)
			{
				door3.CloseMenu(false);
			}
			break;
		}
		}
	}

	// Token: 0x06000DC4 RID: 3524 RVA: 0x00161C3C File Offset: 0x0015FE3C
	private void SetInfoVisible(bool visible)
	{
		this.InfoObj.SetActive(visible);
		this.MainObj.SetActive(!visible);
		if (this.MainObj.activeSelf)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
			this.CheckMonsterSkin();
		}
		else
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 3);
		}
	}

	// Token: 0x06000DC5 RID: 3525 RVA: 0x00161C9C File Offset: 0x0015FE9C
	public void OnButtonDown(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, (int)sender.Parm1, 0, new Vector2((float)sender.Parm2, 0f), UIButtonHint.ePosition.Original);
	}

	// Token: 0x06000DC6 RID: 3526 RVA: 0x00161CDC File Offset: 0x0015FEDC
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x04002C92 RID: 11410
	private Transform MonstIconTrans;

	// Token: 0x04002C93 RID: 11411
	private Transform MonsterPriceTrans;

	// Token: 0x04002C94 RID: 11412
	private Transform MonsterEffTran;

	// Token: 0x04002C95 RID: 11413
	private UIHIBtn MonsterPriceBtn;

	// Token: 0x04002C96 RID: 11414
	private GameObject CostIntoObj;

	// Token: 0x04002C97 RID: 11415
	private GameObject NoticeObj;

	// Token: 0x04002C98 RID: 11416
	private GameObject MonsterObj;

	// Token: 0x04002C99 RID: 11417
	private GameObject MainObj;

	// Token: 0x04002C9A RID: 11418
	private GameObject InfoObj;

	// Token: 0x04002C9B RID: 11419
	private GameObject LeftTimeObj;

	// Token: 0x04002C9C RID: 11420
	private GameObject[] MonsterEffect = new GameObject[4];

	// Token: 0x04002C9D RID: 11421
	private RectTransform CaptionRect;

	// Token: 0x04002C9E RID: 11422
	private RectTransform MonsterTrans;

	// Token: 0x04002C9F RID: 11423
	private UIText SummonMonsterTimesText;

	// Token: 0x04002CA0 RID: 11424
	private UIText TitleText;

	// Token: 0x04002CA1 RID: 11425
	private UIText MonsterNameText;

	// Token: 0x04002CA2 RID: 11426
	private UIText SummonCostText;

	// Token: 0x04002CA3 RID: 11427
	private UIText CaptionText;

	// Token: 0x04002CA4 RID: 11428
	private UIText LeftTimeTitleText;

	// Token: 0x04002CA5 RID: 11429
	private UIText LeftTimeText;

	// Token: 0x04002CA6 RID: 11430
	private UISummonMonster._TextUnderLine MonsterPositionText;

	// Token: 0x04002CA7 RID: 11431
	private UISummonMonster._TextUnderLine PriceTitleText;

	// Token: 0x04002CA8 RID: 11432
	private UIButton SummonOrMove;

	// Token: 0x04002CA9 RID: 11433
	private CString MonsterNameStr;

	// Token: 0x04002CAA RID: 11434
	private CString ArrChatStr;

	// Token: 0x04002CAB RID: 11435
	private CString PositionStr;

	// Token: 0x04002CAC RID: 11436
	private CString SummonCostStr;

	// Token: 0x04002CAD RID: 11437
	private CString SummonMonsterTimesStr;

	// Token: 0x04002CAE RID: 11438
	private CString LeftTimeStr;

	// Token: 0x04002CAF RID: 11439
	private AssetBundle AB;

	// Token: 0x04002CB0 RID: 11440
	private AssetBundleRequest AR;

	// Token: 0x04002CB1 RID: 11441
	private GameObject MonsterGo;

	// Token: 0x04002CB2 RID: 11442
	private SkinnedMeshRenderer MonsterSkin;

	// Token: 0x04002CB3 RID: 11443
	private ushort HeroID;

	// Token: 0x04002CB4 RID: 11444
	private ushort Modle;

	// Token: 0x04002CB5 RID: 11445
	private ushort HeroHead;

	// Token: 0x04002CB6 RID: 11446
	private ushort MonsterID;

	// Token: 0x04002CB7 RID: 11447
	private int AssetKey;

	// Token: 0x04002CB8 RID: 11448
	private int MonsterMapID;

	// Token: 0x04002CB9 RID: 11449
	private int MonsterKingdomID;

	// Token: 0x04002CBA RID: 11450
	private Animation MonsterAN;

	// Token: 0x04002CBB RID: 11451
	private CString MonsterAct;

	// Token: 0x04002CBC RID: 11452
	private int IdleHash;

	// Token: 0x04002CBD RID: 11453
	private float ActionTime;

	// Token: 0x04002CBE RID: 11454
	private float ActionTimeRandom;

	// Token: 0x04002CBF RID: 11455
	private AnimationUnit.AnimName[] ANIndex = new AnimationUnit.AnimName[]
	{
		AnimationUnit.AnimName.ATTACK,
		AnimationUnit.AnimName.SKILL1,
		AnimationUnit.AnimName.SKILL2,
		AnimationUnit.AnimName.SKILL3,
		AnimationUnit.AnimName.VICTORY
	};

	// Token: 0x04002CC0 RID: 11456
	private AnimationUnit.AnimName[] AnList;

	// Token: 0x04002CC1 RID: 11457
	private Vector3 OriMonsterPos;

	// Token: 0x04002CC2 RID: 11458
	private float DelayTime = -1f;

	// Token: 0x04002CC3 RID: 11459
	private float ShowScaleTime = 0.4f;

	// Token: 0x04002CC4 RID: 11460
	private UISummonMonster.eDelayParm DelayParm;

	// Token: 0x04002CC5 RID: 11461
	private UISummonMonster.eDelayParm DelayParm2;

	// Token: 0x04002CC6 RID: 11462
	private UISummonMonster.BtnStyle Style;

	// Token: 0x04002CC7 RID: 11463
	private long SummonLeftTime;

	// Token: 0x04002CC8 RID: 11464
	private byte NeedPoint;

	// Token: 0x04002CC9 RID: 11465
	private ushort PriceID;

	// Token: 0x04002CCA RID: 11466
	private _UISummonMonsterInfo Info;

	// Token: 0x04002CCB RID: 11467
	private byte bCloseUI;

	// Token: 0x020002AA RID: 682
	private enum UIControl
	{
		// Token: 0x04002CCD RID: 11469
		TotalTimes,
		// Token: 0x04002CCE RID: 11470
		Title,
		// Token: 0x04002CCF RID: 11471
		Name,
		// Token: 0x04002CD0 RID: 11472
		Effect,
		// Token: 0x04002CD1 RID: 11473
		Monster,
		// Token: 0x04002CD2 RID: 11474
		MonsterIcon,
		// Token: 0x04002CD3 RID: 11475
		Info,
		// Token: 0x04002CD4 RID: 11476
		SummonMove,
		// Token: 0x04002CD5 RID: 11477
		Notice,
		// Token: 0x04002CD6 RID: 11478
		Price,
		// Token: 0x04002CD7 RID: 11479
		Close
	}

	// Token: 0x020002AB RID: 683
	public enum ClickType
	{
		// Token: 0x04002CD9 RID: 11481
		Summon,
		// Token: 0x04002CDA RID: 11482
		Move,
		// Token: 0x04002CDB RID: 11483
		AddChat,
		// Token: 0x04002CDC RID: 11484
		Info,
		// Token: 0x04002CDD RID: 11485
		CloseInfo,
		// Token: 0x04002CDE RID: 11486
		Close
	}

	// Token: 0x020002AC RID: 684
	private enum BtnStyle
	{
		// Token: 0x04002CE0 RID: 11488
		Summon,
		// Token: 0x04002CE1 RID: 11489
		Move
	}

	// Token: 0x020002AD RID: 685
	private enum Effectenum
	{
		// Token: 0x04002CE3 RID: 11491
		Icon,
		// Token: 0x04002CE4 RID: 11492
		Summoning,
		// Token: 0x04002CE5 RID: 11493
		SummonSuccess,
		// Token: 0x04002CE6 RID: 11494
		Monster
	}

	// Token: 0x020002AE RID: 686
	private enum eDelayParm
	{
		// Token: 0x04002CE8 RID: 11496
		None,
		// Token: 0x04002CE9 RID: 11497
		SummonWait,
		// Token: 0x04002CEA RID: 11498
		MonsterScaleIn,
		// Token: 0x04002CEB RID: 11499
		SummonSuccessWait,
		// Token: 0x04002CEC RID: 11500
		WaitChangeSummon,
		// Token: 0x04002CED RID: 11501
		WaitChangeMove,
		// Token: 0x04002CEE RID: 11502
		WaitSummonTime,
		// Token: 0x04002CEF RID: 11503
		SendSummon,
		// Token: 0x04002CF0 RID: 11504
		MonsterScaleInSound
	}

	// Token: 0x020002AF RID: 687
	public struct _TextUnderLine
	{
		// Token: 0x06000DC7 RID: 3527 RVA: 0x00161CF0 File Offset: 0x0015FEF0
		public void Init(RectTransform HideBtnRect, RectTransform lineTrans, UIText text, float TextWidth, Font font)
		{
			this.TextWidth = TextWidth;
			this.LineRect = lineTrans;
			this.mText = text;
			this.mText.font = font;
			this.ButtonRect = HideBtnRect;
			this.Button = this.ButtonRect.GetComponent<UIButton>();
			this.Button.SoundIndex = byte.MaxValue;
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x00161D48 File Offset: 0x0015FF48
		public void Init(RectTransform TextRect, Transform buttonTrans, float TextWidth, Font font)
		{
			this.TextWidth = TextWidth;
			this.LineRect = TextRect.GetChild(0).GetComponent<RectTransform>();
			this.mText = TextRect.GetComponent<UIText>();
			this.mText.font = font;
			this.ButtonRect = buttonTrans.GetComponent<RectTransform>();
			this.Button = this.ButtonRect.GetComponent<UIButton>();
			this.Button.SoundIndex = byte.MaxValue;
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x00161DB4 File Offset: 0x0015FFB4
		public void SetText(string str)
		{
			this.mText.text = str;
			this.mText.SetAllDirty();
			this.mText.cachedTextGenerator.Invalidate();
			this.mText.cachedTextGeneratorForLayout.Invalidate();
			float preferredWidth = this.mText.preferredWidth;
			if (this.TextWidth > preferredWidth)
			{
				this.LineRect.sizeDelta = new Vector2(preferredWidth, this.LineRect.sizeDelta.y);
			}
			else
			{
				this.LineRect.sizeDelta = new Vector2(this.TextWidth, this.LineRect.sizeDelta.y);
			}
			if (this.mText.alignment == TextAnchor.LowerRight || this.mText.alignment == TextAnchor.MiddleRight || this.mText.alignment == TextAnchor.UpperRight)
			{
				this.LineRect.anchoredPosition = new Vector2(this.TextWidth - this.LineRect.sizeDelta.x, this.LineRect.anchoredPosition.y);
			}
			this.ButtonRect.sizeDelta = new Vector2(this.LineRect.sizeDelta.x, this.ButtonRect.sizeDelta.y);
			this.ButtonRect.anchoredPosition = new Vector2(this.LineRect.anchoredPosition.x, this.ButtonRect.anchoredPosition.y);
			if (GUIManager.Instance.IsArabic)
			{
				this.LineRect.anchoredPosition = new Vector2(this.mText.rectTransform.offsetMin.x, this.LineRect.anchoredPosition.y);
			}
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x00161F90 File Offset: 0x00160190
		public void TextRefresh()
		{
			this.mText.enabled = false;
			this.mText.enabled = true;
		}

		// Token: 0x04002CF1 RID: 11505
		private RectTransform LineRect;

		// Token: 0x04002CF2 RID: 11506
		private RectTransform ButtonRect;

		// Token: 0x04002CF3 RID: 11507
		private float TextWidth;

		// Token: 0x04002CF4 RID: 11508
		private UIText mText;

		// Token: 0x04002CF5 RID: 11509
		public UIButton Button;
	}
}
