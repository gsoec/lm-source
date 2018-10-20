using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000643 RID: 1603
public class UIPetSkill_FS : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x06001EE6 RID: 7910 RVA: 0x003B11F0 File Offset: 0x003AF3F0
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.PM = PetManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.mMaT = this.door.LoadMaterial();
		this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
		this.FrameMaterial = this.GUIM.GetFrameMaterial();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		if (this.GUIM.BattleSerialNo > 0u)
		{
			this.door.CloseMenu(false);
			return;
		}
		this.Favor.Serial = this.DM.OpenMail.Serial;
		this.Favor.Type = this.DM.OpenMail.Type;
		this.Favor.Kind = this.DM.OpenMail.Kind;
		if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
		{
			this.Report = this.Favor.Combat;
			if (!this.Report.BeRead)
			{
				if (this.Favor.Kind == MailType.EMAIL_BATTLE)
				{
					this.DM.BattleReportRead(this.Report.SerialID, false);
				}
				else
				{
					this.DM.FavorReportRead(this.Report.SerialID, false);
				}
			}
			this.IsAttack = (this.Report.Pet.Side == 0);
			this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
			CString cstring = StringManager.Instance.StaticString1024();
			this.Cstr_TitleName = StringManager.Instance.SpawnString(30);
			this.Cstr_Page = StringManager.Instance.SpawnString(30);
			this.Cstr_Text = StringManager.Instance.SpawnString(30);
			for (int i = 0; i < 2; i++)
			{
				this.Cstr_Coordinate[i] = StringManager.Instance.SpawnString(100);
				this.Cstr_Offensive[i] = StringManager.Instance.SpawnString(30);
				this.Cstr_Dominance[i] = StringManager.Instance.SpawnString(30);
				this.Cstr_Country[i] = StringManager.Instance.SpawnString(30);
				this.Cstr_CoordinateMainHero[i] = StringManager.Instance.SpawnString(30);
				this.Cstr_Name[i] = StringManager.Instance.SpawnString(30);
			}
			this.Cstr_PetSkillLv = StringManager.Instance.SpawnString(30);
			this.Cstr_PetSkillInfo = StringManager.Instance.SpawnString(1024);
			this.Cstr_PetWall = StringManager.Instance.SpawnString(30);
			for (int j = 0; j < 3; j++)
			{
				if (j == 0)
				{
					this.Cstr_PetAttack[j] = StringManager.Instance.SpawnString(100);
				}
				else
				{
					this.Cstr_PetAttack[j] = StringManager.Instance.SpawnString(30);
				}
			}
			for (int k = 0; k < 17; k++)
			{
				if (k == 0)
				{
					this.Cstr_PetBeAttacked[k] = StringManager.Instance.SpawnString(100);
				}
				else
				{
					this.Cstr_PetBeAttacked[k] = StringManager.Instance.SpawnString(30);
				}
			}
			for (int l = 0; l < 5; l++)
			{
				this.Cstr_PetResources[l] = StringManager.Instance.SpawnString(30);
			}
			for (int m = 0; m < 16; m++)
			{
				this.Cstr_Soldier_Hurt[m] = StringManager.Instance.SpawnString(30);
				this.Cstr_Soldier_Death[m] = StringManager.Instance.SpawnString(30);
			}
			this.Tmp = this.GameT.GetChild(0);
			this.Tmp1 = this.Tmp.GetChild(1);
			this.text_TitleName = this.Tmp1.GetChild(0).GetComponent<UIText>();
			this.text_TitleName.font = this.TTFont;
			this.text_Page = this.Tmp1.GetChild(1).GetComponent<UIText>();
			this.text_Page.font = this.TTFont;
			this.Mask_T = this.GameT.GetChild(1);
			this.m_Mask = this.Mask_T.GetComponent<CScrollRect>();
			this.ContentRT = this.Mask_T.GetChild(0).GetComponent<RectTransform>();
			this.Tmp1 = this.Mask_T.GetChild(0).GetChild(0);
			this.text_tmpStr = this.Tmp1.GetChild(1).GetComponent<UIText>();
			this.text_tmpStr.font = this.TTFont;
			this.LightT1 = this.Tmp1.GetChild(0);
			this.text_Summary = this.Tmp1.GetChild(1).GetComponent<UIText>();
			this.text_Summary.font = this.TTFont;
			this.tmpH -= 136f;
			this.Tmp1 = this.Mask_T.GetChild(0).GetChild(1);
			this.SummaryRT = this.Tmp1.GetComponent<RectTransform>();
			this.SummaryRT.anchoredPosition = new Vector2(this.SummaryRT.anchoredPosition.x, this.tmpH);
			this.Tmp2 = this.Tmp1.GetChild(2);
			this.Img_Summarybg[0] = this.Tmp2.GetComponent<Image>();
			this.Tmp2 = this.Tmp1.GetChild(3);
			this.Img_Summarybg[1] = this.Tmp2.GetComponent<Image>();
			this.Tmp2 = this.Tmp1.GetChild(0).GetChild(0);
			this.text_Offensive[0] = this.Tmp2.GetComponent<UIText>();
			this.text_Offensive[0].font = this.TTFont;
			this.Cstr_Offensive[0].ClearString();
			this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0);
			this.text_Offensive[1] = this.Tmp2.GetComponent<UIText>();
			this.text_Offensive[1].font = this.TTFont;
			this.Tmp2 = this.Tmp1.GetChild(4);
			this.Img_MainHero[0] = this.Tmp2.GetComponent<Image>();
			this.Img_MainHero[1] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<Image>();
			this.Img_MainHero[1].material = this.IconMaterial;
			this.tmpRC = this.Tmp2.GetChild(0).GetChild(0).GetComponent<RectTransform>();
			this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
			this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.Img_MainHero[2] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<Image>();
			this.Img_MainHero[2].sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, 11);
			this.Img_MainHero[2].material = this.FrameMaterial;
			this.tmpRC = this.Tmp2.GetChild(0).GetChild(1).GetComponent<RectTransform>();
			this.tmpRC.anchorMin = Vector2.zero;
			this.tmpRC.anchorMax = new Vector2(1f, 1f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.Img_MainTitle[0] = this.Tmp2.GetChild(1).GetComponent<Image>();
			this.text_MainHero_F[0] = this.Tmp2.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.text_MainHero_F[0].font = this.TTFont;
			this.text_Dominance[0] = this.Tmp2.GetChild(2).GetChild(0).GetComponent<UIText>();
			this.text_Dominance[0].font = this.TTFont;
			this.Cstr_Dominance[0].ClearString();
			this.Img_Country[0] = this.Tmp2.GetChild(3).GetComponent<Image>();
			this.text_Country[0] = this.Tmp2.GetChild(3).GetChild(0).GetComponent<UIText>();
			this.text_Country[0].font = this.TTFont;
			this.Cstr_Country[0].ClearString();
			this.text_Country[0].text = this.Cstr_Country[0].ToString();
			this.Img_Rank[0] = this.Tmp2.GetChild(4).GetComponent<Image>();
			if (this.GUIM.IsArabic)
			{
				this.Img_Rank[0].transform.localScale = new Vector3(-1f, this.Img_Rank[0].transform.localScale.y, this.Img_Rank[0].transform.localScale.z);
			}
			int num = 0;
			this.Img_Vip[0] = this.Tmp2.GetChild(5).GetComponent<Image>();
			if (this.GUIM.IsArabic)
			{
				this.Img_Vip[0].transform.localScale = new Vector3(-1f, this.Img_Vip[0].transform.localScale.y, this.Img_Vip[0].transform.localScale.z);
			}
			this.btn_Coordinate[0] = this.Tmp2.GetChild(6).GetComponent<UIButton>();
			this.btn_Coordinate[0].m_Handler = this;
			this.btn_Coordinate[0].m_BtnID1 = 6;
			this.text_CoordinateMainHero[0] = this.Tmp2.GetChild(6).GetChild(1).GetComponent<UIText>();
			this.text_CoordinateMainHero[0].font = this.TTFont;
			this.text_Vip[0] = this.Tmp2.GetChild(7).GetComponent<UIText>();
			this.text_Vip[0].font = this.TTFont;
			this.text_Vip[0].text = num.ToString();
			this.text_Name[0] = this.Tmp2.GetChild(8).GetComponent<UIText>();
			this.text_Name[0].font = this.TTFont;
			this.Cstr_Name[0].ClearString();
			this.Tmp2 = this.Tmp1.GetChild(5);
			this.Img_MainHero[3] = this.Tmp2.GetComponent<Image>();
			this.Img_MainHero[4] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<Image>();
			this.Img_MainHero[4].material = this.IconMaterial;
			this.tmpRC = this.Tmp2.GetChild(0).GetChild(0).GetComponent<RectTransform>();
			this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
			this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.Img_MainHero[5] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<Image>();
			this.Img_MainHero[5].sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, 11);
			this.Img_MainHero[5].material = this.FrameMaterial;
			this.tmpRC = this.Tmp2.GetChild(0).GetChild(1).GetComponent<RectTransform>();
			this.tmpRC.anchorMin = Vector2.zero;
			this.tmpRC.anchorMax = new Vector2(1f, 1f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.Img_MainTitle[1] = this.Tmp2.GetChild(1).GetComponent<Image>();
			this.text_MainHero_F[1] = this.Tmp2.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.text_MainHero_F[1].font = this.TTFont;
			this.text_Dominance[1] = this.Tmp2.GetChild(2).GetChild(0).GetComponent<UIText>();
			this.text_Dominance[1].font = this.TTFont;
			this.Cstr_Dominance[1].ClearString();
			this.text_Dominance[1].text = this.Cstr_Dominance[1].ToString();
			this.Img_Country[1] = this.Tmp2.GetChild(3).GetComponent<Image>();
			this.text_Country[1] = this.Tmp2.GetChild(3).GetChild(0).GetComponent<UIText>();
			this.text_Country[1].font = this.TTFont;
			this.Cstr_Country[1].ClearString();
			this.Cstr_Dominance[1].ClearString();
			this.Img_Rank[1] = this.Tmp2.GetChild(4).GetComponent<Image>();
			if (this.GUIM.IsArabic)
			{
				this.Img_Rank[1].transform.localScale = new Vector3(-1f, this.Img_Rank[1].transform.localScale.y, this.Img_Rank[1].transform.localScale.z);
			}
			int num2 = 0;
			this.Img_Vip[1] = this.Tmp2.GetChild(5).GetComponent<Image>();
			if (this.GUIM.IsArabic)
			{
				this.Img_Vip[1].transform.localScale = new Vector3(-1f, this.Img_Vip[1].transform.localScale.y, this.Img_Vip[1].transform.localScale.z);
			}
			this.btn_Coordinate[1] = this.Tmp2.GetChild(6).GetComponent<UIButton>();
			this.btn_Coordinate[1].m_Handler = this;
			this.btn_Coordinate[1].m_BtnID1 = 7;
			this.text_CoordinateMainHero[1] = this.Tmp2.GetChild(6).GetChild(1).GetComponent<UIText>();
			this.text_CoordinateMainHero[1].font = this.TTFont;
			this.text_Vip[1] = this.Tmp2.GetChild(7).GetComponent<UIText>();
			this.text_Vip[1].font = this.TTFont;
			this.text_Vip[1].text = num2.ToString();
			this.text_Name[1] = this.Tmp2.GetChild(8).GetComponent<UIText>();
			this.text_Name[1].font = this.TTFont;
			this.LightT2 = this.Tmp1.GetChild(6);
			this.Img_Vs = this.Tmp1.GetChild(7).GetChild(0).GetComponent<Image>();
			Image component = this.Tmp1.GetChild(7).GetComponent<Image>();
			if (this.GUIM.IsArabic)
			{
				component.transform.localScale = new Vector3(-1f, component.transform.localScale.y, component.transform.localScale.z);
			}
			this.Tmp2 = this.Tmp1.GetChild(8);
			this.Pet_BGRT = this.Tmp2.GetChild(0).GetComponent<RectTransform>();
			this.btn_Pet = this.Tmp2.GetChild(2).GetComponent<UIHIBtn>();
			this.GUIM.InitianHeroItemImg(this.btn_Pet.transform, eHeroOrItem.Pet, 1, 0, 0, 0, false, false, false, false);
			this.text_PetSkillTitle = this.Tmp2.GetChild(3).GetComponent<UIText>();
			this.text_PetSkillTitle.font = this.TTFont;
			this.text_PetSkillTitle.text = this.DM.mStringTable.GetStringByID(10113u);
			this.text_PetSkillInfo = this.Tmp2.GetChild(4).GetComponent<UIText>();
			this.text_PetSkillInfo.font = this.TTFont;
			this.text_PetSkillInfo.color = Color.white;
			this.text_PetName = this.Tmp2.GetChild(5).GetComponent<UIText>();
			this.text_PetName.font = this.TTFont;
			this.text_PetSkillLv = this.Tmp2.GetChild(6).GetComponent<UIText>();
			this.text_PetSkillLv.font = this.TTFont;
			this.Tmp2 = this.Tmp1.GetChild(8).GetChild(7);
			this.Pet_InfoRT = this.Tmp2.GetComponent<RectTransform>();
			this.Pet_WallRT = this.Tmp2.GetChild(0).GetComponent<RectTransform>();
			this.text_PetWall[0] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.text_PetWall[0].font = this.TTFont;
			this.text_PetWall[1] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<UIText>();
			this.text_PetWall[1].font = this.TTFont;
			this.Pet_AttackRT = this.Tmp2.GetChild(1).GetComponent<RectTransform>();
			for (int n = 0; n < 5; n++)
			{
				this.text_PetAttack[n] = this.Tmp2.GetChild(1).GetChild(n).GetComponent<UIText>();
				this.text_PetAttack[n].font = this.TTFont;
			}
			this.text_PetAttack[1].text = this.DM.mStringTable.GetStringByID(5326u);
			this.text_PetAttack[3].text = this.DM.mStringTable.GetStringByID(5327u);
			this.Pet_BeAttackedRT = this.Tmp2.GetChild(2).GetComponent<RectTransform>();
			this.text_PetBeAttacked[0] = this.Tmp2.GetChild(2).GetChild(0).GetComponent<UIText>();
			this.text_PetBeAttacked[0].font = this.TTFont;
			this.text_PetBeAttacked[1] = this.Tmp2.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
			this.text_PetBeAttacked[1].font = this.TTFont;
			this.text_PetBeAttacked[1].text = this.DM.mStringTable.GetStringByID(5341u);
			this.text_PetBeAttacked[2] = this.Tmp2.GetChild(2).GetChild(1).GetChild(1).GetComponent<UIText>();
			this.text_PetBeAttacked[2].font = this.TTFont;
			this.text_PetBeAttacked[2].text = this.DM.mStringTable.GetStringByID(5343u);
			this.text_PetBeAttacked[3] = this.Tmp2.GetChild(2).GetChild(1).GetChild(2).GetComponent<UIText>();
			this.text_PetBeAttacked[3].font = this.TTFont;
			this.text_PetBeAttacked[3].text = this.DM.mStringTable.GetStringByID(5344u);
			for (int num3 = 0; num3 < 16; num3++)
			{
				this.Soldier_T[num3] = this.Tmp2.GetChild(2).GetChild(2 + num3);
				this.Pet_btnSoldierRT[num3] = this.Soldier_T[num3].GetChild(0).GetComponent<RectTransform>();
				this.Hbtn_Hint[num3] = this.Soldier_T[num3].GetChild(0).gameObject.AddComponent<UIButtonHint>();
				this.Hbtn_Hint[num3].m_eHint = EUIButtonHint.CountDown;
				this.Hbtn_Hint[num3].DelayTime = 0.2f;
				this.Hbtn_Hint[num3].m_Handler = this;
				this.Hbtn_Hint[num3].Parm1 = 1;
				this.Img_Soldier[num3] = this.Soldier_T[num3].GetChild(0).GetChild(0).GetComponent<Image>();
				this.text_Soldier_Rank[num3] = this.Soldier_T[num3].GetChild(0).GetChild(1).GetComponent<UIText>();
				this.text_Soldier_Rank[num3].font = this.TTFont;
				this.text_Soldier_Name[num3] = this.Soldier_T[num3].GetChild(0).GetChild(2).GetComponent<UIText>();
				this.text_Soldier_Name[num3].font = this.TTFont;
				this.text_Soldier_Hurt[num3] = this.Soldier_T[num3].GetChild(1).GetComponent<UIText>();
				this.text_Soldier_Hurt[num3].font = this.TTFont;
				this.text_Soldier_Death[num3] = this.Soldier_T[num3].GetChild(2).GetComponent<UIText>();
				this.text_Soldier_Death[num3].font = this.TTFont;
			}
			UIButtonHint.scrollRect = this.m_Mask;
			this.Pet_ResourcesRT = this.Tmp2.GetChild(3).GetComponent<RectTransform>();
			for (int num4 = 0; num4 < 5; num4++)
			{
				this.text_PetResources[num4] = this.Tmp2.GetChild(3).GetChild(num4).GetChild(0).GetComponent<UIText>();
				this.text_PetResources[num4].font = this.TTFont;
			}
			this.text_PetLoss = this.Tmp2.GetChild(4).GetComponent<UIText>();
			this.text_PetLoss.font = this.TTFont;
			this.text_PetLoss.text = this.DM.mStringTable.GetStringByID(5321u);
			this.Tmp1 = this.Mask_T.GetChild(0).GetChild(2);
			this.FailureRT = this.Tmp1.GetComponent<RectTransform>();
			this.FailureRT.anchoredPosition = new Vector2(this.SummaryRT.anchoredPosition.x, this.tmpH);
			this.btn_Pet_Failure = this.Tmp1.GetChild(1).GetComponent<UIHIBtn>();
			this.GUIM.InitianHeroItemImg(this.btn_Pet_Failure.transform, eHeroOrItem.Pet, 1, 0, 0, 0, false, false, false, false);
			this.text_FailurePetSkillInfo = this.Tmp1.GetChild(2).GetComponent<UIText>();
			this.text_FailurePetSkillInfo.font = this.TTFont;
			this.text_FailurePetName = this.Tmp1.GetChild(3).GetComponent<UIText>();
			this.text_FailurePetName.font = this.TTFont;
			this.text_FailurePetSkillLv = this.Tmp1.GetChild(4).GetComponent<UIText>();
			this.text_FailurePetSkillLv.font = this.TTFont;
			this.Tmp = this.GameT.GetChild(2);
			this.Tmp1 = this.Tmp.GetChild(0);
			this.btn_Title = this.Tmp1.GetComponent<UIButton>();
			this.btn_Title.m_Handler = this;
			this.btn_Title.m_BtnID1 = 3;
			this.text_Coordinate = this.Tmp1.GetChild(1).GetComponent<UIText>();
			this.text_Coordinate.font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(1);
			this.text_Time[0] = this.Tmp1.GetComponent<UIText>();
			this.text_Time[0].font = this.TTFont;
			this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Pet.Times).ToShortDateString();
			this.Tmp1 = this.Tmp.GetChild(2);
			this.text_Time[1] = this.Tmp1.GetComponent<UIText>();
			this.text_Time[1].font = this.TTFont;
			this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Pet.Times).ToString("HH:mm:ss");
			this.Tmp1 = this.GameT.GetChild(3);
			this.btn_Delete = this.Tmp1.GetComponent<UIButton>();
			this.btn_Delete.m_Handler = this;
			this.btn_Delete.m_BtnID1 = 4;
			this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
			this.btn_Delete.transition = Selectable.Transition.None;
			this.Tmp1 = this.GameT.GetChild(4);
			this.btn_Collect = this.Tmp1.GetComponent<UIButton>();
			this.btn_Collect.m_Handler = this;
			this.btn_Collect.m_BtnID1 = 5;
			this.btn_Collect.m_EffectType = e_EffectType.e_Scale;
			this.btn_Collect.transition = Selectable.Transition.None;
			float x = this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x;
			this.tempL = (this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x - 853f) / 2f;
			this.PreviousT = this.GameT.GetChild(5);
			this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
			this.btn_Previous.m_Handler = this;
			this.btn_Previous.m_BtnID1 = 1;
			this.btn_Previous.m_EffectType = e_EffectType.e_Scale;
			this.btn_Previous.transition = Selectable.Transition.None;
			this.NextT = this.GameT.GetChild(6);
			this.btn_Next = this.NextT.GetComponent<UIButton>();
			this.btn_Next.m_Handler = this;
			this.btn_Next.m_BtnID1 = 2;
			this.btn_Next.m_EffectType = e_EffectType.e_Scale;
			this.btn_Next.transition = Selectable.Transition.None;
			if (this.tempL > 0f && this.NextT.localPosition.x + this.tempL > x / 2f)
			{
				this.tempL = x / 2f - this.NextT.localPosition.x;
			}
			this.MoveTime1 = this.NextT.localPosition.x + this.tempL;
			this.MoveTime2 = this.PreviousT.localPosition.x - this.tempL;
			if (this.GUIM.bOpenOnIPhoneX)
			{
				this.MoveTime1 -= this.GUIM.IPhoneX_DeltaX;
				this.MoveTime2 += this.GUIM.IPhoneX_DeltaX;
			}
			this.Vec3Instance.Set(this.MoveTime1, this.NextT.localPosition.y, this.NextT.localPosition.z);
			this.NextT.localPosition = this.Vec3Instance;
			this.Vec3Instance.Set(this.MoveTime2, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
			this.PreviousT.localPosition = this.Vec3Instance;
			this.Tmp = this.GameT.GetChild(7);
			component = this.Tmp.GetComponent<Image>();
			cstring.ClearString();
			cstring.AppendFormat("UI_main_close_base");
			component.sprite = this.door.LoadSprite(cstring);
			component.material = this.mMaT;
			if (this.GUIM.bOpenOnIPhoneX)
			{
				component.enabled = false;
			}
			this.Tmp = this.GameT.GetChild(7).GetChild(0);
			this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
			cstring.ClearString();
			cstring.AppendFormat("UI_main_close");
			this.btn_EXIT.image.sprite = this.door.LoadSprite(cstring);
			this.btn_EXIT.image.material = this.mMaT;
			this.btn_EXIT.m_Handler = this;
			this.btn_EXIT.m_BtnID1 = 0;
			this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
			this.btn_EXIT.transition = Selectable.Transition.None;
			this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, -this.tmpH);
			this.SetFSInfo();
			this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
			if (this.DM.mFs_Serial == this.Favor.Serial && this.DM.LetterFs_Y > -1f)
			{
				this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, this.DM.LetterFs_Y);
			}
			else
			{
				this.DM.LetterFs_Y = -1f;
			}
			this.SetPorfileBtn();
			return;
		}
		this.door.CloseMenu(false);
	}

	// Token: 0x06001EE7 RID: 7911 RVA: 0x003B2EB0 File Offset: 0x003B10B0
	public void SetFSInfo()
	{
		this.tmpH = -136f;
		this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
		this.text_Time[0].SetAllDirty();
		this.text_Time[0].cachedTextGenerator.Invalidate();
		this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
		this.text_Time[1].SetAllDirty();
		this.text_Time[1].cachedTextGenerator.Invalidate();
		this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
		this.Cstr_Page.ClearString();
		switch (this.DM.OpenMail.Kind)
		{
		case MailType.EMAIL_BATTLE:
			this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
			this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
			break;
		case MailType.EMAIL_FAVORY:
			this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
			this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
			break;
		}
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Page.AppendFormat("{1}/{0}");
		}
		else
		{
			this.Cstr_Page.AppendFormat("{0}/{1}");
		}
		this.text_Page.text = this.Cstr_Page.ToString();
		this.text_Page.SetAllDirty();
		this.text_Page.cachedTextGenerator.Invalidate();
		if (this.MaxLetterNum > 1)
		{
			if (this.Report.Index + 1 == 1)
			{
				this.btn_Previous.gameObject.SetActive(false);
			}
			else
			{
				this.btn_Previous.gameObject.SetActive(true);
			}
			if ((int)(this.Report.Index + 1) == this.MaxLetterNum)
			{
				this.btn_Next.gameObject.SetActive(false);
			}
			else
			{
				this.btn_Next.gameObject.SetActive(true);
			}
		}
		else
		{
			this.btn_Previous.gameObject.SetActive(false);
			this.btn_Next.gameObject.SetActive(false);
		}
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		CString cstring3 = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring2.ClearString();
		cstring3.ClearString();
		this.Cstr_TitleName.ClearString();
		if (this.Report.Pet.Side == 0)
		{
			cstring2.Append(this.Report.Pet.DefenceName);
			if (this.Report.Pet.DefenceAllianceTag != string.Empty)
			{
				cstring3.Append(this.Report.Pet.DefenceAllianceTag);
				if (this.Report.Pet.AssaultKingdomID != this.Report.Pet.DefenceKingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, this.Report.Pet.DefenceKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
			}
			else if (this.Report.Pet.AssaultKingdomID != this.Report.Pet.DefenceKingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, this.Report.Pet.DefenceKingdomID, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
			}
			this.Cstr_TitleName.StringToFormat(cstring);
			this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter((POINT_KIND)this.Report.Pet.Kind));
			this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(10093u));
		}
		else
		{
			cstring2.Append(this.Report.Pet.AssaultName);
			if (this.Report.Pet.AssaultAllianceTag != string.Empty)
			{
				cstring3.Append(this.Report.Pet.AssaultAllianceTag);
				if (this.Report.Pet.AssaultKingdomID != this.Report.Pet.DefenceKingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, this.Report.Pet.AssaultKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
			}
			else if (this.Report.Pet.AssaultKingdomID != this.Report.Pet.DefenceKingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, this.Report.Pet.AssaultKingdomID, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
			}
			this.Cstr_TitleName.StringToFormat(cstring);
			this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter((POINT_KIND)this.Report.Pet.Kind));
			this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(10094u));
		}
		this.text_TitleName.text = this.Cstr_TitleName.ToString();
		this.text_TitleName.SetAllDirty();
		this.text_TitleName.cachedTextGenerator.Invalidate();
		this.Cstr_Coordinate[0].ClearString();
		this.Cstr_Coordinate[1].ClearString();
		this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Pet.Zone, this.Report.Pet.Point));
		this.Cstr_Coordinate[0].IntToFormat((long)this.Report.Pet.KindgomID, 1, false);
		this.Cstr_Coordinate[0].IntToFormat((long)((int)this.tmpV.x), 1, false);
		this.Cstr_Coordinate[0].IntToFormat((long)((int)this.tmpV.y), 1, false);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Coordinate[0].AppendFormat("{0}:K {1}:X {2}:Y");
		}
		else
		{
			this.Cstr_Coordinate[0].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
		}
		this.Cstr_Coordinate[1].StringToFormat(this.Cstr_Coordinate[0]);
		this.Cstr_Coordinate[1].AppendFormat(this.DM.mStringTable.GetStringByID(10092u));
		this.text_Coordinate.text = this.Cstr_Coordinate[1].ToString();
		this.text_Coordinate.SetAllDirty();
		this.text_Coordinate.cachedTextGenerator.Invalidate();
		this.text_Coordinate.cachedTextGeneratorForLayout.Invalidate();
		this.tmpRC = this.btn_Title.transform.GetComponent<RectTransform>();
		this.tmpRC.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRC.sizeDelta.y);
		this.tmpRC = this.btn_Title.transform.GetChild(0).GetComponent<RectTransform>();
		this.tmpRC.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRC.sizeDelta.y);
		this.tmpRC = this.btn_Title.transform.GetChild(1).GetComponent<RectTransform>();
		this.tmpRC.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRC.sizeDelta.y);
		this.tmpPT = this.PM.PetTable.GetRecordByKey(this.Report.Pet.PetID);
		this.skill = this.PM.PetSkillTable.GetRecordByKey(this.Report.Pet.SkillID);
		if (this.Report.Pet.Result == PetReportResultType.EPRR_ATTACKFAILED)
		{
			this.SummaryRT.gameObject.SetActive(false);
			this.FailureRT.gameObject.SetActive(true);
			this.tmpH -= 305f;
			this.GUIM.ChangeHeroItemImg(this.btn_Pet_Failure.transform, eHeroOrItem.Pet, this.Report.Pet.PetID, 0, 0, 0);
			this.text_FailurePetName.text = this.DM.mStringTable.GetStringByID((uint)this.tmpPT.Name);
			this.text_FailurePetName.SetAllDirty();
			this.text_FailurePetName.cachedTextGenerator.Invalidate();
			this.Cstr_PetSkillLv.ClearString();
			this.Cstr_PetSkillLv.IntToFormat((long)this.Report.Pet.SkillLevel, 1, false);
			this.Cstr_PetSkillLv.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.skill.Name));
			this.Cstr_PetSkillLv.AppendFormat(this.DM.mStringTable.GetStringByID(268u));
			this.text_FailurePetSkillLv.text = this.Cstr_PetSkillLv.ToString();
			this.text_FailurePetSkillLv.SetAllDirty();
			this.text_FailurePetSkillLv.cachedTextGenerator.Invalidate();
			this.Cstr_PetSkillInfo.ClearString();
			this.text_tmpStr.text = this.DM.mStringTable.GetStringByID(10097u);
			this.text_tmpStr.SetAllDirty();
			this.text_tmpStr.cachedTextGenerator.Invalidate();
			this.Cstr_PetSkillInfo.Append(this.DM.mStringTable.GetStringByID(10098u));
			this.text_FailurePetSkillInfo.color = new Color(1f, 0.353f, 0.443f);
			this.text_FailurePetSkillInfo.text = this.Cstr_PetSkillInfo.ToString();
			this.text_FailurePetSkillInfo.SetAllDirty();
			this.text_FailurePetSkillInfo.cachedTextGenerator.Invalidate();
			this.text_FailurePetSkillInfo.cachedTextGeneratorForLayout.Invalidate();
			float y = this.text_FailurePetSkillInfo.preferredHeight + 1f;
			if (this.text_FailurePetSkillInfo.preferredHeight > 150f)
			{
				y = 150f;
			}
			this.text_FailurePetSkillInfo.rectTransform.sizeDelta = new Vector2(this.text_FailurePetSkillInfo.rectTransform.sizeDelta.x, y);
		}
		else
		{
			this.SummaryRT.gameObject.SetActive(true);
			this.FailureRT.gameObject.SetActive(false);
			this.tmpH -= 363f;
			this.tmpH -= 226f;
			this.Cstr_Offensive[0].ClearString();
			this.Cstr_Offensive[1].ClearString();
			if (this.IsAttack)
			{
				this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(5315u));
				this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(5317u));
				this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(10096u));
				this.Img_Summarybg[0].sprite = this.SArray.m_Sprites[0];
				this.Img_Summarybg[1].sprite = this.SArray.m_Sprites[1];
				this.text_tmpStr.text = this.DM.mStringTable.GetStringByID(10095u);
			}
			else
			{
				this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(5315u));
				this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(10096u));
				this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(5317u));
				this.Img_Summarybg[0].sprite = this.SArray.m_Sprites[1];
				this.Img_Summarybg[1].sprite = this.SArray.m_Sprites[0];
				this.text_tmpStr.text = this.DM.mStringTable.GetStringByID(10110u);
			}
			this.text_tmpStr.SetAllDirty();
			this.text_tmpStr.cachedTextGenerator.Invalidate();
			this.text_Offensive[0].text = this.Cstr_Offensive[0].ToString();
			this.text_Offensive[0].SetAllDirty();
			this.text_Offensive[0].cachedTextGenerator.Invalidate();
			this.text_Offensive[1].text = this.Cstr_Offensive[1].ToString();
			this.text_Offensive[1].SetAllDirty();
			this.text_Offensive[1].cachedTextGenerator.Invalidate();
			this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.Report.Pet.AssaultHead);
			this.Img_MainHero[1].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
			this.Cstr_Dominance[0].ClearString();
			this.Cstr_Dominance[0].IntToFormat((long)this.Report.Pet.AssaultLevel, 1, false);
			this.Cstr_Dominance[0].AppendFormat(this.DM.mStringTable.GetStringByID(5320u));
			this.text_Dominance[0].text = this.Cstr_Dominance[0].ToString();
			this.text_Dominance[0].SetAllDirty();
			this.text_Dominance[0].cachedTextGenerator.Invalidate();
			this.Cstr_Country[0].ClearString();
			this.Cstr_Country[0].IntToFormat((long)this.Report.Pet.AssaultKingdomID, 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Country[0].AppendFormat("{0}#");
			}
			else
			{
				this.Cstr_Country[0].AppendFormat("#{0}");
			}
			this.text_Country[0].text = this.Cstr_Country[0].ToString();
			this.text_Country[0].SetAllDirty();
			this.text_Country[0].cachedTextGenerator.Invalidate();
			int assaultAllianceRank = (int)this.Report.Pet.AssaultAllianceRank;
			this.Img_Rank[0].sprite = this.SArray.m_Sprites[1 + assaultAllianceRank];
			if (assaultAllianceRank < 1)
			{
				this.Img_Rank[0].gameObject.SetActive(false);
			}
			else
			{
				this.Img_Rank[0].gameObject.SetActive(true);
			}
			int assaultVIPLevel = (int)this.Report.Pet.AssaultVIPLevel;
			this.text_Vip[0].text = assaultVIPLevel.ToString();
			this.Cstr_CoordinateMainHero[0].ClearString();
			this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Pet.AssaultCapitalZone, this.Report.Pet.AssaultCapitalPoint));
			this.Cstr_CoordinateMainHero[0].IntToFormat((long)this.Report.Pet.KindgomID, 1, false);
			this.Cstr_CoordinateMainHero[0].IntToFormat((long)((int)this.tmpV.x), 1, false);
			this.Cstr_CoordinateMainHero[0].IntToFormat((long)((int)this.tmpV.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_CoordinateMainHero[0].AppendFormat("{2}:Y {1}:X {0}:K");
			}
			else
			{
				this.Cstr_CoordinateMainHero[0].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
			}
			this.text_CoordinateMainHero[0].text = this.Cstr_CoordinateMainHero[0].ToString();
			this.text_CoordinateMainHero[0].SetAllDirty();
			this.text_CoordinateMainHero[0].cachedTextGenerator.Invalidate();
			this.text_CoordinateMainHero[0].cachedTextGeneratorForLayout.Invalidate();
			this.tmpRC = this.btn_Coordinate[0].transform.GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[0].preferredWidth, this.tmpRC.sizeDelta.y);
			this.tmpRC = this.btn_Coordinate[0].transform.GetChild(0).GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[0].preferredWidth, this.tmpRC.sizeDelta.y);
			this.tmpRC = this.btn_Coordinate[0].transform.GetChild(1).GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[0].preferredWidth, this.tmpRC.sizeDelta.y);
			this.Cstr_Name[0].ClearString();
			CString cstring4 = StringManager.Instance.StaticString1024();
			CString cstring5 = StringManager.Instance.StaticString1024();
			cstring4.ClearString();
			cstring5.ClearString();
			cstring4.Append(this.Report.Pet.AssaultName);
			if (this.Report.Pet.AssaultAllianceTag != string.Empty)
			{
				cstring5.Append(this.Report.Pet.AssaultAllianceTag);
				GameConstants.FormatRoleName(this.Cstr_Name[0], cstring4, cstring5, null, 0, 0, null, null, null, null);
			}
			else
			{
				GameConstants.FormatRoleName(this.Cstr_Name[0], cstring4, null, null, 0, 0, null, null, null, null);
			}
			this.text_Name[0].text = this.Cstr_Name[0].ToString();
			this.text_Name[0].SetAllDirty();
			this.text_Name[0].cachedTextGenerator.Invalidate();
			this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.Report.Pet.DefenceHead);
			this.Img_MainHero[4].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
			this.Cstr_Dominance[1].ClearString();
			this.Cstr_Dominance[1].IntToFormat((long)this.Report.Pet.DefenceLevel, 1, false);
			this.Cstr_Dominance[1].AppendFormat(this.DM.mStringTable.GetStringByID(5320u));
			this.text_Dominance[1].text = this.Cstr_Dominance[1].ToString();
			this.text_Dominance[1].SetAllDirty();
			this.text_Dominance[1].cachedTextGenerator.Invalidate();
			this.Cstr_Country[1].ClearString();
			this.Cstr_Country[1].IntToFormat((long)this.Report.Pet.DefenceKingdomID, 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Country[1].AppendFormat("{0}#");
			}
			else
			{
				this.Cstr_Country[1].AppendFormat("#{0}");
			}
			this.text_Country[1].text = this.Cstr_Country[1].ToString();
			this.text_Country[1].SetAllDirty();
			this.text_Country[1].cachedTextGenerator.Invalidate();
			int defenceAllianceRank = (int)this.Report.Pet.DefenceAllianceRank;
			this.Img_Rank[1].sprite = this.SArray.m_Sprites[1 + defenceAllianceRank];
			if (defenceAllianceRank < 1)
			{
				this.Img_Rank[1].gameObject.SetActive(false);
			}
			else
			{
				this.Img_Rank[1].gameObject.SetActive(true);
			}
			int defenceVIPLevel = (int)this.Report.Pet.DefenceVIPLevel;
			this.text_Vip[1].text = defenceVIPLevel.ToString();
			this.Cstr_CoordinateMainHero[1].ClearString();
			this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Pet.DefenceCapitalZone, this.Report.Pet.DefenceCapitalPoint));
			this.Cstr_CoordinateMainHero[1].IntToFormat((long)this.Report.Pet.KindgomID, 1, false);
			this.Cstr_CoordinateMainHero[1].IntToFormat((long)((int)this.tmpV.x), 1, false);
			this.Cstr_CoordinateMainHero[1].IntToFormat((long)((int)this.tmpV.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_CoordinateMainHero[1].AppendFormat("{2}:Y {1}:X {0}:K");
			}
			else
			{
				this.Cstr_CoordinateMainHero[1].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
			}
			this.text_CoordinateMainHero[1].text = this.Cstr_CoordinateMainHero[1].ToString();
			this.text_CoordinateMainHero[1].SetAllDirty();
			this.text_CoordinateMainHero[1].cachedTextGenerator.Invalidate();
			this.text_CoordinateMainHero[1].cachedTextGeneratorForLayout.Invalidate();
			this.tmpRC = this.btn_Coordinate[1].transform.GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[1].preferredWidth, this.tmpRC.sizeDelta.y);
			this.tmpRC = this.btn_Coordinate[1].transform.GetChild(0).GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[1].preferredWidth, this.tmpRC.sizeDelta.y);
			this.tmpRC = this.btn_Coordinate[1].transform.GetChild(1).GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[1].preferredWidth, this.tmpRC.sizeDelta.y);
			this.Cstr_Name[1].ClearString();
			cstring4.ClearString();
			cstring5.ClearString();
			cstring4.Append(this.Report.Pet.DefenceName);
			if (this.Report.Pet.DefenceAllianceTag != string.Empty)
			{
				cstring5.Append(this.Report.Pet.DefenceAllianceTag);
				GameConstants.FormatRoleName(this.Cstr_Name[1], cstring4, cstring5, null, 0, 0, null, null, null, null);
			}
			else
			{
				GameConstants.FormatRoleName(this.Cstr_Name[1], cstring4, null, null, 0, 0, null, null, null, null);
			}
			this.text_Name[1].text = this.Cstr_Name[1].ToString();
			this.text_Name[1].SetAllDirty();
			this.text_Name[1].cachedTextGenerator.Invalidate();
			this.GUIM.ChangeHeroItemImg(this.btn_Pet.transform, eHeroOrItem.Pet, this.Report.Pet.PetID, this.Report.Pet.PetStar, 0, 0);
			this.text_PetName.text = this.DM.mStringTable.GetStringByID((uint)this.tmpPT.Name);
			this.text_PetName.SetAllDirty();
			this.text_PetName.cachedTextGenerator.Invalidate();
			this.Cstr_PetSkillLv.ClearString();
			this.Cstr_PetSkillLv.IntToFormat((long)this.Report.Pet.SkillLevel, 1, false);
			this.Cstr_PetSkillLv.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.skill.Name));
			this.Cstr_PetSkillLv.AppendFormat(this.DM.mStringTable.GetStringByID(268u));
			this.text_PetSkillLv.text = this.Cstr_PetSkillLv.ToString();
			this.text_PetSkillLv.SetAllDirty();
			this.text_PetSkillLv.cachedTextGenerator.Invalidate();
			this.Cstr_PetSkillInfo.ClearString();
			if (this.DM.PetVersionNo != this.Report.Pet.PatchNo)
			{
				this.Cstr_PetSkillInfo.Append(this.DM.mStringTable.GetStringByID(10100u));
			}
			else
			{
				this.PM.FormatSkillContent(this.Report.Pet.SkillID, this.Report.Pet.SkillLevel, this.Cstr_PetSkillInfo, 0);
			}
			this.text_PetSkillInfo.text = this.Cstr_PetSkillInfo.ToString();
			this.text_PetSkillInfo.SetAllDirty();
			this.text_PetSkillInfo.cachedTextGenerator.Invalidate();
			this.text_PetSkillInfo.cachedTextGeneratorForLayout.Invalidate();
			this.text_PetSkillInfo.rectTransform.sizeDelta = new Vector2(this.text_PetSkillInfo.rectTransform.sizeDelta.x, this.text_PetSkillInfo.preferredHeight + 1f);
			this.tmpH -= this.text_PetSkillInfo.preferredHeight + 1f - 30f;
			this.Pet_BGRT.sizeDelta = new Vector2(this.Pet_BGRT.sizeDelta.x, 185f + (this.text_PetSkillInfo.preferredHeight + 1f - 30f));
			this.Pet_InfoRT.anchoredPosition = new Vector2(this.Pet_InfoRT.anchoredPosition.x, -226f - (this.text_PetSkillInfo.preferredHeight + 1f - 30f));
			this.Pet_InfoRT.gameObject.SetActive(false);
			this.Pet_WallRT.gameObject.SetActive(false);
			this.Pet_AttackRT.gameObject.SetActive(false);
			this.Pet_BeAttackedRT.gameObject.SetActive(false);
			this.Pet_ResourcesRT.gameObject.SetActive(false);
			if (this.DM.PetVersionNo == this.Report.Pet.PatchNo)
			{
				this.Pet_InfoRT.gameObject.SetActive(true);
				switch (this.Report.Pet.Result)
				{
				case PetReportResultType.EPRR_ATTACK_NONE:
				case PetReportResultType.EPRR_UNDERATTACKED_NONE:
					this.Pet_InfoRT.gameObject.SetActive(false);
					break;
				case PetReportResultType.EPRR_ATTACK_RSS:
				case PetReportResultType.EPRR_UNDERATTACKED_RSS:
					this.Pet_ResourcesRT.gameObject.SetActive(true);
					break;
				case PetReportResultType.EPRR_ATTACK_TROOP:
					this.Pet_AttackRT.gameObject.SetActive(true);
					break;
				case PetReportResultType.EPRR_UNDERATTACKED_TROOP:
					this.Pet_BeAttackedRT.gameObject.SetActive(true);
					break;
				case PetReportResultType.EPRR_ATTACK_WALL:
				case PetReportResultType.EPRR_UNDERATTACKED_WALL:
					this.Pet_WallRT.gameObject.SetActive(true);
					break;
				}
			}
			if (this.Pet_WallRT.gameObject.activeSelf)
			{
				this.tmpH -= 53f;
				this.Cstr_PetWall.ClearString();
				this.Cstr_PetWall.IntToFormat((long)((ulong)this.Report.Pet.WallDamage), 1, true);
				this.Cstr_PetWall.AppendFormat("{0}");
				this.text_PetWall[1].text = this.Cstr_PetWall.ToString();
				this.text_PetWall[1].SetAllDirty();
				this.text_PetWall[1].cachedTextGenerator.Invalidate();
				this.tmpH -= 100f;
			}
			if (this.Pet_AttackRT.gameObject.activeSelf)
			{
				this.tmpH -= 53f;
				this.Cstr_PetAttack[0].ClearString();
				this.Cstr_PetAttack[0].uLongToFormat(this.Report.Pet.LostPower, 1, true);
				this.Cstr_PetAttack[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322u));
				this.text_PetAttack[0].text = this.Cstr_PetAttack[0].ToString();
				this.text_PetAttack[0].SetAllDirty();
				this.text_PetAttack[0].cachedTextGenerator.Invalidate();
				this.Cstr_PetAttack[1].ClearString();
				this.Cstr_PetAttack[1].IntToFormat((long)((ulong)this.Report.Pet.TotalInjure), 1, true);
				this.Cstr_PetAttack[1].AppendFormat("{0}");
				this.text_PetAttack[2].text = this.Cstr_PetAttack[1].ToString();
				this.text_PetAttack[2].SetAllDirty();
				this.text_PetAttack[2].cachedTextGenerator.Invalidate();
				this.Cstr_PetAttack[2].ClearString();
				this.Cstr_PetAttack[2].IntToFormat((long)((ulong)this.Report.Pet.TotalDead), 1, true);
				this.Cstr_PetAttack[2].AppendFormat("{0}");
				this.text_PetAttack[4].text = this.Cstr_PetAttack[2].ToString();
				this.text_PetAttack[4].SetAllDirty();
				this.text_PetAttack[4].cachedTextGenerator.Invalidate();
				this.tmpH -= 145f;
			}
			if (this.Pet_BeAttackedRT.gameObject.activeSelf)
			{
				this.tmpH -= 53f;
				this.Cstr_PetBeAttacked[0].ClearString();
				this.Cstr_PetBeAttacked[0].uLongToFormat(this.Report.Pet.LostPower, 1, true);
				this.Cstr_PetBeAttacked[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322u));
				this.text_PetBeAttacked[0].text = this.Cstr_PetBeAttacked[0].ToString();
				this.text_PetBeAttacked[0].SetAllDirty();
				this.text_PetBeAttacked[0].cachedTextGenerator.Invalidate();
				int num = 0;
				for (int i = 0; i < 16; i++)
				{
					int num2 = 3 - i / 4 + i % 4 * 4;
					if (this.Report.Pet.InjureTroops[num2] != 0u || this.Report.Pet.DeadTroops[num2] != 0u)
					{
						this.Soldier_T[num].gameObject.SetActive(true);
						this.Hbtn_Hint[num].Parm2 = (byte)num2;
						this.Hbtn_Hint[num].enabled = true;
						SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num2 + 1));
						this.Img_Soldier[num].sprite = this.SArray.m_Sprites[(int)(7 + recordByKey.SoldierKind)];
						this.Img_Soldier[num].gameObject.SetActive(true);
						this.text_Soldier_Rank[num].text = recordByKey.Tier.ToString();
						this.text_Soldier_Rank[num].SetAllDirty();
						this.text_Soldier_Rank[num].cachedTextGenerator.Invalidate();
						this.text_Soldier_Name[num].text = this.DM.mStringTable.GetStringByID((uint)recordByKey.Name);
						this.text_Soldier_Name[num].SetAllDirty();
						this.text_Soldier_Name[num].cachedTextGenerator.Invalidate();
						this.text_Soldier_Name[num].cachedTextGeneratorForLayout.Invalidate();
						this.Cstr_Soldier_Hurt[num].ClearString();
						this.Cstr_Soldier_Hurt[num].IntToFormat((long)((ulong)this.Report.Pet.InjureTroops[num2]), 1, true);
						this.Cstr_Soldier_Hurt[num].AppendFormat("{0}");
						this.text_Soldier_Hurt[num].text = this.Cstr_Soldier_Hurt[num].ToString();
						this.text_Soldier_Hurt[num].SetAllDirty();
						this.text_Soldier_Hurt[num].cachedTextGenerator.Invalidate();
						this.Cstr_Soldier_Death[num].ClearString();
						this.Cstr_Soldier_Death[num].IntToFormat((long)((ulong)this.Report.Pet.DeadTroops[num2]), 1, true);
						this.Cstr_Soldier_Death[num].AppendFormat("{0}");
						this.text_Soldier_Death[num].text = this.Cstr_Soldier_Death[num].ToString();
						this.text_Soldier_Death[num].SetAllDirty();
						this.text_Soldier_Death[num].cachedTextGenerator.Invalidate();
						this.Pet_btnSoldierRT[num].sizeDelta = new Vector2(47f + this.text_Soldier_Name[num].preferredWidth, this.Pet_btnSoldierRT[num].sizeDelta.y);
						num++;
					}
				}
				if (num == 0)
				{
					this.Img_Soldier[num].gameObject.SetActive(false);
					this.Hbtn_Hint[num].enabled = false;
					this.text_Soldier_Name[num].text = "-";
					this.text_Soldier_Name[num].SetAllDirty();
					this.text_Soldier_Name[num].cachedTextGenerator.Invalidate();
					this.text_Soldier_Name[num].cachedTextGeneratorForLayout.Invalidate();
					this.Cstr_Soldier_Hurt[num].ClearString();
					this.Cstr_Soldier_Hurt[num].IntToFormat(0L, 1, true);
					this.Cstr_Soldier_Hurt[num].AppendFormat("{0}");
					this.text_Soldier_Hurt[num].text = this.Cstr_Soldier_Hurt[num].ToString();
					this.text_Soldier_Hurt[num].SetAllDirty();
					this.text_Soldier_Hurt[num].cachedTextGenerator.Invalidate();
					this.Cstr_Soldier_Death[num].ClearString();
					this.Cstr_Soldier_Death[num].IntToFormat(0L, 1, true);
					this.Cstr_Soldier_Death[num].AppendFormat("{0}");
					this.text_Soldier_Death[num].text = this.Cstr_Soldier_Death[num].ToString();
					this.text_Soldier_Death[num].SetAllDirty();
					this.text_Soldier_Death[num].cachedTextGenerator.Invalidate();
					this.Soldier_T[num].gameObject.SetActive(true);
					num++;
				}
				for (int j = num; j < 16; j++)
				{
					this.Soldier_T[j].gameObject.SetActive(false);
				}
				this.Pet_BeAttackedRT.sizeDelta = new Vector2(this.Pet_BeAttackedRT.sizeDelta.x, (float)(120 + num * 35));
				this.tmpH -= this.Pet_BeAttackedRT.sizeDelta.y;
			}
			if (this.Pet_ResourcesRT.gameObject.activeSelf)
			{
				this.tmpH -= 53f;
				for (int k = 0; k < 5; k++)
				{
					this.Cstr_PetResources[k].ClearString();
					this.Cstr_PetResources[k].Append("-");
					if (this.Report.Pet.Resource[k] > 0u)
					{
						GameConstants.FormatResourceValue(this.Cstr_PetResources[k], this.Report.Pet.Resource[k]);
					}
					this.text_PetResources[k].text = this.Cstr_PetResources[k].ToString();
					this.text_PetResources[k].SetAllDirty();
					this.text_PetResources[k].cachedTextGenerator.Invalidate();
				}
				this.tmpH -= 95f;
			}
			if (this.Report.Pet.AssaultKingdomID != this.Report.Pet.DefenceKingdomID)
			{
				this.Img_Country[0].gameObject.SetActive(true);
				this.Img_Country[1].gameObject.SetActive(true);
			}
			else
			{
				this.Img_Country[0].gameObject.SetActive(false);
				this.Img_Country[1].gameObject.SetActive(false);
			}
		}
		this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, -this.tmpH);
	}

	// Token: 0x06001EE8 RID: 7912 RVA: 0x003B5358 File Offset: 0x003B3558
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 1:
			this.Open_NP_Mail(false);
			break;
		case 2:
			this.Open_NP_Mail(true);
			break;
		case 3:
			this.door.GoToPointCode(this.Report.Pet.KindgomID, this.Report.Pet.Zone, this.Report.Pet.Point, 0);
			break;
		case 4:
			if (this.DM.BattleReportDelete(this.Report.SerialID))
			{
				this.door.CloseMenu(false);
			}
			break;
		case 5:
			if (this.Favor.Kind == MailType.EMAIL_FAVORY)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6100u), 255, true);
				return;
			}
			this.DM.BattleReportSave(this.Report.SerialID);
			break;
		case 6:
			this.door.GoToPointCode(this.Report.Pet.KindgomID, this.Report.Pet.AssaultCapitalZone, this.Report.Pet.AssaultCapitalPoint, 0);
			break;
		case 7:
			this.door.GoToPointCode(this.Report.Pet.KindgomID, this.Report.Pet.DefenceCapitalZone, this.Report.Pet.DefenceCapitalPoint, 0);
			break;
		case 8:
		case 9:
			this.ShowLordProfile((PetSkill_FS_btn)sender.m_BtnID1);
			break;
		}
	}

	// Token: 0x06001EE9 RID: 7913 RVA: 0x003B5530 File Offset: 0x003B3730
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06001EEA RID: 7914 RVA: 0x003B5534 File Offset: 0x003B3734
	public void OnButtonDown(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 3, 277f, 20, (int)sender.Parm2, 0, new Vector2(70f, 0f), UIButtonHint.ePosition.Original);
	}

	// Token: 0x06001EEB RID: 7915 RVA: 0x003B5574 File Offset: 0x003B3774
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x06001EEC RID: 7916 RVA: 0x003B5588 File Offset: 0x003B3788
	public void Open_NP_Mail(bool bNext)
	{
		if (this.DM.MailReportGet(ref this.Favor, bNext))
		{
			switch (this.Favor.Type)
			{
			case MailType.EMAIL_SYSTEM:
				this.DM.OpenMail.Serial = this.Favor.Serial;
				this.DM.OpenMail.Type = this.Favor.Type;
				this.DM.OpenMail.Kind = this.Favor.Kind;
				this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
				break;
			case MailType.EMAIL_BATTLE:
				this.DM.OpenMail.Serial = this.Favor.Serial;
				this.DM.OpenMail.Type = this.Favor.Type;
				this.DM.OpenMail.Kind = this.Favor.Kind;
				switch (this.Favor.Combat.Type)
				{
				case CombatCollectReport.CCR_BATTLE:
				case CombatCollectReport.CCR_NPCCOMBAT:
					this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
					break;
				case CombatCollectReport.CCR_RESOURCE:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Resources, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
					break;
				case CombatCollectReport.CCR_COLLECT:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Collection, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
					break;
				case CombatCollectReport.CCR_SCOUT:
					if (this.Favor.Combat.Scout.ScoutLevel != 0)
					{
						this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 0, 0, false);
					}
					else
					{
						this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 1, 0, false);
					}
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
					break;
				case CombatCollectReport.CCR_RECON:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
					break;
				case CombatCollectReport.CCR_MONSTER:
					if (this.Favor.Combat.Monster.Result < 2 || this.Favor.Combat.Monster.Result > 3)
					{
						this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 0, 0, false);
						this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
					}
					else
					{
						this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
						this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
					}
					break;
				case CombatCollectReport.CCR_NPCSCOUT:
					this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
					break;
				case CombatCollectReport.CCR_PETREPORT:
					this.m_Mask.StopMovement();
					this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, 0f);
					this.Favor.Serial = this.DM.OpenMail.Serial;
					this.Favor.Type = this.DM.OpenMail.Type;
					this.Favor.Kind = this.DM.OpenMail.Kind;
					if (!this.DM.MailReportGet(ref this.Favor) || this.Favor.Type != MailType.EMAIL_BATTLE)
					{
						this.door.CloseMenu(false);
						return;
					}
					this.Report = this.Favor.Combat;
					if (!this.Report.BeRead)
					{
						if (this.Favor.Kind == MailType.EMAIL_BATTLE)
						{
							this.DM.BattleReportRead(this.Report.SerialID, false);
						}
						else
						{
							this.DM.FavorReportRead(this.Report.SerialID, false);
						}
					}
					this.IsAttack = (this.Report.Pet.Side == 0);
					this.SetFSInfo();
					break;
				}
				break;
			case MailType.EMAIL_LETTER:
				this.DM.OpenMail.Serial = this.Favor.Serial;
				this.DM.OpenMail.Type = this.Favor.Type;
				this.DM.OpenMail.Kind = this.Favor.Kind;
				this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
				break;
			}
		}
	}

	// Token: 0x06001EED RID: 7917 RVA: 0x003B5A30 File Offset: 0x003B3C30
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Mailbox)
			{
				if (networkNews != NetworkNews.Refresh_Mailing)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						this.Refresh_FontTexture();
					}
				}
				else
				{
					if (!this.DM.MailReportGet(ref this.Favor))
					{
						this.door.CloseMenu(false);
						return;
					}
					this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
					this.Cstr_Page.ClearString();
					switch (this.DM.OpenMail.Kind)
					{
					case MailType.EMAIL_BATTLE:
						this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
						this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
						break;
					case MailType.EMAIL_FAVORY:
						this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
						this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
						break;
					}
					if (this.GUIM.IsArabic)
					{
						this.Cstr_Page.AppendFormat("{1}/{0}");
					}
					else
					{
						this.Cstr_Page.AppendFormat("{0}/{1}");
					}
					this.text_Page.text = this.Cstr_Page.ToString();
					this.text_Page.SetAllDirty();
					this.text_Page.cachedTextGenerator.Invalidate();
					if (this.MaxLetterNum > 1)
					{
						if (this.Report.Index + 1 == 1)
						{
							this.btn_Previous.gameObject.SetActive(false);
						}
						else
						{
							this.btn_Previous.gameObject.SetActive(true);
						}
						if ((int)(this.Report.Index + 1) == this.MaxLetterNum)
						{
							this.btn_Next.gameObject.SetActive(false);
						}
						else
						{
							this.btn_Next.gameObject.SetActive(true);
						}
					}
					else
					{
						this.btn_Previous.gameObject.SetActive(false);
						this.btn_Next.gameObject.SetActive(false);
					}
				}
			}
			else if (!this.DM.MailReportGet(ref this.Favor))
			{
				this.door.CloseMenu(false);
				return;
			}
			break;
		}
	}

	// Token: 0x06001EEE RID: 7918 RVA: 0x003B5C98 File Offset: 0x003B3E98
	public void Refresh_FontTexture()
	{
		if (this.text_Coordinate != null && this.text_Coordinate.enabled)
		{
			this.text_Coordinate.enabled = false;
			this.text_Coordinate.enabled = true;
		}
		if (this.text_TitleName != null && this.text_TitleName.enabled)
		{
			this.text_TitleName.enabled = false;
			this.text_TitleName.enabled = true;
		}
		if (this.text_Page != null && this.text_Page.enabled)
		{
			this.text_Page.enabled = false;
			this.text_Page.enabled = true;
		}
		if (this.text_Summary != null && this.text_Summary.enabled)
		{
			this.text_Summary.enabled = false;
			this.text_Summary.enabled = true;
		}
		if (this.text_PetSkillTitle != null && this.text_PetSkillTitle.enabled)
		{
			this.text_PetSkillTitle.enabled = false;
			this.text_PetSkillTitle.enabled = true;
		}
		if (this.text_PetName != null && this.text_PetName.enabled)
		{
			this.text_PetName.enabled = false;
			this.text_PetName.enabled = true;
		}
		if (this.text_PetSkillLv != null && this.text_PetSkillLv.enabled)
		{
			this.text_PetSkillLv.enabled = false;
			this.text_PetSkillLv.enabled = true;
		}
		if (this.text_PetSkillInfo != null && this.text_PetSkillInfo.enabled)
		{
			this.text_PetSkillInfo.enabled = false;
			this.text_PetSkillInfo.enabled = true;
		}
		if (this.text_PetLoss != null && this.text_PetLoss.enabled)
		{
			this.text_PetLoss.enabled = false;
			this.text_PetLoss.enabled = true;
		}
		if (this.text_FailurePetName != null && this.text_FailurePetName.enabled)
		{
			this.text_FailurePetName.enabled = false;
			this.text_FailurePetName.enabled = true;
		}
		if (this.text_FailurePetSkillLv != null && this.text_FailurePetSkillLv.enabled)
		{
			this.text_FailurePetSkillLv.enabled = false;
			this.text_FailurePetSkillLv.enabled = true;
		}
		if (this.text_FailurePetSkillInfo != null && this.text_FailurePetSkillInfo.enabled)
		{
			this.text_FailurePetSkillInfo.enabled = false;
			this.text_FailurePetSkillInfo.enabled = true;
		}
		if (this.text_tmpStr != null && this.text_tmpStr.enabled)
		{
			this.text_tmpStr.enabled = false;
			this.text_tmpStr.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_Time[i] != null && this.text_Time[i].enabled)
			{
				this.text_Time[i].enabled = false;
				this.text_Time[i].enabled = true;
			}
			if (this.text_Offensive[i] != null && this.text_Offensive[i].enabled)
			{
				this.text_Offensive[i].enabled = false;
				this.text_Offensive[i].enabled = true;
			}
			if (this.text_MainHero_F[i] != null && this.text_MainHero_F[i].enabled)
			{
				this.text_MainHero_F[i].enabled = false;
				this.text_MainHero_F[i].enabled = true;
			}
			if (this.text_Dominance[i] != null && this.text_Dominance[i].enabled)
			{
				this.text_Dominance[i].enabled = false;
				this.text_Dominance[i].enabled = true;
			}
			if (this.text_Country[i] != null && this.text_Country[i].enabled)
			{
				this.text_Country[i].enabled = false;
				this.text_Country[i].enabled = true;
			}
			if (this.text_Vip[i] != null && this.text_Vip[i].enabled)
			{
				this.text_Vip[i].enabled = false;
				this.text_Vip[i].enabled = true;
			}
			if (this.text_CoordinateMainHero[i] != null && this.text_CoordinateMainHero[i].enabled)
			{
				this.text_CoordinateMainHero[i].enabled = false;
				this.text_CoordinateMainHero[i].enabled = true;
			}
			if (this.text_Name[i] != null && this.text_Name[i].enabled)
			{
				this.text_Name[i].enabled = false;
				this.text_Name[i].enabled = true;
			}
			if (this.text_PetWall[i] != null && this.text_PetWall[i].enabled)
			{
				this.text_PetWall[i].enabled = false;
				this.text_PetWall[i].enabled = true;
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (this.text_PetBeAttacked[j] != null && this.text_PetBeAttacked[j].enabled)
			{
				this.text_PetBeAttacked[j].enabled = false;
				this.text_PetBeAttacked[j].enabled = true;
			}
		}
		for (int k = 0; k < 5; k++)
		{
			if (this.text_PetAttack[k] != null && this.text_PetAttack[k].enabled)
			{
				this.text_PetAttack[k].enabled = false;
				this.text_PetAttack[k].enabled = true;
			}
			if (this.text_PetResources[k] != null && this.text_PetResources[k].enabled)
			{
				this.text_PetResources[k].enabled = false;
				this.text_PetResources[k].enabled = true;
			}
		}
		for (int l = 0; l < 16; l++)
		{
			if (this.text_Soldier_Rank[l] != null && this.text_Soldier_Rank[l].enabled)
			{
				this.text_Soldier_Rank[l].enabled = false;
				this.text_Soldier_Rank[l].enabled = true;
			}
			if (this.text_Soldier_Name[l] != null && this.text_Soldier_Name[l].enabled)
			{
				this.text_Soldier_Name[l].enabled = false;
				this.text_Soldier_Name[l].enabled = true;
			}
			if (this.text_Soldier_Hurt[l] != null && this.text_Soldier_Hurt[l].enabled)
			{
				this.text_Soldier_Hurt[l].enabled = false;
				this.text_Soldier_Hurt[l].enabled = true;
			}
			if (this.text_Soldier_Death[l] != null && this.text_Soldier_Death[l].enabled)
			{
				this.text_Soldier_Death[l].enabled = false;
				this.text_Soldier_Death[l].enabled = true;
			}
		}
		if (this.btn_Pet != null && this.btn_Pet.enabled)
		{
			this.btn_Pet.Refresh_FontTexture();
		}
	}

	// Token: 0x06001EEF RID: 7919 RVA: 0x003B6410 File Offset: 0x003B4610
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 1)
		{
			if (arg1 == 2)
			{
				if (!this.DM.MailReportGet(ref this.Favor))
				{
					this.door.CloseMenu(false);
				}
			}
		}
	}

	// Token: 0x06001EF0 RID: 7920 RVA: 0x003B6460 File Offset: 0x003B4660
	public override void UpdateTime(bool bOnSecond)
	{
		this.TmpTime += Time.smoothDeltaTime * 40f;
		if (this.TmpTime >= 40f)
		{
			this.TmpTime = 0f;
		}
		float num = (this.TmpTime <= 20f) ? this.TmpTime : (40f - this.TmpTime);
		if (num < 0f)
		{
			num = 0f;
		}
		if (this.NextT != null)
		{
			this.Vec3Instance.Set(this.MoveTime1 - num, this.NextT.localPosition.y, this.NextT.localPosition.z);
			this.NextT.localPosition = this.Vec3Instance;
		}
		if (this.PreviousT != null)
		{
			this.Vec3Instance.Set(this.MoveTime2 + num, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
			this.PreviousT.localPosition = this.Vec3Instance;
		}
		if (this.LightT1 != null)
		{
			this.LightT1.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		if (this.LightT2 != null)
		{
			this.LightT2.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		this.ShowVsTime += Time.smoothDeltaTime;
		if (this.ShowVsTime >= 0f)
		{
			if (this.ShowVsTime >= 2f)
			{
				this.ShowVsTime = 0f;
			}
			float a = (this.ShowVsTime <= 1f) ? this.ShowVsTime : (2f - this.ShowVsTime);
			if (this.Img_Vs != null)
			{
				this.Img_Vs.color = new Color(1f, 1f, 1f, a);
			}
		}
	}

	// Token: 0x06001EF1 RID: 7921 RVA: 0x003B6694 File Offset: 0x003B4894
	public override void OnClose()
	{
		if (this.Cstr_TitleName != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_TitleName);
		}
		if (this.Cstr_Page != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Page);
		}
		if (this.Cstr_Text != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Text);
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.Cstr_Coordinate[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Coordinate[i]);
			}
			if (this.Cstr_Offensive[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Offensive[i]);
			}
			if (this.Cstr_Dominance[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Dominance[i]);
			}
			if (this.Cstr_Country[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Country[i]);
			}
			if (this.Cstr_CoordinateMainHero[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_CoordinateMainHero[i]);
			}
			if (this.Cstr_Name[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Name[i]);
			}
		}
		if (this.Cstr_PetSkillLv != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_PetSkillLv);
		}
		if (this.Cstr_PetSkillInfo != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_PetSkillInfo);
		}
		if (this.Cstr_PetWall != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_PetWall);
		}
		for (int j = 0; j < 3; j++)
		{
			if (this.Cstr_PetAttack[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_PetAttack[j]);
			}
		}
		for (int k = 0; k < 17; k++)
		{
			if (this.Cstr_PetBeAttacked[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_PetBeAttacked[k]);
			}
		}
		for (int l = 0; l < 5; l++)
		{
			if (this.Cstr_PetResources[l] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_PetResources[l]);
			}
		}
		for (int m = 0; m < 16; m++)
		{
			if (this.Cstr_Soldier_Hurt[m] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Soldier_Hurt[m]);
			}
			if (this.Cstr_Soldier_Death[m] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Soldier_Death[m]);
			}
		}
		if (this.bSaveY)
		{
			this.DM.LetterFs_Y = this.ContentRT.anchoredPosition.y;
			this.DM.mFs_Serial = this.Favor.Serial;
		}
		else
		{
			this.DM.LetterFs_Y = -1f;
		}
	}

	// Token: 0x06001EF2 RID: 7922 RVA: 0x003B6964 File Offset: 0x003B4B64
	private void SetPorfileBtn()
	{
		int num;
		int num2;
		if (this.IsAttack)
		{
			num = 0;
			num2 = 3;
		}
		else
		{
			num = 3;
			num2 = 0;
		}
		if (this.Img_MainHero != null && this.Img_MainHero[num] != null && this.Img_MainHero[num].transform.GetChild(0) != null)
		{
			UIButton component = this.Img_MainHero[num].transform.GetChild(0).gameObject.GetComponent<UIButton>();
			if (component != null)
			{
				component.m_Handler = this;
				component.m_BtnID1 = ((num != 0) ? 9 : 8);
				component.m_EffectType = e_EffectType.e_Scale;
				component.transition = Selectable.Transition.None;
			}
		}
		if (this.Img_MainHero != null && this.Img_MainHero[num2] != null && this.Img_MainHero[num2].transform.GetChild(0) != null)
		{
			UIButton component = this.Img_MainHero[num2].transform.GetChild(0).gameObject.GetComponent<UIButton>();
			if (component != null)
			{
				component.m_Handler = this;
				component.m_BtnID1 = ((num2 != 0) ? 9 : 8);
				component.m_EffectType = e_EffectType.e_Scale;
				component.transition = Selectable.Transition.None;
			}
		}
	}

	// Token: 0x06001EF3 RID: 7923 RVA: 0x003B6AAC File Offset: 0x003B4CAC
	private void ShowLordProfile(PetSkill_FS_btn type)
	{
		this.DM.PlayerName_War[0].Append(this.Report.Pet.AssaultName);
		this.DM.PlayerName_War[1].Append(this.Report.Pet.DefenceName);
		if (type == PetSkill_FS_btn.btn_Porfile_Def)
		{
			if (this.Report != null && this.Report.Pet != null && this.Report.Pet.DefenceName != null && this.Report.Pet.DefenceName != string.Empty)
			{
				this.bSaveY = true;
				DataManager.Instance.ShowLordProfile(this.Report.Pet.DefenceName);
			}
		}
		else if (type == PetSkill_FS_btn.btn_Porfile_Atk && this.Report != null && this.Report.Pet != null && this.Report.Pet.AssaultName != null && this.Report.Pet.AssaultName != string.Empty)
		{
			this.bSaveY = true;
			DataManager.Instance.ShowLordProfile(this.Report.Pet.AssaultName);
		}
	}

	// Token: 0x06001EF4 RID: 7924 RVA: 0x003B6BF4 File Offset: 0x003B4DF4
	private void Start()
	{
	}

	// Token: 0x06001EF5 RID: 7925 RVA: 0x003B6BF8 File Offset: 0x003B4DF8
	private void Update()
	{
	}

	// Token: 0x040061E6 RID: 25062
	private Transform GameT;

	// Token: 0x040061E7 RID: 25063
	private Transform Tmp;

	// Token: 0x040061E8 RID: 25064
	private Transform Tmp1;

	// Token: 0x040061E9 RID: 25065
	private Transform Tmp2;

	// Token: 0x040061EA RID: 25066
	private Transform LightT1;

	// Token: 0x040061EB RID: 25067
	private Transform LightT2;

	// Token: 0x040061EC RID: 25068
	private Transform PreviousT;

	// Token: 0x040061ED RID: 25069
	private Transform NextT;

	// Token: 0x040061EE RID: 25070
	private Transform Mask_T;

	// Token: 0x040061EF RID: 25071
	private Transform[] Soldier_T = new Transform[16];

	// Token: 0x040061F0 RID: 25072
	private RectTransform tmpRC;

	// Token: 0x040061F1 RID: 25073
	private RectTransform ContentRT;

	// Token: 0x040061F2 RID: 25074
	private RectTransform SummaryRT;

	// Token: 0x040061F3 RID: 25075
	private RectTransform FailureRT;

	// Token: 0x040061F4 RID: 25076
	private RectTransform Pet_BGRT;

	// Token: 0x040061F5 RID: 25077
	private RectTransform Pet_InfoRT;

	// Token: 0x040061F6 RID: 25078
	private RectTransform Pet_WallRT;

	// Token: 0x040061F7 RID: 25079
	private RectTransform Pet_AttackRT;

	// Token: 0x040061F8 RID: 25080
	private RectTransform Pet_BeAttackedRT;

	// Token: 0x040061F9 RID: 25081
	private RectTransform Pet_ResourcesRT;

	// Token: 0x040061FA RID: 25082
	private RectTransform[] Pet_btnSoldierRT = new RectTransform[16];

	// Token: 0x040061FB RID: 25083
	private UIButton btn_EXIT;

	// Token: 0x040061FC RID: 25084
	private UIButton btn_Previous;

	// Token: 0x040061FD RID: 25085
	private UIButton btn_Next;

	// Token: 0x040061FE RID: 25086
	private UIButton btn_Title;

	// Token: 0x040061FF RID: 25087
	private UIButton btn_Delete;

	// Token: 0x04006200 RID: 25088
	private UIButton btn_Collect;

	// Token: 0x04006201 RID: 25089
	private UIButton[] btn_Coordinate = new UIButton[2];

	// Token: 0x04006202 RID: 25090
	private UIButtonHint[] Hbtn_Hint = new UIButtonHint[16];

	// Token: 0x04006203 RID: 25091
	private UIHIBtn btn_Pet;

	// Token: 0x04006204 RID: 25092
	private UIHIBtn btn_Pet_Failure;

	// Token: 0x04006205 RID: 25093
	private Image Img_Quanmie;

	// Token: 0x04006206 RID: 25094
	private Image Img_Vs;

	// Token: 0x04006207 RID: 25095
	private Image[] Img_MainHero = new Image[6];

	// Token: 0x04006208 RID: 25096
	private Image[] Img_Summarybg = new Image[2];

	// Token: 0x04006209 RID: 25097
	private Image[] Img_MainTitle = new Image[2];

	// Token: 0x0400620A RID: 25098
	private Image[] Img_Country = new Image[2];

	// Token: 0x0400620B RID: 25099
	private Image[] Img_Rank = new Image[2];

	// Token: 0x0400620C RID: 25100
	private Image[] Img_Vip = new Image[2];

	// Token: 0x0400620D RID: 25101
	private Image[] Img_Soldier = new Image[16];

	// Token: 0x0400620E RID: 25102
	private UIText text_Coordinate;

	// Token: 0x0400620F RID: 25103
	private UIText text_TitleName;

	// Token: 0x04006210 RID: 25104
	private UIText text_Page;

	// Token: 0x04006211 RID: 25105
	private UIText text_Summary;

	// Token: 0x04006212 RID: 25106
	private UIText text_PetSkillTitle;

	// Token: 0x04006213 RID: 25107
	private UIText text_PetName;

	// Token: 0x04006214 RID: 25108
	private UIText text_PetSkillLv;

	// Token: 0x04006215 RID: 25109
	private UIText text_PetSkillInfo;

	// Token: 0x04006216 RID: 25110
	private UIText text_PetLoss;

	// Token: 0x04006217 RID: 25111
	private UIText text_FailurePetName;

	// Token: 0x04006218 RID: 25112
	private UIText text_FailurePetSkillLv;

	// Token: 0x04006219 RID: 25113
	private UIText text_FailurePetSkillInfo;

	// Token: 0x0400621A RID: 25114
	private UIText[] text_Time = new UIText[2];

	// Token: 0x0400621B RID: 25115
	private UIText[] text_Offensive = new UIText[2];

	// Token: 0x0400621C RID: 25116
	private UIText[] text_MainHero_F = new UIText[2];

	// Token: 0x0400621D RID: 25117
	private UIText[] text_Dominance = new UIText[2];

	// Token: 0x0400621E RID: 25118
	private UIText[] text_Country = new UIText[2];

	// Token: 0x0400621F RID: 25119
	private UIText[] text_Vip = new UIText[2];

	// Token: 0x04006220 RID: 25120
	private UIText[] text_CoordinateMainHero = new UIText[2];

	// Token: 0x04006221 RID: 25121
	private UIText[] text_Name = new UIText[2];

	// Token: 0x04006222 RID: 25122
	private UIText[] text_PetWall = new UIText[2];

	// Token: 0x04006223 RID: 25123
	private UIText[] text_PetAttack = new UIText[5];

	// Token: 0x04006224 RID: 25124
	private UIText[] text_PetBeAttacked = new UIText[4];

	// Token: 0x04006225 RID: 25125
	private UIText[] text_PetResources = new UIText[5];

	// Token: 0x04006226 RID: 25126
	private UIText[] text_Soldier_Rank = new UIText[16];

	// Token: 0x04006227 RID: 25127
	private UIText[] text_Soldier_Name = new UIText[16];

	// Token: 0x04006228 RID: 25128
	private UIText[] text_Soldier_Hurt = new UIText[16];

	// Token: 0x04006229 RID: 25129
	private UIText[] text_Soldier_Death = new UIText[16];

	// Token: 0x0400622A RID: 25130
	private UIText text_tmpStr;

	// Token: 0x0400622B RID: 25131
	private CScrollRect m_Mask;

	// Token: 0x0400622C RID: 25132
	private CString[] Cstr_Coordinate = new CString[2];

	// Token: 0x0400622D RID: 25133
	private CString Cstr_TitleName;

	// Token: 0x0400622E RID: 25134
	private CString Cstr_Page;

	// Token: 0x0400622F RID: 25135
	private CString Cstr_Text;

	// Token: 0x04006230 RID: 25136
	private CString[] Cstr_Offensive = new CString[2];

	// Token: 0x04006231 RID: 25137
	private CString[] Cstr_Dominance = new CString[2];

	// Token: 0x04006232 RID: 25138
	private CString[] Cstr_Country = new CString[2];

	// Token: 0x04006233 RID: 25139
	private CString[] Cstr_CoordinateMainHero = new CString[2];

	// Token: 0x04006234 RID: 25140
	private CString[] Cstr_Name = new CString[2];

	// Token: 0x04006235 RID: 25141
	private CString Cstr_PetSkillLv;

	// Token: 0x04006236 RID: 25142
	private CString Cstr_PetSkillInfo;

	// Token: 0x04006237 RID: 25143
	private CString Cstr_PetWall;

	// Token: 0x04006238 RID: 25144
	private CString[] Cstr_PetAttack = new CString[3];

	// Token: 0x04006239 RID: 25145
	private CString[] Cstr_PetBeAttacked = new CString[17];

	// Token: 0x0400623A RID: 25146
	private CString[] Cstr_PetResources = new CString[5];

	// Token: 0x0400623B RID: 25147
	private CString[] Cstr_Soldier_Hurt = new CString[16];

	// Token: 0x0400623C RID: 25148
	private CString[] Cstr_Soldier_Death = new CString[16];

	// Token: 0x0400623D RID: 25149
	private DataManager DM;

	// Token: 0x0400623E RID: 25150
	private GUIManager GUIM;

	// Token: 0x0400623F RID: 25151
	private PetManager PM;

	// Token: 0x04006240 RID: 25152
	private Font TTFont;

	// Token: 0x04006241 RID: 25153
	private Door door;

	// Token: 0x04006242 RID: 25154
	private UISpritesArray SArray;

	// Token: 0x04006243 RID: 25155
	private Material mMaT;

	// Token: 0x04006244 RID: 25156
	private Material IconMaterial;

	// Token: 0x04006245 RID: 25157
	private Material FrameMaterial;

	// Token: 0x04006246 RID: 25158
	private CombatReport Report;

	// Token: 0x04006247 RID: 25159
	private MyFavorite Favor = new MyFavorite(MailType.EMAIL_MAX, 0u);

	// Token: 0x04006248 RID: 25160
	private bool bWin = true;

	// Token: 0x04006249 RID: 25161
	private bool IsAttack = true;

	// Token: 0x0400624A RID: 25162
	private int MaxLetterNum;

	// Token: 0x0400624B RID: 25163
	private float tempL;

	// Token: 0x0400624C RID: 25164
	private float MoveTime1;

	// Token: 0x0400624D RID: 25165
	private float MoveTime2;

	// Token: 0x0400624E RID: 25166
	private float TmpTime;

	// Token: 0x0400624F RID: 25167
	private float ShowVsTime;

	// Token: 0x04006250 RID: 25168
	private Vector3 Vec3Instance = Vector3.zero;

	// Token: 0x04006251 RID: 25169
	private bool bSaveY;

	// Token: 0x04006252 RID: 25170
	private float tmpH;

	// Token: 0x04006253 RID: 25171
	private Hero tmpHero;

	// Token: 0x04006254 RID: 25172
	private Vector2 tmpV;

	// Token: 0x04006255 RID: 25173
	private PetTbl tmpPT;

	// Token: 0x04006256 RID: 25174
	private PetSkillTbl skill;
}
