using System;
using System.Collections;
using System.IO;
using SevenZip.Compression.LZ;
using SevenZip.Compression.RangeCoder;

namespace SevenZip.Compression.LZMA
{
	// Token: 0x020006F4 RID: 1780
	public class Decoder : ICoder, ISetDecoderProperties
	{
		// Token: 0x060021FE RID: 8702 RVA: 0x00404530 File Offset: 0x00402730
		public Decoder()
		{
			this.m_DictionarySize = uint.MaxValue;
			int num = 0;
			while ((long)num < 4L)
			{
				this.m_PosSlotDecoder[num] = new BitTreeDecoder(6);
				num++;
			}
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x00404630 File Offset: 0x00402830
		private void SetDictionarySize(uint dictionarySize)
		{
			if (this.m_DictionarySize != dictionarySize)
			{
				this.m_DictionarySize = dictionarySize;
				this.m_DictionarySizeCheck = Math.Max(this.m_DictionarySize, 1u);
				uint windowSize = Math.Max(this.m_DictionarySizeCheck, 4096u);
				this.m_OutWindow.Create(windowSize);
			}
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x00404680 File Offset: 0x00402880
		private void SetLiteralProperties(int lp, int lc)
		{
			if (lp > 8)
			{
				throw new InvalidParamException();
			}
			if (lc > 8)
			{
				throw new InvalidParamException();
			}
			this.m_LiteralDecoder.Create(lp, lc);
		}

		// Token: 0x06002201 RID: 8705 RVA: 0x004046AC File Offset: 0x004028AC
		private void SetPosBitsProperties(int pb)
		{
			if (pb > 4)
			{
				throw new InvalidParamException();
			}
			uint num = 1u << pb;
			this.m_LenDecoder.Create(num);
			this.m_RepLenDecoder.Create(num);
			this.m_PosStateMask = num - 1u;
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x004046F0 File Offset: 0x004028F0
		private void Init(Stream inStream, Stream outStream)
		{
			this.m_RangeDecoder.Init(inStream);
			this.m_OutWindow.Init(outStream, this._solid);
			for (uint num = 0u; num < 12u; num += 1u)
			{
				for (uint num2 = 0u; num2 <= this.m_PosStateMask; num2 += 1u)
				{
					uint num3 = (num << 4) + num2;
					this.m_IsMatchDecoders[(int)((UIntPtr)num3)].Init();
					this.m_IsRep0LongDecoders[(int)((UIntPtr)num3)].Init();
				}
				this.m_IsRepDecoders[(int)((UIntPtr)num)].Init();
				this.m_IsRepG0Decoders[(int)((UIntPtr)num)].Init();
				this.m_IsRepG1Decoders[(int)((UIntPtr)num)].Init();
				this.m_IsRepG2Decoders[(int)((UIntPtr)num)].Init();
			}
			this.m_LiteralDecoder.Init();
			for (uint num = 0u; num < 4u; num += 1u)
			{
				this.m_PosSlotDecoder[(int)((UIntPtr)num)].Init();
			}
			for (uint num = 0u; num < 114u; num += 1u)
			{
				this.m_PosDecoders[(int)((UIntPtr)num)].Init();
			}
			this.m_LenDecoder.Init();
			this.m_RepLenDecoder.Init();
			this.m_PosAlignDecoder.Init();
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x0040482C File Offset: 0x00402A2C
		public void Code(Stream inStream, Stream outStream, long inSize, long outSize, ICodeProgress progress)
		{
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x00404830 File Offset: 0x00402A30
		public IEnumerator Decode(Stream inStream, Stream outStream, long inSize, long outSize, uint roundSize, ICodeProgress progress)
		{
			this.Init(inStream, outStream);
			Base.State state = default(Base.State);
			state.Init();
			uint rep0 = 0u;
			uint rep = 0u;
			uint rep2 = 0u;
			uint rep3 = 0u;
			uint runs = 0u;
			ulong nowPos64 = 0UL;
			if (nowPos64 < (ulong)outSize)
			{
				if (this.m_IsMatchDecoders[(int)((UIntPtr)(state.Index << 4))].Decode(this.m_RangeDecoder) != 0u)
				{
					throw new DataErrorException();
				}
				state.UpdateChar();
				byte b = this.m_LiteralDecoder.DecodeNormal(this.m_RangeDecoder, 0u, 0);
				this.m_OutWindow.PutByte(b);
				nowPos64 += 1UL;
			}
			while (nowPos64 < (ulong)outSize)
			{
				runs += 1u;
				uint posState = (uint)nowPos64 & this.m_PosStateMask;
				if (this.m_IsMatchDecoders[(int)((UIntPtr)((state.Index << 4) + posState))].Decode(this.m_RangeDecoder) == 0u)
				{
					byte prevByte = this.m_OutWindow.GetByte(0u);
					byte b2;
					if (!state.IsCharState())
					{
						b2 = this.m_LiteralDecoder.DecodeWithMatchByte(this.m_RangeDecoder, (uint)nowPos64, prevByte, this.m_OutWindow.GetByte(rep0));
					}
					else
					{
						b2 = this.m_LiteralDecoder.DecodeNormal(this.m_RangeDecoder, (uint)nowPos64, prevByte);
					}
					this.m_OutWindow.PutByte(b2);
					state.UpdateChar();
					nowPos64 += 1UL;
				}
				else
				{
					uint len;
					if (this.m_IsRepDecoders[(int)((UIntPtr)state.Index)].Decode(this.m_RangeDecoder) == 1u)
					{
						if (this.m_IsRepG0Decoders[(int)((UIntPtr)state.Index)].Decode(this.m_RangeDecoder) == 0u)
						{
							if (this.m_IsRep0LongDecoders[(int)((UIntPtr)((state.Index << 4) + posState))].Decode(this.m_RangeDecoder) == 0u)
							{
								state.UpdateShortRep();
								this.m_OutWindow.PutByte(this.m_OutWindow.GetByte(rep0));
								nowPos64 += 1UL;
								continue;
							}
						}
						else
						{
							uint distance;
							if (this.m_IsRepG1Decoders[(int)((UIntPtr)state.Index)].Decode(this.m_RangeDecoder) == 0u)
							{
								distance = rep;
							}
							else
							{
								if (this.m_IsRepG2Decoders[(int)((UIntPtr)state.Index)].Decode(this.m_RangeDecoder) == 0u)
								{
									distance = rep2;
								}
								else
								{
									distance = rep3;
									rep3 = rep2;
								}
								rep2 = rep;
							}
							rep = rep0;
							rep0 = distance;
						}
						len = this.m_RepLenDecoder.Decode(this.m_RangeDecoder, posState) + 2u;
						state.UpdateRep();
					}
					else
					{
						rep3 = rep2;
						rep2 = rep;
						rep = rep0;
						len = 2u + this.m_LenDecoder.Decode(this.m_RangeDecoder, posState);
						state.UpdateMatch();
						uint posSlot = this.m_PosSlotDecoder[(int)((UIntPtr)Base.GetLenToPosState(len))].Decode(this.m_RangeDecoder);
						if (posSlot >= 4u)
						{
							int numDirectBits = (int)((posSlot >> 1) - 1u);
							rep0 = (2u | (posSlot & 1u)) << numDirectBits;
							if (posSlot < 14u)
							{
								rep0 += BitTreeDecoder.ReverseDecode(this.m_PosDecoders, rep0 - posSlot - 1u, this.m_RangeDecoder, numDirectBits);
							}
							else
							{
								rep0 += this.m_RangeDecoder.DecodeDirectBits(numDirectBits - 4) << 4;
								rep0 += this.m_PosAlignDecoder.ReverseDecode(this.m_RangeDecoder);
							}
						}
						else
						{
							rep0 = posSlot;
						}
					}
					if ((ulong)rep0 >= (ulong)this.m_OutWindow.TrainSize + nowPos64 || rep0 >= this.m_DictionarySizeCheck)
					{
						if (rep0 == 4294967295u)
						{
							break;
						}
						throw new DataErrorException();
					}
					else
					{
						this.m_OutWindow.CopyBlock(rep0, len);
						nowPos64 += (ulong)len;
					}
				}
				if (runs > roundSize)
				{
					if (progress != null)
					{
						progress.SetProgress((long)nowPos64, outSize);
					}
					runs = 0u;
					yield return null;
				}
			}
			this.m_OutWindow.Flush();
			this.m_OutWindow.ReleaseStream();
			this.m_RangeDecoder.ReleaseStream();
			yield break;
		}

		// Token: 0x06002205 RID: 8709 RVA: 0x00404898 File Offset: 0x00402A98
		public void SetDecoderProperties(byte[] properties)
		{
			if (properties.Length < 5)
			{
				throw new InvalidParamException();
			}
			int lc = (int)(properties[0] % 9);
			int num = (int)(properties[0] / 9);
			int lp = num % 5;
			int num2 = num / 5;
			if (num2 > 4)
			{
				throw new InvalidParamException();
			}
			uint num3 = 0u;
			for (int i = 0; i < 4; i++)
			{
				num3 += (uint)((uint)properties[1 + i] << i * 8);
			}
			this.SetDictionarySize(num3);
			this.SetLiteralProperties(lp, lc);
			this.SetPosBitsProperties(num2);
		}

		// Token: 0x06002206 RID: 8710 RVA: 0x00404920 File Offset: 0x00402B20
		public bool Train(Stream stream)
		{
			this._solid = true;
			return this.m_OutWindow.Train(stream);
		}

		// Token: 0x04006ACC RID: 27340
		private OutWindow m_OutWindow = new OutWindow();

		// Token: 0x04006ACD RID: 27341
		private Decoder m_RangeDecoder = new Decoder();

		// Token: 0x04006ACE RID: 27342
		private BitDecoder[] m_IsMatchDecoders = new BitDecoder[192];

		// Token: 0x04006ACF RID: 27343
		private BitDecoder[] m_IsRepDecoders = new BitDecoder[12];

		// Token: 0x04006AD0 RID: 27344
		private BitDecoder[] m_IsRepG0Decoders = new BitDecoder[12];

		// Token: 0x04006AD1 RID: 27345
		private BitDecoder[] m_IsRepG1Decoders = new BitDecoder[12];

		// Token: 0x04006AD2 RID: 27346
		private BitDecoder[] m_IsRepG2Decoders = new BitDecoder[12];

		// Token: 0x04006AD3 RID: 27347
		private BitDecoder[] m_IsRep0LongDecoders = new BitDecoder[192];

		// Token: 0x04006AD4 RID: 27348
		private BitTreeDecoder[] m_PosSlotDecoder = new BitTreeDecoder[4];

		// Token: 0x04006AD5 RID: 27349
		private BitDecoder[] m_PosDecoders = new BitDecoder[114];

		// Token: 0x04006AD6 RID: 27350
		private BitTreeDecoder m_PosAlignDecoder = new BitTreeDecoder(4);

		// Token: 0x04006AD7 RID: 27351
		private Decoder.LenDecoder m_LenDecoder = new Decoder.LenDecoder();

		// Token: 0x04006AD8 RID: 27352
		private Decoder.LenDecoder m_RepLenDecoder = new Decoder.LenDecoder();

		// Token: 0x04006AD9 RID: 27353
		private Decoder.LiteralDecoder m_LiteralDecoder = new Decoder.LiteralDecoder();

		// Token: 0x04006ADA RID: 27354
		private uint m_DictionarySize;

		// Token: 0x04006ADB RID: 27355
		private uint m_DictionarySizeCheck;

		// Token: 0x04006ADC RID: 27356
		private uint m_PosStateMask;

		// Token: 0x04006ADD RID: 27357
		private bool _solid;

		// Token: 0x020006F5 RID: 1781
		private class LenDecoder
		{
			// Token: 0x06002208 RID: 8712 RVA: 0x00404994 File Offset: 0x00402B94
			public void Create(uint numPosStates)
			{
				for (uint num = this.m_NumPosStates; num < numPosStates; num += 1u)
				{
					this.m_LowCoder[(int)((UIntPtr)num)] = new BitTreeDecoder(3);
					this.m_MidCoder[(int)((UIntPtr)num)] = new BitTreeDecoder(3);
				}
				this.m_NumPosStates = numPosStates;
			}

			// Token: 0x06002209 RID: 8713 RVA: 0x004049F0 File Offset: 0x00402BF0
			public void Init()
			{
				this.m_Choice.Init();
				for (uint num = 0u; num < this.m_NumPosStates; num += 1u)
				{
					this.m_LowCoder[(int)((UIntPtr)num)].Init();
					this.m_MidCoder[(int)((UIntPtr)num)].Init();
				}
				this.m_Choice2.Init();
				this.m_HighCoder.Init();
			}

			// Token: 0x0600220A RID: 8714 RVA: 0x00404A5C File Offset: 0x00402C5C
			public uint Decode(Decoder rangeDecoder, uint posState)
			{
				if (this.m_Choice.Decode(rangeDecoder) == 0u)
				{
					return this.m_LowCoder[(int)((UIntPtr)posState)].Decode(rangeDecoder);
				}
				uint num = 8u;
				if (this.m_Choice2.Decode(rangeDecoder) == 0u)
				{
					num += this.m_MidCoder[(int)((UIntPtr)posState)].Decode(rangeDecoder);
				}
				else
				{
					num += 8u;
					num += this.m_HighCoder.Decode(rangeDecoder);
				}
				return num;
			}

			// Token: 0x04006ADE RID: 27358
			private BitDecoder m_Choice = default(BitDecoder);

			// Token: 0x04006ADF RID: 27359
			private BitDecoder m_Choice2 = default(BitDecoder);

			// Token: 0x04006AE0 RID: 27360
			private BitTreeDecoder[] m_LowCoder = new BitTreeDecoder[16];

			// Token: 0x04006AE1 RID: 27361
			private BitTreeDecoder[] m_MidCoder = new BitTreeDecoder[16];

			// Token: 0x04006AE2 RID: 27362
			private BitTreeDecoder m_HighCoder = new BitTreeDecoder(8);

			// Token: 0x04006AE3 RID: 27363
			private uint m_NumPosStates;
		}

		// Token: 0x020006F6 RID: 1782
		private class LiteralDecoder
		{
			// Token: 0x0600220C RID: 8716 RVA: 0x00404AD8 File Offset: 0x00402CD8
			public void Create(int numPosBits, int numPrevBits)
			{
				if (this.m_Coders != null && this.m_NumPrevBits == numPrevBits && this.m_NumPosBits == numPosBits)
				{
					return;
				}
				this.m_NumPosBits = numPosBits;
				this.m_PosMask = (1u << numPosBits) - 1u;
				this.m_NumPrevBits = numPrevBits;
				uint num = 1u << this.m_NumPrevBits + this.m_NumPosBits;
				this.m_Coders = new Decoder.LiteralDecoder.Decoder2[num];
				for (uint num2 = 0u; num2 < num; num2 += 1u)
				{
					this.m_Coders[(int)((UIntPtr)num2)].Create();
				}
			}

			// Token: 0x0600220D RID: 8717 RVA: 0x00404B6C File Offset: 0x00402D6C
			public void Init()
			{
				uint num = 1u << this.m_NumPrevBits + this.m_NumPosBits;
				for (uint num2 = 0u; num2 < num; num2 += 1u)
				{
					this.m_Coders[(int)((UIntPtr)num2)].Init();
				}
			}

			// Token: 0x0600220E RID: 8718 RVA: 0x00404BB0 File Offset: 0x00402DB0
			private uint GetState(uint pos, byte prevByte)
			{
				return ((pos & this.m_PosMask) << this.m_NumPrevBits) + (uint)(prevByte >> 8 - this.m_NumPrevBits);
			}

			// Token: 0x0600220F RID: 8719 RVA: 0x00404BE0 File Offset: 0x00402DE0
			public byte DecodeNormal(Decoder rangeDecoder, uint pos, byte prevByte)
			{
				return this.m_Coders[(int)((UIntPtr)this.GetState(pos, prevByte))].DecodeNormal(rangeDecoder);
			}

			// Token: 0x06002210 RID: 8720 RVA: 0x00404BFC File Offset: 0x00402DFC
			public byte DecodeWithMatchByte(Decoder rangeDecoder, uint pos, byte prevByte, byte matchByte)
			{
				return this.m_Coders[(int)((UIntPtr)this.GetState(pos, prevByte))].DecodeWithMatchByte(rangeDecoder, matchByte);
			}

			// Token: 0x04006AE4 RID: 27364
			private Decoder.LiteralDecoder.Decoder2[] m_Coders;

			// Token: 0x04006AE5 RID: 27365
			private int m_NumPrevBits;

			// Token: 0x04006AE6 RID: 27366
			private int m_NumPosBits;

			// Token: 0x04006AE7 RID: 27367
			private uint m_PosMask;

			// Token: 0x020006F7 RID: 1783
			private struct Decoder2
			{
				// Token: 0x06002211 RID: 8721 RVA: 0x00404C1C File Offset: 0x00402E1C
				public void Create()
				{
					this.m_Decoders = new BitDecoder[768];
				}

				// Token: 0x06002212 RID: 8722 RVA: 0x00404C30 File Offset: 0x00402E30
				public void Init()
				{
					for (int i = 0; i < 768; i++)
					{
						this.m_Decoders[i].Init();
					}
				}

				// Token: 0x06002213 RID: 8723 RVA: 0x00404C64 File Offset: 0x00402E64
				public byte DecodeNormal(Decoder rangeDecoder)
				{
					uint num = 1u;
					do
					{
						num = (num << 1 | this.m_Decoders[(int)((UIntPtr)num)].Decode(rangeDecoder));
					}
					while (num < 256u);
					return (byte)num;
				}

				// Token: 0x06002214 RID: 8724 RVA: 0x00404C98 File Offset: 0x00402E98
				public byte DecodeWithMatchByte(Decoder rangeDecoder, byte matchByte)
				{
					uint num = 1u;
					for (;;)
					{
						uint num2 = (uint)(matchByte >> 7 & 1);
						matchByte = (byte)(matchByte << 1);
						uint num3 = this.m_Decoders[(int)((UIntPtr)((1u + num2 << 8) + num))].Decode(rangeDecoder);
						num = (num << 1 | num3);
						if (num2 != num3)
						{
							break;
						}
						if (num >= 256u)
						{
							goto IL_6D;
						}
					}
					while (num < 256u)
					{
						num = (num << 1 | this.m_Decoders[(int)((UIntPtr)num)].Decode(rangeDecoder));
					}
					IL_6D:
					return (byte)num;
				}

				// Token: 0x04006AE8 RID: 27368
				private BitDecoder[] m_Decoders;
			}
		}
	}
}
