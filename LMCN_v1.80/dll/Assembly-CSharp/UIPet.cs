using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000457 RID: 1111
public class UIPet : GUIWindow, UILoadImageHander, IUIButtonClickHandler, IUIButtonDownUpHandler, IUTimeBarOnTimer
{
	// Token: 0x06001631 RID: 5681 RVA: 0x002615F0 File Offset: 0x0025F7F0
	public UIPet()
	{
		float[] array = new float[5];
		array[1] = 1f;
		array[2] = 1f;
		this.IconMove_AlphaValue = array;
		this.IconMove_AlphaKey = new float[]
		{
			0f,
			0.166666672f,
			0.266666681f,
			0.433333337f,
			1f
		};
		this.IconBlock_ScaleValue = new Vector2[]
		{
			new Vector2(1f, 1f),
			new Vector2(1.05f, 1.05f),
			new Vector2(1.1f, 1.1f),
			new Vector2(1.05f, 1.05f),
			new Vector2(1.15f, 1.15f),
			new Vector2(1f, 1f)
		};
		this.IconBlock_ScaleKey = new float[]
		{
			0f,
			0.13333334f,
			0.166666672f,
			0.433333337f,
			0.6666667f,
			1f
		};
		float[] array2 = new float[5];
		array2[1] = 1f;
		array2[2] = 1f;
		this.IconBlock_AlphaValue = array2;
		this.IconBlock_AlphaKey = new float[]
		{
			0f,
			0.166666672f,
			0.433333337f,
			0.6666667f,
			1f
		};
		float[] array3 = new float[3];
		array3[1] = 1f;
		this.BarBlockImageAlphaValue = array3;
		this.BarBlockImageAlphaKey = new float[]
		{
			0.366666675f,
			0.433333337f,
			0.966666639f
		};
		this.BarBlockImageScaleValue_Up = new Vector2[]
		{
			new Vector2(1f, 1f),
			new Vector2(1.02f, 1.25f),
			new Vector2(1f, 1f)
		};
		this.BarBlockImageScaleKey_Up = new float[]
		{
			0.533333361f,
			0.6f,
			0.7f
		};
		float[] array4 = new float[5];
		array4[2] = 1f;
		array4[3] = 0.8f;
		this.BarBlockImageAlphaValue_Up = array4;
		this.BarBlockImageAlphaKey_Up = new float[]
		{
			0f,
			0.366666675f,
			0.433333337f,
			0.766666651f,
			0.933333337f
		};
		this.BarInnerImageScaleValue = new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2(1f, 1f)
		};
		this.BarInnerImageScaleKey = new float[]
		{
			0.533333361f,
			0.6f
		};
		float[] array5 = new float[3];
		array5[1] = 1f;
		this.BarInnerImageAlphaValue = array5;
		this.BarInnerImageAlphaKey = new float[]
		{
			0.533333361f,
			0.6f,
			0.966666639f
		};
		this.ExpText_OriginalPos = Vector2.zero;
		this.ExpText_PositionValue = new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2(0f, 66f)
		};
		this.ExpText_PositionKey = new float[]
		{
			0.1f,
			0.4f
		};
		this.ExpText_ScaleValue = new Vector2[]
		{
			new Vector2(0.8f, 0.8f),
			new Vector2(1f, 1f)
		};
		this.ExpText_ScaleKey = new float[]
		{
			0.266666681f,
			0.4f
		};
		float[] array6 = new float[4];
		array6[1] = 1f;
		array6[2] = 1f;
		this.ExpText_AlphaValue = array6;
		this.ExpText_AlphaKey = new float[]
		{
			0.2f,
			0.266666681f,
			0.966666639f,
			1.06666672f
		};
		this.ExpBarFA_ScaleKey = new float[]
		{
			0.366666675f,
			0.533333361f
		};
		this.ExpTextX2_PositionValue = new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2(0f, 66f)
		};
		this.ExpTextX2_PositionKey = new float[]
		{
			0.366666675f,
			0.6666667f
		};
		this.ExpTextX2_ScaleValue = new Vector2[]
		{
			new Vector2(0.6f, 0.6f),
			new Vector2(1f, 1f)
		};
		this.ExpTextX2_ScaleKey = new float[]
		{
			0.333333343f,
			0.566666663f
		};
		float[] array7 = new float[4];
		array7[1] = 1f;
		array7[2] = 1f;
		this.ExpTextX2_AlphaValue = array7;
		this.ExpTextX2_AlphaKey = new float[]
		{
			0.36f,
			0.53f,
			1.6f,
			1.83f
		};
		this.X2Text_ScaleValue = new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2(0.6666667f, 0.6666667f),
			new Vector2(1.2f, 1.2f)
		};
		this.X2Text_ScaleKey = new float[]
		{
			0.333333343f,
			0.4f,
			0.6666667f
		};
		float[] array8 = new float[4];
		array8[1] = 1f;
		array8[2] = 1f;
		this.X2Text_AlphaValue = array8;
		this.X2Text_AlphaKey = new float[]
		{
			0.33f,
			0.4f,
			1.56f,
			1.63f
		};
		this.ExpBar_ScaleValue = new Vector2[]
		{
			new Vector2(1f, 1f),
			new Vector2(1.1f, 1.5f),
			new Vector2(1.3f, 2.5f),
			new Vector2(1f, 1f),
			new Vector2(1f, 1f),
			new Vector2(1f, 1f),
			new Vector2(1f, 1f)
		};
		this.ExpBar_ScaleKey = new float[]
		{
			0.53f,
			0.66f,
			0.76f,
			0.83f,
			0.9f,
			0.96f,
			1.03f
		};
		this.ExpBarText_ScaleValue = new Vector2[]
		{
			new Vector2(1f, 1f),
			new Vector2(2f, 2f),
			new Vector2(3f, 4.7f),
			new Vector2(2f, 2f),
			new Vector2(1f, 1f)
		};
		this.ExpBarText_ScaleKey = new float[]
		{
			0.53f,
			0.66f,
			0.76f,
			0.86f,
			0.96f
		};
		this.ExpBarText_AlphaValue = new float[]
		{
			1f,
			1f
		};
		this.ExpBarText_AlphaKey = new float[]
		{
			0.53f,
			0.66f
		};
		this.BarBlockImageX2ScaleValue = new Vector2[]
		{
			new Vector2(0f, 0f),
			new Vector2(1.1f, 2f),
			new Vector2(1.45f, 3f),
			new Vector2(1.05f, 1.1f),
			new Vector2(1.05f, 1.5f),
			new Vector2(1.1f, 1f),
			new Vector2(1f, 1f)
		};
		this.BarBlockImageX2ScaleKey = new float[]
		{
			0.53f,
			0.66f,
			0.76f,
			0.83f,
			0.9f,
			0.96f,
			1.03f
		};
		float[] array9 = new float[3];
		array9[1] = 1f;
		this.BarBlockImageX2AlphaValue = array9;
		this.BarBlockImageX2AlphaKey = new float[]
		{
			0.53f,
			0.66f,
			1.03f
		};
		this.BarInnerImageX2ScaleValue = new Vector2[]
		{
			new Vector2(1f, 1f),
			new Vector2(1.1f, 1.5f),
			new Vector2(1.3f, 2.5f),
			new Vector2(1f, 1f),
			new Vector2(1f, 1f),
			new Vector2(1f, 1f),
			new Vector2(1f, 1f)
		};
		this.BarInnerImageX2ScaleKey = new float[]
		{
			0.53f,
			0.66f,
			0.76f,
			0.83f,
			0.9f,
			0.96f,
			1.03f
		};
		float[] array10 = new float[3];
		array10[1] = 0.5f;
		this.BarInnerImageX2AlphaValue = array10;
		this.BarInnerImageX2AlphaKey = new float[]
		{
			0.53f,
			0.66f,
			1.03f
		};
		this.X2LockImage_AlphaValue = new float[]
		{
			1f,
			0f,
			0f,
			1f
		};
		this.X2LockImage_AlphaKey = new float[]
		{
			0.33f,
			0.4f,
			1.36f,
			1.6f
		};
		this.NowEvoID = -1;
		this.EmijiShowTime1 = 0.1f;
		this.EmijiShowTime2 = 0.08f;
		this.EmojiShowMaxScale = 1.15f;
		this.EmijiShowCountTime = -1f;
		this.ParticleID = new ushort[]
		{
			441,
			442,
			443
		};
		this.ClickAddSkillTime = -1f;
		this.MaxTextColor = new Color32(byte.MaxValue, 247, 153, byte.MaxValue);
		base();
	}

	// Token: 0x170000A2 RID: 162
	// (get) Token: 0x06001632 RID: 5682 RVA: 0x002621B0 File Offset: 0x002603B0
	public Door door
	{
		get
		{
			if (this.m_door == null)
			{
				this.m_door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
			}
			return this.m_door;
		}
	}

	// Token: 0x06001633 RID: 5683 RVA: 0x002621E0 File Offset: 0x002603E0
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.PM = PetManager.Instance;
		this.m_transform = base.transform;
		Font ttffont = this.GM.GetTTFFont();
		if (arg1 == 1)
		{
			this.bMaxShow = true;
		}
		this.LightRC = this.m_transform.GetChild(12).GetComponent<RectTransform>();
		this.myLight1 = this.m_transform.GetChild(12).GetChild(0).GetComponent<Light>();
		this.myLight2 = this.m_transform.GetChild(12).GetChild(1).GetComponent<Light>();
		this.myLight3 = this.m_transform.GetChild(12).GetChild(2).GetComponent<Light>();
		this.HinString = StringManager.Instance.SpawnString(1024);
		this.m_transform.GetChild(0).GetChild(4).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(1).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(2).GetChild(3).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(4).GetChild(11).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(6).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(8).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(9).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(7).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(13).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(14).GetComponent<UIButton>().m_Handler = this;
		if (this.GM.IsArabic)
		{
			this.m_transform.GetChild(6).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.m_transform.GetChild(7).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(7).GetChild(0).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(7).GetComponent<CustomImage>().enabled = false;
		}
		UIButtonHint uibuttonHint = this.m_transform.GetChild(0).GetChild(1).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 16047;
		uibuttonHint.Parm2 = 6;
		this.PetPosRT = this.m_transform.GetChild(10).GetComponent<RectTransform>();
		this.btn_PetActionD = this.m_transform.GetChild(1).gameObject.AddComponent<UIBtnDrag>();
		this.btn_PetActionD.mHero = this.PetPosRT;
		this.PetPosRT.anchoredPosition3D = new Vector3(-239f, -200f, 100f);
		this.LightRC.anchoredPosition3D = new Vector3(0f, 0f, 300f);
		this.BloodBtnT = this.m_transform.GetChild(0).GetChild(4);
		this.BloodSP = this.m_transform.GetChild(0).GetChild(4).GetComponent<UISpritesArray>();
		this.StoneT = this.m_transform.GetChild(2);
		this.MaxShowT = this.m_transform.GetChild(3);
		this.RankT = this.m_transform.GetChild(4).GetChild(11);
		this.RankText2 = this.m_transform.GetChild(4).GetChild(11).GetChild(0).GetComponent<UIText>();
		this.RankText2.font = ttffont;
		this.RankText2.text = this.DM.mStringTable.GetStringByID(7475u);
		this.TimeBarBackT = this.m_transform.GetChild(4).GetChild(12);
		this.Left_T = this.m_transform.GetChild(8);
		this.Right_T = this.m_transform.GetChild(9);
		this.LeftPosX = this.Left_T.localPosition.x + 20f;
		this.RightPosX = this.Right_T.localPosition.x - 20f;
		this.MoveX = 0f;
		this.CheckShowLRBtn();
		this.PanelRLightT = this.m_transform.GetChild(4).GetChild(1);
		this.PanelBlockT = this.m_transform.GetChild(4).GetChild(2);
		this.PetIcon = this.m_transform.GetChild(4).GetChild(3);
		this.GM.InitianHeroItemImg(this.PetIcon, eHeroOrItem.Pet, 1, 0, 0, 0, false, true, true, false);
		uibuttonHint = this.m_transform.GetChild(4).GetChild(4).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm2 = 8;
		this.PetStateImage = this.m_transform.GetChild(4).GetChild(5);
		uibuttonHint = this.PetStateImage.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 16065;
		this.StoneIcon = this.m_transform.GetChild(2).GetChild(1);
		this.GM.InitianHeroItemImg(this.StoneIcon, eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
		this.PetNameText = this.m_transform.GetChild(0).GetChild(2).GetComponent<UIText>();
		this.PetNameText.font = ttffont;
		this.PetNameText.fontSize = 24;
		this.PetNameText.resizeTextMaxSize = 24;
		this.ExpText = this.m_transform.GetChild(0).GetChild(3).GetChild(1).GetComponent<UIText>();
		this.ExpText.font = ttffont;
		this.ExpStr = StringManager.Instance.SpawnString(30);
		this.StoneText = this.m_transform.GetChild(2).GetChild(2).GetComponent<UIText>();
		this.StoneText.font = ttffont;
		this.StoneStr = StringManager.Instance.SpawnString(30);
		this.MaxShowBack = this.m_transform.GetChild(3).GetComponent<Image>();
		this.MaxShowText = this.m_transform.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.MaxShowText.font = ttffont;
		this.MaxShowText.text = this.DM.mStringTable.GetStringByID(10046u);
		this.LevelText_L = this.m_transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.LevelText_L.font = ttffont;
		this.LevelStr_L = StringManager.Instance.SpawnString(30);
		this.RareText = this.m_transform.GetChild(4).GetChild(6).GetChild(0).GetComponent<UIText>();
		this.RareText.font = ttffont;
		this.RareStr = StringManager.Instance.SpawnString(30);
		uibuttonHint = this.m_transform.GetChild(4).GetChild(6).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 16080;
		uibuttonHint.Parm2 = 5;
		this.LevelText = this.m_transform.GetChild(4).GetChild(8).GetComponent<UIText>();
		this.LevelText.font = ttffont;
		this.LevelStr = StringManager.Instance.SpawnString(30);
		this.RankText = this.m_transform.GetChild(4).GetChild(7).GetComponent<UIText>();
		this.RankText.font = ttffont;
		this.RankStr = StringManager.Instance.SpawnString(30);
		this.UpText = this.m_transform.GetChild(4).GetChild(10).GetComponent<UIText>();
		this.UpText.font = ttffont;
		this.UpStr = StringManager.Instance.SpawnString(30);
		this.PanelTitleText1 = this.m_transform.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.PanelTitleText1.font = ttffont;
		this.PanelTitleText1.text = this.DM.mStringTable.GetStringByID(370u);
		this.PanelTitleText2 = this.m_transform.GetChild(5).GetChild(5).GetComponent<UIText>();
		this.PanelTitleText2.font = ttffont;
		this.PanelTitleText2.text = this.DM.mStringTable.GetStringByID(16060u);
		for (int i = 0; i < 3; i++)
		{
			this.SkillT[i] = this.m_transform.GetChild(5).GetChild(i + 2);
			this.SkillNameText[i] = this.SkillT[i].GetChild(1).GetComponent<UIText>();
			this.SkillNameText[i].font = ttffont;
			this.SkillNameStr[i] = StringManager.Instance.SpawnString(30);
			this.SkillExpText[i] = this.SkillT[i].GetChild(3).GetComponent<UIText>();
			this.SkillExpText[i].font = ttffont;
			this.SkillExpStr[i] = StringManager.Instance.SpawnString(30);
			this.SkillLockGO[i] = this.SkillT[i].GetChild(6).gameObject;
			this.SkillLockText[i] = this.SkillLockGO[i].transform.GetChild(0).GetComponent<UIText>();
			this.SkillLockText[i].font = ttffont;
			this.SkillExpImageT[i] = this.SkillT[i].GetChild(2);
			this.SkillExpImage[i] = this.SkillT[i].GetChild(2).GetChild(0).GetComponent<Image>();
			this.SkillExpImageSP[i] = this.SkillT[i].GetChild(2).GetChild(0).GetComponent<UISpritesArray>();
			this.SkillImage1[i] = this.SkillT[i].GetChild(0).GetComponent<Image>();
			this.SkillPicHint[i] = this.SkillT[i].GetChild(0).gameObject.AddComponent<UIButtonHint>();
			this.SkillPicHint[i].m_eHint = EUIButtonHint.DownUpHandler;
			this.SkillPicHint[i].m_Handler = this;
			this.SkillPicHint[i].Parm2 = 3;
			this.SkillImage2[i] = this.SkillT[i].GetChild(0).GetChild(0).GetComponent<Image>();
			this.SkillImage2[i].sprite = this.GM.LoadFrameSprite("sk");
			this.SkillImage2[i].material = this.GM.GetFrameMaterial();
			this.SkillImage2SP[i] = this.SkillT[i].GetChild(0).GetChild(0).GetComponent<UISpritesArray>();
			this.SkillBtnT[i] = this.SkillT[i].GetChild(5);
			this.SkillBtnAlertT[i] = this.SkillT[i].GetChild(5).GetChild(0);
			this.SkillBtn[i] = this.SkillT[i].GetChild(5).GetComponent<UIButton>();
			this.SkillBtn[i].m_Handler = this;
			this.SkillkindImage[i] = this.SkillT[i].GetChild(4).GetComponent<Image>();
			this.SkillkindSP[i] = this.SkillT[i].GetChild(4).GetComponent<UISpritesArray>();
			this.SkillKindHint[i] = this.SkillT[i].GetChild(4).gameObject.AddComponent<UIButtonHint>();
			this.SkillKindHint[i].m_eHint = EUIButtonHint.DownUpHandler;
			this.SkillKindHint[i].m_Handler = this;
			this.SkillKindHint[i].Parm2 = 7;
		}
		this.ExpImage = this.m_transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Image>();
		this.ExpSP = this.m_transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<UISpritesArray>();
		this.TimeBarEffectT = this.m_transform.GetChild(4).GetChild(13);
		((RectTransform)this.TimeBarEffectT).anchoredPosition = new Vector2(-1.6f, -34.7f);
		this.TimeBar = this.m_transform.GetChild(4).GetChild(14).GetComponent<UITimeBar>();
		this.TimeBar.m_Handler = this;
		((RectTransform)this.TimeBar.transform).sizeDelta = new Vector2(261.8f, 29f);
		this.GM.CreateTimerBar(this.TimeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
		this.EmojiRC = (RectTransform)this.m_transform.GetChild(11);
		this.EmojiBack = this.GM.pullEmojiIcon(ushort.MaxValue, 0, false);
		this.EmojiBack.EmojiTransform.SetParent(this.EmojiRC, false);
		if (!this.bMaxShow)
		{
			this.ASExp_PanelT = this.m_transform.GetChild(13);
			if (this.GM.bOpenOnIPhoneX)
			{
				((RectTransform)this.ASExp_PanelT).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0f);
				((RectTransform)this.ASExp_PanelT).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0f);
			}
			this.ASExp_PanelT.GetChild(24).GetComponent<UIButton>().m_Handler = this;
			this.ASExp_PanelT.GetChild(24).GetComponent<CustomImage>().hander = this;
			this.ASExp_TitleText = this.ASExp_PanelT.GetChild(2).GetComponent<UIText>();
			this.ASExp_TitleText.font = ttffont;
			this.ASExp_TitleText.text = this.DM.mStringTable.GetStringByID(12121u);
			this.ASExp_PanelT.GetChild(24).GetComponent<UIButton>().m_Handler = this;
			this.ASExp_PanelT.GetChild(25).GetComponent<UIButton>().m_Handler = this;
			this.ASExp_PanelT.GetChild(26).GetComponent<UIButton>().m_Handler = this;
			this.ASExp_PanelT.GetChild(31).GetComponent<UIButton>().m_Handler = this;
			this.ASExp_PanelT.GetChild(37).GetComponent<UIButton>().m_Handler = this;
			this.ASExp_AddBtn1 = this.ASExp_PanelT.GetChild(28).GetComponent<UIButton>();
			this.ASExp_AddBtn1.m_Handler = this;
			this.ASExp_AddBtn1.transition = Selectable.Transition.ColorTint;
			this.ASExp_AddBtn2 = this.ASExp_PanelT.GetChild(27).GetComponent<UIButton>();
			this.ASExp_AddBtn2.m_Handler = this;
			this.ASExp_AddBtn2.transition = Selectable.Transition.ColorTint;
			if (this.GM.IsArabic)
			{
				this.ASExp_PanelT.GetChild(25).gameObject.AddComponent<ArabicItemTextureRot>();
			}
			this.ASExp_SkillMaxHint = this.ASExp_PanelT.GetChild(26).gameObject.AddComponent<UIButtonHint>();
			this.ASExp_SkillMaxHint.m_eHint = EUIButtonHint.DownUpHandler;
			this.ASExp_SkillMaxHint.m_Handler = this;
			this.ASExp_SkillMaxHint.Parm2 = 4;
			this.ASExp_SrcHint = this.ASExp_PanelT.GetChild(31).gameObject.AddComponent<UIButtonHint>();
			this.ASExp_SrcHint.m_eHint = EUIButtonHint.DownUpHandler;
			this.ASExp_SrcHint.m_Handler = this;
			this.ASExp_SrcHint.Parm2 = 4;
			this.ASExp_SkillImage1 = this.ASExp_PanelT.GetChild(26).GetChild(0).GetComponent<Image>();
			this.ASExp_SkillImage2 = this.ASExp_PanelT.GetChild(26).GetChild(0).GetChild(0).GetComponent<Image>();
			this.ASExp_SkillImage2.sprite = this.GM.LoadFrameSprite("sk");
			this.ASExp_SkillImage2.material = this.GM.GetFrameMaterial();
			this.ASExp_InfoNowTitletext = this.ASExp_PanelT.GetChild(4).GetComponent<UIText>();
			this.ASExp_InfoNowTitletext.font = ttffont;
			this.ASExp_InfoNowTitletext.text = this.DM.mStringTable.GetStringByID(12122u);
			this.ASExp_InfoNowtext = this.ASExp_PanelT.GetChild(5).GetComponent<UIText>();
			this.ASExp_InfoNowtext.font = ttffont;
			this.ASExp_InfoNowStr = StringManager.Instance.SpawnString(800);
			this.ASExp_InfoNowCDImage = this.ASExp_PanelT.GetChild(6).GetComponent<Image>();
			uibuttonHint = this.ASExp_InfoNowCDImage.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 12561;
			this.ASExp_InfoNowCDtext = this.ASExp_PanelT.GetChild(7).GetComponent<UIText>();
			this.ASExp_InfoNowCDtext.font = ttffont;
			this.ASExp_InfoNowCDStr = StringManager.Instance.SpawnString(30);
			uibuttonHint = this.ASExp_InfoNowCDtext.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 12561;
			this.ASExp_InfoNextTitleText = this.ASExp_PanelT.GetChild(8).GetComponent<UIText>();
			this.ASExp_InfoNextTitleText.font = ttffont;
			this.ASExp_InfoNextTitleText.text = this.DM.mStringTable.GetStringByID(12123u);
			this.ASExp_InfoNextText = this.ASExp_PanelT.GetChild(9).GetComponent<UIText>();
			this.ASExp_InfoNextText.font = ttffont;
			this.ASExp_InfoNextStr = StringManager.Instance.SpawnString(800);
			this.ASExp_InfoNextCDImage = this.ASExp_PanelT.GetChild(10).GetComponent<Image>();
			uibuttonHint = this.ASExp_InfoNextCDImage.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 12561;
			this.ASExp_InfoNextCDText = this.ASExp_PanelT.GetChild(11).GetComponent<UIText>();
			this.ASExp_InfoNextCDText.font = ttffont;
			this.ASExp_InfoNextCDStr = StringManager.Instance.SpawnString(30);
			uibuttonHint = this.ASExp_InfoNextCDText.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 12561;
			this.ASExp_MaxImageT = this.ASExp_PanelT.GetChild(12);
			this.ASExp_MaxRImageT = this.ASExp_PanelT.GetChild(12).GetChild(0);
			this.ASExp_MaxText = this.ASExp_PanelT.GetChild(12).GetChild(2).GetComponent<UIText>();
			this.ASExp_MaxText.font = ttffont;
			this.ASExp_MaxText.text = this.DM.mStringTable.GetStringByID(898u);
			this.ASExp_SkillNameText = this.ASExp_PanelT.GetChild(13).GetComponent<UIText>();
			this.ASExp_SkillNameText.font = ttffont;
			this.ASExp_SkillLvText = this.ASExp_PanelT.GetChild(14).GetComponent<UIText>();
			this.ASExp_SkillLvText.font = ttffont;
			this.ASExp_SkillLvStr = StringManager.Instance.SpawnString(30);
			this.ASExp_ExpBar = this.ASExp_PanelT.GetChild(15).GetComponent<Image>();
			this.ASExp_ExpBarImage = this.ASExp_PanelT.GetChild(15).GetChild(0).GetComponent<Image>();
			this.ASExp_ExpSP = this.ASExp_PanelT.GetChild(15).GetChild(0).GetComponent<UISpritesArray>();
			this.ASExp_SkillExpText = this.ASExp_PanelT.GetChild(16).GetComponent<UIText>();
			this.ASExp_SkillExpText.font = ttffont;
			this.ASExp_SkillExpStr = StringManager.Instance.SpawnString(30);
			this.ASExp_SkillLockT = this.ASExp_PanelT.GetChild(37);
			this.ASExp_LockSP = this.ASExp_PanelT.GetChild(37).GetComponent<UISpritesArray>();
			this.ASExp_SkillLockImage = this.ASExp_SkillLockT.GetComponent<Image>();
			this.ASExp_LockHint = this.ASExp_SkillLockT.gameObject.AddComponent<UIButtonHint>();
			this.ASExp_LockHint.m_eHint = EUIButtonHint.DownUpHandler;
			this.ASExp_LockHint.m_Handler = this;
			this.ASExp_LockHint.Parm2 = 4;
			this.ASExp_AddBtnT1 = this.ASExp_PanelT.GetChild(28);
			this.ASExp_AddBtnT2 = this.ASExp_PanelT.GetChild(27);
			this.ASExp_AddBtn1Click = this.ASExp_PanelT.GetChild(30).gameObject;
			UIButton uibutton = this.ASExp_AddBtn1Click.AddComponent<UIButton>();
			uibutton.SoundIndex = byte.MaxValue;
			this.ASExp_AddBtn2Click = this.ASExp_PanelT.GetChild(29).gameObject;
			uibutton = this.ASExp_AddBtn2Click.AddComponent<UIButton>();
			uibutton.SoundIndex = byte.MaxValue;
			this.ASExp_StoneIconT1 = this.ASExp_PanelT.GetChild(21);
			this.GM.InitianHeroItemImg(this.ASExp_StoneIconT1, eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
			this.ASExp_StoneIconT2 = this.ASExp_PanelT.GetChild(19);
			this.GM.InitianHeroItemImg(this.ASExp_StoneIconT2, eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
			this.ASExp_HaveCountText1 = this.ASExp_PanelT.GetChild(22).GetComponent<UIText>();
			this.ASExp_HaveCountText1.font = ttffont;
			this.ASExp_HaveCountStr1 = StringManager.Instance.SpawnString(30);
			this.ASExp_HaveCountText2 = this.ASExp_PanelT.GetChild(20).GetComponent<UIText>();
			this.ASExp_HaveCountText2.font = ttffont;
			this.ASExp_HaveCountStr2 = StringManager.Instance.SpawnString(30);
			this.ASExp_BottomTipText = this.ASExp_PanelT.GetChild(23).GetComponent<UIText>();
			this.ASExp_BottomTipText.font = ttffont;
			this.ASExp_BottomTipText.text = this.DM.mStringTable.GetStringByID(12125u);
			this.ASExp_SelectTextBackT = this.ASExp_PanelT.GetChild(17);
			this.ASExp_SelectText = this.ASExp_PanelT.GetChild(18).GetComponent<UIText>();
			this.ASExp_SelectText.font = ttffont;
			this.ASExp_SelectText.text = this.DM.mStringTable.GetStringByID(12131u);
			this.ASExp_NeedCountText1 = this.ASExp_PanelT.GetChild(28).GetChild(0).GetComponent<UIText>();
			this.ASExp_NeedCountText1.font = ttffont;
			this.ASExp_NeedCountStr1 = StringManager.Instance.SpawnString(30);
			this.ASExp_NeedCountText2 = this.ASExp_PanelT.GetChild(27).GetChild(0).GetComponent<UIText>();
			this.ASExp_NeedCountText2.font = ttffont;
			this.ASExp_NeedCountStr2 = StringManager.Instance.SpawnString(30);
			this.ASExp_UpText1 = this.ASExp_PanelT.GetChild(28).GetChild(1).GetComponent<UIText>();
			this.ASExp_UpText1.font = ttffont;
			this.ASExp_UpText1.text = this.DM.mStringTable.GetStringByID(12126u);
			this.ASExp_UpText2 = this.ASExp_PanelT.GetChild(27).GetChild(1).GetComponent<UIText>();
			this.ASExp_UpText2.font = ttffont;
			this.ASExp_UpText2.text = this.DM.mStringTable.GetStringByID(12126u);
			this.ASExp_EffIconBlockImage = this.ASExp_PanelT.GetChild(34).GetComponent<Image>();
			this.ASExp_EffIconMoveImage = this.ASExp_PanelT.GetChild(35).GetComponent<Image>();
			this.IconMove_OriginalPos = this.ASExp_EffIconMoveImage.rectTransform.anchoredPosition;
			this.ASExp_EffBarBlockImage = this.ASExp_PanelT.GetChild(36).GetComponent<Image>();
			this.ASExp_EffBarInnerImage = this.ASExp_PanelT.GetChild(38).GetComponent<Image>();
			this.ASExp_EffExpBackImage = this.ASExp_PanelT.GetChild(39).GetComponent<Image>();
			this.ASExp_EffExpText = this.ASExp_PanelT.GetChild(40).GetComponent<UIText>();
			this.ASExp_EffExpText.font = ttffont;
			this.ASExp_EffExpStr = StringManager.Instance.SpawnString(30);
			this.ExpText_OriginalPos = this.ASExp_EffExpText.rectTransform.anchoredPosition;
			this.ASExp_EffX2Text = this.ASExp_PanelT.GetChild(41).GetComponent<UIText>();
			this.ASExp_EffX2Text.font = ttffont;
			this.ASExp_EffX2Str = StringManager.Instance.SpawnString(30);
			this.PM.CheckPetSortIndexAndSort();
		}
		this.EVO_panelT = this.m_transform.GetChild(14);
		this.EVO_panelT.GetChild(9).GetComponent<UIButton>().m_Handler = this;
		this.EVO_panelT.GetChild(10).GetComponent<UIButton>().m_Handler = this;
		this.EVO_panelT.GetChild(11).GetComponent<UIButton>().m_Handler = this;
		this.EVO_panelT.GetChild(12).GetComponent<UIButton>().m_Handler = this;
		this.EVO_panelT.GetChild(12).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			((RectTransform)this.EVO_panelT).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0f);
			((RectTransform)this.EVO_panelT).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0f);
		}
		this.EVO_StoneIconT = this.EVO_panelT.GetChild(5);
		this.GM.InitianHeroItemImg(this.EVO_StoneIconT, eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
		this.EVO_TitleText = this.EVO_panelT.GetChild(2).GetComponent<UIText>();
		this.EVO_TitleText.font = ttffont;
		this.EVO_TitleText.text = this.DM.mStringTable.GetStringByID(16083u);
		this.EVO_InfoText = this.EVO_panelT.GetChild(4).GetComponent<UIText>();
		this.EVO_InfoText.font = ttffont;
		this.EVO_InfoText.text = this.DM.mStringTable.GetStringByID(16053u);
		this.EVO_UpText = this.EVO_panelT.GetChild(7).GetComponent<UIText>();
		this.EVO_UpText.font = ttffont;
		this.EVO_UpStr = StringManager.Instance.SpawnString(30);
		this.EVO_NeedLvText = this.EVO_panelT.GetChild(8).GetComponent<UIText>();
		this.EVO_NeedLvText.font = ttffont;
		this.EVO_NeedStr = StringManager.Instance.SpawnString(150);
		this.EVO_LPriceText = this.EVO_panelT.GetChild(9).GetChild(1).GetComponent<UIText>();
		this.EVO_LPriceText.font = ttffont;
		this.EVO_PriceStr = StringManager.Instance.SpawnString(30);
		this.EVO_LBtnText = this.EVO_panelT.GetChild(9).GetChild(2).GetComponent<UIText>();
		this.EVO_LBtnText.font = ttffont;
		this.EVO_LBtnText.text = this.DM.mStringTable.GetStringByID(2912u);
		this.EVO_RTimeText = this.EVO_panelT.GetChild(10).GetChild(1).GetComponent<UIText>();
		this.EVO_RTimeText.font = ttffont;
		this.EVO_TimeStr = StringManager.Instance.SpawnString(30);
		this.EVO_RBtnText = this.EVO_panelT.GetChild(10).GetChild(2).GetComponent<UIText>();
		this.EVO_RBtnText.font = ttffont;
		this.EVO_RBtnText.text = this.DM.mStringTable.GetStringByID(16052u);
		this.EVO_SrcHint = this.EVO_panelT.GetChild(11).gameObject.AddComponent<UIButtonHint>();
		this.EVO_SrcHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.EVO_SrcHint.m_Handler = this;
		this.EVO_SrcHint.Parm2 = 4;
		this.mPetAct[0] = "idle";
		this.mPetAct[1] = "moving";
		this.mPetAct[2] = "attack";
		this.mPetAct[3] = "skill_1";
		this.mPetAct[4] = "skill_2";
		this.mPetAct[5] = "skill_3";
		this.mPetAct[6] = "victory";
		this.SetNowPet();
		this.door.SetBackGroundPosZ(1000f);
		this.GM.UpdateUI(EGUIWindow.Door, 1, 7);
		if (!this.bMaxShow)
		{
			NewbieManager.CheckPetInfo();
		}
	}

	// Token: 0x06001634 RID: 5684 RVA: 0x00263D8C File Offset: 0x00261F8C
	public override void OnClose()
	{
		this.HideAddSkillExpPanel();
		this.HideEvoPanel();
		this.GM.RemoverTimeBaarToList(this.TimeBar);
		this.DeSpawnParticle_Up();
		this.DeSpawnParticle_X2();
		this.DeSpawnParticle_Body();
		this.DestroyPet3D();
		this.DestroyEmoji();
		for (int i = 0; i < 3; i++)
		{
			StringManager.Instance.DeSpawnString(this.SkillNameStr[i]);
			StringManager.Instance.DeSpawnString(this.SkillExpStr[i]);
		}
		StringManager.Instance.DeSpawnString(this.ExpStr);
		StringManager.Instance.DeSpawnString(this.StoneStr);
		StringManager.Instance.DeSpawnString(this.LevelStr_L);
		StringManager.Instance.DeSpawnString(this.LevelStr);
		StringManager.Instance.DeSpawnString(this.RankStr);
		StringManager.Instance.DeSpawnString(this.UpStr);
		StringManager.Instance.DeSpawnString(this.HinString);
		StringManager.Instance.DeSpawnString(this.RareStr);
		if (!this.bMaxShow)
		{
			StringManager.Instance.DeSpawnString(this.ASExp_InfoNowStr);
			StringManager.Instance.DeSpawnString(this.ASExp_InfoNextStr);
			StringManager.Instance.DeSpawnString(this.ASExp_SkillLvStr);
			StringManager.Instance.DeSpawnString(this.ASExp_SkillExpStr);
			StringManager.Instance.DeSpawnString(this.ASExp_HaveCountStr1);
			StringManager.Instance.DeSpawnString(this.ASExp_NeedCountStr1);
			StringManager.Instance.DeSpawnString(this.ASExp_HaveCountStr2);
			StringManager.Instance.DeSpawnString(this.ASExp_NeedCountStr2);
			StringManager.Instance.DeSpawnString(this.ASExp_InfoNowCDStr);
			StringManager.Instance.DeSpawnString(this.ASExp_InfoNextCDStr);
			StringManager.Instance.DeSpawnString(this.ASExp_InfoStr);
			StringManager.Instance.DeSpawnString(this.ASExp_EffExpStr);
			StringManager.Instance.DeSpawnString(this.ASExp_EffX2Str);
		}
		StringManager.Instance.DeSpawnString(this.EVO_UpStr);
		StringManager.Instance.DeSpawnString(this.EVO_NeedStr);
		StringManager.Instance.DeSpawnString(this.EVO_PriceStr);
		StringManager.Instance.DeSpawnString(this.EVO_TimeStr);
		this.door.SetBackGroundPosZ(0f);
	}

	// Token: 0x06001635 RID: 5685 RVA: 0x00263FD0 File Offset: 0x002621D0
	public void LoadPet3D()
	{
		this.ActionTime = 0f;
		this.ActionTimeRandom = 2f;
		this.btn_PetActionD.ReSetHero();
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)this.sHero.Modle, 5, false);
		cstring.AppendFormat("Role/hero_{0}");
		if (this.sHero.Modle > 0 && AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, this.sHero.Modle, false))
		{
			this.AB = AssetManager.GetAssetBundle(cstring, out this.AssetKey);
			if (this.AB != null)
			{
				this.AR = this.AB.LoadAsync("m", typeof(GameObject));
				this.bABInitial = false;
			}
		}
		else
		{
			this.AR = null;
		}
	}

	// Token: 0x06001636 RID: 5686 RVA: 0x002640AC File Offset: 0x002622AC
	public void DestroyPet3D()
	{
		if (this.PetGO != null)
		{
			this.PetGO.transform.SetParent(this.PetPosRT.parent, false);
			ModelLoader.Instance.Unload(this.PetGO);
			this.PetGO = null;
		}
		if (this.PetModel != null)
		{
			UnityEngine.Object.Destroy(this.PetModel);
			this.PetModel = null;
		}
		if (this.AssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey, false);
		}
		this.HideEmoji();
	}

	// Token: 0x06001637 RID: 5687 RVA: 0x00264140 File Offset: 0x00262340
	public void HeroActionChang(bool bForceShowEmoji = false)
	{
		if (this.bABInitial && this.PetModel != null)
		{
			this.tmpAN = this.PetModel.GetComponent<Animation>();
			this.tmpAN.wrapMode = WrapMode.Loop;
			if (this.PetAct == this.mPetAct[1])
			{
				this.tmpAN.CrossFade("idle");
			}
			if (this.tmpAN.GetClip(this.mPetAct[2]) != null)
			{
				this.PetAct = this.mPetAct[2];
				this.tmpAN[this.mPetAct[2]].layer = 1;
				this.tmpAN[this.mPetAct[2]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(this.mPetAct[3]) != null)
			{
				this.PetAct = this.mPetAct[3];
				this.tmpAN[this.mPetAct[3]].layer = 1;
				this.tmpAN[this.mPetAct[3]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[4]) != null)
			{
				this.tmpAN[this.mPetAct[4]].layer = 1;
				this.tmpAN[this.mPetAct[4]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(this.mPetAct[5]) != null)
			{
				this.PetAct = this.mPetAct[5];
				this.tmpAN[this.mPetAct[5]].layer = 1;
				this.tmpAN[this.mPetAct[5]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(this.mPetAct[6]) != null)
			{
				this.PetAct = this.mPetAct[6];
				this.tmpAN[this.mPetAct[6]].layer = 1;
				this.tmpAN[this.mPetAct[6]].wrapMode = WrapMode.Once;
			}
			int num = UnityEngine.Random.Range(1, (int)this.RandomEnd);
			AnimationClip animationClip = this.tmpAN.GetClip(this.mPetAct[(int)((byte)num)]);
			this.PetAct = this.mPetAct[(int)((byte)num)];
			if (num == 3)
			{
				AnimationClip clip = this.tmpAN.GetClip(this.PetAct + "_ch");
				if (clip != null)
				{
					animationClip = null;
				}
			}
			if (animationClip != null)
			{
				this.tmpAN.CrossFade(animationClip.name);
				this.MovingTimer = 0f;
				if (num == 1)
				{
					this.MovingTimer = 2f;
				}
			}
			this.ActionTimeRandom = 0f;
			this.ActionTime = 0f;
			if (num != 0)
			{
				if (bForceShowEmoji || UnityEngine.Random.Range(1, 100) > 75)
				{
					this.ShowEmoji();
				}
			}
			else
			{
				this.HideEmoji();
			}
		}
	}

	// Token: 0x06001638 RID: 5688 RVA: 0x00264454 File Offset: 0x00262654
	private void SpawnParticle_Body()
	{
		this.DeSpawnParticle_Body();
		if (this.PetGO == null)
		{
			return;
		}
		Transform skeletalTrans = AnimationUnit.GetSkeletalTrans(this.PetGO, AnimationUnit.HIT_POINT_ROOTBONE);
		if (skeletalTrans != null)
		{
			float scale;
			ushort effID;
			if (this.bMaxShow)
			{
				scale = (float)this.sPet.EffectRatio[2] / 1000f;
				effID = this.ParticleID[2];
			}
			else
			{
				scale = (float)(((int)this.NowPet.Enhance >= this.sPet.EffectRatio.Length) ? this.sPet.EffectRatio[0] : this.sPet.EffectRatio[(int)this.NowPet.Enhance]) / 1000f;
				effID = (((int)this.NowPet.Enhance >= this.ParticleID.Length) ? this.ParticleID[0] : this.ParticleID[(int)this.NowPet.Enhance]);
			}
			this.ParticleObj = ParticleManager.Instance.Spawn(effID, skeletalTrans, Vector3.zero, scale, true, true, true);
			if (this.ParticleObj != null)
			{
				GUIManager.Instance.SetLayer(this.ParticleObj, 5);
				this.ParticleObj.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
				this.ParticleObj.transform.localPosition = Vector3.zero;
				if (this.CheckHideParticle())
				{
					this.ParticleObj.gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06001639 RID: 5689 RVA: 0x002645EC File Offset: 0x002627EC
	private void DeSpawnParticle_Body()
	{
		if (this.ParticleObj != null)
		{
			ParticleManager.Instance.DeSpawn(this.ParticleObj);
			this.ParticleObj = null;
		}
	}

	// Token: 0x0600163A RID: 5690 RVA: 0x00264618 File Offset: 0x00262818
	private void SpawnParticle_Bar()
	{
		this.DeSpawnParticle_Bar();
		this.ParticleObj_Bar = ParticleManager.Instance.Spawn(444, this.TimeBarEffectT, Vector3.zero, 0.8f, true, true, true);
		if (this.ParticleObj_Bar != null)
		{
			GUIManager.Instance.SetLayer(this.ParticleObj_Bar, 5);
			this.ParticleObj_Bar.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			this.ParticleObj_Bar.transform.localPosition = Vector3.zero;
		}
	}

	// Token: 0x0600163B RID: 5691 RVA: 0x002646B4 File Offset: 0x002628B4
	private void DeSpawnParticle_Bar()
	{
		if (this.ParticleObj_Bar != null)
		{
			ParticleManager.Instance.DeSpawn(this.ParticleObj_Bar);
			this.ParticleObj_Bar = null;
		}
	}

	// Token: 0x0600163C RID: 5692 RVA: 0x002646E0 File Offset: 0x002628E0
	private bool CheckHideParticle()
	{
		return this.NowEvoID != -1 || this.SelectSkillIndex != -1 || this.GM.FindMenu(EGUIWindow.UI_PetStoneTrans);
	}

	// Token: 0x0600163D RID: 5693 RVA: 0x00264718 File Offset: 0x00262918
	private void SetParticle_Show(bool bShow, bool ForceShow = false)
	{
		if (bShow && !ForceShow && this.CheckHideParticle())
		{
			return;
		}
		if (this.ParticleObj != null)
		{
			this.ParticleObj.gameObject.SetActive(bShow);
		}
		if (this.TimeBarEffectT != null)
		{
			this.TimeBarEffectT.gameObject.SetActive(bShow);
		}
	}

	// Token: 0x0600163E RID: 5694 RVA: 0x00264784 File Offset: 0x00262984
	private void SpawnParticle_Up()
	{
		if (this.ShowUpEffectPetID != 0)
		{
			this.ShowUpEffectPetID = 0;
			if (this.PetGO == null)
			{
				return;
			}
			this.UpParticleGO = ParticleManager.Instance.Spawn(440, this.PetPosRT, Vector3.zero, 1f, true, true, true);
			if (this.UpParticleGO != null)
			{
				GUIManager.Instance.SetLayer(this.UpParticleGO, 5);
				this.UpParticleGO.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
				this.UpParticleGO.transform.localPosition = Vector3.zero;
				AudioManager.Instance.PlayUISFX(UIKind.PetEnhance);
			}
		}
	}

	// Token: 0x0600163F RID: 5695 RVA: 0x00264850 File Offset: 0x00262A50
	private void DeSpawnParticle_Up()
	{
		this.ShowUpEffectPetID = 0;
		if (this.UpParticleGO != null)
		{
			if (this.UpParticleGO.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.UpParticleGO.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
				this.UpParticleGO.SetActive(false);
				this.UpParticleGO.SetActive(true);
			}
			this.UpParticleGO = null;
		}
	}

	// Token: 0x06001640 RID: 5696 RVA: 0x002648DC File Offset: 0x00262ADC
	private void SpawnParticle_X2()
	{
		if (this.X2ParticleGO != null)
		{
			return;
		}
		this.X2ParticleGO = ParticleManager.Instance.Spawn(445, this.ASExp_ExpBar.rectTransform, Vector3.zero, 1f, true, true, true);
		if (this.X2ParticleGO != null)
		{
			GUIManager.Instance.SetLayer(this.X2ParticleGO, 5);
			this.X2ParticleGO.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			this.X2ParticleGO.transform.localPosition = Vector3.zero;
		}
	}

	// Token: 0x06001641 RID: 5697 RVA: 0x00264988 File Offset: 0x00262B88
	private void DeSpawnParticle_X2()
	{
		if (this.X2ParticleGO != null)
		{
			if (this.X2ParticleGO.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.X2ParticleGO.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
				this.X2ParticleGO.SetActive(false);
				this.X2ParticleGO.SetActive(true);
			}
			this.X2ParticleGO = null;
		}
	}

	// Token: 0x06001642 RID: 5698 RVA: 0x00264A0C File Offset: 0x00262C0C
	private void ShowEmoji()
	{
		if (this.EmojiRC)
		{
			if (this.Emoji != null)
			{
				this.GM.pushEmojiIcon(this.Emoji);
				this.Emoji = null;
			}
			ushort index = (ushort)UnityEngine.Random.Range(3, DataManager.MapDataController.EmojiDataTable.TableCount);
			EmojiData recordByIndex = DataManager.MapDataController.EmojiDataTable.GetRecordByIndex((int)index);
			float num = (float)((recordByIndex.sizeX <= recordByIndex.sizeY) ? recordByIndex.sizeY : recordByIndex.sizeX);
			if (num == 0f)
			{
				num = ((this.GM.EmojiManager != null) ? this.GM.EmojiManager.basebacksize : 73f);
			}
			else
			{
				num *= 0.9f;
				num += ((this.GM.EmojiManager != null) ? this.GM.EmojiManager.basebackoffset : 25f);
			}
			num /= ((this.GM.EmojiManager != null) ? this.GM.EmojiManager.basebacksize : 73f);
			if (this.EmojiBack != null)
			{
				this.EmojiBack.EmojiTransform.localPosition = Vector2.zero;
				this.EmojiBack.EmojiTransform.localScale = Vector3.one * num;
			}
			this.Emoji = this.GM.pullEmojiIcon(recordByIndex.IconID, recordByIndex.KeyFrame, false);
			if (this.Emoji != null)
			{
				this.Emoji.EmojiTransform.localPosition = new Vector3(0f, 5f, 0f);
				this.Emoji.EmojiTransform.localScale = Vector3.one * 0.9f;
				this.Emoji.EmojiTransform.SetParent(this.EmojiRC, false);
				if (this.bMaxShow || this.NowPet.Enhance == this.PM.GetMaxEnhance())
				{
					this.EmojiRC.anchoredPosition = new Vector2((float)UnityEngine.Random.Range(-340, -380), (float)UnityEngine.Random.Range(90, 125));
				}
				else if (this.NowPet.Enhance == 1)
				{
					this.EmojiRC.anchoredPosition = new Vector2((float)UnityEngine.Random.Range(-300, -340), (float)UnityEngine.Random.Range(55, 90));
				}
				else if (this.NowPet.Enhance == 0)
				{
					this.EmojiRC.anchoredPosition = new Vector2((float)UnityEngine.Random.Range(-260, -300), (float)UnityEngine.Random.Range(20, 55));
				}
				this.StartEmojiMove();
			}
			else
			{
				this.EmojiRC.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001643 RID: 5699 RVA: 0x00264CEC File Offset: 0x00262EEC
	private void HideEmoji()
	{
		if (this.EmojiRC != null)
		{
			this.EmojiRC.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001644 RID: 5700 RVA: 0x00264D1C File Offset: 0x00262F1C
	private void DestroyEmoji()
	{
		if (this.Emoji != null)
		{
			this.GM.pushEmojiIcon(this.Emoji);
			this.Emoji = null;
		}
		if (this.EmojiBack != null)
		{
			this.GM.pushEmojiIcon(this.EmojiBack);
			this.EmojiBack = null;
		}
	}

	// Token: 0x06001645 RID: 5701 RVA: 0x00264D70 File Offset: 0x00262F70
	private void StartEmojiMove()
	{
		if (this.EmojiRC == null)
		{
			return;
		}
		this.EmijiShowCountTime = 0f;
		this.EmojiRC.localScale = Vector3.zero;
		this.EmojiRC.gameObject.SetActive(true);
	}

	// Token: 0x06001646 RID: 5702 RVA: 0x00264DBC File Offset: 0x00262FBC
	private void EndEmojiMove()
	{
		if (this.EmojiRC == null)
		{
			return;
		}
		this.EmijiShowCountTime = -1f;
		this.EmojiRC.localScale = Vector3.one;
	}

	// Token: 0x06001647 RID: 5703 RVA: 0x00264DEC File Offset: 0x00262FEC
	private void SetNowPet()
	{
		ushort num;
		if (this.bMaxShow)
		{
			num = (ushort)this.PM.PetUI_PetMaxShowID;
		}
		else
		{
			num = (ushort)this.PM.PetUI_PetID;
		}
		this.NowPet = this.PM.FindPetData(num);
		this.sPet = this.PM.PetTable.GetRecordByKey(num);
		this.sHero = this.DM.HeroTable.GetRecordByKey(this.sPet.HeroID);
		if (this.NowPet != null)
		{
			this.NowPet.Remove(PetManager.EPetState.NewPet);
		}
		this.DeSpawnParticle_Up();
		this.DestroyPet3D();
		this.LoadPet3D();
		this.SetBlood();
		this.SetStone();
		this.SetPetInfo();
		this.SetSkill();
	}

	// Token: 0x06001648 RID: 5704 RVA: 0x00264EB4 File Offset: 0x002630B4
	private void SetLight()
	{
		if (this.myLight1 == null)
		{
			return;
		}
		if (this.bMaxShow)
		{
			this.myLight1.range = 22.5f;
		}
		else if (this.NowPet != null)
		{
			if (this.NowPet.Enhance == 0)
			{
				this.myLight1.range = 23.4f;
			}
			if (this.NowPet.Enhance == 1)
			{
				this.myLight1.range = 22.9f;
			}
			if (this.NowPet.Enhance == 2)
			{
				this.myLight1.range = 22.5f;
			}
		}
	}

	// Token: 0x06001649 RID: 5705 RVA: 0x00264F60 File Offset: 0x00263160
	private void SetBlood()
	{
		if (this.PetNameText == null)
		{
			return;
		}
		this.PetNameText.text = this.DM.mStringTable.GetStringByID((uint)this.sPet.Name);
		if (this.bMaxShow)
		{
			this.LevelStr_L.Length = 0;
			this.LevelStr_L.IntToFormat((long)this.GetMaxLv(this.PM.GetMaxEnhance()), 1, false);
			this.LevelStr_L.AppendFormat(this.DM.mStringTable.GetStringByID(52u));
			this.ExpStr.Length = 0;
			this.ExpStr.Append(this.DM.mStringTable.GetStringByID(898u));
			this.ExpSP.SetSpriteIndex(1);
			this.BloodBtnT.gameObject.SetActive(false);
		}
		else
		{
			if (this.NowPet == null)
			{
				return;
			}
			this.LevelStr_L.Length = 0;
			this.LevelStr_L.IntToFormat((long)this.NowPet.Level, 1, false);
			this.LevelStr_L.AppendFormat(this.DM.mStringTable.GetStringByID(52u));
			uint needExp = this.PM.GetNeedExp(this.NowPet.Level, this.sPet.Rare);
			this.BloodBtnT.gameObject.SetActive(true);
			this.ExpSP.SetSpriteIndex(0);
			this.ExpStr.Length = 0;
			if (this.NowPet.CheckState(PetManager.EPetState.Evolution))
			{
				this.ExpStr.Append(this.DM.mStringTable.GetStringByID(376u));
				this.ExpImage.fillAmount = 1f;
				this.BloodSP.SetSpriteIndex(1);
				this.BloodSP.m_Image.rectTransform.anchoredPosition = new Vector2(-83.5f, 202.5f);
				this.BloodSP.m_Image.SetNativeSize();
			}
			else if (this.CheckMaxLv() && (this.NowPet.Exp == needExp - 1u || this.NowPet.Enhance == this.PM.GetMaxEnhance()))
			{
				if (this.NowPet.Enhance == this.PM.GetMaxEnhance())
				{
					this.ExpStr.Append(this.DM.mStringTable.GetStringByID(898u));
					this.ExpSP.SetSpriteIndex(1);
					this.ExpImage.fillAmount = 1f;
					this.BloodBtnT.gameObject.SetActive(false);
				}
				else
				{
					this.ExpStr.Append(this.DM.mStringTable.GetStringByID(16051u));
					this.ExpImage.fillAmount = 1f;
					this.BloodSP.SetSpriteIndex(1);
					this.BloodSP.m_Image.rectTransform.anchoredPosition = new Vector2(-83.5f, 202.5f);
					this.BloodSP.m_Image.SetNativeSize();
				}
			}
			else
			{
				this.ExpStr.IntToFormat((long)((ulong)this.NowPet.Exp), 1, true);
				this.ExpStr.IntToFormat((long)((ulong)needExp), 1, true);
				if (this.GM.IsArabic)
				{
					this.ExpStr.AppendFormat("{1} / {0} ");
				}
				else
				{
					this.ExpStr.AppendFormat("{0} / {1} ");
				}
				this.ExpStr.Append(this.DM.mStringTable.GetStringByID(9u));
				double num = (needExp == 0u) ? 0.0 : (this.NowPet.Exp / needExp);
				this.ExpImage.fillAmount = (float)num;
				this.BloodSP.SetSpriteIndex(0);
				this.BloodSP.m_Image.rectTransform.anchoredPosition = new Vector2(-77.5f, 195.5f);
				this.BloodSP.m_Image.SetNativeSize();
			}
		}
		this.LevelText_L.text = this.LevelStr_L.ToString();
		this.LevelText_L.SetAllDirty();
		this.LevelText_L.cachedTextGenerator.Invalidate();
		this.ExpText.text = this.ExpStr.ToString();
		this.ExpText.SetAllDirty();
		this.ExpText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x0600164A RID: 5706 RVA: 0x002653D4 File Offset: 0x002635D4
	private void SetStone()
	{
		if (this.StoneT == null)
		{
			return;
		}
		if (this.bMaxShow)
		{
			this.MaxShowT.gameObject.SetActive(true);
			this.StoneT.gameObject.SetActive(false);
		}
		else
		{
			this.MaxShowT.gameObject.SetActive(false);
			this.StoneT.gameObject.SetActive(true);
			this.GM.ChangeHeroItemImg(this.StoneIcon, eHeroOrItem.Item, this.sPet.SoulID, 0, 0, 0);
			this.StoneStr.Length = 0;
			this.StoneStr.StringToFormat(this.DM.mStringTable.GetStringByID(16050u));
			this.StoneStr.IntToFormat((long)this.DM.GetCurItemQuantity(this.sPet.SoulID, 0), 1, true);
			this.StoneStr.AppendFormat("{0}：{1}");
			this.StoneText.text = this.StoneStr.ToString();
			this.StoneText.SetAllDirty();
			this.StoneText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x0600164B RID: 5707 RVA: 0x002654FC File Offset: 0x002636FC
	private void SetPetInfo()
	{
		if (this.LevelText == null)
		{
			return;
		}
		if (this.bMaxShow)
		{
			this.GM.ChangeHeroItemImg(this.PetIcon, eHeroOrItem.Pet, this.sPet.ID, this.PM.GetMaxEnhance(), 0, 0);
			this.RareStr.Length = 0;
			StringManager.IntToStr(this.RareStr, (long)this.sPet.Rare, 1, false);
			this.LevelStr.Length = 0;
			this.LevelStr.IntToFormat((long)this.GetMaxLv(this.PM.GetMaxEnhance()), 1, false);
			this.LevelStr.AppendFormat(this.DM.mStringTable.GetStringByID(16049u));
			this.RankStr.Length = 0;
			this.RankStr.StringToFormat(this.DM.mStringTable.GetStringByID(16068u));
			this.RankStr.AppendFormat(this.DM.mStringTable.GetStringByID(16048u));
			this.UpStr.Length = 0;
			this.UpStr.Append(this.DM.mStringTable.GetStringByID(21u));
			this.UpText.color = this.MaxTextColor;
			this.RankT.gameObject.SetActive(false);
			this.PanelRLightT.gameObject.SetActive(true);
			this.PanelBlockT.gameObject.SetActive(true);
			this.RandomEnd = 7;
		}
		else
		{
			if (this.NowPet == null)
			{
				return;
			}
			this.GM.ChangeHeroItemImg(this.PetIcon, eHeroOrItem.Pet, this.sPet.ID, this.NowPet.Enhance, 0, 0);
			this.RareStr.Length = 0;
			StringManager.IntToStr(this.RareStr, (long)this.sPet.Rare, 1, false);
			this.LevelStr.Length = 0;
			this.LevelStr.IntToFormat((long)this.GetMaxLv(this.NowPet.Enhance), 1, false);
			this.LevelStr.AppendFormat(this.DM.mStringTable.GetStringByID(16049u));
			this.RankStr.Length = 0;
			this.RankStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.NowPet.Enhance + 16066u));
			this.RankStr.AppendFormat(this.DM.mStringTable.GetStringByID(16048u));
			this.UpStr.Length = 0;
			if (this.NowPet.Enhance == 2)
			{
				this.UpStr.Append(this.DM.mStringTable.GetStringByID(21u));
				this.UpText.color = this.MaxTextColor;
				this.PanelRLightT.gameObject.SetActive(true);
				this.PanelBlockT.gameObject.SetActive(true);
			}
			else
			{
				this.UpStr.IntToFormat((long)this.DM.GetCurItemQuantity(this.sPet.SoulID, 0), 1, true);
				this.UpStr.IntToFormat((long)this.PM.GetEvoNeed_Stone(this.NowPet.Enhance, this.sPet.Rare), 1, true);
				if (this.GM.IsArabic)
				{
					this.UpStr.AppendFormat("{1} / {0}");
				}
				else
				{
					this.UpStr.AppendFormat("{0} / {1}");
				}
				this.UpText.color = Color.white;
				this.PanelRLightT.gameObject.SetActive(false);
				this.PanelBlockT.gameObject.SetActive(false);
			}
			if (this.NowPet.Enhance == 2)
			{
				this.RankT.gameObject.SetActive(false);
			}
			else
			{
				this.RankT.gameObject.SetActive(true);
				this.RankT.GetChild(1).gameObject.SetActive(false);
				this.RankT.GetChild(2).gameObject.SetActive(false);
				if (this.CheckEvoItem() && this.PM.PetUI_EvoID != this.NowPet.ID)
				{
					if (this.CheckMaxLv())
					{
						this.RankT.GetChild(1).gameObject.SetActive(true);
					}
					else
					{
						this.RankT.GetChild(2).gameObject.SetActive(true);
					}
				}
			}
			if (this.NowPet.CheckState(PetManager.EPetState.Training))
			{
				this.PetStateImage.gameObject.SetActive(true);
			}
			else
			{
				this.PetStateImage.gameObject.SetActive(false);
			}
			if (this.PM.PetUI_EvoID == this.NowPet.ID)
			{
				int num = 35;
				long notifyTime = 0L;
				long startTime = this.DM.queueBarData[num].StartTime;
				long num2 = startTime + (long)((ulong)this.DM.queueBarData[num].TotalTime);
				eTimerSpriteType queueBarSpriteType = this.DM.GetQueueBarSpriteType(EQueueBarIndex.PetEvolution);
				if (queueBarSpriteType != eTimerSpriteType.Free)
				{
					notifyTime = num2 - (long)this.DM.FreeCompletePeriod;
				}
				this.GM.SetTimerBar(this.TimeBar, startTime, num2, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(376u), this.DM.mStringTable.GetStringByID((uint)this.sPet.Name));
				this.GM.SetTimerSpriteType(this.TimeBar, queueBarSpriteType);
				this.TimeBar.gameObject.SetActive(true);
				this.TimeBarBackT.gameObject.SetActive(true);
				this.HideEvoPanel();
				this.SpawnParticle_Bar();
			}
			else
			{
				this.TimeBar.gameObject.SetActive(false);
				this.TimeBarBackT.gameObject.SetActive(false);
				this.DeSpawnParticle_Bar();
			}
			this.RandomEnd = 7;
		}
		this.RareText.text = this.RareStr.ToString();
		this.RareText.SetAllDirty();
		this.RareText.cachedTextGenerator.Invalidate();
		this.LevelText.text = this.LevelStr.ToString();
		this.LevelText.SetAllDirty();
		this.LevelText.cachedTextGenerator.Invalidate();
		this.RankText.text = this.RankStr.ToString();
		this.RankText.SetAllDirty();
		this.RankText.cachedTextGenerator.Invalidate();
		this.UpText.text = this.UpStr.ToString();
		this.UpText.SetAllDirty();
		this.UpText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x0600164C RID: 5708 RVA: 0x00265BB0 File Offset: 0x00263DB0
	private void SetSkill()
	{
		if (this.SkillT[0] == null)
		{
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			this.SkillT[i].gameObject.SetActive(false);
		}
		byte b = 0;
		for (int j = 0; j < 3; j++)
		{
			if (this.sPet.PetSkill[j] != 0)
			{
				PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[j]);
				this.SkillNameStr[(int)b].Length = 0;
				if (this.bMaxShow)
				{
					this.SkillNameStr[(int)b].IntToFormat((long)recordByKey.UpLevel, 1, false);
					this.SkillNameText[(int)b].color = this.MaxTextColor;
				}
				else
				{
					this.SkillNameStr[(int)b].IntToFormat((long)this.NowPet.SkillLv[j], 1, false);
					if (this.NowPet.SkillLv[j] >= recordByKey.UpLevel)
					{
						this.SkillNameText[(int)b].color = this.MaxTextColor;
					}
					else
					{
						this.SkillNameText[(int)b].color = Color.white;
					}
				}
				this.SkillNameStr[(int)b].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
				this.SkillNameStr[(int)b].AppendFormat(this.DM.mStringTable.GetStringByID(268u));
				this.SkillNameText[(int)b].text = this.SkillNameStr[(int)b].ToString();
				this.SkillNameText[(int)b].SetAllDirty();
				this.SkillNameText[(int)b].cachedTextGenerator.Invalidate();
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.Append('s');
				cstring.IntToFormat((long)recordByKey.Icon, 5, false);
				cstring.AppendFormat("{0}");
				this.SkillImage1[(int)b].sprite = this.GM.LoadSkillSprite(cstring);
				this.SkillImage1[(int)b].material = this.GM.GetSkillMaterial();
				this.SkillPicHint[(int)b].Parm1 = (ushort)j;
				if (!this.bMaxShow && (int)this.NowPet.Enhance < j)
				{
					this.SkillLockGO[(int)b].gameObject.SetActive(true);
					this.SkillExpImageT[(int)b].gameObject.SetActive(false);
					this.SkillExpText[(int)b].gameObject.SetActive(false);
					this.SkillBtnT[(int)b].gameObject.SetActive(false);
					this.SkillLockText[(int)b].text = this.DM.mStringTable.GetStringByID((uint)(16060 + j));
				}
				else
				{
					this.SkillLockGO[(int)b].gameObject.SetActive(false);
					this.SkillExpImageT[(int)b].gameObject.SetActive(true);
					this.SkillExpText[(int)b].gameObject.SetActive(true);
					if (this.bMaxShow)
					{
						this.SkillBtnT[(int)b].gameObject.SetActive(false);
						this.SkillExpStr[(int)b].Length = 0;
						this.SkillExpStr[(int)b].Append(this.DM.mStringTable.GetStringByID(898u));
						this.SkillExpImage[(int)b].fillAmount = 1f;
						this.SkillExpImageSP[(int)b].SetSpriteIndex(1);
					}
					else
					{
						this.SkillExpStr[(int)b].Length = 0;
						if (this.NowPet.SkillLv[j] >= recordByKey.UpLevel)
						{
							this.SkillBtnT[(int)b].gameObject.SetActive(false);
							this.SkillExpStr[(int)b].Append(this.DM.mStringTable.GetStringByID(898u));
							this.SkillExpImage[(int)b].fillAmount = 1f;
							this.SkillExpImageSP[(int)b].SetSpriteIndex(1);
						}
						else
						{
							this.SkillBtnT[(int)b].gameObject.SetActive(true);
							this.SkillBtn[(int)b].m_BtnID3 = j;
							uint needSkillExp = this.GetNeedSkillExp(recordByKey.Experience, this.NowPet.SkillLv[j]);
							this.SkillExpStr[(int)b].IntToFormat((long)((ulong)this.NowPet.SkillExp[j]), 1, true);
							this.SkillExpStr[(int)b].IntToFormat((long)((ulong)needSkillExp), 1, true);
							if (this.GM.IsArabic)
							{
								this.SkillExpStr[(int)b].AppendFormat("{1} / {0} ");
							}
							else
							{
								this.SkillExpStr[(int)b].AppendFormat("{0} / {1} ");
							}
							this.SkillExpStr[(int)b].Append(this.DM.mStringTable.GetStringByID(9u));
							double num = (needSkillExp == 0u) ? 0.0 : (this.NowPet.SkillExp[j] / needSkillExp);
							this.SkillExpImage[(int)b].fillAmount = (float)num;
							this.SkillExpImageSP[(int)b].SetSpriteIndex(0);
							if ((this.NowPet.SkillLv[j] <= 0 || (int)this.NowPet.SkillLv[j] > recordByKey.OpenLevel.Length || this.NowPet.Level >= recordByKey.OpenLevel[(int)(this.NowPet.SkillLv[j] - 1)] || this.NowPet.SkillExp[j] != needSkillExp - 1u) && this.DM.GetCurItemQuantity(this.sPet.SoulID, 0) >= this.PM.PetUI_UpNeedStoneCount)
							{
								this.SkillBtnAlertT[(int)b].gameObject.SetActive(true);
							}
							else
							{
								this.SkillBtnAlertT[(int)b].gameObject.SetActive(false);
							}
						}
					}
					this.SkillExpText[(int)b].text = this.SkillExpStr[(int)b].ToString();
					this.SkillExpText[(int)b].SetAllDirty();
					this.SkillExpText[(int)b].cachedTextGenerator.Invalidate();
				}
				if (recordByKey.Type == 1)
				{
					this.SkillkindImage[(int)b].enabled = true;
					this.SkillkindSP[(int)b].SetSpriteIndex((recordByKey.Subject != 1) ? 0 : 1);
					this.SkillKindHint[(int)b].Parm1 = ((recordByKey.Subject != 1) ? 16064 : 16063);
				}
				else
				{
					this.SkillkindImage[(int)b].enabled = false;
				}
				this.SkillT[(int)b].gameObject.SetActive(true);
				b += 1;
			}
		}
	}

	// Token: 0x0600164D RID: 5709 RVA: 0x00266238 File Offset: 0x00264438
	private void SetAddSkill_Item()
	{
		if (this.NowPet == null || this.SelectSkillIndex < 0 || this.SelectSkillIndex >= 4)
		{
			return;
		}
		this.GM.ChangeHeroItemImg(this.ASExp_StoneIconT1, eHeroOrItem.Item, this.sPet.SoulID, 0, 0, 0);
		this.GM.ChangeHeroItemImg(this.ASExp_StoneIconT2, eHeroOrItem.Item, this.ASExp_ExpItemID, 0, 0, 0);
		this.ASExp_HaveCountStr1.Length = 0;
		this.ASExp_HaveCountStr1.IntToFormat((long)this.DM.GetCurItemQuantity(this.sPet.SoulID, 0), 1, true);
		this.ASExp_HaveCountStr1.AppendFormat(this.DM.mStringTable.GetStringByID(79u));
		this.ASExp_HaveCountText1.text = this.ASExp_HaveCountStr1.ToString();
		this.ASExp_HaveCountText1.SetAllDirty();
		this.ASExp_HaveCountText1.cachedTextGenerator.Invalidate();
		this.ASExp_HaveCountStr2.Length = 0;
		this.ASExp_HaveCountStr2.IntToFormat((long)this.DM.GetCurItemQuantity(this.ASExp_ExpItemID, 0), 1, true);
		this.ASExp_HaveCountStr2.AppendFormat(this.DM.mStringTable.GetStringByID(79u));
		this.ASExp_HaveCountText2.text = this.ASExp_HaveCountStr2.ToString();
		this.ASExp_HaveCountText2.SetAllDirty();
		this.ASExp_HaveCountText2.cachedTextGenerator.Invalidate();
		this.ASExp_NeedCountStr1.Length = 0;
		this.ASExp_NeedCountStr1.IntToFormat((long)this.PM.PetUI_UpNeedStoneCount, 1, true);
		this.ASExp_NeedCountStr1.AppendFormat(this.DM.mStringTable.GetStringByID(15005u));
		this.ASExp_NeedCountText1.text = this.ASExp_NeedCountStr1.ToString();
		this.ASExp_NeedCountText1.SetAllDirty();
		this.ASExp_NeedCountText1.cachedTextGenerator.Invalidate();
		this.ASExp_NeedCountStr2.Length = 0;
		if (this.sPet.Rare >= 1 && (int)this.sPet.Rare <= this.PM.PetUI_UpNeedSoulCount.Length)
		{
			this.ASExp_NeedCountStr2.IntToFormat((long)this.PM.PetUI_UpNeedSoulCount[(int)(this.sPet.Rare - 1)], 1, true);
		}
		else
		{
			this.ASExp_NeedCountStr2.IntToFormat(0L, 1, true);
		}
		this.ASExp_NeedCountStr2.AppendFormat(this.DM.mStringTable.GetStringByID(15005u));
		this.ASExp_NeedCountText2.text = this.ASExp_NeedCountStr2.ToString();
		this.ASExp_NeedCountText2.SetAllDirty();
		this.ASExp_NeedCountText2.cachedTextGenerator.Invalidate();
	}

	// Token: 0x0600164E RID: 5710 RVA: 0x002664E0 File Offset: 0x002646E0
	private void SetAddSkill_Info()
	{
		if (this.NowPet == null || this.SelectSkillIndex < 0 || this.SelectSkillIndex >= 4)
		{
			return;
		}
		PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[this.SelectSkillIndex]);
		byte b = this.NowPet.SkillLv[this.SelectSkillIndex];
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.Append('s');
		cstring.IntToFormat((long)recordByKey.Icon, 5, false);
		cstring.AppendFormat("{0}");
		this.ASExp_SkillImage1.sprite = this.GM.LoadSkillSprite(cstring);
		this.ASExp_SkillImage1.material = this.GM.GetSkillMaterial();
		this.ASExp_SkillNameText.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.Name);
		bool flag = b >= recordByKey.UpLevel;
		this.ASExp_SkillLvStr.Length = 0;
		this.ASExp_SkillLvStr.IntToFormat((long)b, 1, false);
		this.ASExp_SkillLvStr.AppendFormat(this.DM.mStringTable.GetStringByID(52u));
		this.ASExp_SkillLvText.text = this.ASExp_SkillLvStr.ToString();
		this.ASExp_SkillLvText.SetAllDirty();
		this.ASExp_SkillLvText.cachedTextGenerator.Invalidate();
		uint needSkillExp = this.GetNeedSkillExp(recordByKey.Experience, b);
		this.ASExp_SkillExpStr.Length = 0;
		if (flag)
		{
			this.ASExp_SkillExpStr.Append(this.DM.mStringTable.GetStringByID(898u));
			this.ASExp_ExpBarImage.fillAmount = 1f;
			this.ASExp_ExpSP.SetSpriteIndex(1);
		}
		else
		{
			this.ASExp_SkillExpStr.IntToFormat((long)((ulong)this.NowPet.SkillExp[this.SelectSkillIndex]), 1, true);
			this.ASExp_SkillExpStr.IntToFormat((long)((ulong)needSkillExp), 1, true);
			if (this.GM.IsArabic)
			{
				this.ASExp_SkillExpStr.AppendFormat("{1} / {0} ");
			}
			else
			{
				this.ASExp_SkillExpStr.AppendFormat("{0} / {1} ");
			}
			this.ASExp_SkillExpStr.Append(this.DM.mStringTable.GetStringByID(9u));
			double num = (needSkillExp == 0u) ? 0.0 : (this.NowPet.SkillExp[this.SelectSkillIndex] / needSkillExp);
			this.ASExp_ExpBarImage.fillAmount = (float)num;
			this.ASExp_ExpSP.SetSpriteIndex(0);
		}
		this.ASExp_SkillExpText.text = this.ASExp_SkillExpStr.ToString();
		this.ASExp_SkillExpText.SetAllDirty();
		this.ASExp_SkillExpText.cachedTextGenerator.Invalidate();
		bool flag2 = b > 0 && (int)b <= recordByKey.OpenLevel.Length && this.NowPet.Level < recordByKey.OpenLevel[(int)(b - 1)];
		if (!flag && flag2)
		{
			this.ASExp_SkillLockT.gameObject.SetActive(true);
			if (this.NowPet.SkillExp[this.SelectSkillIndex] == needSkillExp - 1u)
			{
				this.ASExp_LockSP.SetSpriteIndex(0);
			}
			else
			{
				this.ASExp_LockSP.SetSpriteIndex(1);
			}
		}
		else
		{
			this.ASExp_SkillLockT.gameObject.SetActive(false);
		}
		this.ASExp_InfoNowStr.Length = 0;
		this.PM.FormatSkillContent(recordByKey.ID, b, this.ASExp_InfoNowStr, 0);
		this.ASExp_InfoNowtext.text = this.ASExp_InfoNowStr.ToString();
		this.ASExp_InfoNowtext.SetAllDirty();
		this.ASExp_InfoNowtext.cachedTextGenerator.Invalidate();
		if (recordByKey.CoolDown == 0)
		{
			this.ASExp_InfoNowCDImage.gameObject.SetActive(false);
			this.ASExp_InfoNowCDtext.gameObject.SetActive(false);
		}
		else
		{
			this.ASExp_InfoNowCDStr.Length = 0;
			PetSkillCoolTbl recordByKey2 = this.PM.PetSkillCoolTable.GetRecordByKey(recordByKey.CoolDown);
			if (b >= 0 && (int)b <= recordByKey2.CoolBySkillLv.Length)
			{
				this.PM.FormatCoolTime(recordByKey2.CoolBySkillLv[(int)(b - 1)], this.ASExp_InfoNowCDStr, 0);
			}
			this.ASExp_InfoNowCDtext.text = this.ASExp_InfoNowCDStr.ToString();
			this.ASExp_InfoNowCDtext.SetAllDirty();
			this.ASExp_InfoNowCDtext.cachedTextGenerator.Invalidate();
			this.ASExp_InfoNowCDImage.gameObject.SetActive(true);
			this.ASExp_InfoNowCDtext.gameObject.SetActive(true);
		}
		if (flag)
		{
			this.ASExp_MaxImageT.gameObject.SetActive(true);
			this.ASExp_InfoNextTitleText.gameObject.SetActive(false);
			this.ASExp_InfoNextText.gameObject.SetActive(false);
			this.ASExp_InfoNextCDImage.gameObject.SetActive(false);
			this.ASExp_InfoNextCDText.gameObject.SetActive(false);
			this.ASExp_AddBtnT1.gameObject.SetActive(false);
			this.ASExp_AddBtnT2.gameObject.SetActive(false);
			this.ASExp_SrcHint.gameObject.SetActive(false);
			this.ASExp_StoneIconT1.gameObject.SetActive(false);
			this.ASExp_StoneIconT2.gameObject.SetActive(false);
			this.ASExp_HaveCountText1.gameObject.SetActive(false);
			this.ASExp_HaveCountText2.gameObject.SetActive(false);
			this.ASExp_SelectTextBackT.gameObject.SetActive(false);
			this.ASExp_SelectText.gameObject.SetActive(false);
		}
		else
		{
			this.ASExp_InfoNextStr.Length = 0;
			this.PM.FormatSkillContent(recordByKey.ID, b + 1, this.ASExp_InfoNextStr, 0);
			this.ASExp_InfoNextText.text = this.ASExp_InfoNextStr.ToString();
			this.ASExp_InfoNextText.SetAllDirty();
			this.ASExp_InfoNextText.cachedTextGenerator.Invalidate();
			if (recordByKey.CoolDown == 0)
			{
				this.ASExp_InfoNextCDImage.gameObject.SetActive(false);
				this.ASExp_InfoNextCDText.gameObject.SetActive(false);
			}
			else
			{
				this.ASExp_InfoNextCDStr.Length = 0;
				PetSkillCoolTbl recordByKey3 = this.PM.PetSkillCoolTable.GetRecordByKey(recordByKey.CoolDown);
				if (b > 0 && (int)b < recordByKey3.CoolBySkillLv.Length)
				{
					this.PM.FormatCoolTime(recordByKey3.CoolBySkillLv[(int)b], this.ASExp_InfoNextCDStr, 0);
				}
				this.ASExp_InfoNextCDText.text = this.ASExp_InfoNextCDStr.ToString();
				this.ASExp_InfoNextCDText.SetAllDirty();
				this.ASExp_InfoNextCDText.cachedTextGenerator.Invalidate();
				this.ASExp_InfoNextCDImage.gameObject.SetActive(true);
				this.ASExp_InfoNextCDText.gameObject.SetActive(true);
			}
			this.ASExp_MaxImageT.gameObject.SetActive(false);
			this.ASExp_InfoNextTitleText.gameObject.SetActive(true);
			this.ASExp_InfoNextText.gameObject.SetActive(true);
			this.ASExp_AddBtnT1.gameObject.SetActive(true);
			this.ASExp_AddBtnT2.gameObject.SetActive(true);
			this.ASExp_SrcHint.gameObject.SetActive(true);
			this.ASExp_StoneIconT1.gameObject.SetActive(true);
			this.ASExp_StoneIconT2.gameObject.SetActive(true);
			this.ASExp_HaveCountText1.gameObject.SetActive(true);
			this.ASExp_HaveCountText2.gameObject.SetActive(true);
			this.ASExp_SelectTextBackT.gameObject.SetActive(true);
			this.ASExp_SelectText.gameObject.SetActive(true);
		}
	}

	// Token: 0x0600164F RID: 5711 RVA: 0x00266C70 File Offset: 0x00264E70
	private void CheckAddBtnState()
	{
		if (this.NowPet == null || this.SelectSkillIndex < 0 || this.SelectSkillIndex >= 4)
		{
			return;
		}
		PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[this.SelectSkillIndex]);
		uint needSkillExp = this.GetNeedSkillExp(recordByKey.Experience, this.NowPet.SkillLv[this.SelectSkillIndex]);
		this.bCount1 = (this.PM.PetUI_UpNeedStoneCount != 0 && this.DM.GetCurItemQuantity(this.sPet.SoulID, 0) < this.PM.PetUI_UpNeedStoneCount);
		if (this.sPet.Rare >= 1 && (int)this.sPet.Rare <= this.PM.PetUI_UpNeedSoulCount.Length)
		{
			this.bCount2 = (this.PM.PetUI_UpNeedSoulCount[(int)(this.sPet.Rare - 1)] != 0 && this.DM.GetCurItemQuantity(this.ASExp_ExpItemID, 0) < this.PM.PetUI_UpNeedSoulCount[(int)(this.sPet.Rare - 1)]);
		}
		else
		{
			this.bCount2 = false;
		}
		this.bLevel = (this.NowPet.SkillLv[this.SelectSkillIndex] > 0 && (int)this.NowPet.SkillLv[this.SelectSkillIndex] <= recordByKey.OpenLevel.Length && this.NowPet.Level < recordByKey.OpenLevel[(int)(this.NowPet.SkillLv[this.SelectSkillIndex] - 1)] && this.NowPet.SkillExp[this.SelectSkillIndex] == needSkillExp - 1u);
		if (this.bLevel)
		{
			this.ASExp_AddBtn1.ForTextChange(e_BtnType.e_ChangeText);
			this.ASExp_AddBtn2.ForTextChange(e_BtnType.e_ChangeText);
		}
		else
		{
			this.ASExp_AddBtn1.ForTextChange(e_BtnType.e_Normal);
			this.ASExp_AddBtn2.ForTextChange(e_BtnType.e_Normal);
		}
		if (this.bCount1 || this.bLevel)
		{
			this.ASExp_UpText1.color = Color.red;
		}
		else
		{
			this.ASExp_UpText1.color = Color.white;
		}
		if (this.bCount2 || this.bLevel)
		{
			this.ASExp_UpText2.color = Color.red;
		}
		else
		{
			this.ASExp_UpText2.color = Color.white;
		}
		if (this.bCount1)
		{
			this.ASExp_NeedCountText1.color = Color.red;
		}
		else
		{
			this.ASExp_NeedCountText1.color = Color.white;
		}
		if (this.bCount2)
		{
			this.ASExp_NeedCountText2.color = Color.red;
		}
		else
		{
			this.ASExp_NeedCountText2.color = Color.white;
		}
	}

	// Token: 0x06001650 RID: 5712 RVA: 0x00266F4C File Offset: 0x0026514C
	private void ShowAddSkillExpPanel(int SkillIndex)
	{
		if (this.ASExp_PanelT == null)
		{
			return;
		}
		this.SelectSkillIndex = SkillIndex;
		this.SetAddSkill_Info();
		this.SetAddSkill_Item();
		this.CheckAddBtnState();
		this.ASExp_PanelT.SetParent(this.GM.m_SecWindowLayer);
		this.ASExp_PanelT.gameObject.SetActive(true);
		this.SetParticle_Show(false, false);
	}

	// Token: 0x06001651 RID: 5713 RVA: 0x00266FB4 File Offset: 0x002651B4
	private void HideAddSkillExpPanel()
	{
		if (this.ASExp_PanelT == null || this.SelectSkillIndex == -1)
		{
			return;
		}
		this.EndEffect();
		this.ASExp_AddBtn1Click.SetActive(false);
		this.ASExp_AddBtn2Click.SetActive(false);
		this.SelectSkillIndex = -1;
		this.ASExp_PanelT.gameObject.SetActive(false);
		this.ASExp_PanelT.SetParent(this.m_transform);
		this.SetParticle_Show(true, false);
	}

	// Token: 0x06001652 RID: 5714 RVA: 0x00267030 File Offset: 0x00265230
	private void SetEvoPanel()
	{
		if (this.EVO_panelT == null || this.NowPet == null)
		{
			return;
		}
		this.GM.ChangeHeroItemImg(this.EVO_StoneIconT, eHeroOrItem.Item, this.sPet.SoulID, 0, 0, 0);
		bool flag = true;
		this.EVO_UpStr.Length = 0;
		this.EVO_UpStr.IntToFormat((long)this.DM.GetCurItemQuantity(this.sPet.SoulID, 0), 1, true);
		this.EVO_UpStr.IntToFormat((long)this.PM.GetEvoNeed_Stone(this.NowPet.Enhance, this.sPet.Rare), 1, true);
		if (this.GM.IsArabic)
		{
			this.EVO_UpStr.AppendFormat("{1} / {0}");
		}
		else
		{
			this.EVO_UpStr.AppendFormat("{0} / {1}");
		}
		this.EVO_UpText.text = this.EVO_UpStr.ToString();
		this.EVO_UpText.SetAllDirty();
		this.EVO_UpText.cachedTextGenerator.Invalidate();
		if (this.CheckEvoItem())
		{
			this.EVO_UpText.color = Color.white;
		}
		else
		{
			this.EVO_UpText.color = new Color32(byte.MaxValue, 115, 131, byte.MaxValue);
			flag = false;
		}
		this.EVO_NeedStr.Length = 0;
		this.EVO_NeedStr.IntToFormat((long)this.PM.GetEvoNeed_Lv(this.NowPet.Enhance), 1, false);
		this.EVO_NeedStr.AppendFormat(this.DM.mStringTable.GetStringByID(16055u));
		this.EVO_NeedLvText.text = this.EVO_NeedStr.ToString();
		this.EVO_NeedLvText.SetAllDirty();
		this.EVO_NeedLvText.cachedTextGenerator.Invalidate();
		if (this.CheckEvoLv())
		{
			this.EVO_NeedLvText.color = Color.white;
		}
		else
		{
			this.EVO_NeedLvText.color = new Color32(byte.MaxValue, 94, 112, byte.MaxValue);
			flag = false;
		}
		this.EVO_PriceStr.Length = 0;
		this.EVO_PriceStr.IntToFormat((long)((ulong)this.DM.GetResourceExchange(PriceListType.Time, this.PM.GetEvoNeed_Time(this.NowPet.Enhance))), 1, true);
		this.EVO_PriceStr.AppendFormat("{0}");
		this.EVO_LPriceText.text = this.EVO_PriceStr.ToString();
		this.EVO_LPriceText.SetAllDirty();
		this.EVO_LPriceText.cachedTextGenerator.Invalidate();
		this.EVO_TimeStr.Length = 0;
		GameConstants.GetTimeString(this.EVO_TimeStr, this.PM.GetEvoNeed_Time(this.NowPet.Enhance), false, false, true, false, true);
		this.EVO_RTimeText.text = this.EVO_TimeStr.ToString();
		this.EVO_RTimeText.SetAllDirty();
		this.EVO_RTimeText.cachedTextGenerator.Invalidate();
		if (flag)
		{
			this.EVO_LBtnText.color = Color.white;
			this.EVO_RBtnText.color = Color.white;
		}
		else
		{
			this.EVO_LBtnText.color = Color.red;
			this.EVO_RBtnText.color = Color.red;
		}
	}

	// Token: 0x06001653 RID: 5715 RVA: 0x00267380 File Offset: 0x00265580
	private void ShowEvoPanel()
	{
		if (this.NowPet == null || this.EVO_panelT == null)
		{
			return;
		}
		this.NowEvoID = (int)this.NowPet.ID;
		this.SetEvoPanel();
		this.EVO_panelT.SetParent(this.GM.m_SecWindowLayer);
		this.EVO_panelT.gameObject.SetActive(true);
		this.SetParticle_Show(false, false);
	}

	// Token: 0x06001654 RID: 5716 RVA: 0x002673F0 File Offset: 0x002655F0
	private void HideEvoPanel()
	{
		if (this.EVO_panelT == null || this.NowEvoID == -1)
		{
			return;
		}
		this.NowEvoID = -1;
		this.EVO_panelT.gameObject.SetActive(false);
		this.EVO_panelT.SetParent(this.m_transform);
		this.SetParticle_Show(true, false);
	}

	// Token: 0x06001655 RID: 5717 RVA: 0x0026744C File Offset: 0x0026564C
	private uint GetNeedSkillExp(ushort Experience, byte Lv)
	{
		PetSkillExpTbl recordByKey = this.PM.PetSkillExpTable.GetRecordByKey(Experience);
		if (Lv >= 1 && (int)Lv <= recordByKey.ExpValue.Length)
		{
			return recordByKey.ExpValue[(int)(Lv - 1)];
		}
		return 0u;
	}

	// Token: 0x06001656 RID: 5718 RVA: 0x00267490 File Offset: 0x00265690
	private byte GetMaxLv(byte Enhance)
	{
		if (Enhance == 0)
		{
			return 20;
		}
		if (Enhance == 1)
		{
			return 50;
		}
		return 60;
	}

	// Token: 0x06001657 RID: 5719 RVA: 0x002674A8 File Offset: 0x002656A8
	private bool CheckMaxLv()
	{
		return this.NowPet != null && this.NowPet.Level == this.GetMaxLv(this.NowPet.Enhance);
	}

	// Token: 0x06001658 RID: 5720 RVA: 0x002674DC File Offset: 0x002656DC
	private bool CheckEvoItem()
	{
		if (this.NowPet != null)
		{
			ushort curItemQuantity = this.DM.GetCurItemQuantity(this.sPet.SoulID, 0);
			ushort evoNeed_Stone = this.PM.GetEvoNeed_Stone(this.NowPet.Enhance, this.sPet.Rare);
			if (evoNeed_Stone != 0 && curItemQuantity >= evoNeed_Stone)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001659 RID: 5721 RVA: 0x00267540 File Offset: 0x00265740
	private bool CheckEvoLv()
	{
		if (this.NowPet != null)
		{
			byte evoNeed_Lv = this.PM.GetEvoNeed_Lv(this.NowPet.Enhance);
			if (evoNeed_Lv != 0 && this.NowPet.Level >= this.PM.GetEvoNeed_Lv(this.NowPet.Enhance))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600165A RID: 5722 RVA: 0x002675A0 File Offset: 0x002657A0
	private void CheckShowLRBtn()
	{
		if (this.Left_T == null || this.Right_T == null)
		{
			return;
		}
		if (this.bMaxShow || this.PM.PetDataCount <= 1)
		{
			this.Left_T.gameObject.SetActive(false);
			this.Right_T.gameObject.SetActive(false);
		}
		else
		{
			this.Left_T.gameObject.SetActive(true);
			this.Right_T.gameObject.SetActive(true);
		}
	}

	// Token: 0x0600165B RID: 5723 RVA: 0x00267638 File Offset: 0x00265838
	private void SetEffect(eUIPet_Eff EffectKind)
	{
		if (this.NowPet == null || this.SelectSkillIndex < 0 || this.SelectSkillIndex >= 4)
		{
			return;
		}
		if (this.ASExp_EffectKind != EffectKind)
		{
			this.ASExp_EffectKind = EffectKind;
			PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[this.SelectSkillIndex]);
			if (this.ASExp_EffectKind == eUIPet_Eff.eEff_ExpAdd)
			{
				this.ASExp_EffDTime = 0f;
				this.ASExp_EffTatalTime = 1.06f;
				this.ASExp_EffIconBlockImage.gameObject.SetActive(true);
				this.ASExp_EffIconMoveImage.gameObject.SetActive(true);
				this.ASExp_EffBarBlockImage.gameObject.SetActive(true);
				if (this.ASExp_EffbLVUp)
				{
					this.ASExp_EffBarInnerImage.gameObject.SetActive(true);
				}
				this.ASExp_EffExpBackImage.gameObject.SetActive(true);
				this.ASExp_EffExpBackImage.rectTransform.sizeDelta = new Vector2(335f, 100f);
				this.ASExp_EffExpBackImage.rectTransform.anchoredPosition = new Vector2(6.5f, -20f);
				this.ASExp_EffExpStr.Length = 0;
				this.ASExp_EffExpStr.IntToFormat((long)((ulong)this.PM.PetUI_GetExp), 1, true);
				if (this.GM.IsArabic)
				{
					this.ASExp_EffExpStr.AppendFormat("Exp {0}+");
				}
				else
				{
					this.ASExp_EffExpStr.AppendFormat("Exp+{0}");
				}
				this.ASExp_EffExpText.text = this.ASExp_EffExpStr.ToString();
				this.ASExp_EffExpText.gameObject.SetActive(true);
				if (this.ASExp_EffbLVUp)
				{
					this.ImageFAFrom = this.ASExp_ExpBarImage.fillAmount;
					this.ImageFATo = 1f;
					this.ImageExpNeed = this.GetNeedSkillExp(recordByKey.Experience, this.PM.PetUI_OldLV);
				}
				else
				{
					this.ImageFAFrom = this.ASExp_ExpBarImage.fillAmount;
					this.ImageExpNeed = this.GetNeedSkillExp(recordByKey.Experience, this.PM.PetUI_OldLV);
					double num = (this.ImageExpNeed == 0u) ? 0.0 : (this.NowPet.SkillExp[this.SelectSkillIndex] / this.ImageExpNeed);
					this.ImageFATo = (float)num;
				}
			}
			else if (this.ASExp_EffectKind == eUIPet_Eff.eEff_ExpX2)
			{
				this.ASExp_EffDTime = 0f;
				this.ASExp_EffTatalTime = 1.6f;
				this.ASExp_EffIconBlockImage.gameObject.SetActive(true);
				this.ASExp_EffIconMoveImage.gameObject.SetActive(true);
				this.ASExp_EffBarBlockImage.gameObject.SetActive(true);
				this.ASExp_EffBarInnerImage.gameObject.SetActive(true);
				this.ASExp_EffExpBackImage.gameObject.SetActive(true);
				this.ASExp_EffExpBackImage.rectTransform.sizeDelta = new Vector2(335f, 185f);
				this.ASExp_EffExpBackImage.rectTransform.anchoredPosition = new Vector2(6.5f, 29.5f);
				this.ASExp_EffExpStr.Length = 0;
				this.ASExp_EffExpStr.IntToFormat((long)((ulong)this.PM.PetUI_GetExp), 1, true);
				if (this.GM.IsArabic)
				{
					this.ASExp_EffExpStr.AppendFormat("Exp {0}+");
				}
				else
				{
					this.ASExp_EffExpStr.AppendFormat("Exp+{0}");
				}
				this.ASExp_EffExpText.text = this.ASExp_EffExpStr.ToString();
				this.ASExp_EffExpText.gameObject.SetActive(true);
				this.ASExp_EffX2Str.Length = 0;
				this.ASExp_EffX2Str.IntToFormat((long)(this.PM.PetUI_GetRate / 1000), 1, true);
				if (this.GM.IsArabic)
				{
					this.ASExp_EffX2Str.AppendFormat("{0}x");
				}
				else
				{
					this.ASExp_EffX2Str.AppendFormat("x{0}");
				}
				this.ASExp_EffX2Text.text = this.ASExp_EffX2Str.ToString();
				this.ASExp_EffX2Text.gameObject.SetActive(true);
				if (this.ASExp_EffbLVUp)
				{
					this.ImageFAFrom = this.ASExp_ExpBarImage.fillAmount;
					this.ImageFATo = 1f;
					this.ImageExpNeed = this.GetNeedSkillExp(recordByKey.Experience, this.PM.PetUI_OldLV);
				}
				else
				{
					this.ImageFAFrom = this.ASExp_ExpBarImage.fillAmount;
					this.ImageExpNeed = this.GetNeedSkillExp(recordByKey.Experience, this.PM.PetUI_OldLV);
					double num2 = (this.ImageExpNeed == 0u) ? 0.0 : (this.NowPet.SkillExp[this.SelectSkillIndex] / this.ImageExpNeed);
					this.ImageFATo = (float)num2;
				}
			}
			this.SetEffAll();
		}
	}

	// Token: 0x0600165C RID: 5724 RVA: 0x00267B1C File Offset: 0x00265D1C
	private bool EndEffect()
	{
		if (this.ASExp_EffectKind == eUIPet_Eff.eEff_None)
		{
			return false;
		}
		bool result = false;
		this.ASExp_bPlaySound = false;
		this.DeSpawnParticle_X2();
		this.ASExp_AddBtn1Click.SetActive(false);
		this.ASExp_AddBtn2Click.SetActive(false);
		this.ASExp_EffectKind = eUIPet_Eff.eEff_None;
		this.ASExp_EffIconBlockImage.gameObject.SetActive(false);
		this.ASExp_EffIconMoveImage.gameObject.SetActive(false);
		this.ASExp_EffBarBlockImage.gameObject.SetActive(false);
		this.ASExp_EffBarInnerImage.gameObject.SetActive(false);
		this.ASExp_EffExpBackImage.gameObject.SetActive(false);
		this.ASExp_EffExpText.gameObject.SetActive(false);
		this.ASExp_EffX2Text.gameObject.SetActive(false);
		this.ASExp_ExpBar.rectTransform.localScale = Vector3.one;
		if (this.GM.IsArabic)
		{
			this.ASExp_SkillExpText.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		else
		{
			this.ASExp_SkillExpText.rectTransform.localScale = Vector3.one;
		}
		this.ASExp_EffBarBlockImage.rectTransform.localScale = Vector3.one;
		if (this.ASExp_EffbLVUp)
		{
			this.ASExp_EffbLVUp = false;
			this.PM.OpenPetLevelUp(this.NowPet.ID, this.PM.PetUI_OldLV, this.NowPet.SkillLv[this.SelectSkillIndex], this.PM.PetUI_OldExp, this.NowPet.SkillExp[this.SelectSkillIndex], 1, this.sPet.PetSkill[this.SelectSkillIndex]);
			result = true;
		}
		this.SetSkill();
		this.SetAddSkill_Item();
		this.SetAddSkill_Info();
		this.CheckAddBtnState();
		return result;
	}

	// Token: 0x0600165D RID: 5725 RVA: 0x00267CE4 File Offset: 0x00265EE4
	private void SetEffAll()
	{
		if (this.ASExp_EffectKind == eUIPet_Eff.eEff_ExpAdd)
		{
			this.UpDateImageAlpha(this.ASExp_EffIconMoveImage, this.IconMove_AlphaKey, this.IconMove_AlphaValue);
			this.UpDateImagePos(this.ASExp_EffIconMoveImage, this.IconMove_PosKey, this.IconMove_PosValue, this.IconMove_OriginalPos);
			this.UpDateImageAlpha(this.ASExp_EffIconBlockImage, this.IconBlock_AlphaKey, this.IconBlock_AlphaValue);
			this.UpDateImageScale(this.ASExp_EffIconBlockImage, this.IconBlock_ScaleKey, this.IconBlock_ScaleValue);
			this.UpDateImageAlpha(this.ASExp_EffExpBackImage, this.ExpText_AlphaKey, this.ExpText_AlphaValue);
			if (this.ASExp_EffbLVUp)
			{
				this.UpDateImageAlpha(this.ASExp_EffBarBlockImage, this.BarBlockImageAlphaKey_Up, this.BarBlockImageAlphaValue_Up);
				this.UpDateImageScale(this.ASExp_EffBarBlockImage, this.BarBlockImageScaleKey_Up, this.BarBlockImageScaleValue_Up);
				this.UpDateImageAlpha(this.ASExp_EffBarInnerImage, this.BarInnerImageAlphaKey, this.BarInnerImageAlphaValue);
				this.UpDateImageScale(this.ASExp_EffBarInnerImage, this.BarInnerImageScaleKey, this.BarInnerImageScaleValue);
			}
			else
			{
				this.UpDateImageAlpha(this.ASExp_EffBarBlockImage, this.BarBlockImageAlphaKey, this.BarBlockImageAlphaValue);
			}
			this.UpDateTextAlpha(this.ASExp_EffExpText, this.ExpText_AlphaKey, this.ExpText_AlphaValue);
			this.UpDateTextScale(this.ASExp_EffExpText, this.ExpText_ScaleKey, this.ExpText_ScaleValue);
			this.UpDateTextPos(this.ASExp_EffExpText, this.ExpText_PositionKey, this.ExpText_PositionValue, this.ExpText_OriginalPos);
			this.UpDateImageFillAmount(this.ASExp_ExpBarImage, this.ExpBarFA_ScaleKey);
			if (!this.ASExp_bPlaySound && this.ASExp_EffDTime >= 0.3f)
			{
				this.ASExp_bPlaySound = true;
				AudioManager.Instance.PlayUISFX(UIKind.PetAddExp);
			}
		}
		else if (this.ASExp_EffectKind == eUIPet_Eff.eEff_ExpX2)
		{
			this.UpDateImageAlpha(this.ASExp_EffIconMoveImage, this.IconMove_AlphaKey, this.IconMove_AlphaValue);
			this.UpDateImagePos(this.ASExp_EffIconMoveImage, this.IconMove_PosKey, this.IconMove_PosValue, this.IconMove_OriginalPos);
			this.UpDateImageAlpha(this.ASExp_EffIconBlockImage, this.IconBlock_AlphaKey, this.IconBlock_AlphaValue);
			this.UpDateImageScale(this.ASExp_EffIconBlockImage, this.IconBlock_ScaleKey, this.IconBlock_ScaleValue);
			this.UpDateImageAlpha(this.ASExp_EffExpBackImage, this.X2Text_AlphaKey, this.X2Text_AlphaValue);
			this.UpDateTextAlpha(this.ASExp_EffExpText, this.ExpTextX2_AlphaKey, this.ExpTextX2_AlphaValue);
			this.UpDateTextScale(this.ASExp_EffExpText, this.ExpTextX2_ScaleKey, this.ExpTextX2_ScaleValue);
			this.UpDateTextPos(this.ASExp_EffExpText, this.ExpTextX2_PositionKey, this.ExpTextX2_PositionValue, this.ExpText_OriginalPos);
			this.UpDateTextAlpha(this.ASExp_EffX2Text, this.X2Text_AlphaKey, this.X2Text_AlphaValue);
			this.UpDateTextScale(this.ASExp_EffX2Text, this.X2Text_ScaleKey, this.X2Text_ScaleValue);
			this.UpDateImageScale(this.ASExp_ExpBar, this.ExpBar_ScaleKey, this.ExpBar_ScaleValue);
			this.UpDateTextAlpha(this.ASExp_SkillExpText, this.ExpBarText_AlphaKey, this.ExpBarText_AlphaValue);
			this.UpDateTextScale(this.ASExp_SkillExpText, this.ExpBarText_ScaleKey, this.ExpBarText_ScaleValue);
			this.UpDateImageAlpha(this.ASExp_EffBarBlockImage, this.BarBlockImageX2AlphaKey, this.BarBlockImageX2AlphaValue);
			this.UpDateImageScale(this.ASExp_EffBarBlockImage, this.BarBlockImageX2ScaleKey, this.BarBlockImageX2ScaleValue);
			this.UpDateImageAlpha(this.ASExp_EffBarInnerImage, this.BarInnerImageX2AlphaKey, this.BarInnerImageX2AlphaValue);
			this.UpDateImageScale(this.ASExp_EffBarInnerImage, this.BarInnerImageX2ScaleKey, this.BarInnerImageX2ScaleValue);
			this.UpDateImageFillAmount(this.ASExp_ExpBarImage, this.ExpBarFA_ScaleKey);
			if (this.ASExp_EffDTime >= 0.5f)
			{
				this.SpawnParticle_X2();
			}
			if (!this.ASExp_bPlaySound && this.ASExp_EffDTime >= 0.5f)
			{
				this.ASExp_bPlaySound = true;
				AudioManager.Instance.PlayUISFX(UIKind.PetAddExpX2);
			}
		}
	}

	// Token: 0x0600165E RID: 5726 RVA: 0x002680A4 File Offset: 0x002662A4
	private void OpenSrcHint(byte Kind)
	{
		if (this.NowPet == null)
		{
			return;
		}
		UIButtonHint hint = null;
		if (Kind == 1)
		{
			hint = this.EVO_SrcHint;
		}
		else if (Kind == 2)
		{
			hint = this.ASExp_SrcHint;
		}
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.sPet.SoulID);
		CString cstring = StringManager.Instance.StaticString1024();
		if (recordByKey.SyntheticParts[3].SyntheticItem == 65535)
		{
			cstring.Append(this.DM.mStringTable.GetStringByID(16089u));
		}
		else
		{
			cstring.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.SyntheticParts[3].SyntheticItem));
			cstring.AppendFormat(this.DM.mStringTable.GetStringByID(16090u));
		}
		this.GM.m_Hint.Show(hint, UIHintStyle.eHintSimple, 0, 305f, 20, cstring, Vector2.zero);
	}

	// Token: 0x0600165F RID: 5727 RVA: 0x002681A8 File Offset: 0x002663A8
	private void CheckUpgradeSkill(byte Kind)
	{
		if (this.NowPet == null || this.SelectSkillIndex < 0 || this.SelectSkillIndex >= 4)
		{
			return;
		}
		bool flag = false;
		PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[this.SelectSkillIndex]);
		byte b = this.NowPet.SkillLv[this.SelectSkillIndex];
		byte b2 = b;
		uint num = this.NowPet.SkillExp[this.SelectSkillIndex] + this.PM.PetUI_BaseExp;
		byte b3 = 0;
		for (;;)
		{
			uint needSkillExp = this.GetNeedSkillExp(recordByKey.Experience, b2);
			if (num < needSkillExp)
			{
				goto IL_F2;
			}
			if (b2 >= recordByKey.UpLevel || b2 == 0 || (int)b2 > recordByKey.OpenLevel.Length || recordByKey.OpenLevel[(int)(b2 - 1)] > this.NowPet.Level)
			{
				break;
			}
			num -= needSkillExp;
			b2 += 1;
			b3 += 1;
			if (b3 > 15)
			{
				goto Block_7;
			}
		}
		flag = true;
		IL_F2:
		Block_7:
		if (flag)
		{
			this.GM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(685u), this.DM.mStringTable.GetStringByID(12139u), 4, (int)Kind, null, null);
		}
		else
		{
			this.SendUpgradeSkill(Kind);
		}
	}

	// Token: 0x06001660 RID: 5728 RVA: 0x00268314 File Offset: 0x00266514
	private void SendUpgradeSkill(byte Kind)
	{
		this.PM.Send_PETSKILL_UPGRADESKILL(this.NowPet.ID, (byte)this.SelectSkillIndex, Kind);
	}

	// Token: 0x06001661 RID: 5729 RVA: 0x00268334 File Offset: 0x00266534
	private void ShowSkillUpbLevel()
	{
		if (this.NowPet == null)
		{
			return;
		}
		if (this.NowPet.CheckState(PetManager.EPetState.Evolution))
		{
			this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12142u), 35, true);
		}
		else if (this.NowPet.CheckState(PetManager.EPetState.LockLimit))
		{
			GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(16082u), this.DM.mStringTable.GetStringByID(16069u), this.DM.mStringTable.GetStringByID(156u), this, 5, (int)this.NowPet.ID, true, false, false, false, false);
		}
		else
		{
			GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(12143u), this.DM.mStringTable.GetStringByID(12144u), this.DM.mStringTable.GetStringByID(156u), this, 6, (int)this.NowPet.ID, true, false, false, false, false);
		}
	}

	// Token: 0x06001662 RID: 5730 RVA: 0x00268454 File Offset: 0x00266654
	private void UpDateImageAlpha(Image tmpImg, float[] Key, float[] Value)
	{
		if (tmpImg == null || Key == null || Value == null)
		{
			return;
		}
		if (Key.Length != Value.Length)
		{
			return;
		}
		int num = Key.Length - 1;
		float a = 0f;
		if (this.ASExp_EffDTime >= Key[num])
		{
			a = Value[num];
		}
		else if (this.ASExp_EffDTime < Key[0])
		{
			a = Value[0];
		}
		else
		{
			for (int i = 0; i < num; i++)
			{
				if (this.ASExp_EffDTime >= Key[i] && this.ASExp_EffDTime < Key[i + 1])
				{
					a = Mathf.Lerp(Value[i], Value[i + 1], (this.ASExp_EffDTime - Key[i]) / (Key[i + 1] - Key[i]));
					break;
				}
			}
		}
		tmpImg.color = new Color(tmpImg.color.r, tmpImg.color.g, tmpImg.color.b, a);
	}

	// Token: 0x06001663 RID: 5731 RVA: 0x00268550 File Offset: 0x00266750
	private void UpDateImageScale(Image tmpImg, float[] Key, Vector2[] Value)
	{
		if (tmpImg == null || Key == null || Value == null)
		{
			return;
		}
		if (Key.Length != Value.Length)
		{
			return;
		}
		int num = Key.Length - 1;
		Vector2 v = Vector2.one;
		if (this.ASExp_EffDTime >= Key[num])
		{
			v = Value[num];
		}
		else if (this.ASExp_EffDTime < Key[0])
		{
			v = Value[0];
		}
		else
		{
			for (int i = 0; i < num; i++)
			{
				if (this.ASExp_EffDTime >= Key[i] && this.ASExp_EffDTime < Key[i + 1])
				{
					float t = (this.ASExp_EffDTime - Key[i]) / (Key[i + 1] - Key[i]);
					v.x = Mathf.Lerp(Value[i].x, Value[i + 1].x, t);
					v.y = Mathf.Lerp(Value[i].y, Value[i + 1].y, t);
					break;
				}
			}
		}
		tmpImg.rectTransform.localScale = v;
	}

	// Token: 0x06001664 RID: 5732 RVA: 0x00268678 File Offset: 0x00266878
	private void UpDateImagePos(Image tmpImg, float[] Key, Vector2[] Value, Vector2 originalPos)
	{
		if (tmpImg == null || Key == null || Value == null)
		{
			return;
		}
		if (Key.Length != Value.Length)
		{
			return;
		}
		int num = Key.Length - 1;
		Vector2 b = Vector2.one;
		if (this.ASExp_EffDTime >= Key[num])
		{
			b = Value[num];
		}
		else if (this.ASExp_EffDTime < Key[0])
		{
			b = Value[0];
		}
		else
		{
			for (int i = 0; i < num; i++)
			{
				if (this.ASExp_EffDTime >= Key[i] && this.ASExp_EffDTime < Key[i + 1])
				{
					float t = (this.ASExp_EffDTime - Key[i]) / (Key[i + 1] - Key[i]);
					b.x = Mathf.Lerp(Value[i].x, Value[i + 1].x, t);
					b.y = Mathf.Lerp(Value[i].y, Value[i + 1].y, t);
					break;
				}
			}
		}
		tmpImg.rectTransform.anchoredPosition = originalPos + b;
	}

	// Token: 0x06001665 RID: 5733 RVA: 0x002687A4 File Offset: 0x002669A4
	private void UpDateTextAlpha(UIText tmpText, float[] Key, float[] Value)
	{
		if (tmpText == null || Key == null || Value == null)
		{
			return;
		}
		if (Key.Length != Value.Length)
		{
			return;
		}
		int num = Key.Length - 1;
		float a = 0f;
		if (this.ASExp_EffDTime >= Key[num])
		{
			a = Value[num];
		}
		else if (this.ASExp_EffDTime < Key[0])
		{
			a = Value[0];
		}
		else
		{
			for (int i = 0; i < num; i++)
			{
				if (this.ASExp_EffDTime >= Key[i] && this.ASExp_EffDTime < Key[i + 1])
				{
					a = Mathf.Lerp(Value[i], Value[i + 1], (this.ASExp_EffDTime - Key[i]) / (Key[i + 1] - Key[i]));
					break;
				}
			}
		}
		tmpText.color = new Color(tmpText.color.r, tmpText.color.g, tmpText.color.b, a);
	}

	// Token: 0x06001666 RID: 5734 RVA: 0x002688A0 File Offset: 0x00266AA0
	private void UpDateTextScale(UIText tmpText, float[] Key, Vector2[] Value)
	{
		if (tmpText == null || Key == null || Value == null)
		{
			return;
		}
		if (Key.Length != Value.Length)
		{
			return;
		}
		int num = Key.Length - 1;
		Vector2 v = Vector2.one;
		if (this.ASExp_EffDTime >= Key[num])
		{
			v = Value[num];
		}
		else if (this.ASExp_EffDTime < Key[0])
		{
			v = Value[0];
		}
		else
		{
			for (int i = 0; i < num; i++)
			{
				if (this.ASExp_EffDTime >= Key[i] && this.ASExp_EffDTime < Key[i + 1])
				{
					float t = (this.ASExp_EffDTime - Key[i]) / (Key[i + 1] - Key[i]);
					v.x = Mathf.Lerp(Value[i].x, Value[i + 1].x, t);
					v.y = Mathf.Lerp(Value[i].y, Value[i + 1].y, t);
					break;
				}
			}
		}
		if (this.GM.IsArabic)
		{
			tmpText.rectTransform.localScale = new Vector2(-v.x, v.y);
		}
		else
		{
			tmpText.rectTransform.localScale = v;
		}
	}

	// Token: 0x06001667 RID: 5735 RVA: 0x00268A00 File Offset: 0x00266C00
	private void UpDateTextPos(UIText tmpText, float[] Key, Vector2[] Value, Vector2 originalPos)
	{
		if (tmpText == null || Key == null || Value == null)
		{
			return;
		}
		if (Key.Length != Value.Length)
		{
			return;
		}
		int num = Key.Length - 1;
		Vector2 b = Vector2.one;
		if (this.ASExp_EffDTime >= Key[num])
		{
			b = Value[num];
		}
		else if (this.ASExp_EffDTime < Key[0])
		{
			b = Value[0];
		}
		else
		{
			for (int i = 0; i < num; i++)
			{
				if (this.ASExp_EffDTime >= Key[i] && this.ASExp_EffDTime < Key[i + 1])
				{
					float t = (this.ASExp_EffDTime - Key[i]) / (Key[i + 1] - Key[i]);
					b.x = Mathf.Lerp(Value[i].x, Value[i + 1].x, t);
					b.y = Mathf.Lerp(Value[i].y, Value[i + 1].y, t);
					break;
				}
			}
		}
		tmpText.rectTransform.anchoredPosition = originalPos + b;
	}

	// Token: 0x06001668 RID: 5736 RVA: 0x00268B2C File Offset: 0x00266D2C
	private void UpDateImageFillAmount(Image tmpImg, float[] Key)
	{
		if (tmpImg == null || Key == null)
		{
			return;
		}
		int num = Key.Length - 1;
		float num2 = this.ImageFAFrom;
		if (this.ASExp_EffDTime >= Key[num])
		{
			num2 = this.ImageFATo;
		}
		else if (this.ASExp_EffDTime < Key[0])
		{
			num2 = this.ImageFAFrom;
		}
		else
		{
			for (int i = 0; i < num; i++)
			{
				if (this.ASExp_EffDTime >= Key[i] && this.ASExp_EffDTime < Key[i + 1])
				{
					num2 = Mathf.Lerp(this.ImageFAFrom, this.ImageFATo, (this.ASExp_EffDTime - Key[i]) / (Key[i + 1] - Key[i]));
					break;
				}
			}
		}
		this.ASExp_SkillExpStr.Length = 0;
		long num3;
		if (this.ASExp_EffbLVUp)
		{
			num3 = ((this.ASExp_EffDTime < Key[num]) ? ((long)(num2 * this.ImageExpNeed)) : ((long)((ulong)this.ImageExpNeed)));
		}
		else
		{
			num3 = ((this.ASExp_EffDTime < Key[num]) ? ((long)(num2 * this.ImageExpNeed)) : ((long)((ulong)this.NowPet.SkillExp[this.SelectSkillIndex])));
		}
		this.ASExp_SkillExpStr.IntToFormat((num3 >= (long)((ulong)this.PM.PetUI_OldExp)) ? num3 : ((long)((ulong)this.PM.PetUI_OldExp)), 1, true);
		this.ASExp_SkillExpStr.IntToFormat((long)((ulong)this.ImageExpNeed), 1, true);
		if (this.GM.IsArabic)
		{
			this.ASExp_SkillExpStr.AppendFormat("{1} / {0} ");
		}
		else
		{
			this.ASExp_SkillExpStr.AppendFormat("{0} / {1} ");
		}
		this.ASExp_SkillExpStr.Append(this.DM.mStringTable.GetStringByID(9u));
		this.ASExp_SkillExpText.text = this.ASExp_SkillExpStr.ToString();
		this.ASExp_SkillExpText.SetAllDirty();
		this.ASExp_SkillExpText.cachedTextGenerator.Invalidate();
		tmpImg.fillAmount = num2;
	}

	// Token: 0x06001669 RID: 5737 RVA: 0x00268D30 File Offset: 0x00266F30
	private void Update()
	{
		if (!this.bABInitial && this.AR != null && this.AR.isDone)
		{
			this.PetGO = ModelLoader.Instance.Load(this.sHero.Modle, this.AB, (ushort)this.sHero.TextureNo);
			this.PetGO.transform.SetParent(this.PetPosRT, false);
			Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
			localRotation.eulerAngles = new Vector3(0f, (float)this.sHero.Camera_Horizontal, 0f);
			this.PetGO.transform.localRotation = localRotation;
			if (!this.bMaxShow && (int)this.NowPet.Enhance < this.sPet.PetRatio.Length)
			{
				this.PetGO.transform.localScale = new Vector3((float)this.sPet.PetRatio[(int)this.NowPet.Enhance].Ratio, (float)this.sPet.PetRatio[(int)this.NowPet.Enhance].Ratio, (float)this.sPet.PetRatio[(int)this.NowPet.Enhance].Ratio);
			}
			else
			{
				this.PetGO.transform.localScale = new Vector3((float)this.sPet.PetRatio[2].Ratio, (float)this.sPet.PetRatio[2].Ratio, (float)this.sPet.PetRatio[2].Ratio);
			}
			this.PetGO.transform.localPosition = Vector3.zero;
			this.GM.SetLayer(this.PetGO, 5);
			if (!this.bMaxShow && (int)this.NowPet.Enhance < this.sPet.PetRatio.Length)
			{
				this.PetPosRT.anchoredPosition = new Vector2(this.PetPosRT.anchoredPosition.x, (float)(-180 - (int)(1000 - this.sPet.PetRatio[(int)this.NowPet.Enhance].UpDownDist)));
			}
			else
			{
				this.PetPosRT.anchoredPosition = new Vector2(this.PetPosRT.anchoredPosition.x, (float)(-180 - (int)(1000 - this.sPet.PetRatio[2].UpDownDist)));
			}
			this.PetModel = this.PetPosRT.GetChild(0).GetComponent<Transform>();
			if (this.PetModel != null)
			{
				this.tmpAN = this.PetModel.GetComponent<Animation>();
				this.tmpAN.wrapMode = WrapMode.Loop;
				this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
				this.tmpAN.Play(this.mPetAct[0]);
				this.tmpAN.clip = this.tmpAN.GetClip(this.mPetAct[0]);
				if (this.PetPosRT.gameObject.activeSelf)
				{
					SkinnedMeshRenderer componentInChildren = this.PetModel.GetComponentInChildren<SkinnedMeshRenderer>();
					componentInChildren.useLightProbes = false;
					componentInChildren.updateWhenOffscreen = true;
				}
			}
			this.bABInitial = true;
			this.SpawnParticle_Body();
			this.SpawnParticle_Up();
		}
		if (this.bABInitial && this.PetModel != null)
		{
			if ((!this.tmpAN.IsPlaying(this.PetAct) || this.PetAct == "idle") && (double)this.ActionTimeRandom < 0.0001)
			{
				this.ActionTimeRandom = (float)UnityEngine.Random.Range(3, 7);
				this.ActionTime = 0f;
				this.HideEmoji();
			}
			if ((double)this.ActionTimeRandom > 0.0001)
			{
				this.ActionTime += Time.smoothDeltaTime;
				if (this.ActionTime >= this.ActionTimeRandom)
				{
					this.HeroActionChang(false);
				}
			}
			if (this.MovingTimer > 0f)
			{
				this.MovingTimer -= Time.deltaTime;
				if (this.MovingTimer <= 0f)
				{
					this.tmpAN.CrossFade("idle");
					this.PetAct = "idle";
				}
			}
		}
		if (!this.bMaxShow && this.Left_T != null && this.Right_T != null && (this.Left_T.gameObject.activeInHierarchy || this.Right_T.gameObject.activeInHierarchy))
		{
			this.MoveX += Time.smoothDeltaTime * 40f;
			if (this.MoveX >= 40f)
			{
				this.MoveX = 0f;
			}
			float num = (this.MoveX <= 20f) ? this.MoveX : (40f - this.MoveX);
			if (num < 0f)
			{
				num = 0f;
			}
			this.BtnPos.Set(this.LeftPosX - num, this.Left_T.localPosition.y, this.Left_T.localPosition.z);
			this.Left_T.localPosition = this.BtnPos;
			this.BtnPos.Set(this.RightPosX + num, this.Right_T.localPosition.y, this.Right_T.localPosition.z);
			this.Right_T.localPosition = this.BtnPos;
		}
		if (this.SelectSkillIndex != -1 && this.ASExp_MaxRImageT != null)
		{
			this.ASExp_MaxRImageT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		if (this.PanelRLightT != null)
		{
			this.PanelRLightT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		if (this.EmijiShowCountTime >= 0f && this.EmojiRC != null)
		{
			this.EmijiShowCountTime += Time.smoothDeltaTime;
			if (this.EmijiShowCountTime > this.EmijiShowTime1 + this.EmijiShowTime2)
			{
				this.EndEmojiMove();
			}
			else
			{
				float num2 = 0f;
				if (this.EmijiShowCountTime <= this.EmijiShowTime1)
				{
					num2 = Mathf.Lerp(0f, this.EmojiShowMaxScale, this.EmijiShowCountTime / this.EmijiShowTime1);
				}
				else if (this.EmijiShowCountTime > this.EmijiShowTime1)
				{
					num2 = Mathf.Lerp(this.EmojiShowMaxScale, 1f, 1f - (this.EmijiShowCountTime - this.EmijiShowTime1) / this.EmijiShowTime2);
				}
				this.EmojiRC.localScale = new Vector3(num2, num2, num2);
			}
		}
		if (this.ClickAddSkillTime >= 0f)
		{
			this.ClickAddSkillTime += Time.deltaTime;
			if (this.ClickAddSkillTime >= 0.3f)
			{
				this.ClickAddSkillTime = -1f;
			}
		}
		if (this.ASExp_EffectKind != eUIPet_Eff.eEff_None)
		{
			this.ASExp_EffDTime += Time.deltaTime;
			if (this.ASExp_EffDTime >= this.ASExp_EffTatalTime)
			{
				this.EndEffect();
			}
			else
			{
				this.SetEffAll();
			}
		}
		if (this.bMaxShow && this.MaxShowBack != null && this.MaxShowText != null)
		{
			this.MaxShowFalshTime += Time.smoothDeltaTime;
			if (this.MaxShowFalshTime >= 0f)
			{
				if (this.MaxShowFalshTime >= 3.1f)
				{
					this.MaxShowFalshTime = 0f;
				}
				float num3 = 1f;
				if (this.MaxShowFalshTime > 0.5f)
				{
					num3 = ((this.MaxShowFalshTime <= 1.8f) ? (0.25f + (1.3f - (this.MaxShowFalshTime - 0.5f)) / 1.3f * 0.75f) : (0.25f + (this.MaxShowFalshTime - 0.5f - 1.3f) / 1.3f * 0.75f));
				}
				num3 = Mathf.Clamp(num3, 0.25f, 1f);
				this.MaxShowBack.color = new Color(1f, 1f, 0.518f, num3);
				this.MaxShowText.color = new Color(1f, 1f, 0.518f, num3);
			}
		}
	}

	// Token: 0x0600166A RID: 5738 RVA: 0x00269610 File Offset: 0x00267810
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
			if (!this.bMaxShow)
			{
				this.PM.SortPetData();
				this.SetParticle_Show(true, false);
			}
			this.CheckShowLRBtn();
			break;
		case NetworkNews.Fallout:
			if (!this.bMaxShow)
			{
				this.SetParticle_Show(false, false);
			}
			break;
		default:
			if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
			{
				if (networkNews == NetworkNews.Refresh_Pet)
				{
					if (!this.bMaxShow && this.PM.PetUI_PetSortIndex >= 0 && this.PM.PetUI_PetSortIndex < (int)this.PM.PetDataCount)
					{
						PetData petData = this.PM.GetPetData((int)this.PM.sortPetData[this.PM.PetUI_PetSortIndex]);
						if (petData == null || (int)petData.ID != this.PM.PetUI_PetID)
						{
							this.PM.CheckPetSortIndexAndSort();
							this.SetNowPet();
						}
						else
						{
							this.SetBlood();
							this.SetPetInfo();
							this.SetSkill();
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < 3; i++)
				{
					if (this.SkillNameText[i] != null && this.SkillNameText[i].enabled)
					{
						this.SkillNameText[i].enabled = false;
						this.SkillNameText[i].enabled = true;
					}
					if (this.SkillExpText[i] != null && this.SkillExpText[i].enabled)
					{
						this.SkillExpText[i].enabled = false;
						this.SkillExpText[i].enabled = true;
					}
					if (this.SkillLockText[i] != null && this.SkillLockText[i].enabled)
					{
						this.SkillLockText[i].enabled = false;
						this.SkillLockText[i].enabled = true;
					}
				}
				if (this.PetNameText != null && this.PetNameText.enabled)
				{
					this.PetNameText.enabled = false;
					this.PetNameText.enabled = true;
				}
				if (this.ExpText != null && this.ExpText.enabled)
				{
					this.ExpText.enabled = false;
					this.ExpText.enabled = true;
				}
				if (this.StoneText != null && this.StoneText.enabled)
				{
					this.StoneText.enabled = false;
					this.StoneText.enabled = true;
				}
				if (this.LevelText_L != null && this.LevelText_L.enabled)
				{
					this.LevelText_L.enabled = false;
					this.LevelText_L.enabled = true;
				}
				if (this.RareText != null && this.RareText.enabled)
				{
					this.RareText.enabled = false;
					this.RareText.enabled = true;
				}
				if (this.LevelText != null && this.LevelText.enabled)
				{
					this.LevelText.enabled = false;
					this.LevelText.enabled = true;
				}
				if (this.RankText != null && this.RankText.enabled)
				{
					this.RankText.enabled = false;
					this.RankText.enabled = true;
				}
				if (this.RankText2 != null && this.RankText2.enabled)
				{
					this.RankText2.enabled = false;
					this.RankText2.enabled = true;
				}
				if (this.UpText != null && this.UpText.enabled)
				{
					this.UpText.enabled = false;
					this.UpText.enabled = true;
				}
				if (this.PanelTitleText1 != null && this.PanelTitleText1.enabled)
				{
					this.PanelTitleText1.enabled = false;
					this.PanelTitleText1.enabled = true;
				}
				if (this.PanelTitleText2 != null && this.PanelTitleText2.enabled)
				{
					this.PanelTitleText2.enabled = false;
					this.PanelTitleText2.enabled = true;
				}
				if (this.MaxShowText != null && this.MaxShowText.enabled)
				{
					this.MaxShowText.enabled = false;
					this.MaxShowText.enabled = true;
				}
				if (this.EVO_TitleText != null && this.EVO_TitleText.enabled)
				{
					this.EVO_TitleText.enabled = false;
					this.EVO_TitleText.enabled = true;
				}
				if (this.EVO_InfoText != null && this.EVO_InfoText.enabled)
				{
					this.EVO_InfoText.enabled = false;
					this.EVO_InfoText.enabled = true;
				}
				if (this.EVO_UpText != null && this.EVO_UpText.enabled)
				{
					this.EVO_UpText.enabled = false;
					this.EVO_UpText.enabled = true;
				}
				if (this.EVO_NeedLvText != null && this.EVO_NeedLvText.enabled)
				{
					this.EVO_NeedLvText.enabled = false;
					this.EVO_NeedLvText.enabled = true;
				}
				if (this.EVO_LPriceText != null && this.EVO_LPriceText.enabled)
				{
					this.EVO_LPriceText.enabled = false;
					this.EVO_LPriceText.enabled = true;
				}
				if (this.EVO_LBtnText != null && this.EVO_LBtnText.enabled)
				{
					this.EVO_LBtnText.enabled = false;
					this.EVO_LBtnText.enabled = true;
				}
				if (this.EVO_RTimeText != null && this.EVO_RTimeText.enabled)
				{
					this.EVO_RTimeText.enabled = false;
					this.EVO_RTimeText.enabled = true;
				}
				if (this.EVO_RBtnText != null && this.EVO_RBtnText.enabled)
				{
					this.EVO_RBtnText.enabled = false;
					this.EVO_RBtnText.enabled = true;
				}
				if (this.TimeBar != null && this.TimeBar.enabled)
				{
					this.TimeBar.Refresh_FontTexture();
				}
				if (!this.bMaxShow)
				{
					if (this.ASExp_InfoNowtext != null && this.ASExp_InfoNowtext.enabled)
					{
						this.ASExp_InfoNowtext.enabled = false;
						this.ASExp_InfoNowtext.enabled = true;
					}
					if (this.ASExp_InfoNextText != null && this.ASExp_InfoNextText.enabled)
					{
						this.ASExp_InfoNextText.enabled = false;
						this.ASExp_InfoNextText.enabled = true;
					}
					if (this.ASExp_SkillNameText != null && this.ASExp_SkillNameText.enabled)
					{
						this.ASExp_SkillNameText.enabled = false;
						this.ASExp_SkillNameText.enabled = true;
					}
					if (this.ASExp_SkillLvText != null && this.ASExp_SkillLvText.enabled)
					{
						this.ASExp_SkillLvText.enabled = false;
						this.ASExp_SkillLvText.enabled = true;
					}
					if (this.ASExp_SkillExpText != null && this.ASExp_SkillExpText.enabled)
					{
						this.ASExp_SkillExpText.enabled = false;
						this.ASExp_SkillExpText.enabled = true;
					}
					if (this.ASExp_HaveCountText1 != null && this.ASExp_HaveCountText1.enabled)
					{
						this.ASExp_HaveCountText1.enabled = false;
						this.ASExp_HaveCountText1.enabled = true;
					}
					if (this.ASExp_HaveCountText2 != null && this.ASExp_HaveCountText2.enabled)
					{
						this.ASExp_HaveCountText2.enabled = false;
						this.ASExp_HaveCountText2.enabled = true;
					}
					if (this.ASExp_BottomTipText != null && this.ASExp_BottomTipText.enabled)
					{
						this.ASExp_BottomTipText.enabled = false;
						this.ASExp_BottomTipText.enabled = true;
					}
					if (this.ASExp_SelectText != null && this.ASExp_SelectText.enabled)
					{
						this.ASExp_SelectText.enabled = false;
						this.ASExp_SelectText.enabled = true;
					}
					if (this.ASExp_NeedCountText1 != null && this.ASExp_NeedCountText1.enabled)
					{
						this.ASExp_NeedCountText1.enabled = false;
						this.ASExp_NeedCountText1.enabled = true;
					}
					if (this.ASExp_NeedCountText2 != null && this.ASExp_NeedCountText2.enabled)
					{
						this.ASExp_NeedCountText2.enabled = false;
						this.ASExp_NeedCountText2.enabled = true;
					}
					if (this.ASExp_UpText1 != null && this.ASExp_UpText1.enabled)
					{
						this.ASExp_UpText1.enabled = false;
						this.ASExp_UpText1.enabled = true;
					}
					if (this.ASExp_UpText2 != null && this.ASExp_UpText2.enabled)
					{
						this.ASExp_UpText2.enabled = false;
						this.ASExp_UpText2.enabled = true;
					}
					if (this.ASExp_MaxText != null && this.ASExp_MaxText.enabled)
					{
						this.ASExp_MaxText.enabled = false;
						this.ASExp_MaxText.enabled = true;
					}
					if (this.ASExp_TitleText != null && this.ASExp_TitleText.enabled)
					{
						this.ASExp_TitleText.enabled = false;
						this.ASExp_TitleText.enabled = true;
					}
					if (this.ASExp_InfoNowTitletext != null && this.ASExp_InfoNowTitletext.enabled)
					{
						this.ASExp_InfoNowTitletext.enabled = false;
						this.ASExp_InfoNowTitletext.enabled = true;
					}
					if (this.ASExp_InfoNextTitleText != null && this.ASExp_InfoNextTitleText.enabled)
					{
						this.ASExp_InfoNextTitleText.enabled = false;
						this.ASExp_InfoNextTitleText.enabled = true;
					}
					if (this.ASExp_InfoNowCDtext != null && this.ASExp_InfoNowCDtext.enabled)
					{
						this.ASExp_InfoNowCDtext.enabled = false;
						this.ASExp_InfoNowCDtext.enabled = true;
					}
					if (this.ASExp_InfoNextCDText != null && this.ASExp_InfoNextCDText.enabled)
					{
						this.ASExp_InfoNextCDText.enabled = false;
						this.ASExp_InfoNextCDText.enabled = true;
					}
					if (this.ASExp_EffExpText != null && this.ASExp_EffExpText.enabled)
					{
						this.ASExp_EffExpText.enabled = false;
						this.ASExp_EffExpText.enabled = true;
					}
					if (this.ASExp_EffX2Text != null && this.ASExp_EffX2Text.enabled)
					{
						this.ASExp_EffX2Text.enabled = false;
						this.ASExp_EffX2Text.enabled = true;
					}
				}
			}
			break;
		case NetworkNews.Refresh_Asset:
			if (meg[1] == 1 && meg[2] == 2 && GameConstants.ConvertBytesToUShort(meg, 3) == this.sHero.Modle)
			{
				this.DestroyPet3D();
				this.LoadPet3D();
			}
			break;
		case NetworkNews.Refresh_Item:
			if (!this.bMaxShow)
			{
				this.SetStone();
				this.SetPetInfo();
				this.SetSkill();
				this.SetAddSkill_Item();
				this.CheckAddBtnState();
			}
			break;
		}
	}

	// Token: 0x0600166B RID: 5739 RVA: 0x0026A1DC File Offset: 0x002683DC
	public override void UpdateUI(int arg1, int arg2)
	{
		if (this.bMaxShow)
		{
			return;
		}
		switch (arg1)
		{
		case 1:
			this.SetSkill();
			this.SetAddSkill_Item();
			this.CheckAddBtnState();
			break;
		case 2:
			this.SetSkill();
			this.SetAddSkill_Item();
			this.SetAddSkill_Info();
			this.CheckAddBtnState();
			break;
		case 5:
			this.SetBlood();
			this.SetPetInfo();
			break;
		case 6:
			if ((int)this.NowPet.ID == arg2)
			{
				this.DestroyPet3D();
				this.LoadPet3D();
				this.SetBlood();
				this.SetPetInfo();
				this.SetSkill();
				this.ShowUpEffectPetID = this.NowPet.ID;
			}
			break;
		case 7:
			this.SetParticle_Show(true, true);
			break;
		case 8:
			this.SetParticle_Show(false, false);
			break;
		case 9:
			this.ASExp_EffbLVUp = (arg2 > 0);
			this.SetEffect((this.PM.PetUI_GetRate < 2000) ? eUIPet_Eff.eEff_ExpAdd : eUIPet_Eff.eEff_ExpX2);
			this.SetAddSkill_Item();
			break;
		case 10:
			this.PM.Send_PET_STARUP_INSTANT((ushort)this.NowEvoID);
			this.HideEvoPanel();
			break;
		case 11:
			this.ShowEvoPanel();
			break;
		}
	}

	// Token: 0x0600166C RID: 5740 RVA: 0x0026A334 File Offset: 0x00268534
	public override bool OnBackButtonClick()
	{
		if (this.SelectSkillIndex != -1)
		{
			this.HideAddSkillExpPanel();
			return true;
		}
		if (this.NowEvoID != -1)
		{
			this.HideEvoPanel();
			return true;
		}
		return false;
	}

	// Token: 0x0600166D RID: 5741 RVA: 0x0026A360 File Offset: 0x00268560
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			if (sender.m_BtnID2 == 1)
			{
				this.door.CloseMenu(false);
			}
			else if (sender.m_BtnID2 == 2)
			{
				this.door.OpenMenu(EGUIWindow.UI_Monster_Crypt_3, 1, 0, false);
			}
		}
		else if (sender.m_BtnID1 == 2)
		{
			if (sender.m_BtnID2 == 1)
			{
				if (this.NowPet == null)
				{
					return;
				}
				uint needExp = this.PM.GetNeedExp(this.NowPet.Level, this.sPet.Rare);
				if (this.NowPet.CheckState(PetManager.EPetState.Evolution))
				{
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.sPet.Name));
					cstring.AppendFormat(this.DM.mStringTable.GetStringByID(16040u));
					this.GM.AddHUDMessage(cstring.ToString(), 255, true);
				}
				else if (this.CheckMaxLv() && this.NowPet.Exp == needExp - 1u)
				{
					this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(16082u), this.DM.mStringTable.GetStringByID(16069u), this.DM.mStringTable.GetStringByID(3968u), this, 2, 0, true, false, false, false, false);
				}
				else
				{
					this.PM.PetUI_UseItemPetID = this.NowPet.ID;
					this.door.OpenMenu(EGUIWindow.UI_BagFilter, 4, 2, false);
				}
			}
			else if (sender.m_BtnID2 == 2)
			{
				this.GM.OpenMenu(EGUIWindow.UI_PetStoneTrans, (int)this.sPet.SoulID, 0, false, true, false);
			}
			else if (sender.m_BtnID2 == 3)
			{
				this.ShowEvoPanel();
			}
		}
		else if (sender.m_BtnID1 == 3)
		{
			this.ShowAddSkillExpPanel(sender.m_BtnID3);
		}
		else if (sender.m_BtnID1 == 4)
		{
			if (sender.m_BtnID2 == 1)
			{
				this.PM.PetUI_PetSortIndex--;
				if (this.PM.PetUI_PetSortIndex < 0)
				{
					this.PM.PetUI_PetSortIndex = (int)(this.PM.PetDataCount - 1);
				}
			}
			else if (sender.m_BtnID2 == 2)
			{
				this.PM.PetUI_PetSortIndex++;
				if (this.PM.PetUI_PetSortIndex >= (int)this.PM.PetDataCount)
				{
					this.PM.PetUI_PetSortIndex = 0;
				}
			}
			PetData petData = this.PM.GetPetData((int)this.PM.sortPetData[this.PM.PetUI_PetSortIndex]);
			if (petData != null)
			{
				this.PM.PetUI_PetID = (int)petData.ID;
				this.SetNowPet();
			}
		}
		else if (sender.m_BtnID1 == 5)
		{
			if ((this.tmpAN != null && !this.tmpAN.IsPlaying(this.PetAct)) || this.PetAct == "idle")
			{
				this.HeroActionChang(true);
			}
		}
		else if (sender.m_BtnID1 == 6)
		{
			if (sender.m_BtnID2 == 1)
			{
				this.HideAddSkillExpPanel();
			}
			else if (sender.m_BtnID2 == 2)
			{
				if (this.ASExp_InfoStr == null)
				{
					this.ASExp_InfoStr = StringManager.Instance.SpawnString(1024);
				}
				this.ASExp_InfoStr.Length = 0;
				CString cstring2 = StringManager.Instance.StaticString1024();
				cstring2.IntToFormat((long)GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Hour, 2, false);
				cstring2.IntToFormat((long)GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Minute, 2, false);
				cstring2.AppendFormat("{0}:{1}");
				this.ASExp_InfoStr.StringToFormat(cstring2);
				this.ASExp_InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(12128u));
				this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(12127u), this.ASExp_InfoStr.ToString(), null, null, 0, 0, true, true);
			}
			else if (sender.m_BtnID2 == 3)
			{
				if (this.NowPet == null || this.SelectSkillIndex < 0 || this.SelectSkillIndex >= 4)
				{
					return;
				}
				PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[this.SelectSkillIndex]);
				PetSkillHint.eKind kind = PetSkillHint.eKind.MaxLv;
				if (this.NowPet.SkillLv[this.SelectSkillIndex] >= recordByKey.UpLevel)
				{
					kind = PetSkillHint.eKind.Normal;
				}
				this.GM.m_Hint.ShowPetHint(this.ASExp_SkillMaxHint, kind, this.sPet.ID, this.sPet.PetSkill[this.SelectSkillIndex], this.NowPet.SkillLv[this.SelectSkillIndex], Vector2.zero, UIButtonHint.ePosition.Original);
			}
			else if (sender.m_BtnID2 == 5)
			{
				if (this.ClickAddSkillTime >= 0f)
				{
					return;
				}
				this.ClickAddSkillTime = 0f;
				if (this.bLevel)
				{
					this.ShowSkillUpbLevel();
				}
				else if (this.bCount1)
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12132u), 35, true);
				}
				else
				{
					if (this.ASExp_EffectKind != eUIPet_Eff.eEff_None)
					{
						if (this.EndEffect())
						{
							return;
						}
						if (this.bLevel)
						{
							this.ShowSkillUpbLevel();
						}
						else if (this.bCount1)
						{
							this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12132u), 35, true);
						}
					}
					if (!this.bLevel && !this.bCount1)
					{
						this.CheckUpgradeSkill(0);
					}
				}
			}
			else if (sender.m_BtnID2 == 4)
			{
				if (this.ClickAddSkillTime >= 0f)
				{
					return;
				}
				this.ClickAddSkillTime = 0f;
				if (this.bLevel)
				{
					this.ShowSkillUpbLevel();
				}
				else if (this.bCount2)
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12138u), 35, true);
				}
				else
				{
					if (this.ASExp_EffectKind != eUIPet_Eff.eEff_None)
					{
						if (this.EndEffect())
						{
							return;
						}
						if (this.bLevel)
						{
							this.ShowSkillUpbLevel();
						}
						else if (this.bCount2)
						{
							this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12138u), 35, true);
						}
					}
					if (!this.bLevel && !this.bCount2)
					{
						this.CheckUpgradeSkill(1);
					}
				}
			}
			else if (sender.m_BtnID2 == 6)
			{
				this.OpenSrcHint(2);
			}
			else if (sender.m_BtnID2 == 7)
			{
				if (this.ASExp_LockSP.m_SpriteIndex == 1)
				{
					CString cstring3 = StringManager.Instance.StaticString1024();
					PetSkillTbl recordByKey2 = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[this.SelectSkillIndex]);
					if (this.SelectSkillIndex != -1 && this.NowPet.SkillLv[this.SelectSkillIndex] > 0 && (int)this.NowPet.SkillLv[this.SelectSkillIndex] <= recordByKey2.OpenLevel.Length)
					{
						cstring3.IntToFormat((long)recordByKey2.OpenLevel[(int)(this.NowPet.SkillLv[this.SelectSkillIndex] - 1)], 1, false);
					}
					else
					{
						cstring3.IntToFormat(0L, 1, false);
					}
					cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(12124u));
					this.GM.m_Hint.Show(this.ASExp_LockHint, UIHintStyle.eHintSimple, 0, 350f, 20, cstring3, Vector2.zero);
				}
				else
				{
					this.ShowSkillUpbLevel();
				}
			}
		}
		else if (sender.m_BtnID1 == 7)
		{
			if (sender.m_BtnID2 == 1)
			{
				this.HideEvoPanel();
			}
			else if (sender.m_BtnID2 == 2 || sender.m_BtnID2 == 3)
			{
				if (!this.CheckEvoItem())
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(16034u), 35, true);
					return;
				}
				if (!this.CheckEvoLv())
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(16054u), 35, true);
					return;
				}
				if (this.PM.PetUI_EvoID != 0)
				{
					this.GM.OpenOKCancelBox(this, null, this.DM.mStringTable.GetStringByID(16057u), 1, 0, null, null);
					return;
				}
				if (sender.m_BtnID2 == 2)
				{
					uint resourceExchange = this.DM.GetResourceExchange(PriceListType.Time, this.PM.GetEvoNeed_Time(this.NowPet.Enhance));
					if (this.NowPet != null && this.DM.RoleAttr.Diamond < resourceExchange)
					{
						this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966u), this.DM.mStringTable.GetStringByID(646u), this.DM.mStringTable.GetStringByID(3968u), this, 3, 0, true, false, false, false, false);
						return;
					}
					if (GUIManager.Instance.OpenCheckCrystal(resourceExchange, 10, -1, -1))
					{
						return;
					}
					this.PM.Send_PET_STARUP_INSTANT((ushort)this.NowEvoID);
				}
				else
				{
					this.PM.Send_PET_STARUP((ushort)this.NowEvoID);
				}
				this.HideEvoPanel();
			}
			else if (sender.m_BtnID2 == 4)
			{
				this.OpenSrcHint(1);
			}
		}
	}

	// Token: 0x0600166E RID: 5742 RVA: 0x0026AD88 File Offset: 0x00268F88
	public void OnButtonDown(UIButtonHint sender)
	{
		bool flag = true;
		if (sender.Parm2 != 2)
		{
			if (sender.Parm2 == 3)
			{
				if (this.bMaxShow)
				{
					PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[(int)sender.Parm1]);
					this.GM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Lv1AndMax, this.sPet.ID, this.sPet.PetSkill[(int)sender.Parm1], recordByKey.UpLevel, new Vector2(-360f, 0f), UIButtonHint.ePosition.Original);
				}
				else
				{
					this.GM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Normal, this.sPet.ID, this.sPet.PetSkill[(int)sender.Parm1], this.NowPet.SkillLv[(int)sender.Parm1], new Vector2(-360f, 0f), UIButtonHint.ePosition.Original);
				}
			}
			else if (sender.Parm2 == 4)
			{
				flag = false;
			}
			else if (sender.Parm2 == 5)
			{
				this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 250f, 20, (int)sender.Parm1, 0, Vector2.zero, UIButtonHint.ePosition.Original);
			}
			else if (sender.Parm2 == 6)
			{
				this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 400f, 20, (int)sender.Parm1, 0, Vector2.zero, UIButtonHint.ePosition.Original);
			}
			else if (sender.Parm2 == 7)
			{
				this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 350f, 20, (int)sender.Parm1, 0, new Vector2(-60f, -80f), UIButtonHint.ePosition.Original);
			}
			else if (sender.Parm2 == 8)
			{
				if (this.bMaxShow || (this.NowPet != null && this.NowPet.Enhance == 2))
				{
					this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 350f, 20, 16088, 0, Vector2.zero, UIButtonHint.ePosition.Original);
				}
				else
				{
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.IntToFormat((long)this.PM.GetEvoNeed_Stone(this.NowPet.Enhance, this.sPet.Rare), 1, false);
					cstring.AppendFormat(this.DM.mStringTable.GetStringByID(16087u));
					this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 350f, 20, cstring, Vector2.zero);
				}
			}
			else
			{
				this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 350f, 20, (int)sender.Parm1, 0, Vector2.zero, UIButtonHint.ePosition.Original);
			}
		}
		if (flag)
		{
			AudioManager.Instance.PlayUISFX(UIKind.Normal);
		}
	}

	// Token: 0x0600166F RID: 5743 RVA: 0x0026B05C File Offset: 0x0026925C
	public void OnButtonUp(UIButtonHint sender)
	{
		this.GM.m_Hint.Hide(true);
	}

	// Token: 0x06001670 RID: 5744 RVA: 0x0026B070 File Offset: 0x00269270
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		if (this.door)
		{
			img.sprite = this.door.LoadSprite(ImageName);
			img.material = this.door.LoadMaterial();
		}
	}

	// Token: 0x06001671 RID: 5745 RVA: 0x0026B0B0 File Offset: 0x002692B0
	public void OnTimer(UITimeBar sender)
	{
	}

	// Token: 0x06001672 RID: 5746 RVA: 0x0026B0B4 File Offset: 0x002692B4
	public void OnNotify(UITimeBar sender)
	{
		this.GM.SetTimerSpriteType(sender, this.DM.GetQueueBarSpriteType(EQueueBarIndex.PetEvolution));
	}

	// Token: 0x06001673 RID: 5747 RVA: 0x0026B0D0 File Offset: 0x002692D0
	public void Onfunc(UITimeBar sender)
	{
		eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.PetEvolution);
		if (queueBarSpriteType == eTimerSpriteType.Speed)
		{
			this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 35, false);
		}
		else if (queueBarSpriteType == eTimerSpriteType.Free)
		{
			this.PM.Send_PET_STARUP_FREECOMPLETE();
		}
	}

	// Token: 0x06001674 RID: 5748 RVA: 0x0026B11C File Offset: 0x0026931C
	public void OnCancel(UITimeBar sender)
	{
		this.PM.Send_PET_STARUP_CANCEL();
	}

	// Token: 0x06001675 RID: 5749 RVA: 0x0026B12C File Offset: 0x0026932C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			switch (arg1)
			{
			case 1:
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 35, false);
				break;
			case 2:
				this.ShowEvoPanel();
				break;
			case 3:
				MallManager.Instance.Send_Mall_Info();
				break;
			case 4:
				this.SendUpgradeSkill((byte)arg2);
				break;
			case 5:
				this.HideAddSkillExpPanel();
				this.ShowEvoPanel();
				break;
			case 6:
				this.HideAddSkillExpPanel();
				this.PM.PetUI_UseItemPetID = this.NowPet.ID;
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 4, 2, false);
				break;
			}
		}
	}

	// Token: 0x04004285 RID: 17029
	private const int SkillCount = 3;

	// Token: 0x04004286 RID: 17030
	private Transform m_transform;

	// Token: 0x04004287 RID: 17031
	private RectTransform EmojiRC;

	// Token: 0x04004288 RID: 17032
	private DataManager DM;

	// Token: 0x04004289 RID: 17033
	private GUIManager GM;

	// Token: 0x0400428A RID: 17034
	private PetManager PM;

	// Token: 0x0400428B RID: 17035
	private Door m_door;

	// Token: 0x0400428C RID: 17036
	private UIText PetNameText;

	// Token: 0x0400428D RID: 17037
	private UIText ExpText;

	// Token: 0x0400428E RID: 17038
	private UIText StoneText;

	// Token: 0x0400428F RID: 17039
	private UIText LevelText_L;

	// Token: 0x04004290 RID: 17040
	private UIText RareText;

	// Token: 0x04004291 RID: 17041
	private UIText LevelText;

	// Token: 0x04004292 RID: 17042
	private UIText RankText;

	// Token: 0x04004293 RID: 17043
	private UIText RankText2;

	// Token: 0x04004294 RID: 17044
	private UIText UpText;

	// Token: 0x04004295 RID: 17045
	private UIText PanelTitleText1;

	// Token: 0x04004296 RID: 17046
	private UIText PanelTitleText2;

	// Token: 0x04004297 RID: 17047
	private UIText MaxShowText;

	// Token: 0x04004298 RID: 17048
	private CString ExpStr;

	// Token: 0x04004299 RID: 17049
	private CString StoneStr;

	// Token: 0x0400429A RID: 17050
	private CString LevelStr_L;

	// Token: 0x0400429B RID: 17051
	private CString RareStr;

	// Token: 0x0400429C RID: 17052
	private CString LevelStr;

	// Token: 0x0400429D RID: 17053
	private CString RankStr;

	// Token: 0x0400429E RID: 17054
	private CString UpStr;

	// Token: 0x0400429F RID: 17055
	private Transform[] SkillT = new Transform[3];

	// Token: 0x040042A0 RID: 17056
	private Transform[] SkillBtnT = new Transform[3];

	// Token: 0x040042A1 RID: 17057
	private UIButton[] SkillBtn = new UIButton[3];

	// Token: 0x040042A2 RID: 17058
	private Transform[] SkillBtnAlertT = new Transform[3];

	// Token: 0x040042A3 RID: 17059
	private UIText[] SkillNameText = new UIText[3];

	// Token: 0x040042A4 RID: 17060
	private CString[] SkillNameStr = new CString[3];

	// Token: 0x040042A5 RID: 17061
	private UIText[] SkillExpText = new UIText[3];

	// Token: 0x040042A6 RID: 17062
	private CString[] SkillExpStr = new CString[3];

	// Token: 0x040042A7 RID: 17063
	private Transform[] SkillExpImageT = new Transform[3];

	// Token: 0x040042A8 RID: 17064
	private Image[] SkillExpImage = new Image[3];

	// Token: 0x040042A9 RID: 17065
	private UISpritesArray[] SkillExpImageSP = new UISpritesArray[3];

	// Token: 0x040042AA RID: 17066
	private Image[] SkillImage1 = new Image[3];

	// Token: 0x040042AB RID: 17067
	private Image[] SkillImage2 = new Image[3];

	// Token: 0x040042AC RID: 17068
	private UISpritesArray[] SkillImage2SP = new UISpritesArray[3];

	// Token: 0x040042AD RID: 17069
	private GameObject[] SkillLockGO = new GameObject[3];

	// Token: 0x040042AE RID: 17070
	private UIText[] SkillLockText = new UIText[3];

	// Token: 0x040042AF RID: 17071
	private Image[] SkillkindImage = new Image[3];

	// Token: 0x040042B0 RID: 17072
	private UISpritesArray[] SkillkindSP = new UISpritesArray[3];

	// Token: 0x040042B1 RID: 17073
	private UIButtonHint[] SkillKindHint = new UIButtonHint[3];

	// Token: 0x040042B2 RID: 17074
	private UIButtonHint[] SkillPicHint = new UIButtonHint[3];

	// Token: 0x040042B3 RID: 17075
	private Image ExpImage;

	// Token: 0x040042B4 RID: 17076
	private Image MaxShowBack;

	// Token: 0x040042B5 RID: 17077
	private UISpritesArray ExpSP;

	// Token: 0x040042B6 RID: 17078
	private UISpritesArray BloodSP;

	// Token: 0x040042B7 RID: 17079
	private Transform StoneIcon;

	// Token: 0x040042B8 RID: 17080
	private Transform PetIcon;

	// Token: 0x040042B9 RID: 17081
	private Transform PetStateImage;

	// Token: 0x040042BA RID: 17082
	private Transform StoneT;

	// Token: 0x040042BB RID: 17083
	private Transform MaxShowT;

	// Token: 0x040042BC RID: 17084
	private Transform RankT;

	// Token: 0x040042BD RID: 17085
	private Transform TimeBarBackT;

	// Token: 0x040042BE RID: 17086
	private Transform Left_T;

	// Token: 0x040042BF RID: 17087
	private Transform Right_T;

	// Token: 0x040042C0 RID: 17088
	private Transform BloodBtnT;

	// Token: 0x040042C1 RID: 17089
	private Transform PanelRLightT;

	// Token: 0x040042C2 RID: 17090
	private Transform PanelBlockT;

	// Token: 0x040042C3 RID: 17091
	private Transform TimeBarEffectT;

	// Token: 0x040042C4 RID: 17092
	private UITimeBar TimeBar;

	// Token: 0x040042C5 RID: 17093
	private CString HinString;

	// Token: 0x040042C6 RID: 17094
	private EmojiUnit EmojiBack;

	// Token: 0x040042C7 RID: 17095
	private EmojiUnit Emoji;

	// Token: 0x040042C8 RID: 17096
	private float MaxShowFalshTime;

	// Token: 0x040042C9 RID: 17097
	private bool bMaxShow;

	// Token: 0x040042CA RID: 17098
	private PetData NowPet;

	// Token: 0x040042CB RID: 17099
	private PetTbl sPet;

	// Token: 0x040042CC RID: 17100
	private Hero sHero;

	// Token: 0x040042CD RID: 17101
	private GameObject PetGO;

	// Token: 0x040042CE RID: 17102
	private AssetBundle AB;

	// Token: 0x040042CF RID: 17103
	private AssetBundleRequest AR;

	// Token: 0x040042D0 RID: 17104
	private int AssetKey;

	// Token: 0x040042D1 RID: 17105
	private bool bABInitial;

	// Token: 0x040042D2 RID: 17106
	private Transform PetModel;

	// Token: 0x040042D3 RID: 17107
	private RectTransform PetPosRT;

	// Token: 0x040042D4 RID: 17108
	private float ActionTime;

	// Token: 0x040042D5 RID: 17109
	private float ActionTimeRandom;

	// Token: 0x040042D6 RID: 17110
	private float MovingTimer;

	// Token: 0x040042D7 RID: 17111
	private string PetAct;

	// Token: 0x040042D8 RID: 17112
	private Animation tmpAN;

	// Token: 0x040042D9 RID: 17113
	public string[] mPetAct = new string[7];

	// Token: 0x040042DA RID: 17114
	private UIBtnDrag btn_PetActionD;

	// Token: 0x040042DB RID: 17115
	private byte RandomEnd = 1;

	// Token: 0x040042DC RID: 17116
	private float MoveX;

	// Token: 0x040042DD RID: 17117
	private float LeftPosX;

	// Token: 0x040042DE RID: 17118
	private float RightPosX;

	// Token: 0x040042DF RID: 17119
	private Vector3 BtnPos;

	// Token: 0x040042E0 RID: 17120
	private int SelectSkillIndex = -1;

	// Token: 0x040042E1 RID: 17121
	private Transform ASExp_PanelT;

	// Token: 0x040042E2 RID: 17122
	private Transform ASExp_MaxImageT;

	// Token: 0x040042E3 RID: 17123
	private Transform ASExp_SkillLockT;

	// Token: 0x040042E4 RID: 17124
	private Transform ASExp_StoneIconT1;

	// Token: 0x040042E5 RID: 17125
	private Transform ASExp_StoneIconT2;

	// Token: 0x040042E6 RID: 17126
	private Transform ASExp_AddBtnT1;

	// Token: 0x040042E7 RID: 17127
	private Transform ASExp_AddBtnT2;

	// Token: 0x040042E8 RID: 17128
	private Transform ASExp_MaxRImageT;

	// Token: 0x040042E9 RID: 17129
	private Transform ASExp_SelectTextBackT;

	// Token: 0x040042EA RID: 17130
	private Image ASExp_SkillImage1;

	// Token: 0x040042EB RID: 17131
	private Image ASExp_SkillImage2;

	// Token: 0x040042EC RID: 17132
	private Image ASExp_ExpBar;

	// Token: 0x040042ED RID: 17133
	private Image ASExp_ExpBarImage;

	// Token: 0x040042EE RID: 17134
	private Image ASExp_InfoNowCDImage;

	// Token: 0x040042EF RID: 17135
	private Image ASExp_InfoNextCDImage;

	// Token: 0x040042F0 RID: 17136
	private Image ASExp_EffIconBlockImage;

	// Token: 0x040042F1 RID: 17137
	private Image ASExp_EffIconMoveImage;

	// Token: 0x040042F2 RID: 17138
	private Image ASExp_EffBarBlockImage;

	// Token: 0x040042F3 RID: 17139
	private Image ASExp_EffBarInnerImage;

	// Token: 0x040042F4 RID: 17140
	private Image ASExp_EffExpBackImage;

	// Token: 0x040042F5 RID: 17141
	private Image ASExp_SkillLockImage;

	// Token: 0x040042F6 RID: 17142
	private UIText ASExp_InfoNowtext;

	// Token: 0x040042F7 RID: 17143
	private UIText ASExp_InfoNextText;

	// Token: 0x040042F8 RID: 17144
	private UIText ASExp_SkillNameText;

	// Token: 0x040042F9 RID: 17145
	private UIText ASExp_SkillLvText;

	// Token: 0x040042FA RID: 17146
	private UIText ASExp_SkillExpText;

	// Token: 0x040042FB RID: 17147
	private UIText ASExp_SelectText;

	// Token: 0x040042FC RID: 17148
	private UIText ASExp_BottomTipText;

	// Token: 0x040042FD RID: 17149
	private UIText ASExp_NeedCountText1;

	// Token: 0x040042FE RID: 17150
	private UIText ASExp_NeedCountText2;

	// Token: 0x040042FF RID: 17151
	private UIText ASExp_HaveCountText1;

	// Token: 0x04004300 RID: 17152
	private UIText ASExp_HaveCountText2;

	// Token: 0x04004301 RID: 17153
	private UIText ASExp_UpText1;

	// Token: 0x04004302 RID: 17154
	private UIText ASExp_UpText2;

	// Token: 0x04004303 RID: 17155
	private UIText ASExp_MaxText;

	// Token: 0x04004304 RID: 17156
	private UIText ASExp_TitleText;

	// Token: 0x04004305 RID: 17157
	private UIText ASExp_InfoNowTitletext;

	// Token: 0x04004306 RID: 17158
	private UIText ASExp_InfoNextTitleText;

	// Token: 0x04004307 RID: 17159
	private UIText ASExp_InfoNowCDtext;

	// Token: 0x04004308 RID: 17160
	private UIText ASExp_InfoNextCDText;

	// Token: 0x04004309 RID: 17161
	private UIText ASExp_EffExpText;

	// Token: 0x0400430A RID: 17162
	private UIText ASExp_EffX2Text;

	// Token: 0x0400430B RID: 17163
	private CString ASExp_InfoNowStr;

	// Token: 0x0400430C RID: 17164
	private CString ASExp_InfoNextStr;

	// Token: 0x0400430D RID: 17165
	private CString ASExp_SkillLvStr;

	// Token: 0x0400430E RID: 17166
	private CString ASExp_SkillExpStr;

	// Token: 0x0400430F RID: 17167
	private CString ASExp_InfoNowCDStr;

	// Token: 0x04004310 RID: 17168
	private CString ASExp_InfoNextCDStr;

	// Token: 0x04004311 RID: 17169
	private CString ASExp_InfoStr;

	// Token: 0x04004312 RID: 17170
	private CString ASExp_NeedCountStr1;

	// Token: 0x04004313 RID: 17171
	private CString ASExp_NeedCountStr2;

	// Token: 0x04004314 RID: 17172
	private CString ASExp_HaveCountStr1;

	// Token: 0x04004315 RID: 17173
	private CString ASExp_HaveCountStr2;

	// Token: 0x04004316 RID: 17174
	private CString ASExp_EffExpStr;

	// Token: 0x04004317 RID: 17175
	private CString ASExp_EffX2Str;

	// Token: 0x04004318 RID: 17176
	private UIButton ASExp_AddBtn1;

	// Token: 0x04004319 RID: 17177
	private UIButton ASExp_AddBtn2;

	// Token: 0x0400431A RID: 17178
	private GameObject ASExp_AddBtn1Click;

	// Token: 0x0400431B RID: 17179
	private GameObject ASExp_AddBtn2Click;

	// Token: 0x0400431C RID: 17180
	private UISpritesArray ASExp_ExpSP;

	// Token: 0x0400431D RID: 17181
	private UISpritesArray ASExp_LockSP;

	// Token: 0x0400431E RID: 17182
	private UIButtonHint ASExp_SkillMaxHint;

	// Token: 0x0400431F RID: 17183
	private UIButtonHint ASExp_SrcHint;

	// Token: 0x04004320 RID: 17184
	private UIButtonHint ASExp_LockHint;

	// Token: 0x04004321 RID: 17185
	private bool bCount1;

	// Token: 0x04004322 RID: 17186
	private bool bCount2;

	// Token: 0x04004323 RID: 17187
	private bool bLevel;

	// Token: 0x04004324 RID: 17188
	private ushort ASExp_ExpItemID = 3701;

	// Token: 0x04004325 RID: 17189
	private eUIPet_Eff ASExp_EffectKind;

	// Token: 0x04004326 RID: 17190
	private float ASExp_EffDTime;

	// Token: 0x04004327 RID: 17191
	private float ASExp_EffTatalTime;

	// Token: 0x04004328 RID: 17192
	private bool ASExp_EffbLVUp;

	// Token: 0x04004329 RID: 17193
	private bool ASExp_bPlaySound;

	// Token: 0x0400432A RID: 17194
	private Vector2 IconMove_OriginalPos = Vector2.zero;

	// Token: 0x0400432B RID: 17195
	private Vector2[] IconMove_PosValue = new Vector2[]
	{
		new Vector2(0f, 0f),
		new Vector2(0f, 257f),
		new Vector2(0f, 0f)
	};

	// Token: 0x0400432C RID: 17196
	private float[] IconMove_PosKey = new float[]
	{
		0f,
		0.6f,
		1f
	};

	// Token: 0x0400432D RID: 17197
	private float[] IconMove_AlphaValue;

	// Token: 0x0400432E RID: 17198
	private float[] IconMove_AlphaKey;

	// Token: 0x0400432F RID: 17199
	private Vector2[] IconBlock_ScaleValue;

	// Token: 0x04004330 RID: 17200
	private float[] IconBlock_ScaleKey;

	// Token: 0x04004331 RID: 17201
	private float[] IconBlock_AlphaValue;

	// Token: 0x04004332 RID: 17202
	private float[] IconBlock_AlphaKey;

	// Token: 0x04004333 RID: 17203
	private float[] BarBlockImageAlphaValue;

	// Token: 0x04004334 RID: 17204
	private float[] BarBlockImageAlphaKey;

	// Token: 0x04004335 RID: 17205
	private Vector2[] BarBlockImageScaleValue_Up;

	// Token: 0x04004336 RID: 17206
	private float[] BarBlockImageScaleKey_Up;

	// Token: 0x04004337 RID: 17207
	private float[] BarBlockImageAlphaValue_Up;

	// Token: 0x04004338 RID: 17208
	private float[] BarBlockImageAlphaKey_Up;

	// Token: 0x04004339 RID: 17209
	private Vector2[] BarInnerImageScaleValue;

	// Token: 0x0400433A RID: 17210
	private float[] BarInnerImageScaleKey;

	// Token: 0x0400433B RID: 17211
	private float[] BarInnerImageAlphaValue;

	// Token: 0x0400433C RID: 17212
	private float[] BarInnerImageAlphaKey;

	// Token: 0x0400433D RID: 17213
	private Vector2 ExpText_OriginalPos;

	// Token: 0x0400433E RID: 17214
	private Vector2[] ExpText_PositionValue;

	// Token: 0x0400433F RID: 17215
	private float[] ExpText_PositionKey;

	// Token: 0x04004340 RID: 17216
	private Vector2[] ExpText_ScaleValue;

	// Token: 0x04004341 RID: 17217
	private float[] ExpText_ScaleKey;

	// Token: 0x04004342 RID: 17218
	private float[] ExpText_AlphaValue;

	// Token: 0x04004343 RID: 17219
	private float[] ExpText_AlphaKey;

	// Token: 0x04004344 RID: 17220
	private float ImageFAFrom;

	// Token: 0x04004345 RID: 17221
	private float ImageFATo;

	// Token: 0x04004346 RID: 17222
	private uint ImageExpNeed;

	// Token: 0x04004347 RID: 17223
	private float[] ExpBarFA_ScaleKey;

	// Token: 0x04004348 RID: 17224
	private Vector2[] ExpTextX2_PositionValue;

	// Token: 0x04004349 RID: 17225
	private float[] ExpTextX2_PositionKey;

	// Token: 0x0400434A RID: 17226
	private Vector2[] ExpTextX2_ScaleValue;

	// Token: 0x0400434B RID: 17227
	private float[] ExpTextX2_ScaleKey;

	// Token: 0x0400434C RID: 17228
	private float[] ExpTextX2_AlphaValue;

	// Token: 0x0400434D RID: 17229
	private float[] ExpTextX2_AlphaKey;

	// Token: 0x0400434E RID: 17230
	private Vector2[] X2Text_ScaleValue;

	// Token: 0x0400434F RID: 17231
	private float[] X2Text_ScaleKey;

	// Token: 0x04004350 RID: 17232
	private float[] X2Text_AlphaValue;

	// Token: 0x04004351 RID: 17233
	private float[] X2Text_AlphaKey;

	// Token: 0x04004352 RID: 17234
	private Vector2[] ExpBar_ScaleValue;

	// Token: 0x04004353 RID: 17235
	private float[] ExpBar_ScaleKey;

	// Token: 0x04004354 RID: 17236
	private Vector2[] ExpBarText_ScaleValue;

	// Token: 0x04004355 RID: 17237
	private float[] ExpBarText_ScaleKey;

	// Token: 0x04004356 RID: 17238
	private float[] ExpBarText_AlphaValue;

	// Token: 0x04004357 RID: 17239
	private float[] ExpBarText_AlphaKey;

	// Token: 0x04004358 RID: 17240
	private Vector2[] BarBlockImageX2ScaleValue;

	// Token: 0x04004359 RID: 17241
	private float[] BarBlockImageX2ScaleKey;

	// Token: 0x0400435A RID: 17242
	private float[] BarBlockImageX2AlphaValue;

	// Token: 0x0400435B RID: 17243
	private float[] BarBlockImageX2AlphaKey;

	// Token: 0x0400435C RID: 17244
	private Vector2[] BarInnerImageX2ScaleValue;

	// Token: 0x0400435D RID: 17245
	private float[] BarInnerImageX2ScaleKey;

	// Token: 0x0400435E RID: 17246
	private float[] BarInnerImageX2AlphaValue;

	// Token: 0x0400435F RID: 17247
	private float[] BarInnerImageX2AlphaKey;

	// Token: 0x04004360 RID: 17248
	private GameObject X2ParticleGO;

	// Token: 0x04004361 RID: 17249
	private float[] X2LockImage_AlphaValue;

	// Token: 0x04004362 RID: 17250
	private float[] X2LockImage_AlphaKey;

	// Token: 0x04004363 RID: 17251
	private int NowEvoID;

	// Token: 0x04004364 RID: 17252
	private Transform EVO_panelT;

	// Token: 0x04004365 RID: 17253
	private Transform EVO_StoneIconT;

	// Token: 0x04004366 RID: 17254
	private UIText EVO_TitleText;

	// Token: 0x04004367 RID: 17255
	private UIText EVO_InfoText;

	// Token: 0x04004368 RID: 17256
	private UIText EVO_UpText;

	// Token: 0x04004369 RID: 17257
	private UIText EVO_NeedLvText;

	// Token: 0x0400436A RID: 17258
	private UIText EVO_LPriceText;

	// Token: 0x0400436B RID: 17259
	private UIText EVO_LBtnText;

	// Token: 0x0400436C RID: 17260
	private UIText EVO_RTimeText;

	// Token: 0x0400436D RID: 17261
	private UIText EVO_RBtnText;

	// Token: 0x0400436E RID: 17262
	private CString EVO_UpStr;

	// Token: 0x0400436F RID: 17263
	private CString EVO_NeedStr;

	// Token: 0x04004370 RID: 17264
	private CString EVO_PriceStr;

	// Token: 0x04004371 RID: 17265
	private CString EVO_TimeStr;

	// Token: 0x04004372 RID: 17266
	private UIButtonHint EVO_SrcHint;

	// Token: 0x04004373 RID: 17267
	private float EmijiShowTime1;

	// Token: 0x04004374 RID: 17268
	private float EmijiShowTime2;

	// Token: 0x04004375 RID: 17269
	private float EmojiShowMaxScale;

	// Token: 0x04004376 RID: 17270
	private float EmijiShowCountTime;

	// Token: 0x04004377 RID: 17271
	private ushort[] ParticleID;

	// Token: 0x04004378 RID: 17272
	private GameObject ParticleObj;

	// Token: 0x04004379 RID: 17273
	private GameObject ParticleObj_Bar;

	// Token: 0x0400437A RID: 17274
	private ushort ShowUpEffectPetID;

	// Token: 0x0400437B RID: 17275
	private GameObject UpParticleGO;

	// Token: 0x0400437C RID: 17276
	private float ClickAddSkillTime;

	// Token: 0x0400437D RID: 17277
	private RectTransform LightRC;

	// Token: 0x0400437E RID: 17278
	private Light myLight1;

	// Token: 0x0400437F RID: 17279
	private Light myLight2;

	// Token: 0x04004380 RID: 17280
	private Light myLight3;

	// Token: 0x04004381 RID: 17281
	private Color MaxTextColor;
}
