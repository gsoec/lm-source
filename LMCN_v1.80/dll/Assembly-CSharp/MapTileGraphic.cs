using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000261 RID: 609
public class MapTileGraphic
{
	// Token: 0x06000B44 RID: 2884 RVA: 0x00104490 File Offset: 0x00102690
	public MapTileGraphic(Transform realmGroup, GameObject mapTileGraphic)
	{
		this.GraphicSprites = mapTileGraphic.GetComponent<UISpritesArray>();
		this.GraphicSprites.m_Image.material.renderQueue = 2750;
		this.GraphicLayout = mapTileGraphic.transform;
		this.GraphicLayout.position = Vector3.forward * 3198f;
		this.GraphicLayout.SetParent(realmGroup, false);
		GameObject gameObject = new GameObject("graphiclayout");
		this.MainGraphicLayout = gameObject.transform;
		this.MainGraphicLayout.SetParent(this.GraphicLayout, false);
		gameObject = new GameObject("yolklayout");
		this.YolkGraphicLayout = gameObject.transform;
		this.YolkGraphicLayout.SetParent(this.GraphicLayout, false);
		this.HeightSprite = this.GraphicSprites.GetSprite(this.HeightGraphicID);
	}

	// Token: 0x06000B45 RID: 2885 RVA: 0x001045E8 File Offset: 0x001027E8
	public void OnDestroy()
	{
		if (this.GraphicGameObject != null)
		{
			for (int i = 0; i < this.GraphicGameObject.Length; i++)
			{
				Array.Clear(this.GraphicGameObject[i], 0, this.GraphicGameObject[i].Length);
				this.GraphicGameObject[i] = null;
			}
		}
		if (this.GraphicRectTransform != null)
		{
			for (int j = 0; j < this.GraphicRectTransform.Length; j++)
			{
				Array.Clear(this.GraphicRectTransform[j], 0, this.GraphicRectTransform[j].Length);
				this.GraphicRectTransform[j] = null;
			}
		}
		if (this.GraphicImage != null)
		{
			for (int k = 0; k < this.GraphicImage.Length; k++)
			{
				Array.Clear(this.GraphicImage[k], 0, this.GraphicImage[k].Length);
				this.GraphicImage[k] = null;
			}
		}
		if (this.GraphicGameObjectPools != null)
		{
			for (int l = 0; l < this.GraphicGameObjectPools.Length; l++)
			{
				if (this.GraphicGameObjectPools[l] != null)
				{
					Array.Clear(this.GraphicGameObjectPools[l], 0, this.GraphicGameObjectPools[l].Length);
					this.GraphicGameObjectPools[l] = null;
				}
			}
		}
		if (this.GraphicRectTransformPools != null)
		{
			for (int m = 0; m < this.GraphicRectTransformPools.Length; m++)
			{
				if (this.GraphicRectTransformPools[m] != null)
				{
					Array.Clear(this.GraphicRectTransformPools[m], 0, this.GraphicRectTransformPools[m].Length);
					this.GraphicRectTransformPools[m] = null;
				}
			}
		}
		if (this.GraphicImagePools != null)
		{
			for (int n = 0; n < this.GraphicImagePools.Length; n++)
			{
				if (this.GraphicImagePools[n] != null)
				{
					Array.Clear(this.GraphicImagePools[n], 0, this.GraphicImagePools[n].Length);
					this.GraphicImagePools[n] = null;
				}
			}
		}
		if (this.poolCounter != null)
		{
			Array.Clear(this.poolCounter, 0, this.poolCounter.Length);
			this.poolCounter = null;
		}
		if (this.YolkGraphicGameObject != null)
		{
			Array.Clear(this.YolkGraphicGameObject, 0, this.YolkGraphicGameObject.Length);
			this.YolkGraphicGameObject = null;
		}
		if (this.YolkGraphicRectTransform != null)
		{
			Array.Clear(this.YolkGraphicRectTransform, 0, this.YolkGraphicRectTransform.Length);
			this.YolkGraphicRectTransform = null;
		}
		if (this.YolkGraphicImage != null)
		{
			Array.Clear(this.YolkGraphicImage, 0, this.YolkGraphicImage.Length);
			this.YolkGraphicImage = null;
		}
		if (this.GraphicImagePosOffSet != null)
		{
			Array.Clear(this.GraphicImagePosOffSet, 0, this.GraphicImagePosOffSet.Length);
			this.GraphicImagePosOffSet = null;
		}
		this.GraphicSprites = null;
		if (this.GraphicLayout != null)
		{
			UnityEngine.Object.Destroy(this.GraphicLayout);
		}
		this.GraphicLayout = null;
	}

