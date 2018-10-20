using System;
using UnityEngine;

// Token: 0x0200073B RID: 1851
public class WarCamera
{
	// Token: 0x170000DD RID: 221
	// (set) Token: 0x06002387 RID: 9095 RVA: 0x00410D64 File Offset: 0x0040EF64
	public bool Shake
	{
		set
		{
			this.bShaking = value;
			if (value)
			{
				this.ShakingTimer = 0.2f;
			}
		}
	}

	// Token: 0x170000DE RID: 222
	// (get) Token: 0x06002388 RID: 9096 RVA: 0x00410D80 File Offset: 0x0040EF80
	// (set) Token: 0x06002389 RID: 9097 RVA: 0x00410D88 File Offset: 0x0040EF88
	public bool CoordCamMode
	{
		get
		{
			return this.bCoordCamMode;
		}
		set
		{
			if (value && !this.bCoordCamMode)
			{
				this.CoordCamStatus = 0;
			}
			this.bCoordCamMode = value;
		}
	}

	// Token: 0x0600238A RID: 9098 RVA: 0x00410DAC File Offset: 0x0040EFAC
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

	// Token: 0x0600238B RID: 9099 RVA: 0x00410E60 File Offset: 0x0040F060
	public void initCamera(ArmyGroup[] player, int playerCt, ArmyGroup[] enemy, int enemyCt)
	{
		this.distance = 55f;
		this.targetPos = Vector3.zero;
		this.CameraTransform = Camera.main.transform;
		Camera.main.fieldOfView = 60f;
		this.WM = (GameManager.ActiveGameplay as WarManager);
		if (this.WM != null)
		{
			this.CameraModel = this.WM.CameraModel;
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
		Quaternion identity = Quaternion.identity;
		identity.eulerAngles = new Vector3(55f, this.Y_Angles, 0f);
		this.CameraTransform.rotation = identity;
		if (this.bFINISHING)
		{
			this.targetPos = this.ViewportBoundPoint;
			this.CameraTransform.position = this.targetPos;
			this.CameraTransform.position += this.CameraTransform.rotation * Vector3.back * this.distance / Mathf.Sin(this.CameraTransform.eulerAngles.x / 180f * 3.14159274f);
			return;
		}
		int num = 0;
		if (player != null)
		{
			for (int i = 0; i < playerCt; i++)
			{
				if (player[i].groupRoot.gameObject.activeSelf && player[i].CurHP != 0 && (player[i].GroupKind != EGroupKind.Catapults || !this.bIgnoreCatapults))
				{
					this.targetPos += player[i].groupRoot.position;
					num++;
				}
			}
		}
		if (enemy != null)
		{
			for (int j = 0; j < enemyCt; j++)
			{
				if (enemy[j].groupRoot.gameObject.activeSelf && enemy[j].CurHP != 0 && (enemy[j].GroupKind != EGroupKind.Catapults || !this.bIgnoreCatapults))
				{
					this.targetPos += enemy[j].groupRoot.position;
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
		this.ScreenSize = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
	}

	// Token: 0x0600238C RID: 9100 RVA: 0x00411178 File Offset: 0x0040F378
	public void updateCamera(ArmyGroup[] player, int playerCt, ArmyGroup[] enemy, int enemyCt)
	{
		if (this.bCoordCamMode)
		{
			this.updateCameraCoordTestMode(player, playerCt, enemy, enemyCt);
			return;
		}
		if (this.mCount < 2)
		{
			this.mCount += 1;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int i = 0;
			Vector3 vector = Vector3.zero;
			if (player != null)
			{
				num = playerCt;
				while (i < num)
				{
					if (player[i].groupRoot.gameObject.activeSelf && player[i].CurHP != 0 && (player[i].GroupKind != EGroupKind.Catapults || !this.bIgnoreCatapults))
					{
						vector += Camera.main.WorldToScreenPoint(player[i].groupRoot.position) * this.Weights_Play;
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
					if (enemy[i].groupRoot.gameObject.activeSelf && enemy[i].CurHP != 0 && (enemy[i].GroupKind != EGroupKind.Catapults || !this.bIgnoreCatapults))
					{
						vector += Camera.main.WorldToScreenPoint(enemy[i].groupRoot.position) * this.Weights_Enemy;
						num3++;
					}
				}
			}
			if (num3 > 0)
			{
				vector /= (float)num3;
				if (this.bFINISHING)
				{
					vector = this.ViewportBoundPoint - this.targetPos;
				}
				else
				{
					vector = Camera.main.ScreenToWorldPoint(vector) - this.targetPos;
				}
				float num4 = Vector2.Distance(Vector2.zero, vector);
				float num5 = this.LinearInterpolation(new Vector2(2f, 10f), new Vector2(0.1f, 10f), num4, true);
				num5 = ((num5 > 0.1f) ? num5 : 0f);
				if (this.bFINISHING)
				{
					num5 *= this.FinISHINGMoveSpeed;
				}
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
				this.CameraTransform.position = this.targetPos + this.CameraTransform.rotation * Vector3.back * this.distance / (float)Math.Sin((double)(this.CameraTransform.eulerAngles.x * 0.0174532924f));
				if (this.bFINISHING)
				{
					if (this.distance > 35f)
					{
						this.distance += Time.smoothDeltaTime * 22f * -1f;
						if (this.distance < 35f)
						{
							this.distance = 35f;
						}
					}
					Quaternion identity = Quaternion.identity;
					identity.eulerAngles = new Vector3(55f, this.Y_Angles, 0f);
					this.CameraTransform.rotation = identity;
					this.CameraTransform.position = this.targetPos + this.CameraTransform.rotation * Vector3.back * this.distance / (float)Math.Sin((double)(this.CameraTransform.eulerAngles.x * 0.0174532924f));
					return;
				}
				num--;
				num2--;
				float num6 = 0.5f;
				float num7 = num6;
				float num8 = 0.5f;
				float num9 = num8;
				for (i = num; i > -1; i--)
				{
					if (player[i].groupRoot.gameObject.activeSelf && (player[i].GroupKind != EGroupKind.Catapults || !this.bIgnoreCatapults))
					{
						vector = Camera.main.WorldToViewportPoint(player[i].groupRoot.position);
						if (vector.x > num6)
						{
							num6 = vector.x;
						}
						if (vector.x < num7)
						{
							num7 = vector.x;
						}
						if (vector.y < num8)
						{
							num8 = vector.y;
						}
						if (vector.y > num9)
						{
							num9 = vector.y;
						}
					}
				}
				for (i = num2; i > -1; i--)
				{
					if (enemy[i].groupRoot.gameObject.activeSelf && (enemy[i].GroupKind != EGroupKind.Catapults || !this.bIgnoreCatapults))
					{
						vector = Camera.main.WorldToViewportPoint(enemy[i].groupRoot.position);
						if (vector.x > num6)
						{
							num6 = vector.x;
						}
						if (vector.x < num7)
						{
							num7 = vector.x;
						}
						if (vector.y < num8)
						{
							num8 = vector.y;
						}
						if (vector.y > num9)
						{
							num9 = vector.y;
						}
					}
				}
				num7 = Math.Abs(0.5f - num7);
				num8 = Math.Abs(0.5f - num8);
				num6 = Math.Abs(0.5f - num6);
				num9 = Math.Abs(0.5f - num9);
				float num10 = num7;
				if (num6 > num10)
				{
					num10 = num6;
				}
				if (num9 > num10)
				{
					num10 = num9;
				}
				if (num8 > num10)
				{
					num10 = num8;
				}
				num10 *= 2f;
				if (Math.Abs(num10 - 1f) > 0.01f)
				{
					if (this.distance >= 35f)
					{
						this.distance += Time.smoothDeltaTime * 22f * (num10 - 1f);
						if (this.distance < 35f)
						{
							this.distance = 35f;
						}
					}
					Quaternion identity2 = Quaternion.identity;
					identity2.eulerAngles = new Vector3(55f, this.Y_Angles, 0f);
					this.CameraTransform.rotation = identity2;
					this.CameraTransform.position = this.targetPos + this.CameraTransform.rotation * Vector3.back * this.distance / (float)Math.Sin((double)(this.CameraTransform.eulerAngles.x * 0.0174532924f));
				}
			}
			if (this.bShaking)
			{
				this.ShakingTimer -= Time.deltaTime;
				if (this.ShakingTimer <= 0f)
				{
					this.bShaking = false;
				}
				else
				{
					float num11 = Mathf.PerlinNoise(Time.time * 100f, 0f) * 2f;
					float num12 = Mathf.PerlinNoise(0f, Time.time * 100f) * 2f;
					this.CameraTransform.position += this.CameraTransform.rotation * new Vector3(0f, 1f - num11, 0f);
				}
			}
			return;
		}
		this.mCount = 0;
	}

	// Token: 0x0600238D RID: 9101 RVA: 0x004118C0 File Offset: 0x0040FAC0
	public void SetTargetPosition(Vector3 mTargetposition, bool bFinished = true, float fSpeed = 1f)
	{
		this.bFINISHING = bFinished;
		this.ViewportBoundPoint = mTargetposition;
		this.FinISHINGMoveSpeed = fSpeed;
	}

	// Token: 0x0600238E RID: 9102 RVA: 0x004118D8 File Offset: 0x0040FAD8
	public void updateCameraCoordTestMode(ArmyGroup[] player, int playerCt, ArmyGroup[] enemy, int enemyCt)
	{
		if (this.CoordCamStatus == 0)
		{
			this.CameraTransform.position = Vector3.MoveTowards(this.CameraTransform.position, this.CoordModeCamPos, Time.deltaTime * 40f);
			this.CameraTransform.LookAt(this.CoordModeCamLookAt);
			if (Vector3.Distance(this.CameraTransform.position, this.CoordModeCamPos) <= 0.0001f)
			{
				this.CoordCamStatus = 1;
				this.Coord_CamEndPos = this.CameraTransform.position + this.CameraTransform.forward * 100f;
				this.BeginDist = Vector3.Distance(this.CameraTransform.position, this.Coord_CamEndPos);
			}
		}
		else
		{
			int i = 0;
			RectTransform canvasRT = GUIManager.Instance.pDVMgr.CanvasRT;
			bool flag = true;
			if (player != null)
			{
				while (i < playerCt)
				{
					if (player[i].groupRoot.gameObject.activeSelf && player[i].CurHP != 0 && player[i].GroupKind != EGroupKind.Catapults)
					{
						Vector3 vector = Camera.main.WorldToScreenPoint(player[i].groupRoot.position);
						if (vector.x < 60f || vector.x > this.ScreenSize.x - 60f || vector.y < 0f || vector.y > this.ScreenSize.y)
						{
							flag = false;
						}
					}
					i++;
				}
			}
			if (enemy != null)
			{
				for (i = 0; i < enemyCt; i++)
				{
					if (enemy[i].groupRoot.gameObject.activeSelf && enemy[i].CurHP != 0 && enemy[i].GroupKind != EGroupKind.Catapults)
					{
						Vector3 vector2 = Camera.main.WorldToScreenPoint(enemy[i].groupRoot.position);
						if (vector2.x < 60f || vector2.x > this.ScreenSize.x - 60f || vector2.y < 0f || vector2.y > this.ScreenSize.y)
						{
							flag = false;
						}
					}
				}
			}
			if (flag)
			{
				float num = Vector3.Distance(this.CameraTransform.position, this.Coord_CamEndPos);
				num = num / this.BeginDist * 10f;
				this.CameraTransform.position = Vector3.MoveTowards(this.CameraTransform.position, this.Coord_CamEndPos, Time.deltaTime * num);
			}
		}
	}

	// Token: 0x0600238F RID: 9103 RVA: 0x00411B88 File Offset: 0x0040FD88
	public float GetDistForScreenSize(Vector3 ViewportPoint)
	{
		RectTransform canvasRT = GUIManager.Instance.pDVMgr.CanvasRT;
		float num = canvasRT.sizeDelta.x / canvasRT.sizeDelta.y;
		num = 56f + (1.77777779f - num) * 2.25000024f * 14f;
		num = Mathf.Max(num, 56f);
		return Mathf.Min(num, 70f);
	}

	// Token: 0x04006CC5 RID: 27845
	private const float minDis = 35f;

	// Token: 0x04006CC6 RID: 27846
	private const float maxDis = 55f;

	// Token: 0x04006CC7 RID: 27847
	private const float minXAngles = 33.75f;

	// Token: 0x04006CC8 RID: 27848
	private const float maxXAngles = 40f;

	// Token: 0x04006CC9 RID: 27849
	private const float minMoveDis = 2f;

	// Token: 0x04006CCA RID: 27850
	private const float maxMoveDis = 10f;

	// Token: 0x04006CCB RID: 27851
	private const float minMoveSpeed = 0.1f;

	// Token: 0x04006CCC RID: 27852
	private const float maxMoveSpeed = 10f;

	// Token: 0x04006CCD RID: 27853
	private float distance;

	// Token: 0x04006CCE RID: 27854
	private Vector3 targetPos;

	// Token: 0x04006CCF RID: 27855
	private Transform CameraTransform;

	// Token: 0x04006CD0 RID: 27856
	private float Weights_Play = 1f;

	// Token: 0x04006CD1 RID: 27857
	private float Weights_Enemy = 0.8f;

	// Token: 0x04006CD2 RID: 27858
	private float Y_Angles = 45f;

	// Token: 0x04006CD3 RID: 27859
	private float FinISHINGMoveSpeed = 1f;

	// Token: 0x04006CD4 RID: 27860
	private byte CameraModel;

	// Token: 0x04006CD5 RID: 27861
	private Vector3 ViewportBoundPoint = Vector3.zero;

	// Token: 0x04006CD6 RID: 27862
	private WarManager WM;

	// Token: 0x04006CD7 RID: 27863
	private bool bFINISHING;

	// Token: 0x04006CD8 RID: 27864
	public bool bIgnoreCatapults = true;

	// Token: 0x04006CD9 RID: 27865
	public bool bShaking;

	// Token: 0x04006CDA RID: 27866
	public float ShakingTimer;

	// Token: 0x04006CDB RID: 27867
	private Vector3 CoordModeCamPos = new Vector3(54.83f, 66.55f, -31.93f);

	// Token: 0x04006CDC RID: 27868
	private Vector3 CoordModeCamLookAt = new Vector3(54.83f, 0f, 6.5f);

	// Token: 0x04006CDD RID: 27869
	private Vector3 Coord_CamEndPos = Vector3.zero;

	// Token: 0x04006CDE RID: 27870
	private Vector2 ScreenSize = Vector2.zero;

	// Token: 0x04006CDF RID: 27871
	private float BeginDist;

	// Token: 0x04006CE0 RID: 27872
	public bool bCoordCamMode;

	// Token: 0x04006CE1 RID: 27873
	public int CoordCamStatus;

	// Token: 0x04006CE2 RID: 27874
	private byte mCount;
}
