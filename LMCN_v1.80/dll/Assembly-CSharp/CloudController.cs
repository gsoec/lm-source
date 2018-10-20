using System;
using UnityEngine;

// Token: 0x02000357 RID: 855
public class CloudController
{
	// Token: 0x06001199 RID: 4505 RVA: 0x001ED124 File Offset: 0x001EB324
	public CloudController()
	{
		this.offsetCenter = new Vector3[10];
		this.spriteRender = new SpriteRenderer[10];
		this.oriScale = new Vector3[10];
		this.sourcePosition = new Vector3[10];
		this.Init();
	}

	// Token: 0x0600119A RID: 4506 RVA: 0x001ED194 File Offset: 0x001EB394
	private void Init()
	{
		this.AssetName = "UI/Building";
		this.CloudBundle = AssetManager.GetAssetBundle(this.AssetName, out this.key, false);
		if (this.CloudBundle == null)
		{
			return;
		}
		this.CloudGO = (UnityEngine.Object.Instantiate(this.CloudBundle.Load("cloud")) as GameObject);
		this.MoveState = CloudMoveMode.None;
		this.UpdateColudController();
		this.SetSceneCloud();
		this.UpdateTime = this.UpdateTimeFrame;
	}

	// Token: 0x0600119B RID: 4507 RVA: 0x001ED218 File Offset: 0x001EB418
	public void UpdateColudController()
	{
		if (this.CloudGO == null)
		{
			return;
		}
		StageManager stageDataController = DataManager.StageDataController;
		this.ChapterID = (byte)(stageDataController.StageRecord[2] + 1);
		ushort num = 0;
		while ((int)num < this.CloudGO.transform.childCount)
		{
			if (num == 0)
			{
				Transform child = this.CloudGO.transform.GetChild((int)num);
				if (child == null)
				{
					break;
				}
				this.SetSpriteRenderColor(child, 0.4314f);
				child.gameObject.SetActive(true);
			}
			else
			{
				byte b = stageDataController.ChapterTable.GetRecordByKey(num).MapID - 1;
				if (this.CloudGO.transform.childCount < (int)b)
				{
					break;
				}
				Transform child = this.CloudGO.transform.GetChild((int)b);
				if (child == null)
				{
					break;
				}
				if ((ushort)this.ChapterID == num)
				{
					if (stageDataController.isNotFirstInChapter[2] == 0)
					{
						if (stageDataController.currentWorldMode == WorldMode.Wild)
						{
							child.gameObject.SetActive(true);
							this.SetGameObject(child.gameObject);
						}
						else
						{
							child.gameObject.SetActive(false);
						}
					}
					else
					{
						child.gameObject.SetActive(false);
					}
				}
				else if ((ushort)this.ChapterID > num)
				{
					child.gameObject.SetActive(false);
				}
				else
				{
					this.SetSpriteRenderColor(child, 0.4314f);
					child.gameObject.SetActive(true);
				}
			}
			num += 1;
		}
	}

	// Token: 0x0600119C RID: 4508 RVA: 0x001ED3B0 File Offset: 0x001EB5B0
	private void SetSpriteRenderColor(Transform mapTrans, float color)
	{
		for (int i = 0; i < mapTrans.childCount; i++)
		{
			SpriteRenderer component = mapTrans.GetChild(i).GetComponent<SpriteRenderer>();
			component.color = new Color(color, color, color);
		}
	}

	// Token: 0x0600119D RID: 4509 RVA: 0x001ED3F0 File Offset: 0x001EB5F0
	private void SetGameObject(GameObject go)
	{
		this.gameobject = go;
		Vector3 a = Vector3.zero;
		byte b = 0;
		while ((int)b < this.gameobject.transform.childCount)
		{
			if (b >= 10)
			{
				b -= 1;
				break;
			}
			this.sourcePosition[(int)b] = this.gameobject.transform.GetChild((int)b).position;
			this.offsetCenter[(int)b] = this.gameobject.transform.GetChild((int)b).position;
			this.spriteRender[(int)b] = this.gameobject.transform.GetChild((int)b).gameObject.GetComponent<SpriteRenderer>();
			this.oriScale[(int)b] = this.gameobject.transform.GetChild((int)b).localScale;
			this.spriteRender[(int)b].renderer.sortingOrder = -2;
			a += this.offsetCenter[(int)b];
			b += 1;
		}
		a /= (float)b;
		this.childCount = b;
		for (int i = 0; i < (int)this.childCount; i++)
		{
			this.offsetCenter[i] = a - this.offsetCenter[i];
			this.offsetCenter[i].Normalize();
		}
		this.CurTime = 0f;
		this.MoveState = CloudMoveMode.Ready;
	}

