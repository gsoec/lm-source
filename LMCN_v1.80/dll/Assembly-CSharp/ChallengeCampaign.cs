using System;
using UnityEngine;

// Token: 0x02000353 RID: 851
public class ChallengeCampaign : SpriteBase
{
	// Token: 0x0600117D RID: 4477 RVA: 0x001EAA40 File Offset: 0x001E8C40
	public ChallengeCampaign()
	{
		this.RootObj = new GameObject("Campain");
		this.GradespriteRender = new SpriteRenderer[3];
		this.StageStr = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x0600117E RID: 4478 RVA: 0x001EAAA8 File Offset: 0x001E8CA8
	public override GameObject InitialSprite(MapSpriteManager mapspriteManager)
	{
		this.mapspriteManager = mapspriteManager;
		GUIManager instance = GUIManager.Instance;
		this.RootObj.transform.position = Vector3.zero;
		GameObject gameObject = mapspriteManager.GetSpriteObj();
		this.spriteRender = gameObject.GetComponent<SpriteRenderer>();
		this.spriteRender.transform.SetParent(this.RootObj.transform);
		this.spriteRender.transform.localScale *= this.SpriteScale;
		this.spriteRender.renderer.sortingOrder = -50;
		this.spriteRender.color = Color.white;
		if (instance.IsArabic)
		{
			Quaternion rotation = this.spriteRender.transform.rotation;
			rotation.eulerAngles = new Vector3(0f, 180f, 0f);
			this.spriteRender.transform.rotation = rotation;
		}
		gameObject = mapspriteManager.GetSpriteObj();
		this.FramespriteRender = gameObject.GetComponent<SpriteRenderer>();
		this.FramespriteRender.material = mapspriteManager.ChallegeMaterial;
		this.FramespriteRender.renderer.sortingOrder = -10;
		this.FramespriteRender.transform.SetParent(this.RootObj.transform);
		this.FramespriteRender.transform.localScale *= this.SpriteScale;
		this.FramespriteRender.color = Color.white;
		for (int i = 0; i < 3; i++)
		{
			gameObject = mapspriteManager.GetSpriteObj();
			this.GradespriteRender[i] = gameObject.GetComponent<SpriteRenderer>();
			this.GradespriteRender[i].transform.SetParent(this.RootObj.transform);
			this.GradespriteRender[i].enabled = false;
		}
		Vector3 localScale = new Vector3(6f, 6f, 6f);
		this.GradePos.Set(0.52f, -2.33f, 0f);
		gameObject = mapspriteManager.GetTextObj();
		gameObject.transform.localScale = localScale;
		gameObject.transform.SetParent(this.RootObj.transform);
		gameObject.transform.localPosition = this.GradePos;
		this.StageRender = gameObject.GetComponent<SpriteRenderer>();
		this.StageRender.sprite = instance.LoadFrameSprite("UI_black_top");
		this.StageRender.material = instance.GetFrameMaterial();
		this.StageRender.renderer.sortingOrder = -40;
		this.GradePos.Set(-0.066f, 0.26f, 0f);
		this.StageText = gameObject.transform.GetChild(0).GetComponent<TextMesh>();
		localScale.Set(1f / localScale.x, 1f / localScale.y, 1f / localScale.z);
		this.StageText.transform.localScale = localScale;
		this.StageText.transform.localPosition = this.GradePos;
		this.StageStr.ClearString();
		this.StageStr.IntToFormat((long)DataManager.StageDataController.currentChapterID, 1, false);
		Vector3 localPosition = this.StageText.transform.localPosition;
		if (this.Index < 10)
		{
			localPosition.x = -0.066f;
		}
		else
		{
			localPosition.x = -0.227f;
		}
		this.StageText.transform.localPosition = localPosition;
		this.StageStr.IntToFormat((long)this.Index, 1, false);
		this.PointID = (ushort)((DataManager.StageDataController.currentChapterID - 1) * 6);
		if (DataManager.StageDataController._stageMode == StageMode.Full || DataManager.StageDataController._stageMode == StageMode.Dare)
		{
			this.PointID *= 3;
			this.PointID += this.Index;
		}
		else
		{
			this.PointID += this.Index / 3;
		}
		if (instance.IsArabic)
		{
			this.StageStr.AppendFormat("{1}-{0}");
		}
		else
		{
			this.StageStr.AppendFormat("{0}-{1}");
		}
		this.StageText.text = this.StageStr.ToString();
		this.Score = (sbyte)DataManager.StageDataController.GetStagePoint(this.PointID, 0);
		if ((int)this.Score < 0)
		{
			this.Score = 0;
			this.Hide();
		}
		else if ((int)this.Score > 0 && DataManager.StageDataController.DareNodusUpdatePointID == this.PointID)
		{
			this.Score -= 1;
		}
		this.Score = (sbyte)((int)this.Score & 7);
		return this.RootObj;
	}

	// Token: 0x0600117F RID: 4479 RVA: 0x001EAF5C File Offset: 0x001E915C
	public void UpdatData()
	{
		this.FramespriteRender.sprite = this.mapspriteManager.GetChalleteSprite((byte)this.Score);
		this.mapspriteManager.SetOutlinePosition(this.StageText.transform, this.StageText.text);
	}

	// Token: 0x06001180 RID: 4480 RVA: 0x001EAFA8 File Offset: 0x001E91A8
	public override void Destroy()
	{
		StringManager.Instance.DeSpawnString(this.StageStr);
		if (this.spriteRender)
		{
			UnityEngine.Object.Destroy(this.StageText.gameObject);
			UnityEngine.Object.Destroy(this.RootObj);
			this.mapspriteManager.ReleaseSpriteObj(this.spriteRender.gameObject);
			this.mapspriteManager.ReleaseSpriteObj(this.FramespriteRender.gameObject);
			for (byte b = 0; b < 3; b += 1)
			{
				this.mapspriteManager.ReleaseSpriteObj(this.GradespriteRender[(int)b].gameObject);
			}
		}
	}

	// Token: 0x06001181 RID: 4481 RVA: 0x001EB048 File Offset: 0x001E9248
	public override void UpdateSpriteFrame()
	{
		this.Score = (sbyte)DataManager.StageDataController.GetStagePoint(this.PointID, 0);
		if ((int)this.Score < 0)
		{
			this.Score = 0;
			this.Hide();
		}
		this.Score = (sbyte)((int)this.Score & 7);
		this.UpdatData();
	}

	// Token: 0x06001182 RID: 4482 RVA: 0x001EB0A0 File Offset: 0x001E92A0
	public override void SetSprite(ushort ID, byte Class)
	{
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(ID);
		this.spriteRender.sprite = this.mapspriteManager.GetSpriteByID(recordByKey.Graph);
		this.UpdatData();
	}

	// Token: 0x06001183 RID: 4483 RVA: 0x001EB0E4 File Offset: 0x001E92E4
	public override void Update(byte meg)
	{
		if (meg != 0 && meg != 1)
		{
			this.Score = (sbyte)DataManager.StageDataController.GetStagePoint(this.PointID, 0);
			if ((int)this.Score < 0)
			{
				this.Score = 0;
			}
			else if ((int)this.Score > 0 && DataManager.StageDataController.DareNodusUpdatePointID == this.PointID)
			{
				this.Score -= 1;
			}
			this.Score = (sbyte)((int)this.Score & 7);
			this.UpdatData();
		}
	}

	// Token: 0x06001184 RID: 4484 RVA: 0x001EB178 File Offset: 0x001E9378
	public override void Hide()
	{
		this.RootObj.SetActive(false);
	}

	// Token: 0x040037C1 RID: 14273
	private GameObject RootObj;

	// Token: 0x040037C2 RID: 14274
	private ushort PointID;

	// Token: 0x040037C3 RID: 14275
	private sbyte Score;

	// Token: 0x040037C4 RID: 14276
	private float SpriteScale = 6f;

	// Token: 0x040037C5 RID: 14277
	private SpriteRenderer spriteRender;

	// Token: 0x040037C6 RID: 14278
	private SpriteRenderer FramespriteRender;

	// Token: 0x040037C7 RID: 14279
	private SpriteRenderer[] GradespriteRender;

	// Token: 0x040037C8 RID: 14280
	private SpriteRenderer StageRender;

	// Token: 0x040037C9 RID: 14281
	private TextMesh StageText;

	// Token: 0x040037CA RID: 14282
	private CString StageStr;

	// Token: 0x040037CB RID: 14283
	private Vector3 GradePos = new Vector3(0f, 5.19f, 0f);
}
