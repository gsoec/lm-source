using System;
using UnityEngine;

// Token: 0x02000579 RID: 1401
public class UIHintMask : IUIButtonClickHandler
{
	// Token: 0x06001BE7 RID: 7143 RVA: 0x003190F8 File Offset: 0x003172F8
	public void Load()
	{
		UnityEngine.Object @object = GUIManager.Instance.m_ManagerAssetBundle.Load("UIHintMask");
		if (@object == null)
		{
			return;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
		gameObject.transform.SetParent(GUIManager.Instance.m_WindowTopLayer, false);
		gameObject.SetActive(false);
		this.m_RectTransform = (RectTransform)gameObject.transform;
		this.m_RectTransform.GetChild(0).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		this.HideBtn = this.m_RectTransform.GetChild(0).GetComponent<UIButton>();
		this.HideBtn.SoundIndex = byte.MaxValue;
		this.HideBtn.gameObject.name = "*";
	}

	// Token: 0x06001BE8 RID: 7144 RVA: 0x003191C0 File Offset: 0x003173C0
	public void UnLoad()
	{
		UnityEngine.Object.Destroy(this.m_RectTransform.gameObject);
	}

	// Token: 0x06001BE9 RID: 7145 RVA: 0x003191D4 File Offset: 0x003173D4
	public void Show(IUIButtonClickHandler hint)
	{
		this.HideBtn.m_Handler = hint;
		this.m_RectTransform.gameObject.SetActive(true);
	}

	// Token: 0x06001BEA RID: 7146 RVA: 0x003191F4 File Offset: 0x003173F4
	public void Show(UIButtonHint hint)
	{
		this.m_ButtonHint = hint;
		this.m_RectTransform.gameObject.SetActive(true);
	}

	// Token: 0x06001BEB RID: 7147 RVA: 0x00319210 File Offset: 0x00317410
	public void Hide(IUIButtonClickHandler hint)
	{
		if (this.HideBtn.m_Handler != hint)
		{
			return;
		}
		this.m_RectTransform.gameObject.SetActive(false);
		this.HideBtn.m_Handler = null;
		this.m_ButtonHint = null;
	}

	// Token: 0x06001BEC RID: 7148 RVA: 0x00319254 File Offset: 0x00317454
	public void Hide(UIButtonHint hint)
	{
		if (this.m_ButtonHint != hint)
		{
			return;
		}
		this.m_RectTransform.gameObject.SetActive(false);
		this.HideBtn.m_Handler = null;
		this.m_ButtonHint = null;
	}

	// Token: 0x06001BED RID: 7149 RVA: 0x00319298 File Offset: 0x00317498
	public void OnButtonClick(UIButton sender)
	{
	}

	// Token: 0x040054BB RID: 21691
	public RectTransform m_RectTransform;

	// Token: 0x040054BC RID: 21692
	public UIButton HideBtn;

	// Token: 0x040054BD RID: 21693
	public UIButtonHint m_ButtonHint;

	// Token: 0x040054BE RID: 21694
	public static bool bPassThrough = true;
}
