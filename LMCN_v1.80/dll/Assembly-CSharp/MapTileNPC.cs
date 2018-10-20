using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200026E RID: 622
public class MapTileNPC
{
	// Token: 0x06000B85 RID: 2949 RVA: 0x0010B7F8 File Offset: 0x001099F8
	public MapTileNPC(Transform realmGroup)
	{
		this.npcposyoffset = new float[5];
		Array.Clear(this.npcposyoffset, 0, 5);
		this.npcposxoffset = new float[5];
		Array.Clear(this.npcposxoffset, 0, 5);
		this.NPCSprite = new Sprite[5][][];
		for (int i = 0; i < this.NPCSprite.Length; i++)
		{
			this.NPCSprite[i] = new Sprite[3][];
			for (int j = 0; j < 3; j++)
			{
				this.NPCSprite[i][j] = null;
			}
		}
		this.HitFrame = new byte[5];
		Array.Clear(this.HitFrame, 0, 5);
		this.NPCMaterial = new Material[5];
		Array.Clear(this.NPCMaterial, 0, 5);
		this.NPCNum = new ushort[5];
		Array.Clear(this.NPCNum, 0, 5);
		this.NPCPools = new NPC[5][][];
		Array.Clear(this.NPCPools, 0, 5);
		this.poolCounter = new int[5][];
		Array.Clear(this.poolCounter, 0, 5);
		this.poolsCounter = new int[5];
		Array.Clear(this.poolsCounter, 0, 5);
		this.NPCABKey = new int[5];
		Array.Clear(this.NPCABKey, 0, 5);
		this.NPCKindCount = 0;
		GameObject gameObject = new GameObject("MapTileNPC");
		this.NPCLayout = gameObject.transform;
		this.NPCLayout.localScale = Vector3.one * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
		this.NPCLayout.position = Vector3.forward * 3200f * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
		this.NPCLayout.SetParent(realmGroup, false);
		gameObject = new GameObject("MapTileNPCAB");
		this.NPCABLayout = gameObject.transform;
		this.NPCABLayout.position = Vector3.zero;
		this.NPCABLayout.SetParent(this.NPCLayout, false);
		gameObject = new GameObject("MapTileNPCDamage");
		this.DamageLayout = gameObject.transform;
		this.DamageLayout.position = Vector3.zero;
		this.DamageLayout.SetParent(this.NPCLayout, false);
		this.npcfighters = new List<NPCFighter>(16);
		this.delnpc = new List<NPC>(16);
	}

	// Token: 0x06000B86 RID: 2950 RVA: 0x0010BA48 File Offset: 0x00109C48
	public void pushDamage(Damage damageText)
	{
		if (damageText != null)
		{
			for (int i = 0; i < this.DamagePoolsCounter; i++)
			{
				if (this.DamagePoolCounter[i] < this.DamagePools[i].Length)
				{
					this.DamagePools[i][this.DamagePoolCounter[i]] = damageText;
					this.DamagePoolCounter[i]++;
					damageText.SetActive(false);
					break;
				}
			}
		}
	}

	// Token: 0x06000B87 RID: 2951 RVA: 0x0010BAB8 File Offset: 0x00109CB8
	public Damage pullDamage()
	{
		Damage result = null;
		int i;
		for (i = 0; i < this.DamagePoolsCounter; i++)
		{
			if (this.DamagePoolCounter[i] > 0)
			{
				this.DamagePoolCounter[i]--;
				result = this.DamagePools[i][this.DamagePoolCounter[i]];
				this.DamagePools[i][this.DamagePoolCounter[i]] = null;
				break;
			}
		}
		if (i == this.DamagePoolsCounter)
		{
			this.DamagePools[i] = new Damage[this.DamagePools[0].Length];
			for (int j = 0; j < this.DamagePools[i].Length; j++)
			{
				this.DamagePools[i][j] = new Damage(this.DamageLayout, this.DamageFont);
			}
			this.DamagePoolsCounter++;
			this.DamagePoolCounter[i] = this.DamagePools[i].Length;
			this.DamagePoolCounter[i]--;
			result = this.DamagePools[i][this.DamagePoolCounter[i]];
			this.DamagePools[i][this.DamagePoolCounter[i]] = null;
		}
		return result;
	}

