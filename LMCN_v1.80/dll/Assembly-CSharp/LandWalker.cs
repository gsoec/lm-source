using System;
using UnityEngine;

// Token: 0x0200037E RID: 894
public class LandWalker
{
	// Token: 0x060012BA RID: 4794 RVA: 0x0020CC64 File Offset: 0x0020AE64
	public LandWalker(Transform transform)
	{
		this.movingUnit = new SheetAnimationUnitGroup();
		this.movingUnit.transform.parent = null;
		this.movingUnit.transform.parent = transform;
	}

	// Token: 0x060012BB RID: 4795 RVA: 0x0020CC9C File Offset: 0x0020AE9C
	public void setUnit(ushort idx, byte block, bool forceFade = false)
	{
		this.idx = idx;
		LandWalkerData recordByIndex = DataManager.Instance.LandWalkerData.GetRecordByIndex((int)idx);
		this.startPos = GameConstants.HalfShortsToVector3(recordByIndex.Data[0], recordByIndex.Data[1], recordByIndex.Data[2]);
		this.endPos = GameConstants.HalfShortsToVector3(recordByIndex.Data[3], recordByIndex.Data[4], recordByIndex.Data[5]);
		this.totalTime = (float)recordByIndex.totalTime;
		this.nowTime = 0f;
		if (forceFade)
		{
			this.EndFadePoint = 0.2f;
		}
		else
		{
			this.EndFadePoint = (float)recordByIndex.fadeEnd / 100f;
		}
		this.StartFadePoint = (float)(100 - recordByIndex.fadeStart) / 100f;
		this.movingUnit.gameObject.transform.localPosition = this.startPos;
		this.movingUnit.gameObject.transform.localScale = new Vector3(6f, 6f, 6f);
		this.movingUnit.gameObject.SetActive(true);
		this.movingUnit.transform.localEulerAngles = Vector3.zero;
		this.movingUnit.setupLandAnimUnit(recordByIndex.GenData[(int)block].isEmemy, recordByIndex.GenData[(int)block].modelID, (int)recordByIndex.direction);
		this.movingUnit.transform.localEulerAngles = new Vector3(45f, 180f, 0f);
		switch (recordByIndex.SpriteSort)
		{
		case 0:
			this.movingUnit.SetSortOrder(-30);
			this.changeOrder = false;
			break;
		case 1:
			this.movingUnit.SetSortOrder(-30);
			this.changeOrder = true;
			this.overTop = false;
			break;
		case 2:
			this.movingUnit.SetSortOrder(-60);
			this.changeOrder = true;
			this.overTop = true;
			break;
		case 3:
			this.movingUnit.SetSortOrder(-60);
			this.changeOrder = false;
			break;
		}
		if (this.EndFadePoint != 0f)
		{
			this.movingUnit.SetColor(new Color(1f, 1f, 1f, 0f));
		}
	}

	// Token: 0x060012BC RID: 4796 RVA: 0x0020CEF4 File Offset: 0x0020B0F4
	public void update(float deltaTime)
	{
		if (this.movingUnit == null)
		{
			return;
		}
		this.movingUnit.Update(deltaTime);
		this.nowTime += deltaTime;
		if (this.nowTime > this.totalTime)
		{
			LandWalkerManager.EndAction(this);
			return;
		}
		float num = this.nowTime / this.totalTime;
		this.movingUnit.transform.localPosition = Vector3.Lerp(this.startPos, this.endPos, num);
		if (num < this.EndFadePoint)
		{
			this.movingUnit.SetColor(new Color(1f, 1f, 1f, num / this.EndFadePoint));
		}
		else if (num > this.StartFadePoint)
		{
			this.movingUnit.SetColor(new Color(1f, 1f, 1f, Mathf.InverseLerp(1f, this.StartFadePoint, num)));
		}
		else
		{
			this.movingUnit.SetColor(Color.white);
			if (this.changeOrder)
			{
				if (this.overTop)
				{
					this.movingUnit.SetSortOrder(-30);
				}
				else
				{
					this.movingUnit.SetSortOrder(-60);
				}
				this.changeOrder = false;
			}
		}
	}

	// Token: 0x060012BD RID: 4797 RVA: 0x0020D038 File Offset: 0x0020B238
	public void SetFade()
	{
		this.startPos = this.movingUnit.transform.localPosition;
		this.endPos = this.startPos;
		this.nowTime = 0f;
		this.totalTime = 0.8f;
		this.EndFadePoint = 0f;
		this.StartFadePoint = 0f;
	}

	// Token: 0x060012BE RID: 4798 RVA: 0x0020D094 File Offset: 0x0020B294
	public void destroy()
	{
	}

	// Token: 0x04003A12 RID: 14866
	public ushort idx;

	// Token: 0x04003A13 RID: 14867
	public Vector3 startPos;

	// Token: 0x04003A14 RID: 14868
	public Vector3 endPos;

	// Token: 0x04003A15 RID: 14869
	public SheetAnimationUnitGroup movingUnit;

	// Token: 0x04003A16 RID: 14870
	public float EndFadePoint;

	// Token: 0x04003A17 RID: 14871
	public float StartFadePoint;

	// Token: 0x04003A18 RID: 14872
	public float nowTime;

	// Token: 0x04003A19 RID: 14873
	public float totalTime;

	// Token: 0x04003A1A RID: 14874
	public short weight;

	// Token: 0x04003A1B RID: 14875
	public bool changeOrder;

	// Token: 0x04003A1C RID: 14876
	public bool overTop;
}
