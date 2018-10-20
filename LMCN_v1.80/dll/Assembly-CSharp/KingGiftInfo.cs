using System;

// Token: 0x02000766 RID: 1894
public class KingGiftInfo
{
	// Token: 0x060024C5 RID: 9413 RVA: 0x00423B84 File Offset: 0x00421D84
	public KingGiftInfo(int index)
	{
		this._DataIdx = index;
	}

	// Token: 0x170000F0 RID: 240
	// (get) Token: 0x060024C6 RID: 9414 RVA: 0x00423BA0 File Offset: 0x00421DA0
	public int DataIdx
	{
		get
		{
			return this._DataIdx;
		}
	}

	// Token: 0x060024C7 RID: 9415 RVA: 0x00423BA8 File Offset: 0x00421DA8
	public byte GetRemainCount()
	{
		if (this.GiftCount > this.ListCount)
		{
			return this.GiftCount - this.ListCount;
		}
		return 0;
	}

	// Token: 0x04006F19 RID: 28441
	private int _DataIdx;

	// Token: 0x04006F1A RID: 28442
	public ushort ItemID;

	// Token: 0x04006F1B RID: 28443
	public byte GiftCount;

	// Token: 0x04006F1C RID: 28444
	public byte ListCount;

	// Token: 0x04006F1D RID: 28445
	public KingGiftInfo.GiftList[] List = new KingGiftInfo.GiftList[30];

	// Token: 0x02000767 RID: 1895
	public struct GiftList
	{
		// Token: 0x060024C8 RID: 9416 RVA: 0x00423BCC File Offset: 0x00421DCC
		public void Set(CString tagName, CString name, long userID)
		{
			if (this.Name == null)
			{
				this.Name = new CString(13);
				this.Tag = new CString(4);
				this.TageName = new CString(50);
			}
			this.Tag.ClearString();
			this.Tag.Append(tagName);
			this.Name.ClearString();
			this.Name.Append(name);
			this.UserID = userID;
		}

		// Token: 0x04006F1E RID: 28446
		public CString Tag;

		// Token: 0x04006F1F RID: 28447
		public CString TageName;

		// Token: 0x04006F20 RID: 28448
		public CString Name;

		// Token: 0x04006F21 RID: 28449
		public long UserID;
	}
}
