using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200044B RID: 1099
public class UIOther_Set : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x0600160F RID: 5647 RVA: 0x002599A8 File Offset: 0x00257BA8
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		Transform child = this.GameT.GetChild(0).GetChild(0).GetChild(0);
		this.text_tmpStr[0] = child.GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7024u);
		child = this.GameT.GetChild(1);
		this.m_Mask = child.GetComponent<CScrollRect>();
		child = this.GameT.GetChild(1).GetChild(0);
		Transform child2 = child.GetChild(0).GetChild(0);
		this.btn_Music = child2.GetComponent<UIButton>();
		this.btn_Music.m_Handler = this;
		this.btn_Music.m_BtnID1 = 1;
		this.Img_Music = child2.GetChild(1).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_Music.transform.localScale = new Vector3(-1f, this.Img_Music.transform.localScale.y, this.Img_Music.transform.localScale.z);
			child2.GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		child2 = child.GetChild(0).GetChild(1);
		this.btn_Sound = child2.GetComponent<UIButton>();
		this.btn_Sound.m_Handler = this;
		this.btn_Sound.m_BtnID1 = 2;
		this.Img_Sound = child2.GetChild(1).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_Sound.transform.localScale = new Vector3(-1f, this.Img_Sound.transform.localScale.y, this.Img_Sound.transform.localScale.z);
			child2.GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		child2 = child.GetChild(0).GetChild(2);
		this.text_tmpStr[1] = child2.GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7032u);
		child2 = child.GetChild(1);
		this.btn_Music_Old = child2.GetChild(0).GetComponent<UIButton>();
		this.btn_Music_Old.m_Handler = this;
		this.btn_Music_Old.m_BtnID1 = 8;
		this.Img_Music_Old = child2.GetChild(0).GetChild(0).GetComponent<Image>();
		this.btn_Music_New = child2.GetChild(1).GetComponent<UIButton>();
		this.btn_Music_New.m_Handler = this;
		this.btn_Music_New.m_BtnID1 = 9;
		this.Img_Music_New = child2.GetChild(1).GetChild(0).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_Music_Old.gameObject.AddComponent<ArabicItemTextureRot>();
			this.Img_Music_New.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		for (int i = 0; i < 3; i++)
		{
			this.text_MusicSelect[i] = child2.GetChild(2 + i).GetComponent<UIText>();
			this.text_MusicSelect[i].font = this.TTFont;
			this.text_MusicSelect[i].text = this.DM.mStringTable.GetStringByID((uint)((ushort)(16104 + i)));
		}
		child2 = child.GetChild(2);
		this.text_tmpStr[2] = child2.GetChild(3).GetComponent<UIText>();
		this.text_tmpStr[2].font = this.TTFont;
		this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(7034u);
		child2 = child.GetChild(2);
		for (int j = 0; j < 3; j++)
		{
			this.btn_UR[j] = child2.GetChild(j).GetComponent<UIButton>();
			this.btn_UR[j].m_Handler = this;
			this.btn_UR[j].m_BtnID1 = 3 + j;
			this.Img_UR[j] = child2.GetChild(j).GetChild(0).GetComponent<Image>();
			if (this.GUIM.IsArabic)
			{
				this.Img_UR[j].transform.localScale = new Vector3(-1f, this.Img_UR[j].transform.localScale.y, this.Img_UR[j].transform.localScale.z);
			}
			this.text_UR[j] = child2.GetChild(j).GetChild(1).GetComponent<UIText>();
			this.text_UR[j].font = this.TTFont;
			this.text_UR[j].text = this.DM.mStringTable.GetStringByID((uint)((ushort)(7036 + j)));
		}
		child2 = child.GetChild(3);
		this.btn_AutoTranslate = child2.GetChild(0).GetComponent<UIButton>();
		this.btn_AutoTranslate.m_Handler = this;
		this.btn_AutoTranslate.m_BtnID1 = 7;
		this.Img_AutoTranslate = child2.GetChild(0).GetChild(0).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_AutoTranslate.transform.localScale = new Vector3(-1f, this.Img_AutoTranslate.transform.localScale.y, this.Img_AutoTranslate.transform.localScale.z);
		}
		this.text_tmpStr[4] = child2.GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[4].font = this.TTFont;
		this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(9062u);
		this.text_tmpStr[5] = child2.GetChild(2).GetComponent<UIText>();
		this.text_tmpStr[5].font = this.TTFont;
		this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(9078u);
		child2 = child.GetChild(2);
		this.text_tmpStr[3] = child2.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[3].font = this.TTFont;
		this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(7035u);
		this.m_Mat = this.door.LoadMaterial();
		this.tmpImg = this.GameT.GetChild(2).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(2).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.CheckSet();
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001610 RID: 5648 RVA: 0x0025A150 File Offset: 0x00258350
	public void CheckSet()
	{
		this.Img_Music.gameObject.SetActive(this.DM.MySysSetting.bMusic);
		this.Img_Sound.gameObject.SetActive(this.DM.MySysSetting.bSound);
		this.Img_AutoTranslate.gameObject.SetActive(this.DM.MySysSetting.bAutoTranslate);
		this.Img_UR[(int)this.DM.MySysSetting.mUpDateRate].gameObject.SetActive(true);
		if (this.DM.MySysSetting.mMusicSelect == 0)
		{
			this.Img_Music_Old.gameObject.SetActive(true);
			this.Img_Music_New.gameObject.SetActive(false);
		}
		else
		{
			this.Img_Music_Old.gameObject.SetActive(false);
			this.Img_Music_New.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001611 RID: 5649 RVA: 0x0025A240 File Offset: 0x00258440
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 1:
			this.DM.MySysSetting.bMusic = !this.DM.MySysSetting.bMusic;
			this.Img_Music.gameObject.SetActive(this.DM.MySysSetting.bMusic);
			AudioManager.Instance.SwitchMusic(this.DM.MySysSetting.bMusic);
			break;
		case 2:
			this.DM.MySysSetting.bSound = !this.DM.MySysSetting.bSound;
			this.Img_Sound.gameObject.SetActive(this.DM.MySysSetting.bSound);
			AudioManager.Instance.MuteSFXVol = !this.DM.MySysSetting.bSound;
			break;
		case 3:
		case 4:
		case 5:
		{
			byte mUpDateRate = (byte)(sender.m_BtnID1 - 3);
			this.Img_UR[(int)this.DM.MySysSetting.mUpDateRate].gameObject.SetActive(false);
			switch (mUpDateRate)
			{
			case 0:
				Application.targetFrameRate = 15;
				break;
			case 1:
				Application.targetFrameRate = 30;
				break;
			case 2:
				Application.targetFrameRate = -1;
				break;
			}
			this.DM.MySysSetting.mUpDateRate = mUpDateRate;
			this.Img_UR[(int)this.DM.MySysSetting.mUpDateRate].gameObject.SetActive(true);
			break;
		}
		case 7:
			this.DM.MySysSetting.bAutoTranslate = !this.DM.MySysSetting.bAutoTranslate;
			this.Img_AutoTranslate.gameObject.SetActive(this.DM.MySysSetting.bAutoTranslate);
			this.DM.ClearAllHeight();
			break;
		case 8:
		case 9:
		{
			byte b = (byte)(sender.m_BtnID1 - 8);
			if (b == 0)
			{
				this.Img_Music_Old.gameObject.SetActive(true);
				this.Img_Music_New.gameObject.SetActive(false);
			}
			else
			{
				this.Img_Music_Old.gameObject.SetActive(false);
				this.Img_Music_New.gameObject.SetActive(true);
			}
			this.DM.MySysSetting.mMusicSelect = b;
			if (this.door.m_eMapMode == EUIOriginMapMode.KingdomMap || this.door.m_eMapMode == EUIOriginMapMode.WorldMap)
			{
				AudioManager.Instance.LoadAndPlayBGM(BGMType.Legion, 1, false);
			}
			break;
		}
		}
	}

	// Token: 0x06001612 RID: 5650 RVA: 0x0025A504 File Offset: 0x00258704
	public override void OnClose()
	{
		this.DM.SetSysSettingSave();
	}

	// Token: 0x06001613 RID: 5651 RVA: 0x0025A514 File Offset: 0x00258714
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
			break;
		}
	}

	// Token: 0x06001614 RID: 5652 RVA: 0x0025A554 File Offset: 0x00258754
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < 3; i++)
		{
			if (this.text_UR[i] != null && this.text_UR[i].enabled)
			{
				this.text_UR[i].enabled = false;
				this.text_UR[i].enabled = true;
			}
			if (this.text_MusicSelect[i] != null && this.text_MusicSelect[i].enabled)
			{
				this.text_MusicSelect[i].enabled = false;
				this.text_MusicSelect[i].enabled = true;
			}
		}
		for (int j = 0; j < 6; j++)
		{
			if (this.text_tmpStr[j] != null && this.text_tmpStr[j].enabled)
			{
				this.text_tmpStr[j].enabled = false;
				this.text_tmpStr[j].enabled = true;
			}
		}
	}

	// Token: 0x06001615 RID: 5653 RVA: 0x0025A648 File Offset: 0x00258848
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 1)
		{
		}
	}

	// Token: 0x06001616 RID: 5654 RVA: 0x0025A668 File Offset: 0x00258868
	private void Start()
	{
	}

	// Token: 0x06001617 RID: 5655 RVA: 0x0025A66C File Offset: 0x0025886C
	private void Update()
	{
	}

	// Token: 0x04004173 RID: 16755
	private DataManager DM;

	// Token: 0x04004174 RID: 16756
	private GUIManager GUIM;

	// Token: 0x04004175 RID: 16757
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x04004176 RID: 16758
	private Door door;

	// Token: 0x04004177 RID: 16759
	private Transform GameT;

	// Token: 0x04004178 RID: 16760
	private UIButton btn_EXIT;

	// Token: 0x04004179 RID: 16761
	private UIButton btn_Music;

	// Token: 0x0400417A RID: 16762
	private UIButton btn_Sound;

	// Token: 0x0400417B RID: 16763
	private UIButton btn_AutoTranslate;

	// Token: 0x0400417C RID: 16764
	private UIButton[] btn_UR = new UIButton[3];

	// Token: 0x0400417D RID: 16765
	private UIButton btn_Music_Old;

	// Token: 0x0400417E RID: 16766
	private UIButton btn_Music_New;

	// Token: 0x0400417F RID: 16767
	private Image tmpImg;

	// Token: 0x04004180 RID: 16768
	private Image Img_Music;

	// Token: 0x04004181 RID: 16769
	private Image Img_Sound;

	// Token: 0x04004182 RID: 16770
	private Image Img_AutoTranslate;

	// Token: 0x04004183 RID: 16771
	private Image[] Img_UR = new Image[3];

	// Token: 0x04004184 RID: 16772
	private Image Img_Music_Old;

	// Token: 0x04004185 RID: 16773
	private Image Img_Music_New;

	// Token: 0x04004186 RID: 16774
	private UIText[] text_UR = new UIText[3];

	// Token: 0x04004187 RID: 16775
	private UIText[] text_tmpStr = new UIText[6];

	// Token: 0x04004188 RID: 16776
	private UIText[] text_MusicSelect = new UIText[3];

	// Token: 0x04004189 RID: 16777
	private Material m_Mat;

	// Token: 0x0400418A RID: 16778
	private CScrollRect m_Mask;
}
