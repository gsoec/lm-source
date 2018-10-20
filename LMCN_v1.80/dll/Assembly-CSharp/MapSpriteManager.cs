using System;
using UnityEngine;

// Token: 0x020003C1 RID: 961
public class MapSpriteManager
{
	// Token: 0x060013FD RID: 5117 RVA: 0x00233C80 File Offset: 0x00231E80
	public MapSpriteManager(WorldMode worldmode, ushort Count)
	{
		if (Count == 0)
		{
			return;
		}
		this.worldmode = worldmode;
		this.GameObjectCount = Count;
		this.GameObjectPool = new GameObject[(int)this.GameObjectCount];
		this.Initial();
	}

	// Token: 0x17000091 RID: 145
	// (get) Token: 0x060013FE RID: 5118 RVA: 0x00233CCC File Offset: 0x00231ECC
	public Material SpriteMaterial
	{
		get
		{
			return GUIManager.Instance.MapSpriteMaterial;
		}
	}

	// Token: 0x17000092 RID: 146
	// (get) Token: 0x060013FF RID: 5119 RVA: 0x00233CD8 File Offset: 0x00231ED8
	public Material SpriteUIMaterial
	{
		get
		{
			return GUIManager.Instance.MapSpriteUIMaterial;
		}
	}

	// Token: 0x06001400 RID: 5120 RVA: 0x00233CE4 File Offset: 0x00231EE4
	private void Initial()
	{
		if (this.worldmode == WorldMode.Wild)
		{
			this.InitialWide();
		}
		else
		{
			this.InitialDoor();
		}
	}

	// Token: 0x06001401 RID: 5121 RVA: 0x00233D04 File Offset: 0x00231F04
	private void InitialWide()
	{
		GameObject gameObject = new GameObject("MapSprite");
		SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		spriteRenderer.color = Color.black;
		spriteRenderer.material = this.SpriteMaterial;
		this.GameObjectPool[0] = gameObject;
		this.GameObjectPool[0].SetActive(false);
		for (int i = 1; i < (int)this.GameObjectCount; i++)
		{
			this.GameObjectPool[i] = (UnityEngine.Object.Instantiate(gameObject) as GameObject);
			this.GameObjectPool[i].SetActive(false);
		}
	}

	// Token: 0x06001402 RID: 5122 RVA: 0x00233D8C File Offset: 0x00231F8C
	private void InitialDoor()
	{
		GUIManager instance = GUIManager.Instance;
		GameObject gameObject = new GameObject("MapSprite");
		SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
		spriteRenderer.color = Color.black;
		spriteRenderer.material = instance.m_IconSpriteAsset.GetMaterial();
		this.GameObjectPool[0] = gameObject;
		this.GameObjectPool[0].SetActive(false);
		byte b = 1;
		while ((ushort)b < this.GameObjectCount)
		{
			this.GameObjectPool[(int)b] = (UnityEngine.Object.Instantiate(gameObject) as GameObject);
			this.GameObjectPool[(int)b].SetActive(false);
			b += 1;
		}
	}

	// Token: 0x06001403 RID: 5123 RVA: 0x00233E20 File Offset: 0x00232020
	public void InitTextObj(ushort Count)
	{
		GUIManager instance = GUIManager.Instance;
		this.TextObjCount = Count;
		Font ttffont = instance.GetTTFFont();
		this.TextmeshArray = new MeshRenderer[(int)(Count * 5)];
		this.TextObjPool = new GameObject[(int)this.TextObjCount];
		this.TextObjPool[0] = new GameObject("Stage");
		this.TextObjPool[0].AddComponent<SpriteRenderer>();
		GameObject gameObject = new GameObject("Text");
		TextMesh textMesh = gameObject.AddComponent<TextMesh>();
		MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
		component.castShadows = false;
		component.receiveShadows = false;
		this.TextmeshArray[0] = component;
		textMesh.font = ttffont;
		textMesh.fontSize = 18;
		textMesh.richText = false;
		Material material = new Material(ttffont.material);
		material.shader = Shader.Find("UI/Default Font");
		textMesh.renderer.material = material;
		component.renderer.sortingOrder = -20;
		gameObject.transform.SetParent(this.TextObjPool[0].transform);
		this.TextObjPool[0].SetActive(false);
		for (byte b = 0; b < 4; b += 1)
		{
			GameObject gameObject2 = new GameObject("outline", new Type[]
			{
				typeof(TextMesh)
			});
			textMesh = gameObject2.GetComponent<TextMesh>();
			this.TextmeshArray[(int)(1 + b)] = gameObject2.GetComponent<MeshRenderer>();
			textMesh.fontSize = 18;
			component = gameObject2.GetComponent<MeshRenderer>();
			component.renderer.sortingOrder = -30;
			component.castShadows = false;
			component.receiveShadows = false;
			component.material = material;
			textMesh.font = ttffont;
			textMesh.richText = false;
			gameObject2.transform.SetParent(gameObject.transform);
			textMesh.color = Color.black;
		}
		byte b2 = 1;
		while ((ushort)b2 < this.TextObjCount)
		{
			this.TextObjPool[(int)b2] = (UnityEngine.Object.Instantiate(this.TextObjPool[0]) as GameObject);
			this.TextObjPool[(int)b2].SetActive(false);
			this.TextmeshArray[(int)(5 * b2)] = this.TextObjPool[(int)b2].transform.GetChild(0).GetComponent<MeshRenderer>();
			for (byte b3 = 0; b3 < 4; b3 += 1)
			{
				this.TextmeshArray[(int)(5 * b2 + 1 + b3)] = this.TextObjPool[(int)b2].transform.GetChild(0).GetChild((int)b3).GetComponent<MeshRenderer>();
			}
			b2 += 1;
		}
	}

