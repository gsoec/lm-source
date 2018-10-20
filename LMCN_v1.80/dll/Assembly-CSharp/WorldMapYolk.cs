using System;
using UnityEngine;

// Token: 0x02000289 RID: 649
public class WorldMapYolk
{
	// Token: 0x06000C89 RID: 3209 RVA: 0x00125B90 File Offset: 0x00123D90
	public WorldMapYolk(Transform totalityGroup, UISpritesArray tileSprites)
	{
		this.YolkSprite = new Sprite[50];
		for (int i = 0; i < this.YolkSprite.Length; i++)
		{
			this.YolkSprite[i] = tileSprites.GetSprite(10 + i);
		}
		GameObject gameObject = new GameObject("MapTileYolk");
		this.YolkLayout = gameObject.transform;
		this.YolkLayout.position = Vector3.forward * 1920f;
		this.YolkLayout.SetParent(totalityGroup, false);
		this.poolsCounter = 0;
		this.sheepTickImage = new WorldMapImage[16];
		this.wolfTickImage = new WorldMapImage[16];
	}

	// Token: 0x06000C8A RID: 3210 RVA: 0x00125CAC File Offset: 0x00123EAC
	public void OnDestroy()
	{
		if (this.wolfTickImage != null)
		{
			for (int i = 0; i < this.wolfTickImage.Length; i++)
			{
				this.wolfTickImage[i] = null;
			}
			this.wolfTickImage = null;
		}
		if (this.sheepTickImage != null)
		{
			for (int j = 0; j < this.sheepTickImage.Length; j++)
			{
				this.sheepTickImage[j] = null;
			}
			this.sheepTickImage = null;
		}
		if (this.YolkGameObject != null)
		{
			for (int k = 0; k < this.YolkGameObject.Length; k++)
			{
				Array.Clear(this.YolkGameObject[k], 0, this.YolkGameObject[k].Length);
				this.YolkGameObject[k] = null;
			}
		}
		if (this.YolkRectTransform != null)
		{
			for (int l = 0; l < this.YolkRectTransform.Length; l++)
			{
				Array.Clear(this.YolkRectTransform[l], 0, this.YolkRectTransform[l].Length);
				this.YolkRectTransform[l] = null;
			}
		}
		if (this.YolkImage != null)
		{
			for (int m = 0; m < this.YolkImage.Length; m++)
			{
				Array.Clear(this.YolkImage[m], 0, this.YolkImage[m].Length);
				this.YolkImage[m] = null;
			}
		}
		if (this.YolkGameObjectPools != null)
		{
			for (int n = 0; n < this.YolkGameObjectPools.Length; n++)
			{
				if (this.YolkGameObjectPools[n] != null)
				{
					Array.Clear(this.YolkGameObjectPools[n], 0, this.YolkGameObjectPools[n].Length);
					this.YolkGameObjectPools[n] = null;
				}
			}
		}
		if (this.YolkRectTransformPools != null)
		{
			for (int num = 0; num < this.YolkRectTransformPools.Length; num++)
			{
				if (this.YolkRectTransformPools[num] != null)
				{
					Array.Clear(this.YolkRectTransformPools[num], 0, this.YolkRectTransformPools[num].Length);
					this.YolkRectTransformPools[num] = null;
				}
			}
		}
		if (this.YolkImagePools != null)
		{
			for (int num2 = 0; num2 < this.YolkImagePools.Length; num2++)
			{
				if (this.YolkImagePools[num2] != null)
				{
					Array.Clear(this.YolkImagePools[num2], 0, this.YolkImagePools[num2].Length);
					this.YolkImagePools[num2] = null;
				}
			}
		}
		if (this.poolCounter != null)
		{
			Array.Clear(this.poolCounter, 0, this.poolCounter.Length);
			this.poolCounter = null;
		}
		Array.Clear(this.YolkSprite, 0, this.YolkSprite.Length);
		if (this.YolkLayout != null)
		{
			UnityEngine.Object.Destroy(this.YolkLayout);
		}
		this.YolkLayout = null;
	}

