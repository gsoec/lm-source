using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000694 RID: 1684
public class UITechInstitute : GUIWindow, IBuildingWindowType, IUpDateScrollPanel, IUIButtonClickHandler, IUTimeBarOnTimer
{
	// Token: 0x06002048 RID: 8264 RVA: 0x003D37F8 File Offset: 0x003D19F8
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Upgrade)
		{
			this.ThisTransform.gameObject.SetActive(false);
		}
		else if (buildType == e_BuildType.Normal)
		{
			this.ThisTransform.gameObject.SetActive(true);
			this.UpdateTimeBarState();
		}
	}

	// Token: 0x06002049 RID: 8265 RVA: 0x003D3840 File Offset: 0x003D1A40
	private void Start()
	{
		this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		byte level = this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level;
		this.baseBuild.InitBuildingWindow(10, (ushort)this.B_ID, 2, level);
		this.baseBuild.baseTransform.SetAsFirstSibling();
	}

	// Token: 0x0600204A RID: 8266 RVA: 0x003D38B8 File Offset: 0x003D1AB8
	public override void OnOpen(int arg1, int arg2)
	{
		this.ThisTransform = base.transform.GetChild(0);
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.B_ID = arg1;
		Font ttffont = this.GUIM.GetTTFFont();
		this.TitleText = this.ThisTransform.GetChild(0).GetChild(1).GetComponent<UIText>();
		this.TitleText.font = ttffont;
		this.TitleText.text = this.DM.mStringTable.GetStringByID(5001u);
		Transform child = this.ThisTransform.GetChild(0).GetChild(0);
		this.timeBar = child.GetComponent<UITimeBar>();
		this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
		this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
		this.timeBar.m_Handler = this;
		this.UpdateTimeBarState();
		child = this.ThisTransform.GetChild(2);
		this.m_itemView = child.GetComponent<ScrollPanel>();
		this.SpriteArray = this.ThisTransform.GetChild(2).GetComponent<UISpritesArray>();
		if (this.DM.ResearchTech > 0)
		{
			this.ResearchTechKind = this.DM.TechData.GetRecordByKey(this.DM.ResearchTech).Kind;
		}
		this.KindDataCount = (ushort)this.DM.TechKindData.TableCount;
		this.MaxScrollItemCount = (int)(this.KindDataCount / 4) + Mathf.Clamp((int)(this.KindDataCount & 3), 0, 1);
		for (int i = 0; i < 4; i++)
		{
			child = this.ThisTransform.GetChild(3).GetChild(i);
			child.GetChild(0).GetComponent<UIText>().font = ttffont;
			child.GetChild(2).GetChild(1).GetComponent<UIText>().font = ttffont;
		}
		if (DataManager.StageDataController.StageRecord[2] < 8)
		{
			this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		}
		else
		{
			this.GUIM.UpdateUI(EGUIWindow.Door, 1, 4);
		}
		GameConstants.GetBytes(0, GUIManager.Instance.TechSaved, 6);
		if (this.DM.GetTechLevel(42) == 0 && GUIManager.Instance.BuildingData.BuildIDCount[10] != 0 && arg2 != 0)
		{
			NewbieManager.CheckTeach(ETeachKind.COLLEGE, this, true);
		}
	}

	// Token: 0x0600204B RID: 8267 RVA: 0x003D3B18 File Offset: 0x003D1D18
	public void Update()
	{
		if (this.PassInit > 0)
		{
			this.PassInit -= 1;
			if (this.PassInit == 0)
			{
				int num = Mathf.Clamp(this.MaxScrollItemCount, 0, 3);
				this.TechItem = new UITechInstitute._TechItem[num];
				this.m_itemView.IntiScrollPanel(285f, 0f, 0f, this.tmplist, num, this);
				for (int i = 0; i < this.MaxScrollItemCount; i++)
				{
					this.tmplist.Add(227f);
				}
				this.m_itemView.AddNewDataHeight(this.tmplist, true, true);
				this.m_itemView.gameObject.SetActive(true);
				this.ScroContent = this.m_itemView.transform.GetChild(0).GetComponent<RectTransform>();
				float num2 = this.ScroContent.sizeDelta.y - 285f;
				float num3 = GameConstants.ConvertBytesToFloat(this.GUIM.TechKindSaved, 1);
				if (num2 < num3 && this.GUIM.TechKindSaved[0] > 0)
				{
					byte[] techKindSaved = this.GUIM.TechKindSaved;
					int num4 = 0;
					techKindSaved[num4] -= 1;
					num3 = num2;
				}
				this.m_itemView.GoTo((int)this.GUIM.TechKindSaved[0], num3);
				this.TextRefresh();
			}
		}
		else
		{
			for (int j = 0; j < this.TechItem.Length; j++)
			{
				for (int k = 0; k < this.TechItem[j].Research.Length; k++)
				{
					if (this.TechItem[j].Research[k].gameObject.activeSelf)
					{
						if (this.RotTime <= 1.3f)
						{
							Quaternion localRotation = this.TechItem[j].Research[k].localRotation;
							Vector3 eulerAngles = localRotation.eulerAngles;
							if (this.RotTime <= 0.5f)
							{
								eulerAngles.z = EasingEffect.Linear(this.RotTime, 0f, 180f, 0.5f);
							}
							else
							{
								eulerAngles.z = 180f;
							}
							localRotation.eulerAngles = eulerAngles;
							this.TechItem[j].Research[k].localRotation = localRotation;
						}
						else if (this.RotTime <= 2.6f)
						{
							float num5 = this.RotTime - 1.3f;
							Quaternion localRotation2 = this.TechItem[j].Research[k].localRotation;
							Vector3 eulerAngles2 = localRotation2.eulerAngles;
							if (num5 <= 0.5f)
							{
								eulerAngles2.z = EasingEffect.Linear(num5, 180f, 180f, 0.5f);
							}
							else
							{
								eulerAngles2.z = 360f;
							}
							localRotation2.eulerAngles = eulerAngles2;
							this.TechItem[j].Research[k].localRotation = localRotation2;
						}
						else
						{
							this.RotTime = 0f;
						}
						this.RotTime += Time.smoothDeltaTime;
						return;
					}
				}
			}
		}
	}

	// Token: 0x0600204C RID: 8268 RVA: 0x003D3E44 File Offset: 0x003D2044
	public void UpdateTimeBarState()
	{
		if (this.DM.queueBarData[1].bActive)
		{
			long startTime = this.DM.queueBarData[1].StartTime;
			long target = startTime + (long)((ulong)this.DM.queueBarData[1].TotalTime);
			string empty = string.Empty;
			string empty2 = string.Empty;
			DataManager.Instance.GetQueueBarTitle(EQueueBarIndex.Researching, this.GUIM.tmpString, ref empty, ref empty2);
			QueueBarData queueBarData = this.DM.queueBarData[1];
			long notifyTime = queueBarData.StartTime + (long)((ulong)queueBarData.TotalTime) - (long)this.DM.GetFreeCompleteTime();
			if (this.DM.RoleAlliance.Id != 0u && this.DM.mPlayHelpDataType[0].Kind == 0)
			{
				this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Help);
			}
			this.GUIM.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.CancelType, empty, empty2);
			this.timeBar.gameObject.SetActive(true);
		}
		else
		{
			this.timeBar.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600204D RID: 8269 RVA: 0x003D3F84 File Offset: 0x003D2184
	public void OnButtonClick(UIButton sender)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_TechTree, sender.m_BtnID1, sender.m_BtnID2, false);
		}
	}

	// Token: 0x0600204E RID: 8270 RVA: 0x003D3FC4 File Offset: 0x003D21C4
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		Transform transform = item.transform;
		if (this.TechItem[panelObjectIdx].TechImg == null)
		{
			this.TechItem[panelObjectIdx].Init();
		}
		this.TechItem[panelObjectIdx].dataIndex = dataIdx;
		this.TechItem[panelObjectIdx].transform = transform;
		byte b = 0;
		while ((int)b < this.TechItem[panelObjectIdx].KindName.Length)
		{
			uint num = (uint)(dataIdx * 4 + (int)b);
			if (this.TechItem[panelObjectIdx].TechImg[(int)b] == null)
			{
				transform.GetChild((int)b).GetComponent<UIButton>().m_Handler = this;
				this.TechItem[panelObjectIdx].TechImg[(int)b] = transform.GetChild((int)b).GetComponent<Image>();
				this.TechItem[panelObjectIdx].Button[(int)b] = transform.GetChild((int)b).GetComponent<UIButton>();
				this.TechItem[panelObjectIdx].Research[(int)b] = transform.GetChild((int)b).GetChild(1).GetComponent<RectTransform>();
				this.TechItem[panelObjectIdx].Lock[(int)b] = transform.GetChild((int)b).GetChild(2);
				this.TechItem[panelObjectIdx].NeedLvText[(int)b] = transform.GetChild((int)b).GetChild(2).GetChild(1).GetComponent<UIText>();
				this.TechItem[panelObjectIdx].KindName[(int)b] = transform.GetChild((int)b).GetChild(0).GetComponent<UIText>();
			}
			if (num >= (uint)this.KindDataCount)
			{
				transform.GetChild((int)b).gameObject.SetActive(false);
			}
			else
			{
				transform.GetChild((int)b).gameObject.SetActive(true);
				DataManager instance = DataManager.Instance;
				TechKindTbl recordByIndex = instance.TechKindData.GetRecordByIndex((int)instance.sortTechKindIndex[(int)((ushort)num)]);
				this.TechItem[panelObjectIdx].TechImg[(int)b].sprite = this.SpriteArray.GetSprite((int)(recordByIndex.Graphic - 1));
				if (this.TechItem[panelObjectIdx].TechImg[(int)b].sprite == null)
				{
					this.TechItem[panelObjectIdx].TechImg[(int)b].sprite = this.SpriteArray.GetSprite(0);
				}
				this.TechItem[panelObjectIdx].TechImg[(int)b].SetNativeSize();
				this.TechItem[panelObjectIdx].Button[(int)b].m_BtnID1 = (int)recordByIndex.TechKind;
				this.TechItem[panelObjectIdx].KindName[(int)b].text = instance.mStringTable.GetStringByID((uint)recordByIndex.KindName);
				this.TechItem[panelObjectIdx].Button[(int)b].m_BtnID2 = (int)recordByIndex.KindName;
				if (this.ResearchTechKind > 0 && this.TechItem[panelObjectIdx].Button[(int)b].m_BtnID1 == (int)this.ResearchTechKind)
				{
					this.TechItem[panelObjectIdx].Research[(int)b].gameObject.SetActive(true);
				}
				else
				{
					this.TechItem[panelObjectIdx].Research[(int)b].gameObject.SetActive(false);
				}
				if (recordByIndex.ResearchLevel > this.GUIM.BuildingData.GetBuildData(10, 0).Level)
				{
					this.TechItem[panelObjectIdx].Lock[(int)b].gameObject.SetActive(true);
					this.TechItem[panelObjectIdx].NeedLvStr[(int)b].ClearString();
					this.TechItem[panelObjectIdx].NeedLvStr[(int)b].IntToFormat((long)recordByIndex.ResearchLevel, 1, false);
					this.TechItem[panelObjectIdx].NeedLvStr[(int)b].AppendFormat(instance.mStringTable.GetStringByID(5008u));
					this.TechItem[panelObjectIdx].NeedLvText[(int)b].text = this.TechItem[panelObjectIdx].NeedLvStr[(int)b].ToString();
					this.TechItem[panelObjectIdx].NeedLvText[(int)b].SetAllDirty();
					this.TechItem[panelObjectIdx].NeedLvText[(int)b].cachedTextGenerator.Invalidate();
				}
				else if (!DataManager.Instance.CheckTechKind(ref recordByIndex, this.TechItem[panelObjectIdx].NeedLvStr[(int)b]))
				{
					this.TechItem[panelObjectIdx].Lock[(int)b].gameObject.SetActive(true);
					this.TechItem[panelObjectIdx].NeedLvText[(int)b].text = this.TechItem[panelObjectIdx].NeedLvStr[(int)b].ToString();
					this.TechItem[panelObjectIdx].NeedLvText[(int)b].SetAllDirty();
					this.TechItem[panelObjectIdx].NeedLvText[(int)b].cachedTextGenerator.Invalidate();
				}
				else
				{
					this.TechItem[panelObjectIdx].Lock[(int)b].gameObject.SetActive(false);
				}
			}
			b += 1;
		}
	}

	// Token: 0x0600204F RID: 8271 RVA: 0x003D44E4 File Offset: 0x003D26E4
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06002050 RID: 8272 RVA: 0x003D44E8 File Offset: 0x003D26E8
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		if (this.timeBar != null)
		{
			this.GUIM.RemoverTimeBaarToList(this.timeBar);
		}
		if (this.TechItem != null)
		{
			for (int i = 0; i < this.TechItem.Length; i++)
			{
				this.TechItem[i].Destory();
			}
		}
		if (this.ScroContent != null)
		{
			byte[] techKindSaved = this.GUIM.TechKindSaved;
			techKindSaved[0] = (byte)this.m_itemView.GetBeginIdx();
			GameConstants.GetBytes(this.ScroContent.anchoredPosition.y, techKindSaved, 1);
		}
	}

	// Token: 0x06002051 RID: 8273 RVA: 0x003D45B0 File Offset: 0x003D27B0
	public void OnTimer(UITimeBar sender)
	{
	}

	// Token: 0x06002052 RID: 8274 RVA: 0x003D45B4 File Offset: 0x003D27B4
	public void OnNotify(UITimeBar sender)
	{
		this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Free);
	}

	// Token: 0x06002053 RID: 8275 RVA: 0x003D45C8 File Offset: 0x003D27C8
	public void Onfunc(UITimeBar sender)
	{
		if (sender.m_TimerSpriteType == eTimerSpriteType.Speed)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 1, false);
		}
		else if (sender.m_TimerSpriteType == eTimerSpriteType.Free)
		{
			DataManager.Instance.sendTechnologyCompleteFree();
		}
		else if (sender.m_TimerSpriteType == eTimerSpriteType.Help)
		{
			DataManager.Instance.SendAllianceHelp(0);
		}
	}

	// Token: 0x06002054 RID: 8276 RVA: 0x003D4634 File Offset: 0x003D2834
	public void OnCancel(UITimeBar sender)
	{
		if (DataManager.Instance.ResearchTech > 0)
		{
			GUIManager.Instance.OpenOKCancelBox(this.baseBuild, DataManager.Instance.mStringTable.GetStringByID(5023u), DataManager.Instance.mStringTable.GetStringByID(5024u), 14, 0, DataManager.Instance.mStringTable.GetStringByID(5026u), DataManager.Instance.mStringTable.GetStringByID(5025u));
		}
	}

	// Token: 0x06002055 RID: 8277 RVA: 0x003D46B4 File Offset: 0x003D28B4
	public override void UpdateNetwork(byte[] meg)
	{
		if (this.PassInit > 0)
		{
			return;
		}
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_BuildBase:
			this.baseBuild.MyUpdate(meg[1], false);
			for (int i = 0; i < this.TechItem.Length; i++)
			{
				if (this.TechItem[i].transform.gameObject.activeSelf)
				{
					this.UpDateRowItem(this.TechItem[i].transform.gameObject, this.TechItem[i].dataIndex, i, 0);
				}
			}
			return;
		default:
			if (networkNews != NetworkNews.Login)
			{
				if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
				{
					return;
				}
				this.baseBuild.Refresh_FontTexture();
				this.TextRefresh();
				return;
			}
			break;
		case NetworkNews.Refresh_Technology:
		{
			this.UpdateTimeBarState();
			ushort inKey = GameConstants.ConvertBytesToUShort(meg, 2);
			TechDataTbl recordByKey = DataManager.Instance.TechData.GetRecordByKey(inKey);
			for (int j = 0; j < this.TechItem.Length; j++)
			{
				for (int k = 0; k < this.TechItem[j].Button.Length; k++)
				{
					if (this.TechItem[j].Button[k].m_BtnID1 == (int)recordByKey.Kind)
					{
						this.TechItem[j].Research[k].gameObject.SetActive(false);
						this.ResearchTechKind = 0;
						return;
					}
				}
			}
			return;
		}
		case NetworkNews.Refresh_AttribEffectVal:
			break;
		}
		this.baseBuild.MyUpdate(0, false);
	}

	// Token: 0x06002056 RID: 8278 RVA: 0x003D485C File Offset: 0x003D2A5C
	private void TextRefresh()
	{
		this.TitleText.enabled = false;
		this.TitleText.enabled = true;
		if (this.timeBar.gameObject.activeSelf)
		{
			this.timeBar.Refresh_FontTexture();
		}
		for (int i = 0; i < this.TechItem.Length; i++)
		{
			if (this.TechItem[i].KindName != null && this.TechItem[i].NeedLvText != null)
			{
				for (int j = 0; j < this.TechItem[i].KindName.Length; j++)
				{
					if (this.TechItem[i].KindName[j] == null)
					{
						break;
					}
					this.TechItem[i].KindName[j].enabled = false;
					this.TechItem[i].NeedLvText[j].enabled = false;
					this.TechItem[i].KindName[j].enabled = true;
					this.TechItem[i].NeedLvText[j].enabled = true;
				}
			}
		}
	}

	// Token: 0x06002057 RID: 8279 RVA: 0x003D4998 File Offset: 0x003D2B98
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 1)
		{
			if (arg1 == 2)
			{
				this.UpdateTimeBarState();
			}
		}
		else
		{
			this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
		}
	}

	// Token: 0x040065D5 RID: 26069
	private DataManager DM;

	// Token: 0x040065D6 RID: 26070
	private GUIManager GUIM;

	// Token: 0x040065D7 RID: 26071
	private ScrollPanel m_itemView;

	// Token: 0x040065D8 RID: 26072
	private BuildingWindow baseBuild;

	// Token: 0x040065D9 RID: 26073
	private UITimeBar timeBar;

	// Token: 0x040065DA RID: 26074
	private Transform ThisTransform;

	// Token: 0x040065DB RID: 26075
	private RectTransform ScroContent;

	// Token: 0x040065DC RID: 26076
	private UISpritesArray SpriteArray;

	// Token: 0x040065DD RID: 26077
	private byte ResearchTechKind;

	// Token: 0x040065DE RID: 26078
	private List<float> tmplist = new List<float>();

	// Token: 0x040065DF RID: 26079
	private int MaxScrollItemCount;

	// Token: 0x040065E0 RID: 26080
	private ushort KindDataCount;

	// Token: 0x040065E1 RID: 26081
	private float RotTime;

	// Token: 0x040065E2 RID: 26082
	private UIText TitleText;

	// Token: 0x040065E3 RID: 26083
	public UITechInstitute._TechItem[] TechItem;

	// Token: 0x040065E4 RID: 26084
	private int B_ID;

	// Token: 0x040065E5 RID: 26085
	private byte PassInit = 2;

	// Token: 0x02000695 RID: 1685
	public struct _TechItem
	{
		// Token: 0x06002058 RID: 8280 RVA: 0x003D49DC File Offset: 0x003D2BDC
		public void Init()
		{
			this.TechImg = new Image[4];
			this.KindName = new UIText[4];
			this.Research = new RectTransform[4];
			this.Lock = new Transform[4];
			this.Button = new UIButton[4];
			this.NeedLvText = new UIText[4];
			this.NeedLvStr = new CString[4];
			for (int i = 0; i < this.NeedLvStr.Length; i++)
			{
				this.NeedLvStr[i] = StringManager.Instance.SpawnString(30);
			}
		}

		// Token: 0x06002059 RID: 8281 RVA: 0x003D4A6C File Offset: 0x003D2C6C
		public void Destory()
		{
			for (int i = 0; i < this.NeedLvStr.Length; i++)
			{
				StringManager.Instance.DeSpawnString(this.NeedLvStr[i]);
			}
		}

		// Token: 0x040065E6 RID: 26086
		public Transform transform;

		// Token: 0x040065E7 RID: 26087
		public int dataIndex;

		// Token: 0x040065E8 RID: 26088
		public Image[] TechImg;

		// Token: 0x040065E9 RID: 26089
		public UIText[] KindName;

		// Token: 0x040065EA RID: 26090
		public RectTransform[] Research;

		// Token: 0x040065EB RID: 26091
		public Transform[] Lock;

		// Token: 0x040065EC RID: 26092
		public UIButton[] Button;

		// Token: 0x040065ED RID: 26093
		public UIText[] NeedLvText;

		// Token: 0x040065EE RID: 26094
		public CString[] NeedLvStr;
	}

	// Token: 0x02000696 RID: 1686
	private enum UIControl
	{
		// Token: 0x040065F0 RID: 26096
		Image1,
		// Token: 0x040065F1 RID: 26097
		Image2,
		// Token: 0x040065F2 RID: 26098
		ScrollView,
		// Token: 0x040065F3 RID: 26099
		Item
	}
}
