using System;

// Token: 0x020000FD RID: 253
public class WarlobbyTroop
{
	// Token: 0x060002F5 RID: 757 RVA: 0x00028040 File Offset: 0x00026240
	public WarlobbyTroop(int index)
	{
		this.ListIndex = (byte)index;
		this.AllyName = StringManager.Instance.SpawnString(13);
		this.TroopData = new uint[4][];
		for (int i = 0; i < this.TroopData.Length; i++)
		{
			this.TroopData[i] = new uint[4];
		}
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x000280AC File Offset: 0x000262AC
	public void Init(MessagePacket MP)
	{
		MP.ReadStringPlus(13, this.AllyName, -1);
		this.AllyNameID = this.AllyName.GetHashCode(false);
		this.AllyVIP = MP.ReadByte(-1);
		this.AllyRank = MP.ReadByte(-1);
		this.MarchTime.BeginTime = MP.ReadLong(-1);
		this.MarchTime.RequireTime = MP.ReadUInt(-1);
		this.TroopFlag = MP.ReadUShort(-1);
		this.TroopSize = 0;
		this.TotalTroopNum = 0u;
		for (int i = 0; i < 16; i++)
		{
			if ((this.TroopFlag >> i & 1) == 1)
			{
				this.TroopData[i >> 2][i & 3] = MP.ReadUInt(-1);
				this.TotalTroopNum += this.TroopData[i >> 2][i & 3];
				this.TroopSize += 1;
			}
			else
			{
				this.TroopData[i >> 2][i & 3] = 0u;
			}
		}
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x000281AC File Offset: 0x000263AC
	public void Empty()
	{
		this.AllyName.ClearString();
		this.AllyNameID = 0;
		this.AllyVIP = (this.AllyRank = (this.TroopSize = 0));
		this.TroopFlag = 0;
		this.TotalTroopNum = 0u;
		this.CombatPower = 0u;
	}

	// Token: 0x04000B59 RID: 2905
	public byte ListIndex;

	// Token: 0x04000B5A RID: 2906
	public CString AllyName;

	// Token: 0x04000B5B RID: 2907
	public int AllyNameID;

	// Token: 0x04000B5C RID: 2908
	public byte AllyVIP;

	// Token: 0x04000B5D RID: 2909
	public byte AllyRank;

	// Token: 0x04000B5E RID: 2910
	public TimeEventDataType MarchTime;

	// Token: 0x04000B5F RID: 2911
	public ushort TroopFlag;

	// Token: 0x04000B60 RID: 2912
	public uint TotalTroopNum;

	// Token: 0x04000B61 RID: 2913
	public byte TroopSize;

	// Token: 0x04000B62 RID: 2914
	public uint[][] TroopData;

	// Token: 0x04000B63 RID: 2915
	public static byte DelIndex = byte.MaxValue;

	// Token: 0x04000B64 RID: 2916
	public uint CombatPower;
}