	// Token: 0x06000B88 RID: 2952 RVA: 0x0010BBD8 File Offset: 0x00109DD8
	public void OnDestroy()
	{
		this.mapTileController = null;
		if (this.npcfighters != null)
		{
			this.npcfighters.Clear();
			this.npcfighters = null;
		}
		this.DamageFont = null;
		this.NPCABLayout = null;
		if (this.NPCs != null)
		{
			for (int i = 0; i < this.NPCs.Length; i++)
			{
				for (int j = 0; j < this.NPCs[i].Length; j++)
				{
					if (this.NPCs[i][j] != null)
					{
						this.NPCs[i][j].Release();
					}
				}
				Array.Clear(this.NPCs[i], 0, this.NPCs[i].Length);
				this.NPCs[i] = null;
			}
		}
		if (this.NPCPools != null)
		{
			for (int k = 0; k < this.NPCPools.Length; k++)
			{
				if (this.NPCPools[k] != null)
				{
					for (int l = 0; l < this.NPCPools[k].Length; l++)
					{
						if (this.NPCPools[k][l] != null)
						{
							for (int m = 0; m < this.NPCPools[k][l].Length; m++)
							{
								if (this.NPCPools[k][l][m] != null)
								{
									this.NPCPools[k][l][m].Release();
								}
								this.NPCPools[k][l][m] = null;
							}
						}
						this.NPCPools[k][l] = null;
					}
				}
				this.NPCPools[k] = null;
			}
		}
		if (this.NPCSprite != null)
		{
			for (int n = 0; n < this.NPCSprite.Length; n++)
			{
				if (this.NPCSprite[n] != null)
				{
					for (int num = 0; num < this.NPCSprite[n].Length; num++)
					{
						if (this.NPCSprite[n][num] != null)
						{
							Array.Clear(this.NPCSprite[n][num], 0, this.NPCSprite[n][num].Length);
						}
						this.NPCSprite[n][num] = null;
					}
				}
				this.NPCSprite[n] = null;
			}
		}
		if (this.NPCMaterial != null)
		{
			Array.Clear(this.NPCMaterial, 0, this.NPCMaterial.Length);
			this.NPCMaterial = null;
		}
		if (this.NPCNum != null)
		{
			Array.Clear(this.NPCNum, 0, this.NPCNum.Length);
			this.NPCNum = null;
		}
		if (this.poolCounter != null)
		{
			for (int num2 = 0; num2 < this.poolCounter.Length; num2++)
			{
				if (this.poolCounter[num2] != null)
				{
					Array.Clear(this.poolCounter[num2], 0, this.poolCounter[num2].Length);
				}
				this.poolCounter[num2] = null;
			}
			this.poolCounter = null;
		}
		if (this.poolsCounter != null)
		{
			Array.Clear(this.poolsCounter, 0, this.poolsCounter.Length);
			this.poolsCounter = null;
		}
		if (this.NPCABKey != null)
		{
			for (int num3 = 0; num3 < this.NPCABKey.Length; num3++)
			{
				if (this.NPCABKey[num3] != 0)
				{
					AssetManager.UnloadAssetBundle(this.NPCABKey[num3], true);
				}
			}
			this.NPCABKey = null;
		}
		if (this.DamagePools != null)
		{
			for (int num4 = 0; num4 < this.DamagePools.Length; num4++)
			{
				if (this.DamagePools[num4] != null)
				{
					for (int num5 = 0; num5 < this.DamagePools[num4].Length; num5++)
					{
						if (this.DamagePools[num4][num5] != null)
						{
							this.DamagePools[num4][num5].Release();
						}
					}
					Array.Clear(this.DamagePools[num4], 0, this.DamagePools[num4].Length);
					this.DamagePools[num4] = null;
				}
			}
			this.DamagePools = null;
		}
		if (this.DamagePoolCounter != null)
		{
			Array.Clear(this.DamagePoolCounter, 0, this.DamagePoolCounter.Length);
			this.DamagePoolCounter = null;
		}
		if (this.npcposyoffset != null)
		{
			Array.Clear(this.npcposyoffset, 0, this.npcposyoffset.Length);
			this.npcposyoffset = null;
		}
		if (this.npcposxoffset != null)
		{
			Array.Clear(this.npcposxoffset, 0, this.npcposxoffset.Length);
			this.npcposxoffset = null;
		}
		this.DamageLayout = null;
		this.NPCLayout = null;
	}

