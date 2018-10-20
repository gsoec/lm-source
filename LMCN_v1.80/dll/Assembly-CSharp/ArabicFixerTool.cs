using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using StringExtensions;

// Token: 0x0200002A RID: 42
public class ArabicFixerTool
{
	// Token: 0x17000008 RID: 8
	// (get) Token: 0x06000133 RID: 307 RVA: 0x00013DC8 File Offset: 0x00011FC8
	public static ArabicFixerTool Instance
	{
		get
		{
			if (ArabicFixerTool._instance == null)
			{
				ArabicFixerTool._instance = new ArabicFixerTool();
			}
			return ArabicFixerTool._instance;
		}
	}

	// Token: 0x06000134 RID: 308 RVA: 0x00013DE4 File Offset: 0x00011FE4
	private string RemoveTashkeel(string str, ref List<TashkeelLocation> tashkeelLocation)
	{
		tashkeelLocation.Clear();
		int strLen = str.GetStrLen();
		this.tashkeelStr.ClearString();
		for (int i = 0; i < strLen; i++)
		{
			if (str[i] == 'ً')
			{
				tashkeelLocation.Add(new TashkeelLocation('ً', i));
			}
			else if (str[i] == 'ٌ')
			{
				tashkeelLocation.Add(new TashkeelLocation('ٌ', i));
			}
			else if (str[i] == 'ٍ')
			{
				tashkeelLocation.Add(new TashkeelLocation('ٍ', i));
			}
			else if (str[i] == 'َ')
			{
				tashkeelLocation.Add(new TashkeelLocation('َ', i));
			}
			else if (str[i] == 'ُ')
			{
				tashkeelLocation.Add(new TashkeelLocation('ُ', i));
			}
			else if (str[i] == 'ِ')
			{
				tashkeelLocation.Add(new TashkeelLocation('ِ', i));
			}
			else if (str[i] == 'ّ')
			{
				tashkeelLocation.Add(new TashkeelLocation('ّ', i));
			}
			else if (str[i] == 'ْ')
			{
				tashkeelLocation.Add(new TashkeelLocation('ْ', i));
			}
			else if (str[i] == 'ٓ')
			{
				tashkeelLocation.Add(new TashkeelLocation('ٓ', i));
			}
			else
			{
				this.tashkeelStr.Append(str[i]);
			}
		}
		return this.tashkeelStr.ToString();
	}

	// Token: 0x06000135 RID: 309 RVA: 0x00013FA4 File Offset: 0x000121A4
	private unsafe void ReturnTashkeel(CString letters, List<TashkeelLocation> tashkeelLocation)
	{
		int num = 0;
		int length = letters.Length;
		fixed (string text = letters.ToString(), ptr = text + RuntimeHelpers.OffsetToStringData / 2)
		{
			for (int i = 0; i < length; i++)
			{
				num++;
				for (int j = 0; j < tashkeelLocation.Count; j++)
				{
					if (tashkeelLocation[j].position == num)
					{
						ptr[num] = tashkeelLocation[j].tashkeel;
						num++;
					}
				}
			}
		}
	}

