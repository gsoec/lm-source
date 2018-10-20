using System;

// Token: 0x020003BC RID: 956
public class LordEquipSet
{
	// Token: 0x060013A3 RID: 5027 RVA: 0x0022E954 File Offset: 0x0022CB54
	public LordEquipSet()
	{
		this.SerialNO = new uint[8];
	}

	// Token: 0x060013A4 RID: 5028 RVA: 0x0022E968 File Offset: 0x0022CB68
	public bool isInSet(uint serial)
	{
		for (int i = 0; i < this.SerialNO.Length; i++)
		{
			if (this.SerialNO[i] == serial)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060013A5 RID: 5029 RVA: 0x0022E9A0 File Offset: 0x0022CBA0
	public bool isSetEmpty()
	{
		for (int i = 0; i < this.SerialNO.Length; i++)
		{
			if (this.SerialNO[i] > 0u)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x04003C2F RID: 15407
	public CString Name;

	// Token: 0x04003C30 RID: 15408
	public uint[] SerialNO;
}
