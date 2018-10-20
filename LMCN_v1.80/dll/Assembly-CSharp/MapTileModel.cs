using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200026A RID: 618
public class MapTileModel
{
	// Token: 0x06000B4E RID: 2894 RVA: 0x001061A0 File Offset: 0x001043A0
	public MapTileModel(Transform realmGroup, float tileBaseScale)
	{
		this.mapTileModelUpdateDelegate = new MapTileModel.MapTileModelUpdateDelegate[4];
		this.mapTileModelUpdateDelegate[0] = new MapTileModel.MapTileModelUpdateDelegate(this.NoneState);
		this.mapTileModelUpdateDelegate[1] = new MapTileModel.MapTileModelUpdateDelegate(this.Debut);
		this.mapTileModelUpdateDelegate[2] = new MapTileModel.MapTileModelUpdateDelegate(this.Show);
		this.mapTileModelUpdateDelegate[3] = new MapTileModel.MapTileModelUpdateDelegate(this.Exit);
		GameObject gameObject = new GameObject("MapTileModel");
		this.ModelLayoutTransform = gameObject.transform;
		this.RealmGroup = realmGroup;
		this.ModelLayoutTransform.localScale = Vector3.one * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
		this.ModelLayoutTransform.position = Vector3.forward * 33f;
		this.ModelLayoutTransform.SetParent(realmGroup, false);
		gameObject = new GameObject("MapTileModelEffect");
		this.AllEffectTransform = gameObject.transform;
		this.AllEffectTransform.SetParent(this.ModelLayoutTransform, false);
	}

