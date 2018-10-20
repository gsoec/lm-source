using System;
using System.Runtime.CompilerServices;

// Token: 0x020007B6 RID: 1974
public class CString
{
	// Token: 0x0600287B RID: 10363 RVA: 0x0044716C File Offset: 0x0044536C
	public CString(int Capacity)
	{
		this.m_MaxLength = Capacity;
		this.MyString = new string('\0', this.m_MaxLength);
	}

	// Token: 0x1700010E RID: 270
	// (get) Token: 0x0600287C RID: 10364 RVA: 0x00447190 File Offset: 0x00445390
	// (set) Token: 0x0600287D RID: 10365 RVA: 0x00447198 File Offset: 0x00445398
	public int Length
	{
		get
		{
			return this.m_Length;
		}
		set
		{
			if (value > 0 && value <= this.m_MaxLength)
			{
				this.m_Length = value;
			}
			else
			{
				this.ClearString();
			}
		}
	}

	// Token: 0x1700010F RID: 271
	// (get) Token: 0x0600287E RID: 10366 RVA: 0x004471C0 File Offset: 0x004453C0
	public int MaxLength
	{
		get
		{
			return this.m_MaxLength;
		}
	}

	// Token: 0x17000110 RID: 272
	public char this[int index]
	{
		get
		{
			if (index < this.MaxLength)
			{
				return this.MyString[index];
			}
			throw new IndexOutOfRangeException();
		}
	}

	// Token: 0x06002880 RID: 10368 RVA: 0x004471E8 File Offset: 0x004453E8
	~CString()
	{
		this.MyString = null;
	}

	// Token: 0x06002881 RID: 10369 RVA: 0x00447224 File Offset: 0x00445424
	public override string ToString()
	{
		return this.MyString;
	}

