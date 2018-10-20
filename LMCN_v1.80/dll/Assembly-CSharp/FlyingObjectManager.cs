using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200072F RID: 1839
public class FlyingObjectManager
{
	// Token: 0x06002335 RID: 9013 RVA: 0x0040E3AC File Offset: 0x0040C5AC
	private FlyingObjectManager():base()
	{
		ushort[] array = new ushort[8];
		array[4] = 2016;
		this.FO_OBJKIND = array;
		this.MaxCount = new int[8];
		this.freeList = new List<FlyingObject>[8];
		this.bundleList = new AssetBundle[8];
		this.StringInstance = new StringBuilder(128);
	}

	// Token: 0x06002336 RID: 9014 RVA: 0x0040E454 File Offset: 0x0040C654
	public FlyingObjectManager(Transform root, ushort[] count, WarParticleManager _particleMgr):base()
	{
		ushort[] array = new ushort[8];
		array[4] = 2016;
		this.FO_OBJKIND = array;
		this.MaxCount = new int[8];
		this.freeList = new List<FlyingObject>[8];
		this.bundleList = new AssetBundle[8];
		this.StringInstance = new StringBuilder(128);
		int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
		int ambient = 2 + sceneLightmapSize;
		this.renderRoot = root;
		this.particleMgr = _particleMgr;
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			this.MaxCount[i] = (int)count[i];
			this.freeList[i] = new List<FlyingObject>(this.MaxCount[i]);
			this.initFlyingObject((FOKind)i, this.FO_OBJKIND[i], this.BUNDLE_NAME[i], this.MaxCount[i], ambient);
			num += this.MaxCount[i];
		}
		this.workingList = new List<FlyingObject>(num);
	}

	// Token: 0x06002337 RID: 9015 RVA: 0x0040E584 File Offset: 0x0040C784
	private void initFlyingObject(FOKind foKind, ushort objKind, string filename, int count, int ambient)
	{
		if (count <= 0)
		{
			return;
		}
		GameObject gameObject = null;
		AssetBundle assetBundle = null;
		if (objKind == 0)
		{
			if (filename != string.Empty)
			{
				this.StringInstance.Length = 0;
				this.StringInstance.AppendFormat("Role/{0}", filename);
				assetBundle = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
				gameObject = (assetBundle.mainAsset as GameObject);
				MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
				component.material = SheetAnimInfo.GetMaterial(ESheetMeshTexKind.WAR_BLUE);
				component.renderer.lightmapIndex = ambient;
				MeshFilter component2 = gameObject.GetComponent<MeshFilter>();
			}
		}
		else
		{
			gameObject = this.particleMgr.SpawnWithoutManager(objKind);
		}
		List<FlyingObject> list = this.freeList[(int)foKind];
		for (int i = 0; i < count; i++)
		{
			GameObject gameObject2 = null;
			if (gameObject != null)
			{
				gameObject2 = (UnityEngine.Object.Instantiate(gameObject) as GameObject);
				gameObject2.transform.position = Vector3.zero;
				gameObject2.transform.parent = this.renderRoot;
				gameObject2.SetActive(false);
			}
			list.Add(new FlyingObject
			{
				SourceObj = gameObject2,
				foKind = foKind
			});
		}
		this.bundleList[(int)foKind] = assetBundle;
	}

	// Token: 0x06002338 RID: 9016 RVA: 0x0040E6BC File Offset: 0x0040C8BC
	public void Destroy()
	{
		for (int i = 0; i < this.workingList.Count; i++)
		{
			this.workingList[i].Destroy();
		}
		this.workingList.Clear();
		for (int j = 0; j < 8; j++)
		{
			List<FlyingObject> list = this.freeList[j];
			for (int k = 0; k < list.Count; k++)
			{
				list[k].Destroy();
			}
			list.Clear();
			if (this.bundleList[j] != null)
			{
				this.bundleList[j].Unload(true);
				this.bundleList[j] = null;
			}
		}
	}

	// Token: 0x06002339 RID: 9017 RVA: 0x0040E770 File Offset: 0x0040C970
	public FlyingObject addFlyingObject(FOKind kind, Vector3 begin, Transform end, float ms, Vector3 offset, Transform scaleRoot = null, ChaseType CurveType = ChaseType.CurveA, GameObject particle = null)
	{
		FlyingObject flyingObject = null;
		List<FlyingObject> list = this.freeList[(int)kind];
		if (list.Count > 0)
		{
			flyingObject = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
		}
		if (kind == FOKind.LightBall)
		{
			scaleRoot = null;
		}
		if (flyingObject != null)
		{
			if (flyingObject.SourceObj != null)
			{
				flyingObject.SourceObj.SetActive(true);
			}
			else if (particle != null)
			{
				particle.transform.position = Vector3.zero;
				particle.transform.parent = this.renderRoot;
				flyingObject.SourceObj = particle;
			}
			flyingObject.AddFlyingObject(begin, end, ms, offset, scaleRoot, CurveType);
			this.workingList.Add(flyingObject);
		}
		return flyingObject;
	}

	// Token: 0x0600233A RID: 9018 RVA: 0x0040E838 File Offset: 0x0040CA38
	public void recoverSpecialArrow()
	{
		for (int i = this.workingList.Count - 1; i >= 0; i--)
		{
			FlyingObject flyingObject = this.workingList[i];
			if (!flyingObject.bMove && flyingObject.foKind == FOKind.CLv1_Arrow)
			{
				flyingObject.SourceObj.SetActive(false);
				List<FlyingObject> list = this.freeList[(int)flyingObject.foKind];
				list.Add(flyingObject);
				this.workingList.RemoveAt(i);
			}
		}
	}

	// Token: 0x0600233B RID: 9019 RVA: 0x0040E8B4 File Offset: 0x0040CAB4
	public void Update(float deltaTime)
	{
		for (int i = this.workingList.Count - 1; i >= 0; i--)
		{
			FlyingObject flyingObject = this.workingList[i];
			if (flyingObject.bMove)
			{
				flyingObject.Update(deltaTime);
			}
			else if (flyingObject.foKind != FOKind.CLv1_Arrow)
			{
				if (flyingObject.foKind == FOKind.FreeParticle)
				{
					this.particleMgr.DeSpawn(flyingObject.SourceObj);
					flyingObject.SourceObj = null;
				}
				else
				{
					flyingObject.SourceObj.SetActive(false);
				}
				List<FlyingObject> list = this.freeList[(int)flyingObject.foKind];
				list.Add(flyingObject);
				this.workingList.RemoveAt(i);
			}
			else
			{
				flyingObject.specialDelay += deltaTime;
				if (flyingObject.specialDelay >= 1.5f)
				{
					flyingObject.SourceObj.SetActive(false);
					List<FlyingObject> list2 = this.freeList[(int)flyingObject.foKind];
					list2.Add(flyingObject);
					this.workingList.RemoveAt(i);
				}
			}
		}
	}

	// Token: 0x04006C42 RID: 27714
	public string[] BUNDLE_NAME = new string[]
	{
		"FO_Stone",
		"FO_Arrow",
		"FO_Bomb",
		"FO_FireStone",
		string.Empty,
		"FO_TArrow",
		"FO_CLV1_Arrow",
		string.Empty
	};

	// Token: 0x04006C43 RID: 27715
	public ushort[] FO_OBJKIND;

	// Token: 0x04006C44 RID: 27716
	public Transform renderRoot;

	// Token: 0x04006C45 RID: 27717
	public int[] MaxCount;

	// Token: 0x04006C46 RID: 27718
	private List<FlyingObject>[] freeList;

	// Token: 0x04006C47 RID: 27719
	private AssetBundle[] bundleList;

	// Token: 0x04006C48 RID: 27720
	public List<FlyingObject> workingList;

	// Token: 0x04006C49 RID: 27721
	public StringBuilder StringInstance;

	// Token: 0x04006C4A RID: 27722
	public WarParticleManager particleMgr;
}
