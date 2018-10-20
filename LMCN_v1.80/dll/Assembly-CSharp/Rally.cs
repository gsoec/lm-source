using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x020002F6 RID: 758
public class Rally : IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUTimeBarOnTimer
{
	// Token: 0x06000F7B RID: 3963 RVA: 0x001B3CAC File Offset: 0x001B1EAC
	public Rally(Transform transform, int dataindex)
	{
		this.transform = transform;
		this.DataIndex = dataindex;
	}

	// Token: 0x06000F7C RID: 3964 RVA: 0x001B3CE0 File Offset: 0x001B1EE0
	public virtual void OnOpen(int arg1, int arg2)
	{
		GUIManager instance = GUIManager.Instance;
		Font ttffont = instance.GetTTFFont();
		instance.UpdateUI(EGUIWindow.Door, 1, 2);
		this.SPriteArray = this.transform.GetComponent<UISpritesArray>();
		this.TitleText = this.transform.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.TitleText.font = ttffont;
		this.TopHero = this.transform.GetChild(1).GetChild(2).GetChild(0);
		this.TopText = this.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
		this.TopText.font = ttffont;
		this.TopAttackIcon = this.transform.GetChild(1).GetChild(1).GetChild(1).gameObject;
		this.TopTargetIcon = this.transform.GetChild(1).GetChild(1).GetChild(0).gameObject;
		this.TopCountry = this.transform.GetChild(1).GetChild(3).gameObject;
		this.TopCountryText = this.transform.GetChild(1).GetChild(3).GetComponent<UIText>();
		this.TopCountryText.font = ttffont;
		this.TopNameText = this.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
		this.TopNameText.font = ttffont;
		this.TopUnderLine = this.transform.GetChild(1).GetChild(4).GetChild(0).GetComponent<RectTransform>();
		this.TopUnderLineBtn = this.TopUnderLine.GetComponent<UIButton>();
		this.TopUnderLineBtn.m_BtnID1 = 5;
		this.TopUnderLineBtn.m_Handler = this;
		this.transform.GetChild(1).GetChild(5).GetChild(3).GetComponent<UIText>().font = ttffont;
		this.transform.GetChild(1).GetChild(5).GetChild(4).GetComponent<UIText>().font = ttffont;
		this.transform.GetChild(1).GetChild(5).GetChild(5).GetComponent<UIText>().font = ttffont;
		this.TopBar = new RallyTimeBar(this.transform.GetChild(1).GetChild(5).GetComponent<UITimeBar>(), 1);
		this.TopBar.Hander = this;
		this.TopLayerBlue = this.transform.GetChild(1).GetChild(0).gameObject;
		this.InfoBtn = this.transform.GetChild(1).GetChild(6).GetComponent<UIButton>();
		this.InfoBtn.m_BtnID1 = 11;
		this.InfoBtn.m_Handler = this;
		this.LeftHero = this.transform.GetChild(3).GetChild(4).GetChild(0);
		this.LeftText = this.transform.GetChild(3).GetChild(1).GetChild(2).GetComponent<UIText>();
		this.LeftText.font = ttffont;
		this.LeftText.color = Color.white;
		this.LeftAttackIcon = this.transform.GetChild(3).GetChild(1).GetChild(1).gameObject;
		this.LeftTargetIcon = this.transform.GetChild(3).GetChild(1).GetChild(0).gameObject;
		this.transform.GetChild(3).GetChild(2).GetChild(3).GetComponent<UIText>().font = ttffont;
		this.transform.GetChild(3).GetChild(2).GetChild(4).GetComponent<UIText>().font = ttffont;
		this.transform.GetChild(3).GetChild(2).GetChild(5).GetComponent<UIText>().font = ttffont;
		this.LeftBar = new RallyTimeBar(this.transform.GetChild(3).GetChild(2).GetComponent<UITimeBar>(), 3);
		this.LeftBar.Hander = this;
		this.LeftFilterImg = this.transform.GetChild(3).GetChild(5).GetComponent<Image>();
		this.LeftFilterOnImg = this.transform.GetChild(3).GetChild(5).GetChild(0).GetComponent<Image>();
		this.FilterBtn = this.transform.GetChild(3).GetChild(5).GetComponent<UIButton>();
		this.FilterBtn.m_BtnID1 = 0;
		this.FilterBtn.m_Handler = this;
		this.FilterEff = this.transform.GetChild(3).GetChild(5).GetChild(0).GetComponent<CanvasGroup>();
		this.LeftNameText = this.transform.GetChild(3).GetChild(6).GetComponent<UIText>();
		this.LeftNameText.font = ttffont;
		this.LeftUnderLine = this.transform.GetChild(3).GetChild(6).GetChild(0).GetComponent<RectTransform>();
		this.LeftUnderLineBtn = this.LeftUnderLine.GetComponent<UIButton>();
		this.LeftUnderLineBtn.m_BtnID1 = 5;
		this.LeftUnderLineBtn.m_Handler = this;
		this.RallySpeedupBtn = this.transform.GetChild(3).GetChild(3).GetComponent<UIButton>();
		this.RallySpeedupBtn.m_BtnID1 = 10;
		this.RallySpeedupBtn.m_Handler = this;
		if (instance.IsArabic)
		{
			this.RallySpeedupBtn.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		Color effectColor = new Color(0.141f, 0.063f, 0f);
		this.LeftJoinText = this.transform.GetChild(3).GetChild(7).GetChild(0).GetComponent<UIText>();
		this.LeftJoinText.gameObject.AddComponent<Outline>().effectColor = effectColor;
		this.LeftJoinText.font = ttffont;
		this.LeftJoinImg = this.transform.GetChild(3).GetChild(7).GetComponent<Image>();
		this.LeftJoinImg.gameObject.SetActive(false);
		this.JoinBtn = this.transform.GetChild(3).GetChild(7).GetComponent<UIButton>();
		this.JoinBtn.m_BtnID1 = 2;
		this.JoinBtn.m_Handler = this;
		this.LeftCancelText = this.transform.GetChild(3).GetChild(8).GetChild(0).GetComponent<UIText>();
		this.LeftCancelText.gameObject.AddComponent<Outline>().effectColor = effectColor;
		this.LeftCancelText.font = ttffont;
		this.LeftCancelImg = this.transform.GetChild(3).GetChild(8).GetComponent<Image>();
		this.LeftCancelImg.gameObject.SetActive(false);
		this.CancelBtn = this.transform.GetChild(3).GetChild(8).GetComponent<UIButton>();
		this.CancelBtn.m_BtnID1 = 3;
		this.CancelBtn.m_Handler = this;
		this.ArmySpriteArray = this.transform.GetChild(4).GetChild(5).GetComponent<UISpritesArray>();
		this.ArmyStatisticHint = new Rally.RallyArmyHint(this.transform.GetChild(6), ttffont, this.ArmySpriteArray);
		UIButtonHint uibuttonHint = this.transform.GetChild(4).GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.ControlFadeOut = this.ArmyStatisticHint.rectTransform.gameObject;
		this.StaticRect = this.transform.GetChild(4).GetChild(0).GetComponent<RectTransform>();
		this.StaticBtn = this.StaticRect.GetComponent<UIButton>();
		this.StaticBtn.m_BtnID1 = 15;
		this.RightTitleText = this.transform.GetChild(4).GetChild(2).GetComponent<UIText>();
		this.RightTitleText.font = ttffont;
		this.RightMessage = this.transform.GetChild(4).GetChild(4).GetComponent<RectTransform>();
		this.RightMessageText = this.RightMessage.GetChild(0).GetComponent<UIText>();
		this.RightMessageText.font = ttffont;
		this.RightFlagAttack = this.transform.GetChild(4).GetChild(1).GetComponent<Image>();
		this.RightFlagDefense = this.transform.GetChild(4).GetChild(1).GetChild(0).GetComponent<Image>();
		this.RallyScroll = this.transform.GetChild(4).GetChild(5).GetChild(0).GetComponent<ScrollPanel>();
		this.RallyScollRect = this.transform.GetChild(4).GetChild(5).GetChild(0).GetComponent<RectTransform>();
		this.MemberCombat = new Rally._Conbat(this.transform.GetChild(4).GetChild(3), ttffont);
		this.transform.GetChild(4).GetChild(6).GetChild(1).GetComponent<UIText>().font = ttffont;
		this.transform.GetChild(4).GetChild(6).GetChild(2).GetChild(0).GetComponent<UIText>().font = ttffont;
		this.transform.GetChild(4).GetChild(6).GetChild(6).GetComponent<UIText>().font = ttffont;
		this.transform.GetChild(4).GetChild(6).GetChild(7).GetComponent<UIText>().font = ttffont;
		int childCount = this.transform.GetChild(4).GetChild(6).GetChild(9).GetChild(0).childCount;
		for (int i = 0; i < childCount; i++)
		{
			this.transform.GetChild(4).GetChild(6).GetChild(9).GetChild(0).GetChild(i).GetComponent<UIText>().font = ttffont;
			this.transform.GetChild(4).GetChild(6).GetChild(9).GetChild(0).GetChild(i).GetChild(0).GetComponent<Text>().font = ttffont;
			this.transform.GetChild(4).GetChild(6).GetChild(9).GetChild(1).GetChild(i).GetChild(1).GetComponent<Text>().font = ttffont;
			if (instance.IsArabic)
			{
				RectTransform component = this.transform.GetChild(4).GetChild(6).GetChild(9).GetChild(0).GetChild(i).GetChild(0).GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(-68f, component.anchoredPosition.y);
				component.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
				component = this.transform.GetChild(4).GetChild(6).GetChild(9).GetChild(1).GetChild(i).GetChild(1).GetComponent<RectTransform>();
				component.localScale = new Vector3(-1f, 1f, 1f);
				component.anchoredPosition = new Vector2(component.anchoredPosition.x + component.rect.width, component.anchoredPosition.y);
			}
		}
		this.transform.GetChild(4).GetChild(6).GetChild(3).GetChild(3).GetComponent<UIText>().font = ttffont;
		this.transform.GetChild(4).GetChild(6).GetChild(3).GetChild(4).GetComponent<UIText>().font = ttffont;
		this.transform.GetChild(4).GetChild(6).GetChild(3).GetChild(5).GetComponent<UIText>().font = ttffont;
		Image component2 = this.transform.GetChild(5).GetComponent<Image>();
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			component2.enabled = false;
		}
		else
		{
			component2.sprite = door.LoadSprite("UI_main_close_base");
			component2.material = door.LoadMaterial();
		}
		component2 = this.transform.GetChild(5).GetChild(0).GetComponent<Image>();
		component2.sprite = door.LoadSprite("UI_main_close");
		component2.material = door.LoadMaterial();
		UIButton component3 = this.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
		component3.m_BtnID1 = 1;
		component3.m_Handler = this;
		StringManager instance2 = StringManager.Instance;
		this.LeftnameStr = instance2.SpawnString(30);
		this.RightTitleStr = instance2.SpawnString(100);
		this.TopNameStr = instance2.SpawnString(100);
		this.TopCountryStr = instance2.SpawnString(100);
		this.TopTextStr = instance2.SpawnString(30);
		this.LeftTextStr = instance2.SpawnString(30);
		this.MessageStr = instance2.SpawnString(800);
		this.Parm1 = arg1;
		if (arg1 == 102)
		{
			return;
		}
		bool flag = true;
		DataManager instance3 = DataManager.Instance;
		if (arg1 == 100)
		{
			if (instance3.WarhallProtocol > 0 && instance3.WarhallProtocol != 2476 && instance3.WarlobbyDetail != null && (int)instance3.WarlobbyDetail.SelfParticipateTroopIndex == arg2)
			{
				flag = false;
			}
			else
			{
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.AddSeqId();
				messagePacket.Add((uint)arg2);
				messagePacket.Protocol = Protocol._MSG_REQUEST_JOINED_RALLY_DETAIL;
				messagePacket.Send(false);
				instance3.WarhallDetailType = (byte)arg2;
				instance3.WarhallProtocol = (ushort)messagePacket.Protocol;
			}
		}
		else if (arg1 == 101)
		{
			MessagePacket messagePacket2 = new MessagePacket(1024);
			messagePacket2.Protocol = Protocol._MSG_REQUEST_WONDERTEAM_INFO;
			messagePacket2.AddSeqId();
			messagePacket2.Add((byte)arg2);
			messagePacket2.Send(false);
			instance3.WarhallProtocol = (ushort)messagePacket2.Protocol;
			flag = true;
		}
		else if (instance3.WarhallProtocol > 0 && instance3.WarhallProtocol != 2476 && instance3.WarlobbyDetail != null && instance3.WarhallDetailType == (byte)arg1)
		{
			flag = false;
		}
		else
		{
			arg2 = (-32769 & arg2);
			MessagePacket messagePacket3 = new MessagePacket(1024);
			messagePacket3.AddSeqId();
			messagePacket3.Add((byte)arg1);
			messagePacket3.Add((uint)arg2);
			messagePacket3.Protocol = Protocol._MSG_REQUEST_WARHALL_LIST_DETAIL;
			messagePacket3.Send(false);
			instance3.WarhallDetailType = (byte)arg1;
			instance3.WarhallProtocol = (ushort)messagePacket3.Protocol;
		}
		if (flag)
		{
			if (instance3.WarlobbyDetail != null)
			{
				instance3.WarlobbyDetail.AllyNameID = 0;
			}
			instance3.EmptyRallyDetail();
			Array.Clear(instance.RallySaved, 0, instance.RallySaved.Length);
			instance3.WarTroopStatistic.Clear();
		}
	}

