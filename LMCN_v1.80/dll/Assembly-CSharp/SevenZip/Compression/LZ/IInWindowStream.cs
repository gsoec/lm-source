using System;
using System.IO;

namespace SevenZip.Compression.LZ
{
	// Token: 0x020006ED RID: 1773
	internal interface IInWindowStream
	{
		// Token: 0x060021C8 RID: 8648
		void SetStream(Stream inStream);

		// Token: 0x060021C9 RID: 8649
		void Init();

		// Token: 0x060021CA RID: 8650
		void ReleaseStream();

		// Token: 0x060021CB RID: 8651
		byte GetIndexByte(int index);

		// Token: 0x060021CC RID: 8652
		uint GetMatchLen(int index, uint distance, uint limit);

		// Token: 0x060021CD RID: 8653
		uint GetNumAvailableBytes();
	}
}
