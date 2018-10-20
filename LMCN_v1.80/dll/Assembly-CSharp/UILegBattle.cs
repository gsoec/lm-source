using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200020F RID: 527
public class UILegBattle : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x0600098F RID: 2447 RVA: 0x000C46EC File Offset: 0x000C28EC
	public override void OnOpen(int arg1, int arg2)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (GUIManager.Instance.IsArabic)
		{
			this.mHudBeginPos_L = new Vector2(250f, -200f);
			this.mHudBeginPos_R = new Vector2(-250f, -200f);
		}
		else
		{
			this.mHudBeginPos_L = new Vector2(-250f, -200f);
			this.mHudBeginPos_R = new Vector2(250f, -200f);
		}
		this.TTF = GUIManager.Instance.GetTTFFont();
		this.IsPlayerAttack = (arg1 == 0);
		this.IsSimulation = (arg2 != 0);
		this.m_SimulationType = (eLegBattleSimulationType)arg2;
		this.alertBlock = base.transform.GetChild(0);
		this.alertBlock_T = base.transform.GetChild(0).GetChild(0).GetComponent<Image>();
		this.alertBlock_B = base.transform.GetChild(0).GetChild(1).GetComponent<Image>();
		this.alertBlock_R = base.transform.GetChild(0).GetChild(2).GetComponent<Image>();
		this.alertBlock_L = base.transform.GetChild(0).GetChild(3).GetComponent<Image>();
		this.m_BattlePanel = base.transform.GetChild(1);
		this.MaxHudMsg = this.m_BattlePanel.GetChild(6).childCount;
		this.m_HudArray = new sHudMsg[this.MaxHudMsg];
		this.m_CenterMsg = this.m_BattlePanel.GetChild(7).GetChild(0);
		this.m_CenterMsgBg = this.m_CenterMsg.GetComponent<Image>();
		this.m_CenterMsgText = this.m_CenterMsg.GetChild(0).GetComponent<UIText>();
		this.m_CenterMsgIcon = this.m_CenterMsg.GetChild(1).GetComponent<Image>();
		this.m_CenterMsgText.font = this.TTF;
		this.m_Str = new CString[9];
		this.m_HudStr = new CString[this.MaxHudMsg];
		this.m_HudWorkArray_L = new List<sHudMsg>();
		this.m_HudWorkArray_R = new List<sHudMsg>();
		for (int i = 0; i < this.MaxHudMsg; i++)
		{
			this.m_HudArray[i] = new sHudMsg(0);
			this.m_HudArray[i].Trnas = this.m_BattlePanel.GetChild(6).GetChild(i);
			this.m_HudArray[i].Msg = this.m_BattlePanel.GetChild(6).GetChild(i).GetChild(0).GetComponent<UIText>();
			this.m_HudArray[i].Msg.font = this.TTF;
			this.m_HudArray[i].Bg = this.m_BattlePanel.GetChild(6).GetChild(i).GetComponent<Image>();
			this.m_HudArray[i].Idx = i;
			this.m_HudStr[i] = StringManager.Instance.SpawnString(40);
		}
		this.m_SpArray = base.transform.GetComponent<UISpritesArray>();
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			Image component = this.m_BattlePanel.GetChild(2).GetChild(0).GetComponent<Image>();
			component.sprite = this.m_SpArray.GetSprite(8);
			component = this.m_BattlePanel.GetChild(2).GetChild(1).GetComponent<Image>();
			component.sprite = this.m_SpArray.GetSprite(9);
		}
		this.m_FlashImage[0] = this.m_BattlePanel.GetChild(2).GetChild(1).GetComponent<Image>();
		this.m_Hint = this.m_BattlePanel.GetChild(3);
		this.m_HintRect = this.m_Hint.GetComponent<RectTransform>();
		this.m_HintRect.anchorMax = Vector2.zero;
		this.m_HintRect.anchorMin = Vector2.zero;
		this.m_HintRect.pivot = new Vector2(0.5f, 0.5f);
		this.m_HintIcon = this.m_Hint.GetChild(0).GetComponent<Image>();
		this.m_HintText1 = this.m_Hint.GetChild(1).GetComponent<UIText>();
		this.m_HintText1.font = this.TTF;
		this.m_HintText2 = this.m_Hint.GetChild(2).GetComponent<UIText>();
		this.m_HintText2.font = this.TTF;
		this.m_AttackName = this.m_BattlePanel.GetChild(0).GetChild(7).GetComponent<UIText>();
		this.m_AttackName.font = this.TTF;
		this.m_AttackValue = this.m_BattlePanel.GetChild(0).GetChild(9).GetComponent<UIText>();
		this.m_AttackValue.font = this.TTF;
		this.m_AttackMoraleValue = this.m_BattlePanel.GetChild(0).GetChild(8).GetComponent<UIText>();
		this.m_AttackMoraleValue.font = this.TTF;
		this.m_AttackSlider = this.m_BattlePanel.GetChild(0).GetChild(3).GetComponent<Image>();
		this.m_DefendName = this.m_BattlePanel.GetChild(1).GetChild(7).GetComponent<UIText>();
		this.m_DefendName.font = this.TTF;
		this.m_DefendValue = this.m_BattlePanel.GetChild(1).GetChild(9).GetComponent<UIText>();
		this.m_DefendValue.font = this.TTF;
		this.m_DefendMoraleValue = this.m_BattlePanel.GetChild(1).GetChild(8).GetComponent<UIText>();
		this.m_DefendMoraleValue.font = this.TTF;
		this.m_DefendSlider = this.m_BattlePanel.GetChild(1).GetChild(3).GetComponent<Image>();
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			Image component2 = this.m_BattlePanel.GetChild(4).GetComponent<Image>();
			if (component2)
			{
				component2.enabled = false;
			}
		}
		UIButton component3 = this.m_BattlePanel.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 0;
		component3 = this.m_BattlePanel.GetChild(5).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 3;
		this.m_PausePanel = base.transform.GetChild(2);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			((RectTransform)this.m_PausePanel).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)this.m_PausePanel).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		component3 = this.m_PausePanel.GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 1;
		UIText component4 = this.m_PausePanel.GetChild(0).GetChild(0).GetComponent<UIText>();
		component4.font = this.TTF;
		component4.text = DataManager.Instance.mStringTable.GetStringByID(241u);
		component3 = this.m_PausePanel.GetChild(1).GetComponent<UIButton>();
		component3.m_Handler = this;
		component4 = this.m_PausePanel.GetChild(1).GetChild(0).GetComponent<UIText>();
		component4.font = this.TTF;
		component4.text = DataManager.Instance.mStringTable.GetStringByID(240u);
		component3.m_BtnID1 = 2;
		if (GUIManager.Instance.IsArabic)
		{
			this.m_PausePanel.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.m_BattleClearPanel = base.transform.GetChild(3);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			RectTransform rectTransform = (RectTransform)this.m_BattleClearPanel.GetChild(0);
			rectTransform.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, rectTransform.offsetMin.y);
			rectTransform.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, rectTransform.offsetMax.y);
			rectTransform = (RectTransform)this.m_BattleClearPanel.GetChild(1);
			rectTransform.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, rectTransform.offsetMin.y);
			rectTransform.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, rectTransform.offsetMax.y);
			rectTransform = (RectTransform)this.m_BattleClearPanel.GetChild(2);
			rectTransform.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, rectTransform.offsetMin.y);
			rectTransform.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, rectTransform.offsetMax.y);
		}
		this.m_ClearPanelAttackImage = this.m_BattleClearPanel.GetChild(3).GetChild(3).GetComponent<Image>();
		this.m_ClearPanelAttackName = this.m_BattleClearPanel.GetChild(3).GetChild(3).GetChild(0).GetComponent<UIText>();
		this.m_ClearPanelAttackName.font = this.TTF;
		component4 = this.m_BattleClearPanel.GetChild(3).GetChild(3).GetChild(1).GetComponent<UIText>();
		component4.font = this.TTF;
		component4.text = DataManager.Instance.mStringTable.GetStringByID(580u);
		this.m_ClearPanelAttackValue = this.m_BattleClearPanel.GetChild(3).GetChild(3).GetChild(2).GetComponent<UIText>();
		this.m_ClearPanelAttackValue.font = this.TTF;
		this.m_ClearPanelDefendImage = this.m_BattleClearPanel.GetChild(3).GetChild(4).GetComponent<Image>();
		this.m_ClearPanelDefendName = this.m_BattleClearPanel.GetChild(3).GetChild(4).GetChild(0).GetComponent<UIText>();
		this.m_ClearPanelDefendName.font = this.TTF;
		component4 = this.m_BattleClearPanel.GetChild(3).GetChild(4).GetChild(1).GetComponent<UIText>();
		component4.font = this.TTF;
		component4.text = DataManager.Instance.mStringTable.GetStringByID(580u);
		this.m_ClearPanelDefendValue = this.m_BattleClearPanel.GetChild(3).GetChild(4).GetChild(2).GetComponent<UIText>();
		this.m_ClearPanelDefendValue.font = this.TTF;
		this.m_ClearPanelVS = this.m_BattleClearPanel.GetChild(3).GetChild(7).GetChild(0).GetComponent<Image>();
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			Image component5 = this.m_BattleClearPanel.GetChild(3).GetChild(7).GetComponent<Image>();
			component5.sprite = this.m_SpArray.GetSprite(8);
			component5 = this.m_BattleClearPanel.GetChild(3).GetChild(7).GetChild(0).GetComponent<Image>();
			component5.sprite = this.m_SpArray.GetSprite(9);
		}
		this.m_FlashImage[1] = this.m_ClearPanelVS;
		this.m_ClearPanelTitleTf = this.m_BattleClearPanel.GetChild(4).GetChild(0);
		this.m_ClearPanelTitle = this.m_ClearPanelTitleTf.GetChild(0).GetComponent<UIText>();
		this.m_ClearPanelTitle.font = this.TTF;
		this.m_ClearPanelWinOrLose = this.m_BattleClearPanel.GetChild(4).GetChild(3).GetComponent<Image>();
		this.m_ClearPanelResult = this.m_BattleClearPanel.GetChild(4).GetChild(4).GetComponent<UIText>();
		this.m_ClearPanelResult.font = this.TTF;
		this.m_ClearPanelResultShadow = this.m_BattleClearPanel.GetChild(4).GetChild(4).GetComponent<Shadow>();
		this.m_ClearPanelResultOutline = this.m_BattleClearPanel.GetChild(4).GetChild(4).GetComponent<Outline>();
		this.m_RotationTf = this.m_BattleClearPanel.GetChild(4).GetChild(3).GetComponent<Image>().transform;
		component3 = this.m_BattleClearPanel.GetChild(4).GetChild(1).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 4;
		component3 = this.m_BattleClearPanel.GetChild(4).GetChild(2).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 5;
		this.m_SimulationPanel = base.transform.GetChild(4);
		this.m_SimulationPanel_Left = (RectTransform)base.transform.GetChild(4).GetChild(0);
		this.m_SimulationPanel_Right = (RectTransform)base.transform.GetChild(4).GetChild(1);
		this.m_AttackSlider_Rt = (RectTransform)base.transform.GetChild(1).GetChild(0);
		this.m_DefendSlider_Rt = (RectTransform)base.transform.GetChild(1).GetChild(1);
		this.m_VSImage_Rt = (RectTransform)base.transform.GetChild(1).GetChild(2);
		this.m_SimulationAtkObj.Init();
		this.m_SimulationDefObj.Init();
		this.m_SimulationAtkObj.SelectArmy = base.transform.GetChild(4).GetChild(0).GetChild(2).GetComponent<UIText>();
		this.m_SimulationAtkObj.SelectArmy.font = this.TTF;
		for (int j = 0; j < 6; j++)
		{
			Transform child = base.transform.GetChild(4).GetChild(0).GetChild(3 + j);
			this.m_SimulationAtkObj.Btn[j] = child.GetComponent<UIButton>();
			this.m_SimulationAtkObj.Btn[j].m_Handler = this;
			this.m_SimulationAtkObj.Btn[j].m_BtnID1 = 10 + j;
			this.m_SimulationAtkObj.BtnText[j] = child.GetChild(1).GetComponent<UIText>();
			this.m_SimulationAtkObj.BtnText[j].font = this.TTF;
			this.m_SimulationAtkObj.BtnText[j].text = DataManager.Instance.mStringTable.GetStringByID((uint)(9778 + j));
			this.m_SimulationAtkObj.SelectImage[j] = child.GetChild(2).GetComponent<Image>();
		}
		this.m_SimulationDefObj.SelectArmy = base.transform.GetChild(4).GetChild(1).GetChild(2).GetComponent<UIText>();
		this.m_SimulationDefObj.SelectArmy.font = this.TTF;
		for (int k = 0; k < 3; k++)
		{
			Transform child2 = base.transform.GetChild(4).GetChild(1).GetChild(3 + k);
			this.m_SimulationDefObj.Btn[k] = child2.GetComponent<UIButton>();
			this.m_SimulationDefObj.Btn[k].m_Handler = this;
			this.m_SimulationDefObj.Btn[k].m_BtnID1 = 20 + k;
			this.m_SimulationDefObj.BtnText[k] = child2.GetChild(1).GetComponent<UIText>();
			this.m_SimulationDefObj.BtnText[k].font = this.TTF;
			this.m_SimulationDefObj.BtnText[k].text = DataManager.Instance.mStringTable.GetStringByID((uint)(9791 - k));
			this.m_SimulationDefObj.SelectImage[k] = child2.GetChild(2).GetComponent<Image>();
		}
		component3 = this.m_SimulationPanel.GetChild(2).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 30;
		component3 = this.m_SimulationPanel.GetChild(3).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 35;
		Image component6 = this.m_SimulationPanel.GetChild(3).GetComponent<Image>();
		if (GUIManager.Instance.bOpenOnIPhoneX && component6)
		{
			component6.enabled = false;
		}
		if (door)
		{
			component3.image.sprite = door.LoadSprite("UI_main_close");
			component3.image.material = door.LoadMaterial();
		}
		component3 = this.m_SimulationPanel.GetChild(4).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 36;
		this.m_SimulationExitPanel = base.transform.GetChild(5);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			((RectTransform)this.m_SimulationExitPanel).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)this.m_SimulationExitPanel).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		component3 = this.m_SimulationExitPanel.GetChild(1).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 31;
		component4 = this.m_SimulationExitPanel.GetChild(1).GetChild(0).GetComponent<UIText>();
		component4.font = this.TTF;
		component4.text = DataManager.Instance.mStringTable.GetStringByID(241u);
		component3 = this.m_SimulationExitPanel.GetChild(2).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 32;
		component4 = this.m_SimulationExitPanel.GetChild(2).GetChild(0).GetComponent<UIText>();
		component4.font = this.TTF;
		component4.text = DataManager.Instance.mStringTable.GetStringByID(9786u);
		component3 = this.m_SimulationExitPanel.GetChild(3).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 33;
		if (GUIManager.Instance.IsArabic)
		{
			this.m_SimulationExitPanel.GetChild(3).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		component4 = this.m_SimulationExitPanel.GetChild(3).GetChild(0).GetComponent<UIText>();
		component4.font = this.TTF;
		component4.text = DataManager.Instance.mStringTable.GetStringByID(240u);
		component3 = this.m_SimulationExitPanel.GetChild(4).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 34;
		component4 = this.m_SimulationExitPanel.GetChild(4).GetChild(0).GetComponent<UIText>();
		component4.font = this.TTF;
		component4.text = DataManager.Instance.mStringTable.GetStringByID(9785u);
		this.m_IPhoneXPanel = base.transform.GetChild(6);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			this.m_IPhoneXPanel.gameObject.SetActive(true);
		}
		if (this.IsPlayerAttack)
		{
			this.m_AttackSlider.sprite = this.m_SpArray.GetSprite(0);
			this.m_DefendSlider.sprite = this.m_SpArray.GetSprite(1);
			this.m_AttackName.color = new Color(0.341f, 0.854f, 1f);
			this.m_DefendName.color = new Color(1f, 0.29f, 0.458f);
			this.m_ClearPanelAttackImage.sprite = this.m_SpArray.GetSprite(2);
			this.m_ClearPanelDefendImage.sprite = this.m_SpArray.GetSprite(3);
		}
		else
		{
			this.m_AttackSlider.sprite = this.m_SpArray.GetSprite(1);
			this.m_DefendSlider.sprite = this.m_SpArray.GetSprite(0);
			this.m_DefendName.color = new Color(0.341f, 0.854f, 1f);
			this.m_AttackName.color = new Color(1f, 0.29f, 0.458f);
			this.m_ClearPanelAttackImage.sprite = this.m_SpArray.GetSprite(3);
			this.m_ClearPanelDefendImage.sprite = this.m_SpArray.GetSprite(2);
		}
		if (this.IsSimulation)
		{
			this.SetAutoSelect();
			if (this.m_SimulationType == eLegBattleSimulationType.eReplay)
			{
				this.SetSimulationName();
				this.OpenmBattlePanel();
			}
			else if (this.m_SimulationType == eLegBattleSimulationType.eSimulation || this.m_SimulationType == eLegBattleSimulationType.eFirstSimulation)
			{
				this.OpenSimulationPanel();
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
		GUIManager.Instance.BattleOpenChatBox();
		GUIManager.Instance.CheckBattleAttackState();
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component7;
			Vector3 localScale;
			for (int l = 0; l < 3; l++)
			{
				component7 = this.m_BattlePanel.GetChild(l).GetComponent<RectTransform>();
				localScale = component7.localScale;
				localScale.x *= -1f;
				component7.localScale = localScale;
			}
			component4 = this.m_BattlePanel.GetChild(0).GetChild(7).GetComponent<UIText>();
			component4.alignment = TextAnchor.MiddleLeft;
			component4 = this.m_BattlePanel.GetChild(0).GetChild(9).GetComponent<UIText>();
			component4.alignment = TextAnchor.MiddleRight;
			Quaternion rotation;
			for (int m = 0; m < 3; m++)
			{
				component7 = this.m_BattlePanel.GetChild(0).GetChild(7 + m).GetComponent<RectTransform>();
				rotation = component7.rotation;
				rotation.y = 180f;
				component7.rotation = rotation;
			}
			component7 = this.m_BattleClearPanel.GetChild(3).GetComponent<RectTransform>();
			localScale = component7.localScale;
			localScale.x *= -1f;
			component7.localScale = localScale;
			for (int n = 0; n < 3; n++)
			{
				component7 = this.m_BattleClearPanel.GetChild(3).GetChild(3).GetChild(n).GetComponent<RectTransform>();
				rotation = component7.rotation;
				rotation.y = 180f;
				component7.rotation = rotation;
			}
			component7 = base.transform.GetChild(4).GetComponent<RectTransform>();
			localScale = component7.localScale;
			localScale.x *= -1f;
			component7.localScale = localScale;
			component4 = base.transform.GetChild(4).GetChild(0).GetChild(2).GetComponent<UIText>();
			rotation = component4.rectTransform.rotation;
			rotation.y = 180f;
			component4.rectTransform.rotation = rotation;
			component4.alignment = TextAnchor.MiddleLeft;
			component4 = base.transform.GetChild(4).GetChild(1).GetChild(2).GetComponent<UIText>();
			rotation = component4.rectTransform.rotation;
			rotation.y = 180f;
			component4.rectTransform.rotation = rotation;
			component4.alignment = TextAnchor.MiddleRight;
		}
	}

	// Token: 0x06000990 RID: 2448 RVA: 0x000C5D08 File Offset: 0x000C3F08
	public override void OnClose()
	{
		for (int i = 0; i < this.m_Str.Length; i++)
		{
			if (this.m_Str[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_Str[i]);
			}
			this.m_Str[i] = null;
		}
		this.m_Str = null;
		for (int j = 0; j < this.m_HudStr.Length; j++)
		{
			if (this.m_HudStr[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_HudStr[j]);
			}
			this.m_HudStr[j] = null;
		}
		this.m_HudStr = null;
		if (this.m_SimulationAtkObj.CStr != null)
		{
			StringManager.Instance.DeSpawnString(this.m_SimulationAtkObj.CStr);
			this.m_SimulationAtkObj.CStr = null;
		}
		if (this.m_SimulationDefObj.CStr != null)
		{
			StringManager.Instance.DeSpawnString(this.m_SimulationDefObj.CStr);
			this.m_SimulationDefObj.CStr = null;
		}
		Time.timeScale = 1f;
		GUIManager.Instance.BattleCloseChatBox();
	}

	// Token: 0x06000991 RID: 2449 RVA: 0x000C5E20 File Offset: 0x000C4020
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 0:
			if (this.m_Str[5] == null)
			{
				this.m_Str[5] = StringManager.Instance.SpawnString(30);
			}
			else
			{
				this.m_Str[5].ClearString();
			}
			if (this.m_Str[6] == null)
			{
				this.m_Str[6] = StringManager.Instance.SpawnString(30);
			}
			else
			{
				this.m_Str[6].ClearString();
			}
			if (DataManager.Instance.AllianceTag_War[0].Length != 0)
			{
				StringManager.Instance.StringToFormat(DataManager.Instance.AllianceTag_War[0]);
				StringManager.Instance.StringToFormat(DataManager.Instance.PlayerName_War[0]);
				this.m_Str[5].AppendFormat("[{0}] {1}");
			}
			else
			{
				StringManager.Instance.StringToFormat(DataManager.Instance.PlayerName_War[0]);
				this.m_Str[5].AppendFormat("{0}");
			}
			if (DataManager.Instance.AllianceTag_War[1].Length != 0)
			{
				StringManager.Instance.StringToFormat(DataManager.Instance.AllianceTag_War[1]);
				StringManager.Instance.StringToFormat(DataManager.Instance.PlayerName_War[1]);
				this.m_Str[6].AppendFormat("[{0}] {1}");
			}
			else
			{
				StringManager.Instance.StringToFormat(DataManager.Instance.PlayerName_War[1]);
				this.m_Str[6].AppendFormat("{0}");
			}
			if (!this.IsSimulation)
			{
				this.m_AttackName.text = this.m_Str[5].ToString();
				this.m_DefendName.text = this.m_Str[6].ToString();
			}
			for (int i = 0; i < 2; i++)
			{
				this.SetSlider(i, (long)DataManager.Instance.WarMorale[i], 100L);
			}
			for (int j = 0; j < 2; j++)
			{
				this.SetArmyNum(j, DataManager.Instance.NowValue_War[j]);
			}
			break;
		case 1:
			if (arg2 < 2 && arg2 >= 0)
			{
				this.SetSlider(arg2, (long)DataManager.Instance.WarMorale[arg2], 100L);
				this.SetArmyNum(arg2, DataManager.Instance.NowValue_War[arg2]);
			}
			break;
		case 2:
			this.AddCenterMsg((ushort)arg2, 0);
			break;
		case 3:
			this.SetCountDown();
			break;
		case 4:
			this.OpenClearPanel(arg2);
			if (this.IsSimulation)
			{
				this.OpenSimulationExitPanelWithoutBg(true);
			}
			GUIManager.Instance.HideChatBox();
			if (arg2 == 0 || arg2 == 1)
			{
				AudioManager.Instance.LoadAndPlayBGM(BGMType.LegionVictory, 0, false);
			}
			else
			{
				AudioManager.Instance.LoadAndPlayBGM(BGMType.LegionDefeat, 0, false);
			}
			break;
		}
	}

	// Token: 0x06000992 RID: 2450 RVA: 0x000C60F8 File Offset: 0x000C42F8
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x06000993 RID: 2451 RVA: 0x000C6124 File Offset: 0x000C4324
	public void Refresh_FontTexture()
	{
		UIText component = base.transform.GetChild(1).GetChild(0).GetChild(7).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(0).GetChild(8).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(0).GetChild(9).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(1).GetChild(7).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(1).GetChild(8).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(1).GetChild(9).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(3).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(3).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(6).GetChild(0).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(6).GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(6).GetChild(2).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(6).GetChild(3).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(6).GetChild(4).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(6).GetChild(5).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(1).GetChild(7).GetChild(0).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(3).GetChild(3).GetChild(3).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(3).GetChild(3).GetChild(3).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(3).GetChild(3).GetChild(3).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(3).GetChild(3).GetChild(4).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(3).GetChild(3).GetChild(4).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(3).GetChild(3).GetChild(4).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(3).GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(3).GetChild(4).GetChild(4).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		if (this.m_SimulationAtkObj.SelectArmy != null && this.m_SimulationAtkObj.SelectArmy.enabled)
		{
			this.m_SimulationAtkObj.SelectArmy.enabled = false;
			this.m_SimulationAtkObj.SelectArmy.enabled = true;
		}
		if (this.m_SimulationAtkObj.BtnText != null)
		{
			for (int i = 0; i < this.m_SimulationAtkObj.BtnText.Length; i++)
			{
				if (this.m_SimulationAtkObj.BtnText[i] != null && this.m_SimulationAtkObj.BtnText[i].enabled)
				{
					this.m_SimulationAtkObj.BtnText[i].enabled = false;
					this.m_SimulationAtkObj.BtnText[i].enabled = true;
				}
			}
		}
		if (this.m_SimulationDefObj.SelectArmy != null && this.m_SimulationDefObj.SelectArmy.enabled)
		{
			this.m_SimulationDefObj.SelectArmy.enabled = false;
			this.m_SimulationDefObj.SelectArmy.enabled = true;
		}
		if (this.m_SimulationDefObj.BtnText != null)
		{
			for (int j = 0; j < this.m_SimulationDefObj.BtnText.Length; j++)
			{
				if (this.m_SimulationDefObj.BtnText[j] != null && this.m_SimulationDefObj.BtnText[j].enabled)
				{
					this.m_SimulationDefObj.BtnText[j].enabled = false;
					this.m_SimulationDefObj.BtnText[j].enabled = true;
				}
			}
		}
	}

	// Token: 0x06000994 RID: 2452 RVA: 0x000C69B4 File Offset: 0x000C4BB4
	public void OnButtonClick(UIButton sender)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		WarManager warManager = GameManager.ActiveGameplay as WarManager;
		switch (sender.m_BtnID1)
		{
		case 0:
			Time.timeScale = 0f;
			if (this.IsSimulation)
			{
				this.OpenSimulationExitPanel(true);
			}
			else
			{
				this.m_PausePanel.gameObject.SetActive(true);
			}
			break;
		case 1:
		case 31:
			this.OnExit();
			break;
		case 2:
			Time.timeScale = 1f;
			this.m_PausePanel.gameObject.SetActive(false);
			break;
		case 3:
		case 36:
			if (warManager != null)
			{
				warManager.SetWarCameraModel();
			}
			break;
		case 4:
			if (warManager != null)
			{
				warManager.resetWar(eLegBattleSimulationType.None, false);
			}
			break;
		case 5:
			GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.WarToMap);
			break;
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
			this.SimulationActClick(sender.m_BtnID1, true);
			break;
		case 20:
		case 21:
		case 22:
			this.SimulationDefClick(sender.m_BtnID1, true);
			break;
		case 30:
			if (warManager != null)
			{
				warManager.WCamera.CoordCamMode = false;
				warManager.StartTestCoordWar();
			}
			this.SetSimulationName();
			this.playAnim = true;
			this.m_AnimTick = 0f;
			this.m_SimulationPanel.GetChild(2).gameObject.SetActive(false);
			this.m_SimulationPanel.GetChild(3).gameObject.SetActive(false);
			break;
		case 32:
			Time.timeScale = 1f;
			if (warManager != null)
			{
				warManager.resetWar(eLegBattleSimulationType.eSimulation, true);
			}
			this.OpenSimulationPanel();
			break;
		case 33:
			Time.timeScale = 1f;
			this.OpenSimulationExitPanel(false);
			break;
		case 34:
			Time.timeScale = 1f;
			if (warManager != null)
			{
				warManager.resetWar(eLegBattleSimulationType.eReplay, false);
				warManager.StartTestCoordWar();
			}
			break;
		case 35:
			this.OnExit();
			break;
		}
	}

	// Token: 0x06000995 RID: 2453 RVA: 0x000C6C10 File Offset: 0x000C4E10
	private void Update()
	{
		this.m_TickTime += Time.deltaTime;
		if (this.m_TickTime >= 0.1f)
		{
			this.m_TickTime = 0f;
			for (int i = this.m_HudWorkArray_L.Count - 1; i >= 0; i--)
			{
				if (this.m_HudWorkArray_L[i] != null && this.m_HudWorkArray_L[i].Enable)
				{
					this.m_HudWorkArray_L[i].ColorA -= 0.03f;
					this.m_HudWorkArray_L[i].Msg.color = new Color(this.m_HudWorkArray_L[i].Msg.color.r, this.m_HudWorkArray_L[i].Msg.color.g, this.m_HudWorkArray_L[i].Msg.color.b, this.m_HudWorkArray_L[i].ColorA);
					this.m_HudWorkArray_L[i].Bg.color = new Color(this.m_HudWorkArray_L[i].Bg.color.r, this.m_HudWorkArray_L[i].Bg.color.g, this.m_HudWorkArray_L[i].Bg.color.b, this.m_HudWorkArray_L[i].ColorA);
					if (this.m_HudWorkArray_L[i].ColorA <= 0f)
					{
						this.Remove(i, 0);
					}
				}
			}
			for (int j = this.m_HudWorkArray_R.Count - 1; j >= 0; j--)
			{
				if (this.m_HudWorkArray_R[j] != null && this.m_HudWorkArray_R[j].Enable)
				{
					this.m_HudWorkArray_R[j].ColorA -= 0.03f;
					this.m_HudWorkArray_R[j].Msg.color = new Color(this.m_HudWorkArray_R[j].Msg.color.r, this.m_HudWorkArray_R[j].Msg.color.g, this.m_HudWorkArray_R[j].Msg.color.b, this.m_HudWorkArray_R[j].ColorA);
					this.m_HudWorkArray_R[j].Bg.color = new Color(this.m_HudWorkArray_R[j].Bg.color.r, this.m_HudWorkArray_R[j].Bg.color.g, this.m_HudWorkArray_R[j].Bg.color.b, this.m_HudWorkArray_R[j].ColorA);
					if (this.m_HudWorkArray_R[j].ColorA <= 0f)
					{
						this.Remove(j, 1);
					}
				}
			}
		}
		this.m_TickFlash += Time.deltaTime;
		if (this.m_TickFlash >= 0.03f)
		{
			this.m_TickFlash = 0f;
			for (int k = 0; k < this.m_FlashImage.Length; k++)
			{
				if (this.m_FlashColorA[k] > 1.5f)
				{
					this.m_FlashColorA[k] = 0.5f;
				}
				else
				{
					this.m_FlashColorA[k] += this.m_FlashColorDelta[k];
				}
				if (this.m_FlashColorA[k] >= 1f)
				{
					this.m_FlashImage[k].color = new Color(1f, 1f, 1f, 2f - this.m_FlashColorA[k]);
				}
				else
				{
					this.m_FlashImage[k].color = new Color(1f, 1f, 1f, this.m_FlashColorA[k]);
				}
			}
		}
		if (this.bCountDownCenMsg)
		{
			this.m_CenterTick += Time.deltaTime;
			if (this.m_CenterTick >= 0.1f)
			{
				this.m_CenterTick = 0f;
				this.m_CenterMsgColorA -= 0.03f;
				this.m_CenterMsgText.color = new Color(this.m_CenterMsgText.color.r, this.m_CenterMsgText.color.g, this.m_CenterMsgText.color.b, this.m_CenterMsgColorA);
				this.m_CenterMsgBg.color = new Color(1f, 1f, 1f, this.m_CenterMsgColorA);
				this.m_CenterMsgIcon.color = new Color(1f, 1f, 1f, this.m_CenterMsgColorA);
				if (this.m_CenterMsgColorA <= 0f)
				{
					this.m_CenterMsg.gameObject.SetActive(false);
					this.bCountDownCenMsg = false;
					this.m_CenterMsgColorA = 1f;
				}
			}
		}
		this.m_RotationTf.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		if (this.playAnim)
		{
			this.Anim();
		}
	}

	// Token: 0x06000996 RID: 2454 RVA: 0x000C71B8 File Offset: 0x000C53B8
	private void SetSlider(int sliderType, long value, long max)
	{
		if (sliderType == 0)
		{
			if (this.m_Str[0] == null)
			{
				this.m_Str[0] = StringManager.Instance.SpawnString(15);
			}
			this.m_Str[0].ClearString();
			StringManager.Instance.IntToFormat(value, 1, true);
			this.m_Str[0].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(827u));
			this.m_AttackMoraleValue.text = this.m_Str[0].ToString();
			this.m_AttackMoraleValue.SetAllDirty();
			this.m_AttackMoraleValue.cachedTextGenerator.Invalidate();
			this.m_AttackSlider.fillAmount = (float)value / (float)max;
		}
		else if (sliderType == 1)
		{
			if (this.m_Str[1] == null)
			{
				this.m_Str[1] = StringManager.Instance.SpawnString(15);
			}
			this.m_Str[1].ClearString();
			StringManager.Instance.IntToFormat(value, 1, true);
			this.m_Str[1].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(827u));
			this.m_DefendMoraleValue.text = this.m_Str[1].ToString();
			this.m_DefendMoraleValue.SetAllDirty();
			this.m_DefendMoraleValue.cachedTextGenerator.Invalidate();
			this.m_DefendSlider.fillAmount = (float)value / (float)max;
		}
	}

	// Token: 0x06000997 RID: 2455 RVA: 0x000C7318 File Offset: 0x000C5518
	private void SetArmyNum(int type, long value)
	{
		if (type == 0)
		{
			if (this.m_Str[7] == null)
			{
				this.m_Str[7] = StringManager.Instance.SpawnString(15);
			}
			this.m_Str[7].ClearString();
			StringManager.Instance.IntToFormat(value, 1, true);
			this.m_Str[7].AppendFormat("{0}");
			this.m_AttackValue.text = this.m_Str[7].ToString();
			this.m_AttackValue.SetAllDirty();
			this.m_AttackValue.cachedTextGenerator.Invalidate();
		}
		else if (type == 1)
		{
			if (this.m_Str[8] == null)
			{
				this.m_Str[8] = StringManager.Instance.SpawnString(15);
			}
			this.m_Str[8].ClearString();
			StringManager.Instance.IntToFormat(value, 1, true);
			this.m_Str[8].AppendFormat("{0}");
			this.m_DefendValue.text = this.m_Str[8].ToString();
			this.m_DefendValue.SetAllDirty();
			this.m_DefendValue.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06000998 RID: 2456 RVA: 0x000C743C File Offset: 0x000C563C
	public RectTransform SetHint(bool bShow, bool bLord, ushort heroId = 1, ushort stringid = 1)
	{
		float num = 10f;
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(heroId);
		if (bShow)
		{
			this.m_HintText1.resizeTextForBestFit = false;
			this.m_HintText1.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.HeroTitle);
			this.m_HintText2.text = DataManager.Instance.mStringTable.GetStringByID((uint)stringid);
			if (bLord)
			{
				this.m_HintIcon.sprite = this.m_SpArray.GetSprite(7);
			}
			else
			{
				this.m_HintIcon.sprite = this.m_SpArray.GetSprite(6);
			}
			this.m_HintIcon.SetNativeSize();
			float num2 = this.m_HintText1.preferredWidth + this.m_HintIcon.rectTransform.sizeDelta.x;
			if (num2 < 156f - num * 2f)
			{
				num = (156f - num2) / 2f;
			}
			else
			{
				num = 10f;
			}
			num2 += num * 2f;
			this.m_HintRect.sizeDelta = new Vector2(num2, 86f);
			this.m_HintIcon.rectTransform.anchoredPosition = new Vector2(num, this.m_HintIcon.rectTransform.anchoredPosition.y);
			num += this.m_HintIcon.rectTransform.sizeDelta.x;
			this.m_HintText1.rectTransform.anchoredPosition = this.m_HintText1.ArabicFixPos(new Vector2(num, this.m_HintText1.rectTransform.anchoredPosition.y));
		}
		this.m_Hint.gameObject.SetActive(bShow);
		return this.m_HintRect;
	}

	// Token: 0x06000999 RID: 2457 RVA: 0x000C7608 File Offset: 0x000C5808
	private sHudMsg GetEmptyHud(ref int Idx)
	{
		Idx = 0;
		for (int i = 0; i < this.MaxHudMsg; i++)
		{
			if (!this.m_HudArray[i].Enable)
			{
				Idx = i;
				return this.m_HudArray[i];
			}
		}
		return null;
	}

	// Token: 0x0600099A RID: 2458 RVA: 0x000C7650 File Offset: 0x000C5850
	public void AddCenterMsg(ushort MsgID, byte color = 0)
	{
		this.m_CenterMsgColorA = 1f;
		this.bCountDownCenMsg = false;
		this.m_CenterMsg.gameObject.SetActive(true);
		if (MsgID == 0)
		{
			this.m_CenterMsgText.text = DataManager.Instance.mStringTable.GetStringByID(828u);
			this.m_CenterMsgIcon.sprite = this.m_SpArray.GetSprite(4);
			if (this.IsPlayerAttack)
			{
				this.m_CenterMsgText.color = new Color(0.341f, 0.854f, 1f, this.m_CenterMsgColorA);
			}
			else
			{
				this.m_CenterMsgText.color = new Color(1f, 0.29f, 0.458f, this.m_CenterMsgColorA);
			}
		}
		else if (MsgID == 1)
		{
			UIText centerMsgText = this.m_CenterMsgText;
			string stringByID = DataManager.Instance.mStringTable.GetStringByID(829u);
			this.m_CenterMsgText.text = stringByID;
			centerMsgText.text = stringByID;
			this.m_CenterMsgIcon.sprite = this.m_SpArray.GetSprite(5);
			if (!this.IsPlayerAttack)
			{
				this.m_CenterMsgText.color = new Color(0.341f, 0.854f, 1f, this.m_CenterMsgColorA);
			}
			else
			{
				this.m_CenterMsgText.color = new Color(1f, 0.29f, 0.458f, this.m_CenterMsgColorA);
			}
		}
		else
		{
			this.m_CenterMsgText.text = DataManager.Instance.mStringTable.GetStringByID((uint)MsgID);
			this.m_CenterMsgIcon.sprite = this.m_SpArray.GetSprite(5);
			if (color == 0)
			{
				this.m_CenterMsgText.color = new Color(0.341f, 0.854f, 1f, this.m_CenterMsgColorA);
			}
			else
			{
				this.m_CenterMsgText.color = new Color(1f, 0.29f, 0.458f, this.m_CenterMsgColorA);
			}
		}
		this.m_CenterMsgIcon.SetNativeSize();
		this.m_CenterMsgColorA = 1f;
		this.m_CenterMsgBg.color = new Color(1f, 1f, 1f, this.m_CenterMsgColorA);
		this.m_CenterMsgIcon.color = new Color(1f, 1f, 1f, this.m_CenterMsgColorA);
		this.m_CenterMsgText.SetAllDirty();
		this.m_CenterMsgText.cachedTextGenerator.Invalidate();
		this.m_CenterMsgText.cachedTextGeneratorForLayout.Invalidate();
		this.m_CenterMsg.GetComponent<RectTransform>().sizeDelta = new Vector2(this.m_CenterMsgText.preferredWidth + 125f, 47f);
	}

	// Token: 0x0600099B RID: 2459 RVA: 0x000C7904 File Offset: 0x000C5B04
	public void SetCountDown()
	{
		this.bCountDownCenMsg = true;
	}

	// Token: 0x0600099C RID: 2460 RVA: 0x000C7910 File Offset: 0x000C5B10
	public void AddHudMsg(int hudType = 0, int strType = 0, ushort tableKey = 1)
	{
		int num = 0;
		sHudMsg emptyHud = this.GetEmptyHud(ref num);
		if (emptyHud == null)
		{
			return;
		}
		this.m_HudStr[num].ClearString();
		if (strType == 0)
		{
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(tableKey);
			StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.HeroTitle));
			this.m_HudStr[num].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(502u));
		}
		else if (strType == 1)
		{
			SoldierData recordByKey2 = DataManager.Instance.SoldierDataTable.GetRecordByKey(tableKey);
			StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey2.Name));
			this.m_HudStr[num].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(503u));
		}
		else
		{
			SoldierData recordByKey3 = DataManager.Instance.SoldierDataTable.GetRecordByKey(tableKey);
			StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey3.Name));
			this.m_HudStr[num].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(504u));
		}
		emptyHud.Msg.text = this.m_HudStr[num].ToString();
		emptyHud.Msg.SetAllDirty();
		emptyHud.Msg.cachedTextGeneratorForLayout.Invalidate();
		float num2 = Mathf.Clamp(emptyHud.Msg.preferredWidth, 0f, 350f);
		emptyHud.Bg.GetComponent<RectTransform>().sizeDelta = new Vector2(num2 + 10f, this.m_HudHeight);
		if (hudType == 0)
		{
			for (int i = 0; i < this.m_HudWorkArray_L.Count; i++)
			{
				this.m_HudWorkArray_L[i].Trnas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, this.m_HudHeight);
			}
			emptyHud.Enable = true;
			emptyHud.ColorA = 1f;
			emptyHud.Trnas.gameObject.SetActive(true);
			emptyHud.Trnas.GetComponent<RectTransform>().anchoredPosition = this.mHudBeginPos_L;
			if (this.IsPlayerAttack)
			{
				emptyHud.Msg.color = new Color(0.341f, 0.854f, 1f, emptyHud.ColorA);
			}
			else
			{
				emptyHud.Msg.color = new Color(1f, 0.29f, 0.458f, emptyHud.ColorA);
			}
			emptyHud.Bg.color = new Color(emptyHud.Bg.color.r, emptyHud.Bg.color.g, emptyHud.Bg.color.b, emptyHud.ColorA);
			this.m_HudWorkArray_L.Add(emptyHud);
		}
		else
		{
			for (int j = 0; j < this.m_HudWorkArray_R.Count; j++)
			{
				this.m_HudWorkArray_R[j].Trnas.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, this.m_HudHeight);
			}
			emptyHud.Enable = true;
			emptyHud.ColorA = 1f;
			emptyHud.Trnas.gameObject.SetActive(true);
			emptyHud.Trnas.GetComponent<RectTransform>().anchoredPosition = this.mHudBeginPos_R;
			if (!this.IsPlayerAttack)
			{
				emptyHud.Msg.color = new Color(0.341f, 0.854f, 1f, emptyHud.ColorA);
			}
			else
			{
				emptyHud.Msg.color = new Color(1f, 0.29f, 0.458f, emptyHud.ColorA);
			}
			emptyHud.Bg.color = new Color(emptyHud.Msg.color.r, emptyHud.Msg.color.g, emptyHud.Msg.color.b, emptyHud.ColorA);
			this.m_HudWorkArray_R.Add(emptyHud);
		}
	}

	// Token: 0x0600099D RID: 2461 RVA: 0x000C7D5C File Offset: 0x000C5F5C
	private void Remove(int Idx = 0, int hudType = 0)
	{
		if (hudType == 0)
		{
			if (this.m_HudWorkArray_L.Count > 0)
			{
				this.m_HudWorkArray_L[Idx].Enable = false;
				this.m_HudWorkArray_L[Idx].Trnas.gameObject.SetActive(false);
				this.m_HudWorkArray_L.Remove(this.m_HudWorkArray_L[Idx]);
			}
		}
		else if (this.m_HudWorkArray_R.Count > 0)
		{
			this.m_HudWorkArray_R[Idx].Enable = false;
			this.m_HudWorkArray_R[Idx].Trnas.gameObject.SetActive(false);
			this.m_HudWorkArray_R.Remove(this.m_HudWorkArray_R[Idx]);
		}
	}

	// Token: 0x0600099E RID: 2462 RVA: 0x000C7E24 File Offset: 0x000C6024
	private void OpenClearPanel(int type)
	{
		this.SetClearPanelType(type);
		this.m_PausePanel.gameObject.SetActive(false);
		this.m_BattlePanel.gameObject.SetActive(false);
		this.m_BattleClearPanel.gameObject.SetActive(true);
	}

	// Token: 0x0600099F RID: 2463 RVA: 0x000C7E6C File Offset: 0x000C606C
	private void OpenmBattlePanel()
	{
		this.m_BattlePanel.gameObject.SetActive(true);
		this.m_SimulationPanel.gameObject.SetActive(false);
		this.m_SimulationExitPanel.gameObject.SetActive(false);
	}

	// Token: 0x060009A0 RID: 2464 RVA: 0x000C7EAC File Offset: 0x000C60AC
	private void OpenSimulationPanel()
	{
		this.m_BattlePanel.gameObject.SetActive(false);
		this.m_SimulationPanel.gameObject.SetActive(true);
		this.m_SimulationExitPanel.gameObject.SetActive(false);
	}

	// Token: 0x060009A1 RID: 2465 RVA: 0x000C7EEC File Offset: 0x000C60EC
	private void OpenSimulationExitPanel(bool bOpen)
	{
		this.m_SimulationExitPanel.gameObject.SetActive(bOpen);
		this.m_SimulationExitPanel.GetChild(0).GetComponent<Image>().enabled = true;
		this.m_SimulationExitPanel.GetChild(3).gameObject.SetActive(true);
		this.m_SimulationExitPanel.GetChild(4).gameObject.SetActive(false);
	}

	// Token: 0x060009A2 RID: 2466 RVA: 0x000C7F50 File Offset: 0x000C6150
	private void OpenSimulationExitPanelWithoutBg(bool bOpen = true)
	{
		this.m_SimulationExitPanel.gameObject.SetActive(bOpen);
		this.m_SimulationExitPanel.GetChild(0).GetComponent<Image>().enabled = false;
		this.m_SimulationExitPanel.GetChild(3).gameObject.SetActive(false);
		this.m_SimulationExitPanel.GetChild(4).gameObject.SetActive(true);
		this.m_BattleClearPanel.GetChild(4).GetChild(1).gameObject.SetActive(false);
		this.m_BattleClearPanel.GetChild(4).GetChild(2).gameObject.SetActive(false);
	}

	// Token: 0x060009A3 RID: 2467 RVA: 0x000C7FF0 File Offset: 0x000C61F0
	private void OpenSimulationBattle()
	{
		this.m_BattlePanel.gameObject.SetActive(true);
		this.m_SimulationPanel.gameObject.SetActive(false);
		this.m_SimulationExitPanel.gameObject.SetActive(false);
	}

	// Token: 0x060009A4 RID: 2468 RVA: 0x000C8030 File Offset: 0x000C6230
	private void SetAutoSelect()
	{
		this.SimulationActClick((int)(WarManager.CoordSimuIndex_Left + 10), false);
		this.SimulationDefClick((int)(WarManager.TroopKindSimuIndex_Right + 20), false);
	}

	// Token: 0x060009A5 RID: 2469 RVA: 0x000C8050 File Offset: 0x000C6250
	private void SimulationActClick(int btnID, bool bSetCoordDirty = true)
	{
		int num = 0;
		if (btnID >= 10 && btnID < 16)
		{
			num = btnID - 10;
			if (this.m_SimulationAtkObj.SelectImage[num].IsActive())
			{
				return;
			}
			for (int i = 0; i < this.m_SimulationAtkObj.SelectImage.Length; i++)
			{
				this.m_SimulationAtkObj.SelectImage[i].gameObject.SetActive(false);
			}
			this.m_SimulationAtkObj.SelectImage[num].gameObject.SetActive(true);
			this.m_SimulationAtkObj.CStr.ClearString();
			this.m_SimulationAtkObj.CStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)(9778 + num)));
			this.m_SimulationAtkObj.CStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(5317u));
			this.m_SimulationAtkObj.CStr.AppendFormat("{0} {1}");
			this.m_SimulationAtkObj.SelectArmy.text = this.m_SimulationAtkObj.CStr.ToString();
			this.m_SimulationAtkObj.SelectArmy.SetAllDirty();
			this.m_SimulationAtkObj.SelectArmy.cachedTextGenerator.Invalidate();
		}
		if (bSetCoordDirty)
		{
			WarManager warManager = GameManager.ActiveGameplay as WarManager;
			if (warManager != null)
			{
				WarManager.CoordSimuIndex_Left = (ushort)num;
				warManager.SetCoordDirty();
			}
		}
	}

	// Token: 0x060009A6 RID: 2470 RVA: 0x000C81B4 File Offset: 0x000C63B4
	private void SimulationDefClick(int btnID, bool bSetCoordDirty = true)
	{
		int num = 0;
		if (btnID >= 20 && btnID < 23)
		{
			num = btnID - 20;
			if (this.m_SimulationDefObj.SelectImage[num].IsActive())
			{
				return;
			}
			for (int i = 0; i < this.m_SimulationDefObj.SelectImage.Length; i++)
			{
				this.m_SimulationDefObj.SelectImage[i].gameObject.SetActive(false);
			}
			this.m_SimulationDefObj.SelectImage[num].gameObject.SetActive(true);
			this.m_SimulationDefObj.CStr.ClearString();
			this.m_SimulationDefObj.CStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)(9791 - num)));
			this.m_SimulationDefObj.CStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9792u));
			this.m_SimulationDefObj.CStr.AppendFormat("{0} {1}");
			this.m_SimulationDefObj.SelectArmy.text = this.m_SimulationDefObj.CStr.ToString();
			this.m_SimulationDefObj.SelectArmy.SetAllDirty();
			this.m_SimulationDefObj.SelectArmy.cachedTextGenerator.Invalidate();
		}
		if (bSetCoordDirty)
		{
			WarManager warManager = GameManager.ActiveGameplay as WarManager;
			if (warManager != null)
			{
				WarManager.TroopKindSimuIndex_Right = (ushort)num;
				warManager.SetCoordDirty();
			}
		}
	}

	// Token: 0x060009A7 RID: 2471 RVA: 0x000C8318 File Offset: 0x000C6518
	private void SetSimulationName()
	{
		this.m_AttackName.text = this.m_SimulationAtkObj.CStr.ToString();
		this.m_AttackName.SetAllDirty();
		this.m_AttackName.cachedTextGenerator.Invalidate();
		this.m_DefendName.text = this.m_SimulationDefObj.CStr.ToString();
		this.m_DefendName.SetAllDirty();
		this.m_DefendName.cachedTextGenerator.Invalidate();
		this.m_ClearPanelAttackName.text = this.m_SimulationAtkObj.CStr.ToString();
		this.m_ClearPanelAttackName.SetAllDirty();
		this.m_ClearPanelAttackName.cachedTextGenerator.Invalidate();
		this.m_ClearPanelDefendName.text = this.m_SimulationDefObj.CStr.ToString();
		this.m_ClearPanelDefendName.SetAllDirty();
		this.m_ClearPanelDefendName.cachedTextGenerator.Invalidate();
	}

	// Token: 0x060009A8 RID: 2472 RVA: 0x000C8400 File Offset: 0x000C6600
	private void SetClearPanelType(int type)
	{
		DataManager instance = DataManager.Instance;
		if (this.m_Str[0] == null)
		{
			this.m_Str[0] = StringManager.Instance.SpawnString(40);
		}
		this.m_Str[0].ClearString();
		if (this.m_Str[1] == null)
		{
			this.m_Str[1] = StringManager.Instance.SpawnString(40);
		}
		this.m_Str[1].ClearString();
		if (!this.IsSimulation)
		{
			if (instance.KindomID_War[0] != instance.KindomID_War[1])
			{
				StringManager.Instance.IntToFormat((long)instance.KindomID_War[0], 1, false);
				if (instance.AllianceTag_War[0].Length != 0)
				{
					StringManager.Instance.StringToFormat(instance.AllianceTag_War[0]);
					StringManager.Instance.StringToFormat(instance.PlayerName_War[0]);
					this.m_Str[0].AppendFormat("#{0}\n[{1}] {2}");
				}
				else
				{
					StringManager.Instance.StringToFormat(instance.PlayerName_War[0]);
					this.m_Str[0].AppendFormat("#{0}\n{1}");
				}
				this.m_ClearPanelAttackName.text = this.m_Str[0].ToString();
				this.m_ClearPanelAttackName.SetAllDirty();
				this.m_ClearPanelAttackName.cachedTextGenerator.Invalidate();
				StringManager.Instance.IntToFormat((long)instance.KindomID_War[1], 1, false);
				if (instance.AllianceTag_War[1].Length != 0)
				{
					StringManager.Instance.StringToFormat(instance.AllianceTag_War[1]);
					StringManager.Instance.StringToFormat(instance.PlayerName_War[1]);
					this.m_Str[1].AppendFormat("#{0}\n[{1}] {2}");
				}
				else
				{
					StringManager.Instance.StringToFormat(instance.PlayerName_War[1]);
					this.m_Str[1].AppendFormat("#{0}\n{1}");
				}
				this.m_ClearPanelDefendName.text = this.m_Str[1].ToString();
				this.m_ClearPanelDefendName.SetAllDirty();
				this.m_ClearPanelDefendName.cachedTextGenerator.Invalidate();
			}
			else
			{
				if (instance.AllianceTag_War[0].Length != 0)
				{
					StringManager.Instance.StringToFormat(instance.AllianceTag_War[0]);
					StringManager.Instance.StringToFormat(instance.PlayerName_War[0]);
					this.m_Str[0].AppendFormat("[{0}] {1}");
				}
				else
				{
					StringManager.Instance.StringToFormat(instance.PlayerName_War[0]);
					this.m_Str[0].AppendFormat("{0}");
				}
				this.m_ClearPanelAttackName.text = this.m_Str[0].ToString();
				this.m_ClearPanelAttackName.SetAllDirty();
				this.m_ClearPanelAttackName.cachedTextGenerator.Invalidate();
				if (instance.AllianceTag_War[1].Length != 0)
				{
					StringManager.Instance.StringToFormat(instance.AllianceTag_War[1]);
					StringManager.Instance.StringToFormat(instance.PlayerName_War[1]);
					this.m_Str[1].AppendFormat("[{0}] {1}");
				}
				else
				{
					StringManager.Instance.StringToFormat(instance.PlayerName_War[1]);
					this.m_Str[1].AppendFormat("{0}");
				}
				this.m_ClearPanelDefendName.text = this.m_Str[1].ToString();
				this.m_ClearPanelDefendName.SetAllDirty();
				this.m_ClearPanelDefendName.cachedTextGenerator.Invalidate();
			}
		}
		if (this.m_Str[2] == null)
		{
			this.m_Str[2] = StringManager.Instance.SpawnString(15);
		}
		long num = (long)Mathf.Clamp((float)(instance.MaxValue_War[0] - instance.NowValue_War[0]), 0f, (float)instance.MaxValue_War[0]);
		this.m_Str[2].ClearString();
		StringManager.Instance.IntToFormat(num, 1, false);
		this.m_Str[2].AppendFormat("{0}");
		this.m_ClearPanelAttackValue.text = this.m_Str[2].ToString();
		this.m_ClearPanelAttackValue.SetAllDirty();
		this.m_ClearPanelAttackValue.cachedTextGenerator.Invalidate();
		if (this.m_Str[4] == null)
		{
			this.m_Str[4] = StringManager.Instance.SpawnString(15);
		}
		num = (long)Mathf.Clamp((float)(instance.MaxValue_War[1] - instance.NowValue_War[1]), 0f, (float)instance.MaxValue_War[1]);
		num = Math.Max(num - instance.CastleTrapsDestroyedCount, 0L);
		this.m_Str[4].ClearString();
		StringManager.Instance.IntToFormat(num, 1, false);
		this.m_Str[4].AppendFormat("{0}");
		this.m_ClearPanelDefendValue.text = this.m_Str[4].ToString();
		this.m_ClearPanelDefendValue.SetAllDirty();
		this.m_ClearPanelDefendValue.cachedTextGenerator.Invalidate();
		if (type == 0)
		{
			this.m_ClearPanelWinOrLose.color = new Color(1f, 0.9f, 0.564f);
			this.m_ClearPanelResult.text = instance.mStringTable.GetStringByID(574u);
			this.m_ClearPanelResult.color = new Color(1f, 0.925f, 0.529f);
			this.m_ClearPanelResultShadow.effectColor = new Color(0.282f, 0f, 0f);
			this.m_ClearPanelResultOutline.effectColor = new Color(0.843f, 0f, 0f);
			this.m_ClearPanelTitleTf.gameObject.SetActive(false);
		}
		else if (type == 1)
		{
			this.m_ClearPanelWinOrLose.color = new Color(1f, 0.9f, 0.564f);
			this.m_ClearPanelResult.color = new Color(1f, 0.925f, 0.529f);
			this.m_ClearPanelResultShadow.effectColor = new Color(0.282f, 0f, 0f);
			this.m_ClearPanelResultOutline.effectColor = new Color(0.843f, 0f, 0f);
			this.m_ClearPanelResult.text = instance.mStringTable.GetStringByID(575u);
			this.m_ClearPanelTitle.text = instance.mStringTable.GetStringByID(578u);
			this.m_ClearPanelTitleTf.gameObject.SetActive(true);
		}
		else if (type == 2)
		{
			this.m_ClearPanelWinOrLose.color = new Color(0.639f, 0f, 0.14f);
			this.m_ClearPanelResult.color = new Color(0.694f, 0.901f, 1f);
			this.m_ClearPanelResultShadow.effectColor = new Color(0f, 0.047f, 0.282f);
			this.m_ClearPanelResultOutline.effectColor = new Color(0.247f, 0.607f, 0.729f);
			this.m_ClearPanelResult.text = instance.mStringTable.GetStringByID(576u);
			this.m_ClearPanelTitleTf.gameObject.SetActive(false);
		}
		else if (type == 3)
		{
			this.m_ClearPanelWinOrLose.color = new Color(0.639f, 0f, 0.14f);
			this.m_ClearPanelResult.color = new Color(0.694f, 0.901f, 1f);
			this.m_ClearPanelResultShadow.effectColor = new Color(0f, 0.047f, 0.282f);
			this.m_ClearPanelResultOutline.effectColor = new Color(0.247f, 0.607f, 0.729f);
			this.m_ClearPanelResult.text = instance.mStringTable.GetStringByID(577u);
			this.m_ClearPanelTitle.text = instance.mStringTable.GetStringByID(579u);
			this.m_ClearPanelTitleTf.gameObject.SetActive(true);
		}
	}

	// Token: 0x060009A9 RID: 2473 RVA: 0x000C8BC0 File Offset: 0x000C6DC0
	private void OnExit()
	{
		WarManager warManager = GameManager.ActiveGameplay as WarManager;
		Time.timeScale = 1f;
		if (warManager != null)
		{
			warManager.m_WarState = WarManager.WarState.STOP;
		}
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.WarToMap);
	}

	// Token: 0x060009AA RID: 2474 RVA: 0x000C8C04 File Offset: 0x000C6E04
	public override bool OnBackButtonClick()
	{
		if (this.playAnim)
		{
			return true;
		}
		Time.timeScale = 0f;
		if (!this.IsSimulation)
		{
			this.m_PausePanel.gameObject.SetActive(!this.m_PausePanel.gameObject.activeSelf);
			Time.timeScale = (float)((!this.m_PausePanel.gameObject.activeSelf) ? 1 : 0);
		}
		else if (this.m_BattlePanel.gameObject.activeSelf)
		{
			this.OpenSimulationExitPanel(!this.m_SimulationExitPanel.gameObject.activeSelf);
			Time.timeScale = (float)((!this.m_SimulationExitPanel.gameObject.activeSelf) ? 1 : 0);
		}
		else if (this.m_SimulationPanel.gameObject.activeSelf)
		{
			this.OnExit();
		}
		else if (this.m_BattleClearPanel.gameObject.activeSelf)
		{
			this.OpenSimulationExitPanelWithoutBg(!this.m_SimulationExitPanel.gameObject.activeSelf);
			Time.timeScale = (float)((!this.m_SimulationExitPanel.gameObject.activeSelf) ? 1 : 0);
		}
		else
		{
			Time.timeScale = 1f;
		}
		return true;
	}

	// Token: 0x060009AB RID: 2475 RVA: 0x000C8D54 File Offset: 0x000C6F54
	public void OnBattlePause()
	{
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Settlement))
		{
			return;
		}
		if (!NewbieManager.IsWorking())
		{
			Time.timeScale = 0f;
			if (!this.IsSimulation)
			{
				this.m_PausePanel.gameObject.SetActive(true);
			}
			else if (this.m_BattlePanel.gameObject.activeSelf)
			{
				this.OpenSimulationExitPanel(true);
			}
			else if (this.m_BattleClearPanel.gameObject.activeSelf)
			{
				Time.timeScale = 1f;
				this.OpenSimulationExitPanelWithoutBg(true);
			}
			else
			{
				Time.timeScale = 1f;
			}
		}
	}

	// Token: 0x060009AC RID: 2476 RVA: 0x000C8E04 File Offset: 0x000C7004
	private void Anim()
	{
		this.m_AnimTick += Time.unscaledDeltaTime;
		float num = 0.5f;
		float num2 = 0.3f;
		float num3 = 0.2f;
		if (this.m_AnimTick <= num)
		{
			if (this.m_AnimTick >= num3)
			{
				this.m_AttackSlider_Rt.offsetMin = new Vector2(0f, Mathf.Lerp(-190f, 0f, (this.m_AnimTick - num3) / (num - num3)));
				this.m_DefendSlider_Rt.offsetMin = new Vector2(0f, Mathf.Lerp(-190f, 0f, (this.m_AnimTick - num3) / (num - num3)));
				this.m_VSImage_Rt.offsetMin = new Vector2(0f, Mathf.Lerp(-190f, 0f, (this.m_AnimTick - num3) / (num - num3)));
				this.m_BattlePanel.gameObject.SetActive(true);
				Debug.Log("step2 " + this.m_AnimTick);
			}
			if (this.m_AnimTick <= num2)
			{
				this.m_SimulationPanel_Left.anchoredPosition = new Vector2(Mathf.Lerp(0f, -390f, this.m_AnimTick / num2), 0f);
				this.m_SimulationPanel_Right.anchoredPosition = new Vector2(Mathf.Lerp(0f, 390f, this.m_AnimTick / num2), 0f);
				Debug.Log("step1 " + this.m_AnimTick);
			}
		}
		else
		{
			Debug.Log("OpenSimulationBattle " + this.m_AnimTick);
			this.m_AttackSlider_Rt.offsetMin = new Vector2(0f, 0f);
			this.m_DefendSlider_Rt.offsetMin = new Vector2(0f, 0f);
			this.m_VSImage_Rt.offsetMin = new Vector2(0f, 0f);
			this.OpenSimulationBattle();
			this.playAnim = false;
		}
	}

	// Token: 0x060009AD RID: 2477 RVA: 0x000C9000 File Offset: 0x000C7200
	public void SetAlertImageAlpha(float Alpha)
	{
		if (GUIManager.Instance.m_AlertImageIndex == 0 && this.alertBlock != null && this.alertBlock.gameObject.activeSelf)
		{
			Color color = new Color(1f, 1f, 1f, Alpha);
			if (this.alertBlock_T != null)
			{
				this.alertBlock_T.color = color;
			}
			if (this.alertBlock_B != null)
			{
				this.alertBlock_B.color = color;
			}
			if (this.alertBlock_L != null)
			{
				this.alertBlock_L.color = color;
			}
			if (this.alertBlock_R != null)
			{
				this.alertBlock_R.color = color;
			}
		}
	}

	// Token: 0x060009AE RID: 2478 RVA: 0x000C90D0 File Offset: 0x000C72D0
	public void SetAlertBlock(bool bOpenAlertBlock)
	{
		this.alertBlock.gameObject.SetActive(bOpenAlertBlock);
	}

	// Token: 0x0400200E RID: 8206
	private int MaxHudMsg;

	// Token: 0x0400200F RID: 8207
	private Font TTF;

	// Token: 0x04002010 RID: 8208
	private UISpritesArray m_SpArray;

	// Token: 0x04002011 RID: 8209
	private Transform alertBlock;

	// Token: 0x04002012 RID: 8210
	private Image alertBlock_T;

	// Token: 0x04002013 RID: 8211
	private Image alertBlock_B;

	// Token: 0x04002014 RID: 8212
	private Image alertBlock_L;

	// Token: 0x04002015 RID: 8213
	private Image alertBlock_R;

	// Token: 0x04002016 RID: 8214
	private UIText m_AttackName;

	// Token: 0x04002017 RID: 8215
	private UIText m_AttackValue;

	// Token: 0x04002018 RID: 8216
	private UIText m_DefendName;

	// Token: 0x04002019 RID: 8217
	private UIText m_DefendValue;

	// Token: 0x0400201A RID: 8218
	private UIText m_AttackMoraleValue;

	// Token: 0x0400201B RID: 8219
	private UIText m_DefendMoraleValue;

	// Token: 0x0400201C RID: 8220
	private UIText m_ClearPanelAttackName;

	// Token: 0x0400201D RID: 8221
	private UIText m_ClearPanelDefendName;

	// Token: 0x0400201E RID: 8222
	private UIText m_ClearPanelAttackValue;

	// Token: 0x0400201F RID: 8223
	private UIText m_ClearPanelDefendValue;

	// Token: 0x04002020 RID: 8224
	private UIText m_ClearPanelTitle;

	// Token: 0x04002021 RID: 8225
	private UIText m_ClearPanelResult;

	// Token: 0x04002022 RID: 8226
	private Shadow m_ClearPanelResultShadow;

	// Token: 0x04002023 RID: 8227
	private Outline m_ClearPanelResultOutline;

	// Token: 0x04002024 RID: 8228
	private Image m_AttackSlider;

	// Token: 0x04002025 RID: 8229
	private Image m_DefendSlider;

	// Token: 0x04002026 RID: 8230
	private Image m_WallSlider;

	// Token: 0x04002027 RID: 8231
	private Image m_ClearPanelAttackImage;

	// Token: 0x04002028 RID: 8232
	private Image m_ClearPanelDefendImage;

	// Token: 0x04002029 RID: 8233
	private Image m_ClearPanelWinOrLose;

	// Token: 0x0400202A RID: 8234
	private Image m_ClearPanelVS;

	// Token: 0x0400202B RID: 8235
	private Image[] m_FlashImage = new Image[2];

	// Token: 0x0400202C RID: 8236
	private Transform m_RotationTf;

	// Token: 0x0400202D RID: 8237
	private Transform m_PausePanel;

	// Token: 0x0400202E RID: 8238
	private Transform m_BattleClearPanel;

	// Token: 0x0400202F RID: 8239
	private Transform m_BattlePanel;

	// Token: 0x04002030 RID: 8240
	private Transform m_BattlePanel_Top;

	// Token: 0x04002031 RID: 8241
	private Transform m_BattlePanel_Down;

	// Token: 0x04002032 RID: 8242
	private Transform m_SimulationPanel;

	// Token: 0x04002033 RID: 8243
	private Transform m_SimulationExitPanel;

	// Token: 0x04002034 RID: 8244
	private Transform m_IPhoneXPanel;

	// Token: 0x04002035 RID: 8245
	private RectTransform m_SimulationPanel_Left;

	// Token: 0x04002036 RID: 8246
	private RectTransform m_SimulationPanel_Right;

	// Token: 0x04002037 RID: 8247
	private RectTransform m_AttackSlider_Rt;

	// Token: 0x04002038 RID: 8248
	private RectTransform m_DefendSlider_Rt;

	// Token: 0x04002039 RID: 8249
	private RectTransform m_VSImage_Rt;

	// Token: 0x0400203A RID: 8250
	private Transform m_ClearPanelTitleTf;

	// Token: 0x0400203B RID: 8251
	private Transform m_Hint;

	// Token: 0x0400203C RID: 8252
	private Image m_HintIcon;

	// Token: 0x0400203D RID: 8253
	private UIText m_HintText1;

	// Token: 0x0400203E RID: 8254
	private UIText m_HintText2;

	// Token: 0x0400203F RID: 8255
	private RectTransform m_HintRect;

	// Token: 0x04002040 RID: 8256
	private UIText m_CenterMsgText;

	// Token: 0x04002041 RID: 8257
	private Transform m_CenterMsg;

	// Token: 0x04002042 RID: 8258
	private Image m_CenterMsgBg;

	// Token: 0x04002043 RID: 8259
	private Image m_CenterMsgIcon;

	// Token: 0x04002044 RID: 8260
	private sHudMsg[] m_HudArray;

	// Token: 0x04002045 RID: 8261
	private List<sHudMsg> m_HudWorkArray_L;

	// Token: 0x04002046 RID: 8262
	private List<sHudMsg> m_HudWorkArray_R;

	// Token: 0x04002047 RID: 8263
	private SimulationAtkObj m_SimulationAtkObj = default(SimulationAtkObj);

	// Token: 0x04002048 RID: 8264
	private SimulationDefObj m_SimulationDefObj = default(SimulationDefObj);

	// Token: 0x04002049 RID: 8265
	private float m_HudHeight = 32f;

	// Token: 0x0400204A RID: 8266
	private Vector2 mHudBeginPos_L;

	// Token: 0x0400204B RID: 8267
	private Vector2 mHudBeginPos_R;

	// Token: 0x0400204C RID: 8268
	private float m_TickTime = 0.1f;

	// Token: 0x0400204D RID: 8269
	private float m_TickTime_Info = 1f;

	// Token: 0x0400204E RID: 8270
	private float m_TickFlash = 0.03f;

	// Token: 0x0400204F RID: 8271
	private float[] m_FlashColorA = new float[]
	{
		0.5f,
		0.5f,
		0.5f
	};

	// Token: 0x04002050 RID: 8272
	private float[] m_FlashColorDelta = new float[]
	{
		0.03f,
		0.01f,
		0.03f
	};

	// Token: 0x04002051 RID: 8273
	private float m_CenterTick = 0.1f;

	// Token: 0x04002052 RID: 8274
	private float m_CenterMsgColorA = 1f;

	// Token: 0x04002053 RID: 8275
	private bool bCountDownCenMsg;

	// Token: 0x04002054 RID: 8276
	private float m_AnimTick = 1f;

	// Token: 0x04002055 RID: 8277
	private CString[] m_Str;

	// Token: 0x04002056 RID: 8278
	private CString[] m_HudStr;

	// Token: 0x04002057 RID: 8279
	private bool IsPlayerAttack;

	// Token: 0x04002058 RID: 8280
	private bool IsSimulation;

	// Token: 0x04002059 RID: 8281
	private eLegBattleSimulationType m_SimulationType;

	// Token: 0x0400205A RID: 8282
	private bool playAnim;
}
