using System;
using System.IO;
using UnityEngine;

// Token: 0x02000344 RID: 836
public class CastleSkin
{
	// Token: 0x06001125 RID: 4389 RVA: 0x001E6978 File Offset: 0x001E4B78
	public CastleSkin()
	{
		this.tmpAssetName = new CString(256);
	}

	// Token: 0x06001126 RID: 4390 RVA: 0x001E69B0 File Offset: 0x001E4BB0
	public void SortDirty()
	{
		this.SortType = CastleSkin._SortType.None;
	}

	// Token: 0x17000082 RID: 130
	// (get) Token: 0x06001127 RID: 4391 RVA: 0x001E69BC File Offset: 0x001E4BBC
	public CastleSkin._SortType curSortType
	{
		get
		{
			return this.SortType;
		}
	}

	// Token: 0x17000083 RID: 131
	// (get) Token: 0x06001128 RID: 4392 RVA: 0x001E69C4 File Offset: 0x001E4BC4
	public byte[] SkinUnlock
	{
		get
		{
			return this.CastleSwitch;
		}
	}

	// Token: 0x17000084 RID: 132
	// (get) Token: 0x06001129 RID: 4393 RVA: 0x001E69CC File Offset: 0x001E4BCC
	public byte[] SkinLevel
	{
		get
		{
			return this.CastleEnhance;
		}
	}

	// Token: 0x0600112A RID: 4394 RVA: 0x001E69D4 File Offset: 0x001E4BD4
	public void LoadTable()
	{
		this.CastleSkinTable = new CExternalTableWithWordKey<CastleSkinTbl>();
		this.CastleEnhanceTable = new CExternalTableWithWordKey<CastleEnhanceTbl>();
		this.CastleSkinTable.LoadTable("Castleunlock");
		byte b = 0;
		for (int i = 0; i < this.CastleSkinTable.TableCount; i++)
		{
			byte b2 = this.CastleSkinTable.GetRecordByIndex(i).Graphic;
			if (b < b2)
			{
				b = b2;
			}
		}
		this.CastleEnhanceIndexTable = new ushort[(int)this.CastleSkinTable.MapCount];
		int tableCount = this.CastleSkinTable.TableCount;
		this.AllAssetID = new int[(int)b];
		this.AllSprite = new Sprite[(int)b];
		this.AllMaterial = new Material[(int)b];
		this.GraphicNameIndex = new ushort[(int)b];
		this.DefaultExclamation = new byte[(this.CastleSkinTable.TableCount >> 3) + (((this.CastleSkinTable.TableCount & 7) <= 0) ? 0 : 1)];
		this.SortCastleID = new ushort[tableCount];
		this.ActiveCastleID = 0;
		byte b3 = 0;
		for (int j = 0; j < this.CastleSkinTable.TableCount; j++)
		{
			CastleSkinTbl recordByIndex = this.CastleSkinTable.GetRecordByIndex(j);
			byte b2 = recordByIndex.Graphic;
			if (b2 == 1 || b2 == 2)
			{
				b2 = 0;
			}
			int num = 0;
			if (b2 > 0)
			{
				num = (int)(b2 - 2);
			}
			if (recordByIndex.DefaultExclamation == 0)
			{
				this.SetBitField((byte)recordByIndex.ID, this.DefaultExclamation);
			}
			this.GraphicNameIndex[num] = recordByIndex.Name;
			if (recordByIndex.Priority != 255 && recordByIndex.Priority > b3)
			{
				b3 = recordByIndex.Priority;
				this.ActiveCastleID = recordByIndex.ID;
			}
		}
		this.CastleEnhanceTable.LoadTable("CastleEnhance");
		ushort num2 = 255;
		for (int k = 0; k < this.CastleEnhanceTable.TableCount; k++)
		{
			CastleEnhanceTbl recordByIndex2 = this.CastleEnhanceTable.GetRecordByIndex(k);
			if (num2 != recordByIndex2.CastleID)
			{
				num2 = recordByIndex2.CastleID;
				if ((int)num2 <= this.CastleEnhanceIndexTable.Length)
				{
					this.CastleEnhanceIndexTable[(int)(num2 - 1)] = recordByIndex2.ID;
				}
			}
		}
	}

