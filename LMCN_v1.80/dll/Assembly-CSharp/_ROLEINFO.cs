using System;

// Token: 0x02000073 RID: 115
public struct _ROLEINFO
{
	// Token: 0x17000027 RID: 39
	// (get) Token: 0x060002B5 RID: 693 RVA: 0x00026C3C File Offset: 0x00024E3C
	// (set) Token: 0x060002B6 RID: 694 RVA: 0x00026C44 File Offset: 0x00024E44
	public byte VIPLevel
	{
		get
		{
			return this._VIPLevel;
		}
		set
		{
			if (this._VIPLevel == 2 && value > this._VIPLevel)
			{
				AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.REACH_VIPLV3);
			}
			this._VIPLevel = value;
		}
	}

	// Token: 0x17000028 RID: 40
	// (get) Token: 0x060002B8 RID: 696 RVA: 0x00026C98 File Offset: 0x00024E98
	// (set) Token: 0x060002B7 RID: 695 RVA: 0x00026C80 File Offset: 0x00024E80
	public uint recvMonsterPoint
	{
		get
		{
			return this._recvMonsterPoint;
		}
		set
		{
			this._recvMonsterPoint = value;
			this.MonsterPoint = this._recvMonsterPoint;
		}
	}

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x060002BA RID: 698 RVA: 0x00026CBC File Offset: 0x00024EBC
	// (set) Token: 0x060002B9 RID: 697 RVA: 0x00026CA0 File Offset: 0x00024EA0
	public ulong Power
	{
		get
		{
			return this._Power;
		}
		set
		{
			this._Power = value;
			AFAdvanceManager.Instance.CheckPower(this._Power);
		}
	}

	// Token: 0x0400063C RID: 1596
	public int ReadPackNum;

	// Token: 0x0400063D RID: 1597
	public long UserId;

	// Token: 0x0400063E RID: 1598
	public CString Name;

	// Token: 0x0400063F RID: 1599
	public CString NickName;

	// Token: 0x04000640 RID: 1600
	public ushort KingdomTitle;

	// Token: 0x04000641 RID: 1601
	public ushort WorldTitle_Country;

	// Token: 0x04000642 RID: 1602
	public ushort WorldTitle_Personal;

	// Token: 0x04000643 RID: 1603
	public ushort NobilityTitle;

	// Token: 0x04000644 RID: 1604
	public ushort Head;

	// Token: 0x04000645 RID: 1605
	public byte Level;

	// Token: 0x04000646 RID: 1606
	public uint Exp;

	// Token: 0x04000647 RID: 1607
	public ushort Morale;

	// Token: 0x04000648 RID: 1608
	public long LastMoraleRecoverTime;

	// Token: 0x04000649 RID: 1609
	public long AddictionTime;

	// Token: 0x0400064A RID: 1610
	public long ServerTime;

	// Token: 0x0400064B RID: 1611
	public long LogoutTime;

	// Token: 0x0400064C RID: 1612
	public long FirstTimer;

	// Token: 0x0400064D RID: 1613
	public ulong Guide;

	// Token: 0x0400064E RID: 1614
	public uint GuideEx;

	// Token: 0x0400064F RID: 1615
	public uint Diamond;

	// Token: 0x04000650 RID: 1616
	public uint PrizeFlag;

	// Token: 0x04000651 RID: 1617
	public byte HeroSkillPoint;

	// Token: 0x04000652 RID: 1618
	public long LastHeroSPRecoverTime;

	// Token: 0x04000653 RID: 1619
	public ushort EnhanceEventHeroID;

	// Token: 0x04000654 RID: 1620
	public TimeEventDataType HeroEnhanceEventTime;

	// Token: 0x04000655 RID: 1621
	public ushort StarUpEventHeroID;

	// Token: 0x04000656 RID: 1622
	public TimeEventDataType HeroStarUpEventTime;

	// Token: 0x04000657 RID: 1623
	public ulong BattleID;

	// Token: 0x04000658 RID: 1624
	public int CapitalPoint;

	// Token: 0x04000659 RID: 1625
	public uint[] m_Soldier;

	// Token: 0x0400065A RID: 1626
	public ulong LastChatterTime;

	// Token: 0x0400065B RID: 1627
	public uint AllianceChatID;

	// Token: 0x0400065C RID: 1628
	public ulong Kills;

	// Token: 0x0400065D RID: 1629
	public ulong _Power;

	// Token: 0x0400065E RID: 1630
	public uint VipPoint;

	// Token: 0x0400065F RID: 1631
	public long BookmarkTime;

	// Token: 0x04000660 RID: 1632
	public ushort BookmarkNum;

	// Token: 0x04000661 RID: 1633
	public ushort BookmarkLimit;

	// Token: 0x04000662 RID: 1634
	public ushort SuccessiveLoginDays;

	// Token: 0x04000663 RID: 1635
	public byte TodayUseMoraleItemTimes;

	// Token: 0x04000664 RID: 1636
	private byte _VIPLevel;

	// Token: 0x04000665 RID: 1637
	public byte VIPLevelMax;

	// Token: 0x04000666 RID: 1638
	public byte VipLevelUp;

	// Token: 0x04000667 RID: 1639
	public byte LordEquipBagSize;

	// Token: 0x04000668 RID: 1640
	public long NextOnlineGiftOpenTime;

	// Token: 0x04000669 RID: 1641
	public byte OnlineGiftOpenTimes;

	// Token: 0x0400066A RID: 1642
	public ItemSaveDataType OnlineGiftItemID;

	// Token: 0x0400066B RID: 1643
	public long LastLordEquipUpdateTime;

	// Token: 0x0400066C RID: 1644
	public long LastItemMatUpdateTime;

	// Token: 0x0400066D RID: 1645
	public long LastItemGemUpdateTime;

	// Token: 0x0400066E RID: 1646
	public ItemLordEquip LordEquipEventData;

	// Token: 0x0400066F RID: 1647
	public TimeEventDataType LordEquipEventTime;

	// Token: 0x04000670 RID: 1648
	public long LastHitMonsterTime;

	// Token: 0x04000671 RID: 1649
	public uint LastHitMonsterSerialNO;

	// Token: 0x04000672 RID: 1650
	public byte DamageRateForMonster;

	// Token: 0x04000673 RID: 1651
	public uint MonsterPoint;

	// Token: 0x04000674 RID: 1652
	public byte NowArmyCoordIndex;

	// Token: 0x04000675 RID: 1653
	public uint ArmyCoordFlag;

	// Token: 0x04000676 RID: 1654
	public byte bAllianceMobilizationGetPrize;

	// Token: 0x04000677 RID: 1655
	private uint _recvMonsterPoint;

	// Token: 0x04000678 RID: 1656
	public long LastMonsterPointRecoverTime;

	// Token: 0x04000679 RID: 1657
	public ushort MonsterPointRecoverFrequency;

	// Token: 0x0400067A RID: 1658
	public uint TPP_Point;

	// Token: 0x0400067B RID: 1659
	public uint PaidCrystal;

	// Token: 0x0400067C RID: 1660
	public byte DailyFreeScardStar;

	// Token: 0x0400067D RID: 1661
	public uint ScardStar;

	// Token: 0x0400067E RID: 1662
	public ushort PetSkillFatigue;

	// Token: 0x0400067F RID: 1663
	public ushort FatigueRestoreSpeed;

	// Token: 0x04000680 RID: 1664
	public long LastPetSkillFatigueTime;

	// Token: 0x04000681 RID: 1665
	public SocialFriend Inviter;

	// Token: 0x04000682 RID: 1666
	public byte Invitation;
}
