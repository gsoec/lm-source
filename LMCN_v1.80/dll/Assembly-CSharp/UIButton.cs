using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using uTools;

// Token: 0x02000863 RID: 2147
public class UIButton : Selectable, IPointerDownHandler, IPointerClickHandler, IEventSystemHandler, IUIButtonScaleHandler2
{
	// Token: 0x06002C40 RID: 11328 RVA: 0x004888BC File Offset: 0x00486ABC
	protected override void Start()
	{
		if (this.m_EffectType == e_EffectType.e_Scale)
		{
			this.AddScaleComp();
		}
	}

	// Token: 0x06002C41 RID: 11329 RVA: 0x004888D0 File Offset: 0x00486AD0
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this.m_EffectType == e_EffectType.e_Normal)
		{
			this.ClickFunc();
		}
	}

	// Token: 0x06002C42 RID: 11330 RVA: 0x004888E4 File Offset: 0x00486AE4
	public void SetButtonEffectType(e_EffectType type)
	{
		if (type == this.m_EffectType)
		{
			return;
		}
		if (type == e_EffectType.e_Scale)
		{
			this.AddScaleComp();
		}
		this.m_EffectType = type;
	}

	// Token: 0x06002C43 RID: 11331 RVA: 0x00488908 File Offset: 0x00486B08
	private void AddScaleComp()
	{
		uButtonScale uButtonScale = base.gameObject.GetComponent<uButtonScale>();
		if (uButtonScale == null)
		{
			uButtonScale = base.gameObject.AddComponent<uButtonScale>();
		}
		uButtonScale.m_Handler = this;
	}

	// Token: 0x06002C44 RID: 11332 RVA: 0x00488940 File Offset: 0x00486B40
	protected override void OnDisable()
	{
		base.OnDisable();
		uButtonScale component = base.gameObject.GetComponent<uButtonScale>();
		if (component != null)
		{
			component.Reset();
		}
	}

	// Token: 0x06002C45 RID: 11333 RVA: 0x00488974 File Offset: 0x00486B74
	public void ForTextChange(e_BtnType btnType)
	{
		if (btnType != this.m_BtnType)
		{
			this.m_BtnType = btnType;
			if (btnType == e_BtnType.e_ChangeText)
			{
				ColorBlock colors = base.colors;
				colors.normalColor = new Color(0.675f, 0.675f, 0.675f);
				colors.highlightedColor = new Color(0.675f, 0.675f, 0.675f);
				base.colors = colors;
				if (this.m_Text != null)
				{
					this.NormalColor = this.m_Text.color;
					this.m_Text.color = this.ChangeColor;
				}
			}
			else
			{
				ColorBlock colors = base.colors;
				colors.normalColor = Color.white;
				colors.highlightedColor = Color.white;
				base.colors = colors;
				if (this.m_Text != null)
				{
					this.m_Text.color = this.NormalColor;
				}
			}
		}
	}

	// Token: 0x06002C46 RID: 11334 RVA: 0x00488A60 File Offset: 0x00486C60
	private void ClickFunc()
	{
		if (this.IsActive() && this.IsInteractable())
		{
			if ((this.SoundIndex & 64) == 0)
			{
				AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex)this.SoundIndex);
			}
			else if ((this.SoundIndex & 64) > 0)
			{
				int enumSoundIndex = (int)this.SoundIndex & -65;
				AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex)enumSoundIndex);
			}
			if (this.m_Handler != null)
			{
				this.m_Handler.OnButtonClick(this);
			}
		}
	}

	// Token: 0x06002C47 RID: 11335 RVA: 0x00488AE4 File Offset: 0x00486CE4
	public void OnFinish()
	{
		this.ClickFunc();
	}

	// Token: 0x040078F9 RID: 30969
	public IUIButtonClickHandler m_Handler;

	// Token: 0x040078FA RID: 30970
	public int m_BtnID1;

	// Token: 0x040078FB RID: 30971
	public int m_BtnID2;

	// Token: 0x040078FC RID: 30972
	public int m_BtnID3;

	// Token: 0x040078FD RID: 30973
	public int m_BtnID4;

	// Token: 0x040078FE RID: 30974
	public e_BtnType m_BtnType;

	// Token: 0x040078FF RID: 30975
	public Color NormalColor;

	// Token: 0x04007900 RID: 30976
	public Color ChangeColor = new Color(0.898f, 0f, 0.3098f);

	// Token: 0x04007901 RID: 30977
	public UIText m_Text;

	// Token: 0x04007902 RID: 30978
	public e_EffectType m_EffectType;

	// Token: 0x04007903 RID: 30979
	public byte SoundIndex;

	// Token: 0x04007904 RID: 30980
	public int m_Tag1;

	// Token: 0x04007905 RID: 30981
	public int m_Tag2;
}
