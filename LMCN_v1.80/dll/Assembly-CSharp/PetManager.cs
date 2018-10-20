using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

// Token: 0x020007A2 RID: 1954
public class PetManager
{
	// Token: 0x060027D7 RID: 10199 RVA: 0x0043FDC8 File Offset: 0x0043DFC8
	private PetManager()
	{
		this.CurPetData = new List<PetData>(16);
		this.sortPetData = new List<byte>(16);
		this.PetDataPool = new List<PetData>(16);
		this.petDataComparer = new PetDataComparer();
		this.PetFinder = new Dictionary<ushort, byte>(16);
		this.CDFinder = new Dictionary<ushort, long>(16);
		this.NegBuff = new Dictionary<ushort, byte>(16);
		this.PosBuff = new Dictionary<ushort, byte>(16);
		this.BuffInfo = new List<PSBuffInfoData>(16);
		this.CoolDown = new List<PSCoolDownData>(16);
		this.PetItemData = new PetItem[200];
		this.sortPetItemData = new ushort[200];
		this.PetItemDataPool = new ObjectPool<PetItem>(new PetItem(), 200, false);
		for (ushort num = 0; num < 200; num += 1)
		{
			this.sortPetItemData[(int)num] = num;
		}
		this.CalcPetBuffDataType = new _CalcPetBuffDataType[200];
		this.m_TrainingHero = new byte[256];
		this.m_PetTrainingData = new PetTraining[8];
		for (int i = 0; i < 8; i++)
		{
			this.m_PetTrainingData[i] = new PetTraining(PetManager.EPetTrainDataState.Closed);
		}
		this.m_PetTrainingClinetSave = new PetTraining[8];
		for (int j = 0; j < 8; j++)
		{
			this.m_PetTrainingClinetSave[j] = new PetTraining(PetManager.EPetTrainDataState.Closed);
		}
		this.m_PetTrainginSortData = new List<byte>(16);
		this.m_PetIdleComparer = new PetIdleComparer();
		this.LoadTrainingSet();
		this.m_HeroSelectPool = new ObjectPool<UIPetSelect.SScrollData>(new UIPetSelect.SScrollData(), 100, false);
		this.m_PetSelectPool = new ObjectPool<UIPetSelect.SScrollData>(new UIPetSelect.SScrollData(), 100, false);
		this.m_TrainListIndex = 0;
		this.m_TrainListY = 0f;
		this.m_LevelUpIdx = -1;
		this.m_LevelUpSkillIdx = -1;
		this.m_LevelUpStae = -1;
		this.m_LevelUpLV = 1;
		this.m_LevelOldExp = 1u;
		this.m_LevelNowExp = 1u;
		this.m_LevelSkillID = 0;
		this.m_PetMarchEventData = default(PetMarchEventDataType);
		this.m_PetMarchEventData.DesPlayerName = StringManager.Instance.SpawnString(13);
		this.bRecvPetMarchFinish = false;
	}

	// Token: 0x17000106 RID: 262
	// (get) Token: 0x060027D8 RID: 10200 RVA: 0x0044009C File Offset: 0x0043E29C
	public static PetManager Instance
	{
		get
		{
			if (PetManager.instance == null)
			{
				PetManager.instance = new PetManager();
			}
			return PetManager.instance;
		}
	}

	// Token: 0x17000107 RID: 263
	// (get) Token: 0x060027D9 RID: 10201 RVA: 0x004400B8 File Offset: 0x0043E2B8
	public ushort PetDataCount
	{
		get
		{
			return (ushort)this.CurPetData.Count;
		}
	}

	// Token: 0x060027DA RID: 10202 RVA: 0x004400C8 File Offset: 0x0043E2C8
	public byte GetPetSortFlag()
	{
		return this.PetSortFlag;
	}

	// Token: 0x060027DB RID: 10203 RVA: 0x004400D0 File Offset: 0x0043E2D0
	~PetManager()
	{
	}

	// Token: 0x060027DC RID: 10204 RVA: 0x00440108 File Offset: 0x0043E308
	private T FindData<T>(T[] array, ushort count, ushort searchID, ref ushort index) where T : IComparable<ushort>
	{
		int i = 0;
		int num = (int)count;
		while (i <= num)
		{
			ushort num2 = (ushort)Math.Floor((double)((i + num) / 2));
			if (array[(int)num2] == null)
			{
				return default(T);
			}
			if (array[(int)num2].CompareTo(searchID) == 0)
			{
				index = num2;
				return array[(int)num2];
			}
			if (array[(int)num2].CompareTo(searchID) == -1)
			{
				num = (int)(num2 - 1);
			}
			else
			{
				i = (int)(num2 + 1);
			}
		}
		return default(T);
	}

	// Token: 0x060027DD RID: 10205 RVA: 0x004401A4 File Offset: 0x0043E3A4
	private PetData GetPetDataObj()
	{
		PetData petData = null;
		if ((int)this.PetPoolDataCountIdx == this.PetDataPool.Count)
		{
			int capacity = this.PetDataPool.Capacity;
			int count = this.PetDataPool.Count;
			byte b = 0;
			while ((int)b < capacity)
			{
				this.PetDataPool.Add(new PetData(count + (int)b));
				b += 1;
			}
		}
		int petPoolDataCountIdx = (int)this.PetPoolDataCountIdx;
		int count2 = this.PetDataPool.Count;
		for (int i = 0; i < count2; i++)
		{
			int index = (i + petPoolDataCountIdx) % count2;
			petData = this.PetDataPool[index];
			if (petData != null)
			{
				this.PetDataPool[index] = null;
				break;
			}
		}
		this.PetPoolDataCountIdx += 1;
		return petData;
	}

	// Token: 0x060027DE RID: 10206 RVA: 0x00440274 File Offset: 0x0043E474
	private void ReleasePetDataObj(PetData Data)
	{
		if (Data == null || this.PetPoolDataCountIdx == 0)
		{
			return;
		}
		this.PetPoolDataCountIdx -= 1;
		this.PetDataPool[Data.DataIndex] = Data;
	}

	// Token: 0x060027DF RID: 10207 RVA: 0x004402AC File Offset: 0x0043E4AC
	public void LoadTable()
	{
		this.PetTable = new CExternalTableWithWordKey<PetTbl>();
		this.PetExpTable = new CExternalTableWithWordKey<PetExpTbl>();
		this.PetSkillTable = new CExternalTableWithWordKey<PetSkillTbl>();
		this.PetSkillExpTable = new CExternalTableWithWordKey<PetSkillExpTbl>();
		this.PetStoneReqTable = new CExternalTableWithWordKey<PetStoneReqTbl>();
		this.PetSkillValTable = new CExternalTableWithWordKey<PetSkillValTbl>();
		this.PetSkillCoolTable = new CExternalTableWithWordKey<PetSkillCoolTbl>();
		this.MapDamageEffTable = new CExternalTableWithWordKey<MapDamageEffTb>();
		this.HeroTrainExpTable = new CExternalTableWithWordKey<HeroTrainExpTbl>();
		this.PetTable.LoadTable("Pet");
		this.PetExpTable.LoadTable("PetLevelUp");
		this.HeroTrainExpTable.LoadTable("HeroExpForPet");
		this.PetSkillTable.LoadTable("PetSkill");
		this.PetSkillExpTable.LoadTable("PetSkillExp");
		this.PetStoneReqTable.LoadTable("PetStoneRequire");
		this.PetSkillValTable.LoadTable("PetSkillValue");
		this.PetSkillCoolTable.LoadTable("PetSkillCD");
		this.MapDamageEffTable.LoadTable("MapDamageShow");
		if (this.CalcPetDataType == null || this.CalcPetDataType.Length < this.PetTable.TableCount)
		{
			this.CalcPetDataType = new _CalcPetDataType[this.PetTable.TableCount];
		}
	}

	// Token: 0x060027E0 RID: 10208 RVA: 0x004403F0 File Offset: 0x0043E5F0
	public PetData FindPetData(ushort ID)
	{
		byte index = 0;
		if (this.PetFinder.TryGetValue(ID, out index))
		{
			return this.GetPetData((int)index);
		}
		return null;
	}

	// Token: 0x060027E1 RID: 10209 RVA: 0x0044041C File Offset: 0x0043E61C
	public PetData GetPetData(int Index)
	{
		if (Index < this.CurPetData.Count)
		{
			return this.CurPetData[Index];
		}
		return null;
	}

	// Token: 0x060027E2 RID: 10210 RVA: 0x00440440 File Offset: 0x0043E640
	public void SortPetData()
	{
		if ((this.PetSortFlag & 2) == 0)
		{
			this.sortPetData.Sort(this.petDataComparer);
			this.PetSortFlag |= 2;
		}
	}

	// Token: 0x060027E3 RID: 10211 RVA: 0x00440470 File Offset: 0x0043E670
	public void UpdatePetSort(bool bUpdatePetAttr = true)
	{
		this.PetSortFlag &= 253;
		if (bUpdatePetAttr)
		{
			DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
		}
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
		PetBuff.Update();
	}

	// Token: 0x060027E4 RID: 10212 RVA: 0x004404C0 File Offset: 0x0043E6C0
	public void UpdatePetItemSore()
	{
		this.PetSortFlag &= 254;
		if (DataManager.Instance.SortItemDataType == 32)
		{
			DataManager.Instance.SortItemDataType = 0;
		}
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
	}

