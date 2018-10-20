using System;
using System.IO;

namespace SevenZip
{
	// Token: 0x020006E7 RID: 1767
	public interface ICoder
	{
		// Token: 0x060021BD RID: 8637
		void Code(Stream inStream, Stream outStream, long inSize, long outSize, ICodeProgress progress);
	}
}