	// Token: 0x06001404 RID: 5124 RVA: 0x00234090 File Offset: 0x00232290
	public void TextRefresh()
	{
		if (this.TextmeshArray == null)
		{
			return;
		}
		for (int i = 0; i < this.TextmeshArray.Length; i++)
		{
			if (!(this.TextmeshArray[i] == null))
			{
				this.TextmeshArray[i].enabled = false;
				this.TextmeshArray[i].enabled = true;
			}
		}
	}

	// Token: 0x06001405 RID: 5125 RVA: 0x002340F8 File Offset: 0x002322F8
	private Vector3 GetOffset(int i)
	{
		switch (i % 4)
		{
		case 0:
			return new Vector3(0f, 1f, 0f);
		case 1:
			return new Vector3(1f, 0f, 0f);
		case 2:
			return new Vector3(-1f, 0f, 0f);
		case 3:
			return new Vector3(0f, -1f, 0f);
		default:
			return Vector3.zero;
		}
	}

	// Token: 0x06001406 RID: 5126 RVA: 0x00234180 File Offset: 0x00232380
	public void SetOutlinePosition(Transform TextTransform, string Text)
	{
		Vector3 a = Camera.main.WorldToScreenPoint(TextTransform.position);
		bool flag = false;
		int num = 1024;
		float num2 = 1f;
		bool flag2 = flag && (Screen.width > num || Screen.height > num);
		for (int i = 0; i < TextTransform.childCount; i++)
		{
			TextTransform.GetChild(i).GetComponent<TextMesh>().text = Text;
			Transform child = TextTransform.GetChild(i);
			Vector3 b = this.GetOffset(i) * ((!flag2) ? num2 : (2f * num2));
			Vector3 position = Camera.main.ScreenToWorldPoint(a + b);
			child.transform.position = position;
		}
	}

	// Token: 0x06001407 RID: 5127 RVA: 0x0023424C File Offset: 0x0023244C
	public GameObject GetSpriteObj()
	{
		GameObject gameObject = this.GameObjectPool[(int)this.PoolIndex];
		gameObject.SetActive(true);
		this.PoolIndex += 1;
		if (this.PoolIndex >= this.GameObjectCount)
		{
			this.PoolIndex = 0;
		}
		return gameObject;
	}

	// Token: 0x06001408 RID: 5128 RVA: 0x00234298 File Offset: 0x00232498
	public void ReleaseSpriteObj(GameObject go)
	{
		if (go)
		{
			go.SetActive(false);
		}
	}

	// Token: 0x06001409 RID: 5129 RVA: 0x002342AC File Offset: 0x002324AC
	public GameObject GetTextObj()
	{
		GameObject gameObject = this.TextObjPool[(int)this.TextIndex];
		gameObject.SetActive(true);
		this.TextIndex += 1;
		if (this.TextIndex >= this.TextObjCount)
		{
			this.TextIndex = 0;
		}
		return gameObject;
	}

	// Token: 0x0600140A RID: 5130 RVA: 0x002342F8 File Offset: 0x002324F8
	public void ReleaseTextObj(GameObject go)
	{
		if (go)
		{
			go.SetActive(false);
		}
	}

