using System;
using UnityEngine;

// Token: 0x020007B2 RID: 1970
[Serializable]
public class RenderSettingsData : ScriptableObject
{
	// Token: 0x06002869 RID: 10345 RVA: 0x00446C4C File Offset: 0x00444E4C
	public void init()
	{
		this.mfog = RenderSettings.fog;
		this.mfogcolor = RenderSettings.fogColor;
		this.mfogDensity = RenderSettings.fogDensity;
		this.mfogMode = (byte)RenderSettings.fogMode;
		this.mfogStartDistance = RenderSettings.fogStartDistance;
		this.mfogEndDistance = RenderSettings.fogEndDistance;
		this.mambientLight = RenderSettings.ambientLight;
	}

	// Token: 0x040072B7 RID: 29367
	public bool mfog;

	// Token: 0x040072B8 RID: 29368
	public Color mfogcolor;

	// Token: 0x040072B9 RID: 29369
	public Color mambientLight;

	// Token: 0x040072BA RID: 29370
	public float mfogDensity;

	// Token: 0x040072BB RID: 29371
	public byte mfogMode;

	// Token: 0x040072BC RID: 29372
	public float mfogStartDistance;

	// Token: 0x040072BD RID: 29373
	public float mfogEndDistance;
}