	// Token: 0x06000B89 RID: 2953 RVA: 0x0010C038 File Offset: 0x0010A238
	public void IniNPC(int rowNum, int colNum, float nowscale, float canvasScale, MapTile mapTile)
	{
		this.mapTileController = mapTile;
		this.NPCs = new NPC[colNum][];
		for (int i = 0; i < colNum; i++)
		{
			this.NPCs[i] = new NPC[rowNum];
			Array.Clear(this.NPCs[i], 0, this.NPCs[i].Length);
		}
		this.npcscale = nowscale * 1.29032f;
		this.DamageFont = GUIManager.Instance.pDVMgr.DamageValueFont;
		this.DamagePools = new Damage[rowNum][];
		this.DamagePoolCounter = new int[rowNum];
		Array.Clear(this.DamagePools, 0, this.DamagePools.Length);
		for (int j = 0; j < this.DamagePoolCounter.Length; j++)
		{
			this.DamagePoolCounter[j] = -1;
		}
		this.DamagePools[0] = new Damage[colNum * 3];
		for (int k = 0; k < this.DamagePools[0].Length; k++)
		{
			this.DamagePools[0][k] = new Damage(this.DamageLayout, this.DamageFont);
		}
		this.DamagePoolCounter[0] = this.DamagePools[0].Length;
		this.DamagePoolsCounter = 1;
	}

	// Token: 0x06000B8A RID: 2954 RVA: 0x0010C160 File Offset: 0x0010A360
	public void setNPC(ushort npcNum, uint npcTableID, int row, int col, Vector2 pos)
	{
		if (npcNum < 2)
		{
			if (this.NPCs[col][row] != null)
			{
				this.pushNPC(row, col);
			}
		}
		else
		{
			if (this.NPCs[col][row] != null && ((int)this.NPCs[col][row].NPCKindID >= this.NPCNum.Length || this.NPCNum[(int)this.NPCs[col][row].NPCKindID] != npcNum))
			{
				this.pushNPC(row, col);
			}
			if (this.NPCs[col][row] == null)
			{
				int num = 0;
				int i = 0;
				while (i < (int)this.NPCKindCount)
				{
					num %= this.NPCNum.Length;
					if (this.NPCNum[num] == npcNum)
					{
						break;
					}
					i++;
					num++;
				}
				if (i == (int)this.NPCKindCount)
				{
					num %= this.NPCNum.Length;
					this.NPCNum[num] = npcNum;
					MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(npcNum);
					CString cstring = StringManager.Instance.SpawnString(30);
					cstring.ClearString();
					cstring.IntToFormat((long)recordByKey.MapNPCNO, 3, false);
					cstring.AppendFormat("UI/NPC_{0}");
					AssetBundle assetBundle = (!AssetManager.GetAssetBundleDownload(cstring, AssetPath.UI, AssetType.NPC, recordByKey.MapNPCNO, true)) ? null : AssetManager.GetAssetBundle(cstring, out this.NPCABKey[num]);
					StringManager.Instance.DeSpawnString(cstring);
					if (assetBundle == null)
					{
						return;
					}
					this.NPCKindCount += 1;
					GameObject gameObject = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
					gameObject.SetActive(false);
					Transform transform = gameObject.transform;
					UISpritesArray component = transform.GetChild(0).GetComponent<UISpritesArray>();
					UISpritesArray component2 = transform.GetChild(1).GetComponent<UISpritesArray>();
					UISpritesArray component3 = transform.GetChild(2).GetComponent<UISpritesArray>();
					transform.SetParent(this.NPCABLayout, false);
					this.NPCSprite[num][0] = component.m_Sprites;
					this.NPCSprite[num][1] = component2.m_Sprites;
					this.NPCSprite[num][2] = component3.m_Sprites;
					this.HitFrame[num] = recordByKey.HitFrame;
					this.NPCMaterial[num] = component.m_Image.material;
					this.NPCMaterial[num].renderQueue = 2600;
					Vector3 vector = GameConstants.WordToVector3(recordByKey.Xoffset, recordByKey.Yoffset, 0, -100, 0.01f);
					this.npcposxoffset[num] = vector.x * 1.29032f / this.npcscale;
					this.npcposyoffset[num] = vector.y * 4f * 1.29032f / this.npcscale;
					if ((int)this.NPCKindCount <= this.NPCNum.Length)
					{
						this.poolsCounter[num] = 1;
						this.poolCounter[num] = new int[64];
						this.poolCounter[num][0] = 4;
						this.NPCPools[num] = new NPC[64][];
						this.NPCPools[num][0] = new NPC[this.poolCounter[num][0]];
						for (int j = 0; j < this.poolCounter[num][0]; j++)
						{
							this.NPCPools[num][0][j] = new NPC(pos, (byte)num, NPCState.NPC_Idle, this);
						}
					}
					else
					{
						for (int k = 0; k < this.poolsCounter[num]; k++)
						{
							for (int l = 0; l < this.poolCounter[num][k]; l++)
							{
								this.NPCPools[num][k][l].NPCSpriteRenderer.material = this.NPCMaterial[num];
							}
						}
					}
				}
				int m;
				for (m = 0; m < this.poolsCounter[num]; m++)
				{
					if (this.poolCounter[num][m] > 0)
					{
						this.poolCounter[num][m]--;
						this.NPCs[col][row] = this.NPCPools[num][m][this.poolCounter[num][m]];
						this.NPCPools[num][m][this.poolCounter[num][m]] = null;
						break;
					}
				}
				if (m == this.poolsCounter[num])
				{
					this.NPCPools[num][m] = new NPC[this.NPCPools[num][0].Length];
					for (int n = 0; n < this.NPCPools[num][m].Length; n++)
					{
						this.NPCPools[num][m][n] = new NPC(pos, (byte)num, NPCState.NPC_Idle, this);
					}
					this.poolsCounter[num]++;
					this.poolCounter[num][m] = this.NPCPools[num][m].Length;
					this.poolCounter[num][m]--;
					this.NPCs[col][row] = this.NPCPools[num][m][this.poolCounter[num][m]];
					this.NPCPools[num][m][this.poolCounter[num][m]] = null;
				}
				this.NPCs[col][row].SetActive(true);
				int num2 = 0;
				int num3 = 0;
				for (m = 0; m < this.npcfighters.Count; m++)
				{
					this.mapTileController.MapIDtoMapTileRowCol(this.npcfighters[m].mapID, ref num2, ref num3);
					if (num2 == row && col == num3)
					{
						this.setNPC(row, col, this.npcfighters[m].linefighter, this.npcfighters[m].mapID);
						this.npcfighters.RemoveAt(m);
						break;
					}
				}
			}
			this.setNPC(row, col, pos, npcTableID);
		}
	}

