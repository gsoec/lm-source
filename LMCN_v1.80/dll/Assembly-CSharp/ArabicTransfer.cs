using System;
using System.Globalization;
using System.Text;
using StringExtensions;

// Token: 0x0200002D RID: 45
public class ArabicTransfer
{
	// Token: 0x06000140 RID: 320 RVA: 0x00014FBC File Offset: 0x000131BC
	private ArabicTransfer()
	{
		for (int i = 0; i < this.ArabicRichTextBuffer.Length; i++)
		{
			this.ArabicRichTextBuffer[i] = new CString(17);
		}
		this.TempStr = new CString(1024);
		this.CharStr = new CString(1024);
		this.ArabicStr = new CString(1024);
	}

	// Token: 0x1700000A RID: 10
	// (get) Token: 0x06000141 RID: 321 RVA: 0x00015068 File Offset: 0x00013268
	public static ArabicTransfer Instance
	{
		get
		{
			if (ArabicTransfer._instance == null)
			{
				ArabicTransfer._instance = new ArabicTransfer();
			}
			return ArabicTransfer._instance;
		}
	}

	// Token: 0x06000142 RID: 322 RVA: 0x00015084 File Offset: 0x00013284
	public string Transfer(string str, CString tmpStr)
	{
		this.TempStr.ClearString();
		this.CharStr.ClearString();
		tmpStr.ClearString();
		this.ArabicRichEnd = 0;
		byte b = 0;
		byte b2 = 0;
		this.TextState = eTextCheck.Text_None;
		string empty = string.Empty;
		this.ArabicStr.ClearString();
		int strLen = str.GetStrLen();
		for (int i = 0; i < strLen; i++)
		{
			char c = str[i];
			if (c == '\0')
			{
				break;
			}
			byte b3 = 0;
			if (this.IsArabic(c))
			{
				this.ArabicStr.Append(c);
				if (this.CheckYenRule(str, i))
				{
					b = 1;
				}
			}
			else
			{
				if (this.ArabicStr.Length > 0)
				{
					this.TempStr.ClearString();
					this.TempStr.Append(ArabicFixerTool.Instance.FixLine(this.ArabicStr.ToString(), false));
					tmpStr.Insert(0, this.TempStr, this.TempStr.Length);
					this.ArabicStr.ClearString();
				}
				for (int j = 0; j < this.ReplaceStr[0].Length; j++)
				{
					if (this.ReplaceStr[0][j] == c)
					{
						c = this.ReplaceStr[1][j];
						this.TempStr.ClearString();
						this.TempStr.Append(c);
						tmpStr.Insert(0, this.TempStr, this.TempStr.Length);
						b3 = 1;
						break;
					}
				}
				if (b3 != 1)
				{
					if ((c >= '٠' && c <= '٩') || (c >= '۰' && c <= 'ۺ'))
					{
						tmpStr.Insert(0, this.PraseArabicNumber(str, ref i), this.TempStr.Length);
					}
					else if (c == '<')
					{
						tmpStr.Insert(0, this.PraseRichText(str, ref i), this.TempStr.Length);
					}
					else if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
					{
						tmpStr.Insert(0, this.PraseNumber(str, ref i), this.TempStr.Length);
					}
					else if (char.GetUnicodeCategory(c) == UnicodeCategory.Surrogate)
					{
						b2 = 1;
						tmpStr.Insert(0, this.Praseemotion(str, ref i), this.TempStr.Length);
					}
					else
					{
						this.TempStr.ClearString();
						this.TempStr.Append(c);
						tmpStr.Insert(0, this.TempStr, this.TempStr.Length);
					}
				}
			}
		}
		if (b2 == 1)
		{
			this.TextState |= eTextCheck.Text_Emoticon;
		}
		else
		{
			this.TextState |= eTextCheck.Text_NonEmoticon;
		}
		if (b != 0)
		{
			this.TextState |= eTextCheck.Text_Arabic;
			if (this.ArabicStr.Length > 0)
			{
				this.TempStr.ClearString();
				this.TempStr.Append(ArabicFixerTool.Instance.FixLine(this.ArabicStr.ToString(), false));
				tmpStr.Insert(0, this.TempStr, this.TempStr.Length);
			}
			return tmpStr.ToString();
		}
		this.TextState |= eTextCheck.Text_NonArabic;
		if (b2 == 1)
		{
			tmpStr.ClearString();
			tmpStr.Append(str);
			return tmpStr.ToString();
		}
		return str;
	}

