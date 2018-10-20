using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200005D RID: 93
public class DamageValueManager
{
	// Token: 0x06000274 RID: 628 RVA: 0x0001F904 File Offset: 0x0001DB04
	public DamageValueManager(Transform CanvasTransform)
	{
		this.m_Color = new Color(1f, 1f, 1f, 1f);
		this.m_RedColor = new Color(1f, 0.5254902f, 0.0156862754f, 1f);
		this.m_RedColor1 = new Color(1f, 0.2784314f, 0.384313732f, 1f);
		this.m_EnergyColor = new Color(1f, 0.972549f, 0.0235294122f, 1f);
		this.m_GreenColor = new Color(0.169960469f, 1f, 0.05882353f, 1f);
		this.m_GreenColor1 = new Color(0f, 0.6313726f, 0.1882353f, 1f);
		this.m_BlueColor = new Color(0f, 0.7529412f, 1f, 1f);
		this.m_BlueColor1 = new Color(0.149019614f, 0.3647059f, 1f, 1f);
		this.m_Vec2 = new Vector2(500f, 200f);
		GameObject gameObject = new GameObject("DamageValueBaseLayer");
		this.baseLayer = gameObject.AddComponent<RectTransform>();
		this.SetDVTransform(this.baseLayer);
		gameObject.layer = 5;
		this.baseLayer.SetParent(CanvasTransform, false);
		gameObject = new GameObject("BloodBarLayer");
		RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
		gameObject.layer = 5;
		rectTransform.SetParent(this.baseLayer, false);
		gameObject = new GameObject("DamageValueLayer_Num");
		this.DamageValueLayer_Num = gameObject.AddComponent<RectTransform>();
		gameObject.layer = 5;
		this.DamageValueLayer_Num.SetParent(this.baseLayer, false);
		gameObject = new GameObject("DamageValueLayer_Normal");
		this.DamageValueLayer_Normal = gameObject.AddComponent<RectTransform>();
		gameObject.layer = 5;
		this.DamageValueLayer_Normal.SetParent(this.baseLayer, false);
		gameObject = new GameObject("DamageValueLayer_CRINum");
		this.DamageValueLayer_CRINum = gameObject.AddComponent<RectTransform>();
		gameObject.layer = 5;
		this.DamageValueLayer_CRINum.SetParent(this.baseLayer, false);
		gameObject = new GameObject("DamageValueLayer_Word");
		this.DamageValueLayer_Word = gameObject.AddComponent<RectTransform>();
		gameObject.layer = 5;
		this.DamageValueLayer_Word.SetParent(this.baseLayer, false);
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x06000275 RID: 629 RVA: 0x0001FD38 File Offset: 0x0001DF38
	public Font DamageValueFont
	{
		get
		{
			if (this.m_DamageValueFont == null)
			{
				AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/DVFont", out this.AssetKey_Font, false);
				if (assetBundle == null)
				{
					return null;
				}
				this.m_DamageValueFont = (Font)UnityEngine.Object.Instantiate(assetBundle.mainAsset);
			}
			return this.m_DamageValueFont;
		}
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x06000276 RID: 630 RVA: 0x0001FD94 File Offset: 0x0001DF94
	public RectTransform CanvasRT
	{
		get
		{
			if (this.m_CanvasRT == null)
			{
				this.m_CanvasRT = GUIManager.Instance.m_UICanvas.GetComponent<RectTransform>();
			}
			return this.m_CanvasRT;
		}
	}

	// Token: 0x06000277 RID: 631 RVA: 0x0001FDD0 File Offset: 0x0001DFD0
	~DamageValueManager()
	{
	}

	// Token: 0x06000278 RID: 632 RVA: 0x0001FE08 File Offset: 0x0001E008
	public void UnLoadDamageValueAsset()
	{
		if (this.TransitionsGO1 != null)
		{
			UnityEngine.Object.Destroy(this.TransitionsGO1);
			this.TransitionsGO1 = null;
			UnityEngine.Object.Destroy(this.TransitionsGO4);
			this.TransitionsGO4 = null;
			UnityEngine.Object.Destroy(this.TransitionsGO5);
			this.TransitionsGO5 = null;
			UnityEngine.Object.Destroy(this.TransitionsGO6);
			this.TransitionsGO6 = null;
			UnityEngine.Object.Destroy(this.BossObj);
			this.BossObj = null;
			GUIManager.Instance.RemoveSpriteAsset(this.TransNameStr);
			if (this.AssetKey_Trans1 != 0)
			{
				AssetManager.UnloadAssetBundle(this.AssetKey_Trans1, true);
			}
		}
		if (this.TransitionsGO2 != null)
		{
			UnityEngine.Object.Destroy(this.TransitionsGO2);
			this.TransitionsGO2 = null;
		}
		if (this.TransitionsGO3 != null)
		{
			UnityEngine.Object.Destroy(this.TransitionsGO3);
			this.TransitionsGO3 = null;
		}
		if (this.AssetKey_Trans != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey_Trans, true);
		}
		if (this.m_DamageValueFont != null)
		{
			UnityEngine.Object.Destroy(this.m_DamageValueFont);
			if (this.AssetKey_Font != 0)
			{
				AssetManager.UnloadAssetBundle(this.AssetKey_Font, true);
			}
		}
		if (this.AssetKey_Bar != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey_Bar, true);
		}
	}

	// Token: 0x06000279 RID: 633 RVA: 0x0001FF50 File Offset: 0x0001E150
	public void SetDVTransform(RectTransform tran)
	{
		tran.pivot = new Vector2(0.5f, 0.5f);
		tran.anchorMin = new Vector2(0f, 0f);
		tran.anchorMax = new Vector2(0f, 0f);
	}

	// Token: 0x0600027A RID: 634 RVA: 0x0001FF9C File Offset: 0x0001E19C
	public void SetTransitionLayer(Transform CanvasTransform)
	{
		this.TransitionLayer = new GameObject("TransitionLayer")
		{
			layer = 5
		}.AddComponent<RectTransform>();
		this.TransitionLayer.SetParent(CanvasTransform, false);
		RectTransform transitionLayer = this.TransitionLayer;
		Vector2 zero = Vector2.zero;
		this.TransitionLayer.anchorMin = zero;
		transitionLayer.sizeDelta = zero;
		this.TransitionLayer.anchorMax = Vector2.one;
	}

	// Token: 0x0600027B RID: 635 RVA: 0x00020004 File Offset: 0x0001E204
	public void UpdateRun()
	{
		this.UpDateDV();
		this.UpDateStateFade();
		this.UpDateBloodBarPos();
		this.UpDateBloodBarWidth();
		this.UpDateTransitions();
		this.UpDateBoss();
	}

	// Token: 0x0600027C RID: 636 RVA: 0x00020038 File Offset: 0x0001E238
	public void BeginFightInitial()
	{
		this.PlayerCount = 10;
		this.EnemyCount = 20;
		this.bc = (GameManager.ActiveGameplay as BattleController);
		this.InitialDamageValueManager();
		this.InitialBloodBar();
		this.ResetDV();
		this.ResetBloodBar(true);
	}

	// Token: 0x0600027D RID: 637 RVA: 0x00020080 File Offset: 0x0001E280
	public void BeginWarInitial()
	{
		this.PlayerCount = 17;
		this.EnemyCount = 17;
		this.wm = (GameManager.ActiveGameplay as WarManager);
		this.InitialBloodBar();
		this.ResetBloodBar(true);
	}

	// Token: 0x0600027E RID: 638 RVA: 0x000200B0 File Offset: 0x0001E2B0
	public void NextFightStage()
	{
		this.ResetDV();
		this.ResetBloodBar(false);
		this.ResetState();
	}

	// Token: 0x0600027F RID: 639 RVA: 0x000200C8 File Offset: 0x0001E2C8
	public void NextWar()
	{
		this.ResetBloodBar(true);
	}

	// Token: 0x06000280 RID: 640 RVA: 0x000200D4 File Offset: 0x0001E2D4
	public void EndFightClear()
	{
		this.bc = null;
		this.ResetDV();
		this.ResetBloodBar(true);
		this.DeleteDamageValue();
		this.DeleteBloodBar();
	}

	// Token: 0x06000281 RID: 641 RVA: 0x00020104 File Offset: 0x0001E304
	public void EndWarClear()
	{
		this.wm = null;
		this.ResetBloodBar(true);
		this.DeleteBloodBar();
	}

	// Token: 0x06000282 RID: 642 RVA: 0x0002011C File Offset: 0x0001E31C
	public void RebuiltFont()
	{
		if (this.BossObj != null && this.BossText != null && this.BossText.enabled)
		{
			this.BossText.enabled = false;
			this.BossText.enabled = true;
		}
	}

	// Token: 0x06000283 RID: 643 RVA: 0x00020174 File Offset: 0x0001E374
	public void InitialDamageValueManager()
	{
		GameObject gameObject = new GameObject(this.GOName);
		RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
		UIText uitext = gameObject.AddComponent<UIText>();
		rectTransform.sizeDelta = this.m_Vec2;
		uitext.alignment = TextAnchor.MiddleCenter;
		uitext.font = this.DamageValueFont;
		uitext.fontSize = 0;
		uitext.material = this.DamageValueFont.material;
		uitext.horizontalOverflow = HorizontalWrapMode.Overflow;
		DamageValue damageValue = new DamageValue();
		damageValue.m_GameObject = gameObject;
		damageValue.m_transform = gameObject.transform;
		damageValue.m_Text = uitext;
		damageValue.m_RT = rectTransform;
		damageValue.m_GameObject.SetActive(false);
		damageValue.m_GameObject.transform.SetParent(this.DamageValueLayer_Num, false);
		this.EmptyDVStack_Num.Push(damageValue);
		for (int i = 1; i < 60; i++)
		{
			damageValue = new DamageValue();
			damageValue.m_GameObject = (UnityEngine.Object.Instantiate(gameObject) as GameObject);
			damageValue.m_GameObject.name = gameObject.name;
			damageValue.m_transform = damageValue.m_GameObject.transform;
			damageValue.m_Text = damageValue.m_GameObject.GetComponent<UIText>();
			damageValue.m_RT = damageValue.m_GameObject.GetComponent<RectTransform>();
			damageValue.m_GameObject.transform.SetParent(this.DamageValueLayer_Num, false);
			damageValue.m_GameObject.SetActive(false);
			this.EmptyDVStack_Num.Push(damageValue);
		}
		GameObject gameObject2 = new GameObject(this.GOName);
		RectTransform rectTransform2 = gameObject2.AddComponent<RectTransform>();
		UIText uitext2 = gameObject2.AddComponent<UIText>();
		rectTransform2.sizeDelta = this.m_Vec2;
		uitext2.alignment = TextAnchor.MiddleCenter;
		uitext2.font = GUIManager.Instance.GetTTFFont();
		uitext2.fontSize = 48;
		uitext2.horizontalOverflow = HorizontalWrapMode.Overflow;
		Outline outline = gameObject2.AddComponent<Outline>();
		outline.effectColor = new Color(0f, 0f, 0f, 1f);
		outline.effectDistance = new Vector2(2f, 2f);
		DamageValue damageValue2 = new DamageValue();
		damageValue2.m_GameObject = gameObject2;
		damageValue2.m_transform = gameObject2.transform;
		damageValue2.m_Text = uitext2;
		damageValue2.m_RT = rectTransform2;
		damageValue2.m_GameObject.SetActive(false);
		damageValue2.m_GameObject.transform.SetParent(this.DamageValueLayer_Word, false);
		this.EmptyDVStack_Word.Push(damageValue2);
		for (int j = 1; j < 20; j++)
		{
			damageValue2 = new DamageValue();
			damageValue2.m_GameObject = (UnityEngine.Object.Instantiate(gameObject2) as GameObject);
			damageValue2.m_GameObject.name = gameObject2.name;
			damageValue2.m_transform = damageValue2.m_GameObject.transform;
			damageValue2.m_Text = damageValue2.m_GameObject.GetComponent<UIText>();
			damageValue2.m_RT = damageValue2.m_GameObject.GetComponent<RectTransform>();
			damageValue2.m_GameObject.transform.SetParent(this.DamageValueLayer_Word, false);
			damageValue2.m_GameObject.SetActive(false);
			this.EmptyDVStack_Word.Push(damageValue2);
		}
	}

	// Token: 0x06000284 RID: 644 RVA: 0x00020478 File Offset: 0x0001E678
	private void DeleteDamageValue()
	{
		for (int i = 0; i < 20; i++)
		{
			DamageValue damageValue = this.EmptyDVStack_Word.Pop();
			if (damageValue != null)
			{
				UnityEngine.Object.Destroy(damageValue.m_GameObject);
				damageValue.m_GameObject = null;
				damageValue.m_transform = null;
				damageValue.m_Text = null;
				damageValue.m_RT = null;
			}
		}
		for (int j = 0; j < 60; j++)
		{
			DamageValue damageValue = this.EmptyDVStack_Num.Pop();
			if (damageValue != null)
			{
				UnityEngine.Object.Destroy(damageValue.m_GameObject);
				damageValue.m_GameObject = null;
				damageValue.m_transform = null;
				damageValue.m_Text = null;
				damageValue.m_RT = null;
			}
		}
	}

	// Token: 0x06000285 RID: 645 RVA: 0x00020524 File Offset: 0x0001E724
	private bool CheckisNumber(HERO_EFFECTTYPE_ENUM Type)
	{
		bool result = true;
		switch (Type)
		{
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DODGE:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_IMM:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_PHYSIMM:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_MAGIIMM:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_IMM_BUFF:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_PHYSIMM_BUFF:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_MAGIIMM_BUFF:
			result = false;
			break;
		}
		return result;
	}

	// Token: 0x06000286 RID: 646 RVA: 0x00020584 File Offset: 0x0001E784
	private bool CheckisCritical(HERO_EFFECTTYPE_ENUM Type)
	{
		bool result = false;
		switch (Type)
		{
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_CIR:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_RECOVER_CIR:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DOT_CIR:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_HOT_CIR:
			result = true;
			break;
		}
		return result;
	}

