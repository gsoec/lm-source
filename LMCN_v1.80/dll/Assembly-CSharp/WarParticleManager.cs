using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x0200074F RID: 1871
public class WarParticleManager
{
	// Token: 0x060023EC RID: 9196 RVA: 0x0041C8DC File Offset: 0x0041AADC
	public void Setup()
	{
		this.AllEffectObject = new GameObject();
		this.AllEffectObject.name = "AllEffect";
		this.ab = AssetManager.GetAssetBundle("Particle/WarEffects", out this.assetBundleKey, false);
		WarParticleManager.bIsLoad = true;
	}

	// Token: 0x060023ED RID: 9197 RVA: 0x0041C924 File Offset: 0x0041AB24
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

	// Token: 0x060023EE RID: 9198 RVA: 0x0041C9F4 File Offset: 0x0041ABF4
	public GameObject Spawn(ushort EffID, Transform parent, Vector3 position, float scale, bool active, bool bAttach = true)
	{
		SEffData seffData;
		if (this.stackDic.ContainsKey(EffID))
		{
			seffData = this.Pop(EffID);
			this.SetParticle(seffData.gameObject, parent, position, scale, active, bAttach, true);
		}
		else
		{
			GameObject gameObject = this.CreateParticle(EffID);
			if (gameObject == null)
			{
				return null;
			}
			this.SetParticle(gameObject, parent, position, scale, active, bAttach, true);
			Stack<SEffData> value = new Stack<SEffData>();
			this.stackDic.Add(EffID, value);
			seffData = default(SEffData);
			seffData.gameObject = gameObject;
			seffData.particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
		}
		if (this.IsOnceEffect(seffData))
		{
			this.onecEffect.Add(seffData);
		}
		if (seffData.gameObject)
		{
			seffData.gameObject.transform.localScale = new Vector3(scale, scale, scale);
		}
		return seffData.gameObject;
	}

	// Token: 0x060023EF RID: 9199 RVA: 0x0041CAD8 File Offset: 0x0041ACD8
	public GameObject SpawnWithoutManager(ushort EffID)
	{
		return this.LoadEffect(this.ab, EffID) as GameObject;
	}

	// Token: 0x060023F0 RID: 9200 RVA: 0x0041CAEC File Offset: 0x0041ACEC
	public bool DeSpawn(SEffData eData)
	{
		if (eData.gameObject == null)
		{
			return false;
		}
		ushort idbyName = this.GetIDByName(eData.gameObject.name);
		float x = eData.gameObject.transform.localScale.x;
		if (this.stackDic.ContainsKey(idbyName))
		{
			this.SetParticle(eData.gameObject, null, default(Vector3), x, false, false, false);
			eData.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			if (this.AllEffectObject != null)
			{
				eData.gameObject.transform.SetParent(this.AllEffectObject.transform);
			}
			else
			{
				Debug.Log("AllEffectObject NULL");
			}
			this.stackDic[idbyName].Push(eData);
			return true;
		}
		return false;
	}

	// Token: 0x060023F1 RID: 9201 RVA: 0x0041CBDC File Offset: 0x0041ADDC
	public bool DeSpawn(GameObject go)
	{
		if (go == null)
		{
			return false;
		}
		SEffData t = default(SEffData);
		t.gameObject = go;
		t.particleSystem = go.GetComponentInChildren<ParticleSystem>();
		ushort idbyName = this.GetIDByName(t.gameObject.name);
		float x = t.gameObject.transform.localScale.x;
		if (this.stackDic.ContainsKey(idbyName))
		{
			this.SetParticle(t.gameObject, null, default(Vector3), x, false, false, false);
			t.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			if (this.AllEffectObject != null)
			{
				t.gameObject.transform.SetParent(this.AllEffectObject.transform);
			}
			else
			{
				Debug.Log("AllEffectObject NULL");
			}
			this.stackDic[idbyName].Push(t);
			return true;
		}
		return false;
	}

