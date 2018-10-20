using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020006D9 RID: 1753
public class CameraMove
{
	// Token: 0x06002156 RID: 8534 RVA: 0x003F70A0 File Offset: 0x003F52A0
	public CameraMove(CameraState in_cameraState)
	{
		this.CameraInit();
		int num = 0;
		if (in_cameraState == CameraState.Area)
		{
			if (DataManager.StageDataController._stageMode == StageMode.Corps)
			{
				num = (int)DataManager.StageDataController.StageRecord[2];
				if (DataManager.Instance.lastBattleResult != 1)
				{
					num++;
				}
			}
			else
			{
				num = (int)DataManager.StageDataController.currentChapterID;
			}
		}
		this.SetCameraPos(num);
	}

	// Token: 0x06002157 RID: 8535 RVA: 0x003F710C File Offset: 0x003F530C
	~CameraMove()
	{
	}

	// Token: 0x06002158 RID: 8536 RVA: 0x003F7144 File Offset: 0x003F5344
	public void CameraInit()
	{
		Camera.main.fieldOfView = 25f;
		this.mPos = Camera.main.transform.position;
		this.tmpPos = Vector3.zero;
		this.NextPos = Vector3.zero;
		this.TargetPos = Vector3.zero;
		this.AnglePos = Vector3.zero;
		this.pressPosition = Vector2.zero;
		this.pressPosition2 = Vector2.zero;
		this.mTime = 0f;
		this.speed = 1f;
		this.mBegin = 0f;
		this.tmp = 0f;
		this.IsEndDrag = false;
		this.IsGoNow = false;
		this.Limit = DataManager.Instance.WorldCameraLimit;
		this.TmpV3Pos.Set(-11.938f, 181.12f, 204.91f);
		this.TmpV3Rot.Set(45f, 180f, 0.1f);
	}

