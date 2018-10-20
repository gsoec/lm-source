using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200058D RID: 1421
public class UIHint : IUIButtonClickHandler
{
	// Token: 0x06001C1F RID: 7199 RVA: 0x0031B8BC File Offset: 0x00319ABC
	public UIHint()
	{
		this.HintStyle = new HintStyleBase[3];
	}

	// Token: 0x06001C20 RID: 7200 RVA: 0x0031B8DC File Offset: 0x00319ADC
	void IUIButtonClickHandler.OnButtonClick(UIButton sender)
	{
		this.Hide(true);
	}

	// Token: 0x06001C21 RID: 7201 RVA: 0x0031B8E8 File Offset: 0x00319AE8
	public void Load()
	{
		UnityEngine.Object @object = GUIManager.Instance.m_ManagerAssetBundle.Load("UI_Hint");
		if (@object == null)
		{
			return;
		}
		GUIManager instance = GUIManager.Instance;
		Font ttffont = instance.GetTTFFont();
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
		gameObject.transform.SetParent(GUIManager.Instance.m_ItemInfoLayer, false);
		this.Recttrans = gameObject.GetComponent<RectTransform>();
		this.gameObject = this.Recttrans.gameObject;
		this.FadeOutCanvas = this.Recttrans.GetComponent<CanvasGroup>();
		this.HintFrame = this.Recttrans.GetComponent<Image>();
		this.HintFrame.material = instance.GetFrameMaterial();
		this.m_ArmyHint = AssetManager.GetAssetBundle("UI/UIArmyHint", out this.m_ArmyHintAssetBundleKey, false);
		@object = this.m_ArmyHint.Load("UIArmyHint");
		if (@object == null)
		{
			return;
		}
		gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
		gameObject.transform.SetParent(this.Recttrans, false);
		gameObject.SetActive(false);
		@object = GUIManager.Instance.m_ManagerAssetBundle.Load("UI_PetSkillInfo");
		if (@object != null)
		{
			gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
			gameObject.transform.SetParent(this.Recttrans, false);
			gameObject.SetActive(false);
		}
	}

