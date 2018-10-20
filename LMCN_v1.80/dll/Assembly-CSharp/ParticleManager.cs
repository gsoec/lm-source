using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x02000790 RID: 1936
public class ParticleManager
{
	// Token: 0x060027B0 RID: 10160 RVA: 0x0043ED6C File Offset: 0x0043CF6C
	public void PreLoadHeroEffect()
	{
		BattleController battleController = GameManager.ActiveGameplay as BattleController;
		if (battleController != null)
		{
			int playerCount = battleController.playerCount;
			for (int i = 0; i < playerCount; i++)
			{
				ushort npcID = battleController.playerUnit[i].NpcID;
				ushort[] preLoadParticleID = this.GetPreLoadParticleID(npcID);
				for (int j = 0; j < preLoadParticleID.Length; j++)
				{
					if (!this.stackDic.ContainsKey(preLoadParticleID[j]))
					{
						GameObject go = this.Spawn(preLoadParticleID[j], null, default(Vector3), 1f, false, true, true);
						if (!this.IsOnceEffect(go))
						{
							this.DeSpawn(go);
						}
					}
				}
			}
			this.ClearOnecEffect();
		}
	}

	// Token: 0x060027B1 RID: 10161 RVA: 0x0043EE2C File Offset: 0x0043D02C
	public void PreLoadEnemyEffect(int level)
	{
		BattleController battleController = GameManager.ActiveGameplay as BattleController;
		if (battleController != null && level < battleController.m_MaxStageLevel && level >= 0)
		{
			int num = battleController.teamTable[level].Arrays.Length;
			for (int i = 0; i < num; i++)
			{
				ushort hero = battleController.teamTable[level].Arrays[i].Hero;
				ushort[] preLoadParticleID = this.GetPreLoadParticleID(hero);
				for (int j = 0; j < preLoadParticleID.Length; j++)
				{
					if (!this.stackDic.ContainsKey(preLoadParticleID[j]))
					{
						GameObject go = this.Spawn(preLoadParticleID[j], null, default(Vector3), 1f, false, true, true);
						if (!this.IsOnceEffect(go))
						{
							this.DeSpawn(go);
						}
					}
				}
			}
			this.ClearOnecEffect();
		}
	}

	// Token: 0x060027B2 RID: 10162 RVA: 0x0043EF1C File Offset: 0x0043D11C
	private ushort[] GetPreLoadParticleID(ushort heroID)
	{
		ushort[] array = new ushort[20];
		if (DataManager.Instance.HeroTable == null)
		{
			return array;
		}
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(heroID);
		int num = recordByKey.AttackPower.Length;
		int num2 = 0;
		ushort num3 = 0;
		while ((int)num3 < num)
		{
			ushort inKey = recordByKey.AttackPower[(int)num3];
			Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(inKey);
			array[num2++] = recordByKey2.HitParticle;
			array[num2++] = recordByKey2.FireParticle;
			array[num2++] = recordByKey2.RangeHitParticle;
			array[num2++] = recordByKey2.FlyParticle;
			num3 += 1;
		}
		return array;
	}

	// Token: 0x17000103 RID: 259
	// (get) Token: 0x060027B3 RID: 10163 RVA: 0x0043EFDC File Offset: 0x0043D1DC
	public static ParticleManager Instance
	{
		get
		{
			if (ParticleManager.instance == null)
			{
				ParticleManager.instance = new ParticleManager();
			}
			return ParticleManager.instance;
		}
	}

	// Token: 0x060027B4 RID: 10164 RVA: 0x0043EFF8 File Offset: 0x0043D1F8
	public void Setup()
	{
		this.AllEffectObject = new GameObject();
		this.AllEffectObject.name = "AllEffect";
		this.GetAssetBundleByEffID(1);
		ParticleManager.bIsLoad = true;
	}