	// Token: 0x06000C8B RID: 3211 RVA: 0x00125F64 File Offset: 0x00124164
	public void IniYolkImag(int rowNum, int colNum, float tileBaseScale, Material imageMaterial)
	{
		this.YolkGameObject = new GameObject[colNum][];
		this.YolkRectTransform = new RectTransform[colNum][];
		this.YolkImage = new WorldMapImage[colNum][];
		for (int i = 0; i < colNum; i++)
		{
			this.YolkGameObject[i] = new GameObject[rowNum];
			this.YolkRectTransform[i] = new RectTransform[rowNum];
			this.YolkImage[i] = new WorldMapImage[rowNum];
			Array.Clear(this.YolkGameObject[i], 0, this.YolkGameObject[i].Length);
			Array.Clear(this.YolkRectTransform[i], 0, this.YolkRectTransform[i].Length);
			Array.Clear(this.YolkImage[i], 0, this.YolkImage[i].Length);
		}
		Shader shader = null;
		for (int j = 0; j < AssetManager.Instance.Shaders.Length; j++)
		{
			if (AssetManager.Instance.Shaders[j].name == "zTWRD2 Shaders/UI/Sprites Alpha R High Light")
			{
				shader = (Shader)AssetManager.Instance.Shaders[j];
				break;
			}
		}
		this.YolkImageMaterial = new Material(imageMaterial);
		this.YolkImageMaterial.shader = shader;
		this.BaseScale = tileBaseScale;
		this.YolkGameObjectPools = new GameObject[rowNum][];
		this.YolkRectTransformPools = new RectTransform[rowNum][];
		this.YolkImagePools = new WorldMapImage[rowNum][];
		this.poolCounter = new int[rowNum];
		Array.Clear(this.YolkGameObjectPools, 0, this.YolkGameObjectPools.Length);
		Array.Clear(this.YolkRectTransformPools, 0, this.YolkRectTransformPools.Length);
		Array.Clear(this.YolkImagePools, 0, this.YolkImagePools.Length);
		for (int k = 0; k < this.poolCounter.Length; k++)
		{
			this.poolCounter[k] = -1;
		}
		this.YolkGameObjectPools[0] = new GameObject[colNum];
		this.YolkImagePools[0] = new WorldMapImage[colNum];
		this.YolkRectTransformPools[0] = new RectTransform[colNum];
		for (int l = 0; l < this.YolkGameObjectPools[0].Length; l++)
		{
			GameObject gameObject = new GameObject("yolk");
			gameObject.SetActive(false);
			this.YolkImagePools[0][l] = gameObject.AddComponent<WorldMapImage>();
			this.YolkImagePools[0][l].material = this.YolkImageMaterial;
			this.YolkImagePools[0][l].color = Color.black;
			this.YolkRectTransformPools[0][l] = (gameObject.transform as RectTransform);
			this.YolkRectTransformPools[0][l].sizeDelta = this.inisize;
			this.YolkRectTransformPools[0][l].localPosition = this.inipos;
			this.YolkRectTransformPools[0][l].localScale = Vector3.one * tileBaseScale;
			this.YolkRectTransformPools[0][l].SetParent(this.YolkLayout, false);
			this.YolkGameObjectPools[0][l] = gameObject;
		}
		this.poolCounter[0] = colNum;
		this.poolsCounter = 1;
	}

