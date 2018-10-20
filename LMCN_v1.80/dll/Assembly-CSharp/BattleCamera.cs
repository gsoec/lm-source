using System;
using UnityEngine;

// Token: 0x020001D2 RID: 466
public class BattleCamera
{
	// Token: 0x0600086F RID: 2159 RVA: 0x000A8BD8 File Offset: 0x000A6DD8
	private float LinearInterpolation(Vector2 XInterval, Vector2 YInterval, float XValue, bool bLimit = true)
	{
		if (bLimit)
		{
			if (XInterval.x < XInterval.y)
			{
				if (XValue > XInterval.y)
				{
					return YInterval.y;
				}
				if (XValue < XInterval.x)
				{
					return YInterval.x;
				}
			}
			else
			{
				if (XValue > XInterval.x)
				{
					return YInterval.x;
				}
				if (XValue < XInterval.y)
				{
					return YInterval.y;
				}
			}
		}
		return YInterval.x + (XValue - XInterval.x) * (YInterval.y - YInterval.x) / (XInterval.y - XInterval.x);
	}

	// Token: 0x06000870 RID: 2160 RVA: 0x000A8C8C File Offset: 0x000A6E8C
	public void initCamera(AnimationUnit[] player, int playerCt, AnimationUnit[] enemy, int enemyCt)
	{
		this.distance = 12f;
		this.targetPos = Vector3.zero;
		this.CameraTransform = Camera.main.transform;
		Camera.main.fieldOfView = 60f;
		this.bc = (GameManager.ActiveGameplay as BattleController);
		if (this.bc != null)
		{
			this.CameraModel = BattleController.CameraModel;
			if (this.CameraModel == 0)
			{
				this.Weights_Play = 1f;
				this.Weights_Enemy = 1f;
				this.Y_Angles = 45f;
			}
			else
			{
				this.Weights_Play = 1f;
				this.Weights_Enemy = 1f;
				this.Y_Angles = 315f;
			}
		}
		if (NewbieManager.IsNewbie)
		{
			this.Weights_Enemy = 4f;
			this.minXAngles = 30.75f;
		}
		else if (this.bc.BattleType == EBattleType.PLAYBACK)
		{
			this.Weights_Enemy = 1f;
			this.minXAngles = 30.75f;
			MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(GUIManager.Instance.WM_MonsterID);
			if (recordByKey.CameraHeight != 0)
			{
				this.minDis = (float)recordByKey.CameraHeight * 0.01f;
			}
		}
		else if (this.bc.IsType(EBattleType.GAMBLE))
		{
			this.Weights_Enemy = 1f;
			this.minXAngles = 30.75f;
			MapMonster recordByKey2 = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(GamblingManager.Instance.BattleMonsterID);
			if (recordByKey2.CameraHeight != 0)
			{
				this.minDis = (float)recordByKey2.CameraHeight * 0.01f;
			}
		}
		float x = this.LinearInterpolation(new Vector2(this.minDis, 12f), new Vector3(0.1f, 45f), this.distance, true);
		Quaternion identity = Quaternion.identity;
		identity.eulerAngles = new Vector3(x, this.Y_Angles, 0f);
		this.CameraTransform.rotation = identity;
		int num = 0;
		this.DM = DataManager.Instance;
		if (player != null)
		{
			int num2 = Mathf.Min(playerCt, 5);
			for (int i = 0; i < num2; i++)
			{
				if (player[i].gameObject.activeSelf)
				{
					this.targetPos += player[i].transform.position;
					num++;
				}
			}
		}
		if (enemy != null)
		{
			for (int j = 0; j < enemyCt; j++)
			{
				if (enemy[j].gameObject.activeSelf)
				{
					this.targetPos += enemy[j].transform.position;
					num++;
				}
			}
		}
		if (num > 0)
		{
			this.targetPos /= (float)num;
			this.CameraTransform.position = this.targetPos;
			this.CameraTransform.position += this.CameraTransform.rotation * Vector3.back * this.distance / Mathf.Sin(this.CameraTransform.eulerAngles.x / 180f * 3.14159274f);
		}
	}

