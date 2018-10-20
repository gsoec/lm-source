using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000867 RID: 2151
public class UIButtonHint : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler, IEndDragHandler, IPointerExitHandler, IEventSystemHandler, IUIButtonClickHandler
{
	// Token: 0x1700014F RID: 335
	// (get) Token: 0x06002C4E RID: 11342 RVA: 0x00488B38 File Offset: 0x00486D38
	// (set) Token: 0x06002C4D RID: 11341 RVA: 0x00488B1C File Offset: 0x00486D1C
	public MonoBehaviour m_Handler
	{
		get
		{
			return this._Handler;
		}
		set
		{
			this._Handler = value;
			this.m_DownUpHandler = (this._Handler as IUIButtonDownUpHandler);
		}
	}

	// Token: 0x17000150 RID: 336
	// (get) Token: 0x06002C50 RID: 11344 RVA: 0x00488B84 File Offset: 0x00486D84
	// (set) Token: 0x06002C4F RID: 11343 RVA: 0x00488B40 File Offset: 0x00486D40
	public GameObject ControlFadeOut
	{
		get
		{
			return this._ControlFadeOut;
		}
		set
		{
			this._ControlFadeOut = value;
			if ((this.FadeOutCanvas = this._ControlFadeOut.GetComponent<CanvasGroup>()) == null)
			{
				this.FadeOutCanvas = this._ControlFadeOut.AddComponent<CanvasGroup>();
			}
		}
	}

	// Token: 0x17000151 RID: 337
	// (get) Token: 0x06002C52 RID: 11346 RVA: 0x00488B98 File Offset: 0x00486D98
	// (set) Token: 0x06002C51 RID: 11345 RVA: 0x00488B8C File Offset: 0x00486D8C
	private UIButtonHint._BntAction BtnAction
	{
		get
		{
			return this._BtnAction;
		}
		set
		{
			this._BtnAction = value;
		}
	}

	// Token: 0x06002C53 RID: 11347 RVA: 0x00488BA0 File Offset: 0x00486DA0
	private void Awake()
	{
		this.m_Button = base.GetComponent<Selectable>();
	}

	// Token: 0x06002C54 RID: 11348 RVA: 0x00488BB0 File Offset: 0x00486DB0
	private void OnDestroy()
	{
		if (GameManager.bQuitGame)
		{
			return;
		}
		GUIManager.Instance.m_SimpleItemInfo.Hide(this);
		GUIManager.Instance.m_LordInfo.Hide(this);
		if (this.m_DownUpHandler != null)
		{
			this.m_DownUpHandler.OnButtonUp(this);
		}
		GUIManager.Instance.HintMaskObj.Hide(this);
	}

	// Token: 0x06002C55 RID: 11349 RVA: 0x00488C10 File Offset: 0x00486E10
	private void OnDisable()
	{
		if (GameManager.bQuitGame)
		{
			return;
		}
		if (this.SkipDisabelEvent == 1)
		{
			this.SkipDisabelEvent = 0;
			return;
		}
		GUIManager.Instance.m_SimpleItemInfo.Hide(this);
		GUIManager.Instance.m_LordInfo.Hide(this);
		if (GUIManager.Instance.m_SkillInfo.m_RectTransform.gameObject.activeSelf)
		{
			GUIManager.Instance.m_SkillInfo.Hide(this);
		}
		if (this.m_DownUpHandler != null)
		{
			this.m_DownUpHandler.OnButtonUp(this);
		}
		GUIManager.Instance.HintMaskObj.Hide(this);
	}

