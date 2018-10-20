using System;

namespace SevenZip.Compression.LZMA
{
	// Token: 0x020006F2 RID: 1778
	internal abstract class Base
	{
		// Token: 0x060021F7 RID: 8695 RVA: 0x00404458 File Offset: 0x00402658
		public static uint GetLenToPosState(uint len)
		{
			len -= 2u;
			if (len < 4u)
			{
				return len;
			}
			return 3u;
		}

		// Token: 0x04006AB0 RID: 27312
		public const uint kNumRepDistances = 4u;

		// Token: 0x04006AB1 RID: 27313
		public const uint kNumStates = 12u;

		// Token: 0x04006AB2 RID: 27314
		public const int kNumPosSlotBits = 6;

		// Token: 0x04006AB3 RID: 27315
		public const int kDicLogSizeMin = 0;

		// Token: 0x04006AB4 RID: 27316
		public const int kNumLenToPosStatesBits = 2;

		// Token: 0x04006AB5 RID: 27317
		public const uint kNumLenToPosStates = 4u;

		// Token: 0x04006AB6 RID: 27318
		public const uint kMatchMinLen = 2u;

		// Token: 0x04006AB7 RID: 27319
		public const int kNumAlignBits = 4;

		// Token: 0x04006AB8 RID: 27320
		public const uint kAlignTableSize = 16u;

		// Token: 0x04006AB9 RID: 27321
		public const uint kAlignMask = 15u;

		// Token: 0x04006ABA RID: 27322
		public const uint kStartPosModelIndex = 4u;

		// Token: 0x04006ABB RID: 27323
		public const uint kEndPosModelIndex = 14u;

		// Token: 0x04006ABC RID: 27324
		public const uint kNumPosModels = 10u;

		// Token: 0x04006ABD RID: 27325
		public const uint kNumFullDistances = 128u;

		// Token: 0x04006ABE RID: 27326
		public const uint kNumLitPosStatesBitsEncodingMax = 4u;

		// Token: 0x04006ABF RID: 27327
		public const uint kNumLitContextBitsMax = 8u;

		// Token: 0x04006AC0 RID: 27328
		public const int kNumPosStatesBitsMax = 4;

		// Token: 0x04006AC1 RID: 27329
		public const uint kNumPosStatesMax = 16u;

		// Token: 0x04006AC2 RID: 27330
		public const int kNumPosStatesBitsEncodingMax = 4;

		// Token: 0x04006AC3 RID: 27331
		public const uint kNumPosStatesEncodingMax = 16u;

		// Token: 0x04006AC4 RID: 27332
		public const int kNumLowLenBits = 3;

		// Token: 0x04006AC5 RID: 27333
		public const int kNumMidLenBits = 3;

		// Token: 0x04006AC6 RID: 27334
		public const int kNumHighLenBits = 8;

		// Token: 0x04006AC7 RID: 27335
		public const uint kNumLowLenSymbols = 8u;

		// Token: 0x04006AC8 RID: 27336
		public const uint kNumMidLenSymbols = 8u;

		// Token: 0x04006AC9 RID: 27337
		public const uint kNumLenSymbols = 272u;

		// Token: 0x04006ACA RID: 27338
		public const uint kMatchMaxLen = 273u;

		// Token: 0x020006F3 RID: 1779
		public struct State
		{
			// Token: 0x060021F8 RID: 8696 RVA: 0x0040446C File Offset: 0x0040266C
			public void Init()
			{
				this.Index = 0u;
			}

			// Token: 0x060021F9 RID: 8697 RVA: 0x00404478 File Offset: 0x00402678
			public void UpdateChar()
			{
				if (this.Index < 4u)
				{
					this.Index = 0u;
				}
				else if (this.Index < 10u)
				{
					this.Index -= 3u;
				}
				else
				{
					this.Index -= 6u;
				}
			}

			// Token: 0x060021FA RID: 8698 RVA: 0x004044CC File Offset: 0x004026CC
			public void UpdateMatch()
			{
				this.Index = ((this.Index >= 7u) ? 10u : 7u);
			}

			// Token: 0x060021FB RID: 8699 RVA: 0x004044E8 File Offset: 0x004026E8
			public void UpdateRep()
			{
				this.Index = ((this.Index >= 7u) ? 11u : 8u);
			}

			// Token: 0x060021FC RID: 8700 RVA: 0x00404504 File Offset: 0x00402704
			public void UpdateShortRep()
			{
				this.Index = ((this.Index >= 7u) ? 11u : 9u);
			}

			// Token: 0x060021FD RID: 8701 RVA: 0x00404524 File Offset: 0x00402724
			public bool IsCharState()
			{
				return this.Index < 7u;
			}

			// Token: 0x04006ACB RID: 27339
			public uint Index;
		}
	}
}