	// Token: 0x06000C8C RID: 3212 RVA: 0x0012624C File Offset: 0x0012444C
	public void setYolkImage(int kingdomid, int row, int col, Vector2 pos)
	{
		if (kingdomid < 0)
		{
			if (this.YolkGameObject[col][row] != null)
			{
				if (this.tickYolkImage != null && this.tickYolkImage.col == col && this.tickYolkImage.row == row)
				{
					this.tickYolkImage = null;
				}
				if (this.sheepTickImageNum > 0 && this.sheepTickImage != null)
				{
					for (int i = 0; i < this.sheepTickImageNum; i++)
					{
						if (this.sheepTickImage[i] != null && this.sheepTickImage[i].col == col && this.sheepTickImage[i].row == row)
						{
							this.sheepTickImageNum--;
							this.sheepTickImage[i].color = Color.black;
							this.sheepTickImage[i] = this.sheepTickImage[this.sheepTickImageNum];
							this.sheepTickImage[this.sheepTickImageNum] = null;
							break;
						}
					}
				}
				if (this.wolfTickImageNum > 0 && this.wolfTickImage != null)
				{
					for (int j = 0; j < this.wolfTickImageNum; j++)
					{
						if (this.wolfTickImage[j] != null && this.wolfTickImage[j].col == col && this.wolfTickImage[j].row == row)
						{
							this.wolfTickImageNum--;
							this.wolfTickImage[j].color = Color.black;
							this.wolfTickImage[j] = this.wolfTickImage[this.wolfTickImageNum];
							this.wolfTickImage[this.wolfTickImageNum] = null;
							break;
						}
					}
				}
				this.YolkGameObject[col][row].SetActive(false);
				for (int k = 0; k < this.poolsCounter; k++)
				{
					if (this.poolCounter[k] < this.YolkGameObjectPools[k].Length)
					{
						this.YolkGameObjectPools[k][this.poolCounter[k]] = this.YolkGameObject[col][row];
						this.YolkImage[col][row].color = Color.black;
						this.YolkImagePools[k][this.poolCounter[k]] = this.YolkImage[col][row];
						this.YolkRectTransformPools[k][this.poolCounter[k]] = this.YolkRectTransform[col][row];
						this.YolkGameObject[col][row] = null;
						this.YolkImage[col][row] = null;
						this.YolkRectTransform[col][row] = null;
						this.poolCounter[k]++;
						break;
					}
				}
			}
		}
		else
		{
			if (this.YolkGameObject[col][row] == null)
			{
				int l;
				for (l = 0; l < this.poolsCounter; l++)
				{
					if (this.poolCounter[l] > 0)
					{
						this.poolCounter[l]--;
						this.YolkGameObject[col][row] = this.YolkGameObjectPools[l][this.poolCounter[l]];
						this.YolkImage[col][row] = this.YolkImagePools[l][this.poolCounter[l]];
						this.YolkRectTransform[col][row] = this.YolkRectTransformPools[l][this.poolCounter[l]];
						this.YolkGameObjectPools[l][this.poolCounter[l]] = null;
						this.YolkImagePools[l][this.poolCounter[l]] = null;
						this.YolkRectTransformPools[l][this.poolCounter[l]] = null;
						break;
					}
				}
				if (l == this.poolsCounter)
				{
					this.YolkGameObjectPools[l] = new GameObject[this.YolkGameObjectPools[0].Length];
					this.YolkImagePools[l] = new WorldMapImage[this.YolkGameObjectPools[0].Length];
					this.YolkRectTransformPools[l] = new RectTransform[this.YolkGameObjectPools[0].Length];
					for (int m = 0; m < this.YolkGameObjectPools[l].Length; m++)
					{
						GameObject gameObject = new GameObject("yolk");
						gameObject.SetActive(false);
						this.YolkImagePools[l][m] = gameObject.AddComponent<WorldMapImage>();
						this.YolkImagePools[l][m].material = this.YolkImageMaterial;
						this.YolkImagePools[l][m].color = Color.black;
						this.YolkRectTransformPools[l][m] = (gameObject.transform as RectTransform);
						this.YolkRectTransformPools[l][m].sizeDelta = this.inisize;
						this.YolkRectTransformPools[l][m].localPosition = this.inipos;
						this.YolkRectTransformPools[l][m].localScale = Vector3.one * this.BaseScale;
						this.YolkRectTransformPools[l][m].SetParent(this.YolkLayout, false);
						this.YolkGameObjectPools[l][m] = gameObject;
					}
					this.poolsCounter++;
					this.poolCounter[l] = this.YolkGameObjectPools[l].Length;
					this.poolCounter[l]--;
					this.YolkGameObject[col][row] = this.YolkGameObjectPools[l][this.poolCounter[l]];
					this.YolkImage[col][row] = this.YolkImagePools[l][this.poolCounter[l]];
					this.YolkRectTransform[col][row] = this.YolkRectTransformPools[l][this.poolCounter[l]];
					this.YolkGameObjectPools[l][this.poolCounter[l]] = null;
					this.YolkImagePools[l][this.poolCounter[l]] = null;
					this.YolkRectTransformPools[l][this.poolCounter[l]] = null;
				}
				this.YolkGameObject[col][row].SetActive(true);
			}
			byte b = 0;
			KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey((ushort)kingdomid);
			byte b2 = ((int)recordByKey.mapID < this.YolkSprite.Length) ? recordByKey.mapID : 1;
			if (DataManager.MapDataController.GetWorldKingdomTableID((ushort)kingdomid, out b))
			{
				if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK)
				{
					if (DataManager.MapDataController.WorldKingdomTable[(int)b].kingdomPeriod == KINGDOM_PERIOD.KP_KVK && kingdomid != (int)DataManager.MapDataController.kingdomData.kingdomID && (!ActivityManager.Instance.IsMatchKvk() || ActivityManager.Instance.IsMatchKvk_kingdom((ushort)kingdomid)))
					{
						if (this.YolkImage[col][row].sprite != this.YolkSprite[0])
						{
							this.YolkImage[col][row].sprite = this.YolkSprite[0];
						}
						EKvKKingdomType kvKKingdomType = ActivityManager.Instance.getKvKKingdomType((ushort)kingdomid);
						int n = 0;
						if (kvKKingdomType == EKvKKingdomType.EKKT_Hunter)
						{
							while (n < this.sheepTickImageNum)
							{
								if (this.sheepTickImage[n] == this.YolkImage[col][row])
								{
									this.sheepTickImageNum--;
									this.sheepTickImage[n].color = Color.black;
									this.sheepTickImage[n] = this.sheepTickImage[this.sheepTickImageNum];
									this.sheepTickImage[this.sheepTickImageNum] = null;
									break;
								}
								n++;
							}
							for (n = 0; n < this.wolfTickImageNum; n++)
							{
								if (this.wolfTickImage[n] == this.YolkImage[col][row])
								{
									break;
								}
							}
							if (n == this.wolfTickImageNum)
							{
								this.wolfTickImage[this.wolfTickImageNum] = this.YolkImage[col][row];
								this.wolfTickImage[this.wolfTickImageNum].color = this.wolfTickYolkImageColor;
								this.wolfTickImageNum++;
							}
						}
						else if (kvKKingdomType == EKvKKingdomType.EKKT_Target)
						{
							while (n < this.wolfTickImageNum)
							{
								if (this.wolfTickImage[n] == this.YolkImage[col][row])
								{
									this.wolfTickImageNum--;
									this.wolfTickImage[n].color = Color.black;
									this.wolfTickImage[n] = this.wolfTickImage[this.wolfTickImageNum];
									this.wolfTickImage[this.wolfTickImageNum] = null;
									break;
								}
								n++;
							}
							for (n = 0; n < this.sheepTickImageNum; n++)
							{
								if (this.sheepTickImage[n] == this.YolkImage[col][row])
								{
									break;
								}
							}
							if (n == this.sheepTickImageNum)
							{
								this.sheepTickImage[this.sheepTickImageNum] = this.YolkImage[col][row];
								this.sheepTickImage[this.sheepTickImageNum].color = this.sheepTickYolkImageColor;
								this.sheepTickImageNum++;
							}
						}
						else
						{
							while (n < this.sheepTickImageNum)
							{
								if (this.sheepTickImage[n] == this.YolkImage[col][row])
								{
									this.sheepTickImageNum--;
									this.sheepTickImage[n].color = Color.black;
									this.sheepTickImage[n] = this.sheepTickImage[this.sheepTickImageNum];
									this.sheepTickImage[this.sheepTickImageNum] = null;
									break;
								}
								n++;
							}
							if (n >= this.sheepTickImageNum)
							{
								for (n = 0; n < this.wolfTickImageNum; n++)
								{
									if (this.wolfTickImage[n] == this.YolkImage[col][row])
									{
										this.wolfTickImageNum--;
										this.wolfTickImage[n].color = Color.black;
										this.wolfTickImage[n] = this.wolfTickImage[this.wolfTickImageNum];
										this.wolfTickImage[this.wolfTickImageNum] = null;
										break;
									}
								}
							}
						}
					}
					else if (this.YolkImage[col][row].sprite != this.YolkSprite[(int)b2])
					{
						this.YolkImage[col][row].sprite = this.YolkSprite[(int)b2];
						int num;
						for (num = 0; num < this.wolfTickImageNum; num++)
						{
							if (this.wolfTickImage[num] == this.YolkImage[col][row])
							{
								this.wolfTickImageNum--;
								this.wolfTickImage[num].color = Color.black;
								this.wolfTickImage[num] = this.wolfTickImage[this.wolfTickImageNum];
								this.wolfTickImage[this.wolfTickImageNum] = null;
								break;
							}
						}
						if (num >= this.wolfTickImageNum)
						{
							for (num = 0; num < this.sheepTickImageNum; num++)
							{
								if (this.sheepTickImage[num] == this.YolkImage[col][row])
								{
									this.sheepTickImageNum--;
									this.sheepTickImage[num].color = Color.black;
									this.sheepTickImage[num] = this.sheepTickImage[this.sheepTickImageNum];
									this.sheepTickImage[this.sheepTickImageNum] = null;
									break;
								}
							}
						}
					}
				}
				else if (this.YolkImage[col][row].sprite != this.YolkSprite[(int)b2])
				{
					this.YolkImage[col][row].sprite = this.YolkSprite[(int)b2];
					int num2;
					for (num2 = 0; num2 < this.wolfTickImageNum; num2++)
					{
						if (this.wolfTickImage[num2] == this.YolkImage[col][row])
						{
							this.wolfTickImageNum--;
							this.wolfTickImage[num2].color = Color.black;
							this.wolfTickImage[num2] = this.wolfTickImage[this.wolfTickImageNum];
							this.wolfTickImage[this.wolfTickImageNum] = null;
							break;
						}
					}
					if (num2 == this.wolfTickImageNum)
					{
						for (num2 = 0; num2 < this.sheepTickImageNum; num2++)
						{
							if (this.sheepTickImage[num2] == this.YolkImage[col][row])
							{
								this.sheepTickImageNum--;
								this.sheepTickImage[num2].color = Color.black;
								this.sheepTickImage[num2] = this.sheepTickImage[this.sheepTickImageNum];
								this.sheepTickImage[this.sheepTickImageNum] = null;
								break;
							}
						}
					}
				}
				if (DataManager.MapDataController.WorldKingdomTable[(int)b].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
				{
					if (this.tickYolkImage != null)
					{
						Color black = Color.black;
						this.tickYolkImage.color = black;
						this.tickYolkImageColor = black;
					}
					this.tickYolkImage = this.YolkImage[col][row];
				}
				else
				{
					if (this.tickYolkImage == this.YolkImage[col][row])
					{
						this.tickYolkImage = null;
					}
					this.YolkImage[col][row].color = Color.black;
				}
			}
			else if (this.YolkImage[col][row].sprite != this.YolkSprite[(int)b2])
			{
				this.YolkImage[col][row].sprite = this.YolkSprite[(int)b2];
				this.YolkImage[col][row].color = Color.black;
			}
			if (this.YolkImage[col][row].sprite == null)
			{
				this.YolkImage[col][row].sprite = this.YolkSprite[1];
			}
			this.YolkImage[col][row].SetNativeSize();
			this.YolkImage[col][row].kingdomID = (ushort)kingdomid;
			this.YolkImage[col][row].col = col;
			this.YolkImage[col][row].row = row;
			this.setYolkImage(row, col, pos);
		}
	}

