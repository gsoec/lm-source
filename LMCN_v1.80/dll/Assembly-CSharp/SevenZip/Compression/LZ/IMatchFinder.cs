using System;

namespace SevenZip.Compression.LZ
{
	// Token: 0x020006EE RID: 1774
	internal interface IMatchFinder : IInWindowStream
	{
		// Token: 0x060021CE RID: 8654
		void Create(uint historySize, uint keepAddBufferBefore, uint matchMaxLen, uint keepAddBufferAfter);

		// Token: 0x060021CF RID: 8655
		uint GetMatches(uint[] distances);

		// Token: 0x060021D0 RID: 8656
		void Skip(uint num);
	}
}