	// Token: 0x06001C22 RID: 7202 RVA: 0x0031BA38 File Offset: 0x00319C38
	public void UnLoad()
	{
		if (this.m_ArmyHintAssetBundleKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.m_ArmyHintAssetBundleKey, true);
		}
		this.m_ArmyHintAssetBundleKey = 0;
		UnityEngine.Object.Destroy(this.gameObject);
	}

	// Token: 0x06001C23 RID: 7203 RVA: 0x0031BA64 File Offset: 0x00319C64
	public void Show(UIButtonHint hint, UIHintStyle eStyle, byte kind, float width, int fontsize, CString Content, Vector2 upsetPos)
	{
		if (this.HintStyle[(int)eStyle] == null)
		{
			this.HintStyle[(int)eStyle] = this.CreateHintStyle(eStyle);
		}
		if (this.Style != null)
		{
			this.Style.SetActive(false);
		}
		this.Style = this.HintStyle[(int)eStyle];
		if (this.Style == null)
		{
			return;
		}
		this.ResetVal();
		Vector2 sizeDelta = this.Recttrans.sizeDelta;
		sizeDelta.x = width;
		this.Recttrans.sizeDelta = sizeDelta;
		this.Style.SetContent((int)kind, fontsize, width, Content);
		this.Recttrans.sizeDelta = this.Style.GetSize();
		this.HintFrame.sprite = this.Style.HintFrameSprite;
		this.HintFrame.material = this.Style.HintFrameMat;
		if (this.HintFrame.sprite == null)
		{
			this.HintFrame.enabled = false;
		}
		else
		{
			this.HintFrame.enabled = true;
		}
		hint.GetTipPosition(this.Recttrans, UIButtonHint.ePosition.Original, new Vector3?(upsetPos));
		this.gameObject.SetActive(true);
		this.Style.SetActive(true);
		this.ButtonHint = hint;
	}

	// Token: 0x06001C24 RID: 7204 RVA: 0x0031BBA4 File Offset: 0x00319DA4
	public void Show(UIButtonHint hint, UIHintStyle eStyle, byte kind, float width, int fontsize, int Parm1, int Parm2, Vector2 upsetPos, UIButtonHint.ePosition position = UIButtonHint.ePosition.Original)
	{
		if (this.HintStyle[(int)eStyle] == null)
		{
			this.HintStyle[(int)eStyle] = this.CreateHintStyle(eStyle);
		}
		if (this.Style != null)
		{
			this.Style.SetActive(false);
		}
		this.Style = this.HintStyle[(int)eStyle];
		if (this.Style == null)
		{
			return;
		}
		this.ResetVal();
		Vector2 sizeDelta = this.Recttrans.sizeDelta;
		sizeDelta.x = width;
		this.Recttrans.sizeDelta = sizeDelta;
		this.Style.SetContent((int)kind, fontsize, width, Parm1, Parm2);
		this.Recttrans.sizeDelta = this.Style.GetSize();
		this.HintFrame.sprite = this.Style.HintFrameSprite;
		this.HintFrame.material = this.Style.HintFrameMat;
		if (this.HintFrame.sprite == null)
		{
			this.HintFrame.enabled = false;
		}
		else
		{
			this.HintFrame.enabled = true;
		}
		hint.GetTipPosition(this.Recttrans, position, new Vector3?(upsetPos));
		this.gameObject.SetActive(true);
		this.Style.SetActive(true);
		this.ButtonHint = hint;
	}

	// Token: 0x06001C25 RID: 7205 RVA: 0x0031BCE8 File Offset: 0x00319EE8
	public void Show(Vector2 Position, UIHintStyle eStyle, byte kind, float width, int fontsize, int Parm1, int Parm2)
	{
		if (this.HintStyle[(int)eStyle] == null)
		{
			this.HintStyle[(int)eStyle] = this.CreateHintStyle(eStyle);
		}
		if (this.Style != null)
		{
			this.Style.SetActive(false);
		}
		this.Style = this.HintStyle[(int)eStyle];
		if (this.Style == null)
		{
			return;
		}
		this.ResetVal();
		Vector2 sizeDelta = this.Recttrans.sizeDelta;
		sizeDelta.x = width;
		this.Recttrans.sizeDelta = sizeDelta;
		this.Style.SetContent((int)kind, fontsize, width, Parm1, Parm2);
		this.Recttrans.sizeDelta = this.Style.GetSize();
		this.HintFrame.sprite = this.Style.HintFrameSprite;
		this.HintFrame.material = this.Style.HintFrameMat;
		if (this.HintFrame.sprite == null)
		{
			this.HintFrame.enabled = false;
		}
		else
		{
			this.HintFrame.enabled = true;
		}
		this.GetTipPosition(ref Position);
		this.gameObject.SetActive(true);
		this.Style.SetActive(true);
		GUIManager.Instance.HintMaskObj.Show(this);
		this.SkipClick = 1;
	}

	// Token: 0x06001C26 RID: 7206 RVA: 0x0031BE2C File Offset: 0x0031A02C
	public void ShowPetHint(UIButtonHint hint, PetSkillHint.eKind kind, ushort PetID, ushort SkillID, byte Level, Vector2 upsetPos, UIButtonHint.ePosition position = UIButtonHint.ePosition.Original)
	{
		int parm = (int)PetID << 16 | (int)SkillID;
		this.Show(hint, UIHintStyle.eHintPet, (byte)kind, 0f, 0, parm, (int)Level, upsetPos, position);
	}

	// Token: 0x06001C27 RID: 7207 RVA: 0x0031BE58 File Offset: 0x0031A058
	private void ResetVal()
	{
		this.FadeOutCanvas.alpha = 1f;
		this.FadeTime = 0f;
		this.bFadeOut = false;
	}

	// Token: 0x06001C28 RID: 7208 RVA: 0x0031BE88 File Offset: 0x0031A088
	public void GetTipPosition(ref Vector2 Position)
	{
		this.Recttrans.anchoredPosition = Position;
		Vector2 size = GUIManager.Instance.m_MessageBoxLayer.rect.size;
		this.Recttrans.position = this.Recttrans.position;
		Vector3 anchoredPosition3D = this.Recttrans.anchoredPosition3D;
		anchoredPosition3D.x += this.Recttrans.rect.x;
		anchoredPosition3D.y += this.Recttrans.rect.y;
		anchoredPosition3D.z = 0f;
		if (GUIManager.Instance.IsArabic)
		{
			anchoredPosition3D.x = size.x - anchoredPosition3D.x;
		}
		if (anchoredPosition3D.x + this.Recttrans.sizeDelta.x > size.x)
		{
			anchoredPosition3D.x = size.x - this.Recttrans.sizeDelta.x;
		}
		if (anchoredPosition3D.y + this.Recttrans.rect.height + this.Recttrans.sizeDelta.y <= 0f)
		{
			anchoredPosition3D.y += this.Recttrans.rect.height + this.Recttrans.sizeDelta.y;
		}
		else if (-1f * anchoredPosition3D.y + this.Recttrans.sizeDelta.y > size.y)
		{
			anchoredPosition3D.y = -1f * (size.y - this.Recttrans.sizeDelta.y);
		}
		this.Recttrans.anchoredPosition3D = anchoredPosition3D;
	}

	// Token: 0x06001C29 RID: 7209 RVA: 0x0031C07C File Offset: 0x0031A27C
	public void Hide(bool bFadeOut = false)
	{
		if (this.SkipClick > 0)
		{
			this.SkipClick = 0;
			return;
		}
		if (!this.gameObject.activeSelf)
		{
			return;
		}
		this.bFadeOut = bFadeOut;
		if (!bFadeOut)
		{
			this.gameObject.SetActive(false);
			if (this.Style != null)
			{
				this.Style.SetActive(false);
			}
			this.Style = null;
			this.ButtonHint = null;
		}
	}

	// Token: 0x06001C2A RID: 7210 RVA: 0x0031C0EC File Offset: 0x0031A2EC
	private HintStyleBase CreateHintStyle(UIHintStyle Style)
	{
		HintStyleBase result = null;
		switch (Style)
		{
		case UIHintStyle.eHintSimple:
			result = new SimpleHint(this.Recttrans.GetChild(0) as RectTransform);
			break;
		case UIHintStyle.eHintArmy:
			result = new ArmyHint(this.Recttrans.GetChild(1) as RectTransform);
			break;
		case UIHintStyle.eHintPet:
			result = new PetSkillHint(this.Recttrans.GetChild(2) as RectTransform);
			break;
		}
		return result;
	}

	// Token: 0x06001C2B RID: 7211 RVA: 0x0031C16C File Offset: 0x0031A36C
	public void Update()
	{
		if (this.bFadeOut)
		{
			if (this.FadeTime < this.MaxFadeTime)
			{
				this.FadeOutCanvas.alpha = Mathf.Clamp(1f - this.FadeTime / this.MaxFadeTime, 0f, 1f);
				this.FadeTime += Time.deltaTime;
			}
			else
			{
				this.FadeOutCanvas.alpha = 1f;
				this.FadeTime = 0f;
				if (this.ButtonHint == null)
				{
					GUIManager.Instance.HintMaskObj.Hide(this);
				}
				else
				{
					GUIManager.Instance.HintMaskObj.Hide(this.ButtonHint);
				}
				this.Hide(false);
			}
		}
	}

	// Token: 0x06001C2C RID: 7212 RVA: 0x0031C238 File Offset: 0x0031A438
	public UIButtonHint GetButtonHint()
	{
		return this.ButtonHint;
	}

	// Token: 0x06001C2D RID: 7213 RVA: 0x0031C240 File Offset: 0x0031A440
	public void TextRefresh()
	{
		if (this.Style != null)
		{
			this.Style.TextRefresh();
		}
	}

	// Token: 0x0400551F RID: 21791
	public GameObject gameObject;

	// Token: 0x04005520 RID: 21792
	private RectTransform Recttrans;

	// Token: 0x04005521 RID: 21793
	private Image HintFrame;

	// Token: 0x04005522 RID: 21794
	private HintStyleBase[] HintStyle;

	// Token: 0x04005523 RID: 21795
	private HintStyleBase Style;

	// Token: 0x04005524 RID: 21796
	private bool bFadeOut;

	// Token: 0x04005525 RID: 21797
	private float FadeTime;

	// Token: 0x04005526 RID: 21798
	private float MaxFadeTime = 0.2f;

	// Token: 0x04005527 RID: 21799
	private CanvasGroup FadeOutCanvas;

	// Token: 0x04005528 RID: 21800
	private byte SkipClick;

	// Token: 0x04005529 RID: 21801
	private UIButtonHint ButtonHint;

	// Token: 0x0400552A RID: 21802
	public AssetBundle m_ArmyHint;

	// Token: 0x0400552B RID: 21803
	public int m_ArmyHintAssetBundleKey;
}
