using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000286 RID: 646
public class WorldMapName
{
	// Token: 0x06000C74 RID: 3188 RVA: 0x00122A60 File Offset: 0x00120C60
	public WorldMapName(Transform totalityGroup, UISpritesArray tileSprites)
	{
		GameObject gameObject = new GameObject("WorldMapNameName");
		this.BloodNameLayout = gameObject.transform;
		this.BloodNameLayout.position = Vector3.forward * 1664f;
		this.BloodNameLayout.SetParent(totalityGroup, false);
		Color color = new Color(0f, 0f, 0f, 0.3f);
		this.NameTex = new Texture2D(2, 2);
		for (int i = 0; i < this.NameTex.height; i++)
		{
			for (int j = 0; j < this.NameTex.width; j++)
			{
				this.NameTex.SetPixel(j, i, color);
			}
		}
		this.NameTex.Apply();
		this.NameSprite = Sprite.Create(this.NameTex, new Rect(0f, 0f, 2f, 2f), new Vector2(0.5f, 0.5f));
		this.PointPoolsCounter = 0;
		this.myPosSprite = tileSprites.GetSprite(0);
		this.myPosMaterial = new Material(tileSprites.m_Image.material);
		this.myPosMaterial.renderQueue = 2800;
	}

	// Token: 0x06000C75 RID: 3189 RVA: 0x00122C10 File Offset: 0x00120E10
	public void OnDestroy()
	{
		if (this.NameTex != null)
		{
			UnityEngine.Object.Destroy(this.NameTex);
		}
		this.NameTex = null;
		if (this.PointName != null)
		{
			for (int i = 0; i < this.PointName.Length; i++)
			{
				if (this.PointName[i] != null)
				{
					for (int j = 0; j < this.PointName[i].Length; j++)
					{
						if (this.PointName[i][j] != null)
						{
							this.PointName[i][j].Release();
						}
					}
					Array.Clear(this.PointName[i], 0, this.PointName[i].Length);
					this.PointName[i] = null;
				}
			}
			this.PointName = null;
		}
		if (this.PointNamePools != null)
		{
			for (int k = 0; k < this.PointNamePools.Length; k++)
			{
				if (this.PointNamePools[k] != null)
				{
					for (int l = 0; l < this.PointNamePools[k].Length; l++)
					{
						if (this.PointNamePools[k][l] != null)
						{
							this.PointNamePools[k][l].Release();
						}
					}
					Array.Clear(this.PointNamePools[k], 0, this.PointNamePools[k].Length);
					this.PointNamePools[k] = null;
				}
			}
			this.PointNamePools = null;
		}
		if (this.PointPoolCounter != null)
		{
			Array.Clear(this.PointPoolCounter, 0, this.PointPoolCounter.Length);
			this.PointPoolCounter = null;
		}
		if (this.BloodNameLayout != null)
		{
			UnityEngine.Object.Destroy(this.BloodNameLayout);
		}
		this.BloodNameLayout = null;
	}

	// Token: 0x06000C76 RID: 3190 RVA: 0x00122DB0 File Offset: 0x00120FB0
	public void IniName(int rowNum, int colNum, float tileBaseScale)
	{
		this.PointName = new WorldKingdomName[colNum][];
		for (int i = 0; i < colNum; i++)
		{
			this.PointName[i] = new WorldKingdomName[rowNum];
			Array.Clear(this.PointName[i], 0, this.PointName[i].Length);
		}
		this.PointNamePools = new WorldKingdomName[rowNum][];
		this.PointPoolCounter = new int[rowNum];
		Array.Clear(this.PointNamePools, 0, this.PointNamePools.Length);
		for (int j = 0; j < this.PointPoolCounter.Length; j++)
		{
			this.PointPoolCounter[j] = -1;
		}
		this.PointNamePools[0] = new WorldKingdomName[colNum];
		for (int k = 0; k < this.PointNamePools[0].Length; k++)
		{
			this.PointNamePools[0][k] = new WorldKingdomName(this.BloodNameLayout, this.iniNamePos, this.NameTextSize);
		}
		this.PointPoolCounter[0] = colNum;
		this.PointPoolsCounter = 1;
		this.myPosGameObject = new GameObject("myKingdom");
		this.myPosGameObject.SetActive(false);
		this.myPosImage = this.myPosGameObject.AddComponent<Image>();
		this.myPosImage.material = this.myPosMaterial;
		this.myPosImage.sprite = this.myPosSprite;
		this.myPosImage.SetNativeSize();
		this.myPosRectTransform = (this.myPosGameObject.transform as RectTransform);
		this.myPosRectTransform.localScale = Vector3.one * tileBaseScale;
		this.myPosRectTransform.anchoredPosition = new Vector2(-103f, 68f);
		this.myPosRectTransform.SetParent(this.BloodNameLayout, false);
	}

