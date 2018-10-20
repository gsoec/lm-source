using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

// Token: 0x02000035 RID: 53
public class AssetManager
{
	// Token: 0x06000152 RID: 338 RVA: 0x00015BD4 File Offset: 0x00013DD4
	private AssetManager()
	{
		this.AssetManagerState = AssetState.Preload;
		AssetManager.persistentDataPath = IGGSDKPlugin.GetExternalFilesDir();
		AssetManager.Reload = true;
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x06000154 RID: 340 RVA: 0x00015DC0 File Offset: 0x00013FC0
	// (set) Token: 0x06000155 RID: 341 RVA: 0x00015DC8 File Offset: 0x00013FC8
	public AssetState AssetManagerState
	{
		get
		{
			return this.assetState;
		}
		set
		{
			this.assetState = value;
		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000156 RID: 342 RVA: 0x00015DD4 File Offset: 0x00013FD4
	public static AssetManager Instance
	{
		get
		{
			if (AssetManager.instance == null)
			{
				AssetManager.instance = new AssetManager();
			}
			return AssetManager.instance;
		}
	}

	// Token: 0x06000157 RID: 343 RVA: 0x00015DF0 File Offset: 0x00013FF0
	public static void SetDownload(bool active)
	{
		AssetManager.Download = active;
	}

	// Token: 0x06000158 RID: 344 RVA: 0x00015DF8 File Offset: 0x00013FF8
	public static bool GetAssetBundleDownload(CString Name, AssetPath Path, AssetType Type, ushort Id, bool DontUpdate = false)
	{
		bool flag = false;
		int hashCode = Name.GetHashCode(true);
		AssetManager.AssRef assRef;
		if (!AssetManager.AssetMap.TryGetValue(hashCode, out assRef))
		{
			AssetManager.SetAssetBundle(hashCode, 0L, true);
			assRef.Internal = true;
		}
		else if (assRef.Asset)
		{
			flag = true;
		}
		if (!flag)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			if (!assRef.Internal)
			{
				cstring.StringToFormat(Application.dataPath);
				cstring.StringToFormat(Name);
				cstring.AppendFormat("{0}!assets/{1}.unity3d");
			}
			else
			{
				cstring.StringToFormat(AssetManager.persistentDataPath);
				cstring.StringToFormat(Name);
				cstring.AppendFormat("{0}/{1}.unity3d");
			}
			if (assRef.Asset = AssetBundle.CreateFromFile(cstring.ToString()))
			{
				assRef.Asset.Unload(true);
				flag = true;
			}
		}
		if (DontUpdate && flag)
		{
			return true;
		}
		if (Path == AssetPath.Store)
		{
			if (Type == AssetType.MallBack)
			{
				AssetManager.RequestMallBundle(Id, false);
			}
			else if (Type == AssetType.MallPackage)
			{
				AssetManager.RequestMallPackage(Id, false);
			}
		}
		else if (Path == AssetPath.Activity)
		{
			if (Type == AssetType.ActivityBack)
			{
				AssetManager.RequestActivityBundle(Id, false);
			}
			else if (Type == AssetType.ActivityPackage)
			{
				AssetManager.RequestActivityPackage(Id, false);
			}
		}
		else
		{
			AssetManager.DownloadAssetBundle(Name, Path, Type, Id, false);
		}
		return flag;
	}

	// Token: 0x06000159 RID: 345 RVA: 0x00015F50 File Offset: 0x00014150
	public static void DownloadAssetBundle(CString Name, AssetPath Path, AssetType Type, ushort Id, bool bFail = false)
	{
		if (!bFail)
		{
			AssetManager.AssetPackage[0].Add(new AssetUpdate(Name.ToString(), (byte)Path, (byte)Type, (int)Id));
			DownloadController.Refresh();
		}
	}

	// Token: 0x0600015A RID: 346 RVA: 0x00015F84 File Offset: 0x00014184
	public static void RequestDownload(CString Name, AssetPath Path, AssetType Type, ushort Id, bool bFail = false)
	{
		DataManager.msgBuffer[0] = (byte)Path;
		DataManager.msgBuffer[1] = (byte)Type;
		GameConstants.GetBytes(Id, DataManager.msgBuffer, 2);
		GameManager.OnRefresh(NetworkNews.Refresh_Asset, DataManager.msgBuffer);
	}

	// Token: 0x0600015B RID: 347 RVA: 0x00015FB0 File Offset: 0x000141B0
	public static void RequestActivityBundle(ushort id, bool bFail = false)
	{
		if (bFail && !AssetManager.AssetPackages[0, 1].Contains((int)id))
		{
			AssetManager.AssetPackages[0, 1].Add((int)id);
		}
		else if (!bFail && !AssetManager.AssetPackages[0, 0].Contains((int)id))
		{
			AssetManager.AssetPackages[0, 0].Add((int)id);
		}
		DownloadController.Refresh();
	}

	// Token: 0x0600015C RID: 348 RVA: 0x00016028 File Offset: 0x00014228
	public static void RequestActivityPackage(ushort id, bool bFail = false)
	{
		if (bFail && !AssetManager.AssetPackages[1, 1].Contains((int)id))
		{
			AssetManager.AssetPackages[1, 1].Add((int)id);
		}
		else if (!bFail && !AssetManager.AssetPackages[1, 0].Contains((int)id))
		{
			AssetManager.AssetPackages[1, 0].Add((int)id);
		}
		DownloadController.Refresh();
	}

	// Token: 0x0600015D RID: 349 RVA: 0x000160A0 File Offset: 0x000142A0
	public static void RequestMallBundle(ushort id, bool bFail = false)
	{
		if (bFail && !AssetManager.UpdatePackage[0, 1].Contains((int)id))
		{
			AssetManager.UpdatePackage[0, 1].Add((int)id);
		}
		else if (!bFail && !AssetManager.UpdatePackage[0, 0].Contains((int)id))
		{
			AssetManager.UpdatePackage[0, 0].Add((int)id);
		}
		DownloadController.Refresh();
	}

	// Token: 0x0600015E RID: 350 RVA: 0x00016118 File Offset: 0x00014318
	public static void RequestMallPackage(ushort id, bool bFail = false)
	{
		if (bFail && !AssetManager.UpdatePackage[1, 1].Contains((int)id))
		{
			AssetManager.UpdatePackage[1, 1].Add((int)id);
		}
		else if (!bFail && !AssetManager.UpdatePackage[1, 0].Contains((int)id))
		{
			AssetManager.UpdatePackage[1, 0].Add((int)id);
		}
		DownloadController.Refresh();
	}

	// Token: 0x0600015F RID: 351 RVA: 0x00016190 File Offset: 0x00014390
	public static AssetBundle GetAssetBundle(string Name, out int Key, bool Inside = false)
	{
		Key = Name.ToUpperInvariant().GetHashCode();
		AssetManager.AssRef value;
		if (!AssetManager.AssetMap.TryGetValue(Key, out value) || !value.Asset || value.RefCount == 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (value.Internal || Inside)
			{
				stringBuilder.AppendFormat("{0}/{1}.unity3d", AssetManager.persistentDataPath, Name);
			}
			else
			{
				stringBuilder.AppendFormat("{0}!assets/{1}.unity3d", Application.dataPath, Name);
			}
			value.Set(AssetBundle.CreateFromFile(stringBuilder.ToString()));
		}
		value.RefCount++;
		AssetManager.AssetMap[Key] = value;
		return value.Asset;
	}

	// Token: 0x06000160 RID: 352 RVA: 0x00016254 File Offset: 0x00014454
	public static AssetBundle GetAssetBundle(CString Name, out int Key)
	{
		Key = Name.GetHashCode(true);
		AssetManager.AssRef value;
		if (!AssetManager.AssetMap.TryGetValue(Key, out value) || !value.Asset || value.RefCount == 0)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			if (!value.Internal)
			{
				cstring.StringToFormat(Application.dataPath);
				cstring.StringToFormat(Name);
				cstring.AppendFormat("{0}!assets/{1}.unity3d");
			}
			else
			{
				cstring.StringToFormat(AssetManager.persistentDataPath);
				cstring.StringToFormat(Name);
				cstring.AppendFormat("{0}/{1}.unity3d");
			}
			value.Set(AssetBundle.CreateFromFile(cstring.ToString()));
		}
		value.RefCount++;
		AssetManager.AssetMap[Key] = value;
		return value.Asset;
	}

	// Token: 0x06000161 RID: 353 RVA: 0x0001632C File Offset: 0x0001452C
	[Obsolete]
	public static AssetBundle GetAssetBundle(string name, long stamper = 0L)
	{
		AssetManager.SOB.Length = 0;
		AssetManager.AssRef assRef;
		if (stamper > 0L && !AssetManager.AssetMap.TryGetValue(name.ToUpperInvariant().GetHashCode(), out assRef))
		{
			using (FileStream fileStream = new FileStream(AssetManager.SOB.AppendFormat("{0}/{1}", AssetManager.persistentDataPath, name).ToString(), FileMode.OpenOrCreate))
			{
				using (StreamReader streamReader = new StreamReader(fileStream))
				{
					long num;
					if (long.TryParse(streamReader.ReadLine(), out num) && stamper <= num)
					{
						AssetManager.SetAssetBundle(name.ToUpperInvariant().GetHashCode(), num, true);
					}
					else
					{
						AssetManager.SetAssetBundle(name.ToUpperInvariant().GetHashCode(), stamper, false);
					}
				}
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (!AssetManager.AssetMap.TryGetValue(name.ToUpperInvariant().GetHashCode(), out assRef) || !assRef.Internal)
		{
			stringBuilder.AppendFormat("{0}!assets/{1}.unity3d", Application.dataPath, name);
		}
		else
		{
			stringBuilder.AppendFormat("{0}/{1}.unity3d", AssetManager.persistentDataPath, name);
		}
		return AssetBundle.CreateFromFile(stringBuilder.ToString());
	}

	// Token: 0x06000162 RID: 354 RVA: 0x00016490 File Offset: 0x00014690
	public static void UnloadAssetBundle(int Key, bool UnloadAll = true)
	{
		AssetManager.AssRef value;
		if (AssetManager.AssetMap.TryGetValue(Key, out value) && value.RefCount > 0)
		{
			value.RefCount--;
			if (value.RefCount == 0 && value.Asset)
			{
				value.Asset.Unload(UnloadAll);
			}
			AssetManager.AssetMap[Key] = value;
		}
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00016504 File Offset: 0x00014704
	public static void SetAssetBundle(int Key, long Stamp, bool Insideout = true)
	{
		AssetManager.AssRef value;
		AssetManager.AssetMap.TryGetValue(Key, out value);
		value.Internal = Insideout;
		value.Stamping = Stamp;
		AssetManager.AssetMap[Key] = value;
	}

	// Token: 0x06000164 RID: 356 RVA: 0x0001653C File Offset: 0x0001473C
	public static long GetAssetStamp(int Key)
	{
		AssetManager.AssRef assRef;
		AssetManager.AssetMap.TryGetValue(Key, out assRef);
		return assRef.Stamping;
	}

	// Token: 0x06000165 RID: 357 RVA: 0x00016560 File Offset: 0x00014760
	public static void RefreshAssetBundle(int Key, bool UnloadAll = false)
	{
		AssetManager.AssRef assRef;
		if (AssetManager.AssetMap.TryGetValue(Key, out assRef) && assRef.Asset)
		{
			assRef.Asset.Unload(UnloadAll);
		}
	}

	// Token: 0x06000166 RID: 358 RVA: 0x000165A0 File Offset: 0x000147A0
	public static void FreeAss()
	{
		if (AssetManager.AssetMap == null)
		{
			return;
		}
		foreach (AssetManager.AssRef assRef in AssetManager.AssetMap.Values)
		{
			if (assRef.Asset)
			{
				assRef.Asset.Unload(true);
			}
		}
		AssetManager.AssetMap.Clear();
		if (AssetManager.Instance.Shader)
		{
			AssetManager.Instance.Shader.Unload(true);
		}
		AssetManager.BigData.Unload();
		AssetManager.BigMac.Unload();
	}

	// Token: 0x06000167 RID: 359 RVA: 0x00016670 File Offset: 0x00014870
	public static void SetAssetMap(int amount)
	{
		if (AssetManager.AssetMap == null)
		{
			AssetManager.AssetPackages = new List<int>[2, 2];
			AssetManager.UpdatePackage = new List<int>[2, 2];
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					AssetManager.AssetPackages[i, j] = new List<int>();
					AssetManager.UpdatePackage[i, j] = new List<int>();
				}
			}
			AssetManager.AssetPackage = new List<AssetUpdate>[2];
			for (int k = 0; k < 2; k++)
			{
				AssetManager.AssetPackage[k] = new List<AssetUpdate>();
			}
			AssetManager.AssetMap = new Dictionary<int, AssetManager.AssRef>(amount);
		}
	}

	// Token: 0x06000168 RID: 360 RVA: 0x0001671C File Offset: 0x0001491C
	public static void UnloadAsses()
	{
		DataManager dataManager = DataManager.Instance;
		if (AssetManager.AssetMap != null && dataManager.bLoadingTableSuccess)
		{
			AssetManager.BigMac.Unload();
			AssetManager.BigData.Unload();
			DataManager.MissionDataManager.Reset();
		}
		DownloadController.Reset(true);
		DataManager.Instance.Init();
		GUIManager.Instance.pDVMgr.UnLoadDamageValueAsset();
		AudioManager.Instance.UnLoadBGM();
		GUIManager.Instance.UnloadAssets();
		MallManager.Instance.UnloadAsset();
		ActivityManager.Instance.ResetPara();
		PetManager.Instance.UnloadAsset();
		if (dataManager.m_BannedWord != null)
		{
			dataManager.m_BannedWord.UnLoadBannedWordTable();
			dataManager.m_BannedWord.UnLoadBannedWordTable2();
		}
		Array.Clear(dataManager.TempFightHeroID, 0, dataManager.TempFightHeroID.Length);
		Array.Clear(dataManager.FightHeroID, 0, dataManager.FightHeroID.Length);
		Array.Clear(dataManager.NonFightHeroID, 0, dataManager.NonFightHeroID.Length);
		Array.Clear(dataManager.SortNonFightHeroID, 0, dataManager.SortNonFightHeroID.Length);
		Array.Clear(dataManager.SelectHeroID, 0, dataManager.SelectHeroID.Length);
		dataManager.LegionBattleHero.Clear();
		dataManager.FightHeroCount = 0u;
		dataManager.NonFightHeroCount = 0u;
		BattleNetwork.NetworkError = 0;
		dataManager.InitMarchData();
		dataManager.curHeroData.Clear();
		Array.Clear(dataManager.sortHeroData, 0, dataManager.sortHeroData.Length);
		dataManager.ResetBuffData();
		dataManager.InitAltarTime();
		NewbieManager.Free();
		PushManage.PushStart = false;
	}

	// Token: 0x06000169 RID: 361 RVA: 0x00016898 File Offset: 0x00014A98
	public void LoadShader(string name)
	{
		if (!AssetManager.Reload)
		{
			return;
		}
		AssetManager.Reload = false;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0}!assets/Loading/{1}.unity3d", Application.dataPath, name);
		if (this.Shader)
		{
			this.Shader.Unload(true);
			Handheld.ClearShaderCache();
		}
		if (this.Shader = AssetBundle.CreateFromFile(stringBuilder.ToString()))
		{
			this.Shaders = this.Shader.LoadAll();
		}
	}

	// Token: 0x0600016A RID: 362 RVA: 0x00016920 File Offset: 0x00014B20
	public static void LoadMap(ushort Scene, byte Theme = 1, WarParticleManager WarP = null)
	{
		AssetManager.UnloadBigMap();
		AssetManager.SOB.Length = 0;
		AssetManager.SOB.AppendFormat("Scene/TMAP_{0}", Scene.ToString("d3"));
		if ((AssetManager.BigMac.Ass = AssetManager.GetAssetBundle(AssetManager.SOB.ToString(), out AssetManager.BigMac.AssKey, false)) && (AssetManager.BigMac.Asset = UnityEngine.Object.Instantiate(AssetManager.BigMac.Ass.Load(AssetManager.SOB.Remove(0, 6).ToString(), typeof(GameObject)))))
		{
			AssetManager.SOB.Length = 0;
			AssetManager.SOB.AppendFormat("Scene/TMAP_{0}_M{1}", Scene.ToString("d3"), 1);
			if (AssetManager.BigMap[0] = ((GameObject)AssetManager.BigMac.Asset).transform.Find(AssetManager.SOB.ToString()))
			{
				AssetManager.BigMap[0].position -= AssetManager.Bearing;
				AssetManager.BigMap[0].gameObject.AddComponent("ShadowReceiver");
				StringBuilder sob = AssetManager.SOB;
				int num = 0;
				AssetManager.BigMap[0].renderer.lightmapIndex = num;
				sob.Length = num;
				AssetManager.SOB.AppendFormat("Scene/TMAP_{0}_{1}", Scene.ToString("d3"), Theme);
				if (AssetManager.BigData.Ass = AssetManager.GetAssetBundle(AssetManager.SOB.ToString(), out AssetManager.BigData.AssKey, false))
				{
					if (!(AssetManager.SData = (AssetManager.BigData.Ass.mainAsset as SceneData)))
					{
						AssetManager.SOB.Length = 0;
						AssetManager.SOB.AppendFormat("SceneData0{0}", Theme);
						AssetManager.SData = (AssetManager.BigData.Ass.Load(AssetManager.SOB.ToString()) as SceneData);
					}
					RenderSettings.fog = AssetManager.SData.mfog;
					RenderSettings.fogColor = AssetManager.SData.mfogcolor;
					RenderSettings.fogDensity = AssetManager.SData.mfogDensity;
					RenderSettings.fogStartDistance = AssetManager.SData.mfogStartDistance;
					RenderSettings.fogEndDistance = AssetManager.SData.mfogEndDistance;
					RenderSettings.ambientLight = AssetManager.SData.mambientLight;
					RenderSettings.fogMode = (FogMode)AssetManager.SData.mfogMode;
					int num2 = AssetManager.SData.Lightmap.Length;
					LightmapData[] array = new LightmapData[num2 + (int)LightmapManager.Instance.GetCustomLightmapNum()];
					byte b = 0;
					while ((int)b < num2)
					{
						array[(int)b] = new LightmapData
						{
							lightmapFar = AssetManager.SData.Lightmap[(int)b]
						};
						b += 1;
					}
					LightmapManager.Instance.UpdateCurLightmap(array);
					LightmapSettings.lightmaps = array;
					LightmapSettings.lightmapsMode = LightmapsMode.Single;
					LightmapSettings.lightProbes = AssetManager.SData.Lightprobe;
					Camera.main.backgroundColor = AssetManager.SData.cameraBackgroundColor;
				}
			}
			Transform transform;
			if (transform = ((GameObject)AssetManager.BigMac.Asset).transform.FindChild("Theme"))
			{
				ushort num3 = 0;
				while ((int)num3 < transform.childCount)
				{
					Transform child;
					if ((child = transform.GetChild((int)num3)).name.Contains(Theme.ToString()))
					{
						ushort num4 = 0;
						ushort effID = 0;
						while ((int)num4 < child.childCount)
						{
							GameObject gameObject;
							if (ushort.TryParse(child.GetChild((int)num4).name, out effID) && (gameObject = WarP.Spawn(effID, null, child.GetChild((int)num4).position, 1f, true, false)))
							{
								gameObject.transform.SetParent(((GameObject)AssetManager.BigMac.Asset).transform, false);
							}
							num4 += 1;
						}
					}
					num3 += 1;
				}
			}
		}
	}

	// Token: 0x0600016B RID: 363 RVA: 0x00016D30 File Offset: 0x00014F30
	public static void LoadScene(ushort name)
	{
		AssetManager.SceneStage = DataManager.StageDataController.StageTable.GetRecordByKey(name);
	}

	// Token: 0x0600016C RID: 364 RVA: 0x00016D48 File Offset: 0x00014F48
	public static void QuitScene()
	{
		AssetManager.SceneID = 0;
		AssetManager.SAss.Unload();
		AssetManager.SMood.Unload();
		LightmapSettings.lightmaps = null;
		LightmapSettings.lightProbes = null;
		Camera.main.backgroundColor = Color.clear;
	}

	// Token: 0x0600016D RID: 365 RVA: 0x00016D8C File Offset: 0x00014F8C
	public static void LoadStage(byte level, ref Transform out_mapObject1, ref Transform out_mapObject2)
	{
		if (level >= 1 && level <= 3)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Scene/map_{0}", AssetManager.SceneStage.Arrays[(int)(level - 1)].Scene.ToString("d3"));
			if (AssetManager.SceneID != AssetManager.SceneStage.Arrays[(int)(level - 1)].Scene)
			{
				AssetManager.QuitScene();
				GC.Collect();
				AssetManager.SceneTheme = (AssetManager.SceneSide = 0);
				if ((AssetManager.SAss.Ass = AssetManager.GetAssetBundle(stringBuilder.ToString(), out AssetManager.SAss.AssKey, false)) && (AssetManager.SAss.Asset = UnityEngine.Object.Instantiate(AssetManager.SAss.Ass.Load(stringBuilder.Remove(0, 6).ToString()))) && (AssetManager.BigMap[0] = ((GameObject)AssetManager.SAss.Asset).transform))
				{
					Transform transform = AssetManager.BigMap[0].FindChild("Scene");
					int num = (!transform) ? 2 : Mathf.Min(transform.childCount, 10);
					for (int i = 1; i <= num; i++)
					{
						stringBuilder.Length = 0;
						stringBuilder.AppendFormat("{0}_m{1}", AssetManager.SceneStage.Arrays[(int)(level - 1)].Scene.ToString("d3"), i);
						AssetManager.BigMap[i] = ((!transform) ? AssetManager.BigMap[0].FindChild(stringBuilder.ToString()) : transform.FindChild(stringBuilder.ToString()));
					}
					AssetManager.BigMap[0].position -= AssetManager.Bearing;
					if (AssetManager.BigMap[1])
					{
						AssetManager.BigMap[1].gameObject.AddComponent("ShadowReceiver");
						out_mapObject1 = AssetManager.BigMap[1];
					}
					if (AssetManager.BigMap[2])
					{
						out_mapObject2 = AssetManager.BigMap[2];
					}
				}
				AssetManager.SceneID = AssetManager.SceneStage.Arrays[(int)(level - 1)].Scene;
			}
			if (AssetManager.SAss.Asset)
			{
				if (AssetManager.SceneStage.Arrays[(int)(level - 1)].Theme != AssetManager.SceneTheme)
				{
					AssetManager.SceneTheme = AssetManager.SceneStage.Arrays[(int)(level - 1)].Theme;
					stringBuilder.Length = 0;
					stringBuilder.AppendFormat("Scene/map_{0}_{1}", AssetManager.SceneID.ToString("d3"), AssetManager.SceneTheme);
					LightmapSettings.lightmaps = null;
					LightmapSettings.lightProbes = null;
					if (AssetManager.SMood.Unload())
					{
						GC.Collect();
					}
					AssetManager.SMood.Ass = AssetManager.GetAssetBundle(stringBuilder.ToString(), out AssetManager.SMood.AssKey, false);
					if (AssetManager.SMood.Ass)
					{
						Transform transform2;
						if (transform2 = AssetManager.BigMap[0].FindChild("Theme"))
						{
							for (int j = 0; j < transform2.childCount; j++)
							{
								Transform child = transform2.GetChild(j);
								child.gameObject.SetActive(child.name.Contains(AssetManager.SceneTheme.ToString()));
							}
						}
						if (!(AssetManager.SData = (AssetManager.SMood.Ass.mainAsset as SceneData)))
						{
							stringBuilder.Length = 0;
							stringBuilder.AppendFormat("SceneData0{0}", AssetManager.SceneTheme);
							AssetManager.SData = (AssetManager.SMood.Ass.Load(stringBuilder.ToString()) as SceneData);
						}
						RenderSettings.fog = AssetManager.SData.mfog;
						RenderSettings.fogColor = AssetManager.SData.mfogcolor;
						RenderSettings.fogDensity = AssetManager.SData.mfogDensity;
						RenderSettings.fogStartDistance = AssetManager.SData.mfogStartDistance;
						RenderSettings.fogEndDistance = AssetManager.SData.mfogEndDistance;
						RenderSettings.ambientLight = AssetManager.SData.mambientLight;
						RenderSettings.fogMode = (FogMode)AssetManager.SData.mfogMode;
						int num2 = AssetManager.SData.Lightmap.Length;
						LightmapData[] array = new LightmapData[num2 + (int)LightmapManager.Instance.GetCustomLightmapNum()];
						byte b = 0;
						while ((int)b < num2)
						{
							array[(int)b] = new LightmapData
							{
								lightmapFar = AssetManager.SData.Lightmap[(int)b]
							};
							if (AssetManager.BigMap[(int)(b + 1)])
							{
								AssetManager.BigMap[(int)(b + 1)].renderer.lightmapIndex = (int)b;
							}
							b += 1;
						}
						LightmapManager.Instance.UpdateCurLightmap(array);
						LightmapSettings.lightmaps = array;
						LightmapSettings.lightmapsMode = LightmapsMode.Single;
						LightmapSettings.lightProbes = AssetManager.SData.Lightprobe;
						Camera.main.backgroundColor = AssetManager.SData.cameraBackgroundColor;
					}
					else
					{
						RenderSettingsData renderSettingsData = AssetManager.SAss.Ass.Load("RData") as RenderSettingsData;
						if (renderSettingsData)
						{
							RenderSettings.fog = renderSettingsData.mfog;
							RenderSettings.fogColor = renderSettingsData.mfogcolor;
							RenderSettings.fogDensity = renderSettingsData.mfogDensity;
							RenderSettings.fogStartDistance = renderSettingsData.mfogStartDistance;
							RenderSettings.fogEndDistance = renderSettingsData.mfogEndDistance;
							RenderSettings.ambientLight = renderSettingsData.mambientLight;
							RenderSettings.fogMode = (FogMode)renderSettingsData.mfogMode;
							LightmapData[] array2 = new LightmapData[(int)(1 + LightmapManager.Instance.GetCustomLightmapNum())];
							array2[0] = new LightmapData
							{
								lightmapFar = (Texture2D)AssetManager.SAss.Ass.Load("LightmapFar-0")
							};
							LightmapManager.Instance.UpdateCurLightmap(array2);
							LightmapSettings.lightmaps = array2;
							LightmapSettings.lightmapsMode = LightmapsMode.Single;
							LightmapSettings.lightProbes = (LightProbes)AssetManager.SAss.Ass.Load("LightProbes");
							Camera.main.backgroundColor = AssetManager.SData.cameraBackgroundColor;
						}
					}
				}
				else
				{
					GC.Collect();
				}
				if (AssetManager.SceneStage.Arrays[(int)(level - 1)].Face != AssetManager.SceneSide)
				{
					AssetManager.SceneSide = AssetManager.SceneStage.Arrays[(int)(level - 1)].Face;
					((GameObject)AssetManager.SAss.Asset).transform.RotateAround(new Vector3(11.9f, 0f, 5.55f), Vector3.up, 180f);
				}
			}
		}
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00017428 File Offset: 0x00015628
	public static void LoadBigMap()
	{
		AssetManager.UnloadBigMap();
		AssetManager.SOB.Length = 0;
		AssetManager.SOB.AppendFormat("Scene/wmap", new object[0]);
		AssetManager.BigMac.Ass = AssetManager.GetAssetBundle(AssetManager.SOB.ToString(), out AssetManager.BigMac.AssKey, false);
		AssetManager.BigMac.Asset = UnityEngine.Object.Instantiate(AssetManager.BigMac.Ass.Load(AssetManager.SOB.Remove(0, 6).ToString()));
		if (AssetManager.BigMac.Asset)
		{
			byte b = 0;
			while ((int)b < AssetManager.BigMap.Length)
			{
				AssetManager.SOB.Length = 0;
				AssetManager.SOB.AppendFormat("wmap_m{0:D2}", b);
				AssetManager.BigMap[(int)b] = ((GameObject)AssetManager.BigMac.Asset).transform.FindChild(AssetManager.SOB.ToString());
				if (AssetManager.BigMap[(int)b])
				{
					AssetManager.BigMap[(int)b].renderer.lightmapIndex = (int)((b != 0) ? (b - 1) : 14);
				}
				b += 1;
			}
			if (GUIManager.Instance.BuildingData.AllBuildsData != null)
			{
				AssetManager.SetCastleLevel(GUIManager.Instance.BuildingData.GetBuildData(12, 0).Level, 0);
			}
			AssetManager.SOB.Length = 0;
			AssetManager.SOB.AppendFormat("Scene/wmap_{0}", 1);
			AssetManager.BigData.Ass = AssetManager.GetAssetBundle(AssetManager.SOB.ToString(), out AssetManager.BigData.AssKey, false);
			if (AssetManager.BigData.Ass)
			{
				AssetManager.SOB.Length = 0;
				AssetManager.SOB.AppendFormat("SceneData0{0}", 1);
				SceneData sceneData = AssetManager.BigData.Ass.Load(AssetManager.SOB.ToString()) as SceneData;
				RenderSettings.fog = sceneData.mfog;
				RenderSettings.fogColor = sceneData.mfogcolor;
				RenderSettings.fogDensity = sceneData.mfogDensity;
				RenderSettings.fogStartDistance = sceneData.mfogStartDistance;
				RenderSettings.fogEndDistance = sceneData.mfogEndDistance;
				RenderSettings.ambientLight = sceneData.mambientLight;
				RenderSettings.fogMode = (FogMode)sceneData.mfogMode;
				int num = sceneData.Lightmap.Length;
				LightmapData[] array = new LightmapData[num + (int)LightmapManager.Instance.GetCustomLightmapNum()];
				byte b2 = 0;
				while ((int)b2 < num)
				{
					array[(int)b2] = new LightmapData
					{
						lightmapFar = sceneData.Lightmap[(int)b2]
					};
					b2 += 1;
				}
				LightmapManager.Instance.UpdateCurLightmap(array);
				LightmapSettings.lightmaps = array;
				LightmapSettings.lightmapsMode = LightmapsMode.Single;
				LightmapSettings.lightProbes = sceneData.Lightprobe;
				Camera.main.backgroundColor = sceneData.cameraBackgroundColor;
			}
		}
	}

	// Token: 0x0600016F RID: 367 RVA: 0x000176F4 File Offset: 0x000158F4
	public static void SetCastleLevel(byte Level, byte Status)
	{
		DataManager.msgBuffer[0] = 41;
		DataManager.msgBuffer[1] = Level;
		DataManager.msgBuffer[2] = Status;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06000170 RID: 368 RVA: 0x0001771C File Offset: 0x0001591C
	public static void OriginSetCastleLevel(byte Level, byte Status)
	{
		if (DataManager.Instance.m_WallRepairNowValue < DataManager.Instance.m_WallRepairMaxValue)
		{
			Status = 1;
		}
		else
		{
			Status = 0;
		}
		if (AssetManager.BigMac.Asset && (!AssetManager.BigCity.Ass || AssetManager.BuildLv != Level || AssetManager.BuildState != Status))
		{
			AssetManager.BuildLv = Level;
			AssetManager.BuildState = Status;
			AssetManager.BigCity.Unload();
			if (Level < 9)
			{
				Level = 1;
			}
			else if (Level < 17)
			{
				Level = 2;
			}
			else if (Level < 25)
			{
				Level = 3;
			}
			else
			{
				Level = 4;
			}
			AssetManager.SOB.Length = 0;
			AssetManager.SOB.AppendFormat("Scene/wall", new object[0]);
			if ((AssetManager.BigCity.Ass = AssetManager.GetAssetBundle(AssetManager.SOB.ToString(), out AssetManager.BigCity.AssKey, false)) && (AssetManager.BigCity.Asset = AssetManager.BigCity.Ass.Load(AssetManager.SOB.Remove(0, 6).Append(Level).Append(Status).ToString())))
			{
				for (int i = AssetManager.BigMap.Length; i > 0; i--)
				{
					if (AssetManager.BigMap[i - 1])
					{
						((GameObject)(AssetManager.BigCity.Asset = UnityEngine.Object.Instantiate(AssetManager.BigCity.Asset))).transform.SetParent(((GameObject)AssetManager.BigMac.Asset).transform);
						((GameObject)AssetManager.BigCity.Asset).renderer.lightmapIndex = AssetManager.BigMap[i - 1].renderer.lightmapIndex + (int)Level;
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000171 RID: 369 RVA: 0x00017908 File Offset: 0x00015B08
	public static void UnloadBigMap()
	{
		AssetManager.BigMac.Unload();
		AssetManager.BigData.Unload();
		AssetManager.BigCity.Unload();
		AssetManager.BigWall.Unload();
		LightmapSettings.lightmaps = null;
		LightmapSettings.lightProbes = null;
		LightmapManager.Instance.SceneLightmapSize = 0;
	}

	// Token: 0x040002E6 RID: 742
	public static string[] PriorityAsset = new string[]
	{
		"UI",
		"TTFFont",
		"UI",
		"UI_frame",
		"UI",
		"ManagerAsset2",
		"UI",
		"UILoadingTalk",
		"UI",
		"UILight",
		"UI",
		"UITreasureBox",
		"UI",
		"AudioAsset",
		"Role",
		"hero_00001",
		"Role",
		"hero_00007",
		"Role",
		"hero_00009",
		"Role",
		"400",
		"Role",
		"410"
	};

	// Token: 0x040002E7 RID: 743
	public static string[] StringAsset = new string[]
	{
		"StringEng",
		"StringCht",
		"StringFre",
		"StringGem",
		"StringSpa",
		"StringRus",
		"StringChs",
		"StringIdn",
		"StringVet",
		"StringTur",
		"StringTha",
		"StringIta",
		"StringPot",
		"StringKor",
		"StringJap",
		"StringUkr",
		"StringMys",
		"StringArb"
	};

	// Token: 0x040002E8 RID: 744
	private static AssetManager instance = null;

	// Token: 0x040002E9 RID: 745
	private AssetState assetState;

	// Token: 0x040002EA RID: 746
	public static List<int>[,] UpdatePackage;

	// Token: 0x040002EB RID: 747
	public static List<int>[,] AssetPackages;

	// Token: 0x040002EC RID: 748
	public static List<AssetUpdate>[] AssetPackage;

	// Token: 0x040002ED RID: 749
	private static Dictionary<int, AssetManager.AssRef> AssetMap;

	// Token: 0x040002EE RID: 750
	private static StringBuilder SOB = new StringBuilder();

	// Token: 0x040002EF RID: 751
	private static AssetManager.AssAsset SAss;

	// Token: 0x040002F0 RID: 752
	private static AssetManager.AssAsset SMood;

	// Token: 0x040002F1 RID: 753
	private static SceneData SData;

	// Token: 0x040002F2 RID: 754
	public static Stage SceneStage;

	// Token: 0x040002F3 RID: 755
	public static byte SceneTheme;

	// Token: 0x040002F4 RID: 756
	public static byte SceneSide;

	// Token: 0x040002F5 RID: 757
	public static byte SceneID;

	// Token: 0x040002F6 RID: 758
	public AssetBundle Shader;

	// Token: 0x040002F7 RID: 759
	public UnityEngine.Object[] Shaders;

	// Token: 0x040002F8 RID: 760
	public static bool Reload;

	// Token: 0x040002F9 RID: 761
	public static bool Download;

	// Token: 0x040002FA RID: 762
	public static byte BuildLv;

	// Token: 0x040002FB RID: 763
	public static byte BuildState;

	// Token: 0x040002FC RID: 764
	public static AssetManager.AssAsset BigMac;

	// Token: 0x040002FD RID: 765
	public static AssetManager.AssAsset BigData;

	// Token: 0x040002FE RID: 766
	public static AssetManager.AssAsset BigWall;

	// Token: 0x040002FF RID: 767
	public static AssetManager.AssAsset BigCity;

	// Token: 0x04000300 RID: 768
	public static Transform[] BigMap = new Transform[11];

	// Token: 0x04000301 RID: 769
	public static Vector3 Bearing = new Vector3(0f, 0.1f, 0f);

	// Token: 0x04000302 RID: 770
	public static string persistentDataPath = Application.persistentDataPath;

	// Token: 0x02000036 RID: 54
	public struct AssRef
	{
		// Token: 0x06000172 RID: 370 RVA: 0x00017958 File Offset: 0x00015B58
		public bool Set(AssetBundle Ass)
		{
			this.Asset = Ass;
			if (Ass)
			{
				this.RefCount = 0;
				return false;
			}
			return NetworkManager.Miss();
		}

		// Token: 0x04000303 RID: 771
		public int RefCount;

		// Token: 0x04000304 RID: 772
		public bool Internal;

		// Token: 0x04000305 RID: 773
		public long Stamping;

		// Token: 0x04000306 RID: 774
		public AssetBundle Asset;
	}

	// Token: 0x02000037 RID: 55
	public struct AssAsset
	{
		// Token: 0x06000173 RID: 371 RVA: 0x0001798C File Offset: 0x00015B8C
		public bool Unload()
		{
			UnityEngine.Object.DestroyImmediate(this.Asset);
			this.Asset = null;
			if (this.Ass)
			{
				AssetManager.UnloadAssetBundle(this.AssKey, true);
				return true;
			}
			return false;
		}

		// Token: 0x04000307 RID: 775
		public int AssKey;

		// Token: 0x04000308 RID: 776
		public UnityEngine.Object Asset;

		// Token: 0x04000309 RID: 777
		public AssetBundle Ass;
	}
}
