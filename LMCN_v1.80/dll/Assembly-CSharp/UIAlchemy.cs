using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004C3 RID: 1219
public class UIAlchemy : GUIWindow, UILoadImageHander, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x170000B0 RID: 176
	// (get) Token: 0x0600189D RID: 6301 RVA: 0x00295044 File Offset: 0x00293244
	private Door door
	{
		get
		{
			if (this.m_door == null)
			{
				this.m_door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
			}
			return this.m_door;
		}
	}

	// Token: 0x0600189E RID: 6302 RVA: 0x00295074 File Offset: 0x00293274
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.m_transform = base.transform;
		this.tmpFont = this.GM.GetTTFFont();
		UIText component = this.m_transform.GetChild(5).GetComponent<UIText>();
		component.font = this.tmpFont;
		component.text = this.DM.mStringTable.GetStringByID(12027u);
		this.AllText.Add(component);
		this.DontHaveText = this.m_transform.GetChild(6).GetComponent<UIText>();
		this.DontHaveText.font = this.tmpFont;
		this.DontHaveText.text = this.DM.mStringTable.GetStringByID(12030u);
		this.AllText.Add(this.DontHaveText);
		this.m_transform.GetChild(7).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(7).gameObject.AddComponent<ArabicItemTextureRot>();
		this.m_transform.GetChild(8).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(8).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(8).GetChild(0).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(8).GetComponent<CustomImage>().enabled = false;
		}
		this.tFront1 = this.m_transform.GetChild(9);
		for (int i = 0; i < 3; i++)
		{
			this.Box[i].PressImage = this.tFront1.GetChild(i).GetComponent<Image>();
			this.Box[i].PressImageSA = this.tFront1.GetChild(i).GetComponent<UISpritesArray>();
			this.Box[i].ClockImage = this.tFront1.GetChild(i + 3).GetComponent<Image>();
			this.Box[i].Clock2Image = this.tFront1.GetChild(i + 6).GetComponent<Image>();
			this.Box[i].BtnTopText = this.tFront1.GetChild(i + 9).GetComponent<UIText>();
			this.Box[i].BtnTopText.font = this.tmpFont;
			this.AllText.Add(this.Box[i].BtnTopText);
			this.Box[i].TotalTimeText = this.tFront1.GetChild(i + 12).GetComponent<UIText>();
			this.Box[i].TotalTimeText.font = this.tmpFont;
			this.AllText.Add(this.Box[i].TotalTimeText);
			this.Box[i].OpenTimeText = this.tFront1.GetChild(i + 15).GetComponent<UIText>();
			this.Box[i].OpenTimeText.font = this.tmpFont;
			this.AllText.Add(this.Box[i].OpenTimeText);
			this.Box[i].TimeStr = StringManager.Instance.SpawnString(15);
		}
		this.tFront1.GetChild(18).GetComponent<UIButton>().m_Handler = this;
		this.tFront1.GetChild(19).GetComponent<UIButton>().m_Handler = this;
		this.tFront1.GetChild(20).GetComponent<UIButton>().m_Handler = this;
		this.tFront1.GetChild(21).GetComponent<UIButton>().m_Handler = this;
		this.tFront1.GetChild(22).GetComponent<UIButton>().m_Handler = this;
		this.tFront1.GetChild(23).GetComponent<UIButton>().m_Handler = this;
		for (int j = 0; j < 3; j++)
		{
			this.Box[j].HintButton = this.tFront1.GetChild(24 + j).GetComponent<UIButton>();
			this.Box[j].HintButton.m_Handler = this;
			UIButtonHint uibuttonHint = this.Box[j].HintButton.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.Parm1 = 12026;
			uibuttonHint.m_DownUpHandler = this;
		}
		this.tFront2 = this.m_transform.GetChild(10);
		HelperUIButton helperUIButton = this.tFront2.gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID1 = 2;
		helperUIButton.m_BtnID2 = 1;
		this.Front_TitleText = this.tFront2.GetChild(4).GetComponent<UIText>();
		this.Front_TitleText.font = this.tmpFont;
		this.AllText.Add(this.Front_TitleText);
		this.Front_CheckText = this.tFront2.GetChild(8).GetChild(0).GetComponent<UIText>();
		this.Front_CheckText.font = this.tmpFont;
		this.AllText.Add(component);
		this.Front_TotalTimeText = this.tFront2.GetChild(10).GetComponent<UIText>();
		this.Front_TotalTimeText.font = this.tmpFont;
		this.Front_TotalTimeText.alignment = TextAnchor.MiddleCenter;
		this.AllText.Add(this.Front_TotalTimeText);
		this.Front_OpenTimeText = this.tFront2.GetChild(12).GetComponent<UIText>();
		this.Front_OpenTimeText.font = this.tmpFont;
		this.AllText.Add(this.Front_OpenTimeText);
		this.Front_MessageText = this.tFront2.GetChild(13).GetComponent<UIText>();
		this.Front_MessageText.font = this.tmpFont;
		this.Front_MessageText.text = this.DM.mStringTable.GetStringByID(12032u);
		this.AllText.Add(this.Front_MessageText);
		this.Front_ItemNameText = this.tFront2.GetChild(17).GetComponent<UIText>();
		this.Front_ItemNameText.font = this.tmpFont;
		this.AllText.Add(this.Front_ItemNameText);
		this.Front_ItemCountText = this.tFront2.GetChild(18).GetComponent<UIText>();
		this.Front_ItemCountText.font = this.tmpFont;
		this.AllText.Add(this.Front_ItemCountText);
		this.tFront2.GetChild(5).GetComponent<UIButton>().m_Handler = this;
		this.tFront2.GetChild(5).GetComponent<CustomImage>().hander = this;
		this.tFront2.GetChild(7).GetComponent<UIButton>().m_Handler = this;
		this.tFront2.GetChild(8).GetComponent<UIButton>().m_Handler = this;
		this.GM.InitianHeroItemImg(this.tFront2.GetChild(16), eHeroOrItem.Item, 10, 0, 0, 0, true, true, true, false);
		this.Front_ItemCountStr = StringManager.Instance.SpawnString(150);
		this.Front_HINTBtn = this.tFront2.GetChild(19).GetComponent<UIButton>();
		this.Front_HINTBtn.m_Handler = this;
		this.Front_HINTBtn.m_BtnID2 = 2;
		UIButtonHint uibuttonHint2 = this.Front_HINTBtn.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint2.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint2.Parm1 = 12026;
		uibuttonHint2.m_DownUpHandler = this;
		this.tTimeObj = this.m_transform.GetChild(11);
		this.tTimeObj.GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.tTimeObj.GetChild(0).GetComponent<UIButton>().transition = Selectable.Transition.None;
		UIButtonHint uibuttonHint3 = this.tTimeObj.GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint3.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint3.Parm1 = 12048;
		uibuttonHint3.m_DownUpHandler = this;
		component = this.tTimeObj.GetChild(2).GetComponent<UIText>();
		component.font = this.tmpFont;
		component.text = this.DM.mStringTable.GetStringByID(8110u);
		this.AllText.Add(component);
		this.CountTimeText = this.tTimeObj.GetChild(3).GetComponent<UIText>();
		this.CountTimeText.font = this.tmpFont;
		this.AllText.Add(this.CountTimeText);
		this.CountTimeStr = StringManager.Instance.SpawnString(30);
		this.ActorT[0] = this.m_transform.GetChild(15);
		this.ActorT[1] = this.m_transform.GetChild(16);
		this.ActorT[2] = this.m_transform.GetChild(17);
		this.AB = AssetManager.GetAssetBundle("Role/darkbox", out this.AssetKey, false);
		if (this.AB != null)
		{
			this.AR = this.AB.LoadAsync("m", typeof(GameObject));
		}
		if (this.GM.bOpenOnIPhoneX)
		{
			((RectTransform)this.tFront2).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0f);
			((RectTransform)this.tFront2).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0f);
		}
		this.tFront2.GetComponent<RectTransform>().localPosition = Vector3.zero;
		this.tFront2.SetParent(this.GM.m_SecWindowLayer, false);
		this.CheckHaveText();
		this.SetTimeText();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x0600189F RID: 6303 RVA: 0x00295A0C File Offset: 0x00293C0C
	public override void OnClose()
	{
		this.tFront2.SetParent(this.m_transform);
		for (int i = 0; i < 3; i++)
		{
			if (this.EffectObj[i] != null)
			{
				ParticleManager.Instance.DeSpawn(this.EffectObj[i]);
				this.EffectObj[i] = null;
			}
			if (this.Box[i].TimeStr != null)
			{
				StringManager.Instance.DeSpawnString(this.Box[i].TimeStr);
			}
			if (this.BoxGO[i] == null)
			{
				UnityEngine.Object.Destroy(this.BoxGO[i]);
				this.BoxGO[i] = null;
			}
		}
		if (this.EffectObj3 != null && this.EffectObj3.activeSelf && ParticleManager.Instance.AllEffectObject != null)
		{
			this.EffectObj3.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
		}
		if (this.EffectObj2 != null)
		{
			ParticleManager.Instance.DeSpawn(this.EffectObj2);
			this.EffectObj2 = null;
		}
		if (this.EffectObj1 != null)
		{
			ParticleManager.Instance.DeSpawn(this.EffectObj1);
			this.EffectObj1 = null;
		}
		if (this.Front_ItemCountStr != null)
		{
			StringManager.Instance.DeSpawnString(this.Front_ItemCountStr);
		}
		if (this.CountTimeStr != null)
		{
			StringManager.Instance.DeSpawnString(this.CountTimeStr);
		}
		if (this.AssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey, true);
		}
	}

	// Token: 0x060018A0 RID: 6304 RVA: 0x00295BC0 File Offset: 0x00293DC0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Fallout)
			{
				if (networkNews != NetworkNews.Refresh_AttribEffectVal)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						if (this.AllText != null)
						{
							for (int i = 0; i < this.AllText.Count; i++)
							{
								if (this.AllText[i] != null && this.AllText[i].enabled)
								{
									this.AllText[i].enabled = false;
									this.AllText[i].enabled = true;
								}
							}
						}
					}
				}
				else
				{
					this.ReSetTotalTime();
				}
			}
			else
			{
				this.tFront2.GetChild(6).gameObject.SetActive(false);
			}
		}
		else
		{
			this.tFront2.GetChild(6).gameObject.SetActive(true);
			if (this.tFront2.gameObject.activeInHierarchy && !NewbieManager.IsWorking())
			{
				this.NowIndex = 0;
				this.tFState = 0;
				this.tFront2.gameObject.SetActive(false);
			}
			this.SetTimeText();
		}
	}

	// Token: 0x060018A1 RID: 6305 RVA: 0x00295CF8 File Offset: 0x00293EF8
	private void Update()
	{
		if (!this.bABInitial && this.AR != null && this.AR.isDone)
		{
			for (int i = 0; i < 3; i++)
			{
				if (this.BoxGO[i] == null)
				{
					if (i == 2)
					{
						this.bABInitial = true;
					}
					this.BoxGO[i] = (GameObject)UnityEngine.Object.Instantiate(this.AR.asset);
					this.BoxGO[i].transform.SetParent(this.ActorT[i], false);
					this.BoxGO[i].transform.localPosition = Vector3.zero;
					this.BoxGO[i].transform.localRotation = new Quaternion(0f, -180f, 0f, 0f);
					this.BoxGO[i].transform.localScale = new Vector3((float)this.ScaleRate, (float)this.ScaleRate, (float)this.ScaleRate);
					GUIManager.Instance.SetLayer(this.BoxGO[i], 5);
					this.WPT[i] = this.BoxGO[i].transform.GetChild(0).GetChild(1);
					if (this.BoxGO[i] != null)
					{
						this.tmpAN[i] = this.BoxGO[i].GetComponent<Animation>();
						this.tmpAN[i].wrapMode = WrapMode.Loop;
						this.tmpAN[i].cullingType = AnimationCullingType.AlwaysAnimate;
						this.tmpAN[i]["idle"].layer = 0;
						this.tmpAN[i]["close_idle"].layer = 0;
						this.tmpAN[i]["close_open"].layer = 0;
						this.tmpAN[i]["close"].layer = 1;
						this.tmpAN[i]["close"].wrapMode = WrapMode.Default;
						this.tmpAN[i].Stop();
						this.tmpAN[i]["idle"].time = UnityEngine.Random.Range(0f, this.tmpAN[i]["idle"].length);
						this.tmpAN[i].clip = this.tmpAN[i].GetClip("idle");
						if (this.GM.BoxID[i] > 0 && this.GM.BoxTime[i] > 0L)
						{
							if (this.GM.BoxTime[i] > this.DM.ServerTime)
							{
								this.tmpAN[i].Play("close_open");
							}
							else
							{
								this.tmpAN[i].Play("close_idle");
							}
						}
						else
						{
							this.tmpAN[i].Play("idle");
						}
						SkinnedMeshRenderer componentInChildren = this.BoxGO[i].GetComponentInChildren<SkinnedMeshRenderer>();
						if (componentInChildren != null)
						{
							componentInChildren.useLightProbes = false;
							componentInChildren.updateWhenOffscreen = true;
						}
						this.CloseTime = this.tmpAN[i]["close"].length;
					}
					this.ReSetState(i, true);
					return;
				}
			}
		}
		if (this.bABInitial)
		{
			this.CheckTime -= Time.unscaledDeltaTime;
			if (this.CheckTime <= 0f)
			{
				this.CheckTime = 1f;
				for (int j = 0; j < 3; j++)
				{
					if (this.BoxGO[j] != null && this.GM.BoxID[j] != 0 && this.GM.BoxTime[j] > this.DM.ServerTime)
					{
						this.Box[j].TimeStr.Length = 0;
						GameConstants.GetTimeString(this.Box[j].TimeStr, (uint)(this.GM.BoxTime[j] - this.DM.ServerTime), false, true, false, false, true);
						this.Box[j].OpenTimeText.text = this.Box[j].TimeStr.ToString();
						this.Box[j].OpenTimeText.SetAllDirty();
						this.Box[j].OpenTimeText.cachedTextGenerator.Invalidate();
						if ((int)this.NowIndex == j + 1)
						{
							this.Front_OpenTimeText.text = this.Box[j].TimeStr.ToString();
							this.Front_OpenTimeText.SetAllDirty();
							this.Front_OpenTimeText.cachedTextGenerator.Invalidate();
						}
					}
					if (this.BoxGO[j] != null && this.GM.BoxID[j] != 0 && this.GM.BoxTime[j] > 0L && this.GM.BoxTime[j] < this.DM.ServerTime && this.Box[j].OpenTimeText.gameObject.activeInHierarchy)
					{
						this.ReSetState(j, true);
					}
				}
			}
			if (this.Open_Close != 0)
			{
				this.WaitTime -= Time.unscaledDeltaTime;
				if (this.WaitTime < 0f)
				{
					if (this.Open_Close == 1)
					{
						Vector2 sizeDelta = this.GM.m_UICanvas.gameObject.GetComponent<RectTransform>().sizeDelta;
						sizeDelta = new Vector2(sizeDelta.x / 2f, sizeDelta.y / 2f + 50f);
						Vector2 zero = Vector2.zero;
						if (this.WaitIndex == 0)
						{
							zero = new Vector2(sizeDelta.x - 265f, sizeDelta.y);
						}
						else if (this.WaitIndex == 1)
						{
							zero = new Vector2(sizeDelta.x, sizeDelta.y);
						}
						else if (this.WaitIndex == 2)
						{
							zero = new Vector2(sizeDelta.x + 265f, sizeDelta.y);
						}
						if (this.GM.BoxRewardCrystal > 0u)
						{
							this.GM.m_SpeciallyEffect.mDiamondValue = this.GM.BoxRewardCrystal;
							this.GM.m_SpeciallyEffect.AddIconShow(false, zero, SpeciallyEffect_Kind.Diamond, 0, 0, true, 2f);
						}
						else if (this.GM.BoxRewardAlliance > 0u)
						{
							this.GM.m_SpeciallyEffect.AddIconShow(false, zero, SpeciallyEffect_Kind.AllianceMoney, 0, 0, true, 2f);
						}
						else
						{
							GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, zero, SpeciallyEffect_Kind.Item, 0, this.GM.BoxRewardItemID, true, 2f);
						}
						this.ReSerAll(this.WaitIndex);
						this.WaitIndex = -1;
						this.Open_Close = 3;
						this.WaitTime = 1f;
					}
					else if (this.Open_Close == 3)
					{
						this.Open_Close = 0;
						this.OpenFront2_Get();
					}
					else if (this.Open_Close == 2)
					{
						AudioManager.Instance.PlayUISFX(UIKind.Laboratory_Start);
						this.WaitTime = this.CloseTime - this.ClosePreTime;
						this.Open_Close = 4;
					}
					else if (this.Open_Close == 4)
					{
						this.ReSerAll(this.WaitIndex);
						this.WaitIndex = -1;
						this.Open_Close = 0;
					}
				}
				if (this.WaitPlaySFX > 0f)
				{
					this.WaitPlaySFX -= Time.unscaledDeltaTime;
					if (this.WaitPlaySFX <= 0f)
					{
						this.WaitPlaySFX = -1f;
						AudioManager.Instance.PlaySFX(903, 0f, PitchKind.NoPitch, null, null);
					}
				}
			}
		}
	}

	// Token: 0x060018A2 RID: 6306 RVA: 0x002964D0 File Offset: 0x002946D0
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			this.SetTimeText();
		}
	}

	// Token: 0x060018A3 RID: 6307 RVA: 0x002964E0 File Offset: 0x002946E0
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.ReSetAll();
		}
		else if (arg1 == 2)
		{
			this.Open_Close = 2;
			this.WaitIndex = arg2;
			this.WaitTime = this.ClosePreTime;
			this.tmpAN[arg2]["close"].time = 0f;
			this.tmpAN[arg2]["close"].speed = 1f;
			this.tmpAN[arg2].CrossFade("close");
			this.tmpAN[arg2].CrossFade("close_idle");
		}
		else if (arg1 == 3)
		{
			this.Open_Close = 1;
			this.WaitIndex = arg2;
			this.WaitTime = this.CloseTime;
			this.LoadEffect(arg2, this.GM.BoxRewardID);
			this.LoadGetEffect(arg2);
			AudioManager.Instance.PlayUISFX(UIKind.Laboratory_Open);
			this.WaitPlaySFX = 0.358f;
			this.tmpAN[arg2]["close"].time = this.tmpAN[arg2]["close"].length;
			this.tmpAN[arg2]["close"].speed = -1f;
			this.tmpAN[arg2].CrossFade("close");
			this.tmpAN[arg2].CrossFade("idle");
		}
		else if (arg1 == 4)
		{
			this.ReSetState(arg2, true);
		}
		else if (arg1 == 5)
		{
			this.ReSetState(arg2, true);
		}
		else if (arg1 == 6)
		{
			if (this.tFront2.gameObject.activeInHierarchy && (int)(this.NowIndex - 1) == arg2)
			{
				this.tFState = 0;
				this.NowIndex = 0;
				this.tFront2.gameObject.SetActive(false);
			}
		}
		else if (arg1 == 7)
		{
			this.SetTimeText();
		}
	}

	// Token: 0x060018A4 RID: 6308 RVA: 0x002966CC File Offset: 0x002948CC
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			if (sender.m_BtnID2 == 1)
			{
				if (this.door)
				{
					this.door.CloseMenu(false);
				}
			}
			else if (sender.m_BtnID2 == 2)
			{
				this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(12044u), this.DM.mStringTable.GetStringByID(12039u), null, null, 0, 0, true, true);
			}
		}
		else if (sender.m_BtnID1 == 2)
		{
			if (sender.m_BtnID2 == 1)
			{
				this.tFState = 0;
				this.tFront2.gameObject.SetActive(false);
			}
			else if (sender.m_BtnID2 == 2)
			{
				if (this.NowIndex - 1 < 3)
				{
					this.GM.MsgStr.Length = 0;
					this.GM.MsgStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[(int)(this.NowIndex - 1)]).Element));
					this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(12037u));
					this.GM.OpenSpendWindow_Normal(this, this.DM.mStringTable.GetStringByID(12036u), this.GM.MsgStr.ToString(), (int)this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[(int)(this.NowIndex - 1)]).Coin, 0, (int)this.NowIndex, this.DM.mStringTable.GetStringByID(12040u), true);
					this.NowIndex = 0;
				}
				this.tFront2.gameObject.SetActive(false);
			}
			else if (sender.m_BtnID2 == 3)
			{
				if (this.tFState == 1)
				{
					this.tFState = 0;
					this.GM.Send_NPC_START_REWARD(this.NowIndex);
					this.NowIndex = 0;
				}
				this.tFront2.gameObject.SetActive(false);
			}
		}
		else if (sender.m_BtnID1 == 3 && this.Open_Close == 0)
		{
			this.OpenFront2(sender.m_BtnID2 - 1);
		}
	}

	// Token: 0x060018A5 RID: 6309 RVA: 0x0029693C File Offset: 0x00294B3C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 != 0)
			{
				if (arg1 == 1)
				{
					int num = 1;
					if (this.door != null)
					{
						this.door.OpenMenu(EGUIWindow.UI_BagFilter, num + 262144, 0, false);
					}
				}
			}
			else if (this.DM.Resource[4].Stock >= (uint)this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[arg2 - 1]).Coin)
			{
				this.GM.Send_NPC_DELETE_REWARD((byte)arg2);
			}
			else
			{
				this.GM.MsgStr.Length = 0;
				this.GM.MsgStr.StringToFormat(this.DM.mStringTable.GetStringByID(6012u));
				this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(1546u));
				this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(5721u), this.GM.MsgStr.ToString(), this.DM.mStringTable.GetStringByID(3968u), this, 1, 0, true, false, false, false, false);
			}
		}
	}

	// Token: 0x060018A6 RID: 6310 RVA: 0x00296A90 File Offset: 0x00294C90
	private int bTransIng()
	{
		for (int i = 0; i < 3; i++)
		{
			if (this.GM.BoxTime[i] != 0L)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x060018A7 RID: 6311 RVA: 0x00296AC4 File Offset: 0x00294CC4
	private void CheckHaveText()
	{
		bool flag = false;
		for (int i = 0; i < 3; i++)
		{
			if (this.GM.BoxID[i] != 0)
			{
				flag = true;
				break;
			}
		}
		this.DontHaveText.gameObject.SetActive(!flag);
	}

	// Token: 0x060018A8 RID: 6312 RVA: 0x00296B14 File Offset: 0x00294D14
	private void LoadEffect(int Index, ushort BoxID = 0)
	{
		if (Index < 0 || Index >= 3)
		{
			return;
		}
		if (this.EffectObj[Index] != null)
		{
			ParticleManager.Instance.DeSpawn(this.EffectObj[Index]);
			this.EffectObj[Index] = null;
		}
		if (BoxID != 0)
		{
			this.EffectObj[Index] = ParticleManager.Instance.Spawn(400 + this.DM.NPCPrize.GetRecordByKey(BoxID).PicNo - 60000, this.WPT[Index], Vector3.zero, 1.4f, true, true, true);
		}
		else
		{
			this.EffectObj[Index] = ParticleManager.Instance.Spawn(400 + this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[Index]).PicNo - 60000, this.WPT[Index], Vector3.zero, 1.4f, true, true, true);
		}
		if (this.EffectObj[Index] != null)
		{
			this.GM.SetLayer(this.EffectObj[Index], 5);
			this.EffectObj[Index].transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			this.EffectObj[Index].transform.localPosition = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060018A9 RID: 6313 RVA: 0x00296C88 File Offset: 0x00294E88
	private void LoadFrontEffect(int Index)
	{
		if (Index < 0 || Index >= 3)
		{
			return;
		}
		if (this.EffectObj2 != null)
		{
			ParticleManager.Instance.DeSpawn(this.EffectObj2);
			this.EffectObj2 = null;
		}
		this.EffectObj2 = ParticleManager.Instance.Spawn(400 + this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[Index]).PicNo - 60000, this.tFront2.GetChild(6), Vector3.zero, 1.4f, true, true, true);
		if (this.EffectObj2 != null)
		{
			this.GM.SetLayer(this.EffectObj2, 5);
			this.EffectObj2.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			this.EffectObj2.transform.localPosition = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060018AA RID: 6314 RVA: 0x00296D98 File Offset: 0x00294F98
	private void LoadGetEffect(int Index)
	{
		if (Index < 0 || Index >= 3)
		{
			return;
		}
		this.EffectObj3 = ParticleManager.Instance.Spawn(406, this.ActorT[Index], Vector3.zero, 1f, true, true, true);
		if (this.EffectObj3 != null)
		{
			this.GM.SetLayer(this.EffectObj3, 5);
			this.EffectObj3.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			this.EffectObj3.transform.localPosition = new Vector3(0f, 185f, -170f);
		}
	}

	// Token: 0x060018AB RID: 6315 RVA: 0x00296E50 File Offset: 0x00295050
	private void LoadIngEffect(int Index)
	{
		if (Index < 0 || Index >= 3)
		{
			return;
		}
		this.IngEffectIndex = Index;
		this.EffectObj1 = ParticleManager.Instance.Spawn(6, this.ActorT[Index], Vector3.zero, 0.4f, true, true, true);
		if (this.EffectObj1 != null)
		{
			this.GM.SetLayer(this.EffectObj1, 5);
			this.EffectObj1.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			this.EffectObj1.transform.localPosition = new Vector3(-1f, 148f, -96f);
		}
	}

	// Token: 0x060018AC RID: 6316 RVA: 0x00296F0C File Offset: 0x0029510C
	private void DeSpawnIngEffect(int Index)
	{
		if (Index == this.IngEffectIndex && this.EffectObj1 != null)
		{
			this.IngEffectIndex = -1;
			ParticleManager.Instance.DeSpawn(this.EffectObj1);
			this.EffectObj1 = null;
		}
	}

	// Token: 0x060018AD RID: 6317 RVA: 0x00296F58 File Offset: 0x00295158
	private void OpenFront2_Get()
	{
		for (int i = 6; i <= 18; i++)
		{
			this.tFront2.GetChild(i).gameObject.SetActive(false);
		}
		this.Front_TitleText.text = this.DM.mStringTable.GetStringByID((uint)this.DM.NPCPrize.GetRecordByKey(this.GM.BoxRewardID).Element);
		this.Front_CheckText.text = this.DM.mStringTable.GetStringByID(3u);
		Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.GM.BoxRewardItemID);
		if (recordByKey.EquipKey == this.GM.BoxRewardItemID)
		{
			this.GM.ChangeHeroItemImg(this.tFront2.GetChild(16), eHeroOrItem.Item, this.GM.BoxRewardItemID, this.GM.BoxRewardItemRank, 0, 0);
			this.Front_ItemNameText.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.EquipName);
			this.tFront2.GetChild(16).gameObject.SetActive(true);
			this.tFront2.GetChild(17).gameObject.SetActive(true);
		}
		this.Front_ItemCountStr.Length = 0;
		this.Front_ItemCountStr.IntToFormat((long)this.GM.BoxRewardNum, 1, false);
		this.Front_ItemCountStr.AppendFormat(this.DM.mStringTable.GetStringByID(7676u));
		this.Front_ItemCountText.text = this.Front_ItemCountStr.ToString();
		this.Front_ItemCountText.SetAllDirty();
		this.Front_ItemCountText.cachedTextGenerator.Invalidate();
		this.tFront2.GetChild(8).gameObject.SetActive(true);
		this.tFront2.GetChild(14).gameObject.SetActive(true);
		this.tFront2.GetChild(15).gameObject.SetActive(true);
		this.tFront2.GetChild(18).gameObject.SetActive(true);
		this.tFront2.gameObject.SetActive(true);
	}

	// Token: 0x060018AE RID: 6318 RVA: 0x00297188 File Offset: 0x00295388
	public void OpenFront2(int Index)
	{
		if (Index < 3 && this.BoxGO[Index] != null)
		{
			if (this.GM.BoxID[Index] != 0)
			{
				this.NowIndex = (byte)(Index + 1);
				for (int i = 6; i <= 18; i++)
				{
					this.tFront2.GetChild(i).gameObject.SetActive(false);
				}
				if (this.GM.BoxTime[Index] != 0L)
				{
					if (this.GM.BoxTime[Index] <= this.DM.ServerTime)
					{
						this.GM.Send_NPC_GET_REWARD(this.NowIndex);
						this.NowIndex = 0;
						return;
					}
					this.tFront2.GetChild(6).gameObject.SetActive(true);
					this.tFront2.GetChild(7).gameObject.SetActive(true);
					this.tFront2.GetChild(8).gameObject.SetActive(true);
					this.tFront2.GetChild(11).gameObject.SetActive(true);
					this.tFront2.GetChild(12).gameObject.SetActive(true);
					this.tFront2.GetChild(19).gameObject.SetActive(true);
					this.tFront2.GetChild(19).gameObject.GetComponent<UIButtonHint>().Parm1 = 12028;
					this.Front_TitleText.text = this.DM.mStringTable.GetStringByID((uint)this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[Index]).Element);
					this.Front_CheckText.text = this.DM.mStringTable.GetStringByID(3u);
					this.Front_OpenTimeText.text = this.Box[Index].TimeStr.ToString();
					this.Front_OpenTimeText.SetAllDirty();
					this.Front_OpenTimeText.cachedTextGenerator.Invalidate();
					this.LoadFrontEffect(Index);
				}
				else
				{
					int num = this.bTransIng();
					if (num == -1)
					{
						this.tFront2.GetChild(6).gameObject.SetActive(true);
						this.tFront2.GetChild(7).gameObject.SetActive(true);
						this.tFront2.GetChild(8).gameObject.SetActive(true);
						this.tFront2.GetChild(9).gameObject.SetActive(true);
						this.tFront2.GetChild(10).gameObject.SetActive(true);
						this.tFront2.GetChild(19).gameObject.SetActive(true);
						this.tFront2.GetChild(19).gameObject.GetComponent<UIButtonHint>().Parm1 = 12026;
						this.Front_TitleText.text = this.DM.mStringTable.GetStringByID((uint)this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[Index]).Element);
						this.Front_CheckText.text = this.DM.mStringTable.GetStringByID(12031u);
						this.Front_TotalTimeText.text = this.Box[Index].TimeStr.ToString();
						this.Front_TotalTimeText.SetAllDirty();
						this.Front_TotalTimeText.cachedTextGenerator.Invalidate();
						Image component = this.tFront2.GetChild(9).GetComponent<Image>();
						component.rectTransform.anchoredPosition = new Vector2(this.Front_TotalTimeText.rectTransform.anchoredPosition.x - this.Front_TotalTimeText.preferredWidth / 2f - 18f, component.rectTransform.anchoredPosition.y);
						this.tFState = 1;
						this.LoadFrontEffect(Index);
					}
					else
					{
						this.Front_TitleText.text = this.DM.mStringTable.GetStringByID((uint)this.DM.NPCPrize.GetRecordByKey(this.GM.BoxID[Index]).Element);
						this.tFront2.GetChild(6).gameObject.SetActive(true);
						this.tFront2.GetChild(7).gameObject.SetActive(true);
						this.tFront2.GetChild(8).gameObject.SetActive(true);
						this.tFront2.GetChild(13).gameObject.SetActive(true);
						if (this.GM.BoxTime[num] <= this.DM.ServerTime)
						{
							this.Front_MessageText.text = this.DM.mStringTable.GetStringByID(12038u);
						}
						else
						{
							this.Front_MessageText.text = this.DM.mStringTable.GetStringByID(12032u);
						}
						this.Front_CheckText.text = this.DM.mStringTable.GetStringByID(3u);
						this.LoadFrontEffect(Index);
					}
				}
				this.tFront2.gameObject.SetActive(true);
			}
			else
			{
				this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12030u), 255, true);
			}
		}
	}

	// Token: 0x060018AF RID: 6319 RVA: 0x002976C8 File Offset: 0x002958C8
	private void ReSetState(int Index, bool bUpDateEffect = true)
	{
		if (Index < 3 && this.BoxGO[Index] != null)
		{
			this.Box[Index].PressImage.gameObject.SetActive(false);
			this.Box[Index].ClockImage.gameObject.SetActive(false);
			this.Box[Index].Clock2Image.gameObject.SetActive(false);
			this.Box[Index].BtnTopText.gameObject.SetActive(false);
			this.Box[Index].TotalTimeText.gameObject.SetActive(false);
			this.Box[Index].OpenTimeText.gameObject.SetActive(false);
			this.Box[Index].HintButton.gameObject.SetActive(false);
			if (this.GM.BoxID[Index] != 0 && this.GM.BoxTime[Index] != 0L)
			{
				if (this.GM.BoxTime[Index] > this.DM.ServerTime)
				{
					this.tmpAN[Index].clip = this.tmpAN[Index].GetClip("close_idle");
					this.tmpAN[Index].CrossFade("close_idle");
					this.Box[Index].Clock2Image.gameObject.SetActive(true);
					this.Box[Index].OpenTimeText.gameObject.SetActive(true);
					this.Box[Index].HintButton.gameObject.SetActive(true);
					this.Box[Index].HintButton.gameObject.GetComponent<UIButtonHint>().Parm1 = 12028;
					this.Box[Index].TimeStr.Length = 0;
					GameConstants.GetTimeString(this.Box[Index].TimeStr, (uint)(this.GM.BoxTime[Index] - this.DM.ServerTime), false, true, false, false, true);
					this.Box[Index].OpenTimeText.text = this.Box[Index].TimeStr.ToString();
					this.Box[Index].OpenTimeText.SetAllDirty();
					this.Box[Index].OpenTimeText.cachedTextGenerator.Invalidate();
					this.LoadIngEffect(Index);
				}
				else
				{
					this.DeSpawnIngEffect(Index);
					this.tmpAN[Index].clip = this.tmpAN[Index].GetClip("close_idle");
					this.tmpAN[Index].CrossFade("close_open");
					this.Box[Index].PressImageSA.SetSpriteIndex(1);
					this.Box[Index].PressImage.gameObject.SetActive(true);
					this.Box[Index].BtnTopText.text = this.DM.mStringTable.GetStringByID(1520u);
					this.Box[Index].BtnTopText.gameObject.SetActive(true);
				}
			}
			else
			{
				this.DeSpawnIngEffect(Index);
				this.tmpAN[Index].clip = this.tmpAN[Index].GetClip("idle");
				this.tmpAN[Index].CrossFade("idle");
				if (this.GM.BoxID[Index] != 0)
				{
					if (this.bTransIng() == -1)
					{
						this.Box[Index].PressImageSA.SetSpriteIndex(0);
						this.Box[Index].PressImage.gameObject.SetActive(true);
						this.Box[Index].BtnTopText.text = this.DM.mStringTable.GetStringByID(12029u);
						this.Box[Index].BtnTopText.gameObject.SetActive(true);
					}
					this.Box[Index].ClockImage.gameObject.SetActive(true);
					this.Box[Index].TotalTimeText.gameObject.SetActive(true);
					this.Box[Index].HintButton.gameObject.SetActive(true);
					this.Box[Index].HintButton.gameObject.GetComponent<UIButtonHint>().Parm1 = 12026;
					this.Box[Index].TimeStr.Length = 0;
					GameConstants.GetTimeInfoString(this.Box[Index].TimeStr, this.GM.GetRequireTime(this.GM.BoxRequire[Index]));
					this.Box[Index].TotalTimeText.text = this.Box[Index].TimeStr.ToString();
					this.Box[Index].TotalTimeText.SetAllDirty();
					this.Box[Index].TotalTimeText.cachedTextGenerator.Invalidate();
					this.Box[Index].ClockImage.rectTransform.anchoredPosition = new Vector2(this.Box[Index].TotalTimeText.rectTransform.anchoredPosition.x - this.Box[Index].TotalTimeText.preferredWidth / 2f - 18f, this.Box[Index].ClockImage.rectTransform.anchoredPosition.y);
					if (bUpDateEffect)
					{
						this.LoadEffect(Index, 0);
					}
				}
				else if (this.EffectObj[Index] != null)
				{
					ParticleManager.Instance.DeSpawn(this.EffectObj[Index]);
					this.EffectObj[Index] = null;
				}
			}
			this.CheckHaveText();
		}
	}

	// Token: 0x060018B0 RID: 6320 RVA: 0x00297CC8 File Offset: 0x00295EC8
	private void ReSetTotalTime()
	{
		if (!this.bABInitial)
		{
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.GM.BoxID[i] != 0 && this.GM.BoxTime[i] == 0L)
			{
				this.Box[i].TimeStr.Length = 0;
				GameConstants.GetTimeInfoString(this.Box[i].TimeStr, this.GM.GetRequireTime(this.GM.BoxRequire[i]));
				this.Box[i].TotalTimeText.text = this.Box[i].TimeStr.ToString();
				this.Box[i].TotalTimeText.SetAllDirty();
				this.Box[i].TotalTimeText.cachedTextGenerator.Invalidate();
				this.Box[i].ClockImage.rectTransform.anchoredPosition = new Vector2(this.Box[i].TotalTimeText.rectTransform.anchoredPosition.x - this.Box[i].TotalTimeText.preferredWidth / 2f - 18f, this.Box[i].ClockImage.rectTransform.anchoredPosition.y);
			}
		}
		if (this.NowIndex != 0)
		{
			this.Front_TotalTimeText.text = this.Box[(int)(this.NowIndex - 1)].TimeStr.ToString();
			this.Front_TotalTimeText.SetAllDirty();
			this.Front_TotalTimeText.cachedTextGenerator.Invalidate();
			Image component = this.tFront2.GetChild(9).GetComponent<Image>();
			component.rectTransform.anchoredPosition = new Vector2(this.Front_TotalTimeText.rectTransform.anchoredPosition.x - this.Front_TotalTimeText.preferredWidth / 2f - 18f, component.rectTransform.anchoredPosition.y);
		}
	}

	// Token: 0x060018B1 RID: 6321 RVA: 0x00297EF8 File Offset: 0x002960F8
	private void ReSetAll()
	{
		for (int i = 0; i < 3; i++)
		{
			this.ReSetState(i, true);
		}
	}

	// Token: 0x060018B2 RID: 6322 RVA: 0x00297F20 File Offset: 0x00296120
	private void ReSerAll(int Index)
	{
		this.ReSetState(Index, true);
		for (int i = 0; i < 3; i++)
		{
			if (i != Index && this.GM.BoxID[i] != 0)
			{
				this.ReSetState(i, false);
			}
		}
	}

	// Token: 0x060018B3 RID: 6323 RVA: 0x00297F68 File Offset: 0x00296168
	private void SetTimeText()
	{
		if (this.tTimeObj == null)
		{
			return;
		}
		if (this.GM.NPCCityBonusTime > 0L)
		{
			if (!this.tTimeObj.gameObject.activeInHierarchy)
			{
				this.tTimeObj.gameObject.SetActive(true);
			}
			long num = this.GM.NPCCityBonusTime - this.DM.ServerTime;
			if (num < 0L)
			{
				num = 0L;
			}
			this.CountTimeStr.Length = 0;
			GameConstants.GetTimeString(this.CountTimeStr, (uint)num, false, true, false, false, true);
			this.CountTimeText.text = this.CountTimeStr.ToString();
			this.CountTimeText.SetAllDirty();
			this.CountTimeText.cachedTextGenerator.Invalidate();
		}
		else if (this.tTimeObj.gameObject.activeInHierarchy)
		{
			this.tTimeObj.gameObject.SetActive(false);
		}
	}

	// Token: 0x060018B4 RID: 6324 RVA: 0x0029805C File Offset: 0x0029625C
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		if (uibutton != null)
		{
			if (uibutton.m_BtnID1 == 4 && uibutton.m_BtnID2 == 2)
			{
				this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 277f, 20, (int)sender.Parm1, 0, new Vector2(130f, 0f), UIButtonHint.ePosition.Original);
			}
			else if (uibutton.m_BtnID1 == 5 && uibutton.m_BtnID2 == 1)
			{
				this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 277f, 20, (int)sender.Parm1, 0, new Vector2(180f, 60f), UIButtonHint.ePosition.Original);
			}
			else
			{
				this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 277f, 20, (int)sender.Parm1, 0, Vector2.zero, UIButtonHint.ePosition.Original);
			}
		}
		else
		{
			this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 277f, 20, (int)sender.Parm1, 0, Vector2.zero, UIButtonHint.ePosition.Original);
		}
	}

	// Token: 0x060018B5 RID: 6325 RVA: 0x00298170 File Offset: 0x00296370
	public void OnButtonUp(UIButtonHint sender)
	{
		this.GM.m_Hint.Hide(false);
	}

	// Token: 0x060018B6 RID: 6326 RVA: 0x00298184 File Offset: 0x00296384
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x040048BF RID: 18623
	private const byte ActorMax = 3;

	// Token: 0x040048C0 RID: 18624
	public Transform m_transform;

	// Token: 0x040048C1 RID: 18625
	public Transform tFront1;

	// Token: 0x040048C2 RID: 18626
	public Transform tFront2;

	// Token: 0x040048C3 RID: 18627
	public Transform tTimeObj;

	// Token: 0x040048C4 RID: 18628
	private Transform[] ActorT = new Transform[3];

	// Token: 0x040048C5 RID: 18629
	public Transform[] WPT = new Transform[3];

	// Token: 0x040048C6 RID: 18630
	private GameObject[] EffectObj = new GameObject[3];

	// Token: 0x040048C7 RID: 18631
	private GameObject EffectObj1;

	// Token: 0x040048C8 RID: 18632
	private GameObject EffectObj2;

	// Token: 0x040048C9 RID: 18633
	private GameObject EffectObj3;

	// Token: 0x040048CA RID: 18634
	private DataManager DM;

	// Token: 0x040048CB RID: 18635
	private GUIManager GM;

	// Token: 0x040048CC RID: 18636
	private Font tmpFont;

	// Token: 0x040048CD RID: 18637
	private Door m_door;

	// Token: 0x040048CE RID: 18638
	private int IngEffectIndex = -1;

	// Token: 0x040048CF RID: 18639
	private byte tFState;

	// Token: 0x040048D0 RID: 18640
	private byte NowIndex;

	// Token: 0x040048D1 RID: 18641
	private float CheckTime;

	// Token: 0x040048D2 RID: 18642
	private int ScaleRate = 800;

	// Token: 0x040048D3 RID: 18643
	private int AssetKey;

	// Token: 0x040048D4 RID: 18644
	private GameObject[] BoxGO = new GameObject[3];

	// Token: 0x040048D5 RID: 18645
	private AssetBundle AB;

	// Token: 0x040048D6 RID: 18646
	private AssetBundleRequest AR;

	// Token: 0x040048D7 RID: 18647
	private bool bABInitial;

	// Token: 0x040048D8 RID: 18648
	private Animation[] tmpAN = new Animation[3];

	// Token: 0x040048D9 RID: 18649
	private BoxUnitComp[] Box = new BoxUnitComp[3];

	// Token: 0x040048DA RID: 18650
	private List<UIText> AllText = new List<UIText>();

	// Token: 0x040048DB RID: 18651
	private UIText DontHaveText;

	// Token: 0x040048DC RID: 18652
	private UIText Front_TitleText;

	// Token: 0x040048DD RID: 18653
	private UIText Front_CheckText;

	// Token: 0x040048DE RID: 18654
	private UIText Front_TotalTimeText;

	// Token: 0x040048DF RID: 18655
	private UIText Front_OpenTimeText;

	// Token: 0x040048E0 RID: 18656
	private UIText Front_MessageText;

	// Token: 0x040048E1 RID: 18657
	private UIText Front_ItemNameText;

	// Token: 0x040048E2 RID: 18658
	private UIText Front_ItemCountText;

	// Token: 0x040048E3 RID: 18659
	private UIText CountTimeText;

	// Token: 0x040048E4 RID: 18660
	private UIButton Front_HINTBtn;

	// Token: 0x040048E5 RID: 18661
	private CString Front_ItemCountStr;

	// Token: 0x040048E6 RID: 18662
	private CString CountTimeStr;

	// Token: 0x040048E7 RID: 18663
	private byte Open_Close;

	// Token: 0x040048E8 RID: 18664
	private int WaitIndex = -1;

	// Token: 0x040048E9 RID: 18665
	private float CloseTime;

	// Token: 0x040048EA RID: 18666
	private float WaitTime;

	// Token: 0x040048EB RID: 18667
	private float WaitPlaySFX = -1f;

	// Token: 0x040048EC RID: 18668
	private float ClosePreTime = 0.55f;
}