	// Token: 0x06000C8D RID: 3213 RVA: 0x00127008 File Offset: 0x00125208
	public void setYolkImage(int row, int col, Vector2 pos)
	{
		if (this.YolkRectTransform[col][row] != null)
		{
			this.YolkRectTransform[col][row].anchoredPosition = pos + Vector2.up * (this.YolkRectTransform[col][row].sizeDelta.y * this.BaseScale - 128f) * 0.5f;
		}
	}

	// Token: 0x06000C8E RID: 3214 RVA: 0x00127078 File Offset: 0x00125278
	public WorldMapImage getYolkImage(int row, int col)
	{
		return this.YolkImage[col][row];
	}

	// Token: 0x06000C8F RID: 3215 RVA: 0x00127084 File Offset: 0x00125284
	public void updateYolkImage()
	{
		float num = this.tickspeed * Time.deltaTime;
		num = this.tickspeed * Time.deltaTime;
		this.wolfTickYolkImageColor.r = this.wolfTickYolkImageColor.r + num * 0.239215687f;
		this.wolfTickYolkImageColor.b = this.wolfTickYolkImageColor.b + num * 0.4392157f;
		this.sheepTickYolkImageColor.r = this.sheepTickYolkImageColor.r + num * 0.466666669f;
		if (this.sheepTickYolkImageColor.r <= 0f && this.tickspeed < 0f)
		{
			this.tickspeed *= -1f;
		}
		else if (this.sheepTickYolkImageColor.r >= 0.466666669f && this.tickspeed > 0f)
		{
			this.tickspeed *= -1f;
		}
		byte b = 0;
		if (this.tickYolkImage != null && this.tickYolkImage.gameObject.activeSelf)
		{
			if (DataManager.MapDataController.GetWorldKingdomTableID(this.tickYolkImage.kingdomID, out b))
			{
				if ((DataManager.MapDataController.WorldKingdomTable[(int)b].kingdomFlag & 2) != 0)
				{
					Color color = this.tickYolkImage.color;
					this.tickYolkImageColor.b = num;
					this.tickYolkImageColor.g = (this.tickYolkImageColor.r = (this.tickYolkImageColor.a = 0f));
					this.tickYolkImage.color = color + this.tickYolkImageColor;
				}
				else if (this.tickYolkImage.color.b > 0f && this.tickYolkImage.color.g == 0f)
				{
					this.tickYolkImage.color = Color.black;
				}
			}
			else if (this.tickYolkImage.color.b > 0f && this.tickYolkImage.color.g == 0f)
			{
				this.tickYolkImage.color = Color.black;
			}
		}
		if (this.wolfTickImage != null && this.wolfTickImageNum > 0)
		{
			for (int i = 0; i < this.wolfTickImageNum; i++)
			{
				if (this.wolfTickImage[i] != null)
				{
					this.wolfTickImage[i].color = this.wolfTickYolkImageColor;
				}
			}
		}
		if (this.sheepTickImage != null && this.sheepTickImageNum > 0)
		{
			for (int j = 0; j < this.sheepTickImageNum; j++)
			{
				if (this.sheepTickImage[j] != null)
				{
					this.sheepTickImage[j].color = this.sheepTickYolkImageColor;
				}
			}
		}
	}

