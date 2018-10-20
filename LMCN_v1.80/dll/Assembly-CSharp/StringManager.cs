using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020007B7 RID: 1975
public class StringManager
{
	// Token: 0x0600289E RID: 10398 RVA: 0x00447D34 File Offset: 0x00445F34
	private StringManager()
	{
		for (int i = 0; i < 50; i++)
		{
			CString item = new CString(1024);
			this.StaticString.Add(item);
		}
		for (int j = 0; j < this.ListCount; j++)
		{
			List<CString> list = this.GetList(j);
			if (list != null)
			{
				for (int k = 0; k < this.CountArray[j]; k++)
				{
					CString item2 = new CString(this.LengthArray[j]);
					list.Add(item2);
				}
			}
		}
		for (int l = 0; l < this.FormatS.Length; l++)
		{
			CString cstring = new CString(1024);
			this.FormatS[l] = cstring;
		}
	}

	// Token: 0x17000111 RID: 273
	// (get) Token: 0x060028A0 RID: 10400 RVA: 0x00447ED0 File Offset: 0x004460D0
	public static StringManager Instance
	{
		get
		{
			if (StringManager.instance == null)
			{
				StringManager.instance = new StringManager();
			}
			return StringManager.instance;
		}
	}

	// Token: 0x060028A1 RID: 10401 RVA: 0x00447EEC File Offset: 0x004460EC
	~StringManager()
	{
	}

	// Token: 0x060028A2 RID: 10402 RVA: 0x00447F24 File Offset: 0x00446124
	public CString StaticString1024()
	{
		this.StaticNowCount++;
		if (this.StaticNowCount >= 50)
		{
			this.StaticNowCount = 0;
		}
		this.StaticString[this.StaticNowCount].ClearString();
		return this.StaticString[this.StaticNowCount];
	}

	// Token: 0x060028A3 RID: 10403 RVA: 0x00447F7C File Offset: 0x0044617C
	private List<CString> GetList(int Index)
	{
		switch (Index)
		{
		case 0:
			return this.StringPool10;
		case 1:
			return this.StringPool30;
		case 2:
			return this.StringPool70;
		case 3:
			return this.StringPool100;
		case 4:
			return this.StringPool150;
		case 5:
			return this.StringPool300;
		case 6:
			return this.StringPool500;
		case 7:
			return this.StringPool800;
		case 8:
			return this.StringPool1200;
		case 9:
			return this.StringPool3500;
		default:
			return null;
		}
	}

	// Token: 0x060028A4 RID: 10404 RVA: 0x00448008 File Offset: 0x00446208
	private int CalculateIndex(int StringLength)
	{
		int result = -1;
		if (StringLength <= this.LengthArray[0])
		{
			return 0;
		}
		for (int i = 1; i < this.ListCount; i++)
		{
			if (StringLength > this.LengthArray[i - 1] && StringLength <= this.LengthArray[i])
			{
				result = i;
				break;
			}
		}
		return result;
	}