	// Token: 0x06000143 RID: 323 RVA: 0x0001540C File Offset: 0x0001360C
	public bool IsArabic(char character)
	{
		return (character < '٠' || character > '٩') && (character < '۰' || character > 'ۺ') && ((character >= '؀' && character <= 'ۿ') || (character >= 'ݐ' && character <= 'ݿ') || (character >= 'ﭐ' && character <= 'ﰿ') || (character >= 'ﹰ' && character <= 'ﻼ'));
	}

	// Token: 0x06000144 RID: 324 RVA: 0x000154A8 File Offset: 0x000136A8
	public bool CheckYenRule(string str, int index)
	{
		return (index > 0 && this.IsArabic(str[index - 1])) || (index < str.Length - 1 && this.IsArabic(str[index + 1]));
	}

	// Token: 0x06000145 RID: 325 RVA: 0x000154F8 File Offset: 0x000136F8
	public bool IsYenText(char character, char prechar)
	{
		return character == 'و' && prechar == ')';
	}

	// Token: 0x06000146 RID: 326 RVA: 0x00015510 File Offset: 0x00013710
	public bool IsArabicStr(string str)
	{
		if (str == null)
		{
			return false;
		}
		for (int i = 0; i < str.Length; i++)
		{
			if (str[i] == '\0')
			{
				return false;
			}
			if (this.IsArabic(str[i]))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000147 RID: 327 RVA: 0x00015560 File Offset: 0x00013760
	private string PraseArabicNumber(string str, ref int index)
	{
		this.TempStr.ClearString();
		while (index < str.Length)
		{
			if (str[index] == '\0')
			{
				break;
			}
			if ((str[index] < '٠' || str[index] > '٩') && (str[index] < '۰' || str[index] > 'ۺ'))
			{
				break;
			}
			this.TempStr.Append(str[index]);
			index++;
		}
		if (this.TempStr.Length > 0)
		{
			index--;
		}
		return this.TempStr.ToString();
	}

	// Token: 0x06000148 RID: 328 RVA: 0x0001562C File Offset: 0x0001382C
	private string PraseNumber(string str, ref int index)
	{
		this.TempStr.ClearString();
		int strLen = str.GetStrLen();
		while (index < strLen)
		{
			if ((str[index] < '0' || str[index] > '9') && (str[index] != ',' && str[index] != '.' && str[index] != ':' && (str[index] < 'a' || str[index] > 'z')) && (str[index] < 'A' || str[index] > 'Z'))
			{
				break;
			}
			this.TempStr.Append(str[index]);
			index++;
		}
		if (this.TempStr.Length > 0)
		{
			index--;
		}
		return this.TempStr.ToString();
	}

	// Token: 0x06000149 RID: 329 RVA: 0x00015724 File Offset: 0x00013924
	private string PraseRichText(string str, ref int index)
	{
		this.TempStr.ClearString();
		if (index >= str.Length - 1)
		{
			return string.Empty;
		}
		char c = str[index + 1];
		if (c == 'c')
		{
			while (index < str.Length)
			{
				this.TempStr.Append(str[index]);
				if (str[index] == '\0' || str[index] == '>')
				{
					break;
				}
				index++;
			}
			int num = this.ArabicRichEnd++ % 10;
			this.ArabicRichTextBuffer[num].ClearString();
			this.ArabicRichTextBuffer[num].Append(this.TempStr);
			this.TempStr.ClearString();
			this.TempStr.Append("</color>");
		}
		else if (c == '/')
		{
			while (index < str.Length)
			{
				if (str[index] == '\0' || str[index] == '>')
				{
					break;
				}
				index++;
			}
			int num2 = 0;
			if (this.ArabicRichEnd > 0)
			{
				num2 = --this.ArabicRichEnd % 10;
			}
			this.TempStr.Append(this.ArabicRichTextBuffer[num2]);
		}
		return this.TempStr.ToString();
	}

	// Token: 0x0600014A RID: 330 RVA: 0x00015888 File Offset: 0x00013A88
	public CString ReserveString(CString str)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.Append(str);
		str.ClearString();
		for (int i = cstring.Length - 1; i >= 0; i--)
		{
			str.Append(cstring[i]);
		}
		return str;
	}

	// Token: 0x0600014B RID: 331 RVA: 0x000158D4 File Offset: 0x00013AD4
	private string GetKeyString(string str, int index, char keyEnd, byte bReserve = 0)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		while (index < str.Length)
		{
			if (str[index] == keyEnd)
			{
				break;
			}
			if (bReserve == 0)
			{
				cstring.Append(str[index]);
			}
			else
			{
				cstring2.ClearString();
				cstring2.Append(str[index]);
				cstring.Insert(0, cstring2, 1);
			}
			index++;
		}
		return cstring.ToString();
	}

