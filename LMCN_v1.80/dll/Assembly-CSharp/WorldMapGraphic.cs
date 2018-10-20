using System;
using UnityEngine;

// Token: 0x02000284 RID: 644
public class WorldMapGraphic
{
	// Token: 0x06000C6D RID: 3181 RVA: 0x001202FC File Offset: 0x0011E4FC
	public WorldMapGraphic(Transform totalityGroup, UISpritesArray tileSprites)
	{
		this.WorldMapSprites[0] = tileSprites.GetSprite(1);
		this.WorldMapSprites[1] = tileSprites.GetSprite(9);
		this.WorldMapSprites[3] = tileSprites.GetSprite(101);
		int num = 60;
		for (int i = 4; i < this.WorldMapSprites.Length - 2; i++)
		{
			this.WorldMapSprites[i] = tileSprites.GetSprite(num);
			num++;
		}
		this.WorldMapSprites[44] = tileSprites.GetSprite(102);
		this.WorldMapSprites[45] = tileSprites.GetSprite(103);
		this.GraphicSpriteMaterial = new Material(tileSprites.m_Image.material);
		this.GraphicSpriteMaterial.renderQueue = 2750;
		GameObject gameObject = new GameObject("WorldMapGraphic");
		this.GraphicLayout = gameObject.transform;
		this.GraphicLayout.position = Vector3.forward * 1536f;
		this.GraphicLayout.SetParent(totalityGroup, false);
		gameObject = new GameObject("G1");
		this.G1 = gameObject.transform;
		this.G1.SetParent(this.GraphicLayout, false);
		gameObject = new GameObject("G2");
		this.G2 = gameObject.transform;
		this.G2.SetParent(this.GraphicLayout, false);
		gameObject = new GameObject("G3");
		this.G3 = gameObject.transform;
		this.G3.SetParent(this.GraphicLayout, false);
		this.kindomYolkHeight = new float[tileSprites.m_Sprites.Length - 10];
		for (int j = 0; j < this.kindomYolkHeight.Length; j++)
		{
			this.kindomYolkHeight[j] = tileSprites.GetSprite(j + 10).rect.size.y;
		}
	}

