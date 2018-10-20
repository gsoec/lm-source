using System;
using UnityEngine;

// Token: 0x02000769 RID: 1897
public class LightmapManager
{
	// Token: 0x060024C9 RID: 9417 RVA: 0x00423C40 File Offset: 0x00421E40
	private LightmapManager()
	{
		this.twinkleRender = null;
		this.twinkleCurTime = 0f;
		this.InitialCustomLightmap();
	}

	// Token: 0x170000F1 RID: 241
	// (get) Token: 0x060024CB RID: 9419 RVA: 0x00423C94 File Offset: 0x00421E94
	public static LightmapManager Instance
	{
		get
		{
			if (LightmapManager.instance == null)
			{
				LightmapManager.instance = new LightmapManager();
			}
			return LightmapManager.instance;
		}
	}

	// Token: 0x060024CC RID: 9420 RVA: 0x00423CB0 File Offset: 0x00421EB0
	public void InitialCustomLightmap()
	{
		ushort num = 9;
		this.LightmapDataArr = new LightmapData[(int)num];
		Color[] array = new Color[(int)num];
		Color color = new Color(0.175f, 0.175f, 0.175f);
		Color color2 = new Color(0.88f, 0.88f, 0.88f);
		Color color3 = new Color(0.045f, 0.045f, 0.045f);
		Color color4 = new Color(0.325f, 0.325f, 0.325f);
		Color color5 = BattleController.StateSkin[0];
		Color color6 = BattleController.StateSkin[1];
		Color color7 = BattleController.StateSkin[2];
		Color color8 = BattleController.StateSkin[3];
		array[0] = color;
		array[1] = color2;
		array[2] = color2;
		array[3] = color3;
		array[4] = color4;
		array[5] = color5;
		array[6] = color6;
		array[7] = color7;
		array[8] = color8;
		for (ushort num2 = 0; num2 < num; num2 += 1)
		{
			LightmapData lightmapData = new LightmapData();
			Texture2D texture2D = new Texture2D(1, 1);
			for (int i = 0; i < texture2D.width; i++)
			{
				for (int j = 0; j < texture2D.height; j++)
				{
					texture2D.SetPixel(i, j, array[(int)num2]);
				}
			}
			texture2D.Apply();
			lightmapData.lightmapFar = texture2D;
			this.LightmapDataArr[(int)num2] = lightmapData;
		}
	}

	// Token: 0x060024CD RID: 9421 RVA: 0x00423E7C File Offset: 0x0042207C
	public byte GetCustomLightmapNum()
	{
		return 9;
	}

	// Token: 0x060024CE RID: 9422 RVA: 0x00423E80 File Offset: 0x00422080
	public void SetTwinkle(Renderer render, bool bTwinkle, float HalfTotalTime = 0.4f)
	{
		if (bTwinkle)
		{
			if (this.twinkleRender != null)
			{
				this.SetTwinkle(render, false, 0.4f);
			}
			this.twinkleHalfTotalTime = HalfTotalTime;
			this.twinkleRender = render;
			this.twinkleLightIndex = render.lightmapIndex;
			render.lightmapIndex = this.SceneLightmapSize + 3;
		}
		else if (this.twinkleRender != null)
		{
			this.twinkleRender.lightmapIndex = this.twinkleLightIndex;
			this.twinkleRender = null;
		}
	}

	// Token: 0x060024CF RID: 9423 RVA: 0x00423F08 File Offset: 0x00422108
	public void SetRenderIndex(Renderer render, Lightmap_Enum State)
	{
		render.lightmapIndex = (int)(State + this.SceneLightmapSize);
	}

	// Token: 0x060024D0 RID: 9424 RVA: 0x00423F18 File Offset: 0x00422118
	public void UpdateCurLightmap(LightmapData[] lightmapData)
	{
		this.SceneLightmapSize = lightmapData.Length - (int)this.GetCustomLightmapNum();
		this.LightmapDataArr.CopyTo(lightmapData, this.SceneLightmapSize);
	}

	// Token: 0x060024D1 RID: 9425 RVA: 0x00423F48 File Offset: 0x00422148
	public void Update()
	{
		this.UpdateTwinkle();
	}

	// Token: 0x060024D2 RID: 9426 RVA: 0x00423F50 File Offset: 0x00422150
	private void UpdateTwinkle()
	{
		if (this.twinkleRender == null)
		{
			return;
		}
		Texture2D lightmapFar = LightmapSettings.lightmaps[this.SceneLightmapSize + 3].lightmapFar;
		Color color = lightmapFar.GetPixel(1, 1);
		if (this.twinkleCurTime <= this.twinkleHalfTotalTime && !this.Reverse)
		{
			color = Color.Lerp(Color.white, this.MaskMaxColor, this.twinkleCurTime / this.twinkleHalfTotalTime);
		}
		else
		{
			this.Reverse = true;
			color = Color.Lerp(Color.white, this.MaskMaxColor, 1f - (this.twinkleCurTime - this.twinkleHalfTotalTime) / this.twinkleHalfTotalTime);
		}
		lightmapFar.SetPixel(1, 1, color);
		lightmapFar.Apply();
		this.twinkleCurTime += Time.deltaTime;
		if (this.twinkleCurTime > this.twinkleHalfTotalTime * 2f)
		{
			this.twinkleCurTime = 0f;
			this.Reverse = false;
		}
	}

	// Token: 0x060024D3 RID: 9427 RVA: 0x00424048 File Offset: 0x00422248
	public void UpdateSceneAmbient()
	{
		Texture2D lightmapFar = LightmapSettings.lightmaps[this.SceneLightmapSize + 2].lightmapFar;
		lightmapFar.SetPixel(1, 1, RenderSettings.ambientLight);
		lightmapFar.Apply();
		Debug.Log("Update Scene Ambient To " + RenderSettings.ambientLight.ToString());
	}

	// Token: 0x060024D4 RID: 9428 RVA: 0x00424098 File Offset: 0x00422298
	public int GetLightmapIndex(Lightmap_Enum kind)
	{
		return (int)(this.SceneLightmapSize + kind);
	}

	// Token: 0x060024D5 RID: 9429 RVA: 0x004240A4 File Offset: 0x004222A4
	public Texture2D GetLightmapTexture(Lightmap_Enum kind)
	{
		return LightmapSettings.lightmaps[(int)(this.SceneLightmapSize + kind)].lightmapFar;
	}

	// Token: 0x04006F2D RID: 28461
	private LightmapData[] LightmapDataArr;

	// Token: 0x04006F2E RID: 28462
	private Renderer twinkleRender;

	// Token: 0x04006F2F RID: 28463
	public int SceneLightmapSize;

	// Token: 0x04006F30 RID: 28464
	private int twinkleLightIndex;

	// Token: 0x04006F31 RID: 28465
	private float twinkleHalfTotalTime = 0.4f;

	// Token: 0x04006F32 RID: 28466
	private float twinkleCurTime;

	// Token: 0x04006F33 RID: 28467
	private static LightmapManager instance;

	// Token: 0x04006F34 RID: 28468
	private bool Reverse;

	// Token: 0x04006F35 RID: 28469
	private Color MaskMaxColor = new Color(0.65f, 0.65f, 0.65f);
}
