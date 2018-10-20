using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005AE RID: 1454
public class UIImmigration : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001CEB RID: 7403 RVA: 0x0033C498 File Offset: 0x0033A698
	public override void OnOpen(int arg1, int arg2)
	{
		this.door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.Current = base.transform;
		Transform child = this.Current.GetChild(1);
		this.StaticText[0] = child.GetChild(2).GetComponent<UIText>();
		this.StaticText[0].font = ttffont;
		this.StaticText[0].text = DataManager.Instance.mStringTable.GetStringByID(949u);
		this.StaticText[1] = child.GetChild(19).GetComponent<UIText>();
		this.StaticText[1].font = ttffont;
		this.StaticText[1].text = DataManager.Instance.mStringTable.GetStringByID(10019u);
		this.StaticText[2] = child.GetChild(16).GetComponent<UIText>();
		this.StaticText[2].font = ttffont;
		this.StaticText[2].text = DataManager.Instance.mStringTable.GetStringByID(9102u);
		this.ResTitle = child.GetChild(17).GetComponent<UIText>();
		this.ResTitle.font = ttffont;
		this.ResTitle.text = DataManager.Instance.mStringTable.GetStringByID(10020u);
		this.ResContent = child.GetChild(20).GetComponent<UIText>();
		this.ResContent.font = ttffont;
		this.ResContent.text = DataManager.Instance.mStringTable.GetStringByID(10021u);
		this.StaticText[3] = child.GetChild(18).GetComponent<UIText>();
		this.StaticText[3].font = ttffont;
		this.StaticText[3].text = DataManager.Instance.mStringTable.GetStringByID(10023u);
		this.NeedItemCountText = child.GetChild(15).GetChild(0).GetComponent<UIText>();
		this.NeedItemCountText.font = ttffont;
		this.NeedItemCountText.rectTransform.sizeDelta = new Vector2(200f, 30f);
		this.ItemCountText = child.GetChild(25).GetComponent<UIText>();
		this.ItemCountText.font = ttffont;
		this.PlayBtnText = child.GetChild(15).GetChild(1).GetComponent<UIText>();
		this.PlayBtnText.font = ttffont;
		this.PlayBtnText.text = DataManager.Instance.mStringTable.GetStringByID(949u);
		this.PlayBtnText.rectTransform.sizeDelta = new Vector2(200f, 30f);
		this.LongTitle = child.GetChild(23).GetComponent<UIText>();
		this.LongTitle.font = ttffont;
		this.ResIcon[0] = child.GetChild(27).GetComponent<Image>();
		this.ResIcon[0].sprite = this.door.LoadSprite("UI_main_res_food");
		this.ResIcon[0].material = this.door.LoadMaterial();
		this.ResIcon[1] = child.GetChild(28).GetComponent<Image>();
		this.ResIcon[1].sprite = this.door.LoadSprite("UI_main_res_stone");
		this.ResIcon[1].material = this.door.LoadMaterial();
		this.ResIcon[2] = child.GetChild(29).GetComponent<Image>();
		this.ResIcon[2].sprite = this.door.LoadSprite("UI_main_res_wood");
		this.ResIcon[2].material = this.door.LoadMaterial();
		this.ResIcon[3] = child.GetChild(30).GetComponent<Image>();
		this.ResIcon[3].sprite = this.door.LoadSprite("UI_main_res_iron");
		this.ResIcon[3].material = this.door.LoadMaterial();
		this.ResIcon[4] = child.GetChild(31).GetComponent<Image>();
		this.ResIcon[4].sprite = this.door.LoadSprite("UI_main_money_01");
		this.ResIcon[4].material = this.door.LoadMaterial();
		Transform child2 = child.GetChild(26);
		GUIManager.Instance.InitianHeroItemImg(child2, eHeroOrItem.Item, GameConstants.WorldTeleportItemID, 0, 0, 0, false, false, true, false);
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(GameConstants.WorldTeleportItemID);
		this.StaticText[4] = child.GetChild(24).GetComponent<UIText>();
		this.StaticText[4].font = ttffont;
		if (recordByKey.EquipKey == GameConstants.WorldTeleportItemID)
		{
			this.StaticText[4].text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.EquipName);
		}
		this.MoveFilter[0] = child.GetChild(21).GetComponent<UIText>();
		this.MoveFilter[0].font = ttffont;
		this.MoveFilter[1] = child.GetChild(22).GetComponent<UIText>();
		this.MoveFilter[1].font = ttffont;
		this.IconX[0] = child.GetChild(10).GetComponent<Image>();
		this.IconX[1] = child.GetChild(11).GetComponent<Image>();
		this.IconV[0] = child.GetChild(12).GetComponent<Image>();
		this.IconV[1] = child.GetChild(13).GetComponent<Image>();
		this.IconX[0].gameObject.AddComponent<ArabicItemTextureRot>();
		this.IconX[1].gameObject.AddComponent<ArabicItemTextureRot>();
		this.IconV[0].gameObject.AddComponent<ArabicItemTextureRot>();
		this.IconV[1].gameObject.AddComponent<ArabicItemTextureRot>();
		this.AnimIcon[0] = child.GetChild(6).GetComponent<Image>();
		this.AnimIcon[1] = child.GetChild(7).GetComponent<Image>();
		this.AnimIcon2[0] = child.GetChild(8).GetComponent<Image>();
		this.AnimIcon2[1] = child.GetChild(9).GetComponent<Image>();
		this.AnimIcon[0].gameObject.AddComponent<ArabicItemTextureRot>();
		this.AnimIcon[1].gameObject.AddComponent<ArabicItemTextureRot>();
		this.AnimIcon2[0].gameObject.AddComponent<ArabicItemTextureRot>();
		this.AnimIcon2[1].gameObject.AddComponent<ArabicItemTextureRot>();
		this.ResIconV = child.GetChild(32).GetComponent<Image>();
		this.ResIconV.gameObject.AddComponent<ArabicItemTextureRot>();
		UIButton component = child.GetChild(33).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 2;
		this.PlayBtn = child.GetChild(15).GetComponent<UIButton>();
		this.PlayBtn.m_Handler = this;
		this.PlayBtn.m_BtnID1 = 1;
		this.PlayBtnImage = child.GetChild(15).GetComponent<Image>();
		component = this.Current.GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 2;
		this.ResTitleStr = StringManager.Instance.SpawnString(30);
		this.LongTitleStr = StringManager.Instance.SpawnString(200);
		this.NeedItemCountStr = StringManager.Instance.SpawnString(30);
		this.ItemCountStr = StringManager.Instance.SpawnString(30);
		this.ReCheckData();
	}

	// Token: 0x06001CEC RID: 7404 RVA: 0x0033CBC4 File Offset: 0x0033ADC4
	public override void OnClose()
	{
		if (this.ResTitleStr != null)
		{
			StringManager.Instance.DeSpawnString(this.ResTitleStr);
		}
		if (this.LongTitleStr != null)
		{
			StringManager.Instance.DeSpawnString(this.LongTitleStr);
		}
		if (this.NeedItemCountStr != null)
		{
			StringManager.Instance.DeSpawnString(this.NeedItemCountStr);
		}
		if (this.ItemCountStr != null)
		{
			StringManager.Instance.DeSpawnString(this.ItemCountStr);
		}
	}

	// Token: 0x06001CED RID: 7405 RVA: 0x0033CC44 File Offset: 0x0033AE44
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Refresh_TroopHome && networkNews != NetworkNews.Refresh_BuffList && networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
		}
		else
		{
			this.ReCheckData();
		}
	}

	// Token: 0x06001CEE RID: 7406 RVA: 0x0033CC90 File Offset: 0x0033AE90
	public void ReCheckData()
	{
		bool bEnable = true;
		if (DataManager.Instance.WorldTeleportRank > 0)
		{
			this.LongTitleStr.ClearString();
			this.LongTitleStr.IntToFormat((long)DataManager.Instance.WorldTeleportRank, 1, false);
			this.LongTitleStr.IntToFormat((long)DataManager.Instance.WorldTeleportItemCount, 1, false);
			this.LongTitleStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(950u));
			this.LongTitle.enabled = true;
			this.LongTitle.text = this.LongTitleStr.ToString();
			this.LongTitle.SetAllDirty();
			this.LongTitle.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.LongTitle.enabled = false;
		}
		this.PlayBtn.m_BtnID2 = 0;
		if (!this.CheckResource())
		{
			this.PlayBtn.m_BtnID2 |= 1;
		}
		if (!this.CheckMarchAndBuff())
		{
			bEnable = false;
		}
		int curItemQuantity = (int)DataManager.Instance.GetCurItemQuantity(GameConstants.WorldTeleportItemID, 0);
		if (curItemQuantity < (int)DataManager.Instance.WorldTeleportItemCount)
		{
			bEnable = false;
		}
		this.ItemCountStr.ClearString();
		this.ItemCountStr.Append(DataManager.Instance.mStringTable.GetStringByID(281u));
		this.ItemCountStr.IntToFormat((long)curItemQuantity, 1, true);
		this.ItemCountStr.AppendFormat("{0}");
		this.ItemCountText.text = this.ItemCountStr.ToString();
		this.ItemCountText.SetAllDirty();
		this.ItemCountText.cachedTextGenerator.Invalidate();
		this.SetPlayButtonEnable(bEnable, curItemQuantity);
	}

	// Token: 0x06001CEF RID: 7407 RVA: 0x0033CE38 File Offset: 0x0033B038
	private void SetPlayButtonEnable(bool bEnable, int itemCt)
	{
		if (itemCt < (int)DataManager.Instance.WorldTeleportItemCount)
		{
			this.PlayBtn.m_BtnID2 |= 2;
			this.NeedItemCountText.color = new Color(0.898f, 0f, 0.31f);
		}
		else
		{
			this.NeedItemCountText.color = ((!bEnable) ? Color.gray : Color.white);
		}
		this.NeedItemCountStr.ClearString();
		this.NeedItemCountStr.Append(DataManager.Instance.mStringTable.GetStringByID(951u));
		this.NeedItemCountStr.Append(DataManager.Instance.WorldTeleportItemCount.ToString());
		this.NeedItemCountText.text = this.NeedItemCountStr.ToString();
		this.NeedItemCountText.SetAllDirty();
		this.NeedItemCountText.cachedTextGenerator.Invalidate();
		if (bEnable)
		{
			this.PlayBtn.m_BtnID3 = 1;
			this.PlayBtnImage.color = Color.white;
			this.PlayBtnText.color = Color.white;
		}
		else
		{
			this.PlayBtn.m_BtnID3 = 0;
			this.PlayBtnImage.color = Color.gray;
			this.PlayBtnText.color = Color.gray;
		}
	}

	// Token: 0x06001CF0 RID: 7408 RVA: 0x0033CF84 File Offset: 0x0033B184
	private bool CheckResource()
	{
		bool result = false;
		DataManager instance = DataManager.Instance;
		uint effectBaseVal = instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PROTCTION);
		RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(9, 0);
		BuildLevelRequest buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(9, buildData.Level);
		float num = (10000u + effectBaseVal) / 10000f;
		uint num2 = GameConstants.appCeil(buildLevelRequestData.Value1 * num);
		this.ResMax = num2;
		for (int i = 0; i < 5; i++)
		{
			this.ResIcon[i].enabled = false;
		}
		int num3 = 0;
		int num4 = 0;
		while (num4 < instance.Resource.Length && num4 < 5)
		{
			if (instance.Resource[num4].Stock > num2)
			{
				this.ResIcon[num4].enabled = true;
				this.ResIcon[num4].rectTransform.anchoredPosition = UIImmigration.ResStart + new Vector2(64f * (float)num3, 0f);
				num3++;
			}
			num4++;
		}
		if (num3 == 0)
		{
			this.ResContent.color = UIImmigration.ResContentNormal;
			this.ResContent.text = DataManager.Instance.mStringTable.GetStringByID(10022u);
			this.ResContent.rectTransform.anchoredPosition = UIImmigration.ResContentPos;
			this.AnimIcon2[0].enabled = false;
			this.AnimIcon2[1].enabled = false;
			this.ResIconV.enabled = true;
			result = true;
		}
		else
		{
			this.ResContent.color = UIImmigration.ResContentRed;
			this.ResContent.text = DataManager.Instance.mStringTable.GetStringByID(10021u);
			this.ResContent.rectTransform.anchoredPosition = UIImmigration.ResContentPos + new Vector2((float)(64 * num3), 0f);
			this.AnimIcon2[0].enabled = true;
			this.AnimIcon2[1].enabled = true;
			this.ResIconV.enabled = false;
		}
		this.ResTitleStr.ClearString();
		this.ResTitleStr.uLongToFormat((ulong)num2, 1, true);
		this.ResTitleStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10020u));
		this.ResTitle.text = this.ResTitleStr.ToString();
		this.ResTitle.SetAllDirty();
		this.ResTitle.cachedTextGenerator.Invalidate();
		return result;
	}

	// Token: 0x06001CF1 RID: 7409 RVA: 0x0033D21C File Offset: 0x0033B41C
	private bool CheckMarchAndBuff()
	{
		DataManager instance = DataManager.Instance;
		bool flag = false;
		for (int i = 0; i < (int)instance.MaxMarchEventNum; i++)
		{
			if (instance.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
			{
				flag = true;
			}
		}
		bool bHaveWarBuff = instance.bHaveWarBuff;
		if (!flag && !bHaveWarBuff)
		{
			this.MoveFilter[0].text = instance.mStringTable.GetStringByID(10026u);
			this.IconX[0].enabled = false;
			this.IconV[0].enabled = true;
			this.MoveFilter[1].enabled = false;
			this.IconX[1].enabled = false;
			this.IconV[1].enabled = false;
		}
		else
		{
			int num = 0;
			if (flag)
			{
				this.MoveFilter[num].enabled = true;
				this.MoveFilter[num].text = instance.mStringTable.GetStringByID(10024u);
				this.IconX[num].enabled = true;
				this.IconV[num].enabled = false;
				num++;
			}
			if (bHaveWarBuff)
			{
				this.MoveFilter[num].enabled = true;
				this.MoveFilter[num].text = instance.mStringTable.GetStringByID(10025u);
				this.IconX[num].enabled = true;
				this.IconV[num].enabled = false;
				num++;
			}
			if (num <= 1)
			{
				this.MoveFilter[1].enabled = false;
				this.IconX[1].enabled = false;
				this.IconV[1].enabled = false;
			}
		}
		return !flag && !bHaveWarBuff;
	}

	// Token: 0x06001CF2 RID: 7410 RVA: 0x0033D3CC File Offset: 0x0033B5CC
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			DataManager instance = DataManager.Instance;
			if ((sender.m_BtnID2 & 2) != 0)
			{
				GUIManager.Instance.OpenMessageBox(instance.mStringTable.GetStringByID(3782u), instance.mStringTable.GetStringByID(955u), null, null, 0, 0, false, false, false, false, false);
				return;
			}
			if (sender.m_BtnID3 == 1)
			{
				if ((sender.m_BtnID2 & 1) != 0)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.ClearString();
					cstring.uLongToFormat((ulong)this.ResMax, 1, false);
					cstring.AppendFormat(instance.mStringTable.GetStringByID(959u));
					GUIManager.Instance.OpenOKCancelBox(13, instance.mStringTable.GetStringByID(5893u), cstring.ToString(), UIImmigration.kingdomID, UIImmigration.mapPointID, instance.mStringTable.GetStringByID(3u), instance.mStringTable.GetStringByID(4u));
					return;
				}
				CString cstring2 = StringManager.Instance.StaticString1024();
				cstring2.ClearString();
				cstring2.Append(instance.mStringTable.GetStringByID(958u));
				GUIManager.Instance.OpenOKCancelBox(13, instance.mStringTable.GetStringByID(5893u), cstring2.ToString(), UIImmigration.kingdomID, UIImmigration.mapPointID, instance.mStringTable.GetStringByID(3u), instance.mStringTable.GetStringByID(4u));
				return;
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(5771u), 255, true);
			}
		}
		else if (sender.m_BtnID1 == 2)
		{
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_Immigration);
		}
	}

	// Token: 0x06001CF3 RID: 7411 RVA: 0x0033D570 File Offset: 0x0033B770
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 0)
		{
			this.ReCheckData();
		}
	}

	// Token: 0x06001CF4 RID: 7412 RVA: 0x0033D598 File Offset: 0x0033B798
	public void Update()
	{
		this.WarningIconAlpha += this.WarningIconAlphaSign * Time.deltaTime * 2f;
		if (this.WarningIconAlpha >= 1f || this.WarningIconAlpha <= 0f)
		{
			if (this.WarningIconAlpha >= 1f)
			{
				this.WarningIconAlpha = 1f;
			}
			else if (this.WarningIconAlpha <= 0f)
			{
				this.WarningIconAlpha = 0f;
			}
			this.WarningIconAlphaSign *= -1f;
		}
		if (this.AnimIcon[0].enabled)
		{
			Color white = Color.white;
			white.a = this.WarningIconAlpha;
			this.AnimIcon[1].color = white;
		}
		if (this.AnimIcon2[0].enabled)
		{
			Color white2 = Color.white;
			white2.a = this.WarningIconAlpha;
			this.AnimIcon2[1].color = white2;
		}
	}

	// Token: 0x06001CF5 RID: 7413 RVA: 0x0033D698 File Offset: 0x0033B898
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < this.StaticText.Length; i++)
		{
			if (this.StaticText[i] != null && this.StaticText[i].enabled)
			{
				this.StaticText[i].enabled = false;
				this.StaticText[i].enabled = true;
			}
		}
		for (int j = 0; j < this.MoveFilter.Length; j++)
		{
			if (this.MoveFilter[j] != null && this.MoveFilter[j].enabled)
			{
				this.MoveFilter[j].enabled = false;
				this.MoveFilter[j].enabled = true;
			}
		}
		if (this.NeedItemCountText != null && this.NeedItemCountText.enabled)
		{
			this.NeedItemCountText.enabled = false;
			this.NeedItemCountText.enabled = true;
		}
		if (this.ItemCountText != null && this.ItemCountText.enabled)
		{
			this.ItemCountText.enabled = false;
			this.ItemCountText.enabled = true;
		}
		if (this.PlayBtnText != null && this.PlayBtnText.enabled)
		{
			this.PlayBtnText.enabled = false;
			this.PlayBtnText.enabled = true;
		}
		if (this.ResTitle != null && this.ResTitle.enabled)
		{
			this.ResTitle.enabled = false;
			this.ResTitle.enabled = true;
		}
		if (this.ResContent != null && this.ResContent.enabled)
		{
			this.ResContent.enabled = false;
			this.ResContent.enabled = true;
		}
		if (this.LongTitle != null && this.LongTitle.enabled)
		{
			this.LongTitle.enabled = false;
			this.LongTitle.enabled = true;
		}
	}

	// Token: 0x0400584E RID: 22606
	private const float ResStep = 64f;

	// Token: 0x0400584F RID: 22607
	private const float AlphaSecPerRound = 2f;

	// Token: 0x04005850 RID: 22608
	private Door door;

	// Token: 0x04005851 RID: 22609
	private Transform Current;

	// Token: 0x04005852 RID: 22610
	private UIText ResTitle;

	// Token: 0x04005853 RID: 22611
	private UIText ResContent;

	// Token: 0x04005854 RID: 22612
	private UIText LongTitle;

	// Token: 0x04005855 RID: 22613
	private CString ResTitleStr;

	// Token: 0x04005856 RID: 22614
	private CString LongTitleStr;

	// Token: 0x04005857 RID: 22615
	private CString NeedItemCountStr;

	// Token: 0x04005858 RID: 22616
	private CString ItemCountStr;

	// Token: 0x04005859 RID: 22617
	private UIText NeedItemCountText;

	// Token: 0x0400585A RID: 22618
	private UIText ItemCountText;

	// Token: 0x0400585B RID: 22619
	private Image[] IconX = new Image[2];

	// Token: 0x0400585C RID: 22620
	private Image[] IconV = new Image[2];

	// Token: 0x0400585D RID: 22621
	private UIText[] MoveFilter = new UIText[2];

	// Token: 0x0400585E RID: 22622
	private Image[] AnimIcon = new Image[2];

	// Token: 0x0400585F RID: 22623
	private Image[] AnimIcon2 = new Image[2];

	// Token: 0x04005860 RID: 22624
	private float WarningIconAlphaSign = 1f;

	// Token: 0x04005861 RID: 22625
	private float WarningIconAlpha;

	// Token: 0x04005862 RID: 22626
	private Image[] ResIcon = new Image[5];

	// Token: 0x04005863 RID: 22627
	private Image ResIconV;

	// Token: 0x04005864 RID: 22628
	private UIButton PlayBtn;

	// Token: 0x04005865 RID: 22629
	private Image PlayBtnImage;

	// Token: 0x04005866 RID: 22630
	private UIText PlayBtnText;

	// Token: 0x04005867 RID: 22631
	private UIText[] StaticText = new UIText[5];

	// Token: 0x04005868 RID: 22632
	private uint ResMax;

	// Token: 0x04005869 RID: 22633
	public static int kingdomID = 0;

	// Token: 0x0400586A RID: 22634
	public static int mapPointID = 0;

	// Token: 0x0400586B RID: 22635
	private static readonly Color32 ResContentNormal = new Color32(byte.MaxValue, 247, 153, byte.MaxValue);

	// Token: 0x0400586C RID: 22636
	private static readonly Color32 ResContentRed = new Color32(byte.MaxValue, 94, 112, byte.MaxValue);

	// Token: 0x0400586D RID: 22637
	private static readonly Vector2 ResContentPos = new Vector2(79f, -210f);

	// Token: 0x0400586E RID: 22638
	private static readonly Vector2 ResStart = new Vector2(-223f, 64f);

	// Token: 0x020005AF RID: 1455
	private enum EUIImmigrationUnit
	{
		// Token: 0x04005870 RID: 22640
		TitleLeft,
		// Token: 0x04005871 RID: 22641
		TitleRight,
		// Token: 0x04005872 RID: 22642
		Title,
		// Token: 0x04005873 RID: 22643
		ArenaBar,
		// Token: 0x04005874 RID: 22644
		ResBar,
		// Token: 0x04005875 RID: 22645
		MoveBar,
		// Token: 0x04005876 RID: 22646
		Warning1,
		// Token: 0x04005877 RID: 22647
		Warning1_a,
		// Token: 0x04005878 RID: 22648
		Warning2,
		// Token: 0x04005879 RID: 22649
		Warning2_a,
		// Token: 0x0400587A RID: 22650
		X1,
		// Token: 0x0400587B RID: 22651
		X2,
		// Token: 0x0400587C RID: 22652
		V1,
		// Token: 0x0400587D RID: 22653
		V2,
		// Token: 0x0400587E RID: 22654
		Line,
		// Token: 0x0400587F RID: 22655
		PlayBtn,
		// Token: 0x04005880 RID: 22656
		ArenaTitle,
		// Token: 0x04005881 RID: 22657
		ResTitle,
		// Token: 0x04005882 RID: 22658
		MoveTitle,
		// Token: 0x04005883 RID: 22659
		ArenaContent,
		// Token: 0x04005884 RID: 22660
		ResContent,
		// Token: 0x04005885 RID: 22661
		MoveContent,
		// Token: 0x04005886 RID: 22662
		MoveContent2,
		// Token: 0x04005887 RID: 22663
		LongText,
		// Token: 0x04005888 RID: 22664
		ItemName,
		// Token: 0x04005889 RID: 22665
		ItemCount,
		// Token: 0x0400588A RID: 22666
		ItemIcon,
		// Token: 0x0400588B RID: 22667
		ResFood,
		// Token: 0x0400588C RID: 22668
		ResRock,
		// Token: 0x0400588D RID: 22669
		ResWood,
		// Token: 0x0400588E RID: 22670
		ResIron,
		// Token: 0x0400588F RID: 22671
		ResGold,
		// Token: 0x04005890 RID: 22672
		V3,
		// Token: 0x04005891 RID: 22673
		Exit
	}

	// Token: 0x020005B0 RID: 1456
	private enum EUIImmigrationButtonID
	{
		// Token: 0x04005893 RID: 22675
		Play = 1,
		// Token: 0x04005894 RID: 22676
		Exit
	}
}
