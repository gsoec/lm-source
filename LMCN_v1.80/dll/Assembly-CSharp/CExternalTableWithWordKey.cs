using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x020000C9 RID: 201
public class CExternalTableWithWordKey<R> where R : struct
{
	// Token: 0x060002BC RID: 700 RVA: 0x00026CDC File Offset: 0x00024EDC
	public CExternalTableWithWordKey()
	{
		this.MaxKey = 0;
		this.KeyMapIndex = IntPtr.Zero;
		this.BytesIntPtr = IntPtr.Zero;
	}


    // Token: 0x060002BD RID: 701 RVA: 0x00026D04 File Offset: 0x00024F04
    ~CExternalTableWithWordKey()
    {
			if (this.KeyMapIndex != IntPtr.Zero)
			{
				GCHandle gchandle = GCHandle.FromIntPtr(this.KeyMapIndex);
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

	// Token: 0x060002BE RID: 702 RVA: 0x00026DA4 File Offset: 0x00024FA4
	public bool LoadTable(string in_DataName)
	{
		if (!DataManager.Instance.bLoadingTableSuccess)
		{
			return false;
		}
		bool result = false;
		if (in_DataName.Length == 0)
		{
			DataManager.Instance.bLoadingTableSuccess = false;
			return result;
		}
		AssetBundle tableAB = DataManager.Instance.GetTableAB();
		if (tableAB == null)
		{
			DataManager.Instance.bLoadingTableSuccess = false;
			return result;
		}
		TextAsset textAsset = tableAB.Load(in_DataName) as TextAsset;
		if (textAsset == null)
		{
			DataManager.Instance.bLoadingTableSuccess = false;
			return result;
		}
		Stream stream = new MemoryStream(textAsset.bytes);
		if (stream.Length <= 4L)
		{
			DataManager.Instance.bLoadingTableSuccess = false;
			return result;
		}
		GCHandle gchandle = GCHandle.Alloc(textAsset.bytes, GCHandleType.Pinned);
		this.BytesIntPtr = gchandle.AddrOfPinnedObject();
		int num = (int)stream.Length - 4;
		int num2 = Marshal.SizeOf(typeof(R));
		if (num < num2 || num % num2 != 0)
		{
			if (gchandle.IsAllocated)
			{
				gchandle.Free();
				this.BytesIntPtr = IntPtr.Zero;
			}
			stream.Close();
			Resources.UnloadUnusedAssets();
			DataManager.Instance.bLoadingTableSuccess = false;
			return result;
		}
		this.RecordAmount = num / num2;
		using (BinaryReader binaryReader = new BinaryReader(stream))
		{
			binaryReader.ReadUInt16();
			ushort num3 = binaryReader.ReadUInt16();
			if (this.RecordAmount > (int)num3)
			{
				this.RecordAmount = (int)num3;
			}
			int startIdx = 4 + (this.RecordAmount - 1) * num2;
			this.MaxKey = GameConstants.ConvertBytesToUShort(textAsset.bytes, startIdx);
			this.MaxKey += 1;
			ushort[] array = new ushort[(int)this.MaxKey];
			Array.Clear(array, 0, (int)this.MaxKey);
			int num4 = 4;
			ushort num5 = 0;
			while ((int)num5 < this.RecordAmount)
			{
				array[(int)GameConstants.ConvertBytesToUShort(textAsset.bytes, num4)] = num5;
				num4 += num2;
				num5 += 1;
			}
			this.KeyMapIndex = GCHandle.Alloc(array, GCHandleType.Pinned).AddrOfPinnedObject();
			binaryReader.Close();
		}
		stream.Close();
		return true;
	}

	// Token: 0x060002BF RID: 703 RVA: 0x00026FE8 File Offset: 0x000251E8
	public unsafe R GetRecordByKey(ushort InKey)
	{
		int index = 0;
		if (InKey < this.MaxKey)
		{
			ushort* ptr = (ushort*)this.KeyMapIndex.ToPointer();
			ptr += InKey;
			index = (int)(*ptr);
		}
		return this.GetRecordByIndex(index);
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x00027020 File Offset: 0x00025220
	public unsafe ushort GetIndexByKey(ushort InKey)
	{
		int num = 0;
		if (InKey < this.MaxKey)
		{
			ushort* ptr = (ushort*)this.KeyMapIndex.ToPointer();
			ptr += InKey;
			num = (int)(*ptr);
		}
		return (ushort)num;
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x00027054 File Offset: 0x00025254
	public unsafe R GetRecordByIndex(int Index)
	{
		if (this.RecordAmount == 0)
		{
			return default(R);
		}
		int num = 4;
		if (Index >= 0 && Index < this.RecordAmount)
		{
			num += Index * Marshal.SizeOf(typeof(R));
		}
		byte* ptr = (byte*)this.BytesIntPtr.ToPointer();
		ptr += num;
		IntPtr ptr2 = new IntPtr((void*)ptr);
		return (R)((object)Marshal.PtrToStructure(ptr2, typeof(R)));
	}

	// Token: 0x1700002A RID: 42
	// (get) Token: 0x060002C2 RID: 706 RVA: 0x000270D0 File Offset: 0x000252D0
	public int TableCount
	{
		get
		{
			return this.RecordAmount;
		}
	}

	// Token: 0x1700002B RID: 43
	// (get) Token: 0x060002C3 RID: 707 RVA: 0x000270D8 File Offset: 0x000252D8
	public ushort MapCount
	{
		get
		{
			return this.MaxKey;
		}
	}

	// Token: 0x1700002C RID: 44
	// (get) Token: 0x060002C4 RID: 708 RVA: 0x000270E0 File Offset: 0x000252E0
	public unsafe IntPtr TablePtr
	{
		get
		{
			byte* ptr = (byte*)this.BytesIntPtr.ToPointer();
			ptr += 4;
			IntPtr result = new IntPtr((void*)ptr);
			return result;
		}
	}

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x060002C5 RID: 709 RVA: 0x00027108 File Offset: 0x00025308
	public IntPtr MapPtr
	{
		get
		{
			return this.KeyMapIndex;
		}
	}

	// Token: 0x0400092B RID: 2347
	protected ushort MaxKey;

	// Token: 0x0400092C RID: 2348
	protected int RecordAmount;

	// Token: 0x0400092D RID: 2349
	protected IntPtr KeyMapIndex;

	// Token: 0x0400092E RID: 2350
	protected IntPtr BytesIntPtr;
}
