using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006C5 RID: 1733
public class UI_AlliWarSchedule : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06002143 RID: 8515 RVA: 0x003F4FDC File Offset: 0x003F31DC
	public override void OnOpen(int arg1, int arg2)
	{
		this.door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		this.AGS_SpriteArray = this.AGS_Form.GetChild(0).GetComponent<UISpritesArray>();
		this.AGS_SpriteArray2 = this.AGS_Form.GetChild(1).GetComponent<UISpritesArray>();
		this.WinnerEff.IO = 0;
		this.WinnerEff.EffectNode1 = this.AGS_Form.GetChild(2).GetChild(0);
		this.WinnerEff.RotateingLight = this.WinnerEff.EffectNode1.GetChild(2);
		this.WinnerEff.RotateingLight.GetComponent<Image>().color = new Color32(byte.MaxValue, 216, 98, byte.MaxValue);
		this.WinnerEff.EffectNode2 = this.AGS_Form.GetChild(2).GetChild(9);
		this.WinnerEff.lightBox = this.WinnerEff.EffectNode2.GetComponent<Image>();
		this.WinnerEff.lightBoxStep = -1;
		this.WinnerEff.EffectNode1.localScale = Vector3.zero;
		this.WinnerEff.EffectNode2.localScale = Vector3.zero;
		for (int i = 0; i < 16; i++)
		{
			UI_AlliWarSchedule.AWS_NodeData aws_NodeData = this.InitNode(this.Top16Nodes, i, this.AGS_Form.GetChild(2).GetChild(1));
		}
		for (int j = 0; j < 8; j++)
		{
			UI_AlliWarSchedule.AWS_NodeData aws_NodeData2 = this.InitNode(this.Top8Nodes, j, this.AGS_Form.GetChild(2).GetChild(2));
			this.InitLine(this.Top16Lines, j, this.Top16Nodes, (byte)j, null, this.AGS_Form.GetChild(2).GetChild(5), UI_AlliWarSchedule.EAWSLineStyle.Vertical);
		}
		for (int k = 0; k < 4; k++)
		{
			UI_AlliWarSchedule.AWS_NodeData aws_NodeData3 = this.InitNode(this.Top4Nodes, k, this.AGS_Form.GetChild(2).GetChild(3));
			this.InitLine(this.Top8Lines, k, this.Top8Nodes, (byte)(8 + k), this.Top16Lines, this.AGS_Form.GetChild(2).GetChild(6), UI_AlliWarSchedule.EAWSLineStyle.Vertical);
		}
		for (int l = 0; l < 2; l++)
		{
			UI_AlliWarSchedule.AWS_NodeData aws_NodeData4 = this.InitNode(this.Top2Nodes, l, this.AGS_Form.GetChild(2).GetChild(4));
			this.InitLine(this.Top4Lines, l, this.Top4Nodes, (byte)(12 + l), this.Top8Lines, this.AGS_Form.GetChild(2).GetChild(7), UI_AlliWarSchedule.EAWSLineStyle.Horizontal);
		}
		this.InitLine(this.Top2Lines, 0, this.Top2Nodes, 14, this.Top4Lines, this.AGS_Form.GetChild(2).GetChild(8), UI_AlliWarSchedule.EAWSLineStyle.Vertical);
		this.Top2Lines[0].Score.rectTransform.localPosition = new Vector3(this.Top2Lines[0].Score.rectTransform.localPosition.x, this.Top2Lines[0].Score.rectTransform.localPosition.y - 2f, this.Top2Lines[0].Score.rectTransform.localPosition.z);
		this.Notes = this.AGS_Form.GetChild(2).GetChild(10).GetComponent<UIText>();
		this.Notes.font = ttffont;
		this.Title = this.AGS_Form.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.Title.font = ttffont;
		this.Title.text = DataManager.Instance.mStringTable.GetStringByID(17501u);
		Image component = this.AGS_Form.GetChild(4).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = this.door.LoadMaterial();
		component.enabled = !GUIManager.Instance.bOpenOnIPhoneX;
		component = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close");
		component.material = this.door.LoadMaterial();
		UIButton component2 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 0;
		component2.transition = Selectable.Transition.None;
		component2.m_EffectType = e_EffectType.e_Scale;
		for (int m = 0; m < 15; m++)
		{
			UIButton component3 = this.AGS_Form.GetChild(2).GetChild(11).GetChild(m).GetComponent<UIButton>();
			component3.m_BtnID1 = 1 + m;
			component3.m_Handler = this;
		}
		this.RefreshData();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		ActivityManager instance = ActivityManager.Instance;
		if (this.door != null && (instance.AW_State == EAllianceWarState.EAWS_None || DataManager.Instance.RoleAlliance.Id == 0u))
		{
			this.bExit = true;
			return;
		}
		byte b = (instance.AW_Round != 0) ? (instance.AW_Round - 1) : 5;
		if (b != (byte)UI_AlliWarSchedule.Step)
		{
			UI_AlliWarSchedule.RequestScheduleData();
		}
	}

	// Token: 0x06002144 RID: 8516 RVA: 0x003F5550 File Offset: 0x003F3750
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_FontTextureRebuilt:
			this.Refresh_FontTexture();
			break;
		default:
			if (networkNews == NetworkNews.Login)
			{
				if ((ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None || DataManager.Instance.RoleAlliance.Id == 0u) && this.door != null)
				{
					this.door.CloseMenu(false);
				}
			}
			break;
		case NetworkNews.Refresh_AllianceWarRound:
			UI_AlliWarSchedule.RequestScheduleData();
			break;
		case NetworkNews.Refresh_RecvAllianceInfo:
			UI_AlliWarSchedule.RequestScheduleData();
			break;
		}
	}

	// Token: 0x06002145 RID: 8517 RVA: 0x003F55F0 File Offset: 0x003F37F0
	private UI_AlliWarSchedule.AWS_NodeData InitNode(UI_AlliWarSchedule.AWS_NodeData[] container, int index, Transform nodeTrans)
	{
		UI_AlliWarSchedule.AWS_NodeData aws_NodeData = new UI_AlliWarSchedule.AWS_NodeData();
		aws_NodeData.AlliTag = nodeTrans.GetChild(index).GetChild(2).GetComponent<UIText>();
		aws_NodeData.AlliTag.font = GUIManager.Instance.GetTTFFont();
		aws_NodeData.StrNone = nodeTrans.GetChild(index).GetChild(3).GetComponent<UIText>();
		aws_NodeData.StrNone.font = GUIManager.Instance.GetTTFFont();
		aws_NodeData.StrNone.text = DataManager.Instance.mStringTable.GetStringByID(17505u);
		aws_NodeData.IconBackObj = nodeTrans.GetChild(index).GetChild(1).gameObject;
		aws_NodeData.ElbemTrans = (aws_NodeData.IconBackObj.transform.GetChild(0) as RectTransform);
		aws_NodeData.ImgUnknown = nodeTrans.GetChild(index).GetChild(0).GetComponent<Image>();
		RectTransform rectTransform = aws_NodeData.ImgUnknown.transform as RectTransform;
		if (rectTransform != null)
		{
			rectTransform.sizeDelta = aws_NodeData.ElbemTrans.sizeDelta;
		}
		aws_NodeData.Mask = nodeTrans.GetChild(index).GetChild(4).GetComponent<Image>();
		aws_NodeData.NodeBack = nodeTrans.GetChild(index).GetComponent<Image>();
		aws_NodeData.Mask.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 128);
		container[index] = aws_NodeData;
		return aws_NodeData;
	}

	// Token: 0x06002146 RID: 8518 RVA: 0x003F5750 File Offset: 0x003F3950
	private void SetupNode(ref UI_AlliWarSchedule.AWS_NodeData _node, UI_AlliWarSchedule.EAWSNodeState state, bool highlight = true, int dataindex = 0)
	{
		switch (state)
		{
		case UI_AlliWarSchedule.EAWSNodeState.Normal:
		{
			if (DataManager.Instance.RoleAlliance.Id == UI_AlliWarSchedule.AllianceData[dataindex].ID)
			{
				_node.NodeBack.sprite = this.AGS_SpriteArray.GetSprite(2);
			}
			else
			{
				_node.NodeBack.sprite = this.AGS_SpriteArray.GetSprite(1);
			}
			_node.IconBackObj.SetActive(true);
			if (_node.ElbemTrans.childCount == 0)
			{
				GUIManager.Instance.InitBadgeTotem(_node.ElbemTrans, UI_AlliWarSchedule.AllianceData[dataindex].Emblem);
			}
			else
			{
				GUIManager.Instance.SetBadgeTotemImg(_node.ElbemTrans, UI_AlliWarSchedule.AllianceData[dataindex].Emblem);
			}
			RectTransform rectTransform = _node.ElbemTrans.GetChild(0) as RectTransform;
			if (rectTransform != null)
			{
				rectTransform.sizeDelta = _node.ElbemTrans.sizeDelta;
			}
			_node.AlliTag.enabled = true;
			_node.AlliTag.text = UI_AlliWarSchedule.AllianceData[dataindex].Tag;
			_node.StrNone.enabled = false;
			_node.ImgUnknown.enabled = false;
			break;
		}
		case UI_AlliWarSchedule.EAWSNodeState.UnKnown:
			_node.NodeBack.sprite = this.AGS_SpriteArray.GetSprite(0);
			_node.IconBackObj.SetActive(false);
			_node.AlliTag.enabled = false;
			_node.StrNone.enabled = false;
			_node.ImgUnknown.enabled = true;
			break;
		case UI_AlliWarSchedule.EAWSNodeState.NoAlliance:
			_node.NodeBack.sprite = this.AGS_SpriteArray.GetSprite(1);
			_node.IconBackObj.SetActive(false);
			_node.AlliTag.enabled = false;
			_node.StrNone.enabled = true;
			_node.ImgUnknown.enabled = false;
			break;
		default:
			_node.NodeBack.sprite = this.AGS_SpriteArray.GetSprite(0);
			_node.IconBackObj.SetActive(false);
			_node.AlliTag.enabled = false;
			_node.StrNone.enabled = false;
			_node.ImgUnknown.enabled = false;
			break;
		}
		_node.Mask.enabled = !highlight;
		_node.State = state;
	}

	// Token: 0x06002147 RID: 8519 RVA: 0x003F59BC File Offset: 0x003F3BBC
	private UI_AlliWarSchedule.AWS_LineData InitLine(UI_AlliWarSchedule.AWS_LineData[] container, int index, UI_AlliWarSchedule.AWS_NodeData[] childnodes, byte fightDataIndex, UI_AlliWarSchedule.AWS_LineData[] childlines, Transform lineTrans, UI_AlliWarSchedule.EAWSLineStyle style)
	{
		UI_AlliWarSchedule.AWS_LineData aws_LineData = new UI_AlliWarSchedule.AWS_LineData();
		aws_LineData.Style = style;
		aws_LineData.Score = lineTrans.GetChild(index).GetChild(1).GetComponent<UIText>();
		aws_LineData.Score.font = GUIManager.Instance.GetTTFFont();
		aws_LineData.ImgVS = lineTrans.GetChild(index).GetChild(0).GetComponent<Image>();
		if (GUIManager.Instance.IsArabic)
		{
			aws_LineData.ImgVS.rectTransform.localScale = new Vector3(-aws_LineData.ImgVS.rectTransform.localScale.x, aws_LineData.ImgVS.rectTransform.localScale.y, aws_LineData.ImgVS.rectTransform.localScale.z);
		}
		aws_LineData.Line = lineTrans.GetChild(index).GetComponent<Image>();
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			aws_LineData.ImgVS.sprite = this.AGS_SpriteArray2.GetSprite(1);
		}
		aws_LineData.Node1 = childnodes[index * 2];
		aws_LineData.Node2 = childnodes[index * 2 + 1];
		aws_LineData.ChildLine1 = ((childlines != null) ? childlines[index * 2] : null);
		aws_LineData.ChildLine2 = ((childlines != null) ? childlines[index * 2 + 1] : null);
		aws_LineData.FightDataIndex = fightDataIndex;
		aws_LineData.StrScore = new CString(10);
		container[index] = aws_LineData;
		return aws_LineData;
	}

	// Token: 0x06002148 RID: 8520 RVA: 0x003F5B2C File Offset: 0x003F3D2C
	private void SetupLine(ref UI_AlliWarSchedule.AWS_LineData _node, UI_AlliWarSchedule.EAWSLineState state, int fightDataIndex = 0)
	{
		switch (state)
		{
		case UI_AlliWarSchedule.EAWSLineState.VS:
			if (_node.Line.color.a != 0)
			{
				_node.Line.color = new Color32(93, 187, 236, byte.MaxValue);
			}
			_node.Score.enabled = false;
			_node.ImgVS.enabled = true;
			_node.State = UI_AlliWarSchedule.EAWSLineState.VS;
			return;
		case UI_AlliWarSchedule.EAWSLineState.Score:
			if (_node.Line.color.a != 0)
			{
				_node.Line.color = new Color32(108, 118, 126, byte.MaxValue);
			}
			if (UI_AlliWarSchedule.FightData[fightDataIndex].Score1 != 0 || UI_AlliWarSchedule.FightData[fightDataIndex].Score2 != 0)
			{
				_node.StrScore.ClearString();
				_node.StrScore.IntToFormat((long)UI_AlliWarSchedule.FightData[fightDataIndex].Score1, 1, false);
				_node.StrScore.IntToFormat((long)UI_AlliWarSchedule.FightData[fightDataIndex].Score2, 1, false);
				if (_node.Style == UI_AlliWarSchedule.EAWSLineStyle.Vertical)
				{
					_node.StrScore.AppendFormat("{0}\n|\n{1}");
				}
				else if (GUIManager.Instance.IsArabic)
				{
					_node.StrScore.AppendFormat("{1}─{0}");
				}
				else
				{
					_node.StrScore.AppendFormat("{0}─{1}");
				}
				_node.Score.text = _node.StrScore.ToString();
			}
			else
			{
				_node.Score.text = string.Empty;
			}
			_node.Score.enabled = true;
			_node.ImgVS.enabled = false;
			_node.State = UI_AlliWarSchedule.EAWSLineState.Score;
			return;
		case UI_AlliWarSchedule.EAWSLineState.EmptyLightLine:
			if (_node.Line.color.a != 0)
			{
				_node.Line.color = new Color32(93, 187, 236, byte.MaxValue);
			}
			_node.Score.enabled = false;
			_node.ImgVS.enabled = false;
			_node.State = UI_AlliWarSchedule.EAWSLineState.Empty;
			return;
		}
		if (_node.Line.color.a != 0)
		{
			_node.Line.color = new Color32(108, 118, 126, byte.MaxValue);
		}
		_node.Score.enabled = false;
		_node.ImgVS.enabled = false;
		_node.State = UI_AlliWarSchedule.EAWSLineState.Empty;
	}

	// Token: 0x06002149 RID: 8521 RVA: 0x003F5DF8 File Offset: 0x003F3FF8
	private void RefreshData()
	{
		for (int i = 0; i < 8; i++)
		{
			this.RefreshNode(0, i, this.Top16Nodes, this.Top16Lines);
		}
		for (int j = 0; j < 4; j++)
		{
			this.RefreshNode(1, j, this.Top8Nodes, this.Top8Lines);
		}
		for (int k = 0; k < 2; k++)
		{
			this.RefreshNode(2, k, this.Top4Nodes, this.Top4Lines);
		}
		this.RefreshNode(3, 0, this.Top2Nodes, this.Top2Lines);
		if (UI_AlliWarSchedule.Step == UI_AlliWarSchedule.EAWSFightStep.Final)
		{
			if (UI_AlliWarSchedule.FightData[14].Winner == 1)
			{
				this.SetupWinnerEffect(true, 0);
			}
			else if (UI_AlliWarSchedule.FightData[14].Winner == 2)
			{
				this.SetupWinnerEffect(true, 1);
			}
			else
			{
				this.SetupWinnerEffect(false, 0);
			}
			this.Notes.text = DataManager.Instance.mStringTable.GetStringByID(17506u);
		}
		else
		{
			this.SetupWinnerEffect(false, 0);
			this.Notes.text = DataManager.Instance.mStringTable.GetStringByID(17504u);
		}
	}

	// Token: 0x0600214A RID: 8522 RVA: 0x003F5F34 File Offset: 0x003F4134
	private void RefreshNode(byte level, int LineIdx, UI_AlliWarSchedule.AWS_NodeData[] nodes, UI_AlliWarSchedule.AWS_LineData[] lines)
	{
		int num = LineIdx * 2;
		int fightDataIndex = (int)lines[LineIdx].FightDataIndex;
		UI_AlliWarSchedule.AWS_LineData childLine = lines[LineIdx].ChildLine1;
		UI_AlliWarSchedule.AWS_LineData childLine2 = lines[LineIdx].ChildLine2;
		UI_AlliWarSchedule.EAWSLineState eawslineState;
		if (UI_AlliWarSchedule.FightData[fightDataIndex].Winner != 0)
		{
			eawslineState = UI_AlliWarSchedule.EAWSLineState.Score;
		}
		else if (level > (byte)UI_AlliWarSchedule.Step)
		{
			eawslineState = UI_AlliWarSchedule.EAWSLineState.Empty;
		}
		else
		{
			eawslineState = UI_AlliWarSchedule.EAWSLineState.VS;
		}
		bool highlight = false;
		if (UI_AlliWarSchedule.Step == UI_AlliWarSchedule.EAWSFightStep.Final || (level == 3 && eawslineState == UI_AlliWarSchedule.EAWSLineState.Score))
		{
			highlight = true;
		}
		else if ((byte)UI_AlliWarSchedule.Step <= level)
		{
			highlight = true;
		}
		if (eawslineState == UI_AlliWarSchedule.EAWSLineState.Empty)
		{
			if ((childLine != null && (childLine.Node1.State == UI_AlliWarSchedule.EAWSNodeState.UnKnown || childLine.Node1.State == UI_AlliWarSchedule.EAWSNodeState.Empty)) || (childLine2 != null && (childLine2.Node2.State == UI_AlliWarSchedule.EAWSNodeState.UnKnown || childLine2.Node2.State == UI_AlliWarSchedule.EAWSNodeState.Empty)))
			{
				this.SetupNode(ref nodes[num], UI_AlliWarSchedule.EAWSNodeState.Empty, highlight, 0);
				this.SetupNode(ref nodes[num + 1], UI_AlliWarSchedule.EAWSNodeState.Empty, highlight, 0);
			}
			else
			{
				this.SetupNode(ref nodes[num], UI_AlliWarSchedule.EAWSNodeState.UnKnown, highlight, 0);
				this.SetupNode(ref nodes[num + 1], UI_AlliWarSchedule.EAWSNodeState.UnKnown, highlight, 0);
			}
		}
		else
		{
			if (UI_AlliWarSchedule.AllianceData[(int)UI_AlliWarSchedule.FightData[fightDataIndex].Alliance1Index].ID != 0u)
			{
				this.SetupNode(ref nodes[num], UI_AlliWarSchedule.EAWSNodeState.Normal, highlight, (int)UI_AlliWarSchedule.FightData[fightDataIndex].Alliance1Index);
			}
			else
			{
				this.SetupNode(ref nodes[num], UI_AlliWarSchedule.EAWSNodeState.NoAlliance, highlight, (int)UI_AlliWarSchedule.FightData[fightDataIndex].Alliance1Index);
			}
			if (UI_AlliWarSchedule.AllianceData[(int)UI_AlliWarSchedule.FightData[fightDataIndex].Alliance2Index].ID != 0u)
			{
				this.SetupNode(ref nodes[num + 1], UI_AlliWarSchedule.EAWSNodeState.Normal, highlight, (int)UI_AlliWarSchedule.FightData[fightDataIndex].Alliance2Index);
			}
			else
			{
				this.SetupNode(ref nodes[num + 1], UI_AlliWarSchedule.EAWSNodeState.NoAlliance, highlight, (int)UI_AlliWarSchedule.FightData[fightDataIndex].Alliance2Index);
			}
		}
		if (eawslineState == UI_AlliWarSchedule.EAWSLineState.VS && nodes[num].StrNone.enabled && nodes[num + 1].StrNone.enabled)
		{
			if ((byte)UI_AlliWarSchedule.Step == level)
			{
				eawslineState = UI_AlliWarSchedule.EAWSLineState.EmptyLightLine;
			}
			else
			{
				eawslineState = UI_AlliWarSchedule.EAWSLineState.Empty;
			}
		}
		this.SetupLine(ref lines[LineIdx], eawslineState, fightDataIndex);
	}

	// Token: 0x0600214B RID: 8523 RVA: 0x003F61A0 File Offset: 0x003F43A0
	private void SetupWinnerEffect(bool show, int posidx)
	{
		if (show)
		{
			this.WinnerEff.IO = 1;
			this.WinnerEff.EffectNode1.localScale = Vector3.one;
			this.WinnerEff.EffectNode2.localScale = Vector3.one;
			this.WinnerEff.EffectNode1.localPosition = this.Top2Nodes[posidx].NodeBack.transform.localPosition;
			this.WinnerEff.EffectNode2.localPosition = this.Top2Nodes[posidx].NodeBack.transform.localPosition;
		}
		else
		{
			this.WinnerEff.IO = 0;
			this.WinnerEff.EffectNode1.localScale = Vector3.zero;
			this.WinnerEff.EffectNode2.localScale = Vector3.zero;
		}
	}

	// Token: 0x0600214C RID: 8524 RVA: 0x003F6274 File Offset: 0x003F4474
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			this.door.CloseMenu(false);
			break;
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		{
			int num = this.BtnIndexToLevel[sender.m_BtnID1 - 1];
			if (UI_AlliWarSchedule.Step == UI_AlliWarSchedule.EAWSFightStep.Final || num == (int)UI_AlliWarSchedule.Step)
			{
				UI_AlliWarSchedule.AWS_AlliData aws_AlliData = UI_AlliWarSchedule.AllianceData[(int)UI_AlliWarSchedule.FightData[sender.m_BtnID1 - 1].Alliance1Index];
				UI_AlliWarSchedule.AWS_AlliData aws_AlliData2 = UI_AlliWarSchedule.AllianceData[(int)UI_AlliWarSchedule.FightData[sender.m_BtnID1 - 1].Alliance2Index];
				if (aws_AlliData.ID != 0u || aws_AlliData2.ID != 0u)
				{
					byte b = (byte)UI_AlliWarSchedule.LinePos_C2S[sender.m_BtnID1 - 1];
					if (UI_AlliWarSchedule.Step != UI_AlliWarSchedule.EAWSFightStep.Final)
					{
						if (aws_AlliData.ID == 0u || aws_AlliData2.ID == 0u)
						{
							this.HudStr.ClearString();
							this.HudStr.StringToFormat((aws_AlliData.ID != 0u) ? aws_AlliData.Tag : aws_AlliData2.Tag);
							this.HudStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17507u));
							GUIManager.Instance.AddHUDMessage(this.HudStr.ToString(), 255, true);
						}
						else
						{
							uint id = DataManager.Instance.RoleAlliance.Id;
							if (id == aws_AlliData.ID || id == aws_AlliData2.ID)
							{
								b = 0;
								if (GUIManager.Instance.bCheckAWSSchedule)
								{
									GUIManager.Instance.OpenCheckAWSSchedule(DataManager.Instance.mStringTable.GetStringByID(17502u), b);
								}
								else
								{
									this.RequestPlayWar(b);
								}
							}
							else
							{
								this.MsgStr.ClearString();
								this.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(this.LevelToStr[(int)UI_AlliWarSchedule.Step]));
								this.MsgStr.StringToFormat(aws_AlliData.Tag);
								this.MsgStr.StringToFormat(aws_AlliData2.Tag);
								this.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17503u));
								if (GUIManager.Instance.bCheckAWSSchedule)
								{
									GUIManager.Instance.OpenCheckAWSSchedule(this.MsgStr.ToString(), b);
								}
								else
								{
									this.RequestPlayWar(b);
								}
							}
						}
					}
					else if (aws_AlliData.ID == 0u || aws_AlliData2.ID == 0u)
					{
						this.HudStr.ClearString();
						this.HudStr.StringToFormat((aws_AlliData.ID != 0u) ? aws_AlliData.Tag : aws_AlliData2.Tag);
						this.HudStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17507u));
						GUIManager.Instance.AddHUDMessage(this.HudStr.ToString(), 255, true);
					}
					else if (GUIManager.Instance.bCheckAWSSchedule)
					{
						this.MsgStr.ClearString();
						int num2 = this.BtnIndexToLevel[sender.m_BtnID1 - 1];
						this.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(this.LevelToStr[num2]));
						this.MsgStr.StringToFormat(aws_AlliData.Tag);
						this.MsgStr.StringToFormat(aws_AlliData2.Tag);
						this.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17503u));
						GUIManager.Instance.OpenCheckAWSSchedule(this.MsgStr.ToString(), b);
					}
					else
					{
						this.RequestPlayWar(b);
					}
				}
			}
			break;
		}
		}
	}

	// Token: 0x0600214D RID: 8525 RVA: 0x003F6688 File Offset: 0x003F4888
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 0:
			this.RefreshData();
			break;
		case 1:
			this.RequestPlayWar((byte)arg2);
			break;
		case 2:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		}
	}

	// Token: 0x0600214E RID: 8526 RVA: 0x003F66E8 File Offset: 0x003F48E8
	private void Update()
	{
		if (this.bExit && this.door != null)
		{
			this.door.CloseMenu(false);
			this.bExit = false;
			return;
		}
		if (this.WinnerEff.IO != 0)
		{
			if (this.WinnerEff.RotateingLight != null)
			{
				this.WinnerEff.RotateingLight.Rotate(0f, 0f, Time.deltaTime * 20f, Space.Self);
			}
			if (this.WinnerEff.lightBox != null)
			{
				Color color = this.WinnerEff.lightBox.color;
				float num = color.a;
				num += (float)this.WinnerEff.lightBoxStep * Time.deltaTime * 0.5f;
				if (num < 0.3f || num > 1f)
				{
					this.WinnerEff.lightBoxStep = this.WinnerEff.lightBoxStep * -1;
					num = Mathf.Clamp(num, 0.3f, 1f);
				}
				color.a = num;
				this.WinnerEff.lightBox.color = color;
			}
		}
		if (UI_AlliWarSchedule.Reconnect && Time.time - UI_AlliWarSchedule.ReconnectTimeCache >= 3f)
		{
			UI_AlliWarSchedule.RequestScheduleData();
			UI_AlliWarSchedule.ReconnectTimeCache = Time.time;
			UI_AlliWarSchedule.Reconnect = false;
		}
	}

	// Token: 0x0600214F RID: 8527 RVA: 0x003F6844 File Offset: 0x003F4A44
	public static void RequestScheduleData()
	{
		if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_AWS_SCHEDULE;
		messagePacket.Add(ActivityManager.Instance.AW_Round);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.AWS_Schedule);
	}

	// Token: 0x06002150 RID: 8528 RVA: 0x003F68A4 File Offset: 0x003F4AA4
	private void RequestPlayWar(byte MatchID)
	{
		if (MatchID == 0)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.CloseMenu(false);
			}
		}
		else
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.AddSeqId();
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_REPLAY;
			byte data = (UI_AlliWarSchedule.Step != UI_AlliWarSchedule.EAWSFightStep.Final) ? 1 : 0;
			messagePacket.Add(data);
			messagePacket.Add(0);
			messagePacket.Add(MatchID);
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Activity);
		}
	}

	// Token: 0x06002151 RID: 8529 RVA: 0x003F693C File Offset: 0x003F4B3C
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < 16; i++)
		{
			if (this.Top16Nodes[i].StrNone != null && this.Top16Nodes[i].StrNone.enabled)
			{
				this.Top16Nodes[i].StrNone.enabled = false;
				this.Top16Nodes[i].StrNone.enabled = true;
			}
			if (this.Top16Nodes[i].AlliTag != null && this.Top16Nodes[i].AlliTag.enabled)
			{
				this.Top16Nodes[i].AlliTag.enabled = false;
				this.Top16Nodes[i].AlliTag.enabled = true;
			}
		}
		for (int j = 0; j < 8; j++)
		{
			if (this.Top8Nodes[j].StrNone != null && this.Top8Nodes[j].StrNone.enabled)
			{
				this.Top8Nodes[j].StrNone.enabled = false;
				this.Top8Nodes[j].StrNone.enabled = true;
			}
			if (this.Top8Nodes[j].AlliTag != null && this.Top8Nodes[j].AlliTag.enabled)
			{
				this.Top8Nodes[j].AlliTag.enabled = false;
				this.Top8Nodes[j].AlliTag.enabled = true;
			}
			if (this.Top16Lines[j].Score != null && this.Top16Lines[j].Score.enabled)
			{
				this.Top16Lines[j].Score.enabled = false;
				this.Top16Lines[j].Score.enabled = true;
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (this.Top4Nodes[k].StrNone != null && this.Top4Nodes[k].StrNone.enabled)
			{
				this.Top4Nodes[k].StrNone.enabled = false;
				this.Top4Nodes[k].StrNone.enabled = true;
			}
			if (this.Top4Nodes[k].AlliTag != null && this.Top4Nodes[k].AlliTag.enabled)
			{
				this.Top4Nodes[k].AlliTag.enabled = false;
				this.Top4Nodes[k].AlliTag.enabled = true;
			}
			if (this.Top8Lines[k].Score != null && this.Top8Lines[k].Score.enabled)
			{
				this.Top8Lines[k].Score.enabled = false;
				this.Top8Lines[k].Score.enabled = true;
			}
		}
		for (int l = 0; l < 2; l++)
		{
			if (this.Top2Nodes[l].StrNone != null && this.Top2Nodes[l].StrNone.enabled)
			{
				this.Top2Nodes[l].StrNone.enabled = false;
				this.Top2Nodes[l].StrNone.enabled = true;
			}
			if (this.Top2Nodes[l].AlliTag != null && this.Top2Nodes[l].AlliTag.enabled)
			{
				this.Top2Nodes[l].AlliTag.enabled = false;
				this.Top2Nodes[l].AlliTag.enabled = true;
			}
			if (this.Top4Lines[l].Score != null && this.Top4Lines[l].Score.enabled)
			{
				this.Top4Lines[l].Score.enabled = false;
				this.Top4Lines[l].Score.enabled = true;
			}
		}
		if (this.Top2Lines[0].Score != null && this.Top2Lines[0].Score.enabled)
		{
			this.Top2Lines[0].Score.enabled = false;
			this.Top2Lines[0].Score.enabled = true;
		}
		if (this.Notes != null && this.Notes.enabled)
		{
			this.Notes.enabled = false;
			this.Notes.enabled = true;
		}
		if (this.Title != null && this.Title.enabled)
		{
			this.Title.enabled = false;
			this.Title.enabled = true;
		}
	}

	// Token: 0x06002152 RID: 8530 RVA: 0x003F6E00 File Offset: 0x003F5000
	public static byte NodePosS2C(byte sPos)
	{
		if (sPos > 15)
		{
			return 0;
		}
		return (byte)UI_AlliWarSchedule.NodePos_S2C[(int)sPos];
	}

	// Token: 0x06002153 RID: 8531 RVA: 0x003F6E14 File Offset: 0x003F5014
	public static void RespSchedule(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.AWS_Schedule);
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			int num = (int)MP.ReadByte(-1);
			num = Mathf.Clamp(num, 0, 4);
			UI_AlliWarSchedule.Step = (UI_AlliWarSchedule.EAWSFightStep)num;
			Array.Clear(UI_AlliWarSchedule.AllianceData, 0, 16);
			Array.Clear(UI_AlliWarSchedule.FightData, 0, 15);
			for (int i = 0; i < 16; i++)
			{
				int num2 = UI_AlliWarSchedule.NodePos_S2C[i];
				UI_AlliWarSchedule.AllianceData[num2].ID = MP.ReadUInt(-1);
				UI_AlliWarSchedule.AllianceData[num2].Emblem = MP.ReadUShort(-1);
				UI_AlliWarSchedule.AllianceData[num2].Tag = MP.ReadString(3, -1);
			}
			for (int j = 0; j < 15; j++)
			{
				int num3 = UI_AlliWarSchedule.LinePos_S2C[j];
				UI_AlliWarSchedule.FightData[num3].Winner = MP.ReadByte(-1);
				UI_AlliWarSchedule.FightData[num3].Alliance1Index = UI_AlliWarSchedule.NodePosS2C(MP.ReadByte(-1));
				UI_AlliWarSchedule.FightData[num3].Alliance2Index = UI_AlliWarSchedule.NodePosS2C(MP.ReadByte(-1));
				UI_AlliWarSchedule.FightData[num3].Score1 = MP.ReadByte(-1);
				UI_AlliWarSchedule.FightData[num3].Score2 = MP.ReadByte(-1);
				if (j == 1)
				{
					byte b2 = UI_AlliWarSchedule.FightData[num3].Alliance1Index;
					UI_AlliWarSchedule.FightData[num3].Alliance1Index = UI_AlliWarSchedule.FightData[num3].Alliance2Index;
					UI_AlliWarSchedule.FightData[num3].Alliance2Index = b2;
					b2 = UI_AlliWarSchedule.FightData[num3].Score1;
					UI_AlliWarSchedule.FightData[num3].Score1 = UI_AlliWarSchedule.FightData[num3].Score2;
					UI_AlliWarSchedule.FightData[num3].Score2 = b2;
				}
			}
			if (GUIManager.Instance.FindMenu(EGUIWindow.UI_AlliWarSchedule))
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_AlliWarSchedule, 0, 0);
			}
			else
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door != null)
				{
					door.OpenMenu(EGUIWindow.UI_AlliWarSchedule, 0, 0, false);
				}
			}
		}
		else if (b == 1 && DataManager.Instance.RoleAlliance.Id != 0u)
		{
			UI_AlliWarSchedule.Reconnect = true;
		}
	}

	// Token: 0x04006907 RID: 26887
	private Door door;

	// Token: 0x04006908 RID: 26888
	private Transform AGS_Form;

	// Token: 0x04006909 RID: 26889
	private UISpritesArray AGS_SpriteArray;

	// Token: 0x0400690A RID: 26890
	private UISpritesArray AGS_SpriteArray2;

	// Token: 0x0400690B RID: 26891
	private UI_AlliWarSchedule.AWS_NodeData[] Top16Nodes = new UI_AlliWarSchedule.AWS_NodeData[16];

	// Token: 0x0400690C RID: 26892
	private UI_AlliWarSchedule.AWS_NodeData[] Top8Nodes = new UI_AlliWarSchedule.AWS_NodeData[8];

	// Token: 0x0400690D RID: 26893
	private UI_AlliWarSchedule.AWS_NodeData[] Top4Nodes = new UI_AlliWarSchedule.AWS_NodeData[4];

	// Token: 0x0400690E RID: 26894
	private UI_AlliWarSchedule.AWS_NodeData[] Top2Nodes = new UI_AlliWarSchedule.AWS_NodeData[2];

	// Token: 0x0400690F RID: 26895
	private UI_AlliWarSchedule.AWS_LineData[] Top16Lines = new UI_AlliWarSchedule.AWS_LineData[8];

	// Token: 0x04006910 RID: 26896
	private UI_AlliWarSchedule.AWS_LineData[] Top8Lines = new UI_AlliWarSchedule.AWS_LineData[4];

	// Token: 0x04006911 RID: 26897
	private UI_AlliWarSchedule.AWS_LineData[] Top4Lines = new UI_AlliWarSchedule.AWS_LineData[2];

	// Token: 0x04006912 RID: 26898
	private UI_AlliWarSchedule.AWS_LineData[] Top2Lines = new UI_AlliWarSchedule.AWS_LineData[1];

	// Token: 0x04006913 RID: 26899
	public static UI_AlliWarSchedule.AWS_AlliData[] AllianceData = new UI_AlliWarSchedule.AWS_AlliData[16];

	// Token: 0x04006914 RID: 26900
	public static UI_AlliWarSchedule.AWS_FightData[] FightData = new UI_AlliWarSchedule.AWS_FightData[15];

	// Token: 0x04006915 RID: 26901
	public static int[] NodePos_S2C = new int[]
	{
		0,
		12,
		4,
		8,
		2,
		14,
		6,
		10,
		1,
		13,
		5,
		9,
		3,
		15,
		7,
		11
	};

	// Token: 0x04006916 RID: 26902
	public static int[] LinePos_S2C = new int[]
	{
		14,
		13,
		12,
		10,
		9,
		11,
		8,
		5,
		3,
		7,
		1,
		4,
		2,
		6,
		0
	};

	// Token: 0x04006917 RID: 26903
	public static int[] LinePos_C2S = new int[]
	{
		15,
		11,
		13,
		9,
		12,
		8,
		14,
		10,
		7,
		5,
		4,
		6,
		3,
		2,
		1
	};

	// Token: 0x04006918 RID: 26904
	private UI_AlliWarSchedule.WinnerEffect WinnerEff = default(UI_AlliWarSchedule.WinnerEffect);

	// Token: 0x04006919 RID: 26905
	public static UI_AlliWarSchedule.EAWSFightStep Step = UI_AlliWarSchedule.EAWSFightStep.Top16;

	// Token: 0x0400691A RID: 26906
	private int[] BtnIndexToLevel = new int[]
	{
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		1,
		1,
		1,
		1,
		2,
		2,
		3
	};

	// Token: 0x0400691B RID: 26907
	private uint[] LevelToStr = new uint[]
	{
		14604u,
		14605u,
		14606u,
		14607u
	};

	// Token: 0x0400691C RID: 26908
	private UIText Title;

	// Token: 0x0400691D RID: 26909
	private UIText Notes;

	// Token: 0x0400691E RID: 26910
	private CString HudStr = new CString(1024);

	// Token: 0x0400691F RID: 26911
	private CString MsgStr = new CString(1024);

	// Token: 0x04006920 RID: 26912
	private bool bExit;

	// Token: 0x04006921 RID: 26913
	public static bool Reconnect = false;

	// Token: 0x04006922 RID: 26914
	public static float ReconnectTimeCache = 0f;

	// Token: 0x020006C6 RID: 1734
	private enum e_AGS_UI_AlliWarSchedule
	{
		// Token: 0x04006924 RID: 26916
		SpriteArray,
		// Token: 0x04006925 RID: 26917
		SpriteArray2,
		// Token: 0x04006926 RID: 26918
		BGFrame,
		// Token: 0x04006927 RID: 26919
		Title,
		// Token: 0x04006928 RID: 26920
		exitImage
	}

	// Token: 0x020006C7 RID: 1735
	private enum e_AGS_BGFrame
	{
		// Token: 0x0400692A RID: 26922
		WinnerEffect,
		// Token: 0x0400692B RID: 26923
		Top16Nodes,
		// Token: 0x0400692C RID: 26924
		Top8Nodes,
		// Token: 0x0400692D RID: 26925
		Top4Nodes,
		// Token: 0x0400692E RID: 26926
		Top2Nodes,
		// Token: 0x0400692F RID: 26927
		Top16Lines,
		// Token: 0x04006930 RID: 26928
		Top8Lines,
		// Token: 0x04006931 RID: 26929
		Top4Lines,
		// Token: 0x04006932 RID: 26930
		Top2Lines,
		// Token: 0x04006933 RID: 26931
		WinnerEffect2,
		// Token: 0x04006934 RID: 26932
		Notes,
		// Token: 0x04006935 RID: 26933
		Btns
	}

	// Token: 0x020006C8 RID: 1736
	private enum e_AGS_AlliNode
	{
		// Token: 0x04006937 RID: 26935
		Unknown,
		// Token: 0x04006938 RID: 26936
		IconBak,
		// Token: 0x04006939 RID: 26937
		Tag,
		// Token: 0x0400693A RID: 26938
		None,
		// Token: 0x0400693B RID: 26939
		Mask
	}

	// Token: 0x020006C9 RID: 1737
	private enum e_AGS_Line
	{
		// Token: 0x0400693D RID: 26941
		VS,
		// Token: 0x0400693E RID: 26942
		Score
	}

	// Token: 0x020006CA RID: 1738
	private enum e_AGS_Title
	{
		// Token: 0x04006940 RID: 26944
		Text
	}

	// Token: 0x020006CB RID: 1739
	private enum e_AGS_exitImage
	{
		// Token: 0x04006942 RID: 26946
		exitUIButton
	}

	// Token: 0x020006CC RID: 1740
	private enum e_UIAWSButtonID
	{
		// Token: 0x04006944 RID: 26948
		ExitBtn,
		// Token: 0x04006945 RID: 26949
		PlayBtn1,
		// Token: 0x04006946 RID: 26950
		PlayBtn2,
		// Token: 0x04006947 RID: 26951
		PlayBtn3,
		// Token: 0x04006948 RID: 26952
		PlayBtn4,
		// Token: 0x04006949 RID: 26953
		PlayBtn5,
		// Token: 0x0400694A RID: 26954
		PlayBtn6,
		// Token: 0x0400694B RID: 26955
		PlayBtn7,
		// Token: 0x0400694C RID: 26956
		PlayBtn8,
		// Token: 0x0400694D RID: 26957
		PlayBtn9,
		// Token: 0x0400694E RID: 26958
		PlayBtn10,
		// Token: 0x0400694F RID: 26959
		PlayBtn11,
		// Token: 0x04006950 RID: 26960
		PlayBtn12,
		// Token: 0x04006951 RID: 26961
		PlayBtn13,
		// Token: 0x04006952 RID: 26962
		PlayBtn14,
		// Token: 0x04006953 RID: 26963
		PlayBtn15
	}

	// Token: 0x020006CD RID: 1741
	public enum EAWSNodeState
	{
		// Token: 0x04006955 RID: 26965
		Normal,
		// Token: 0x04006956 RID: 26966
		UnKnown,
		// Token: 0x04006957 RID: 26967
		NoAlliance,
		// Token: 0x04006958 RID: 26968
		Empty
	}

	// Token: 0x020006CE RID: 1742
	public enum EAWSLineState
	{
		// Token: 0x0400695A RID: 26970
		VS,
		// Token: 0x0400695B RID: 26971
		Score,
		// Token: 0x0400695C RID: 26972
		Empty,
		// Token: 0x0400695D RID: 26973
		EmptyLightLine
	}

	// Token: 0x020006CF RID: 1743
	public enum EAWSLineStyle
	{
		// Token: 0x0400695F RID: 26975
		Vertical,
		// Token: 0x04006960 RID: 26976
		Horizontal
	}

	// Token: 0x020006D0 RID: 1744
	public enum EAWSFightStep
	{
		// Token: 0x04006962 RID: 26978
		Top16,
		// Token: 0x04006963 RID: 26979
		Top8,
		// Token: 0x04006964 RID: 26980
		Top4,
		// Token: 0x04006965 RID: 26981
		Top2,
		// Token: 0x04006966 RID: 26982
		Final
	}

	// Token: 0x020006D1 RID: 1745
	public class AWS_NodeData
	{
		// Token: 0x04006967 RID: 26983
		public UI_AlliWarSchedule.EAWSNodeState State;

		// Token: 0x04006968 RID: 26984
		public Image NodeBack;

		// Token: 0x04006969 RID: 26985
		public UIText AlliTag;

		// Token: 0x0400696A RID: 26986
		public RectTransform ElbemTrans;

		// Token: 0x0400696B RID: 26987
		public Image ImgUnknown;

		// Token: 0x0400696C RID: 26988
		public UIText StrNone;

		// Token: 0x0400696D RID: 26989
		public GameObject IconBackObj;

		// Token: 0x0400696E RID: 26990
		public Image Mask;
	}

	// Token: 0x020006D2 RID: 1746
	public class AWS_LineData
	{
		// Token: 0x0400696F RID: 26991
		public UI_AlliWarSchedule.EAWSLineStyle Style;

		// Token: 0x04006970 RID: 26992
		public UI_AlliWarSchedule.EAWSLineState State;

		// Token: 0x04006971 RID: 26993
		public Image Line;

		// Token: 0x04006972 RID: 26994
		public UIText Score;

		// Token: 0x04006973 RID: 26995
		public Image ImgVS;

		// Token: 0x04006974 RID: 26996
		public CString StrScore;

		// Token: 0x04006975 RID: 26997
		public UI_AlliWarSchedule.AWS_NodeData Node1;

		// Token: 0x04006976 RID: 26998
		public UI_AlliWarSchedule.AWS_NodeData Node2;

		// Token: 0x04006977 RID: 26999
		public UI_AlliWarSchedule.AWS_LineData ChildLine1;

		// Token: 0x04006978 RID: 27000
		public UI_AlliWarSchedule.AWS_LineData ChildLine2;

		// Token: 0x04006979 RID: 27001
		public byte FightDataIndex;
	}

	// Token: 0x020006D3 RID: 1747
	public struct WinnerEffect
	{
		// Token: 0x0400697A RID: 27002
		public byte IO;

		// Token: 0x0400697B RID: 27003
		public Transform EffectNode1;

		// Token: 0x0400697C RID: 27004
		public Transform EffectNode2;

		// Token: 0x0400697D RID: 27005
		public Transform RotateingLight;

		// Token: 0x0400697E RID: 27006
		public Image lightBox;

		// Token: 0x0400697F RID: 27007
		public int lightBoxStep;
	}

	// Token: 0x020006D4 RID: 1748
	public struct AWS_AlliData
	{
		// Token: 0x04006980 RID: 27008
		public uint ID;

		// Token: 0x04006981 RID: 27009
		public ushort Emblem;

		// Token: 0x04006982 RID: 27010
		public string Tag;
	}

	// Token: 0x020006D5 RID: 1749
	public struct AWS_FightData
	{
		// Token: 0x04006983 RID: 27011
		public byte Winner;

		// Token: 0x04006984 RID: 27012
		public byte Alliance1Index;

		// Token: 0x04006985 RID: 27013
		public byte Alliance2Index;

		// Token: 0x04006986 RID: 27014
		public byte Score1;

		// Token: 0x04006987 RID: 27015
		public byte Score2;
	}
}
