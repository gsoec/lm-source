using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000202 RID: 514
internal class ShitfHelper
{
	// Token: 0x0600097D RID: 2429 RVA: 0x000C391C File Offset: 0x000C1B1C
	private void AddShift(RectTransform rect, int beginIdx, int targetIdx, float time = 0.05f)
	{
		ShitfHelper.ShitfItemObj item = default(ShitfHelper.ShitfItemObj);
		item.Rect = rect;
		item.bMoving = true;
		item.BeginIdx = beginIdx;
		item.TargetIdx = targetIdx;
		item.MovingTime = time;
		if (this.m_ShiftList != null)
		{
			this.m_ShiftList.Add(item);
		}
	}

	// Token: 0x0600097E RID: 2430 RVA: 0x000C3974 File Offset: 0x000C1B74
	public void Init(RectTransform[] Rect)
	{
		int num = 0;
		while (num < this.m_InitObj.Length && num < Rect.Length)
		{
			this.m_InitObj[num] = default(ShitfHelper.InitObj);
			this.m_InitObj[num].Rect = Rect[num];
			this.m_InitObj[num].Postion = this.m_InitObj[num].Rect.anchoredPosition.x;
			this.m_InitObj[num].Idx = num;
			this.m_InitObj[num].Hint1 = Rect[num].GetChild(0).GetComponent<UIButtonHint>();
			this.m_InitObj[num].Hint2 = Rect[num].GetChild(1).GetComponent<UIButtonHint>();
			num++;
		}
	}

	// Token: 0x0600097F RID: 2431 RVA: 0x000C3A50 File Offset: 0x000C1C50
	public void Start()
	{
		if (this.m_InitObj != null && this.m_ShiftList.Count == 0)
		{
			int num = this.m_InitObj.Length - 1;
			for (int i = 0; i < this.m_InitObj.Length; i++)
			{
				RectTransform rect = this.m_InitObj[i].Rect;
				if (this.m_InitObj[i].Idx < num)
				{
					RectTransform rect2 = rect;
					int idx = this.m_InitObj[i].Idx;
					ShitfHelper.InitObj[] initObj = this.m_InitObj;
					int num2 = i;
					this.AddShift(rect2, idx, initObj[num2].Idx = initObj[num2].Idx + 1, 0.05f);
				}
				else
				{
					this.AddShift(rect, this.m_InitObj[i].Idx, 0, 0f);
					this.m_InitObj[i].Idx = 0;
					this.m_AddItemIdx = i;
				}
			}
			this.m_Time = 0f;
		}
	}

	// Token: 0x06000980 RID: 2432 RVA: 0x000C3B48 File Offset: 0x000C1D48
	public void Update()
	{
		this.m_Time += Time.deltaTime;
		for (int i = 0; i < this.m_ShiftList.Count; i++)
		{
			RectTransform rect = this.m_ShiftList[i].Rect;
			int beginIdx = this.m_ShiftList[i].BeginIdx;
			int targetIdx = this.m_ShiftList[i].TargetIdx;
			float x;
			if (this.m_ShiftList[i].MovingTime <= 0f)
			{
				x = Mathf.Lerp(this.m_InitObj[beginIdx].Postion, this.m_InitObj[targetIdx].Postion, 1f);
			}
			else
			{
				x = Mathf.Lerp(this.m_InitObj[beginIdx].Postion, this.m_InitObj[targetIdx].Postion, this.m_Time / this.m_ShiftList[i].MovingTime);
			}
			rect.anchoredPosition = new Vector2(x, rect.anchoredPosition.y);
			if (this.m_Time >= 0.5f)
			{
				this.m_ShiftList.RemoveAt(i);
			}
		}
	}

	// Token: 0x06000981 RID: 2433 RVA: 0x000C3CA4 File Offset: 0x000C1EA4
	public int GetAddItemIdx()
	{
		return this.m_AddItemIdx;
	}

	// Token: 0x04001FB9 RID: 8121
	private const int MaxItem = 6;

	// Token: 0x04001FBA RID: 8122
	private float m_Time;

	// Token: 0x04001FBB RID: 8123
	private ShitfHelper.InitObj[] m_InitObj = new ShitfHelper.InitObj[6];

	// Token: 0x04001FBC RID: 8124
	private List<ShitfHelper.ShitfItemObj> m_ShiftList = new List<ShitfHelper.ShitfItemObj>();

	// Token: 0x04001FBD RID: 8125
	private int m_AddItemIdx;

	// Token: 0x02000203 RID: 515
	private struct InitObj
	{
		// Token: 0x04001FBE RID: 8126
		public RectTransform Rect;

		// Token: 0x04001FBF RID: 8127
		public float Postion;

		// Token: 0x04001FC0 RID: 8128
		public int Idx;

		// Token: 0x04001FC1 RID: 8129
		public UIButtonHint Hint1;

		// Token: 0x04001FC2 RID: 8130
		public UIButtonHint Hint2;
	}

	// Token: 0x02000204 RID: 516
	private struct ShitfItemObj
	{
		// Token: 0x04001FC3 RID: 8131
		public bool bMoving;

		// Token: 0x04001FC4 RID: 8132
		public RectTransform Rect;

		// Token: 0x04001FC5 RID: 8133
		public int BeginIdx;

		// Token: 0x04001FC6 RID: 8134
		public int TargetIdx;

		// Token: 0x04001FC7 RID: 8135
		public float MovingTime;
	}
}