	// Token: 0x0600119E RID: 4510 RVA: 0x001ED578 File Offset: 0x001EB778
	private void SetSceneCloud()
	{
		this.SceneCloudCount = 0;
		byte b = 0;
		while ((int)b < this.CloudGO.transform.childCount)
		{
			for (int i = 0; i < this.CloudGO.transform.GetChild((int)b).childCount; i++)
			{
				float value = UnityEngine.Random.value;
				this.SceneCloud[(int)this.SceneCloudCount].transform = this.CloudGO.transform.GetChild((int)b).GetChild(i);
				this.SceneCloud[(int)this.SceneCloudCount].transform.GetComponent<SpriteRenderer>().sortingOrder = -2;
				this.SceneCloud[(int)this.SceneCloudCount].Chapter = b;
				this.SceneCloud[(int)this.SceneCloudCount].forward = (value >= 0.5f);
				this.SceneCloud[(int)this.SceneCloudCount].distance = 10f * value;
				this.SceneCloud[(int)this.SceneCloudCount].time = 0f;
				this.SceneCloud[(int)this.SceneCloudCount].totaltime = 10f * (1f + value);
				this.SceneCloud[(int)this.SceneCloudCount].origin = this.SceneCloud[(int)this.SceneCloudCount].transform.position.x;
				this.SceneCloud[(int)this.SceneCloudCount].endflag = 0;
				this.SceneCloudCount += 1;
			}
			b += 1;
		}
	}

	// Token: 0x0600119F RID: 4511 RVA: 0x001ED724 File Offset: 0x001EB924
	public void MapClick()
	{
		if (this.gameobject == null)
		{
			return;
		}
		GUIManager.Instance.ShowUILock(EUILock.Normal);
		this.UpdateColudController();
		this.MoveState = CloudMoveMode.Move;
		this.UpdateTimeFrame = 0f;
	}

