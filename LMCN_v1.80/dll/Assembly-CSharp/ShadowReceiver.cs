using System;
using UnityEngine;

// Token: 0x02000049 RID: 73
[AddComponentMenu("Fast Shadow Projector/Shadow Receiver")]
public class ShadowReceiver : MonoBehaviour
{
	// Token: 0x060001EE RID: 494 RVA: 0x0001B3FC File Offset: 0x000195FC
	private void Awake()
	{
		this._meshFilter = base.GetComponent<MeshFilter>();
		this._meshRenderer = base.GetComponent<MeshRenderer>();
		this._meshCopy = null;
		if (this._meshFilter != null)
		{
			this._mesh = this._meshFilter.mesh;
		}
	}

	// Token: 0x060001EF RID: 495 RVA: 0x0001B44C File Offset: 0x0001964C
	private void Start()
	{
		this.AddReceiver();
		if (this._meshRenderer != null && this._meshRenderer.isPartOfStaticBatch && this._mesh != null)
		{
			this.CopyMesh();
		}
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x0001B498 File Offset: 0x00019698
	private void CopyMesh()
	{
		this._meshCopy = new Mesh();
		this._meshCopy.vertices = this._mesh.vertices;
		this._meshCopy.normals = this._mesh.normals;
		this._meshCopy.uv = this._mesh.uv;
		this._meshCopy.triangles = this._mesh.triangles;
		this._meshCopy.tangents = this._mesh.tangents;
		this._meshCopy.colors = this._mesh.colors;
		this._meshCopy.colors32 = this._mesh.colors32;
		this._meshCopy.uv1 = this._mesh.uv1;
		this._meshCopy.uv2 = this._mesh.uv2;
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x0001B578 File Offset: 0x00019778
	public Mesh GetMesh()
	{
		if (this._meshCopy != null)
		{
			return this._meshCopy;
		}
		return this._mesh;
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x0001B598 File Offset: 0x00019798
	private void OnEnable()
	{
		this.AddReceiver();
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x0001B5A0 File Offset: 0x000197A0
	private void OnDisable()
	{
		this.RemoveReceiver();
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x0001B5A8 File Offset: 0x000197A8
	private void OnDestroy()
	{
		this.RemoveReceiver();
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x0001B5B0 File Offset: 0x000197B0
	private void AddReceiver()
	{
		if (this._meshFilter != null)
		{
			GlobalProjectorManager.Get().AddReceiver(this);
		}
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x0001B5D0 File Offset: 0x000197D0
	private void RemoveReceiver()
	{
		if (GlobalProjectorManager.Exists() && this._meshFilter != null)
		{
			GlobalProjectorManager.Get().RemoveReceiver(this);
		}
	}

	// Token: 0x040003E7 RID: 999
	private MeshFilter _meshFilter;

	// Token: 0x040003E8 RID: 1000
	private Mesh _mesh;

	// Token: 0x040003E9 RID: 1001
	private Mesh _meshCopy;

	// Token: 0x040003EA RID: 1002
	private MeshRenderer _meshRenderer;
}