	// Token: 0x060027B5 RID: 10165 RVA: 0x0043F024 File Offset: 0x0043D224
	public void ShowDebug()
	{
		IDictionaryEnumerator dictionaryEnumerator = this.stackDic.GetEnumerator();
		Debug.Log("-----------------Particle ShowDebug-----------------");
		while (dictionaryEnumerator.MoveNext())
		{
			this.sb.Length = 0;
			this.sb.AppendFormat("StackName = {0}/Count = {1}", dictionaryEnumerator.Key, ((Stack<GameObject>)dictionaryEnumerator.Value).Count);
			Debug.Log(this.sb.ToString());
		}
		this.sb.Length = 0;
		this.sb.AppendFormat("TotalEffect = {0} / LoadCount = {1} / OnecEffectCount = {2}", this.totalEffect, this.LoadABCount, this.OnecEffectCount);
		Debug.Log(this.sb.ToString());
	}

	// Token: 0x060027B6 RID: 10166 RVA: 0x0043F0F4 File Offset: 0x0043D2F4
	public GameObject Spawn(ushort EffID, Transform parent, Vector3 position, float scale, bool active, bool bAttach = true, bool bCheckOnecEffect = true)
	{
		if (EffID == 0)
		{
			return null;
		}
		GameObject gameObject;
		if (this.stackDic.ContainsKey(EffID))
		{
			gameObject = this.Pop(EffID);
			this.SetParticle(gameObject, parent, position, scale, active, bAttach, true);
		}
		else
		{
			gameObject = this.CreateParticle(EffID);
			if (gameObject)
			{
				this.SetParticle(gameObject, parent, position, scale, active, bAttach, true);
				Stack<GameObject> value = new Stack<GameObject>();
				this.stackDic.Add(EffID, value);
			}
		}
		if (bCheckOnecEffect && this.IsOnceEffect(gameObject))
		{
			this.onecEffect.Add(gameObject);
		}
		if (gameObject)
		{
			gameObject.transform.localScale = new Vector3(scale, scale, scale);
		}
		return gameObject;
	}

	// Token: 0x060027B7 RID: 10167 RVA: 0x0043F1B0 File Offset: 0x0043D3B0
	public bool DeSpawn(GameObject go)
	{
		if (go == null)
		{
			return false;
		}
		ushort idbyName = this.GetIDByName(go.name);
		float x = go.transform.localScale.x;
		if (this.stackDic.ContainsKey(idbyName))
		{
			this.SetParticle(go, null, default(Vector3), x, false, false, false);
			if (this.AllEffectObject != null)
			{
				go.transform.SetParent(this.AllEffectObject.transform);
			}
			else
			{
				Debug.Log("AllEffectObject NULL");
			}
			this.stackDic[idbyName].Push(go);
			return true;
		}
		return false;
	}

	// Token: 0x060027B8 RID: 10168 RVA: 0x0043F260 File Offset: 0x0043D460
	public void Play(GameObject go, Transform parent, Vector3 position)
	{
		go.SetActive(true);
		go.transform.parent = parent;
		go.transform.localPosition = position;
		ParticleSystem component = go.transform.GetComponent<ParticleSystem>();
		if (component)
		{
			component.Play();
		}
	}

	// Token: 0x060027B9 RID: 10169 RVA: 0x0043F2AC File Offset: 0x0043D4AC
	public void Stop(GameObject go)
	{
		go.SetActive(false);
		ParticleSystem component = go.transform.GetComponent<ParticleSystem>();
		if (component)
		{
			component.Stop();
		}
	}

	// Token: 0x060027BA RID: 10170 RVA: 0x0043F2E0 File Offset: 0x0043D4E0
	public void Pause(GameObject go, bool pause)
	{
		if (go == null)
		{
			return;
		}
		int childCount = go.transform.childCount;
		ParticleSystem component = go.transform.GetComponent<ParticleSystem>();
		if (component)
		{
			if (pause)
			{
				component.Pause();
			}
			else if (component.isPaused)
			{
				component.Play();
			}
		}
		for (int i = 0; i < childCount; i++)
		{
			Transform child = go.transform.GetChild(i);
			this.Pause(child.gameObject, pause);
		}
	}

