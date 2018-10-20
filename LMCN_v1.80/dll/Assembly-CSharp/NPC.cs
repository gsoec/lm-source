using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200026F RID: 623
public class NPC
{
	// Token: 0x06000B98 RID: 2968 RVA: 0x0010CDB8 File Offset: 0x0010AFB8
	public NPC(Vector2 inipos, byte npcKindID, NPCState npcState, MapTileNPC npcControl)
	{
		this.NPCControl = npcControl;
		this.NPCGameObject = new GameObject("npc");
		this.NPCTransform = this.NPCGameObject.transform;
		this.NPCSpriteRenderer = this.NPCGameObject.AddComponent<SpriteRenderer>();
		this.NPCSpriteRenderer.material = npcControl.NPCMaterial[(int)npcKindID];
		this.NPCTransform.localScale = Vector3.one * npcControl.npcscale;
		this.NPCTransform.SetParent(npcControl.NPCLayout, false);
		this.NPCKindID = npcKindID;
		this.NPCAnimation = npcControl.NPCSprite[(int)npcKindID];
		this.CurNPCState = ((npcState < NPCState.NPC_Hit) ? npcState : NPCState.NPC_Attack);
		this.IdelNPCState = NPCState.NPC_Idle;
		this.HitFrame = npcControl.HitFrame[(int)npcKindID];
		this.NPCDir = (sbyte)UnityEngine.Random.Range(0, 2);
		if ((int)this.NPCDir == 0)
		{
			this.NPCDir = -1;
			this.NPCTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		}
		else
		{
			this.NPCTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		}
		this.NPCSheetID = (byte)UnityEngine.Random.Range(0, this.NPCAnimation[(int)this.CurNPCState].Length);
		this.AnimationSpeed = 15f;
		this.AnimationTimer = 1f;
		this.posxoffset = (this.posyoffset = (this.HurtTimer = (this.HitTimer = (this.DieTimer = 0f))));
		this.damage = new List<Damage>(3);
		this.fighters = new List<LineNode>(16);
		this.hurt = new List<float>(16);
		this.updateNPC(inipos);
		this.SetActive(false);
	}

