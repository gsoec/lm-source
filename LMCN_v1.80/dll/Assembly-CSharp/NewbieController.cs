using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200078F RID: 1935
public class NewbieController : MonoBehaviour, IUIHIBtnClickHandler, IUIHIBtnUpDownHandler, IUIHIBtnDrag
{
	// Token: 0x06002795 RID: 10133 RVA: 0x0043C268 File Offset: 0x0043A468
	public void Awake()
	{
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UINewbie", out this.AssetKey, false);
		this.ShareMat = (assetBundle.Load("UI_new_m") as Material);
		this.Black = new Texture2D(1, 1);
		this.Black.SetPixel(1, 1, new Color32(0, 0, 0, byte.MaxValue));
		this.Black.Apply();
		Shader shader = null;
		Shader shader2 = null;
		AssetManager instance = AssetManager.Instance;
		int num = instance.Shaders.Length;
		for (int i = 0; i < num; i++)
		{
			if (instance.Shaders[i].name == "zTWRD2 Shaders/UI/Mask")
			{
				shader2 = (Shader)instance.Shaders[i];
			}
			else if (instance.Shaders[i].name == "zTWRD2 Shaders/UI/Masked")
			{
				shader = (Shader)instance.Shaders[i];
			}
		}
		GameObject gameObject = new GameObject("HoleMaskPanel");
		this.HoleMaskTrans = gameObject.AddComponent<RectTransform>();
		this.HoleMaskTrans.anchorMin = Vector2.zero;
		this.HoleMaskTrans.anchorMax = Vector2.zero;
		this.HoleMaskTrans.pivot = new Vector2(0.5f, 0.5f);
		this.HoleMaskPanel = gameObject.AddComponent<Image>();
		UnityEngine.Object[] array = assetBundle.LoadAll(typeof(Sprite));
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j].name == "UI_new_mask_01")
			{
				this.HoleMaskPanel.sprite = (array[j] as Sprite);
			}
		}
		Material material = new Material(shader2);
		material.renderQueue = 3000;
		material.mainTexture = this.HoleMaskPanel.sprite.texture;
		this.HoleMaskPanel.type = Image.Type.Sliced;
		this.HoleMaskPanel.material = material;
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.SetActive(false);
		for (int k = 0; k < 5; k++)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject) as GameObject;
			gameObject2.transform.SetParent(base.transform);
			gameObject2.transform.localScale = Vector3.one;
			gameObject2.transform.localPosition = Vector3.zero;
			this.OtherHoles[k].HoleMaskRectTransform = (gameObject2.transform as RectTransform);
		}
		gameObject = new GameObject("BlackPanel");
		RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMin = Vector2.zero;
		rectTransform.anchorMax = Vector2.zero;
		rectTransform.pivot = new Vector2(0.25f, 0.25f);
		Vector2 vector = GUIManager.Instance.m_UICanvas.gameObject.GetComponent<RectTransform>().sizeDelta * 2f;
		rectTransform.sizeDelta = new Vector2(vector.x, vector.y);
		this.BlackPanel = gameObject.AddComponent<Image>();
		this.BlackPanel.sprite = Sprite.Create(this.Black, new Rect(0f, 0f, 1f, 1f), new Vector2(0f, 0f));
		material = new Material(shader);
		material.renderQueue = 3000;
		material.mainTexture = this.Black;
		this.BlackPanel.material = material;
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.SetActive(false);
		gameObject = new GameObject("HolePanel");
		this.HoleTrans = gameObject.AddComponent<RectTransform>();
		this.HoleTrans.anchorMin = Vector2.zero;
		this.HoleTrans.anchorMax = Vector2.zero;
		this.HoleTrans.pivot = new Vector2(0.5f, 0.5f);
		this.HoleBtn = gameObject.AddComponent<UIHIBtn>();
		this.HoleBtn.m_BtnID1 = 0;
		this.HoleBtn.m_Handler = this;
		this.HoleBtn.m_UpDownHandler = this;
		this.HoleBtn.m_DHandler = this;
		this.HolePanel = gameObject.AddComponent<Image>();
		for (int l = 0; l < array.Length; l++)
		{
			if (array[l].name == "UI_new_frame_01")
			{
				this.HolePanel.sprite = (array[l] as Sprite);
			}
		}
		this.HolePanel.type = Image.Type.Sliced;
		this.HolePanel.material = this.ShareMat;
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.SetActive(false);
		for (int m = 0; m < 5; m++)
		{
			GameObject gameObject3 = UnityEngine.Object.Instantiate(gameObject) as GameObject;
			UIHIBtn component = gameObject3.GetComponent<UIHIBtn>();
			component.m_Handler = this;
			gameObject3.transform.SetParent(base.transform);
			gameObject3.transform.localScale = Vector3.one;
			gameObject3.transform.localPosition = Vector3.zero;
			this.OtherHoles[m].rectTransform = (gameObject3.transform as RectTransform);
			this.OtherHoles[m].button = gameObject3.GetComponent<UIHIBtn>();
			this.OtherHoles[m].button.m_BtnID1 = m + 1;
			this.OtherHoles[m].image = gameObject3.GetComponent<Image>();
		}
		gameObject = new GameObject("Dir");
		this.ArrowTrans = gameObject.AddComponent<RectTransform>();
		this.ArrowTrans.anchorMin = Vector2.zero;
		this.ArrowTrans.anchorMax = Vector2.zero;
		this.ArrowTrans.pivot = new Vector2(0.5f, 0.5f);
		this.ArrowTrans.sizeDelta = new Vector2(98f, 71f);
		this.Arrow = gameObject.AddComponent<Image>();
		for (int n = 0; n < array.Length; n++)
		{
			if (array[n].name == "UI_new_arrow_01")
			{
				this.Arrow.sprite = (array[n] as Sprite);
			}
		}
		this.Arrow.material = this.ShareMat;
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.SetActive(false);
		gameObject = new GameObject("TextBox");
		this.TextBoxTrans = gameObject.AddComponent<RectTransform>();
		this.TextBoxTrans.anchorMin = Vector2.zero;
		this.TextBoxTrans.anchorMax = Vector2.zero;
		this.TextBoxTrans.pivot = new Vector2(0.5f, 0.5f);
		this.TextBox = gameObject.AddComponent<Image>();
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			if (array[num2].name == "UI_new_box_02")
			{
				this.TextBox.sprite = (array[num2] as Sprite);
			}
		}
		this.TextBox.material = this.ShareMat;
		this.TextBox.type = Image.Type.Sliced;
		gameObject.AddComponent<IgnoreRaycast>();
		gameObject.transform.SetParent(base.transform);
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.SetActive(false);
		gameObject = new GameObject("Text");
		this.TextTrans = gameObject.AddComponent<RectTransform>();
		this.TextTrans.anchorMin = new Vector2(0.5f, 0f);
		this.TextTrans.anchorMax = new Vector2(0.5f, 0f);
		this.TextTrans.pivot = new Vector2(0.5f, 0f);
		this.m_Text = gameObject.AddComponent<UIText>();
		this.m_Text.font = GUIManager.Instance.GetTTFFont();
		this.m_Text.color = Color.black;
		this.m_Text.fontSize = 24;
		this.m_Text.alignment = TextAnchor.MiddleLeft;
		this.m_Text.supportRichText = true;
		gameObject.AddComponent<IgnoreRaycast>();
		gameObject.transform.SetParent(this.TextBoxTrans);
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = Vector3.zero;
		this.TextTrans.anchoredPosition = new Vector2(0f, 0f);
		for (int num3 = 0; num3 < 3; num3++)
		{
			gameObject = new GameObject("TextEx");
			this.m_TextExTrans[num3] = gameObject.AddComponent<RectTransform>();
			this.m_TextExTrans[num3].anchorMin = Vector2.zero;
			this.m_TextExTrans[num3].anchorMax = Vector2.zero;
			this.m_TextExTrans[num3].pivot = new Vector2(0.5f, 0.5f);
			this.m_TextEx[num3] = gameObject.AddComponent<UIText>();
			this.m_TextEx[num3].font = GUIManager.Instance.GetTTFFont();
			this.m_TextEx[num3].color = Color.black;
			this.m_TextEx[num3].fontSize = 17;
			this.m_TextEx[num3].alignment = TextAnchor.MiddleCenter;
			gameObject.AddComponent<IgnoreRaycast>();
			gameObject.transform.SetParent(this.TextBoxTrans);
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localPosition = Vector3.zero;
			this.m_TextExTrans[num3].anchoredPosition = new Vector2(this.textPosX[num3], 30f);
			gameObject.SetActive(false);
		}
		for (int num4 = 0; num4 < 3; num4++)
		{
			gameObject = new GameObject("ImageEx");
			this.m_ImageExTrans[num4] = gameObject.AddComponent<RectTransform>();
			this.m_ImageExTrans[num4].anchorMin = Vector2.zero;
			this.m_ImageExTrans[num4].anchorMax = Vector2.zero;
			this.m_ImageExTrans[num4].pivot = new Vector2(0.5f, 0.5f);
			this.m_ImageEx[num4] = gameObject.AddComponent<Image>();
			gameObject.AddComponent<IgnoreRaycast>();
			gameObject.transform.SetParent(this.TextBoxTrans);
			gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.SetActive(false);
		}
		Sprite sprite = null;
		for (int num5 = 0; num5 < array.Length; num5++)
		{
			if (array[num5].name == "UI_slide")
			{
				sprite = (array[num5] as Sprite);
				break;
			}
		}
		for (int num6 = 0; num6 < 5; num6++)
		{
			gameObject = new GameObject("Pointer");
			this.m_PointerTrans[num6] = gameObject.AddComponent<RectTransform>();
			this.m_PointerTrans[num6].anchorMin = new Vector2(0.5f, 0f);
			this.m_PointerTrans[num6].anchorMax = new Vector2(0.5f, 0f);
			this.m_PointerTrans[num6].pivot = new Vector2(0.5f, 0.5f);
			this.m_Pointer[num6] = gameObject.AddComponent<Image>();
			this.m_Pointer[num6].material = this.ShareMat;
			this.m_Pointer[num6].sprite = sprite;
			this.m_Pointer[num6].SetNativeSize();
			if (num6 > 0)
			{
				this.m_Pointer[num6].color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0);
			}
			gameObject.AddComponent<IgnoreRaycast>();
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.SetActive(false);
		}
		gameObject = new GameObject("StageDir");
		this.StageArrowTrans = gameObject.AddComponent<RectTransform>();
		this.StageArrowTrans.anchorMin = Vector2.zero;
		this.StageArrowTrans.anchorMax = Vector2.zero;
		this.StageArrowTrans.pivot = new Vector2(0.5f, 0.5f);
		this.StageArrowTrans.sizeDelta = new Vector2(98f, 71f);
		Image image = gameObject.AddComponent<Image>();
		image.sprite = this.Arrow.sprite;
		image.material = new Material(this.ShareMat)
		{
			renderQueue = 2500
		};
		gameObject.transform.SetParent(GUIManager.Instance.m_BottomLayer);
		gameObject.transform.localScale = Vector3.one;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.SetActive(false);
		gameObject = new GameObject("CoordTester");
		this.CoordTester = gameObject.AddComponent<RectTransform>();
		this.CoordTester.SetParent(base.transform, true);
		this.CoordTester.anchorMax = Vector2.zero;
		this.CoordTester.anchorMin = Vector2.zero;
		this.CoordTester.pivot = Vector2.one * 0.5f;
	}

	// Token: 0x06002796 RID: 10134 RVA: 0x0043D064 File Offset: 0x0043B264
	public void RebuildText()
	{
		if (this.TextBoxTrans != null && this.TextBoxTrans.gameObject.activeSelf)
		{
			this.m_Text.enabled = false;
			this.m_Text.enabled = true;
		}
	}

	// Token: 0x06002797 RID: 10135 RVA: 0x0043D0B0 File Offset: 0x0043B2B0
	public Vector2 ScreenPointTest(RectTransform rt)
	{
		this.CoordTester.SetParent(rt);
		this.CoordTester.localPosition = Vector3.zero;
		this.CoordTester.SetParent(base.transform, true);
		Vector2 b = new Vector2(rt.sizeDelta.x * (0.5f - rt.pivot.x), rt.sizeDelta.y * (0.5f - rt.pivot.y));
		return this.CoordTester.anchoredPosition + b;
	}

	// Token: 0x06002798 RID: 10136 RVA: 0x0043D14C File Offset: 0x0043B34C
	public void Update()
	{
		if (this.pManager != null)
		{
			this.pManager.Update();
		}
		if (this.bArrowShow)
		{
			if (this.ArrowDir == EArrowDir.RIGHT)
			{
				this.ArrowPosOffset.x = this.ArrowPosOffset.x + Time.deltaTime * 40f * (float)this.ArrowMoveSign;
				if (this.ArrowPosOffset.x >= 40f)
				{
					this.ArrowPosOffset.x = 40f;
					this.ArrowMoveSign *= -1;
				}
				else if (this.ArrowPosOffset.x <= 0f)
				{
					this.ArrowPosOffset.x = 0f;
					this.ArrowMoveSign *= -1;
				}
			}
			else if (this.ArrowDir == EArrowDir.UP)
			{
				this.ArrowPosOffset.y = this.ArrowPosOffset.y - Time.deltaTime * 40f * (float)this.ArrowMoveSign;
				if (this.ArrowPosOffset.y <= -40f)
				{
					this.ArrowPosOffset.y = -40f;
					this.ArrowMoveSign *= -1;
				}
				else if (this.ArrowPosOffset.y >= 0f)
				{
					this.ArrowPosOffset.y = 0f;
					this.ArrowMoveSign *= -1;
				}
			}
			else if (this.ArrowDir == EArrowDir.DOWN)
			{
				this.ArrowPosOffset.y = this.ArrowPosOffset.y + Time.deltaTime * 40f * (float)this.ArrowMoveSign;
				if (this.ArrowPosOffset.y >= 40f)
				{
					this.ArrowPosOffset.y = 40f;
					this.ArrowMoveSign *= -1;
				}
				else if (this.ArrowPosOffset.y <= 0f)
				{
					this.ArrowPosOffset.y = 0f;
					this.ArrowMoveSign *= -1;
				}
			}
			else if (this.ArrowDir == EArrowDir.LEFT)
			{
				this.ArrowPosOffset.x = this.ArrowPosOffset.x - Time.deltaTime * 40f * (float)this.ArrowMoveSign;
				if (this.ArrowPosOffset.x <= -40f)
				{
					this.ArrowPosOffset.x = -40f;
					this.ArrowMoveSign *= -1;
				}
				else if (this.ArrowPosOffset.x >= 0f)
				{
					this.ArrowPosOffset.x = 0f;
					this.ArrowMoveSign *= -1;
				}
			}
			this.ArrowTrans.anchoredPosition = this.ArrowPos + this.ArrowPosOffset;
		}
		if (this.bStageArrowShow)
		{
			this.StageArrowPosOffset.y = this.StageArrowPosOffset.y + Time.deltaTime * 40f * (float)this.StageArrowMoveSign;
			if (this.StageArrowPosOffset.y >= 40f)
			{
				this.StageArrowPosOffset.y = 40f;
				this.StageArrowMoveSign *= -1;
			}
			else if (this.StageArrowPosOffset.y <= 0f)
			{
				this.StageArrowPosOffset.y = 0f;
				this.StageArrowMoveSign *= -1;
			}
			this.StageArrowTrans.anchoredPosition = this.StageArrowPos + this.StageArrowPosOffset;
		}
		if (this.m_FlowLineFactoryNewbie != null)
		{
			this.m_FlowLineFactoryNewbie.Update(Time.deltaTime);
		}
		if (this.Npc_Node != null)
		{
			this.Npc_Node.Run();
		}
		this.UpdatePointer();
	}

	// Token: 0x06002799 RID: 10137 RVA: 0x0043D504 File Offset: 0x0043B704
	public void UpdatePointer()
	{
		if (this.bPointerShow)
		{
			if (this.PointerState == 0)
			{
				Vector2 anchoredPosition = GameConstants.QuadraticBezierCurves(this.StartPoint, this.CenterPoint, this.EndPoint, 1f, this.PointerTimer);
				this.m_PointerTrans[0].anchoredPosition = anchoredPosition;
				this.PointerTimer += Time.smoothDeltaTime;
				this.PointerTimer2 += Time.smoothDeltaTime;
				if (this.PointerTimer2 > 0.2f)
				{
					this.PointerTimer2 = 0f;
					this.PointerColor[this.PointerFlag].a = 0.5f;
					this.m_PointerTrans[this.PointerFlag].anchoredPosition = anchoredPosition;
					this.m_Pointer[this.PointerFlag].color = this.PointerColor[this.PointerFlag];
					this.PointerFlag++;
					if (this.PointerFlag > 4)
					{
						this.PointerFlag = 1;
					}
				}
				if (this.PointerTimer > 1f)
				{
					this.PointerState = 1;
					this.PointerTimer = 0f;
				}
			}
			else if (this.PointerState == 1)
			{
				this.PointerTimer += Time.smoothDeltaTime;
				if (this.PointerTimer > 0.5f)
				{
					this.PointerState = 0;
					this.PointerTimer = 0f;
				}
			}
			for (int i = 1; i < 5; i++)
			{
				if (this.PointerColor[i].a > 0.001f)
				{
					Color[] pointerColor = this.PointerColor;
					int num = i;
					pointerColor[num].a = pointerColor[num].a - Time.smoothDeltaTime * 0.5f;
					this.PointerColor[i].a = Mathf.Max(this.PointerColor[i].a, 0f);
					this.m_Pointer[i].color = this.PointerColor[i];
				}
			}
		}
	}

	// Token: 0x0600279A RID: 10138 RVA: 0x0043D710 File Offset: 0x0043B910
	public void ShowPointer(bool bShow, Vector2? start = null, Vector2? end = null)
	{
		if (bShow)
		{
			if (start != null)
			{
				this.StartPoint = start.Value;
			}
			if (end != null)
			{
				this.EndPoint = end.Value;
			}
			this.CenterPoint = new Vector2(this.StartPoint.x, this.EndPoint.y);
			this.PointerState = 0;
			this.PointerTimer = 0f;
			this.PointerTimer2 = 0f;
			this.PointerFlag = 1;
		}
		this.bPointerShow = bShow;
		this.m_Pointer[0].gameObject.SetActive(bShow);
		for (int i = 1; i < 5; i++)
		{
			this.m_Pointer[i].gameObject.SetActive(bShow);
			this.PointerColor[i] = new Color(1f, 1f, 1f, 0f);
		}
	}

	// Token: 0x0600279B RID: 10139 RVA: 0x0043D804 File Offset: 0x0043BA04
	public void ToEnemyPointer(Vector2 start, int enemyIdx, int param = 0)
	{
		BattleController battleController = GameManager.ActiveGameplay as BattleController;
		if (battleController != null)
		{
			Vector2 vector = Camera.main.WorldToScreenPoint(battleController.enemyUnit[enemyIdx].Position);
			float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
			vector /= scaleFactor;
			if (GUIManager.Instance.IsArabic)
			{
				RectTransform canvasRT = GUIManager.Instance.pDVMgr.CanvasRT;
				vector.x += (canvasRT.sizeDelta.x * 0.5f - vector.x) * 2f;
			}
			this.ShowPointer(true, new Vector2?(start), new Vector2?(vector));
		}
	}

	// Token: 0x0600279C RID: 10140 RVA: 0x0043D8BC File Offset: 0x0043BABC
	public void ToEnemyPointer(Vector2 start, Vector2 end)
	{
		float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
		end /= scaleFactor;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform canvasRT = GUIManager.Instance.pDVMgr.CanvasRT;
			end.x += (canvasRT.sizeDelta.x * 0.5f - end.x) * 2f;
		}
		this.ShowPointer(true, new Vector2?(start), new Vector2?(end));
	}

	// Token: 0x0600279D RID: 10141 RVA: 0x0043D944 File Offset: 0x0043BB44
	public void SetArrow(bool bShow, EArrowDir dir = EArrowDir.RIGHT)
	{
		if (bShow)
		{
			this.ArrowTrans.gameObject.SetActive(true);
			this.ArrowTrans.localRotation = Quaternion.identity;
			if (dir == EArrowDir.UP)
			{
				this.ArrowTrans.Rotate(new Vector3(0f, 0f, 90f));
				this.ArrowTrans.anchoredPosition = this.HoleTrans.anchoredPosition + new Vector2(0f, -(this.HoleTrans.sizeDelta.y * 0.5f + 50f));
			}
			else if (dir == EArrowDir.DOWN)
			{
				this.ArrowTrans.Rotate(new Vector3(0f, 0f, 270f));
				this.ArrowTrans.anchoredPosition = this.HoleTrans.anchoredPosition + new Vector2(0f, this.HoleTrans.sizeDelta.y * 0.5f + 50f);
			}
			else if (dir == EArrowDir.LEFT)
			{
				this.ArrowTrans.Rotate(new Vector3(0f, 0f, 180f));
				this.ArrowTrans.anchoredPosition = this.HoleTrans.anchoredPosition + new Vector2(this.HoleTrans.sizeDelta.x * 0.5f + 50f, 0f);
			}
			else
			{
				this.ArrowTrans.anchoredPosition = this.HoleTrans.anchoredPosition + new Vector2(-(this.HoleTrans.sizeDelta.x * 0.5f + 50f), 0f);
			}
			this.ArrowTrans.anchoredPosition3D = new Vector3(this.ArrowTrans.anchoredPosition.x, this.ArrowTrans.anchoredPosition.y, 0f);
			this.ArrowPos = this.ArrowTrans.anchoredPosition;
			this.ArrowPosOffset = Vector2.zero;
			this.ArrowDir = dir;
			this.ArrowMoveSign = 1;
			this.bArrowShow = true;
		}
		else
		{
			this.ArrowTrans.gameObject.SetActive(false);
			this.bArrowShow = false;
		}
	}

	// Token: 0x0600279E RID: 10142 RVA: 0x0043DB98 File Offset: 0x0043BD98
	public void SetStageArrow(bool bShow, Vector2? pos = null)
	{
		if (bShow)
		{
			this.StageArrowTrans.gameObject.SetActive(true);
			this.StageArrowTrans.localRotation = Quaternion.identity;
			this.StageArrowTrans.Rotate(new Vector3(0f, 0f, 270f));
			this.StageArrowTrans.anchoredPosition = ((pos != null) ? pos.Value : Vector2.zero);
			this.StageArrowTrans.anchoredPosition3D = new Vector3(this.StageArrowTrans.anchoredPosition.x, this.StageArrowTrans.anchoredPosition.y, 0f);
			this.StageArrowPos = this.StageArrowTrans.anchoredPosition;
			this.StageArrowPosOffset = Vector2.zero;
			this.StageArrowMoveSign = 1;
			this.bStageArrowShow = true;
		}
		else
		{
			this.StageArrowTrans.gameObject.SetActive(false);
			this.bStageArrowShow = false;
		}
	}

	// Token: 0x0600279F RID: 10143 RVA: 0x0043DC98 File Offset: 0x0043BE98
	public void SetText(ushort Key, Vector2 offset)
	{
		this.TextBoxTrans.gameObject.SetActive(true);
		this.TextBoxTrans.localRotation = Quaternion.identity;
		this.TextBoxTrans.anchoredPosition = this.HoleTrans.anchoredPosition + offset;
		this.m_Text.text = DataManager.Instance.mStringTable.GetStringByID((uint)Key);
		this.TextTrans.sizeDelta = new Vector2(1920f, 1920f);
		this.TextTrans.sizeDelta = new Vector2(this.m_Text.preferredWidth, this.m_Text.preferredHeight + 26f);
		this.TextBoxTrans.sizeDelta = new Vector2(this.TextTrans.sizeDelta.x + 26f, this.m_Text.preferredHeight + 26f);
		this.TextTrans.anchoredPosition = new Vector2(0f, 0f);
		Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
		float num = this.TextBoxTrans.anchoredPosition.x - this.TextBoxTrans.sizeDelta.x * 0.5f;
		float num2 = this.TextBoxTrans.anchoredPosition.x + this.TextBoxTrans.sizeDelta.x * 0.5f;
		Vector2 anchoredPosition = this.TextBoxTrans.anchoredPosition;
		if (num < 0f)
		{
			anchoredPosition.x -= num;
			this.TextBoxTrans.anchoredPosition = anchoredPosition;
		}
		else if (num2 > sizeDelta.x)
		{
			anchoredPosition.x -= num2 - sizeDelta.x;
			this.TextBoxTrans.anchoredPosition = anchoredPosition;
		}
	}

	// Token: 0x060027A0 RID: 10144 RVA: 0x0043DE78 File Offset: 0x0043C078
	public void SetBlackVisible(bool bShow)
	{
		this.BlackPanel.color = new Color32(0, 0, 0, (!bShow) ? 0 : 130);
		RectTransform rectTransform = this.BlackPanel.transform as RectTransform;
		rectTransform.localRotation = Quaternion.identity;
		rectTransform.anchoredPosition = Vector2.zero;
	}

	// Token: 0x060027A1 RID: 10145 RVA: 0x0043DED8 File Offset: 0x0043C0D8
	public void SetHoleVisible(bool bShow, Rect? _r = null, HolePivot pivot = HolePivot.CENTER, bool setAP = false)
	{
		this.HoleMaskPanel.gameObject.SetActive(bShow);
		this.HolePanel.gameObject.SetActive(bShow);
		if (bShow)
		{
			if (_r == null)
			{
				Rect value = default(Rect);
				Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
				value.position = sizeDelta * 0.5f;
				value.size = sizeDelta * 1.3f;
				_r = new Rect?(value);
			}
			this.HoleMaskTrans.localRotation = Quaternion.identity;
			this.HoleTrans.localRotation = Quaternion.identity;
			Vector2 pivot2 = new Vector2(0.5f, 0.5f);
			if (pivot == HolePivot.BOTTOM_LEFT)
			{
				pivot2 = new Vector2(0f, 0f);
			}
			else if (pivot == HolePivot.BOTTOM_RIGHT)
			{
				pivot2 = new Vector2(1f, 0f);
			}
			else if (pivot == HolePivot.TOP_LEFT)
			{
				pivot2 = new Vector2(0f, 1f);
			}
			else if (pivot == HolePivot.TOP_RIGHT)
			{
				pivot2 = new Vector2(1f, 1f);
			}
			this.HoleMaskTrans.pivot = pivot2;
			this.HoleTrans.pivot = pivot2;
			Rect value2 = _r.Value;
			this.HoleMaskTrans.sizeDelta = new Vector2(value2.width, value2.height);
			if (setAP)
			{
				this.HoleMaskTrans.anchoredPosition = new Vector3(value2.position.x, value2.position.y, 0f);
			}
			else
			{
				this.HoleMaskTrans.localPosition = new Vector3(value2.position.x, value2.position.y, 0f);
			}
			this.HoleTrans.sizeDelta = new Vector2(value2.width, value2.height);
			this.HoleTrans.localPosition = new Vector3(value2.position.x, value2.position.y, 0f);
		}
	}

	// Token: 0x060027A2 RID: 10146 RVA: 0x0043E114 File Offset: 0x0043C314
	public void SetOtherHoleVisible(int idx, bool bShow, Vector2 pos)
	{
		if (idx >= 5)
		{
			return;
		}
		this.OtherHoles[idx].HoleMaskRectTransform.gameObject.SetActive(bShow);
		this.OtherHoles[idx].rectTransform.gameObject.SetActive(bShow);
		if (bShow)
		{
			this.OtherHoles[idx].HoleMaskRectTransform.localRotation = Quaternion.identity;
			this.OtherHoles[idx].rectTransform.localRotation = Quaternion.identity;
			this.OtherHoles[idx].HoleMaskRectTransform.pivot = this.HoleMaskTrans.pivot;
			this.OtherHoles[idx].rectTransform.pivot = this.HoleMaskTrans.pivot;
			this.OtherHoles[idx].HoleMaskRectTransform.sizeDelta = this.HoleMaskTrans.sizeDelta;
			this.OtherHoles[idx].HoleMaskRectTransform.localPosition = new Vector3(pos.x, pos.y, 0f);
			this.OtherHoles[idx].rectTransform.sizeDelta = this.HoleMaskTrans.sizeDelta;
			this.OtherHoles[idx].rectTransform.localPosition = new Vector3(pos.x, pos.y, 0f);
		}
	}

	// Token: 0x060027A3 RID: 10147 RVA: 0x0043E280 File Offset: 0x0043C480
	public void SetSpecialBox(bool bShow, byte type = 0)
	{
		if (bShow)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door == null)
			{
				return;
			}
			if (door.m_GroundInfo.TileMapMat == null)
			{
				door.m_GroundInfo.TileMapMat = (UnityEngine.Object.Instantiate(door.TileMapController.TileSprites.m_Image.material) as Material);
				door.m_GroundInfo.TileMapMat.renderQueue = 3000;
			}
			this.TextBoxTrans.gameObject.SetActive(true);
			this.TextBoxTrans.sizeDelta = new Vector2(500f, 150f);
			Vector2 a = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta * 0.5f;
			this.TextBoxTrans.anchoredPosition = a + new Vector2(0f, 60f);
			for (int i = 0; i < 3; i++)
			{
				this.m_ImageEx[i].gameObject.SetActive(true);
				this.m_ImageEx[i].material = door.m_GroundInfo.TileMapMat;
			}
			if (type == 0)
			{
				door.TileMapController.getTileMapSprite(ref this.m_ImageEx[0], POINT_KIND.PK_CITY, 25, CITY_OUTWARD.CO_PLAYER);
				this.m_ImageEx[0].SetNativeSize();
				this.m_ImageExTrans[0].anchoredPosition = new Vector2(95f, 70f);
				door.TileMapController.getTileMapSprite(ref this.m_ImageEx[2], POINT_KIND.PK_FOOD, 0, CITY_OUTWARD.CO_PLAYER);
				this.m_ImageEx[2].SetNativeSize();
				this.m_ImageExTrans[2].anchoredPosition = new Vector2(396.5f, 70f);
				this.m_ImageExTrans[1].anchoredPosition = new Vector2(95f, 60f);
				Vector3 position = this.m_ImageExTrans[1].position;
				this.m_ImageExTrans[1].anchoredPosition = new Vector2(396.5f, 60f);
				Vector3 position2 = this.m_ImageExTrans[1].position;
				this.m_ImageEx[1].gameObject.SetActive(false);
				CHAOS chaos = GameManager.ActiveGameplay as CHAOS;
				if (chaos != null && chaos.realmController != null)
				{
					if (this.m_FlowLineFactoryNewbie == null)
					{
						this.m_FlowLineFactoryNewbie = new FlowLineFactoryNewbie(chaos.realmController.RealmGroup_3DTransform, chaos.realmController.mapTileController.TileBaseScale);
					}
					MapLine mapLine = new MapLine();
					mapLine.lineID = uint.MaxValue;
					mapLine.begin = (ulong)DataManager.Instance.ServerTime;
					mapLine.during = 5u;
					mapLine.lineFlag = 0;
					this.m_FlowLineFactoryNewbie.createLine(mapLine, position, position2, ELineColor.DEEPBLUE, EUnitSide.BLUE, false, true, EMonsterFace.LEFT, 1);
				}
			}
			else if (type == 1)
			{
				door.TileMapController.getTileMapSprite(ref this.m_ImageEx[0], POINT_KIND.PK_CITY, 25, CITY_OUTWARD.CO_PLAYER);
				this.m_ImageEx[0].SetNativeSize();
				this.m_ImageExTrans[0].anchoredPosition = new Vector2(95f, 70f);
				door.TileMapController.getTileMapSprite(ref this.m_ImageEx[2], POINT_KIND.PK_CITY, 24, CITY_OUTWARD.CO_PLAYER);
				this.m_ImageEx[2].SetNativeSize();
				this.m_ImageExTrans[2].anchoredPosition = new Vector2(412.4f, 70f);
				this.m_ImageExTrans[1].anchoredPosition = new Vector2(95f, 60f);
				Vector3 position3 = this.m_ImageExTrans[1].position;
				this.m_ImageExTrans[1].anchoredPosition = new Vector2(412.4f, 60f);
				Vector3 position4 = this.m_ImageExTrans[1].position;
				this.m_ImageEx[1].gameObject.SetActive(false);
				CHAOS chaos2 = GameManager.ActiveGameplay as CHAOS;
				if (chaos2 != null && chaos2.realmController != null)
				{
					if (this.m_FlowLineFactoryNewbie == null)
					{
						this.m_FlowLineFactoryNewbie = new FlowLineFactoryNewbie(chaos2.realmController.RealmGroup_3DTransform, chaos2.realmController.mapTileController.TileBaseScale);
					}
					MapLine mapLine2 = new MapLine();
					mapLine2.lineID = uint.MaxValue;
					mapLine2.begin = (ulong)DataManager.Instance.ServerTime;
					mapLine2.during = 2u;
					mapLine2.lineFlag = 5;
					this.m_FlowLineFactoryNewbie.createLine(mapLine2, position3, position4, ELineColor.DEEPBLUE, EUnitSide.BLUE, false, true, EMonsterFace.LEFT, 1);
					this.m_FlowLineFactoryNewbie.MoveUnitToEndPoint(EMarchEventType.EMET_AttackRetreat);
				}
			}
			else if (type == 2)
			{
				door.TileMapController.getTileMapSprite(ref this.m_ImageEx[0], POINT_KIND.PK_CITY, 25, CITY_OUTWARD.CO_PLAYER);
				this.m_ImageEx[0].SetNativeSize();
				this.m_ImageExTrans[0].anchoredPosition = new Vector2(95f, 70f);
				this.m_ImageEx[1].gameObject.SetActive(false);
				this.m_ImageExTrans[2].anchoredPosition = new Vector2(412.4f, 70f);
				Vector2 inipos = this.m_ImageExTrans[2].transform.position;
				float iniscale = 1f / GUIManager.Instance.pDVMgr.CanvasRT.localScale.x;
				this.Npc_Parent = new GameObject("NPC");
				Transform transform = this.Npc_Parent.transform;
				transform.parent = this.m_ImageExTrans[2].parent;
				transform.position = Vector3.zero;
				transform.localScale = Vector3.one;
				this.Npc_Node = new NPC(inipos, iniscale, 1, 2, NPCState.NPC_Idle, transform, ref this.Npc_ABKey);
				this.Npc_Node.SetActive(true);
				this.m_ImageExTrans[2].anchoredPosition = new Vector2(95f, 60f);
				Vector3 position5 = this.m_ImageEx[2].transform.position;
				this.m_ImageExTrans[2].anchoredPosition = new Vector2(395f, 60f);
				Vector3 position6 = this.m_ImageEx[2].transform.position;
				this.m_ImageEx[2].gameObject.SetActive(false);
				CHAOS chaos3 = GameManager.ActiveGameplay as CHAOS;
				if (chaos3 != null && chaos3.realmController != null)
				{
					if (this.m_FlowLineFactoryNewbie == null)
					{
						this.m_FlowLineFactoryNewbie = new FlowLineFactoryNewbie(chaos3.realmController.RealmGroup_3DTransform, chaos3.realmController.mapTileController.TileBaseScale);
					}
					MapLine mapLine3 = new MapLine();
					mapLine3.lineID = uint.MaxValue;
					mapLine3.begin = (ulong)DataManager.Instance.ServerTime;
					mapLine3.during = 2u;
					mapLine3.lineFlag = 9;
					LineNode lineNode = this.m_FlowLineFactoryNewbie.createLine(mapLine3, position5, position6, ELineColor.DEEPBLUE, EUnitSide.BLUE, false, true, EMonsterFace.LEFT, 1);
					this.m_FlowLineFactoryNewbie.MoveUnitToEndPoint(EMarchEventType.EMET_HitMonsterRetreat);
				}
			}
		}
		else
		{
			for (int j = 0; j < 3; j++)
			{
				this.m_ImageEx[j].gameObject.SetActive(false);
			}
			if (this.m_FlowLineFactoryNewbie != null)
			{
				this.m_FlowLineFactoryNewbie.ClearLine();
			}
			if (this.Npc_Node != null)
			{
				this.Npc_Node.Release();
				this.Npc_Node = null;
				AssetManager.UnloadAssetBundle(this.Npc_ABKey, true);
			}
			if (this.Npc_Parent != null)
			{
				UnityEngine.Object.Destroy(this.Npc_Parent);
				this.Npc_Parent = null;
			}
		}
	}

	// Token: 0x060027A4 RID: 10148 RVA: 0x0043E9D0 File Offset: 0x0043CBD0
	public void HideUI(bool force = false)
	{
		this.SetBlackVisible(false);
		this.SetHoleVisible(false, null, HolePivot.CENTER, false);
		this.SetArrow(false, EArrowDir.RIGHT);
		this.ShowPointer(false, null, null);
		if (this.PreClickFlag != 1 || force)
		{
			this.SetSpecialBox(false, 0);
			this.m_Text.text = string.Empty;
			this.TextBoxTrans.gameObject.SetActive(false);
		}
		for (int i = 0; i < 5; i++)
		{
			this.OtherHoles[i].rectTransform.gameObject.SetActive(false);
			this.OtherHoles[i].HoleMaskRectTransform.gameObject.SetActive(false);
		}
	}

	// Token: 0x060027A5 RID: 10149 RVA: 0x0043EA9C File Offset: 0x0043CC9C
	public void TriggerButtonEvent(int btnid = 0)
	{
		int workingKey = this.pManager.WorkingKey;
		this.pManager.SubStep++;
		this.HideUI(false);
		NewbieManager.ClickBtnID = btnid;
		this.pManager.ExeClickAction(workingKey);
		if (this.pManager.NextUI != EGUIWindow.MAX && this.pManager.UIOperator == 0)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(this.pManager.NextUI, this.pManager.NextUIArg1, 0, false);
		}
	}

	// Token: 0x060027A6 RID: 10150 RVA: 0x0043EB38 File Offset: 0x0043CD38
	public bool CheckOutsideHole()
	{
		Rect rect = new Rect(this.HoleTrans.anchoredPosition.x - this.HoleTrans.sizeDelta.x * 0.5f, this.HoleTrans.anchoredPosition.y - this.HoleTrans.sizeDelta.y * 0.5f, this.HoleTrans.sizeDelta.x, this.HoleTrans.sizeDelta.y);
		return Input.touchCount <= 0 || !rect.Contains(Input.GetTouch(0).position);
	}

	// Token: 0x060027A7 RID: 10151 RVA: 0x0043EBF8 File Offset: 0x0043CDF8
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (this.pManager.IsSpecialKey())
		{
			return;
		}
		this.TriggerButtonEvent(sender.m_BtnID1);
	}

	// Token: 0x060027A8 RID: 10152 RVA: 0x0043EC18 File Offset: 0x0043CE18
	public void OnHIButtonUp(UIHIBtn sender)
	{
		if (!this.pManager.IsSpecialKey())
		{
			return;
		}
		if (this.pManager.PreTriggerCheck())
		{
			this.TriggerButtonEvent(0);
		}
	}

	// Token: 0x060027A9 RID: 10153 RVA: 0x0043EC50 File Offset: 0x0043CE50
	public void OnHIButtonDown(UIHIBtn sender)
	{
		if (this.pManager.WorkingKey == 8010)
		{
			this.pManager.Battle_SecondUltra_BtnDown();
		}
		else if (this.pManager.WorkingKey == 8011)
		{
			this.pManager.Battle_ThirdUltra_BtnDown();
		}
	}

	// Token: 0x060027AA RID: 10154 RVA: 0x0043ECA4 File Offset: 0x0043CEA4
	public void OnHIButtonDrag(UIHIBtn sender)
	{
		if (this.pManager.WorkingKey == 8010)
		{
			this.pManager.Battle_SecondUltra_BtnDrag();
		}
		else if (this.pManager.WorkingKey == 8011)
		{
			this.pManager.Battle_ThirdUltra_BtnDrag();
		}
	}

	// Token: 0x060027AB RID: 10155 RVA: 0x0043ECF8 File Offset: 0x0043CEF8
	public void OnHIButtonDragEnd(UIHIBtn sender)
	{
	}

	// Token: 0x060027AC RID: 10156 RVA: 0x0043ECFC File Offset: 0x0043CEFC
	public void OnHIButtonDragExit(UIHIBtn sender)
	{
	}

	// Token: 0x060027AD RID: 10157 RVA: 0x0043ED00 File Offset: 0x0043CF00
	public void FreeResource()
	{
		AssetManager.UnloadAssetBundle(this.AssetKey, true);
	}

	// Token: 0x0400711E RID: 28958
	private const float N_ARROW_MOVE_RANGE = 40f;

	// Token: 0x0400711F RID: 28959
	private const float N_ARROW_MOVE_SPEED = 40f;

	// Token: 0x04007120 RID: 28960
	public NewbieManager pManager;

	// Token: 0x04007121 RID: 28961
	protected Material ShareMat;

	// Token: 0x04007122 RID: 28962
	protected Texture2D Black;

	// Token: 0x04007123 RID: 28963
	public Image BlackPanel;

	// Token: 0x04007124 RID: 28964
	public Image HoleMaskPanel;

	// Token: 0x04007125 RID: 28965
	public Image HolePanel;

	// Token: 0x04007126 RID: 28966
	public UIHIBtn HoleBtn;

	// Token: 0x04007127 RID: 28967
	private RectTransform HoleMaskTrans;

	// Token: 0x04007128 RID: 28968
	private RectTransform HoleTrans;

	// Token: 0x04007129 RID: 28969
	private NewbieBtnData[] OtherHoles = new NewbieBtnData[5];

	// Token: 0x0400712A RID: 28970
	public Image Arrow;

	// Token: 0x0400712B RID: 28971
	private RectTransform ArrowTrans;

	// Token: 0x0400712C RID: 28972
	private Vector2 ArrowPos = Vector2.zero;

	// Token: 0x0400712D RID: 28973
	private Vector2 ArrowPosOffset = Vector2.zero;

	// Token: 0x0400712E RID: 28974
	private bool bArrowShow;

	// Token: 0x0400712F RID: 28975
	private int ArrowMoveSign = 1;

	// Token: 0x04007130 RID: 28976
	private EArrowDir ArrowDir = EArrowDir.RIGHT;

	// Token: 0x04007131 RID: 28977
	private Vector2 StageArrowPos = Vector2.zero;

	// Token: 0x04007132 RID: 28978
	private bool bStageArrowShow;

	// Token: 0x04007133 RID: 28979
	private Vector2 StageArrowPosOffset = Vector2.zero;

	// Token: 0x04007134 RID: 28980
	private int StageArrowMoveSign = 1;

	// Token: 0x04007135 RID: 28981
	private RectTransform StageArrowTrans;

	// Token: 0x04007136 RID: 28982
	public Image TextBox;

	// Token: 0x04007137 RID: 28983
	private RectTransform TextBoxTrans;

	// Token: 0x04007138 RID: 28984
	private RectTransform TextTrans;

	// Token: 0x04007139 RID: 28985
	private UIText m_Text;

	// Token: 0x0400713A RID: 28986
	public Text[] m_TextEx = new Text[3];

	// Token: 0x0400713B RID: 28987
	public RectTransform[] m_TextExTrans = new RectTransform[3];

	// Token: 0x0400713C RID: 28988
	public Image[] m_ImageEx = new Image[3];

	// Token: 0x0400713D RID: 28989
	public RectTransform[] m_ImageExTrans = new RectTransform[3];

	// Token: 0x0400713E RID: 28990
	public Image[] m_Pointer = new Image[5];

	// Token: 0x0400713F RID: 28991
	public RectTransform[] m_PointerTrans = new RectTransform[5];

	// Token: 0x04007140 RID: 28992
	public bool bPointerShow;

	// Token: 0x04007141 RID: 28993
	public Vector2 StartPoint = Vector2.zero;

	// Token: 0x04007142 RID: 28994
	public Vector2 EndPoint = Vector2.zero;

	// Token: 0x04007143 RID: 28995
	public Vector2 CenterPoint = Vector2.zero;

	// Token: 0x04007144 RID: 28996
	public float PointerTimer;

	// Token: 0x04007145 RID: 28997
	public float PointerTimer2;

	// Token: 0x04007146 RID: 28998
	public byte PointerState;

	// Token: 0x04007147 RID: 28999
	public Color[] PointerColor = new Color[5];

	// Token: 0x04007148 RID: 29000
	public int PointerFlag;

	// Token: 0x04007149 RID: 29001
	public FlowLineFactoryNewbie m_FlowLineFactoryNewbie;

	// Token: 0x0400714A RID: 29002
	public float[] textPosX = new float[]
	{
		90f,
		250f,
		410f
	};

	// Token: 0x0400714B RID: 29003
	public ushort[,] textKey = new ushort[,]
	{
		{
			8072,
			8073,
			8074
		},
		{
			8075,
			8076,
			8077
		}
	};

	// Token: 0x0400714C RID: 29004
	private int AssetKey;

	// Token: 0x0400714D RID: 29005
	public GameObject Npc_Parent;

	// Token: 0x0400714E RID: 29006
	public NPC Npc_Node;

	// Token: 0x0400714F RID: 29007
	public int Npc_ABKey;

	// Token: 0x04007150 RID: 29008
	public int PreClickFlag;

	// Token: 0x04007151 RID: 29009
	public RectTransform CoordTester;
}