	// Token: 0x06000F7D RID: 3965 RVA: 0x001B4B48 File Offset: 0x001B2D48
	public virtual void Init()
	{
		GUIManager instance = GUIManager.Instance;
		instance.InitianHeroItemImg(this.TopHero, eHeroOrItem.Hero, 5, 1, 2, 10, false, false, true, false);
		instance.InitianHeroItemImg(this.LeftHero, eHeroOrItem.Hero, 5, 1, 2, 10, false, false, true, false);
		this.TopHeroBtn = this.TopHero.GetComponent<UIHIBtn>();
		this.TopHeroBtn.m_Handler = this;
		this.LeftHeroBtn = this.LeftHero.GetComponent<UIHIBtn>();
		this.LeftHeroBtn.m_Handler = this;
		this.RightMessageText.text = DataManager.Instance.mStringTable.GetStringByID(4824u);
		Vector2 sizeDelta = this.RightMessage.sizeDelta;
		sizeDelta.x = this.RightMessageText.preferredWidth + 165f;
		this.RightMessage.sizeDelta = sizeDelta;
		this.LoadBeginIndex = (int)instance.RallySaved[0];
		this.LoadContY = GameConstants.ConvertBytesToFloat(instance.RallySaved, 1);
		byte b = 6;
		this.ItemEdit = new Rally.RallyItem[(int)b];
		for (byte b2 = 0; b2 < b; b2 += 1)
		{
			this.ItemsExtend.Add(0);
			this.ItemsHeight.Add(80f);
		}
		this.RallyScroll.IntiScrollPanel(352f, 0f, 0f, this.ItemsHeight, (int)b, this);
		UIButtonHint.scrollRect = this.RallyScroll.transform.GetComponent<CScrollRect>();
		this.RightScrollCont = this.RallyScroll.transform.GetChild(0).GetComponent<RectTransform>();
		this.UpdateRallyData();
	}

	// Token: 0x06000F7E RID: 3966 RVA: 0x001B4CC8 File Offset: 0x001B2EC8
	public virtual void UpdateTime(bool bOnSecond)
	{
		if (this.DelayInit > 0)
		{
			this.DelayInit -= 1;
			if (this.DelayInit == 0)
			{
				this.Init();
			}
		}
		else
		{
			this.TopBar.Update();
			this.LeftBar.Update();
			for (int i = 0; i < this.ItemEdit.Length; i++)
			{
				this.ItemEdit[i].Update();
			}
			if (this.LeftFilterImg.gameObject.activeSelf)
			{
				this.DeltaTime += Time.deltaTime;
				if (this.DeltaTime >= 2f)
				{
					this.DeltaTime = 0f;
				}
				float alpha = (this.DeltaTime <= 1f) ? this.DeltaTime : (2f - this.DeltaTime);
				this.FilterEff.alpha = alpha;
			}
		}
	}

	// Token: 0x06000F7F RID: 3967 RVA: 0x001B4DB8 File Offset: 0x001B2FB8
	public virtual void OnClose()
	{
		this.TopBar.Destroy();
		this.LeftBar.Destroy();
		StringManager instance = StringManager.Instance;
		instance.DeSpawnString(this.LeftnameStr);
		instance.DeSpawnString(this.RightTitleStr);
		instance.DeSpawnString(this.TopNameStr);
		instance.DeSpawnString(this.TopCountryStr);
		instance.DeSpawnString(this.TopTextStr);
		instance.DeSpawnString(this.LeftTextStr);
		instance.DeSpawnString(this.MessageStr);
		if (this.ItemEdit != null)
		{
			for (int i = 0; i < this.ItemEdit.Length; i++)
			{
				if (this.ItemEdit[i] != null)
				{
					this.ItemEdit[i].OnClose();
				}
			}
			GUIManager instance2 = GUIManager.Instance;
			instance2.RallySaved[0] = (byte)this.RallyScroll.GetBeginIdx();
			GameConstants.GetBytes(this.RightScrollCont.anchoredPosition.y, instance2.RallySaved, 1);
		}
		this.ArmyStatisticHint.OnClose();
		this.MemberCombat.OnClose();
	}

	// Token: 0x06000F80 RID: 3968 RVA: 0x001B4ECC File Offset: 0x001B30CC
	public virtual void OnTimer(UITimeBar sender)
	{
	}

	// Token: 0x06000F81 RID: 3969 RVA: 0x001B4ED0 File Offset: 0x001B30D0
	public void KickMemberConfirm(ushort Index, byte WonderID)
	{
		int arg = (int)Index << 16 | (int)WonderID;
		StringTable mStringTable = DataManager.Instance.mStringTable;
		GUIManager.Instance.OpenOKCancelBox(GUIManager.Instance.FindMenu(EGUIWindow.UI_Rally), mStringTable.GetStringByID(4096u), mStringTable.GetStringByID(9913u), 13, arg, mStringTable.GetStringByID(4977u), mStringTable.GetStringByID(4978u));
	}

	// Token: 0x06000F82 RID: 3970 RVA: 0x001B4F34 File Offset: 0x001B3134
	public virtual void KickMember(ushort Index, byte WonderID)
	{
	}

	// Token: 0x06000F83 RID: 3971 RVA: 0x001B4F38 File Offset: 0x001B3138
	public void OnNotify(UITimeBar sender)
	{
	}

	// Token: 0x06000F84 RID: 3972 RVA: 0x001B4F3C File Offset: 0x001B313C
	public void Onfunc(UITimeBar sender)
	{
	}