	// Token: 0x06000C6E RID: 3182 RVA: 0x0012051C File Offset: 0x0011E71C
	public void OnDestroy()
	{
		if (this.HeightOffset != null)
		{
			for (int i = 0; i < this.HeightOffset.Length; i++)
			{
				Array.Clear(this.HeightOffset[i], 0, this.HeightOffset[i].Length);
				this.HeightOffset[i] = null;
			}
			this.HeightOffset = null;
		}
		if (this.HeightExOffset != null)
		{
			for (int j = 0; j < this.HeightExOffset.Length; j++)
			{
				Array.Clear(this.HeightExOffset[j], 0, this.HeightExOffset[j].Length);
				this.HeightExOffset[j] = null;
			}
			this.HeightExOffset = null;
		}
		if (this.HeightTrdOffset != null)
		{
			for (int k = 0; k < this.HeightTrdOffset.Length; k++)
			{
				Array.Clear(this.HeightTrdOffset[k], 0, this.HeightTrdOffset[k].Length);
				this.HeightTrdOffset[k] = null;
			}
			this.HeightTrdOffset = null;
		}
		if (this.GraphicGameObject != null)
		{
			for (int l = 0; l < this.GraphicGameObject.Length; l++)
			{
				Array.Clear(this.GraphicGameObject[l], 0, this.GraphicGameObject[l].Length);
				this.GraphicGameObject[l] = null;
			}
		}
		if (this.GraphicExGameObject != null)
		{
			for (int m = 0; m < this.GraphicExGameObject.Length; m++)
			{
				Array.Clear(this.GraphicExGameObject[m], 0, this.GraphicExGameObject[m].Length);
				this.GraphicExGameObject[m] = null;
			}
		}
		if (this.GraphicTrdGameObject != null)
		{
			for (int n = 0; n < this.GraphicTrdGameObject.Length; n++)
			{
				Array.Clear(this.GraphicTrdGameObject[n], 0, this.GraphicTrdGameObject[n].Length);
				this.GraphicTrdGameObject[n] = null;
			}
		}
		if (this.GraphicRectTransform != null)
		{
			for (int num = 0; num < this.GraphicRectTransform.Length; num++)
			{
				Array.Clear(this.GraphicRectTransform[num], 0, this.GraphicRectTransform[num].Length);
				this.GraphicRectTransform[num] = null;
			}
			this.GraphicRectTransform = null;
		}
		if (this.GraphicExRectTransform != null)
		{
			for (int num2 = 0; num2 < this.GraphicExRectTransform.Length; num2++)
			{
				Array.Clear(this.GraphicExRectTransform[num2], 0, this.GraphicExRectTransform[num2].Length);
				this.GraphicExRectTransform[num2] = null;
			}
			this.GraphicExRectTransform = null;
		}
		if (this.GraphicTrdRectTransform != null)
		{
			for (int num3 = 0; num3 < this.GraphicTrdRectTransform.Length; num3++)
			{
				Array.Clear(this.GraphicTrdRectTransform[num3], 0, this.GraphicTrdRectTransform[num3].Length);
				this.GraphicTrdRectTransform[num3] = null;
			}
			this.GraphicTrdRectTransform = null;
		}
		if (this.GraphicImage != null)
		{
			for (int num4 = 0; num4 < this.GraphicImage.Length; num4++)
			{
				Array.Clear(this.GraphicImage[num4], 0, this.GraphicImage[num4].Length);
				this.GraphicImage[num4] = null;
			}
			this.GraphicImage = null;
		}
		if (this.GraphicExImage != null)
		{
			for (int num5 = 0; num5 < this.GraphicExImage.Length; num5++)
			{
				Array.Clear(this.GraphicExImage[num5], 0, this.GraphicExImage[num5].Length);
				this.GraphicExImage[num5] = null;
			}
			this.GraphicExImage = null;
		}
		if (this.GraphicTrdImage != null)
		{
			for (int num6 = 0; num6 < this.GraphicTrdImage.Length; num6++)
			{
				Array.Clear(this.GraphicTrdImage[num6], 0, this.GraphicTrdImage[num6].Length);
				this.GraphicTrdImage[num6] = null;
			}
			this.GraphicTrdImage = null;
		}
		if (this.GraphicGameObjectPools != null)
		{
			for (int num7 = 0; num7 < this.GraphicGameObjectPools.Length; num7++)
			{
				if (this.GraphicGameObjectPools[num7] != null)
				{
					Array.Clear(this.GraphicGameObjectPools[num7], 0, this.GraphicGameObjectPools[num7].Length);
					this.GraphicGameObjectPools[num7] = null;
				}
			}
		}
		if (this.GraphicExGameObjectPools != null)
		{
			for (int num8 = 0; num8 < this.GraphicExGameObjectPools.Length; num8++)
			{
				if (this.GraphicExGameObjectPools[num8] != null)
				{
					Array.Clear(this.GraphicExGameObjectPools[num8], 0, this.GraphicExGameObjectPools[num8].Length);
					this.GraphicExGameObjectPools[num8] = null;
				}
			}
		}
		if (this.GraphicTrdGameObjectPools != null)
		{
			for (int num9 = 0; num9 < this.GraphicTrdGameObjectPools.Length; num9++)
			{
				if (this.GraphicTrdGameObjectPools[num9] != null)
				{
					Array.Clear(this.GraphicTrdGameObjectPools[num9], 0, this.GraphicTrdGameObjectPools[num9].Length);
					this.GraphicTrdGameObjectPools[num9] = null;
				}
			}
		}
		if (this.GraphicRectTransformPools != null)
		{
			for (int num10 = 0; num10 < this.GraphicRectTransformPools.Length; num10++)
			{
				if (this.GraphicRectTransformPools[num10] != null)
				{
					Array.Clear(this.GraphicRectTransformPools[num10], 0, this.GraphicRectTransformPools[num10].Length);
					this.GraphicRectTransformPools[num10] = null;
				}
			}
		}
		if (this.GraphicExRectTransformPools != null)
		{
			for (int num11 = 0; num11 < this.GraphicExRectTransformPools.Length; num11++)
			{
				if (this.GraphicExRectTransformPools[num11] != null)
				{
					Array.Clear(this.GraphicExRectTransformPools[num11], 0, this.GraphicExRectTransformPools[num11].Length);
					this.GraphicExRectTransformPools[num11] = null;
				}
			}
		}
		if (this.GraphicTrdRectTransformPools != null)
		{
			for (int num12 = 0; num12 < this.GraphicTrdRectTransformPools.Length; num12++)
			{
				if (this.GraphicTrdRectTransformPools[num12] != null)
				{
					Array.Clear(this.GraphicTrdRectTransformPools[num12], 0, this.GraphicTrdRectTransformPools[num12].Length);
					this.GraphicTrdRectTransformPools[num12] = null;
				}
			}
		}
		if (this.GraphicImagePools != null)
		{
			for (int num13 = 0; num13 < this.GraphicImagePools.Length; num13++)
			{
				if (this.GraphicImagePools[num13] != null)
				{
					Array.Clear(this.GraphicImagePools[num13], 0, this.GraphicImagePools[num13].Length);
					this.GraphicImagePools[num13] = null;
				}
			}
		}
		if (this.GraphicExImagePools != null)
		{
			for (int num14 = 0; num14 < this.GraphicExImagePools.Length; num14++)
			{
				if (this.GraphicExImagePools[num14] != null)
				{
					Array.Clear(this.GraphicExImagePools[num14], 0, this.GraphicExImagePools[num14].Length);
					this.GraphicExImagePools[num14] = null;
				}
			}
		}
		if (this.GraphicTrdGameObjectPools != null)
		{
			for (int num15 = 0; num15 < this.GraphicTrdImagePools.Length; num15++)
			{
				if (this.GraphicTrdImagePools[num15] != null)
				{
					Array.Clear(this.GraphicTrdImagePools[num15], 0, this.GraphicTrdImagePools[num15].Length);
					this.GraphicTrdImagePools[num15] = null;
				}
			}
		}
		if (this.poolCounter != null)
		{
			Array.Clear(this.poolCounter, 0, this.poolCounter.Length);
			this.poolCounter = null;
		}
		if (this.poolExCounter != null)
		{
			Array.Clear(this.poolExCounter, 0, this.poolExCounter.Length);
			this.poolExCounter = null;
		}
		if (this.poolTrdCounter != null)
		{
			Array.Clear(this.poolTrdCounter, 0, this.poolTrdCounter.Length);
			this.poolTrdCounter = null;
		}
		if (this.WorldMapSprites != null)
		{
			Array.Clear(this.WorldMapSprites, 0, this.WorldMapSprites.Length);
			this.WorldMapSprites = null;
		}
		if (this.kindomYolkHeight != null)
		{
			Array.Clear(this.kindomYolkHeight, 0, this.kindomYolkHeight.Length);
			this.kindomYolkHeight = null;
		}
		if (this.GraphicLayout != null)
		{
			UnityEngine.Object.Destroy(this.GraphicLayout);
		}
		this.GraphicLayout = null;
	}

