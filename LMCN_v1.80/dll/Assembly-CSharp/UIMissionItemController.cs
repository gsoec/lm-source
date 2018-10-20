using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200041C RID: 1052
public class UIMissionItemController : iMissionTimeDelta, IUIButtonClickHandler
{
	// Token: 0x0600155E RID: 5470 RVA: 0x0024ACE4 File Offset: 0x00248EE4
	public UIMissionItemController(UIMission GUIWin, Transform listTrans, byte MaxItemCount)
	{
		this.ControllerTrans = listTrans;
		this.MaxItemCount = MaxItemCount;
		this.GUIWin = GUIWin;
		this.ManorKindSpriteArray = this.ControllerTrans.GetChild(3).GetChild(1).GetComponent<UISpritesArray>();
		this.scrollPanel = this.ControllerTrans.GetChild(2).GetComponent<ScrollPanel>();
		for (int i = 0; i < (int)MaxItemCount; i++)
		{
			this.ItemsHeight.Add(106f);
		}
		this.scrollPanel.IntiScrollPanel(429f, 0f, 0f, this.ItemsHeight, (int)MaxItemCount, GUIWin);
		this.scrollPanel.gameObject.SetActive(true);
		this.RectSecroll = this.scrollPanel.transform.GetComponent<RectTransform>();
		this.Content = this.scrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
		this.AffairSpriteArray = this.ControllerTrans.GetChild(3).GetComponent<UISpritesArray>();
		this.ReCommandSpriteArray = this.ControllerTrans.GetChild(3).GetChild(0).GetComponent<UISpritesArray>();
		this.TitleTrans = this.ControllerTrans.GetChild(0);
		this.NoMission = this.ControllerTrans.GetChild(1);
		this.NoMissionText = this.NoMission.GetChild(0).GetComponent<UIText>();
		this.NoMissionStr = StringManager.Instance.SpawnString(150);
		this.AllianceBoundRateText = this.NoMission.GetChild(1).GetComponent<UIText>();
		this.AllianceBoundRateStr = StringManager.Instance.SpawnString(150);
		this.AllianceBoundRateStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(1525u));
		this.AllianceBoundRateStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(1003u));
		this.AllianceBoundRateText.text = this.AllianceBoundRateStr.ToString();
		this.TimeStr = StringManager.Instance.SpawnString(100);
		this.TimeText = this.ControllerTrans.GetChild(0).GetChild(3).GetComponent<UIText>();
		this.ResetBtn = this.ControllerTrans.GetChild(0).GetChild(0).GetComponent<UIButton>();
		this.ResetBtn.m_BtnID1 = 10;
		this.ResetBtn.m_Handler = this;
		UIButtonHint uibuttonHint = this.ControllerTrans.GetChild(0).GetChild(1).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = GUIWin;
		uibuttonHint.Parm1 = 1566;
		uibuttonHint.ControlFadeOut = GUIWin.HintRect.gameObject;
		this.InfoBtn = this.ControllerTrans.GetChild(0).GetChild(2).GetComponent<UIButton>();
		this.InfoBtn.m_BtnID1 = 9;
		this.InfoBtn.m_Handler = this;
		if (GUIManager.Instance.IsArabic)
		{
			this.InfoBtn.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		this.TimebarTrans = this.ControllerTrans.GetChild(4);
		this.TimebarData.transform = this.TimebarTrans.GetChild(0).GetComponent<RectTransform>();
		this.TimebarData.TimeBar = this.TimebarTrans.GetChild(0).GetChild(0).GetComponent<UITimeBar>();
		this.TimebarData.Speed = this.TimebarTrans.GetChild(0).GetChild(1).GetComponent<UIButton>();
		this.TimebarData.Speed.m_BtnID1 = 6;
		this.TimebarData.Speed.m_Handler = this;
		GUIManager.Instance.CreateTimerBar(this.TimebarData.TimeBar, 0L, 0L, 0L, eTimeBarType.UIMission, string.Empty, string.Empty);
		this.VIPTimebar.transform = this.TimebarTrans.GetChild(1).GetComponent<RectTransform>();
		this.VIPTimebar.TimeBar = this.TimebarTrans.GetChild(1).GetChild(0).GetComponent<UITimeBar>();
		this.VIPTimebar.Speed = this.TimebarTrans.GetChild(1).GetChild(1).GetComponent<UIButton>();
		this.VIPTimebar.Speed.m_BtnID1 = 12;
		this.VIPTimebar.Speed.m_Handler = this;
		GUIManager.Instance.CreateTimerBar(this.VIPTimebar.TimeBar, 0L, 0L, 0L, eTimeBarType.UIMission, string.Empty, string.Empty);
		this.MissionListItem = new UIMissionItem[4][];
		this.scrollItem = new ScrollPanelItem[(int)MaxItemCount];
		for (int j = 0; j < (int)MaxItemCount; j++)
		{
			this.scrollItem[j] = this.Content.GetChild(j).GetComponent<ScrollPanelItem>();
		}
	}

	// Token: 0x0600155F RID: 5471 RVA: 0x0024B1E0 File Offset: 0x002493E0
	public bool ChangeTag(eMissionClickType Tag, bool ForceUpdate = false)
	{
		if (!ForceUpdate && this.CurrentTag == Tag)
		{
			return false;
		}
		if (DataManager.Instance.RoleAlliance.Id == 0u && Tag == eMissionClickType.Tag3)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			DataManager.Instance.SetSelectRequest = 0;
			door.OpenMenu(EGUIWindow.UI_AllianceHint, 0, 0, false);
			return false;
		}
		if (this.Select != null)
		{
			this.Select.SetSelect(false, this.SelectIndex, null, null, null);
		}
		if (this.CurrentTag != eMissionClickType.Tag4)
		{
			this.Oldid = (int)this.CurrentTag;
		}
		this.CurrentTag = Tag;
		int currentTag = (int)this.CurrentTag;
		if (this.NoMission.gameObject.activeSelf)
		{
			this.NoMission.gameObject.SetActive(false);
		}
		if (!this.scrollPanel.gameObject.activeSelf)
		{
			this.scrollPanel.gameObject.SetActive(true);
		}
		if (this.CurrentTag != eMissionClickType.Tag1)
		{
			this.SetScrollViewRange(1);
		}
		else
		{
			this.SetScrollViewRange(2);
		}
		if (this.MissionListItem[currentTag] == null)
		{
			this.MissionListItem[currentTag] = new UIMissionItem[(int)this.MaxItemCount];
			for (int i = 0; i < (int)this.MaxItemCount; i++)
			{
				switch (this.CurrentTag)
				{
				case eMissionClickType.Tag1:
					if (i == 0)
					{
						this.MissionListItem[currentTag][i] = new ReCommandMission(UnityEngine.Object.Instantiate(this.ItemSample[2]) as Transform, this.ReCommandSpriteArray);
					}
					else if (i == 1)
					{
						this.MissionListItem[currentTag][i] = new AchieveTarget(UnityEngine.Object.Instantiate(this.ItemSample[0]) as Transform, this.ManorKindSpriteArray.GetSprite(0));
					}
					else
					{
						this.MissionListItem[currentTag][i] = new ManorMissionKind(UnityEngine.Object.Instantiate(this.ItemSample[0]) as Transform, (eUIMissionKind)(i - 2), this.ManorKindSpriteArray);
					}
					this.MissionListItem[currentTag][i].TimeHandle = this;
					break;
				case eMissionClickType.Tag2:
					this.MissionListItem[currentTag][i] = new AffairMission(UnityEngine.Object.Instantiate(this.ItemSample[1]) as Transform, this.AffairSpriteArray, this.TimebarData);
					if (this.MissionListItem[currentTag + 1] == null)
					{
						this.MissionListItem[currentTag + 1] = new UIMissionItem[(int)this.MaxItemCount];
					}
					this.MissionListItem[currentTag + 1][i] = this.MissionListItem[currentTag][i];
					this.MissionListItem[currentTag + 1][i].TimeHandle = this;
					break;
				case eMissionClickType.Tag3:
					this.MissionListItem[currentTag][i] = new AffairMission(UnityEngine.Object.Instantiate(this.ItemSample[1]) as Transform, this.AffairSpriteArray, this.TimebarData);
					if (this.MissionListItem[currentTag - 1] == null)
					{
						this.MissionListItem[currentTag - 1] = new UIMissionItem[(int)this.MaxItemCount];
					}
					this.MissionListItem[currentTag - 1][i] = this.MissionListItem[currentTag][i];
					this.MissionListItem[currentTag - 1][i].TimeHandle = this;
					break;
				case eMissionClickType.Tag4:
					if (this.vipMission == null)
					{
						this.vipMission = new VIPMission(this.ItemSample[3], this.VIPTimebar);
					}
					this.vipMission.TimdHandle = this;
					break;
				}
				if (this.CurrentTag == eMissionClickType.Tag4)
				{
					break;
				}
			}
		}
		if (this.CurrentTag == eMissionClickType.Tag4)
		{
			this.ControllerTrans.gameObject.SetActive(false);
			this.vipMission.SetAchieve(true);
			return true;
		}
		if (!this.ControllerTrans.gameObject.activeSelf)
		{
			this.vipMission.SetAchieve(false);
			this.ControllerTrans.gameObject.SetActive(true);
		}
		bool flag = true;
		if ((this.Oldid == 1 && this.CurrentTag == eMissionClickType.Tag3) || (this.Oldid == 2 && this.CurrentTag == eMissionClickType.Tag2))
		{
			flag = false;
		}
		if (this.CurrentTag == eMissionClickType.Tag2 || this.CurrentTag == eMissionClickType.Tag3)
		{
			for (int j = 0; j < (int)this.MaxItemCount; j++)
			{
				AffairMission affairMission = this.MissionListItem[currentTag][j] as AffairMission;
				if (this.CurrentTag == eMissionClickType.Tag2)
				{
					affairMission.SetType(_eMissionType.Affair);
				}
				else
				{
					affairMission.SetType(_eMissionType.Alliance);
				}
			}
		}
		if (flag)
		{
			for (byte b = 0; b < this.MaxItemCount; b += 1)
			{
				if (this.MissionListItem.Length > this.Oldid && this.MissionListItem[this.Oldid][(int)b] != null)
				{
					this.MissionListItem[this.Oldid][(int)b].transform.gameObject.SetActive(false);
				}
				if (this.MissionListItem[currentTag][(int)b].transform.parent == null)
				{
					this.MissionListItem[currentTag][(int)b].transform.SetParent(this.Content.GetChild((int)b));
				}
				this.MissionListItem[currentTag][(int)b].transform.localPosition = new Vector3(this.OffsetX[currentTag], 0f, 0f);
				this.MissionListItem[currentTag][(int)b].transform.localScale = Vector3.one;
				this.MissionListItem[currentTag][(int)b].transform.gameObject.SetActive(true);
				for (int k = 0; k < this.MissionListItem[currentTag][(int)b].ItemBtn.Length; k++)
				{
					if (this.MissionListItem[currentTag][(int)b].ItemBtn[k] != null)
					{
						this.MissionListItem[currentTag][(int)b].ItemBtn[k].m_Handler = this;
					}
				}
			}
		}
		this.ItemsHeight.Clear();
		float item = 0f;
		ushort itemCount = this.GetItemCount(eMissionClickType.None);
		for (int l = 0; l < (int)itemCount; l++)
		{
			if (l < this.MissionListItem[currentTag].Length)
			{
				item = this.MissionListItem[currentTag][l].GetHeight();
			}
			this.ItemsHeight.Add(item);
		}
		Vector2 vector = Vector2.zero;
		int itemidx = 0;
		this.Select = null;
		if (itemCount > 0)
		{
			if (ForceUpdate)
			{
				vector = this.Content.anchoredPosition;
				itemidx = this.scrollPanel.GetBeginIdx();
			}
			this.scrollPanel.AddNewDataHeight(this.ItemsHeight, this.RectSecroll.sizeDelta.y, true);
		}
		this.ResetBtn.m_BtnID2 = (int)this.CurrentTag;
		this.InfoBtn.m_BtnID2 = (int)this.CurrentTag;
		this.UpdateTime = 0f;
		this.Update();
		if (itemCount > 0 && ForceUpdate)
		{
			this.scrollPanel.GoTo(itemidx, vector.y);
		}
		if (this.CurrentTag == eMissionClickType.Tag1 && DataManager.MissionDataManager.RewardList.Priority.Count > 0)
		{
			this.OnButtonClick(this.MissionListItem[currentTag][1].ItemBtn[0]);
		}
		else if (this.MissionListItem[currentTag][0] != null)
		{
			this.OnButtonClick(this.MissionListItem[currentTag][0].ItemBtn[0]);
		}
		return true;
	}

	// Token: 0x06001560 RID: 5472 RVA: 0x0024B920 File Offset: 0x00249B20
	public void SetScrollViewRange(byte Type)
	{
		if (Type == 1)
		{
			this.TitleTrans.gameObject.SetActive(true);
			Vector2 vector = this.RectSecroll.anchoredPosition;
			vector.Set(vector.x, -53f);
			this.RectSecroll.anchoredPosition = vector;
			vector = this.RectSecroll.sizeDelta;
			vector.Set(vector.x, 410.8f);
			this.RectSecroll.sizeDelta = vector;
		}
		else
		{
			this.TitleTrans.gameObject.SetActive(false);
			Vector2 vector = this.RectSecroll.anchoredPosition;
			vector.Set(vector.x, 4.06f);
			this.RectSecroll.anchoredPosition = vector;
			vector = this.RectSecroll.sizeDelta;
			vector.Set(vector.x, 468.32f);
			this.RectSecroll.sizeDelta = vector;
		}
	}

	// Token: 0x06001561 RID: 5473 RVA: 0x0024BA08 File Offset: 0x00249C08
	public ushort GetItemCount(eMissionClickType Tag = eMissionClickType.None)
	{
		if (Tag == eMissionClickType.None)
		{
			Tag = this.CurrentTag;
		}
		this.MissionList.Clear();
		switch (Tag)
		{
		case eMissionClickType.Tag1:
			for (byte b = 0; b < 8; b += 1)
			{
				this.MissionList.Add(b);
			}
			return (ushort)this.MissionList.Count;
		case eMissionClickType.Tag2:
		case eMissionClickType.Tag3:
		{
			_eMissionType type;
			if (Tag == eMissionClickType.Tag2)
			{
				type = _eMissionType.Affair;
			}
			else
			{
				type = _eMissionType.Alliance;
			}
			ushort num = 0;
			TimerTypeMission timerMissionData = DataManager.MissionDataManager.GetTimerMissionData(type);
			for (byte b2 = 0; b2 < timerMissionData.MissionCount; b2 += 1)
			{
				if (timerMissionData.TimeMission[(int)b2].State != _eTimerMissionState.Complete)
				{
					this.MissionList.Add(timerMissionData.TimeMission[(int)b2].Index);
					if (num > 0 && (timerMissionData.TimeMission[(int)b2].State == _eTimerMissionState.Reward || timerMissionData.TimeMission[(int)b2].State == _eTimerMissionState.Countdown))
					{
						for (int i = (int)num; i > 0; i--)
						{
							this.MissionList[i - 1] = (this.MissionList[i - 1] ^ this.MissionList[i]);
							this.MissionList[i] = (this.MissionList[i] ^ this.MissionList[i - 1]);
							this.MissionList[i - 1] = (this.MissionList[i - 1] ^ this.MissionList[i]);
						}
					}
					num += 1;
				}
			}
			return num;
		}
		default:
			return 0;
		}
	}

	// Token: 0x06001562 RID: 5474 RVA: 0x0024BBC0 File Offset: 0x00249DC0
	public float GetDeltaTime()
	{
		return this.DeltaTime;
	}

	// Token: 0x06001563 RID: 5475 RVA: 0x0024BBC8 File Offset: 0x00249DC8
	public float GetSmoothDeltaTime()
	{
		return this.SmoothTime;
	}

	// Token: 0x06001564 RID: 5476 RVA: 0x0024BBD0 File Offset: 0x00249DD0
	public void Destroy()
	{
		StringManager.Instance.DeSpawnString(this.TimeStr);
		StringManager.Instance.DeSpawnString(this.NoMissionStr);
		StringManager.Instance.DeSpawnString(this.AllianceBoundRateStr);
		byte b = 0;
		while ((int)b < this.MissionListItem.Length)
		{
			if (this.MissionListItem[(int)b] != null)
			{
				byte b2 = 0;
				while ((int)b2 < this.MissionListItem[(int)b].Length)
				{
					if (this.MissionListItem[(int)b][(int)b2] != null)
					{
						this.MissionListItem[(int)b][(int)b2].Destroy();
					}
					b2 += 1;
				}
			}
			b += 1;
		}
		GUIManager.Instance.RemoverTimeBaarToList(this.TimebarData.TimeBar);
		GUIManager.Instance.RemoverTimeBaarToList(this.VIPTimebar.TimeBar);
		if (this.vipMission != null)
		{
			this.vipMission.Destroy();
		}
	}

	// Token: 0x06001565 RID: 5477 RVA: 0x0024BCB4 File Offset: 0x00249EB4
	public void UpdateItem(int dataIndex, int panelIndex)
	{
		if (this.CurrentTag == eMissionClickType.MaxTag || this.MissionListItem[(int)this.CurrentTag] == null)
		{
			return;
		}
		this.MissionListItem[(int)this.CurrentTag][panelIndex].SetMissionData((int)this.MissionList[dataIndex]);
		if (this.Select != null && this.SelectDataIndex == (int)this.MissionList[dataIndex])
		{
			this.MissionListItem[(int)this.CurrentTag][panelIndex].SetSelect(true, 0, null, null, null);
		}
	}

	// Token: 0x06001566 RID: 5478 RVA: 0x0024BD3C File Offset: 0x00249F3C
	public void Update()
	{
		if (this.CurrentTag == eMissionClickType.MaxTag)
		{
			return;
		}
		byte b = (byte)this.CurrentTag;
		for (int i = 0; i < this.MissionListItem[(int)b].Length; i++)
		{
			if (this.MissionListItem[(int)b][i] != null)
			{
				this.MissionListItem[(int)b][i].Update();
			}
		}
		this.DeltaTime += Time.deltaTime;
		this.SmoothTime += Time.smoothDeltaTime;
		if (this.DeltaTime >= 2f)
		{
			this.DeltaTime = 0f;
		}
		this.UpdateTime -= Time.deltaTime;
		if (this.UpdateTime > 0f)
		{
			return;
		}
		this.UpdateTime = 0.2f;
		if (this.CurrentTag == eMissionClickType.Tag1)
		{
			if (this.MissionList.Count == 0 && this.scrollPanel.gameObject.activeSelf)
			{
				this.scrollPanel.gameObject.SetActive(false);
				this.NoMission.gameObject.SetActive(true);
				this.NoMissionText.text = DataManager.Instance.mStringTable.GetStringByID(1539u);
			}
		}
		else if (this.CurrentTag == eMissionClickType.Tag2 || this.CurrentTag == eMissionClickType.Tag3)
		{
			TimerTypeMission timerMissionData = DataManager.MissionDataManager.GetTimerMissionData((_eMissionType)this.CurrentTag);
			this.TimeStr.ClearString();
			this.TimeStr.Append(DataManager.MissionDataManager.FormatMissionTime((uint)Math.Max(timerMissionData.ResetTime - DataManager.Instance.ServerTime, 0L)));
			this.TimeText.text = this.TimeStr.ToString();
			this.TimeText.SetAllDirty();
			this.TimeText.cachedTextGenerator.Invalidate();
			if (this.MissionList.Count == 0)
			{
				if (this.scrollPanel.gameObject.activeSelf)
				{
					this.scrollPanel.gameObject.SetActive(false);
					this.NoMission.gameObject.SetActive(true);
					this.UpdateAllianceBoundRate();
				}
				StringTable mStringTable = DataManager.Instance.mStringTable;
				this.NoMissionStr.ClearString();
				this.NoMissionStr.StringToFormat(mStringTable.GetStringByID(1544u));
				this.NoMissionStr.StringToFormat("\n");
				this.NoMissionStr.StringToFormat(this.TimeStr);
				this.NoMissionStr.AppendFormat("{0}{1}{2}");
				this.NoMissionText.text = this.NoMissionStr.ToString();
				this.NoMissionText.SetAllDirty();
				this.NoMissionText.cachedTextGenerator.Invalidate();
			}
		}
		else if (this.CurrentTag == eMissionClickType.Tag4)
		{
			this.vipMission.Update();
		}
		this.SmoothTime = 0f;
	}

	// Token: 0x06001567 RID: 5479 RVA: 0x0024C014 File Offset: 0x0024A214
	private void UpdateAllianceBoundRate()
	{
		if (this.MissionList.Count == 0 && !this.scrollPanel.gameObject.activeSelf)
		{
			if (this.CurrentTag == eMissionClickType.Tag3 && DataManager.MissionDataManager.AllianceMissionBonusRate > 100)
			{
				this.AllianceBoundRateText.gameObject.SetActive(true);
			}
			else
			{
				this.AllianceBoundRateText.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001568 RID: 5480 RVA: 0x0024C08C File Offset: 0x0024A28C
	public void Update(int arg1, int arg2)
	{
		bool flag = true;
		switch (arg1)
		{
		case 1:
			if (this.CurrentTag == eMissionClickType.Tag2 || this.CurrentTag == eMissionClickType.Tag3)
			{
				for (int i = 0; i < this.MissionListItem[(int)this.CurrentTag].Length; i++)
				{
					this.MissionListItem[(int)this.CurrentTag][i].SetMissionData(this.MissionListItem[(int)this.CurrentTag][i].DataIndex);
				}
			}
			break;
		case 2:
			if (this.CurrentTag == eMissionClickType.Tag2 || this.CurrentTag == eMissionClickType.Tag3)
			{
				_eMissionType type;
				if (this.CurrentTag == eMissionClickType.Tag2)
				{
					type = _eMissionType.Affair;
				}
				else
				{
					type = _eMissionType.Alliance;
				}
				TimerTypeMission timerMissionData = DataManager.MissionDataManager.GetTimerMissionData(type);
				int num = this.MissionList.BinarySearch(timerMissionData.ProcessIdx);
				if (num < 0)
				{
					return;
				}
				if (num != 0)
				{
					for (int j = num; j > 0; j--)
					{
						this.MissionList[j - 1] = (this.MissionList[j - 1] ^ this.MissionList[j]);
						this.MissionList[j] = (this.MissionList[j] ^ this.MissionList[j - 1]);
						this.MissionList[j - 1] = (this.MissionList[j - 1] ^ this.MissionList[j]);
					}
				}
				this.scrollPanel.GoTo(0, 0f);
				for (int k = 0; k < this.MissionListItem[(int)this.CurrentTag].Length; k++)
				{
					if (k >= this.MissionList.Count)
					{
						break;
					}
					this.MissionListItem[(int)this.CurrentTag][k].SetMissionData((int)this.MissionList[k]);
				}
			}
			break;
		default:
			if (arg1 != 16)
			{
				if (arg1 == 32)
				{
					flag = false;
					this.GUIWin.UpdatAllianceUpGrade();
					this.UpdateAllianceBoundRate();
				}
			}
			else
			{
				ManorAimMission manorAimMission = this.Select as ManorAimMission;
				if (manorAimMission != null)
				{
					int num2 = this.SelectIndex;
					this.ChangeTag(this.CurrentTag, true);
					if (manorAimMission.SlotCount > 0)
					{
						if (num2 >= manorAimMission.SlotCount)
						{
							num2 = manorAimMission.SlotCount - 1;
						}
						this.GUIWin.OnButtonClick(manorAimMission.ItemBtn[num2]);
						arg2 = 1;
					}
				}
			}
			break;
		case 4:
			this.ChangeTag(this.CurrentTag, true);
			break;
		case 8:
		{
			DataManager instance = DataManager.Instance;
			if (instance.RoleAlliance.Id == 0u && this.CurrentTag == eMissionClickType.Tag3)
			{
				GUIManager.Instance.OpenMessageBox(instance.mStringTable.GetStringByID(3782u), instance.mStringTable.GetStringByID(1569u), instance.mStringTable.GetStringByID(3784u), null, 0, 0, false, false, false, false, false);
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.CloseMenu_Alliance(EGUIWindow.UI_Mission);
			}
			break;
		}
		}
		if (flag && arg1 > 0 && this.MissionList.Count > 0 && arg2 == 0 && this.MissionListItem[(int)this.CurrentTag][0] != null)
		{
			this.OnButtonClick(this.MissionListItem[(int)this.CurrentTag][0].ItemBtn[0]);
		}
	}

	// Token: 0x06001569 RID: 5481 RVA: 0x0024C430 File Offset: 0x0024A630
	public void SetSelect(int dataIndex, int index, uint[] reward, ushort[] rewardItem, ushort[] Count)
	{
		if (this.MissionList.Count == 0)
		{
			Array.Clear(reward, 0, reward.Length);
			Array.Clear(rewardItem, 0, rewardItem.Length);
			Array.Clear(Count, 0, Count.Length);
			return;
		}
		int currentTag = (int)this.CurrentTag;
		for (int i = 0; i < this.MissionListItem[currentTag].Length; i++)
		{
			if (this.MissionListItem[currentTag][i] == null)
			{
				break;
			}
			if (this.MissionListItem[currentTag][i].DataIndex == dataIndex)
			{
				if (this.Select != null)
				{
					this.Select.SetSelect(false, this.SelectIndex, null, null, null);
				}
				this.SelectIndex = index;
				this.MissionListItem[currentTag][i].SetSelect(true, index, reward, rewardItem, Count);
				this.Select = this.MissionListItem[currentTag][i];
				this.SelectDataIndex = this.Select.DataIndex;
				break;
			}
		}
	}

	// Token: 0x0600156A RID: 5482 RVA: 0x0024C520 File Offset: 0x0024A720
	public ushort GetQuality(int dataIndex, int index)
	{
		if (this.CurrentTag == eMissionClickType.Tag2 || this.CurrentTag == eMissionClickType.Tag3)
		{
			TimerTypeMission timerMissionData = DataManager.MissionDataManager.GetTimerMissionData((_eMissionType)this.CurrentTag);
			return timerMissionData.TimeMission[dataIndex].Quality;
		}
		return 0;
	}

	// Token: 0x0600156B RID: 5483 RVA: 0x0024C56C File Offset: 0x0024A76C
	public void OnButtonClick(UIButton sender)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		switch (sender.m_BtnID1)
		{
		case 9:
			switch (sender.m_BtnID2)
			{
			case 1:
				GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(1524u), mStringTable.GetStringByID(3799u), null, null, 0, 0, false, false, true, false, false);
				break;
			case 2:
				GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(1525u), mStringTable.GetStringByID(3800u), null, null, 0, 0, false, false, true, false, false);
				break;
			}
			break;
		case 10:
			switch (sender.m_BtnID2)
			{
			case 1:
				GUIManager.Instance.UseOrSpend(1112, mStringTable.GetStringByID(1513u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
				break;
			case 2:
				GUIManager.Instance.UseOrSpend(1113, mStringTable.GetStringByID(1515u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
				break;
			}
			break;
		case 11:
			this.GUIWin.OnButtonClick(sender);
			break;
		case 12:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 21, false);
			break;
		}
		}
	}

	// Token: 0x0600156C RID: 5484 RVA: 0x0024C6E4 File Offset: 0x0024A8E4
	public void TextRefresh()
	{
		this.NoMissionText.enabled = false;
		this.NoMissionText.enabled = true;
		this.AllianceBoundRateText.enabled = false;
		this.AllianceBoundRateText.enabled = true;
		this.TimeText.enabled = false;
		this.TimeText.enabled = true;
		this.TimebarData.TimeBar.Refresh_FontTexture();
		this.VIPTimebar.TimeBar.Refresh_FontTexture();
		if (this.vipMission != null)
		{
			this.vipMission.TextRefresh();
		}
		byte b = 0;
		while ((int)b < this.MissionListItem.Length)
		{
			if (this.MissionListItem[(int)b] != null)
			{
				byte b2 = 0;
				while ((int)b2 < this.MissionListItem[(int)b].Length)
				{
					if (this.MissionListItem[(int)b][(int)b2] != null)
					{
						this.MissionListItem[(int)b][(int)b2].TextRefresh();
					}
					b2 += 1;
				}
			}
			b += 1;
		}
	}

	// Token: 0x04003F63 RID: 16227
	private ScrollPanel scrollPanel;

	// Token: 0x04003F64 RID: 16228
	private RectTransform RectSecroll;

	// Token: 0x04003F65 RID: 16229
	private RectTransform Content;

	// Token: 0x04003F66 RID: 16230
	private Transform ControllerTrans;

	// Token: 0x04003F67 RID: 16231
	private Transform TitleTrans;

	// Token: 0x04003F68 RID: 16232
	private Transform NoMission;

	// Token: 0x04003F69 RID: 16233
	private Transform TimebarTrans;

	// Token: 0x04003F6A RID: 16234
	public UIText NoMissionText;

	// Token: 0x04003F6B RID: 16235
	public UIText TimeText;

	// Token: 0x04003F6C RID: 16236
	public UIText AllianceBoundRateText;

	// Token: 0x04003F6D RID: 16237
	private CString NoMissionStr;

	// Token: 0x04003F6E RID: 16238
	private CString TimeStr;

	// Token: 0x04003F6F RID: 16239
	private CString AllianceBoundRateStr;

	// Token: 0x04003F70 RID: 16240
	private UIButton InfoBtn;

	// Token: 0x04003F71 RID: 16241
	private UIButton ResetBtn;

	// Token: 0x04003F72 RID: 16242
	private UISpritesArray AffairSpriteArray;

	// Token: 0x04003F73 RID: 16243
	private UISpritesArray ReCommandSpriteArray;

	// Token: 0x04003F74 RID: 16244
	private UISpritesArray ManorKindSpriteArray;

	// Token: 0x04003F75 RID: 16245
	private byte MaxItemCount;

	// Token: 0x04003F76 RID: 16246
	private UIMissionItem[][] MissionListItem;

	// Token: 0x04003F77 RID: 16247
	private VIPMission vipMission;

	// Token: 0x04003F78 RID: 16248
	public eMissionClickType CurrentTag = eMissionClickType.MaxTag;

	// Token: 0x04003F79 RID: 16249
	private int Oldid;

	// Token: 0x04003F7A RID: 16250
	private ScrollPanelItem[] scrollItem;

	// Token: 0x04003F7B RID: 16251
	private List<float> ItemsHeight = new List<float>();

	// Token: 0x04003F7C RID: 16252
	public List<byte> MissionList = new List<byte>();

	// Token: 0x04003F7D RID: 16253
	public Transform[] ItemSample = new Transform[4];

	// Token: 0x04003F7E RID: 16254
	private UIMissionItem Select;

	// Token: 0x04003F7F RID: 16255
	private UIMission GUIWin;

	// Token: 0x04003F80 RID: 16256
	private int SelectIndex;

	// Token: 0x04003F81 RID: 16257
	private int SelectDataIndex;

	// Token: 0x04003F82 RID: 16258
	private _MissionTimeBar TimebarData;

	// Token: 0x04003F83 RID: 16259
	private _MissionTimeBar VIPTimebar;

	// Token: 0x04003F84 RID: 16260
	private float DeltaTime;

	// Token: 0x04003F85 RID: 16261
	private float SmoothTime;

	// Token: 0x04003F86 RID: 16262
	private float[] OffsetX = new float[]
	{
		21.48f,
		18.4f,
		18.4f
	};

	// Token: 0x04003F87 RID: 16263
	private float UpdateTime = 0.2f;

	// Token: 0x0200041D RID: 1053
	public enum MissionListControl
	{
		// Token: 0x04003F89 RID: 16265
		Title,
		// Token: 0x04003F8A RID: 16266
		NoMission,
		// Token: 0x04003F8B RID: 16267
		Scroll,
		// Token: 0x04003F8C RID: 16268
		SpriteArray,
		// Token: 0x04003F8D RID: 16269
		TimeBar
	}
}
