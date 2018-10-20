using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

// Token: 0x02000772 RID: 1906
public class MallManager
{
	// Token: 0x060024E7 RID: 9447 RVA: 0x00424890 File Offset: 0x00422A90
	private MallManager()
	{
		this._SmallID = this.TreasureIDTransToNew(this._SmallID);
		this.LoadShowEffect();
	}

	// Token: 0x170000F2 RID: 242
	// (get) Token: 0x060024E8 RID: 9448 RVA: 0x0042518C File Offset: 0x0042338C
	public static MallManager Instance
	{
		get
		{
			if (MallManager.instance == null)
			{
				MallManager.instance = new MallManager();
			}
			return MallManager.instance;
		}
	}

	// Token: 0x170000F3 RID: 243
	// (get) Token: 0x060024E9 RID: 9449 RVA: 0x004251A8 File Offset: 0x004233A8
	// (set) Token: 0x060024EA RID: 9450 RVA: 0x004251D8 File Offset: 0x004233D8
	public Door door
	{
		get
		{
			if (this.m_door == null)
			{
				this.m_door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
			}
			return this.m_door;
		}
		set
		{
			this.m_door = value;
		}
	}

	// Token: 0x170000F4 RID: 244
	// (get) Token: 0x060024EB RID: 9451 RVA: 0x004251E4 File Offset: 0x004233E4
	public uint SmallID
	{
		get
		{
			if (MerchantmanManager.Instance.ExtraTreasureID != 0u)
			{
				return MerchantmanManager.Instance.ExtraTreasureID;
			}
			return this._SmallID;
		}
	}

	// Token: 0x060024EC RID: 9452 RVA: 0x00425214 File Offset: 0x00423414
	~MallManager()
	{
	}

	// Token: 0x060024ED RID: 9453 RVA: 0x0042524C File Offset: 0x0042344C
	public void UnloadAsset()
	{
		for (int i = 0; i < this.MallDataList.Count; i++)
		{
			this.MallDataList[i].UnloadAB(true);
		}
		this.MallDataList.Clear();
		this.MainData = null;
		this.bNeedUpDateItemPtice = false;
		this.m_MallItemPrice.Clear();
		if (this.Default_AssetBundleKey != 0)
		{
			this.Default_Material = null;
			this.Default_MainMenuSprite = null;
			AssetManager.UnloadAssetBundle(this.Default_AssetBundleKey, true);
			this.Default_AssetBundle = null;
			this.Default_AssetBundleKey = 0;
		}
		this.UnLoadMainPackage();
		this.LastServerTime = 0L;
		this.bAskListData = false;
		this.bRcvMainData = false;
		this.bCanOpenMain = false;
		this.bLoginFinish = false;
		this.AutoMall = false;
		this.AutoDetailSN = 0;
		this.bAutoOpenMain = false;
		this.bSendMallInfo = false;
		this.bNewbie = false;
		this.MallUIIndex = -1;
		this.MallUIPos = -1f;
		this.ForgeIndex = -1;
		this.bFirstArrow = true;
		this.SendBuySN = 0;
		this.SendCheckBuySN = 0u;
		this.bLockBuy = false;
		this.AskForgeCount = 0;
		this.NeedFindFrogeIndex = -1;
		this.ClearFullGift();
	}

	// Token: 0x060024EE RID: 9454 RVA: 0x00425374 File Offset: 0x00423574
	public MallDataType FindDataBySN(ushort SN)
	{
		int num = 0;
		if (this.MallMap_SN.TryGetValue(SN, out num) && num < this.MallDataList.Count)
		{
			return this.MallDataList[num];
		}
		return null;
	}

	// Token: 0x060024EF RID: 9455 RVA: 0x004253B8 File Offset: 0x004235B8
	public int FindIndexBySN(ushort SN)
	{
		int num = -1;
		if (this.MallMap_SN.TryGetValue(SN, out num) && num < this.MallDataList.Count)
		{
			return num;
		}
		return -1;
	}

	// Token: 0x060024F0 RID: 9456 RVA: 0x004253F0 File Offset: 0x004235F0
	public MallDataType FindDataByGID(ushort GroupID)
	{
		int num = 0;
		if (this.MallMap_GID.TryGetValue(GroupID, out num) && num < this.MallDataList.Count)
		{
			return this.MallDataList[num];
		}
		return null;
	}

	// Token: 0x060024F1 RID: 9457 RVA: 0x00425434 File Offset: 0x00423634
	public int FindIndexByGID(ushort GroupID)
	{
		int num = -1;
		if (this.MallMap_GID.TryGetValue(GroupID, out num) && num < this.MallDataList.Count)
		{
			return num;
		}
		return -1;
	}

	// Token: 0x060024F2 RID: 9458 RVA: 0x0042546C File Offset: 0x0042366C
	public int RemoveDataByGID(ushort GroupID)
	{
		int num = 0;
		if (this.MallMap_GID.TryGetValue(GroupID, out num) && num < this.MallDataList.Count)
		{
			if (this.MainData != null && this.door != null && this.MallDataList[num].SN == this.MainData.SN)
			{
				this.SetDefaultPackage();
			}
			this.MallDataList[num].UnloadAB(false);
			this.MallDataList.RemoveAt(num);
			return num;
		}
		return -1;
	}

	// Token: 0x060024F3 RID: 9459 RVA: 0x00425504 File Offset: 0x00423704
	public void SortMallData()
	{
		this.CheckNewBie();
		this.MallDataList.Sort(this.DataComparer);
		int i = 0;
		while (i < this.MallDataList.Count)
		{
			if (this.MallDataList[i].Type == ETreasureType.ETST_Month)
			{
				if (i == 1)
				{
					break;
				}
				if (i + 1 < this.MallDataList.Count && this.MallDataList[i + 1].Type == ETreasureType.ETST_Crystal)
				{
					break;
				}
				MallDataType item = this.MallDataList[i];
				this.MallDataList.RemoveAt(i);
				this.MallDataList.Insert(1, item);
				break;
			}
			else
			{
				i++;
			}
		}
		this.MallMap_SN.Clear();
		this.MallMap_GID.Clear();
		ushort num = 0;
		while ((int)num < this.MallDataList.Count)
		{
			if (!this.MallMap_SN.ContainsKey(this.MallDataList[(int)num].SN))
			{
				this.MallMap_SN.Add(this.MallDataList[(int)num].SN, (int)num);
			}
			if (!this.MallMap_GID.ContainsKey(this.MallDataList[(int)num].GroupID))
			{
				this.MallMap_GID.Add(this.MallDataList[(int)num].GroupID, (int)num);
			}
			num += 1;
		}
	}

	// Token: 0x060024F4 RID: 9460 RVA: 0x00425674 File Offset: 0x00423874
	private void CheckNewBie()
	{
		this.bNewbie = (DataManager.Instance.ServerTime - DataManager.Instance.RoleAttr.FirstTimer <= 432000L);
	}

	// Token: 0x060024F5 RID: 9461 RVA: 0x004256A4 File Offset: 0x004238A4
	public void ChaekMainPackage()
	{
		int index = 0;
		this.SetDefaultPackage();
		if (this.MallDataList.Count > 0)
		{
			this.MainData = this.MallDataList[index];
			if (this.MainData.Type == ETreasureType.ETST_Crystal)
			{
				this.bCanOpenMain = true;
			}
			else
			{
				this.MainData.SendAskDownLoad();
				this.bRcvMainData = false;
			}
		}
		else
		{
			this.MainData = null;
		}
		this.CheckHaveLevelUpPack();
		this.SetMainTime(true);
	}

	// Token: 0x060024F6 RID: 9462 RVA: 0x00425724 File Offset: 0x00423924
	public void CalculateTime(int Index)
	{
		if (Index < 0 || Index >= this.MallDataList.Count)
		{
			return;
		}
		if (this.MallDataList[Index].EndTime == 0L)
		{
			this.MallDataList[Index].uTime = 0u;
			return;
		}
		uint num;
		if (this.MallDataList[Index].EndTime <= DataManager.Instance.ServerTime)
		{
			num = 0u;
		}
		else
		{
			num = (uint)(this.MallDataList[Index].EndTime - DataManager.Instance.ServerTime);
			if (this.MallDataList[Index].Type != ETreasureType.ETST_SHLevelUp && num > 3300u)
			{
				num = (num + 300u) % 3600u;
			}
		}
		this.MallDataList[Index].uTime = num;
		if (this.MallDataList[Index].Type == ETreasureType.ETST_SHLevelUp)
		{
			this.SetMainTime(false);
		}
	}