	// Token: 0x06000C6F RID: 3183 RVA: 0x00120CE8 File Offset: 0x0011EEE8
	public void IniGraphicImag(int rowNum, int colNum, float tileBaseScale)
	{
		this.HeightOffset = new Vector2[colNum][];
		this.HeightExOffset = new Vector2[colNum][];
		this.HeightTrdOffset = new Vector2[colNum][];
		this.GraphicGameObject = new GameObject[colNum][];
		this.GraphicExGameObject = new GameObject[colNum][];
		this.GraphicTrdGameObject = new GameObject[colNum][];
		this.GraphicRectTransform = new RectTransform[colNum][];
		this.GraphicExRectTransform = new RectTransform[colNum][];
		this.GraphicTrdRectTransform = new RectTransform[colNum][];
		this.GraphicImage = new WorldMapGraphicImage[colNum][];
		this.GraphicExImage = new WorldMapGraphicImage[colNum][];
		this.GraphicTrdImage = new WorldMapGraphicImage[colNum][];
		for (int i = 0; i < colNum; i++)
		{
			this.GraphicGameObject[i] = new GameObject[rowNum];
			this.GraphicExGameObject[i] = new GameObject[rowNum];
			this.GraphicTrdGameObject[i] = new GameObject[rowNum];
			this.GraphicRectTransform[i] = new RectTransform[rowNum];
			this.GraphicExRectTransform[i] = new RectTransform[rowNum];
			this.GraphicTrdRectTransform[i] = new RectTransform[rowNum];
			this.GraphicImage[i] = new WorldMapGraphicImage[rowNum];
			this.GraphicExImage[i] = new WorldMapGraphicImage[rowNum];
			this.GraphicTrdImage[i] = new WorldMapGraphicImage[rowNum];
			Array.Clear(this.GraphicGameObject[i], 0, this.GraphicGameObject[i].Length);
			Array.Clear(this.GraphicExGameObject[i], 0, this.GraphicExGameObject[i].Length);
			Array.Clear(this.GraphicTrdGameObject[i], 0, this.GraphicTrdGameObject[i].Length);
			Array.Clear(this.GraphicRectTransform[i], 0, this.GraphicRectTransform[i].Length);
			Array.Clear(this.GraphicExRectTransform[i], 0, this.GraphicExRectTransform[i].Length);
			Array.Clear(this.GraphicTrdRectTransform[i], 0, this.GraphicTrdRectTransform[i].Length);
			Array.Clear(this.GraphicImage[i], 0, this.GraphicImage[i].Length);
			Array.Clear(this.GraphicExImage[i], 0, this.GraphicImage[i].Length);
			Array.Clear(this.GraphicTrdImage[i], 0, this.GraphicImage[i].Length);
			this.HeightOffset[i] = new Vector2[rowNum];
			this.HeightExOffset[i] = new Vector2[rowNum];
			this.HeightTrdOffset[i] = new Vector2[rowNum];
			for (int j = 0; j < rowNum; j++)
			{
				this.HeightOffset[i][j] = (this.HeightExOffset[i][j] = (this.HeightTrdOffset[i][j] = Vector2.zero));
			}
		}
		this.BaseScale = tileBaseScale;
		this.GraphicGameObjectPools = new GameObject[rowNum][];
		this.GraphicExGameObjectPools = new GameObject[rowNum][];
		this.GraphicTrdGameObjectPools = new GameObject[rowNum][];
		this.GraphicRectTransformPools = new RectTransform[rowNum][];
		this.GraphicExRectTransformPools = new RectTransform[rowNum][];
		this.GraphicTrdRectTransformPools = new RectTransform[rowNum][];
		this.GraphicImagePools = new WorldMapGraphicImage[rowNum][];
		this.GraphicExImagePools = new WorldMapGraphicImage[rowNum][];
		this.GraphicTrdImagePools = new WorldMapGraphicImage[rowNum][];
		this.poolCounter = new int[rowNum];
		this.poolExCounter = new int[rowNum];
		this.poolTrdCounter = new int[rowNum];
		Array.Clear(this.GraphicGameObjectPools, 0, this.GraphicGameObjectPools.Length);
		Array.Clear(this.GraphicExGameObjectPools, 0, this.GraphicGameObjectPools.Length);
		Array.Clear(this.GraphicTrdGameObjectPools, 0, this.GraphicGameObjectPools.Length);
		Array.Clear(this.GraphicRectTransformPools, 0, this.GraphicRectTransformPools.Length);
		Array.Clear(this.GraphicExRectTransformPools, 0, this.GraphicRectTransformPools.Length);
		Array.Clear(this.GraphicTrdRectTransformPools, 0, this.GraphicRectTransformPools.Length);
		Array.Clear(this.GraphicImagePools, 0, this.GraphicImagePools.Length);
		Array.Clear(this.GraphicExImagePools, 0, this.GraphicImagePools.Length);
		Array.Clear(this.GraphicTrdImagePools, 0, this.GraphicImagePools.Length);
		for (int k = 0; k < this.poolCounter.Length; k++)
		{
			this.poolCounter[k] = (this.poolExCounter[k] = (this.poolTrdCounter[k] = -1));
		}
		this.GraphicGameObjectPools[0] = new GameObject[colNum];
		this.GraphicExGameObjectPools[0] = new GameObject[colNum];
		this.GraphicTrdGameObjectPools[0] = new GameObject[colNum];
		this.GraphicImagePools[0] = new WorldMapGraphicImage[colNum];
		this.GraphicExImagePools[0] = new WorldMapGraphicImage[colNum];
		this.GraphicTrdImagePools[0] = new WorldMapGraphicImage[colNum];
		this.GraphicRectTransformPools[0] = new RectTransform[colNum];
		this.GraphicExRectTransformPools[0] = new RectTransform[colNum];
		this.GraphicTrdRectTransformPools[0] = new RectTransform[colNum];
		for (int l = 0; l < this.GraphicGameObjectPools[0].Length; l++)
		{
			GameObject gameObject = new GameObject("graphic");
			gameObject.SetActive(false);
			this.GraphicImagePools[0][l] = gameObject.AddComponent<WorldMapGraphicImage>();
			this.GraphicImagePools[0][l].material = this.GraphicSpriteMaterial;
			this.GraphicRectTransformPools[0][l] = (gameObject.transform as RectTransform);
			this.GraphicRectTransformPools[0][l].sizeDelta = this.inisize;
			this.GraphicRectTransformPools[0][l].localPosition = this.inipos;
			this.GraphicRectTransformPools[0][l].localScale = Vector3.one * tileBaseScale * 1f;
			this.GraphicRectTransformPools[0][l].SetParent(this.G1, false);
			this.GraphicGameObjectPools[0][l] = gameObject;
		}
		this.poolCounter[0] = colNum;
		this.poolsCounter = 1;
		for (int m = 0; m < this.GraphicExGameObjectPools[0].Length; m++)
		{
			GameObject gameObject = new GameObject("graphicEx");
			gameObject.SetActive(false);
			this.GraphicExImagePools[0][m] = gameObject.AddComponent<WorldMapGraphicImage>();
			this.GraphicExImagePools[0][m].material = this.GraphicSpriteMaterial;
			this.GraphicExRectTransformPools[0][m] = (gameObject.transform as RectTransform);
			this.GraphicExRectTransformPools[0][m].sizeDelta = this.inisize;
			this.GraphicExRectTransformPools[0][m].localPosition = this.inipos;
			this.GraphicExRectTransformPools[0][m].localScale = Vector3.one * tileBaseScale * 1f;
			this.GraphicExRectTransformPools[0][m].SetParent(this.G2, false);
			this.GraphicExGameObjectPools[0][m] = gameObject;
		}
		this.poolExCounter[0] = colNum;
		this.poolsExCounter = 1;
		for (int n = 0; n < this.GraphicTrdGameObjectPools[0].Length; n++)
		{
			GameObject gameObject = new GameObject("graphicTrd");
			gameObject.SetActive(false);
			this.GraphicTrdImagePools[0][n] = gameObject.AddComponent<WorldMapGraphicImage>();
			this.GraphicTrdImagePools[0][n].material = this.GraphicSpriteMaterial;
			this.GraphicTrdRectTransformPools[0][n] = (gameObject.transform as RectTransform);
			this.GraphicTrdRectTransformPools[0][n].sizeDelta = this.inisize;
			this.GraphicTrdRectTransformPools[0][n].localPosition = this.inipos;
			this.GraphicTrdRectTransformPools[0][n].localScale = Vector3.one * tileBaseScale * 1f;
			this.GraphicTrdRectTransformPools[0][n].SetParent(this.G2, false);
			this.GraphicTrdGameObjectPools[0][n] = gameObject;
		}
		this.poolTrdCounter[0] = colNum;
		this.poolsTrdCounter = 1;
	}

