using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020007B8 RID: 1976
public class BoyerMooreStringMatcher
{
	// Token: 0x060028B3 RID: 10419 RVA: 0x004489C4 File Offset: 0x00446BC4
	public BoyerMooreStringMatcher(string tmpStr)
	{
		if (this.Pattern == null)
		{
			this.Pattern = tmpStr.ToLower();
			this.BuildBadCharactorHeuristic();
			this.BuildGoodSuffixHeuristic();
		}
	}

	// Token: 0x060028B5 RID: 10421 RVA: 0x00448A38 File Offset: 0x00446C38
	public void UnLoad()
	{
		this.Pattern = null;
		this.badCharactorShifts.Clear();
		this.goodSuffixShifts = null;
	}

	// Token: 0x060028B6 RID: 10422 RVA: 0x00448A54 File Offset: 0x00446C54
	private static int Max(int a, int b)
	{
		return (a <= b) ? b : a;
	}

	// Token: 0x060028B7 RID: 10423 RVA: 0x00448A64 File Offset: 0x00446C64
	private static bool IsChinese(char mchar)
	{
		int num = Convert.ToInt32(mchar);
		return num >= BoyerMooreStringMatcher.dstringmin && num < BoyerMooreStringMatcher.dstringmax;
	}

	// Token: 0x060028B8 RID: 10424 RVA: 0x00448A94 File Offset: 0x00446C94
	private static bool CheckWord(char mchar)
	{
		return char.IsWhiteSpace(mchar) || char.IsSymbol(mchar) || char.IsPunctuation(mchar) || BoyerMooreStringMatcher.IsChinese(mchar);
	}

	// Token: 0x060028B9 RID: 10425 RVA: 0x00448AC8 File Offset: 0x00446CC8
	private void BuildBadCharactorHeuristic()
	{
		int length = this.Pattern.Length;
		for (int i = 0; i < length; i++)
		{
			if (!this.badCharactorShifts.ContainsKey(this.Pattern[i]))
			{
				this.badCharactorShifts.Add(this.Pattern[i], length - 1 - i);
			}
			else
			{
				this.badCharactorShifts[this.Pattern[i]] = length - 1 - i;
			}
		}
	}

	// Token: 0x060028BA RID: 10426 RVA: 0x00448B4C File Offset: 0x00446D4C
	private void BuildGoodSuffixHeuristic()
	{
		int length = this.Pattern.Length;
		this.goodSuffixShifts = new int[length];
		int[] suffixLengthArray = this.GetSuffixLengthArray();
		for (int i = 0; i < length; i++)
		{
			this.goodSuffixShifts[i] = length;
		}
		int j = 0;
		for (int k = length - 1; k >= -1; k--)
		{
			if (k == -1 || suffixLengthArray[k] == k + 1)
			{
				while (j < length - 1 - k)
				{
					if (this.goodSuffixShifts[j] == length)
					{
						this.goodSuffixShifts[j] = length - 1 - k;
					}
					j++;
				}
			}
		}
		for (int l = 0; l < length - 1; l++)
		{
			this.goodSuffixShifts[length - 1 - suffixLengthArray[l]] = length - 1 - l;
		}
	}

	// Token: 0x060028BB RID: 10427 RVA: 0x00448C20 File Offset: 0x00446E20
	private int[] GetSuffixLengthArray()
	{
		int length = this.Pattern.Length;
		int[] array = new int[length];
		int num = 0;
		array[length - 1] = length;
		int num2 = length - 1;
		for (int i = length - 2; i >= 0; i--)
		{
			if (i > num2 && array[i + length - 1 - num] < i - num2)
			{
				array[i] = array[i + length - 1 - num];
			}
			else
			{
				if (i < num2)
				{
					num2 = i;
				}
				num = i;
				while (num2 >= 0 && this.Pattern[num2] == this.Pattern[num2 + length - 1 - num])
				{
					num2--;
				}
				array[i] = num - num2;
			}
		}
		return array;
	}

