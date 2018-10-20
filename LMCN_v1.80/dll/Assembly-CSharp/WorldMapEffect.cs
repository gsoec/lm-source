using System;
using UnityEngine;

// Token: 0x02000282 RID: 642
public class WorldMapEffect
{
	// Token: 0x06000C66 RID: 3174 RVA: 0x0011F0A4 File Offset: 0x0011D2A4
	public WorldMapEffect(Transform totalityGroup, float tileBaseScale)
	{
		GameObject gameObject = new GameObject("WorldMapTileEffect");
		this.EffectLayoutTransform = gameObject.transform;
		this.TotalityGroup = totalityGroup;
		this.EffectLayoutTransform.localScale = Vector3.one * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
		this.EffectLayoutTransform.position = Vector3.forward * 1024f * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
		this.EffectLayoutTransform.SetParent(totalityGroup, false);
		gameObject = new GameObject("MapTileEffectWin");
		this.ActLayoutTransform = gameObject.transform;
		this.ActLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		this.ActpoolsCounter = 0;
	}

	// Token: 0x06000C67 RID: 3175 RVA: 0x0011F184 File Offset: 0x0011D384
	public void OnDestroy()
	{
		if (this.EffectActGameObject != null)
		{
			for (int i = 0; i < this.EffectActGameObject.Length; i++)
			{
				for (int j = 0; j < this.EffectActGameObject[i].Length; j++)
				{
					if (this.EffectActGameObject[i][j] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectActGameObject[i][j]);
						this.EffectActGameObject[i][j] = null;
						this.EffectActTransform[i][j] = null;
						this.EffectActParticle[i][j] = null;
						this.EffectActParticle_one[i][j] = null;
						this.EffectActParticle_two[i][j] = null;
						this.EffectActParticle_three[i][j] = null;
					}
				}
				this.EffectActGameObject[i] = null;
				this.EffectActTransform[i] = null;
				this.EffectActParticle[i] = null;
				this.EffectActParticle_one[i] = null;
				this.EffectActParticle_two[i] = null;
				this.EffectActParticle_three[i] = null;
			}
		}
		this.EffectActGameObject = null;
		this.EffectActTransform = null;
		this.EffectActParticle = null;
		this.EffectActParticle_one = null;
		this.EffectActParticle_two = null;
		this.EffectActParticle_three = null;
		if (this.EffectActGameObjectPools != null)
		{
			for (int k = 0; k < this.EffectActGameObjectPools.Length; k++)
			{
				if (this.EffectActGameObjectPools[k] != null)
				{
					for (int l = 0; l < this.EffectActGameObjectPools[k].Length; l++)
					{
						if (this.EffectActGameObjectPools[k][l] != null)
						{
							ParticleManager.Instance.DeSpawn(this.EffectActGameObjectPools[k][l]);
							this.EffectActGameObjectPools[k][l] = null;
							this.EffectActTransformPools[k][l] = null;
							this.EffectActParticlePools[k][l] = null;
							this.EffectActParticlePools_one[k][l] = null;
							this.EffectActParticlePools_two[k][l] = null;
							this.EffectActParticlePools_three[k][l] = null;
						}
					}
					this.EffectActGameObjectPools[k] = null;
					this.EffectActTransformPools[k] = null;
					this.EffectActParticlePools[k] = null;
					this.EffectActParticlePools_one[k] = null;
					this.EffectActParticlePools_two[k] = null;
					this.EffectActParticlePools_three[k] = null;
				}
			}
		}
		this.EffectActGameObjectPools = null;
		this.EffectActTransformPools = null;
		this.EffectActParticlePools = null;
		this.EffectActParticlePools_one = null;
		this.EffectActParticlePools_two = null;
		this.EffectActParticlePools_three = null;
		if (this.ActpoolCounter != null)
		{
			Array.Clear(this.ActpoolCounter, 0, this.ActpoolCounter.Length);
		}
	}

	// Token: 0x06000C68 RID: 3176 RVA: 0x0011F3D4 File Offset: 0x0011D5D4
	public void IniEffect(int rowNum, int colNum, float tileBaseScale)
	{
		this.EffectActGameObject = new GameObject[colNum][];
		this.EffectActTransform = new Transform[colNum][];
		this.EffectActParticle = new ParticleSystem[colNum][];
		this.EffectActParticle_one = new ParticleSystem[colNum][];
		this.EffectActParticle_two = new ParticleSystem[colNum][];
		this.EffectActParticle_three = new ParticleSystem[colNum][];
		for (int i = 0; i < colNum; i++)
		{
			this.EffectActGameObject[i] = new GameObject[rowNum];
			this.EffectActTransform[i] = new Transform[rowNum];
			this.EffectActParticle[i] = new ParticleSystem[rowNum];
			this.EffectActParticle_one[i] = new ParticleSystem[rowNum];
			this.EffectActParticle_two[i] = new ParticleSystem[rowNum];
			this.EffectActParticle_three[i] = new ParticleSystem[rowNum];
			Array.Clear(this.EffectActGameObject[i], 0, this.EffectActGameObject[i].Length);
			Array.Clear(this.EffectActTransform[i], 0, this.EffectActTransform[i].Length);
			Array.Clear(this.EffectActParticle[i], 0, this.EffectActParticle[i].Length);
			Array.Clear(this.EffectActParticle_one[i], 0, this.EffectActParticle_one[i].Length);
			Array.Clear(this.EffectActParticle_two[i], 0, this.EffectActParticle_two[i].Length);
			Array.Clear(this.EffectActParticle_three[i], 0, this.EffectActParticle_three[i].Length);
		}
		this.EffectActGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectActTransformPools = new Transform[rowNum << 1][];
		this.EffectActParticlePools = new ParticleSystem[rowNum << 1][];
		this.EffectActParticlePools_one = new ParticleSystem[rowNum << 1][];
		this.EffectActParticlePools_two = new ParticleSystem[rowNum << 1][];
		this.EffectActParticlePools_three = new ParticleSystem[rowNum << 1][];
		this.ActpoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectActGameObjectPools, 0, this.EffectActGameObjectPools.Length);
		Array.Clear(this.EffectActTransformPools, 0, this.EffectActTransformPools.Length);
		Array.Clear(this.EffectActParticlePools, 0, this.EffectActParticlePools.Length);
		Array.Clear(this.EffectActParticlePools_one, 0, this.EffectActParticlePools_one.Length);
		Array.Clear(this.EffectActParticlePools_two, 0, this.EffectActParticlePools_two.Length);
		Array.Clear(this.EffectActParticlePools_three, 0, this.EffectActParticlePools_three.Length);
		for (int j = 0; j < this.ActpoolCounter.Length; j++)
		{
			this.ActpoolCounter[j] = -1;
		}
		this.EffectActGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectActTransformPools[0] = new Transform[colNum >> 1];
		this.EffectActParticlePools[0] = new ParticleSystem[colNum >> 1];
		this.EffectActParticlePools_one[0] = new ParticleSystem[colNum >> 1];
		this.EffectActParticlePools_two[0] = new ParticleSystem[colNum >> 1];
		this.EffectActParticlePools_three[0] = new ParticleSystem[colNum >> 1];
		for (int k = 0; k < this.EffectActGameObjectPools[0].Length; k++)
		{
			this.EffectActGameObjectPools[0][k] = ParticleManager.Instance.Spawn(60201, null, Vector3.zero, 1f, false, false, true);
			this.EffectActTransformPools[0][k] = this.EffectActGameObjectPools[0][k].transform;
			this.EffectActTransformPools[0][k].SetParent(this.ActLayoutTransform);
			this.EffectActTransformPools[0][k].localPosition = this.inipos;
			this.EffectActParticlePools[0][k] = this.EffectActTransformPools[0][k].GetChild(0).GetComponent<ParticleSystem>();
			this.EffectActParticlePools_one[0][k] = this.EffectActTransformPools[0][k].GetChild(1).GetComponent<ParticleSystem>();
			this.EffectActParticlePools_two[0][k] = this.EffectActTransformPools[0][k].GetChild(2).GetComponent<ParticleSystem>();
			this.EffectActParticlePools_three[0][k] = this.EffectActTransformPools[0][k].GetChild(3).GetComponent<ParticleSystem>();
		}
		this.ActstartSize = this.EffectActParticlePools[0][0].startSize;
		this.Actlifetime = this.EffectActParticlePools[0][0].startLifetime;
		this.ActstartSize_one = this.EffectActParticlePools_one[0][0].startSize;
		this.Actlifetime_one = this.EffectActParticlePools_one[0][0].startLifetime;
		this.ActstartSize_two = this.EffectActParticlePools_two[0][0].startSize;
		this.Actlifetime_two = this.EffectActParticlePools_two[0][0].startLifetime;
		this.ActstartSize_three = this.EffectActParticlePools_three[0][0].startSize;
		this.Actlifetime_three = this.EffectActParticlePools_three[0][0].startLifetime;
		this.ActpoolCounter[0] = colNum >> 1;
		this.ActpoolsCounter = 1;
	}

	// Token: 0x06000C69 RID: 3177 RVA: 0x0011F838 File Offset: 0x0011DA38
	public void setEffect(byte effectflag, int row, int col, Vector2 pos, byte effecttype = 0)
	{
		float x = this.TotalityGroup.localScale.x;
		if ((effectflag & 1) == 0)
		{
			if (this.EffectActGameObject[col][row] != null)
			{
				this.EffectActGameObject[col][row].SetActive(false);
				for (int i = 0; i < this.ActpoolsCounter; i++)
				{
					if (this.ActpoolCounter[i] < this.EffectActGameObjectPools[i].Length)
					{
						this.EffectActGameObjectPools[i][this.ActpoolCounter[i]] = this.EffectActGameObject[col][row];
						this.EffectActTransformPools[i][this.ActpoolCounter[i]] = this.EffectActTransform[col][row];
						this.EffectActParticlePools[i][this.ActpoolCounter[i]] = this.EffectActParticle[col][row];
						this.EffectActParticlePools_one[i][this.ActpoolCounter[i]] = this.EffectActParticle_one[col][row];
						this.EffectActParticlePools_two[i][this.ActpoolCounter[i]] = this.EffectActParticle_two[col][row];
						this.EffectActParticlePools_three[i][this.ActpoolCounter[i]] = this.EffectActParticle_three[col][row];
						this.EffectActGameObject[col][row] = null;
						this.EffectActTransform[col][row] = null;
						this.EffectActParticle[col][row] = null;
						this.EffectActParticle_one[col][row] = null;
						this.EffectActParticle_two[col][row] = null;
						this.EffectActParticle_three[col][row] = null;
						this.ActpoolCounter[i]++;
						break;
					}
				}
			}
		}
		else
		{
			if (this.EffectActGameObject[col][row] == null)
			{
				int j;
				for (j = 0; j < this.ActpoolsCounter; j++)
				{
					if (this.ActpoolCounter[j] > 0)
					{
						this.ActpoolCounter[j]--;
						this.EffectActGameObject[col][row] = this.EffectActGameObjectPools[j][this.ActpoolCounter[j]];
						this.EffectActTransform[col][row] = this.EffectActTransformPools[j][this.ActpoolCounter[j]];
						this.EffectActParticle[col][row] = this.EffectActParticlePools[j][this.ActpoolCounter[j]];
						this.EffectActParticle_one[col][row] = this.EffectActParticlePools_one[j][this.ActpoolCounter[j]];
						this.EffectActParticle_two[col][row] = this.EffectActParticlePools_two[j][this.ActpoolCounter[j]];
						this.EffectActParticle_three[col][row] = this.EffectActParticlePools_three[j][this.ActpoolCounter[j]];
						this.EffectActGameObjectPools[j][this.ActpoolCounter[j]] = null;
						this.EffectActTransformPools[j][this.ActpoolCounter[j]] = null;
						this.EffectActParticlePools[j][this.ActpoolCounter[j]] = null;
						this.EffectActParticlePools_one[j][this.ActpoolCounter[j]] = null;
						this.EffectActParticlePools_two[j][this.ActpoolCounter[j]] = null;
						this.EffectActParticlePools_three[j][this.ActpoolCounter[j]] = null;
						this.setEffect(row, col, DataManager.MapDataController.zoomSize);
						break;
					}
				}
				if (j == this.ActpoolsCounter)
				{
					this.EffectActGameObjectPools[j] = new GameObject[this.EffectActGameObjectPools[0].Length];
					this.EffectActTransformPools[j] = new Transform[this.EffectActTransformPools[0].Length];
					this.EffectActParticlePools[j] = new ParticleSystem[this.EffectActParticlePools[0].Length];
					this.EffectActParticlePools_one[j] = new ParticleSystem[this.EffectActParticlePools_one[0].Length];
					this.EffectActParticlePools_two[j] = new ParticleSystem[this.EffectActParticlePools_two[0].Length];
					this.EffectActParticlePools_three[j] = new ParticleSystem[this.EffectActParticlePools_three[0].Length];
					for (int k = 0; k < this.EffectActGameObjectPools[j].Length; k++)
					{
						this.EffectActGameObjectPools[j][k] = ParticleManager.Instance.Spawn(60201, null, Vector3.zero, 1f, false, false, true);
						this.EffectActTransformPools[j][k] = this.EffectActGameObjectPools[j][k].transform;
						this.EffectActTransformPools[j][k].SetParent(this.ActLayoutTransform, false);
						this.EffectActTransformPools[j][k].localPosition = this.inipos;
						this.EffectActParticlePools[j][k] = this.EffectActTransformPools[j][k].GetChild(0).GetComponent<ParticleSystem>();
						this.EffectActParticlePools_one[j][k] = this.EffectActTransformPools[j][k].GetChild(1).GetComponent<ParticleSystem>();
						this.EffectActParticlePools_two[j][k] = this.EffectActTransformPools[j][k].GetChild(2).GetComponent<ParticleSystem>();
						this.EffectActParticlePools_three[j][k] = this.EffectActTransformPools[j][k].GetChild(3).GetComponent<ParticleSystem>();
					}
					this.ActpoolsCounter++;
					this.ActpoolCounter[j] = this.EffectActGameObjectPools[j].Length;
					this.ActpoolCounter[j]--;
					this.EffectActGameObject[col][row] = this.EffectActGameObjectPools[j][this.ActpoolCounter[j]];
					this.EffectActTransform[col][row] = this.EffectActTransformPools[j][this.ActpoolCounter[j]];
					this.EffectActParticle[col][row] = this.EffectActParticlePools[j][this.ActpoolCounter[j]];
					this.EffectActParticle_one[col][row] = this.EffectActParticlePools_one[j][this.ActpoolCounter[j]];
					this.EffectActParticle_two[col][row] = this.EffectActParticlePools_two[j][this.ActpoolCounter[j]];
					this.EffectActParticle_three[col][row] = this.EffectActParticlePools_three[j][this.ActpoolCounter[j]];
					this.EffectActParticle[col][row].startSize = this.ActstartSize * x;
					this.EffectActParticle[col][row].startLifetime = this.Actlifetime * x;
					this.EffectActParticle_one[col][row].startSize = this.ActstartSize_one * x;
					this.EffectActParticle_one[col][row].startLifetime = this.Actlifetime_one * x;
					this.EffectActParticle_two[col][row].startSize = this.ActstartSize_two * x;
					this.EffectActParticle_two[col][row].startLifetime = this.Actlifetime_two * x;
					this.EffectActParticle_three[col][row].startSize = this.ActstartSize_three * x;
					this.EffectActParticle_three[col][row].startLifetime = this.Actlifetime_three * x;
					this.EffectActGameObjectPools[j][this.ActpoolCounter[j]] = null;
					this.EffectActTransformPools[j][this.ActpoolCounter[j]] = null;
					this.EffectActParticlePools[j][this.ActpoolCounter[j]] = null;
					this.EffectActParticlePools_one[j][this.ActpoolCounter[j]] = null;
					this.EffectActParticlePools_two[j][this.ActpoolCounter[j]] = null;
					this.EffectActParticlePools_three[j][this.ActpoolCounter[j]] = null;
				}
				this.EffectActGameObject[col][row].SetActive(true);
			}
			this.EffectActTransform[col][row].localPosition = pos;
		}
	}

	// Token: 0x06000C6A RID: 3178 RVA: 0x0011FEDC File Offset: 0x0011E0DC
	public void setEffect(int row, int col, Vector2 pos)
	{
		Vector3 localPosition = new Vector3(pos.x, pos.y, 0f);
		if (this.EffectActGameObject[col][row] != null)
		{
			this.EffectActTransform[col][row].localPosition = localPosition;
		}
	}

	// Token: 0x06000C6B RID: 3179 RVA: 0x0011FF28 File Offset: 0x0011E128
	public void setEffect(int row, int col, float scale)
	{
		if (this.EffectActGameObject[col][row] != null)
		{
			float num = this.EffectActParticle[col][row].startSize;
			float num2 = this.EffectActParticle[col][row].startLifetime;
			this.EffectActParticle[col][row].startSize = this.ActstartSize * scale;
			this.EffectActParticle[col][row].startLifetime = this.Actlifetime * scale;
			num = this.EffectActParticle[col][row].startSize / num;
			num2 = this.EffectActParticle[col][row].startLifetime / num2;
			int num3 = this.EffectActParticle[col][row].GetParticles(this.particles);
			for (int i = 0; i < num3; i++)
			{
				ParticleSystem.Particle[] array = this.particles;
				int num4 = i;
				array[num4].size = array[num4].size * num;
				ParticleSystem.Particle[] array2 = this.particles;
				int num5 = i;
				array2[num5].lifetime = array2[num5].lifetime * num2;
			}
			this.EffectActParticle[col][row].SetParticles(this.particles, num3);
			num = this.EffectActParticle_one[col][row].startSize;
			num2 = this.EffectActParticle_one[col][row].startLifetime;
			this.EffectActParticle_one[col][row].startSize = this.ActstartSize_one * scale;
			this.EffectActParticle_one[col][row].startLifetime = this.Actlifetime_one * scale;
			num = this.EffectActParticle_one[col][row].startSize / num;
			num2 = this.EffectActParticle_one[col][row].startLifetime / num2;
			num3 = this.EffectActParticle_one[col][row].GetParticles(this.particles);
			for (int j = 0; j < num3; j++)
			{
				ParticleSystem.Particle[] array3 = this.particles;
				int num6 = j;
				array3[num6].size = array3[num6].size * num;
				ParticleSystem.Particle[] array4 = this.particles;
				int num7 = j;
				array4[num7].lifetime = array4[num7].lifetime * num2;
			}
			this.EffectActParticle_one[col][row].SetParticles(this.particles, num3);
			num = this.EffectActParticle_two[col][row].startSize;
			num2 = this.EffectActParticle_two[col][row].startLifetime;
			this.EffectActParticle_two[col][row].startSize = this.ActstartSize_two * scale;
			this.EffectActParticle_two[col][row].startLifetime = this.Actlifetime_two * scale;
			num = this.EffectActParticle_two[col][row].startSize / num;
			num2 = this.EffectActParticle_two[col][row].startLifetime / num2;
			num3 = this.EffectActParticle_two[col][row].GetParticles(this.particles);
			for (int k = 0; k < num3; k++)
			{
				ParticleSystem.Particle[] array5 = this.particles;
				int num8 = k;
				array5[num8].size = array5[num8].size * num;
				ParticleSystem.Particle[] array6 = this.particles;
				int num9 = k;
				array6[num9].lifetime = array6[num9].lifetime * num2;
			}
			this.EffectActParticle_two[col][row].SetParticles(this.particles, num3);
			num = this.EffectActParticle_three[col][row].startSize;
			num2 = this.EffectActParticle_three[col][row].startLifetime;
			this.EffectActParticle_three[col][row].startSize = this.ActstartSize_three * scale;
			this.EffectActParticle_three[col][row].startLifetime = this.Actlifetime_three * scale;
			num = this.EffectActParticle_three[col][row].startSize / num;
			num2 = this.EffectActParticle_three[col][row].startLifetime / num2;
			num3 = this.EffectActParticle_three[col][row].GetParticles(this.particles);
			for (int l = 0; l < num3; l++)
			{
				ParticleSystem.Particle[] array7 = this.particles;
				int num10 = l;
				array7[num10].size = array7[num10].size * num;
				ParticleSystem.Particle[] array8 = this.particles;
				int num11 = l;
				array8[num11].lifetime = array8[num11].lifetime * num2;
			}
			this.EffectActParticle_three[col][row].SetParticles(this.particles, num3);
		}
	}

	// Token: 0x04002872 RID: 10354
	private const ushort EffectActID = 60201;

	// Token: 0x04002873 RID: 10355
	private Transform TotalityGroup;

	// Token: 0x04002874 RID: 10356
	private Transform EffectLayoutTransform;

	// Token: 0x04002875 RID: 10357
	private Transform ActLayoutTransform;

	// Token: 0x04002876 RID: 10358
	private GameObject[][] EffectActGameObject;

	// Token: 0x04002877 RID: 10359
	private Transform[][] EffectActTransform;

	// Token: 0x04002878 RID: 10360
	private ParticleSystem[][] EffectActParticle;

	// Token: 0x04002879 RID: 10361
	private ParticleSystem[][] EffectActParticle_one;

	// Token: 0x0400287A RID: 10362
	private ParticleSystem[][] EffectActParticle_two;

	// Token: 0x0400287B RID: 10363
	private ParticleSystem[][] EffectActParticle_three;

	// Token: 0x0400287C RID: 10364
	private GameObject[][] EffectActGameObjectPools;

	// Token: 0x0400287D RID: 10365
	private Transform[][] EffectActTransformPools;

	// Token: 0x0400287E RID: 10366
	private ParticleSystem[][] EffectActParticlePools;

	// Token: 0x0400287F RID: 10367
	private ParticleSystem[][] EffectActParticlePools_one;

	// Token: 0x04002880 RID: 10368
	private ParticleSystem[][] EffectActParticlePools_two;

	// Token: 0x04002881 RID: 10369
	private ParticleSystem[][] EffectActParticlePools_three;

	// Token: 0x04002882 RID: 10370
	private int[] ActpoolCounter;

	// Token: 0x04002883 RID: 10371
	private int ActpoolsCounter;

	// Token: 0x04002884 RID: 10372
	private Vector3 inipos = new Vector3(0f, 1024f, 0f);

	// Token: 0x04002885 RID: 10373
	private float ActstartSize;

	// Token: 0x04002886 RID: 10374
	private float Actlifetime;

	// Token: 0x04002887 RID: 10375
	private float ActstartSize_one;

	// Token: 0x04002888 RID: 10376
	private float Actlifetime_one;

	// Token: 0x04002889 RID: 10377
	private float ActstartSize_two;

	// Token: 0x0400288A RID: 10378
	private float Actlifetime_two;

	// Token: 0x0400288B RID: 10379
	private float ActstartSize_three;

	// Token: 0x0400288C RID: 10380
	private float Actlifetime_three;

	// Token: 0x0400288D RID: 10381
	private ParticleSystem.Particle[] particles = new ParticleSystem.Particle[64];
}
