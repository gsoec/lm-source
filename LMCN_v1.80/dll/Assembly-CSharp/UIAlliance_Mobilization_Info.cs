using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000314 RID: 788
public class UIAlliance_Mobilization_Info : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001014 RID: 4116 RVA: 0x001C7750 File Offset: 0x001C5950
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
		this.tmpItemNum = (int)this.DM.RoleAlliance.AMMaxDegree;
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
		this.text_Title.text = this.DM.mStringTable.GetStringByID(1380u);
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
		for (int j = 0; j < 6; j++)
		{
			child3 = child2.GetChild(1 + j);
			this.text_P1[j] = child3.GetComponent<UIText>();
			this.text_P1[j].font = this.TTFont;
			this.text_P1[j].text = this.DM.mStringTable.GetStringByID((uint)(1381 + j));
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
		child3 = child2.GetChild(7);
		this.text_P1[6] = child3.GetComponent<UIText>();
		this.text_P1[6].font = this.TTFont;
		this.text_P1[6].text = this.DM.mStringTable.GetStringByID(17251u);
		this.text_P1[6].SetAllDirty();
		this.text_P1[6].cachedTextGenerator.Invalidate();
		this.text_P1[6].cachedTextGeneratorForLayout.Invalidate();
		if (this.text_P1[6].rectTransform.sizeDelta.y < this.text_P1[6].preferredHeight)
		{
			this.text_P1[6].rectTransform.sizeDelta = new Vector2(this.text_P1[6].rectTransform.sizeDelta.x, this.text_P1[6].preferredHeight + 1f);
		}
		this.text_P1[6].rectTransform.anchoredPosition = new Vector2(this.text_P1[6].rectTransform.anchoredPosition.x, this.text_P1[5].rectTransform.anchoredPosition.y - this.text_P1[5].rectTransform.sizeDelta.y - 2f);
		num += this.text_P1[6].rectTransform.sizeDelta.y;
		child3 = child2.GetChild(8);
		this.text_RankInfo[0] = child3.GetComponent<UIText>();
		this.text_RankInfo[0].font = this.TTFont;
		this.text_RankInfo[0].text = this.DM.mStringTable.GetStringByID(3692u);
		this.text_RankInfo[0].rectTransform.anchoredPosition = new Vector2(this.text_RankInfo[0].rectTransform.anchoredPosition.x, this.text_P1[6].rectTransform.anchoredPosition.y - this.text_P1[6].rectTransform.sizeDelta.y - 20f);
		num += this.text_RankInfo[0].rectTransform.sizeDelta.y;
		for (int k = 1; k < 6; k++)
		{
			child3 = child2.GetChild(8 + k);
			this.text_RankInfo[k] = child3.GetComponent<UIText>();
			this.text_RankInfo[k].font = this.TTFont;
			this.text_RankInfo[k].text = this.DM.mStringTable.GetStringByID((uint)(3692 + k));
			this.text_RankInfo[k].SetAllDirty();
			this.text_RankInfo[k].cachedTextGenerator.Invalidate();
			this.text_RankInfo[k].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_RankInfo[k].rectTransform.sizeDelta.y < this.text_RankInfo[k].preferredHeight)
			{
				this.text_RankInfo[k].rectTransform.sizeDelta = new Vector2(this.text_RankInfo[k].rectTransform.sizeDelta.x, this.text_RankInfo[k].preferredHeight + 1f);
			}
			this.text_RankInfo[k].rectTransform.anchoredPosition = new Vector2(this.text_RankInfo[k].rectTransform.anchoredPosition.x, this.text_RankInfo[k - 1].rectTransform.anchoredPosition.y - this.text_RankInfo[k - 1].rectTransform.sizeDelta.y - 2f);
			num += this.text_RankInfo[k].rectTransform.sizeDelta.y;
		}
		for (int l = 6; l < 11; l++)
		{
			child3 = child2.GetChild(8 + l);
			this.text_RankInfo[l] = child3.GetComponent<UIText>();
			this.text_RankInfo[l].font = this.TTFont;
			this.text_RankInfo[l].text = this.DM.mStringTable.GetStringByID((uint)(3692 + l));
			this.text_RankInfo[l].SetAllDirty();
			this.text_RankInfo[l].cachedTextGenerator.Invalidate();
			this.text_RankInfo[l].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_RankInfo[l].rectTransform.sizeDelta.y < this.text_RankInfo[l].preferredHeight)
			{
				this.text_RankInfo[l].rectTransform.sizeDelta = new Vector2(this.text_RankInfo[l].rectTransform.sizeDelta.x, this.text_RankInfo[l].preferredHeight + 1f);
			}
			this.text_RankInfo[l].rectTransform.anchoredPosition = new Vector2(this.text_RankInfo[l].rectTransform.anchoredPosition.x, this.text_RankInfo[l - 1].rectTransform.anchoredPosition.y - this.text_RankInfo[l - 1].rectTransform.sizeDelta.y - 2f);
			num += this.text_RankInfo[l].rectTransform.sizeDelta.y;
		}
		child3 = child2.GetChild(19);
		this.text_TitleP1[1] = child3.GetComponent<UIText>();
		this.text_TitleP1[1].font = this.TTFont;
		this.text_TitleP1[1].text = this.DM.mStringTable.GetStringByID(9151u);
		this.text_TitleP1[1].rectTransform.anchoredPosition = new Vector2(this.text_TitleP1[1].rectTransform.anchoredPosition.x, this.text_RankInfo[10].rectTransform.anchoredPosition.y - this.text_RankInfo[10].rectTransform.sizeDelta.y - 20f);
		num += this.text_TitleP1[1].rectTransform.sizeDelta.y;
		child3 = child2.GetChild(20);
		this.text_P1[7] = child3.GetComponent<UIText>();
		this.text_P1[7].font = this.TTFont;
		this.text_P1[7].text = this.DM.mStringTable.GetStringByID(1389u);
		this.text_P1[7].SetAllDirty();
		this.text_P1[7].cachedTextGenerator.Invalidate();
		this.text_P1[7].cachedTextGeneratorForLayout.Invalidate();
		if (this.text_P1[7].rectTransform.sizeDelta.y < this.text_P1[7].preferredHeight)
		{
			this.text_P1[7].rectTransform.sizeDelta = new Vector2(this.text_P1[7].rectTransform.sizeDelta.x, this.text_P1[7].preferredHeight + 1f);
		}
		this.text_P1[7].rectTransform.anchoredPosition = new Vector2(this.text_P1[7].rectTransform.anchoredPosition.x, this.text_TitleP1[1].rectTransform.anchoredPosition.y - this.text_TitleP1[1].rectTransform.sizeDelta.y + 2f);
		num += this.text_P1[7].rectTransform.sizeDelta.y;
		child3 = child2.GetChild(21);
		this.text_P1[8] = child3.GetComponent<UIText>();
		this.text_P1[8].font = this.TTFont;
		this.text_P1[8].text = this.DM.mStringTable.GetStringByID(1390u);
		this.text_P1[8].SetAllDirty();
		this.text_P1[8].cachedTextGenerator.Invalidate();
		this.text_P1[8].cachedTextGeneratorForLayout.Invalidate();
		if (this.text_P1[8].rectTransform.sizeDelta.y < this.text_P1[8].preferredHeight)
		{
			this.text_P1[8].rectTransform.sizeDelta = new Vector2(this.text_P1[8].rectTransform.sizeDelta.x, this.text_P1[8].preferredHeight + 1f);
		}
		this.text_P1[8].rectTransform.anchoredPosition = new Vector2(this.text_P1[8].rectTransform.anchoredPosition.x, this.text_P1[7].rectTransform.anchoredPosition.y - this.text_P1[7].rectTransform.sizeDelta.y + 2f);
		num += this.text_P1[8].rectTransform.sizeDelta.y;
		num += 80f;
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
		this.text_TitleP2[0].text = this.DM.mStringTable.GetStringByID(1442u);
		child3 = child2.GetChild(1).GetChild(0);
		this.text_TitleP2[1] = child3.GetComponent<UIText>();
		this.text_TitleP2[1].font = this.TTFont;
		this.text_TitleP2[1].text = this.DM.mStringTable.GetStringByID(1443u);
		child3 = child2.GetChild(2);
		Image component = child3.GetComponent<Image>();
		Image component3;
		for (int m = 0; m < this.tmpItemNum; m++)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(component.gameObject);
			gameObject.transform.SetParent(this.P2_RT.transform, false);
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2(component.rectTransform.anchoredPosition.x, -num);
			gameObject.SetActive(true);
			num += component.rectTransform.sizeDelta.y;
			if (m % 2 == 1)
			{
				component3 = gameObject.transform.GetComponent<Image>();
				component3.sprite = this.SArray.m_Sprites[0];
				component3 = gameObject.transform.GetChild(0).GetComponent<Image>();
				component3.sprite = this.SArray.m_Sprites[1];
			}
			for (int n = 0; n < 2; n++)
			{
				child3 = gameObject.transform.GetChild(1 + n);
				this.text_P2[m * 2 + n] = child3.GetComponent<UIText>();
				this.text_P2[m * 2 + n].font = this.TTFont;
			}
		}
		this.P2_RT.sizeDelta = new Vector2(this.P2_RT.sizeDelta.x, num);
		this.Content_RT.sizeDelta = new Vector2(this.Content_RT.sizeDelta.x, this.Content_RT.sizeDelta.y + num);
		this.tmpDegreeData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex(0);
		for (int num2 = 0; num2 < this.tmpItemNum; num2++)
		{
			this.Cstr_P2[num2].ClearString();
			this.tmpDegreeData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int)((ushort)num2));
			this.Cstr_P2[num2].IntToFormat((long)this.tmpDegreeData.MissionDegreeKey, 1, true);
			this.Cstr_P2[num2].AppendFormat("{0}");
			this.text_P2[num2 * 2].text = this.Cstr_P2[num2].ToString();
			this.Cstr_P2Reward[num2].ClearString();
			this.Cstr_P2Reward[num2].IntToFormat((long)((ulong)this.tmpDegreeData.MissionDegreeScore), 1, true);
			this.Cstr_P2Reward[num2].AppendFormat("{0}");
			this.text_P2[num2 * 2 + 1].text = this.Cstr_P2Reward[num2].ToString();
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

	// Token: 0x06001015 RID: 4117 RVA: 0x001C89CC File Offset: 0x001C6BCC
	public override void OnClose()
	{
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

	// Token: 0x06001016 RID: 4118 RVA: 0x001C8A30 File Offset: 0x001C6C30
	public void OnButtonClick(UIButton sender)
	{
		Mobilization_Info btnID = (Mobilization_Info)sender.m_BtnID1;
		if (btnID == Mobilization_Info.btn_EXIT)
		{
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x06001017 RID: 4119 RVA: 0x001C8A74 File Offset: 0x001C6C74
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

	// Token: 0x06001018 RID: 4120 RVA: 0x001C8AAC File Offset: 0x001C6CAC
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
		for (int k = 0; k < 9; k++)
		{
			if (this.text_P1[k] != null && this.text_P1[k].enabled)
			{
				this.text_P1[k].enabled = false;
				this.text_P1[k].enabled = true;
			}
		}
		for (int l = 0; l < 11; l++)
		{
			if (this.text_RankInfo[l] != null && this.text_RankInfo[l].enabled)
			{
				this.text_RankInfo[l].enabled = false;
				this.text_RankInfo[l].enabled = true;
			}
		}
	}

	// Token: 0x06001019 RID: 4121 RVA: 0x001C8C88 File Offset: 0x001C6E88
	private void Start()
	{
	}

	// Token: 0x0600101A RID: 4122 RVA: 0x001C8C8C File Offset: 0x001C6E8C
	private void Update()
	{
	}

	// Token: 0x040034A9 RID: 13481
	private DataManager DM;

	// Token: 0x040034AA RID: 13482
	private GUIManager GUIM;

	// Token: 0x040034AB RID: 13483
	private Transform GameT;

	// Token: 0x040034AC RID: 13484
	private Door door;

	// Token: 0x040034AD RID: 13485
	private Font TTFont;

	// Token: 0x040034AE RID: 13486
	private UISpritesArray SArray;

	// Token: 0x040034AF RID: 13487
	private RectTransform Content_RT;

	// Token: 0x040034B0 RID: 13488
	private RectTransform P1_RT;

	// Token: 0x040034B1 RID: 13489
	private RectTransform P2_RT;

	// Token: 0x040034B2 RID: 13490
	private UIButton btn_EXIT;

	// Token: 0x040034B3 RID: 13491
	private UIText text_Title;

	// Token: 0x040034B4 RID: 13492
	private UIText[] text_TitleP1 = new UIText[2];

	// Token: 0x040034B5 RID: 13493
	private UIText[] text_P1 = new UIText[9];

	// Token: 0x040034B6 RID: 13494
	private UIText[] text_TitleP2 = new UIText[2];

	// Token: 0x040034B7 RID: 13495
	private UIText[] text_P2;

	// Token: 0x040034B8 RID: 13496
	private UIText[] text_RankInfo = new UIText[11];

	// Token: 0x040034B9 RID: 13497
	private CString[] Cstr_P2;

	// Token: 0x040034BA RID: 13498
	private CString[] Cstr_P2Reward;

	// Token: 0x040034BB RID: 13499
	private int tmpItemNum;

	// Token: 0x040034BC RID: 13500
	private MobilizationDegreeData tmpDegreeData;
}
