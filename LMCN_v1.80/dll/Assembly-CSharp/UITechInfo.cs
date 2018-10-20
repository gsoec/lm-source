using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000691 RID: 1681
public class UITechInfo : IUIButtonClickHandler
{
	// Token: 0x0600203F RID: 8255 RVA: 0x003D2A20 File Offset: 0x003D0C20
	public void OnOpen(int arg1, int arg2)
	{
		Transform child = this.ThisTransform.GetChild(1);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.TechID = arg1;
		UIButton component = this.ThisTransform.GetChild(0).GetComponent<UIButton>();
		component.m_BtnID1 = 1;
		component.m_Handler = this;
		component = child.GetChild(1).GetComponent<UIButton>();
		component.m_BtnID1 = 0;
		component.m_Handler = this;
		if (GUIManager.Instance.IsArabic)
		{
			component.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			RectTransform component2 = this.ThisTransform.GetChild(0).GetComponent<RectTransform>();
			component2.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			component2.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		this.TechImage = child.GetChild(2).GetChild(0).GetComponent<Image>();
		this.Frame = child.GetChild(2).GetChild(1);
		this.Lock = child.GetChild(2).GetChild(1).GetChild(0);
		this.Lock1 = child.GetChild(2).GetChild(1).GetChild(1);
		this.LockPanel = child.GetChild(2).GetChild(0).GetChild(0);
		this.FullFrame = child.GetChild(2).GetChild(2);
		this.DegreeRect = child.GetChild(2).GetChild(3).GetComponent<RectTransform>();
		this.LevelText = child.GetChild(2).GetChild(4).GetComponent<UIText>();
		this.TechName = child.GetChild(2).GetChild(5).GetComponent<UIText>();
		this.EffectRect = child.GetChild(3).GetComponent<RectTransform>();
		this.EffectText = child.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.EffectNextText = child.GetChild(4).GetComponent<UIText>();
		this.ContText = child.GetChild(5).GetChild(0).GetComponent<UIText>();
		Text contText = this.ContText;
		Font font = ttffont;
		this.TechName.font = font;
		font = font;
		this.LevelText.font = font;
		font = font;
		this.EffectText.font = font;
		font = font;
		this.EffectNextText.font = font;
		contText.font = font;
		this.LevelStr = StringManager.Instance.SpawnString(30);
		this.EffectStr = StringManager.Instance.SpawnString(100);
		this.EffectNextStr = StringManager.Instance.SpawnString(100);
		this.ContentStr = StringManager.Instance.SpawnString(200);
		if (GUIManager.Instance.IsArabic)
		{
			this.TechImage.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		this.ConfirmTrans = child.GetChild(6);
		this.ConfirmBtn = this.ConfirmTrans.GetComponent<UIButton>();
		this.ConfirmBtn.m_BtnID1 = 2;
		this.ConfirmBtn.m_Handler = this;
		this.ResearchFull = child.GetChild(7);
		this.BtnTitleText[0] = this.ConfirmTrans.GetChild(1).GetComponent<UIText>();
		this.BtnTitleText[0].font = ttffont;
		this.BtnTitleText[0].text = DataManager.Instance.mStringTable.GetStringByID(5014u);
		this.BtnTitleText[1] = child.GetChild(7).GetChild(0).GetComponent<UIText>();
		this.BtnTitleText[1].font = ttffont;
		this.BtnTitleText[1].text = DataManager.Instance.mStringTable.GetStringByID(5015u);
		this.UpdateTechInfo();
		this.SetActive(true);
	}

	// Token: 0x06002040 RID: 8256 RVA: 0x003D2DE0 File Offset: 0x003D0FE0
	public void UpdateTechInfo()
	{
		DataManager instance = DataManager.Instance;
		byte b = 0;
		byte b2 = 0;
		TechDataTbl recordByKey = DataManager.Instance.TechData.GetRecordByKey((ushort)this.TechID);
		byte techLevel = instance.GetTechLevel(recordByKey.TechID);
		this.TechName.text = instance.mStringTable.GetStringByID((uint)recordByKey.TechName);
		float num = 173.8f / (float)recordByKey.LevelMax;
		Vector2 sizeDelta = this.DegreeRect.sizeDelta;
		sizeDelta.x = num * (float)techLevel;
		this.DegreeRect.sizeDelta = sizeDelta;
		this.LevelStr.ClearString();
		this.LevelStr.IntToFormat((long)techLevel, 1, false);
		this.LevelStr.IntToFormat((long)recordByKey.LevelMax, 1, false);
		if (GUIManager.Instance.IsArabic)
		{
			this.LevelStr.AppendFormat("{1}/{0}");
		}
		else
		{
			this.LevelStr.AppendFormat("{0}/{1}");
		}
		this.LevelText.text = this.LevelStr.ToString();
		this.LevelText.SetAllDirty();
		this.LevelText.cachedTextGenerator.Invalidate();
		this.GraphicID = recordByKey.Graphic;
		if (GUIManager.Instance.TechMaterial == null)
		{
			this.TechImage.enabled = false;
		}
		else
		{
			this.TechImage.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
			this.TechImage.material = GUIManager.Instance.TechMaterial;
			this.TechImage.enabled = true;
		}
		this.EffectStr.ClearString();
		this.EffectNextStr.ClearString();
		this.ContentStr.ClearString();
		uint num2 = 0u;
		byte level = Math.Max(1, techLevel);
		TechLevelTbl techLevelTbl;
		if (instance.GetTechLevelupData(out techLevelTbl, (ushort)this.TechID, level))
		{
			if (techLevel > 0)
			{
				num2 += techLevelTbl.EffectVal;
			}
			CString cstring = StringManager.Instance.StaticString1024();
			if (techLevelTbl.Effect <= 1000)
			{
				if (num2 > 0u)
				{
					GameConstants.GetEffectValue(cstring, techLevelTbl.Effect, 0u, 6, num2);
				}
			}
			else if (techLevel > 0)
			{
				GameConstants.GetEffectValue(cstring, techLevelTbl.Effect, 0u, 7, num2);
			}
			GameConstants.GetEffectValue(this.ContentStr, techLevelTbl.Effect, num2, 0, 0f);
			b = (byte)cstring[0];
			this.EffectStr.StringToFormat(cstring);
			this.EffectStr.AppendFormat(instance.mStringTable.GetStringByID(5012u));
			this.EffectText.text = this.EffectStr.ToString();
			this.EffectText.SetAllDirty();
			this.EffectText.cachedTextGenerator.Invalidate();
			this.ContText.text = this.ContentStr.ToString();
			this.ContText.SetAllDirty();
			this.ContText.cachedTextGenerator.Invalidate();
		}
		if (techLevel < recordByKey.LevelMax && instance.GetTechLevelupData(out techLevelTbl, (ushort)this.TechID, techLevel + 1))
		{
			num2 = techLevelTbl.EffectVal - num2;
			CString cstring2 = StringManager.Instance.StaticString1024();
			if (techLevelTbl.Effect <= 1000)
			{
				GameConstants.GetEffectValue(cstring2, techLevelTbl.Effect, 0u, 6, num2);
			}
			else
			{
				GameConstants.GetEffectValue(cstring2, techLevelTbl.Effect, 0u, 7, num2);
			}
			GameConstants.GetEffectValue(this.ContentStr, techLevelTbl.Effect, num2, 0, 0f);
			this.ContText.text = this.ContentStr.ToString();
			this.ContText.SetAllDirty();
			this.ContText.cachedTextGenerator.Invalidate();
			b2 = (byte)cstring2[0];
			this.EffectNextStr.StringToFormat(cstring2);
			this.EffectNextStr.AppendFormat(instance.mStringTable.GetStringByID(5013u));
			this.EffectNextText.text = this.EffectNextStr.ToString();
			this.EffectNextText.SetAllDirty();
			this.EffectNextText.cachedTextGenerator.Invalidate();
			this.ConfirmTrans.gameObject.SetActive(true);
			this.ResearchFull.gameObject.SetActive(false);
			this.DegreeRect.gameObject.SetActive(true);
			this.FullFrame.gameObject.SetActive(false);
			this.Frame.gameObject.SetActive(true);
		}
		else
		{
			this.EffectNextText.text = string.Empty;
			this.ConfirmTrans.gameObject.SetActive(false);
			this.ResearchFull.gameObject.SetActive(true);
			this.DegreeRect.gameObject.SetActive(false);
			this.FullFrame.gameObject.SetActive(true);
			this.Frame.gameObject.SetActive(false);
		}
		byte b3 = instance.CheckTechState((ushort)this.TechID);
		this.ConfirmBtn.m_BtnID2 = this.TechID;
		this.ConfirmBtn.m_BtnID3 = (int)b3;
		if (b == 0)
		{
			this.EffectRect.gameObject.SetActive(false);
		}
		else
		{
			this.EffectRect.gameObject.SetActive(true);
			Vector2 anchoredPosition = this.EffectRect.anchoredPosition;
			if (b2 == 0)
			{
				anchoredPosition.y = -281f;
			}
			else
			{
				anchoredPosition.y = -269f;
			}
			this.EffectRect.anchoredPosition = anchoredPosition;
		}
		if (b2 == 0)
		{
			this.EffectNextText.gameObject.SetActive(false);
		}
		else
		{
			this.EffectNextText.gameObject.SetActive(true);
			Vector2 anchoredPosition2 = this.EffectNextText.rectTransform.anchoredPosition;
			if (b == 0)
			{
				anchoredPosition2.y = -280f;
			}
			else
			{
				anchoredPosition2.y = -297f;
			}
			this.EffectNextText.rectTransform.anchoredPosition = anchoredPosition2;
		}
		if ((b3 & 1) > 0)
		{
			if ((b3 & 2) == 0)
			{
				this.LockPanel.gameObject.SetActive(true);
				this.Lock.gameObject.SetActive(true);
				this.Lock1.gameObject.SetActive(false);
			}
			else
			{
				this.Lock.gameObject.SetActive(false);
				this.Lock1.gameObject.SetActive(true);
				this.LockPanel.gameObject.SetActive(false);
			}
		}
		else
		{
			this.Lock.gameObject.SetActive(false);
			this.LockPanel.gameObject.SetActive(false);
			this.Lock1.gameObject.SetActive(false);
		}
		if (GUIManager.Instance.GuideParm1 == 3 && this.TechID == (int)GUIManager.Instance.GuideParm2)
		{
			GUIManager.Instance.GuideArrow_Position(new Vector3(0f, -132.88f, 0f), ArrowDirect.Ar_Up);
		}
	}

	// Token: 0x06002041 RID: 8257 RVA: 0x003D34C8 File Offset: 0x003D16C8
	public void SetActive(bool bActive)
	{
		this.ThisTransform.gameObject.SetActive(bActive);
	}

	// Token: 0x06002042 RID: 8258 RVA: 0x003D34DC File Offset: 0x003D16DC
	public void TextRefresh()
	{
		this.TechName.enabled = false;
		this.LevelText.enabled = false;
		this.EffectText.enabled = false;
		this.EffectNextText.enabled = false;
		this.ContText.enabled = false;
		this.BtnTitleText[0].enabled = false;
		this.BtnTitleText[1].enabled = false;
		this.TechName.enabled = true;
		this.LevelText.enabled = true;
		this.EffectText.enabled = true;
		this.EffectNextText.enabled = true;
		this.ContText.enabled = true;
		this.BtnTitleText[0].enabled = true;
		this.BtnTitleText[1].enabled = true;
	}

	// Token: 0x06002043 RID: 8259 RVA: 0x003D359C File Offset: 0x003D179C
	public void UpdateUI(int arge1, int arge2)
	{
		this.TechID = arge1;
		this.UpdateTechInfo();
		this.SetActive(true);
	}

	// Token: 0x06002044 RID: 8260 RVA: 0x003D35B4 File Offset: 0x003D17B4
	public void OnDestroy()
	{
		StringManager.Instance.DeSpawnString(this.LevelStr);
		StringManager.Instance.DeSpawnString(this.EffectStr);
		StringManager.Instance.DeSpawnString(this.EffectNextStr);
		StringManager.Instance.DeSpawnString(this.ContentStr);
	}

	// Token: 0x06002045 RID: 8261 RVA: 0x003D3608 File Offset: 0x003D1808
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
		{
			this.SetCreatScrollDelayFlage();
			GameConstants.GetBytes((ushort)this.TechID, GUIManager.Instance.TechSaved, 6);
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_Information, -1, this.TechID, false);
			break;
		}
		case 1:
			GameConstants.GetBytes(0, GUIManager.Instance.TechSaved, 6);
			GUIManager.Instance.HideArrow(false);
			this.SetActive(false);
			break;
		case 2:
		{
			if (GUIManager.Instance.GuideParm1 == 3 && this.TechID == (int)GUIManager.Instance.GuideParm2)
			{
				GUIManager.Instance.HideArrow(false);
				GUIManager.Instance.GuideParm1 = 3;
				GUIManager.Instance.GuideParm2 = (ushort)this.TechID;
			}
			GameConstants.GetBytes(0, GUIManager.Instance.TechSaved, 6);
			Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door2 != null)
			{
				door2.OpenMenu(EGUIWindow.UI_TechUpgrade, sender.m_BtnID2, 0, false);
			}
			GameConstants.GetBytes(0, GUIManager.Instance.TechSaved, 6);
			break;
		}
		}
	}

	// Token: 0x06002046 RID: 8262 RVA: 0x003D3740 File Offset: 0x003D1940
	public void SetCreatScrollDelayFlage()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_WindowStack.Count > 0)
		{
			for (int i = door.m_WindowStack.Count - 1; i >= 0; i--)
			{
				GUIWindowStackData value = door.m_WindowStack[i];
				if (value.m_eWindow == EGUIWindow.UI_TechTree)
				{
					value.m_Arg1 |= 32768;
					door.m_WindowStack[i] = value;
					break;
				}
			}
		}
	}

	// Token: 0x040065AF RID: 26031
	private const float MaxWidth = 173.8f;

	// Token: 0x040065B0 RID: 26032
	public int TechID;

	// Token: 0x040065B1 RID: 26033
	public Image TechImage;

	// Token: 0x040065B2 RID: 26034
	private UIText TechName;

	// Token: 0x040065B3 RID: 26035
	private UIText LevelText;

	// Token: 0x040065B4 RID: 26036
	private UIText EffectText;

	// Token: 0x040065B5 RID: 26037
	private UIText EffectNextText;

	// Token: 0x040065B6 RID: 26038
	private UIText ContText;

	// Token: 0x040065B7 RID: 26039
	private UIText[] BtnTitleText = new UIText[2];

	// Token: 0x040065B8 RID: 26040
	private Transform Lock;

	// Token: 0x040065B9 RID: 26041
	private Transform Lock1;

	// Token: 0x040065BA RID: 26042
	private Transform LockPanel;

	// Token: 0x040065BB RID: 26043
	private Transform FullFrame;

	// Token: 0x040065BC RID: 26044
	private Transform Frame;

	// Token: 0x040065BD RID: 26045
	private Transform ResearchFull;

	// Token: 0x040065BE RID: 26046
	private Transform ConfirmTrans;

	// Token: 0x040065BF RID: 26047
	private RectTransform DegreeRect;

	// Token: 0x040065C0 RID: 26048
	private RectTransform EffectRect;

	// Token: 0x040065C1 RID: 26049
	private CString LevelStr;

	// Token: 0x040065C2 RID: 26050
	private CString EffectStr;

	// Token: 0x040065C3 RID: 26051
	private CString EffectNextStr;

	// Token: 0x040065C4 RID: 26052
	private CString ContentStr;

	// Token: 0x040065C5 RID: 26053
	public UIButton ConfirmBtn;

	// Token: 0x040065C6 RID: 26054
	public ushort GraphicID;

	// Token: 0x040065C7 RID: 26055
	public Transform ThisTransform;

	// Token: 0x02000692 RID: 1682
	private enum MainControl
	{
		// Token: 0x040065C9 RID: 26057
		Background,
		// Token: 0x040065CA RID: 26058
		Info,
		// Token: 0x040065CB RID: 26059
		Skill,
		// Token: 0x040065CC RID: 26060
		Price,
		// Token: 0x040065CD RID: 26061
		Next,
		// Token: 0x040065CE RID: 26062
		Content,
		// Token: 0x040065CF RID: 26063
		Button,
		// Token: 0x040065D0 RID: 26064
		ResearchFull
	}

	// Token: 0x02000693 RID: 1683
	private enum ClickType
	{
		// Token: 0x040065D2 RID: 26066
		Info,
		// Token: 0x040065D3 RID: 26067
		Close,
		// Token: 0x040065D4 RID: 26068
		Confirm
	}
}