	// Token: 0x06000B8B RID: 2955 RVA: 0x0010C720 File Offset: 0x0010A920
	public void setNPC(int row, int col, Vector2 pos, uint tableid)
	{
		if (this.NPCs[col][row] != null)
		{
			this.NPCs[col][row].updateNPC(tableid, (byte)row, (byte)col);
			this.NPCs[col][row].updateNPC(pos * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale * DataManager.MapDataController.zoomSize);
		}
	}

	// Token: 0x06000B8C RID: 2956 RVA: 0x0010C780 File Offset: 0x0010A980
	public void setNPC(int row, int col, Vector2 pos)
	{
		if (this.NPCs[col][row] != null)
		{
			this.NPCs[col][row].updateNPC(pos * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale * DataManager.MapDataController.zoomSize);
		}
	}

	// Token: 0x06000B8D RID: 2957 RVA: 0x0010C7C0 File Offset: 0x0010A9C0
	public void setNPC(int row, int col, NPCState npcState)
	{
		if (row > -1 && col > -1 && this.NPCs[col][row] != null)
		{
			if (npcState != NPCState.NPC_Hit)
			{
				if (npcState != NPCState.NPC_Hurt)
				{
					this.NPCs[col][row].updateNPC(npcState);
				}
				else
				{
					this.NPCs[col][row].Hurt();
				}
			}
			else
			{
				this.NPCs[col][row].HIT();
			}
		}
	}

	// Token: 0x06000B8E RID: 2958 RVA: 0x0010C83C File Offset: 0x0010AA3C
	public void setNPC(int row, int col, float hurt, uint mapID)
	{
		if (this.NPCs[col][row] == null)
		{
			this.mapTileController.CheckMapNPCBlood(mapID, hurt);
		}
		else
		{
			this.NPCs[col][row].updateNPC(hurt);
		}
	}

