using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200053D RID: 1341
public class UIDefenders : GUIWindow, IUIButtonClickHandler, IUIHIBtnClickHandler
{
	// Token: 0x06001AAB RID: 6827 RVA: 0x002D5AC4 File Offset: 0x002D3CC4
	public override void OnOpen(int arg1, int arg2)
	{
		this.CanSelectNum = 0;
		this.SelectNum = 0;
		GUIManager instance = GUIManager.Instance;
		DataManager instance2 = DataManager.Instance;
		this.TTF = instance.GetTTFFont();
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		if (!this.door)
		{
			return;
		}
		this.MaxDefender = instance2.GetMaxDefenders();
		this.m_SpArray = base.transform.GetComponent<UISpritesArray>();
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(0).GetChild(8).GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		this.m_tmptext[this.mTextCount].text = DataManager.Instance.mStringTable.GetStringByID(3744u);
		this.mTextCount++;
		Image component = base.transform.GetChild(4).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && component)
		{
			component.enabled = false;
		}
		UIButton component2 = base.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 0;
		component2.image.sprite = this.door.LoadSprite("UI_main_close");
		component2.image.material = this.door.LoadMaterial();
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(1).GetChild(2).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		this.m_tmptext[this.mTextCount].text = instance2.mStringTable.GetStringByID(3752u);
		this.mTextCount++;
		this.m_FlashLord = base.transform.GetChild(3).GetChild(0).GetComponent<Image>();
		this.SetData();
	}

	// Token: 0x06001AAC RID: 6828 RVA: 0x002D5CF4 File Offset: 0x002D3EF4
	private void SetData()
	{
		GUIManager instance = GUIManager.Instance;
		DataManager instance2 = DataManager.Instance;
		this.CheckFight();
		int i = 0;
		while (i < 5)
		{
			Transform child = base.transform.GetChild(2).GetChild(i);
			UIHIBtn component = child.GetChild(1).GetComponent<UIHIBtn>();
			component.m_BtnID1 = i;
			component.m_Handler = this;
			this.m_HiBtn[i] = component;
			UIButton component2 = child.GetChild(2).GetChild(0).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 1;
			if (i < this.MaxDefender)
			{
				if (instance2.m_DefendersID[i] != 0)
				{
					if (!DataManager.Instance.curHeroData.ContainsKey((uint)instance2.m_DefendersID[i]))
					{
						goto IL_49F;
					}
					CurHeroData curHeroData = instance2.curHeroData[(uint)instance2.m_DefendersID[i]];
					Hero recordByKey = instance2.HeroTable.GetRecordByKey(curHeroData.ID);
					UIHIBtn component3 = child.GetChild(1).GetComponent<UIHIBtn>();
					instance.InitianHeroItemImg(component3.transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level, true, false, true, false);
					this.m_HeroTextTemp1[i] = child.GetChild(4).GetChild(0).GetComponent<UIText>();
					this.m_HeroTextTemp1[i] = child.GetChild(4).GetChild(0).GetComponent<UIText>();
					this.m_HeroTextTemp1[i].font = this.TTF;
					this.m_HeroTextTemp1[i].text = instance2.mStringTable.GetStringByID((uint)recordByKey.HeroTitle);
					eHeroState heroState = instance2.GetHeroState(recordByKey.HeroKey);
					Image component4 = child.GetChild(6).GetComponent<Image>();
					if (heroState == eHeroState.None)
					{
						component4.enabled = false;
						component3.HIImage.color = new Color(1f, 1f, 1f, 1f);
						component3.CircleImage.color = new Color(1f, 1f, 1f, 1f);
						component3.HeroRankImage.color = new Color(1f, 1f, 1f, 1f);
						component3.LvOrNum.color = new Color(1f, 1f, 1f, 1f);
					}
					else
					{
						if (heroState == eHeroState.IsFighting)
						{
							component4.sprite = this.m_SpArray.GetSprite(0);
						}
						if (heroState == eHeroState.Captured)
						{
							component4.sprite = this.m_SpArray.GetSprite(1);
						}
						if (heroState == eHeroState.Dead)
						{
							component4.sprite = this.m_SpArray.GetSprite(2);
						}
						component3.HIImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
						component3.CircleImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
						component3.HeroRankImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
						component3.LvOrNum.color = new Color(0.5f, 0.5f, 0.5f, 1f);
						component4.enabled = true;
					}
					this.SelectNum++;
				}
				else
				{
					child.GetChild(1).gameObject.SetActive(false);
					child.GetChild(4).gameObject.SetActive(false);
					child.GetChild(2).gameObject.SetActive(true);
					child.GetChild(2).GetComponent<Image>().material = instance.GetFrameMaterial();
					child.GetChild(2).GetComponent<Image>().sprite = instance.LoadFrameSprite("hf000");
					component2 = child.GetChild(2).GetChild(0).GetComponent<UIButton>();
					component2.m_BtnID1 = 1;
					component2.m_Handler = this;
				}
				goto IL_470;
			}
			child.GetChild(1).gameObject.SetActive(false);
			child.GetChild(4).gameObject.SetActive(false);
			child.GetChild(3).gameObject.SetActive(true);
			child.GetChild(3).GetComponent<Image>().material = instance.GetFrameMaterial();
			child.GetChild(3).GetComponent<Image>().sprite = instance.LoadFrameSprite("hf000");
			component2 = child.GetChild(3).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 2;
			goto IL_470;
			IL_49F:
			i++;
			continue;
			IL_470:
			this.m_HeroTextTemp2[i] = child.GetChild(4).GetChild(0).GetComponent<UIText>();
			this.m_HeroTextTemp2[i].font = this.TTF;
			goto IL_49F;
		}
		this.m_HeroTextTemp3 = base.transform.GetChild(1).GetChild(3).GetComponent<UIText>();
		this.m_Str = StringManager.Instance.SpawnString(30);
		this.m_Str.ClearString();
		StringManager.Instance.IntToFormat((long)this.GetCanSelectNum(), 1, false);
		this.m_Str.AppendFormat(instance2.mStringTable.GetStringByID(3753u));
		this.m_HeroTextTemp3.font = this.TTF;
		this.m_HeroTextTemp3.text = this.m_Str.ToString();
	}

	// Token: 0x06001AAD RID: 6829 RVA: 0x002D6240 File Offset: 0x002D4440
	private int GetCanSelectNum()
	{
		DataManager instance = DataManager.Instance;
		int num = 0;
		int num2 = 0;
		while ((long)num2 < (long)((ulong)instance.NonFightHeroCount))
		{
			bool flag = true;
			int num3 = 0;
			while (num3 < instance.m_DefendersID.Length && num3 < this.IsFight.Length)
			{
				if (instance.NonFightHeroID[num2] == (uint)instance.m_DefendersID[num3])
				{
					flag = false;
				}
				num3++;
			}
			if (flag)
			{
				num++;
			}
			num2++;
		}
		return num;
	}

	// Token: 0x06001AAE RID: 6830 RVA: 0x002D62C4 File Offset: 0x002D44C4
	private void CheckFight()
	{
		DataManager instance = DataManager.Instance;
		Array.Clear(this.IsFight, 0, this.IsFight.Length);
		for (int i = 0; i < instance.FightHeroID.Length; i++)
		{
			int num = 0;
			while (num < instance.m_DefendersID.Length && num < this.IsFight.Length)
			{
				if (instance.FightHeroID[i] == (uint)instance.m_DefendersID[num])
				{
					this.IsFight[num] = true;
				}
				num++;
			}
		}
	}

	// Token: 0x06001AAF RID: 6831 RVA: 0x002D634C File Offset: 0x002D454C
	public override void OnClose()
	{
		if (this.m_Str != null)
		{
			StringManager.Instance.DeSpawnString(this.m_Str);
		}
	}

	// Token: 0x06001AB0 RID: 6832 RVA: 0x002D636C File Offset: 0x002D456C
	public override void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x06001AB1 RID: 6833 RVA: 0x002D6370 File Offset: 0x002D4570
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
		case NetworkNews.Refresh_Hero:
			this.SetData();
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
			break;
		}
	}

	// Token: 0x06001AB2 RID: 6834 RVA: 0x002D63C4 File Offset: 0x002D45C4
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < 13; i++)
		{
			if (this.m_tmptext[i] != null && this.m_tmptext[i].enabled)
			{
				this.m_tmptext[i].enabled = false;
				this.m_tmptext[i].enabled = true;
			}
		}
		for (int j = 0; j < this.m_HeroTextTemp1.Length; j++)
		{
			if (this.m_HeroTextTemp1[j] != null && this.m_HeroTextTemp1[j].enabled)
			{
				this.m_HeroTextTemp1[j].enabled = false;
				this.m_HeroTextTemp1[j].enabled = true;
			}
			if (this.m_HeroTextTemp2[j] != null && this.m_HeroTextTemp2[j].enabled)
			{
				this.m_HeroTextTemp2[j].enabled = false;
				this.m_HeroTextTemp2[j].enabled = true;
			}
		}
		if (this.m_HeroTextTemp3 != null && this.m_HeroTextTemp3.enabled)
		{
			this.m_HeroTextTemp3.enabled = false;
			this.m_HeroTextTemp3.enabled = true;
		}
		if (this.m_HiBtn != null)
		{
			for (int k = 0; k < this.m_HiBtn.Length; k++)
			{
				this.m_HiBtn[k].Refresh_FontTexture();
			}
		}
	}

	// Token: 0x06001AB3 RID: 6835 RVA: 0x002D652C File Offset: 0x002D472C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
	}

	// Token: 0x06001AB4 RID: 6836 RVA: 0x002D6530 File Offset: 0x002D4730
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x06001AB5 RID: 6837 RVA: 0x002D6534 File Offset: 0x002D4734
	public void OnHIButtonClick(UIHIBtn sender)
	{
		this.door.OpenMenu(EGUIWindow.UI_HeroList_Soldier2, 1, 0, false);
	}

	// Token: 0x06001AB6 RID: 6838 RVA: 0x002D6548 File Offset: 0x002D4748
	private void Update()
	{
		this.m_ColorTick += Time.deltaTime;
		if (this.m_ColorTick >= 0.05f)
		{
			this.m_ColorA += 0.1f;
			if (this.m_ColorA >= 2f)
			{
				this.m_ColorA = 0f;
			}
			for (int i = 0; i < 3; i++)
			{
				if (this.m_FlashLord != null)
				{
					if (this.m_ColorA > 1f)
					{
						this.m_FlashLord.color = new Color(1f, 1f, 1f, 2f - this.m_ColorA);
					}
					else
					{
						this.m_FlashLord.color = new Color(1f, 1f, 1f, this.m_ColorA);
					}
				}
			}
			this.m_ColorTick = 0f;
		}
	}

	// Token: 0x06001AB7 RID: 6839 RVA: 0x002D6638 File Offset: 0x002D4838
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 0)
		{
			if (this.door)
			{
				this.door.CloseMenu(false);
			}
		}
		else if (sender.m_BtnID1 == 1)
		{
			this.door.OpenMenu(EGUIWindow.UI_HeroList_Soldier2, 1, 0, false);
		}
		else if (sender.m_BtnID1 == 2)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(330u), 255, true);
		}
	}

	// Token: 0x04004F1D RID: 20253
	private const int TextMax = 13;

	// Token: 0x04004F1E RID: 20254
	private Door door;

	// Token: 0x04004F1F RID: 20255
	private CString m_Str;

	// Token: 0x04004F20 RID: 20256
	private UISpritesArray m_SpArray;

	// Token: 0x04004F21 RID: 20257
	private float m_ColorTick;

	// Token: 0x04004F22 RID: 20258
	private float m_ColorA;

	// Token: 0x04004F23 RID: 20259
	private Image m_FlashLord;

	// Token: 0x04004F24 RID: 20260
	private int MaxDefender;

	// Token: 0x04004F25 RID: 20261
	private int CanSelectNum;

	// Token: 0x04004F26 RID: 20262
	private int SelectNum;

	// Token: 0x04004F27 RID: 20263
	private bool[] IsFight = new bool[5];

	// Token: 0x04004F28 RID: 20264
	private Font TTF;

	// Token: 0x04004F29 RID: 20265
	private int mTextCount;

	// Token: 0x04004F2A RID: 20266
	private UIText[] m_tmptext = new UIText[13];

	// Token: 0x04004F2B RID: 20267
	private UIHIBtn[] m_HiBtn = new UIHIBtn[5];

	// Token: 0x04004F2C RID: 20268
	private UIText[] m_HeroTextTemp1 = new UIText[5];

	// Token: 0x04004F2D RID: 20269
	private UIText[] m_HeroTextTemp2 = new UIText[5];

	// Token: 0x04004F2E RID: 20270
	private UIText m_HeroTextTemp3;
}
