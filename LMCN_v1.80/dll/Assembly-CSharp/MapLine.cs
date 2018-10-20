using System;
using UnityEngine;

// Token: 0x02000240 RID: 576
public class MapLine
{
	// Token: 0x060009E3 RID: 2531 RVA: 0x000D08A8 File Offset: 0x000CEAA8
	public MapLine()
	{
		this.playerName = new CString(13);
		this.allianceTag = new CString(4);
		this.MapLineInit();
	}

	// Token: 0x060009E4 RID: 2532 RVA: 0x000D08DC File Offset: 0x000CEADC
	public void MapLineInit()
	{
		this.playerName.ClearString();
		this.allianceTag.ClearString();
		this.lineID = 1048576u;
		this.begin = 0UL;
		this.during = 0u;
		this.lineFlag = 0;
		this.zoneNum = 0;
		this.Slope = (this.YIntercept = (this.XIntercept = 0.0));
		if (this.ZoneIDTable != null)
		{
			for (int i = 0; i < this.ZoneIDTable.Length; i++)
			{
				this.ZoneIDTable[i] = (int)this.lineID;
			}
		}
		this.lineObject = null;
	}

	// Token: 0x040022CD RID: 8909
	public uint lineID;

	// Token: 0x040022CE RID: 8910
	public CString playerName;

	// Token: 0x040022CF RID: 8911
	public CString allianceTag;

	// Token: 0x040022D0 RID: 8912
	public ushort kingdomID;

	// Token: 0x040022D1 RID: 8913
	public PointCode start;

	// Token: 0x040022D2 RID: 8914
	public PointCode end;

	// Token: 0x040022D3 RID: 8915
	public ulong begin;

	// Token: 0x040022D4 RID: 8916
	public uint during;

	// Token: 0x040022D5 RID: 8917
	public uint EXbegin;

	// Token: 0x040022D6 RID: 8918
	public uint EXduring;

	// Token: 0x040022D7 RID: 8919
	public byte lineFlag;

	// Token: 0x040022D8 RID: 8920
	public Vector2 zoneMax;

	// Token: 0x040022D9 RID: 8921
	public Vector2 zoneMin;

	// Token: 0x040022DA RID: 8922
	public double Slope;

	// Token: 0x040022DB RID: 8923
	public double YIntercept;

	// Token: 0x040022DC RID: 8924
	public double XIntercept;

	// Token: 0x040022DD RID: 8925
	public int[] ZoneIDTable = new int[8];

	// Token: 0x040022DE RID: 8926
	public ushort zoneNum;

	// Token: 0x040022DF RID: 8927
	public byte baseFlag;

	// Token: 0x040022E0 RID: 8928
	public ushort emojiID;

	// Token: 0x040022E1 RID: 8929
	public GameObject lineObject;
}