	// Token: 0x06000871 RID: 2161 RVA: 0x000A8FDC File Offset: 0x000A71DC
	public void updateCamera(AnimationUnit[] player, int playerCt, AnimationUnit[] enemy, int enemyCt)
	{
		if (this.mCount < 10)
		{
			this.mCount += 1;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int b = 5;
			int i = 0;
			Vector3 vector = Vector3.zero;
			Vector3 zero = Vector3.zero;
			if (player != null)
			{
				num = Mathf.Min(playerCt, b);
				while (i < num)
				{
					if (player[i].gameObject.activeSelf)
					{
						vector += Camera.main.WorldToScreenPoint(player[i].transform.position) * this.Weights_Play;
						num3++;
					}
					i++;
				}
			}
			if (enemy != null)
			{
				num2 = enemyCt;
				for (i = 0; i < num2; i++)
				{
					if (enemy[i].gameObject.activeSelf)
					{
						vector += Camera.main.WorldToScreenPoint(enemy[i].transform.position) * this.Weights_Enemy;
						num3++;
					}
				}
			}
			if (num3 > 0)
			{
				vector /= (float)num3;
				vector = Camera.main.ScreenToWorldPoint(vector) - this.targetPos;
				float num4 = Vector3.Distance(Vector3.zero, vector);
				float num5 = this.LinearInterpolation(new Vector2(2f, 10f), new Vector3(1f, 0.1f), num4, true);
				num5 *= Time.smoothDeltaTime;
				if (num4 < num5)
				{
					this.targetPos += vector;
				}
				else
				{
					vector.Normalize();
					this.targetPos += vector * num5;
				}
				this.CameraTransform.position = this.targetPos + this.CameraTransform.rotation * Vector3.back * this.distance / Mathf.Sin(this.CameraTransform.eulerAngles.x / 180f * 3.14159274f);
				num--;
				num2--;
				float num6 = 0.5f;
				float num7 = num6;
				float num8 = 0.5f;
				float num9 = num8;
				for (i = num; i > -1; i--)
				{
					if (player[i].gameObject.activeSelf)
					{
						this.sHero = this.DM.HeroTable.GetRecordByKey(player[i].NpcID);
						float num10 = (float)this.sHero.Radius * 0.01f;
						zero.Set(player[i].transform.position.x + num10, player[i].transform.position.y, player[i].transform.position.z);
						vector = Camera.main.WorldToViewportPoint(zero);
						if (vector.x > num6)
						{
							num6 = vector.x;
						}
						zero.Set(player[i].transform.position.x - num10, player[i].transform.position.y, player[i].transform.position.z);
						vector = Camera.main.WorldToViewportPoint(zero);
						if (vector.x < num7)
						{
							num7 = vector.x;
						}
						vector = Camera.main.WorldToViewportPoint(player[i].transform.position);
						if (vector.y < num8)
						{
							num8 = vector.y;
						}
						num10 = (float)this.sHero.Height * 0.01f;
						zero.Set(player[i].transform.position.x, player[i].transform.position.y + num10, player[i].transform.position.z);
						vector = Camera.main.WorldToViewportPoint(zero);
						if (vector.y > num9)
						{
							num9 = vector.y;
						}
					}
				}
				for (i = num2; i > -1; i--)
				{
					if (enemy[i].gameObject.activeSelf)
					{
						this.sHero = this.DM.HeroTable.GetRecordByKey(enemy[i].NpcID);
						float num10 = (float)this.sHero.Radius * 0.01f;
						zero.Set(enemy[i].transform.position.x + num10, enemy[i].transform.position.y, enemy[i].transform.position.z);
						vector = Camera.main.WorldToViewportPoint(zero);
						if (vector.x > num6)
						{
							num6 = vector.x;
						}
						zero.Set(enemy[i].transform.position.x - num10, enemy[i].transform.position.y, enemy[i].transform.position.z);
						vector = Camera.main.WorldToViewportPoint(zero);
						if (vector.x < num7)
						{
							num7 = vector.x;
						}
						vector = Camera.main.WorldToViewportPoint(enemy[i].transform.position);
						if (vector.y < num8)
						{
							num8 = vector.y;
						}
						num10 = (float)this.sHero.Height * 0.01f;
						zero.Set(enemy[i].transform.position.x, enemy[i].transform.position.y + num10, enemy[i].transform.position.z);
						vector = Camera.main.WorldToViewportPoint(zero);
						if (vector.y > num9)
						{
							num9 = vector.y;
						}
					}
				}
				num7 = Mathf.Abs(0.5f - num7) * 1.3f;
				num8 = Mathf.Abs(0.5f - num8) * 1.3f;
				num6 = Mathf.Abs(0.5f - num6) * 1.3f;
				num9 = Mathf.Abs(0.5f - num9);
				float num11 = num7;
				if (num6 > num11)
				{
					num11 = num6;
				}
				if (num9 > num11)
				{
					num11 = num9;
				}
				if (num8 > num11)
				{
					num11 = num8;
				}
				num11 *= 2f;
				if (Mathf.Abs(num11 - 1f) > 0.01f)
				{
					if (this.distance >= this.minDis)
					{
						this.distance += Time.smoothDeltaTime * 22f * (num11 - 1f);
						if (this.distance < this.minDis)
						{
							this.distance = this.minDis;
						}
						else if (this.distance >= 12f)
						{
							this.distance = 12f;
						}
					}
					float x = this.LinearInterpolation(new Vector2(this.minDis, 12f), new Vector3(this.minXAngles, 45f), this.distance, true);
					Quaternion identity = Quaternion.identity;
					identity.eulerAngles = new Vector3(x, this.Y_Angles, 0f);
					this.CameraTransform.rotation = identity;
					this.CameraTransform.position = this.targetPos + this.CameraTransform.rotation * Vector3.back * this.distance / Mathf.Sin(this.CameraTransform.eulerAngles.x / 180f * 3.14159274f);
				}
			}
			return;
		}
		this.mCount = 0;
	}