	// Token: 0x060023F2 RID: 9202 RVA: 0x0041CCE4 File Offset: 0x0041AEE4
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

	// Token: 0x060023F3 RID: 9203 RVA: 0x0041CD30 File Offset: 0x0041AF30
	public void Stop(GameObject go)
	{
		go.SetActive(false);
		ParticleSystem component = go.transform.GetComponent<ParticleSystem>();
		if (component)
		{
			component.Stop();
		}
	}

	// Token: 0x060023F4 RID: 9204 RVA: 0x0041CD64 File Offset: 0x0041AF64
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
			else
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

	// Token: 0x060023F5 RID: 9205 RVA: 0x0041CDE8 File Offset: 0x0041AFE8
	public void Clear()
	{
		UnityEngine.Object.Destroy(this.AllEffectObject);
		this.AllEffectObject = null;
		this.onecEffect.Clear();
		this.stackDic.Clear();
		this.resourcesDic.Clear();
		this.UnLoadAB();
	}

	// Token: 0x060023F6 RID: 9206 RVA: 0x0041CE30 File Offset: 0x0041B030
	public void Update()
	{
		for (int i = this.onecEffect.Count - 1; i >= 0; i--)
		{
			this.CheckOnecEffect(i);
		}
	}

	// Token: 0x060023F7 RID: 9207 RVA: 0x0041CE64 File Offset: 0x0041B064
	public void ClearOnecEffect()
	{
		for (int i = this.onecEffect.Count - 1; i >= 0; i--)
		{
			this.DeSpawn(this.onecEffect[i]);
		}
		this.onecEffect.Clear();
		this.OnecEffectCount = this.onecEffect.Count;
		Debug.Log("ClearOnecEffect");
	}

	// Token: 0x060023F8 RID: 9208 RVA: 0x0041CEC8 File Offset: 0x0041B0C8
	public GameObject GetAllEffecet()
	{
		return this.AllEffectObject;
	}

	// Token: 0x060023F9 RID: 9209 RVA: 0x0041CED0 File Offset: 0x0041B0D0
	private void CheckOnecEffect(int i)
	{
		if (!this.onecEffect[i].particleSystem.IsAlive())
		{
			this.DeSpawn(this.onecEffect[i]);
			this.onecEffect.RemoveAt(i);
			this.OnecEffectCount = this.onecEffect.Count;
		}
	}

	// Token: 0x060023FA RID: 9210 RVA: 0x0041CF30 File Offset: 0x0041B130
	private bool IsOnceEffect(GameObject go)
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

	// Token: 0x060023FB RID: 9211 RVA: 0x0041CFAC File Offset: 0x0041B1AC
	private bool IsOnceEffect(SEffData data)
	{
		return !(data.gameObject == null) && !data.particleSystem.loop;
	}

	// Token: 0x060023FC RID: 9212 RVA: 0x0041CFD4 File Offset: 0x0041B1D4
	private void UnLoadAB()
	{
		if (this.ab)
		{
			AssetManager.UnloadAssetBundle(this.assetBundleKey, true);
			WarParticleManager.bIsLoad = false;
		}
	}

	// Token: 0x060023FD RID: 9213 RVA: 0x0041D004 File Offset: 0x0041B204
	private string GetNameByID(ushort EffID)
	{
		this.sb.Length = 0;
		this.sb.AppendFormat("{0:0000}", EffID);
		return this.sb.ToString();
	}

	// Token: 0x060023FE RID: 9214 RVA: 0x0041D040 File Offset: 0x0041B240
	private ushort GetIDByName(string Name)
	{
		ushort result = 0;
		ushort.TryParse(Name, out result);
		return result;
	}

	// Token: 0x060023FF RID: 9215 RVA: 0x0041D05C File Offset: 0x0041B25C
	private SEffData Pop(ushort EffID)
	{
		Stack<SEffData> stack = this.stackDic[EffID];
		if (stack.Count > 0)
		{
			return stack.Pop();
		}
		SEffData result = default(SEffData);
		result.gameObject = this.CreateParticle(EffID);
		result.particleSystem = result.gameObject.GetComponentInChildren<ParticleSystem>();
		return result;
	}