	// Token: 0x06000B46 RID: 2886 RVA: 0x001048B4 File Offset: 0x00102AB4
	public void IniGraphicImag(int rowNum, int colNum, float tileBaseScale)
	{
		this.GraphicGameObject = new GameObject[colNum][];
		this.GraphicRectTransform = new RectTransform[colNum][];
		this.GraphicImage = new Image[colNum][];
		this.GraphicImagePosOffSet = new Vector2[colNum][];
		for (int i = 0; i < colNum; i++)
		{
			this.GraphicGameObject[i] = new GameObject[rowNum];
			this.GraphicRectTransform[i] = new RectTransform[rowNum];
			this.GraphicImage[i] = new Image[rowNum];
			Array.Clear(this.GraphicGameObject[i], 0, this.GraphicGameObject[i].Length);
			Array.Clear(this.GraphicRectTransform[i], 0, this.GraphicRectTransform[i].Length);
			Array.Clear(this.GraphicImage[i], 0, this.GraphicImage[i].Length);
			this.GraphicImagePosOffSet[i] = new Vector2[rowNum];
			for (int j = 0; j < rowNum; j++)
			{
				this.GraphicImagePosOffSet[i][j] = Vector2.zero;
			}
		}
		this.BaseScale = tileBaseScale;
		this.oBaseScale = tileBaseScale;
		this.BaseScale *= 0.725f;
		this.GraphicGameObjectPools = new GameObject[rowNum][];
		this.GraphicRectTransformPools = new RectTransform[rowNum][];
		this.GraphicImagePools = new Image[rowNum][];
		this.poolCounter = new int[rowNum];
		Array.Clear(this.GraphicGameObjectPools, 0, this.GraphicGameObjectPools.Length);
		Array.Clear(this.GraphicRectTransformPools, 0, this.GraphicRectTransformPools.Length);
		Array.Clear(this.GraphicImagePools, 0, this.GraphicImagePools.Length);
		for (int k = 0; k < this.poolCounter.Length; k++)
		{
			this.poolCounter[k] = -1;
		}
		this.YolkGraphicGameObject = new GameObject[2];
		this.YolkGraphicImage = new Image[2];
		this.YolkGraphicRectTransform = new RectTransform[2];
		for (int l = 0; l < this.YolkGraphicGameObject.Length; l++)
		{
			GameObject gameObject = new GameObject("yolkgraphic");
			gameObject.SetActive(false);
			this.YolkGraphicImage[l] = gameObject.AddComponent<Image>();
			this.YolkGraphicImage[l].material = (UnityEngine.Object.Instantiate(GUIManager.Instance.GetBadgeMaterial(l == 0)) as Material);
			this.YolkGraphicImage[l].material.renderQueue = 2750;
			this.YolkGraphicRectTransform[l] = (gameObject.transform as RectTransform);
			this.YolkGraphicRectTransform[l].sizeDelta = this.inisize;
			this.YolkGraphicRectTransform[l].localPosition = this.inipos;
			this.YolkGraphicRectTransform[l].localScale = Vector3.one * this.YolkGraphicScale;
			this.YolkGraphicRectTransform[l].SetParent(this.YolkGraphicLayout, false);
			this.YolkGraphicGameObject[l] = gameObject;
		}
		this.GraphicGameObjectPools[0] = new GameObject[colNum];
		this.GraphicImagePools[0] = new Image[colNum];
		this.GraphicRectTransformPools[0] = new RectTransform[colNum];
		for (int m = 0; m < this.GraphicGameObjectPools[0].Length; m++)
		{
			GameObject gameObject = new GameObject("graphic");
			gameObject.SetActive(false);
			this.GraphicImagePools[0][m] = gameObject.AddComponent<Image>();
			this.GraphicImagePools[0][m].material = this.GraphicSprites.m_Image.material;
			this.GraphicRectTransformPools[0][m] = (gameObject.transform as RectTransform);
			this.GraphicRectTransformPools[0][m].sizeDelta = this.inisize;
			this.GraphicRectTransformPools[0][m].localPosition = this.inipos;
			this.GraphicRectTransformPools[0][m].localScale = Vector3.one * this.BaseScale;
			this.GraphicRectTransformPools[0][m].SetParent(this.MainGraphicLayout, false);
			this.GraphicGameObjectPools[0][m] = gameObject;
		}
		this.poolCounter[0] = colNum;
		this.poolsCounter = 1;
	}

