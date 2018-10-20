using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000584 RID: 1412
public class PetSkillHint : HintStyleBase
{
	// Token: 0x06001C0A RID: 7178 RVA: 0x00319C28 File Offset: 0x00317E28
	public PetSkillHint(RectTransform transform)
	{
		GUIManager instance = GUIManager.Instance;
		this.rectTrans = transform;
		Font ttffont = instance.GetTTFFont();
		UILoadImageHander itemInfo = instance.m_ItemInfo;
		this.StateObj = this.rectTrans.GetChild(0).gameObject;
		this.StateText = this.rectTrans.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.StateText.font = ttffont;
		this.StateContText = this.rectTrans.GetChild(0).GetChild(1).GetComponent<UIText>();
		this.StateContText.font = ttffont;
		this.OthersObj = this.rectTrans.GetChild(1).gameObject;
		this.SkillImg = this.rectTrans.GetChild(1).GetChild(0).GetComponent<Image>();
		CustomImage component = this.rectTrans.GetChild(1).GetChild(0).GetChild(0).GetComponent<CustomImage>();
		component.hander = itemInfo;
		this.NameText = this.rectTrans.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.NameText.font = ttffont;
		this.KindText = this.rectTrans.GetChild(1).GetChild(2).GetComponent<UIText>();
		this.KindText.font = ttffont;
		component = this.rectTrans.GetChild(1).GetChild(3).GetChild(0).GetComponent<CustomImage>();
		component.hander = itemInfo;
		this.CrystalText = this.rectTrans.GetChild(1).GetChild(3).GetChild(1).GetComponent<UIText>();
		this.CrystalText.font = ttffont;
		this.CrystalText.text = DataManager.Instance.mStringTable.GetStringByID(10081u);
		this.CrystalObj = this.rectTrans.GetChild(1).GetChild(3).gameObject;
		this.Contents = new PetSkillHint._Content[2];
		this.Contents[0] = new PetSkillHint._Content(this.rectTrans.GetChild(1).GetChild(4), ttffont);
		this.Contents[1] = new PetSkillHint._Content(this.rectTrans.GetChild(1).GetChild(7), ttffont);
		this.rectTrans.GetChild(1).GetChild(5).GetComponent<CustomImage>().hander = itemInfo;
		this.LineRect = this.rectTrans.GetChild(1).GetChild(5).GetComponent<RectTransform>();
		this.LineObj = this.LineRect.gameObject;
		this.rectTrans.GetChild(1).GetChild(6).GetComponent<CustomImage>().hander = itemInfo;
		this.MaxBackRect = this.rectTrans.GetChild(1).GetChild(6).GetComponent<RectTransform>();
		this.BackSprite[0] = instance.LoadFrameSprite("UI_main_hero_box_01");
		this.BackSprite[1] = instance.LoadFrameSprite("UI_main_hero_box_01_b");
		this.BackSprite[2] = instance.LoadFrameSprite("UI_main_hero_box_01_c");
		this.BackSprite[3] = instance.LoadFrameSprite("UI_main_box_012");
		this.HintFrameSprite = this.BackSprite[0];
		this.HintFrameMat = instance.GetFrameMaterial();
		this.CanvasRect = instance.m_UICanvas.GetComponent<RectTransform>();
		this.HintWidth = this.rectTrans.sizeDelta.x;
		this.Note = new PetSkillHint._Note(this.rectTrans.GetChild(1).GetChild(8), ttffont, itemInfo);
	}

	// Token: 0x06001C0B RID: 7179 RVA: 0x00319FC0 File Offset: 0x003181C0
	public override void SetStyle(byte style)
	{
	}

	// Token: 0x06001C0C RID: 7180 RVA: 0x00319FC4 File Offset: 0x003181C4
	public override Vector2 GetSize()
	{
		if (this.Kind == PetSkillHint.eKind.State)
		{
			float x = this.HintWidth;
			if (this.StateContText.cachedTextGeneratorForLayout.lineCount <= 1)
			{
				x = ((this.StateText.preferredWidth <= this.StateContText.preferredWidth) ? (this.StateContText.preferredWidth + 16f) : (this.StateText.preferredWidth + 16f));
			}
			return new Vector2(x, this.StateText.rectTransform.sizeDelta.y + this.StateContText.preferredHeight + 16f);
		}
		if (this.Contents[1].activeSelf)
		{
			return new Vector2(this.HintWidth, -this.Contents[1].rectTransfrom.anchoredPosition.y + this.Contents[1].Height + 25f + this.Note.Height);
		}
		return new Vector2(this.HintWidth, -this.Contents[0].rectTransfrom.anchoredPosition.y + this.Contents[0].Height + 25f + this.Note.Height);
	}

