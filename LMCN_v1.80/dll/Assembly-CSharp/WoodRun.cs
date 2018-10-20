using System;
using UnityEngine;

// Token: 0x02000744 RID: 1860
public class WoodRun : TrapBehavior
{
	// Token: 0x060023A9 RID: 9129 RVA: 0x004134DC File Offset: 0x004116DC
	public WoodRun(Vector3[] defaultPos, byte unitCount)
	{
		this.oriPos = defaultPos;
		this.UnitCount = unitCount;
		this.woodController = new WoodRun.WoodNode[(int)unitCount];
		if (unitCount == 3)
		{
			this.hitParticleID = 2011;
		}
		else
		{
			this.hitParticleID = 2013;
		}
	}

	// Token: 0x060023AA RID: 9130 RVA: 0x004135E8 File Offset: 0x004117E8
	private void UpdateSampleControl(ref WoodRun.WoodNode woodNode)
	{
		Vector3 a = woodNode.SamplePoint2 - woodNode.SamplePoint1;
		woodNode.SampleControl1 = woodNode.SamplePoint1 + a * 0.25f;
		woodNode.SampleControl2 = woodNode.SamplePoint1 + a * 0.6f;
		woodNode.SampleControl1.y = woodNode.SampleControl1.y + woodNode.CurveHeight;
		woodNode.SampleControl2.y = woodNode.SampleControl2.y + woodNode.CurveHeight;
	}

	// Token: 0x060023AB RID: 9131 RVA: 0x00413670 File Offset: 0x00411870
	private Vector3 Evaluate(float deltaTime, ref WoodRun.WoodNode woodNode)
	{
		float num = this.SampleTime[0];
		float num2 = this.SampleTime[(int)(woodNode.sampleStep + 1)];
		float d = (woodNode.timeStep - num) / (num2 - num);
		Vector3 a = woodNode.SamplePoint2 - (woodNode.SampleControl2 - woodNode.SampleControl1) * 3f - woodNode.SamplePoint1;
		Vector3 a2 = 3f * (woodNode.SampleControl2 + woodNode.SamplePoint1) - 6f * woodNode.SampleControl1;
		Vector3 a3 = (woodNode.SampleControl1 - woodNode.SamplePoint1) * 3f;
		return woodNode.SamplePoint1 + d * (a3 + d * (a2 + d * a));
	}

	// Token: 0x060023AC RID: 9132 RVA: 0x00413754 File Offset: 0x00411954
	private void InitNode(ref WoodRun.WoodNode woodNode, Transform wood)
	{
		woodNode.activeState = 1;
		woodNode.timeStep = 0f;
		woodNode.sampleStep = 0;
		woodNode.SamplePoint1 = wood.localPosition;
		woodNode.SamplePoint2 = wood.localPosition + this.woodSamplePoint[0];
		woodNode.CurveHeight = Vector3.Distance(woodNode.SamplePoint1, woodNode.SamplePoint2) * 0.4f;
	}

	// Token: 0x060023AD RID: 9133 RVA: 0x004137C8 File Offset: 0x004119C8
	private bool UpdateNode(float deltaTime, ref WoodRun.WoodNode woodNode, Transform wood)
	{
		if (woodNode.activeState == 0)
		{
			return false;
		}
		if (woodNode.activeState == 5)
		{
			wood.Rotate(Vector3.right, 64f * deltaTime, Space.Self);
			Vector3 position = wood.position;
			position.y -= deltaTime * 7f;
			position.x -= deltaTime * 2f;
			wood.position = position;
			if (position.y <= -1f)
			{
				wood.gameObject.SetActive(false);
			}
			return true;
		}
		if (woodNode.timeStep > this.SampleTime[(int)(woodNode.sampleStep + 1)])
		{
			if (woodNode.sampleStep == 0)
			{
				Vector3 position2 = wood.position;
				base.checkHitParticle(ref position2);
			}
			if (woodNode.sampleStep >= 3)
			{
				woodNode.activeState = 5;
				return false;
			}
			woodNode.timeStep = 0f;
			woodNode.sampleStep += 1;
			wood.localPosition = woodNode.SamplePoint2;
			woodNode.SamplePoint1 = wood.localPosition;
			woodNode.SamplePoint2 += this.woodSamplePoint[(int)woodNode.sampleStep];
			woodNode.CurveHeight = ((woodNode.sampleStep < 3) ? (Vector3.Distance(woodNode.SamplePoint1, woodNode.SamplePoint2) * 0.4f) : 0f);
		}
		this.UpdateSampleControl(ref woodNode);
		wood.localPosition = this.Evaluate(deltaTime, ref woodNode);
		woodNode.timeStep += deltaTime;
		return true;
	}

