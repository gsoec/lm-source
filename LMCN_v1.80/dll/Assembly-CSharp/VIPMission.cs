using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200042A RID: 1066
public class VIPMission : iMissionAnimNotify, IUIButtonClickHandler
{
	// Token: 0x060015A0 RID: 5536 RVA: 0x0024E404 File Offset: 0x0024C604
	public VIPMission(Transform transform, _MissionTimeBar timebar)
	{
		this.transform = transform;
		this.TimeBar = timebar;
		this.TimeBar.transform.SetParent(transform.GetChild(1));
	}

	// Token: 0x060015A1 RID: 5537 RVA: 0x0024E49C File Offset: 0x0024C69C
	public void Init()
	{
		DataManager instance = DataManager.Instance;
		this.ResetTimeStr = StringManager.Instance.SpawnString(100);
		this.TitleObject = this.transform.GetChild(0).gameObject;
		UIText component = this.transform.GetChild(0).GetChild(1).GetComponent<UIText>();
		component.text = instance.mStringTable.GetStringByID(1530u);
		this.AddRefreshText(component);
		component = this.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = instance.mStringTable.GetStringByID(323u);
		this.AddRefreshText(component);
		component = this.transform.GetChild(10).GetChild(0).GetComponent<UIText>();
		this.ResetTimeStr.ClearString();
		DateTime dateTime = GameConstants.GetDateTime(DataManager.Instance.RoleAttr.FirstTimer);
		this.ResetTimeStr.IntToFormat((long)dateTime.Hour, 2, false);
		this.ResetTimeStr.IntToFormat((long)dateTime.Minute, 2, false);
		this.ResetTimeStr.AppendFormat(instance.mStringTable.GetStringByID(753u));
		component.text = this.ResetTimeStr.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		this.AddRefreshText(component);
		this.CompleteBarTrans = this.TimeBar.transform.GetChild(0).GetChild(0).GetChild(0);
		component = this.CompleteBarTrans.GetChild(0).GetComponent<UIText>();
		component.text = instance.mStringTable.GetStringByID(7949u);
		this.AddRefreshText(component);
		if (GUIManager.Instance.IsArabic)
		{
			this.transform.GetChild(1).GetChild(0).GetChild(1).localScale = new Vector3(-1f, 1f, 1f);
		}
		this.SpeedupBtnObj = this.transform.GetChild(1).GetChild(0).GetChild(1).gameObject;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.AppendFormat("Role/RewardBtn");
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.TreasureassetKey);
		this.Treasure = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject);
		GUIManager.Instance.SetLayer(this.Treasure, 5);
		Vector3 eulerAngles = new Vector3(23.5f, 152.5f, 350.6f);
		this.TreasureBox[0] = new VIPMission._TreasureBox(this.Treasure.transform);
		this.TreasureBox[0].transform.SetParent(this.transform.GetChild(3));
		this.TreasureBox[0].transform.localScale = Vector3.one * 300f;
		this.TreasureBox[0].NotifyHandle = this;
		Quaternion localRotation = this.TreasureBox[0].transform.localRotation;
		localRotation.eulerAngles = eulerAngles;
		this.TreasureBox[0].transform.localRotation = localRotation;
		this.TreasureBox[0].transform.localPosition = Vector3.zero;
		this.RewardBtn[0] = this.transform.GetChild(3).GetChild(0).GetComponent<UIButton>();
		this.RewardBtn[0].m_Handler = this;
		this.RestrictStr[0] = StringManager.Instance.SpawnString(30);
		this.RestrictStr[0].IntToFormat((long)DataManager.MissionDataManager.VipLvRestrict[0], 1, false);
		this.RestrictStr[0].AppendFormat(instance.mStringTable.GetStringByID(7951u));
		this.Restrict[0] = this.transform.GetChild(3).GetChild(1);
		component = this.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = this.RestrictStr[0].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		this.AddRefreshText(component);
		for (int i = 1; i < this.TreasureBox.Length; i++)
		{
			this.TreasureBox[i] = new VIPMission._TreasureBox((UnityEngine.Object.Instantiate(this.Treasure) as GameObject).transform);
			this.TreasureBox[i].transform.SetParent(this.transform.GetChild(3 + i));
			this.TreasureBox[i].transform.localScale = this.TreasureBox[0].transform.localScale;
			this.TreasureBox[i].transform.localPosition = this.TreasureBox[0].transform.localPosition;
			this.TreasureBox[i].transform.localRotation = this.TreasureBox[0].transform.localRotation;
			this.TreasureBox[i].NotifyHandle = this;
			this.RestrictStr[i] = StringManager.Instance.SpawnString(30);
			this.RestrictStr[i].IntToFormat((long)DataManager.MissionDataManager.VipLvRestrict[i], 1, false);
			this.RestrictStr[i].AppendFormat(instance.mStringTable.GetStringByID(7951u));
			this.Restrict[i] = this.transform.GetChild(3 + i).GetChild(1);
			this.RewardBtn[i] = this.transform.GetChild(3 + i).GetChild(0).GetComponent<UIButton>();
			this.RewardBtn[i].m_Handler = this;
			this.RewardBtn[i].m_BtnID1 = i;
			component = this.transform.GetChild(3 + i).GetChild(1).GetChild(0).GetComponent<UIText>();
			component.text = this.RestrictStr[i].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.AddRefreshText(component);
		}
		DataManager.MissionDataManager.UpdateUIBox = 0;
		this.TreasureBox[6].transform.parent.gameObject.SetActive(false);
		this.PrictTrans = this.transform.GetChild(2);
		this.PriceCont = this.transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<RectTransform>();
		this.PriceScroll = this.transform.GetChild(2).GetChild(2).GetComponent<CScrollRect>();
		UIButtonHint.scrollRect = this.PriceScroll;
		GUIManager instance2 = GUIManager.Instance;
		for (byte b = 0; b < 8; b += 1)
		{
			instance2.InitianHeroItemImg(this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b), eHeroOrItem.Item, 0, 0, 0, 0, true, true, true, false);
			this.AddRefreshText(this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b).GetChild(4).GetComponent<UIText>());
		}
		this.ScreenSize = instance2.m_UICanvas.GetComponent<RectTransform>().sizeDelta;
		this.ScrollContWidth = this.PriceCont.sizeDelta.x;
		this.ScrollPricePos = this.PriceCont.anchoredPosition;
		this.ResetTitleTrans = this.transform.GetChild(10);
		Camera.main.cullingMask |= 1 << LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer);
		this.UpdateUI();
		if (GUIManager.Instance.IsArabic)
		{
			Transform child = this.transform.GetChild(11);
			localRotation = child.localRotation;
			localRotation.eulerAngles = new Vector3(9.501f, 20.636f, 142.35f);
			child.localRotation = localRotation;
		}
	}

	// Token: 0x060015A2 RID: 5538 RVA: 0x0024EC40 File Offset: 0x0024CE40
	public void InitPrice()
	{
		DataManager instance = DataManager.Instance;
		byte b = 0;
		ushort[] vipRewardItem = DataManager.MissionDataManager.VipRewardItem;
		for (int i = 0; i < vipRewardItem.Length; i++)
		{
			if (vipRewardItem[i] == 0)
			{
				break;
			}
			Equip recordByKey = instance.EquipTable.GetRecordByKey(vipRewardItem[i]);
			b += 1;
			if (!GUIManager.Instance.IsLeadItem(recordByKey.EquipKind))
			{
				if (i < this.PriceCont.GetChild(0).GetChild(0).childCount)
				{
					GUIManager.Instance.ChangeHeroItemImg(this.PriceCont.GetChild(0).GetChild(0).GetChild(i), eHeroOrItem.Item, vipRewardItem[i], 0, 0, 0);
					this.PriceCont.GetChild(0).GetChild(0).GetChild(i).gameObject.SetActive(true);
				}
				else
				{
					RectTransform rectTransform = UnityEngine.Object.Instantiate(this.PriceCont.GetChild(0).GetChild(0).GetChild(0)) as RectTransform;
					rectTransform.SetParent(this.PriceCont.GetChild(0).GetChild(0));
					rectTransform.anchoredPosition3D = new Vector3(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y, 0f);
					Quaternion localRotation = rectTransform.localRotation;
					localRotation.eulerAngles = Vector3.zero;
					rectTransform.localRotation = localRotation;
					rectTransform.localScale = Vector3.one;
					rectTransform.anchoredPosition = new Vector2((float)(7 + 93 * i), 0f);
					rectTransform.gameObject.SetActive(true);
					GUIManager.Instance.ChangeHeroItemImg(rectTransform, eHeroOrItem.Item, vipRewardItem[i], 0, 0, 0);
					this.AddRefreshText(rectTransform.GetChild(4).GetComponent<UIText>());
				}
			}
		}
		if (this.PriceCont.GetChild(0).GetChild(0).childCount > (int)b)
		{
			for (int j = (int)b; j < this.PriceCont.GetChild(0).GetChild(0).childCount; j++)
			{
				this.PriceCont.GetChild(0).GetChild(0).GetChild(j).gameObject.SetActive(false);
			}
		}
		float num = 7f + 93f * (float)b;
		this.PriceCont.anchoredPosition = this.ScrollPricePos;
		if (this.ScrollContWidth < num)
		{
			Vector2 sizeDelta = this.PriceCont.sizeDelta;
			sizeDelta.x = num + 4f;
			this.PriceCont.sizeDelta = sizeDelta;
			this.PriceScroll.enabled = true;
		}
		else
		{
			this.PriceScroll.enabled = false;
		}
	}

	// Token: 0x060015A3 RID: 5539 RVA: 0x0024EEE8 File Offset: 0x0024D0E8
	public void SetAchieve(bool active)
	{
		if (active)
		{
			DataManager.msgBuffer[0] = 84;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			GUIManager.Instance.m_UICanvas.renderMode = RenderMode.ScreenSpaceCamera;
			GUIManager.Instance.SetCanvasChanged();
			if (this.Treasure != null)
			{
				for (int i = 0; i < this.TreasureBox.Length; i++)
				{
					this.TreasureBox[i].PlayAnimation();
				}
				this.UpdateUI();
			}
		}
		else
		{
			ushort[] vipRewardItem = DataManager.MissionDataManager.VipRewardItem;
			Array.Clear(vipRewardItem, 0, vipRewardItem.Length);
			SpeciallyEffect_Kind[] vipRewardKind = DataManager.MissionDataManager.VipRewardKind;
			Array.Clear(vipRewardKind, 0, vipRewardKind.Length);
			GUIManager.Instance.m_SpeciallyEffect.ClearAllEffect();
			DataManager.msgBuffer[0] = 84;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			GUIManager.Instance.m_UICanvas.renderMode = RenderMode.ScreenSpaceOverlay;
			GUIManager.Instance.SetCanvasChanged();
			for (int j = 0; j < this.TreasureBox.Length; j++)
			{
				this.TreasureBox[j].StopAnimation();
			}
			this.ThrowEffectCount = 0;
		}
		if (this.Treasure == null)
		{
			this.Init();
			this.UpdateUI();
		}
		this.transform.gameObject.SetActive(active);
	}

	// Token: 0x060015A4 RID: 5540 RVA: 0x0024F030 File Offset: 0x0024D230
	public void UpdateUI()
	{
		MissionManager missionDataManager = DataManager.MissionDataManager;
		DataManager instance = DataManager.Instance;
		_ROLEINFO roleAttr = DataManager.Instance.RoleAttr;
		bool flag = true;
		if ((missionDataManager.MissionNotice >> 3 & 1) == 0)
		{
			flag = false;
		}
		if (missionDataManager.HaveEmptyBox())
		{
			this.TitleObject.SetActive(true);
			this.TimeBar.transform.gameObject.SetActive(true);
			GUIManager.Instance.SetTimerBar(this.TimeBar.TimeBar, missionDataManager.VipRewardStartTime, missionDataManager.VipRewardStartTime + 3600L, 0L, eTimeBarType.UIMission, this.TimeBar.TimeBar.m_Titles[0], this.TimeBar.TimeBar.m_Titles[1]);
		}
		else
		{
			this.TitleObject.SetActive(false);
			this.TimeBar.transform.gameObject.SetActive(false);
		}
		this.CompleteBarTrans.gameObject.SetActive(flag);
		if (missionDataManager.VipRewardStartTime + 3600L <= instance.ServerTime)
		{
			this.SpeedupBtnObj.SetActive(false);
		}
		else
		{
			this.SpeedupBtnObj.SetActive(true);
		}
		this.TimeBar.TimeBar.m_TimeText.gameObject.SetActive(!flag);
		byte b = missionDataManager.UpdateUIBox;
		this.OpenBoxIdx = byte.MaxValue;
		while (b > 0)
		{
			this.OpenBoxIdx += 1;
			b = (byte)(b >> 1);
		}
		this.PrictTrans.gameObject.SetActive(false);
		this.ResetTitleTrans.gameObject.SetActive(true);
		byte b2 = 0;
		while ((int)b2 < this.TreasureBox.Length - 1)
		{
			if (this.TreasureBox[(int)b2] == null)
			{
				break;
			}
			if (this.TreasureBox[(int)b2].transform.gameObject.activeSelf)
			{
				if (roleAttr.VIPLevel < missionDataManager.VipLvRestrict[(int)b2])
				{
					this.TreasureBox[(int)b2].Light = false;
					this.RewardBtn[(int)b2].enabled = false;
					this.Restrict[(int)b2].gameObject.SetActive(true);
				}
				else
				{
					this.TreasureBox[(int)b2].Light = true;
					this.RewardBtn[(int)b2].enabled = true;
					this.Restrict[(int)b2].gameObject.SetActive(false);
					this.TreasureBox[(int)b2].StopAnimation();
					if (this.OpenBoxIdx == b2)
					{
						this.PrictTrans.gameObject.SetActive(true);
						this.ResetTitleTrans.gameObject.SetActive(false);
						this.InitPrice();
						AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
						this.TreasureBox[(int)b2].PlayAnimation("open", 0f, WrapMode.Once);
						this.TreasureBox[(int)b2].SetNotifyTime(0.15f);
					}
					else if (missionDataManager.GetVipBoxState(b2) == 1)
					{
						this.TreasureBox[(int)b2].PlayAnimation("open", 0f, WrapMode.Once);
						this.TreasureBox[(int)b2].GotoAnimLast();
					}
					else if (flag && this.CompleteBarTrans.gameObject.activeSelf)
					{
						this.TreasureBox[(int)b2].PlayAnimation("idle_02", UnityEngine.Random.value * 0.025f, WrapMode.Loop);
					}
				}
			}
			b2 += 1;
		}
		this.BoxEffectID = (int)(DataManager.MissionDataManager.BoxEffectID - 1);
	}

	// Token: 0x060015A5 RID: 5541 RVA: 0x0024F3A4 File Offset: 0x0024D5A4
	public void AnimNotify()
	{
		if (this.OpenBoxIdx != 255)
		{
			if (this.BoxEffect != null && this.BoxEffect.activeSelf)
			{
				this.BoxEffect.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			}
			if (this.BoxEffectID >= 0 && this.BoxEffectID <= 4)
			{
				this.BoxEffect = ParticleManager.Instance.Spawn((ushort)(373 + this.BoxEffectID), this.TreasureBox[(int)this.OpenBoxIdx].transform, new Vector3(1.1f, 1.35f, 2.28f), 0.5f, true, true, true);
				GUIManager.Instance.SetLayer(this.BoxEffect, 5);
			}
			this.RewardEffPos.Set(this.ScreenSize.x * 0.5f + 8.5f + this.TreasureBox[(int)this.OpenBoxIdx].transform.parent.localPosition.x, 319f + 130f * (float)(this.OpenBoxIdx / 3), -80f);
			this.OpenBoxIdx = byte.MaxValue;
			AudioManager.Instance.PlayMP3SFX(41011, 0f);
		}
	}

	// Token: 0x060015A6 RID: 5542 RVA: 0x0024F4F8 File Offset: 0x0024D6F8
	public void AnimnotifyEnd()
	{
		ushort[] vipRewardItem = DataManager.MissionDataManager.VipRewardItem;
		this.ThrowEffectCount = vipRewardItem.Length / 3 + Mathf.Clamp(vipRewardItem.Length % 3, 0, 1);
		if (this.ThrowEffectCount > 0)
		{
			this.ThrowEffectIdx = 0;
			this.ThrowRewardEffect(this.ThrowEffectIdx++);
			this.EffectTime = 0f;
		}
	}

	// Token: 0x060015A7 RID: 5543 RVA: 0x0024F560 File Offset: 0x0024D760
	private void ThrowRewardEffect(int index)
	{
		GUIManager instance = GUIManager.Instance;
		ushort[] vipRewardItem = DataManager.MissionDataManager.VipRewardItem;
		SpeciallyEffect_Kind[] vipRewardKind = DataManager.MissionDataManager.VipRewardKind;
		Array.Clear(instance.SE_Kind, 0, instance.SE_Kind.Length);
		Array.Clear(instance.SE_ItemID, 0, instance.SE_ItemID.Length);
		instance.m_SpeciallyEffect.mDiamondValue = 0u;
		for (int i = 0; i < instance.SE_ItemID.Length; i++)
		{
			int num = index * 3 + i;
			if (num >= vipRewardItem.Length)
			{
				break;
			}
			if (vipRewardKind[num] == SpeciallyEffect_Kind.Diamond)
			{
				instance.SE_ItemID[i] = 0;
				instance.m_SpeciallyEffect.mDiamondValue = DataManager.MissionDataManager.RewardVipDiamond;
			}
			else if (vipRewardKind[num] == SpeciallyEffect_Kind.AllianceMoney)
			{
				instance.SE_ItemID[i] = 0;
			}
			else
			{
				instance.SE_ItemID[i] = vipRewardItem[num];
			}
			instance.SE_Kind[i] = vipRewardKind[num];
		}
		instance.m_SpeciallyEffect.AddIconShow(this.RewardEffPos, instance.SE_Kind, instance.SE_ItemID, false);
	}

	// Token: 0x060015A8 RID: 5544 RVA: 0x0024F670 File Offset: 0x0024D870
	public void Update()
	{
		for (int i = 0; i < this.TreasureBox.Length; i++)
		{
			if (this.TreasureBox[i] != null)
			{
				this.TreasureBox[i].Update();
			}
		}
		if (this.ThrowEffectIdx < this.ThrowEffectCount)
		{
			if (this.EffectTime >= this.MaxEffectTime)
			{
				this.ThrowRewardEffect(this.ThrowEffectIdx++);
				this.EffectTime = 0f;
			}
			else
			{
				this.EffectTime += this.TimdHandle.GetSmoothDeltaTime();
			}
		}
	}

	// Token: 0x060015A9 RID: 5545 RVA: 0x0024F714 File Offset: 0x0024D914
	public void AddRefreshText(UIText text)
	{
		this.TitleText.Add(text);
	}

	// Token: 0x060015AA RID: 5546 RVA: 0x0024F724 File Offset: 0x0024D924
	public void Destroy()
	{
		if (this.TreasureassetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.TreasureassetKey, true);
		}
		StringManager.Instance.DeSpawnString(this.ResetTimeStr);
		Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer));
		for (int i = 0; i < this.RestrictStr.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.RestrictStr[i]);
		}
		if (this.BoxEffect != null && this.BoxEffect.activeSelf)
		{
			this.BoxEffect.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			this.BoxEffect.transform.localPosition = new Vector3(0f, 0f, -50f);
		}
	}

	// Token: 0x060015AB RID: 5547 RVA: 0x0024F810 File Offset: 0x0024DA10
	public void TextRefresh()
	{
		for (int i = 0; i < this.TitleText.Count; i++)
		{
			if (!(this.TitleText[i] == null))
			{
				this.TitleText[i].enabled = false;
				this.TitleText[i].enabled = true;
			}
		}
	}

	// Token: 0x060015AC RID: 5548 RVA: 0x0024F87C File Offset: 0x0024DA7C
	public void OnButtonClick(UIButton sender)
	{
		if (DataManager.MissionDataManager.GetVipBoxState((byte)sender.m_BtnID1) == 0 && (DataManager.MissionDataManager.MissionNotice >> 3 & 1) > 0)
		{
			DataManager.MissionDataManager.sendReceiveVipBox((byte)sender.m_BtnID1);
		}
	}

	// Token: 0x04003FD5 RID: 16341
	private Transform transform;

	// Token: 0x04003FD6 RID: 16342
	private Transform CompleteBarTrans;

	// Token: 0x04003FD7 RID: 16343
	private Transform PrictTrans;

	// Token: 0x04003FD8 RID: 16344
	private Transform ResetTitleTrans;

	// Token: 0x04003FD9 RID: 16345
	private _MissionTimeBar TimeBar;

	// Token: 0x04003FDA RID: 16346
	private GameObject Treasure;

	// Token: 0x04003FDB RID: 16347
	private GameObject SpeedupBtnObj;

	// Token: 0x04003FDC RID: 16348
	private GameObject BoxEffect;

	// Token: 0x04003FDD RID: 16349
	private GameObject TitleObject;

	// Token: 0x04003FDE RID: 16350
	private int TreasureassetKey;

	// Token: 0x04003FDF RID: 16351
	private List<UIText> TitleText = new List<UIText>();

	// Token: 0x04003FE0 RID: 16352
	private UIButton[] RewardBtn = new UIButton[7];

	// Token: 0x04003FE1 RID: 16353
	private VIPMission._TreasureBox[] TreasureBox = new VIPMission._TreasureBox[7];

	// Token: 0x04003FE2 RID: 16354
	private Transform[] Restrict = new Transform[7];

	// Token: 0x04003FE3 RID: 16355
	private CString ResetTimeStr;

	// Token: 0x04003FE4 RID: 16356
	private CString[] RestrictStr = new CString[7];

	// Token: 0x04003FE5 RID: 16357
	private byte OpenBoxIdx = byte.MaxValue;

	// Token: 0x04003FE6 RID: 16358
	private CScrollRect PriceScroll;

	// Token: 0x04003FE7 RID: 16359
	private RectTransform PriceCont;

	// Token: 0x04003FE8 RID: 16360
	private Vector3 RewardEffPos = default(Vector3);

	// Token: 0x04003FE9 RID: 16361
	private Vector2 ScreenSize;

	// Token: 0x04003FEA RID: 16362
	private Vector2 ScrollPricePos;

	// Token: 0x04003FEB RID: 16363
	private int ThrowEffectCount;

	// Token: 0x04003FEC RID: 16364
	private int ThrowEffectIdx;

	// Token: 0x04003FED RID: 16365
	private int BoxEffectID;

	// Token: 0x04003FEE RID: 16366
	private float EffectTime;

	// Token: 0x04003FEF RID: 16367
	private float MaxEffectTime = 1.5f;

	// Token: 0x04003FF0 RID: 16368
	private float ScrollContWidth;

	// Token: 0x04003FF1 RID: 16369
	public iMissionTimeDelta TimdHandle;

	// Token: 0x0200042B RID: 1067
	public enum UIControl
	{
		// Token: 0x04003FF3 RID: 16371
		Title,
		// Token: 0x04003FF4 RID: 16372
		Timebar,
		// Token: 0x04003FF5 RID: 16373
		Price,
		// Token: 0x04003FF6 RID: 16374
		Box1,
		// Token: 0x04003FF7 RID: 16375
		Box2,
		// Token: 0x04003FF8 RID: 16376
		Box3,
		// Token: 0x04003FF9 RID: 16377
		Box4,
		// Token: 0x04003FFA RID: 16378
		Box5,
		// Token: 0x04003FFB RID: 16379
		Box6,
		// Token: 0x04003FFC RID: 16380
		Box7,
		// Token: 0x04003FFD RID: 16381
		ResetTitle,
		// Token: 0x04003FFE RID: 16382
		Light
	}

	// Token: 0x0200042C RID: 1068
	private class _TreasureBox
	{
		// Token: 0x060015AD RID: 5549 RVA: 0x0024F8BC File Offset: 0x0024DABC
		public _TreasureBox(Transform transform)
		{
			this.transform = transform;
			this._Animation = transform.GetComponent<Animation>();
			this._Animation.wrapMode = WrapMode.Loop;
			this._Animation.playAutomatically = false;
			this.Render = transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
			this.Render.useLightProbes = false;
		}

		// Token: 0x1700009F RID: 159
		// (set) Token: 0x060015AE RID: 5550 RVA: 0x0024F920 File Offset: 0x0024DB20
		public bool Light
		{
			set
			{
				if (!value)
				{
					if (this.transform.gameObject.layer != LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer))
					{
						GUIManager.Instance.SetLayer(this.transform.gameObject, LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer));
					}
				}
				else if (this.transform.gameObject.layer != 5)
				{
					GUIManager.Instance.SetLayer(this.transform.gameObject, 5);
				}
			}
		}

		// Token: 0x060015AF RID: 5551 RVA: 0x0024F9A4 File Offset: 0x0024DBA4
		public void PlayAnimation(string animation, float delay = 0f, WrapMode Mode = WrapMode.Loop)
		{
			this.AnimationName = animation;
			if (delay == 0f)
			{
				this._Animation.Play(this.AnimationName);
			}
			else
			{
				this.DelayTime = delay;
			}
			this.bStop = 0;
			this._Animation.wrapMode = Mode;
		}

		// Token: 0x060015B0 RID: 5552 RVA: 0x0024F9F4 File Offset: 0x0024DBF4
		public void SetNotifyTime(float NormalizedTime)
		{
			this.NormalizedTime = NormalizedTime;
			this.NotifyFlag = VIPMission._TreasureBox.eNotyfy.None;
		}

		// Token: 0x060015B1 RID: 5553 RVA: 0x0024FA04 File Offset: 0x0024DC04
		public void PlayAnimation()
		{
			this.bStop = 0;
			this.DeltaTime = 0f;
		}

		// Token: 0x060015B2 RID: 5554 RVA: 0x0024FA18 File Offset: 0x0024DC18
		public bool IsPlaying()
		{
			return this.AnimationName != null && this._Animation.IsPlaying(this.AnimationName);
		}

		// Token: 0x060015B3 RID: 5555 RVA: 0x0024FA38 File Offset: 0x0024DC38
		public void StopAnimation()
		{
			if (this.AnimationName == null)
			{
				return;
			}
			if (this._Animation.IsPlaying(this.AnimationName))
			{
				this._Animation[this.AnimationName].normalizedTime = 0f;
				this._Animation.Sample();
				this._Animation.Stop();
			}
			this.bStop = 1;
		}

		// Token: 0x060015B4 RID: 5556 RVA: 0x0024FAA0 File Offset: 0x0024DCA0
		public void GotoAnimLast()
		{
			if (this.AnimationName == null)
			{
				return;
			}
			if (this._Animation.IsPlaying(this.AnimationName))
			{
				this._Animation[this.AnimationName].normalizedTime = this._Animation[this.AnimationName].length;
				this._Animation.Sample();
				this._Animation.Stop();
			}
		}

		// Token: 0x060015B5 RID: 5557 RVA: 0x0024FB14 File Offset: 0x0024DD14
		public void Update()
		{
			if (!this.transform.gameObject.activeSelf || this.bStop == 1 || this.AnimationName == null)
			{
				return;
			}
			if (this.DelayTime > this.DeltaTime)
			{
				this.DeltaTime += Time.deltaTime;
			}
			else if (this._Animation.wrapMode == WrapMode.Loop && !this._Animation.IsPlaying(this.AnimationName))
			{
				this._Animation.clip = this._Animation.GetClip(this.AnimationName);
				this._Animation.Play(this.AnimationName);
			}
			if (this.NotifyHandle != null && this.NotifyFlag != VIPMission._TreasureBox.eNotyfy.All)
			{
				if ((byte)(this.NotifyFlag & VIPMission._TreasureBox.eNotyfy.AnimNotyfy) == 0 && this._Animation[this.AnimationName].normalizedTime >= this.NormalizedTime)
				{
					this.NotifyHandle.AnimNotify();
					this.NotifyFlag |= VIPMission._TreasureBox.eNotyfy.AnimNotyfy;
				}
				if ((byte)(this.NotifyFlag & VIPMission._TreasureBox.eNotyfy.AnimEnd) == 0 && !this._Animation.IsPlaying(this.AnimationName))
				{
					this.NotifyHandle.AnimnotifyEnd();
					this.NotifyFlag |= VIPMission._TreasureBox.eNotyfy.AnimEnd;
				}
			}
		}

		// Token: 0x04003FFF RID: 16383
		public Transform transform;

		// Token: 0x04004000 RID: 16384
		private SkinnedMeshRenderer Render;

		// Token: 0x04004001 RID: 16385
		private Animation _Animation;

		// Token: 0x04004002 RID: 16386
		private float DelayTime;

		// Token: 0x04004003 RID: 16387
		private float DeltaTime;

		// Token: 0x04004004 RID: 16388
		private float NormalizedTime;

		// Token: 0x04004005 RID: 16389
		private string AnimationName;

		// Token: 0x04004006 RID: 16390
		public iMissionAnimNotify NotifyHandle;

		// Token: 0x04004007 RID: 16391
		private VIPMission._TreasureBox.eNotyfy NotifyFlag = VIPMission._TreasureBox.eNotyfy.All;

		// Token: 0x04004008 RID: 16392
		private byte bStop;

		// Token: 0x0200042D RID: 1069
		private enum eNotyfy : byte
		{
			// Token: 0x0400400A RID: 16394
			None,
			// Token: 0x0400400B RID: 16395
			AnimNotyfy,
			// Token: 0x0400400C RID: 16396
			AnimEnd,
			// Token: 0x0400400D RID: 16397
			All
		}
	}
}
