using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x020001BE RID: 446
public class ModelLoader
{
	// Token: 0x06000777 RID: 1911 RVA: 0x000A27C8 File Offset: 0x000A09C8
	public ModelLoader()
	{
		AssetManager instance = AssetManager.Instance;
		int num = instance.Shaders.Length;
		for (int i = 0; i < num; i++)
		{
			if (instance.Shaders[i].name == "zTWRD2 Shaders/Model/Diffuse")
			{
				this.modelDefuse = (Shader)instance.Shaders[i];
				break;
			}
		}
	}

	// Token: 0x1700004D RID: 77
	// (get) Token: 0x06000779 RID: 1913 RVA: 0x000A2864 File Offset: 0x000A0A64
	public static ModelLoader Instance
	{
		get
		{
			if (ModelLoader.m_Self == null)
			{
				ModelLoader.m_Self = new ModelLoader();
			}
			return ModelLoader.m_Self;
		}
	}

	// Token: 0x0600077A RID: 1914 RVA: 0x000A2880 File Offset: 0x000A0A80
	public void Clear()
	{
		Debug.Log("Clean all: " + this.m_MatMap.Count.ToString());
		this.m_MatMap.Clear();
		this.m_MatList.Clear();
	}

	// Token: 0x0600077B RID: 1915 RVA: 0x000A28C8 File Offset: 0x000A0AC8
	public GameObject Load(ushort modelID, AssetBundle ab, ushort texID = 0)
	{
		if (modelID <= 0 || ab == null || this.modelDefuse == null)
		{
			return null;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(ab.Load("mwm")) as GameObject;
		if (gameObject == null)
		{
			return null;
		}
		SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren == null)
		{
			return null;
		}
		ModelLoader.MatNode matNode = null;
		ModelLoader.ModelNode modelNode = null;
		bool flag = this.m_MatList.TryGetValue(modelID, out modelNode);
		if (!flag || (flag && modelNode.matNode[(int)texID] == null))
		{
			this.sb.Length = 0;
			this.sb.AppendFormat("m{0:00}", texID);
			if (!ab.Contains(this.sb.ToString()))
			{
				this.sb.Length = 0;
				this.sb.Append("m00");
			}
			Texture2D texture2D = ab.Load(this.sb.ToString(), typeof(Texture2D)) as Texture2D;
			if (texture2D != null)
			{
				Material material = new Material(this.modelDefuse);
				material.mainTexture = texture2D;
				uint value = (uint)((int)modelID << 16 | (int)texID);
				this.m_MatMap.Add(material.GetInstanceID(), value);
				matNode = new ModelLoader.MatNode();
				matNode.material = material;
				if (!flag)
				{
					modelNode = new ModelLoader.ModelNode();
					this.m_MatList.Add(modelID, modelNode);
				}
				modelNode.matNode[(int)texID] = matNode;
			}
		}
		else
		{
			matNode = modelNode.matNode[(int)texID];
		}
		if (matNode == null || (matNode != null && matNode.material == null))
		{
			return null;
		}
		componentInChildren.material = matNode.material;
		ModelLoader.MatNode matNode2 = matNode;
		matNode2.refCount += 1;
		ModelLoader.ModelNode modelNode2 = modelNode;
		modelNode2.refCount += 1;
		return gameObject;
	}

	// Token: 0x0600077C RID: 1916 RVA: 0x000A2AA4 File Offset: 0x000A0CA4
	public Material LoadMaterial(ushort modelID, AssetBundle ab, ushort texID = 0)
	{
		if (modelID <= 0 || ab == null || this.modelDefuse == null)
		{
			return null;
		}
		ModelLoader.MatNode matNode = null;
		ModelLoader.ModelNode modelNode = null;
		bool flag = this.m_MatList.TryGetValue(modelID, out modelNode);
		if (!flag || (flag && modelNode.matNode[(int)texID] == null))
		{
			this.sb.Length = 0;
			this.sb.AppendFormat("m{0:00}", texID);
			if (!ab.Contains(this.sb.ToString()))
			{
				this.sb.Length = 0;
				this.sb.Append("m00");
			}
			Texture2D texture2D = ab.Load(this.sb.ToString(), typeof(Texture2D)) as Texture2D;
			if (texture2D != null)
			{
				Material material = new Material(this.modelDefuse);
				material.mainTexture = texture2D;
				uint value = (uint)((int)modelID << 16 | (int)texID);
				this.m_MatMap.Add(material.GetInstanceID(), value);
				matNode = new ModelLoader.MatNode();
				matNode.material = material;
				if (!flag)
				{
					modelNode = new ModelLoader.ModelNode();
					this.m_MatList.Add(modelID, modelNode);
				}
				modelNode.matNode[(int)texID] = matNode;
			}
		}
		else
		{
			matNode = modelNode.matNode[(int)texID];
		}
		if (matNode == null || (matNode != null && matNode.material == null))
		{
			return null;
		}
		ModelLoader.MatNode matNode2 = matNode;
		matNode2.refCount += 1;
		ModelLoader.ModelNode modelNode2 = modelNode;
		modelNode2.refCount += 1;
		Debug.Log(string.Concat(new string[]
		{
			modelID.ToString(),
			": modelCt: ",
			modelNode.refCount.ToString(),
			" ,matCt: ",
			matNode.refCount.ToString()
		}));
		return matNode.material;
	}