	// Token: 0x06000B8F RID: 2959 RVA: 0x0010C87C File Offset: 0x0010AA7C
	public void setNPC(int row, int col, LineNode linenode, uint mapID)
	{
		if (row > -1 && row > -1 && this.NPCs[col][row] != null)
		{
			this.NPCs[col][row].updateNPC(linenode);
		}
		else
		{
			NPCFighter item;
			item.mapID = mapID;
			item.linefighter = linenode;
			this.npcfighters.Add(item);
		}
	}

	// Token: 0x06000B90 RID: 2960 RVA: 0x0010C8D8 File Offset: 0x0010AAD8
	public void setNPC(int row, int col, int lineTableID)
	{
		if (row > -1 && col > -1 && this.NPCs[col][row] != null)
		{
			for (int i = 0; i < this.NPCs[col][row].fighters.Count; i++)
			{
				if (this.NPCs[col][row].fighters[i].lineTableID == lineTableID)
				{
					this.NPCs[col][row].fighters.RemoveAt(i);
					return;
				}
			}
		}
		else
		{
			for (int j = 0; j < this.npcfighters.Count; j++)
			{
				if (this.npcfighters[j].linefighter.lineTableID == lineTableID)
				{
					this.npcfighters.RemoveAt(j);
					return;
				}
			}
		}
	}

	// Token: 0x06000B91 RID: 2961 RVA: 0x0010C9AC File Offset: 0x0010ABAC
	public void setNPC(int row, int col)
	{
		if (row > -1 && col > -1 && this.NPCs[col][row] != null)
		{
			this.NPCs[col][row].updateNPC();
		}
	}

	// Token: 0x06000B92 RID: 2962 RVA: 0x0010C9E8 File Offset: 0x0010ABE8
	public void pushNPC(int row, int col)
	{
		if (this.NPCs[col][row] == this.kickNPC)
		{
			this.kickNPC = null;
		}
		this.NPCs[col][row].SetActive(false);
		int npckindID = (int)this.NPCs[col][row].NPCKindID;
		for (int i = 0; i < this.poolsCounter[npckindID]; i++)
		{
			if (this.poolCounter[npckindID][i] < this.NPCPools[npckindID][i].Length)
			{
				if (this.NPCs[col][row].NPCTid < 2048)
				{
					this.NPCs[col][row].releaseNPC();
				}
				this.NPCPools[npckindID][i][this.poolCounter[npckindID][i]] = this.NPCs[col][row];
				this.NPCs[col][row] = null;
				this.poolCounter[npckindID][i]++;
				break;
			}
		}
	}

