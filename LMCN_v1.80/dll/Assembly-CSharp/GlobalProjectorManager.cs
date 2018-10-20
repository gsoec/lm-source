using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000043 RID: 67
public class GlobalProjectorManager : MonoBehaviour
{
	// Token: 0x1700000E RID: 14
	// (get) Token: 0x060001A8 RID: 424 RVA: 0x0001A0D0 File Offset: 0x000182D0
	// (set) Token: 0x060001A7 RID: 423 RVA: 0x0001A098 File Offset: 0x00018298
	public static Vector3 GlobalProjectionDir
	{
		get
		{
			return GlobalProjectorManager._Instance._GlobalProjectionDir;
		}
		set
		{
			if (GlobalProjectorManager._Instance._GlobalProjectionDir != value)
			{
				GlobalProjectorManager._Instance._GlobalProjectionDir = value;
				GlobalProjectorManager._Instance.OnProjectionDirChange();
			}
		}
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x060001AA RID: 426 RVA: 0x0001A104 File Offset: 0x00018304
	// (set) Token: 0x060001A9 RID: 425 RVA: 0x0001A0DC File Offset: 0x000182DC
	public static int GlobalShadowResolution
	{
		get
		{
			return GlobalProjectorManager._Instance._GlobalShadowResolution;
		}
		set
		{
			if (GlobalProjectorManager._Instance._GlobalShadowResolution != value)
			{
				GlobalProjectorManager._Instance._GlobalShadowResolution = value;
				GlobalProjectorManager._Instance.OnShadowResolutionChange();
			}
		}
	}

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x060001AC RID: 428 RVA: 0x0001A120 File Offset: 0x00018320
	// (set) Token: 0x060001AB RID: 427 RVA: 0x0001A110 File Offset: 0x00018310
	public static GlobalProjectorManager.ProjectionCulling GlobalShadowCullingMode
	{
		get
		{
			return GlobalProjectorManager._Instance._GlobalShadowCullingMode;
		}
		set
		{
			GlobalProjectorManager._Instance._GlobalShadowCullingMode = value;
		}
	}

	// Token: 0x060001AD RID: 429 RVA: 0x0001A12C File Offset: 0x0001832C
	public static GlobalProjectorManager Get()
	{
		if (GlobalProjectorManager._Instance == null)
		{
			GlobalProjectorManager._Instance = new GameObject("_GlobalProjectorManager").AddComponent<GlobalProjectorManager>();
			GlobalProjectorManager._Instance.Initialize();
		}
		return GlobalProjectorManager._Instance;
	}

	// Token: 0x060001AE RID: 430 RVA: 0x0001A164 File Offset: 0x00018364
	private void Initialize()
	{
		base.gameObject.layer = LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer);
		this._ProjectorMaterial = new Material(GlobalProjectorManager._GlobalProjectorShader);
		this._ProjectorCamera = base.gameObject.AddComponent<Camera>();
		this._ProjectorCamera.clearFlags = CameraClearFlags.Color;
		this._ProjectorCamera.backgroundColor = new Color32(0, 0, 0, 0);
		this._ProjectorCamera.cullingMask = 1 << LayerMask.NameToLayer(GlobalProjectorManager.GlobalProjectorLayer);
		this._ProjectorCamera.orthographic = true;
		this._ProjectorCamera.nearClipPlane = -10000f;
		this._ProjectorCamera.farClipPlane = 10000f;
		this._ProjectorCamera.aspect = 1f;
		this._ProjectorCamera.depth = float.MinValue;
		this.CreateProjectorEyeTexture();
		this._BiasMatrix = default(Matrix4x4);
		this._BiasMatrix.SetRow(0, new Vector4(0.5f, 0f, 0f, 0.5f));
		this._BiasMatrix.SetRow(1, new Vector4(0f, 0.5f, 0f, 0.5f));
		this._BiasMatrix.SetRow(2, new Vector4(0f, 0f, 0.5f, 0.5f));
		this._BiasMatrix.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
		this._ProjectorMatrix = default(Matrix4x4);
		this._MBP = new MaterialPropertyBlock();
		this._ShadowProjectors = new List<ShadowProjector>();
		this._ShadowReceivers = new List<ShadowReceiver>();
	}

