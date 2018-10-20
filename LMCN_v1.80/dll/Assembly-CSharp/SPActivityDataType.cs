using System;
using UnityEngine;

// Token: 0x0200001B RID: 27
public class SPActivityDataType
{
	// Token: 0x06000039 RID: 57 RVA: 0x00003A1C File Offset: 0x00001C1C
	public void Initial()
	{
		this.bAskDetailData = false;
		this.EventBeginTime = 0L;
		this.EventEndTime = 0L;
		this.Name = 0;
		this.Pic = 0;
		this.PicStr = 0;
		this.HeadStr = 0;
		this.DetailPic = 0;
		this.GoToButton = 0;
		this.Marquee = 0;
		for (int i = 0; i < this.ContentTimeData.Length; i++)
		{
			this.ContentTimeData[i].BeginTime = 0L;
			this.ContentTimeData[i].RequireTime = 0u;
		}
		this.DownLoadStr = null;
		this.bDownLoadStr = false;
		this.bUpDateStr = false;
		this.UnloadStrAB();
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00003ACC File Offset: 0x00001CCC
	public void InitialABString()
	{
		if (this.DetailStr == 0)
		{
			return;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)this.DetailStr, 1, false);
		cstring.AppendFormat("UI/UIActivityPackage_{0}");
		this.m_StrAssetBundle = AssetManager.GetAssetBundle(cstring, out this.m_StrAssetBundleKey);
		if (this.m_StrAssetBundle != null)
		{
			this.DownLoadStr = (this.m_StrAssetBundle.Load("Package", typeof(ActivityData)) as ActivityData);
		}
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00003B54 File Offset: 0x00001D54
	public void UnloadStrAB()
	{
		if (this.m_StrAssetBundleKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.m_StrAssetBundleKey, true);
			this.m_StrAssetBundle = null;
			this.m_StrAssetBundleKey = 0;
		}
	}

	// Token: 0x04000122 RID: 290
	public const byte MAX_ACTIVITY_SPECIAL_CONTENT_DATE = 4;

	// Token: 0x04000123 RID: 291
	public bool bAskDetailData;

	// Token: 0x04000124 RID: 292
	public long EventBeginTime;

	// Token: 0x04000125 RID: 293
	public long EventEndTime;

	// Token: 0x04000126 RID: 294
	public ushort Name;

	// Token: 0x04000127 RID: 295
	public ushort Pic;

	// Token: 0x04000128 RID: 296
	public ushort PicStr;

	// Token: 0x04000129 RID: 297
	public ushort HeadStr;

	// Token: 0x0400012A RID: 298
	public ushort DetailPic;

	// Token: 0x0400012B RID: 299
	public ushort DetailStr;

	// Token: 0x0400012C RID: 300
	public ushort GoToButton;

	// Token: 0x0400012D RID: 301
	public ushort Marquee;

	// Token: 0x0400012E RID: 302
	public SPContentTimeDataType[] ContentTimeData = new SPContentTimeDataType[4];

	// Token: 0x0400012F RID: 303
	public bool bDownLoadStr;

	// Token: 0x04000130 RID: 304
	public bool bUpDateStr;

	// Token: 0x04000131 RID: 305
	public AssetBundle m_StrAssetBundle;

	// Token: 0x04000132 RID: 306
	public int m_StrAssetBundleKey;

	// Token: 0x04000133 RID: 307
	public ActivityData DownLoadStr;
}
