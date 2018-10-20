using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000020 RID: 32
public class UINPC
{
	// Token: 0x060000F5 RID: 245 RVA: 0x00010FE8 File Offset: 0x0000F1E8
	public void SpawnNPC(Vector2 inipos, float iniscale, sbyte iniDir, byte npcID, UINPCState npcState, Transform parent, ref int ABKey)
	{
		MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey((ushort)npcID);
		CString cstring = StringManager.Instance.SpawnString(30);
		cstring.ClearString();
		cstring.IntToFormat((long)recordByKey.MapNPCNO, 3, false);
		cstring.AppendFormat("UI/NPC_{0}");
		AssetBundle assetBundle = null;
		if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.UI, AssetType.NPC, recordByKey.MapNPCNO, false))
		{
			assetBundle = AssetManager.GetAssetBundle(cstring, out ABKey);
		}
		StringManager.Instance.DeSpawnString(cstring);
		if (assetBundle == null)
		{
			this.bNeedReload = true;
			return;
		}
		this.bNeedReload = false;
		this.NPCGameObject = new GameObject("npc");
		RectTransform rectTransform = this.NPCGameObject.AddComponent<RectTransform>();
		rectTransform.localScale = Vector3.one * iniscale;
		this.NPCGameObject.AddComponent<IgnoreRaycast>();
		this.NPCImage = this.NPCGameObject.AddComponent<Image>();
		this.NPCSpriteObject = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
		this.NPCSpriteObject.SetActive(false);
		Transform transform = this.NPCSpriteObject.transform;
		UISpritesArray component = transform.GetChild(0).GetComponent<UISpritesArray>();
		UISpritesArray component2 = transform.GetChild(1).GetComponent<UISpritesArray>();
		UISpritesArray component3 = transform.GetChild(2).GetComponent<UISpritesArray>();
		transform.SetParent(parent, false);
		rectTransform.SetParent(parent, false);
		this.NPCImage.material = component.m_Image.material;
		Shader shader = null;
		for (int i = 0; i < AssetManager.Instance.Shaders.Length; i++)
		{
			if (AssetManager.Instance.Shaders[i].name == "zTWRD2 Shaders/UI/Sprites Stencil Alpha R")
			{
				shader = (Shader)AssetManager.Instance.Shaders[i];
				break;
			}
		}
		if (shader != null)
		{
			this.NPCImage.material.shader = shader;
		}
		this.NPCAnimation = new Sprite[4][];
		this.NPCAnimation[0] = component.m_Sprites;
		this.NPCAnimation[1] = component2.m_Sprites;
		this.NPCAnimation[2] = component3.m_Sprites;
		this.NPCDir = iniDir;
		if ((int)this.NPCDir == 0)
		{
			this.NPCDir = -1;
			rectTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		}
		else
		{
			rectTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		}
		this.CurNPCState = ((npcState < UINPCState.UINPC_Max) ? npcState : UINPCState.UINPC_Attack);
		this.SetActive(true, this.CurNPCState);
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x0001127C File Offset: 0x0000F47C
	public void Release()
	{
		if (this.bNeedReload)
		{
			return;
		}
		Array.Clear(this.NPCAnimation, 0, this.NPCAnimation.Length);
		this.NPCAnimation = null;
		this.NPCGameObject = null;
		this.NPCSpriteObject = null;
		this.NPCImage = null;
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x000112C8 File Offset: 0x0000F4C8
	public void updateNPC(UINPCState npcState)
	{
		if (this.bNeedReload)
		{
			return;
		}
		this.CurNPCState = npcState;
		this.NPCSheetID = 0;
		if (npcState == UINPCState.UINPC_Stop)
		{
			this.NPCImage.sprite = this.NPCAnimation[2][(int)this.NPCSheetID];
			this.NPCImage.SetNativeSize();
			this.NPCImage.color = new Color32(83, 118, 167, byte.MaxValue);
		}
		else
		{
			this.NPCImage.color = Color.white;
		}
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x00011354 File Offset: 0x0000F554
	public void SetActive(bool active, UINPCState tmpState = UINPCState.UINPC_Idle)
	{
		if (this.bNeedReload)
		{
			return;
		}
		if (active)
		{
			this.CurNPCState = tmpState;
			this.NPCSheetID = (byte)UnityEngine.Random.Range(0, this.NPCAnimation[(int)this.CurNPCState].Length);
			this.AnimationTimer = 1f;
			this.NPCImage.sprite = this.NPCAnimation[(int)this.CurNPCState][(int)this.NPCSheetID];
			this.NPCImage.SetNativeSize();
		}
		this.NPCGameObject.SetActive(active);
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x000113D8 File Offset: 0x0000F5D8
	public void Run()
	{
		if (this.bNeedReload)
		{
			return;
		}
		if (this.CurNPCState != UINPCState.UINPC_Stop)
		{
			this.AnimationTimer -= Time.deltaTime * this.AnimationSpeed;
			if (this.AnimationTimer < 0f)
			{
				this.AnimationTimer = 1f;
				this.NPCImage.sprite = this.NPCAnimation[(int)this.CurNPCState][(int)this.NPCSheetID];
				this.NPCImage.SetNativeSize();
				if ((int)(this.NPCSheetID += 1) >= this.NPCAnimation[(int)this.CurNPCState].Length)
				{
					this.NPCSheetID = 0;
				}
			}
		}
	}

	// Token: 0x040001FC RID: 508
	public sbyte NPCDir;

	// Token: 0x040001FD RID: 509
	public UINPCState CurNPCState;

	// Token: 0x040001FE RID: 510
	public GameObject NPCGameObject;

	// Token: 0x040001FF RID: 511
	public GameObject NPCSpriteObject;

	// Token: 0x04000200 RID: 512
	public Image NPCImage;

	// Token: 0x04000201 RID: 513
	public bool bNeedReload;

	// Token: 0x04000202 RID: 514
	private byte NPCSheetID;

	// Token: 0x04000203 RID: 515
	private Sprite[][] NPCAnimation;

	// Token: 0x04000204 RID: 516
	private float AnimationSpeed = 15f;

	// Token: 0x04000205 RID: 517
	private float AnimationTimer;

	// Token: 0x04000206 RID: 518
	private bool bStopAnim;
}