	// Token: 0x06000C70 RID: 3184 RVA: 0x00121450 File Offset: 0x0011F650
	public void setGraphicImage(int graphic, int row, int col, Vector2 pos, int yolkid = 0, ushort kingdomID = 0, byte title = 0)
	{
		if (graphic < 1 || graphic > 42)
		{
			if (this.GraphicGameObject[col][row] != null)
			{
				this.GraphicGameObject[col][row].SetActive(false);
				for (int i = 0; i < this.poolsCounter; i++)
				{
					if (this.poolCounter[i] < this.GraphicGameObjectPools[i].Length)
					{
						this.GraphicGameObjectPools[i][this.poolCounter[i]] = this.GraphicGameObject[col][row];
						this.GraphicImagePools[i][this.poolCounter[i]] = this.GraphicImage[col][row];
						this.GraphicRectTransformPools[i][this.poolCounter[i]] = this.GraphicRectTransform[col][row];
						this.GraphicGameObject[col][row] = null;
						this.GraphicImage[col][row] = null;
						this.GraphicRectTransform[col][row] = null;
						this.poolCounter[i]++;
						break;
					}
				}
				this.HeightOffset[col][row].y = 0f;
			}
			if (this.GraphicExGameObject[col][row] != null)
			{
				this.GraphicExGameObject[col][row].SetActive(false);
				for (int j = 0; j < this.poolsExCounter; j++)
				{
					if (this.poolExCounter[j] < this.GraphicExGameObjectPools[j].Length)
					{
						this.GraphicExGameObjectPools[j][this.poolExCounter[j]] = this.GraphicExGameObject[col][row];
						this.GraphicExImagePools[j][this.poolExCounter[j]] = this.GraphicExImage[col][row];
						this.GraphicExRectTransformPools[j][this.poolExCounter[j]] = this.GraphicExRectTransform[col][row];
						this.GraphicExGameObject[col][row] = null;
						this.GraphicExImage[col][row] = null;
						this.GraphicExRectTransform[col][row] = null;
						this.poolExCounter[j]++;
						break;
					}
				}
				this.HeightExOffset[col][row] = Vector2.zero;
			}
			if (this.GraphicTrdGameObject[col][row] != null)
			{
				this.GraphicTrdGameObject[col][row].SetActive(false);
				for (int k = 0; k < this.poolsTrdCounter; k++)
				{
					if (this.poolTrdCounter[k] < this.GraphicTrdGameObjectPools[k].Length)
					{
						this.GraphicTrdGameObjectPools[k][this.poolTrdCounter[k]] = this.GraphicTrdGameObject[col][row];
						this.GraphicTrdImagePools[k][this.poolTrdCounter[k]] = this.GraphicTrdImage[col][row];
						this.GraphicTrdRectTransformPools[k][this.poolTrdCounter[k]] = this.GraphicTrdRectTransform[col][row];
						this.GraphicTrdGameObject[col][row] = null;
						this.GraphicTrdImage[col][row] = null;
						this.GraphicTrdRectTransform[col][row] = null;
						this.poolTrdCounter[k]++;
						break;
					}
				}
				this.HeightTrdOffset[col][row] = Vector2.zero;
			}
		}
		else
		{
			int num = graphic & 3;
			int num2 = graphic & 12;
			int num3 = graphic & 48;
			if (num > 0)
			{
				if (this.GraphicGameObject[col][row] == null)
				{
					int l;
					for (l = 0; l < this.poolsCounter; l++)
					{
						if (this.poolCounter[l] > 0)
						{
							this.poolCounter[l]--;
							this.GraphicGameObject[col][row] = this.GraphicGameObjectPools[l][this.poolCounter[l]];
							this.GraphicImage[col][row] = this.GraphicImagePools[l][this.poolCounter[l]];
							this.GraphicRectTransform[col][row] = this.GraphicRectTransformPools[l][this.poolCounter[l]];
							this.GraphicGameObjectPools[l][this.poolCounter[l]] = null;
							this.GraphicImagePools[l][this.poolCounter[l]] = null;
							this.GraphicRectTransformPools[l][this.poolCounter[l]] = null;
							break;
						}
					}
					if (l == this.poolsCounter)
					{
						this.GraphicGameObjectPools[l] = new GameObject[this.GraphicGameObjectPools[0].Length];
						this.GraphicImagePools[l] = new WorldMapGraphicImage[this.GraphicImagePools[0].Length];
						this.GraphicRectTransformPools[l] = new RectTransform[this.GraphicRectTransformPools[0].Length];
						for (int m = 0; m < this.GraphicGameObjectPools[l].Length; m++)
						{
							GameObject gameObject = new GameObject("graphic");
							gameObject.SetActive(false);
							this.GraphicImagePools[l][m] = gameObject.AddComponent<WorldMapGraphicImage>();
							this.GraphicImagePools[l][m].material = this.GraphicSpriteMaterial;
							this.GraphicRectTransformPools[l][m] = (gameObject.transform as RectTransform);
							this.GraphicRectTransformPools[l][m].sizeDelta = this.inisize;
							this.GraphicRectTransformPools[l][m].localPosition = this.inipos;
							this.GraphicRectTransformPools[l][m].localScale = Vector3.one * this.BaseScale * 1f;
							this.GraphicRectTransformPools[l][m].SetParent(this.G1, false);
							this.GraphicGameObjectPools[l][m] = gameObject;
						}
						this.poolsCounter++;
						this.poolCounter[l] = this.GraphicGameObjectPools[l].Length;
						this.poolCounter[l]--;
						this.GraphicGameObject[col][row] = this.GraphicGameObjectPools[l][this.poolCounter[l]];
						this.GraphicImage[col][row] = this.GraphicImagePools[l][this.poolCounter[l]];
						this.GraphicRectTransform[col][row] = this.GraphicRectTransformPools[l][this.poolCounter[l]];
						this.GraphicGameObjectPools[l][this.poolCounter[l]] = null;
						this.GraphicImagePools[l][this.poolCounter[l]] = null;
						this.GraphicRectTransformPools[l][this.poolCounter[l]] = null;
					}
					this.GraphicGameObject[col][row].SetActive(true);
				}
				if (this.GraphicImage[col][row].sprite != this.WorldMapSprites[num - 1])
				{
					this.GraphicImage[col][row].sprite = this.WorldMapSprites[num - 1];
				}
				this.GraphicImage[col][row].SetNativeSize();
				if (num == 2)
				{
					this.HeightOffset[col][row].y = -50f;
				}
				else
				{
					this.HeightOffset[col][row].y = this.kindomYolkHeight[yolkid] + this.GraphicImage[col][row].rectTransform.sizeDelta.y * 0.5f;
				}
				this.GraphicImage[col][row].kingdomID = kingdomID;
				if (this.GraphicGameObject[col][row] != null)
				{
					this.GraphicRectTransform[col][row].anchoredPosition = pos + this.HeightOffset[col][row];
				}
			}
			else if (this.GraphicGameObject[col][row] != null)
			{
				this.GraphicGameObject[col][row].SetActive(false);
				for (int n = 0; n < this.poolsCounter; n++)
				{
					if (this.poolCounter[n] < this.GraphicGameObjectPools[n].Length)
					{
						this.GraphicGameObjectPools[n][this.poolCounter[n]] = this.GraphicGameObject[col][row];
						this.GraphicImagePools[n][this.poolCounter[n]] = this.GraphicImage[col][row];
						this.GraphicRectTransformPools[n][this.poolCounter[n]] = this.GraphicRectTransform[col][row];
						this.GraphicGameObject[col][row] = null;
						this.GraphicImage[col][row] = null;
						this.GraphicRectTransform[col][row] = null;
						this.poolCounter[n]++;
						break;
					}
				}
				this.HeightOffset[col][row].y = 0f;
			}
			if (num2 > 0)
			{
				if (this.GraphicExGameObject[col][row] == null)
				{
					int num4;
					for (num4 = 0; num4 < this.poolsExCounter; num4++)
					{
						if (this.poolExCounter[num4] > 0)
						{
							this.poolExCounter[num4]--;
							this.GraphicExGameObject[col][row] = this.GraphicExGameObjectPools[num4][this.poolExCounter[num4]];
							this.GraphicExImage[col][row] = this.GraphicExImagePools[num4][this.poolExCounter[num4]];
							this.GraphicExRectTransform[col][row] = this.GraphicExRectTransformPools[num4][this.poolExCounter[num4]];
							this.GraphicExGameObjectPools[num4][this.poolExCounter[num4]] = null;
							this.GraphicExImagePools[num4][this.poolExCounter[num4]] = null;
							this.GraphicExRectTransformPools[num4][this.poolExCounter[num4]] = null;
							break;
						}
					}
					if (num4 == this.poolsExCounter)
					{
						this.GraphicExGameObjectPools[num4] = new GameObject[this.GraphicExGameObjectPools[0].Length];
						this.GraphicExImagePools[num4] = new WorldMapGraphicImage[this.GraphicExImagePools[0].Length];
						this.GraphicExRectTransformPools[num4] = new RectTransform[this.GraphicExRectTransformPools[0].Length];
						for (int num5 = 0; num5 < this.GraphicExGameObjectPools[num4].Length; num5++)
						{
							GameObject gameObject2 = new GameObject("graphicEx");
							gameObject2.SetActive(false);
							this.GraphicExImagePools[num4][num5] = gameObject2.AddComponent<WorldMapGraphicImage>();
							this.GraphicExImagePools[num4][num5].material = this.GraphicSpriteMaterial;
							this.GraphicExRectTransformPools[num4][num5] = (gameObject2.transform as RectTransform);
							this.GraphicExRectTransformPools[num4][num5].sizeDelta = this.inisize;
							this.GraphicExRectTransformPools[num4][num5].localPosition = this.inipos;
							this.GraphicExRectTransformPools[num4][num5].localScale = Vector3.one * this.BaseScale * 1f;
							this.GraphicExRectTransformPools[num4][num5].SetParent(this.G2, false);
							this.GraphicExGameObjectPools[num4][num5] = gameObject2;
						}
						this.poolsExCounter++;
						this.poolExCounter[num4] = this.GraphicExGameObjectPools[num4].Length;
						this.poolExCounter[num4]--;
						this.GraphicExGameObject[col][row] = this.GraphicExGameObjectPools[num4][this.poolExCounter[num4]];
						this.GraphicExImage[col][row] = this.GraphicExImagePools[num4][this.poolExCounter[num4]];
						this.GraphicExRectTransform[col][row] = this.GraphicExRectTransformPools[num4][this.poolExCounter[num4]];
						this.GraphicExGameObjectPools[num4][this.poolExCounter[num4]] = null;
						this.GraphicExImagePools[num4][this.poolExCounter[num4]] = null;
						this.GraphicExRectTransformPools[num4][this.poolExCounter[num4]] = null;
					}
					this.GraphicExGameObject[col][row].SetActive(true);
				}
				if (num2 == 4)
				{
					if (this.GraphicExImage[col][row].sprite != this.WorldMapSprites[num2 - 1])
					{
						this.GraphicExImage[col][row].sprite = this.WorldMapSprites[num2 - 1];
					}
					this.GraphicExImage[col][row].SetNativeSize();
					this.HeightExOffset[col][row].y = this.kindomYolkHeight[yolkid] - this.GraphicExImage[col][row].rectTransform.sizeDelta.y;
					this.HeightExOffset[col][row].x = 202f;
					if (GUIManager.Instance.IsArabic)
					{
						Vector2[] array = this.HeightExOffset[col];
						array[row].x = array[row].x * -1f;
					}
					this.GraphicExImage[col][row].kingdomID = kingdomID;
				}
				else
				{
					TitleData recordByKey = DataManager.Instance.TitleDataN.GetRecordByKey((ushort)title);
					if (this.GraphicExImage[col][row].sprite != this.WorldMapSprites[(int)(4 + recordByKey.IconID)])
					{
						this.GraphicExImage[col][row].sprite = this.WorldMapSprites[(int)(4 + recordByKey.IconID)];
					}
					this.GraphicExImage[col][row].SetNativeSize();
					this.HeightExOffset[col][row].y = -145f;
					this.HeightExOffset[col][row].x = -180f;
					if (GUIManager.Instance.IsArabic)
					{
						Vector2[] array2 = this.HeightExOffset[col];
						array2[row].x = array2[row].x * -1f;
					}
					this.GraphicExImage[col][row].kingdomID = (ushort)title;
				}
				if (this.GraphicExGameObject[col][row] != null)
				{
					this.GraphicExRectTransform[col][row].anchoredPosition = pos + this.HeightExOffset[col][row];
				}
			}
			else if (this.GraphicExGameObject[col][row] != null)
			{
				this.GraphicExGameObject[col][row].SetActive(false);
				for (int num6 = 0; num6 < this.poolsExCounter; num6++)
				{
					if (this.poolExCounter[num6] < this.GraphicExGameObjectPools[num6].Length)
					{
						this.GraphicExGameObjectPools[num6][this.poolExCounter[num6]] = this.GraphicExGameObject[col][row];
						this.GraphicExImagePools[num6][this.poolExCounter[num6]] = this.GraphicExImage[col][row];
						this.GraphicExRectTransformPools[num6][this.poolExCounter[num6]] = this.GraphicExRectTransform[col][row];
						this.GraphicExGameObject[col][row] = null;
						this.GraphicExImage[col][row] = null;
						this.GraphicExRectTransform[col][row] = null;
						this.poolExCounter[num6]++;
						break;
					}
				}
				this.HeightExOffset[col][row] = Vector2.zero;
			}
			if (num3 > 0)
			{
				if (this.GraphicTrdGameObject[col][row] == null)
				{
					int num7;
					for (num7 = 0; num7 < this.poolsTrdCounter; num7++)
					{
						if (this.poolTrdCounter[num7] > 0)
						{
							this.poolTrdCounter[num7]--;
							this.GraphicTrdGameObject[col][row] = this.GraphicTrdGameObjectPools[num7][this.poolTrdCounter[num7]];
							this.GraphicTrdImage[col][row] = this.GraphicTrdImagePools[num7][this.poolTrdCounter[num7]];
							this.GraphicTrdRectTransform[col][row] = this.GraphicTrdRectTransformPools[num7][this.poolTrdCounter[num7]];
							this.GraphicTrdGameObjectPools[num7][this.poolTrdCounter[num7]] = null;
							this.GraphicTrdImagePools[num7][this.poolTrdCounter[num7]] = null;
							this.GraphicTrdRectTransformPools[num7][this.poolTrdCounter[num7]] = null;
							break;
						}
					}
					if (num7 == this.poolsTrdCounter)
					{
						this.GraphicTrdGameObjectPools[num7] = new GameObject[this.GraphicTrdGameObjectPools[0].Length];
						this.GraphicTrdImagePools[num7] = new WorldMapGraphicImage[this.GraphicTrdImagePools[0].Length];
						this.GraphicTrdRectTransformPools[num7] = new RectTransform[this.GraphicTrdRectTransformPools[0].Length];
						for (int num8 = 0; num8 < this.GraphicTrdGameObjectPools[num7].Length; num8++)
						{
							GameObject gameObject3 = new GameObject("graphicTrd");
							gameObject3.SetActive(false);
							this.GraphicTrdImagePools[num7][num8] = gameObject3.AddComponent<WorldMapGraphicImage>();
							this.GraphicTrdImagePools[num7][num8].material = this.GraphicSpriteMaterial;
							this.GraphicTrdRectTransformPools[num7][num8] = (gameObject3.transform as RectTransform);
							this.GraphicTrdRectTransformPools[num7][num8].sizeDelta = this.inisize;
							this.GraphicTrdRectTransformPools[num7][num8].localPosition = this.inipos;
							this.GraphicTrdRectTransformPools[num7][num8].localScale = Vector3.one * this.BaseScale * 1f;
							this.GraphicTrdRectTransformPools[num7][num8].SetParent(this.G3, false);
							this.GraphicTrdGameObjectPools[num7][num8] = gameObject3;
						}
						this.poolsTrdCounter++;
						this.poolTrdCounter[num7] = this.GraphicTrdGameObjectPools[num7].Length;
						this.poolTrdCounter[num7]--;
						this.GraphicTrdGameObject[col][row] = this.GraphicTrdGameObjectPools[num7][this.poolTrdCounter[num7]];
						this.GraphicTrdImage[col][row] = this.GraphicTrdImagePools[num7][this.poolTrdCounter[num7]];
						this.GraphicTrdRectTransform[col][row] = this.GraphicTrdRectTransformPools[num7][this.poolTrdCounter[num7]];
						this.GraphicTrdGameObjectPools[num7][this.poolTrdCounter[num7]] = null;
						this.GraphicTrdImagePools[num7][this.poolTrdCounter[num7]] = null;
						this.GraphicTrdRectTransformPools[num7][this.poolTrdCounter[num7]] = null;
					}
					this.GraphicTrdGameObject[col][row].SetActive(true);
				}
				if (num3 == 16)
				{
					if (this.GraphicTrdImage[col][row].sprite != this.WorldMapSprites[44])
					{
						this.GraphicTrdImage[col][row].sprite = this.WorldMapSprites[44];
					}
					this.GraphicTrdImage[col][row].SetNativeSize();
					this.HeightTrdOffset[col][row].y = this.kindomYolkHeight[yolkid] - this.GraphicTrdImage[col][row].rectTransform.sizeDelta.y + 10f;
					this.GraphicTrdImage[col][row].kingdomID = kingdomID;
				}
				else
				{
					TitleData recordByKey2 = DataManager.Instance.TitleDataN.GetRecordByKey((ushort)title);
					if (this.GraphicTrdImage[col][row].sprite != this.WorldMapSprites[45])
					{
						this.GraphicTrdImage[col][row].sprite = this.WorldMapSprites[45];
					}
					this.GraphicTrdImage[col][row].SetNativeSize();
					this.HeightTrdOffset[col][row].y = this.kindomYolkHeight[yolkid] - this.GraphicTrdImage[col][row].rectTransform.sizeDelta.y + 10f;
					this.GraphicTrdImage[col][row].kingdomID = (ushort)title;
				}
				if (this.GraphicTrdGameObject[col][row] != null)
				{
					this.GraphicTrdRectTransform[col][row].anchoredPosition = pos + this.HeightTrdOffset[col][row];
				}
			}
			else if (this.GraphicTrdGameObject[col][row] != null)
			{
				this.GraphicTrdGameObject[col][row].SetActive(false);
				for (int num9 = 0; num9 < this.poolsTrdCounter; num9++)
				{
					if (this.poolTrdCounter[num9] < this.GraphicTrdGameObjectPools[num9].Length)
					{
						this.GraphicTrdGameObjectPools[num9][this.poolTrdCounter[num9]] = this.GraphicTrdGameObject[col][row];
						this.GraphicTrdImagePools[num9][this.poolTrdCounter[num9]] = this.GraphicTrdImage[col][row];
						this.GraphicTrdRectTransformPools[num9][this.poolTrdCounter[num9]] = this.GraphicTrdRectTransform[col][row];
						this.GraphicTrdGameObject[col][row] = null;
						this.GraphicTrdImage[col][row] = null;
						this.GraphicTrdRectTransform[col][row] = null;
						this.poolTrdCounter[num9]++;
						break;
					}
				}
				this.HeightTrdOffset[col][row] = Vector2.zero;
			}
		}
	}

