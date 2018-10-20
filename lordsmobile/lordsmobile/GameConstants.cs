using System;
using System.Text;
using UnityEngine;

// Token: 0x020001B6 RID: 438
public static class GameConstants
{
	// Token: 0x06000709 RID: 1801 RVA: 0x0009F1F8 File Offset: 0x0009D3F8
	public static float FastInvSqrt(float x)
	{
		if (x < 1E-09f)
		{
			return 1E-09f;
		}
		float num = x * 0.5f;
		float num2 = x;
		int num3 = (int)num2;
		num3 = 1597463007 - (num3 >> 1);
		num2 = (float)num3;
		num2 *= 1.5f - num * num2 * num2;
		return num2;
	}

	// Token: 0x0600070A RID: 1802 RVA: 0x0009F244 File Offset: 0x0009D444
	public static float fastSine(float f)
	{
		return -(1.27323949f * f + -0.4052847f * f * ((f >= 0f) ? f : (-f)));
	}

	// Token: 0x0600070B RID: 1803 RVA: 0x0009F278 File Offset: 0x0009D478
	public static Vector3 MoveTowards(Vector3 current, Vector3 target, float deltaTime)
	{
		float num = target.x - current.x;
		float num2 = target.z - current.z;
		float num3 = GameConstants.FastInvSqrt(num * num + num2 * num2) * deltaTime;
		num3 = ((num3 <= 0.99f) ? num3 : 1f);
		float num4 = num * num3;
		float num5 = num2 * num3;
		GameConstants.Vec3Instance.Set(current.x + num4, 0f, current.z + num5);
		return GameConstants.Vec3Instance;
	}

	// Token: 0x0600070C RID: 1804 RVA: 0x0009F2FC File Offset: 0x0009D4FC
	public static Vector3 MoveTowardsPlus(Vector3 current, Vector3 target, float deltaTime)
	{
		float num = target.x - current.x;
		float num2 = target.y - current.y;
		float num3 = target.z - current.z;
		float num4 = GameConstants.FastInvSqrt(num * num + num2 * num2 + num3 * num3) * deltaTime;
		num4 = ((num4 <= 0.99f) ? num4 : 1f);
		float num5 = num * num4;
		float num6 = num2 * num4;
		float num7 = num3 * num4;
		GameConstants.Vec3Instance.Set(current.x + num5, current.y + num6, current.z + num7);
		return GameConstants.Vec3Instance;
	}

