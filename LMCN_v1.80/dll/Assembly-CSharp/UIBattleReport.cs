using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001F4 RID: 500
public class UIBattleReport : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x0600093D RID: 2365 RVA: 0x000BCAB0 File Offset: 0x000BACB0
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_transform = base.transform;
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.tmpFont = this.GM.GetTTFFont();
		this.m_transform.GetChild(1).GetComponent<UIButton>().m_Handler = this;
		this.ScrollRC = this.m_transform.GetChild(0).GetComponent<RectTransform>();
		this.ContentT = this.m_transform.GetChild(0).GetChild(0);
		this.ContentRC = this.ContentT.GetComponent<RectTransform>();
		this.tmpBlock = this.ContentT.GetChild(1).gameObject;
		this.ExpBlock = this.ContentT.GetChild(2).gameObject;
		this.RBText[0] = this.m_transform.GetChild(3).GetComponent<UIText>();
		this.RBText[0].text = this.DM.mStringTable.GetStringByID(151u);
		this.RBText[0].font = this.tmpFont;
		this.ExpBlock.transform.GetChild(1).GetComponent<UIButton>().m_Handler = this;
		this.RBText[1] = this.ExpBlock.transform.GetChild(1).GetChild(2).GetComponent<UIText>();
		this.RBText[1].text = this.DM.mStringTable.GetStringByID(739u);
		this.RBText[1].font = this.tmpFont;
		this.m_HintBox = this.m_transform.GetChild(4).GetComponent<Image>();
		this.m_HintBox.rectTransform.sizeDelta = new Vector2(350f, 60f);
		this.m_HintText = this.m_transform.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.m_HintText.font = this.tmpFont;
		this.m_HintText.horizontalOverflow = HorizontalWrapMode.Wrap;
		float num = 0f;
		for (int i = 0; i < (int)this.DM.QBTimes; i++)
		{
			num += this.GetBlockHeight((int)this.DM.QBRewardLen[i], false) + 10f;
		}
		if (this.DM.ExpItemCount > 0)
		{
			this.bHasBonus = true;
			this.bonusCount = (int)this.DM.ExpItemCount;
		}
		if (this.bHasBonus)
		{
			num += this.GetBlockHeight(this.bonusCount, true);
		}
		else
		{
			UnityEngine.Object.Destroy(this.ContentT.GetChild(0).gameObject);
		}
		num += 102f;
		this.ContentRC.sizeDelta = new Vector2(this.ContentRC.sizeDelta.x, num);
		this.m_transform.GetChild(0).GetComponent<ScrollRect>().enabled = false;
		this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
	}

	// Token: 0x0600093E RID: 2366 RVA: 0x000BCD98 File Offset: 0x000BAF98
	public override void OnClose()
	{
		for (int i = 0; i < this.BlockTextStr.Length; i++)
		{
			if (this.BlockTextStr[i] != null)
			{
				for (int j = 0; j < this.BlockTextStr[i].Length; j++)
				{
					if (this.BlockTextStr[i][j] != null)
					{
						StringManager.Instance.DeSpawnString(this.BlockTextStr[i][j]);
					}
				}
			}
		}
	}

	// Token: 0x0600093F RID: 2367 RVA: 0x000BCE0C File Offset: 0x000BB00C
	private void Update()
	{
		float smoothDeltaTime = Time.smoothDeltaTime;
		if (this.TickCount != -1f)
		{
			this.TickCount += smoothDeltaTime;
		}
		if (this.TickCount >= this.TickTimes)
		{
			this.TickCount = 0f;
			if (this.NowIndex < (int)this.DM.QBTimes)
			{
				this.RBBlockText[this.NowIndex] = new UIText[4];
				this.BlockTextStr[this.NowIndex] = new CString[3];
				int index = (!this.bHasBonus) ? (this.NowIndex + 2) : (this.NowIndex + 3);
				GameObject gameObject = UnityEngine.Object.Instantiate(this.tmpBlock) as GameObject;
				gameObject.SetActive(true);
				gameObject.transform.SetParent(this.ContentT, false);
				RectTransform component = gameObject.GetComponent<RectTransform>();
				component.localPosition = new Vector3(component.localPosition.x, -this.BlockTop, 0f);
				this.tmpHeight = this.GetBlockHeight((int)this.DM.QBRewardLen[this.NowIndex], false);
				component.sizeDelta = new Vector2(component.sizeDelta.x, this.tmpHeight);
				this.BlockTop += this.tmpHeight + 10f;
				Transform child = this.ContentT.GetChild(index);
				this.BlockTextStr[this.NowIndex][0] = StringManager.Instance.SpawnString(30);
				this.BlockTextStr[this.NowIndex][0].IntToFormat((long)(this.NowIndex + 1), 1, false);
				this.BlockTextStr[this.NowIndex][0].AppendFormat("{0}");
				this.RBBlockText[this.NowIndex][0] = child.GetChild(6).GetComponent<UIText>();
				this.RBBlockText[this.NowIndex][0].text = this.BlockTextStr[this.NowIndex][0].ToString();
				this.RBBlockText[this.NowIndex][0].font = this.tmpFont;
				Level levelBycurrentPointID = DataManager.StageDataController.GetLevelBycurrentPointID(0);
				LevelUp recordByKey = this.DM.LevelUpTable.GetRecordByKey(levelBycurrentPointID.LeadLV);
				this.BlockTextStr[this.NowIndex][1] = StringManager.Instance.SpawnString(30);
				uint exp = (uint)(recordByKey.BattleHeroLeadExp * ((DataManager.StageDataController._stageMode != StageMode.Lean) ? 1 : 2));
				this.BlockTextStr[this.NowIndex][1].IntToFormat((long)((ulong)DataManager.Instance.GetExpAddition(exp)), 1, true);
				this.BlockTextStr[this.NowIndex][1].AppendFormat("{0}");
				this.RBBlockText[this.NowIndex][1] = child.GetChild(4).GetComponent<UIText>();
				this.RBBlockText[this.NowIndex][1].text = this.BlockTextStr[this.NowIndex][1].ToString();
				this.RBBlockText[this.NowIndex][1].font = this.tmpFont;
				this.BlockTextStr[this.NowIndex][2] = StringManager.Instance.SpawnString(30);
				this.BlockTextStr[this.NowIndex][2].IntToFormat((long)((ulong)this.DM.QBMoney), 1, true);
				this.BlockTextStr[this.NowIndex][2].AppendFormat("{0}");
				this.RBBlockText[this.NowIndex][2] = child.GetChild(5).GetComponent<UIText>();
				this.RBBlockText[this.NowIndex][2].text = this.BlockTextStr[this.NowIndex][2].ToString();
				this.RBBlockText[this.NowIndex][2].font = this.tmpFont;
				if (this.DM.QBRewardLen[this.NowIndex] > 0)
				{
					GameObject gameObject2 = child.GetChild(8).gameObject;
					for (int i = 0; i < (int)this.DM.QBRewardLen[this.NowIndex]; i++)
					{
						GameObject gameObject3 = UnityEngine.Object.Instantiate(gameObject2) as GameObject;
						gameObject3.SetActive(true);
						gameObject3.transform.SetParent(child, false);
						component = gameObject3.GetComponent<RectTransform>();
						component.localPosition += new Vector3(88f * (float)(i % 6), -88f * (float)(i / 6), 0f);
						ushort num = this.DM.QBRewardData[this.NowRWIndex];
						this.NowRWIndex++;
						UIHIBtn component2 = gameObject3.transform.GetComponent<UIHIBtn>();
						component2.m_BtnID1 = (int)num;
						component2.m_BtnID2 = 0;
						component2.m_Handler = this;
						this.GM.InitianHeroItemImg(gameObject3.transform, eHeroOrItem.Item, num, 0, 0, 0, false, true, true, false);
						gameObject3.SetActive(true);
					}
					UnityEngine.Object.Destroy(gameObject2);
				}
				else
				{
					child.GetChild(8).gameObject.SetActive(false);
					child.GetChild(7).gameObject.SetActive(true);
					this.RBBlockText[this.NowIndex][3] = child.GetChild(7).GetComponent<UIText>();
					this.RBBlockText[this.NowIndex][3].text = this.DM.mStringTable.GetStringByID(1597u);
					this.RBBlockText[this.NowIndex][3].font = this.tmpFont;
				}
				this.HintRC[this.NowIndex] = new RectTransform[2];
				UIButton component3 = gameObject.transform.GetChild(9).GetComponent<UIButton>();
				this.HintRC[this.NowIndex][0] = gameObject.transform.GetChild(9).GetComponent<RectTransform>();
				UIButtonHint uibuttonHint = component3.gameObject.AddComponent<UIButtonHint>();
				uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
				uibuttonHint.m_Handler = this;
				uibuttonHint.ControlFadeOut = this.m_HintBox.gameObject;
				component3.m_BtnID1 = this.NowIndex;
				component3.m_BtnID2 = 1;
				component3 = gameObject.transform.GetChild(10).GetComponent<UIButton>();
				this.HintRC[this.NowIndex][1] = gameObject.transform.GetChild(10).GetComponent<RectTransform>();
				uibuttonHint = component3.gameObject.AddComponent<UIButtonHint>();
				uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
				uibuttonHint.m_Handler = this;
				uibuttonHint.ControlFadeOut = this.m_HintBox.gameObject;
				component3.m_BtnID1 = this.NowIndex;
				component3.m_BtnID2 = 2;
				if (this.DM.UserLanguage == GameLanguage.GL_Chs)
				{
					gameObject.transform.GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(0);
				}
				if (this.GM.IsArabic)
				{
					gameObject.transform.GetChild(2).localScale = new Vector3(-1f, 1f, 1f);
				}
				AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
			}
			else
			{
				RectTransform component;
				if (this.bHasBonus)
				{
					Transform child = this.ContentT.GetChild(0);
					child.gameObject.SetActive(true);
					component = child.GetComponent<RectTransform>();
					component.localPosition = new Vector3(component.localPosition.x, -this.BlockTop, 0f);
					this.tmpHeight = this.GetBlockHeight(this.bonusCount, true);
					component.sizeDelta = new Vector2(component.sizeDelta.x, this.tmpHeight);
					this.BlockTop += this.tmpHeight + 10f;
					this.BonusText = child.GetChild(3).GetComponent<UIText>();
					this.BonusText.text = this.DM.mStringTable.GetStringByID(152u);
					this.BonusText.font = this.tmpFont;
					GameObject gameObject2 = child.GetChild(1).gameObject;
					this.GM.InitianHeroItemImg(gameObject2.transform, eHeroOrItem.Item, 0, 0, 0, 0, true, true, true, false);
					for (int j = 0; j < this.bonusCount; j++)
					{
						GameObject gameObject3 = UnityEngine.Object.Instantiate(gameObject2) as GameObject;
						gameObject3.transform.SetParent(child, false);
						component = gameObject3.GetComponent<RectTransform>();
						component.localPosition += new Vector3(88f * (float)(j % 7), -88f * (float)(j / 7), 0f);
						UIHIBtn component2 = gameObject3.transform.GetComponent<UIHIBtn>();
						component2.m_BtnID1 = (int)this.DM.QBExpItem[j].ItemID;
						component2.m_BtnID2 = 0;
						component2.m_Handler = this;
						this.GM.ChangeHeroItemImg(gameObject3.transform, eHeroOrItem.Item, this.DM.QBExpItem[j].ItemID, 0, 0, (int)this.DM.QBExpItem[j].Quantity);
						gameObject3.SetActive(true);
					}
					UnityEngine.Object.Destroy(gameObject2);
					AudioManager.Instance.PlayUISFX(UIKind.MissionReward);
				}
				else
				{
					UnityEngine.Object.Destroy(this.tmpBlock);
				}
				this.ExpBlock.gameObject.SetActive(true);
				component = this.ExpBlock.GetComponent<RectTransform>();
				component.localPosition = new Vector3(component.localPosition.x, -this.BlockTop, 0f);
				component.sizeDelta = new Vector2(component.sizeDelta.x, 92f);
				this.TickCount = -1f;
			}
			this.NowIndex++;
			this.moveDelta = this.tmpHeight / this.TickTimes;
		}
		if (this.bMove)
		{
			if (this.ContentRC.sizeDelta.y - this.ContentRC.anchoredPosition.y <= this.ScrollRC.sizeDelta.y)
			{
				this.bMove = false;
				this.m_transform.GetChild(0).GetComponent<ScrollRect>().enabled = true;
				this.GM.UIQueueLockRelease(EGUIQueueLock.UIQL_BattleReport);
				NewbieManager.CheckTeach(ETeachKind.WIPE_OUT, this, false);
				return;
			}
			if (this.NowIndex > 2)
			{
				this.ContentRC.localPosition += new Vector3(0f, this.moveDelta * smoothDeltaTime, 0f);
			}
		}
		if (this.bHintOpen > 0)
		{
			this.SetHint();
		}
	}

	// Token: 0x06000940 RID: 2368 RVA: 0x000BD88C File Offset: 0x000BBA8C
	private float GetBlockHeight(int ItemCount, bool bBonus = false)
	{
		if (bBonus)
		{
			return 183f + (float)((ItemCount - 1) / 7) * 88f;
		}
		return 160f + (float)((ItemCount - 1) / 6) * 88f;
	}

	// Token: 0x06000941 RID: 2369 RVA: 0x000BD8BC File Offset: 0x000BBABC
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06000942 RID: 2370 RVA: 0x000BD8C0 File Offset: 0x000BBAC0
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			(GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu(false);
			this.GM.UIQueueLockRelease(EGUIQueueLock.UIQL_BattleReport);
		}
		else if (sender.m_BtnID1 == 2)
		{
			GUIManager.Instance.m_WindowStack.RemoveAt(GUIManager.Instance.m_WindowStack.Count - 1);
			(GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BagFilter, 4, 0, false);
		}
	}

	// Token: 0x06000943 RID: 2371 RVA: 0x000BD94C File Offset: 0x000BBB4C
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		if (this.bMove || uibutton == null || uibutton.m_BtnID1 < 0 || uibutton.m_BtnID1 >= 10 || uibutton.m_BtnID2 < 1 || uibutton.m_BtnID2 > 3)
		{
			return;
		}
		this.bHintOpen = (byte)(uibutton.m_BtnID2 - 1);
		Vector3 position = this.HintRC[uibutton.m_BtnID1][(int)this.bHintOpen].position;
		this.m_HintBox.rectTransform.position = position;
		this.m_HintBox.rectTransform.anchoredPosition -= new Vector2(40f, 0f);
		this.m_HintBox.gameObject.SetActive(true);
		this.HintTime = 2f;
		this.SetHint();
	}

	// Token: 0x06000944 RID: 2372 RVA: 0x000BDA34 File Offset: 0x000BBC34
	public void OnButtonUp(UIButtonHint sender)
	{
		this.m_HintBox.gameObject.SetActive(false);
		this.bHintOpen = 0;
	}

	// Token: 0x06000945 RID: 2373 RVA: 0x000BDA50 File Offset: 0x000BBC50
	private void SetHint()
	{
		this.HintTime += Time.deltaTime;
		if (this.HintTime < 1f)
		{
			return;
		}
		this.HintTime = 0f;
		if (this.bHintOpen == 0)
		{
			this.m_HintText.text = this.DM.mStringTable.GetStringByID(1518u);
		}
		else if (this.bHintOpen == 1)
		{
			this.m_HintText.text = this.DM.mStringTable.GetStringByID(1580u);
		}
		this.m_HintBox.rectTransform.sizeDelta = new Vector2(350f, this.m_HintText.preferredHeight + 31f);
		if (this.m_HintBox.rectTransform.sizeDelta.y - this.m_HintBox.rectTransform.anchoredPosition.y > 609f)
		{
			this.m_HintBox.rectTransform.anchoredPosition = new Vector2(this.m_HintBox.rectTransform.anchoredPosition.x, -609f + this.m_HintBox.rectTransform.sizeDelta.y);
		}
	}

	// Token: 0x06000946 RID: 2374 RVA: 0x000BDB98 File Offset: 0x000BBD98
	public override bool OnBackButtonClick()
	{
		this.GM.UIQueueLockRelease(EGUIQueueLock.UIQL_BattleReport);
		return false;
	}

	// Token: 0x06000947 RID: 2375 RVA: 0x000BDBAC File Offset: 0x000BBDAC
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			for (int i = 0; i < this.RBText.Length; i++)
			{
				if (this.RBText[i] != null && this.RBText[i].enabled)
				{
					this.RBText[i].enabled = false;
					this.RBText[i].enabled = true;
				}
			}
			for (int j = 0; j < 10; j++)
			{
				for (int k = 0; k < 4; k++)
				{
					if (this.RBBlockText[j] != null && this.RBBlockText[j][k] != null && this.RBBlockText[j][k].enabled)
					{
						this.RBBlockText[j][k].enabled = false;
						this.RBBlockText[j][k].enabled = true;
					}
				}
			}
		}
	}

	// Token: 0x04001E88 RID: 7816
	private const float BtnDleta = 88f;

	// Token: 0x04001E89 RID: 7817
	private const float BlockDleta = 10f;

	// Token: 0x04001E8A RID: 7818
	private Transform m_transform;

	// Token: 0x04001E8B RID: 7819
	private DataManager DM;

	// Token: 0x04001E8C RID: 7820
	private GUIManager GM;

	// Token: 0x04001E8D RID: 7821
	private Font tmpFont;

	// Token: 0x04001E8E RID: 7822
	public Transform ContentT;

	// Token: 0x04001E8F RID: 7823
	private RectTransform ContentRC;

	// Token: 0x04001E90 RID: 7824
	private RectTransform ScrollRC;

	// Token: 0x04001E91 RID: 7825
	private GameObject tmpBlock;

	// Token: 0x04001E92 RID: 7826
	private GameObject ExpBlock;

	// Token: 0x04001E93 RID: 7827
	private float BlockTop;

	// Token: 0x04001E94 RID: 7828
	private float tmpHeight;

	// Token: 0x04001E95 RID: 7829
	private int bonusCount;

	// Token: 0x04001E96 RID: 7830
	private bool bHasBonus;

	// Token: 0x04001E97 RID: 7831
	private int NowIndex;

	// Token: 0x04001E98 RID: 7832
	private int NowRWIndex;

	// Token: 0x04001E99 RID: 7833
	private bool bMove = true;

	// Token: 0x04001E9A RID: 7834
	private float TickTimes = 0.6f;

	// Token: 0x04001E9B RID: 7835
	private float TickCount = 1.5f;

	// Token: 0x04001E9C RID: 7836
	private float moveDelta;

	// Token: 0x04001E9D RID: 7837
	private RectTransform[][] HintRC = new RectTransform[10][];

	// Token: 0x04001E9E RID: 7838
	private Image m_HintBox;

	// Token: 0x04001E9F RID: 7839
	private UIText m_HintText;

	// Token: 0x04001EA0 RID: 7840
	private byte bHintOpen;

	// Token: 0x04001EA1 RID: 7841
	private float HintTime;

	// Token: 0x04001EA2 RID: 7842
	private UIText[] RBText = new UIText[2];

	// Token: 0x04001EA3 RID: 7843
	private UIText[][] RBBlockText = new UIText[10][];

	// Token: 0x04001EA4 RID: 7844
	private UIText BonusText;

	// Token: 0x04001EA5 RID: 7845
	private CString[][] BlockTextStr = new CString[10][];
}
