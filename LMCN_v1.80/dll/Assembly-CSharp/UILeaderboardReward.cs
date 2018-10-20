using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200031F RID: 799
public class UILeaderboardReward : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001053 RID: 4179 RVA: 0x001D3768 File Offset: 0x001D1968
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_SpriteArray = base.transform.GetComponent<UISpritesArray>();
		this.m_ScrollPanel = base.transform.GetChild(1).GetComponent<ScrollPanel>();
		this.TitleText = base.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.CalculationText = base.transform.GetChild(3).GetComponent<UIText>();
		this.TitleText.font = GUIManager.Instance.GetTTFFont();
		this.TitleText.text = DataManager.Instance.mStringTable.GetStringByID(8148u);
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			Image component = base.transform.GetChild(4).GetComponent<Image>();
			component.sprite = door.LoadSprite("UI_main_close_base");
			component.material = door.LoadMaterial();
			if (GUIManager.Instance.bOpenOnIPhoneX && component)
			{
				component.enabled = false;
			}
			UIButton component2 = base.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
			component2.m_BtnID1 = 1;
			component2.m_Handler = this;
			component2.image.sprite = door.LoadSprite("UI_main_close");
			component2.image.material = door.LoadMaterial();
		}
		for (int i = 0; i < this.m_ScrollData.Length; i++)
		{
			this.m_ScrollData[i].Init();
		}
		for (int j = 0; j < this.m_ScrollObject.Length; j++)
		{
			this.m_ScrollObject[j].Init(this.m_SpriteArray);
		}
		this.SetData();
		this.InitScrollPanel();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001054 RID: 4180 RVA: 0x001D3940 File Offset: 0x001D1B40
	public override void OnClose()
	{
	}

	// Token: 0x06001055 RID: 4181 RVA: 0x001D3944 File Offset: 0x001D1B44
	public override void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x06001056 RID: 4182 RVA: 0x001D3948 File Offset: 0x001D1B48
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			if (this.m_ScrollObject != null)
			{
				for (int i = 0; i < this.m_ScrollObject.Length; i++)
				{
					this.m_ScrollObject[i].RefreshFontTextureRebuilt();
				}
				if (this.TitleText != null && this.TitleText.enabled)
				{
					this.TitleText.enabled = false;
					this.TitleText.enabled = true;
				}
			}
		}
	}

	// Token: 0x06001057 RID: 4183 RVA: 0x001D39DC File Offset: 0x001D1BDC
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (dataIdx < 0 || dataIdx > this.m_ScrollData.Length)
		{
			return;
		}
		if (panelObjectIdx < 0 || panelObjectIdx > this.m_ScrollObject.Length)
		{
			return;
		}
		if (!this.m_ScrollObject[panelObjectIdx].bInitFinish)
		{
			for (int i = 0; i < 4; i++)
			{
				this.m_ScrollObject[panelObjectIdx].Transforms[i] = item.transform.GetChild(i);
			}
			Transform child = item.transform.GetChild(0);
			this.m_ScrollObject[panelObjectIdx].InfoText = child.GetChild(0).GetComponent<UIText>();
			this.m_ScrollObject[panelObjectIdx].InfoText.font = GUIManager.Instance.GetTTFFont();
			child = item.transform.GetChild(1);
			this.m_ScrollObject[panelObjectIdx].HeadText = child.GetChild(1).GetComponent<UIText>();
			this.m_ScrollObject[panelObjectIdx].HeadText.font = GUIManager.Instance.GetTTFFont();
			child = item.transform.GetChild(2);
			this.m_ScrollObject[panelObjectIdx].TitleImage = child.GetChild(0).GetComponent<Image>();
			this.m_ScrollObject[panelObjectIdx].GradientBackground = child.GetChild(2).GetComponent<Image>();
			this.m_ScrollObject[panelObjectIdx].LeftFrame = child.GetChild(3).GetComponent<Image>();
			this.m_ScrollObject[panelObjectIdx].RightFrame = child.GetChild(4).GetComponent<Image>();
			this.m_ScrollObject[panelObjectIdx].RankingText = child.GetChild(6).GetComponent<UIText>();
			this.m_ScrollObject[panelObjectIdx].RankingText.font = GUIManager.Instance.GetTTFFont();
		}
		if (this.m_ScrollData[dataIdx].ItemType == UILeaderboardReward.eScrollItemType.Info)
		{
			this.m_ScrollObject[panelObjectIdx].SetInfoType(17223, this.m_ScrollData[dataIdx].Height);
		}
		if (this.m_ScrollData[dataIdx].ItemType == UILeaderboardReward.eScrollItemType.Head)
		{
			this.m_ScrollObject[panelObjectIdx].SetHeadType(8149);
		}
		if (this.m_ScrollData[dataIdx].ItemType == UILeaderboardReward.eScrollItemType.Item)
		{
			this.m_ScrollObject[panelObjectIdx].SetItemType(this.m_ScrollData[dataIdx].Ranking);
		}
		if (this.m_ScrollData[dataIdx].ItemType == UILeaderboardReward.eScrollItemType.Scpace)
		{
			this.m_ScrollObject[panelObjectIdx].SetSpcace(this.m_ScrollData[dataIdx].Height);
		}
	}

	// Token: 0x06001058 RID: 4184 RVA: 0x001D3C8C File Offset: 0x001D1E8C
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001059 RID: 4185 RVA: 0x001D3C90 File Offset: 0x001D1E90
	public void OnButtonClick(UIButton sender)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.CloseMenu(false);
		}
	}

	// Token: 0x0600105A RID: 4186 RVA: 0x001D3CC4 File Offset: 0x001D1EC4
	private void SetData()
	{
		int num = 0;
		this.m_ScrollData[num].ItemType = UILeaderboardReward.eScrollItemType.Info;
		this.m_ScrollData[num].TitleStrID = 17223u;
		this.m_ScrollData[num].Height = this.GetTextHeight(17223);
		this.m_ScrollData[num].Ranking = 0;
		num++;
		this.m_ScrollData[num].ItemType = UILeaderboardReward.eScrollItemType.Head;
		this.m_ScrollData[num].TitleStrID = 1u;
		this.m_ScrollData[num].Height = 30f;
		this.m_ScrollData[num].Ranking = 0;
		num++;
		this.m_ScrollData[num].ItemType = UILeaderboardReward.eScrollItemType.Scpace;
		this.m_ScrollData[num].TitleStrID = 1u;
		this.m_ScrollData[num].Height = 18f;
		this.m_ScrollData[num].Ranking = 0;
		num++;
		for (byte b = 0; b < 4; b += 1)
		{
			this.m_ScrollData[num].ItemType = UILeaderboardReward.eScrollItemType.Item;
			this.m_ScrollData[num].TitleStrID = 1u;
			this.m_ScrollData[num].Height = 312f;
			this.m_ScrollData[num].Ranking = b;
			num++;
			this.m_ScrollData[num].ItemType = UILeaderboardReward.eScrollItemType.Scpace;
			this.m_ScrollData[num].TitleStrID = 1u;
			this.m_ScrollData[num].Height = 34f;
			this.m_ScrollData[num].Ranking = b;
			num++;
		}
	}

	// Token: 0x0600105B RID: 4187 RVA: 0x001D3E80 File Offset: 0x001D2080
	private void InitScrollPanel()
	{
		List<float> list = new List<float>();
		for (int i = 0; i < this.m_ScrollData.Length; i++)
		{
			list.Add(this.m_ScrollData[i].Height);
		}
		this.m_ScrollPanel.IntiScrollPanel(566f, 0f, 0f, list, 7, this);
	}

	// Token: 0x0600105C RID: 4188 RVA: 0x001D3EE0 File Offset: 0x001D20E0
	private float GetTextHeight(ushort strID)
	{
		if (this.CalculationText != null)
		{
			this.CalculationText.font = GUIManager.Instance.GetTTFFont();
			this.CalculationText.text = DataManager.Instance.mStringTable.GetStringByID((uint)strID);
			this.CalculationText.gameObject.SetActive(false);
			return this.CalculationText.preferredHeight;
		}
		return 0f;
	}

	// Token: 0x040035AF RID: 13743
	private const int MAX_SCROLL_COUNT = 11;

	// Token: 0x040035B0 RID: 13744
	private const int MAX_SCROLL_OBJECT_COUNT = 7;

	// Token: 0x040035B1 RID: 13745
	private const float TITLE_HEIGHT = 40f;

	// Token: 0x040035B2 RID: 13746
	private const float HEAD_HEIGHT = 30f;

	// Token: 0x040035B3 RID: 13747
	private const float HEAD_SPACE = 18f;

	// Token: 0x040035B4 RID: 13748
	private const float ITEM_HEIGHT = 312f;

	// Token: 0x040035B5 RID: 13749
	private const float ITEM_SPACE = 34f;

	// Token: 0x040035B6 RID: 13750
	private UILeaderboardReward.sRewardItemData[] m_ScrollData = new UILeaderboardReward.sRewardItemData[11];

	// Token: 0x040035B7 RID: 13751
	private UILeaderboardReward.sRewardItemObject[] m_ScrollObject = new UILeaderboardReward.sRewardItemObject[7];

	// Token: 0x040035B8 RID: 13752
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040035B9 RID: 13753
	private UISpritesArray m_SpriteArray;

	// Token: 0x040035BA RID: 13754
	private UIText TitleText;

	// Token: 0x040035BB RID: 13755
	private UIText CalculationText;

	// Token: 0x02000320 RID: 800
	private enum eSpriteArray
	{
		// Token: 0x040035BD RID: 13757
		Title1,
		// Token: 0x040035BE RID: 13758
		Title2,
		// Token: 0x040035BF RID: 13759
		Title3,
		// Token: 0x040035C0 RID: 13760
		Title4,
		// Token: 0x040035C1 RID: 13761
		Frame1,
		// Token: 0x040035C2 RID: 13762
		Frame2,
		// Token: 0x040035C3 RID: 13763
		Frame3
	}

	// Token: 0x02000321 RID: 801
	private enum eScrollItemType
	{
		// Token: 0x040035C5 RID: 13765
		Info,
		// Token: 0x040035C6 RID: 13766
		Head,
		// Token: 0x040035C7 RID: 13767
		Item,
		// Token: 0x040035C8 RID: 13768
		Scpace
	}

	// Token: 0x02000322 RID: 802
	private struct sRewardItemData
	{
		// Token: 0x0600105D RID: 4189 RVA: 0x001D3F50 File Offset: 0x001D2150
		public void Init()
		{
			this.ItemType = UILeaderboardReward.eScrollItemType.Info;
			this.TitleStrID = 0u;
			this.Height = 0f;
			this.Ranking = 0;
		}

		// Token: 0x040035C9 RID: 13769
		public UILeaderboardReward.eScrollItemType ItemType;

		// Token: 0x040035CA RID: 13770
		public uint TitleStrID;

		// Token: 0x040035CB RID: 13771
		public float Height;

		// Token: 0x040035CC RID: 13772
		public byte Ranking;
	}

	// Token: 0x02000323 RID: 803
	private struct sRewardItemObject
	{
		// Token: 0x0600105E RID: 4190 RVA: 0x001D3F80 File Offset: 0x001D2180
		public void Init(UISpritesArray sp)
		{
			this.Transforms = new Transform[4];
			this.TitleImage = null;
			this.LeftFrame = null;
			this.RightFrame = null;
			this.GradientBackground = null;
			this.InfoText = null;
			this.RankingText = null;
			this.CStr = StringManager.Instance.SpawnString(100);
			this.bInitFinish = false;
			this.SpritesArray = sp;
		}

		// Token: 0x0600105F RID: 4191 RVA: 0x001D3FE4 File Offset: 0x001D21E4
		public void SetInfoType(ushort strID, float preferredHeight)
		{
			if (this.InfoText != null)
			{
				this.InfoText.rectTransform.sizeDelta = new Vector2(this.InfoText.rectTransform.sizeDelta.x, preferredHeight);
				this.InfoText.text = DataManager.Instance.mStringTable.GetStringByID((uint)strID);
				this.InfoText.SetAllDirty();
				this.InfoText.cachedTextGeneratorForLayout.Invalidate();
				this.InfoText.cachedTextGenerator.Invalidate();
				this.InfoText.UpdateArabicPos();
			}
			for (int i = 0; i < this.Transforms.Length; i++)
			{
				if (this.Transforms[i] != null)
				{
					this.Transforms[i].gameObject.SetActive(i == 0);
				}
			}
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x001D40C4 File Offset: 0x001D22C4
		public void SetHeadType(ushort strID)
		{
			if (this.HeadText != null)
			{
				this.HeadText.text = DataManager.Instance.mStringTable.GetStringByID((uint)strID);
				this.HeadText.SetAllDirty();
				this.HeadText.cachedTextGenerator.Invalidate();
				this.HeadText.UpdateArabicPos();
			}
			for (int i = 0; i < this.Transforms.Length; i++)
			{
				if (this.Transforms[i] != null)
				{
					this.Transforms[i].gameObject.SetActive(i == 1);
				}
			}
		}

		// Token: 0x06001061 RID: 4193 RVA: 0x001D4168 File Offset: 0x001D2368
		public void SetItemType(byte ranking)
		{
			for (int i = 0; i < this.Transforms.Length; i++)
			{
				if (this.Transforms[i] != null)
				{
					this.Transforms[i].gameObject.SetActive(i == 2);
				}
			}
			if (this.SpritesArray != null)
			{
				this.TitleImage.sprite = this.SpritesArray.GetSprite((int)(0 + ranking));
				if (ranking == 0)
				{
					RectTransform component = this.LeftFrame.gameObject.GetComponent<RectTransform>();
					if (component)
					{
						component.sizeDelta = new Vector2(177f, 218f);
					}
					component = this.RightFrame.gameObject.GetComponent<RectTransform>();
					if (component)
					{
						component.sizeDelta = new Vector2(177f, 218f);
					}
					this.GradientBackground.gameObject.SetActive(true);
					this.LeftFrame.gameObject.SetActive(true);
					this.RightFrame.gameObject.SetActive(true);
					this.LeftFrame.sprite = this.SpritesArray.GetSprite((int)(4 + ranking));
					this.RightFrame.sprite = this.SpritesArray.GetSprite((int)(4 + ranking));
				}
				else if (ranking == 1)
				{
					RectTransform component2 = this.LeftFrame.gameObject.GetComponent<RectTransform>();
					if (component2)
					{
						component2.sizeDelta = new Vector2(177f, 198f);
					}
					component2 = this.RightFrame.gameObject.GetComponent<RectTransform>();
					if (component2)
					{
						component2.sizeDelta = new Vector2(177f, 198f);
					}
					this.GradientBackground.gameObject.SetActive(true);
					this.LeftFrame.gameObject.SetActive(true);
					this.RightFrame.gameObject.SetActive(true);
					this.LeftFrame.sprite = this.SpritesArray.GetSprite((int)(4 + ranking));
					this.RightFrame.sprite = this.SpritesArray.GetSprite((int)(4 + ranking));
				}
				else if (ranking == 2)
				{
					RectTransform component3 = this.LeftFrame.gameObject.GetComponent<RectTransform>();
					if (component3)
					{
						component3.sizeDelta = new Vector2(177f, 174f);
					}
					component3 = this.RightFrame.gameObject.GetComponent<RectTransform>();
					if (component3)
					{
						component3.sizeDelta = new Vector2(177f, 174f);
					}
					this.GradientBackground.gameObject.SetActive(false);
					this.LeftFrame.gameObject.SetActive(true);
					this.RightFrame.gameObject.SetActive(true);
					this.LeftFrame.sprite = this.SpritesArray.GetSprite((int)(4 + ranking));
					this.RightFrame.sprite = this.SpritesArray.GetSprite((int)(4 + ranking));
				}
				else
				{
					RectTransform component4 = this.LeftFrame.gameObject.GetComponent<RectTransform>();
					if (component4)
					{
						component4.sizeDelta = new Vector2(177f, 174f);
					}
					component4 = this.RightFrame.gameObject.GetComponent<RectTransform>();
					if (component4)
					{
						component4.sizeDelta = new Vector2(177f, 174f);
					}
					this.GradientBackground.gameObject.SetActive(false);
					this.LeftFrame.gameObject.SetActive(false);
					this.RightFrame.gameObject.SetActive(false);
				}
			}
			if (this.CStr != null)
			{
				this.CStr.ClearString();
				switch (ranking)
				{
				case 0:
					this.CStr.IntToFormat(1L, 1, false);
					this.CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8150u));
					break;
				case 1:
					this.CStr.IntToFormat(2L, 1, false);
					this.CStr.IntToFormat(10L, 1, false);
					this.CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8151u));
					break;
				case 2:
					this.CStr.IntToFormat(11L, 1, false);
					this.CStr.IntToFormat(50L, 1, false);
					this.CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8151u));
					break;
				case 3:
					this.CStr.IntToFormat(51L, 1, false);
					this.CStr.IntToFormat(100L, 1, false);
					this.CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8151u));
					break;
				}
				this.RankingText.text = this.CStr.ToString();
				this.RankingText.SetAllDirty();
				this.RankingText.cachedTextGenerator.Invalidate();
				this.RankingText.UpdateArabicPos();
			}
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x001D466C File Offset: 0x001D286C
		public void SetSpcace(float space)
		{
			for (int i = 0; i < this.Transforms.Length; i++)
			{
				if (this.Transforms[i] != null)
				{
					this.Transforms[i].gameObject.SetActive(i == 3);
				}
			}
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x001D46BC File Offset: 0x001D28BC
		public void RefreshFontTextureRebuilt()
		{
			if (this.InfoText != null && this.InfoText.enabled)
			{
				this.InfoText.enabled = false;
				this.InfoText.enabled = true;
			}
			if (this.HeadText != null && this.HeadText.enabled)
			{
				this.HeadText.enabled = false;
				this.HeadText.enabled = true;
			}
			if (this.RankingText != null && this.RankingText.enabled)
			{
				this.RankingText.enabled = false;
				this.RankingText.enabled = true;
			}
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x001D4774 File Offset: 0x001D2974
		public void DestiryStr()
		{
			if (this.CStr != null)
			{
				StringManager.Instance.DeSpawnString(this.CStr);
				this.CStr = null;
			}
		}

		// Token: 0x040035CD RID: 13773
		public Transform[] Transforms;

		// Token: 0x040035CE RID: 13774
		public Image TitleImage;

		// Token: 0x040035CF RID: 13775
		public Image LeftFrame;

		// Token: 0x040035D0 RID: 13776
		public Image RightFrame;

		// Token: 0x040035D1 RID: 13777
		public Image GradientBackground;

		// Token: 0x040035D2 RID: 13778
		public UIText InfoText;

		// Token: 0x040035D3 RID: 13779
		public UIText HeadText;

		// Token: 0x040035D4 RID: 13780
		public UIText RankingText;

		// Token: 0x040035D5 RID: 13781
		public CString CStr;

		// Token: 0x040035D6 RID: 13782
		public bool bInitFinish;

		// Token: 0x040035D7 RID: 13783
		public UISpritesArray SpritesArray;
	}
}