	// Token: 0x040028DF RID: 10463
	private const int kingdom = 10;

	// Token: 0x040028E0 RID: 10464
	private const int YolkSpriteNum = 50;

	// Token: 0x040028E1 RID: 10465
	private const int TickImageMax = 16;

	// Token: 0x040028E2 RID: 10466
	public Transform YolkLayout;

	// Token: 0x040028E3 RID: 10467
	public WorldMapImage tickYolkImage;

	// Token: 0x040028E4 RID: 10468
	public WorldMapImage[] sheepTickImage;

	// Token: 0x040028E5 RID: 10469
	public WorldMapImage[] wolfTickImage;

	// Token: 0x040028E6 RID: 10470
	public int sheepTickImageNum;

	// Token: 0x040028E7 RID: 10471
	public int wolfTickImageNum;

	// Token: 0x040028E8 RID: 10472
	private Sprite[] YolkSprite;

	// Token: 0x040028E9 RID: 10473
	private GameObject[][] YolkGameObject;

	// Token: 0x040028EA RID: 10474
	private RectTransform[][] YolkRectTransform;

	// Token: 0x040028EB RID: 10475
	private WorldMapImage[][] YolkImage;

	// Token: 0x040028EC RID: 10476
	private GameObject[][] YolkGameObjectPools;

