using System;
using System.Collections.Generic;
using FootballInfo;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000361 RID: 865
public class UIFootBallInfo : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x060011D1 RID: 4561 RVA: 0x001F17F4 File Offset: 0x001EF9F4
	void IUIButtonClickHandler.OnButtonClick(UIButton sender)
	{
		this.Info.OnButtonClick(sender);
	}

	// Token: 0x060011D2 RID: 4562 RVA: 0x001F1804 File Offset: 0x001EFA04
	void IUpDateScrollPanel.UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this._ScrollItems[dataIdx] == null)
		{
			Font ttffont = GUIManager.Instance.GetTTFFont();
			this.Info.CreateItem(dataIdx, item.transform, ttffont);
		}
		else
		{
			this.Info.UpdateRowData(dataIdx);
		}
	}

	// Token: 0x060011D3 RID: 4563 RVA: 0x001F1850 File Offset: 0x001EFA50
	void IUpDateScrollPanel.ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x060011D4 RID: 4564 RVA: 0x001F1854 File Offset: 0x001EFA54
	void IUIButtonDownUpHandler.OnButtonDown(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 320f, 20, (int)sender.Parm1, 0, new Vector2((float)sender.Parm2, 0f), UIButtonHint.ePosition.Original);
	}

	// Token: 0x060011D5 RID: 4565 RVA: 0x001F1894 File Offset: 0x001EFA94
	void IUIButtonDownUpHandler.OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x17000086 RID: 134
	// (get) Token: 0x060011D6 RID: 4566 RVA: 0x001F18A8 File Offset: 0x001EFAA8
	public UIText TitleText
	{
		get
		{
			return this._TitleText;
		}
	}

	// Token: 0x17000087 RID: 135
	// (get) Token: 0x060011D7 RID: 4567 RVA: 0x001F18B0 File Offset: 0x001EFAB0
	public UIFootBallInfo.ScrollItemBase[] ScrollItems
	{
		get
		{
			return this._ScrollItems;
		}
	}

	// Token: 0x17000088 RID: 136
	// (get) Token: 0x060011D8 RID: 4568 RVA: 0x001F18B8 File Offset: 0x001EFAB8
	public Transform ItemTypeTrans
	{
		get
		{
			return this._ItemTypeTrans;
		}
	}

	// Token: 0x17000089 RID: 137
	// (get) Token: 0x060011D9 RID: 4569 RVA: 0x001F18C0 File Offset: 0x001EFAC0
	public UISpritesArray SkillIconArray
	{
		get
		{
			return this._SkillIconArray;
		}
	}

	// Token: 0x060011DA RID: 4570 RVA: 0x001F18C8 File Offset: 0x001EFAC8
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this._TitleText = base.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
		this._TitleText.font = ttffont;
		this.ScrollPanel = base.transform.GetChild(2).GetComponent<ScrollPanel>();
		this._ItemTypeTrans = base.transform.GetChild(3);
		this._SkillIconArray = base.transform.GetComponent<UISpritesArray>();
		if (arg1 == 0)
		{
			this.Info = new FootballSkillInfo(this);
		}
		else
		{
			this.Info = new FootballActInfo(this);
		}
		Image component = base.transform.GetChild(4).GetComponent<Image>();
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			component.enabled = false;
		}
		else
		{
			component.sprite = door.LoadSprite("UI_main_close_base");
			component.material = door.LoadMaterial();
		}
		component = base.transform.GetChild(4).GetChild(0).GetComponent<Image>();
		component.sprite = door.LoadSprite("UI_main_close");
		component.material = door.LoadMaterial();
		int rowCount = this.Info.GetRowCount();
		this.ExitBtn = base.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
		this.ExitBtn.m_Handler = this;
		this._ScrollItems = new UIFootBallInfo.ScrollItemBase[rowCount];
		this.ItemsHeigh = new List<float>(rowCount);
		for (int i = 0; i < rowCount; i++)
		{
			this.ItemsHeigh.Add(30f);
		}
	}

	// Token: 0x060011DB RID: 4571 RVA: 0x001F1A78 File Offset: 0x001EFC78
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.DelayInit > 0)
		{
			this.DelayInit -= 1;
			if (this.DelayInit == 0)
			{
				int count = this.ItemsHeigh.Count;
				this.ScrollPanel.gameObject.SetActive(true);
				this.ScrollPanel.IntiScrollPanel(509f, 0f, 0f, this.ItemsHeigh, count, this);
				for (int i = 0; i < count; i++)
				{
					this.ItemsHeigh[i] = this._ScrollItems[i].GetHeight();
				}
				this.ScrollPanel.AddNewDataHeight(this.ItemsHeigh, true, true);
				UIButtonHint.scrollRect = this.ScrollPanel.transform.GetComponent<CScrollRect>();
			}
		}
	}

	// Token: 0x060011DC RID: 4572 RVA: 0x001F1B40 File Offset: 0x001EFD40
	public override void UpdateNetwork(byte[] meg)
	{
		if (meg[0] == 35)
		{
			for (int i = 0; i < this._ScrollItems.Length; i++)
			{
				if (this._ScrollItems[i] == null)
				{
					break;
				}
				this._ScrollItems[i].TextRefresh();
			}
			this.TitleText.enabled = false;
			this.TitleText.enabled = true;
		}
	}

	// Token: 0x060011DD RID: 4573 RVA: 0x001F1BA8 File Offset: 0x001EFDA8
	public override void OnClose()
	{
		for (int i = 0; i < this._ScrollItems.Length; i++)
		{
			if (this._ScrollItems[i] == null)
			{
				break;
			}
			this._ScrollItems[i].OnClose();
		}
		this.Info.OnClose();
	}

	// Token: 0x060011DE RID: 4574 RVA: 0x001F1BF8 File Offset: 0x001EFDF8
	public override bool OnBackButtonClick()
	{
		this.Info.OnButtonClick(this.ExitBtn);
		return true;
	}

	// Token: 0x040038A4 RID: 14500
	private FoolballInfoBase Info;

	// Token: 0x040038A5 RID: 14501
	private List<float> ItemsHeigh;

	// Token: 0x040038A6 RID: 14502
	private UIFootBallInfo.ScrollItemBase[] _ScrollItems;

	// Token: 0x040038A7 RID: 14503
	private UIText _TitleText;

	// Token: 0x040038A8 RID: 14504
	private ScrollPanel ScrollPanel;

	// Token: 0x040038A9 RID: 14505
	private Transform _ItemTypeTrans;

	// Token: 0x040038AA RID: 14506
	private UISpritesArray _SkillIconArray;

	// Token: 0x040038AB RID: 14507
	private UIButton ExitBtn;

	// Token: 0x040038AC RID: 14508
	private byte DelayInit = 2;

	// Token: 0x02000362 RID: 866
	public enum eType
	{
		// Token: 0x040038AE RID: 14510
		Skill,
		// Token: 0x040038AF RID: 14511
		Activity
	}

	// Token: 0x02000363 RID: 867
	private enum UIControl
	{
		// Token: 0x040038B1 RID: 14513
		BackImg,
		// Token: 0x040038B2 RID: 14514
		Title,
		// Token: 0x040038B3 RID: 14515
		Scroll,
		// Token: 0x040038B4 RID: 14516
		ScrollItem,
		// Token: 0x040038B5 RID: 14517
		Close
	}

	// Token: 0x02000364 RID: 868
	public abstract class ScrollItemBase
	{
		// Token: 0x060011DF RID: 4575 RVA: 0x001F1C0C File Offset: 0x001EFE0C
		public ScrollItemBase(Transform transform)
		{
			this.recttransform = (UnityEngine.Object.Instantiate(transform.gameObject) as GameObject).transform.GetComponent<RectTransform>();
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060011E0 RID: 4576 RVA: 0x001F1C40 File Offset: 0x001EFE40
		// (set) Token: 0x060011E1 RID: 4577 RVA: 0x001F1C48 File Offset: 0x001EFE48
		public RectTransform recttransform
		{
			get
			{
				return this._recttransform;
			}
			protected set
			{
				this._recttransform = value;
			}
		}

		// Token: 0x060011E2 RID: 4578 RVA: 0x001F1C54 File Offset: 0x001EFE54
		public virtual void SetData(int Index)
		{
		}

		// Token: 0x060011E3 RID: 4579 RVA: 0x001F1C58 File Offset: 0x001EFE58
		public virtual void SetData(uint[] Index, int[] fontsize, int[] linespace)
		{
		}

		// Token: 0x060011E4 RID: 4580 RVA: 0x001F1C5C File Offset: 0x001EFE5C
		public virtual float GetHeight()
		{
			return this.recttransform.rect.height;
		}

		// Token: 0x060011E5 RID: 4581
		public abstract void TextRefresh();

		// Token: 0x060011E6 RID: 4582 RVA: 0x001F1C7C File Offset: 0x001EFE7C
		public virtual void OnClose()
		{
		}

		// Token: 0x040038B6 RID: 14518
		private RectTransform _recttransform;
	}

	// Token: 0x02000365 RID: 869
	public class ItemTextMulti : UIFootBallInfo.ScrollItemBase
	{
		// Token: 0x060011E7 RID: 4583 RVA: 0x001F1C80 File Offset: 0x001EFE80
		public ItemTextMulti(byte count, Transform transform, Font font) : base(transform)
		{
			this.Context = new UIText[(int)count];
			for (byte b = 0; b < count; b += 1)
			{
				this.Context[(int)b] = base.recttransform.GetChild((int)b).GetComponent<UIText>();
				this.Context[(int)b].font = font;
			}
		}

		// Token: 0x060011E8 RID: 4584 RVA: 0x001F1CDC File Offset: 0x001EFEDC
		public override void SetData(uint[] Index, int[] fontsize, int[] linespace)
		{
			StringTable mStringTable = DataManager.Instance.mStringTable;
			for (int i = 0; i < this.Context.Length; i++)
			{
				this.Context[i].fontSize = fontsize[i];
				this.Context[i].text = mStringTable.GetStringByID(Index[i]);
			}
			this.UpdateLayout(linespace);
		}

		// Token: 0x060011E9 RID: 4585 RVA: 0x001F1D3C File Offset: 0x001EFF3C
		private void UpdateLayout(int[] linespace)
		{
			this.Height = 0f;
			float num = 0f;
			for (int i = 0; i < this.Context.Length; i++)
			{
				if (this.Context[i].preferredWidth != 0f)
				{
					float preferredHeight = this.Context[i].preferredHeight;
					RectTransform rectTransform = this.Context[i].rectTransform;
					rectTransform.sizeDelta = new Vector2(this.Context[i].rectTransform.sizeDelta.x, preferredHeight);
					rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -num);
					num += preferredHeight + (float)linespace[i];
				}
			}
			this.Height = num;
		}

		// Token: 0x060011EA RID: 4586 RVA: 0x001F1E00 File Offset: 0x001F0000
		public override float GetHeight()
		{
			return this.Height;
		}

		// Token: 0x060011EB RID: 4587 RVA: 0x001F1E08 File Offset: 0x001F0008
		public override void TextRefresh()
		{
			for (int i = 0; i < this.Context.Length; i++)
			{
				this.Context[i].enabled = false;
				this.Context[i].enabled = true;
			}
		}

		// Token: 0x040038B7 RID: 14519
		private UIText[] Context;

		// Token: 0x040038B8 RID: 14520
		private float Height;
	}

	// Token: 0x02000366 RID: 870
	public class ItemTitle : UIFootBallInfo.ScrollItemBase
	{
		// Token: 0x060011EC RID: 4588 RVA: 0x001F1E4C File Offset: 0x001F004C
		public ItemTitle(Transform transform, Font font) : base(transform)
		{
			this.Titletext = base.recttransform.GetChild(0).GetComponent<UIText>();
			this.Titletext.font = font;
		}

		// Token: 0x060011ED RID: 4589 RVA: 0x001F1E84 File Offset: 0x001F0084
		public override void SetData(int Index)
		{
			this.Titletext.text = DataManager.Instance.mStringTable.GetStringByID((uint)Index);
		}

		// Token: 0x060011EE RID: 4590 RVA: 0x001F1EA4 File Offset: 0x001F00A4
		public override void TextRefresh()
		{
			this.Titletext.enabled = false;
			this.Titletext.enabled = true;
		}

		// Token: 0x040038B9 RID: 14521
		private UIText Titletext;
	}

	// Token: 0x02000367 RID: 871
	public class ItemSkill : UIFootBallInfo.ScrollItemBase
	{
		// Token: 0x060011EF RID: 4591 RVA: 0x001F1EC0 File Offset: 0x001F00C0
		public ItemSkill(Transform transform, Font font, UISpritesArray SkillIconArray, GUIWindow win) : base(transform)
		{
			this.SkillIcon = new _FootSkillIcon(base.recttransform.GetChild(0) as RectTransform, font, SkillIconArray);
			for (int i = 0; i < this.Context.Length; i++)
			{
				this.Context[i] = base.recttransform.GetChild(i + 1).GetComponent<UIText>();
				this.Context[i].font = font;
			}
			this.TimeText = base.recttransform.GetChild(4).GetChild(1).GetComponent<Text>();
			this.TimeText.font = font;
			UIButtonHint uibuttonHint = base.recttransform.GetChild(5).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = win;
			uibuttonHint.Parm1 = 12561;
			this.TimeStr = StringManager.Instance.SpawnString(30);
			this.ContStr[0] = StringManager.Instance.SpawnString(30);
			this.ContStr[1] = StringManager.Instance.SpawnString(128);
		}

		// Token: 0x060011F0 RID: 4592 RVA: 0x001F1FE4 File Offset: 0x001F01E4
		public override void SetData(int Index)
		{
			StringTable mStringTable = DataManager.Instance.mStringTable;
			FootBallSkillData recordByIndex = FootballManager.Instance.FootBallSkillTable.GetRecordByIndex(Index);
			this.SkillIcon.SetData(ref recordByIndex);
			this.Context[0].text = mStringTable.GetStringByID((uint)recordByIndex.SkillName);
			this.ContStr[0].ClearString();
			this.ContStr[0].IntToFormat((long)recordByIndex.SkillStrength, 1, false);
			this.ContStr[0].AppendFormat(mStringTable.GetStringByID(17202u));
			this.Context[1].text = this.ContStr[0].ToString();
			this.Context[1].SetAllDirty();
			this.Context[1].cachedTextGenerator.Invalidate();
			this.ContStr[1].ClearString();
			this.ContStr[1].IntToFormat((long)recordByIndex.NeedSoldierRank, 1, false);
			this.ContStr[1].IntToFormat((long)((ulong)recordByIndex.NeedSoldierQty), 1, true);
			this.ContStr[1].AppendFormat(mStringTable.GetStringByID(17203u));
			this.Context[2].text = this.ContStr[1].ToString();
			this.Context[2].SetAllDirty();
			this.Context[2].cachedTextGenerator.Invalidate();
			this.TimeStr.ClearString();
			this.TimeStr.IntToFormat((long)(recordByIndex.SkillCountDown / 100), 1, true);
			this.TimeStr.AppendFormat(mStringTable.GetStringByID(17204u));
			this.TimeText.text = this.TimeStr.ToString();
			this.TimeText.SetAllDirty();
			this.TimeText.cachedTextGenerator.Invalidate();
		}

		// Token: 0x060011F1 RID: 4593 RVA: 0x001F21A4 File Offset: 0x001F03A4
		public override void TextRefresh()
		{
			this.TimeText.enabled = false;
			this.TimeText.enabled = true;
			this.SkillIcon.TextRefresh();
			for (int i = 0; i < this.Context.Length; i++)
			{
				this.Context[i].enabled = false;
				this.Context[i].enabled = true;
			}
		}

		// Token: 0x060011F2 RID: 4594 RVA: 0x001F220C File Offset: 0x001F040C
		public override void OnClose()
		{
			this.SkillIcon.OnClose();
			StringManager.Instance.DeSpawnString(this.TimeStr);
			StringManager.Instance.DeSpawnString(this.ContStr[0]);
			StringManager.Instance.DeSpawnString(this.ContStr[1]);
		}

		// Token: 0x040038BA RID: 14522
		private _FootSkillIcon SkillIcon;

		// Token: 0x040038BB RID: 14523
		private UIText[] Context = new UIText[3];

		// Token: 0x040038BC RID: 14524
		private Text TimeText;

		// Token: 0x040038BD RID: 14525
		private CString TimeStr;

		// Token: 0x040038BE RID: 14526
		private CString[] ContStr = new CString[2];
	}
}