	// Token: 0x060027E5 RID: 10213 RVA: 0x00440514 File Offset: 0x0043E714
	public byte UpdateCalculateBuffInfo()
	{
		byte b = 0;
		int count = this.BuffInfo.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.BuffInfo[i].SkillID != 0)
			{
				if (this.CalcPetBuffDataType.Length > (int)b)
				{
					this.CalcPetBuffDataType[(int)b].SkillID = this.BuffInfo[i].SkillID;
					this.CalcPetBuffDataType[(int)b].Level = this.BuffInfo[i].Level;
					b += 1;
				}
			}
		}
		return b;
	}

	// Token: 0x060027E6 RID: 10214 RVA: 0x004405C0 File Offset: 0x0043E7C0
	public void Clear()
	{
		if (this.PetDataCount > 0)
		{
			for (ushort num = 0; num < this.PetDataCount; num += 1)
			{
				this.ReleasePetDataObj(this.CurPetData[(int)num]);
			}
			this.CurPetData.Clear();
			this.PetFinder.Clear();
			this.sortPetData.Clear();
			this.m_PetTrainginSortData.Clear();
		}
		if (this.PetItemDataCount > 0)
		{
			for (ushort num2 = 0; num2 < this.PetItemDataCount; num2 += 1)
			{
				this.PetItemDataPool.despawn(this.PetItemData[(int)num2]);
				this.PetItemData[(int)num2] = null;
			}
			this.PetItemDataCount = 0;
		}
		this.PetSortFlag = 0;
		this.BuffInfoLen = 0;
		this.CoolDownLen = 0;
		for (int i = 0; i < this.m_PetTrainingData.Length; i++)
		{
			if (this.m_PetTrainingData[i].m_PetTrainingSet.m_CoachHeroId != null)
			{
				this.m_PetTrainingData[i].m_PetTrainingSet.Empty();
			}
			this.m_PetTrainingData[i].m_State = PetManager.EPetTrainDataState.Empty;
		}
		if (this.m_TrainingHero != null)
		{
			Array.Clear(this.m_TrainingHero, 0, this.m_TrainingHero.Length);
		}
		this.m_PetMarchEventData.Empty();
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.PetMarch, false, 0L, 0u);
		GameConstants.GetBytes(0, DataManager.msgBuffer, 0);
		GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, 16, 0);
	}

	// Token: 0x060027E7 RID: 10215 RVA: 0x0044074C File Offset: 0x0043E94C
	public void UnloadAsset()
	{
	}

	// Token: 0x060027E8 RID: 10216 RVA: 0x00440750 File Offset: 0x0043E950
	public bool CheckNewPetBook(ushort ItemID, int update = 0)
	{
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(ItemID);
		if (recordByKey.EquipKind - 1 == 17 && recordByKey.PropertiesInfo[0].Propertieskey == 5)
		{
			if (GUIManager.Instance.FindMenu(EGUIWindow.UI_PetList) != null)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, update | 8, 0);
			}
			else
			{
				this.UISave[6] = 0;
				GameConstants.GetBytes(0f, this.UISave, 7);
			}
			return true;
		}
		if (update > 0)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, update, 0);
		}
		return false;
	}

	// Token: 0x060027E9 RID: 10217 RVA: 0x00440800 File Offset: 0x0043EA00
	public bool IsPetItem(ushort ItemID)
	{
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(ItemID);
		EItemType eitemType = (EItemType)(recordByKey.EquipKind - 1);
		if (eitemType == EItemType.EIT_Consumables)
		{
			if (recordByKey.PropertiesInfo[0].Propertieskey == 5 || recordByKey.PropertiesInfo[0].Propertieskey == 6)
			{
				return true;
			}
		}
		else if (eitemType == EItemType.EIT_CaseByCase)
		{
			if (recordByKey.PropertiesInfo[0].Propertieskey >= 45 && recordByKey.PropertiesInfo[0].Propertieskey <= 48)
			{
				return true;
			}
		}
		else
		{
			if (eitemType == EItemType.EIT_EnhanceStone)
			{
				return true;
			}
			if (eitemType == EItemType.EIT_MaterialTreasureBox && recordByKey.PropertiesInfo[0].Propertieskey == 5)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060027EA RID: 10218 RVA: 0x004408D8 File Offset: 0x0043EAD8
	public void SetCurItemQuantity(ushort ItemID, ushort Quantity, byte Rare = 0)
	{
		ushort num = 0;
		PetItem petItem = this.FindItemData(ItemID, ref num);
		if (petItem != null)
		{
			if (Quantity > 0)
			{
				if (petItem.EquipKind - 1 == 17)
				{
					this.PetMaterialTreasureBox -= petItem.Quantity;
					this.PetMaterialTreasureBox += Quantity;
				}
				petItem.Quantity = Quantity;
			}
			else
			{
				if (petItem.EquipKind - 1 == 17)
				{
					this.PetMaterialTreasureBox -= petItem.Quantity;
				}
				this.PetItemDataPool.despawn(petItem);
				this.PetItemDataCount -= 1;
				if (num < this.PetItemDataCount)
				{
					Array.Copy(this.PetItemData, (int)(num + 1), this.PetItemData, (int)num, (int)(this.PetItemDataCount - num));
				}
				this.PetItemData[(int)this.PetItemDataCount] = null;
			}
		}
		else
		{
			if (200 <= this.PetItemDataCount || Quantity == 0)
			{
				return;
			}
			petItem = this.PetItemDataPool.spawn();
			petItem.Init();
			petItem.ItemID = ItemID;
			petItem.Quantity = Quantity;
			PetItem[] petItemData = this.PetItemData;
			ushort petItemDataCount;
			this.PetItemDataCount = (petItemDataCount = this.PetItemDataCount) + 1;
			petItemData[(int)petItemDataCount] = petItem;
			if (petItem.EquipKind - 1 == 17)
			{
				this.PetMaterialTreasureBox += petItem.Quantity;
			}
		}
		this.UpdatePetItemSore();
	}

	// Token: 0x060027EB RID: 10219 RVA: 0x00440A30 File Offset: 0x0043EC30
	public ushort GetCurItemQuantity(ushort ItemID, byte Rare = 0)
	{
		ushort num = 0;
		PetItem petItem = this.FindItemData(ItemID, ref num);
		if (petItem != null)
		{
			return petItem.Quantity;
		}
		return 0;
	}

	// Token: 0x060027EC RID: 10220 RVA: 0x00440A58 File Offset: 0x0043EC58
	public PetItem FindItemData(ushort ID, ref ushort Index)
	{
		if ((this.PetSortFlag & 1) == 0)
		{
			Array.Sort<PetItem>(this.PetItemData, 0, (int)this.PetItemDataCount);
			this.PetSortFlag |= 1;
		}
		return this.FindData<PetItem>(this.PetItemData, this.PetItemDataCount, ID, ref Index);
	}

	// Token: 0x060027ED RID: 10221 RVA: 0x00440AA8 File Offset: 0x0043ECA8
	public PetItem GetItemData(int Index)
	{
		if (Index < this.PetItemData.Length)
		{
			return this.PetItemData[Index];
		}
		return null;
	}

	// Token: 0x060027EE RID: 10222 RVA: 0x00440AC4 File Offset: 0x0043ECC4
	public void SortPetItemData()
	{
		DataManager dataManager = DataManager.Instance;
		if (dataManager.SortItemDataType == 32)
		{
			return;
		}
		if ((this.PetSortFlag & 1) == 0)
		{
			if (this.PetItemDataCount > 0)
			{
				Array.Sort<PetItem>(this.PetItemData, 0, (int)this.PetItemDataCount);
			}
			this.PetSortFlag |= 1;
		}
		dataManager.SortItemDataType = 32;
		dataManager.bagitemDataComparer.SortType = 4;
		Array.Clear(dataManager.sortItemDataStart, 0, dataManager.sortItemDataStart.Length);
		Array.Clear(dataManager.sortItemDataCount, 0, dataManager.sortItemDataCount.Length);
		Array.Sort<ushort>(this.sortPetItemData, 0, this.sortPetItemData.Length, dataManager.bagitemDataComparer);
		EItemType eitemType = EItemType.EIT_MAX;
		ushort num = 0;
		int petItemDataCount = (int)this.PetItemDataCount;
		for (int i = 0; i < petItemDataCount; i++)
		{
			PetItem itemData = this.GetItemData((int)this.sortPetItemData[i]);
			if (itemData == null)
			{
				break;
			}
			if (itemData.EquipKind > 2)
			{
				EItemType eitemType2 = (itemData.EquipKind <= 0 || itemData.EquipKind > 30) ? EItemType.EIT_MAX : ((EItemType)(itemData.EquipKind - 1));
				if (eitemType != eitemType2)
				{
					if (eitemType2 == EItemType.EIT_CaseByCase)
					{
						ushort propertieskey = itemData.PropertiesInfo[0].Propertieskey;
						if (num != propertieskey)
						{
							if (propertieskey == 45)
							{
								dataManager.sortItemDataStart[0] = (ushort)i;
								dataManager.sortItemDataCount[0] = 1;
							}
							else if (propertieskey == 46)
							{
								dataManager.sortItemDataStart[1] = (ushort)i;
								dataManager.sortItemDataCount[1] = 1;
							}
							num = propertieskey;
						}
						else if (propertieskey == 45)
						{
							ushort[] sortItemDataCount = dataManager.sortItemDataCount;
							int num2 = 0;
							sortItemDataCount[num2] += 1;
						}
						else if (propertieskey == 46)
						{
							ushort[] sortItemDataCount2 = dataManager.sortItemDataCount;
							int num3 = 1;
							sortItemDataCount2[num3] += 1;
						}
					}
					else
					{
						dataManager.sortItemDataStart[(int)eitemType2] = (ushort)i;
						dataManager.sortItemDataCount[(int)eitemType2] = 1;
						eitemType = eitemType2;
					}
				}
				else
				{
					ushort[] sortItemDataCount3 = dataManager.sortItemDataCount;
					EItemType eitemType3 = eitemType2;
					sortItemDataCount3[(int)eitemType3] = sortItemDataCount3[(int)eitemType3] + 1;
				}
			}
		}
	}

	// Token: 0x060027EF RID: 10223 RVA: 0x00440CD8 File Offset: 0x0043EED8
	public void Update()
	{
		bool flag = false;
		bool flag2 = DataManager.Instance.ServerTime != this.LastServerTime;
		if (flag2)
		{
			this.LastServerTime = DataManager.Instance.ServerTime;
			if (this.m_PetTrainingData != null)
			{
				for (int i = 0; i < this.m_PetTrainingData.Length; i++)
				{
					if (this.m_PetTrainingData[i].m_State == PetManager.EPetTrainDataState.Training)
					{
						long beginTime = this.m_PetTrainingData[i].m_EventTime.BeginTime;
						uint requireTime = this.m_PetTrainingData[i].m_EventTime.RequireTime;
						if (this.LastServerTime >= beginTime + (long)((ulong)requireTime))
						{
							this.m_PetTrainingData[i].m_State = PetManager.EPetTrainDataState.CanReceive;
							flag = true;
						}
					}
				}
				if (flag)
				{
					this.SetAllTrainState();
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 20, 0);
				}
			}
		}
	}

	// Token: 0x060027F0 RID: 10224 RVA: 0x00440DC0 File Offset: 0x0043EFC0
	private void SetAllTrainState()
	{
		byte trainBuildNum = this.GetTrainBuildNum();
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		while (num < (int)trainBuildNum && num < this.m_PetTrainingData.Length)
		{
			if (this.m_PetTrainingData[num].m_State == PetManager.EPetTrainDataState.CanReceive)
			{
				flag2 = true;
				break;
			}
			if (this.m_PetTrainingData[num].m_State == PetManager.EPetTrainDataState.Empty || this.m_PetTrainingData[num].m_State == PetManager.EPetTrainDataState.Received)
			{
				flag = true;
			}
			num++;
		}
		if (flag2)
		{
			this.m_AllPetTrainState = PetManager.EPetTrainDataState.CanReceive;
		}
		else if (flag)
		{
			this.m_AllPetTrainState = PetManager.EPetTrainDataState.Empty;
		}
		else
		{
			this.m_AllPetTrainState = PetManager.EPetTrainDataState.Training;
		}
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
	}

	// Token: 0x060027F1 RID: 10225 RVA: 0x00440E88 File Offset: 0x0043F088
	public byte GetTrainBuildNum()
	{
		byte b = GUIManager.Instance.BuildingData.GetBuildNumByID(23);
		BuildsData buildingData = GUIManager.Instance.BuildingData;
		if (b > 0 && buildingData.QueueBuildType == 2 && buildingData.AllBuildsData[(int)buildingData.BuildingManorID].BuildID == 23)
		{
			b -= 1;
		}
		return b;
	}

	// Token: 0x060027F2 RID: 10226 RVA: 0x00440EE8 File Offset: 0x0043F0E8
	public void SetTrainingCenterNum()
	{
		byte trainBuildNum = this.GetTrainBuildNum();
		for (int i = 0; i < 8; i++)
		{
			if (!this.m_PetTrainingData[i].HasInstance)
			{
				this.m_PetTrainingData[i] = new PetTraining(PetManager.EPetTrainDataState.Closed);
			}
			if (i < (int)trainBuildNum && this.m_PetTrainingData[i].m_State != PetManager.EPetTrainDataState.Training && this.m_PetTrainingData[i].m_State != PetManager.EPetTrainDataState.CanReceive && this.m_PetTrainingData[i].m_State != PetManager.EPetTrainDataState.Received)
			{
				this.m_PetTrainingData[i].SetState(PetManager.EPetTrainDataState.Empty);
			}
			else if (i > (int)trainBuildNum)
			{
				this.m_PetTrainingClinetSave[i].Empty();
				this.m_PetTrainingClinetSave[i].SetState(PetManager.EPetTrainDataState.Closed);
				this.m_PetTrainingData[i].SetState(PetManager.EPetTrainDataState.Closed);
			}
			else if (i == (int)trainBuildNum)
			{
				this.m_PetTrainingClinetSave[i].SetState(PetManager.EPetTrainDataState.NextOpen);
				this.m_PetTrainingClinetSave[i].Empty();
				this.m_PetTrainingData[i].SetState(PetManager.EPetTrainDataState.NextOpen);
			}
		}
		this.SaveTrainingSet();
		this.SetAllTrainState();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 0, 0);
	}

	// Token: 0x060027F3 RID: 10227 RVA: 0x00441038 File Offset: 0x0043F238
	public byte SortPetIdle()
	{
		byte b = 0;
		this.m_PetTrainginSortData.Sort(this.m_PetIdleComparer);
		byte b2 = 0;
		while ((int)b2 < this.m_PetTrainginSortData.Count)
		{
			PetData petData = this.GetPetData((int)this.m_PetTrainginSortData[(int)b2]);
			if (petData != null)
			{
				if (petData.CheckState(PetManager.EPetState.Limit))
				{
					break;
				}
				b += 1;
			}
			b2 += 1;
		}
		return b;
	}

	// Token: 0x060027F4 RID: 10228 RVA: 0x004410AC File Offset: 0x0043F2AC
	public string GetPetNameByID(ushort id)
	{
		if (this.PetTable != null)
		{
			PetTbl recordByKey = this.PetTable.GetRecordByKey(id);
			return DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.Name);
		}
		return null;
	}

	// Token: 0x060027F5 RID: 10229 RVA: 0x004410EC File Offset: 0x0043F2EC
	public uint GetPetSkillMaxExp(ushort petID, byte skillIdx)
	{
		if (skillIdx >= 4)
		{
			return 0u;
		}
		PetTbl recordByKey = this.PetTable.GetRecordByKey(petID);
		PetSkillTbl recordByKey2 = this.PetSkillTable.GetRecordByKey(recordByKey.PetSkill[(int)skillIdx]);
		PetSkillExpTbl recordByKey3 = this.PetSkillExpTable.GetRecordByKey(recordByKey2.Experience);
		PetData petData = this.FindPetData(petID);
		if (petData != null)
		{
			byte b = petData.SkillLv[(int)skillIdx];
			if (b >= 1 && (int)b <= recordByKey3.ExpValue.Length)
			{
				return recordByKey3.ExpValue[(int)(b - 1)];
			}
		}
		return 0u;
	}

	// Token: 0x060027F6 RID: 10230 RVA: 0x00441178 File Offset: 0x0043F378
	public uint GetPetSkillMaxExpByID(ushort skillID, byte lv)
	{
		PetSkillTbl recordByKey = this.PetSkillTable.GetRecordByKey(skillID);
		PetSkillExpTbl recordByKey2 = this.PetSkillExpTable.GetRecordByKey(recordByKey.Experience);
		if (lv >= 1 && (int)lv <= recordByKey2.ExpValue.Length)
		{
			return recordByKey2.ExpValue[(int)(lv - 1)];
		}
		return 0u;
	}

	// Token: 0x060027F7 RID: 10231 RVA: 0x004411C8 File Offset: 0x0043F3C8
	public bool IsMaxLevelExp(ushort petID)
	{
		PetData petData = this.FindPetData(petID);
		return petData != null && petData.Level == 60;
	}

	// Token: 0x060027F8 RID: 10232 RVA: 0x004411F0 File Offset: 0x0043F3F0
	public void LoadTrainingSet()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0}/Data/{1}{2}", AssetManager.persistentDataPath, this.PetTrainingListName, DataManager.Instance.RoleAttr.UserId);
		string path = stringBuilder.ToString();
		if (File.Exists(path))
		{
			using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
			{
				if (fileStream.Length > 0L)
				{
					try
					{
						using (BinaryReader binaryReader = new BinaryReader(fileStream))
						{
							for (int i = 0; i < this.m_PetTrainingClinetSave.Length; i++)
							{
								this.m_PetTrainingClinetSave[i].m_PetTrainingSet.m_PetId = binaryReader.ReadUInt16();
								int num = binaryReader.ReadInt32();
								this.m_PetTrainingClinetSave[i].m_PetTrainingSet.m_CoachHeroId.Clear();
								for (int j = 0; j < num; j++)
								{
									this.m_PetTrainingClinetSave[i].m_PetTrainingSet.m_CoachHeroId.Add(binaryReader.ReadUInt16());
								}
								this.m_PetTrainingClinetSave[i].m_TotalExp = binaryReader.ReadUInt32();
								this.m_PetTrainingClinetSave[i].m_CancelExp = binaryReader.ReadUInt32();
								this.m_PetTrainingClinetSave[i].m_EventTime.RequireTime = binaryReader.ReadUInt32();
								if (this.m_PetTrainingClinetSave[i].m_PetTrainingSet.m_PetId != 0)
								{
									this.m_PetTrainingClinetSave[i].m_State = PetManager.EPetTrainDataState.Received;
								}
								else
								{
									this.m_PetTrainingClinetSave[i].m_State = PetManager.EPetTrainDataState.Closed;
								}
							}
						}
					}
					catch (SystemException ex)
					{
					}
				}
			}
		}
	}

	// Token: 0x060027F9 RID: 10233 RVA: 0x00441404 File Offset: 0x0043F604
	public void SaveTrainingSet()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0}/Data/{1}{2}", AssetManager.persistentDataPath, this.PetTrainingListName, DataManager.Instance.RoleAttr.UserId);
		string path = stringBuilder.ToString();
		using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
			{
				for (int i = 0; i < this.m_PetTrainingClinetSave.Length; i++)
				{
					binaryWriter.Write(this.m_PetTrainingClinetSave[i].m_PetTrainingSet.m_PetId);
					if (this.m_PetTrainingClinetSave[i].m_PetTrainingSet.m_CoachHeroId.Count >= DataManager.Instance.MaxCurHeroData)
					{
						binaryWriter.Write(DataManager.Instance.MaxCurHeroData);
					}
					else
					{
						binaryWriter.Write(this.m_PetTrainingClinetSave[i].m_PetTrainingSet.m_CoachHeroId.Count);
					}
					int num = 0;
					while (num < this.m_PetTrainingClinetSave[i].m_PetTrainingSet.m_CoachHeroId.Count && num < DataManager.Instance.MaxCurHeroData)
					{
						binaryWriter.Write(this.m_PetTrainingClinetSave[i].m_PetTrainingSet.m_CoachHeroId[num]);
						num++;
					}
					binaryWriter.Write(this.m_PetTrainingClinetSave[i].m_TotalExp);
					binaryWriter.Write(this.m_PetTrainingClinetSave[i].m_CancelExp);
					binaryWriter.Write(this.m_PetTrainingClinetSave[i].m_EventTime.RequireTime);
				}
			}
		}
	}

	// Token: 0x060027FA RID: 10234 RVA: 0x00441600 File Offset: 0x0043F800
	public void SetTrainingHero(ushort heroID)
	{
		if ((int)heroID < this.m_TrainingHero.Length)
		{
			this.m_TrainingHero[(int)heroID] = 1;
		}
	}

	// Token: 0x060027FB RID: 10235 RVA: 0x0044161C File Offset: 0x0043F81C
	public void RemoveTrainingHero(ushort heroID)
	{
		if ((int)heroID < this.m_TrainingHero.Length)
		{
			this.m_TrainingHero[(int)heroID] = 0;
		}
	}

	// Token: 0x060027FC RID: 10236 RVA: 0x00441638 File Offset: 0x0043F838
	public bool IsTrainingHero(ushort heroID)
	{
		bool result = false;
		if ((int)heroID < this.m_TrainingHero.Length)
		{
			return this.m_TrainingHero[(int)heroID] == 1;
		}
		return result;
	}

	// Token: 0x060027FD RID: 10237 RVA: 0x00441664 File Offset: 0x0043F864
	public Sprite LoadPetSkillIcon(ushort skillID)
	{
		if (skillID == 0)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.Append("s60000");
			return GUIManager.Instance.LoadSkillSprite(cstring);
		}
		PetSkillTbl recordByKey = this.PetSkillTable.GetRecordByKey(skillID);
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring2.Append('s');
		cstring2.IntToFormat((long)recordByKey.Icon, 5, false);
		cstring2.AppendFormat("{0}");
		return GUIManager.Instance.LoadSkillSprite(cstring2);
	}

	// Token: 0x060027FE RID: 10238 RVA: 0x004416E0 File Offset: 0x0043F8E0
	public void OpenPetLevelUp(ushort petID, byte beginLv, byte endLv, uint beginExp, uint endExp, int UsePetLvUp = 0, ushort skillID = 0)
	{
		this.m_PetBeginLv = beginLv;
		this.m_PetEndLv = endLv;
		this.m_BeginExp = beginExp;
		this.m_EndExp = endExp;
		this.m_PetSkillLvUpID = skillID;
		GUIManager.Instance.OpenUI_Queued_Restricted_Top(EGUIWindow.UI_PetLevelUp, (int)petID, UsePetLvUp, true, 1);
	}

	// Token: 0x060027FF RID: 10239 RVA: 0x00441728 File Offset: 0x0043F928
	public ushort GetTrainExpByHeroCount(ushort count, bool bSkill = false)
	{
		ushort result = 0;
		if (this.HeroTrainExpTable != null && count != 0)
		{
			HeroTrainExpTbl recordByKey = this.HeroTrainExpTable.GetRecordByKey(count);
			if (recordByKey.ID == count)
			{
				if (bSkill)
				{
					result = recordByKey.PetEep;
				}
				else
				{
					result = recordByKey.PetSkillExp;
				}
			}
		}
		return result;
	}

	// Token: 0x06002800 RID: 10240 RVA: 0x00441780 File Offset: 0x0043F980
	public void RequestPetTrainingBegin(byte idx, ushort petID, List<ushort> coachHeroId)
	{
		if ((int)idx < this.m_PetTrainingData.Length)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_PET_TRAINING_BEGIN;
			messagePacket.AddSeqId();
			messagePacket.Add(idx);
			messagePacket.Add(petID);
			messagePacket.Add((byte)coachHeroId.Count);
			for (int i = 0; i < coachHeroId.Count; i++)
			{
				messagePacket.Add(coachHeroId[i]);
			}
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.PetSelect);
			this.m_AllPetTrainState = PetManager.EPetTrainDataState.Training;
		}
	}

	// Token: 0x06002801 RID: 10241 RVA: 0x00441814 File Offset: 0x0043FA14
	public void RecvPetTrainingBegin(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			byte b2 = MP.ReadByte(-1);
			ushort num = MP.ReadUShort(-1);
			uint totalExp = MP.ReadUInt(-1);
			long beginTime = MP.ReadLong(-1);
			uint requireTime = MP.ReadUInt(-1);
			byte b3 = MP.ReadByte(-1);
			if ((int)b2 <= this.m_PetTrainingData.Length)
			{
				this.m_PetTrainingData[(int)b2].m_PetTrainingSet.m_PetId = num;
				this.m_PetTrainingData[(int)b2].m_EventTime.BeginTime = beginTime;
				this.m_PetTrainingData[(int)b2].m_EventTime.RequireTime = requireTime;
				this.m_PetTrainingData[(int)b2].m_TotalExp = totalExp;
				this.m_PetTrainingData[(int)b2].m_PetTrainingSet.m_CoachHeroId.Clear();
				this.m_PetTrainingClinetSave[(int)b2].m_PetTrainingSet.m_PetId = num;
				this.m_PetTrainingClinetSave[(int)b2].m_EventTime.RequireTime = requireTime;
				this.m_PetTrainingClinetSave[(int)b2].m_PetTrainingSet.m_CoachHeroId.Clear();
				this.m_PetTrainingClinetSave[(int)b2].m_TotalExp = totalExp;
				this.m_PetTrainingClinetSave[(int)b2].m_CancelExp = 0u;
				for (byte b4 = 0; b4 < b3; b4 += 1)
				{
					ushort num2 = MP.ReadUShort(-1);
					this.m_PetTrainingData[(int)b2].m_PetTrainingSet.m_CoachHeroId.Add(num2);
					this.SetTrainingHero(num2);
					this.m_PetTrainingClinetSave[(int)b2].m_PetTrainingSet.m_CoachHeroId.Add(num2);
				}
				this.m_PetTrainingData[(int)b2].m_State = PetManager.EPetTrainDataState.Training;
				this.SaveTrainingSet();
			}
			PetData petData = this.FindPetData(num);
			if (petData != null)
			{
				petData.AddState(PetManager.EPetState.Training);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetSelect, 0, (int)b2);
		}
		else
		{
			this.ShowTrainErrorMsg(b);
		}
		GUIManager.Instance.HideUILock(EUILock.PetSelect);
		this.SetAllTrainState();
		GameConstants.GetBytes(0, DataManager.msgBuffer, 0);
		GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
	}

	// Token: 0x06002802 RID: 10242 RVA: 0x00441A30 File Offset: 0x0043FC30
	public void RequestPetTrainingCancel(ushort petID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_PET_TRAINING_CANCEL;
		messagePacket.AddSeqId();
		messagePacket.Add(petID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.PetSelect);
	}

	// Token: 0x06002803 RID: 10243 RVA: 0x00441A78 File Offset: 0x0043FC78
	public void RecvPetTrainingCancel(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			byte b2 = MP.ReadByte(-1);
			ushort num = MP.ReadUShort(-1);
			uint num2 = MP.ReadUInt(-1);
			if ((int)b2 < this.m_PetTrainingData.Length)
			{
				this.m_PetTrainingData[(int)b2].m_PetTrainingSet.m_PetId = num;
				this.m_PetTrainingData[(int)b2].m_EventTime.BeginTime = 0L;
				this.m_PetTrainingData[(int)b2].m_EventTime.RequireTime = 0u;
				this.m_PetTrainingData[(int)b2].m_TotalExp = num2;
				this.m_PetTrainingClinetSave[(int)b2].m_CancelExp = num2;
				if (num2 > 0u)
				{
					this.m_PetTrainingData[(int)b2].m_State = PetManager.EPetTrainDataState.CanReceive;
				}
				else
				{
					this.m_PetTrainingData[(int)b2].m_State = PetManager.EPetTrainDataState.Received;
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17106u), 35, true);
				}
				this.SaveTrainingSet();
			}
			if (num2 == 0u)
			{
				for (int i = 0; i < (int)this.m_PetTrainingData[(int)b2].CoachHeroCount; i++)
				{
					this.RemoveTrainingHero(this.m_PetTrainingData[(int)b2].m_PetTrainingSet.m_CoachHeroId[i]);
				}
				this.m_PetTrainingData[(int)b2].m_PetTrainingSet.m_CoachHeroId.Clear();
				PetData petData = this.FindPetData(num);
				if (petData != null)
				{
					petData.Remove(PetManager.EPetState.Training);
				}
			}
			this.SetAllTrainState();
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 20, 0);
		}
		else
		{
			this.ShowTrainErrorMsg(b);
		}
		GUIManager.Instance.HideUILock(EUILock.PetSelect);
		this.SetAllTrainState();
		GameConstants.GetBytes(0, DataManager.msgBuffer, 0);
		GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
	}

	// Token: 0x06002804 RID: 10244 RVA: 0x00441C4C File Offset: 0x0043FE4C
	public void RequestPetTrainingComplete(ushort petID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_PET_TRAINING_COMPLETE;
		messagePacket.AddSeqId();
		messagePacket.Add(petID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.PetSelect);
	}

	// Token: 0x06002805 RID: 10245 RVA: 0x00441C94 File Offset: 0x0043FE94
	public void RecvPetTrainingComplete(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			byte[] array = new byte[4];
			uint[] array2 = new uint[4];
			byte b2 = MP.ReadByte(-1);
			ushort num = MP.ReadUShort(-1);
			bool flag = this.IsMaxLevelExp(num);
			PetData petData = this.FindPetData(num);
			if (petData != null && (int)b2 < this.m_PetTrainingData.Length)
			{
				byte level = petData.Level;
				uint exp = petData.Exp;
				petData.Level = MP.ReadByte(-1);
				petData.Exp = MP.ReadUInt(-1);
				petData.Enhance = MP.ReadByte(-1);
				for (int i = 0; i < petData.SkillLv.Length; i++)
				{
					array[i] = petData.SkillLv[i];
					petData.SkillLv[i] = MP.ReadByte(-1);
					if (array[i] != petData.SkillLv[i])
					{
						byte b3 = (byte)i;
					}
				}
				for (int j = 0; j < petData.SkillExp.Length; j++)
				{
					array2[j] = petData.SkillExp[j];
					petData.SkillExp[j] = MP.ReadUInt(-1);
					if (array2[j] != petData.SkillExp[j])
					{
						byte b4 = (byte)j;
					}
				}
				petData.UpdateLevelState();
				this.UpdatePetSort(true);
				this.m_PetTrainingClinetSave[(int)b2].m_PetTrainingSet.m_PetId = num;
				this.m_PetTrainingClinetSave[(int)b2].m_CancelExp = 0u;
				this.SaveTrainingSet();
				if ((int)b2 < this.m_PetTrainingData.Length)
				{
					this.m_PetTrainingData[(int)b2].m_PetTrainingSet.m_PetId = num;
					this.m_PetTrainingData[(int)b2].m_EventTime.BeginTime = 0L;
					this.m_PetTrainingData[(int)b2].m_EventTime.RequireTime = 0u;
					this.m_PetTrainingData[(int)b2].m_State = PetManager.EPetTrainDataState.Received;
					for (int k = 0; k < (int)this.m_PetTrainingData[(int)b2].CoachHeroCount; k++)
					{
						this.RemoveTrainingHero(this.m_PetTrainingData[(int)b2].m_PetTrainingSet.m_CoachHeroId[k]);
					}
					this.m_PetTrainingData[(int)b2].m_PetTrainingSet.m_CoachHeroId.Clear();
					petData.Remove(PetManager.EPetState.Training);
					PetTbl recordByKey = this.PetTable.GetRecordByKey(num);
					this.m_LevelUpIdx = (int)b2;
					if (flag)
					{
						for (int l = 0; l < 4; l++)
						{
							if (array[l] != petData.SkillLv[l] || array2[l] != petData.SkillExp[l])
							{
								this.m_LevelUpSkillIdx = l;
								if (array[l] < petData.SkillLv[l] && l < recordByKey.PetSkill.Length)
								{
									this.OpenPetLevelUp(num, array[l], petData.SkillLv[l], array2[l], petData.SkillExp[l], 1, recordByKey.PetSkill[l]);
								}
								else
								{
									this.m_LevelUpLV = petData.SkillLv[l];
									this.m_LevelOldExp = array2[l];
									this.m_LevelNowExp = petData.SkillExp[l];
									this.m_LevelUpStae = 2;
									this.m_LevelSkillID = recordByKey.PetSkill[l];
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 0, 0);
								}
								break;
							}
						}
					}
					else if (level < petData.Level)
					{
						this.OpenPetLevelUp(num, level, petData.Level, exp, petData.Exp, 0, 0);
					}
					else
					{
						this.m_LevelUpStae = 1;
						GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 0, 0);
					}
					this.m_LevelUpIdx = -1;
					this.m_LevelUpSkillIdx = -1;
					this.m_LevelUpStae = -1;
					this.m_LevelUpLV = 1;
					this.m_LevelOldExp = 1u;
					this.m_LevelNowExp = 1u;
				}
			}
			this.SetAllTrainState();
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, 2, 0);
			DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
			if (petData.CheckState(PetManager.EPetState.Limit))
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17142u), 35, true);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 0, 0);
			}
		}
		else
		{
			this.ShowTrainErrorMsg(b);
		}
		GUIManager.Instance.HideUILock(EUILock.PetSelect);
		this.SetAllTrainState();
		GameConstants.GetBytes(0, DataManager.msgBuffer, 0);
		GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
	}

	// Token: 0x06002806 RID: 10246 RVA: 0x00442134 File Offset: 0x00440334
	public void RecvPetTrainingEvevt(MessagePacket MP)
	{
		DataManager.eMsgState eMsgState = (DataManager.eMsgState)MP.ReadByte(-1);
		byte b = MP.ReadByte(-1);
		ushort num = MP.ReadUShort(-1);
		uint totalExp = MP.ReadUInt(-1);
		long beginTime = MP.ReadLong(-1);
		uint requireTime = MP.ReadUInt(-1);
		byte b2 = MP.ReadByte(-1);
		if ((int)b < this.m_PetTrainingData.Length)
		{
			this.m_PetTrainingData[(int)b].m_PetTrainingSet.m_PetId = num;
			this.m_PetTrainingData[(int)b].m_EventTime.BeginTime = beginTime;
			this.m_PetTrainingData[(int)b].m_EventTime.RequireTime = requireTime;
			this.m_PetTrainingData[(int)b].m_TotalExp = totalExp;
			this.m_PetTrainingData[(int)b].m_PetTrainingSet.m_CoachHeroId.Clear();
			for (byte b3 = 0; b3 < b2; b3 += 1)
			{
				ushort num2 = MP.ReadUShort(-1);
				if (num2 == 0)
				{
					break;
				}
				this.m_PetTrainingData[(int)b].m_PetTrainingSet.m_CoachHeroId.Add(num2);
				this.SetTrainingHero(num2);
			}
			this.m_PetTrainingData[(int)b].m_State = PetManager.EPetTrainDataState.Training;
			PetData petData = this.FindPetData(num);
			if (petData != null)
			{
				petData.AddState(PetManager.EPetState.Training);
			}
		}
		if (eMsgState == DataManager.eMsgState.EMS_End || eMsgState == DataManager.eMsgState.EMS_BeginAndEnd)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 20, 0);
			this.SetAllTrainState();
			GameConstants.GetBytes(0, DataManager.msgBuffer, 0);
			GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
		}
	}

	// Token: 0x06002807 RID: 10247 RVA: 0x004422BC File Offset: 0x004404BC
	private void ShowTrainErrorMsg(byte result)
	{
		if (result >= 1)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat((long)result, 1, false);
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17134u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 35, true);
		}
	}

	// Token: 0x06002808 RID: 10248 RVA: 0x00442314 File Offset: 0x00440514
	public void RecvPetMarchEventData(MessagePacket MP)
	{
		this.m_PetMarchEventData.PetID = MP.ReadUShort(-1);
		this.m_PetMarchEventData.Point.zoneID = MP.ReadUShort(-1);
		this.m_PetMarchEventData.Point.pointID = MP.ReadByte(-1);
		this.m_PetMarchEventData.MarchEventTime.BeginTime = MP.ReadLong(-1);
		this.m_PetMarchEventData.MarchEventTime.RequireTime = MP.ReadUInt(-1);
		this.m_PetMarchEventData.DesPointKind = (POINT_KIND)MP.ReadByte(-1);
		this.m_PetMarchEventData.DesPointLevel = MP.ReadByte(-1);
		MP.ReadStringPlus(13, this.m_PetMarchEventData.DesPlayerName, -1);
		if (this.m_PetMarchEventData.PetID != 0)
		{
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.PetMarch, true, this.m_PetMarchEventData.MarchEventTime.BeginTime, this.m_PetMarchEventData.MarchEventTime.RequireTime);
			DataManager.Instance.SetRecvQueueBarData(36);
		}
	}

	// Token: 0x06002809 RID: 10249 RVA: 0x00442410 File Offset: 0x00440610
	public void RecvPetMarchEnd(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		this.m_PetMarchEventData.Empty();
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.PetMarch, false, 0L, 0u);
	}

	// Token: 0x0600280A RID: 10250 RVA: 0x00442440 File Offset: 0x00440640
	public void OpenPetUI(int SortIndex, int PetID)
	{
		this.PetUI_PetID = PetID;
		this.PetUI_PetSortIndex = SortIndex;
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			door.OpenMenu(EGUIWindow.UI_Pet, 0, 0, true);
		}
	}

	// Token: 0x0600280B RID: 10251 RVA: 0x00442488 File Offset: 0x00440688
	public void OpenPetMaxShowUI(int PetID)
	{
		this.PetUI_PetMaxShowID = PetID;
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			door.OpenMenu(EGUIWindow.UI_Pet, 1, 0, true);
		}
	}

	// Token: 0x0600280C RID: 10252 RVA: 0x004424C8 File Offset: 0x004406C8
	public void OpenPetEvoPanel(int PetID, bool bCloseOpenPetList = true)
	{
		if (bCloseOpenPetList)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door)
			{
				door.ClearWindowStack();
				GUIWindowStackData item;
				item.m_eWindow = EGUIWindow.UI_PetList;
				item.m_Arg1 = 49;
				item.m_Arg2 = 20;
				item.bCameraMode = false;
				door.m_WindowStack.Add(item);
			}
		}
		this.OpenPetUI(0, PetID);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 11, 0);
	}

	// Token: 0x0600280D RID: 10253 RVA: 0x0044254C File Offset: 0x0044074C
	public uint GetNeedExp(byte Level, byte Rare)
	{
		PetExpTbl recordByKey = this.PetExpTable.GetRecordByKey((ushort)Level);
		if (Rare > 0 && (int)Rare <= recordByKey.ExpValue.Length)
		{
			return recordByKey.ExpValue[(int)(Rare - 1)];
		}
		return 0u;
	}

	// Token: 0x0600280E RID: 10254 RVA: 0x0044258C File Offset: 0x0044078C
	public byte GetMaxEnhance()
	{
		return 2;
	}

	// Token: 0x0600280F RID: 10255 RVA: 0x00442590 File Offset: 0x00440790
	public ushort GetEvoNeed_Stone(byte Enhance, byte Rare)
	{
		PetStoneReqTbl recordByKey = this.PetStoneReqTable.GetRecordByKey((ushort)Rare);
		return ((int)Enhance >= recordByKey.StoneReq.Length) ? 0 : recordByKey.StoneReq[(int)Enhance];
	}

	// Token: 0x06002810 RID: 10256 RVA: 0x004425C8 File Offset: 0x004407C8
	public uint GetEvoNeed_Time(byte Enhance)
	{
		if (Enhance == 0)
		{
			return 43200u;
		}
		if (Enhance == 1)
		{
			return 129600u;
		}
		return 0u;
	}

	// Token: 0x06002811 RID: 10257 RVA: 0x004425E4 File Offset: 0x004407E4
	public byte GetEvoNeed_Lv(byte Enhance)
	{
		if (Enhance == 0)
		{
			return 20;
		}
		if (Enhance == 1)
		{
			return 50;
		}
		return 0;
	}

	// Token: 0x06002812 RID: 10258 RVA: 0x004425FC File Offset: 0x004407FC
	public void CheckPetSortIndexAndSort()
	{
		this.SortPetData();
		if (this.PetUI_PetSortIndex >= 0 && this.PetUI_PetSortIndex < (int)this.PetDataCount)
		{
			PetData petData = this.GetPetData((int)this.sortPetData[this.PetUI_PetSortIndex]);
			if (petData == null || (int)petData.ID != this.PetUI_PetID)
			{
				for (int i = 0; i < (int)this.PetDataCount; i++)
				{
					petData = this.GetPetData((int)this.sortPetData[i]);
					if (petData != null && (int)petData.ID == this.PetUI_PetID)
					{
						this.PetUI_PetSortIndex = i;
						break;
					}
				}
			}
		}
	}

	// Token: 0x06002813 RID: 10259 RVA: 0x004426A8 File Offset: 0x004408A8
	public bool IsFakePetItem(ushort ItemID)
	{
		return DataManager.Instance.EquipTable.GetRecordByKey(ItemID).EquipKind == 30;
	}

	// Token: 0x06002814 RID: 10260 RVA: 0x004426D8 File Offset: 0x004408D8
	public void SkillBuffComplete(ushort skillId)
	{
		if (skillId == 87)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Market, 0, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Market_Help, 2, 0);
		}
	}

	// Token: 0x06002815 RID: 10261 RVA: 0x00442718 File Offset: 0x00440918
	public bool UseSkill(ushort skillId, ushort petId, bool onSelf = true)
	{
		PetSkillTbl recordByKey = this.PetSkillTable.GetRecordByKey(skillId);
		PetSkillValTbl recordByKey2 = this.PetSkillValTable.GetRecordByKey(recordByKey.XValue);
		if (recordByKey.Kind == 4 && (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 13 || ((MerchantmanManager.Instance.TradeLocks & 1) == 1 && (MerchantmanManager.Instance.TradeLocks >> 1 & 1) == 1 && (MerchantmanManager.Instance.TradeLocks >> 2 & 1) == 1 && (MerchantmanManager.Instance.TradeLocks >> 3 & 1) == 1 && (MerchantmanManager.Instance.MerchantmanExtraData.LocksBought & 1) == 1)))
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(13544u), 255, true);
			return false;
		}
		if (recordByKey.Kind == 15 && GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 10)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12624u), 255, true);
			return false;
		}
		if (recordByKey.Kind == 8 && (recordByKey2.EffectBySkillLv[0] != 2u || !DataManager.Instance.queueBarData[1].bActive || DataManager.Instance.mPlayHelpDataType[0].HelpMax == 0 || DataManager.Instance.mPlayHelpDataType[0].AlreadyHelperNum >= DataManager.Instance.mPlayHelpDataType[0].HelpMax) && (recordByKey2.EffectBySkillLv[0] != 1u || !DataManager.Instance.queueBarData[0].bActive || DataManager.Instance.mPlayHelpDataType[1].HelpMax == 0 || DataManager.Instance.mPlayHelpDataType[1].AlreadyHelperNum >= DataManager.Instance.mPlayHelpDataType[1].HelpMax))
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12615u), 255, true);
			return false;
		}
		if (recordByKey.Kind == 28 && PetManager.Instance.NegBuff.Count == 0)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12622u), 255, true);
			return false;
		}
		if (recordByKey.Kind == 6 && GUIManager.Instance.m_TroopsCount == 0)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12614u), 255, true);
			return false;
		}
		if (recordByKey.Kind == 23)
		{
			for (int i = 0; i < 8; i++)
			{
				if (DataManager.Instance.MarchEventData[i].Type == EMarchEventType.EMET_Gathering && DataManager.Instance.MarchEventData[i].PointKind != POINT_KIND.PK_CRYSTAL)
				{
					return true;
				}
			}
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12620u), 255, true);
			return false;
		}
		if (recordByKey.Kind == 5 && (recordByKey2.EffectBySkillLv[0] == 3u || recordByKey2.EffectBySkillLv[0] == 1u))
		{
			PetData petData = this.FindPetData(petId);
			PetTbl recordByKey3 = this.PetTable.GetRecordByKey(petId);
			PetSkillValTbl recordByKey4 = this.PetSkillValTable.GetRecordByKey(recordByKey.ZValue);
			int num = 0;
			while (num < 4 && num < recordByKey3.PetSkill.Length)
			{
				if (recordByKey3.PetSkill[num] == skillId && petData != null && (int)(petData.SkillLv[num] - 1) < recordByKey4.EffectBySkillLv.Length)
				{
					if (recordByKey2.EffectBySkillLv[0] == 1u)
					{
						if ((uint)DataManager.Instance.RoleAttr.Morale + recordByKey4.EffectBySkillLv[(int)(petData.SkillLv[num] - 1)] > 999u)
						{
							GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(809u), 255, true);
							return false;
						}
					}
					else if (recordByKey4.EffectBySkillLv[(int)(petData.SkillLv[num] - 1)] > 4294967295u - DataManager.Instance.Resource[4].Stock)
					{
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(820u), 255, true);
						return false;
					}
					break;
				}
				num++;
			}
		}
		if (recordByKey.Kind == 2)
		{
			long num2 = DataManager.Instance.SoldierTotal;
			for (int j = 0; j < DataManager.Instance.MarchEventData.Length; j++)
			{
				for (int k = 0; k < DataManager.Instance.MarchEventData[j].TroopData.Length; k++)
				{
					if (DataManager.Instance.MarchEventData[j].Type != EMarchEventType.EMET_Standby)
					{
						for (int l = 0; l < DataManager.Instance.MarchEventData[j].TroopData[k].Length; l++)
						{
							num2 += (long)((ulong)DataManager.Instance.MarchEventData[j].TroopData[k][l]);
						}
					}
				}
			}
			if (DataManager.Instance.queueBarData[10].bActive)
			{
				num2 += (long)((ulong)DataManager.Instance.SoldierQuantity);
			}
			PetData petData2 = this.FindPetData(petId);
			PetTbl recordByKey5 = this.PetTable.GetRecordByKey(petId);
			int num3 = 0;
			int num4 = 0;
			while (num4 < 4 && num4 < recordByKey5.PetSkill.Length)
			{
				if (skillId == recordByKey5.PetSkill[num4])
				{
					num3 = num4;
				}
				num4++;
			}
			for (int m = 0; m < 16; m++)
			{
				num2 += (long)((ulong)DataManager.Instance.mSoldier_Hospital[m]);
			}
			if ((int)(petData2.SkillLv[num3] - 1) < recordByKey2.EffectBySkillLv.Length)
			{
				num2 += (long)((ulong)recordByKey2.EffectBySkillLv[(int)(petData2.SkillLv[num3] - 1)]);
			}
			if (num2 >= (long)((ulong)-94967296))
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12625u), 255, true);
				return false;
			}
		}
		if (skillId == 76 && (DataManager.Instance.RoleAttr.Guide & 16777216UL) == 0UL)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12628u), 255, true);
			return false;
		}
		if (skillId == 88)
		{
			if (DataManager.Instance.m_WallRepairNowValue >= DataManager.Instance.m_WallRepairMaxValue)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12618u), 35, true);
				return false;
			}
			if (LandWalkerManager.IsBattleFire())
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12619u), 35, true);
				return false;
			}
		}
		return true;
	}

	// Token: 0x06002816 RID: 10262 RVA: 0x00442E78 File Offset: 0x00441078
	public void UseSkillResult(ushort skillId, ushort petId, byte Result, MessagePacket MP = null)
	{
		switch (Result)
		{
		case 13:
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826u), DataManager.Instance.mStringTable.GetStringByID(12572u), null, null, 0, 0, false, false, false, false, false);
			break;
		default:
			switch (Result)
			{
			case 0:
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12574u), 35, true);
				break;
			case 1:
			{
				byte b = MP.ReadByte(-1);
				byte b2 = MP.ReadByte(-1);
				uint num = MP.ReadUInt(-1);
				int num2 = (int)(b * 4 + b2);
				SoldierData recordByKey = DataManager.Instance.SoldierDataTable.GetRecordByKey((ushort)(num2 + 1));
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.Name));
				cstring.IntToFormat((long)((ulong)num), 1, false);
				cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12613u));
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12574u), 35, true);
				GUIManager.Instance.AddHUDMessage(cstring.ToString(), 35, true);
				break;
			}
			case 2:
			{
				uint[] array = new uint[5];
				int num3 = 0;
				Array.Clear(GUIManager.Instance.SE_Kind, 0, GUIManager.Instance.SE_Kind.Length);
				Array.Clear(GUIManager.Instance.SE_ItemID, 0, GUIManager.Instance.SE_ItemID.Length);
				byte b3 = 0;
				while ((int)b3 < array.Length)
				{
					array[(int)b3] = MP.ReadUInt(-1);
					if (array[(int)b3] > 0u)
					{
						GUIManager.Instance.SE_Kind[num3] = SpeciallyEffect_Kind.Food + (int)b3;
						GUIManager.Instance.m_SpeciallyEffect.mResValue[(int)b3] = array[(int)b3];
						num3++;
					}
					b3 += 1;
				}
				GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
				GUIManager.Instance.m_SpeciallyEffect.AddIconShow(GUIManager.Instance.mStartV2, GUIManager.Instance.SE_Kind, GUIManager.Instance.SE_ItemID, true);
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12574u), 35, true);
				GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
				break;
			}
			default:
			{
				CString cstring2 = StringManager.Instance.StaticString1024();
				cstring2.IntToFormat((long)Result, 1, false);
				cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12570u));
				GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(12550u), cstring2.ToString(), 35, null, 0, 0, false, false, false, false, false);
				break;
			}
			}
			break;
		case 15:
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826u), DataManager.Instance.mStringTable.GetStringByID(12576u), null, null, 0, 0, false, false, false, false, false);
			break;
		case 22:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12616u), 35, true);
			break;
		case 25:
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826u), DataManager.Instance.mStringTable.GetStringByID(12577u), null, null, 0, 0, false, false, false, false, false);
			break;
		case 26:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12614u), 35, true);
			break;
		case 27:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12620u), 35, true);
			break;
		case 28:
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826u), DataManager.Instance.mStringTable.GetStringByID(12626u), null, null, 0, 0, false, false, false, false, false);
			break;
		case 29:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12617u), 35, true);
			break;
		case 30:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12623u), 35, true);
			break;
		case 31:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12621u), 35, true);
			break;
		case 32:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(13544u), 35, true);
			break;
		case 34:
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826u), DataManager.Instance.mStringTable.GetStringByID(12563u), null, null, 0, 0, false, false, false, false, false);
			break;
		}
		if (Result == 6 || Result == 7 || Result == 13 || Result == 15 || Result == 25 || Result == 26 || Result == 27 || Result == 28 || Result == 34)
		{
			PetSkillTbl recordByKey2 = this.PetSkillTable.GetRecordByKey(skillId);
			if (skillId == 0 || (recordByKey2.Type > 0 && recordByKey2.Subject > 1))
			{
				DataManager.MapDataController.StopMapWeapon();
			}
		}
	}

	// Token: 0x06002817 RID: 10263 RVA: 0x00443474 File Offset: 0x00441674
	public void SetSkillFatigue(ushort value = 0, ushort speed = 0, long time = 0L, bool Update = true)
	{
		DataManager.Instance.RoleAttr.PetSkillFatigue = value;
		DataManager.Instance.RoleAttr.FatigueRestoreSpeed = speed;
		DataManager.Instance.RoleAttr.LastPetSkillFatigueTime = time;
		if (Update)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 26, 0);
		}
	}

	// Token: 0x06002818 RID: 10264 RVA: 0x004434C8 File Offset: 0x004416C8
	public bool CheckPetListBuildMark()
	{
		if (this.PetMaterialTreasureBox > 0)
		{
			return true;
		}
		for (int i = 0; i < (int)this.PetDataCount; i++)
		{
			bool flag = this.CurPetData[i].Level == this.CurPetData[i].GetMaxLevel(false);
			if (flag)
			{
				if (this.CurPetData[i].Enhance != 2 && !this.CurPetData[i].CheckState(PetManager.EPetState.Evolution))
				{
					bool flag2 = this.GetCurItemQuantity(this.PetTable.GetRecordByKey(this.CurPetData[i].ID).SoulID, 0) >= this.GetEvoNeed_Stone(this.CurPetData[i].Enhance, this.CurPetData[i].Rare);
					if (flag && flag2)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06002819 RID: 10265 RVA: 0x004435C8 File Offset: 0x004417C8
	public void FormatSkillContent(ushort skillID, byte level, CString NewStr, byte ContType = 0)
	{
		if (skillID == 0 || level == 0 || NewStr == null)
		{
			return;
		}
		NewStr.ClearString();
		for (int i = 0; i < this.HintParm.Length; i++)
		{
			this.HintParm[i] = StringManager.Instance.StaticString1024();
		}
		PetSkillTbl recordByKey = this.PetSkillTable.GetRecordByKey(skillID);
		if (recordByKey.UpLevel < level)
		{
			level = recordByKey.UpLevel;
		}
		if (recordByKey.Type == 2)
		{
			this.GetEffectStr(ref recordByKey, level, NewStr);
			return;
		}
		this.GetSkillTypeStr(ref recordByKey, level, this.HintParm);
		string stringByID;
		if (ContType == 0)
		{
			stringByID = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.Effect1);
		}
		else
		{
			stringByID = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.Status);
		}
		int j = 0;
		while (j < stringByID.Length)
		{
			char c = stringByID[j++];
			if (c == '%')
			{
				switch (stringByID[j])
				{
				case 'a':
					NewStr.Append(this.HintParm[0]);
					j++;
					break;
				case 'b':
					NewStr.Append(this.HintParm[1]);
					j++;
					break;
				case 'c':
					NewStr.Append(this.HintParm[2]);
					j++;
					break;
				case 'd':
					NewStr.Append(this.HintParm[3]);
					j++;
					break;
				case 'e':
					NewStr.Append(this.HintParm[4]);
					j++;
					break;
				case 'f':
					NewStr.Append(this.HintParm[5]);
					j++;
					break;
				case 'g':
					NewStr.Append(this.HintParm[6]);
					j++;
					break;
				default:
					NewStr.Append(c);
					break;
				}
			}
			else
			{
				NewStr.Append(c);
			}
		}
	}

	// Token: 0x0600281A RID: 10266 RVA: 0x004437D0 File Offset: 0x004419D0
	private unsafe void GetEffectStr(ref PetSkillTbl skillTbl, byte level, CString ParmA)
	{
		DataManager dataManager = DataManager.Instance;
		PetSkillValTbl recordByKey = this.PetSkillValTable.GetRecordByKey(skillTbl.XValue);
		if ((int)(level -= 1) >= recordByKey.EffectBySkillLv.Length)
		{
			return;
		}
		ushort* ptr = stackalloc ushort[checked(6 * 2)];
		*ptr = skillTbl.XValue;
		ptr[1] = skillTbl.YValue;
		ptr[2] = skillTbl.AValue;
		ptr[3] = skillTbl.BValue;
		ptr[4] = skillTbl.CValue;
		ptr[5] = skillTbl.DValue;
		for (int i = 0; i < 3; i++)
		{
			int num = i * 2;
			if (ptr[num] != 0)
			{
				Effect recordByKey2 = dataManager.EffectData.GetRecordByKey((ushort)recordByKey.EffectBySkillLv[(int)level]);
				recordByKey = this.PetSkillValTable.GetRecordByKey(ptr[num + 1]);
				float num2 = recordByKey.EffectBySkillLv[(int)level];
				if (recordByKey.Unit == 0)
				{
					ParmA.Append(dataManager.mStringTable.GetStringByID((uint)recordByKey2.String_infoID));
					num2 /= 100f;
					ParmA.FloatToFormat(num2, 2, false);
					ParmA.AppendFormat("{0}");
				}
				else if (recordByKey.Unit == 1)
				{
					ParmA.AppendFormat(dataManager.mStringTable.GetStringByID((uint)recordByKey2.String_infoID));
					ParmA.IntToFormat((long)((int)num2), 1, true);
					ParmA.AppendFormat("{0}");
				}
				else
				{
					ParmA.Append(dataManager.mStringTable.GetStringByID((uint)recordByKey2.String_infoID));
					num2 /= 60f;
					ParmA.FloatToFormat(num2, 2, false);
					ParmA.AppendFormat("{0}");
				}
				if (recordByKey2.ValueID > 0)
				{
					ParmA.Append(dataManager.mStringTable.GetStringByID((uint)recordByKey2.ValueID));
				}
				num = (i + 1) * 2;
				if (num < 6 && ptr[num] > 0)
				{
					recordByKey = this.PetSkillValTable.GetRecordByKey(ptr[num]);
					ParmA.Append('\n');
				}
			}
		}
	}

	// Token: 0x0600281B RID: 10267 RVA: 0x004439D4 File Offset: 0x00441BD4
	private unsafe void GetSkillTypeStr(ref PetSkillTbl skillTbl, byte level, CString[] Parms)
	{
		DataManager dataManager = DataManager.Instance;
		PetSkillValTbl recordByKey = this.PetSkillValTable.GetRecordByKey(skillTbl.ZValue);
		if ((int)(level -= 1) >= recordByKey.EffectBySkillLv.Length)
		{
			return;
		}
		float num = recordByKey.EffectBySkillLv[(int)level];
		if (recordByKey.Unit == 0)
		{
			num /= 100f;
			Parms[0].FloatToFormat(num, 2, false);
		}
		else if (recordByKey.Unit == 1)
		{
			Parms[0].IntToFormat((long)((int)num), 1, true);
		}
		else
		{
			num /= 60f;
			Parms[0].FloatToFormat(num, 2, false);
		}
		Parms[0].AppendFormat("{0}");
		ushort* ptr = stackalloc ushort[checked(6 * 2)];
		*ptr = skillTbl.XValue;
		ptr[1] = skillTbl.YValue;
		ptr[2] = skillTbl.AValue;
		ptr[3] = skillTbl.BValue;
		ptr[4] = skillTbl.CValue;
		ptr[5] = skillTbl.DValue;
		for (int i = 0; i < 6; i++)
		{
			if (ptr[i] != 0)
			{
				recordByKey = this.PetSkillValTable.GetRecordByKey(ptr[i]);
				num = recordByKey.EffectBySkillLv[(int)level];
				if (recordByKey.Unit == 0)
				{
					num /= 100f;
					Parms[i + 1].FloatToFormat(num, 2, false);
				}
				else if (recordByKey.Unit == 1)
				{
					Parms[i + 1].IntToFormat((long)((int)num), 1, true);
				}
				else
				{
					num /= 60f;
					Parms[i + 1].FloatToFormat(num, 2, false);
				}
				Parms[i + 1].AppendFormat("{0}");
			}
		}
	}

	// Token: 0x0600281C RID: 10268 RVA: 0x00443B7C File Offset: 0x00441D7C
	public void FormatCoolTime(ushort time, CString timeStr, byte HavaArabicStr = 0)
	{
		if (timeStr == null || time == 0)
		{
			return;
		}
		timeStr.Append("<color=#4CF5F5FF>");
		if (time < 60)
		{
			timeStr.IntToFormat((long)time, 1, false);
			timeStr.AppendFormat("{0}m");
		}
		else
		{
			int num = (int)(time / 60);
			if (num < 24)
			{
				int num2 = (int)(time % 60);
				timeStr.IntToFormat((long)num, 1, false);
				if (num2 > 0)
				{
					timeStr.IntToFormat((long)num2, 1, false);
					if (HavaArabicStr == 0)
					{
						timeStr.AppendFormat("{0}h {1}m");
					}
					else
					{
						timeStr.AppendFormat("{1}m {0}h");
					}
				}
				else
				{
					timeStr.IntToFormat((long)num2, 1, false);
					timeStr.AppendFormat("{0}h");
				}
			}
			else
			{
				int num3 = num / 24;
				num %= 24;
				int num4 = (int)(time % 60);
				timeStr.IntToFormat((long)num3, 1, false);
				if (num > 0 && num4 > 0)
				{
					timeStr.IntToFormat((long)num, 1, false);
					timeStr.IntToFormat((long)num4, 1, false);
					if (HavaArabicStr == 0)
					{
						timeStr.AppendFormat("{0}d {1}h {2}m");
					}
					else
					{
						timeStr.AppendFormat("{2}m {1}h {0}d ");
					}
				}
				else if (num > 0)
				{
					timeStr.IntToFormat((long)num, 1, false);
					if (HavaArabicStr == 0)
					{
						timeStr.AppendFormat("{0}d {1}h");
					}
					else
					{
						timeStr.AppendFormat("{1}h {0}d");
					}
				}
				else if (num4 > 0)
				{
					timeStr.IntToFormat((long)num4, 1, false);
					if (HavaArabicStr == 0)
					{
						timeStr.AppendFormat("{0}d {1}m");
					}
					else
					{
						timeStr.AppendFormat("{1}m {0}d");
					}
				}
				else
				{
					timeStr.AppendFormat("{0}d");
				}
			}
		}
		timeStr.Append("</color>");
	}

	// Token: 0x0600281D RID: 10269 RVA: 0x00443D20 File Offset: 0x00441F20
	public void RecvPetItemInfo(MessagePacket MP)
	{
		this.RecvItemState = (DataManager.eMsgState)MP.ReadByte(-1);
		if (this.RecvItemState == DataManager.eMsgState.EMS_Begin || this.RecvItemState == DataManager.eMsgState.EMS_BeginAndEnd)
		{
			if (this.PetItemDataCount > 0)
			{
				for (int i = 0; i < (int)this.PetItemDataCount; i++)
				{
					this.PetItemDataPool.despawn(this.PetItemData[i]);
				}
				this.PetItemDataCount = 0;
			}
			this.PetSortFlag &= 254;
			if (DataManager.Instance.SortItemDataType == 32)
			{
				DataManager.Instance.SortItemDataType = 0;
			}
			this.PetMaterialTreasureBox = 0;
		}
		ushort num = MP.ReadUShort(-1);
		for (int j = 0; j < (int)num; j++)
		{
			ushort itemID = MP.ReadUShort(-1);
			if ((int)this.PetItemDataCount + j >= 200)
			{
				break;
			}
			PetItem petItem = this.PetItemDataPool.spawn();
			petItem.ItemID = itemID;
			petItem.Quantity = MP.ReadUShort(-1);
			this.PetItemData[(int)this.PetItemDataCount + j] = petItem;
			if (petItem.EquipKind - 1 == 17)
			{
				this.PetMaterialTreasureBox += petItem.Quantity;
			}
		}
		this.PetItemDataCount += num;
		if (this.PetItemDataCount > 200)
		{
			this.PetItemDataCount = 200;
		}
		if (this.RecvItemState == DataManager.eMsgState.EMS_End || this.RecvItemState == DataManager.eMsgState.EMS_BeginAndEnd)
		{
			this.UpdatePetItemSore();
			GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
		}
	}

	// Token: 0x0600281E RID: 10270 RVA: 0x00443EB0 File Offset: 0x004420B0
	public void RecvPetInfo(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		ushort num = MP.ReadUShort(-1);
		for (ushort num2 = 0; num2 < num; num2 += 1)
		{
			PetData petDataObj = this.GetPetDataObj();
			petDataObj.Init();
			petDataObj.ID = MP.ReadUShort(-1);
			petDataObj.Level = MP.ReadByte(-1);
			petDataObj.Exp = MP.ReadUInt(-1);
			petDataObj.Enhance = MP.ReadByte(-1);
			if (petDataObj.Enhance > 2)
			{
				petDataObj.Enhance = 2;
			}
			MP.ReadBlock(petDataObj.SkillLv, 0, 4, -1);
			for (byte b2 = 0; b2 < 4; b2 += 1)
			{
				petDataObj.SkillExp[(int)b2] = MP.ReadUInt(-1);
			}
			petDataObj.UpdateLevelState();
			if (!this.PetFinder.ContainsKey(petDataObj.ID))
			{
				this.PetFinder.Add(petDataObj.ID, (byte)this.PetDataCount);
				this.sortPetData.Add((byte)this.PetDataCount);
				this.m_PetTrainginSortData.Add((byte)this.PetDataCount);
				this.CurPetData.Add(petDataObj);
			}
			else
			{
				this.ReleasePetDataObj(petDataObj);
			}
		}
		if (b == 1)
		{
			this.UpdatePetSort(true);
			GameManager.OnRefresh(NetworkNews.Refresh_Pet, null);
			DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 30, 0);
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 30, this.PetDataCount);
		}
	}

	// Token: 0x0600281F RID: 10271 RVA: 0x00444028 File Offset: 0x00442228
	public void RecvPetAddNewPet(MessagePacket MP)
	{
		PetData petDataObj = this.GetPetDataObj();
		petDataObj.Init();
		petDataObj.AddState(PetManager.EPetState.NewPet);
		petDataObj.ID = MP.ReadUShort(-1);
		petDataObj.Level = MP.ReadByte(-1);
		petDataObj.Exp = MP.ReadUInt(-1);
		petDataObj.Enhance = MP.ReadByte(-1);
		if (petDataObj.Enhance > 2)
		{
			petDataObj.Enhance = 2;
		}
		MP.ReadBlock(petDataObj.SkillLv, 0, 4, -1);
		for (byte b = 0; b < 4; b += 1)
		{
			petDataObj.SkillExp[(int)b] = MP.ReadUInt(-1);
		}
		if (!this.PetFinder.ContainsKey(petDataObj.ID))
		{
			this.PetFinder.Add(petDataObj.ID, (byte)this.PetDataCount);
			this.sortPetData.Add((byte)this.PetDataCount);
			this.m_PetTrainginSortData.Add((byte)this.PetDataCount);
			this.CurPetData.Add(petDataObj);
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 30, this.PetDataCount);
		}
		else
		{
			this.ReleasePetDataObj(petDataObj);
		}
		this.UpdatePetSort(true);
		GameManager.OnRefresh(NetworkNews.Refresh_Pet, null);
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
	}

	// Token: 0x06002820 RID: 10272 RVA: 0x00444164 File Offset: 0x00442364
	public void RecvPetUpdate(MessagePacket MP)
	{
		ushort id = MP.ReadUShort(-1);
		PetData petData = this.FindPetData(id);
		if (petData == null)
		{
			return;
		}
		petData.Level = MP.ReadByte(-1);
		petData.Exp = MP.ReadUInt(-1);
		petData.Enhance = MP.ReadByte(-1);
		MP.ReadBlock(petData.SkillLv, 0, 4, -1);
		for (byte b = 0; b < 4; b += 1)
		{
			petData.SkillExp[(int)b] = MP.ReadUInt(-1);
		}
		this.UpdatePetSort(true);
		GameManager.OnRefresh(NetworkNews.Refresh_Pet, null);
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
	}

	// Token: 0x06002821 RID: 10273 RVA: 0x00444204 File Offset: 0x00442404
	public void Recv_PET_CURRENT_STARUP(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.PetUI);
		this.PetUI_EvoID = MP.ReadUShort(-1);
		long num = MP.ReadLong(-1);
		uint num2 = MP.ReadUInt(-1);
		PetData petData = this.FindPetData(this.PetUI_EvoID);
		if (petData != null)
		{
			petData.AddState(PetManager.EPetState.Evolution);
		}
		if (this.PetUI_EvoID > 0 && num > 0L && num2 > 0u)
		{
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.PetEvolution, true, num, num2);
			DataManager.Instance.SetRecvQueueBarData(35);
		}
		else
		{
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.PetEvolution, false, 0L, 0u);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 5, 0);
	}

	// Token: 0x06002822 RID: 10274 RVA: 0x004442B4 File Offset: 0x004424B4
	public void Recv_PET_STARUP_START(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.PetUI);
		PetManager.PET_STARUP_START_RESULT pet_STARUP_START_RESULT = (PetManager.PET_STARUP_START_RESULT)MP.ReadByte(-1);
		if (pet_STARUP_START_RESULT == PetManager.PET_STARUP_START_RESULT.PET_STARUP_START_RESULT_SUCCESS)
		{
			this.PetUI_EvoID = MP.ReadUShort(-1);
			ushort itemID = MP.ReadUShort(-1);
			ushort quantity = MP.ReadUShort(-1);
			long num = MP.ReadLong(-1);
			uint num2 = MP.ReadUInt(-1);
			PetData petData = this.FindPetData(this.PetUI_EvoID);
			if (petData != null)
			{
				petData.AddState(PetManager.EPetState.Evolution);
			}
			DataManager dataManager = DataManager.Instance;
			if (this.PetUI_EvoID > 0 && num > 0L && num2 > 0u)
			{
				dataManager.SetQueueBarData(EQueueBarIndex.PetEvolution, true, num, num2);
				dataManager.SetRecvQueueBarData(35);
			}
			else
			{
				dataManager.SetQueueBarData(EQueueBarIndex.PetEvolution, false, 0L, 0u);
			}
			dataManager.SetCurItemQuantity(itemID, quantity, 0, 0L);
			GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
			GameManager.OnRefresh(NetworkNews.Refresh_Pet, null);
		}
		else
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat((long)((byte)pet_STARUP_START_RESULT), 1, false);
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(16084u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
		}
	}

	// Token: 0x06002823 RID: 10275 RVA: 0x004443E0 File Offset: 0x004425E0
	public void Recv_PET_STARUP_COMPLETE(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.PetUI);
		PetManager.PET_STARUP_COMPLETE_RESULT pet_STARUP_COMPLETE_RESULT = (PetManager.PET_STARUP_COMPLETE_RESULT)MP.ReadByte(-1);
		if (pet_STARUP_COMPLETE_RESULT == PetManager.PET_STARUP_COMPLETE_RESULT.PET_STARUP_COMPLETE_RESULT_SUCCESS)
		{
			DataManager dataManager = DataManager.Instance;
			ushort num = MP.ReadUShort(-1);
			byte enhance = MP.ReadByte(-1);
			uint diamond = MP.ReadUInt(-1);
			ushort itemID = MP.ReadUShort(-1);
			ushort quantity = MP.ReadUShort(-1);
			this.PetUI_EvoID = 0;
			dataManager.SetQueueBarData(EQueueBarIndex.PetEvolution, false, 0L, 0u);
			PetData petData = this.FindPetData(num);
			if (petData != null)
			{
				petData.Enhance = enhance;
				petData.Remove(PetManager.EPetState.Evolution);
				GameManager.OnRefresh(NetworkNews.Refresh_Pet, null);
				PetTbl recordByKey = this.PetTable.GetRecordByKey(num);
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.StringToFormat(dataManager.mStringTable.GetStringByID((uint)recordByKey.Name));
				cstring.AppendFormat(dataManager.mStringTable.GetStringByID(16058u));
				GUIManager.Instance.AddHUDMessage(cstring.ToString(), 35, true);
				this.UpdatePetSort(true);
				petData.UpdateLevelState();
			}
			GUIManager.Instance.SetRoleAttrDiamond(diamond, 0, eSpentCredits.eMax);
			DataManager.Instance.SetCurItemQuantity(itemID, quantity, 0, 0L);
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
			GameManager.OnRefresh(NetworkNews.Refresh_Attr, null);
			GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 6, (int)num);
		}
		else
		{
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.IntToFormat((long)((byte)pet_STARUP_COMPLETE_RESULT), 1, false);
			cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(16084u));
			GUIManager.Instance.AddHUDMessage(cstring2.ToString(), 255, true);
		}
	}

	// Token: 0x06002824 RID: 10276 RVA: 0x0044458C File Offset: 0x0044278C
	public void Recv_PET_STARUP_CANCEL(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.PetUI);
		PetManager.PET_STARUP_CANCEL_RESULT pet_STARUP_CANCEL_RESULT = (PetManager.PET_STARUP_CANCEL_RESULT)MP.ReadByte(-1);
		if (pet_STARUP_CANCEL_RESULT == PetManager.PET_STARUP_CANCEL_RESULT.PET_STARUP_CANCEL_RESULT_SUCCESS)
		{
			ushort id = MP.ReadUShort(-1);
			ushort itemID = MP.ReadUShort(-1);
			ushort quantity = MP.ReadUShort(-1);
			PetData petData = this.FindPetData(id);
			if (petData != null)
			{
				petData.Remove(PetManager.EPetState.Evolution);
			}
			this.PetUI_EvoID = 0;
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.PetEvolution, false, 0L, 0u);
			DataManager.Instance.SetCurItemQuantity(itemID, quantity, 0, 0L);
			GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
			GameManager.OnRefresh(NetworkNews.Refresh_Pet, null);
		}
		else
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat((long)((byte)pet_STARUP_CANCEL_RESULT), 1, false);
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(16084u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
		}
	}

	// Token: 0x06002825 RID: 10277 RVA: 0x0044466C File Offset: 0x0044286C
	public void Send_PET_STARUP(ushort PetID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_PET_STARUP;
		messagePacket.AddSeqId();
		messagePacket.Add(PetID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.PetUI);
	}

	// Token: 0x06002826 RID: 10278 RVA: 0x004446B4 File Offset: 0x004428B4
	public void Send_PET_STARUP_FREECOMPLETE()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_PET_STARUP_FREECOMPLETE;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.PetUI);
	}

	// Token: 0x06002827 RID: 10279 RVA: 0x004446F4 File Offset: 0x004428F4
	public void Send_PET_STARUP_INSTANT(ushort PetID = 0)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_PET_STARUP_INSTANT;
		messagePacket.AddSeqId();
		if (PetID == 0)
		{
			messagePacket.Add(this.PetUI_EvoID);
		}
		else
		{
			messagePacket.Add(PetID);
		}
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.PetUI);
	}

	// Token: 0x06002828 RID: 10280 RVA: 0x00444750 File Offset: 0x00442950
	public void Send_PET_STARUP_CANCEL()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_PET_STARUP_CANCEL;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.PetUI);
	}

	// Token: 0x06002829 RID: 10281 RVA: 0x00444790 File Offset: 0x00442990
	public void Recv_PETSKILL_UPGRADESKILL(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.PetUI);
		PetManager.EPetSkillUpgradeErrorCode epetSkillUpgradeErrorCode = (PetManager.EPetSkillUpgradeErrorCode)MP.ReadByte(-1);
		if (epetSkillUpgradeErrorCode == PetManager.EPetSkillUpgradeErrorCode.EPSUEC_SUCCEED)
		{
			ushort id = MP.ReadUShort(-1);
			PetData petData = this.FindPetData(id);
			if (petData == null)
			{
				return;
			}
			byte b = MP.ReadByte(-1);
			if (b < 4)
			{
				this.PetUI_OldExp = petData.SkillExp[(int)b];
				petData.SkillExp[(int)b] = MP.ReadUInt(-1);
				this.PetUI_OldLV = petData.SkillLv[(int)b];
				petData.SkillLv[(int)b] = MP.ReadByte(-1);
				this.PetUI_UpNeedStoneCount = MP.ReadUShort(-1);
				for (int i = 0; i < this.PetUI_UpNeedSoulCount.Length; i++)
				{
					this.PetUI_UpNeedSoulCount[i] = MP.ReadUShort(-1);
				}
				this.PetUI_BaseExp = MP.ReadUInt(-1);
				this.PetUI_GetExp = MP.ReadUInt(-1);
				this.PetUI_GetRate = MP.ReadUShort(-1);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 9, (int)(petData.SkillLv[(int)b] - this.PetUI_OldLV));
				petData.UpdateLevelState();
			}
			DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Buff);
			DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
		}
		else
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat((long)((byte)epetSkillUpgradeErrorCode), 1, false);
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12130u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 2, 0);
		}
		this.PetSortFlag |= 4;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, 4, 0);
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
	}

	// Token: 0x0600282A RID: 10282 RVA: 0x00444958 File Offset: 0x00442B58
	public void Recv_PETSKILL_UPGRADE_STONE_AMOUNT(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.PetUI);
		this.PetUI_UpNeedStoneCount = MP.ReadUShort(-1);
		for (int i = 0; i < this.PetUI_UpNeedSoulCount.Length; i++)
		{
			this.PetUI_UpNeedSoulCount[i] = MP.ReadUShort(-1);
		}
		this.PetUI_BaseExp = MP.ReadUInt(-1);
		this.PetSortFlag |= 4;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 1, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, 4, 0);
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
	}

	// Token: 0x0600282B RID: 10283 RVA: 0x004449FC File Offset: 0x00442BFC
	public void Send_PETSKILL_UPGRADESKILL(ushort PetID, byte SkillIndex, byte CoinType)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_UPGRADESKILL;
		messagePacket.AddSeqId();
		messagePacket.Add(PetID);
		messagePacket.Add(SkillIndex);
		messagePacket.Add(CoinType);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.PetUI);
	}

	// Token: 0x0600282C RID: 10284 RVA: 0x00444A50 File Offset: 0x00442C50
	public void Send_PETSKILL_UPGRADE_STONE_AMOUNT()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_UPGRADE_STONE_AMOUNT;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.PetUI);
		this.PetSortFlag &= 251;
	}

	// Token: 0x0600282D RID: 10285 RVA: 0x00444AA4 File Offset: 0x00442CA4
	public void SendItemCraft_Start(ushort mItemCraftID, ushort mItemCount, byte InstantComplete = 0)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ITEMCRAFT_START;
		messagePacket.AddSeqId();
		messagePacket.Add(mItemCraftID);
		messagePacket.Add(mItemCount);
		messagePacket.Add(InstantComplete);
		messagePacket.Send(false);
	}

	// Token: 0x0600282E RID: 10286 RVA: 0x00444AEC File Offset: 0x00442CEC
	public void SendItemCraft_Cancel()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ITEMCRAFT_CANCEL;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x0600282F RID: 10287 RVA: 0x00444B20 File Offset: 0x00442D20
	public void Recv_MSG_RESP_ITEMCRAFT(MessagePacket MP)
	{
		DataManager dataManager = DataManager.Instance;
		GUIManager guimanager = GUIManager.Instance;
		guimanager.HideUILock(EUILock.PetFusion);
		byte b = MP.ReadByte(-1);
		if (b == 3)
		{
			this.Recv_MSG_RESP_ITEMCRAFT_Type3(MP);
			return;
		}
		byte b2 = MP.ReadByte(-1);
		if (b2 == 0)
		{
			ushort num = MP.ReadUShort(-1);
			ushort num2 = MP.ReadUShort(-1);
			long itemCraftBeginTime = MP.ReadLong(-1);
			uint itemCraftNeedTime = MP.ReadUInt(-1);
			FusionData recordByKey = dataManager.FusionDataTable.GetRecordByKey(num);
			if (b == 0)
			{
				this.ItemCraftID = num;
				this.ItemCraftCount = num2;
				if (this.ItemCraftCount == 0)
				{
					guimanager.OpenMessageBox(dataManager.mStringTable.GetStringByID(4829u), dataManager.mStringTable.GetStringByID(3870u), dataManager.mStringTable.GetStringByID(4831u), null, 0, 0, false, false, false, false, false);
				}
				else if (this.ItemCraftCount < this.m_ItemCraftQty)
				{
					guimanager.MsgStr.ClearString();
					guimanager.MsgStr.IntToFormat((long)this.m_ItemCraftQty, 1, false);
					guimanager.MsgStr.IntToFormat((long)this.ItemCraftCount, 1, false);
					if (recordByKey.Fusion_Kind < 1)
					{
						guimanager.MsgStr.AppendFormat(dataManager.mStringTable.GetStringByID(14674u));
					}
					else
					{
						guimanager.MsgStr.AppendFormat(dataManager.mStringTable.GetStringByID(14675u));
					}
					guimanager.OpenMessageBox(dataManager.mStringTable.GetStringByID(3971u), guimanager.MsgStr.ToString(), dataManager.mStringTable.GetStringByID(4026u), null, 0, 0, false, false, false, false, false);
				}
				this.ItemCraftBeginTime = itemCraftBeginTime;
				this.ItemCraftNeedTime = itemCraftNeedTime;
				if (this.ItemCraftBeginTime > 0L && this.ItemCraftNeedTime > 0u)
				{
					dataManager.SetQueueBarData(EQueueBarIndex.PetFusion, true, this.ItemCraftBeginTime, this.ItemCraftNeedTime);
					dataManager.SetRecvQueueBarData(34);
				}
				else
				{
					dataManager.SetQueueBarData(EQueueBarIndex.PetFusion, false, 0L, 0u);
				}
				AudioManager.Instance.PlaySFX(2201, 0f, PitchKind.NoPitch, null, null);
			}
			else if (b == 1)
			{
				dataManager.SetCurItemQuantity(recordByKey.Fusion_ItemID, num2, 0, 0L);
				guimanager.MsgStr.ClearString();
				if (recordByKey.Fusion_Kind < 1)
				{
					guimanager.MsgStr.StringToFormat(dataManager.mStringTable.GetStringByID((uint)dataManager.EquipTable.GetRecordByKey(recordByKey.Fusion_ItemID).EquipName));
				}
				else
				{
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.ClearString();
					cstring.StringToFormat(dataManager.mStringTable.GetStringByID((uint)dataManager.EquipTable.GetRecordByKey(recordByKey.Fusion_ItemID).EquipName));
					cstring.StringToFormat(dataManager.mStringTable.GetStringByID(14669u));
					cstring.AppendFormat("{0}{1}");
					guimanager.MsgStr.StringToFormat(cstring);
				}
				guimanager.MsgStr.AppendFormat(dataManager.mStringTable.GetStringByID(14676u));
				guimanager.AddHUDMessage(guimanager.MsgStr.ToString(), 255, true);
				this.CheckNewPetBook(recordByKey.Fusion_ItemID, 0);
				AudioManager.Instance.PlaySFX(2404, 0f, PitchKind.NoPitch, null, null);
			}
			else if (b == 2)
			{
				dataManager.SetQueueBarData(EQueueBarIndex.PetFusion, false, 0L, 0u);
			}
			for (int i = 0; i < 5; i++)
			{
				dataManager.Resource[i].Stock = MP.ReadUInt(-1);
			}
			dataManager.PetResource.Stock = MP.ReadUInt(-1);
			ushort num3;
			for (int j = 0; j < 3; j++)
			{
				num3 = MP.ReadUShort(-1);
				if (num3 >= 0)
				{
					dataManager.SetCurItemQuantity(recordByKey.ItemData[j].ItemID, num3, recordByKey.ItemData[j].Rank, 0L);
				}
			}
			num3 = MP.ReadUShort(-1);
			if (b == 1 && num3 >= 0)
			{
				dataManager.SetCurItemQuantity(recordByKey.Fusion_ItemID, num3, 0, 0L);
			}
			if (b == 1)
			{
				guimanager.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eMax);
			}
			guimanager.UpdateUI(EGUIWindow.UI_PetFusion, 1, 0);
			guimanager.UpdateUI(EGUIWindow.UI_PetFusionbuilding, 1, 0);
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
			GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
		}
		else if (b2 == 3)
		{
			guimanager.OpenMessageBox(dataManager.mStringTable.GetStringByID(4829u), dataManager.mStringTable.GetStringByID(3870u), dataManager.mStringTable.GetStringByID(4831u), null, 0, 0, false, false, false, false, false);
		}
		else
		{
			guimanager.MsgStr.ClearString();
			guimanager.MsgStr.IntToFormat((long)b2, 1, false);
			guimanager.MsgStr.AppendFormat(dataManager.mStringTable.GetStringByID(14673u));
			guimanager.AddHUDMessage(guimanager.MsgStr.ToString(), 255, true);
		}
	}

	// Token: 0x06002830 RID: 10288 RVA: 0x00445038 File Offset: 0x00443238
	public void Recv_MSG_RESP_ITEMCRAFT_Type3(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			MP.ReadUShort(-1);
			MP.ReadUShort(-1);
			MP.ReadLong(-1);
			MP.ReadUInt(-1);
			for (int i = 0; i < 5; i++)
			{
				MP.ReadUInt(-1);
			}
			MP.ReadUInt(-1);
			MP.ReadUShort(-1);
			MP.ReadUShort(-1);
			MP.ReadUShort(-1);
			MP.ReadUShort(-1);
			GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eMax);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetFusionbuilding, 1, 0);
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
			GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
		}
		else
		{
			GUIManager.Instance.MsgStr.ClearString();
			GUIManager.Instance.MsgStr.IntToFormat((long)b, 1, false);
			GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(14673u));
			GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), 255, true);
		}
	}

	// Token: 0x06002831 RID: 10289 RVA: 0x0044515C File Offset: 0x0044335C
	public void Recv_MSG_ITEMCRAFT_INFO(MessagePacket MP)
	{
		DataManager dataManager = DataManager.Instance;
		GUIManager guimanager = GUIManager.Instance;
		this.ItemCraftID = MP.ReadUShort(-1);
		this.ItemCraftCount = MP.ReadUShort(-1);
		this.ItemCraftBeginTime = MP.ReadLong(-1);
		this.ItemCraftNeedTime = MP.ReadUInt(-1);
		if (this.ItemCraftBeginTime > 0L && this.ItemCraftNeedTime > 0u)
		{
			dataManager.SetQueueBarData(EQueueBarIndex.PetFusion, true, this.ItemCraftBeginTime, this.ItemCraftNeedTime);
			dataManager.SetRecvQueueBarData(34);
		}
		else
		{
			dataManager.SetQueueBarData(EQueueBarIndex.PetFusion, false, 0L, 0u);
		}
		guimanager.UpdateUI(EGUIWindow.UI_PetFusionbuilding, 1, 0);
	}

	// Token: 0x06002832 RID: 10290 RVA: 0x00445200 File Offset: 0x00443400
	public void Recv_MSG_ITEMCRAFT_DONE(MessagePacket MP)
	{
		DataManager dataManager = DataManager.Instance;
		GUIManager guimanager = GUIManager.Instance;
		this.ItemCraftID = MP.ReadUShort(-1);
		FusionData recordByKey = dataManager.FusionDataTable.GetRecordByKey(this.ItemCraftID);
		ushort num = MP.ReadUShort(-1);
		if (num >= 0)
		{
			dataManager.SetCurItemQuantity(recordByKey.Fusion_ItemID, num, 0, 0L);
		}
		this.ItemCraftBeginTime = 0L;
		this.ItemCraftNeedTime = 0u;
		dataManager.SetQueueBarData(EQueueBarIndex.PetFusion, false, 0L, 0u);
		guimanager.MsgStr.ClearString();
		if (recordByKey.Fusion_Kind < 1)
		{
			guimanager.MsgStr.StringToFormat(dataManager.mStringTable.GetStringByID((uint)dataManager.EquipTable.GetRecordByKey(recordByKey.Fusion_ItemID).EquipName));
		}
		else
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.StringToFormat(dataManager.mStringTable.GetStringByID((uint)dataManager.EquipTable.GetRecordByKey(recordByKey.Fusion_ItemID).EquipName));
			cstring.StringToFormat(dataManager.mStringTable.GetStringByID(14669u));
			cstring.AppendFormat("{0}{1}");
			guimanager.MsgStr.StringToFormat(cstring);
		}
		guimanager.MsgStr.AppendFormat(dataManager.mStringTable.GetStringByID(14676u));
		guimanager.AddHUDMessage(guimanager.MsgStr.ToString(), 255, true);
		this.CheckNewPetBook(recordByKey.Fusion_ItemID, 0);
		guimanager.UpdateUI(EGUIWindow.UI_PetFusion, 2, 0);
		guimanager.UpdateUI(EGUIWindow.UI_PetFusionbuilding, 1, 0);
		guimanager.UpdateUI(EGUIWindow.UI_PetList, 9, (int)recordByKey.Fusion_ItemID);
		GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
		AudioManager.Instance.PlaySFX(2404, 0f, PitchKind.NoPitch, null, null);
	}

	// Token: 0x06002833 RID: 10291 RVA: 0x004453CC File Offset: 0x004435CC
	public void Recv_MSG_RESP_PET_OPENPETBOX(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.UseItem);
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			DataManager dataManager = DataManager.Instance;
			GUIManager guimanager = GUIManager.Instance;
			this.IsShowOpen = false;
			this.mItemCraftList.Clear();
			ushort num = MP.ReadUShort(-1);
			ushort num2 = dataManager.GetCurItemQuantity(num, 0);
			ushort num3 = MP.ReadUShort(-1);
			num2 -= num3;
			dataManager.SetCurItemQuantity(num, num3, 0, 0L);
			guimanager.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eMax);
			dataManager.RoleAlliance.Money = MP.ReadUInt(-1);
			this.mPetItemNum = MP.ReadByte(-1);
			this.ItemNum = MP.ReadByte(-1);
			this.mPetStoneNum = 0;
			int num4 = (int)(this.mPetItemNum + this.ItemNum);
			ItemCraftDataType item = default(ItemCraftDataType);
			int num5 = 0;
			while (num5 < num4 && num4 < 200)
			{
				item.ItemID = MP.ReadUShort(-1);
				item.Num = MP.ReadUShort(-1);
				item.ItemRank = MP.ReadByte(-1);
				item.mNo = (byte)num5;
				Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(item.ItemID);
				item.mPetID = recordByKey.SyntheticParts[0].SyntheticItem;
				item.mPetName = recordByKey.EquipName;
				item.mItemKind = recordByKey.EquipKind;
				if (item.mItemKind == 29)
				{
					PetData petData = this.FindPetData(item.mPetID);
					item.mPetEnhance = petData.Enhance;
				}
				this.mItemCraftList.Add(item);
				if (recordByKey.EquipKind <= 29)
				{
					ushort curItemQuantity = dataManager.GetCurItemQuantity(item.ItemID, 0);
					if (curItemQuantity + item.Num > 65535)
					{
						dataManager.SetCurItemQuantity(item.ItemID, ushort.MaxValue, 0, 0L);
					}
					else
					{
						dataManager.SetCurItemQuantity(item.ItemID, curItemQuantity + item.Num, 0, 0L);
					}
					if (item.mItemKind == 29)
					{
						this.mPetStoneNum += 1;
					}
				}
				num5++;
			}
			this.ItemNum -= this.mPetStoneNum;
			this.mItemCraftList.Sort(this.mItemCrafeDataComparer);
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door)
			{
				door.OpenMenu(EGUIWindow.UI_ItemCraftShow, (int)num, (int)num2, true);
			}
			GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
			FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_PACT_OPENED);
		}
		else
		{
			byte b2 = b;
			if (b2 != 1)
			{
				if (b2 == 2)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(702u), 255, true);
				}
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9771u), 255, true);
			}
		}
	}

	// Token: 0x06002834 RID: 10292 RVA: 0x004456D4 File Offset: 0x004438D4
	public void Recv_PETSKILL_USE(MessagePacket MP)
	{
		byte result = MP.ReadByte(-1);
		ushort petId = MP.ReadUShort(-1);
		PSCoolDownData pscoolDownData;
		pscoolDownData.SkillID = MP.ReadUShort(-1);
		pscoolDownData.EndTime = MP.ReadLong(-1);
		DataManager.Instance.SetCurItemQuantity(MP.ReadUShort(-1), MP.ReadUShort(-1), 0, 0L);
		if (pscoolDownData.SkillID > 0 && !this.CDFinder.ContainsKey(pscoolDownData.SkillID))
		{
			this.CoolDown.Add(pscoolDownData);
		}
		else
		{
			for (int i = 0; i < this.CoolDown.Count; i++)
			{
				if (this.CoolDown[i].SkillID == pscoolDownData.SkillID)
				{
					this.CoolDown[i] = pscoolDownData;
					break;
				}
			}
		}
		this.CDFinder[pscoolDownData.SkillID] = pscoolDownData.EndTime;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetBuff, 0, 0);
		GUIManager.Instance.HideUILock(EUILock.PetSkill);
		GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
		this.UseSkillResult(pscoolDownData.SkillID, petId, result, MP);
	}

	// Token: 0x06002835 RID: 10293 RVA: 0x004457FC File Offset: 0x004439FC
	public void Recv_PETSKILL_GETSKILL(MessagePacket MP)
	{
		PSBuffInfoData psbuffInfoData;
		psbuffInfoData.SkillID = MP.ReadUShort(-1);
		psbuffInfoData.Level = MP.ReadByte(-1);
		psbuffInfoData.BeginTime = MP.ReadLong(-1);
		psbuffInfoData.RequireTime = MP.ReadUInt(-1);
		if (psbuffInfoData.BeginTime > 0L)
		{
			if (psbuffInfoData.SkillID > 0)
			{
				PetSkillTbl recordByKey = this.PetSkillTable.GetRecordByKey(psbuffInfoData.SkillID);
				byte index;
				if (psbuffInfoData.SkillID == recordByKey.ID && recordByKey.Type == 1 && recordByKey.Subject == 2)
				{
					if (this.NegBuff.TryGetValue(psbuffInfoData.SkillID, out index))
					{
						this.BuffInfo[(int)index] = psbuffInfoData;
					}
					else
					{
						this.NegBuff[psbuffInfoData.SkillID] = (byte)this.BuffInfo.Count;
						this.BuffInfo.Add(psbuffInfoData);
					}
					PetBuff.Refreshed = false;
					PetBuff.Update(6, 0, false);
				}
				else if (this.PosBuff.TryGetValue(psbuffInfoData.SkillID, out index))
				{
					this.BuffInfo[(int)index] = psbuffInfoData;
				}
				else
				{
					this.PosBuff[psbuffInfoData.SkillID] = (byte)this.BuffInfo.Count;
					this.BuffInfo.Add(psbuffInfoData);
				}
			}
			else
			{
				this.BuffImmune.BeginTime = psbuffInfoData.BeginTime;
				this.BuffImmune.RequireTime = psbuffInfoData.RequireTime;
			}
			DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Buff);
		}
		this.SetSkillFatigue(MP.ReadUShort(-1), MP.ReadUShort(-1), MP.ReadLong(-1), true);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetBuff, 1, 0);
	}

	// Token: 0x06002836 RID: 10294 RVA: 0x004459C0 File Offset: 0x00443BC0
	public void Recv_PETSKILL_FATIGUE(MessagePacket MP)
	{
		this.SetSkillFatigue(MP.ReadUShort(-1), MP.ReadUShort(-1), MP.ReadLong(-1), true);
	}

	// Token: 0x06002837 RID: 10295 RVA: 0x004459EC File Offset: 0x00443BEC
	public void Recv_PETSKILL_BUFFCOMPLETE(MessagePacket MP)
	{
		ushort num = MP.ReadUShort(-1);
		byte index;
		if (num == 0)
		{
			this.BuffImmune.BeginTime = (long)((ulong)(this.BuffImmune.RequireTime = 0u));
		}
		else if (this.NegBuff.TryGetValue(num, out index))
		{
			this.BuffInfo[(int)index] = default(PSBuffInfoData);
			this.NegBuff.Remove(num);
			PetBuff.Update(6, 0, false);
		}
		else if (this.PosBuff.TryGetValue(num, out index))
		{
			this.BuffInfo[(int)index] = default(PSBuffInfoData);
			this.PosBuff.Remove(num);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 26, 0);
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Buff);
		this.SkillBuffComplete(num);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MapMonster, 0, 0);
	}

	// Token: 0x06002838 RID: 10296 RVA: 0x00445AD4 File Offset: 0x00443CD4
	public void Recv_PETSKILL_BUFFINFO(MessagePacket MP)
	{
		this.BuffImmune.BeginTime = MP.ReadLong(-1);
		this.BuffImmune.RequireTime = MP.ReadUInt(-1);
		this.PosBuff.Clear();
		this.NegBuff.Clear();
		this.BuffInfo.Clear();
		this.BuffInfoLen = MP.ReadByte(-1);
		this.BuffInfoData = new PSBuffInfoData[(int)this.BuffInfoLen];
		for (byte b = 0; b < this.BuffInfoLen; b += 1)
		{
			this.BuffInfoData[(int)b].SkillID = MP.ReadUShort(-1);
			this.BuffInfoData[(int)b].Level = MP.ReadByte(-1);
			this.BuffInfoData[(int)b].BeginTime = MP.ReadLong(-1);
			this.BuffInfoData[(int)b].RequireTime = MP.ReadUInt(-1);
			PetSkillTbl recordByKey = this.PetSkillTable.GetRecordByKey(this.BuffInfoData[(int)b].SkillID);
			if (DataManager.Instance.ServerTime < this.BuffInfoData[(int)b].BeginTime + (long)((ulong)this.BuffInfoData[(int)b].RequireTime))
			{
				byte index;
				if (recordByKey.Type == 1 && recordByKey.Subject == 2)
				{
					if (this.NegBuff.TryGetValue(this.BuffInfoData[(int)b].SkillID, out index))
					{
						this.BuffInfo[(int)index] = this.BuffInfoData[(int)b];
					}
					else
					{
						this.NegBuff[this.BuffInfoData[(int)b].SkillID] = (byte)this.BuffInfo.Count;
						this.BuffInfo.Add(this.BuffInfoData[(int)b]);
					}
				}
				else if (this.PosBuff.TryGetValue(this.BuffInfoData[(int)b].SkillID, out index))
				{
					this.BuffInfo[(int)index] = this.BuffInfoData[(int)b];
				}
				else
				{
					this.PosBuff[this.BuffInfoData[(int)b].SkillID] = (byte)this.BuffInfo.Count;
					this.BuffInfo.Add(this.BuffInfoData[(int)b]);
				}
			}
		}
		PetBuff.Update(6, 0, false);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 26, 0);
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Buff);
	}

	// Token: 0x06002839 RID: 10297 RVA: 0x00445D64 File Offset: 0x00443F64
	public void Recv_PETSKILL_COOLDOWN(MessagePacket MP)
	{
		this.CDFinder.Clear();
		this.CoolDown.Clear();
		this.CoolDownLen = MP.ReadByte(-1);
		this.CoolDownData = new PSCoolDownData[(int)this.CoolDownLen];
		for (int i = 0; i < (int)this.CoolDownLen; i++)
		{
			this.CoolDownData[i].SkillID = MP.ReadUShort(-1);
			this.CoolDownData[i].EndTime = MP.ReadLong(-1);
			if (!this.CDFinder.ContainsKey(this.CoolDownData[i].SkillID))
			{
				this.CoolDown.Add(this.CoolDownData[i]);
			}
			else
			{
				int num = 0;
				while (i < this.CoolDown.Count)
				{
					if (this.CoolDown[i].SkillID == this.CoolDownData[i].SkillID)
					{
						this.CoolDown[i] = this.CoolDownData[i];
						break;
					}
					num++;
				}
			}
			this.CDFinder[this.CoolDownData[i].SkillID] = this.CoolDownData[i].EndTime;
		}
	}

	// Token: 0x0600283A RID: 10298 RVA: 0x00445EC4 File Offset: 0x004440C4
	public ulong CalTotalPetPower()
	{
		ulong num = 0UL;
		for (int i = 0; i < (int)this.PetDataCount; i++)
		{
			num += this.CurPetData[i].getPetPower();
		}
		return num;
	}

	// Token: 0x040071D2 RID: 29138
	public const byte MAX_PET_LEVEL = 60;

	// Token: 0x040071D3 RID: 29139
	public const byte MAX_PET_SKILL = 4;

	// Token: 0x040071D4 RID: 29140
	public const ushort MaxPetItemCount = 200;

	// Token: 0x040071D5 RID: 29141
	private const int MaxCoachCount = 100;

	// Token: 0x040071D6 RID: 29142
	private const int MaxTrainingCount = 8;

	// Token: 0x040071D7 RID: 29143
	public const byte MAX_PET_RARITY = 5;

	// Token: 0x040071D8 RID: 29144
	private static PetManager instance;

	// Token: 0x040071D9 RID: 29145
	private long LastServerTime;

	// Token: 0x040071DA RID: 29146
	public List<byte> sortPetData;

	// Token: 0x040071DB RID: 29147
	private List<PetData> CurPetData;

	// Token: 0x040071DC RID: 29148
	private List<PetData> PetDataPool;

	// Token: 0x040071DD RID: 29149
	private ushort PetPoolDataCountIdx;

	// Token: 0x040071DE RID: 29150
	private Dictionary<ushort, byte> PetFinder;

	// Token: 0x040071DF RID: 29151
	private PetDataComparer petDataComparer;

	// Token: 0x040071E0 RID: 29152
	public _CalcPetDataType[] CalcPetDataType;

	// Token: 0x040071E1 RID: 29153
	public _CalcPetBuffDataType[] CalcPetBuffDataType;

	// Token: 0x040071E2 RID: 29154
	public PetItem[] PetItemData;

	// Token: 0x040071E3 RID: 29155
	public ushort[] sortPetItemData;

	// Token: 0x040071E4 RID: 29156
	private ObjectPool<PetItem> PetItemDataPool;

	// Token: 0x040071E5 RID: 29157
	public ushort PetItemDataCount;

	// Token: 0x040071E6 RID: 29158
	private ushort PetMaterialTreasureBox;

	// Token: 0x040071E7 RID: 29159
	private string PetTrainingListName = "PetTrainingList";

	// Token: 0x040071E8 RID: 29160
	public PetTraining[] m_PetTrainingData;

	// Token: 0x040071E9 RID: 29161
	public PetTraining[] m_PetTrainingClinetSave;

	// Token: 0x040071EA RID: 29162
	public byte[] m_TrainingHero;

	// Token: 0x040071EB RID: 29163
	public List<byte> m_PetTrainginSortData;

	// Token: 0x040071EC RID: 29164
	public PetIdleComparer m_PetIdleComparer;

	// Token: 0x040071ED RID: 29165
	public byte m_PetBeginLv;

	// Token: 0x040071EE RID: 29166
	public byte m_PetEndLv;

	// Token: 0x040071EF RID: 29167
	public uint m_BeginExp;

	// Token: 0x040071F0 RID: 29168
	public uint m_EndExp;

	// Token: 0x040071F1 RID: 29169
	public ushort m_PetSkillLvUpID;

	// Token: 0x040071F2 RID: 29170
	public PetManager.EPetTrainDataState m_AllPetTrainState;

	// Token: 0x040071F3 RID: 29171
	public ObjectPool<UIPetSelect.SScrollData> m_HeroSelectPool;

	// Token: 0x040071F4 RID: 29172
	public ObjectPool<UIPetSelect.SScrollData> m_PetSelectPool;

	// Token: 0x040071F5 RID: 29173
	public int m_TrainListIndex;

	// Token: 0x040071F6 RID: 29174
	public float m_TrainListY;

	// Token: 0x040071F7 RID: 29175
	public int m_LevelUpIdx;

	// Token: 0x040071F8 RID: 29176
	public int m_LevelUpSkillIdx;

	// Token: 0x040071F9 RID: 29177
	public int m_LevelUpStae;

	// Token: 0x040071FA RID: 29178
	public byte m_LevelUpLV = 1;

	// Token: 0x040071FB RID: 29179
	public uint m_LevelOldExp = 1u;

	// Token: 0x040071FC RID: 29180
	public uint m_LevelNowExp = 1u;

	// Token: 0x040071FD RID: 29181
	public ushort m_LevelSkillID;

	// Token: 0x040071FE RID: 29182
	public PetMarchEventDataType m_PetMarchEventData;

	// Token: 0x040071FF RID: 29183
	public bool bRecvPetMarchFinish;

	// Token: 0x04007200 RID: 29184
	public byte BuffInfoLen;

	// Token: 0x04007201 RID: 29185
	public PSBuffInfoData[] BuffInfoData;

	// Token: 0x04007202 RID: 29186
	public PSBuffInfoTime BuffImmune;

	// Token: 0x04007203 RID: 29187
	public List<PSBuffInfoData> BuffInfo;

	// Token: 0x04007204 RID: 29188
	public Dictionary<ushort, byte> NegBuff;

	// Token: 0x04007205 RID: 29189
	public Dictionary<ushort, byte> PosBuff;

	// Token: 0x04007206 RID: 29190
	public byte CoolDownLen;

	// Token: 0x04007207 RID: 29191
	public PSCoolDownData[] CoolDownData;

	// Token: 0x04007208 RID: 29192
	public List<PSCoolDownData> CoolDown;

	// Token: 0x04007209 RID: 29193
	public Dictionary<ushort, long> CDFinder;

	// Token: 0x0400720A RID: 29194
	private CString[] HintParm = new CString[7];

	// Token: 0x0400720B RID: 29195
	public byte[] UISave = new byte[11];

	// Token: 0x0400720C RID: 29196
	private byte PetSortFlag;

	// Token: 0x0400720D RID: 29197
	public CExternalTableWithWordKey<PetTbl> PetTable;

	// Token: 0x0400720E RID: 29198
	public CExternalTableWithWordKey<PetExpTbl> PetExpTable;

	// Token: 0x0400720F RID: 29199
	public CExternalTableWithWordKey<PetSkillTbl> PetSkillTable;

	// Token: 0x04007210 RID: 29200
	public CExternalTableWithWordKey<PetSkillExpTbl> PetSkillExpTable;

	// Token: 0x04007211 RID: 29201
	public CExternalTableWithWordKey<HeroTrainExpTbl> HeroTrainExpTable;

	// Token: 0x04007212 RID: 29202
	public CExternalTableWithWordKey<PetStoneReqTbl> PetStoneReqTable;

	// Token: 0x04007213 RID: 29203
	public CExternalTableWithWordKey<PetSkillValTbl> PetSkillValTable;

	// Token: 0x04007214 RID: 29204
	public CExternalTableWithWordKey<PetSkillCoolTbl> PetSkillCoolTable;

	// Token: 0x04007215 RID: 29205
	public CExternalTableWithWordKey<MapDamageEffTb> MapDamageEffTable;

	// Token: 0x04007216 RID: 29206
	private DataManager.eMsgState RecvItemState;

	// Token: 0x04007217 RID: 29207
	public int PetUI_PetMaxShowID = -1;

	// Token: 0x04007218 RID: 29208
	public int PetUI_PetID = -1;

	// Token: 0x04007219 RID: 29209
	public int PetUI_PetSortIndex = -1;

	// Token: 0x0400721A RID: 29210
	public ushort PetUI_UseItemPetID;

	// Token: 0x0400721B RID: 29211
	public ushort PetUI_EvoID;

	// Token: 0x0400721C RID: 29212
	public ushort PetUI_UpNeedStoneCount;

	// Token: 0x0400721D RID: 29213
	public uint PetUI_BaseExp;

	// Token: 0x0400721E RID: 29214
	public ushort[] PetUI_UpNeedSoulCount = new ushort[5];

	// Token: 0x0400721F RID: 29215
	public uint PetUI_OldExp;

	// Token: 0x04007220 RID: 29216
	public byte PetUI_OldLV;

	// Token: 0x04007221 RID: 29217
	public uint PetUI_GetExp;

	// Token: 0x04007222 RID: 29218
	public ushort PetUI_GetRate;

	// Token: 0x04007223 RID: 29219
	public ushort ItemCraftID;

	// Token: 0x04007224 RID: 29220
	public ushort ItemCraftCount;

	// Token: 0x04007225 RID: 29221
	public long ItemCraftBeginTime;

	// Token: 0x04007226 RID: 29222
	public uint ItemCraftNeedTime;

	// Token: 0x04007227 RID: 29223
	public ushort m_ItemCraftQty;

	// Token: 0x04007228 RID: 29224
	public uint m_FusionQty;

	// Token: 0x04007229 RID: 29225
	public int Fusion_Lock = 2;

	// Token: 0x0400722A RID: 29226
	public long Fusion_SliderValue;

	// Token: 0x0400722B RID: 29227
	public int FusionSkill_Lock = 2;

	// Token: 0x0400722C RID: 29228
	public long FusionSkill_SliderValue;

	// Token: 0x0400722D RID: 29229
	public int mPetSkillItemID = -1;

	// Token: 0x0400722E RID: 29230
	public int mPetFusionItemID = -1;

	// Token: 0x0400722F RID: 29231
	public float mUIFusion_Y = -1f;

	// Token: 0x04007230 RID: 29232
	public int mUIFusion_Idx = -1;

	// Token: 0x04007231 RID: 29233
	public bool bCheckLockFusionSkill = true;

	// Token: 0x04007232 RID: 29234
	public bool bActFusioncutdown;

	// Token: 0x04007233 RID: 29235
	public List<ItemCraftDataType> mItemCraftList = new List<ItemCraftDataType>(200);

	// Token: 0x04007234 RID: 29236
	public byte mPetItemNum;

	// Token: 0x04007235 RID: 29237
	public byte mPetStoneNum;

	// Token: 0x04007236 RID: 29238
	public byte ItemNum;

	// Token: 0x04007237 RID: 29239
	public bool IsShowOpen;

	// Token: 0x04007238 RID: 29240
	public ItemCrafeComparer mItemCrafeDataComparer = new ItemCrafeComparer();

	// Token: 0x020007A3 RID: 1955
	public enum EPetState
	{
		// Token: 0x0400723A RID: 29242
		None,
		// Token: 0x0400723B RID: 29243
		Training,
		// Token: 0x0400723C RID: 29244
		LockLimit,
		// Token: 0x0400723D RID: 29245
		Limit = 4,
		// Token: 0x0400723E RID: 29246
		Evolution = 8,
		// Token: 0x0400723F RID: 29247
		NewPet = 16
	}

	// Token: 0x020007A4 RID: 1956
	public enum EPetTrainDataState
	{
		// Token: 0x04007241 RID: 29249
		Empty,
		// Token: 0x04007242 RID: 29250
		Training,
		// Token: 0x04007243 RID: 29251
		CanReceive,
		// Token: 0x04007244 RID: 29252
		Received,
		// Token: 0x04007245 RID: 29253
		Closed,
		// Token: 0x04007246 RID: 29254
		NextOpen
	}

	// Token: 0x020007A5 RID: 1957
	private enum EPetSkillExecuteErrorCode
	{
		// Token: 0x04007248 RID: 29256
		EPSEEC_SUCCEED,
		// Token: 0x04007249 RID: 29257
		EPSEEC_SUCCEED_SPAWN_SOLDIER,
		// Token: 0x0400724A RID: 29258
		EPSEEC_SUCCEED_GET_RSS,
		// Token: 0x0400724B RID: 29259
		EPSEEC_SKILL_DATA_NOT_FOUND,
		// Token: 0x0400724C RID: 29260
		EPSEEC_IN_CD,
		// Token: 0x0400724D RID: 29261
		EPSEEC_UNDEFINE_KIND,
		// Token: 0x0400724E RID: 29262
		EPSEEC_NO_PLAYER,
		// Token: 0x0400724F RID: 29263
		EPSEEC_BAD_TARGET,
		// Token: 0x04007250 RID: 29264
		EPSEEC_PET_NOT_FOUND,
		// Token: 0x04007251 RID: 29265
		EPSEEC_PET_DATA_NOT_FOUND,
		// Token: 0x04007252 RID: 29266
		EPSEEC_NO_SKILL,
		// Token: 0x04007253 RID: 29267
		EPSEEC_NO_SKILL_ITEM,
		// Token: 0x04007254 RID: 29268
		EPSEEC_NOT_ACTIVE,
		// Token: 0x04007255 RID: 29269
		EPSEEC_SHIELD,
		// Token: 0x04007256 RID: 29270
		EPSEEC_UNDEFINE_TARGETTYPE,
		// Token: 0x04007257 RID: 29271
		EPSEEC_PET_MARCHING,
		// Token: 0x04007258 RID: 29272
		EPSEEC_CONSUMINGVALUE_ZERO,
		// Token: 0x04007259 RID: 29273
		EPSEEC_HELPTYPE_ERROR,
		// Token: 0x0400725A RID: 29274
		EPSEEC_HELPSTATUS_ERROR,
		// Token: 0x0400725B RID: 29275
		EPSEEC_BM_CASTLE_LEVEL_LOW,
		// Token: 0x0400725C RID: 29276
		EPSEEC_WALL_MAX,
		// Token: 0x0400725D RID: 29277
		EPSEEC_WALL_ONFIRE,
		// Token: 0x0400725E RID: 29278
		EPSEEC_NO_NPCCITYREWARD,
		// Token: 0x0400725F RID: 29279
		EPSEEC_SOLDIER_MAX,
		// Token: 0x04007260 RID: 29280
		EPSEEC_POOR_PETSTAR,
		// Token: 0x04007261 RID: 29281
		EPSEEC_NEWBIESHIELD,
		// Token: 0x04007262 RID: 29282
		EPSEEC_NO_MARCHING_TROOP,
		// Token: 0x04007263 RID: 29283
		EPSEEC_NO_GATHER,
		// Token: 0x04007264 RID: 29284
		EPSEEC_HAS_HIGHER_BUFF,
		// Token: 0x04007265 RID: 29285
		EPSEEC_NO_MARKET,
		// Token: 0x04007266 RID: 29286
		EPSEEC_NO_WARHALL,
		// Token: 0x04007267 RID: 29287
		EPSEEC_NO_MISSION,
		// Token: 0x04007268 RID: 29288
		EPSEEC_BM_ALL_LOCK,
		// Token: 0x04007269 RID: 29289
		EPSEEC_MORALE_LIMIT,
		// Token: 0x0400726A RID: 29290
		EPSEEC_DES_OUT_RANGE
	}

	// Token: 0x020007A6 RID: 1958
	public enum eSortFlag : byte
	{
		// Token: 0x0400726C RID: 29292
		Item = 1,
		// Token: 0x0400726D RID: 29293
		PetList,
		// Token: 0x0400726E RID: 29294
		RefreshNeedStone = 4
	}

	// Token: 0x020007A7 RID: 1959
	private enum PET_STARUP_START_RESULT
	{
		// Token: 0x04007270 RID: 29296
		PET_STARUP_START_RESULT_SUCCESS,
		// Token: 0x04007271 RID: 29297
		PET_STARUP_START_RESULT_NOTEXIST,
		// Token: 0x04007272 RID: 29298
		PET_STARUP_START_RESULT_STARLIMIT,
		// Token: 0x04007273 RID: 29299
		PET_STARUP_START_RESULT_DOING,
		// Token: 0x04007274 RID: 29300
		PET_STARUP_START_RESULT_STONE
	}

	// Token: 0x020007A8 RID: 1960
	private enum PET_STARUP_COMPLETE_RESULT
	{
		// Token: 0x04007276 RID: 29302
		PET_STARUP_COMPLETE_RESULT_SUCCESS,
		// Token: 0x04007277 RID: 29303
		PET_STARUP_COMPLETE_RESULT_NOTDOING,
		// Token: 0x04007278 RID: 29304
		PET_STARUP_COMPLETE_RESULT_NOTYET,
		// Token: 0x04007279 RID: 29305
		PET_STARUP_COMPLETE_RESULT_NOTEXIST,
		// Token: 0x0400727A RID: 29306
		PET_STARUP_COMPLETE_RESULT_STARLIMIT,
		// Token: 0x0400727B RID: 29307
		PET_STARUP_COMPLETE_RESULT_DOING,
		// Token: 0x0400727C RID: 29308
		PET_STARUP_COMPLETE_RESULT_STONE,
		// Token: 0x0400727D RID: 29309
		PET_STARUP_COMPLETE_RESULT_CRYSTAL
	}

	// Token: 0x020007A9 RID: 1961
	private enum PET_STARUP_CANCEL_RESULT
	{
		// Token: 0x0400727F RID: 29311
		PET_STARUP_CANCEL_RESULT_SUCCESS,
		// Token: 0x04007280 RID: 29312
		PET_STARUP_CANCEL_RESULT_NOTDOING
	}

	// Token: 0x020007AA RID: 1962
	private enum EPetSkillUpgradeErrorCode
	{
		// Token: 0x04007282 RID: 29314
		EPSUEC_SUCCEED,
		// Token: 0x04007283 RID: 29315
		EPSUEC_PET_NOT_FOUND,
		// Token: 0x04007284 RID: 29316
		EPSUEC_PET_DATA_NOT_FOUND,
		// Token: 0x04007285 RID: 29317
		EPSUEC_SKILL_DATA_NOT_FOUND,
		// Token: 0x04007286 RID: 29318
		EPSUEC_ITEMCOUNT_ERROR,
		// Token: 0x04007287 RID: 29319
		EPSUEC_NO_SKILL_ITEM,
		// Token: 0x04007288 RID: 29320
		EPSUEC_CAN_NOT_UPGRADE,
		// Token: 0x04007289 RID: 29321
		EPSUEC_PETLEVEL_POOR,
		// Token: 0x0400728A RID: 29322
		EPSUEC_PET_STAR_POOR
	}
}