	// Token: 0x0600140B RID: 5131 RVA: 0x0023430C File Offset: 0x0023250C
	public Sprite GetSpriteByID(ushort ID)
	{
		return GUIManager.Instance.m_IconSpriteAsset.LoadSprite(ID);
	}

	// Token: 0x0600140C RID: 5132 RVA: 0x00234320 File Offset: 0x00232520
	public Sprite GetSpriteByName(string Name)
	{
		if (Name == null)
		{
			return null;
		}
		Sprite result;
		if (GUIManager.Instance.MapIconDict.TryGetValue(Name.GetHashCode(), out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600140D RID: 5133 RVA: 0x00234354 File Offset: 0x00232554
	public void Destory()
	{
		for (int i = 0; i < (int)this.GameObjectCount; i++)
		{
			UnityEngine.Object.Destroy(this.GameObjectPool[i]);
			this.GameObjectPool[i] = null;
		}
		byte b = 0;
		while ((ushort)b < this.TextObjCount)
		{
			UnityEngine.Object.Destroy(this.TextObjPool[(int)b]);
			this.TextObjPool[(int)b] = null;
			b += 1;
		}
		this.DestroyChallegeFrame();
	}

	// Token: 0x17000093 RID: 147
	// (get) Token: 0x0600140E RID: 5134 RVA: 0x002343C4 File Offset: 0x002325C4
	public Material ChallegeMaterial
	{
		get
		{
			return this._ChallegeMaterial;
		}
	}

	// Token: 0x0600140F RID: 5135 RVA: 0x002343CC File Offset: 0x002325CC
	public void LoadChallegeFrame()
	{
		if (DataManager.StageDataController._stageMode != StageMode.Dare)
		{
			return;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat("ChallegeFrame");
		cstring.AppendFormat("UI/{0}");
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.ChallegeAssKey);
		UnityEngine.Object[] array = assetBundle.LoadAll();
		if (assetBundle == null)
		{
			return;
		}
		UnityEngine.Object[] array2 = assetBundle.LoadAll(typeof(Sprite));
		cstring.ClearString();
		cstring.StringToFormat("ChallegeFrame");
		cstring.AppendFormat("{0}_m");
		this._ChallegeMaterial = (assetBundle.Load(cstring.ToString(), typeof(Material)) as Material);
		for (int i = 0; i < array2.Length; i++)
		{
			Sprite sprite = array2[i] as Sprite;
			if (!(sprite == null))
			{
				cstring.ClearString();
				int startIndex = sprite.name.Length - 3;
				Debug.Log(sprite.name.Substring(startIndex));
				int num;
				if (int.TryParse(sprite.name.Substring(startIndex), out num) && num < this.ChallegeFrame.Length)
				{
					this.ChallegeFrame[num] = sprite;
				}
			}
		}
	}

	// Token: 0x06001410 RID: 5136 RVA: 0x00234510 File Offset: 0x00232710
	public Sprite GetChalleteSprite(byte difficult)
	{
		return this.ChallegeFrame[(int)(((int)difficult < this.ChallegeFrame.Length) ? difficult : 0)];
	}

	// Token: 0x06001411 RID: 5137 RVA: 0x00234530 File Offset: 0x00232730
	private void DestroyChallegeFrame()
	{
		if (this.ChallegeAssKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.ChallegeAssKey, true);
		}
		this.ChallegeAssKey = 0;
	}

	// Token: 0x04003C65 RID: 15461
	private ushort GameObjectCount;

	// Token: 0x04003C66 RID: 15462
	private GameObject[] GameObjectPool;

	// Token: 0x04003C67 RID: 15463
	private ushort PoolIndex;

	// Token: 0x04003C68 RID: 15464
	private ushort TextObjCount;

	// Token: 0x04003C69 RID: 15465
	private GameObject[] TextObjPool;

	// Token: 0x04003C6A RID: 15466
	private ushort TextIndex;

	// Token: 0x04003C6B RID: 15467
	private WorldMode worldmode;

	// Token: 0x04003C6C RID: 15468
	private MeshRenderer[] TextmeshArray;

	// Token: 0x04003C6D RID: 15469
	private Material _ChallegeMaterial;

	// Token: 0x04003C6E RID: 15470
	private Sprite[] ChallegeFrame = new Sprite[4];

	// Token: 0x04003C6F RID: 15471
	private int ChallegeAssKey;
}
