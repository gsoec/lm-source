using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000262 RID: 610
public class MapTileLevel
{
	// Token: 0x06000B49 RID: 2889 RVA: 0x00105728 File Offset: 0x00103928
	public MapTileLevel(Transform realmGroup, UISpritesArray tileSprites)
	{
		this.LevelSprite = new Sprite[25];
		for (int i = 0; i < this.LevelSprite.Length; i++)
		{
			this.LevelSprite[i] = tileSprites.GetSprite(i + 113);
		}
		this.DarkLevelSprite = new Sprite[5];
		for (int j = 0; j < this.DarkLevelSprite.Length; j++)
		{
			this.DarkLevelSprite[j] = tileSprites.GetSprite(j + 256);
		}
		GameObject gameObject = new GameObject("MapTileLevel");
		this.LevelLayout = gameObject.transform;
		this.LevelLayout.position = Vector3.forward * 3968f;
		this.LevelLayout.SetParent(realmGroup, false);
		this.poolsCounter = 0;
	}

	// Token: 0x06000B4A RID: 2890 RVA: 0x00105838 File Offset: 0x00103A38
	public void OnDestroy()
	{
		if (this.LevelGameObject != null)
		{
			for (int i = 0; i < this.LevelGameObject.Length; i++)
			{
				Array.Clear(this.LevelGameObject[i], 0, this.LevelGameObject[i].Length);
				this.LevelGameObject[i] = null;
			}
		}
		if (this.LevelRectTransform != null)
		{
			for (int j = 0; j < this.LevelRectTransform.Length; j++)
			{
				Array.Clear(this.LevelRectTransform[j], 0, this.LevelRectTransform[j].Length);
				this.LevelRectTransform[j] = null;
			}
		}
		if (this.LevelImage != null)
		{
			for (int k = 0; k < this.LevelImage.Length; k++)
			{
				Array.Clear(this.LevelImage[k], 0, this.LevelImage[k].Length);
				this.LevelImage[k] = null;
			}
		}
		if (this.LevelGameObjectPools != null)
		{
			for (int l = 0; l < this.LevelGameObjectPools.Length; l++)
			{
				if (this.LevelGameObjectPools[l] != null)
				{
					Array.Clear(this.LevelGameObjectPools[l], 0, this.LevelGameObjectPools[l].Length);
					this.LevelGameObjectPools[l] = null;
				}
			}
		}
		if (this.LevelRectTransformPools != null)
		{
			for (int m = 0; m < this.LevelRectTransformPools.Length; m++)
			{
				if (this.LevelRectTransformPools[m] != null)
				{
					Array.Clear(this.LevelRectTransformPools[m], 0, this.LevelRectTransformPools[m].Length);
					this.LevelRectTransformPools[m] = null;
				}
			}
		}
		if (this.LevelImagePools != null)
		{
			for (int n = 0; n < this.LevelImagePools.Length; n++)
			{
				if (this.LevelImagePools[n] != null)
				{
					Array.Clear(this.LevelImagePools[n], 0, this.LevelImagePools[n].Length);
					this.LevelImagePools[n] = null;
				}
			}
		}
		if (this.poolCounter != null)
		{
			Array.Clear(this.poolCounter, 0, this.poolCounter.Length);
			this.poolCounter = null;
		}
		Array.Clear(this.LevelSprite, 0, this.LevelSprite.Length);
		Array.Clear(this.DarkLevelSprite, 0, this.DarkLevelSprite.Length);
		if (this.LevelLayout != null)
		{
			UnityEngine.Object.Destroy(this.LevelLayout);
		}
		this.LevelLayout = null;
	}