	// Token: 0x06002400 RID: 9216 RVA: 0x0041D0B4 File Offset: 0x0041B2B4
	private GameObject CreateParticle(ushort EffID)
	{
		UnityEngine.Object @object = this.LoadEffect(this.ab, EffID);
		if (@object == null)
		{
			return null;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
		gameObject.name = EffID.ToString();
		gameObject.transform.SetParent(this.AllEffectObject.transform);
		this.totalEffect++;
		return gameObject;
	}

	// Token: 0x06002401 RID: 9217 RVA: 0x0041D11C File Offset: 0x0041B31C
	private UnityEngine.Object LoadEffect(AssetBundle ab, ushort EffID)
	{
		if (ab == null)
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
			this.effName = this.GetNameByID(EffID);
			@object = ab.Load(this.effName);
			this.resourcesDic.Add(EffID, @object);
			this.LoadABCount++;
		}
		return @object;
	}

	// Token: 0x06002402 RID: 9218 RVA: 0x0041D194 File Offset: 0x0041B394
	private void SetParticle(GameObject go, Transform parent, Vector3 position, float scale, bool active, bool bAttach = true, bool bMultiply = true)
	{
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
		go.SetActive(active);
	}

	// Token: 0x06002403 RID: 9219 RVA: 0x0041D1F8 File Offset: 0x0041B3F8
	private void SetParticleScale(GameObject go, float scale, bool bMultiply = true)
	{
		int childCount = go.transform.childCount;
		float num = Mathf.Abs(scale);
		ParticleSystem component = go.GetComponent<ParticleSystem>();
		if (component)
		{
			if (bMultiply)
			{
				component.startSize *= num;
				component.startSpeed *= num;
				ParticleSystem.Particle[] array = new ParticleSystem.Particle[component.particleCount];
				component.GetParticles(array);
				for (int i = 0; i < array.Length; i++)
				{
					ParticleSystem.Particle[] array2 = array;
					int num2 = i;
					array2[num2].velocity = array2[num2].velocity * num;
				}
				component.SetParticles(array, array.Length);
			}
			else
			{
				component.startSize /= num;
				component.startSpeed /= num;
				ParticleSystem.Particle[] array = new ParticleSystem.Particle[component.particleCount];
				component.GetParticles(array);
				for (int j = 0; j < array.Length; j++)
				{
					ParticleSystem.Particle[] array3 = array;
					int num3 = j;
					array3[num3].velocity = array3[num3].velocity / num;
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

	// Token: 0x04006DD4 RID: 28116
	private StringBuilder sb = new StringBuilder();

	// Token: 0x04006DD5 RID: 28117
	private string effName;

	// Token: 0x04006DD6 RID: 28118
	private Dictionary<ushort, Stack<SEffData>> stackDic = new Dictionary<ushort, Stack<SEffData>>();

	// Token: 0x04006DD7 RID: 28119
	private Dictionary<ushort, UnityEngine.Object> resourcesDic = new Dictionary<ushort, UnityEngine.Object>(128);

	// Token: 0x04006DD8 RID: 28120
	private List<SEffData> onecEffect = new List<SEffData>(128);

	// Token: 0x04006DD9 RID: 28121
	private AssetBundle ab;

	// Token: 0x04006DDA RID: 28122
	private int assetBundleKey;

	// Token: 0x04006DDB RID: 28123
	private int totalEffect;

	// Token: 0x04006DDC RID: 28124
	private int LoadABCount;

	// Token: 0x04006DDD RID: 28125
	private int OnecEffectCount;

	// Token: 0x04006DDE RID: 28126
	private GameObject AllEffectObject;

	// Token: 0x04006DDF RID: 28127
	public static bool bIsLoad;
}