	// Token: 0x060024F7 RID: 9463 RVA: 0x0042581C File Offset: 0x00423A1C
	public void Update()
	{
		bool flag = DataManager.Instance.ServerTime != this.LastServerTime;
		if (flag)
		{
			this.LastServerTime = DataManager.Instance.ServerTime;
			this.UpdateMall();
		}
		if (this.mMonthTreasure_CDTime > 0f)
		{
			this.mMonthTreasure_CDTime -= Time.unscaledDeltaTime;
			if (this.mShowSec == 1 && this.mMonthTreasure_CDTime <= 1.5f)
			{
				this.mShowSec = 2;
				GUIManager guimanager = GUIManager.Instance;
				Array.Clear(guimanager.SE_Kind, 0, guimanager.SE_Kind.Length);
				Array.Clear(guimanager.m_SpeciallyEffect.mResValue, 0, guimanager.m_SpeciallyEffect.mResValue.Length);
				Array.Clear(guimanager.SE_ItemID, 0, guimanager.SE_ItemID.Length);
				for (int i = 0; i < 3; i++)
				{
					guimanager.SE_ItemID[i] = this.mMonthTreasureItem[3 + i].ItemID;
				}
				guimanager.mStartV2 = new Vector2(guimanager.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, guimanager.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
				guimanager.m_SpeciallyEffect.AddIconShow(guimanager.mStartV2, guimanager.SE_Kind, guimanager.SE_ItemID, true);
			}
			else if (this.mShowSec == 2 && this.mMonthTreasure_CDTime <= 0f && this.mMonthTreasureItem[6].ItemID != 0)
			{
				this.mShowSec = 0;
				GUIManager guimanager2 = GUIManager.Instance;
				Array.Clear(guimanager2.SE_Kind, 0, guimanager2.SE_Kind.Length);
				Array.Clear(guimanager2.m_SpeciallyEffect.mResValue, 0, guimanager2.m_SpeciallyEffect.mResValue.Length);
				Array.Clear(guimanager2.SE_ItemID, 0, guimanager2.SE_ItemID.Length);
				guimanager2.SE_ItemID[0] = this.mMonthTreasureItem[6].ItemID;
				guimanager2.mStartV2 = new Vector2(guimanager2.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, guimanager2.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
				guimanager2.m_SpeciallyEffect.AddIconShow(guimanager2.mStartV2, guimanager2.SE_Kind, guimanager2.SE_ItemID, true);
			}
		}
		if (this.bLoginFinish)
		{
			if (this.bSendMallInfo)
			{
				this.bSendMallInfo = false;
				this.Send_Mall_Info();
			}
			if (this.AutoMall)
			{
				this.AutoMall = false;
				this.Send_Mall_Info();
			}
		}
		if (this.bLoginFinish && this.door)
		{
			this.CheckOpenPUSHBACK_PRIZE();
			if (!this.bCanOpenMain)
			{
				bool flag2 = true;
				if (IGGGameSDK.Instance.IGGIdIsReady)
				{
					flag2 = IGGGameSDK.Instance.bPaymentReady;
				}
				bool flag3 = this.MainData != null && this.MainData.bDownLoadPic && this.MainData.bDownLoadStr;
				if (flag2 && this.bRcvMainData && flag3)
				{
					this.bCanOpenMain = true;
					if (!NewbieManager.IsWorking())
					{
						GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_Mall, 1, 0, true, 2);
					}
				}
			}
		}
	}

	// Token: 0x060024F8 RID: 9464 RVA: 0x00425B74 File Offset: 0x00423D74
	public void UpdateMall()
	{
		if (this.MallDataList.Count > 0)
		{
			for (int i = 0; i < this.MallDataList.Count; i++)
			{
				this.CalculateTime(i);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 0, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 0, 0);
		}
		if (this.FullGift_Deadline > 0L)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_FG, 0, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_FG_Detail, 0, 0);
		}
	}

	// Token: 0x060024F9 RID: 9465 RVA: 0x00425C00 File Offset: 0x00423E00
	public void UpDateDownLoad(byte[] meg)
	{
		if (meg[1] != 2)
		{
			return;
		}
		byte b = meg[2];
		ushort num = GameConstants.ConvertBytesToUShort(meg, 3);
		if (meg[5] == 1)
		{
			if (b == 0)
			{
				AssetManager.RequestMallBundle(num, true);
			}
			else
			{
				AssetManager.RequestMallPackage(num, true);
			}
			return;
		}
		if (meg[5] == 2)
		{
			return;
		}
		if (b == 0)
		{
			if (num >= 1 && num <= 1000)
			{
				for (int i = 0; i < this.MallDataList.Count; i++)
				{
					if (this.MallDataList[i].PicPackageID1 == num)
					{
						if (this.MallDataList[i].bDownLoadPic)
						{
							this.MallDataList[i].bUpDatePic = true;
						}
						else
						{
							this.MallDataList[i].bDownLoadPic = true;
						}
					}
				}
			}
			else if (num >= 1001 && num <= 2000 && this.MainData != null && this.MainData.PicPackageID2 + 1000 == num)
			{
				this.LoadMainPackege(num);
				this.SetMainPackage();
			}
		}
		else
		{
			for (int j = 0; j < this.MallDataList.Count; j++)
			{
				if (this.MallDataList[j].StrPackageID == num)
				{
					if (this.MallDataList[j].bDownLoadStr)
					{
						this.MallDataList[j].bUpDateStr = true;
					}
					else
					{
						this.MallDataList[j].bDownLoadStr = true;
					}
				}
			}
		}
		this.CheckOpenMain();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 5, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 5, 0);
	}

	// Token: 0x060024FA RID: 9466 RVA: 0x00425DC0 File Offset: 0x00423FC0
	public void CheckOpenMain()
	{
		if (this.MainData != null && !this.bRcvMainData && this.MainData.bDownLoadPic && this.MainData.bDownLoadStr)
		{
			this.bRcvMainData = true;
		}
	}

	// Token: 0x060024FB RID: 9467 RVA: 0x00425E00 File Offset: 0x00424000
	public string GetItemRankName(byte ItemRank)
	{
		switch (ItemRank)
		{
		case 1:
			return DataManager.Instance.mStringTable.GetStringByID(7733u);
		case 2:
			return DataManager.Instance.mStringTable.GetStringByID(7734u);
		case 3:
			return DataManager.Instance.mStringTable.GetStringByID(7735u);
		case 4:
			return DataManager.Instance.mStringTable.GetStringByID(7736u);
		case 5:
			return DataManager.Instance.mStringTable.GetStringByID(7737u);
		default:
			return DataManager.Instance.mStringTable.GetStringByID(7733u);
		}
	}

	// Token: 0x060024FC RID: 9468 RVA: 0x00425EB0 File Offset: 0x004240B0
	public Color GetItemRankColor(byte ItemRank)
	{
		switch (ItemRank)
		{
		case 1:
			return Color.white;
		case 2:
			return new Color(0.2078f, 0.9686f, 0.4235f);
		case 3:
			return new Color(0f, 1f, 1f);
		case 4:
			return new Color(0.7098f, 0.5569f, 1f);
		case 5:
			return new Color(1f, 0.9686f, 0.4235f);
		default:
			return Color.white;
		}
	}

	// Token: 0x060024FD RID: 9469 RVA: 0x00425F40 File Offset: 0x00424140
	public bool CheckCanOpenDetail(ushort HIID)
	{
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(HIID);
		return (recordByKey.EquipKind == 18 && recordByKey.PropertiesInfo[2].Propertieskey == 3 && recordByKey.PropertiesInfo[2].PropertiesValue == 1) || (recordByKey.EquipKind == 18 && recordByKey.PropertiesInfo[2].Propertieskey == 0) || (recordByKey.EquipKind == 18 && recordByKey.PropertiesInfo[2].Propertieskey == 1 && recordByKey.PropertiesInfo[4].PropertiesValue == 1) || (recordByKey.EquipKind == 18 && recordByKey.PropertiesInfo[2].Propertieskey == 2 && recordByKey.PropertiesInfo[4].PropertiesValue == 1) || recordByKey.EquipKind == 19;
	}

	// Token: 0x060024FE RID: 9470 RVA: 0x00426050 File Offset: 0x00424250
	public bool OpenDetail(ushort HIID)
	{
		if (this.door == null)
		{
			return false;
		}
		if (this.CheckCanOpenDetail(HIID))
		{
			this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int)HIID, false);
			return true;
		}
		return false;
	}

	// Token: 0x060024FF RID: 9471 RVA: 0x00426090 File Offset: 0x00424290
	public void LoadDefaultMainPackage()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.Append("UI/Mall_0");
		this.Default_AssetBundle = AssetManager.GetAssetBundle(cstring, out this.Default_AssetBundleKey);
		if (this.Default_AssetBundle != null)
		{
			this.Default_Material = (this.Default_AssetBundle.Load("Mall_m", typeof(Material)) as Material);
			UnityEngine.Object[] array = this.Default_AssetBundle.LoadAll(typeof(Sprite));
			this.Default_MainMenuSprite = new Sprite[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				ushort num = ushort.Parse(array[i].name);
				if (num >= 1 && (int)num <= this.Default_MainMenuSprite.Length)
				{
					this.Default_MainMenuSprite[(int)(num - 1)] = (Sprite)array[i];
				}
			}
		}
	}

	// Token: 0x06002500 RID: 9472 RVA: 0x0042616C File Offset: 0x0042436C
	public void SetDefaultPackage()
	{
		if (this.door == null)
		{
			return;
		}
		if (this.Default_AssetBundleKey == 0)
		{
			this.LoadDefaultMainPackage();
		}
		this.door.SpriteA.m_Sprites = this.Default_MainMenuSprite;
		this.door.SpriteA.m_Pivot = null;
		this.door.SpriteA.m_Image.sprite = this.Default_MainMenuSprite[0];
		this.door.SpriteA.m_Image.material = this.Default_Material;
		this.door.SpriteA.m_Image.material.renderQueue = 3000;
		this.door.SpriteA.m_Image.enabled = true;
		this.UnLoadMainPackage();
	}

	// Token: 0x06002501 RID: 9473 RVA: 0x00426238 File Offset: 0x00424438
	public void LoadMainPackege(ushort PackageID)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)PackageID, 1, false);
		cstring.AppendFormat("Store/Mallback_{0}");
		if (this.Main_AssetBundleKey != 0)
		{
			this.UnLoadMainPackage();
		}
		this.Main_AssetBundle = AssetManager.GetAssetBundle(cstring, out this.Main_AssetBundleKey);
		if (this.Main_AssetBundle != null)
		{
			this.Main_Material = (this.Main_AssetBundle.Load("Mall_m", typeof(Material)) as Material);
			UnityEngine.Object[] array = this.Main_AssetBundle.LoadAll(typeof(Sprite));
			this.Main_Sprite = new Sprite[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				ushort num = ushort.Parse(array[i].name);
				if (num >= 1 && (int)num <= this.Main_Sprite.Length)
				{
					this.Main_Sprite[(int)(num - 1)] = (Sprite)array[i];
				}
			}
		}
	}

	// Token: 0x06002502 RID: 9474 RVA: 0x00426330 File Offset: 0x00424530
	public void SetMainPackage()
	{
		if (this.door == null)
		{
			return;
		}
		if (this.Main_Sprite == null || this.Main_Material == null)
		{
			this.SetDefaultPackage();
			return;
		}
		this.door.SpriteA.m_Sprites = this.Main_Sprite;
		this.door.SpriteA.m_Pivot = null;
		this.door.SpriteA.m_Image.sprite = this.Main_Sprite[0];
		this.door.SpriteA.m_Image.material = this.Main_Material;
		this.door.SpriteA.m_Image.material.renderQueue = 3000;
		this.door.SpriteA.m_Image.enabled = true;
	}

	// Token: 0x06002503 RID: 9475 RVA: 0x00426408 File Offset: 0x00424608
	public void CheckHaveLevelUpPack()
	{
		if (this.MainData != null && this.MainData.Type == ETreasureType.ETST_SHLevelUp)
		{
			this.bLevelUpPack = true;
		}
		else
		{
			this.bLevelUpPack = false;
		}
	}

	// Token: 0x06002504 RID: 9476 RVA: 0x0042643C File Offset: 0x0042463C
	public void SetMainTime(bool bCheckTime = false)
	{
		if (this.door == null)
		{
			return;
		}
		if (this.MainData != null && this.MainData.Type == ETreasureType.ETST_SHLevelUp)
		{
			this.door.m_MallStr.Length = 0;
			if (bCheckTime && this.MainData.uTime == 0u && this.MainData.EndTime > DataManager.Instance.ServerTime)
			{
				this.MainData.uTime = (uint)(this.MainData.EndTime - DataManager.Instance.ServerTime);
			}
			GameConstants.GetTimeString(this.door.m_MallStr, this.MainData.uTime, false, false, true, false, false);
			this.door.m_MallText.text = this.door.m_MallStr.ToString();
			this.door.m_MallText.SetAllDirty();
			this.door.m_MallText.cachedTextGenerator.Invalidate();
			if (!this.door.m_MallImageGO.activeInHierarchy)
			{
				this.door.m_MallImageGO.SetActive(true);
			}
		}
		else
		{
			this.door.m_MallImageGO.SetActive(false);
		}
	}

	// Token: 0x06002505 RID: 9477 RVA: 0x0042657C File Offset: 0x0042477C
	public void UnLoadMainPackage()
	{
		if (this.Main_AssetBundleKey != 0)
		{
			this.Main_Material = null;
			this.Main_Sprite = null;
			AssetManager.UnloadAssetBundle(this.Main_AssetBundleKey, true);
			this.Main_AssetBundle = null;
			this.Main_AssetBundleKey = 0;
		}
	}

	// Token: 0x06002506 RID: 9478 RVA: 0x004265B4 File Offset: 0x004247B4
	public double Getprice(uint PackageID)
	{
		switch (PackageID)
		{
		case 11570u:
			return 65.0;
		case 11571u:
		case 11596u:
		case 11600u:
		case 11601u:
		case 11610u:
		case 11611u:
		case 11612u:
		case 11613u:
		case 11614u:
		case 11615u:
		case 11616u:
		case 11617u:
		case 11618u:
		case 11619u:
		case 11660u:
			goto IL_344;
		case 11572u:
			goto IL_34E;
		case 11573u:
		case 11597u:
		case 11604u:
		case 11605u:
		case 11630u:
		case 11631u:
		case 11632u:
		case 11633u:
		case 11634u:
		case 11635u:
		case 11636u:
		case 11637u:
		case 11638u:
		case 11639u:
		case 11661u:
			goto IL_358;
		case 11574u:
		case 11598u:
		case 11606u:
		case 11607u:
		case 11640u:
		case 11641u:
		case 11642u:
		case 11643u:
		case 11644u:
		case 11645u:
		case 11646u:
		case 11647u:
		case 11648u:
		case 11649u:
		case 11662u:
			goto IL_36C;
		case 11575u:
		case 11595u:
		case 11599u:
		case 11608u:
		case 11609u:
		case 11650u:
		case 11651u:
		case 11652u:
		case 11653u:
		case 11654u:
		case 11655u:
		case 11656u:
		case 11657u:
		case 11658u:
		case 11659u:
		case 11663u:
			goto IL_376;
		default:
			switch (PackageID)
			{
			case 14238u:
			case 14239u:
			case 14240u:
			case 14263u:
			case 14264u:
				goto IL_344;
			case 14241u:
			case 14242u:
			case 14243u:
				goto IL_358;
			case 14244u:
			case 14245u:
			case 14246u:
				goto IL_36C;
			case 14247u:
			case 14248u:
			case 14249u:
				goto IL_376;
			default:
				switch (PackageID)
				{
				case 14037u:
				case 14038u:
				case 14039u:
				case 14040u:
				case 14041u:
				case 14042u:
				case 14043u:
				case 14044u:
				case 14045u:
				case 14046u:
					goto IL_358;
				case 14047u:
				case 14048u:
				case 14049u:
				case 14050u:
				case 14051u:
				case 14052u:
				case 14053u:
				case 14054u:
				case 14055u:
				case 14056u:
					break;
				case 14057u:
				case 14058u:
				case 14059u:
				case 14060u:
				case 14061u:
					goto IL_376;
				default:
					switch (PackageID)
					{
					case 14140u:
					case 14141u:
					case 14142u:
						goto IL_344;
					case 14143u:
					case 14144u:
					case 14145u:
						goto IL_358;
					case 14146u:
					case 14147u:
					case 14148u:
						goto IL_36C;
					case 14149u:
					case 14150u:
					case 14151u:
						goto IL_376;
					default:
						switch (PackageID)
						{
						case 13881u:
						case 13882u:
							goto IL_344;
						case 13883u:
						case 13884u:
							goto IL_358;
						case 13885u:
						case 13886u:
							goto IL_36C;
						default:
							switch (PackageID)
							{
							case 14388u:
								goto IL_344;
							case 14389u:
								goto IL_358;
							case 14390u:
								break;
							case 14391u:
								goto IL_36C;
							case 14392u:
								goto IL_376;
							default:
								switch (PackageID)
								{
								case 13090u:
								case 13091u:
								case 13092u:
								case 13093u:
									goto IL_330;
								default:
									if (PackageID == 12378u)
									{
										goto IL_34E;
									}
									if (PackageID != 14216u && PackageID != 14269u)
									{
										return 0.0;
									}
									goto IL_344;
								}
								break;
							}
							break;
						}
						break;
					}
					break;
				}
				return 990.0;
			}
			break;
		case 11589u:
			break;
		}
		IL_330:
		return 33.0;
		IL_344:
		return 165.0;
		IL_34E:
		return 330.0;
		IL_358:
		return 660.0;
		IL_36C:
		return 1650.0;
		IL_376:
		return 3300.0;
	}

	// Token: 0x06002507 RID: 9479 RVA: 0x0042694C File Offset: 0x00424B4C
	public int GetPoint(uint PackageID)
	{
		switch (PackageID)
		{
		case 11570u:
			return 280;
		case 11571u:
		case 11596u:
		case 11600u:
		case 11601u:
		case 11610u:
		case 11611u:
		case 11612u:
		case 11613u:
		case 11614u:
		case 11615u:
		case 11616u:
		case 11617u:
		case 11618u:
		case 11619u:
		case 11660u:
			return 800;
		case 11572u:
			return 1700;
		case 11573u:
		case 11597u:
		case 11604u:
		case 11605u:
		case 11630u:
		case 11631u:
		case 11632u:
		case 11633u:
		case 11634u:
		case 11635u:
		case 11636u:
		case 11637u:
		case 11638u:
		case 11639u:
		case 11661u:
			return 3600;
		case 11574u:
		case 11598u:
		case 11606u:
		case 11607u:
		case 11640u:
		case 11641u:
		case 11642u:
		case 11643u:
		case 11644u:
		case 11645u:
		case 11646u:
		case 11647u:
		case 11648u:
		case 11649u:
		case 11662u:
			return 9500;
		case 11575u:
		case 11595u:
		case 11599u:
		case 11608u:
		case 11609u:
		case 11650u:
		case 11651u:
		case 11652u:
		case 11653u:
		case 11654u:
		case 11655u:
		case 11656u:
		case 11657u:
		case 11658u:
		case 11659u:
		case 11663u:
			return 22000;
		default:
			switch (PackageID)
			{
			case 14238u:
			case 14239u:
			case 14240u:
				return 800;
			case 14241u:
			case 14242u:
			case 14243u:
				return 3600;
			case 14244u:
			case 14245u:
			case 14246u:
				return 9500;
			case 14247u:
			case 14248u:
			case 14249u:
				return 22000;
			default:
				switch (PackageID)
				{
				case 14037u:
				case 14038u:
				case 14039u:
				case 14040u:
				case 14041u:
				case 14042u:
				case 14043u:
				case 14044u:
				case 14045u:
				case 14046u:
				case 14047u:
				case 14048u:
				case 14049u:
				case 14050u:
				case 14051u:
				case 14052u:
				case 14053u:
				case 14054u:
				case 14055u:
				case 14056u:
				case 14057u:
				case 14058u:
				case 14059u:
				case 14060u:
				case 14061u:
					break;
				default:
					switch (PackageID)
					{
					case 14140u:
					case 14141u:
					case 14142u:
						return 800;
					case 14143u:
					case 14144u:
					case 14145u:
						return 3600;
					case 14146u:
					case 14147u:
					case 14148u:
						return 9500;
					case 14149u:
					case 14150u:
					case 14151u:
						return 22000;
					default:
						switch (PackageID)
						{
						case 13881u:
						case 13882u:
						case 13883u:
						case 13884u:
						case 13885u:
						case 13886u:
							break;
						default:
							switch (PackageID)
							{
							case 14388u:
							case 14389u:
							case 14390u:
							case 14391u:
							case 14392u:
								break;
							default:
								switch (PackageID)
								{
								case 13090u:
								case 13091u:
								case 13092u:
									return 140;
								case 13093u:
									break;
								default:
									if (PackageID != 12378u && PackageID != 14216u && PackageID != 14269u)
									{
										return 0;
									}
									break;
								}
								break;
							}
							break;
						}
						break;
					}
					break;
				}
				break;
			case 14263u:
			case 14264u:
				break;
			}
			return 0;
		case 11589u:
			break;
		}
		return 140;
	}

	// Token: 0x06002508 RID: 9480 RVA: 0x00426CB8 File Offset: 0x00424EB8
	public string GetProductPriceByID(int id)
	{
		if (this.m_MallItemPrice.ContainsKey(id))
		{
			return this.m_MallItemPrice[id].Price;
		}
		return null;
	}

	// Token: 0x06002509 RID: 9481 RVA: 0x00426CEC File Offset: 0x00424EEC
	public string GetProductPaltformPriceByID(int id)
	{
		if (this.m_MallItemPrice.ContainsKey(id))
		{
			return this.m_MallItemPrice[id].PaltformPrice;
		}
		return null;
	}

	// Token: 0x0600250A RID: 9482 RVA: 0x00426D20 File Offset: 0x00424F20
	public bool GetProductPointByID(int id, out int point)
	{
		bool result = false;
		point = 0;
		if (this.m_MallItemPrice.ContainsKey(id))
		{
			point = this.m_MallItemPrice[id].Point;
			result = true;
		}
		return result;
	}

	// Token: 0x0600250B RID: 9483 RVA: 0x00426D5C File Offset: 0x00424F5C
	public string GetCurrency(int id)
	{
		if (this.m_MallItemPrice.ContainsKey(id))
		{
			return this.m_MallItemPrice[id].Currency;
		}
		return null;
	}

	// Token: 0x0600250C RID: 9484 RVA: 0x00426D90 File Offset: 0x00424F90
	public void SetCulture()
	{
		string countryCode = IGGSDKPlugin.GetCountryCode();
		for (int i = 0; i < this.CurrencyToCulture.Length; i++)
		{
			if (this.CurrencyToCulture[i][0] == countryCode)
			{
				this.culture = CultureInfo.CreateSpecificCulture(this.CurrencyToCulture[i][1]);
				this.bFindCulture = true;
				return;
			}
		}
		this.culture = CultureInfo.CreateSpecificCulture("en-US");
	}

	// Token: 0x0600250D RID: 9485 RVA: 0x00426E00 File Offset: 0x00425000
	public bool IsArabicNum(char tmp)
	{
		return tmp == '٠' || tmp == '١' || tmp == '٢' || tmp == '٣' || tmp == '٤' || tmp == '٥' || tmp == '٦' || tmp == '٧' || tmp == '٨' || tmp == '٩' || tmp == '۰' || tmp == '۱' || tmp == '۲' || tmp == '۳' || tmp == '۴' || tmp == '۵' || tmp == '۶' || tmp == '۷' || tmp == '۸' || tmp == '۹';
	}

	// Token: 0x0600250E RID: 9486 RVA: 0x00426EEC File Offset: 0x004250EC
	public string RePlaceArbForPrice(string Price)
	{
		if (Price == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < Price.Length; i++)
		{
			if (Price[i] == '٠')
			{
				stringBuilder.Append('0');
			}
			else if (Price[i] == '١')
			{
				stringBuilder.Append('1');
			}
			else if (Price[i] == '٢')
			{
				stringBuilder.Append('2');
			}
			else if (Price[i] == '٣')
			{
				stringBuilder.Append('3');
			}
			else if (Price[i] == '٤')
			{
				stringBuilder.Append('4');
			}
			else if (Price[i] == '٥')
			{
				stringBuilder.Append('5');
			}
			else if (Price[i] == '٦')
			{
				stringBuilder.Append('6');
			}
			else if (Price[i] == '٧')
			{
				stringBuilder.Append('7');
			}
			else if (Price[i] == '٨')
			{
				stringBuilder.Append('8');
			}
			else if (Price[i] == '٩')
			{
				stringBuilder.Append('9');
			}
			else if (Price[i] == '٬')
			{
				stringBuilder.Append(',');
			}
			else if (Price[i] == ',')
			{
				stringBuilder.Append('.');
			}
			else if (Price[i] == '۰')
			{
				stringBuilder.Append('0');
			}
			else if (Price[i] == '۱')
			{
				stringBuilder.Append('1');
			}
			else if (Price[i] == '۲')
			{
				stringBuilder.Append('2');
			}
			else if (Price[i] == '۳')
			{
				stringBuilder.Append('3');
			}
			else if (Price[i] == '۴')
			{
				stringBuilder.Append('4');
			}
			else if (Price[i] == '۵')
			{
				stringBuilder.Append('5');
			}
			else if (Price[i] == '۶')
			{
				stringBuilder.Append('6');
			}
			else if (Price[i] == '۷')
			{
				stringBuilder.Append('7');
			}
			else if (Price[i] == '۸')
			{
				stringBuilder.Append('8');
			}
			else if (Price[i] == '۹')
			{
				stringBuilder.Append('9');
			}
			else
			{
				stringBuilder.Append(Price[i]);
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0600250F RID: 9487 RVA: 0x004271DC File Offset: 0x004253DC
	public string RevArbForPrice(string Price)
	{
		if (Price == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < Price.Length; i++)
		{
			if (Price[i] == '0')
			{
				stringBuilder.Append('٠');
			}
			else if (Price[i] == '1')
			{
				stringBuilder.Append('١');
			}
			else if (Price[i] == '2')
			{
				stringBuilder.Append('٢');
			}
			else if (Price[i] == '3')
			{
				stringBuilder.Append('٣');
			}
			else if (Price[i] == '4')
			{
				stringBuilder.Append('٤');
			}
			else if (Price[i] == '5')
			{
				stringBuilder.Append('٥');
			}
			else if (Price[i] == '6')
			{
				stringBuilder.Append('٦');
			}
			else if (Price[i] == '7')
			{
				stringBuilder.Append('٧');
			}
			else if (Price[i] == '8')
			{
				stringBuilder.Append('٨');
			}
			else if (Price[i] == '9')
			{
				stringBuilder.Append('٩');
			}
			else if (Price[i] == ',')
			{
				stringBuilder.Append('٬');
			}
			else if (Price[i] == '.')
			{
				stringBuilder.Append(',');
			}
			else if (Price[i] == '0')
			{
				stringBuilder.Append('۰');
			}
			else if (Price[i] == '1')
			{
				stringBuilder.Append('۱');
			}
			else if (Price[i] == '2')
			{
				stringBuilder.Append('۲');
			}
			else if (Price[i] == '3')
			{
				stringBuilder.Append('۳');
			}
			else if (Price[i] == '4')
			{
				stringBuilder.Append('۴');
			}
			else if (Price[i] == '5')
			{
				stringBuilder.Append('۵');
			}
			else if (Price[i] == '6')
			{
				stringBuilder.Append('۶');
			}
			else if (Price[i] == '7')
			{
				stringBuilder.Append('۷');
			}
			else if (Price[i] == '8')
			{
				stringBuilder.Append('۸');
			}
			else if (Price[i] == '9')
			{
				stringBuilder.Append('۹');
			}
			else
			{
				stringBuilder.Append(Price[i]);
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x06002510 RID: 9488 RVA: 0x004274CC File Offset: 0x004256CC
	public double GetOriginalPrice(double Price, byte Discount)
	{
		return (Discount < 100) ? (Price * 100.0 / (double)(100 - Discount)) : 0.0;
	}

	// Token: 0x06002511 RID: 9489 RVA: 0x004274F8 File Offset: 0x004256F8
	public bool SetPriceStr(CString tmpPriceStr, int TreasureID, bool bDisCount = false, byte Discount = 0)
	{
		if (tmpPriceStr == null)
		{
			return false;
		}
		bool result = false;
		tmpPriceStr.Length = 0;
		string productPaltformPriceByID = this.GetProductPaltformPriceByID(TreasureID);
		string productPriceByID = this.GetProductPriceByID(TreasureID);
		if (productPaltformPriceByID != null && productPaltformPriceByID != string.Empty)
		{
			if (bDisCount)
			{
				bool flag = false;
				bool flag2 = true;
				bool flag3 = false;
				double price = 0.0;
				string text = null;
				string tmpS = null;
				CString cstring = StringManager.Instance.SpawnString(30);
				bool flag4 = this.IsArabicNum(productPaltformPriceByID[0]);
				if ((productPaltformPriceByID[0] >= '0' && productPaltformPriceByID[0] <= '9') || flag4)
				{
					flag3 = true;
					int num = -1;
					for (int i = productPaltformPriceByID.Length - 1; i >= 0; i--)
					{
						if ((productPaltformPriceByID[i] >= '0' && productPaltformPriceByID[i] <= '9') || this.IsArabicNum(productPaltformPriceByID[i]))
						{
							num = i + 1;
							break;
						}
					}
					if (num == -1)
					{
						flag2 = false;
					}
					else
					{
						text = productPaltformPriceByID.Substring(0, num);
						for (int j = num; j < productPaltformPriceByID.Length; j++)
						{
							cstring.Append(productPaltformPriceByID[j]);
						}
					}
				}
				else
				{
					for (int k = 0; k < productPaltformPriceByID.Length; k++)
					{
						flag4 = this.IsArabicNum(productPaltformPriceByID[k]);
						if ((productPaltformPriceByID[k] >= '0' && productPaltformPriceByID[k] <= '9') || flag4)
						{
							text = productPaltformPriceByID.Substring(k, productPaltformPriceByID.Length - k);
							if (flag4)
							{
								text = this.RePlaceArbForPrice(text);
							}
							break;
						}
						tmpPriceStr.Append(productPaltformPriceByID[k]);
					}
				}
				if (flag2)
				{
					NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
					if (flag4)
					{
						if (text != null && double.TryParse(text, style, this.NormalCulture1, out price))
						{
							flag = true;
							price = this.GetOriginalPrice(price, Discount);
							tmpS = this.RevArbForPrice(price.ToString("N2", this.NormalCulture1));
						}
						if (text != null && !flag && double.TryParse(text, style, this.NormalCulture2, out price))
						{
							flag = true;
							price = this.GetOriginalPrice(price, Discount);
							tmpS = this.RevArbForPrice(price.ToString("N2", this.NormalCulture2));
						}
					}
					else
					{
						if (this.culture == null)
						{
							this.SetCulture();
						}
						if (this.bFindCulture && text != null && double.TryParse(text, style, this.culture, out price))
						{
							flag = true;
							price = this.GetOriginalPrice(price, Discount);
							tmpS = price.ToString("N2", this.culture);
						}
					}
				}
				if (flag)
				{
					tmpPriceStr.StringToFormat(tmpS);
					tmpPriceStr.AppendFormat("{0}");
					if (flag3)
					{
						tmpPriceStr.Append(cstring);
					}
				}
				else
				{
					tmpPriceStr.Length = 0;
					tmpPriceStr.Append(productPaltformPriceByID);
				}
				StringManager.Instance.DeSpawnString(cstring);
			}
			else
			{
				tmpPriceStr.Append(productPaltformPriceByID);
			}
		}
		else
		{
			if (productPriceByID == null)
			{
				double num2 = 0.0;
				result = true;
				if (bDisCount)
				{
					tmpPriceStr.DoubleToFormat((Discount < 100) ? (num2 * 100.0 / (double)(100 - Discount)) : 0.0, 2, true);
				}
				else
				{
					tmpPriceStr.DoubleToFormat(num2, 2, true);
				}
			}
			else if (bDisCount)
			{
				bool flag5 = false;
				NumberStyles style2 = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
				if (this.IsArabicNum(productPriceByID[0]))
				{
					double price2 = 0.0;
					string s = this.RePlaceArbForPrice(productPriceByID);
					if (double.TryParse(s, style2, this.NormalCulture1, out price2))
					{
						flag5 = true;
						price2 = this.GetOriginalPrice(price2, Discount);
						string tmpS2 = this.RevArbForPrice(price2.ToString("N2", this.NormalCulture1));
						tmpPriceStr.StringToFormat(tmpS2);
					}
					if (!flag5 && double.TryParse(s, style2, this.NormalCulture2, out price2))
					{
						flag5 = true;
						price2 = this.GetOriginalPrice(price2, Discount);
						string tmpS3 = this.RevArbForPrice(price2.ToString("N2", this.NormalCulture2));
						tmpPriceStr.StringToFormat(tmpS3);
					}
				}
				else
				{
					if (this.culture == null)
					{
						this.SetCulture();
					}
					double price3 = 0.0;
					if (this.bFindCulture && double.TryParse(productPriceByID, style2, this.culture, out price3))
					{
						flag5 = true;
						price3 = this.GetOriginalPrice(price3, Discount);
						string tmpS4 = price3.ToString("N2", this.culture);
						tmpPriceStr.StringToFormat(tmpS4);
					}
				}
				if (!flag5)
				{
					tmpPriceStr.StringToFormat(productPriceByID);
				}
			}
			else
			{
				tmpPriceStr.StringToFormat(productPriceByID);
			}
			string currency = this.GetCurrency(TreasureID);
			if (currency != null)
			{
				tmpPriceStr.StringToFormat(currency);
				if (this.bChangePosCurrency(currency))
				{
					tmpPriceStr.AppendFormat("{0} {1}");
				}
				else
				{
					tmpPriceStr.AppendFormat("{1} {0}");
				}
			}
			else
			{
				tmpPriceStr.AppendFormat("-");
			}
		}
		return result;
	}

	// Token: 0x06002512 RID: 9490 RVA: 0x00427A30 File Offset: 0x00425C30
	public uint TreasureIDTransToNew(uint TreasureID)
	{
		return TreasureID;
	}

	// Token: 0x06002513 RID: 9491 RVA: 0x00427A34 File Offset: 0x00425C34
	public bool bChangePosCurrency(string Currency)
	{
		if (this.ChangePos == -1)
		{
			if (string.Compare("EUR", Currency) == 0 || string.Compare("RUB", Currency) == 0 || string.Compare("р.", Currency) == 0)
			{
				this.ChangePos = 1;
			}
			else
			{
				this.ChangePos = 0;
			}
		}
		return this.ChangePos == 1;
	}

	// Token: 0x06002514 RID: 9492 RVA: 0x00427A9C File Offset: 0x00425C9C
	public bool FindAndOpenMall(int tmpForgeIndex)
	{
		for (int i = 0; i < this.MallDataList.Count; i++)
		{
			if (this.MallDataList[i].Type != ETreasureType.ETST_Crystal && (int)this.MallDataList[i].SetNo == tmpForgeIndex)
			{
				this.ForgeIndex = i;
				this.Send_Mall_Info();
				return true;
			}
		}
		bool flag = false;
		List<ushort> list = new List<ushort>();
		for (int j = 0; j < this.MallDataList.Count; j++)
		{
			if (this.MallDataList[j].Type != ETreasureType.ETST_Crystal && this.MallDataList[j].SetNo == 65535)
			{
				flag = true;
				if (!this.MallDataList[j].bAskDetailData)
				{
					list.Add(this.MallDataList[j].SN);
				}
			}
		}
		if (flag)
		{
			if (list.Count > 0)
			{
				GUIManager.Instance.ShowUILock(EUILock.Mall);
				this.AskForgeCount = list.Count;
				this.NeedFindFrogeIndex = tmpForgeIndex;
				for (int k = 0; k < list.Count; k++)
				{
					this.Send_Mall_Combobox(list[k]);
				}
			}
			else
			{
				this.FindDetailAndOpenMall(tmpForgeIndex);
			}
			return true;
		}
		return false;
	}

	// Token: 0x06002515 RID: 9493 RVA: 0x00427BF4 File Offset: 0x00425DF4
	public void FindDetailAndOpenMall(int tmpForgeIndex)
	{
		for (int i = 0; i < this.MallDataList.Count; i++)
		{
			if (this.MallDataList[i].Type != ETreasureType.ETST_Crystal && this.MallDataList[i].SetNo == 65535)
			{
				for (int j = 0; j < 200; j++)
				{
					if ((int)DataManager.Instance.EquipTable.GetRecordByKey(this.MallDataList[i].Item[j].ItemID).ActivitySuitIndex == tmpForgeIndex)
					{
						this.ForgeIndex = i;
						this.Send_Mall_Info();
						return;
					}
				}
			}
		}
		GUIManager.Instance.OpenItemKindFilterUI(18, 1, (byte)tmpForgeIndex);
	}

	// Token: 0x06002516 RID: 9494 RVA: 0x00427CBC File Offset: 0x00425EBC
	public void ClearSendCheckBuySN()
	{
		this.SendCheckBuySN = 0u;
		this.SendCheckEmojiID = 0;
		this.SendCheckCastleID = 0;
		this.SendCheckRedPocketID = 0;
		this.bLockBuy = false;
		this.bLockBuyEmojiID = false;
		this.bLockBuyCastleID = false;
		this.bLockBuyRedPocket = false;
		MerchantmanManager.Instance.ClearSendCheckBuy();
	}

	// Token: 0x06002517 RID: 9495 RVA: 0x00427D0C File Offset: 0x00425F0C
	public bool CheckbWaitBuy(bool bShowMessage = false)
	{
		if (this.bLockBuy)
		{
			if (bShowMessage)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(656u), 255, true);
			}
			return true;
		}
		return false;
	}

	// Token: 0x06002518 RID: 9496 RVA: 0x00427D54 File Offset: 0x00425F54
	public bool CheckbWaitBuy_Emoji(bool bShowMessage = false)
	{
		if (this.bLockBuyEmojiID)
		{
			if (bShowMessage)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(656u), 255, true);
			}
			return true;
		}
		return false;
	}

	// Token: 0x06002519 RID: 9497 RVA: 0x00427D9C File Offset: 0x00425F9C
	public bool CheckbWaitBuy_Castle(bool bShowMessage = false)
	{
		if (this.bLockBuyCastleID)
		{
			if (bShowMessage)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(656u), 255, true);
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600251A RID: 9498 RVA: 0x00427DE4 File Offset: 0x00425FE4
	public bool CheckbWaitBuy_RedPocket(bool bShowMessage = false)
	{
		if (this.bLockBuyRedPocket)
		{
			if (bShowMessage)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(656u), 255, true);
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600251B RID: 9499 RVA: 0x00427E2C File Offset: 0x0042602C
	public void ClearFullGift()
	{
		this.FullGift_NowCrystal = 0u;
		this.FullGift_MaxCrystal = 0u;
		this.FullGift_Deadline = 0L;
		this.FullGift_TreasureItemCount = 0;
	}

	// Token: 0x0600251C RID: 9500 RVA: 0x00427E4C File Offset: 0x0042604C
	public void LoadShowEffect()
	{
		bool.TryParse(PlayerPrefs.GetString("FullGift_bShowEffect"), out this.FullGift_bShowEffect);
	}

	// Token: 0x0600251D RID: 9501 RVA: 0x00427E64 File Offset: 0x00426064
	public void SetShowEffect(bool Set)
	{
		this.FullGift_bShowEffect = Set;
		PlayerPrefs.SetString("FullGift_bShowEffect", this.FullGift_bShowEffect.ToString());
	}

	// Token: 0x0600251E RID: 9502 RVA: 0x00427E84 File Offset: 0x00426084
	public void CheckShowEffect()
	{
		if (this.FullGift_bShowEffect && this.FullGift_Deadline == 0L)
		{
			this.SetShowEffect(false);
		}
	}

	// Token: 0x0600251F RID: 9503 RVA: 0x00427EA4 File Offset: 0x004260A4
	public void SetPaidDollar(uint Dollar, bool bCheckFirst = false)
	{
		long paidDollar = this.PaidDollar;
		this.PaidDollar = (long)((ulong)Dollar);
		if (Dollar == 0u && paidDollar == -1L)
		{
			ActivityManager activityManager = ActivityManager.Instance;
			activityManager.FBActivityData.Initial();
			activityManager.FBActivityData.Name = 8105;
			activityManager.FBActivityData.DetailPic = 102;
			activityManager.FBActivityData.HeadStr = 1;
			activityManager.FBActivityData.DetailStr = 116;
			activityManager.FBActivityData.GoToButton = 1;
			CString cstring = StringManager.Instance.StaticString1024();
			cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat((long)activityManager.FBActivityData.DetailStr, 1, false);
			cstring.AppendFormat("UI/UIActivityPackage_{0}");
			if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Activity, AssetType.ActivityPackage, activityManager.FBActivityData.DetailStr, false))
			{
				activityManager.FBActivityData.bDownLoadStr = true;
			}
		}
		else if (Dollar != 0u && paidDollar == 0L)
		{
			this.FirstGift_bShowEffect = true;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 12, 0);
		}
		ActivityManager.Instance.CheckFirstBuyShowHint();
	}

	// Token: 0x06002520 RID: 9504 RVA: 0x00427FB0 File Offset: 0x004261B0
	public void Send_Mall_Info()
	{
		if (this.bAskListData)
		{
			List<ushort> list = new List<ushort>();
			for (int i = 0; i < this.MallDataList.Count; i++)
			{
				if (!this.MallDataList[i].bAskListData)
				{
					list.Add(this.MallDataList[i].SN);
				}
			}
			if (list.Count > 0)
			{
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_TREASURE_INFO;
				messagePacket.AddSeqId();
				messagePacket.Add((byte)list.Count);
				for (int j = 0; j < list.Count; j++)
				{
					messagePacket.Add(list[j]);
				}
				messagePacket.Send(false);
				GUIManager.Instance.ShowUILock(EUILock.Mall);
			}
			else
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 1, 0);
				if (this.door != null)
				{
					this.door.OpenMenu(EGUIWindow.UI_Mall, 0, 0, true);
				}
			}
		}
		else
		{
			MessagePacket messagePacket2 = new MessagePacket(1024);
			messagePacket2.Protocol = Protocol._MSG_REQUEST_TREASURE_INFO;
			messagePacket2.AddSeqId();
			messagePacket2.Add(0);
			messagePacket2.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Mall);
			AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.ENTER_MALL);
		}
	}

	// Token: 0x06002521 RID: 9505 RVA: 0x0042810C File Offset: 0x0042630C
	public void Send_Mall_Combobox(ushort SN)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_TREASURE_COMBOBOX;
		messagePacket.AddSeqId();
		messagePacket.Add(SN);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Mall);
	}

	// Token: 0x06002522 RID: 9506 RVA: 0x00428154 File Offset: 0x00426354
	public void Send_Mall_Check(ushort SN, bool checkPay = true)
	{
		if (checkPay && (DataManager.Instance.MySysSetting.mPaySetting & 4) == 0)
		{
			GUIManager.Instance.OpenMenu(EGUIWindow.UI_PaySetting, (int)SN, 0, false, true, false);
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_TREASURE_PREBUY_CHECK;
		messagePacket.AddSeqId();
		messagePacket.Add(SN);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Mall);
	}

	// Token: 0x06002523 RID: 9507 RVA: 0x004281C8 File Offset: 0x004263C8
	public void Send_Mall_TestBuy(uint TreasureID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_TREASURE_DEBUGBUY;
		messagePacket.AddSeqId();
		messagePacket.Add(TreasureID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Mall);
	}

	// Token: 0x06002524 RID: 9508 RVA: 0x00428210 File Offset: 0x00426410
	public void RecvMall_List(MessagePacket MP)
	{
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 4, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 4, 0);
		this.SetDefaultPackage();
		for (int i = 0; i < this.MallDataList.Count; i++)
		{
			this.MallDataList[i].UnloadAB(false);
		}
		this.MallDataList.Clear();
		ushort num = MP.ReadUShort(-1);
		MallDataType mallDataType = new MallDataType();
		mallDataType.SN = num;
		mallDataType.bAskListData = true;
		mallDataType.TreasureID = this.TreasureIDTransToNew(MP.ReadUInt(-1));
		mallDataType.PosType = MP.ReadByte(-1);
		mallDataType.BonusRate = MP.ReadByte(-1);
		mallDataType.BonusCrystal = MP.ReadUInt(-1);
		mallDataType.EndTime = MP.ReadLong(-1);
		mallDataType.FrameColor.r = (float)MP.ReadByte(-1) / 255f;
		mallDataType.FrameColor.g = (float)MP.ReadByte(-1) / 255f;
		mallDataType.FrameColor.b = (float)MP.ReadByte(-1) / 255f;
		mallDataType.LineColor.r = (float)MP.ReadByte(-1) / 255f;
		mallDataType.LineColor.g = (float)MP.ReadByte(-1) / 255f;
		mallDataType.LineColor.b = (float)MP.ReadByte(-1) / 255f;
		mallDataType.ComboBoxID = MP.ReadUShort(-1);
		for (int j = 0; j < 3; j++)
		{
			mallDataType.BriefItem[j].ItemID = MP.ReadUShort(-1);
			mallDataType.BriefItem[j].Num = MP.ReadUShort(-1);
			mallDataType.BriefItem[j].ItemRank = MP.ReadByte(-1);
		}
		mallDataType.bBuyOnce = MP.ReadByte(-1);
		if (DataManager.Instance.ServerVersionMajor != 0)
		{
			mallDataType.StampPic = MP.ReadUShort(-1);
			mallDataType.StampHint = MP.ReadUShort(-1);
			mallDataType.Discount = MP.ReadByte(-1);
			mallDataType.ExtraByte = MP.ReadByte(-1);
			for (int k = 0; k < 3; k++)
			{
				mallDataType.ExtraData[k] = MP.ReadUShort(-1);
			}
		}
		if (num != 0)
		{
			this.MallDataList.Add(mallDataType);
			this.MainData = mallDataType;
		}
		byte b = MP.ReadByte(-1);
		for (int l = 0; l < (int)b; l++)
		{
			ushort num2 = MP.ReadUShort(-1);
			if (this.MainData != null && this.MainData.SN == num2)
			{
				this.MainData.GroupID = MP.ReadUShort(-1);
				this.MainData.TreasureID = this.TreasureIDTransToNew(MP.ReadUInt(-1));
				this.MainData.PicPackageID1 = MP.ReadUShort(-1);
				this.MainData.SetBuyOnce();
				this.MainData.PicPackageID2 = MP.ReadUShort(-1);
				this.MainData.StrPackageID = MP.ReadUShort(-1);
				this.MainData.Type = (ETreasureType)MP.ReadByte(-1);
				this.MainData.RenderWeight = MP.ReadUShort(-1);
				this.MainData.SetNo = MP.ReadUShort(-1);
				if (this.MainData.Type == ETreasureType.ETST_Crystal)
				{
					this.bCanOpenMain = true;
				}
				else
				{
					this.MainData.SendAskDownLoad();
				}
			}
			else
			{
				MallDataType mallDataType2 = new MallDataType();
				this.MallDataList.Add(mallDataType2);
				mallDataType2.SN = num2;
				mallDataType2.GroupID = MP.ReadUShort(-1);
				mallDataType2.TreasureID = this.TreasureIDTransToNew(MP.ReadUInt(-1));
				mallDataType2.PicPackageID1 = MP.ReadUShort(-1);
				mallDataType2.SetBuyOnce();
				mallDataType2.PicPackageID2 = MP.ReadUShort(-1);
				mallDataType2.StrPackageID = MP.ReadUShort(-1);
				mallDataType2.Type = (ETreasureType)MP.ReadByte(-1);
				mallDataType2.RenderWeight = MP.ReadUShort(-1);
				mallDataType2.SetNo = MP.ReadUShort(-1);
			}
		}
		this.bAskListData = false;
		this.SortMallData();
		for (int m = 0; m < this.MallDataList.Count; m++)
		{
			if (this.MallDataList[m].SN != num && this.MallDataList[m].Type != ETreasureType.ETST_Crystal)
			{
				this.MallDataList[m].SendAskDownLoad();
			}
		}
		if (this.AutoDetailSN != 0)
		{
			if (this.FindIndexBySN(this.AutoDetailSN) != -1)
			{
				this.bSendMallInfo = true;
			}
			else
			{
				this.AutoDetailSN = 0;
				if (this.door != null)
				{
					this.door.CloseMenu(false);
				}
			}
		}
		if (this.bLockBuy && this.FindIndexBySN((ushort)this.SendCheckBuySN) == -1)
		{
			this.ClearSendCheckBuySN();
		}
		if (this.AutoDetailSN != 0 || this.AutoMall)
		{
			GUIManager.Instance.ShowUILock(EUILock.Mall);
		}
		if (this.MainPackageSN != 0 && this.MainData != null && this.MainPackageSN != this.MainData.SN && this.MainData.Type != ETreasureType.ETST_Crystal && !GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall) && !GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall_Detail) && !GUIManager.Instance.CheckInQueue(EGUIWindow.UI_Mall))
		{
			this.bCanOpenMain = false;
		}
		if (this.MainData != null)
		{
			this.MainPackageSN = this.MainData.SN;
		}
		this.CheckHaveLevelUpPack();
		this.SetMainTime(true);
	}

	// Token: 0x06002525 RID: 9509 RVA: 0x004287C4 File Offset: 0x004269C4
	public void RecvMall_Info(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = MP.ReadByte(-1);
		for (int i = 0; i < (int)b2; i++)
		{
			ushort sn = MP.ReadUShort(-1);
			MallDataType mallDataType = this.FindDataBySN(sn);
			if (mallDataType == null)
			{
				mallDataType = new MallDataType();
				mallDataType.SN = sn;
				this.MallDataList.Add(mallDataType);
			}
			mallDataType.bAskListData = true;
			mallDataType.TreasureID = this.TreasureIDTransToNew(MP.ReadUInt(-1));
			mallDataType.PosType = MP.ReadByte(-1);
			mallDataType.BonusRate = MP.ReadByte(-1);
			mallDataType.BonusCrystal = MP.ReadUInt(-1);
			mallDataType.EndTime = MP.ReadLong(-1);
			mallDataType.FrameColor.r = (float)MP.ReadByte(-1) / 255f;
			mallDataType.FrameColor.g = (float)MP.ReadByte(-1) / 255f;
			mallDataType.FrameColor.b = (float)MP.ReadByte(-1) / 255f;
			mallDataType.LineColor.r = (float)MP.ReadByte(-1) / 255f;
			mallDataType.LineColor.g = (float)MP.ReadByte(-1) / 255f;
			mallDataType.LineColor.b = (float)MP.ReadByte(-1) / 255f;
			mallDataType.ComboBoxID = MP.ReadUShort(-1);
			for (int j = 0; j < 3; j++)
			{
				mallDataType.BriefItem[j].ItemID = MP.ReadUShort(-1);
				mallDataType.BriefItem[j].Num = MP.ReadUShort(-1);
				mallDataType.BriefItem[j].ItemRank = MP.ReadByte(-1);
			}
			mallDataType.bBuyOnce = MP.ReadByte(-1);
			if (DataManager.Instance.ServerVersionMajor != 0)
			{
				mallDataType.StampPic = MP.ReadUShort(-1);
				mallDataType.StampHint = MP.ReadUShort(-1);
				mallDataType.Discount = MP.ReadByte(-1);
				mallDataType.ExtraByte = MP.ReadByte(-1);
				for (int k = 0; k < 3; k++)
				{
					mallDataType.ExtraData[k] = MP.ReadUShort(-1);
				}
			}
		}
		if (b == 1)
		{
			this.SortMallData();
			if (this.AutoDetailSN != 0)
			{
				this.Send_Mall_Combobox(this.AutoDetailSN);
				this.AutoDetailSN = 0;
			}
			else if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall))
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 1, 0);
			}
			else if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_Mall, 0, 0, true);
			}
			GUIManager.Instance.HideUILock(EUILock.Mall);
			this.bAskListData = true;
		}
	}

	// Token: 0x06002526 RID: 9510 RVA: 0x00428A94 File Offset: 0x00426C94
	public void RecvMall_Combobox(MessagePacket MP)
	{
		ushort sn = MP.ReadUShort(-1);
		int num = this.FindIndexBySN(sn);
		if (num != -1)
		{
			MallDataType mallDataType = this.MallDataList[num];
			for (int i = 0; i < 5; i++)
			{
				mallDataType.AllianceGift[i].ItemID = MP.ReadUShort(-1);
				mallDataType.AllianceGift[i].Num = MP.ReadUShort(-1);
			}
			mallDataType.DataLen = MP.ReadByte(-1);
			for (int j = 0; j < (int)mallDataType.DataLen; j++)
			{
				mallDataType.Item[j].ItemID = MP.ReadUShort(-1);
				mallDataType.Item[j].Num = MP.ReadUShort(-1);
				mallDataType.Item[j].ItemRank = MP.ReadByte(-1);
			}
			mallDataType.AllianceGiftShowTop = MP.ReadByte(-1);
			mallDataType.bAskDetailData = true;
			if (this.AskForgeCount > 0)
			{
				this.AskForgeCount--;
				if (this.AskForgeCount == 0)
				{
					GUIManager.Instance.HideUILock(EUILock.Mall);
					this.FindDetailAndOpenMall(this.NeedFindFrogeIndex);
					this.NeedFindFrogeIndex = -1;
				}
			}
			else
			{
				GUIManager.Instance.HideUILock(EUILock.Mall);
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall_Detail))
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 6, 0);
				}
				else if (this.door != null)
				{
					this.door.OpenMenu(EGUIWindow.UI_Mall_Detail, num, 0, false);
				}
			}
		}
	}

	// Token: 0x06002527 RID: 9511 RVA: 0x00428C30 File Offset: 0x00426E30
	public void RecvMall_UpdateList(MessagePacket MP)
	{
		switch (MP.ReadByte(-1))
		{
		case 0:
		{
			ushort sn = MP.ReadUShort(-1);
			MallDataType mallDataType = this.FindDataBySN(sn);
			if (mallDataType == null)
			{
				mallDataType = new MallDataType();
				mallDataType.SN = sn;
				this.MallDataList.Add(mallDataType);
			}
			mallDataType.SN = sn;
			mallDataType.GroupID = MP.ReadUShort(-1);
			mallDataType.TreasureID = this.TreasureIDTransToNew(MP.ReadUInt(-1));
			mallDataType.PicPackageID1 = MP.ReadUShort(-1);
			mallDataType.SetBuyOnce();
			mallDataType.PicPackageID2 = MP.ReadUShort(-1);
			mallDataType.StrPackageID = MP.ReadUShort(-1);
			mallDataType.Type = (ETreasureType)MP.ReadByte(-1);
			mallDataType.RenderWeight = MP.ReadUShort(-1);
			mallDataType.SetNo = MP.ReadUShort(-1);
			mallDataType.SendAskDownLoad();
			if (mallDataType.Type == ETreasureType.ETST_SHLevelUp)
			{
				mallDataType.EndTime = MP.ReadLong(-1);
			}
			this.SortMallData();
			if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall))
			{
				this.Send_Mall_Info();
			}
			else
			{
				this.MallUIIndex = 0;
				this.MallUIPos = 0f;
			}
			this.ChaekMainPackage();
			break;
		}
		case 1:
		{
			ushort groupID = MP.ReadUShort(-1);
			int arg = this.RemoveDataByGID(groupID);
			this.SortMallData();
			this.ChaekMainPackage();
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 1, arg);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 1, 0);
			break;
		}
		case 2:
		{
			ushort groupID2 = MP.ReadUShort(-1);
			int num = this.FindIndexByGID(groupID2);
			if (num != -1)
			{
				this.MallDataList[num].EndTime = MP.ReadLong(-1);
				this.CalculateTime(num);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 0, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 0, 0);
			}
			break;
		}
		}
	}

	// Token: 0x06002528 RID: 9512 RVA: 0x00428E0C File Offset: 0x0042700C
	public void RecvMall_Check(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			ushort num = MP.ReadUShort(-1);
			this.SendBuySN = num;
			MallDataType mallDataType = this.FindDataBySN(num);
			if (mallDataType == null)
			{
				return;
			}
			if (mallDataType.bBuyOnce == 1)
			{
				this.SendCheckBuySN = (uint)num;
			}
			DataManager dataManager = DataManager.Instance;
			string itemName = string.Empty;
			string productPriceByID = IGGGameSDK.Instance.GetProductPriceByID((int)mallDataType.TreasureID);
			if (mallDataType.Type == ETreasureType.ETST_Crystal)
			{
				itemName = dataManager.mStringTable.GetStringByID((uint)mallDataType.StrPackageID);
			}
			else
			{
				byte b = dataManager.UserLanguage - GameLanguage.GL_Eng;
				if (mallDataType.DownLoadStr != null)
				{
					if ((int)b >= mallDataType.DownLoadStr.Header.Length || mallDataType.DownLoadStr.Header[(int)b] == string.Empty)
					{
						b = 0;
					}
					itemName = mallDataType.DownLoadStr.Header[(int)b];
				}
			}
			if ((DataManager.Instance.MySysSetting.mPaySetting & 1) > 0)
			{
				if (IGGSDKPlugin.isWXAppInstalled())
				{
					GUIManager.Instance.HideUILock(EUILock.Mall);
					if (IGGGameSDK.Instance.GetRealNameSW() == 1)
					{
						if (!RealNameHelp.Instance.CheckOpenRealNameDlg())
						{
							GUIManager.Instance.ShowUILock(EUILock.WeChatPay);
							if (AntiAddictive.Instance.IsNonage())
							{
								IGGSDKPlugin.WeChatPay(mallDataType.TreasureID.ToString(), itemName, productPriceByID, true, IGGGameSDK.Instance.GetMinorsDailySpendAmount());
							}
							else
							{
								IGGSDKPlugin.WeChatPay(mallDataType.TreasureID.ToString(), itemName, productPriceByID);
							}
						}
					}
					else
					{
						GUIManager.Instance.ShowUILock(EUILock.WeChatPay);
						IGGSDKPlugin.WeChatPay(mallDataType.TreasureID.ToString(), itemName, productPriceByID);
					}
				}
				else
				{
					GUIManager.Instance.OpenMessageBox(dataManager.mStringTable.GetStringByID(614u), dataManager.mStringTable.GetStringByID(9525u), null, null, 0, 0, false, false, false, false, false);
				}
			}
			else if ((DataManager.Instance.MySysSetting.mPaySetting & 2) > 0)
			{
				GUIManager.Instance.HideUILock(EUILock.Mall);
				if (IGGGameSDK.Instance.GetRealNameSW() == 1)
				{
					if (!RealNameHelp.Instance.CheckOpenRealNameDlg())
					{
						GUIManager.Instance.ShowUILock(EUILock.AliPay);
						if (AntiAddictive.Instance.IsNonage())
						{
							IGGSDKPlugin.AliPay(mallDataType.TreasureID.ToString(), itemName, productPriceByID, true, IGGGameSDK.Instance.GetMinorsDailySpendAmount());
						}
						else
						{
							IGGSDKPlugin.AliPay(mallDataType.TreasureID.ToString(), itemName, productPriceByID);
						}
					}
				}
				else
				{
					GUIManager.Instance.ShowUILock(EUILock.AliPay);
					IGGSDKPlugin.AliPay(mallDataType.TreasureID.ToString(), itemName, productPriceByID);
				}
			}
		}
		else
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(868u), 255, true);
		}
		GUIManager.Instance.HideUILock(EUILock.Mall);
	}

	// Token: 0x06002529 RID: 9513 RVA: 0x004290F4 File Offset: 0x004272F4
	public void RecvMall_GetItem(MessagePacket MP)
	{
		string price = null;
		string content_type = string.Empty;
		string content_id = string.Empty;
		string currency = string.Empty;
		DataManager dataManager = DataManager.Instance;
		GUIManager guimanager = GUIManager.Instance;
		ushort num = MP.ReadUShort(-1);
		ushort num2 = MP.ReadUShort(-1);
		if (num != 0)
		{
			int arg = this.FindIndexByGID(num);
			if (num2 != 0)
			{
				MallDataType mallDataType = new MallDataType();
				mallDataType.SN = num2;
				this.MallDataList.Add(mallDataType);
				mallDataType.GroupID = MP.ReadUShort(-1);
				mallDataType.TreasureID = this.TreasureIDTransToNew(MP.ReadUInt(-1));
				mallDataType.PicPackageID1 = MP.ReadUShort(-1);
				mallDataType.SetBuyOnce();
				mallDataType.PicPackageID2 = MP.ReadUShort(-1);
				mallDataType.StrPackageID = MP.ReadUShort(-1);
				mallDataType.Type = (ETreasureType)MP.ReadByte(-1);
				mallDataType.RenderWeight = MP.ReadUShort(-1);
				mallDataType.SetNo = MP.ReadUShort(-1);
				mallDataType.SendAskDownLoad();
			}
			MallDataType mallDataType2 = this.FindDataByGID(num);
			if (mallDataType2 != null)
			{
				price = IGGGameSDK.Instance.GetProductPriceByID((int)mallDataType2.TreasureID);
				content_id = mallDataType2.TreasureID.ToString();
				if (mallDataType2.Type == ETreasureType.ETST_Crystal)
				{
					content_type = dataManager.mStringTable.GetStringByID((uint)mallDataType2.StrPackageID);
				}
				else
				{
					byte b = dataManager.UserLanguage - GameLanguage.GL_Eng;
					if (mallDataType2.DownLoadStr != null)
					{
						if ((int)b >= mallDataType2.DownLoadStr.Header.Length || mallDataType2.DownLoadStr.Header[(int)b] == string.Empty)
						{
							b = 0;
						}
						content_type = mallDataType2.DownLoadStr.Header[(int)b];
					}
				}
				currency = IGGGameSDK.Instance.GetCurrency((int)mallDataType2.TreasureID);
			}
			this.RemoveDataByGID(num);
			this.SortMallData();
			this.ChaekMainPackage();
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_Detail, 1, arg);
		}
		if (num2 == 0)
		{
			MP.ReadUShort(-1);
			MP.ReadUInt(-1);
			MP.ReadUShort(-1);
			MP.ReadUShort(-1);
			MP.ReadUShort(-1);
			MP.ReadByte(-1);
			MP.ReadUShort(-1);
			MP.ReadUShort(-1);
		}
		uint num3 = this.TreasureIDTransToNew(MP.ReadUInt(-1));
		if (num == 0 && num3 != 0u)
		{
			MallDataType mallDataType3 = this.FindDataBySN(this.SendBuySN);
			if (mallDataType3 != null && mallDataType3.TreasureID == num3)
			{
				price = IGGGameSDK.Instance.GetProductPriceByID((int)mallDataType3.TreasureID);
				content_id = mallDataType3.TreasureID.ToString();
				if (mallDataType3.Type == ETreasureType.ETST_Crystal)
				{
					content_type = dataManager.mStringTable.GetStringByID((uint)mallDataType3.StrPackageID);
				}
				else
				{
					byte b2 = dataManager.UserLanguage - GameLanguage.GL_Eng;
					if (mallDataType3.DownLoadStr != null)
					{
						if ((int)b2 >= mallDataType3.DownLoadStr.Header.Length || mallDataType3.DownLoadStr.Header[(int)b2] == string.Empty)
						{
							b2 = 0;
						}
						content_type = mallDataType3.DownLoadStr.Header[(int)b2];
					}
				}
				currency = IGGGameSDK.Instance.GetCurrency((int)mallDataType3.TreasureID);
			}
		}
		bool flag = false;
		if (num3 == 13093u || num3 == MerchantmanManager.Instance.ExtraTreasureID)
		{
			flag = true;
		}
		if (flag)
		{
			price = IGGGameSDK.Instance.GetProductPriceByID((int)num3);
			content_id = num3.ToString();
			content_type = dataManager.mStringTable.GetStringByID(8874u);
			currency = IGGGameSDK.Instance.GetCurrency((int)num3);
		}
		this.SendBuySN = 0;
		if (num != 0)
		{
			this.ClearSendCheckBuySN();
		}
		MP.ReadUShort(-1);
		guimanager.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eMax);
		byte b3 = MP.ReadByte(-1);
		for (int i = 0; i < (int)b3; i++)
		{
			ushort itemID = MP.ReadUShort(-1);
			ushort quantity = MP.ReadUShort(-1);
			byte rare = MP.ReadByte(-1);
			dataManager.SetCurItemQuantity(itemID, quantity, rare, 0L);
		}
		GameManager.OnRefresh(NetworkNews.Refresh, null);
		GameManager.OnRefresh(NetworkNews.Refresh_Attr, null);
		GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
		guimanager.UpdateUI(EGUIWindow.UI_Mall_Detail, 2, 0);
		guimanager.UpdateUI(EGUIWindow.UI_Mall, 2, 0);
		guimanager.AddHUDMessage(dataManager.mStringTable.GetStringByID(867u), 254, true);
		LordEquipData.Instance().Scan_MaterialOrEquipIncreace();
		guimanager.HideUILock(EUILock.Mall);
		string text = this.RePlaceArb(price);
		IGGSDKPlugin.SetFacebookEventPurchases((text != null) ? double.Parse(text) : 0.0, "1", content_type, content_id, currency);
	}

	// Token: 0x0600252A RID: 9514 RVA: 0x00429584 File Offset: 0x00427784
	private unsafe string RePlaceArb(string Price)
	{
		if (Price == null)
		{
			return Price;
		}
		fixed (string text = Price)
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				for (int i = 0; i < Price.Length; i++)
				{
					if (ptr[i] == '٠')
					{
						ptr[i] = '0';
					}
					else if (ptr[i] == '١')
					{
						ptr[i] = '1';
					}
					else if (ptr[i] == '٢')
					{
						ptr[i] = '2';
					}
					else if (ptr[i] == '٣')
					{
						ptr[i] = '3';
					}
					else if (ptr[i] == '٤')
					{
						ptr[i] = '4';
					}
					else if (ptr[i] == '٥')
					{
						ptr[i] = '5';
					}
					else if (ptr[i] == '٦')
					{
						ptr[i] = '6';
					}
					else if (ptr[i] == '٧')
					{
						ptr[i] = '7';
					}
					else if (ptr[i] == '٨')
					{
						ptr[i] = '8';
					}
					else if (ptr[i] == '٩')
					{
						ptr[i] = '9';
					}
					else if (ptr[i] == '٬')
					{
						ptr[i] = ',';
					}
				}
				text = null;
				return Price;
			}
		}
	}

	// Token: 0x0600252B RID: 9515 RVA: 0x004296F8 File Offset: 0x004278F8
	public void RecvTreasure_Monthprize_Info(MessagePacket MP)
	{
		this.mMonthTreasureCrystal = MP.ReadUInt(-1);
		byte b = MP.ReadByte(-1);
		int num = 0;
		while (num < (int)b && num < 200)
		{
			this.mMonthTreasureItem[num].ItemID = MP.ReadUShort(-1);
			this.mMonthTreasureItem[num].Num = MP.ReadUShort(-1);
			this.mMonthTreasureItem[num].ItemRank = MP.ReadByte(-1);
			num++;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_TreasureBox, 7, 0);
	}

	// Token: 0x0600252C RID: 9516 RVA: 0x00429790 File Offset: 0x00427990
	public void RecvTreasure_Get_Monthprize(MessagePacket MP)
	{
		DataManager dataManager = DataManager.Instance;
		GUIManager guimanager = GUIManager.Instance;
		if (MP.ReadByte(-1) == 0)
		{
			this.BuyMonthTreasureTime = MP.ReadLong(-1);
			this.LastGetMonthTreasurePrizeTime = MP.ReadLong(-1);
			uint diamond = MP.ReadUInt(-1);
			guimanager.SetRoleAttrDiamond(diamond, 0, eSpentCredits.eMax);
			byte b = MP.ReadByte(-1);
			int num = 0;
			while (num < (int)b && num < 200)
			{
				this.mMonthTreasureItem[num].ItemID = MP.ReadUShort(-1);
				this.mMonthTreasureItem[num].Num = MP.ReadUShort(-1);
				this.mMonthTreasureItem[num].ItemRank = MP.ReadByte(-1);
				dataManager.SetCurItemQuantity(this.mMonthTreasureItem[num].ItemID, this.mMonthTreasureItem[num].Num, this.mMonthTreasureItem[num].ItemRank, 0L);
				num++;
			}
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			Array.Clear(guimanager.SE_Kind, 0, guimanager.SE_Kind.Length);
			Array.Clear(guimanager.m_SpeciallyEffect.mResValue, 0, guimanager.m_SpeciallyEffect.mResValue.Length);
			Array.Clear(guimanager.SE_ItemID, 0, guimanager.SE_ItemID.Length);
			guimanager.SE_Kind[0] = SpeciallyEffect_Kind.Diamond;
			for (int i = 0; i < 3; i++)
			{
				guimanager.SE_ItemID[i] = this.mMonthTreasureItem[i].ItemID;
			}
			guimanager.mStartV2 = new Vector2(guimanager.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, guimanager.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
			guimanager.m_SpeciallyEffect.AddIconShow(guimanager.mStartV2, guimanager.SE_Kind, guimanager.SE_ItemID, true);
			AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
			this.mMonthTreasure_CDTime = 3.2f;
			this.mShowSec = 1;
			guimanager.UpdateUI(EGUIWindow.UI_TreasureBox, 6, 0);
			guimanager.UpdateUI(EGUIWindow.Door, 23, 0);
		}
		guimanager.HideUILock(EUILock.Mall);
	}

	// Token: 0x0600252D RID: 9517 RVA: 0x004299C8 File Offset: 0x00427BC8
	public void Send_Treasure_Get_Monthprize()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_TREASURE_GET_MONTHPRIZE;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Mall);
	}

	// Token: 0x0600252E RID: 9518 RVA: 0x00429A08 File Offset: 0x00427C08
	public bool CheckBtnShow()
	{
		bool result = false;
		if (this.BuyMonthTreasureTime != 0L && this.LastGetMonthTreasurePrizeTime == 0L)
		{
			result = true;
		}
		else if (this.LastGetMonthTreasurePrizeTime != 0L && DataManager.Instance.ServerTime - MallManager.Instance.LastGetMonthTreasurePrizeTime >= 86400L)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x0600252F RID: 9519 RVA: 0x00429A64 File Offset: 0x00427C64
	public void Send_SPTREASURE_PREBUY_CHECK(ESpcialTreasureType SpTreasureType, uint TreasureID, bool checkPay = true)
	{
		if (checkPay && (DataManager.Instance.MySysSetting.mPaySetting & 4) == 0)
		{
			GUIManager.Instance.OpenMenu(EGUIWindow.UI_PaySetting, (int)TreasureID, (int)(SpTreasureType + 1), false, true, false);
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_SPTREASURE_PREBUY_CHECK;
		messagePacket.AddSeqId();
		messagePacket.Add((byte)SpTreasureType);
		messagePacket.Add(TreasureID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Mall);
	}

	// Token: 0x06002530 RID: 9520 RVA: 0x00429AE4 File Offset: 0x00427CE4
	public void Recv_SPTREASURE_PREBUY_CHECK(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		ESpcialTreasureType espcialTreasureType = (ESpcialTreasureType)MP.ReadByte(-1);
		uint num = MP.ReadUInt(-1);
		if (b == 0)
		{
			num = this.TreasureIDTransToNew(num);
			DataManager dataManager = DataManager.Instance;
			string productTitleByID = IGGGameSDK.Instance.GetProductTitleByID((int)num);
			string productPriceByID = IGGGameSDK.Instance.GetProductPriceByID((int)num);
			if ((DataManager.Instance.MySysSetting.mPaySetting & 1) > 0)
			{
				if (IGGSDKPlugin.isWXAppInstalled())
				{
					GUIManager.Instance.HideUILock(EUILock.Mall);
					if (IGGGameSDK.Instance.GetRealNameSW() == 1)
					{
						if (!RealNameHelp.Instance.CheckOpenRealNameDlg())
						{
							GUIManager.Instance.ShowUILock(EUILock.WeChatPay);
							if (AntiAddictive.Instance.IsNonage())
							{
								IGGSDKPlugin.WeChatPay(num.ToString(), productTitleByID, productPriceByID, true, IGGGameSDK.Instance.GetMinorsDailySpendAmount());
							}
							else
							{
								IGGSDKPlugin.WeChatPay(num.ToString(), productTitleByID, productPriceByID);
							}
						}
					}
					else
					{
						GUIManager.Instance.ShowUILock(EUILock.WeChatPay);
						IGGSDKPlugin.WeChatPay(num.ToString(), productTitleByID, productPriceByID);
					}
				}
				else
				{
					GUIManager.Instance.OpenMessageBox(dataManager.mStringTable.GetStringByID(614u), dataManager.mStringTable.GetStringByID(9525u), null, null, 0, 0, false, false, false, false, false);
				}
			}
			else if ((DataManager.Instance.MySysSetting.mPaySetting & 2) > 0)
			{
				GUIManager.Instance.HideUILock(EUILock.Mall);
				if (IGGGameSDK.Instance.GetRealNameSW() == 1)
				{
					if (!RealNameHelp.Instance.CheckOpenRealNameDlg())
					{
						GUIManager.Instance.ShowUILock(EUILock.AliPay);
						if (AntiAddictive.Instance.IsNonage())
						{
							IGGSDKPlugin.AliPay(num.ToString(), productTitleByID, productPriceByID, true, IGGGameSDK.Instance.GetMinorsDailySpendAmount());
						}
						else
						{
							IGGSDKPlugin.AliPay(num.ToString(), productTitleByID, productPriceByID);
						}
					}
				}
				else
				{
					GUIManager.Instance.ShowUILock(EUILock.AliPay);
					IGGSDKPlugin.AliPay(num.ToString(), productTitleByID, productPriceByID);
				}
			}
		}
		else
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(868u), 255, true);
			if (espcialTreasureType == ESpcialTreasureType.ESTST_Emote)
			{
				this.SendCheckEmojiID = 0;
			}
			else if (espcialTreasureType == ESpcialTreasureType.ESTST_CastleSkin)
			{
				this.SendCheckCastleID = 0;
			}
			else if (espcialTreasureType == ESpcialTreasureType.ESTST_RedPocket)
			{
				this.SendCheckRedPocketID = 0;
			}
		}
		GUIManager.Instance.HideUILock(EUILock.Mall);
	}

	// Token: 0x06002531 RID: 9521 RVA: 0x00429D4C File Offset: 0x00427F4C
	public void Send_TREASUREBACK_PRIZEINFO()
	{
		if (this.FullGift_TreasureItemCount != 0)
		{
			if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall_FG_Detail))
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_FG_Detail, 3, 0);
			}
			else if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_Mall_FG_Detail, 0, 0, false);
			}
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_TREASUREBACK_PRIZEINFO;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Mall);
	}

	// Token: 0x06002532 RID: 9522 RVA: 0x00429DEC File Offset: 0x00427FEC
	public void Recv_TREASUREBACK_PRIZEINFO(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			this.FullGift_TreasureItemCount = MP.ReadByte(-1);
			int num = 0;
			while (num < (int)this.FullGift_TreasureItemCount && num < 200)
			{
				this.FullGift_TreasureItem[num].ItemID = MP.ReadUShort(-1);
				this.FullGift_TreasureItem[num].Num = MP.ReadUShort(-1);
				this.FullGift_TreasureItem[num].ItemRank = MP.ReadByte(-1);
				num++;
			}
			if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Mall_FG_Detail))
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall_FG_Detail, 3, 0);
			}
			else if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_Mall_FG_Detail, 0, 0, false);
			}
		}
		else if (b == 1)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7343u), 255, true);
		}
		else if (b == 2)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7343u), 255, true);
		}
		GUIManager.Instance.HideUILock(EUILock.Mall);
	}

	// Token: 0x06002533 RID: 9523 RVA: 0x00429F40 File Offset: 0x00428140
	public void Recv_TREASUREBACK_RCVPRIZE(MessagePacket MP)
	{
		DataManager dataManager = DataManager.Instance;
		GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eMax);
		byte b = MP.ReadByte(-1);
		for (int i = 0; i < (int)b; i++)
		{
			ushort itemID = MP.ReadUShort(-1);
			ushort quantity = MP.ReadUShort(-1);
			byte rare = MP.ReadByte(-1);
			dataManager.SetCurItemQuantity(itemID, quantity, rare, 0L);
		}
		GameManager.OnRefresh(NetworkNews.Refresh, null);
		GameManager.OnRefresh(NetworkNews.Refresh_Attr, null);
		GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 11, 0);
		GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17510u), 28, true);
		GUIManager.Instance.HideUILock(EUILock.Mall);
	}

	// Token: 0x06002534 RID: 9524 RVA: 0x0042A004 File Offset: 0x00428204
	public void CheckOpenPUSHBACK_PRIZE()
	{
		if (this.BackRewardComboBoxID != 0 && this.BackRewardOpenID == 0 && this.door != null)
		{
			GUIManager guimanager = GUIManager.Instance;
			if (guimanager.FindMenu(EGUIWindow.UIBackReward_Detail) || guimanager.FindMenu(EGUIWindow.UIBackReward))
			{
				return;
			}
			this.bCanOpenMain = true;
			if (!NewbieManager.IsWorking() && !guimanager.CheckInQueue(EGUIWindow.UIBackReward))
			{
				this.BackRewardOpenID = this.BackRewardComboBoxID;
				guimanager.OpenUI_Queued_Restricted(EGUIWindow.UIBackReward, 0, 0, false, 2);
			}
		}
	}

	// Token: 0x06002535 RID: 9525 RVA: 0x0042A0A8 File Offset: 0x004282A8
	public void Send_PUSHBACK_PRIZE()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_PUSHBACK_PRIZE;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Mall);
	}

	// Token: 0x06002536 RID: 9526 RVA: 0x0042A0E8 File Offset: 0x004282E8
	public void Recv_PUSHBACK_PRIZE(MessagePacket MP)
	{
		DataManager dataManager = DataManager.Instance;
		GUIManager guimanager = GUIManager.Instance;
		if (MP.ReadByte(-1) == 0)
		{
			guimanager.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eMax);
			dataManager.RoleAlliance.Money = MP.ReadUInt(-1);
			byte b = MP.ReadByte(-1);
			for (int i = 0; i < (int)b; i++)
			{
				ushort itemID = MP.ReadUShort(-1);
				ushort quantity = MP.ReadUShort(-1);
				byte rare = MP.ReadByte(-1);
				dataManager.SetCurItemQuantity(itemID, quantity, rare, 0L);
			}
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			GameManager.OnRefresh(NetworkNews.Refresh_Attr, null);
			GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
			guimanager.AddHUDMessage(dataManager.mStringTable.GetStringByID(10170u), 254, true);
			LordEquipData.Instance().Scan_MaterialOrEquipIncreace();
		}
		this.BackRewardComboBoxID = 0;
		if (this.door != null)
		{
			if (guimanager.FindMenu(EGUIWindow.UIBackReward_Detail))
			{
				if (this.door.m_WindowStack.Count >= 2)
				{
					this.door.m_WindowStack.RemoveAt(this.door.m_WindowStack.Count - 2);
				}
				this.door.CloseMenu(false);
			}
			else if (guimanager.FindMenu(EGUIWindow.UIBackReward))
			{
				this.door.CloseMenu(false);
			}
		}
		guimanager.HideUILock(EUILock.Mall);
		guimanager.UIQueueLockRelease(EGUIQueueLock.UIQL_Mall);
	}

	// Token: 0x04006F81 RID: 28545
	public const uint IOS_MONTH_ID = 12379u;

	// Token: 0x04006F82 RID: 28546
	public const uint ANDROID_MONTH_ID = 12378u;

	// Token: 0x04006F83 RID: 28547
	public const uint IOS_SMALL_ID = 13097u;

	// Token: 0x04006F84 RID: 28548
	private const uint ANDROID_SMALL_ID = 13093u;

	// Token: 0x04006F85 RID: 28549
	private static MallManager instance;

	// Token: 0x04006F86 RID: 28550
	private Door m_door;

	// Token: 0x04006F87 RID: 28551
	public List<MallDataType> MallDataList = new List<MallDataType>();

	// Token: 0x04006F88 RID: 28552
	private Dictionary<ushort, int> MallMap_SN = new Dictionary<ushort, int>();

	// Token: 0x04006F89 RID: 28553
	private Dictionary<ushort, int> MallMap_GID = new Dictionary<ushort, int>();

	// Token: 0x04006F8A RID: 28554
	public MallDataType MainData;

	// Token: 0x04006F8B RID: 28555
	public bool bNeedUpDateItemPtice;

	// Token: 0x04006F8C RID: 28556
	public Dictionary<int, MallItemPrice> m_MallItemPrice = new Dictionary<int, MallItemPrice>();

	// Token: 0x04006F8D RID: 28557
	public uint _SmallID = 13093u;

	// Token: 0x04006F8E RID: 28558
	public MallDataComparer DataComparer = new MallDataComparer();

	// Token: 0x04006F8F RID: 28559
	private long LastServerTime;

	// Token: 0x04006F90 RID: 28560
	public bool bAskListData;

	// Token: 0x04006F91 RID: 28561
	public bool bRcvMainData;

	// Token: 0x04006F92 RID: 28562
	public bool bCanOpenMain;

	// Token: 0x04006F93 RID: 28563
	public bool bLoginFinish;

	// Token: 0x04006F94 RID: 28564
	public bool AutoMall;

	// Token: 0x04006F95 RID: 28565
	public ushort AutoDetailSN;

	// Token: 0x04006F96 RID: 28566
	public bool bAutoOpenMain;

	// Token: 0x04006F97 RID: 28567
	public bool bSendMallInfo;

	// Token: 0x04006F98 RID: 28568
	public bool bNewbie;

	// Token: 0x04006F99 RID: 28569
	private AssetBundle Default_AssetBundle;

	// Token: 0x04006F9A RID: 28570
	private int Default_AssetBundleKey;

	// Token: 0x04006F9B RID: 28571
	private Sprite[] Default_MainMenuSprite;

	// Token: 0x04006F9C RID: 28572
	private Material Default_Material;

	// Token: 0x04006F9D RID: 28573
	private AssetBundle Main_AssetBundle;

	// Token: 0x04006F9E RID: 28574
	private int Main_AssetBundleKey;

	// Token: 0x04006F9F RID: 28575
	private Sprite[] Main_Sprite;

	// Token: 0x04006FA0 RID: 28576
	private Material Main_Material;

	// Token: 0x04006FA1 RID: 28577
	public int MallUIIndex = -1;

	// Token: 0x04006FA2 RID: 28578
	public float MallUIPos = -1f;

	// Token: 0x04006FA3 RID: 28579
	public int ForgeIndex = -1;

	// Token: 0x04006FA4 RID: 28580
	public int AskForgeCount;

	// Token: 0x04006FA5 RID: 28581
	public int NeedFindFrogeIndex = -1;

	// Token: 0x04006FA6 RID: 28582
	public bool bFirstArrow = true;

	// Token: 0x04006FA7 RID: 28583
	private ushort SendBuySN;

	// Token: 0x04006FA8 RID: 28584
	public ushort SendCheckCastleID;

	// Token: 0x04006FA9 RID: 28585
	public bool bLockBuyCastleID;

	// Token: 0x04006FAA RID: 28586
	public ushort SendCheckEmojiID;

	// Token: 0x04006FAB RID: 28587
	public bool bLockBuyEmojiID;

	// Token: 0x04006FAC RID: 28588
	public ushort SendCheckRedPocketID;

	// Token: 0x04006FAD RID: 28589
	public bool bLockBuyRedPocket;

	// Token: 0x04006FAE RID: 28590
	public uint SendCheckBuySN;

	// Token: 0x04006FAF RID: 28591
	public bool bLockBuy;

	// Token: 0x04006FB0 RID: 28592
	private int ChangePos = -1;

	// Token: 0x04006FB1 RID: 28593
	private ushort MainPackageSN;

	// Token: 0x04006FB2 RID: 28594
	public long BuyMonthTreasureTime;

	// Token: 0x04006FB3 RID: 28595
	public long LastGetMonthTreasurePrizeTime;

	// Token: 0x04006FB4 RID: 28596
	public uint mMonthTreasureCrystal;

	// Token: 0x04006FB5 RID: 28597
	public ComboBoxTBItemDataType[] mMonthTreasureItem = new ComboBoxTBItemDataType[200];

	// Token: 0x04006FB6 RID: 28598
	public float mMonthTreasure_CDTime;

	// Token: 0x04006FB7 RID: 28599
	public byte mShowSec;

	// Token: 0x04006FB8 RID: 28600
	public bool bLevelUpPack;

	// Token: 0x04006FB9 RID: 28601
	public uint FullGift_NowCrystal;

	// Token: 0x04006FBA RID: 28602
	public uint FullGift_MaxCrystal;

	// Token: 0x04006FBB RID: 28603
	public long FullGift_Deadline;

	// Token: 0x04006FBC RID: 28604
	public bool FullGift_bShowEffect;

	// Token: 0x04006FBD RID: 28605
	public byte FullGift_TreasureItemCount;

	// Token: 0x04006FBE RID: 28606
	public ComboBoxTBItemDataType[] FullGift_TreasureItem = new ComboBoxTBItemDataType[200];

	// Token: 0x04006FBF RID: 28607
	public ushort BackRewardOpenID;

	// Token: 0x04006FC0 RID: 28608
	public ushort BackRewardComboBoxID;

	// Token: 0x04006FC1 RID: 28609
	public byte BackRewardItemDataCount;

	// Token: 0x04006FC2 RID: 28610
	public byte[] BackRewardItemData = new byte[40];

	// Token: 0x04006FC3 RID: 28611
	public long PaidDollar = -1L;

	// Token: 0x04006FC4 RID: 28612
	public bool FirstGift_bShowEffect;

	// Token: 0x04006FC5 RID: 28613
	public bool bFindCulture;

	// Token: 0x04006FC6 RID: 28614
	public CultureInfo culture;

	// Token: 0x04006FC7 RID: 28615
	public CultureInfo NormalCulture1 = CultureInfo.CreateSpecificCulture("en-US");

	// Token: 0x04006FC8 RID: 28616
	public CultureInfo NormalCulture2 = CultureInfo.CreateSpecificCulture("ar-SA");

	// Token: 0x04006FC9 RID: 28617
	public string[][] CurrencyToCulture = new string[][]
	{
		new string[]
		{
			"US",
			"en-US"
		},
		new string[]
		{
			"BH",
			"en-US"
		},
		new string[]
		{
			"KH",
			"en-US"
		},
		new string[]
		{
			"KW",
			"en-US"
		},
		new string[]
		{
			"OM",
			"en-US"
		},
		new string[]
		{
			"CN",
			"zh-CN"
		},
		new string[]
		{
			"AT",
			"fr-FR"
		},
		new string[]
		{
			"GR",
			"fr-FR"
		},
		new string[]
		{
			"DE",
			"fr-FR"
		},
		new string[]
		{
			"EE",
			"fr-FR"
		},
		new string[]
		{
			"IE",
			"fr-FR"
		},
		new string[]
		{
			"LV",
			"fr-FR"
		},
		new string[]
		{
			"SK",
			"fr-FR"
		},
		new string[]
		{
			"SI",
			"fr-FR"
		},
		new string[]
		{
			"BE",
			"fr-FR"
		},
		new string[]
		{
			"FR",
			"fr-FR"
		},
		new string[]
		{
			"LU",
			"fr-FR"
		},
		new string[]
		{
			"LT",
			"fr-FR"
		},
		new string[]
		{
			"IT",
			"fr-FR"
		},
		new string[]
		{
			"FI",
			"fr-FR"
		},
		new string[]
		{
			"NL",
			"fr-FR"
		},
		new string[]
		{
			"PT",
			"fr-FR"
		},
		new string[]
		{
			"ES",
			"fr-FR"
		},
		new string[]
		{
			"CY",
			"fr-FR"
		},
		new string[]
		{
			"TW",
			"zh-TW"
		},
		new string[]
		{
			"BR",
			"pt-BR"
		},
		new string[]
		{
			"MX",
			"es-MX"
		},
		new string[]
		{
			"TH",
			"th-TH"
		},
		new string[]
		{
			"RU",
			"fr-FR"
		},
		new string[]
		{
			"JP",
			"ja-JP"
		},
		new string[]
		{
			"KR",
			"ko-KR"
		},
		new string[]
		{
			"ID",
			"id-ID"
		},
		new string[]
		{
			"VN",
			"vi-VN"
		},
		new string[]
		{
			"IN",
			"gu-IN"
		},
		new string[]
		{
			"SG",
			"zh-SG"
		},
		new string[]
		{
			"CA",
			"en-CA"
		},
		new string[]
		{
			"GB",
			"en-GB"
		},
		new string[]
		{
			"AU",
			"zh-CN"
		},
		new string[]
		{
			"MO",
			"zh-MO"
		},
		new string[]
		{
			"PH",
			"en-PH"
		},
		new string[]
		{
			"CO",
			"es-CO"
		},
		new string[]
		{
			"MY",
			"zh-CN"
		},
		new string[]
		{
			"TR",
			"tr-TR"
		},
		new string[]
		{
			"HK",
			"zh-HK"
		},
		new string[]
		{
			"DK",
			"da-DK"
		},
		new string[]
		{
			"IL",
			"he-IL"
		},
		new string[]
		{
			"BG",
			"bg-BG"
		},
		new string[]
		{
			"HR",
			"hr-HR"
		},
		new string[]
		{
			"LI",
			"de-CH"
		},
		new string[]
		{
			"CH",
			"de-CH"
		},
		new string[]
		{
			"HU",
			"hu-HU"
		},
		new string[]
		{
			"ZA",
			"fr-FR"
		},
		new string[]
		{
			"KZ",
			"fr-FR"
		},
		new string[]
		{
			"CR",
			"es-CR"
		},
		new string[]
		{
			"PK",
			"zh-CN"
		},
		new string[]
		{
			"NO",
			"nn-NO"
		},
		new string[]
		{
			"CZ",
			"cs-CZ"
		},
		new string[]
		{
			"CL",
			"es-CL"
		},
		new string[]
		{
			"PL",
			"pl-PL"
		},
		new string[]
		{
			"UA",
			"uk-UA"
		},
		new string[]
		{
			"BO",
			"es-BO"
		},
		new string[]
		{
			"SE",
			"sv-SE"
		},
		new string[]
		{
			"PE",
			"es-PE"
		},
		new string[]
		{
			"NZ",
			"zh-CN"
		},
		new string[]
		{
			"RO",
			"ro-RO"
		},
		new string[]
		{
			"KE",
			"sw-KE"
		},
		new string[]
		{
			"LK",
			"zh-CN"
		},
		new string[]
		{
			"NG",
			"zh-CN"
		},
		new string[]
		{
			"GH",
			"en-US"
		},
		new string[]
		{
			"TZ",
			"sw-KE"
		},
		new string[]
		{
			"BD",
			"gu-IN"
		},
		new string[]
		{
			"BY",
			"be-BY"
		},
		new string[]
		{
			"UA",
			"ar-SA"
		},
		new string[]
		{
			"QA",
			"ar-QA"
		},
		new string[]
		{
			"EG",
			"ar-EG"
		},
		new string[]
		{
			"LB",
			"ar-SA"
		},
		new string[]
		{
			"DZ",
			"ar-DZ"
		},
		new string[]
		{
			"SA",
			"ar-SA"
		},
		new string[]
		{
			"MA",
			"ar-MA"
		}
	};
}