	// Token: 0x06000F85 RID: 3973 RVA: 0x001B4F40 File Offset: 0x001B3140
	public void OnCancel(UITimeBar sender)
	{
	}

	// Token: 0x06000F86 RID: 3974 RVA: 0x001B4F44 File Offset: 0x001B3144
	public virtual void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
	}

	// Token: 0x06000F87 RID: 3975 RVA: 0x001B4F48 File Offset: 0x001B3148
	protected void SetText(Rally.TextType Type, int Parm1 = 0, CString Parm2 = null, int Parm3 = 0, CString Parm4 = null, ushort KingdomCompare = 0)
	{
		bool flag = false;
		UIText uitext;
		CString cstring;
		switch (Type)
		{
		case Rally.TextType.TopCountry:
			uitext = this.TopCountryText;
			cstring = this.TopCountryStr;
			cstring.ClearString();
			cstring.IntToFormat((long)Parm1, 1, false);
			if (GUIManager.Instance.IsArabic)
			{
				cstring.AppendFormat("{0}#");
			}
			else
			{
				cstring.AppendFormat("#{0}");
			}
			break;
		case Rally.TextType.TopName:
			if (ActivityManager.Instance.IsInKvK(0, false) && KingdomCompare > 0 && KingdomCompare != DataManager.MapDataController.kingdomData.kingdomID)
			{
				flag = true;
			}
			cstring = this.TopNameStr;
			uitext = this.TopNameText;
			cstring.ClearString();
			if (flag)
			{
				uitext.color = new Color(1f, 0.529f, 0.557f);
			}
			if (Parm4 != null)
			{
				if (Parm4.Length > 0)
				{
					if (flag)
					{
						GameConstants.FormatRoleName(cstring, Parm2, Parm4, null, 0, 0, null, "<color=#FF878E>", "<color=#FF878E>", null);
					}
					else
					{
						GameConstants.FormatRoleName(cstring, Parm2, Parm4, null, 0, 0, null, null, "<color=#FFCC00>", null);
					}
				}
				else
				{
					cstring.Append(Parm2);
				}
			}
			else
			{
				cstring.Append(Parm2);
			}
			break;
		case Rally.TextType.LeftName:
			uitext = this.LeftNameText;
			cstring = Parm2;
			break;
		case Rally.TextType.RightTitle:
			uitext = this.RightTitleText;
			cstring = this.RightTitleStr;
			cstring.ClearString();
			cstring.Append(Parm2);
			cstring.IntToFormat((long)Parm1, 1, true);
			cstring.IntToFormat((long)Parm3, 1, true);
			cstring.AppendFormat("{0} / {1}");
			break;
		case Rally.TextType.TopWonders:
			if (ActivityManager.Instance.IsInKvK(0, false) && Parm1 > 0 && Parm1 != (int)DataManager.MapDataController.kingdomData.kingdomID)
			{
				flag = true;
			}
			uitext = this.TopCountryText;
			cstring = this.TopCountryStr;
			cstring.ClearString();
			cstring.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)Parm3, 0));
			if (flag)
			{
				cstring.AppendFormat("<color=#FF878E>{0}</color>");
			}
			else
			{
				cstring.AppendFormat("<color=#FFFFFF>{0}</color>");
			}
			break;
		default:
			return;
		}
		uitext.text = cstring.ToString();
		uitext.SetAllDirty();
		uitext.cachedTextGenerator.Invalidate();
		uitext.cachedTextGeneratorForLayout.Invalidate();
	}

	// Token: 0x06000F88 RID: 3976 RVA: 0x001B5190 File Offset: 0x001B3390
	public byte GetTroopKind()
	{
		if (DataManager.Instance.WarlobbyDetail != null)
		{
			return DataManager.Instance.WarlobbyDetail.Kind;
		}
		return 0;
	}

	// Token: 0x06000F89 RID: 3977 RVA: 0x001B51C0 File Offset: 0x001B33C0
	public void TextRefresh()
	{
		if (this.TitleText != null)
		{
			this.TitleText.enabled = false;
			this.TitleText.enabled = true;
		}
		if (this.TopText != null)
		{
			this.TopText.enabled = false;
			this.TopText.enabled = true;
		}
		if (this.TopCountryText != null)
		{
			this.TopCountryText.enabled = false;
			this.TopCountryText.enabled = true;
		}
		if (this.TopNameText != null)
		{
			this.TopNameText.enabled = false;
			this.TopNameText.enabled = true;
		}
		if (this.LeftText != null)
		{
			this.LeftText.enabled = false;
			this.LeftText.enabled = true;
		}
		if (this.LeftNameText != null)
		{
			this.LeftNameText.enabled = false;
			this.LeftNameText.enabled = true;
		}
		if (this.LeftJoinText != null)
		{
			this.LeftJoinText.enabled = false;
			this.LeftJoinText.enabled = true;
		}
		if (this.LeftCancelText != null)
		{
			this.LeftCancelText.enabled = false;
			this.LeftCancelText.enabled = true;
		}
		if (this.RightTitleText != null)
		{
			this.RightTitleText.enabled = false;
			this.RightTitleText.enabled = true;
		}
		if (this.RightMessageText != null)
		{
			this.RightMessageText.enabled = false;
			this.RightMessageText.enabled = true;
		}
		if (this.ItemEdit != null)
		{
			for (int i = 0; i < this.ItemEdit.Length; i++)
			{
				if (this.ItemEdit[i] == null)
				{
					break;
				}
				this.ItemEdit[i].TextRefresh();
			}
		}
		if (this.TopBar != null)
		{
			this.TopBar.TextRefresh();
		}
		if (this.LeftBar != null)
		{
			this.LeftBar.TextRefresh();
		}
		this.ArmyStatisticHint.TextRefresh();
		this.MemberCombat.TextRefresh();
	}

	// Token: 0x06000F8A RID: 3978 RVA: 0x001B53EC File Offset: 0x001B35EC
	public virtual void UpdateUI(int arg1, int arg2)
	{
		if (this.DelayInit > 0)
		{
			this.Init();
			this.DelayInit = 0;
		}
		this.LoadBeginIndex = (int)((byte)this.RallyScroll.GetBeginIdx());
		this.LoadContY = this.RightScrollCont.anchoredPosition.y;
		this.ArmyStatisticHint.Show(null);
	}

	// Token: 0x06000F8B RID: 3979 RVA: 0x001B544C File Offset: 0x001B364C
	public virtual void UpdateRallyData()
	{
	}

	// Token: 0x06000F8C RID: 3980 RVA: 0x001B5450 File Offset: 0x001B3650
	public void UpdateItemDataHeight(int panelObjectIdx)
	{
		int dataIndex = this.ItemEdit[panelObjectIdx].DataIndex;
		this.ItemsExtend[dataIndex] = ((!this.ItemEdit[panelObjectIdx].Extend.gameObject.activeSelf) ? 0 : 1);
		this.ItemsHeight[dataIndex] = this.ItemEdit[panelObjectIdx].GetItemHeight();
		float y = this.RightScrollCont.anchoredPosition.y;
		this.RallyScroll.AddNewDataHeight(this.ItemsHeight, true, true);
		if (y > 0f)
		{
			this.RallyScroll.GoTo(dataIndex, y);
		}
	}

	// Token: 0x06000F8D RID: 3981 RVA: 0x001B54F4 File Offset: 0x001B36F4
	protected uint GetCombatPower(bool skipinitiator = false)
	{
		uint num = 1600u + DataManager.Instance.WarlobbyDetail.AddCombatPower;
		uint num2 = 0u;
		List<WarlobbyTroop> warTroop = DataManager.Instance.WarTroop;
		int count = warTroop.Count;
		int i = 0;
		if (skipinitiator)
		{
			i = 1;
		}
		while (i < count)
		{
			num2 += warTroop[i].CombatPower;
			i++;
		}
		if (num2 > num)
		{
			num2 = num;
		}
		return num2;
	}

	// Token: 0x06000F8E RID: 3982 RVA: 0x001B5564 File Offset: 0x001B3764
	public virtual void OnButtonClick(UIButton sender)
	{
		Rally.ClickType btnID = (Rally.ClickType)sender.m_BtnID1;
		if (btnID != Rally.ClickType.Close)
		{
			if (btnID != Rally.ClickType.Jump)
			{
				if (btnID != Rally.ClickType.Static)
				{
				}
			}
			else
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.GoToMapID((ushort)sender.m_BtnID3, sender.m_BtnID2, 0, 1, true);
			}
		}
		else
		{
			Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door2 != null)
			{
				door2.CloseMenu(false);
			}
		}
	}

	// Token: 0x06000F8F RID: 3983 RVA: 0x001B55F0 File Offset: 0x001B37F0
	public void OnButtonDown(UIButtonHint sender)
	{
		this.ArmyStatisticHint.Show(sender);
	}

	// Token: 0x06000F90 RID: 3984 RVA: 0x001B5600 File Offset: 0x001B3800
	public void OnButtonUp(UIButtonHint sender)
	{
		this.ArmyStatisticHint.Hide();
	}

	// Token: 0x06000F91 RID: 3985 RVA: 0x001B5610 File Offset: 0x001B3810
	public virtual void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.ItemEdit[panelObjectIdx] == null)
		{
			this.ItemEdit[panelObjectIdx] = new Rally.RallyItem(this.SPriteArray, this.ArmySpriteArray, item.transform, this);
		}
		else
		{
			this.ItemEdit[panelObjectIdx].SetRallyItem(dataIdx, panelObjectIdx, this.ItemsExtend[dataIdx], this.MemberCombat.gameobject.activeSelf);
		}
	}

	// Token: 0x06000F92 RID: 3986 RVA: 0x001B567C File Offset: 0x001B387C
	public virtual void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		for (int i = 0; i < this.ItemEdit.Length; i++)
		{
			if (this.ItemEdit[i].ThisRect.gameObject.activeSelf && this.ItemEdit[i].DataIndex == dataIndex)
			{
				AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
				this.ItemEdit[i].OnButtonClick(null);
				break;
			}
		}
	}

	// Token: 0x06000F93 RID: 3987 RVA: 0x001B56F0 File Offset: 0x001B38F0
	public void OnHIButtonClick(UIHIBtn sender)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		door.GoToMapID((ushort)sender.m_BtnID2, sender.m_BtnID1, 0, 1, true);
	}

	// Token: 0x06000F94 RID: 3988 RVA: 0x001B5724 File Offset: 0x001B3924
	protected void CloseMenuCheck()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			if (this.transform.gameObject.activeSelf)
			{
				door.CloseMenu(false);
			}
			else
			{
				GUIManager.Instance.CloseMenu(EGUIWindow.UI_Rally);
				DataManager.Instance.RemoveDoorUIStack(EGUIWindow.UI_Rally);
			}
		}
	}

	// Token: 0x040032EF RID: 13039
	protected const float ScrollHightLarge = 352f;

	// Token: 0x040032F0 RID: 13040
	protected const float ScrollHightSmall = 306f;

	// Token: 0x040032F1 RID: 13041
	protected int DataIndex;

	// Token: 0x040032F2 RID: 13042
	protected int LoadBeginIndex;

	// Token: 0x040032F3 RID: 13043
	protected float LoadContY;

	// Token: 0x040032F4 RID: 13044
	protected float DeltaTime;

	// Token: 0x040032F5 RID: 13045
	protected RectTransform RightScrollCont;

	// Token: 0x040032F6 RID: 13046
	protected RectTransform RightMessage;

	// Token: 0x040032F7 RID: 13047
	protected RectTransform TopUnderLine;

	// Token: 0x040032F8 RID: 13048
	protected RectTransform LeftUnderLine;

	// Token: 0x040032F9 RID: 13049
	protected RectTransform RallyScollRect;

	// Token: 0x040032FA RID: 13050
	protected RectTransform StaticRect;

	// Token: 0x040032FB RID: 13051
	protected Transform TopHero;

	// Token: 0x040032FC RID: 13052
	protected Transform LeftHero;

	// Token: 0x040032FD RID: 13053
	protected Transform transform;

	// Token: 0x040032FE RID: 13054
	protected UIText TitleText;

	// Token: 0x040032FF RID: 13055
	protected UIText TopText;

	// Token: 0x04003300 RID: 13056
	protected UIText TopCountryText;

	// Token: 0x04003301 RID: 13057
	protected UIText TopNameText;

	// Token: 0x04003302 RID: 13058
	protected UIText LeftText;

	// Token: 0x04003303 RID: 13059
	protected UIText LeftNameText;

	// Token: 0x04003304 RID: 13060
	protected UIText LeftJoinText;

	// Token: 0x04003305 RID: 13061
	protected UIText LeftCancelText;

	// Token: 0x04003306 RID: 13062
	protected UIText RightTitleText;

	// Token: 0x04003307 RID: 13063
	protected UIText RightMessageText;

	// Token: 0x04003308 RID: 13064
	protected UIHIBtn TopHeroBtn;

	// Token: 0x04003309 RID: 13065
	protected UIHIBtn LeftHeroBtn;

	// Token: 0x0400330A RID: 13066
	private CString LeftnameStr;

	// Token: 0x0400330B RID: 13067
	private CString RightTitleStr;

	// Token: 0x0400330C RID: 13068
	private CString TopNameStr;

	// Token: 0x0400330D RID: 13069
	private CString TopCountryStr;

	// Token: 0x0400330E RID: 13070
	protected CString MessageStr;

	// Token: 0x0400330F RID: 13071
	protected CString TopTextStr;

	// Token: 0x04003310 RID: 13072
	protected CString LeftTextStr;

	// Token: 0x04003311 RID: 13073
	protected Image LeftJoinImg;

	// Token: 0x04003312 RID: 13074
	protected Image LeftCancelImg;

	// Token: 0x04003313 RID: 13075
	protected Image RightFlagAttack;

	// Token: 0x04003314 RID: 13076
	protected Image RightFlagDefense;

	// Token: 0x04003315 RID: 13077
	protected Image LeftFilterImg;

	// Token: 0x04003316 RID: 13078
	protected Image LeftFilterOnImg;

	// Token: 0x04003317 RID: 13079
	protected CanvasGroup FilterEff;

	// Token: 0x04003318 RID: 13080
	protected RallyTimeBar TopBar;

	// Token: 0x04003319 RID: 13081
	protected RallyTimeBar LeftBar;

	// Token: 0x0400331A RID: 13082
	protected GameObject TopAttackIcon;

	// Token: 0x0400331B RID: 13083
	protected GameObject TopTargetIcon;

	// Token: 0x0400331C RID: 13084
	protected GameObject LeftAttackIcon;

	// Token: 0x0400331D RID: 13085
	protected GameObject LeftTargetIcon;

	// Token: 0x0400331E RID: 13086
	protected GameObject TopCountry;

	// Token: 0x0400331F RID: 13087
	protected GameObject TopLayerBlue;

	// Token: 0x04003320 RID: 13088
	protected UIButton FilterBtn;

	// Token: 0x04003321 RID: 13089
	protected UIButton JoinBtn;

	// Token: 0x04003322 RID: 13090
	protected UIButton CancelBtn;

	// Token: 0x04003323 RID: 13091
	protected UIButton TopUnderLineBtn;

	// Token: 0x04003324 RID: 13092
	protected UIButton LeftUnderLineBtn;

	// Token: 0x04003325 RID: 13093
	protected UIButton RallySpeedupBtn;

	// Token: 0x04003326 RID: 13094
	protected UIButton InfoBtn;

	// Token: 0x04003327 RID: 13095
	protected UIButton StaticBtn;

	// Token: 0x04003328 RID: 13096
	protected uButtonScale JoinScale;

	// Token: 0x04003329 RID: 13097
	protected uButtonScale CancelScale;

	// Token: 0x0400332A RID: 13098
	protected UISpritesArray SPriteArray;

	// Token: 0x0400332B RID: 13099
	protected UISpritesArray ArmySpriteArray;

	// Token: 0x0400332C RID: 13100
	protected ScrollPanel RallyScroll;

	// Token: 0x0400332D RID: 13101
	protected byte DelayInit = 1;

	// Token: 0x0400332E RID: 13102
	protected List<float> ItemsHeight = new List<float>();

	// Token: 0x0400332F RID: 13103
	protected List<byte> ItemsExtend = new List<byte>();

	// Token: 0x04003330 RID: 13104
	protected Rally.RallyItem[] ItemEdit;

	// Token: 0x04003331 RID: 13105
	protected string RallyTitleStr;

	// Token: 0x04003332 RID: 13106
	protected int Parm1;

	// Token: 0x04003333 RID: 13107
	protected Rally.RallyArmyHint ArmyStatisticHint;

	// Token: 0x04003334 RID: 13108
	protected Rally._Conbat MemberCombat;

	// Token: 0x020002F7 RID: 759
	protected enum UIControl
	{
		// Token: 0x04003336 RID: 13110
		Background,
		// Token: 0x04003337 RID: 13111
		TopLayer,
		// Token: 0x04003338 RID: 13112
		Title,
		// Token: 0x04003339 RID: 13113
		LeftLayer,
		// Token: 0x0400333A RID: 13114
		RightLayer,
		// Token: 0x0400333B RID: 13115
		Close,
		// Token: 0x0400333C RID: 13116
		Hint
	}

	// Token: 0x020002F8 RID: 760
	private enum TopControl
	{
		// Token: 0x0400333E RID: 13118
		Blue,
		// Token: 0x0400333F RID: 13119
		Target,
		// Token: 0x04003340 RID: 13120
		Hero,
		// Token: 0x04003341 RID: 13121
		Country,
		// Token: 0x04003342 RID: 13122
		Name,
		// Token: 0x04003343 RID: 13123
		Bar,
		// Token: 0x04003344 RID: 13124
		Info
	}

	// Token: 0x020002F9 RID: 761
	private enum LeftControl
	{
		// Token: 0x04003346 RID: 13126
		Image,
		// Token: 0x04003347 RID: 13127
		Sponsor,
		// Token: 0x04003348 RID: 13128
		Bar,
		// Token: 0x04003349 RID: 13129
		Speedup,
		// Token: 0x0400334A RID: 13130
		Hero,
		// Token: 0x0400334B RID: 13131
		Filter,
		// Token: 0x0400334C RID: 13132
		Name,
		// Token: 0x0400334D RID: 13133
		Join,
		// Token: 0x0400334E RID: 13134
		Cancel
	}

	// Token: 0x020002FA RID: 762
	private enum RightControl
	{
		// Token: 0x04003350 RID: 13136
		Static,
		// Token: 0x04003351 RID: 13137
		Flag,
		// Token: 0x04003352 RID: 13138
		Title,
		// Token: 0x04003353 RID: 13139
		Combat,
		// Token: 0x04003354 RID: 13140
		Message,
		// Token: 0x04003355 RID: 13141
		Scroll,
		// Token: 0x04003356 RID: 13142
		Item,
		// Token: 0x04003357 RID: 13143
		Hint
	}

	// Token: 0x020002FB RID: 763
	private enum ItemControl
	{
		// Token: 0x04003359 RID: 13145
		List,
		// Token: 0x0400335A RID: 13146
		Name,
		// Token: 0x0400335B RID: 13147
		Combat,
		// Token: 0x0400335C RID: 13148
		Bar,
		// Token: 0x0400335D RID: 13149
		Icon,
		// Token: 0x0400335E RID: 13150
		Speedup,
		// Token: 0x0400335F RID: 13151
		RallyText,
		// Token: 0x04003360 RID: 13152
		RallyTitleText,
		// Token: 0x04003361 RID: 13153
		Kick,
		// Token: 0x04003362 RID: 13154
		Extend
	}

	// Token: 0x020002FC RID: 764
	public enum ClickType
	{
		// Token: 0x04003364 RID: 13156
		Filter,
		// Token: 0x04003365 RID: 13157
		Close,
		// Token: 0x04003366 RID: 13158
		Join,
		// Token: 0x04003367 RID: 13159
		Cancel,
		// Token: 0x04003368 RID: 13160
		StartNow,
		// Token: 0x04003369 RID: 13161
		Jump,
		// Token: 0x0400336A RID: 13162
		JoinWonders,
		// Token: 0x0400336B RID: 13163
		CancelWonders,
		// Token: 0x0400336C RID: 13164
		CancelJoin,
		// Token: 0x0400336D RID: 13165
		WonderDefFilter,
		// Token: 0x0400336E RID: 13166
		RallySpeed,
		// Token: 0x0400336F RID: 13167
		Info,
		// Token: 0x04003370 RID: 13168
		ChangeLeader,
		// Token: 0x04003371 RID: 13169
		Kick,
		// Token: 0x04003372 RID: 13170
		JoinNPC,
		// Token: 0x04003373 RID: 13171
		Static
	}

	// Token: 0x020002FD RID: 765
	public enum TextType
	{
		// Token: 0x04003375 RID: 13173
		TopCountry,
		// Token: 0x04003376 RID: 13174
		TopName,
		// Token: 0x04003377 RID: 13175
		LeftName,
		// Token: 0x04003378 RID: 13176
		RightTitle,
		// Token: 0x04003379 RID: 13177
		TopWonders
	}

	// Token: 0x020002FE RID: 766
	public enum eSpriteArray
	{
		// Token: 0x0400337B RID: 13179
		DefenceBtn,
		// Token: 0x0400337C RID: 13180
		DefenceBtnOn,
		// Token: 0x0400337D RID: 13181
		ExtendBtn,
		// Token: 0x0400337E RID: 13182
		ExtendBtnOn,
		// Token: 0x0400337F RID: 13183
		JoinBtn,
		// Token: 0x04003380 RID: 13184
		CancelBtn
	}

	// Token: 0x020002FF RID: 767
	public enum RallyProtocol
	{
		// Token: 0x04003382 RID: 13186
		OwnTroop = 32768,
		// Token: 0x04003383 RID: 13187
		Mask = 32768
	}

	// Token: 0x02000300 RID: 768
	protected struct _Conbat : IUIButtonDownUpHandler
	{
		// Token: 0x06000F95 RID: 3989 RVA: 0x001B5788 File Offset: 0x001B3988
		public _Conbat(Transform transform, Font font)
		{
			this.gameobject = transform.gameObject;
			this.CombatText = transform.GetChild(1).GetComponent<UIText>();
			this.CombatText.font = font;
			this.AttackText = transform.GetChild(3).GetComponent<UIText>();
			this.AttackText.font = font;
			this.AttackObj = transform.GetChild(2).gameObject;
			this.CombatStr = StringManager.Instance.SpawnString(32);
			this.AttackStr = StringManager.Instance.SpawnString(32);
			this.HintStr = StringManager.Instance.SpawnString(512);
			this.hint = this.gameobject.AddComponent<UIButtonHint>();
			this.hint.m_DownUpHandler = this;
			this.hint.m_eHint = EUIButtonHint.DownUpHandler;
		}

		// Token: 0x06000F96 RID: 3990 RVA: 0x001B585C File Offset: 0x001B3A5C
		public void SetCombatVal(uint val)
		{
			uint num = 1600u + DataManager.Instance.WarlobbyDetail.AddCombatPower;
			StringTable mStringTable = DataManager.Instance.mStringTable;
			this.CombatStr.ClearString();
			this.CombatStr.IntToFormat((long)((ulong)val), 1, true);
			this.CombatStr.IntToFormat((long)((ulong)num), 1, true);
			this.CombatStr.AppendFormat(mStringTable.GetStringByID(12247u));
			this.CombatText.text = this.CombatStr.ToString();
			this.CombatText.SetAllDirty();
			this.CombatText.cachedTextGenerator.Invalidate();
			double f = 10000UL * (ulong)val / 1600UL / 100.0;
			this.HintStr.ClearString();
			this.HintStr.DoubleToFormat(f, 2, false);
			this.HintStr.AppendFormat(mStringTable.GetStringByID(12246u));
			if (val == 0u)
			{
				this.AttackObj.SetActive(false);
				this.AttackText.text = string.Empty;
				return;
			}
			this.AttackObj.SetActive(true);
			this.AttackStr.ClearString();
			this.AttackStr.DoubleToFormat(f, 2, false);
			if (GUIManager.Instance.IsArabic)
			{
				this.AttackStr.AppendFormat("%{0}");
			}
			else
			{
				this.AttackStr.AppendFormat("{0}%");
			}
			this.AttackText.text = this.AttackStr.ToString();
			this.AttackText.SetAllDirty();
			this.AttackText.cachedTextGenerator.Invalidate();
		}

		// Token: 0x06000F97 RID: 3991 RVA: 0x001B59F8 File Offset: 0x001B3BF8
		public void OnButtonDown(UIButtonHint sender)
		{
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 320f, 20, this.HintStr, Vector2.zero);
		}

		// Token: 0x06000F98 RID: 3992 RVA: 0x001B5A2C File Offset: 0x001B3C2C
		public void OnButtonUp(UIButtonHint sender)
		{
			GUIManager.Instance.m_Hint.Hide(true);
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x001B5A40 File Offset: 0x001B3C40
		public void UpdateHint()
		{
			if (GUIManager.Instance.m_Hint.gameObject.activeSelf && GUIManager.Instance.m_Hint.GetButtonHint() == this.hint)
			{
				GUIManager.Instance.m_Hint.Show(this.hint, UIHintStyle.eHintSimple, 0, 320f, 20, this.HintStr, Vector2.zero);
			}
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x001B5AB0 File Offset: 0x001B3CB0
		public void TextRefresh()
		{
			this.CombatText.enabled = false;
			this.CombatText.enabled = true;
			this.AttackText.enabled = false;
			this.AttackText.enabled = true;
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x001B5AF0 File Offset: 0x001B3CF0
		public void OnClose()
		{
			StringManager.Instance.DeSpawnString(this.CombatStr);
			StringManager.Instance.DeSpawnString(this.AttackStr);
			StringManager.Instance.DeSpawnString(this.HintStr);
		}

		// Token: 0x04003384 RID: 13188
		public GameObject gameobject;

		// Token: 0x04003385 RID: 13189
		private UIText CombatText;

		// Token: 0x04003386 RID: 13190
		private UIText AttackText;

		// Token: 0x04003387 RID: 13191
		private CString CombatStr;

		// Token: 0x04003388 RID: 13192
		private CString AttackStr;

		// Token: 0x04003389 RID: 13193
		public CString HintStr;

		// Token: 0x0400338A RID: 13194
		private GameObject AttackObj;

		// Token: 0x0400338B RID: 13195
		private UIButtonHint hint;
	}

	// Token: 0x02000301 RID: 769
	protected class RallyItem : IUIButtonClickHandler, IUIButtonDownUpHandler, IUTimeBarOnTimer
	{
		// Token: 0x06000F9C RID: 3996 RVA: 0x001B5B30 File Offset: 0x001B3D30
		public RallyItem(UISpritesArray SpriteArray, UISpritesArray ArmySpriteArray, Transform Item, Rally Inst)
		{
			this.SpriteArray = SpriteArray;
			this.ArmySpriteArray = ArmySpriteArray;
			this.ParentInst = Inst;
			this.ThisRect = Item.GetComponent<RectTransform>();
			this.ListImg = Item.GetChild(0).GetComponent<Image>();
			UIButton component = Item.GetChild(0).GetComponent<UIButton>();
			component.m_BtnID1 = 0;
			component.m_Handler = this;
			this.NameText = Item.GetChild(1).GetComponent<UIText>();
			this.CombatText = Item.GetChild(2).GetChild(0).GetComponent<UIText>();
			this.CombatObj = Item.GetChild(2).gameObject;
			this.Bar = new RallyTimeBar(Item.GetChild(3).GetComponent<UITimeBar>(), 0);
			this.SpeedupBtn = Item.GetChild(5).GetComponent<UIButton>();
			this.SpeedupBtn.m_BtnID1 = 1;
			this.SpeedupBtn.m_Handler = this;
			if (GUIManager.Instance.IsArabic)
			{
				this.SpeedupBtn.transform.localScale = new Vector3(-1f, 1f, 1f);
			}
			this.KickBtnRect = Item.GetChild(8).GetComponent<RectTransform>();
			component = Item.GetChild(8).GetComponent<UIButton>();
			component.m_BtnID1 = 2;
			component.m_Handler = this;
			this.RallyNumText = Item.GetChild(6).GetComponent<UIText>();
			this.Extend = Item.GetChild(9).GetComponent<RectTransform>();
			this.RallyTitleText = Item.GetChild(7).GetComponent<UIText>();
			this.RallyTitleText.rectTransform.anchoredPosition = new Vector2(293f, -44f);
			for (int i = 0; i < 16; i++)
			{
				this.ArmyData[i].ArmyTypeText = this.Extend.GetChild(0).GetChild(i).GetComponent<UIText>();
				this.ArmyData[i].ArmyNumText = this.Extend.GetChild(0).GetChild(i).GetChild(0).GetComponent<Text>();
				this.ArmyData[i].ArmyNumStr = StringManager.Instance.SpawnString(30);
				this.ArmyData[i].ArmyRankStr = StringManager.Instance.SpawnString(30);
				this.ArmyData[i].HintRect = this.Extend.GetChild(1).GetChild(i).GetComponent<RectTransform>();
				this.ArmyData[i].ArmyHint = this.ArmyData[i].HintRect.gameObject.AddComponent<UIButtonHint>();
				this.ArmyData[i].ArmyHint.m_eHint = EUIButtonHint.CountDown;
				this.ArmyData[i].ArmyHint.DelayTime = 0.2f;
				this.ArmyData[i].ArmyHint.m_DownUpHandler = this;
				this.ArmyData[i].ArmyRankText = this.Extend.GetChild(1).GetChild(i).GetChild(1).GetComponent<Text>();
				this.ArmyData[i].ArmyIcon = this.Extend.GetChild(1).GetChild(i).GetChild(0).GetComponent<Image>();
			}
			this.Bar.TimeBar.m_Handler = this;
			this.RallyNumStr = StringManager.Instance.SpawnString(30);
			this.CombatStr = StringManager.Instance.SpawnString(30);
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x001B5EA4 File Offset: 0x001B40A4
		public void SetRallyItem(int DataIndex, int PanelIndex, byte Extend, bool bShowCombat)
		{
			this.DataIndex = DataIndex;
			this.PanelIndex = PanelIndex;
			this.SpeedupBtn.m_BtnID2 = DataIndex;
			DataManager instance = DataManager.Instance;
			if (Extend == 1)
			{
				this.Extend.gameObject.SetActive(true);
				this.SetArymNum(DataManager.Instance.WarTroop[DataIndex].TroopSize);
			}
			else
			{
				this.Extend.gameObject.SetActive(false);
			}
			this.UpdateKickBtnState(Extend);
			this.ListImg.sprite = this.SpriteArray.GetSprite((int)(2 + Extend));
			if (instance.WarTroop.Count <= DataIndex)
			{
				return;
			}
			WarlobbyTroop warlobbyTroop = instance.WarTroop[DataIndex];
			if (warlobbyTroop == null)
			{
				return;
			}
			this.NameText.text = warlobbyTroop.AllyName.ToString();
			this.NameText.SetAllDirty();
			this.NameText.cachedTextGenerator.Invalidate();
			this.RallyNumStr.ClearString();
			this.RallyNumStr.IntToFormat((long)((ulong)warlobbyTroop.TotalTroopNum), 1, true);
			this.RallyNumStr.AppendFormat("{0}");
			this.RallyNumText.text = this.RallyNumStr.ToString();
			this.RallyNumText.SetAllDirty();
			this.RallyNumText.cachedTextGenerator.Invalidate();
			if (bShowCombat && warlobbyTroop.CombatPower > 0u)
			{
				this.CombatObj.SetActive(true);
				this.CombatStr.ClearString();
				this.CombatStr.IntToFormat((long)((ulong)warlobbyTroop.CombatPower), 1, true);
				this.CombatStr.AppendFormat("{0}");
				this.CombatText.text = this.CombatStr.ToString();
				this.CombatText.SetAllDirty();
				this.CombatText.cachedTextGenerator.Invalidate();
			}
			else
			{
				this.CombatObj.SetActive(false);
			}
			if (warlobbyTroop.MarchTime.BeginTime > 0L && warlobbyTroop.MarchTime.RequireTime > 0u)
			{
				if (warlobbyTroop.MarchTime.BeginTime + (long)((ulong)warlobbyTroop.MarchTime.RequireTime) > instance.ServerTime)
				{
					this.SetTimeBarVisibility(true);
					this.Bar.SetTimebar(0, warlobbyTroop.MarchTime.BeginTime, warlobbyTroop.MarchTime.BeginTime + (long)((ulong)warlobbyTroop.MarchTime.RequireTime), 0L);
					this.Bar.Title.text = instance.mStringTable.GetStringByID(4914u);
				}
				else
				{
					this.SetTimeBarVisibility(false);
				}
			}
			else
			{
				this.SetTimeBarVisibility(false);
			}
			byte b = 0;
			byte b2 = 1;
			for (int i = 0; i < 16; i++)
			{
				int num = (16 - i >> 2) + Mathf.Clamp(16 - i & 3, 0, 1);
				int num2 = num + (i & 3) * 4 - 1;
				if ((warlobbyTroop.TroopFlag >> num2 & 1) == 1)
				{
					SoldierData recordByKey = instance.SoldierDataTable.GetRecordByKey((ushort)(num2 + 1));
					this.ArmyData[(int)b].ArmyTypeText.text = instance.mStringTable.GetStringByID((uint)recordByKey.Name);
					this.ArmyData[(int)b].ArmyNumStr.ClearString();
					this.ArmyData[(int)b].ArmyNumStr.IntToFormat((long)((ulong)warlobbyTroop.TroopData[num2 >> 2][num2 & 3]), 1, true);
					this.ArmyData[(int)b].ArmyNumStr.AppendFormat("{0}");
					this.ArmyData[(int)b].ArmyNumText.text = this.ArmyData[(int)b].ArmyNumStr.ToString();
					this.ArmyData[(int)b].ArmyNumText.SetAllDirty();
					this.ArmyData[(int)b].ArmyNumText.cachedTextGenerator.Invalidate();
					this.ArmyData[(int)b].SetArmyHint((short)num2, num, this.ArmySpriteArray);
					b += 1;
				}
				else
				{
					this.ArmyData[(int)(16 - b2)].SetArmyHint(short.MaxValue, 0, this.ArmySpriteArray);
					this.ArmyData[(int)(16 - b2)].ArmyTypeText.text = string.Empty;
					Rally.RallyItem.ArmyList[] armyData = this.ArmyData;
					int num3 = 16;
					byte b3 = b2;
					b2 = b3 + 1;
					armyData[num3 - (int)b3].ArmyNumText.text = string.Empty;
				}
			}
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x001B630C File Offset: 0x001B450C
		private void UpdateKickBtnState(byte Extend)
		{
			DataManager instance = DataManager.Instance;
			if (instance.WarlobbyDetail.AttackOrDefense == 1)
			{
				if (Extend == 1)
				{
					if (instance.WarlobbyDetail.WonderID != 255 && instance.WarTroop.Count > 1 && instance.WarTroop[0].AllyNameID == instance.RoleAttr.Name.GetHashCode(false))
					{
						this.KickBtnRect.gameObject.SetActive(true);
					}
					else if (instance.WarlobbyDetail.WonderID == 255 && instance.WarlobbyDetail.AllyNameID == instance.RoleAttr.Name.GetHashCode(false))
					{
						this.KickBtnRect.gameObject.SetActive(true);
					}
					else
					{
						this.KickBtnRect.gameObject.SetActive(false);
					}
				}
				else
				{
					this.KickBtnRect.gameObject.SetActive(false);
				}
			}
			else if (instance.WarlobbyDetail.AttackOrDefense == 0)
			{
				if (this.DataIndex == 0)
				{
					this.KickBtnRect.gameObject.SetActive(false);
				}
				else if (instance.MaxMarchEventNum > instance.WarlobbyDetail.SelfParticipateTroopIndex)
				{
					if (Extend == 1 && instance.WarlobbyDetail.Kind == 0 && (instance.MarchEventData[(int)instance.WarlobbyDetail.SelfParticipateTroopIndex].bRallyHost == 1 || instance.MarchEventData[(int)instance.WarlobbyDetail.SelfParticipateTroopIndex].bRallyHost == 4))
					{
						this.KickBtnRect.gameObject.SetActive(true);
					}
					else
					{
						this.KickBtnRect.gameObject.SetActive(false);
					}
				}
			}
			else if (this.DataIndex == 0 || Extend == 0 || instance.WarlobbyDetail.AllyNameID != instance.RoleAttr.Name.GetHashCode(false))
			{
				this.KickBtnRect.gameObject.SetActive(false);
			}
			else
			{
				this.KickBtnRect.gameObject.SetActive(true);
			}
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x001B6538 File Offset: 0x001B4738
		public void SetTimeBarVisibility(bool bShow)
		{
			if (bShow)
			{
				this.Bar.gameObject.SetActive(true);
				this.SpeedupBtn.gameObject.SetActive(true);
				this.RallyTitleText.text = string.Empty;
			}
			else
			{
				this.Bar.gameObject.SetActive(false);
				this.SpeedupBtn.gameObject.SetActive(false);
				this.RallyTitleText.text = this.ParentInst.RallyTitleStr;
			}
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x001B65BC File Offset: 0x001B47BC
		public void OnButtonClick(UIButton sender)
		{
			if (sender == null)
			{
				this.Extend.gameObject.SetActive(!this.Extend.gameObject.activeSelf);
				int num = (!this.Extend.gameObject.activeSelf) ? 0 : 1;
				if (this.Extend.gameObject.activeSelf)
				{
					this.UpdateKickBtnState(1);
				}
				else
				{
					this.UpdateKickBtnState(0);
				}
				this.ListImg.sprite = this.SpriteArray.GetSprite(2 + num);
				this.SetArymNum(DataManager.Instance.WarTroop[this.DataIndex].TroopSize);
				this.ParentInst.UpdateItemDataHeight(this.PanelIndex);
				return;
			}
			switch (sender.m_BtnID1)
			{
			case 0:
			{
				this.Extend.gameObject.SetActive(!this.Extend.gameObject.activeSelf);
				int num2 = (!this.Extend.gameObject.activeSelf) ? 0 : 1;
				this.ListImg.sprite = this.SpriteArray.GetSprite(2 + num2);
				this.SetArymNum(DataManager.Instance.WarTroop[this.DataIndex].TroopSize);
				this.ParentInst.UpdateItemDataHeight(this.PanelIndex);
				break;
			}
			case 1:
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.OpenMenu(EGUIWindow.UI_BagFilter, 2, sender.m_BtnID2 + 100, false);
				break;
			}
			case 2:
				this.ParentInst.KickMemberConfirm((ushort)this.DataIndex, DataManager.Instance.WarlobbyDetail.WonderID);
				break;
			}
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x001B6788 File Offset: 0x001B4988
		private void SetArymNum(byte Num)
		{
			Vector2 sizeDelta = this.ThisRect.sizeDelta;
			sizeDelta.y = 98f + (float)Num * 26f;
			this.ThisRect.sizeDelta = sizeDelta;
			this.KickBtnRect.anchoredPosition = new Vector2(this.KickBtnRect.anchoredPosition.x, (float)(-95 - (int)(26 * (Num -= 1))));
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x001B67F4 File Offset: 0x001B49F4
		public float GetItemHeight()
		{
			if (!this.Extend.gameObject.activeSelf)
			{
				this.SetArymNum(0);
			}
			return this.ThisRect.sizeDelta.y;
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x001B6830 File Offset: 0x001B4A30
		public void TextRefresh()
		{
			this.NameText.enabled = false;
			this.RallyNumText.enabled = false;
			this.RallyTitleText.enabled = false;
			this.NameText.enabled = true;
			this.RallyNumText.enabled = true;
			this.RallyTitleText.enabled = true;
			this.CombatText.enabled = false;
			this.CombatText.enabled = true;
			for (int i = 0; i < this.ArmyData.Length; i++)
			{
				this.ArmyData[i].ArmyNumText.enabled = false;
				this.ArmyData[i].ArmyTypeText.enabled = false;
				this.ArmyData[i].ArmyNumText.enabled = true;
				this.ArmyData[i].ArmyTypeText.enabled = true;
			}
			this.Bar.TextRefresh();
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x001B6920 File Offset: 0x001B4B20
		public void OnClose()
		{
			this.Bar.Destroy();
			StringManager.Instance.DeSpawnString(this.RallyNumStr);
			StringManager.Instance.DeSpawnString(this.CombatStr);
			for (int i = 0; i < this.ArmyData.Length; i++)
			{
				StringManager.Instance.DeSpawnString(this.ArmyData[i].ArmyNumStr);
				StringManager.Instance.DeSpawnString(this.ArmyData[i].ArmyRankStr);
			}
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x001B69AC File Offset: 0x001B4BAC
		public void Update()
		{
			this.Bar.Update();
		}

		// Token: 0x06000FA6 RID: 4006 RVA: 0x001B69BC File Offset: 0x001B4BBC
		public void OnTimer(UITimeBar sender)
		{
		}

		// Token: 0x06000FA7 RID: 4007 RVA: 0x001B69C0 File Offset: 0x001B4BC0
		public void OnNotify(UITimeBar sender)
		{
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x001B69C4 File Offset: 0x001B4BC4
		public void Onfunc(UITimeBar sender)
		{
		}

		// Token: 0x06000FA9 RID: 4009 RVA: 0x001B69C8 File Offset: 0x001B4BC8
		public void OnCancel(UITimeBar sender)
		{
		}

		// Token: 0x06000FAA RID: 4010 RVA: 0x001B69CC File Offset: 0x001B4BCC
		public void OnButtonDown(UIButtonHint sender)
		{
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 3, 277f, 20, (int)sender.Parm1, 0, new Vector2(70f, 0f), UIButtonHint.ePosition.Original);
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x001B6A0C File Offset: 0x001B4C0C
		public void OnButtonUp(UIButtonHint sender)
		{
			GUIManager.Instance.m_Hint.Hide(true);
		}

		// Token: 0x0400338C RID: 13196
		private Rally ParentInst;

		// Token: 0x0400338D RID: 13197
		private UISpritesArray SpriteArray;

		// Token: 0x0400338E RID: 13198
		private UISpritesArray ArmySpriteArray;

		// Token: 0x0400338F RID: 13199
		public RectTransform Extend;

		// Token: 0x04003390 RID: 13200
		public RectTransform ThisRect;

		// Token: 0x04003391 RID: 13201
		public RectTransform KickBtnRect;

		// Token: 0x04003392 RID: 13202
		private UIButton SpeedupBtn;

		// Token: 0x04003393 RID: 13203
		private Image ListImg;

		// Token: 0x04003394 RID: 13204
		private UIText NameText;

		// Token: 0x04003395 RID: 13205
		private UIText RallyNumText;

		// Token: 0x04003396 RID: 13206
		private UIText RallyTitleText;

		// Token: 0x04003397 RID: 13207
		private UIText CombatText;

		// Token: 0x04003398 RID: 13208
		private CString RallyNumStr;

		// Token: 0x04003399 RID: 13209
		private CString CombatStr;

		// Token: 0x0400339A RID: 13210
		private GameObject CombatObj;

		// Token: 0x0400339B RID: 13211
		private RallyTimeBar Bar;

		// Token: 0x0400339C RID: 13212
		public int DataIndex;

		// Token: 0x0400339D RID: 13213
		public int PanelIndex;

		// Token: 0x0400339E RID: 13214
		private Rally.RallyItem.ArmyList[] ArmyData = new Rally.RallyItem.ArmyList[16];

		// Token: 0x02000302 RID: 770
		private struct ArmyList
		{
			// Token: 0x06000FAC RID: 4012 RVA: 0x001B6A20 File Offset: 0x001B4C20
			public void SetArmyHint(short id, int rank, UISpritesArray spriteArray)
			{
				if (id == 32767)
				{
					this.HintRect.sizeDelta = new Vector2(0f, this.HintRect.sizeDelta.y);
					this.ArmyIcon.enabled = false;
					this.ArmyHint.enabled = false;
					this.ArmyRankText.text = string.Empty;
					return;
				}
				this.ArmyTypeText.cachedTextGeneratorForLayout.Invalidate();
				this.HintRect.sizeDelta = new Vector2(this.ArmyTypeText.preferredWidth + 33f, this.HintRect.sizeDelta.y);
				this.ArmyRankStr.ClearString();
				this.ArmyRankStr.IntToFormat((long)rank, 1, false);
				this.ArmyRankStr.AppendFormat("{0}");
				this.ArmyRankText.text = this.ArmyRankStr.ToString();
				this.ArmyRankText.SetAllDirty();
				this.ArmyRankText.cachedTextGenerator.Invalidate();
				this.ArmyIcon.enabled = true;
				this.ArmyIcon.sprite = spriteArray.GetSprite(id >> 2);
				this.ArmyHint.enabled = true;
				this.ArmyHint.Parm1 = (ushort)id;
			}

			// Token: 0x0400339F RID: 13215
			public UIText ArmyTypeText;

			// Token: 0x040033A0 RID: 13216
			public Text ArmyNumText;

			// Token: 0x040033A1 RID: 13217
			public CString ArmyNumStr;

			// Token: 0x040033A2 RID: 13218
			public CString ArmyRankStr;

			// Token: 0x040033A3 RID: 13219
			public UIButtonHint ArmyHint;

			// Token: 0x040033A4 RID: 13220
			public Image ArmyIcon;

			// Token: 0x040033A5 RID: 13221
			public Text ArmyRankText;

			// Token: 0x040033A6 RID: 13222
			public RectTransform HintRect;
		}

		// Token: 0x02000303 RID: 771
		private enum ClickType
		{
			// Token: 0x040033A8 RID: 13224
			List,
			// Token: 0x040033A9 RID: 13225
			Speedup,
			// Token: 0x040033AA RID: 13226
			Kick
		}
	}

	// Token: 0x02000304 RID: 772
	protected struct RallyArmyHint
	{
		// Token: 0x06000FAD RID: 4013 RVA: 0x001B6B64 File Offset: 0x001B4D64
		public RallyArmyHint(Transform transform, Font font, UISpritesArray IconArray)
		{
			this.gameobject = transform.gameObject;
			this.Army = new Rally.RallyArmyHint.ArmyInfo[16];
			for (int i = 0; i < 16; i++)
			{
				this.Army[i] = new Rally.RallyArmyHint.ArmyInfo(transform.GetChild(0).GetChild(i + 2), font, IconArray);
			}
			Image component = transform.GetChild(0).GetComponent<Image>();
			this.rectTransform = component.rectTransform;
			component.material = GUIManager.Instance.GetFrameMaterial();
			component.sprite = GUIManager.Instance.LoadFrameSprite("UI_main_box_099");
			this.TitleText = transform.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.TitleText.font = font;
			this.TitleText.text = DataManager.Instance.mStringTable.GetStringByID(4925u);
			this.MsgText = transform.GetChild(0).GetChild(1).GetComponent<UIText>();
			this.MsgText.font = font;
			RectTransform rectTransform = this.TitleText.rectTransform;
			this.DefHeight = rectTransform.rect.height * 2f;
			this.Hint = null;
			transform.SetParent(GUIManager.Instance.m_ItemInfoLayer, false);
			this.MsgStr = StringManager.Instance.SpawnString(64);
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x001B6CBC File Offset: 0x001B4EBC
		public void Show(UIButtonHint sender)
		{
			if (sender == null && !this.gameobject.activeSelf)
			{
				return;
			}
			DataManager instance = DataManager.Instance;
			byte b = 0;
			byte b2 = 1;
			uint[][] troop = instance.WarTroopStatistic.GetTroop();
			uint num = 0u;
			if (instance.WarlobbyDetail != null)
			{
				num = instance.WarlobbyDetail.AllyCurrTroop;
			}
			for (int i = 0; i < 16; i++)
			{
				int num2 = (16 - i >> 2) + Mathf.Clamp(16 - i & 3, 0, 1);
				int num3 = num2 + (i & 3) * 4 - 1;
				if (troop[num3 >> 2][num3 & 3] > 0u)
				{
					uint percentage;
					if (num > 0u)
					{
						percentage = troop[num3 >> 2][num3 & 3] * 1000u / num;
					}
					else
					{
						percentage = 0u;
					}
					this.Army[(int)b].Set(num3, num2, troop[num3 >> 2][num3 & 3], percentage);
					if (b > 0)
					{
						this.Army[(int)b].rectTransform.anchoredPosition = new Vector2(this.Army[0].rectTransform.anchoredPosition.x, this.Army[0].rectTransform.anchoredPosition.y - this.Army[0].rectTransform.sizeDelta.y * (float)b);
					}
					b += 1;
				}
				else
				{
					Rally.RallyArmyHint.ArmyInfo[] army = this.Army;
					int num4 = 16;
					byte b3 = b2;
					b2 = b3 + 1;
					army[num4 - (int)b3].Hide();
				}
			}
			if (b == 0)
			{
				this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(4824u);
				this.MsgText.alignment = TextAnchor.LowerCenter;
				this.MsgText.color = Color.white;
				this.rectTransform.sizeDelta = new Vector2(this.rectTransform.sizeDelta.x, 83f);
			}
			else
			{
				this.MsgText.alignment = TextAnchor.LowerRight;
				this.MsgText.color = new Color32(233, 207, 167, byte.MaxValue);
				this.MsgStr.ClearString();
				this.MsgStr.IntToFormat((long)instance.WarTroop.Count, 1, false);
				this.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12245u));
				this.MsgText.text = this.MsgStr.ToString();
				this.MsgText.SetAllDirty();
				this.MsgText.cachedTextGenerator.Invalidate();
				this.rectTransform.sizeDelta = new Vector2(this.rectTransform.sizeDelta.x, this.DefHeight + (float)b * this.Army[0].rectTransform.sizeDelta.y + this.MsgText.rectTransform.sizeDelta.y);
			}
			this.gameobject.SetActive(true);
			if (sender != null)
			{
				this.Hint = sender;
				this.Hint.GetTipPosition(this.rectTransform, UIButtonHint.ePosition.Original, null);
			}
			else if (this.Hint != null)
			{
				this.Hint.GetTipPosition(this.rectTransform, UIButtonHint.ePosition.Original, null);
			}
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x001B7040 File Offset: 0x001B5240
		public void Hide()
		{
			if (this.gameobject != null)
			{
				this.gameobject.SetActive(false);
			}
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x001B7060 File Offset: 0x001B5260
		public void TextRefresh()
		{
			this.TitleText.enabled = false;
			this.TitleText.enabled = true;
			this.MsgText.enabled = false;
			this.MsgText.enabled = true;
			for (int i = 0; i < 16; i++)
			{
				this.Army[i].TextRefresh();
			}
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x001B70C4 File Offset: 0x001B52C4
		public void OnClose()
		{
			for (int i = 0; i < 16; i++)
			{
				this.Army[i].OnClose();
			}
			StringManager.Instance.DeSpawnString(this.MsgStr);
			UnityEngine.Object.Destroy(this.gameobject);
			this.gameobject = null;
		}

		// Token: 0x040033AB RID: 13227
		public RectTransform rectTransform;

		// Token: 0x040033AC RID: 13228
		private GameObject gameobject;

		// Token: 0x040033AD RID: 13229
		private Rally.RallyArmyHint.ArmyInfo[] Army;

		// Token: 0x040033AE RID: 13230
		private UIText TitleText;

		// Token: 0x040033AF RID: 13231
		private UIText MsgText;

		// Token: 0x040033B0 RID: 13232
		private CString MsgStr;

		// Token: 0x040033B1 RID: 13233
		private float DefHeight;

		// Token: 0x040033B2 RID: 13234
		private UIButtonHint Hint;

		// Token: 0x02000305 RID: 773
		private struct ArmyInfo
		{
			// Token: 0x06000FB2 RID: 4018 RVA: 0x001B7118 File Offset: 0x001B5318
			public ArmyInfo(Transform transform, Font font, UISpritesArray IconArray)
			{
				this.gameobject = transform.gameObject;
				this.rectTransform = (transform as RectTransform);
				this.PercentText = transform.GetChild(0).GetComponent<UIText>();
				this.PercentText.font = font;
				this.Icon = transform.GetChild(1).GetComponent<Image>();
				this.RankText = transform.GetChild(2).GetComponent<UIText>();
				this.RankText.font = font;
				this.NameText = transform.GetChild(3).GetComponent<UIText>();
				this.NameText.font = font;
				this.QtyText = transform.GetChild(4).GetComponent<UIText>();
				this.QtyText.font = font;
				this.RankStr = StringManager.Instance.SpawnString(30);
				this.QtyStr = StringManager.Instance.SpawnString(30);
				this.PercentStr = StringManager.Instance.SpawnString(30);
				this.IconArray = IconArray;
			}

			// Token: 0x06000FB3 RID: 4019 RVA: 0x001B7204 File Offset: 0x001B5404
			public void Set(int id, int rank, uint qty, uint percentage)
			{
				this.gameobject.SetActive(true);
				this.PercentStr.ClearString();
				this.PercentStr.DoubleToFormat(percentage / 10.0, -1, true);
				if (GUIManager.Instance.IsArabic)
				{
					this.PercentStr.AppendFormat("%{0}");
				}
				else
				{
					this.PercentStr.AppendFormat("{0}%");
				}
				this.PercentText.text = this.PercentStr.ToString();
				this.PercentText.SetAllDirty();
				this.PercentText.cachedTextGenerator.Invalidate();
				this.Icon.sprite = this.IconArray.GetSprite(id >> 2);
				this.RankStr.ClearString();
				this.RankStr.IntToFormat((long)rank, 1, false);
				this.RankStr.AppendFormat("{0}");
				this.RankText.text = this.RankStr.ToString();
				this.RankText.SetAllDirty();
				this.RankText.cachedTextGenerator.Invalidate();
				SoldierData recordByKey = DataManager.Instance.SoldierDataTable.GetRecordByKey((ushort)(id + 1));
				this.NameText.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.Name);
				this.QtyStr.ClearString();
				this.QtyStr.IntToFormat((long)((ulong)qty), 1, true);
				this.QtyStr.AppendFormat("{0}");
				this.QtyText.text = this.QtyStr.ToString();
				this.QtyText.SetAllDirty();
				this.QtyText.cachedTextGenerator.Invalidate();
			}

			// Token: 0x06000FB4 RID: 4020 RVA: 0x001B73B0 File Offset: 0x001B55B0
			public void Hide()
			{
				this.gameobject.SetActive(false);
			}

			// Token: 0x06000FB5 RID: 4021 RVA: 0x001B73C0 File Offset: 0x001B55C0
			public void TextRefresh()
			{
				this.PercentText.enabled = false;
				this.PercentText.enabled = true;
				this.RankText.enabled = false;
				this.RankText.enabled = true;
				this.NameText.enabled = false;
				this.NameText.enabled = true;
				this.QtyText.enabled = false;
				this.QtyText.enabled = true;
			}

			// Token: 0x06000FB6 RID: 4022 RVA: 0x001B7430 File Offset: 0x001B5630
			public void OnClose()
			{
				StringManager.Instance.DeSpawnString(this.PercentStr);
				StringManager.Instance.DeSpawnString(this.RankStr);
				StringManager.Instance.DeSpawnString(this.QtyStr);
			}

			// Token: 0x040033B3 RID: 13235
			public RectTransform rectTransform;

			// Token: 0x040033B4 RID: 13236
			private GameObject gameobject;

			// Token: 0x040033B5 RID: 13237
			private Image Icon;

			// Token: 0x040033B6 RID: 13238
			private UIText RankText;

			// Token: 0x040033B7 RID: 13239
			private UIText NameText;

			// Token: 0x040033B8 RID: 13240
			private UIText QtyText;

			// Token: 0x040033B9 RID: 13241
			private UIText PercentText;

			// Token: 0x040033BA RID: 13242
			private CString RankStr;

			// Token: 0x040033BB RID: 13243
			private CString QtyStr;

			// Token: 0x040033BC RID: 13244
			private CString PercentStr;

			// Token: 0x040033BD RID: 13245
			private UISpritesArray IconArray;
		}
	}
}
