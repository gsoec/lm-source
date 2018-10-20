using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000307 RID: 775
public class Rally_Defense : Rally
{
	// Token: 0x06000FC3 RID: 4035 RVA: 0x001B950C File Offset: 0x001B770C
	public Rally_Defense(Transform transform, int dataindex) : base(transform, dataindex)
	{
	}

	// Token: 0x06000FC4 RID: 4036 RVA: 0x001B9518 File Offset: 0x001B7718
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		base.OnOpen(arg1, arg2);
		this.bCloseDefensebtn = ((arg2 & 32768) > 0);
		this.TitleText.color = new Color(0.345f, 0.945f, 1f);
		this.TitleText.text = instance.mStringTable.GetStringByID(4874u);
		this.TopText.text = instance.mStringTable.GetStringByID(4885u);
		this.TopBar.gameObject.SetActive(false);
		this.LeftBar.gameObject.SetActive(false);
		this.TopTargetIcon.SetActive(false);
		this.LeftAttackIcon.SetActive(false);
		this.RightFlagAttack.enabled = false;
		this.RallyTitleStr = instance.mStringTable.GetStringByID(4891u);
		this.AttackBtnSprite = this.LeftFilterImg.sprite;
		this.AttackOnSprite = this.LeftFilterOnImg.sprite;
	}

	// Token: 0x06000FC5 RID: 4037 RVA: 0x001B9620 File Offset: 0x001B7820
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

	// Token: 0x06000FC6 RID: 4038 RVA: 0x001B9640 File Offset: 0x001B7840
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
			this.UpdateRallyWonderDefense(ref warlobbyDetail);
		}
		else
		{
			this.UpdateRallyDefense(ref warlobbyDetail);
		}
	}

	// Token: 0x06000FC7 RID: 4039 RVA: 0x001B9688 File Offset: 0x001B7888
	private void UpdateRallyDefense(ref WarlobbyData Data)
	{
		DataManager instance = DataManager.Instance;
		this.LeftText.text = instance.mStringTable.GetStringByID(4886u);
		this.JoinBtn.m_BtnID1 = 2;
		this.LeftFilterImg.sprite = this.SPriteArray.GetSprite(0);
		this.LeftFilterOnImg.sprite = this.SPriteArray.GetSprite(1);
		Data.AttackOrDefense = 1;
		GUIManager.Instance.ChangeHeroItemImg(this.TopHero, eHeroOrItem.Hero, Data.EnemyHead, 11, 0, 0);
		if (Data.EnemyHead > 0)
		{
			this.TopHero.gameObject.SetActive(true);
		}
		if (DataManager.MapDataController.kingdomData.kingdomID == Data.EnemyHomeKingdom)
		{
			this.TopCountry.SetActive(false);
		}
		else
		{
			this.TopCountry.SetActive(true);
			base.SetText(Rally.TextType.TopCountry, (int)Data.EnemyHomeKingdom, null, 0, null, 0);
		}
		base.SetText(Rally.TextType.TopName, 0, Data.EnemyName, 0, Data.EnemyAllianceTag, Data.EnemyHomeKingdom);
		GUIManager.Instance.ChangeHeroItemImg(this.LeftHero, eHeroOrItem.Hero, Data.AllyHead, 11, 0, 0);
		if (Data.AllyHead > 0)
		{
			this.LeftHero.gameObject.SetActive(true);
		}
		base.SetText(Rally.TextType.LeftName, 0, Data.AllyName, 0, null, 0);
		if (Data.AllyNameID != 0)
		{
			this.TopBar.gameObject.SetActive(true);
			this.TopBar.SetTimebar(base.GetTroopKind(), Data.EventTime.BeginTime, Data.EventTime.BeginTime + (long)((ulong)Data.EventTime.RequireTime), 0L);
		}
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
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform rectTransform = this.TopUnderLine.transform as RectTransform;
			rectTransform.anchoredPosition = new Vector2(this.TopNameText.rectTransform.sizeDelta.x - this.TopNameText.preferredWidth, rectTransform.anchoredPosition.y);
		}
		this.LeftUnderLine.gameObject.SetActive(true);
		if (DataManager.MapDataController.kingdomData.kingdomID == Data.EnemyHomeKingdom)
		{
			this.TopCountry.SetActive(false);
		}
		else
		{
			this.TopCountry.SetActive(true);
		}
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
		int hashCode = instance.RoleAttr.Name.GetHashCode(false);
		if (hashCode == Data.AllyNameID)
		{
			this.FilterBtn.gameObject.SetActive(true);
		}
		else
		{
			this.FilterBtn.gameObject.SetActive(false);
		}
		if (Data.AllyNameID != 0 && Data.AllyNameID != hashCode && !this.bCloseDefensebtn)
		{
			this.LeftJoinImg.gameObject.SetActive(true);
			CString cstring = StringManager.Instance.StaticString1024();
			bool flag = false;
			for (byte b2 = 0; b2 < instance.MaxMarchEventNum; b2 += 1)
			{
				if ((instance.MarchEventData[(int)b2].Type == EMarchEventType.EMET_InforceMarching || instance.MarchEventData[(int)b2].Type == EMarchEventType.EMET_InforceStanby) && DataManager.MapDataController.getYolkIDbyPointCode(instance.MarchEventData[(int)b2].Point.zoneID, instance.MarchEventData[(int)b2].Point.pointID, 0) == 40)
				{
					cstring.ClearString();
					cstring.Append(instance.MarchEventData[(int)b2].DesPlayerName);
					if (cstring.GetHashCode(false) == Data.AllyNameID)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				this.JoinBtn.enabled = true;
				this.LeftJoinText.color = Color.white;
				UIText leftJoinText = this.LeftJoinText;
				string stringByID = instance.mStringTable.GetStringByID(4887u);
				this.LeftJoinText.text = stringByID;
				leftJoinText.text = stringByID;
			}
			else
			{
				this.LeftJoinText.color = Color.red;
				UIText leftJoinText2 = this.LeftJoinText;
				string stringByID = instance.mStringTable.GetStringByID(5891u);
				this.LeftJoinText.text = stringByID;
				leftJoinText2.text = stringByID;
				this.JoinBtn.enabled = false;
			}
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
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring2.StringToFormat(instance.mStringTable.GetStringByID(4890u));
		cstring2.AppendFormat("{0} : ");
		base.SetText(Rally.TextType.RightTitle, (int)Data.AllyCurrTroop, cstring2, (int)Data.AllyMAXTroop, null, 0);
		this.ArmyStatisticHint.Show(null);
	}

	// Token: 0x06000FC8 RID: 4040 RVA: 0x001B9EC4 File Offset: 0x001B80C4
	private void UpdateRallyWonderDefense(ref WarlobbyData Data)
	{
		DataManager instance = DataManager.Instance;
		this.LeftFilterImg.sprite = this.AttackBtnSprite;
		this.LeftFilterOnImg.sprite = this.AttackOnSprite;
		this.LeftTextStr.ClearString();
		if (Data.WonderID > 0 && DataManager.MapDataController.OtherKingdomData.kingdomID != ActivityManager.Instance.KOWKingdomID)
		{
			this.LeftTextStr.StringToFormat(instance.mStringTable.GetStringByID(9309u));
		}
		else
		{
			this.LeftTextStr.StringToFormat(instance.mStringTable.GetStringByID(9308u));
		}
		this.LeftTextStr.AppendFormat(instance.mStringTable.GetStringByID(8555u));
		this.LeftText.text = this.LeftTextStr.ToString();
		this.LeftText.SetAllDirty();
		this.LeftText.cachedTextGenerator.Invalidate();
		this.JoinBtn.m_BtnID1 = 6;
		this.FilterBtn.m_BtnID1 = 9;
		Data.AttackOrDefense = 1;
		GUIManager.Instance.ChangeHeroItemImg(this.TopHero, eHeroOrItem.Hero, Data.EnemyHead, 11, 0, 0);
		if (Data.EnemyHead > 0)
		{
			this.TopHero.gameObject.SetActive(true);
		}
		if (DataManager.MapDataController.kingdomData.kingdomID == Data.EnemyHomeKingdom)
		{
			this.TopCountry.SetActive(false);
		}
		else
		{
			this.TopCountry.SetActive(true);
			base.SetText(Rally.TextType.TopCountry, (int)Data.EnemyHomeKingdom, null, 0, null, 0);
		}
		base.SetText(Rally.TextType.TopName, 0, Data.EnemyName, 0, Data.EnemyAllianceTag, Data.EnemyHomeKingdom);
		if (DataManager.MapDataController.OtherKingdomData.kingdomID == ActivityManager.Instance.KOWKingdomID)
		{
			GUIManager.Instance.ChangeWonderImg(this.LeftHero, Data.WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID);
		}
		else
		{
			GUIManager.Instance.ChangeWonderImg(this.LeftHero, Data.WonderID, Data.AllyHomeKingdom);
		}
		this.LeftHero.gameObject.SetActive(true);
		Data.AllyName.ClearString();
		Data.AllyName.Append(DataManager.MapDataController.GetYolkName((ushort)Data.WonderID, 0));
		base.SetText(Rally.TextType.LeftName, 0, Data.AllyName, 0, null, 0);
		this.TopBar.gameObject.SetActive(true);
		this.TopBar.SetTimebar(base.GetTroopKind(), Data.EventTime.BeginTime, Data.EventTime.BeginTime + (long)((ulong)Data.EventTime.RequireTime), 0L);
		this.TopHeroBtn.m_BtnID1 = GameConstants.PointCodeToMapID(Data.EnemyCapitalPoint.zoneID, Data.EnemyCapitalPoint.pointID);
		this.TopHeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		Vector2 yolkPointCode = DataManager.MapDataController.GetYolkPointCode((ushort)Data.WonderID, 0);
		Data.AllyCapitalPoint.zoneID = (ushort)yolkPointCode.x;
		Data.AllyCapitalPoint.pointID = (byte)yolkPointCode.y;
		this.LeftHeroBtn.m_BtnID1 = (int)DataManager.MapDataController.GetYolkMapID((ushort)Data.WonderID, 0);
		this.LeftHeroBtn.m_BtnID2 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.TopUnderLineBtn.m_BtnID2 = GameConstants.PointCodeToMapID(Data.EnemyCapitalPoint.zoneID, Data.EnemyCapitalPoint.pointID);
		this.TopUnderLineBtn.m_BtnID3 = (int)DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.LeftUnderLineBtn.m_BtnID2 = (int)DataManager.MapDataController.GetYolkMapID((ushort)Data.WonderID, 0);
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
		if (DataManager.MapDataController.kingdomData.kingdomID == Data.EnemyHomeKingdom)
		{
			this.TopCountry.SetActive(false);
		}
		else
		{
			this.TopCountry.SetActive(true);
		}
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
		if (instance.MaxMarchEventNum > Data.SelfParticipateTroopIndex)
		{
			flag = true;
			if (instance.WarTroop.Count > 0)
			{
				if (instance.WarTroop[0].AllyNameID == instance.RoleAttr.Name.GetHashCode(false))
				{
					this.FilterBtn.gameObject.SetActive(true);
					this.LeftJoinImg.gameObject.SetActive(false);
				}
				else
				{
					this.FilterBtn.gameObject.SetActive(false);
					this.LeftJoinImg.gameObject.SetActive(true);
				}
			}
		}
		else
		{
			this.LeftJoinImg.gameObject.SetActive(true);
		}
		if (this.LeftJoinImg.gameObject.activeSelf)
		{
			if (!flag)
			{
				this.JoinBtn.enabled = true;
				this.LeftJoinText.color = Color.white;
				UIText leftJoinText = this.LeftJoinText;
				string stringByID = instance.mStringTable.GetStringByID(4887u);
				this.LeftJoinText.text = stringByID;
				leftJoinText.text = stringByID;
			}
			else
			{
				this.LeftJoinText.color = Color.red;
				UIText leftJoinText2 = this.LeftJoinText;
				string stringByID = instance.mStringTable.GetStringByID(5891u);
				this.LeftJoinText.text = stringByID;
				leftJoinText2.text = stringByID;
				this.JoinBtn.enabled = false;
			}
		}
		this.MemberCombat.gameobject.SetActive(true);
		this.MemberCombat.SetCombatVal(base.GetCombatPower(false));
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
		cstring.StringToFormat(instance.mStringTable.GetStringByID(8560u));
		cstring.AppendFormat("{0} : ");
		base.SetText(Rally.TextType.RightTitle, (int)Data.AllyCurrTroop, cstring, (int)Data.AllyMAXTroop, null, 0);
		this.ArmyStatisticHint.Show(null);
	}

	// Token: 0x06000FC9 RID: 4041 RVA: 0x001BA7F8 File Offset: 0x001B89F8
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (!bOK)
		{
			return;
		}
		if (arg1 == 13)
		{
			this.KickMember((ushort)(arg2 >> 16), (byte)(arg2 & 65535));
		}
	}

	// Token: 0x06000FCA RID: 4042 RVA: 0x001BA828 File Offset: 0x001B8A28
	public override void OnButtonClick(UIButton sender)
	{
		if (this.DelayInit > 0)
		{
			this.Init();
			this.DelayInit = 0;
		}
		if (sender.m_BtnID1 == 2)
		{
			StringTable mStringTable = DataManager.Instance.mStringTable;
			List<WarlobbyTroop> warTroop = DataManager.Instance.WarTroop;
			WarlobbyData warlobbyDetail = DataManager.Instance.WarlobbyDetail;
			GUIManager instance = GUIManager.Instance;
			byte b = 0;
			string stringByID = mStringTable.GetStringByID(5745u);
			string stringByID2 = mStringTable.GetStringByID(5747u);
			if (ActivityManager.Instance.IsInKvK(0, false) && DataManager.MapDataController.kingdomData.kingdomID != warlobbyDetail.AllyHomeKingdom)
			{
				instance.OpenMessageBox(stringByID, mStringTable.GetStringByID(4827u), stringByID2, null, 0, 0, false, false, false, false, false);
				return;
			}
			if (warTroop.Count >= 30)
			{
				b = 1;
				instance.OpenMessageBox(stringByID, mStringTable.GetStringByID(5746u), stringByID2, null, 0, 0, false, false, false, false, false);
			}
			else if (warlobbyDetail.AllyCurrTroop == warlobbyDetail.AllyMAXTroop)
			{
				b = 1;
				if (warlobbyDetail.AllyMAXTroop > 0u)
				{
					stringByID = mStringTable.GetStringByID(5812u);
					stringByID2 = mStringTable.GetStringByID(5814u);
					instance.OpenMessageBox(stringByID, mStringTable.GetStringByID(5813u), stringByID2, null, 0, 0, false, false, false, false, false);
				}
				else
				{
					stringByID = mStringTable.GetStringByID(4834u);
					stringByID2 = mStringTable.GetStringByID(4836u);
					instance.OpenMessageBox(stringByID, mStringTable.GetStringByID(4835u), stringByID2, null, 0, 0, false, false, false, false, false);
				}
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
				DataManager.Instance.ReinforceCheckType = eReinforceCheck.OpenUIExpedition_Marshal;
				DataManager.Instance.SendAllyInforceInfo(warlobbyDetail.AllyName.ToString());
			}
		}
		else if (sender.m_BtnID1 == 6)
		{
			StringTable mStringTable2 = DataManager.Instance.mStringTable;
			List<WarlobbyTroop> warTroop2 = DataManager.Instance.WarTroop;
			WarlobbyData warlobbyDetail2 = DataManager.Instance.WarlobbyDetail;
			GUIManager instance2 = GUIManager.Instance;
			Door door = instance2.FindMenu(EGUIWindow.Door) as Door;
			byte b2 = 0;
			string stringByID3 = mStringTable2.GetStringByID(8563u);
			string stringByID4 = mStringTable2.GetStringByID(8565u);
			if (ActivityManager.Instance.IsInKvK(0, false))
			{
				if (warlobbyDetail2.AllyCurrTroop == 0u)
				{
					instance2.OpenMessageBox(stringByID3, mStringTable2.GetStringByID(9916u), stringByID4, null, 0, 0, false, false, false, false, false);
					return;
				}
				if (DataManager.MapDataController.kingdomData.kingdomID != warlobbyDetail2.AllyHomeKingdom)
				{
					instance2.OpenMessageBox(stringByID3, mStringTable2.GetStringByID(4827u), stringByID4, null, 0, 0, false, false, false, false, false);
					return;
				}
			}
			if (warTroop2.Count > 30)
			{
				b2 = 1;
				this.MessageStr.ClearString();
				this.MessageStr.StringToFormat(this.LeftNameText.text);
				this.MessageStr.AppendFormat(mStringTable2.GetStringByID(8568u));
				instance2.OpenMessageBox(stringByID3, this.MessageStr.ToString(), stringByID4, null, 0, 0, false, false, false, false, false);
			}
			else if (warlobbyDetail2.AllyCurrTroop == 0u)
			{
				b2 = 1;
				instance2.OpenMessageBox(stringByID3, mStringTable2.GetStringByID(9916u), stringByID4, null, 0, 0, false, false, false, false, false);
			}
			else if (warlobbyDetail2.AllyCurrTroop == warlobbyDetail2.AllyMAXTroop)
			{
				b2 = 1;
				if (warTroop2.Count > 1)
				{
					stringByID3 = mStringTable2.GetStringByID(8563u);
					stringByID4 = mStringTable2.GetStringByID(8565u);
					this.MessageStr.ClearString();
					this.MessageStr.StringToFormat(this.LeftNameText.text);
					this.MessageStr.AppendFormat(mStringTable2.GetStringByID(8567u));
					instance2.OpenMessageBox(stringByID3, this.MessageStr.ToString(), stringByID4, null, 0, 0, false, false, false, false, false);
				}
				else
				{
					stringByID3 = mStringTable2.GetStringByID(8563u);
					stringByID4 = mStringTable2.GetStringByID(8565u);
					this.MessageStr.ClearString();
					this.MessageStr.StringToFormat(this.LeftNameText.text);
					this.MessageStr.AppendFormat(mStringTable2.GetStringByID(8566u));
					instance2.OpenMessageBox(stringByID3, this.MessageStr.ToString(), stringByID4, null, 0, 0, false, false, false, false, false);
				}
			}
			else if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyPointCode(warlobbyDetail2.AllyCapitalPoint.zoneID, warlobbyDetail2.AllyCapitalPoint.pointID)) == 0f)
			{
				b2 = 1;
				stringByID3 = mStringTable2.GetStringByID(4030u);
				stringByID4 = mStringTable2.GetStringByID(4031u);
				instance2.OpenMessageBox(stringByID3, mStringTable2.GetStringByID(119u), stringByID4, null, 0, 0, false, false, false, false, false);
			}
			else
			{
				int num2 = 0;
				if (DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
				{
					num2++;
				}
				uint effectBaseVal2 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
				for (int j = 0; j < 8; j++)
				{
					if (DataManager.Instance.MarchEventData[j].Type != EMarchEventType.EMET_Standby)
					{
						num2++;
						if ((long)num2 == (long)((ulong)effectBaseVal2))
						{
							b2 = 1;
							instance2.OpenMessageBox(stringByID3, mStringTable2.GetStringByID(3959u), stringByID4, null, 0, 0, false, false, false, false, false);
							break;
						}
					}
				}
			}
			if (door && b2 == 0)
			{
				door.OpenMenu(EGUIWindow.UI_Expedition, 3, 2, true);
			}
		}
		else if (sender.m_BtnID1 == 0)
		{
			Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door2.OpenMenu(EGUIWindow.UI_BuffList, 2, 0, false);
		}
		else if (sender.m_BtnID1 == 9)
		{
			Door door3 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door3.OpenMenu(EGUIWindow.UI_BuffList, 1, 0, false);
		}
		else
		{
			base.OnButtonClick(sender);
		}
	}

	// Token: 0x06000FCB RID: 4043 RVA: 0x001BAF0C File Offset: 0x001B910C
	public override void OnTimer(UITimeBar sender)
	{
	}

	// Token: 0x06000FCC RID: 4044 RVA: 0x001BAF10 File Offset: 0x001B9110
	public override void KickMember(ushort Index, byte WonderID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		if (WonderID == 255)
		{
			messagePacket.Protocol = Protocol._MSG_REQUEST_KICK_INFORCEMEMBER;
			messagePacket.Add(Index);
		}
		else
		{
			messagePacket.Protocol = Protocol._MSG_REQUEST_KICK_WONDERMEMBER;
			messagePacket.Add(WonderID);
			messagePacket.Add(Index);
		}
		messagePacket.Send(false);
	}

	// Token: 0x040033BF RID: 13247
	private bool bCloseDefensebtn;

	// Token: 0x040033C0 RID: 13248
	private Sprite AttackBtnSprite;

	// Token: 0x040033C1 RID: 13249
	private Sprite AttackOnSprite;

	// Token: 0x02000308 RID: 776
	private enum FilterKind
	{
		// Token: 0x040033C3 RID: 13251
		Defence,
		// Token: 0x040033C4 RID: 13252
		Wonders
	}
}
