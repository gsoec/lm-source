using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000527 RID: 1319
public class UIChapterRewards : GUIWindow, IUIButtonClickHandler, IUIHIBtnClickHandler
{
	// Token: 0x06001A49 RID: 6729 RVA: 0x002C93D0 File Offset: 0x002C75D0
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.mMaT = this.door.LoadMaterial();
		Chapter recordByKey = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort)arg1);
		this.sHero = this.DM.HeroTable.GetRecordByKey(recordByKey.HeroID);
		this.ShowHeroID = this.sHero.Modle;
		int num = 0;
		for (int i = 0; i < 5; i++)
		{
			if (recordByKey.Items[i].ItemID != 0)
			{
				num++;
			}
		}
		this.Hero_Pos = this.GameT.GetChild(0);
		this.Hero_PosRT = this.Hero_Pos.GetComponent<RectTransform>();
		this.text_tmpStr[0] = this.GameT.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID((uint)this.sHero.HeroTitle);
		this.text_tmpStr[1] = this.GameT.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID((uint)this.sHero.HeroName);
		this.Hbtn_Hero = this.GameT.GetChild(3).GetChild(2).GetComponent<UIHIBtn>();
		this.Hbtn_Hero.m_Handler = this;
		this.GUIM.InitianHeroItemImg(this.Hbtn_Hero.transform, eHeroOrItem.Item, recordByKey.Hero_ItemID, 0, 0, (int)recordByKey.Hero_ItemNum, true, true, true, false);
		this.text_Item = this.GameT.GetChild(3).GetChild(4).GetComponent<UIText>();
		this.text_Item.font = this.TTFont;
		this.Hbtn_go = this.GameT.GetChild(4).GetComponent<UIHIBtn>();
		this.Hbtn_go.m_Handler = this;
		this.Hbtn_go.SoundIndex = 64;
		this.GUIM.InitianHeroItemImg(this.Hbtn_go.transform, eHeroOrItem.Item, 0, 0, 0, 0, true, true, true, false);
		this.Img_Mask = this.GameT.GetChild(5).GetComponent<Image>();
		UIButtonHint.m_scrollRect = this.Img_Mask.transform.GetComponent<ScrollRect>();
		this.ContentRT = this.GameT.GetChild(5).GetChild(0).GetComponent<RectTransform>();
		float num2 = 10f;
		for (int j = 0; j < num; j++)
		{
			this.tmpGo = (GameObject)UnityEngine.Object.Instantiate(this.Hbtn_go.gameObject);
			this.tmpGo.transform.SetParent(this.ContentRT.transform, false);
			this.tmpRC = this.tmpGo.GetComponent<RectTransform>();
			this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x + (float)(93 * j), this.tmpRC.anchoredPosition.y);
			this.tmpGo.SetActive(true);
			num2 += 93f;
			this.GUIM.ChangeHeroItemImg(this.tmpGo.transform, eHeroOrItem.Item, recordByKey.Items[j].ItemID, 0, 0, (int)recordByKey.Items[j].ItemNum);
			this.Hbtn_Itme[j] = this.tmpGo.GetComponent<UIHIBtn>();
		}
		this.ContentRT.sizeDelta = new Vector2(num2, this.ContentRT.sizeDelta.y);
		this.Tmp = this.GameT.GetChild(7);
		this.Img_Chapter = this.Tmp.GetComponent<Image>();
		this.text_tmpStr[2] = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[2].font = this.TTFont;
		this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(1589u);
		this.Tmp = this.GameT.GetChild(8);
		this.Img_Rewards = this.Tmp.GetComponent<Image>();
		this.LightT1 = this.Tmp.GetChild(2);
		this.text_tmpStr[3] = this.Tmp.GetChild(3).GetComponent<UIText>();
		this.text_tmpStr[3].font = this.TTFont;
		this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(1591u);
		this.btn_Back = this.GameT.GetChild(10).GetComponent<UIButton>();
		this.btn_Back.m_Handler = this;
		this.btn_Back.m_BtnID1 = 1;
		this.btn_Back.m_EffectType = e_EffectType.e_Scale;
		this.btn_Back.transition = Selectable.Transition.None;
		this.Img_Exit = this.GameT.GetChild(11).GetComponent<Image>();
		this.Img_Exit.sprite = this.door.LoadSprite("UI_main_close_base");
		this.Img_Exit.material = this.mMaT;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Img_Exit.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(11).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.mMaT;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		if (arg2 == 0)
		{
			this.Img_Chapter.gameObject.SetActive(true);
			this.Img_Exit.gameObject.SetActive(true);
			this.btn_EXIT.gameObject.SetActive(true);
			this.text_Item.text = this.DM.mStringTable.GetStringByID(1590u);
		}
		else
		{
			this.Img_Rewards.gameObject.SetActive(true);
			this.btn_Back.gameObject.SetActive(true);
			this.text_Item.text = this.DM.mStringTable.GetStringByID(323u);
			AudioManager.Instance.PlayMP3SFX(41011, 0f);
		}
		this.Hero3D_Destroy();
		this.LoadHero3D();
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 1);
	}

	// Token: 0x06001A4A RID: 6730 RVA: 0x002C9ABC File Offset: 0x002C7CBC
	public void Hero3D_Destroy()
	{
		if (this.go2 != null)
		{
			this.go2.transform.SetParent(this.Hero_Pos.parent, false);
			UnityEngine.Object.Destroy(this.go2);
		}
		if (this.Hero_Model != null)
		{
			UnityEngine.Object.Destroy(this.Hero_Model);
		}
		this.Hero_Model = null;
		this.go2 = null;
		AssetManager.UnloadAssetBundle(this.AssetKey, false);
	}

	// Token: 0x06001A4B RID: 6731 RVA: 0x002C9B38 File Offset: 0x002C7D38
	public void LoadHero3D()
	{
		this.ActionTime = 0f;
		this.ActionTimeRandom = 2f;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)this.sHero.Modle, 5, false);
		cstring.AppendFormat("Role/hero_{0}");
		if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, this.sHero.Modle, false))
		{
			this.AB = AssetManager.GetAssetBundle(cstring, out this.AssetKey);
			if (this.AB != null)
			{
				this.AR = this.AB.LoadAsync("m", typeof(GameObject));
				this.ABIsDone = false;
			}
		}
		else
		{
			this.AR = null;
		}
	}

	// Token: 0x06001A4C RID: 6732 RVA: 0x002C9BF8 File Offset: 0x002C7DF8
	public void HeroActionChang()
	{
		if (this.ABIsDone && this.Hero_Model != null)
		{
			this.tmpAN = this.Hero_Model.GetComponent<Animation>();
			this.tmpAN.wrapMode = WrapMode.Loop;
			if (this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[2]) != null)
			{
				this.HeroAct = AnimationUnit.ANIM_STRING[2];
				this.tmpAN[AnimationUnit.ANIM_STRING[2]].layer = 1;
				this.tmpAN[AnimationUnit.ANIM_STRING[2]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[3]) != null)
			{
				this.HeroAct = AnimationUnit.ANIM_STRING[3];
				this.tmpAN[AnimationUnit.ANIM_STRING[3]].layer = 1;
				this.tmpAN[AnimationUnit.ANIM_STRING[3]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[4]) != null)
			{
				this.HeroAct = AnimationUnit.ANIM_STRING[4];
				this.tmpAN[AnimationUnit.ANIM_STRING[4]].layer = 1;
				this.tmpAN[AnimationUnit.ANIM_STRING[4]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[5]) != null)
			{
				this.HeroAct = AnimationUnit.ANIM_STRING[5];
				this.tmpAN[AnimationUnit.ANIM_STRING[5]].layer = 1;
				this.tmpAN[AnimationUnit.ANIM_STRING[5]].wrapMode = WrapMode.Once;
			}
			int num = UnityEngine.Random.Range(1, 6);
			AnimationClip animationClip = this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[(int)((byte)num)]);
			this.HeroAct = AnimationUnit.ANIM_STRING[(int)((byte)num)];
			if (num == 3)
			{
				AnimationClip clip = this.tmpAN.GetClip(this.HeroAct + "_ch");
				if (clip != null)
				{
					animationClip = null;
				}
			}
			if (animationClip != null)
			{
				this.tmpAN.CrossFade(animationClip.name);
				this.MovingTimer = 0f;
				if (num == 1)
				{
					this.MovingTimer = 2f;
				}
			}
			this.ActionTimeRandom = 0f;
			this.ActionTime = 0f;
		}
	}

	// Token: 0x06001A4D RID: 6733 RVA: 0x002C9E54 File Offset: 0x002C8054
	public override void OnClose()
	{
	}

	// Token: 0x06001A4E RID: 6734 RVA: 0x002C9E58 File Offset: 0x002C8058
	public void OnButtonClick(UIButton sender)
	{
		ChapterRewards_btn btnID = (ChapterRewards_btn)sender.m_BtnID1;
		if (btnID != ChapterRewards_btn.btn_EXIT)
		{
			if (btnID == ChapterRewards_btn.btn_Back)
			{
				if (DataManager.StageDataController.limitRecord[(int)DataManager.StageDataController._stageMode] > DataManager.StageDataController.StageRecord[(int)DataManager.StageDataController._stageMode])
				{
					DataManager.StageDataController.isNotFirstInChapter[(int)DataManager.StageDataController._stageMode] = 0;
					DataManager.StageDataController.SaveisNotFirstInChapter();
				}
				DataManager.msgBuffer[0] = 39;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
		}
		else if (this.door != null)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001A4F RID: 6735 RVA: 0x002C9F0C File Offset: 0x002C810C
	public override bool OnBackButtonClick()
	{
		if (this.btn_Back.IsActive())
		{
			if (DataManager.StageDataController.limitRecord[(int)DataManager.StageDataController._stageMode] > DataManager.StageDataController.StageRecord[(int)DataManager.StageDataController._stageMode])
			{
				DataManager.StageDataController.isNotFirstInChapter[(int)DataManager.StageDataController._stageMode] = 0;
				DataManager.StageDataController.SaveisNotFirstInChapter();
			}
			DataManager.msgBuffer[0] = 39;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			return true;
		}
		return false;
	}

	// Token: 0x06001A50 RID: 6736 RVA: 0x002C9F90 File Offset: 0x002C8190
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06001A51 RID: 6737 RVA: 0x002C9F94 File Offset: 0x002C8194
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
			break;
		case NetworkNews.Refresh_Asset:
			if (meg[1] == 1 && meg[2] == 2 && GameConstants.ConvertBytesToUShort(meg, 3) == this.ShowHeroID)
			{
				this.Hero3D_Destroy();
				this.LoadHero3D();
			}
			break;
		}
	}

	// Token: 0x06001A52 RID: 6738 RVA: 0x002CA010 File Offset: 0x002C8210
	public void Refresh_FontTexture()
	{
		if (this.text_Item != null && this.text_Item.enabled)
		{
			this.text_Item.enabled = false;
			this.text_Item.enabled = true;
		}
		for (int i = 0; i < 4; i++)
		{
			if (this.text_tmpStr[i] != null && this.text_tmpStr[i].enabled)
			{
				this.text_tmpStr[i].enabled = false;
				this.text_tmpStr[i].enabled = true;
			}
		}
		if (this.Hbtn_Hero != null && this.Hbtn_Hero.enabled)
		{
			this.Hbtn_Hero.Refresh_FontTexture();
		}
		if (this.Hbtn_go != null && this.Hbtn_go.enabled)
		{
			this.Hbtn_go.Refresh_FontTexture();
		}
		for (int j = 0; j < 5; j++)
		{
			if (this.Hbtn_Itme[j] != null && this.Hbtn_Itme[j].enabled)
			{
				this.Hbtn_Itme[j].Refresh_FontTexture();
			}
		}
	}

	// Token: 0x06001A53 RID: 6739 RVA: 0x002CA148 File Offset: 0x002C8348
	private void Start()
	{
	}

	// Token: 0x06001A54 RID: 6740 RVA: 0x002CA14C File Offset: 0x002C834C
	private void Update()
	{
		if (this.LightT1 != null)
		{
			this.LightT1.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		if (!this.ABIsDone && this.AR != null && this.AR.isDone)
		{
			this.go2 = (GameObject)UnityEngine.Object.Instantiate(this.AR.asset);
			this.go2.transform.SetParent(this.Hero_Pos, false);
			Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
			localRotation.eulerAngles = new Vector3(0f, (float)this.sHero.Camera_Horizontal, 0f);
			this.go2.transform.localRotation = localRotation;
			this.go2.transform.localScale = new Vector3((float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate);
			this.go2.transform.localPosition = Vector3.zero;
			this.GUIM.SetLayer(this.go2, 5);
			this.Hero_PosRT.anchoredPosition = new Vector2(this.Hero_PosRT.anchoredPosition.x, (float)(-180 - (int)(1000 - this.sHero.CameraDistance)));
			this.Tmp = this.Hero_Pos.GetChild(0);
			this.Hero_Model = this.Tmp.GetComponent<Transform>();
			if (this.Hero_Model != null)
			{
				this.tmpAN = this.Hero_Model.GetComponent<Animation>();
				this.tmpAN.wrapMode = WrapMode.Loop;
				this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
				this.tmpAN.Play(AnimationUnit.ANIM_STRING[0]);
				this.tmpAN.clip = this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[0]);
				if (this.Hero_Pos.gameObject.activeSelf)
				{
					SkinnedMeshRenderer componentInChildren = this.Hero_Model.GetComponentInChildren<SkinnedMeshRenderer>();
					componentInChildren.useLightProbes = false;
					componentInChildren.updateWhenOffscreen = true;
				}
			}
			this.ABIsDone = true;
		}
		if (this.ABIsDone && this.Hero_Model != null && (!this.tmpAN.IsPlaying(this.HeroAct) || this.HeroAct == "idle") && (double)this.ActionTimeRandom < 0.0001)
		{
			this.ActionTimeRandom = (float)UnityEngine.Random.Range(3, 7);
			this.ActionTime = 0f;
		}
		if ((double)this.ActionTimeRandom > 0.0001)
		{
			this.ActionTime += Time.smoothDeltaTime;
			if (this.ActionTime >= this.ActionTimeRandom)
			{
				this.HeroActionChang();
			}
		}
		if (this.ABIsDone && this.Hero_Model != null && this.MovingTimer > 0f)
		{
			this.MovingTimer -= Time.deltaTime;
			if (this.MovingTimer <= 0f)
			{
				this.tmpAN.CrossFade("idle");
				this.HeroAct = "idle";
			}
		}
	}

	// Token: 0x04004DDC RID: 19932
	private Transform GameT;

	// Token: 0x04004DDD RID: 19933
	private Transform Tmp;

	// Token: 0x04004DDE RID: 19934
	private Transform Hero_Model;

	// Token: 0x04004DDF RID: 19935
	private Transform Hero_Pos;

	// Token: 0x04004DE0 RID: 19936
	private Transform LightT1;

	// Token: 0x04004DE1 RID: 19937
	private RectTransform Hero_PosRT;

	// Token: 0x04004DE2 RID: 19938
	private RectTransform ContentRT;

	// Token: 0x04004DE3 RID: 19939
	private RectTransform tmpRC;

	// Token: 0x04004DE4 RID: 19940
	private UIButton btn_EXIT;

	// Token: 0x04004DE5 RID: 19941
	private UIButton btn_Back;

	// Token: 0x04004DE6 RID: 19942
	private UIHIBtn[] Hbtn_Itme = new UIHIBtn[5];

	// Token: 0x04004DE7 RID: 19943
	private UIHIBtn Hbtn_go;

	// Token: 0x04004DE8 RID: 19944
	private UIHIBtn Hbtn_Hero;

	// Token: 0x04004DE9 RID: 19945
	private Image Img_Mask;

	// Token: 0x04004DEA RID: 19946
	private Image Img_Rewards;

	// Token: 0x04004DEB RID: 19947
	private Image Img_Chapter;

	// Token: 0x04004DEC RID: 19948
	private Image Img_Exit;

	// Token: 0x04004DED RID: 19949
	private UIText text_Item;

	// Token: 0x04004DEE RID: 19950
	private UIText[] text_tmpStr = new UIText[4];

	// Token: 0x04004DEF RID: 19951
	private DataManager DM;

	// Token: 0x04004DF0 RID: 19952
	private GUIManager GUIM;

	// Token: 0x04004DF1 RID: 19953
	private Font TTFont;

	// Token: 0x04004DF2 RID: 19954
	private Door door;

	// Token: 0x04004DF3 RID: 19955
	private Material mMaT;

	// Token: 0x04004DF4 RID: 19956
	private Hero sHero;

	// Token: 0x04004DF5 RID: 19957
	private AssetBundle AB;

	// Token: 0x04004DF6 RID: 19958
	private AssetBundleRequest AR;

	// Token: 0x04004DF7 RID: 19959
	private bool ABIsDone;

	// Token: 0x04004DF8 RID: 19960
	private GameObject go2;

	// Token: 0x04004DF9 RID: 19961
	private int AssetKey;

	// Token: 0x04004DFA RID: 19962
	private Animation tmpAN;

	// Token: 0x04004DFB RID: 19963
	private GameObject tmpGo;

	// Token: 0x04004DFC RID: 19964
	private string HeroAct;

	// Token: 0x04004DFD RID: 19965
	private float MovingTimer;

	// Token: 0x04004DFE RID: 19966
	private float ActionTime;

	// Token: 0x04004DFF RID: 19967
	private float ActionTimeRandom;

	// Token: 0x04004E00 RID: 19968
	public ushort ShowHeroID;
}
