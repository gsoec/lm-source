using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000667 RID: 1639
public class UISuitBuilding : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x170000BC RID: 188
	// (get) Token: 0x06001F85 RID: 8069 RVA: 0x003C24CC File Offset: 0x003C06CC
	public ScrollPanel scrollPanel
	{
		get
		{
			return this.m_ScrollPanel;
		}
	}

	// Token: 0x06001F86 RID: 8070 RVA: 0x003C24D4 File Offset: 0x003C06D4
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_EmptyString = string.Empty;
		this.sb = new StringBuilder();
		for (int i = 0; i < 3; i++)
		{
			this.m_BuildIdList[i] = new List<ushort>();
		}
		this.m_BuildKindID = (ushort)arg1;
		this.m_ExitBtn = base.transform.GetChild(7).GetComponent<UIButton>();
		this.m_ExitBtn.m_BtnID1 = 1;
		this.m_ExitBtn.m_Handler = this;
		this.m_TitleText = base.transform.GetChild(6).GetChild(0).GetComponent<UIText>();
		this.m_TitleText.font = GUIManager.Instance.GetTTFFont();
		this.m_ScrollPanel = base.transform.GetChild(2).GetComponent<ScrollPanel>();
		this.m_ArrowScrollPanel = base.transform.GetChild(3).GetComponent<ScrollPanel>();
		this.m_BuildKind = DataManager.Instance.BuildManorData.GetRecordByKey(this.m_BuildKindID).Kind;
		this.SetScrollPanel((int)this.m_BuildKind);
		this.bInitScrollPanel = true;
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
		NewbieManager.CheckNewbie(this);
		this.m_GuideBuildID = GUIManager.Instance.BuildingData.GuideBuildID;
		if (this.m_GuideBuildID != 0)
		{
			for (int j = 0; j < this.m_ItemDatas.Length; j++)
			{
				if (this.m_ItemDatas[j].BuildID == this.m_GuideBuildID)
				{
					this.SetArrow(true, j);
					this.m_ScrollPanel.GoTo(j);
					this.m_ArrowScrollPanel.GoTo(j);
				}
			}
		}
		List<float> list = new List<float>();
		for (int k = 0; k < this.m_ItemDatas.Length; k++)
		{
			list.Add(127f);
		}
		this.m_ScrollPanel.AddNewDataHeight(list, false, true);
		this.m_ArrowScrollPanel.AddNewDataHeight(list, false, true);
	}

	// Token: 0x06001F87 RID: 8071 RVA: 0x003C26B8 File Offset: 0x003C08B8
	public override void OnClose()
	{
		this.m_ExitBtn = null;
		this.m_TitleText = null;
		this.m_ScrollPanel = null;
		this.m_TextObject1s = null;
		this.m_TextObject2s = null;
		this.m_TextObject3s = null;
		this.m_TextObject4s = null;
		this.m_ImageObjects = null;
		this.m_ItemDatas = null;
		this.sb = null;
		for (int i = 0; i < 3; i++)
		{
			this.m_BuildIdList[i].Clear();
			this.m_BuildIdList[i] = null;
		}
		this.m_GuideBuildID = 0;
	}

	// Token: 0x06001F88 RID: 8072 RVA: 0x003C273C File Offset: 0x003C093C
	public override void UpdateUI(int arg1, int arg2)
	{
		this.SetScrollPanel((int)this.m_BuildKind);
	}

	// Token: 0x06001F89 RID: 8073 RVA: 0x003C274C File Offset: 0x003C094C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x06001F8A RID: 8074 RVA: 0x003C2778 File Offset: 0x003C0978
	public void Refresh_FontTexture()
	{
		if (this.m_TitleText != null && this.m_TitleText.enabled)
		{
			this.m_TitleText.enabled = false;
			this.m_TitleText.enabled = true;
		}
		for (int i = 0; i < this.m_MaxObjCount; i++)
		{
			if (this.m_TextObject1s[i] != null && this.m_TextObject1s[i].enabled)
			{
				this.m_TextObject1s[i].enabled = false;
				this.m_TextObject1s[i].enabled = true;
			}
			if (this.m_TextObject2s[i] != null && this.m_TextObject2s[i].enabled)
			{
				this.m_TextObject2s[i].enabled = false;
				this.m_TextObject2s[i].enabled = true;
			}
			if (this.m_TextObject3s[i] != null && this.m_TextObject3s[i].enabled)
			{
				this.m_TextObject3s[i].enabled = false;
				this.m_TextObject3s[i].enabled = true;
			}
			if (this.m_TextObject4s[i] != null && this.m_TextObject4s[i].enabled)
			{
				this.m_TextObject4s[i].enabled = false;
				this.m_TextObject4s[i].enabled = true;
			}
		}
	}

	// Token: 0x06001F8B RID: 8075 RVA: 0x003C28DC File Offset: 0x003C0ADC
	private void Update()
	{
		if (this.m_ArrowScrollPanel.enabled)
		{
			this.m_ArrowContent.anchoredPosition = this.m_ScrollContent.anchoredPosition;
		}
	}

	// Token: 0x06001F8C RID: 8076 RVA: 0x003C2910 File Offset: 0x003C0B10
	private int SetSortData(int buildManorKind)
	{
		int num = 0;
		DataManager instance = DataManager.Instance;
		for (int i = 0; i < 3; i++)
		{
			this.m_BuildIdList[i].Clear();
		}
		int tableCount = instance.BuildsTypeData.TableCount;
		ushort num2 = 0;
		while ((int)num2 < tableCount)
		{
			BuildTypeData recordByIndex = instance.BuildsTypeData.GetRecordByIndex((int)num2);
			if (buildManorKind == (int)recordByIndex.Kind)
			{
				byte b = GUIManager.Instance.BuildingData.CheckLevelupRule(recordByIndex.BuildID, 1);
				if (b < 3 && b >= 0)
				{
					this.m_BuildIdList[(int)b].Add(recordByIndex.BuildID);
					num++;
				}
			}
			num2 += 1;
		}
		return num;
	}

	// Token: 0x06001F8D RID: 8077 RVA: 0x003C29CC File Offset: 0x003C0BCC
	private void SetScrollPanel(int buildManorKind)
	{
		ushort[] array = new ushort[]
		{
			0,
			3811,
			3812,
			3813,
			3813,
			3813,
			12098
		};
		this.m_MaxItemDataCount = 0;
		DataManager instance = DataManager.Instance;
		int tableCount = instance.BuildsTypeData.TableCount;
		int num = 0;
		List<float> list = new List<float>();
		if (buildManorKind >= 0 && buildManorKind < array.Length)
		{
			this.m_TitleText.text = instance.mStringTable.GetStringByID((uint)array[buildManorKind]);
		}
		this.m_MaxItemDataCount = this.SetSortData(buildManorKind);
		this.m_ItemDatas = new SuitBuildingItem[this.m_MaxItemDataCount];
		for (int i = 0; i < 3; i++)
		{
			int count = this.m_BuildIdList[i].Count;
			for (int j = 0; j < count; j++)
			{
				ushort inKey = this.m_BuildIdList[i][j];
				BuildTypeData recordByKey = instance.BuildsTypeData.GetRecordByKey(inKey);
				this.sb.Length = 0;
				SuitBuildingItem suitBuildingItem = default(SuitBuildingItem);
				suitBuildingItem.StrTexts = new string[4];
				suitBuildingItem.StrTexts[0] = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.NameID);
				suitBuildingItem.StrTexts[1] = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.StringID);
				switch (i)
				{
				case 0:
					suitBuildingItem.StrTexts[2] = this.m_EmptyString;
					break;
				case 1:
					suitBuildingItem.StrTexts[2] = DataManager.Instance.mStringTable.GetStringByID(3815u);
					break;
				case 2:
					suitBuildingItem.StrTexts[2] = DataManager.Instance.mStringTable.GetStringByID(3816u);
					break;
				}
				this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3941u), GUIManager.Instance.BuildingData.GetBuildNumByID(recordByKey.BuildID));
				suitBuildingItem.StrTexts[3] = this.sb.ToString();
				suitBuildingItem.BuildID = recordByKey.BuildID;
				this.m_ItemDatas[num] = suitBuildingItem;
				num++;
				list.Add(127f);
			}
		}
		this.m_TextObject1s = new UIText[this.m_MaxObjCount];
		this.m_TextObject2s = new UIText[this.m_MaxObjCount];
		this.m_TextObject3s = new UIText[this.m_MaxObjCount];
		this.m_TextObject4s = new UIText[this.m_MaxObjCount];
		this.m_ImageObjects = new Image[this.m_MaxObjCount];
		this.m_ImageObjectsRt = new RectTransform[this.m_MaxObjCount];
		if (!this.bInitScrollPanel)
		{
			this.m_ArrowScrollPanel.IntiScrollPanel(561f, 2f, 5f, list, 5, this);
			this.m_ScrollPanel.IntiScrollPanel(561f, 2f, 5f, list, this.m_MaxObjCount, this);
			this.m_ArrowContent = base.transform.GetChild(3).GetChild(0).GetComponent<RectTransform>();
			this.m_ScrollContent = base.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>();
		}
		else
		{
			this.m_ArrowScrollPanel.AddNewDataHeight(list, true, true);
			this.m_ScrollPanel.AddNewDataHeight(list, true, true);
		}
	}

	// Token: 0x06001F8E RID: 8078 RVA: 0x003C2D20 File Offset: 0x003C0F20
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId == 0)
		{
			if (dataIdx < this.m_MaxItemDataCount)
			{
				if (this.m_ImageObjects[panelObjectIdx] == null)
				{
					this.m_ImageObjects[panelObjectIdx] = item.transform.GetChild(1).GetComponent<Image>();
					this.m_ImageObjectsRt[panelObjectIdx] = item.transform.GetChild(1).GetComponent<RectTransform>();
					this.m_TextObject1s[panelObjectIdx] = item.transform.GetChild(3).GetComponent<UIText>();
					this.m_TextObject1s[panelObjectIdx].font = GUIManager.Instance.GetTTFFont();
					this.m_TextObject2s[panelObjectIdx] = item.transform.GetChild(4).GetComponent<UIText>();
					this.m_TextObject2s[panelObjectIdx].font = GUIManager.Instance.GetTTFFont();
					this.m_TextObject3s[panelObjectIdx] = item.transform.GetChild(5).GetComponent<UIText>();
					this.m_TextObject3s[panelObjectIdx].font = GUIManager.Instance.GetTTFFont();
					this.m_TextObject4s[panelObjectIdx] = item.transform.GetChild(6).GetChild(0).GetComponent<UIText>();
					this.m_TextObject4s[panelObjectIdx].font = GUIManager.Instance.GetTTFFont();
					this.m_ImageObjects[panelObjectIdx].material = GUIManager.Instance.BuildingData.mapspriteManager.SpriteUIMaterial;
				}
				this.m_TextObject1s[panelObjectIdx].text = this.m_ItemDatas[dataIdx].StrTexts[0];
				this.m_TextObject2s[panelObjectIdx].text = this.m_ItemDatas[dataIdx].StrTexts[1];
				if (!this.m_ItemDatas[dataIdx].bCanBuild)
				{
					this.m_TextObject3s[panelObjectIdx].color = new Color(0.8f, 0.05f, 0.015f, 1f);
				}
				else
				{
					this.m_TextObject3s[panelObjectIdx].color = new Color(0.11f, 0.3f, 0.46f, 1f);
				}
				this.m_TextObject3s[panelObjectIdx].text = this.m_ItemDatas[dataIdx].StrTexts[2];
				if (this.m_BuildKind == 3)
				{
					this.m_TextObject4s[panelObjectIdx].transform.parent.gameObject.SetActive(false);
				}
				else
				{
					this.m_TextObject4s[panelObjectIdx].transform.parent.gameObject.SetActive(true);
				}
				this.m_TextObject4s[panelObjectIdx].text = this.m_ItemDatas[dataIdx].StrTexts[3];
				Sprite buildSprite = GUIManager.Instance.BuildingData.GetBuildSprite(this.m_ItemDatas[dataIdx].BuildID, 0);
				if (buildSprite != null)
				{
					this.m_ImageObjects[panelObjectIdx].sprite = buildSprite;
					float num = 88f / buildSprite.rect.size.y;
					this.m_ImageObjectsRt[panelObjectIdx].sizeDelta = new Vector2(num * buildSprite.rect.size.x, 88f);
					if (GUIManager.Instance.IsArabic)
					{
						Vector3 localScale = this.m_ImageObjects[panelObjectIdx].rectTransform.localScale;
						localScale.x = -1f;
						this.m_ImageObjects[panelObjectIdx].rectTransform.localScale = localScale;
					}
				}
			}
		}
		else if (panelId == 1)
		{
			if (dataIdx == this.m_ArrowIndx)
			{
				item.transform.GetChild(0).GetComponent<Image>().enabled = true;
			}
			else
			{
				item.transform.GetChild(0).GetComponent<Image>().enabled = false;
			}
		}
	}

	// Token: 0x06001F8F RID: 8079 RVA: 0x003C30B8 File Offset: 0x003C12B8
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (panelId == 0 && this.m_ItemDatas != null && dataIndex < this.m_ItemDatas.Length && dataIndex >= 0)
		{
			if (this.m_ItemDatas[dataIndex].BuildID == 6)
			{
				door.OpenMenu(EGUIWindow.UI_Barrack, (int)this.m_BuildKindID, 0, false);
			}
			else if (this.m_ItemDatas[dataIndex].BuildID == 7)
			{
				door.OpenMenu(EGUIWindow.UI_Hospital, (int)this.m_BuildKindID, 0, false);
			}
			else if (this.m_ItemDatas[dataIndex].BuildID == 12)
			{
				door.OpenMenu(EGUIWindow.UI_CityWall, (int)this.m_BuildKindID, 0, false);
			}
			else if (this.m_ItemDatas[dataIndex].BuildID == 19)
			{
				door.OpenMenu(EGUIWindow.UI_Altar, (int)this.m_BuildKindID, 0, true);
			}
			else if (this.m_ItemDatas[dataIndex].BuildID == 23)
			{
				door.OpenMenu(EGUIWindow.UI_PetTrainingCenter, (int)this.m_BuildKindID, 0, true);
			}
			else
			{
				door.OpenMenu(EGUIWindow.UIResourceBuilding, (int)this.m_BuildKindID, (int)this.m_ItemDatas[dataIndex].BuildID, false);
			}
		}
	}

	// Token: 0x06001F90 RID: 8080 RVA: 0x003C3204 File Offset: 0x003C1404
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID == 1)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.CloseMenu(false);
			}
		}
	}

	// Token: 0x06001F91 RID: 8081 RVA: 0x003C3250 File Offset: 0x003C1450
	private void SetArrow(bool bActive, int index = 0)
	{
		if (bActive)
		{
			this.m_ArrowIndx = index;
		}
		else
		{
			this.m_ArrowIndx = -1;
		}
		this.m_ArrowScrollPanel.gameObject.SetActive(bActive);
	}

	// Token: 0x06001F92 RID: 8082 RVA: 0x003C3288 File Offset: 0x003C1488
	public float ATween(float t, float b, float c, float d)
	{
		float num = (t /= d) * t;
		float num2 = num * t;
		return b + c * (num2 * num);
	}

	// Token: 0x040063AD RID: 25517
	private const int MaxSortType = 3;

	// Token: 0x040063AE RID: 25518
	private UIButton m_ExitBtn;

	// Token: 0x040063AF RID: 25519
	private UIText m_TitleText;

	// Token: 0x040063B0 RID: 25520
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040063B1 RID: 25521
	private ScrollPanel m_ArrowScrollPanel;

	// Token: 0x040063B2 RID: 25522
	private RectTransform m_ScrollContent;

	// Token: 0x040063B3 RID: 25523
	private RectTransform m_ArrowContent;

	// Token: 0x040063B4 RID: 25524
	private int m_ArrowIndx;

	// Token: 0x040063B5 RID: 25525
	private int m_MaxItemDataCount;

	// Token: 0x040063B6 RID: 25526
	private SuitBuildingItem[] m_ItemDatas;

	// Token: 0x040063B7 RID: 25527
	private ushort m_BuildKindID;

	// Token: 0x040063B8 RID: 25528
	private byte m_BuildKind;

	// Token: 0x040063B9 RID: 25529
	private StringBuilder sb;

	// Token: 0x040063BA RID: 25530
	private int m_MaxObjCount = 5;

	// Token: 0x040063BB RID: 25531
	private UIText[] m_TextObject1s;

	// Token: 0x040063BC RID: 25532
	private UIText[] m_TextObject2s;

	// Token: 0x040063BD RID: 25533
	private UIText[] m_TextObject3s;

	// Token: 0x040063BE RID: 25534
	private UIText[] m_TextObject4s;

	// Token: 0x040063BF RID: 25535
	private Image[] m_ImageObjects;

	// Token: 0x040063C0 RID: 25536
	private RectTransform[] m_ImageObjectsRt;

	// Token: 0x040063C1 RID: 25537
	private string m_EmptyString;

	// Token: 0x040063C2 RID: 25538
	private bool bInitScrollPanel;

	// Token: 0x040063C3 RID: 25539
	private ushort m_GuideBuildID;

	// Token: 0x040063C4 RID: 25540
	private List<ushort>[] m_BuildIdList = new List<ushort>[3];
}