	// Token: 0x04001C95 RID: 7317
	private const float maxDis = 12f;

	// Token: 0x04001C96 RID: 7318
	private const float maxXAngles = 45f;

	// Token: 0x04001C97 RID: 7319
	private const float minMoveDis = 2f;

	// Token: 0x04001C98 RID: 7320
	private const float maxMoveDis = 10f;

	// Token: 0x04001C99 RID: 7321
	private const float minMoveSpeed = 0.1f;

	// Token: 0x04001C9A RID: 7322
	private const float maxMoveSpeed = 1f;

	// Token: 0x04001C9B RID: 7323
	private float distance;

	// Token: 0x04001C9C RID: 7324
	private Vector3 targetPos;

	// Token: 0x04001C9D RID: 7325
	private Transform CameraTransform;

	// Token: 0x04001C9E RID: 7326
	private float minDis = 6f;

	// Token: 0x04001C9F RID: 7327
	public float minXAngles = 33.75f;

	// Token: 0x04001CA0 RID: 7328
	private Hero sHero;

	// Token: 0x04001CA1 RID: 7329
	private DataManager DM;

	// Token: 0x04001CA2 RID: 7330
	private float Weights_Play = 1f;

	// Token: 0x04001CA3 RID: 7331
	private float Weights_Enemy = 0.75f;

	// Token: 0x04001CA4 RID: 7332
	private float Y_Angles = 45f;

	// Token: 0x04001CA5 RID: 7333
	private byte CameraModel;

	// Token: 0x04001CA6 RID: 7334
	private BattleController bc;

	// Token: 0x04001CA7 RID: 7335
	private byte mCount;
}
