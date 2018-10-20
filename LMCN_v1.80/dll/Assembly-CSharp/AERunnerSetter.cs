using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020007C1 RID: 1985
internal class AERunnerSetter
{
	// Token: 0x0600290B RID: 10507 RVA: 0x0044C2D4 File Offset: 0x0044A4D4
	public static AERunner SetFunctionTick(RectTransform RTF, Image[] Image)
	{
		AERunner aerunner = new AERunner(RTF);
		aerunner.CenterPivot = Vector2.zero;
		aerunner.ActiveKind = new AERunner.AEType[]
		{
			AERunner.AEType.scale,
			AERunner.AEType.alpha
		};
		aerunner.AlphaApplyImages = Image;
		aerunner.ScaleValue = new Vector2[]
		{
			new Vector2(4.6f, 4.6f),
			new Vector2(4f, 4f),
			new Vector2(0.9f, 0.9f),
			new Vector2(1f, 1f)
		};
		aerunner.ScaleKey = new float[]
		{
			0f,
			0.166666672f,
			0.266666681f,
			0.333333343f
		};
		aerunner.AlphaValue = new float[]
		{
			0f,
			100f,
			100f
		};
		aerunner.AlphaKey = new float[]
		{
			0f,
			0.2f,
			0.333333343f
		};
		aerunner.CheckLastKey();
		return aerunner;
	}

	// Token: 0x0600290C RID: 10508 RVA: 0x0044C3EC File Offset: 0x0044A5EC
	public static AERunner SetFunctionDisappear(RectTransform RTF, Image[] Image)
	{
		AERunner aerunner = new AERunner(RTF);
		aerunner.CenterPivot = Vector2.zero;
		aerunner.ActiveKind = new AERunner.AEType[]
		{
			AERunner.AEType.scale,
			AERunner.AEType.alpha
		};
		aerunner.AlphaApplyImages = Image;
		aerunner.ScaleValue = new Vector2[]
		{
			new Vector2(1f, 1f),
			new Vector2(1.2f, 1.2f),
			new Vector2(0f, 0f)
		};
		aerunner.ScaleKey = new float[]
		{
			0.333333343f,
			0.6f,
			0.766666651f
		};
		AERunner aerunner2 = aerunner;
		float[] array = new float[2];
		array[0] = 100f;
		aerunner2.AlphaValue = array;
		aerunner.AlphaKey = new float[]
		{
			0.6333333f,
			0.9f
		};
		aerunner.CheckLastKey();
		return aerunner;
	}

	// Token: 0x0600290D RID: 10509 RVA: 0x0044C4E0 File Offset: 0x0044A6E0
	public static AERunner SetFunctionAppear(RectTransform RTF, Image[] Image)
	{
		AERunner aerunner = new AERunner(RTF);
		aerunner.CenterPivot = Vector2.zero;
		aerunner.ActiveKind = new AERunner.AEType[]
		{
			AERunner.AEType.scale,
			AERunner.AEType.alpha
		};
		aerunner.AlphaApplyImages = Image;
		aerunner.ScaleValue = new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2(1.2f, 1.2f),
			new Vector2(1f, 1f)
		};
		aerunner.ScaleKey = new float[]
		{
			0.766666651f,
			1.0333333f,
			1.3f
		};
		aerunner.AlphaValue = new float[]
		{
			0f,
			100f
		};
		aerunner.AlphaKey = new float[]
		{
			0.766666651f,
			1.26666665f
		};
		aerunner.CheckLastKey();
		return aerunner;
	}

	// Token: 0x0600290E RID: 10510 RVA: 0x0044C5D4 File Offset: 0x0044A7D4
	public static AERunner SetFunctionFirst(RectTransform RTF, Image[] Image)
	{
		AERunner aerunner = new AERunner(RTF);
		aerunner.CenterPivot = Vector2.zero;
		aerunner.ActiveKind = new AERunner.AEType[]
		{
			AERunner.AEType.scale,
			AERunner.AEType.alpha
		};
		aerunner.AlphaApplyImages = Image;
		aerunner.ScaleValue = new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2(1.2f, 1.2f),
			new Vector2(1f, 1f)
		};
		aerunner.ScaleKey = new float[]
		{
			0f,
			0.266666681f,
			0.533333361f
		};
		aerunner.AlphaValue = new float[]
		{
			0f,
			100f
		};
		aerunner.AlphaKey = new float[]
		{
			0f,
			0.5f
		};
		aerunner.CheckLastKey();
		return aerunner;
	}
}