	// Token: 0x06000B4F RID: 2895 RVA: 0x001063AC File Offset: 0x001045AC
	public void OnDestroy()
	{
		this.Effects.Clear();
		this.EffectTimes.Clear();
		this.EffectsIDs.Clear();
		if (this.EffectAssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.EffectAssetKey, true);
			this.EffectAssetKey = 0;
		}
		if (this.WeaponParticleGameObject != null)
		{
			UnityEngine.Object.Destroy(this.WeaponParticleGameObject);
			this.WeaponParticleGameObject = null;
			this.WeaponParticle = null;
			this.WeaponParticleID = 0u;
		}
		if (this.AllEffectTransform != null)
		{
			UnityEngine.Object.Destroy(this.AllEffectTransform.gameObject);
			this.AllEffectTransform = null;
		}
		if (this.WeaponAssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.WeaponAssetKey, true);
			this.WeaponAssetKey = 0;
		}
		if (this.WeaponTransform != null)
		{
			ModelLoader.Instance.Unload(this.WeaponTransform.gameObject);
			this.hitParticleRoot = null;
			this.flyRoot = null;
			this.WeaponTransform = null;
		}
		if (this.WeaponLightTransform != null)
		{
			UnityEngine.Object.Destroy(this.WeaponLightTransform.gameObject);
			this.WeaponLightTransform = null;
		}
		if (this.UpImageRectTransform != null)
		{
			UnityEngine.Object.Destroy(this.UpImageRectTransform.gameObject);
			this.UpImageRectTransform = null;
		}
		if (this.DownImageRectTransform != null)
		{
			UnityEngine.Object.Destroy(this.DownImageRectTransform.gameObject);
			this.DownImageRectTransform = null;
		}
	}

	// Token: 0x06000B50 RID: 2896 RVA: 0x00106524 File Offset: 0x00104724
	public void MapTileModelUpdate()
	{
		this.mapTileModelUpdateDelegate[(int)this.mapWeaponState]();
		this.MapWeaponEffectParticleUpdate();
	}

	// Token: 0x06000B51 RID: 2897 RVA: 0x00106540 File Offset: 0x00104740
	public bool SetWeaponResources(ushort MapWeaponID, ushort MapSkillID)
	{
		if (MapWeaponID < 1)
		{
			MapWeaponID = 1;
		}
		if (this.WeaponModelID != MapWeaponID)
		{
			if (this.WeaponAssetKey != 0)
			{
				AssetManager.UnloadAssetBundle(this.WeaponAssetKey, true);
				this.WeaponAssetKey = 0;
			}
			if (this.WeaponTransform != null)
			{
				ModelLoader.Instance.Unload(this.WeaponTransform.gameObject);
				this.WeaponTransform = null;
			}
			this.WeaponModelID = MapWeaponID;
		}
		PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey(MapSkillID);
		MapDamageEffTb recordByKey2 = PetManager.Instance.MapDamageEffTable.GetRecordByKey(recordByKey.DamageRange);
		this.DebutID = recordByKey2.BeginID;
		this.ShowID = recordByKey2.AttackID;
		this.ExitID = recordByKey2.EndID;
		this.LoadShowData();
		CString cstring = StringManager.Instance.SpawnString(30);
		if (this.WeaponTransform == null)
		{
			Hero recordByKey3 = DataManager.Instance.HeroTable.GetRecordByKey(this.WeaponModelID);
			cstring.ClearString();
			cstring.StringToFormat("Role/hero_");
			cstring.IntToFormat((long)recordByKey3.Modle, 5, false);
			cstring.AppendFormat("{0}{1}");
			if (!AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, recordByKey3.Modle, true))
			{
				return false;
			}
			AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.WeaponAssetKey);
			if (assetBundle == null)
			{
				return false;
			}
			GameObject gameObject = ModelLoader.Instance.Load(recordByKey3.Modle, assetBundle, (ushort)recordByKey3.TextureNo);
			if (gameObject == null)
			{
				return false;
			}
			this.WeaponTransform = gameObject.transform;
			this.WeaponTransform.SetParent(this.ModelLayoutTransform, true);
			this.WeaponTransform.localPosition = Vector3.zero;
			this.WeaponTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
			this.WeaponAnimation = gameObject.GetComponent<Animation>();
			this.WeaponAnimation.wrapMode = WrapMode.Loop;
			this.WeaponAnimation.Stop();
			Transform child = this.WeaponTransform.GetChild(0);
			Transform[] componentsInChildren = this.WeaponTransform.gameObject.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].name == AnimationUnit.HIT_POINT_ROOTBONE)
				{
					this.hitParticleRoot = componentsInChildren[i];
					if (!(this.flyRoot == null))
					{
						break;
					}
				}
				else if (componentsInChildren[i].name == AnimationUnit.FLY_WEAPON_ROOTBONE)
				{
					this.flyRoot = componentsInChildren[i];
					if (!(this.hitParticleRoot == null))
					{
						break;
					}
				}
			}
			if (this.hitParticleRoot == null)
			{
				this.hitParticleRoot = child;
			}
			if (this.flyRoot == null)
			{
				this.flyRoot = child;
			}
			gameObject.SetActive(false);
		}
		if (this.WeaponLightTransform == null)
		{
			GameObject gameObject = new GameObject("WeaponLight");
			this.WeaponLight = gameObject.AddComponent<Light>();
			this.WeaponLight.type = LightType.Directional;
			this.WeaponLightTransform = gameObject.transform;
			this.WeaponLightTransform.SetParent(this.ModelLayoutTransform, true);
			this.WeaponLightTransform.localPosition = Vector3.zero;
			this.WeaponLightTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			gameObject.SetActive(false);
		}
		if (this.UpImageRectTransform == null)
		{
			GameObject gameObject = new GameObject("upImage");
			this.UpImage = gameObject.AddComponent<Image>();
			int j;
			for (j = 0; j < AssetManager.Instance.Shaders.Length; j++)
			{
				if (AssetManager.Instance.Shaders[j].name == "zTWRD2 Shaders/UI/Sprites")
				{
					this.UpImage.material = new Material((Shader)AssetManager.Instance.Shaders[j]);
					this.UpImage.material.renderQueue = 3100;
					break;
				}
			}
			this.UpImage.color = new Color(0f, 0f, 0f, 1f);
			this.UpImageRectTransform = gameObject.GetComponent<RectTransform>();
			RectTransform rectTransform = GUIManager.Instance.m_UICanvas.transform as RectTransform;
			Vector2 sizeDelta = rectTransform.sizeDelta;
			sizeDelta.y *= 0.5f;
			this.UpImageRectTransform.sizeDelta = sizeDelta;
			this.UpImageRectTransform.SetParent(GUIManager.Instance.m_FourthWindowLayer, false);
			Vector2 zero = Vector2.zero;
			zero.y += sizeDelta.y * 1.5f;
			this.UpImageRectTransform.anchoredPosition = zero;
			gameObject.SetActive(false);
			gameObject = new GameObject("downImage");
			this.DownImage = gameObject.AddComponent<Image>();
			this.DownImage.material = new Material((Shader)AssetManager.Instance.Shaders[j]);
			this.DownImage.material.renderQueue = 3100;
			this.DownImage.color = new Color(0f, 0f, 0f, 1f);
			this.DownImageRectTransform = gameObject.GetComponent<RectTransform>();
			this.DownImageRectTransform.sizeDelta = sizeDelta;
			this.DownImageRectTransform.SetParent(GUIManager.Instance.m_FourthWindowLayer, false);
			zero.y -= sizeDelta.y * 3f;
			this.DownImageRectTransform.anchoredPosition = zero;
			gameObject.SetActive(false);
		}
		if (this.EffectAssetBundle == null)
		{
			this.EffectAssetBundle = AssetManager.GetAssetBundle("Particle/Monster_Effects_604", out this.EffectAssetKey, false);
		}
		StringManager.Instance.DeSpawnString(cstring);
		return true;
	}

	// Token: 0x06000B52 RID: 2898 RVA: 0x00106B1C File Offset: 0x00104D1C
	public void startDebut(float RotationY = 0f)
	{
		this.WeaponTransform.gameObject.SetActive(true);
		this.WeaponLightTransform.gameObject.SetActive(true);
		this.UpImageRectTransform.gameObject.SetActive(true);
		this.DownImageRectTransform.gameObject.SetActive(true);
		ShowKindToShowMap recordByKey = this.ShowKindToShowMapTable.GetRecordByKey(this.DebutID);
		if (RotationY > 360f)
		{
			RotationY -= 360f;
		}
		else if (RotationY < 0f)
		{
			RotationY += 360f;
		}
		this.WeaponRotationOffSetY = RotationY;
		this.WeaponRotationOffSetX = (this.WeaponRotationOffSetZ = 0f);
		this.WeaponRotationOffSetKeyFrameID = recordByKey.ShowKind12ID;
		if (this.WeaponRotationOffSetKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationOffSetKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (vector.x > 360f)
			{
				vector.x -= 360f;
			}
			else if (vector.x < 0f)
			{
				vector.x += 360f;
			}
			float num = this.WeaponRotationOffSetY;
			num += 180f;
			if (num > 360f)
			{
				num -= 360f;
			}
			else if (num < 0f)
			{
				num += 360f;
			}
			if (num > 180f)
			{
				num = 360f - num;
			}
			this.WeaponRotationOffSetX = num * vector.x * 0.0111111114f - vector.x;
			if (Mathf.Abs(this.WeaponRotationOffSetX) < 0.01f)
			{
				this.WeaponRotationOffSetX = 0f;
			}
			num = this.WeaponRotationOffSetY;
			num += 90f;
			if (num > 360f)
			{
				num -= 360f;
			}
			else if (num < 0f)
			{
				num += 360f;
			}
			if (num > 180f)
			{
				num = 360f - num;
			}
			this.WeaponRotationOffSetZ = num * vector.x * 0.0111111114f - vector.x;
			if (Mathf.Abs(this.WeaponRotationOffSetZ) < 0.01f)
			{
				this.WeaponRotationOffSetZ = 0f;
			}
			this.WeaponRotationOffSetTime = 0f;
			this.WeaponRotationOffSetTimeTarget = recordByKey2.ShowTime * 0.0001f;
		}
		this.WeaponAnimationKeyFrameID = recordByKey.ShowKind0ID;
		if (this.WeaponAnimationKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponAnimationKeyFrameID);
			ShowAnimation recordByKey4 = this.ShowAnimationTable.GetRecordByKey(recordByKey2.ListID);
			this.SetWeaponAnimation((AnimationUnit.AnimName)recordByKey4.AnimationNameID, (WrapMode)recordByKey4.WrapModeID, recordByKey2.ShowTime * 0.0001f, (float)recordByKey4.AnimationSpeed * 0.0001f, (float)recordByKey4.AnimationTime * 0.0001f);
		}
		this.WeaponScaleKeyFrameID = recordByKey.ShowKind1ID;
		if (this.WeaponScaleKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponScaleKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponScale(vector.x, vector.x, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponScale(vector.x, vector2.x, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponRotationKeyFrameID = recordByKey.ShowKind2ID;
		if (this.WeaponRotationKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponRotation(vector.x, vector.y, vector.z, vector.x, vector.y, vector.z, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponRotation(vector.x, vector.y, vector.z, vector2.x, vector2.y, vector2.z, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponPositionKeyFrameID = recordByKey.ShowKind3ID;
		if (this.WeaponPositionKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponPositionKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponPosition(vector.x, vector.y, vector.z, vector.x, vector.y, vector.z, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponPosition(vector.x, vector.y, vector.z, vector2.x, vector2.y, vector2.z, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponLightKeyFrameID = recordByKey.ShowKind4ID;
		this.WeaponLightColorKeyFrameID = recordByKey.ShowKind7ID;
		if (this.WeaponLightColorKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightKeyFrameID);
			ShowLight recordByKey6 = this.ShowLightTable.GetRecordByKey(recordByKey2.ListID);
			LightType showLightType = (LightType)recordByKey6.ShowLightType;
			float weaponLightIntensity = (float)recordByKey6.ShowLightIntensity * 0.0001f;
			recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightColorKeyFrameID);
			ShowColor recordByKey7 = this.ShowColorTable.GetRecordByKey(recordByKey2.ListID);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				ShowColor recordByKey8 = this.ShowColorTable.GetRecordByKey(recordByKey5.ListID);
				this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, recordByKey8.ColorR, recordByKey8.ColorG, recordByKey8.ColorB, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponLightRotationKeyFrameID = recordByKey.ShowKind5ID;
		if (this.WeaponLightRotationKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightRotationKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponLightRotation(vector.x, vector.y, vector.z, vector.x, vector.y, vector.z, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponLightRotation(vector.x, vector.y, vector.z, vector2.x, vector2.y, vector2.z, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponLightPositionKeyFrameID = recordByKey.ShowKind6ID;
		if (this.WeaponLightPositionKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightPositionKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponLightPosition(vector.x, vector.y, vector.x, vector.y, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponLightPosition(vector.x, vector.y, vector2.x, vector2.y, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.UpDownImagePositionKeyFrameID = recordByKey.ShowKind8ID;
		if (this.UpDownImagePositionKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.UpDownImagePositionKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetScreenEffectPosition(vector.y, vector.y, vector.z <= 0f, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetScreenEffectPosition(vector.y, vector2.y, vector2.z <= 0f, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.UpDownImageColorKeyFrameID = recordByKey.ShowKind9ID;
		if (this.UpDownImageColorKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.UpDownImageColorKeyFrameID);
			ShowColor recordByKey7 = this.ShowColorTable.GetRecordByKey(recordByKey2.ListID);
			if (recordByKey2.NextListID == 0)
			{
				this.SetScreenEffectColor(recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, (byte)recordByKey7.ColorA, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, (byte)recordByKey7.ColorA, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				ShowColor recordByKey8 = this.ShowColorTable.GetRecordByKey(recordByKey5.ListID);
				this.SetScreenEffectColor(recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, (byte)recordByKey7.ColorA, recordByKey8.ColorR, recordByKey8.ColorG, recordByKey8.ColorB, (byte)recordByKey8.ColorA, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponParticleKeyFrameID = recordByKey.ShowKind10ID;
		if (this.WeaponParticleKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponParticleKeyFrameID);
			ShowEffectSound recordByKey9 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey2.ListID);
			this.SetWeaponParticle(recordByKey9.EffectSoundID, (int)recordByKey9.AttackMode, recordByKey2.ShowTime * 0.0001f);
		}
		this.WeaponSoundKeyFrameID = recordByKey.ShowKind11ID;
		if (this.WeaponSoundKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponSoundKeyFrameID);
			ShowEffectSound recordByKey9 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey2.ListID);
			this.SetWeaponSound(recordByKey9.EffectSoundID, (int)recordByKey9.AttackMode, recordByKey2.ShowTime * 0.0001f);
		}
		this.mapWeaponState = MapTileModel.MapWeaponState.Debut;
		this.CheckNextState();
	}

	// Token: 0x06000B53 RID: 2899 RVA: 0x00107804 File Offset: 0x00105A04
	public void startShow(ushort showID)
	{
		ShowKindToShowMap recordByKey = this.ShowKindToShowMapTable.GetRecordByKey(showID);
		this.WeaponRotationOffSetX = (this.WeaponRotationOffSetZ = 0f);
		this.WeaponRotationOffSetKeyFrameID = recordByKey.ShowKind12ID;
		if (this.WeaponRotationOffSetKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationOffSetKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (vector.x > 360f)
			{
				vector.x -= 360f;
			}
			else if (vector.x < 0f)
			{
				vector.x += 360f;
			}
			float num = this.WeaponRotationOffSetY;
			num += 180f;
			if (num > 360f)
			{
				num -= 360f;
			}
			else if (num < 0f)
			{
				num += 360f;
			}
			if (num > 180f)
			{
				num = 360f - num;
			}
			this.WeaponRotationOffSetX = num * vector.x * 0.0111111114f - vector.x;
			if (Mathf.Abs(this.WeaponRotationOffSetX) < 0.01f)
			{
				this.WeaponRotationOffSetX = 0f;
			}
			num = this.WeaponRotationOffSetY;
			num += 90f;
			if (num > 360f)
			{
				num -= 360f;
			}
			else if (num < 0f)
			{
				num += 360f;
			}
			if (num > 180f)
			{
				num = 360f - num;
			}
			this.WeaponRotationOffSetZ = num * vector.x * 0.0111111114f - vector.x;
			if (Mathf.Abs(this.WeaponRotationOffSetZ) < 0.01f)
			{
				this.WeaponRotationOffSetZ = 0f;
			}
			this.WeaponRotationOffSetTime = 0f;
			this.WeaponRotationOffSetTimeTarget = recordByKey2.ShowTime * 0.0001f;
		}
		this.WeaponAnimationKeyFrameID = recordByKey.ShowKind0ID;
		if (this.WeaponAnimationKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponAnimationKeyFrameID);
			ShowAnimation recordByKey4 = this.ShowAnimationTable.GetRecordByKey(recordByKey2.ListID);
			this.SetWeaponAnimation((AnimationUnit.AnimName)recordByKey4.AnimationNameID, (WrapMode)recordByKey4.WrapModeID, recordByKey2.ShowTime * 0.0001f, (float)recordByKey4.AnimationSpeed * 0.0001f, (float)recordByKey4.AnimationTime * 0.0001f);
		}
		this.WeaponScaleKeyFrameID = recordByKey.ShowKind1ID;
		if (this.WeaponScaleKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponScaleKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponScale(vector.x, vector.x, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponScale(vector.x, vector2.x, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponRotationKeyFrameID = recordByKey.ShowKind2ID;
		if (this.WeaponRotationKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponRotation(vector.x, vector.y, vector.z, vector.x, vector.y, vector.z, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponRotation(vector.x, vector.y, vector.z, vector2.x, vector2.y, vector2.z, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponPositionKeyFrameID = recordByKey.ShowKind3ID;
		if (this.WeaponPositionKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponPositionKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponPosition(vector.x, vector.y, vector.z, vector.x, vector.y, vector.z, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponPosition(vector.x, vector.y, vector.z, vector2.x, vector2.y, vector2.z, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponLightKeyFrameID = recordByKey.ShowKind4ID;
		this.WeaponLightColorKeyFrameID = recordByKey.ShowKind7ID;
		if (this.WeaponLightColorKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightKeyFrameID);
			ShowLight recordByKey6 = this.ShowLightTable.GetRecordByKey(recordByKey2.ListID);
			LightType showLightType = (LightType)recordByKey6.ShowLightType;
			float weaponLightIntensity = (float)recordByKey6.ShowLightIntensity * 0.0001f;
			recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightColorKeyFrameID);
			ShowColor recordByKey7 = this.ShowColorTable.GetRecordByKey(recordByKey2.ListID);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				ShowColor recordByKey8 = this.ShowColorTable.GetRecordByKey(recordByKey5.ListID);
				this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, recordByKey8.ColorR, recordByKey8.ColorG, recordByKey8.ColorB, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponLightRotationKeyFrameID = recordByKey.ShowKind5ID;
		if (this.WeaponLightRotationKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightRotationKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponLightRotation(vector.x, vector.y, vector.z, vector.x, vector.y, vector.z, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponLightRotation(vector.x, vector.y, vector.z, vector2.x, vector2.y, vector2.z, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponLightPositionKeyFrameID = recordByKey.ShowKind6ID;
		if (this.WeaponLightPositionKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightPositionKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponLightPosition(vector.x, vector.y, vector.x, vector.y, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponLightPosition(vector.x, vector.y, vector2.x, vector2.y, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.UpDownImagePositionKeyFrameID = recordByKey.ShowKind8ID;
		if (this.UpDownImagePositionKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.UpDownImagePositionKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetScreenEffectPosition(vector.y, vector.y, vector.z <= 0f, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetScreenEffectPosition(vector.y, vector2.y, vector2.z <= 0f, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.UpDownImageColorKeyFrameID = recordByKey.ShowKind9ID;
		if (this.UpDownImageColorKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.UpDownImageColorKeyFrameID);
			ShowColor recordByKey7 = this.ShowColorTable.GetRecordByKey(recordByKey2.ListID);
			if (recordByKey2.NextListID == 0)
			{
				this.SetScreenEffectColor(recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, (byte)recordByKey7.ColorA, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, (byte)recordByKey7.ColorA, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				ShowColor recordByKey8 = this.ShowColorTable.GetRecordByKey(recordByKey5.ListID);
				this.SetScreenEffectColor(recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, (byte)recordByKey7.ColorA, recordByKey8.ColorR, recordByKey8.ColorG, recordByKey8.ColorB, (byte)recordByKey8.ColorA, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponParticleKeyFrameID = recordByKey.ShowKind10ID;
		if (this.WeaponParticleKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponParticleKeyFrameID);
			ShowEffectSound recordByKey9 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey2.ListID);
			this.SetWeaponParticle(recordByKey9.EffectSoundID, (int)recordByKey9.AttackMode, recordByKey2.ShowTime * 0.0001f);
		}
		this.WeaponSoundKeyFrameID = recordByKey.ShowKind11ID;
		if (this.WeaponSoundKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponSoundKeyFrameID);
			ShowEffectSound recordByKey9 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey2.ListID);
			this.SetWeaponParticle(recordByKey9.EffectSoundID, (int)recordByKey9.AttackMode, recordByKey2.ShowTime * 0.0001f);
		}
		this.mapWeaponState = MapTileModel.MapWeaponState.Show;
		this.CheckNextState();
	}

	// Token: 0x06000B54 RID: 2900 RVA: 0x0010846C File Offset: 0x0010666C
	public void startExit(ushort exitID)
	{
		ShowKindToShowMap recordByKey = this.ShowKindToShowMapTable.GetRecordByKey(exitID);
		this.WeaponRotationOffSetX = (this.WeaponRotationOffSetZ = 0f);
		this.WeaponRotationOffSetKeyFrameID = recordByKey.ShowKind12ID;
		if (this.WeaponRotationOffSetKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationOffSetKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (vector.x > 360f)
			{
				vector.x -= 360f;
			}
			else if (vector.x < 0f)
			{
				vector.x += 360f;
			}
			float num = this.WeaponRotationOffSetY;
			num += 180f;
			if (num > 360f)
			{
				num -= 360f;
			}
			else if (num < 0f)
			{
				num += 360f;
			}
			if (num > 180f)
			{
				num = 360f - num;
			}
			this.WeaponRotationOffSetX = num * vector.x * 0.0111111114f - vector.x;
			if (Mathf.Abs(this.WeaponRotationOffSetX) < 0.01f)
			{
				this.WeaponRotationOffSetX = 0f;
			}
			num = this.WeaponRotationOffSetY;
			num += 90f;
			if (num > 360f)
			{
				num -= 360f;
			}
			else if (num < 0f)
			{
				num += 360f;
			}
			if (num > 180f)
			{
				num = 360f - num;
			}
			this.WeaponRotationOffSetZ = num * vector.x * 0.0111111114f - vector.x;
			if (Mathf.Abs(this.WeaponRotationOffSetZ) < 0.01f)
			{
				this.WeaponRotationOffSetZ = 0f;
			}
			this.WeaponRotationOffSetTime = 0f;
			this.WeaponRotationOffSetTimeTarget = recordByKey2.ShowTime * 0.0001f;
		}
		this.WeaponAnimationKeyFrameID = recordByKey.ShowKind0ID;
		if (this.WeaponAnimationKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponAnimationKeyFrameID);
			ShowAnimation recordByKey4 = this.ShowAnimationTable.GetRecordByKey(recordByKey2.ListID);
			this.SetWeaponAnimation((AnimationUnit.AnimName)recordByKey4.AnimationNameID, (WrapMode)recordByKey4.WrapModeID, recordByKey2.ShowTime * 0.0001f, (float)recordByKey4.AnimationSpeed * 0.0001f, (float)recordByKey4.AnimationTime * 0.0001f);
		}
		this.WeaponScaleKeyFrameID = recordByKey.ShowKind1ID;
		if (this.WeaponScaleKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponScaleKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponScale(vector.x, vector.x, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponScale(vector.x, vector2.x, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponRotationKeyFrameID = recordByKey.ShowKind2ID;
		if (this.WeaponRotationKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponRotationKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponRotation(vector.x, vector.y, vector.z, vector.x, vector.y, vector.z, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponRotation(vector.x, vector.y, vector.z, vector2.x, vector2.y, vector2.z, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponPositionKeyFrameID = recordByKey.ShowKind3ID;
		if (this.WeaponPositionKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponPositionKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponPosition(vector.x, vector.y, vector.z, vector.x, vector.y, vector.z, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponPosition(vector.x, vector.y, vector.z, vector2.x, vector2.y, vector2.z, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponLightKeyFrameID = recordByKey.ShowKind4ID;
		this.WeaponLightColorKeyFrameID = recordByKey.ShowKind7ID;
		if (this.WeaponLightColorKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightKeyFrameID);
			ShowLight recordByKey6 = this.ShowLightTable.GetRecordByKey(recordByKey2.ListID);
			LightType showLightType = (LightType)recordByKey6.ShowLightType;
			float weaponLightIntensity = (float)recordByKey6.ShowLightIntensity * 0.0001f;
			recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightColorKeyFrameID);
			ShowColor recordByKey7 = this.ShowColorTable.GetRecordByKey(recordByKey2.ListID);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				ShowColor recordByKey8 = this.ShowColorTable.GetRecordByKey(recordByKey5.ListID);
				this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, recordByKey8.ColorR, recordByKey8.ColorG, recordByKey8.ColorB, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponLightRotationKeyFrameID = recordByKey.ShowKind5ID;
		if (this.WeaponLightRotationKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightRotationKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponLightRotation(vector.x, vector.y, vector.z, vector.x, vector.y, vector.z, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponLightRotation(vector.x, vector.y, vector.z, vector2.x, vector2.y, vector2.z, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponLightPositionKeyFrameID = recordByKey.ShowKind6ID;
		if (this.WeaponLightPositionKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponLightPositionKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetWeaponLightPosition(vector.x, vector.y, vector.x, vector.y, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetWeaponLightPosition(vector.x, vector.y, vector2.x, vector2.y, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.UpDownImagePositionKeyFrameID = recordByKey.ShowKind8ID;
		if (this.UpDownImagePositionKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.UpDownImagePositionKeyFrameID);
			ShowVector3 recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey2.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
			if (recordByKey2.NextListID == 0)
			{
				this.SetScreenEffectPosition(vector.y, vector.y, vector.z <= 0f, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				recordByKey3 = this.ShowVector3Table.GetRecordByKey(recordByKey5.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey3.X, recordByKey3.Y, recordByKey3.Z, 0, 0.1f);
				this.SetScreenEffectPosition(vector.y, vector2.y, vector2.z <= 0f, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.UpDownImageColorKeyFrameID = recordByKey.ShowKind9ID;
		if (this.UpDownImageColorKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.UpDownImageColorKeyFrameID);
			ShowColor recordByKey7 = this.ShowColorTable.GetRecordByKey(recordByKey2.ListID);
			if (recordByKey2.NextListID == 0)
			{
				this.SetScreenEffectColor(recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, (byte)recordByKey7.ColorA, recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, (byte)recordByKey7.ColorA, 0f);
			}
			else
			{
				ShowMap recordByKey5 = this.ShowMapTable.GetRecordByKey(recordByKey2.NextListID);
				ShowColor recordByKey8 = this.ShowColorTable.GetRecordByKey(recordByKey5.ListID);
				this.SetScreenEffectColor(recordByKey7.ColorR, recordByKey7.ColorG, recordByKey7.ColorB, (byte)recordByKey7.ColorA, recordByKey8.ColorR, recordByKey8.ColorG, recordByKey8.ColorB, (byte)recordByKey8.ColorA, recordByKey2.ShowTime * 0.0001f);
			}
		}
		this.WeaponParticleKeyFrameID = recordByKey.ShowKind10ID;
		if (this.WeaponParticleKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponParticleKeyFrameID);
			ShowEffectSound recordByKey9 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey2.ListID);
			this.SetWeaponParticle(recordByKey9.EffectSoundID, (int)recordByKey9.AttackMode, recordByKey2.ShowTime * 0.0001f);
		}
		this.WeaponSoundKeyFrameID = recordByKey.ShowKind11ID;
		if (this.WeaponSoundKeyFrameID > 0)
		{
			ShowMap recordByKey2 = this.ShowMapTable.GetRecordByKey(this.WeaponSoundKeyFrameID);
			ShowEffectSound recordByKey9 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey2.ListID);
			this.SetWeaponParticle(recordByKey9.EffectSoundID, (int)recordByKey9.AttackMode, recordByKey2.ShowTime * 0.0001f);
		}
		this.mapWeaponState = MapTileModel.MapWeaponState.Exit;
		this.CheckNextState();
	}

	// Token: 0x06000B55 RID: 2901 RVA: 0x001090D4 File Offset: 0x001072D4
	public void Stop()
	{
		if (this.WeaponTransform != null)
		{
			this.WeaponTransform.gameObject.SetActive(false);
		}
		if (this.WeaponLightTransform != null)
		{
			this.WeaponLightTransform.gameObject.SetActive(false);
		}
		if (this.UpImageRectTransform != null)
		{
			this.UpImageRectTransform.gameObject.SetActive(false);
		}
		if (this.DownImageRectTransform != null)
		{
			this.DownImageRectTransform.gameObject.SetActive(false);
		}
		if (this.WeaponParticleGameObject != null)
		{
			this.WeaponParticleGameObject.SetActive(false);
		}
		this.mapWeaponState = MapTileModel.MapWeaponState.None;
	}

	// Token: 0x06000B56 RID: 2902 RVA: 0x00109190 File Offset: 0x00107390
	public void LoadShowData()
	{
		if (this.ShowKindToShowMapTable == null)
		{
			this.ShowKindToShowMapTable = new CExternalTableWithWordKey<ShowKindToShowMap>();
			this.ShowKindToShowMapTable.LoadTable("ShowKindToShowMap");
		}
		if (this.ShowMapTable == null)
		{
			this.ShowMapTable = new CExternalTableWithWordKey<ShowMap>();
			this.ShowMapTable.LoadTable("ShowMap");
		}
		if (this.ShowAnimationTable == null)
		{
			this.ShowAnimationTable = new CExternalTableWithWordKey<ShowAnimation>();
			this.ShowAnimationTable.LoadTable("ShowAnimation");
		}
		if (this.ShowVector3Table == null)
		{
			this.ShowVector3Table = new CExternalTableWithWordKey<ShowVector3>();
			this.ShowVector3Table.LoadTable("ShowVector3");
		}
		if (this.ShowLightTable == null)
		{
			this.ShowLightTable = new CExternalTableWithWordKey<ShowLight>();
			this.ShowLightTable.LoadTable("ShowLight");
		}
		if (this.ShowColorTable == null)
		{
			this.ShowColorTable = new CExternalTableWithWordKey<ShowColor>();
			this.ShowColorTable.LoadTable("ShowColor");
		}
		if (this.ShowEffectSoundTable == null)
		{
			this.ShowEffectSoundTable = new CExternalTableWithWordKey<ShowEffectSound>();
			this.ShowEffectSoundTable.LoadTable("ShowEffectSound");
		}
	}

	// Token: 0x06000B57 RID: 2903 RVA: 0x001092B0 File Offset: 0x001074B0
	public bool MapWeaponEffect(ushort EffectID, Vector3 pos, float EffectTime)
	{
		bool result = false;
		if (this.EffectAssetBundle == null)
		{
			this.EffectAssetBundle = AssetManager.GetAssetBundle("Particle/Monster_Effects_604", out this.EffectAssetKey, false);
		}
		this.sb.Length = 0;
		this.sb.AppendFormat("Effect_{0:00000}", EffectID);
		UnityEngine.Object @object = this.EffectAssetBundle.Load(this.sb.ToString());
		if (@object != null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
			if (gameObject != null)
			{
				Transform transform = gameObject.transform;
				transform.SetParent(this.AllEffectTransform, false);
				transform.localPosition = pos;
				float zoomSize = DataManager.MapDataController.zoomSize;
				for (int i = 0; i < transform.childCount; i++)
				{
					ParticleSystem component = transform.GetChild(i).GetComponent<ParticleSystem>();
					if (component != null)
					{
						float num = component.startSize;
						float num2 = component.startLifetime;
						component.startSize = num * zoomSize;
						component.startLifetime = num2 * zoomSize;
						num = component.startSize / num;
						num2 = component.startLifetime / num2;
						int num3 = component.GetParticles(this.particles);
						for (int j = 0; j < num3; j++)
						{
							ParticleSystem.Particle[] array = this.particles;
							int num4 = i;
							array[num4].size = array[num4].size * num;
							ParticleSystem.Particle[] array2 = this.particles;
							int num5 = i;
							array2[num5].lifetime = array2[num5].lifetime * num2;
						}
						component.SetParticles(this.particles, num3);
					}
				}
				this.Effects.Add(gameObject.transform);
				this.EffectTimes.Add(EffectTime * zoomSize);
				result = true;
			}
		}
		return result;
	}

	// Token: 0x06000B58 RID: 2904 RVA: 0x0010948C File Offset: 0x0010768C
	public void MapWeaponEffectMove(Vector2 moveDelta)
	{
		if (this.Effects.Count <= 0)
		{
			return;
		}
		moveDelta *= DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
		for (int i = 0; i < this.Effects.Count; i++)
		{
			Transform transform = this.Effects[i];
			transform.position = new Vector3(transform.position.x + moveDelta.x, transform.position.y + moveDelta.y, transform.position.z);
		}
	}

	// Token: 0x06000B59 RID: 2905 RVA: 0x00109530 File Offset: 0x00107730
	public void MapWeaponEffectScale(float scale)
	{
	}

	// Token: 0x06000B5A RID: 2906 RVA: 0x00109534 File Offset: 0x00107734
	private void NoneState()
	{
	}

	// Token: 0x06000B5B RID: 2907 RVA: 0x00109538 File Offset: 0x00107738
	private void Debut()
	{
		this.UpdateSet();
	}

	// Token: 0x06000B5C RID: 2908 RVA: 0x00109540 File Offset: 0x00107740
	private void Show()
	{
		this.UpdateSet();
	}

	// Token: 0x06000B5D RID: 2909 RVA: 0x00109548 File Offset: 0x00107748
	private void Exit()
	{
		this.UpdateSet();
	}

	// Token: 0x06000B5E RID: 2910 RVA: 0x00109550 File Offset: 0x00107750
	private void WeaponAnimationUpdate()
	{
		this.WeaponAnimationSpeedTime += Time.deltaTime;
		if (this.WeaponAnimationSpeedTime >= this.WeaponAnimationSpeedTimeTarget)
		{
			this.WeaponAnimationTime += this.WeaponAnimationSpeedTimeTarget * this.WeaponAnimationSpeed;
			this.WeaponAnimation[AnimationUnit.ANIM_STRING[(int)this.WeaponAnimationName]].speed = this.WeaponAnimationSpeed;
			this.WeaponAnimation[AnimationUnit.ANIM_STRING[(int)this.WeaponAnimationName]].time = this.WeaponAnimationTime;
			this.NextWeaponAnimation();
		}
	}

	// Token: 0x06000B5F RID: 2911 RVA: 0x001095E4 File Offset: 0x001077E4
	private void WeaponScaleUpdate()
	{
		this.WeaponScaleTime += Time.deltaTime;
		if (this.WeaponScaleTime >= this.WeaponScaleTimeTarget)
		{
			this.WeaponTransform.localScale = Vector3.one * this.WeaponScaleTo;
			this.NextWeaponScale();
		}
		else
		{
			float t = this.WeaponScaleTime / this.WeaponScaleTimeTarget;
			this.WeaponTransform.localScale = Vector3.one * Mathf.Lerp(this.WeaponScaleFrom, this.WeaponScaleTo, t);
		}
	}

	// Token: 0x06000B60 RID: 2912 RVA: 0x00109670 File Offset: 0x00107870
	private void WeaponRotationUpdate()
	{
		this.WeaponRotationTime += Time.deltaTime;
		if (this.WeaponRotationTime >= this.WeaponRotationTimeTarget)
		{
			if (this.WeaponRotationXTo < 0f)
			{
				this.WeaponRotationXTo += 360f;
			}
			else if (this.WeaponRotationXTo > 360f)
			{
				this.WeaponRotationXTo -= 360f;
			}
			if (this.WeaponRotationYTo < 0f)
			{
				this.WeaponRotationYTo += 360f;
			}
			else if (this.WeaponRotationYTo > 360f)
			{
				this.WeaponRotationYTo -= 360f;
			}
			if (this.WeaponRotationZTo < 0f)
			{
				this.WeaponRotationZTo += 360f;
			}
			else if (this.WeaponRotationZTo > 360f)
			{
				this.WeaponRotationZTo -= 360f;
			}
			this.WeaponTransform.localRotation = Quaternion.Euler(this.WeaponRotationXTo, this.WeaponRotationYTo, this.WeaponRotationZTo);
			this.NextWeaponRotation();
		}
		else
		{
			float t = this.WeaponRotationTime / this.WeaponRotationTimeTarget;
			this.WeaponTransform.localRotation = Quaternion.Euler(Mathf.Lerp(this.WeaponRotationXFrom, this.WeaponRotationXTo, t), Mathf.Lerp(this.WeaponRotationYFrom, this.WeaponRotationYTo, t), Mathf.Lerp(this.WeaponRotationZFrom, this.WeaponRotationZTo, t));
		}
	}

	// Token: 0x06000B61 RID: 2913 RVA: 0x001097FC File Offset: 0x001079FC
	private void WeaponRotationOffSetUpdate()
	{
		this.WeaponRotationOffSetTime += Time.deltaTime;
		if (this.WeaponRotationOffSetTime >= this.WeaponRotationOffSetTimeTarget)
		{
			this.NextWeaponRotationOffSet();
		}
	}

	// Token: 0x06000B62 RID: 2914 RVA: 0x00109828 File Offset: 0x00107A28
	private void WeaponPositionUpdate()
	{
		this.WeaponPositionTime += Time.deltaTime;
		if (this.WeaponPositionTime >= this.WeaponPositionTimeTarget)
		{
			this.WeaponTransform.localPosition = new Vector3(this.WeaponPositionXTo, this.WeaponPositionYTo, this.WeaponPositionZTo);
			this.NextWeaponPosition();
		}
		else
		{
			float t = this.WeaponPositionTime / this.WeaponPositionTimeTarget;
			this.WeaponTransform.localPosition = new Vector3(Mathf.Lerp(this.WeaponPositionXFrom, this.WeaponPositionXTo, t), Mathf.Lerp(this.WeaponPositionYFrom, this.WeaponPositionYTo, t), Mathf.Lerp(this.WeaponPositionZFrom, this.WeaponPositionZTo, t));
		}
	}

	// Token: 0x06000B63 RID: 2915 RVA: 0x001098DC File Offset: 0x00107ADC
	private void WeaponLightRotationUpdate()
	{
		this.WeaponLightRotationTime += Time.deltaTime;
		if (this.WeaponLightRotationTime >= this.WeaponLightRotationTimeTarget)
		{
			if (this.WeaponLightRotationXTo < 0f)
			{
				this.WeaponLightRotationXTo += 360f;
			}
			else if (this.WeaponLightRotationXTo > 360f)
			{
				this.WeaponLightRotationXTo -= 360f;
			}
			if (this.WeaponLightRotationYTo < 0f)
			{
				this.WeaponLightRotationYTo += 360f;
			}
			else if (this.WeaponLightRotationYTo > 360f)
			{
				this.WeaponLightRotationYTo -= 360f;
			}
			if (this.WeaponLightRotationZTo < 0f)
			{
				this.WeaponLightRotationZTo += 360f;
			}
			else if (this.WeaponLightRotationZTo > 360f)
			{
				this.WeaponLightRotationZTo -= 360f;
			}
			this.WeaponLightTransform.localRotation = Quaternion.Euler(this.WeaponLightRotationXTo, this.WeaponLightRotationYTo, this.WeaponLightRotationZTo);
			this.NextWeaponLightRotation();
		}
		else
		{
			float t = this.WeaponLightRotationTime / this.WeaponLightRotationTimeTarget;
			this.WeaponLightTransform.localRotation = Quaternion.Euler(Mathf.Lerp(this.WeaponLightRotationXFrom, this.WeaponLightRotationXTo, t), Mathf.Lerp(this.WeaponLightRotationYFrom, this.WeaponLightRotationYTo, t), Mathf.Lerp(this.WeaponLightRotationZFrom, this.WeaponLightRotationZTo, t));
		}
	}

	// Token: 0x06000B64 RID: 2916 RVA: 0x00109A68 File Offset: 0x00107C68
	private void WeaponLightPositionUpdate()
	{
		this.WeaponLightPositionTime += Time.deltaTime;
		if (this.WeaponLightPositionTime >= this.WeaponLightPositionTimeTarget)
		{
			this.WeaponLightTransform.localPosition = new Vector3(this.WeaponLightPositionXTo, this.WeaponLightPositionYTo, this.WeaponLightTransform.localPosition.z);
			this.NextWeaponLightPosition();
		}
		else
		{
			float t = this.WeaponLightPositionTime / this.WeaponLightPositionTimeTarget;
			this.WeaponLightTransform.localPosition = new Vector3(Mathf.Lerp(this.WeaponLightPositionXFrom, this.WeaponLightPositionXTo, t), Mathf.Lerp(this.WeaponLightPositionYFrom, this.WeaponLightPositionYTo, t), this.WeaponLightTransform.localPosition.z);
		}
	}

	// Token: 0x06000B65 RID: 2917 RVA: 0x00109B28 File Offset: 0x00107D28
	private void WeaponLightColorUpdate()
	{
		this.WeaponLightColorTime += Time.deltaTime;
		if (this.WeaponLightColorTime >= this.WeaponLightColorTimeTarget)
		{
			this.WeaponLight.color = new Color(this.WeaponLightColorRTo, this.WeaponLightColorGTo, this.WeaponLightColorBTo);
			this.NextWeaponLightColor();
		}
		else
		{
			float t = this.WeaponLightColorTime / this.WeaponLightColorTimeTarget;
			this.WeaponLight.color = new Color(Mathf.Lerp(this.WeaponLightColorRFrom, this.WeaponLightColorRTo, t), Mathf.Lerp(this.WeaponLightColorGFrom, this.WeaponLightColorGTo, t), Mathf.Lerp(this.WeaponLightColorBFrom, this.WeaponLightColorBTo, t));
		}
	}

	// Token: 0x06000B66 RID: 2918 RVA: 0x00109BDC File Offset: 0x00107DDC
	private void ScreenEffectPositionUpdate()
	{
		this.UpDownImagePositionTime += Time.deltaTime;
		if (this.UpDownImagePositionTime >= this.UpDownImagePositionTimeTarget)
		{
			this.UpImageRectTransform.anchoredPosition = new Vector2(this.UpImageRectTransform.anchoredPosition.x, this.UpDownImagePositionYTo);
			this.DownImageRectTransform.anchoredPosition = new Vector2(this.DownImageRectTransform.anchoredPosition.x, -this.UpDownImagePositionYTo);
			this.NextScreenEffectPosition();
		}
		else
		{
			float t = this.UpDownImagePositionTime / this.UpDownImagePositionTimeTarget;
			this.UpImageRectTransform.anchoredPosition = new Vector2(this.UpImageRectTransform.anchoredPosition.x, Mathf.Lerp(this.UpDownImagePositionYFrom, this.UpDownImagePositionYTo, t));
			this.DownImageRectTransform.anchoredPosition = new Vector2(this.DownImageRectTransform.anchoredPosition.x, Mathf.Lerp(-this.UpDownImagePositionYFrom, -this.UpDownImagePositionYTo, t));
		}
	}

	// Token: 0x06000B67 RID: 2919 RVA: 0x00109CE8 File Offset: 0x00107EE8
	private void ScreenEffectColorUpdate()
	{
		this.UpDownImageColorTime += Time.deltaTime;
		if (this.UpDownImageColorTime >= this.UpDownImageColorTimeTarget)
		{
			Graphic upImage = this.UpImage;
			Color color = new Color(this.UpDownImageColorRTo, this.UpDownImageColorGTo, this.UpDownImageColorBTo, this.UpDownImageColorATo);
			this.DownImage.color = color;
			upImage.color = color;
			this.NextScreenEffectColor();
		}
		else
		{
			float t = this.UpDownImageColorTime / this.UpDownImageColorTimeTarget;
			Graphic upImage2 = this.UpImage;
			Color color = new Color(Mathf.Lerp(this.UpDownImageColorRFrom, this.UpDownImageColorRTo, t), Mathf.Lerp(this.UpDownImageColorGFrom, this.UpDownImageColorGTo, t), Mathf.Lerp(this.UpDownImageColorBFrom, this.UpDownImageColorBTo, t), Mathf.Lerp(this.UpDownImageColorBFrom, this.UpDownImageColorBTo, t));
			this.DownImage.color = color;
			upImage2.color = color;
		}
	}

	// Token: 0x06000B68 RID: 2920 RVA: 0x00109DD0 File Offset: 0x00107FD0
	private void WeaponParticleUpdate()
	{
		this.WeaponParticleTime -= Time.deltaTime;
		if (this.WeaponParticleTime <= 0f)
		{
			this.WeaponParticleTime = 0f;
			this.NextWeaponParticle();
		}
	}

	// Token: 0x06000B69 RID: 2921 RVA: 0x00109E08 File Offset: 0x00108008
	private void WeaponSoundUpdate()
	{
		this.WeaponSoundTime -= Time.deltaTime;
		if (this.WeaponSoundTime <= 0f)
		{
			this.WeaponSoundTime = 0f;
			this.NextWeaponSound();
		}
	}

	// Token: 0x06000B6A RID: 2922 RVA: 0x00109E40 File Offset: 0x00108040
	private void MapWeaponEffectParticleUpdate()
	{
		for (int i = 0; i < this.EffectTimes.Count; i++)
		{
			List<float> effectTimes;
			List<float> list = effectTimes = this.EffectTimes;
			int index2;
			int index = index2 = i;
			float num = effectTimes[index2];
			list[index] = num - Time.deltaTime;
			if (this.EffectTimes[i] <= 0f)
			{
				this.EffectsIDs.Add(i);
			}
		}
		for (int j = this.EffectsIDs.Count - 1; j >= 0; j--)
		{
			UnityEngine.Object.Destroy(this.Effects[this.EffectsIDs[j]].gameObject);
			this.Effects.RemoveAt(this.EffectsIDs[j]);
			this.EffectTimes.RemoveAt(this.EffectsIDs[j]);
		}
		this.EffectsIDs.Clear();
	}

	// Token: 0x06000B6B RID: 2923 RVA: 0x00109F24 File Offset: 0x00108124
	private void UpdateSet()
	{
		this.WeaponAnimationUpdate();
		this.WeaponScaleUpdate();
		this.WeaponRotationUpdate();
		this.WeaponRotationOffSetUpdate();
		this.WeaponPositionUpdate();
		this.WeaponLightColorUpdate();
		this.WeaponLightRotationUpdate();
		this.WeaponLightPositionUpdate();
		this.ScreenEffectColorUpdate();
		this.ScreenEffectPositionUpdate();
		this.WeaponParticleUpdate();
		this.WeaponSoundUpdate();
	}

	// Token: 0x06000B6C RID: 2924 RVA: 0x00109F7C File Offset: 0x0010817C
	private void NextWeaponAnimation()
	{
		if (this.WeaponAnimationKeyFrameID == 0)
		{
			return;
		}
		this.WeaponAnimationKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponAnimationKeyFrameID).NextListID;
		if (this.WeaponAnimationKeyFrameID > 0)
		{
			ShowMap recordByKey = this.ShowMapTable.GetRecordByKey(this.WeaponAnimationKeyFrameID);
			ShowAnimation recordByKey2 = this.ShowAnimationTable.GetRecordByKey(recordByKey.ListID);
			this.SetWeaponAnimation((AnimationUnit.AnimName)recordByKey2.AnimationNameID, (WrapMode)recordByKey2.WrapModeID, recordByKey.ShowTime * 0.0001f, (float)recordByKey2.AnimationSpeed * 0.0001f, (float)recordByKey2.AnimationTime * 0.0001f);
		}
		this.CheckNextState();
	}

	// Token: 0x06000B6D RID: 2925 RVA: 0x0010A02C File Offset: 0x0010822C
	private void NextWeaponScale()
	{
		if (this.WeaponScaleKeyFrameID == 0)
		{
			return;
		}
		this.WeaponScaleKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponScaleKeyFrameID).NextListID;
		if (this.WeaponScaleKeyFrameID > 0)
		{
			ShowMap recordByKey = this.ShowMapTable.GetRecordByKey(this.WeaponScaleKeyFrameID);
			ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
			if (recordByKey.NextListID == 0)
			{
				this.SetWeaponScale(vector.x, vector.x, 0f);
			}
			else
			{
				ShowMap recordByKey3 = this.ShowMapTable.GetRecordByKey(recordByKey.NextListID);
				recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey3.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
				this.SetWeaponScale(vector.x, vector2.x, recordByKey.ShowTime * 0.0001f);
			}
		}
		this.CheckNextState();
	}

	// Token: 0x06000B6E RID: 2926 RVA: 0x0010A154 File Offset: 0x00108354
	private void NextWeaponRotation()
	{
		if (this.WeaponRotationKeyFrameID == 0)
		{
			return;
		}
		this.WeaponRotationKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponRotationKeyFrameID).NextListID;
		if (this.WeaponRotationKeyFrameID > 0)
		{
			ShowMap recordByKey = this.ShowMapTable.GetRecordByKey(this.WeaponRotationKeyFrameID);
			ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
			if (recordByKey.NextListID == 0)
			{
				this.SetWeaponRotation(vector.x, vector.y, vector.z, vector.x, vector.y, vector.z, 0f);
			}
			else
			{
				ShowMap recordByKey3 = this.ShowMapTable.GetRecordByKey(recordByKey.NextListID);
				recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey3.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
				this.SetWeaponRotation(vector.x, vector.y, vector.z, vector2.x, vector2.y, vector2.z, recordByKey.ShowTime * 0.0001f);
			}
		}
		this.CheckNextState();
	}

	// Token: 0x06000B6F RID: 2927 RVA: 0x0010A2B4 File Offset: 0x001084B4
	private void NextWeaponRotationOffSet()
	{
		if (this.WeaponRotationOffSetKeyFrameID == 0)
		{
			return;
		}
		this.WeaponRotationOffSetKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponRotationOffSetKeyFrameID).NextListID;
		if (this.WeaponRotationOffSetKeyFrameID > 0)
		{
			this.WeaponRotationOffSetX = (this.WeaponRotationOffSetZ = 0f);
			ShowMap recordByKey = this.ShowMapTable.GetRecordByKey(this.WeaponRotationOffSetKeyFrameID);
			ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
			float num = this.WeaponRotationOffSetY;
			if (num > 180f)
			{
				num -= 180f;
			}
			this.WeaponRotationOffSetX = vector.x - num * vector.x * 0.0111111114f;
			num = this.WeaponRotationOffSetY;
			num -= 90f;
			if (num > 180f)
			{
				num -= 180f;
			}
			else if (num < 0f)
			{
				num += 180f;
			}
			this.WeaponRotationOffSetZ = vector.x - num * vector.x * 0.0111111114f;
			this.WeaponRotationOffSetTime = 0f;
			this.WeaponRotationOffSetTimeTarget = recordByKey.ShowTime * 0.0001f;
		}
		this.CheckNextState();
	}

	// Token: 0x06000B70 RID: 2928 RVA: 0x0010A408 File Offset: 0x00108608
	private void NextWeaponPosition()
	{
		if (this.WeaponPositionKeyFrameID == 0)
		{
			return;
		}
		this.WeaponPositionKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponPositionKeyFrameID).NextListID;
		if (this.WeaponPositionKeyFrameID > 0)
		{
			ShowMap recordByKey = this.ShowMapTable.GetRecordByKey(this.WeaponPositionKeyFrameID);
			ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
			if (recordByKey.NextListID == 0)
			{
				this.SetWeaponPosition(vector.x, vector.y, vector.z, vector.x, vector.y, vector.z, 0f);
			}
			else
			{
				ShowMap recordByKey3 = this.ShowMapTable.GetRecordByKey(recordByKey.NextListID);
				recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey3.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
				this.SetWeaponPosition(vector.x, vector.y, vector.z, vector2.x, vector2.y, vector2.z, recordByKey.ShowTime * 0.0001f);
			}
		}
		this.CheckNextState();
	}

	// Token: 0x06000B71 RID: 2929 RVA: 0x0010A568 File Offset: 0x00108768
	private void NextWeaponLightRotation()
	{
		if (this.WeaponLightRotationKeyFrameID == 0)
		{
			return;
		}
		this.WeaponLightRotationKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponLightRotationKeyFrameID).NextListID;
		if (this.WeaponLightRotationKeyFrameID > 0)
		{
			ShowMap recordByKey = this.ShowMapTable.GetRecordByKey(this.WeaponLightRotationKeyFrameID);
			ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
			if (recordByKey.NextListID == 0)
			{
				this.SetWeaponLightRotation(vector.x, vector.y, vector.z, vector.x, vector.y, vector.z, 0f);
			}
			else
			{
				ShowMap recordByKey3 = this.ShowMapTable.GetRecordByKey(recordByKey.NextListID);
				recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey3.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
				this.SetWeaponLightRotation(vector.x, vector.y, vector.z, vector2.x, vector2.y, vector2.z, recordByKey.ShowTime * 0.0001f);
			}
		}
		this.CheckNextState();
	}

	// Token: 0x06000B72 RID: 2930 RVA: 0x0010A6C8 File Offset: 0x001088C8
	private void NextWeaponLightPosition()
	{
		if (this.WeaponLightPositionKeyFrameID == 0)
		{
			return;
		}
		this.WeaponLightPositionKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponLightPositionKeyFrameID).NextListID;
		if (this.WeaponLightPositionKeyFrameID > 0)
		{
			ShowMap recordByKey = this.ShowMapTable.GetRecordByKey(this.WeaponLightPositionKeyFrameID);
			ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
			if (recordByKey.NextListID == 0)
			{
				this.SetWeaponLightPosition(vector.x, vector.y, vector.x, vector.y, 0f);
			}
			else
			{
				ShowMap recordByKey3 = this.ShowMapTable.GetRecordByKey(recordByKey.NextListID);
				recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey3.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
				this.SetWeaponLightPosition(vector.x, vector.y, vector2.x, vector2.y, recordByKey.ShowTime * 0.0001f);
			}
		}
		this.CheckNextState();
	}

	// Token: 0x06000B73 RID: 2931 RVA: 0x0010A80C File Offset: 0x00108A0C
	private void NextWeaponLightColor()
	{
		if (this.WeaponLightColorKeyFrameID == 0)
		{
			return;
		}
		this.WeaponLightKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponLightKeyFrameID).NextListID;
		this.WeaponLightColorKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponLightColorKeyFrameID).NextListID;
		if (this.WeaponLightColorKeyFrameID > 0)
		{
			ShowMap recordByKey = this.ShowMapTable.GetRecordByKey(this.WeaponLightKeyFrameID);
			ShowLight recordByKey2 = this.ShowLightTable.GetRecordByKey(recordByKey.ListID);
			LightType showLightType = (LightType)recordByKey2.ShowLightType;
			float weaponLightIntensity = (float)recordByKey2.ShowLightIntensity * 0.0001f;
			recordByKey = this.ShowMapTable.GetRecordByKey(this.WeaponLightColorKeyFrameID);
			ShowColor recordByKey3 = this.ShowColorTable.GetRecordByKey(recordByKey.ListID);
			if (recordByKey.NextListID == 0)
			{
				this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey3.ColorR, recordByKey3.ColorG, recordByKey3.ColorB, recordByKey3.ColorR, recordByKey3.ColorG, recordByKey3.ColorB, 0f);
			}
			else
			{
				ShowMap recordByKey4 = this.ShowMapTable.GetRecordByKey(recordByKey.NextListID);
				ShowColor recordByKey5 = this.ShowColorTable.GetRecordByKey(recordByKey4.ListID);
				this.SetWeaponLight(showLightType, weaponLightIntensity, recordByKey3.ColorR, recordByKey3.ColorG, recordByKey3.ColorB, recordByKey5.ColorR, recordByKey5.ColorG, recordByKey5.ColorB, recordByKey.ShowTime * 0.0001f);
			}
		}
		this.CheckNextState();
	}

	// Token: 0x06000B74 RID: 2932 RVA: 0x0010A988 File Offset: 0x00108B88
	private void NextScreenEffectPosition()
	{
		if (this.UpDownImagePositionKeyFrameID == 0)
		{
			return;
		}
		this.UpDownImagePositionKeyFrameID = this.ShowMapTable.GetRecordByKey(this.UpDownImagePositionKeyFrameID).NextListID;
		if (this.UpDownImagePositionKeyFrameID > 0)
		{
			ShowMap recordByKey = this.ShowMapTable.GetRecordByKey(this.UpDownImagePositionKeyFrameID);
			ShowVector3 recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey.ListID);
			Vector3 vector = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
			if (recordByKey.NextListID == 0)
			{
				this.SetScreenEffectPosition(vector.y, vector.y, vector.z <= 0f, 0f);
			}
			else
			{
				ShowMap recordByKey3 = this.ShowMapTable.GetRecordByKey(recordByKey.NextListID);
				recordByKey2 = this.ShowVector3Table.GetRecordByKey(recordByKey3.ListID);
				Vector3 vector2 = GameConstants.WordToVector3(recordByKey2.X, recordByKey2.Y, recordByKey2.Z, 0, 0.1f);
				this.SetScreenEffectPosition(vector.y, vector2.y, vector2.z <= 0f, recordByKey.ShowTime * 0.0001f);
			}
		}
		this.CheckNextState();
	}

	// Token: 0x06000B75 RID: 2933 RVA: 0x0010AAD0 File Offset: 0x00108CD0
	private void NextScreenEffectColor()
	{
		if (this.UpDownImageColorKeyFrameID == 0)
		{
			return;
		}
		this.UpDownImageColorKeyFrameID = this.ShowMapTable.GetRecordByKey(this.UpDownImageColorKeyFrameID).NextListID;
		if (this.UpDownImageColorKeyFrameID > 0)
		{
			ShowMap recordByKey = this.ShowMapTable.GetRecordByKey(this.UpDownImageColorKeyFrameID);
			ShowColor recordByKey2 = this.ShowColorTable.GetRecordByKey(recordByKey.ListID);
			if (recordByKey.NextListID == 0)
			{
				this.SetScreenEffectColor(recordByKey2.ColorR, recordByKey2.ColorG, recordByKey2.ColorB, (byte)recordByKey2.ColorA, recordByKey2.ColorR, recordByKey2.ColorG, recordByKey2.ColorB, (byte)recordByKey2.ColorA, 0f);
			}
			else
			{
				ShowMap recordByKey3 = this.ShowMapTable.GetRecordByKey(recordByKey.NextListID);
				ShowColor recordByKey4 = this.ShowColorTable.GetRecordByKey(recordByKey3.ListID);
				this.SetScreenEffectColor(recordByKey2.ColorR, recordByKey2.ColorG, recordByKey2.ColorB, (byte)recordByKey2.ColorA, recordByKey4.ColorR, recordByKey4.ColorG, recordByKey4.ColorB, (byte)recordByKey4.ColorA, recordByKey.ShowTime * 0.0001f);
			}
		}
		this.CheckNextState();
	}

	// Token: 0x06000B76 RID: 2934 RVA: 0x0010AC0C File Offset: 0x00108E0C
	private void NextWeaponParticle()
	{
		if (this.WeaponParticleKeyFrameID == 0)
		{
			return;
		}
		if (this.WeaponParticle != null && this.WeaponParticleGameObject != null)
		{
			if (this.WeaponParticleID == 0u)
			{
				this.WeaponParticleGameObject.SetActive(false);
				UnityEngine.Object.Destroy(this.WeaponParticleGameObject);
				this.WeaponParticleGameObject = null;
				this.WeaponParticle = null;
			}
			else
			{
				this.WeaponParticleGameObject.SetActive(true);
			}
		}
		this.WeaponParticleKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponParticleKeyFrameID).NextListID;
		if (this.WeaponParticleKeyFrameID > 0)
		{
			ShowMap recordByKey = this.ShowMapTable.GetRecordByKey(this.WeaponParticleKeyFrameID);
			ShowEffectSound recordByKey2 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey.ListID);
			this.SetWeaponParticle(recordByKey2.EffectSoundID, (int)recordByKey2.AttackMode, recordByKey.ShowTime * 0.0001f);
		}
		this.CheckNextState();
	}

	// Token: 0x06000B77 RID: 2935 RVA: 0x0010AD04 File Offset: 0x00108F04
	private void NextWeaponSound()
	{
		if (this.WeaponSoundKeyFrameID == 0)
		{
			return;
		}
		this.WeaponSoundKeyFrameID = this.ShowMapTable.GetRecordByKey(this.WeaponSoundKeyFrameID).NextListID;
		if (this.WeaponSoundKeyFrameID > 0)
		{
			ShowMap recordByKey = this.ShowMapTable.GetRecordByKey(this.WeaponSoundKeyFrameID);
			ShowEffectSound recordByKey2 = this.ShowEffectSoundTable.GetRecordByKey(recordByKey.ListID);
			this.SetWeaponParticle(recordByKey2.EffectSoundID, (int)recordByKey2.AttackMode, recordByKey.ShowTime * 0.0001f);
		}
		this.CheckNextState();
	}

	// Token: 0x06000B78 RID: 2936 RVA: 0x0010AD98 File Offset: 0x00108F98
	private void endState()
	{
		DataManager.msgBuffer[0] = 81;
		GameConstants.GetBytes(9, DataManager.msgBuffer, 1);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		DataManager.MapDataController.StopMapWeapon();
	}

	// Token: 0x06000B79 RID: 2937 RVA: 0x0010ADC8 File Offset: 0x00108FC8
	private void CheckNextState()
	{
		int num = (int)(this.WeaponScaleKeyFrameID + this.WeaponRotationKeyFrameID + this.WeaponPositionKeyFrameID + this.WeaponAnimationKeyFrameID + this.WeaponLightColorKeyFrameID + this.WeaponLightRotationKeyFrameID + this.WeaponLightPositionKeyFrameID + this.UpDownImagePositionKeyFrameID + this.UpDownImageColorKeyFrameID + this.WeaponParticleKeyFrameID + this.WeaponSoundKeyFrameID + this.WeaponRotationOffSetKeyFrameID);
		if (num != 0)
		{
			return;
		}
		switch (this.mapWeaponState)
		{
		case MapTileModel.MapWeaponState.Debut:
			this.startShow(this.ShowID);
			break;
		case MapTileModel.MapWeaponState.Show:
			this.startExit(this.ExitID);
			break;
		case MapTileModel.MapWeaponState.Exit:
			this.endState();
			break;
		}
	}

	// Token: 0x06000B7A RID: 2938 RVA: 0x0010AE84 File Offset: 0x00109084
	private void SetWeaponAnimation(AnimationUnit.AnimName animName, WrapMode animWrapMode, float timeTarget, float animSpeed = 1f, float animTime = 0f)
	{
		this.WeaponAnimationName = animName;
		this.WeaponAnimation.wrapMode = animWrapMode;
		this.WeaponAnimation.CrossFade(AnimationUnit.ANIM_STRING[(int)this.WeaponAnimationName]);
		this.WeaponAnimationSpeed = animSpeed;
		this.WeaponAnimationTime = animTime;
		this.WeaponAnimationSpeedTime = 0f;
		this.WeaponAnimationSpeedTimeTarget = timeTarget;
		this.WeaponAnimation[AnimationUnit.ANIM_STRING[(int)this.WeaponAnimationName]].speed = this.WeaponAnimationSpeed;
		this.WeaponAnimation[AnimationUnit.ANIM_STRING[(int)this.WeaponAnimationName]].time = this.WeaponAnimationTime;
	}

	// Token: 0x06000B7B RID: 2939 RVA: 0x0010AF24 File Offset: 0x00109124
	private void SetWeaponScale(float weaponScaleFrom, float weaponScaleTo, float weaponScaleTimeTarget)
	{
		this.WeaponScaleFrom = weaponScaleFrom;
		this.WeaponScaleTo = weaponScaleTo;
		this.WeaponScaleTime = 0f;
		this.WeaponScaleTimeTarget = weaponScaleTimeTarget;
		this.WeaponTransform.localScale = Vector3.one * this.WeaponScaleFrom;
	}

	// Token: 0x06000B7C RID: 2940 RVA: 0x0010AF64 File Offset: 0x00109164
	private void SetWeaponRotation(float weaponRotationXFrom, float weaponRotationYFrom, float weaponRotationZFrom, float weaponRotationXTo, float weaponRotationYTo, float weaponRotationZTo, float weaponRotationTimeTarget)
	{
		this.WeaponRotationXFrom = weaponRotationXFrom + this.WeaponRotationOffSetX;
		this.WeaponRotationYFrom = weaponRotationYFrom + this.WeaponRotationOffSetY;
		this.WeaponRotationZFrom = weaponRotationZFrom + this.WeaponRotationOffSetZ;
		this.WeaponRotationXTo = weaponRotationXTo + this.WeaponRotationOffSetX;
		this.WeaponRotationYTo = weaponRotationYTo + this.WeaponRotationOffSetY;
		this.WeaponRotationZTo = weaponRotationZTo + this.WeaponRotationOffSetZ;
		this.WeaponRotationTime = 0f;
		this.WeaponRotationTimeTarget = weaponRotationTimeTarget;
		this.WeaponTransform.localRotation = Quaternion.Euler(this.WeaponRotationXFrom, this.WeaponRotationYFrom, this.WeaponRotationZFrom);
	}

	// Token: 0x06000B7D RID: 2941 RVA: 0x0010B000 File Offset: 0x00109200
	private void SetWeaponPosition(float weaponPositionXFrom, float weaponPositionYFrom, float weaponPositionZFrom, float weaponPositionXTo, float weaponPositionYTo, float weaponPositionZTo, float weaponPositionTimeTarget)
	{
		this.WeaponPositionXFrom = weaponPositionXFrom;
		this.WeaponPositionYFrom = weaponPositionYFrom;
		this.WeaponPositionZFrom = weaponPositionZFrom;
		this.WeaponPositionXTo = weaponPositionXTo;
		this.WeaponPositionYTo = weaponPositionYTo;
		this.WeaponPositionZTo = weaponPositionZTo;
		this.WeaponPositionTime = 0f;
		this.WeaponPositionTimeTarget = weaponPositionTimeTarget;
		this.WeaponTransform.localPosition = new Vector3(this.WeaponPositionXFrom, this.WeaponPositionYFrom, this.WeaponPositionZFrom);
	}

	// Token: 0x06000B7E RID: 2942 RVA: 0x0010B070 File Offset: 0x00109270
	private void SetWeaponLight(LightType weaponLightType, float weaponLightIntensity, byte weaponLightColorRFrom, byte weaponLightColorGFrom, byte weaponLightColorBFrom, byte weaponLightColorRTo, byte weaponLightColorGTo, byte weaponLightColorBTo, float weaponLightColorTimeTarget)
	{
		this.WeaponLight.type = weaponLightType;
		this.WeaponLight.intensity = weaponLightIntensity;
		this.WeaponLightColorRFrom = (float)weaponLightColorRFrom * 0.003921569f;
		this.WeaponLightColorGFrom = (float)weaponLightColorGFrom * 0.003921569f;
		this.WeaponLightColorBFrom = (float)weaponLightColorBFrom * 0.003921569f;
		this.WeaponLightColorRTo = (float)weaponLightColorRTo * 0.003921569f;
		this.WeaponLightColorGTo = (float)weaponLightColorGTo * 0.003921569f;
		this.WeaponLightColorBTo = (float)weaponLightColorBTo * 0.003921569f;
		this.WeaponLightColorTime = 0f;
		this.WeaponLightColorTimeTarget = weaponLightColorTimeTarget;
		this.WeaponLight.color = new Color(this.WeaponLightColorRFrom, this.WeaponLightColorGFrom, this.WeaponLightColorBFrom);
	}

	// Token: 0x06000B7F RID: 2943 RVA: 0x0010B124 File Offset: 0x00109324
	private void SetWeaponLightRotation(float weaponLightRotationXFrom, float weaponLightRotationYFrom, float weaponLightRotationZFrom, float weaponLightRotationXTo, float weaponLightRotationYTo, float weaponLightRotationZTo, float weaponLightRotationTimeTarget)
	{
		this.WeaponLightRotationXFrom = weaponLightRotationXFrom;
		this.WeaponLightRotationYFrom = weaponLightRotationYFrom;
		this.WeaponLightRotationZFrom = weaponLightRotationZFrom;
		this.WeaponLightRotationXTo = weaponLightRotationXTo;
		this.WeaponLightRotationYTo = weaponLightRotationYTo;
		this.WeaponLightRotationZTo = weaponLightRotationZTo;
		this.WeaponLightRotationTime = 0f;
		this.WeaponLightRotationTimeTarget = weaponLightRotationTimeTarget;
		this.WeaponTransform.localRotation = Quaternion.Euler(this.WeaponLightRotationXFrom, this.WeaponLightRotationYFrom, this.WeaponLightRotationZFrom);
	}

	// Token: 0x06000B80 RID: 2944 RVA: 0x0010B194 File Offset: 0x00109394
	private void SetWeaponLightPosition(float weaponLightPositionXFrom, float weaponLightPositionYFrom, float weaponLightPositionXTo, float weaponLightPositionYTo, float weaponLightPositionTimeTarget)
	{
		this.WeaponLightPositionXFrom = weaponLightPositionXFrom;
		this.WeaponLightPositionYFrom = weaponLightPositionYFrom;
		this.WeaponLightPositionXTo = weaponLightPositionXTo;
		this.WeaponLightPositionYTo = weaponLightPositionYTo;
		this.WeaponLightPositionTime = 0f;
		this.WeaponLightPositionTimeTarget = weaponLightPositionTimeTarget;
		this.WeaponLightTransform.localPosition = new Vector3(this.WeaponLightPositionXFrom, this.WeaponLightPositionYFrom, this.WeaponLightTransform.localPosition.z);
	}

	// Token: 0x06000B81 RID: 2945 RVA: 0x0010B200 File Offset: 0x00109400
	private void SetScreenEffectPosition(float upDownImagePositionYFrom, float upDownImagePositionYTo, bool bFront, float upDownImagePositionTimeTarget)
	{
		this.UpDownImagePositionYFrom = upDownImagePositionYFrom;
		this.UpDownImagePositionYTo = upDownImagePositionYTo;
		this.UpDownImagePositionTime = 0f;
		this.UpDownImagePositionTimeTarget = upDownImagePositionTimeTarget;
		if (bFront)
		{
			if (this.DownImage != null && this.DownImage.material != null && this.DownImage.material.renderQueue != 3100)
			{
				this.DownImage.material.renderQueue = 3100;
			}
			if (this.UpImage != null && this.UpImage.material != null && this.UpImage.material.renderQueue != 3100)
			{
				this.UpImage.material.renderQueue = 3100;
			}
		}
		else
		{
			if (this.DownImage != null && this.DownImage.material != null && this.DownImage.material.renderQueue != 2890)
			{
				this.DownImage.material.renderQueue = 2890;
			}
			if (this.UpImage != null && this.UpImage.material != null && this.UpImage.material.renderQueue != 2890)
			{
				this.UpImage.material.renderQueue = 2890;
			}
		}
		this.UpImageRectTransform.anchoredPosition = new Vector2(this.UpImageRectTransform.anchoredPosition.x, this.UpDownImagePositionYFrom);
		this.DownImageRectTransform.anchoredPosition = new Vector2(this.DownImageRectTransform.anchoredPosition.x, -this.UpDownImagePositionYFrom);
	}

	// Token: 0x06000B82 RID: 2946 RVA: 0x0010B3E4 File Offset: 0x001095E4
	private void SetScreenEffectColor(byte screenEffectColorRFrom, byte screenEffectColorGFrom, byte screenEffectColorBFrom, byte screenEffectColorAFrom, byte screenEffectColorRTo, byte screenEffectColorGTo, byte screenEffectColorBTo, byte screenEffectColorATo, float screenEffectColorTimeTarget)
	{
		this.UpDownImageColorRFrom = (float)screenEffectColorRFrom * 0.003921569f;
		this.UpDownImageColorGFrom = (float)screenEffectColorGFrom * 0.003921569f;
		this.UpDownImageColorBFrom = (float)screenEffectColorBFrom * 0.003921569f;
		this.UpDownImageColorAFrom = (float)screenEffectColorAFrom * 0.003921569f;
		this.UpDownImageColorRTo = (float)screenEffectColorRTo * 0.003921569f;
		this.UpDownImageColorGTo = (float)screenEffectColorGTo * 0.003921569f;
		this.UpDownImageColorBTo = (float)screenEffectColorBTo * 0.003921569f;
		this.UpDownImageColorATo = (float)screenEffectColorATo * 0.003921569f;
		this.UpDownImageColorTime = 0f;
		this.UpDownImageColorTimeTarget = screenEffectColorTimeTarget;
		Graphic upImage = this.UpImage;
		Color color = new Color(this.UpDownImageColorRFrom, this.UpDownImageColorGFrom, this.UpDownImageColorBFrom, this.UpDownImageColorAFrom);
		this.DownImage.color = color;
		upImage.color = color;
	}

	// Token: 0x06000B83 RID: 2947 RVA: 0x0010B4B0 File Offset: 0x001096B0
	private void SetWeaponParticle(uint effectID, int attackMode, float startEffectTime)
	{
		if (effectID == 0u && this.WeaponParticleGameObject != null && this.WeaponParticleGameObject.activeSelf)
		{
			this.WeaponParticleID = effectID;
		}
		else
		{
			this.sb.Length = 0;
			this.sb.AppendFormat("Effect_{0:00000}", effectID);
			if (this.WeaponParticle != null && this.WeaponParticleID != effectID)
			{
				UnityEngine.Object.Destroy(this.WeaponParticleGameObject);
				this.WeaponParticleGameObject = null;
				this.WeaponParticle = null;
			}
			this.WeaponParticleID = effectID;
			if (this.WeaponParticle == null)
			{
				UnityEngine.Object @object = this.EffectAssetBundle.Load(this.sb.ToString());
				if (@object != null)
				{
					this.WeaponParticleGameObject = (UnityEngine.Object.Instantiate(@object) as GameObject);
				}
				if (this.WeaponParticleGameObject != null)
				{
					this.WeaponParticle = this.WeaponParticleGameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
				}
				else
				{
					this.WeaponParticle = null;
				}
			}
			if (this.WeaponParticle != null && this.WeaponParticleGameObject != null)
			{
				Transform transform = this.WeaponParticleGameObject.transform;
				if (this.WeaponTransform == null)
				{
					transform.SetParent(this.AllEffectTransform, false);
				}
				else
				{
					Transform allEffectTransform;
					if (attackMode != 1)
					{
						if (attackMode != 2)
						{
							allEffectTransform = this.AllEffectTransform;
						}
						else
						{
							allEffectTransform = this.flyRoot;
						}
					}
					else
					{
						allEffectTransform = this.hitParticleRoot;
					}
					transform.SetParent(allEffectTransform, false);
					float zoomSize = DataManager.MapDataController.zoomSize;
					for (int i = 0; i < transform.childCount; i++)
					{
						ParticleSystem component = transform.GetChild(i).GetComponent<ParticleSystem>();
						if (component != null)
						{
							float num = component.startSize;
							float num2 = component.startLifetime;
							component.startSize = num * zoomSize;
							component.startLifetime = num2 * zoomSize;
							num = component.startSize / num;
							num2 = component.startLifetime / num2;
							int num3 = component.GetParticles(this.particles);
							for (int j = 0; j < num3; j++)
							{
								ParticleSystem.Particle[] array = this.particles;
								int num4 = i;
								array[num4].size = array[num4].size * num;
								ParticleSystem.Particle[] array2 = this.particles;
								int num5 = i;
								array2[num5].lifetime = array2[num5].lifetime * num2;
							}
							component.SetParticles(this.particles, num3);
						}
					}
				}
				this.WeaponParticleGameObject.SetActive(false);
			}
		}
		this.WeaponParticleTime = ((this.WeaponParticleID != 0u) ? startEffectTime : (startEffectTime * DataManager.MapDataController.zoomSize));
	}

	// Token: 0x06000B84 RID: 2948 RVA: 0x0010B790 File Offset: 0x00109990
	private void SetWeaponSound(uint soundID, int attackMode, float startSoundTime)
	{
		Transform allEffectTransform;
		if (attackMode != 1)
		{
			if (attackMode != 2)
			{
				allEffectTransform = this.AllEffectTransform;
			}
			else
			{
				allEffectTransform = this.flyRoot;
			}
		}
		else
		{
			allEffectTransform = this.hitParticleRoot;
		}
		this.WeaponSoundTime = startSoundTime;
		AudioManager.Instance.PlaySFX((ushort)soundID, startSoundTime, PitchKind.NoPitch, allEffectTransform, null);
	}

	// Token: 0x0400267C RID: 9852
	private Transform RealmGroup;

	// Token: 0x0400267D RID: 9853
	private Transform ModelLayoutTransform;

	// Token: 0x0400267E RID: 9854
	private ushort DebutID = 1;

	// Token: 0x0400267F RID: 9855
	private ushort ShowID = 1;

	// Token: 0x04002680 RID: 9856
	private ushort ExitID = 1;

	// Token: 0x04002681 RID: 9857
	private Transform WeaponTransform;

	// Token: 0x04002682 RID: 9858
	private Transform hitParticleRoot;

	// Token: 0x04002683 RID: 9859
	private Transform flyRoot;

	// Token: 0x04002684 RID: 9860
	private int WeaponAssetKey;

	// Token: 0x04002685 RID: 9861
	private ushort WeaponModelID = 1;

	// Token: 0x04002686 RID: 9862
	private float WeaponScaleFrom = 1f;

	// Token: 0x04002687 RID: 9863
	private float WeaponScaleTo = 1f;

	// Token: 0x04002688 RID: 9864
	private float WeaponScaleTime;

	// Token: 0x04002689 RID: 9865
	private float WeaponScaleTimeTarget;

	// Token: 0x0400268A RID: 9866
	private ushort WeaponScaleKeyFrameID;

	// Token: 0x0400268B RID: 9867
	private float WeaponRotationXFrom;

	// Token: 0x0400268C RID: 9868
	private float WeaponRotationYFrom;

	// Token: 0x0400268D RID: 9869
	private float WeaponRotationZFrom;

	// Token: 0x0400268E RID: 9870
	private float WeaponRotationXTo;

	// Token: 0x0400268F RID: 9871
	private float WeaponRotationYTo;

	// Token: 0x04002690 RID: 9872
	private float WeaponRotationZTo;

	// Token: 0x04002691 RID: 9873
	private float WeaponRotationTime;

	// Token: 0x04002692 RID: 9874
	private float WeaponRotationTimeTarget;

	// Token: 0x04002693 RID: 9875
	private ushort WeaponRotationKeyFrameID;

	// Token: 0x04002694 RID: 9876
	private float WeaponRotationOffSetX;

	// Token: 0x04002695 RID: 9877
	private float WeaponRotationOffSetY;

	// Token: 0x04002696 RID: 9878
	private float WeaponRotationOffSetZ;

	// Token: 0x04002697 RID: 9879
	private float WeaponRotationOffSetTime;

	// Token: 0x04002698 RID: 9880
	private float WeaponRotationOffSetTimeTarget;

	// Token: 0x04002699 RID: 9881
	private ushort WeaponRotationOffSetKeyFrameID;

	// Token: 0x0400269A RID: 9882
	private float WeaponPositionXFrom;

	// Token: 0x0400269B RID: 9883
	private float WeaponPositionYFrom;

	// Token: 0x0400269C RID: 9884
	private float WeaponPositionZFrom;

	// Token: 0x0400269D RID: 9885
	private float WeaponPositionXTo;

	// Token: 0x0400269E RID: 9886
	private float WeaponPositionYTo;

	// Token: 0x0400269F RID: 9887
	private float WeaponPositionZTo;

	// Token: 0x040026A0 RID: 9888
	private float WeaponPositionTime;

	// Token: 0x040026A1 RID: 9889
	private float WeaponPositionTimeTarget;

	// Token: 0x040026A2 RID: 9890
	private ushort WeaponPositionKeyFrameID;

	// Token: 0x040026A3 RID: 9891
	private Animation WeaponAnimation;

	// Token: 0x040026A4 RID: 9892
	private AnimationUnit.AnimName WeaponAnimationName;

	// Token: 0x040026A5 RID: 9893
	private float WeaponAnimationSpeed = 1f;

	// Token: 0x040026A6 RID: 9894
	private float WeaponAnimationTime;

	// Token: 0x040026A7 RID: 9895
	private float WeaponAnimationSpeedTime;

	// Token: 0x040026A8 RID: 9896
	private float WeaponAnimationSpeedTimeTarget;

	// Token: 0x040026A9 RID: 9897
	private ushort WeaponAnimationKeyFrameID;

	// Token: 0x040026AA RID: 9898
	private Light WeaponLight;

	// Token: 0x040026AB RID: 9899
	private Transform WeaponLightTransform;

	// Token: 0x040026AC RID: 9900
	private ushort WeaponLightKeyFrameID;

	// Token: 0x040026AD RID: 9901
	private float WeaponLightColorRFrom = 1f;

	// Token: 0x040026AE RID: 9902
	private float WeaponLightColorGFrom = 1f;

	// Token: 0x040026AF RID: 9903
	private float WeaponLightColorBFrom = 1f;

	// Token: 0x040026B0 RID: 9904
	private float WeaponLightColorRTo = 1f;

	// Token: 0x040026B1 RID: 9905
	private float WeaponLightColorGTo = 1f;

	// Token: 0x040026B2 RID: 9906
	private float WeaponLightColorBTo = 1f;

	// Token: 0x040026B3 RID: 9907
	private float WeaponLightColorTime;

	// Token: 0x040026B4 RID: 9908
	private float WeaponLightColorTimeTarget;

	// Token: 0x040026B5 RID: 9909
	private ushort WeaponLightColorKeyFrameID;

	// Token: 0x040026B6 RID: 9910
	private float WeaponLightRotationXFrom;

	// Token: 0x040026B7 RID: 9911
	private float WeaponLightRotationYFrom;

	// Token: 0x040026B8 RID: 9912
	private float WeaponLightRotationZFrom;

	// Token: 0x040026B9 RID: 9913
	private float WeaponLightRotationXTo;

	// Token: 0x040026BA RID: 9914
	private float WeaponLightRotationYTo;

	// Token: 0x040026BB RID: 9915
	private float WeaponLightRotationZTo;

	// Token: 0x040026BC RID: 9916
	private float WeaponLightRotationTime;

	// Token: 0x040026BD RID: 9917
	private float WeaponLightRotationTimeTarget;

	// Token: 0x040026BE RID: 9918
	private ushort WeaponLightRotationKeyFrameID;

	// Token: 0x040026BF RID: 9919
	private float WeaponLightPositionXFrom;

	// Token: 0x040026C0 RID: 9920
	private float WeaponLightPositionYFrom;

	// Token: 0x040026C1 RID: 9921
	private float WeaponLightPositionXTo;

	// Token: 0x040026C2 RID: 9922
	private float WeaponLightPositionYTo;

	// Token: 0x040026C3 RID: 9923
	private float WeaponLightPositionTime;

	// Token: 0x040026C4 RID: 9924
	private float WeaponLightPositionTimeTarget;

	// Token: 0x040026C5 RID: 9925
	private ushort WeaponLightPositionKeyFrameID;

	// Token: 0x040026C6 RID: 9926
	private Image UpImage;

	// Token: 0x040026C7 RID: 9927
	private Image DownImage;

	// Token: 0x040026C8 RID: 9928
	private RectTransform UpImageRectTransform;

	// Token: 0x040026C9 RID: 9929
	private RectTransform DownImageRectTransform;

	// Token: 0x040026CA RID: 9930
	private float UpDownImagePositionYFrom;

	// Token: 0x040026CB RID: 9931
	private float UpDownImagePositionYTo;

	// Token: 0x040026CC RID: 9932
	private float UpDownImagePositionTime;

	// Token: 0x040026CD RID: 9933
	private float UpDownImagePositionTimeTarget;

	// Token: 0x040026CE RID: 9934
	private ushort UpDownImagePositionKeyFrameID;

	// Token: 0x040026CF RID: 9935
	private float UpDownImageColorRFrom = 1f;

	// Token: 0x040026D0 RID: 9936
	private float UpDownImageColorGFrom = 1f;

	// Token: 0x040026D1 RID: 9937
	private float UpDownImageColorBFrom = 1f;

	// Token: 0x040026D2 RID: 9938
	private float UpDownImageColorAFrom = 1f;

	// Token: 0x040026D3 RID: 9939
	private float UpDownImageColorRTo = 1f;

	// Token: 0x040026D4 RID: 9940
	private float UpDownImageColorGTo = 1f;

	// Token: 0x040026D5 RID: 9941
	private float UpDownImageColorBTo = 1f;

	// Token: 0x040026D6 RID: 9942
	private float UpDownImageColorATo = 1f;

	// Token: 0x040026D7 RID: 9943
	private float UpDownImageColorTime;

	// Token: 0x040026D8 RID: 9944
	private float UpDownImageColorTimeTarget;

	// Token: 0x040026D9 RID: 9945
	private ushort UpDownImageColorKeyFrameID;

	// Token: 0x040026DA RID: 9946
	private AssetBundle EffectAssetBundle;

	// Token: 0x040026DB RID: 9947
	private ParticleSystem WeaponParticle;

	// Token: 0x040026DC RID: 9948
	private GameObject WeaponParticleGameObject;

	// Token: 0x040026DD RID: 9949
	private Transform AllEffectTransform;

	// Token: 0x040026DE RID: 9950
	private int EffectAssetKey;

	// Token: 0x040026DF RID: 9951
	private uint WeaponParticleID;

	// Token: 0x040026E0 RID: 9952
	private float WeaponParticleTime;

	// Token: 0x040026E1 RID: 9953
	private ushort WeaponParticleKeyFrameID;

	// Token: 0x040026E2 RID: 9954
	private float WeaponSoundTime;

	// Token: 0x040026E3 RID: 9955
	private ushort WeaponSoundKeyFrameID;

	// Token: 0x040026E4 RID: 9956
	private MapTileModel.MapWeaponState mapWeaponState;

	// Token: 0x040026E5 RID: 9957
	private MapTileModel.MapTileModelUpdateDelegate[] mapTileModelUpdateDelegate;

	// Token: 0x040026E6 RID: 9958
	private CExternalTableWithWordKey<ShowKindToShowMap> ShowKindToShowMapTable;

	// Token: 0x040026E7 RID: 9959
	private CExternalTableWithWordKey<ShowMap> ShowMapTable;

	// Token: 0x040026E8 RID: 9960
	private CExternalTableWithWordKey<ShowAnimation> ShowAnimationTable;

	// Token: 0x040026E9 RID: 9961
	private CExternalTableWithWordKey<ShowVector3> ShowVector3Table;

	// Token: 0x040026EA RID: 9962
	private CExternalTableWithWordKey<ShowLight> ShowLightTable;

	// Token: 0x040026EB RID: 9963
	private CExternalTableWithWordKey<ShowColor> ShowColorTable;

	// Token: 0x040026EC RID: 9964
	private CExternalTableWithWordKey<ShowEffectSound> ShowEffectSoundTable;

	// Token: 0x040026ED RID: 9965
	private List<Transform> Effects = new List<Transform>();

	// Token: 0x040026EE RID: 9966
	private List<float> EffectTimes = new List<float>();

	// Token: 0x040026EF RID: 9967
	private List<int> EffectsIDs = new List<int>();

	// Token: 0x040026F0 RID: 9968
	private ParticleSystem.Particle[] particles = new ParticleSystem.Particle[64];

	// Token: 0x040026F1 RID: 9969
	private StringBuilder sb = new StringBuilder();

	// Token: 0x0200026B RID: 619
	private enum MapWeaponState : byte
	{
		// Token: 0x040026F3 RID: 9971
		None,
		// Token: 0x040026F4 RID: 9972
		Debut,
		// Token: 0x040026F5 RID: 9973
		Show,
		// Token: 0x040026F6 RID: 9974
		Exit,
		// Token: 0x040026F7 RID: 9975
		Count
	}

	// Token: 0x02000892 RID: 2194
	// (Invoke) Token: 0x06002D90 RID: 11664
	private delegate void MapTileModelUpdateDelegate();
}
