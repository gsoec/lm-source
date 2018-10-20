using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000576 RID: 1398
public class UILordItemInfo : IUIButtonDownUpHandler
{
	// Token: 0x170000B3 RID: 179
	// (get) Token: 0x06001BCF RID: 7119 RVA: 0x003163D8 File Offset: 0x003145D8
	// (set) Token: 0x06001BD0 RID: 7120 RVA: 0x003163E0 File Offset: 0x003145E0
	public bool HideEquipVal
	{
		get
		{
			return this._HideEquipVal;
		}
		set
		{
			this._HideEquipVal = value;
		}
	}

	// Token: 0x06001BD1 RID: 7121 RVA: 0x003163EC File Offset: 0x003145EC
	public void Load()
	{
		UnityEngine.Object @object = GUIManager.Instance.m_ManagerAssetBundle.Load("UILordItemInfo");
		if (@object == null)
		{
			return;
		}
		this.EffTitleText = new UIText[6];
		this.EffNumText = new UIText[6];
		this.EffNumStr = new CString[6];
		this.EffectRect = new RectTransform[6];
		GUIManager instance = GUIManager.Instance;
		Font ttffont = instance.GetTTFFont();
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
		gameObject.transform.SetParent(instance.m_WindowTopLayer, false);
		gameObject.SetActive(false);
		this.m_RectTransform = (RectTransform)gameObject.transform;
		this.OriRectSize = this.m_RectTransform.sizeDelta;
		this.Canvasgroup = this.m_RectTransform.GetComponent<CanvasGroup>();
		this.ItemTrans = this.m_RectTransform.GetChild(1);
		for (int i = 0; i < this.LinTrans.Length; i++)
		{
			this.LinTrans[i] = this.m_RectTransform.GetChild(8).GetChild(i);
			this.LinTrans[i].GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		}
		this.m_RectTransform.GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		this.m_RectTransform.GetChild(0).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		this.m_RectTransform.GetChild(6).GetComponent<CustomImage>().hander = instance.m_ItemInfo;
		this.ShadowObj = this.m_RectTransform.GetChild(0).gameObject;
		this.NameText = this.m_RectTransform.GetChild(2).GetComponent<UIText>();
		this.NameText.font = ttffont;
		this.LevelText = this.m_RectTransform.GetChild(3).GetComponent<UIText>();
		this.LevelText.font = ttffont;
		this.KindText = this.m_RectTransform.GetChild(4).GetComponent<UIText>();
		this.KindText.font = ttffont;
		this.OwnText = this.m_RectTransform.GetChild(5).GetComponent<UIText>();
		this.OwnText.font = ttffont;
		this.TimeTrans = this.m_RectTransform.GetChild(6);
		this.TimeText = this.TimeTrans.GetChild(0).GetComponent<UIText>();
		this.TimeText.font = ttffont;
		this.ContTextRect = this.m_RectTransform.GetChild(7).GetComponent<RectTransform>();
		this.ContText = this.ContTextRect.GetComponent<UIText>();
		this.ContText.font = ttffont;
		this.OriContFontSize = this.ContText.fontSize;
		this.TipRect = this.m_RectTransform.GetChild(9).GetComponent<RectTransform>();
		this.TipText = this.TipRect.GetComponent<UIText>();
		this.TipText.font = ttffont;
		this.TipObj = this.TipText.gameObject;
		this.OriTextSize = this.ContText.rectTransform.sizeDelta;
		this.EffectTrans = this.m_RectTransform.GetChild(8).GetComponent<RectTransform>();
		this.OriEffPos = this.EffectTrans.anchoredPosition;
		int childCount = this.EffectTrans.childCount;
		for (int j = 0; j < this.EffTitleText.Length; j++)
		{
			int num = (j + 1) * 2 + 1;
			this.EffTitleText[j] = this.m_RectTransform.GetChild(8).GetChild(num).GetComponent<UIText>();
			this.EffTitleText[j].font = ttffont;
			this.EffNumText[j] = this.m_RectTransform.GetChild(8).GetChild(num + 1).GetComponent<UIText>();
			this.EffNumText[j].font = ttffont;
			this.EffectRect[j] = this.EffTitleText[j].rectTransform;
		}
		for (int k = 0; k < this.EffNumStr.Length; k++)
		{
			this.EffNumStr[k] = StringManager.Instance.SpawnString(30);
		}
		instance.InitLordEquipImg(this.ItemTrans, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		this.LevelStr = StringManager.Instance.SpawnString(30);
		this.NameStr = StringManager.Instance.SpawnString(100);
		this.TimeStr = StringManager.Instance.SpawnString(30);
		this.OwnStr = StringManager.Instance.SpawnString(30);
		this.OriKindPos = this.KindText.transform.localPosition;
		this.ContStr = StringManager.Instance.SpawnString(512);
		this.effList = new List<LordEquipEffectSet>(6);
	}

	// Token: 0x06001BD2 RID: 7122 RVA: 0x00316880 File Offset: 0x00314A80
	public void UnLoad()
	{
		StringManager.Instance.DeSpawnString(this.LevelStr);
		StringManager.Instance.DeSpawnString(this.NameStr);
		StringManager.Instance.DeSpawnString(this.TimeStr);
		StringManager.Instance.DeSpawnString(this.OwnStr);
		StringManager.Instance.DeSpawnString(this.ContStr);
		for (int i = 0; i < this.EffNumStr.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.EffNumStr[i]);
		}
	}

