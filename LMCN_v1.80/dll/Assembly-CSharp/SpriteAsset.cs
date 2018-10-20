using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200019B RID: 411
public struct SpriteAsset
{
	// Token: 0x060005DE RID: 1502 RVA: 0x00081F14 File Offset: 0x00080114
	public void InitialAsset(string AssetName)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(AssetName);
		cstring.AppendFormat("UI/{0}");
		this.m_AssetBundle = AssetManager.GetAssetBundle(cstring, out this.m_AssetBundleKey);
		if (this.m_AssetBundle == null)
		{
			return;
		}
		UnityEngine.Object[] array = this.m_AssetBundle.LoadAll(typeof(Sprite));
		cstring.ClearString();
		cstring.StringToFormat(AssetName);
		cstring.AppendFormat("{0}_m");
		this.m_Material = (this.m_AssetBundle.Load(cstring.ToString(), typeof(Material)) as Material);
		this.m_RefCount = 1;
		this.m_Dict = new Dictionary<int, Sprite>();
		for (int i = 0; i < array.Length; i++)
		{
			this.m_Dict.Add(array[i].name.GetHashCode(), (Sprite)array[i]);
		}
	}

	// Token: 0x060005DF RID: 1503 RVA: 0x00082000 File Offset: 0x00080200
	public void UnloadAsset()
	{
		if (this.m_AssetBundleKey == 0)
		{
			return;
		}
		AssetManager.UnloadAssetBundle(this.m_AssetBundleKey, true);
		this.m_Dict.Clear();
		this.m_Material = null;
		this.m_AssetBundle = null;
		this.m_AssetBundleKey = 0;
	}

	// Token: 0x040017AF RID: 6063
	public int m_RefCount;

	// Token: 0x040017B0 RID: 6064
	public Dictionary<int, Sprite> m_Dict;

	// Token: 0x040017B1 RID: 6065
	public AssetBundle m_AssetBundle;

	// Token: 0x040017B2 RID: 6066
	public int m_AssetBundleKey;

	// Token: 0x040017B3 RID: 6067
	public Material m_Material;
}
