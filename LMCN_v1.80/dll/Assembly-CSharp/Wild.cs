using System;
using UnityEngine;

// Token: 0x020006DA RID: 1754
public class Wild : Gameplay
{
	// Token: 0x06002162 RID: 8546 RVA: 0x003F8D40 File Offset: 0x003F6F40
	public Wild(GameObject _CorpsStage)
	{
		this.WildCorpsStage = _CorpsStage;
	}

	// Token: 0x06002163 RID: 8547 RVA: 0x003F8D50 File Offset: 0x003F6F50
	~Wild()
	{
	}

	// Token: 0x06002164 RID: 8548 RVA: 0x003F8D88 File Offset: 0x003F6F88
	private void PlayBoss()
	{
		if (this.WildCorpsStage == null)
		{
			return;
		}
		this.WildCorpsStage.SetActive(true);
		Animation component = this.WildCorpsStage.transform.GetChild(1).GetComponent<Animation>();
		if (component != null)
		{
			component.wrapMode = WrapMode.Loop;
			component.CrossFade("idle", 0.3f);
		}
	}

	// Token: 0x06002165 RID: 8549 RVA: 0x003F8DF0 File Offset: 0x003F6FF0
	protected override void UpdateNext(byte[] meg)
	{
		this.WildCorpsStage = null;
		if (this._BuildSprite != null)
		{
			this._BuildSprite.Destroy();
		}
		this._BuildSprite = null;
		if (this.currentCorpsStageEff != null)
		{
			ParticleManager.Instance.DeSpawn(this.currentCorpsStageEff);
		}
		this.currentCorpsStageEff = null;
		if (this.cloudEff != null)
		{
			ParticleManager.Instance.DeSpawn(this.cloudEff);
		}
		this.cloudEff = null;
		this.currentCorpsStageModel = null;
		this.Select = null;
		if (this.currentCorpsStageObject != null)
		{
			UnityEngine.Object.Destroy(this.currentCorpsStageObject);
		}
		this.currentCorpsStageObject = null;
		AssetManager.UnloadAssetBundle(this.currentCorpsStageKey, true);
		if (this.ConfirmSelect != null)
		{
			Array.Clear(this.ConfirmSelect, 0, this.ConfirmSelect.Length);
		}
		this.ConfirmSelect = null;
		if (this.CanBeSelect != null)
		{
			Array.Clear(this.CanBeSelect, 0, this.CanBeSelect.Length);
		}
		this.CanBeSelect = null;
		this.ClearUpdateDelegates();
	}