	// Token: 0x06000B93 RID: 2963 RVA: 0x0010CAD0 File Offset: 0x0010ACD0
	public void pushDelNPC(int row, int col)
	{
		if (this.NPCs[col][row] != null)
		{
			this.NPCs[col][row].DieTimer = 8f;
			if (this.NPCs[col][row].NPCTableID < 262144u)
			{
				this.NPCs[col][row].NPCTid = DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCs[col][row].NPCTableID)].tableID;
				if (DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCs[col][row].NPCTableID)].pointKind == 10)
				{
					DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCs[col][row].NPCTableID)].pointKind = 0;
				}
				this.NPCs[col][row].NPCTableID = 262144u;
			}
		}
	}

	// Token: 0x06000B94 RID: 2964 RVA: 0x0010CBB0 File Offset: 0x0010ADB0
	public void checkNPC(int row, int col)
	{
		if (this.NPCs[col][row] == null)
		{
			DataManager.msgBuffer[0] = 90;
			DataManager.msgBuffer[1] = (byte)row;
			DataManager.msgBuffer[2] = (byte)col;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
		else if (this.NPCs[col][row].NPCTableID < 262144u || this.NPCs[col][row].NPCTid >= 2048)
		{
			this.NPCs[col][row].releaseNPC();
			DataManager.msgBuffer[0] = 90;
			DataManager.msgBuffer[1] = (byte)row;
			DataManager.msgBuffer[2] = (byte)col;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x06000B95 RID: 2965 RVA: 0x0010CC60 File Offset: 0x0010AE60
	public void Run()
	{
		for (int i = 0; i < this.NPCs.Length; i++)
		{
			for (int j = 0; j < this.NPCs[i].Length; j++)
			{
				if (this.NPCs[i][j] != null)
				{
					this.NPCs[i][j].Run();
				}
			}
		}
	}

	// Token: 0x06000B96 RID: 2966 RVA: 0x0010CCC0 File Offset: 0x0010AEC0
	public sbyte getNPCDir(int row, int col)
	{
		return (this.NPCs[col][row] == null) ? 1 : this.NPCs[col][row].NPCDir;
	}

	// Token: 0x06000B97 RID: 2967 RVA: 0x0010CCF4 File Offset: 0x0010AEF4
	public float getNPCLastBlood(int row, int col)
	{
		if (this.NPCs[col][row] == null)
		{
			return -1f;
		}
		if (this.NPCs[col][row].hurt.Count <= 0)
		{
			this.NPCs[col][row].releaseNPC();
			return -1f;
		}
		if (this.NPCs[col][row].hurt[this.NPCs[col][row].hurt.Count - 1] != 0f)
		{
			this.NPCs[col][row].releaseNPC();
			return -1f;
		}
		return this.NPCs[col][row].hurt[this.NPCs[col][row].hurt.Count - 1];
	}

	// Token: 0x04002700 RID: 9984
	public const float AnimationSpeed = 15f;

	// Token: 0x04002701 RID: 9985
	public const float HitSpeed = 5f;

	// Token: 0x04002702 RID: 9986
	public const float DieSpeed = 5f;

	// Token: 0x04002703 RID: 9987
	public const float HurtTimer = 0.2f;

	// Token: 0x04002704 RID: 9988
	public const float HitTimer = 0.2f;

	// Token: 0x04002705 RID: 9989
	public const float DieTimer = 1f;

	// Token: 0x04002706 RID: 9990
	public const float ReadyDieTimer = 8f;

	// Token: 0x04002707 RID: 9991
	public const float PerlinNoiseScale = 9f;

	// Token: 0x04002708 RID: 9992
	public const float damagexoffset = 1f;

	// Token: 0x04002709 RID: 9993
	public const float damageyoffset = 0f;

	// Token: 0x0400270A RID: 9994
	public const float DamageScaleSpeed = 25f;

	// Token: 0x0400270B RID: 9995
	public const float DamageAlphaSpeed = 0.8333333f;

	// Token: 0x0400270C RID: 9996
	public const float DamageYoffsetSpeed = 0.25f;

	// Token: 0x0400270D RID: 9997
	public const float Spritenpcscale = 1.29032f;

	// Token: 0x0400270E RID: 9998
	public const float maxDamageScale = 10f;

	// Token: 0x0400270F RID: 9999
	public const float npcposz = 37f;

	// Token: 0x04002710 RID: 10000
	public MapTile mapTileController;

	// Token: 0x04002711 RID: 10001
	public Transform NPCLayout;

	// Token: 0x04002712 RID: 10002
	public Transform DamageLayout;

	// Token: 0x04002713 RID: 10003
	public float[] npcposyoffset;

	// Token: 0x04002714 RID: 10004
	public float[] npcposxoffset;

	// Token: 0x04002715 RID: 10005
	public Material[] NPCMaterial;

	// Token: 0x04002716 RID: 10006
	public byte[] HitFrame;

	// Token: 0x04002717 RID: 10007
	public float npcscale = 1f;

	// Token: 0x04002718 RID: 10008
	public Sprite[][][] NPCSprite;

	// Token: 0x04002719 RID: 10009
	public List<NPCFighter> npcfighters;

	// Token: 0x0400271A RID: 10010
	public NPC kickNPC;

	// Token: 0x0400271B RID: 10011
	private Transform NPCABLayout;

	// Token: 0x0400271C RID: 10012
	private NPC[][] NPCs;

	// Token: 0x0400271D RID: 10013
	private ushort[] NPCNum;

	// Token: 0x0400271E RID: 10014
	private byte NPCKindCount;

	// Token: 0x0400271F RID: 10015
	private NPC[][][] NPCPools;

	// Token: 0x04002720 RID: 10016
	private int[][] poolCounter;

	// Token: 0x04002721 RID: 10017
	private int[] poolsCounter;

	// Token: 0x04002722 RID: 10018
	private int[] NPCABKey;

	// Token: 0x04002723 RID: 10019
	private List<NPC> delnpc;

	// Token: 0x04002724 RID: 10020
	private Font DamageFont;

	// Token: 0x04002725 RID: 10021
	private Damage[][] DamagePools;

	// Token: 0x04002726 RID: 10022
	private int[] DamagePoolCounter;

	// Token: 0x04002727 RID: 10023
	private int DamagePoolsCounter;
}
