using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200021A RID: 538
public class UI_leadup : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x060009D3 RID: 2515 RVA: 0x000CE57C File Offset: 0x000CC77C
	public override void OnOpen(int arg1, int arg2)
	{
		this.GM.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		Font ttffont = this.GM.GetTTFFont();
		CString cstring = StringManager.Instance.StaticString1024();
		for (int i = 0; i < 6; i++)
		{
			this.tmpString[i] = StringManager.Instance.SpawnString(30);
		}
		this.m_PanelT = base.transform;
		this.m_PanelT.GetChild(16).GetComponent<UIButton>().m_Handler = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			((RectTransform)this.m_PanelT).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0f);
			((RectTransform)this.m_PanelT).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0f);
		}
		this.RBText[0] = this.m_PanelT.GetChild(14).GetComponent<UIText>();
		this.RBText[0].text = this.DM.RoleAttr.Level.ToString();
		this.RBText[0].font = ttffont;
		this.RBText[1] = this.m_PanelT.GetChild(15).GetComponent<UIText>();
		this.RBText[1].text = this.DM.mStringTable.GetStringByID(5797u);
		this.RBText[1].font = ttffont;
		this.RBText[2] = this.m_PanelT.GetChild(17).GetComponent<UIText>();
		this.RBText[2].text = this.DM.mStringTable.GetStringByID(1556u);
		this.RBText[2].font = ttffont;
		this.RBText[3] = this.m_PanelT.GetChild(23).GetComponent<UIText>();
		cstring.Length = 0;
		cstring.IntToFormat((long)arg1, 1, false);
		cstring.AppendFormat(this.whiteString2);
		this.tmpString[0].Length = 0;
		this.tmpString[0].Append(this.whiteString1);
		this.tmpString[0].StringToFormat(cstring);
		this.tmpString[0].IntToFormat((long)this.DM.RoleAttr.Level, 1, false);
		this.tmpString[0].AppendFormat(this.DM.mStringTable.GetStringByID(1557u));
		this.RBText[3].text = this.tmpString[0].ToString();
		this.RBText[3].font = ttffont;
		LevelUp recordByKey = this.DM.LevelUpTable.GetRecordByKey((ushort)this.DM.RoleAttr.Level);
		this.RBText[4] = this.m_PanelT.GetChild(18).GetComponent<UIText>();
		this.RBText[4].text = this.DM.mStringTable.GetStringByID(1558u);
		this.RBText[4].font = ttffont;
		this.RBText[5] = this.m_PanelT.GetChild(24).GetComponent<UIText>();
		this.tmpString[1].Length = 0;
		this.tmpString[1].IntToFormat((long)recordByKey.AddCoin, 1, false);
		this.tmpString[1].AppendFormat(this.DM.mStringTable.GetStringByID(1559u));
		this.RBText[5].text = this.tmpString[1].ToString();
		this.RBText[5].font = ttffont;
		uint num = 0u;
		if (this.DM.RoleAttr.Level > 0)
		{
			num = this.DM.LevelUpTable.GetRecordByKey((ushort)(this.DM.RoleAttr.Level - 1)).AddForce;
		}
		this.RBText[6] = this.m_PanelT.GetChild(19).GetComponent<UIText>();
		this.RBText[6].text = this.DM.mStringTable.GetStringByID(1560u);
		this.RBText[6].font = ttffont;
		this.RBText[7] = this.m_PanelT.GetChild(25).GetComponent<UIText>();
		this.tmpString[2].Length = 0;
		this.tmpString[2].IntToFormat((long)((ulong)(recordByKey.AddForce - num)), 1, true);
		this.tmpString[2].AppendFormat(this.DM.mStringTable.GetStringByID(1561u));
		this.RBText[7].text = this.tmpString[2].ToString();
		this.RBText[7].font = ttffont;
		this.RBText[8] = this.m_PanelT.GetChild(20).GetComponent<UIText>();
		this.RBText[8].text = this.DM.mStringTable.GetStringByID(1562u);
		this.RBText[8].font = ttffont;
		this.RBText[9] = this.m_PanelT.GetChild(26).GetComponent<UIText>();
		this.RBText[9].font = ttffont;
		if (this.DM.RoleAttr.Level <= 15)
		{
			this.tmpString[3].Length = 0;
			this.tmpString[3].Append(this.whiteString1);
			this.tmpString[3].Append(this.DM.mStringTable.GetStringByID(1568u));
			this.tmpString[3].Append(this.whiteString3);
		}
		else
		{
			cstring.Length = 0;
			cstring.IntToFormat((long)arg1, 1, false);
			cstring.AppendFormat(this.whiteString2);
			this.tmpString[3].Length = 0;
			this.tmpString[3].Append(this.whiteString1);
			this.tmpString[3].StringToFormat(cstring);
			this.tmpString[3].IntToFormat((long)this.DM.RoleAttr.Level, 1, false);
			this.tmpString[3].AppendFormat(this.DM.mStringTable.GetStringByID(1563u));
		}
		this.RBText[9].text = this.tmpString[3].ToString();
		this.LightT2 = this.m_PanelT.GetChild(3);
		if (this.DM.UserLanguage == GameLanguage.GL_Chs)
		{
			this.m_PanelT.GetChild(8).GetComponent<UISpritesArray>().SetSpriteIndex(0);
		}
		if (this.GM.IsArabic)
		{
			((RectTransform)this.m_PanelT.GetChild(8)).localScale = new Vector3(-1f, 1f, 1f);
		}
		AudioManager.Instance.PlayUISFX(UIKind.DominanceLevelup);
		this.DM.leadup_CDTime = 0.3f;
		this.GM.LoadLvUpLight(this.m_PanelT);
	}

	// Token: 0x060009D4 RID: 2516 RVA: 0x000CEC4C File Offset: 0x000CCE4C
	public override void OnClose()
	{
		for (int i = 0; i < 6; i++)
		{
			if (this.tmpString[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.tmpString[i]);
				this.tmpString[i] = null;
			}
		}
		this.GM.ReleaseLvUpLight();
	}

	// Token: 0x060009D5 RID: 2517 RVA: 0x000CECA0 File Offset: 0x000CCEA0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			for (int i = 0; i < this.RBText.Length; i++)
			{
				if (this.RBText[i] != null && this.RBText[i].enabled)
				{
					this.RBText[i].enabled = false;
					this.RBText[i].enabled = true;
				}
			}
		}
	}

	// Token: 0x060009D6 RID: 2518 RVA: 0x000CED20 File Offset: 0x000CCF20
	private void Update()
	{
		this.LightT2.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
	}

	// Token: 0x060009D7 RID: 2519 RVA: 0x000CED54 File Offset: 0x000CCF54
	public void OnButtonClick(UIButton sender)
	{
		this.GM.CloseMenu(EGUIWindow.UI_leadup);
		this.GM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
	}

	// Token: 0x04002115 RID: 8469
	private Transform m_PanelT;

	// Token: 0x04002116 RID: 8470
	private GUIManager GM = GUIManager.Instance;

	// Token: 0x04002117 RID: 8471
	private DataManager DM = DataManager.Instance;

	// Token: 0x04002118 RID: 8472
	private CString[] tmpString = new CString[6];

	// Token: 0x04002119 RID: 8473
	private Transform LightT2;

	// Token: 0x0400211A RID: 8474
	private string whiteString1 = "<color=#FFFFFFFF>";

	// Token: 0x0400211B RID: 8475
	private string whiteString2 = "{0}</color>";

	// Token: 0x0400211C RID: 8476
	private string whiteString3 = "</color>";

	// Token: 0x0400211D RID: 8477
	private UIText[] RBText = new UIText[10];
}