	// Token: 0x060011A0 RID: 4512 RVA: 0x001ED768 File Offset: 0x001EB968
	public void Update()
	{
		float deltaTime = Time.deltaTime;
		this.UpdateTime -= deltaTime;
		if (this.UpdateTime > 0f)
		{
			return;
		}
		this.UpdateTime = this.UpdateTimeFrame;
		if (this.MoveState == CloudMoveMode.Move)
		{
			this.UpdateMove(deltaTime);
			this.CurTime += deltaTime;
		}
		this.UpdateSceneCloudMove(deltaTime);
		if (this.CurTime > this.TotalTime)
		{
			this.CurTime = 0f;
			this.MoveState = CloudMoveMode.Done;
			this.gameobject.SetActive(false);
			DataManager.msgBuffer[0] = 11;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x060011A1 RID: 4513 RVA: 0x001ED814 File Offset: 0x001EBA14
	public void UpdateMove(float delta)
	{
		float num = this.CurTime / this.TotalTime;
		for (int i = 0; i < this.gameobject.transform.childCount; i++)
		{
			float d;
			if (this.offsetCenter[i].normalized.x < 0f && this.offsetCenter[i].normalized.y < 0f)
			{
				d = -9.5f;
			}
			else
			{
				d = 9.5f;
			}
			this.gameobject.transform.GetChild(i).Translate(this.offsetCenter[i].normalized * delta * d);
			this.gameobject.transform.GetChild(i).localScale = this.oriScale[i] + this.oriScale[i] * (0.15f * num);
			Color color = this.spriteRender[i].color;
			color.a = EasingEffect.Quintic(this.CurTime, 1f, -1f, this.TotalTime);
			this.spriteRender[i].color = color;
		}
	}

	// Token: 0x060011A2 RID: 4514 RVA: 0x001ED96C File Offset: 0x001EBB6C
	private void UpdateSceneCloudMove(float delta)
	{
		for (int i = 0; i < (int)this.SceneCloudCount; i++)
		{
			if (this.MoveState != CloudMoveMode.Move || this.ChapterID != this.SceneCloud[i].Chapter)
			{
				if (this.SceneCloud[i].transform.gameObject.activeInHierarchy)
				{
					Vector3 position = this.SceneCloud[i].transform.position;
					float x;
					if (this.SceneCloud[i].forward)
					{
						x = this.SceneCloud[i].origin + this.SceneCloud[i].distance * (this.SceneCloud[i].time / this.SceneCloud[i].totaltime);
					}
					else
					{
						x = this.SceneCloud[i].origin - this.SceneCloud[i].distance * (this.SceneCloud[i].time / this.SceneCloud[i].totaltime);
					}
					position.x = x;
					this.SceneCloud[i].transform.position = position;
					CloudController._SceneCloud[] sceneCloud = this.SceneCloud;
					int num = i;
					sceneCloud[num].time = sceneCloud[num].time + delta;
					if (this.SceneCloud[i].time > this.SceneCloud[i].totaltime)
					{
						this.SceneCloud[i].time = 0f;
						this.SceneCloud[i].forward = !this.SceneCloud[i].forward;
						this.SceneCloud[i].origin = this.SceneCloud[i].transform.position.x;
						CloudController._SceneCloud[] sceneCloud2 = this.SceneCloud;
						int num2 = i;
						CloudController._SceneCloud[] sceneCloud3 = this.SceneCloud;
						int num3 = i;
						sceneCloud2[num2].endflag = ((sceneCloud3[num3].endflag = sceneCloud3[num3].endflag + 1) & 1);
						if (this.SceneCloud[i].endflag == 0)
						{
							float value = UnityEngine.Random.value;
							this.SceneCloud[i].distance = 10f * value;
							this.SceneCloud[i].totaltime = 10f * (1f + value);
						}
					}
				}
			}
		}
	}

	// Token: 0x060011A3 RID: 4515 RVA: 0x001EDBF4 File Offset: 0x001EBDF4
	private CloudMoveMode GetCloudState()
	{
		return this.MoveState;
	}

	// Token: 0x060011A4 RID: 4516 RVA: 0x001EDBFC File Offset: 0x001EBDFC
	public void Reset()
	{
		byte b = 0;
		while ((int)b < this.gameobject.transform.childCount)
		{
			this.gameobject.transform.GetChild((int)b).position = this.sourcePosition[(int)b];
			this.gameobject.transform.GetChild((int)b).localScale = this.oriScale[(int)b];
			Color color = this.spriteRender[(int)b].color;
			color.a = 255f;
			this.spriteRender[(int)b].color = color;
			b += 1;
		}
		this.CurTime = 0f;
		this.MoveState = CloudMoveMode.Ready;
		DataManager.StageDataController.isNotFirstInChapter[2] = 0;
		this.gameobject.SetActive(true);
	}

	// Token: 0x060011A5 RID: 4517 RVA: 0x001EDCD0 File Offset: 0x001EBED0
	public void Destory()
	{
		if (this.CloudGO)
		{
			UnityEngine.Object.Destroy(this.CloudGO);
		}
		this.CloudGO = null;
		AssetManager.UnloadAssetBundle(this.key, true);
	}

	// Token: 0x04003805 RID: 14341
	private const byte MaxchildCount = 10;

	// Token: 0x04003806 RID: 14342
	private const float CloudMoveFactor = 10f;

	// Token: 0x04003807 RID: 14343
	private AssetBundle CloudBundle;

	// Token: 0x04003808 RID: 14344
	private string AssetName;

	// Token: 0x04003809 RID: 14345
	private int key;

	// Token: 0x0400380A RID: 14346
	private GameObject CloudGO;

	// Token: 0x0400380B RID: 14347
	private GameObject gameobject;

	// Token: 0x0400380C RID: 14348
	private Vector3[] sourcePosition;

	// Token: 0x0400380D RID: 14349
	private Vector3[] offsetCenter;

	// Token: 0x0400380E RID: 14350
	private SpriteRenderer[] spriteRender;

	// Token: 0x0400380F RID: 14351
	private Vector3[] oriScale;

	// Token: 0x04003810 RID: 14352
	private byte childCount;

	// Token: 0x04003811 RID: 14353
	private byte ChapterID;

	// Token: 0x04003812 RID: 14354
	private CloudController._SceneCloud[] SceneCloud = new CloudController._SceneCloud[100];

	// Token: 0x04003813 RID: 14355
	private byte SceneCloudCount;

	// Token: 0x04003814 RID: 14356
	public float TotalTime = 2f;

	// Token: 0x04003815 RID: 14357
	private float CurTime;

	// Token: 0x04003816 RID: 14358
	private float UpdateTime;

	// Token: 0x04003817 RID: 14359
	private float UpdateTimeFrame = 0.3f;

	// Token: 0x04003818 RID: 14360
	private CloudMoveMode MoveState;

	// Token: 0x02000358 RID: 856
	public struct _SceneCloud
	{
		// Token: 0x04003819 RID: 14361
		public byte Chapter;

		// Token: 0x0400381A RID: 14362
		public Transform transform;

		// Token: 0x0400381B RID: 14363
		public float time;

		// Token: 0x0400381C RID: 14364
		public float totaltime;

		// Token: 0x0400381D RID: 14365
		public bool forward;

		// Token: 0x0400381E RID: 14366
		public float origin;

		// Token: 0x0400381F RID: 14367
		public float distance;

		// Token: 0x04003820 RID: 14368
		public byte endflag;
	}
}
