using System;

namespace StringExtensions
{
	// Token: 0x02000886 RID: 2182
	public static class StringformExtensions
	{
		// Token: 0x06002D59 RID: 11609 RVA: 0x0049082C File Offset: 0x0048EA2C
		public static int GetStrLen(this string str)
		{
			int i;
			for (i = 0; i < str.Length; i++)
			{
				if (str[i] == '\0')
				{
					break;
				}
			}
			return i;
		}
	}
}