	// Token: 0x06002C56 RID: 11350 RVA: 0x00488CB4 File Offset: 0x00486EB4
	public void OnPointerDown(PointerEventData eventData)
	{
		if (!base.enabled || !base.gameObject.activeInHierarchy || (this.m_Button != null && !this.m_Button.IsInteractable()))
		{
			return;
		}
		if (this.m_eHint == EUIButtonHint.UIHIBtn || this.m_eHint == EUIButtonHint.UILeBtn)
		{
			this.SetFadeOutObject(this.m_eHint);
		}
		if (UIButtonHint.DelayFadeOutHint)
		{
			UIButtonHint.DelayFadeOutHint.ForceCloseHint();
		}
		if (GUIManager.Instance.HintMaskObj.HideBtn.m_Handler != null)
		{
			GUIManager.Instance.HintMaskObj.HideBtn.m_Handler.OnButtonClick(null);
		}
		if (this.GetCScrollRect() != null && this.GetCScrollRect().content != null)
		{
			this.PressPosition = this.GetCScrollRect().content.anchoredPosition;
		}
		else
		{
			this.PressPosition = base.transform.position;
		}
		this.BtnAction = UIButtonHint._BntAction.BtnDown;
		UIButtonHint.DelayFadeOutHint = this;
		GUIManager.Instance.HintMaskObj.Hide(this);
		this.IsValidClick = 1;
		if (this.FadeOutCanvas)
		{
			this.bFadeOut = false;
			this.FadeOutCanvas.alpha = 1f;
		}
		switch (this.m_eHint)
		{
		case EUIButtonHint.UIHIBtn:
		{
			UIHIBtn uihibtn = this.m_Button as UIHIBtn;
			if (!(uihibtn == null))
			{
				eHeroOrItem heroOrItem = (eHeroOrItem)uihibtn.HeroOrItem;
				if (heroOrItem != eHeroOrItem.Hero)
				{
					if (heroOrItem == eHeroOrItem.Item)
					{
						GUIManager.Instance.m_SimpleItemInfo.Show(this, uihibtn.HIID, -1, UIButtonHint.ePosition.Original, null);
					}
				}
				else
				{
					GUIManager.Instance.m_SimpleItemInfo.ShowHero(this, uihibtn.HIID, (ushort)uihibtn.m_BtnID1, (ushort)uihibtn.m_BtnID2);
				}
			}
			break;
		}
		case EUIButtonHint.DownUpHandler:
		case EUIButtonHint.Slider:
			if (this.m_DownUpHandler != null)
			{
				this.m_DownUpHandler.OnButtonDown(this);
			}
			break;
		case EUIButtonHint.CountDown:
			this.m_Time = 0f;
			this.bCountDown = true;
			break;
		case EUIButtonHint.UILeBtn:
			if (this.m_DownUpHandler != null)
			{
				this.m_DownUpHandler.OnButtonDown(this);
			}
			break;
		case EUIButtonHint.UIArena_Hint:
			if (this.m_DownUpHandler != null)
			{
				this.m_DownUpHandler.OnButtonDown(this);
			}
			break;
		}
		if (this.GetCScrollRect() != null)
		{
			this.GetCScrollRect().OnBeginDrag(eventData);
		}
		if (this.GetScrollRect() != null)
		{
			this.GetScrollRect().OnBeginDrag(eventData);
		}
	}

	// Token: 0x06002C57 RID: 11351 RVA: 0x00488F6C File Offset: 0x0048716C
	private CScrollRect GetCScrollRect()
	{
		if (this.ScrollID == 0)
		{
			return UIButtonHint.scrollRect;
		}
		return UIButtonHint.scrollRect2;
	}

	// Token: 0x06002C58 RID: 11352 RVA: 0x00488F84 File Offset: 0x00487184
	public ScrollRect GetScrollRect()
	{
		if (this.ScrollID == 0)
		{
			return UIButtonHint.m_scrollRect;
		}
		return UIButtonHint.m_scrollRect2;
	}

