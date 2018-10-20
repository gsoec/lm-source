using System;

namespace UnityEngine.UI
{
	// Token: 0x020007F6 RID: 2038
	internal static class SetPropertyUtility
	{
		// Token: 0x06002A4A RID: 10826 RVA: 0x00469F88 File Offset: 0x00468188
		public static bool SetColor(ref Color currentValue, Color newValue)
		{
			if (currentValue.r == newValue.r && currentValue.g == newValue.g && currentValue.b == newValue.b && currentValue.a == newValue.a)
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}

		// Token: 0x06002A4B RID: 10827 RVA: 0x00469FE8 File Offset: 0x004681E8
		public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
		{
			if (currentValue.Equals(newValue))
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}

		// Token: 0x06002A4C RID: 10828 RVA: 0x0046A00C File Offset: 0x0046820C
		public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
		{
			if ((currentValue == null && newValue == null) || (currentValue != null && currentValue.Equals(newValue)))
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}
	}
}