	// Token: 0x06001BD3 RID: 7123 RVA: 0x00316910 File Offset: 0x00314B10
	public void Show(UIButtonHint hint, ushort ItemID, byte Rank, int Num = -1)
	{
		if (GUIManager.Instance.m_SimpleItemInfo.m_ButtonHint != null)
		{
			GUIManager.Instance.m_SimpleItemInfo.Hide(GUIManager.Instance.m_SimpleItemInfo.m_ButtonHint);
		}
		if (Rank == 0)
		{
			return;
		}
		if (this.m_RectTransform.gameObject.activeSelf)
		{
			this.Hide(this.m_ButtonHint);
		}
		DataManager instance = DataManager.Instance;
		bool flag = false;
		bool flag2 = false;
		float num = 0f;
		Equip recordByKey = instance.EquipTable.GetRecordByKey(ItemID);
		if (!GUIManager.Instance.IsLeadItem(recordByKey.EquipKind))
		{
			return;
		}
		GUIManager.Instance.ChangeLordEquipImg(this.ItemTrans, ItemID, Rank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
		if (recordByKey.EquipKind >= 21 && recordByKey.EquipKind <= 26)
		{
			flag2 = true;
			this.LevelStr.ClearString();
			if (recordByKey.NeedLv <= instance.RoleAttr.Level)
			{
				this.LevelStr.IntToFormat((long)recordByKey.NeedLv, 1, false);
			}
			else
			{
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.IntToFormat((long)recordByKey.NeedLv, 1, false);
				cstring.AppendFormat("<color=#FF5581FF>{0}</color>");
				this.LevelStr.StringToFormat(cstring);
			}
			this.LevelStr.AppendFormat(instance.mStringTable.GetStringByID(885u));
			this.LevelText.text = this.LevelStr.ToString();
			this.LevelText.SetAllDirty();
			this.LevelText.cachedTextGenerator.Invalidate();
			flag = true;
			this.KindText.text = instance.mStringTable.GetStringByID(7431u + (uint)recordByKey.EquipKind - 21u);
			if (!this._HideEquipVal && recordByKey.TimedType > 0)
			{
				this.TimeTrans.gameObject.SetActive(true);
				this.TimeStr.ClearString();
				if (recordByKey.TimedTime >= 86400u)
				{
					GameConstants.GetTimeString(this.TimeStr, recordByKey.TimedTime, false, false, true, false, true);
				}
				else
				{
					this.TimeStr.Append(DataManager.MissionDataManager.FormatMissionTime(recordByKey.TimedTime));
				}
				this.TimeText.text = this.TimeStr.ToString();
				this.TimeText.SetAllDirty();
				this.TimeText.cachedTextGenerator.Invalidate();
				this.TimeExtendHeight = 25f;
			}
		}
		else if (recordByKey.EquipKind == 27)
		{
			bool flag3 = recordByKey.NewGem > 0;
			this.KindText.transform.localPosition = this.LevelText.transform.localPosition;
			flag = true;
			if (flag3)
			{
				this.ShadowObj.SetActive(false);
				this.KindText.text = instance.mStringTable.GetStringByID(16126u);
				this.ContText.gameObject.SetActive(true);
				this.ContStr.ClearString();
				for (int i = 0; i < 3; i++)
				{
					if (recordByKey.NewGemEffect[i] == 0)
					{
						break;
					}
					if (i > 0)
					{
						this.ContStr.Append('\n');
					}
					CString cstring2 = StringManager.Instance.StaticString1024();
					SpecialEffect recordByKey2 = instance.SpecialEffectTable.GetRecordByKey(recordByKey.NewGemEffect[i]);
					if ((int)Rank <= recordByKey2.ColorEffect.Length)
					{
						LordEquipData.GetNewGemEffectString(cstring2, recordByKey2.NewGemEffectID, (int)recordByKey2.ColorEffect[(int)(Rank - 1)], true, 0);
					}
					else
					{
						LordEquipData.GetNewGemEffectString(cstring2, recordByKey2.NewGemEffectID, (int)recordByKey2.ColorEffect[0], true, 0);
					}
					this.ContStr.Append(cstring2);
				}
				this.ContText.text = this.ContStr.ToString();
				if (recordByKey.EquipInfo > 0)
				{
					this.ContText.fontSize = 16;
				}
				this.ContText.SetAllDirty();
				this.ContText.cachedTextGenerator.Invalidate();
				this.ContText.cachedTextGeneratorForLayout.Invalidate();
				if (this.ContStr.Length > 0)
				{
					num = this.ContText.preferredHeight;
				}
				this.EffectTrans.anchoredPosition = new Vector2(this.OriEffPos.x, this.OriEffPos.y - num);
				if (recordByKey.EquipInfo > 0)
				{
					this.TipObj.SetActive(true);
					this.TipText.text = instance.mStringTable.GetStringByID((uint)recordByKey.EquipInfo);
					this.TipRect.sizeDelta = new Vector2(this.TipRect.sizeDelta.x, this.TipText.preferredHeight);
				}
			}
			else
			{
				this.KindText.text = instance.mStringTable.GetStringByID(878u);
			}
			this.OwnStr.ClearString();
			this.OwnStr.Append("(");
			if (Num == -1)
			{
				this.OwnStr.IntToFormat((long)instance.GetCurItemQuantity(ItemID, Rank), 1, true);
			}
			else
			{
				this.OwnStr.IntToFormat((long)Num, 1, true);
			}
			this.OwnStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(79u));
			this.OwnStr.Append(")");
			this.OwnText.text = this.OwnStr.ToString();
			this.OwnText.SetAllDirty();
			this.OwnText.cachedTextGenerator.Invalidate();
		}
		else if (recordByKey.EquipKind == 20)
		{
			this.KindText.transform.localPosition = this.LevelText.transform.localPosition;
			this.ContText.gameObject.SetActive(true);
			this.ContText.text = instance.mStringTable.GetStringByID((uint)recordByKey.EquipInfo);
			this.KindText.text = instance.mStringTable.GetStringByID(879u);
			this.OwnStr.ClearString();
			this.OwnStr.Append("(");
			if (Num == -1)
			{
				this.OwnStr.IntToFormat((long)instance.GetCurItemQuantity(ItemID, Rank), 1, true);
			}
			else
			{
				this.OwnStr.IntToFormat((long)Num, 1, true);
			}
			this.OwnStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(79u));
			this.OwnStr.Append(")");
			this.OwnText.text = this.OwnStr.ToString();
			this.OwnText.SetAllDirty();
			this.OwnText.cachedTextGenerator.Invalidate();
		}
		this.NameStr.ClearString();
		GameConstants.GetColoredLordEquipString(this.NameStr, ref recordByKey, Rank);
		this.NameText.text = this.NameStr.ToString();
		this.NameText.SetAllDirty();
		this.NameText.cachedTextGenerator.Invalidate();
		this.EffSize = 0;
		if (flag)
		{
			if (flag2 && this._HideEquipVal)
			{
				this.ContText.gameObject.SetActive(true);
				this.ContText.text = instance.mStringTable.GetStringByID((uint)recordByKey.EquipInfo);
			}
			else
			{
				this.EffectTrans.gameObject.SetActive(true);
				this.effList.Clear();
				LordEquipData.GetEffectList(recordByKey.EquipKey, Rank, this.effList);
				this.EffSize = this.effList.Count;
				int num2 = 0;
				for (int j = 0; j < this.EffSize; j++)
				{
					if (this.effList[j].isNewGemEffect <= 0)
					{
						this.EffNumStr[num2].ClearString();
						Effect recordByKey3 = instance.EffectData.GetRecordByKey(this.effList[j].EffectID);
						this.EffTitleText[num2].text = instance.mStringTable.GetStringByID((uint)recordByKey3.InfoID);
						if (recordByKey3.ValueID == 0)
						{
							this.EffNumStr[num2].IntToFormat((long)this.effList[j].EffectValue, 1, false);
							this.EffNumStr[num2].AppendFormat("{0}");
						}
						else
						{
							this.EffNumStr[num2].FloatToFormat((float)this.effList[j].EffectValue / 100f, 2, false);
							if (GUIManager.Instance.IsArabic)
							{
								this.EffNumStr[num2].AppendFormat("%{0}");
							}
							else
							{
								this.EffNumStr[num2].AppendFormat("{0}%");
							}
						}
						this.EffNumText[num2].text = this.EffNumStr[num2].ToString();
						this.EffNumText[num2].SetAllDirty();
						this.EffNumText[num2].cachedTextGenerator.Invalidate();
						if (num2 >= 3)
						{
							this.EffTitleText[num2].gameObject.SetActive(true);
							this.EffNumText[num2].gameObject.SetActive(true);
						}
						num2++;
					}
				}
				this.EffSize = num2;
				if (this.EffSize >= 4)
				{
					this.LinTrans[1].gameObject.SetActive(true);
				}
				else if (this.EffSize == 6)
				{
					this.LinTrans[2].gameObject.SetActive(true);
				}
			}
		}
		if (this.EffSize <= 1)
		{
			this.LinTrans[0].gameObject.SetActive(false);
		}
		float num3 = -this.EffectTrans.anchoredPosition.y;
		if (this.TimeExtendHeight > 0f)
		{
			this.ContTextRect.anchoredPosition = new Vector2(this.ContTextRect.anchoredPosition.x, this.ContTextRect.anchoredPosition.y - this.TimeExtendHeight);
			this.EffectTrans.anchoredPosition = new Vector2(this.EffectTrans.anchoredPosition.x, this.EffectTrans.anchoredPosition.y - this.TimeExtendHeight);
		}
		num = this.ContText.preferredHeight;
		if (num > this.ContText.rectTransform.sizeDelta.y)
		{
			this.ContText.rectTransform.sizeDelta = new Vector2(this.ContText.rectTransform.sizeDelta.x, num);
		}
		if (this.EffSize > 0)
		{
			num3 += -this.EffectRect[this.EffSize - 1].anchoredPosition.y + this.EffectRect[this.EffSize - 1].sizeDelta.y + this.TimeExtendHeight;
		}
		else
		{
			num3 = -this.ContTextRect.anchoredPosition.y;
			num3 += num;
		}
		if (this.TipObj.activeSelf)
		{
			this.TipRect.anchoredPosition = new Vector2(this.TipRect.anchoredPosition.x, -num3);
			num3 += this.TipRect.sizeDelta.y;
		}
		num3 += 16f;
		if (num3 < 193f)
		{
			num3 = 193f;
		}
		this.m_RectTransform.sizeDelta = new Vector2(this.m_RectTransform.sizeDelta.x, num3);
		this.m_ButtonHint = hint;
		this.m_ButtonHint.GetTipPosition(this.m_RectTransform, UIButtonHint.ePosition.Original, null);
		this.m_RectTransform.gameObject.SetActive(true);
		this.Canvasgroup.alpha = 1f;
		UILEBtn component = hint.transform.GetComponent<UILEBtn>();
		if (component != null && component.m_Handler == null)
		{
			int soundIndex = (int)component.SoundIndex;
			if ((soundIndex & 64) == 0)
			{
				AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex)soundIndex);
			}
			else if ((soundIndex & 64) > 0)
			{
				int enumSoundIndex = soundIndex & -65;
				AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex)enumSoundIndex);
			}
		}
	}

	// Token: 0x06001BD4 RID: 7124 RVA: 0x00317574 File Offset: 0x00315774
	public void Hide(UIButtonHint hint)
	{
		if (this.m_ButtonHint != hint)
		{
			return;
		}
		this.m_ButtonHint = null;
		this.m_RectTransform.gameObject.SetActive(false);
		this.ContText.transform.gameObject.SetActive(false);
		this.EffectTrans.transform.gameObject.SetActive(false);
		this.TimeTrans.transform.gameObject.SetActive(false);
		this.ShadowObj.SetActive(true);
		UIText nameText = this.NameText;
		string text = string.Empty;
		this.KindText.text = text;
		text = text;
		this.LevelText.text = text;
		nameText.text = text;
		for (int i = 0; i < this.EffTitleText.Length; i++)
		{
			UIText uitext = this.EffTitleText[i];
			text = string.Empty;
			this.EffNumText[i].text = text;
			uitext.text = text;
		}
		this.KindText.transform.localPosition = this.OriKindPos;
		this.OwnText.text = string.Empty;
		if (this.EffSize >= 3)
		{
			for (int j = 3; j < this.EffSize; j++)
			{
				this.EffTitleText[j].gameObject.SetActive(false);
				this.EffNumText[j].gameObject.SetActive(false);
			}
			this.LinTrans[1].gameObject.SetActive(false);
			this.LinTrans[2].gameObject.SetActive(false);
		}
		else if (this.ContText.gameObject.activeSelf)
		{
			this.ContText.gameObject.SetActive(false);
		}
		if (this.TimeExtendHeight > 0f)
		{
			this.ContTextRect.anchoredPosition = new Vector2(this.ContTextRect.anchoredPosition.x, this.ContTextRect.anchoredPosition.y - this.TimeExtendHeight);
			this.EffectTrans.anchoredPosition = this.OriEffPos;
		}
		this.TimeExtendHeight = 0f;
		this.EffSize = 0;
		this.LinTrans[0].gameObject.SetActive(true);
		this.TipObj.SetActive(false);
		this.ContText.gameObject.SetActive(false);
		this.ContTextRect.sizeDelta = this.OriTextSize;
		this.ContText.fontSize = this.OriContFontSize;
		this.m_RectTransform.sizeDelta = this.OriRectSize;
	}

	// Token: 0x06001BD5 RID: 7125 RVA: 0x003177FC File Offset: 0x003159FC
	public void OnButtonDown(UIButtonHint sender)
	{
		this.Show(sender, sender.Parm1, sender.Parm2, -1);
	}

	// Token: 0x06001BD6 RID: 7126 RVA: 0x00317814 File Offset: 0x00315A14
	public void OnButtonUp(UIButtonHint sender)
	{
		this.Hide(sender);
	}

	// Token: 0x06001BD7 RID: 7127 RVA: 0x00317820 File Offset: 0x00315A20
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			if (img.sprite)
			{
				img.material = door.LoadMaterial();
			}
			else
			{
				img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
				img.material = GUIManager.Instance.GetFrameMaterial();
			}
		}
	}

	// Token: 0x06001BD8 RID: 7128 RVA: 0x00317898 File Offset: 0x00315A98
	public void TextRefresh()
	{
		if (this.m_RectTransform == null || !this.m_RectTransform.gameObject.activeSelf)
		{
			return;
		}
		this.NameText.enabled = false;
		this.NameText.enabled = true;
		this.LevelText.enabled = false;
		this.LevelText.enabled = true;
		this.KindText.enabled = false;
		this.KindText.enabled = true;
		this.ContText.enabled = false;
		this.ContText.enabled = true;
		this.TimeText.enabled = false;
		this.TimeText.enabled = true;
		this.OwnText.enabled = false;
		this.OwnText.enabled = true;
		this.TipText.enabled = false;
		this.TipText.enabled = true;
		for (int i = 0; i < this.EffTitleText.Length; i++)
		{
			this.EffTitleText[i].enabled = false;
			this.EffTitleText[i].enabled = true;
			this.EffNumText[i].enabled = false;
			this.EffNumText[i].enabled = true;
		}
	}

	// Token: 0x0400546D RID: 21613
	public CanvasGroup Canvasgroup;

	// Token: 0x0400546E RID: 21614
	public RectTransform m_RectTransform;

	// Token: 0x0400546F RID: 21615
	private GameObject ShadowObj;

	// Token: 0x04005470 RID: 21616
	private GameObject TipObj;

	// Token: 0x04005471 RID: 21617
	private Transform ItemTrans;

	// Token: 0x04005472 RID: 21618
	private Transform TimeTrans;

	// Token: 0x04005473 RID: 21619
	private RectTransform EffectTrans;

	// Token: 0x04005474 RID: 21620
	private RectTransform ContTextRect;

	// Token: 0x04005475 RID: 21621
	private RectTransform TipRect;

	// Token: 0x04005476 RID: 21622
	private Transform[] LinTrans = new Transform[3];

	// Token: 0x04005477 RID: 21623
	private UIText NameText;

	// Token: 0x04005478 RID: 21624
	private UIText LevelText;

	// Token: 0x04005479 RID: 21625
	private UIText KindText;

	// Token: 0x0400547A RID: 21626
	private UIText ContText;

	// Token: 0x0400547B RID: 21627
	private UIText TimeText;

	// Token: 0x0400547C RID: 21628
	private UIText OwnText;

	// Token: 0x0400547D RID: 21629
	private UIText TipText;

	// Token: 0x0400547E RID: 21630
	private UIText[] EffTitleText;

	// Token: 0x0400547F RID: 21631
	private UIText[] EffNumText;

	// Token: 0x04005480 RID: 21632
	private CString LevelStr;

	// Token: 0x04005481 RID: 21633
	private CString NameStr;

	// Token: 0x04005482 RID: 21634
	private CString TimeStr;

	// Token: 0x04005483 RID: 21635
	private CString OwnStr;

	// Token: 0x04005484 RID: 21636
	private CString ContStr;

	// Token: 0x04005485 RID: 21637
	private CString[] EffNumStr;

	// Token: 0x04005486 RID: 21638
	private Vector3 OriKindPos;

	// Token: 0x04005487 RID: 21639
	private Vector3 OriEffPos;

	// Token: 0x04005488 RID: 21640
	private int OriContFontSize;

	// Token: 0x04005489 RID: 21641
	private int EffSize;

	// Token: 0x0400548A RID: 21642
	private Vector2 OriTextSize;

	// Token: 0x0400548B RID: 21643
	private Vector2 OriRectSize;

	// Token: 0x0400548C RID: 21644
	private RectTransform[] EffectRect;

	// Token: 0x0400548D RID: 21645
	private float TimeExtendHeight;

	// Token: 0x0400548E RID: 21646
	public UIButtonHint m_ButtonHint;

	// Token: 0x0400548F RID: 21647
	private bool _HideEquipVal;

	// Token: 0x04005490 RID: 21648
	private List<LordEquipEffectSet> effList;

	// Token: 0x02000577 RID: 1399
	private enum UIControl
	{
		// Token: 0x04005492 RID: 21650
		Shadow,
		// Token: 0x04005493 RID: 21651
		ItemRect,
		// Token: 0x04005494 RID: 21652
		Name,
		// Token: 0x04005495 RID: 21653
		Level,
		// Token: 0x04005496 RID: 21654
		Kind,
		// Token: 0x04005497 RID: 21655
		Own,
		// Token: 0x04005498 RID: 21656
		Time,
		// Token: 0x04005499 RID: 21657
		Cont,
		// Token: 0x0400549A RID: 21658
		Effect,
		// Token: 0x0400549B RID: 21659
		Tip
	}
}
