using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000258 RID: 600
public class SheetAnimationUnit
{
	// Token: 0x06000AB2 RID: 2738 RVA: 0x000E5980 File Offset: 0x000E3B80
	public SheetAnimationUnit(uint actionID, Dictionary<uint, Sprite[]> animMap, Material sharedMat, bool bMirror = false, float speed = 1f, bool AttackerDirection = false, bool bReverse = false)
	{
		this.gameObject = new GameObject("AnimUnit");
		this.transform = this.gameObject.transform;
		this.kdmr = this.gameObject.AddComponent<SpriteRenderer>();
		this.gameObject.transform.localScale = new Vector3(1.4545f, 1.4545f, 1.4545f);
		this.ResetUnit(actionID, animMap, sharedMat, bMirror, speed, AttackerDirection, bReverse);
	}

	// Token: 0x06000AB3 RID: 2739 RVA: 0x000E5A30 File Offset: 0x000E3C30
	public void ResetUnit(uint actionID, Dictionary<uint, Sprite[]> animMap, Material sharedMat, bool bMirror = false, float speed = 1f, bool AttackerDirection = false, bool bReverse = false)
	{
		if (!this.gameObject.activeSelf)
		{
			this.gameObject.SetActive(true);
		}
		if (!animMap.ContainsKey(actionID))
		{
			Debug.LogError("Sheet not found " + actionID);
		}
		this.AnimArray = animMap[actionID];
		this.sheetIdx = UnityEngine.Random.Range(1, this.AnimArray.Length);
		this.kdmr.sprite = this.AnimArray[this.sheetIdx - 1];
		this.kdmr.material = sharedMat;
		this.sheetLen = this.AnimArray.Length;
		this.speedRate = speed;
		this.CurSPF = 1f / this.speedRate * 0.066f;
		this.FixedSPF = this.CurSPF;
		this.reverse = bReverse;
		this.gameObject.transform.rotation = Quaternion.identity;
		this.gameObject.transform.localScale = Vector3.one;
		if (bMirror)
		{
			this.gameObject.transform.localRotation = ((!AttackerDirection) ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.Euler(0f, 180f, 315f));
		}
		else
		{
			this.gameObject.transform.localRotation = ((!AttackerDirection) ? Quaternion.identity : Quaternion.Euler(0f, 0f, 315f));
		}
		this.StopPoint = -1;
		this.EndPoint = -1;
		int num = (int)(actionID / 10u % 1000u);
		num = ((num <= 100) ? num : (num - 100));
		if (num == 9)
		{
			this.StopPoint = (int)DataManager.MapDataController.MapMonsterTable.GetRecordByKey(1).HitFrame;
			this.sheetIdx = 1;
			this.kdmr.sprite = this.AnimArray[0];
		}
		else if (num == 16)
		{
			this.sheetIdx = 1;
			this.kdmr.sprite = this.AnimArray[0];
			this.StopPoint = 15;
			this.EndPoint = 19;
		}
		else if (num == 18)
		{
			this.sheetIdx = 1;
			this.kdmr.sprite = this.AnimArray[0];
			this.EndPoint = 5;
		}
		else if (this.sheetIdx >= this.sheetLen)
		{
			this.sheetIdx = this.sheetLen - 1;
		}
		this.SoccerUnit = 0;
		if (num == 13)
		{
			this.SoccerUnit = 1;
		}
		else if (num == 14)
		{
			this.SoccerUnit = 2;
		}
		else if (num == 17)
		{
			this.SoccerUnit = 3;
		}
		else if (num == 19)
		{
			this.SoccerUnit = 3;
		}
	}

	// Token: 0x06000AB4 RID: 2740 RVA: 0x000E5CFC File Offset: 0x000E3EFC
	public float GetAnimLen()
	{
		return this.CurSPF * (float)this.sheetLen;
	}

	// Token: 0x06000AB5 RID: 2741 RVA: 0x000E5D0C File Offset: 0x000E3F0C
	public void SampleAnimation(float animTime)
	{
		float animLen = this.GetAnimLen();
		if (animTime <= animLen)
		{
			animTime = animLen;
		}
		int num = (int)(animTime / this.CurSPF);
		if (num >= this.sheetLen - 1)
		{
			this.sheetTimer = this.FixedSPF;
			this.sheetIdx = this.sheetLen - 1;
		}
		else
		{
			this.sheetTimer = animTime - (float)num * this.CurSPF;
			this.kdmr.sprite = this.AnimArray[num];
			this.sheetIdx = num + 1;
		}
	}

	// Token: 0x06000AB6 RID: 2742 RVA: 0x000E5D90 File Offset: 0x000E3F90
	public int Update(float deltaTime)
	{
		if (this.sheetLen <= 1)
		{
			return 0;
		}
		this.sheetTimer += deltaTime;
		int result = 0;
		if (this.sheetTimer >= this.FixedSPF)
		{
			this.sheetTimer = 0f;
			this.kdmr.sprite = this.AnimArray[this.sheetIdx];
			if (this.StopPoint == this.sheetIdx)
			{
				this.FixedSPF = this.CurSPF * 3f;
				result = 1;
			}
			else if (this.EndPoint == this.sheetIdx)
			{
				result = 2;
			}
			else
			{
				this.FixedSPF = this.CurSPF;
			}
			if (this.reverse)
			{
				this.sheetIdx--;
				if (this.sheetIdx <= 0)
				{
					this.sheetIdx = this.sheetLen - 1;
				}
			}
			else
			{
				this.sheetIdx++;
				if (this.sheetIdx >= this.sheetLen)
				{
					this.sheetIdx = 0;
				}
			}
		}
		return result;
	}

	// Token: 0x04002412 RID: 9234
	private const float SPF = 0.066f;

	// Token: 0x04002413 RID: 9235
	private const float cameraScale = 1.4545f;

	// Token: 0x04002414 RID: 9236
	public GameObject gameObject;

	// Token: 0x04002415 RID: 9237
	public Transform transform;

	// Token: 0x04002416 RID: 9238
	public SpriteRenderer kdmr;

	// Token: 0x04002417 RID: 9239
	private Sprite[] AnimArray;

	// Token: 0x04002418 RID: 9240
	private float sheetTimer;

	// Token: 0x04002419 RID: 9241
	private int sheetLen;

	// Token: 0x0400241A RID: 9242
	private int sheetIdx = 1;

	// Token: 0x0400241B RID: 9243
	private float speedRate = 1f;

	// Token: 0x0400241C RID: 9244
	private float CurSPF = 0.066f;

	// Token: 0x0400241D RID: 9245
	private float FixedSPF;

	// Token: 0x0400241E RID: 9246
	private int StopPoint = -1;

	// Token: 0x0400241F RID: 9247
	private int EndPoint = -1;

	// Token: 0x04002420 RID: 9248
	private bool reverse;

	// Token: 0x04002421 RID: 9249
	public byte SoccerUnit;

	// Token: 0x04002422 RID: 9250
	public Vector3 LocalOffset = Vector3.zero;
}