	// Token: 0x06002C59 RID: 11353 RVA: 0x00488F9C File Offset: 0x0048719C
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.BtnAction == UIButtonHint._BntAction.BtnNone)
		{
			return;
		}
		GUIManager.Instance.HintMaskObj.Show(this);
		GUIManager.Instance.HintMaskObj.HideBtn.m_Handler = this;
	}

	// Token: 0x06002C5A RID: 11354 RVA: 0x00488FD0 File Offset: 0x004871D0
	public void OnCloseHint()
	{
		GUIManager.Instance.HintMaskObj.HideBtn.m_Handler = null;
		if (this.FadeOutCanvas)
		{
			this.bFadeOut = true;
			this.FadeTime = 0f;
		}
		switch (this.m_eHint)
		{
		case EUIButtonHint.UIHIBtn:
		{
			UIHIBtn uihibtn = this.m_Button as UIHIBtn;
			if (!(uihibtn == null))
			{
				eHeroOrItem heroOrItem = (eHeroOrItem)uihibtn.HeroOrItem;
				if (heroOrItem == eHeroOrItem.Hero || heroOrItem == eHeroOrItem.Item)
				{
					this.BtnAction = UIButtonHint._BntAction.BtnUp;
				}
			}
			break;
		}
		case EUIButtonHint.DownUpHandler:
		case EUIButtonHint.UILeBtn:
		case EUIButtonHint.UIArena_Hint:
			this.BtnAction = UIButtonHint._BntAction.BtnUp;
			break;
		case EUIButtonHint.Slider:
			if (this.m_DownUpHandler != null)
			{
				this.m_DownUpHandler.OnButtonUp(this);
			}
			break;
		case EUIButtonHint.CountDown:
			this.m_Time = 0f;
			this.bCountDown = false;
			this.BtnAction = UIButtonHint._BntAction.BtnUp;
			break;
		}
	}

	// Token: 0x06002C5B RID: 11355 RVA: 0x004890CC File Offset: 0x004872CC
	public void OnPointerExit(PointerEventData eventData)
	{
	}

	// Token: 0x06002C5C RID: 11356 RVA: 0x004890D0 File Offset: 0x004872D0
	public void OnDrag(PointerEventData eventData)
	{
		if (this.IsValidClick == 0 && eventData.eligibleForClick)
		{
			eventData.eligibleForClick = false;
		}
		if (this.GetCScrollRect() != null)
		{
			this.GetCScrollRect().OnDrag(eventData);
		}
		if (this.GetScrollRect() != null)
		{
			this.GetScrollRect().OnDrag(eventData);
		}
	}

	// Token: 0x06002C5D RID: 11357 RVA: 0x00489134 File Offset: 0x00487334
	public void OnEndDrag(PointerEventData eventData)
	{
		if (this.GetCScrollRect() != null)
		{
			this.GetCScrollRect().OnEndDrag(eventData);
		}
		if (this.GetScrollRect() != null)
		{
			this.GetScrollRect().OnEndDrag(eventData);
		}
	}

	// Token: 0x06002C5E RID: 11358 RVA: 0x0048917C File Offset: 0x0048737C
	public void OnButtonClick(UIButton sender)
	{
		if (sender == null)
		{
			this.ForceCloseHint();
		}
		else
		{
			this.OnCloseHint();
		}
	}

	// Token: 0x06002C5F RID: 11359 RVA: 0x0048919C File Offset: 0x0048739C
	public void GetTipPosition(RectTransform tipRect, UIButtonHint.ePosition position = UIButtonHint.ePosition.Original, Vector3? upsetPoint = null)
	{
		RectTransform rectTransform = base.transform as RectTransform;
		if (rectTransform == null)
		{
			return;
		}
		Vector2 size = GUIManager.Instance.m_MessageBoxLayer.rect.size;
		tipRect.position = rectTransform.position;
		Vector3 vector = tipRect.anchoredPosition3D;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			size.x -= GUIManager.Instance.IPhoneX_DeltaX * 2f;
		}
		if (this.m_ForcePos)
		{
			if (this.m_HintPosHandler == null)
			{
				vector.x = this.m_HIBtnOffset.x;
				vector.y = this.m_HIBtnOffset.y;
				vector.z = 0f;
				tipRect.anchoredPosition3D = vector;
				tipRect.anchoredPosition = this.m_HIBtnOffset;
			}
			else
			{
				this.m_HintPosHandler.UpdatePos(rectTransform, tipRect);
			}
			return;
		}
		if (position == UIButtonHint.ePosition.Original)
		{
			vector.x += rectTransform.rect.x;
			vector.y += rectTransform.rect.y;
		}
		else
		{
			vector.x -= tipRect.rect.width;
			vector.y += rectTransform.rect.y - rectTransform.rect.height;
		}
		if (upsetPoint != null)
		{
			vector += upsetPoint.Value;
		}
		vector.z = 0f;
		if (vector.x + tipRect.sizeDelta.x > size.x)
		{
			vector.x = size.x - tipRect.sizeDelta.x;
		}
		if (vector.y + rectTransform.rect.height + tipRect.sizeDelta.y <= 0f)
		{
			vector.y += rectTransform.rect.height + tipRect.sizeDelta.y;
		}
		else if (-1f * vector.y + tipRect.sizeDelta.y > size.y)
		{
			vector.y = -1f * (size.y - tipRect.sizeDelta.y);
		}
		tipRect.anchoredPosition3D = vector;
	}

	// Token: 0x06002C60 RID: 11360 RVA: 0x00489434 File Offset: 0x00487634
	public void ForceCloseHint()
	{
		this.BtnAction = UIButtonHint._BntAction.BtnNone;
		this.bFadeOut = false;
		this.bCountDown = false;
		if (this.m_eHint == EUIButtonHint.UIHIBtn)
		{
			GUIManager.Instance.m_SimpleItemInfo.Hide(this);
		}
		if (this.m_DownUpHandler != null)
		{
			this.m_DownUpHandler.OnButtonUp(this);
		}
		UIButtonHint.DelayFadeOutHint = null;
		GUIManager.Instance.HintMaskObj.HideBtn.m_Handler = null;
	}

	// Token: 0x06002C61 RID: 11361 RVA: 0x004894A4 File Offset: 0x004876A4
	public void SetFadeOutObject(EUIButtonHint HintEnum)
	{
		if (HintEnum == EUIButtonHint.UIHIBtn)
		{
			this._ControlFadeOut = GUIManager.Instance.m_SimpleItemInfo.m_RectTransform.gameObject;
			this.FadeOutCanvas = GUIManager.Instance.m_SimpleItemInfo.Canvasgroup;
		}
		else if (HintEnum == EUIButtonHint.UILeBtn)
		{
			this._ControlFadeOut = GUIManager.Instance.m_LordInfo.m_RectTransform.gameObject;
			this.FadeOutCanvas = GUIManager.Instance.m_LordInfo.Canvasgroup;
		}
	}

	// Token: 0x06002C62 RID: 11362 RVA: 0x00489524 File Offset: 0x00487724
	private void Update()
	{
		if (!base.enabled)
		{
			return;
		}
		if (this.BtnAction == UIButtonHint._BntAction.BtnNone)
		{
			return;
		}
		if (this.GetCScrollRect() != null && this.GetCScrollRect().Get_Dragging())
		{
			if (this.GetCScrollRect().content != null)
			{
				if (Math.Abs(this.PressPosition.y - this.GetCScrollRect().content.anchoredPosition.y) > 20f)
				{
					this.IsValidClick = 0;
					this.ForceCloseHint();
				}
			}
			else if (Math.Abs(this.PressPosition.y - base.transform.position.y) > 20f)
			{
				this.IsValidClick = 0;
				this.ForceCloseHint();
			}
		}
		if (this.GetScrollRect() != null && Math.Abs(this.PressPosition.y - base.transform.position.y) > 20f)
		{
			this.IsValidClick = 0;
			this.ForceCloseHint();
		}
		if (this.BtnAction == UIButtonHint._BntAction.BtnUp)
		{
			if (!this.FadeOutCanvas)
			{
				if (this.m_DownUpHandler != null)
				{
					this.m_DownUpHandler.OnButtonUp(this);
				}
				this.BtnAction = UIButtonHint._BntAction.BtnNone;
				UIButtonHint.DelayFadeOutHint = null;
			}
			if (this.bFadeOut)
			{
				if (this.FadeTime < this.MaxFadeTime)
				{
					this.FadeOutCanvas.alpha = Mathf.Clamp(1f - this.FadeTime / this.MaxFadeTime, 0f, 1f);
					this.FadeTime += Time.unscaledDeltaTime;
				}
				else
				{
					this.bFadeOut = false;
					if (this.m_DownUpHandler != null)
					{
						this.m_DownUpHandler.OnButtonUp(this);
					}
					this.FadeOutCanvas.alpha = 1f;
					UIButtonHint.DelayFadeOutHint = null;
					this.BtnAction = UIButtonHint._BntAction.BtnNone;
					GUIManager.Instance.m_SimpleItemInfo.Hide(this);
					GUIManager.Instance.m_LordInfo.Hide(this);
					GUIManager.Instance.HintMaskObj.Hide(this);
				}
			}
		}
		if (this.m_eHint == EUIButtonHint.CountDown && this.bCountDown)
		{
			this.m_Time += Time.unscaledDeltaTime;
			if (this.m_Time >= this.DelayTime)
			{
				if (this.m_DownUpHandler != null)
				{
					this.m_DownUpHandler.OnButtonDown(this);
					GUIManager.Instance.HintMaskObj.Show(this);
					GUIManager.Instance.HintMaskObj.HideBtn.m_Handler = this;
				}
				this.bCountDown = false;
				this.m_Time = 0f;
			}
		}
	}

	// Token: 0x0400790D RID: 30989
	public Selectable m_Button;

	// Token: 0x0400790E RID: 30990
	public EUIButtonHint m_eHint;

	// Token: 0x0400790F RID: 30991
	public IUIButtonDownUpHandler m_DownUpHandler;

	// Token: 0x04007910 RID: 30992
	private MonoBehaviour _Handler;

	// Token: 0x04007911 RID: 30993
	public IUIUpdatePos m_HintPosHandler;

	// Token: 0x04007912 RID: 30994
	public bool m_ForcePos;

	// Token: 0x04007913 RID: 30995
	public Vector2 m_HIBtnOffset = Vector2.zero;

	// Token: 0x04007914 RID: 30996
	private GameObject _ControlFadeOut;

	// Token: 0x04007915 RID: 30997
	private CanvasGroup FadeOutCanvas;

	// Token: 0x04007916 RID: 30998
	private float FadeTime;

	// Token: 0x04007917 RID: 30999
	private float MaxFadeTime = 0.2f;

	// Token: 0x04007918 RID: 31000
	private bool bFadeOut;

	// Token: 0x04007919 RID: 31001
	public byte SkipDisabelEvent;

	// Token: 0x0400791A RID: 31002
	public bool bCountDown;

	// Token: 0x0400791B RID: 31003
	public float m_Time;

	// Token: 0x0400791C RID: 31004
	public float DelayTime = 0.7f;

	// Token: 0x0400791D RID: 31005
	public ushort Parm1;

	// Token: 0x0400791E RID: 31006
	public byte Parm2;

	// Token: 0x0400791F RID: 31007
	private byte IsValidClick;

	// Token: 0x04007920 RID: 31008
	private UIButtonHint._BntAction _BtnAction;

	// Token: 0x04007921 RID: 31009
	private Vector3 PressPosition;

	// Token: 0x04007922 RID: 31010
	public byte ScrollID;

	// Token: 0x04007923 RID: 31011
	public static CScrollRect scrollRect;

	// Token: 0x04007924 RID: 31012
	public static CScrollRect scrollRect2;

	// Token: 0x04007925 RID: 31013
	public static ScrollRect m_scrollRect;

	// Token: 0x04007926 RID: 31014
	public static ScrollRect m_scrollRect2;

	// Token: 0x04007927 RID: 31015
	private static UIButtonHint DelayFadeOutHint;

	// Token: 0x02000868 RID: 2152
	private enum _BntAction
	{
		// Token: 0x04007929 RID: 31017
		BtnNone,
		// Token: 0x0400792A RID: 31018
		BtnDown,
		// Token: 0x0400792B RID: 31019
		BtnUp
	}

	// Token: 0x02000869 RID: 2153
	public enum ePosition
	{
		// Token: 0x0400792D RID: 31021
		Original,
		// Token: 0x0400792E RID: 31022
		LeftSide
	}
}