	// Token: 0x06000B99 RID: 2969 RVA: 0x0010CF98 File Offset: 0x0010B198
	public NPC(Vector2 inipos, float iniscale, sbyte iniDir, byte npcID, NPCState npcState, Transform parent, ref int ABKey)
	{
		this.NPCControl = null;
		this.NPCGameObject = new GameObject("npc");
		this.NPCTransform = this.NPCGameObject.transform;
		this.NPCTransform.localScale = Vector3.one * iniscale;
		this.NPCSpriteRenderer = this.NPCGameObject.AddComponent<SpriteRenderer>();
		MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey((ushort)npcID);
		CString cstring = StringManager.Instance.SpawnString(30);
		cstring.ClearString();
		cstring.IntToFormat((long)recordByKey.MapNPCNO, 3, false);
		cstring.AppendFormat("UI/NPC_{0}");
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out ABKey);
		StringManager.Instance.DeSpawnString(cstring);
		GameObject gameObject = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
		gameObject.SetActive(false);
		Transform transform = gameObject.transform;
		UISpritesArray component = transform.GetChild(0).GetComponent<UISpritesArray>();
		UISpritesArray component2 = transform.GetChild(1).GetComponent<UISpritesArray>();
		UISpritesArray component3 = transform.GetChild(2).GetComponent<UISpritesArray>();
		transform.SetParent(parent, false);
		this.NPCTransform.SetParent(parent, false);
		this.NPCSpriteRenderer.material = component.m_Image.material;
		this.NPCSpriteRenderer.material.renderQueue = 3001;
		this.NPCAnimation = new Sprite[3][];
		this.NPCAnimation[0] = component.m_Sprites;
		this.NPCAnimation[1] = component2.m_Sprites;
		this.NPCAnimation[2] = component3.m_Sprites;
		this.HitFrame = recordByKey.HitFrame;
		this.NPCKindID = npcID;
		this.CurNPCState = ((npcState < NPCState.NPC_Hit) ? npcState : NPCState.NPC_Attack);
		this.NPCDir = iniDir;
		if ((int)this.NPCDir == 0)
		{
			this.NPCDir = -1;
			this.NPCTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		}
		else
		{
			this.NPCTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		}
		this.NPCSheetID = (byte)UnityEngine.Random.Range(0, this.NPCAnimation[(int)this.CurNPCState].Length);
		this.AnimationSpeed = 15f;
		this.AnimationTimer = 1f;
		this.posxoffset = (this.posyoffset = (this.HurtTimer = (this.HitTimer = (this.DieTimer = 0f))));
		this.damage = new List<Damage>(3);
		this.fighters = new List<LineNode>(16);
		this.hurt = new List<float>(16);
		this.updateNPC(inipos.x, inipos.y);
		this.SetActive(false);
	}

	// Token: 0x06000B9A RID: 2970 RVA: 0x0010D264 File Offset: 0x0010B464
	public void Release()
	{
		if (this.NPCTid < 2048)
		{
			this.releaseNPC();
		}
		if (this.hurt != null)
		{
			this.HurtClear();
			this.hurt = null;
		}
		if (this.fighters != null)
		{
			this.fighters.Clear();
			this.fighters = null;
		}
		if (this.damage != null)
		{
			this.damage.Clear();
			this.damage = null;
		}
		if (this.NPCControl == null)
		{
			Array.Clear(this.NPCAnimation, 0, this.NPCAnimation.Length);
		}
		this.NPCAnimation = null;
		this.NPCGameObject = null;
		this.NPCTransform = null;
		this.NPCSpriteRenderer = null;
		this.NPCControl = null;
	}

	// Token: 0x06000B9B RID: 2971 RVA: 0x0010D31C File Offset: 0x0010B51C
	public void updateNPC()
	{
		if (this.CurNPCState != NPCState.NPC_Idle)
		{
			this.updateNPC(NPCState.NPC_Idle);
		}
		if (this.NPCTableID < 262144u)
		{
			ushort tableID = DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCTableID)].tableID;
			if (this.hurt.Count > 0 && DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCTableID)].pointKind == 10 && (int)tableID < DataManager.MapDataController.NPCPointTable.Length)
			{
				DataManager.MapDataController.NPCPointTable[(int)tableID].Blood = this.hurt[0];
				this.hurt.RemoveAt(0);
				DataManager.msgBuffer[0] = 88;
				DataManager.msgBuffer[1] = this.row;
				DataManager.msgBuffer[2] = this.col;
				GameConstants.GetBytes(DataManager.MapDataController.NPCPointTable[(int)tableID].Blood, DataManager.msgBuffer, 3);
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
		}
	}

	// Token: 0x06000B9C RID: 2972 RVA: 0x0010D42C File Offset: 0x0010B62C
	public void updateNPC(NPCState npcState)
	{
		this.CurNPCState = npcState;
		this.NPCSheetID = 0;
	}

	// Token: 0x06000B9D RID: 2973 RVA: 0x0010D43C File Offset: 0x0010B63C
	public void updateNPC(uint npctableid, byte npcrow, byte npccol)
	{
		this.CurNPCState = NPCState.NPC_Idle;
		if (npctableid < 262144u && DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)npctableid)].pointKind == 10)
		{
			if (npctableid != this.NPCTableID)
			{
				this.NPCDir = (sbyte)UnityEngine.Random.Range(0, 2);
				if ((int)this.NPCDir == 0)
				{
					this.NPCDir = -1;
					this.NPCTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
				}
				else
				{
					this.NPCTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
				}
				this.NPCTableID = npctableid;
				this.NPCTid = 2048;
			}
			ushort tableID = DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCTableID)].tableID;
			if (DataManager.MapDataController.NPCPointTable[(int)tableID].Key == FootballManager.Instance.mFootballKickData.last_football_id)
			{
				if (this.NPCControl != null && this.NPCControl.kickNPC != this)
				{
					if (this.NPCControl.kickNPC != null)
					{
						this.NPCControl.kickNPC.switchIdle(NPCState.NPC_Idle);
					}
					this.NPCControl.kickNPC = this;
					this.NPCControl.mapTileController.updateKickNPCPos((int)this.NPCTableID);
				}
				this.switchIdle(NPCState.NPC_Die);
			}
			else
			{
				this.switchIdle(NPCState.NPC_Idle);
			}
		}
		this.NPCSheetID = (byte)UnityEngine.Random.Range(0, this.NPCAnimation[(int)this.CurNPCState].Length);
		this.row = npcrow;
		this.col = npccol;
		this.Clear();
	}

	// Token: 0x06000B9E RID: 2974 RVA: 0x0010D5E4 File Offset: 0x0010B7E4
	public void updateNPC(float npcboold)
	{
		if (npcboold <= 0f)
		{
			npcboold = 0f;
			if (this.hurt.Count == 0 || this.hurt[this.hurt.Count - 1] > 0f)
			{
				this.hurt.Add(npcboold);
			}
		}
		else
		{
			this.hurt.Add(npcboold);
		}
		if (this.CurNPCState != NPCState.NPC_Attack)
		{
			this.updateNPC(NPCState.NPC_Attack);
		}
	}

	// Token: 0x06000B9F RID: 2975 RVA: 0x0010D664 File Offset: 0x0010B864
	public void updateNPC(LineNode npclineNode)
	{
		this.fighters.Add(npclineNode);
	}

	// Token: 0x06000BA0 RID: 2976 RVA: 0x0010D674 File Offset: 0x0010B874
	public void FighterLeave(LineNode npclineNode)
	{
		for (int i = 0; i < this.fighters.Count; i++)
		{
			if (this.fighters[i] == npclineNode)
			{
				this.fighters.RemoveAt(i);
				return;
			}
		}
	}

	// Token: 0x06000BA1 RID: 2977 RVA: 0x0010D6BC File Offset: 0x0010B8BC
	public void updateNPC(Vector2 pos)
	{
		this.NPCPos.x = pos.x + this.NPCControl.npcposxoffset[(int)this.NPCKindID] * (float)this.NPCDir * DataManager.MapDataController.zoomSize;
		this.NPCPos.y = pos.y + this.NPCControl.npcposyoffset[(int)this.NPCKindID] * DataManager.MapDataController.zoomSize;
		this.NPCTransform.position = new Vector3(this.NPCPos.x + this.posxoffset, this.NPCPos.y + this.posyoffset, 37f);
	}

	// Token: 0x06000BA2 RID: 2978 RVA: 0x0010D76C File Offset: 0x0010B96C
	public void updateNPC(float posx, float posy)
	{
		this.NPCPos.x = posx;
		this.NPCPos.y = posy;
		this.NPCTransform.position = new Vector3(posx, posy, 37f);
	}

	// Token: 0x06000BA3 RID: 2979 RVA: 0x0010D7A0 File Offset: 0x0010B9A0
	public void releaseNPC()
	{
		if (this.NPCTableID < 262144u)
		{
			if (DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCTableID)].pointKind == 10)
			{
				DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCTableID)].pointKind = 0;
				ushort tableID = DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCTableID)].tableID;
				if ((int)tableID < DataManager.MapDataController.NPCPointTable.Length)
				{
					DataManager.MapDataController.NPCPointTableIDpool.despawn((int)tableID);
				}
			}
		}
		else if (this.NPCTid < 2048)
		{
			DataManager.MapDataController.NPCPointTableIDpool.despawn((int)this.NPCTid);
		}
		this.NPCTableID = 262144u;
		this.NPCTid = 2048;
	}

	// Token: 0x06000BA4 RID: 2980 RVA: 0x0010D87C File Offset: 0x0010BA7C
	public void SetActive(bool active)
	{
		if (active)
		{
			this.CurNPCState = NPCState.NPC_Idle;
			this.NPCSheetID = (byte)UnityEngine.Random.Range(0, this.NPCAnimation[(int)this.CurNPCState].Length);
			this.AnimationSpeed = 15f;
			this.AnimationTimer = 1f;
			this.posxoffset = (this.posyoffset = (this.HurtTimer = (this.HitTimer = (this.DieTimer = 0f))));
		}
		else
		{
			this.Clear();
		}
		this.NPCGameObject.SetActive(active);
	}

	// Token: 0x06000BA5 RID: 2981 RVA: 0x0010D910 File Offset: 0x0010BB10
	public void Run()
	{
		this.AnimationTimer -= Time.deltaTime * this.AnimationSpeed;
		if (this.AnimationTimer < 0f)
		{
			this.AnimationTimer = 1f;
			this.NPCSpriteRenderer.sprite = this.NPCAnimation[(int)this.CurNPCState][(int)this.NPCSheetID];
			if (this.CurNPCState == NPCState.NPC_Attack && this.IdelNPCState != NPCState.NPC_Attack)
			{
				if (this.NPCSheetID == this.HitFrame)
				{
					this.HIT();
				}
				if ((int)(this.NPCSheetID += 1) >= this.NPCAnimation[0].Length)
				{
					this.NPCSheetID = 0;
					if (this.fighters.Count == 0)
					{
						this.updateNPC(NPCState.NPC_Idle);
					}
				}
			}
			else if ((int)(this.NPCSheetID += 1) >= this.NPCAnimation[(int)this.CurNPCState].Length)
			{
				if (this.CurNPCState == NPCState.NPC_Die && this.IdelNPCState != NPCState.NPC_Die)
				{
					this.NPCSheetID -= 1;
					this.DieTimer = 1f;
					this.AnimationSpeed = 0f;
				}
				else
				{
					this.NPCSheetID = 0;
				}
			}
		}
		if (this.HurtTimer != 0f)
		{
			this.HurtTimer -= Time.deltaTime;
			Vector3 position = this.NPCPos;
			position.z = 37f;
			if (this.HurtTimer <= 0f)
			{
				this.HurtTimer = 0f;
				this.AnimationSpeed = 15f;
				this.NPCTransform.position = position;
				this.posyoffset = (this.posxoffset = 0f);
			}
			else
			{
				this.posxoffset = Mathf.PerlinNoise(this.posxoffset * 9f, 0f) - 0.5f;
				this.posyoffset = Mathf.PerlinNoise(this.posyoffset * 9f, 0f) - 0.5f;
				position.x += this.posxoffset;
				position.y += this.posyoffset;
				this.NPCTransform.position = position;
			}
		}
		if (this.HitTimer != 0f)
		{
			this.HitTimer -= Time.deltaTime;
			if (this.HitTimer <= 0f)
			{
				this.HitTimer = 0f;
				this.AnimationSpeed = 15f;
			}
		}
		if (this.DieTimer != 0f)
		{
			this.DieTimer -= Time.deltaTime;
			if (this.DieTimer <= 0f)
			{
				this.DieTimer = 0f;
				this.NPCSheetID = 0;
				this.AnimationSpeed = 0f;
				this.fighters.Clear();
				this.HurtClear();
				this.releaseNPC();
				if (this.NPCControl != null)
				{
					this.NPCControl.pushNPC((int)this.row, (int)this.col);
				}
				DataManager.msgBuffer[0] = 90;
				DataManager.msgBuffer[1] = this.row;
				DataManager.msgBuffer[2] = this.col;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
		}
		for (int i = 0; i < this.damage.Count; i++)
		{
			this.damage[i].Tick(Time.deltaTime);
		}
	}

	// Token: 0x06000BA6 RID: 2982 RVA: 0x0010DC80 File Offset: 0x0010BE80
	public void Hurt()
	{
		if (this.CurNPCState == NPCState.NPC_Die)
		{
			return;
		}
		if (this.CurNPCState != NPCState.NPC_Attack)
		{
			this.updateNPC(NPCState.NPC_Attack);
		}
		ushort num = this.NPCTid;
		if (this.NPCTableID < 262144u && DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCTableID)].pointKind == 10)
		{
			num = DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCTableID)].tableID;
		}
		if ((this.hurt.Count == 0 && (int)num < DataManager.MapDataController.NPCPointTable.Length && DataManager.MapDataController.NPCPointTable[(int)num].Blood == 0f) || (this.hurt.Count > 0 && this.hurt[0] == 0f))
		{
			this.Die();
		}
		else
		{
			this.AnimationSpeed = 0f;
			if (this.hurt.Count > 0)
			{
				float num2 = this.hurt[0];
				if (num2 >= 0f && this.NPCControl != null && this.NPCTableID < 262144u && DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCTableID)].pointKind == 10 && (int)num < DataManager.MapDataController.NPCPointTable.Length)
				{
					Damage damage = this.NPCControl.pullDamage();
					damage.updateDamage(this);
					num2 = DataManager.MapDataController.NPCPointTable[(int)num].Blood - num2;
					DataManager.MapDataController.NPCPointTable[(int)num].Blood = this.hurt[0];
					damage.updateDamage(num2);
					if (this.damage.Count == 3)
					{
						this.NPCControl.pushDamage(this.damage[0]);
						this.damage.RemoveAt(0);
					}
					this.damage.Add(damage);
					damage.SetActive(true);
					DataManager.msgBuffer[0] = 88;
					DataManager.msgBuffer[1] = this.row;
					DataManager.msgBuffer[2] = this.col;
					GameConstants.GetBytes(DataManager.MapDataController.NPCPointTable[(int)num].Blood, DataManager.msgBuffer, 3);
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
				this.hurt.RemoveAt(0);
			}
			this.HurtTimer = 0.2f;
			this.HitTimer = 0f;
			this.posxoffset = Mathf.PerlinNoise(this.NPCTransform.position.x * 9f, 0f) - 0.5f;
			this.posyoffset = Mathf.PerlinNoise(this.NPCTransform.position.y * 9f, 0f) - 0.5f;
			this.NPCTransform.position = new Vector3(this.NPCPos.x + this.posxoffset, this.NPCPos.y + this.posyoffset, 37f);
		}
	}

	// Token: 0x06000BA7 RID: 2983 RVA: 0x0010DF9C File Offset: 0x0010C19C
	public void Die()
	{
		if (this.hurt.Count > 0)
		{
			float num = this.hurt[0];
			if (this.NPCControl != null)
			{
				ushort num2 = this.NPCTid;
				if (this.NPCTableID < 262144u && DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCTableID)].pointKind == 10)
				{
					num2 = DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCTableID)].tableID;
				}
				if ((int)num2 < DataManager.MapDataController.NPCPointTable.Length)
				{
					Damage damage = this.NPCControl.pullDamage();
					damage.updateDamage(this);
					num = DataManager.MapDataController.NPCPointTable[(int)num2].Blood - num;
					damage.updateDamage(num);
					if (this.damage.Count == 3)
					{
						this.NPCControl.pushDamage(this.damage[0]);
						this.damage.RemoveAt(0);
					}
					this.damage.Add(damage);
					damage.SetActive(true);
				}
			}
			this.HurtClear();
			if (this.fighters.Count > 0)
			{
				this.fighters.Clear();
			}
		}
		DataManager.msgBuffer[0] = 88;
		DataManager.msgBuffer[1] = this.row;
		DataManager.msgBuffer[2] = this.col;
		GameConstants.GetBytes(0f, DataManager.msgBuffer, 3);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		this.AnimationSpeed = 5f;
		this.posxoffset = (this.posyoffset = (this.HitTimer = (this.HurtTimer = (this.DieTimer = 0f))));
		this.updateNPC(NPCState.NPC_Die);
	}

	// Token: 0x06000BA8 RID: 2984 RVA: 0x0010E154 File Offset: 0x0010C354
	public void HIT()
	{
		for (int i = 0; i < this.fighters.Count; i++)
		{
			this.fighters[i].Shake();
		}
		this.AnimationSpeed = 5f;
		this.HitTimer = 0.2f;
		this.HurtTimer = 0f;
		if (this.CurNPCState != NPCState.NPC_Attack)
		{
			this.updateNPC(NPCState.NPC_Attack);
		}
	}

	// Token: 0x06000BA9 RID: 2985 RVA: 0x0010E1C4 File Offset: 0x0010C3C4
	public void Clear()
	{
		if (this.NPCControl != null)
		{
			for (int i = 0; i < this.damage.Count; i++)
			{
				this.NPCControl.pushDamage(this.damage[i]);
			}
		}
		this.damage.Clear();
		this.fighters.Clear();
		this.HurtClear();
	}

	// Token: 0x06000BAA RID: 2986 RVA: 0x0010E22C File Offset: 0x0010C42C
	public void DelDamage(Damage deldamage)
	{
		int num = -1;
		for (int i = 0; i < this.damage.Count; i++)
		{
			if (deldamage == this.damage[i])
			{
				num = i;
				break;
			}
		}
		if (num > -1)
		{
			this.damage.RemoveAt(num);
		}
		if (this.NPCControl != null)
		{
			this.NPCControl.pushDamage(deldamage);
		}
	}

	// Token: 0x06000BAB RID: 2987 RVA: 0x0010E29C File Offset: 0x0010C49C
	public void HurtClear()
	{
		if (this.NPCControl != null)
		{
			ushort num = this.NPCTid;
			if (this.NPCTableID < 262144u && DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCTableID)].pointKind == 10)
			{
				num = DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)this.NPCTableID)].tableID;
			}
			if ((int)num < DataManager.MapDataController.NPCPointTable.Length)
			{
				for (int i = this.hurt.Count - 1; i > -1; i--)
				{
					if (this.hurt[i] >= 0f)
					{
						DataManager.MapDataController.NPCPointTable[(int)num].Blood = this.hurt[i];
						break;
					}
				}
			}
		}
		this.hurt.Clear();
	}

	// Token: 0x06000BAC RID: 2988 RVA: 0x0010E380 File Offset: 0x0010C580
	public void switchIdle(NPCState switchState)
	{
		if (switchState == NPCState.NPC_Hit || switchState == NPCState.NPC_Hurt)
		{
			return;
		}
		if (switchState != this.CurNPCState)
		{
			this.updateNPC(switchState);
		}
		if (this.CurNPCState == NPCState.NPC_Attack)
		{
			this.IdelNPCState = NPCState.NPC_Attack;
		}
		else if (this.CurNPCState == NPCState.NPC_Die)
		{
			this.IdelNPCState = NPCState.NPC_Die;
		}
		else
		{
			this.IdelNPCState = NPCState.NPC_Idle;
		}
	}

	// Token: 0x04002728 RID: 10024
	public byte NPCKindID;

	// Token: 0x04002729 RID: 10025
	public sbyte NPCDir;

	// Token: 0x0400272A RID: 10026
	public NPCState CurNPCState;

	// Token: 0x0400272B RID: 10027
	public Vector2 NPCPos;

	// Token: 0x0400272C RID: 10028
	public List<float> hurt;

	// Token: 0x0400272D RID: 10029
	public List<LineNode> fighters;

	// Token: 0x0400272E RID: 10030
	public float DieTimer;

	// Token: 0x0400272F RID: 10031
	public uint NPCTableID = 262144u;

	// Token: 0x04002730 RID: 10032
	public GameObject NPCGameObject;

	// Token: 0x04002731 RID: 10033
	public ushort NPCTid = 2048;

	// Token: 0x04002732 RID: 10034
	public SpriteRenderer NPCSpriteRenderer;

	// Token: 0x04002733 RID: 10035
	private byte NPCSheetID;

	// Token: 0x04002734 RID: 10036
	private byte HitFrame;

	// Token: 0x04002735 RID: 10037
	private Sprite[][] NPCAnimation;

	// Token: 0x04002736 RID: 10038
	private float AnimationSpeed;

	// Token: 0x04002737 RID: 10039
	private float AnimationTimer;

	// Token: 0x04002738 RID: 10040
	private float HurtTimer;

	// Token: 0x04002739 RID: 10041
	private float HitTimer;

	// Token: 0x0400273A RID: 10042
	private float posxoffset;

	// Token: 0x0400273B RID: 10043
	private float posyoffset;

	// Token: 0x0400273C RID: 10044
	private byte row;

	// Token: 0x0400273D RID: 10045
	private byte col;

	// Token: 0x0400273E RID: 10046
	private Transform NPCTransform;

	// Token: 0x0400273F RID: 10047
	private List<Damage> damage;

	// Token: 0x04002740 RID: 10048
	private MapTileNPC NPCControl;

	// Token: 0x04002741 RID: 10049
	private NPCState IdelNPCState;
}
