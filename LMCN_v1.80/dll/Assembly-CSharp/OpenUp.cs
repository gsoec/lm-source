using System;
using UnityEngine;

// Token: 0x020006DB RID: 1755
public class OpenUp : Gameplay
{
	// Token: 0x0600216A RID: 8554 RVA: 0x003F9480 File Offset: 0x003F7680
	public OpenUp(GameObject _CorpsStage)
	{
		this._openState = OpenUp.OpenState.Count;
		this.OpenUpCorpsStage = _CorpsStage;
		this.stateUpdateDelegates = null;
	}

	// Token: 0x0600216B RID: 8555 RVA: 0x003F9560 File Offset: 0x003F7760
	~OpenUp()
	{
	}

	// Token: 0x170000BE RID: 190
	// (get) Token: 0x0600216C RID: 8556 RVA: 0x003F9598 File Offset: 0x003F7798
	private byte LineID
	{
		get
		{
			byte stageMode = (byte)DataManager.StageDataController._stageMode;
			ushort num = DataManager.StageDataController.StageRecord[(int)stageMode];
			if (num >= DataManager.StageDataController.limitRecord[(int)stageMode] && num > 0)
			{
				num -= 1;
			}
			num /= GameConstants.LinePointNum[(int)stageMode];
			num %= 6;
			return (byte)num;
		}
	}

	// Token: 0x170000BF RID: 191
	// (get) Token: 0x0600216D RID: 8557 RVA: 0x003F95F0 File Offset: 0x003F77F0
	private byte PointID
	{
		get
		{
			byte stageMode = (byte)DataManager.StageDataController._stageMode;
			ushort num = DataManager.StageDataController.StageRecord[(int)stageMode];
			if (num >= DataManager.StageDataController.limitRecord[(int)stageMode] && num > 0)
			{
				num -= 1;
			}
			num %= GameConstants.LinePointNum[(int)stageMode];
			return (byte)num;
		}
	}

	// Token: 0x0600216E RID: 8558 RVA: 0x003F9640 File Offset: 0x003F7840
	private void getBossID(byte in_LineID)
	{
		ushort num = (ushort)DataManager.StageDataController.currentChapterID;
		num -= 1;
		num *= 6;
		num += 1;
		byte b = (byte)((DataManager.StageDataController._stageMode <= StageMode.Lean) ? DataManager.StageDataController._stageMode : StageMode.Full);
		b += 1;
		Array.Clear(DataManager.msgBuffer, 0, DataManager.msgBuffer.Length);
		Array.Clear(DataManager.DataBuffer, 0, DataManager.DataBuffer.Length);
		for (ushort num2 = 0; num2 <= (ushort)in_LineID; num2 += 1)
		{
			CExternalTableWithWordKey<Level> cexternalTableWithWordKey = DataManager.StageDataController.LevelTable[(int)b];
			ushort num3 = num;
			num = num3 + 1;
			ushort inKey = cexternalTableWithWordKey.GetRecordByKey(num3).Team[2];
			HeroTeam recordByKey = DataManager.Instance.TeamTable.GetRecordByKey(inKey);
			for (int i = 0; i < recordByKey.Arrays.Length; i++)
			{
				HeroTeamAttribute heroTeamAttribute = recordByKey.Arrays[i];
				if (heroTeamAttribute.Type == 3)
				{
					GameConstants.GetBytes(heroTeamAttribute.Hero, DataManager.msgBuffer, (int)num2 << 1);
					DataManager.DataBuffer[(int)num2] = recordByKey.HeroStar;
					break;
				}
			}
		}
	}

	// Token: 0x0600216F RID: 8559 RVA: 0x003F9760 File Offset: 0x003F7960
	private bool setOpenState()
	{
		DataManager.msgBuffer[0] = 46;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		DataManager.msgBuffer[0] = 42;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		this._openState = OpenUp.OpenState.Count;
		this.stateUpdateDelegates = null;
		ushort num = DataManager.StageDataController.currentPointID;
		byte stageMode = (byte)DataManager.StageDataController._stageMode;
		if (DataManager.StageDataController.currentChapterID < DataManager.StageDataController.ChapterID)
		{
			if (num - 1 == DataManager.StageDataController.StageRecord[(int)stageMode])
			{
				num /= GameConstants.StagePointNum[(int)stageMode];
				if (num == (ushort)DataManager.StageDataController.currentChapterID)
				{
					this._openState = OpenUp.OpenState.FinalWin;
					DataManager.msgBuffer[0] = 45;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
			}
			else if (DataManager.StageDataController.DareNodusUpdatePointID > 0 && DataManager.StageDataController._stageMode == StageMode.Dare && DataManager.StageDataController.DareNodusUpdatePointID == DataManager.StageDataController.currentPointID)
			{
				DataManager.msgBuffer[0] = 45;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
		}
		else if (DataManager.Instance.lastBattleResult > 0 && DataManager.StageDataController.lastStageRecord < DataManager.StageDataController.StageRecord[(int)stageMode] && DataManager.StageDataController.StageRecord[(int)stageMode] % GameConstants.StagePointNum[(int)stageMode] == 0 && num == DataManager.StageDataController.limitRecord[(int)stageMode])
		{
			this._openState = OpenUp.OpenState.FinalWin;
			DataManager.msgBuffer[0] = 45;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
		else if (num - 1 == DataManager.StageDataController.StageRecord[(int)stageMode])
		{
			num = (ushort)this.LineID;
			if (this.LineID == 0 && DataManager.StageDataController.isNotFirstInLine[(int)stageMode] == 0)
			{
				if (DataManager.StageDataController._stageMode == StageMode.Full && DataManager.StageDataController.isNotFirstInChapter[0] == 0)
				{
					if (!NewbieManager.IsTeachWorking(ETeachKind.DARE_FULL))
					{
						this._openState = OpenUp.OpenState.Wait;
						DataManager.msgBuffer[0] = 47;
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						DataManager.msgBuffer[0] = 15;
						DataManager.msgBuffer[1] = 0;
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						return true;
					}
					this._openState = OpenUp.OpenState.First;
					DataManager.msgBuffer[0] = 45;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
				else
				{
					if (DataManager.StageDataController.isNotFirstInChapter[(int)stageMode] == 0)
					{
						DataManager.StageDataController.isNotFirstInChapter[(int)stageMode] = 1;
					}
					this._openState = OpenUp.OpenState.First;
					DataManager.msgBuffer[0] = 45;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
			}
			else if (DataManager.Instance.lastBattleResult > 0)
			{
				this._openState = ((this.PointID != 0) ? OpenUp.OpenState.FullWin : OpenUp.OpenState.LeanWin);
				DataManager.msgBuffer[0] = 45;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
		}
		DataManager.StageDataController.lastStageRecord = DataManager.StageDataController.StageRecord[(int)stageMode];
		if (this._openState != OpenUp.OpenState.First && DataManager.StageDataController.StageRecord[0] == 0 && NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
		{
			NewbieManager.Get().IgnoreStep(false, 0);
		}
		return false;
	}

	// Token: 0x06002170 RID: 8560 RVA: 0x003F9A7C File Offset: 0x003F7C7C
	private bool MoveRun(Transform in_transform, Vector3 in_direction, float in_speed, float limit, OpenUp.OpenState in_next)
	{
		bool result = false;
		Vector3 position = in_transform.position + in_direction * Time.deltaTime * in_speed;
		if (in_speed < 0f)
		{
			if (position.y < limit)
			{
				position.y = limit;
				this._openState = in_next;
				result = true;
			}
		}
		else if (position.y > limit)
		{
			position.y = limit;
			this._openState = in_next;
			result = true;
		}
		in_transform.position = position;
		return result;
	}

	// Token: 0x06002171 RID: 8561 RVA: 0x003F9B04 File Offset: 0x003F7D04
	private void LoadLine(byte in_chapterId, CString in_str, AssetBundle in_AB)
	{
		Chapter recordByKey = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort)in_chapterId);
		in_str.ClearString();
		in_str.StringToFormat("Role/wmapline_m");
		in_str.IntToFormat((long)recordByKey.MapID, 2, false);
		in_str.AppendFormat("{0}{1}");
		AssetBundle assetBundle = AssetManager.GetAssetBundle(in_str, out this.LineassetKey);
		this.Line = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
	}

	// Token: 0x06002172 RID: 8562 RVA: 0x003F9B74 File Offset: 0x003F7D74
	private void FullWinLoad()
	{
		CString cstring = StringManager.Instance.SpawnString(30);
		byte b = DataManager.StageDataController.currentChapterID;
		AssetBundle assetBundle = null;
		this.LoadLine(b, cstring, assetBundle);
		ushort num = 1;
		if (DataManager.Instance.RoleAttr.Head != 0)
		{
			num = DataManager.Instance.RoleAttr.Head;
		}
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(num);
		ushort num2 = recordByKey.Modle;
		if (!DataManager.Instance.CheckHero3DMesh(num))
		{
			num2 = 1;
		}
		cstring.ClearString();
		cstring.StringToFormat("Role/hero_");
		cstring.IntToFormat((long)num2, 5, false);
		cstring.AppendFormat("{0}{1}");
		assetBundle = AssetManager.GetAssetBundle(cstring, out this.PawnassetKey);
		this.Pawn = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject);
		this.PawnTransform = this.Pawn.transform;
		this.PawnTransform.localScale = Vector3.one * (float)recordByKey.Scale * 0.01f;
		NewbieManager.pTrans = this.PawnTransform;
		ushort pointID = (ushort)this.PointID;
		assetBundle = AssetManager.GetAssetBundle("Role/wmap_sbt", out this.PointassetKey, false);
		GameObject original = assetBundle.mainAsset as GameObject;
		this.Point = new GameObject[(int)(GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode] - pointID)];
		this.PointTransform = new Transform[this.Point.Length];
		for (int i = 0; i < this.Point.Length; i++)
		{
			this.Point[i] = (UnityEngine.Object.Instantiate(original) as GameObject);
			this.PointTransform[i] = this.Point[i].transform;
		}
		b = this.LineID;
		this.CanBeSelect = new GameObject[(int)(b + 3)];
		this.CanBeSelect[0] = (this.CanBeSelect[this.CanBeSelect.Length - 1] = (this.CanBeSelect[this.CanBeSelect.Length - 2] = null));
		if (pointID + 1 != GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode])
		{
			this.CanBeSelect[0] = this.Pawn;
		}
		this.getBossID(b);
		if (DataManager.StageDataController._stageMode == StageMode.Dare)
		{
			for (int j = 0; j < (int)b; j++)
			{
				this.CanBeSelect[j + 1] = null;
			}
		}
		else if (b != 0)
		{
			this._BuildSprite = new MapSprite(WorldMode.OpenUp, (ushort)b);
			for (int k = 0; k < (int)b; k++)
			{
				this.CanBeSelect[k + 1] = this._BuildSprite.SpriteGameObject[k];
			}
			this._BuildSprite.SetSprite(DataManager.msgBuffer, DataManager.DataBuffer);
		}
		num = GameConstants.ConvertBytesToUShort(DataManager.msgBuffer, (int)b << 1);
		recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(num);
		num2 = recordByKey.Modle;
		if (!DataManager.Instance.CheckHero3DMesh(num))
		{
			num2 = 1;
		}
		cstring.ClearString();
		cstring.StringToFormat("Role/hero_");
		cstring.IntToFormat((long)num2, 5, false);
		cstring.AppendFormat("{0}{1}");
		assetBundle = AssetManager.GetAssetBundle(cstring, out this.BossassetKey);
		this.Boss = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject);
		this.BossTransform = this.Boss.transform;
		this.BossTransform.localScale = Vector3.one * (float)recordByKey.Scale * 0.01f;
		assetBundle = AssetManager.GetAssetBundle("Role/wmap_bbt", out this.BigPointassetKey, false);
		GameObject original2 = assetBundle.mainAsset as GameObject;
		this.BigPoint = new GameObject[(int)(b + 1)];
		this.BigPointTransform = new Transform[this.BigPoint.Length];
		for (int l = 0; l < this.BigPoint.Length; l++)
		{
			this.BigPoint[l] = (UnityEngine.Object.Instantiate(original2) as GameObject);
			this.BigPointTransform[l] = this.BigPoint[l].transform;
		}
		if (this.CanBeSelect[0] == null)
		{
			this.CanBeSelect[0] = this.Boss;
		}
		else
		{
			this.CanBeSelect[this.CanBeSelect.Length - 1] = this.Boss;
		}
		int num3 = (int)(DataManager.StageDataController.StageRecord[0] % GameConstants.StagePointNum[0]);
		if (DataManager.StageDataController._stageMode == StageMode.Full && num3 < 15)
		{
			cstring.ClearString();
			cstring.AppendFormat("Role/RewardBtn");
			assetBundle = AssetManager.GetAssetBundle(cstring, out this.TreasureassetKey);
			this.CanBeSelect[this.CanBeSelect.Length - 2] = (this.Treasure = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject));
			this.TreasureTransform = this.Treasure.transform;
		}
		StringManager.Instance.DeSpawnString(cstring);
	}