	// Token: 0x06000287 RID: 647 RVA: 0x000205C4 File Offset: 0x0001E7C4
	private void UpDateDV()
	{
		float deltaTime = Time.deltaTime;
		float y = deltaTime * 150f;
		for (int i = this.DVList.Count - 1; i >= 0; i--)
		{
			this.DVList[i].fTime += deltaTime;
			if (this.DVList[i].fTime >= this.DVList[i].fShowTime)
			{
				this.ClearDV(i);
			}
			else
			{
				bool isArabic = GUIManager.Instance.IsArabic;
				if (isArabic && this.DVList[i].m_RT.localScale.x < 0f)
				{
					this.DVList[i].m_RT.localScale = new Vector3(-this.DVList[i].m_RT.localScale.x, this.DVList[i].m_RT.localScale.y, this.DVList[i].m_RT.localScale.z);
				}
				if (this.DVList[i].bNumber)
				{
					if (this.DVList[i].bCritical)
					{
						if (this.DVList[i].fTime <= 0.2f)
						{
							float num = 8.5f;
							this.m_Vec3.x = this.DVList[i].m_RT.localScale.x + deltaTime * num;
							this.m_Vec3.y = this.DVList[i].m_RT.localScale.y + deltaTime * num;
							this.m_Vec3.z = this.DVList[i].m_RT.localScale.z + deltaTime * num;
							this.DVList[i].m_RT.localScale = this.m_Vec3;
						}
						else if (this.DVList[i].fTime > 0.2f && this.DVList[i].fTime <= 0.4f)
						{
							float num2 = 8.5f;
							this.m_Vec3.x = this.DVList[i].m_RT.localScale.x - deltaTime * num2;
							this.m_Vec3.y = this.DVList[i].m_RT.localScale.y - deltaTime * num2;
							this.m_Vec3.z = this.DVList[i].m_RT.localScale.z - deltaTime * num2;
							this.DVList[i].m_RT.localScale = this.m_Vec3;
						}
						else
						{
							this.DVList[i].m_RT.localScale = Vector3.one * this.DVScaleN * this.DVScale;
							this.DVList[i].m_transform.localPosition += new Vector3(0f, y, 0f);
						}
						if (this.DVList[i].m_RT.localScale.x < 0f)
						{
							this.DVList[i].m_RT.localScale = Vector3.one * this.DVScaleN * this.DVScale;
						}
					}
					else if (this.DVList[i].Type == HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DAMAGE)
					{
						if (this.moveDelta == -1f)
						{
							this.moveDelta = this.CanvasRT.sizeDelta.x * 1.1f;
						}
						if (this.DVList[i].fTime <= 0.06f)
						{
							if (this.DVList[i].side == 0)
							{
								this.m_Vec3.x = this.DVList[i].m_RT.localPosition.x - deltaTime * this.moveDelta;
							}
							else
							{
								this.m_Vec3.x = this.DVList[i].m_RT.localPosition.x + deltaTime * this.moveDelta;
							}
							this.m_Vec3.y = this.DVList[i].m_RT.localPosition.y;
							this.m_Vec3.z = this.DVList[i].m_RT.localPosition.z;
							this.DVList[i].m_RT.localPosition = this.m_Vec3;
						}
						else if (this.DVList[i].fTime >= 0.06f && this.DVList[i].fTime <= 0.12f)
						{
							if (this.DVList[i].side == 0)
							{
								this.m_Vec3.x = this.DVList[i].m_RT.localPosition.x + deltaTime * this.moveDelta;
							}
							else
							{
								this.m_Vec3.x = this.DVList[i].m_RT.localPosition.x - deltaTime * this.moveDelta;
							}
							this.m_Vec3.y = this.DVList[i].m_RT.localPosition.y;
							this.m_Vec3.z = this.DVList[i].m_RT.localPosition.z;
							this.DVList[i].m_RT.localPosition = this.m_Vec3;
						}
						this.DVList[i].m_transform.localPosition += new Vector3(0f, y, 0f);
					}
					if (this.DVList[i].Type == HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DOT || this.DVList[i].Type == HERO_EFFECTTYPE_ENUM.HERO_EFFECT_HOT)
					{
						this.DVList[i].m_transform.localPosition += new Vector3(0f, y, 0f);
					}
					if (this.DVList[i].fTime >= this.DVList[i].fShowTime * 0.3f)
					{
						Color color = this.DVList[i].m_Text.color;
						color.a -= Time.deltaTime * 2f;
						this.DVList[i].m_Text.color = color;
					}
				}
				else
				{
					this.DVList[i].m_transform.localPosition += new Vector3(0f, y, 0f);
					if (this.DVList[i].fTime >= this.DVList[i].fShowTime * 0.8f)
					{
						Color color2 = this.DVList[i].m_Text.color;
						color2.a -= Time.deltaTime * 2f;
						this.DVList[i].m_Text.color = color2;
					}
				}
				if (isArabic && this.DVList[i].m_RT.localScale.x < 0f)
				{
					this.DVList[i].m_RT.localScale = new Vector3(-this.DVList[i].m_RT.localScale.x, this.DVList[i].m_RT.localScale.y, this.DVList[i].m_RT.localScale.z);
				}
			}
		}
	}

	// Token: 0x06000288 RID: 648 RVA: 0x00020E80 File Offset: 0x0001F080
	public void ResetDV()
	{
		for (int i = this.DVList.Count - 1; i >= 0; i--)
		{
			this.ClearDV(i);
		}
	}

	// Token: 0x06000289 RID: 649 RVA: 0x00020EB4 File Offset: 0x0001F0B4
	private void ClearDV(int i)
	{
		this.DVList[i].m_GameObject.SetActive(false);
		this.DVList[i].fTime = 0f;
		this.DVList[i].iOffset = 0;
		this.DVList[i].side = 0;
		this.DVList[i].fShowTime = 0f;
		this.DVList[i].m_transform.SetParent(this.DamageValueLayer_Num, false);
		if (this.DVList[i].bNumber)
		{
			this.EmptyDVStack_Num.Push(this.DVList[i]);
		}
		else
		{
			this.EmptyDVStack_Word.Push(this.DVList[i]);
		}
		this.DVList.RemoveAt(i);
	}

	// Token: 0x0600028A RID: 650 RVA: 0x00020F9C File Offset: 0x0001F19C
	public void AddDamageValueEffect(uint iValue, int Side, int iIndex, HERO_EFFECTTYPE_ENUM Type, int iOffset = 0)
	{
		if (this.bc == null)
		{
			return;
		}
		if (NewbieManager.IsNewbie)
		{
			return;
		}
		Vector3 position;
		float boundingHight;
		if (Side == 0)
		{
			position = this.bc.playerUnit[iIndex].Position;
			boundingHight = this.bc.playerUnit[iIndex].BoundingHight;
		}
		else
		{
			position = this.bc.enemyUnit[iIndex].Position;
			boundingHight = this.bc.enemyUnit[iIndex].BoundingHight;
		}
		bool flag = this.CheckisNumber(Type);
		if (flag && this.EmptyDVStack_Num.Count <= 0)
		{
			return;
		}
		if (!flag && this.EmptyDVStack_Word.Count <= 0)
		{
			return;
		}
		DamageValue damageValue = (!flag) ? this.EmptyDVStack_Word.Pop() : this.EmptyDVStack_Num.Pop();
		damageValue.bNumber = flag;
		this.m_Vec3.x = 0f;
		this.m_Vec3.y = boundingHight;
		this.m_Vec3.z = 0f;
		Vector2 vector = Camera.main.WorldToScreenPoint(position + this.m_Vec3);
		float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
		vector /= scaleFactor;
		damageValue.Type = Type;
		damageValue.iOffset = iOffset;
		damageValue.side = (byte)Side;
		damageValue.m_GameObject.SetActive(true);
		damageValue.m_RT.anchoredPosition = vector;
		this.m_Vec3.x = this.DVScaleN;
		this.m_Vec3.y = this.DVScaleN;
		this.m_Vec3.z = this.DVScaleN;
		damageValue.m_RT.localScale = this.m_Vec3;
		byte b = 13;
		this.sb.Length = 0;
		switch (Type)
		{
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DAMAGE:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DOT:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DOT_CIR:
			damageValue.fShowTime = 0.9f;
			if (GUIManager.Instance.IsArabic)
			{
				this.sb.AppendFormat("{0}-", iValue);
			}
			else
			{
				this.sb.AppendFormat("-{0}", iValue);
			}
			if (Side == 0)
			{
				damageValue.m_Text.color = this.m_RedColor;
			}
			else
			{
				damageValue.m_Text.color = this.m_RedColor1;
			}
			this.OpenBloodShow(Side, iIndex);
			break;
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_RECOVER:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_RECOVER_CIR:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_HOT:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_HOT_CIR:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_HEMOPHAGIA:
			damageValue.fShowTime = 0.9f;
			if (GUIManager.Instance.IsArabic)
			{
				this.sb.AppendFormat("{0}+", iValue);
			}
			else
			{
				this.sb.AppendFormat("+{0}", iValue);
			}
			if (Side == 0)
			{
				damageValue.m_Text.color = this.m_GreenColor;
			}
			else
			{
				damageValue.m_Text.color = this.m_GreenColor1;
			}
			damageValue.m_RT.anchoredPosition += new Vector2(0f, (float)b);
			this.OpenBloodShow(Side, iIndex);
			break;
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_ADDENERGY:
			damageValue.fShowTime = 0.5f;
			if (GUIManager.Instance.IsArabic)
			{
				this.sb.AppendFormat("{0}+", iValue);
			}
			else
			{
				this.sb.AppendFormat("+{0}", iValue);
			}
			damageValue.m_Text.color = this.m_EnergyColor;
			damageValue.m_RT.anchoredPosition += new Vector2(0f, (float)(b * 3));
			break;
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_SUBENERGY:
			damageValue.fShowTime = 0.6f;
			if (GUIManager.Instance.IsArabic)
			{
				this.sb.AppendFormat("{0}-", iValue);
			}
			else
			{
				this.sb.AppendFormat("-{0}", iValue);
			}
			damageValue.m_Text.color = this.m_EnergyColor;
			break;
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DODGE:
			this.sb.Append(DataManager.Instance.mStringTable.GetStringByID(95u));
			damageValue.fShowTime = 0.6f;
			if (Side == 0)
			{
				damageValue.m_Text.color = this.m_BlueColor;
			}
			else
			{
				damageValue.m_Text.color = this.m_BlueColor1;
			}
			damageValue.m_RT.anchoredPosition -= new Vector2(0f, (float)b);
			break;
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_IMM:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_IMM_BUFF:
			this.sb.Append(DataManager.Instance.mStringTable.GetStringByID(96u));
			damageValue.fShowTime = 0.6f;
			if (Side == 0)
			{
				damageValue.m_Text.color = this.m_BlueColor;
			}
			else
			{
				damageValue.m_Text.color = this.m_BlueColor1;
			}
			damageValue.m_RT.anchoredPosition -= new Vector2(0f, (float)b);
			break;
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_PHYSIMM:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_PHYSIMM_BUFF:
			this.sb.Append(DataManager.Instance.mStringTable.GetStringByID(97u));
			damageValue.fShowTime = 0.6f;
			if (Side == 0)
			{
				damageValue.m_Text.color = this.m_BlueColor;
			}
			else
			{
				damageValue.m_Text.color = this.m_BlueColor1;
			}
			damageValue.m_RT.anchoredPosition -= new Vector2(0f, (float)b);
			break;
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_MAGIIMM:
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_MAGIIMM_BUFF:
			this.sb.Append(DataManager.Instance.mStringTable.GetStringByID(98u));
			damageValue.fShowTime = 0.6f;
			if (Side == 0)
			{
				damageValue.m_Text.color = this.m_BlueColor;
			}
			else
			{
				damageValue.m_Text.color = this.m_BlueColor1;
			}
			damageValue.m_RT.anchoredPosition -= new Vector2(0f, (float)b);
			break;
		case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_CIR:
			if (GUIManager.Instance.IsArabic)
			{
				this.sb.AppendFormat("{0}-", iValue);
			}
			else
			{
				this.sb.AppendFormat("-{0}", iValue);
			}
			if (Side == 0)
			{
				damageValue.m_Text.color = this.m_RedColor;
			}
			else
			{
				damageValue.m_Text.color = this.m_RedColor1;
			}
			this.OpenBloodShow(Side, iIndex);
			break;
		}
		damageValue.bCritical = this.CheckisCritical(Type);
		if (damageValue.bCritical)
		{
			damageValue.m_transform.SetParent(this.DamageValueLayer_CRINum, false);
			this.m_Vec3.x = this.DVScaleC;
			this.m_Vec3.y = this.DVScaleC;
			this.m_Vec3.z = this.DVScaleC;
			damageValue.m_RT.localScale = this.m_Vec3;
			damageValue.fShowTime = 1.5f;
		}
		else
		{
			damageValue.m_transform.SetParent(this.DamageValueLayer_Normal, false);
		}
		damageValue.m_RT.localScale *= this.DVScale;
		damageValue.fShowTime += 0.4f;
		damageValue.m_Text.text = this.sb.ToString();
		this.DVList.Add(damageValue);
	}

