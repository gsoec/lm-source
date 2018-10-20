using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000644 RID: 1604
public class UIPriestTalk : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001EF8 RID: 7928 RVA: 0x003B6C10 File Offset: 0x003B4E10
	public override void OnOpen(int arg1, int arg2)
	{
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIButton component = this.AGS_Form.GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1;
		UIText component2 = this.AGS_Form.GetChild(0).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = DataManager.Instance.mStringTable.GetStringByID((uint)((ushort)arg1));
		component2.resizeTextForBestFit = true;
		component2.resizeTextMinSize = 12;
		component2.resizeTextMaxSize = 22;
		component = this.AGS_Form.GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1;
		component = this.AGS_Form.GetChild(4).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 2;
		component.gameObject.SetActive(NewbieManager.IsNewbie);
		component2 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(1050u);
		this.Pos3D1 = this.AGS_Form.GetChild(1);
		this.hero = DataManager.Instance.HeroTable.GetRecordByKey(101);
		this.bundle = AssetManager.GetAssetBundle("Role/Priest", out this.AssetKey, false);
		this.bundleRequest = this.bundle.LoadAsync("Priest", typeof(GameObject));
		this.wait3DModel = true;
		if (GUIManager.Instance.m_UICanvas.renderMode == RenderMode.ScreenSpaceOverlay)
		{
			this.isOverLay = true;
			GUIManager.Instance.m_UICanvas.renderMode = RenderMode.ScreenSpaceCamera;
			GUIManager.Instance.SetCanvasChanged();
		}
		this.bClickClose = (arg2 == 0);
		if (UIPriestTalk.Block1s)
		{
			this.limitTime = Time.time + 1f;
		}
		Light component3 = this.AGS_Form.GetChild(1).GetChild(0).GetChild(0).GetComponent<Light>();
		component3.gameObject.transform.localPosition = new Vector3(-1576f, -267f, 583f);
		component3.range = 70f;
		component3.color = new Color32(68, 99, 171, byte.MaxValue);
		component3.intensity = 6.5f;
		Light component4 = this.AGS_Form.GetChild(1).GetChild(0).GetChild(1).GetComponent<Light>();
		component4.gameObject.transform.localPosition = new Vector3(807f, 1263f, -2327f);
		component4.range = 70f;
		component4.color = new Color32(253, 239, 190, byte.MaxValue);
		component4.intensity = 5.3f;
	}

	// Token: 0x06001EF9 RID: 7929 RVA: 0x003B6EEC File Offset: 0x003B50EC
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID != 1)
		{
			if (btnID == 2)
			{
				NewbieManager.Get().SkipForceNewbie();
				GUIManager.Instance.CloseMenu(EGUIWindow.UI_PriestTalk);
			}
		}
		else
		{
			if (Time.time < this.limitTime)
			{
				return;
			}
			UIPriestTalk.Block1s = false;
			NewbieManager.Get().UIController.TriggerButtonEvent(0);
			if (this.bClickClose)
			{
				GUIManager.Instance.CloseMenu(EGUIWindow.UI_PriestTalk);
			}
		}
	}

	// Token: 0x06001EFA RID: 7930 RVA: 0x003B6F74 File Offset: 0x003B5174
	public override void OnClose()
	{
		UIPriestTalk.Block1s = false;
		if (this.isOverLay)
		{
			GUIManager.Instance.m_UICanvas.renderMode = RenderMode.ScreenSpaceOverlay;
			GUIManager.Instance.SetCanvasChanged();
		}
		if (this.Holder != null)
		{
			UnityEngine.Object.Destroy(this.Holder);
			this.Holder = null;
		}
		AssetManager.UnloadAssetBundle(this.AssetKey, false);
	}

	// Token: 0x06001EFB RID: 7931 RVA: 0x003B6FDC File Offset: 0x003B51DC
	public override void UpdateUI(int arg1, int arg2)
	{
		UIText component = this.AGS_Form.GetChild(0).GetChild(0).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID((uint)((ushort)arg1));
		if (this.Holder != null)
		{
			Animation component2 = this.Holder.GetComponent<Animation>();
			if (component2 != null)
			{
				component2.CrossFade("talk");
			}
		}
		this.bClickClose = (arg2 == 0);
		if (UIPriestTalk.Block1s)
		{
			this.limitTime = Time.time + 1f;
		}
	}

	// Token: 0x06001EFC RID: 7932 RVA: 0x003B707C File Offset: 0x003B527C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Fallout)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				this.AGS_Form.gameObject.SetActive(false);
			}
		}
		else
		{
			this.AGS_Form.gameObject.SetActive(true);
			if (this.Holder != null)
			{
				Animation component = this.Holder.GetComponent<Animation>();
				if (component != null)
				{
					component[AnimationUnit.ANIM_STRING[0]].layer = 0;
					component[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
					component.Play(AnimationUnit.ANIM_STRING[0]);
					component["talk"].layer = 1;
					component["talk"].wrapMode = WrapMode.Once;
					component.CrossFade("talk");
				}
			}
		}
	}

	// Token: 0x06001EFD RID: 7933 RVA: 0x003B716C File Offset: 0x003B536C
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(0).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
	}

	// Token: 0x06001EFE RID: 7934 RVA: 0x003B71F4 File Offset: 0x003B53F4
	public void Update()
	{
		if (this.wait3DModel)
		{
			if (!this.bundleRequest.isDone)
			{
				return;
			}
			this.Pos3D1.gameObject.SetActive(true);
			this.Holder = (GameObject)UnityEngine.Object.Instantiate(this.bundleRequest.asset);
			this.Holder.transform.SetParent(this.Pos3D1, false);
			Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
			localRotation.eulerAngles = new Vector3(0f, (float)this.hero.Camera_Horizontal, 0f);
			this.Holder.transform.localRotation = localRotation;
			this.Holder.transform.localScale = new Vector3((float)this.hero.CameraScaleRate, (float)this.hero.CameraScaleRate, (float)this.hero.CameraScaleRate) * 1.3f;
			this.Holder.transform.localPosition = new Vector3(0f, -120f, 0f);
			GUIManager.Instance.SetLayer(this.Holder, 5);
			Transform transform = this.Holder.transform;
			if (transform != null)
			{
				Animation component = transform.GetComponent<Animation>();
				component[AnimationUnit.ANIM_STRING[0]].layer = 0;
				component[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
				component.Play(AnimationUnit.ANIM_STRING[0]);
				transform.GetComponentInChildren<SkinnedMeshRenderer>().useLightProbes = false;
				transform.GetComponentInChildren<SkinnedMeshRenderer>().updateWhenOffscreen = true;
				component["talk"].layer = 1;
				component["talk"].wrapMode = WrapMode.Once;
				component.CrossFade("talk");
			}
			this.wait3DModel = false;
		}
	}

	// Token: 0x04006257 RID: 25175
	private Transform AGS_Form;

	// Token: 0x04006258 RID: 25176
	private Hero hero;

	// Token: 0x04006259 RID: 25177
	private Transform Pos3D1;

	// Token: 0x0400625A RID: 25178
	private GameObject Holder;

	// Token: 0x0400625B RID: 25179
	private bool wait3DModel;

	// Token: 0x0400625C RID: 25180
	private int AssetKey;

	// Token: 0x0400625D RID: 25181
	private AssetBundle bundle;

	// Token: 0x0400625E RID: 25182
	private AssetBundleRequest bundleRequest;

	// Token: 0x0400625F RID: 25183
	private bool isOverLay;

	// Token: 0x04006260 RID: 25184
	private bool bClickClose = true;

	// Token: 0x04006261 RID: 25185
	public static bool Block1s;

	// Token: 0x04006262 RID: 25186
	private float limitTime;

	// Token: 0x02000645 RID: 1605
	private enum e_AGS_UI_PriestTalk_Editor
	{
		// Token: 0x04006264 RID: 25188
		TalkPanel,
		// Token: 0x04006265 RID: 25189
		T3DO1,
		// Token: 0x04006266 RID: 25190
		UIButton,
		// Token: 0x04006267 RID: 25191
		GameObject,
		// Token: 0x04006268 RID: 25192
		skip
	}

	// Token: 0x02000646 RID: 1606
	private enum e_AGS_Light
	{
		// Token: 0x0400626A RID: 25194
		Light1,
		// Token: 0x0400626B RID: 25195
		Light2
	}
}
