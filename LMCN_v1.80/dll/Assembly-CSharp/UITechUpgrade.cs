using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000697 RID: 1687
public class UITechUpgrade : GUIWindow
{
	// Token: 0x0600205B RID: 8283 RVA: 0x003D4AB0 File Offset: 0x003D2CB0
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		this.TechID = (byte)arg1;
		GUIManager.Instance.SetTalentIconSprite("UITechIcon", this.m_eWindow);
		TechDataTbl recordByKey = instance.TechData.GetRecordByKey((ushort)this.TechID);
		Font ttffont = instance2.GetTTFFont();
		byte techLevel = instance.GetTechLevel((ushort)this.TechID);
		if (DataManager.StageDataController.StageRecord[2] < 8)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		}
		else
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
		}
		this.LvStr = StringManager.Instance.SpawnString(30);
		this.TechIcon = base.transform.GetChild(0).GetChild(0).GetComponent<Image>();
		this.TechIcon.enabled = false;
		this.GraphicID = recordByKey.Graphic;
		this.DegreeRect = base.transform.GetChild(0).GetChild(3).GetComponent<RectTransform>();
		float num = 173.8f / (float)recordByKey.LevelMax;
		Vector2 sizeDelta = this.DegreeRect.sizeDelta;
		sizeDelta.x = (float)techLevel * num;
		this.DegreeRect.sizeDelta = sizeDelta;
		this.LvStr.ClearString();
		this.LvStr.IntToFormat((long)techLevel, 1, false);
		this.LvStr.IntToFormat((long)recordByKey.LevelMax, 1, false);
		if (GUIManager.Instance.IsArabic)
		{
			this.LvStr.AppendFormat("{1}/{0}");
		}
		else
		{
			this.LvStr.AppendFormat("{0}/{1}");
		}
		this.LvText = base.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
		this.LvText.font = ttffont;
		this.LvText.text = this.LvStr.ToString();
		this.buildWin = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.buildWin.InitTechWindow(this.TechID, techLevel);
		base.transform.GetChild(0).SetAsLastSibling();
		if (GUIManager.Instance.IsArabic)
		{
			this.TechIcon.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		if (instance2.GuideParm1 == 3 && (ushort)this.TechID == instance2.GuideParm2)
		{
			instance2.GuideArrow((RectTransform)this.buildWin.upgradeBtn.transform, ArrowDirect.Ar_Up, 0f);
		}
		this.TechIcon.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
		this.TechIcon.material = GUIManager.Instance.TechMaterial;
		if (this.TechIcon.sprite != null)
		{
			this.TechIcon.enabled = true;
		}
		NewbieManager.CheckTeach(ETeachKind.COLLEGE, this, false);
	}

	// Token: 0x0600205C RID: 8284 RVA: 0x003D4D88 File Offset: 0x003D2F88
	public override void OnClose()
	{
		if (this.buildWin != null)
		{
			this.buildWin.DestroyBuildingWindow();
		}
		this.buildWin = null;
		StringManager.Instance.DeSpawnString(this.LvStr);
		NewbieManager.CheckTeach(ETeachKind.COLLEGE, this, false);
	}

	// Token: 0x0600205D RID: 8285 RVA: 0x003D4DD4 File Offset: 0x003D2FD4
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_QBarTime:
		case NetworkNews.Refresh_AttribEffectVal:
			if (this.buildWin)
			{
				this.buildWin.MyUpdate(0, false);
			}
			break;
		case NetworkNews.Refresh_Technology:
			this.UpdateTechInfo();
			if (this.buildWin)
			{
				this.buildWin.MyUpdate(meg[1], false);
			}
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.buildWin.Refresh_FontTexture();
				this.LvText.enabled = false;
				this.LvText.enabled = true;
			}
			break;
		}
	}

	// Token: 0x0600205E RID: 8286 RVA: 0x003D4E80 File Offset: 0x003D3080
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == -1)
		{
			this.TechIcon.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
			this.TechIcon.material = GUIManager.Instance.TechMaterial;
			this.TechIcon.enabled = true;
		}
	}

	// Token: 0x0600205F RID: 8287 RVA: 0x003D4ED0 File Offset: 0x003D30D0
	private void UpdateTechInfo()
	{
		DataManager instance = DataManager.Instance;
		TechDataTbl recordByKey = instance.TechData.GetRecordByKey((ushort)this.TechID);
		byte techLevel = instance.GetTechLevel((ushort)this.TechID);
		this.LvStr.ClearString();
		this.LvStr.IntToFormat((long)techLevel, 1, false);
		this.LvStr.IntToFormat((long)recordByKey.LevelMax, 1, false);
		if (GUIManager.Instance.IsArabic)
		{
			this.LvStr.AppendFormat("{1}/{0}");
		}
		else
		{
			this.LvStr.AppendFormat("{0}/{1}");
		}
		this.LvText.text = this.LvStr.ToString();
		this.LvText.SetAllDirty();
		this.LvText.cachedTextGenerator.Invalidate();
		if (techLevel == recordByKey.LevelMax)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.CloseMenu(false);
			}
		}
		else
		{
			float num = 173.8f / (float)recordByKey.LevelMax;
			Vector2 sizeDelta = this.DegreeRect.sizeDelta;
			sizeDelta.x = (float)techLevel * num;
			this.DegreeRect.sizeDelta = sizeDelta;
		}
	}

	// Token: 0x040065F4 RID: 26100
	private byte TechID;

	// Token: 0x040065F5 RID: 26101
	public BuildingWindow buildWin;

	// Token: 0x040065F6 RID: 26102
	private UIText LvText;

	// Token: 0x040065F7 RID: 26103
	private CString LvStr;

	// Token: 0x040065F8 RID: 26104
	private RectTransform DegreeRect;

	// Token: 0x040065F9 RID: 26105
	private Image TechIcon;

	// Token: 0x040065FA RID: 26106
	private ushort GraphicID;

	// Token: 0x02000698 RID: 1688
	private enum SkillControl
	{
		// Token: 0x040065FC RID: 26108
		SkillIcon,
		// Token: 0x040065FD RID: 26109
		Frame,
		// Token: 0x040065FE RID: 26110
		FullFrame,
		// Token: 0x040065FF RID: 26111
		Degree,
		// Token: 0x04006600 RID: 26112
		LvText
	}
}