	// Token: 0x0600028B RID: 651 RVA: 0x00021730 File Offset: 0x0001F930
	private void InitialBloodBar()
	{
		Transform child = this.baseLayer.GetChild(0);
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/PlayerBar", out this.AssetKey_Bar, false);
		if (assetBundle == null)
		{
			return;
		}
		UnityEngine.Object[] array = assetBundle.LoadAll(typeof(Sprite));
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].name[0] >= '0' && array[i].name[0] <= '9')
			{
				this.m_Dict.Add(ushort.Parse(array[i].name), (Sprite)array[i]);
			}
		}
		for (int j = 0; j < 2; j++)
		{
			List<BloodBar> list;
			string name;
			int num;
			if (j == 0)
			{
				list = this.Player;
				name = this.PlayerName;
				num = this.PlayerCount;
			}
			else
			{
				list = this.Enemy;
				name = this.EnemyName;
				num = this.EnemyCount;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(assetBundle.Load(name)) as GameObject;
			gameObject.name = name;
			gameObject.transform.SetParent(child, false);
			BloodBar bloodBar = new BloodBar();
			bloodBar.m_GameObject = gameObject;
			bloodBar.m_transform = gameObject.transform;
			bloodBar.m_RT = gameObject.GetComponent<RectTransform>();
			bloodBar.m_BarTransform = gameObject.transform.GetChild(0);
			bloodBar.m_IconTransform = gameObject.transform.GetChild(1);
			bloodBar.m_BarTransform.gameObject.SetActive(false);
			if (this.wm != null && j == 0)
			{
				bloodBar.m_BarTransform.GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(1);
			}
			for (int k = 0; k < 3; k++)
			{
				Transform child2 = bloodBar.m_BarTransform.GetChild(k);
				bloodBar.m_BarRT[k] = child2.GetComponent<RectTransform>();
				bloodBar.m_BarImg[k] = child2.GetComponent<Image>();
				child2 = bloodBar.m_IconTransform.GetChild(k);
				bloodBar.m_IconRT[k] = child2.GetComponent<RectTransform>();
				bloodBar.m_IconImg[k] = child2.GetComponent<Image>();
				child2.gameObject.SetActive(false);
			}
			if (this.wm != null)
			{
				bloodBar.m_BarRT[0].offsetMin = new Vector2(8f, 3f);
				bloodBar.m_BarRT[0].offsetMax = new Vector2(-8f, -3f);
				bloodBar.m_BarRT[1].offsetMin = new Vector2(10f, 5f);
				bloodBar.m_BarRT[1].offsetMax = new Vector2(72f, -5f);
				bloodBar.m_BarRT[2].offsetMin = new Vector2(10f, 5f);
				bloodBar.m_BarRT[2].offsetMax = new Vector2(72f, -5f);
			}
			this.m_Vec3.Set(0.6f, 0.6f, 0.6f);
			bloodBar.m_RT.localScale = this.m_Vec3;
			list.Add(bloodBar);
			for (int l = 1; l < num; l++)
			{
				bloodBar = new BloodBar();
				bloodBar.m_GameObject = (UnityEngine.Object.Instantiate(gameObject) as GameObject);
				bloodBar.m_GameObject.name = name;
				bloodBar.m_GameObject.transform.SetParent(child, false);
				bloodBar.m_transform = bloodBar.m_GameObject.transform;
				bloodBar.m_RT = bloodBar.m_GameObject.GetComponent<RectTransform>();
				bloodBar.m_BarTransform = bloodBar.m_GameObject.transform.GetChild(0);
				bloodBar.m_IconTransform = bloodBar.m_GameObject.transform.GetChild(1);
				bloodBar.m_BarTransform.gameObject.SetActive(false);
				for (int m = 0; m < 3; m++)
				{
					Transform child2 = bloodBar.m_BarTransform.GetChild(m);
					bloodBar.m_BarRT[m] = child2.GetComponent<RectTransform>();
					bloodBar.m_BarImg[m] = child2.GetComponent<Image>();
					child2 = bloodBar.m_IconTransform.GetChild(m);
					bloodBar.m_IconRT[m] = child2.GetComponent<RectTransform>();
					bloodBar.m_IconImg[m] = child2.GetComponent<Image>();
					child2.gameObject.SetActive(false);
				}
				if (this.wm != null && l == num - 1)
				{
					((RectTransform)bloodBar.m_BarTransform).sizeDelta = new Vector2(136f, 20f);
					bloodBar.m_BarRT[0].offsetMin = new Vector2(0f, 0f);
					bloodBar.m_BarRT[0].offsetMax = new Vector2(0f, 0f);
					bloodBar.m_BarRT[1].offsetMin = new Vector2(4f, 3f);
					bloodBar.m_BarRT[1].offsetMax = new Vector2(132f, -3f);
					bloodBar.m_BarRT[2].offsetMin = new Vector2(4f, 3f);
					bloodBar.m_BarRT[2].offsetMax = new Vector2(132f, -3f);
				}
				list.Add(bloodBar);
			}
		}
	}

	// Token: 0x0600028C RID: 652 RVA: 0x00021C8C File Offset: 0x0001FE8C
	private void DeleteBloodBar()
	{
		for (int i = this.PlayerCount - 1; i >= 0; i--)
		{
			UnityEngine.Object.Destroy(this.Player[i].m_GameObject);
			this.Player[i].m_GameObject = null;
			this.Player[i].m_transform = null;
			this.Player[i].m_RT = null;
			this.Player[i].m_BarTransform = null;
			this.Player[i].m_IconTransform = null;
			for (int j = 0; j < 3; j++)
			{
				this.Player[i].m_BarRT[j] = null;
				this.Player[i].m_BarImg[j] = null;
				this.Player[i].m_IconRT[j] = null;
				this.Player[i].m_IconImg[j] = null;
			}
			this.Player.RemoveAt(i);
		}
		for (int k = this.EnemyCount - 1; k >= 0; k--)
		{
			UnityEngine.Object.Destroy(this.Enemy[k].m_GameObject);
			this.Enemy[k].m_GameObject = null;
			this.Enemy[k].m_transform = null;
			this.Enemy[k].m_RT = null;
			this.Enemy[k].m_BarTransform = null;
			this.Enemy[k].m_IconTransform = null;
			for (int l = 0; l < 3; l++)
			{
				this.Enemy[k].m_BarRT[l] = null;
				this.Enemy[k].m_BarImg[l] = null;
				this.Enemy[k].m_IconRT[l] = null;
				this.Enemy[k].m_IconImg[l] = null;
			}
			this.Enemy.RemoveAt(k);
		}
		this.m_Dict.Clear();
	}

	// Token: 0x0600028D RID: 653 RVA: 0x00021E94 File Offset: 0x00020094
	private void UpDateBloodBarPos()
	{
		float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
		if (this.bc != null)
		{
			for (int i = 0; i < 2; i++)
			{
				List<BloodBar> list;
				AnimationUnit[] array;
				int num;
				int num2;
				if (i == 0)
				{
					list = this.Player;
					array = this.bc.playerUnit;
					num = this.bc.playerCount;
					num2 = this.PlayerCount;
				}
				else
				{
					list = this.Enemy;
					array = this.bc.enemyUnit;
					num = this.bc.enemyCount;
					num2 = this.EnemyCount;
				}
				int num3 = 0;
				while (num3 < num2 && num3 < num)
				{
					if (!(array[num3] == null))
					{
						if (list[num3].bShow || list[num3].bShowState)
						{
							this.m_Vec3.x = 0f;
							this.m_Vec3.y = array[num3].BoundingHight;
							this.m_Vec3.z = 0f;
							Vector3 vector = array[num3].Position;
							vector = Camera.main.WorldToScreenPoint(vector + this.m_Vec3);
							vector /= scaleFactor;
							list[num3].m_RT.anchoredPosition = vector;
						}
					}
					num3++;
				}
			}
		}
		else if (this.wm != null)
		{
			for (int j = 0; j < 2; j++)
			{
				List<BloodBar> list;
				int num4;
				int num5;
				if (j == 0)
				{
					list = this.Player;
					num4 = (int)this.wm.playerCount;
					num5 = this.PlayerCount;
				}
				else
				{
					list = this.Enemy;
					num4 = (int)this.wm.enemyCount;
					num5 = this.EnemyCount;
				}
				int k = 0;
				while (k < num5)
				{
					Vector3 vector2;
					if (k < num4)
					{
						if (j == 0)
						{
							if (this.wm.playerSideArmies[k] == null)
							{
								goto IL_3BC;
							}
							vector2 = this.wm.playerSideArmies[k].GetBloodBarPos();
						}
						else
						{
							if (this.wm.enemySideArmies[k] == null)
							{
								goto IL_3BC;
							}
							vector2 = this.wm.enemySideArmies[k].GetBloodBarPos();
						}
						goto IL_2EC;
					}
					if (k == 16)
					{
						if (j == 0)
						{
							if (this.wm.playerSideArmies[k] == null)
							{
								goto IL_3BC;
							}
							vector2 = this.wm.playerSideArmies[16].groupRoot.position + this.wm.CastleBloodBarOffset;
						}
						else
						{
							if (this.wm.enemySideArmies[k] == null)
							{
								goto IL_3BC;
							}
							vector2 = this.wm.enemySideArmies[16].groupRoot.position + this.wm.CastleBloodBarOffset;
						}
						goto IL_2EC;
					}
					IL_3BC:
					k++;
					continue;
					IL_2EC:
					if (!list[k].bShow && !list[k].bShowState)
					{
						goto IL_3BC;
					}
					this.m_Vec3.x = 0f;
					this.m_Vec3.y = 5f;
					this.m_Vec3.z = 0f;
					Vector3 vector3 = vector2;
					vector3 = Camera.main.WorldToScreenPoint(vector3 + this.m_Vec3);
					vector3 /= scaleFactor;
					if (k == 16)
					{
						list[k].m_RT.anchoredPosition = new Vector2((float)((int)vector3.x), (float)((int)vector3.y));
						goto IL_3BC;
					}
					list[k].m_RT.anchoredPosition = vector3;
					goto IL_3BC;
				}
			}
		}
	}

	// Token: 0x0600028E RID: 654 RVA: 0x0002227C File Offset: 0x0002047C
	private void UpDateBloodBarWidth()
	{
		if (this.bc == null && this.wm == null)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		for (int i = 0; i < 2; i++)
		{
			List<BloodBar> list;
			int num;
			if (i == 0)
			{
				list = this.Player;
				num = this.PlayerCount;
			}
			else
			{
				list = this.Enemy;
				num = this.EnemyCount;
			}
			for (int j = 0; j < num; j++)
			{
				if (list[j].bShow && !list[j].bForceShowBlood)
				{
					list[j].fTime -= deltaTime;
					if (list[j].fTime <= 0.8f || list[j].m_BarImg[1].fillAmount <= 0f)
					{
						float num2 = deltaTime * 5f;
						Color color = list[j].m_BarImg[0].color;
						color.a -= num2;
						if (color.a <= 0f)
						{
							Color color2 = list[j].m_BarImg[1].color;
							Color color3 = list[j].m_BarImg[2].color;
							color.a = 1f;
							color2.a = 1f;
							color3.a = 1f;
							list[j].m_BarImg[0].color = color;
							list[j].m_BarImg[1].color = color2;
							list[j].m_BarImg[2].color = color3;
							list[j].m_BarImg[1].fillAmount = list[j].TargetWidth;
							list[j].m_BarTransform.gameObject.SetActive(false);
							list[j].bShow = false;
							goto IL_335;
						}
						Color color4 = list[j].m_BarImg[1].color;
						Color color5 = list[j].m_BarImg[2].color;
						color4.a = color.a;
						color5.a = color.a;
						list[j].m_BarImg[0].color = color;
						list[j].m_BarImg[1].color = color4;
						list[j].m_BarImg[2].color = color5;
					}
					list[j].m_BarImg[1].fillAmount -= list[j].DeltaX;
					if ((list[j].DeltaX >= 0f && list[j].m_BarImg[1].fillAmount <= list[j].TargetWidth) || (list[j].DeltaX <= 0f && list[j].m_BarImg[1].fillAmount >= list[j].TargetWidth))
					{
						list[j].m_BarImg[1].fillAmount = list[j].TargetWidth;
					}
				}
				IL_335:;
			}
		}
	}

	// Token: 0x0600028F RID: 655 RVA: 0x000225D8 File Offset: 0x000207D8
	public void OpenBloodShow(int side, int iIndex)
	{
		float num = 0f;
		List<BloodBar> list;
		float num3;
		float num4;
		if (this.bc != null)
		{
			if (this.bc.BattleType == EBattleType.PLAYBACK && side == 1)
			{
				return;
			}
			BattleController.HeroAttr[] array;
			int num2;
			if (side == 0)
			{
				list = this.Player;
				array = this.bc.playerAttr;
				num2 = this.PlayerCount;
			}
			else
			{
				list = this.Enemy;
				array = this.bc.enemyAttr;
				num2 = this.EnemyCount;
			}
			if (iIndex < 0 || iIndex >= num2)
			{
				return;
			}
			num3 = array[iIndex].MAX_HP;
			num4 = array[iIndex].CUR_HP;
		}
		else
		{
			if (this.wm == null)
			{
				return;
			}
			if (side == 0)
			{
				list = this.Player;
				int num2 = this.PlayerCount;
				if (iIndex < 0 || iIndex >= num2)
				{
					return;
				}
				num3 = (float)this.wm.playerSideArmies[iIndex].MaxHP;
				num4 = (float)this.wm.playerSideArmies[iIndex].CurHP;
			}
			else
			{
				list = this.Enemy;
				int num2 = this.EnemyCount;
				if (iIndex < 0 || iIndex >= num2)
				{
					return;
				}
				num3 = (float)this.wm.enemySideArmies[iIndex].MaxHP;
				num4 = (float)this.wm.enemySideArmies[iIndex].CurHP;
			}
			num = 2f;
		}
		if (list[iIndex].TargetWidth <= 0f)
		{
			return;
		}
		if (num3 > 0f && num3 > num4)
		{
			list[iIndex].TargetWidth = num4 / num3;
		}
		else
		{
			list[iIndex].TargetWidth = 1f;
		}
		if (list[iIndex].m_BarImg[1].fillAmount > list[iIndex].TargetWidth)
		{
			list[iIndex].DeltaX = (list[iIndex].m_BarImg[1].fillAmount - list[iIndex].TargetWidth) * 0.0500000045f;
		}
		else
		{
			list[iIndex].DeltaX = 0f;
		}
		list[iIndex].m_BarImg[2].fillAmount = list[iIndex].TargetWidth;
		list[iIndex].m_BarTransform.gameObject.SetActive(true);
		list[iIndex].bShow = true;
		list[iIndex].bForceShowBlood = false;
		list[iIndex].fTime = 2.3f + num;
		Color color = list[iIndex].m_BarImg[0].color;
		Color color2 = list[iIndex].m_BarImg[1].color;
		Color color3 = list[iIndex].m_BarImg[2].color;
		color.a = 1f;
		color2.a = 1f;
		color3.a = 1f;
		list[iIndex].m_BarImg[0].color = color;
		list[iIndex].m_BarImg[1].color = color2;
		list[iIndex].m_BarImg[2].color = color3;
		this.UpDateBloodBarPos();
	}

	// Token: 0x06000290 RID: 656 RVA: 0x0002290C File Offset: 0x00020B0C
	private void ResetBloodBar(bool bResetPlayer = true)
	{
		for (int i = 0; i < this.Player.Count; i++)
		{
			if (bResetPlayer)
			{
				this.Player[i].TargetWidth = 1f;
				this.Player[i].m_BarImg[1].fillAmount = 1f;
				this.Player[i].m_BarImg[2].fillAmount = 1f;
			}
			this.Player[i].m_BarTransform.gameObject.SetActive(false);
			this.Player[i].bShow = false;
			this.Player[i].bForceShowBlood = false;
		}
		for (int j = 0; j < this.Enemy.Count; j++)
		{
			this.Enemy[j].TargetWidth = 1f;
			this.Enemy[j].m_BarImg[1].fillAmount = 1f;
			this.Enemy[j].m_BarImg[2].fillAmount = 1f;
			this.Enemy[j].m_BarTransform.gameObject.SetActive(false);
			this.Enemy[j].bShow = false;
			this.Enemy[j].bForceShowBlood = false;
		}
	}

	// Token: 0x06000291 RID: 657 RVA: 0x00022A78 File Offset: 0x00020C78
	public void ShowBloodBar(int side, int iIndex)
	{
		if (this.bc == null)
		{
			return;
		}
		List<BloodBar> list;
		BattleController.HeroAttr[] array;
		int num;
		AnimationUnit[] array2;
		if (side == 0)
		{
			list = this.Player;
			array = this.bc.playerAttr;
			num = this.PlayerCount;
			array2 = this.bc.playerUnit;
		}
		else
		{
			list = this.Enemy;
			array = this.bc.enemyAttr;
			num = this.EnemyCount;
			array2 = this.bc.enemyUnit;
		}
		if (iIndex < 0 || iIndex >= num || list[iIndex].TargetWidth <= 0f)
		{
			return;
		}
		float num2 = array[iIndex].MAX_HP;
		float num3 = array[iIndex].CUR_HP;
		if (num2 > 0f && num2 > num3)
		{
			list[iIndex].TargetWidth = num3 / num2;
		}
		else
		{
			list[iIndex].TargetWidth = 1f;
		}
		if (list[iIndex].m_BarImg[1].fillAmount > list[iIndex].TargetWidth)
		{
			list[iIndex].DeltaX = (list[iIndex].m_BarImg[1].fillAmount - list[iIndex].TargetWidth) * 0.0500000045f;
		}
		else
		{
			list[iIndex].DeltaX = 0f;
		}
		list[iIndex].m_BarImg[2].fillAmount = list[iIndex].TargetWidth;
		list[iIndex].m_BarTransform.gameObject.SetActive(true);
		list[iIndex].bForceShowBlood = true;
		Color color = list[iIndex].m_BarImg[0].color;
		Color color2 = list[iIndex].m_BarImg[1].color;
		Color color3 = list[iIndex].m_BarImg[2].color;
		color.a = 1f;
		color2.a = 1f;
		color3.a = 1f;
		list[iIndex].m_BarImg[0].color = color;
		list[iIndex].m_BarImg[1].color = color2;
		list[iIndex].m_BarImg[2].color = color3;
		this.m_Vec3.x = 0f;
		this.m_Vec3.y = array2[iIndex].BoundingHight;
		this.m_Vec3.z = 0f;
		Vector3 vector = array2[iIndex].Position;
		vector = Camera.main.WorldToScreenPoint(vector + this.m_Vec3);
		vector /= GUIManager.Instance.m_UICanvas.scaleFactor;
		list[iIndex].m_RT.anchoredPosition = vector;
	}

	// Token: 0x06000292 RID: 658 RVA: 0x00022D48 File Offset: 0x00020F48
	public void HideBloodBar(int side, int iIndex)
	{
		if (side == 0)
		{
			if (iIndex < 0 || iIndex >= this.PlayerCount)
			{
				return;
			}
			this.Player[iIndex].m_BarTransform.gameObject.SetActive(false);
			this.Player[iIndex].bForceShowBlood = false;
		}
		else
		{
			if (iIndex < 0 || iIndex >= this.EnemyCount)
			{
				return;
			}
			this.Enemy[iIndex].m_BarTransform.gameObject.SetActive(false);
			this.Enemy[iIndex].bForceShowBlood = false;
		}
	}

	// Token: 0x06000293 RID: 659 RVA: 0x00022DE4 File Offset: 0x00020FE4
	public void SetBloodBarFillAmount(int side, int iIndex, float fillAmount)
	{
		if (side == 0)
		{
			if (iIndex < 0 || iIndex >= this.PlayerCount)
			{
				return;
			}
			this.Player[iIndex].TargetWidth = fillAmount;
			this.Player[iIndex].m_BarImg[1].fillAmount = fillAmount;
			this.Player[iIndex].m_BarImg[2].fillAmount = fillAmount;
		}
		else
		{
			if (iIndex < 0 || iIndex >= this.EnemyCount)
			{
				return;
			}
			this.Enemy[iIndex].TargetWidth = fillAmount;
			this.Enemy[iIndex].m_BarImg[1].fillAmount = fillAmount;
			this.Enemy[iIndex].m_BarImg[2].fillAmount = fillAmount;
		}
	}

	// Token: 0x06000294 RID: 660 RVA: 0x00022EAC File Offset: 0x000210AC
	private void UpDateStateFade()
	{
		if (this.bc == null)
		{
			return;
		}
		float num = Time.smoothDeltaTime * 4f;
		for (int i = 0; i < 2; i++)
		{
			List<BloodBar> list;
			int num2;
			if (i == 0)
			{
				list = this.Player;
				num2 = this.PlayerCount;
			}
			else
			{
				list = this.Enemy;
				num2 = this.EnemyCount;
			}
			for (int j = 0; j < num2; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					if (list[j].FadeNum[k] != 0)
					{
						list[j].m_IconImg[k].color += new Color(0f, 0f, 0f, num * (float)list[j].FadeNum[k]);
						if (list[j].FadeNum[k] == 1 && list[j].m_IconImg[k].color.a >= 1f)
						{
							list[j].FadeNum[k] = 0;
							list[j].m_IconImg[k].color = Color.white;
						}
						if (list[j].FadeNum[k] == -1 && list[j].m_IconImg[k].color.a <= 0f)
						{
							list[j].FadeNum[k] = 0;
							list[j].m_IconImg[k].color = Color.white;
							list[j].m_IconRT[k].gameObject.SetActive(false);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000295 RID: 661 RVA: 0x00023084 File Offset: 0x00021284
	public void CheckBuffIcon(byte HeroOrEnemy, byte HEIndex)
	{
		if (this.bc == null || BattleController.IsGambleMode)
		{
			return;
		}
		List<BloodBar> list;
		AnimationUnit[] array;
		int num;
		if (HeroOrEnemy == 0)
		{
			list = this.Player;
			array = this.bc.playerUnit;
			num = this.PlayerCount;
		}
		else
		{
			list = this.Enemy;
			array = this.bc.enemyUnit;
			num = this.EnemyCount;
		}
		if ((int)HEIndex < num)
		{
			int count = array[(int)HEIndex].StateEffList.Count;
			for (int i = 0; i < 3; i++)
			{
				if (i < count)
				{
					Sprite sprite = null;
					byte b = array[(int)HEIndex].StateEffList[i];
					if (b > 0 && b <= 6)
					{
						this.m_Dict.TryGetValue((ushort)((int)b + 300), out sprite);
					}
					else
					{
						Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey((ushort)(b - 6));
						this.m_Dict.TryGetValue(recordByKey.StatusIcon, out sprite);
						if (sprite == null)
						{
							if (b > 1 && b <= 100)
							{
								this.m_Dict.TryGetValue(254, out sprite);
							}
							else if (b > 100 && b <= 200)
							{
								this.m_Dict.TryGetValue(255, out sprite);
							}
						}
					}
					list[(int)HEIndex].m_IconRT[i].gameObject.SetActive(true);
					list[(int)HEIndex].m_IconImg[i].sprite = sprite;
					if (list[(int)HEIndex].StateID[i] == 0)
					{
						list[(int)HEIndex].m_IconImg[i].color = new Color(1f, 1f, 1f, 0f);
						list[(int)HEIndex].FadeNum[i] = 1;
					}
					list[(int)HEIndex].StateID[i] = b;
				}
				else
				{
					bool flag = false;
					for (int j = 0; j < i; j++)
					{
						if (list[(int)HEIndex].StateID[i] == list[(int)HEIndex].StateID[j])
						{
							flag = true;
						}
					}
					if (!flag)
					{
						list[(int)HEIndex].FadeNum[i] = -1;
						list[(int)HEIndex].StateID[i] = 0;
					}
					else
					{
						list[(int)HEIndex].m_IconRT[i].gameObject.SetActive(false);
					}
				}
			}
			if (count > 0)
			{
				float num2 = 0f;
				for (int k = 0; k < 3; k++)
				{
					list[(int)HEIndex].m_IconRT[k].sizeDelta = new Vector2(36f, 36f);
					list[(int)HEIndex].m_IconRT[k].anchoredPosition = new Vector2(num2, -10f);
					num2 += 38f;
				}
				list[(int)HEIndex].bShowState = true;
			}
			else
			{
				list[(int)HEIndex].bShowState = false;
			}
		}
	}

	// Token: 0x06000296 RID: 662 RVA: 0x00023398 File Offset: 0x00021598
	private void ResetState()
	{
		for (int i = 0; i < 2; i++)
		{
			List<BloodBar> list;
			if (i == 0)
			{
				list = this.Player;
			}
			else
			{
				list = this.Enemy;
			}
			for (int j = 0; j < list.Count; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					list[j].m_IconImg[k].color = Color.white;
					list[j].FadeNum[k] = 0;
					list[j].m_IconRT[k].gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06000297 RID: 663 RVA: 0x0002343C File Offset: 0x0002163C
	public void NextTransitions(eTrans kind, eTransFunc FKind = eTransFunc.Max)
	{
		switch (kind)
		{
		case eTrans.BEGIN:
			if (this.NowFuncKind != eTransFunc.Max)
			{
				return;
			}
			if (NewbieManager.IsNewbie)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Front, 4, 0);
			}
			GUIManager.Instance.ShowUILock(EUILock.Normal);
			GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Transition);
			if (FKind == eTransFunc.MapToWar)
			{
				DataManager.Instance.WorldCameraTransitionsPos = GameConstants.GoldGuy;
			}
			this.NowFuncKind = FKind;
			this.InitialTransition();
			this.BeginTransitions(true);
			if (GUIManager.Instance.m_ItemInfo.m_RectTransform.gameObject.activeSelf)
			{
				GUIManager.Instance.m_ItemInfo.Hide();
			}
			break;
		case eTrans.END:
			if (NewbieManager.IsNewbie)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Front, 5, 0);
			}
			if (this.bTranstions == 3)
			{
				this.BeginTransitions(false);
			}
			break;
		case eTrans.FORCEEND:
			this.EndTransitions();
			break;
		}
	}

	// Token: 0x06000298 RID: 664 RVA: 0x00023538 File Offset: 0x00021738
	private void TransitionFunc()
	{
		switch (this.NowFuncKind)
		{
		case eTransFunc.Battle:
			if (this.bc != null)
			{
				this.bc.NextLevel();
			}
			break;
		case eTransFunc.MapToBattle:
		case eTransFunc.WarToBattle:
		case eTransFunc.MonsterBattle:
		case eTransFunc.GambleBattle:
			GameManager.SwitchGameplay(GameplayKind.Battle);
			GUIManager.Instance.SetBattleMessageButton(false);
			break;
		case eTransFunc.BattleToMap:
			GUIManager.Instance.OpenABColor();
			GUIManager.Instance.m_UICanvas.renderMode = RenderMode.ScreenSpaceOverlay;
			GUIManager.Instance.SetCanvasChanged();
			GameManager.SwitchGameplay(DataManager.Instance.GoToBattleOrWar);
			GUIManager.Instance.SetBattleMessageButton(true);
			break;
		case eTransFunc.NextStage:
			DataManager.msgBuffer[0] = 5;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_StageSelect, 0, 0);
			break;
		case eTransFunc.PrevStage:
			DataManager.msgBuffer[0] = 6;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_StageSelect, 0, 0);
			break;
		case eTransFunc.ChangeStage:
			DataManager.msgBuffer[0] = 35;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_StageSelect, 0, 0);
			break;
		case eTransFunc.ChangeToKing:
			DataManager.StageDataController.ReBackCurrentChapter();
			NewbieManager.EntryLock = true;
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 2, 0);
			NewbieManager.EntryLock = false;
			break;
		case eTransFunc.ChangeToMap:
			DataManager.MapDataController.ClearLayoutMapInfoYolkKind();
			DataManager.StageDataController.ReBackCurrentChapter();
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 3, 0);
			break;
		case eTransFunc.ChangeToWorld:
			DataManager.MapDataController.ClearLayoutMapInfoYolkKind();
			DataManager.StageDataController.ReBackCurrentChapter();
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 4, 0);
			break;
		case eTransFunc.BattleReplay:
		case eTransFunc.BattleReplay_Dare:
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_Settlement);
			GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle).gameObject.SetActive(true);
			if (this.bc != null)
			{
				this.bc.ResetLevel();
			}
			break;
		case eTransFunc.BattleReplay_Force:
			if (this.bc != null)
			{
				this.bc.ResetLevel();
			}
			break;
		case eTransFunc.WarToMap:
			GUIManager.Instance.OpenABColor();
			GUIManager.Instance.m_UICanvas.renderMode = RenderMode.ScreenSpaceOverlay;
			GUIManager.Instance.SetCanvasChanged();
			GameManager.SwitchGameplay(DataManager.Instance.GoToBattleOrWar);
			GUIManager.Instance.SetBattleMessageButton(true);
			break;
		case eTransFunc.MapToWar:
		case eTransFunc.MapToWar_Stage:
		case eTransFunc.MapToWar_CoordTest:
			WarManager.WarKind = ((this.NowFuncKind != eTransFunc.MapToWar_CoordTest) ? WarManager.EWarKind.Normal : WarManager.EWarKind.CoordTest);
			GameManager.SwitchGameplay(GameplayKind.War);
			GUIManager.Instance.SetBattleMessageButton(false);
			break;
		case eTransFunc.DoorOpenUp:
			DataManager.msgBuffer[0] = 40;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			break;
		case eTransFunc.DoorWild:
			DataManager.msgBuffer[0] = 21;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			break;
		case eTransFunc.GambleSwitchMode:
			if (this.bc != null)
			{
				this.bc.ResetGamble();
			}
			break;
		}
		DataManager.Instance.UpdateMailData(true);
	}

	// Token: 0x06000299 RID: 665 RVA: 0x0002383C File Offset: 0x00021A3C
	private void TransitionBeginFunc()
	{
		switch (this.NowFuncKind)
		{
		case eTransFunc.Battle:
			if (this.bc != null && this.bc.m_CurStageLevel == this.bc.m_MaxStageLevel - 1)
			{
				this.bNeedShowBoss = true;
			}
			break;
		case eTransFunc.MapToBattle:
		case eTransFunc.WarToBattle:
		case eTransFunc.MonsterBattle:
		case eTransFunc.GambleBattle:
			AudioManager.Instance.LoadAndPlayBGM(BGMType.War, 1, false);
			break;
		case eTransFunc.BattleToMap:
			GUIManager.Instance.BattleCloseChatBox();
			break;
		case eTransFunc.Test:
			this.bBossTest = true;
			this.bNeedShowBoss = true;
			break;
		}
	}

	// Token: 0x0600029A RID: 666 RVA: 0x00023954 File Offset: 0x00021B54
	private void TransitionEndFunc()
	{
		switch (this.NowFuncKind)
		{
		case eTransFunc.Battle:
			this.BeginMoveBossText();
			break;
		case eTransFunc.BattleToMap:
			DataManager.msgBuffer[0] = 22;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			if (BattleNetwork.NetworkError != 0)
			{
				BattleNetwork.NetworkError = 0;
				GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4834u), DataManager.Instance.mStringTable.GetStringByID(114u), DataManager.Instance.mStringTable.GetStringByID(4836u), null, 0, 0, false, false, false, false, false);
			}
			GUIManager.Instance.CheckSuggestion();
			GUIManager.Instance.RestoreQueuedUI();
			if (GamblingManager.Instance.bOpenTreasure == 1)
			{
				GamblingManager.Instance.bOpenTreasure = 0;
				MallManager.Instance.Send_Mall_Info();
			}
			break;
		case eTransFunc.NextStage:
			DataManager.msgBuffer[0] = 22;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			break;
		case eTransFunc.ChangeStage:
			DataManager.msgBuffer[0] = 22;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			if (NewbieManager.IsTeachWorking(ETeachKind.DARE_FULL))
			{
				NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, false);
			}
			break;
		case eTransFunc.ChangeToKing:
			Camera.main.cullingMask |= 1;
			NewbieManager.CheckWorldTeach();
			break;
		case eTransFunc.ChangeToMap:
			Indemnify.CheckShowIndemnify();
			ActivityGiftManager.Instance.CheckShowActivityGiftEffect();
			break;
		case eTransFunc.ChangeToWorld:
			Camera.main.cullingMask |= 1;
			break;
		case eTransFunc.WarToMap:
		case eTransFunc.MapToWar_Stage:
			if (DataManager.StageDataController._stageMode == StageMode.Corps)
			{
				DataManager.msgBuffer[0] = 22;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			GUIManager.Instance.RestoreQueuedUI();
			break;
		case eTransFunc.DoorOpenUp:
			DataManager.msgBuffer[0] = 22;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			if (NewbieManager.IsTeachWorking(ETeachKind.DARE_FULL))
			{
				NewbieManager.CheckTeach(ETeachKind.DARE_FULL, null, false);
			}
			break;
		case eTransFunc.DoorWild:
			NewbieManager.EntryTest();
			Indemnify.CheckShowIndemnify();
			ActivityGiftManager.Instance.CheckShowActivityGiftEffect();
			break;
		case eTransFunc.Test:
			this.BeginMoveBossText();
			break;
		}
	}

	// Token: 0x0600029B RID: 667 RVA: 0x00023BB0 File Offset: 0x00021DB0
	private void UpDateTransitions()
	{
		if (this.NowFuncKind == eTransFunc.Max || this.CanvasRT == null || this.TRT1 == null)
		{
			return;
		}
		float unscaledDeltaTime = Time.unscaledDeltaTime;
		if (this.bTranstions != 0)
		{
			this.fTransitionsTime += unscaledDeltaTime;
		}
		if (this.bTranstions == 2 && (this.bAxeOutNew || this.bCastleOutNew))
		{
			this.dTime += unscaledDeltaTime;
		}
		if (this.fTransitionsTime >= 0.033f)
		{
			this.fTransitionsTime = 0f;
			if (this.NowTransKind == eTransKind.WhiteScaleAxe)
			{
				if (this.bTranstions == 1)
				{
					if (this.bAxeInNew)
					{
						this.nowSize -= this.DeltaSize;
						this.setMsize();
						if (this.nowSize <= this.sizeMin)
						{
							this.nowSize = this.sizeMin;
							this.setMsize();
							this.bTranstions = 3;
							this.TransitionFunc();
						}
					}
					else
					{
						float num = this.TransitionsSpeed * 6f;
						if (this.TRT1.localScale.x <= 10f)
						{
							num *= 0.5f;
						}
						this.m_Vec3.Set(num, num, num);
						this.TRT1.localScale += this.m_Vec3;
						if (this.TImage.color.a < 1f)
						{
							this.m_Color = this.TImage.color;
							this.m_Color.a = this.m_Color.a + num * 4f / 255f;
							if (this.m_Color.a >= 1f)
							{
								this.TImage.color = Color.white;
								this.TImage06.color = Color.white;
							}
							else
							{
								this.TImage.color = this.m_Color;
								this.TImage06.color = this.m_Color;
							}
						}
						if (this.TRT1.localScale.x * 10f > this.CanvasRT.sizeDelta.x)
						{
							this.bTranstions = 3;
							this.TransitionFunc();
							this.TImage06.color = Color.white;
						}
					}
				}
				else if (this.bTranstions == 2)
				{
					if (this.bAxeOutNew)
					{
						this.nowSize = this.GetScale(this.dTime, this.sizeMin, this.sizeMax - this.sizeMin, 1f);
						this.setMsize();
						if (this.nowSize >= this.sizeMax)
						{
							this.EndTransitions();
						}
					}
					else
					{
						float num2 = this.TransitionsSpeed * 4f;
						if (this.TRT1.localScale.x <= 10f)
						{
							num2 *= 0.5f;
						}
						this.m_Vec3.Set(-num2, -num2, -num2);
						this.TRT1.localScale += this.m_Vec3;
						if (this.TImage06.color.a > 0f && this.TRT1.localScale.x <= 20f)
						{
							this.m_Color = this.TImage06.color;
							this.m_Color.a = this.m_Color.a - num2 * 15f / 255f;
							if (this.m_Color.a <= 0.05f)
							{
								this.TImage06.color = new Color(1f, 1f, 1f, 0.05f);
							}
							else
							{
								this.TImage06.color = this.m_Color;
							}
						}
						if (this.TRT1.localScale.x <= 0f)
						{
							this.EndTransitions();
						}
					}
				}
			}
			else if (this.NowTransKind == eTransKind.WhiteScaleCastle)
			{
				if (this.bTranstions == 1)
				{
					if (this.bCastleInNew)
					{
						this.nowSize -= this.DeltaSize;
						this.setMsize();
						if (this.nowSize <= this.sizeMin)
						{
							this.nowSize = this.sizeMin;
							this.setMsize();
							this.bTranstions = 3;
							this.TransitionFunc();
						}
					}
					else
					{
						float num3 = this.TransitionsSpeed * 8f;
						if (this.TRT1.localScale.x <= 10f)
						{
							num3 *= 0.5f;
						}
						this.m_Vec3.Set(num3, num3, num3);
						this.TRT1.localScale += this.m_Vec3;
						if (this.TImage06.color.a < 1f)
						{
							this.m_Color = this.TImage.color;
							this.m_Color.a = this.m_Color.a + num3 * 4f / 255f;
							if (this.m_Color.a >= 1f)
							{
								this.TImage06.color = Color.white;
							}
							else
							{
								this.TImage06.color = this.m_Color;
							}
						}
						if (this.TRT1.localScale.x * 6f > this.CanvasRT.sizeDelta.y)
						{
							this.bTranstions = 3;
							this.TransitionFunc();
							this.TImage06.color = Color.white;
						}
					}
				}
				else if (this.bTranstions == 2)
				{
					if (this.bCastleOutNew)
					{
						this.nowSize = this.GetScale(this.dTime, this.sizeMin, this.sizeMax - this.sizeMin, 1f);
						this.setMsize();
						if (this.nowSize >= this.sizeMax)
						{
							this.EndTransitions();
						}
					}
					else
					{
						float num4 = this.TransitionsSpeed * 5f;
						if (this.TRT1.localScale.x > 5f && this.TRT1.localScale.x <= 20f)
						{
							num4 *= 0.5f;
						}
						else if (this.TRT1.localScale.x <= 5f)
						{
							num4 *= 0.2f;
						}
						this.m_Vec3.Set(-num4, -num4, -num4);
						this.TRT1.localScale += this.m_Vec3;
						if (this.TImage06.color.a > 0f && this.TRT1.localScale.x <= 20f)
						{
							this.m_Color = this.TImage06.color;
							this.m_Color.a = this.m_Color.a - num4 * 15f / 255f;
							if (this.m_Color.a <= 0.05f)
							{
								this.TImage06.color = new Color(1f, 1f, 1f, 0.05f);
							}
							else
							{
								this.TImage06.color = this.m_Color;
							}
						}
						if (this.TRT1.localScale.x <= 0f)
						{
							this.EndTransitions();
						}
					}
				}
			}
			else if (this.NowTransKind == eTransKind.HalfClose)
			{
				this.dTime += 0.033f;
				if (this.bTranstions == 1)
				{
					float z = 315f + DamageValueManager.easeOutCubic(0f, 1f, this.dTime / this.HalfTotalTime) * 45f;
					this.TRT4.localEulerAngles = new Vector3(0f, 0f, z);
					this.TRT5.localEulerAngles = new Vector3(0f, 0f, z);
					if (this.dTime >= this.HalfTotalTime)
					{
						this.bTranstions = 3;
						this.TransitionFunc();
					}
				}
				else if (this.bTranstions == 2)
				{
					float num5 = DamageValueManager.easeInCubic(0f, 1f, this.dTime / this.HalfTotalTime);
					float num6 = this.CanvasRT.sizeDelta.y / 2f;
					float num7 = num6 * num5;
					this.m_Vec3.Set(num6 - 1f, num7, 0f);
					this.TRT4.anchoredPosition = this.m_Vec3;
					this.m_Vec3.Set(-num6 + 1f, -num7, 0f);
					this.TRT5.anchoredPosition = this.m_Vec3;
					num5 = DamageValueManager.easeInExpo(0f, 1f, this.dTime / this.HalfTotalTime);
					Color color = this.HalfImageTop.color;
					color.a = 1f - num5;
					this.HalfImageTop.color = color;
					this.HalfImageBottom.color = color;
					if (this.dTime >= this.HalfTotalTime)
					{
						this.EndTransitions();
					}
				}
			}
			else if (this.bTranstions == 1)
			{
				this.TransitionsWidth = this.CanvasRT.sizeDelta.x;
				this.m_Vec2.x = this.TRT1.sizeDelta.x + this.TransitionsSpeed;
				this.m_Vec2.y = this.TRT1.sizeDelta.y;
				this.TRT1.sizeDelta = this.m_Vec2;
				float num8 = this.TransitionsWidth + this.TransitionsDeltaX * 2f;
				if (this.bNeedShowBoss && this.m_Vec2.x >= num8 * 0.66f)
				{
					this.ShowBossText(this.bBossTest);
					this.bNeedShowBoss = false;
					this.bBossTest = false;
				}
				if (this.m_Vec2.x >= num8)
				{
					this.m_Vec2.x = num8;
					this.m_Vec2.y = this.TRT1.sizeDelta.y;
					this.TRT1.sizeDelta = this.m_Vec2;
					this.bTranstions = 3;
					this.TransitionFunc();
				}
			}
			else if (this.bTranstions == 2)
			{
				this.m_Vec2.x = this.TRT1.sizeDelta.x - this.TransitionsSpeed;
				this.m_Vec2.y = this.TRT1.sizeDelta.y;
				this.TRT1.sizeDelta = this.m_Vec2;
				if (this.m_Vec2.x <= 0f)
				{
					this.EndTransitions();
				}
			}
		}
	}

	// Token: 0x0600029C RID: 668 RVA: 0x000246EC File Offset: 0x000228EC
	private void InitialTransition()
	{
		GUIManager instance = GUIManager.Instance;
		this.LoadTransition1();
		this.LoadTransition2();
		if (this.TransitionsGO1 == null || this.TransitionsGO2 == null)
		{
			return;
		}
		if (this.NowFuncKind == eTransFunc.MapToBattle || this.NowFuncKind == eTransFunc.BattleReplay || this.NowFuncKind == eTransFunc.MapToWar || this.NowFuncKind == eTransFunc.DoorOpenUp || this.NowFuncKind == eTransFunc.MapToWar_Stage || this.NowFuncKind == eTransFunc.MapToWar_CoordTest || this.NowFuncKind == eTransFunc.WarToBattle || this.NowFuncKind == eTransFunc.MonsterBattle || this.NowFuncKind == eTransFunc.GambleBattle)
		{
			this.NowTransKind = eTransKind.WhiteScaleAxe;
		}
		else if (this.NowFuncKind == eTransFunc.BattleToMap || this.NowFuncKind == eTransFunc.WarToMap || this.NowFuncKind == eTransFunc.DoorWild)
		{
			this.NowTransKind = eTransKind.WhiteScaleCastle;
		}
		else if (this.NowFuncKind == eTransFunc.ChangeToMap || this.NowFuncKind == eTransFunc.ChangeToKing || this.NowFuncKind == eTransFunc.ChangeToWorld)
		{
			this.NowTransKind = eTransKind.HalfClose;
		}
		else
		{
			this.NowTransKind = eTransKind.Normal;
		}
		if (this.NowTransKind == eTransKind.WhiteScaleAxe)
		{
			this.TransitionsSpeed = 1f;
			this.TransitionsWidth = this.CanvasRT.sizeDelta.x;
			this.m_Vec2.Set(0.5f, 0.5f);
			this.TRT1.anchorMin = this.m_Vec2;
			this.TRT1.anchorMax = this.m_Vec2;
			this.TRT1.pivot = this.m_Vec2;
			this.m_Vec2.Set(128f, 128f);
			this.TRT1.sizeDelta = this.m_Vec2;
			this.m_Vec3.Set(0f, 0f, this.TransitionsZ);
			this.TRT1.anchoredPosition = this.m_Vec3;
			this.TRT1.localPosition = this.m_Vec3;
			this.TRT1.localScale = Vector3.one;
			this.TImage.sprite = instance.LoadSprite("Transitions1", "mark02");
			this.TImage.type = Image.Type.Simple;
		}
		else if (this.NowTransKind == eTransKind.WhiteScaleCastle)
		{
			this.TransitionsSpeed = 1f;
			this.TransitionsWidth = this.CanvasRT.sizeDelta.x;
			this.m_Vec2.Set(0.5f, 0.5f);
			this.TRT1.anchorMin = this.m_Vec2;
			this.TRT1.anchorMax = this.m_Vec2;
			this.TRT1.pivot = this.m_Vec2;
			this.m_Vec2.Set(128f, 128f);
			this.TRT1.sizeDelta = this.m_Vec2;
			this.m_Vec3.Set(0f, 0f, this.TransitionsZ);
			this.TRT1.anchoredPosition = this.m_Vec3;
			this.TRT1.localPosition = this.m_Vec3;
			this.TRT1.localScale = Vector3.one;
			this.TImage.sprite = instance.LoadSprite("Transitions1", "mark03");
			this.TImage.type = Image.Type.Simple;
		}
		else if (this.NowTransKind == eTransKind.HalfClose)
		{
			this.TRT4.anchorMin = Vector2.one;
			this.TRT4.anchorMax = Vector2.one;
			this.TRT4.pivot = Vector2.one;
			float num = this.CanvasRT.sizeDelta.y / 2f;
			this.m_Vec2.Set(this.CanvasRT.sizeDelta.x + num, num * 1.2f);
			this.TRT4.sizeDelta = this.m_Vec2;
			this.m_Vec3.Set(num, 0f, 0f);
			this.TRT4.anchoredPosition = this.m_Vec3;
			this.TRT4.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			this.HalfImageTop.color = Color.white;
			this.TRT5.anchorMin = Vector2.zero;
			this.TRT5.anchorMax = Vector2.zero;
			this.TRT5.pivot = Vector2.zero;
			this.m_Vec2.Set(this.CanvasRT.sizeDelta.x + num, num * 1.2f);
			this.TRT5.sizeDelta = this.m_Vec2;
			this.m_Vec3.Set(-num, 0f, 0f);
			this.TRT5.anchoredPosition = this.m_Vec3;
			this.TRT5.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			this.HalfImageBottom.color = Color.white;
		}
		else
		{
			this.TransitionsSpeed = 100f;
			this.TransitionsDeltaX = 379f;
			this.TransitionsWidth = this.CanvasRT.sizeDelta.x;
			this.m_Vec2.Set(0f, 0f);
			this.TRT1.anchorMin = this.m_Vec2;
			this.m_Vec2.Set(0f, 1f);
			this.TRT1.anchorMax = this.m_Vec2;
			this.m_Vec2.Set(0f, 0.5f);
			this.TRT1.pivot = this.m_Vec2;
			this.m_Vec2.Set(0f, this.TRT1.sizeDelta.y);
			this.TRT1.sizeDelta = this.m_Vec2;
			this.m_Vec3.Set(-this.TransitionsDeltaX, 0f, this.TransitionsZ);
			this.TRT1.anchoredPosition = this.m_Vec3;
			this.TRT1.localPosition = this.m_Vec3;
			this.TRT1.localScale = Vector3.one;
			this.TImage.sprite = instance.LoadSprite("Transitions1", "mark01");
			this.TImage.type = Image.Type.Sliced;
			this.TImage.fillCenter = true;
		}
	}

	// Token: 0x0600029D RID: 669 RVA: 0x00024D6C File Offset: 0x00022F6C
	public void BeginTransitions(bool bBeginClose)
	{
		if (this.TransitionLayer.localScale.x != 1f)
		{
			this.TransitionLayer.localScale = Vector3.one;
		}
		if (bBeginClose)
		{
			this.TransitionBeginFunc();
			this.bTranstions = 1;
			if (this.NowTransKind == eTransKind.WhiteScaleCastle)
			{
				if (this.bCastleInNew)
				{
					this.nowSize = this.sizeMax;
					this.setMsize();
					this.TransitionsGO3.SetActive(true);
				}
				else
				{
					this.TRT1.localScale = new Vector3(0.5f, 0.5f, 0.5f);
					this.TransitionsGO1.SetActive(true);
				}
				this.TransitionsGO6.SetActive(true);
				this.TImage06.color = new Color(1f, 1f, 1f, 0f);
			}
			else if (this.NowTransKind == eTransKind.WhiteScaleAxe)
			{
				if (this.bAxeInNew)
				{
					this.nowSize = this.sizeMax;
					this.setMsize();
					this.TransitionsGO2.SetActive(true);
				}
				else
				{
					this.TRT1.localScale = Vector3.one;
					if (this.NowFuncKind == eTransFunc.MapToBattle)
					{
						this.m_Vec3.Set(this.FightBeginPos.x, this.FightBeginPos.y, this.TransitionsZ);
					}
					else
					{
						this.m_Vec3.Set(0f, 0f, this.TransitionsZ);
					}
					this.TRT1.anchoredPosition = this.m_Vec3;
					this.TRT1.localPosition = this.m_Vec3;
					this.m_Color = Color.white;
					this.m_Color.a = 0.3f;
					this.TImage.color = this.m_Color;
					this.TransitionsGO1.SetActive(true);
				}
				this.TransitionsGO6.SetActive(true);
				this.TImage06.color = new Color(1f, 1f, 1f, 0f);
			}
			else if (this.NowTransKind == eTransKind.HalfClose)
			{
				this.dTime = 0f;
				float num = this.CanvasRT.sizeDelta.y / 2f;
				this.m_Vec3.Set(num - 1f, 10f, 0f);
				this.TRT4.anchoredPosition = this.m_Vec3;
				this.m_Vec3.Set(-num + 1f, -10f, 0f);
				this.TRT5.anchoredPosition = this.m_Vec3;
				this.TRT4.localRotation = new Quaternion(0f, 0f, 315f, 0f);
				this.TRT5.localRotation = new Quaternion(0f, 0f, 315f, 0f);
				this.HalfImageTop.color = Color.white;
				this.HalfImageBottom.color = Color.white;
				this.TransitionsGO4.SetActive(true);
				this.TransitionsGO5.SetActive(true);
			}
			else
			{
				this.TRT1.localRotation = this.Quaternion1;
				this.m_Vec3.Set(-this.TransitionsDeltaX, 0f, this.TransitionsZ);
				this.TRT1.anchoredPosition = this.m_Vec3;
				this.m_Vec3.Set(this.TRT1.localPosition.x, 0f, this.TransitionsZ);
				this.TRT1.localPosition = this.m_Vec3;
				this.m_Vec2.Set(0f, this.TRT1.sizeDelta.y);
				this.TRT1.sizeDelta = this.m_Vec2;
				this.TransitionsGO1.SetActive(true);
			}
		}
		else
		{
			this.bTranstions = 2;
			if (this.NowTransKind == eTransKind.WhiteScaleCastle)
			{
				if (this.bCastleOutNew)
				{
					this.dTime = 0f;
					this.nowSize = this.sizeMin;
					this.setMsize();
					this.TransitionsGO3.SetActive(true);
					if (!this.bCastleInNew)
					{
						this.TransitionsGO1.SetActive(false);
					}
				}
				else
				{
					this.m_Vec3.Set(0f, 0f, this.TransitionsZ);
					this.TRT1.anchoredPosition = this.m_Vec3;
					this.TRT1.localPosition = this.m_Vec3;
					float num2 = this.CanvasRT.sizeDelta.y / 6f;
					this.m_Vec3.Set(num2, num2, num2);
					this.TRT1.localScale = this.m_Vec3;
					this.TransitionsGO1.SetActive(true);
					if (this.bCastleInNew)
					{
						this.TransitionsGO3.SetActive(false);
					}
					this.TransitionsGO6.SetActive(true);
					this.TImage06.color = new Color(1f, 1f, 1f, 1f);
				}
			}
			else if (this.NowTransKind == eTransKind.WhiteScaleAxe)
			{
				if (this.bAxeOutNew)
				{
					this.dTime = 0f;
					this.nowSize = this.sizeMin;
					this.setMsize();
					this.TransitionsGO2.SetActive(true);
					if (!this.bAxeInNew)
					{
						this.TransitionsGO1.SetActive(false);
					}
				}
				else
				{
					this.m_Vec3.Set(0f, 0f, this.TransitionsZ);
					this.TRT1.anchoredPosition = this.m_Vec3;
					this.TRT1.localPosition = this.m_Vec3;
					float num3 = this.CanvasRT.sizeDelta.y / 10f;
					this.m_Vec3.Set(num3, num3, num3);
					this.TRT1.localScale = this.m_Vec3;
					this.TransitionsGO1.SetActive(true);
					if (this.bAxeInNew)
					{
						this.TransitionsGO2.SetActive(false);
					}
					if (this.NowFuncKind == eTransFunc.DoorOpenUp)
					{
						GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
						GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
						GUIManager.Instance.m_HUDMessage.MapHud.ShowTime = 1.3f;
						GUIManager.Instance.m_HUDMessage.MapHud.StartCountdown();
					}
					this.TransitionsGO6.SetActive(true);
					this.TImage06.color = new Color(1f, 1f, 1f, 1f);
				}
			}
			else if (this.NowTransKind == eTransKind.HalfClose)
			{
				this.dTime = 0f;
				float num4 = this.CanvasRT.sizeDelta.y / 2f;
				this.m_Vec3.Set(num4 - 1f, 10f, 0f);
				this.TRT4.anchoredPosition = this.m_Vec3;
				this.m_Vec3.Set(-num4 + 1f, -10f, 0f);
				this.TRT5.anchoredPosition = this.m_Vec3;
				this.TRT4.localRotation = new Quaternion(0f, 0f, 0f, 0f);
				this.TRT5.localRotation = new Quaternion(0f, 0f, 0f, 0f);
				this.HalfImageTop.color = Color.white;
				this.HalfImageBottom.color = Color.white;
				this.TransitionsGO4.SetActive(true);
				this.TransitionsGO5.SetActive(true);
				if (this.NowFuncKind != eTransFunc.Battle && this.NowFuncKind != eTransFunc.BattleReplay_Force && this.NowFuncKind != eTransFunc.BattleReplay_Dare)
				{
					GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
				}
			}
			else
			{
				this.TRT1.localRotation = this.Quaternion2;
				this.m_Vec3.Set(this.TransitionsWidth + this.TransitionsDeltaX, 0f, this.TransitionsZ);
				this.TRT1.anchoredPosition = this.m_Vec3;
				this.m_Vec3.Set(this.TRT1.localPosition.x, 0f, this.TransitionsZ);
				this.TRT1.localPosition = this.m_Vec3;
				this.m_Vec2.Set(this.TransitionsWidth + this.TransitionsDeltaX * 2f, this.TRT1.sizeDelta.y);
				this.TRT1.sizeDelta = this.m_Vec2;
				this.TransitionsGO1.SetActive(true);
				if (this.NowFuncKind != eTransFunc.Battle && this.NowFuncKind != eTransFunc.BattleReplay_Force && this.NowFuncKind != eTransFunc.BattleReplay_Dare)
				{
					GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
				}
			}
		}
	}

	// Token: 0x0600029E RID: 670 RVA: 0x00025690 File Offset: 0x00023890
	public void EndTransitions()
	{
		this.TransitionEndFunc();
		if (this.NowTransKind == eTransKind.HalfClose)
		{
			this.TransitionsGO4.SetActive(false);
			this.TransitionsGO5.SetActive(false);
		}
		else if (this.NowTransKind == eTransKind.WhiteScaleAxe)
		{
			this.TransitionsGO2.SetActive(false);
		}
		else if (this.NowTransKind == eTransKind.WhiteScaleCastle)
		{
			this.TransitionsGO3.SetActive(false);
		}
		if (this.TransitionsGO1.activeInHierarchy)
		{
			this.TransitionsGO1.SetActive(false);
		}
		if (this.TransitionsGO6.activeInHierarchy)
		{
			this.TransitionsGO6.SetActive(false);
		}
		this.bTranstions = 0;
		this.NowFuncKind = eTransFunc.Max;
		this.NowTransKind = eTransKind.Normal;
		GUIManager.Instance.m_HUDMessage.MapHud.StartCountdown();
		GUIManager.Instance.HideUILock(EUILock.Normal);
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Transition);
	}

	// Token: 0x0600029F RID: 671 RVA: 0x0002577C File Offset: 0x0002397C
	private void setMsize()
	{
		if (this.NowTransKind == eTransKind.WhiteScaleCastle)
		{
			float num = 1f / this.nowSize;
			float num2 = 1f / this.nowSize;
			this.m_Castle.mainTextureScale = new Vector2(num, num2);
			num = 0.5f - 0.5f * num;
			num2 = 0.55f - 0.5f * num2;
			this.m_Castle.mainTextureOffset = new Vector2(num, num2);
		}
		else if (this.NowTransKind == eTransKind.WhiteScaleAxe)
		{
			float num3 = 1f / this.nowSize;
			float num4 = 1f / this.nowSize;
			this.m_Axe.mainTextureScale = new Vector2(num3, num4);
			num3 = 0.5f - 0.5f * num3;
			num4 = 0.5f - 0.5f * num4;
			this.m_Axe.mainTextureOffset = new Vector2(num3, num4);
		}
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x0002585C File Offset: 0x00023A5C
	private void LoadTransition1()
	{
		if (this.TransitionsGO1 == null)
		{
			this.m_A8 = GUIManager.Instance.AddSpriteAsset(this.TransNameStr);
			this.TransitionsGO1 = new GameObject("Transitions1");
			this.TransitionsGO1.transform.SetParent(this.TransitionLayer, false);
			this.TRT1 = this.TransitionsGO1.AddComponent<RectTransform>();
			this.TImage = this.TransitionsGO1.AddComponent<Image>();
			this.TImage.material = this.m_A8;
			this.TransitionsGO4 = new GameObject("Transitions4");
			this.TransitionsGO4.transform.SetParent(this.TransitionLayer, false);
			this.TRT4 = this.TransitionsGO4.AddComponent<RectTransform>();
			this.HalfImageTop = this.TransitionsGO4.AddComponent<Image>();
			this.HalfImageTop.material = this.m_A8;
			this.HalfImageTop.sprite = GUIManager.Instance.LoadSprite(this.TransNameStr, "black_gogo");
			this.HalfImageTop.type = Image.Type.Sliced;
			this.TransitionsGO5 = new GameObject("Transitions5");
			this.TransitionsGO5.transform.SetParent(this.TransitionLayer, false);
			this.TRT5 = this.TransitionsGO5.AddComponent<RectTransform>();
			this.HalfImageBottom = this.TransitionsGO5.AddComponent<Image>();
			this.HalfImageBottom.material = this.m_A8;
			this.HalfImageBottom.sprite = GUIManager.Instance.LoadSprite(this.TransNameStr, "black_gogo_b");
			this.HalfImageBottom.type = Image.Type.Sliced;
			this.TransitionsGO6 = new GameObject("Transitions6");
			this.TransitionsGO6.transform.SetParent(this.TransitionLayer, false);
			RectTransform rectTransform = this.TransitionsGO6.AddComponent<RectTransform>();
			rectTransform.anchorMax = Vector2.one;
			rectTransform.anchorMin = Vector2.zero;
			this.TImage06 = this.TransitionsGO6.AddComponent<Image>();
			this.TImage06.material = this.m_A8;
			this.TImage06.sprite = GUIManager.Instance.LoadSprite(this.TransNameStr, "black_Transitions");
			this.TImage06.type = Image.Type.Simple;
			if (GUIManager.Instance.bOpenOnIPhoneX)
			{
				rectTransform.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
				rectTransform.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
			}
			else
			{
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
			}
			AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/Transitions1", out this.AssetKey_Trans1, false);
			if (assetBundle == null)
			{
				return;
			}
			this.BossObj = (GameObject)UnityEngine.Object.Instantiate(assetBundle.mainAsset);
			if (this.BossObj != null)
			{
				this.BossObj.transform.SetParent(this.TransitionLayer, false);
				this.BossCG = this.BossObj.transform.GetComponent<CanvasGroup>();
				this.BossImgRC = this.BossObj.transform.GetChild(0).GetComponent<RectTransform>();
				this.BossTextRC = this.BossObj.transform.GetChild(1).GetComponent<RectTransform>();
				this.BossImgRC.sizeDelta = new Vector2(this.CanvasRT.sizeDelta.x + 300f, this.BossImgRC.sizeDelta.y);
				UIText component = this.BossTextRC.GetComponent<UIText>();
				component.font = GUIManager.Instance.GetTTFFont();
				component.text = DataManager.Instance.mStringTable.GetStringByID(5910u);
				this.BossObj.SetActive(false);
			}
			this.TransitionsGO1.SetActive(false);
			this.TransitionsGO4.SetActive(false);
			this.TransitionsGO5.SetActive(false);
			this.TransitionsGO6.SetActive(false);
		}
	}

	// Token: 0x060002A1 RID: 673 RVA: 0x00025C48 File Offset: 0x00023E48
	private void LoadTransition2()
	{
		if (this.TransitionsGO2 == null)
		{
			AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/Transitions2", out this.AssetKey_Trans, false);
			if (assetBundle == null)
			{
				return;
			}
			float num = this.TransitionsWidth / 256f;
			this.TransitionsGO2 = new GameObject("Transitions2");
			this.TransitionsGO2.transform.SetParent(this.TransitionLayer, false);
			RectTransform rectTransform = this.TransitionsGO2.AddComponent<RectTransform>();
			this.m_Vec2.Set(256f, 256f);
			rectTransform.sizeDelta = this.m_Vec2;
			this.m_Vec3.Set(0f, 0f, this.TransitionsZ);
			rectTransform.anchoredPosition = this.m_Vec3;
			rectTransform.localPosition = this.m_Vec3;
			this.m_Vec3.Set(num, num, 1f);
			rectTransform.localScale = this.m_Vec3;
			Image image = this.TransitionsGO2.AddComponent<Image>();
			image.material = (assetBundle.Load("001_m") as Material);
			this.m_Axe = image.material;
			this.TransitionsGO2.SetActive(false);
			this.TransitionsGO3 = new GameObject("Transitions3");
			this.TransitionsGO3.transform.SetParent(this.TransitionLayer, false);
			rectTransform = this.TransitionsGO3.AddComponent<RectTransform>();
			this.m_Vec2.Set(256f, 256f);
			rectTransform.sizeDelta = this.m_Vec2;
			this.m_Vec3.Set(0f, 0f, this.TransitionsZ);
			rectTransform.anchoredPosition = this.m_Vec3;
			rectTransform.localPosition = this.m_Vec3;
			this.m_Vec3.Set(num, num, 1f);
			rectTransform.localScale = this.m_Vec3;
			image = this.TransitionsGO3.AddComponent<Image>();
			image.material = (assetBundle.Load("002_m") as Material);
			this.m_Castle = image.material;
			this.TransitionsGO3.SetActive(false);
		}
	}

	// Token: 0x060002A2 RID: 674 RVA: 0x00025E5C File Offset: 0x0002405C
	public void ShowGodText(bool bTest = false)
	{
		this.LoadTransition1();
		if (this.BossObj != null)
		{
			float num = 1f / this.TransitionLayer.localScale.x;
			this.BossObj.transform.localScale = new Vector3(num, num, num);
			this.BossImgRC.sizeDelta = this.BossImageSize;
			this.BossImgRC.anchoredPosition = this.BossImagePos;
			if (GUIManager.Instance.IsArabic)
			{
				this.BossTextRC.localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				this.BossTextRC.localScale = Vector3.one;
			}
			this.BossTextRC.anchoredPosition = this.BossTextPos;
			this.BossText = this.BossTextRC.GetComponent<UIText>();
			this.BossText.text = DataManager.Instance.mStringTable.GetStringByID(9187u);
			this.BossText.resizeTextMinSize = 60;
			this.BossText.color = this.BossTextColor;
			this.BossTextRC.GetComponent<Outline>().effectColor = this.BossTextColorOutline;
			this.BossTextRC.GetComponent<Shadow>().effectColor = this.BossTextColorShadow;
			this.BossObj.SetActive(true);
			if (bTest)
			{
				this.bShowBoss = true;
			}
			this.BossCG.alpha = 0f;
			this.BossFadeDeltaTime = 0.3f;
			this.bBossMoveDown = false;
		}
	}

	// Token: 0x060002A3 RID: 675 RVA: 0x00025FE0 File Offset: 0x000241E0
	public void ShowBossText(bool bTest = false)
	{
		this.LoadTransition1();
		if (this.BossObj != null)
		{
			float num = 1f / this.TransitionLayer.localScale.x;
			this.BossObj.transform.localScale = new Vector3(num, num, num);
			this.BossImgRC.sizeDelta = this.BossImageSize;
			this.BossImgRC.anchoredPosition = this.BossImagePos;
			if (GUIManager.Instance.IsArabic)
			{
				this.BossTextRC.localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				this.BossTextRC.localScale = Vector3.one;
			}
			this.BossTextRC.anchoredPosition = this.BossTextPos;
			this.BossText = this.BossTextRC.GetComponent<UIText>();
			this.BossText.text = DataManager.Instance.mStringTable.GetStringByID(5910u);
			this.BossText.resizeTextMinSize = 60;
			this.BossText.color = this.BossTextColor;
			this.BossTextRC.GetComponent<Outline>().effectColor = this.BossTextColorOutline;
			this.BossTextRC.GetComponent<Shadow>().effectColor = this.BossTextColorShadow;
			this.BossObj.SetActive(true);
			if (bTest)
			{
				this.bShowBoss = true;
			}
			this.BossCG.alpha = 0f;
			this.BossFadeDeltaTime = 0.3f;
			this.bBossMoveDown = false;
		}
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x00026164 File Offset: 0x00024364
	public void ShowMallGetItemText(bool bTest = false)
	{
		this.LoadTransition1();
		if (this.BossObj != null)
		{
			float num = 1f / this.TransitionLayer.localScale.x;
			this.BossObj.transform.localScale = new Vector3(num, num, num);
			this.BossImgRC.sizeDelta = this.BossImageSize;
			this.BossImgRC.anchoredPosition = this.BossImagePos;
			if (GUIManager.Instance.IsArabic)
			{
				this.BossTextRC.localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				this.BossTextRC.localScale = Vector3.one;
			}
			this.BossTextRC.anchoredPosition = this.BossTextPos;
			this.BossText = this.BossTextRC.GetComponent<UIText>();
			this.BossText.text = DataManager.Instance.mStringTable.GetStringByID(17515u);
			this.BossText.resizeTextMinSize = 40;
			this.BossText.color = this.BossTextColor;
			this.BossTextRC.GetComponent<Outline>().effectColor = this.BossTextColorOutline;
			this.BossTextRC.GetComponent<Shadow>().effectColor = this.BossTextColorShadow;
			this.BossObj.SetActive(true);
			if (bTest)
			{
				this.bShowBoss = true;
			}
			this.BossCG.alpha = 0f;
			this.BossFadeDeltaTime = 0.3f;
			this.bBossMoveDown = false;
		}
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x000262E8 File Offset: 0x000244E8
	public void ShowCastleStrengthenText(ushort strId, bool bMoveDown)
	{
		this.LoadTransition1();
		if (this.BossObj != null)
		{
			float num = 1f / this.TransitionLayer.localScale.x;
			this.BossObj.transform.localScale = new Vector3(num, num, num);
			this.BossImgRC.sizeDelta = this.BossImageSize;
			this.BossImgRC.anchoredPosition = this.BossImagePos;
			if (GUIManager.Instance.IsArabic)
			{
				this.BossTextRC.localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				this.BossTextRC.localScale = Vector3.one;
			}
			this.BossTextRC.anchoredPosition = this.BossTextPos;
			this.BossText = this.BossTextRC.GetComponent<UIText>();
			this.BossText.text = DataManager.Instance.mStringTable.GetStringByID((uint)strId);
			this.BossText.resizeTextMinSize = 60;
			this.BossText.color = this.BossTextColor;
			this.BossTextRC.GetComponent<Outline>().effectColor = this.BossTextColorOutline;
			this.BossTextRC.GetComponent<Shadow>().effectColor = this.BossTextColorShadow;
			if (GUIManager.Instance.IsArabic)
			{
				this.BossTextRC.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
			}
			else
			{
				this.BossTextRC.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			}
			this.BossImgRC.sizeDelta = new Vector2(this.BossImageSize.x, 80f);
			this.BossImgRC.anchoredPosition = new Vector2(this.BossImagePos.x, -83f);
			if (bMoveDown)
			{
				this.BossText.color = new Color(0.8235f, 0.8235f, 0.8235f);
				this.BossTextRC.GetComponent<Outline>().effectColor = new Color(0.588f, 0.588f, 0.588f);
				this.BossTextRC.GetComponent<Shadow>().effectColor = new Color(0.431f, 0.431f, 0.431f);
			}
			this.BossObj.SetActive(true);
			this.BossCG.alpha = 0f;
			this.BossFadeDeltaTime = 0.3f;
			this.bBossMoveDown = bMoveDown;
		}
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x00026558 File Offset: 0x00024758
	public void ShowMallGetItem_FT_Text(bool bTest = false)
	{
		this.LoadTransition1();
		if (this.BossObj != null)
		{
			float num = 1f / this.TransitionLayer.localScale.x;
			this.BossObj.transform.localScale = new Vector3(num, num, num);
			this.BossImgRC.sizeDelta = this.BossImageSize;
			this.BossImgRC.anchoredPosition = this.BossImagePos;
			if (GUIManager.Instance.IsArabic)
			{
				this.BossTextRC.localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				this.BossTextRC.localScale = Vector3.one;
			}
			this.BossTextRC.anchoredPosition = this.BossTextPos;
			this.BossText = this.BossTextRC.GetComponent<UIText>();
			this.BossText.text = DataManager.Instance.mStringTable.GetStringByID(10187u);
			this.BossText.resizeTextMinSize = 40;
			this.BossText.color = this.BossTextColor;
			this.BossTextRC.GetComponent<Outline>().effectColor = this.BossTextColorOutline;
			this.BossTextRC.GetComponent<Shadow>().effectColor = this.BossTextColorShadow;
			this.BossObj.SetActive(true);
			if (bTest)
			{
				this.bShowBoss = true;
			}
			this.BossCG.alpha = 0f;
			this.BossFadeDeltaTime = 0.3f;
			this.bBossMoveDown = false;
		}
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x000266DC File Offset: 0x000248DC
	public void BeginMoveBossText()
	{
		if (this.BossObj != null)
		{
			this.bBossMove = true;
			this.BossDeltaTime = 0f;
			this.BossMoveDelta = this.CanvasRT.sizeDelta.x + 200f;
			GUIManager.Instance.ShowUILock(EUILock.Normal);
		}
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x00026738 File Offset: 0x00024938
	public void BeginMoveBossText(float mValue)
	{
		if (this.BossObj != null)
		{
			this.bBossMove = true;
			this.BossDeltaTime = 0f;
			this.BossMoveDelta = mValue;
			GUIManager.Instance.ShowUILock(EUILock.Normal);
		}
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x0002677C File Offset: 0x0002497C
	public void EndMoveBossText()
	{
		if (this.BossObj != null)
		{
			this.BossObj.SetActive(false);
			this.bBossMove = false;
			GUIManager.Instance.HideUILock(EUILock.Normal);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 21, 0);
		}
	}

	// Token: 0x060002AA RID: 682 RVA: 0x000267CC File Offset: 0x000249CC
	private void UpDateBoss()
	{
		if (this.BossObj != null)
		{
			if (this.BossFadeDeltaTime > 0f)
			{
				this.BossFadeDeltaTime -= Time.smoothDeltaTime;
				if (this.BossFadeDeltaTime <= 0f || this.bBossMove)
				{
					this.BossCG.alpha = 1f;
					this.BossFadeDeltaTime = -1f;
				}
				else
				{
					this.BossCG.alpha = 1f - Mathf.Lerp(0f, 1f, this.BossFadeDeltaTime / 0.3f);
				}
			}
			if (this.bBossMove)
			{
				if (this.bBossMoveDown)
				{
					float num = DamageValueManager.easeInBack2(this.BossDeltaTime, 0f, 1f, this.BossTotalTime);
					this.BossTextRC.anchoredPosition = new Vector2(this.BossTextRC.anchoredPosition.x, this.BossTextPos.y - this.BossMoveDelta * num);
					this.BossCG.alpha = 1f - Mathf.Lerp(0f, 1f, this.BossDeltaTime / this.BossTotalTime);
				}
				else
				{
					float num2 = DamageValueManager.easeInBack(0f, 1f, this.BossDeltaTime / this.BossTotalTime);
					this.BossImgRC.anchoredPosition = new Vector2(this.BossMoveDelta * num2, this.BossImgRC.anchoredPosition.y);
					this.BossTextRC.anchoredPosition = new Vector2(-(this.BossMoveDelta * num2), this.BossTextRC.anchoredPosition.y);
				}
				this.BossDeltaTime += Time.smoothDeltaTime;
				if (this.BossDeltaTime >= this.BossTotalTime)
				{
					this.EndMoveBossText();
				}
			}
			else if (this.bShowBoss)
			{
				this.ShowBossTime += Time.smoothDeltaTime;
				if (this.ShowBossTime >= 1f)
				{
					this.NextTransitions(eTrans.END, eTransFunc.Test);
					this.ShowBossTime = 0f;
					this.bShowBoss = false;
				}
			}
		}
	}

	// Token: 0x060002AB RID: 683 RVA: 0x000269FC File Offset: 0x00024BFC
	public static float easeInExpo(float start, float end, float value)
	{
		end -= start;
		return end * Mathf.Pow(2f, 10f * (value / 1f - 1f)) + start;
	}

	// Token: 0x060002AC RID: 684 RVA: 0x00026A30 File Offset: 0x00024C30
	public static float easeInCubic(float start, float end, float value)
	{
		end -= start;
		return end * value * value * value + start;
	}

	// Token: 0x060002AD RID: 685 RVA: 0x00026A40 File Offset: 0x00024C40
	public static float easeInQuart(float start, float end, float value)
	{
		end -= start;
		return end * value * value * value * value + start;
	}

	// Token: 0x060002AE RID: 686 RVA: 0x00026A54 File Offset: 0x00024C54
	public static float easeOutCubic2(float start, float end, float value)
	{
		return end * ((value -= 1f) * value * value * value + 1f) + start;
	}

	// Token: 0x060002AF RID: 687 RVA: 0x00026A70 File Offset: 0x00024C70
	public static float easeOutCubic(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return end * (value * value * value + 1f) + start;
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x00026A90 File Offset: 0x00024C90
	public static float easeOutQuart(float start, float end, float value)
	{
		value -= 1f;
		end -= start;
		return end * (value * value * value * value * -1f + 1f) + start;
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x00026AB8 File Offset: 0x00024CB8
	public static double easeInElastic(double t, double b, double c, double d)
	{
		double num = c;
		if (t == 0.0)
		{
			return b;
		}
		if ((t /= d) == 1.0)
		{
			return b + c;
		}
		double num2 = d * 0.3;
		double num3;
		if (num < Math.Abs(c))
		{
			num = c;
			num3 = num2 / 4.0;
		}
		else
		{
			num3 = num2 / 6.2831853071795862 * Math.Asin(c / num);
		}
		return -(num * Math.Pow(2.0, 10.0 * (t -= 1.0)) * Math.Sin((t * d - num3) * 6.2831853071795862 / num2)) + b;
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x00026B7C File Offset: 0x00024D7C
	public static float easeInBack(float start, float end, float value)
	{
		end -= start;
		value /= 1f;
		float num = 0.8f;
		return end * value * value * ((num + 1f) * value - num) + start;
	}

	// Token: 0x060002B3 RID: 691 RVA: 0x00026BB0 File Offset: 0x00024DB0
	private float GetScale(float t, float b, float c, float d)
	{
		float num = (t /= d) * t;
		float num2 = num * t;
		return b + c * (num2 * num);
	}

	// Token: 0x060002B4 RID: 692 RVA: 0x00026BD4 File Offset: 0x00024DD4
	public static float easeInBack2(float t, float b, float c, float d)
	{
		float num = (t /= d) * t;
		float num2 = num * t;
		return (float)((double)b + (double)c * (5.6 * (double)num2 * (double)num + -11.3 * (double)num * (double)num + 8.1 * (double)num2 + -0.2 * (double)num + -1.2 * (double)t));
	}

	// Token: 0x04000491 RID: 1169
	private const int DVCount_Word = 20;

	// Token: 0x04000492 RID: 1170
	private const int DVCount_NUm = 60;

	// Token: 0x04000493 RID: 1171
	private const float ScaleRate = 0.6f;

	// Token: 0x04000494 RID: 1172
	private const float ShowTime = 1.5f;

	// Token: 0x04000495 RID: 1173
	private const float FadeOutTime = 0.8f;

	// Token: 0x04000496 RID: 1174
	private const float DecreaseTime = 0.0500000045f;

	// Token: 0x04000497 RID: 1175
	private const float BarWidth = 45f;

	// Token: 0x04000498 RID: 1176
	private const float BarHeight = 5f;

	// Token: 0x04000499 RID: 1177
	private const float StateSize = 36f;

	// Token: 0x0400049A RID: 1178
	private const int StateMax = 3;

	// Token: 0x0400049B RID: 1179
	private const float BossFadeTime = 0.3f;

	// Token: 0x0400049C RID: 1180
	private Color m_Color;

	// Token: 0x0400049D RID: 1181
	private Color m_EnergyColor;

	// Token: 0x0400049E RID: 1182
	private Color m_BlueColor;

	// Token: 0x0400049F RID: 1183
	private Color m_RedColor;

	// Token: 0x040004A0 RID: 1184
	private Color m_GreenColor;

	// Token: 0x040004A1 RID: 1185
	private Color m_BlueColor1;

	// Token: 0x040004A2 RID: 1186
	private Color m_RedColor1;

	// Token: 0x040004A3 RID: 1187
	private Color m_GreenColor1;

	// Token: 0x040004A4 RID: 1188
	private Vector2 m_Vec2;

	// Token: 0x040004A5 RID: 1189
	private Vector3 m_Vec3;

	// Token: 0x040004A6 RID: 1190
	private BattleController bc;

	// Token: 0x040004A7 RID: 1191
	private WarManager wm;

	// Token: 0x040004A8 RID: 1192
	private StringBuilder sb = new StringBuilder();

	// Token: 0x040004A9 RID: 1193
	private int AssetKey_Font;

	// Token: 0x040004AA RID: 1194
	private int AssetKey_Bar;

	// Token: 0x040004AB RID: 1195
	private int AssetKey_Trans;

	// Token: 0x040004AC RID: 1196
	private int AssetKey_Trans1;

	// Token: 0x040004AD RID: 1197
	private float moveDelta = -1f;

	// Token: 0x040004AE RID: 1198
	private float DVScaleN = 0.7f;

	// Token: 0x040004AF RID: 1199
	private float DVScaleC = 0.4f;

	// Token: 0x040004B0 RID: 1200
	private float DVScale = 0.8f;

	// Token: 0x040004B1 RID: 1201
	private string GOName = "DamageValue";

	// Token: 0x040004B2 RID: 1202
	private Font m_DamageValueFont;

	// Token: 0x040004B3 RID: 1203
	private List<DamageValue> DVList = new List<DamageValue>();

	// Token: 0x040004B4 RID: 1204
	private Stack<DamageValue> EmptyDVStack_Word = new Stack<DamageValue>(20);

	// Token: 0x040004B5 RID: 1205
	private Stack<DamageValue> EmptyDVStack_Num = new Stack<DamageValue>(60);

	// Token: 0x040004B6 RID: 1206
	private string PlayerName = "PlayerBar";

	// Token: 0x040004B7 RID: 1207
	private string EnemyName = "EnemyBar";

	// Token: 0x040004B8 RID: 1208
	private int PlayerCount;

	// Token: 0x040004B9 RID: 1209
	private int EnemyCount;

	// Token: 0x040004BA RID: 1210
	private Dictionary<ushort, Sprite> m_Dict = new Dictionary<ushort, Sprite>();

	// Token: 0x040004BB RID: 1211
	private List<BloodBar> Player = new List<BloodBar>(20);

	// Token: 0x040004BC RID: 1212
	private List<BloodBar> Enemy = new List<BloodBar>(20);

	// Token: 0x040004BD RID: 1213
	private byte bTranstions;

	// Token: 0x040004BE RID: 1214
	private GameObject TransitionsGO6;

	// Token: 0x040004BF RID: 1215
	private Image TImage06;

	// Token: 0x040004C0 RID: 1216
	private GameObject TransitionsGO1;

	// Token: 0x040004C1 RID: 1217
	private GameObject TransitionsGO2;

	// Token: 0x040004C2 RID: 1218
	private GameObject TransitionsGO3;

	// Token: 0x040004C3 RID: 1219
	private GameObject TransitionsGO4;

	// Token: 0x040004C4 RID: 1220
	private GameObject TransitionsGO5;

	// Token: 0x040004C5 RID: 1221
	private GameObject BossObj;

	// Token: 0x040004C6 RID: 1222
	private RectTransform TRT1;

	// Token: 0x040004C7 RID: 1223
	private RectTransform m_CanvasRT;

	// Token: 0x040004C8 RID: 1224
	private RectTransform baseLayer;

	// Token: 0x040004C9 RID: 1225
	private RectTransform DamageValueLayer_Num;

	// Token: 0x040004CA RID: 1226
	private RectTransform DamageValueLayer_Normal;

	// Token: 0x040004CB RID: 1227
	private RectTransform DamageValueLayer_CRINum;

	// Token: 0x040004CC RID: 1228
	private RectTransform DamageValueLayer_Word;

	// Token: 0x040004CD RID: 1229
	private RectTransform TRT4;

	// Token: 0x040004CE RID: 1230
	private RectTransform TRT5;

	// Token: 0x040004CF RID: 1231
	public RectTransform TransitionLayer;

	// Token: 0x040004D0 RID: 1232
	public RectTransform BossTextRC;

	// Token: 0x040004D1 RID: 1233
	public RectTransform BossImgRC;

	// Token: 0x040004D2 RID: 1234
	private CanvasGroup BossCG;

	// Token: 0x040004D3 RID: 1235
	private Image TImage;

	// Token: 0x040004D4 RID: 1236
	private float fTransitionsTime;

	// Token: 0x040004D5 RID: 1237
	private float TransitionsSpeed = 100f;

	// Token: 0x040004D6 RID: 1238
	private float TransitionsDeltaX = 379f;

	// Token: 0x040004D7 RID: 1239
	private float TransitionsWidth = 853f;

	// Token: 0x040004D8 RID: 1240
	private float TransitionsZ;

	// Token: 0x040004D9 RID: 1241
	private float nowSize;

	// Token: 0x040004DA RID: 1242
	private float DeltaSize = 0.33f;

	// Token: 0x040004DB RID: 1243
	private float sizeMin;

	// Token: 0x040004DC RID: 1244
	private float sizeMax = 15f;

	// Token: 0x040004DD RID: 1245
	private Quaternion Quaternion1 = new Quaternion(0f, 0f, 0f, 0f);

	// Token: 0x040004DE RID: 1246
	private Quaternion Quaternion2 = new Quaternion(0f, 180f, 0f, 0f);

	// Token: 0x040004DF RID: 1247
	private Material m_A8;

	// Token: 0x040004E0 RID: 1248
	private Material m_Axe;

	// Token: 0x040004E1 RID: 1249
	private Material m_Castle;

	// Token: 0x040004E2 RID: 1250
	private eTransFunc NowFuncKind = eTransFunc.Max;

	// Token: 0x040004E3 RID: 1251
	private eTransKind NowTransKind = eTransKind.Normal;

	// Token: 0x040004E4 RID: 1252
	public Vector3 FightBeginPos = Vector3.zero;

	// Token: 0x040004E5 RID: 1253
	private bool bAxeInNew;

	// Token: 0x040004E6 RID: 1254
	private bool bAxeOutNew;

	// Token: 0x040004E7 RID: 1255
	private bool bCastleInNew;

	// Token: 0x040004E8 RID: 1256
	private bool bCastleOutNew;

	// Token: 0x040004E9 RID: 1257
	private float dTime;

	// Token: 0x040004EA RID: 1258
	private string TransNameStr = "Transitions1";

	// Token: 0x040004EB RID: 1259
	private bool bBossMove;

	// Token: 0x040004EC RID: 1260
	private bool bShowBoss;

	// Token: 0x040004ED RID: 1261
	private bool bNeedShowBoss;

	// Token: 0x040004EE RID: 1262
	private bool bBossTest;

	// Token: 0x040004EF RID: 1263
	private float BossDeltaTime;

	// Token: 0x040004F0 RID: 1264
	private float BossTotalTime = 0.5f;

	// Token: 0x040004F1 RID: 1265
	private float BossMoveDelta;

	// Token: 0x040004F2 RID: 1266
	private float ShowBossTime;

	// Token: 0x040004F3 RID: 1267
	private float BossFadeDeltaTime = -1f;

	// Token: 0x040004F4 RID: 1268
	private float HalfTotalTime = 0.3f;

	// Token: 0x040004F5 RID: 1269
	private Image HalfImageTop;

	// Token: 0x040004F6 RID: 1270
	private Image HalfImageBottom;

	// Token: 0x040004F7 RID: 1271
	public UIText BossText;

	// Token: 0x040004F8 RID: 1272
	private Vector2 BossImagePos = new Vector2(0f, -107f);

	// Token: 0x040004F9 RID: 1273
	private Vector2 BossTextPos = new Vector2(0f, -84f);

	// Token: 0x040004FA RID: 1274
	private Vector2 BossImageSize = new Vector2(1200f, 160f);

	// Token: 0x040004FB RID: 1275
	private bool bBossMoveDown;

	// Token: 0x040004FC RID: 1276
	private Color BossTextColor = new Color(1f, 0.859f, 0.286f);

	// Token: 0x040004FD RID: 1277
	private Color BossTextColorOutline = new Color(0.898f, 0.635f, 0f, 0.5f);

	// Token: 0x040004FE RID: 1278
	private Color BossTextColorShadow = new Color(0.855f, 0.4196f, 0.0705f, 0.5f);
}
