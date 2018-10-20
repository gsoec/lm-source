using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200025A RID: 602
public class SheetAnimationUnitGroupNewbie : ISheetAnimationUnitGroup
{
	// Token: 0x06000AC2 RID: 2754 RVA: 0x000E6FD4 File Offset: 0x000E51D4
	public SheetAnimationUnitGroupNewbie()
	{
		this.gameObject = new GameObject("AnimUnitGroupNewbie");
		this.transform = this.gameObject.transform;
	}

	// Token: 0x06000AC4 RID: 2756 RVA: 0x000E703C File Offset: 0x000E523C
	public static void InitResource()
	{
		SheetAnimationUnitGroupNewbie.sharedMat = new Material(SheetAnimationUnitGroup.sharedMat);
		SheetAnimationUnitGroupNewbie.sharedMat.renderQueue = 3010;
		SheetAnimationUnitGroupNewbie.AnimMap = SheetAnimationUnitGroup.AnimMap;
	}

	// Token: 0x06000AC5 RID: 2757 RVA: 0x000E7074 File Offset: 0x000E5274
	public static void FreeResource()
	{
		for (int i = 0; i < SheetAnimationUnitGroupNewbie.m_FreeList.Count; i++)
		{
			UnityEngine.Object.Destroy(SheetAnimationUnitGroupNewbie.m_FreeList[i].gameObject);
		}
		SheetAnimationUnitGroupNewbie.m_FreeList.Clear();
	}

	// Token: 0x06000AC6 RID: 2758 RVA: 0x000E70BC File Offset: 0x000E52BC
	public override int Update(float deltaTime)
	{
		int num = 0;
		for (int i = 0; i < 18; i++)
		{
			if (this.animUnit[i] != null)
			{
				num += this.animUnit[i].Update(deltaTime);
			}
		}
		return num;
	}

	// Token: 0x06000AC7 RID: 2759 RVA: 0x000E7100 File Offset: 0x000E5300
	public override void RecoverUnit()
	{
		for (int i = 0; i < this.Count; i++)
		{
			if (this.animUnit[i] != null)
			{
				SheetAnimationUnit sheetAnimationUnit = this.animUnit[i];
				this.animUnit[i] = null;
				if (sheetAnimationUnit.transform != null)
				{
					sheetAnimationUnit.transform.parent = null;
				}
				if (sheetAnimationUnit.gameObject != null)
				{
					sheetAnimationUnit.gameObject.SetActive(false);
				}
				SheetAnimationUnitGroupNewbie.m_FreeList.Add(sheetAnimationUnit);
			}
		}
	}

	// Token: 0x06000AC8 RID: 2760 RVA: 0x000E7188 File Offset: 0x000E5388
	public override void setupAnimUnit(byte Side, byte lineFlag, float angle, byte setupFlag = 0)
	{
		this.Count = 0;
		byte b = 0;
		bool flag = SheetAnimationUnitGroupNewbie.getSpriteDirFromAngle(angle, out b);
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
			inKey = 8;
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
		case 26:
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
		case 27:
			inKey = 11;
			flag = false;
			b = 0;
			Side = 0;
			break;
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
			bool flag2 = flag;
			if (GUIManager.Instance.IsArabic)
			{
				flag2 = !flag2;
				if (lineFlag == 0)
				{
					flag2 = !flag2;
				}
			}
			this.addAnimUnit(Side, recordByKey2.Kind, b, flag2, new Vector3(x, y, 0f), i, false);
		}
	}

	// Token: 0x06000AC9 RID: 2761 RVA: 0x000E740C File Offset: 0x000E560C
	private void addAnimUnit(byte Side, byte Kind, byte dir, bool bMirror, Vector3 localOffset, int zOrder = 0, bool AttackerDirection = false)
	{
		uint actionID = SheetAnimationUnitGroup.GetActionID(Side, Kind, dir);
		if (SheetAnimationUnitGroupNewbie.m_FreeList.Count == 0)
		{
			SheetAnimationUnit sheetAnimationUnit = new SheetAnimationUnit(actionID, SheetAnimationUnitGroupNewbie.AnimMap, SheetAnimationUnitGroupNewbie.sharedMat, bMirror, 1f, AttackerDirection, false);
			this.animUnit[this.Count] = sheetAnimationUnit;
		}
		else
		{
			this.animUnit[this.Count] = SheetAnimationUnitGroupNewbie.m_FreeList[SheetAnimationUnitGroupNewbie.m_FreeList.Count - 1];
			SheetAnimationUnitGroupNewbie.m_FreeList.RemoveAt(SheetAnimationUnitGroupNewbie.m_FreeList.Count - 1);
			this.animUnit[this.Count].ResetUnit(actionID, SheetAnimationUnitGroupNewbie.AnimMap, SheetAnimationUnitGroupNewbie.sharedMat, bMirror, 1f, AttackerDirection, false);
		}
		this.animUnit[this.Count].transform.parent = this.transform;
		localOffset.z = (float)zOrder * -0.01f;
		this.animUnit[this.Count].transform.localPosition = localOffset;
		this.animUnit[this.Count].transform.localScale = Vector3.one;
		this.Count++;
	}

	// Token: 0x06000ACA RID: 2762 RVA: 0x000E7530 File Offset: 0x000E5730
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

	// Token: 0x06000ACB RID: 2763 RVA: 0x000E7620 File Offset: 0x000E5820
	public void resetScale()
	{
		this.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
	}

	// Token: 0x04002435 RID: 9269
	private const int MAX_SHEETANIM_UNIT = 18;

	// Token: 0x04002436 RID: 9270
	public static Dictionary<uint, Sprite[]> AnimMap = new Dictionary<uint, Sprite[]>();

	// Token: 0x04002437 RID: 9271
	public static List<SheetAnimationUnit> m_FreeList = new List<SheetAnimationUnit>(256);

	// Token: 0x04002438 RID: 9272
	private static Material sharedMat = null;

	// Token: 0x04002439 RID: 9273
	private SheetAnimationUnit[] animUnit = new SheetAnimationUnit[18];

	// Token: 0x0400243A RID: 9274
	private int Count;

	// Token: 0x0400243B RID: 9275
	public GameObject gameObject;

	// Token: 0x0400243C RID: 9276
	public Transform transform;
}
