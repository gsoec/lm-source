using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000306 RID: 774
public class Rally_Attack : Rally
{
	// Token: 0x06000FB7 RID: 4023 RVA: 0x001B7470 File Offset: 0x001B5670
	public Rally_Attack(Transform transform, int DataIndex) : base(transform, DataIndex)
	{
	}

	// Token: 0x06000FB8 RID: 4024 RVA: 0x001B747C File Offset: 0x001B567C
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		base.OnOpen(arg1, arg2);
		this.bShowAttackbtn = ((arg2 & 32768) > 0);
		this.TitleText.color = new Color(1f, 0.631f, 0.671f);
		this.TitleText.text = instance.mStringTable.GetStringByID(4873u);
		this.LeftText.text = instance.mStringTable.GetStringByID(4880u);
		this.LeftCancelText.text = instance.mStringTable.GetStringByID(4882u);
		this.LeftCancelImg.sprite = this.SPriteArray.GetSprite(5);
		this.TopBar.gameObject.SetActive(false);
		this.LeftBar.gameObject.SetActive(false);
		this.TopAttackIcon.SetActive(false);
		this.LeftTargetIcon.SetActive(false);
		this.RightFlagDefense.enabled = false;
		this.RallyTitleStr = instance.mStringTable.GetStringByID(4883u);
	}

	// Token: 0x06000FB9 RID: 4025 RVA: 0x001B7594 File Offset: 0x001B5794
	public override void Init()
	{
		base.Init();
	}

	// Token: 0x06000FBA RID: 4026 RVA: 0x001B759C File Offset: 0x001B579C
	public override void UpdateUI(int arg1, int arg2)
	{
		base.UpdateUI(arg1, arg2);
		if (arg1 == 1)
		{
			base.CloseMenuCheck();
			return;
		}
		this.UpdateRallyData();
	}

	// Token: 0x06000FBB RID: 4027 RVA: 0x001B75BC File Offset: 0x001B57BC
	public override void UpdateRallyData()
	{
		DataManager instance = DataManager.Instance;
		WarlobbyData warlobbyDetail = instance.WarlobbyDetail;
		if (warlobbyDetail == null)
		{
			return;
		}
		if (warlobbyDetail.WonderID != 255)
		{
			this.UpdateRallyWonderAttack(ref warlobbyDetail);
		}
		else if (warlobbyDetail.EnemyHead != 255)
		{
			this.UpdateRallyAttack(ref warlobbyDetail);
		}
		else
		{
			this.UpdateNPCRallyAttack(ref warlobbyDetail);
		}
	}

	// Token: 0x06000FBC RID: 4028 RVA: 0x001B7620 File Offset: 0x001B5820
	private void UpdateRallyAttack(ref WarlobbyData Data)
	{
		DataManager instance = DataManager.Instance;
		this.TopText.text = instance.mStringTable.GetStringByID(4879u);
		Data.AttackOrDefense = 0;
		GUIManager.Instance.ChangeHeroItemImg(this.TopHero, eHeroOrItem.Hero, Data.EnemyHead, 11, 0, 0);
		if (Data.EnemyHead > 0)
		{
			this.TopHero.gameObject.SetActive(true);
		}
		if (Data.EnemyHomeKingdom == 0 || DataManager.MapDataController.kingdomData.kingdomID == Data.EnemyHomeKingdom)
		{
			this.TopCountry.SetActive(false);
		}
		else
		{
			this.TopCountry.SetActive(true);
			base.SetText(Rally.TextType.TopCountry, (int)Data.EnemyHomeKingdom, null, 0, null, 0);
		}
		base.SetText(Rally.TextType.TopName, 0, Data.EnemyName, 0, Data.EnemyAllianceTag, Data.EnemyHomeKingdom);
		if (Data.AllyNameID != 0)
		{
			this.LeftBar.gameObject.SetActive(true);
			this.LeftBar.SetTimebar(base.GetTroopKind(), Data.EventTime.BeginTime, Data.EventTime.BeginTime + (long)((ulong)Data.EventTime.RequireTime), 0L);
		}
		GUIManager.Instance.ChangeHeroItemImg(this.LeftHero, eHeroOrItem.Hero, Data.AllyHead, 11, 0, 0);
		if (Data.AllyHead > 0)
		{
			this.LeftHero.gameObject.SetActive(true);
		}
		base.SetText(Rally.TextType.LeftName, 0, Data.AllyName, 0, null, 0);
		this.TopHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(Data.EnemyCapitalPoint.zoneID, Data.EnemyCapitalPoint.pointID);
		this.TopHeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.LeftHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(Data.AllyCapitalPoint.zoneID, Data.AllyCapitalPoint.pointID);
		this.LeftHeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.TopUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(Data.EnemyCapitalPoint.zoneID, Data.EnemyCapitalPoint.pointID);
		this.TopUnderLineBtn.m_BtnID3 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.LeftUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(Data.AllyCapitalPoint.zoneID, Data.AllyCapitalPoint.pointID);
		this.LeftUnderLineBtn.m_BtnID3 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		Vector2 sizeDelta = this.TopUnderLine.sizeDelta;
		sizeDelta.x = Math.Min(this.TopNameText.preferredWidth, 362f);
		this.TopUnderLine.sizeDelta = sizeDelta;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform rectTransform = this.TopUnderLine.transform as RectTransform;
			rectTransform.anchoredPosition = new Vector2(this.TopNameText.rectTransform.sizeDelta.x - this.TopNameText.preferredWidth, rectTransform.anchoredPosition.y);
		}
		this.TopUnderLine.gameObject.SetActive(true);
		sizeDelta = this.LeftUnderLine.sizeDelta;
		if (this.LeftNameText.preferredWidth > 245f)
		{
			this.LeftNameText.fontSize = 19;
			this.LeftNameText.SetAllDirty();
			this.LeftNameText.cachedTextGeneratorForLayout.Invalidate();
		}
		sizeDelta.x = Math.Min(this.LeftNameText.preferredWidth, 245f);
		this.LeftUnderLine.sizeDelta = sizeDelta;
		this.LeftUnderLine.gameObject.SetActive(true);
		int num = this.ItemsHeight.Count - instance.WarTroop.Count;
		if (num < 0)
		{
			short num2 = 0;
			while ((int)num2 > num)
			{
				this.ItemsHeight.Add(80f);
				this.ItemsExtend.Add(0);
				num2 -= 1;
			}
		}
		else if (num > 0)
		{
			if (WarlobbyTroop.DelIndex != 255 && (int)WarlobbyTroop.DelIndex < this.ItemsExtend.Count)
			{
				this.ItemsHeight.RemoveAt((int)WarlobbyTroop.DelIndex);
				this.ItemsExtend.RemoveAt((int)WarlobbyTroop.DelIndex);
				WarlobbyTroop.DelIndex = byte.MaxValue;
				num--;
			}
			byte b = 0;
			while ((int)b < num)
			{
				this.ItemsHeight.RemoveAt(0);
				this.ItemsExtend.RemoveAt(0);
				b += 1;
			}
		}
		bool flag = false;
		if (Data.EventTime.BeginTime + (long)((ulong)Data.EventTime.RequireTime) < instance.ServerTime)
		{
			flag = true;
		}
		if (Data.Kind == 1)
		{
			this.LeftBar.transform.anchoredPosition = new Vector2(-6.6f, this.LeftBar.transform.anchoredPosition.y);
			this.RallySpeedupBtn.gameObject.SetActive(true);
		}
		else
		{
			this.LeftBar.transform.anchoredPosition = new Vector2(17.2f, this.LeftBar.transform.anchoredPosition.y);
			this.RallySpeedupBtn.gameObject.SetActive(false);
		}
		int hashCode = instance.RoleAttr.Name.GetHashCode(false);
		if (Data.AllyNameID == 0)
		{
			this.LeftCancelImg.gameObject.SetActive(false);
			this.LeftJoinImg.gameObject.SetActive(false);
		}
		else if (hashCode == Data.AllyNameID || this.bShowAttackbtn)
		{
			this.LeftCancelImg.gameObject.SetActive(true);
			this.FilterBtn.gameObject.SetActive(true);
			this.LeftJoinImg.gameObject.SetActive(false);
			this.LeftCancelImg.rectTransform.anchoredPosition = new Vector2(131.5f, -319.5f);
		}
		else
		{
			this.LeftCancelImg.gameObject.SetActive(false);
			this.FilterBtn.gameObject.SetActive(false);
			if (!flag && Data.Kind == 0)
			{
				CString cstring = StringManager.Instance.StaticString1024();
				bool flag2 = false;
				for (byte b2 = 0; b2 < instance.MaxMarchEventNum; b2 += 1)
				{
					if (instance.MarchEventData[(int)b2].Type == EMarchEventType.EMET_RallyMarching || instance.MarchEventData[(int)b2].Type == EMarchEventType.EMET_RallyStanby)
					{
						cstring.ClearString();
						cstring.Append(instance.MarchEventData[(int)b2].DesPlayerName);
						if (cstring.GetHashCode(false) == Data.AllyNameID)
						{
							flag2 = true;
							break;
						}
					}
				}
				if (!flag2)
				{
					this.LeftJoinText.text = instance.mStringTable.GetStringByID(4884u);
					this.LeftJoinText.color = Color.white;
					this.JoinBtn.enabled = true;
				}
				else
				{
					this.LeftJoinText.text = instance.mStringTable.GetStringByID(4913u);
					this.LeftJoinText.color = Color.red;
					this.JoinBtn.enabled = false;
				}
				this.LeftJoinImg.gameObject.SetActive(true);
			}
			else
			{
				this.LeftJoinImg.gameObject.SetActive(false);
			}
		}
		if (this.ItemsHeight.Count > 0)
		{
			this.RightMessage.gameObject.SetActive(false);
			this.RallyScroll.gameObject.SetActive(true);
			this.RallyScroll.AddNewDataHeight(this.ItemsHeight, true, true);
			this.RallyScroll.GoTo(this.LoadBeginIndex, this.LoadContY);
		}
		else
		{
			this.RightMessage.gameObject.SetActive(true);
			this.RallyScroll.gameObject.SetActive(false);
		}
		Data.AllyCurrTroop = 0u;
		for (int i = 0; i < instance.WarTroop.Count; i++)
		{
			if (instance.WarTroop[i] != null)
			{
				Data.AllyCurrTroop += instance.WarTroop[i].TotalTroopNum;
			}
		}
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring2.StringToFormat(instance.mStringTable.GetStringByID(4889u));
		cstring2.AppendFormat("{0} : ");
		base.SetText(Rally.TextType.RightTitle, (int)Data.AllyCurrTroop, cstring2, (int)Data.AllyMAXTroop, null, 0);
		this.ArmyStatisticHint.Show(null);
	}

	// Token: 0x06000FBD RID: 4029 RVA: 0x001B7ED4 File Offset: 0x001B60D4
	private void UpdateRallyWonderAttack(ref WarlobbyData Data)
	{
		DataManager instance = DataManager.Instance;
		this.TopTextStr.ClearString();
		if (Data.WonderID > 0 && DataManager.MapDataController.OtherKingdomData.kingdomID != ActivityManager.Instance.KOWKingdomID)
		{
			this.TopTextStr.StringToFormat(instance.mStringTable.GetStringByID(9309u));
		}
		else
		{
			this.TopTextStr.StringToFormat(instance.mStringTable.GetStringByID(9308u));
		}
		this.TopTextStr.AppendFormat(instance.mStringTable.GetStringByID(8555u));
		this.TopText.text = this.TopTextStr.ToString();
		this.TopText.SetAllDirty();
		this.TopText.cachedTextGenerator.Invalidate();
		Data.AttackOrDefense = 0;
		if (ActivityManager.Instance.IsInKvK(0, false) && Data.EnemyHomeKingdom == 0)
		{
			Data.EnemyHomeKingdom = DataManager.MapDataController.OtherKingdomData.kingdomID;
		}
		if (DataManager.MapDataController.OtherKingdomData.kingdomID == ActivityManager.Instance.KOWKingdomID)
		{
			GUIManager.Instance.ChangeWonderImg(this.TopHero, Data.WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID);
		}
		else
		{
			GUIManager.Instance.ChangeWonderImg(this.TopHero, Data.WonderID, Data.EnemyHomeKingdom);
		}
		this.TopHero.gameObject.SetActive(true);
		base.SetText(Rally.TextType.TopName, 0, Data.EnemyName, 0, Data.EnemyAllianceTag, Data.EnemyHomeKingdom);
		if (Data.AllyNameID != 0)
		{
			this.LeftBar.gameObject.SetActive(true);
			this.LeftBar.SetTimebar(base.GetTroopKind(), Data.EventTime.BeginTime, Data.EventTime.BeginTime + (long)((ulong)Data.EventTime.RequireTime), 0L);
		}
		GUIManager.Instance.ChangeHeroItemImg(this.LeftHero, eHeroOrItem.Hero, Data.AllyHead, 11, 0, 0);
		if (Data.AllyHead > 0)
		{
			this.LeftHero.gameObject.SetActive(true);
		}
		base.SetText(Rally.TextType.LeftName, 0, Data.AllyName, 0, null, 0);
		this.TopHeroBtn.m_BtnID1 = (int)DataManager.MapDataController.GetYolkMapID((ushort)Data.WonderID, 0);
		this.TopHeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.LeftHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(Data.AllyCapitalPoint.zoneID, Data.AllyCapitalPoint.pointID);
		this.LeftHeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.TopUnderLineBtn.m_BtnID2 = (int)DataManager.MapDataController.GetYolkMapID((ushort)Data.WonderID, 0);
		this.TopUnderLineBtn.m_BtnID3 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.LeftUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(Data.AllyCapitalPoint.zoneID, Data.AllyCapitalPoint.pointID);
		this.LeftUnderLineBtn.m_BtnID3 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		Vector2 sizeDelta = this.TopUnderLine.sizeDelta;
		sizeDelta.x = Math.Min(this.TopNameText.preferredWidth, 362f);
		this.TopUnderLine.sizeDelta = sizeDelta;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform rectTransform = this.TopUnderLine.transform as RectTransform;
			rectTransform.anchoredPosition = new Vector2(this.TopNameText.rectTransform.sizeDelta.x - this.TopNameText.preferredWidth, rectTransform.anchoredPosition.y);
		}
		this.TopUnderLine.gameObject.SetActive(true);
		sizeDelta = this.LeftUnderLine.sizeDelta;
		if (this.LeftNameText.preferredWidth > 245f)
		{
			this.LeftNameText.fontSize = 19;
			this.LeftNameText.SetAllDirty();
			this.LeftNameText.cachedTextGeneratorForLayout.Invalidate();
		}
		sizeDelta.x = Math.Min(this.LeftNameText.preferredWidth, 245f);
		this.LeftUnderLine.sizeDelta = sizeDelta;
		this.LeftUnderLine.gameObject.SetActive(true);
		if (Data.Kind == 1)
		{
			this.LeftBar.transform.anchoredPosition = new Vector2(-6.6f, this.LeftBar.transform.anchoredPosition.y);
			this.RallySpeedupBtn.gameObject.SetActive(true);
		}
		else
		{
			this.LeftBar.transform.anchoredPosition = new Vector2(17.2f, this.LeftBar.transform.anchoredPosition.y);
			this.RallySpeedupBtn.gameObject.SetActive(false);
		}
		this.TopCountry.SetActive(true);
		base.SetText(Rally.TextType.TopWonders, (int)Data.EnemyHomeKingdom, null, (int)Data.WonderID, null, 0);
		int num = this.ItemsHeight.Count - instance.WarTroop.Count;
		if (num < 0)
		{
			short num2 = 0;
			while ((int)num2 > num)
			{
				this.ItemsHeight.Add(80f);
				this.ItemsExtend.Add(0);
				num2 -= 1;
			}
		}
		else if (num > 0)
		{
			if (WarlobbyTroop.DelIndex != 255 && (int)WarlobbyTroop.DelIndex < this.ItemsExtend.Count)
			{
				this.ItemsHeight.RemoveAt((int)WarlobbyTroop.DelIndex);
				this.ItemsExtend.RemoveAt((int)WarlobbyTroop.DelIndex);
				WarlobbyTroop.DelIndex = byte.MaxValue;
				num--;
			}
			byte b = 0;
			while ((int)b < num)
			{
				this.ItemsHeight.RemoveAt(0);
				this.ItemsExtend.RemoveAt(0);
				b += 1;
			}
		}
		if (Data.AllyNameID == 0)
		{
			this.LeftCancelImg.gameObject.SetActive(false);
			this.LeftJoinImg.gameObject.SetActive(false);
		}
		else if (instance.MaxMarchEventNum > Data.SelfParticipateTroopIndex)
		{
			if (instance.MarchEventData[(int)Data.SelfParticipateTroopIndex].bRallyHost == 1)
			{
				this.LeftJoinImg.gameObject.SetActive(false);
				this.LeftCancelImg.gameObject.SetActive(true);
				this.FilterBtn.gameObject.SetActive(true);
				this.LeftJoinImg.gameObject.SetActive(false);
				this.LeftCancelImg.rectTransform.anchoredPosition = new Vector2(131.5f, -319.5f);
			}
			else if (instance.MarchEventData[(int)Data.SelfParticipateTroopIndex].Type == EMarchEventType.EMET_RallyReturn)
			{
				if (Data.Kind == 0)
				{
					this.LeftJoinImg.gameObject.SetActive(true);
					this.LeftJoinText.text = instance.mStringTable.GetStringByID(4884u);
					this.LeftJoinText.color = Color.white;
					this.JoinBtn.enabled = true;
				}
				else
				{
					this.LeftJoinImg.gameObject.SetActive(false);
				}
			}
			else
			{
				this.LeftJoinImg.gameObject.SetActive(true);
				this.LeftJoinText.text = instance.mStringTable.GetStringByID(4913u);
				this.LeftJoinText.color = Color.red;
				this.JoinBtn.enabled = false;
			}
		}
		else if (Data.Kind == 0)
		{
			this.LeftJoinImg.gameObject.SetActive(true);
			this.LeftJoinText.text = instance.mStringTable.GetStringByID(4884u);
			this.LeftJoinText.color = Color.white;
			this.JoinBtn.enabled = true;
		}
		else
		{
			this.LeftJoinImg.gameObject.SetActive(false);
		}
		this.MemberCombat.gameobject.SetActive(true);
		this.MemberCombat.SetCombatVal(base.GetCombatPower(true));
		this.MemberCombat.UpdateHint();
		this.StaticRect.anchoredPosition = new Vector2(-192.2f, 149.7f);
		if (this.ItemsHeight.Count > 0)
		{
			this.RightMessage.gameObject.SetActive(false);
			this.RallyScroll.gameObject.SetActive(true);
			this.RallyScollRect.sizeDelta = new Vector2(this.RallyScollRect.sizeDelta.x, 306f);
			this.RallyScroll.AddNewDataHeight(this.ItemsHeight, 306f, true);
			this.RallyScroll.GoTo(this.LoadBeginIndex, this.LoadContY);
		}
		else
		{
			this.RightMessage.gameObject.SetActive(true);
			this.RallyScroll.gameObject.SetActive(false);
		}
		Data.AllyCurrTroop = 0u;
		for (int i = 0; i < instance.WarTroop.Count; i++)
		{
			if (instance.WarTroop[i] != null)
			{
				Data.AllyCurrTroop += instance.WarTroop[i].TotalTroopNum;
			}
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(instance.mStringTable.GetStringByID(4889u));
		cstring.AppendFormat("{0} : ");
		base.SetText(Rally.TextType.RightTitle, (int)Data.AllyCurrTroop, cstring, (int)Data.AllyMAXTroop, null, 0);
		this.ArmyStatisticHint.Show(null);
	}

	// Token: 0x06000FBE RID: 4030 RVA: 0x001B888C File Offset: 0x001B6A8C
	private void UpdateNPCRallyAttack(ref WarlobbyData Data)
	{
		this.LeftJoinImg.gameObject.SetActive(false);
		this.LeftCancelImg.gameObject.SetActive(false);
		this.FilterBtn.gameObject.SetActive(false);
		DataManager instance = DataManager.Instance;
		this.JoinBtn.m_BtnID1 = 14;
		this.TopText.text = instance.mStringTable.GetStringByID(4879u);
		Data.AttackOrDefense = 0;
		GUIManager.Instance.ChangeNPCImg(this.TopHero);
		this.TopHero.gameObject.SetActive(true);
		this.TopCountry.SetActive(false);
		base.SetText(Rally.TextType.TopName, 0, Data.EnemyName, 0, Data.EnemyAllianceTag, Data.EnemyHomeKingdom);
		if (Data.AllyNameID != 0)
		{
			this.LeftBar.gameObject.SetActive(true);
			this.LeftBar.SetTimebar(base.GetTroopKind(), Data.EventTime.BeginTime, Data.EventTime.BeginTime + (long)((ulong)Data.EventTime.RequireTime), 0L);
		}
		GUIManager.Instance.ChangeHeroItemImg(this.LeftHero, eHeroOrItem.Hero, Data.AllyHead, 11, 0, 0);
		if (Data.AllyHead > 0)
		{
			this.LeftHero.gameObject.SetActive(true);
		}
		base.SetText(Rally.TextType.LeftName, 0, Data.AllyName, 0, null, 0);
		this.TopHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(Data.EnemyCapitalPoint.zoneID, Data.EnemyCapitalPoint.pointID);
		this.TopHeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.LeftHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(Data.AllyCapitalPoint.zoneID, Data.AllyCapitalPoint.pointID);
		this.LeftHeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.TopUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(Data.EnemyCapitalPoint.zoneID, Data.EnemyCapitalPoint.pointID);
		this.TopUnderLineBtn.m_BtnID3 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.LeftUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(Data.AllyCapitalPoint.zoneID, Data.AllyCapitalPoint.pointID);
		this.LeftUnderLineBtn.m_BtnID3 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		Vector2 sizeDelta = this.TopUnderLine.sizeDelta;
		sizeDelta.x = Math.Min(this.TopNameText.preferredWidth, 362f);
		this.TopUnderLine.sizeDelta = sizeDelta;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform rectTransform = this.TopUnderLine.transform as RectTransform;
			rectTransform.anchoredPosition = new Vector2(this.TopNameText.rectTransform.sizeDelta.x - this.TopNameText.preferredWidth, rectTransform.anchoredPosition.y);
		}
		this.TopUnderLine.gameObject.SetActive(true);
		sizeDelta = this.LeftUnderLine.sizeDelta;
		if (this.LeftNameText.preferredWidth > 245f)
		{
			this.LeftNameText.fontSize = 19;
			this.LeftNameText.SetAllDirty();
			this.LeftNameText.cachedTextGeneratorForLayout.Invalidate();
		}
		sizeDelta.x = Math.Min(this.LeftNameText.preferredWidth, 245f);
		this.LeftUnderLine.sizeDelta = sizeDelta;
		this.LeftUnderLine.gameObject.SetActive(true);
		int num = this.ItemsHeight.Count - instance.WarTroop.Count;
		if (num < 0)
		{
			short num2 = 0;
			while ((int)num2 > num)
			{
				this.ItemsHeight.Add(80f);
				this.ItemsExtend.Add(0);
				num2 -= 1;
			}
		}
		else if (num > 0)
		{
			if (WarlobbyTroop.DelIndex != 255 && (int)WarlobbyTroop.DelIndex < this.ItemsExtend.Count)
			{
				this.ItemsHeight.RemoveAt((int)WarlobbyTroop.DelIndex);
				this.ItemsExtend.RemoveAt((int)WarlobbyTroop.DelIndex);
				WarlobbyTroop.DelIndex = byte.MaxValue;
				num--;
			}
			byte b = 0;
			while ((int)b < num)
			{
				this.ItemsHeight.RemoveAt(0);
				this.ItemsExtend.RemoveAt(0);
				b += 1;
			}
		}
		if (Data.Kind == 1)
		{
			this.LeftBar.transform.anchoredPosition = new Vector2(-6.6f, this.LeftBar.transform.anchoredPosition.y);
			this.RallySpeedupBtn.gameObject.SetActive(true);
		}
		else
		{
			this.LeftBar.transform.anchoredPosition = new Vector2(17.2f, this.LeftBar.transform.anchoredPosition.y);
			this.RallySpeedupBtn.gameObject.SetActive(false);
		}
		if (Data.AllyNameID == 0)
		{
			this.LeftCancelImg.gameObject.SetActive(false);
			this.LeftJoinImg.gameObject.SetActive(false);
		}
		else if (instance.MaxMarchEventNum > Data.SelfParticipateTroopIndex)
		{
			if (instance.MarchEventData[(int)Data.SelfParticipateTroopIndex].bRallyHost == 1 || instance.MarchEventData[(int)Data.SelfParticipateTroopIndex].bRallyHost == 4)
			{
				this.LeftCancelImg.gameObject.SetActive(true);
				this.FilterBtn.gameObject.SetActive(true);
				this.LeftJoinImg.gameObject.SetActive(false);
				this.LeftCancelImg.rectTransform.anchoredPosition = new Vector2(131.5f, -319.5f);
			}
			else if (instance.MarchEventData[(int)Data.SelfParticipateTroopIndex].Type == EMarchEventType.EMET_RallyReturn)
			{
				this.LeftJoinImg.gameObject.SetActive(true);
				this.LeftJoinText.text = instance.mStringTable.GetStringByID(4884u);
				this.LeftJoinText.color = Color.white;
				this.JoinBtn.enabled = true;
			}
			else
			{
				this.LeftJoinImg.gameObject.SetActive(true);
				this.LeftJoinText.text = instance.mStringTable.GetStringByID(4913u);
				this.LeftJoinText.color = Color.red;
				this.JoinBtn.enabled = false;
			}
		}
		else if (Data.Kind == 0)
		{
			if (Data.EventTime.BeginTime + (long)((ulong)Data.EventTime.RequireTime) > instance.ServerTime)
			{
				this.LeftJoinImg.gameObject.SetActive(true);
			}
			this.LeftJoinText.text = instance.mStringTable.GetStringByID(4884u);
			this.LeftJoinText.color = Color.white;
			this.JoinBtn.enabled = true;
		}
		else
		{
			this.LeftJoinImg.gameObject.SetActive(false);
		}
		if (this.ItemsHeight.Count > 0)
		{
			this.RightMessage.gameObject.SetActive(false);
			this.RallyScroll.gameObject.SetActive(true);
			this.RallyScroll.AddNewDataHeight(this.ItemsHeight, true, true);
			this.RallyScroll.GoTo(this.LoadBeginIndex, this.LoadContY);
		}
		else
		{
			this.RightMessage.gameObject.SetActive(true);
			this.RallyScroll.gameObject.SetActive(false);
		}
		Data.AllyCurrTroop = 0u;
		for (int i = 0; i < instance.WarTroop.Count; i++)
		{
			if (instance.WarTroop[i] != null)
			{
				Data.AllyCurrTroop += instance.WarTroop[i].TotalTroopNum;
			}
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(instance.mStringTable.GetStringByID(4889u));
		cstring.AppendFormat("{0} : ");
		base.SetText(Rally.TextType.RightTitle, (int)Data.AllyCurrTroop, cstring, (int)Data.AllyMAXTroop, null, 0);
		this.ArmyStatisticHint.Show(null);
	}

	// Token: 0x06000FBF RID: 4031 RVA: 0x001B90EC File Offset: 0x001B72EC
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (!bOK)
		{
			return;
		}
		if (arg1 == 3)
		{
			DataManager.Instance.sendCancelRally();
		}
		else if (arg1 == 13)
		{
			this.KickMember((ushort)(arg2 >> 16), (byte)(arg2 & 65535));
		}
	}

	// Token: 0x06000FC0 RID: 4032 RVA: 0x001B9134 File Offset: 0x001B7334
	public override void OnButtonClick(UIButton sender)
	{
		if (this.DelayInit > 0)
		{
			this.Init();
			this.DelayInit = 0;
		}
		StringTable mStringTable = DataManager.Instance.mStringTable;
		GUIManager instance = GUIManager.Instance;
		WarlobbyData warlobbyDetail = DataManager.Instance.WarlobbyDetail;
		Rally.ClickType btnID = (Rally.ClickType)sender.m_BtnID1;
		switch (btnID)
		{
		case Rally.ClickType.Filter:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_BuffList, 1, 0, false);
			return;
		}
		default:
			if (btnID == Rally.ClickType.RallySpeed)
			{
				Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door2.OpenMenu(EGUIWindow.UI_BagFilter, 2, 200, false);
				return;
			}
			if (btnID != Rally.ClickType.JoinNPC)
			{
				base.OnButtonClick(sender);
				return;
			}
			break;
		case Rally.ClickType.Join:
			break;
		case Rally.ClickType.Cancel:
			GUIManager.Instance.OpenOKCancelBox(instance.FindMenu(EGUIWindow.UI_Rally), mStringTable.GetStringByID(4975u), mStringTable.GetStringByID(4976u), 3, 0, mStringTable.GetStringByID(4977u), mStringTable.GetStringByID(4978u));
			return;
		}
		List<WarlobbyTroop> warTroop = DataManager.Instance.WarTroop;
		string stringByID = mStringTable.GetStringByID(5748u);
		string stringByID2 = mStringTable.GetStringByID(5750u);
		byte b = 0;
		if (ActivityManager.Instance.IsInKvK(0, false) && DataManager.MapDataController.kingdomData.kingdomID != warlobbyDetail.AllyHomeKingdom)
		{
			instance.OpenMessageBox(stringByID, mStringTable.GetStringByID(982u), stringByID2, null, 0, 0, false, false, false, false, false);
			return;
		}
		if (warTroop.Count > 30)
		{
			b = 1;
			instance.OpenMessageBox(stringByID, mStringTable.GetStringByID(5749u), stringByID2, null, 0, 0, false, false, false, false, false);
		}
		else if (warlobbyDetail.AllyCurrTroop == warlobbyDetail.AllyMAXTroop)
		{
			b = 1;
			instance.OpenMessageBox(stringByID, mStringTable.GetStringByID(5813u), stringByID2, null, 0, 0, false, false, false, false, false);
		}
		else if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyPointCode(warlobbyDetail.AllyCapitalPoint.zoneID, warlobbyDetail.AllyCapitalPoint.pointID)) == 0f)
		{
			b = 1;
			stringByID = mStringTable.GetStringByID(4030u);
			stringByID2 = mStringTable.GetStringByID(4031u);
			instance.OpenMessageBox(stringByID, mStringTable.GetStringByID(119u), stringByID2, null, 0, 0, false, false, false, false, false);
		}
		else
		{
			stringByID = mStringTable.GetStringByID(3967u);
			stringByID2 = mStringTable.GetStringByID(4034u);
			int num = 0;
			if (DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
			{
				num++;
			}
			uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
			for (int i = 0; i < 8; i++)
			{
				if (DataManager.Instance.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
				{
					num++;
					if ((long)num == (long)((ulong)effectBaseVal))
					{
						b = 1;
						instance.OpenMessageBox(stringByID, mStringTable.GetStringByID(3959u), stringByID2, null, 0, 0, false, false, false, false, false);
						break;
					}
				}
			}
		}
		if (b == 0)
		{
			Door door3 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door3)
			{
				if (sender.m_BtnID1 == 2)
				{
					door3.OpenMenu(EGUIWindow.UI_Expedition, 1, 3, true);
				}
				else
				{
					door3.OpenMenu(EGUIWindow.UI_Expedition, 1, 9, true);
				}
			}
		}
	}

	// Token: 0x06000FC1 RID: 4033 RVA: 0x001B9498 File Offset: 0x001B7698
	public override void OnTimer(UITimeBar sender)
	{
		if (sender.m_TimeBarID == 1)
		{
			return;
		}
		if (this.JoinBtn.enabled)
		{
			this.LeftJoinImg.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000FC2 RID: 4034 RVA: 0x001B94D4 File Offset: 0x001B76D4
	public override void KickMember(ushort Index, byte WonderID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_KICK_RALLYMEMBER;
		messagePacket.Add(Index);
		messagePacket.Send(false);
	}

	// Token: 0x040033BE RID: 13246
	private bool bShowAttackbtn;
}