	// Token: 0x060028BC RID: 10428 RVA: 0x00448CE0 File Offset: 0x00446EE0
	private int GetBadCharactorShift(char tmp)
	{
		if (this.badCharactorShifts.ContainsKey(tmp))
		{
			return this.badCharactorShifts[tmp];
		}
		return this.Pattern.Length;
	}

	// Token: 0x060028BD RID: 10429 RVA: 0x00448D0C File Offset: 0x00446F0C
	public bool TryMatch(string text, bool Accurate = false)
	{
		int length = text.Length;
		int length2 = this.Pattern.Length;
		int i = 0;
		while (i <= length - length2)
		{
			int num = length2 - 1;
			while (num >= 0 && this.Pattern[num] == char.ToLower(text[i + num]))
			{
				num--;
			}
			if (num < 0)
			{
				if (!Accurate || ((i == 0 || BoyerMooreStringMatcher.CheckWord(text[i - 1])) && (i + length2 == length || BoyerMooreStringMatcher.CheckWord(text[i + length2]))))
				{
					return true;
				}
				i += this.goodSuffixShifts[0];
			}
			else
			{
				i += BoyerMooreStringMatcher.Max(this.goodSuffixShifts[num], this.GetBadCharactorShift(char.ToLower(text[i + num])) - (length2 - 1) + num);
			}
		}
		return false;
	}

	// Token: 0x060028BE RID: 10430 RVA: 0x00448DF0 File Offset: 0x00446FF0
	public void CheckAndRePlace(char[] text, bool Accurate = false)
	{
		int num = text.Length;
		int length = this.Pattern.Length;
		int i = 0;
		while (i <= num - length)
		{
			int num2 = length - 1;
			while (num2 >= 0 && this.Pattern[num2] == char.ToLower(text[i + num2]))
			{
				num2--;
			}
			if (num2 < 0)
			{
				if (!Accurate || ((i == 0 || BoyerMooreStringMatcher.CheckWord(text[i - 1])) && (i + length == num || BoyerMooreStringMatcher.CheckWord(text[i + length]))))
				{
					for (int j = 0; j < length; j++)
					{
						text[i + j] = '*';
					}
				}
				i += this.goodSuffixShifts[0];
			}
			else
			{
				i += BoyerMooreStringMatcher.Max(this.goodSuffixShifts[num2], this.GetBadCharactorShift(char.ToLower(text[i + num2])) - (length - 1) + num2);
			}
		}
	}

	// Token: 0x060028BF RID: 10431 RVA: 0x00448EDC File Offset: 0x004470DC
	public unsafe void CheckAndRePlace(string text, bool Accurate = false)
	{
		int length = text.Length;
		int length2 = this.Pattern.Length;
		int i = 0;
		while (i <= length - length2)
		{
			int num = length2 - 1;
			while (num >= 0 && this.Pattern[num] == char.ToLower(text[i + num]))
			{
				num--;
			}
			if (num < 0)
			{
				if (!Accurate || ((i == 0 || BoyerMooreStringMatcher.CheckWord(text[i - 1])) && (i + length2 == length || BoyerMooreStringMatcher.CheckWord(text[i + length2]))))
				{
					fixed (string text2 = text, ptr = text2 + RuntimeHelpers.OffsetToStringData / 2)
					{
						for (int j = 0; j < length2; j++)
						{
							ptr[i + j] = '*';
						}
					}
				}
				i += this.goodSuffixShifts[0];
			}
			else
			{
				i += BoyerMooreStringMatcher.Max(this.goodSuffixShifts[num], this.GetBadCharactorShift(char.ToLower(text[i + num])) - (length2 - 1) + num);
			}
		}
	}

	// Token: 0x040072F6 RID: 29430
	public string Pattern;

	// Token: 0x040072F7 RID: 29431
	private Dictionary<char, int> badCharactorShifts = new Dictionary<char, int>();

	// Token: 0x040072F8 RID: 29432
	private int[] goodSuffixShifts;

	// Token: 0x040072F9 RID: 29433
	private static int dstringmax = Convert.ToInt32("9fff", 16);

	// Token: 0x040072FA RID: 29434
	private static int dstringmin = Convert.ToInt32("4e00", 16);
}
