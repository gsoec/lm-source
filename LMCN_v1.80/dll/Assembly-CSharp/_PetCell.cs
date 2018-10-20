using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000477 RID: 1143
public struct _PetCell
{
	// Token: 0x06001725 RID: 5925 RVA: 0x0027D838 File Offset: 0x0027BA38
	public _PetCell(Transform transform, IUIButtonClickHandler clickHandle)
	{
		this.cellType = _PetItem._ItemType.Def;
		this.gameobject = transform.gameObject;
		this.PetTrans = transform.GetChild(0).GetChild(0);
		this.ItemTrans = transform.GetChild(1).GetChild(1);
		this.PetObj = transform.GetChild(0).gameObject;
		this.ItemObj = transform.GetChild(1).gameObject;
		if (transform.childCount > 2)
		{
			this.DefObj = transform.GetChild(2).gameObject;
			UIButton component = this.DefObj.transform.GetChild(0).GetComponent<UIButton>();
			component.m_Handler = clickHandle;
			component.m_BtnID1 = 3;
		}
		else
		{
			this.DefObj = null;
		}
		this.PetNameText = transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
		this.ItemNameText = transform.GetChild(1).GetChild(2).GetComponent<UIText>();
		this.NumText = this.ItemTrans.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.NumStr = StringManager.Instance.SpawnString(30);
		this.ItemTrans.GetChild(0).SetAsLastSibling();
		this.ItemBtn = transform.GetChild(1).GetComponent<UIButton>();
		this.ItemBtn.m_Handler = clickHandle;
		this.ItemBtn.m_BtnID1 = 1;
		this.PetBtn = transform.GetChild(0).GetComponent<UIButton>();
		this.PetBtn.m_Handler = clickHandle;
		this.PetBtn.m_BtnID1 = 2;
		this.PetStoneID = (this.ID = 0);
		this.sortIndex = 0;
		this.PetNotice = new GameObject[4];
		this.PetNoticeShow = new bool[4];
		for (int i = 0; i < 4; i++)
		{
			this.PetNotice[i] = transform.GetChild(0).GetChild(1).GetChild(i).gameObject;
		}
		this.NewObj = transform.GetChild(0).GetChild(3).gameObject;
		this.NewText = transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>();
		this.NewText.text = DataManager.Instance.mStringTable.GetStringByID(6048u);
		this.PM = PetManager.Instance;
	}

	// Token: 0x170000A3 RID: 163
	// (get) Token: 0x06001726 RID: 5926 RVA: 0x0027DA7C File Offset: 0x0027BC7C
	private UIText NameText
	{
		get
		{
			if (this.PetObj.activeSelf)
			{
				return this.PetNameText;
			}
			return this.ItemNameText;
		}
	}