	// Token: 0x06000136 RID: 310 RVA: 0x0001402C File Offset: 0x0001222C
	public unsafe string FixLine(string str, bool showTashkeel = false)
	{
		ArabicFixerTool.showTashkeel = showTashkeel;
		string value = this.RemoveTashkeel(str, ref this.tashkeelLocation);
		this.ctext1.ClearString();
		this.ctext2.ClearString();
		this.ctext1.Append(value);
		this.ctext2.Append(value);
		if (this.ctext1.Length == 0)
		{
			return string.Empty;
		}
		fixed (string text = this.ctext1.ToString())
		{
			fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				fixed (string text2 = this.ctext2.ToString())
				{
					fixed (char* ptr2 = text2 + RuntimeHelpers.OffsetToStringData / 2)
					{
						for (int i = 0; i < this.ctext1.Length; i++)
						{
							bool flag = false;
							if (i == 0)
							{
								ptr[i] = (char)ArabicTable.ArabicMapper.Convert((int)ptr[i]);
							}
							if (this.ctext1.Length - 1 > i)
							{
								ptr[i + 1] = (char)ArabicTable.ArabicMapper.Convert((int)ptr[i + 1]);
							}
							if (ptr[i] == 'ﻝ' && this.ctext1.Length - 1 > i)
							{
								if (ptr[i + 1] == 'ﺇ')
								{
									ptr[i] = 'ﻷ';
									ptr2[i + 1] = this.SkipChar;
									flag = true;
								}
								else if (ptr[i + 1] == 'ﺍ')
								{
									ptr[i] = 'ﻹ';
									ptr2[i + 1] = this.SkipChar;
									flag = true;
								}
								else if (ptr[i + 1] == 'ﺃ')
								{
									ptr[i] = 'ﻵ';
									ptr2[i + 1] = this.SkipChar;
									flag = true;
								}
								else if (ptr[i + 1] == 'ﺁ')
								{
									ptr[i] = 'ﻳ';
									ptr2[i + 1] = this.SkipChar;
									flag = true;
								}
							}
							if (!ArabicFixerTool.IsIgnoredCharacter(ptr[i]) && ptr[i] != 'A')
							{
								if (ArabicFixerTool.IsMiddleLetter(this.ctext1, i))
								{
									ptr2[i] = ptr[i] + '\u0003';
								}
								else if (ArabicFixerTool.IsFinishingLetter(this.ctext1, i))
								{
									ptr2[i] = ptr[i] + '\u0001';
								}
								else if (ArabicFixerTool.IsLeadingLetter(this.ctext1, i))
								{
									ptr2[i] = ptr[i] + '\u0002';
								}
							}
							if (flag)
							{
								i++;
								if (this.ctext1.Length - 1 > i)
								{
									ptr[i + 1] = (char)ArabicTable.ArabicMapper.Convert((int)ptr[i + 1]);
								}
							}
						}
						text2 = null;
						text = null;
						if (ArabicFixerTool.showTashkeel)
						{
							this.ReturnTashkeel(this.ctext2, this.tashkeelLocation);
						}
						this.ctext1.ClearString();
						this.ctext1.Append(this.ctext2);
						this.ctext2.ClearString();
						for (int j = this.ctext1.Length - 1; j >= 0; j--)
						{
							this.ctext2.Append(this.ctext1[j]);
						}
						return this.ctext2.ToString();
					}
				}
			}
		}
	}

	// Token: 0x06000137 RID: 311 RVA: 0x00014364 File Offset: 0x00012564
	private void SwapCH(ref char ch1, ref char ch2)
	{
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00014368 File Offset: 0x00012568
	internal static bool IsIgnoredCharacter(char ch)
	{
		bool flag = char.IsPunctuation(ch);
		bool flag2 = char.IsNumber(ch);
		bool flag3 = char.IsLower(ch);
		bool flag4 = char.IsUpper(ch);
		bool flag5 = char.IsSymbol(ch);
		bool flag6 = ch == 'ﭖ' || ch == 'ﭺ' || ch == 'ﮊ' || ch == 'ﮒ';
		bool flag7 = (ch <= '﻿' && ch >= 'ﹰ') || flag6;
		return flag || flag2 || flag3 || flag4 || flag5 || !flag7 || ch == 'a' || ch == '>' || ch == '<' || ch == '؛';
	}

	// Token: 0x06000139 RID: 313 RVA: 0x00014430 File Offset: 0x00012630
	internal static bool IsLeadingLetter(CString letters, int index)
	{
		return (index == 0 || letters[index - 1] == ' ' || letters[index - 1] == '*' || letters[index - 1] == 'A' || char.IsPunctuation(letters[index - 1]) || letters[index - 1] == '>' || letters[index - 1] == '<' || letters[index - 1] == 'ﺍ' || letters[index - 1] == 'ﺩ' || letters[index - 1] == 'ﺫ' || letters[index - 1] == 'ﺭ' || letters[index - 1] == 'ﺯ' || letters[index - 1] == 'ﮊ' || letters[index - 1] == 'ﻯ' || letters[index - 1] == 'ﻭ' || letters[index - 1] == 'ﺁ' || letters[index - 1] == 'ﺃ' || letters[index - 1] == 'ﺇ' || letters[index - 1] == 'ﺅ') && letters[index] != ' ' && letters[index] != 'ﺩ' && letters[index] != 'ﺫ' && letters[index] != 'ﺭ' && letters[index] != 'ﺯ' && letters[index] != 'ﮊ' && letters[index] != 'ﺍ' && letters[index] != 'ﺃ' && letters[index] != 'ﺇ' && letters[index] != 'ﻭ' && letters[index] != 'ﺀ' && index < letters.Length - 1 && letters[index + 1] != ' ' && !char.IsPunctuation(letters[index + 1]) && letters[index + 1] != 'ﺀ';
	}

	// Token: 0x0600013A RID: 314 RVA: 0x0001468C File Offset: 0x0001288C
	internal static bool IsFinishingLetter(CString letters, int index)
	{
		return index != 0 && letters[index - 1] != ' ' && letters[index - 1] != '*' && letters[index - 1] != 'A' && letters[index - 1] != 'ﺩ' && letters[index - 1] != 'ﺫ' && letters[index - 1] != 'ﺭ' && letters[index - 1] != 'ﺯ' && letters[index - 1] != 'ﮊ' && letters[index - 1] != 'ﻯ' && letters[index - 1] != 'ﻭ' && letters[index - 1] != 'ﺍ' && letters[index - 1] != 'ﺁ' && letters[index - 1] != 'ﺃ' && letters[index - 1] != 'ﺇ' && letters[index - 1] != 'ﺅ' && letters[index - 1] != 'ﺀ' && !char.IsPunctuation(letters[index - 1]) && letters[index - 1] != '>' && letters[index - 1] != '<' && letters[index] != ' ' && index < letters.Length && letters[index] != 'ﺀ';
	}

	// Token: 0x0600013B RID: 315 RVA: 0x00014828 File Offset: 0x00012A28
	internal static bool IsMiddleLetter(CString letters, int index)
	{
		if (index != 0 && letters[index] != ' ' && letters[index] != 'ﺍ' && letters[index] != 'ﺩ' && letters[index] != 'ﺫ' && letters[index] != 'ﺭ' && letters[index] != 'ﺯ' && letters[index] != 'ﮊ' && letters[index] != 'ﻯ' && letters[index] != 'ﻭ' && letters[index] != 'ﺁ' && letters[index] != 'ﺃ' && letters[index] != 'ﺇ' && letters[index] != 'ﺅ' && letters[index] != 'ﺀ' && letters[index - 1] != 'ﺍ' && letters[index - 1] != 'ﺩ' && letters[index - 1] != 'ﺫ' && letters[index - 1] != 'ﺭ' && letters[index - 1] != 'ﺯ' && letters[index - 1] != 'ﮊ' && letters[index - 1] != 'ﻯ' && letters[index - 1] != 'ﻭ' && letters[index - 1] != 'ﺁ' && letters[index - 1] != 'ﺃ' && letters[index - 1] != 'ﺇ' && letters[index - 1] != 'ﺅ' && letters[index - 1] != 'ﺀ' && letters[index - 1] != '>' && letters[index - 1] != '<' && letters[index - 1] != ' ' && letters[index - 1] != '*' && !char.IsPunctuation(letters[index - 1]) && index < letters.Length - 1 && letters[index + 1] != ' ' && letters[index + 1] != '\r' && letters[index + 1] != 'A' && letters[index + 1] != '>' && letters[index + 1] != '>' && letters[index + 1] != 'ﺀ')
		{
			try
			{
				if (char.IsPunctuation(letters[index + 1]))
				{
					return false;
				}
				return true;
			}
			catch
			{
				return false;
			}
			return false;
		}
		return false;
	}

	// Token: 0x04000264 RID: 612
	public static bool showTashkeel = true;

	// Token: 0x04000265 RID: 613
	private List<TashkeelLocation> tashkeelLocation = new List<TashkeelLocation>();

	// Token: 0x04000266 RID: 614
	private CString ctext1 = new CString(512);

	// Token: 0x04000267 RID: 615
	private CString ctext2 = new CString(512);

	// Token: 0x04000268 RID: 616
	private CString tashkeelStr = new CString(512);

	// Token: 0x04000269 RID: 617
	private char SkipChar = Convert.ToChar(21);

	// Token: 0x0400026A RID: 618
	private static ArabicFixerTool _instance;
}
