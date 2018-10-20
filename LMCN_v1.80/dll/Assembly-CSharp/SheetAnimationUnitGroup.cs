using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000257 RID: 599
public class SheetAnimationUnitGroup : ISheetAnimationUnitGroup
{
	// Token: 0x06000A9A RID: 2714 RVA: 0x000E43F8 File Offset: 0x000E25F8
	public SheetAnimationUnitGroup()
	{
		this.gameObject = new GameObject("AnimUnitGroup");
		this.transform = this.gameObject.transform;
	}

	// Token: 0x06000A9C RID: 2716 RVA: 0x000E4484 File Offset: 0x000E2684
	public static void InitResource()
	{
		if (SheetAnimationUnitGroup.kdab == null)
		{
			SheetAnimationUnitGroup.kdab = AssetManager.GetAssetBundle("UI/KDUnit", 0L);
			SheetAnimationUnitGroup.sharedMat = (SheetAnimationUnitGroup.kdab.Load("KDUnit_m") as Material);
			SheetAnimationUnitGroup.sharedMat.renderQueue = 2660;
			UnityEngine.Object[] array = SheetAnimationUnitGroup.kdab.LoadAll(typeof(Sprite));
			uint num = 0u;
			int num2 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				uint num3 = 0u;
				uint.TryParse(array[i].name, out num3);
				uint num4 = (uint)(num3 / 100f);
				bool flag = i == array.Length - 1;
				if (flag || num4 != num)
				{
					int num5 = (!flag) ? (i - num2) : (i - num2 + 1);
					Sprite[] array2 = new Sprite[num5];
					for (int j = 0; j < num5; j++)
					{
						array2[j] = (Sprite)array[num2 + j];
					}
					SheetAnimationUnitGroup.AnimMap.Add(num, array2);
					num2 = i;
					num = num4;
				}
			}
		}
	}

	// Token: 0x06000A9D RID: 2717 RVA: 0x000E459C File Offset: 0x000E279C
	public static void InitSoccerRes()
	{
		if (SheetAnimationUnitGroup.soccer_ab == null)
		{
			SheetAnimationUnitGroup.soccer_ab = AssetManager.GetAssetBundle("UI/SoccerUnit", 0L);
			SheetAnimationUnitGroup.sharedSoccerMat = (SheetAnimationUnitGroup.soccer_ab.Load("SoccerUnit_m") as Material);
			SheetAnimationUnitGroup.sharedSoccerMat.renderQueue = 2660;
			UnityEngine.Object[] array = SheetAnimationUnitGroup.soccer_ab.LoadAll(typeof(Sprite));
			uint num = 130u;
			int num2 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				uint num3 = 0u;
				uint.TryParse(array[i].name, out num3);
				uint num4 = (uint)(num3 / 100f);
				bool flag = i == array.Length - 1;
				if (flag || num4 != num)
				{
					int num5 = (!flag) ? (i - num2) : (i - num2 + 1);
					Sprite[] array2 = new Sprite[num5];
					for (int j = 0; j < num5; j++)
					{
						array2[j] = (Sprite)array[num2 + j];
					}
					SheetAnimationUnitGroup.AnimMap.Add(num, array2);
					num2 = i;
					num = num4;
				}
			}
		}
	}

	// Token: 0x06000A9E RID: 2718 RVA: 0x000E46B8 File Offset: 0x000E28B8
	public Material GetSoccerSharedMat()
	{
		SheetAnimationUnitGroup.InitSoccerRes();
		return SheetAnimationUnitGroup.sharedSoccerMat;
	}

	// Token: 0x06000A9F RID: 2719 RVA: 0x000E46C4 File Offset: 0x000E28C4
	public static void FreeResource()
	{
		for (int i = 0; i < SheetAnimationUnitGroup.m_FreeList.Count; i++)
		{
			UnityEngine.Object.Destroy(SheetAnimationUnitGroup.m_FreeList[i].gameObject);
		}
		SheetAnimationUnitGroup.m_FreeList.Clear();
	}

	// Token: 0x06000AA0 RID: 2720 RVA: 0x000E470C File Offset: 0x000E290C
	public override int Update(float deltaTime)
	{
		int num = 0;
		for (int i = 0; i < this.Count; i++)
		{
			if (this.animUnit[i] != null)
			{
				int num2 = this.animUnit[i].Update(deltaTime);
				if (num2 != 0)
				{
					num |= 1 << num2 - 1;
				}
			}
		}
		if ((num & 1) != 0 && this.Count > 0 && this.animUnit[0].SoccerUnit == 3)
		{
			this.animUnit[0].gameObject.SetActive(false);
		}
		return num;
	}

	// Token: 0x06000AA1 RID: 2721 RVA: 0x000E47A0 File Offset: 0x000E29A0
	public override void RecoverUnit()
	{
		for (int i = 0; i < this.Count; i++)
		{
			if (this.animUnit[i] != null)
			{
				SheetAnimationUnit sheetAnimationUnit = this.animUnit[i];
				this.animUnit[i] = null;
				sheetAnimationUnit.transform.parent = null;
				sheetAnimationUnit.gameObject.SetActive(false);
				SheetAnimationUnitGroup.m_FreeList.Add(sheetAnimationUnit);
			}
		}
		this.Count = 0;
	}

	// Token: 0x06000AA2 RID: 2722 RVA: 0x000E4810 File Offset: 0x000E2A10
	public static Sprite[] GetActionSpriteArray(byte Side, byte lineFlag, float angle)
	{
		byte b = 0;
		bool spriteDirFromAngle = SheetAnimationUnitGroup.getSpriteDirFromAngle(angle, out b);
		ushort inKey = 0;
		switch (lineFlag)
		{
		case 5:
		case 6:
		case 10:
		case 11:
		case 14:
		case 15:
		case 17:
		case 20:
			inKey = 5;
			break;
		case 7:
			inKey = 4;
			break;
		case 8:
		case 18:
			inKey = 30;
			break;
		case 9:
		case 19:
			inKey = 9;
			Side = 0;
			break;
		case 12:
			inKey = 7;
			break;
		case 13:
			inKey = 1;
			break;
		case 16:
			inKey = 3;
			break;
		case 21:
			inKey = 2;
			break;
		case 22:
			inKey = 10;
			Side = 0;
			break;
		case 23:
			inKey = 6;
			b = 0;
			break;
		case 24:
		case 25:
			inKey = 6;
			b = 0;
			break;
		case 26:
			inKey = 31;
			b = 0;
			break;
		case 27:
			inKey = 11;
			b = 0;
			Side = 0;
			break;
		}
		MarchPaltform recordByKey = DataManager.Instance.MarchPaltformTable.GetRecordByKey(inKey);
		int num = 0;
		if (b == 0)
		{
			num = (int)recordByKey.UpStartID;
		}
		else if (b == 1)
		{
			num = (int)recordByKey.UpRightStartID;
		}
		else if (b == 2)
		{
			num = (int)recordByKey.RightStartID;
		}
		else if (b == 3)
		{
			num = (int)recordByKey.DownRightStartID;
		}
		else if (b == 4)
		{
			num = (int)recordByKey.DownStartID;
		}
		uint actionID = SheetAnimationUnitGroup.GetActionID(Side, DataManager.Instance.MarchOffsetTable.GetRecordByKey((ushort)num).Kind, b);
		return (!SheetAnimationUnitGroup.AnimMap.ContainsKey(actionID)) ? null : SheetAnimationUnitGroup.AnimMap[actionID];
	}

	// Token: 0x06000AA3 RID: 2723 RVA: 0x000E49D0 File Offset: 0x000E2BD0
	public Color32 GetColorByMapDamageTb(ushort TbID, byte index)
	{
		MapDamageEffTb recordByKey = PetManager.Instance.MapDamageEffTable.GetRecordByKey(TbID);
		if (index >= 3)
		{
			return Color.white;
		}
		return new Color32(recordByKey.LineStyle[(int)index].R, recordByKey.LineStyle[(int)index].G, recordByKey.LineStyle[(int)index].B, byte.MaxValue);
	}

	// Token: 0x06000AA4 RID: 2724 RVA: 0x000E4A40 File Offset: 0x000E2C40
	public override void setupAnimUnit(byte Side, byte lineFlag, float angle, byte setupFlag = 0)
	{
		if (this.transform.childCount != 0)
		{
			this.RecoverUnit();
		}
		this.Count = 0;
		this.hasSoccerBall = false;
		byte b = 0;
		bool flag = SheetAnimationUnitGroup.getSpriteDirFromAngle(angle, out b);
		ushort inKey = 0;
		bool reverse = false;
		bool flag2 = (setupFlag & 2) != 0;
		bool flag3 = (setupFlag & 4) != 0;
		bool flag4 = (setupFlag & 8) != 0;
		bool flag5 = (setupFlag & 16) != 0;
		if (flag2)
		{
			inKey = PetManager.Instance.MapDamageEffTable.GetRecordByKey((ushort)lineFlag).PaltformKey;
		}
		else if (flag3)
		{
			inKey = 33;
			reverse = (b == 4 || flag);
			b = ((b != 4) ? b : 0);
		}
		else if (flag4)
		{
			inKey = 36;
		}
		else
		{
			switch (lineFlag)
			{
			case 5:
			case 6:
			case 10:
			case 11:
			case 14:
			case 15:
			case 17:
			case 20:
				inKey = 5;
				break;
			case 7:
				inKey = 4;
				break;
			case 8:
			case 18:
				inKey = 30;
				break;
			case 9:
			case 19:
				inKey = 9;
				break;
			case 12:
				inKey = 7;
				break;
			case 13:
				inKey = 1;
				break;
			case 16:
				inKey = 3;
				break;
			case 21:
				inKey = 2;
				break;
			case 22:
				inKey = 10;
				break;
			case 23:
				inKey = 6;
				flag = false;
				b = 0;
				break;
			case 24:
			case 25:
				inKey = 6;
				flag = false;
				b = 0;
				break;
			case 26:
				inKey = 31;
				flag = false;
				b = 0;
				break;
			case 27:
				inKey = 11;
				flag = false;
				break;
			case 28:
			case 29:
				inKey = 34;
				break;
			case 30:
				if (flag5)
				{
					inKey = 37;
				}
				else
				{
					inKey = 35;
				}
				break;
			}
		}
		if ((setupFlag & 1) != 0)
		{
			flag = true;
		}
		MarchPaltform recordByKey = DataManager.Instance.MarchPaltformTable.GetRecordByKey(inKey);
		int num = 0;
		int num2 = 0;
		if (b == 0)
		{
			num = (int)recordByKey.UpStartID;
			num2 = (int)recordByKey.UpEndID;
		}
		else if (b == 1)
		{
			num = (int)recordByKey.UpRightStartID;
			num2 = (int)recordByKey.UpRightEndID;
		}
		else if (b == 2)
		{
			num = (int)recordByKey.RightStartID;
			num2 = (int)recordByKey.RightEndID;
		}
		else if (b == 3)
		{
			num = (int)recordByKey.DownRightStartID;
			num2 = (int)recordByKey.DownRightEndID;
		}
		else if (b == 4)
		{
			num = (int)recordByKey.DownStartID;
			num2 = (int)recordByKey.DownEndID;
		}
		int num3 = num2 - num;
		for (int i = 0; i <= num3; i++)
		{
			MarchOffset recordByKey2 = DataManager.Instance.MarchOffsetTable.GetRecordByKey((ushort)(num + i));
			float x = (float)recordByKey2.OffsetX * 0.001f * (float)((recordByKey2.SignedX != 0) ? -1 : 1) * (float)((!flag) ? 1 : -1);
			float y = (float)recordByKey2.OffsetY * 0.001f * (float)((recordByKey2.SignedY != 0) ? -1 : 1);
			if (flag2 && (recordByKey2.Kind == 10 || recordByKey2.Kind == 11 || recordByKey2.Kind == 12))
			{
				flag = false;
				int num4 = (int)(recordByKey2.Kind - 10);
				Color value = this.GetColorByMapDamageTb((ushort)lineFlag, (byte)num4);
				this.addAnimUnit(Side, recordByKey2.Kind, b, flag, new Vector3(x, y, 0f), i, false, new Color?(value), new float?(180f + angle), false);
			}
			else
			{
				this.addAnimUnit(Side, recordByKey2.Kind, b, flag, new Vector3(x, y, 0f), i, false, null, null, reverse);
			}
		}
	}

	// Token: 0x06000AA5 RID: 2725 RVA: 0x000E4E24 File Offset: 0x000E3024
	public void setupLandAnimUnit(byte Side, byte lineFlag, int angle)
	{
		this.Count = 0;
		byte b = 0;
		angle = (560 - angle) % 360;
		bool spriteDirFromAngle = SheetAnimationUnitGroup.getSpriteDirFromAngle((float)angle, out b);
		MarchPaltform recordByKey = DataManager.Instance.MarchPaltformTable.GetRecordByKey((ushort)lineFlag);
		int num = 0;
		int num2 = 0;
		if (b == 0)
		{
			num = (int)recordByKey.UpStartID;
			num2 = (int)recordByKey.UpEndID;
		}
		else if (b == 1)
		{
			num = (int)recordByKey.UpRightStartID;
			num2 = (int)recordByKey.UpRightEndID;
		}
		else if (b == 2)
		{
			num = (int)recordByKey.RightStartID;
			num2 = (int)recordByKey.RightEndID;
		}
		else if (b == 3)
		{
			num = (int)recordByKey.DownRightStartID;
			num2 = (int)recordByKey.DownRightEndID;
		}
		else if (b == 4)
		{
			num = (int)recordByKey.DownStartID;
			num2 = (int)recordByKey.DownEndID;
		}
		int num3 = num2 - num;
		int i = 0;
		while (i <= num3)
		{
			MarchOffset recordByKey2 = DataManager.Instance.MarchOffsetTable.GetRecordByKey((ushort)(num + i));
			float x = (float)recordByKey2.OffsetX * 0.001f * (float)((recordByKey2.SignedX != 0) ? -1 : 1) * (float)((!spriteDirFromAngle) ? 1 : -1);
			float y = (float)recordByKey2.OffsetY * 0.001f * (float)((recordByKey2.SignedY != 0) ? -1 : 1);
			switch (recordByKey2.Kind)
			{
			case 5:
				switch (recordByKey2.AttackerDirection)
				{
				case 0:
					this.addAnimUnit(Side, recordByKey2.Kind, 0, spriteDirFromAngle, new Vector3(x, y, 0f), 0, false, null, null, false);
					break;
				case 1:
					this.addAnimUnit(0, recordByKey2.Kind, 0, false, new Vector3(x, y, 0f), 0, false, null, null, false);
					break;
				case 2:
					this.addAnimUnit(0, recordByKey2.Kind, 0, true, new Vector3(x, y, 0f), 0, false, null, null, false);
					break;
				case 3:
					this.addAnimUnit(0, recordByKey2.Kind, 0, false, new Vector3(x, y, 0f), 0, true, null, null, false);
					break;
				case 4:
					this.addAnimUnit(0, recordByKey2.Kind, 0, true, new Vector3(x, y, 0f), 0, true, null, null, false);
					break;
				case 5:
					this.addAnimUnit(1, recordByKey2.Kind, 0, false, new Vector3(x, y, 0f), 0, false, null, null, false);
					break;
				case 6:
					this.addAnimUnit(1, recordByKey2.Kind, 0, true, new Vector3(x, y, 0f), 0, false, null, null, false);
					break;
				case 7:
					this.addAnimUnit(1, recordByKey2.Kind, 0, false, new Vector3(x, y, 0f), 0, true, null, null, false);
					break;
				case 8:
					this.addAnimUnit(1, recordByKey2.Kind, 0, true, new Vector3(x, y, 0f), 0, true, null, null, false);
					break;
				}
				break;
			case 6:
				goto IL_429;
			case 7:
			case 8:
				this.addAnimUnit(0, recordByKey2.Kind, b, spriteDirFromAngle, new Vector3(x, y, 0f), 0, false, null, null, false);
				break;
			case 9:
				this.addAnimUnit(0, recordByKey2.Kind, 0, spriteDirFromAngle, new Vector3(x, y, 0f), 0, false, null, null, false);
				break;
			default:
				goto IL_429;
			}
			IL_463:
			i++;
			continue;
			IL_429:
			this.addAnimUnit(Side, recordByKey2.Kind, b, spriteDirFromAngle, new Vector3(x, y, 0f), 0, false, null, null, false);
			goto IL_463;
		}
	}

	// Token: 0x06000AA6 RID: 2726 RVA: 0x000E52A4 File Offset: 0x000E34A4
	private int IsSoccer(byte Kind)
	{
		return (int)((Kind >= 13 && Kind <= 19) ? this.kindgroup[(int)(Kind - 13)] : 0);
	}

	// Token: 0x06000AA7 RID: 2727 RVA: 0x000E52C8 File Offset: 0x000E34C8
	private SheetAnimationUnit GetFreeUnit(byte Side, byte Kind, byte dir, bool bMirror, bool AttackerDirection = false, bool reverse = false)
	{
		uint actionID = SheetAnimationUnitGroup.GetActionID(Side, Kind, dir);
		if (this.IsSoccer(Kind) != 0)
		{
			SheetAnimationUnitGroup.InitSoccerRes();
		}
		Material material = (this.IsSoccer(Kind) == 0) ? SheetAnimationUnitGroup.sharedMat : SheetAnimationUnitGroup.sharedSoccerMat;
		if (SheetAnimationUnitGroup.m_FreeList.Count == 0)
		{
			return new SheetAnimationUnit(actionID, SheetAnimationUnitGroup.AnimMap, material, bMirror, 1f, AttackerDirection, reverse);
		}
		SheetAnimationUnit sheetAnimationUnit = SheetAnimationUnitGroup.m_FreeList[SheetAnimationUnitGroup.m_FreeList.Count - 1];
		SheetAnimationUnitGroup.m_FreeList.RemoveAt(SheetAnimationUnitGroup.m_FreeList.Count - 1);
		sheetAnimationUnit.ResetUnit(actionID, SheetAnimationUnitGroup.AnimMap, material, bMirror, 1f, AttackerDirection, reverse);
		return sheetAnimationUnit;
	}

	// Token: 0x06000AA8 RID: 2728 RVA: 0x000E5378 File Offset: 0x000E3578
	private void addAnimUnit(byte Side, byte Kind, byte dir, bool bMirror, Vector3 localOffset, int zOrder = 0, bool AttackerDirection = false, Color? blendColor = null, float? extraRotation = null, bool reverse = false)
	{
		this.animUnit[this.Count] = this.GetFreeUnit(Side, Kind, dir, bMirror, AttackerDirection, reverse);
		if (this.animUnit[this.Count] != null)
		{
			this.animUnit[this.Count].transform.parent = this.transform;
			localOffset.z = (float)zOrder * -0.01f;
			this.animUnit[this.Count].transform.localPosition = localOffset;
			this.animUnit[this.Count].transform.localScale = Vector3.one;
			this.animUnit[this.Count].LocalOffset = localOffset;
			this.animUnit[this.Count].kdmr.color = ((blendColor == null) ? Color.white : blendColor.Value);
			if (extraRotation != null)
			{
				this.animUnit[this.Count].transform.Rotate(0f, 0f, extraRotation.Value, Space.World);
			}
			this.Count++;
			if (this.IsSoccer(Kind) == 1)
			{
				this.hasSoccerBall = true;
			}
		}
	}

	// Token: 0x06000AA9 RID: 2729 RVA: 0x000E54B4 File Offset: 0x000E36B4
	public static bool getSpriteDirFromAngle(float angle, out byte dir)
	{
		bool result = false;
		if (angle > 67.5f && (double)angle <= 112.5)
		{
			dir = 0;
		}
		else if (angle > 112.5f && angle <= 157.5f)
		{
			dir = 1;
			result = true;
		}
		else if (angle > 157.5f && angle <= 202.5f)
		{
			dir = 2;
			result = true;
		}
		else if (angle > 202.5f && angle <= 247.5f)
		{
			dir = 3;
			result = true;
		}
		else if (angle > 247.5f && angle <= 292.5f)
		{
			dir = 4;
		}
		else if (angle > 292.5f && angle <= 337.5f)
		{
			dir = 3;
		}
		else if (angle > 337.5f || angle <= 22.5f)
		{
			dir = 2;
		}
		else
		{
			dir = 1;
		}
		return result;
	}

	// Token: 0x06000AAA RID: 2730 RVA: 0x000E55A4 File Offset: 0x000E37A4
	public void resetScale()
	{
		this.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
	}

	// Token: 0x06000AAB RID: 2731 RVA: 0x000E55D0 File Offset: 0x000E37D0
	public void SetColor(Color color)
	{
		for (int i = 0; i < 18; i++)
		{
			if (this.animUnit[i] != null)
			{
				this.animUnit[i].kdmr.color = color;
			}
		}
	}

	// Token: 0x06000AAC RID: 2732 RVA: 0x000E5610 File Offset: 0x000E3810
	public void SetSortOrder(int sortOrder)
	{
		for (int i = 0; i < 18; i++)
		{
			if (this.animUnit[i] != null)
			{
				this.animUnit[i].kdmr.sortingOrder = sortOrder + i;
			}
		}
	}

	// Token: 0x06000AAD RID: 2733 RVA: 0x000E5654 File Offset: 0x000E3854
	public static uint GetActionID(byte Side, byte Kind, byte dir)
	{
		uint num = (uint)((Kind != 5 && Kind != 9 && Kind != 10 && Kind != 11 && Kind != 12 && Kind != 14 && Kind != 17 && Kind != 18 && Kind != 19) ? dir : 0);
		byte b = (Kind != 7 && Kind != 8 && Kind != 9 && Kind != 10 && Kind != 11 && Kind != 12 && Kind != 13 && Kind != 14 && Kind != 17 && Kind != 18 && Kind != 19) ? Side : 0;
		return num + ((uint)(Kind * 10) + (uint)b * 1000u);
	}

	// Token: 0x06000AAE RID: 2734 RVA: 0x000E5720 File Offset: 0x000E3920
	public override bool HasSpecialSimu()
	{
		return this.hasSoccerBall;
	}

	// Token: 0x06000AAF RID: 2735 RVA: 0x000E5728 File Offset: 0x000E3928
	public override void RunSpecialSimuMode(LineNode node)
	{
		byte b = 0;
		SheetAnimationUnitGroup.getSpriteDirFromAngle(node.angle, out b);
		float num = Mathf.Min(node.timeOffset * node.inverseTransferTime, 1f);
		float num2 = Mathf.Min(5f, node.touchDownDistance * 0.5f);
		float num3 = Mathf.Max(0f, GameConstants.CubicBezierCurves(new Vector2(0f, 0f), new Vector2(num2, num2), new Vector2(node.touchDownDistance, num2), new Vector2(node.touchDownDistance, 0f), node.inverseTransferTime, node.timeOffset).y);
		float num4 = 0.5f * num3 * 0.2857143f;
		float num5 = this.CheckValueVaild(Mathf.Max(0.1f, 1f - num4), 1f);
		float num6 = this.CheckValueVaild(1f + num4, 1f);
		for (int i = 0; i < this.Count; i++)
		{
			if (this.animUnit[i] != null && this.animUnit[i].SoccerUnit != 0)
			{
				if (this.animUnit[i].SoccerUnit == 1)
				{
					this.animUnit[i].transform.localPosition = new Vector3(0f, num3, this.animUnit[i].transform.localPosition.z);
					this.animUnit[i].transform.localPosition += this.animUnit[i].LocalOffset;
				}
				if (b != 2 && this.animUnit[i].SoccerUnit == 1)
				{
					this.animUnit[i].transform.localScale = new Vector3(num6, num6, num6);
				}
				if (this.animUnit[i].SoccerUnit == 2)
				{
					this.animUnit[i].transform.localScale = new Vector3(num5, num5, num5);
				}
			}
		}
	}

	// Token: 0x06000AB0 RID: 2736 RVA: 0x000E5938 File Offset: 0x000E3B38
	public override void SampleAnimation(int UnitIndex, float AnimTime)
	{
		if (UnitIndex < this.Count && this.animUnit[UnitIndex] != null)
		{
			this.animUnit[UnitIndex].SampleAnimation(AnimTime);
		}
	}

	// Token: 0x06000AB1 RID: 2737 RVA: 0x000E5964 File Offset: 0x000E3B64
	public float CheckValueVaild(float in_val, float def_val = 1f)
	{
		if (float.IsInfinity(in_val) || float.IsNaN(in_val))
		{
			return def_val;
		}
		return in_val;
	}

	// Token: 0x04002404 RID: 9220
	private const int MAX_SHEETANIM_UNIT = 18;

	// Token: 0x04002405 RID: 9221
	public const float CRUVE_HEIGHT_RATE = 0.2f;

	// Token: 0x04002406 RID: 9222
	public static Dictionary<uint, Sprite[]> AnimMap = new Dictionary<uint, Sprite[]>();

	// Token: 0x04002407 RID: 9223
	public static List<SheetAnimationUnit> m_FreeList = new List<SheetAnimationUnit>(256);

	// Token: 0x04002408 RID: 9224
	public static Material sharedMat = null;

	// Token: 0x04002409 RID: 9225
	private static Material sharedSoccerMat = null;

	// Token: 0x0400240A RID: 9226
	private static AssetBundle kdab = null;

	// Token: 0x0400240B RID: 9227
	private static AssetBundle soccer_ab = null;

	// Token: 0x0400240C RID: 9228
	private SheetAnimationUnit[] animUnit = new SheetAnimationUnit[18];

	// Token: 0x0400240D RID: 9229
	private int Count;

	// Token: 0x0400240E RID: 9230
	private bool hasSoccerBall;

	// Token: 0x0400240F RID: 9231
	public GameObject gameObject;

	// Token: 0x04002410 RID: 9232
	public Transform transform;

	// Token: 0x04002411 RID: 9233
	private readonly byte[] kindgroup = new byte[]
	{
		1,
		2,
		3,
		4,
		5,
		6,
		7
	};
}