	// Token: 0x060027BB RID: 10171 RVA: 0x0043F370 File Offset: 0x0043D570
	public void Clear()
	{
		UnityEngine.Object.Destroy(this.AllEffectObject);
		this.AllEffectObject = null;
		this.onecEffect.Clear();
		this.stackDic.Clear();
		this.resourcesDic.Clear();
		this.abDic.Clear();
		this.bundleKeyList.Clear();
		this.UnLoadAB();
	}

	// Token: 0x060027BC RID: 10172 RVA: 0x0043F3CC File Offset: 0x0043D5CC
	public void Update()
	{
		for (int i = this.onecEffect.Count - 1; i >= 0; i--)
		{
			this.CheckOnecEffect(i);
		}
	}

	// Token: 0x060027BD RID: 10173 RVA: 0x0043F400 File Offset: 0x0043D600
	public void ClearOnecEffect()
	{
		for (int i = this.onecEffect.Count - 1; i >= 0; i--)
		{
			this.DeSpawn(this.onecEffect[i]);
			this.onecEffect.RemoveAt(i);
		}
		this.OnecEffectCount = this.onecEffect.Count;
		Debug.Log("ClearOnecEffect");
	}

	// Token: 0x060027BE RID: 10174 RVA: 0x0043F468 File Offset: 0x0043D668
	public GameObject GetAllEffecet()
	{
		return this.AllEffectObject;
	}

	// Token: 0x060027BF RID: 10175 RVA: 0x0043F470 File Offset: 0x0043D670
	private void CheckOnecEffect(int i)
	{
		bool flag = false;
		ParticleSystem component = this.onecEffect[i].GetComponent<ParticleSystem>();
		if (component)
		{
			flag = component.IsAlive();
		}
		int childCount = this.onecEffect[i].transform.childCount;
		for (int j = 0; j < childCount; j++)
		{
			Transform child = this.onecEffect[i].transform.GetChild(j);
			if (child)
			{
				component = child.GetComponent<ParticleSystem>();
				bool flag2 = component.IsAlive();
				if (component && flag2)
				{
					flag = flag2;
				}
			}
		}
		if (!flag)
		{
			this.DeSpawn(this.onecEffect[i]);
			this.onecEffect.RemoveAt(i);
			this.OnecEffectCount = this.onecEffect.Count;
		}
	}

	// Token: 0x060027C0 RID: 10176 RVA: 0x0043F554 File Offset: 0x0043D754
	private void CheckNeedAddToList(GameObject go)
	{
		if (go == null)
		{
			return;
		}
		ParticleSystem component = go.transform.GetComponent<ParticleSystem>();
		if (component)
		{
			if (!component.loop)
			{
				this.onecEffect.Add(go);
			}
		}
		else
		{
			Transform child = go.transform.GetChild(0);
			component = child.GetComponent<ParticleSystem>();
			if (component && !component.loop)
			{
				this.onecEffect.Add(go);
			}
		}
	}

	// Token: 0x060027C1 RID: 10177 RVA: 0x0043F5E0 File Offset: 0x0043D7E0
	public bool IsOnceEffect(GameObject go)
	{
		if (go == null)
		{
			return false;
		}
		bool result = false;
		ParticleSystem component = go.transform.GetComponent<ParticleSystem>();
		if (component)
		{
			if (!component.loop)
			{
				result = true;
			}
		}
		else
		{
			Transform child = go.transform.GetChild(0);
			component = child.GetComponent<ParticleSystem>();
			if (component && !component.loop)
			{
				result = true;
			}
		}
		return result;
	}

	// Token: 0x060027C2 RID: 10178 RVA: 0x0043F65C File Offset: 0x0043D85C
	private void UnLoadAB()
	{
		for (int i = 0; i < this.bundleKeyList.Count; i++)
		{
			AssetManager.UnloadAssetBundle(this.bundleKeyList[i], true);
		}
		ParticleManager.bIsLoad = false;
	}

	// Token: 0x060027C3 RID: 10179 RVA: 0x0043F6A0 File Offset: 0x0043D8A0
	private string GetNameByID(ushort EffID)
	{
		this.sb.Length = 0;
		this.sb.AppendFormat("Effect_{0:00000}", EffID);
		return this.sb.ToString();
	}

