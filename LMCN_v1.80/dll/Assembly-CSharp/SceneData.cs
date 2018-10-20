using System;
using UnityEngine;

// Token: 0x020006DF RID: 1759
[Serializable]
public class SceneData : ScriptableObject
{
	// Token: 0x060021A4 RID: 8612 RVA: 0x00401B70 File Offset: 0x003FFD70
	public void init()
	{
		this.mfog = RenderSettings.fog;
		this.mfogcolor = RenderSettings.fogColor;
		this.mfogDensity = RenderSettings.fogDensity;
		this.mfogMode = (byte)RenderSettings.fogMode;
		this.mfogStartDistance = RenderSettings.fogStartDistance;
		this.mfogEndDistance = RenderSettings.fogEndDistance;
		this.mambientLight = RenderSettings.ambientLight;
		if (LightmapSettings.lightmaps.Length > 0)
		{
			this.Lightmap = new Texture2D[LightmapSettings.lightmaps.Length];
			for (int i = 0; i < this.Lightmap.Length; i++)
			{
				this.Lightmap[i] = LightmapSettings.lightmaps[i].lightmapFar;
			}
		}
		this.Lightprobe = LightmapSettings.lightProbes;
		this.cameraBackgroundColor = Camera.main.backgroundColor;
	}

	// Token: 0x04006A35 RID: 27189
	public bool mfog;

	// Token: 0x04006A36 RID: 27190
	public Color mfogcolor;

	// Token: 0x04006A37 RID: 27191
	public Color mambientLight;

	// Token: 0x04006A38 RID: 27192
	public float mfogDensity;

	// Token: 0x04006A39 RID: 27193
	public byte mfogMode;

	// Token: 0x04006A3A RID: 27194
	public float mfogStartDistance;

	// Token: 0x04006A3B RID: 27195
	public float mfogEndDistance;

	// Token: 0x04006A3C RID: 27196
	public Texture2D[] Lightmap;

	// Token: 0x04006A3D RID: 27197
	public LightProbes Lightprobe;

	// Token: 0x04006A3E RID: 27198
	public Color cameraBackgroundColor;
}