	// Token: 0x06000B47 RID: 2887 RVA: 0x00104C9C File Offset: 0x00102E9C
	public void setGraphicImage(int graphic, int row, int col, Vector2 pos, ushort mEmblem = 65535)
	{
		if (graphic >= this.YolkGraphic)
		{
			graphic++;
		}
		if (graphic <= -1)
		{
			int num = -graphic;
			num--;
			if (this.YolkEmblem != mEmblem)
			{
				this.YolkEmblem = mEmblem;
				int num2 = ((mEmblem >> 3 & 7) << 3) + (int)(mEmblem & 7) + 1;
				CString cstring = StringManager.Instance.SpawnString(30);
				cstring.ClearString();
				cstring.StringToFormat("UI_league_badge_");
				cstring.IntToFormat((long)num2, 2, false);
				cstring.AppendFormat("{0}{1}");
				cstring.SetLength(cstring.Length);
				this.YolkGraphicImage[0].sprite = GUIManager.Instance.LoadBadgeSprite(true, cstring.ToString());
				cstring.SetLength(cstring.MaxLength);
				this.YolkGraphicRectTransform[0].pivot = Vector2.one * 0.5f;
				this.YolkGraphicRectTransform[0].anchorMin = Vector2.one * 0.5f;
				this.YolkGraphicRectTransform[0].anchorMax = Vector2.one * 0.5f;
				this.YolkGraphicRectTransform[0].offsetMin = Vector2.zero;
				this.YolkGraphicRectTransform[0].offsetMax = Vector2.zero;
				this.YolkGraphicRectTransform[0].anchoredPosition = Vector2.zero;
				this.YolkGraphicRectTransform[0].sizeDelta = Vector2.one * 64f;
				num2 = (mEmblem >> 6 & 63) + 1;
				cstring.ClearString();
				cstring.StringToFormat("UI_league_totem_");
				cstring.IntToFormat((long)num2, 2, false);
				cstring.AppendFormat("{0}{1}");
				cstring.SetLength(cstring.Length);
				this.YolkGraphicImage[1].sprite = GUIManager.Instance.LoadBadgeSprite(false, cstring.ToString());
				cstring.SetLength(cstring.MaxLength);
				this.YolkGraphicImage[1].SetNativeSize();
				StringManager.Instance.DeSpawnString(cstring);
			}
			KingdomYolkDeploy recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
			int i;
			for (i = 1; i < DataManager.MapDataController.KingdomYolkDeployTable.TableCount; i++)
			{
				recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(i);
				if (recordByIndex.kingdomID == DataManager.MapDataController.FocusKingdomID)
				{
					break;
				}
			}
			if (i >= DataManager.MapDataController.KingdomYolkDeployTable.TableCount)
			{
				recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
			}
			ushort inKey = recordByIndex.yolkDeployIDs[num];
			this.YolkGraphicImageOffSet.y = (float)DataManager.MapDataController.YolkDeployTable.GetRecordByKey(inKey).AllianceIconHeight;
			this.YolkGraphicGameObject[0].SetActive(true);
			this.YolkGraphicGameObject[1].SetActive(true);
			this.Yolkrow = row;
			this.Yolkcol = col;
			graphic = this.YolkGraphic;
		}
		if (graphic < 1 || graphic > this.GraphicSprites.m_Sprites.Length)
		{
			if (this.GraphicGameObject[col][row] != null)
			{
				if (col == this.Yolkcol && row == this.Yolkrow)
				{
					this.Yolkrow = -1;
					this.Yolkcol = -1;
					this.YolkGraphicGameObject[0].SetActive(false);
					this.YolkGraphicGameObject[1].SetActive(false);
				}
				this.GraphicGameObject[col][row].SetActive(false);
				this.GraphicRectTransform[col][row].localScale = Vector3.one * this.BaseScale;
				for (int j = 0; j < this.poolsCounter; j++)
				{
					if (this.poolCounter[j] < this.GraphicGameObjectPools[j].Length)
					{
						this.GraphicGameObjectPools[j][this.poolCounter[j]] = this.GraphicGameObject[col][row];
						this.GraphicImagePools[j][this.poolCounter[j]] = this.GraphicImage[col][row];
						this.GraphicRectTransformPools[j][this.poolCounter[j]] = this.GraphicRectTransform[col][row];
						this.GraphicGameObject[col][row] = null;
						this.GraphicImage[col][row] = null;
						this.GraphicRectTransform[col][row] = null;
						this.poolCounter[j]++;
						break;
					}
				}
				this.GraphicImagePosOffSet[col][row] = Vector2.zero;
			}
		}
		else
		{
			if (this.GraphicGameObject[col][row] == null)
			{
				int k;
				for (k = 0; k < this.poolsCounter; k++)
				{
					if (this.poolCounter[k] > 0)
					{
						this.poolCounter[k]--;
						this.GraphicGameObject[col][row] = this.GraphicGameObjectPools[k][this.poolCounter[k]];
						this.GraphicImage[col][row] = this.GraphicImagePools[k][this.poolCounter[k]];
						this.GraphicRectTransform[col][row] = this.GraphicRectTransformPools[k][this.poolCounter[k]];
						this.GraphicGameObjectPools[k][this.poolCounter[k]] = null;
						this.GraphicImagePools[k][this.poolCounter[k]] = null;
						this.GraphicRectTransformPools[k][this.poolCounter[k]] = null;
						break;
					}
				}
				if (k == this.poolsCounter)
				{
					this.GraphicGameObjectPools[k] = new GameObject[this.GraphicGameObjectPools[0].Length];
					this.GraphicImagePools[k] = new Image[this.GraphicImagePools[0].Length];
					this.GraphicRectTransformPools[k] = new RectTransform[this.GraphicRectTransformPools[0].Length];
					for (int l = 0; l < this.GraphicGameObjectPools[k].Length; l++)
					{
						GameObject gameObject = new GameObject("graphic");
						gameObject.SetActive(false);
						this.GraphicImagePools[k][l] = gameObject.AddComponent<Image>();
						this.GraphicImagePools[k][l].material = this.GraphicSprites.m_Image.material;
						this.GraphicRectTransformPools[k][l] = (gameObject.transform as RectTransform);
						this.GraphicRectTransformPools[k][l].sizeDelta = this.inisize;
						this.GraphicRectTransformPools[k][l].localPosition = this.inipos;
						this.GraphicRectTransformPools[k][l].localScale = ((graphic != 6 && graphic >= 5) ? (Vector3.one * this.BaseScale) : (Vector3.one * this.oBaseScale));
						this.GraphicRectTransformPools[k][l].SetParent(this.MainGraphicLayout, false);
						this.GraphicGameObjectPools[k][l] = gameObject;
					}
					this.poolsCounter++;
					this.poolCounter[k] = this.GraphicGameObjectPools[k].Length;
					this.poolCounter[k]--;
					this.GraphicGameObject[col][row] = this.GraphicGameObjectPools[k][this.poolCounter[k]];
					this.GraphicImage[col][row] = this.GraphicImagePools[k][this.poolCounter[k]];
					this.GraphicRectTransform[col][row] = this.GraphicRectTransformPools[k][this.poolCounter[k]];
					this.GraphicGameObjectPools[k][this.poolCounter[k]] = null;
					this.GraphicImagePools[k][this.poolCounter[k]] = null;
					this.GraphicRectTransformPools[k][this.poolCounter[k]] = null;
				}
				this.GraphicGameObject[col][row].SetActive(true);
				if (graphic == this.YolkGraphic)
				{
					this.GraphicRectTransform[col][row].localScale = Vector3.one * this.YolkGraphicScale;
				}
				else if (graphic == 6 || graphic < 5)
				{
					this.GraphicRectTransform[col][row].localScale = Vector3.one * this.oBaseScale;
				}
				else
				{
					this.GraphicRectTransform[col][row].localScale = Vector3.one * this.BaseScale;
				}
			}
			else if (graphic == this.YolkGraphic)
			{
				this.GraphicRectTransform[col][row].localScale = Vector3.one * this.YolkGraphicScale;
			}
			else if (this.Yolkrow == row && this.Yolkcol == col)
			{
				this.Yolkrow = -1;
				this.Yolkcol = -1;
				this.YolkGraphicGameObject[0].SetActive(false);
				this.YolkGraphicGameObject[1].SetActive(false);
				this.GraphicRectTransform[col][row].localScale = ((graphic != 6 && graphic >= 5) ? (Vector3.one * this.BaseScale) : (Vector3.one * this.oBaseScale));
			}
			else if (graphic == 6 || graphic < 5)
			{
				this.GraphicRectTransform[col][row].localScale = Vector3.one * this.oBaseScale;
			}
			else
			{
				this.GraphicRectTransform[col][row].localScale = Vector3.one * this.BaseScale;
			}
			if (this.GraphicImage[col][row].sprite != this.GraphicSprites.GetSprite(graphic - 1))
			{
				this.GraphicImage[col][row].sprite = this.GraphicSprites.GetSprite(graphic - 1);
				if (this.GraphicImage[col][row].sprite == null)
				{
					this.GraphicImage[col][row].sprite = this.GraphicSprites.GetSprite(46);
				}
				this.GraphicImage[col][row].SetNativeSize();
			}
			this.GraphicImagePosOffSet[col][row] = ((graphic != this.YolkGraphic) ? ((graphic != 5 && graphic <= 6) ? this.GraphicImageOffSet : (this.GraphicImageOffSet * 2f)) : this.YolkGraphicImageOffSet);
			this.setGraphicImage(row, col, pos);
		}
	}