	// Token: 0x060027C4 RID: 10180 RVA: 0x0043F6DC File Offset: 0x0043D8DC
	private ushort GetIDByName(string Name)
	{
		ushort result = 0;
		string s = Name.Substring(7);
		ushort.TryParse(s, out result);
		return result;
	}

	// Token: 0x060027C5 RID: 10181 RVA: 0x0043F700 File Offset: 0x0043D900
	private string GetAbNamebyID(ushort EffID)
	{
		this.sb.Length = 0;
		ushort abNumByEffID = this.GetAbNumByEffID(EffID);
		if (EffID >= 10000)
		{
			this.sb.AppendFormat("Particle/Monster_Effects_{0:000}", abNumByEffID);
		}
		else
		{
			this.sb.AppendFormat("Particle/Effects_{0:000}", abNumByEffID);
		}
		return this.sb.ToString();
	}

	// Token: 0x060027C6 RID: 10182 RVA: 0x0043F76C File Offset: 0x0043D96C
	private ushort GetAbNumByEffID(ushort EffID)
	{
		if (EffID >= 10000)
		{
			return EffID / 100;
		}
		ushort result;
		if (EffID % 400 == 0)
		{
			result = EffID / 400;
		}
		else
		{
			result = EffID / 400 + 1;
		}
		return result;
	}

	// Token: 0x060027C7 RID: 10183 RVA: 0x0043F7B4 File Offset: 0x0043D9B4
	private AssetBundle GetAssetBundleByEffID(ushort EffID)
	{
		if (EffID == 0)
		{
			return null;
		}
		ushort abNumByEffID = this.GetAbNumByEffID(EffID);
		AssetBundle assetBundle;
		if (this.abDic.ContainsKey(abNumByEffID))
		{
			assetBundle = this.abDic[abNumByEffID];
		}
		else
		{
			int item;
			assetBundle = AssetManager.GetAssetBundle(this.GetAbNamebyID(EffID), out item, false);
			if (assetBundle)
			{
				this.abDic.Add(abNumByEffID, assetBundle);
				this.bundleKeyList.Add(item);
			}
		}
		return assetBundle;
	}

	// Token: 0x060027C8 RID: 10184 RVA: 0x0043F82C File Offset: 0x0043DA2C
	private GameObject Pop(ushort EffID)
	{
		Stack<GameObject> stack = this.stackDic[EffID];
		if (stack.Count > 0)
		{
			return stack.Pop();
		}
		return this.CreateParticle(EffID);
	}

	// Token: 0x060027C9 RID: 10185 RVA: 0x0043F860 File Offset: 0x0043DA60
	private void Push(ushort EffID, GameObject go)
	{
		this.effName = this.GetNameByID(EffID);
		this.stackDic[EffID].Push(go);
	}