	// Token: 0x06001727 RID: 5927 RVA: 0x0027DA9C File Offset: 0x0027BC9C
	public void SetData(ushort ID, int Index, _PetItem._ItemType Type)
	{
		this.ID = ID;
		this.sortIndex = Index;
		this.cellType = Type;
		if (this.cellType == _PetItem._ItemType.Item)
		{
			if (this.DefObj != null)
			{
				this.DefObj.SetActive(false);
			}
			this.PetObj.SetActive(false);
			this.ItemObj.SetActive(true);
			GUIManager.Instance.ChangeHeroItemImg(this.ItemTrans, eHeroOrItem.Item, ID, 0, 0, 0);
			this.ItemBtn.m_BtnID2 = (int)ID;
			this.ItemBtn.m_BtnID3 = this.sortIndex;
			this.NumStr.ClearString();
			ushort num = DataManager.Instance.GetCurItemQuantity(ID, 0);
			if (num > 999)
			{
				num = 999;
			}
			this.NumStr.IntToFormat((long)num, 1, false);
			this.NumStr.AppendFormat("{0}");
			this.NumText.text = this.NumStr.ToString();
			this.NumText.SetAllDirty();
			this.NumText.cachedTextGenerator.Invalidate();
			this.NameText.text = DataManager.Instance.mStringTable.GetStringByID((uint)DataManager.Instance.EquipTable.GetRecordByKey(ID).EquipName);
		}
		else if (this.cellType == _PetItem._ItemType.Pet)
		{
			if (this.DefObj != null)
			{
				this.DefObj.SetActive(false);
			}
			this.PetObj.SetActive(true);
			this.ItemObj.SetActive(false);
			this.PetBtn.m_BtnID2 = (int)ID;
			this.PetBtn.m_BtnID3 = this.sortIndex;
			PetData petData = this.PM.GetPetData((int)this.PM.sortPetData[this.sortIndex]);
			PetTbl recordByKey = this.PM.PetTable.GetRecordByKey(ID);
			GUIManager.Instance.ChangeHeroItemImg(this.PetTrans, eHeroOrItem.Pet, petData.ID, petData.Enhance, petData.Rare, (int)petData.Level);
			this.NameText.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.Name);
			this.PetStoneID = recordByKey.SoulID;
			this.NewObj.SetActive(petData.CheckState(PetManager.EPetState.NewPet));
		}
		else if (this.DefObj != null)
		{
			this.DefObj.SetActive(true);
			this.PetObj.SetActive(false);
			this.ItemObj.SetActive(false);
		}
	}

	// Token: 0x06001728 RID: 5928 RVA: 0x0027DD18 File Offset: 0x0027BF18
	public void UpdateState(byte lockStone)
	{
		if (!this.gameobject.activeSelf || this.cellType != _PetItem._ItemType.Pet)
		{
			return;
		}
		if (this.sortIndex >= this.PM.sortPetData.Count)
		{
			this.gameobject.SetActive(false);
			return;
		}
		PetData petData = this.PM.GetPetData((int)this.PM.sortPetData[this.sortIndex]);
		Array.Clear(this.PetNoticeShow, 0, this.PetNoticeShow.Length);
		byte petState = this.GetPetState(lockStone);
		if (petState > 0 && petState <= 3)
		{
			this.PetNoticeShow[(int)(petState - 1)] = true;
		}
		this.PetNoticeShow[3] = petData.CheckState(PetManager.EPetState.Training);
		for (int i = 0; i < 4; i++)
		{
			this.PetNotice[i].SetActive(this.PetNoticeShow[i]);
		}
	}

	// Token: 0x06001729 RID: 5929 RVA: 0x0027DDF8 File Offset: 0x0027BFF8
	private byte GetPetState(byte lockStone)
	{
		PetData petData = this.PM.GetPetData((int)this.PM.sortPetData[this.sortIndex]);
		PetTbl recordByKey = this.PM.PetTable.GetRecordByKey(this.ID);
		bool flag = petData.Level == petData.GetMaxLevel(false);
		bool flag2;
		if (petData.Enhance == 2 || petData.CheckState(PetManager.EPetState.Evolution))
		{
			flag2 = (flag = false);
		}
		else
		{
			flag2 = (DataManager.Instance.GetCurItemQuantity(this.PetStoneID, 0) >= this.PM.GetEvoNeed_Stone(petData.Enhance, recordByKey.Rare));
		}
		if (flag && flag2)
		{
			return 1;
		}
		if (!flag && flag2)
		{
			return 2;
		}
		if (lockStone == 0)
		{
			DataManager instance = DataManager.Instance;
			ushort propertiesValue = instance.EquipTable.GetRecordByKey(instance.EquipTable.GetRecordByKey(this.PetStoneID).SyntheticParts[1].SyntheticItem).PropertiesInfo[0].PropertiesValue;
			int num = 3;
			if (petData.Enhance == 0)
			{
				num = 1;
			}
			else if (petData.Enhance == 1)
			{
				num = 2;
			}
			for (int i = 0; i < num; i++)
			{
				if (propertiesValue == 0)
				{
					break;
				}
				if (recordByKey.PetSkill[i] != 0 && petData.SkillLv[i] != 0)
				{
					PetSkillTbl recordByKey2 = this.PM.PetSkillTable.GetRecordByKey(recordByKey.PetSkill[i]);
					if (recordByKey2.UpLevel != petData.SkillLv[i])
					{
						if ((int)petData.SkillLv[i] > recordByKey2.OpenLevel.Length || recordByKey2.OpenLevel[(int)(petData.SkillLv[i] - 1)] <= petData.Level || petData.SkillExp[i] != this.GetNeedSkillExp(recordByKey2.Experience, petData.SkillLv[i]) - 1u)
						{
							if (instance.GetCurItemQuantity(this.PetStoneID, 0) >= this.PM.PetUI_UpNeedStoneCount)
							{
								return 3;
							}
						}
					}
				}
			}
		}
		return 0;
	}

	// Token: 0x0600172A RID: 5930 RVA: 0x0027E034 File Offset: 0x0027C234
	private uint GetNeedSkillExp(ushort Experience, byte Lv)
	{
		PetSkillExpTbl recordByKey = this.PM.PetSkillExpTable.GetRecordByKey(Experience);
		if (Lv >= 1 && (int)Lv <= recordByKey.ExpValue.Length)
		{
			return recordByKey.ExpValue[(int)(Lv - 1)];
		}
		return 0u;
	}

	// Token: 0x0600172B RID: 5931 RVA: 0x0027E078 File Offset: 0x0027C278
	public void TextRefresh()
	{
		if (this.NumText == null)
		{
			return;
		}
		this.NameText.enabled = false;
		this.NameText.enabled = true;
		this.NumText.enabled = false;
		this.NumText.enabled = true;
		this.NewText.enabled = false;
		this.NewText.enabled = true;
		UIHIBtn component = this.ItemTrans.GetComponent<UIHIBtn>();
		if (component != null)
		{
			component.Refresh_FontTexture();
		}
		component = this.PetTrans.GetComponent<UIHIBtn>();
		if (component != null)
		{
			component.Refresh_FontTexture();
		}
	}

	// Token: 0x0600172C RID: 5932 RVA: 0x0027E11C File Offset: 0x0027C31C
	public void OnDestroy()
	{
		StringManager.Instance.DeSpawnString(this.NumStr);
	}

	// Token: 0x04004557 RID: 17751
	public GameObject gameobject;

	// Token: 0x04004558 RID: 17752
	public _PetItem._ItemType cellType;

	// Token: 0x04004559 RID: 17753
	private Transform PetTrans;

	// Token: 0x0400455A RID: 17754
	private Transform ItemTrans;

	// Token: 0x0400455B RID: 17755
	private GameObject PetObj;

	// Token: 0x0400455C RID: 17756
	private GameObject ItemObj;

	// Token: 0x0400455D RID: 17757
	private GameObject DefObj;

	// Token: 0x0400455E RID: 17758
	private GameObject NewObj;

	// Token: 0x0400455F RID: 17759
	private GameObject[] PetNotice;

	// Token: 0x04004560 RID: 17760
	private bool[] PetNoticeShow;

	// Token: 0x04004561 RID: 17761
	private UIText NumText;

	// Token: 0x04004562 RID: 17762
	private UIText ItemNameText;

	// Token: 0x04004563 RID: 17763
	private UIText PetNameText;

	// Token: 0x04004564 RID: 17764
	private UIText NewText;

	// Token: 0x04004565 RID: 17765
	private UIButton ItemBtn;

	// Token: 0x04004566 RID: 17766
	private UIButton PetBtn;

	// Token: 0x04004567 RID: 17767
	private CString NumStr;

	// Token: 0x04004568 RID: 17768
	private ushort PetStoneID;

	// Token: 0x04004569 RID: 17769
	private ushort ID;

	// Token: 0x0400456A RID: 17770
	private int sortIndex;

	// Token: 0x0400456B RID: 17771
	private PetManager PM;
}
