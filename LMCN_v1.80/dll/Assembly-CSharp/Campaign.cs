using System;
using UnityEngine;

// Token: 0x02000352 RID: 850
public class Campaign : SpriteBase
{
	// Token: 0x06001176 RID: 4470 RVA: 0x001EA258 File Offset: 0x001E8458
	public Campaign()
	{
		this.RootObj = new GameObject("Campain");
		this.GradespriteRender = new SpriteRenderer[3];
		this.StageStr = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x06001177 RID: 4471 RVA: 0x001EA2CC File Offset: 0x001E84CC
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
		Sprite sprite = instance.LoadFrameSprite("Crowne01");
		gameObject = mapspriteManager.GetSpriteObj();
		this.FramespriteRender = gameObject.GetComponent<SpriteRenderer>();
		this.FramespriteRender.material = instance.GetFrameMaterial();
		this.FramespriteRender.renderer.sortingOrder = -40;
		this.FramespriteRender.transform.SetParent(this.RootObj.transform);
		this.FramespriteRender.transform.localScale *= this.SpriteScale;
		this.FramespriteRender.color = Color.white;
		for (int i = 0; i < 3; i++)
		{
			gameObject = mapspriteManager.GetSpriteObj();
			this.GradespriteRender[i] = gameObject.GetComponent<SpriteRenderer>();
			this.GradespriteRender[i].sprite = sprite;
			this.GradespriteRender[i].renderer.sortingOrder = -40;
			this.GradespriteRender[i].material = instance.GetFrameMaterial();
			this.GradespriteRender[i].transform.SetParent(this.RootObj.transform);
			this.GradespriteRender[i].transform.localScale *= this.GradeScale;
			this.GradespriteRender[i].transform.localPosition = this.GradePos;
			this.GradespriteRender[i].enabled = false;
			this.GradespriteRender[i].color = Color.white;
		}
		Vector3 localScale = new Vector3(6f, 6f, 6f);
		this.GradePos.Set(0.52f, -2.41f, 0f);
		gameObject = mapspriteManager.GetTextObj();
		gameObject.transform.localScale = localScale;
		gameObject.transform.SetParent(this.RootObj.transform);
		gameObject.transform.localPosition = this.GradePos;
		this.StageRender = gameObject.GetComponent<SpriteRenderer>();
		this.StageRender.sprite = instance.LoadFrameSprite("UI_black_top");
		this.StageRender.material = instance.GetFrameMaterial();
		this.StageRender.renderer.sortingOrder = -40;
		this.GradePos.Set(-0.066f, 0.203f, 0f);
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
		if (DataManager.StageDataController._stageMode == StageMode.Full)
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
		this.Score = (byte)DataManager.StageDataController.GetStagePoint(this.PointID, 0);
		return this.RootObj;
	}

	// Token: 0x06001178 RID: 4472 RVA: 0x001EA7A8 File Offset: 0x001E89A8
	public void UpdatData()
	{
		if (this.Score == 3)
		{
			float num = -2.74f;
			float num2 = 2.74f;
			for (byte b = 0; b < this.Score; b += 1)
			{
				this.GradespriteRender[(int)b].enabled = true;
				this.GradespriteRender[(int)b].transform.Translate(num + num2 * (float)b, 0f, 0f);
			}
		}
		else if (this.Score == 2)
		{
			float num = -1.4f;
			float num2 = 2.76f;
			for (byte b2 = 0; b2 < this.Score; b2 += 1)
			{
				this.GradespriteRender[(int)b2].enabled = true;
				this.GradespriteRender[(int)b2].transform.Translate(num + num2 * (float)b2, 0f, 0f);
			}
		}
		else
		{
			this.GradespriteRender[0].enabled = true;
		}
		this.mapspriteManager.SetOutlinePosition(this.StageText.transform, this.StageText.text);
	}

	// Token: 0x06001179 RID: 4473 RVA: 0x001EA8B4 File Offset: 0x001E8AB4
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

	// Token: 0x0600117A RID: 4474 RVA: 0x001EA954 File Offset: 0x001E8B54
	public override void SetSprite(ushort ID, byte Class)
	{
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(ID);
		this.spriteRender.sprite = this.mapspriteManager.GetSpriteByID(recordByKey.Graph);
		this.FramespriteRender.sprite = GUIManager.Instance.LoadFrameSprite(EFrameSprite.Hero, Class);
		this.UpdatData();
	}

	// Token: 0x0600117B RID: 4475 RVA: 0x001EA9AC File Offset: 0x001E8BAC
	public override void Update(byte meg)
	{
		if (meg == 0)
		{
			byte b = 0;
			while ((int)b < this.GradespriteRender.Length)
			{
				this.GradespriteRender[(int)b].gameObject.SetActive(false);
				b += 1;
			}
		}
		else if (meg == 1)
		{
			this.GradespriteRender[0].gameObject.SetActive(true);
		}
		else
		{
			this.Score = (byte)DataManager.StageDataController.GetStagePoint(this.PointID, 0);
			this.UpdatData();
		}
	}

	// Token: 0x0600117C RID: 4476 RVA: 0x001EAA30 File Offset: 0x001E8C30
	public override void Hide()
	{
		this.RootObj.SetActive(false);
	}

	// Token: 0x040037B5 RID: 14261
	private GameObject RootObj;

	// Token: 0x040037B6 RID: 14262
	private ushort PointID;

	// Token: 0x040037B7 RID: 14263
	private byte Score;

	// Token: 0x040037B8 RID: 14264
	private float SpriteScale = 6f;

	// Token: 0x040037B9 RID: 14265
	private float GradeScale = 4.2f;

	// Token: 0x040037BA RID: 14266
	private SpriteRenderer spriteRender;

	// Token: 0x040037BB RID: 14267
	private SpriteRenderer FramespriteRender;

	// Token: 0x040037BC RID: 14268
	private SpriteRenderer[] GradespriteRender;

	// Token: 0x040037BD RID: 14269
	private SpriteRenderer StageRender;

	// Token: 0x040037BE RID: 14270
	private TextMesh StageText;

	// Token: 0x040037BF RID: 14271
	private CString StageStr;

	// Token: 0x040037C0 RID: 14272
	private Vector3 GradePos = new Vector3(0f, 5.19f, 0f);
}