	// Token: 0x06000B4B RID: 2891 RVA: 0x00105A8C File Offset: 0x00103C8C
	public void IniLevelImag(int rowNum, int colNum, float tileBaseScale, Material imageMaterial)
	{
		this.LevelGameObject = new GameObject[colNum][];
		this.LevelRectTransform = new RectTransform[colNum][];
		this.LevelImage = new Image[colNum][];
		for (int i = 0; i < colNum; i++)
		{
			this.LevelGameObject[i] = new GameObject[rowNum];
			this.LevelRectTransform[i] = new RectTransform[rowNum];
			this.LevelImage[i] = new Image[rowNum];
			Array.Clear(this.LevelGameObject[i], 0, this.LevelGameObject[i].Length);
			Array.Clear(this.LevelRectTransform[i], 0, this.LevelRectTransform[i].Length);
			Array.Clear(this.LevelImage[i], 0, this.LevelImage[i].Length);
		}
		this.LevelImageMaterial = imageMaterial;
		this.BaseScale = tileBaseScale;
		this.LevelGameObjectPools = new GameObject[rowNum][];
		this.LevelRectTransformPools = new RectTransform[rowNum][];
		this.LevelImagePools = new Image[rowNum][];
		this.poolCounter = new int[rowNum];
		Array.Clear(this.LevelGameObjectPools, 0, this.LevelGameObjectPools.Length);
		Array.Clear(this.LevelRectTransformPools, 0, this.LevelRectTransformPools.Length);
		Array.Clear(this.LevelImagePools, 0, this.LevelImagePools.Length);
		for (int j = 0; j < this.poolCounter.Length; j++)
		{
			this.poolCounter[j] = -1;
		}
		this.LevelGameObjectPools[0] = new GameObject[colNum];
		this.LevelImagePools[0] = new Image[colNum];
		this.LevelRectTransformPools[0] = new RectTransform[colNum];
		for (int k = 0; k < this.LevelGameObjectPools[0].Length; k++)
		{
			GameObject gameObject = new GameObject("level");
			gameObject.SetActive(false);
			this.LevelImagePools[0][k] = gameObject.AddComponent<Image>();
			this.LevelImagePools[0][k].material = imageMaterial;
			this.LevelRectTransformPools[0][k] = (gameObject.transform as RectTransform);
			this.LevelRectTransformPools[0][k].sizeDelta = this.inisize;
			this.LevelRectTransformPools[0][k].localPosition = this.inipos;
			this.LevelRectTransformPools[0][k].localScale = Vector3.one * tileBaseScale;
			this.LevelRectTransformPools[0][k].SetParent(this.LevelLayout, false);
			this.LevelGameObjectPools[0][k] = gameObject;
		}
		this.poolCounter[0] = colNum;
		this.poolsCounter = 1;
	}