	// Token: 0x06002882 RID: 10370 RVA: 0x0044722C File Offset: 0x0044542C
	public unsafe void SetLength(int length)
	{
		fixed (string text = this.MyString)
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				int* ptr2 = (int*)ptr;
				if (length < 0 || length > this.m_MaxLength)
				{
					return;
				}
				ptr2[-1] = length;
				text = null;
				return;
			}
		}
	}

	// Token: 0x06002883 RID: 10371 RVA: 0x00447268 File Offset: 0x00445468
	public unsafe void ClearString()
	{
		if (this.MyString == null)
		{
			return;
		}
		this.m_Length = 0;
		fixed (string text = this.MyString)
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				*ptr = '\0';
				text = null;
				return;
			}
		}
	}

	// Token: 0x06002884 RID: 10372 RVA: 0x004472A0 File Offset: 0x004454A0
	public unsafe void SetChar(int index, char ch)
	{
		if (this.MyString == null)
		{
			return;
		}
		if (index < 0 || index >= this.m_MaxLength)
		{
			return;
		}
		fixed (string text = this.MyString)
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				if (index < this.m_Length)
				{
					ptr[index] = ch;
				}
				text = null;
				return;
			}
		}
	}

	// Token: 0x06002885 RID: 10373 RVA: 0x004472F4 File Offset: 0x004454F4
	private unsafe void InternalInsert(int StartIndex, string textS, int SLength)
	{
		if (textS == null || this.MyString == null)
		{
			return;
		}
		if (StartIndex < 0 || StartIndex >= this.m_MaxLength)
		{
			return;
		}
		if (StartIndex + SLength > this.m_MaxLength)
		{
			return;
		}
		if (this.m_Length + SLength > this.m_MaxLength)
		{
			return;
		}
		fixed (string text = this.MyString)
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				for (int i = this.m_Length - 1; i >= StartIndex; i--)
				{
					ptr[i + SLength] = this.MyString[i];
				}
				for (int i = 0; i < SLength; i++)
				{
					ptr[StartIndex + i] = textS[i];
				}
				this.m_Length += SLength;
				ptr[this.m_Length] = '\0';
				text = null;
				return;
			}
		}
	}

	// Token: 0x06002886 RID: 10374 RVA: 0x004473C4 File Offset: 0x004455C4
	public void Insert(int StartIndex, string textS, int SLength = -1)
	{
		if (textS == null)
		{
			return;
		}
		this.InternalInsert(StartIndex, textS, (SLength != -1) ? SLength : textS.Length);
	}

	// Token: 0x06002887 RID: 10375 RVA: 0x004473F4 File Offset: 0x004455F4
	public void Insert(int StartIndex, CString textS, int SLength = -1)
	{
		if (textS == null)
		{
			return;
		}
		this.InternalInsert(StartIndex, textS.ToString(), (SLength != -1) ? SLength : textS.Length);
	}

	// Token: 0x06002888 RID: 10376 RVA: 0x00447428 File Offset: 0x00445628
	private unsafe void InternalAppend(string value, int Lengthv)
	{
		if (this.MyString == null || value == null || Lengthv == 0)
		{
			return;
		}
		fixed (string text = this.MyString)
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				int num = 0;
				while (num < Lengthv && num + this.m_Length < this.m_MaxLength)
				{
					ptr[num + this.m_Length] = value[num];
					if (value[num] == '\0')
					{
						break;
					}
					num++;
				}
				this.m_Length = num + this.m_Length;
				if (this.m_Length < this.m_MaxLength)
				{
					ptr[this.m_Length] = '\0';
				}
				text = null;
				return;
			}
		}
	}

	// Token: 0x06002889 RID: 10377 RVA: 0x004474D4 File Offset: 0x004456D4
	public void Append(string value)
	{
		if (value == null)
		{
			return;
		}
		this.InternalAppend(value, value.Length);
	}

	// Token: 0x0600288A RID: 10378 RVA: 0x004474EC File Offset: 0x004456EC
	public void Append(CString value)
	{
		if (value == null)
		{
			return;
		}
		this.InternalAppend(value.ToString(), value.Length);
	}

	// Token: 0x0600288B RID: 10379 RVA: 0x00447508 File Offset: 0x00445708
	public unsafe void Append(char value)
	{
		if (this.MyString == null)
		{
			return;
		}
		if (this.m_Length < this.m_MaxLength)
		{
			fixed (string myString = this.MyString, ptr = myString + RuntimeHelpers.OffsetToStringData / 2)
			{
				ptr[this.m_Length++ * 2] = value;
				if (this.m_Length < this.m_MaxLength)
				{
					ptr[this.m_Length] = '\0';
				}
			}
		}
	}

	// Token: 0x0600288C RID: 10380 RVA: 0x00447578 File Offset: 0x00445778
	public unsafe void Append(char value, int repeatCount)
	{
		if (this.MyString == null || repeatCount <= 0)
		{
			return;
		}
		fixed (string text = this.MyString)
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				while (repeatCount > 0)
				{
					if (this.m_Length < this.m_MaxLength)
					{
						ptr[this.m_Length++ * 2] = value;
						repeatCount--;
					}
					else
					{
						repeatCount = 0;
					}
				}
				if (this.m_Length < this.m_MaxLength)
				{
					ptr[this.m_Length] = '\0';
				}
				text = null;
				return;
			}
		}
	}

	// Token: 0x0600288D RID: 10381 RVA: 0x00447608 File Offset: 0x00445808
	private void InternalAppendFormat(string format, int lengthf)
	{
		if (this.MyString == null || format == null)
		{
			return;
		}
		StringManager instance = StringManager.Instance;
		int num = 0;
		for (;;)
		{
			char c;
			if (num < lengthf)
			{
				c = format[num];
				num++;
				if (c == '}')
				{
					if (num >= lengthf || format[num] != '}')
					{
						break;
					}
					num++;
				}
				if (c == '{')
				{
					if (num >= lengthf || format[num] != '{')
					{
						num--;
						goto IL_8C;
					}
					num++;
				}
				this.Append(c);
				continue;
			}
			IL_8C:
			if (num == lengthf)
			{
				return;
			}
			num++;
			if (num == lengthf || (c = format[num]) < '0' || c > '9')
			{
				return;
			}
			int num2 = 0;
			do
			{
				num2 = num2 * 10 + (int)c - 48;
				num++;
				if (num == lengthf)
				{
					return;
				}
				c = format[num];
			}
			while (c >= '0' && c <= '9' && num2 < 1000000);
			CString[] formatS = instance.FormatS;
			if (num2 >= formatS.Length)
			{
				return;
			}
			while (num < lengthf && (c = format[num]) == ' ')
			{
				num++;
			}
			bool flag = false;
			int num3 = 0;
			if (c == ',')
			{
				num++;
				while (num < lengthf && format[num] == ' ')
				{
					num++;
				}
				if (num == lengthf)
				{
					return;
				}
				c = format[num];
				if (c == '-')
				{
					flag = true;
					num++;
					if (num == lengthf)
					{
						return;
					}
					c = format[num];
				}
				if (c < '0' || c > '9')
				{
					return;
				}
				do
				{
					num3 = num3 * 10 + (int)c - 48;
					num++;
					if (num == lengthf)
					{
						return;
					}
					c = format[num];
					if (c < '0' || c > '9')
					{
						break;
					}
				}
				while (num3 < 1000000);
			}
			while (num < lengthf && (c = format[num]) == ' ')
			{
				num++;
			}
			CString cstring = instance.StaticString1024();
			if (c == ':')
			{
				num++;
				while (num != lengthf)
				{
					c = format[num];
					num++;
					if (c == '{')
					{
						if (num >= lengthf || format[num] != '{')
						{
							return;
						}
						num++;
					}
					else if (c == '}')
					{
						if (num >= lengthf || format[num] != '}')
						{
							num--;
							goto IL_286;
						}
						num++;
					}
					cstring.Append(c);
				}
				return;
			}
			IL_286:
			if (c != '}')
			{
				return;
			}
			num++;
			CString cstring2 = null;
			if (formatS[num2] != null)
			{
				cstring2 = formatS[num2];
			}
			if (cstring2 == null)
			{
				cstring2 = instance.StaticString1024();
			}
			int num4 = num3 - cstring2.Length;
			if (!flag && num4 > 0)
			{
				this.Append(' ', num4);
			}
			this.Append(cstring2);
			if (flag && num4 > 0)
			{
				this.Append(' ', num4);
			}
		}
	}

	// Token: 0x0600288E RID: 10382 RVA: 0x00447914 File Offset: 0x00445B14
	public void AppendFormat(string format)
	{
		StringManager.Instance.FormatStringCount = 0;
		if (format == null)
		{
			return;
		}
		this.InternalAppendFormat(format, format.Length);
	}

	// Token: 0x0600288F RID: 10383 RVA: 0x00447938 File Offset: 0x00445B38
	public void AppendFormat(CString format)
	{
		StringManager.Instance.FormatStringCount = 0;
		if (format == null)
		{
			return;
		}
		this.InternalAppendFormat(format.ToString(), format.Length);
	}

	// Token: 0x06002890 RID: 10384 RVA: 0x0044796C File Offset: 0x00445B6C
	public bool IntToFormat(long x, int digits = 1, bool bNumber = false)
	{
		return StringManager.Instance.IntToFormat(x, digits, bNumber);
	}

	// Token: 0x06002891 RID: 10385 RVA: 0x0044797C File Offset: 0x00445B7C
	public bool uLongToFormat(ulong x, int digits = 1, bool bNumber = false)
	{
		return StringManager.Instance.uLongToFormat(x, digits, bNumber);
	}

	// Token: 0x06002892 RID: 10386 RVA: 0x0044798C File Offset: 0x00445B8C
	public bool FloatToFormat(float f, int afterpoint = -1, bool bAfterPointShowZero = true)
	{
		return StringManager.Instance.FloatToFormat(f, afterpoint, bAfterPointShowZero);
	}

	// Token: 0x06002893 RID: 10387 RVA: 0x0044799C File Offset: 0x00445B9C
	public bool DoubleToFormat(double f, int afterpoint = -1, bool bAfterPointShowZero = true)
	{
		return StringManager.Instance.DoubleToFormat(f, afterpoint, bAfterPointShowZero);
	}

	// Token: 0x06002894 RID: 10388 RVA: 0x004479AC File Offset: 0x00445BAC
	public bool StringToFormat(CString tmpS)
	{
		return StringManager.Instance.StringToFormat(tmpS);
	}

	// Token: 0x06002895 RID: 10389 RVA: 0x004479BC File Offset: 0x00445BBC
	public bool StringToFormat(string tmpS)
	{
		return StringManager.Instance.StringToFormat(tmpS);
	}

	// Token: 0x06002896 RID: 10390 RVA: 0x004479CC File Offset: 0x00445BCC
	public unsafe void ToUpper()
	{
		fixed (string text = this.MyString.ToString(), ptr = text + RuntimeHelpers.OffsetToStringData / 2)
		{
			for (int i = 0; i < this.m_Length; i++)
			{
				if ('a' <= this.MyString[i] && this.MyString[i] <= 'z')
				{
					ptr[i] = (char)((int)this.MyString[i] & -33);
				}
				else
				{
					ptr[i] = this.MyString[i];
				}
			}
		}
	}

	// Token: 0x06002897 RID: 10391 RVA: 0x00447A5C File Offset: 0x00445C5C
	public unsafe int GetHashCode(bool bToUpper = false)
	{
		int hashCode;
		if (bToUpper)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			fixed (string text = cstring.ToString(), ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				int num = 0;
				while (num < this.m_Length && num < cstring.MaxLength)
				{
					if ('a' <= this.MyString[num] && this.MyString[num] <= 'z')
					{
						ptr[num] = (char)((int)this.MyString[num] & -33);
					}
					else
					{
						ptr[num] = this.MyString[num];
					}
					num++;
				}
				ptr[num] = '\0';
				cstring.SetLength(num);
				hashCode = cstring.ToString().GetHashCode();
				cstring.SetLength(cstring.MaxLength);
			}
		}
		else
		{
			fixed (string myString = this.MyString, ptr2 = myString + RuntimeHelpers.OffsetToStringData / 2)
			{
				this.SetLength(this.m_Length);
				hashCode = this.MyString.GetHashCode();
				this.SetLength(this.m_MaxLength);
			}
		}
		return hashCode;
	}

	// Token: 0x06002898 RID: 10392 RVA: 0x00447B6C File Offset: 0x00445D6C
	public void Substring(CString s, int startIndex)
	{
		if (s == null || startIndex <= 0 || startIndex >= s.Length)
		{
			return;
		}
		this.Substring(s.ToString(), startIndex, s.Length - startIndex);
	}

	// Token: 0x06002899 RID: 10393 RVA: 0x00447BA8 File Offset: 0x00445DA8
	public void Substring(string s, int startIndex)
	{
		if (s == null || startIndex <= 0 || startIndex >= s.Length)
		{
			return;
		}
		this.Substring(s, startIndex, s.Length - startIndex);
	}

	// Token: 0x0600289A RID: 10394 RVA: 0x00447BE0 File Offset: 0x00445DE0
	public void Substring(string s, int startIndex, int length)
	{
		if (length == 0)
		{
			return;
		}
		this.InternalSubString(s, startIndex, length);
	}

	// Token: 0x0600289B RID: 10395 RVA: 0x00447BF4 File Offset: 0x00445DF4
	private unsafe void InternalSubString(string s, int startIndex, int length)
	{
		if (this.MyString == null || s == null)
		{
			return;
		}
		fixed (string text = this.MyString)
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				int num = 0;
				while (num < length && num < this.m_MaxLength && num + startIndex < s.Length)
				{
					ptr[num] = s[num + startIndex];
					if (s[num + startIndex] == '\0')
					{
						break;
					}
					num++;
				}
				this.m_Length = num;
				if (this.m_Length < this.m_MaxLength)
				{
					ptr[this.m_Length] = '\0';
				}
				text = null;
				return;
			}
		}
	}

	// Token: 0x0600289C RID: 10396 RVA: 0x00447C98 File Offset: 0x00445E98
	public void CheckBannedWord()
	{
		if (DataManager.Instance.m_BannedWord != null)
		{
			this.SetLength(this.Length);
			DataManager.Instance.m_BannedWord.CheckBannedWord(this.MyString);
			this.SetLength(this.MaxLength);
		}
	}

	// Token: 0x0600289D RID: 10397 RVA: 0x00447CE4 File Offset: 0x00445EE4
	public bool ChackHasBannedWord()
	{
		if (DataManager.Instance.m_BannedWord != null)
		{
			this.SetLength(this.Length);
			bool result = DataManager.Instance.m_BannedWord.ChackHasBannedWord(this.MyString);
			this.SetLength(this.MaxLength);
			return result;
		}
		return false;
	}

	// Token: 0x040072DE RID: 29406
	private int m_Length;

	// Token: 0x040072DF RID: 29407
	private int m_MaxLength;

	// Token: 0x040072E0 RID: 29408
	private string MyString;

	// Token: 0x040072E1 RID: 29409
	public byte ReferenceCount;
}
