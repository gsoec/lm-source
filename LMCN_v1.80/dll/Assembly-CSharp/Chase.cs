using System;
using UnityEngine;

// Token: 0x0200004F RID: 79
public class Chase
{
	// Token: 0x06000222 RID: 546 RVA: 0x0001D5AC File Offset: 0x0001B7AC
	public Chase()
	{
		this.bMove = false;
		this.Offset = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06000223 RID: 547 RVA: 0x0001D5D8 File Offset: 0x0001B7D8
	public void AddParticleChase(Vector3 Source, Vector3 Target, float TotalTime, ushort ParticleID, float ParticleScale, ChaseType CurveType)
	{
		this.Target = Target;
		this.TotalTime = TotalTime;
		this.Type = CurveType;
		this.particleID = ParticleID;
		if (this.particleID < 0)
		{
			return;
		}
		this.SourceObj = ParticleManager.Instance.Spawn(this.particleID, null, Source, ParticleScale, true, false, true);
		if (this.SourceObj == null)
		{
			return;
		}
		if (this.Type == ChaseType.CurveRandom)
		{
			byte b = (byte)Mathf.Max(0f, 40f * UnityEngine.Random.value / 10f);
			if (b == 0)
			{
				this.Type = ChaseType.Straight;
			}
			else if (b == 1)
			{
				this.Type = ChaseType.CurveA;
			}
			else if (b == 2)
			{
				this.Type = ChaseType.CurveLeft;
			}
			else
			{
				this.Type = ChaseType.CurveRight;
			}
		}
		if (this.Type == ChaseType.Straight)
		{
			this.initStraight();
		}
		else
		{
			this.initCurve();
		}
	}

	// Token: 0x06000224 RID: 548 RVA: 0x0001D6C4 File Offset: 0x0001B8C4
	private void initStraight()
	{
		this.UsedSampleCount = 2;
		this.CreateSamplePoint();
		this.LookTarget(this.Target);
		this.SamplePoint[0] = this.SourceObj.transform.position;
		this.SamplePoint[1] = this.Target + this.Offset;
		this.SampleTime[0] = 0f;
		this.SampleTime[1] = this.TotalTime;
		this.LifeTime = 0f;
		this.bMove = true;
	}

	// Token: 0x06000225 RID: 549 RVA: 0x0001D75C File Offset: 0x0001B95C
	private void LookTarget(Vector3 target)
	{
		Vector3 vector = target - this.SourceObj.transform.position;
		if (vector == Vector3.zero)
		{
			return;
		}
		Quaternion rotation = Quaternion.LookRotation(vector);
		this.SourceObj.transform.rotation = rotation;
	}

	// Token: 0x06000226 RID: 550 RVA: 0x0001D7AC File Offset: 0x0001B9AC
	private void initCurve()
	{
		this.UsedSampleCount = 2;
		this.CreateSamplePoint();
		this.SamplePoint[0] = this.SourceObj.transform.position;
		this.SamplePoint[1] = this.Target + this.Offset;
		this.SampleTime[0] = 0f;
		this.SampleTime[1] = this.TotalTime;
		if (this.Type == ChaseType.CurveB)
		{
			this.CurveHeight = Vector3.Distance(this.SourceObj.transform.position, this.Target) * 0.4f;
		}
		else
		{
			this.CurveHeight = Vector3.Distance(this.SourceObj.transform.position, this.Target) * 0.25f;
		}
		this.UpdateSampleControl();
		this.LifeTime = 0f;
		this.bMove = true;
		this.LookTarget(this.Target);
	}

	// Token: 0x06000227 RID: 551 RVA: 0x0001D8A8 File Offset: 0x0001BAA8
	private void UpdateSampleControl()
	{
		if (this.Type == ChaseType.CurveB)
		{
			this.SampleControl[0] = this.SamplePoint[0] + (this.SamplePoint[1] - this.SamplePoint[0]) * 0.25f;
			this.SampleControl[1] = this.SamplePoint[0] + (this.SamplePoint[1] - this.SamplePoint[0]) * 0.75f;
		}
		else
		{
			this.SampleControl[0] = this.SamplePoint[0] + (this.SamplePoint[1] - this.SamplePoint[0]) * 0.25f;
			this.SampleControl[1] = this.SamplePoint[0] + (this.SamplePoint[1] - this.SamplePoint[0]) * 0.6f;
		}
		switch (this.Type)
		{
		case ChaseType.CurveA:
		case ChaseType.CurveB:
		{
			Vector3[] sampleControl = this.SampleControl;
			int num = 0;
			sampleControl[num].y = sampleControl[num].y + this.CurveHeight;
			Vector3[] sampleControl2 = this.SampleControl;
			int num2 = 1;
			sampleControl2[num2].y = sampleControl2[num2].y + this.CurveHeight;
			break;
		}
		case ChaseType.CurveLeft:
		{
			Vector3[] sampleControl3 = this.SampleControl;
			int num3 = 0;
			sampleControl3[num3].z = sampleControl3[num3].z - this.CurveHeight;
			Vector3[] sampleControl4 = this.SampleControl;
			int num4 = 1;
			sampleControl4[num4].z = sampleControl4[num4].z - this.CurveHeight;
			break;
		}
		case ChaseType.CurveRight:
		{
			Vector3[] sampleControl5 = this.SampleControl;
			int num5 = 0;
			sampleControl5[num5].z = sampleControl5[num5].z + this.CurveHeight;
			Vector3[] sampleControl6 = this.SampleControl;
			int num6 = 1;
			sampleControl6[num6].z = sampleControl6[num6].z + this.CurveHeight;
			break;
		}
		}
	}

	// Token: 0x06000228 RID: 552 RVA: 0x0001DB10 File Offset: 0x0001BD10
	private void CreateSamplePoint()
	{
		this.SamplePoint = new Vector3[(int)this.UsedSampleCount];
		this.SampleControl = new Vector3[(int)this.UsedSampleCount];
		this.SampleTime = new float[(int)this.UsedSampleCount];
	}

	// Token: 0x06000229 RID: 553 RVA: 0x0001DB48 File Offset: 0x0001BD48
	public void Update()
	{
		if (!this.bMove)
		{
			return;
		}
		if (this.LifeTime > this.SampleTime[(int)(this.UsedSampleCount - 1)])
		{
			this.bMove = false;
			this.SourceObj.transform.position = this.SamplePoint[(int)(this.UsedSampleCount - 1)];
			this.StopParticle();
			return;
		}
		this.SamplePoint[(int)(this.UsedSampleCount - 1)] = this.Target + this.Offset;
		if (this.Type != ChaseType.Straight)
		{
			this.UpdateSampleControl();
		}
		if (this.Type == ChaseType.Straight)
		{
			this.LookTarget(this.SamplePoint[(int)(this.UsedSampleCount - 1)]);
			float num = this.LifeTime / this.TotalTime;
			if (!float.IsNaN(num))
			{
				this.SourceObj.transform.position = this.SamplePoint[0] + (this.SamplePoint[1] - this.SamplePoint[0]) * num;
			}
			else
			{
				Debug.Log(string.Format("NAN:{0}/{1}", this.LifeTime, this.TotalTime));
			}
		}
		else
		{
			this.Evaluate();
		}
		this.LifeTime += Time.deltaTime;
	}

	// Token: 0x0600022A RID: 554 RVA: 0x0001DCC8 File Offset: 0x0001BEC8
	public void StopParticle()
	{
		if (this.particleID > 0)
		{
			ParticleManager.Instance.DeSpawn(this.SourceObj);
		}
		this.particleID = 0;
	}

	// Token: 0x0600022B RID: 555 RVA: 0x0001DCFC File Offset: 0x0001BEFC
	private void Evaluate()
	{
		int i;
		for (i = 0; i < (int)(this.UsedSampleCount - 1); i++)
		{
			if (this.LifeTime < this.SampleTime[i + 1])
			{
				break;
			}
		}
		if (i >= (int)(this.UsedSampleCount - 1))
		{
			return;
		}
		float num = this.SampleTime[i];
		float num2 = this.SampleTime[i + 1];
		float d = (this.LifeTime - num) / (num2 - num);
		Vector3 a = this.SamplePoint[i + 1] - 3f * this.SampleControl[2 * i + 1] + 3f * this.SampleControl[2 * i] - this.SamplePoint[i];
		Vector3 a2 = 3f * this.SampleControl[2 * i + 1] - 6f * this.SampleControl[2 * i] + 3f * this.SamplePoint[i];
		Vector3 a3 = 3f * this.SampleControl[2 * i] - 3f * this.SamplePoint[i];
		Vector3 vector = this.SamplePoint[0] + d * (a3 + d * (a2 + d * a));
		this.LookTarget(vector);
		this.SourceObj.transform.position = vector;
	}

	// Token: 0x04000414 RID: 1044
	public GameObject SourceObj;

	// Token: 0x04000415 RID: 1045
	private Vector3 Target;

	// Token: 0x04000416 RID: 1046
	private Vector3[] SamplePoint;

	// Token: 0x04000417 RID: 1047
	private Vector3[] SampleControl;

	// Token: 0x04000418 RID: 1048
	private Vector3 Offset;

	// Token: 0x04000419 RID: 1049
	private float[] SampleTime;

	// Token: 0x0400041A RID: 1050
	private byte UsedSampleCount;

	// Token: 0x0400041B RID: 1051
	private float TotalTime;

	// Token: 0x0400041C RID: 1052
	private float LifeTime;

	// Token: 0x0400041D RID: 1053
	public bool bMove;

	// Token: 0x0400041E RID: 1054
	private ChaseType Type;

	// Token: 0x0400041F RID: 1055
	private float CurveHeight;

	// Token: 0x04000420 RID: 1056
	public ushort particleID;
}