	// Token: 0x06000B4C RID: 2892 RVA: 0x00105CE4 File Offset: 0x00103EE4
	public void setLevelImage(int level, int row, int col, Vector2 pos, bool dark = false)
	{
		if (level < 1 || level > 25 || (dark && level > 5))
		{
			if (this.LevelGameObject[col][row] != null)
			{
				this.LevelGameObject[col][row].SetActive(false);
				for (int i = 0; i < this.poolsCounter; i++)
				{
					if (this.poolCounter[i] < this.LevelGameObjectPools[i].Length)
					{
						this.LevelGameObjectPools[i][this.poolCounter[i]] = this.LevelGameObject[col][row];
						this.LevelImagePools[i][this.poolCounter[i]] = this.LevelImage[col][row];
						this.LevelRectTransformPools[i][this.poolCounter[i]] = this.LevelRectTransform[col][row];
						this.LevelGameObject[col][row] = null;
						this.LevelImage[col][row] = null;
						this.LevelRectTransform[col][row] = null;
						this.poolCounter[i]++;
						break;
					}
				}
			}
		}
		else
		{
			if (this.LevelGameObject[col][row] == null)
			{
				int j;
				for (j = 0; j < this.poolsCounter; j++)
				{
					if (this.poolCounter[j] > 0)
					{
						this.poolCounter[j]--;
						this.LevelGameObject[col][row] = this.LevelGameObjectPools[j][this.poolCounter[j]];
						this.LevelImage[col][row] = this.LevelImagePools[j][this.poolCounter[j]];
						this.LevelRectTransform[col][row] = this.LevelRectTransformPools[j][this.poolCounter[j]];
						this.LevelGameObjectPools[j][this.poolCounter[j]] = null;
						this.LevelImagePools[j][this.poolCounter[j]] = null;
						this.LevelRectTransformPools[j][this.poolCounter[j]] = null;
						break;
					}
				}
				if (j == this.poolsCounter)
				{
					this.LevelGameObjectPools[j] = new GameObject[this.LevelGameObjectPools[0].Length];
					this.LevelImagePools[j] = new Image[this.LevelGameObjectPools[0].Length];
					this.LevelRectTransformPools[j] = new RectTransform[this.LevelGameObjectPools[0].Length];
					for (int k = 0; k < this.LevelGameObjectPools[j].Length; k++)
					{
						GameObject gameObject = new GameObject("level");
						gameObject.SetActive(false);
						this.LevelImagePools[j][k] = gameObject.AddComponent<Image>();
						this.LevelImagePools[j][k].material = this.LevelImageMaterial;
						this.LevelRectTransformPools[j][k] = (gameObject.transform as RectTransform);
						this.LevelRectTransformPools[j][k].sizeDelta = this.inisize;
						this.LevelRectTransformPools[j][k].localPosition = this.inipos;
						this.LevelRectTransformPools[j][k].localScale = Vector3.one * this.BaseScale;
						this.LevelRectTransformPools[j][k].SetParent(this.LevelLayout, false);
						this.LevelGameObjectPools[j][k] = gameObject;
					}
					this.poolsCounter++;
					this.poolCounter[j] = this.LevelGameObjectPools[j].Length;
					this.poolCounter[j]--;
					this.LevelGameObject[col][row] = this.LevelGameObjectPools[j][this.poolCounter[j]];
					this.LevelImage[col][row] = this.LevelImagePools[j][this.poolCounter[j]];
					this.LevelRectTransform[col][row] = this.LevelRectTransformPools[j][this.poolCounter[j]];
					this.LevelGameObjectPools[j][this.poolCounter[j]] = null;
					this.LevelImagePools[j][this.poolCounter[j]] = null;
					this.LevelRectTransformPools[j][this.poolCounter[j]] = null;
				}
				this.LevelGameObject[col][row].SetActive(true);
			}
			if (dark)
			{
				if (this.LevelImage[col][row].sprite != this.DarkLevelSprite[level - 1])
				{
					this.LevelImage[col][row].sprite = this.DarkLevelSprite[level - 1];
					this.LevelImage[col][row].SetNativeSize();
				}
			}
			else if (this.LevelImage[col][row].sprite != this.LevelSprite[level - 1])
			{
				this.LevelImage[col][row].sprite = this.LevelSprite[level - 1];
				this.LevelImage[col][row].SetNativeSize();
			}
			this.setLevelImage(row, col, pos);
		}
	}

	// Token: 0x06000B4D RID: 2893 RVA: 0x00106160 File Offset: 0x00104360
	public void setLevelImage(int row, int col, Vector2 pos)
	{
		if (this.LevelRectTransform[col][row] != null)
		{
			this.LevelRectTransform[col][row].anchoredPosition = pos + this.LevelImageOffset;
		}
	}

	// Token: 0x0400263A RID: 9786
	private const int rankone = 113;

	// Token: 0x0400263B RID: 9787
	private const int darkrankone = 256;

	// Token: 0x0400263C RID: 9788
	public Transform LevelLayout;

	// Token: 0x0400263D RID: 9789
	private Sprite[] LevelSprite;

	// Token: 0x0400263E RID: 9790
	private Sprite[] DarkLevelSprite;

	// Token: 0x0400263F RID: 9791
	private GameObject[][] LevelGameObject;

	// Token: 0x04002640 RID: 9792
	private RectTransform[][] LevelRectTransform;

	// Token: 0x04002641 RID: 9793
	private Image[][] LevelImage;

	// Token: 0x04002642 RID: 9794
	private GameObject[][] LevelGameObjectPools;

	// Token: 0x04002643 RID: 9795
	private RectTransform[][] LevelRectTransformPools;

	// Token: 0x04002644 RID: 9796
	private Image[][] LevelImagePools;

	// Token: 0x04002645 RID: 9797
	private int[] poolCounter;

	// Token: 0x04002646 RID: 9798
	private int poolsCounter;

	// Token: 0x04002647 RID: 9799
	private Material LevelImageMaterial;

	// Token: 0x04002648 RID: 9800
	private float BaseScale;

	// Token: 0x04002649 RID: 9801
	private Vector2 LevelImageOffset = new Vector2(70.7f, -5.4f);

	// Token: 0x0400264A RID: 9802
	private Vector2 inisize = new Vector2(52f, 29f);

	// Token: 0x0400264B RID: 9803
	private Vector3 inipos = new Vector3(0f, 1024f, 0f);
}
