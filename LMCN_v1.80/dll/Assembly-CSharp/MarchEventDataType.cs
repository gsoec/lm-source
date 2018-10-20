using System;
using System.Runtime.InteropServices;

// Token: 0x02000145 RID: 325
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MarchEventDataType
{
	// Token: 0x06000345 RID: 837 RVA: 0x00028AE4 File Offset: 0x00026CE4
	public bool IsAmbushCamp()
	{
		return this.bRallyHost == 1 && this.Type == EMarchEventType.EMET_Camp;
	}

	// Token: 0x06000346 RID: 838 RVA: 0x00028B00 File Offset: 0x00026D00
	public bool IsAmbushCampMarching()
	{
		return this.bRallyHost == 1 && this.Type == EMarchEventType.EMET_CampMarching;
	}

	// Token: 0x06000347 RID: 839 RVA: 0x00028B1C File Offset: 0x00026D1C
	public bool IsAmbushCampReturn()
	{
		return this.bRallyHost == 1 && this.Type == EMarchEventType.EMET_CampReturn;
	}

	// Token: 0x04000D40 RID: 3392
	public EMarchEventType Type;

	// Token: 0x04000D41 RID: 3393
	public ushort[] HeroID;

	// Token: 0x04000D42 RID: 3394
	public uint[][] TroopData;

	// Token: 0x04000D43 RID: 3395
	public PointCode Point;

	// Token: 0x04000D44 RID: 3396
	public uint[] ResourceGetCount;

	// Token: 0x04000D45 RID: 3397
	public uint Crystal;

	// Token: 0x04000D46 RID: 3398
	public uint MaxOverLoad;

	// Token: 0x04000D47 RID: 3399
	public POINT_KIND PointKind;

	// Token: 0x04000D48 RID: 3400
	public byte DesPointLevel;

	// Token: 0x04000D49 RID: 3401
	public string DesPlayerName;

	// Token: 0x04000D4A RID: 3402
	public byte bRallyHost;
}