	// Token: 0x060028A5 RID: 10405 RVA: 0x00448064 File Offset: 0x00446264
	private int DeSpawnFindIndex(int StringLength)
	{
		for (int i = 0; i < this.ListCount; i++)
		{
			if (StringLength == this.LengthArray[i])
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x060028A6 RID: 10406 RVA: 0x0044809C File Offset: 0x0044629C
	public CString SpawnString(int StringLength = 30)
	{
		CString cstring = null;
		int num = this.CalculateIndex(StringLength);
		if (num == -1)
		{
			return cstring;
		}
		List<CString> list = this.GetList(num);
		if (list == null)
		{
			return cstring;
		}
		if (list.Count <= 0)
		{
			for (int i = 0; i < this.CountArray[num]; i++)
			{
				CString item = new CString(this.LengthArray[num]);
				list.Add(item);
			}
		}
		cstring = list[list.Count - 1];
		CString cstring2 = cstring;
		cstring2.ReferenceCount += 1;
		cstring.ClearString();
		list.RemoveAt(list.Count - 1);
		return cstring;
	}

	// Token: 0x060028A7 RID: 10407 RVA: 0x0044813C File Offset: 0x0044633C
	public bool DeSpawnString(CString str)
	{
		if (str == null)
		{
			return false;
		}
		if (str.ReferenceCount == 0)
		{
		}
		int num = this.DeSpawnFindIndex(str.MaxLength);
		if (num == -1)
		{
			return false;
		}
		List<CString> list = this.GetList(num);
		if (list != null)
		{
			str.ReferenceCount -= 1;
			list.Add(str);
			return true;
		}
		return false;
	}

	// Token: 0x060028A8 RID: 10408 RVA: 0x0044819C File Offset: 0x0044639C
	private unsafe static void reverse(CString s, int len)
	{
		if (s == null)
		{
			return;
		}
		int i = 0;
		int num = len - 1;
		while (i < num)
		{
			fixed (string text = s.ToString(), ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				char c = ptr[i];
				ptr[i] = ptr[num];
				ptr[num] = c;
				i++;
				num--;
			}
		}
	}

	// Token: 0x060028A9 RID: 10409 RVA: 0x004481FC File Offset: 0x004463FC
	public unsafe static int IntToStr(CString s, long x, int digits = 1, bool bNumber = false)
	{
		if (s == null)
		{
			return -1;
		}
		int i = 0;
		int num = 0;
		int num2 = (x >= 0L) ? 1 : -1;
		if (num2 < 0)
		{
			x *= -1L;
		}
		fixed (string text = s.ToString())
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				while (x != 0L)
				{
					if (bNumber && num == 3)
					{
						ptr[i++ * 2] = ',';
						num = 0;
					}
					ptr[i++ * 2] = GameConstants.numChar[(int)(checked((IntPtr)(x % 10L)))];
					x = (long)((double)x * 0.1);
					if (bNumber)
					{
						num++;
					}
				}
				while (i < digits)
				{
					ptr[i++ * 2] = GameConstants.numChar[0];
				}
				if (num2 < 0)
				{
					ptr[i++ * 2] = '-';
				}
				StringManager.reverse(s, i);
				ptr[i] = '\0';
				s.Length = i;
				text = null;
				return i;
			}
		}
	}

