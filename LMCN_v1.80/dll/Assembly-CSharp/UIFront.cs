using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000296 RID: 662
public class UIFront : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06000D2B RID: 3371 RVA: 0x00139298 File Offset: 0x00137498
	public override void OnOpen(int arg1, int arg2)
	{
		base.transform.SetParent(GUIManager.Instance.m_NewbieLayer);
		for (int i = 0; i < this.SceneBackImage.Length; i++)
		{
			this.SceneBackImage[i] = base.transform.GetChild(0 + i).GetComponent<CanvasGroup>();
		}
		this.BackTrans = base.transform.GetChild(0);
		this.EffectTrans = base.transform.GetChild(3);
		this.SkipBtnTrans = base.transform.GetChild(5).GetComponent<RectTransform>();
		this.SkipBtn = this.SkipBtnTrans.GetComponent<UIButton>();
		this.SkipBtn.m_Handler = this;
		this.SkipText = base.transform.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.SkipText.font = GUIManager.Instance.GetTTFFont();
		this.SkipText.text = DataManager.Instance.mStringTable.GetStringByID(1050u);
		this.EffectObj = ParticleManager.Instance.Spawn(378, null, Vector3.zero, 1f, true, true, true);
		GUIManager.Instance.SetLayer(this.EffectObj, 5);
		this.EffectObj.transform.SetParent(this.EffectTrans);
		this.EffectObj.transform.localPosition = new Vector3(0f, 0f, 444f);
		this.EffectObj.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
		this.CanvasWidth = (GUIManager.Instance.m_UICanvas.transform as RectTransform).sizeDelta.x;
		GUIManager.Instance.m_MessageBoxLayer.gameObject.SetActive(false);
		GUIManager.Instance.m_LockPanelLayer.gameObject.SetActive(false);
		GUIManager.Instance.m_HUDsTransform.gameObject.SetActive(false);
		if (!byte.TryParse(PlayerPrefs.GetString("Front_Guide"), out this.HideSkipBtn))
		{
			PlayerPrefs.SetString("Front_Guide", "0");
		}
		if (this.HideSkipBtn == 1)
		{
			this.SkipBtn.gameObject.SetActive(true);
		}
		else
		{
			this.SkipBtn.gameObject.SetActive(false);
		}
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			RectTransform rectTransform = base.transform as RectTransform;
			rectTransform.offsetMin = new Vector2(0f, 0f);
			rectTransform.offsetMax = new Vector2(0f, 0f);
		}
	}

	// Token: 0x06000D2C RID: 3372 RVA: 0x00139538 File Offset: 0x00137738
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.SkipText.enabled = false;
			this.SkipText.enabled = true;
		}
	}

	// Token: 0x06000D2D RID: 3373 RVA: 0x00139574 File Offset: 0x00137774
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.CurScen == 0)
		{
			return;
		}
		if (this.SceneBackImage[(int)(this.CurScen - 1)].alpha < 0.1f)
		{
			return;
		}
		float num = Mathf.Clamp(this.DeltaTime / 1f, 0f, 1f);
		this.SceneBackImage[(int)(this.CurScen - 1)].alpha = 1f - num;
		this.SceneBackImage[(int)this.CurScen].alpha = num;
		if (this.SceneBackImage[(int)(this.CurScen - 1)].alpha < 0.1f)
		{
			this.SceneBackImage[(int)(this.CurScen - 1)].gameObject.SetActive(false);
			this.SceneBackImage[(int)this.CurScen].alpha = 1f;
			this.BackTrans = this.SceneBackImage[(int)this.CurScen].transform;
			this.DeltaTime = 0f;
		}
		else
		{
			this.DeltaTime += Time.deltaTime;
		}
	}

	// Token: 0x06000D2E RID: 3374 RVA: 0x00139680 File Offset: 0x00137880
	public void OnButtonClick(UIButton sender)
	{
		DataManager.StageDataController.currentWorldMode = WorldMode.Wild;
		DataManager.StageDataController._stageMode = StageMode.Count;
		DataManager.Instance.GoToBattleOrWar = GameplayKind.Origin;
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
		NewbieManager.Get().LockControl(true);
		NewbieManager.CheckNewbie(null);
		GUIManager.Instance.ShowChatBox();
		GUIManager.Instance.CloseMenu(EGUIWindow.UI_Front);
	}

	// Token: 0x06000D2F RID: 3375 RVA: 0x001396E8 File Offset: 0x001378E8
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 0:
			base.transform.gameObject.SetActive(true);
			break;
		case 1:
			this.BackTrans.gameObject.SetActive(false);
			this.EffectTrans.gameObject.SetActive(false);
			break;
		case 2:
			if (GUIManager.Instance.m_OtherCanvasLayer != null)
			{
				this.SkipBtnTrans.SetParent(GUIManager.Instance.m_OtherCanvasLayer);
				if (GUIManager.Instance.IsArabic)
				{
					this.SkipBtnTrans.anchoredPosition = new Vector2(-this.CanvasWidth + 85f, -40f);
					this.SkipBtnTrans.rotation = new Quaternion(0f, 180f, 0f, 0f);
				}
				else
				{
					this.SkipBtnTrans.anchoredPosition = new Vector2(-85f, -40f);
					this.SkipBtnTrans.rotation = new Quaternion(0f, 0f, 0f, 0f);
				}
				this.SkipBtnTrans.localScale = Vector3.one;
			}
			break;
		case 3:
			this.SkipBtnTrans.SetParent(base.transform);
			this.SkipBtnTrans.anchoredPosition = new Vector2(-85f, -40f);
			this.SkipBtnTrans.rotation = new Quaternion(0f, 0f, 0f, 0f);
			this.SkipBtnTrans.localScale = Vector3.one;
			break;
		case 4:
			this.SkipBtn.enabled = false;
			break;
		case 5:
			this.SkipBtn.enabled = true;
			break;
		case 6:
			if ((int)(this.CurScen + 1) < this.SceneBackImage.Length && (int)this.SceneBackImage[(int)this.CurScen].alpha == 1)
			{
				this.SceneBackImage[(int)(this.CurScen += 1)].gameObject.SetActive(true);
			}
			break;
		case 7:
			if (this.CurScen >= 2 && !(this.FireEffect != null))
			{
				this.FireEffect = ParticleManager.Instance.Spawn(386, null, Vector3.zero, 1f, true, true, true);
				GUIManager.Instance.SetLayer(this.FireEffect, 5);
				this.FireEffect.transform.SetParent(this.EffectTrans);
				this.FireEffect.transform.localPosition = new Vector3(0f, -222f, 0f);
				this.FireEffect.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			}
			break;
		}
	}

	// Token: 0x06000D30 RID: 3376 RVA: 0x001399D4 File Offset: 0x00137BD4
	public override void OnClose()
	{
		GUIManager.Instance.m_MessageBoxLayer.gameObject.SetActive(true);
		GUIManager.Instance.m_LockPanelLayer.gameObject.SetActive(true);
		this.SkipBtnTrans.SetParent(base.transform);
		ParticleManager.Instance.DeSpawn(this.EffectObj);
		if (this.FireEffect != null && this.FireEffect.activeSelf)
		{
			this.FireEffect.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			this.FireEffect.transform.localPosition = new Vector3(0f, 0f, -50f);
		}
	}

	// Token: 0x04002AC0 RID: 10944
	private Transform BackTrans;

	// Token: 0x04002AC1 RID: 10945
	private Transform EffectTrans;

	// Token: 0x04002AC2 RID: 10946
	private CanvasGroup[] SceneBackImage = new CanvasGroup[3];

	// Token: 0x04002AC3 RID: 10947
	private RectTransform SkipBtnTrans;

	// Token: 0x04002AC4 RID: 10948
	private UIText SkipText;

	// Token: 0x04002AC5 RID: 10949
	private GameObject EffectObj;

	// Token: 0x04002AC6 RID: 10950
	private GameObject FireEffect;

	// Token: 0x04002AC7 RID: 10951
	private UIButton SkipBtn;

	// Token: 0x04002AC8 RID: 10952
	private byte CurScen;

	// Token: 0x04002AC9 RID: 10953
	private byte HideSkipBtn;

	// Token: 0x04002ACA RID: 10954
	private float DeltaTime;

	// Token: 0x04002ACB RID: 10955
	private float CanvasWidth;

	// Token: 0x02000297 RID: 663
	public enum UIControl
	{
		// Token: 0x04002ACD RID: 10957
		BackImage1,
		// Token: 0x04002ACE RID: 10958
		BackImage2,
		// Token: 0x04002ACF RID: 10959
		BackImage3,
		// Token: 0x04002AD0 RID: 10960
		Effect,
		// Token: 0x04002AD1 RID: 10961
		Fences,
		// Token: 0x04002AD2 RID: 10962
		SkipBtn
	}
}