	// Token: 0x06002173 RID: 8563 RVA: 0x003FA05C File Offset: 0x003F825C
	private void LeanWinLoad()
	{
		CString cstring = StringManager.Instance.SpawnString(30);
		byte b = DataManager.StageDataController.currentChapterID;
		AssetBundle assetBundle = null;
		this.LoadLine(b, cstring, assetBundle);
		b = this.LineID;
		ushort num = (ushort)this.PointID;
		this.CanBeSelect = new GameObject[(int)(b + 3)];
		this.CanBeSelect[this.CanBeSelect.Length - 2] = null;
		ushort num2 = 1;
		if (DataManager.Instance.RoleAttr.Head != 0)
		{
			num2 = DataManager.Instance.RoleAttr.Head;
		}
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(num2);
		ushort num3 = recordByKey.Modle;
		if (!DataManager.Instance.CheckHero3DMesh(num2))
		{
			num3 = 1;
		}
		cstring.ClearString();
		cstring.StringToFormat("Role/hero_");
		cstring.IntToFormat((long)num3, 5, false);
		cstring.AppendFormat("{0}{1}");
		assetBundle = AssetManager.GetAssetBundle(cstring, out this.PawnassetKey);
		this.CanBeSelect[0] = (this.Pawn = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject));
		this.PawnTransform = this.Pawn.transform;
		this.PawnTransform.localScale = Vector3.one * (float)recordByKey.Scale * 0.01f;
		NewbieManager.pTrans = this.PawnTransform;
		if ((num += 1) != GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode])
		{
			assetBundle = AssetManager.GetAssetBundle("Role/wmap_sbt", out this.PointassetKey, false);
			GameObject original = assetBundle.mainAsset as GameObject;
			this.Point = new GameObject[(int)(GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode] - num)];
			this.PointTransform = new Transform[this.Point.Length];
			for (int i = 0; i < this.Point.Length; i++)
			{
				this.Point[i] = (UnityEngine.Object.Instantiate(original) as GameObject);
				this.PointTransform[i] = this.Point[i].transform;
			}
		}
		this.getBossID(b);
		if (DataManager.StageDataController._stageMode == StageMode.Dare)
		{
			for (int j = 0; j < (int)b; j++)
			{
				this.CanBeSelect[j + 1] = null;
			}
		}
		else if (b != 0)
		{
			this._BuildSprite = new MapSprite(WorldMode.OpenUp, (ushort)b);
			for (int k = 0; k < (int)b; k++)
			{
				this.CanBeSelect[k + 1] = this._BuildSprite.SpriteGameObject[k];
			}
			this._BuildSprite.SetSprite(DataManager.msgBuffer, DataManager.DataBuffer);
		}
		num2 = GameConstants.ConvertBytesToUShort(DataManager.msgBuffer, (int)b << 1);
		recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(num2);
		num3 = recordByKey.Modle;
		if (!DataManager.Instance.CheckHero3DMesh(num2))
		{
			num3 = 1;
		}
		cstring.ClearString();
		cstring.StringToFormat("Role/hero_");
		cstring.IntToFormat((long)num3, 5, false);
		cstring.AppendFormat("{0}{1}");
		assetBundle = AssetManager.GetAssetBundle(cstring, out this.BossassetKey);
		this.CanBeSelect[this.CanBeSelect.Length - 1] = (this.Boss = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject));
		this.BossTransform = this.Boss.transform;
		this.BossTransform.localScale = Vector3.one * (float)recordByKey.Scale * 0.01f;
		num2 = GameConstants.ConvertBytesToUShort(DataManager.msgBuffer, (int)(b - 1) << 1);
		recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(num2);
		num3 = recordByKey.Modle;
		if (!DataManager.Instance.CheckHero3DMesh(num2))
		{
			num3 = 1;
		}
		cstring.ClearString();
		cstring.StringToFormat("Role/hero_");
		cstring.IntToFormat((long)num3, 5, false);
		cstring.AppendFormat("{0}{1}");
		assetBundle = AssetManager.GetAssetBundle(cstring, out this.DeadBossassetKey);
		this.DeadBoss = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject);
		this.DeadBossTransform = this.DeadBoss.transform;
		this.DeadBossTransform.localScale = Vector3.one * (float)recordByKey.Scale * 0.01f;
		assetBundle = AssetManager.GetAssetBundle("Role/wmap_bbt", out this.BigPointassetKey, false);
		GameObject original2 = assetBundle.mainAsset as GameObject;
		this.BigPoint = new GameObject[(int)(b + 1)];
		this.BigPointTransform = new Transform[this.BigPoint.Length];
		for (int l = 0; l < this.BigPoint.Length; l++)
		{
			this.BigPoint[l] = (UnityEngine.Object.Instantiate(original2) as GameObject);
			this.BigPointTransform[l] = this.BigPoint[l].transform;
		}
		int num4 = (int)(DataManager.StageDataController.StageRecord[0] % GameConstants.StagePointNum[0]);
		if (DataManager.StageDataController._stageMode == StageMode.Full && num4 < 16)
		{
			cstring.ClearString();
			cstring.AppendFormat("Role/RewardBtn");
			assetBundle = AssetManager.GetAssetBundle(cstring, out this.TreasureassetKey);
			this.CanBeSelect[this.CanBeSelect.Length - 2] = (this.Treasure = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject));
			if (num4 == 15)
			{
				this.CanBeSelect[this.CanBeSelect.Length - 2] = null;
			}
			this.TreasureTransform = this.Treasure.transform;
		}
		StringManager.Instance.DeSpawnString(cstring);
	}

	// Token: 0x06002174 RID: 8564 RVA: 0x003FA5E4 File Offset: 0x003F87E4
	private void FinalWinLoad()
	{
		CString cstring = StringManager.Instance.SpawnString(30);
		byte b = DataManager.StageDataController.currentChapterID;
		AssetBundle assetBundle = null;
		this.LoadLine(b, cstring, assetBundle);
		b = 5;
		this.getBossID(b);
		this._BuildSprite = new MapSprite(WorldMode.OpenUp, 6);
		this.CanBeSelect = this._BuildSprite.SpriteGameObject;
		this._BuildSprite.SetSprite(DataManager.msgBuffer, DataManager.DataBuffer);
		ushort num = 1;
		if (DataManager.Instance.RoleAttr.Head != 0)
		{
			num = DataManager.Instance.RoleAttr.Head;
		}
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(num);
		ushort num2 = recordByKey.Modle;
		if (!DataManager.Instance.CheckHero3DMesh(num))
		{
			num2 = 1;
		}
		cstring.ClearString();
		cstring.StringToFormat("Role/hero_");
		cstring.IntToFormat((long)num2, 5, false);
		cstring.AppendFormat("{0}{1}");
		assetBundle = AssetManager.GetAssetBundle(cstring, out this.PawnassetKey);
		this.Pawn = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject);
		this.PawnTransform = this.Pawn.transform;
		this.PawnTransform.localScale = Vector3.one * (float)recordByKey.Scale * 0.01f;
		num = GameConstants.ConvertBytesToUShort(DataManager.msgBuffer, (int)b << 1);
		recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(num);
		num2 = recordByKey.Modle;
		if (!DataManager.Instance.CheckHero3DMesh(num))
		{
			num2 = 1;
		}
		cstring.ClearString();
		cstring.StringToFormat("Role/hero_");
		cstring.IntToFormat((long)num2, 5, false);
		cstring.AppendFormat("{0}{1}");
		assetBundle = AssetManager.GetAssetBundle(cstring, out this.BossassetKey);
		this.DeadBoss = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject);
		this.DeadBossTransform = this.DeadBoss.transform;
		this.DeadBossTransform.localScale = Vector3.one * (float)recordByKey.Scale * 0.01f;
		assetBundle = AssetManager.GetAssetBundle("Role/wmap_bbt", out this.BigPointassetKey, false);
		GameObject original = assetBundle.mainAsset as GameObject;
		this.BigPoint = new GameObject[(int)(b + 1)];
		this.BigPointTransform = new Transform[this.BigPoint.Length];
		for (int i = 0; i < this.BigPoint.Length; i++)
		{
			this.BigPoint[i] = (UnityEngine.Object.Instantiate(original) as GameObject);
			this.BigPointTransform[i] = this.BigPoint[i].transform;
		}
		StringManager.Instance.DeSpawnString(cstring);
	}

	// Token: 0x06002175 RID: 8565 RVA: 0x003FA888 File Offset: 0x003F8A88
	private void defaultLoad()
	{
		CString cstring = StringManager.Instance.SpawnString(30);
		byte b = DataManager.StageDataController.currentChapterID;
		AssetBundle assetBundle = null;
		this.LoadLine(b, cstring, assetBundle);
		if (b < DataManager.StageDataController.ChapterID || DataManager.StageDataController.StageRecord[(int)DataManager.StageDataController._stageMode] == DataManager.StageDataController.limitRecord[(int)DataManager.StageDataController._stageMode])
		{
			b = 5;
			this.getBossID(b);
			this._BuildSprite = new MapSprite(WorldMode.OpenUp, 6);
			this.CanBeSelect = this._BuildSprite.SpriteGameObject;
			this._BuildSprite.SetSprite(DataManager.msgBuffer, DataManager.DataBuffer);
		}
		else
		{
			b = this.LineID;
			ushort num = (ushort)this.PointID;
			this.CanBeSelect = new GameObject[(int)(b + 3)];
			this.CanBeSelect[0] = (this.CanBeSelect[this.CanBeSelect.Length - 1] = (this.CanBeSelect[this.CanBeSelect.Length - 2] = null));
			ushort num2 = 1;
			if (DataManager.Instance.RoleAttr.Head != 0)
			{
				num2 = DataManager.Instance.RoleAttr.Head;
			}
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(num2);
			ushort num3 = recordByKey.Modle;
			if (!DataManager.Instance.CheckHero3DMesh(num2))
			{
				num3 = 1;
			}
			cstring.ClearString();
			cstring.StringToFormat("Role/hero_");
			cstring.IntToFormat((long)num3, 5, false);
			cstring.AppendFormat("{0}{1}");
			assetBundle = AssetManager.GetAssetBundle(cstring, out this.PawnassetKey);
			this.Pawn = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject);
			this.PawnTransform = this.Pawn.transform;
			this.PawnTransform.localScale = Vector3.one * (float)recordByKey.Scale * 0.01f;
			NewbieManager.pTrans = this.PawnTransform;
			if ((num += 1) != GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode])
			{
				this.CanBeSelect[0] = this.Pawn;
				assetBundle = AssetManager.GetAssetBundle("Role/wmap_sbt", out this.PointassetKey, false);
				GameObject original = assetBundle.mainAsset as GameObject;
				this.Point = new GameObject[(int)(GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode] - num)];
				this.PointTransform = new Transform[this.Point.Length];
				for (int i = 0; i < this.Point.Length; i++)
				{
					this.Point[i] = (UnityEngine.Object.Instantiate(original) as GameObject);
					this.PointTransform[i] = this.Point[i].transform;
				}
			}
			this.getBossID(b);
			if (DataManager.StageDataController._stageMode == StageMode.Dare)
			{
				for (int j = 0; j < (int)b; j++)
				{
					this.CanBeSelect[j + 1] = null;
				}
			}
			else if (b != 0)
			{
				this._BuildSprite = new MapSprite(WorldMode.OpenUp, (ushort)b);
				for (int k = 0; k < (int)b; k++)
				{
					this.CanBeSelect[k + 1] = this._BuildSprite.SpriteGameObject[k];
				}
				this._BuildSprite.SetSprite(DataManager.msgBuffer, DataManager.DataBuffer);
			}
			num2 = GameConstants.ConvertBytesToUShort(DataManager.msgBuffer, (int)b << 1);
			recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(num2);
			num3 = recordByKey.Modle;
			if (!DataManager.Instance.CheckHero3DMesh(num2))
			{
				num3 = 1;
			}
			cstring.ClearString();
			cstring.StringToFormat("Role/hero_");
			cstring.IntToFormat((long)num3, 5, false);
			cstring.AppendFormat("{0}{1}");
			assetBundle = AssetManager.GetAssetBundle(cstring, out this.BossassetKey);
			this.Boss = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject);
			this.BossTransform = this.Boss.transform;
			this.BossTransform.localScale = Vector3.one * (float)recordByKey.Scale * 0.01f;
			if (this.CanBeSelect[0] == null)
			{
				this.CanBeSelect[0] = this.Boss;
			}
			else
			{
				this.CanBeSelect[this.CanBeSelect.Length - 1] = this.Boss;
			}
			int num4 = (int)(DataManager.StageDataController.StageRecord[0] % GameConstants.StagePointNum[0]);
			if (DataManager.StageDataController._stageMode == StageMode.Full && num4 < 15)
			{
				cstring.ClearString();
				cstring.AppendFormat("Role/RewardBtn");
				assetBundle = AssetManager.GetAssetBundle(cstring, out this.TreasureassetKey);
				this.CanBeSelect[this.CanBeSelect.Length - 2] = (this.Treasure = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject));
				this.TreasureTransform = this.Treasure.transform;
			}
		}
		assetBundle = AssetManager.GetAssetBundle("Role/wmap_bbt", out this.BigPointassetKey, false);
		GameObject original2 = assetBundle.mainAsset as GameObject;
		this.BigPoint = new GameObject[(int)(b + 1)];
		this.BigPointTransform = new Transform[this.BigPoint.Length];
		for (int l = 0; l < this.BigPoint.Length; l++)
		{
			this.BigPoint[l] = (UnityEngine.Object.Instantiate(original2) as GameObject);
			this.BigPointTransform[l] = this.BigPoint[l].transform;
		}
		StringManager.Instance.DeSpawnString(cstring);
	}

	// Token: 0x06002176 RID: 8566 RVA: 0x003FADF4 File Offset: 0x003F8FF4
	private void FirstReady()
	{
		byte b = this.LineID;
		if ((int)b >= this.BigPoint.Length)
		{
			b = (byte)(this.BigPoint.Length - 1);
		}
		this.Line.transform.position = this.LinePos;
		Animation component = this.Line.GetComponent<Animation>();
		AnimationState animationState = component[b.ToString()];
		animationState.speed = 0.05f;
		if (b > 0)
		{
			float num = (float)(b + 1);
			num = 1f - 1f / num;
			animationState.time = animationState.length * num;
		}
		if (this.stateUpdateDelegates != null)
		{
			component.Play(b.ToString());
		}
		else
		{
			component.Stop();
		}
		for (int i = 0; i < this.BigPoint.Length; i++)
		{
			this.BigPointTransform[i].position = this.BigPointPos[i];
		}
		this.BigPointTransform[(int)b].position = this.BigPointPos[(int)b] + Vector3.up * 50f;
		this.BigPoint[(int)b].SetActive(false);
		if (this._BuildSprite != null)
		{
			int num2 = 0;
			while (num2 < this._BuildSprite.SpriteGameObject.Length && num2 < this.BigPointPos.Length)
			{
				Vector3 vector = this.BigPointPos[num2] + Vector3.up * this.Spriteoffset;
				this._BuildSprite.SetSpritePosition((ushort)num2, vector);
				this._BuildSprite.SpriteGameObject[num2].transform.LookAt(Camera.main.transform);
				vector.Set(360f - this._BuildSprite.SpriteGameObject[num2].transform.localEulerAngles.x, 182f, 0f);
				Quaternion localRotation = this._BuildSprite.SpriteGameObject[num2].transform.localRotation;
				localRotation.eulerAngles = vector;
				this._BuildSprite.SpriteGameObject[num2].transform.rotation = localRotation;
				num2++;
			}
		}
		if (this.Point != null)
		{
			for (int j = 0; j < this.Point.Length; j++)
			{
				int num3 = (int)((ushort)b * (GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode] - 1) + 1) - j;
				if (num3 >= this.PointPos.Length)
				{
					num3 = this.PointPos.Length - 1;
				}
				this.PointTransform[j].position = this.PointPos[num3] + Vector3.up * this.FallStart;
				this.Point[j].SetActive(false);
			}
			if (this.Pawn != null)
			{
				this.PawnTransform.localScale *= this.Pawnscale;
				this.PawnTransform.position = this.PointTransform[this.Point.Length - 1].position + Vector3.up * this.Pawnoffset;
				Vector3 vector = this.BigPointTransform[(int)b].position - this.PawnTransform.position;
				vector.y = 0f;
				if (vector != Vector3.zero)
				{
					this.PawnTransform.rotation = Quaternion.LookRotation(vector);
				}
				component = this.Pawn.GetComponent<Animation>();
				component.Stop();
				this.Pawn.SetActive(false);
			}
			if (this.stateUpdateDelegates != null)
			{
				this._openState = OpenUp.OpenState.FirstPointDown;
				this.Point[1].SetActive(true);
			}
			else
			{
				this.Point[1].SetActive(false);
			}
		}
		else if (this.Pawn != null)
		{
			this.PawnTransform.localScale *= this.Pawnscale;
			this.PawnTransform.position = this.PointPos[0] + Vector3.up * (this.FallStart + this.Pawnoffset);
			Vector3 vector = this.BigPointTransform[(int)b].position - this.PawnTransform.position;
			vector.y = 0f;
			if (vector != Vector3.zero)
			{
				this.PawnTransform.rotation = Quaternion.LookRotation(vector);
			}
			component = this.Pawn.GetComponent<Animation>();
			component.Stop();
			this.Pawn.SetActive(false);
			if (this.stateUpdateDelegates != null)
			{
				this._openState = OpenUp.OpenState.BigPointDown;
				this.BigPoint[(int)b].SetActive(true);
			}
			else
			{
				this.BigPoint[(int)b].SetActive(false);
			}
		}
		if (this.Boss != null)
		{
			this.BossTransform.position = this.BigPointTransform[(int)b].position + Vector3.up * this.Bossoffset;
			this.BossTransform.localScale *= this.Bossscale;
			Vector3 vector = Camera.main.transform.position - this.BossTransform.position;
			vector.y = 0f;
			if (vector != Vector3.zero)
			{
				this.BossTransform.rotation = Quaternion.LookRotation(vector);
			}
			this.BossAnimation = this.Boss.GetComponent<Animation>();
			this.BossAnimation.wrapMode = WrapMode.Loop;
			this.BossAnimation.Stop();
			this.Boss.SetActive(false);
		}
		if (this.Treasure != null)
		{
			this.TreasureTransform.position = this.BigPointPos[this.BigPointPos.Length - 1] + Vector3.up * (this.FallStart + this.Treasureoffset);
			this.TreasureTransform.localScale *= this.Treasurescale;
			component = this.Treasure.GetComponent<Animation>();
			component.wrapMode = WrapMode.Loop;
			component.Play("idle");
			this.Treasure.SetActive(false);
		}
	}

	// Token: 0x06002177 RID: 8567 RVA: 0x003FB450 File Offset: 0x003F9650
	private void FullWinReady()
	{
		byte lineID = this.LineID;
		this.Line.transform.position = this.LinePos;
		Animation component = this.Line.GetComponent<Animation>();
		AnimationState animationState = component[lineID.ToString()];
		animationState.time = animationState.length;
		component.Play(lineID.ToString());
		for (int i = 0; i < this.BigPoint.Length; i++)
		{
			this.BigPointTransform[i].position = this.BigPointPos[i];
		}
		if (this._BuildSprite != null)
		{
			ushort num = 0;
			while ((int)num < this._BuildSprite.SpriteGameObject.Length)
			{
				Vector3 vector = this.BigPointPos[(int)num] + Vector3.up * this.Spriteoffset;
				this._BuildSprite.SetSpritePosition(num, vector);
				this._BuildSprite.SpriteGameObject[(int)num].transform.LookAt(Camera.main.transform);
				vector.Set(360f - this._BuildSprite.SpriteGameObject[(int)num].transform.localEulerAngles.x, 182f, 0f);
				Quaternion localRotation = this._BuildSprite.SpriteGameObject[(int)num].transform.localRotation;
				localRotation.eulerAngles = vector;
				this._BuildSprite.SpriteGameObject[(int)num].transform.rotation = localRotation;
				num += 1;
			}
		}
		if (this.Point != null)
		{
			for (int j = 0; j < this.Point.Length; j++)
			{
				this.PointTransform[j].position = this.PointPos[(int)((ushort)lineID * (GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode] - 1) + 1) - j];
			}
			if (this.Pawn != null)
			{
				this.PawnTransform.localScale *= this.Pawnscale;
				this.PawnTransform.position = this.PointTransform[this.Point.Length - 1].position + Vector3.up * this.Pawnoffset;
				Vector3 vector = Camera.main.transform.position - this.Pawn.transform.position;
				vector.y = 0f;
				if (vector != Vector3.zero)
				{
					this.PawnTransform.rotation = Quaternion.LookRotation(vector);
				}
				component = this.Pawn.GetComponent<Animation>();
				component.wrapMode = WrapMode.Loop;
				component.Play("victory");
				Transform transform = this.Halo.transform;
				transform.SetParent(this.Point[this.Point.Length - 1].transform, false);
				transform.localPosition = Vector3.forward * 0.5f;
				transform.rotation = Quaternion.identity;
				this.Halo.SetActive(true);
			}
		}
		if (this.Boss != null)
		{
			this.BossTransform.position = this.BigPointTransform[(int)lineID].position + Vector3.up * this.Bossoffset;
			this.BossTransform.localScale *= this.Bossscale;
			Vector3 vector = Camera.main.transform.position - this.BossTransform.position;
			vector.y = 0f;
			if (vector != Vector3.zero)
			{
				this.BossTransform.rotation = Quaternion.LookRotation(vector);
			}
			this.BossAnimation = this.Boss.GetComponent<Animation>();
			this.BossAnimation.wrapMode = WrapMode.Loop;
			this.BossAnimationTime = this.BossAnimation["victory"].length;
			this.BossAnimation.Play("victory");
		}
		if (this.Treasure != null)
		{
			this.TreasureTransform.position = this.BigPointPos[this.BigPointPos.Length - 1] + Vector3.up * this.Treasureoffset;
			this.TreasureTransform.localScale *= this.Treasurescale;
			component = this.Treasure.GetComponent<Animation>();
			component.wrapMode = WrapMode.Loop;
			component.Play("idle");
		}
	}

	// Token: 0x06002178 RID: 8568 RVA: 0x003FB8E8 File Offset: 0x003F9AE8
	private void LeanWinReady()
	{
		byte b = this.LineID;
		b -= 1;
		this.Line.transform.position = this.LinePos;
		Animation component = this.Line.GetComponent<Animation>();
		AnimationState animationState = component[b.ToString()];
		animationState.time = animationState.length;
		component.Play(b.ToString());
		b += 1;
		for (int i = 0; i < this.BigPoint.Length; i++)
		{
			this.BigPointTransform[i].position = this.BigPointPos[i];
		}
		this.BigPointTransform[(int)b].position = this.BigPointPos[(int)b] + Vector3.up * this.FallStart;
		this.BigPoint[(int)b].SetActive(false);
		if (this._BuildSprite != null)
		{
			for (int j = 0; j < (int)b; j++)
			{
				Vector3 vector = this.BigPointPos[j] + Vector3.up * this.Spriteoffset;
				this._BuildSprite.SetSpritePosition((ushort)j, vector);
				this._BuildSprite.SpriteGameObject[j].transform.LookAt(Camera.main.transform);
				vector.Set(360f - this._BuildSprite.SpriteGameObject[j].transform.localEulerAngles.x, 182f, 0f);
				Quaternion localRotation = this._BuildSprite.SpriteGameObject[j].transform.localRotation;
				localRotation.eulerAngles = vector;
				this._BuildSprite.SpriteGameObject[j].transform.rotation = localRotation;
			}
			this._BuildSprite.SpriteGameObject[(int)(b - 1)].transform.position = this.BigPointPos[(int)(b - 1)] + Vector3.down * this.UpStart;
			this._BuildSprite.SpriteGameObject[(int)(b - 1)].gameObject.SetActive(false);
		}
		if (this.Point != null)
		{
			for (int k = 0; k < this.Point.Length; k++)
			{
				Transform transform = this.PointTransform[k];
				Vector3 position = this.PointPos[(int)((ushort)b * (GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode] - 1) + 1) - k] + Vector3.up * this.FallStart;
				this.PointTransform[k].position = position;
				transform.position = position;
				this.Point[k].SetActive(false);
			}
		}
		if (this.Pawn != null)
		{
			this.PawnTransform.localScale *= this.Pawnscale;
			this.PawnTransform.position = (this.BigPointTransform[(int)(b - 1)].position + this.PointPos[(int)(2 * b - 1)]) * 0.5f + Vector3.up * this.Pawnoffset;
			Vector3 vector = Camera.main.transform.position - this.PawnTransform.position;
			vector.y = 0f;
			if (vector != Vector3.zero)
			{
				this.PawnTransform.rotation = Quaternion.LookRotation(vector);
			}
			component = this.Pawn.GetComponent<Animation>();
			component.wrapMode = WrapMode.Loop;
			component.Play("victory");
		}
		if (this.Boss != null)
		{
			this.BossTransform.position = this.BigPointTransform[(int)b].position + Vector3.up * this.Bossoffset;
			this.BossTransform.localScale *= this.Bossscale;
			Vector3 vector = Camera.main.transform.position - this.BossTransform.position;
			vector.y = 0f;
			if (vector != Vector3.zero)
			{
				this.BossTransform.rotation = Quaternion.LookRotation(vector);
			}
			this.BossAnimation = this.Boss.GetComponent<Animation>();
			this.BossAnimation.Stop();
			this.Boss.SetActive(false);
		}
		if (this.DeadBoss != null)
		{
			this.DeadBossTransform.position = this.BigPointTransform[(int)(b - 1)].position + Vector3.up * this.Bossoffset;
			this.DeadBossTransform.localScale *= this.Bossscale;
			Vector3 vector = Camera.main.transform.position - this.DeadBossTransform.position;
			vector.y = 0f;
			if (vector != Vector3.zero)
			{
				this.DeadBossTransform.rotation = Quaternion.LookRotation(vector);
			}
			this.DeadBossAnimation = this.DeadBoss.GetComponent<Animation>();
			this.DeadBossAnimation.wrapMode = WrapMode.Once;
			this.DeadBossAnimation.Play("die");
			this.DeadBossAnimation.Stop();
		}
		if (this.Treasure != null)
		{
			this.TreasureTransform.position = this.BigPointPos[this.BigPointPos.Length - 1] + Vector3.up * this.Treasureoffset;
			this.TreasureTransform.localScale *= this.Treasurescale;
			component = this.Treasure.GetComponent<Animation>();
			component.wrapMode = WrapMode.Loop;
			component.Play("idle");
		}
		if ((uint)DataManager.MissionDataManager.HeroNum == DataManager.Instance.CurHeroDataCount)
		{
			StageManager stageDataController = DataManager.StageDataController;
			if (stageDataController._stageMode == StageMode.Full || stageDataController._stageMode == StageMode.Lean)
			{
				DataManager.MissionDataManager.CheckChanged((eMissionKind)((byte)(3 + DataManager.StageDataController._stageMode)), 1, DataManager.StageDataController.StageRecord[(int)DataManager.StageDataController._stageMode]);
			}
			else if (stageDataController._stageMode == StageMode.Dare)
			{
				int stagePoint = stageDataController.GetStagePoint(stageDataController.currentPointID, 0);
				DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeStage, 1, stageDataController.StageRecord[3]);
				if (stagePoint > 0)
				{
					DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeAdvance, stageDataController.currentPointID, (ushort)stagePoint);
				}
			}
		}
	}

	// Token: 0x06002179 RID: 8569 RVA: 0x003FBF90 File Offset: 0x003FA190
	private void FinalWinReady()
	{
		byte b = 5;
		this.Line.transform.position = this.LinePos;
		Animation component = this.Line.GetComponent<Animation>();
		AnimationState animationState = component[b.ToString()];
		animationState.time = animationState.length;
		component.Play(b.ToString());
		for (int i = 0; i < this.BigPoint.Length; i++)
		{
			this.BigPointTransform[i].position = this.BigPointPos[i];
		}
		if (this._BuildSprite != null)
		{
			if (DataManager.StageDataController._stageMode == StageMode.Dare)
			{
				ushort num = 0;
				while ((int)num < this._BuildSprite.SpriteGameObject.Length)
				{
					Vector3 vector = this.BigPointPos[(int)num] + Vector3.down * this.UpStart;
					this._BuildSprite.SetSpritePosition(num, vector);
					this._BuildSprite.SpriteGameObject[(int)num].transform.LookAt(Camera.main.transform);
					vector.Set(360f - this._BuildSprite.SpriteGameObject[(int)num].transform.localEulerAngles.x, 182f, 0f);
					Quaternion localRotation = this._BuildSprite.SpriteGameObject[(int)num].transform.localRotation;
					localRotation.eulerAngles = vector;
					this._BuildSprite.SpriteGameObject[(int)num].transform.rotation = localRotation;
					this._BuildSprite.SpriteGameObject[(int)num].gameObject.SetActive(false);
					num += 1;
				}
			}
			else
			{
				ushort num2 = 0;
				while ((int)num2 < this._BuildSprite.SpriteGameObject.Length)
				{
					Vector3 vector = this.BigPointPos[(int)num2] + Vector3.up * this.Spriteoffset;
					this._BuildSprite.SetSpritePosition(num2, vector);
					this._BuildSprite.SpriteGameObject[(int)num2].transform.LookAt(Camera.main.transform);
					vector.Set(360f - this._BuildSprite.SpriteGameObject[(int)num2].transform.localEulerAngles.x, 182f, 0f);
					Quaternion localRotation2 = this._BuildSprite.SpriteGameObject[(int)num2].transform.localRotation;
					localRotation2.eulerAngles = vector;
					this._BuildSprite.SpriteGameObject[(int)num2].transform.rotation = localRotation2;
					num2 += 1;
				}
				this._BuildSprite.SpriteGameObject[(int)b].transform.position = this.BigPointPos[(int)b] + Vector3.down * this.UpStart;
				this._BuildSprite.SpriteGameObject[(int)b].gameObject.SetActive(false);
			}
		}
		if (this.Pawn != null)
		{
			this.PawnTransform.localScale *= this.Pawnscale;
			this.PawnTransform.position = (this.BigPointTransform[(int)b].position + this.PointPos[(int)((ushort)b * (GameConstants.LinePointNum[0] - 1) + 1)]) * 0.5f + Vector3.up * this.Pawnoffset;
			Vector3 vector = Camera.main.transform.position - this.PawnTransform.position;
			vector.y = 0f;
			if (vector != Vector3.zero)
			{
				this.PawnTransform.rotation = Quaternion.LookRotation(vector);
			}
			component = this.Pawn.GetComponent<Animation>();
			component.wrapMode = WrapMode.Loop;
			component.Play("victory");
		}
		if (this.DeadBoss != null)
		{
			this.DeadBossTransform.position = this.BigPointTransform[(int)b].position + Vector3.up * this.Bossoffset;
			this.DeadBossTransform.localScale *= this.Bossscale;
			Vector3 vector = Camera.main.transform.position - this.DeadBossTransform.position;
			vector.y = 0f;
			if (vector != Vector3.zero)
			{
				this.DeadBossTransform.rotation = Quaternion.LookRotation(vector);
			}
			this.DeadBossAnimation = this.DeadBoss.GetComponent<Animation>();
			this.DeadBossAnimation.wrapMode = WrapMode.Once;
			this.DeadBossAnimation.Play("die");
			this.DeadBossAnimation.Stop();
		}
		if ((uint)DataManager.MissionDataManager.HeroNum == DataManager.Instance.CurHeroDataCount)
		{
			StageManager stageDataController = DataManager.StageDataController;
			if (stageDataController._stageMode == StageMode.Full || stageDataController._stageMode == StageMode.Lean)
			{
				DataManager.MissionDataManager.CheckChanged((eMissionKind)((byte)(3 + DataManager.StageDataController._stageMode)), 1, DataManager.StageDataController.StageRecord[(int)DataManager.StageDataController._stageMode]);
			}
			else if (stageDataController._stageMode == StageMode.Dare)
			{
				int stagePoint = stageDataController.GetStagePoint(stageDataController.currentPointID, 0);
				DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeStage, 1, stageDataController.StageRecord[3]);
				if (stagePoint > 0)
				{
					DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeAdvance, stageDataController.currentPointID, (ushort)stagePoint);
				}
			}
		}
	}

	// Token: 0x0600217A RID: 8570 RVA: 0x003FC524 File Offset: 0x003FA724
	private void defaultReady()
	{
		byte b;
		if (DataManager.StageDataController.currentChapterID < DataManager.StageDataController.ChapterID)
		{
			b = 5;
		}
		else
		{
			b = this.LineID;
		}
		this.Line.transform.position = this.LinePos;
		Animation component = this.Line.GetComponent<Animation>();
		AnimationState animationState = component[b.ToString()];
		animationState.time = animationState.length;
		component.Play(b.ToString());
		for (int i = 0; i < this.BigPoint.Length; i++)
		{
			this.BigPointTransform[i].position = this.BigPointPos[i];
		}
		if (this._BuildSprite != null)
		{
			ushort num = 0;
			while ((int)num < this._BuildSprite.SpriteGameObject.Length)
			{
				Vector3 vector = this.BigPointPos[(int)num] + Vector3.up * this.Spriteoffset;
				this._BuildSprite.SetSpritePosition(num, vector);
				this._BuildSprite.SpriteGameObject[(int)num].transform.LookAt(Camera.main.transform);
				vector.Set(360f - this._BuildSprite.SpriteGameObject[(int)num].transform.localEulerAngles.x, 182f, 0f);
				Quaternion localRotation = this._BuildSprite.SpriteGameObject[(int)num].transform.localRotation;
				localRotation.eulerAngles = vector;
				this._BuildSprite.SpriteGameObject[(int)num].transform.rotation = localRotation;
				num += 1;
			}
		}
		if (this.Point != null)
		{
			for (int j = 0; j < this.Point.Length; j++)
			{
				this.PointTransform[j].position = this.PointPos[(int)((ushort)b * (GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode] - 1) + 1) - j];
			}
		}
		if (this.Pawn != null)
		{
			component = this.Pawn.GetComponent<Animation>();
			component.wrapMode = WrapMode.Loop;
			byte pointID = this.PointID;
			this.PawnTransform.localScale *= this.Pawnscale;
			Transform transform = this.Halo.transform;
			Vector3 vector;
			if (this.Point == null || (ushort)pointID == GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode] - 1)
			{
				vector = this.BigPointTransform[(int)b].position;
				this.PawnTransform.position = (vector + this.PointPos[(int)(2 * (b + 1) - 1)]) * 0.5f + Vector3.up * this.Pawnoffset;
				transform.SetParent(this.BigPointTransform[(int)b], false);
				transform.localPosition = Vector3.forward * 1.4f;
				transform.rotation = Quaternion.identity;
				this.Halo.SetActive(true);
				component.Play("idle");
			}
			else
			{
				this.PawnTransform.position = this.PointTransform[this.Point.Length - 1].position + Vector3.up * this.Pawnoffset;
				transform.SetParent(this.PointTransform[this.Point.Length - 1], false);
				transform.localPosition = Vector3.forward * 0.5f;
				transform.rotation = Quaternion.identity;
				this.Halo.SetActive(true);
				vector = this.BigPointTransform[(int)b].position;
				component.Play("moving");
			}
			vector -= this.PawnTransform.position;
			vector.y = 0f;
			if (vector != Vector3.zero)
			{
				this.PawnTransform.rotation = Quaternion.LookRotation(vector);
			}
		}
		if (this.Boss != null)
		{
			this.BossTransform.position = this.BigPointTransform[(int)b].position + Vector3.up * this.Bossoffset;
			this.BossTransform.localScale *= this.Bossscale;
			Vector3 vector = Camera.main.transform.position - this.BossTransform.position;
			vector.y = 0f;
			if (vector != Vector3.zero)
			{
				this.BossTransform.rotation = Quaternion.LookRotation(vector);
			}
			this.BossAnimation = this.Boss.GetComponent<Animation>();
			this.BossAnimation.wrapMode = WrapMode.Loop;
			this.BossAnimationTime = this.BossAnimation["victory"].length;
			this.BossAnimation.Play("victory");
		}
		if (this.Treasure != null)
		{
			this.TreasureTransform.position = this.BigPointPos[this.BigPointPos.Length - 1] + Vector3.up * this.Treasureoffset;
			this.TreasureTransform.localScale *= this.Treasurescale;
			component = this.Treasure.GetComponent<Animation>();
			component.wrapMode = WrapMode.Loop;
			component.Play("idle");
		}
		this.StartInOut(OpenUp.OpenState.In);
		if (DataManager.StageDataController.DareNodusUpdatePointID <= 0 || DataManager.StageDataController._stageMode != StageMode.Dare || DataManager.StageDataController.DareNodusUpdatePointID != DataManager.StageDataController.currentPointID)
		{
			DataManager.msgBuffer[0] = 47;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			DataManager.msgBuffer[0] = 43;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
		if (DataManager.StageDataController._stageMode == StageMode.Dare && DataManager.StageDataController.StageRecord[3] >= GameConstants.StagePointNum[3] && NewbieManager.CheckDareLead() && this._BuildSprite != null)
		{
			for (int k = 0; k < this._BuildSprite.SpriteGameObject.Length; k++)
			{
				NewbieManager.HeroIconCache[k] = ((k >= 6) ? null : this._BuildSprite.SpriteGameObject[k]);
			}
		}
		if ((uint)DataManager.MissionDataManager.HeroNum == DataManager.Instance.CurHeroDataCount)
		{
			StageManager stageDataController = DataManager.StageDataController;
			if (stageDataController._stageMode == StageMode.Dare)
			{
				int stagePoint = stageDataController.GetStagePoint(stageDataController.currentPointID, 0);
				DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeStage, 1, stageDataController.StageRecord[3]);
				if (stagePoint > 0)
				{
					DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeAdvance, stageDataController.currentPointID, (ushort)stagePoint);
				}
			}
		}
	}

	// Token: 0x0600217B RID: 8571 RVA: 0x003FCC04 File Offset: 0x003FAE04
	private void CorpsReady()
	{
		if (this.OpenUpCorpsStage != null)
		{
			if (this._openState == OpenUp.OpenState.CorpsWin)
			{
				this.DeadBoss = this.OpenUpCorpsStage.transform.GetChild(1).gameObject;
				this.DeadBossTransform = this.DeadBoss.transform;
				this.DeadBossAnimation = this.DeadBoss.GetComponent<Animation>();
				if (this.DeadBossAnimation)
				{
					this.DeadBossAnimation.wrapMode = WrapMode.Once;
					this.DeadBossAnimation.Play("die");
					this.DeadBossAnimation.Stop();
				}
				CorpsStage recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(DataManager.StageDataController.StageRecord[2]);
				GUIManager.Instance.AddHUDMessage(string.Format(DataManager.Instance.mStringTable.GetStringByID(7371u), DataManager.Instance.GetExpAddition((uint)recordByKey.LeadExp), recordByKey.HeroExp), 26, true);
				DataManager.MissionDataManager.CheckChanged(eMissionKind.CorpsPVE, 1, DataManager.StageDataController.StageRecord[2]);
				DataManager.FBMissionDataManager.CheckHUDMsg(7);
			}
			else
			{
				this.BossAnimation = this.OpenUpCorpsStage.transform.GetChild(1).gameObject.GetComponent<Animation>();
				if (this.BossAnimation)
				{
					this.BossAnimation.wrapMode = WrapMode.Loop;
					this.BossAnimation.CrossFade("victory", 0.3f);
				}
				DataManager.msgBuffer[0] = 47;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				if (DataManager.Instance.lastBattleResult == 0)
				{
					DataManager.Instance.lastBattleResult = -1;
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7344u), 23, true);
				}
			}
		}
	}

	// Token: 0x0600217C RID: 8572 RVA: 0x003FCDD4 File Offset: 0x003FAFD4
	private void FirstRun()
	{
		byte b = 0;
		switch (this._openState)
		{
		case OpenUp.OpenState.BigPointDown:
			if (this.MoveRun(this.BigPointTransform[(int)b], Vector3.up, -200f, this.BigPointPos[(int)b].y, OpenUp.OpenState.BossZoom))
			{
				AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
				if (DataManager.StageDataController._stageMode == StageMode.Full)
				{
					this.Treasure.SetActive(true);
				}
				else
				{
					this._openState = OpenUp.OpenState.BossDown;
					this.Boss.SetActive(true);
				}
			}
			break;
		case OpenUp.OpenState.FirstPointDown:
			if (this.MoveRun(this.PointTransform[1], Vector3.up, -200f, this.PointPos[0].y, OpenUp.OpenState.SecPointDown))
			{
				AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
				this.Point[0].SetActive(true);
			}
			break;
		case OpenUp.OpenState.SecPointDown:
			if (this.MoveRun(this.PointTransform[0], Vector3.up, -200f, this.PointPos[1].y, OpenUp.OpenState.BigPointDown))
			{
				AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
				this.BigPoint[(int)b].SetActive(true);
			}
			break;
		case OpenUp.OpenState.BossDown:
			if (this.MoveRun(this.BossTransform, Vector3.up, -200f, this.BigPointPos[(int)b].y + this.Bossoffset, OpenUp.OpenState.PawnDown))
			{
				AudioManager.Instance.PlayUISFX(UIKind.BossDrop);
				this.BossAnimation.wrapMode = WrapMode.Loop;
				this.BossAnimationTime = this.BossAnimation["victory"].length;
				this.BossAnimation.Play("victory");
				this.Pawn.SetActive(true);
			}
			break;
		case OpenUp.OpenState.PawnDown:
			if (this.MoveRun(this.PawnTransform, Vector3.up, -200f, this.PointPos[0].y + this.Pawnoffset, OpenUp.OpenState.Count))
			{
				Animation component = this.Pawn.GetComponent<Animation>();
				component.wrapMode = WrapMode.Loop;
				component.Play("moving");
				Transform transform = this.Halo.transform;
				if (this.Point == null)
				{
					transform.SetParent(this.BigPointTransform[0], false);
					this._openState = OpenUp.OpenState.PawnMove;
				}
				else
				{
					transform.SetParent(this.PointTransform[1], false);
				}
				transform.localPosition = Vector3.forward * 0.5f;
				transform.rotation = Quaternion.identity;
				this.Halo.SetActive(true);
			}
			break;
		case OpenUp.OpenState.PawnTurn:
		{
			Vector3 vector = (this.BigPointTransform[(int)b].position + this.PointPos[1]) * 0.5f - this.PawnTransform.position;
			vector.y = 0f;
			if (vector == Vector3.zero)
			{
				this._openState = OpenUp.OpenState.Count;
				Animation component2 = this.Pawn.GetComponent<Animation>();
				component2.wrapMode = WrapMode.Loop;
				component2.CrossFade("idle", 0.3f);
			}
			else
			{
				vector = this.BigPointTransform[(int)b].position - this.PointPos[1];
				vector.y = 0f;
				this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(vector), Time.deltaTime * 10f * 0.5f);
				this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, (this.BigPointTransform[(int)b].position + this.PointPos[1]) * 0.5f + Vector3.up * this.Pawnoffset, Time.deltaTime * 10f);
			}
			break;
		}
		case OpenUp.OpenState.PawnMove:
			if (this.PawnTransform.position == this.PointPos[1] + Vector3.up * this.Pawnoffset)
			{
				this._openState = OpenUp.OpenState.PawnTurn;
			}
			else
			{
				Vector3 vector = this.PointPos[1] - this.PawnTransform.position;
				vector.y = 0f;
				if (vector != Vector3.zero)
				{
					vector = this.PointPos[1] - this.PointPos[0];
					vector.y = 0f;
					this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(vector), Time.deltaTime * 10f * 0.5f);
					this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, this.PointPos[1] + Vector3.up * this.Pawnoffset, Time.deltaTime * 10f);
				}
			}
			break;
		case OpenUp.OpenState.BossZoom:
			if (this.MoveRun(this.TreasureTransform, Vector3.up, -200f, this.BigPointPos[this.BigPointPos.Length - 1].y + this.Treasureoffset, OpenUp.OpenState.BossDown))
			{
				AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
				this.Boss.SetActive(true);
			}
			break;
		default:
			this._openState = OpenUp.OpenState.Count;
			this.stateUpdateDelegates = null;
			DataManager.msgBuffer[0] = 44;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			DataManager.msgBuffer[0] = 47;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			if (DataManager.StageDataController._stageMode == StageMode.Corps)
			{
				DataManager.msgBuffer[0] = 37;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			else if (DataManager.StageDataController._stageMode == StageMode.Full)
			{
				if (!NewbieManager.IsTeachWorking(ETeachKind.DARE_FULL))
				{
					DataManager.StageDataController.isNotFirstInLine[(int)DataManager.StageDataController._stageMode] = 1;
				}
				DataManager.msgBuffer[0] = 37;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			else
			{
				DataManager.StageDataController.isNotFirstInLine[(int)DataManager.StageDataController._stageMode] = 1;
			}
			DataManager.msgBuffer[0] = 43;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			break;
		}
	}

	// Token: 0x0600217D RID: 8573 RVA: 0x003FD46C File Offset: 0x003FB66C
	private void FullWinRun()
	{
		byte lineID = this.LineID;
		switch (this._openState)
		{
		case OpenUp.OpenState.FirstPointDown:
		{
			int num = (int)((ushort)lineID * (GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode] - 1)) - this.Point.Length + 2;
			if (this.MoveRun(this.PointTransform[this.Point.Length - 1], Vector3.up, -1f, this.PointPos[num].y - this.PointDown, OpenUp.OpenState.PawnMove))
			{
				Animation component = this.Pawn.GetComponent<Animation>();
				component.wrapMode = WrapMode.Loop;
				component.CrossFade("moving", 0.3f);
				Transform transform = this.Halo.transform;
				if (this.PointID == 2)
				{
					transform.SetParent(this.BigPointTransform[(int)lineID], false);
					transform.localPosition = Vector3.forward * 1.4f;
				}
				else
				{
					transform.SetParent(this.PointTransform[0], false);
					transform.localPosition = Vector3.forward * 0.5f;
				}
				transform.rotation = Quaternion.identity;
			}
			return;
		}
		case OpenUp.OpenState.PawnTurn:
		{
			Vector3 vector = this.BigPointTransform[(int)lineID].position - this.PointTransform[0].position;
			vector.y = 0f;
			Quaternion quaternion = Quaternion.LookRotation(vector);
			if (Quaternion.Angle(quaternion, this.PawnTransform.rotation) == 0f)
			{
				this._openState = OpenUp.OpenState.Count;
			}
			else
			{
				this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, quaternion, Time.deltaTime * 10f * 0.5f);
			}
			return;
		}
		case OpenUp.OpenState.PawnMove:
			if (this.PointID == 2)
			{
				Vector3 vector = (this.BigPointTransform[(int)lineID].position + this.PointTransform[0].position) * 0.5f - this.PawnTransform.position;
				vector.y = 0f;
				if (vector == Vector3.zero)
				{
					this._openState = OpenUp.OpenState.Count;
					Animation component2 = this.Pawn.GetComponent<Animation>();
					component2.wrapMode = WrapMode.Loop;
					component2.CrossFade("idle", 0.3f);
				}
				else
				{
					vector = this.BigPointTransform[(int)lineID].position - this.PointTransform[0].position;
					vector.y = 0f;
					this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(vector), Time.deltaTime * 10f * 0.5f);
					this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, (this.BigPointTransform[(int)lineID].position + this.PointTransform[0].position) * 0.5f + Vector3.up * this.Pawnoffset, Time.deltaTime * 10f);
				}
			}
			else
			{
				Vector3 vector = this.PointTransform[0].position - this.PawnTransform.position;
				vector.y = 0f;
				if (vector == Vector3.zero)
				{
					this._openState = OpenUp.OpenState.PawnTurn;
				}
				else
				{
					vector = this.PointTransform[0].position - this.PointTransform[1].position;
					vector.y = 0f;
					this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(vector), Time.deltaTime * 10f * 0.5f);
					this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, this.PointTransform[0].position + Vector3.up * this.Pawnoffset, Time.deltaTime * 10f);
				}
			}
			return;
		}
		this._openState = OpenUp.OpenState.Count;
		this.stateUpdateDelegates = null;
		DataManager.msgBuffer[0] = 44;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		DataManager.msgBuffer[0] = 47;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		NewbieManager.CheckShowArrow(true, this.Halo);
		if (NewbieManager.CheckPutOnEquipTeach())
		{
			NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, null, false);
		}
		DataManager.msgBuffer[0] = 43;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x0600217E RID: 8574 RVA: 0x003FD900 File Offset: 0x003FBB00
	private void LeanWinRun()
	{
		byte lineID = this.LineID;
		switch (this._openState)
		{
		case OpenUp.OpenState.BigPointDown:
			if (this.MoveRun(this.BigPointTransform[(int)lineID], Vector3.up, -200f, this.BigPointPos[(int)lineID].y, OpenUp.OpenState.BossDown))
			{
				AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
				this.Boss.SetActive(true);
				if (this.Treasure != null)
				{
					int num = (int)(DataManager.StageDataController.StageRecord[0] % GameConstants.StagePointNum[0]);
					if (num == 15)
					{
						this.Treasure.SetActive(false);
					}
				}
				if (this.Point == null)
				{
					DataManager.msgBuffer[0] = 44;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					DataManager.msgBuffer[0] = 47;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					DataManager.msgBuffer[0] = 43;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
			}
			if (this.Point == null)
			{
				Vector3 vector = this.BigPointTransform[(int)lineID].position - this.PawnTransform.position;
				vector.y = 0f;
				this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(vector), Time.deltaTime * 200f * 0.1f);
			}
			if (this.Treasure != null)
			{
				int num2 = (int)(DataManager.StageDataController.StageRecord[0] % GameConstants.StagePointNum[0]);
				if (num2 == 15)
				{
					float num3 = 12f;
					if (this.BigPointTransform[(int)lineID].position.y < this.BigPointPos[(int)lineID].y + num3)
					{
						Vector3 vector = this.TreasureTransform.position;
						vector.y = this.BigPointTransform[(int)lineID].position.y - num3;
						this.TreasureTransform.position = vector;
					}
				}
			}
			break;
		case OpenUp.OpenState.FirstPointDown:
		{
			if (this.MoveRun(this.PointTransform[1], Vector3.up, -200f, this.PointPos[(int)((ushort)lineID * (GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode] - 1))].y, OpenUp.OpenState.SecPointDown))
			{
				AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
				this.Point[0].SetActive(true);
				DataManager.msgBuffer[0] = 44;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				DataManager.msgBuffer[0] = 47;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				DataManager.msgBuffer[0] = 43;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			Vector3 vector = this.PointTransform[1].position - this.PawnTransform.position;
			vector.y = 0f;
			this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(vector), Time.deltaTime * 200f * 0.1f);
			break;
		}
		case OpenUp.OpenState.SecPointDown:
			if (this.MoveRun(this.PointTransform[0], Vector3.up, -200f, this.PointPos[(int)((ushort)lineID * (GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode] - 1) + 1)].y, OpenUp.OpenState.BigPointDown))
			{
				AudioManager.Instance.PlayUISFX(UIKind.PlatformDrop);
				this.BigPoint[(int)lineID].SetActive(true);
			}
			break;
		case OpenUp.OpenState.BossDown:
			if (this.MoveRun(this.BossTransform, Vector3.up, -200f, this.BigPointPos[(int)lineID].y + this.Bossoffset, OpenUp.OpenState.PawnDown))
			{
				AudioManager.Instance.PlayUISFX(UIKind.BossDrop);
				this.BossAnimation.wrapMode = WrapMode.Loop;
				this.BossAnimationTime = this.BossAnimation["victory"].length;
				this.BossAnimation.Play("victory");
				Transform transform = this.Halo.transform;
				if (this.Point == null)
				{
					transform.SetParent(this.BigPointTransform[(int)lineID], false);
					transform.localPosition = Vector3.forward * 1.4f;
				}
				else
				{
					transform.SetParent(this.PointTransform[1], false);
					transform.localPosition = Vector3.forward * 0.5f;
				}
				transform.rotation = Quaternion.identity;
				this.Halo.SetActive(true);
			}
			break;
		case OpenUp.OpenState.PawnDown:
			if (this.Point == null)
			{
				Vector3 vector = this.PointPos[(int)(2 * lineID)] - this.PawnTransform.position;
				vector.y = 0f;
				if (vector == Vector3.zero)
				{
					this._openState = OpenUp.OpenState.LineUp;
				}
				else
				{
					this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(vector), Time.deltaTime * 200f * 0.05f);
					this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, this.PointPos[(int)(2 * lineID)] + Vector3.up * this.Pawnoffset, Time.deltaTime * 200f * 0.05f);
				}
			}
			else
			{
				Vector3 vector = this.PointTransform[1].position - this.PawnTransform.position;
				vector.y = 0f;
				if (vector == Vector3.zero)
				{
					if (this._BuildSprite == null)
					{
						this._openState = OpenUp.OpenState.Count;
					}
					else
					{
						this._BuildSprite.SpriteGameObject[this._BuildSprite.SpriteGameObject.Length - 1].SetActive(true);
						this._openState = OpenUp.OpenState.SpriteUp;
					}
				}
				else
				{
					this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(vector), Time.deltaTime * 200f * 0.025f);
					this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, this.PointTransform[1].position + Vector3.up * this.Pawnoffset, Time.deltaTime * 200f * 0.05f);
				}
			}
			break;
		case OpenUp.OpenState.PawnTurn:
		{
			Vector3 vector = this.BigPointPos[(int)(lineID - 1)] - this.PointPos[(int)(2 * lineID - 1)];
			vector.y = 0f;
			Quaternion quaternion = Quaternion.LookRotation(vector);
			if (Quaternion.Angle(quaternion, this.PawnTransform.rotation) == 0f)
			{
				this._openState = OpenUp.OpenState.PawnMove;
			}
			else
			{
				this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, quaternion, Time.deltaTime * 200f * 0.1f);
			}
			break;
		}
		case OpenUp.OpenState.PawnMove:
		{
			Vector3 vector = this.BigPointPos[(int)(lineID - 1)] - this.PawnTransform.position;
			vector.y = 0f;
			if (vector == Vector3.zero)
			{
				Animation component = this.Line.GetComponent<Animation>();
				AnimationState animationState = component[lineID.ToString()];
				animationState.speed = 0.05f;
				if (lineID > 0)
				{
					float num4 = (float)(lineID + 1);
					num4 = 1f - 1f / num4;
					animationState.time = animationState.length * num4;
				}
				component.Play(lineID.ToString());
				if (this.Point == null)
				{
					this.BigPoint[(int)lineID].SetActive(true);
					this._openState = OpenUp.OpenState.BigPointDown;
				}
				else
				{
					this.Point[1].SetActive(true);
					this._openState = OpenUp.OpenState.FirstPointDown;
				}
			}
			else
			{
				this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, this.BigPointPos[(int)(lineID - 1)] + Vector3.up * this.Pawnoffset, Time.deltaTime * 200f * 0.05f);
			}
			break;
		}
		case OpenUp.OpenState.BossZoom:
		{
			AnimationState animationState = this.DeadBossAnimation["die"];
			if (!animationState.enabled)
			{
				this._openState = OpenUp.OpenState.BossDead;
			}
			break;
		}
		case OpenUp.OpenState.BossDead:
			if (this.MoveRun(this.DeadBossTransform, Vector3.up, -10f, this.BigPointPos[(int)(lineID - 1)].y - this.BossDown, OpenUp.OpenState.PawnTurn))
			{
				this.DeadBoss.gameObject.SetActive(false);
				Animation component = this.Pawn.GetComponent<Animation>();
				component.wrapMode = WrapMode.Loop;
				component.CrossFade("moving", 0.3f);
			}
			break;
		case OpenUp.OpenState.SpriteUp:
		{
			Vector3 vector = this.BossTransform.position - this.PawnTransform.position;
			vector.y = 0f;
			if (vector != Vector3.zero)
			{
				this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(vector), Time.deltaTime * 200f * 0.025f);
				this._BuildSprite.UpdateMapSprite((ushort)lineID, 0);
			}
			if (this.MoveRun(this._BuildSprite.SpriteGameObject[(int)(lineID - 1)].transform, Vector3.up, 20f, this.BigPointPos[(int)(lineID - 1)].y + this.Spriteoffset, OpenUp.OpenState.ShowSpriteStar))
			{
				this._BuildSprite.UpdateMapSprite((ushort)lineID, 1);
			}
			break;
		}
		case OpenUp.OpenState.LineUp:
		{
			Vector3 vector = (this.BigPointPos[(int)lineID] + this.PointPos[(int)(2 * lineID + 1)]) * 0.5f - this.PawnTransform.position;
			vector.y = 0f;
			if (vector == Vector3.zero)
			{
				this._BuildSprite.SpriteGameObject[this._BuildSprite.SpriteGameObject.Length - 1].SetActive(true);
				Animation component = this.Pawn.GetComponent<Animation>();
				component.wrapMode = WrapMode.Loop;
				component.CrossFade("idle", 0.3f);
				this._openState = OpenUp.OpenState.SpriteUp;
			}
			else
			{
				this.PawnTransform.rotation = Quaternion.Slerp(this.PawnTransform.rotation, Quaternion.LookRotation(vector), Time.deltaTime * 200f * 0.05f);
				this.PawnTransform.position = GameConstants.MoveTowardsPlus(this.PawnTransform.position, (this.BigPointPos[(int)lineID] + this.PointPos[(int)(2 * lineID + 1)]) * 0.5f + Vector3.up * this.Pawnoffset, Time.deltaTime * 200f * 0.05f);
			}
			break;
		}
		case OpenUp.OpenState.ShowSpriteStar:
			if (!this._BuildSprite.UpdateRun(Time.deltaTime))
			{
				this._openState = OpenUp.OpenState.Count;
			}
			break;
		default:
			DataManager.StageDataController.isNotFirstInLine[(int)DataManager.StageDataController._stageMode] = 1;
			NewbieManager.CheckShowArrow(true, this.Halo);
			this._openState = OpenUp.OpenState.Count;
			this.stateUpdateDelegates = null;
			break;
		}
	}

	// Token: 0x0600217F RID: 8575 RVA: 0x003FE488 File Offset: 0x003FC688
	private void FinalWinRun()
	{
		byte b = 5;
		switch (this._openState)
		{
		case OpenUp.OpenState.PawnDown:
			this.MoveRun(this.PawnTransform, Vector3.up, 200f, this.BigPointPos[(int)b].y + this.FallStart, OpenUp.OpenState.Count);
			return;
		case OpenUp.OpenState.BossZoom:
			if (!this.DeadBossAnimation.isPlaying)
			{
				this._openState = OpenUp.OpenState.BossDead;
			}
			return;
		case OpenUp.OpenState.BossDead:
			if (this.MoveRun(this.DeadBossTransform, Vector3.up, -10f, this.BigPointPos[(int)b].y + this.Bossoffset - this.BossDown, OpenUp.OpenState.SpriteUp))
			{
				this.DeadBoss.gameObject.SetActive(false);
				if (DataManager.StageDataController._stageMode == StageMode.Dare)
				{
					for (int i = 0; i <= (int)b; i++)
					{
						this._BuildSprite.SpriteGameObject[i].SetActive(true);
						this._BuildSprite.UpdateMapSprite((ushort)(i + 1), 0);
					}
					AudioManager.Instance.PlayMP3SFX(41002, 1.5f);
				}
				else
				{
					this._BuildSprite.SpriteGameObject[(int)b].SetActive(true);
					this._BuildSprite.UpdateMapSprite((ushort)(b + 1), 0);
				}
				Animation component = this.Pawn.GetComponent<Animation>();
				component.wrapMode = WrapMode.Loop;
				component.CrossFade("idle", 0.3f);
			}
			return;
		case OpenUp.OpenState.SpriteUp:
			if (DataManager.StageDataController._stageMode == StageMode.Dare)
			{
				for (int j = 0; j <= (int)b; j++)
				{
					if (this.MoveRun(this._BuildSprite.SpriteGameObject[j].transform, Vector3.up, 5f, this.BigPointPos[j].y + this.Spriteoffset, OpenUp.OpenState.ShowSpriteStar))
					{
						this._BuildSprite.UpdateMapSprite((ushort)(j + 1), 1);
					}
				}
			}
			else if (this.MoveRun(this._BuildSprite.SpriteGameObject[(int)b].transform, Vector3.up, 5f, this.BigPointPos[(int)b].y + this.Spriteoffset, OpenUp.OpenState.ShowSpriteStar))
			{
				this._BuildSprite.UpdateMapSprite((ushort)(b + 1), 1);
			}
			return;
		case OpenUp.OpenState.ShowSpriteStar:
			if (!this._BuildSprite.UpdateRun(Time.deltaTime))
			{
				this._openState = OpenUp.OpenState.PawnDown;
				if (DataManager.StageDataController._stageMode == StageMode.Full)
				{
					GUIManager.Instance.m_HUDMessage.MapHud.SkipMsg();
				}
			}
			return;
		}
		DataManager.msgBuffer[0] = 44;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		DataManager.msgBuffer[0] = 47;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		this._openState = OpenUp.OpenState.Count;
		this.stateUpdateDelegates = null;
		if (DataManager.StageDataController._stageMode == StageMode.Lean)
		{
			DataManager.StageDataController.isNotFirstInChapter[(int)DataManager.StageDataController._stageMode] = 0;
			DataManager.StageDataController.SaveisNotFirstInChapter();
			if (DataManager.StageDataController.StageRecord[1] == 4 * GameConstants.StagePointNum[1] && DataManager.StageDataController.limitRecord[3] > 0)
			{
				NewbieManager.CheckDareFull(true);
			}
			else if (DataManager.StageDataController.StageRecord[1] * 3 == DataManager.StageDataController.StageRecord[0] || DataManager.StageDataController.StageRecord[1] == DataManager.StageDataController.limitRecord[1])
			{
				DataManager.msgBuffer[0] = 4;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			else
			{
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.NextStage);
			}
			DataManager.msgBuffer[0] = 43;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
		else if (DataManager.StageDataController._stageMode == StageMode.Dare)
		{
			DataManager.StageDataController.isNotFirstInChapter[(int)DataManager.StageDataController._stageMode] = 0;
			DataManager.StageDataController.SaveisNotFirstInChapter();
			if (DataManager.StageDataController.StageRecord[3] == GameConstants.StagePointNum[3])
			{
				if (NewbieManager.CheckDareLead() && this._BuildSprite != null)
				{
					for (int k = 0; k < this._BuildSprite.SpriteGameObject.Length; k++)
					{
						NewbieManager.HeroIconCache[k] = ((k >= 6) ? null : this._BuildSprite.SpriteGameObject[k]);
					}
				}
			}
			else if (DataManager.StageDataController.StageRecord[3] == DataManager.StageDataController.StageRecord[1] * 3 - 1 || DataManager.StageDataController.StageRecord[3] == DataManager.StageDataController.limitRecord[3])
			{
				DataManager.msgBuffer[0] = 4;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			else
			{
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.NextStage);
			}
			DataManager.msgBuffer[0] = 43;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
		else
		{
			DataManager.msgBuffer[0] = 38;
			DataManager.msgBuffer[1] = 1;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x06002180 RID: 8576 RVA: 0x003FE9A0 File Offset: 0x003FCBA0
	private void CorpsWinRun()
	{
		switch (this._openState)
		{
		case OpenUp.OpenState.BossDown:
		{
			this.PointPos[1].x = Mathf.PerlinNoise(this.DeadBossTransform.position.y, this.DeadBossTransform.position.z) - 0.5f;
			this.PointPos[1].y = Mathf.PerlinNoise(this.DeadBossTransform.position.x, this.DeadBossTransform.position.z) - 0.5f;
			this.PointPos[1].z = Mathf.PerlinNoise(this.DeadBossTransform.position.x, this.DeadBossTransform.position.y) - 0.5f;
			this.DeadBossTransform.position = this.PointPos[0];
			bool flag = this.MoveRun(this.DeadBossTransform, Vector3.up, -10f, this.LinePos.y, OpenUp.OpenState.Count);
			this.PointPos[0] = this.DeadBossTransform.position;
			Transform pawnTransform = this.PawnTransform;
			Vector3 position = this.PointPos[0] + this.PointPos[1] * 3f;
			this.DeadBossTransform.position = position;
			pawnTransform.position = position;
			if (flag)
			{
				this.OpenUpCorpsStage.SetActive(false);
				this.DeadBoss = null;
				this.DeadBossTransform = null;
				this.PawnTransform = null;
			}
			return;
		}
		case OpenUp.OpenState.BossZoom:
			if (!this.DeadBossAnimation.isPlaying)
			{
				this._openState = OpenUp.OpenState.BossDead;
				this.LinePos = this.DeadBossTransform.position;
				this.LinePos.y = this.LinePos.y - this.BossDown;
			}
			return;
		case OpenUp.OpenState.BossDead:
			if (this.MoveRun(this.DeadBossTransform, Vector3.up, -10f, this.LinePos.y, OpenUp.OpenState.BossDown))
			{
				this.DeadBoss.gameObject.SetActive(false);
				this.DeadBoss = this.OpenUpCorpsStage.transform.GetChild(0).gameObject;
				this.DeadBossTransform = this.DeadBoss.transform;
				this.PointPos[0] = (this.LinePos = this.DeadBossTransform.position);
				ParticleManager.Instance.Spawn(310, null, this.LinePos, 1f, true, true, true);
				this.LinePos.y = this.LinePos.y - this.BossDown * 4f;
				this.PawnTransform = this.OpenUpCorpsStage.transform.GetChild(2).transform;
				AudioManager.Instance.PlaySFX(20010, 0f, PitchKind.NoPitch, null, null);
			}
			return;
		}
		DataManager.Instance.lastBattleResult = -1;
		DataManager.msgBuffer[0] = 44;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		DataManager.msgBuffer[0] = 47;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		this._openState = OpenUp.OpenState.Count;
		this.stateUpdateDelegates = null;
		DataManager.msgBuffer[0] = 15;
		DataManager.msgBuffer[1] = 1;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06002181 RID: 8577 RVA: 0x003FED30 File Offset: 0x003FCF30
	private void DareNodusUpdateRun()
	{
		int num = 0;
		if (DataManager.StageDataController.DareNodusUpdatePointID <= 0)
		{
			this._openState = OpenUp.OpenState.Count;
		}
		else
		{
			num = (int)((DataManager.StageDataController.DareNodusUpdatePointID - 1) % GameConstants.StagePointNum[(int)DataManager.StageDataController._stageMode]);
			num /= (int)GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode];
			if (num >= this._BuildSprite.SpriteGameObject.Length)
			{
				this._openState = OpenUp.OpenState.Count;
			}
		}
		OpenUp.OpenState openState = this._openState;
		if (openState != OpenUp.OpenState.BigPointDown)
		{
			if (openState != OpenUp.OpenState.SpriteUp)
			{
				DataManager.StageDataController.DareNodusUpdatePointID = 0;
				this._openState = OpenUp.OpenState.Count;
				this.stateUpdateDelegates = null;
			}
			else if (this.MoveRun(this._BuildSprite.SpriteGameObject[num].transform, Vector3.up, 20f, this.BigPointPos[num].y + this.Spriteoffset, OpenUp.OpenState.Count))
			{
				this._BuildSprite.ShowChallegeEffect(this._BuildSprite.SpriteGameObject[num].transform);
			}
		}
		else if (this.MoveRun(this._BuildSprite.SpriteGameObject[num].transform, Vector3.up, -20f, this.BigPointPos[num].y - this.UpStart, OpenUp.OpenState.SpriteUp))
		{
			this._BuildSprite.UpdateSpriteFrame(num);
			DataManager.msgBuffer[0] = 44;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			DataManager.msgBuffer[0] = 47;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			DataManager.msgBuffer[0] = 43;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x06002182 RID: 8578 RVA: 0x003FEED8 File Offset: 0x003FD0D8
	private void StartInOut(OpenUp.OpenState inoutstate)
	{
		if (inoutstate != OpenUp.OpenState.In)
		{
			if (inoutstate != OpenUp.OpenState.Out)
			{
				return;
			}
			this.InOutSpeed = -200f;
		}
		else
		{
			this.InOutSpeed = 200f;
		}
		this._openState = inoutstate;
		DataManager.msgBuffer[0] = 46;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		DataManager.msgBuffer[0] = 42;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.InOut);
		if (this.InOutParent == null)
		{
			this.InOutParent = new GameObject("InOutParent");
		}
		this.InOutParentTransform = this.InOutParent.transform;
		if (this.InOutSpeed > 0f)
		{
			this.InOutParentTransform.position += Vector3.up * 10f;
		}
		else
		{
			this.InOutParentTransform.position = Vector3.zero;
		}
		this.Line.transform.SetParent(this.InOutParentTransform);
		if (this._BuildSprite != null)
		{
			for (int i = 0; i < this._BuildSprite.SpriteGameObject.Length; i++)
			{
				this._BuildSprite.SpriteGameObject[i].transform.SetParent(this.InOutParentTransform);
			}
		}
		if (this.Point != null)
		{
			for (int j = 0; j < this.Point.Length; j++)
			{
				this.PointTransform[j].SetParent(this.InOutParentTransform);
			}
		}
		if (this.Pawn != null)
		{
			this.PawnTransform.SetParent(this.InOutParentTransform);
		}
		if (this.Boss != null)
		{
			this.BossTransform.SetParent(this.InOutParentTransform);
		}
		for (int k = 0; k < this.BigPoint.Length; k++)
		{
			this.BigPointTransform[k].SetParent(this.InOutParentTransform);
		}
		if (this.Treasure != null)
		{
			this.TreasureTransform.SetParent(this.InOutParentTransform);
		}
		if (this.InOutSpeed > 0f)
		{
			this.InOutParentTransform.position = Vector3.zero;
		}
	}

	// Token: 0x06002183 RID: 8579 RVA: 0x003FF124 File Offset: 0x003FD324
	private void InOut()
	{
		if (this._openState == OpenUp.OpenState.Count)
		{
			this.Line.transform.SetParent(null);
			if (this._BuildSprite != null)
			{
				for (int i = 0; i < this._BuildSprite.SpriteGameObject.Length; i++)
				{
					this._BuildSprite.SpriteGameObject[i].transform.SetParent(null);
				}
			}
			if (this.Point != null)
			{
				for (int j = 0; j < this.Point.Length; j++)
				{
					this.PointTransform[j].SetParent(null);
				}
			}
			if (this.Pawn != null)
			{
				this.PawnTransform.SetParent(null);
			}
			if (this.Boss != null)
			{
				this.BossTransform.SetParent(null);
			}
			for (int k = 0; k < this.BigPoint.Length; k++)
			{
				this.BigPointTransform[k].SetParent(null);
			}
			this.stateUpdateDelegates = null;
			if (this.InOutSpeed < 0f)
			{
				if (this.bupdateChapter)
				{
					DataManager.msgBuffer[0] = 34;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
				else
				{
					DataManager.msgBuffer[0] = 21;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
			}
			this.InOutParentTransform = null;
			DataManager.msgBuffer[0] = 47;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			DataManager.msgBuffer[0] = 43;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			return;
		}
		this.MoveRun(this.InOutParentTransform, Vector3.up, this.InOutSpeed, this.InOutSpeed * 0.05f, OpenUp.OpenState.Count);
	}

	// Token: 0x06002184 RID: 8580 RVA: 0x003FF2CC File Offset: 0x003FD4CC
	protected override void UpdateNext(byte[] meg)
	{
		AssetManager.UnloadAssetBundle(this.LineassetKey, true);
		UnityEngine.Object.Destroy(this.Line);
		AssetManager.UnloadAssetBundle(this.PointassetKey, true);
		if (this.Point != null)
		{
			for (int i = 0; i < this.Point.Length; i++)
			{
				this.PointTransform[i] = null;
				UnityEngine.Object.Destroy(this.Point[i]);
				this.Point[i] = null;
			}
		}
		AssetManager.UnloadAssetBundle(this.BigPointassetKey, true);
		if (this.BigPoint != null)
		{
			for (int j = 0; j < this.BigPoint.Length; j++)
			{
				this.BigPointTransform[j] = null;
				UnityEngine.Object.Destroy(this.BigPoint[j]);
				this.BigPoint[j] = null;
			}
		}
		AssetManager.UnloadAssetBundle(this.BossassetKey, true);
		this.BossTransform = null;
		UnityEngine.Object.Destroy(this.Boss);
		AssetManager.UnloadAssetBundle(this.DeadBossassetKey, true);
		this.DeadBossTransform = null;
		UnityEngine.Object.Destroy(this.DeadBoss);
		AssetManager.UnloadAssetBundle(this.PawnassetKey, true);
		this.PawnTransform = null;
		UnityEngine.Object.Destroy(this.Pawn);
		AssetManager.UnloadAssetBundle(this.TreasureassetKey, true);
		this.TreasureTransform = null;
		UnityEngine.Object.Destroy(this.Treasure);
		if (this._BuildSprite != null)
		{
			this._BuildSprite.Destroy();
		}
		if (this.CanBeSelect != null)
		{
			Array.Clear(this.CanBeSelect, 0, this.CanBeSelect.Length);
		}
		if (this.Select != null)
		{
			Array.Clear(this.Select, 0, this.Select.Length);
		}
		if (this.Halo != null)
		{
			ParticleManager.Instance.DeSpawn(this.Halo);
		}
		this.InOutParentTransform = null;
		UnityEngine.Object.Destroy(this.InOutParent);
		this.Line = null;
		this.Point = null;
		this.BigPoint = null;
		this.Boss = null;
		this.DeadBoss = null;
		this.Pawn = null;
		this._BuildSprite = null;
		this.CanBeSelect = null;
		this.Select = null;
		this.InOutParent = null;
		this.DeadBossAnimation = null;
		this.BossAnimation = null;
		this.Halo = null;
		this.stateUpdateDelegates = null;
		NewbieManager.CheckShowArrow(false, null);
		this.ClearUpdateDelegates();
	}

	// Token: 0x06002185 RID: 8581 RVA: 0x003FF500 File Offset: 0x003FD700
	protected override void UpdateLoad(byte[] meg)
	{
		this.bupdateChapter = false;
		this.Select = new GameObject[1];
		if (DataManager.StageDataController._stageMode == StageMode.Corps)
		{
			this._openState = OpenUp.OpenState.Count;
			this.stateUpdateDelegates = null;
			if (DataManager.StageDataController.isNotFirstInChapter[2] == 0)
			{
				this._openState = OpenUp.OpenState.Wait;
				DataManager.msgBuffer[0] = 47;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				DataManager.msgBuffer[0] = 15;
				DataManager.msgBuffer[1] = 0;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				return;
			}
			if (DataManager.Instance.lastBattleResult > 0)
			{
				DataManager.msgBuffer[0] = 46;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				DataManager.msgBuffer[0] = 42;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				this._openState = OpenUp.OpenState.CorpsWin;
				DataManager.msgBuffer[0] = 45;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			else
			{
				this._openState = OpenUp.OpenState.Corps;
			}
			return;
		}
		else
		{
			if (this.OpenUpCorpsStage != null)
			{
				this.OpenUpCorpsStage.SetActive(false);
			}
			if (this.setOpenState())
			{
				return;
			}
			this.Halo = ParticleManager.Instance.Spawn(51, null, Vector3.zero, 1f, false, false, true);
			Chapter recordByKey = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort)DataManager.StageDataController.currentChapterID);
			for (int i = 0; i < this.PointPos.Length; i++)
			{
				this.PointPos[i] = GameConstants.WordToVector3(recordByKey.PointPos[i].X, recordByKey.PointPos[i].Y, recordByKey.PointPos[i].Z, -100, 0.01f);
			}
			for (int j = 0; j < this.BigPointPos.Length; j++)
			{
				this.BigPointPos[j] = GameConstants.WordToVector3(recordByKey.BigPointPos[j].X, recordByKey.BigPointPos[j].Y, recordByKey.BigPointPos[j].Z, -100, 0.01f);
			}
			switch (this._openState)
			{
			case OpenUp.OpenState.FullWin:
				this.FullWinLoad();
				break;
			case OpenUp.OpenState.LeanWin:
				this.LeanWinLoad();
				break;
			case OpenUp.OpenState.FinalWin:
				this.FinalWinLoad();
				break;
			default:
				this.defaultLoad();
				break;
			}
			return;
		}
	}

	// Token: 0x06002186 RID: 8582 RVA: 0x003FF774 File Offset: 0x003FD974
	protected override void UpdateReady(byte[] meg)
	{
		if (this._openState == OpenUp.OpenState.Wait)
		{
			return;
		}
		switch (this._openState)
		{
		case OpenUp.OpenState.First:
			this.FirstReady();
			break;
		case OpenUp.OpenState.FullWin:
			this.FullWinReady();
			break;
		case OpenUp.OpenState.LeanWin:
			this.LeanWinReady();
			break;
		case OpenUp.OpenState.FinalWin:
			this.FinalWinReady();
			break;
		case OpenUp.OpenState.Corps:
		case OpenUp.OpenState.CorpsWin:
			this.CorpsReady();
			break;
		default:
			this.defaultReady();
			GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
			break;
		}
	}

	// Token: 0x06002187 RID: 8583 RVA: 0x003FF810 File Offset: 0x003FDA10
	protected override void UpdateRun(byte[] meg)
	{
		if (this.stateUpdateDelegates != null)
		{
			this.stateUpdateDelegates();
		}
		if (this.BossAnimation != null)
		{
			this.BossAnimationTime -= Time.deltaTime;
			if (this.BossAnimationTime < 0f)
			{
				int num = (int)(UnityEngine.Random.value * 10f);
				if (num % 4 == 0)
				{
					this.BossAnimationTime = this.BossAnimation["victory"].length;
					this.BossAnimation.CrossFade("victory", 0.3f);
				}
				else
				{
					this.BossAnimationTime = this.BossAnimation["idle"].length;
					this.BossAnimation.CrossFade("idle", 0.3f);
				}
			}
		}
	}

	// Token: 0x06002188 RID: 8584 RVA: 0x003FF8E4 File Offset: 0x003FDAE4
	protected override void UpdateNews(byte[] meg)
	{
		switch (meg[0])
		{
		case 0:
		{
			Vector2 touch = new Vector2(GameConstants.ConvertBytesToFloat(meg, 1), GameConstants.ConvertBytesToFloat(meg, 5));
			this.Select[0] = null;
			if (this.CanBeSelect != null)
			{
				this.Select[0] = GameConstants.GameObjectPick(touch, this.CanBeSelect, typeof(Renderer), false);
			}
			break;
		}
		case 1:
			if (this.Select[0] != null)
			{
				Vector2 touch = new Vector2(GameConstants.ConvertBytesToFloat(meg, 1), GameConstants.ConvertBytesToFloat(meg, 5));
				this.Select[0] = GameConstants.GameObjectPick(touch, this.Select, typeof(Renderer), false);
				if (this.Select[0] != null)
				{
					if (DataManager.StageDataController._stageMode == StageMode.Corps)
					{
						DataManager.msgBuffer[0] = 18;
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						this.Select[0] = null;
						return;
					}
					AudioManager.Instance.PlayUISFX(UIKind.Normal);
					if (this.Select[0] == this.Treasure)
					{
						this.Select[0] = null;
						DataManager.msgBuffer[0] = 38;
						DataManager.msgBuffer[1] = 0;
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						return;
					}
					SpriteRenderer component = this.Select[0].transform.GetChild(0).GetComponent<SpriteRenderer>();
					if (component != null)
					{
						ushort num = 0;
						while ((int)num < this._BuildSprite.SpriteGameObject.Length)
						{
							if (this.Select[0] == this._BuildSprite.SpriteGameObject[(int)num])
							{
								int num2 = (int)((ushort)((DataManager.StageDataController.currentChapterID - 1) * 6) + num + 1);
								num2 *= (int)GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode];
								DataManager.StageDataController.currentPointID = (ushort)num2;
								DataManager.StageDataController.SaveUserStage(DataManager.StageDataController._stageMode);
								break;
							}
							num += 1;
						}
					}
					else
					{
						if (DataManager.StageDataController._stageMode == StageMode.Lean && (DataManager.StageDataController.StageRecord[1] + 1) * 3 > DataManager.StageDataController.StageRecord[0])
						{
							GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1593u), 255, true);
							this.Select[0] = null;
							return;
						}
						DataManager.StageDataController.resetCurrentPointIDwithStageRecord();
					}
					DataManager.msgBuffer[0] = 17;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
			}
			this.Select[0] = null;
			break;
		case 2:
			if (DataManager.StageDataController._stageMode == StageMode.Corps)
			{
				DataManager.msgBuffer[0] = 21;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			else
			{
				this.StartInOut(OpenUp.OpenState.Out);
			}
			break;
		case 3:
			this.StartInOut(OpenUp.OpenState.In);
			break;
		case 4:
			switch (this._openState)
			{
			case OpenUp.OpenState.First:
			{
				this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.FirstRun);
				byte lineID = this.LineID;
				this.Line.transform.position = this.LinePos;
				Animation component2 = this.Line.GetComponent<Animation>();
				component2.Play(lineID.ToString());
				if (this.Point != null)
				{
					this._openState = OpenUp.OpenState.FirstPointDown;
					this.Point[1].SetActive(true);
				}
				else
				{
					if (this.Pawn != null)
					{
						this.BigPoint[(int)lineID].SetActive(true);
					}
					this._openState = OpenUp.OpenState.BigPointDown;
				}
				goto IL_6A3;
			}
			case OpenUp.OpenState.FullWin:
				this._openState = OpenUp.OpenState.FirstPointDown;
				this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.FullWinRun);
				goto IL_6A3;
			case OpenUp.OpenState.LeanWin:
				this._openState = OpenUp.OpenState.BossZoom;
				this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.LeanWinRun);
				if (this.DeadBoss != null)
				{
					this.DeadBossAnimation.wrapMode = WrapMode.Once;
					this.DeadBossAnimation.Play("die");
				}
				goto IL_6A3;
			case OpenUp.OpenState.FinalWin:
				this._openState = OpenUp.OpenState.BossZoom;
				this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.FinalWinRun);
				if (this.DeadBoss != null)
				{
					this.DeadBossAnimation.wrapMode = WrapMode.Once;
					this.DeadBossAnimation.Play("die");
				}
				goto IL_6A3;
			case OpenUp.OpenState.CorpsWin:
				this._openState = OpenUp.OpenState.BossZoom;
				this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.CorpsWinRun);
				if (this.OpenUpCorpsStage != null)
				{
					this.DeadBossAnimation.wrapMode = WrapMode.Once;
					this.DeadBossAnimation.Play("die");
					CorpsStage recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(DataManager.StageDataController.StageRecord[2]);
					Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey.Heros[0].HeroID);
					AudioManager.Instance.PlaySFX(recordByKey2.DyingSound, 0f, PitchKind.SpeechSound, null, null);
					Vector3 vector = Camera.main.WorldToViewportPoint(this.OpenUpCorpsStage.transform.position);
					int num3 = 0;
					GUIManager instance = GUIManager.Instance;
					Array.Clear(instance.SE_Kind, 0, instance.SE_Kind.Length);
					instance.SE_Kind[num3] = SpeciallyEffect_Kind.LeadExp;
					num3++;
					instance.SE_Kind[num3] = SpeciallyEffect_Kind.HeroExp;
					num3++;
					Array.Clear(instance.SE_ItemID, 0, instance.SE_ItemID.Length);
					instance.mStartV2 = new Vector2(instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x * vector.x, instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.y * vector.y);
					instance.m_SpeciallyEffect.AddIconShow(instance.mStartV2, instance.SE_Kind, instance.SE_ItemID, true);
				}
				goto IL_6A3;
			}
			if (DataManager.StageDataController.DareNodusUpdatePointID > 0)
			{
				if (DataManager.StageDataController._stageMode == StageMode.Dare && DataManager.StageDataController.DareNodusUpdatePointID == DataManager.StageDataController.currentPointID && this._BuildSprite != null)
				{
					this._openState = OpenUp.OpenState.BigPointDown;
					this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.DareNodusUpdateRun);
				}
				else
				{
					DataManager.StageDataController.DareNodusUpdatePointID = 0;
				}
			}
			NewbieManager.CheckShowArrow(true, this.Halo);
			IL_6A3:
			break;
		case 6:
			this.bupdateChapter = true;
			this.StartInOut(OpenUp.OpenState.Out);
			break;
		case 8:
			if (this._BuildSprite != null)
			{
				this._BuildSprite.Hide();
			}
			break;
		case 13:
			DataManager.msgBuffer[0] = 45;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			this.stateUpdateDelegates = new OpenUp.StateUpdateDelegate(this.FirstRun);
			break;
		}
	}

	// Token: 0x040069D3 RID: 27091
	private const ushort HaloID = 51;

	// Token: 0x040069D4 RID: 27092
	private const ushort CastleDestroyEffID = 310;

	// Token: 0x040069D5 RID: 27093
	private GameObject OpenUpCorpsStage;

	// Token: 0x040069D6 RID: 27094
	private GameObject Line;

	// Token: 0x040069D7 RID: 27095
	private GameObject[] BigPoint;

	// Token: 0x040069D8 RID: 27096
	private GameObject[] Point;

	// Token: 0x040069D9 RID: 27097
	private GameObject Boss;

	// Token: 0x040069DA RID: 27098
	private GameObject DeadBoss;

	// Token: 0x040069DB RID: 27099
	private GameObject Pawn;

	// Token: 0x040069DC RID: 27100
	private GameObject[] CanBeSelect;

	// Token: 0x040069DD RID: 27101
	private GameObject[] Select;

	// Token: 0x040069DE RID: 27102
	private GameObject Halo;

	// Token: 0x040069DF RID: 27103
	private GameObject InOutParent;

	// Token: 0x040069E0 RID: 27104
	private GameObject Treasure;

	// Token: 0x040069E1 RID: 27105
	private MapSprite _BuildSprite;

	// Token: 0x040069E2 RID: 27106
	private Animation BossAnimation;

	// Token: 0x040069E3 RID: 27107
	private Animation DeadBossAnimation;

	// Token: 0x040069E4 RID: 27108
	private Transform[] BigPointTransform;

	// Token: 0x040069E5 RID: 27109
	private Transform[] PointTransform;

	// Token: 0x040069E6 RID: 27110
	private Transform BossTransform;

	// Token: 0x040069E7 RID: 27111
	private Transform DeadBossTransform;

	// Token: 0x040069E8 RID: 27112
	private Transform PawnTransform;

	// Token: 0x040069E9 RID: 27113
	private Transform InOutParentTransform;

	// Token: 0x040069EA RID: 27114
	private Transform TreasureTransform;

	// Token: 0x040069EB RID: 27115
	private OpenUp.OpenState _openState;

	// Token: 0x040069EC RID: 27116
	private OpenUp.StateUpdateDelegate stateUpdateDelegates;

	// Token: 0x040069ED RID: 27117
	private float Bossoffset = 1.25f;

	// Token: 0x040069EE RID: 27118
	private float Bossscale = 4f;

	// Token: 0x040069EF RID: 27119
	private float BossDown = 6f;

	// Token: 0x040069F0 RID: 27120
	private float Spriteoffset = 5.25f;

	// Token: 0x040069F1 RID: 27121
	private float Pawnoffset = 2f;

	// Token: 0x040069F2 RID: 27122
	private float Pawnscale = 4f;

	// Token: 0x040069F3 RID: 27123
	private float PointDown = 2f;

	// Token: 0x040069F4 RID: 27124
	private float FallStart = 55f;

	// Token: 0x040069F5 RID: 27125
	private float UpStart = 10f;

	// Token: 0x040069F6 RID: 27126
	private float InOutSpeed = 10f;

	// Token: 0x040069F7 RID: 27127
	private float BossAnimationTime;

	// Token: 0x040069F8 RID: 27128
	private float Treasurescale = 26f;

	// Token: 0x040069F9 RID: 27129
	private float Treasureoffset = 0.25f;

	// Token: 0x040069FA RID: 27130
	private int BossassetKey;

	// Token: 0x040069FB RID: 27131
	private int DeadBossassetKey;

	// Token: 0x040069FC RID: 27132
	private int PawnassetKey;

	// Token: 0x040069FD RID: 27133
	private int LineassetKey;

	// Token: 0x040069FE RID: 27134
	private int PointassetKey;

	// Token: 0x040069FF RID: 27135
	private int BigPointassetKey;

	// Token: 0x04006A00 RID: 27136
	private int TreasureassetKey;

	// Token: 0x04006A01 RID: 27137
	private bool bupdateChapter;

	// Token: 0x04006A02 RID: 27138
	private Vector3[] PointPos = new Vector3[12];

	// Token: 0x04006A03 RID: 27139
	private Vector3[] BigPointPos = new Vector3[6];

	// Token: 0x04006A04 RID: 27140
	private Vector3 LinePos = new Vector3(0f, 0f, 0f);

	// Token: 0x020006DC RID: 1756
	private enum OpenState : byte
	{
		// Token: 0x04006A06 RID: 27142
		First,
		// Token: 0x04006A07 RID: 27143
		FullWin,
		// Token: 0x04006A08 RID: 27144
		LeanWin,
		// Token: 0x04006A09 RID: 27145
		FinalWin,
		// Token: 0x04006A0A RID: 27146
		Corps,
		// Token: 0x04006A0B RID: 27147
		CorpsWin,
		// Token: 0x04006A0C RID: 27148
		Wait,
		// Token: 0x04006A0D RID: 27149
		BigPointDown,
		// Token: 0x04006A0E RID: 27150
		FirstPointDown,
		// Token: 0x04006A0F RID: 27151
		SecPointDown,
		// Token: 0x04006A10 RID: 27152
		BossDown,
		// Token: 0x04006A11 RID: 27153
		PawnDown,
		// Token: 0x04006A12 RID: 27154
		PawnTurn,
		// Token: 0x04006A13 RID: 27155
		PawnMove,
		// Token: 0x04006A14 RID: 27156
		BossZoom,
		// Token: 0x04006A15 RID: 27157
		BossDead,
		// Token: 0x04006A16 RID: 27158
		SpriteUp,
		// Token: 0x04006A17 RID: 27159
		LineUp,
		// Token: 0x04006A18 RID: 27160
		ShowSpriteStar,
		// Token: 0x04006A19 RID: 27161
		In,
		// Token: 0x04006A1A RID: 27162
		Out,
		// Token: 0x04006A1B RID: 27163
		Count
	}

	// Token: 0x02000893 RID: 2195
	// (Invoke) Token: 0x06002D94 RID: 11668
	private delegate void StateUpdateDelegate();
}
