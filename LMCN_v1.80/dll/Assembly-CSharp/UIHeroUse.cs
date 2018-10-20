using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005A4 RID: 1444
public class UIHeroUse : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001C8E RID: 7310 RVA: 0x0032672C File Offset: 0x0032492C
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.OpenKind = (UIHeroUse.eUIHU_OpenKind)arg1;
		if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.eHero)
		{
			this.m_SpArray = base.transform.GetComponent<UISpritesArray>();
			Image component = base.transform.GetChild(4).GetComponent<Image>();
			component.sprite = this.door.LoadSprite("UI_main_close_base");
			component.material = this.door.LoadMaterial();
			if (GUIManager.Instance.bOpenOnIPhoneX && component)
			{
				component.enabled = false;
			}
			UIButton component2 = base.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
			component2.m_BtnID1 = 101;
			component2.m_Handler = this;
			component2.image.sprite = this.door.LoadSprite("UI_main_close");
			component2.image.material = this.door.LoadMaterial();
			this.m_TitleText[0] = base.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.m_TitleText[0].font = ttffont;
			this.m_TitleText[0].text = instance.mStringTable.GetStringByID(529u);
			this.m_TitleText[1] = base.transform.GetChild(2).GetChild(0).GetComponent<UIText>();
			this.m_TitleText[1].font = ttffont;
			this.m_TitleText[1].text = instance.mStringTable.GetStringByID(530u);
			for (int i = 0; i < 4; i++)
			{
				component2 = base.transform.GetChild(5).GetChild(i).GetComponent<UIButton>();
				component2.SoundIndex = 64;
				UIHIBtn component3 = base.transform.GetChild(5).GetChild(i).GetChild(1).GetComponent<UIHIBtn>();
				GUIManager.Instance.InitianHeroItemImg(component3.transform, eHeroOrItem.Hero, 0, 0, 0, 0, false, false, true, false);
				if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
				{
					component = base.transform.GetChild(5).GetChild(i).GetChild(2).GetComponent<Image>();
					component.sprite = this.m_SpArray.GetSprite(3);
				}
				UIText component4 = base.transform.GetChild(5).GetChild(i).GetChild(2).GetChild(0).GetComponent<UIText>();
				component4.font = ttffont;
				component4 = base.transform.GetChild(5).GetChild(i).GetChild(2).GetChild(1).GetComponent<UIText>();
				component4.font = ttffont;
				component4 = base.transform.GetChild(5).GetChild(i).GetChild(6).GetComponent<UIText>();
				component4.font = ttffont;
				component4.text = instance.mStringTable.GetStringByID(1555u);
				if (GUIManager.Instance.IsArabic)
				{
					component = base.transform.GetChild(5).GetChild(i).GetChild(2).GetComponent<Image>();
					if (component != null)
					{
						component.sprite = this.m_SpArray.GetSprite(5);
					}
				}
			}
			DataManager.SortHeroData();
			int curHeroDataCount = (int)DataManager.Instance.CurHeroDataCount;
			int num = (curHeroDataCount % 4 != 0) ? (curHeroDataCount / 4 + 1) : (curHeroDataCount / 4);
			this.InitHeroExpObj();
			this.m_ScrollPanel = base.transform.GetChild(3).GetComponent<ScrollPanel>();
			List<float> list = new List<float>();
			for (int j = 0; j < num; j++)
			{
				list.Add(244f);
			}
			this.m_ScrollPanel.IntiScrollPanel(496f, 0f, 1f, list, 5, this);
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		}
		else if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.ePet)
		{
			PetManager instance2 = PetManager.Instance;
			instance2.SortPetData();
			this.m_SpArray = base.transform.GetComponent<UISpritesArray>();
			Image component = base.transform.GetChild(4).GetComponent<Image>();
			component.sprite = this.door.LoadSprite("UI_main_close_base");
			component.material = this.door.LoadMaterial();
			if (GUIManager.Instance.bOpenOnIPhoneX && component)
			{
				component.enabled = false;
			}
			UIButton component2 = base.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
			component2.m_BtnID1 = 101;
			component2.m_Handler = this;
			component2.image.sprite = this.door.LoadSprite("UI_main_close");
			component2.image.material = this.door.LoadMaterial();
			this.m_TitleText[0] = base.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.m_TitleText[0].font = ttffont;
			this.m_TitleText[0].text = instance.mStringTable.GetStringByID(16044u);
			this.m_TitleText[1] = base.transform.GetChild(2).GetChild(0).GetComponent<UIText>();
			this.m_TitleText[1].font = ttffont;
			this.m_TitleText[1].text = instance.mStringTable.GetStringByID(16045u);
			for (int k = 0; k < 4; k++)
			{
				component2 = base.transform.GetChild(5).GetChild(k).GetComponent<UIButton>();
				component2.SoundIndex = 64;
				UIHIBtn component3 = base.transform.GetChild(5).GetChild(k).GetChild(1).GetComponent<UIHIBtn>();
				GUIManager.Instance.InitianHeroItemImg(component3.transform, eHeroOrItem.Pet, 0, 0, 0, 0, false, false, true, false);
				if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
				{
					component = base.transform.GetChild(5).GetChild(k).GetChild(2).GetComponent<Image>();
					component.sprite = this.m_SpArray.GetSprite(3);
				}
				UIText component4 = base.transform.GetChild(5).GetChild(k).GetChild(2).GetChild(0).GetComponent<UIText>();
				component4.font = ttffont;
				component4 = base.transform.GetChild(5).GetChild(k).GetChild(2).GetChild(1).GetComponent<UIText>();
				component4.font = ttffont;
				component4 = base.transform.GetChild(5).GetChild(k).GetChild(6).GetComponent<UIText>();
				component4.font = ttffont;
				component4.text = instance.mStringTable.GetStringByID(1555u);
				if (GUIManager.Instance.IsArabic)
				{
					component = base.transform.GetChild(5).GetChild(k).GetChild(2).GetComponent<Image>();
					if (component != null)
					{
						component.sprite = this.m_SpArray.GetSprite(5);
					}
				}
			}
			int petDataCount = (int)instance2.PetDataCount;
			int num2 = (petDataCount % 4 != 0) ? (petDataCount / 4 + 1) : (petDataCount / 4);
			this.InitHeroExpObj();
			this.m_ScrollPanel = base.transform.GetChild(3).GetComponent<ScrollPanel>();
			List<float> list2 = new List<float>();
			for (int l = 0; l < num2; l++)
			{
				list2.Add(244f);
			}
			this.m_ScrollPanel.IntiScrollPanel(496f, 0f, 1f, list2, 5, this);
			if (arg2 != 0)
			{
				for (int m = 0; m < (int)instance2.PetDataCount; m++)
				{
					PetData petData = instance2.GetPetData((int)instance2.sortPetData[m]);
					if (petData != null && (int)petData.ID == arg2)
					{
						if (m >= 4)
						{
							this.m_ScrollPanel.GoTo(m / 4);
						}
						break;
					}
				}
				GUIManager.Instance.OpenContinuousUI(GUIManager.Instance.m_ItemInfo.m_ItemBtn.HIID, (int)instance2.PetUI_UseItemPetID);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
		}
	}

	// Token: 0x06001C8F RID: 7311 RVA: 0x00326F48 File Offset: 0x00325148
	public override void OnClose()
	{
		GUIManager.Instance.CloseMenu(EGUIWindow.UI_BagFilter);
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (this.m_HeroExpObj[i].m_Str[j] != null)
				{
					StringManager.Instance.DeSpawnString(this.m_HeroExpObj[i].m_Str[j]);
					this.m_HeroExpObj[i].m_Str[j] = null;
				}
			}
		}
	}

	// Token: 0x06001C90 RID: 7312 RVA: 0x00326FD0 File Offset: 0x003251D0
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 0)
		{
			this.StopHeroLvUp(this.m_LvUpHeroID);
			this.UpdateScrollPanel(false);
		}
	}

	// Token: 0x06001C91 RID: 7313 RVA: 0x00327004 File Offset: 0x00325204
	public override void UpdateNetwork(byte[] meg)
	{
		if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.eHero)
		{
			NetworkNews networkNews = (NetworkNews)meg[0];
			switch (networkNews)
			{
			case NetworkNews.Login:
			case NetworkNews.Refresh:
			case NetworkNews.Refresh_Hero:
				this.UpdateScrollPanel(true);
				break;
			default:
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
				break;
			case NetworkNews.Refresh_Item:
			{
				byte tagetlv = meg[3];
				float leftover = GameConstants.ConvertBytesToFloat(meg, 4);
				ushort num = GameConstants.ConvertBytesToUShort(meg, 8);
				byte beginlv = meg[2];
				Array.Clear(meg, 2, 6);
				if (num == 0)
				{
					return;
				}
				this.m_BeginLv = 0;
				this.m_TagetLv = 0;
				this.m_Leftover = 0f;
				this.m_FlashCount = -1;
				this.SetHeroLvUp(beginlv, tagetlv, leftover, (int)num);
				break;
			}
			}
		}
		else if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.ePet)
		{
			NetworkNews networkNews = (NetworkNews)meg[0];
			switch (networkNews)
			{
			case NetworkNews.Login:
			case NetworkNews.Refresh:
				break;
			default:
				if (networkNews != NetworkNews.Refresh_Item)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						this.Refresh_FontTexture();
						return;
					}
					if (networkNews != NetworkNews.Refresh_Pet)
					{
						return;
					}
				}
				else
				{
					byte tagetlv2 = meg[3];
					float leftover2 = GameConstants.ConvertBytesToFloat(meg, 4);
					ushort num2 = GameConstants.ConvertBytesToUShort(meg, 8);
					byte beginlv2 = meg[2];
					Array.Clear(meg, 2, 8);
					if (num2 == 0)
					{
						return;
					}
					this.m_BeginLv = 0;
					this.m_TagetLv = 0;
					this.m_Leftover = 0f;
					this.m_FlashCount = -1;
					this.SetHeroLvUp(beginlv2, tagetlv2, leftover2, (int)num2);
					return;
				}
				break;
			}
			this.StopHeroLvUp(this.m_LvUpHeroID);
			this.UpdateScrollPanel(true);
		}
	}

	// Token: 0x06001C92 RID: 7314 RVA: 0x0032718C File Offset: 0x0032538C
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x06001C93 RID: 7315 RVA: 0x00327190 File Offset: 0x00325390
	public void InitHeroExpObj()
	{
		for (int i = 0; i < 5; i++)
		{
			this.m_HeroExpObj[i].m_HeroHibtn = new UIHIBtn[4];
			this.m_HeroExpObj[i].m_ScrollSlider = new Slider[4];
			this.m_HeroExpObj[i].m_ScrollLvUpRT = new RectTransform[4];
			this.m_HeroExpObj[i].m_ScrollLvUpText = new UIText[4];
			this.m_HeroExpObj[i].m_ScrollLvText = new UIText[4];
			this.m_HeroExpObj[i].m_FlashHandle = new Image[4];
			this.m_HeroExpObj[i].ScrollHeroID = new ushort[4];
			this.m_HeroExpObj[i].m_HeroNameText = new UIText[4];
			this.m_HeroExpObj[i].m_Btn = new UIButton[4];
			this.m_HeroExpObj[i].m_Str = new CString[4];
			for (int j = 0; j < 4; j++)
			{
				if (this.m_HeroExpObj[i].m_Str[j] == null)
				{
					this.m_HeroExpObj[i].m_Str[j] = StringManager.Instance.SpawnString(30);
				}
			}
			this.m_HeroExpObj[i].m_FlashImage1 = new Image[4];
			this.m_HeroExpObj[i].m_FlashImage2 = new Image[4];
			this.m_HeroExpObj[i].m_FlashValue1 = new FlashValue[4];
			this.m_HeroExpObj[i].m_FlashValue2 = new FlashValue[4];
			this.m_HeroExpObj[i].m_FlashLvUpValue = new FlashValue[4];
			this.m_HeroExpObj[i].m_IsFightingImg = new Image[4];
			this.m_HeroExpObj[i].m_PetLock = new Image[4];
			this.m_HeroExpObj[i].m_FillImage = new Image[4];
		}
	}

	// Token: 0x06001C94 RID: 7316 RVA: 0x00327398 File Offset: 0x00325598
	private void Update()
	{
		bool flag = false;
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (this.m_LvUpHeroID != 0 && this.m_LvUpHeroID == (int)this.m_HeroExpObj[i].ScrollHeroID[j])
				{
					this.m_TickTime[0] += Time.deltaTime;
					if (this.m_TickTime[0] >= 0.01f)
					{
						if (!this.m_HeroExpObj[i].m_ScrollSlider[j])
						{
							goto IL_B4F;
						}
						if (this.m_FlashCount >= 0)
						{
							this.m_preLvUpHeroID = this.m_LvUpHeroID;
							flag = true;
							if (this.m_BeginLv == this.m_TagetLv && this.m_HeroExpObj[i].m_ScrollSlider[j].value < this.m_FlashLeftOver)
							{
								this.m_TickTime[0] = 0f;
								this.m_HeroExpObj[i].m_ScrollSlider[j].value += 0.02f;
								this.m_HeroExpObj[i].m_ScrollSlider[j].value = Mathf.Clamp(this.m_HeroExpObj[i].m_ScrollSlider[j].value, 0f, this.m_FlashLeftOver);
							}
							else
							{
								this.m_TickTime[0] = 0f;
								this.m_HeroExpObj[i].m_ScrollSlider[j].value += 0.02f;
							}
							this.m_SliderValue = this.m_HeroExpObj[i].m_ScrollSlider[j].value;
							if (this.m_SliderValue >= 1f)
							{
								this.m_SliderValue = 0f;
								this.m_HeroExpObj[i].m_ScrollSlider[j].value = 0f;
								this.m_FlashCount--;
								this.bShowLvUp = true;
								this.LvUpCount += 1f;
								this.m_BeginLv += 1;
								this.m_HeroExpObj[i].m_Str[j].ClearString();
								StringManager.Instance.IntToFormat((long)this.m_BeginLv, 1, false);
								this.m_HeroExpObj[i].m_Str[j].AppendFormat("{0}");
								this.m_HeroExpObj[i].m_ScrollLvText[j].text = this.m_HeroExpObj[i].m_Str[j].ToString();
								this.m_HeroExpObj[i].m_ScrollLvText[j].SetAllDirty();
								this.m_HeroExpObj[i].m_ScrollLvText[j].cachedTextGenerator.Invalidate();
								AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
							}
							if (this.m_BeginLv == this.m_TagetLv && this.m_SliderValue >= this.m_FlashLeftOver)
							{
								this.m_FlashCount = -1;
								if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.ePet)
								{
									PetData petData = PetManager.Instance.FindPetData((ushort)this.m_LvUpHeroID);
									if (petData != null)
									{
										if (this.GetPetLock(petData.ID) != 0)
										{
											this.m_HeroExpObj[i].m_PetLock[j].enabled = true;
										}
										else
										{
											this.m_HeroExpObj[i].m_PetLock[j].enabled = false;
										}
										if (petData.Level < 60)
										{
											this.m_HeroExpObj[i].m_FillImage[j].sprite = this.m_SpArray.GetSprite(7);
										}
										else
										{
											this.m_HeroExpObj[i].m_FillImage[j].sprite = this.m_SpArray.GetSprite(8);
											this.m_HeroExpObj[i].m_ScrollSlider[j].value = 1f;
										}
									}
								}
							}
						}
					}
					if (this.bShowLvUp)
					{
						if (!this.m_HeroExpObj[i].m_ScrollLvUpRT[j])
						{
							goto IL_B4F;
						}
						if (this.LvUpCount > 0f)
						{
							flag = true;
							if (this.m_HeroExpObj[i].m_FlashLvUpValue[j].posTime >= this.m_FalshImageEffectTime[2])
							{
								this.bFinish[0] = true;
								this.m_HeroExpObj[i].m_ScrollLvUpText[j].enabled = false;
							}
							else
							{
								this.bFinish[0] = false;
								this.m_HeroExpObj[i].m_ScrollLvUpText[j].enabled = true;
								FlashValue[] flashLvUpValue = this.m_HeroExpObj[i].m_FlashLvUpValue;
								int num = j;
								flashLvUpValue[num].posTime = flashLvUpValue[num].posTime + Time.deltaTime;
								this.m_HeroExpObj[i].m_FlashLvUpValue[j].posY = this.SelectTween(this.m_HeroExpObj[i].m_FlashLvUpValue[j].posTime, -210f, 200f, this.m_FalshImageEffectTime[2]);
								this.m_HeroExpObj[i].m_ScrollLvUpRT[j].anchoredPosition = this.m_HeroExpObj[i].m_ScrollLvUpText[j].ArabicFixPos(new Vector2(30f, this.m_HeroExpObj[i].m_FlashLvUpValue[j].posY));
								this.m_HeroExpObj[i].m_FlashLvUpValue[j].colorA = this.SelectTween(this.m_HeroExpObj[i].m_FlashLvUpValue[j].posTime, 0f, 1f, this.m_FalshImageEffectTime[2]);
								this.m_HeroExpObj[i].m_ScrollLvUpText[j].color = new Color(this.m_HeroExpObj[i].m_ScrollLvUpText[j].color.r, this.m_HeroExpObj[i].m_ScrollLvUpText[j].color.g, this.m_HeroExpObj[i].m_ScrollLvUpText[j].color.b, this.m_HeroExpObj[i].m_FlashLvUpValue[j].colorA);
							}
							if (this.m_HeroExpObj[i].m_FlashValue1[j].colorTime >= this.m_FalshImageEffectTime[0])
							{
								this.bFinish[1] = true;
								this.m_HeroExpObj[i].m_FlashImage1[j].enabled = false;
							}
							else
							{
								this.bFinish[1] = false;
								this.m_HeroExpObj[i].m_FlashImage1[j].enabled = true;
								FlashValue[] flashValue = this.m_HeroExpObj[i].m_FlashValue1;
								int num2 = j;
								flashValue[num2].colorTime = flashValue[num2].colorTime + Time.deltaTime;
								this.m_HeroExpObj[i].m_FlashValue1[j].colorA = this.SelectTween(this.m_HeroExpObj[i].m_FlashValue1[j].colorTime, 0f, 2f, this.m_FalshImageEffectTime[0]);
								if (this.m_HeroExpObj[i].m_FlashValue1[j].colorA >= 1f)
								{
									this.m_HeroExpObj[i].m_FlashImage1[j].color = new Color(1f, 1f, 1f, 2f - this.m_HeroExpObj[i].m_FlashValue1[j].colorA);
								}
								else
								{
									this.m_HeroExpObj[i].m_FlashImage1[j].color = new Color(1f, 1f, 1f, this.m_HeroExpObj[i].m_FlashValue1[j].colorA);
								}
							}
							if (this.m_HeroExpObj[i].m_FlashValue2[j].colorTime >= this.m_FalshImageEffectTime[0])
							{
								this.bFinish[2] = true;
								this.m_HeroExpObj[i].m_FlashImage2[j].enabled = false;
							}
							else
							{
								this.bFinish[2] = false;
								this.m_HeroExpObj[i].m_FlashImage2[j].enabled = true;
								FlashValue[] flashValue2 = this.m_HeroExpObj[i].m_FlashValue2;
								int num3 = j;
								flashValue2[num3].colorTime = flashValue2[num3].colorTime + Time.deltaTime;
								this.m_HeroExpObj[i].m_FlashValue2[j].colorA = this.SelectTween(this.m_HeroExpObj[i].m_FlashValue2[j].colorTime, 0f, 2f, this.m_FalshImageEffectTime[0]);
								if (this.m_HeroExpObj[i].m_FlashValue2[j].colorA >= 1f)
								{
									this.m_HeroExpObj[i].m_FlashImage2[j].color = new Color(1f, 1f, 1f, 2f - this.m_HeroExpObj[i].m_FlashValue2[j].colorA);
								}
								else
								{
									this.m_HeroExpObj[i].m_FlashImage2[j].color = new Color(1f, 1f, 1f, this.m_HeroExpObj[i].m_FlashValue2[j].colorA);
								}
								this.m_HeroExpObj[i].m_FlashValue2[j].posY = this.SelectTween(this.m_HeroExpObj[i].m_FlashValue2[j].colorTime, -40f, 180f, this.m_FalshImageEffectTime[0]);
								this.m_HeroExpObj[i].m_FlashImage2[j].rectTransform.anchoredPosition = new Vector2(0f, this.m_HeroExpObj[i].m_FlashValue2[j].posY);
							}
							if (this.bFinish[0] && this.bFinish[1] && this.bFinish[2])
							{
								this.LvUpCount -= 1f;
								if (this.m_FlashCount == -1)
								{
									this.bShowLvUp = false;
									this.LvUpCount = 0f;
									if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.ePet)
									{
										PetData petData2 = PetManager.Instance.FindPetData((ushort)this.m_LvUpHeroID);
										if (petData2 != null)
										{
											if (this.GetPetLock(petData2.ID) != 0)
											{
												this.m_HeroExpObj[i].m_PetLock[j].enabled = true;
											}
											else
											{
												this.m_HeroExpObj[i].m_PetLock[j].enabled = false;
											}
										}
									}
								}
								this.m_HeroExpObj[i].m_FlashLvUpValue[j].posTime = 0f;
								this.m_HeroExpObj[i].m_FlashValue1[j].colorTime = 0f;
								this.m_HeroExpObj[i].m_FlashValue2[j].colorTime = 0f;
							}
						}
					}
					break;
				}
				IL_B4F:;
			}
		}
		if (!flag)
		{
			this.m_preLvUpHeroID = 0;
		}
	}

	// Token: 0x06001C95 RID: 7317 RVA: 0x00327F18 File Offset: 0x00326118
	public float SelectTween(float t, float b, float c, float d)
	{
		t /= d;
		return b + c * t;
	}

	// Token: 0x06001C96 RID: 7318 RVA: 0x00327F28 File Offset: 0x00326128
	public void UpdateScrollPanel(bool bneedSort = true)
	{
		if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.eHero)
		{
			if (bneedSort)
			{
				DataManager.SortHeroData();
			}
			int curHeroDataCount = (int)DataManager.Instance.CurHeroDataCount;
			int num = (curHeroDataCount % 4 != 0) ? (curHeroDataCount / 4 + 1) : (curHeroDataCount / 4);
			this.InitHeroExpObj();
			this.m_ScrollPanel = base.transform.GetChild(3).GetComponent<ScrollPanel>();
			List<float> list = new List<float>();
			for (int i = 0; i < num; i++)
			{
				list.Add(244f);
			}
			this.m_ScrollPanel.AddNewDataHeight(list, false, true);
		}
		else if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.ePet)
		{
			if (bneedSort)
			{
				PetManager.Instance.SortPetData();
			}
			int petDataCount = (int)PetManager.Instance.PetDataCount;
			int num2 = (petDataCount % 4 != 0) ? (petDataCount / 4 + 1) : (petDataCount / 4);
			this.InitHeroExpObj();
			this.m_ScrollPanel = base.transform.GetChild(3).GetComponent<ScrollPanel>();
			List<float> list2 = new List<float>();
			for (int j = 0; j < num2; j++)
			{
				list2.Add(244f);
			}
			this.m_ScrollPanel.AddNewDataHeight(list2, false, true);
		}
	}

	// Token: 0x06001C97 RID: 7319 RVA: 0x00328058 File Offset: 0x00326258
	public void OnButtonClick(UIButton sender)
	{
		if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.eHero)
		{
			if (sender.m_BtnID1 == 101)
			{
				if (this.door != null)
				{
					this.door.CloseMenu(false);
				}
			}
			else
			{
				eHeroState heroState = DataManager.Instance.GetHeroState((ushort)sender.m_BtnID2);
				if (heroState == eHeroState.Captured)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(818u), 255, true);
					return;
				}
				if (heroState == eHeroState.Dead)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(819u), 255, true);
					return;
				}
				if (sender.m_BtnID2 == this.m_preLvUpHeroID)
				{
					this.StopHeroLvUp(this.m_preLvUpHeroID);
					this.UpdateScrollPanel(true);
				}
				GUIManager.Instance.OpenContinuousUI(GUIManager.Instance.m_ItemInfo.m_ItemBtn.HIID, sender.m_BtnID2);
			}
		}
		else if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.ePet)
		{
			if (sender.m_BtnID1 == 101)
			{
				if (this.door != null)
				{
					this.door.CloseMenu(false);
				}
			}
			else
			{
				PetManager instance = PetManager.Instance;
				ushort num = (ushort)sender.m_BtnID2;
				byte petLock = this.GetPetLock(num);
				if (petLock != 0)
				{
					DataManager instance2 = DataManager.Instance;
					CString cstring = StringManager.Instance.StaticString1024();
					if (petLock == 1)
					{
						PetTbl recordByKey = instance.PetTable.GetRecordByKey(num);
						cstring.StringToFormat(instance2.mStringTable.GetStringByID((uint)recordByKey.Name));
						cstring.AppendFormat(instance2.mStringTable.GetStringByID(16040u));
						GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
					}
					else if (petLock == 2)
					{
						GUIManager.Instance.OpenMessageBox(instance2.mStringTable.GetStringByID(16082u), instance2.mStringTable.GetStringByID(16069u), instance2.mStringTable.GetStringByID(3968u), this, 1, (int)num, true, false, false, false, false);
					}
					return;
				}
				if ((int)num == this.m_preLvUpHeroID)
				{
					this.StopHeroLvUp(this.m_preLvUpHeroID);
					this.UpdateScrollPanel(true);
				}
				GUIManager.Instance.OpenContinuousUI(GUIManager.Instance.m_ItemInfo.m_ItemBtn.HIID, sender.m_BtnID2);
			}
		}
	}

	// Token: 0x06001C98 RID: 7320 RVA: 0x003282B4 File Offset: 0x003264B4
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.eHero)
		{
			DataManager instance = DataManager.Instance;
			GUIManager instance2 = GUIManager.Instance;
			for (int i = 0; i < 4; i++)
			{
				int num = dataIdx * 4 + i;
				uint key = instance.sortHeroData[num];
				if (instance.curHeroData.ContainsKey(key))
				{
					CurHeroData curHeroData = instance.curHeroData[key];
					this.m_HeroExpObj[panelObjectIdx].ScrollHeroID[i] = 0;
					Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(curHeroData.ID);
					if (this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[i] == null)
					{
						this.m_HeroExpObj[panelObjectIdx].m_HeroHibtn[i] = item.transform.GetChild(i).GetChild(1).GetComponent<UIHIBtn>();
						Transform child = item.transform.GetChild(i).GetChild(2);
						this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[i] = child.GetChild(0).GetComponent<UIText>();
						this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[i].resizeTextForBestFit = true;
						this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[i].resizeTextMaxSize = 22;
						child = item.transform.GetChild(i).GetChild(2);
						this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[i] = child.GetChild(1).GetComponent<UIText>();
						this.m_HeroExpObj[panelObjectIdx].m_Btn[i] = item.transform.GetChild(i).GetComponent<UIButton>();
						this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[i] = item.transform.GetChild(i).GetChild(3).GetComponent<Slider>();
						this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpRT[i] = item.transform.GetChild(i).GetChild(6).GetComponent<RectTransform>();
						this.m_HeroExpObj[panelObjectIdx].m_FlashImage1[i] = item.transform.GetChild(i).GetChild(4).GetComponent<Image>();
						this.m_HeroExpObj[panelObjectIdx].m_FlashImage2[i] = item.transform.GetChild(i).GetChild(5).GetComponent<Image>();
						this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpText[i] = item.transform.GetChild(i).GetChild(6).GetComponent<UIText>();
						this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[i] = item.transform.GetChild(i).GetChild(7).GetComponent<Image>();
						this.m_HeroExpObj[panelObjectIdx].m_PetLock[i] = item.transform.GetChild(i).GetChild(8).GetComponent<Image>();
						this.m_HeroExpObj[panelObjectIdx].m_FillImage[i] = this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[i].fillRect.GetComponent<Image>();
					}
					this.m_HeroExpObj[panelObjectIdx].ScrollHeroID[i] = recordByKey.HeroKey;
					instance2.ChangeHeroItemImg(this.m_HeroExpObj[panelObjectIdx].m_HeroHibtn[i].transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, 0, 0);
					this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[i].text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.HeroTitle);
					this.m_HeroExpObj[panelObjectIdx].m_Str[i].ClearString();
					StringManager.Instance.IntToFormat((long)curHeroData.Level, 1, false);
					this.m_HeroExpObj[panelObjectIdx].m_Str[i].AppendFormat("{0}");
					this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[i].text = this.m_HeroExpObj[panelObjectIdx].m_Str[i].ToString();
					this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[i].SetAllDirty();
					this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[i].cachedTextGenerator.Invalidate();
					this.m_HeroExpObj[panelObjectIdx].m_FlashImage1[i].enabled = false;
					this.m_HeroExpObj[panelObjectIdx].m_FlashImage2[i].enabled = false;
					this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpText[i].enabled = false;
					this.m_HeroExpObj[panelObjectIdx].m_FlashLvUpValue[i].posTime = 0f;
					this.m_HeroExpObj[panelObjectIdx].m_FlashValue1[i].colorTime = 0f;
					this.m_HeroExpObj[panelObjectIdx].m_FlashValue2[i].colorTime = 0f;
					this.m_HeroExpObj[panelObjectIdx].m_Btn[i].m_Handler = this;
					this.m_HeroExpObj[panelObjectIdx].m_Btn[i].m_BtnID1 = num;
					this.m_HeroExpObj[panelObjectIdx].m_Btn[i].m_BtnID2 = (int)recordByKey.HeroKey;
					uint heroExp = instance.LevelUpTable.GetRecordByKey((ushort)curHeroData.Level).HeroExp;
					uint exp = curHeroData.Exp;
					this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[i].value = exp / heroExp;
					this.m_HeroExpObj[panelObjectIdx].ScrollHeroID[i] = recordByKey.HeroKey;
					this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpRT[i].anchoredPosition = this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpText[i].ArabicFixPos(new Vector2(44f, -98f));
					eHeroState heroState = instance.GetHeroState(recordByKey.HeroKey);
					if (heroState == eHeroState.None)
					{
						this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[i].gameObject.SetActive(false);
					}
					else
					{
						if (heroState == eHeroState.IsFighting)
						{
							this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[i].sprite = this.m_SpArray.GetSprite(0);
						}
						if (heroState == eHeroState.Captured)
						{
							this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[i].sprite = this.m_SpArray.GetSprite(1);
						}
						if (heroState == eHeroState.Dead)
						{
							this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[i].sprite = this.m_SpArray.GetSprite(2);
						}
						this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[i].gameObject.SetActive(true);
					}
				}
				if ((long)num < (long)((ulong)instance.CurHeroDataCount))
				{
					item.transform.GetChild(i).gameObject.SetActive(true);
				}
				else
				{
					item.transform.GetChild(i).gameObject.SetActive(false);
				}
			}
		}
		else if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.ePet)
		{
			DataManager instance3 = DataManager.Instance;
			GUIManager instance4 = GUIManager.Instance;
			PetManager instance5 = PetManager.Instance;
			for (int j = 0; j < 4; j++)
			{
				int num2 = dataIdx * 4 + j;
				if (num2 < (int)instance5.PetDataCount)
				{
					PetData petData = instance5.GetPetData((int)instance5.sortPetData[num2]);
					if (petData != null)
					{
						if (this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[j] == null)
						{
							this.m_HeroExpObj[panelObjectIdx].m_HeroHibtn[j] = item.transform.GetChild(j).GetChild(1).GetComponent<UIHIBtn>();
							Transform child2 = item.transform.GetChild(j).GetChild(2);
							this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[j] = child2.GetChild(0).GetComponent<UIText>();
							this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[j].resizeTextForBestFit = true;
							this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[j].resizeTextMaxSize = 22;
							child2 = item.transform.GetChild(j).GetChild(2);
							this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[j] = child2.GetChild(1).GetComponent<UIText>();
							this.m_HeroExpObj[panelObjectIdx].m_Btn[j] = item.transform.GetChild(j).GetComponent<UIButton>();
							this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[j] = item.transform.GetChild(j).GetChild(3).GetComponent<Slider>();
							this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpRT[j] = item.transform.GetChild(j).GetChild(6).GetComponent<RectTransform>();
							this.m_HeroExpObj[panelObjectIdx].m_FlashImage1[j] = item.transform.GetChild(j).GetChild(4).GetComponent<Image>();
							this.m_HeroExpObj[panelObjectIdx].m_FlashImage2[j] = item.transform.GetChild(j).GetChild(5).GetComponent<Image>();
							this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpText[j] = item.transform.GetChild(j).GetChild(6).GetComponent<UIText>();
							this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[j] = item.transform.GetChild(j).GetChild(7).GetComponent<Image>();
							this.m_HeroExpObj[panelObjectIdx].m_PetLock[j] = item.transform.GetChild(j).GetChild(8).GetComponent<Image>();
							this.m_HeroExpObj[panelObjectIdx].m_FillImage[j] = this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[j].fillRect.GetComponent<Image>();
						}
						PetTbl recordByKey2 = instance5.PetTable.GetRecordByKey(petData.ID);
						this.m_HeroExpObj[panelObjectIdx].ScrollHeroID[j] = petData.ID;
						instance4.ChangeHeroItemImg(this.m_HeroExpObj[panelObjectIdx].m_HeroHibtn[j].transform, eHeroOrItem.Pet, petData.ID, petData.Enhance, 0, 0);
						this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[j].text = instance3.mStringTable.GetStringByID((uint)recordByKey2.Name);
						this.m_HeroExpObj[panelObjectIdx].m_Str[j].ClearString();
						this.m_HeroExpObj[panelObjectIdx].m_Str[j].IntToFormat((long)petData.Level, 1, false);
						this.m_HeroExpObj[panelObjectIdx].m_Str[j].AppendFormat("{0}");
						this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[j].text = this.m_HeroExpObj[panelObjectIdx].m_Str[j].ToString();
						this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[j].SetAllDirty();
						this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[j].cachedTextGenerator.Invalidate();
						this.m_HeroExpObj[panelObjectIdx].m_FlashImage1[j].enabled = false;
						this.m_HeroExpObj[panelObjectIdx].m_FlashImage2[j].enabled = false;
						this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpText[j].enabled = false;
						this.m_HeroExpObj[panelObjectIdx].m_FlashLvUpValue[j].posTime = 0f;
						this.m_HeroExpObj[panelObjectIdx].m_FlashValue1[j].colorTime = 0f;
						this.m_HeroExpObj[panelObjectIdx].m_FlashValue2[j].colorTime = 0f;
						this.m_HeroExpObj[panelObjectIdx].m_Btn[j].m_Handler = this;
						this.m_HeroExpObj[panelObjectIdx].m_Btn[j].m_BtnID1 = num2;
						this.m_HeroExpObj[panelObjectIdx].m_Btn[j].m_BtnID2 = (int)petData.ID;
						uint needExp = instance5.GetNeedExp(petData.Level, recordByKey2.Rare);
						double num3 = (needExp == 0u) ? 0.0 : (petData.Exp / needExp);
						this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[j].value = (float)num3;
						if (petData.Level < 60)
						{
							this.m_HeroExpObj[panelObjectIdx].m_FillImage[j].sprite = this.m_SpArray.GetSprite(7);
						}
						else
						{
							this.m_HeroExpObj[panelObjectIdx].m_FillImage[j].sprite = this.m_SpArray.GetSprite(8);
							this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[j].value = 1f;
						}
						this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpRT[j].anchoredPosition = this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpText[j].ArabicFixPos(new Vector2(44f, -98f));
						if (petData.CheckState(PetManager.EPetState.Training))
						{
							this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[j].sprite = this.m_SpArray.GetSprite(6);
							this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[j].gameObject.SetActive(true);
						}
						else
						{
							this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[j].gameObject.SetActive(false);
						}
						if (this.GetPetLock(petData.ID) != 0)
						{
							if (this.m_FlashCount != -1 && this.LvUpCount != -1f && this.m_LvUpHeroID != 0 && this.m_LvUpHeroID == (int)petData.ID)
							{
								this.m_HeroExpObj[panelObjectIdx].m_PetLock[j].enabled = false;
							}
							else
							{
								this.m_HeroExpObj[panelObjectIdx].m_PetLock[j].enabled = true;
							}
						}
						else
						{
							this.m_HeroExpObj[panelObjectIdx].m_PetLock[j].enabled = false;
						}
					}
					item.transform.GetChild(j).gameObject.SetActive(true);
				}
				else
				{
					item.transform.GetChild(j).gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06001C99 RID: 7321 RVA: 0x00329174 File Offset: 0x00327374
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001C9A RID: 7322 RVA: 0x00329178 File Offset: 0x00327378
	private void StopHeroLvUp(int HeroID)
	{
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (HeroID != 0 && HeroID == (int)this.m_HeroExpObj[i].ScrollHeroID[j])
				{
					this.m_HeroExpObj[i].m_FlashLvUpValue[j].posTime = 0f;
					this.m_HeroExpObj[i].m_FlashValue1[j].colorTime = 0f;
					this.m_HeroExpObj[i].m_FlashValue2[j].colorTime = 0f;
					this.m_HeroExpObj[i].m_FlashImage2[j].enabled = false;
					this.m_HeroExpObj[i].m_FlashImage1[j].enabled = false;
					this.m_HeroExpObj[i].m_ScrollLvUpText[j].enabled = false;
					this.m_LvUpHeroID = 0;
					this.m_preLvUpHeroID = 0;
					if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.ePet)
					{
						PetData petData = PetManager.Instance.FindPetData((ushort)HeroID);
						if (petData != null)
						{
							if (this.GetPetLock(petData.ID) != 0)
							{
								this.m_HeroExpObj[i].m_PetLock[j].enabled = true;
							}
							else
							{
								this.m_HeroExpObj[i].m_PetLock[j].enabled = false;
							}
							if (petData.Level < 60)
							{
								this.m_HeroExpObj[i].m_FillImage[j].sprite = this.m_SpArray.GetSprite(7);
							}
							else
							{
								this.m_HeroExpObj[i].m_FillImage[j].sprite = this.m_SpArray.GetSprite(8);
								this.m_HeroExpObj[i].m_ScrollSlider[j].value = 1f;
							}
						}
					}
					break;
				}
			}
		}
	}

	// Token: 0x06001C9B RID: 7323 RVA: 0x00329368 File Offset: 0x00327568
	private void SetHeroLvUp(byte beginlv, byte tagetlv, float leftover, int HeroID = 1)
	{
		this.m_BeginLv = beginlv;
		this.m_TagetLv = tagetlv;
		this.m_Leftover = leftover;
		this.m_LvUpHeroID = HeroID;
		this.m_FlashCount = (int)(tagetlv - beginlv);
		this.m_FlashLeftOver = leftover;
	}

	// Token: 0x06001C9C RID: 7324 RVA: 0x00329398 File Offset: 0x00327598
	private void Refresh_FontTexture()
	{
		if (this.m_TitleText != null)
		{
			for (int i = 0; i < this.m_TitleText.Length; i++)
			{
				if (this.m_TitleText[i] != null && this.m_TitleText[i].enabled)
				{
					this.m_TitleText[i].enabled = false;
					this.m_TitleText[i].enabled = true;
				}
			}
		}
		if (this.m_HeroExpObj != null)
		{
			for (int j = 0; j < this.m_HeroExpObj.Length; j++)
			{
				for (int k = 0; k < this.m_HeroExpObj[j].m_HeroHibtn.Length; k++)
				{
					if (this.m_HeroExpObj[j].m_HeroHibtn[k] != null && this.m_HeroExpObj[j].m_HeroHibtn[k].enabled)
					{
						this.m_HeroExpObj[j].m_HeroHibtn[k].Refresh_FontTexture();
					}
				}
				for (int l = 0; l < this.m_HeroExpObj[j].m_ScrollLvUpText.Length; l++)
				{
					if (this.m_HeroExpObj[j].m_ScrollLvUpText[l] != null && this.m_HeroExpObj[j].m_ScrollLvUpText[l].enabled)
					{
						this.m_HeroExpObj[j].m_ScrollLvUpText[l].enabled = false;
						this.m_HeroExpObj[j].m_ScrollLvUpText[l].enabled = true;
					}
				}
				for (int m = 0; m < this.m_HeroExpObj[j].m_ScrollLvText.Length; m++)
				{
					if (this.m_HeroExpObj[j].m_ScrollLvText[m] != null && this.m_HeroExpObj[j].m_ScrollLvText[m].enabled)
					{
						this.m_HeroExpObj[j].m_ScrollLvText[m].enabled = false;
						this.m_HeroExpObj[j].m_ScrollLvText[m].enabled = true;
					}
				}
				for (int n = 0; n < this.m_HeroExpObj[j].m_HeroNameText.Length; n++)
				{
					if (this.m_HeroExpObj[j].m_HeroNameText[n] != null && this.m_HeroExpObj[j].m_HeroNameText[n].enabled)
					{
						this.m_HeroExpObj[j].m_HeroNameText[n].enabled = false;
						this.m_HeroExpObj[j].m_HeroNameText[n].enabled = true;
					}
				}
			}
		}
	}

	// Token: 0x06001C9D RID: 7325 RVA: 0x00329668 File Offset: 0x00327868
	private byte GetPetLock(ushort PetID)
	{
		PetManager instance = PetManager.Instance;
		PetData petData = instance.FindPetData(PetID);
		if (petData.CheckState(PetManager.EPetState.Evolution))
		{
			return 1;
		}
		if (petData.Level >= petData.GetMaxLevel(false))
		{
			PetTbl recordByKey = instance.PetTable.GetRecordByKey(petData.ID);
			uint needExp = instance.GetNeedExp(petData.Level, recordByKey.Rare);
			if (petData.Exp == needExp - 1u)
			{
				return 2;
			}
		}
		return 0;
	}

	// Token: 0x06001C9E RID: 7326 RVA: 0x003296DC File Offset: 0x003278DC
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 == 1)
			{
				PetManager.Instance.OpenPetEvoPanel(arg2, true);
			}
		}
	}

	// Token: 0x04005662 RID: 22114
	private const int MaxScorllCount = 5;

	// Token: 0x04005663 RID: 22115
	private UIText[] m_TitleText = new UIText[2];

	// Token: 0x04005664 RID: 22116
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04005665 RID: 22117
	private Door door;

	// Token: 0x04005666 RID: 22118
	private HeroExpObj[] m_HeroExpObj = new HeroExpObj[5];

	// Token: 0x04005667 RID: 22119
	private UISpritesArray m_SpArray;

	// Token: 0x04005668 RID: 22120
	private int m_FlashCount;

	// Token: 0x04005669 RID: 22121
	private float m_FlashLeftOver;

	// Token: 0x0400566A RID: 22122
	private bool bShowLvUp;

	// Token: 0x0400566B RID: 22123
	private float LvUpCount;

	// Token: 0x0400566C RID: 22124
	private bool[] bFinish = new bool[3];

	// Token: 0x0400566D RID: 22125
	private byte m_BeginLv;

	// Token: 0x0400566E RID: 22126
	private byte m_TagetLv;

	// Token: 0x0400566F RID: 22127
	private float m_Leftover;

	// Token: 0x04005670 RID: 22128
	private int m_LvUpHeroID;

	// Token: 0x04005671 RID: 22129
	private int m_preLvUpHeroID;

	// Token: 0x04005672 RID: 22130
	private float[] m_TickTime = new float[]
	{
		0.008f,
		0.01f,
		0.01f
	};

	// Token: 0x04005673 RID: 22131
	private float m_SliderValue;

	// Token: 0x04005674 RID: 22132
	private float[] m_FalshImageEffectTime = new float[]
	{
		0.8f,
		0.8f,
		1.2f
	};

	// Token: 0x04005675 RID: 22133
	public float[] PageMoveSpeed = new float[2];

	// Token: 0x04005676 RID: 22134
	private UIHeroUse.eUIHU_OpenKind OpenKind;

	// Token: 0x020005A5 RID: 1445
	private enum eUIHU_OpenKind
	{
		// Token: 0x04005678 RID: 22136
		eHero,
		// Token: 0x04005679 RID: 22137
		ePet
	}
}
