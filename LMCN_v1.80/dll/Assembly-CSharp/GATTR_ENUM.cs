﻿using System;

// Token: 0x0200018C RID: 396
public enum GATTR_ENUM : ushort
{
	// Token: 0x0400159A RID: 5530
	EGA_INFNATRY_ATK,
	// Token: 0x0400159B RID: 5531
	EGA_CAVALRY_ATK,
	// Token: 0x0400159C RID: 5532
	EGA_RANGED_ATK,
	// Token: 0x0400159D RID: 5533
	EGA_SIEGE_ATK,
	// Token: 0x0400159E RID: 5534
	EGA_TRAP_ATK,
	// Token: 0x0400159F RID: 5535
	EGA_INFNATRY_DEF,
	// Token: 0x040015A0 RID: 5536
	EGA_CAVALRY_DEF,
	// Token: 0x040015A1 RID: 5537
	EGA_RANGED_DEF,
	// Token: 0x040015A2 RID: 5538
	EGA_SIEGE_DEF,
	// Token: 0x040015A3 RID: 5539
	EGA_TRAP_DEF,
	// Token: 0x040015A4 RID: 5540
	EGA_INFNATRY_HEALTH,
	// Token: 0x040015A5 RID: 5541
	EGA_CAVALRY_HEALTH,
	// Token: 0x040015A6 RID: 5542
	EGA_RANGED_HEALTH,
	// Token: 0x040015A7 RID: 5543
	EGA_SIEGE_HEALTH,
	// Token: 0x040015A8 RID: 5544
	EGA_TRAP_HEALTH,
	// Token: 0x040015A9 RID: 5545
	EGA_TROOP_ATK,
	// Token: 0x040015AA RID: 5546
	EGA_TROOP_DEF,
	// Token: 0x040015AB RID: 5547
	EGA_TROOP_HEALTH,
	// Token: 0x040015AC RID: 5548
	EGA_TROOP_LOAD,
	// Token: 0x040015AD RID: 5549
	EGA_MARCH_SPEED,
	// Token: 0x040015AE RID: 5550
	EGA_TROOP_ATK_DEBUFF,
	// Token: 0x040015AF RID: 5551
	EGA_TROOP_DEF_DEBUFF,
	// Token: 0x040015B0 RID: 5552
	EGA_TROOP_HEALTH_DEBUFF,
	// Token: 0x040015B1 RID: 5553
	EGA_TROOP_LOAD_DEBUFF,
	// Token: 0x040015B2 RID: 5554
	EGA_MARCH_SPEED_DEBUFF,
	// Token: 0x040015B3 RID: 5555
	EGA_UPKEEP_REDUCTION,
	// Token: 0x040015B4 RID: 5556
	EGA_HOMETROOP_ATK,
	// Token: 0x040015B5 RID: 5557
	EGA_HOMETROOP_DEF,
	// Token: 0x040015B6 RID: 5558
	EGA_HOMETROOP_HEALTH,
	// Token: 0x040015B7 RID: 5559
	EGA_ENEMYTROOP_HEALTH_DEBUFF,
	// Token: 0x040015B8 RID: 5560
	EGA_ENEMYTROOP_ATK_DEBUFF,
	// Token: 0x040015B9 RID: 5561
	EGA_ENEMYTROOP_DEF_DEBUFF,
	// Token: 0x040015BA RID: 5562
	EGA_MARCH_NUM,
	// Token: 0x040015BB RID: 5563
	EGA_TROOPHERO_SPACE,
	// Token: 0x040015BC RID: 5564
	EGA_HEROTROOPAMOUNT,
	// Token: 0x040015BD RID: 5565
	EGA_HEROTROOPAMOUNT_PERCENT,
	// Token: 0x040015BE RID: 5566
	EGA_ATTACK_MARCH_SPEED,
	// Token: 0x040015BF RID: 5567
	EGA_RALLY_SPEED,
	// Token: 0x040015C0 RID: 5568
	EGA_TRADE_MARCH_SPEED,
	// Token: 0x040015C1 RID: 5569
	EGA_GATHERING_MARCH_SPEED,
	// Token: 0x040015C2 RID: 5570
	EGA_HERO_MARCH_SPEED,
	// Token: 0x040015C3 RID: 5571
	EGA_FOOD_PRODUCTION_PERCENT,
	// Token: 0x040015C4 RID: 5572
	EGA_ROCK_PRODUCTION_PERCENT,
	// Token: 0x040015C5 RID: 5573
	EGA_WOOD_PRODUCTION_PERCENT,
	// Token: 0x040015C6 RID: 5574
	EGA_STEEL_PRODUCTION_PERCENT,
	// Token: 0x040015C7 RID: 5575
	EGA_MONEY_PRODUCTION_PERCENT,
	// Token: 0x040015C8 RID: 5576
	EGA_RESOURCE_PRODUCTION,
	// Token: 0x040015C9 RID: 5577
	EGA_CONSTRUCTION_SPEED,
	// Token: 0x040015CA RID: 5578
	EGA_RESEARCH_SPEED,
	// Token: 0x040015CB RID: 5579
	EGA_CRAFTING_SPEED,
	// Token: 0x040015CC RID: 5580
	EGA_TROOP_TRAINING_SPEED,
	// Token: 0x040015CD RID: 5581
	EGA_TRAP_TRAINING_SPEED,
	// Token: 0x040015CE RID: 5582
	EGA_HOSPITAL_HEALING_SPEED,
	// Token: 0x040015CF RID: 5583
	EGA_GATHERING_SPEED,
	// Token: 0x040015D0 RID: 5584
	EGA_DIAMOND_GATHERING_SPEED,
	// Token: 0x040015D1 RID: 5585
	EGA_FOOD_PRODUCTION,
	// Token: 0x040015D2 RID: 5586
	EGA_ROCK_PRODUCTION,
	// Token: 0x040015D3 RID: 5587
	EGA_WOOD_PRODUCTION,
	// Token: 0x040015D4 RID: 5588
	EGA_STEEL_PRODUCTION,
	// Token: 0x040015D5 RID: 5589
	EGA_MONEY_PRODUCTION,
	// Token: 0x040015D6 RID: 5590
	EGA_FOOD_CAPACITY,
	// Token: 0x040015D7 RID: 5591
	EGA_ROCK_CAPACITY,
	// Token: 0x040015D8 RID: 5592
	EGA_WOOD_CAPACITY,
	// Token: 0x040015D9 RID: 5593
	EGA_STEEL_CAPACITY,
	// Token: 0x040015DA RID: 5594
	EGA_MONEY_CAPACITY,
	// Token: 0x040015DB RID: 5595
	EGA_TRAINING_CAPACITY,
	// Token: 0x040015DC RID: 5596
	EGA_TRAINING_CAPACITY_PERCENT,
	// Token: 0x040015DD RID: 5597
	EGA_TRAP_CAPACITY,
	// Token: 0x040015DE RID: 5598
	EGA_WALL_HEALTH,
	// Token: 0x040015DF RID: 5599
	EGA_HOSPITAL_CAPACITY,
	// Token: 0x040015E0 RID: 5600
	EGA_STOREHOUSE_PROTECTION,
	// Token: 0x040015E1 RID: 5601
	EGA_RESOURCE_TRADE_CAPACITY,
	// Token: 0x040015E2 RID: 5602
	EGA_RESOURCE_TRADE_TAX,
	// Token: 0x040015E3 RID: 5603
	EGA_GATHERING_CAPACITY,
	// Token: 0x040015E4 RID: 5604
	EGA_REINFORCE_CAPACITY,
	// Token: 0x040015E5 RID: 5605
	EGA_RALLY_CAPACITY,
	// Token: 0x040015E6 RID: 5606
	EGA_TREASURY_INTEREST_RATE,
	// Token: 0x040015E7 RID: 5607
	EGA_TREASURY_MAX_DEPOSIT,
	// Token: 0x040015E8 RID: 5608
	EGA_ALLAINCE_HELP,
	// Token: 0x040015E9 RID: 5609
	EGA_T1INFNATRY_RESOURCE_COST_REDUCTION,
	// Token: 0x040015EA RID: 5610
	EGA_T1RANGED_RESOURCE_COST_REDUCTION,
	// Token: 0x040015EB RID: 5611
	EGA_T1CAVALRY_RESOURCE_COST_REDUCTION,
	// Token: 0x040015EC RID: 5612
	EGA_T1SIEGE_RESOURCE_COST_REDUCTION,
	// Token: 0x040015ED RID: 5613
	EGA_T2INFNATRY_RESOURCE_COST_REDUCTION,
	// Token: 0x040015EE RID: 5614
	EGA_T2RANGED_RESOURCE_COST_REDUCTION,
	// Token: 0x040015EF RID: 5615
	EGA_T2CAVALRY_RESOURCE_COST_REDUCTION,
	// Token: 0x040015F0 RID: 5616
	EGA_T2SIEGE_RESOURCE_COST_REDUCTION,
	// Token: 0x040015F1 RID: 5617
	EGA_T3INFNATRY_RESOURCE_COST_REDUCTION,
	// Token: 0x040015F2 RID: 5618
	EGA_T3RANGED_RESOURCE_COST_REDUCTION,
	// Token: 0x040015F3 RID: 5619
	EGA_T3CAVALRY_RESOURCE_COST_REDUCTION,
	// Token: 0x040015F4 RID: 5620
	EGA_T3SIEGE_RESOURCE_COST_REDUCTION,
	// Token: 0x040015F5 RID: 5621
	EGA_T4INFNATRY_RESOURCE_COST_REDUCTION,
	// Token: 0x040015F6 RID: 5622
	EGA_T4RANGED_RESOURCE_COST_REDUCTION,
	// Token: 0x040015F7 RID: 5623
	EGA_T4CAVALRY_RESOURCE_COST_REDUCTION,
	// Token: 0x040015F8 RID: 5624
	EGA_T4SIEGE_RESOURCE_COST_REDUCTION,
	// Token: 0x040015F9 RID: 5625
	EGA_T1TRAP_SALVAGE_RANGE,
	// Token: 0x040015FA RID: 5626
	EGA_T2TRAP_SALVAGE_RANGE,
	// Token: 0x040015FB RID: 5627
	EGA_T3TRAP_SALVAGE_RANGE,
	// Token: 0x040015FC RID: 5628
	EGA_T4TRAP_SALVAGE_RANGE,
	// Token: 0x040015FD RID: 5629
	EGA_TRAP_SALVAGE_RANGE,
	// Token: 0x040015FE RID: 5630
	EGA_RALLY_TIME_REDUCTION,
	// Token: 0x040015FF RID: 5631
	EGA_REINFORCE_MARCH_SPEED,
	// Token: 0x04001600 RID: 5632
	EGA_RALLY_TROOP_ATK,
	// Token: 0x04001601 RID: 5633
	EGA_HERO_EXP_BONUS,
	// Token: 0x04001602 RID: 5634
	EGA_EXECUTION_BUFF_DURATION,
	// Token: 0x04001603 RID: 5635
	EGA_LORD_EXP_RESERVE,
	// Token: 0x04001604 RID: 5636
	EGA_COMBAT_GROUP_CAPACITY,
	// Token: 0x04001605 RID: 5637
	EGA_ENEMY_ATTACKHOME_ATK_DEBUFF,
	// Token: 0x04001606 RID: 5638
	EGA_CRIFTING_COST_MONEY_REDUCTION,
	// Token: 0x04001607 RID: 5639
	EGA_BASE_TROOP_AMOUNT,
	// Token: 0x04001608 RID: 5640
	EGA_MAX_WALL_DEFENCE,
	// Token: 0x04001609 RID: 5641
	EGA_RESOURCE_PROTCTION,
	// Token: 0x0400160A RID: 5642
	EGA_WALL_DEFENCE_ADD,
	// Token: 0x0400160B RID: 5643
	EGA_WALL_REPAIR_SPEED,
	// Token: 0x0400160C RID: 5644
	EGA_EXECUTE_TIME,
	// Token: 0x0400160D RID: 5645
	EGA_RESOURCE_TRADE_TAX_REDUCTION,
	// Token: 0x0400160E RID: 5646
	EGA_MONSTERPOINT_RECOVER,
	// Token: 0x0400160F RID: 5647
	EGA_MONSTERPOINT_COST_REDUCTION,
	// Token: 0x04001610 RID: 5648
	EGA_MONSTERPOINT_MAX,
	// Token: 0x04001611 RID: 5649
	EGA_MONSTERKILL_COMBOMAX,
	// Token: 0x04001612 RID: 5650
	EGA_MONSTERKILL_ATK,
	// Token: 0x04001613 RID: 5651
	EGA_MONSTERKILL_HP_ADD,
	// Token: 0x04001614 RID: 5652
	EGA_MONSTERKILL_CURE_ADD,
	// Token: 0x04001615 RID: 5653
	EGA_MONSTERKILL_INIT_MP,
	// Token: 0x04001616 RID: 5654
	EGA_QUICK_EQUIP_SET,
	// Token: 0x04001617 RID: 5655
	EGA_QUICK_TALENT_SET,
	// Token: 0x04001618 RID: 5656
	EGA_RESOURCE_PRODUCTION_DEBUFF,
	// Token: 0x04001619 RID: 5657
	EGA_FOOD_PRODUCTION_PERCENT_DEBUFF,
	// Token: 0x0400161A RID: 5658
	EGA_ROCK_PRODUCTION_PERCENT_DEBUFF,
	// Token: 0x0400161B RID: 5659
	EGA_WOOD_PRODUCTION_PERCENT_DEBUFF,
	// Token: 0x0400161C RID: 5660
	EGA_STEEL_PRODUCTION_PERCENT_DEBUFF,
	// Token: 0x0400161D RID: 5661
	EGA_MONEY_PRODUCTION_PERCENT_DEBUFF,
	// Token: 0x0400161E RID: 5662
	EGA_CONSTRUCTION_SPEED_DEBUFF,
	// Token: 0x0400161F RID: 5663
	EGA_RESEARCH_SPEED_DEBUFF,
	// Token: 0x04001620 RID: 5664
	EGA_TROOP_TRAINING_SPEED_DEBUFF,
	// Token: 0x04001621 RID: 5665
	EGE_NOUSE,
	// Token: 0x04001622 RID: 5666
	EGE_HOSPITAL_CAPACITY_PERCENT,
	// Token: 0x04001623 RID: 5667
	EGE_MONEY_CAPACITY_PERCENT,
	// Token: 0x04001624 RID: 5668
	EGE_NPCCITY_REWARD_SPEED,
	// Token: 0x04001625 RID: 5669
	EGE_NPCCITY_RALLY_SPEED,
	// Token: 0x04001626 RID: 5670
	EGE_NPCCITY_JOINRALLY_SPEED,
	// Token: 0x04001627 RID: 5671
	EGE_NPCCITY_TROOP_AMOUNT,
	// Token: 0x04001628 RID: 5672
	EGE_NPCCITY_TROOP_ATK,
	// Token: 0x04001629 RID: 5673
	EGE_NPCCITY_TROOP_DEF,
	// Token: 0x0400162A RID: 5674
	EGE_NPCCITY_TROOP_HEALTH,
	// Token: 0x0400162B RID: 5675
	EGE_SHELTER_TROOP_AMOUNT,
	// Token: 0x0400162C RID: 5676
	EGE_MORALE_MAX,
	// Token: 0x0400162D RID: 5677
	EGE_TALENT_POINT,
	// Token: 0x0400162E RID: 5678
	EGE_DESHIELD_ATK,
	// Token: 0x0400162F RID: 5679
	EGE_DESHIELD_DEF,
	// Token: 0x04001630 RID: 5680
	EGE_DESHIELD_HEALTH,
	// Token: 0x04001631 RID: 5681
	EGE_INDEMNIFY_RESOURCE_ADD,
	// Token: 0x04001632 RID: 5682
	EGE_FOOD_CAPACITY_PERCENT,
	// Token: 0x04001633 RID: 5683
	EGE_ROCK_CAPACITY_PERCENT,
	// Token: 0x04001634 RID: 5684
	EGE_WOOD_CAPACITY_PERCENT,
	// Token: 0x04001635 RID: 5685
	EGE_STEEL_CAPACITY_PERCENT,
	// Token: 0x04001636 RID: 5686
	EGE_PETLOEETRY_TRAINING_CAPACITY,
	// Token: 0x04001637 RID: 5687
	EGE_PETRSS_PRODUCTION,
	// Token: 0x04001638 RID: 5688
	EGE_PETRSS_CAPACITY,
	// Token: 0x04001639 RID: 5689
	EGE_PETLOEETRY_MAKE_SPEED,
	// Token: 0x0400163A RID: 5690
	EGE_PETTRAININGEXP_EXP_PERCENT,
	// Token: 0x0400163B RID: 5691
	EGE_PETTRAININGEXP_PET_NUM,
	// Token: 0x0400163C RID: 5692
	EGE_PETTRAININGEXP_TIME,
	// Token: 0x0400163D RID: 5693
	EGA_PETSKILL_SKILLCASTITEMMAKE,
	// Token: 0x0400163E RID: 5694
	EGE_PETRSS_PRODUCTION_PERCENT,
	// Token: 0x0400163F RID: 5695
	EGE_PETRSS_CAPACITY_PERCENT,
	// Token: 0x04001640 RID: 5696
	EGE_PETLOEETRY_LV1_MAKE_COST_REDUCTION,
	// Token: 0x04001641 RID: 5697
	EGE_PETLOEETRY_LV2_MAKE_COST_REDUCTION,
	// Token: 0x04001642 RID: 5698
	EGE_PETLOEETRY_LV3_MAKE_COST_REDUCTION,
	// Token: 0x04001643 RID: 5699
	EGE_PETLOEETRY_LV4_MAKE_COST_REDUCTION,
	// Token: 0x04001644 RID: 5700
	EGE_PETSKILL_USEEXPITEM_ADD,
	// Token: 0x04001645 RID: 5701
	EGE_PETSKILL_MAKE_SKILLSTONE_SPEED,
	// Token: 0x04001646 RID: 5702
	EGA_PETSKILL_SHIELD_TIME,
	// Token: 0x04001647 RID: 5703
	EGA_LORD_ESCAPE,
	// Token: 0x04001648 RID: 5704
	EGA_ENEMY_ATTACKHOME_DESHIELDTIME,
	// Token: 0x04001649 RID: 5705
	EGA_RESOURCE_PRODUCTION_CURSE,
	// Token: 0x0400164A RID: 5706
	EGA_MARCH_SPEED_CURSE,
	// Token: 0x0400164B RID: 5707
	EGA_RESOURCE_TRADE_CAPACITY_PERCENT,
	// Token: 0x0400164C RID: 5708
	EGA_PETSKILL_RALLY_CAPACITY,
	// Token: 0x0400164D RID: 5709
	EGA_INFANTRY_ATK_WITHLORD,
	// Token: 0x0400164E RID: 5710
	EGA_CAVALRY_ATK_WITHLORD,
	// Token: 0x0400164F RID: 5711
	EGA_RANGED_ATK_WITHLORD,
	// Token: 0x04001650 RID: 5712
	EGA_SIEGE_ATK_WITHLORD,
	// Token: 0x04001651 RID: 5713
	EGA_INFANTRY_DEF_WITHLORD,
	// Token: 0x04001652 RID: 5714
	EGA_CAVALRY_DEF_WITHLORD,
	// Token: 0x04001653 RID: 5715
	EGA_RANGED_DEF_WITHLORD,
	// Token: 0x04001654 RID: 5716
	EGA_SIEGE_DEF_WITHLORD,
	// Token: 0x04001655 RID: 5717
	EGA_INFANTRY_HEALTH_WITHLORD,
	// Token: 0x04001656 RID: 5718
	EGA_CAVALRY_HEALTH_WITHLORD,
	// Token: 0x04001657 RID: 5719
	EGA_RANGED_HEALTH_WITHLORD,
	// Token: 0x04001658 RID: 5720
	EGA_SIEGE_HEALTH_WITHLORD,
	// Token: 0x04001659 RID: 5721
	EGA_DESHIELD_INFANTRY_ATK,
	// Token: 0x0400165A RID: 5722
	EGA_DESHIELD_CAVALRY_ATK,
	// Token: 0x0400165B RID: 5723
	EGA_DESHIELD_RANGED_ATK,
	// Token: 0x0400165C RID: 5724
	EGA_DESHIELD_SIEGE_ATK,
	// Token: 0x0400165D RID: 5725
	EGA_DESHIELD_INFANTRY_DEF,
	// Token: 0x0400165E RID: 5726
	EGA_DESHIELD_CAVALRY_DEF,
	// Token: 0x0400165F RID: 5727
	EGA_DESHIELD_RANGED_DEF,
	// Token: 0x04001660 RID: 5728
	EGA_DESHIELD_SIEGE_DEF,
	// Token: 0x04001661 RID: 5729
	EGA_DESHIELD_INFANTRY_HEALTH,
	// Token: 0x04001662 RID: 5730
	EGA_DESHIELD_CAVALRY_HEALTH,
	// Token: 0x04001663 RID: 5731
	EGA_DESHIELD_RANGED_HEALTH,
	// Token: 0x04001664 RID: 5732
	EGA_DESHIELD_SIEGE_HEALTH,
	// Token: 0x04001665 RID: 5733
	EGA_RALLY_COMBATPOWER_UPBOUND,
	// Token: 0x04001666 RID: 5734
	EGA_JOINRALLY_COMBATPOWER,
	// Token: 0x04001667 RID: 5735
	EGA_MAX
}