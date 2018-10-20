using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200019C RID: 412
public struct IconSpriteAsset
{
	// Token: 0x060005E0 RID: 1504 RVA: 0x00082048 File Offset: 0x00080248
	public void InitialAsset(string AssetName)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("UI/{0}", AssetName);
		this.m_AssetBundle = AssetManager.GetAssetBundle(stringBuilder.ToString(), out this.m_AssetBundleKey, false);
		this.m_Dict = new Dictionary<ushort, Sprite>();
		if (this.m_AssetBundle != null)
		{
			UnityEngine.Object[] array = this.m_AssetBundle.LoadAll(typeof(Sprite));
			stringBuilder.Length = 0;
			stringBuilder.AppendFormat("{0}_m", AssetName);
			this.m_Material = (this.m_AssetBundle.Load(stringBuilder.ToString(), typeof(Material)) as Material);
			for (int i = 0; i < array.Length; i++)
			{
				this.m_Dict.Add(ushort.Parse(array[i].name.Substring(1)), (Sprite)array[i]);
			}
		}
	}

	// Token: 0x060005E1 RID: 1505 RVA: 0x00082128 File Offset: 0x00080328
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

	// Token: 0x060005E2 RID: 1506 RVA: 0x00082170 File Offset: 0x00080370
	public Sprite LoadSprite(ushort id)
	{
		Sprite result;
		this.m_Dict.TryGetValue(id, out result);
		return result;
	}

	// Token: 0x060005E3 RID: 1507 RVA: 0x00082190 File Offset: 0x00080390
	public Material GetMaterial()
	{
		return this.m_Material;
	}

	// Token: 0x040017B4 RID: 6068
	private AssetBundle m_AssetBundle;

	// Token: 0x040017B5 RID: 6069
	private int m_AssetBundleKey;

	// Token: 0x040017B6 RID: 6070
	private Dictionary<ushort, Sprite> m_Dict;

	// Token: 0x040017B7 RID: 6071
	private Material m_Material;
}
