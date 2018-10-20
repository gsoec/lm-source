using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200030A RID: 778
public class RallyTimeBar : IUTimeBarOnTimer
{
	// Token: 0x06000FD8 RID: 4056 RVA: 0x001BC314 File Offset: 0x001BA514
	public RallyTimeBar(UITimeBar timebar, int TimeBarID = 0)
	{
		this.TimeBar = timebar;
		this.TimeBar.m_Handler = this;
		this.TimeBar.m_TimeBarID = TimeBarID;
		this.transform = (this.TimeBar.transform as RectTransform);
		this.gameObject = this.transform.gameObject;
		this.RedShellAlpha = this.transform.GetChild(0).GetComponent<CanvasGroup>();
		this.RedShellAlpha.gameObject.SetActive(false);
		this.TitleStr = StringManager.Instance.SpawnString(30);
		GUIManager.Instance.CreateTimerBar(this.TimeBar, 0L, 0L, 0L, eTimeBarType.Marshal, string.Empty, string.Empty);
		this.BlueImg = this.transform.GetChild(2).GetComponent<Image>();
		this.RedImg = this.transform.GetChild(1).GetComponent<Image>();
		this.Title = this.transform.GetChild(3).GetComponent<UIText>();
	}

	// Token: 0x06000FD9 RID: 4057 RVA: 0x001BC418 File Offset: 0x001BA618
	public void SetTimebar(byte kind, long Begin, long Target, long NotifyTime)
	{
		DataManager instance = DataManager.Instance;
		string stringByID;
		Image sliderImage;
		RectTransform rectTransform;
		if (kind == 0)
		{
			if (instance.ServerTime < Target)
			{
				this.RedShellAlpha.gameObject.SetActive(false);
				this.RedShellAlpha.alpha = 0f;
				stringByID = instance.mStringTable.GetStringByID(4875u);
			}
			else
			{
				this.RedShellAlpha.gameObject.SetActive(true);
				this.RedShellAlpha.alpha = 1f;
				stringByID = instance.mStringTable.GetStringByID(4876u);
			}
			this.BlueImg.gameObject.SetActive(true);
			this.RedImg.gameObject.SetActive(false);
			sliderImage = this.BlueImg;
			rectTransform = this.BlueImg.rectTransform;
		}
		else
		{
			this.RedShellAlpha.gameObject.SetActive(true);
			this.RedShellAlpha.alpha = 1f;
			stringByID = instance.mStringTable.GetStringByID(4877u);
			this.BlueImg.gameObject.SetActive(false);
			this.RedImg.gameObject.SetActive(true);
			sliderImage = this.RedImg;
			rectTransform = this.RedImg.rectTransform;
		}
		this.Title.text = stringByID;
		GUIManager.Instance.SetTimerBar(this.TimeBar, Begin, Target, NotifyTime, eTimeBarType.SpeedupType, string.Empty, string.Empty);
		this.TimeBar.m_SliderImage = sliderImage;
		this.TimeBar.m_SliderRectTransform = rectTransform;
		if (!this.transform.gameObject.activeSelf)
		{
			this.transform.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000FDA RID: 4058 RVA: 0x001BC5B0 File Offset: 0x001BA7B0
	public void Update()
	{
		if (this.RedShellAlpha.gameObject.activeSelf)
		{
			float num = this.GleamTime / this.MaxGleamTime;
			if (num <= 1f)
			{
				this.RedShellAlpha.alpha = 1f - num;
			}
			else if (num <= 2f)
			{
				this.RedShellAlpha.alpha = num - 1f;
			}
			else
			{
				this.GleamTime = 0f;
			}
			this.GleamTime += Time.deltaTime;
		}
	}

	// Token: 0x06000FDB RID: 4059 RVA: 0x001BC644 File Offset: 0x001BA844
	public void TextRefresh()
	{
		if (this.TimeBar.gameObject.activeSelf)
		{
			this.TimeBar.Refresh_FontTexture();
		}
		this.Title.enabled = false;
		this.Title.enabled = true;
	}

	// Token: 0x06000FDC RID: 4060 RVA: 0x001BC68C File Offset: 0x001BA88C
	public void Destroy()
	{
		GUIManager.Instance.RemoverTimeBaarToList(this.TimeBar);
		StringManager.Instance.DeSpawnString(this.TitleStr);
	}

	// Token: 0x06000FDD RID: 4061 RVA: 0x001BC6B0 File Offset: 0x001BA8B0
	public void OnTimer(UITimeBar sender)
	{
		this.Title.text = DataManager.Instance.mStringTable.GetStringByID(4876u);
		this.RedShellAlpha.gameObject.SetActive(true);
		this.RedShellAlpha.alpha = 1f;
		if (this.Hander != null)
		{
			this.Hander.OnTimer(sender);
		}
	}

	// Token: 0x06000FDE RID: 4062 RVA: 0x001BC714 File Offset: 0x001BA914
	public void OnNotify(UITimeBar sender)
	{
	}

	// Token: 0x06000FDF RID: 4063 RVA: 0x001BC718 File Offset: 0x001BA918
	public void Onfunc(UITimeBar sender)
	{
	}

	// Token: 0x06000FE0 RID: 4064 RVA: 0x001BC71C File Offset: 0x001BA91C
	public void OnCancel(UITimeBar sender)
	{
	}

	// Token: 0x040033C9 RID: 13257
	public UITimeBar TimeBar;

	// Token: 0x040033CA RID: 13258
	public GameObject gameObject;

	// Token: 0x040033CB RID: 13259
	public UIText Title;

	// Token: 0x040033CC RID: 13260
	private CString TitleStr;

	// Token: 0x040033CD RID: 13261
	public RectTransform transform;

	// Token: 0x040033CE RID: 13262
	private CanvasGroup RedShellAlpha;

	// Token: 0x040033CF RID: 13263
	private Image BlueImg;

	// Token: 0x040033D0 RID: 13264
	private Image RedImg;

	// Token: 0x040033D1 RID: 13265
	private float GleamTime;

	// Token: 0x040033D2 RID: 13266
	private float MaxGleamTime = 1f;

	// Token: 0x040033D3 RID: 13267
	public IUTimeBarOnTimer Hander;
}
