using System;
using UnityEngine;

// Token: 0x0200072E RID: 1838
public class FlyingObject
{
	// Token: 0x06002328 RID: 9000 RVA: 0x0040DC20 File Offset: 0x0040BE20
	public FlyingObject()
	{
		this.bMove = false;
		this.Offset = new Vector3(0f, 1f, 0f);
		this.CreateSamplePoint();
	}

	// Token: 0x170000CB RID: 203
	// (get) Token: 0x06002329 RID: 9001 RVA: 0x0040DC50 File Offset: 0x0040BE50
	public Vector3 EndPoint
	{
		get
		{
			return this.Target + this.Offset;
		}
	}

	// Token: 0x0600232A RID: 9002 RVA: 0x0040DC64 File Offset: 0x0040BE64
	public void AddFlyingObject(Vector3 Source, Transform Target, float TotalTime, Vector3 offset, Transform scaleRoot, ChaseType CurveType)
	{
		this.Target = Target.position;
		this.Type = CurveType;
		this.TotalTime = TotalTime;
		this.Offset = offset;
		this.specialDelay = 0f;
		this.ScaleRoot = scaleRoot;
		if (this.ScaleRoot != null)
		{
			MeshRenderer component = this.SourceObj.GetComponent<MeshRenderer>();
			if (component != null)
			{
				component.sharedMaterial = SheetAnimInfo.Instance.nonBatching_sharedMat;
			}
		}
		this.SourceObj.transform.position = Source;
		if (this.Type == ChaseType.Straight)
		{
			this.initStraight();
		}
		else
		{
			this.initCurve();
		}
	}

	// Token: 0x0600232B RID: 9003 RVA: 0x0040DD10 File Offset: 0x0040BF10
	private void EndingCheck()
	{
		if (this.ScaleRoot != null)
		{
			MeshRenderer component = this.SourceObj.GetComponent<MeshRenderer>();
			if (component != null)
			{
				component.sharedMaterial = SheetAnimInfo.GetMaterial(ESheetMeshTexKind.WAR_BLUE);
			}
			this.ScaleRoot = null;
		}
	}

	// Token: 0x0600232C RID: 9004 RVA: 0x0040DD5C File Offset: 0x0040BF5C
	private void LookTarget(Vector3 Target)
	{
		Vector3 vector = Target - this.SourceObj.transform.position;
		if (vector == Vector3.zero)
		{
			return;
		}
		Quaternion rotation = Quaternion.LookRotation(vector);
		this.SourceObj.transform.rotation = rotation;
	}

	// Token: 0x0600232D RID: 9005 RVA: 0x0040DDAC File Offset: 0x0040BFAC
	private void initCurve()
	{
		this.SamplePoint[0] = this.SourceObj.transform.position;
		this.SamplePoint[1] = this.Target + this.Offset;
		this.SampleTime[0] = 0f;
		this.SampleTime[1] = this.TotalTime;
		float num = UnityEngine.Random.Range(0.3f, 0.5f);
		this.CurveHeight = Vector3.Distance(this.SourceObj.transform.position, this.Target) * num;
		this.UpdateSampleControl();
		this.LifeTime = 0f;
		this.ShiftStep = 0f;
		this.bMove = true;
		this.LookTarget(this.Target);
	}

	// Token: 0x0600232E RID: 9006 RVA: 0x0040DE7C File Offset: 0x0040C07C
	private void initStraight()
	{
		this.LookTarget(this.Target);
		this.SamplePoint[0] = this.SourceObj.transform.position;
		this.SamplePoint[1] = this.Target + this.Offset;
		this.SampleTime[0] = 0f;
		this.SampleTime[1] = this.TotalTime;
		this.LifeTime = 0f;
		this.bMove = true;
	}

	// Token: 0x0600232F RID: 9007 RVA: 0x0040DF08 File Offset: 0x0040C108
	private void UpdateSampleControl()
	{
		Vector3 a = this.SamplePoint[1] - this.SamplePoint[0];
		this.SampleControl[0] = this.SamplePoint[0] + a * 0.25f;
		this.SampleControl[1] = this.SamplePoint[0] + a * 0.6f;
		Vector3[] sampleControl = this.SampleControl;
		int num = 0;
		sampleControl[num].y = sampleControl[num].y + this.CurveHeight;
		Vector3[] sampleControl2 = this.SampleControl;
		int num2 = 1;
		sampleControl2[num2].y = sampleControl2[num2].y + this.CurveHeight;
	}

	// Token: 0x06002330 RID: 9008 RVA: 0x0040DFE0 File Offset: 0x0040C1E0
	private void CreateSamplePoint()
	{
		this.SamplePoint = new Vector3[2];
		this.SampleControl = new Vector3[2];
		this.SampleTime = new float[2];
	}

