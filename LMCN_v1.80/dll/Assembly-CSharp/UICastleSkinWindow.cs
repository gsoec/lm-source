using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000513 RID: 1299
public class UICastleSkinWindow : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x060019F3 RID: 6643 RVA: 0x002C1228 File Offset: 0x002BF428
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager instance = GUIManager.Instance;
		Font ttffont = instance.GetTTFFont();
		instance.UpdateUI(EGUIWindow.Door, 1, 2);
		GameObject gameObject = UnityEngine.Object.Instantiate(this.m_AssetBundle.Load("UICastleSkin")) as GameObject;
		this.ThisTransform = (gameObject.transform as RectTransform);
		this.ThisTransform.SetParent(instance.m_WindowsTransform, false);
		this.MainTitle = this.ThisTransform.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.MainTitle.font = ttffont;
		this.DiverseTrans = this.ThisTransform.GetChild(2);
		base.transform.SetParent(this.DiverseTrans, false);
		UIButton component = this.ThisTransform.GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 100;
		if (instance.IsArabic)
		{
			component.transform.localScale = new Vector3(-1f, 1f, 1f);
			this.ThisTransform.GetChild(3).GetChild(1).GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		if (instance.bOpenOnIPhoneX)
		{
			this.ThisTransform.GetChild(4).GetComponent<CustomImage>().enabled = false;
		}
		else
		{
			this.ThisTransform.GetChild(4).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		}
		this.ThisTransform.GetChild(4).GetChild(0).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		component = this.ThisTransform.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 101;
		this.StarArray = this.ThisTransform.GetChild(3).GetChild(0).GetComponent<UISpritesArray>();
		this.ScrollLayerTrans = this.ThisTransform.GetChild(3);
		this.CastleView = this.ThisTransform.GetChild(3).GetChild(0).GetChild(0).GetComponent<ScrollPanel_Horizontal>();
		this.Hint = new UICastleSkinWindow._CastleHint(this.ThisTransform.GetChild(5), ttffont);
		this.CastleLv = instance.BuildingData.GetBuildData(8, 0).Level;
		this.SelectedCastleID = (ushort)instance.CastleSkinSaved[0];
		if (this.CastleLv >= 25 && !DataManager.Instance.CheckPrizeFlag(21))
		{
			this.ScrollToPosition = 1;
			this.SelectedCastleID = 1;
		}
		else if (this.SelectedCastleID == 0)
		{
			this.SelectedCastleID = 1;
		}
		int num = (int)instance.m_UICanvas.GetComponent<RectTransform>().sizeDelta.x;
		if (num >= 1024)
		{
			this.SetLargeSize(num);
		}
	}

	// Token: 0x060019F4 RID: 6644 RVA: 0x002C14D8 File Offset: 0x002BF6D8
	public override void ReOnOpen()
	{
		this.ThisTransform.gameObject.SetActive(true);
	}

	// Token: 0x060019F5 RID: 6645 RVA: 0x002C14EC File Offset: 0x002BF6EC
	public void OnDisable()
	{
		this.bDeActive = 1;
	}

	// Token: 0x060019F6 RID: 6646 RVA: 0x002C14F8 File Offset: 0x002BF6F8
	protected virtual void SetLargeSize(int screenWidth)
	{
		this.ScrollViewWidth = 789f;
		RectTransform component = this.CastleView.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(this.ScrollViewWidth, component.sizeDelta.y);
	}

	// Token: 0x060019F7 RID: 6647 RVA: 0x002C153C File Offset: 0x002BF73C
	public virtual void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 101)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu(false);
		}
		else if (sender.m_BtnID1 == 100)
		{
			this.OnInfoClick(sender);
		}
	}

	// Token: 0x060019F8 RID: 6648 RVA: 0x002C1588 File Offset: 0x002BF788
	public virtual void Initial()
	{
		byte b;
		this.AllCastleID = GUIManager.Instance.BuildingData.castleSkin.GetAllCastleID(this.ListSortType, out b);
		this.ViewItem = new UICastleSkinWindow._CastleItem[Mathf.Min((int)b, 7)];
		for (byte b2 = 0; b2 < b; b2 += 1)
		{
			this.ItemsHeight.Add(120f);
		}
		this.ScrollLayerTrans.gameObject.SetActive(true);
		this.CastleView.IntiScrollPanel(this.ScrollViewWidth, 12f, 16f, this.ItemsHeight, 7, this);
		this.ScrollRect = this.ThisTransform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetComponent<RectTransform>();
		float width = GameConstants.ConvertBytesToFloat(GUIManager.Instance.CastleSkinSaved, 1);
		for (int i = 0; i < this.AllCastleID.Length; i++)
		{
			if (this.AllCastleID[i] == this.SelectedCastleID)
			{
				UICastleSkinWindow._CastleItem lastSelect = this.LastSelect;
				if (this.LastSelect != null)
				{
					this.LastSelect.SetSelect(false);
				}
				this.LastSelect = null;
				if (this.ScrollToPosition == 1)
				{
					this.GoToScroll(i, 0);
				}
				else
				{
					this.CastleView.GoTo((int)GUIManager.Instance.CastleSkinSaved[5], width);
				}
				break;
			}
		}
	}

	// Token: 0x060019F9 RID: 6649 RVA: 0x002C16E4 File Offset: 0x002BF8E4
	protected void GoToScroll(int index, ushort selectCastleID = 0)
	{
		if (selectCastleID == 0)
		{
			if (index < this.AllCastleID.Length)
			{
				this.SelectedCastleID = this.AllCastleID[index];
			}
			else
			{
				this.SelectedCastleID = 1;
			}
		}
		else
		{
			this.SelectedCastleID = selectCastleID;
		}
		if (index > 0)
		{
			index--;
		}
		float num = 120f * (float)index + (float)(16 * index);
		if (num + this.ScrollViewWidth > this.ScrollRect.sizeDelta.x)
		{
			num = this.ScrollRect.sizeDelta.x - this.ScrollViewWidth;
		}
		this.CastleView.GoTo(index, -num);
		for (int i = 0; i < this.ViewItem.Length; i++)
		{
			if (this.ViewItem[i].gameobject.activeSelf && (ushort)this.ViewItem[i].CastleID == this.SelectedCastleID)
			{
				if (this.LastSelect != null)
				{
					this.LastSelect.SetSelect(false);
				}
				this.LastSelect = this.ViewItem[i];
				this.ViewItem[i].SetSelect(true);
				break;
			}
		}
	}

	// Token: 0x060019FA RID: 6650 RVA: 0x002C1810 File Offset: 0x002BFA10
	public override void UpdateUI(int arg1, int arg2)
	{
		if (this.Delay > 0)
		{
			return;
		}
		CastleSkin._SortType curSortType = GUIManager.Instance.BuildingData.castleSkin.curSortType;
		if (curSortType != this.ListSortType)
		{
			this.LastSelect = null;
			byte b;
			this.AllCastleID = GUIManager.Instance.BuildingData.castleSkin.GetAllCastleID(this.ListSortType, out b);
			int num = this.ItemsHeight.Count - (int)b;
			if (num < 0)
			{
				short num2 = 0;
				while ((int)num2 > num)
				{
					this.ItemsHeight.Insert(this.ItemsHeight.Count - 1, 120f);
					num2 -= 1;
				}
			}
			else if (num > 0)
			{
				byte b2 = 0;
				while ((int)b2 < num)
				{
					this.ItemsHeight.RemoveAt(this.ItemsHeight.Count - 1);
					b2 += 1;
				}
			}
			this.CastleLv = GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level;
			Vector2 anchoredPosition = this.ScrollRect.anchoredPosition;
			int beginIdx = this.CastleView.GetBeginIdx();
			this.CastleView.AddNewDataHeight(this.ItemsHeight, true, true);
			this.CastleView.GoTo(beginIdx, anchoredPosition.x);
		}
		else
		{
			for (int i = 0; i < this.ViewItem.Length; i++)
			{
				this.ViewItem[i].UpdateSelf();
				if ((ushort)this.ViewItem[i].CastleID == this.SelectedCastleID)
				{
					this.ViewItem[i].SetSelect(true);
					this.LastSelect = this.ViewItem[i];
				}
			}
		}
		this.Hint.Update();
	}

	// Token: 0x060019FB RID: 6651 RVA: 0x002C19C8 File Offset: 0x002BFBC8
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.ViewItem[panelObjectIdx] == null)
		{
			this.ViewItem[panelObjectIdx] = new UICastleSkinWindow._CastleItem(item.transform, this.StarArray);
		}
		if (this.AllCastleID.Length > dataIdx)
		{
			this.ViewItem[panelObjectIdx].SetData((byte)this.AllCastleID[dataIdx]);
		}
		else
		{
			this.ViewItem[panelObjectIdx].SetData((byte)this.AllCastleID[0]);
		}
		if ((ushort)this.ViewItem[panelObjectIdx].CastleID == this.SelectedCastleID)
		{
			this.ViewItem[panelObjectIdx].SetSelect(true);
			if (this.LastSelect == null || this.ViewItem[panelObjectIdx].CastleID != this.LastSelect.CastleID)
			{
				this.LastSelect = this.ViewItem[panelObjectIdx];
			}
		}
	}

	// Token: 0x060019FC RID: 6652 RVA: 0x002C1A98 File Offset: 0x002BFC98
	public virtual void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		if (this.AllCastleID.Length > dataIndex)
		{
			this.SelectedCastleID = this.AllCastleID[dataIndex];
		}
		else
		{
			this.SelectedCastleID = 1;
		}
		if (this.LastSelect != null)
		{
			this.LastSelect.SetSelect(false);
		}
		for (int i = 0; i < this.ViewItem.Length; i++)
		{
			if (this.ViewItem[i].gameobject.activeSelf && (ushort)this.ViewItem[i].CastleID == this.SelectedCastleID)
			{
				this.ViewItem[i].SetSelect(true);
				this.LastSelect = this.ViewItem[i];
				break;
			}
		}
		GUIManager.Instance.BuildingData.castleSkin.SaveCastleSkinSave();
	}

	// Token: 0x060019FD RID: 6653 RVA: 0x002C1B6C File Offset: 0x002BFD6C
	public override void OnClose()
	{
		if (this.Delay == 0)
		{
			GUIManager.Instance.CastleSkinSaved[0] = (byte)this.SelectedCastleID;
			GameConstants.GetBytes(this.ScrollRect.anchoredPosition.x, GUIManager.Instance.CastleSkinSaved, 1);
			GUIManager.Instance.CastleSkinSaved[5] = (byte)this.CastleView.GetBeginIdx();
		}
		this.Hint.Destroy();
		UnityEngine.Object.Destroy(this.ThisTransform.gameObject);
		GUIManager.Instance.BuildingData.castleSkin.ClearCastleSkinUI(false);
	}

	// Token: 0x060019FE RID: 6654 RVA: 0x002C1C04 File Offset: 0x002BFE04
	public virtual void OnInfoClick(UIButton sender)
	{
	}

	// Token: 0x060019FF RID: 6655 RVA: 0x002C1C08 File Offset: 0x002BFE08
	public virtual void ClassticalCastleChanged()
	{
	}

	// Token: 0x06001A00 RID: 6656 RVA: 0x002C1C0C File Offset: 0x002BFE0C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Hint.TextRefresh();
			this.MainTitle.enabled = false;
			this.MainTitle.enabled = true;
		}
		else if (networkNews == NetworkNews.Refresh_BuildBase)
		{
			byte level = GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level;
			if (level == this.CastleLv)
			{
				return;
			}
			this.CastleLv = level;
			for (int i = 0; i < this.ViewItem.Length; i++)
			{
				if (this.ViewItem[i].CastleID == 1)
				{
					this.ViewItem[i].UpdateSelf();
					break;
				}
			}
			if (this.SelectedCastleID == 1)
			{
				this.Hint.Update();
				this.ClassticalCastleChanged();
			}
		}
	}

	// Token: 0x06001A01 RID: 6657 RVA: 0x002C1CE0 File Offset: 0x002BFEE0
	public override void UpdateTime(bool bOnSecond)
	{
		this.DeltaTime += Time.deltaTime;
		if (this.DeltaTime >= 2f)
		{
			this.DeltaTime = 0f;
		}
		if (this.Delay > 0)
		{
			this.Delay -= 1;
			if (this.Delay == 0)
			{
				this.Initial();
			}
		}
		if (this.bDeActive > 0)
		{
			this.bDeActive -= 1;
			if (this.bDeActive == 0)
			{
				this.ThisTransform.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x04004CE5 RID: 19685
	protected UIText MainTitle;

	// Token: 0x04004CE6 RID: 19686
	protected Transform ScrollLayerTrans;

	// Token: 0x04004CE7 RID: 19687
	private Transform DiverseTrans;

	// Token: 0x04004CE8 RID: 19688
	private RectTransform ThisTransform;

	// Token: 0x04004CE9 RID: 19689
	private RectTransform ScrollRect;

	// Token: 0x04004CEA RID: 19690
	protected UICastleSkinWindow._CastleHint Hint;

	// Token: 0x04004CEB RID: 19691
	protected ScrollPanel_Horizontal CastleView;

	// Token: 0x04004CEC RID: 19692
	private List<float> ItemsHeight = new List<float>();

	// Token: 0x04004CED RID: 19693
	private float ScrollViewWidth = 744f;

	// Token: 0x04004CEE RID: 19694
	protected ushort[] AllCastleID;

	// Token: 0x04004CEF RID: 19695
	private UICastleSkinWindow._CastleItem[] ViewItem;

	// Token: 0x04004CF0 RID: 19696
	protected CastleSkin._SortType ListSortType = CastleSkin._SortType.All;

	// Token: 0x04004CF1 RID: 19697
	protected UISpritesArray StarArray;

	// Token: 0x04004CF2 RID: 19698
	protected ushort SelectedCastleID;

	// Token: 0x04004CF3 RID: 19699
	protected float DeltaTime;

	// Token: 0x04004CF4 RID: 19700
	private UICastleSkinWindow._CastleItem LastSelect;

	// Token: 0x04004CF5 RID: 19701
	private byte Delay = 2;

	// Token: 0x04004CF6 RID: 19702
	private byte bDeActive;

	// Token: 0x04004CF7 RID: 19703
	protected byte CastleLv;

	// Token: 0x04004CF8 RID: 19704
	protected byte ScrollToPosition;

	// Token: 0x02000514 RID: 1300
	private enum UIControl
	{
		// Token: 0x04004CFA RID: 19706
		Title,
		// Token: 0x04004CFB RID: 19707
		Info,
		// Token: 0x04004CFC RID: 19708
		Diverse,
		// Token: 0x04004CFD RID: 19709
		CastleList,
		// Token: 0x04004CFE RID: 19710
		Close,
		// Token: 0x04004CFF RID: 19711
		Hint
	}

	// Token: 0x02000515 RID: 1301
	private enum ClickType
	{
		// Token: 0x04004D01 RID: 19713
		Info = 100,
		// Token: 0x04004D02 RID: 19714
		Close
	}

	// Token: 0x02000516 RID: 1302
	protected enum SpriteIndex
	{
		// Token: 0x04004D04 RID: 19716
		StarOff,
		// Token: 0x04004D05 RID: 19717
		StarOn,
		// Token: 0x04004D06 RID: 19718
		Add,
		// Token: 0x04004D07 RID: 19719
		Use
	}

	// Token: 0x02000517 RID: 1303
	protected struct _CastleHint
	{
		// Token: 0x06001A02 RID: 6658 RVA: 0x002C1D80 File Offset: 0x002BFF80
		public _CastleHint(Transform transform, Font font)
		{
			this.ThisTransform = (transform as RectTransform);
			this.ThisTransObj = this.ThisTransform.gameObject;
			this.CastleImg = this.ThisTransform.GetChild(0).GetComponent<Image>();
			if (GUIManager.Instance.IsArabic)
			{
				this.CastleImg.gameObject.AddComponent<ArabicItemTextureRot>();
			}
			this.NameText = this.ThisTransform.GetChild(1).GetComponent<UIText>();
			this.NameText.font = font;
			this.TitleText = this.ThisTransform.GetChild(2).GetComponent<UIText>();
			this.TitleText.font = font;
			this.AttribText = new UIText[2];
			this.EffectStr = new CString[2];
			this.EffectStr[0] = StringManager.Instance.SpawnString(30);
			this.AttribText[0] = this.ThisTransform.GetChild(3).GetComponent<UIText>();
			this.AttribText[0].font = font;
			this.EffectStr[1] = StringManager.Instance.SpawnString(30);
			this.AttribText[1] = this.ThisTransform.GetChild(6).GetComponent<UIText>();
			this.AttribText[1].font = font;
			this.EnhanceText = new UIText[2][];
			this.EnhanceImg = new Image[2][];
			this.EnhanceStr = new CString[2][];
			for (int i = 0; i < this.EnhanceText.Length; i++)
			{
				this.EnhanceText[i] = new UIText[5];
				this.EnhanceImg[i] = new Image[5];
				this.EnhanceStr[i] = new CString[5];
			}
			for (byte b = 0; b < 5; b += 1)
			{
				this.EnhanceText[0][(int)b] = this.ThisTransform.GetChild(4).GetChild((int)b).GetChild(0).GetComponent<UIText>();
				this.EnhanceText[0][(int)b].font = font;
				this.EnhanceText[1][(int)b] = this.ThisTransform.GetChild(7).GetChild((int)b).GetChild(0).GetComponent<UIText>();
				this.EnhanceText[1][(int)b].font = font;
				this.EnhanceImg[0][(int)b] = this.ThisTransform.GetChild(4).GetChild((int)b).GetComponent<Image>();
				this.EnhanceImg[1][(int)b] = this.ThisTransform.GetChild(7).GetChild((int)b).GetComponent<Image>();
				this.EnhanceStr[0][(int)b] = StringManager.Instance.SpawnString(30);
				this.EnhanceStr[1][(int)b] = StringManager.Instance.SpawnString(30);
			}
			this.NoteText = this.ThisTransform.GetChild(9).GetComponent<UIText>();
			this.NoteText.font = font;
			this.NoteText.text = DataManager.Instance.mStringTable.GetStringByID(14576u);
			this.StarArray = this.ThisTransform.GetChild(4).GetChild(0).GetComponent<UISpritesArray>();
			this.CastleID = 0;
		}

		// Token: 0x06001A03 RID: 6659 RVA: 0x002C2074 File Offset: 0x002C0274
		public void Show(ushort CastleID)
		{
			this.ThisTransObj.SetActive(true);
			if (this.CastleID == CastleID)
			{
				return;
			}
			CastleSkin castleSkin = GUIManager.Instance.BuildingData.castleSkin;
			DataManager instance = DataManager.Instance;
			this.CastleID = CastleID;
			CastleSkinTbl recordByKey = castleSkin.CastleSkinTable.GetRecordByKey(CastleID);
			byte level = GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level;
			this.CastleImg.sprite = castleSkin.GetUISprite(recordByKey.Graphic, level);
			this.CastleImg.material = castleSkin.GetUIMaterial(recordByKey.Graphic, level);
			this.CastleImg.SetNativeSize();
			float num = (float)recordByKey.PreViewPercentage * 0.002f;
			this.CastleImg.rectTransform.localScale = new Vector3(num, num, num);
			this.NameText.text = instance.mStringTable.GetStringByID((uint)recordByKey.Name);
			this.TitleText.text = instance.mStringTable.GetStringByID(14562u);
			byte castleEnhance = castleSkin.GetCastleEnhance((byte)CastleID);
			CastleEnhanceTbl castleEnhanceData = castleSkin.GetCastleEnhanceData((byte)CastleID, castleEnhance);
			bool flag = false;
			for (int i = 0; i < 2; i++)
			{
				Effect recordByKey2 = instance.EffectData.GetRecordByKey(recordByKey.Effect[i]);
				if (recordByKey2.ValueID == 4378)
				{
					flag = true;
				}
				this.EffectStr[i].ClearString();
				this.EffectStr[i].StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey2.String_infoID));
				if (flag)
				{
					this.EffectStr[i].DoubleToFormat((double)castleEnhanceData.Value[i] / 100.0, 2, false);
					this.EffectStr[i].AppendFormat("{0}{1}%");
				}
				else
				{
					this.EffectStr[i].IntToFormat((long)castleEnhanceData.Value[i], 1, false);
					this.EffectStr[i].AppendFormat("{0}{1}");
				}
				this.AttribText[i].text = this.EffectStr[i].ToString();
				this.AttribText[i].SetAllDirty();
				this.AttribText[i].cachedTextGenerator.Invalidate();
			}
			for (byte b = 0; b < 5; b += 1)
			{
				castleEnhanceData = castleSkin.GetCastleEnhanceData((byte)CastleID, b + 1);
				this.EnhanceStr[0][(int)b].ClearString();
				if (flag)
				{
					this.EnhanceStr[0][(int)b].FloatToFormat((float)castleEnhanceData.Value[0] / 100f, 2, false);
					if (GUIManager.Instance.IsArabic)
					{
						this.EnhanceStr[0][(int)b].AppendFormat("%{0}");
					}
					else
					{
						this.EnhanceStr[0][(int)b].AppendFormat("{0}%");
					}
				}
				else
				{
					this.EnhanceStr[0][(int)b].IntToFormat((long)castleEnhanceData.Value[0], 1, false);
					this.EnhanceStr[0][(int)b].AppendFormat("{0}");
				}
				this.EnhanceText[0][(int)b].text = this.EnhanceStr[0][(int)b].ToString();
				this.EnhanceText[0][(int)b].SetAllDirty();
				this.EnhanceText[0][(int)b].cachedTextGenerator.Invalidate();
				this.EnhanceStr[1][(int)b].ClearString();
				if (flag)
				{
					this.EnhanceStr[1][(int)b].FloatToFormat((float)castleEnhanceData.Value[1] / 100f, 2, false);
					if (GUIManager.Instance.IsArabic)
					{
						this.EnhanceStr[1][(int)b].AppendFormat("%{0}");
					}
					else
					{
						this.EnhanceStr[1][(int)b].AppendFormat("{0}%");
					}
				}
				else
				{
					this.EnhanceStr[1][(int)b].IntToFormat((long)castleEnhanceData.Value[1], 1, false);
					this.EnhanceStr[1][(int)b].AppendFormat("{0}");
				}
				this.EnhanceText[1][(int)b].text = this.EnhanceStr[1][(int)b].ToString();
				this.EnhanceText[1][(int)b].SetAllDirty();
				this.EnhanceText[1][(int)b].cachedTextGenerator.Invalidate();
				if (b < castleEnhance)
				{
					this.EnhanceImg[0][(int)b].sprite = this.StarArray.GetSprite(1);
					this.EnhanceImg[1][(int)b].sprite = this.StarArray.GetSprite(1);
					this.EnhanceText[0][(int)b].color = Color.white;
					this.EnhanceText[1][(int)b].color = Color.white;
				}
				else
				{
					this.EnhanceImg[0][(int)b].sprite = this.StarArray.GetSprite(0);
					this.EnhanceImg[1][(int)b].sprite = this.StarArray.GetSprite(0);
					this.EnhanceText[0][(int)b].color = new Color(0.6275f, 0.6275f, 0.6275f);
					this.EnhanceText[1][(int)b].color = new Color(0.6275f, 0.6275f, 0.6275f);
				}
			}
		}

		// Token: 0x06001A04 RID: 6660 RVA: 0x002C25B8 File Offset: 0x002C07B8
		public void Hide()
		{
			this.ThisTransObj.SetActive(false);
		}

		// Token: 0x06001A05 RID: 6661 RVA: 0x002C25C8 File Offset: 0x002C07C8
		public void TextRefresh()
		{
			this.NameText.enabled = false;
			this.NameText.enabled = true;
			this.TitleText.enabled = false;
			this.TitleText.enabled = true;
			this.NoteText.enabled = false;
			this.NoteText.enabled = true;
			for (int i = 0; i < this.AttribText.Length; i++)
			{
				this.AttribText[i].enabled = false;
				this.AttribText[i].enabled = true;
			}
			for (byte b = 0; b < 5; b += 1)
			{
				this.EnhanceText[0][(int)b].enabled = false;
				this.EnhanceText[0][(int)b].enabled = true;
				this.EnhanceText[1][(int)b].enabled = false;
				this.EnhanceText[1][(int)b].enabled = true;
			}
		}

		// Token: 0x06001A06 RID: 6662 RVA: 0x002C26A8 File Offset: 0x002C08A8
		public void Destroy()
		{
			for (byte b = 0; b < 5; b += 1)
			{
				StringManager.Instance.DeSpawnString(this.EnhanceStr[0][(int)b]);
				StringManager.Instance.DeSpawnString(this.EnhanceStr[1][(int)b]);
			}
		}

		// Token: 0x06001A07 RID: 6663 RVA: 0x002C26F4 File Offset: 0x002C08F4
		public void Update()
		{
			this.CastleID = 0;
		}

		// Token: 0x04004D08 RID: 19720
		public RectTransform ThisTransform;

		// Token: 0x04004D09 RID: 19721
		private GameObject ThisTransObj;

		// Token: 0x04004D0A RID: 19722
		private Image CastleImg;

		// Token: 0x04004D0B RID: 19723
		private UIText NameText;

		// Token: 0x04004D0C RID: 19724
		private UIText TitleText;

		// Token: 0x04004D0D RID: 19725
		private UIText NoteText;

		// Token: 0x04004D0E RID: 19726
		private UIText[] AttribText;

		// Token: 0x04004D0F RID: 19727
		private CString[][] EnhanceStr;

		// Token: 0x04004D10 RID: 19728
		private UIText[][] EnhanceText;

		// Token: 0x04004D11 RID: 19729
		private Image[][] EnhanceImg;

		// Token: 0x04004D12 RID: 19730
		private UISpritesArray StarArray;

		// Token: 0x04004D13 RID: 19731
		private ushort CastleID;

		// Token: 0x04004D14 RID: 19732
		private CString[] EffectStr;

		// Token: 0x02000518 RID: 1304
		private enum UIControl
		{
			// Token: 0x04004D16 RID: 19734
			CastleImg,
			// Token: 0x04004D17 RID: 19735
			Name,
			// Token: 0x04004D18 RID: 19736
			Title,
			// Token: 0x04004D19 RID: 19737
			Effect1,
			// Token: 0x04004D1A RID: 19738
			Enhance1,
			// Token: 0x04004D1B RID: 19739
			Line,
			// Token: 0x04004D1C RID: 19740
			Effect2,
			// Token: 0x04004D1D RID: 19741
			Enhance2,
			// Token: 0x04004D1E RID: 19742
			Line2,
			// Token: 0x04004D1F RID: 19743
			Note
		}
	}

	// Token: 0x02000519 RID: 1305
	private class _CastleItem
	{
		// Token: 0x06001A08 RID: 6664 RVA: 0x002C2700 File Offset: 0x002C0900
		public _CastleItem(Transform transform, UISpritesArray starArray)
		{
			this.gameobject = transform.gameObject;
			this.StarArray = starArray;
			this.StarRect = new RectTransform[5];
			this.StarImg = new Image[5];
			this.SelectImg = transform.GetChild(0).GetComponent<Image>();
			this.StarLayerObj = transform.GetChild(2).gameObject;
			for (byte b = 0; b < 5; b += 1)
			{
				this.StarRect[(int)b] = transform.GetChild(2).GetChild((int)b).GetComponent<RectTransform>();
				this.StarImg[(int)b] = this.StarRect[(int)b].GetComponent<Image>();
			}
			this.MainImg = transform.GetChild(1).GetComponent<Image>();
			this.AddImg = transform.GetChild(3).GetComponent<Image>();
			this.NoticeObj = transform.GetChild(4).gameObject;
		}

		// Token: 0x06001A09 RID: 6665 RVA: 0x002C27DC File Offset: 0x002C09DC
		public void SetData(byte CastleID)
		{
			this.CastleID = CastleID;
			CastleSkin castleSkin = GUIManager.Instance.BuildingData.castleSkin;
			CastleSkinTbl recordByKey = castleSkin.CastleSkinTable.GetRecordByKey((ushort)CastleID);
			byte level = GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level;
			this.MainImg.sprite = castleSkin.GetUISprite(recordByKey.Graphic, level);
			this.MainImg.material = castleSkin.GetUIMaterial(recordByKey.Graphic, level);
			this.MainImg.SetNativeSize();
			float num = (float)recordByKey.UnlockPercentage * 0.01f * 0.3f;
			this.MainImg.rectTransform.localScale = new Vector3(num, num, num);
			this.SetStar(castleSkin.GetCastleEnhance(CastleID));
			if (GUIManager.Instance.BuildingData.CastleID == CastleID)
			{
				this.AddImg.sprite = this.StarArray.GetSprite(3);
				this.AddImg.enabled = true;
			}
			else if (!castleSkin.CheckUnlock(CastleID))
			{
				this.AddImg.sprite = this.StarArray.GetSprite(2);
				this.AddImg.enabled = true;
			}
			else
			{
				this.AddImg.enabled = false;
			}
			this.NoticeObj.SetActive(!castleSkin.CheckSelect(CastleID));
			this.SelectImg.color = new Color(1f, 1f, 1f, 0f);
		}

		// Token: 0x06001A0A RID: 6666 RVA: 0x002C2958 File Offset: 0x002C0B58
		public void SetSelect(bool select)
		{
			if (select)
			{
				this.SelectImg.color = Color.white;
				GUIManager.Instance.BuildingData.castleSkin.SetSelect(this.CastleID);
				this.NoticeObj.SetActive(false);
			}
			else
			{
				this.SelectImg.color = new Color(1f, 1f, 1f, 0f);
			}
		}

		// Token: 0x06001A0B RID: 6667 RVA: 0x002C29CC File Offset: 0x002C0BCC
		public void UpdateSelf()
		{
			this.SetData(this.CastleID);
		}

		// Token: 0x06001A0C RID: 6668 RVA: 0x002C29DC File Offset: 0x002C0BDC
		private void SetStar(byte rank)
		{
			if (rank == 0)
			{
				this.StarLayerObj.SetActive(false);
				return;
			}
			for (int i = (int)rank; i < 5; i++)
			{
				this.StarImg[i].enabled = false;
			}
			switch (rank)
			{
			case 1:
				this.StarImg[0].enabled = true;
				this.StarRect[0].anchoredPosition = new Vector2(0f, this.StarRect[0].anchoredPosition.y);
				break;
			case 2:
				this.StarImg[0].enabled = true;
				this.StarRect[0].anchoredPosition = new Vector2(-12f, this.StarRect[0].anchoredPosition.y);
				this.StarImg[1].enabled = true;
				this.StarRect[1].anchoredPosition = new Vector2(12f, this.StarRect[0].anchoredPosition.y);
				break;
			case 3:
				this.StarImg[0].enabled = true;
				this.StarRect[0].anchoredPosition = new Vector2(-24f, this.StarRect[0].anchoredPosition.y);
				this.StarImg[1].enabled = true;
				this.StarRect[1].anchoredPosition = new Vector2(0f, this.StarRect[0].anchoredPosition.y);
				this.StarImg[2].enabled = true;
				this.StarRect[2].anchoredPosition = new Vector2(24f, this.StarRect[0].anchoredPosition.y);
				break;
			case 4:
				this.StarImg[0].enabled = true;
				this.StarRect[0].anchoredPosition = new Vector2(-36f, this.StarRect[0].anchoredPosition.y);
				this.StarImg[1].enabled = true;
				this.StarRect[1].anchoredPosition = new Vector2(-12f, this.StarRect[0].anchoredPosition.y);
				this.StarImg[2].enabled = true;
				this.StarRect[2].anchoredPosition = new Vector2(12f, this.StarRect[0].anchoredPosition.y);
				this.StarImg[3].enabled = true;
				this.StarRect[3].anchoredPosition = new Vector2(36f, this.StarRect[0].anchoredPosition.y);
				break;
			case 5:
				this.StarImg[0].enabled = true;
				this.StarRect[0].anchoredPosition = new Vector2(-48f, this.StarRect[0].anchoredPosition.y);
				this.StarImg[1].enabled = true;
				this.StarRect[1].anchoredPosition = new Vector2(-24f, this.StarRect[0].anchoredPosition.y);
				this.StarImg[2].enabled = true;
				this.StarRect[2].anchoredPosition = new Vector2(0f, this.StarRect[0].anchoredPosition.y);
				this.StarImg[3].enabled = true;
				this.StarRect[3].anchoredPosition = new Vector2(24f, this.StarRect[0].anchoredPosition.y);
				this.StarImg[4].enabled = true;
				this.StarRect[4].anchoredPosition = new Vector2(48f, this.StarRect[0].anchoredPosition.y);
				break;
			}
			this.StarLayerObj.SetActive(true);
		}

		// Token: 0x04004D20 RID: 19744
		private RectTransform[] StarRect;

		// Token: 0x04004D21 RID: 19745
		private Image[] StarImg;

		// Token: 0x04004D22 RID: 19746
		private Image MainImg;

		// Token: 0x04004D23 RID: 19747
		private Image AddImg;

		// Token: 0x04004D24 RID: 19748
		private Image SelectImg;

		// Token: 0x04004D25 RID: 19749
		private GameObject NoticeObj;

		// Token: 0x04004D26 RID: 19750
		private GameObject StarLayerObj;

		// Token: 0x04004D27 RID: 19751
		public GameObject gameobject;

		// Token: 0x04004D28 RID: 19752
		private UISpritesArray StarArray;

		// Token: 0x04004D29 RID: 19753
		public byte CastleID;
	}
}