	// Token: 0x06002159 RID: 8537 RVA: 0x003F7238 File Offset: 0x003F5438
	public void SetCameraState(CameraState state, byte LeveL = 0, bool GoNow = false)
	{
		if (this.NextState != this.mState)
		{
			return;
		}
		int num = (int)this.mLevel;
		this.mLevel = LeveL;
		if (this.mLevel == 0)
		{
			if (state == CameraState.World && num != 0)
			{
				this.chapter = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort)num);
				this.NextPos = GameConstants.WordToVector3(this.chapter.CameraPos.X, this.chapter.CameraPos.Y, this.chapter.CameraPos.Z, -100, 0.01f);
				this.tmpPos = GameConstants.WordToVector3(this.chapter.CameraRot.X, this.chapter.CameraRot.Y, this.chapter.CameraRot.Z, -100, 0.01f);
				float num2 = this.NextPos.z + this.TmpV3Pos.y - this.NextPos.y;
				if (num2 < 110f + this.Limit)
				{
					num2 = 110f + this.Limit;
				}
				else if (num2 > 280f + this.Limit * 0.5f)
				{
					num2 = 280f + this.Limit * 0.5f;
				}
				this.TmpV3Pos = new Vector3(this.NextPos.x, this.TmpV3Pos.y, num2);
			}
			this.NextPos = this.TmpV3Pos;
			this.tmpPos = this.TmpV3Rot;
		}
		else
		{
			this.chapter = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort)this.mLevel);
			this.NextPos = GameConstants.WordToVector3(this.chapter.CameraPos.X, this.chapter.CameraPos.Y, this.chapter.CameraPos.Z, -100, 0.01f);
			this.tmpPos = GameConstants.WordToVector3(this.chapter.CameraRot.X, this.chapter.CameraRot.Y, this.chapter.CameraRot.Z, -100, 0.01f);
		}
		this.NextQuaternion.eulerAngles = this.tmpPos;
		this.IsGoNow = GoNow;
		this.mPos = Camera.main.transform.position;
		this.tmpQuaternion = Camera.main.transform.rotation;
		if (this.IsGoNow && DataManager.StageDataController._stageMode == StageMode.Corps && DataManager.StageDataController.isNotFirstInChapter[2] == 0)
		{
			this.TargetPos = this.NextPos;
			this.IsOpenGoNow = true;
			this.IsGoNow = false;
			float num3 = this.NextPos.z + Camera.main.transform.position.y - this.NextPos.y;
			if (num3 < 110f + this.Limit)
			{
				num3 = 110f + this.Limit;
			}
			else if (num3 > 280f + this.Limit * 0.5f)
			{
				num3 = 280f + this.Limit * 0.5f;
			}
			this.NextPos = new Vector3(this.NextPos.x, Camera.main.transform.position.y, num3);
			this.TmpV3Pos = this.NextPos;
			this.NextPos -= this.mPos;
		}
		else if (!this.IsGoNow)
		{
			this.NextPos -= this.mPos;
		}
		else
		{
			this.TargetPos = this.NextPos;
			this.NextPos.Set(this.NextPos.x - this.mPos.x, 0f, 0f);
			this.mBegin = 0f;
			this.Distance = 0f;
		}
		this.mTime = 0f;
		this.speed = 2f;
		this.speed2 = 0f;
		this.NextState = state;
		this.AnglePos = this.NextQuaternion.eulerAngles - this.tmpQuaternion.eulerAngles;
		if (state != this.mState)
		{
			DataManager.msgBuffer[0] = 46;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			DataManager.msgBuffer[0] = 42;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x0600215A RID: 8538 RVA: 0x003F76BC File Offset: 0x003F58BC
	public void CameraMoveTarget(CameraState state, Vector3 TargetPosition)
	{
		if (this.NextState != this.mState)
		{
			return;
		}
		this.mPos = Camera.main.transform.position;
		this.tmpQuaternion = Camera.main.transform.rotation;
		if (TargetPosition.x >= 250f - this.Limit * 0.4f)
		{
			TargetPosition.x = 250f - this.Limit * 0.4f;
		}
		else if (TargetPosition.x <= -315f + this.Limit * 0.35f)
		{
			TargetPosition.x = -315f + this.Limit * 0.35f;
		}
		float num = TargetPosition.z + (this.mPos.y - TargetPosition.y);
		if (num >= 280f + this.Limit * 0.5f)
		{
			num = 280f + this.Limit * 0.5f;
		}
		else if (num <= 110f + this.Limit)
		{
			num = 110f + this.Limit;
		}
		this.NextPos.Set(TargetPosition.x - this.mPos.x, 0f, num - this.mPos.z);
		this.AnglePos = Vector2.zero;
		this.mTime = 0f;
		this.speed = 2f;
		this.speed2 = 0f;
		this.NextState = state;
	}

	// Token: 0x0600215B RID: 8539 RVA: 0x003F784C File Offset: 0x003F5A4C
	public void SetCameraPos(int AreaLevel)
	{
		if (AreaLevel == 0)
		{
			this.mState = CameraState.World;
			this.NextState = CameraState.World;
			Camera.main.transform.eulerAngles = this.TmpV3Rot;
			Camera.main.transform.position = this.TmpV3Pos;
		}
		else
		{
			this.mState = CameraState.Area;
			this.NextState = CameraState.Area;
			this.chapter = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort)AreaLevel);
			Camera.main.transform.eulerAngles = GameConstants.WordToVector3(this.chapter.CameraRot.X, this.chapter.CameraRot.Y, this.chapter.CameraRot.Z, -100, 0.01f);
			Camera.main.transform.position = GameConstants.WordToVector3(this.chapter.CameraPos.X, this.chapter.CameraPos.Y, this.chapter.CameraPos.Z, -100, 0.01f);
		}
		this.mLevel = (byte)AreaLevel;
	}

	// Token: 0x0600215C RID: 8540 RVA: 0x003F7960 File Offset: 0x003F5B60
	public void SetCamerPos_Out()
	{
		this.mState = CameraState.World;
		this.NextState = CameraState.World;
		Camera.main.transform.localPosition = DataManager.Instance.WorldCameraTransitionsPos;
		Camera.main.transform.eulerAngles = this.TmpV3Rot;
		this.Limit = DataManager.Instance.WorldCameraLimit;
	}

	// Token: 0x0600215D RID: 8541 RVA: 0x003F79BC File Offset: 0x003F5BBC
	public void CameraUpdata()
	{
		Transform transform = Camera.main.transform;
		if (this.mState != this.NextState)
		{
			if (this.IsGoNow)
			{
				if (Time.smoothDeltaTime > this.Distance)
				{
					this.Distance = Time.smoothDeltaTime;
				}
				if (this.NextPos.x > 0f)
				{
					this.mBegin += 100f * this.Distance;
				}
				else
				{
					this.mBegin -= 100f * this.Distance;
				}
				if (Mathf.Abs(this.mBegin) > Mathf.Abs(this.NextPos.x))
				{
					this.mBegin = this.NextPos.x;
					this.mTime = 0f;
					this.Distance = 0f;
					this.IsGoNow = false;
					this.tmpPos = this.mPos + this.NextPos;
					transform.position = this.tmpPos;
					this.mPos = transform.position;
					this.NextPos = this.TargetPos - this.mPos;
					this.TmpV3Pos = this.mPos;
					DataManager.msgBuffer[0] = 10;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					return;
				}
				this.tmpPos.Set(this.mPos.x + this.mBegin, this.mPos.y, this.mPos.z);
			}
			else
			{
				this.mTime += Time.smoothDeltaTime;
				if (this.IsOpenGoNow)
				{
					this.speed -= this.Limit / 100f;
					this.tmp = this.mTime * this.speed;
				}
				else
				{
					float num = this.speed;
					num -= this.Limit / 100f;
					this.tmp = this.mTime * num;
				}
				if (this.tmp > 0.99f)
				{
					this.tmp = 1f;
					if (this.NextState == CameraState.Area)
					{
						if (this.IsOpenGoNow)
						{
							this.speed = 0.5f;
							this.mTime = 0f;
							this.IsOpenGoNow = false;
							this.tmpPos = this.mPos + this.tmp * this.NextPos;
							transform.position = this.tmpPos;
							this.mPos = transform.position;
							this.NextPos = this.TargetPos - this.mPos;
							DataManager.msgBuffer[0] = 10;
							GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
							return;
						}
						this.mState = CameraState.Area;
						DataManager.msgBuffer[0] = 8;
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					}
					else if (this.NextState == CameraState.World)
					{
						this.mState = CameraState.World;
						DataManager.msgBuffer[0] = 19;
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					}
					else if (this.mState == CameraState.World)
					{
						this.mState = CameraState.World;
						this.NextState = CameraState.World;
					}
					else
					{
						this.mState = CameraState.Area;
						this.NextState = CameraState.Area;
					}
				}
				if (!this.IsOpenGoNow)
				{
					this.tmpPos = this.tmpQuaternion.eulerAngles + this.tmp * this.AnglePos;
					this.NextQuaternion.eulerAngles = this.tmpPos;
					transform.rotation = this.NextQuaternion;
				}
				this.tmpPos = this.mPos + this.tmp * this.NextPos;
			}
			transform.position = this.tmpPos;
		}
		else if (this.mState == CameraState.World)
		{
			if (this.IsEndDrag)
			{
				if (this.IsBackEndDragX > 0)
				{
					this.tmpTime1 += Time.smoothDeltaTime;
					this.speed *= Mathf.Pow(0.8f, this.tmpTime1);
					if (Mathf.Abs(this.speed) < 1f)
					{
						this.speed = 0f;
						this.IsBackEndDragX = 0;
					}
				}
				else
				{
					this.speed *= Mathf.Pow(0.135f, this.mTime);
					if (Mathf.Abs(this.speed) < 1f)
					{
						this.speed = 0f;
					}
				}
				if (this.IsBackEndDragY > 0)
				{
					this.tmpTime2 += Time.smoothDeltaTime;
					this.speed2 *= Mathf.Pow(0.8f, this.tmpTime2);
					if (Mathf.Abs(this.speed2) < 1f)
					{
						this.speed2 = 0f;
						this.IsBackEndDragY = 0;
					}
				}
				else
				{
					this.speed2 *= Mathf.Pow(0.135f, this.mTime);
					if (Mathf.Abs(this.speed2) < 1f)
					{
						this.speed2 = 0f;
					}
				}
				if (this.speed != 0f || this.speed2 != 0f)
				{
					this.tmpPos.Set(this.speed * Time.smoothDeltaTime, 0f, this.speed2 * Time.smoothDeltaTime);
					transform.position += this.tmpPos;
				}
				else
				{
					this.IsEndDrag = false;
				}
			}
			else if (this.bMove)
			{
				float to = (transform.position.x - this.tmpCameraPos.x) / Time.smoothDeltaTime;
				this.speed = Mathf.Lerp(this.speed, to, Time.smoothDeltaTime * 5f);
				to = (transform.position.z - this.tmpCameraPos.z) / Time.smoothDeltaTime;
				this.speed2 = Mathf.Lerp(this.speed2, to, Time.smoothDeltaTime * 5f);
			}
			if (this.IsBackEndDragX > 0)
			{
				if (transform.position.x >= 265f - this.Limit * 0.4f)
				{
					this.tmpPos.Set(265f - this.Limit * 0.4f, transform.position.y, transform.position.z);
					transform.position = this.tmpPos;
				}
				else if (transform.position.x <= -330f + this.Limit * 0.35f)
				{
					this.tmpPos.Set(-330f + this.Limit * 0.35f, transform.position.y, transform.position.z);
					transform.position = this.tmpPos;
				}
			}
			else if (transform.position.x >= 250f - this.Limit * 0.4f)
			{
				this.tmpPos.Set(250f - this.Limit * 0.4f, transform.position.y, transform.position.z);
				transform.position = this.tmpPos;
			}
			else if (transform.position.x <= -315f + this.Limit * 0.35f)
			{
				this.tmpPos.Set(-315f + this.Limit * 0.35f, transform.position.y, transform.position.z);
				transform.position = this.tmpPos;
			}
			if (this.IsBackEndDragY > 0)
			{
				if (transform.position.z >= 295f + this.Limit * 0.5f)
				{
					this.tmpPos.Set(transform.position.x, transform.position.y, 295f + this.Limit * 0.5f);
					transform.position = this.tmpPos;
				}
				else if (transform.position.z <= 95f + this.Limit)
				{
					this.tmpPos.Set(transform.position.x, transform.position.y, 95f + this.Limit);
					transform.position = this.tmpPos;
				}
			}
			else if (transform.position.z >= 280f + this.Limit * 0.5f)
			{
				this.tmpPos.Set(transform.position.x, transform.position.y, 280f + this.Limit * 0.5f);
				transform.position = this.tmpPos;
			}
			else if (transform.position.z <= 110f + this.Limit)
			{
				this.tmpPos.Set(transform.position.x, transform.position.y, 110f + this.Limit);
				transform.position = this.tmpPos;
			}
			if (this.tmpCameraPos != transform.position)
			{
				this.tmpCameraPos = transform.position;
			}
		}
	}

	// Token: 0x0600215E RID: 8542 RVA: 0x003F8368 File Offset: 0x003F6568
	public void OnBeginDrag(PointerEventData eventData)
	{
		if (this.NextState != this.mState)
		{
			return;
		}
		if (this.pressPosition != Vector2.zero && this.pressPosition2 != Vector2.zero && eventData.pointerId > 1)
		{
			return;
		}
		if (this.pressPosition == Vector2.zero)
		{
			this.pressPosition = eventData.pressPosition;
			this.mPosition = eventData.position;
		}
		else if (this.pressPosition != Vector2.zero && this.pressPosition2 == Vector2.zero)
		{
			this.pressPosition2 = eventData.pressPosition;
			this.mPosition2 = eventData.position;
		}
		this.speed = 0f;
		this.speed2 = 0f;
		this.IsEndDrag = false;
		if (this.mState == CameraState.World && this.mState == this.NextState && this.pressPosition2 == Vector2.zero)
		{
			this.m_ContentStartPosition = Camera.main.transform.position;
			this.m_PointerStartLocalCursor = Camera.main.ScreenToViewportPoint(eventData.position);
		}
	}

	// Token: 0x0600215F RID: 8543 RVA: 0x003F84B8 File Offset: 0x003F66B8
	public void OnDrag(PointerEventData eventData)
	{
		if (this.pressPosition != Vector2.zero && this.pressPosition2 != Vector2.zero && eventData.pointerId > 1)
		{
			return;
		}
		if (this.pressPosition == Vector2.zero)
		{
			return;
		}
		Transform transform = Camera.main.transform;
		if (this.mState == CameraState.World && this.mState == this.NextState)
		{
			if (this.pressPosition2 == Vector2.zero)
			{
				Vector2 a = Camera.main.ScreenToViewportPoint(eventData.position);
				Vector2 vector = a - this.m_PointerStartLocalCursor;
				if (!this.bMove)
				{
					this.Dis = Vector2.Distance(eventData.position, eventData.pressPosition);
					if (Mathf.Abs(this.Dis) >= 1f)
					{
						this.bMove = true;
					}
					if (!this.bMove && Mathf.Abs(vector.x * 100f) < 1f && Mathf.Abs(vector.y * 100f) < 1f)
					{
						return;
					}
				}
				this.tmpPos.Set(vector.x * (164f - 64f * (-this.Limit / 100f)), 0f, vector.y * (164f - 64f * (-this.Limit / 100f)));
				transform.position = this.m_ContentStartPosition + this.tmpPos;
				if (eventData.position.x > eventData.pressPosition.x && 250f - this.Limit * 0.4f - this.m_ContentStartPosition.x <= 10f)
				{
					this.IsBackEndDragX = 1;
				}
				else if (eventData.pressPosition.x > eventData.position.x && this.m_ContentStartPosition.x - (-315f + this.Limit * 0.35f) <= 10f)
				{
					this.IsBackEndDragX = 2;
				}
				if (eventData.position.y > eventData.pressPosition.y && 280f + this.Limit * 0.5f - this.m_ContentStartPosition.z <= 10f)
				{
					this.IsBackEndDragY = 1;
				}
				else if (eventData.pressPosition.y > eventData.position.y && this.m_ContentStartPosition.z - (110f + this.Limit) <= 10f)
				{
					this.IsBackEndDragY = 2;
				}
				this.mTime = Time.smoothDeltaTime;
				this.mPosition = eventData.position;
			}
			else if (eventData.pressPosition == this.pressPosition || eventData.pressPosition == this.pressPosition2)
			{
				this.Dis = Vector2.Distance(this.mPosition, this.mPosition2);
				if (eventData.pressPosition == this.pressPosition)
				{
					this.Dis2 = Vector2.Distance(eventData.position, this.mPosition2);
					this.mPosition = eventData.position;
				}
				else
				{
					this.Dis2 = Vector2.Distance(eventData.position, this.mPosition);
					this.mPosition2 = eventData.position;
				}
				float num = (this.Dis - this.Dis2) * 0.2f;
				if (this.Limit + num >= 0f)
				{
					num = 0f - this.Limit;
					this.Limit = 0f;
				}
				else if (this.Limit + num <= -100f)
				{
					num = -100f - this.Limit;
					this.Limit = -100f;
				}
				else
				{
					this.Limit += num;
				}
				transform.position += transform.rotation * Vector3.back * num;
			}
		}
	}

	// Token: 0x06002160 RID: 8544 RVA: 0x003F8914 File Offset: 0x003F6B14
	public void OnEndDrag(PointerEventData eventData)
	{
		if (this.pressPosition != Vector2.zero && this.pressPosition2 != Vector2.zero && eventData.pointerId > 1)
		{
			return;
		}
		if (this.mState == CameraState.World && this.mState == this.NextState)
		{
			if (eventData.pressPosition == this.pressPosition && this.pressPosition2 != Vector2.zero)
			{
				this.pressPosition = this.pressPosition2;
				this.pressPosition2 = Vector2.zero;
				this.mPosition = this.mPosition2;
				this.mPosition2 = Vector2.zero;
				this.m_ContentStartPosition = Camera.main.transform.position;
				this.m_PointerStartLocalCursor = Camera.main.ScreenToViewportPoint(this.mPosition);
				this.mTime = 0f;
				this.speed = 0f;
				this.speed2 = 0f;
			}
			else if (eventData.pressPosition == this.pressPosition2)
			{
				this.pressPosition2 = Vector2.zero;
				this.mPosition2 = Vector2.zero;
				this.mTime = 0f;
				this.speed = 0f;
				this.speed2 = 0f;
				this.m_ContentStartPosition = Camera.main.transform.position;
				this.m_PointerStartLocalCursor = Camera.main.ScreenToViewportPoint(this.mPosition);
			}
			else
			{
				this.pressPosition = Vector2.zero;
				this.mPosition = Vector2.zero;
			}
			this.IsEndDrag = true;
			this.bMove = false;
			this.IsBackEndDragX = 0;
			this.IsBackEndDragY = 0;
			this.tmpTime1 = 0f;
			this.tmpTime2 = 0f;
			Transform transform = Camera.main.transform;
			if (this.mState == CameraState.World)
			{
				this.mTime = Time.smoothDeltaTime;
				if (transform.position.x >= 250f - this.Limit * 0.4f)
				{
					this.IsBackEndDragX = 1;
					this.newVelocity = (250f - this.Limit * 0.4f - transform.position.x) / this.mTime;
					this.speed = Mathf.Lerp(0f, this.newVelocity, this.mTime * 3.5f);
				}
				else if (transform.position.x <= -315f + this.Limit * 0.35f)
				{
					this.IsBackEndDragX = 2;
					this.newVelocity = (-315f + this.Limit * 0.35f - transform.position.x) / this.mTime;
					this.speed = Mathf.Lerp(0f, this.newVelocity, this.mTime * 3.5f);
				}
				if (transform.position.z >= 280f + this.Limit * 0.5f)
				{
					this.IsBackEndDragY = 1;
					this.newVelocity = (280f + this.Limit * 0.5f - transform.position.z) / this.mTime;
					this.speed2 = Mathf.Lerp(0f, this.newVelocity, this.mTime * 3.5f);
				}
				else if (transform.position.z <= 110f + this.Limit)
				{
					this.IsBackEndDragY = 2;
					this.newVelocity = (110f + this.Limit - transform.position.z) / this.mTime;
					this.speed2 = Mathf.Lerp(0f, this.newVelocity, this.mTime * 3.5f);
				}
			}
		}
		else
		{
			this.pressPosition = Vector2.zero;
			this.pressPosition2 = Vector2.zero;
		}
	}

	// Token: 0x06002161 RID: 8545 RVA: 0x003F8D28 File Offset: 0x003F6F28
	public void ReSetPressPosition()
	{
		this.pressPosition = Vector2.zero;
		this.pressPosition2 = Vector2.zero;
	}

	// Token: 0x040069A1 RID: 27041
	public Vector3 tmpPos;

	// Token: 0x040069A2 RID: 27042
	public Vector3 tmpCameraPos;

	// Token: 0x040069A3 RID: 27043
	public Vector2 m_PointerStartLocalCursor;

	// Token: 0x040069A4 RID: 27044
	public Vector3 m_ContentStartPosition;

	// Token: 0x040069A5 RID: 27045
	public Vector3 NextPos;

	// Token: 0x040069A6 RID: 27046
	public Vector3 TargetPos;

	// Token: 0x040069A7 RID: 27047
	public Vector3 mPos;

	// Token: 0x040069A8 RID: 27048
	public Vector3 AnglePos;

	// Token: 0x040069A9 RID: 27049
	public float mTime;

	// Token: 0x040069AA RID: 27050
	public float speed;

	// Token: 0x040069AB RID: 27051
	public float speed2;

	// Token: 0x040069AC RID: 27052
	public float Distance;

	// Token: 0x040069AD RID: 27053
	public float mBegin;

	// Token: 0x040069AE RID: 27054
	public float tmp;

	// Token: 0x040069AF RID: 27055
	public bool IsEndDrag;

	// Token: 0x040069B0 RID: 27056
	public bool IsGoNow;

	// Token: 0x040069B1 RID: 27057
	public bool IsOpenGoNow;

	// Token: 0x040069B2 RID: 27058
	public CameraState mState;

	// Token: 0x040069B3 RID: 27059
	public CameraState NextState;

	// Token: 0x040069B4 RID: 27060
	private Quaternion NextQuaternion;

	// Token: 0x040069B5 RID: 27061
	private Quaternion tmpQuaternion;

	// Token: 0x040069B6 RID: 27062
	public byte mLevel;

	// Token: 0x040069B7 RID: 27063
	public Vector2 pressPosition;

	// Token: 0x040069B8 RID: 27064
	public Vector2 pressPosition2;

	// Token: 0x040069B9 RID: 27065
	public Vector2 mPosition;

	// Token: 0x040069BA RID: 27066
	public Vector2 mPosition2;

	// Token: 0x040069BB RID: 27067
	public Vector3 TmpV3Pos;

	// Token: 0x040069BC RID: 27068
	public Vector3 TmpV3Rot;

	// Token: 0x040069BD RID: 27069
	private Chapter chapter;

	// Token: 0x040069BE RID: 27070
	private float Dis;

	// Token: 0x040069BF RID: 27071
	private float Dis2;

	// Token: 0x040069C0 RID: 27072
	private bool bMove;

	// Token: 0x040069C1 RID: 27073
	public float Limit;

	// Token: 0x040069C2 RID: 27074
	public byte IsBackEndDragX;

	// Token: 0x040069C3 RID: 27075
	public byte IsBackEndDragY;

	// Token: 0x040069C4 RID: 27076
	public float newVelocity;

	// Token: 0x040069C5 RID: 27077
	private float tmpTime1;

	// Token: 0x040069C6 RID: 27078
	private float tmpTime2;
}
