using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004C4 RID: 1220
public class UIAllianceMatchInfo : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x060018B8 RID: 6328 RVA: 0x00298224 File Offset: 0x00296424
	public override void OnOpen(int arg1, int arg2)
	{
		this.GM = GUIManager.Instance;
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.GM.AddSpriteAsset(this.AssName);
		Material material = this.GM.LoadMaterial(this.AssName, "UI_act_content_m");
		Image component = base.transform.GetChild(0).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_act_box_002");
		component.material = material;
		component = base.transform.GetChild(1).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_act_box_009");
		component.material = material;
		this.m_TitleText = base.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_TitleText.font = this.GM.GetTTFFont();
		this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID(this.TitleStrID);
		component = base.transform.GetChild(2).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_act_alpha_001");
		component.material = material;
		this.m_ScrollPanel = base.transform.GetChild(2).GetComponent<ScrollPanel>();
		this.m_GetHightText = base.transform.GetChild(4).GetComponent<UIText>();
		this.m_GetHightText.font = this.GM.GetTTFFont();
		component = base.transform.GetChild(5).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && component)
		{
			component.enabled = false;
		}
		this.m_Exit = base.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
		this.m_Exit.m_BtnID1 = 0;
		this.m_Exit.m_Handler = this;
		this.m_Exit.image.sprite = this.door.LoadSprite("UI_main_close");
		this.m_Exit.image.material = this.door.LoadMaterial();
		this.SetData();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		this.bOpen = true;
	}

	// Token: 0x060018B9 RID: 6329 RVA: 0x0029849C File Offset: 0x0029669C
	public override void OnClose()
	{
		if (this.m_PanelObjects != null)
		{
			for (int i = 0; i < 20; i++)
			{
				this.m_PanelObjects[i].Destroy();
			}
		}
		this.GM.RemoveSpriteAsset(this.AssName);
	}

	// Token: 0x060018BA RID: 6330 RVA: 0x002984EC File Offset: 0x002966EC
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x060018BB RID: 6331 RVA: 0x00298518 File Offset: 0x00296718
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < this.m_PanelObjects.Length && panelObjectIdx >= 0)
		{
			if (this.m_PanelObjects[panelObjectIdx].InfoText == null)
			{
				this.m_PanelObjects[panelObjectIdx].InfoText = item.transform.GetChild(0).GetComponent<UIText>();
				this.m_PanelObjects[panelObjectIdx].InfoText.font = GUIManager.Instance.GetTTFFont();
			}
			this.SetScrollItem(dataIdx, panelObjectIdx);
		}
	}

	// Token: 0x060018BC RID: 6332 RVA: 0x002985A0 File Offset: 0x002967A0
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x060018BD RID: 6333 RVA: 0x002985A4 File Offset: 0x002967A4
	public void OnButtonClick(UIButton sender)
	{
		if (!this.bOpen)
		{
			return;
		}
		this.door.CloseMenu(false);
	}

	// Token: 0x060018BE RID: 6334 RVA: 0x002985C0 File Offset: 0x002967C0
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x060018BF RID: 6335 RVA: 0x002985C4 File Offset: 0x002967C4
	private void SetData()
	{
		if (this.m_Data != null)
		{
			int num = 0;
			while ((long)num < 38L && num < this.m_StrIDs.Length)
			{
				this.m_Data[num].StrID = this.m_StrIDs[num];
				this.m_Data[num].Type = ((this.m_StrIDs[num] != 0u) ? UIAllianceMatchInfo.MatchInfoType.StrInfo : UIAllianceMatchInfo.MatchInfoType.None);
				this.m_Data[num].TextHeight = this.GetPreferredHeight(this.m_StrIDs[num]);
				num++;
			}
			if (this.m_ScrollPanel != null)
			{
				List<float> list = new List<float>();
				for (int i = 0; i < this.m_Data.Length; i++)
				{
					list.Add(this.m_Data[i].TextHeight);
				}
				this.m_ScrollPanel.IntiScrollPanel(509f, 0f, 5f, list, 20, this);
			}
		}
		if (this.m_GetHightText != null)
		{
			this.m_GetHightText.gameObject.SetActive(false);
		}
	}

	// Token: 0x060018C0 RID: 6336 RVA: 0x002986E4 File Offset: 0x002968E4
	private float GetPreferredHeight(uint StrID)
	{
		if (this.m_GetHightText != null)
		{
			this.m_GetHightText.text = DataManager.Instance.mStringTable.GetStringByID(StrID);
			return this.m_GetHightText.preferredHeight;
		}
		return 0f;
	}

	// Token: 0x060018C1 RID: 6337 RVA: 0x00298730 File Offset: 0x00296930
	private void SetScrollItem(int dataIdx, int panelObjectIdx)
	{
		if (dataIdx < this.m_Data.Length && dataIdx >= 0)
		{
			this.m_PanelObjects[panelObjectIdx].SetTextByStrID(this.m_Data[dataIdx]);
		}
	}

	// Token: 0x060018C2 RID: 6338 RVA: 0x0029876C File Offset: 0x0029696C
	private void Refresh_FontTexture()
	{
		if (!this.bOpen)
		{
			return;
		}
		if (this.m_PanelObjects != null)
		{
			for (int i = 0; i < 20; i++)
			{
				if (this.m_PanelObjects[i].InfoText != null && this.m_PanelObjects[i].InfoText.enabled)
				{
					this.m_PanelObjects[i].InfoText.enabled = false;
					this.m_PanelObjects[i].InfoText.enabled = true;
				}
			}
		}
		if (this.m_TitleText != null && this.m_TitleText.enabled)
		{
			this.m_TitleText.enabled = false;
			this.m_TitleText.enabled = true;
		}
	}

	// Token: 0x040048ED RID: 18669
	private const int MaxPanelObject = 20;

	// Token: 0x040048EE RID: 18670
	private const uint MaxData = 38u;

	// Token: 0x040048EF RID: 18671
	private UIAllianceMatchInfo.sMatchInfo[] m_PanelObjects = new UIAllianceMatchInfo.sMatchInfo[20];

	// Token: 0x040048F0 RID: 18672
	private UIAllianceMatchInfo.sMatchInfoData[] m_Data = new UIAllianceMatchInfo.sMatchInfoData[38];

	// Token: 0x040048F1 RID: 18673
	private uint TitleStrID = 17040u;

	// Token: 0x040048F2 RID: 18674
	private uint[] m_StrIDs = new uint[]
	{
		17076u,
		0u,
		17041u,
		17042u,
		17043u,
		17044u,
		17045u,
		0u,
		17046u,
		17047u,
		17048u,
		17049u,
		17050u,
		17070u,
		0u,
		17051u,
		17052u,
		17053u,
		0u,
		17054u,
		17055u,
		17056u,
		17057u,
		0u,
		17058u,
		17059u,
		17060u,
		17061u,
		17062u,
		0u,
		17063u,
		17064u,
		17065u,
		0u,
		17066u,
		17067u,
		17068u,
		17069u
	};

	// Token: 0x040048F3 RID: 18675
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040048F4 RID: 18676
	private UIButton m_Exit;

	// Token: 0x040048F5 RID: 18677
	private UIText m_TitleText;

	// Token: 0x040048F6 RID: 18678
	private UIText m_GetHightText;

	// Token: 0x040048F7 RID: 18679
	private Door door;

	// Token: 0x040048F8 RID: 18680
	private GUIManager GM;

	// Token: 0x040048F9 RID: 18681
	private string AssName = "UIActivity3";

	// Token: 0x040048FA RID: 18682
	private bool bOpen;

	// Token: 0x020004C5 RID: 1221
	private enum MatchInfoType
	{
		// Token: 0x040048FC RID: 18684
		None,
		// Token: 0x040048FD RID: 18685
		StrInfo,
		// Token: 0x040048FE RID: 18686
		Max
	}

	// Token: 0x020004C6 RID: 1222
	private struct sMatchInfoData
	{
		// Token: 0x060018C3 RID: 6339 RVA: 0x00298844 File Offset: 0x00296A44
		public void Init()
		{
			this.Type = UIAllianceMatchInfo.MatchInfoType.StrInfo;
			this.StrID = 0u;
			this.TextHeight = 0f;
		}

		// Token: 0x040048FF RID: 18687
		public UIAllianceMatchInfo.MatchInfoType Type;

		// Token: 0x04004900 RID: 18688
		public uint StrID;

		// Token: 0x04004901 RID: 18689
		public float TextHeight;
	}

	// Token: 0x020004C7 RID: 1223
	private struct sMatchInfo
	{
		// Token: 0x060018C4 RID: 6340 RVA: 0x00298860 File Offset: 0x00296A60
		public void Init()
		{
			this.InfoText = null;
			this.Str = StringManager.Instance.SpawnString(30);
		}

		// Token: 0x060018C5 RID: 6341 RVA: 0x0029887C File Offset: 0x00296A7C
		public void SetTextByStrID(UIAllianceMatchInfo.sMatchInfoData data)
		{
			if (data.Type == UIAllianceMatchInfo.MatchInfoType.StrInfo)
			{
				Vector2 sizeDelta = this.InfoText.rectTransform.sizeDelta;
				sizeDelta.y = data.TextHeight;
				this.InfoText.rectTransform.sizeDelta = sizeDelta;
				this.InfoText.text = DataManager.Instance.mStringTable.GetStringByID(data.StrID);
			}
			else
			{
				this.InfoText.text = string.Empty;
			}
		}

		// Token: 0x060018C6 RID: 6342 RVA: 0x002988FC File Offset: 0x00296AFC
		public void Destroy()
		{
			if (this.Str != null)
			{
				StringManager.Instance.DeSpawnString(this.Str);
			}
		}

		// Token: 0x04004902 RID: 18690
		public UIText InfoText;

		// Token: 0x04004903 RID: 18691
		public CString Str;
	}

	// Token: 0x020004C8 RID: 1224
	private enum eUIAllianceMatchInfo
	{
		// Token: 0x04004905 RID: 18693
		BGPanel,
		// Token: 0x04004906 RID: 18694
		Title,
		// Token: 0x04004907 RID: 18695
		ScrollPanel,
		// Token: 0x04004908 RID: 18696
		Item,
		// Token: 0x04004909 RID: 18697
		HeightText,
		// Token: 0x0400490A RID: 18698
		Exit
	}
}
