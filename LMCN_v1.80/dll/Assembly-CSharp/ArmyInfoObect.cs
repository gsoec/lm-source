using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004E3 RID: 1251
internal class ArmyInfoObect
{
	// Token: 0x06001907 RID: 6407 RVA: 0x002A1BE0 File Offset: 0x0029FDE0
	public ArmyInfoObect()
	{
		this.m_dataIdx = -1;
		this.m_SliderType = 1;
		this.m_MaxOverload = 0u;
		this.m_MaxOverload = 0u;
		this.m_ResStartTime = 0L;
		this.m_ResTotalCount = 0u;
		this.m_ResRate = 0f;
		this.m_Type = EMarchEventType.EMET_Standby;
		this.bHost = 0;
		this.m_Text1Str = StringManager.Instance.SpawnString(40);
		this.m_Text2Str = StringManager.Instance.SpawnString(40);
		this.m_Slider1TitleStr = StringManager.Instance.SpawnString(40);
		this.m_Slider1TimeStr = StringManager.Instance.SpawnString(40);
		this.m_TempTime = StringManager.Instance.SpawnString(40);
		this.m_IconText = StringManager.Instance.SpawnString(40);
	}

	// Token: 0x04004A13 RID: 18963
	public int m_dataIdx;

	// Token: 0x04004A14 RID: 18964
	public EMarchEventType m_Type;

	// Token: 0x04004A15 RID: 18965
	public POINT_KIND PointKind;

	// Token: 0x04004A16 RID: 18966
	public byte bHost;

	// Token: 0x04004A17 RID: 18967
	public byte m_SliderType;

	// Token: 0x04004A18 RID: 18968
	public Image m_ScrollSliderIcon;

	// Token: 0x04004A19 RID: 18969
	public UIText m_ScrollSliderText1;

	// Token: 0x04004A1A RID: 18970
	public UIText m_ScrollSliderText2;

	// Token: 0x04004A1B RID: 18971
	public Image m_ScrollSlider1Value;

	// Token: 0x04004A1C RID: 18972
	public UIText m_ScrollSlider1Title;

	// Token: 0x04004A1D RID: 18973
	public UIText m_ScrollSlider1Time;

	// Token: 0x04004A1E RID: 18974
	public Image m_ScrollSlider2Value1;

	// Token: 0x04004A1F RID: 18975
	public Image m_ScrollSlider2Value2;

	// Token: 0x04004A20 RID: 18976
	public UIText m_ScrollSlider2Title;

	// Token: 0x04004A21 RID: 18977
	public UIText m_ScrollSlider2Time;

	// Token: 0x04004A22 RID: 18978
	public Image m_ScrollSlider3Value;

	// Token: 0x04004A23 RID: 18979
	public UIText m_ScrollSlider3Title;

	// Token: 0x04004A24 RID: 18980
	public UIText m_ScrollSlider3Time;

	// Token: 0x04004A25 RID: 18981
	public UIText m_ScrollIconText;

	// Token: 0x04004A26 RID: 18982
	public Transform m_Slider1;

	// Token: 0x04004A27 RID: 18983
	public Transform m_Slider2;

	// Token: 0x04004A28 RID: 18984
	public Transform m_Slider3;

	// Token: 0x04004A29 RID: 18985
	public uint m_MaxOverload;

	// Token: 0x04004A2A RID: 18986
	public long m_ResStartTime;

	// Token: 0x04004A2B RID: 18987
	public uint m_ResTotalCount;

	// Token: 0x04004A2C RID: 18988
	public float m_ResRate;

	// Token: 0x04004A2D RID: 18989
	public CString m_Text1Str;

	// Token: 0x04004A2E RID: 18990
	public CString m_Text2Str;

	// Token: 0x04004A2F RID: 18991
	public CString m_Slider1TitleStr;

	// Token: 0x04004A30 RID: 18992
	public CString m_Slider1TimeStr;

	// Token: 0x04004A31 RID: 18993
	public CString m_TempTime;

	// Token: 0x04004A32 RID: 18994
	public CString m_IconText;
}