	// Token: 0x060028AA RID: 10410 RVA: 0x004482E4 File Offset: 0x004464E4
	public unsafe static int ulongToStr(CString s, ulong x, int digits = 1, bool bNumber = false)
	{
		if (s == null)
		{
			return -1;
		}
		int i = 0;
		int num = 0;
		fixed (string text = s.ToString())
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				while (x != 0UL)
				{
					if (bNumber && num == 3)
					{
						ptr[i++ * 2] = ',';
						num = 0;
					}
					ptr[i++ * 2] = GameConstants.numChar[(int)(checked((IntPtr)(x % 10UL)))];
					x = (ulong)(x * 0.1);
					if (bNumber)
					{
						num++;
					}
				}
				while (i < digits)
				{
					ptr[i++ * 2] = GameConstants.numChar[0];
				}
				StringManager.reverse(s, i);
				ptr[i] = '\0';
				s.Length = i;
				text = null;
				return i;
			}
		}
	}

	// Token: 0x060028AB RID: 10411 RVA: 0x00448398 File Offset: 0x00446598
	public unsafe static void FloatToStr(CString s, float f, int afterpoint = -1, bool bAfterPointShowZero = true)
	{
		int num = 1;
		int num2 = -1;
		int num3 = (f >= 0f) ? 1 : -1;
		if (num3 < 0)
		{
			f *= -1f;
		}
		long num4;
		if (afterpoint < 0)
		{
			num4 = (long)f;
			float num5 = f - (float)num4;
			afterpoint = 0;
			while ((double)num5 != 0.0 && (double)num5 >= 0.0)
			{
				num5 = f * (float)Math.Pow(10.0, (double)(afterpoint + 1));
				num4 = (long)num5;
				num5 -= (float)num4;
				afterpoint++;
			}
		}
		else
		{
			decimal num6 = (decimal)f;
			for (int i = 0; i < afterpoint; i++)
			{
				num6 *= 10m;
			}
			num4 = (long)num6;
		}
		while ((f *= 0.1f) >= 1f)
		{
			num++;
		}
		if (!bAfterPointShowZero && afterpoint > 0)
		{
			long num7 = num4;
			int num8 = 0;
			for (int j = 0; j < afterpoint; j++)
			{
				if (num7 % 10L != 0L)
				{
					break;
				}
				num8++;
				num7 /= 10L;
			}
			if (num8 > 0)
			{
				num4 /= (long)((int)Math.Pow(10.0, (double)num8));
				afterpoint -= num8;
			}
		}
		if (afterpoint > 0)
		{
			num2 = num;
			num = num + 1 + afterpoint;
		}
		if (num3 < 0)
		{
			num++;
			if (num2 != -1)
			{
				num2++;
			}
		}
		fixed (string text = s.ToString(), ptr = text + RuntimeHelpers.OffsetToStringData / 2)
		{
			for (int j = num; j >= 0; j--)
			{
				if (j == num)
				{
					ptr[j] = '\0';
				}
				else if (j == num2)
				{
					ptr[j] = '.';
				}
				else if (num3 < 0 && j == 0)
				{
					ptr[j] = '-';
				}
				else
				{
					long num9 = num4 % 10L;
					if (num9 < 0L)
					{
						num9 *= -1L;
					}
					ptr[j] = GameConstants.numChar[(int)(checked((IntPtr)num9))];
					num4 = (long)((int)((float)num4 * 0.1f));
				}
			}
			s.Length = num;
		}
	}

	// Token: 0x060028AC RID: 10412 RVA: 0x004485CC File Offset: 0x004467CC
	public unsafe static void DoubleToStr(CString s, double f, int afterpoint = -1, bool bAfterPointShowZero = true)
	{
		int num = 1;
		int num2 = -1;
		int num3 = (f >= 0.0) ? 1 : -1;
		if (num3 < 0)
		{
			f *= -1.0;
		}
		long num4;
		if (afterpoint < 0)
		{
			num4 = (long)f;
			double num5 = f - (double)num4;
			afterpoint = 0;
			while (num5 != 0.0 && num5 >= 0.0)
			{
				num5 = f * Math.Pow(10.0, (double)(afterpoint + 1));
				num4 = (long)num5;
				num5 -= (double)num4;
				afterpoint++;
			}
		}
		else
		{
			decimal num6 = (decimal)f;
			for (int i = 0; i < afterpoint; i++)
			{
				num6 *= 10m;
			}
			num4 = (long)num6;
		}
		while ((f *= 0.10000000149011612) >= 1.0)
		{
			num++;
		}
		if (!bAfterPointShowZero && afterpoint > 0)
		{
			long num7 = num4;
			int num8 = 0;
			for (int j = 0; j < afterpoint; j++)
			{
				if (num7 % 10L != 0L)
				{
					break;
				}
				num8++;
				num7 /= 10L;
			}
			if (num8 > 0)
			{
				num4 /= (long)((int)Math.Pow(10.0, (double)num8));
				afterpoint -= num8;
			}
		}
		if (afterpoint > 0)
		{
			num2 = num;
			num = num + 1 + afterpoint;
		}
		if (num3 < 0)
		{
			num++;
			if (num2 != -1)
			{
				num2++;
			}
		}
		fixed (string text = s.ToString(), ptr = text + RuntimeHelpers.OffsetToStringData / 2)
		{
			for (int j = num; j >= 0; j--)
			{
				if (j == num)
				{
					ptr[j] = '\0';
				}
				else if (j == num2)
				{
					ptr[j] = '.';
				}
				else if (num3 < 0 && j == 0)
				{
					ptr[j] = '-';
				}
				else
				{
					long num9 = num4 % 10L;
					if (num9 < 0L)
					{
						num9 *= -1L;
					}
					ptr[j] = GameConstants.numChar[(int)(checked((IntPtr)num9))];
					num4 = (long)((int)((float)num4 * 0.1f));
				}
			}
			s.Length = num;
		}
	}

	// Token: 0x060028AD RID: 10413 RVA: 0x0044880C File Offset: 0x00446A0C
	public bool IntToFormat(long x, int digits = 1, bool bNumber = false)
	{
		if (this.FormatStringCount < this.FormatS.Length)
		{
			StringManager.IntToStr(this.FormatS[this.FormatStringCount], x, digits, bNumber);
			this.FormatStringCount++;
			return true;
		}
		return false;
	}

	// Token: 0x060028AE RID: 10414 RVA: 0x00448854 File Offset: 0x00446A54
	public bool uLongToFormat(ulong x, int digits = 1, bool bNumber = false)
	{
		if (this.FormatStringCount < this.FormatS.Length)
		{
			StringManager.ulongToStr(this.FormatS[this.FormatStringCount], x, digits, bNumber);
			this.FormatStringCount++;
			return true;
		}
		return false;
	}

	// Token: 0x060028AF RID: 10415 RVA: 0x0044889C File Offset: 0x00446A9C
	public bool FloatToFormat(float f, int afterpoint = -1, bool bAfterPointShowZero = true)
	{
		if (this.FormatStringCount < this.FormatS.Length)
		{
			StringManager.FloatToStr(this.FormatS[this.FormatStringCount], f, afterpoint, bAfterPointShowZero);
			this.FormatStringCount++;
			return true;
		}
		return false;
	}

	// Token: 0x060028B0 RID: 10416 RVA: 0x004488D8 File Offset: 0x00446AD8
	public bool DoubleToFormat(double f, int afterpoint = -1, bool bAfterPointShowZero = true)
	{
		if (this.FormatStringCount < this.FormatS.Length)
		{
			StringManager.DoubleToStr(this.FormatS[this.FormatStringCount], f, afterpoint, bAfterPointShowZero);
			this.FormatStringCount++;
			return true;
		}
		return false;
	}

	// Token: 0x060028B1 RID: 10417 RVA: 0x00448914 File Offset: 0x00446B14
	public bool StringToFormat(CString tmpS)
	{
		if (this.FormatStringCount < this.FormatS.Length)
		{
			this.FormatS[this.FormatStringCount].ClearString();
			this.FormatS[this.FormatStringCount].Append(tmpS);
			this.FormatStringCount++;
			return true;
		}
		return false;
	}

	// Token: 0x060028B2 RID: 10418 RVA: 0x0044896C File Offset: 0x00446B6C
	public bool StringToFormat(string tmpS)
	{
		if (this.FormatStringCount < this.FormatS.Length)
		{
			this.FormatS[this.FormatStringCount].ClearString();
			this.FormatS[this.FormatStringCount].Append(tmpS);
			this.FormatStringCount++;
			return true;
		}
		return false;
	}

	// Token: 0x040072E2 RID: 29410
	public const int MAX_SSTRING = 50;

	// Token: 0x040072E3 RID: 29411
	private List<CString> StaticString = new List<CString>();

	// Token: 0x040072E4 RID: 29412
	private int StaticNowCount = -1;

	// Token: 0x040072E5 RID: 29413
	private int ListCount = 10;

	// Token: 0x040072E6 RID: 29414
	private int[] LengthArray = new int[]
	{
		10,
		50,
		70,
		100,
		150,
		300,
		500,
		800,
		1200,
		3500
	};

	// Token: 0x040072E7 RID: 29415
	private int[] CountArray = new int[]
	{
		150,
		100,
		50,
		30,
		20,
		10,
		10,
		5,
		3,
		3
	};

	// Token: 0x040072E8 RID: 29416
	private List<CString> StringPool10 = new List<CString>();

	// Token: 0x040072E9 RID: 29417
	private List<CString> StringPool30 = new List<CString>();

	// Token: 0x040072EA RID: 29418
	private List<CString> StringPool70 = new List<CString>();

	// Token: 0x040072EB RID: 29419
	private List<CString> StringPool100 = new List<CString>();

	// Token: 0x040072EC RID: 29420
	private List<CString> StringPool150 = new List<CString>();

	// Token: 0x040072ED RID: 29421
	private List<CString> StringPool300 = new List<CString>();

	// Token: 0x040072EE RID: 29422
	private List<CString> StringPool500 = new List<CString>();

	// Token: 0x040072EF RID: 29423
	private List<CString> StringPool800 = new List<CString>();

	// Token: 0x040072F0 RID: 29424
	private List<CString> StringPool1200 = new List<CString>();

	// Token: 0x040072F1 RID: 29425
	private List<CString> StringPool3500 = new List<CString>();

	// Token: 0x040072F2 RID: 29426
	public int FormatStringCount;

	// Token: 0x040072F3 RID: 29427
	public CString[] FormatS = new CString[50];

	// Token: 0x040072F4 RID: 29428
	public static string InputTemp = "1";

	// Token: 0x040072F5 RID: 29429
	private static StringManager instance;
}