	// Token: 0x0600070D RID: 1805 RVA: 0x0009F3A0 File Offset: 0x0009D5A0
	public static float DistanceSquare(Vector3 p1, Vector3 p2)
	{
		float num = p2.x - p1.x;
		float num2 = p2.z - p1.z;
		return num * num + num2 * num2;
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x0009F3D4 File Offset: 0x0009D5D4
	public static DateTime GetDateTime(long Time)
	{
		Time = Time * 10000000L + 621355968000000000L;
		return DateTime.FromBinary((Time >= 0L && Time <= DateTime.MaxValue.Ticks) ? Time : 0L).ToLocalTime();
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x0009F428 File Offset: 0x0009D628
	public static ushort ConvertBytesToUShort(byte[] value, int startIdx)
	{
		if (startIdx < 0 || startIdx + 2 > value.Length)
		{
			startIdx = value.Length - 2;
		}
		return (ushort)((int)value[startIdx] | (int)value[startIdx + 1] << 8);
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x0009F45C File Offset: 0x0009D65C
	public static int ConvertBytesToInt(byte[] value, int startIdx)
	{
		if (startIdx < 0 || startIdx + 4 > value.Length)
		{
			startIdx = value.Length - 4;
		}
		return (int)value[startIdx] | (int)value[startIdx + 1] << 8 | (int)value[startIdx + 2] << 16 | (int)value[startIdx + 3] << 24;
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x0009F4A0 File Offset: 0x0009D6A0
	public static uint ConvertBytesToUInt(byte[] value, int startIdx)
	{
		return (uint)GameConstants.ConvertBytesToInt(value, startIdx);
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x0009F4BC File Offset: 0x0009D6BC
	public static long ConvertBytesToLong(byte[] value, int startIdx)
	{
		if (startIdx < 0 || startIdx + 8 > value.Length)
		{
			startIdx = value.Length - 8;
		}
		return (long)((int)value[startIdx] | (int)value[startIdx + 1] << 8 | (int)value[startIdx + 2] << 16 | (int)value[startIdx + 3] << 24 | (int)value[startIdx + 4] | (int)value[startIdx + 5] << 8 | (int)value[startIdx + 6] << 16 | (int)value[startIdx + 7] << 24);
	}

	// Token: 0x06000713 RID: 1811 RVA: 0x0009F520 File Offset: 0x0009D720
	public static float ConvertBytesToFloat(byte[] value, int startIdx)
	{
		return (float)GameConstants.ConvertBytesToInt(value, startIdx);
	}

	// Token: 0x06000714 RID: 1812 RVA: 0x0009F540 File Offset: 0x0009D740
	public static void GetBytes(ushort value, byte[] goal, int startIdx = 0)
	{
		if (startIdx < 0 || startIdx + 2 > goal.Length)
		{
			startIdx = goal.Length - 2;
		}
		goal[startIdx++] = (byte)(value & 255);
		goal[startIdx] = (byte)(value >> 8 & 255);
	}

	// Token: 0x06000715 RID: 1813 RVA: 0x0009F584 File Offset: 0x0009D784
	public static void GetBytes(uint value, byte[] goal, int startIdx = 0)
	{
		if (startIdx < 0 || startIdx + 4 > goal.Length)
		{
			startIdx = goal.Length - 4;
		}
		goal[startIdx++] = (byte)(value & 255u);
		goal[startIdx++] = (byte)(value >> 8 & 255u);
		goal[startIdx++] = (byte)(value >> 16 & 255u);
		goal[startIdx] = (byte)(value >> 24 & 255u);
	}

	// Token: 0x06000716 RID: 1814 RVA: 0x0009F5F0 File Offset: 0x0009D7F0
	public static void GetBytes(float value, byte[] goal, int startIdx = 0)
	{
		uint value2 = (uint)value;
		GameConstants.GetBytes(value2, goal, startIdx);
	}

	// Token: 0x06000718 RID: 1816 RVA: 0x0009F9A4 File Offset: 0x0009DBA4
	public static void ArrayFill<T>(T[] arrayToFill, T fillValue)
	{
		arrayToFill.Fill(new T[]
		{
			fillValue
		});
	}

	// Token: 0x06000719 RID: 1817 RVA: 0x0009F9BC File Offset: 0x0009DBBC
	public static void Fill<T>(this T[] destinationArray, params T[] value)
	{
		if (destinationArray == null || value.Length >= destinationArray.Length)
		{
			return;
		}
		Array.Copy(value, destinationArray, value.Length);
		int num = (destinationArray.Length % 2 == 0) ? (destinationArray.Length / 2) : (destinationArray.Length / 2 + 1);
		int i;
		for (i = value.Length; i < num; i <<= 1)
		{
			Array.Copy(destinationArray, 0, destinationArray, i, i);
		}
		Array.Copy(destinationArray, 0, destinationArray, i, destinationArray.Length - i);
	}

	// Token: 0x0600071A RID: 1818 RVA: 0x0009FA30 File Offset: 0x0009DC30
	public static void FormatResourceValue(StringBuilder sb, uint value)
	{
		if (value >= 1000000000u)
		{
			sb.AppendFormat("{0:#.##}B", value / 10000000u / 100f);
		}
		else if (value >= 100000000u)
		{
			sb.AppendFormat("{0}M", value / 1000000u);
		}
		else if (value >= 10000000u)
		{
			sb.AppendFormat("{0:#.#}M", value / 100000u / 10f);
		}
		else if (value >= 1000000u)
		{
			sb.AppendFormat("{0:#.##}M", value / 10000u / 100f);
		}
		else if (value >= 100000u)
		{
			sb.AppendFormat("{0}K", value / 1000u);
		}
		else if (value >= 10000u)
		{
			sb.AppendFormat("{0:#.#}K", value / 100u / 10f);
		}
		else if (value >= 1000u)
		{
			sb.AppendFormat("{0},{1:000}", value / 1000u, value % 1000u);
		}
		else
		{
			sb.Append(value);
		}
	}

	// Token: 0x0600071D RID: 1821 RVA: 0x0009FD1C File Offset: 0x0009DF1C
	public static void FormatValue(StringBuilder sb, uint value)
	{
		if (value >= 1000000000u)
		{
			sb.AppendFormat("{0},{1:000},{2:000},{3:000}", new object[]
			{
				value / 1000000000u,
				value % 1000000000u / 1000000u,
				value % 1000000u / 1000u,
				value % 1000u
			});
		}
		else if (value >= 1000000u)
		{
			sb.AppendFormat("{0},{1:000},{2:000}", value / 1000000u, value % 1000000u / 1000u, value % 1000u);
		}
		else if (value >= 1000u)
		{
			sb.AppendFormat("{0},{1:000}", value / 1000u, value % 1000u);
		}
		else
		{
			sb.Append(value);
		}
	}

	// Token: 0x0600071E RID: 1822 RVA: 0x0009FE18 File Offset: 0x0009E018
	public static void FormatEstimateValue(StringBuilder sb, uint value)
	{
		if (value >= 1000000000u)
		{
			sb.AppendFormat("~{0}B", value / 1000000000u);
		}
		else if (value >= 100000000u)
		{
			sb.AppendFormat("~{0}00M", value / 100000000u);
		}
		else if (value >= 10000000u)
		{
			sb.AppendFormat("~{0}0M", value / 10000000u);
		}
		else if (value >= 1000000u)
		{
			sb.AppendFormat("~{0}M", value / 1000000u);
		}
		else if (value >= 100000u)
		{
			sb.AppendFormat("~{0}00K", value / 100000u);
		}
		else if (value >= 10000u)
		{
			sb.AppendFormat("~{0}0K", value / 10000u);
		}
		else if (value >= 1000u)
		{
			sb.AppendFormat("~{0}K", value / 1000u);
		}
		else if (value >= 100u)
		{
			sb.AppendFormat("~{0}00", value / 100u);
		}
		else if (value >= 10u)
		{
			sb.AppendFormat("~{0}0", value / 10u);
		}
		else
		{
			sb.Append(value);
		}
	}

	// Token: 0x0600071F RID: 1823 RVA: 0x0009FF94 File Offset: 0x0009E194
	public static Vector2 MapPosToPointCode(Vector2 in_mapPos)
	{
		ushort num = (ushort)in_mapPos.x;
		ushort num2 = (ushort)in_mapPos.y;
		ushort num3 = (ushort)in_mapPos.x;
		ushort num4 = (ushort)in_mapPos.y;
		num = (ushort)(num >> 5);
		num2 = (ushort)(num2 >> 4);
		ushort num5 = num;
		num5 += (ushort)(num2 << 4);
		num3 = (ushort)(num3 >> 1);
		num3 &= 15;
		num4 &= 15;
		byte b = (byte)num3;
		b += (byte)(num4 << 4);
		in_mapPos.x = (float)num5;
		in_mapPos.y = (float)b;
		return in_mapPos;
	}

	// Token: 0x06000720 RID: 1824 RVA: 0x000A0010 File Offset: 0x0009E210
	public static Vector2 getTileMapPosbySpriteID(int in_spriteId)
	{
		if (in_spriteId > -1 && in_spriteId < 262144)
		{
			int num = in_spriteId >> 8;
			int num2 = ((in_spriteId & 255) << 1) + (num & 1);
			return new Vector2((float)num2, (float)num);
		}
		return Vector2.zero;
	}

	// Token: 0x06000723 RID: 1827 RVA: 0x000A0090 File Offset: 0x0009E290
	public static Mesh CreatePlane(Vector3 up, Vector3 right, Rect uvRect, Color color, float radius)
	{
		Mesh mesh = new Mesh();
		Vector3[] vertices = new Vector3[]
		{
			up * radius - right * radius,
			up * radius + right * radius,
			-up * radius - right * radius,
			-up * radius + right * radius
		};
		Vector2[] uv = new Vector2[]
		{
			new Vector2(uvRect.x, uvRect.y + uvRect.height),
			new Vector2(uvRect.x + uvRect.width, uvRect.y + uvRect.height),
			new Vector2(uvRect.x, uvRect.y),
			new Vector2(uvRect.x + uvRect.width, uvRect.y)
		};
		Color[] colors = new Color[]
		{
			color,
			color,
			color,
			color
		};
		int[] triangles = new int[]
		{
			0,
			1,
			3,
			0,
			3,
			2
		};
		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.colors = colors;
		mesh.SetTriangles(triangles, 0);
		return mesh;
	}

	// Token: 0x06000724 RID: 1828 RVA: 0x000A0248 File Offset: 0x0009E448
	public static Vector3 WordToVector3(ushort posx, ushort posy, ushort posz, int offset = -100, float in_decimal = 0.01f)
	{
		int num = 32768;
		int num2 = 32767;
		Vector2 vector = new Vector2(in_decimal, -in_decimal);
		Vector3 zero = Vector3.zero;
		zero.x = (float)((int)posx & num2) * vector[((int)posx & num) >> 15] + (float)offset;
		zero.y = (float)((int)posy & num2) * vector[((int)posy & num) >> 15] + (float)offset;
		zero.z = (float)((int)posz & num2) * vector[((int)posz & num) >> 15] + (float)offset;
		return zero;
	}

	// Token: 0x06000725 RID: 1829 RVA: 0x000A02C8 File Offset: 0x0009E4C8
	public static int PointCodeToMapID(ushort zoneID, byte pointID)
	{
		return ((int)(zoneID & 1023 & 15) << 4) + (int)(pointID & 15) + (((zoneID & 1023) >> 4 << 4) + (pointID >> 4) << 8);
	}

	// Token: 0x06000726 RID: 1830 RVA: 0x000A02F0 File Offset: 0x0009E4F0
	public static int TileMapPosToMapID(int in_posx, int in_posy)
	{
		return (in_posy << 8) + (++in_posx - (in_posy & 1) >> 1);
	}

	// Token: 0x06000727 RID: 1831 RVA: 0x000A0304 File Offset: 0x0009E504
	public static bool CheckTileMapPos(int in_posx, int in_posy)
	{
		return in_posx > -1 && in_posx < 512 && in_posy > -1 && in_posy < 1024;
	}

	// Token: 0x06000728 RID: 1832 RVA: 0x000A0338 File Offset: 0x0009E538
	public static void MapIDToPointCode(int mapID, out ushort zoneID, out byte pointID)
	{
		int num = mapID & 255;
		int num2 = mapID >> 8;
		zoneID = (ushort)((num2 >> 4 << 4) + (num >> 4));
		pointID = (byte)(((num2 & 15) << 4) + (num & 15));
	}

	// Token: 0x06000729 RID: 1833 RVA: 0x000A036C File Offset: 0x0009E56C
	public static Vector2 getTileMapPosbyMapID(int mapID)
	{
		if (mapID > -1 && mapID < 262144)
		{
			int num = mapID >> 8;
			int num2 = ((mapID & 255) << 1) + (num & 1);
			return new Vector2((float)num2, (float)num);
		}
		return Vector2.zero;
	}

	// Token: 0x0600072A RID: 1834 RVA: 0x000A03AC File Offset: 0x0009E5AC
	public static Vector2 getTileMapPosbyPointCode(ushort zoneID, byte pointID)
	{
		return GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(zoneID, pointID));
	}

	// Token: 0x0600072B RID: 1835 RVA: 0x000A03BC File Offset: 0x0009E5BC
	public static Vector2 CubicBezierCurves(Vector2 start, Vector2 center, Vector2 center2, Vector2 end, float inverseLength, float timeStep)
	{
		float num = timeStep * inverseLength;
		float num2 = 1f - num;
		return num2 * num2 * num2 * start + 3f * num * num2 * num2 * center + 3f * num2 * num * num * center2 + num * num * num * end;
	}

	// Token: 0x0600072C RID: 1836 RVA: 0x000A0420 File Offset: 0x0009E620
	public static Vector2 QuadraticBezierCurves(Vector2 start, Vector2 center, Vector2 end, float inverseLength, float timeStep)
	{
		float num = timeStep * inverseLength;
		float num2 = 1f - num;
		return num2 * num2 * start + 2f * num * num2 * center + num * num * end;
	}

	// Token: 0x0600072D RID: 1837 RVA: 0x000A0468 File Offset: 0x0009E668
	public static Vector3 QuadraticBezierCurves(Vector3 start, Vector3 center, Vector3 end, float inverseLength, float timeStep)
	{
		float num = timeStep * inverseLength;
		float num2 = 1f - num;
		return num2 * num2 * start + 2f * num * num2 * center + num * num * end;
	}

	// Token: 0x0600072E RID: 1838 RVA: 0x000A04B0 File Offset: 0x0009E6B0
	public static uint appCeil(float InFloat)
	{
		uint num = (uint)Mathf.Round(InFloat);
		float num2 = num;
		if (num2 < InFloat)
		{
			return (InFloat - num2 <= 0.01f) ? num : (num + 1u);
		}
		return num;
	}

	// Token: 0x0600073B RID: 1851 RVA: 0x000A15C4 File Offset: 0x0009F7C4
	public static bool IsBetween(int item, int start, int end)
	{
		return item >= start && item <= end;
	}

	// Token: 0x0600073C RID: 1852 RVA: 0x000A15DC File Offset: 0x0009F7DC
	public static bool IsBetween(long item, long start, long end)
	{
		return item >= start && item <= end;
	}

	// Token: 0x0600073D RID: 1853 RVA: 0x000A15F4 File Offset: 0x0009F7F4
	public static Vector3 HalfShortsToVector3(ushort x, ushort y, ushort z)
	{
		return new Vector3
		{
			x = ((x <= 32768) ? ((float)x) : ((float)x - 65535f)),
			y = ((y <= 32768) ? ((float)y) : ((float)y - 65535f)),
			z = ((z <= 32768) ? ((float)z) : ((float)z - 65535f))
		};
	}

	// Token: 0x06000740 RID: 1856 RVA: 0x000A16F4 File Offset: 0x0009F8F4
	public static void SetPivot(RectTransform rectTransform, Vector2 pivot)
	{
		if (rectTransform == null)
		{
			return;
		}
		Vector2 size = rectTransform.rect.size;
		Vector2 vector = rectTransform.pivot - pivot;
		Vector3 b = new Vector3(vector.x * size.x, vector.y * size.y);
		rectTransform.pivot = pivot;
		rectTransform.localPosition -= b;
	}

    // Token: 0x06000737 RID: 1847 RVA: 0x000A140C File Offset: 0x0009F60C
    public static void GetHostName(CString CStr, string in_ip, string hostname)
    {
        CStr.StringToFormat(hostname);
        CStr.StringToFormat(in_ip);
        CStr.StringToFormat(".igg.com");
        CStr.AppendFormat("{0}{1}{2}");
        byte b = 0;
        int num = 0;
        while (num < CStr.Length && b < 3)
        {
            if (CStr[num] == '.')
            {
                b += 1;
                CStr.SetChar(num, '-');
            }
            num++;
        }
    }

    // Token: 0x04001AA8 RID: 6824
    public const int TimeSpanHour = -5;

	// Token: 0x04001AA9 RID: 6825
	public const byte YolkMax = 40;

	// Token: 0x04001AAA RID: 6826
	public const ushort StageLineNum = 6;

	// Token: 0x04001AAB RID: 6827
	public const ushort FightButtonEff_keep = 65;

	// Token: 0x04001AAC RID: 6828
	public const ushort FightButtonEff_fight = 59;

	// Token: 0x04001AAD RID: 6829
	public const byte TileHeight = 128;

	// Token: 0x04001AAE RID: 6830
	public const byte TileMapInfoKindMax = 25;

	// Token: 0x04001AAF RID: 6831
	public const byte TileMapInfoWidthMaxOffSet = 8;

	// Token: 0x04001AB0 RID: 6832
	public const byte TileMapInfoHeightMaxOffSet = 10;

	// Token: 0x04001AB1 RID: 6833
	public const byte TileMapInfoWidthMaxSubTractOne = 255;

	// Token: 0x04001AB2 RID: 6834
	public const ushort TileMapInfoWidthMax = 256;

	// Token: 0x04001AB3 RID: 6835
	public const ushort TileMapInfoHeightMax = 1024;

	// Token: 0x04001AB4 RID: 6836
	public const ushort TileMapZoneNum = 1024;

	// Token: 0x04001AB5 RID: 6837
	public const int TileMapPointNum = 262144;

	// Token: 0x04001AB6 RID: 6838
	public const int TileMapZoneLineTableNum = 2048;

	// Token: 0x04001AB7 RID: 6839
	public const int TileMapRAMSataeInfoNum = 8;

	// Token: 0x04001AB8 RID: 6840
	public const int TileMapROMSataeInfoNum = 120;

	// Token: 0x04001AB9 RID: 6841
	public const byte UpdateZoneMax = 4;

	// Token: 0x04001ABA RID: 6842
	public const byte MAX_COMBAT_STAGE_SOLDIER = 10;

	// Token: 0x04001ABB RID: 6843
	public const int LineTableSize = 256;

	// Token: 0x04001ABC RID: 6844
	public const int ZonePointTableSize = 256;

	// Token: 0x04001ABD RID: 6845
	public const int PointTableSize = 2048;

	// Token: 0x04001ABE RID: 6846
	public const int ObstacleMin = 0;

	// Token: 0x04001ABF RID: 6847
	public const int ObstacleMax = 21;

	// Token: 0x04001AC0 RID: 6848
	public const int LineMax = 1048576;

	// Token: 0x04001AC1 RID: 6849
	public const float RequestMapdataWaiteTime = 1.5f;

	// Token: 0x04001AC2 RID: 6850
	public const byte KingdomUpdateMax = 32;

	// Token: 0x04001AC3 RID: 6851
	public const byte KingdomReqMax = 16;

	// Token: 0x04001AC4 RID: 6852
	public const byte OpenDareLeanChapterMax = 4;

	// Token: 0x04001AC5 RID: 6853
	public const int CanvasLayer = 5;

	// Token: 0x04001AC6 RID: 6854
	public const int DefaultLayer = 0;

	// Token: 0x04001AC7 RID: 6855
	public const byte MAX_BUFFER_LEN = 32;

	// Token: 0x04001AC8 RID: 6856
	public const byte MAX_BUFFER_CACHE = 128;

	// Token: 0x04001AC9 RID: 6857
	public const ushort MASK_MAP_OUT = 16384;

	// Token: 0x04001ACA RID: 6858
	public const ushort MASK_ZONE_ID = 1023;

	// Token: 0x04001ACB RID: 6859
	public const ushort KINGDOM_OPEN_TABLE_SIZE = 38;

	// Token: 0x04001ACC RID: 6860
	public const int MAP_WEAPONE_SHOW_TIME = 3;

	// Token: 0x04001ACD RID: 6861
	public const int PLAYER_NICKNAME_LEN = 10;

	// Token: 0x04001ACE RID: 6862
	public const int PLAYER_NAME_LEN = 12;

	// Token: 0x04001ACF RID: 6863
	public const int SOCIAL_NAME_LEN = 41;

	// Token: 0x04001AD0 RID: 6864
	public const int MAX_NAME = 13;

	// Token: 0x04001AD1 RID: 6865
	public const int MAX_TITLENAME = 3;

	// Token: 0x04001AD2 RID: 6866
	public const int MAX_NICKNAME = 41;

	// Token: 0x04001AD3 RID: 6867
	public const int MAX_TALKNAME = 18;

	// Token: 0x04001AD4 RID: 6868
	public const int MAX_TALKCONTENT = 400;

	// Token: 0x04001AD5 RID: 6869
	public const int ALLIANCE_TAG_LEN = 3;

	// Token: 0x04001AD6 RID: 6870
	public const int ALLIANCE_NAME_LEN = 20;

	// Token: 0x04001AD7 RID: 6871
	public const int ALLIANCE_HEADER_LEN = 20;

	// Token: 0x04001AD8 RID: 6872
	public const int ALLIANCE_NOTICE_LEN = 1300;

	// Token: 0x04001AD9 RID: 6873
	public const int ALLIANCE_BULLETIN_LEN = 900;

	// Token: 0x04001ADA RID: 6874
	public const int MAX_ALLIANCE_APPLYLIST = 100;

	// Token: 0x04001ADB RID: 6875
	public const int MAX_ALLIANCE_SEARCH_NUM = 100;

	// Token: 0x04001ADC RID: 6876
	public const int MAX_PLAYER_ALLIANCE_APPLY = 10;

	// Token: 0x04001ADD RID: 6877
	public const int MAX_ALLIANCE_SEARCH_ONEGROUP = 10;

	// Token: 0x04001ADE RID: 6878
	public const int MAX_ALLREPORT_SIZE = 130;

	// Token: 0x04001ADF RID: 6879
	public const int MAX_MAIL_NUM = 100;

	// Token: 0x04001AE0 RID: 6880
	public const int MAX_FAVOR_NUM = 100;

	// Token: 0x04001AE1 RID: 6881
	public const int MAX_SYSTEM_NUM = 50;

	// Token: 0x04001AE2 RID: 6882
	public const int MAX_REPORT_NUM = 400;

	// Token: 0x04001AE3 RID: 6883
	public const int MAX_MAILSIZE_NUM = 6;

	// Token: 0x04001AE4 RID: 6884
	public const int MAX_MAILATTACH_NUM = 6;

	// Token: 0x04001AE5 RID: 6885
	public const int MAX_MAILMULTIPLIER = 2;

	// Token: 0x04001AE6 RID: 6886
	public const int MAX_MAILTITLE_LEN = 32;

	// Token: 0x04001AE7 RID: 6887
	public const int MAX_MAILTITLES_LEN = 32;

	// Token: 0x04001AE8 RID: 6888
	public const int MAX_MAILINGPACK_NUM = 1;

	// Token: 0x04001AE9 RID: 6889
	public const int MAX_MAILINGSIZE_NUM = 10;

	// Token: 0x04001AEA RID: 6890
	public const int MAX_MAILCONTENT_LEN = 501;

	// Token: 0x04001AEB RID: 6891
	public const int MAX_COMBATREPORT_LEN = 100;

	// Token: 0x04001AEC RID: 6892
	public const int MAX_ANTISCOUTREPORT_NUM = 10;

	// Token: 0x04001AED RID: 6893
	public const int MAX_RESOURCEREPORT_NUM = 10;

	// Token: 0x04001AEE RID: 6894
	public const int MAX_COMBATREPORT_NUM = 100;

	// Token: 0x04001AEF RID: 6895
	public const int MAX_GATHERREPORT_NUM = 10;

	// Token: 0x04001AF0 RID: 6896
	public const int MAX_RECONREPORT_NUM = 10;

	// Token: 0x04001AF1 RID: 6897
	public const int MAX_GATHERITEM_NUM = 10;

	// Token: 0x04001AF2 RID: 6898
	public const int MAX_KINGDOM_NAME = 20;

	// Token: 0x04001AF3 RID: 6899
	public const int MAX_SEARCH_PLAYER = 20;

	// Token: 0x04001AF4 RID: 6900
	public const int KINGDOM_BULLITIN = 1024;

	// Token: 0x04001AF5 RID: 6901
	public const byte MAX_QB_NORMAL_TIMES = 10;

	// Token: 0x04001AF6 RID: 6902
	public const byte MAX_QB_ADVANCE_TIMES = 3;

	// Token: 0x04001AF7 RID: 6903
	public const byte MAX_QB_REWARD_NUM = 220;

	// Token: 0x04001AF8 RID: 6904
	public const byte MAX_HERO_EXPITEM_NUM = 6;

	// Token: 0x04001AF9 RID: 6905
	public const float WALL_HIT_X = 52f;

	// Token: 0x04001AFA RID: 6906
	public const float WALL_HIT_PARTICLE_X = 51f;

	// Token: 0x04001AFB RID: 6907
	public const float WAR_SCALE_FACTOR = 1.5f;

	// Token: 0x04001AFC RID: 6908
	public const int MAX_ALLIANCE_MEMBER = 100;

	// Token: 0x04001AFD RID: 6909
	public const int MAX_GROUP = 8;

	// Token: 0x04001AFE RID: 6910
	public const int MAP_WEAPON_ID = 9;

	// Token: 0x04001AFF RID: 6911
	public const int MAX_GROUP_EX = 10;

	// Token: 0x04001B00 RID: 6912
	public const int MAX_Hero = 5;

	// Token: 0x04001B01 RID: 6913
	public const int MAX_Fs_InfoPlayers = 30;

	// Token: 0x04001B02 RID: 6914
	public const int MAX_Prisoner = 30;

	// Token: 0x04001B03 RID: 6915
	public const byte MaxBuildLevel = 25;

	// Token: 0x04001B04 RID: 6916
	public const int MAX_TROOP_DATA_LEN = 64;

	// Token: 0x04001B05 RID: 6917
	public const byte MAX_ACTIVITY_GETSCORE_FACTOR_NUM = 6;

	// Token: 0x04001B06 RID: 6918
	public const byte MAX_ACTIVITY_RANK = 5;

	// Token: 0x04001B07 RID: 6919
	public const byte MAX_ACTIVITY_DEGREE = 3;

	// Token: 0x04001B08 RID: 6920
	public const byte MAX_ACTIVITY_PRIZE = 20;

	// Token: 0x04001B09 RID: 6921
	public const byte MAX_ACTIVITY_RANKING_REGION = 7;

	// Token: 0x04001B0A RID: 6922
	public const byte MAX_ALLIANCEMOBILIZATION_RANKING_REGION = 5;

	// Token: 0x04001B0B RID: 6923
	public const byte MAX_ACTIVITY_RANKING_PLACE = 100;

	// Token: 0x04001B0C RID: 6924
	public const ushort ACTIVITY_PREPARE_TIME = 300;

	// Token: 0x04001B0D RID: 6925
	public const byte MAX_ACTIVITY_MONSTER = 5;

	// Token: 0x04001B0E RID: 6926
	public const byte ALLIANCEWAR_RANKPRIZE_REGION = 5;

	// Token: 0x04001B0F RID: 6927
	public const byte MAX_ALLIANCEWAR_RANKPRIZE = 4;

	// Token: 0x04001B10 RID: 6928
	public const byte MAX_TREASURE_ALLIANCEGIFT_NUM = 5;

	// Token: 0x04001B11 RID: 6929
	public const byte MAX_TREASURE_COMBOBOX_ITEM = 200;

	// Token: 0x04001B12 RID: 6930
	public const byte MAX_TREASURE_BRIEF_COMBOBOX_ITEM = 3;

	// Token: 0x04001B13 RID: 6931
	public const byte MAX_MSG_TREASURE_DATA_NUM = 30;

	// Token: 0x04001B14 RID: 6932
	public const byte MAX_MSG_TREASURE_COMBOBOX_DATA_NUM = 9;

	// Token: 0x04001B15 RID: 6933
	public const byte MAX_TREASURE_LIST_NUM = 50;

	// Token: 0x04001B16 RID: 6934
	public const byte MAX_MSG_TREASURE_INFO_NUM = 25;

	// Token: 0x04001B17 RID: 6935
	public const byte MAX_TREASURE_EXTRADATA = 3;

	// Token: 0x04001B18 RID: 6936
	public const byte MAX_HERO_ENGAGE = 5;

	// Token: 0x04001B19 RID: 6937
	public const byte MAX_SKILL = 4;

	// Token: 0x04001B1A RID: 6938
	public const byte MAX_LORD_LEVEL = 60;

	// Token: 0x04001B1B RID: 6939
	public const byte MAX_RALLY_COUNT = 30;

	// Token: 0x04001B1C RID: 6940
	public const byte AllianceMoblizationMissionMax = 20;

	// Token: 0x04001B1D RID: 6941
	public const ushort MoblizationMissionCD = 1001;

	// Token: 0x04001B1E RID: 6942
	public const int MAX_ALLIANCEMOBILIZATION_DEGREE = 35;

	// Token: 0x04001B1F RID: 6943
	public const int MAX_ALLIANCEMOBILIZATION_DEGREEPRIZE_OPTION = 3;

	// Token: 0x04001B20 RID: 6944
	public const ushort mapeomjibackiconid = 65535;

	// Token: 0x04001B21 RID: 6945
	public const float mapemojiscale = 0.9f;

	// Token: 0x04001B22 RID: 6946
	public const float mapemojicityoffset = 92f;

	// Token: 0x04001B23 RID: 6947
	public const char SComma = ',';

	// Token: 0x04001B24 RID: 6948
	public const char SDot = '.';

	// Token: 0x04001B25 RID: 6949
	public const char SMinus = '-';

	// Token: 0x04001B26 RID: 6950
	public const char StringEnd = '\0';

	// Token: 0x04001B27 RID: 6951
	public const char SSpace = ' ';

	// Token: 0x04001B28 RID: 6952
	public const char SLeftBracket = '[';

	// Token: 0x04001B29 RID: 6953
	public const char SRightBracket = ']';

	// Token: 0x04001B2A RID: 6954
	public const char SSharp = '#';

	// Token: 0x04001B2B RID: 6955
	public const string SMultiply = "x{0}";

	// Token: 0x04001B2C RID: 6956
	public const string SPercent = "{0}%";

	// Token: 0x04001B2D RID: 6957
	public const string SNumber = "{0:N}";

	// Token: 0x04001B2E RID: 6958
	public const string SLessItemColor = "<color=#FF5581FF>";

	// Token: 0x04001B2F RID: 6959
	public const string SColorWhite = "<color=#FFFFFFFF>";

	// Token: 0x04001B30 RID: 6960
	public const string SColorEnd = "</color>";

	// Token: 0x04001B31 RID: 6961
	public const string baseHostName = ".igg.com";

	// Token: 0x04001B32 RID: 6962
	public const string baseLoginHostName = "lm-login-";

	// Token: 0x04001B33 RID: 6963
	public const string baseProxyHostName = "lm-proxy-";

	// Token: 0x04001B34 RID: 6964
	public const char RePlaceChar = '*';

	// Token: 0x04001B35 RID: 6965
	public const int BundleVersionCode = 168;

	// Token: 0x04001B36 RID: 6966
	public const ushort MonsterHeroID = 50000;

	// Token: 0x04001B37 RID: 6967
	public const ushort Arena_Effect = 9200;

	// Token: 0x04001B38 RID: 6968
	public const ushort FootBall_kick_time = 7200;

	// Token: 0x04001B39 RID: 6969
	public const ulong HeroPower = 1000000UL;

	// Token: 0x04001B3A RID: 6970
	public static readonly string[] TranslateLanguage = new string[]
	{
		"ar",
		"af",
		"aq",
		"bg",
		"ca",
		"zh-TW",
		"hr",
		"cs",
		"da",
		"nl",
		"en",
		"et",
		"fi",
		"fr",
		"de",
		"el",
		"iw",
		"hi",
		"hu",
		"id",
		"it",
		"ja",
		"ko",
		"lv",
		"lt",
		"ms",
		"no",
		"fa",
		"pl",
		"pt",
		"ro",
		"ru",
		"sr",
		"sk",
		"sl",
		"es",
		"sv",
		"th",
		"tr",
		"uk",
		"vi",
		"zh-CN"
	};

	// Token: 0x04001B3B RID: 6971
	public static readonly string[] TranslateTragetLanguage = new string[]
	{
		string.Empty,
		"en",
		"zh-TW",
		"fr",
		"de",
		"es",
		"ru",
		"zh-CN",
		"id",
		"vi",
		"tr",
		"th",
		"it",
		"pt",
		"ko",
		"ja",
		"uk",
		"ms",
		"ar"
	};

	// Token: 0x04001B3C RID: 6972
	public static readonly string[] GameLanguageName = new string[]
	{
		string.Empty,
		"EN",
		"TW",
		"FR",
		"DE",
		"ES",
		"RU",
		"CN",
		"ID",
		"VN",
		"TR",
		"TH",
		"IT",
		"PT",
		"KR",
		"JP",
		"UA",
		"MY",
		"ARB"
	};

	// Token: 0x04001B3D RID: 6973
	public static readonly string GameName = "Lords Mobile";

	// Token: 0x04001B3E RID: 6974
	public static readonly string HealthGame = "健康游戏忠告\n抵制不良游戏，拒绝盗版游戏。 注意自我保护，谨防受骗上当。\n适度游戏益脑，沉迷游戏伤身。 合理安排时间，享受健康生活。";

	// Token: 0x04001B3F RID: 6975
	public static readonly string HealthGameCN = "抵制不良游戏，拒绝盗版游戏。 注意自我保护，谨防受骗上当。\n适度游戏益脑，沉迷游戏伤身。 合理安排时间，享受健康生活。\n著作权人：IGG SINGAPORE PTE. LTD.  出版单位：福州天盟数码有限公司  批准文号：新广出审[2017]5382号\n出版物号：ISBN978-7-7979-8893-3  进口网络游戏批准号：网游进字〔2017〕0094 号";

	// Token: 0x04001B40 RID: 6976
	public static readonly string CommunityCN = "http://lordsmobile.igg.com/cn/";

	// Token: 0x04001B41 RID: 6977
	public static readonly string CommunityJP = "https://web.lobi.co/game/lords_mobile/group";

	// Token: 0x04001B42 RID: 6978
	public static readonly string CommunityKR = "http://cafe.naver.com/lordsmobile";

	// Token: 0x04001B43 RID: 6979
	public static readonly string CommunityRU = "https://vk.com/lordsmobile";

	// Token: 0x04001B44 RID: 6980
	public static readonly string Url176 = "http://lordsmobile.176.com/main.php";

	// Token: 0x04001B45 RID: 6981
	public static readonly string TWGameID = "1051019902";

	// Token: 0x04001B46 RID: 6982
	public static readonly string TWSecretKey = "f6239975b2faae941ec24695e4db5bba";

	// Token: 0x04001B47 RID: 6983
	public static readonly string TWGCMSenderId = "489219977954";

	// Token: 0x04001B48 RID: 6984
	public static readonly string TWPaymentKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEApLvdDnDjVKFDgVZGsDfdDyjNcpnvxFgST61I1CL1zdMoQ/9GUQ/mvBr4fw19uhC2gyD+vA8HqfhYJ8hpNPbUbDB9+MYnaPgufR6vEtFMnAr62DOSwcc4g8KRGCqiNO+wkTm5ytK6jx6ykD0TTYh4XhciQcNifdvJLBcS1s6xDMWjvcKPEMrCWz/KScmfPXrTnh/jlwu2bDafmVnzLED2CXDH3Z4mj0XaxR1YB9OxJJ4xaK2UytLMKKeVZLwGE3J6lXX+KnchHx/O/J2+7qCOJRNKbEbMLzFOSecN2UNqVHfCZbH1hqiSSVzwdF6maW5dK9rft/MLoJlaKCRyHVCbuQIDAQAB";

	// Token: 0x04001B49 RID: 6985
	public static readonly string[] GlobalEditionGameID = new string[]
	{
		string.Empty,
		"1051029902",
		"1051039902",
		"1051059902",
		"1051049902",
		"1051069902",
		"1051079902",
		"1051089902",
		"1051159902",
		"1051169902",
		"1051139902",
		"1051149902",
		"1051119902",
		"1051129902",
		"1051099902",
		"1051109902",
		"1051189902",
		"1051199902",
		"1051179902"
	};

	// Token: 0x04001B4A RID: 6986
	public static readonly string[] AmazonEditionGameID = new string[]
	{
		string.Empty,
		"1051019905",
		"1051029905",
		"1051039905",
		"1051049905",
		"1051059905",
		"1051069905",
		"1051079905",
		"1051149905",
		"1051159905",
		"1051129905",
		"1051139905",
		"1051109905",
		"1051119905",
		"1051089905",
		"1051099905",
		"1051169905",
		"1051179905",
		"1051189905"
	};

	// Token: 0x04001B4B RID: 6987
	public static readonly string[] AmazonEditionSecretKey = new string[]
	{
		string.Empty,
		"b871ac535980040bbee4a709e5c2d3df",
		"21bffb9414be3322275a762415040027",
		"e44587b24e8ba90a5584973009d3e4b8",
		"c3c0ebffb25a86d62e36a44f19deedc9",
		"26ddc0401c12488e3ea44c7eb842d89a",
		"f0819fc3facd9d6ba1d56366e8f59f38",
		"f52e263e05a4c767fd47b6ff8d0a1757",
		"eb0a69489d38efa9e4c1169182678c79",
		"4c9a49b2964e9014dd12dd8b55d1243e",
		"94579bde8cda536e6d6d193d55d2b6f8",
		"ab453a16ca366f808ae01c1682373b67",
		"01aca668352391f7c5d221ae11220a2a",
		"81cfe6c0bb1ecef902fe95ea951d0c53",
		"32e82273adac1dbbf88d5fddb4d911a9",
		"b698451d9fa306b72711286ee9e29622",
		"fdfc379ce3702c95765de698affcc5e8",
		"68327e5deb2dc00a4604060dc837fd15",
		"755058b572b2215ef3e69b9e264d7b2e"
	};

	// Token: 0x04001B4C RID: 6988
	public static readonly string[] GlobalEditionSecretKey = new string[]
	{
		string.Empty,
		"0d87c3e251c04d496196781e48da0abb",
		"92af4fd8e7dc4f1c299c29ec137d50e1",
		"cf62a92688a8ee779af1ed36802f7f01",
		"d3593cd0c41dd772b8f9b2e27b95a5a7",
		"215cac4e9adfb0ac829ff1f67a06a085",
		"20fe87550a4e157860a1c80377aa2b28",
		"236f724c3c121f4ea3f5b5be729c3229",
		"bd7270648b6b76407370fd95586d0075",
		"7fe03c9b27dd6fa068cbe6242dee2436",
		"db9a860cd48e730ef6f0b12030789fef",
		"f944f5fec0dedc1cb0ca338dc35bd54b",
		"37f0471f9b463562e2f5e4c406775e52",
		"6d02dc798cc6da28a14fee2c5256d389",
		"b1485ff2add0c83b3d2a0e584be9304f",
		"79d965a6e4208c0d2d2133e14cd1eccf",
		"72c0587b902d0a997794dffd1d23485a",
		"21902fdc5860b7f48fd33ce6d091aeae",
		"f69562f90d3b99c7424d9c91a3fe3945"
	};

	// Token: 0x04001B4D RID: 6989
	public static readonly string GlobalEditionGCMSenderId = "489219977954";

	// Token: 0x04001B4E RID: 6990
	public static readonly string GlobalEditionPaymentKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAjBWGQ7uE1DawEzXWEKCAeIfcqMCbmxZALu2CVtmQFAzwsWnGyowHxVcFVc1tAcBfnBWnP82KfdZ9MvilANRJ5iVNhEqYgfF7/orpkPChFIz8TJdgyNGaOjwHDsvcA5UJe5n5wBlIBFL4nGRi431gYGFPMr9Gi2jh2oUYPA+jolZlt1Xt4wVmkfR1eMVTNw+gDMlduvjZtVyOoZbFsvcvJbk4OJcP+SBvjyKk5N/8gWqr8KNMV/eUmMoKCzYkwHLB3SWuk47f12KbEIocRc2jEMvrCu7MtC+tjnHLr6/FbmhLThahR85xRdJtA41KpHbw6lTQytiF7Fh5CFc/I/t42QIDAQAB";

	// Token: 0x04001B4F RID: 6991
	public static readonly string CNGameID = "1051089911";

	// Token: 0x04001B50 RID: 6992
	public static readonly string CNSecretKey = "85325e58784353a8f9ae271fd996dc76";

	// Token: 0x04001B51 RID: 6993
	public static readonly string CNGCMSenderId = "489219977954";

	// Token: 0x04001B52 RID: 6994
	public static readonly string CNPaymentKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEApLvdDnDjVKFDgVZGsDfdDyjNcpnvxFgST61I1CL1zdMoQ/9GUQ/mvBr4fw19uhC2gyD+vA8HqfhYJ8hpNPbUbDB9+MYnaPgufR6vEtFMnAr62DOSwcc4g8KRGCqiNO+wkTm5ytK6jx6ykD0TTYh4XhciQcNifdvJLBcS1s6xDMWjvcKPEMrCWz/KScmfPXrTnh/jlwu2bDafmVnzLED2CXDH3Z4mj0XaxR1YB9OxJJ4xaK2UytLMKKeVZLwGE3J6lXX+KnchHx/O/J2+7qCOJRNKbEbMLzFOSecN2UNqVHfCZbH1hqiSSVzwdF6maW5dK9rft/MLoJlaKCRyHVCbuQIDAQAB";

	// Token: 0x04001B53 RID: 6995
	public static readonly string TWMailTo = "mailto:help.lordsonline.android.tw@igg.com";

	// Token: 0x04001B54 RID: 6996
	public static readonly string[] GlobalEditionMailTo = new string[]
	{
		string.Empty,
		"mailto:help.lordsmobile.android@igg.com",
		"mailto:service@fantasyplus.game.tw",
		"mailto:help.lordsmobile.android.fr@igg.com",
		"mailto:help.lordsmobile.android.de@igg.com",
		"mailto:help.lordsmobile.android.es@igg.com",
		"mailto:help.lordsmobile.android.ru@igg.com",
		"mailto:help.lordsmobile.android.cn@igg.com",
		"mailto:help.lordsmobile.android.id@igg.com",
		"mailto:help.lordsmobile.android.vn@igg.com",
		"mailto:help.lordsmobile.android.tr@igg.com",
		"mailto:help.lordsmobile.android.th@igg.com",
		"mailto:help.lordsmobile.android.it@igg.com",
		"mailto:help.lordsmobile.android.pt@igg.com",
		"mailto:help.lordsmobile.android.kr@igg.com",
		"mailto:help.lordsmobile.android.jp@igg.com",
		"mailto:help.lordsmobile.android.ua@igg.com",
		"mailto:help.lordsmobile.android.my@igg.com",
		"mailto:help.lordsmobile.android.arb@igg.com"
	};

	// Token: 0x04001B55 RID: 6997
	public static readonly string TWGuideURL = "http://lo.tw.igg.com/project/guide/?";

	// Token: 0x04001B56 RID: 6998
	public static readonly string GlobalEditionGuideURL = "http://lordsmobile.igg.com/project/guide/?";

	// Token: 0x04001B57 RID: 6999
	public static readonly string TWNewsUrl = "http://lo.tw.igg.com/project/news/?";

	// Token: 0x04001B58 RID: 7000
	public static readonly string GlobalEditionTWNewsUrl = "http://lordsmobile.igg.com/project/news/?";

	// Token: 0x04001B59 RID: 7001
	public static readonly string TWNewsUrlKey = "ebmQCLWxSdT5bUXu";

	// Token: 0x04001B5A RID: 7002
	public static readonly string GlobalEditionNewsUrlKey = "etuaxaXNbBANAzvFBvH";

	// Token: 0x04001B5B RID: 7003
	public static readonly string TWFbUrl = "https://www.facebook.com/LordsOnlineTW/";

	// Token: 0x04001B5C RID: 7004
	public static readonly string GlobalEditionFUrl = "https://www.facebook.com/lordsmobile/";

	// Token: 0x04001B5D RID: 7005
	public static readonly string InternalClassName = "com.IgeeRD2.LordsOnline";

	// Token: 0x04001B5E RID: 7006
	public static readonly string TWClassName = "com.igg.android.lordsonline_tw";

	// Token: 0x04001B5F RID: 7007
	public static readonly string GlobalEditionClassNames = "com.igg.android.lordsmobile";

	// Token: 0x04001B60 RID: 7008
	public static readonly string ThirdPartyUpadteURL = "http://lordsmobile.igg.com/payment/?game_id=";

	// Token: 0x04001B61 RID: 7009
	public static readonly ushort[] StagePointNum = new ushort[]
	{
		18,
		6,
		1,
		18
	};

	// Token: 0x04001B62 RID: 7010
	public static readonly ushort[] LinePointNum = new ushort[]
	{
		3,
		1,
		1,
		3
	};

	// Token: 0x04001B63 RID: 7011
	public static readonly ushort[] StageInfoSize = new ushort[]
	{
		12,
		48,
		0,
		18
	};

	// Token: 0x04001B64 RID: 7012
	public static readonly float[,] MAP_POS_EX = new float[,]
	{
		{
			0f,
			0f
		},
		{
			16f,
			0f
		},
		{
			32f,
			0f
		},
		{
			48f,
			0f
		},
		{
			64f,
			0f
		},
		{
			80f,
			0f
		},
		{
			96f,
			0f
		},
		{
			112f,
			0f
		},
		{
			0f,
			-16f
		},
		{
			16f,
			-16f
		},
		{
			32f,
			-16f
		},
		{
			48f,
			-16f
		},
		{
			64f,
			-16f
		},
		{
			80f,
			-16f
		},
		{
			96f,
			-16f
		},
		{
			-16f,
			48f
		},
		{
			0f,
			-32f
		},
		{
			16f,
			-32f
		},
		{
			32f,
			-32f
		},
		{
			48f,
			-32f
		},
		{
			64f,
			-32f
		},
		{
			-48f,
			32f
		},
		{
			-32f,
			32f
		},
		{
			-16f,
			32f
		},
		{
			0f,
			-48f
		},
		{
			16f,
			-48f
		},
		{
			32f,
			-48f
		},
		{
			-80f,
			16f
		},
		{
			-64f,
			16f
		},
		{
			-48f,
			16f
		},
		{
			-32f,
			16f
		},
		{
			-16f,
			16f
		},
		{
			0f,
			64f
		},
		{
			-112f,
			0f
		},
		{
			-96f,
			0f
		},
		{
			-80f,
			0f
		},
		{
			-64f,
			0f
		},
		{
			-48f,
			0f
		},
		{
			-32f,
			0f
		},
		{
			-16f,
			0f
		},
		{
			0f,
			48f
		},
		{
			16f,
			48f
		},
		{
			32f,
			48f
		},
		{
			-80f,
			-16f
		},
		{
			-64f,
			-16f
		},
		{
			-48f,
			-16f
		},
		{
			-32f,
			-16f
		},
		{
			-16f,
			-16f
		},
		{
			0f,
			32f
		},
		{
			16f,
			32f
		},
		{
			32f,
			32f
		},
		{
			48f,
			32f
		},
		{
			64f,
			32f
		},
		{
			-48f,
			-32f
		},
		{
			-32f,
			-32f
		},
		{
			-16f,
			-32f
		},
		{
			0f,
			16f
		},
		{
			16f,
			16f
		},
		{
			32f,
			16f
		},
		{
			48f,
			16f
		},
		{
			64f,
			16f
		},
		{
			80f,
			16f
		},
		{
			96f,
			16f
		},
		{
			-16f,
			-48f
		}
	};

	// Token: 0x04001B65 RID: 7013
	public static readonly byte[] troopSortByTeir = new byte[]
	{
		3,
		7,
		11,
		15,
		2,
		6,
		10,
		14,
		1,
		5,
		9,
		13,
		0,
		4,
		8,
		12
	};

	// Token: 0x04001B66 RID: 7014
	public static readonly byte[] trapSortByTeir = new byte[]
	{
		3,
		7,
		11,
		2,
		6,
		10,
		1,
		5,
		9,
		0,
		4,
		8
	};

	// Token: 0x04001B67 RID: 7015
	public static readonly double[] cryptInterest = new double[]
	{
		0.0,
		0.03,
		0.27,
		0.85
	};

	// Token: 0x04001B68 RID: 7016
	public static readonly uint[] CryptSecends = new uint[]
	{
		0u,
		604800u,
		1209600u,
		2592000u
	};

	// Token: 0x04001B69 RID: 7017
	public static byte MAX_TALENT_CACHE_NAME_BYTE = 40;

	// Token: 0x04001B6A RID: 7018
	public static ushort TalentSaveItemID = 1254;

	// Token: 0x04001B6B RID: 7019
	public static ushort LESaveItemID = 1256;

	// Token: 0x04001B6C RID: 7020
	public static ushort NewbieTeleportItemID = 1005;

	// Token: 0x04001B6D RID: 7021
	public static ushort AdvanceTeleportItemID = 1004;

	// Token: 0x04001B6E RID: 7022
	public static ushort WorldTeleportItemID = 1275;

	// Token: 0x04001B6F RID: 7023
	public static ushort RandomTeleportItemID = 1003;

	// Token: 0x04001B70 RID: 7024
	public static ushort WorldWarTeleportItemID = 1002;

	// Token: 0x04001B71 RID: 7025
	public static ushort[] RandomTB = new ushort[]
	{
		599,
		699,
		691,
		642,
		146,
		740,
		170,
		895,
		618,
		768,
		529,
		656,
		771,
		941,
		906,
		411,
		55,
		897,
		120,
		439,
		196,
		98,
		904,
		70,
		171,
		420,
		754,
		804,
		425,
		519,
		330,
		508,
		523,
		653,
		824,
		51,
		826,
		611,
		400,
		390,
		558,
		502,
		384,
		144,
		498,
		268,
		339,
		136,
		697,
		859,
		736,
		827,
		122,
		474,
		40,
		938,
		62,
		639,
		291,
		948,
		745,
		417,
		899,
		881,
		32,
		237,
		178,
		580,
		293,
		121,
		511,
		587,
		557,
		846,
		635,
		199,
		934,
		58,
		74,
		373,
		84,
		365,
		168,
		686,
		44,
		323,
		141,
		679,
		997,
		379,
		241,
		750,
		320,
		473,
		789,
		280,
		93,
		970,
		844,
		724,
		359,
		290,
		549,
		92,
		715,
		973,
		990,
		837,
		452,
		617,
		933,
		119,
		338,
		467,
		874,
		994,
		324,
		643,
		160,
		749,
		377,
		579,
		727,
		832,
		504,
		840,
		622,
		139,
		993,
		492,
		661,
		690,
		457,
		964,
		129,
		23,
		244,
		930,
		834,
		974,
		702,
		730,
		345,
		923,
		603,
		926,
		813,
		576,
		368,
		773,
		394,
		668,
		114,
		117,
		162,
		407,
		202,
		586,
		157,
		409,
		896,
		584,
		289,
		108,
		673,
		49,
		210,
		95,
		537,
		648,
		109,
		167,
		239,
		698,
		910,
		966,
		194,
		654,
		610,
		208,
		725,
		209,
		791,
		2,
		306,
		982,
		590,
		708,
		128,
		408,
		685,
		367,
		880,
		868,
		442,
		828,
		103,
		717,
		438,
		446,
		65,
		986,
		222,
		190,
		831,
		544,
		105,
		509,
		16,
		503,
		795,
		772,
		68,
		305,
		249,
		660,
		902,
		253,
		385,
		440,
		381,
		682,
		719,
		191,
		113,
		429,
		158,
		206,
		981,
		596,
		436,
		889,
		292,
		216,
		349,
		496,
		760,
		488,
		929,
		135,
		100,
		539,
		177,
		101,
		512,
		110,
		36,
		836,
		659,
		99,
		845,
		522,
		755,
		149,
		4,
		743,
		742,
		41,
		311,
		979,
		621,
		134,
		169,
		969,
		652,
		159,
		77,
		593,
		961,
		482,
		118,
		213,
		507,
		304,
		166,
		207,
		254,
		314,
		541,
		399,
		873,
		29,
		234,
		215,
		601,
		811,
		347,
		397,
		86,
		341,
		501,
		515,
		972,
		640,
		830,
		301,
		856,
		644,
		761,
		953,
		5,
		362,
		329,
		877,
		581,
		34,
		414,
		885,
		333,
		104,
		893,
		404,
		187,
		531,
		536,
		271,
		631,
		72,
		573,
		403,
		677,
		3,
		371,
		786,
		274,
		287,
		353,
		608,
		182,
		582,
		797,
		900,
		283,
		204,
		7,
		453,
		613,
		585,
		328,
		495,
		38,
		481,
		751,
		218,
		569,
		871,
		450,
		858,
		402,
		998,
		710,
		316,
		675,
		87,
		197,
		296,
		313,
		24,
		219,
		360,
		294,
		176,
		875,
		939,
		882,
		272,
		391,
		443,
		578,
		357,
		150,
		91,
		140,
		240,
		321,
		386,
		960,
		996,
		925,
		21,
		777,
		335,
		634,
		180,
		435,
		909,
		217,
		628,
		83,
		80,
		655,
		233,
		383,
		914,
		985,
		568,
		198,
		286,
		255,
		221,
		382,
		718,
		546,
		705,
		211,
		303,
		67,
		995,
		282,
		25,
		756,
		312,
		469,
		692,
		433,
		250,
		463,
		667,
		59,
		604,
		258,
		694,
		164,
		556,
		729,
		663,
		645,
		112,
		843,
		776,
		630,
		680,
		672,
		901,
		924,
		723,
		563,
		766,
		887,
		862,
		468,
		10,
		137,
		388,
		759,
		514,
		547,
		285,
		790,
		11,
		978,
		342,
		186,
		798,
		931,
		392,
		666,
		928,
		458,
		369,
		535,
		870,
		242,
		416,
		733,
		860,
		555,
		415,
		189,
		803,
		102,
		82,
		506,
		28,
		256,
		505,
		816,
		90,
		552,
		309,
		688,
		820,
		455,
		47,
		331,
		18,
		614,
		891,
		79,
		595,
		956,
		574,
		423,
		43,
		14,
		470,
		464,
		297,
		46,
		641,
		851,
		447,
		577,
		73,
		534,
		775,
		229,
		812,
		975,
		13,
		633,
		863,
		327,
		513,
		432,
		116,
		247,
		193,
		814,
		583,
		592,
		78,
		315,
		308,
		426,
		56,
		810,
		410,
		770,
		510,
		731,
		554,
		720,
		124,
		876,
		151,
		334,
		636,
		406,
		629,
		153,
		246,
		275,
		527,
		350,
		884,
		395,
		486,
		748,
		800,
		721,
		401,
		267,
		220,
		517,
		115,
		152,
		913,
		200,
		559,
		142,
		248,
		734,
		937,
		231,
		917,
		822,
		263,
		905,
		520,
		817,
		111,
		732,
		477,
		594,
		784,
		188,
		955,
		472,
		336,
		126,
		8,
		669,
		861,
		888,
		670,
		172,
		346,
		739,
		533,
		245,
		528,
		225,
		163,
		145,
		543,
		476,
		278,
		269,
		722,
		532,
		228,
		802,
		81,
		819,
		60,
		566,
		709,
		147,
		703,
		485,
		808,
		848,
		376,
		421,
		968,
		550,
		835,
		572,
		936,
		638,
		758,
		944,
		20,
		676,
		951,
		358,
		689,
		479,
		307,
		389,
		422,
		69,
		864,
		852,
		75,
		726,
		300,
		821,
		201,
		746,
		801,
		872,
		97,
		259,
		794,
		823,
		940,
		19,
		674,
		427,
		318,
		451,
		449,
		270,
		545,
		437,
		916,
		632,
		793,
		809,
		310,
		475,
		466,
		842,
		548,
		538,
		1,
		616,
		714,
		987,
		138,
		561,
		921,
		700,
		174,
		947,
		854,
		516,
		704,
		325,
		878,
		337,
		780,
		657,
		932,
		959,
		175,
		838,
		480,
		154,
		89,
		526,
		626,
		491,
		883,
		352,
		737,
		606,
		490,
		665,
		762,
		565,
		785,
		850,
		567,
		396,
		984,
		148,
		343,
		273,
		553,
		462,
		9,
		279,
		26,
		64,
		588,
		922,
		605,
		465,
		788,
		497,
		943,
		299,
		155,
		179,
		264,
		230,
		713,
		54,
		181,
		894,
		94,
		908,
		302,
		912,
		53,
		431,
		419,
		627,
		807,
		33,
		185,
		227,
		17,
		806,
		22,
		983,
		378,
		319,
		66,
		63,
		1000,
		500,
		281,
		478,
		687,
		132,
		869,
		232,
		867,
		647,
		243,
		918,
		945,
		96,
		332,
		143,
		6,
		701,
		853,
		88,
		12,
		678,
		744,
		991,
		866,
		460,
		949,
		499,
		530,
		412,
		387,
		156,
		898,
		471,
		326,
		214,
		260,
		763,
		45,
		521,
		890,
		564,
		361,
		695,
		815,
		295,
		372,
		915,
		363,
		48,
		847,
		277,
		919,
		298,
		600,
		957,
		380,
		224,
		818,
		562,
		525,
		252,
		841,
		127,
		413,
		651,
		461,
		782,
		664,
		71,
		954,
		855,
		226,
		623,
		619,
		752,
		61,
		518,
		31,
		792,
		671,
		489,
		716,
		524,
		30,
		375,
		971,
		825,
		935,
		494,
		952,
		15,
		52,
		598,
		454,
		398,
		706,
		76,
		212,
		778,
		977,
		753,
		637,
		989,
		707,
		907,
		205,
		257,
		235,
		493,
		418,
		364,
		693,
		266,
		597,
		487,
		829,
		658,
		927,
		223,
		571,
		769,
		540,
		238,
		107,
		405,
		711,
		106,
		344,
		445,
		942,
		456,
		192,
		351,
		173,
		712,
		251,
		37,
		747,
		130,
		607,
		591,
		839,
		833,
		483,
		920,
		560,
		620,
		879,
		696,
		609,
		35,
		366,
		799,
		980,
		774,
		612,
		317,
		783,
		428,
		123,
		374,
		735,
		849,
		340,
		356,
		424,
		946,
		988,
		184,
		484,
		684,
		131,
		57,
		125,
		39,
		738,
		575,
		857,
		967,
		602,
		165,
		551,
		542,
		728,
		958,
		764,
		796,
		203,
		681,
		757,
		683,
		741,
		999,
		624,
		911,
		288,
		42,
		615,
		355,
		236,
		625,
		85,
		27,
		787,
		779,
		903,
		441,
		805,
		459,
		765,
		865,
		322,
		950,
		434,
		354,
		892,
		976,
		370,
		992,
		767,
		262,
		276,
		962,
		50,
		448,
		444,
		133,
		183,
		161,
		662,
		430,
		650,
		393,
		348,
		963,
		261,
		646,
		781,
		284,
		265,
		195,
		886,
		589,
		965,
		570,
		649
	};

	// Token: 0x04001B72 RID: 7026
	public static Vector3 lineeomji = new Vector3(0f, 1.071f, 0f);

	// Token: 0x04001B73 RID: 7027
	public static Vector3 lineeomjiback = new Vector3(0f, 1.03f, 0.12f);

	// Token: 0x04001B74 RID: 7028
	public static readonly char[] numChar = new char[]
	{
		'0',
		'1',
		'2',
		'3',
		'4',
		'5',
		'6',
		'7',
		'8',
		'9'
	};

	// Token: 0x04001B75 RID: 7029
	public static readonly string[] SItemRareHeader = new string[]
	{
		string.Empty,
		"<color=#FFFFFFFF>",
		"<color=#4DDA65FF>",
		"<color=#74A5FFFF>",
		"<color=#C37DF9FF>",
		"<color=#F3D84EFF>",
		"<color=#FF8328FF>"
	};

	// Token: 0x04001B76 RID: 7030
	public static readonly ushort[] Version = new ushort[]
	{
		1,
		80,
		22
	};

	// Token: 0x04001B77 RID: 7031
	public static readonly string[] IPMan = new string[]
	{
		"192.243.44.63"
	};

	// Token: 0x04001B78 RID: 7032
	public static Color32 DefaultAmbientLight = new Color32(137, 137, 137, byte.MaxValue);

	// Token: 0x04001B79 RID: 7033
	public static readonly string[] m_Mail = new string[]
	{
		string.Empty,
		"help.lordsmobile.android@igg.com",
		"service@fantasyplus.game.tw",
		"help.lordsmobile.android.fr@igg.com",
		"help.lordsmobile.android.de@igg.com",
		"help.lordsmobile.android.es@igg.com",
		"help.lordsmobile.android.ru@igg.com",
		"help.lordsmobile.android.cn@igg.com",
		"help.lordsmobile.android.id@igg.com",
		"help.lordsmobile.android.vn@igg.com",
		"help.lordsmobile.android.tr@igg.com",
		"help.lordsmobile.android.th@igg.com",
		"help.lordsmobile.android.it@igg.com",
		"help.lordsmobile.android.pt@igg.com",
		"help.lordsmobile.android.kr@igg.com",
		"help.lordsmobile.android.jp@igg.com",
		"help.lordsmobile.android.ua@igg.com",
		"help.lordsmobile.android.my@igg.com",
		"help.lordsmobile.android.arb@igg.com"
	};

	// Token: 0x04001B7A RID: 7034
	public static Vector3 GoldGuy = new Vector3(22f, 181f, 224f);

	// Token: 0x04001B7B RID: 7035
	public static Vector3 GamblingGuy = new Vector3(128f, 181f, 150f);

	// Token: 0x04001B7C RID: 7036
	public static Vector3 Vec3Instance = new Vector3(0f, 0f, 0f);

	// Token: 0x04001B7D RID: 7037
	private static Vector3 inv_direction = default(Vector3);

	// Token: 0x04001B7E RID: 7038
	public static readonly double[] HeroRankMod = new double[]
	{
		0.0,
		0.03,
		0.1,
		0.18,
		0.3,
		0.45,
		0.65,
		0.9,
		1.0
	};

	// Token: 0x04001B7F RID: 7039
	public static readonly double[] HeroColorMod = new double[]
	{
		0.0,
		0.05,
		0.1,
		0.2,
		0.4,
		1.0
	};
}
