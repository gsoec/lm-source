using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200025E RID: 606
public class MapTileBloodName
{
	// Token: 0x06000B1E RID: 2846 RVA: 0x000EF7D0 File Offset: 0x000ED9D0
	public MapTileBloodName(Transform realmGroup)
	{
		GUIManager.Instance.EmojiManager.EmojiCenterIni();
		this.NPCBloodAB = GUIManager.Instance.EmojiManager.EmojiAB;
		GameObject gameObject = new GameObject("MapTileBloodName");
		this.BloodNameLayout = gameObject.transform;
		this.BloodNameLayout.position = Vector3.forward * 2944f;
		this.BloodNameLayout.SetParent(realmGroup, false);
		gameObject = new GameObject("MapTileNPCBlood");
		this.NPCBloodLayout = gameObject.transform;
		this.NPCBloodLayout.position = Vector3.forward * 2944f;
		this.NPCBloodLayout.SetParent(this.BloodNameLayout, false);
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
		this.LinePoolsCounter = 0;
		this.NPCLevelStr = new CString[this.maxlevel];
		this.NPCLevelStr[0] = null;
		for (int k = 1; k < this.NPCLevelStr.Length; k++)
		{
			this.NPCLevelStr[k] = new CString(2);
			this.NPCLevelStr[k].ClearString();
			this.NPCLevelStr[k].IntToFormat((long)k, 1, false);
			this.NPCLevelStr[k].AppendFormat("{0}");
		}
		this.NPCTimeStr.ClearString();
	}