	// Token: 0x0600112B RID: 4395 RVA: 0x001E6C1C File Offset: 0x001E4E1C
	public CastleEnhanceTbl GetCastleEnhanceData(byte CastleID, byte Rank)
	{
		if (CastleID == 0 || Rank > 5)
		{
			return default(CastleEnhanceTbl);
		}
		return this.CastleEnhanceTable.GetRecordByKey(this.CastleEnhanceIndexTable[(int)(CastleID - 1)] + (ushort)Rank);
	}

	// Token: 0x0600112C RID: 4396 RVA: 0x001E6C58 File Offset: 0x001E4E58
	private void LoadCastleSkinSave()
	{
		if (this.SaveExclamationData == null)
		{
			byte b = 5;
			try
			{
				this.tmpAssetName.ClearString();
				this.tmpAssetName.StringToFormat(AssetManager.persistentDataPath);
				this.tmpAssetName.IntToFormat(DataManager.Instance.RoleAttr.UserId, 1, false);
				this.tmpAssetName.StringToFormat(this.ExclamationSaveName);
				this.tmpAssetName.AppendFormat("{0}/Data/{1}{2}");
				this.tmpAssetName.SetLength(this.tmpAssetName.Length);
				using (FileStream fileStream = new FileStream(this.tmpAssetName.ToString(), FileMode.OpenOrCreate, FileAccess.Read))
				{
					if (fileStream.Length > 0L)
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							b = binaryReader.ReadByte();
							this.SaveExclamationData = binaryReader.ReadBytes((int)b);
							this.UnlockCastleSkinNotice = binaryReader.ReadByte();
						}
					}
					else
					{
						this.SaveExclamationData = new byte[(int)b];
						Array.Copy(this.DefaultExclamation, this.SaveExclamationData, Math.Min(this.DefaultExclamation.Length, this.SaveExclamationData.Length));
					}
				}
				this.tmpAssetName.SetLength(this.tmpAssetName.MaxLength);
			}
			catch (Exception ex)
			{
				this.SaveExclamationData = new byte[(int)b];
				Array.Copy(this.DefaultExclamation, this.SaveExclamationData, Math.Min(this.DefaultExclamation.Length, this.SaveExclamationData.Length));
			}
		}
		if (this.CastleSwitch.Length != this.SaveExclamationData.Length)
		{
			byte[] array = new byte[this.CastleSwitch.Length];
			Array.Copy(this.SaveExclamationData, array, this.SaveExclamationData.Length);
			this.SaveExclamationData = array;
		}
	}

	// Token: 0x0600112D RID: 4397 RVA: 0x001E6E68 File Offset: 0x001E5068
	private void UpdateExclamationCount()
	{
		this.ExclamationCount = (byte)this.CastleSkinTable.TableCount;
		for (int i = 0; i < this.SaveExclamationData.Length; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				if (((int)this.SaveExclamationData[i] & 1 << j) > 0 && this.ExclamationCount > 0)
				{
					this.ExclamationCount -= 1;
				}
			}
		}
		if (this.UnlockCastleSkinNotice == 0 && this.ExclamationCount == 0)
		{
			this.UnlockCastleSkinNotice = 1;
		}
	}

	// Token: 0x0600112E RID: 4398 RVA: 0x001E6F00 File Offset: 0x001E5100
	public byte GetExclamationCount()
	{
		return this.ExclamationCount;
	}

	// Token: 0x0600112F RID: 4399 RVA: 0x001E6F08 File Offset: 0x001E5108
	public void SaveCastleSkinSave()
	{
		try
		{
			this.tmpAssetName.ClearString();
			this.tmpAssetName.StringToFormat(AssetManager.persistentDataPath);
			this.tmpAssetName.IntToFormat(DataManager.Instance.RoleAttr.UserId, 1, false);
			this.tmpAssetName.StringToFormat(this.ExclamationSaveName);
			this.tmpAssetName.AppendFormat("{0}/Data/{1}{2}");
			this.tmpAssetName.SetLength(this.tmpAssetName.Length);
			using (FileStream fileStream = new FileStream(this.tmpAssetName.ToString(), FileMode.OpenOrCreate))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
				{
					binaryWriter.Write((byte)this.SaveExclamationData.Length);
					binaryWriter.Write(this.SaveExclamationData, 0, this.SaveExclamationData.Length);
					binaryWriter.Write(this.UnlockCastleSkinNotice);
				}
			}
			this.tmpAssetName.SetLength(this.tmpAssetName.MaxLength);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06001130 RID: 4400 RVA: 0x001E7068 File Offset: 0x001E5268
	public bool CheckShowCastleSkin()
	{
		return GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 9;
	}

	// Token: 0x06001131 RID: 4401 RVA: 0x001E7098 File Offset: 0x001E5298
	public bool CheckShowExclamation(bool bCheckNewbie = false)
	{
		byte level = GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level;
		bool result = false;
		if (this.ExclamationCount > 0)
		{
			result = true;
		}
		else if (bCheckNewbie && ((level >= 9 && this.UnlockCastleSkinNotice == 0) || (level >= 25 && !DataManager.Instance.CheckPrizeFlag(21))))
		{
			result = true;
		}
		return result;
	}

	// Token: 0x06001132 RID: 4402 RVA: 0x001E710C File Offset: 0x001E530C
	public bool CheckSelect(byte ID)
	{
		return this.CheckBitField(ID, this.SaveExclamationData);
	}

	// Token: 0x06001133 RID: 4403 RVA: 0x001E711C File Offset: 0x001E531C
	public void SetSelect(byte ID)
	{
		bool flag = this.CheckSelect(ID);
		this.SetBitField(ID, this.SaveExclamationData);
		if (flag != this.CheckSelect(ID) && this.ExclamationCount > 0)
		{
			this.ExclamationCount -= 1;
			if (this.ExclamationCount == 0)
			{
				GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
			}
		}
	}

	// Token: 0x06001134 RID: 4404 RVA: 0x001E7188 File Offset: 0x001E5388
	public bool CheckUnlock(byte ID)
	{
		return this.CheckBitField(ID, this.CastleSwitch);
	}

	// Token: 0x06001135 RID: 4405 RVA: 0x001E7198 File Offset: 0x001E5398
	public void SetUnlock(byte ID)
	{
		this.SetBitField(ID, this.CastleSwitch);
	}

	// Token: 0x06001136 RID: 4406 RVA: 0x001E71A8 File Offset: 0x001E53A8
	private bool CheckBitField(byte ID, byte[] Array)
	{
		if (ID == 0)
		{
			return false;
		}
		int num = (ID -= 1) >> 3;
		int num2 = (int)(ID & 7);
		return num < Array.Length && ((int)Array[num] & 1 << num2) > 0;
	}

	// Token: 0x06001137 RID: 4407 RVA: 0x001E71F0 File Offset: 0x001E53F0
	private void SetBitField(byte ID, byte[] Array)
	{
		if (ID == 0)
		{
			return;
		}
		int num = (ID -= 1) >> 3;
		int num2 = (int)(ID & 7);
		if (num < Array.Length)
		{
			int num3 = num;
			Array[num3] |= (byte)(1 << num2);
		}
	}

	// Token: 0x06001138 RID: 4408 RVA: 0x001E7230 File Offset: 0x001E5430
	public byte GetCastleEnhance(byte ID)
	{
		if (ID == 0)
		{
			return 0;
		}
		return this.CastleEnhance[(int)(ID - 1)];
	}

	// Token: 0x06001139 RID: 4409 RVA: 0x001E7244 File Offset: 0x001E5444
	private void Load(byte ID, byte Level)
	{
		if (this.AssetID != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetID, true);
		}
		this.tmpAssetName.ClearString();
		byte graphic = this.CastleSkinTable.GetRecordByKey((ushort)ID).Graphic;
		if (graphic > 0)
		{
			this.tmpAssetName.IntToFormat((long)graphic, 3, false);
			this.tmpAssetName.AppendFormat("UI/castle_{0}");
		}
		else
		{
			this.tmpAssetName.IntToFormat((long)graphic, 3, false);
			byte b = 1;
			if (Level >= 9 && Level < 17)
			{
				b = 2;
			}
			else if (Level >= 17 && Level < 25)
			{
				b = 3;
			}
			else if (Level >= 25)
			{
				b = 4;
			}
			this.tmpAssetName.IntToFormat((long)b, 1, false);
			this.tmpAssetName.AppendFormat("UI/castle_{0}-{1}");
		}
		AssetBundle assetBundle = AssetManager.GetAssetBundle(this.tmpAssetName, out this.AssetID);
		this.CastleID = ID;
		this.Level = Level;
		if (assetBundle == null)
		{
			if (this.AssetID != 0)
			{
				AssetManager.UnloadAssetBundle(this.AssetID, true);
			}
			this.AssetID = 0;
			this.LoadDefault(Level);
			this.sprite = this.defaultSprite;
			this.material = this.defaultMaterial;
			return;
		}
		UnityEngine.Object[] array = assetBundle.LoadAll();
		this.sprite = (array[1] as Sprite);
		this.material = (array[3] as Material);
	}

	// Token: 0x0600113A RID: 4410 RVA: 0x001E73AC File Offset: 0x001E55AC
	private void LoadDefault(byte Level)
	{
		if (this.defaultSprite != null)
		{
			return;
		}
		byte b = 0;
		this.tmpAssetName.ClearString();
		this.tmpAssetName.IntToFormat((long)b, 3, false);
		byte b2 = 1;
		if (Level >= 9 && Level < 17)
		{
			b2 = 2;
		}
		else if (Level >= 17 && Level < 25)
		{
			b2 = 3;
		}
		else if (Level >= 25)
		{
			b2 = 4;
		}
		this.tmpAssetName.IntToFormat((long)b2, 1, false);
		this.tmpAssetName.AppendFormat("UI/castle_{0}-{1}");
		AssetBundle assetBundle = AssetManager.GetAssetBundle(this.tmpAssetName, out this.AssetID);
		if (assetBundle == null)
		{
			if (this.AssetID != 0)
			{
				AssetManager.UnloadAssetBundle(this.AssetID, true);
			}
			this.AssetID = 0;
			this.defaultSprite = GUIManager.Instance.BuildingData.GetBuildSprite(13, 0);
			this.defaultMaterial = GUIManager.Instance.MapSpriteMaterial;
			this.defaultMaterialUI = GUIManager.Instance.MapSpriteUIMaterial;
			return;
		}
		UnityEngine.Object[] array = assetBundle.LoadAll();
		this.defaultSprite = (array[1] as Sprite);
		this.defaultMaterial = (array[3] as Material);
		this.defaultMaterialUI = (array[4] as Material);
	}

	// Token: 0x0600113B RID: 4411 RVA: 0x001E74E8 File Offset: 0x001E56E8
	public Material GetMaterial(byte ID, byte Level = 0)
	{
		if (this.material == null || (ID > 1 && this.CastleID != ID) || (ID == 1 && (this.CastleID != ID || this.Level != Level)))
		{
			this.Load(ID, Level);
		}
		return this.material;
	}

	// Token: 0x0600113C RID: 4412 RVA: 0x001E7548 File Offset: 0x001E5748
	public Sprite GetSprite(byte ID, byte Level = 0)
	{
		if (this.sprite == null || (ID > 1 && this.CastleID != ID) || (ID == 1 && (this.CastleID != ID || this.Level != Level)))
		{
			this.Load(ID, Level);
		}
		return this.sprite;
	}

	// Token: 0x0600113D RID: 4413 RVA: 0x001E75A8 File Offset: 0x001E57A8
	public void Destroy()
	{
		if (this.AssetID != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetID, true);
		}
		this.AssetID = (int)(this.CastleID = 0);
	}

	// Token: 0x0600113E RID: 4414 RVA: 0x001E75DC File Offset: 0x001E57DC
	public void KeepCastleSkinUI()
	{
		this.bUILoaded = 2;
	}

	// Token: 0x0600113F RID: 4415 RVA: 0x001E75E8 File Offset: 0x001E57E8
	public void ClearCastleSkinUI(bool CleanImmediate = false)
	{
		if (this.bUILoaded == 0)
		{
			return;
		}
		if (this.bUILoaded > 1 && !CleanImmediate)
		{
			this.bUILoaded = 1;
			return;
		}
		for (int i = 0; i < this.AllAssetID.Length; i++)
		{
			AssetManager.UnloadAssetBundle(this.AllAssetID[i], true);
			this.AllAssetID[i] = 0;
		}
		this.bUILoaded = 0;
	}

	// Token: 0x06001140 RID: 4416 RVA: 0x001E7654 File Offset: 0x001E5854
	private void LoadUISprite(byte ID, byte Level = 0)
	{
		if (ID == 1 || ID == 2)
		{
			return;
		}
		int num = 0;
		if (ID > 0)
		{
			num = (int)(ID - 2);
		}
		if (this.AllAssetID[num] != 0)
		{
			return;
		}
		this.tmpAssetName.ClearString();
		if (ID > 0)
		{
			this.tmpAssetName.IntToFormat((long)ID, 3, false);
			this.tmpAssetName.AppendFormat("UI/castle_{0}");
		}
		else
		{
			this.UILevel = Level;
			this.tmpAssetName.IntToFormat((long)ID, 3, false);
			byte b = 1;
			if (Level >= 9 && Level < 17)
			{
				b = 2;
			}
			else if (Level >= 17 && Level < 25)
			{
				b = 3;
			}
			else if (Level >= 25)
			{
				b = 4;
			}
			this.tmpAssetName.IntToFormat((long)b, 1, false);
			this.tmpAssetName.AppendFormat("UI/castle_{0}-{1}");
		}
		AssetBundle assetBundle = AssetManager.GetAssetBundle(this.tmpAssetName, out this.AllAssetID[num]);
		if (assetBundle == null)
		{
			if (this.AllAssetID[num] != 0)
			{
				AssetManager.UnloadAssetBundle(this.AllAssetID[num], true);
			}
			this.AllAssetID[num] = 0;
			this.LoadDefault(0);
			this.AllSprite[num] = this.defaultSprite;
			this.AllMaterial[num] = this.defaultMaterialUI;
			return;
		}
		UnityEngine.Object[] array = assetBundle.LoadAll();
		this.AllSprite[num] = (array[1] as Sprite);
		this.AllMaterial[num] = (array[4] as Material);
		this.bUILoaded = 1;
	}

	// Token: 0x06001141 RID: 4417 RVA: 0x001E77D0 File Offset: 0x001E59D0
	public Sprite GetUISprite(byte ID, byte Level = 0)
	{
		if (ID == 1 || ID == 2)
		{
			ID = 0;
		}
		int num = 0;
		if (ID > 0)
		{
			num = (int)(ID - 2);
		}
		if (num >= this.AllAssetID.Length)
		{
			this.LoadDefault(0);
			return this.defaultSprite;
		}
		if (this.AllAssetID[num] == 0)
		{
			this.LoadUISprite(ID, Level);
		}
		else if (ID == 0 && this.UILevel != Level)
		{
			AssetManager.UnloadAssetBundle(this.AllAssetID[num], true);
			this.AllAssetID[num] = 0;
			this.LoadUISprite(ID, Level);
		}
		if (this.AllSprite[num] == null)
		{
			this.LoadDefault(0);
			return this.defaultSprite;
		}
		return this.AllSprite[num];
	}

	// Token: 0x06001142 RID: 4418 RVA: 0x001E788C File Offset: 0x001E5A8C
	public Material GetUIMaterial(byte ID, byte Level = 0)
	{
		if (ID == 1 || ID == 2)
		{
			ID = 0;
		}
		int num = 0;
		if (ID > 0)
		{
			num = (int)(ID - 2);
		}
		if (num >= this.AllAssetID.Length)
		{
			this.LoadDefault(0);
			return this.defaultMaterialUI;
		}
		if (this.AllAssetID[num] == 0)
		{
			this.LoadUISprite(ID, Level);
		}
		else if (ID == 0 && this.UILevel != Level)
		{
			AssetManager.UnloadAssetBundle(this.AllAssetID[num], true);
			this.AllAssetID[num] = 0;
			this.LoadUISprite(ID, Level);
		}
		if (this.AllMaterial[num] == null)
		{
			this.LoadDefault(0);
			return this.defaultMaterialUI;
		}
		return this.AllMaterial[num];
	}

	// Token: 0x06001143 RID: 4419 RVA: 0x001E7948 File Offset: 0x001E5B48
	public string GetCastleSkinName(byte graphicID)
	{
		if (graphicID == 1 || graphicID == 2)
		{
			graphicID = 0;
		}
		int num = 0;
		if (graphicID > 0)
		{
			num = (int)(graphicID - 2);
		}
		if (num >= this.GraphicNameIndex.Length || this.GraphicNameIndex[num] == 0)
		{
			return string.Empty;
		}
		return DataManager.Instance.mStringTable.GetStringByID((uint)this.GraphicNameIndex[num]);
	}

	// Token: 0x06001144 RID: 4420 RVA: 0x001E79AC File Offset: 0x001E5BAC
	private void UnlockMall()
	{
		if (MallManager.Instance.bLockBuyCastleID && MallManager.Instance.SendCheckCastleID != 0 && this.CheckUnlock((byte)MallManager.Instance.SendCheckCastleID))
		{
			MallManager.Instance.ClearSendCheckBuySN();
		}
	}

	// Token: 0x06001145 RID: 4421 RVA: 0x001E79F8 File Offset: 0x001E5BF8
	public void RecvCastleUnlockdata(MessagePacket Mp)
	{
		GUIManager.Instance.BuildingData.CastleID = Mp.ReadByte(-1);
		byte b = Mp.ReadByte(-1);
		if (this.CastleSwitch == null || this.CastleSwitch.Length < (int)b)
		{
			this.CastleSwitch = new byte[(int)b];
		}
		byte b2 = Mp.ReadByte(-1);
		if (this.CastleEnhance == null || this.CastleEnhance.Length < (int)(b * 8))
		{
			this.CastleEnhance = new byte[(int)(b * 8)];
		}
		this.LoadCastleSkinSave();
		Mp.ReadBlock(this.CastleSwitch, 0, (int)b, -1);
		int num = 0;
		if (b2 > 0)
		{
			for (int i = 0; i < this.CastleSwitch.Length; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (((int)this.CastleSwitch[i] & 1 << j) > 0)
					{
						int num2 = i * 8 + j;
						this.CastleEnhance[num2] = Mp.ReadByte(-1);
						if (this.CastleEnhance[num2] > 5)
						{
							this.CastleEnhance[num2] = 5;
						}
						this.SetSelect((byte)(num2 + 1));
						num++;
						if (num == (int)b2)
						{
							break;
						}
					}
				}
				if (num == (int)b2)
				{
					break;
				}
			}
		}
		this.UpdateExclamationCount();
		this.SortDirty();
		this.SetUnlock(1);
		this.UnlockMall();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_CastleSkin, 0, 0);
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.CastleSkin);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_CastleStrengthen, 4, 0);
	}

	// Token: 0x06001146 RID: 4422 RVA: 0x001E7B80 File Offset: 0x001E5D80
	public void RecvCastleSkinUpdate(MessagePacket Mp)
	{
		byte b = Mp.ReadByte(-1);
		byte b2 = Mp.ReadByte(-1);
		byte b3 = Mp.ReadByte(-1);
		if (b2 == 0)
		{
			if (b == 0)
			{
				this.SortDirty();
				this.SetUnlock(b3 + 1);
				this.UnlockMall();
				AudioManager.Instance.PlayMP3SFX(41011, 0f);
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(867u), 254, true);
				GUIManager.Instance.HideUILock(EUILock.Mall);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_CastleSkin, 2, (int)(b3 + 1));
			}
			else
			{
				if (this.CastleEnhance.Length > (int)b3)
				{
					this.CastleEnhance[(int)b3] = Mp.ReadByte(-1);
					if (this.CastleEnhance[(int)b3] > 5)
					{
						this.CastleEnhance[(int)b3] = 5;
					}
					if (this.CastleEnhance[(int)b3] >= 2)
					{
						AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.CASTLESKIN_LV2);
					}
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_CastleStrengthen, 1, 0);
			}
			DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.CastleSkin);
		}
		else if (b2 == 1)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_CastleStrengthen, 3, 0);
		}
	}

	// Token: 0x06001147 RID: 4423 RVA: 0x001E7CB4 File Offset: 0x001E5EB4
	public void RecvCastleSkinChange(MessagePacket Mp)
	{
		if (Mp.ReadByte(-1) == 0)
		{
			DataManager instance = DataManager.Instance;
			GUIManager instance2 = GUIManager.Instance;
			instance2.BuildingData.CastleID = Mp.ReadByte(-1);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(instance.mStringTable.GetStringByID((uint)instance2.BuildingData.castleSkin.CastleSkinTable.GetRecordByKey((ushort)instance2.BuildingData.CastleID).Name));
			cstring.AppendFormat(instance.mStringTable.GetStringByID(9686u));
			instance2.AddHUDMessage(cstring.ToString(), 255, true);
			instance2.UpdateUI(EGUIWindow.UI_CastleSkin, 3, (int)instance2.BuildingData.CastleID);
			instance2.HideUILock(EUILock.CastleSkin);
			instance.AttribVal.UpdateAttrVal(UpdateAttrKind.CastleSkin);
			AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
		}
	}

	// Token: 0x06001148 RID: 4424 RVA: 0x001E7D94 File Offset: 0x001E5F94
	public ushort[] GetAllCastleID(CastleSkin._SortType type, out byte count)
	{
		if (type == this.SortType)
		{
			count = this.SortCount;
			return this.SortCastleID;
		}
		this.SortType = type;
		this.SortCount = 0;
		for (int i = 0; i < this.CastleSkinTable.TableCount; i++)
		{
			if (this.SortType == CastleSkin._SortType.Own)
			{
				if (this.CheckUnlock((byte)(i + 1)))
				{
					ushort[] sortCastleID = this.SortCastleID;
					byte sortCount;
					this.SortCount = (sortCount = this.SortCount) + 1;
					sortCastleID[(int)sortCount] = (ushort)(i + 1);
				}
			}
			else
			{
				ushort[] sortCastleID2 = this.SortCastleID;
				byte sortCount;
				this.SortCount = (sortCount = this.SortCount) + 1;
				sortCastleID2[(int)sortCount] = (ushort)(i + 1);
			}
		}
		this.SortComparer.type = this.SortType;
		Array.Sort<ushort>(this.SortCastleID, 0, (int)this.SortCount, this.SortComparer);
		if (this.SortCastleID.Length - 1 > (int)this.SortCount)
		{
			this.SortCastleID[(int)this.SortCount] = 0;
		}
		count = this.SortCount;
		return this.SortCastleID;
	}

	// Token: 0x06001149 RID: 4425 RVA: 0x001E7E9C File Offset: 0x001E609C
	public void SetCheckStrengthen(bool bSet)
	{
		this.bCheckCastleStrengthen = bSet;
	}

	// Token: 0x0600114A RID: 4426 RVA: 0x001E7EA8 File Offset: 0x001E60A8
	public bool GetCheckStrengthen()
	{
		return this.bCheckCastleStrengthen;
	}

	// Token: 0x0400375F RID: 14175
	public const byte MaxRank = 5;

	// Token: 0x04003760 RID: 14176
	public const byte EnhanceRequireCastleLv = 25;

	// Token: 0x04003761 RID: 14177
	private int AssetID;

	// Token: 0x04003762 RID: 14178
	private byte CastleID;

	// Token: 0x04003763 RID: 14179
	private byte Level;

	// Token: 0x04003764 RID: 14180
	private byte UILevel;

	// Token: 0x04003765 RID: 14181
	private Material material;

	// Token: 0x04003766 RID: 14182
	private Material defaultMaterial;

	// Token: 0x04003767 RID: 14183
	private Material defaultMaterialUI;

	// Token: 0x04003768 RID: 14184
	private Sprite sprite;

	// Token: 0x04003769 RID: 14185
	private Sprite defaultSprite;

	// Token: 0x0400376A RID: 14186
	private CString tmpAssetName;

	// Token: 0x0400376B RID: 14187
	private byte bUILoaded;

	// Token: 0x0400376C RID: 14188
	private int[] AllAssetID;

	// Token: 0x0400376D RID: 14189
	private Sprite[] AllSprite;

	// Token: 0x0400376E RID: 14190
	private Material[] AllMaterial;

	// Token: 0x0400376F RID: 14191
	private ushort[] SortCastleID;

	// Token: 0x04003770 RID: 14192
	private ushort[] GraphicNameIndex;

	// Token: 0x04003771 RID: 14193
	private byte SortCount;

	// Token: 0x04003772 RID: 14194
	private CastleSort SortComparer = new CastleSort();

	// Token: 0x04003773 RID: 14195
	private CastleSkin._SortType SortType;

	// Token: 0x04003774 RID: 14196
	private byte[] SaveExclamationData;

	// Token: 0x04003775 RID: 14197
	private string ExclamationSaveName = "ExclamationSave";

	// Token: 0x04003776 RID: 14198
	private byte ExclamationCount;

	// Token: 0x04003777 RID: 14199
	public byte UnlockCastleSkinNotice;

	// Token: 0x04003778 RID: 14200
	private byte[] CastleSwitch;

	// Token: 0x04003779 RID: 14201
	private byte[] CastleEnhance;

	// Token: 0x0400377A RID: 14202
	public CExternalTableWithWordKey<CastleSkinTbl> CastleSkinTable;

	// Token: 0x0400377B RID: 14203
	public CExternalTableWithWordKey<CastleEnhanceTbl> CastleEnhanceTable;

	// Token: 0x0400377C RID: 14204
	private ushort[] CastleEnhanceIndexTable;

	// Token: 0x0400377D RID: 14205
	public ushort ActiveCastleID;

	// Token: 0x0400377E RID: 14206
	private byte[] DefaultExclamation;

	// Token: 0x0400377F RID: 14207
	private bool bCheckCastleStrengthen = true;

	// Token: 0x02000345 RID: 837
	public enum _SortType
	{
		// Token: 0x04003781 RID: 14209
		None,
		// Token: 0x04003782 RID: 14210
		All,
		// Token: 0x04003783 RID: 14211
		Own
	}
}
