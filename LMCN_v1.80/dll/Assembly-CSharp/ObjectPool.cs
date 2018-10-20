using System;
using UnityEngine;

// Token: 0x020001B9 RID: 441
public sealed class ObjectPool<T> where T : class, new()
{
	// Token: 0x0600075E RID: 1886 RVA: 0x000A2284 File Offset: 0x000A0484
	public ObjectPool(T t, int initialCapacity, bool bPrefab = false)
	{
		this.instancesToPreallocate = initialCapacity;
		this._gameObjectPool = new T[this.instancesToPreallocate];
		this.allocateGameObjects(t, bPrefab);
	}

    // Token: 0x0600075F RID: 1887 RVA: 0x000A22B4 File Offset: 0x000A04B4
    ~ObjectPool()
	{
			if (this._gameObjectPool != null)
			{
				for (int i = 0; i < this.instancesToPreallocate; i++)
				{
					this._gameObjectPool[i] = (T)((object)null);
				}
				this._gameObjectPool = null;
			}
	}

	// Token: 0x06000760 RID: 1888 RVA: 0x000A2324 File Offset: 0x000A0524
	public T spawn()
	{
		return this.pop();
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x000A233C File Offset: 0x000A053C
	public void despawn(T t)
	{
		GameObject gameObject = t as GameObject;
		if (gameObject != null)
		{
			gameObject.SetActive(false);
		}
		this._gameObjectPool[this.instancesToPreallocate - this._spawnedInstanceCount] = t;
		this._spawnedInstanceCount--;
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x000A2390 File Offset: 0x000A0590
	private void allocateGameObjects(T t, bool bPrefab)
	{
		int i = 0;
		GameObject gameObject = t as GameObject;
		if (gameObject != null)
		{
			if (!bPrefab)
			{
				this._gameObjectPool[i++] = t;
			}
			gameObject.transform.parent = null;
			gameObject.SetActive(false);
			while (i < this.instancesToPreallocate)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject) as GameObject;
				if (gameObject2 != null)
				{
					gameObject2.name = gameObject.name;
					gameObject2.transform.parent = null;
					gameObject2.SetActive(false);
				}
				this._gameObjectPool[i] = (gameObject2 as T);
				i++;
			}
		}
		else
		{
			while (i < this.instancesToPreallocate)
			{
				T t2 = Activator.CreateInstance<T>();
				this._gameObjectPool[i] = t2;
				i++;
			}
		}
	}

	// Token: 0x06000763 RID: 1891 RVA: 0x000A2478 File Offset: 0x000A0678
	private T pop()
	{
		if (this._spawnedInstanceCount < this.instancesToPreallocate)
		{
			this._spawnedInstanceCount++;
			T result = this._gameObjectPool[this.instancesToPreallocate - this._spawnedInstanceCount];
			this._gameObjectPool[this.instancesToPreallocate - this._spawnedInstanceCount] = (T)((object)null);
			return result;
		}
		return (T)((object)null);
	}

	// Token: 0x04001B87 RID: 7047
	public int instancesToPreallocate = 5;

	// Token: 0x04001B88 RID: 7048
	private int _spawnedInstanceCount;

	// Token: 0x04001B89 RID: 7049
	private T[] _gameObjectPool;
}
