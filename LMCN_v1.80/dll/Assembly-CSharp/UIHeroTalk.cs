using System;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x0200059B RID: 1435
public class UIHeroTalk : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001C74 RID: 7284 RVA: 0x00324974 File Offset: 0x00322B74
	public override void OnOpen(int arg1, int arg2)
	{
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIButton component = this.AGS_Form.GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.gameObject.SetActive(false);
		component.image.color = new Color(1f, 1f, 1f, 0.5f);
		component.m_BtnID1 = 1;
		UIText component2 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.resizeTextForBestFit = true;
		component2.resizeTextMinSize = 12;
		component2.resizeTextMaxSize = 22;
		component2 = this.AGS_Form.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component = this.AGS_Form.GetChild(7).GetComponent<UIButton>();
		component.m_Handler = this;
		component.gameObject.SetActive(false);
		component.m_BtnID1 = 2;
		component2 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(1050u);
		Vector3 localPosition = this.AGS_Form.GetChild(1).localPosition;
		localPosition.z = -1000f;
		this.AGS_Form.GetChild(1).localPosition = localPosition;
		this.AGS_Form.GetChild(1).gameObject.SetActive(false);
		localPosition = this.AGS_Form.GetChild(5).localPosition;
		localPosition.z = -1000f;
		this.AGS_Form.GetChild(5).localPosition = localPosition;
		uTweenPosition component3 = this.AGS_Form.GetChild(6).GetComponent<uTweenPosition>();
		component3.from.z = -1000f;
		component3.to.z = -1000f;
		this.Pos3D1 = this.AGS_Form.GetChild(2).transform;
		localPosition = this.Pos3D1.localPosition;
		localPosition.z = -500f;
		this.Pos3D1.localPosition = localPosition;
		this.Pos3D1.localEulerAngles = new Vector3(0f, 340f, 0f);
		this.Pos3D1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -28f);
		this.Pos3D2 = this.AGS_Form.GetChild(3).transform;
		localPosition = this.Pos3D2.localPosition;
		localPosition.z = -500f;
		this.Pos3D2.localPosition = localPosition;
		this.Pos3D2.localEulerAngles = new Vector3(0f, 20f, 0f);
		this.Pos3D2.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -28f);
		this.AGS_Form.GetChild(0).gameObject.SetActive(true);
		this.LightGroup = this.AGS_Form.GetChild(4);
		this.PosLight1 = this.AGS_Form.GetChild(4).GetChild(0);
		this.PosLight2 = this.AGS_Form.GetChild(4).GetChild(1);
		GameObject gameObject = new GameObject("Light3");
		gameObject.transform.SetParent(this.LightGroup, false);
		this.PosLight3 = gameObject.transform;
		gameObject.AddComponent<Light>();
		Light component4 = this.PosLight1.GetComponent<Light>();
		component4.range = 15f;
		component4.spotAngle = 10f;
		component4.color = new Color32(195, 87, 54, byte.MaxValue);
		component4.type = LightType.Spot;
		component4.intensity = 8f;
		component4 = this.PosLight2.GetComponent<Light>();
		component4.type = LightType.Spot;
		component4.range = 20f;
		component4.spotAngle = 10f;
		component4.color = new Color32(242, 224, 205, byte.MaxValue);
		component4.intensity = 8f;
		component4 = this.PosLight3.GetComponent<Light>();
		component4.range = 15f;
		component4.spotAngle = 10f;
		component4.color = new Color32(148, 107, 107, byte.MaxValue);
		component4.type = LightType.Spot;
		component4.intensity = 5.5f;
		this.EvoLight = RenderSettings.ambientLight;
		RenderSettings.ambientLight = new Color32(197, 178, 178, byte.MaxValue);
		this.startTalkId = (ushort)arg1;
		if (this.startTalkId == 13)
		{
			component.gameObject.SetActive(NewbieManager.IsNewbie);
		}
		else
		{
			component.gameObject.SetActive(false);
		}
		if (arg2 != 0)
		{
			UIHeroTalk.HeroID1 = (ushort)arg2;
		}
		this.talkString = StringManager.Instance.SpawnString(500);
		ushort num = 0;
		while ((int)num < DataManager.Instance.HeroTalkTable.TableCount)
		{
			HeroTalkTbl recordByIndex = DataManager.Instance.HeroTalkTable.GetRecordByIndex((int)num);
			if (recordByIndex.TalkGroup == this.startTalkId)
			{
				this.startTalkId = recordByIndex.ID;
				break;
			}
			num += 1;
		}
		this.SetTalk(this.startTalkId);
		GUIManager.Instance.m_WindowsTransform.gameObject.SetActive(false);
		this.Create3DObjects();
	}

	// Token: 0x06001C75 RID: 7285 RVA: 0x00324EEC File Offset: 0x003230EC
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID != 1)
		{
			if (btnID == 2)
			{
				NewbieManager.Get().SkipForceNewbie();
				GUIManager.Instance.CloseMenu(EGUIWindow.UI_HeroTalk);
			}
		}
		else
		{
			if (UIHeroTalk.lockInput)
			{
				return;
			}
			if (this.talkData.TalkGroup == DataManager.Instance.HeroTalkTable.GetRecordByKey(this.nowTalkId + 1).TalkGroup)
			{
				this.SetTalk(this.nowTalkId + 1);
				return;
			}
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_HeroTalk);
			DataManager.msgBuffer[0] = 2;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x06001C76 RID: 7286 RVA: 0x00324FA0 File Offset: 0x003231A0
	public void SetTalk(ushort talkID)
	{
		this.nowTalkId = talkID;
		this.talkData = DataManager.Instance.HeroTalkTable.GetRecordByKey(talkID);
		byte showRole = this.talkData.ShowRole;
		if (showRole != 2)
		{
			if (showRole == 3)
			{
				System.Random random = new System.Random();
				int num = random.Next((int)DataManager.Instance.CurHeroDataCount);
				UIHeroTalk.HeroID1 = DataManager.Instance.curHeroData[DataManager.Instance.sortHeroData[num]].ID;
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.IntToFormat((long)UIHeroTalk.HeroID1, 5, false);
				cstring.AppendFormat("Role/hero_{0}");
				if (!AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, UIHeroTalk.HeroID1, false))
				{
					UIHeroTalk.HeroID1 = 101;
				}
				else if (!this.CheckCanSelectById(UIHeroTalk.HeroID1))
				{
					UIHeroTalk.HeroID1 = 101;
				}
			}
		}
		else
		{
			UIHeroTalk.HeroID1 = 101;
		}
		UIHeroTalk.HeroID2 = this.talkData.NPCID;
		this.hero1 = DataManager.Instance.HeroTable.GetRecordByKey(UIHeroTalk.HeroID1);
		this.hero2 = DataManager.Instance.HeroTable.GetRecordByKey(UIHeroTalk.HeroID2);
		UIText component;
		if (this.talkData.Enemytalk == 0)
		{
			this.AGS_Form.GetChild(1).localScale = new Vector3(-1f, 1f, 1f);
			this.AGS_Form.GetChild(1).GetChild(0).localEulerAngles = new Vector3(0f, 180f, 0f);
			this.AGS_Form.GetChild(1).GetChild(1).GetChild(0).localEulerAngles = new Vector3(0f, 180f, 0f);
			component = this.AGS_Form.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID((uint)this.hero1.HeroTitle);
			this.PosLight1.SetParent(this.Pos3D1);
			this.PosLight2.SetParent(this.Pos3D1);
			this.PosLight3.SetParent(this.Pos3D2);
			this.PosLight1.localPosition = new Vector3(-256.35f, -124.16f, 456.18f);
			this.PosLight2.localPosition = new Vector3(-244.53f, 1105.84f, -817.82f);
			this.PosLight3.localPosition = new Vector3(76.94f, 464.84f, 296.185f);
			this.PosLight1.LookAt(this.Pos3D1.position);
			this.PosLight2.LookAt(this.Pos3D1.position);
			this.PosLight3.LookAt(this.Pos3D2.position);
		}
		else
		{
			this.AGS_Form.GetChild(1).localScale = Vector3.one;
			this.AGS_Form.GetChild(1).GetChild(0).localEulerAngles = Vector3.zero;
			this.AGS_Form.GetChild(1).GetChild(1).GetChild(0).localEulerAngles = Vector3.zero;
			component = this.AGS_Form.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID((uint)this.hero2.HeroTitle);
			this.PosLight1.SetParent(this.Pos3D2);
			this.PosLight2.SetParent(this.Pos3D2);
			this.PosLight3.SetParent(this.Pos3D1);
			this.PosLight1.localPosition = new Vector3(-256.35f, -124.16f, 456.18f);
			this.PosLight2.localPosition = new Vector3(-184.53f, 1105.84f, -817.82f);
			this.PosLight3.localPosition = new Vector3(76.94f, 464.84f, 296.185f);
			this.PosLight1.LookAt(this.Pos3D2.position);
			this.PosLight2.LookAt(this.Pos3D2.position);
			this.PosLight3.LookAt(this.Pos3D1.position);
			Debug.Log(this.Pos3D1.position);
			Debug.Log(this.PosLight1.position);
		}
		component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.talkString.ClearString();
		this.talkString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)this.hero1.HeroTitle));
		this.talkString.AppendFormat(DataManager.Instance.mStringTable.GetStringByID((uint)this.talkData.StringID));
		component.text = this.talkString.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		if (this.talkData.ShowRole == 0)
		{
			this.Pos3D1.gameObject.SetActive(false);
		}
		else
		{
			this.Pos3D1.gameObject.SetActive(true);
		}
		if (this.talkData.NPCID == 0)
		{
			this.Pos3D2.gameObject.SetActive(false);
		}
		else
		{
			this.Pos3D2.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001C77 RID: 7287 RVA: 0x00325510 File Offset: 0x00323710
	private void Create3DObjects()
	{
		if (this.LoadingStep > UIHeroTalk.e_LoadingStep.Ready)
		{
			this.Destory3DObject();
		}
		this.LoadingStep = UIHeroTalk.e_LoadingStep.Ready;
		if (UIHeroTalk.HeroID1 != 0)
		{
			this.hero1 = DataManager.Instance.HeroTable.GetRecordByKey(UIHeroTalk.HeroID1);
			this.LoadModel(this.hero1, out this.AssetKey1);
			this.LoadingStep = UIHeroTalk.e_LoadingStep.WaitFirst;
		}
		else
		{
			this.hero2 = DataManager.Instance.HeroTable.GetRecordByKey(UIHeroTalk.HeroID2);
			this.LoadModel(this.hero2, out this.AssetKey2);
			this.LoadingStep = UIHeroTalk.e_LoadingStep.WaitSecend;
		}
	}

	// Token: 0x06001C78 RID: 7288 RVA: 0x003255AC File Offset: 0x003237AC
	private void LoadModel(Hero herodata, out int AssetKey)
	{
		if (herodata.HeroKey == 101)
		{
			this.bundle = AssetManager.GetAssetBundle("Role/Priest", out AssetKey, false);
			this.bundleRequest = this.bundle.LoadAsync("Priest", typeof(GameObject));
		}
		else
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat((long)herodata.Modle, 5, false);
			cstring.AppendFormat("Role/hero_{0}");
			this.bundle = AssetManager.GetAssetBundle(cstring, out AssetKey);
			if (this.bundle == null)
			{
				cstring.ClearString();
				cstring.IntToFormat(1L, 5, false);
				cstring.AppendFormat("Role/hero_{0}");
				this.bundle = AssetManager.GetAssetBundle(cstring, out AssetKey);
			}
			this.bundleRequest = this.bundle.LoadAsync("m", typeof(GameObject));
		}
	}

	// Token: 0x06001C79 RID: 7289 RVA: 0x0032568C File Offset: 0x0032388C
	private void Destory3DObject()
	{
		if (this.Holder1 != null)
		{
			UnityEngine.Object.Destroy(this.Holder1);
			this.Holder1 = null;
		}
		if (this.Holder2 != null)
		{
			UnityEngine.Object.Destroy(this.Holder2);
			this.Holder2 = null;
		}
		this.bundle = null;
		if (this.AssetKey1 != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey1, false);
		}
		if (this.AssetKey2 != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey2, false);
		}
		UnityEngine.Object.Destroy(this.Pos3D1.gameObject);
		UnityEngine.Object.Destroy(this.Pos3D2.gameObject);
		if (this.PosLight1 != null)
		{
			UnityEngine.Object.Destroy(this.PosLight1.gameObject);
		}
		if (this.PosLight2 != null)
		{
			UnityEngine.Object.Destroy(this.PosLight2.gameObject);
		}
		this.LoadingStep = UIHeroTalk.e_LoadingStep.Ready;
	}

	// Token: 0x06001C7A RID: 7290 RVA: 0x00325780 File Offset: 0x00323980
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
			else if (!NewbieManager.IsNewbie)
			{
				this.AGS_Form.gameObject.SetActive(false);
			}
		}
		else
		{
			this.AGS_Form.gameObject.SetActive(true);
			this.resetModelAction();
		}
	}

	// Token: 0x06001C7B RID: 7291 RVA: 0x003257F4 File Offset: 0x003239F4
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
	}

	// Token: 0x06001C7C RID: 7292 RVA: 0x003258C0 File Offset: 0x00323AC0
	public void Update()
	{
		UIHeroTalk.e_LoadingStep loadingStep = this.LoadingStep;
		if (loadingStep != UIHeroTalk.e_LoadingStep.WaitFirst)
		{
			if (loadingStep == UIHeroTalk.e_LoadingStep.WaitSecend)
			{
				if (this.bundleRequest.isDone)
				{
					this.Holder2 = (GameObject)UnityEngine.Object.Instantiate(this.bundleRequest.asset);
					this.Holder2.transform.SetParent(this.Pos3D2, false);
					Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
					localRotation.eulerAngles = new Vector3(0f, 180f, 0f);
					this.Holder2.transform.localRotation = localRotation;
					this.Holder2.transform.localScale = new Vector3((float)this.hero2.CameraScaleRate, (float)this.hero2.CameraScaleRate, (float)this.hero2.CameraScaleRate);
					this.Holder2.transform.localPosition = Vector3.zero;
					GUIManager.Instance.SetLayer(this.Holder2, 5);
					Transform transform = this.Holder2.transform;
					if (transform != null)
					{
						Animation component = transform.GetComponent<Animation>();
						component[AnimationUnit.ANIM_STRING[0]].layer = 0;
						component[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
						component.Play(AnimationUnit.ANIM_STRING[0]);
						SkinnedMeshRenderer componentInChildren = transform.GetComponentInChildren<SkinnedMeshRenderer>();
						if (componentInChildren != null)
						{
							componentInChildren.useLightProbes = false;
							componentInChildren.updateWhenOffscreen = true;
						}
					}
					this.LoadingStep = UIHeroTalk.e_LoadingStep.Done;
					this.AGS_Form.GetChild(1).gameObject.SetActive(true);
				}
			}
		}
		else if (this.bundleRequest != null && this.bundleRequest.isDone)
		{
			this.Pos3D1.gameObject.SetActive(true);
			this.Holder1 = (GameObject)UnityEngine.Object.Instantiate(this.bundleRequest.asset);
			this.Holder1.transform.SetParent(this.Pos3D1, false);
			Quaternion localRotation2 = new Quaternion(0f, 0f, 0f, 0f);
			localRotation2.eulerAngles = new Vector3(0f, 180f, 0f);
			this.Holder1.transform.localRotation = localRotation2;
			this.Holder1.transform.localScale = new Vector3((float)this.hero1.CameraScaleRate, (float)this.hero1.CameraScaleRate, (float)this.hero1.CameraScaleRate);
			this.Holder1.transform.localPosition = Vector3.zero;
			GUIManager.Instance.SetLayer(this.Holder1, 5);
			Transform transform2 = this.Holder1.transform;
			if (transform2 != null)
			{
				Animation component2 = transform2.GetComponent<Animation>();
				component2[AnimationUnit.ANIM_STRING[0]].layer = 0;
				component2[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
				component2.Play(AnimationUnit.ANIM_STRING[0]);
				SkinnedMeshRenderer componentInChildren2 = transform2.GetComponentInChildren<SkinnedMeshRenderer>();
				if (componentInChildren2 != null)
				{
					componentInChildren2.useLightProbes = false;
					componentInChildren2.updateWhenOffscreen = true;
				}
			}
			if (UIHeroTalk.HeroID2 != 0)
			{
				this.LoadModel(this.hero2, out this.AssetKey2);
				this.LoadingStep = UIHeroTalk.e_LoadingStep.WaitSecend;
			}
			else
			{
				this.LoadingStep = UIHeroTalk.e_LoadingStep.Done;
				this.AGS_Form.GetChild(1).gameObject.SetActive(true);
			}
			if (this.talkData.ShowRole == 0)
			{
				this.Pos3D1.gameObject.SetActive(false);
			}
			else
			{
				this.Pos3D1.gameObject.SetActive(true);
			}
			if (this.talkData.NPCID == 0)
			{
				this.Pos3D2.gameObject.SetActive(false);
			}
			else
			{
				this.Pos3D2.gameObject.SetActive(true);
			}
		}
	}

	// Token: 0x06001C7D RID: 7293 RVA: 0x00325CB4 File Offset: 0x00323EB4
	public void resetModelAction()
	{
		if (this.Holder1 == null)
		{
			return;
		}
		Animation component = this.Holder1.GetComponent<Animation>();
		if (component != null)
		{
			component[AnimationUnit.ANIM_STRING[0]].layer = 0;
			component[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
			component.Play(AnimationUnit.ANIM_STRING[0]);
		}
		if (this.Holder2 != null)
		{
			component = this.Holder2.GetComponent<Animation>();
			if (component != null)
			{
				component[AnimationUnit.ANIM_STRING[0]].layer = 0;
				component[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
				component.Play(AnimationUnit.ANIM_STRING[0]);
			}
		}
	}

	// Token: 0x06001C7E RID: 7294 RVA: 0x00325D7C File Offset: 0x00323F7C
	public override void OnClose()
	{
		UIHeroTalk.lockInput = false;
		GUIManager.Instance.m_WindowsTransform.gameObject.SetActive(true);
		this.Destory3DObject();
		StringManager.Instance.DeSpawnString(this.talkString);
		RenderSettings.ambientLight = this.EvoLight;
	}

	// Token: 0x06001C7F RID: 7295 RVA: 0x00325DC8 File Offset: 0x00323FC8
	private bool CheckCanSelectById(ushort id)
	{
		DataManager instance = DataManager.Instance;
		int num = 0;
		while ((long)num < (long)((ulong)instance.FightHeroCount))
		{
			if (instance.GetLeaderID() == id)
			{
				if (instance.beCaptured.nowCaptureStat == LoadCaptureState.Captured)
				{
					return false;
				}
				if (instance.beCaptured.nowCaptureStat == LoadCaptureState.Dead)
				{
					return false;
				}
			}
			if (instance.FightHeroID[num] == (uint)id)
			{
				return false;
			}
			num++;
		}
		return true;
	}

	// Token: 0x0400560F RID: 22031
	private Transform AGS_Form;

	// Token: 0x04005610 RID: 22032
	private Transform Pos3D1;

	// Token: 0x04005611 RID: 22033
	private Transform Pos3D2;

	// Token: 0x04005612 RID: 22034
	private Transform LightGroup;

	// Token: 0x04005613 RID: 22035
	private Transform PosLight1;

	// Token: 0x04005614 RID: 22036
	private Transform PosLight2;

	// Token: 0x04005615 RID: 22037
	private Transform PosLight3;

	// Token: 0x04005616 RID: 22038
	private Hero hero1;

	// Token: 0x04005617 RID: 22039
	private Hero hero2;

	// Token: 0x04005618 RID: 22040
	private int AssetKey1;

	// Token: 0x04005619 RID: 22041
	private int AssetKey2;

	// Token: 0x0400561A RID: 22042
	private UIHeroTalk.e_LoadingStep LoadingStep;

	// Token: 0x0400561B RID: 22043
	private AssetBundle bundle;

	// Token: 0x0400561C RID: 22044
	private AssetBundleRequest bundleRequest;

	// Token: 0x0400561D RID: 22045
	private GameObject Holder1;

	// Token: 0x0400561E RID: 22046
	private GameObject Holder2;

	// Token: 0x0400561F RID: 22047
	private static ushort HeroID1;

	// Token: 0x04005620 RID: 22048
	private static ushort HeroID2;

	// Token: 0x04005621 RID: 22049
	private ushort startTalkId;

	// Token: 0x04005622 RID: 22050
	private ushort nowTalkId;

	// Token: 0x04005623 RID: 22051
	private HeroTalkTbl talkData;

	// Token: 0x04005624 RID: 22052
	private CString talkString;

	// Token: 0x04005625 RID: 22053
	private Color EvoLight;

	// Token: 0x04005626 RID: 22054
	public static bool lockInput;

	// Token: 0x0200059C RID: 1436
	private enum e_AGS_UI_HeroTalk_Editor
	{
		// Token: 0x04005628 RID: 22056
		Back,
		// Token: 0x04005629 RID: 22057
		Panel,
		// Token: 0x0400562A RID: 22058
		T3DO1,
		// Token: 0x0400562B RID: 22059
		T3DO2,
		// Token: 0x0400562C RID: 22060
		Light,
		// Token: 0x0400562D RID: 22061
		Image,
		// Token: 0x0400562E RID: 22062
		Image2,
		// Token: 0x0400562F RID: 22063
		skip
	}

	// Token: 0x0200059D RID: 1437
	private enum e_AGS_Panel
	{
		// Token: 0x04005631 RID: 22065
		Text,
		// Token: 0x04005632 RID: 22066
		Title
	}

	// Token: 0x0200059E RID: 1438
	private enum e_AGS_Title
	{
		// Token: 0x04005634 RID: 22068
		Text
	}

	// Token: 0x0200059F RID: 1439
	private enum e_LoadingStep
	{
		// Token: 0x04005636 RID: 22070
		Nothing,
		// Token: 0x04005637 RID: 22071
		Ready,
		// Token: 0x04005638 RID: 22072
		WaitFirst,
		// Token: 0x04005639 RID: 22073
		WaitSecend,
		// Token: 0x0400563A RID: 22074
		Done
	}
}
