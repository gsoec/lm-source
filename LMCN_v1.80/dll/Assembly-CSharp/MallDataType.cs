using System;
using UnityEngine;

// Token: 0x02000771 RID: 1905
public class MallDataType
{
	// Token: 0x060024DE RID: 9438 RVA: 0x00424348 File Offset: 0x00422548
	public MallDataType()
	{
		this.Initial();
	}

	// Token: 0x060024DF RID: 9439 RVA: 0x00424398 File Offset: 0x00422598
	public void SetBuyOnce()
	{
		this.BuyOncePic = (byte)(this.PicPackageID1 / 10000);
		this.PicPackageID1 %= 10000;
	}

	// Token: 0x060024E0 RID: 9440 RVA: 0x004243CC File Offset: 0x004225CC
	public void SendAskDownLoad()
	{
		if (this.Type == ETreasureType.ETST_Crystal)
		{
			return;
		}
		if (this.m_AssetBundleKey == 0 && this.PicPackageID1 != 0)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat((long)this.PicPackageID1, 1, false);
			cstring.AppendFormat("Store/Mallback_{0}");
			if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Store, AssetType.MallBack, this.PicPackageID1, false))
			{
				this.bDownLoadPic = true;
			}
		}
		if (this.PicPackageID2 != 0)
		{
			MallManager instance = MallManager.Instance;
			ushort num = this.PicPackageID2 + 1000;
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.IntToFormat((long)num, 1, false);
			cstring2.AppendFormat("Store/Mallback_{0}");
			if (AssetManager.GetAssetBundleDownload(cstring2, AssetPath.Store, AssetType.MallBack, num, false) && instance.MainData != null && instance.MainData.PicPackageID2 == this.PicPackageID2)
			{
				instance.LoadMainPackege(num);
				instance.SetMainPackage();
			}
		}
		if (this.m_StrAssetBundleKey == 0 && this.StrPackageID != 0)
		{
			CString cstring3 = StringManager.Instance.StaticString1024();
			cstring3.IntToFormat((long)this.StrPackageID, 1, false);
			cstring3.AppendFormat("Store/Package_{0}");
			if (AssetManager.GetAssetBundleDownload(cstring3, AssetPath.Store, AssetType.MallPackage, this.StrPackageID, false))
			{
				this.bDownLoadStr = true;
			}
		}
		MallManager.Instance.CheckOpenMain();
	}

	// Token: 0x060024E1 RID: 9441 RVA: 0x00424520 File Offset: 0x00422720
	public void Initial()
	{
		this.bAskListData = false;
		this.bAskDetailData = false;
		this.SN = 0;
		this.GroupID = 0;
		this.TreasureID = 0u;
		this.PicPackageID1 = 0;
		this.PicPackageID2 = 0;
		this.StrPackageID = 0;
		this.Type = ETreasureType.ETST_NULL;
		this.PosType = 0;
		this.BonusRate = 0;
		this.TotalCrystal = 0u;
		this.BonusCrystal = 0u;
		this.EndTime = 0L;
		this.FrameColor = Color.white;
		this.LineColor = Color.white;
		this.RenderWeight = 0;
		this.ComboBoxID = 0;
		this.StampPic = 0;
		this.Discount = 0;
		this.ExtraByte = 0;
		Array.Clear(this.ExtraData, 0, this.ExtraData.Length);
		this.SetNo = 0;
		Array.Clear(this.AllianceGift, 0, this.AllianceGift.Length);
		this.DataLen = 0;
		Array.Clear(this.Item, 0, this.Item.Length);
		this.AllianceGiftShowTop = 0;
		this.uTime = 0u;
		this.m_AssetBundle = null;
		this.m_AssetBundleKey = 0;
		this.m_BackImage1 = null;
		this.m_BackImage2 = null;
		this.m_Material = null;
		this.DownLoadStr = null;
		this.m_StrAssetBundle = null;
		this.m_StrAssetBundleKey = 0;
		this.bDownLoadPic = false;
		this.bDownLoadStr = false;
		this.bUpDatePic = false;
		this.bUpDateStr = false;
		this.bABUseInUI = false;
		this.BuyOncePic = 0;
	}

	// Token: 0x060024E2 RID: 9442 RVA: 0x00424684 File Offset: 0x00422884
	public void InitialAB()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		if (this.PicPackageID1 != 0)
		{
			cstring.IntToFormat((long)this.PicPackageID1, 1, false);
			cstring.AppendFormat("Store/Mallback_{0}");
		}
		else
		{
			cstring.Append("UI/Mall_0");
		}
		this.m_AssetBundle = AssetManager.GetAssetBundle(cstring, out this.m_AssetBundleKey);
		if (this.m_AssetBundle != null)
		{
			this.m_Material = (this.m_AssetBundle.Load("Mall_m", typeof(Material)) as Material);
			UnityEngine.Object[] array = this.m_AssetBundle.LoadAll(typeof(Sprite));
			for (int i = 0; i < array.Length; i++)
			{
				ushort num = ushort.Parse(array[i].name);
				if (num == 100)
				{
					this.m_BackImage1 = (Sprite)array[i];
				}
				else if (num == 200)
				{
					this.m_BackImage2 = (Sprite)array[i];
				}
			}
		}
	}

	// Token: 0x060024E3 RID: 9443 RVA: 0x00424788 File Offset: 0x00422988
	public void UnloadBackAB(bool UnloadAll = true)
	{
		if (this.m_AssetBundleKey != 0)
		{
			this.m_Material = null;
			this.m_BackImage1 = null;
			this.m_BackImage2 = null;
			AssetManager.UnloadAssetBundle(this.m_AssetBundleKey, UnloadAll);
			this.m_AssetBundle = null;
			this.m_AssetBundleKey = 0;
		}
	}

	// Token: 0x060024E4 RID: 9444 RVA: 0x004247D0 File Offset: 0x004229D0
	public void InitialABString()
	{
		if (this.StrPackageID == 0)
		{
			return;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)this.StrPackageID, 1, false);
		cstring.AppendFormat("Store/Package_{0}");
		this.m_StrAssetBundle = AssetManager.GetAssetBundle(cstring, out this.m_StrAssetBundleKey);
		if (this.m_StrAssetBundle != null)
		{
			this.DownLoadStr = (this.m_StrAssetBundle.Load("Package", typeof(Download)) as Download);
		}
	}

	// Token: 0x060024E5 RID: 9445 RVA: 0x00424858 File Offset: 0x00422A58
	public void UnloadStrAB()
	{
		if (this.m_StrAssetBundleKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.m_StrAssetBundleKey, true);
			this.m_StrAssetBundle = null;
			this.m_StrAssetBundleKey = 0;
		}
	}

	// Token: 0x060024E6 RID: 9446 RVA: 0x00424880 File Offset: 0x00422A80
	public void UnloadAB(bool UnloadAll = true)
	{
		this.UnloadBackAB(UnloadAll);
		this.UnloadStrAB();
	}

	// Token: 0x04006F54 RID: 28500
	public bool bAskListData;

	// Token: 0x04006F55 RID: 28501
	public bool bAskDetailData;

	// Token: 0x04006F56 RID: 28502
	public ushort SN;

	// Token: 0x04006F57 RID: 28503
	public ushort GroupID;

	// Token: 0x04006F58 RID: 28504
	public uint TreasureID;

	// Token: 0x04006F59 RID: 28505
	public ushort PicPackageID1;

	// Token: 0x04006F5A RID: 28506
	public ushort PicPackageID2;

	// Token: 0x04006F5B RID: 28507
	public ushort StrPackageID;

	// Token: 0x04006F5C RID: 28508
	public ETreasureType Type;

	// Token: 0x04006F5D RID: 28509
	public byte PosType;

	// Token: 0x04006F5E RID: 28510
	public byte BonusRate;

	// Token: 0x04006F5F RID: 28511
	public byte bBuyOnce;

	// Token: 0x04006F60 RID: 28512
	public uint TotalCrystal;

	// Token: 0x04006F61 RID: 28513
	public uint BonusCrystal;

	// Token: 0x04006F62 RID: 28514
	public long EndTime;

	// Token: 0x04006F63 RID: 28515
	public Color FrameColor;

	// Token: 0x04006F64 RID: 28516
	public Color LineColor;

	// Token: 0x04006F65 RID: 28517
	public ushort RenderWeight;

	// Token: 0x04006F66 RID: 28518
	public ushort ComboBoxID;

	// Token: 0x04006F67 RID: 28519
	public ComboBoxTBItemDataType[] BriefItem = new ComboBoxTBItemDataType[3];

	// Token: 0x04006F68 RID: 28520
	public ushort StampPic;

	// Token: 0x04006F69 RID: 28521
	public ushort StampHint;

	// Token: 0x04006F6A RID: 28522
	public byte Discount;

	// Token: 0x04006F6B RID: 28523
	public byte ExtraByte;

	// Token: 0x04006F6C RID: 28524
	public ushort[] ExtraData = new ushort[3];

	// Token: 0x04006F6D RID: 28525
	public ushort SetNo;

	// Token: 0x04006F6E RID: 28526
	public TreasureAllianceGiftDataType[] AllianceGift = new TreasureAllianceGiftDataType[5];

	// Token: 0x04006F6F RID: 28527
	public byte DataLen;

	// Token: 0x04006F70 RID: 28528
	public ComboBoxTBItemDataType[] Item = new ComboBoxTBItemDataType[200];

	// Token: 0x04006F71 RID: 28529
	public byte AllianceGiftShowTop;

	// Token: 0x04006F72 RID: 28530
	public uint uTime;

	// Token: 0x04006F73 RID: 28531
	public AssetBundle m_AssetBundle;

	// Token: 0x04006F74 RID: 28532
	public int m_AssetBundleKey;

	// Token: 0x04006F75 RID: 28533
	public Sprite m_BackImage1;

	// Token: 0x04006F76 RID: 28534
	public Sprite m_BackImage2;

	// Token: 0x04006F77 RID: 28535
	public Material m_Material;

	// Token: 0x04006F78 RID: 28536
	public AssetBundle m_StrAssetBundle;

	// Token: 0x04006F79 RID: 28537
	public int m_StrAssetBundleKey;

	// Token: 0x04006F7A RID: 28538
	public Download DownLoadStr;

	// Token: 0x04006F7B RID: 28539
	public bool bDownLoadPic;

	// Token: 0x04006F7C RID: 28540
	public bool bDownLoadStr;

	// Token: 0x04006F7D RID: 28541
	public bool bUpDatePic;

	// Token: 0x04006F7E RID: 28542
	public bool bUpDateStr;

	// Token: 0x04006F7F RID: 28543
	public bool bABUseInUI;

	// Token: 0x04006F80 RID: 28544
	public byte BuyOncePic;
}