	// Token: 0x060023AE RID: 9134 RVA: 0x00413958 File Offset: 0x00411B58
	public override void Update(Transform[] suprs, float deltaTime)
	{
		if (this.trapState == 0)
		{
			return;
		}
		if (this.trapState == 1)
		{
			for (int i = 0; i < (int)this.UnitCount; i++)
			{
				suprs[i].localPosition = this.oriPos[i];
				if (suprs[i].gameObject.activeSelf)
				{
					suprs[i].gameObject.SetActive(false);
				}
				this.woodController[i] = default(WoodRun.WoodNode);
				this.InitNode(ref this.woodController[i], suprs[i]);
				this.woodController[i].delay = UnityEngine.Random.Range(0f, 0.5f);
			}
			this.targetPosCache.Clear();
			this.trapState = 2;
		}
		else if (this.trapState == 2)
		{
			byte b = 0;
			for (int j = 0; j < (int)this.UnitCount; j++)
			{
				if (this.woodController[j].activeState == 1)
				{
					WoodRun.WoodNode[] array = this.woodController;
					int num = j;
					array[num].timeStep = array[num].timeStep + deltaTime;
					if (this.woodController[j].timeStep >= this.woodController[j].delay)
					{
						suprs[j].gameObject.SetActive(true);
						this.woodController[j].timeStep = 0f;
						this.woodController[j].activeState = 2;
					}
				}
				else if (this.UpdateNode(deltaTime, ref this.woodController[j], suprs[j]))
				{
					suprs[j].Rotate(Vector3.right, this.RotateSpeed[(int)this.woodController[j].sampleStep] * deltaTime, Space.Self);
				}
				else
				{
					b += 1;
				}
			}
			if (b == this.UnitCount)
			{
				this.trapState = 0;
			}
		}
	}

	// Token: 0x04006D1E RID: 27934
	private const byte MAX_STEPINDEX = 3;

	// Token: 0x04006D1F RID: 27935
	private readonly Vector3[] woodSamplePoint = new Vector3[]
	{
		new Vector3(-4.5f, -5f, 0f),
		new Vector3(-4f, 0f, 0f),
		new Vector3(-2f, 0f, 0f),
		new Vector3(-2f, 0f, 0f)
	};

	// Token: 0x04006D20 RID: 27936
	private float[] SampleTime = new float[]
	{
		0f,
		0.4f,
		0.8f,
		0.5f,
		0.5f
	};

	// Token: 0x04006D21 RID: 27937
	private float[] RotateSpeed = new float[]
	{
		960f,
		360f,
		240f,
		200f
	};

	// Token: 0x04006D22 RID: 27938
	private WoodRun.WoodNode[] woodController;

	// Token: 0x04006D23 RID: 27939
	private byte UnitCount;

	// Token: 0x02000745 RID: 1861
	public struct WoodNode
	{
		// Token: 0x04006D24 RID: 27940
		public byte activeState;

		// Token: 0x04006D25 RID: 27941
		public float timeStep;

		// Token: 0x04006D26 RID: 27942
		public float CurveHeight;

		// Token: 0x04006D27 RID: 27943
		public Vector3 SamplePoint1;

		// Token: 0x04006D28 RID: 27944
		public Vector3 SamplePoint2;

		// Token: 0x04006D29 RID: 27945
		public Vector3 SampleControl1;

		// Token: 0x04006D2A RID: 27946
		public Vector3 SampleControl2;

		// Token: 0x04006D2B RID: 27947
		public byte sampleStep;

		// Token: 0x04006D2C RID: 27948
		public float delay;
	}
}
