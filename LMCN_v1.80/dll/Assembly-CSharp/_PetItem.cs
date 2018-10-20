using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000475 RID: 1141
public struct _PetItem
{
	// Token: 0x06001720 RID: 5920 RVA: 0x0027D558 File Offset: 0x0027B758
	public _PetItem(Transform transform, IUIButtonClickHandler clickHandle)
	{
		this.bInit = 1;
		this.gameobject = transform.gameObject;
		this.PetCell = new _PetCell[4];
		for (int i = 0; i < 4; i++)
		{
			this.PetCell[i] = new _PetCell(transform.GetChild(i), clickHandle);
		}
	}

	// Token: 0x06001721 RID: 5921 RVA: 0x0027D5B4 File Offset: 0x0027B7B4
	public void SetData(int DataIndex, int ItemBegin, int ItemCount, byte LockCheck)
	{
		PetManager instance = PetManager.Instance;
		int num = DataIndex * 4;
		int num2 = ItemCount;
		if (ItemCount == 0)
		{
			ItemCount = 1;
		}
		ushort[] sortPetItemData = instance.sortPetItemData;
		List<byte> sortPetData = instance.sortPetData;
		for (int i = 0; i < 4; i++)
		{
			if (num + i < ItemCount)
			{
				int num3 = num + i;
				if (num2 > num3)
				{
					PetItem itemData;
					if (ItemBegin + num3 < sortPetItemData.Length && (itemData = instance.GetItemData((int)sortPetItemData[ItemBegin + num3])) != null)
					{
						this.PetCell[i].gameobject.SetActive(true);
						this.PetCell[i].SetData(itemData.ItemID, num3, _PetItem._ItemType.Item);
					}
					else
					{
						this.PetCell[i].gameobject.SetActive(false);
					}
				}
				else if (ItemCount == 1 && num2 == 0)
				{
					this.PetCell[i].gameobject.SetActive(true);
					this.PetCell[i].SetData(0, 0, _PetItem._ItemType.Def);
				}
				else
				{
					this.PetCell[i].gameobject.SetActive(false);
				}
			}
			else
			{
				int num3 = num + i - ItemCount;
				if ((int)instance.PetDataCount > num3)
				{
					this.PetCell[i].gameobject.SetActive(true);
					this.PetCell[i].SetData(PetManager.Instance.GetPetData((int)sortPetData[num3]).ID, num3, _PetItem._ItemType.Pet);
					this.PetCell[i].UpdateState(LockCheck);
				}
				else
				{
					this.PetCell[i].gameobject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06001722 RID: 5922 RVA: 0x0027D76C File Offset: 0x0027B96C
	public void UpdatePetState(byte LockCheck)
	{
		if (this.gameobject == null)
		{
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			this.PetCell[i].UpdateState(LockCheck);
		}
	}

	// Token: 0x06001723 RID: 5923 RVA: 0x0027D7B0 File Offset: 0x0027B9B0
	public void TextRefresh()
	{
		if (this.PetCell != null)
		{
			for (int i = 0; i < this.PetCell.Length; i++)
			{
				this.PetCell[i].TextRefresh();
			}
		}
	}

	// Token: 0x06001724 RID: 5924 RVA: 0x0027D7F4 File Offset: 0x0027B9F4
	public void OnDestroy()
	{
		if (this.PetCell != null)
		{
			for (int i = 0; i < this.PetCell.Length; i++)
			{
				this.PetCell[i].OnDestroy();
			}
		}
	}

	// Token: 0x04004550 RID: 17744
	public byte bInit;

	// Token: 0x04004551 RID: 17745
	private GameObject gameobject;

	// Token: 0x04004552 RID: 17746
	private _PetCell[] PetCell;

	// Token: 0x02000476 RID: 1142
	public enum _ItemType
	{
		// Token: 0x04004554 RID: 17748
		Pet,
		// Token: 0x04004555 RID: 17749
		Item,
		// Token: 0x04004556 RID: 17750
		Def
	}
}