	// Token: 0x06000C71 RID: 3185 RVA: 0x0012283C File Offset: 0x00120A3C
	public void setGraphicImage(int row, int col, Vector2 pos)
	{
		if (this.GraphicGameObject[col][row] != null)
		{
			this.GraphicRectTransform[col][row].anchoredPosition = pos + this.HeightOffset[col][row];
		}
		if (this.GraphicExGameObject[col][row] != null)
		{
			this.GraphicExRectTransform[col][row].anchoredPosition = pos + this.HeightExOffset[col][row];
		}
		if (this.GraphicTrdGameObject[col][row] != null)
		{
			this.GraphicTrdRectTransform[col][row].anchoredPosition = pos + this.HeightTrdOffset[col][row];
		}
	}

	// Token: 0x06000C72 RID: 3186 RVA: 0x00122900 File Offset: 0x00120B00
	public void reflashGraphicImage()
	{
		for (int i = 0; i < this.GraphicExGameObject.Length; i++)
		{
			for (int j = 0; j < this.GraphicExGameObject[i].Length; j++)
			{
				if (this.GraphicExGameObject[i][j] != null && this.GraphicExImage[i][j].sprite == this.WorldMapSprites[3])
				{
					this.GraphicExGameObject[i][j].SetActive(false);
					for (int k = 0; k < this.poolsExCounter; k++)
					{
						if (this.poolExCounter[k] < this.GraphicExGameObjectPools[k].Length)
						{
							this.GraphicExGameObjectPools[k][this.poolExCounter[k]] = this.GraphicExGameObject[i][j];
							this.GraphicExImagePools[k][this.poolExCounter[k]] = this.GraphicExImage[i][j];
							this.GraphicExRectTransformPools[k][this.poolExCounter[k]] = this.GraphicExRectTransform[i][j];
							this.GraphicExGameObject[i][j] = null;
							this.GraphicExImage[i][j] = null;
							this.GraphicExRectTransform[i][j] = null;
							this.poolExCounter[k]++;
							break;
						}
					}
					this.HeightExOffset[i][j] = Vector2.zero;
				}
			}
		}
	}