	// Token: 0x06001C0D RID: 7181 RVA: 0x0031A124 File Offset: 0x00318324
	public override void SetContent(int kind, int fontsize, float width, int Parm1, int Parm2 = 0)
	{
		PetManager instance = PetManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.Kind = (PetSkillHint.eKind)kind;
		this.SkillID = (ushort)(Parm1 & 255);
		this.PetID = (ushort)(Parm1 >> 16);
		this.Level = (byte)Parm2;
		byte b = 0;
		float num = 0f;
		PetData petData = instance.FindPetData(this.PetID);
		PetSkillTbl recordByKey = instance.PetSkillTable.GetRecordByKey(this.SkillID);
		if (this.Level == 0)
		{
			this.Level = 1;
		}
		if (recordByKey.UpLevel < this.Level)
		{
			this.Level = recordByKey.UpLevel;
		}
		if (this.Kind == PetSkillHint.eKind.State)
		{
			this.SetStateContent(mStringTable.GetStringByID((uint)recordByKey.Name), this.SkillID, this.Level);
			this.HintFrameSprite = this.BackSprite[3];
			this.StateObj.SetActive(true);
			this.OthersObj.SetActive(false);
			return;
		}
		this.StateObj.SetActive(false);
		this.OthersObj.SetActive(true);
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.Append('s');
		cstring.IntToFormat((long)recordByKey.Icon, 5, false);
		cstring.AppendFormat("{0}");
		this.SkillImg.sprite = instance2.LoadSkillSprite(cstring);
		this.SkillImg.material = instance2.GetSkillMaterial();
		this.NameText.text = mStringTable.GetStringByID((uint)recordByKey.Name);
		if (recordByKey.Diamond > 0)
		{
			this.CrystalObj.SetActive(true);
			b += 1;
		}
		else
		{
			this.CrystalObj.SetActive(false);
		}
		byte type = recordByKey.Type;
		if (type != 1)
		{
			if (type != 2)
			{
				this.KindText.text = string.Empty;
			}
			else
			{
				this.KindText.text = mStringTable.GetStringByID(10091u);
			}
		}
		else if (recordByKey.Subject == 1)
		{
			this.KindText.text = mStringTable.GetStringByID(10083u);
		}
		else if (recordByKey.Subject == 2)
		{
			this.KindText.text = mStringTable.GetStringByID(10084u);
		}
		else if (recordByKey.Subject == 3)
		{
			this.KindText.text = mStringTable.GetStringByID(10085u);
		}
		else
		{
			this.KindText.text = string.Empty;
		}
		switch (this.Kind)
		{
		case PetSkillHint.eKind.Normal:
		{
			byte needEnhance = this.GetNeedEnhance(petData);
			this.LineObj.SetActive(true);
			this.Contents[0].SetActive(true);
			this.Contents[0].SetData(ref recordByKey, this.Level, PetSkillHint._Content._ShowType.ShowNone, needEnhance, 0, PetSkillHint._Content.eFlag.None);
			if (petData != null && petData.Enhance < needEnhance)
			{
				this.Note.activeSelf = false;
				this.Contents[1].SetActive(true);
				num = 25f;
				this.Contents[1].SetData(ref recordByKey, recordByKey.UpLevel, PetSkillHint._Content._ShowType.ShowMax, needEnhance, this.GetNeedLv(recordByKey.UpLevel, recordByKey.OpenLevel, petData), PetSkillHint._Content.eFlag.None);
			}
			else
			{
				if (recordByKey.Type == 2)
				{
					this.Note.activeSelf = true;
				}
				else
				{
					this.Note.activeSelf = false;
				}
				if (this.Level < recordByKey.UpLevel)
				{
					this.Contents[1].SetActive(true);
					this.Contents[1].SetData(ref recordByKey, this.Level += 1, PetSkillHint._Content._ShowType.ShowNext, needEnhance, this.GetNeedLv(this.Level, recordByKey.OpenLevel, petData), PetSkillHint._Content.eFlag.None);
				}
				else
				{
					this.Contents[1].SetActive(false);
					this.LineObj.SetActive(false);
				}
			}
			break;
		}
		case PetSkillHint.eKind.MaxLv:
			this.Note.activeSelf = false;
			this.LineObj.SetActive(true);
			this.Contents[0].SetActive(true);
			this.Contents[0].SetData(ref recordByKey, this.Level, PetSkillHint._Content._ShowType.ShowNone, 0, 0, PetSkillHint._Content.eFlag.None);
			this.Contents[1].SetActive(true);
			this.Contents[1].SetData(ref recordByKey, recordByKey.UpLevel, PetSkillHint._Content._ShowType.ShowMax, this.GetNeedEnhance(petData), this.GetNeedLv(recordByKey.UpLevel, recordByKey.OpenLevel, petData), PetSkillHint._Content.eFlag.None);
			break;
		case PetSkillHint.eKind.Lv1AndMax:
			this.Note.activeSelf = false;
			this.LineObj.SetActive(true);
			this.Contents[0].SetActive(true);
			this.Contents[0].SetData(ref recordByKey, 1, PetSkillHint._Content._ShowType.ShowNone, 0, 0, PetSkillHint._Content.eFlag.ShowLvOne);
			this.Contents[1].SetActive(true);
			this.Contents[1].SetData(ref recordByKey, recordByKey.UpLevel, PetSkillHint._Content._ShowType.ShowMax, this.GetNeedEnhance(petData), this.GetNeedLv(recordByKey.UpLevel, recordByKey.OpenLevel, petData), PetSkillHint._Content.eFlag.SkipLvCheck);
			break;
		case PetSkillHint.eKind.CurentLv:
			this.LineObj.SetActive(false);
			this.Contents[0].SetActive(true);
			this.Contents[0].SetData(ref recordByKey, this.Level, PetSkillHint._Content._ShowType.ShowNone, 0, 0, PetSkillHint._Content.eFlag.None);
			this.Contents[1].SetActive(false);
			break;
		case PetSkillHint.eKind.Mail:
			this.Note.activeSelf = false;
			this.LineObj.SetActive(false);
			this.Contents[0].SetActive(true);
			this.Contents[0].SetData(ref recordByKey, this.Level, PetSkillHint._Content._ShowType.ShowNone, 0, 0, PetSkillHint._Content.eFlag.Mail);
			this.Contents[1].SetActive(false);
			break;
		default:
			this.Note.activeSelf = false;
			this.LineObj.SetActive(false);
			this.Contents[0].SetActive(false);
			this.Contents[1].SetActive(false);
			break;
		}
		if (this.Contents[0].CoolTime())
		{
			b += 1;
		}
		this.HintFrameSprite = this.BackSprite[(int)b];
		this.DefHeight = this.DefHeights[(int)b];
		this.Contents[0].rectTransfrom.anchoredPosition = new Vector2(this.Contents[0].rectTransfrom.anchoredPosition.x, -this.DefHeight);
		if (this.LineObj.activeSelf)
		{
			this.LineRect.anchoredPosition = new Vector2(this.LineRect.anchoredPosition.x, this.Contents[0].rectTransfrom.anchoredPosition.y - this.Contents[0].Height - 25f + num);
		}
		if (this.Contents[1].activeSelf)
		{
			this.Contents[1].rectTransfrom.anchoredPosition = new Vector2(this.Contents[1].rectTransfrom.anchoredPosition.x, this.LineRect.anchoredPosition.y - this.LineRect.sizeDelta.y - 13f);
		}
		if (this.Note.activeSelf)
		{
			if (this.Contents[1].activeSelf)
			{
				this.Note.rectTransform.anchoredPosition = new Vector2(this.Note.rectTransform.anchoredPosition.x, this.Contents[1].rectTransfrom.anchoredPosition.y - this.Contents[1].Height);
			}
			else
			{
				this.Note.rectTransform.anchoredPosition = new Vector2(this.Note.rectTransform.anchoredPosition.x, this.Contents[0].rectTransfrom.anchoredPosition.y - this.Contents[0].Height);
			}
		}
		if (this.CanvasRect.sizeDelta.y < this.GetSize().y)
		{
			int num2 = 0;
			while (this.CanvasRect.sizeDelta.y < this.GetSize().y)
			{
				for (int i = 0; i < this.Contents.Length; i++)
				{
					if (this.Contents[i].activeSelf)
					{
						num2 = this.Contents[i].FontShrink();
					}
				}
				if (this.LineObj.activeSelf)
				{
					this.LineRect.anchoredPosition = new Vector2(this.LineRect.anchoredPosition.x, this.Contents[0].rectTransfrom.anchoredPosition.y - this.Contents[0].Height - 25f);
				}
				if (this.Contents[1].activeSelf)
				{
					this.Contents[1].rectTransfrom.anchoredPosition = new Vector2(this.Contents[1].rectTransfrom.anchoredPosition.x, this.LineRect.anchoredPosition.y - this.LineRect.sizeDelta.y - 13f);
				}
				if (num2 == 8)
				{
					break;
				}
			}
		}
		if (this.Contents[1].activeSelf && (num > 0f || this.Kind == PetSkillHint.eKind.MaxLv || this.Kind == PetSkillHint.eKind.Lv1AndMax))
		{
			this.MaxBackRect.gameObject.SetActive(true);
			this.MaxBackRect.anchoredPosition = new Vector2(this.MaxBackRect.anchoredPosition.x, this.LineRect.anchoredPosition.y - 5f);
			this.MaxBackRect.sizeDelta = new Vector2(this.MaxBackRect.sizeDelta.x, this.Contents[1].Height + 24f);
		}
		else
		{
			this.MaxBackRect.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001C0E RID: 7182 RVA: 0x0031AC24 File Offset: 0x00318E24
	public void SetStateContent(string Name, ushort SkillID, byte Level)
	{
		this.StateContText.rectTransform.sizeDelta = new Vector2(this.HintWidth - 16f, this.StateContText.rectTransform.sizeDelta.y);
		PetManager.Instance.FormatSkillContent(SkillID, Level, this.Contents[0].ContStr, 1);
		this.StateText.text = Name;
		this.StateContText.text = this.Contents[0].ContStr.ToString();
		this.StateContText.SetAllDirty();
		this.StateContText.cachedTextGenerator.Invalidate();
		this.StateContText.cachedTextGeneratorForLayout.Invalidate();
		this.StateContText.rectTransform.sizeDelta = new Vector2(this.StateContText.rectTransform.sizeDelta.x, this.StateContText.preferredHeight);
	}

	// Token: 0x06001C0F RID: 7183 RVA: 0x0031AD18 File Offset: 0x00318F18
	private sbyte GetNeedLv(byte Level, byte[] OpenLevel, PetData curPet)
	{
		sbyte b = 0;
		if (Level > 1 && (int)Level <= OpenLevel.Length + 1)
		{
			b = (sbyte)OpenLevel[(int)(Level - 2)];
		}
		if (curPet != null)
		{
			if ((int)b > 0 && (int)curPet.Level < (int)b)
			{
				b = (sbyte)((int)b * -1);
			}
		}
		else
		{
			b = (sbyte)((int)b * -1);
		}
		return b;
	}

	// Token: 0x06001C10 RID: 7184 RVA: 0x0031AD70 File Offset: 0x00318F70
	private byte GetNeedEnhance(PetData curPet)
	{
		byte result = 0;
		if (this.PetID > 0)
		{
			PetTbl recordByKey = PetManager.Instance.PetTable.GetRecordByKey(this.PetID);
			for (int i = 0; i < recordByKey.PetSkill.Length; i++)
			{
				if (recordByKey.PetSkill[i] == this.SkillID)
				{
					if (curPet != null && (int)curPet.Enhance < i)
					{
						result = (byte)i;
					}
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x06001C11 RID: 7185 RVA: 0x0031ADEC File Offset: 0x00318FEC
	public override void TextRefresh()
	{
		this.NameText.enabled = false;
		this.NameText.enabled = true;
		this.KindText.enabled = false;
		this.KindText.enabled = true;
		this.CrystalText.enabled = false;
		this.CrystalText.enabled = true;
		this.StateText.enabled = false;
		this.StateText.enabled = true;
		this.StateContText.enabled = false;
		this.StateContText.enabled = true;
		this.Contents[0].TextRefresh();
		this.Contents[1].TextRefresh();
		this.Note.TextRefresh();
	}

	// Token: 0x040054D5 RID: 21717
	private float HintWidth;

	// Token: 0x040054D6 RID: 21718
	private ushort SkillID;

	// Token: 0x040054D7 RID: 21719
	private ushort PetID;

	// Token: 0x040054D8 RID: 21720
	private byte Level;

	// Token: 0x040054D9 RID: 21721
	private UIText NameText;

	// Token: 0x040054DA RID: 21722
	private UIText KindText;

	// Token: 0x040054DB RID: 21723
	private UIText CrystalText;

	// Token: 0x040054DC RID: 21724
	private UIText StateText;

	// Token: 0x040054DD RID: 21725
	private UIText StateContText;

	// Token: 0x040054DE RID: 21726
	private GameObject CrystalObj;

	// Token: 0x040054DF RID: 21727
	private GameObject LineObj;

	// Token: 0x040054E0 RID: 21728
	private GameObject StateObj;

	// Token: 0x040054E1 RID: 21729
	private GameObject OthersObj;

	// Token: 0x040054E2 RID: 21730
	private RectTransform LineRect;

	// Token: 0x040054E3 RID: 21731
	private RectTransform CanvasRect;

	// Token: 0x040054E4 RID: 21732
	private RectTransform MaxBackRect;

	// Token: 0x040054E5 RID: 21733
	private PetSkillHint._Content[] Contents;

	// Token: 0x040054E6 RID: 21734
	private PetSkillHint._Note Note;

	// Token: 0x040054E7 RID: 21735
	private Image SkillImg;

	// Token: 0x040054E8 RID: 21736
	private float DefHeight;

	// Token: 0x040054E9 RID: 21737
	private PetSkillHint.eKind Kind;

	// Token: 0x040054EA RID: 21738
	private Sprite[] BackSprite = new Sprite[4];

	// Token: 0x040054EB RID: 21739
	private float[] DefHeights = new float[]
	{
		69f,
		96.7f,
		127.27f
	};

	// Token: 0x02000585 RID: 1413
	private enum UIHitTypeControl
	{
		// Token: 0x040054ED RID: 21741
		State,
		// Token: 0x040054EE RID: 21742
		Others
	}

	// Token: 0x02000586 RID: 1414
	private enum UIControl
	{
		// Token: 0x040054F0 RID: 21744
		Icon,
		// Token: 0x040054F1 RID: 21745
		Name,
		// Token: 0x040054F2 RID: 21746
		King,
		// Token: 0x040054F3 RID: 21747
		UseCrystal,
		// Token: 0x040054F4 RID: 21748
		Content1,
		// Token: 0x040054F5 RID: 21749
		LineImg,
		// Token: 0x040054F6 RID: 21750
		MaxBack,
		// Token: 0x040054F7 RID: 21751
		Content2,
		// Token: 0x040054F8 RID: 21752
		Note
	}

	// Token: 0x02000587 RID: 1415
	public enum eKind
	{
		// Token: 0x040054FA RID: 21754
		Normal,
		// Token: 0x040054FB RID: 21755
		MaxLv,
		// Token: 0x040054FC RID: 21756
		Lv1AndMax,
		// Token: 0x040054FD RID: 21757
		CurentLv,
		// Token: 0x040054FE RID: 21758
		Mail,
		// Token: 0x040054FF RID: 21759
		State
	}

	// Token: 0x02000588 RID: 1416
	public enum eBackImage
	{
		// Token: 0x04005501 RID: 21761
		Type1,
		// Token: 0x04005502 RID: 21762
		Type2,
		// Token: 0x04005503 RID: 21763
		Type3,
		// Token: 0x04005504 RID: 21764
		Type4,
		// Token: 0x04005505 RID: 21765
		Max
	}

	// Token: 0x02000589 RID: 1417
	private struct _Content
	{
		// Token: 0x06001C12 RID: 7186 RVA: 0x0031AEA0 File Offset: 0x003190A0
		public _Content(Transform transform, Font font)
		{
			this.gameobject = transform.gameObject;
			this.rectTransfrom = (transform as RectTransform);
			this.ContText = transform.GetChild(0).GetComponent<UIText>();
			this.ContText.font = font;
			this.DefFontSize = this.ContText.fontSize;
			this.OriContTop = this.ContText.rectTransform.anchoredPosition.y;
			this.CooldownText = transform.GetChild(1).GetComponent<UIText>();
			this.CooldownText.font = font;
			this.CooldownText.AdjuestUI();
			this.DefHeight = 0f;
			this.TitleText = transform.GetChild(2).GetComponent<UIText>();
			this.TitleText.font = font;
			this.ContStr = new CString(512);
			this.CooldownStr = new CString(64);
			this.TitleStr = new CString(32);
			this.IsCoolTime = false;
		}

		// Token: 0x06001C13 RID: 7187 RVA: 0x0031AF98 File Offset: 0x00319198
		public void SetData(ref PetSkillTbl skillData, byte level, PetSkillHint._Content._ShowType type, byte needEnhance, sbyte NeedLv, PetSkillHint._Content.eFlag Flag = PetSkillHint._Content.eFlag.None)
		{
			this.ContStr.ClearString();
			this.CooldownStr.ClearString();
			this.ContText.fontSize = this.DefFontSize;
			StringTable mStringTable = DataManager.Instance.mStringTable;
			this.TitleText.color = new Color32(byte.MaxValue, 201, 97, byte.MaxValue);
			if (type == PetSkillHint._Content._ShowType.ShowNext)
			{
				if (needEnhance > 0)
				{
					this.DefHeight = 0f;
					this.TitleText.color = new Color32(byte.MaxValue, 132, 109, byte.MaxValue);
					this.TitleText.text = mStringTable.GetStringByID(10085u + (uint)needEnhance);
					this.ContText.text = string.Empty;
					this.ContText.SetAllDirty();
					this.ContText.cachedTextGenerator.Invalidate();
					this.ContText.cachedTextGeneratorForLayout.Invalidate();
					this.ContText.rectTransform.sizeDelta = new Vector2(this.ContText.rectTransform.sizeDelta.x, this.ContText.preferredHeight);
					return;
				}
				this.TitleText.text = mStringTable.GetStringByID(480u);
				this.CooldownText.alignment = TextAnchor.LowerRight;
			}
			else if (type == PetSkillHint._Content._ShowType.ShowMax)
			{
				this.TitleStr.ClearString();
				this.TitleStr.IntToFormat((long)skillData.UpLevel, 1, false);
				this.TitleStr.AppendFormat(mStringTable.GetStringByID(10137u));
				this.TitleText.color = new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				this.TitleText.text = this.TitleStr.ToString();
				this.TitleText.SetAllDirty();
				this.TitleText.cachedTextGenerator.Invalidate();
				this.CooldownText.alignment = TextAnchor.LowerRight;
				if ((int)NeedLv < 0 && Flag == PetSkillHint._Content.eFlag.SkipLvCheck)
				{
					NeedLv = (sbyte)((int)NeedLv * -1);
				}
			}
			else if (type == PetSkillHint._Content._ShowType.ShowNone)
			{
				if (Flag == PetSkillHint._Content.eFlag.ShowLvOne)
				{
					this.TitleText.gameObject.SetActive(true);
					this.TitleStr.ClearString();
					this.TitleStr.IntToFormat(1L, 1, false);
					this.TitleStr.AppendFormat(mStringTable.GetStringByID(10136u));
					this.TitleText.text = this.TitleStr.ToString();
					this.TitleText.SetAllDirty();
					this.TitleText.cachedTextGenerator.Invalidate();
				}
				else
				{
					this.TitleText.gameObject.SetActive(false);
				}
			}
			else
			{
				this.TitleText.text = string.Empty;
				this.CooldownText.alignment = TextAnchor.UpperRight;
			}
			this.CooldownStr.Append(mStringTable.GetStringByID(10082u));
			this.CooldownStr.Append(" ");
			ushort num = 0;
			if (skillData.CoolDown > 0)
			{
				num = PetManager.Instance.PetSkillCoolTable.GetRecordByKey(skillData.CoolDown).CoolBySkillLv[(int)(level - 1)];
			}
			Vector2 anchoredPosition = new Vector2(this.ContText.rectTransform.anchoredPosition.x, this.OriContTop);
			if (num == 0 || Flag == PetSkillHint._Content.eFlag.Mail)
			{
				this.IsCoolTime = false;
				this.CooldownText.text = string.Empty;
				if (type != PetSkillHint._Content._ShowType.ShowNone && this.TitleText.gameObject.activeSelf)
				{
					anchoredPosition = new Vector2(this.ContText.rectTransform.anchoredPosition.x, this.CooldownText.rectTransform.anchoredPosition.y);
				}
			}
			else
			{
				this.IsCoolTime = true;
				PetManager.Instance.FormatCoolTime(num, this.CooldownStr, (!GUIManager.Instance.IsArabic) ? 0 : 1);
				this.CooldownText.text = this.CooldownStr.ToString();
				this.CooldownText.SetAllDirty();
				this.CooldownText.cachedTextGenerator.Invalidate();
				anchoredPosition = new Vector2(this.ContText.rectTransform.anchoredPosition.x, this.OriContTop);
			}
			if (Flag == PetSkillHint._Content.eFlag.ShowLvOne)
			{
				anchoredPosition.y -= 30f;
			}
			this.ContText.rectTransform.anchoredPosition = anchoredPosition;
			PetManager.Instance.FormatSkillContent(skillData.ID, level, this.ContStr, (Flag != PetSkillHint._Content.eFlag.State) ? 0 : 1);
			if (type != PetSkillHint._Content._ShowType.ShowNone && (int)NeedLv != 0)
			{
				this.ContStr.Append('\n');
				if ((int)NeedLv < 0)
				{
					this.ContStr.Append("<color=#ff6278ff>");
					this.ContStr.IntToFormat((long)(-(long)((int)NeedLv)), 1, false);
				}
				else
				{
					this.ContStr.IntToFormat((long)NeedLv, 1, false);
				}
				this.ContStr.AppendFormat(mStringTable.GetStringByID(10089u));
				if ((int)NeedLv < 0)
				{
					this.ContStr.Append("</color>");
				}
			}
			if (type == PetSkillHint._Content._ShowType.ShowNone)
			{
				if (needEnhance > 0)
				{
					this.ContStr.Append('\n');
					this.ContStr.Append('\n');
					this.ContStr.Append("<color=#ff6278ff>");
					this.ContStr.Append(mStringTable.GetStringByID(10085u + (uint)needEnhance));
					this.ContStr.Append("</color>");
				}
				if (level == skillData.UpLevel)
				{
					this.ContStr.Append('\n');
					this.ContStr.Append("<color=#ffc961ff>");
					this.ContStr.Append(mStringTable.GetStringByID(481u));
					this.ContStr.Append("</color>");
				}
			}
			this.ContText.text = this.ContStr.ToString();
			this.ContText.SetAllDirty();
			this.ContText.cachedTextGenerator.Invalidate();
			this.ContText.cachedTextGeneratorForLayout.Invalidate();
			this.ContText.rectTransform.sizeDelta = new Vector2(this.ContText.rectTransform.sizeDelta.x, this.ContText.preferredHeight);
			if (this.IsCoolTime)
			{
				if (this.TitleText.gameObject.activeSelf)
				{
					this.DefHeight = this.CooldownText.rectTransform.sizeDelta.y + this.TitleText.rectTransform.sizeDelta.y;
				}
				else
				{
					this.DefHeight = this.CooldownText.rectTransform.sizeDelta.y;
				}
			}
			else if (Flag == PetSkillHint._Content.eFlag.ShowLvOne)
			{
				this.DefHeight = this.CooldownText.rectTransform.sizeDelta.y + 30f;
			}
			else
			{
				this.DefHeight = this.CooldownText.rectTransform.sizeDelta.y;
			}
		}

		// Token: 0x06001C14 RID: 7188 RVA: 0x0031B6C4 File Offset: 0x003198C4
		public bool CoolTime()
		{
			return this.IsCoolTime;
		}

		// Token: 0x06001C15 RID: 7189 RVA: 0x0031B6CC File Offset: 0x003198CC
		public void SetActive(bool Active)
		{
			this.gameobject.SetActive(Active);
		}

		// Token: 0x06001C16 RID: 7190 RVA: 0x0031B6DC File Offset: 0x003198DC
		public int FontShrink()
		{
			this.ContText.fontSize--;
			this.ContText.SetLayoutDirty();
			this.ContText.cachedTextGeneratorForLayout.Invalidate();
			return this.ContText.fontSize;
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06001C17 RID: 7191 RVA: 0x0031B724 File Offset: 0x00319924
		public bool activeSelf
		{
			get
			{
				return this.gameobject.activeSelf;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06001C18 RID: 7192 RVA: 0x0031B734 File Offset: 0x00319934
		public float Height
		{
			get
			{
				if (this.gameobject.activeSelf)
				{
					return this.DefHeight + this.ContText.preferredHeight;
				}
				return 0f;
			}
		}

		// Token: 0x06001C19 RID: 7193 RVA: 0x0031B76C File Offset: 0x0031996C
		public void TextRefresh()
		{
			this.ContText.enabled = false;
			this.ContText.enabled = true;
			this.CooldownText.enabled = false;
			this.CooldownText.enabled = true;
			this.TitleText.enabled = false;
			this.TitleText.enabled = true;
		}

		// Token: 0x04005506 RID: 21766
		private GameObject gameobject;

		// Token: 0x04005507 RID: 21767
		public RectTransform rectTransfrom;

		// Token: 0x04005508 RID: 21768
		private UIText ContText;

		// Token: 0x04005509 RID: 21769
		private UIText TitleText;

		// Token: 0x0400550A RID: 21770
		private UIText CooldownText;

		// Token: 0x0400550B RID: 21771
		public CString ContStr;

		// Token: 0x0400550C RID: 21772
		private CString CooldownStr;

		// Token: 0x0400550D RID: 21773
		private CString TitleStr;

		// Token: 0x0400550E RID: 21774
		private float DefHeight;

		// Token: 0x0400550F RID: 21775
		private float OriContTop;

		// Token: 0x04005510 RID: 21776
		private bool IsCoolTime;

		// Token: 0x04005511 RID: 21777
		private int DefFontSize;

		// Token: 0x0200058A RID: 1418
		public enum _ShowType
		{
			// Token: 0x04005513 RID: 21779
			ShowNone,
			// Token: 0x04005514 RID: 21780
			ShowNext,
			// Token: 0x04005515 RID: 21781
			ShowMax
		}

		// Token: 0x0200058B RID: 1419
		public enum eFlag
		{
			// Token: 0x04005517 RID: 21783
			None,
			// Token: 0x04005518 RID: 21784
			Mail,
			// Token: 0x04005519 RID: 21785
			State,
			// Token: 0x0400551A RID: 21786
			SkipLvCheck,
			// Token: 0x0400551B RID: 21787
			ShowLvOne
		}
	}

	// Token: 0x0200058C RID: 1420
	private struct _Note
	{
		// Token: 0x06001C1A RID: 7194 RVA: 0x0031B7C4 File Offset: 0x003199C4
		public _Note(Transform transform, Font font, UILoadImageHander hander)
		{
			this.gameobject = transform.gameObject;
			this.rectTransform = (transform as RectTransform);
			transform.GetChild(0).GetComponent<CustomImage>().hander = hander;
			this.NoteText = transform.GetChild(1).GetComponent<UIText>();
			this.NoteText.font = font;
			this.NoteText.text = DataManager.Instance.mStringTable.GetStringByID(10135u);
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06001C1B RID: 7195 RVA: 0x0031B838 File Offset: 0x00319A38
		// (set) Token: 0x06001C1C RID: 7196 RVA: 0x0031B848 File Offset: 0x00319A48
		public bool activeSelf
		{
			get
			{
				return this.gameobject.activeSelf;
			}
			set
			{
				this.gameobject.SetActive(value);
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06001C1D RID: 7197 RVA: 0x0031B858 File Offset: 0x00319A58
		public float Height
		{
			get
			{
				if (this.activeSelf)
				{
					RectTransform rectTransform = this.NoteText.rectTransform;
					return -rectTransform.anchoredPosition.y + rectTransform.sizeDelta.y;
				}
				return 0f;
			}
		}

		// Token: 0x06001C1E RID: 7198 RVA: 0x0031B8A0 File Offset: 0x00319AA0
		public void TextRefresh()
		{
			this.NoteText.enabled = false;
			this.NoteText.enabled = true;
		}

		// Token: 0x0400551C RID: 21788
		private GameObject gameobject;

		// Token: 0x0400551D RID: 21789
		public RectTransform rectTransform;

		// Token: 0x0400551E RID: 21790
		private UIText NoteText;
	}
}