	// Token: 0x06000B48 RID: 2888 RVA: 0x00105694 File Offset: 0x00103894
	public void setGraphicImage(int row, int col, Vector2 pos)
	{
		if (this.GraphicGameObject[col][row] != null)
		{
			if (col == this.Yolkcol && row == this.Yolkrow)
			{
				this.YolkGraphicRectTransform[0].anchoredPosition = pos + this.YolkGraphicImageOffSet;
				this.YolkGraphicRectTransform[1].anchoredPosition = pos + this.YolkGraphicImageOffSet;
			}
			this.GraphicRectTransform[col][row].anchoredPosition = pos + this.GraphicImagePosOffSet[col][row];
		}
	}

	// Token: 0x0400261D RID: 9757
	private Transform GraphicLayout;

	// Token: 0x0400261E RID: 9758
	private Transform MainGraphicLayout;

	// Token: 0x0400261F RID: 9759
	private Transform YolkGraphicLayout;

	// Token: 0x04002620 RID: 9760
	private GameObject[][] GraphicGameObject;

	// Token: 0x04002621 RID: 9761
	private RectTransform[][] GraphicRectTransform;

	// Token: 0x04002622 RID: 9762
	private Image[][] GraphicImage;

	// Token: 0x04002623 RID: 9763
	private GameObject[][] GraphicGameObjectPools;

