﻿using System;

// Token: 0x0200070E RID: 1806
public enum EStateName : byte
{
	// Token: 0x04006BEF RID: 27631
	MOVING,
	// Token: 0x04006BF0 RID: 27632
	IDLE,
	// Token: 0x04006BF1 RID: 27633
	IDLE_FASTRUN,
	// Token: 0x04006BF2 RID: 27634
	IDLE_WITHOUT_CLUMP,
	// Token: 0x04006BF3 RID: 27635
	MELEE_FIGHT,
	// Token: 0x04006BF4 RID: 27636
	MELEE_FIGHT_IMMEDIATE,
	// Token: 0x04006BF5 RID: 27637
	RANGE_FIGHT,
	// Token: 0x04006BF6 RID: 27638
	RANGE_FIGHT_WALL,
	// Token: 0x04006BF7 RID: 27639
	MELEE_FIGHT_WALL,
	// Token: 0x04006BF8 RID: 27640
	TRYFIGHT,
	// Token: 0x04006BF9 RID: 27641
	MOVETO_TARGET,
	// Token: 0x04006BFA RID: 27642
	DIE,
	// Token: 0x04006BFB RID: 27643
	DYING,
	// Token: 0x04006BFC RID: 27644
	LORD_DYING,
	// Token: 0x04006BFD RID: 27645
	LORD_DIE,
	// Token: 0x04006BFE RID: 27646
	SPREAD,
	// Token: 0x04006BFF RID: 27647
	ARCHER_SPREAD,
	// Token: 0x04006C00 RID: 27648
	VICTORY,
	// Token: 0x04006C01 RID: 27649
	MOVE_OUTOF_TOWN,
	// Token: 0x04006C02 RID: 27650
	JUMP_FROM_WALL,
	// Token: 0x04006C03 RID: 27651
	LOSETARGET,
	// Token: 0x04006C04 RID: 27652
	GO_CAPTIVING,
	// Token: 0x04006C05 RID: 27653
	ATTACKER_RUN_AWAY,
	// Token: 0x04006C06 RID: 27654
	DEFENSER_CHASING,
	// Token: 0x04006C07 RID: 27655
	DEFENSER_RUN_AWAY,
	// Token: 0x04006C08 RID: 27656
	ATTACKER_CHASING,
	// Token: 0x04006C09 RID: 27657
	OUTSIDE_HERO_DISPLAY,
	// Token: 0x04006C0A RID: 27658
	KICKBACK
}