	// Token: 0x060027CA RID: 10186 RVA: 0x0043F884 File Offset: 0x0043DA84
	private GameObject CreateParticle(ushort EffID)
	{
		UnityEngine.Object @object = this.LoadEffect(EffID);
		if (@object == null)
		{
			return null;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
		float x = gameObject.transform.localScale.x;
		this.SetParticleScale(gameObject, x, false);
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.name = this.GetNameByID(EffID);
		gameObject.transform.SetParent(this.AllEffectObject.transform);
		this.totalEffect++;
		return gameObject;
	}

	// Token: 0x060027CB RID: 10187 RVA: 0x0043F924 File Offset: 0x0043DB24
	private UnityEngine.Object LoadEffect(ushort EffID)
	{
		AssetBundle assetBundleByEffID = this.GetAssetBundleByEffID(EffID);
		if (assetBundleByEffID == null)
		{
			return null;
		}
		this.effName = this.GetNameByID(EffID);
		if (assetBundleByEffID == null)
		{
			return null;
		}
		UnityEngine.Object @object;
		if (this.resourcesDic.ContainsKey(EffID))
		{
			@object = this.resourcesDic[EffID];
		}
		else
		{
			@object = assetBundleByEffID.Load(this.effName);
			this.resourcesDic.Add(EffID, @object);
			this.LoadABCount++;
		}
		return @object;
	}

	// Token: 0x060027CC RID: 10188 RVA: 0x0043F9B0 File Offset: 0x0043DBB0
	private void SetParticle(GameObject go, Transform parent, Vector3 position, float scale, bool active, bool bAttach = true, bool bMultiply = true)
	{
		if (!go)
		{
			return;
		}
		if (!bAttach)
		{
			if (parent)
			{
				go.transform.rotation = parent.rotation;
			}
			go.transform.position = position;
		}
		else
		{
			go.transform.parent = parent;
			go.transform.localPosition = position;
		}
		this.SetParticleScale(go, scale, bMultiply);
		if (bMultiply)
		{
			go.transform.localScale = new Vector3(scale, scale, scale);
		}
		else
		{
			go.transform.localScale = new Vector3(1f, 1f, 1f);
		}
		go.SetActive(active);
	}

	// Token: 0x060027CD RID: 10189 RVA: 0x0043FA6C File Offset: 0x0043DC6C
	private void SetParticleScale(GameObject go, float scale, bool bMultiply = true)
	{
		if (!go)
		{
			return;
		}
		int childCount = go.transform.childCount;
		ParticleSystem component = go.GetComponent<ParticleSystem>();
		if (component)
		{
			if (bMultiply)
			{
				component.startSize *= scale;
				component.startSpeed *= scale;
				ParticleSystem.Particle[] array = new ParticleSystem.Particle[component.particleCount];
				component.GetParticles(array);
				for (int i = 0; i < array.Length; i++)
				{
					ParticleSystem.Particle[] array2 = array;
					int num = i;
					array2[num].velocity = array2[num].velocity * scale;
				}
				component.SetParticles(array, array.Length);
			}
			else
			{
				component.startSize /= scale;
				component.startSpeed /= scale;
				ParticleSystem.Particle[] array = new ParticleSystem.Particle[component.particleCount];
				component.GetParticles(array);
				for (int j = 0; j < array.Length; j++)
				{
					ParticleSystem.Particle[] array3 = array;
					int num2 = j;
					array3[num2].velocity = array3[num2].velocity / scale;
				}
				component.SetParticles(array, array.Length);
			}
		}
		for (int k = 0; k < childCount; k++)
		{
			Transform child = go.transform.GetChild(k);
			this.SetParticleScale(child.gameObject, scale, bMultiply);
		}
	}

	// Token: 0x04007152 RID: 29010
	private const ushort MaxAbEffectNum = 400;

	// Token: 0x04007153 RID: 29011
	private static ParticleManager instance;

	// Token: 0x04007154 RID: 29012
	private StringBuilder sb = new StringBuilder();

	// Token: 0x04007155 RID: 29013
	private string effName;

	// Token: 0x04007156 RID: 29014
	private string abName;

	// Token: 0x04007157 RID: 29015
	private Dictionary<ushort, Stack<GameObject>> stackDic = new Dictionary<ushort, Stack<GameObject>>();

	// Token: 0x04007158 RID: 29016
	private Dictionary<ushort, UnityEngine.Object> resourcesDic = new Dictionary<ushort, UnityEngine.Object>();

	// Token: 0x04007159 RID: 29017
	private List<GameObject> onecEffect = new List<GameObject>();

	// Token: 0x0400715A RID: 29018
	private Dictionary<ushort, AssetBundle> abDic = new Dictionary<ushort, AssetBundle>();

	// Token: 0x0400715B RID: 29019
	private List<int> bundleKeyList = new List<int>();

	// Token: 0x0400715C RID: 29020
	private int assetBundleKey;

	// Token: 0x0400715D RID: 29021
	private int totalEffect;

	// Token: 0x0400715E RID: 29022
	private int LoadABCount;

	// Token: 0x0400715F RID: 29023
	private int OnecEffectCount;

	// Token: 0x04007160 RID: 29024
	public GameObject AllEffectObject;

	// Token: 0x04007161 RID: 29025
	public static bool bIsLoad;
}
