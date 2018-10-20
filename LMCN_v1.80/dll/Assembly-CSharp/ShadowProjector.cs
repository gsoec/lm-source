using System;
using UnityEngine;

// Token: 0x02000047 RID: 71
[AddComponentMenu("Fast Shadow Projector/Shadow Projector")]
public class ShadowProjector : MonoBehaviour
{
	// Token: 0x17000011 RID: 17
	// (get) Token: 0x060001CA RID: 458 RVA: 0x0001ACA8 File Offset: 0x00018EA8
	// (set) Token: 0x060001C9 RID: 457 RVA: 0x0001AC88 File Offset: 0x00018E88
	public Vector3 GlobalProjectionDir
	{
		get
		{
			return this._GlobalProjectionDir;
		}
		set
		{
			this._GlobalProjectionDir = value;
			if (GlobalProjectorManager.Exists())
			{
				GlobalProjectorManager.GlobalProjectionDir = this._GlobalProjectionDir;
			}
		}
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x060001CC RID: 460 RVA: 0x0001ACD0 File Offset: 0x00018ED0
	// (set) Token: 0x060001CB RID: 459 RVA: 0x0001ACB0 File Offset: 0x00018EB0
	public int GlobalShadowResolution
	{
		get
		{
			return this._GlobalShadowResolution;
		}
		set
		{
			this._GlobalShadowResolution = value;
			if (GlobalProjectorManager.Exists())
			{
				GlobalProjectorManager.GlobalShadowResolution = this._GlobalShadowResolution;
			}
		}
	}

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x060001CE RID: 462 RVA: 0x0001ACF8 File Offset: 0x00018EF8
	// (set) Token: 0x060001CD RID: 461 RVA: 0x0001ACD8 File Offset: 0x00018ED8
	public GlobalProjectorManager.ProjectionCulling GlobalShadowCullingMode
	{
		get
		{
			return this._GlobalShadowCullingMode;
		}
		set
		{
			this._GlobalShadowCullingMode = value;
			if (GlobalProjectorManager.Exists())
			{
				GlobalProjectorManager.GlobalShadowCullingMode = this._GlobalShadowCullingMode;
			}
		}
	}

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x060001D0 RID: 464 RVA: 0x0001AD38 File Offset: 0x00018F38
	// (set) Token: 0x060001CF RID: 463 RVA: 0x0001AD00 File Offset: 0x00018F00
	public float ShadowSize
	{
		get
		{
			return this._ShadowSize;
		}
		set
		{
			if (this._ShadowSize != value)
			{
				this._ShadowSize = value;
				if (this._ShadowDummyMesh != null)
				{
					this.OnShadowSizeChanged();
				}
			}
		}
	}

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x060001D2 RID: 466 RVA: 0x0001AD74 File Offset: 0x00018F74
	// (set) Token: 0x060001D1 RID: 465 RVA: 0x0001AD40 File Offset: 0x00018F40
	public Color ShadowColor
	{
		get
		{
			return this._ShadowColor;
		}
		set
		{
			if (this._ShadowColor != value)
			{
				this._ShadowColor = value;
				if (this._ShadowDummyMesh != null)
				{
					this.OnShadowColorChanged();
				}
			}
		}
	}

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x060001D4 RID: 468 RVA: 0x0001ADB4 File Offset: 0x00018FB4
	// (set) Token: 0x060001D3 RID: 467 RVA: 0x0001AD7C File Offset: 0x00018F7C
	public float ShadowOpacity
	{
		get
		{
			return this._ShadowOpacity;
		}
		set
		{
			if (this._ShadowOpacity != value)
			{
				this._ShadowOpacity = value;
				if (this._ShadowDummyMesh != null)
				{
					this.OnShadowColorChanged();
				}
			}
		}
	}

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x060001D6 RID: 470 RVA: 0x0001ADE8 File Offset: 0x00018FE8
	// (set) Token: 0x060001D5 RID: 469 RVA: 0x0001ADBC File Offset: 0x00018FBC
	public Vector3 ShadowLocalOffset
	{
		get
		{
			return this._ShadowLocalOffset;
		}
		set
		{
			this._ShadowLocalOffset = value;
			if (this._ShadowDummy != null)
			{
				this._ShadowDummy._ShadowLocalOffset = this._ShadowLocalOffset;
			}
		}
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x060001D8 RID: 472 RVA: 0x0001AE1C File Offset: 0x0001901C
	// (set) Token: 0x060001D7 RID: 471 RVA: 0x0001ADF0 File Offset: 0x00018FF0
	public float RotationAngleOffset
	{
		get
		{
			return this._RotationAngleOffset;
		}
		set
		{
			this._RotationAngleOffset = value;
			if (this._ShadowDummy != null)
			{
				this._ShadowDummy._RotationAngleOffset = this._RotationAngleOffset;
			}
		}
	}

	// Token: 0x17000019 RID: 25
	// (get) Token: 0x060001DA RID: 474 RVA: 0x0001AE44 File Offset: 0x00019044
	// (set) Token: 0x060001D9 RID: 473 RVA: 0x0001AE24 File Offset: 0x00019024
	public Rect UVRect
	{
		get
		{
			return this._UVRect;
		}
		set
		{
			this._UVRect = value;
			if (this._ShadowDummy != null)
			{
				this.OnUVRectChanged();
			}
		}
	}

	// Token: 0x060001DB RID: 475 RVA: 0x0001AE4C File Offset: 0x0001904C
	private void Awake()
	{
		this._ShadowDummyMesh = ShadowProjector.MeshGen.CreatePlane(new Vector3(0f, 20f, 0f), new Vector3(20f, 0f, 0f), this._UVRect, new Color(this._ShadowColor.r, this._ShadowColor.g, this._ShadowColor.b, this._ShadowOpacity));
		Transform transform = base.transform;
		this._ShadowDummy = new GameObject("shadowDummy").AddComponent<ProjectorShadowDummy>();
		this._ShadowDummy.transform.parent = transform;
		this._ShadowDummy.transform.localPosition = new Vector3(0f, 0f, 0f);
		this._ShadowDummy.gameObject.layer = LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer);
		this._ShadowDummy._ShadowLocalOffset = this._ShadowLocalOffset;
		this._ShadowDummy._RotationAngleOffset = this._RotationAngleOffset;
		this.OnShadowSizeChanged();
		this._Renderer = this._ShadowDummy.gameObject.AddComponent<MeshRenderer>();
		this._Renderer.receiveShadows = false;
		this._Renderer.castShadows = false;
		this._Renderer.material = this._Material;
		this._MeshFilter = this._ShadowDummy.gameObject.AddComponent<MeshFilter>();
		this._MeshFilter.mesh = this._ShadowDummyMesh;
	}

	// Token: 0x060001DC RID: 476 RVA: 0x0001AFB8 File Offset: 0x000191B8
	private void Start()
	{
		GlobalProjectorManager.Get().AddProjector(this);
	}

	// Token: 0x060001DD RID: 477 RVA: 0x0001AFC8 File Offset: 0x000191C8
	private void OnEnable()
	{
		GlobalProjectorManager.Get().AddProjector(this);
	}

	// Token: 0x060001DE RID: 478 RVA: 0x0001AFD8 File Offset: 0x000191D8
	private void OnDisable()
	{
		if (GlobalProjectorManager.Exists())
		{
			GlobalProjectorManager.Get().RemoveProjector(this);
		}
	}

	// Token: 0x060001DF RID: 479 RVA: 0x0001AFF0 File Offset: 0x000191F0
	private void OnDestroy()
	{
		if (GlobalProjectorManager.Exists())
		{
			GlobalProjectorManager.Get().RemoveProjector(this);
		}
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x0001B008 File Offset: 0x00019208
	public Bounds GetBounds()
	{
		return this._Renderer.bounds;
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x0001B018 File Offset: 0x00019218
	public bool IsVisible()
	{
		return this._Renderer.isVisible;
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x0001B028 File Offset: 0x00019228
	public void SetVisible(bool visible)
	{
		this._Renderer.enabled = visible;
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x0001B038 File Offset: 0x00019238
	public void OnPreRender()
	{
		if (this._ShadowDummy != null)
		{
			this._ShadowDummy.OnPreRender();
		}
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x0001B058 File Offset: 0x00019258
	public Matrix4x4 ShadowDummyLocalToWorldMatrix()
	{
		return this._ShadowDummy.transform.localToWorldMatrix;
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x0001B06C File Offset: 0x0001926C
	public float GetShadowWorldSize()
	{
		return this.ShadowSize * (this.ShadowDummyLocalToWorldMatrix() * new Vector3(20f, 0f, 0f)).magnitude;
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x0001B0AC File Offset: 0x000192AC
	public Vector3 GetShadowPos()
	{
		return this._ShadowDummy.transform.position;
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x0001B0C0 File Offset: 0x000192C0
	private void OnShadowSizeChanged()
	{
		this._ShadowDummy.transform.localScale = new Vector3(this._ShadowSize, this._ShadowSize, this._ShadowSize);
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x0001B0EC File Offset: 0x000192EC
	private void OnUVRectChanged()
	{
		this.RebuildMesh();
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x0001B0F4 File Offset: 0x000192F4
	public void OnShadowColorChanged()
	{
		Color color = new Color(this._ShadowColor.r, this._ShadowColor.g, this._ShadowColor.b, this._ShadowOpacity);
		this._ShadowDummyMesh.colors = new Color[]
		{
			color,
			color,
			color,
			color
		};
	}

	// Token: 0x060001EA RID: 490 RVA: 0x0001B174 File Offset: 0x00019374
	private void RebuildMesh()
	{
		this._ShadowDummyMesh = ShadowProjector.MeshGen.CreatePlane(new Vector3(0f, 20f, 0f), new Vector3(20f, 0f, 0f), this._UVRect, new Color(this._ShadowColor.r, this._ShadowColor.g, this._ShadowColor.b, this._ShadowOpacity));
		this._MeshFilter.mesh = this._ShadowDummyMesh;
	}

	// Token: 0x060001EB RID: 491 RVA: 0x0001B1F8 File Offset: 0x000193F8
	public void SetShadowProjectorMaterial(Material in_Material)
	{
		this._Material = in_Material;
		if (this._Renderer != null)
		{
			this._Renderer.material = this._Material;
		}
	}

	// Token: 0x040003D9 RID: 985
	[SerializeField]
	protected Vector3 _GlobalProjectionDir = new Vector3(0f, -1f, 0f);

	// Token: 0x040003DA RID: 986
	[SerializeField]
	protected int _GlobalShadowResolution = 1;

	// Token: 0x040003DB RID: 987
	[SerializeField]
	protected GlobalProjectorManager.ProjectionCulling _GlobalShadowCullingMode;

	// Token: 0x040003DC RID: 988
	[SerializeField]
	private float _ShadowSize = 1f;

	// Token: 0x040003DD RID: 989
	[SerializeField]
	private Color _ShadowColor = new Color(1f, 1f, 1f);

	// Token: 0x040003DE RID: 990
	[SerializeField]
	private float _ShadowOpacity = 1f;

	// Token: 0x040003DF RID: 991
	public Material _Material;

	// Token: 0x040003E0 RID: 992
	[SerializeField]
	private Vector3 _ShadowLocalOffset;

	// Token: 0x040003E1 RID: 993
	[SerializeField]
	private float _RotationAngleOffset;

	// Token: 0x040003E2 RID: 994
	[SerializeField]
	private Rect _UVRect = new Rect(0f, 0f, 1f, 1f);

	// Token: 0x040003E3 RID: 995
	private MeshRenderer _Renderer;

	// Token: 0x040003E4 RID: 996
	private MeshFilter _MeshFilter;

	// Token: 0x040003E5 RID: 997
	private Mesh _ShadowDummyMesh;

	// Token: 0x040003E6 RID: 998
	private ProjectorShadowDummy _ShadowDummy;

	// Token: 0x02000048 RID: 72
	private static class MeshGen
	{
		// Token: 0x060001EC RID: 492 RVA: 0x0001B224 File Offset: 0x00019424
		public static Mesh CreatePlane(Vector3 up, Vector3 right, Rect uvRect, Color color)
		{
			Mesh mesh = new Mesh();
			Vector3[] vertices = new Vector3[]
			{
				up * 0.5f - right * 0.5f,
				up * 0.5f + right * 0.5f,
				-up * 0.5f - right * 0.5f,
				-up * 0.5f + right * 0.5f
			};
			Vector2[] uv = new Vector2[]
			{
				new Vector2(uvRect.x, uvRect.y + uvRect.height),
				new Vector2(uvRect.x + uvRect.width, uvRect.y + uvRect.height),
				new Vector2(uvRect.x, uvRect.y),
				new Vector2(uvRect.x + uvRect.width, uvRect.y)
			};
			Color[] colors = new Color[]
			{
				color,
				color,
				color,
				color
			};
			int[] triangles = new int[]
			{
				0,
				1,
				3,
				0,
				3,
				2
			};
			mesh.vertices = vertices;
			mesh.uv = uv;
			mesh.colors = colors;
			mesh.SetTriangles(triangles, 0);
			return mesh;
		}
	}
}
