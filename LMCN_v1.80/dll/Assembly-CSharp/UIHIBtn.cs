using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200087B RID: 2171
public class UIHIBtn : Selectable, IPointerUpHandler, IDragHandler, IPointerDownHandler, IPointerClickHandler, IEndDragHandler, IPointerExitHandler, IEventSystemHandler, IUIButtonScaleHandler2
{
	// Token: 0x1700016D RID: 365
	// (get) Token: 0x06002D09 RID: 11529 RVA: 0x0048E3D0 File Offset: 0x0048C5D0
	// (set) Token: 0x06002D0A RID: 11530 RVA: 0x0048E3D8 File Offset: 0x0048C5D8
	public UIText PetRareText
	{
		get
		{
			return this._PetRareText;
		}
		set
		{
			this._PetRareText = value;
		}
	}

	// Token: 0x06002D0B RID: 11531 RVA: 0x0048E3E4 File Offset: 0x0048C5E4
	public void SetPetRare(byte rare)
	{
		this._PetRareStr.ClearString();
		this._PetRareStr.IntToFormat((long)rare, 1, false);
		this._PetRareStr.AppendFormat("{0}");
		this._PetRareText.text = this._PetRareStr.ToString();
		this._PetRareText.SetAllDirty();
		this._PetRareText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x1700016E RID: 366
	// (get) Token: 0x06002D0C RID: 11532 RVA: 0x0048E450 File Offset: 0x0048C650
	// (set) Token: 0x06002D0D RID: 11533 RVA: 0x0048E458 File Offset: 0x0048C658
	private bool isPointerDown { get; set; }

	// Token: 0x06002D0E RID: 11534 RVA: 0x0048E464 File Offset: 0x0048C664
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this.m_EffectType != e_EffectType.e_Normal)
		{
			return;
		}
		this.ClickFunc();
	}

	// Token: 0x06002D0F RID: 11535 RVA: 0x0048E478 File Offset: 0x0048C678
	public override void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);
		if (this.IsActive() && this.IsInteractable())
		{
			this.isPointerDown = false;
			if (this.m_UpDownHandler != null)
			{
				this.m_UpDownHandler.OnHIButtonUp(this);
			}
		}
	}

	// Token: 0x06002D10 RID: 11536 RVA: 0x0048E4C0 File Offset: 0x0048C6C0
	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);
		if (this.IsActive() && this.IsInteractable())
		{
			if ((this.SoundIndex & 64) == 0 && this.IsActive() && this.IsInteractable())
			{
				AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex)this.SoundIndex);
			}
			this.isPointerDown = true;
			if (this.m_UpDownHandler != null)
			{
				this.m_UpDownHandler.OnHIButtonDown(this);
			}
		}
	}

	// Token: 0x06002D11 RID: 11537 RVA: 0x0048E53C File Offset: 0x0048C73C
	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		if (this.isPointerDown && this.m_DHandler != null)
		{
			this.m_DHandler.OnHIButtonDragExit(this);
		}
	}

	// Token: 0x06002D12 RID: 11538 RVA: 0x0048E568 File Offset: 0x0048C768
	public void OnEndDrag(PointerEventData eventData)
	{
		if (this.m_DHandler != null)
		{
			this.m_DHandler.OnHIButtonDragEnd(this);
		}
	}

	// Token: 0x06002D13 RID: 11539 RVA: 0x0048E584 File Offset: 0x0048C784
	public void OnDrag(PointerEventData eventData)
	{
		if (this.isPointerDown && this.m_DHandler != null)
		{
			this.m_DHandler.OnHIButtonDrag(this);
		}
	}

	// Token: 0x06002D14 RID: 11540 RVA: 0x0048E5B4 File Offset: 0x0048C7B4
	public void Refresh_FontTexture()
	{
		if (this.LvOrNum != null && this.LvOrNum.enabled)
		{
			this.LvOrNum.enabled = false;
			this.LvOrNum.enabled = true;
		}
		if (this._PetRareText != null && this._PetRareText.enabled)
		{
			this._PetRareText.enabled = false;
			this._PetRareText.enabled = true;
		}
	}

	// Token: 0x06002D15 RID: 11541 RVA: 0x0048E634 File Offset: 0x0048C834
	private void ClickFunc()
	{
		if (this.IsActive() && this.IsInteractable() && this.m_Handler != null)
		{
			if ((this.SoundIndex & 64) > 0)
			{
				int enumSoundIndex = (int)this.SoundIndex & -65;
				AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex)enumSoundIndex);
			}
			this.m_Handler.OnHIButtonClick(this);
		}
	}

	// Token: 0x06002D16 RID: 11542 RVA: 0x0048E694 File Offset: 0x0048C894
	public void SetEffectType(e_EffectType EffectType)
	{
		this.m_EffectType = EffectType;
	}

	// Token: 0x06002D17 RID: 11543 RVA: 0x0048E6A0 File Offset: 0x0048C8A0
	public void OnFinish()
	{
		this.ClickFunc();
	}

	// Token: 0x0400799C RID: 31132
	public IUIHIBtnClickHandler m_Handler;

	// Token: 0x0400799D RID: 31133
	public IUIHIBtnUpDownHandler m_UpDownHandler;

	// Token: 0x0400799E RID: 31134
	public IUIHIBtnDrag m_DHandler;

	// Token: 0x0400799F RID: 31135
	public int m_BtnID1;

	// Token: 0x040079A0 RID: 31136
	public int m_BtnID2;

	// Token: 0x040079A1 RID: 31137
	public int m_BtnID3;

	// Token: 0x040079A2 RID: 31138
	public int m_BtnID4;

	// Token: 0x040079A3 RID: 31139
	public byte HeroOrItem;

	// Token: 0x040079A4 RID: 31140
	public ushort HIID;

	// Token: 0x040079A5 RID: 31141
	public Image HIImage;

	// Token: 0x040079A6 RID: 31142
	public Image ChipBookImage;

	// Token: 0x040079A7 RID: 31143
	public Image CircleImage;

	// Token: 0x040079A8 RID: 31144
	public Image HeroRankImage;

	// Token: 0x040079A9 RID: 31145
	public Image TextImage;

	// Token: 0x040079AA RID: 31146
	public UIText LvOrNum;

	// Token: 0x040079AB RID: 31147
	private UIText _PetRareText;

	// Token: 0x040079AC RID: 31148
	private CString _PetRareStr = new CString(4);

	// Token: 0x040079AD RID: 31149
	private e_EffectType m_EffectType;

	// Token: 0x040079AE RID: 31150
	public byte SoundIndex;
}
