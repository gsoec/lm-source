using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002D7 RID: 727
public class UIAlliance_Badge : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06000EAC RID: 3756 RVA: 0x00184790 File Offset: 0x00182990
	public override void OnOpen(int arg1, int arg2)
	{
		this.NeedValue = (uint)arg1;
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.BadgeMaterial = this.GUIM.GetBadgeMaterial(true);
		this.TotemMaterial = this.GUIM.GetBadgeMaterial(false);
		this.Tmp = this.GameT.GetChild(0);
		this.Tmp1 = this.Tmp.GetChild(0).GetChild(0).GetChild(0);
		this.tmptext_Str[0] = this.Tmp1.GetComponent<UIText>();
		this.tmptext_Str[0].font = this.TTFont;
		this.tmptext_Str[0].text = this.DM.mStringTable.GetStringByID(4732u);
		this.Tmp = this.GameT.GetChild(1);
		this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
		this.tmptext_Str[1] = this.Tmp1.GetComponent<UIText>();
		this.tmptext_Str[1].font = this.TTFont;
		this.tmptext_Str[1].text = this.DM.mStringTable.GetStringByID(4733u);
		for (int i = 0; i < 8; i++)
		{
			this.btn_BadgeT[i] = this.Tmp.GetChild(1 + i);
			this.btn_BadgeT[i] = this.Tmp.GetChild(1 + i).GetChild(0);
			this.btn_Badge[i] = this.btn_BadgeT[i].GetComponent<UIButton>();
			this.btn_Badge[i].m_Handler = this;
			this.btn_Badge[i].m_BtnID1 = 1 + i;
			this.btn_Badge[i].m_EffectType = e_EffectType.e_Scale;
			this.btn_Badge[i].transition = Selectable.Transition.None;
			this.tmpImg = this.btn_BadgeT[i].GetComponent<Image>();
			this.tmpString.Length = 0;
			this.tmpString.AppendFormat("UI_league_badge_{0:00}", 1 + i * 8);
			this.tmpImg.sprite = this.GUIM.LoadBadgeSprite(true, this.tmpString.ToString());
			this.tmpImg.material = this.BadgeMaterial;
		}
		this.Img_BadgeFrameT = this.Tmp.GetChild(9);
		this.Img_BadgeFrame = this.Img_BadgeFrameT.GetComponent<Image>();
		this.Img_BadgeFrameRT = this.Img_BadgeFrameT.GetComponent<RectTransform>();
		this.Img_BadgeFrameRT.anchoredPosition = new Vector2(0f, 0f);
		this.Tmp = this.GameT.GetChild(2);
		for (int j = 0; j < 8; j++)
		{
			this.btn_ColorT[j] = this.Tmp.GetChild(j);
			this.btn_Color[j] = this.btn_ColorT[j].GetComponent<UIButton>();
			this.btn_Color[j].m_Handler = this;
			this.btn_Color[j].m_BtnID1 = 9 + j;
			this.btn_Color[j].m_EffectType = e_EffectType.e_Scale;
			this.btn_Color[j].transition = Selectable.Transition.None;
		}
		this.Img_ColorFrameT = this.Tmp.GetChild(8);
		this.Img_ColorFrame = this.Img_ColorFrameT.GetComponent<Image>();
		this.Img_ColorFrameRT = this.Img_ColorFrameT.GetComponent<RectTransform>();
		this.Img_ColorFrameRT.anchoredPosition = new Vector2(1f, 1.5f);
		this.Tmp = this.GameT.GetChild(3);
		this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
		this.tmptext_Str[2] = this.Tmp1.GetComponent<UIText>();
		this.tmptext_Str[2].font = this.TTFont;
		this.tmptext_Str[2].text = this.DM.mStringTable.GetStringByID(4734u);
		this.Tmp1 = this.Tmp.GetChild(1);
		this.m_ScrollPanel = this.Tmp1.GetComponent<ScrollPanel>();
		List<float> list = new List<float>();
		for (int k = 0; k < 8; k++)
		{
			this.Tmp1 = this.Tmp.GetChild(2).GetChild(k);
			this.tmpbtn = this.Tmp1.GetComponent<UIButton>();
			this.tmpbtn.m_Handler = this;
			this.tmpbtn.m_BtnID1 = 17 + k;
			this.tmpbtn.m_EffectType = e_EffectType.e_Scale;
			this.tmpbtn.transition = Selectable.Transition.None;
			list.Add(92f);
			for (int l = 0; l < 8; l++)
			{
				this.tmpString.Length = 0;
				this.tmpString.AppendFormat("UI_league_totem_{0:00}", 1 + k * 8 + l);
				this.m_TotemSprite[k * 8 + l] = this.GUIM.LoadBadgeSprite(false, this.tmpString.ToString());
			}
		}
		this.Img_TotemFrameT = this.Tmp.GetChild(3);
		this.Img_TotemFrame = this.Img_TotemFrameT.GetComponent<Image>();
		this.Img_TotemFrameRT = this.Img_TotemFrameT.GetComponent<RectTransform>();
		this.Img_TotemFrameRT.anchoredPosition = new Vector2(0f, 0f);
		this.m_ScrollPanel.IntiScrollPanel(239f, 0f, 0f, list, 4, this);
		this.Tmp = this.GameT.GetChild(4);
		this.Img_BadgeT = this.Tmp.GetChild(0).GetChild(1);
		this.tmpEmblem = this.DM.CurSelectBadge;
		this.GUIM.InitBadgeTotem(this.Img_BadgeT, this.tmpEmblem);
		if (!this.Img_BadgeT.gameObject.activeSelf)
		{
			this.tmpBadge = UnityEngine.Random.Range(1, 64);
			this.tmpTotem = UnityEngine.Random.Range(1, 64);
			this.GUIM.SetBadgeTotemImg(this.Img_BadgeT, this.tmpBadge, this.tmpTotem);
		}
		else
		{
			int num = (int)(this.tmpEmblem & 7);
			int num2 = this.tmpEmblem >> 3 & 7;
			this.tmpBadge = num2 * 8 + num + 1;
			if (this.tmpBadge > 64)
			{
				this.tmpBadge = 64;
			}
			this.tmpTotem = (this.tmpEmblem >> 6 & 63) + 1;
			if (this.tmpTotem > 64)
			{
				this.tmpTotem = 64;
			}
		}
		this.SetRandomBadgeTotem(this.tmpBadge, this.tmpTotem);
		this.Tmp1 = this.Tmp.GetChild(1);
		this.btn_Random = this.Tmp1.GetComponent<UIButton>();
		this.btn_Random.m_Handler = this;
		this.btn_Random.m_BtnID1 = 25;
		this.btn_Random.m_EffectType = e_EffectType.e_Scale;
		this.btn_Random.transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(2);
		this.btn_Accept = this.Tmp1.GetComponent<UIButton>();
		this.btn_Accept.m_Handler = this;
		this.btn_Accept.m_BtnID1 = 26;
		this.btn_Accept.m_EffectType = e_EffectType.e_Scale;
		this.btn_Accept.transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(2).GetChild(0).GetChild(0);
		this.text_AcceptValue = this.Tmp1.GetComponent<UIText>();
		this.text_AcceptValue.font = this.TTFont;
		this.Tmp1 = this.Tmp.GetChild(2).GetChild(1);
		this.tmptext_Str[3] = this.Tmp1.GetComponent<UIText>();
		this.tmptext_Str[3].font = this.TTFont;
		this.tmptext_Str[3].text = this.DM.mStringTable.GetStringByID(4736u);
		this.Tmp1 = this.Tmp.GetChild(3);
		this.btn_Accept_y = this.Tmp1.GetComponent<UIButton>();
		this.btn_Accept_y.m_Handler = this;
		this.btn_Accept_y.m_BtnID1 = 27;
		this.btn_Accept_y.m_EffectType = e_EffectType.e_Scale;
		this.btn_Accept_y.transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(3).GetChild(0);
		this.tmptext_Str[4] = this.Tmp1.GetComponent<UIText>();
		this.tmptext_Str[4].font = this.TTFont;
		this.tmptext_Str[4].text = this.DM.mStringTable.GetStringByID(4736u);
		if (this.NeedValue != 0u)
		{
			this.bNeed = true;
		}
		if (this.bNeed)
		{
			this.btn_Accept.gameObject.SetActive(true);
			this.tmpString.Length = 0;
			GameConstants.FormatValue(this.tmpString, this.NeedValue);
			this.text_AcceptValue.text = this.tmpString.ToString();
		}
		else
		{
			this.btn_Accept_y.gameObject.SetActive(true);
		}
		this.Tmp1 = this.Tmp.GetChild(4);
		this.tmptext_Str[5] = this.Tmp1.GetComponent<UIText>();
		this.tmptext_Str[5].font = this.TTFont;
		this.tmptext_Str[5].text = this.DM.mStringTable.GetStringByID(4735u);
		this.tmpImg = this.GameT.GetChild(6).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.door.LoadMaterial();
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06000EAD RID: 3757 RVA: 0x001851EC File Offset: 0x001833EC
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.tmpItem[panelObjectIdx] == null)
		{
			this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
			for (int i = 0; i < 8; i++)
			{
				this.Tmp = item.transform.GetChild(i);
				this.tmpbtn = this.Tmp.GetComponent<UIButton>();
				this.tmpbtn.m_Handler = this;
				this.tmpbtn.m_BtnID2 = panelObjectIdx;
				this.Img_Totem[panelObjectIdx * 8 + i] = this.Tmp.GetComponent<Image>();
				this.Img_Totem[panelObjectIdx * 8 + i].sprite = this.m_TotemSprite[dataIdx * 8 + i];
				this.Img_Totem[panelObjectIdx * 8 + i].material = this.TotemMaterial;
			}
		}
		else
		{
			if (panelObjectIdx == this.mTotemIndex)
			{
				this.Img_TotemFrameT.gameObject.SetActive(false);
			}
			for (int j = 0; j < 8; j++)
			{
				this.Img_Totem[panelObjectIdx * 8 + j].sprite = this.m_TotemSprite[dataIdx * 8 + j];
				if (this.mTotem == dataIdx * 8 + j)
				{
					this.Img_TotemFrameT.SetParent(this.Img_Totem[panelObjectIdx * 8 + j].GetComponent<Transform>(), false);
					this.mTotemIndex = panelObjectIdx;
					this.Img_TotemFrameT.gameObject.SetActive(true);
					this.tmpShow[2] = 0f;
				}
			}
		}
	}

	// Token: 0x06000EAE RID: 3758 RVA: 0x00185364 File Offset: 0x00183564
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06000EAF RID: 3759 RVA: 0x00185368 File Offset: 0x00183568
	public override void OnClose()
	{
	}

	// Token: 0x06000EB0 RID: 3760 RVA: 0x0018536C File Offset: 0x0018356C
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
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
			this.mBadge = sender.m_BtnID1 - 1;
			this.Img_BadgeFrameT.SetParent(this.btn_BadgeT[this.mBadge], false);
			this.tmpShow[0] = 0f;
			this.tmpBadge = this.mBadge * 8 + this.mColor + 1;
			this.GUIM.SetBadgeTotemImg(this.Img_BadgeT, this.tmpBadge, this.tmpTotem);
			break;
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
			this.mColor = sender.m_BtnID1 - 9;
			this.Img_ColorFrameT.SetParent(this.btn_ColorT[this.mColor], false);
			this.tmpShow[1] = 0f;
			this.tmpBadge = this.mBadge * 8 + this.mColor + 1;
			for (int i = 0; i < 8; i++)
			{
				this.tmpImg = this.btn_BadgeT[i].GetComponent<Image>();
				this.tmpString.Length = 0;
				this.tmpString.AppendFormat("UI_league_badge_{0:00}", 1 + i * 8 + this.mColor);
				this.tmpImg.sprite = this.GUIM.LoadBadgeSprite(true, this.tmpString.ToString());
			}
			this.GUIM.SetBadgeTotemImg(this.Img_BadgeT, this.tmpBadge, this.tmpTotem);
			break;
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
		case 22:
		case 23:
		case 24:
		{
			Transform parent = sender.gameObject.transform.parent;
			this.Img_TotemFrameT.SetParent(sender.GetComponent<Transform>(), false);
			this.mTotem = parent.GetComponent<ScrollPanelItem>().m_BtnID1 * 8 + sender.m_BtnID1 - 17;
			this.mTotemIndex = parent.GetComponent<ScrollPanelItem>().m_BtnID2;
			this.tmpTotem = this.mTotem + 1;
			if (!this.Img_TotemFrameT.gameObject.activeSelf)
			{
				this.Img_TotemFrameT.gameObject.SetActive(true);
			}
			this.tmpShow[2] = 0f;
			this.GUIM.SetBadgeTotemImg(this.Img_BadgeT, this.tmpBadge, this.tmpTotem);
			break;
		}
		case 25:
			this.tmpBadge = UnityEngine.Random.Range(1, 64);
			this.tmpTotem = UnityEngine.Random.Range(1, 64);
			this.SetRandomBadgeTotem(this.tmpBadge, this.tmpTotem);
			this.GUIM.SetBadgeTotemImg(this.Img_BadgeT, this.tmpBadge, this.tmpTotem);
			break;
		case 26:
		{
			if (this.DM.RoleAttr.Diamond < this.NeedValue)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(3966u), 255, true);
				return;
			}
			ushort num = (ushort)(this.tmpTotem - 1 << 6 | this.tmpBadge - 1);
			if (this.tmpEmblem == num)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4749u), 255, true);
				return;
			}
			if (!this.GUIM.OpenCheckCrystal(this.NeedValue, 5, (int)((int)this.m_eWindow << 16 | EGUIWindow.UI_VipLevelUp), (int)num))
			{
				this.SendModifyEmblem(num);
			}
			break;
		}
		case 27:
			this.DM.CurSelectBadge = (ushort)(this.tmpTotem - 1 << 6 | this.tmpBadge - 1);
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		}
	}

	// Token: 0x06000EB1 RID: 3761 RVA: 0x0018576C File Offset: 0x0018396C
	private void SendModifyEmblem(ushort tmpValue)
	{
		if (GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_EMBLEM;
			messagePacket.AddSeqId();
			messagePacket.Add(tmpValue);
			messagePacket.Send(false);
		}
	}

	// Token: 0x06000EB2 RID: 3762 RVA: 0x001857B8 File Offset: 0x001839B8
	public void SetRandomBadgeTotem(int tmpBadge, int tmpTotem)
	{
		this.mBadge = (tmpBadge - 1) / 8;
		this.mColor = (tmpBadge - 1) % 8;
		this.Img_BadgeFrameT.SetParent(this.btn_BadgeT[this.mBadge], false);
		if (!this.Img_BadgeFrameT.gameObject.activeSelf)
		{
			this.Img_BadgeFrameT.gameObject.SetActive(true);
		}
		this.tmpShow[0] = 0f;
		this.Img_ColorFrameT.SetParent(this.btn_ColorT[this.mColor], false);
		if (!this.Img_ColorFrameT.gameObject.activeSelf)
		{
			this.Img_ColorFrameT.gameObject.SetActive(true);
		}
		this.tmpShow[1] = 0f;
		for (int i = 0; i < 8; i++)
		{
			this.tmpImg = this.btn_BadgeT[i].GetComponent<Image>();
			this.tmpString.Length = 0;
			this.tmpString.AppendFormat("UI_league_badge_{0:00}", 1 + i * 8 + this.mColor);
			this.tmpImg.sprite = this.GUIM.LoadBadgeSprite(true, this.tmpString.ToString());
		}
		this.mTotem = tmpTotem - 1;
		bool flag = false;
		for (int j = 0; j < 4; j++)
		{
			for (int k = 0; k < 8; k++)
			{
				if (this.mTotem == this.tmpItem[j].m_BtnID1 * 8 + k)
				{
					this.Img_TotemFrameT.SetParent(this.Img_Totem[this.tmpItem[j].m_BtnID2 * 8 + k].GetComponent<Transform>(), false);
					this.mTotemIndex = this.tmpItem[j].m_BtnID2;
					flag = true;
				}
			}
		}
		if (flag && !this.Img_TotemFrameT.gameObject.activeSelf)
		{
			this.Img_TotemFrameT.gameObject.SetActive(true);
		}
		else if (!flag)
		{
			this.Img_TotemFrameT.gameObject.SetActive(false);
			this.mTotemIndex = -1;
		}
		this.tmpShow[2] = 0f;
		if (!this.Img_BadgeT.gameObject.activeSelf)
		{
			this.Img_BadgeT.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000EB3 RID: 3763 RVA: 0x001859F4 File Offset: 0x00183BF4
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

	// Token: 0x06000EB4 RID: 3764 RVA: 0x00185A34 File Offset: 0x00183C34
	public void Refresh_FontTexture()
	{
		if (this.text_AcceptValue != null && this.text_AcceptValue.enabled)
		{
			this.text_AcceptValue.enabled = false;
			this.text_AcceptValue.enabled = true;
		}
		for (int i = 0; i < 6; i++)
		{
			if (this.tmptext_Str[i] != null && this.tmptext_Str[i].enabled)
			{
				this.tmptext_Str[i].enabled = false;
				this.tmptext_Str[i].enabled = true;
			}
		}
	}

	// Token: 0x06000EB5 RID: 3765 RVA: 0x00185AD0 File Offset: 0x00183CD0
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 1)
		{
			if (arg1 == 100)
			{
				this.SendModifyEmblem((ushort)arg2);
			}
		}
		else if (this.door != null)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06000EB6 RID: 3766 RVA: 0x00185B24 File Offset: 0x00183D24
	private void Update()
	{
		if (this.Img_BadgeFrame.IsActive())
		{
			this.tmpShow[0] += Time.smoothDeltaTime;
			if (this.tmpShow[0] >= 2f)
			{
				this.tmpShow[0] = 0f;
			}
			float a = (this.tmpShow[0] <= 1f) ? this.tmpShow[0] : (2f - this.tmpShow[0]);
			this.Img_BadgeFrame.color = new Color(1f, 1f, 1f, a);
		}
		if (this.Img_ColorFrame.IsActive())
		{
			this.tmpShow[1] += Time.smoothDeltaTime;
			if (this.tmpShow[1] >= 2f)
			{
				this.tmpShow[1] = 0f;
			}
			float a2 = (this.tmpShow[1] <= 1f) ? this.tmpShow[1] : (2f - this.tmpShow[1]);
			this.Img_ColorFrame.color = new Color(1f, 1f, 1f, a2);
		}
		if (this.Img_TotemFrame.IsActive())
		{
			this.tmpShow[2] += Time.smoothDeltaTime;
			if (this.tmpShow[2] >= 2f)
			{
				this.tmpShow[2] = 0f;
			}
			float a3 = (this.tmpShow[2] <= 1f) ? this.tmpShow[2] : (2f - this.tmpShow[2]);
			this.Img_TotemFrame.color = new Color(1f, 1f, 1f, a3);
		}
	}

	// Token: 0x04002F57 RID: 12119
	private Transform GameT;

	// Token: 0x04002F58 RID: 12120
	private Transform Tmp;

	// Token: 0x04002F59 RID: 12121
	private Transform Tmp1;

	// Token: 0x04002F5A RID: 12122
	private Transform Img_BadgeT;

	// Token: 0x04002F5B RID: 12123
	private Transform Img_BadgeFrameT;

	// Token: 0x04002F5C RID: 12124
	private Transform Img_ColorFrameT;

	// Token: 0x04002F5D RID: 12125
	private Transform Img_TotemFrameT;

	// Token: 0x04002F5E RID: 12126
	private Transform[] btn_BadgeT = new Transform[8];

	// Token: 0x04002F5F RID: 12127
	private Transform[] btn_ColorT = new Transform[8];

	// Token: 0x04002F60 RID: 12128
	private RectTransform Img_BadgeFrameRT;

	// Token: 0x04002F61 RID: 12129
	private RectTransform Img_ColorFrameRT;

	// Token: 0x04002F62 RID: 12130
	private RectTransform Img_TotemFrameRT;

	// Token: 0x04002F63 RID: 12131
	private UIButton btn_EXIT;

	// Token: 0x04002F64 RID: 12132
	private UIButton[] btn_Badge = new UIButton[8];

	// Token: 0x04002F65 RID: 12133
	private UIButton[] btn_Color = new UIButton[8];

	// Token: 0x04002F66 RID: 12134
	private UIButton btn_Random;

	// Token: 0x04002F67 RID: 12135
	private UIButton btn_Accept;

	// Token: 0x04002F68 RID: 12136
	private UIButton btn_Accept_y;

	// Token: 0x04002F69 RID: 12137
	private UIButton tmpbtn;

	// Token: 0x04002F6A RID: 12138
	private Image Img_BadgeFrame;

	// Token: 0x04002F6B RID: 12139
	private Image Img_ColorFrame;

	// Token: 0x04002F6C RID: 12140
	private Image Img_TotemFrame;

	// Token: 0x04002F6D RID: 12141
	private Image tmpImg;

	// Token: 0x04002F6E RID: 12142
	private Image[] Img_Totem = new Image[32];

	// Token: 0x04002F6F RID: 12143
	private Sprite[] m_TotemSprite = new Sprite[64];

	// Token: 0x04002F70 RID: 12144
	private UIText text_AcceptValue;

	// Token: 0x04002F71 RID: 12145
	private UIText[] tmptext_Str = new UIText[6];

	// Token: 0x04002F72 RID: 12146
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04002F73 RID: 12147
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[4];

	// Token: 0x04002F74 RID: 12148
	private StringBuilder tmpString = new StringBuilder();

	// Token: 0x04002F75 RID: 12149
	private DataManager DM;

	// Token: 0x04002F76 RID: 12150
	private GUIManager GUIM;

	// Token: 0x04002F77 RID: 12151
	private Font TTFont;

	// Token: 0x04002F78 RID: 12152
	private Door door;

	// Token: 0x04002F79 RID: 12153
	private Material BadgeMaterial;

	// Token: 0x04002F7A RID: 12154
	private Material TotemMaterial;

	// Token: 0x04002F7B RID: 12155
	private int mTotem;

	// Token: 0x04002F7C RID: 12156
	private int mTotemIndex;

	// Token: 0x04002F7D RID: 12157
	private int mBadge;

	// Token: 0x04002F7E RID: 12158
	private int mColor;

	// Token: 0x04002F7F RID: 12159
	private bool bNeed;

	// Token: 0x04002F80 RID: 12160
	private uint NeedValue;

	// Token: 0x04002F81 RID: 12161
	private int tmpBadge;

	// Token: 0x04002F82 RID: 12162
	private int tmpTotem;

	// Token: 0x04002F83 RID: 12163
	private ushort tmpEmblem;

	// Token: 0x04002F84 RID: 12164
	private float[] tmpShow = new float[3];
}
