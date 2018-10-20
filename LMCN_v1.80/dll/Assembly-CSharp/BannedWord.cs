using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

// Token: 0x020007B9 RID: 1977
public class BannedWord
{
	// Token: 0x060028C0 RID: 10432 RVA: 0x00448FF0 File Offset: 0x004471F0
	public BannedWord()
	{
		this.LoadBannedWordTable();
		this.LoadBannedWordTable2();
	}

	// Token: 0x060028C1 RID: 10433 RVA: 0x00449004 File Offset: 0x00447204
	public unsafe void LoadBannedWordTable()
	{
		int num = 0;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		int key = 0;
		AssetBundle assetBundle = AssetManager.GetAssetBundle("Loading/Table", out key, false);
		if (assetBundle == null)
		{
			return;
		}
		TextAsset textAsset = assetBundle.Load("BannedWord_CN") as TextAsset;
		TextAsset textAsset2 = assetBundle.Load("BannedWord2_CN") as TextAsset;
		if (textAsset == null || textAsset2 == null)
		{
			return;
		}
		Stream input = new MemoryStream(textAsset2.bytes);
		using (BinaryReader binaryReader = new BinaryReader(input))
		{
			num = binaryReader.ReadInt32();
			intPtr = GCHandle.Alloc(textAsset2.bytes, GCHandleType.Pinned).AddrOfPinnedObject();
		}
		Stream stream = new MemoryStream(textAsset.bytes);
		GCHandle gchandle;
		using (BinaryReader binaryReader2 = new BinaryReader(stream))
		{
			int num2 = binaryReader2.ReadInt32();
			gchandle = GCHandle.Alloc(textAsset.bytes, GCHandleType.Pinned);
			intPtr2 = gchandle.AddrOfPinnedObject();
			int num3 = num2 / 8 + 1;
			this.BMStringArray = new BoyerMooreStringMatcher[num3];
			int num4 = num / 2 + 1;
			for (int i = 1; i < num4; i++)
			{
				int num5 = 4 + i * 2;
				byte* ptr = (byte*)intPtr.ToPointer();
				ptr += num5;
				IntPtr intPtr3 = new IntPtr((void*)ptr);
				ushort num6 = (ushort)Marshal.PtrToStructure(intPtr3, typeof(ushort));
				if (num6 > 0 && (int)num6 < num3 && this.BMStringArray[(int)num6] == null)
				{
					ptr = (byte*)intPtr2.ToPointer();
					num5 = (int)(4 + (num6 - 1) * 8);
					ptr += num5;
					intPtr3 = new IntPtr((void*)ptr);
					int num7 = (int)Marshal.PtrToStructure(intPtr3, typeof(int));
					ptr += 4;
					intPtr3 = new IntPtr((void*)ptr);
					ushort length = (ushort)Marshal.PtrToStructure(intPtr3, typeof(ushort));
					num5 = 4 + num2 + num7;
					ptr = (byte*)intPtr2.ToPointer();
					ptr += num5;
					intPtr3 = new IntPtr((void*)ptr);
					this.BMStringArray[(int)num6] = new BoyerMooreStringMatcher(new string((sbyte*)((void*)intPtr3), 0, (int)length, Encoding.UTF8));
				}
			}
			binaryReader2.Close();
		}
		stream.Close();
		if (gchandle.IsAllocated)
		{
			gchandle.Free();
		}
		AssetManager.UnloadAssetBundle(key, true);
	}

	// Token: 0x060028C2 RID: 10434 RVA: 0x004492A8 File Offset: 0x004474A8
	public void UnLoadBannedWordTable()
	{
		if (this.BMStringArray == null)
		{
			return;
		}
		for (int i = 1; i < this.BMStringArray.Length; i++)
		{
			this.BMStringArray[i].UnLoad();
		}
		this.BMStringArray = null;
	}