	// Token: 0x04002624 RID: 9764
	private RectTransform[][] GraphicRectTransformPools;

	// Token: 0x04002625 RID: 9765
	private Image[][] GraphicImagePools;

	// Token: 0x04002626 RID: 9766
	private UISpritesArray GraphicSprites;

	// Token: 0x04002627 RID: 9767
	private Vector2 GraphicImageOffSet = new Vector2(0f, 30f);

	// Token: 0x04002628 RID: 9768
	private Vector2 inisize = new Vector2(44f, 62f);

	// Token: 0x04002629 RID: 9769
	private Vector3 inipos = new Vector3(0f, 1024f, 0f);

	// Token: 0x0400262A RID: 9770
	private int[] poolCounter;

	// Token: 0x0400262B RID: 9771
	private int poolsCounter;

	// Token: 0x0400262C RID: 9772
	private float oBaseScale;

	// Token: 0x0400262D RID: 9773
	private float BaseScale;

	// Token: 0x0400262E RID: 9774
	private int HeightGraphicID = 4;

	// Token: 0x0400262F RID: 9775
	private Sprite HeightSprite;

	// Token: 0x04002630 RID: 9776
	private GameObject[] YolkGraphicGameObject;

	// Token: 0x04002631 RID: 9777
	private RectTransform[] YolkGraphicRectTransform;

	// Token: 0x04002632 RID: 9778
	private Image[] YolkGraphicImage;

	// Token: 0x04002633 RID: 9779
	private ushort YolkEmblem = ushort.MaxValue;

	// Token: 0x04002634 RID: 9780
	private Vector2 YolkGraphicImageOffSet = Vector2.zero;

	// Token: 0x04002635 RID: 9781
	private float YolkGraphicScale = 0.85f;

	// Token: 0x04002636 RID: 9782
	private int Yolkrow = -1;

	// Token: 0x04002637 RID: 9783
	private int Yolkcol = -1;

	// Token: 0x04002638 RID: 9784
	private int YolkGraphic = 6;

	// Token: 0x04002639 RID: 9785
	private Vector2[][] GraphicImagePosOffSet;
}