	// Token: 0x040028ED RID: 10477
	private RectTransform[][] YolkRectTransformPools;

	// Token: 0x040028EE RID: 10478
	private WorldMapImage[][] YolkImagePools;

	// Token: 0x040028EF RID: 10479
	private int[] poolCounter;

	// Token: 0x040028F0 RID: 10480
	private int poolsCounter;

	// Token: 0x040028F1 RID: 10481
	private Material YolkImageMaterial;

	// Token: 0x040028F2 RID: 10482
	private float BaseScale;

	// Token: 0x040028F3 RID: 10483
	private Vector2 YolkImageOffset = new Vector2(70.7f, -5.4f);

	// Token: 0x040028F4 RID: 10484
	private Vector2 inisize = new Vector2(52f, 29f);

	// Token: 0x040028F5 RID: 10485
	private Vector3 inipos = new Vector3(0f, 1024f, 0f);

	// Token: 0x040028F6 RID: 10486
	private float tickspeed = 2.15f;

	// Token: 0x040028F7 RID: 10487
	private Color tickYolkImageColor = Color.black;

	// Token: 0x040028F8 RID: 10488
	private Color sheepTickYolkImageColor = Color.black;

	// Token: 0x040028F9 RID: 10489
	private Color wolfTickYolkImageColor = Color.black;
}
