using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

// Token: 0x020000CB RID: 203
public class StringTable
{
	// Token: 0x060002C6 RID: 710 RVA: 0x00027110 File Offset: 0x00025310
	public StringTable()
	{
		this.BytesIntPtr_Key = IntPtr.Zero;
		this.BytesIntPtr = IntPtr.Zero;
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x00027130 File Offset: 0x00025330
	~StringTable()
	{
			this.ClearStringTable();
			if (this.BytesIntPtr_Key != IntPtr.Zero)
			{
				GCHandle gchandle = GCHandle.FromIntPtr(this.BytesIntPtr_Key);
				if (gchandle.IsAllocated)
				{
					gchandle.Free();
				}
			}
			if (this.BytesIntPtr != IntPtr.Zero)
			{
				GCHandle gchandle2 = GCHandle.FromIntPtr(this.BytesIntPtr);
				if (gchandle2.IsAllocated)
				{
					gchandle2.Free();
				}
			}
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x000271D4 File Offset: 0x000253D4
	public unsafe bool LoadStringTable(string Table = "Loading/String", bool Seek = false)
	{
		bool result = false;
		int key = 0;
		AssetBundle assetBundle = AssetManager.GetAssetBundle(Table, out key, Seek);
		if (assetBundle == null)
		{
			return result;
		}
		TextAsset textAsset = assetBundle.Load("StringTable") as TextAsset;
		TextAsset textAsset2 = assetBundle.Load("StringTable2") as TextAsset;
		if (textAsset == null || textAsset2 == null)
		{
			return result;
		}
		this.RecordAmount = 0;
		Stream input = new MemoryStream(textAsset2.bytes);
		using (BinaryReader binaryReader = new BinaryReader(input))
		{
			this.RecordAmount = binaryReader.ReadInt32();
			this.BytesIntPtr_Key = GCHandle.Alloc(textAsset2.bytes, GCHandleType.Pinned).AddrOfPinnedObject();
		}
		Stream stream = new MemoryStream(textAsset.bytes);
		GCHandle gchandle;
		using (BinaryReader binaryReader2 = new BinaryReader(stream))
		{
			this.MaxKey = binaryReader2.ReadInt32();
			gchandle = GCHandle.Alloc(textAsset.bytes, GCHandleType.Pinned);
			this.BytesIntPtr = gchandle.AddrOfPinnedObject();
			int num = this.MaxKey / 8 + 1;
			this.StringTableData = new string[num];
			int num2 = this.RecordAmount / 2;
			for (int i = 1; i < num2; i++)
			{
				int num3 = 4 + i * 2;
				byte* ptr = (byte*)this.BytesIntPtr_Key.ToPointer();
				ptr += num3;
				IntPtr intPtr = new IntPtr((void*)ptr);
				ushort num4 = (ushort)Marshal.PtrToStructure(intPtr, typeof(ushort));
				if (num4 > 0 && (int)num4 < num && this.StringTableData[(int)num4] == null)
				{
					ptr = (byte*)this.BytesIntPtr.ToPointer();
					num3 = (int)(4 + (num4 - 1) * 8);
					ptr += num3;
					intPtr = new IntPtr((void*)ptr);
					int num5 = (int)Marshal.PtrToStructure(intPtr, typeof(int));
					ptr += 4;
					intPtr = new IntPtr((void*)ptr);
					ushort length = (ushort)Marshal.PtrToStructure(intPtr, typeof(ushort));
					num3 = 4 + this.MaxKey + num5;
					ptr = (byte*)this.BytesIntPtr.ToPointer();
					ptr += num3;
					intPtr = new IntPtr((void*)ptr);
					this.StringTableData[(int)num4] = new string((sbyte*)((void*)intPtr), 0, (int)length, Encoding.UTF8);
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
		return true;
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x00027490 File Offset: 0x00025690
	public unsafe string GetStringByID(uint ID)
	{
		int num = 4;
		if (ID <= 0u || (ulong)ID >= (ulong)((long)(this.RecordAmount / 2)))
		{
			return string.Empty;
		}
		num += (int)(ID * 2u);
		byte* ptr = (byte*)this.BytesIntPtr_Key.ToPointer();
		ptr += num;
		IntPtr ptr2 = new IntPtr((void*)ptr);
		ushort num2 = (ushort)Marshal.PtrToStructure(ptr2, typeof(ushort));
		if ((int)num2 > this.StringTableData.Length)
		{
			return this.StringTableData[0];
		}
		return this.StringTableData[(int)num2];
	}

	// Token: 0x060002CA RID: 714 RVA: 0x00027518 File Offset: 0x00025718
	public void ClearStringTable()
	{
		if (this.StringTableData != null)
		{
			Array.Clear(this.StringTableData, 0, this.StringTableData.Length);
		}
		this.StringTableData = null;
	}

	// Token: 0x04000931 RID: 2353
	public string[] StringTableData;

	// Token: 0x04000932 RID: 2354
	public int RecordAmount;

	// Token: 0x04000933 RID: 2355
	public int MaxKey;

	// Token: 0x04000934 RID: 2356
	protected IntPtr BytesIntPtr_Key;

	// Token: 0x04000935 RID: 2357
	protected IntPtr BytesIntPtr;
}