	// Token: 0x06002166 RID: 8550 RVA: 0x003F8F04 File Offset: 0x003F7104
	protected override void UpdateLoad(byte[] meg)
	{
		this._BuildSprite = new MapSprite(WorldMode.Wild, 1);
		this.CanBeSelect = new GameObject[2 + this._BuildSprite.SpriteGameObject.Length + DataManager.StageDataController.CorpsStageTable.TableCount];
		this.ConfirmSelect = new GameObject[1];
		Array.Copy(this._BuildSprite.SpriteGameObject, 0, this.CanBeSelect, 2, this._BuildSprite.SpriteGameObject.Length);
		Array.Copy(this._BuildSprite.StageLock, 0, this.CanBeSelect, 2 + this._BuildSprite.SpriteGameObject.Length, this._BuildSprite.StageLock.Length);
		if (DataManager.StageDataController.StageRecord[2] < DataManager.StageDataController.limitRecord[2])
		{
			ushort inKey = DataManager.StageDataController.StageRecord[2] + 1;
			if (DataManager.StageDataController.isNotFirstInChapter[2] == 1)
			{
				this.PlayBoss();
				this.CanBeSelect[0] = this.WildCorpsStage.transform.GetChild(0).gameObject;
				this.CanBeSelect[1] = this.WildCorpsStage.transform.GetChild(1).gameObject;
			}
			else
			{
				this.currentCorpsStageObject = new GameObject("CorpsStageFlag");
				Transform transform = this.currentCorpsStageObject.transform;
				AssetBundle assetBundle = AssetManager.GetAssetBundle("Role/3dbutton02", out this.currentCorpsStageKey, false);
				this.CanBeSelect[0] = (this.currentCorpsStageModel = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject));
				this.CanBeSelect[1] = null;
				Animation component = this.currentCorpsStageModel.GetComponent<Animation>();
				component.wrapMode = WrapMode.Loop;
				component.Play("idle");
				Transform transform2 = this.currentCorpsStageModel.transform;
				transform2.localScale = Vector3.one * 20f;
				transform2.SetParent(transform);
				this.cloudEff = ParticleManager.Instance.Spawn(307, transform, new Vector3(0f, 8.67f, -7.03f), 1f, true, true, true);
				this.currentCorpsStageEff = ParticleManager.Instance.Spawn(308, transform, new Vector3(0.59f, 5.69f, -3.8f), 1f, true, true, true);
				CorpsStage recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(inKey);
				transform.position = GameConstants.WordToVector3(recordByKey.StagePos.X, recordByKey.StagePos.Y, recordByKey.StagePos.Z, -100, 0.01f);
				Chapter recordByKey2 = DataManager.StageDataController.ChapterTable.GetRecordByKey(inKey);
				transform.LookAt(GameConstants.WordToVector3(recordByKey2.CameraPos.X, recordByKey2.CameraPos.Y, recordByKey2.CameraPos.Z, -100, 0.01f));
				Vector3 eulerAngles = transform.eulerAngles;
				eulerAngles.y = (eulerAngles.z = 0f);
				transform.eulerAngles = eulerAngles;
			}
		}
		else
		{
			this.CanBeSelect[0] = (this.CanBeSelect[1] = null);
		}
	}

	// Token: 0x06002167 RID: 8551 RVA: 0x003F9210 File Offset: 0x003F7410
	protected override void UpdateReady(byte[] meg)
	{
		DataManager.msgBuffer[0] = 9;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		DataManager.Instance.lastBattleResult = -1;
		GUIManager instance = GUIManager.Instance;
		if (instance.BuildGuildQueue > 0)
		{
			instance.BuildingData.ManorGuild(GUIManager.Instance.BuildGuildQueue, false);
			instance.BuildGuildQueue = 0;
		}
	}

	// Token: 0x06002168 RID: 8552 RVA: 0x003F926C File Offset: 0x003F746C
	protected override void UpdateRun(byte[] meg)
	{
		this._BuildSprite.UpdateGuildPos();
	}

	// Token: 0x06002169 RID: 8553 RVA: 0x003F927C File Offset: 0x003F747C
	protected override void UpdateNews(byte[] meg)
	{
		Vector2 touch = new Vector2(GameConstants.ConvertBytesToFloat(meg, 1), GameConstants.ConvertBytesToFloat(meg, 5));
		switch (meg[0])
		{
		case 0:
			this.Select = GameConstants.GameObjectPick(touch, this.CanBeSelect, typeof(Renderer), true);
			break;
		case 1:
			if (this.Select != null)
			{
				this.ConfirmSelect[0] = this.Select;
				this.Select = GameConstants.GameObjectPick(touch, this.ConfirmSelect, typeof(Renderer), true);
				if (this.Select == this.ConfirmSelect[0])
				{
					if (this.Select == this.CanBeSelect[0] || this.Select == this.CanBeSelect[1])
					{
						if (DataManager.StageDataController.isNotFirstInChapter[2] == 0)
						{
							this.PlayBoss();
						}
						DataManager.StageDataController.resetStageMode(StageMode.Corps);
						DataManager.msgBuffer[0] = 7;
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					}
					else
					{
						this._BuildSprite.NotifyOpenUI(this.Select.name.GetHashCode());
					}
				}
				this.Select = null;
			}
			break;
		case 5:
			if (this._BuildSprite != null)
			{
				this._BuildSprite.UpdateMapSprite(GameConstants.ConvertBytesToUShort(meg, 12), meg[11]);
			}
			break;
		case 7:
			this.Select = null;
			break;
		case 9:
			if (this._BuildSprite != null)
			{
				this._BuildSprite.UpdateMapSprite(GameConstants.ConvertBytesToUShort(meg, 12), 5);
			}
			break;
		case 11:
			if (this._BuildSprite != null)
			{
				this._BuildSprite.ShowManorGuild(GameConstants.ConvertBytesToUShort(meg, 3));
			}
			break;
		case 12:
			if (DataManager.StageDataController.isNotFirstInChapter[2] == 0)
			{
				this.PlayBoss();
			}
			break;
		}
	}

	// Token: 0x040069C7 RID: 27079
	private const ushort currentCorpsStageEffID = 308;

	// Token: 0x040069C8 RID: 27080
	private const ushort cloudEffEffID = 307;

	// Token: 0x040069C9 RID: 27081
	private GameObject WildCorpsStage;

	// Token: 0x040069CA RID: 27082
	private MapSprite _BuildSprite;

	// Token: 0x040069CB RID: 27083
	private GameObject Select;

	// Token: 0x040069CC RID: 27084
	private GameObject[] ConfirmSelect;

	// Token: 0x040069CD RID: 27085
	private GameObject[] CanBeSelect;

	// Token: 0x040069CE RID: 27086
	private GameObject currentCorpsStageObject;

	// Token: 0x040069CF RID: 27087
	private GameObject currentCorpsStageModel;

	// Token: 0x040069D0 RID: 27088
	private GameObject currentCorpsStageEff;

	// Token: 0x040069D1 RID: 27089
	private GameObject cloudEff;

	// Token: 0x040069D2 RID: 27090
	private int currentCorpsStageKey;
}
