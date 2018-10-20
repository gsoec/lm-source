using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000338 RID: 824
public class UIArena_I : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x060010C8 RID: 4296 RVA: 0x001DE0D0 File Offset: 0x001DC2D0
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		Material material = this.door.LoadMaterial();
		float num = 0f;
		this.Cstr_CDTime = StringManager.Instance.SpawnString(100);
		this.tmpItemNum = this.DM.ArenaRewardData.TableCount;
		this.Cstr_P2 = new CString[this.tmpItemNum];
		this.Cstr_P2Reward = new CString[this.tmpItemNum];
		this.text_P2 = new UIText[this.tmpItemNum * 2];
		for (int i = 0; i < this.tmpItemNum; i++)
		{
			this.Cstr_P2[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_P2Reward[i] = StringManager.Instance.SpawnString(30);
		}
		Transform child = this.GameT.GetChild(0);
		Transform child2 = child.GetChild(0).GetChild(0);
		this.text_Title = child2.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(9128u);
		child = this.GameT.GetChild(1);
		child2 = child.GetChild(0);
		this.Content_RT = child2.GetComponent<RectTransform>();
		child2 = child.GetChild(0).GetChild(0);
		this.P1_RT = child2.GetComponent<RectTransform>();
		Transform child3 = child2.GetChild(0);
		this.text_TitleP1[0] = child3.GetComponent<UIText>();
		this.text_TitleP1[0].font = this.TTFont;
		this.text_TitleP1[0].text = this.DM.mStringTable.GetStringByID(9129u);
		num += this.text_TitleP1[0].rectTransform.sizeDelta.y;
		for (int j = 0; j < 5; j++)
		{
			child3 = child2.GetChild(1 + j);
			this.text_P1[j] = child3.GetComponent<UIText>();
			this.text_P1[j].font = this.TTFont;
			this.text_P1[j].text = this.DM.mStringTable.GetStringByID((uint)(9130 + j));
			this.text_P1[j].SetAllDirty();
			this.text_P1[j].cachedTextGenerator.Invalidate();
			this.text_P1[j].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_P1[j].rectTransform.sizeDelta.y < this.text_P1[j].preferredHeight)
			{
				this.text_P1[j].rectTransform.sizeDelta = new Vector2(this.text_P1[j].rectTransform.sizeDelta.x, this.text_P1[j].preferredHeight + 1f);
			}
			if (j == 0)
			{
				this.text_P1[0].rectTransform.anchoredPosition = new Vector2(this.text_P1[0].rectTransform.anchoredPosition.x, -(12f + num));
			}
			else
			{
				this.text_P1[j].rectTransform.anchoredPosition = new Vector2(this.text_P1[j].rectTransform.anchoredPosition.x, this.text_P1[j - 1].rectTransform.anchoredPosition.y - this.text_P1[j - 1].rectTransform.sizeDelta.y - 2f);
			}
			num += this.text_P1[j].rectTransform.sizeDelta.y;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		this.Cstr_CDTime.ClearString();
		cstring.IntToFormat((long)GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Hour, 2, false);
		cstring.IntToFormat((long)GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Minute, 2, false);
		cstring.AppendFormat("{0}:{1}");
		this.Cstr_CDTime.StringToFormat(cstring);
		this.Cstr_CDTime.AppendFormat(this.DM.mStringTable.GetStringByID(9134u));
		this.text_P1[4].text = this.Cstr_CDTime.ToString();
		child3 = child2.GetChild(6);
		this.text_P1[5] = child3.GetComponent<UIText>();
		this.text_P1[5].font = this.TTFont;
		this.text_P1[5].text = this.DM.mStringTable.GetStringByID(9135u);
		if (this.text_P1[5].rectTransform.sizeDelta.y < this.text_P1[5].preferredHeight)
		{
			this.text_P1[5].rectTransform.sizeDelta = new Vector2(this.text_P1[5].rectTransform.sizeDelta.x, this.text_P1[5].preferredHeight + 1f);
		}
		this.text_P1[5].rectTransform.anchoredPosition = new Vector2(this.text_P1[5].rectTransform.anchoredPosition.x, this.text_P1[4].rectTransform.anchoredPosition.y - this.text_P1[4].rectTransform.sizeDelta.y - 2f);
		num += this.text_P1[5].rectTransform.sizeDelta.y;
		child3 = child2.GetChild(7);
		this.text_TitleP1[1] = child3.GetComponent<UIText>();
		this.text_TitleP1[1].font = this.TTFont;
		this.text_TitleP1[1].text = this.DM.mStringTable.GetStringByID(9151u);
		this.text_TitleP1[1].rectTransform.anchoredPosition = new Vector2(this.text_TitleP1[1].rectTransform.anchoredPosition.x, this.text_P1[5].rectTransform.anchoredPosition.y - this.text_P1[5].rectTransform.sizeDelta.y - 20f);
		num += this.text_TitleP1[1].rectTransform.sizeDelta.y;
		child3 = child2.GetChild(8);
		this.text_P1[6] = child3.GetComponent<UIText>();
		this.text_P1[6].font = this.TTFont;
		this.text_P1[6].text = this.DM.mStringTable.GetStringByID(9136u);
		this.text_P1[6].SetAllDirty();
		this.text_P1[6].cachedTextGenerator.Invalidate();
		this.text_P1[6].cachedTextGeneratorForLayout.Invalidate();
		if (this.text_P1[6].rectTransform.sizeDelta.y < this.text_P1[6].preferredHeight)
		{
			this.text_P1[6].rectTransform.sizeDelta = new Vector2(this.text_P1[6].rectTransform.sizeDelta.x, this.text_P1[6].preferredHeight + 1f);
		}
		this.text_P1[6].rectTransform.anchoredPosition = new Vector2(this.text_P1[6].rectTransform.anchoredPosition.x, this.text_TitleP1[1].rectTransform.anchoredPosition.y - this.text_TitleP1[1].rectTransform.sizeDelta.y + 2f);
		num += this.text_P1[6].rectTransform.sizeDelta.y;
		num += 60f;
		this.P1_RT.sizeDelta = new Vector2(this.P1_RT.sizeDelta.x, num);
		this.Content_RT.sizeDelta = new Vector2(this.Content_RT.sizeDelta.x, num);
		child2 = child.GetChild(0).GetChild(1);
		this.P2_RT = child2.GetComponent<RectTransform>();
		this.P2_RT.anchoredPosition = new Vector2(this.P2_RT.anchoredPosition.x, -num);
		num = 0f;
		child3 = child2.GetChild(0);
		num += child3.GetComponent<RectTransform>().sizeDelta.y;
		child3 = child2.GetChild(0).GetChild(0);
		this.text_TitleP2[0] = child3.GetComponent<UIText>();
		this.text_TitleP2[0].font = this.TTFont;
		this.text_TitleP2[0].text = this.DM.mStringTable.GetStringByID(9137u);
		child3 = child2.GetChild(1).GetChild(0);
		this.text_TitleP2[1] = child3.GetComponent<UIText>();
		this.text_TitleP2[1].font = this.TTFont;
		this.text_TitleP2[1].text = this.DM.mStringTable.GetStringByID(9140u);
		child3 = child2.GetChild(2);
		Image component = child3.GetComponent<Image>();
		Image component3;
		for (int k = 0; k < this.tmpItemNum; k++)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(component.gameObject);
			gameObject.transform.SetParent(this.P2_RT.transform, false);
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2(component.rectTransform.anchoredPosition.x, -num);
			gameObject.SetActive(true);
			num += component.rectTransform.sizeDelta.y;
			if (k % 2 == 1)
			{
				component3 = gameObject.transform.GetComponent<Image>();
				component3.sprite = this.SArray.m_Sprites[0];
				component3 = gameObject.transform.GetChild(0).GetComponent<Image>();
				component3.sprite = this.SArray.m_Sprites[1];
			}
			for (int l = 0; l < 2; l++)
			{
				child3 = gameObject.transform.GetChild(2 + l);
				this.text_P2[k * 2 + l] = child3.GetComponent<UIText>();
				this.text_P2[k * 2 + l].font = this.TTFont;
			}
		}
		this.P2_RT.sizeDelta = new Vector2(this.P2_RT.sizeDelta.x, num);
		this.Content_RT.sizeDelta = new Vector2(this.Content_RT.sizeDelta.x, this.Content_RT.sizeDelta.y + num);
		ArenaReward recordByIndex = this.DM.ArenaRewardData.GetRecordByIndex(0);
		for (int m = 0; m < this.tmpItemNum; m++)
		{
			this.Cstr_P2[m].ClearString();
			recordByIndex = this.DM.ArenaRewardData.GetRecordByIndex((int)((ushort)m));
			if (recordByIndex.Value1 == recordByIndex.Value2)
			{
				this.Cstr_P2[m].IntToFormat((long)recordByIndex.Value1, 1, true);
				this.Cstr_P2[m].AppendFormat(this.DM.mStringTable.GetStringByID(9138u));
			}
			else
			{
				this.Cstr_P2[m].IntToFormat((long)recordByIndex.Value1, 1, true);
				this.Cstr_P2[m].IntToFormat((long)recordByIndex.Value2, 1, true);
				this.Cstr_P2[m].AppendFormat(this.DM.mStringTable.GetStringByID(9139u));
			}
			this.text_P2[m * 2].text = this.Cstr_P2[m].ToString();
			this.Cstr_P2Reward[m].ClearString();
			this.Cstr_P2Reward[m].IntToFormat((long)recordByIndex.Crystal, 1, true);
			this.Cstr_P2Reward[m].AppendFormat("{0}");
			this.text_P2[m * 2 + 1].text = this.Cstr_P2Reward[m].ToString();
		}
		child = this.GameT.GetChild(2);
		component3 = child.GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_close_base");
		component3.material = material;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component3.enabled = false;
		}
		child = this.GameT.GetChild(2).GetChild(0);
		this.btn_EXIT = child.GetComponent<UIButton>();
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = material;
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x060010C9 RID: 4297 RVA: 0x001DEEA4 File Offset: 0x001DD0A4
	public override void OnClose()
	{
		if (this.Cstr_CDTime != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_CDTime);
		}
		for (int i = 0; i < this.tmpItemNum; i++)
		{
			if (this.Cstr_P2[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_P2[i]);
			}
			if (this.Cstr_P2Reward[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_P2Reward[i]);
			}
		}
	}

	// Token: 0x060010CA RID: 4298 RVA: 0x001DEF24 File Offset: 0x001DD124
	public void OnButtonClick(UIButton sender)
	{
		GUIArena_Info btnID = (GUIArena_Info)sender.m_BtnID1;
		if (btnID == GUIArena_Info.btn_EXIT)
		{
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x060010CB RID: 4299 RVA: 0x001DEF68 File Offset: 0x001DD168
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
		}
	}

	// Token: 0x060010CC RID: 4300 RVA: 0x001DEFA0 File Offset: 0x001DD1A0
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_TitleP1[i] != null && this.text_TitleP1[i].enabled)
			{
				this.text_TitleP1[i].enabled = false;
				this.text_TitleP1[i].enabled = true;
			}
			if (this.text_TitleP2[i] != null && this.text_TitleP2[i].enabled)
			{
				this.text_TitleP2[i].enabled = false;
				this.text_TitleP2[i].enabled = true;
			}
		}
		for (int j = 0; j < this.tmpItemNum * 2; j++)
		{
			if (this.text_P2[j] != null && this.text_P2[j].enabled)
			{
				this.text_P2[j].enabled = false;
				this.text_P2[j].enabled = true;
			}
		}
		for (int k = 0; k < 7; k++)
		{
			if (this.text_P1[k] != null && this.text_P1[k].enabled)
			{
				this.text_P1[k].enabled = false;
				this.text_P1[k].enabled = true;
			}
		}
	}

	// Token: 0x060010CD RID: 4301 RVA: 0x001DF128 File Offset: 0x001DD328
	private void Start()
	{
	}

	// Token: 0x060010CE RID: 4302 RVA: 0x001DF12C File Offset: 0x001DD32C
	private void Update()
	{
	}

	// Token: 0x040036C6 RID: 14022
	private DataManager DM;

	// Token: 0x040036C7 RID: 14023
	private GUIManager GUIM;

	// Token: 0x040036C8 RID: 14024
	private Transform GameT;

	// Token: 0x040036C9 RID: 14025
	private Door door;

	// Token: 0x040036CA RID: 14026
	private Font TTFont;

	// Token: 0x040036CB RID: 14027
	private UISpritesArray SArray;

	// Token: 0x040036CC RID: 14028
	private RectTransform Content_RT;

	// Token: 0x040036CD RID: 14029
	private RectTransform P1_RT;

	// Token: 0x040036CE RID: 14030
	private RectTransform P2_RT;

	// Token: 0x040036CF RID: 14031
	private UIButton btn_EXIT;

	// Token: 0x040036D0 RID: 14032
	private UIText text_Title;

	// Token: 0x040036D1 RID: 14033
	private UIText[] text_TitleP1 = new UIText[2];

	// Token: 0x040036D2 RID: 14034
	private UIText[] text_P1 = new UIText[7];

	// Token: 0x040036D3 RID: 14035
	private UIText[] text_TitleP2 = new UIText[2];

	// Token: 0x040036D4 RID: 14036
	private UIText[] text_P2;

	// Token: 0x040036D5 RID: 14037
	private CString Cstr_CDTime;

	// Token: 0x040036D6 RID: 14038
	private CString[] Cstr_P2;

	// Token: 0x040036D7 RID: 14039
	private CString[] Cstr_P2Reward;

	// Token: 0x040036D8 RID: 14040
	private int tmpItemNum;
}
