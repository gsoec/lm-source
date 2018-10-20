using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x02000464 RID: 1124
public class PetBuff : GUIWindow
{
	// Token: 0x060016C3 RID: 5827 RVA: 0x002734A8 File Offset: 0x002716A8
	protected void SetSkill(bool Casting = true)
	{
		if (!Casting)
		{
			PetBuff.Refreshed = true;
		}
		if (!PetBuff.SkillInit)
		{
			PetBuff.UpdateSkill(0);
		}
		PetBuff.bCasting = Casting;
		for (int i = 0; i < PetBuff.PetSkillList.Length; i++)
		{
			if (PetBuff.PetSkillList[i] != null)
			{
				PetBuff.PetSkillList[i].Sort(PetBuff.PSC);
			}
		}
	}

	// Token: 0x060016C4 RID: 5828 RVA: 0x00273510 File Offset: 0x00271710
	public static void Clear()
	{
		PetBuff.SkillInit = false;
	}

	// Token: 0x060016C5 RID: 5829 RVA: 0x00273518 File Offset: 0x00271718
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (bOK && door)
		{
			door.OpenMenu(EGUIWindow.UI_PetFusion, 1, arg1, false);
		}
	}

	// Token: 0x060016C6 RID: 5830 RVA: 0x00273558 File Offset: 0x00271758
	public static void Update(int arg1, int arg2 = 0, bool bCast = false)
	{
		if (bCast)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetSkill, arg1, 0);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetBuff, arg1, 0);
	}

	// Token: 0x060016C7 RID: 5831 RVA: 0x00273590 File Offset: 0x00271790
	public static bool ShowActive(byte Type = 1)
	{
		return PetBuff.ActiveSkill[(int)(((int)Type >= PetBuff.ActiveSkill.Length) ? 0 : Type)] > 0;
	}

	// Token: 0x060016C8 RID: 5832 RVA: 0x002735B0 File Offset: 0x002717B0
	public static bool CheckActive(int PointID, byte Type = 1)
	{
		return PetBuff.ShowActive(Type) && GUIManager.Instance.OpenMenu(EGUIWindow.UI_PetSkill, PointID, (int)(Type + 1), false, true, false) != null;
	}

	// Token: 0x060016C9 RID: 5833 RVA: 0x002735EC File Offset: 0x002717EC
	public static bool CheckNegative()
	{
		return !PetBuff.Refreshed;
	}

	// Token: 0x060016CA RID: 5834 RVA: 0x002735F8 File Offset: 0x002717F8
	public static bool UpdateSkill(int arg = 0)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			door.m_PetSkillBtnFlashGO.GetComponent<uTweener>().enabled = !PetBuff.Refreshed;
			door.m_PetSkillBtnFlashGO.GetComponent<Image>().color = Color.white;
		}
		if (arg > 0 || !PetBuff.SkillInit)
		{
			PetBuff.SkillInit = true;
			for (int i = 0; i < PetBuff.ActiveSkill.Length; i++)
			{
				PetBuff.ActiveSkill[i] = 0;
			}
			for (int j = 0; j < PetBuff.PetSkillList.Length; j++)
			{
				if (PetBuff.PetSkillList[j] == null)
				{
					PetBuff.PetSkillList[j] = new List<PetBuff.PetSkillData>();
				}
				else
				{
					PetBuff.PetSkillList[j].Clear();
				}
			}
			for (int k = 0; k < (int)PetManager.Instance.PetDataCount; k++)
			{
				PetData petData = PetManager.Instance.GetPetData((int)((byte)k));
				if (petData != null)
				{
					PetTbl recordByKey = PetManager.Instance.PetTable.GetRecordByKey(petData.ID);
					byte b = 0;
					while (recordByKey.PetSkill != null && (int)b < recordByKey.PetSkill.Length)
					{
						if (recordByKey.PetSkill[(int)b] > 0 && petData.SkillLv != null && (int)b < petData.SkillLv.Length && petData.Enhance >= b)
						{
							PetSkillTbl recordByKey2 = PetManager.Instance.PetSkillTable.GetRecordByKey(recordByKey.PetSkill[(int)b]);
							if (recordByKey2.Subject > 0 && recordByKey2.Type == 1 && recordByKey2.Class >= 1 && (int)recordByKey2.Class <= PetBuff.PetSkillList.Length && (int)recordByKey2.Subject <= PetBuff.ActiveSkill.Length)
							{
								PetBuff.PetSkillList[(int)(recordByKey2.Class - 1)].Add(new PetBuff.PetSkillData((uint)recordByKey.PetSkill[(int)b], b, recordByKey2.Subject, petData.ID));
							}
						}
						b += 1;
					}
				}
			}
			if (arg > 0)
			{
				PetBuff.Update(6, 0, true);
			}
		}
		for (int l = 0; l < PetBuff.ActiveSkill.Length; l++)
		{
			if (PetBuff.ActiveSkill[l] > 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060016CB RID: 5835 RVA: 0x00273848 File Offset: 0x00271A48
	public static void UpdateFatigue()
	{
		long num = DataManager.Instance.ServerTime - DataManager.Instance.RoleAttr.LastPetSkillFatigueTime;
		if (DataManager.Instance.RoleAttr.PetSkillFatigue > 0 && DataManager.Instance.RoleAttr.FatigueRestoreSpeed > 0 && num > (long)DataManager.Instance.RoleAttr.FatigueRestoreSpeed)
		{
			if ((long)DataManager.Instance.RoleAttr.PetSkillFatigue < num / (long)DataManager.Instance.RoleAttr.FatigueRestoreSpeed)
			{
				PetManager.Instance.SetSkillFatigue(0, 0, 0L, true);
			}
			else
			{
				PetManager.Instance.SetSkillFatigue((ushort)((long)DataManager.Instance.RoleAttr.PetSkillFatigue - num / (long)DataManager.Instance.RoleAttr.FatigueRestoreSpeed), DataManager.Instance.RoleAttr.FatigueRestoreSpeed, DataManager.Instance.ServerTime - (long)((int)num % (int)DataManager.Instance.RoleAttr.FatigueRestoreSpeed), true);
			}
		}
	}

	// Token: 0x060016CC RID: 5836 RVA: 0x00273948 File Offset: 0x00271B48
	public static void Update()
	{
		PetBuff.UpdateSkill(1);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 26, 0);
	}

	// Token: 0x060016CD RID: 5837 RVA: 0x00273960 File Offset: 0x00271B60
	public static bool ShowButt(int arg)
	{
		return (PetBuff.UpdateSkill(arg) && PetBuff.ShowActive(0)) || PetManager.Instance.BuffImmune.BeginTime > 0L || PetManager.Instance.NegBuff.Count > 0 || DataManager.Instance.RoleAttr.PetSkillFatigue > 0;
	}

	// Token: 0x060016CE RID: 5838 RVA: 0x002739C4 File Offset: 0x00271BC4
	public static ushort CheckCount()
	{
		return (ushort)(PetManager.Instance.PosBuff.Count + PetManager.Instance.NegBuff.Count + ((PetManager.Instance.BuffImmune.BeginTime <= 0L) ? 0 : 1));
	}

	// Token: 0x060016CF RID: 5839 RVA: 0x00273A10 File Offset: 0x00271C10
	public static bool CheckFlash()
	{
		return PetManager.Instance.NegBuff.Count > 0;
	}

	// Token: 0x060016D0 RID: 5840 RVA: 0x00273A24 File Offset: 0x00271C24
	public static long CheckSkillBuff(ushort Id, out uint Require)
	{
		Require = 480u;
		if (Id == 0)
		{
			return (DataManager.Instance.ServerTime >= PetManager.Instance.BuffImmune.BeginTime + (long)((ulong)PetManager.Instance.BuffImmune.RequireTime)) ? 0L : (PetManager.Instance.BuffImmune.BeginTime + (long)((ulong)PetManager.Instance.BuffImmune.RequireTime) - DataManager.Instance.ServerTime);
		}
		byte index;
		if (PetManager.Instance.PosBuff.TryGetValue(Id, out index) || PetManager.Instance.NegBuff.TryGetValue(Id, out index))
		{
			Require = PetManager.Instance.BuffInfo[(int)index].RequireTime;
			return (DataManager.Instance.ServerTime >= PetManager.Instance.BuffInfo[(int)index].BeginTime + (long)((ulong)PetManager.Instance.BuffInfo[(int)index].RequireTime)) ? 0L : (PetManager.Instance.BuffInfo[(int)index].BeginTime + (long)((ulong)PetManager.Instance.BuffInfo[(int)index].RequireTime) - DataManager.Instance.ServerTime);
		}
		return 0L;
	}

	// Token: 0x060016D1 RID: 5841 RVA: 0x00273B74 File Offset: 0x00271D74
	public static long CheckSkillBuff(ushort Id = 0)
	{
		if (Id == 0)
		{
			return (DataManager.Instance.ServerTime >= PetManager.Instance.BuffImmune.BeginTime + (long)((ulong)PetManager.Instance.BuffImmune.RequireTime)) ? 0L : (PetManager.Instance.BuffImmune.BeginTime + (long)((ulong)PetManager.Instance.BuffImmune.RequireTime) - DataManager.Instance.ServerTime);
		}
		byte index;
		if (PetManager.Instance.PosBuff.TryGetValue(Id, out index) || PetManager.Instance.NegBuff.TryGetValue(Id, out index))
		{
			return (DataManager.Instance.ServerTime >= PetManager.Instance.BuffInfo[(int)index].BeginTime + (long)((ulong)PetManager.Instance.BuffInfo[(int)index].RequireTime)) ? 0L : (PetManager.Instance.BuffInfo[(int)index].BeginTime + (long)((ulong)PetManager.Instance.BuffInfo[(int)index].RequireTime) - DataManager.Instance.ServerTime);
		}
		return 0L;
	}

	// Token: 0x060016D2 RID: 5842 RVA: 0x00273CA0 File Offset: 0x00271EA0
	public long CheckSkillBuff(byte idx)
	{
		if ((int)idx < PetManager.Instance.BuffInfo.Count && DataManager.Instance.ServerTime < PetManager.Instance.BuffInfo[(int)idx].BeginTime + (long)((ulong)PetManager.Instance.BuffInfo[(int)idx].RequireTime))
		{
			return PetManager.Instance.BuffInfo[(int)idx].BeginTime + (long)((ulong)PetManager.Instance.BuffInfo[(int)idx].RequireTime) - DataManager.Instance.ServerTime;
		}
		return 0L;
	}

	// Token: 0x060016D3 RID: 5843 RVA: 0x00273D44 File Offset: 0x00271F44
	public static long CheckSkillCD(ushort id)
	{
		long num = 0L;
		if (id > 0 && PetManager.Instance.CDFinder != null && PetManager.Instance.CDFinder.TryGetValue(id, out num))
		{
			if (DataManager.Instance.ServerTime < num)
			{
				return num - DataManager.Instance.ServerTime;
			}
			num = 0L;
			PetManager.Instance.CDFinder.Remove(id);
			for (int i = 0; i < PetManager.Instance.CoolDown.Count; i++)
			{
				if (PetManager.Instance.CoolDown[i].SkillID == id)
				{
					PetManager.Instance.CoolDown[i].Clear();
					return num;
				}
			}
		}
		return num;
	}

	// Token: 0x04004439 RID: 17465
	public static bool bCasting;

	// Token: 0x0400443A RID: 17466
	public static bool Refreshed;

	// Token: 0x0400443B RID: 17467
	public static bool SkillInit;

	// Token: 0x0400443C RID: 17468
	public static int[] ActiveSkill = new int[2];

	// Token: 0x0400443D RID: 17469
	public static List<PetBuff.PetSkillData>[] PetSkillList = new List<PetBuff.PetSkillData>[5];

	// Token: 0x0400443E RID: 17470
	public static List<PetBuff.PetSkill> PetSkills = new List<PetBuff.PetSkill>();

	// Token: 0x0400443F RID: 17471
	public static PetBuff.PetSkillComparer PSC = new PetBuff.PetSkillComparer();

	// Token: 0x02000465 RID: 1125
	public struct SkillPanelItem
	{
		// Token: 0x060016D4 RID: 5844 RVA: 0x00273E0C File Offset: 0x0027200C
		public void Rebuilt()
		{
			if (this.Text != null)
			{
				for (int i = 0; i < this.Text.Length; i++)
				{
					if (this.Text[i])
					{
						this.Text[i].enabled = false;
						this.Text[i].enabled = true;
					}
				}
			}
		}

		// Token: 0x04004440 RID: 17472
		public int ID;

		// Token: 0x04004441 RID: 17473
		public bool Init;

		// Token: 0x04004442 RID: 17474
		public ushort CoolDown;

		// Token: 0x04004443 RID: 17475
		public GameObject Item;

		// Token: 0x04004444 RID: 17476
		public Text[] Text;
	}

	// Token: 0x02000466 RID: 1126
	public struct PetSkillData
	{
		// Token: 0x060016D5 RID: 5845 RVA: 0x00273E6C File Offset: 0x0027206C
		public PetSkillData(uint id, byte slot, byte sub, ushort pet)
		{
			this.Id = id;
			this.Pet = pet;
			this.Slot = slot;
			this.Subject = sub;
			PetBuff.ActiveSkill[(int)(sub - 1)]++;
		}

		// Token: 0x04004445 RID: 17477
		public uint Id;

		// Token: 0x04004446 RID: 17478
		public byte Slot;

		// Token: 0x04004447 RID: 17479
		public ushort Pet;

		// Token: 0x04004448 RID: 17480
		public byte Subject;
	}

	// Token: 0x02000467 RID: 1127
	public struct PetSkill
	{
		// Token: 0x060016D6 RID: 5846 RVA: 0x00273EA0 File Offset: 0x002720A0
		public PetSkill(uint id, int idx, byte cls, byte slot, ushort pet)
		{
			this.ID = id;
			this.Idx = idx;
			this.Class = cls;
			this.Slot = slot;
			this.Pet = pet;
			this.Power = 0UL;
		}

		// Token: 0x04004449 RID: 17481
		public uint ID;

		// Token: 0x0400444A RID: 17482
		public int Idx;

		// Token: 0x0400444B RID: 17483
		public byte Slot;

		// Token: 0x0400444C RID: 17484
		public byte Class;

		// Token: 0x0400444D RID: 17485
		public ushort Pet;

		// Token: 0x0400444E RID: 17486
		public ulong Power;
	}

	// Token: 0x02000468 RID: 1128
	public class PetSkillComparer : IComparer<PetBuff.PetSkillData>
	{
		// Token: 0x060016D8 RID: 5848 RVA: 0x00273ED8 File Offset: 0x002720D8
		public int Compare(PetBuff.PetSkillData x, PetBuff.PetSkillData y)
		{
			return (x.Id <= y.Id) ? ((x.Id >= y.Id) ? 0 : -1) : 1;
		}
	}
}
