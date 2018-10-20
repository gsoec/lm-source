using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
internal class Pet3DLoader
{
	// Token: 0x06001706 RID: 5894 RVA: 0x0027B56C File Offset: 0x0027976C
	public Pet3DLoader(Transform transform, ushort id)
	{
		this.m_PetTransform = transform;
		this.ID = id;
		this.m_Str = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x06001707 RID: 5895 RVA: 0x0027B5F4 File Offset: 0x002797F4
	public void LoadPet()
	{
		this.sPet = PetManager.Instance.PetTable.GetRecordByKey(this.ID);
		this.sHero = DataManager.Instance.HeroTable.GetRecordByKey(this.sPet.HeroID);
		this.petData = PetManager.Instance.FindPetData(this.ID);
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)this.sHero.Modle, 5, false);
		cstring.AppendFormat("Role/hero_{0}");
		if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, this.sHero.Modle, false))
		{
			this.m_AssetBundle = AssetManager.GetAssetBundle(cstring, out this.AssetKey);
			if (this.m_AssetBundle != null)
			{
				this.m_ABRequest = this.m_AssetBundle.LoadAsync("m", typeof(GameObject));
				this.IsDone = false;
			}
		}
	}

	// Token: 0x06001708 RID: 5896 RVA: 0x0027B6E0 File Offset: 0x002798E0
	public void Update()
	{
		if (!this.IsDone && this.m_ABRequest != null && this.m_ABRequest.isDone && this.petData != null)
		{
			this.assetObject = ModelLoader.Instance.Load(this.sHero.Modle, this.m_AssetBundle, (ushort)this.sHero.TextureNo);
			this.assetObject.transform.SetParent(this.m_PetTransform, false);
			Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
			localRotation.eulerAngles = new Vector3(0f, 180f, 0f);
			this.assetObject.transform.localRotation = localRotation;
			if (!this.bMaxShow && (int)this.petData.Enhance < this.sPet.PetRatio.Length)
			{
				this.assetObject.transform.localScale = new Vector3((float)this.sPet.PetRatio[(int)this.petData.Enhance].Ratio, (float)this.sPet.PetRatio[(int)this.petData.Enhance].Ratio, (float)this.sPet.PetRatio[(int)this.petData.Enhance].Ratio);
			}
			else
			{
				this.assetObject.transform.localScale = new Vector3((float)this.sPet.StartupRatio.Ratio, (float)this.sPet.StartupRatio.Ratio, (float)this.sPet.StartupRatio.Ratio);
			}
			this.assetObject.transform.localPosition = Vector3.zero;
			GUIManager.Instance.SetLayer(this.assetObject, 5);
			if (!this.bMaxShow && (int)this.petData.Enhance < this.sPet.PetRatio.Length)
			{
				((RectTransform)this.m_PetTransform).anchoredPosition = new Vector2(((RectTransform)this.m_PetTransform).anchoredPosition.x, (float)(-140 - (int)(1000 - this.sPet.PetRatio[(int)this.petData.Enhance].UpDownDist)));
			}
			else
			{
				((RectTransform)this.m_PetTransform).anchoredPosition = new Vector2(((RectTransform)this.m_PetTransform).anchoredPosition.x, (float)(-140 - (int)(1000 - this.sPet.StartupRatio.UpDownDist)));
			}
			this.m_PetModel = this.m_PetTransform.GetChild(0);
			if (this.m_PetModel != null)
			{
				if (this.m_PetTransform.gameObject.activeSelf)
				{
					SkinnedMeshRenderer componentInChildren = this.m_PetModel.GetComponentInChildren<SkinnedMeshRenderer>();
					if (componentInChildren != null)
					{
						componentInChildren.useLightProbes = false;
						componentInChildren.updateWhenOffscreen = true;
					}
				}
				this.m_Animation = this.m_PetModel.GetComponent<Animation>();
				if (this.m_Animation != null)
				{
					this.m_Animation.wrapMode = WrapMode.Loop;
					AnimationState animationState = this.m_Animation[this.ANIM_STR[6]];
					if (animationState != null)
					{
						animationState.layer = 1;
						animationState.wrapMode = WrapMode.Loop;
						this.m_Animation.CrossFade(this.ANIM_STR[6]);
						this.m_Animation.clip = this.m_Animation.GetClip(this.ANIM_STR[6]);
					}
				}
			}
			this.IsDone = true;
		}
	}

	// Token: 0x06001709 RID: 5897 RVA: 0x0027BA80 File Offset: 0x00279C80
	public void Destory()
	{
		if (this.assetObject != null)
		{
			this.assetObject.transform.SetParent(this.m_PetTransform.parent, false);
			ModelLoader.Instance.Unload(this.assetObject);
			this.assetObject = null;
		}
		if (this.m_PetModel != null)
		{
			UnityEngine.Object.Destroy(this.m_PetModel);
			this.m_PetModel = null;
		}
		AssetManager.UnloadAssetBundle(this.AssetKey, true);
	}

	// Token: 0x0600170A RID: 5898 RVA: 0x0027BB00 File Offset: 0x00279D00
	private void RandAnimation()
	{
		if (this.m_Animation != null)
		{
			int num = UnityEngine.Random.Range(0, this.ANIM_STR.Length);
			this.m_Animation.wrapMode = WrapMode.Loop;
			AnimationState animationState = this.m_Animation[this.ANIM_STR[num]];
			if (animationState != null)
			{
				animationState.layer = 1;
				animationState.wrapMode = WrapMode.Loop;
				this.m_Animation.CrossFade(this.ANIM_STR[num]);
				this.m_Animation.clip = this.m_Animation.GetClip(this.ANIM_STR[num]);
			}
		}
	}

	// Token: 0x040044EF RID: 17647
	private string[] ANIM_STR = new string[]
	{
		"idle",
		"moving",
		"attack",
		"skill_1",
		"skill_2",
		"skill_3",
		"victory"
	};

	// Token: 0x040044F0 RID: 17648
	private AssetBundle m_AssetBundle;

	// Token: 0x040044F1 RID: 17649
	private AssetBundleRequest m_ABRequest;

	// Token: 0x040044F2 RID: 17650
	private int AssetKey;

	// Token: 0x040044F3 RID: 17651
	private bool IsDone = true;

	// Token: 0x040044F4 RID: 17652
	private Transform m_PetTransform;

	// Token: 0x040044F5 RID: 17653
	private Transform m_PetModel;

	// Token: 0x040044F6 RID: 17654
	private Animation m_Animation;

	// Token: 0x040044F7 RID: 17655
	private GameObject assetObject;

	// Token: 0x040044F8 RID: 17656
	private ushort ID;

	// Token: 0x040044F9 RID: 17657
	private float m_ChangeTime;

	// Token: 0x040044FA RID: 17658
	private CString m_Str;

	// Token: 0x040044FB RID: 17659
	private PetTbl sPet;

	// Token: 0x040044FC RID: 17660
	private Hero sHero;

	// Token: 0x040044FD RID: 17661
	private PetData petData;

	// Token: 0x040044FE RID: 17662
	private bool bMaxShow = true;
}