	// Token: 0x0400288F RID: 10383
	private const int kingdom = 10;

	// Token: 0x04002890 RID: 10384
	private const float GraphicScale = 1f;

	// Token: 0x04002891 RID: 10385
	private Transform GraphicLayout;

	// Token: 0x04002892 RID: 10386
	private Material GraphicSpriteMaterial;

	// Token: 0x04002893 RID: 10387
	private Vector2 GraphicImageOffSet = new Vector2(0f, 42f);

	// Token: 0x04002894 RID: 10388
	private Vector2 inisize = new Vector2(44f, 62f);

	// Token: 0x04002895 RID: 10389
	private Vector3 inipos = new Vector3(0f, 1024f, 0f);

	// Token: 0x04002896 RID: 10390
	private float BaseScale;

	// Token: 0x04002897 RID: 10391
	private Sprite[] WorldMapSprites = new Sprite[46];

	// Token: 0x04002898 RID: 10392
	private float[] kindomYolkHeight;

	// Token: 0x04002899 RID: 10393
	private Transform G1;

	// Token: 0x0400289A RID: 10394
	private GameObject[][] GraphicGameObject;

	// Token: 0x0400289B RID: 10395
	private RectTransform[][] GraphicRectTransform;

	// Token: 0x0400289C RID: 10396
	private WorldMapGraphicImage[][] GraphicImage;