	// Token: 0x060001AF RID: 431 RVA: 0x0001A30C File Offset: 0x0001850C
	private void Awake()
	{
		this.OnProjectionDirChange();
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x0001A314 File Offset: 0x00018514
	private void Start()
	{
		this.OnProjectionDirChange();
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x0001A31C File Offset: 0x0001851C
	private void OnDestroy()
	{
		GlobalProjectorManager._Instance = null;
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x0001A324 File Offset: 0x00018524
	public static bool Exists()
	{
		return GlobalProjectorManager._Instance != null;
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x0001A334 File Offset: 0x00018534
	public void AddProjector(ShadowProjector projector)
	{
		if (!this._ShadowProjectors.Contains(projector))
		{
			this._ShadowProjectors.Add(projector);
			if (projector.GlobalProjectionDir != this._GlobalProjectionDir)
			{
				GlobalProjectorManager.GlobalProjectionDir = projector.GlobalProjectionDir;
			}
		}
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x0001A380 File Offset: 0x00018580
	public void RemoveProjector(ShadowProjector projector)
	{
		if (this._ShadowProjectors.Contains(projector))
		{
			this._ShadowProjectors.Remove(projector);
		}
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x0001A3A0 File Offset: 0x000185A0
	public void AddReceiver(ShadowReceiver receiver)
	{
		if (!this._ShadowReceivers.Contains(receiver))
		{
			this._ShadowReceivers.Add(receiver);
		}
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x0001A3C0 File Offset: 0x000185C0
	public void RemoveReceiver(ShadowReceiver receiver)
	{
		if (this._ShadowReceivers.Contains(receiver))
		{
			this._ShadowReceivers.Remove(receiver);
		}
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x0001A3E0 File Offset: 0x000185E0
	private void OnProjectionDirChange()
	{
		if (base.camera != null)
		{
			base.camera.transform.rotation = Quaternion.LookRotation(this._GlobalProjectionDir);
		}
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x0001A41C File Offset: 0x0001861C
	private void OnShadowResolutionChange()
	{
		this.CreateProjectorEyeTexture();
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x0001A424 File Offset: 0x00018624
	private void CreateProjectorEyeTexture()
	{
		this._Tex = new ProjectorEyeTexture(this._ProjectorCamera, this._ShadowResolutions[this._GlobalShadowResolution]);
		this._ProjectorMaterial.SetTexture("_ShadowTex", this._Tex.GetTexture());
	}

	// Token: 0x060001BA RID: 442 RVA: 0x0001A460 File Offset: 0x00018660
	private void CalculateShadowBounds()
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		Vector2 vector = new Vector2(float.MaxValue, float.MinValue);
		Vector2 vector2 = new Vector2(float.MaxValue, float.MinValue);
		float num = 10f;
		bool flag = true;
		int num2 = 0;
		int num3 = 0;
		Bounds bounds = default(Bounds);
		int i = 0;
		while (i < this._ShadowProjectors.Count)
		{
			ShadowProjector shadowProjector = this._ShadowProjectors[i];
			GlobalProjectorManager.ProjectionCulling globalShadowCullingMode = this._GlobalShadowCullingMode;
			if (globalShadowCullingMode != GlobalProjectorManager.ProjectionCulling.ProjectorBounds)
			{
				if (globalShadowCullingMode != GlobalProjectorManager.ProjectionCulling.ProjectionVolumeBounds)
				{
					goto IL_D1;
				}
				if (this.IsProjectionVolumeVisible(planes, shadowProjector))
				{
					goto IL_D1;
				}
				num3++;
				shadowProjector.SetVisible(false);
			}
			else
			{
				if (GeometryUtility.TestPlanesAABB(planes, shadowProjector.GetBounds()))
				{
					goto IL_D1;
				}
				num3++;
				shadowProjector.SetVisible(false);
			}
			IL_1C1:
			i++;
			continue;
			IL_D1:
			flag = false;
			shadowProjector.SetVisible(true);
			Vector2 vector3 = base.camera.WorldToViewportPoint(shadowProjector.GetShadowPos());
			if (num2 == 0)
			{
				bounds = new Bounds(shadowProjector.GetShadowPos(), Vector3.zero);
			}
			else
			{
				bounds.Encapsulate(shadowProjector.GetShadowPos());
			}
			if (vector3.x < vector.x)
			{
				vector.x = vector3.x;
			}
			if (vector3.x > vector.y)
			{
				vector.y = vector3.x;
			}
			if (vector3.y < vector2.x)
			{
				vector2.x = vector3.y;
			}
			if (vector3.y > vector2.y)
			{
				vector2.y = vector3.y;
			}
			float shadowWorldSize = shadowProjector.GetShadowWorldSize();
			if (shadowWorldSize > num)
			{
				num = shadowWorldSize;
			}
			num2++;
			goto IL_1C1;
		}
		if (flag)
		{
			return;
		}
		float num4 = base.camera.orthographicSize * 2f;
		float num5 = num / num4;
		Vector3 center = bounds.center;
		base.camera.transform.position = center;
		float num6 = Mathf.Max(vector[1] - vector[0] + num5 * 2f, vector2[1] - vector2[0] + num5 * 2f);
		base.camera.orthographicSize = base.camera.orthographicSize * num6;
	}

	// Token: 0x060001BB RID: 443 RVA: 0x0001A6D8 File Offset: 0x000188D8
	private bool IsProjectionVolumeVisible(Plane[] planes, ShadowProjector projector)
	{
		float num = 1000000f;
		Vector3 center = projector.GetShadowPos() + GlobalProjectorManager.GlobalProjectionDir.normalized * (num * 0.5f);
		Vector3 size = new Vector3(Mathf.Abs(GlobalProjectorManager.GlobalProjectionDir.normalized.x), Mathf.Abs(GlobalProjectorManager.GlobalProjectionDir.normalized.y), Mathf.Abs(GlobalProjectorManager.GlobalProjectionDir.normalized.z)) * num;
		Bounds bounds = new Bounds(center, size);
		float shadowWorldSize = projector.GetShadowWorldSize();
		bounds.Encapsulate(new Bounds(projector.GetShadowPos(), new Vector3(shadowWorldSize, shadowWorldSize, shadowWorldSize)));
		return GeometryUtility.TestPlanesAABB(planes, bounds);
	}

	// Token: 0x060001BC RID: 444 RVA: 0x0001A7A8 File Offset: 0x000189A8
	private void LateUpdate()
	{
		if (this._ShadowProjectors.Count > 0 && this._ShadowReceivers.Count > 0)
		{
			this.CalculateShadowBounds();
			float nearClipPlane = base.camera.nearClipPlane;
			float farClipPlane = base.camera.farClipPlane;
			float orthographicSize = base.camera.orthographicSize;
			float orthographicSize2 = base.camera.orthographicSize;
			this._ProjectorMatrix.SetRow(0, new Vector4(1f / orthographicSize, 0f, 0f, 0f));
			this._ProjectorMatrix.SetRow(1, new Vector4(0f, 1f / orthographicSize2, 0f, 0f));
			this._ProjectorMatrix.SetRow(2, new Vector4(0f, 0f, -2f / (farClipPlane - nearClipPlane), 0f));
			this._ProjectorMatrix.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
			this._ViewMatrix = base.camera.transform.localToWorldMatrix.inverse;
			this._BPV = this._BiasMatrix * this._ProjectorMatrix * this._ViewMatrix;
			this.RenderShadows();
		}
	}

	// Token: 0x060001BD RID: 445 RVA: 0x0001A8F0 File Offset: 0x00018AF0
	private void RenderShadows()
	{
		this._MBP.Clear();
		for (int i = 0; i < this._ShadowReceivers.Count; i++)
		{
			this._ModelMatrix = this._ShadowReceivers[i].transform.localToWorldMatrix;
			this._FinalMatrix = this._BPV * this._ModelMatrix;
			this._MBP.AddMatrix("_GlobalProjector", this._FinalMatrix);
			Graphics.DrawMesh(this._ShadowReceivers[i].GetMesh(), this._ModelMatrix, this._ProjectorMaterial, LayerMask.NameToLayer("Default"), null, 0, this._MBP);
		}
	}

	// Token: 0x060001BE RID: 446 RVA: 0x0001A9A4 File Offset: 0x00018BA4
	private void OnPreCull()
	{
		for (int i = 0; i < this._ShadowProjectors.Count; i++)
		{
			this._ShadowProjectors[i].SetVisible(true);
			this._ShadowProjectors[i].OnPreRender();
		}
	}

	// Token: 0x060001BF RID: 447 RVA: 0x0001A9F0 File Offset: 0x00018BF0
	private void OnPostRender()
	{
		this._Tex.GrabScreenIfNeeded();
		for (int i = 0; i < this._ShadowProjectors.Count; i++)
		{
			this._ShadowProjectors[i].SetVisible(false);
		}
	}

	// Token: 0x040003BA RID: 954
	private static string _GlobalProjectorShader = "Shader \"GlobalProjector/Multiply\" {\nProperties {\n_ShadowTex (\"Projector Texture\", 2D) = \"gray\" { TexGen ObjectLinear }\n}\nSubshader {\nTags { \"RenderType\"=\"Transparent\" \"Queue\"=\"Geometry+1\" }\nPass {\nZWrite Off\nZTest LEqual\nFog { Color (0, 0, 0) }\nAlphaTest Greater 0\nColorMask RGB\nBlend One One\nOffset -1, -1\nSetTexture [_ShadowTex] {\nMatrix [_GlobalProjector]\n}\n}\n}\n}\n";

	// Token: 0x040003BB RID: 955
	private ProjectorEyeTexture _Tex;

	// Token: 0x040003BC RID: 956
	public Material _ProjectorMaterial;

	// Token: 0x040003BD RID: 957
	private Matrix4x4 _ProjectorMatrix;

	// Token: 0x040003BE RID: 958
	private Matrix4x4 _BiasMatrix;

	// Token: 0x040003BF RID: 959
	private Matrix4x4 _ViewMatrix;

	// Token: 0x040003C0 RID: 960
	private Matrix4x4 _BPV;

	// Token: 0x040003C1 RID: 961
	private Matrix4x4 _ModelMatrix;

	// Token: 0x040003C2 RID: 962
	private Matrix4x4 _FinalMatrix;

	// Token: 0x040003C3 RID: 963
	private MaterialPropertyBlock _MBP;

	// Token: 0x040003C4 RID: 964
	private int[] _ShadowResolutions = new int[]
	{
		128,
		256,
		512,
		1024,
		2048
	};

	// Token: 0x040003C5 RID: 965
	public static readonly string GlobalProjectorLayer = "GlobalProjectorLayer";

	// Token: 0x040003C6 RID: 966
	private static GlobalProjectorManager _Instance;

	// Token: 0x040003C7 RID: 967
	private Vector3 _GlobalProjectionDir = new Vector3(0f, -1f, 0f);

	// Token: 0x040003C8 RID: 968
	private int _GlobalShadowResolution = 3;

	// Token: 0x040003C9 RID: 969
	private GlobalProjectorManager.ProjectionCulling _GlobalShadowCullingMode;

	// Token: 0x040003CA RID: 970
	private Camera _ProjectorCamera;

	// Token: 0x040003CB RID: 971
	private List<ShadowProjector> _ShadowProjectors;

	// Token: 0x040003CC RID: 972
	private List<ShadowReceiver> _ShadowReceivers;

	// Token: 0x02000044 RID: 68
	public enum ProjectionCulling
	{
		// Token: 0x040003CE RID: 974
		None,
		// Token: 0x040003CF RID: 975
		ProjectorBounds,
		// Token: 0x040003D0 RID: 976
		ProjectionVolumeBounds
	}
}
