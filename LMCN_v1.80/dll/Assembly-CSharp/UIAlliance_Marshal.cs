using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x020002EC RID: 748
public class UIAlliance_Marshal : IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06000F53 RID: 3923 RVA: 0x001B14BC File Offset: 0x001AF6BC
	public void OnOpen(Transform transform)
	{
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		Font ttffont = instance2.GetTTFFont();
		this.ThisTransform = transform;
		instance2.UpdateUI(EGUIWindow.Door, 1, 2);
		this.CampsTitle[0] = this.ThisTransform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.CampsTitle[0].font = ttffont;
		this.CampsTitle[1] = this.ThisTransform.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
		this.CampsTitle[1].font = ttffont;
		UIButton component = this.ThisTransform.GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 0;
		component = this.ThisTransform.GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1;
		this.TagText[0] = this.ThisTransform.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.TagText[0].font = ttffont;
		this.TagText[0].text = instance.mStringTable.GetStringByID(4868u);
		this.TagTextColor[0] = this.TagText[0].color;
		this.TagText[1] = this.ThisTransform.GetChild(2).GetChild(1).GetComponent<UIText>();
		this.TagText[1].font = ttffont;
		this.TagText[1].text = instance.mStringTable.GetStringByID(4869u);
		this.TagTextColor[1] = this.TagText[1].color;
		this.MessageRect = this.ThisTransform.GetChild(3).GetComponent<RectTransform>();
		this.MessageText = this.ThisTransform.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.MessageText.font = ttffont;
		this.CampsBkImg[0] = this.ThisTransform.GetChild(0).GetChild(1).GetComponent<Image>();
		this.CampsBkImg[1] = this.ThisTransform.GetChild(0).GetChild(2).GetComponent<Image>();
		this.TitleSprite[0] = this.CampsBkImg[0].sprite;
		this.TitleSprite[1] = this.CampsBkImg[1].sprite;
		this.TagAlpha[0] = this.ThisTransform.GetChild(1).GetChild(0).GetComponent<CanvasGroup>();
		this.TagAlpha[1] = this.ThisTransform.GetChild(2).GetChild(0).GetComponent<CanvasGroup>();
		this.RotationImg = this.ThisTransform.GetChild(7);
		Transform child = this.ThisTransform.GetChild(5);
		child.GetChild(0).GetChild(2).GetComponent<UIText>().font = ttffont;
		child.GetChild(1).GetChild(2).GetComponent<UIText>().font = ttffont;
		child.GetChild(0).GetChild(3).GetComponent<UIText>().font = ttffont;
		child.GetChild(1).GetChild(3).GetComponent<UIText>().font = ttffont;
		UIText component2 = child.GetChild(0).GetChild(5).GetComponent<UIText>();
		component2.font = ttffont;
		component2.resizeTextForBestFit = true;
		component2.resizeTextMaxSize = 18;
		component2.rectTransform.sizeDelta = new Vector2(210f, 32f);
		component2 = child.GetChild(1).GetChild(5).GetComponent<UIText>();
		component2.font = ttffont;
		component2.resizeTextForBestFit = true;
		component2.resizeTextMaxSize = 18;
		child.GetChild(2).GetChild(3).GetComponent<UIText>().font = ttffont;
		child.GetChild(2).GetChild(4).GetComponent<UIText>().font = ttffont;
		this.TagInfo[0].Tip = this.ThisTransform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
		this.TagInfo[0].TagImage = this.ThisTransform.GetChild(1).GetChild(2).GetComponent<Image>();
		this.TagInfo[0].NumText = this.TagInfo[0].Tip.GetChild(0).GetComponent<UIText>();
		this.TagInfo[0].NumText.font = ttffont;
		this.TagInfo[0].Init();
		this.TagInfo[1].Tip = this.ThisTransform.GetChild(2).GetChild(2).GetComponent<RectTransform>();
		this.TagInfo[1].TagImage = this.ThisTransform.GetChild(2).GetChild(2).GetComponent<Image>();
		this.TagInfo[1].NumText = this.TagInfo[1].Tip.GetChild(0).GetComponent<UIText>();
		this.TagInfo[1].NumText.font = ttffont;
		this.TagInfo[1].Init();
		this.ScrollContent = this.ThisTransform.GetChild(4).gameObject;
		if (instance.UserLanguage == GameLanguage.GL_Chs)
		{
			this.ThisTransform.GetChild(8).GetComponent<UISpritesArray>().SetSpriteIndex(0);
		}
		if (instance2.IsArabic)
		{
			this.ThisTransform.GetChild(8).localScale = new Vector3(-1f, 1f, 1f);
		}
		this.GuideObject = this.ThisTransform.GetChild(6).gameObject;
		if (!byte.TryParse(PlayerPrefs.GetString("Marshal_Guide"), out this.ShowGuide))
		{
			this.ShowGuide = 1;
			PlayerPrefs.SetString("Marshal_Guide", this.ShowGuide.ToString());
		}
	}

	// Token: 0x06000F54 RID: 3924 RVA: 0x001B1A78 File Offset: 0x001AFC78
	public void Init()
	{
		GUIManager instance = GUIManager.Instance;
		uTweenScale uTweenScale = this.GuideObject.transform.GetChild(0).gameObject.AddComponent<uTweenScale>();
		uTweenScale.easeType = EaseType.linear;
		uTweenScale.loopStyle = LoopStyle.Loop;
		uTweenScale.delay = 0.2f;
		uTweenScale.from = Vector3.one;
		uTweenScale.to = new Vector3(3f, 3f, 3f);
		uTweenAlpha uTweenAlpha = this.GuideObject.transform.GetChild(0).gameObject.AddComponent<uTweenAlpha>();
		uTweenAlpha.easeType = EaseType.linear;
		uTweenAlpha.loopStyle = LoopStyle.Loop;
		uTweenAlpha.delay = 0.2f;
		uTweenAlpha.from = 1f;
		uTweenAlpha.to = 0f;
		uTweenAlpha.mMaskableGraphic = this.GuideObject.transform.GetChild(0).GetComponent<Image>();
		uTweenPosition uTweenPosition = this.GuideObject.transform.GetChild(1).gameObject.AddComponent<uTweenPosition>();
		uTweenPosition.easeType = EaseType.easeOutQuad;
		uTweenPosition.loopStyle = LoopStyle.PingPong;
		uTweenPosition.duration = 0.5f;
		uTweenPosition.from = new Vector3(224f, 17.8f, 0f);
		uTweenPosition.to = new Vector3(241f, 0.8f, 0f);
		Transform child = this.ThisTransform.GetChild(5);
		instance.InitianHeroItemImg(child.GetChild(0).GetChild(1).GetChild(0), eHeroOrItem.Hero, 0, 0, 0, 0, false, false, false, false);
		instance.InitianHeroItemImg(child.GetChild(1).GetChild(1).GetChild(0), eHeroOrItem.Hero, 0, 0, 0, 0, false, false, false, false);
		this.ItemCount = 5;
		this.ItemEdit = new UIAlliance_Marshal.MarshalList[(int)this.ItemCount];
		this.WarScrollView = this.ThisTransform.GetChild(4).GetChild(0).GetComponent<ScrollPanel>();
		byte b = 0;
		while ((ushort)b < this.ItemCount)
		{
			this.ItemsHeight.Add(128f);
			b += 1;
		}
		this.WarScrollView.IntiScrollPanel(435f, 0f, 3f, this.ItemsHeight, (int)this.ItemCount, this);
		this.Content = this.ThisTransform.GetChild(4).GetChild(0).GetChild(0).GetComponent<RectTransform>();
		DataManager.Instance.CheckWalHall_List();
		if (instance.MarshalSaved == 0)
		{
			this.ChangeTag(this.CurrentTag, true);
		}
		else
		{
			this.ChangeTag((UIAlliance_Marshal.ClickType)(instance.MarshalSaved - 1), true);
		}
	}

	// Token: 0x06000F55 RID: 3925 RVA: 0x001B1CF0 File Offset: 0x001AFEF0
	private void ChangeTag(UIAlliance_Marshal.ClickType tag, bool bForceUpdate = false)
	{
		if (!bForceUpdate && tag == this.CurrentTag)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		int currentTag = (int)this.CurrentTag;
		this.CurrentTag = tag;
		this.TagText[currentTag].color = this.TagTextColor[currentTag];
		this.TagAlpha[currentTag].alpha = 0f;
		this.ActiveTagAlpha = this.TagAlpha[(int)this.CurrentTag];
		this.TagText[(int)this.CurrentTag].color = Color.white;
		List<WarlobbyData> list = instance.WarHall[(int)((byte)this.CurrentTag)];
		if (list != null)
		{
			this.ItemCount = (ushort)list.Count;
			if (this.ShowGuide == 1 && this.ItemCount > 0)
			{
				this.GuideObject.SetActive(true);
			}
			else
			{
				this.GuideObject.SetActive(false);
			}
		}
		else
		{
			this.ItemCount = 0;
			if (this.ShowGuide == 1)
			{
				this.GuideObject.SetActive(false);
			}
		}
		if (this.CurrentTag == UIAlliance_Marshal.ClickType.AttackTag)
		{
			this.CampsTitle[0].text = instance.mStringTable.GetStringByID(4870u);
			this.CampsTitle[1].text = instance.mStringTable.GetStringByID(4871u);
			this.MessageText.text = instance.mStringTable.GetStringByID(5782u);
			this.CampsBkImg[0].sprite = this.TitleSprite[1];
			this.CampsBkImg[1].sprite = this.TitleSprite[0];
		}
		else
		{
			this.CampsTitle[0].text = instance.mStringTable.GetStringByID(5760u);
			this.CampsTitle[1].text = instance.mStringTable.GetStringByID(5761u);
			this.MessageText.text = instance.mStringTable.GetStringByID(5783u);
			this.CampsBkImg[0].sprite = this.TitleSprite[0];
			this.CampsBkImg[1].sprite = this.TitleSprite[1];
		}
		for (int i = 0; i < this.ItemEdit.Length; i++)
		{
			this.ItemEdit[i].SetType(this.CurrentTag);
		}
		if (this.ItemCount > 0)
		{
			this.ScrollContent.SetActive(true);
			this.MessageRect.gameObject.SetActive(false);
		}
		else
		{
			this.ScrollContent.SetActive(false);
			this.MessageRect.gameObject.SetActive(true);
		}
		int num = this.ItemsHeight.Count - (int)this.ItemCount;
		if (num < 0)
		{
			short num2 = 0;
			while ((int)num2 > num)
			{
				this.ItemsHeight.Add(128f);
				num2 -= 1;
			}
		}
		else if (num > 0)
		{
			byte b = 0;
			while ((int)b < num)
			{
				this.ItemsHeight.RemoveAt(0);
				b += 1;
			}
		}
		if (this.ItemsHeight.Count > 0)
		{
			this.SortItemData();
			this.WarScrollView.AddNewDataHeight(this.ItemsHeight, true, true);
			this.MessageRect.gameObject.SetActive(false);
			this.ScrollContent.SetActive(true);
		}
		else
		{
			this.MessageRect.gameObject.SetActive(true);
			this.ScrollContent.SetActive(false);
		}
		this.TagInfo[0].SetNum((byte)instance.ActiveRallyRecNum);
		this.TagInfo[1].SetNum((byte)instance.BeingRallyRecNum);
	}

	// Token: 0x06000F56 RID: 3926 RVA: 0x001B208C File Offset: 0x001B028C
	public void SortItemData()
	{
		List<WarlobbyData> list = DataManager.Instance.WarHall[(int)((byte)this.CurrentTag)];
		if (list == null)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			list[i].DataIndex = i;
		}
		this.SortData.Clear();
		this.SortData.AddRange(list);
		this.SortData.Sort(this.WarComparer);
	}

	// Token: 0x06000F57 RID: 3927 RVA: 0x001B2100 File Offset: 0x001B0300
	public void OnButtonClick(UIButton sender)
	{
		if (this.DelayInit > 0)
		{
			return;
		}
		this.ChangeTag((UIAlliance_Marshal.ClickType)sender.m_BtnID1, false);
	}

	// Token: 0x06000F58 RID: 3928 RVA: 0x001B211C File Offset: 0x001B031C
	public void OnClose()
	{
		if (this.DelayInit == 0)
		{
			GUIManager.Instance.MarshalSaved = (byte)(this.CurrentTag + 1);
		}
		if (this.ItemEdit != null)
		{
			for (int i = 0; i < this.ItemEdit.Length; i++)
			{
				this.ItemEdit[i].OnClose();
			}
		}
		for (int j = 0; j < this.TagInfo.Length; j++)
		{
			this.TagInfo[j].Destroy();
		}
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_WindowStack.Count > 0)
		{
			GUIWindowStackData value = door.m_WindowStack[door.m_WindowStack.Count - 1];
			value.m_Arg1 = 0;
			door.m_WindowStack[door.m_WindowStack.Count - 1] = value;
		}
	}

	// Token: 0x06000F59 RID: 3929 RVA: 0x001B220C File Offset: 0x001B040C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.ItemEdit[panelObjectIdx] == null)
		{
			this.ItemEdit[panelObjectIdx] = new UIAlliance_Marshal.MarshalList(item.transform, this.SortData);
		}
		else
		{
			this.ItemEdit[panelObjectIdx].SetData(dataIdx, this.CurrentTag);
		}
	}

	// Token: 0x06000F5A RID: 3930 RVA: 0x001B2258 File Offset: 0x001B0458
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		int num = 0;
		if (this.ShowGuide == 1)
		{
			PlayerPrefs.SetString("Marshal_Guide", "0");
		}
		AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		if (this.SortData[dataIndex].AllyNameID == DataManager.Instance.RoleAttr.Name.GetHashCode(false))
		{
			num |= 32768;
		}
		num |= this.SortData[dataIndex].DataIndex;
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		door.OpenMenu(EGUIWindow.UI_Rally, (int)this.CurrentTag, num, false);
	}

	// Token: 0x06000F5B RID: 3931 RVA: 0x001B22F8 File Offset: 0x001B04F8
	public void Update()
	{
		if (this.DelayInit > 0)
		{
			this.DelayInit -= 1;
			if (this.DelayInit == 0)
			{
				this.Init();
			}
			return;
		}
		for (int i = 0; i < this.ItemEdit.Length; i++)
		{
			this.ItemEdit[i].Update();
		}
		Quaternion rotation = this.RotationImg.rotation;
		Vector3 eulerAngles = this.RotationImg.rotation.eulerAngles;
		float num = this.RotTime / this.MaxRotTime;
		if (num <= 1f)
		{
			eulerAngles.z = 360f * num;
		}
		else
		{
			eulerAngles.z = (this.RotTime = 0f);
		}
		this.RotTime += Time.deltaTime;
		rotation.eulerAngles = eulerAngles;
		this.RotationImg.rotation = rotation;
		if (this.ActiveTagAlpha != null)
		{
			this.TagTimer += Time.smoothDeltaTime;
			if (this.TagTimer >= 2f)
			{
				this.TagTimer = 0f;
			}
			float alpha = (this.TagTimer <= 1f) ? this.TagTimer : (2f - this.TagTimer);
			this.ActiveTagAlpha.alpha = alpha;
		}
	}

	// Token: 0x06000F5C RID: 3932 RVA: 0x001B2458 File Offset: 0x001B0658
	public void UpdateNetwork(byte[] meg)
	{
		if (meg[0] == 0)
		{
			DataManager.Instance.CheckWalHall_List();
		}
		else if (meg[0] == 35)
		{
			if (this.MessageText != null)
			{
				this.MessageText.enabled = false;
				this.MessageText.enabled = true;
			}
			for (int i = 0; i < this.TagText.Length; i++)
			{
				if (this.TagText[i] != null)
				{
					this.TagText[i].enabled = false;
					this.TagText[i].enabled = true;
				}
				if (this.CampsTitle[i] != null)
				{
					this.CampsTitle[i].enabled = false;
					this.CampsTitle[i].enabled = true;
				}
				if (this.TagInfo[i].NumText != null)
				{
					this.TagInfo[i].NumText.enabled = false;
					this.TagInfo[i].NumText.enabled = true;
				}
			}
			if (this.ItemEdit != null)
			{
				for (int j = 0; j < this.ItemEdit.Length; j++)
				{
					if (this.ItemEdit[j] == null)
					{
						break;
					}
					this.ItemEdit[j].TextRefresh();
				}
			}
		}
	}

	// Token: 0x06000F5D RID: 3933 RVA: 0x001B25B4 File Offset: 0x001B07B4
	public void UpdateUI(int arg1, int arg2)
	{
		if (this.DelayInit > 0)
		{
			this.Init();
			this.DelayInit = 0;
		}
		int beginIdx = this.WarScrollView.GetBeginIdx();
		float y = this.Content.anchoredPosition.y;
		this.ChangeTag(this.CurrentTag, true);
		if (this.WarScrollView.gameObject.activeSelf)
		{
			this.WarScrollView.GoTo(beginIdx, y);
		}
	}

	// Token: 0x0400329F RID: 12959
	private List<float> ItemsHeight = new List<float>();

	// Token: 0x040032A0 RID: 12960
	private List<WarlobbyData> SortData = new List<WarlobbyData>();

	// Token: 0x040032A1 RID: 12961
	private GameObject ScrollContent;

	// Token: 0x040032A2 RID: 12962
	private GameObject GuideObject;

	// Token: 0x040032A3 RID: 12963
	private ScrollPanel WarScrollView;

	// Token: 0x040032A4 RID: 12964
	private ushort ItemCount;

	// Token: 0x040032A5 RID: 12965
	private RectTransform Content;

	// Token: 0x040032A6 RID: 12966
	private Transform RotationImg;

	// Token: 0x040032A7 RID: 12967
	private Transform MessageRect;

	// Token: 0x040032A8 RID: 12968
	private UIText MessageText;

	// Token: 0x040032A9 RID: 12969
	private byte ShowGuide;

	// Token: 0x040032AA RID: 12970
	private UIText[] TagText = new UIText[2];

	// Token: 0x040032AB RID: 12971
	private Color[] TagTextColor = new Color[2];

	// Token: 0x040032AC RID: 12972
	private CanvasGroup[] TagAlpha = new CanvasGroup[2];

	// Token: 0x040032AD RID: 12973
	private Image[] CampsBkImg = new Image[2];

	// Token: 0x040032AE RID: 12974
	private Sprite[] TitleSprite = new Sprite[2];

	// Token: 0x040032AF RID: 12975
	private UIText[] CampsTitle = new UIText[2];

	// Token: 0x040032B0 RID: 12976
	private CanvasGroup ActiveTagAlpha;

	// Token: 0x040032B1 RID: 12977
	private float TagTimer;

	// Token: 0x040032B2 RID: 12978
	private UIAlliance_Marshal.WarhallComp WarComparer = new UIAlliance_Marshal.WarhallComp();

	// Token: 0x040032B3 RID: 12979
	private Transform ThisTransform;

	// Token: 0x040032B4 RID: 12980
	private byte DelayInit = 1;

	// Token: 0x040032B5 RID: 12981
	private UIAlliance_Marshal.MarshalList[] ItemEdit;

	// Token: 0x040032B6 RID: 12982
	private UIAlliance_Marshal.ClickType CurrentTag;

	// Token: 0x040032B7 RID: 12983
	private UIAlliance_Marshal._TagControl[] TagInfo = new UIAlliance_Marshal._TagControl[2];

	// Token: 0x040032B8 RID: 12984
	private float RotTime;

	// Token: 0x040032B9 RID: 12985
	private float MaxRotTime = 4f;

	// Token: 0x020002ED RID: 749
	private enum UIControl
	{
		// Token: 0x040032BB RID: 12987
		Background,
		// Token: 0x040032BC RID: 12988
		Tab1,
		// Token: 0x040032BD RID: 12989
		Tab2,
		// Token: 0x040032BE RID: 12990
		Message,
		// Token: 0x040032BF RID: 12991
		ScrollCont,
		// Token: 0x040032C0 RID: 12992
		Item,
		// Token: 0x040032C1 RID: 12993
		Guide,
		// Token: 0x040032C2 RID: 12994
		RingImage,
		// Token: 0x040032C3 RID: 12995
		Image
	}

	// Token: 0x020002EE RID: 750
	private enum ItemControl
	{
		// Token: 0x040032C5 RID: 12997
		Alli1,
		// Token: 0x040032C6 RID: 12998
		Alli2,
		// Token: 0x040032C7 RID: 12999
		Bar,
		// Token: 0x040032C8 RID: 13000
		RallySpeedup
	}

	// Token: 0x020002EF RID: 751
	private enum AlliControl
	{
		// Token: 0x040032CA RID: 13002
		BackImage,
		// Token: 0x040032CB RID: 13003
		Hero,
		// Token: 0x040032CC RID: 13004
		Country,
		// Token: 0x040032CD RID: 13005
		Message,
		// Token: 0x040032CE RID: 13006
		Flag,
		// Token: 0x040032CF RID: 13007
		Total
	}

	// Token: 0x020002F0 RID: 752
	public enum ClickType
	{
		// Token: 0x040032D1 RID: 13009
		AttackTag,
		// Token: 0x040032D2 RID: 13010
		DefenceTag
	}

	// Token: 0x020002F1 RID: 753
	private struct _TagControl
	{
		// Token: 0x06000F5E RID: 3934 RVA: 0x001B262C File Offset: 0x001B082C
		public void Init()
		{
			this.NumStr = StringManager.Instance.SpawnString(30);
		}

		// Token: 0x06000F5F RID: 3935 RVA: 0x001B2640 File Offset: 0x001B0840
		public void SetNum(byte Num)
		{
			if (Num == 0)
			{
				this.Tip.gameObject.SetActive(false);
				return;
			}
			this.Tip.gameObject.SetActive(true);
			this.NumStr.ClearString();
			this.NumStr.IntToFormat((long)Num, 1, false);
			this.NumStr.AppendFormat("{0}");
			this.NumText.text = this.NumStr.ToString();
			this.NumText.SetAllDirty();
			this.NumText.cachedTextGenerator.Invalidate();
			Vector2 sizeDelta = this.Tip.sizeDelta;
			sizeDelta.x = this.NumText.preferredWidth + 47f;
			this.Tip.sizeDelta = sizeDelta;
		}

		// Token: 0x06000F60 RID: 3936 RVA: 0x001B2704 File Offset: 0x001B0904
		public void Destroy()
		{
			StringManager.Instance.DeSpawnString(this.NumStr);
		}

		// Token: 0x040032D3 RID: 13011
		public Image TagImage;

		// Token: 0x040032D4 RID: 13012
		public CString NumStr;

		// Token: 0x040032D5 RID: 13013
		public UIText NumText;

		// Token: 0x040032D6 RID: 13014
		public RectTransform Tip;
	}

	// Token: 0x020002F2 RID: 754
	private class WarhallComp : IComparer<WarlobbyData>
	{
		// Token: 0x06000F62 RID: 3938 RVA: 0x001B2720 File Offset: 0x001B0920
		public int Compare(WarlobbyData a, WarlobbyData b)
		{
			long num = a.EventTime.BeginTime + (long)((ulong)a.EventTime.RequireTime);
			long num2 = b.EventTime.BeginTime + (long)((ulong)b.EventTime.RequireTime);
			if (num < num2)
			{
				return -1;
			}
			if (num > num2)
			{
				return 1;
			}
			return 0;
		}
	}

	// Token: 0x020002F3 RID: 755
	private class MarshalList : IUIStateTransition, IUIButtonClickHandler, IUIHIBtnClickHandler
	{
		// Token: 0x06000F63 RID: 3939 RVA: 0x001B2774 File Offset: 0x001B0974
		public MarshalList(Transform Item, List<WarlobbyData> SortData)
		{
			this.SortData = SortData;
			this.CampsData[0].Init(Item.GetChild(0));
			this.CampsData[1].Init(Item.GetChild(1));
			this.CampsData[0].HeroBtn.m_Handler = this;
			this.CampsData[1].HeroBtn.m_Handler = this;
			this.BsckSprite[0] = this.CampsData[0].BackImg.sprite;
			this.BsckSprite[1] = this.CampsData[1].BackImg.sprite;
			this.scrollItem = Item.GetComponent<ScrollPanelItem>();
			this.scrollItem.m_StateTransitionHandler = this;
			this.TimeBar = new RallyTimeBar(Item.GetChild(2).GetComponent<UITimeBar>(), 0);
			this.SpeedupBtn = Item.GetChild(3).GetComponent<UIButton>();
			this.SpeedupBtn.m_Handler = this;
			if (GUIManager.Instance.IsArabic)
			{
				this.SpeedupBtn.transform.localScale = new Vector3(-1f, 1f, 1f);
			}
		}

		// Token: 0x06000F64 RID: 3940 RVA: 0x001B28C4 File Offset: 0x001B0AC4
		void IUIButtonClickHandler.OnButtonClick(UIButton sender)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 201 + this.DataIndex, false);
		}

		// Token: 0x06000F65 RID: 3941 RVA: 0x001B28FC File Offset: 0x001B0AFC
		public void SetData(int DataIndex, UIAlliance_Marshal.ClickType type)
		{
			DataManager instance = DataManager.Instance;
			ushort kingdomID = DataManager.MapDataController.kingdomData.kingdomID;
			WarlobbyData warlobbyData;
			if (type == UIAlliance_Marshal.ClickType.AttackTag)
			{
				if (instance.WarHall[0] == null || instance.WarHall[0].Count <= DataIndex)
				{
					return;
				}
				warlobbyData = this.SortData[DataIndex];
				this.DataIndex = warlobbyData.DataIndex;
				GUIManager.Instance.ChangeHeroItemImg(this.CampsData[0].HeroIcon, eHeroOrItem.Hero, warlobbyData.AllyHead, 11, 0, 0);
				this.CampsData[0].CampsText.text = warlobbyData.AllyName.ToString();
				this.CampsData[0].CampsText.SetAllDirty();
				this.CampsData[0].CampsText.cachedTextGenerator.Invalidate();
				this.CampsData[0].SetForce(warlobbyData.AllyCurrTroop, warlobbyData.AllyMAXTroop);
				if (warlobbyData.WonderID != 255)
				{
					if (ActivityManager.Instance.IsInKvK(0, false) && warlobbyData.EnemyHomeKingdom == 0)
					{
						warlobbyData.EnemyHomeKingdom = DataManager.MapDataController.OtherKingdomData.kingdomID;
					}
					if (DataManager.MapDataController.OtherKingdomData.kingdomID == ActivityManager.Instance.KOWKingdomID)
					{
						GUIManager.Instance.ChangeWonderImg(this.CampsData[1].HeroIcon, warlobbyData.WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID);
					}
					else
					{
						GUIManager.Instance.ChangeWonderImg(this.CampsData[1].HeroIcon, warlobbyData.WonderID, warlobbyData.EnemyHomeKingdom);
					}
					this.CampsData[1].Country.SetActive(true);
					if (ActivityManager.Instance.IsInKvK(0, false) && warlobbyData.EnemyHomeKingdom == 0)
					{
						warlobbyData.EnemyHomeKingdom = DataManager.MapDataController.OtherKingdomData.kingdomID;
					}
					this.CampsData[1].SetWonderName((ushort)warlobbyData.WonderID, warlobbyData.EnemyHomeKingdom);
					this.CampsData[1].SetName(warlobbyData.EnemyName, warlobbyData.EnemyAllianceTag, warlobbyData.EnemyHomeKingdom);
					this.CampsData[1].HeroBtn.m_BtnID1 = (int)DataManager.MapDataController.GetYolkMapID((ushort)warlobbyData.WonderID, 0);
					this.CampsData[1].HeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
				}
				else
				{
					if (warlobbyData.EnemyHead != 255)
					{
						GUIManager.Instance.ChangeHeroItemImg(this.CampsData[1].HeroIcon, eHeroOrItem.Hero, warlobbyData.EnemyHead, 11, 0, 0);
						this.CampsData[1].SetName(warlobbyData.EnemyName, warlobbyData.EnemyAllianceTag, warlobbyData.EnemyHomeKingdom);
					}
					else
					{
						GUIManager.Instance.ChangeNPCImg(this.CampsData[1].HeroIcon);
						this.CampsData[1].SetNpcName(warlobbyData.EnemyName);
					}
					if (warlobbyData.EnemyHomeKingdom == 0 || kingdomID == warlobbyData.EnemyHomeKingdom)
					{
						this.CampsData[1].Country.SetActive(false);
					}
					else
					{
						this.CampsData[1].Country.SetActive(true);
						this.CampsData[1].SetKingdom(warlobbyData.EnemyHomeKingdom);
					}
					this.CampsData[1].HeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(warlobbyData.EnemyCapitalPoint.zoneID, warlobbyData.EnemyCapitalPoint.pointID);
					this.CampsData[1].HeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
				}
				this.CampsData[0].HeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(warlobbyData.AllyCapitalPoint.zoneID, warlobbyData.AllyCapitalPoint.pointID);
				this.CampsData[0].HeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
				this.CampsData[0].BackImg.sprite = this.BsckSprite[1];
				this.CampsData[1].BackImg.sprite = this.BsckSprite[0];
			}
			else
			{
				if (instance.WarHall[1] == null || instance.WarHall[1].Count <= DataIndex)
				{
					return;
				}
				warlobbyData = this.SortData[DataIndex];
				if (warlobbyData.WonderID != 255)
				{
					if (DataManager.MapDataController.OtherKingdomData.kingdomID == ActivityManager.Instance.KOWKingdomID)
					{
						GUIManager.Instance.ChangeWonderImg(this.CampsData[1].HeroIcon, warlobbyData.WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID);
					}
					else
					{
						GUIManager.Instance.ChangeWonderImg(this.CampsData[1].HeroIcon, warlobbyData.WonderID, warlobbyData.AllyHomeKingdom);
					}
					this.CampsData[1].Country.SetActive(true);
					if (ActivityManager.Instance.IsInKvK(0, false) && warlobbyData.EnemyHomeKingdom == 0)
					{
						warlobbyData.EnemyHomeKingdom = DataManager.MapDataController.OtherKingdomData.kingdomID;
					}
					this.CampsData[1].SetWonderName((ushort)warlobbyData.WonderID, 0);
					this.CampsData[1].SetName(instance.RoleAlliance.Name, instance.RoleAlliance.Tag, 0);
					this.CampsData[1].SetForce(warlobbyData.AllyCurrTroop, warlobbyData.AllyMAXTroop);
					this.CampsData[1].HeroBtn.m_BtnID1 = (int)DataManager.MapDataController.GetYolkMapID((ushort)warlobbyData.WonderID, 0);
					this.CampsData[1].HeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
				}
				else
				{
					GUIManager.Instance.ChangeHeroItemImg(this.CampsData[1].HeroIcon, eHeroOrItem.Hero, warlobbyData.AllyHead, 11, 0, 0);
					this.CampsData[1].CampsText.text = warlobbyData.AllyName.ToString();
					this.CampsData[1].CampsText.SetAllDirty();
					this.CampsData[1].CampsText.cachedTextGenerator.Invalidate();
					this.CampsData[1].SetForce(warlobbyData.AllyCurrTroop, warlobbyData.AllyMAXTroop);
					this.CampsData[1].HeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(warlobbyData.AllyCapitalPoint.zoneID, warlobbyData.AllyCapitalPoint.pointID);
					this.CampsData[1].HeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
				}
				GUIManager.Instance.ChangeHeroItemImg(this.CampsData[0].HeroIcon, eHeroOrItem.Hero, warlobbyData.EnemyHead, 11, 0, 0);
				this.CampsData[0].CampsText.text = warlobbyData.EnemyName.ToString();
				this.CampsData[0].CampsText.SetAllDirty();
				this.CampsData[0].CampsText.cachedTextGenerator.Invalidate();
				this.CampsData[0].SetName(warlobbyData.EnemyName, warlobbyData.EnemyAllianceTag, warlobbyData.EnemyHomeKingdom);
				if (warlobbyData.EnemyHomeKingdom == 0 || kingdomID == warlobbyData.EnemyHomeKingdom)
				{
					this.CampsData[0].Country.SetActive(false);
				}
				else
				{
					this.CampsData[0].Country.SetActive(true);
					this.CampsData[0].SetKingdom(warlobbyData.EnemyHomeKingdom);
				}
				this.CampsData[0].HeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(warlobbyData.EnemyCapitalPoint.zoneID, warlobbyData.EnemyCapitalPoint.pointID);
				this.CampsData[0].HeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
				this.CampsData[0].BackImg.sprite = this.BsckSprite[0];
				this.CampsData[1].BackImg.sprite = this.BsckSprite[1];
			}
			Vector2 anchoredPosition = this.CampsData[1].Flag.anchoredPosition;
			anchoredPosition.x = 410.7f - this.CampsData[1].Total.preferredWidth - 25f;
			this.CampsData[1].Flag.anchoredPosition = anchoredPosition;
			if (warlobbyData != null)
			{
				if (warlobbyData.EventTime.BeginTime == 0L)
				{
					this.TimeBar.gameObject.SetActive(false);
				}
				else
				{
					this.TimeBar.gameObject.SetActive(true);
					this.TimeBar.SetTimebar(warlobbyData.Kind, warlobbyData.EventTime.BeginTime, warlobbyData.EventTime.BeginTime + (long)((ulong)warlobbyData.EventTime.RequireTime), 0L);
					if (type == UIAlliance_Marshal.ClickType.AttackTag && warlobbyData.Kind == 1)
					{
						this.SpeedupBtn.gameObject.SetActive(true);
					}
					else
					{
						this.SpeedupBtn.gameObject.SetActive(false);
					}
				}
			}
		}

		// Token: 0x06000F66 RID: 3942 RVA: 0x001B3294 File Offset: 0x001B1494
		public void SetType(UIAlliance_Marshal.ClickType Type)
		{
			this.CurrentType = Type;
			if (this.CurrentType == UIAlliance_Marshal.ClickType.AttackTag)
			{
				this.CampsData[0].Country.SetActive(false);
				this.CampsData[0].AttackFlag.enabled = true;
				this.CampsData[0].DefenseFlag.enabled = false;
				this.CampsData[1].AttackFlag.enabled = false;
				this.CampsData[1].DefenseFlag.enabled = false;
				this.CampsData[1].Country.SetActive(true);
				this.CampsData[1].Total.text = string.Empty;
			}
			else
			{
				this.CampsData[1].AttackFlag.enabled = false;
				this.CampsData[1].DefenseFlag.enabled = true;
				this.CampsData[1].Country.SetActive(false);
				this.CampsData[0].AttackFlag.enabled = false;
				this.CampsData[0].DefenseFlag.enabled = false;
				this.CampsData[0].Country.SetActive(true);
				this.CampsData[0].Total.text = string.Empty;
			}
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x001B3404 File Offset: 0x001B1604
		public void OnClose()
		{
			this.TimeBar.Destroy();
			for (int i = 0; i < this.CampsData.Length; i++)
			{
				this.CampsData[i].Destroy();
			}
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x001B3448 File Offset: 0x001B1648
		public void OnHIButtonClick(UIHIBtn sender)
		{
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.GoToMapID((ushort)sender.m_BtnID2, sender.m_BtnID1, 0, 1, true);
		}

		// Token: 0x06000F69 RID: 3945 RVA: 0x001B3488 File Offset: 0x001B1688
		public void OnStateTransition(byte state, bool instant)
		{
			switch (state)
			{
			case 0:
			{
				Graphic backImg = this.CampsData[0].BackImg;
				Color color = this.scrollItem.colors.normalColor;
				this.CampsData[1].BackImg.color = color;
				backImg.color = color;
				break;
			}
			case 1:
			{
				Graphic backImg2 = this.CampsData[0].BackImg;
				Color color = this.scrollItem.colors.highlightedColor;
				this.CampsData[1].BackImg.color = color;
				backImg2.color = color;
				break;
			}
			case 2:
			{
				Graphic backImg3 = this.CampsData[0].BackImg;
				Color color = this.scrollItem.colors.pressedColor;
				this.CampsData[1].BackImg.color = color;
				backImg3.color = color;
				break;
			}
			case 3:
			{
				Graphic backImg4 = this.CampsData[0].BackImg;
				Color color = this.scrollItem.colors.disabledColor;
				this.CampsData[1].BackImg.color = color;
				backImg4.color = color;
				break;
			}
			}
		}

		// Token: 0x06000F6A RID: 3946 RVA: 0x001B35D0 File Offset: 0x001B17D0
		public void Update()
		{
			this.TimeBar.Update();
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x001B35E0 File Offset: 0x001B17E0
		public void TextRefresh()
		{
			for (int i = 0; i < this.CampsData.Length; i++)
			{
				this.CampsData[i].TextRefresh();
			}
			if (this.TimeBar != null)
			{
				this.TimeBar.TextRefresh();
			}
		}

		// Token: 0x040032D7 RID: 13015
		private const float BarMaxWidth = 21f;

		// Token: 0x040032D8 RID: 13016
		private Sprite[] BsckSprite = new Sprite[2];

		// Token: 0x040032D9 RID: 13017
		private ScrollPanelItem scrollItem;

		// Token: 0x040032DA RID: 13018
		public UIAlliance_Marshal.MarshalList.Camps[] CampsData = new UIAlliance_Marshal.MarshalList.Camps[2];

		// Token: 0x040032DB RID: 13019
		private UIAlliance_Marshal.ClickType CurrentType;

		// Token: 0x040032DC RID: 13020
		private RallyTimeBar TimeBar;

		// Token: 0x040032DD RID: 13021
		private UIButton SpeedupBtn;

		// Token: 0x040032DE RID: 13022
		private List<WarlobbyData> SortData;

		// Token: 0x040032DF RID: 13023
		private int DataIndex;

		// Token: 0x020002F4 RID: 756
		public struct Camps
		{
			// Token: 0x06000F6C RID: 3948 RVA: 0x001B3630 File Offset: 0x001B1830
			public void Init(Transform CampsTrans)
			{
				this.HeroIcon = CampsTrans.GetChild(1).GetChild(0);
				this.HeroBtn = this.HeroIcon.GetComponent<UIHIBtn>();
				this.Country = CampsTrans.GetChild(2).gameObject;
				this.CountryText = CampsTrans.GetChild(2).GetComponent<UIText>();
				this.CampsText = CampsTrans.GetChild(3).GetComponent<UIText>();
				this.AttackFlag = CampsTrans.GetChild(4).GetComponent<Image>();
				this.DefenseFlag = CampsTrans.GetChild(4).GetChild(0).GetComponent<Image>();
				this.Flag = CampsTrans.GetChild(4).GetComponent<RectTransform>();
				this.Total = CampsTrans.GetChild(5).GetComponent<UIText>();
				this.TotalStr = StringManager.Instance.SpawnString(30);
				this.NameStr = StringManager.Instance.SpawnString(100);
				this.CountryStr = StringManager.Instance.SpawnString(30);
				GUIManager.Instance.InitianHeroItemImg(this.HeroIcon, eHeroOrItem.Hero, 0, 11, 0, 0, false, false, true, false);
				this.BackImg = CampsTrans.GetChild(0).GetComponent<Image>();
				this.CountryColor = this.CountryText.color;
			}

			// Token: 0x06000F6D RID: 3949 RVA: 0x001B375C File Offset: 0x001B195C
			public void SetForce(uint CurTroop, uint MaxTroop)
			{
				this.TotalStr.ClearString();
				this.TotalStr.IntToFormat((long)((ulong)CurTroop), 1, true);
				this.TotalStr.IntToFormat((long)((ulong)MaxTroop), 1, true);
				if (GUIManager.Instance.IsArabic)
				{
					this.TotalStr.AppendFormat("{1} / {0}");
				}
				else
				{
					this.TotalStr.AppendFormat("{0} / {1}");
				}
				this.Total.text = this.TotalStr.ToString();
				this.Total.SetAllDirty();
				this.Total.cachedTextGenerator.Invalidate();
				this.Total.cachedTextGeneratorForLayout.Invalidate();
			}

			// Token: 0x06000F6E RID: 3950 RVA: 0x001B380C File Offset: 0x001B1A0C
			public void SetName(CString Name, CString Tag, ushort homeKindom)
			{
				bool flag = false;
				if (ActivityManager.Instance.IsInKvK(0, false) && homeKindom > 0 && homeKindom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					flag = true;
				}
				this.NameStr.ClearString();
				if (flag)
				{
					GameConstants.FormatRoleName(this.NameStr, Name, Tag, null, 0, 0, null, "<color=#FF878E>", "<color=#FF878E>", null);
				}
				else
				{
					GameConstants.FormatRoleName(this.NameStr, Name, Tag, null, 0, 0, null, "<color=#FFCC00>", null, null);
				}
				this.CampsText.text = this.NameStr.ToString();
				this.CampsText.SetAllDirty();
				this.CampsText.cachedTextGenerator.Invalidate();
			}

			// Token: 0x06000F6F RID: 3951 RVA: 0x001B38C8 File Offset: 0x001B1AC8
			public void SetNpcName(CString Name)
			{
				this.NameStr.ClearString();
				this.NameStr.StringToFormat("<color=#FFCC00>");
				this.NameStr.StringToFormat(Name);
				this.NameStr.StringToFormat("</color>");
				this.NameStr.AppendFormat("{0}{1}{2}");
				this.CampsText.text = this.NameStr.ToString();
				this.CampsText.SetAllDirty();
				this.CampsText.cachedTextGenerator.Invalidate();
			}

			// Token: 0x06000F70 RID: 3952 RVA: 0x001B3950 File Offset: 0x001B1B50
			public void SetKingdom(ushort kingdomID)
			{
				this.CountryStr.ClearString();
				this.CountryStr.IntToFormat((long)kingdomID, 1, false);
				if (GUIManager.Instance.IsArabic)
				{
					this.CountryStr.AppendFormat("{0}#");
				}
				else
				{
					this.CountryStr.AppendFormat("#{0}");
				}
				this.CountryText.text = this.CountryStr.ToString();
				this.CountryText.SetAllDirty();
				this.CountryText.cachedTextGenerator.Invalidate();
				this.CountryText.color = this.CountryColor;
			}

			// Token: 0x06000F71 RID: 3953 RVA: 0x001B39F0 File Offset: 0x001B1BF0
			public void SetWonderName(ushort wonderID, ushort homeKindom)
			{
				bool flag = false;
				if (ActivityManager.Instance.IsInKvK(0, false) && homeKindom > 0 && homeKindom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					flag = true;
				}
				this.CountryStr.ClearString();
				this.CountryStr.StringToFormat(DataManager.MapDataController.GetYolkName(wonderID, 0));
				if (flag)
				{
					this.CountryStr.AppendFormat("<color=#FF878E>{0}</color>");
				}
				else
				{
					this.CountryStr.AppendFormat("{0}");
				}
				this.CountryText.text = this.CountryStr.ToString();
				this.CountryText.SetAllDirty();
				this.CountryText.cachedTextGenerator.Invalidate();
				this.CountryText.color = Color.white;
			}

			// Token: 0x06000F72 RID: 3954 RVA: 0x001B3AC0 File Offset: 0x001B1CC0
			public void Destroy()
			{
				StringManager.Instance.DeSpawnString(this.TotalStr);
				StringManager.Instance.DeSpawnString(this.NameStr);
				StringManager.Instance.DeSpawnString(this.CountryStr);
			}

			// Token: 0x06000F73 RID: 3955 RVA: 0x001B3B00 File Offset: 0x001B1D00
			public void TextRefresh()
			{
				if (this.CountryText != null)
				{
					this.CountryText.enabled = false;
					this.CountryText.enabled = true;
				}
				if (this.CampsText != null)
				{
					this.CampsText.enabled = false;
					this.CampsText.enabled = true;
				}
				if (this.Total != null)
				{
					this.Total.enabled = false;
					this.Total.enabled = true;
				}
			}

			// Token: 0x040032E0 RID: 13024
			public RectTransform Flag;

			// Token: 0x040032E1 RID: 13025
			public Transform HeroIcon;

			// Token: 0x040032E2 RID: 13026
			public UIHIBtn HeroBtn;

			// Token: 0x040032E3 RID: 13027
			public Image AttackFlag;

			// Token: 0x040032E4 RID: 13028
			public Image DefenseFlag;

			// Token: 0x040032E5 RID: 13029
			public Image BackImg;

			// Token: 0x040032E6 RID: 13030
			public GameObject Country;

			// Token: 0x040032E7 RID: 13031
			public UIText CountryText;

			// Token: 0x040032E8 RID: 13032
			public UIText CampsText;

			// Token: 0x040032E9 RID: 13033
			public UIText Total;

			// Token: 0x040032EA RID: 13034
			public CString TotalStr;

			// Token: 0x040032EB RID: 13035
			public CString NameStr;

			// Token: 0x040032EC RID: 13036
			public CString CountryStr;

			// Token: 0x040032ED RID: 13037
			private Color CountryColor;
		}
	}
}
