using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002A7 RID: 679
public class UIActivity3 : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
	// Token: 0x06000D93 RID: 3475 RVA: 0x0015B79C File Offset: 0x0015999C
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.SM = StringManager.Instance;
		this.AM = ActivityManager.Instance;
		this.m_transform = base.transform;
		Font ttffont = this.GM.GetTTFFont();
		this.DataIndex = (byte)arg2;
		bool flag = arg1 == 254;
		this.bFirstBuy = (arg1 == 253);
		if (this.bFirstBuy)
		{
			this.tmpData = this.AM.FBActivityData;
		}
		else
		{
			this.tmpData = ((!flag) ? this.AM.SPActivityData[(int)this.DataIndex] : this.AM.CSActivityData[(int)this.DataIndex]);
		}
		this.m_transform.GetChild(2).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(2).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(2).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(3).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(3).gameObject.SetActive(false);
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(2).GetComponent<CustomImage>().enabled = false;
		}
		Transform child = this.m_transform.GetChild(1);
		UIText component = child.GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID((uint)this.tmpData.Name);
		this.RefreshTextArray.Add(component);
		this.TitleText = child.GetChild(3).GetComponent<UIText>();
		this.TitleText.font = ttffont;
		this.RefreshTextArray.Add(this.TitleText);
		this.TimeText = child.GetChild(4).GetComponent<UIText>();
		this.TimeText.font = ttffont;
		this.TimeText.color = new Color(1f, 0.9294f, 0.5451f);
		this.timeStr = this.SM.SpawnString(150);
		this.RefreshTextArray.Add(this.TimeText);
		this.TitleImg = child.GetChild(5).GetComponent<Image>();
		child.GetChild(5).gameObject.AddComponent<ArabicItemTextureRot>();
		this.SetTitleImage();
		this.ContentT = child.GetChild(6).GetChild(0);
		this.TextGO = this.ContentT.GetChild(0).gameObject;
		component = this.ContentT.GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		this.ItemGO = this.ContentT.GetChild(1).gameObject;
		((RectTransform)this.ItemGO.transform).sizeDelta = new Vector2(this.ItemSize, this.ItemSize);
		this.GM.InitianHeroItemImg(this.ContentT.GetChild(1), eHeroOrItem.Item, 1, 0, 0, 0, true, true, true, false);
		this.UrlGO = this.ContentT.GetChild(2).gameObject;
		component = this.ContentT.GetChild(2).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		child.GetChild(7).GetComponent<UIButton>().m_Handler = this;
		if ((!flag || this.bFirstBuy) && this.tmpData.GoToButton != 0)
		{
			child.GetChild(7).gameObject.SetActive(true);
		}
		component = child.GetChild(7).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		if (this.tmpData.GoToButton == 5)
		{
			component.text = this.DM.mStringTable.GetStringByID(15015u);
		}
		else
		{
			component.text = this.DM.mStringTable.GetStringByID(8154u);
		}
		this.RefreshTextArray.Add(component);
		this.SpawnContent();
		if (this.bFirstBuy)
		{
			this.AM.bOpenFirstBuyActivity = true;
		}
		else if (flag)
		{
			this.AM.SetbOpenCSActivity(this.DataIndex, true);
		}
		else
		{
			this.AM.SetbOpenSPActivity(this.DataIndex, true);
		}
		this.GM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06000D94 RID: 3476 RVA: 0x0015BC00 File Offset: 0x00159E00
	public override void OnClose()
	{
		for (int i = 0; i < this.AllObject.Count; i++)
		{
			StringManager.Instance.DeSpawnString(this.AllObject[i]);
		}
		for (int j = 0; j < this.UrlObject.Count; j++)
		{
			StringManager.Instance.DeSpawnString(this.UrlObject[j]);
		}
		if (this.timeStr != null)
		{
			StringManager.Instance.DeSpawnString(this.timeStr);
		}
		if (this.bPlayMaster)
		{
			AudioManager.Instance.LoadAndPlayBGM(this.NowBGM, 1, false);
		}
	}

	// Token: 0x06000D95 RID: 3477 RVA: 0x0015BCAC File Offset: 0x00159EAC
	private void DestroyContentItem()
	{
		for (int i = 0; i < this.AllObject.Count; i++)
		{
			StringManager.Instance.DeSpawnString(this.AllObject[i]);
		}
		for (int j = 0; j < this.UrlObject.Count; j++)
		{
			StringManager.Instance.DeSpawnString(this.UrlObject[j]);
		}
		this.AllObject.Clear();
		this.UrlObject.Clear();
		for (int k = this.DestroyGO.Count - 1; k >= 0; k--)
		{
			this.DestroyGO[k].SetActive(false);
			UnityEngine.Object.Destroy(this.DestroyGO[k]);
		}
		this.DestroyGO.Clear();
		this.NowX = 60f;
		this.NowY = -5f;
		this.timeStr.Length = 0;
	}

	// Token: 0x06000D96 RID: 3478 RVA: 0x0015BDA4 File Offset: 0x00159FA4
	private void SetTitleImage()
	{
		if (this.TitleImg == null)
		{
			return;
		}
		if (this.AM.bDownLoadPic2)
		{
			if (this.AM.bUpDatePic2)
			{
				this.AM.m_ActivityAsset.UnloadAsset();
				this.AM.bUpDatePic2 = false;
			}
			if (this.AM.m_ActivityAsset.m_AssetBundleKey == 0)
			{
				this.AM.m_ActivityAsset.InitialAsset("UIActivityBack_2");
			}
			this.TitleImg.sprite = this.AM.LoadActivitySprite(this.tmpData.DetailPic);
			if (this.TitleImg.sprite == null)
			{
				this.TitleImg.sprite = this.AM.LoadActivitySprite(0);
			}
			this.TitleImg.material = this.AM.GetActivityMaterial();
			if (this.AM.m_ActivityAsset.m_Material == null || this.TitleImg.sprite == null)
			{
				this.TitleImg.enabled = false;
			}
			else
			{
				this.TitleImg.enabled = true;
			}
		}
		else
		{
			this.TitleImg.enabled = false;
		}
	}

	// Token: 0x06000D97 RID: 3479 RVA: 0x0015BEEC File Offset: 0x0015A0EC
	private void SpawnContent()
	{
		if (this.ContentT == null)
		{
			return;
		}
		((RectTransform)this.ContentT).sizeDelta = new Vector2(829f, 5f);
		if (this.bFirstBuy)
		{
			this.TimeText.gameObject.SetActive(false);
		}
		else
		{
			DateTime dateTime = GameConstants.GetDateTime(this.tmpData.EventBeginTime);
			DateTime dateTime2 = GameConstants.GetDateTime(this.tmpData.EventEndTime);
			if (this.tmpData.HeadStr == 0)
			{
				this.timeStr.Append(this.DM.mStringTable.GetStringByID(8153u));
				this.timeStr.StringToFormat(dateTime.ToString("MM/dd/yy HH:mm"));
				this.timeStr.StringToFormat(dateTime2.ToString("MM/dd/yy HH:mm"));
				this.timeStr.AppendFormat("{0} ~ {1}");
			}
			else
			{
				this.timeStr.StringToFormat(dateTime.ToString("MM/dd/yy HH:mm"));
				this.timeStr.StringToFormat(dateTime2.ToString("MM/dd/yy HH:mm"));
				this.timeStr.AppendFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpData.HeadStr));
			}
			this.TimeText.text = this.timeStr.ToString();
			this.TimeText.SetAllDirty();
			this.TimeText.cachedTextGenerator.Invalidate();
		}
		if (this.tmpData.bDownLoadStr)
		{
			if (this.tmpData.bUpDateStr)
			{
				if (this.bFirstBuy)
				{
					if (this.AM.FBActivityData.DetailStr == this.tmpData.DetailStr)
					{
						this.AM.FBActivityData.UnloadStrAB();
					}
				}
				else
				{
					if (this.AM.CSActivityData[(int)this.DataIndex].DetailStr == this.tmpData.DetailStr)
					{
						this.AM.CSActivityData[(int)this.DataIndex].UnloadStrAB();
					}
					if (this.AM.SPActivityData[(int)this.DataIndex].DetailStr == this.tmpData.DetailStr)
					{
						this.AM.SPActivityData[(int)this.DataIndex].UnloadStrAB();
					}
				}
				this.tmpData.bUpDateStr = false;
			}
			if (this.tmpData.m_StrAssetBundleKey == 0)
			{
				this.tmpData.InitialABString();
			}
			if (this.tmpData.DownLoadStr != null)
			{
				byte b = (byte)((int)(this.DM.UserLanguage - GameLanguage.GL_Eng) * this.tmpData.DownLoadStr.Count);
				if ((int)b >= this.tmpData.DownLoadStr.Content.Length || this.tmpData.DownLoadStr.Content[(int)b] == string.Empty)
				{
					b = 0;
				}
				this.TitleText.text = this.tmpData.DownLoadStr.Content[(int)(b + 1)];
				CString cstring = StringManager.Instance.SpawnString(3500);
				for (int i = 0; i < 4; i++)
				{
					if (this.tmpData.ContentTimeData[i].BeginTime > 0L)
					{
						DateTime dateTime3 = GameConstants.GetDateTime(this.tmpData.ContentTimeData[i].BeginTime);
						DateTime dateTime4 = GameConstants.GetDateTime(this.tmpData.ContentTimeData[i].BeginTime + (long)((ulong)this.tmpData.ContentTimeData[i].RequireTime));
						cstring.IntToFormat((long)dateTime3.Year, 1, false);
						cstring.IntToFormat((long)dateTime3.Month, 1, false);
						cstring.IntToFormat((long)dateTime3.Day, 1, false);
						cstring.IntToFormat((long)dateTime3.Hour, 2, false);
						cstring.IntToFormat((long)dateTime3.Minute, 2, false);
						cstring.IntToFormat((long)dateTime4.Year, 1, false);
						cstring.IntToFormat((long)dateTime4.Month, 1, false);
						cstring.IntToFormat((long)dateTime4.Day, 1, false);
						cstring.IntToFormat((long)dateTime4.Hour, 2, false);
						cstring.IntToFormat((long)dateTime4.Minute, 2, false);
					}
				}
				cstring.AppendFormat(this.tmpData.DownLoadStr.Content[(int)(b + 2)].Replace("\\n", "\n"));
				CString cstring2 = StringManager.Instance.SpawnString(30);
				CString cstring3 = StringManager.Instance.SpawnString(3500);
				for (int j = 0; j < cstring.Length; j++)
				{
					bool flag = false;
					if (cstring[j] == '*')
					{
						if (j + 4 < cstring.Length && cstring[j + 1] == 'U' && cstring[j + 2] == 'R' && cstring[j + 3] == 'L' && cstring[j + 4] == '-')
						{
							if (cstring3.Length > 0)
							{
								this.SpawnText(cstring3);
							}
							cstring3.Length = 0;
							this.NowX = this.NormalLeft;
							CString cstring4 = this.SM.SpawnString(1024);
							this.UrlObject.Add(cstring4);
							for (int k = j + 5; k < cstring.Length; k++)
							{
								if (cstring[k] == '-' && k + 4 < cstring.Length && cstring[k + 1] == 'E' && cstring[k + 2] == 'N' && cstring[k + 3] == 'D' && cstring[k + 4] == '*')
								{
									this.SpawnUrlBtn(this.UrlObject.Count - 1);
									j = k + 4;
									break;
								}
								cstring4.Append(cstring[k]);
							}
							flag = true;
						}
						else if (j + 2 < cstring.Length && cstring[j + 1] == 'I' && cstring[j + 2] == '=')
						{
							if (cstring3.Length > 0)
							{
								this.SpawnText(cstring3);
							}
							cstring3.Length = 0;
							this.NowX = this.NormalLeft + this.ItemSize / 2f;
							for (int l = j + 3; l < cstring.Length; l++)
							{
								if (cstring[l] == '/' || cstring[l] == '*')
								{
									this.SpawnItem(cstring2);
									cstring2.Length = 0;
									if (cstring[l] == '*')
									{
										j = l;
										break;
									}
								}
								else
								{
									cstring2.Append(cstring[l]);
								}
							}
							this.NowY -= this.ItemSize + this.ItemDelta;
							((RectTransform)this.ContentT).sizeDelta += new Vector2(0f, this.ItemSize + this.ItemDelta);
							flag = true;
						}
						else if (j + 2 < cstring.Length && cstring[j + 1] == 'V' && cstring[j + 2] == '=')
						{
							if (cstring3.Length > 0)
							{
								this.SpawnText(cstring3);
							}
							cstring3.Length = 0;
							bool flag2 = false;
							bool flag3 = false;
							for (int m = j + 3; m < cstring.Length; m++)
							{
								if (cstring[m] == '*')
								{
									if (!flag3)
									{
										this.SpawnText(cstring3);
									}
									cstring3.Length = 0;
									j = m;
									break;
								}
								if (!flag2 && cstring[m] == '=')
								{
									flag2 = true;
									flag3 = this.CheckVersion(cstring2);
									cstring2.Length = 0;
								}
								else if (flag2)
								{
									cstring3.Append(cstring[m]);
								}
								else
								{
									cstring2.Append(cstring[m]);
								}
							}
							flag = true;
						}
					}
					if (!flag)
					{
						cstring3.Append(cstring[j]);
					}
					if (j == cstring.Length - 1 && cstring3.Length > 0)
					{
						this.SpawnText(cstring3);
					}
				}
				StringManager.Instance.DeSpawnString(cstring2);
				StringManager.Instance.DeSpawnString(cstring3);
				StringManager.Instance.DeSpawnString(cstring);
			}
		}
		else
		{
			this.TitleText.text = string.Empty;
		}
	}

	// Token: 0x06000D98 RID: 3480 RVA: 0x0015C7B8 File Offset: 0x0015A9B8
	private void SpawnText(CString tmpContent)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(this.TextGO) as GameObject;
		gameObject.SetActive(true);
		gameObject.transform.SetParent(this.ContentT, false);
		this.DestroyGO.Add(gameObject);
		CString cstring = StringManager.Instance.SpawnString(tmpContent.Length);
		cstring.Append(tmpContent);
		this.AllObject.Add(cstring);
		UIText component = gameObject.transform.GetComponent<UIText>();
		component.text = cstring.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component.cachedTextGeneratorForLayout.Invalidate();
		component.rectTransform.anchoredPosition = new Vector2(this.NormalLeft, this.NowY);
		component.rectTransform.sizeDelta = new Vector2(709f, component.preferredHeight + 2f);
		this.RefreshTextArray.Add(component);
		this.NowY -= component.preferredHeight + this.ItemDelta;
		((RectTransform)this.ContentT).sizeDelta += new Vector2(0f, component.preferredHeight + this.ItemDelta);
	}

	// Token: 0x06000D99 RID: 3481 RVA: 0x0015C8E8 File Offset: 0x0015AAE8
	private void SpawnItem(CString tmpNum)
	{
		ushort num = 0;
		int num2 = 1;
		for (int i = tmpNum.Length - 1; i >= 0; i--)
		{
			if (tmpNum[i] < '0' || tmpNum[i] > '9')
			{
				break;
			}
			num += (ushort)(num2 * (int)(tmpNum[i] - '0'));
			num2 *= 10;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(this.ItemGO) as GameObject;
		gameObject.SetActive(true);
		gameObject.transform.SetParent(this.ContentT, false);
		this.DestroyGO.Add(gameObject);
		this.GM.ChangeHeroItemImg(gameObject.transform, eHeroOrItem.Item, num, 0, 0, 0);
		((RectTransform)gameObject.transform).anchoredPosition = new Vector2(this.NowX, this.NowY - this.ItemSize / 2f);
		this.NowX += this.ItemSize + this.ItemDelta;
	}

	// Token: 0x06000D9A RID: 3482 RVA: 0x0015C9E0 File Offset: 0x0015ABE0
	private void SpawnUrlBtn(int Index)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(this.UrlGO) as GameObject;
		gameObject.SetActive(true);
		gameObject.transform.SetParent(this.ContentT, false);
		this.DestroyGO.Add(gameObject);
		UIButton component = gameObject.transform.GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = Index;
		UIText component2 = gameObject.transform.GetChild(0).GetComponent<UIText>();
		component2.text = this.DM.mStringTable.GetStringByID(15014u);
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		component2.cachedTextGeneratorForLayout.Invalidate();
		this.RefreshTextArray.Add(component2);
		float num = component2.preferredHeight + 26f;
		((RectTransform)gameObject.transform).anchoredPosition = new Vector2(this.NormalLeft, this.NowY);
		((RectTransform)gameObject.transform).sizeDelta = new Vector2(component2.preferredWidth + 2f, num);
		this.NowY -= num + this.ItemDelta;
		((RectTransform)this.ContentT).sizeDelta += new Vector2(0f, num + this.ItemDelta);
	}

	// Token: 0x06000D9B RID: 3483 RVA: 0x0015CB24 File Offset: 0x0015AD24
	private bool CheckVersion(CString tmpNum)
	{
		ushort[] array = new ushort[3];
		int num = 1;
		int num2 = 2;
		for (int i = tmpNum.Length - 1; i >= 0; i--)
		{
			if (tmpNum[i] == '.')
			{
				num2--;
				num = 1;
			}
			else
			{
				if (tmpNum[i] < '0' || tmpNum[i] > '9')
				{
					return false;
				}
				if (num2 < 0)
				{
					return false;
				}
				ushort[] array2 = array;
				int num3 = num2;
				array2[num3] += (ushort)(num * (int)(tmpNum[i] - '0'));
				num *= 10;
			}
		}
		for (int j = 0; j < array.Length; j++)
		{
			if (GameConstants.Version[j] < array[j])
			{
				return false;
			}
			if (GameConstants.Version[j] > array[j])
			{
				return true;
			}
		}
		return true;
	}

	// Token: 0x06000D9C RID: 3484 RVA: 0x0015CBFC File Offset: 0x0015ADFC
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			if (sender.m_BtnID2 == 1)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door)
				{
					door.CloseMenu(false);
				}
			}
			else if (sender.m_BtnID2 == 2)
			{
			}
		}
		else if (sender.m_BtnID1 == 2)
		{
			if (sender.m_BtnID2 == 1)
			{
				Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door2)
				{
					if (this.tmpData.GoToButton == 1)
					{
						door2.OpenMenu(EGUIWindow.UI_Mall, 0, 0, true);
					}
					else if (this.tmpData.GoToButton == 2)
					{
						door2.OpenMenu(EGUIWindow.UI_Chat, 0, 0, false);
						GUIManager.Instance.OpenMenu(EGUIWindow.UIEmojiSelect, 2, 0, false, true, false);
						GUIManager.Instance.UpdateUI(EGUIWindow.UIEmojiSelect, 4, 1);
					}
					else if (this.tmpData.GoToButton == 3)
					{
						if (this.GM.BuildingData.GetBuildData(8, 0).Level < 9)
						{
							CString cstring = StringManager.Instance.StaticString1024();
							cstring.IntToFormat(9L, 1, false);
							cstring.AppendFormat(this.DM.mStringTable.GetStringByID(9167u));
							this.GM.AddHUDMessage(cstring.ToString(), 255, true);
						}
						else
						{
							door2.OpenMenu(EGUIWindow.UI_CastleSkin, 0, 0, true);
							GUIManager.Instance.UpdateUI(EGUIWindow.UI_CastleSkin, 1, 0);
						}
					}
					else if (this.tmpData.GoToButton == 4)
					{
						H5SDKPlugin.StartH5ByWebView(IGGGameSDK.Instance.m_IGGID, DataManager.Instance.UserLanguage.ToString(), "1", DataManager.Instance.RoleAttr.Name.ToString());
						this.GM.StopShowLiveScale = 2;
						this.GM.UpdateUI(EGUIWindow.Door, 20, 0);
					}
					else if (this.tmpData.GoToButton == 5)
					{
						if (!this.DM.MySysSetting.bMusic)
						{
							this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(10163u), 255, true);
							return;
						}
						if (!this.bPlayMaster)
						{
							this.bPlayMaster = true;
							this.NowBGM = AudioManager.Instance.GetCurMusic();
						}
						AudioManager.Instance.LoadAndPlayBGM(BGMType.Master, 1, false);
					}
					else
					{
						door2.CloseMenu(false);
					}
				}
			}
		}
		else if (sender.m_BtnID1 == 3 && sender.m_BtnID2 < this.UrlObject.Count)
		{
			Application.OpenURL(this.UrlObject[sender.m_BtnID2].ToString());
		}
	}

	// Token: 0x06000D9D RID: 3485 RVA: 0x0015CED8 File Offset: 0x0015B0D8
	private bool CheckActiviteTime()
	{
		if (this.bFirstBuy)
		{
			if (MallManager.Instance.PaidDollar > 0L || this.GM.BuildingData.GetBuildData(8, 0).Level >= 17)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door)
				{
					door.CloseMenu(false);
				}
				return true;
			}
			return false;
		}
		else
		{
			if (this.tmpData != null && this.tmpData.EventBeginTime == 0L)
			{
				Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door2)
				{
					door2.CloseMenu(false);
				}
				return true;
			}
			return false;
		}
	}

	// Token: 0x06000D9E RID: 3486 RVA: 0x0015CF8C File Offset: 0x0015B18C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			this.CheckActiviteTime();
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				for (int i = 0; i < this.RefreshTextArray.Count; i++)
				{
					if (this.RefreshTextArray[i] != null && this.RefreshTextArray[i].enabled)
					{
						this.RefreshTextArray[i].enabled = false;
						this.RefreshTextArray[i].enabled = true;
					}
				}
			}
			break;
		}
	}

	// Token: 0x06000D9F RID: 3487 RVA: 0x0015D03C File Offset: 0x0015B23C
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.SetTitleImage();
		}
		else if (arg1 == 2)
		{
			this.DestroyContentItem();
			this.SpawnContent();
		}
		else if (arg1 == 3)
		{
			if (this.bFirstBuy)
			{
				return;
			}
			if (this.CheckActiviteTime())
			{
				return;
			}
			if ((arg2 == 4 && this.tmpData == this.AM.CSActivityData[(int)this.DataIndex]) || (arg2 == 5 && this.tmpData == this.AM.SPActivityData[(int)this.DataIndex]))
			{
				this.SetTitleImage();
				this.DestroyContentItem();
				this.SpawnContent();
			}
		}
		else if (arg1 == 4 && this.CheckActiviteTime())
		{
			return;
		}
	}

	// Token: 0x06000DA0 RID: 3488 RVA: 0x0015D104 File Offset: 0x0015B304
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x04002C5C RID: 11356
	private Transform m_transform;

	// Token: 0x04002C5D RID: 11357
	private Transform ContentT;

	// Token: 0x04002C5E RID: 11358
	private GameObject TextGO;

	// Token: 0x04002C5F RID: 11359
	private GameObject ItemGO;

	// Token: 0x04002C60 RID: 11360
	private GameObject UrlGO;

	// Token: 0x04002C61 RID: 11361
	private DataManager DM;

	// Token: 0x04002C62 RID: 11362
	private GUIManager GM;

	// Token: 0x04002C63 RID: 11363
	private StringManager SM;

	// Token: 0x04002C64 RID: 11364
	private ActivityManager AM;

	// Token: 0x04002C65 RID: 11365
	private SPActivityDataType tmpData;

	// Token: 0x04002C66 RID: 11366
	private float NormalLeft = 60f;

	// Token: 0x04002C67 RID: 11367
	private float ItemSize = 60f;

	// Token: 0x04002C68 RID: 11368
	private float ItemDelta = 10f;

	// Token: 0x04002C69 RID: 11369
	private float UrlItemSize = 50f;

	// Token: 0x04002C6A RID: 11370
	private float NowX = 60f;

	// Token: 0x04002C6B RID: 11371
	private float NowY = -5f;

	// Token: 0x04002C6C RID: 11372
	private byte DataIndex;

	// Token: 0x04002C6D RID: 11373
	private List<CString> AllObject = new List<CString>();

	// Token: 0x04002C6E RID: 11374
	private List<CString> UrlObject = new List<CString>();

	// Token: 0x04002C6F RID: 11375
	private List<UIText> RefreshTextArray = new List<UIText>();

	// Token: 0x04002C70 RID: 11376
	private List<GameObject> DestroyGO = new List<GameObject>();

	// Token: 0x04002C71 RID: 11377
	private Image TitleImg;

	// Token: 0x04002C72 RID: 11378
	private UIText TitleText;

	// Token: 0x04002C73 RID: 11379
	private UIText TimeText;

	// Token: 0x04002C74 RID: 11380
	private CString timeStr;

	// Token: 0x04002C75 RID: 11381
	private BGMType NowBGM;

	// Token: 0x04002C76 RID: 11382
	private bool bPlayMaster;

	// Token: 0x04002C77 RID: 11383
	private bool bFirstBuy;
}
