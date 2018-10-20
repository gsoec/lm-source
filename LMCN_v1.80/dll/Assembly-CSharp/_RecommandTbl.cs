using System;

// Token: 0x020003DE RID: 990
public struct _RecommandTbl
{
	// Token: 0x06001464 RID: 5220 RVA: 0x0023A60C File Offset: 0x0023880C
	public void CheckMin(ushort Min)
	{
		if (this.MinIndex < Min)
		{
			this.MinIndex = Min;
			this.SaveIndex = this.MinIndex;
		}
	}

	// Token: 0x06001465 RID: 5221 RVA: 0x0023A630 File Offset: 0x00238830
	public void Reset()
	{
		this.SaveIndex = 1;
	}

	// Token: 0x04003D64 RID: 15716
	public ushort[] RecommandID;

	// Token: 0x04003D65 RID: 15717
	public byte[] Achievement;

	// Token: 0x04003D66 RID: 15718
	public ushort MinIndex;

	// Token: 0x04003D67 RID: 15719
	public ushort SaveIndex;
}