	// Token: 0x06000C77 RID: 3191 RVA: 0x00122F60 File Offset: 0x00121160
	public void setName(byte SetKingdomTableID, int row, int col, Color textcolor, Vector2 pos)
	{
		if ((int)SetKingdomTableID >= DataManager.MapDataController.WorldKingdomTable.Length)
		{
			if (this.PointName[col][row] != null)
			{
				this.PointName[col][row].SetActive(false);
				for (int i = 0; i < this.PointPoolsCounter; i++)
				{
					if (this.PointPoolCounter[i] < this.PointNamePools[i].Length)
					{
						this.PointNamePools[i][this.PointPoolCounter[i]] = this.PointName[col][row];
						this.PointName[col][row] = null;
						this.PointPoolCounter[i]++;
						break;
					}
				}
			}
		}
		else
		{
			if (this.PointName[col][row] == null)
			{
				int j;
				for (j = 0; j < this.PointPoolsCounter; j++)
				{
					if (this.PointPoolCounter[j] > 0)
					{
						this.PointPoolCounter[j]--;
						this.PointName[col][row] = this.PointNamePools[j][this.PointPoolCounter[j]];
						this.PointNamePools[j][this.PointPoolCounter[j]] = null;
						break;
					}
				}
				if (j == this.PointPoolsCounter)
				{
					this.PointNamePools[j] = new WorldKingdomName[this.PointNamePools[0].Length];
					for (int k = 0; k < this.PointNamePools[j].Length; k++)
					{
						this.PointNamePools[j][k] = new WorldKingdomName(this.BloodNameLayout, this.iniNamePos, this.NameTextSize);
					}
					this.PointPoolsCounter++;
					this.PointPoolCounter[j] = this.PointNamePools[j].Length;
					this.PointPoolCounter[j]--;
					this.PointName[col][row] = this.PointNamePools[j][this.PointPoolCounter[j]];
					this.PointNamePools[j][this.PointPoolCounter[j]] = null;
				}
			}
			this.PointName[col][row].SetNameText(row, col);
			if (DataManager.MapDataController.WorldKingdomTable[(int)SetKingdomTableID].kingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
			{
				this.PointName[col][row].updateName(SetKingdomTableID, this.myPosImage, textcolor, pos + this.NameTextOffset);
			}
			else
			{
				this.PointName[col][row].updateName(SetKingdomTableID, null, textcolor, pos + this.NameTextOffset);
			}
		}
	}

	// Token: 0x06000C78 RID: 3192 RVA: 0x001231CC File Offset: 0x001213CC
	public void setName(int row, int col, Vector2 pos)
	{
		if (this.PointName[col][row] != null)
		{
			this.PointName[col][row].updateName(pos + this.NameTextOffset);
		}
	}

	// Token: 0x06000C79 RID: 3193 RVA: 0x00123204 File Offset: 0x00121404
	public void myPosImageRun()
	{
		if (this.myPosGameObject.activeSelf)
		{
			float d = Time.deltaTime * this.myPosImageSpeed;
			this.myPosRectTransform.anchoredPosition += Vector2.up * d;
			if (this.myPosRectTransform.anchoredPosition.y > this.myPosImagePosY + 20f)
			{
				Vector2 anchoredPosition = this.myPosRectTransform.anchoredPosition;
				anchoredPosition.y = this.myPosImagePosY + 20f;
				this.myPosRectTransform.anchoredPosition = anchoredPosition;
				this.myPosImageSpeed *= -1f;
			}
			if (this.myPosRectTransform.anchoredPosition.y < this.myPosImagePosY)
			{
				Vector2 anchoredPosition2 = this.myPosRectTransform.anchoredPosition;
				anchoredPosition2.y = this.myPosImagePosY;
				this.myPosRectTransform.anchoredPosition = anchoredPosition2;
				this.myPosImageSpeed *= -1f;
			}
		}
		this.SetTimeText();
	}

	// Token: 0x06000C7A RID: 3194 RVA: 0x00123310 File Offset: 0x00121510
	public void WorldKingdomNameRebuilt()
	{
		if (this.PointName != null)
		{
			for (int i = 0; i < this.PointName.Length; i++)
			{
				if (this.PointName[i] != null)
				{
					for (int j = 0; j < this.PointName[i].Length; j++)
					{
						if (this.PointName[i][j] != null)
						{
							this.PointName[i][j].NameTextRebuilt();
						}
					}
				}
			}
		}
	}

	// Token: 0x06000C7B RID: 3195 RVA: 0x00123388 File Offset: 0x00121588
	public void SetTimeText()
	{
		if (this.PointName != null)
		{
			for (int i = 0; i < this.PointName.Length; i++)
			{
				if (this.PointName[i] != null)
				{
					for (int j = 0; j < this.PointName[i].Length; j++)
					{
						if (this.PointName[i][j] != null)
						{
							this.PointName[i][j].SetTimeText();
						}
					}
				}
			}
		}
	}

	// Token: 0x040028B9 RID: 10425
	public const float NamePosX = 128f;

	// Token: 0x040028BA RID: 10426
	public const float MyPosY = 0f;

	// Token: 0x040028BB RID: 10427
	public const float notMyPosY = -20f;

	// Token: 0x040028BC RID: 10428
	public const float MySizeW = 512f;

	// Token: 0x040028BD RID: 10429
	public const float MySizeH = 215f;

	// Token: 0x040028BE RID: 10430
	public const float notMySizeH = 178f;

	// Token: 0x040028BF RID: 10431
	public Transform BloodNameLayout;

	// Token: 0x040028C0 RID: 10432
	private Texture2D NameTex;

	// Token: 0x040028C1 RID: 10433
	private Sprite NameSprite;

	// Token: 0x040028C2 RID: 10434
	private Vector2 NameImageSize = new Vector2(0f, 34f);

	// Token: 0x040028C3 RID: 10435
	private Vector2 NameTextSize = new Vector2(512f, 118f);

	// Token: 0x040028C4 RID: 10436
	private Vector2 NameTextOffset = new Vector2(0f, -85f);

	// Token: 0x040028C5 RID: 10437
	private Vector3 iniNamePos = new Vector3(0f, 1024f, 0f);

	// Token: 0x040028C6 RID: 10438
	private Image myPosImage;

	// Token: 0x040028C7 RID: 10439
	private Sprite myPosSprite;

	// Token: 0x040028C8 RID: 10440
	private Material myPosMaterial;

	// Token: 0x040028C9 RID: 10441
	private GameObject myPosGameObject;

	// Token: 0x040028CA RID: 10442
	private RectTransform myPosRectTransform;

	// Token: 0x040028CB RID: 10443
	private float myPosImageSpeed = 25f;

	// Token: 0x040028CC RID: 10444
	private float myPosImagePosY = 58f;

	// Token: 0x040028CD RID: 10445
	private WorldKingdomName[][] PointName;

	// Token: 0x040028CE RID: 10446
	private WorldKingdomName[][] PointNamePools;

	// Token: 0x040028CF RID: 10447
	private int[] PointPoolCounter;

	// Token: 0x040028D0 RID: 10448
	private int PointPoolsCounter;
}