	// Token: 0x06000B20 RID: 2848 RVA: 0x000EFB94 File Offset: 0x000EDD94
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
		if (this.LineNamePools != null)
		{
			for (int m = 0; m < this.LineNamePools.Count; m++)
			{
				if (this.LineNamePools[m] != null)
				{
					this.LineNamePools[m].Release();
				}
				this.LineNamePools[m] = null;
			}
		}
		if (this.NPCBloodPools != null)
		{
			for (int n = 0; n < this.NPCBloodPools.Length; n++)
			{
				if (this.NPCBloodPools[n] != null)
				{
					Array.Clear(this.NPCBloodPools[n], 0, this.NPCBloodPools[n].Length);
					this.NPCBloodPools[n] = null;
				}
			}
			this.NPCBloodPools = null;
		}
		if (this.NPCBloodPoolCounter != null)
		{
			Array.Clear(this.NPCBloodPoolCounter, 0, this.NPCBloodPoolCounter.Length);
			this.NPCBloodPoolCounter = null;
		}
		if (this.NPCBloodValue != null)
		{
			for (int num = 0; num < this.NPCBloodValue.Length; num++)
			{
				Array.Clear(this.NPCBloodValue[num], 0, this.NPCBloodValue[num].Length);
			}
			this.NPCBloodValue = null;
		}
		if (this.NPCBloodSpeed != null)
		{
			for (int num2 = 0; num2 < this.NPCBloodSpeed.Length; num2++)
			{
				Array.Clear(this.NPCBloodSpeed[num2], 0, this.NPCBloodSpeed[num2].Length);
			}
			this.NPCBloodSpeed = null;
		}
		if (this.NPCLevelStr != null)
		{
			Array.Clear(this.NPCLevelStr, 1, this.NPCLevelStr.Length - 1);
			this.NPCLevelStr = null;
		}
		if (this.NPCBloodStr != null)
		{
			for (int num3 = 0; num3 < this.NPCBloodStr.Length; num3++)
			{
				for (int num4 = 0; num4 < this.NPCBloodStr[num3].Length; num4++)
				{
					this.NPCBloodStr[num3][num4].ClearString();
					this.NPCBloodStr[num3][num4] = null;
				}
				this.NPCBloodStr[num3] = null;
			}
		}
		if (this.NPCBloodLayout != null)
		{
			this.NPCBloodLayout = null;
		}
		if (this.BloodNameLayout != null)
		{
			UnityEngine.Object.Destroy(this.BloodNameLayout);
		}
		this.BloodNameLayout = null;
		this.NPCBloodAB = null;
	}

	// Token: 0x06000B21 RID: 2849 RVA: 0x000EFF60 File Offset: 0x000EE160
	public void IniName(int rowNum, int colNum)
	{
		this.PointName = new MapTileName[colNum][];
		for (int i = 0; i < colNum; i++)
		{
			this.PointName[i] = new MapTileName[rowNum];
			Array.Clear(this.PointName[i], 0, this.PointName[i].Length);
		}
		this.PointNamePools = new MapTileName[rowNum][];
		this.PointPoolCounter = new int[rowNum];
		Array.Clear(this.PointNamePools, 0, this.PointNamePools.Length);
		for (int j = 0; j < this.PointPoolCounter.Length; j++)
		{
			this.PointPoolCounter[j] = -1;
		}
		this.PointNamePools[0] = new MapTileName[colNum];
		for (int k = 0; k < this.PointNamePools[0].Length; k++)
		{
			this.PointNamePools[0][k] = new MapTileName(this.BloodNameLayout, this.iniNamePos, this.NameTextSize);
		}
		this.PointPoolCounter[0] = colNum;
		this.PointPoolsCounter = 1;
		for (int l = 0; l < this.LinePoolsCounter; l++)
		{
			this.LineNamePools[l] = new MapTileName(this.BloodNameLayout, this.iniNamePos, this.NameTextSize);
		}
		this.NPCBloodPools = new Transform[rowNum][];
		this.NPCBloodPoolCounter = new int[rowNum];
		Array.Clear(this.NPCBloodPools, 0, this.NPCBloodPools.Length);
		for (int m = 0; m < this.NPCBloodPoolCounter.Length; m++)
		{
			this.NPCBloodPoolCounter[m] = -1;
		}
		this.NPCBloodPools[0] = new Transform[colNum];
		for (int n = 0; n < this.NPCBloodPools[0].Length; n++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(this.NPCBloodAB.mainAsset) as GameObject;
			this.NPCBloodPools[0][n] = gameObject.transform;
			this.NPCBloodPools[0][n].localScale = Vector3.one * this.NPCBloodScale;
			this.NPCBloodPools[0][n].position = this.NPCBloodpos;
			this.NPCBloodPools[0][n].SetParent(this.NPCBloodLayout, false);
			Transform child = this.NPCBloodPools[0][n].GetChild(4);
			Text component = child.GetComponent<Text>();
			component.font = GUIManager.Instance.GetTTFFont();
			component.material = component.font.material;
			child = this.NPCBloodPools[0][n].GetChild(3);
			component = child.GetComponent<Text>();
			component.font = GUIManager.Instance.GetTTFFont();
			component.material = component.font.material;
			component.verticalOverflow = VerticalWrapMode.Overflow;
			this.NPCBloodPools[0][n].gameObject.SetActive(false);
		}
		this.NPCBloodPoolCounter[0] = colNum;
		this.NPCBloodPoolsCounter = 1;
		this.NPCBloodValue = new float[rowNum][];
		for (int num = 0; num < this.NPCBloodValue.Length; num++)
		{
			this.NPCBloodValue[num] = new float[colNum];
			Array.Clear(this.NPCBloodValue[num], 0, this.NPCBloodValue[num].Length);
		}
		this.NPCBloodSpeed = new float[rowNum][];
		for (int num2 = 0; num2 < this.NPCBloodSpeed.Length; num2++)
		{
			this.NPCBloodSpeed[num2] = new float[colNum];
			Array.Clear(this.NPCBloodSpeed[num2], 0, this.NPCBloodSpeed[num2].Length);
		}
		this.NPCBloodStr = new CString[rowNum][];
		for (int num3 = 0; num3 < this.NPCBloodStr.Length; num3++)
		{
			this.NPCBloodStr[num3] = new CString[colNum];
			for (int num4 = 0; num4 < this.NPCBloodStr[num3].Length; num4++)
			{
				this.NPCBloodStr[num3][num4] = new CString(8);
			}
		}
		this.npccityname.ClearString();
		this.npccityname.Append(DataManager.Instance.mStringTable.GetStringByID(12033u));
	}

	// Token: 0x06000B22 RID: 2850 RVA: 0x000F0384 File Offset: 0x000EE584
	public void setName(CString Name, CString Tag, int row, int col, Color textcolor, Vector2 pos, byte npclevel = 0, float npcbloods = 0f, ushort kingdomID = 0, CString First = null, int emojiID = -1, float offsety = 0f)
	{
		if ((Name == null || Name.Length == 0) && emojiID == -1)
		{
			if (this.PointName[col][row] != null)
			{
				this.setName(row, col, -1);
				this.PointName[col][row].SetActive(false);
				if (this.PointName[col][row].bloodtextID > 0)
				{
					Transform child = this.PointName[col][row].NameRectTransform.GetChild(this.PointName[col][row].bloodtextID);
					this.PointName[col][row].bloodtextID = -1;
					for (int i = 0; i < this.NPCBloodPoolsCounter; i++)
					{
						if (this.NPCBloodPoolCounter[i] < this.NPCBloodPools[i].Length)
						{
							this.NPCBloodPools[i][this.NPCBloodPoolCounter[i]] = child;
							child.SetParent(this.NPCBloodLayout, false);
							child.GetChild(3).GetComponent<Text>().color = Color.white;
							child.gameObject.SetActive(false);
							this.NPCBloodPoolCounter[i]++;
							break;
						}
					}
				}
				if (this.PointName[col][row].mapEmoji != null)
				{
					GUIManager.Instance.pushEmojiIcon(this.PointName[col][row].mapEmoji);
					this.PointName[col][row].mapEmoji = null;
				}
				if (this.PointName[col][row].mapEmojiBack != null)
				{
					GUIManager.Instance.pushEmojiIcon(this.PointName[col][row].mapEmojiBack);
					this.PointName[col][row].mapEmojiBack = null;
				}
				for (int j = 0; j < this.PointPoolsCounter; j++)
				{
					if (this.PointPoolCounter[j] < this.PointNamePools[j].Length)
					{
						this.PointNamePools[j][this.PointPoolCounter[j]] = this.PointName[col][row];
						this.PointName[col][row].NameOffset = 0f;
						this.PointName[col][row] = null;
						this.PointPoolCounter[j]++;
						break;
					}
				}
			}
		}
		else
		{
			if (this.PointName[col][row] == null)
			{
				int k;
				for (k = 0; k < this.PointPoolsCounter; k++)
				{
					if (this.PointPoolCounter[k] > 0)
					{
						this.PointPoolCounter[k]--;
						this.PointName[col][row] = this.PointNamePools[k][this.PointPoolCounter[k]];
						this.PointNamePools[k][this.PointPoolCounter[k]] = null;
						break;
					}
				}
				if (k == this.PointPoolsCounter)
				{
					this.PointNamePools[k] = new MapTileName[this.PointNamePools[0].Length];
					for (int l = 0; l < this.PointNamePools[k].Length; l++)
					{
						this.PointNamePools[k][l] = new MapTileName(this.BloodNameLayout, this.iniNamePos, this.NameTextSize);
					}
					this.PointPoolsCounter++;
					this.PointPoolCounter[k] = this.PointNamePools[k].Length;
					this.PointPoolCounter[k]--;
					this.PointName[col][row] = this.PointNamePools[k][this.PointPoolCounter[k]];
					this.PointNamePools[k][this.PointPoolCounter[k]] = null;
				}
			}
			this.setName(row, col, -1);
			if (npclevel != 0 && this.PointName[col][row].bloodtextID < 1)
			{
				int m;
				for (m = 0; m < this.NPCBloodPoolsCounter; m++)
				{
					if (this.NPCBloodPoolCounter[m] > 0)
					{
						this.PointName[col][row].bloodtextID = this.PointName[col][row].NameRectTransform.childCount;
						this.NPCBloodPoolCounter[m]--;
						this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].SetParent(this.PointName[col][row].NameRectTransform, false);
						this.NPCBloodValue[col][row] = 0f;
						Transform child2 = this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].GetChild(0);
						child2.gameObject.SetActive(true);
						child2 = this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].GetChild(2);
						child2.gameObject.SetActive(false);
						RectTransform component = this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].GetChild(1).GetComponent<RectTransform>();
						component.gameObject.SetActive(true);
						Vector2 sizeDelta = component.sizeDelta;
						sizeDelta.x = this.maxblood * npcbloods / 100f;
						component.sizeDelta = sizeDelta;
						child2 = this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].GetChild(4);
						child2.gameObject.SetActive(true);
						Text component2 = child2.GetComponent<Text>();
						component2.text = this.NPCLevelStr[(int)npclevel].ToString();
						child2 = this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].GetChild(3);
						component = child2.GetComponent<RectTransform>();
						component.anchoredPosition = new Vector2(this.NPCTimeStrXOffSet, 0f);
						component2 = child2.GetComponent<Text>();
						this.NPCBloodStr[col][row].ClearString();
						this.NPCBloodStr[col][row].FloatToFormat(this.checkNpdBlood(npcbloods), 2, true);
						if (GUIManager.Instance.IsArabic)
						{
							this.NPCBloodStr[col][row].AppendFormat("%{0}");
						}
						else
						{
							this.NPCBloodStr[col][row].AppendFormat("{0}%");
						}
						component2.color = Color.white;
						if (this.NPCTimeState == 0)
						{
							component2.text = this.NPCBloodStr[col][row].ToString();
						}
						else
						{
							if (ActivityManager.Instance.ActivityData[0].EventCountTime < (long)this.minTime)
							{
								component2.color = Color.yellow;
							}
							component2.text = this.NPCTimeStr.ToString();
						}
						component2.SetAllDirty();
						component2.cachedTextGenerator.Invalidate();
						this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].gameObject.SetActive(true);
						this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]] = null;
						break;
					}
				}
				if (m == this.NPCBloodPoolsCounter)
				{
					this.NPCBloodPools[m] = new Transform[this.NPCBloodPools[0].Length];
					Transform child2;
					Text component2;
					for (int n = 0; n < this.NPCBloodPools[m].Length; n++)
					{
						GameObject gameObject = UnityEngine.Object.Instantiate(this.NPCBloodAB.mainAsset) as GameObject;
						this.NPCBloodPools[m][n] = gameObject.transform;
						this.NPCBloodPools[m][n].localScale = Vector3.one * this.NPCBloodScale;
						this.NPCBloodPools[m][n].position = this.NPCBloodpos;
						this.NPCBloodPools[m][n].SetParent(this.NPCBloodLayout, false);
						child2 = this.NPCBloodPools[m][n].GetChild(4);
						component2 = child2.GetComponent<Text>();
						component2.font = GUIManager.Instance.GetTTFFont();
						component2.material = component2.font.material;
						child2 = this.NPCBloodPools[m][n].GetChild(3);
						component2 = child2.GetComponent<Text>();
						component2.font = GUIManager.Instance.GetTTFFont();
						component2.material = component2.font.material;
						component2.verticalOverflow = VerticalWrapMode.Overflow;
						this.NPCBloodPools[m][n].gameObject.SetActive(false);
					}
					this.PointName[col][row].bloodtextID = this.PointName[col][row].NameRectTransform.childCount;
					this.NPCBloodPoolsCounter++;
					this.NPCBloodPoolCounter[m] = this.NPCBloodPools[m].Length;
					this.NPCBloodPoolCounter[m]--;
					this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].SetParent(this.PointName[col][row].NameRectTransform, false);
					this.NPCBloodValue[col][row] = 0f;
					child2 = this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].GetChild(0);
					child2.gameObject.SetActive(true);
					child2 = this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].GetChild(2);
					child2.gameObject.SetActive(false);
					RectTransform component = this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].GetChild(1).GetComponent<RectTransform>();
					component.gameObject.SetActive(true);
					Vector2 sizeDelta2 = component.sizeDelta;
					sizeDelta2.x = this.maxblood * npcbloods / 100f;
					component.sizeDelta = sizeDelta2;
					child2 = this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].GetChild(4);
					child2.gameObject.SetActive(true);
					component2 = child2.GetComponent<Text>();
					component2.text = this.NPCLevelStr[(int)npclevel].ToString();
					child2 = this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].GetChild(3);
					component = child2.GetComponent<RectTransform>();
					component.anchoredPosition = new Vector2(this.NPCTimeStrXOffSet, 0f);
					component2 = child2.GetComponent<Text>();
					this.NPCBloodStr[col][row].ClearString();
					this.NPCBloodStr[col][row].FloatToFormat(this.checkNpdBlood(npcbloods), 2, true);
					if (GUIManager.Instance.IsArabic)
					{
						this.NPCBloodStr[col][row].AppendFormat("%{0}");
					}
					else
					{
						this.NPCBloodStr[col][row].AppendFormat("{0}%");
					}
					component2.color = Color.white;
					if (this.NPCTimeState == 0)
					{
						component2.text = this.NPCBloodStr[col][row].ToString();
					}
					else
					{
						if (ActivityManager.Instance.ActivityData[0].EventCountTime < (long)this.minTime)
						{
							component2.color = Color.yellow;
						}
						component2.text = this.NPCTimeStr.ToString();
					}
					component2.SetAllDirty();
					component2.cachedTextGenerator.Invalidate();
					this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]].gameObject.SetActive(true);
					this.NPCBloodPools[m][this.NPCBloodPoolCounter[m]] = null;
				}
				this.PointName[col][row].NameOffset = this.NPCNameOffSet;
			}
			else
			{
				if (npclevel == 0 && this.PointName[col][row].bloodtextID > 0)
				{
					Transform child2 = this.PointName[col][row].NameRectTransform.GetChild(this.PointName[col][row].bloodtextID);
					this.PointName[col][row].bloodtextID = -1;
					for (int num = 0; num < this.NPCBloodPoolsCounter; num++)
					{
						if (this.NPCBloodPoolCounter[num] < this.NPCBloodPools[num].Length)
						{
							this.NPCBloodPools[num][this.NPCBloodPoolCounter[num]] = child2;
							child2.SetParent(this.NPCBloodLayout, false);
							child2.GetChild(3).GetComponent<Text>().color = Color.white;
							child2.gameObject.SetActive(false);
							this.NPCBloodPoolCounter[num]++;
							break;
						}
					}
				}
				if (this.PointName[col][row].bloodtextID > 0)
				{
					this.PointName[col][row].NameOffset = this.NPCNameOffSet;
					this.NPCBloodValue[col][row] = 0f;
					Transform child3 = this.PointName[col][row].NameRectTransform.GetChild(this.PointName[col][row].bloodtextID);
					Transform child2 = child3.GetChild(0);
					child2.gameObject.SetActive(true);
					child2 = child3.GetChild(2);
					child2.gameObject.SetActive(false);
					RectTransform component = child3.GetChild(1).GetComponent<RectTransform>();
					component.gameObject.SetActive(true);
					Vector2 sizeDelta3 = component.sizeDelta;
					sizeDelta3.x = this.maxblood * npcbloods / 100f;
					component.sizeDelta = sizeDelta3;
					child2 = child3.GetChild(4);
					child2.gameObject.SetActive(true);
					Text component2 = child2.GetComponent<Text>();
					component2.text = this.NPCLevelStr[(int)npclevel].ToString();
					child2 = child3.GetChild(3);
					component = child2.GetComponent<RectTransform>();
					component.anchoredPosition = new Vector2(this.NPCTimeStrXOffSet, 0f);
					component2 = child2.GetComponent<Text>();
					this.NPCBloodStr[col][row].ClearString();
					this.NPCBloodStr[col][row].FloatToFormat(this.checkNpdBlood(npcbloods), 2, true);
					if (GUIManager.Instance.IsArabic)
					{
						this.NPCBloodStr[col][row].AppendFormat("%{0}");
					}
					else
					{
						this.NPCBloodStr[col][row].AppendFormat("{0}%");
					}
					component2.color = Color.white;
					if (this.NPCTimeState == 0)
					{
						component2.text = this.NPCBloodStr[col][row].ToString();
					}
					else
					{
						if (ActivityManager.Instance.ActivityData[0].EventCountTime < (long)this.minTime)
						{
							component2.color = Color.yellow;
						}
						component2.text = this.NPCTimeStr.ToString();
					}
					component2.SetAllDirty();
					component2.cachedTextGenerator.Invalidate();
				}
				else
				{
					this.PointName[col][row].NameOffset = 0f;
				}
			}
			if (emojiID > -1)
			{
				EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey((ushort)emojiID);
				if ((int)recordByKey.EmojiKey == emojiID)
				{
					float num2 = (float)((recordByKey.sizeX <= recordByKey.sizeY) ? recordByKey.sizeY : recordByKey.sizeX);
					if (num2 == 0f)
					{
						num2 = ((GUIManager.Instance.EmojiManager != null) ? GUIManager.Instance.EmojiManager.basebacksize : 73f);
					}
					else
					{
						num2 *= 0.9f;
						num2 += ((GUIManager.Instance.EmojiManager != null) ? GUIManager.Instance.EmojiManager.basebackoffset : 25f);
					}
					num2 /= ((GUIManager.Instance.EmojiManager != null) ? GUIManager.Instance.EmojiManager.basebacksize : 73f);
					if (this.PointName[col][row].mapEmoji == null)
					{
						this.PointName[col][row].mapEmoji = GUIManager.Instance.pullEmojiIcon(recordByKey.IconID, recordByKey.KeyFrame, false);
						if (this.MapEmojiImageMaterial == null)
						{
							this.MapEmojiImageMaterial = new Material(this.PointName[col][row].mapEmoji.EmojiImage.material);
							this.MapEmojiImageMaterial.renderQueue = 2999;
						}
						this.PointName[col][row].mapEmoji.EmojiImage.material = this.MapEmojiImageMaterial;
						this.PointName[col][row].mapEmoji.EmojiTransform.localPosition = new Vector3(0f, offsety, 0f);
						this.PointName[col][row].mapEmoji.EmojiTransform.localScale = Vector3.one * 0.9f;
						this.PointName[col][row].mapEmoji.EmojiTransform.SetParent(this.PointName[col][row].NameRectTransform, false);
						this.PointName[col][row].mapEmoji.EmojiTransform.SetAsFirstSibling();
						if (this.PointName[col][row].bloodtextID > 0)
						{
							this.PointName[col][row].bloodtextID++;
						}
						if (this.PointName[col][row].mapEmojiBack == null)
						{
							this.PointName[col][row].mapEmojiBack = GUIManager.Instance.pullEmojiIcon(ushort.MaxValue, 0, false);
							if (this.MapEmojiImageMaterial == null)
							{
								this.MapEmojiImageMaterial = new Material(this.PointName[col][row].mapEmojiBack.EmojiImage.material);
								this.MapEmojiImageMaterial.renderQueue = 2999;
							}
							this.PointName[col][row].mapEmojiBack.EmojiImage.material = this.MapEmojiImageMaterial;
							if (offsety != 0f)
							{
								this.PointName[col][row].mapEmojiBack.EmojiTransform.localPosition = new Vector3(0f, offsety - 5f, 0f);
							}
							this.PointName[col][row].mapEmojiBack.EmojiTransform.localScale = Vector3.one * num2;
							this.PointName[col][row].mapEmojiBack.EmojiTransform.SetParent(this.PointName[col][row].NameRectTransform, false);
							this.PointName[col][row].mapEmojiBack.EmojiTransform.SetAsFirstSibling();
							if (this.PointName[col][row].bloodtextID > 0)
							{
								this.PointName[col][row].bloodtextID++;
							}
						}
					}
					else if (this.PointName[col][row].mapEmoji.IconID != recordByKey.IconID)
					{
						GUIManager.Instance.pushEmojiIcon(this.PointName[col][row].mapEmoji);
						this.PointName[col][row].mapEmoji = GUIManager.Instance.pullEmojiIcon(recordByKey.IconID, recordByKey.KeyFrame, false);
						if (this.MapEmojiImageMaterial == null)
						{
							this.MapEmojiImageMaterial = new Material(this.PointName[col][row].mapEmoji.EmojiImage.material);
							this.MapEmojiImageMaterial.renderQueue = 2999;
						}
						this.PointName[col][row].mapEmoji.EmojiImage.material = this.MapEmojiImageMaterial;
						this.PointName[col][row].mapEmoji.EmojiTransform.localPosition = new Vector3(0f, offsety, 0f);
						this.PointName[col][row].mapEmoji.EmojiTransform.localScale = Vector3.one * 0.9f;
						this.PointName[col][row].mapEmoji.EmojiTransform.SetParent(this.PointName[col][row].NameRectTransform, false);
						this.PointName[col][row].mapEmoji.EmojiTransform.SetAsFirstSibling();
						if (offsety != 0f)
						{
							this.PointName[col][row].mapEmojiBack.EmojiTransform.localPosition = new Vector3(0f, offsety - 5f, 0f);
						}
						this.PointName[col][row].mapEmojiBack.EmojiTransform.localScale = Vector3.one * num2;
						this.PointName[col][row].mapEmojiBack.EmojiTransform.SetAsFirstSibling();
					}
				}
			}
			else if (this.PointName[col][row].mapEmoji != null)
			{
				GUIManager.Instance.pushEmojiIcon(this.PointName[col][row].mapEmoji);
				this.PointName[col][row].mapEmoji = null;
				if (this.PointName[col][row].bloodtextID > 0)
				{
					this.PointName[col][row].bloodtextID--;
				}
				if (this.PointName[col][row].mapEmojiBack != null)
				{
					GUIManager.Instance.pushEmojiIcon(this.PointName[col][row].mapEmojiBack);
					this.PointName[col][row].mapEmojiBack = null;
					if (this.PointName[col][row].bloodtextID > 0)
					{
						this.PointName[col][row].bloodtextID--;
					}
				}
			}
			this.PointName[col][row].updateName(Name, Tag, textcolor, pos + this.NameTextOffset, kingdomID, First);
		}
	}

	// Token: 0x06000B23 RID: 2851 RVA: 0x000F184C File Offset: 0x000EFA4C
	public void setName(ushort NPCNum, int row, int col, Color textcolor, Vector2 pos, byte npclevel, float npcbloods, int emojiID = -1, CString tag = null, short pointID = -1)
	{
		if (this.NPCTimeStr.Length == 0)
		{
			this.NPCTimeStr.ClearString();
			GameConstants.GetTimeString(this.NPCTimeStr, (uint)ActivityManager.Instance.ActivityData[0].EventCountTime, false, true, false, false, true);
		}
		MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(NPCNum);
		this.npcname.ClearString();
		this.npcname.Append(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.NameID));
		this.setName(this.npcname, tag, row, col, textcolor, pos, npclevel, npcbloods, 0, null, emojiID, 92f);
		if (tag == null || tag[0] == '\0')
		{
			this.setName(row, col, -1);
		}
		else
		{
			this.setName(row, col, pointID);
		}
	}

	// Token: 0x06000B24 RID: 2852 RVA: 0x000F1920 File Offset: 0x000EFB20
	public void setName(CString Tag, int row, int col, Color textcolor, Vector2 pos, int emojiID = -1)
	{
		this.setName(this.npccityname, Tag, row, col, textcolor, pos, 0, 0f, 0, null, emojiID, 92f);
	}

	// Token: 0x06000B25 RID: 2853 RVA: 0x000F1950 File Offset: 0x000EFB50
	public void setName(int row, int col, Vector2 pos)
	{
		if (this.PointName[col][row] != null)
		{
			this.PointName[col][row].updateName(pos + this.NameTextOffset);
		}
	}

	// Token: 0x06000B26 RID: 2854 RVA: 0x000F1988 File Offset: 0x000EFB88
	public void setName(int row, int col, float blood)
	{
		if (this.PointName[col][row] != null && this.PointName[col][row].bloodtextID > 0)
		{
			this.NPCBloodValue[col][row] = blood;
			RectTransform component = this.PointName[col][row].NameRectTransform.GetChild(this.PointName[col][row].bloodtextID).GetChild(1).GetComponent<RectTransform>();
			this.NPCBloodSpeed[col][row] = component.sizeDelta.x * 100f / this.maxblood - blood;
			this.NPCBloodSpeed[col][row] *= this.BloodSpeed;
			this.NPCBloodStr[col][row].ClearString();
			this.NPCBloodStr[col][row].FloatToFormat(blood, 2, true);
			this.NPCBloodStr[col][row].AppendFormat("{0}%");
		}
	}

	// Token: 0x06000B27 RID: 2855 RVA: 0x000F1A68 File Offset: 0x000EFC68
	public void setName(int row, int col, short pointid)
	{
		if (this.PointName[col][row] != null)
		{
			if (pointid > -1 && pointid < 2048)
			{
				this.PointName[col][row].pointID = pointid;
				if (this.PointName[col][row].TimeString == null)
				{
					this.PointName[col][row].TimeString = StringManager.Instance.SpawnString(64);
				}
				Text component = this.PointName[col][row].NameRectTransform.GetChild(this.PointName[col][row].bloodtextID).GetChild(3).GetComponent<Text>();
				this.PointName[col][row].TimeString.ClearString();
				uint num;
				if (DataManager.MapDataController.NPCPointTable[(int)this.PointName[col][row].pointID].endTime > (ulong)DataManager.Instance.ServerTime)
				{
					num = (uint)(DataManager.MapDataController.NPCPointTable[(int)this.PointName[col][row].pointID].endTime - (ulong)DataManager.Instance.ServerTime);
				}
				else
				{
					num = 0u;
				}
				GameConstants.GetTimeString(this.PointName[col][row].TimeString, num, false, true, false, false, true);
				component.text = this.PointName[col][row].TimeString.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				if ((ulong)num < (ulong)((long)this.minTime))
				{
					component.color = Color.yellow;
				}
				else
				{
					component.color = Color.white;
				}
			}
			else
			{
				this.PointName[col][row].pointID = -1;
				if (this.PointName[col][row].TimeString != null)
				{
					StringManager.Instance.DeSpawnString(this.PointName[col][row].TimeString);
					this.PointName[col][row].TimeString = null;
				}
			}
		}
	}

	// Token: 0x06000B28 RID: 2856 RVA: 0x000F1C44 File Offset: 0x000EFE44
	public MapTileName pullLineName(CString Name, CString Tag, ELineColor textcolor, Vector2 pos, ushort kingdomID = 0)
	{
		if (Name == null)
		{
			return null;
		}
		if (this.LinePoolsCounter == 0)
		{
			this.LinePoolsCounter = 256;
			for (int i = 0; i < this.LinePoolsCounter; i++)
			{
				if (i < this.LineNamePools.Count)
				{
					this.LineNamePools[i] = new MapTileName(this.BloodNameLayout, this.iniNamePos, this.NameTextSize);
				}
				else
				{
					this.LineNamePools.Add(new MapTileName(this.BloodNameLayout, this.iniNamePos, this.NameTextSize));
				}
			}
		}
		this.LinePoolsCounter--;
		MapTileName mapTileName = this.LineNamePools[this.LinePoolsCounter];
		this.LineNamePools[this.LinePoolsCounter] = null;
		mapTileName.updateName(Name, Tag, MapTileBloodName.lineNameColor[(int)textcolor], pos, kingdomID, null);
		return mapTileName;
	}

	// Token: 0x06000B29 RID: 2857 RVA: 0x000F1D40 File Offset: 0x000EFF40
	public void pushLineName(ref MapTileName Name)
	{
		if (Name != null)
		{
			if (Name.mapEmoji != null)
			{
				GUIManager.Instance.pushEmojiIcon(Name.mapEmoji);
				Name.mapEmoji = null;
			}
			if (Name.mapEmojiBack != null)
			{
				GUIManager.Instance.pushEmojiIcon(Name.mapEmojiBack);
				Name.mapEmojiBack = null;
			}
			if (Name.TimeString != null)
			{
				StringManager.Instance.DeSpawnString(Name.TimeString);
				Name.TimeString = null;
			}
			Name.pointID = -1;
			Name.SetActive(false);
			if (this.LinePoolsCounter < this.LineNamePools.Count)
			{
				this.LineNamePools[this.LinePoolsCounter] = Name;
			}
			else
			{
				this.LineNamePools.Add(Name);
			}
			this.LinePoolsCounter++;
			Name = null;
		}
	}

	// Token: 0x06000B2A RID: 2858 RVA: 0x000F1E20 File Offset: 0x000F0020
	public void updateLineNameColor(MapTileName Name, ELineColor textcolor, CString player = null, CString tag = null)
	{
		if (player == null)
		{
			Name.updateName(MapTileBloodName.lineNameColor[(int)textcolor]);
		}
		else
		{
			Name.updateName(player, tag, MapTileBloodName.lineNameColor[(int)textcolor], 0, null);
		}
	}

	// Token: 0x06000B2B RID: 2859 RVA: 0x000F1E6C File Offset: 0x000F006C
	public void npcTimeRun()
	{
		if (this.WaiteTimer == 0f)
		{
			this.NPCBloodStrAlpha -= Time.deltaTime * this.AlphaSpeed;
			if (this.NPCBloodStrAlpha < 0f)
			{
				this.NPCBloodStrAlpha = 0f;
				this.AlphaSpeed *= -1f;
				this.NPCTimeState += 1;
				this.NPCTimeState &= 1;
				if (this.NPCTimeState == 0)
				{
					for (int i = 0; i < this.PointName.Length; i++)
					{
						for (int j = 0; j < this.PointName[i].Length; j++)
						{
							if (this.PointName[i][j] != null && this.PointName[i][j].bloodtextID > 0)
							{
								RectTransform component = this.PointName[i][j].NameRectTransform.GetChild(this.PointName[i][j].bloodtextID).GetChild(1).GetComponent<RectTransform>();
								if (component.gameObject.activeSelf)
								{
									if (this.NPCBloodValue[i][j] != 0f)
									{
										Vector2 sizeDelta = component.sizeDelta;
										sizeDelta.x -= Time.deltaTime * this.NPCBloodSpeed[i][j];
										float num = sizeDelta.x * 100f / this.maxblood;
										if (num < this.NPCBloodValue[i][j])
										{
											num = this.NPCBloodValue[i][j];
											sizeDelta.x = num * this.maxblood / 100f;
											this.NPCBloodValue[i][j] = 0f;
										}
										component.sizeDelta = sizeDelta;
									}
									Text component2 = this.PointName[i][j].NameRectTransform.GetChild(this.PointName[i][j].bloodtextID).GetChild(3).GetComponent<Text>();
									component2.text = this.NPCBloodStr[i][j].ToString();
									component2.SetAllDirty();
									component2.cachedTextGenerator.Invalidate();
									component2.color = Color.white;
									Color color = component2.color;
									color.a = this.NPCBloodStrAlpha;
									component2.color = color;
								}
							}
						}
					}
				}
				else
				{
					this.NPCTimeStr.ClearString();
					GameConstants.GetTimeString(this.NPCTimeStr, (uint)ActivityManager.Instance.ActivityData[0].EventCountTime, false, true, false, false, true);
					for (int k = 0; k < this.PointName.Length; k++)
					{
						for (int l = 0; l < this.PointName[k].Length; l++)
						{
							if (this.PointName[k][l] != null && this.PointName[k][l].bloodtextID > 0)
							{
								RectTransform component3 = this.PointName[k][l].NameRectTransform.GetChild(this.PointName[k][l].bloodtextID).GetChild(1).GetComponent<RectTransform>();
								if (component3.gameObject.activeSelf)
								{
									if (this.NPCBloodValue[k][l] != 0f)
									{
										Vector2 sizeDelta = component3.sizeDelta;
										sizeDelta.x -= Time.deltaTime * this.NPCBloodSpeed[k][l];
										float num = sizeDelta.x * 100f / this.maxblood;
										if (num < this.NPCBloodValue[k][l])
										{
											sizeDelta.x = this.NPCBloodValue[k][l] * this.maxblood / 100f;
											this.NPCBloodValue[k][l] = 0f;
										}
										component3.sizeDelta = sizeDelta;
									}
									Text component2 = this.PointName[k][l].NameRectTransform.GetChild(this.PointName[k][l].bloodtextID).GetChild(3).GetComponent<Text>();
									if (this.PointName[k][l].pointID > -1 && this.PointName[k][l].pointID < 2048)
									{
										this.PointName[k][l].TimeString.ClearString();
										uint num2;
										if (DataManager.MapDataController.NPCPointTable[(int)this.PointName[k][l].pointID].endTime > (ulong)DataManager.Instance.ServerTime)
										{
											num2 = (uint)(DataManager.MapDataController.NPCPointTable[(int)this.PointName[k][l].pointID].endTime - (ulong)DataManager.Instance.ServerTime);
										}
										else
										{
											num2 = 0u;
										}
										GameConstants.GetTimeString(this.PointName[k][l].TimeString, num2, false, true, false, false, true);
										component2.text = this.PointName[k][l].TimeString.ToString();
										component2.SetAllDirty();
										component2.cachedTextGenerator.Invalidate();
										if ((ulong)num2 < (ulong)((long)this.minTime))
										{
											component2.color = Color.yellow;
										}
										else
										{
											component2.color = Color.white;
										}
									}
									else
									{
										component2.text = this.NPCTimeStr.ToString();
										component2.SetAllDirty();
										component2.cachedTextGenerator.Invalidate();
										if (ActivityManager.Instance.ActivityData[0].EventCountTime < (long)this.minTime)
										{
											component2.color = Color.yellow;
										}
										else
										{
											component2.color = Color.white;
										}
									}
									Color color = component2.color;
									color.a = this.NPCBloodStrAlpha;
									component2.color = color;
								}
							}
						}
					}
				}
			}
			else
			{
				if (this.NPCBloodStrAlpha > 1f)
				{
					this.NPCBloodStrAlpha = 1f;
					this.AlphaSpeed *= -1f;
					this.WaiteTimer = this.maxWaiteTimer;
				}
				if (this.NPCTimeState == 0)
				{
					for (int m = 0; m < this.PointName.Length; m++)
					{
						for (int n = 0; n < this.PointName[m].Length; n++)
						{
							if (this.PointName[m][n] != null && this.PointName[m][n].bloodtextID > 0)
							{
								RectTransform component4 = this.PointName[m][n].NameRectTransform.GetChild(this.PointName[m][n].bloodtextID).GetChild(1).GetComponent<RectTransform>();
								if (component4.gameObject.activeSelf)
								{
									if (this.NPCBloodValue[m][n] != 0f)
									{
										Vector2 sizeDelta = component4.sizeDelta;
										sizeDelta.x -= Time.deltaTime * this.NPCBloodSpeed[m][n];
										float num = sizeDelta.x * 100f / this.maxblood;
										if (num < this.NPCBloodValue[m][n])
										{
											sizeDelta.x = this.NPCBloodValue[m][n] * this.maxblood / 100f;
											this.NPCBloodValue[m][n] = 0f;
										}
										component4.sizeDelta = sizeDelta;
									}
									Text component2 = this.PointName[m][n].NameRectTransform.GetChild(this.PointName[m][n].bloodtextID).GetChild(3).GetComponent<Text>();
									Color color = component2.color;
									color.a = this.NPCBloodStrAlpha;
									component2.color = color;
								}
							}
						}
					}
				}
				else
				{
					this.ChekTimer += Time.deltaTime;
					if (this.ChekTimer >= 1f)
					{
						this.ChekTimer = 0f;
						this.NPCTimeStr.ClearString();
						GameConstants.GetTimeString(this.NPCTimeStr, (uint)ActivityManager.Instance.ActivityData[0].EventCountTime, false, true, false, false, true);
					}
					for (int num3 = 0; num3 < this.PointName.Length; num3++)
					{
						for (int num4 = 0; num4 < this.PointName[num3].Length; num4++)
						{
							if (this.PointName[num3][num4] != null && this.PointName[num3][num4].bloodtextID > 0)
							{
								RectTransform component5 = this.PointName[num3][num4].NameRectTransform.GetChild(this.PointName[num3][num4].bloodtextID).GetChild(1).GetComponent<RectTransform>();
								if (component5.gameObject.activeSelf)
								{
									if (this.NPCBloodValue[num3][num4] != 0f)
									{
										Vector2 sizeDelta = component5.sizeDelta;
										sizeDelta.x -= Time.deltaTime * this.NPCBloodSpeed[num3][num4];
										float num = sizeDelta.x * 100f / this.maxblood;
										if (num < this.NPCBloodValue[num3][num4])
										{
											sizeDelta.x = this.NPCBloodValue[num3][num4] * this.maxblood / 100f;
											this.NPCBloodValue[num3][num4] = 0f;
										}
										component5.sizeDelta = sizeDelta;
									}
									Text component2 = this.PointName[num3][num4].NameRectTransform.GetChild(this.PointName[num3][num4].bloodtextID).GetChild(3).GetComponent<Text>();
									if (this.ChekTimer == 0f)
									{
										if (this.PointName[num3][num4].pointID > -1 && this.PointName[num3][num4].pointID < 2048)
										{
											this.PointName[num3][num4].TimeString.ClearString();
											uint num2;
											if (DataManager.MapDataController.NPCPointTable[(int)this.PointName[num3][num4].pointID].endTime > (ulong)DataManager.Instance.ServerTime)
											{
												num2 = (uint)(DataManager.MapDataController.NPCPointTable[(int)this.PointName[num3][num4].pointID].endTime - (ulong)DataManager.Instance.ServerTime);
											}
											else
											{
												num2 = 0u;
											}
											GameConstants.GetTimeString(this.PointName[num3][num4].TimeString, num2, false, true, false, false, true);
											component2.text = this.PointName[num3][num4].TimeString.ToString();
										}
										else
										{
											component2.text = this.NPCTimeStr.ToString();
										}
										component2.SetAllDirty();
										component2.cachedTextGenerator.Invalidate();
									}
									Color color = component2.color;
									color.a = this.NPCBloodStrAlpha;
									component2.color = color;
								}
							}
						}
					}
				}
			}
		}
		else
		{
			this.WaiteTimer -= Time.deltaTime;
			if (this.WaiteTimer < 0f)
			{
				this.WaiteTimer = 0f;
			}
			if (this.NPCTimeState != 0)
			{
				this.ChekTimer += Time.deltaTime;
				if (this.ChekTimer >= 1f)
				{
					this.ChekTimer = 0f;
					this.NPCTimeStr.ClearString();
					GameConstants.GetTimeString(this.NPCTimeStr, (uint)ActivityManager.Instance.ActivityData[0].EventCountTime, false, true, false, false, true);
				}
			}
			for (int num5 = 0; num5 < this.PointName.Length; num5++)
			{
				for (int num6 = 0; num6 < this.PointName[num5].Length; num6++)
				{
					if (this.PointName[num5][num6] != null && this.PointName[num5][num6].bloodtextID > 0)
					{
						RectTransform component6 = this.PointName[num5][num6].NameRectTransform.GetChild(this.PointName[num5][num6].bloodtextID).GetChild(1).GetComponent<RectTransform>();
						if (component6.gameObject.activeSelf && this.NPCBloodValue[num5][num6] != 0f)
						{
							Vector2 sizeDelta = component6.sizeDelta;
							sizeDelta.x -= Time.deltaTime * this.NPCBloodSpeed[num5][num6];
							float num = sizeDelta.x * 100f / this.maxblood;
							if (num < this.NPCBloodValue[num5][num6])
							{
								sizeDelta.x = this.NPCBloodValue[num5][num6] * this.maxblood / 100f;
								this.NPCBloodValue[num5][num6] = 0f;
							}
							component6.sizeDelta = sizeDelta;
						}
						if (this.NPCTimeState != 0 && this.ChekTimer == 0f)
						{
							Text component2 = this.PointName[num5][num6].NameRectTransform.GetChild(this.PointName[num5][num6].bloodtextID).GetChild(3).GetComponent<Text>();
							if (this.PointName[num5][num6].pointID > -1 && this.PointName[num5][num6].pointID < 2048)
							{
								this.PointName[num5][num6].TimeString.ClearString();
								uint num2;
								if (DataManager.MapDataController.NPCPointTable[(int)this.PointName[num5][num6].pointID].endTime > (ulong)DataManager.Instance.ServerTime)
								{
									num2 = (uint)(DataManager.MapDataController.NPCPointTable[(int)this.PointName[num5][num6].pointID].endTime - (ulong)DataManager.Instance.ServerTime);
								}
								else
								{
									num2 = 0u;
								}
								GameConstants.GetTimeString(this.PointName[num5][num6].TimeString, num2, false, true, false, false, true);
								component2.text = this.PointName[num5][num6].TimeString.ToString();
							}
							else
							{
								component2.text = this.NPCTimeStr.ToString();
							}
							component2.SetAllDirty();
							component2.cachedTextGenerator.Invalidate();
						}
					}
				}
			}
		}
	}

	// Token: 0x06000B2C RID: 2860 RVA: 0x000F2C5C File Offset: 0x000F0E5C
	public void MapTileNameRebuilt()
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

	// Token: 0x06000B2D RID: 2861 RVA: 0x000F2CD4 File Offset: 0x000F0ED4
	private float checkNpdBlood(float booldvalue)
	{
		if (booldvalue > 0f && booldvalue < 0.01f)
		{
			booldvalue = 0.012f;
		}
		return booldvalue;
	}

	// Token: 0x040024C1 RID: 9409
	private const int npcnamemax = 128;

	// Token: 0x040024C2 RID: 9410
	private const int npccitynamemax = 128;

	// Token: 0x040024C3 RID: 9411
	public static Color[] lineNameColor = new Color[]
	{
		new Color(0f, 1f, 1f),
		new Color(1f, 0.6862745f, 0f),
		new Color(1f, 0f, 0.117647f),
		new Color(0.0784313f, 0.764706f, 1f)
	};

	// Token: 0x040024C4 RID: 9412
	public Transform BloodNameLayout;

	// Token: 0x040024C5 RID: 9413
	private Texture2D NameTex;

	// Token: 0x040024C6 RID: 9414
	private Sprite NameSprite;

	// Token: 0x040024C7 RID: 9415
	private Vector2 NameImageSize = new Vector2(0f, 34f);

	// Token: 0x040024C8 RID: 9416
	private Vector2 NameTextSize = new Vector2(256f, 34f);

	// Token: 0x040024C9 RID: 9417
	private Vector2 NameTextOffset = new Vector2(0f, -33.5f);

	// Token: 0x040024CA RID: 9418
	private Vector3 iniNamePos = new Vector3(0f, 1024f, 0f);

	// Token: 0x040024CB RID: 9419
	private MapTileName[][] PointName;

	// Token: 0x040024CC RID: 9420
	private MapTileName[][] PointNamePools;

	// Token: 0x040024CD RID: 9421
	private int[] PointPoolCounter;

	// Token: 0x040024CE RID: 9422
	private int PointPoolsCounter;

	// Token: 0x040024CF RID: 9423
	private List<MapTileName> LineNamePools = new List<MapTileName>(256);

	// Token: 0x040024D0 RID: 9424
	private int LinePoolsCounter = 256;

	// Token: 0x040024D1 RID: 9425
	private Transform NPCBloodLayout;

	// Token: 0x040024D2 RID: 9426
	private CString npcname = new CString(128);

	// Token: 0x040024D3 RID: 9427
	private CString npccityname = new CString(128);

	// Token: 0x040024D4 RID: 9428
	private AssetBundle NPCBloodAB;

	// Token: 0x040024D5 RID: 9429
	private int NPCBloodABKey;

	// Token: 0x040024D6 RID: 9430
	private Transform[][] NPCBloodPools;

	// Token: 0x040024D7 RID: 9431
	private int[] NPCBloodPoolCounter;

	// Token: 0x040024D8 RID: 9432
	private int NPCBloodPoolsCounter;

	// Token: 0x040024D9 RID: 9433
	private float[][] NPCBloodValue;

	// Token: 0x040024DA RID: 9434
	private float[][] NPCBloodSpeed;

	// Token: 0x040024DB RID: 9435
	private float NPCBloodScale = 1.5f;

	// Token: 0x040024DC RID: 9436
	private Vector3 NPCBloodpos = new Vector3(-11f, -23f, 0f);

	// Token: 0x040024DD RID: 9437
	private byte NPCTimeState;

	// Token: 0x040024DE RID: 9438
	private CString[] NPCLevelStr;

	// Token: 0x040024DF RID: 9439
	private CString NPCTimeStr = new CString(64);

	// Token: 0x040024E0 RID: 9440
	private CString[][] NPCBloodStr;

	// Token: 0x040024E1 RID: 9441
	private float NPCBloodStrAlpha = 1f;

	// Token: 0x040024E2 RID: 9442
	private int maxlevel = 8;

	// Token: 0x040024E3 RID: 9443
	private float AlphaSpeed = 4f;

	// Token: 0x040024E4 RID: 9444
	private float maxblood = 86f;

	// Token: 0x040024E5 RID: 9445
	private float BloodSpeed = 2f;

	// Token: 0x040024E6 RID: 9446
	private float maxWaiteTimer = 2f;

	// Token: 0x040024E7 RID: 9447
	private float WaiteTimer;

	// Token: 0x040024E8 RID: 9448
	private float ChekTimer;

	// Token: 0x040024E9 RID: 9449
	private float NPCNameOffSet = -14f;

	// Token: 0x040024EA RID: 9450
	private float NPCTimeStrXOffSet = 10f;

	// Token: 0x040024EB RID: 9451
	private int minTime = 600;

	// Token: 0x040024EC RID: 9452
	private Material MapEmojiImageMaterial;
}