	// Token: 0x0400289D RID: 10397
	private GameObject[][] GraphicGameObjectPools;

	// Token: 0x0400289E RID: 10398
	private RectTransform[][] GraphicRectTransformPools;

	// Token: 0x0400289F RID: 10399
	private WorldMapGraphicImage[][] GraphicImagePools;

	// Token: 0x040028A0 RID: 10400
	private int[] poolCounter;

	// Token: 0x040028A1 RID: 10401
	private int poolsCounter;

	// Token: 0x040028A2 RID: 10402
	private Vector2[][] HeightOffset;

	// Token: 0x040028A3 RID: 10403
	private Transform G2;

	// Token: 0x040028A4 RID: 10404
	private GameObject[][] GraphicExGameObject;

	// Token: 0x040028A5 RID: 10405
	private RectTransform[][] GraphicExRectTransform;

	// Token: 0x040028A6 RID: 10406
	private WorldMapGraphicImage[][] GraphicExImage;

	// Token: 0x040028A7 RID: 10407
	private GameObject[][] GraphicExGameObjectPools;

	// Token: 0x040028A8 RID: 10408
	private RectTransform[][] GraphicExRectTransformPools;

	// Token: 0x040028A9 RID: 10409
	private WorldMapGraphicImage[][] GraphicExImagePools;

	// Token: 0x040028AA RID: 10410
	private int[] poolExCounter;

	// Token: 0x040028AB RID: 10411
	private int poolsExCounter;

	// Token: 0x040028AC RID: 10412
	private Vector2[][] HeightExOffset;

	// Token: 0x040028AD RID: 10413
	private Transform G3;

	// Token: 0x040028AE RID: 10414
	private GameObject[][] GraphicTrdGameObject;

	// Token: 0x040028AF RID: 10415
	private RectTransform[][] GraphicTrdRectTransform;

	// Token: 0x040028B0 RID: 10416
	private WorldMapGraphicImage[][] GraphicTrdImage;

	// Token: 0x040028B1 RID: 10417
	private GameObject[][] GraphicTrdGameObjectPools;

	// Token: 0x040028B2 RID: 10418
	private RectTransform[][] GraphicTrdRectTransformPools;

	// Token: 0x040028B3 RID: 10419
	private WorldMapGraphicImage[][] GraphicTrdImagePools;

	// Token: 0x040028B4 RID: 10420
	private int[] poolTrdCounter;

	// Token: 0x040028B5 RID: 10421
	private int poolsTrdCounter;

	// Token: 0x040028B6 RID: 10422
	private Vector2[][] HeightTrdOffset;
}
