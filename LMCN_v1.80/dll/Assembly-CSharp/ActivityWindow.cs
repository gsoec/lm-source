using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020007C5 RID: 1989
public class ActivityWindow : UIBehaviour, UILoadImageHander, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06002911 RID: 10513 RVA: 0x0044C6EC File Offset: 0x0044A8EC
	protected override void Awake()
	{
		this.GM = GUIManager.Instance;
		this.DM = DataManager.Instance;
		this.AM = ActivityManager.Instance;
		this.SM = StringManager.Instance;
		this.AWM = this.AM.AllianceWarMgr;
		this.door = (this.GM.FindMenu(EGUIWindow.Door) as Door);
		AssetBundle assetBundle = AssetManager.GetAssetBundle(this.abName, out this.abKey, false);
		if (assetBundle == null)
		{
			return;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(assetBundle.mainAsset);
		if (gameObject == null)
		{
			AssetManager.UnloadAssetBundle(this.abKey, true);
			return;
		}
		gameObject.transform.SetParent(base.transform, false);
		this.m_transform = gameObject.transform;
		this.m_transform.SetAsFirstSibling();
		this.GM.m_ActivityWindow = this;
		this.tmpData = this.AM.AllianceWarData;
		Font ttffont = this.GM.GetTTFFont();
		this.m_transform.GetChild(7).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(7).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(7).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(7).GetComponent<CustomImage>().enabled = false;
		}
		this.InfoGO = this.m_transform.GetChild(6).gameObject;
		this.InfoGO.AddComponent<ArabicItemTextureRot>();
		this.m_transform.GetChild(6).GetComponent<UIButton>().m_Handler = this;
		this.Title1GO = this.m_transform.GetChild(4).gameObject;
		this.Title2GO = this.m_transform.GetChild(5).gameObject;
		UIText component = this.m_transform.GetChild(4).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(17029u);
		this.rebuildText.Add(component);
		UIButtonHint uibuttonHint = this.m_transform.GetChild(4).GetChild(1).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.Parm1 = 0;
		uibuttonHint.ScrollID = 1;
		uibuttonHint.m_Handler = this;
		this.TitleRankText = this.m_transform.GetChild(4).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.TitleRankText.font = ttffont;
		this.TitleRankText.text = this.DM.mStringTable.GetStringByID(17029u);
		this.TitleRankTextStr = this.SM.SpawnString(30);
		this.rebuildText.Add(this.TitleRankText);
		this.TitleSA1 = this.m_transform.GetChild(4).GetComponent<UISpritesArray>();
		this.TitleSA2 = this.m_transform.GetChild(4).GetChild(1).GetComponent<UISpritesArray>();
		this.Title2Text = this.m_transform.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.Title2Text.font = ttffont;
		this.rebuildText.Add(this.Title2Text);
		this.TimeGO = this.m_transform.GetChild(3).gameObject;
		this.TimeSA = this.m_transform.GetChild(3).GetComponent<UISpritesArray>();
		this.TimeTitle = this.m_transform.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.TimeTitle.font = ttffont;
		this.rebuildText.Add(this.TimeTitle);
		this.TimeText = this.m_transform.GetChild(3).GetChild(1).GetComponent<UIText>();
		this.TimeText.font = ttffont;
		this.rebuildText.Add(this.TimeText);
		this.TimeTitle2 = this.m_transform.GetChild(3).GetChild(2).GetComponent<UIText>();
		this.TimeTitle2.font = ttffont;
		this.rebuildText.Add(this.TimeTitle2);
		this.TimeTitle2.enabled = false;
		this.TimeTitle2.gameObject.SetActive(true);
		this.TimeStr = this.SM.SpawnString(30);
		this.SetTimeTitle();
		this.SetTimeStr();
	}

	// Token: 0x06002912 RID: 10514 RVA: 0x0044CB48 File Offset: 0x0044AD48
	protected override void OnDestroy()
	{
		this.SM.DeSpawnString(this.HintStr);
		this.SM.DeSpawnString(this.TitleRankTextStr);
		this.SM.DeSpawnString(this.TimeStr);
		this.SM.DeSpawnString(this.SignUpCountStr);
		this.SM.DeSpawnString(this.MessageText1Str);
		this.SM.DeSpawnString(this.MessageText2Str);
		this.SM.DeSpawnString(this.MyNoTextStr);
		this.SM.DeSpawnString(this.FTimeTextStr);
		this.SM.DeSpawnString(this.No1TextStr);
		this.SM.DeSpawnString(this.No2TextStr);
		if (this.GM.m_ActivityWindow == this)
		{
			this.GM.m_ActivityWindow = null;
		}
		base.OnDestroy();
	}

	// Token: 0x06002913 RID: 10515 RVA: 0x0044CC34 File Offset: 0x0044AE34
	public void Initial(e_ActivityType Type, IActivityWindow handler)
	{
		this.WindowType = Type;
		this.m_handler = handler;
		Font ttffont = this.GM.GetTTFFont();
		if (Type == e_ActivityType.SignUp)
		{
			Transform child = this.m_transform.GetChild(8);
			child.gameObject.SetActive(true);
			UIButtonHint uibuttonHint = child.GetChild(0).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.Parm1 = 1;
			uibuttonHint.ScrollID = 1;
			uibuttonHint.m_Handler = this;
			this.Check1GO = child.GetChild(1).gameObject;
			child.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
			this.Check2GO = child.GetChild(2).gameObject;
			child.GetChild(2).gameObject.AddComponent<ArabicItemTextureRot>();
			UIText component = child.GetChild(1).GetChild(0).GetComponent<UIText>();
			component.font = ttffont;
			component.text = this.DM.mStringTable.GetStringByID(17004u);
			this.rebuildText.Add(component);
			component = child.GetChild(2).GetChild(0).GetComponent<UIText>();
			component.font = ttffont;
			component.text = this.DM.mStringTable.GetStringByID(17032u);
			this.rebuildText.Add(component);
			this.MessageText1 = child.GetChild(3).GetComponent<UIText>();
			this.MessageText1.font = ttffont;
			this.MessageText1Str = this.SM.SpawnString(150);
			this.rebuildText.Add(this.MessageText1);
			this.MessageText2 = child.GetChild(4).GetComponent<UIText>();
			this.MessageText2.font = ttffont;
			this.MessageText2Str = this.SM.SpawnString(150);
			this.rebuildText.Add(this.MessageText2);
			this.SignUpCount = child.GetChild(5).GetComponent<UIText>();
			this.SignUpCount.font = ttffont;
			this.SignUpCountStr = this.SM.SpawnString(30);
			this.rebuildText.Add(this.SignUpCount);
		}
		else if (Type == e_ActivityType.Run || Type == e_ActivityType.RunFail)
		{
			Transform child = this.m_transform.GetChild(9);
			child.gameObject.SetActive(true);
			this.MyNoText = child.GetChild(2).GetComponent<UIText>();
			this.MyNoText.font = ttffont;
			this.MyNoTextStr = this.SM.SpawnString(100);
			this.rebuildText.Add(this.MyNoText);
			this.StageText = child.GetChild(3).GetComponent<UIText>();
			this.StageText.font = ttffont;
			this.rebuildText.Add(this.StageText);
			this.FTimeText = child.GetChild(4).GetComponent<UIText>();
			this.FTimeText.font = ttffont;
			this.rebuildText.Add(this.FTimeText);
			this.FTimeTextStr = this.SM.SpawnString(100);
			this.BtnGO = child.GetChild(5).gameObject;
			child.GetChild(5).GetComponent<UIButton>().m_Handler = this;
			this.Review1GO = child.GetChild(6).gameObject;
			this.Review2GO = child.GetChild(7).gameObject;
			this.ReviewText = child.GetChild(8).GetComponent<UIText>();
			this.ReviewText.font = ttffont;
			this.rebuildText.Add(this.ReviewText);
			if (Type != e_ActivityType.RunFail)
			{
				if (this.AWM.bReplaying)
				{
					this.m_transform.GetChild(1).gameObject.SetActive(false);
					this.m_transform.GetChild(2).gameObject.SetActive(false);
					this.InfoGO.SetActive(false);
					this.TimeGO.SetActive(false);
					this.BtnGO.SetActive(false);
					this.Title1GO.SetActive(false);
					this.Title2GO.SetActive(true);
					this.Review1GO.SetActive(true);
					this.Review2GO.SetActive(false);
					this.Title2Text.text = this.DM.mStringTable.GetStringByID(14635u);
					this.ReviewText.text = this.DM.mStringTable.GetStringByID(14616u);
					this.ReviewText.gameObject.SetActive(true);
				}
				else if (this.AWM.MyAllySide == 0)
				{
					this.m_transform.GetChild(1).gameObject.SetActive(false);
					this.m_transform.GetChild(2).gameObject.SetActive(false);
					this.InfoGO.SetActive(false);
					this.TimeGO.SetActive(false);
					this.BtnGO.SetActive(false);
					this.Title1GO.SetActive(false);
					this.Title2GO.SetActive(true);
					this.Review1GO.SetActive(false);
					this.Review2GO.SetActive(true);
					this.Title2Text.text = this.DM.mStringTable.GetStringByID(14614u);
					this.ReviewText.text = this.DM.mStringTable.GetStringByID(14615u);
					this.ReviewText.gameObject.SetActive(true);
				}
			}
		}
		else if (Type == e_ActivityType.Ranking)
		{
			Transform child = this.m_transform.GetChild(10);
			child.gameObject.SetActive(true);
			this.No1Text = child.GetChild(0).GetComponent<UIText>();
			this.No1Text.font = ttffont;
			this.No1TextStr = this.SM.SpawnString(100);
			this.rebuildText.Add(this.No1Text);
			this.No2Text = child.GetChild(1).GetComponent<UIText>();
			this.No2Text.font = ttffont;
			this.No2TextStr = this.SM.SpawnString(100);
			this.rebuildText.Add(this.No2Text);
			this.SBtnGO = child.GetChild(2).gameObject;
			child.GetChild(2).GetComponent<UIButton>().m_Handler = this;
		}
		this.SetTitleRank();
		this.SetTopText();
	}

	// Token: 0x06002914 RID: 10516 RVA: 0x0044D248 File Offset: 0x0044B448
	private void SetTimeTitle()
	{
		this.TimeTitle.enabled = false;
		this.TimeTitle2.enabled = false;
		EAllianceWarState aw_State = this.AM.AW_State;
		if (aw_State == EAllianceWarState.EAWS_SignUp)
		{
			this.TimeTitle.enabled = true;
			this.TimeTitle.text = this.DM.mStringTable.GetStringByID(17001u);
			this.TimeSA.SetSpriteIndex(0);
		}
		else if (aw_State == EAllianceWarState.EAWS_Prepare)
		{
			this.TimeTitle.enabled = true;
			this.TimeTitle.text = this.DM.mStringTable.GetStringByID(17030u);
			this.TimeSA.SetSpriteIndex(0);
		}
		else if (aw_State == EAllianceWarState.EAWS_Run)
		{
			this.TimeTitle.enabled = true;
			this.TimeTitle.text = this.DM.mStringTable.GetStringByID(8110u);
			this.TimeSA.SetSpriteIndex(0);
		}
		else if (aw_State == EAllianceWarState.EAWS_Replay)
		{
			this.TimeSA.SetSpriteIndex(1);
			this.TimeTitle2.enabled = true;
			if (this.DM.RoleAlliance.Id != 0u && this.DM.RoleAlliance.Id == this.AM.AW_SignUpAllianceID && this.AM.AW_NowAllianceEnterWar != 0 && this.AM.AW_GetGift == 0)
			{
				this.TimeTitle2.text = this.DM.mStringTable.GetStringByID(747u);
			}
			else
			{
				this.TimeTitle2.text = this.DM.mStringTable.GetStringByID(14608u);
			}
		}
		else
		{
			this.TimeTitle.enabled = true;
			this.TimeTitle.text = this.DM.mStringTable.GetStringByID(8111u);
			this.TimeSA.SetSpriteIndex(3);
		}
	}

	// Token: 0x06002915 RID: 10517 RVA: 0x0044D43C File Offset: 0x0044B63C
	private void SetTimeStr()
	{
		if (this.TimeText == null)
		{
			return;
		}
		this.TimeStr.Length = 0;
		if (this.AM.AW_State != EAllianceWarState.EAWS_Replay)
		{
			GameConstants.GetTimeString(this.TimeStr, (uint)this.tmpData.EventCountTime, false, true, false, false, true);
		}
		this.TimeText.text = this.TimeStr.ToString();
		this.TimeText.SetAllDirty();
		this.TimeText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002916 RID: 10518 RVA: 0x0044D4C8 File Offset: 0x0044B6C8
	private void SetTopTime()
	{
		if (this.FTimeText == null)
		{
			return;
		}
		if ((this.WindowType == e_ActivityType.Run && !this.AWM.bReplaying) || this.WindowType == e_ActivityType.RunFail)
		{
			CString cstring = this.SM.StaticString1024();
			long num = this.AM.AW_RoundBeginTime + (long)this.AM.AW_PrepareTime;
			ushort id;
			if (this.AM.ServerEventTime <= num)
			{
				id = 14609;
				GameConstants.GetTimeString(cstring, (uint)(num - this.AM.ServerEventTime), false, true, false, false, true);
				this.FTimeText.color = new Color(0.9921f, 0.9058f, 0.3294f);
			}
			else
			{
				id = 14617;
				GameConstants.GetTimeString(cstring, (uint)(this.AM.AW_RoundEndTime - this.AM.ServerEventTime), false, true, false, false, true);
				this.FTimeText.color = new Color(0.0313f, 0.9568f, 0.2901f);
			}
			this.FTimeTextStr.Length = 0;
			this.FTimeTextStr.StringToFormat(cstring);
			this.FTimeTextStr.AppendFormat(this.DM.mStringTable.GetStringByID((uint)id));
			this.FTimeText.text = this.FTimeTextStr.ToString();
			this.FTimeText.SetAllDirty();
			this.FTimeText.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.FTimeText.text = string.Empty;
		}
	}

	// Token: 0x06002917 RID: 10519 RVA: 0x0044D650 File Offset: 0x0044B850
	public void SetTopTimeVivsible(bool bVisible)
	{
		if (this.FTimeText == null)
		{
			return;
		}
		this.FTimeText.gameObject.SetActive(bVisible);
		if (bVisible)
		{
			this.SetTopTime();
		}
	}

	// Token: 0x06002918 RID: 10520 RVA: 0x0044D684 File Offset: 0x0044B884
	private void SetTitleRank()
	{
		int num = (int)((this.AM.AW_Rank <= 0) ? 0 : ((this.AM.AW_Rank - 1) / 5));
		this.TitleSA1.SetSpriteIndex(num);
		this.TitleSA2.SetSpriteIndex(num);
		this.TitleRankTextStr.Length = 0;
		num = (int)((this.AM.AW_Rank <= 0) ? 1 : this.AM.AW_Rank);
		this.TitleRankTextStr.IntToFormat((long)num, 1, false);
		this.TitleRankTextStr.AppendFormat("{0}");
		this.TitleRankText.text = this.TitleRankTextStr.ToString();
		this.TitleRankText.SetAllDirty();
		this.TitleRankText.cachedTextGenerator.Invalidate();
		if (this.AM.AW_Rank >= 21 && this.AM.AW_Rank <= 25)
		{
			this.TitleRankText.rectTransform.anchoredPosition = new Vector2(0f, 0f);
		}
		else
		{
			this.TitleRankText.rectTransform.anchoredPosition = new Vector2(0f, 5f);
		}
	}

	// Token: 0x06002919 RID: 10521 RVA: 0x0044D7B8 File Offset: 0x0044B9B8
	private void SetRoundText()
	{
		if (this.StageText != null)
		{
			byte b;
			if (this.AWM.bReplaying)
			{
				b = this.AWM.ReplayGame;
			}
			else
			{
				b = this.AM.AW_Round;
			}
			if (b == 1)
			{
				this.StageText.text = this.DM.mStringTable.GetStringByID(14604u);
			}
			else if (b == 2)
			{
				this.StageText.text = this.DM.mStringTable.GetStringByID(14605u);
			}
			else if (b == 3)
			{
				this.StageText.text = this.DM.mStringTable.GetStringByID(14606u);
			}
			else if (b == 4)
			{
				this.StageText.text = this.DM.mStringTable.GetStringByID(14607u);
			}
			else
			{
				this.StageText.text = string.Empty;
			}
		}
	}

	// Token: 0x0600291A RID: 10522 RVA: 0x0044D8C8 File Offset: 0x0044BAC8
	private void SetTopText()
	{
		if (this.WindowType == e_ActivityType.SignUp)
		{
			byte registerCount = this.AM.AllianceWarMgr.GetRegisterCount();
			this.SignUpCountStr.Length = 0;
			this.SignUpCountStr.IntToFormat((long)registerCount, 1, false);
			this.SignUpCountStr.AppendFormat(this.DM.mStringTable.GetStringByID(1340u));
			this.SignUpCount.text = this.SignUpCountStr.ToString();
			this.SignUpCount.SetAllDirty();
			this.SignUpCount.cachedTextGenerator.Invalidate();
			this.Check1GO.SetActive(false);
			this.Check2GO.SetActive(false);
			this.MessageText1.gameObject.SetActive(false);
			this.MessageText2.gameObject.SetActive(false);
			if (this.AM.AW_State == EAllianceWarState.EAWS_SignUp)
			{
				if (this.DM.RoleAlliance.Id == 0u)
				{
					this.Check2GO.SetActive(true);
				}
				else if (registerCount >= this.AM.AW_MemberCount)
				{
					this.Check1GO.SetActive(true);
					this.MessageText2.gameObject.SetActive(true);
					this.MessageText2Str.Length = 0;
					this.MessageText2Str.IntToFormat((long)this.AM.AW_MemberCount, 1, false);
					this.MessageText2Str.AppendFormat(this.DM.mStringTable.GetStringByID(17038u));
					this.MessageText2.text = this.MessageText2Str.ToString();
					this.MessageText2.SetAllDirty();
					this.MessageText2.cachedTextGenerator.Invalidate();
				}
				else
				{
					this.MessageText1.gameObject.SetActive(true);
					this.MessageText1Str.Length = 0;
					this.MessageText1Str.IntToFormat((long)this.AM.AW_MemberCount, 1, false);
					this.MessageText1Str.AppendFormat(this.DM.mStringTable.GetStringByID(17003u));
					this.MessageText1.text = this.MessageText1Str.ToString();
					this.MessageText1.SetAllDirty();
					this.MessageText1.cachedTextGenerator.Invalidate();
				}
			}
			else if (this.DM.RoleAlliance.Id == 0u)
			{
				this.Check2GO.SetActive(true);
			}
			else if (registerCount < this.AM.AW_MemberCount)
			{
				this.Check2GO.SetActive(true);
				this.MessageText2.gameObject.SetActive(true);
				this.MessageText2Str.Length = 0;
				this.MessageText2Str.IntToFormat((long)this.AM.AW_MemberCount, 1, false);
				this.MessageText2Str.AppendFormat(this.DM.mStringTable.GetStringByID(17003u));
				this.MessageText2.text = this.MessageText2Str.ToString();
				this.MessageText2.SetAllDirty();
				this.MessageText2.cachedTextGenerator.Invalidate();
			}
			else
			{
				this.Check1GO.SetActive(true);
				this.MessageText2.gameObject.SetActive(true);
				this.MessageText2Str.Length = 0;
				this.MessageText2Str.IntToFormat((long)this.AM.AW_MemberCount, 1, false);
				this.MessageText2Str.AppendFormat(this.DM.mStringTable.GetStringByID(17038u));
				this.MessageText2.text = this.MessageText2Str.ToString();
				this.MessageText2.SetAllDirty();
				this.MessageText2.cachedTextGenerator.Invalidate();
			}
		}
		else if (this.WindowType == e_ActivityType.Run || this.WindowType == e_ActivityType.RunFail)
		{
			this.SetRoundText();
			if (this.AWM.bReplaying)
			{
				this.FTimeText.text = string.Empty;
			}
			else
			{
				this.SetTopTime();
			}
			if (this.AWM.MyPosition != 0)
			{
				if (this.AWM.MyAllySide == 2)
				{
					this.MyNoText.rectTransform.anchoredPosition = this.RightPos;
				}
				this.MyNoTextStr.Length = 0;
				this.MyNoTextStr.IntToFormat((long)this.AWM.MyPosition, 1, false);
				this.MyNoTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(14610u));
				this.MyNoText.text = this.MyNoTextStr.ToString();
				this.MyNoText.SetAllDirty();
				this.MyNoText.cachedTextGenerator.Invalidate();
			}
			else
			{
				this.MyNoText.text = string.Empty;
			}
		}
		else if (this.WindowType == e_ActivityType.Ranking)
		{
			this.No2Text.gameObject.SetActive(true);
			if (this.DM.RoleAlliance.Id == 0u)
			{
				this.No1Text.text = this.DM.mStringTable.GetStringByID(1594u);
				this.No2Text.gameObject.SetActive(false);
				this.SBtnGO.SetActive(false);
			}
			else if (this.AM.AW_NowAllianceEnterWar == 0)
			{
				this.No1Text.text = this.DM.mStringTable.GetStringByID(17022u);
				this.No2TextStr.Length = 0;
				this.No2TextStr.IntToFormat((long)this.AM.AW_NextRank, 1, false);
				if (this.AM.AW_NextRank > this.AM.AW_Rank)
				{
					this.No2TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17071u));
				}
				else if (this.AM.AW_NextRank == this.AM.AW_Rank)
				{
					this.No2TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17073u));
				}
				else
				{
					this.No2TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17072u));
				}
				this.No2Text.text = this.No2TextStr.ToString();
				this.No2Text.SetAllDirty();
				this.No2Text.cachedTextGenerator.Invalidate();
				this.SBtnGO.SetActive(false);
			}
			else
			{
				this.No1TextStr.Length = 0;
				this.No1TextStr.IntToFormat((long)LeaderBoardManager.Instance.AllianceWarGroupRank, 1, false);
				this.No1TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17021u));
				this.No1Text.text = this.No1TextStr.ToString();
				this.No1Text.SetAllDirty();
				this.No1Text.cachedTextGenerator.Invalidate();
				this.No2TextStr.Length = 0;
				this.No2TextStr.IntToFormat((long)this.AM.AW_NextRank, 1, false);
				if (this.AM.AW_NextRank > this.AM.AW_Rank)
				{
					this.No2TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17071u));
				}
				else if (this.AM.AW_NextRank == this.AM.AW_Rank)
				{
					this.No2TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17073u));
				}
				else
				{
					this.No2TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17072u));
				}
				this.No2Text.text = this.No2TextStr.ToString();
				this.No2Text.SetAllDirty();
				this.No2Text.cachedTextGenerator.Invalidate();
				if (!this.AM.AW_bcalculateEnd)
				{
					this.No1Text.text = this.DM.mStringTable.GetStringByID(14613u);
					this.No2Text.gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x0600291B RID: 10523 RVA: 0x0044E0DC File Offset: 0x0044C2DC
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID != 1)
		{
			if (btnID == 2)
			{
				if (sender.m_BtnID2 == 1)
				{
					if (!this.AM.AW_bcalculateEnd)
					{
						this.GM.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14613u), 255, true);
						return;
					}
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.AddSeqId();
					messagePacket.Protocol = Protocol._MSG_REQUEST_AWS_SCHEDULE;
					messagePacket.Add(ActivityManager.Instance.AW_Round);
					messagePacket.Send(false);
					GUIManager.Instance.ShowUILock(EUILock.AWS_Schedule);
				}
			}
		}
		else if (sender.m_BtnID2 == 1)
		{
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
		}
		else if (sender.m_BtnID2 == 2 && this.door != null)
		{
			this.door.OpenMenu(EGUIWindow.UI_AllianceMatchInfo, 0, 0, false);
		}
	}

	// Token: 0x0600291C RID: 10524 RVA: 0x0044E1F0 File Offset: 0x0044C3F0
	public void OnButtonDown(UIButtonHint sender)
	{
		if (this.DM.RoleAlliance.Id == 0u)
		{
			return;
		}
		if (this.HintStr == null)
		{
			this.HintStr = this.SM.SpawnString(200);
		}
		this.HintStr.Length = 0;
		if (sender.Parm1 == 0)
		{
			this.HintStr.IntToFormat((long)this.AM.AW_Rank, 1, false);
			this.HintStr.IntToFormat((long)this.AM.AW_MemberCount, 1, false);
			this.HintStr.AppendFormat(this.DM.mStringTable.GetStringByID(17074u));
		}
		else
		{
			this.HintStr.IntToFormat((long)this.AM.AllianceWarMgr.GetRegisterCount(), 1, false);
			this.HintStr.AppendFormat(this.DM.mStringTable.GetStringByID(17002u));
		}
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.HintStr, Vector2.zero);
	}

	// Token: 0x0600291D RID: 10525 RVA: 0x0044E308 File Offset: 0x0044C508
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(false);
	}

	// Token: 0x0600291E RID: 10526 RVA: 0x0044E31C File Offset: 0x0044C51C
	public void UpdateTime()
	{
		if (this.tmpData == null || this.tmpData.EventState == EActivityState.EAS_None)
		{
			return;
		}
		this.SetTimeStr();
		this.SetTopTime();
	}

	// Token: 0x0600291F RID: 10527 RVA: 0x0044E354 File Offset: 0x0044C554
	public void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_FontTextureRebuilt:
			for (int i = 0; i < this.rebuildText.Count; i++)
			{
				if (this.rebuildText[i] != null && this.rebuildText[i].enabled)
				{
					this.rebuildText[i].enabled = false;
					this.rebuildText[i].enabled = true;
				}
			}
			break;
		default:
			if (networkNews != NetworkNews.Login)
			{
			}
			break;
		case NetworkNews.Refresh_AllianceWarState:
			if (this.m_handler != null)
			{
				this.m_handler.OnStateChange(this.AM.AW_StateOld, this.AM.AW_State);
			}
			if (this.tmpData != null && this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
			{
				this.SetRoundText();
			}
			this.SetTimeTitle();
			this.RefreshTop();
			break;
		case NetworkNews.Refresh_AllianceWarRound:
			if (this.tmpData != null && this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
			{
				this.SetRoundText();
				this.SetTopTime();
			}
			break;
		}
	}

	// Token: 0x06002920 RID: 10528 RVA: 0x0044E490 File Offset: 0x0044C690
	public void RefreshTop()
	{
		this.SetTimeTitle();
		this.SetTitleRank();
		this.SetTopText();
	}

	// Token: 0x06002921 RID: 10529 RVA: 0x0044E4A4 File Offset: 0x0044C6A4
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x04007362 RID: 29538
	private Transform m_transform;

	// Token: 0x04007363 RID: 29539
	private string abName = "UI/ActivityWindow";

	// Token: 0x04007364 RID: 29540
	private int abKey;

	// Token: 0x04007365 RID: 29541
	private Door door;

	// Token: 0x04007366 RID: 29542
	private GUIManager GM;

	// Token: 0x04007367 RID: 29543
	private DataManager DM;

	// Token: 0x04007368 RID: 29544
	private ActivityManager AM;

	// Token: 0x04007369 RID: 29545
	private StringManager SM;

	// Token: 0x0400736A RID: 29546
	private AllianceWarManager AWM;

	// Token: 0x0400736B RID: 29547
	private e_ActivityType WindowType;

	// Token: 0x0400736C RID: 29548
	private IActivityWindow m_handler;

	// Token: 0x0400736D RID: 29549
	private ActivityDataType tmpData;

	// Token: 0x0400736E RID: 29550
	private CString HintStr;

	// Token: 0x0400736F RID: 29551
	private GameObject Title1GO;

	// Token: 0x04007370 RID: 29552
	private GameObject Title2GO;

	// Token: 0x04007371 RID: 29553
	private UIText TitleRankText;

	// Token: 0x04007372 RID: 29554
	private UIText Title2Text;

	// Token: 0x04007373 RID: 29555
	private CString TitleRankTextStr;

	// Token: 0x04007374 RID: 29556
	private GameObject TimeGO;

	// Token: 0x04007375 RID: 29557
	private GameObject InfoGO;

	// Token: 0x04007376 RID: 29558
	private UISpritesArray TimeSA;

	// Token: 0x04007377 RID: 29559
	private UISpritesArray TitleSA1;

	// Token: 0x04007378 RID: 29560
	private UISpritesArray TitleSA2;

	// Token: 0x04007379 RID: 29561
	private UIText TimeTitle;

	// Token: 0x0400737A RID: 29562
	private UIText TimeTitle2;

	// Token: 0x0400737B RID: 29563
	private UIText TimeText;

	// Token: 0x0400737C RID: 29564
	private CString TimeStr;

	// Token: 0x0400737D RID: 29565
	private GameObject Check1GO;

	// Token: 0x0400737E RID: 29566
	private GameObject Check2GO;

	// Token: 0x0400737F RID: 29567
	private UIText SignUpCount;

	// Token: 0x04007380 RID: 29568
	private UIText MessageText1;

	// Token: 0x04007381 RID: 29569
	private UIText MessageText2;

	// Token: 0x04007382 RID: 29570
	private CString SignUpCountStr;

	// Token: 0x04007383 RID: 29571
	private CString MessageText1Str;

	// Token: 0x04007384 RID: 29572
	private CString MessageText2Str;

	// Token: 0x04007385 RID: 29573
	private Vector2 RightPos = new Vector2(316.6f, 127.3f);

	// Token: 0x04007386 RID: 29574
	private UIText MyNoText;

	// Token: 0x04007387 RID: 29575
	private UIText StageText;

	// Token: 0x04007388 RID: 29576
	private UIText FTimeText;

	// Token: 0x04007389 RID: 29577
	private UIText ReviewText;

	// Token: 0x0400738A RID: 29578
	private CString MyNoTextStr;

	// Token: 0x0400738B RID: 29579
	private CString FTimeTextStr;

	// Token: 0x0400738C RID: 29580
	private GameObject Review1GO;

	// Token: 0x0400738D RID: 29581
	private GameObject Review2GO;

	// Token: 0x0400738E RID: 29582
	private GameObject BtnGO;

	// Token: 0x0400738F RID: 29583
	private UIText No1Text;

	// Token: 0x04007390 RID: 29584
	private UIText No2Text;

	// Token: 0x04007391 RID: 29585
	private CString No1TextStr;

	// Token: 0x04007392 RID: 29586
	private CString No2TextStr;

	// Token: 0x04007393 RID: 29587
	private GameObject SBtnGO;

	// Token: 0x04007394 RID: 29588
	private List<UIText> rebuildText = new List<UIText>();
}
