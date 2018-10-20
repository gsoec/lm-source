using System;
using UnityEngine;

// Token: 0x02000045 RID: 69
public class ProjectorEyeTexture
{
	// Token: 0x060001C0 RID: 448 RVA: 0x0001AA38 File Offset: 0x00018C38
	public ProjectorEyeTexture(Camera camera, int size)
	{
		this._Camera = camera;
		this._RenderTexture = null;
		this._RenderTextureDummy = null;
		if (this.RenderTextureSupported())
		{
			if (this._RenderTexture != null)
			{
				this._RenderTexture.Release();
				this._RenderTexture = null;
			}
			this._RenderTexture = new RenderTexture(size, size, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
			this._RenderTexture.Create();
			this._RenderTexture.anisoLevel = 0;
			this._RenderTexture.filterMode = FilterMode.Bilinear;
			this._RenderTexture.useMipMap = false;
			camera.targetTexture = this._RenderTexture;
		}
		else
		{
			if (this._RenderTextureDummy != null)
			{
				this._RenderTextureDummy = null;
			}
			this._RenderTextureDummy = new Texture2D((int)this._Camera.pixelWidth, (int)this._Camera.pixelHeight, TextureFormat.ARGB32, false, true);
			this._RenderTextureDummy.filterMode = FilterMode.Bilinear;
			this._RenderTextureDummy.wrapMode = TextureWrapMode.Clamp;
		}
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x0001AB38 File Offset: 0x00018D38
	public Texture GetTexture()
	{
		if (this.RenderTextureSupported())
		{
			return this._RenderTexture;
		}
		return this._RenderTextureDummy;
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x0001AB54 File Offset: 0x00018D54
	public RenderTexture GetRenderTexture()
	{
		return this._RenderTexture;
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x0001AB5C File Offset: 0x00018D5C
	public void GrabScreenIfNeeded()
	{
		if (!this.RenderTextureSupported())
		{
			this._RenderTextureDummy.ReadPixels(new Rect(0f, 0f, (float)((int)this._Camera.pixelWidth), (float)((int)this._Camera.pixelHeight)), 0, 0, false);
			this._RenderTextureDummy.Apply();
		}
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x0001ABB8 File Offset: 0x00018DB8
	private bool RenderTextureSupported()
	{
		return SystemInfo.supportsRenderTextures;
	}

	// Token: 0x040003D1 RID: 977
	private RenderTexture _RenderTexture;

	// Token: 0x040003D2 RID: 978
	private Texture2D _RenderTextureDummy;

	// Token: 0x040003D3 RID: 979
	private Camera _Camera;
}