	// Token: 0x060028C3 RID: 10435 RVA: 0x004492F0 File Offset: 0x004474F0
	public unsafe void LoadBannedWordTable2()
	{
		int num = 0;
		IntPtr intPtr = IntPtr.Zero;
		IntPtr intPtr2 = IntPtr.Zero;
		int key = 0;
		AssetBundle assetBundle = AssetManager.GetAssetBundle("Loading/Table", out key, false);
		if (assetBundle == null)
		{
			return;
		}
		TextAsset textAsset = assetBundle.Load("AccurateBannedWord") as TextAsset;
		TextAsset textAsset2 = assetBundle.Load("AccurateBannedWord2") as TextAsset;
		if (textAsset == null || textAsset2 == null)
		{
			return;
		}
		Stream input = new MemoryStream(textAsset2.bytes);
		using (BinaryReader binaryReader = new BinaryReader(input))
		{
			num = binaryReader.ReadInt32();
			intPtr = GCHandle.Alloc(textAsset2.bytes, GCHandleType.Pinned).AddrOfPinnedObject();
		}
		Stream stream = new MemoryStream(textAsset.bytes);
		GCHandle gchandle;
		using (BinaryReader binaryReader2 = new BinaryReader(stream))
		{
			int num2 = binaryReader2.ReadInt32();
			gchandle = GCHandle.Alloc(textAsset.bytes, GCHandleType.Pinned);
			intPtr2 = gchandle.AddrOfPinnedObject();
			int num3 = num2 / 8 + 1;
			this.BMStringArray_Accurate = new BoyerMooreStringMatcher[num3];
			int num4 = num / 2 + 1;
			for (int i = 1; i < num4; i++)
			{
				int num5 = 4 + i * 2;
				byte* ptr = (byte*)intPtr.ToPointer();
				ptr += num5;
				IntPtr intPtr3 = new IntPtr((void*)ptr);
				ushort num6 = (ushort)Marshal.PtrToStructure(intPtr3, typeof(ushort));
				if (num6 > 0 && (int)num6 < num3 && this.BMStringArray_Accurate[(int)num6] == null)
				{
					ptr = (byte*)intPtr2.ToPointer();
					num5 = (int)(4 + (num6 - 1) * 8);
					ptr += num5;
					intPtr3 = new IntPtr((void*)ptr);
					int num7 = (int)Marshal.PtrToStructure(intPtr3, typeof(int));
					ptr += 4;
					intPtr3 = new IntPtr((void*)ptr);
					ushort length = (ushort)Marshal.PtrToStructure(intPtr3, typeof(ushort));
					num5 = 4 + num2 + num7;
					ptr = (byte*)intPtr2.ToPointer();
					ptr += num5;
					intPtr3 = new IntPtr((void*)ptr);
					this.BMStringArray_Accurate[(int)num6] = new BoyerMooreStringMatcher(new string((sbyte*)((void*)intPtr3), 0, (int)length, Encoding.UTF8));
				}
			}
			binaryReader2.Close();
		}
		stream.Close();
		if (gchandle.IsAllocated)
		{
			gchandle.Free();
		}
		AssetManager.UnloadAssetBundle(key, true);
	}

	// Token: 0x060028C4 RID: 10436 RVA: 0x00449594 File Offset: 0x00447794
	public void UnLoadBannedWordTable2()
	{
		if (this.BMStringArray_Accurate == null)
		{
			return;
		}
		for (int i = 1; i < this.BMStringArray_Accurate.Length; i++)
		{
			this.BMStringArray_Accurate[i].UnLoad();
		}
		this.BMStringArray_Accurate = null;
	}

	// Token: 0x060028C5 RID: 10437 RVA: 0x004495DC File Offset: 0x004477DC
	public void CheckBannedWord(char[] text)
	{
		if (this.BMStringArray != null)
		{
			for (int i = 1; i < this.BMStringArray.Length; i++)
			{
				this.BMStringArray[i].CheckAndRePlace(text, false);
			}
		}
		if (this.BMStringArray_Accurate != null)
		{
			for (int j = 1; j < this.BMStringArray_Accurate.Length; j++)
			{
				this.BMStringArray_Accurate[j].CheckAndRePlace(text, true);
			}
		}
	}

	// Token: 0x060028C6 RID: 10438 RVA: 0x00449650 File Offset: 0x00447850
	public void CheckBannedWord(string text)
	{
		if (this.BMStringArray != null)
		{
			for (int i = 1; i < this.BMStringArray.Length; i++)
			{
				this.BMStringArray[i].CheckAndRePlace(text, false);
			}
		}
		if (this.BMStringArray_Accurate != null)
		{
			for (int j = 1; j < this.BMStringArray_Accurate.Length; j++)
			{
				this.BMStringArray_Accurate[j].CheckAndRePlace(text, true);
			}
		}
	}

	// Token: 0x060028C7 RID: 10439 RVA: 0x004496C4 File Offset: 0x004478C4
	public bool ChackHasBannedWord(string text)
	{
		if (this.BMStringArray != null)
		{
			for (int i = 1; i < this.BMStringArray.Length; i++)
			{
				if (this.BMStringArray[i].TryMatch(text, false))
				{
					return true;
				}
			}
		}
		if (this.BMStringArray_Accurate != null)
		{
			for (int j = 1; j < this.BMStringArray_Accurate.Length; j++)
			{
				if (this.BMStringArray_Accurate[j].TryMatch(text, true))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x040072FB RID: 29435
	public BoyerMooreStringMatcher[] BMStringArray;

	// Token: 0x040072FC RID: 29436
	public BoyerMooreStringMatcher[] BMStringArray_Accurate;
}