	// Token: 0x06002331 RID: 9009 RVA: 0x0040E014 File Offset: 0x0040C214
	public void Destroy()
	{
		if (this.SourceObj != null)
		{
			UnityEngine.Object.Destroy(this.SourceObj);
			this.SourceObj = null;
		}
	}

	// Token: 0x06002332 RID: 9010 RVA: 0x0040E03C File Offset: 0x0040C23C
	public void Update(float deltaTime)
	{
		if (!this.bMove)
		{
			return;
		}
		if (this.LifeTime > this.SampleTime[1])
		{
			this.bMove = false;
			this.SourceObj.transform.position = this.SamplePoint[1];
			return;
		}
		this.SamplePoint[1] = this.Target + this.Offset;
		if (this.Type == ChaseType.Straight)
		{
			this.LookTarget(this.SamplePoint[1]);
			if (Mathf.Abs(this.TotalTime) >= 0.001f)
			{
				float d = this.LifeTime / this.TotalTime;
				this.SourceObj.transform.position = this.SamplePoint[0] + (this.SamplePoint[1] - this.SamplePoint[0]) * d;
			}
		}
		else
		{
			this.UpdateSampleControl();
			this.Evaluate(deltaTime);
		}
		if (this.ScaleRoot != null)
		{
			this.SourceObj.transform.localScale = this.ScaleRoot.localScale * 0.333333343f;
		}
		float num = this.EaseOutIn(this.LifeTime, 1.1f, 0.9f, this.TotalTime);
		this.ShiftStep += deltaTime * num;
		this.LifeTime += deltaTime;
	}

	// Token: 0x06002333 RID: 9011 RVA: 0x0040E1D0 File Offset: 0x0040C3D0
	private void Evaluate(float deltaTime)
	{
		float num = this.SampleTime[0];
		float num2 = this.SampleTime[1];
		float d = (this.ShiftStep - num) / (num2 - num);
		Vector3 a = this.SamplePoint[1] - (this.SampleControl[1] - this.SampleControl[0]) * 3f - this.SamplePoint[0];
		Vector3 a2 = 3f * (this.SampleControl[1] + this.SamplePoint[0]) - 6f * this.SampleControl[0];
		Vector3 a3 = (this.SampleControl[0] - this.SamplePoint[0]) * 3f;
		Vector3 vector = this.SamplePoint[0] + d * (a3 + d * (a2 + d * a));
		if (this.foKind == FOKind.Stone || this.foKind == FOKind.FireStone)
		{
			this.SourceObj.transform.Rotate(Vector3.left, 720f * deltaTime, Space.Self);
		}
		else if (this.foKind != FOKind.LightBall)
		{
			this.LookTarget(vector);
		}
		this.SourceObj.transform.position = vector;
	}

	// Token: 0x06002334 RID: 9012 RVA: 0x0040E378 File Offset: 0x0040C578
	private float EaseOutIn(float time, float from, float to, float duration)
	{
		float num = duration * 0.5f;
		if (time < num)
		{
			return Mathf.SmoothStep(from, to, time / num);
		}
		return Mathf.SmoothStep(to, from, (time - num) / num);
	}

	// Token: 0x04006C31 RID: 27697
	private const byte UsedSampleCount = 2;

	// Token: 0x04006C32 RID: 27698
	private const float InverseHeroScaleBase = 0.333333343f;

	// Token: 0x04006C33 RID: 27699
	public GameObject SourceObj;

	// Token: 0x04006C34 RID: 27700
	private Vector3 Target;

	// Token: 0x04006C35 RID: 27701
	private Transform ScaleRoot;

	// Token: 0x04006C36 RID: 27702
	private Vector3[] SamplePoint;

	// Token: 0x04006C37 RID: 27703
	private Vector3[] SampleControl;

	// Token: 0x04006C38 RID: 27704
	private Vector3 Offset;

	// Token: 0x04006C39 RID: 27705
	private float[] SampleTime;

	// Token: 0x04006C3A RID: 27706
	private float TotalTime;

	// Token: 0x04006C3B RID: 27707
	private float LifeTime;

	// Token: 0x04006C3C RID: 27708
	private float ShiftStep;

	// Token: 0x04006C3D RID: 27709
	public bool bMove;

	// Token: 0x04006C3E RID: 27710
	private float CurveHeight;

	// Token: 0x04006C3F RID: 27711
	public float specialDelay;

	// Token: 0x04006C40 RID: 27712
	private ChaseType Type;

	// Token: 0x04006C41 RID: 27713
	public FOKind foKind;
}