	// Token: 0x0600077D RID: 1917 RVA: 0x000A2C80 File Offset: 0x000A0E80
	public void UnloadMaterial(Material material)
	{
		int instanceID = material.GetInstanceID();
		if (!this.m_MatMap.ContainsKey(instanceID))
		{
			Debug.LogError("Material memory leak appear");
			return;
		}
		uint num = this.m_MatMap[instanceID];
		ushort key = (ushort)(num >> 16);
		ushort num2 = (ushort)(num & 65535u);
		ModelLoader.ModelNode modelNode = this.m_MatList[key];
		if (modelNode != null)
		{
			ModelLoader.MatNode matNode = modelNode.matNode[(int)num2];
			ModelLoader.MatNode matNode2 = matNode;
			matNode2.refCount -= 1;
			if (matNode.refCount == 0)
			{
				UnityEngine.Object.DestroyImmediate(modelNode.matNode[(int)num2].material, true);
				modelNode.matNode[(int)num2] = null;
				this.m_MatMap.Remove(instanceID);
			}
			ModelLoader.ModelNode modelNode2 = modelNode;
			modelNode2.refCount -= 1;
			if (modelNode.refCount == 0)
			{
				this.m_MatList.Remove(key);
			}
			Debug.Log("modelCt: " + modelNode.refCount.ToString() + " ,matCt: " + matNode.refCount.ToString());
		}
	}

	// Token: 0x0600077E RID: 1918 RVA: 0x000A2D88 File Offset: 0x000A0F88
	public void Unload(UnityEngine.Object obj)
	{
		GameObject gameObject = obj as GameObject;
		if (gameObject == null)
		{
			return;
		}
		if (!gameObject.activeSelf)
		{
			gameObject.SetActive(true);
		}
		SkinnedMeshRenderer componentInChildren = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null)
		{
			int instanceID = componentInChildren.sharedMaterial.GetInstanceID();
			if (!this.m_MatMap.ContainsKey(instanceID))
			{
				Debug.LogError("Material memory leak appear");
				return;
			}
			uint num = this.m_MatMap[instanceID];
			ushort key = (ushort)(num >> 16);
			ushort num2 = (ushort)(num & 65535u);
			ModelLoader.ModelNode modelNode = this.m_MatList[key];
			if (modelNode != null)
			{
				ModelLoader.MatNode matNode = modelNode.matNode[(int)num2];
				ModelLoader.MatNode matNode2 = matNode;
				matNode2.refCount -= 1;
				if (matNode.refCount == 0)
				{
					UnityEngine.Object.DestroyImmediate(modelNode.matNode[(int)num2].material, true);
					modelNode.matNode[(int)num2] = null;
					this.m_MatMap.Remove(instanceID);
				}
				ModelLoader.ModelNode modelNode2 = modelNode;
				modelNode2.refCount -= 1;
				if (modelNode.refCount == 0)
				{
					this.m_MatList.Remove(key);
				}
			}
		}
		UnityEngine.Object.Destroy(gameObject);
	}

	// Token: 0x04001B8F RID: 7055
	private const ushort MAX_MODEL_MAT = 200;

	// Token: 0x04001B90 RID: 7056
	private Dictionary<ushort, ModelLoader.ModelNode> m_MatList = new Dictionary<ushort, ModelLoader.ModelNode>(200);

	// Token: 0x04001B91 RID: 7057
	private Dictionary<int, uint> m_MatMap = new Dictionary<int, uint>(200);

	// Token: 0x04001B92 RID: 7058
	private StringBuilder sb = new StringBuilder(64);

	// Token: 0x04001B93 RID: 7059
	private Shader modelDefuse;

	// Token: 0x04001B94 RID: 7060
	private static ModelLoader m_Self;

	// Token: 0x020001BF RID: 447
	public class MatNode
	{
		// Token: 0x04001B95 RID: 7061
		public Material material;

		// Token: 0x04001B96 RID: 7062
		public ushort refCount;
	}

	// Token: 0x020001C0 RID: 448
	public class ModelNode
	{
		// Token: 0x04001B97 RID: 7063
		public ushort refCount;

		// Token: 0x04001B98 RID: 7064
		public ModelLoader.MatNode[] matNode = new ModelLoader.MatNode[10];
	}
}
