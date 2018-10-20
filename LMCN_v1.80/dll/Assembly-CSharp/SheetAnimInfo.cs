using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x02000733 RID: 1843
public class SheetAnimInfo
{
	// Token: 0x0600233C RID: 9020 RVA: 0x0040E9B8 File Offset: 0x0040CBB8
	private SheetAnimInfo()
	{
	}

	// Token: 0x170000CC RID: 204
	// (get) Token: 0x0600233E RID: 9022 RVA: 0x0040EA54 File Offset: 0x0040CC54
	public static SheetAnimInfo Instance
	{
		get
		{
			if (SheetAnimInfo.m_Self == null)
			{
				SheetAnimInfo.m_Self = new SheetAnimInfo();
			}
			return SheetAnimInfo.m_Self;
		}
	}

	// Token: 0x0600233F RID: 9023 RVA: 0x0040EA70 File Offset: 0x0040CC70
	public void DestroyAllMesh()
	{
		this.m_AnimList.Clear();
		this.m_AnimFOList.Clear();
		this.m_MeshList.Clear();
		if (this.nonBatching_sharedMat)
		{
			UnityEngine.Object.Destroy(this.nonBatching_sharedMat);
			this.nonBatching_sharedMat = null;
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.sharedMat[i] != null)
			{
				if (this.sharedMat[i].mainTexture != null)
				{
					UnityEngine.Object.DestroyImmediate(this.sharedMat[i].mainTexture, true);
					this.sharedMat[i].mainTexture = null;
				}
				UnityEngine.Object.Destroy(this.sharedMat[i]);
				this.sharedMat[i] = null;
			}
			if (this.m_TexBundle[i])
			{
				this.m_TexBundle[i].Unload(true);
				this.m_TexBundle[i] = null;
			}
		}
		Resources.UnloadUnusedAssets();
	}

	// Token: 0x06002340 RID: 9024 RVA: 0x0040EB64 File Offset: 0x0040CD64
	public void createMesh(ushort heroID)
	{
		if (this.m_MeshList.ContainsKey(heroID))
		{
			return;
		}
		this.StringInstance.Length = 0;
		this.StringInstance.AppendFormat("Role/soldier_{0:000}", heroID);
		AssetBundle assetBundle = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
		GameObject gameObject = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
		SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		Animation component = gameObject.GetComponent<Animation>();
		if (this.sharedMat[0] == null)
		{
			Shader shader = null;
			AssetManager instance = AssetManager.Instance;
			int num = instance.Shaders.Length;
			for (int i = 0; i < num; i++)
			{
				if (instance.Shaders[i].name == "zTWRD2 Shaders/Model/Unlit (Supports Lightmap)")
				{
					shader = (Shader)instance.Shaders[i];
					break;
				}
			}
			for (int j = 0; j < 3; j++)
			{
				this.sharedMat[j] = new Material(shader);
				this.m_TexBundle[j] = AssetManager.GetAssetBundle(SheetAnimInfo.TexBundleName[j], 0L);
				Texture mainTexture = this.m_TexBundle[j].mainAsset as Texture;
				this.sharedMat[j].mainTexture = mainTexture;
			}
			this.nonBatching_sharedMat = new Material(shader);
			this.nonBatching_sharedMat.mainTexture = this.sharedMat[0].mainTexture;
		}
		int num2 = 0;
		for (int k = 0; k < 5; k++)
		{
			AnimationClip clip = component.GetClip(((ESheetMeshAnim)k).ToString());
			if (clip)
			{
				uint key = (uint)(k << 16 | (int)heroID);
				num2 = this.SampleStaticMeshToList(gameObject, componentInChildren, clip, this.m_AnimList, key);
			}
		}
		Debug.Log(heroID.ToString() + " = " + num2.ToString());
		this.m_MeshList.Add(heroID, 1);
		UnityEngine.Object.Destroy(gameObject);
		assetBundle.Unload(true);
	}

	// Token: 0x06002341 RID: 9025 RVA: 0x0040ED64 File Offset: 0x0040CF64
	public static Material GetMaterial(ESheetMeshTexKind kind)
	{
		return (kind >= ESheetMeshTexKind.MAX) ? null : SheetAnimInfo.Instance.sharedMat[(int)kind];
	}

	// Token: 0x06002342 RID: 9026 RVA: 0x0040ED80 File Offset: 0x0040CF80
	public void createAnimFO(ushort modelID)
	{
		if (this.m_MeshList.ContainsKey(modelID * 10))
		{
			return;
		}
		this.StringInstance.Length = 0;
		this.StringInstance.AppendFormat("Role/BrokenFO_{0:000}", modelID);
		AssetBundle assetBundle = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
		GameObject gameObject = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
		SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		Animation component = gameObject.GetComponent<Animation>();
		int num = 0;
		AnimationClip clip = component.GetClip("attack");
		if (clip)
		{
			num = this.SampleStaticMeshToList(gameObject, componentInChildren, clip, this.m_AnimFOList, (uint)modelID);
		}
		Debug.Log(modelID.ToString() + " = " + num.ToString());
		this.m_MeshList.Add(modelID * 10, 1);
		UnityEngine.Object.Destroy(gameObject);
		assetBundle.Unload(true);
	}

	// Token: 0x06002343 RID: 9027 RVA: 0x0040EE64 File Offset: 0x0040D064
	private int SampleStaticMeshToList(GameObject SkeletalGO, SkinnedMeshRenderer smr, AnimationClip ac, Dictionary<uint, sAnimInfo> list, uint key)
	{
		float length = ac.length;
		float num = 40f;
		int num2 = (int)(length * 30f + 1f);
		float num3 = (float)(num2 - 1) * 0.1f;
		num2 = (int)(num3 * num + 1f);
		float num4 = length / (float)num2;
		Mesh[] array = new Mesh[num2];
		for (int i = 0; i < num2; i++)
		{
			SkeletalGO.SampleAnimation(ac, (float)i * num4);
			Mesh mesh = new Mesh();
			smr.BakeMesh(mesh);
			mesh.Optimize();
			array[i] = mesh;
		}
		list.Add(key, new sAnimInfo
		{
			animLength = (float)(num2 - 1) * 0.025f,
			keyframeCount = num2,
			animMesh = array
		});
		return (num2 <= 0 || !(array[0] != null)) ? 0 : array[0].vertexCount;
	}

	// Token: 0x06002344 RID: 9028 RVA: 0x0040EF4C File Offset: 0x0040D14C
	public void createCastleGate(ushort modelID)
	{
		if (this.m_MeshList.ContainsKey(modelID * 100))
		{
			return;
		}
		this.StringInstance.Length = 0;
		this.StringInstance.AppendFormat("Role/CastleGate_{0:00}", modelID);
		AssetBundle assetBundle = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
		GameObject gameObject = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
		MeshFilter component = gameObject.GetComponent<MeshFilter>();
		Mesh[] animMesh = new Mesh[]
		{
			component.mesh
		};
		sAnimInfo value = default(sAnimInfo);
		value.animLength = 0f;
		value.keyframeCount = 1;
		value.animMesh = animMesh;
		this.m_CastleGateList.Add((uint)modelID, value);
		this.m_MeshList.Add(modelID * 100, 1);
		UnityEngine.Object.Destroy(gameObject);
		assetBundle.Unload(true);
	}

	// Token: 0x06002345 RID: 9029 RVA: 0x0040F020 File Offset: 0x0040D220
	public sAnimInfo getAnimInfo(ushort heroID, ushort animIdx)
	{
		uint key = (uint)((int)animIdx << 16 | (int)heroID);
		return this.m_AnimList[key];
	}

	// Token: 0x06002346 RID: 9030 RVA: 0x0040F040 File Offset: 0x0040D240
	public sAnimInfo getAnimFOInfo(ushort modelID)
	{
		return this.m_AnimFOList[(uint)modelID];
	}

	// Token: 0x06002347 RID: 9031 RVA: 0x0040F050 File Offset: 0x0040D250
	public sAnimInfo getBuildMesh(ushort modelID)
	{
		return this.m_CastleGateList[(uint)modelID];
	}

	// Token: 0x06002348 RID: 9032 RVA: 0x0040F060 File Offset: 0x0040D260
	public ushort getMeshInfo(ushort heroID)
	{
		return this.m_MeshList[heroID];
	}

	// Token: 0x06002349 RID: 9033 RVA: 0x0040F070 File Offset: 0x0040D270
	public bool containMesh(ushort modelID)
	{
		return this.m_MeshList.ContainsKey(modelID);
	}

	// Token: 0x04006C5A RID: 27738
	public const float SAMPLE_RATE = 0.025f;

	// Token: 0x04006C5B RID: 27739
	public const int MAX_ANIM = 64;

	// Token: 0x04006C5C RID: 27740
	public const int MAX_MESH = 16;

	// Token: 0x04006C5D RID: 27741
	public const int MAX_ANIMFO = 4;

	// Token: 0x04006C5E RID: 27742
	public const int MAX_CASTLEGATE = 4;

	// Token: 0x04006C5F RID: 27743
	private const int SHARE_TEX_COUNT = 3;

	// Token: 0x04006C60 RID: 27744
	public static SheetAnimInfo m_Self = null;

	// Token: 0x04006C61 RID: 27745
	public Dictionary<uint, sAnimInfo> m_AnimList = new Dictionary<uint, sAnimInfo>(64);

	// Token: 0x04006C62 RID: 27746
	public Dictionary<uint, sAnimInfo> m_AnimFOList = new Dictionary<uint, sAnimInfo>(4);

	// Token: 0x04006C63 RID: 27747
	public Dictionary<uint, sAnimInfo> m_CastleGateList = new Dictionary<uint, sAnimInfo>(4);

	// Token: 0x04006C64 RID: 27748
	public Dictionary<ushort, ushort> m_MeshList = new Dictionary<ushort, ushort>(24);

	// Token: 0x04006C65 RID: 27749
	public StringBuilder StringInstance = new StringBuilder(256);

	// Token: 0x04006C66 RID: 27750
	public Material nonBatching_sharedMat;

	// Token: 0x04006C67 RID: 27751
	private Material[] sharedMat = new Material[3];

	// Token: 0x04006C68 RID: 27752
	private AssetBundle[] m_TexBundle = new AssetBundle[3];

	// Token: 0x04006C69 RID: 27753
	private static readonly string[] TexBundleName = new string[]
	{
		"Role/soldiers_tex",
		"Role/soldiers_tex_2",
		"Role/soldiers_tex_3"
	};
}