	// Token: 0x0600014C RID: 332 RVA: 0x0001595C File Offset: 0x00013B5C
	private int FindStringPosition(string str, int index, string findStr)
	{
		int strLen = findStr.GetStrLen();
		if (index == 0 || index < strLen)
		{
			return -1;
		}
		while (index >= 0)
		{
			bool flag = true;
			if (index < strLen)
			{
				return -1;
			}
			for (int i = 0; i < strLen; i++)
			{
				if (findStr[i] != str[index - strLen + i])
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return index - strLen;
			}
			index--;
		}
		return -1;
	}

	// Token: 0x0600014D RID: 333 RVA: 0x000159D8 File Offset: 0x00013BD8
	private string PraseCustomParmeter(string str, ref int index)
	{
		this.TempStr.ClearString();
		while (index < str.Length)
		{
			char c = str[index];
			if (c != '%' && (c < 'a' || c > 'z'))
			{
				break;
			}
			this.TempStr.Append(c);
			index++;
		}
		if (this.TempStr.Length > 0)
		{
			index--;
		}
		return this.TempStr.ToString();
	}

	// Token: 0x0600014E RID: 334 RVA: 0x00015A64 File Offset: 0x00013C64
	private string Praseemotion(string str, ref int index)
	{
		this.TempStr.ClearString();
		char c = str[index];
		this.TempStr.Append(c);
		for (index++; index < str.Length; index++)
		{
			c = str[index];
			if (char.GetUnicodeCategory(c) != UnicodeCategory.Surrogate)
			{
				break;
			}
			this.TempStr.Append(c);
		}
		return this.TempStr.ToString();
	}

	// Token: 0x0600014F RID: 335 RVA: 0x00015AE8 File Offset: 0x00013CE8
	private int FindFirstChar(string str, ref int index, char ch)
	{
		int result = -1;
		for (int i = index; i < str.Length; i++)
		{
			if (str[i] == '\0')
			{
				break;
			}
			if (str[i] == ch)
			{
				result = i;
			}
		}
		return result;
	}

	// Token: 0x06000150 RID: 336 RVA: 0x00015B30 File Offset: 0x00013D30
	public string ReverseExceptNums(string _outTextField)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		int i = _outTextField.Length;
		while (i > 0)
		{
			i--;
			if (!char.IsDigit(_outTextField[i]))
			{
				if (num > 0)
				{
					stringBuilder.Append(_outTextField.Substring(i + 1, num));
				}
				num = 0;
				stringBuilder.Append(_outTextField[i]);
			}
			else
			{
				num++;
			}
		}
		if (num > 0)
		{
			stringBuilder.Append(_outTextField.Substring(0, num));
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0400026F RID: 623
	private const byte ArabicRichMax = 10;

	// Token: 0x04000270 RID: 624
	private CString TempStr;

	// Token: 0x04000271 RID: 625
	private CString CharStr;

	// Token: 0x04000272 RID: 626
	private CString ArabicStr;

	// Token: 0x04000273 RID: 627
	private CString[] ArabicRichTextBuffer = new CString[10];

	// Token: 0x04000274 RID: 628
	private int ArabicRichEnd;

	// Token: 0x04000275 RID: 629
	public eTextCheck TextState;

	// Token: 0x04000276 RID: 630
	private readonly char[][] ReplaceStr = new char[][]
	{
		new char[]
		{
			'(',
			')',
			'{',
			'}',
			'[',
			']'
		},
		new char[]
		{
			')',
			'(',
			'}',
			'{',
			']',
			'['
		}
	};

	// Token: 0x04000277 RID: 631
	private static ArabicTransfer _instance;
}
