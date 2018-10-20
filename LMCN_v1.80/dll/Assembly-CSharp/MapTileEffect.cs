using System;
using UnityEngine;

// Token: 0x02000260 RID: 608
public class MapTileEffect
{
	// Token: 0x06000B3A RID: 2874 RVA: 0x000F35B0 File Offset: 0x000F17B0
	public MapTileEffect(Transform realmGroup, float tileBaseScale)
	{
		GameObject gameObject = new GameObject("MapTileEffect");
		this.EffectLayoutTransform = gameObject.transform;
		this.RealmGroup = realmGroup;
		this.EffectLayoutTransform.localScale = Vector3.one * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
		this.EffectLayoutTransform.position = Vector3.forward * 2950f * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
		this.EffectLayoutTransform.SetParent(realmGroup, false);
		gameObject = new GameObject("MapTileEffectWin");
		this.WinLayoutTransform = gameObject.transform;
		this.WinLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		gameObject = new GameObject("MapTileEffectLose");
		this.LoseLayoutTransform = gameObject.transform;
		this.LoseLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		gameObject = new GameObject("MapTileEffectShield");
		this.ShieldLayoutTransform = gameObject.transform;
		this.ShieldLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		gameObject = new GameObject("MapTileEffectConvey");
		this.ConveyLayoutTransform = gameObject.transform;
		this.ConveyLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		gameObject = new GameObject("MapTileEffectYolk");
		this.YolkLayoutTransform = gameObject.transform;
		this.YolkLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		gameObject = new GameObject("MapTileEffectEnemyLose");
		this.EnemyLoseLayoutTransform = gameObject.transform;
		this.EnemyLoseLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		gameObject = new GameObject("MapTileEffectNPCCityConvey");
		this.NPCCityConveyLayoutTransform = gameObject.transform;
		this.NPCCityConveyLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		gameObject = new GameObject("MapTileEffectMapWeaponHurt");
		this.MapWeaponHurtLayoutTransform = gameObject.transform;
		this.MapWeaponHurtLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		gameObject = new GameObject("MapTileEffectBallDown");
		this.BallDownLayoutTransform = gameObject.transform;
		this.BallDownLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		gameObject = new GameObject("MapTileEffectBallBigYolk");
		this.BallBigYolkLayoutTransform = gameObject.transform;
		this.BallBigYolkLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		gameObject = new GameObject("MapTileEffectBallYolk");
		this.BallYolkLayoutTransform = gameObject.transform;
		this.BallYolkLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		gameObject = new GameObject("MapTileEffectBallNPCCity");
		this.BallNPCCityLayoutTransform = gameObject.transform;
		this.BallNPCCityLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		gameObject = new GameObject("MapTileEffectBallOut");
		this.BallOutLayoutTransform = gameObject.transform;
		this.BallOutLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		gameObject = new GameObject("MapTileEffectBallKick");
		this.BallKickLayoutTransform = gameObject.transform;
		this.BallKickLayoutTransform.SetParent(this.EffectLayoutTransform, false);
		this.WinpoolsCounter = (this.LosepoolsCounter = (this.ShieldpoolsCounter = (this.ConveypoolsCounter = (this.EnemyLosepoolsCounter = (this.NPCCityConveypoolsCounter = (this.MapWeaponHurtpoolsCounter = (this.BallDownpoolsCounter = (this.BallBigYolkpoolsCounter = (this.BallYolkpoolsCounter = (this.BallNPCCitypoolsCounter = (this.BallOutpoolsCounter = (this.BallKickpoolsCounter = 0))))))))))));
	}

	// Token: 0x06000B3B RID: 2875 RVA: 0x000F3938 File Offset: 0x000F1B38
	public void OnDestroy()
	{
		if (this.EffectWinGameObject != null)
		{
			for (int i = 0; i < this.EffectWinGameObject.Length; i++)
			{
				for (int j = 0; j < this.EffectWinGameObject[i].Length; j++)
				{
					if (this.EffectWinGameObject[i][j] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectWinGameObject[i][j]);
						this.EffectWinGameObject[i][j] = null;
						this.EffectWinTransform[i][j] = null;
						this.EffectWinParticle[i][j] = null;
					}
				}
				this.EffectWinGameObject[i] = null;
				this.EffectWinTransform[i] = null;
				this.EffectWinParticle[i] = null;
			}
		}
		this.EffectWinGameObject = null;
		this.EffectWinTransform = null;
		this.EffectWinParticle = null;
		if (this.EffectLoseGameObject != null)
		{
			for (int k = 0; k < this.EffectLoseGameObject.Length; k++)
			{
				for (int l = 0; l < this.EffectLoseGameObject[k].Length; l++)
				{
					if (this.EffectLoseGameObject[k][l] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectLoseGameObject[k][l]);
						this.EffectLoseGameObject[k][l] = null;
						this.EffectLoseTransform[k][l] = null;
						this.EffectLoseParticle[k][l] = null;
					}
				}
				this.EffectLoseGameObject[k] = null;
				this.EffectLoseTransform[k] = null;
				this.EffectLoseParticle[k] = null;
			}
		}
		this.EffectLoseGameObject = null;
		this.EffectLoseTransform = null;
		this.EffectLoseParticle = null;
		if (this.EffectEnemyLoseGameObject != null)
		{
			for (int m = 0; m < this.EffectEnemyLoseGameObject.Length; m++)
			{
				for (int n = 0; n < this.EffectEnemyLoseGameObject[m].Length; n++)
				{
					if (this.EffectEnemyLoseGameObject[m][n] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectEnemyLoseGameObject[m][n]);
						this.EffectEnemyLoseGameObject[m][n] = null;
						this.EffectEnemyLoseTransform[m][n] = null;
						this.EffectEnemyLoseParticle[m][n] = null;
					}
				}
				this.EffectEnemyLoseGameObject[m] = null;
				this.EffectEnemyLoseTransform[m] = null;
				this.EffectEnemyLoseParticle[m] = null;
			}
		}
		this.EffectEnemyLoseGameObject = null;
		this.EffectEnemyLoseTransform = null;
		this.EffectEnemyLoseParticle = null;
		if (this.EffectShieldGameObject != null)
		{
			for (int num = 0; num < this.EffectShieldGameObject.Length; num++)
			{
				for (int num2 = 0; num2 < this.EffectShieldGameObject[num].Length; num2++)
				{
					if (this.EffectShieldGameObject[num][num2] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectShieldGameObject[num][num2]);
						this.EffectShieldGameObject[num][num2] = null;
						this.EffectShieldTransform[num][num2] = null;
						this.EffectShieldParticle[num][num2] = null;
						this.EffectShieldParticle_one[num][num2] = null;
					}
				}
				this.EffectShieldGameObject[num] = null;
				this.EffectShieldTransform[num] = null;
				this.EffectShieldParticle[num] = null;
				this.EffectShieldParticle_one[num] = null;
			}
		}
		this.EffectShieldGameObject = null;
		this.EffectShieldTransform = null;
		this.EffectShieldParticle = null;
		this.EffectShieldParticle_one = null;
		if (this.EffectConveyGameObject != null)
		{
			for (int num3 = 0; num3 < this.EffectConveyGameObject.Length; num3++)
			{
				for (int num4 = 0; num4 < this.EffectConveyGameObject[num3].Length; num4++)
				{
					if (this.EffectConveyGameObject[num3][num4] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectConveyGameObject[num3][num4]);
						this.EffectConveyGameObject[num3][num4] = null;
						this.EffectConveyTransform[num3][num4] = null;
						this.EffectConveyParticle[num3][num4] = null;
						this.EffectConveyParticle_one[num3][num4] = null;
						this.EffectConveyParticle_two[num3][num4] = null;
						this.EffectConveyParticle_thr[num3][num4] = null;
					}
				}
				this.EffectConveyGameObject[num3] = null;
				this.EffectConveyTransform[num3] = null;
				this.EffectConveyParticle[num3] = null;
				this.EffectConveyParticle_one[num3] = null;
				this.EffectConveyParticle_two[num3] = null;
				this.EffectConveyParticle_thr[num3] = null;
			}
		}
		this.EffectConveyGameObject = null;
		this.EffectConveyTransform = null;
		this.EffectConveyParticle = null;
		this.EffectConveyParticle_one = null;
		this.EffectConveyParticle_two = null;
		this.EffectConveyParticle_thr = null;
		if (this.EffectNPCCityConveyGameObject != null)
		{
			for (int num5 = 0; num5 < this.EffectNPCCityConveyGameObject.Length; num5++)
			{
				for (int num6 = 0; num6 < this.EffectNPCCityConveyGameObject[num5].Length; num6++)
				{
					if (this.EffectNPCCityConveyGameObject[num5][num6] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectNPCCityConveyGameObject[num5][num6]);
						this.EffectNPCCityConveyGameObject[num5][num6] = null;
						this.EffectNPCCityConveyTransform[num5][num6] = null;
						this.EffectNPCCityConveyParticle[num5][num6] = null;
						this.EffectNPCCityConveyParticle_one[num5][num6] = null;
						this.EffectNPCCityConveyParticle_two[num5][num6] = null;
						this.EffectNPCCityConveyParticle_thr[num5][num6] = null;
					}
				}
				this.EffectNPCCityConveyGameObject[num5] = null;
				this.EffectNPCCityConveyTransform[num5] = null;
				this.EffectNPCCityConveyParticle[num5] = null;
				this.EffectNPCCityConveyParticle_one[num5] = null;
				this.EffectNPCCityConveyParticle_two[num5] = null;
				this.EffectNPCCityConveyParticle_thr[num5] = null;
			}
		}
		this.EffectNPCCityConveyGameObject = null;
		this.EffectNPCCityConveyTransform = null;
		this.EffectNPCCityConveyParticle = null;
		this.EffectNPCCityConveyParticle_one = null;
		this.EffectNPCCityConveyParticle_two = null;
		this.EffectNPCCityConveyParticle_thr = null;
		if (this.EffectMapWeaponHurtGameObject != null)
		{
			for (int num7 = 0; num7 < this.EffectMapWeaponHurtGameObject.Length; num7++)
			{
				for (int num8 = 0; num8 < this.EffectMapWeaponHurtGameObject[num7].Length; num8++)
				{
					if (this.EffectMapWeaponHurtGameObject[num7][num8] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectMapWeaponHurtGameObject[num7][num8]);
						this.EffectMapWeaponHurtGameObject[num7][num8] = null;
						this.EffectMapWeaponHurtTransform[num7][num8] = null;
						for (int num9 = 0; num9 < this.EffectMapWeaponHurtParticle.Length; num9++)
						{
							this.EffectMapWeaponHurtParticle[num9][num7][num8] = null;
						}
					}
				}
				this.EffectMapWeaponHurtGameObject[num7] = null;
				this.EffectMapWeaponHurtTransform[num7] = null;
				for (int num10 = 0; num10 < this.EffectMapWeaponHurtParticle.Length; num10++)
				{
					this.EffectMapWeaponHurtParticle[num10][num7] = null;
				}
			}
		}
		this.EffectMapWeaponHurtGameObject = null;
		this.EffectMapWeaponHurtTransform = null;
		for (int num11 = 0; num11 < this.EffectMapWeaponHurtParticle.Length; num11++)
		{
			this.EffectMapWeaponHurtParticle[num11] = null;
		}
		this.EffectMapWeaponHurtParticle = null;
		if (this.EffectBallDownGameObject != null)
		{
			for (int num12 = 0; num12 < this.EffectBallDownGameObject.Length; num12++)
			{
				for (int num13 = 0; num13 < this.EffectBallDownGameObject[num12].Length; num13++)
				{
					if (this.EffectBallDownGameObject[num12][num13] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectBallDownGameObject[num12][num13]);
						this.EffectBallDownGameObject[num12][num13] = null;
						this.EffectBallDownTransform[num12][num13] = null;
						for (int num14 = 0; num14 < this.EffectBallDownParticle.Length; num14++)
						{
							this.EffectBallDownParticle[num14][num12][num13] = null;
						}
					}
				}
				this.EffectBallDownGameObject[num12] = null;
				this.EffectBallDownTransform[num12] = null;
				for (int num15 = 0; num15 < this.EffectBallDownParticle.Length; num15++)
				{
					this.EffectBallDownParticle[num15][num12] = null;
				}
			}
		}
		this.EffectBallDownGameObject = null;
		this.EffectBallDownTransform = null;
		for (int num16 = 0; num16 < this.EffectBallDownParticle.Length; num16++)
		{
			this.EffectBallDownParticle[num16] = null;
		}
		this.EffectBallDownParticle = null;
		if (this.EffectBallBigYolkGameObject != null)
		{
			for (int num17 = 0; num17 < this.EffectBallBigYolkGameObject.Length; num17++)
			{
				for (int num18 = 0; num18 < this.EffectBallBigYolkGameObject[num17].Length; num18++)
				{
					if (this.EffectBallBigYolkGameObject[num17][num18] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectBallBigYolkGameObject[num17][num18]);
						this.EffectBallBigYolkGameObject[num17][num18] = null;
						this.EffectBallBigYolkTransform[num17][num18] = null;
						for (int num19 = 0; num19 < this.EffectBallBigYolkParticle.Length; num19++)
						{
							this.EffectBallBigYolkParticle[num19][num17][num18] = null;
						}
					}
				}
				this.EffectBallBigYolkGameObject[num17] = null;
				this.EffectBallBigYolkTransform[num17] = null;
				for (int num20 = 0; num20 < this.EffectBallBigYolkParticle.Length; num20++)
				{
					this.EffectBallBigYolkParticle[num20][num17] = null;
				}
			}
		}
		this.EffectBallBigYolkGameObject = null;
		this.EffectBallBigYolkTransform = null;
		for (int num21 = 0; num21 < this.EffectBallBigYolkParticle.Length; num21++)
		{
			this.EffectBallBigYolkParticle[num21] = null;
		}
		this.EffectBallBigYolkParticle = null;
		if (this.EffectBallYolkGameObject != null)
		{
			for (int num22 = 0; num22 < this.EffectBallYolkGameObject.Length; num22++)
			{
				for (int num23 = 0; num23 < this.EffectBallYolkGameObject[num22].Length; num23++)
				{
					if (this.EffectBallYolkGameObject[num22][num23] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectBallYolkGameObject[num22][num23]);
						this.EffectBallYolkGameObject[num22][num23] = null;
						this.EffectBallYolkTransform[num22][num23] = null;
						for (int num24 = 0; num24 < this.EffectBallYolkParticle.Length; num24++)
						{
							this.EffectBallYolkParticle[num24][num22][num23] = null;
						}
					}
				}
				this.EffectBallYolkGameObject[num22] = null;
				this.EffectBallYolkTransform[num22] = null;
				for (int num25 = 0; num25 < this.EffectBallYolkParticle.Length; num25++)
				{
					this.EffectBallYolkParticle[num25][num22] = null;
				}
			}
		}
		this.EffectBallYolkGameObject = null;
		this.EffectBallYolkTransform = null;
		for (int num26 = 0; num26 < this.EffectBallYolkParticle.Length; num26++)
		{
			this.EffectBallYolkParticle[num26] = null;
		}
		this.EffectBallYolkParticle = null;
		if (this.EffectBallNPCCityGameObject != null)
		{
			for (int num27 = 0; num27 < this.EffectBallNPCCityGameObject.Length; num27++)
			{
				for (int num28 = 0; num28 < this.EffectBallNPCCityGameObject[num27].Length; num28++)
				{
					if (this.EffectBallNPCCityGameObject[num27][num28] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectBallNPCCityGameObject[num27][num28]);
						this.EffectBallNPCCityGameObject[num27][num28] = null;
						this.EffectBallNPCCityTransform[num27][num28] = null;
						for (int num29 = 0; num29 < this.EffectBallNPCCityParticle.Length; num29++)
						{
							this.EffectBallNPCCityParticle[num29][num27][num28] = null;
						}
					}
				}
				this.EffectBallNPCCityGameObject[num27] = null;
				this.EffectBallNPCCityTransform[num27] = null;
				for (int num30 = 0; num30 < this.EffectBallNPCCityParticle.Length; num30++)
				{
					this.EffectBallNPCCityParticle[num30][num27] = null;
				}
			}
		}
		this.EffectBallNPCCityGameObject = null;
		this.EffectBallNPCCityTransform = null;
		for (int num31 = 0; num31 < this.EffectBallNPCCityParticle.Length; num31++)
		{
			this.EffectBallNPCCityParticle[num31] = null;
		}
		this.EffectBallNPCCityParticle = null;
		if (this.EffectBallOutGameObject != null)
		{
			for (int num32 = 0; num32 < this.EffectBallOutGameObject.Length; num32++)
			{
				for (int num33 = 0; num33 < this.EffectBallOutGameObject[num32].Length; num33++)
				{
					if (this.EffectBallOutGameObject[num32][num33] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectBallOutGameObject[num32][num33]);
						this.EffectBallOutGameObject[num32][num33] = null;
						this.EffectBallOutTransform[num32][num33] = null;
						for (int num34 = 0; num34 < this.EffectBallOutParticle.Length; num34++)
						{
							this.EffectBallOutParticle[num34][num32][num33] = null;
						}
					}
				}
				this.EffectBallOutGameObject[num32] = null;
				this.EffectBallOutTransform[num32] = null;
				for (int num35 = 0; num35 < this.EffectBallOutParticle.Length; num35++)
				{
					this.EffectBallOutParticle[num35][num32] = null;
				}
			}
		}
		this.EffectBallOutGameObject = null;
		this.EffectBallOutTransform = null;
		for (int num36 = 0; num36 < this.EffectBallOutParticle.Length; num36++)
		{
			this.EffectBallOutParticle[num36] = null;
		}
		this.EffectBallOutParticle = null;
		if (this.EffectBallKickGameObject != null)
		{
			for (int num37 = 0; num37 < this.EffectBallKickGameObject.Length; num37++)
			{
				for (int num38 = 0; num38 < this.EffectBallKickGameObject[num37].Length; num38++)
				{
					if (this.EffectBallKickGameObject[num37][num38] != null)
					{
						ParticleManager.Instance.DeSpawn(this.EffectBallKickGameObject[num37][num38]);
						this.EffectBallKickGameObject[num37][num38] = null;
						this.EffectBallKickTransform[num37][num38] = null;
						for (int num39 = 0; num39 < this.EffectBallKickParticle.Length; num39++)
						{
							this.EffectBallKickParticle[num39][num37][num38] = null;
						}
					}
				}
				this.EffectBallKickGameObject[num37] = null;
				this.EffectBallKickTransform[num37] = null;
				for (int num40 = 0; num40 < this.EffectBallKickParticle.Length; num40++)
				{
					this.EffectBallKickParticle[num40][num37] = null;
				}
			}
		}
		this.EffectBallKickGameObject = null;
		this.EffectBallKickTransform = null;
		for (int num41 = 0; num41 < this.EffectBallKickParticle.Length; num41++)
		{
			this.EffectBallKickParticle[num41] = null;
		}
		this.EffectBallKickParticle = null;
		if (this.EffectWinGameObjectPools != null)
		{
			for (int num42 = 0; num42 < this.EffectWinGameObjectPools.Length; num42++)
			{
				if (this.EffectWinGameObjectPools[num42] != null)
				{
					for (int num43 = 0; num43 < this.EffectWinGameObjectPools[num42].Length; num43++)
					{
						if (this.EffectWinGameObjectPools[num42][num43] != null)
						{
							ParticleManager.Instance.DeSpawn(this.EffectWinGameObjectPools[num42][num43]);
							this.EffectWinGameObjectPools[num42][num43] = null;
							this.EffectWinTransformPools[num42][num43] = null;
							this.EffectWinParticlePools[num42][num43] = null;
						}
					}
					this.EffectWinGameObjectPools[num42] = null;
					this.EffectWinTransformPools[num42] = null;
					this.EffectWinParticlePools[num42] = null;
				}
			}
		}
		this.EffectWinGameObjectPools = null;
		this.EffectWinTransformPools = null;
		this.EffectWinParticlePools = null;
		if (this.EffectLoseGameObjectPools != null)
		{
			for (int num44 = 0; num44 < this.EffectLoseGameObjectPools.Length; num44++)
			{
				if (this.EffectLoseGameObjectPools[num44] != null)
				{
					for (int num45 = 0; num45 < this.EffectLoseGameObjectPools[num44].Length; num45++)
					{
						if (this.EffectLoseGameObjectPools[num44][num45] != null)
						{
							ParticleManager.Instance.DeSpawn(this.EffectLoseGameObjectPools[num44][num45]);
							this.EffectLoseGameObjectPools[num44][num45] = null;
							this.EffectLoseTransformPools[num44][num45] = null;
							this.EffectLoseParticlePools[num44][num45] = null;
						}
					}
					this.EffectLoseGameObjectPools[num44] = null;
					this.EffectLoseTransformPools[num44] = null;
					this.EffectLoseParticlePools[num44] = null;
				}
			}
		}
		this.EffectLoseGameObjectPools = null;
		this.EffectLoseTransformPools = null;
		this.EffectLoseParticlePools = null;
		if (this.EffectShieldGameObjectPools != null)
		{
			for (int num46 = 0; num46 < this.EffectShieldGameObjectPools.Length; num46++)
			{
				if (this.EffectShieldTransformPools[num46] != null)
				{
					for (int num47 = 0; num47 < this.EffectShieldGameObjectPools[num46].Length; num47++)
					{
						if (this.EffectShieldGameObjectPools[num46][num47] != null)
						{
							ParticleManager.Instance.DeSpawn(this.EffectShieldGameObjectPools[num46][num47]);
							this.EffectShieldGameObjectPools[num46][num47] = null;
							this.EffectShieldTransformPools[num46][num47] = null;
							this.EffectShieldParticlePools[num46][num47] = null;
							this.EffectShieldParticlePools_one[num46][num47] = null;
						}
					}
					this.EffectShieldGameObjectPools[num46] = null;
					this.EffectShieldTransformPools[num46] = null;
					this.EffectShieldParticlePools[num46] = null;
					this.EffectShieldParticlePools_one[num46] = null;
				}
			}
		}
		this.EffectShieldGameObjectPools = null;
		this.EffectShieldTransformPools = null;
		this.EffectShieldParticlePools = null;
		this.EffectShieldParticlePools_one = null;
		if (this.EffectConveyGameObjectPools != null)
		{
			for (int num48 = 0; num48 < this.EffectConveyGameObjectPools.Length; num48++)
			{
				if (this.EffectConveyGameObjectPools[num48] != null)
				{
					for (int num49 = 0; num49 < this.EffectConveyGameObjectPools[num48].Length; num49++)
					{
						if (this.EffectConveyGameObjectPools[num48][num49] != null)
						{
							ParticleManager.Instance.DeSpawn(this.EffectConveyGameObjectPools[num48][num49]);
							this.EffectConveyGameObjectPools[num48][num49] = null;
							this.EffectConveyTransformPools[num48][num49] = null;
							this.EffectConveyParticlePools[num48][num49] = null;
							this.EffectConveyParticlePools_one[num48][num49] = null;
							this.EffectConveyParticlePools_two[num48][num49] = null;
							this.EffectConveyParticlePools_thr[num48][num49] = null;
						}
					}
					this.EffectConveyGameObjectPools[num48] = null;
					this.EffectConveyTransformPools[num48] = null;
					this.EffectConveyParticlePools[num48] = null;
					this.EffectConveyParticlePools_one[num48] = null;
					this.EffectConveyParticlePools_two[num48] = null;
					this.EffectConveyParticlePools_thr[num48] = null;
				}
			}
		}
		this.EffectConveyGameObjectPools = null;
		this.EffectConveyTransformPools = null;
		this.EffectConveyParticlePools = null;
		this.EffectConveyParticlePools_one = null;
		this.EffectConveyParticlePools_two = null;
		this.EffectConveyParticlePools_thr = null;
		if (this.EffectNPCCityConveyGameObjectPools != null)
		{
			for (int num50 = 0; num50 < this.EffectNPCCityConveyGameObjectPools.Length; num50++)
			{
				if (this.EffectNPCCityConveyGameObjectPools[num50] != null)
				{
					for (int num51 = 0; num51 < this.EffectNPCCityConveyGameObjectPools[num50].Length; num51++)
					{
						if (this.EffectNPCCityConveyGameObjectPools[num50][num51] != null)
						{
							ParticleManager.Instance.DeSpawn(this.EffectNPCCityConveyGameObjectPools[num50][num51]);
							this.EffectNPCCityConveyGameObjectPools[num50][num51] = null;
							this.EffectNPCCityConveyTransformPools[num50][num51] = null;
							this.EffectNPCCityConveyParticlePools[num50][num51] = null;
							this.EffectNPCCityConveyParticlePools_one[num50][num51] = null;
							this.EffectNPCCityConveyParticlePools_two[num50][num51] = null;
							this.EffectNPCCityConveyParticlePools_thr[num50][num51] = null;
						}
					}
					this.EffectNPCCityConveyGameObjectPools[num50] = null;
					this.EffectNPCCityConveyTransformPools[num50] = null;
					this.EffectNPCCityConveyParticlePools[num50] = null;
					this.EffectNPCCityConveyParticlePools_one[num50] = null;
					this.EffectNPCCityConveyParticlePools_two[num50] = null;
					this.EffectNPCCityConveyParticlePools_thr[num50] = null;
				}
			}
		}
		this.EffectNPCCityConveyGameObjectPools = null;
		this.EffectNPCCityConveyTransformPools = null;
		this.EffectNPCCityConveyParticlePools = null;
		this.EffectNPCCityConveyParticlePools_one = null;
		this.EffectNPCCityConveyParticlePools_two = null;
		this.EffectNPCCityConveyParticlePools_thr = null;
		if (this.EffectMapWeaponHurtGameObjectPools != null)
		{
			for (int num52 = 0; num52 < this.EffectMapWeaponHurtGameObjectPools.Length; num52++)
			{
				if (this.EffectMapWeaponHurtGameObjectPools[num52] != null)
				{
					for (int num53 = 0; num53 < this.EffectMapWeaponHurtGameObjectPools[num52].Length; num53++)
					{
						if (this.EffectMapWeaponHurtGameObjectPools[num52][num53] != null)
						{
							ParticleManager.Instance.DeSpawn(this.EffectMapWeaponHurtGameObjectPools[num52][num53]);
							this.EffectMapWeaponHurtGameObjectPools[num52][num53] = null;
							this.EffectMapWeaponHurtTransformPools[num52][num53] = null;
							for (int num54 = 0; num54 < this.EffectMapWeaponHurtParticlePools.Length; num54++)
							{
								this.EffectMapWeaponHurtParticlePools[num54][num52][num53] = null;
							}
						}
					}
					this.EffectMapWeaponHurtGameObjectPools[num52] = null;
					this.EffectMapWeaponHurtTransformPools[num52] = null;
					for (int num55 = 0; num55 < this.EffectMapWeaponHurtParticlePools.Length; num55++)
					{
						this.EffectMapWeaponHurtParticlePools[num55][num52] = null;
					}
				}
			}
		}
		this.EffectMapWeaponHurtGameObjectPools = null;
		this.EffectMapWeaponHurtTransformPools = null;
		for (int num56 = 0; num56 < this.EffectMapWeaponHurtParticlePools.Length; num56++)
		{
			this.EffectMapWeaponHurtParticlePools[num56] = null;
		}
		this.EffectMapWeaponHurtParticlePools = null;
		if (this.EffectBallDownGameObjectPools != null)
		{
			for (int num57 = 0; num57 < this.EffectBallDownGameObjectPools.Length; num57++)
			{
				if (this.EffectBallDownGameObjectPools[num57] != null)
				{
					for (int num58 = 0; num58 < this.EffectBallDownGameObjectPools[num57].Length; num58++)
					{
						if (this.EffectBallDownGameObjectPools[num57][num58] != null)
						{
							ParticleManager.Instance.DeSpawn(this.EffectBallDownGameObjectPools[num57][num58]);
							this.EffectBallDownGameObjectPools[num57][num58] = null;
							this.EffectBallDownTransformPools[num57][num58] = null;
							for (int num59 = 0; num59 < this.EffectBallDownParticlePools.Length; num59++)
							{
								this.EffectBallDownParticlePools[num59][num57][num58] = null;
							}
						}
					}
					this.EffectBallDownGameObjectPools[num57] = null;
					this.EffectBallDownTransformPools[num57] = null;
					for (int num60 = 0; num60 < this.EffectBallDownParticlePools.Length; num60++)
					{
						this.EffectBallDownParticlePools[num60][num57] = null;
					}
				}
			}
		}
		this.EffectBallDownGameObjectPools = null;
		this.EffectBallDownTransformPools = null;
		for (int num61 = 0; num61 < this.EffectBallDownParticlePools.Length; num61++)
		{
			this.EffectBallDownParticlePools[num61] = null;
		}
		this.EffectBallDownParticlePools = null;
		if (this.EffectBallBigYolkGameObjectPools != null)
		{
			for (int num62 = 0; num62 < this.EffectBallBigYolkGameObjectPools.Length; num62++)
			{
				if (this.EffectBallBigYolkGameObjectPools[num62] != null)
				{
					for (int num63 = 0; num63 < this.EffectBallBigYolkGameObjectPools[num62].Length; num63++)
					{
						if (this.EffectBallBigYolkGameObjectPools[num62][num63] != null)
						{
							ParticleManager.Instance.DeSpawn(this.EffectBallBigYolkGameObjectPools[num62][num63]);
							this.EffectBallBigYolkGameObjectPools[num62][num63] = null;
							this.EffectBallBigYolkTransformPools[num62][num63] = null;
							for (int num64 = 0; num64 < this.EffectBallBigYolkParticlePools.Length; num64++)
							{
								this.EffectBallBigYolkParticlePools[num64][num62][num63] = null;
							}
						}
					}
					this.EffectBallBigYolkGameObjectPools[num62] = null;
					this.EffectBallBigYolkTransformPools[num62] = null;
					for (int num65 = 0; num65 < this.EffectBallBigYolkParticlePools.Length; num65++)
					{
						this.EffectBallBigYolkParticlePools[num65][num62] = null;
					}
				}
			}
		}
		this.EffectBallBigYolkGameObjectPools = null;
		this.EffectBallBigYolkTransformPools = null;
		for (int num66 = 0; num66 < this.EffectBallBigYolkParticlePools.Length; num66++)
		{
			this.EffectBallBigYolkParticlePools[num66] = null;
		}
		this.EffectBallBigYolkParticlePools = null;
		if (this.EffectBallYolkGameObjectPools != null)
		{
			for (int num67 = 0; num67 < this.EffectBallYolkGameObjectPools.Length; num67++)
			{
				if (this.EffectBallYolkGameObjectPools[num67] != null)
				{
					for (int num68 = 0; num68 < this.EffectBallYolkGameObjectPools[num67].Length; num68++)
					{
						if (this.EffectBallYolkGameObjectPools[num67][num68] != null)
						{
							ParticleManager.Instance.DeSpawn(this.EffectBallYolkGameObjectPools[num67][num68]);
							this.EffectBallYolkGameObjectPools[num67][num68] = null;
							this.EffectBallYolkTransformPools[num67][num68] = null;
							for (int num69 = 0; num69 < this.EffectBallYolkParticlePools.Length; num69++)
							{
								this.EffectBallYolkParticlePools[num69][num67][num68] = null;
							}
						}
					}
					this.EffectBallYolkGameObjectPools[num67] = null;
					this.EffectBallYolkTransformPools[num67] = null;
					for (int num70 = 0; num70 < this.EffectBallYolkParticlePools.Length; num70++)
					{
						this.EffectBallYolkParticlePools[num70][num67] = null;
					}
				}
			}
		}
		this.EffectBallYolkGameObjectPools = null;
		this.EffectBallYolkTransformPools = null;
		for (int num71 = 0; num71 < this.EffectBallYolkParticlePools.Length; num71++)
		{
			this.EffectBallYolkParticlePools[num71] = null;
		}
		this.EffectBallYolkParticlePools = null;
		if (this.EffectBallNPCCityGameObjectPools != null)
		{
			for (int num72 = 0; num72 < this.EffectBallNPCCityGameObjectPools.Length; num72++)
			{
				if (this.EffectBallNPCCityGameObjectPools[num72] != null)
				{
					for (int num73 = 0; num73 < this.EffectBallNPCCityGameObjectPools[num72].Length; num73++)
					{
						if (this.EffectBallNPCCityGameObjectPools[num72][num73] != null)
						{
							ParticleManager.Instance.DeSpawn(this.EffectBallNPCCityGameObjectPools[num72][num73]);
							this.EffectBallNPCCityGameObjectPools[num72][num73] = null;
							this.EffectBallNPCCityTransformPools[num72][num73] = null;
							for (int num74 = 0; num74 < this.EffectBallNPCCityParticlePools.Length; num74++)
							{
								this.EffectBallNPCCityParticlePools[num74][num72][num73] = null;
							}
						}
					}
					this.EffectBallNPCCityGameObjectPools[num72] = null;
					this.EffectBallNPCCityTransformPools[num72] = null;
					for (int num75 = 0; num75 < this.EffectBallNPCCityParticlePools.Length; num75++)
					{
						this.EffectBallNPCCityParticlePools[num75][num72] = null;
					}
				}
			}
		}
		this.EffectBallNPCCityGameObjectPools = null;
		this.EffectBallNPCCityTransformPools = null;
		for (int num76 = 0; num76 < this.EffectBallNPCCityParticlePools.Length; num76++)
		{
			this.EffectBallNPCCityParticlePools[num76] = null;
		}
		this.EffectBallNPCCityParticlePools = null;
		if (this.EffectBallOutGameObjectPools != null)
		{
			for (int num77 = 0; num77 < this.EffectBallOutGameObjectPools.Length; num77++)
			{
				if (this.EffectBallOutGameObjectPools[num77] != null)
				{
					for (int num78 = 0; num78 < this.EffectBallOutGameObjectPools[num77].Length; num78++)
					{
						if (this.EffectBallOutGameObjectPools[num77][num78] != null)
						{
							ParticleManager.Instance.DeSpawn(this.EffectBallOutGameObjectPools[num77][num78]);
							this.EffectBallOutGameObjectPools[num77][num78] = null;
							this.EffectBallOutTransformPools[num77][num78] = null;
							for (int num79 = 0; num79 < this.EffectBallOutParticlePools.Length; num79++)
							{
								this.EffectBallOutParticlePools[num79][num77][num78] = null;
							}
						}
					}
					this.EffectBallOutGameObjectPools[num77] = null;
					this.EffectBallOutTransformPools[num77] = null;
					for (int num80 = 0; num80 < this.EffectBallOutParticlePools.Length; num80++)
					{
						this.EffectBallOutParticlePools[num80][num77] = null;
					}
				}
			}
		}
		this.EffectBallOutGameObjectPools = null;
		this.EffectBallOutTransformPools = null;
		for (int num81 = 0; num81 < this.EffectBallOutParticlePools.Length; num81++)
		{
			this.EffectBallOutParticlePools[num81] = null;
		}
		this.EffectBallOutParticlePools = null;
		if (this.EffectBallKickGameObjectPools != null)
		{
			for (int num82 = 0; num82 < this.EffectBallKickGameObjectPools.Length; num82++)
			{
				if (this.EffectBallKickGameObjectPools[num82] != null)
				{
					for (int num83 = 0; num83 < this.EffectBallKickGameObjectPools[num82].Length; num83++)
					{
						if (this.EffectBallKickGameObjectPools[num82][num83] != null)
						{
							ParticleManager.Instance.DeSpawn(this.EffectBallKickGameObjectPools[num82][num83]);
							this.EffectBallKickGameObjectPools[num82][num83] = null;
							this.EffectBallKickTransformPools[num82][num83] = null;
							for (int num84 = 0; num84 < this.EffectBallKickParticlePools.Length; num84++)
							{
								this.EffectBallKickParticlePools[num84][num82][num83] = null;
							}
						}
					}
					this.EffectBallKickGameObjectPools[num82] = null;
					this.EffectBallKickTransformPools[num82] = null;
					for (int num85 = 0; num85 < this.EffectBallKickParticlePools.Length; num85++)
					{
						this.EffectBallKickParticlePools[num85][num82] = null;
					}
				}
			}
		}
		this.EffectBallKickGameObjectPools = null;
		this.EffectBallKickTransformPools = null;
		for (int num86 = 0; num86 < this.EffectBallKickParticlePools.Length; num86++)
		{
			this.EffectBallKickParticlePools[num86] = null;
		}
		this.EffectBallKickParticlePools = null;
		this.EffectYolkWinGameObject = null;
		this.EffectYolkLoseGameObject = null;
		this.EffectYolkShieldGameObject = null;
		this.EffectBigYolkWinGameObject = null;
		this.EffectBigYolkLoseGameObject = null;
		this.EffectBigYolkShieldGameObject = null;
		this.EffectYolkWinTransform = null;
		this.EffectYolkLoseTransform = null;
		this.EffectYolkShieldTransform = null;
		this.EffectBigYolkWinTransform = null;
		this.EffectBigYolkLoseTransform = null;
		this.EffectBigYolkShieldTransform = null;
		this.EffectYolkWinParticle = null;
		this.EffectYolkWinParticle_one = null;
		this.EffectYolkWinParticle_two = null;
		this.EffectYolkWinParticle_thr = null;
		this.EffectYolkWinParticle_tho = null;
		this.EffectYolkLoseParticle = null;
		this.EffectYolkLoseParticle_one = null;
		this.EffectYolkShieldParticle = null;
		this.EffectYolkShieldParticle_one = null;
		this.EffectYolkShieldParticle_two = null;
		this.EffectYolkShieldParticle_thr = null;
		this.EffectBigYolkWinParticle = null;
		this.EffectBigYolkWinParticle_one = null;
		this.EffectBigYolkWinParticle_two = null;
		this.EffectBigYolkWinParticle_thr = null;
		this.EffectBigYolkWinParticle_for = null;
		this.EffectBigYolkLoseParticle = null;
		this.EffectBigYolkLoseParticle_one = null;
		this.EffectBigYolkLoseParticle_two = null;
		this.EffectBigYolkShieldParticle = null;
		this.EffectBigYolkShieldParticle_one = null;
		this.EffectBigYolkShieldParticle_two = null;
		this.EffectBigYolkShieldParticle_thr = null;
		if (this.WinpoolCounter != null)
		{
			Array.Clear(this.WinpoolCounter, 0, this.WinpoolCounter.Length);
		}
		if (this.LosepoolCounter != null)
		{
			Array.Clear(this.LosepoolCounter, 0, this.LosepoolCounter.Length);
		}
		if (this.ShieldpoolCounter != null)
		{
			Array.Clear(this.ShieldpoolCounter, 0, this.ShieldpoolCounter.Length);
		}
		if (this.ConveypoolCounter != null)
		{
			Array.Clear(this.ConveypoolCounter, 0, this.ConveypoolCounter.Length);
		}
		if (this.EnemyLosepoolCounter != null)
		{
			Array.Clear(this.EnemyLosepoolCounter, 0, this.EnemyLosepoolCounter.Length);
		}
		if (this.NPCCityConveypoolCounter != null)
		{
			Array.Clear(this.NPCCityConveypoolCounter, 0, this.NPCCityConveypoolCounter.Length);
		}
		if (this.MapWeaponHurtpoolCounter != null)
		{
			Array.Clear(this.MapWeaponHurtpoolCounter, 0, this.MapWeaponHurtpoolCounter.Length);
		}
		if (this.BallDownpoolCounter != null)
		{
			Array.Clear(this.BallDownpoolCounter, 0, this.BallDownpoolCounter.Length);
		}
		if (this.BallBigYolkpoolCounter != null)
		{
			Array.Clear(this.BallBigYolkpoolCounter, 0, this.BallBigYolkpoolCounter.Length);
		}
		if (this.BallYolkpoolCounter != null)
		{
			Array.Clear(this.BallYolkpoolCounter, 0, this.BallYolkpoolCounter.Length);
		}
		if (this.BallNPCCitypoolCounter != null)
		{
			Array.Clear(this.BallNPCCitypoolCounter, 0, this.BallNPCCitypoolCounter.Length);
		}
		if (this.BallOutpoolCounter != null)
		{
			Array.Clear(this.BallOutpoolCounter, 0, this.BallOutpoolCounter.Length);
		}
		if (this.BallKickpoolCounter != null)
		{
			Array.Clear(this.BallKickpoolCounter, 0, this.BallKickpoolCounter.Length);
		}
	}

	// Token: 0x06000B3C RID: 2876 RVA: 0x000F57E0 File Offset: 0x000F39E0
	public void IniEffect(int rowNum, int colNum, float tileBaseScale, bool bfront = false)
	{
		this.bFront = bfront;
		this.bBack = ((!this.bFront) ? (((ActivityManager.Instance.bSpecialMonsterTreasureEvent & 2UL) <= 0UL) ? 1 : 0) : 1);
		this.EffectWinGameObject = new GameObject[colNum][];
		this.EffectLoseGameObject = new GameObject[colNum][];
		this.EffectShieldGameObject = new GameObject[colNum][];
		this.EffectConveyGameObject = new GameObject[colNum][];
		this.EffectEnemyLoseGameObject = new GameObject[colNum][];
		this.EffectNPCCityConveyGameObject = new GameObject[colNum][];
		this.EffectMapWeaponHurtGameObject = new GameObject[colNum][];
		this.EffectBallDownGameObject = new GameObject[colNum][];
		this.EffectBallBigYolkGameObject = new GameObject[colNum][];
		this.EffectBallYolkGameObject = new GameObject[colNum][];
		this.EffectBallNPCCityGameObject = new GameObject[colNum][];
		this.EffectBallOutGameObject = new GameObject[colNum][];
		this.EffectBallKickGameObject = new GameObject[colNum][];
		this.EffectWinTransform = new Transform[colNum][];
		this.EffectLoseTransform = new Transform[colNum][];
		this.EffectShieldTransform = new Transform[colNum][];
		this.EffectConveyTransform = new Transform[colNum][];
		this.EffectEnemyLoseTransform = new Transform[colNum][];
		this.EffectNPCCityConveyTransform = new Transform[colNum][];
		this.EffectMapWeaponHurtTransform = new Transform[colNum][];
		this.EffectBallDownTransform = new Transform[colNum][];
		this.EffectBallBigYolkTransform = new Transform[colNum][];
		this.EffectBallYolkTransform = new Transform[colNum][];
		this.EffectBallNPCCityTransform = new Transform[colNum][];
		this.EffectBallOutTransform = new Transform[colNum][];
		this.EffectBallKickTransform = new Transform[colNum][];
		this.EffectWinParticle = new ParticleSystem[colNum][];
		this.EffectLoseParticle = new ParticleSystem[colNum][];
		this.EffectShieldParticle = new ParticleSystem[colNum][];
		this.EffectShieldParticle_one = new ParticleSystem[colNum][];
		this.EffectConveyParticle = new ParticleSystem[colNum][];
		this.EffectConveyParticle_one = new ParticleSystem[colNum][];
		this.EffectConveyParticle_two = new ParticleSystem[colNum][];
		this.EffectConveyParticle_thr = new ParticleSystem[colNum][];
		this.EffectEnemyLoseParticle = new ParticleSystem[colNum][];
		this.EffectNPCCityConveyParticle = new ParticleSystem[colNum][];
		this.EffectNPCCityConveyParticle_one = new ParticleSystem[colNum][];
		this.EffectNPCCityConveyParticle_two = new ParticleSystem[colNum][];
		this.EffectNPCCityConveyParticle_thr = new ParticleSystem[colNum][];
		this.EffectMapWeaponHurtParticle = new ParticleSystem[2][][];
		this.EffectMapWeaponHurtParticlePools = new ParticleSystem[2][][];
		this.MapWeaponHurtlifetime = new float[2];
		this.MapWeaponHurtstartSize = new float[2];
		for (int i = 0; i < this.EffectMapWeaponHurtParticle.Length; i++)
		{
			this.EffectMapWeaponHurtParticle[i] = new ParticleSystem[colNum][];
		}
		this.EffectBallDownParticle = new ParticleSystem[13][][];
		this.EffectBallDownParticlePools = new ParticleSystem[13][][];
		this.BallDownlifetime = new float[13];
		this.BallDownstartSize = new float[13];
		for (int j = 0; j < this.EffectBallDownParticle.Length; j++)
		{
			this.EffectBallDownParticle[j] = new ParticleSystem[colNum][];
		}
		this.EffectBallBigYolkParticle = new ParticleSystem[9][][];
		this.EffectBallBigYolkParticlePools = new ParticleSystem[9][][];
		this.BallBigYolklifetime = new float[9];
		this.BallBigYolkstartSize = new float[9];
		for (int k = 0; k < this.EffectBallBigYolkParticle.Length; k++)
		{
			this.EffectBallBigYolkParticle[k] = new ParticleSystem[colNum][];
		}
		this.EffectBallYolkParticle = new ParticleSystem[9][][];
		this.EffectBallYolkParticlePools = new ParticleSystem[9][][];
		this.BallYolklifetime = new float[9];
		this.BallYolkstartSize = new float[9];
		for (int l = 0; l < this.EffectBallYolkParticle.Length; l++)
		{
			this.EffectBallYolkParticle[l] = new ParticleSystem[colNum][];
		}
		this.EffectBallNPCCityParticle = new ParticleSystem[9][][];
		this.EffectBallNPCCityParticlePools = new ParticleSystem[9][][];
		this.BallNPCCitylifetime = new float[9];
		this.BallNPCCitystartSize = new float[9];
		for (int m = 0; m < this.EffectBallNPCCityParticle.Length; m++)
		{
			this.EffectBallNPCCityParticle[m] = new ParticleSystem[colNum][];
		}
		this.EffectBallOutParticle = new ParticleSystem[6][][];
		this.EffectBallOutParticlePools = new ParticleSystem[6][][];
		this.BallOutlifetime = new float[6];
		this.BallOutstartSize = new float[6];
		for (int n = 0; n < this.EffectBallOutParticle.Length; n++)
		{
			this.EffectBallOutParticle[n] = new ParticleSystem[colNum][];
		}
		this.EffectBallKickParticle = new ParticleSystem[5][][];
		this.EffectBallKickParticlePools = new ParticleSystem[5][][];
		this.BallKicklifetime = new float[5];
		this.BallKickstartSize = new float[5];
		for (int num = 0; num < this.EffectBallKickParticle.Length; num++)
		{
			this.EffectBallKickParticle[num] = new ParticleSystem[colNum][];
		}
		this.Particletimer = new float[colNum][];
		this.Particlekind = new byte[colNum][];
		for (int num2 = 0; num2 < colNum; num2++)
		{
			this.EffectWinGameObject[num2] = new GameObject[rowNum];
			this.EffectLoseGameObject[num2] = new GameObject[rowNum];
			this.EffectShieldGameObject[num2] = new GameObject[rowNum];
			this.EffectConveyGameObject[num2] = new GameObject[rowNum];
			this.EffectEnemyLoseGameObject[num2] = new GameObject[rowNum];
			this.EffectNPCCityConveyGameObject[num2] = new GameObject[rowNum];
			this.EffectMapWeaponHurtGameObject[num2] = new GameObject[rowNum];
			this.EffectBallDownGameObject[num2] = new GameObject[rowNum];
			this.EffectBallBigYolkGameObject[num2] = new GameObject[rowNum];
			this.EffectBallYolkGameObject[num2] = new GameObject[rowNum];
			this.EffectBallNPCCityGameObject[num2] = new GameObject[rowNum];
			this.EffectBallOutGameObject[num2] = new GameObject[rowNum];
			this.EffectBallKickGameObject[num2] = new GameObject[rowNum];
			this.EffectWinTransform[num2] = new Transform[rowNum];
			this.EffectLoseTransform[num2] = new Transform[rowNum];
			this.EffectShieldTransform[num2] = new Transform[rowNum];
			this.EffectConveyTransform[num2] = new Transform[rowNum];
			this.EffectEnemyLoseTransform[num2] = new Transform[rowNum];
			this.EffectNPCCityConveyTransform[num2] = new Transform[rowNum];
			this.EffectMapWeaponHurtTransform[num2] = new Transform[rowNum];
			this.EffectBallDownTransform[num2] = new Transform[rowNum];
			this.EffectBallBigYolkTransform[num2] = new Transform[rowNum];
			this.EffectBallYolkTransform[num2] = new Transform[rowNum];
			this.EffectBallNPCCityTransform[num2] = new Transform[rowNum];
			this.EffectBallOutTransform[num2] = new Transform[rowNum];
			this.EffectBallKickTransform[num2] = new Transform[rowNum];
			this.EffectWinParticle[num2] = new ParticleSystem[rowNum];
			this.EffectLoseParticle[num2] = new ParticleSystem[rowNum];
			this.EffectShieldParticle[num2] = new ParticleSystem[rowNum];
			this.EffectShieldParticle_one[num2] = new ParticleSystem[rowNum];
			this.EffectConveyParticle[num2] = new ParticleSystem[rowNum];
			this.EffectConveyParticle_one[num2] = new ParticleSystem[rowNum];
			this.EffectConveyParticle_two[num2] = new ParticleSystem[rowNum];
			this.EffectConveyParticle_thr[num2] = new ParticleSystem[rowNum];
			this.EffectEnemyLoseParticle[num2] = new ParticleSystem[rowNum];
			this.EffectNPCCityConveyParticle[num2] = new ParticleSystem[rowNum];
			this.EffectNPCCityConveyParticle_one[num2] = new ParticleSystem[rowNum];
			this.EffectNPCCityConveyParticle_two[num2] = new ParticleSystem[rowNum];
			this.EffectNPCCityConveyParticle_thr[num2] = new ParticleSystem[rowNum];
			for (int num3 = 0; num3 < this.EffectMapWeaponHurtParticle.Length; num3++)
			{
				this.EffectMapWeaponHurtParticle[num3][num2] = new ParticleSystem[rowNum];
			}
			for (int num4 = 0; num4 < this.EffectBallDownParticle.Length; num4++)
			{
				this.EffectBallDownParticle[num4][num2] = new ParticleSystem[rowNum];
			}
			for (int num5 = 0; num5 < this.EffectBallBigYolkParticle.Length; num5++)
			{
				this.EffectBallBigYolkParticle[num5][num2] = new ParticleSystem[rowNum];
			}
			for (int num6 = 0; num6 < this.EffectBallYolkParticle.Length; num6++)
			{
				this.EffectBallYolkParticle[num6][num2] = new ParticleSystem[rowNum];
			}
			for (int num7 = 0; num7 < this.EffectBallNPCCityParticle.Length; num7++)
			{
				this.EffectBallNPCCityParticle[num7][num2] = new ParticleSystem[rowNum];
			}
			for (int num8 = 0; num8 < this.EffectBallOutParticle.Length; num8++)
			{
				this.EffectBallOutParticle[num8][num2] = new ParticleSystem[rowNum];
			}
			for (int num9 = 0; num9 < this.EffectBallKickParticle.Length; num9++)
			{
				this.EffectBallKickParticle[num9][num2] = new ParticleSystem[rowNum];
			}
			Array.Clear(this.EffectWinGameObject[num2], 0, this.EffectWinGameObject[num2].Length);
			Array.Clear(this.EffectLoseGameObject[num2], 0, this.EffectLoseGameObject[num2].Length);
			Array.Clear(this.EffectShieldGameObject[num2], 0, this.EffectShieldGameObject[num2].Length);
			Array.Clear(this.EffectConveyGameObject[num2], 0, this.EffectConveyGameObject[num2].Length);
			Array.Clear(this.EffectEnemyLoseGameObject[num2], 0, this.EffectLoseGameObject[num2].Length);
			Array.Clear(this.EffectNPCCityConveyGameObject[num2], 0, this.EffectNPCCityConveyGameObject[num2].Length);
			Array.Clear(this.EffectMapWeaponHurtGameObject[num2], 0, this.EffectMapWeaponHurtGameObject[num2].Length);
			Array.Clear(this.EffectBallDownGameObject[num2], 0, this.EffectBallDownGameObject[num2].Length);
			Array.Clear(this.EffectBallBigYolkGameObject[num2], 0, this.EffectBallBigYolkGameObject[num2].Length);
			Array.Clear(this.EffectBallYolkGameObject[num2], 0, this.EffectBallYolkGameObject[num2].Length);
			Array.Clear(this.EffectBallNPCCityGameObject[num2], 0, this.EffectBallNPCCityGameObject[num2].Length);
			Array.Clear(this.EffectBallOutGameObject[num2], 0, this.EffectBallOutGameObject[num2].Length);
			Array.Clear(this.EffectBallKickGameObject[num2], 0, this.EffectBallKickGameObject[num2].Length);
			Array.Clear(this.EffectWinTransform[num2], 0, this.EffectWinTransform[num2].Length);
			Array.Clear(this.EffectLoseTransform[num2], 0, this.EffectLoseTransform[num2].Length);
			Array.Clear(this.EffectShieldTransform[num2], 0, this.EffectShieldTransform[num2].Length);
			Array.Clear(this.EffectConveyTransform[num2], 0, this.EffectConveyTransform[num2].Length);
			Array.Clear(this.EffectEnemyLoseTransform[num2], 0, this.EffectLoseTransform[num2].Length);
			Array.Clear(this.EffectNPCCityConveyTransform[num2], 0, this.EffectNPCCityConveyTransform[num2].Length);
			Array.Clear(this.EffectMapWeaponHurtTransform[num2], 0, this.EffectMapWeaponHurtTransform[num2].Length);
			Array.Clear(this.EffectBallDownTransform[num2], 0, this.EffectBallDownTransform[num2].Length);
			Array.Clear(this.EffectBallBigYolkTransform[num2], 0, this.EffectBallBigYolkTransform[num2].Length);
			Array.Clear(this.EffectBallYolkTransform[num2], 0, this.EffectBallYolkTransform[num2].Length);
			Array.Clear(this.EffectBallNPCCityTransform[num2], 0, this.EffectBallNPCCityTransform[num2].Length);
			Array.Clear(this.EffectBallOutTransform[num2], 0, this.EffectBallOutTransform[num2].Length);
			Array.Clear(this.EffectBallKickTransform[num2], 0, this.EffectBallKickTransform[num2].Length);
			Array.Clear(this.EffectWinParticle[num2], 0, this.EffectWinParticle[num2].Length);
			Array.Clear(this.EffectLoseParticle[num2], 0, this.EffectLoseParticle[num2].Length);
			Array.Clear(this.EffectShieldParticle[num2], 0, this.EffectShieldParticle[num2].Length);
			Array.Clear(this.EffectShieldParticle_one[num2], 0, this.EffectShieldParticle_one[num2].Length);
			Array.Clear(this.EffectConveyParticle[num2], 0, this.EffectConveyParticle[num2].Length);
			Array.Clear(this.EffectConveyParticle_one[num2], 0, this.EffectConveyParticle_one[num2].Length);
			Array.Clear(this.EffectConveyParticle_two[num2], 0, this.EffectConveyParticle_two[num2].Length);
			Array.Clear(this.EffectConveyParticle_thr[num2], 0, this.EffectConveyParticle_thr[num2].Length);
			Array.Clear(this.EffectEnemyLoseParticle[num2], 0, this.EffectLoseParticle[num2].Length);
			Array.Clear(this.EffectNPCCityConveyParticle[num2], 0, this.EffectNPCCityConveyParticle[num2].Length);
			Array.Clear(this.EffectNPCCityConveyParticle_one[num2], 0, this.EffectNPCCityConveyParticle_one[num2].Length);
			Array.Clear(this.EffectNPCCityConveyParticle_two[num2], 0, this.EffectNPCCityConveyParticle_two[num2].Length);
			Array.Clear(this.EffectNPCCityConveyParticle_thr[num2], 0, this.EffectNPCCityConveyParticle_thr[num2].Length);
			for (int num10 = 0; num10 < this.EffectMapWeaponHurtParticle.Length; num10++)
			{
				Array.Clear(this.EffectMapWeaponHurtParticle[num10][num2], 0, this.EffectMapWeaponHurtParticle[num10][num2].Length);
			}
			for (int num11 = 0; num11 < this.EffectBallDownParticle.Length; num11++)
			{
				Array.Clear(this.EffectBallDownParticle[num11][num2], 0, this.EffectBallDownParticle[num11][num2].Length);
			}
			for (int num12 = 0; num12 < this.EffectBallBigYolkParticle.Length; num12++)
			{
				Array.Clear(this.EffectBallBigYolkParticle[num12][num2], 0, this.EffectBallBigYolkParticle[num12][num2].Length);
			}
			for (int num13 = 0; num13 < this.EffectBallYolkParticle.Length; num13++)
			{
				Array.Clear(this.EffectBallYolkParticle[num13][num2], 0, this.EffectBallYolkParticle[num13][num2].Length);
			}
			for (int num14 = 0; num14 < this.EffectBallNPCCityParticle.Length; num14++)
			{
				Array.Clear(this.EffectBallNPCCityParticle[num14][num2], 0, this.EffectBallNPCCityParticle[num14][num2].Length);
			}
			for (int num15 = 0; num15 < this.EffectBallOutParticle.Length; num15++)
			{
				Array.Clear(this.EffectBallOutParticle[num15][num2], 0, this.EffectBallOutParticle[num15][num2].Length);
			}
			for (int num16 = 0; num16 < this.EffectBallKickParticle.Length; num16++)
			{
				Array.Clear(this.EffectBallKickParticle[num16][num2], 0, this.EffectBallKickParticle[num16][num2].Length);
			}
			this.Particletimer[num2] = new float[rowNum];
			Array.Clear(this.Particletimer[num2], 0, this.Particletimer[num2].Length);
			this.Particlekind[num2] = new byte[rowNum];
			Array.Clear(this.Particlekind[num2], 0, this.Particlekind[num2].Length);
		}
		this.EffectWinGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectWinTransformPools = new Transform[rowNum << 1][];
		this.EffectWinParticlePools = new ParticleSystem[rowNum << 1][];
		this.WinpoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectWinGameObjectPools, 0, this.EffectWinGameObjectPools.Length);
		Array.Clear(this.EffectWinTransformPools, 0, this.EffectWinTransformPools.Length);
		Array.Clear(this.EffectWinParticlePools, 0, this.EffectWinParticlePools.Length);
		this.EffectLoseGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectLoseTransformPools = new Transform[rowNum << 1][];
		this.EffectLoseParticlePools = new ParticleSystem[rowNum << 1][];
		this.LosepoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectLoseGameObjectPools, 0, this.EffectLoseGameObjectPools.Length);
		Array.Clear(this.EffectLoseTransformPools, 0, this.EffectLoseTransformPools.Length);
		Array.Clear(this.EffectLoseParticlePools, 0, this.EffectLoseParticlePools.Length);
		this.EffectEnemyLoseGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectEnemyLoseTransformPools = new Transform[rowNum << 1][];
		this.EffectEnemyLoseParticlePools = new ParticleSystem[rowNum << 1][];
		this.EnemyLosepoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectEnemyLoseGameObjectPools, 0, this.EffectEnemyLoseGameObjectPools.Length);
		Array.Clear(this.EffectEnemyLoseTransformPools, 0, this.EffectEnemyLoseTransformPools.Length);
		Array.Clear(this.EffectEnemyLoseParticlePools, 0, this.EffectEnemyLoseParticlePools.Length);
		this.EffectShieldGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectShieldTransformPools = new Transform[rowNum << 1][];
		this.EffectShieldParticlePools = new ParticleSystem[rowNum << 1][];
		this.EffectShieldParticlePools_one = new ParticleSystem[rowNum << 1][];
		this.ShieldpoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectShieldGameObjectPools, 0, this.EffectShieldGameObjectPools.Length);
		Array.Clear(this.EffectShieldTransformPools, 0, this.EffectShieldTransformPools.Length);
		Array.Clear(this.EffectShieldParticlePools, 0, this.EffectShieldParticlePools.Length);
		Array.Clear(this.EffectShieldParticlePools_one, 0, this.EffectShieldParticlePools_one.Length);
		this.EffectConveyGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectConveyTransformPools = new Transform[rowNum << 1][];
		this.EffectConveyParticlePools = new ParticleSystem[rowNum << 1][];
		this.EffectConveyParticlePools_one = new ParticleSystem[rowNum << 1][];
		this.EffectConveyParticlePools_two = new ParticleSystem[rowNum << 1][];
		this.EffectConveyParticlePools_thr = new ParticleSystem[rowNum << 1][];
		this.ConveypoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectConveyGameObjectPools, 0, this.EffectConveyGameObjectPools.Length);
		Array.Clear(this.EffectConveyTransformPools, 0, this.EffectConveyTransformPools.Length);
		Array.Clear(this.EffectConveyParticlePools, 0, this.EffectConveyParticlePools.Length);
		Array.Clear(this.EffectConveyParticlePools_one, 0, this.EffectConveyParticlePools_one.Length);
		Array.Clear(this.EffectConveyParticlePools_two, 0, this.EffectConveyParticlePools_two.Length);
		Array.Clear(this.EffectConveyParticlePools_thr, 0, this.EffectConveyParticlePools_thr.Length);
		this.EffectNPCCityConveyGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectNPCCityConveyTransformPools = new Transform[rowNum << 1][];
		this.EffectNPCCityConveyParticlePools = new ParticleSystem[rowNum << 1][];
		this.EffectNPCCityConveyParticlePools_one = new ParticleSystem[rowNum << 1][];
		this.EffectNPCCityConveyParticlePools_two = new ParticleSystem[rowNum << 1][];
		this.EffectNPCCityConveyParticlePools_thr = new ParticleSystem[rowNum << 1][];
		this.NPCCityConveypoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectNPCCityConveyGameObjectPools, 0, this.EffectNPCCityConveyGameObjectPools.Length);
		Array.Clear(this.EffectNPCCityConveyTransformPools, 0, this.EffectNPCCityConveyTransformPools.Length);
		Array.Clear(this.EffectNPCCityConveyParticlePools, 0, this.EffectNPCCityConveyParticlePools.Length);
		Array.Clear(this.EffectNPCCityConveyParticlePools_one, 0, this.EffectNPCCityConveyParticlePools_one.Length);
		Array.Clear(this.EffectNPCCityConveyParticlePools_two, 0, this.EffectNPCCityConveyParticlePools_two.Length);
		Array.Clear(this.EffectNPCCityConveyParticlePools_thr, 0, this.EffectNPCCityConveyParticlePools_thr.Length);
		this.EffectMapWeaponHurtGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectMapWeaponHurtTransformPools = new Transform[rowNum << 1][];
		for (int num17 = 0; num17 < this.EffectMapWeaponHurtParticlePools.Length; num17++)
		{
			this.EffectMapWeaponHurtParticlePools[num17] = new ParticleSystem[rowNum << 1][];
		}
		this.MapWeaponHurtpoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectMapWeaponHurtGameObjectPools, 0, this.EffectMapWeaponHurtGameObjectPools.Length);
		Array.Clear(this.EffectMapWeaponHurtTransformPools, 0, this.EffectMapWeaponHurtTransformPools.Length);
		for (int num18 = 0; num18 < this.EffectMapWeaponHurtParticlePools.Length; num18++)
		{
			Array.Clear(this.EffectMapWeaponHurtParticlePools[num18], 0, this.EffectMapWeaponHurtParticlePools[num18].Length);
		}
		this.EffectBallDownGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectBallDownTransformPools = new Transform[rowNum << 1][];
		for (int num19 = 0; num19 < this.EffectBallDownParticlePools.Length; num19++)
		{
			this.EffectBallDownParticlePools[num19] = new ParticleSystem[rowNum << 1][];
		}
		this.BallDownpoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectBallDownGameObjectPools, 0, this.EffectBallDownGameObjectPools.Length);
		Array.Clear(this.EffectBallDownTransformPools, 0, this.EffectBallDownTransformPools.Length);
		for (int num20 = 0; num20 < this.EffectBallDownParticlePools.Length; num20++)
		{
			Array.Clear(this.EffectBallDownParticlePools[num20], 0, this.EffectBallDownParticlePools[num20].Length);
		}
		this.EffectBallBigYolkGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectBallBigYolkTransformPools = new Transform[rowNum << 1][];
		for (int num21 = 0; num21 < this.EffectBallBigYolkParticlePools.Length; num21++)
		{
			this.EffectBallBigYolkParticlePools[num21] = new ParticleSystem[rowNum << 1][];
		}
		this.BallBigYolkpoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectBallBigYolkGameObjectPools, 0, this.EffectBallBigYolkGameObjectPools.Length);
		Array.Clear(this.EffectBallBigYolkTransformPools, 0, this.EffectBallBigYolkTransformPools.Length);
		for (int num22 = 0; num22 < this.EffectBallBigYolkParticlePools.Length; num22++)
		{
			Array.Clear(this.EffectBallBigYolkParticlePools[num22], 0, this.EffectBallBigYolkParticlePools[num22].Length);
		}
		this.EffectBallYolkGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectBallYolkTransformPools = new Transform[rowNum << 1][];
		for (int num23 = 0; num23 < this.EffectBallYolkParticlePools.Length; num23++)
		{
			this.EffectBallYolkParticlePools[num23] = new ParticleSystem[rowNum << 1][];
		}
		this.BallYolkpoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectBallYolkGameObjectPools, 0, this.EffectBallYolkGameObjectPools.Length);
		Array.Clear(this.EffectBallYolkTransformPools, 0, this.EffectBallYolkTransformPools.Length);
		for (int num24 = 0; num24 < this.EffectBallYolkParticlePools.Length; num24++)
		{
			Array.Clear(this.EffectBallYolkParticlePools[num24], 0, this.EffectBallYolkParticlePools[num24].Length);
		}
		this.EffectBallNPCCityGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectBallNPCCityTransformPools = new Transform[rowNum << 1][];
		for (int num25 = 0; num25 < this.EffectBallNPCCityParticlePools.Length; num25++)
		{
			this.EffectBallNPCCityParticlePools[num25] = new ParticleSystem[rowNum << 1][];
		}
		this.BallNPCCitypoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectBallNPCCityGameObjectPools, 0, this.EffectBallNPCCityGameObjectPools.Length);
		Array.Clear(this.EffectBallNPCCityTransformPools, 0, this.EffectBallNPCCityTransformPools.Length);
		for (int num26 = 0; num26 < this.EffectBallNPCCityParticlePools.Length; num26++)
		{
			Array.Clear(this.EffectBallNPCCityParticlePools[num26], 0, this.EffectBallNPCCityParticlePools[num26].Length);
		}
		this.EffectBallOutGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectBallOutTransformPools = new Transform[rowNum << 1][];
		for (int num27 = 0; num27 < this.EffectBallOutParticlePools.Length; num27++)
		{
			this.EffectBallOutParticlePools[num27] = new ParticleSystem[rowNum << 1][];
		}
		this.BallOutpoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectBallOutGameObjectPools, 0, this.EffectBallOutGameObjectPools.Length);
		Array.Clear(this.EffectBallOutTransformPools, 0, this.EffectBallOutTransformPools.Length);
		for (int num28 = 0; num28 < this.EffectBallOutParticlePools.Length; num28++)
		{
			Array.Clear(this.EffectBallOutParticlePools[num28], 0, this.EffectBallOutParticlePools[num28].Length);
		}
		this.EffectBallKickGameObjectPools = new GameObject[rowNum << 1][];
		this.EffectBallKickTransformPools = new Transform[rowNum << 1][];
		for (int num29 = 0; num29 < this.EffectBallKickParticlePools.Length; num29++)
		{
			this.EffectBallKickParticlePools[num29] = new ParticleSystem[rowNum << 1][];
		}
		this.BallKickpoolCounter = new int[rowNum << 1];
		Array.Clear(this.EffectBallKickGameObjectPools, 0, this.EffectBallKickGameObjectPools.Length);
		Array.Clear(this.EffectBallKickTransformPools, 0, this.EffectBallKickTransformPools.Length);
		for (int num30 = 0; num30 < this.EffectBallKickParticlePools.Length; num30++)
		{
			Array.Clear(this.EffectBallKickParticlePools[num30], 0, this.EffectBallKickParticlePools[num30].Length);
		}
		for (int num31 = 0; num31 < this.WinpoolCounter.Length; num31++)
		{
			this.WinpoolCounter[num31] = -1;
			this.LosepoolCounter[num31] = -1;
			this.ShieldpoolCounter[num31] = -1;
			this.ConveypoolCounter[num31] = -1;
			this.EnemyLosepoolCounter[num31] = -1;
			this.NPCCityConveypoolCounter[num31] = -1;
			this.MapWeaponHurtpoolCounter[num31] = -1;
			this.BallDownpoolCounter[num31] = -1;
			this.BallBigYolkpoolCounter[num31] = -1;
			this.BallYolkpoolCounter[num31] = -1;
			this.BallNPCCitypoolCounter[num31] = -1;
			this.BallOutpoolCounter[num31] = -1;
			this.BallKickpoolCounter[num31] = -1;
		}
		this.EffectWinGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectWinTransformPools[0] = new Transform[colNum >> 1];
		this.EffectWinParticlePools[0] = new ParticleSystem[colNum >> 1];
		this.EffectLoseGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectLoseTransformPools[0] = new Transform[colNum >> 1];
		this.EffectLoseParticlePools[0] = new ParticleSystem[colNum >> 1];
		this.EffectEnemyLoseGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectEnemyLoseTransformPools[0] = new Transform[colNum >> 1];
		this.EffectEnemyLoseParticlePools[0] = new ParticleSystem[colNum >> 1];
		this.EffectShieldGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectShieldTransformPools[0] = new Transform[colNum >> 1];
		this.EffectShieldParticlePools[0] = new ParticleSystem[colNum >> 1];
		this.EffectShieldParticlePools_one[0] = new ParticleSystem[colNum >> 1];
		this.EffectConveyGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectConveyTransformPools[0] = new Transform[colNum >> 1];
		this.EffectConveyParticlePools[0] = new ParticleSystem[colNum >> 1];
		this.EffectConveyParticlePools_one[0] = new ParticleSystem[colNum >> 1];
		this.EffectConveyParticlePools_two[0] = new ParticleSystem[colNum >> 1];
		this.EffectConveyParticlePools_thr[0] = new ParticleSystem[colNum >> 1];
		this.EffectNPCCityConveyGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectNPCCityConveyTransformPools[0] = new Transform[colNum >> 1];
		this.EffectNPCCityConveyParticlePools[0] = new ParticleSystem[colNum >> 1];
		this.EffectNPCCityConveyParticlePools_one[0] = new ParticleSystem[colNum >> 1];
		this.EffectNPCCityConveyParticlePools_two[0] = new ParticleSystem[colNum >> 1];
		this.EffectNPCCityConveyParticlePools_thr[0] = new ParticleSystem[colNum >> 1];
		this.EffectMapWeaponHurtGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectMapWeaponHurtTransformPools[0] = new Transform[colNum >> 1];
		for (int num32 = 0; num32 < this.EffectMapWeaponHurtParticlePools.Length; num32++)
		{
			this.EffectMapWeaponHurtParticlePools[num32][0] = new ParticleSystem[colNum >> 1];
		}
		this.EffectBallDownGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectBallDownTransformPools[0] = new Transform[colNum >> 1];
		for (int num33 = 0; num33 < this.EffectBallDownParticlePools.Length; num33++)
		{
			this.EffectBallDownParticlePools[num33][0] = new ParticleSystem[colNum >> 1];
		}
		this.EffectBallYolkGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectBallYolkTransformPools[0] = new Transform[colNum >> 1];
		for (int num34 = 0; num34 < this.EffectBallYolkParticlePools.Length; num34++)
		{
			this.EffectBallYolkParticlePools[num34][0] = new ParticleSystem[colNum >> 1];
		}
		this.EffectBallBigYolkGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectBallBigYolkTransformPools[0] = new Transform[colNum >> 1];
		for (int num35 = 0; num35 < this.EffectBallBigYolkParticlePools.Length; num35++)
		{
			this.EffectBallBigYolkParticlePools[num35][0] = new ParticleSystem[colNum >> 1];
		}
		this.EffectBallNPCCityGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectBallNPCCityTransformPools[0] = new Transform[colNum >> 1];
		for (int num36 = 0; num36 < this.EffectBallNPCCityParticlePools.Length; num36++)
		{
			this.EffectBallNPCCityParticlePools[num36][0] = new ParticleSystem[colNum >> 1];
		}
		this.EffectBallOutGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectBallOutTransformPools[0] = new Transform[colNum >> 1];
		for (int num37 = 0; num37 < this.EffectBallOutParticlePools.Length; num37++)
		{
			this.EffectBallOutParticlePools[num37][0] = new ParticleSystem[colNum >> 1];
		}
		this.EffectBallKickGameObjectPools[0] = new GameObject[colNum >> 1];
		this.EffectBallKickTransformPools[0] = new Transform[colNum >> 1];
		for (int num38 = 0; num38 < this.EffectBallKickParticlePools.Length; num38++)
		{
			this.EffectBallKickParticlePools[num38][0] = new ParticleSystem[colNum >> 1];
		}
		if (this.bBack == 1)
		{
			this.EffectYolkWinGameObject = ParticleManager.Instance.Spawn(379, null, Vector3.zero, 1f, false, false, true);
			this.EffectYolkLoseGameObject = ParticleManager.Instance.Spawn(380, null, Vector3.zero, 1f, false, false, true);
			this.EffectYolkShieldGameObject = ParticleManager.Instance.Spawn(381, null, Vector3.zero, 1f, false, false, true);
			this.EffectBigYolkWinGameObject = ParticleManager.Instance.Spawn(383, null, Vector3.zero, 1f, false, false, true);
			this.EffectBigYolkLoseGameObject = ParticleManager.Instance.Spawn(384, null, Vector3.zero, 1f, false, false, true);
			this.EffectBigYolkShieldGameObject = ParticleManager.Instance.Spawn(385, null, Vector3.zero, 1f, false, false, true);
		}
		else
		{
			this.EffectYolkWinGameObject = ParticleManager.Instance.Spawn(60104, null, Vector3.zero, 1f, false, false, true);
			if (this.EffectYolkWinGameObject == null)
			{
				this.EffectYolkWinGameObject = ParticleManager.Instance.Spawn(379, null, Vector3.zero, 1f, false, false, true);
			}
			this.EffectYolkLoseGameObject = ParticleManager.Instance.Spawn(60105, null, Vector3.zero, 1f, false, false, true);
			if (this.EffectYolkLoseGameObject == null)
			{
				this.EffectYolkLoseGameObject = ParticleManager.Instance.Spawn(380, null, Vector3.zero, 1f, false, false, true);
			}
			this.EffectYolkShieldGameObject = ParticleManager.Instance.Spawn(60106, null, Vector3.zero, 1f, false, false, true);
			if (this.EffectYolkShieldGameObject == null)
			{
				this.EffectYolkShieldGameObject = ParticleManager.Instance.Spawn(381, null, Vector3.zero, 1f, false, false, true);
			}
			this.EffectBigYolkWinGameObject = ParticleManager.Instance.Spawn(60107, null, Vector3.zero, 1f, false, false, true);
			if (this.EffectBigYolkWinGameObject == null)
			{
				this.EffectBigYolkWinGameObject = ParticleManager.Instance.Spawn(383, null, Vector3.zero, 1f, false, false, true);
			}
			this.EffectBigYolkLoseGameObject = ParticleManager.Instance.Spawn(60108, null, Vector3.zero, 1f, false, false, true);
			if (this.EffectBigYolkLoseGameObject == null)
			{
				this.EffectBigYolkLoseGameObject = ParticleManager.Instance.Spawn(384, null, Vector3.zero, 1f, false, false, true);
			}
			this.EffectBigYolkShieldGameObject = ParticleManager.Instance.Spawn(60109, null, Vector3.zero, 1f, false, false, true);
			if (this.EffectBigYolkShieldGameObject == null)
			{
				this.EffectBigYolkShieldGameObject = ParticleManager.Instance.Spawn(385, null, Vector3.zero, 1f, false, false, true);
			}
		}
		this.EffectYolkWinTransform = this.EffectYolkWinGameObject.transform;
		this.EffectYolkLoseTransform = this.EffectYolkLoseGameObject.transform;
		this.EffectYolkShieldTransform = this.EffectYolkShieldGameObject.transform;
		this.EffectBigYolkWinTransform = this.EffectBigYolkWinGameObject.transform;
		this.EffectBigYolkLoseTransform = this.EffectBigYolkLoseGameObject.transform;
		this.EffectBigYolkShieldTransform = this.EffectBigYolkShieldGameObject.transform;
		this.EffectYolkWinTransform.SetParent(this.YolkLayoutTransform);
		this.EffectYolkLoseTransform.SetParent(this.YolkLayoutTransform);
		this.EffectYolkShieldTransform.SetParent(this.YolkLayoutTransform);
		this.EffectBigYolkWinTransform.SetParent(this.YolkLayoutTransform);
		this.EffectBigYolkLoseTransform.SetParent(this.YolkLayoutTransform);
		this.EffectBigYolkShieldTransform.SetParent(this.YolkLayoutTransform);
		this.EffectYolkWinTransform.localPosition = this.inipos;
		this.EffectYolkLoseTransform.localPosition = this.inipos;
		this.EffectYolkShieldTransform.localPosition = this.inipos;
		this.EffectBigYolkWinTransform.localPosition = this.inipos;
		this.EffectBigYolkLoseTransform.localPosition = this.inipos;
		this.EffectBigYolkShieldTransform.localPosition = this.inipos;
		this.EffectYolkWinParticle = this.EffectYolkWinTransform.GetChild(0).GetComponent<ParticleSystem>();
		this.EffectYolkWinParticle_one = this.EffectYolkWinTransform.GetChild(1).GetComponent<ParticleSystem>();
		this.EffectYolkWinParticle_two = this.EffectYolkWinTransform.GetChild(2).GetComponent<ParticleSystem>();
		this.EffectYolkWinParticle_thr = this.EffectYolkWinTransform.GetChild(3).GetComponent<ParticleSystem>();
		this.EffectYolkWinParticle_tho = this.EffectYolkWinTransform.GetChild(4).GetComponent<ParticleSystem>();
		this.EffectYolkLoseParticle = this.EffectYolkLoseTransform.GetChild(0).GetComponent<ParticleSystem>();
		this.EffectYolkLoseParticle_one = this.EffectYolkLoseTransform.GetChild(1).GetComponent<ParticleSystem>();
		this.EffectYolkShieldParticle = this.EffectYolkShieldTransform.GetChild(0).GetComponent<ParticleSystem>();
		this.EffectYolkShieldParticle_one = this.EffectYolkShieldTransform.GetChild(1).GetComponent<ParticleSystem>();
		this.EffectYolkShieldParticle_two = this.EffectYolkShieldTransform.GetChild(2).GetComponent<ParticleSystem>();
		this.EffectYolkShieldParticle_thr = this.EffectYolkShieldTransform.GetChild(3).GetComponent<ParticleSystem>();
		this.EffectBigYolkWinParticle = this.EffectBigYolkWinTransform.GetChild(0).GetComponent<ParticleSystem>();
		this.EffectBigYolkWinParticle_one = this.EffectBigYolkWinTransform.GetChild(1).GetComponent<ParticleSystem>();
		this.EffectBigYolkWinParticle_two = this.EffectBigYolkWinTransform.GetChild(2).GetComponent<ParticleSystem>();
		this.EffectBigYolkWinParticle_thr = this.EffectBigYolkWinTransform.GetChild(3).GetComponent<ParticleSystem>();
		this.EffectBigYolkWinParticle_for = this.EffectBigYolkWinTransform.GetChild(4).GetComponent<ParticleSystem>();
		this.EffectBigYolkLoseParticle = this.EffectBigYolkLoseTransform.GetChild(0).GetComponent<ParticleSystem>();
		this.EffectBigYolkLoseParticle_one = this.EffectBigYolkLoseTransform.GetChild(1).GetComponent<ParticleSystem>();
		this.EffectBigYolkLoseParticle_two = this.EffectBigYolkLoseTransform.GetChild(2).GetComponent<ParticleSystem>();
		this.EffectBigYolkShieldParticle = this.EffectBigYolkShieldTransform.GetChild(0).GetComponent<ParticleSystem>();
		this.EffectBigYolkShieldParticle_one = this.EffectBigYolkShieldTransform.GetChild(1).GetComponent<ParticleSystem>();
		this.EffectBigYolkShieldParticle_two = this.EffectBigYolkShieldTransform.GetChild(2).GetComponent<ParticleSystem>();
		this.EffectBigYolkShieldParticle_thr = this.EffectBigYolkShieldTransform.GetChild(3).GetComponent<ParticleSystem>();
		this.YolkWinstartSize = this.EffectYolkWinParticle.startSize;
		this.YolkWinstartSize_one = this.EffectYolkWinParticle_one.startSize;
		this.YolkWinstartSize_two = this.EffectYolkWinParticle_two.startSize;
		this.YolkWinstartSize_thr = this.EffectYolkWinParticle_thr.startSize;
		this.YolkWinstartSize_tho = this.EffectYolkWinParticle_tho.startSize;
		this.YolkWinlifetime = this.EffectYolkWinParticle.startLifetime;
		this.YolkWinlifetime_one = this.EffectYolkWinParticle_one.startLifetime;
		this.YolkWinlifetime_two = this.EffectYolkWinParticle_two.startLifetime;
		this.YolkWinlifetime_thr = this.EffectYolkWinParticle_thr.startLifetime;
		this.YolkWinlifetime_tho = this.EffectYolkWinParticle_tho.startLifetime;
		this.YolkLosestartSize = this.EffectYolkLoseParticle.startSize;
		this.YolkLosestartSize_one = this.EffectYolkLoseParticle_one.startSize;
		this.YolkLoselifetime = this.EffectYolkLoseParticle.startLifetime;
		this.YolkLoselifetime_one = this.EffectYolkLoseParticle_one.startLifetime;
		this.YolkShieldstartSize = this.EffectYolkShieldParticle.startSize;
		this.YolkShieldstartSize_one = this.EffectYolkShieldParticle_one.startSize;
		this.YolkShieldstartSize_two = this.EffectYolkShieldParticle_two.startSize;
		this.YolkShieldstartSize_thr = this.EffectYolkShieldParticle_thr.startSize;
		this.YolkShieldlifetime = this.EffectYolkShieldParticle.startLifetime;
		this.YolkShieldlifetime_one = this.EffectYolkShieldParticle_one.startLifetime;
		this.YolkShieldlifetime_two = this.EffectYolkShieldParticle_two.startLifetime;
		this.YolkShieldlifetime_thr = this.EffectYolkShieldParticle_thr.startLifetime;
		this.BigYolkWinstartSize = this.EffectBigYolkWinParticle.startSize;
		this.BigYolkWinstartSize_one = this.EffectBigYolkWinParticle_one.startSize;
		this.BigYolkWinstartSize_two = this.EffectBigYolkWinParticle_two.startSize;
		this.BigYolkWinstartSize_thr = this.EffectBigYolkWinParticle_thr.startSize;
		this.BigYolkWinstartSize_for = this.EffectBigYolkWinParticle_for.startSize;
		this.BigYolkWinlifetime = this.EffectBigYolkWinParticle.startLifetime;
		this.BigYolkWinlifetime_one = this.EffectBigYolkWinParticle_one.startLifetime;
		this.BigYolkWinlifetime_two = this.EffectBigYolkWinParticle_two.startLifetime;
		this.BigYolkWinlifetime_thr = this.EffectBigYolkWinParticle_thr.startLifetime;
		this.BigYolkWinlifetime_for = this.EffectBigYolkWinParticle_for.startLifetime;
		this.BigYolkLosestartSize = this.EffectBigYolkLoseParticle.startSize;
		this.BigYolkLosestartSize_one = this.EffectBigYolkLoseParticle_one.startSize;
		this.BigYolkLosestartSize_two = this.EffectBigYolkLoseParticle_two.startSize;
		this.BigYolkLoselifetime = this.EffectBigYolkLoseParticle.startLifetime;
		this.BigYolkLoselifetime_one = this.EffectBigYolkLoseParticle_one.startLifetime;
		this.BigYolkLoselifetime_two = this.EffectBigYolkLoseParticle_two.startLifetime;
		this.BigYolkShieldstartSize = this.EffectBigYolkShieldParticle.startSize;
		this.BigYolkShieldstartSize_one = this.EffectBigYolkShieldParticle_one.startSize;
		this.BigYolkShieldstartSize_two = this.EffectBigYolkShieldParticle_two.startSize;
		this.BigYolkShieldstartSize_thr = this.EffectBigYolkShieldParticle_thr.startSize;
		this.BigYolkShieldlifetime = this.EffectBigYolkShieldParticle.startLifetime;
		this.BigYolkShieldlifetime_one = this.EffectBigYolkShieldParticle_one.startLifetime;
		this.BigYolkShieldlifetime_two = this.EffectBigYolkShieldParticle_two.startLifetime;
		this.BigYolkShieldlifetime_thr = this.EffectBigYolkShieldParticle_thr.startLifetime;
		if (this.bBack == 1)
		{
			for (int num39 = 0; num39 < this.EffectWinGameObjectPools[0].Length; num39++)
			{
				this.EffectWinGameObjectPools[0][num39] = ParticleManager.Instance.Spawn(198, null, Vector3.zero, 1f, false, false, true);
				this.EffectWinTransformPools[0][num39] = this.EffectWinGameObjectPools[0][num39].transform;
				this.EffectWinTransformPools[0][num39].SetParent(this.WinLayoutTransform);
				this.EffectWinTransformPools[0][num39].localPosition = this.inipos;
				this.EffectWinParticlePools[0][num39] = this.EffectWinTransformPools[0][num39].GetChild(0).GetComponent<ParticleSystem>();
				this.EffectLoseGameObjectPools[0][num39] = ParticleManager.Instance.Spawn(197, null, Vector3.zero, 1f, false, false, true);
				this.EffectLoseTransformPools[0][num39] = this.EffectLoseGameObjectPools[0][num39].transform;
				this.EffectLoseTransformPools[0][num39].SetParent(this.LoseLayoutTransform);
				this.EffectLoseTransformPools[0][num39].localPosition = this.inipos;
				this.EffectLoseParticlePools[0][num39] = this.EffectLoseTransformPools[0][num39].GetChild(0).GetComponent<ParticleSystem>();
				this.EffectEnemyLoseGameObjectPools[0][num39] = ParticleManager.Instance.Spawn(387, null, Vector3.zero, 1f, false, false, true);
				this.EffectEnemyLoseTransformPools[0][num39] = this.EffectEnemyLoseGameObjectPools[0][num39].transform;
				this.EffectEnemyLoseTransformPools[0][num39].SetParent(this.EnemyLoseLayoutTransform);
				this.EffectEnemyLoseTransformPools[0][num39].localPosition = this.inipos;
				this.EffectEnemyLoseParticlePools[0][num39] = this.EffectEnemyLoseTransformPools[0][num39].GetChild(0).GetComponent<ParticleSystem>();
				this.EffectShieldGameObjectPools[0][num39] = ParticleManager.Instance.Spawn(199, null, Vector3.zero, 1f, false, false, true);
				this.EffectShieldTransformPools[0][num39] = this.EffectShieldGameObjectPools[0][num39].transform;
				this.EffectShieldTransformPools[0][num39].SetParent(this.ShieldLayoutTransform);
				this.EffectShieldTransformPools[0][num39].localPosition = this.inipos;
				this.EffectShieldParticlePools[0][num39] = this.EffectShieldTransformPools[0][num39].GetChild(0).GetComponent<ParticleSystem>();
				this.EffectShieldParticlePools_one[0][num39] = this.EffectShieldTransformPools[0][num39].GetChild(1).GetComponent<ParticleSystem>();
				this.EffectConveyGameObjectPools[0][num39] = ParticleManager.Instance.Spawn(332, null, Vector3.zero, 1f, false, false, false);
				this.EffectConveyTransformPools[0][num39] = this.EffectConveyGameObjectPools[0][num39].transform;
				this.EffectConveyTransformPools[0][num39].SetParent(this.ConveyLayoutTransform);
				this.EffectConveyTransformPools[0][num39].localPosition = this.inipos;
				this.EffectConveyParticlePools[0][num39] = this.EffectConveyTransformPools[0][num39].GetChild(0).GetComponent<ParticleSystem>();
				this.EffectConveyParticlePools_one[0][num39] = this.EffectConveyTransformPools[0][num39].GetChild(1).GetComponent<ParticleSystem>();
				this.EffectConveyParticlePools_two[0][num39] = this.EffectConveyTransformPools[0][num39].GetChild(2).GetComponent<ParticleSystem>();
				this.EffectConveyParticlePools_thr[0][num39] = this.EffectConveyTransformPools[0][num39].GetChild(3).GetComponent<ParticleSystem>();
				this.EffectNPCCityConveyGameObjectPools[0][num39] = ParticleManager.Instance.Spawn(390, null, Vector3.zero, 1f, false, false, false);
				this.EffectNPCCityConveyTransformPools[0][num39] = this.EffectNPCCityConveyGameObjectPools[0][num39].transform;
				this.EffectNPCCityConveyTransformPools[0][num39].SetParent(this.NPCCityConveyLayoutTransform);
				this.EffectNPCCityConveyTransformPools[0][num39].localPosition = this.inipos;
				this.EffectNPCCityConveyParticlePools[0][num39] = this.EffectNPCCityConveyTransformPools[0][num39].GetChild(0).GetComponent<ParticleSystem>();
				this.EffectNPCCityConveyParticlePools_one[0][num39] = this.EffectNPCCityConveyTransformPools[0][num39].GetChild(1).GetComponent<ParticleSystem>();
				this.EffectNPCCityConveyParticlePools_two[0][num39] = this.EffectNPCCityConveyTransformPools[0][num39].GetChild(2).GetComponent<ParticleSystem>();
				this.EffectNPCCityConveyParticlePools_thr[0][num39] = this.EffectNPCCityConveyTransformPools[0][num39].GetChild(3).GetComponent<ParticleSystem>();
			}
		}
		else
		{
			for (int num40 = 0; num40 < this.EffectWinGameObjectPools[0].Length; num40++)
			{
				this.EffectWinGameObjectPools[0][num40] = ParticleManager.Instance.Spawn(60102, null, Vector3.zero, 1f, false, false, true);
				if (this.EffectWinGameObjectPools[0][num40] == null)
				{
					this.EffectWinGameObjectPools[0][num40] = ParticleManager.Instance.Spawn(198, null, Vector3.zero, 1f, false, false, true);
				}
				this.EffectWinTransformPools[0][num40] = this.EffectWinGameObjectPools[0][num40].transform;
				this.EffectWinTransformPools[0][num40].SetParent(this.WinLayoutTransform);
				this.EffectWinTransformPools[0][num40].localPosition = this.inipos;
				this.EffectWinParticlePools[0][num40] = this.EffectWinTransformPools[0][num40].GetChild(0).GetComponent<ParticleSystem>();
				this.EffectLoseGameObjectPools[0][num40] = ParticleManager.Instance.Spawn(60101, null, Vector3.zero, 1f, false, false, true);
				if (this.EffectLoseGameObjectPools[0][num40] == null)
				{
					this.EffectLoseGameObjectPools[0][num40] = ParticleManager.Instance.Spawn(197, null, Vector3.zero, 1f, false, false, true);
				}
				this.EffectLoseTransformPools[0][num40] = this.EffectLoseGameObjectPools[0][num40].transform;
				this.EffectLoseTransformPools[0][num40].SetParent(this.LoseLayoutTransform);
				this.EffectLoseTransformPools[0][num40].localPosition = this.inipos;
				this.EffectLoseParticlePools[0][num40] = this.EffectLoseTransformPools[0][num40].GetChild(0).GetComponent<ParticleSystem>();
				this.EffectEnemyLoseGameObjectPools[0][num40] = ParticleManager.Instance.Spawn(60110, null, Vector3.zero, 1f, false, false, true);
				if (this.EffectEnemyLoseGameObjectPools[0][num40] == null)
				{
					this.EffectEnemyLoseGameObjectPools[0][num40] = ParticleManager.Instance.Spawn(387, null, Vector3.zero, 1f, false, false, true);
				}
				this.EffectEnemyLoseTransformPools[0][num40] = this.EffectEnemyLoseGameObjectPools[0][num40].transform;
				this.EffectEnemyLoseTransformPools[0][num40].SetParent(this.EnemyLoseLayoutTransform);
				this.EffectEnemyLoseTransformPools[0][num40].localPosition = this.inipos;
				this.EffectEnemyLoseParticlePools[0][num40] = this.EffectEnemyLoseTransformPools[0][num40].GetChild(0).GetComponent<ParticleSystem>();
				this.EffectShieldGameObjectPools[0][num40] = ParticleManager.Instance.Spawn(60103, null, Vector3.zero, 1f, false, false, true);
				if (this.EffectShieldGameObjectPools[0][num40] == null)
				{
					this.EffectShieldGameObjectPools[0][num40] = ParticleManager.Instance.Spawn(199, null, Vector3.zero, 1f, false, false, true);
				}
				this.EffectShieldTransformPools[0][num40] = this.EffectShieldGameObjectPools[0][num40].transform;
				this.EffectShieldTransformPools[0][num40].SetParent(this.ShieldLayoutTransform);
				this.EffectShieldTransformPools[0][num40].localPosition = this.inipos;
				this.EffectShieldParticlePools[0][num40] = this.EffectShieldTransformPools[0][num40].GetChild(0).GetComponent<ParticleSystem>();
				this.EffectShieldParticlePools_one[0][num40] = this.EffectShieldTransformPools[0][num40].GetChild(1).GetComponent<ParticleSystem>();
				this.EffectConveyGameObjectPools[0][num40] = ParticleManager.Instance.Spawn(60111, null, Vector3.zero, 1f, false, false, false);
				if (this.EffectConveyGameObjectPools[0][num40] == null)
				{
					this.EffectConveyGameObjectPools[0][num40] = ParticleManager.Instance.Spawn(332, null, Vector3.zero, 1f, false, false, false);
				}
				this.EffectConveyTransformPools[0][num40] = this.EffectConveyGameObjectPools[0][num40].transform;
				this.EffectConveyTransformPools[0][num40].SetParent(this.ConveyLayoutTransform);
				this.EffectConveyTransformPools[0][num40].localPosition = this.inipos;
				this.EffectConveyParticlePools[0][num40] = this.EffectConveyTransformPools[0][num40].GetChild(0).GetComponent<ParticleSystem>();
				this.EffectConveyParticlePools_one[0][num40] = this.EffectConveyTransformPools[0][num40].GetChild(1).GetComponent<ParticleSystem>();
				this.EffectConveyParticlePools_two[0][num40] = this.EffectConveyTransformPools[0][num40].GetChild(2).GetComponent<ParticleSystem>();
				this.EffectConveyParticlePools_thr[0][num40] = this.EffectConveyTransformPools[0][num40].GetChild(3).GetComponent<ParticleSystem>();
				this.EffectNPCCityConveyGameObjectPools[0][num40] = ParticleManager.Instance.Spawn(60112, null, Vector3.zero, 1f, false, false, false);
				if (this.EffectNPCCityConveyGameObjectPools[0][num40] == null)
				{
					this.EffectNPCCityConveyGameObjectPools[0][num40] = ParticleManager.Instance.Spawn(390, null, Vector3.zero, 1f, false, false, false);
				}
				this.EffectNPCCityConveyTransformPools[0][num40] = this.EffectNPCCityConveyGameObjectPools[0][num40].transform;
				this.EffectNPCCityConveyTransformPools[0][num40].SetParent(this.NPCCityConveyLayoutTransform);
				this.EffectNPCCityConveyTransformPools[0][num40].localPosition = this.inipos;
				this.EffectNPCCityConveyParticlePools[0][num40] = this.EffectNPCCityConveyTransformPools[0][num40].GetChild(0).GetComponent<ParticleSystem>();
				this.EffectNPCCityConveyParticlePools_one[0][num40] = this.EffectNPCCityConveyTransformPools[0][num40].GetChild(1).GetComponent<ParticleSystem>();
				this.EffectNPCCityConveyParticlePools_two[0][num40] = this.EffectNPCCityConveyTransformPools[0][num40].GetChild(2).GetComponent<ParticleSystem>();
				this.EffectNPCCityConveyParticlePools_thr[0][num40] = this.EffectNPCCityConveyTransformPools[0][num40].GetChild(3).GetComponent<ParticleSystem>();
			}
		}
		for (int num41 = 0; num41 < this.EffectWinGameObjectPools[0].Length; num41++)
		{
			this.EffectMapWeaponHurtGameObjectPools[0][num41] = ParticleManager.Instance.Spawn(60601, null, Vector3.zero, 1f, false, false, true);
			this.EffectMapWeaponHurtTransformPools[0][num41] = this.EffectMapWeaponHurtGameObjectPools[0][num41].transform;
			this.EffectMapWeaponHurtTransformPools[0][num41].SetParent(this.MapWeaponHurtLayoutTransform);
			this.EffectMapWeaponHurtTransformPools[0][num41].localPosition = this.inipos;
			for (int num42 = 0; num42 < this.EffectMapWeaponHurtParticlePools.Length; num42++)
			{
				this.EffectMapWeaponHurtParticlePools[num42][0][num41] = this.EffectMapWeaponHurtTransformPools[0][num41].GetChild(num42).GetComponent<ParticleSystem>();
			}
			this.EffectBallDownGameObjectPools[0][num41] = ParticleManager.Instance.Spawn(60501, null, Vector3.zero, 1f, false, false, true);
			this.EffectBallDownTransformPools[0][num41] = this.EffectBallDownGameObjectPools[0][num41].transform;
			this.EffectBallDownTransformPools[0][num41].SetParent(this.BallDownLayoutTransform);
			this.EffectBallDownTransformPools[0][num41].localPosition = this.inipos;
			for (int num43 = 0; num43 < this.EffectBallDownParticlePools.Length; num43++)
			{
				this.EffectBallDownParticlePools[num43][0][num41] = this.EffectBallDownTransformPools[0][num41].GetChild(num43).GetComponent<ParticleSystem>();
			}
			this.EffectBallBigYolkGameObjectPools[0][num41] = ParticleManager.Instance.Spawn(60502, null, Vector3.zero, 1f, false, false, true);
			this.EffectBallBigYolkTransformPools[0][num41] = this.EffectBallBigYolkGameObjectPools[0][num41].transform;
			this.EffectBallBigYolkTransformPools[0][num41].SetParent(this.BallBigYolkLayoutTransform);
			this.EffectBallBigYolkTransformPools[0][num41].localPosition = this.inipos;
			for (int num44 = 0; num44 < this.EffectBallBigYolkParticlePools.Length; num44++)
			{
				this.EffectBallBigYolkParticlePools[num44][0][num41] = this.EffectBallBigYolkTransformPools[0][num41].GetChild(num44).GetComponent<ParticleSystem>();
			}
			this.EffectBallYolkGameObjectPools[0][num41] = ParticleManager.Instance.Spawn(60503, null, Vector3.zero, 1f, false, false, true);
			this.EffectBallYolkTransformPools[0][num41] = this.EffectBallYolkGameObjectPools[0][num41].transform;
			this.EffectBallYolkTransformPools[0][num41].SetParent(this.BallYolkLayoutTransform);
			this.EffectBallYolkTransformPools[0][num41].localPosition = this.inipos;
			for (int num45 = 0; num45 < this.EffectBallYolkParticlePools.Length; num45++)
			{
				this.EffectBallYolkParticlePools[num45][0][num41] = this.EffectBallYolkTransformPools[0][num41].GetChild(num45).GetComponent<ParticleSystem>();
			}
			this.EffectBallNPCCityGameObjectPools[0][num41] = ParticleManager.Instance.Spawn(60504, null, Vector3.zero, 1f, false, false, true);
			this.EffectBallNPCCityTransformPools[0][num41] = this.EffectBallNPCCityGameObjectPools[0][num41].transform;
			this.EffectBallNPCCityTransformPools[0][num41].SetParent(this.BallNPCCityLayoutTransform);
			this.EffectBallNPCCityTransformPools[0][num41].localPosition = this.inipos;
			for (int num46 = 0; num46 < this.EffectBallNPCCityParticlePools.Length; num46++)
			{
				this.EffectBallNPCCityParticlePools[num46][0][num41] = this.EffectBallNPCCityTransformPools[0][num41].GetChild(num46).GetComponent<ParticleSystem>();
			}
			this.EffectBallOutGameObjectPools[0][num41] = ParticleManager.Instance.Spawn(60505, null, Vector3.zero, 1f, false, false, true);
			this.EffectBallOutTransformPools[0][num41] = this.EffectBallOutGameObjectPools[0][num41].transform;
			this.EffectBallOutTransformPools[0][num41].SetParent(this.BallOutLayoutTransform);
			this.EffectBallOutTransformPools[0][num41].localPosition = this.inipos;
			for (int num47 = 0; num47 < this.EffectBallOutParticlePools.Length; num47++)
			{
				this.EffectBallOutParticlePools[num47][0][num41] = this.EffectBallOutTransformPools[0][num41].GetChild(num47).GetComponent<ParticleSystem>();
			}
			this.EffectBallKickGameObjectPools[0][num41] = ParticleManager.Instance.Spawn(60506, null, Vector3.zero, 1f, false, false, true);
			this.EffectBallKickTransformPools[0][num41] = this.EffectBallKickGameObjectPools[0][num41].transform;
			this.EffectBallKickTransformPools[0][num41].SetParent(this.BallKickLayoutTransform);
			this.EffectBallKickTransformPools[0][num41].localPosition = this.inipos;
			for (int num48 = 0; num48 < this.EffectBallKickParticlePools.Length; num48++)
			{
				this.EffectBallKickParticlePools[num48][0][num41] = this.EffectBallKickTransformPools[0][num41].GetChild(num48).GetComponent<ParticleSystem>();
			}
		}
		this.WinstartSize = this.EffectWinParticlePools[0][0].startSize;
		this.Winlifetime = this.EffectWinParticlePools[0][0].startLifetime;
		this.LosestartSize = this.EffectLoseParticlePools[0][0].startSize;
		this.Loselifetime = this.EffectLoseParticlePools[0][0].startLifetime;
		this.EnemyLosestartSize = this.EffectEnemyLoseParticlePools[0][0].startSize;
		this.EnemyLoselifetime = this.EffectEnemyLoseParticlePools[0][0].startLifetime;
		this.ShieldstartSize = this.EffectShieldParticlePools[0][0].startSize;
		this.ConveystartSize = this.EffectConveyParticlePools[0][0].startSize;
		this.Conveylifetime = this.EffectConveyParticlePools[0][0].startLifetime;
		this.ConveystartSize_one = this.EffectConveyParticlePools_one[0][0].startSize;
		this.Conveylifetime_one = this.EffectConveyParticlePools_one[0][0].startLifetime;
		this.ConveystartSize_two = this.EffectConveyParticlePools_two[0][0].startSize;
		this.Conveylifetime_two = this.EffectConveyParticlePools_two[0][0].startLifetime;
		this.ConveystartSize_thr = this.EffectConveyParticlePools_thr[0][0].startSize;
		this.Conveylifetime_thr = this.EffectConveyParticlePools_thr[0][0].startLifetime;
		this.NPCCityConveystartSize = this.EffectNPCCityConveyParticlePools[0][0].startSize;
		this.NPCCityConveylifetime = this.EffectNPCCityConveyParticlePools[0][0].startLifetime;
		this.NPCCityConveystartSize_one = this.EffectNPCCityConveyParticlePools_one[0][0].startSize;
		this.NPCCityConveylifetime_one = this.EffectNPCCityConveyParticlePools_one[0][0].startLifetime;
		this.NPCCityConveystartSize_two = this.EffectNPCCityConveyParticlePools_two[0][0].startSize;
		this.NPCCityConveylifetime_two = this.EffectNPCCityConveyParticlePools_two[0][0].startLifetime;
		this.NPCCityConveystartSize_thr = this.EffectNPCCityConveyParticlePools_thr[0][0].startSize;
		this.NPCCityConveylifetime_thr = this.EffectNPCCityConveyParticlePools_thr[0][0].startLifetime;
		for (int num49 = 0; num49 < this.MapWeaponHurtlifetime.Length; num49++)
		{
			this.MapWeaponHurtlifetime[num49] = this.EffectMapWeaponHurtParticlePools[num49][0][0].startLifetime;
			this.MapWeaponHurtstartSize[num49] = this.EffectMapWeaponHurtParticlePools[num49][0][0].startSize;
		}
		for (int num50 = 0; num50 < this.BallDownlifetime.Length; num50++)
		{
			this.BallDownlifetime[num50] = this.EffectBallDownParticlePools[num50][0][0].startLifetime;
			this.BallDownstartSize[num50] = this.EffectBallDownParticlePools[num50][0][0].startSize;
		}
		for (int num51 = 0; num51 < this.BallBigYolklifetime.Length; num51++)
		{
			this.BallBigYolklifetime[num51] = this.EffectBallBigYolkParticlePools[num51][0][0].startLifetime;
			this.BallBigYolkstartSize[num51] = this.EffectBallBigYolkParticlePools[num51][0][0].startSize;
		}
		for (int num52 = 0; num52 < this.BallYolklifetime.Length; num52++)
		{
			this.BallYolklifetime[num52] = this.EffectBallYolkParticlePools[num52][0][0].startLifetime;
			this.BallYolkstartSize[num52] = this.EffectBallYolkParticlePools[num52][0][0].startSize;
		}
		for (int num53 = 0; num53 < this.BallNPCCitylifetime.Length; num53++)
		{
			this.BallNPCCitylifetime[num53] = this.EffectBallNPCCityParticlePools[num53][0][0].startLifetime;
			this.BallNPCCitystartSize[num53] = this.EffectBallNPCCityParticlePools[num53][0][0].startSize;
		}
		for (int num54 = 0; num54 < this.BallOutlifetime.Length; num54++)
		{
			this.BallOutlifetime[num54] = this.EffectBallOutParticlePools[num54][0][0].startLifetime;
			this.BallOutstartSize[num54] = this.EffectBallOutParticlePools[num54][0][0].startSize;
		}
		for (int num55 = 0; num55 < this.BallKicklifetime.Length; num55++)
		{
			this.BallKicklifetime[num55] = this.EffectBallKickParticlePools[num55][0][0].startLifetime;
			this.BallKickstartSize[num55] = this.EffectBallKickParticlePools[num55][0][0].startSize;
		}
		this.WinpoolCounter[0] = colNum >> 1;
		this.WinpoolsCounter = 1;
		this.LosepoolCounter[0] = colNum >> 1;
		this.LosepoolsCounter = 1;
		this.EnemyLosepoolCounter[0] = colNum >> 1;
		this.EnemyLosepoolsCounter = 1;
		this.ShieldpoolCounter[0] = colNum >> 1;
		this.ShieldpoolsCounter = 1;
		this.ConveypoolCounter[0] = colNum >> 1;
		this.ConveypoolsCounter = 1;
		this.NPCCityConveypoolCounter[0] = colNum >> 1;
		this.NPCCityConveypoolsCounter = 1;
		this.MapWeaponHurtpoolCounter[0] = colNum >> 1;
		this.MapWeaponHurtpoolsCounter = 1;
		this.BallDownpoolCounter[0] = colNum >> 1;
		this.BallDownpoolsCounter = 1;
		this.BallBigYolkpoolCounter[0] = colNum >> 1;
		this.BallBigYolkpoolsCounter = 1;
		this.BallYolkpoolCounter[0] = colNum >> 1;
		this.BallYolkpoolsCounter = 1;
		this.BallNPCCitypoolCounter[0] = colNum >> 1;
		this.BallNPCCitypoolsCounter = 1;
		this.BallOutpoolCounter[0] = colNum >> 1;
		this.BallOutpoolsCounter = 1;
		this.BallKickpoolCounter[0] = colNum >> 1;
		this.BallKickpoolsCounter = 1;
	}

	// Token: 0x06000B3D RID: 2877 RVA: 0x000F90CC File Offset: 0x000F72CC
	public void setEffect(byte effectflag, int row, int col, Vector2 pos, byte effecttype = 0)
	{
		float x = this.RealmGroup.localScale.x;
		if (effecttype > 0 && effecttype < 3)
		{
			if (effectflag == 0)
			{
				this.Yolkrow = (this.Yolkcol = -1);
				if (this.EffectYolkWinGameObject.activeSelf)
				{
					this.EffectYolkWinGameObject.SetActive(false);
				}
				if (this.EffectYolkLoseGameObject.activeSelf)
				{
					this.EffectYolkLoseGameObject.SetActive(false);
				}
				if (this.EffectYolkShieldGameObject.activeSelf)
				{
					this.EffectYolkShieldGameObject.SetActive(false);
				}
				if (this.EffectBigYolkWinGameObject.activeSelf)
				{
					this.EffectBigYolkWinGameObject.SetActive(false);
				}
				if (this.EffectBigYolkLoseGameObject.activeSelf)
				{
					this.EffectBigYolkLoseGameObject.SetActive(false);
				}
				if (this.EffectBigYolkShieldGameObject.activeSelf)
				{
					this.EffectBigYolkShieldGameObject.SetActive(false);
				}
			}
			else
			{
				bool flag = false;
				this.Yolkrow = row;
				this.Yolkcol = col;
				if ((effectflag & 2) == 0)
				{
					if (this.EffectYolkWinGameObject.activeSelf)
					{
						this.EffectYolkWinGameObject.SetActive(false);
					}
					if (this.EffectBigYolkWinGameObject.activeSelf)
					{
						this.EffectBigYolkWinGameObject.SetActive(false);
					}
				}
				else if (effecttype == 1)
				{
					if (this.EffectBigYolkWinGameObject.activeSelf)
					{
						this.EffectBigYolkWinGameObject.SetActive(false);
					}
					if (!this.EffectYolkWinGameObject.activeSelf)
					{
						this.EffectYolkWinParticle.startSize = this.YolkWinstartSize * x;
						this.EffectYolkWinParticle_one.startSize = this.YolkWinstartSize_one * x;
						this.EffectYolkWinParticle_two.startSize = this.YolkWinstartSize_two * x;
						this.EffectYolkWinParticle_thr.startSize = this.YolkWinstartSize_thr * x;
						this.EffectYolkWinParticle_tho.startSize = this.YolkWinstartSize_tho * x;
						this.EffectYolkWinParticle.startLifetime = this.YolkWinlifetime * x;
						this.EffectYolkWinParticle_one.startLifetime = this.YolkWinlifetime_one * x;
						this.EffectYolkWinParticle_two.startLifetime = this.YolkWinlifetime_two * x;
						this.EffectYolkWinParticle_thr.startLifetime = this.YolkWinstartSize_thr * x;
						this.EffectYolkWinParticle_tho.startLifetime = this.YolkWinstartSize_tho * x;
						this.EffectYolkWinGameObject.SetActive(true);
						flag = true;
					}
					this.EffectYolkWinTransform.localPosition = pos;
				}
				else
				{
					if (this.EffectYolkWinGameObject.activeSelf)
					{
						this.EffectYolkWinGameObject.SetActive(false);
					}
					if (!this.EffectBigYolkWinGameObject.activeSelf)
					{
						this.EffectBigYolkWinParticle.startSize = this.BigYolkWinstartSize * x;
						this.EffectBigYolkWinParticle_one.startSize = this.BigYolkWinstartSize_one * x;
						this.EffectBigYolkWinParticle_two.startSize = this.BigYolkWinstartSize_two * x;
						this.EffectBigYolkWinParticle_thr.startSize = this.BigYolkWinstartSize_thr * x;
						this.EffectBigYolkWinParticle_for.startSize = this.BigYolkWinstartSize_for * x;
						this.EffectBigYolkWinParticle.startLifetime = this.BigYolkWinlifetime * x;
						this.EffectBigYolkWinParticle_one.startLifetime = this.BigYolkWinlifetime_one * x;
						this.EffectBigYolkWinParticle_two.startLifetime = this.BigYolkWinlifetime_two * x;
						this.EffectBigYolkWinParticle_thr.startLifetime = this.BigYolkWinlifetime_thr * x;
						this.EffectBigYolkWinParticle_for.startLifetime = this.BigYolkWinlifetime_for * x;
						this.EffectBigYolkWinGameObject.SetActive(true);
						flag = true;
					}
					this.EffectBigYolkWinTransform.localPosition = pos;
				}
				if ((effectflag & 1) == 0)
				{
					if (this.EffectYolkLoseGameObject.activeSelf)
					{
						this.EffectYolkLoseGameObject.SetActive(false);
					}
					if (this.EffectBigYolkLoseGameObject.activeSelf)
					{
						this.EffectBigYolkLoseGameObject.SetActive(false);
					}
				}
				else if (effecttype == 1)
				{
					if (this.EffectBigYolkLoseGameObject.activeSelf)
					{
						this.EffectBigYolkLoseGameObject.SetActive(false);
					}
					if (!this.EffectYolkLoseGameObject.activeSelf)
					{
						this.EffectYolkLoseParticle.startSize = this.YolkLosestartSize * x;
						this.EffectYolkLoseParticle_one.startSize = this.YolkLosestartSize_one * x;
						this.EffectYolkLoseParticle.startLifetime = this.YolkLoselifetime * x;
						this.EffectYolkLoseParticle_one.startLifetime = this.YolkLoselifetime_one * x;
						this.EffectYolkLoseGameObject.SetActive(true);
						flag = true;
					}
					this.EffectYolkLoseTransform.localPosition = pos;
				}
				else
				{
					if (this.EffectYolkLoseGameObject.activeSelf)
					{
						this.EffectYolkLoseGameObject.SetActive(false);
					}
					if (!this.EffectBigYolkLoseGameObject.activeSelf)
					{
						this.EffectBigYolkLoseParticle.startSize = this.BigYolkLosestartSize * x;
						this.EffectBigYolkLoseParticle_one.startSize = this.BigYolkLosestartSize_one * x;
						this.EffectBigYolkLoseParticle_two.startSize = this.BigYolkLosestartSize_two * x;
						this.EffectBigYolkLoseParticle.startLifetime = this.BigYolkLoselifetime * x;
						this.EffectBigYolkLoseParticle_one.startLifetime = this.BigYolkLoselifetime_one * x;
						this.EffectBigYolkLoseParticle_two.startLifetime = this.BigYolkLoselifetime_two * x;
						this.EffectBigYolkLoseGameObject.SetActive(true);
						flag = true;
					}
					this.EffectBigYolkLoseTransform.localPosition = pos;
				}
				if ((effectflag & 4) == 0)
				{
					if (this.EffectYolkShieldGameObject.activeSelf)
					{
						this.EffectYolkShieldGameObject.SetActive(false);
					}
					if (this.EffectBigYolkShieldGameObject.activeSelf)
					{
						this.EffectBigYolkShieldGameObject.SetActive(false);
					}
				}
				else if (effecttype == 1)
				{
					if (this.EffectBigYolkShieldGameObject.activeSelf)
					{
						this.EffectBigYolkShieldGameObject.SetActive(false);
					}
					if (!this.EffectYolkShieldGameObject.activeSelf)
					{
						this.EffectYolkShieldParticle.startSize = this.YolkShieldstartSize * x;
						this.EffectYolkShieldParticle_one.startSize = this.YolkShieldstartSize_one * x;
						this.EffectYolkShieldParticle_two.startSize = this.YolkShieldstartSize_two * x * this.YolkShieldScale;
						this.EffectYolkShieldParticle_thr.startSize = this.YolkShieldstartSize_thr * x * this.YolkShieldScale;
						this.EffectYolkShieldParticle.startLifetime = this.YolkShieldlifetime * x;
						this.EffectYolkShieldParticle_one.startLifetime = this.YolkShieldlifetime_one * x;
						this.EffectYolkShieldGameObject.SetActive(true);
						flag = true;
					}
					this.EffectYolkShieldTransform.localPosition = pos;
				}
				else
				{
					if (this.EffectYolkShieldGameObject.activeSelf)
					{
						this.EffectYolkShieldGameObject.SetActive(false);
					}
					if (!this.EffectBigYolkShieldGameObject.activeSelf)
					{
						this.EffectBigYolkShieldParticle.startSize = this.BigYolkShieldstartSize * x;
						this.EffectBigYolkShieldParticle_one.startSize = this.BigYolkShieldstartSize_one * x;
						this.EffectBigYolkShieldParticle_two.startSize = this.BigYolkShieldstartSize_two * x * this.YolkShieldScale;
						this.EffectBigYolkShieldParticle_thr.startSize = this.BigYolkShieldstartSize_thr * x * this.YolkShieldScale;
						this.EffectBigYolkShieldParticle.startLifetime = this.BigYolkShieldlifetime * x;
						this.EffectBigYolkShieldParticle_one.startLifetime = this.BigYolkShieldlifetime_one * x;
						this.EffectBigYolkShieldGameObject.SetActive(true);
						flag = true;
					}
					this.EffectBigYolkShieldTransform.localPosition = pos;
				}
				if (flag)
				{
					this.setEffect(row, col, DataManager.MapDataController.zoomSize);
				}
			}
			effectflag = 0;
		}
		else if (row == this.Yolkrow && col == this.Yolkcol && (effecttype < 5 || effecttype == 11))
		{
			this.Yolkrow = (this.Yolkcol = -1);
			if (this.EffectYolkWinGameObject.activeSelf)
			{
				this.EffectYolkWinGameObject.SetActive(false);
			}
			if (this.EffectYolkLoseGameObject.activeSelf)
			{
				this.EffectYolkLoseGameObject.SetActive(false);
			}
			if (this.EffectYolkShieldGameObject.activeSelf)
			{
				this.EffectYolkShieldGameObject.SetActive(false);
			}
			if (this.EffectBigYolkWinGameObject.activeSelf)
			{
				this.EffectBigYolkWinGameObject.SetActive(false);
			}
			if (this.EffectBigYolkLoseGameObject.activeSelf)
			{
				this.EffectBigYolkLoseGameObject.SetActive(false);
			}
			if (this.EffectBigYolkShieldGameObject.activeSelf)
			{
				this.EffectBigYolkShieldGameObject.SetActive(false);
			}
		}
		if (effecttype < 5 || effecttype == 11)
		{
			if ((effectflag & 1) == 0)
			{
				if (this.EffectWinGameObject[col][row] != null)
				{
					this.EffectWinGameObject[col][row].SetActive(false);
					for (int i = 0; i < this.WinpoolsCounter; i++)
					{
						if (this.WinpoolCounter[i] < this.EffectWinGameObjectPools[i].Length)
						{
							this.EffectWinGameObjectPools[i][this.WinpoolCounter[i]] = this.EffectWinGameObject[col][row];
							this.EffectWinTransformPools[i][this.WinpoolCounter[i]] = this.EffectWinTransform[col][row];
							this.EffectWinParticlePools[i][this.WinpoolCounter[i]] = this.EffectWinParticle[col][row];
							this.EffectWinGameObject[col][row] = null;
							this.EffectWinTransform[col][row] = null;
							this.EffectWinParticle[col][row] = null;
							this.WinpoolCounter[i]++;
							break;
						}
					}
				}
			}
			else
			{
				if (this.EffectWinGameObject[col][row] == null)
				{
					int j;
					for (j = 0; j < this.WinpoolsCounter; j++)
					{
						if (this.WinpoolCounter[j] > 0)
						{
							this.WinpoolCounter[j]--;
							this.EffectWinGameObject[col][row] = this.EffectWinGameObjectPools[j][this.WinpoolCounter[j]];
							this.EffectWinTransform[col][row] = this.EffectWinTransformPools[j][this.WinpoolCounter[j]];
							this.EffectWinParticle[col][row] = this.EffectWinParticlePools[j][this.WinpoolCounter[j]];
							this.EffectWinGameObjectPools[j][this.WinpoolCounter[j]] = null;
							this.EffectWinTransformPools[j][this.WinpoolCounter[j]] = null;
							this.EffectWinParticlePools[j][this.WinpoolCounter[j]] = null;
							this.setEffect(row, col, DataManager.MapDataController.zoomSize);
							break;
						}
					}
					if (j == this.WinpoolsCounter)
					{
						this.EffectWinGameObjectPools[j] = new GameObject[this.EffectWinGameObjectPools[0].Length];
						this.EffectWinTransformPools[j] = new Transform[this.EffectWinTransformPools[0].Length];
						this.EffectWinParticlePools[j] = new ParticleSystem[this.EffectWinParticlePools[0].Length];
						if (this.bBack == 1)
						{
							for (int k = 0; k < this.EffectWinGameObjectPools[j].Length; k++)
							{
								this.EffectWinGameObjectPools[j][k] = ParticleManager.Instance.Spawn(198, null, Vector3.zero, 1f, false, false, true);
								this.EffectWinTransformPools[j][k] = this.EffectWinGameObjectPools[j][k].transform;
								this.EffectWinTransformPools[j][k].SetParent(this.WinLayoutTransform, false);
								this.EffectWinTransformPools[j][k].localPosition = this.inipos;
								this.EffectWinParticlePools[j][k] = this.EffectWinTransformPools[j][k].GetChild(0).GetComponent<ParticleSystem>();
							}
						}
						else
						{
							for (int l = 0; l < this.EffectWinGameObjectPools[j].Length; l++)
							{
								this.EffectWinGameObjectPools[j][l] = ParticleManager.Instance.Spawn(60102, null, Vector3.zero, 1f, false, false, true);
								if (this.EffectWinGameObjectPools[j][l] == null)
								{
									this.EffectWinGameObjectPools[j][l] = ParticleManager.Instance.Spawn(198, null, Vector3.zero, 1f, false, false, true);
								}
								this.EffectWinTransformPools[j][l] = this.EffectWinGameObjectPools[j][l].transform;
								this.EffectWinTransformPools[j][l].SetParent(this.WinLayoutTransform, false);
								this.EffectWinTransformPools[j][l].localPosition = this.inipos;
								this.EffectWinParticlePools[j][l] = this.EffectWinTransformPools[j][l].GetChild(0).GetComponent<ParticleSystem>();
							}
						}
						this.WinpoolsCounter++;
						this.WinpoolCounter[j] = this.EffectWinGameObjectPools[j].Length;
						this.WinpoolCounter[j]--;
						this.EffectWinGameObject[col][row] = this.EffectWinGameObjectPools[j][this.WinpoolCounter[j]];
						this.EffectWinTransform[col][row] = this.EffectWinTransformPools[j][this.WinpoolCounter[j]];
						this.EffectWinParticle[col][row] = this.EffectWinParticlePools[j][this.WinpoolCounter[j]];
						this.EffectWinParticle[col][row].startSize = this.WinstartSize * x;
						this.EffectWinParticle[col][row].startLifetime = this.Winlifetime * x;
						this.EffectWinGameObjectPools[j][this.WinpoolCounter[j]] = null;
						this.EffectWinTransformPools[j][this.WinpoolCounter[j]] = null;
						this.EffectWinParticlePools[j][this.WinpoolCounter[j]] = null;
					}
					this.EffectWinGameObject[col][row].SetActive(true);
				}
				this.EffectWinTransform[col][row].localPosition = pos;
			}
			if ((effectflag & 2) == 0)
			{
				if (this.EffectLoseGameObject[col][row] != null)
				{
					this.EffectLoseGameObject[col][row].SetActive(false);
					for (int m = 0; m < this.LosepoolsCounter; m++)
					{
						if (this.LosepoolCounter[m] < this.EffectLoseGameObjectPools[m].Length)
						{
							this.EffectLoseGameObjectPools[m][this.LosepoolCounter[m]] = this.EffectLoseGameObject[col][row];
							this.EffectLoseTransformPools[m][this.LosepoolCounter[m]] = this.EffectLoseTransform[col][row];
							this.EffectLoseParticlePools[m][this.LosepoolCounter[m]] = this.EffectLoseParticle[col][row];
							this.EffectLoseGameObject[col][row] = null;
							this.EffectLoseTransform[col][row] = null;
							this.EffectLoseParticle[col][row] = null;
							this.LosepoolCounter[m]++;
							break;
						}
					}
				}
				if (this.EffectEnemyLoseGameObject[col][row] != null)
				{
					this.EffectEnemyLoseGameObject[col][row].SetActive(false);
					for (int n = 0; n < this.EnemyLosepoolsCounter; n++)
					{
						if (this.EnemyLosepoolCounter[n] < this.EffectEnemyLoseGameObjectPools[n].Length)
						{
							this.EffectEnemyLoseGameObjectPools[n][this.EnemyLosepoolCounter[n]] = this.EffectEnemyLoseGameObject[col][row];
							this.EffectEnemyLoseTransformPools[n][this.EnemyLosepoolCounter[n]] = this.EffectEnemyLoseTransform[col][row];
							this.EffectEnemyLoseParticlePools[n][this.EnemyLosepoolCounter[n]] = this.EffectEnemyLoseParticle[col][row];
							this.EffectEnemyLoseGameObject[col][row] = null;
							this.EffectEnemyLoseTransform[col][row] = null;
							this.EffectEnemyLoseParticle[col][row] = null;
							this.EnemyLosepoolCounter[n]++;
							break;
						}
					}
				}
			}
			else if ((effectflag & 64) == 0)
			{
				if (this.EffectEnemyLoseGameObject[col][row] != null)
				{
					this.EffectEnemyLoseGameObject[col][row].SetActive(false);
					for (int num = 0; num < this.EnemyLosepoolsCounter; num++)
					{
						if (this.EnemyLosepoolCounter[num] < this.EffectEnemyLoseGameObjectPools[num].Length)
						{
							this.EffectEnemyLoseGameObjectPools[num][this.EnemyLosepoolCounter[num]] = this.EffectEnemyLoseGameObject[col][row];
							this.EffectEnemyLoseTransformPools[num][this.EnemyLosepoolCounter[num]] = this.EffectEnemyLoseTransform[col][row];
							this.EffectEnemyLoseParticlePools[num][this.EnemyLosepoolCounter[num]] = this.EffectEnemyLoseParticle[col][row];
							this.EffectEnemyLoseGameObject[col][row] = null;
							this.EffectEnemyLoseTransform[col][row] = null;
							this.EffectEnemyLoseParticle[col][row] = null;
							this.EnemyLosepoolCounter[num]++;
							break;
						}
					}
				}
				if (this.EffectLoseGameObject[col][row] == null)
				{
					int num2;
					for (num2 = 0; num2 < this.LosepoolsCounter; num2++)
					{
						if (this.LosepoolCounter[num2] > 0)
						{
							this.LosepoolCounter[num2]--;
							this.EffectLoseGameObject[col][row] = this.EffectLoseGameObjectPools[num2][this.LosepoolCounter[num2]];
							this.EffectLoseTransform[col][row] = this.EffectLoseTransformPools[num2][this.LosepoolCounter[num2]];
							this.EffectLoseParticle[col][row] = this.EffectLoseParticlePools[num2][this.LosepoolCounter[num2]];
							this.EffectLoseGameObjectPools[num2][this.LosepoolCounter[num2]] = null;
							this.EffectLoseTransformPools[num2][this.LosepoolCounter[num2]] = null;
							this.EffectLoseParticlePools[num2][this.LosepoolCounter[num2]] = null;
							this.setEffect(row, col, DataManager.MapDataController.zoomSize);
							break;
						}
					}
					if (num2 == this.LosepoolsCounter)
					{
						this.EffectLoseGameObjectPools[num2] = new GameObject[this.EffectLoseGameObjectPools[0].Length];
						this.EffectLoseTransformPools[num2] = new Transform[this.EffectLoseTransformPools[0].Length];
						this.EffectLoseParticlePools[num2] = new ParticleSystem[this.EffectLoseParticlePools[0].Length];
						if (this.bBack == 1)
						{
							for (int num3 = 0; num3 < this.EffectLoseGameObjectPools[num2].Length; num3++)
							{
								this.EffectLoseGameObjectPools[num2][num3] = ParticleManager.Instance.Spawn(197, null, Vector3.zero, 1f, false, false, true);
								this.EffectLoseTransformPools[num2][num3] = this.EffectLoseGameObjectPools[num2][num3].transform;
								this.EffectLoseTransformPools[num2][num3].SetParent(this.LoseLayoutTransform, false);
								this.EffectLoseTransformPools[num2][num3].localPosition = this.inipos;
								this.EffectLoseParticlePools[num2][num3] = this.EffectLoseTransformPools[num2][num3].GetChild(0).GetComponent<ParticleSystem>();
							}
						}
						else
						{
							for (int num4 = 0; num4 < this.EffectLoseGameObjectPools[num2].Length; num4++)
							{
								this.EffectLoseGameObjectPools[num2][num4] = ParticleManager.Instance.Spawn(60101, null, Vector3.zero, 1f, false, false, true);
								if (this.EffectLoseGameObjectPools[num2][num4] == null)
								{
									this.EffectLoseGameObjectPools[num2][num4] = ParticleManager.Instance.Spawn(197, null, Vector3.zero, 1f, false, false, true);
								}
								this.EffectLoseTransformPools[num2][num4] = this.EffectLoseGameObjectPools[num2][num4].transform;
								this.EffectLoseTransformPools[num2][num4].SetParent(this.LoseLayoutTransform, false);
								this.EffectLoseTransformPools[num2][num4].localPosition = this.inipos;
								this.EffectLoseParticlePools[num2][num4] = this.EffectLoseTransformPools[num2][num4].GetChild(0).GetComponent<ParticleSystem>();
							}
						}
						this.LosepoolsCounter++;
						this.LosepoolCounter[num2] = this.EffectLoseGameObjectPools[num2].Length;
						this.LosepoolCounter[num2]--;
						this.EffectLoseGameObject[col][row] = this.EffectLoseGameObjectPools[num2][this.LosepoolCounter[num2]];
						this.EffectLoseTransform[col][row] = this.EffectLoseTransformPools[num2][this.LosepoolCounter[num2]];
						this.EffectLoseParticle[col][row] = this.EffectLoseParticlePools[num2][this.LosepoolCounter[num2]];
						this.EffectLoseParticle[col][row].startSize = this.LosestartSize * x;
						this.EffectLoseParticle[col][row].startLifetime = this.Loselifetime * x;
						this.EffectLoseGameObjectPools[num2][this.LosepoolCounter[num2]] = null;
						this.EffectLoseTransformPools[num2][this.LosepoolCounter[num2]] = null;
						this.EffectLoseParticlePools[num2][this.LosepoolCounter[num2]] = null;
					}
					this.EffectLoseGameObject[col][row].SetActive(true);
				}
				this.EffectLoseTransform[col][row].localPosition = pos;
			}
			else
			{
				if (this.EffectLoseGameObject[col][row] != null)
				{
					this.EffectLoseGameObject[col][row].SetActive(false);
					for (int num5 = 0; num5 < this.LosepoolsCounter; num5++)
					{
						if (this.LosepoolCounter[num5] < this.EffectLoseGameObjectPools[num5].Length)
						{
							this.EffectLoseGameObjectPools[num5][this.LosepoolCounter[num5]] = this.EffectLoseGameObject[col][row];
							this.EffectLoseTransformPools[num5][this.LosepoolCounter[num5]] = this.EffectLoseTransform[col][row];
							this.EffectLoseParticlePools[num5][this.LosepoolCounter[num5]] = this.EffectLoseParticle[col][row];
							this.EffectLoseGameObject[col][row] = null;
							this.EffectLoseTransform[col][row] = null;
							this.EffectLoseParticle[col][row] = null;
							this.LosepoolCounter[num5]++;
							break;
						}
					}
				}
				if (this.EffectEnemyLoseGameObject[col][row] == null)
				{
					int num6;
					for (num6 = 0; num6 < this.EnemyLosepoolsCounter; num6++)
					{
						if (this.EnemyLosepoolCounter[num6] > 0)
						{
							this.EnemyLosepoolCounter[num6]--;
							this.EffectEnemyLoseGameObject[col][row] = this.EffectEnemyLoseGameObjectPools[num6][this.EnemyLosepoolCounter[num6]];
							this.EffectEnemyLoseTransform[col][row] = this.EffectEnemyLoseTransformPools[num6][this.EnemyLosepoolCounter[num6]];
							this.EffectEnemyLoseParticle[col][row] = this.EffectEnemyLoseParticlePools[num6][this.EnemyLosepoolCounter[num6]];
							this.EffectEnemyLoseGameObjectPools[num6][this.EnemyLosepoolCounter[num6]] = null;
							this.EffectEnemyLoseTransformPools[num6][this.EnemyLosepoolCounter[num6]] = null;
							this.EffectEnemyLoseParticlePools[num6][this.EnemyLosepoolCounter[num6]] = null;
							this.setEffect(row, col, DataManager.MapDataController.zoomSize);
							break;
						}
					}
					if (num6 == this.EnemyLosepoolsCounter)
					{
						this.EffectEnemyLoseGameObjectPools[num6] = new GameObject[this.EffectEnemyLoseGameObjectPools[0].Length];
						this.EffectEnemyLoseTransformPools[num6] = new Transform[this.EffectEnemyLoseTransformPools[0].Length];
						this.EffectEnemyLoseParticlePools[num6] = new ParticleSystem[this.EffectEnemyLoseParticlePools[0].Length];
						if (this.bBack == 1)
						{
							for (int num7 = 0; num7 < this.EffectEnemyLoseGameObjectPools[num6].Length; num7++)
							{
								this.EffectEnemyLoseGameObjectPools[num6][num7] = ParticleManager.Instance.Spawn(387, null, Vector3.zero, 1f, false, false, true);
								this.EffectEnemyLoseTransformPools[num6][num7] = this.EffectEnemyLoseGameObjectPools[num6][num7].transform;
								this.EffectEnemyLoseTransformPools[num6][num7].SetParent(this.EnemyLoseLayoutTransform, false);
								this.EffectEnemyLoseTransformPools[num6][num7].localPosition = this.inipos;
								this.EffectEnemyLoseParticlePools[num6][num7] = this.EffectEnemyLoseTransformPools[num6][num7].GetChild(0).GetComponent<ParticleSystem>();
							}
						}
						else
						{
							for (int num8 = 0; num8 < this.EffectEnemyLoseGameObjectPools[num6].Length; num8++)
							{
								this.EffectEnemyLoseGameObjectPools[num6][num8] = ParticleManager.Instance.Spawn(60110, null, Vector3.zero, 1f, false, false, true);
								if (this.EffectEnemyLoseGameObjectPools[num6][num8] == null)
								{
									this.EffectEnemyLoseGameObjectPools[num6][num8] = ParticleManager.Instance.Spawn(387, null, Vector3.zero, 1f, false, false, true);
								}
								this.EffectEnemyLoseTransformPools[num6][num8] = this.EffectEnemyLoseGameObjectPools[num6][num8].transform;
								this.EffectEnemyLoseTransformPools[num6][num8].SetParent(this.EnemyLoseLayoutTransform, false);
								this.EffectEnemyLoseTransformPools[num6][num8].localPosition = this.inipos;
								this.EffectEnemyLoseParticlePools[num6][num8] = this.EffectEnemyLoseTransformPools[num6][num8].GetChild(0).GetComponent<ParticleSystem>();
							}
						}
						this.EnemyLosepoolsCounter++;
						this.EnemyLosepoolCounter[num6] = this.EffectEnemyLoseGameObjectPools[num6].Length;
						this.EnemyLosepoolCounter[num6]--;
						this.EffectEnemyLoseGameObject[col][row] = this.EffectEnemyLoseGameObjectPools[num6][this.EnemyLosepoolCounter[num6]];
						this.EffectEnemyLoseTransform[col][row] = this.EffectEnemyLoseTransformPools[num6][this.EnemyLosepoolCounter[num6]];
						this.EffectEnemyLoseParticle[col][row] = this.EffectEnemyLoseParticlePools[num6][this.EnemyLosepoolCounter[num6]];
						this.EffectEnemyLoseParticle[col][row].startSize = this.EnemyLosestartSize * x;
						this.EffectEnemyLoseParticle[col][row].startLifetime = this.EnemyLoselifetime * x;
						this.EffectEnemyLoseGameObjectPools[num6][this.EnemyLosepoolCounter[num6]] = null;
						this.EffectEnemyLoseTransformPools[num6][this.EnemyLosepoolCounter[num6]] = null;
						this.EffectEnemyLoseParticlePools[num6][this.EnemyLosepoolCounter[num6]] = null;
					}
					this.EffectEnemyLoseGameObject[col][row].SetActive(true);
				}
				this.EffectEnemyLoseTransform[col][row].localPosition = pos;
			}
			if ((effectflag & 4) == 0)
			{
				if (this.EffectShieldGameObject[col][row] != null)
				{
					this.EffectShieldGameObject[col][row].SetActive(false);
					for (int num9 = 0; num9 < this.ShieldpoolsCounter; num9++)
					{
						if (this.ShieldpoolCounter[num9] < this.EffectShieldGameObjectPools[num9].Length)
						{
							this.EffectShieldGameObjectPools[num9][this.ShieldpoolCounter[num9]] = this.EffectShieldGameObject[col][row];
							this.EffectShieldTransformPools[num9][this.ShieldpoolCounter[num9]] = this.EffectShieldTransform[col][row];
							this.EffectShieldParticlePools[num9][this.ShieldpoolCounter[num9]] = this.EffectShieldParticle[col][row];
							this.EffectShieldParticlePools_one[num9][this.ShieldpoolCounter[num9]] = this.EffectShieldParticle_one[col][row];
							this.EffectShieldGameObject[col][row] = null;
							this.EffectShieldTransform[col][row] = null;
							this.EffectShieldParticle[col][row] = null;
							this.EffectShieldParticle_one[col][row] = null;
							this.ShieldpoolCounter[num9]++;
							break;
						}
					}
				}
			}
			else
			{
				if (this.EffectShieldGameObject[col][row] == null)
				{
					int num10;
					for (num10 = 0; num10 < this.ShieldpoolsCounter; num10++)
					{
						if (this.ShieldpoolCounter[num10] > 0)
						{
							this.ShieldpoolCounter[num10]--;
							this.EffectShieldGameObject[col][row] = this.EffectShieldGameObjectPools[num10][this.ShieldpoolCounter[num10]];
							this.EffectShieldTransform[col][row] = this.EffectShieldTransformPools[num10][this.ShieldpoolCounter[num10]];
							this.EffectShieldParticle[col][row] = this.EffectShieldParticlePools[num10][this.ShieldpoolCounter[num10]];
							this.EffectShieldParticle_one[col][row] = this.EffectShieldParticlePools_one[num10][this.ShieldpoolCounter[num10]];
							this.EffectShieldGameObjectPools[num10][this.ShieldpoolCounter[num10]] = null;
							this.EffectShieldTransformPools[num10][this.ShieldpoolCounter[num10]] = null;
							this.EffectShieldParticlePools[num10][this.ShieldpoolCounter[num10]] = null;
							this.EffectShieldParticlePools_one[num10][this.ShieldpoolCounter[num10]] = null;
							this.setEffect(row, col, DataManager.MapDataController.zoomSize);
							break;
						}
					}
					if (num10 == this.ShieldpoolsCounter)
					{
						this.EffectShieldGameObjectPools[num10] = new GameObject[this.EffectShieldGameObjectPools[0].Length];
						this.EffectShieldTransformPools[num10] = new Transform[this.EffectShieldTransformPools[0].Length];
						this.EffectShieldParticlePools[num10] = new ParticleSystem[this.EffectShieldParticlePools[0].Length];
						this.EffectShieldParticlePools_one[num10] = new ParticleSystem[this.EffectShieldParticlePools_one[0].Length];
						if (this.bBack == 1)
						{
							for (int num11 = 0; num11 < this.EffectShieldGameObjectPools[num10].Length; num11++)
							{
								this.EffectShieldGameObjectPools[num10][num11] = ParticleManager.Instance.Spawn(199, null, Vector3.zero, 1f, false, false, true);
								this.EffectShieldTransformPools[num10][num11] = this.EffectShieldGameObjectPools[num10][num11].transform;
								this.EffectShieldTransformPools[num10][num11].SetParent(this.ShieldLayoutTransform, false);
								this.EffectShieldTransformPools[num10][num11].localPosition = this.inipos;
								this.EffectShieldParticlePools[num10][num11] = this.EffectShieldTransformPools[num10][num11].GetChild(0).GetComponent<ParticleSystem>();
								this.EffectShieldParticlePools_one[num10][num11] = this.EffectShieldTransformPools[num10][num11].GetChild(1).GetComponent<ParticleSystem>();
							}
						}
						else
						{
							for (int num12 = 0; num12 < this.EffectShieldGameObjectPools[num10].Length; num12++)
							{
								this.EffectShieldGameObjectPools[num10][num12] = ParticleManager.Instance.Spawn(60103, null, Vector3.zero, 1f, false, false, true);
								if (this.EffectShieldGameObjectPools[num10][num12] == null)
								{
									this.EffectShieldGameObjectPools[num10][num12] = ParticleManager.Instance.Spawn(199, null, Vector3.zero, 1f, false, false, true);
								}
								this.EffectShieldTransformPools[num10][num12] = this.EffectShieldGameObjectPools[num10][num12].transform;
								this.EffectShieldTransformPools[num10][num12].SetParent(this.ShieldLayoutTransform, false);
								this.EffectShieldTransformPools[num10][num12].localPosition = this.inipos;
								this.EffectShieldParticlePools[num10][num12] = this.EffectShieldTransformPools[num10][num12].GetChild(0).GetComponent<ParticleSystem>();
								this.EffectShieldParticlePools_one[num10][num12] = this.EffectShieldTransformPools[num10][num12].GetChild(1).GetComponent<ParticleSystem>();
							}
						}
						this.ShieldpoolsCounter++;
						this.ShieldpoolCounter[num10] = this.EffectShieldGameObjectPools[num10].Length;
						this.ShieldpoolCounter[num10]--;
						this.EffectShieldGameObject[col][row] = this.EffectShieldGameObjectPools[num10][this.ShieldpoolCounter[num10]];
						this.EffectShieldTransform[col][row] = this.EffectShieldTransformPools[num10][this.ShieldpoolCounter[num10]];
						this.EffectShieldParticle[col][row] = this.EffectShieldParticlePools[num10][this.ShieldpoolCounter[num10]];
						this.EffectShieldParticle_one[col][row] = this.EffectShieldParticlePools_one[num10][this.ShieldpoolCounter[num10]];
						ParticleSystem particleSystem = this.EffectShieldParticle[col][row];
						float startSize = this.ShieldstartSize * x;
						this.EffectShieldParticle_one[col][row].startSize = startSize;
						particleSystem.startSize = startSize;
						this.EffectShieldGameObjectPools[num10][this.ShieldpoolCounter[num10]] = null;
						this.EffectShieldTransformPools[num10][this.ShieldpoolCounter[num10]] = null;
						this.EffectShieldParticlePools[num10][this.ShieldpoolCounter[num10]] = null;
						this.EffectShieldParticlePools_one[num10][this.ShieldpoolCounter[num10]] = null;
					}
					this.EffectShieldGameObject[col][row].SetActive(true);
				}
				this.EffectShieldTransform[col][row].localPosition = pos;
			}
			if ((effectflag & 16) == 0 || (effecttype != 3 && effecttype != 4))
			{
				if (this.EffectConveyGameObject[col][row] != null)
				{
					this.EffectConveyGameObject[col][row].SetActive(false);
					for (int num13 = 0; num13 < this.ConveypoolsCounter; num13++)
					{
						if (this.ConveypoolCounter[num13] < this.EffectConveyGameObjectPools[num13].Length)
						{
							this.EffectConveyGameObjectPools[num13][this.ConveypoolCounter[num13]] = this.EffectConveyGameObject[col][row];
							this.EffectConveyTransformPools[num13][this.ConveypoolCounter[num13]] = this.EffectConveyTransform[col][row];
							this.EffectConveyParticlePools[num13][this.ConveypoolCounter[num13]] = this.EffectConveyParticle[col][row];
							this.EffectConveyParticlePools_one[num13][this.ConveypoolCounter[num13]] = this.EffectConveyParticle_one[col][row];
							this.EffectConveyParticlePools_two[num13][this.ConveypoolCounter[num13]] = this.EffectConveyParticle_two[col][row];
							this.EffectConveyParticlePools_thr[num13][this.ConveypoolCounter[num13]] = this.EffectConveyParticle_thr[col][row];
							this.EffectConveyGameObject[col][row] = null;
							this.EffectConveyTransform[col][row] = null;
							this.EffectConveyParticle[col][row] = null;
							this.EffectConveyParticle_one[col][row] = null;
							this.EffectConveyParticle_two[col][row] = null;
							this.EffectConveyParticle_thr[col][row] = null;
							this.ConveypoolCounter[num13]++;
							break;
						}
					}
				}
				if (this.EffectNPCCityConveyGameObject[col][row] != null)
				{
					this.EffectNPCCityConveyGameObject[col][row].SetActive(false);
					for (int num14 = 0; num14 < this.NPCCityConveypoolsCounter; num14++)
					{
						if (this.NPCCityConveypoolCounter[num14] < this.EffectNPCCityConveyGameObjectPools[num14].Length)
						{
							this.EffectNPCCityConveyGameObjectPools[num14][this.NPCCityConveypoolCounter[num14]] = this.EffectNPCCityConveyGameObject[col][row];
							this.EffectNPCCityConveyTransformPools[num14][this.NPCCityConveypoolCounter[num14]] = this.EffectNPCCityConveyTransform[col][row];
							this.EffectNPCCityConveyParticlePools[num14][this.NPCCityConveypoolCounter[num14]] = this.EffectNPCCityConveyParticle[col][row];
							this.EffectNPCCityConveyParticlePools_one[num14][this.NPCCityConveypoolCounter[num14]] = this.EffectNPCCityConveyParticle_one[col][row];
							this.EffectNPCCityConveyParticlePools_two[num14][this.NPCCityConveypoolCounter[num14]] = this.EffectNPCCityConveyParticle_two[col][row];
							this.EffectNPCCityConveyParticlePools_thr[num14][this.NPCCityConveypoolCounter[num14]] = this.EffectNPCCityConveyParticle_thr[col][row];
							this.EffectNPCCityConveyGameObject[col][row] = null;
							this.EffectNPCCityConveyTransform[col][row] = null;
							this.EffectNPCCityConveyParticle[col][row] = null;
							this.EffectNPCCityConveyParticle_one[col][row] = null;
							this.EffectNPCCityConveyParticle_two[col][row] = null;
							this.EffectNPCCityConveyParticle_thr[col][row] = null;
							this.NPCCityConveypoolCounter[num14]++;
							break;
						}
					}
				}
			}
			else if (effecttype == 3)
			{
				if (this.EffectNPCCityConveyGameObject[col][row] != null)
				{
					this.EffectNPCCityConveyGameObject[col][row].SetActive(false);
					for (int num15 = 0; num15 < this.NPCCityConveypoolsCounter; num15++)
					{
						if (this.NPCCityConveypoolCounter[num15] < this.EffectNPCCityConveyGameObjectPools[num15].Length)
						{
							this.EffectNPCCityConveyGameObjectPools[num15][this.NPCCityConveypoolCounter[num15]] = this.EffectNPCCityConveyGameObject[col][row];
							this.EffectNPCCityConveyTransformPools[num15][this.NPCCityConveypoolCounter[num15]] = this.EffectNPCCityConveyTransform[col][row];
							this.EffectNPCCityConveyParticlePools[num15][this.NPCCityConveypoolCounter[num15]] = this.EffectNPCCityConveyParticle[col][row];
							this.EffectNPCCityConveyParticlePools_one[num15][this.NPCCityConveypoolCounter[num15]] = this.EffectNPCCityConveyParticle_one[col][row];
							this.EffectNPCCityConveyParticlePools_two[num15][this.NPCCityConveypoolCounter[num15]] = this.EffectNPCCityConveyParticle_two[col][row];
							this.EffectNPCCityConveyParticlePools_thr[num15][this.NPCCityConveypoolCounter[num15]] = this.EffectNPCCityConveyParticle_thr[col][row];
							this.EffectNPCCityConveyGameObject[col][row] = null;
							this.EffectNPCCityConveyTransform[col][row] = null;
							this.EffectNPCCityConveyParticle[col][row] = null;
							this.EffectNPCCityConveyParticle_one[col][row] = null;
							this.EffectNPCCityConveyParticle_two[col][row] = null;
							this.EffectNPCCityConveyParticle_thr[col][row] = null;
							this.NPCCityConveypoolCounter[num15]++;
							break;
						}
					}
				}
				if (this.EffectConveyGameObject[col][row] == null)
				{
					int num16;
					for (num16 = 0; num16 < this.ConveypoolsCounter; num16++)
					{
						if (this.ConveypoolCounter[num16] > 0)
						{
							this.ConveypoolCounter[num16]--;
							this.EffectConveyGameObject[col][row] = this.EffectConveyGameObjectPools[num16][this.ConveypoolCounter[num16]];
							this.EffectConveyTransform[col][row] = this.EffectConveyTransformPools[num16][this.ConveypoolCounter[num16]];
							this.EffectConveyParticle[col][row] = this.EffectConveyParticlePools[num16][this.ConveypoolCounter[num16]];
							this.EffectConveyParticle_one[col][row] = this.EffectConveyParticlePools_one[num16][this.ConveypoolCounter[num16]];
							this.EffectConveyParticle_two[col][row] = this.EffectConveyParticlePools_two[num16][this.ConveypoolCounter[num16]];
							this.EffectConveyParticle_thr[col][row] = this.EffectConveyParticlePools_thr[num16][this.ConveypoolCounter[num16]];
							this.EffectConveyGameObjectPools[num16][this.ConveypoolCounter[num16]] = null;
							this.EffectConveyTransformPools[num16][this.ConveypoolCounter[num16]] = null;
							this.EffectConveyParticlePools[num16][this.ConveypoolCounter[num16]] = null;
							this.EffectConveyParticlePools_one[num16][this.ConveypoolCounter[num16]] = null;
							this.EffectConveyParticlePools_two[num16][this.ConveypoolCounter[num16]] = null;
							this.EffectConveyParticlePools_thr[num16][this.ConveypoolCounter[num16]] = null;
							this.setEffect(row, col, DataManager.MapDataController.zoomSize);
							break;
						}
					}
					if (num16 == this.ConveypoolsCounter)
					{
						this.EffectConveyGameObjectPools[num16] = new GameObject[this.EffectConveyGameObjectPools[0].Length];
						this.EffectConveyTransformPools[num16] = new Transform[this.EffectConveyTransformPools[0].Length];
						this.EffectConveyParticlePools[num16] = new ParticleSystem[this.EffectConveyParticlePools[0].Length];
						this.EffectConveyParticlePools_one[num16] = new ParticleSystem[this.EffectConveyParticlePools_one[0].Length];
						this.EffectConveyParticlePools_two[num16] = new ParticleSystem[this.EffectConveyParticlePools_two[0].Length];
						this.EffectConveyParticlePools_thr[num16] = new ParticleSystem[this.EffectConveyParticlePools_thr[0].Length];
						if (this.bBack == 1)
						{
							for (int num17 = 0; num17 < this.EffectConveyGameObjectPools[num16].Length; num17++)
							{
								this.EffectConveyGameObjectPools[num16][num17] = ParticleManager.Instance.Spawn(332, null, Vector3.zero, 1f, false, false, false);
								this.EffectConveyTransformPools[num16][num17] = this.EffectConveyGameObjectPools[num16][num17].transform;
								this.EffectConveyTransformPools[num16][num17].SetParent(this.ConveyLayoutTransform, false);
								this.EffectConveyTransformPools[num16][num17].localPosition = this.inipos;
								this.EffectConveyParticlePools[num16][num17] = this.EffectConveyTransformPools[num16][num17].GetChild(0).GetComponent<ParticleSystem>();
								this.EffectConveyParticlePools_one[num16][num17] = this.EffectConveyTransformPools[num16][num17].GetChild(1).GetComponent<ParticleSystem>();
								this.EffectConveyParticlePools_two[num16][num17] = this.EffectConveyTransformPools[num16][num17].GetChild(2).GetComponent<ParticleSystem>();
								this.EffectConveyParticlePools_thr[num16][num17] = this.EffectConveyTransformPools[num16][num17].GetChild(3).GetComponent<ParticleSystem>();
							}
						}
						else
						{
							for (int num18 = 0; num18 < this.EffectConveyGameObjectPools[num16].Length; num18++)
							{
								this.EffectConveyGameObjectPools[num16][num18] = ParticleManager.Instance.Spawn(60111, null, Vector3.zero, 1f, false, false, false);
								if (this.EffectConveyGameObjectPools[num16][num18] == null)
								{
									ParticleManager.Instance.Spawn(332, null, Vector3.zero, 1f, false, false, false);
								}
								this.EffectConveyTransformPools[num16][num18] = this.EffectConveyGameObjectPools[num16][num18].transform;
								this.EffectConveyTransformPools[num16][num18].SetParent(this.ConveyLayoutTransform, false);
								this.EffectConveyTransformPools[num16][num18].localPosition = this.inipos;
								this.EffectConveyParticlePools[num16][num18] = this.EffectConveyTransformPools[num16][num18].GetChild(0).GetComponent<ParticleSystem>();
								this.EffectConveyParticlePools_one[num16][num18] = this.EffectConveyTransformPools[num16][num18].GetChild(1).GetComponent<ParticleSystem>();
								this.EffectConveyParticlePools_two[num16][num18] = this.EffectConveyTransformPools[num16][num18].GetChild(2).GetComponent<ParticleSystem>();
								this.EffectConveyParticlePools_thr[num16][num18] = this.EffectConveyTransformPools[num16][num18].GetChild(3).GetComponent<ParticleSystem>();
							}
						}
						this.ConveypoolsCounter++;
						this.ConveypoolCounter[num16] = this.EffectConveyGameObjectPools[num16].Length;
						this.ConveypoolCounter[num16]--;
						this.EffectConveyGameObject[col][row] = this.EffectConveyGameObjectPools[num16][this.ConveypoolCounter[num16]];
						this.EffectConveyTransform[col][row] = this.EffectConveyTransformPools[num16][this.ConveypoolCounter[num16]];
						this.EffectConveyParticle[col][row] = this.EffectConveyParticlePools[num16][this.ConveypoolCounter[num16]];
						this.EffectConveyParticle_one[col][row] = this.EffectConveyParticlePools_one[num16][this.ConveypoolCounter[num16]];
						this.EffectConveyParticle_two[col][row] = this.EffectConveyParticlePools_two[num16][this.ConveypoolCounter[num16]];
						this.EffectConveyParticle_thr[col][row] = this.EffectConveyParticlePools_thr[num16][this.ConveypoolCounter[num16]];
						this.EffectConveyParticle[col][row].startSize = this.ConveystartSize * x;
						this.EffectConveyParticle_one[col][row].startSize = this.ConveystartSize_one * x;
						this.EffectConveyParticle_two[col][row].startSize = this.ConveystartSize_two * x;
						this.EffectConveyParticle_thr[col][row].startSize = this.ConveystartSize_thr * x;
						this.EffectConveyParticle[col][row].startLifetime = this.Conveylifetime * x;
						this.EffectConveyParticle_one[col][row].startLifetime = this.Conveylifetime_one * x;
						this.EffectConveyParticle_two[col][row].startLifetime = this.Conveylifetime_two * x;
						this.EffectConveyParticle_thr[col][row].startLifetime = this.Conveylifetime_thr * x;
						this.EffectConveyGameObjectPools[num16][this.ConveypoolCounter[num16]] = null;
						this.EffectConveyTransformPools[num16][this.ConveypoolCounter[num16]] = null;
						this.EffectConveyParticlePools[num16][this.ConveypoolCounter[num16]] = null;
						this.EffectConveyParticlePools_one[num16][this.ConveypoolCounter[num16]] = null;
						this.EffectConveyParticlePools_two[num16][this.ConveypoolCounter[num16]] = null;
						this.EffectConveyParticlePools_thr[num16][this.ConveypoolCounter[num16]] = null;
					}
					this.EffectConveyGameObject[col][row].SetActive(true);
				}
				this.EffectConveyTransform[col][row].localPosition = pos;
			}
			else
			{
				if (this.EffectConveyGameObject[col][row] != null)
				{
					this.EffectConveyGameObject[col][row].SetActive(false);
					for (int num19 = 0; num19 < this.ConveypoolsCounter; num19++)
					{
						if (this.ConveypoolCounter[num19] < this.EffectConveyGameObjectPools[num19].Length)
						{
							this.EffectConveyGameObjectPools[num19][this.ConveypoolCounter[num19]] = this.EffectConveyGameObject[col][row];
							this.EffectConveyTransformPools[num19][this.ConveypoolCounter[num19]] = this.EffectConveyTransform[col][row];
							this.EffectConveyParticlePools[num19][this.ConveypoolCounter[num19]] = this.EffectConveyParticle[col][row];
							this.EffectConveyParticlePools_one[num19][this.ConveypoolCounter[num19]] = this.EffectConveyParticle_one[col][row];
							this.EffectConveyParticlePools_two[num19][this.ConveypoolCounter[num19]] = this.EffectConveyParticle_two[col][row];
							this.EffectConveyParticlePools_thr[num19][this.ConveypoolCounter[num19]] = this.EffectConveyParticle_thr[col][row];
							this.EffectConveyGameObject[col][row] = null;
							this.EffectConveyTransform[col][row] = null;
							this.EffectConveyParticle[col][row] = null;
							this.EffectConveyParticle_one[col][row] = null;
							this.EffectConveyParticle_two[col][row] = null;
							this.EffectConveyParticle_thr[col][row] = null;
							this.ConveypoolCounter[num19]++;
							break;
						}
					}
				}
				if (this.EffectNPCCityConveyGameObject[col][row] == null)
				{
					int num20;
					for (num20 = 0; num20 < this.NPCCityConveypoolsCounter; num20++)
					{
						if (this.NPCCityConveypoolCounter[num20] > 0)
						{
							this.NPCCityConveypoolCounter[num20]--;
							this.EffectNPCCityConveyGameObject[col][row] = this.EffectNPCCityConveyGameObjectPools[num20][this.NPCCityConveypoolCounter[num20]];
							this.EffectNPCCityConveyTransform[col][row] = this.EffectNPCCityConveyTransformPools[num20][this.NPCCityConveypoolCounter[num20]];
							this.EffectNPCCityConveyParticle[col][row] = this.EffectNPCCityConveyParticlePools[num20][this.NPCCityConveypoolCounter[num20]];
							this.EffectNPCCityConveyParticle_one[col][row] = this.EffectNPCCityConveyParticlePools_one[num20][this.NPCCityConveypoolCounter[num20]];
							this.EffectNPCCityConveyParticle_two[col][row] = this.EffectNPCCityConveyParticlePools_two[num20][this.NPCCityConveypoolCounter[num20]];
							this.EffectNPCCityConveyParticle_thr[col][row] = this.EffectNPCCityConveyParticlePools_thr[num20][this.NPCCityConveypoolCounter[num20]];
							this.EffectNPCCityConveyGameObjectPools[num20][this.NPCCityConveypoolCounter[num20]] = null;
							this.EffectNPCCityConveyTransformPools[num20][this.NPCCityConveypoolCounter[num20]] = null;
							this.EffectNPCCityConveyParticlePools[num20][this.NPCCityConveypoolCounter[num20]] = null;
							this.EffectNPCCityConveyParticlePools_one[num20][this.NPCCityConveypoolCounter[num20]] = null;
							this.EffectNPCCityConveyParticlePools_two[num20][this.NPCCityConveypoolCounter[num20]] = null;
							this.EffectNPCCityConveyParticlePools_thr[num20][this.NPCCityConveypoolCounter[num20]] = null;
							this.setEffect(row, col, DataManager.MapDataController.zoomSize);
							break;
						}
					}
					if (num20 == this.NPCCityConveypoolsCounter)
					{
						this.EffectNPCCityConveyGameObjectPools[num20] = new GameObject[this.EffectNPCCityConveyGameObjectPools[0].Length];
						this.EffectNPCCityConveyTransformPools[num20] = new Transform[this.EffectNPCCityConveyTransformPools[0].Length];
						this.EffectNPCCityConveyParticlePools[num20] = new ParticleSystem[this.EffectConveyParticlePools[0].Length];
						this.EffectNPCCityConveyParticlePools_one[num20] = new ParticleSystem[this.EffectNPCCityConveyParticlePools_one[0].Length];
						this.EffectNPCCityConveyParticlePools_two[num20] = new ParticleSystem[this.EffectNPCCityConveyParticlePools_two[0].Length];
						this.EffectNPCCityConveyParticlePools_thr[num20] = new ParticleSystem[this.EffectNPCCityConveyParticlePools_thr[0].Length];
						if (this.bBack == 1)
						{
							for (int num21 = 0; num21 < this.EffectNPCCityConveyGameObjectPools[num20].Length; num21++)
							{
								this.EffectNPCCityConveyGameObjectPools[num20][num21] = ParticleManager.Instance.Spawn(390, null, Vector3.zero, 1f, false, false, false);
								this.EffectNPCCityConveyTransformPools[num20][num21] = this.EffectNPCCityConveyGameObjectPools[num20][num21].transform;
								this.EffectNPCCityConveyTransformPools[num20][num21].SetParent(this.NPCCityConveyLayoutTransform, false);
								this.EffectNPCCityConveyTransformPools[num20][num21].localPosition = this.inipos;
								this.EffectNPCCityConveyParticlePools[num20][num21] = this.EffectNPCCityConveyTransformPools[num20][num21].GetChild(0).GetComponent<ParticleSystem>();
								this.EffectNPCCityConveyParticlePools_one[num20][num21] = this.EffectNPCCityConveyTransformPools[num20][num21].GetChild(1).GetComponent<ParticleSystem>();
								this.EffectNPCCityConveyParticlePools_two[num20][num21] = this.EffectNPCCityConveyTransformPools[num20][num21].GetChild(2).GetComponent<ParticleSystem>();
								this.EffectNPCCityConveyParticlePools_thr[num20][num21] = this.EffectNPCCityConveyTransformPools[num20][num21].GetChild(3).GetComponent<ParticleSystem>();
							}
						}
						else
						{
							for (int num22 = 0; num22 < this.EffectNPCCityConveyGameObjectPools[num20].Length; num22++)
							{
								this.EffectNPCCityConveyGameObjectPools[num20][num22] = ParticleManager.Instance.Spawn(60112, null, Vector3.zero, 1f, false, false, false);
								if (this.EffectNPCCityConveyGameObjectPools[num20][num22] == null)
								{
									ParticleManager.Instance.Spawn(390, null, Vector3.zero, 1f, false, false, false);
								}
								this.EffectNPCCityConveyTransformPools[num20][num22] = this.EffectNPCCityConveyGameObjectPools[num20][num22].transform;
								this.EffectNPCCityConveyTransformPools[num20][num22].SetParent(this.NPCCityConveyLayoutTransform, false);
								this.EffectNPCCityConveyTransformPools[num20][num22].localPosition = this.inipos;
								this.EffectNPCCityConveyParticlePools[num20][num22] = this.EffectNPCCityConveyTransformPools[num20][num22].GetChild(0).GetComponent<ParticleSystem>();
								this.EffectNPCCityConveyParticlePools_one[num20][num22] = this.EffectNPCCityConveyTransformPools[num20][num22].GetChild(1).GetComponent<ParticleSystem>();
								this.EffectNPCCityConveyParticlePools_two[num20][num22] = this.EffectNPCCityConveyTransformPools[num20][num22].GetChild(2).GetComponent<ParticleSystem>();
								this.EffectNPCCityConveyParticlePools_thr[num20][num22] = this.EffectNPCCityConveyTransformPools[num20][num22].GetChild(3).GetComponent<ParticleSystem>();
							}
						}
						this.NPCCityConveypoolsCounter++;
						this.NPCCityConveypoolCounter[num20] = this.EffectNPCCityConveyGameObjectPools[num20].Length;
						this.NPCCityConveypoolCounter[num20]--;
						this.EffectNPCCityConveyGameObject[col][row] = this.EffectNPCCityConveyGameObjectPools[num20][this.NPCCityConveypoolCounter[num20]];
						this.EffectNPCCityConveyTransform[col][row] = this.EffectNPCCityConveyTransformPools[num20][this.NPCCityConveypoolCounter[num20]];
						this.EffectNPCCityConveyParticle[col][row] = this.EffectNPCCityConveyParticlePools[num20][this.NPCCityConveypoolCounter[num20]];
						this.EffectNPCCityConveyParticle_one[col][row] = this.EffectNPCCityConveyParticlePools_one[num20][this.NPCCityConveypoolCounter[num20]];
						this.EffectNPCCityConveyParticle_two[col][row] = this.EffectNPCCityConveyParticlePools_two[num20][this.NPCCityConveypoolCounter[num20]];
						this.EffectNPCCityConveyParticle_thr[col][row] = this.EffectNPCCityConveyParticlePools_thr[num20][this.NPCCityConveypoolCounter[num20]];
						this.EffectNPCCityConveyParticle[col][row].startSize = this.NPCCityConveystartSize * x;
						this.EffectNPCCityConveyParticle_one[col][row].startSize = this.NPCCityConveystartSize_one * x;
						this.EffectNPCCityConveyParticle_two[col][row].startSize = this.NPCCityConveystartSize_two * x;
						this.EffectNPCCityConveyParticle_thr[col][row].startSize = this.NPCCityConveystartSize_thr * x;
						this.EffectNPCCityConveyParticle[col][row].startLifetime = this.NPCCityConveylifetime * x;
						this.EffectNPCCityConveyParticle_one[col][row].startLifetime = this.NPCCityConveylifetime_one * x;
						this.EffectNPCCityConveyParticle_two[col][row].startLifetime = this.NPCCityConveylifetime_two * x;
						this.EffectNPCCityConveyParticle_thr[col][row].startLifetime = this.NPCCityConveylifetime_thr * x;
						this.EffectNPCCityConveyGameObjectPools[num20][this.NPCCityConveypoolCounter[num20]] = null;
						this.EffectNPCCityConveyTransformPools[num20][this.NPCCityConveypoolCounter[num20]] = null;
						this.EffectNPCCityConveyParticlePools[num20][this.NPCCityConveypoolCounter[num20]] = null;
						this.EffectNPCCityConveyParticlePools_one[num20][this.NPCCityConveypoolCounter[num20]] = null;
						this.EffectNPCCityConveyParticlePools_two[num20][this.NPCCityConveypoolCounter[num20]] = null;
						this.EffectNPCCityConveyParticlePools_thr[num20][this.NPCCityConveypoolCounter[num20]] = null;
					}
					this.EffectNPCCityConveyGameObject[col][row].SetActive(true);
				}
				this.EffectNPCCityConveyTransform[col][row].localPosition = pos;
			}
			if ((effectflag & 128) != 0)
			{
				if (this.EffectMapWeaponHurtGameObject[col][row] == null)
				{
					int num23;
					for (num23 = 0; num23 < this.MapWeaponHurtpoolsCounter; num23++)
					{
						if (this.MapWeaponHurtpoolCounter[num23] > 0)
						{
							this.MapWeaponHurtpoolCounter[num23]--;
							this.EffectMapWeaponHurtGameObject[col][row] = this.EffectMapWeaponHurtGameObjectPools[num23][this.MapWeaponHurtpoolCounter[num23]];
							this.EffectMapWeaponHurtTransform[col][row] = this.EffectMapWeaponHurtTransformPools[num23][this.MapWeaponHurtpoolCounter[num23]];
							for (int num24 = 0; num24 < this.EffectMapWeaponHurtParticle.Length; num24++)
							{
								this.EffectMapWeaponHurtParticle[num24][col][row] = this.EffectMapWeaponHurtParticlePools[num24][num23][this.MapWeaponHurtpoolCounter[num23]];
							}
							this.EffectMapWeaponHurtGameObjectPools[num23][this.MapWeaponHurtpoolCounter[num23]] = null;
							this.EffectMapWeaponHurtTransformPools[num23][this.MapWeaponHurtpoolCounter[num23]] = null;
							for (int num25 = 0; num25 < this.EffectMapWeaponHurtParticle.Length; num25++)
							{
								this.EffectMapWeaponHurtParticlePools[num25][num23][this.MapWeaponHurtpoolCounter[num23]] = null;
							}
							this.setEffect(row, col, DataManager.MapDataController.zoomSize);
							break;
						}
					}
					if (num23 == this.MapWeaponHurtpoolsCounter)
					{
						this.EffectMapWeaponHurtGameObjectPools[num23] = new GameObject[this.EffectMapWeaponHurtGameObjectPools[0].Length];
						this.EffectMapWeaponHurtTransformPools[num23] = new Transform[this.EffectMapWeaponHurtTransformPools[0].Length];
						for (int num26 = 0; num26 < this.EffectMapWeaponHurtParticlePools.Length; num26++)
						{
							this.EffectMapWeaponHurtParticlePools[num26][num23] = new ParticleSystem[this.EffectMapWeaponHurtParticlePools[0].Length];
						}
						for (int num27 = 0; num27 < this.EffectMapWeaponHurtGameObjectPools[num23].Length; num27++)
						{
							this.EffectMapWeaponHurtGameObjectPools[num23][num27] = ParticleManager.Instance.Spawn(60601, null, Vector3.zero, 1f, false, false, true);
							if (this.EffectMapWeaponHurtGameObjectPools[num23][num27] == null)
							{
								this.EffectMapWeaponHurtGameObjectPools[num23][num27] = ParticleManager.Instance.Spawn(60601, null, Vector3.zero, 1f, false, false, true);
							}
							this.EffectMapWeaponHurtTransformPools[num23][num27] = this.EffectMapWeaponHurtGameObjectPools[num23][num27].transform;
							this.EffectMapWeaponHurtTransformPools[num23][num27].SetParent(this.MapWeaponHurtLayoutTransform, false);
							this.EffectMapWeaponHurtTransformPools[num23][num27].localPosition = this.inipos;
							for (int num28 = 0; num28 < this.EffectMapWeaponHurtParticlePools.Length; num28++)
							{
								this.EffectMapWeaponHurtParticlePools[num28][num23][num27] = this.EffectMapWeaponHurtTransformPools[num23][num27].GetChild(num28).GetComponent<ParticleSystem>();
							}
						}
						this.MapWeaponHurtpoolsCounter++;
						this.MapWeaponHurtpoolCounter[num23] = this.EffectMapWeaponHurtGameObjectPools[num23].Length;
						this.MapWeaponHurtpoolCounter[num23]--;
						this.EffectMapWeaponHurtGameObject[col][row] = this.EffectMapWeaponHurtGameObjectPools[num23][this.MapWeaponHurtpoolCounter[num23]];
						this.EffectMapWeaponHurtTransform[col][row] = this.EffectMapWeaponHurtTransformPools[num23][this.MapWeaponHurtpoolCounter[num23]];
						for (int num29 = 0; num29 < this.EffectMapWeaponHurtParticle.Length; num29++)
						{
							this.EffectMapWeaponHurtParticle[num29][col][row] = this.EffectMapWeaponHurtParticlePools[num29][num23][this.MapWeaponHurtpoolCounter[num23]];
							this.EffectMapWeaponHurtParticle[num29][col][row].startSize = this.MapWeaponHurtstartSize[num29] * x;
						}
						this.EffectMapWeaponHurtGameObjectPools[num23][this.MapWeaponHurtpoolCounter[num23]] = null;
						this.EffectMapWeaponHurtTransformPools[num23][this.MapWeaponHurtpoolCounter[num23]] = null;
						for (int num30 = 0; num30 < this.EffectMapWeaponHurtParticle.Length; num30++)
						{
							this.EffectMapWeaponHurtParticlePools[num30][num23][this.MapWeaponHurtpoolCounter[num23]] = null;
						}
					}
					this.EffectMapWeaponHurtGameObject[col][row].SetActive(true);
				}
				this.EffectMapWeaponHurtTransform[col][row].localPosition = pos;
			}
			else if (this.EffectMapWeaponHurtGameObject[col][row] != null)
			{
				this.EffectMapWeaponHurtGameObject[col][row].SetActive(false);
				for (int num31 = 0; num31 < this.MapWeaponHurtpoolsCounter; num31++)
				{
					if (this.MapWeaponHurtpoolCounter[num31] < this.EffectMapWeaponHurtGameObjectPools[num31].Length)
					{
						this.EffectMapWeaponHurtGameObjectPools[num31][this.MapWeaponHurtpoolCounter[num31]] = this.EffectMapWeaponHurtGameObject[col][row];
						this.EffectMapWeaponHurtTransformPools[num31][this.MapWeaponHurtpoolCounter[num31]] = this.EffectMapWeaponHurtTransform[col][row];
						for (int num32 = 0; num32 < this.EffectMapWeaponHurtParticlePools.Length; num32++)
						{
							this.EffectMapWeaponHurtParticlePools[num32][num31][this.MapWeaponHurtpoolCounter[num31]] = this.EffectMapWeaponHurtParticle[num32][col][row];
						}
						this.EffectMapWeaponHurtGameObject[col][row] = null;
						this.EffectMapWeaponHurtTransform[col][row] = null;
						for (int num33 = 0; num33 < this.EffectMapWeaponHurtParticlePools.Length; num33++)
						{
							this.EffectMapWeaponHurtParticle[num33][col][row] = null;
						}
						this.MapWeaponHurtpoolCounter[num31]++;
						break;
					}
				}
			}
		}
		if (effecttype >= 5)
		{
			if (effecttype == 5)
			{
				if (this.active)
				{
					if (this.EffectBallDownGameObject[col][row] == null)
					{
						int num34;
						for (num34 = 0; num34 < this.BallDownpoolsCounter; num34++)
						{
							if (this.BallDownpoolCounter[num34] > 0)
							{
								this.BallDownpoolCounter[num34]--;
								this.EffectBallDownGameObject[col][row] = this.EffectBallDownGameObjectPools[num34][this.BallDownpoolCounter[num34]];
								this.EffectBallDownTransform[col][row] = this.EffectBallDownTransformPools[num34][this.BallDownpoolCounter[num34]];
								for (int num35 = 0; num35 < this.EffectBallDownParticle.Length; num35++)
								{
									this.EffectBallDownParticle[num35][col][row] = this.EffectBallDownParticlePools[num35][num34][this.BallDownpoolCounter[num34]];
								}
								this.EffectBallDownGameObjectPools[num34][this.BallDownpoolCounter[num34]] = null;
								this.EffectBallDownTransformPools[num34][this.BallDownpoolCounter[num34]] = null;
								for (int num36 = 0; num36 < this.EffectBallDownParticle.Length; num36++)
								{
									this.EffectBallDownParticlePools[num36][num34][this.BallDownpoolCounter[num34]] = null;
								}
								this.setEffect(row, col, DataManager.MapDataController.zoomSize);
								break;
							}
						}
						if (num34 == this.BallDownpoolsCounter)
						{
							this.EffectBallDownGameObjectPools[num34] = new GameObject[this.EffectBallDownGameObjectPools[0].Length];
							this.EffectBallDownTransformPools[num34] = new Transform[this.EffectBallDownTransformPools[0].Length];
							for (int num37 = 0; num37 < this.EffectBallDownParticlePools.Length; num37++)
							{
								this.EffectBallDownParticlePools[num37][num34] = new ParticleSystem[this.EffectBallDownParticlePools[0].Length];
							}
							for (int num38 = 0; num38 < this.EffectBallDownGameObjectPools[num34].Length; num38++)
							{
								this.EffectBallDownGameObjectPools[num34][num38] = ParticleManager.Instance.Spawn(60501, null, Vector3.zero, 1f, false, false, true);
								if (this.EffectBallDownGameObjectPools[num34][num38] == null)
								{
									this.EffectBallDownGameObjectPools[num34][num38] = ParticleManager.Instance.Spawn(60501, null, Vector3.zero, 1f, false, false, true);
								}
								this.EffectBallDownTransformPools[num34][num38] = this.EffectBallDownGameObjectPools[num34][num38].transform;
								this.EffectBallDownTransformPools[num34][num38].SetParent(this.BallDownLayoutTransform, false);
								this.EffectBallDownTransformPools[num34][num38].localPosition = this.inipos;
								for (int num39 = 0; num39 < this.EffectBallDownParticlePools.Length; num39++)
								{
									this.EffectBallDownParticlePools[num39][num34][num38] = this.EffectBallDownTransformPools[num34][num38].GetChild(num39).GetComponent<ParticleSystem>();
								}
							}
							this.BallDownpoolsCounter++;
							this.BallDownpoolCounter[num34] = this.EffectBallDownGameObjectPools[num34].Length;
							this.BallDownpoolCounter[num34]--;
							this.EffectBallDownGameObject[col][row] = this.EffectBallDownGameObjectPools[num34][this.BallDownpoolCounter[num34]];
							this.EffectBallDownTransform[col][row] = this.EffectBallDownTransformPools[num34][this.BallDownpoolCounter[num34]];
							for (int num40 = 0; num40 < this.EffectBallDownParticle.Length; num40++)
							{
								this.EffectBallDownParticle[num40][col][row] = this.EffectBallDownParticlePools[num40][num34][this.BallDownpoolCounter[num34]];
								this.EffectBallDownParticle[num40][col][row].startSize = this.BallDownstartSize[num40] * x;
							}
							this.EffectBallDownGameObjectPools[num34][this.BallDownpoolCounter[num34]] = null;
							this.EffectBallDownTransformPools[num34][this.BallDownpoolCounter[num34]] = null;
							for (int num41 = 0; num41 < this.EffectBallDownParticle.Length; num41++)
							{
								this.EffectBallDownParticlePools[num41][num34][this.BallDownpoolCounter[num34]] = null;
							}
						}
						this.EffectBallDownGameObject[col][row].SetActive(true);
						if (this.Particletimer[col][row] > 0f && this.Particlekind[col][row] != 1)
						{
							this.EffectGone(row, col);
						}
						this.Particletimer[col][row] = 1.6f * x;
						this.Particlekind[col][row] = 1;
					}
					this.EffectBallDownTransform[col][row].localPosition = pos;
				}
			}
			else if (this.EffectBallDownGameObject[col][row] != null)
			{
				this.EffectBallDownGameObject[col][row].SetActive(false);
				if (this.Particlekind[col][row] == 1)
				{
					this.Particletimer[col][row] = 0f;
					this.Particlekind[col][row] = 0;
				}
				this.Particletimer[col][row] = 0f;
				this.Particlekind[col][row] = 0;
				for (int num42 = 0; num42 < this.BallDownpoolsCounter; num42++)
				{
					if (this.BallDownpoolCounter[num42] < this.EffectBallDownGameObjectPools[num42].Length)
					{
						this.EffectBallDownGameObjectPools[num42][this.BallDownpoolCounter[num42]] = this.EffectBallDownGameObject[col][row];
						this.EffectBallDownTransformPools[num42][this.BallDownpoolCounter[num42]] = this.EffectBallDownTransform[col][row];
						for (int num43 = 0; num43 < this.EffectBallDownParticlePools.Length; num43++)
						{
							this.EffectBallDownParticlePools[num43][num42][this.BallDownpoolCounter[num42]] = this.EffectBallDownParticle[num43][col][row];
						}
						this.EffectBallDownGameObject[col][row] = null;
						this.EffectBallDownTransform[col][row] = null;
						for (int num44 = 0; num44 < this.EffectBallDownParticlePools.Length; num44++)
						{
							this.EffectBallDownParticle[num44][col][row] = null;
						}
						this.BallDownpoolCounter[num42]++;
						break;
					}
				}
			}
			if (effecttype == 6)
			{
				if (this.active)
				{
					Vector2 zero = Vector2.zero;
					zero.y = 64f;
					if (this.EffectBallBigYolkGameObject[col][row] == null)
					{
						int num45;
						for (num45 = 0; num45 < this.BallBigYolkpoolsCounter; num45++)
						{
							if (this.BallBigYolkpoolCounter[num45] > 0)
							{
								this.BallBigYolkpoolCounter[num45]--;
								this.EffectBallBigYolkGameObject[col][row] = this.EffectBallBigYolkGameObjectPools[num45][this.BallBigYolkpoolCounter[num45]];
								this.EffectBallBigYolkTransform[col][row] = this.EffectBallBigYolkTransformPools[num45][this.BallBigYolkpoolCounter[num45]];
								for (int num46 = 0; num46 < this.EffectBallBigYolkParticle.Length; num46++)
								{
									this.EffectBallBigYolkParticle[num46][col][row] = this.EffectBallBigYolkParticlePools[num46][num45][this.BallBigYolkpoolCounter[num45]];
								}
								this.EffectBallBigYolkGameObjectPools[num45][this.BallBigYolkpoolCounter[num45]] = null;
								this.EffectBallBigYolkTransformPools[num45][this.BallBigYolkpoolCounter[num45]] = null;
								for (int num47 = 0; num47 < this.EffectBallBigYolkParticle.Length; num47++)
								{
									this.EffectBallBigYolkParticlePools[num47][num45][this.BallBigYolkpoolCounter[num45]] = null;
								}
								this.setEffect(row, col, DataManager.MapDataController.zoomSize);
								break;
							}
						}
						if (num45 == this.BallBigYolkpoolsCounter)
						{
							this.EffectBallBigYolkGameObjectPools[num45] = new GameObject[this.EffectBallBigYolkGameObjectPools[0].Length];
							this.EffectBallBigYolkTransformPools[num45] = new Transform[this.EffectBallBigYolkTransformPools[0].Length];
							for (int num48 = 0; num48 < this.EffectBallBigYolkParticlePools.Length; num48++)
							{
								this.EffectBallBigYolkParticlePools[num48][num45] = new ParticleSystem[this.EffectBallBigYolkParticlePools[0].Length];
							}
							for (int num49 = 0; num49 < this.EffectBallBigYolkGameObjectPools[num45].Length; num49++)
							{
								this.EffectBallBigYolkGameObjectPools[num45][num49] = ParticleManager.Instance.Spawn(60502, null, Vector3.zero, 1f, false, false, true);
								if (this.EffectBallBigYolkGameObjectPools[num45][num49] == null)
								{
									this.EffectBallBigYolkGameObjectPools[num45][num49] = ParticleManager.Instance.Spawn(60502, null, Vector3.zero, 1f, false, false, true);
								}
								this.EffectBallBigYolkTransformPools[num45][num49] = this.EffectBallBigYolkGameObjectPools[num45][num49].transform;
								this.EffectBallBigYolkTransformPools[num45][num49].SetParent(this.BallBigYolkLayoutTransform, false);
								this.EffectBallBigYolkTransformPools[num45][num49].localPosition = this.inipos;
								for (int num50 = 0; num50 < this.EffectBallBigYolkParticlePools.Length; num50++)
								{
									this.EffectBallBigYolkParticlePools[num50][num45][num49] = this.EffectBallBigYolkTransformPools[num45][num49].GetChild(num50).GetComponent<ParticleSystem>();
								}
							}
							this.BallBigYolkpoolsCounter++;
							this.BallBigYolkpoolCounter[num45] = this.EffectBallBigYolkGameObjectPools[num45].Length;
							this.BallBigYolkpoolCounter[num45]--;
							this.EffectBallBigYolkGameObject[col][row] = this.EffectBallBigYolkGameObjectPools[num45][this.BallBigYolkpoolCounter[num45]];
							this.EffectBallBigYolkTransform[col][row] = this.EffectBallBigYolkTransformPools[num45][this.BallBigYolkpoolCounter[num45]];
							for (int num51 = 0; num51 < this.EffectBallBigYolkParticle.Length; num51++)
							{
								this.EffectBallBigYolkParticle[num51][col][row] = this.EffectBallBigYolkParticlePools[num51][num45][this.BallBigYolkpoolCounter[num45]];
								this.EffectBallBigYolkParticle[num51][col][row].startSize = this.BallBigYolkstartSize[num51] * x;
							}
							this.EffectBallBigYolkGameObjectPools[num45][this.BallBigYolkpoolCounter[num45]] = null;
							this.EffectBallBigYolkTransformPools[num45][this.BallBigYolkpoolCounter[num45]] = null;
							for (int num52 = 0; num52 < this.EffectBallBigYolkParticle.Length; num52++)
							{
								this.EffectBallBigYolkParticlePools[num52][num45][this.BallBigYolkpoolCounter[num45]] = null;
							}
						}
						this.EffectBallBigYolkGameObject[col][row].SetActive(true);
						if (this.Particletimer[col][row] > 0f && this.Particlekind[col][row] != 2)
						{
							this.EffectGone(row, col);
						}
						this.Particletimer[col][row] = 2f * x;
						this.Particlekind[col][row] = 2;
					}
					this.EffectBallBigYolkTransform[col][row].localPosition = pos + zero;
				}
			}
			else if (this.EffectBallBigYolkGameObject[col][row] != null)
			{
				this.EffectBallBigYolkGameObject[col][row].SetActive(false);
				if (this.Particlekind[col][row] == 2)
				{
					this.Particletimer[col][row] = 0f;
					this.Particlekind[col][row] = 0;
				}
				for (int num53 = 0; num53 < this.BallBigYolkpoolsCounter; num53++)
				{
					if (this.BallBigYolkpoolCounter[num53] < this.EffectBallBigYolkGameObjectPools[num53].Length)
					{
						this.EffectBallBigYolkGameObjectPools[num53][this.BallBigYolkpoolCounter[num53]] = this.EffectBallBigYolkGameObject[col][row];
						this.EffectBallBigYolkTransformPools[num53][this.BallBigYolkpoolCounter[num53]] = this.EffectBallBigYolkTransform[col][row];
						for (int num54 = 0; num54 < this.EffectBallBigYolkParticlePools.Length; num54++)
						{
							this.EffectBallBigYolkParticlePools[num54][num53][this.BallBigYolkpoolCounter[num53]] = this.EffectBallBigYolkParticle[num54][col][row];
						}
						this.EffectBallBigYolkGameObject[col][row] = null;
						this.EffectBallBigYolkTransform[col][row] = null;
						for (int num55 = 0; num55 < this.EffectBallBigYolkParticlePools.Length; num55++)
						{
							this.EffectBallBigYolkParticle[num55][col][row] = null;
						}
						this.BallBigYolkpoolCounter[num53]++;
						break;
					}
				}
			}
			if (effecttype == 7)
			{
				if (this.active)
				{
					Vector2 zero2 = Vector2.zero;
					zero2.y = 64f;
					if (this.EffectBallYolkGameObject[col][row] == null)
					{
						int num56;
						for (num56 = 0; num56 < this.BallYolkpoolsCounter; num56++)
						{
							if (this.BallYolkpoolCounter[num56] > 0)
							{
								this.BallYolkpoolCounter[num56]--;
								this.EffectBallYolkGameObject[col][row] = this.EffectBallYolkGameObjectPools[num56][this.BallYolkpoolCounter[num56]];
								this.EffectBallYolkTransform[col][row] = this.EffectBallYolkTransformPools[num56][this.BallYolkpoolCounter[num56]];
								for (int num57 = 0; num57 < this.EffectBallYolkParticle.Length; num57++)
								{
									this.EffectBallYolkParticle[num57][col][row] = this.EffectBallYolkParticlePools[num57][num56][this.BallYolkpoolCounter[num56]];
								}
								this.EffectBallYolkGameObjectPools[num56][this.BallYolkpoolCounter[num56]] = null;
								this.EffectBallYolkTransformPools[num56][this.BallYolkpoolCounter[num56]] = null;
								for (int num58 = 0; num58 < this.EffectBallYolkParticle.Length; num58++)
								{
									this.EffectBallYolkParticlePools[num58][num56][this.BallYolkpoolCounter[num56]] = null;
								}
								this.setEffect(row, col, DataManager.MapDataController.zoomSize);
								break;
							}
						}
						if (num56 == this.BallYolkpoolsCounter)
						{
							this.EffectBallYolkGameObjectPools[num56] = new GameObject[this.EffectBallYolkGameObjectPools[0].Length];
							this.EffectBallYolkTransformPools[num56] = new Transform[this.EffectBallYolkTransformPools[0].Length];
							for (int num59 = 0; num59 < this.EffectBallYolkParticlePools.Length; num59++)
							{
								this.EffectBallYolkParticlePools[num59][num56] = new ParticleSystem[this.EffectBallYolkParticlePools[0].Length];
							}
							for (int num60 = 0; num60 < this.EffectBallYolkGameObjectPools[num56].Length; num60++)
							{
								this.EffectBallYolkGameObjectPools[num56][num60] = ParticleManager.Instance.Spawn(60503, null, Vector3.zero, 1f, false, false, true);
								if (this.EffectBallYolkGameObjectPools[num56][num60] == null)
								{
									this.EffectBallYolkGameObjectPools[num56][num60] = ParticleManager.Instance.Spawn(60503, null, Vector3.zero, 1f, false, false, true);
								}
								this.EffectBallYolkTransformPools[num56][num60] = this.EffectBallYolkGameObjectPools[num56][num60].transform;
								this.EffectBallYolkTransformPools[num56][num60].SetParent(this.BallYolkLayoutTransform, false);
								this.EffectBallYolkTransformPools[num56][num60].localPosition = this.inipos;
								for (int num61 = 0; num61 < this.EffectBallYolkParticlePools.Length; num61++)
								{
									this.EffectBallYolkParticlePools[num61][num56][num60] = this.EffectBallYolkTransformPools[num56][num60].GetChild(num61).GetComponent<ParticleSystem>();
								}
							}
							this.BallYolkpoolsCounter++;
							this.BallYolkpoolCounter[num56] = this.EffectBallYolkGameObjectPools[num56].Length;
							this.BallYolkpoolCounter[num56]--;
							this.EffectBallYolkGameObject[col][row] = this.EffectBallYolkGameObjectPools[num56][this.BallYolkpoolCounter[num56]];
							this.EffectBallYolkTransform[col][row] = this.EffectBallYolkTransformPools[num56][this.BallYolkpoolCounter[num56]];
							for (int num62 = 0; num62 < this.EffectBallYolkParticle.Length; num62++)
							{
								this.EffectBallYolkParticle[num62][col][row] = this.EffectBallYolkParticlePools[num62][num56][this.BallYolkpoolCounter[num56]];
								this.EffectBallYolkParticle[num62][col][row].startSize = this.BallYolkstartSize[num62] * x;
							}
							this.EffectBallYolkGameObjectPools[num56][this.BallYolkpoolCounter[num56]] = null;
							this.EffectBallYolkTransformPools[num56][this.BallYolkpoolCounter[num56]] = null;
							for (int num63 = 0; num63 < this.EffectBallYolkParticle.Length; num63++)
							{
								this.EffectBallYolkParticlePools[num63][num56][this.BallYolkpoolCounter[num56]] = null;
							}
						}
						this.EffectBallYolkGameObject[col][row].SetActive(true);
						if (this.Particletimer[col][row] > 0f && this.Particlekind[col][row] != 3)
						{
							this.EffectGone(row, col);
						}
						this.Particletimer[col][row] = 2f * x;
						this.Particlekind[col][row] = 3;
					}
					this.EffectBallYolkTransform[col][row].localPosition = pos + zero2;
				}
			}
			else if (this.EffectBallYolkGameObject[col][row] != null)
			{
				this.EffectBallYolkGameObject[col][row].SetActive(false);
				if (this.Particlekind[col][row] == 3)
				{
					this.Particletimer[col][row] = 0f;
					this.Particlekind[col][row] = 0;
				}
				for (int num64 = 0; num64 < this.BallYolkpoolsCounter; num64++)
				{
					if (this.BallYolkpoolCounter[num64] < this.EffectBallYolkGameObjectPools[num64].Length)
					{
						this.EffectBallYolkGameObjectPools[num64][this.BallYolkpoolCounter[num64]] = this.EffectBallYolkGameObject[col][row];
						this.EffectBallYolkTransformPools[num64][this.BallYolkpoolCounter[num64]] = this.EffectBallYolkTransform[col][row];
						for (int num65 = 0; num65 < this.EffectBallYolkParticlePools.Length; num65++)
						{
							this.EffectBallYolkParticlePools[num65][num64][this.BallYolkpoolCounter[num64]] = this.EffectBallYolkParticle[num65][col][row];
						}
						this.EffectBallYolkGameObject[col][row] = null;
						this.EffectBallYolkTransform[col][row] = null;
						for (int num66 = 0; num66 < this.EffectBallYolkParticlePools.Length; num66++)
						{
							this.EffectBallYolkParticle[num66][col][row] = null;
						}
						this.BallYolkpoolCounter[num64]++;
						break;
					}
				}
			}
			if (effecttype == 8)
			{
				if (this.active)
				{
					if (this.EffectBallNPCCityGameObject[col][row] == null)
					{
						int num67;
						for (num67 = 0; num67 < this.BallNPCCitypoolsCounter; num67++)
						{
							if (this.BallNPCCitypoolCounter[num67] > 0)
							{
								this.BallNPCCitypoolCounter[num67]--;
								this.EffectBallNPCCityGameObject[col][row] = this.EffectBallNPCCityGameObjectPools[num67][this.BallNPCCitypoolCounter[num67]];
								this.EffectBallNPCCityTransform[col][row] = this.EffectBallNPCCityTransformPools[num67][this.BallNPCCitypoolCounter[num67]];
								for (int num68 = 0; num68 < this.EffectBallNPCCityParticle.Length; num68++)
								{
									this.EffectBallNPCCityParticle[num68][col][row] = this.EffectBallNPCCityParticlePools[num68][num67][this.BallNPCCitypoolCounter[num67]];
								}
								this.EffectBallNPCCityGameObjectPools[num67][this.BallNPCCitypoolCounter[num67]] = null;
								this.EffectBallNPCCityTransformPools[num67][this.BallNPCCitypoolCounter[num67]] = null;
								for (int num69 = 0; num69 < this.EffectBallNPCCityParticle.Length; num69++)
								{
									this.EffectBallNPCCityParticlePools[num69][num67][this.BallNPCCitypoolCounter[num67]] = null;
								}
								this.setEffect(row, col, DataManager.MapDataController.zoomSize);
								break;
							}
						}
						if (num67 == this.BallNPCCitypoolsCounter)
						{
							this.EffectBallNPCCityGameObjectPools[num67] = new GameObject[this.EffectBallNPCCityGameObjectPools[0].Length];
							this.EffectBallNPCCityTransformPools[num67] = new Transform[this.EffectBallNPCCityTransformPools[0].Length];
							for (int num70 = 0; num70 < this.EffectBallNPCCityParticlePools.Length; num70++)
							{
								this.EffectBallNPCCityParticlePools[num70][num67] = new ParticleSystem[this.EffectBallNPCCityParticlePools[0].Length];
							}
							for (int num71 = 0; num71 < this.EffectBallNPCCityGameObjectPools[num67].Length; num71++)
							{
								this.EffectBallNPCCityGameObjectPools[num67][num71] = ParticleManager.Instance.Spawn(60504, null, Vector3.zero, 1f, false, false, true);
								if (this.EffectBallNPCCityGameObjectPools[num67][num71] == null)
								{
									this.EffectBallNPCCityGameObjectPools[num67][num71] = ParticleManager.Instance.Spawn(60504, null, Vector3.zero, 1f, false, false, true);
								}
								this.EffectBallNPCCityTransformPools[num67][num71] = this.EffectBallNPCCityGameObjectPools[num67][num71].transform;
								this.EffectBallNPCCityTransformPools[num67][num71].SetParent(this.BallNPCCityLayoutTransform, false);
								this.EffectBallNPCCityTransformPools[num67][num71].localPosition = this.inipos;
								for (int num72 = 0; num72 < this.EffectBallNPCCityParticlePools.Length; num72++)
								{
									this.EffectBallNPCCityParticlePools[num72][num67][num71] = this.EffectBallNPCCityTransformPools[num67][num71].GetChild(num72).GetComponent<ParticleSystem>();
								}
							}
							this.BallNPCCitypoolsCounter++;
							this.BallNPCCitypoolCounter[num67] = this.EffectBallNPCCityGameObjectPools[num67].Length;
							this.BallNPCCitypoolCounter[num67]--;
							this.EffectBallNPCCityGameObject[col][row] = this.EffectBallNPCCityGameObjectPools[num67][this.BallNPCCitypoolCounter[num67]];
							this.EffectBallNPCCityTransform[col][row] = this.EffectBallNPCCityTransformPools[num67][this.BallNPCCitypoolCounter[num67]];
							for (int num73 = 0; num73 < this.EffectBallNPCCityParticle.Length; num73++)
							{
								this.EffectBallNPCCityParticle[num73][col][row] = this.EffectBallNPCCityParticlePools[num73][num67][this.BallNPCCitypoolCounter[num67]];
								this.EffectBallNPCCityParticle[num73][col][row].startSize = this.BallNPCCitystartSize[num73] * x;
							}
							this.EffectBallNPCCityGameObjectPools[num67][this.BallNPCCitypoolCounter[num67]] = null;
							this.EffectBallNPCCityTransformPools[num67][this.BallNPCCitypoolCounter[num67]] = null;
							for (int num74 = 0; num74 < this.EffectBallNPCCityParticle.Length; num74++)
							{
								this.EffectBallNPCCityParticlePools[num74][num67][this.BallNPCCitypoolCounter[num67]] = null;
							}
						}
						this.EffectBallNPCCityGameObject[col][row].SetActive(true);
						if (this.Particletimer[col][row] > 0f && this.Particlekind[col][row] != 4)
						{
							this.EffectGone(row, col);
						}
						this.Particletimer[col][row] = 2f * x;
						this.Particlekind[col][row] = 4;
					}
					this.EffectBallNPCCityTransform[col][row].localPosition = pos;
				}
			}
			else if (this.EffectBallNPCCityGameObject[col][row] != null)
			{
				this.EffectBallNPCCityGameObject[col][row].SetActive(false);
				if (this.Particlekind[col][row] == 4)
				{
					this.Particletimer[col][row] = 0f;
					this.Particlekind[col][row] = 0;
				}
				for (int num75 = 0; num75 < this.BallNPCCitypoolsCounter; num75++)
				{
					if (this.BallNPCCitypoolCounter[num75] < this.EffectBallNPCCityGameObjectPools[num75].Length)
					{
						this.EffectBallNPCCityGameObjectPools[num75][this.BallNPCCitypoolCounter[num75]] = this.EffectBallNPCCityGameObject[col][row];
						this.EffectBallNPCCityTransformPools[num75][this.BallNPCCitypoolCounter[num75]] = this.EffectBallNPCCityTransform[col][row];
						for (int num76 = 0; num76 < this.EffectBallNPCCityParticlePools.Length; num76++)
						{
							this.EffectBallNPCCityParticlePools[num76][num75][this.BallNPCCitypoolCounter[num75]] = this.EffectBallNPCCityParticle[num76][col][row];
						}
						this.EffectBallNPCCityGameObject[col][row] = null;
						this.EffectBallNPCCityTransform[col][row] = null;
						for (int num77 = 0; num77 < this.EffectBallNPCCityParticlePools.Length; num77++)
						{
							this.EffectBallNPCCityParticle[num77][col][row] = null;
						}
						this.BallNPCCitypoolCounter[num75]++;
						break;
					}
				}
			}
			if (effecttype == 9)
			{
				if (this.active)
				{
					if (this.EffectBallOutGameObject[col][row] == null)
					{
						int num78;
						for (num78 = 0; num78 < this.BallOutpoolsCounter; num78++)
						{
							if (this.BallOutpoolCounter[num78] > 0)
							{
								this.BallOutpoolCounter[num78]--;
								this.EffectBallOutGameObject[col][row] = this.EffectBallOutGameObjectPools[num78][this.BallOutpoolCounter[num78]];
								this.EffectBallOutTransform[col][row] = this.EffectBallOutTransformPools[num78][this.BallOutpoolCounter[num78]];
								for (int num79 = 0; num79 < this.EffectBallOutParticle.Length; num79++)
								{
									this.EffectBallOutParticle[num79][col][row] = this.EffectBallOutParticlePools[num79][num78][this.BallOutpoolCounter[num78]];
								}
								this.EffectBallOutGameObjectPools[num78][this.BallOutpoolCounter[num78]] = null;
								this.EffectBallOutTransformPools[num78][this.BallOutpoolCounter[num78]] = null;
								for (int num80 = 0; num80 < this.EffectBallOutParticle.Length; num80++)
								{
									this.EffectBallOutParticlePools[num80][num78][this.BallOutpoolCounter[num78]] = null;
								}
								this.setEffect(row, col, DataManager.MapDataController.zoomSize);
								break;
							}
						}
						if (num78 == this.BallOutpoolsCounter)
						{
							this.EffectBallOutGameObjectPools[num78] = new GameObject[this.EffectBallOutGameObjectPools[0].Length];
							this.EffectBallOutTransformPools[num78] = new Transform[this.EffectBallOutTransformPools[0].Length];
							for (int num81 = 0; num81 < this.EffectBallOutParticlePools.Length; num81++)
							{
								this.EffectBallOutParticlePools[num81][num78] = new ParticleSystem[this.EffectBallOutParticlePools[0].Length];
							}
							for (int num82 = 0; num82 < this.EffectBallOutGameObjectPools[num78].Length; num82++)
							{
								this.EffectBallOutGameObjectPools[num78][num82] = ParticleManager.Instance.Spawn(60505, null, Vector3.zero, 1f, false, false, true);
								if (this.EffectBallOutGameObjectPools[num78][num82] == null)
								{
									this.EffectBallOutGameObjectPools[num78][num82] = ParticleManager.Instance.Spawn(60505, null, Vector3.zero, 1f, false, false, true);
								}
								this.EffectBallOutTransformPools[num78][num82] = this.EffectBallOutGameObjectPools[num78][num82].transform;
								this.EffectBallOutTransformPools[num78][num82].SetParent(this.BallOutLayoutTransform, false);
								this.EffectBallOutTransformPools[num78][num82].localPosition = this.inipos;
								for (int num83 = 0; num83 < this.EffectBallOutParticlePools.Length; num83++)
								{
									this.EffectBallOutParticlePools[num83][num78][num82] = this.EffectBallOutTransformPools[num78][num82].GetChild(num83).GetComponent<ParticleSystem>();
								}
							}
							this.BallOutpoolsCounter++;
							this.BallOutpoolCounter[num78] = this.EffectBallOutGameObjectPools[num78].Length;
							this.BallOutpoolCounter[num78]--;
							this.EffectBallOutGameObject[col][row] = this.EffectBallOutGameObjectPools[num78][this.BallOutpoolCounter[num78]];
							this.EffectBallOutTransform[col][row] = this.EffectBallOutTransformPools[num78][this.BallOutpoolCounter[num78]];
							for (int num84 = 0; num84 < this.EffectBallOutParticle.Length; num84++)
							{
								this.EffectBallOutParticle[num84][col][row] = this.EffectBallOutParticlePools[num84][num78][this.BallOutpoolCounter[num78]];
								this.EffectBallOutParticle[num84][col][row].startSize = this.BallOutstartSize[num84] * x;
							}
							this.EffectBallOutGameObjectPools[num78][this.BallOutpoolCounter[num78]] = null;
							this.EffectBallOutTransformPools[num78][this.BallOutpoolCounter[num78]] = null;
							for (int num85 = 0; num85 < this.EffectBallOutParticle.Length; num85++)
							{
								this.EffectBallOutParticlePools[num85][num78][this.BallOutpoolCounter[num78]] = null;
							}
						}
						this.EffectBallOutGameObject[col][row].SetActive(true);
						if (this.Particletimer[col][row] > 0f && this.Particlekind[col][row] != 5)
						{
							this.EffectGone(row, col);
						}
						this.Particletimer[col][row] = 2f * x;
						this.Particlekind[col][row] = 5;
					}
					this.EffectBallOutTransform[col][row].localPosition = pos;
				}
			}
			else if (this.EffectBallOutGameObject[col][row] != null)
			{
				this.EffectBallOutGameObject[col][row].SetActive(false);
				if (this.Particlekind[col][row] == 5)
				{
					this.Particletimer[col][row] = 0f;
					this.Particlekind[col][row] = 0;
				}
				for (int num86 = 0; num86 < this.BallOutpoolsCounter; num86++)
				{
					if (this.BallOutpoolCounter[num86] < this.EffectBallOutGameObjectPools[num86].Length)
					{
						this.EffectBallOutGameObjectPools[num86][this.BallOutpoolCounter[num86]] = this.EffectBallOutGameObject[col][row];
						this.EffectBallOutTransformPools[num86][this.BallOutpoolCounter[num86]] = this.EffectBallOutTransform[col][row];
						for (int num87 = 0; num87 < this.EffectBallOutParticlePools.Length; num87++)
						{
							this.EffectBallOutParticlePools[num87][num86][this.BallOutpoolCounter[num86]] = this.EffectBallOutParticle[num87][col][row];
						}
						this.EffectBallOutGameObject[col][row] = null;
						this.EffectBallOutTransform[col][row] = null;
						for (int num88 = 0; num88 < this.EffectBallOutParticlePools.Length; num88++)
						{
							this.EffectBallOutParticle[num88][col][row] = null;
						}
						this.BallOutpoolCounter[num86]++;
						break;
					}
				}
			}
			if (effecttype == 10)
			{
				if (this.active)
				{
					if (this.EffectBallKickGameObject[col][row] == null)
					{
						int num89;
						for (num89 = 0; num89 < this.BallKickpoolsCounter; num89++)
						{
							if (this.BallKickpoolCounter[num89] > 0)
							{
								this.BallKickpoolCounter[num89]--;
								this.EffectBallKickGameObject[col][row] = this.EffectBallKickGameObjectPools[num89][this.BallKickpoolCounter[num89]];
								this.EffectBallKickTransform[col][row] = this.EffectBallKickTransformPools[num89][this.BallKickpoolCounter[num89]];
								for (int num90 = 0; num90 < this.EffectBallKickParticle.Length; num90++)
								{
									this.EffectBallKickParticle[num90][col][row] = this.EffectBallKickParticlePools[num90][num89][this.BallKickpoolCounter[num89]];
								}
								this.EffectBallKickGameObjectPools[num89][this.BallKickpoolCounter[num89]] = null;
								this.EffectBallKickTransformPools[num89][this.BallKickpoolCounter[num89]] = null;
								for (int num91 = 0; num91 < this.EffectBallKickParticle.Length; num91++)
								{
									this.EffectBallKickParticlePools[num91][num89][this.BallKickpoolCounter[num89]] = null;
								}
								this.setEffect(row, col, DataManager.MapDataController.zoomSize);
								break;
							}
						}
						if (num89 == this.BallKickpoolsCounter)
						{
							this.EffectBallKickGameObjectPools[num89] = new GameObject[this.EffectBallKickGameObjectPools[0].Length];
							this.EffectBallKickTransformPools[num89] = new Transform[this.EffectBallKickTransformPools[0].Length];
							for (int num92 = 0; num92 < this.EffectBallKickParticlePools.Length; num92++)
							{
								this.EffectBallKickParticlePools[num92][num89] = new ParticleSystem[this.EffectBallKickParticlePools[0].Length];
							}
							for (int num93 = 0; num93 < this.EffectBallKickGameObjectPools[num89].Length; num93++)
							{
								this.EffectBallKickGameObjectPools[num89][num93] = ParticleManager.Instance.Spawn(60506, null, Vector3.zero, 1f, false, false, true);
								if (this.EffectBallKickGameObjectPools[num89][num93] == null)
								{
									this.EffectBallKickGameObjectPools[num89][num93] = ParticleManager.Instance.Spawn(60506, null, Vector3.zero, 1f, false, false, true);
								}
								this.EffectBallKickTransformPools[num89][num93] = this.EffectBallKickGameObjectPools[num89][num93].transform;
								this.EffectBallKickTransformPools[num89][num93].SetParent(this.BallKickLayoutTransform, false);
								this.EffectBallKickTransformPools[num89][num93].localPosition = this.inipos;
								for (int num94 = 0; num94 < this.EffectBallKickParticlePools.Length; num94++)
								{
									this.EffectBallKickParticlePools[num94][num89][num93] = this.EffectBallKickTransformPools[num89][num93].GetChild(num94).GetComponent<ParticleSystem>();
								}
							}
							this.BallKickpoolsCounter++;
							this.BallKickpoolCounter[num89] = this.EffectBallKickGameObjectPools[num89].Length;
							this.BallKickpoolCounter[num89]--;
							this.EffectBallKickGameObject[col][row] = this.EffectBallKickGameObjectPools[num89][this.BallKickpoolCounter[num89]];
							this.EffectBallKickTransform[col][row] = this.EffectBallKickTransformPools[num89][this.BallKickpoolCounter[num89]];
							for (int num95 = 0; num95 < this.EffectBallKickParticle.Length; num95++)
							{
								this.EffectBallKickParticle[num95][col][row] = this.EffectBallKickParticlePools[num95][num89][this.BallKickpoolCounter[num89]];
								this.EffectBallKickParticle[num95][col][row].startSize = this.BallKickstartSize[num95] * x;
							}
							this.EffectBallKickGameObjectPools[num89][this.BallKickpoolCounter[num89]] = null;
							this.EffectBallKickTransformPools[num89][this.BallKickpoolCounter[num89]] = null;
							for (int num96 = 0; num96 < this.EffectBallKickParticle.Length; num96++)
							{
								this.EffectBallKickParticlePools[num96][num89][this.BallKickpoolCounter[num89]] = null;
							}
						}
						this.EffectBallKickGameObject[col][row].SetActive(true);
						if (this.Particletimer[col][row] > 0f && this.Particlekind[col][row] != 6)
						{
							this.EffectGone(row, col);
						}
						this.Particletimer[col][row] = 0.6f * x;
						this.Particlekind[col][row] = 6;
					}
					this.EffectBallKickTransform[col][row].localPosition = pos;
				}
			}
			else if (this.EffectBallKickGameObject[col][row] != null)
			{
				this.EffectBallKickGameObject[col][row].SetActive(false);
				if (this.Particlekind[col][row] == 6)
				{
					this.Particletimer[col][row] = 0f;
					this.Particlekind[col][row] = 0;
				}
				for (int num97 = 0; num97 < this.BallKickpoolsCounter; num97++)
				{
					if (this.BallKickpoolCounter[num97] < this.EffectBallKickGameObjectPools[num97].Length)
					{
						this.EffectBallKickGameObjectPools[num97][this.BallKickpoolCounter[num97]] = this.EffectBallKickGameObject[col][row];
						this.EffectBallKickTransformPools[num97][this.BallKickpoolCounter[num97]] = this.EffectBallKickTransform[col][row];
						for (int num98 = 0; num98 < this.EffectBallKickParticlePools.Length; num98++)
						{
							this.EffectBallKickParticlePools[num98][num97][this.BallKickpoolCounter[num97]] = this.EffectBallKickParticle[num98][col][row];
						}
						this.EffectBallKickGameObject[col][row] = null;
						this.EffectBallKickTransform[col][row] = null;
						for (int num99 = 0; num99 < this.EffectBallKickParticlePools.Length; num99++)
						{
							this.EffectBallKickParticle[num99][col][row] = null;
						}
						this.BallKickpoolCounter[num97]++;
						break;
					}
				}
			}
		}
	}

	// Token: 0x06000B3E RID: 2878 RVA: 0x000FEBD8 File Offset: 0x000FCDD8
	public void setEffect(int row, int col, Vector2 pos)
	{
		Vector3 vector = new Vector3(pos.x, pos.y, 0f);
		Vector3 b = new Vector3(0f, 64f, 0f);
		Vector3 b2 = new Vector3(0f, 55f, 0f);
		if (this.EffectWinGameObject[col][row] != null)
		{
			this.EffectWinTransform[col][row].localPosition = vector;
		}
		if (this.EffectLoseGameObject[col][row] != null)
		{
			this.EffectLoseTransform[col][row].localPosition = vector;
		}
		if (this.EffectEnemyLoseGameObject[col][row] != null)
		{
			this.EffectEnemyLoseTransform[col][row].localPosition = vector;
		}
		if (this.EffectShieldGameObject[col][row] != null)
		{
			this.EffectShieldTransform[col][row].localPosition = vector;
		}
		if (this.EffectConveyGameObject[col][row] != null)
		{
			this.EffectConveyTransform[col][row].localPosition = vector;
		}
		if (this.EffectNPCCityConveyGameObject[col][row] != null)
		{
			this.EffectNPCCityConveyTransform[col][row].localPosition = vector;
		}
		if (this.EffectMapWeaponHurtGameObject[col][row] != null)
		{
			this.EffectMapWeaponHurtTransform[col][row].localPosition = vector + b2;
		}
		if (this.EffectBallDownGameObject[col][row] != null)
		{
			this.EffectBallDownTransform[col][row].localPosition = vector;
		}
		if (this.EffectBallBigYolkGameObject[col][row] != null)
		{
			this.EffectBallBigYolkTransform[col][row].localPosition = vector + b;
		}
		if (this.EffectBallYolkGameObject[col][row] != null)
		{
			this.EffectBallYolkTransform[col][row].localPosition = vector + b;
		}
		if (this.EffectBallNPCCityGameObject[col][row] != null)
		{
			this.EffectBallNPCCityTransform[col][row].localPosition = vector;
		}
		if (this.EffectBallOutGameObject[col][row] != null)
		{
			this.EffectBallOutTransform[col][row].localPosition = vector;
		}
		if (this.EffectBallKickGameObject[col][row] != null)
		{
			this.EffectBallKickTransform[col][row].localPosition = vector;
		}
		if (this.Yolkrow == row && this.Yolkcol == col)
		{
			if (this.EffectYolkWinGameObject.activeSelf)
			{
				this.EffectYolkWinTransform.localPosition = vector;
			}
			if (this.EffectYolkLoseGameObject.activeSelf)
			{
				this.EffectYolkLoseTransform.localPosition = vector;
			}
			if (this.EffectYolkShieldGameObject.activeSelf)
			{
				this.EffectYolkShieldTransform.localPosition = vector;
			}
			if (this.EffectBigYolkWinGameObject.activeSelf)
			{
				this.EffectBigYolkWinTransform.localPosition = vector;
			}
			if (this.EffectBigYolkLoseGameObject.activeSelf)
			{
				this.EffectBigYolkLoseTransform.localPosition = vector;
			}
			if (this.EffectBigYolkShieldGameObject.activeSelf)
			{
				this.EffectBigYolkShieldTransform.localPosition = vector;
			}
		}
	}

	// Token: 0x06000B3F RID: 2879 RVA: 0x000FEEE0 File Offset: 0x000FD0E0
	public void setEffect(int row, int col, float scale)
	{
		float num = 0f;
		if (this.EffectWinGameObject[col][row] != null)
		{
			float num2 = this.EffectWinParticle[col][row].startSize;
			num = this.EffectWinParticle[col][row].startLifetime;
			this.EffectWinParticle[col][row].startSize = this.WinstartSize * scale;
			this.EffectWinParticle[col][row].startLifetime = this.Winlifetime * scale;
			num2 = this.EffectWinParticle[col][row].startSize / num2;
			num = this.EffectWinParticle[col][row].startLifetime / num;
			int num3 = this.EffectWinParticle[col][row].GetParticles(this.particles);
			for (int i = 0; i < num3; i++)
			{
				ParticleSystem.Particle[] array = this.particles;
				int num4 = i;
				array[num4].size = array[num4].size * num2;
				ParticleSystem.Particle[] array2 = this.particles;
				int num5 = i;
				array2[num5].lifetime = array2[num5].lifetime * num;
			}
			this.EffectWinParticle[col][row].SetParticles(this.particles, num3);
		}
		if (this.EffectLoseGameObject[col][row] != null)
		{
			float num2 = this.EffectLoseParticle[col][row].startSize;
			num = this.EffectLoseParticle[col][row].startLifetime;
			this.EffectLoseParticle[col][row].startSize = this.LosestartSize * scale;
			this.EffectLoseParticle[col][row].startLifetime = this.Loselifetime * scale;
			num2 = this.EffectLoseParticle[col][row].startSize / num2;
			num = this.EffectLoseParticle[col][row].startLifetime / num;
			int num3 = this.EffectLoseParticle[col][row].GetParticles(this.particles);
			for (int j = 0; j < num3; j++)
			{
				ParticleSystem.Particle[] array3 = this.particles;
				int num6 = j;
				array3[num6].size = array3[num6].size * num2;
				ParticleSystem.Particle[] array4 = this.particles;
				int num7 = j;
				array4[num7].lifetime = array4[num7].lifetime * num;
			}
			this.EffectLoseParticle[col][row].SetParticles(this.particles, num3);
		}
		if (this.EffectEnemyLoseGameObject[col][row] != null)
		{
			float num2 = this.EffectEnemyLoseParticle[col][row].startSize;
			num = this.EffectEnemyLoseParticle[col][row].startLifetime;
			this.EffectEnemyLoseParticle[col][row].startSize = this.EnemyLosestartSize * scale;
			this.EffectEnemyLoseParticle[col][row].startLifetime = this.EnemyLoselifetime * scale;
			num2 = this.EffectEnemyLoseParticle[col][row].startSize / num2;
			num = this.EffectEnemyLoseParticle[col][row].startLifetime / num;
			int num3 = this.EffectEnemyLoseParticle[col][row].GetParticles(this.particles);
			for (int k = 0; k < num3; k++)
			{
				ParticleSystem.Particle[] array5 = this.particles;
				int num8 = k;
				array5[num8].size = array5[num8].size * num2;
				ParticleSystem.Particle[] array6 = this.particles;
				int num9 = k;
				array6[num9].lifetime = array6[num9].lifetime * num;
			}
			this.EffectEnemyLoseParticle[col][row].SetParticles(this.particles, num3);
		}
		if (this.EffectShieldGameObject[col][row] != null)
		{
			float num2 = this.EffectShieldParticle[col][row].startSize;
			this.EffectShieldParticle[col][row].startSize = this.ShieldstartSize * scale;
			num2 = this.EffectShieldParticle[col][row].startSize / num2;
			num = this.EffectShieldParticle[col][row].startLifetime / num;
			int num3 = this.EffectShieldParticle[col][row].GetParticles(this.particles);
			for (int l = 0; l < num3; l++)
			{
				ParticleSystem.Particle[] array7 = this.particles;
				int num10 = l;
				array7[num10].size = array7[num10].size * num2;
			}
			this.EffectShieldParticle[col][row].SetParticles(this.particles, num3);
			num2 = this.EffectShieldParticle_one[col][row].startSize;
			this.EffectShieldParticle_one[col][row].startSize = this.ShieldstartSize * scale;
			num2 = this.EffectShieldParticle_one[col][row].startSize / num2;
			num = this.EffectShieldParticle_one[col][row].startLifetime / num;
			num3 = this.EffectShieldParticle_one[col][row].GetParticles(this.particles);
			for (int m = 0; m < num3; m++)
			{
				ParticleSystem.Particle[] array8 = this.particles;
				int num11 = m;
				array8[num11].size = array8[num11].size * num2;
			}
			this.EffectShieldParticle_one[col][row].SetParticles(this.particles, num3);
		}
		if (this.EffectConveyGameObject[col][row] != null)
		{
			float num2 = this.EffectConveyParticle[col][row].startSize;
			num = this.EffectConveyParticle[col][row].startLifetime;
			this.EffectConveyParticle[col][row].startSize = this.ConveystartSize * scale;
			this.EffectConveyParticle[col][row].startLifetime = this.Conveylifetime * scale;
			num2 = this.EffectConveyParticle[col][row].startSize / num2;
			num = this.EffectConveyParticle[col][row].startLifetime / num;
			int num3 = this.EffectConveyParticle[col][row].GetParticles(this.particles);
			for (int n = 0; n < num3; n++)
			{
				ParticleSystem.Particle[] array9 = this.particles;
				int num12 = n;
				array9[num12].size = array9[num12].size * num2;
				ParticleSystem.Particle[] array10 = this.particles;
				int num13 = n;
				array10[num13].lifetime = array10[num13].lifetime * num;
			}
			this.EffectConveyParticle[col][row].SetParticles(this.particles, num3);
			num2 = this.EffectConveyParticle_one[col][row].startSize;
			this.EffectConveyParticle_one[col][row].startSize = this.ConveystartSize_one * scale;
			this.EffectConveyParticle_one[col][row].startLifetime = this.Conveylifetime_one * scale;
			num2 = this.EffectConveyParticle_one[col][row].startSize / num2;
			num = this.EffectConveyParticle_one[col][row].startLifetime / num;
			num3 = this.EffectConveyParticle_one[col][row].GetParticles(this.particles);
			for (int num14 = 0; num14 < num3; num14++)
			{
				ParticleSystem.Particle[] array11 = this.particles;
				int num15 = num14;
				array11[num15].size = array11[num15].size * num2;
				ParticleSystem.Particle[] array12 = this.particles;
				int num16 = num14;
				array12[num16].lifetime = array12[num16].lifetime * num;
			}
			this.EffectConveyParticle_one[col][row].SetParticles(this.particles, num3);
			num2 = this.EffectConveyParticle_two[col][row].startSize;
			this.EffectConveyParticle_two[col][row].startSize = this.ConveystartSize_two * scale;
			this.EffectConveyParticle_two[col][row].startLifetime = this.Conveylifetime_two * scale;
			num2 = this.EffectConveyParticle_two[col][row].startSize / num2;
			num = this.EffectConveyParticle_two[col][row].startLifetime / num;
			num3 = this.EffectConveyParticle_two[col][row].GetParticles(this.particles);
			for (int num17 = 0; num17 < num3; num17++)
			{
				ParticleSystem.Particle[] array13 = this.particles;
				int num18 = num17;
				array13[num18].size = array13[num18].size * num2;
				ParticleSystem.Particle[] array14 = this.particles;
				int num19 = num17;
				array14[num19].lifetime = array14[num19].lifetime * num;
			}
			this.EffectConveyParticle_two[col][row].SetParticles(this.particles, num3);
			num2 = this.EffectConveyParticle_thr[col][row].startSize;
			this.EffectConveyParticle_thr[col][row].startSize = this.ConveystartSize_thr * scale;
			this.EffectConveyParticle_thr[col][row].startLifetime = this.Conveylifetime_thr * scale;
			num2 = this.EffectConveyParticle_thr[col][row].startSize / num2;
			num = this.EffectConveyParticle_thr[col][row].startLifetime / num;
			num3 = this.EffectConveyParticle_thr[col][row].GetParticles(this.particles);
			for (int num20 = 0; num20 < num3; num20++)
			{
				ParticleSystem.Particle[] array15 = this.particles;
				int num21 = num20;
				array15[num21].size = array15[num21].size * num2;
				ParticleSystem.Particle[] array16 = this.particles;
				int num22 = num20;
				array16[num22].lifetime = array16[num22].lifetime * num;
			}
			this.EffectConveyParticle_thr[col][row].SetParticles(this.particles, num3);
		}
		if (this.EffectNPCCityConveyGameObject[col][row] != null)
		{
			float num2 = this.EffectNPCCityConveyParticle[col][row].startSize;
			num = this.EffectNPCCityConveyParticle[col][row].startLifetime;
			this.EffectNPCCityConveyParticle[col][row].startSize = this.NPCCityConveystartSize * scale;
			this.EffectNPCCityConveyParticle[col][row].startLifetime = this.NPCCityConveylifetime * scale;
			num2 = this.EffectNPCCityConveyParticle[col][row].startSize / num2;
			num = this.EffectNPCCityConveyParticle[col][row].startLifetime / num;
			int num3 = this.EffectNPCCityConveyParticle[col][row].GetParticles(this.particles);
			for (int num23 = 0; num23 < num3; num23++)
			{
				ParticleSystem.Particle[] array17 = this.particles;
				int num24 = num23;
				array17[num24].size = array17[num24].size * num2;
				ParticleSystem.Particle[] array18 = this.particles;
				int num25 = num23;
				array18[num25].lifetime = array18[num25].lifetime * num;
			}
			this.EffectNPCCityConveyParticle[col][row].SetParticles(this.particles, num3);
			num2 = this.EffectNPCCityConveyParticle_one[col][row].startSize;
			this.EffectNPCCityConveyParticle_one[col][row].startSize = this.NPCCityConveystartSize_one * scale;
			this.EffectNPCCityConveyParticle_one[col][row].startLifetime = this.NPCCityConveylifetime_one * scale;
			num2 = this.EffectNPCCityConveyParticle_one[col][row].startSize / num2;
			num = this.EffectNPCCityConveyParticle_one[col][row].startLifetime / num;
			num3 = this.EffectNPCCityConveyParticle_one[col][row].GetParticles(this.particles);
			for (int num26 = 0; num26 < num3; num26++)
			{
				ParticleSystem.Particle[] array19 = this.particles;
				int num27 = num26;
				array19[num27].size = array19[num27].size * num2;
				ParticleSystem.Particle[] array20 = this.particles;
				int num28 = num26;
				array20[num28].lifetime = array20[num28].lifetime * num;
			}
			this.EffectNPCCityConveyParticle_one[col][row].SetParticles(this.particles, num3);
			num2 = this.EffectNPCCityConveyParticle_two[col][row].startSize;
			this.EffectNPCCityConveyParticle_two[col][row].startSize = this.NPCCityConveystartSize_two * scale;
			this.EffectNPCCityConveyParticle_two[col][row].startLifetime = this.NPCCityConveylifetime_two * scale;
			num2 = this.EffectNPCCityConveyParticle_two[col][row].startSize / num2;
			num = this.EffectNPCCityConveyParticle_two[col][row].startLifetime / num;
			num3 = this.EffectNPCCityConveyParticle_two[col][row].GetParticles(this.particles);
			for (int num29 = 0; num29 < num3; num29++)
			{
				ParticleSystem.Particle[] array21 = this.particles;
				int num30 = num29;
				array21[num30].size = array21[num30].size * num2;
				ParticleSystem.Particle[] array22 = this.particles;
				int num31 = num29;
				array22[num31].lifetime = array22[num31].lifetime * num;
			}
			this.EffectNPCCityConveyParticle_two[col][row].SetParticles(this.particles, num3);
			num2 = this.EffectNPCCityConveyParticle_thr[col][row].startSize;
			this.EffectNPCCityConveyParticle_thr[col][row].startSize = this.NPCCityConveystartSize_thr * scale;
			this.EffectNPCCityConveyParticle_thr[col][row].startLifetime = this.NPCCityConveylifetime_thr * scale;
			num2 = this.EffectNPCCityConveyParticle_thr[col][row].startSize / num2;
			num = this.EffectNPCCityConveyParticle_thr[col][row].startLifetime / num;
			num3 = this.EffectNPCCityConveyParticle_thr[col][row].GetParticles(this.particles);
			for (int num32 = 0; num32 < num3; num32++)
			{
				ParticleSystem.Particle[] array23 = this.particles;
				int num33 = num32;
				array23[num33].size = array23[num33].size * num2;
				ParticleSystem.Particle[] array24 = this.particles;
				int num34 = num32;
				array24[num34].lifetime = array24[num34].lifetime * num;
			}
			this.EffectNPCCityConveyParticle_thr[col][row].SetParticles(this.particles, num3);
		}
		if (this.EffectMapWeaponHurtGameObject[col][row] != null)
		{
			for (int num35 = 0; num35 < this.EffectMapWeaponHurtParticle.Length; num35++)
			{
				float num2 = this.EffectMapWeaponHurtParticle[num35][col][row].startSize;
				num = this.EffectMapWeaponHurtParticle[num35][col][row].startLifetime;
				this.EffectMapWeaponHurtParticle[num35][col][row].startSize = this.MapWeaponHurtstartSize[num35] * scale;
				this.EffectMapWeaponHurtParticle[num35][col][row].startLifetime = this.MapWeaponHurtlifetime[num35] * scale;
				num2 = this.EffectMapWeaponHurtParticle[num35][col][row].startSize / num2;
				num = this.EffectMapWeaponHurtParticle[num35][col][row].startLifetime / num;
				int num3 = this.EffectMapWeaponHurtParticle[num35][col][row].GetParticles(this.particles);
				for (int num36 = 0; num36 < num3; num36++)
				{
					ParticleSystem.Particle[] array25 = this.particles;
					int num37 = num36;
					array25[num37].size = array25[num37].size * num2;
					ParticleSystem.Particle[] array26 = this.particles;
					int num38 = num36;
					array26[num38].lifetime = array26[num38].lifetime * num;
				}
				this.EffectMapWeaponHurtParticle[num35][col][row].SetParticles(this.particles, num3);
			}
		}
		if (this.EffectBallDownGameObject[col][row] != null)
		{
			for (int num39 = 0; num39 < this.EffectBallDownParticle.Length; num39++)
			{
				float num2 = this.EffectBallDownParticle[num39][col][row].startSize;
				num = this.EffectBallDownParticle[num39][col][row].startLifetime;
				this.EffectBallDownParticle[num39][col][row].startSize = this.BallDownstartSize[num39] * scale;
				this.EffectBallDownParticle[num39][col][row].startLifetime = this.BallDownlifetime[num39] * scale;
				num2 = this.EffectBallDownParticle[num39][col][row].startSize / num2;
				num = this.EffectBallDownParticle[num39][col][row].startLifetime / num;
				int num3 = this.EffectBallDownParticle[num39][col][row].GetParticles(this.particles);
				for (int num40 = 0; num40 < num3; num40++)
				{
					ParticleSystem.Particle[] array27 = this.particles;
					int num41 = num40;
					array27[num41].size = array27[num41].size * num2;
					ParticleSystem.Particle[] array28 = this.particles;
					int num42 = num40;
					array28[num42].lifetime = array28[num42].lifetime * num;
				}
				this.EffectBallDownParticle[num39][col][row].SetParticles(this.particles, num3);
			}
			this.Particletimer[col][row] *= scale;
		}
		if (this.EffectBallBigYolkGameObject[col][row] != null)
		{
			for (int num43 = 0; num43 < this.EffectBallBigYolkParticle.Length; num43++)
			{
				float num2 = this.EffectBallBigYolkParticle[num43][col][row].startSize;
				num = this.EffectBallBigYolkParticle[num43][col][row].startLifetime;
				this.EffectBallBigYolkParticle[num43][col][row].startSize = this.BallBigYolkstartSize[num43] * scale;
				this.EffectBallBigYolkParticle[num43][col][row].startLifetime = this.BallBigYolklifetime[num43] * scale;
				num2 = this.EffectBallBigYolkParticle[num43][col][row].startSize / num2;
				num = this.EffectBallBigYolkParticle[num43][col][row].startLifetime / num;
				int num3 = this.EffectBallBigYolkParticle[num43][col][row].GetParticles(this.particles);
				for (int num44 = 0; num44 < num3; num44++)
				{
					ParticleSystem.Particle[] array29 = this.particles;
					int num45 = num44;
					array29[num45].size = array29[num45].size * num2;
					ParticleSystem.Particle[] array30 = this.particles;
					int num46 = num44;
					array30[num46].lifetime = array30[num46].lifetime * num;
				}
				this.EffectBallBigYolkParticle[num43][col][row].SetParticles(this.particles, num3);
			}
			this.Particletimer[col][row] *= scale;
		}
		if (this.EffectBallYolkGameObject[col][row] != null)
		{
			for (int num47 = 0; num47 < this.EffectBallYolkParticle.Length; num47++)
			{
				float num2 = this.EffectBallYolkParticle[num47][col][row].startSize;
				num = this.EffectBallYolkParticle[num47][col][row].startLifetime;
				this.EffectBallYolkParticle[num47][col][row].startSize = this.BallYolkstartSize[num47] * scale;
				this.EffectBallYolkParticle[num47][col][row].startLifetime = this.BallYolklifetime[num47] * scale;
				num2 = this.EffectBallYolkParticle[num47][col][row].startSize / num2;
				num = this.EffectBallYolkParticle[num47][col][row].startLifetime / num;
				int num3 = this.EffectBallYolkParticle[num47][col][row].GetParticles(this.particles);
				for (int num48 = 0; num48 < num3; num48++)
				{
					ParticleSystem.Particle[] array31 = this.particles;
					int num49 = num48;
					array31[num49].size = array31[num49].size * num2;
					ParticleSystem.Particle[] array32 = this.particles;
					int num50 = num48;
					array32[num50].lifetime = array32[num50].lifetime * num;
				}
				this.EffectBallYolkParticle[num47][col][row].SetParticles(this.particles, num3);
			}
			this.Particletimer[col][row] *= scale;
		}
		if (this.EffectBallNPCCityGameObject[col][row] != null)
		{
			for (int num51 = 0; num51 < this.EffectBallNPCCityParticle.Length; num51++)
			{
				float num2 = this.EffectBallNPCCityParticle[num51][col][row].startSize;
				num = this.EffectBallNPCCityParticle[num51][col][row].startLifetime;
				this.EffectBallNPCCityParticle[num51][col][row].startSize = this.BallNPCCitystartSize[num51] * scale;
				this.EffectBallNPCCityParticle[num51][col][row].startLifetime = this.BallNPCCitylifetime[num51] * scale;
				num2 = this.EffectBallNPCCityParticle[num51][col][row].startSize / num2;
				num = this.EffectBallNPCCityParticle[num51][col][row].startLifetime / num;
				int num3 = this.EffectBallNPCCityParticle[num51][col][row].GetParticles(this.particles);
				for (int num52 = 0; num52 < num3; num52++)
				{
					ParticleSystem.Particle[] array33 = this.particles;
					int num53 = num52;
					array33[num53].size = array33[num53].size * num2;
					ParticleSystem.Particle[] array34 = this.particles;
					int num54 = num52;
					array34[num54].lifetime = array34[num54].lifetime * num;
				}
				this.EffectBallNPCCityParticle[num51][col][row].SetParticles(this.particles, num3);
			}
			this.Particletimer[col][row] *= scale;
		}
		if (this.EffectBallOutGameObject[col][row] != null)
		{
			for (int num55 = 0; num55 < this.EffectBallOutParticle.Length; num55++)
			{
				float num2 = this.EffectBallOutParticle[num55][col][row].startSize;
				num = this.EffectBallOutParticle[num55][col][row].startLifetime;
				this.EffectBallOutParticle[num55][col][row].startSize = this.BallOutstartSize[num55] * scale;
				this.EffectBallOutParticle[num55][col][row].startLifetime = this.BallOutlifetime[num55] * scale;
				num2 = this.EffectBallOutParticle[num55][col][row].startSize / num2;
				num = this.EffectBallOutParticle[num55][col][row].startLifetime / num;
				int num3 = this.EffectBallOutParticle[num55][col][row].GetParticles(this.particles);
				for (int num56 = 0; num56 < num3; num56++)
				{
					ParticleSystem.Particle[] array35 = this.particles;
					int num57 = num56;
					array35[num57].size = array35[num57].size * num2;
					ParticleSystem.Particle[] array36 = this.particles;
					int num58 = num56;
					array36[num58].lifetime = array36[num58].lifetime * num;
				}
				this.EffectBallOutParticle[num55][col][row].SetParticles(this.particles, num3);
			}
			this.Particletimer[col][row] *= scale;
		}
		if (this.EffectBallKickGameObject[col][row] != null)
		{
			for (int num59 = 0; num59 < this.EffectBallKickParticle.Length; num59++)
			{
				float num2 = this.EffectBallKickParticle[num59][col][row].startSize;
				num = this.EffectBallKickParticle[num59][col][row].startLifetime;
				this.EffectBallKickParticle[num59][col][row].startSize = this.BallKickstartSize[num59] * scale;
				this.EffectBallKickParticle[num59][col][row].startLifetime = this.BallKicklifetime[num59] * scale;
				num2 = this.EffectBallKickParticle[num59][col][row].startSize / num2;
				num = this.EffectBallKickParticle[num59][col][row].startLifetime / num;
				int num3 = this.EffectBallKickParticle[num59][col][row].GetParticles(this.particles);
				for (int num60 = 0; num60 < num3; num60++)
				{
					ParticleSystem.Particle[] array37 = this.particles;
					int num61 = num60;
					array37[num61].size = array37[num61].size * num2;
					ParticleSystem.Particle[] array38 = this.particles;
					int num62 = num60;
					array38[num62].lifetime = array38[num62].lifetime * num;
				}
				this.EffectBallKickParticle[num59][col][row].SetParticles(this.particles, num3);
			}
			this.Particletimer[col][row] *= scale;
		}
		if (row == this.Yolkrow && col == this.Yolkcol)
		{
			if (this.EffectYolkWinGameObject.activeSelf)
			{
				float num2 = this.EffectYolkWinParticle.startSize;
				num = this.EffectYolkWinParticle.startLifetime;
				this.EffectYolkWinParticle.startSize = this.YolkWinstartSize * scale;
				this.EffectYolkWinParticle.startLifetime = this.YolkWinlifetime * scale;
				num2 = this.EffectYolkWinParticle.startSize / num2;
				num = this.EffectYolkWinParticle.startLifetime / num;
				int num3 = this.EffectYolkWinParticle.GetParticles(this.particles);
				for (int num63 = 0; num63 < num3; num63++)
				{
					ParticleSystem.Particle[] array39 = this.particles;
					int num64 = num63;
					array39[num64].size = array39[num64].size * num2;
					ParticleSystem.Particle[] array40 = this.particles;
					int num65 = num63;
					array40[num65].lifetime = array40[num65].lifetime * num;
				}
				this.EffectYolkWinParticle.SetParticles(this.particles, num3);
				num2 = this.EffectYolkWinParticle_one.startSize;
				num = this.EffectYolkWinParticle_one.startLifetime;
				this.EffectYolkWinParticle_one.startSize = this.YolkWinstartSize_one * scale;
				this.EffectYolkWinParticle_one.startLifetime = this.YolkWinlifetime_one * scale;
				num2 = this.EffectYolkWinParticle_one.startSize / num2;
				num = this.EffectYolkWinParticle_one.startLifetime / num;
				num3 = this.EffectYolkWinParticle_one.GetParticles(this.particles);
				for (int num66 = 0; num66 < num3; num66++)
				{
					ParticleSystem.Particle[] array41 = this.particles;
					int num67 = num66;
					array41[num67].size = array41[num67].size * num2;
					ParticleSystem.Particle[] array42 = this.particles;
					int num68 = num66;
					array42[num68].lifetime = array42[num68].lifetime * num;
				}
				this.EffectYolkWinParticle_one.SetParticles(this.particles, num3);
				num2 = this.EffectYolkWinParticle_two.startSize;
				num = this.EffectYolkWinParticle_two.startLifetime;
				this.EffectYolkWinParticle_two.startSize = this.YolkWinstartSize_two * scale;
				this.EffectYolkWinParticle_two.startLifetime = this.YolkWinlifetime_two * scale;
				num2 = this.EffectYolkWinParticle_two.startSize / num2;
				num = this.EffectYolkWinParticle_two.startLifetime / num;
				num3 = this.EffectYolkWinParticle_two.GetParticles(this.particles);
				for (int num69 = 0; num69 < num3; num69++)
				{
					ParticleSystem.Particle[] array43 = this.particles;
					int num70 = num69;
					array43[num70].size = array43[num70].size * num2;
					ParticleSystem.Particle[] array44 = this.particles;
					int num71 = num69;
					array44[num71].lifetime = array44[num71].lifetime * num;
				}
				this.EffectYolkWinParticle_two.SetParticles(this.particles, num3);
				num2 = this.EffectYolkWinParticle_thr.startSize;
				num = this.EffectYolkWinParticle_thr.startLifetime;
				this.EffectYolkWinParticle_thr.startSize = this.YolkWinstartSize_thr * scale;
				this.EffectYolkWinParticle_thr.startLifetime = this.YolkWinlifetime_thr * scale;
				num2 = this.EffectYolkWinParticle_thr.startSize / num2;
				num = this.EffectYolkWinParticle_thr.startLifetime / num;
				num3 = this.EffectYolkWinParticle_thr.GetParticles(this.particles);
				for (int num72 = 0; num72 < num3; num72++)
				{
					ParticleSystem.Particle[] array45 = this.particles;
					int num73 = num72;
					array45[num73].size = array45[num73].size * num2;
					ParticleSystem.Particle[] array46 = this.particles;
					int num74 = num72;
					array46[num74].lifetime = array46[num74].lifetime * num;
				}
				this.EffectYolkWinParticle_thr.SetParticles(this.particles, num3);
				num2 = this.EffectYolkWinParticle_tho.startSize;
				num = this.EffectYolkWinParticle_tho.startLifetime;
				this.EffectYolkWinParticle_tho.startSize = this.YolkWinstartSize_tho * scale;
				this.EffectYolkWinParticle_tho.startLifetime = this.YolkWinlifetime_tho * scale;
				num2 = this.EffectYolkWinParticle_tho.startSize / num2;
				num = this.EffectYolkWinParticle_tho.startLifetime / num;
				num3 = this.EffectYolkWinParticle_tho.GetParticles(this.particles);
				for (int num75 = 0; num75 < num3; num75++)
				{
					ParticleSystem.Particle[] array47 = this.particles;
					int num76 = num75;
					array47[num76].size = array47[num76].size * num2;
					ParticleSystem.Particle[] array48 = this.particles;
					int num77 = num75;
					array48[num77].lifetime = array48[num77].lifetime * num;
				}
				this.EffectYolkWinParticle_tho.SetParticles(this.particles, num3);
			}
			if (this.EffectYolkLoseGameObject.activeSelf)
			{
				float num2 = this.EffectYolkLoseParticle.startSize;
				num = this.EffectYolkLoseParticle.startLifetime;
				this.EffectYolkLoseParticle.startSize = this.YolkLosestartSize * scale;
				this.EffectYolkLoseParticle.startLifetime = this.YolkLoselifetime * scale;
				num2 = this.EffectYolkLoseParticle.startSize / num2;
				num = this.EffectYolkLoseParticle.startLifetime / num;
				int num3 = this.EffectYolkLoseParticle.GetParticles(this.particles);
				for (int num78 = 0; num78 < num3; num78++)
				{
					ParticleSystem.Particle[] array49 = this.particles;
					int num79 = num78;
					array49[num79].size = array49[num79].size * num2;
					ParticleSystem.Particle[] array50 = this.particles;
					int num80 = num78;
					array50[num80].lifetime = array50[num80].lifetime * num;
				}
				this.EffectYolkLoseParticle.SetParticles(this.particles, num3);
				num2 = this.EffectYolkLoseParticle_one.startSize;
				num = this.EffectYolkLoseParticle_one.startLifetime;
				this.EffectYolkLoseParticle_one.startSize = this.YolkLosestartSize_one * scale;
				this.EffectYolkLoseParticle_one.startLifetime = this.YolkLoselifetime_one * scale;
				num2 = this.EffectYolkLoseParticle_one.startSize / num2;
				num = this.EffectYolkLoseParticle_one.startLifetime / num;
				num3 = this.EffectYolkLoseParticle_one.GetParticles(this.particles);
				for (int num81 = 0; num81 < num3; num81++)
				{
					ParticleSystem.Particle[] array51 = this.particles;
					int num82 = num81;
					array51[num82].size = array51[num82].size * num2;
					ParticleSystem.Particle[] array52 = this.particles;
					int num83 = num81;
					array52[num83].lifetime = array52[num83].lifetime * num;
				}
				this.EffectYolkLoseParticle_one.SetParticles(this.particles, num3);
			}
			if (this.EffectYolkShieldGameObject.activeSelf)
			{
				float num2 = this.EffectYolkShieldParticle.startSize;
				num = this.EffectYolkShieldParticle.startLifetime;
				this.EffectYolkShieldParticle.startSize = this.YolkShieldstartSize * scale;
				this.EffectYolkShieldParticle.startLifetime = this.YolkShieldlifetime * scale;
				num2 = this.EffectYolkShieldParticle.startSize / num2;
				num = this.EffectYolkShieldParticle.startLifetime / num;
				int num3 = this.EffectYolkShieldParticle.GetParticles(this.particles);
				for (int num84 = 0; num84 < num3; num84++)
				{
					ParticleSystem.Particle[] array53 = this.particles;
					int num85 = num84;
					array53[num85].size = array53[num85].size * num2;
					ParticleSystem.Particle[] array54 = this.particles;
					int num86 = num84;
					array54[num86].lifetime = array54[num86].lifetime * num;
				}
				this.EffectYolkShieldParticle.SetParticles(this.particles, num3);
				num2 = this.EffectYolkShieldParticle_one.startSize;
				num = this.EffectYolkShieldParticle_one.startLifetime;
				this.EffectYolkShieldParticle_one.startSize = this.YolkShieldstartSize_one * scale;
				this.EffectYolkShieldParticle_one.startLifetime = this.YolkShieldlifetime_one * scale;
				num2 = this.EffectYolkShieldParticle_one.startSize / num2;
				num = this.EffectYolkShieldParticle_one.startLifetime / num;
				num3 = this.EffectYolkShieldParticle_one.GetParticles(this.particles);
				for (int num87 = 0; num87 < num3; num87++)
				{
					ParticleSystem.Particle[] array55 = this.particles;
					int num88 = num87;
					array55[num88].size = array55[num88].size * num2;
					ParticleSystem.Particle[] array56 = this.particles;
					int num89 = num87;
					array56[num89].lifetime = array56[num89].lifetime * num;
				}
				this.EffectYolkShieldParticle_one.SetParticles(this.particles, num3);
				scale *= this.YolkShieldScale;
				num2 = this.EffectYolkShieldParticle_two.startSize;
				this.EffectYolkShieldParticle_two.startSize = this.YolkShieldstartSize_two * scale;
				num2 = this.EffectYolkShieldParticle_two.startSize / num2;
				num3 = this.EffectYolkShieldParticle_two.GetParticles(this.particles);
				for (int num90 = 0; num90 < num3; num90++)
				{
					ParticleSystem.Particle[] array57 = this.particles;
					int num91 = num90;
					array57[num91].size = array57[num91].size * num2;
				}
				this.EffectYolkShieldParticle_two.SetParticles(this.particles, num3);
				num2 = this.EffectYolkShieldParticle_thr.startSize;
				this.EffectYolkShieldParticle_thr.startSize = this.YolkShieldstartSize_thr * scale;
				num2 = this.EffectYolkShieldParticle_thr.startSize / num2;
				num3 = this.EffectYolkShieldParticle_thr.GetParticles(this.particles);
				for (int num92 = 0; num92 < num3; num92++)
				{
					ParticleSystem.Particle[] array58 = this.particles;
					int num93 = num92;
					array58[num93].size = array58[num93].size * num2;
				}
				this.EffectYolkShieldParticle_thr.SetParticles(this.particles, num3);
			}
			if (this.EffectBigYolkWinGameObject.activeSelf)
			{
				float num2 = this.EffectBigYolkWinParticle.startSize;
				num = this.EffectBigYolkWinParticle.startLifetime;
				this.EffectBigYolkWinParticle.startSize = this.BigYolkWinstartSize * scale;
				this.EffectBigYolkWinParticle.startLifetime = this.BigYolkWinlifetime * scale;
				num2 = this.EffectBigYolkWinParticle.startSize / num2;
				num = this.EffectBigYolkWinParticle.startLifetime / num;
				int num3 = this.EffectBigYolkWinParticle.GetParticles(this.particles);
				for (int num94 = 0; num94 < num3; num94++)
				{
					ParticleSystem.Particle[] array59 = this.particles;
					int num95 = num94;
					array59[num95].size = array59[num95].size * num2;
					ParticleSystem.Particle[] array60 = this.particles;
					int num96 = num94;
					array60[num96].lifetime = array60[num96].lifetime * num;
				}
				this.EffectBigYolkWinParticle.SetParticles(this.particles, num3);
				num2 = this.EffectBigYolkWinParticle_one.startSize;
				num = this.EffectBigYolkWinParticle_one.startLifetime;
				this.EffectBigYolkWinParticle_one.startSize = this.BigYolkWinstartSize_one * scale;
				this.EffectBigYolkWinParticle_one.startLifetime = this.BigYolkWinlifetime_one * scale;
				num2 = this.EffectBigYolkWinParticle_one.startSize / num2;
				num = this.EffectBigYolkWinParticle_one.startLifetime / num;
				num3 = this.EffectBigYolkWinParticle_one.GetParticles(this.particles);
				for (int num97 = 0; num97 < num3; num97++)
				{
					ParticleSystem.Particle[] array61 = this.particles;
					int num98 = num97;
					array61[num98].size = array61[num98].size * num2;
					ParticleSystem.Particle[] array62 = this.particles;
					int num99 = num97;
					array62[num99].lifetime = array62[num99].lifetime * num;
				}
				this.EffectBigYolkWinParticle_one.SetParticles(this.particles, num3);
				num2 = this.EffectBigYolkWinParticle_two.startSize;
				num = this.EffectBigYolkWinParticle_two.startLifetime;
				this.EffectBigYolkWinParticle_two.startSize = this.BigYolkWinstartSize_two * scale;
				this.EffectBigYolkWinParticle_two.startLifetime = this.BigYolkWinlifetime_two * scale;
				num2 = this.EffectBigYolkWinParticle_two.startSize / num2;
				num = this.EffectBigYolkWinParticle_two.startLifetime / num;
				num3 = this.EffectBigYolkWinParticle_two.GetParticles(this.particles);
				for (int num100 = 0; num100 < num3; num100++)
				{
					ParticleSystem.Particle[] array63 = this.particles;
					int num101 = num100;
					array63[num101].size = array63[num101].size * num2;
					ParticleSystem.Particle[] array64 = this.particles;
					int num102 = num100;
					array64[num102].lifetime = array64[num102].lifetime * num;
				}
				this.EffectBigYolkWinParticle_two.SetParticles(this.particles, num3);
				num2 = this.EffectBigYolkWinParticle_thr.startSize;
				num = this.EffectBigYolkWinParticle_thr.startLifetime;
				this.EffectBigYolkWinParticle_thr.startSize = this.BigYolkWinstartSize_thr * scale;
				this.EffectBigYolkWinParticle_thr.startLifetime = this.BigYolkWinlifetime_thr * scale;
				num2 = this.EffectBigYolkWinParticle_thr.startSize / num2;
				num = this.EffectBigYolkWinParticle_thr.startLifetime / num;
				num3 = this.EffectBigYolkWinParticle_thr.GetParticles(this.particles);
				for (int num103 = 0; num103 < num3; num103++)
				{
					ParticleSystem.Particle[] array65 = this.particles;
					int num104 = num103;
					array65[num104].size = array65[num104].size * num2;
					ParticleSystem.Particle[] array66 = this.particles;
					int num105 = num103;
					array66[num105].lifetime = array66[num105].lifetime * num;
				}
				this.EffectBigYolkWinParticle_thr.SetParticles(this.particles, num3);
				num2 = this.EffectBigYolkWinParticle_for.startSize;
				num = this.EffectBigYolkWinParticle_for.startLifetime;
				this.EffectBigYolkWinParticle_for.startSize = this.BigYolkWinstartSize_for * scale;
				this.EffectBigYolkWinParticle_for.startLifetime = this.BigYolkWinlifetime_for * scale;
				num2 = this.EffectBigYolkWinParticle_for.startSize / num2;
				num = this.EffectBigYolkWinParticle_for.startLifetime / num;
				num3 = this.EffectBigYolkWinParticle_for.GetParticles(this.particles);
				for (int num106 = 0; num106 < num3; num106++)
				{
					ParticleSystem.Particle[] array67 = this.particles;
					int num107 = num106;
					array67[num107].size = array67[num107].size * num2;
					ParticleSystem.Particle[] array68 = this.particles;
					int num108 = num106;
					array68[num108].lifetime = array68[num108].lifetime * num;
				}
				this.EffectBigYolkWinParticle_for.SetParticles(this.particles, num3);
			}
			if (this.EffectBigYolkLoseGameObject.activeSelf)
			{
				float num2 = this.EffectBigYolkLoseParticle.startSize;
				num = this.EffectBigYolkLoseParticle.startLifetime;
				this.EffectBigYolkLoseParticle.startSize = this.BigYolkLosestartSize * scale;
				this.EffectBigYolkLoseParticle.startLifetime = this.BigYolkLoselifetime * scale;
				num2 = this.EffectBigYolkLoseParticle.startSize / num2;
				num = this.EffectBigYolkLoseParticle.startLifetime / num;
				int num3 = this.EffectBigYolkLoseParticle.GetParticles(this.particles);
				for (int num109 = 0; num109 < num3; num109++)
				{
					ParticleSystem.Particle[] array69 = this.particles;
					int num110 = num109;
					array69[num110].size = array69[num110].size * num2;
					ParticleSystem.Particle[] array70 = this.particles;
					int num111 = num109;
					array70[num111].lifetime = array70[num111].lifetime * num;
				}
				this.EffectBigYolkLoseParticle.SetParticles(this.particles, num3);
				num2 = this.EffectBigYolkLoseParticle_one.startSize;
				num = this.EffectBigYolkLoseParticle_one.startLifetime;
				this.EffectBigYolkLoseParticle_one.startSize = this.BigYolkLosestartSize_one * scale;
				this.EffectBigYolkLoseParticle_one.startLifetime = this.BigYolkLoselifetime_one * scale;
				num2 = this.EffectBigYolkLoseParticle_one.startSize / num2;
				num = this.EffectBigYolkLoseParticle_one.startLifetime / num;
				num3 = this.EffectBigYolkLoseParticle_one.GetParticles(this.particles);
				for (int num112 = 0; num112 < num3; num112++)
				{
					ParticleSystem.Particle[] array71 = this.particles;
					int num113 = num112;
					array71[num113].size = array71[num113].size * num2;
					ParticleSystem.Particle[] array72 = this.particles;
					int num114 = num112;
					array72[num114].lifetime = array72[num114].lifetime * num;
				}
				this.EffectBigYolkLoseParticle_one.SetParticles(this.particles, num3);
				num2 = this.EffectBigYolkLoseParticle_one.startSize;
				num = this.EffectBigYolkLoseParticle_one.startLifetime;
				this.EffectBigYolkLoseParticle_one.startSize = this.BigYolkLosestartSize_one * scale;
				this.EffectBigYolkLoseParticle_one.startLifetime = this.BigYolkLoselifetime_one * scale;
				num2 = this.EffectBigYolkLoseParticle_one.startSize / num2;
				num = this.EffectBigYolkLoseParticle_one.startLifetime / num;
				num3 = this.EffectBigYolkLoseParticle_one.GetParticles(this.particles);
				for (int num115 = 0; num115 < num3; num115++)
				{
					ParticleSystem.Particle[] array73 = this.particles;
					int num116 = num115;
					array73[num116].size = array73[num116].size * num2;
					ParticleSystem.Particle[] array74 = this.particles;
					int num117 = num115;
					array74[num117].lifetime = array74[num117].lifetime * num;
				}
				this.EffectBigYolkLoseParticle_one.SetParticles(this.particles, num3);
				num2 = this.EffectBigYolkLoseParticle_two.startSize;
				num = this.EffectBigYolkLoseParticle_two.startLifetime;
				this.EffectBigYolkLoseParticle_two.startSize = this.BigYolkLosestartSize_two * scale;
				this.EffectBigYolkLoseParticle_two.startLifetime = this.BigYolkLoselifetime_two * scale;
				num2 = this.EffectBigYolkLoseParticle_two.startSize / num2;
				num = this.EffectBigYolkLoseParticle_two.startLifetime / num;
				num3 = this.EffectBigYolkLoseParticle_two.GetParticles(this.particles);
				for (int num118 = 0; num118 < num3; num118++)
				{
					ParticleSystem.Particle[] array75 = this.particles;
					int num119 = num118;
					array75[num119].size = array75[num119].size * num2;
					ParticleSystem.Particle[] array76 = this.particles;
					int num120 = num118;
					array76[num120].lifetime = array76[num120].lifetime * num;
				}
				this.EffectBigYolkLoseParticle_two.SetParticles(this.particles, num3);
			}
			if (this.EffectBigYolkShieldGameObject.activeSelf)
			{
				float num2 = this.EffectBigYolkShieldParticle.startSize;
				num = this.EffectBigYolkShieldParticle.startLifetime;
				this.EffectBigYolkShieldParticle.startSize = this.BigYolkShieldstartSize * scale;
				this.EffectBigYolkShieldParticle.startLifetime = this.BigYolkShieldlifetime * scale;
				num2 = this.EffectBigYolkShieldParticle.startSize / num2;
				num = this.EffectBigYolkShieldParticle.startLifetime / num;
				int num3 = this.EffectBigYolkShieldParticle.GetParticles(this.particles);
				for (int num121 = 0; num121 < num3; num121++)
				{
					ParticleSystem.Particle[] array77 = this.particles;
					int num122 = num121;
					array77[num122].size = array77[num122].size * num2;
					ParticleSystem.Particle[] array78 = this.particles;
					int num123 = num121;
					array78[num123].lifetime = array78[num123].lifetime * num;
				}
				this.EffectBigYolkShieldParticle.SetParticles(this.particles, num3);
				num2 = this.EffectBigYolkShieldParticle_one.startSize;
				num = this.EffectBigYolkShieldParticle_one.startLifetime;
				this.EffectBigYolkShieldParticle_one.startSize = this.BigYolkShieldstartSize_one * scale;
				this.EffectBigYolkShieldParticle_one.startLifetime = this.BigYolkShieldlifetime_one * scale;
				num2 = this.EffectBigYolkShieldParticle_one.startSize / num2;
				num = this.EffectBigYolkShieldParticle_one.startLifetime / num;
				num3 = this.EffectBigYolkShieldParticle_one.GetParticles(this.particles);
				for (int num124 = 0; num124 < num3; num124++)
				{
					ParticleSystem.Particle[] array79 = this.particles;
					int num125 = num124;
					array79[num125].size = array79[num125].size * num2;
					ParticleSystem.Particle[] array80 = this.particles;
					int num126 = num124;
					array80[num126].lifetime = array80[num126].lifetime * num;
				}
				this.EffectBigYolkShieldParticle_one.SetParticles(this.particles, num3);
				scale *= this.YolkShieldScale;
				num2 = this.EffectBigYolkShieldParticle_two.startSize;
				this.EffectBigYolkShieldParticle_two.startSize = this.BigYolkShieldstartSize_two * scale;
				num2 = this.EffectBigYolkShieldParticle_two.startSize / num2;
				num3 = this.EffectBigYolkShieldParticle_two.GetParticles(this.particles);
				for (int num127 = 0; num127 < num3; num127++)
				{
					ParticleSystem.Particle[] array81 = this.particles;
					int num128 = num127;
					array81[num128].size = array81[num128].size * num2;
				}
				this.EffectBigYolkShieldParticle_two.SetParticles(this.particles, num3);
				num2 = this.EffectBigYolkShieldParticle_thr.startSize;
				this.EffectBigYolkShieldParticle_thr.startSize = this.BigYolkShieldstartSize_thr * scale;
				num2 = this.EffectBigYolkShieldParticle_thr.startSize / num2;
				num3 = this.EffectBigYolkShieldParticle_thr.GetParticles(this.particles);
				for (int num129 = 0; num129 < num3; num129++)
				{
					ParticleSystem.Particle[] array82 = this.particles;
					int num130 = num129;
					array82[num130].size = array82[num130].size * num2;
				}
				this.EffectBigYolkShieldParticle_thr.SetParticles(this.particles, num3);
			}
		}
	}

	// Token: 0x06000B40 RID: 2880 RVA: 0x00101584 File Offset: 0x000FF784
	public void setActive(byte effectflag)
	{
		bool flag = (effectflag & 1) != 0;
		this.WinLayoutTransform.gameObject.SetActive(flag);
		bool flag2 = (effectflag & 2) != 0;
		this.LoseLayoutTransform.gameObject.SetActive(flag2);
		this.EnemyLoseLayoutTransform.gameObject.SetActive(flag2);
		bool flag3 = (effectflag & 4) != 0;
		this.ShieldLayoutTransform.gameObject.SetActive(flag3);
		bool flag4 = (effectflag & 16) != 0;
		this.ConveyLayoutTransform.gameObject.SetActive(flag4);
		this.NPCCityConveyLayoutTransform.gameObject.SetActive(flag4);
		bool flag5 = (effectflag & 128) != 0;
		this.MapWeaponHurtLayoutTransform.gameObject.SetActive(flag5);
		this.YolkLayoutTransform.gameObject.SetActive(effectflag != 0);
	}

	// Token: 0x06000B41 RID: 2881 RVA: 0x00101658 File Offset: 0x000FF858
	public void EffectGone(int row, int col)
	{
		switch (this.Particlekind[col][row])
		{
		case 1:
			if (this.EffectBallDownGameObject[col][row] != null)
			{
				this.EffectBallDownGameObject[col][row].SetActive(false);
				for (int i = 0; i < this.BallDownpoolsCounter; i++)
				{
					if (this.BallDownpoolCounter[i] < this.EffectBallDownGameObjectPools[i].Length)
					{
						this.EffectBallDownGameObjectPools[i][this.BallDownpoolCounter[i]] = this.EffectBallDownGameObject[col][row];
						this.EffectBallDownTransformPools[i][this.BallDownpoolCounter[i]] = this.EffectBallDownTransform[col][row];
						for (int j = 0; j < this.EffectBallDownParticlePools.Length; j++)
						{
							this.EffectBallDownParticlePools[j][i][this.BallDownpoolCounter[i]] = this.EffectBallDownParticle[j][col][row];
						}
						this.EffectBallDownGameObject[col][row] = null;
						this.EffectBallDownTransform[col][row] = null;
						for (int k = 0; k < this.EffectBallDownParticlePools.Length; k++)
						{
							this.EffectBallDownParticle[k][col][row] = null;
						}
						this.BallDownpoolCounter[i]++;
						break;
					}
				}
			}
			break;
		case 2:
			if (this.EffectBallBigYolkGameObject[col][row] != null)
			{
				this.EffectBallBigYolkGameObject[col][row].SetActive(false);
				for (int l = 0; l < this.BallBigYolkpoolsCounter; l++)
				{
					if (this.BallBigYolkpoolCounter[l] < this.EffectBallBigYolkGameObjectPools[l].Length)
					{
						this.EffectBallBigYolkGameObjectPools[l][this.BallBigYolkpoolCounter[l]] = this.EffectBallBigYolkGameObject[col][row];
						this.EffectBallBigYolkTransformPools[l][this.BallBigYolkpoolCounter[l]] = this.EffectBallBigYolkTransform[col][row];
						for (int m = 0; m < this.EffectBallBigYolkParticlePools.Length; m++)
						{
							this.EffectBallBigYolkParticlePools[m][l][this.BallBigYolkpoolCounter[l]] = this.EffectBallBigYolkParticle[m][col][row];
						}
						this.EffectBallBigYolkGameObject[col][row] = null;
						this.EffectBallBigYolkTransform[col][row] = null;
						for (int n = 0; n < this.EffectBallBigYolkParticlePools.Length; n++)
						{
							this.EffectBallBigYolkParticle[n][col][row] = null;
						}
						this.BallBigYolkpoolCounter[l]++;
						break;
					}
				}
			}
			break;
		case 3:
			if (this.EffectBallYolkGameObject[col][row] != null)
			{
				this.EffectBallYolkGameObject[col][row].SetActive(false);
				for (int num = 0; num < this.BallYolkpoolsCounter; num++)
				{
					if (this.BallYolkpoolCounter[num] < this.EffectBallYolkGameObjectPools[num].Length)
					{
						this.EffectBallYolkGameObjectPools[num][this.BallYolkpoolCounter[num]] = this.EffectBallYolkGameObject[col][row];
						this.EffectBallYolkTransformPools[num][this.BallYolkpoolCounter[num]] = this.EffectBallYolkTransform[col][row];
						for (int num2 = 0; num2 < this.EffectBallYolkParticlePools.Length; num2++)
						{
							this.EffectBallYolkParticlePools[num2][num][this.BallYolkpoolCounter[num]] = this.EffectBallYolkParticle[num2][col][row];
						}
						this.EffectBallYolkGameObject[col][row] = null;
						this.EffectBallYolkTransform[col][row] = null;
						for (int num3 = 0; num3 < this.EffectBallYolkParticlePools.Length; num3++)
						{
							this.EffectBallYolkParticle[num3][col][row] = null;
						}
						this.BallYolkpoolCounter[num]++;
						break;
					}
				}
			}
			break;
		case 4:
			if (this.EffectBallNPCCityGameObject[col][row] != null)
			{
				this.EffectBallNPCCityGameObject[col][row].SetActive(false);
				for (int num4 = 0; num4 < this.BallNPCCitypoolsCounter; num4++)
				{
					if (this.BallNPCCitypoolCounter[num4] < this.EffectBallNPCCityGameObjectPools[num4].Length)
					{
						this.EffectBallNPCCityGameObjectPools[num4][this.BallNPCCitypoolCounter[num4]] = this.EffectBallNPCCityGameObject[col][row];
						this.EffectBallNPCCityTransformPools[num4][this.BallNPCCitypoolCounter[num4]] = this.EffectBallNPCCityTransform[col][row];
						for (int num5 = 0; num5 < this.EffectBallNPCCityParticlePools.Length; num5++)
						{
							this.EffectBallNPCCityParticlePools[num5][num4][this.BallNPCCitypoolCounter[num4]] = this.EffectBallNPCCityParticle[num5][col][row];
						}
						this.EffectBallNPCCityGameObject[col][row] = null;
						this.EffectBallNPCCityTransform[col][row] = null;
						for (int num6 = 0; num6 < this.EffectBallNPCCityParticlePools.Length; num6++)
						{
							this.EffectBallNPCCityParticle[num6][col][row] = null;
						}
						this.BallNPCCitypoolCounter[num4]++;
						break;
					}
				}
			}
			break;
		case 5:
			if (this.EffectBallOutGameObject[col][row] != null)
			{
				this.EffectBallOutGameObject[col][row].SetActive(false);
				for (int num7 = 0; num7 < this.BallOutpoolsCounter; num7++)
				{
					if (this.BallOutpoolCounter[num7] < this.EffectBallOutGameObjectPools[num7].Length)
					{
						this.EffectBallOutGameObjectPools[num7][this.BallOutpoolCounter[num7]] = this.EffectBallOutGameObject[col][row];
						this.EffectBallOutTransformPools[num7][this.BallOutpoolCounter[num7]] = this.EffectBallOutTransform[col][row];
						for (int num8 = 0; num8 < this.EffectBallOutParticlePools.Length; num8++)
						{
							this.EffectBallOutParticlePools[num8][num7][this.BallOutpoolCounter[num7]] = this.EffectBallOutParticle[num8][col][row];
						}
						this.EffectBallOutGameObject[col][row] = null;
						this.EffectBallOutTransform[col][row] = null;
						for (int num9 = 0; num9 < this.EffectBallOutParticlePools.Length; num9++)
						{
							this.EffectBallOutParticle[num9][col][row] = null;
						}
						this.BallOutpoolCounter[num7]++;
						break;
					}
				}
			}
			break;
		case 6:
			if (this.EffectBallKickGameObject[col][row] != null)
			{
				this.EffectBallKickGameObject[col][row].SetActive(false);
				for (int num10 = 0; num10 < this.BallKickpoolsCounter; num10++)
				{
					if (this.BallKickpoolCounter[num10] < this.EffectBallKickGameObjectPools[num10].Length)
					{
						this.EffectBallKickGameObjectPools[num10][this.BallKickpoolCounter[num10]] = this.EffectBallKickGameObject[col][row];
						this.EffectBallKickTransformPools[num10][this.BallKickpoolCounter[num10]] = this.EffectBallKickTransform[col][row];
						for (int num11 = 0; num11 < this.EffectBallKickParticlePools.Length; num11++)
						{
							this.EffectBallKickParticlePools[num11][num10][this.BallKickpoolCounter[num10]] = this.EffectBallKickParticle[num11][col][row];
						}
						this.EffectBallKickGameObject[col][row] = null;
						this.EffectBallKickTransform[col][row] = null;
						for (int num12 = 0; num12 < this.EffectBallKickParticlePools.Length; num12++)
						{
							this.EffectBallKickParticle[num12][col][row] = null;
						}
						this.BallKickpoolCounter[num10]++;
						break;
					}
				}
			}
			break;
		}
	}

	// Token: 0x06000B42 RID: 2882 RVA: 0x00101D94 File Offset: 0x000FFF94
	public void EffectCheck()
	{
		if (this.EffectConveyParticle == null)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		for (int i = 0; i < this.EffectConveyParticle.Length; i++)
		{
			for (int j = 0; j < this.EffectConveyParticle[i].Length; j++)
			{
				if (this.Particletimer[i][j] != 0f)
				{
					this.Particletimer[i][j] -= deltaTime;
					if (this.Particletimer[i][j] <= 0f)
					{
						this.EffectGone(j, i);
						this.Particletimer[i][j] = 0f;
						this.Particlekind[i][j] = 0;
					}
				}
				if (this.EffectConveyParticle_two[i][j] != null && !this.EffectConveyParticle_two[i][j].IsAlive())
				{
					this.EffectConveyGameObject[i][j].SetActive(false);
					for (int k = 0; k < this.ConveypoolsCounter; k++)
					{
						if (this.ConveypoolCounter[k] < this.EffectConveyGameObjectPools[k].Length)
						{
							this.EffectConveyGameObjectPools[k][this.ConveypoolCounter[k]] = this.EffectConveyGameObject[i][j];
							this.EffectConveyTransformPools[k][this.ConveypoolCounter[k]] = this.EffectConveyTransform[i][j];
							this.EffectConveyParticlePools[k][this.ConveypoolCounter[k]] = this.EffectConveyParticle[i][j];
							this.EffectConveyParticlePools_one[k][this.ConveypoolCounter[k]] = this.EffectConveyParticle_one[i][j];
							this.EffectConveyParticlePools_two[k][this.ConveypoolCounter[k]] = this.EffectConveyParticle_two[i][j];
							this.EffectConveyParticlePools_thr[k][this.ConveypoolCounter[k]] = this.EffectConveyParticle_thr[i][j];
							this.EffectConveyGameObject[i][j] = null;
							this.EffectConveyTransform[i][j] = null;
							this.EffectConveyParticle[i][j] = null;
							this.EffectConveyParticle_one[i][j] = null;
							this.EffectConveyParticle_two[i][j] = null;
							this.EffectConveyParticle_thr[i][j] = null;
							this.ConveypoolCounter[k]++;
							break;
						}
					}
				}
				if (this.EffectNPCCityConveyParticle_two[i][j] != null && !this.EffectNPCCityConveyParticle_two[i][j].IsAlive())
				{
					this.EffectNPCCityConveyGameObject[i][j].SetActive(false);
					for (int l = 0; l < this.NPCCityConveypoolsCounter; l++)
					{
						if (this.NPCCityConveypoolCounter[l] < this.EffectNPCCityConveyGameObjectPools[l].Length)
						{
							this.EffectNPCCityConveyGameObjectPools[l][this.NPCCityConveypoolCounter[l]] = this.EffectNPCCityConveyGameObject[i][j];
							this.EffectNPCCityConveyTransformPools[l][this.NPCCityConveypoolCounter[l]] = this.EffectNPCCityConveyTransform[i][j];
							this.EffectNPCCityConveyParticlePools[l][this.NPCCityConveypoolCounter[l]] = this.EffectNPCCityConveyParticle[i][j];
							this.EffectNPCCityConveyParticlePools_one[l][this.NPCCityConveypoolCounter[l]] = this.EffectNPCCityConveyParticle_one[i][j];
							this.EffectNPCCityConveyParticlePools_two[l][this.NPCCityConveypoolCounter[l]] = this.EffectNPCCityConveyParticle_two[i][j];
							this.EffectNPCCityConveyParticlePools_thr[l][this.NPCCityConveypoolCounter[l]] = this.EffectNPCCityConveyParticle_thr[i][j];
							this.EffectNPCCityConveyGameObject[i][j] = null;
							this.EffectNPCCityConveyTransform[i][j] = null;
							this.EffectNPCCityConveyParticle[i][j] = null;
							this.EffectNPCCityConveyParticle_one[i][j] = null;
							this.EffectNPCCityConveyParticle_two[i][j] = null;
							this.EffectNPCCityConveyParticle_thr[i][j] = null;
							this.NPCCityConveypoolCounter[l]++;
							break;
						}
					}
				}
			}
		}
	}

	// Token: 0x06000B43 RID: 2883 RVA: 0x0010211C File Offset: 0x0010031C
	public void ReflashEffect()
	{
		byte b = this.bBack;
		this.bBack = ((!this.bFront) ? (((ActivityManager.Instance.bSpecialMonsterTreasureEvent & 2UL) <= 0UL) ? 1 : 0) : 1);
		if (b == this.bBack)
		{
			return;
		}
		ushort effID = 60102;
		ushort effID2 = 60101;
		ushort effID3 = 60103;
		ushort effID4 = 60111;
		ushort effID5 = 60110;
		ushort effID6 = 60112;
		ushort effID7 = 60104;
		ushort effID8 = 60105;
		ushort effID9 = 60106;
		ushort effID10 = 60107;
		ushort effID11 = 60108;
		ushort effID12 = 60109;
		if (this.bBack == 1)
		{
			effID = 198;
			effID2 = 197;
			effID3 = 199;
			effID4 = 332;
			effID5 = 387;
			effID6 = 390;
			effID7 = 379;
			effID8 = 380;
			effID9 = 381;
			effID10 = 383;
			effID11 = 384;
			effID12 = 385;
		}
		for (int i = 0; i < this.WinpoolsCounter; i++)
		{
			int num = 0;
			while (num < this.WinpoolCounter[i] && num < this.EffectWinGameObjectPools[i].Length)
			{
				if (this.EffectWinGameObjectPools[i][num] != null)
				{
					UnityEngine.Object.DestroyObject(this.EffectWinGameObjectPools[i][num]);
					this.EffectWinGameObjectPools[i][num] = ParticleManager.Instance.Spawn(effID, null, Vector3.zero, 1f, false, false, true);
					this.EffectWinGameObjectPools[i][num].SetActive(false);
					this.EffectWinTransformPools[i][num] = this.EffectWinGameObjectPools[i][num].transform;
					this.EffectWinTransformPools[i][num].SetParent(this.WinLayoutTransform);
					this.EffectWinTransformPools[i][num].localPosition = this.inipos;
					this.EffectWinParticlePools[i][num] = this.EffectWinTransformPools[i][num].GetChild(0).GetComponent<ParticleSystem>();
				}
				num++;
			}
		}
		for (int j = 0; j < this.LosepoolsCounter; j++)
		{
			int num2 = 0;
			while (num2 < this.LosepoolCounter[j] && num2 < this.EffectLoseGameObjectPools[j].Length)
			{
				if (this.EffectLoseGameObjectPools[j][num2] != null)
				{
					UnityEngine.Object.DestroyObject(this.EffectLoseGameObjectPools[j][num2]);
					this.EffectLoseGameObjectPools[j][num2] = ParticleManager.Instance.Spawn(effID2, null, Vector3.zero, 1f, false, false, true);
					this.EffectLoseGameObjectPools[j][num2].SetActive(false);
					this.EffectLoseTransformPools[j][num2] = this.EffectLoseGameObjectPools[j][num2].transform;
					this.EffectLoseTransformPools[j][num2].SetParent(this.LoseLayoutTransform);
					this.EffectLoseTransformPools[j][num2].localPosition = this.inipos;
					this.EffectLoseParticlePools[j][num2] = this.EffectLoseTransformPools[j][num2].GetChild(0).GetComponent<ParticleSystem>();
				}
				num2++;
			}
		}
		for (int k = 0; k < this.ShieldpoolsCounter; k++)
		{
			int num3 = 0;
			while (num3 < this.ShieldpoolCounter[k] && num3 < this.EffectShieldGameObjectPools[k].Length)
			{
				if (this.EffectShieldGameObjectPools[k][num3] != null)
				{
					UnityEngine.Object.DestroyObject(this.EffectShieldGameObjectPools[k][num3]);
					this.EffectShieldGameObjectPools[k][num3] = ParticleManager.Instance.Spawn(effID3, null, Vector3.zero, 1f, false, false, true);
					this.EffectShieldGameObjectPools[k][num3].SetActive(false);
					this.EffectShieldTransformPools[k][num3] = this.EffectShieldGameObjectPools[k][num3].transform;
					this.EffectShieldTransformPools[k][num3].SetParent(this.ShieldLayoutTransform);
					this.EffectShieldTransformPools[k][num3].localPosition = this.inipos;
					this.EffectShieldParticlePools[k][num3] = this.EffectShieldTransformPools[k][num3].GetChild(0).GetComponent<ParticleSystem>();
					this.EffectShieldParticlePools_one[k][num3] = this.EffectShieldTransformPools[k][num3].GetChild(1).GetComponent<ParticleSystem>();
				}
				num3++;
			}
		}
		for (int l = 0; l < this.ConveypoolsCounter; l++)
		{
			int num4 = 0;
			while (num4 < this.ConveypoolCounter[l] && num4 < this.EffectConveyGameObjectPools[l].Length)
			{
				if (this.EffectConveyGameObjectPools[l][num4] != null)
				{
					UnityEngine.Object.DestroyObject(this.EffectConveyGameObjectPools[l][num4]);
					this.EffectConveyGameObjectPools[l][num4] = ParticleManager.Instance.Spawn(effID4, null, Vector3.zero, 1f, false, false, true);
					this.EffectConveyGameObjectPools[l][num4].SetActive(false);
					this.EffectConveyTransformPools[l][num4] = this.EffectConveyGameObjectPools[l][num4].transform;
					this.EffectConveyTransformPools[l][num4].SetParent(this.ConveyLayoutTransform);
					this.EffectConveyTransformPools[l][num4].localPosition = this.inipos;
					this.EffectConveyParticlePools[l][num4] = this.EffectConveyTransformPools[l][num4].GetChild(0).GetComponent<ParticleSystem>();
					this.EffectConveyParticlePools_one[l][num4] = this.EffectConveyTransformPools[l][num4].GetChild(1).GetComponent<ParticleSystem>();
					this.EffectConveyParticlePools_two[l][num4] = this.EffectConveyTransformPools[l][num4].GetChild(2).GetComponent<ParticleSystem>();
					this.EffectConveyParticlePools_thr[l][num4] = this.EffectConveyTransformPools[l][num4].GetChild(3).GetComponent<ParticleSystem>();
				}
				num4++;
			}
		}
		for (int m = 0; m < this.NPCCityConveypoolsCounter; m++)
		{
			int num5 = 0;
			while (num5 < this.NPCCityConveypoolCounter[m] && num5 < this.EffectNPCCityConveyGameObjectPools[m].Length)
			{
				if (this.EffectNPCCityConveyGameObjectPools[m][num5] != null)
				{
					UnityEngine.Object.DestroyObject(this.EffectNPCCityConveyGameObjectPools[m][num5]);
					this.EffectNPCCityConveyGameObjectPools[m][num5] = ParticleManager.Instance.Spawn(effID6, null, Vector3.zero, 1f, false, false, true);
					this.EffectNPCCityConveyGameObjectPools[m][num5].SetActive(false);
					this.EffectNPCCityConveyTransformPools[m][num5] = this.EffectNPCCityConveyGameObjectPools[m][num5].transform;
					this.EffectNPCCityConveyTransformPools[m][num5].SetParent(this.NPCCityConveyLayoutTransform);
					this.EffectNPCCityConveyTransformPools[m][num5].localPosition = this.inipos;
					this.EffectNPCCityConveyParticlePools[m][num5] = this.EffectNPCCityConveyTransformPools[m][num5].GetChild(0).GetComponent<ParticleSystem>();
					this.EffectNPCCityConveyParticlePools_one[m][num5] = this.EffectNPCCityConveyTransformPools[m][num5].GetChild(1).GetComponent<ParticleSystem>();
					this.EffectNPCCityConveyParticlePools_two[m][num5] = this.EffectNPCCityConveyTransformPools[m][num5].GetChild(2).GetComponent<ParticleSystem>();
					this.EffectNPCCityConveyParticlePools_thr[m][num5] = this.EffectNPCCityConveyTransformPools[m][num5].GetChild(3).GetComponent<ParticleSystem>();
				}
				num5++;
			}
		}
		for (int n = 0; n < this.EnemyLosepoolsCounter; n++)
		{
			int num6 = 0;
			while (num6 < this.EnemyLosepoolCounter[n] && num6 < this.EffectEnemyLoseGameObjectPools[n].Length)
			{
				if (this.EffectEnemyLoseGameObjectPools[n][num6] != null)
				{
					UnityEngine.Object.DestroyObject(this.EffectEnemyLoseGameObjectPools[n][num6]);
					this.EffectEnemyLoseGameObjectPools[n][num6] = ParticleManager.Instance.Spawn(effID5, null, Vector3.zero, 1f, false, false, true);
					this.EffectEnemyLoseGameObjectPools[n][num6].SetActive(false);
					this.EffectEnemyLoseTransformPools[n][num6] = this.EffectEnemyLoseGameObjectPools[n][num6].transform;
					this.EffectEnemyLoseTransformPools[n][num6].SetParent(this.EnemyLoseLayoutTransform);
					this.EffectEnemyLoseTransformPools[n][num6].localPosition = this.inipos;
					this.EffectEnemyLoseParticlePools[n][num6] = this.EffectEnemyLoseTransformPools[n][num6].GetChild(0).GetComponent<ParticleSystem>();
				}
				num6++;
			}
		}
		bool flag = true;
		if (this.EffectWinParticlePools[0][0] != null)
		{
			this.WinstartSize = this.EffectWinParticlePools[0][0].startSize;
			this.Winlifetime = this.EffectWinParticlePools[0][0].startLifetime;
		}
		else
		{
			flag = false;
		}
		bool flag2 = true;
		if (this.EffectLoseParticlePools[0][0] != null)
		{
			this.LosestartSize = this.EffectLoseParticlePools[0][0].startSize;
			this.Loselifetime = this.EffectLoseParticlePools[0][0].startLifetime;
		}
		else
		{
			flag2 = false;
		}
		bool flag3 = true;
		if (this.EffectEnemyLoseParticlePools[0][0] != null)
		{
			this.EnemyLosestartSize = this.EffectEnemyLoseParticlePools[0][0].startSize;
			this.EnemyLoselifetime = this.EffectEnemyLoseParticlePools[0][0].startLifetime;
		}
		else
		{
			flag3 = false;
		}
		bool flag4 = true;
		if (this.EffectShieldParticlePools[0][0] != null)
		{
			this.ShieldstartSize = this.EffectShieldParticlePools[0][0].startSize;
		}
		else
		{
			flag4 = false;
		}
		bool flag5 = true;
		if (this.EffectConveyParticlePools[0][0] != null)
		{
			this.ConveystartSize = this.EffectConveyParticlePools[0][0].startSize;
			this.Conveylifetime = this.EffectConveyParticlePools[0][0].startLifetime;
		}
		else
		{
			flag5 = false;
		}
		if (this.EffectConveyParticlePools_one[0][0] != null)
		{
			this.ConveystartSize_one = this.EffectConveyParticlePools_one[0][0].startSize;
			this.Conveylifetime_one = this.EffectConveyParticlePools_one[0][0].startLifetime;
		}
		if (this.EffectConveyParticlePools_two[0][0] != null)
		{
			this.ConveystartSize_two = this.EffectConveyParticlePools_two[0][0].startSize;
			this.Conveylifetime_two = this.EffectConveyParticlePools_two[0][0].startLifetime;
		}
		if (this.EffectConveyParticlePools_thr[0][0] != null)
		{
			this.ConveystartSize_thr = this.EffectConveyParticlePools_thr[0][0].startSize;
			this.Conveylifetime_thr = this.EffectConveyParticlePools_thr[0][0].startLifetime;
		}
		bool flag6 = true;
		if (this.EffectNPCCityConveyParticlePools[0][0] != null)
		{
			this.NPCCityConveystartSize = this.EffectNPCCityConveyParticlePools[0][0].startSize;
			this.NPCCityConveylifetime = this.EffectNPCCityConveyParticlePools[0][0].startLifetime;
		}
		else
		{
			flag6 = false;
		}
		if (this.EffectNPCCityConveyParticlePools_one[0][0] != null)
		{
			this.NPCCityConveystartSize_one = this.EffectNPCCityConveyParticlePools_one[0][0].startSize;
			this.NPCCityConveylifetime_one = this.EffectNPCCityConveyParticlePools_one[0][0].startLifetime;
		}
		if (this.EffectNPCCityConveyParticlePools_two[0][0] != null)
		{
			this.NPCCityConveystartSize_two = this.EffectNPCCityConveyParticlePools_two[0][0].startSize;
			this.NPCCityConveylifetime_two = this.EffectNPCCityConveyParticlePools_two[0][0].startLifetime;
		}
		if (this.EffectNPCCityConveyParticlePools_thr[0][0] != null)
		{
			this.NPCCityConveystartSize_thr = this.EffectNPCCityConveyParticlePools_thr[0][0].startSize;
			this.NPCCityConveylifetime_thr = this.EffectNPCCityConveyParticlePools_thr[0][0].startLifetime;
		}
		Vector3 localPosition = Vector3.zero;
		float x = this.RealmGroup.localScale.x;
		bool flag7 = false;
		if (this.EffectYolkWinGameObject != null)
		{
			bool activeSelf = this.EffectYolkWinGameObject.activeSelf;
			localPosition = this.EffectYolkWinTransform.localPosition;
			UnityEngine.Object.DestroyObject(this.EffectYolkWinGameObject);
			this.EffectYolkWinGameObject = ParticleManager.Instance.Spawn(effID7, null, Vector3.zero, 1f, false, false, true);
			this.EffectYolkWinTransform = this.EffectYolkWinGameObject.transform;
			this.EffectYolkWinTransform.SetParent(this.YolkLayoutTransform);
			this.EffectYolkWinTransform.localPosition = localPosition;
			this.EffectYolkWinParticle = this.EffectYolkWinTransform.GetChild(0).GetComponent<ParticleSystem>();
			this.EffectYolkWinParticle_one = this.EffectYolkWinTransform.GetChild(1).GetComponent<ParticleSystem>();
			this.EffectYolkWinParticle_two = this.EffectYolkWinTransform.GetChild(2).GetComponent<ParticleSystem>();
			this.EffectYolkWinParticle_thr = this.EffectYolkWinTransform.GetChild(3).GetComponent<ParticleSystem>();
			this.EffectYolkWinParticle_tho = this.EffectYolkWinTransform.GetChild(4).GetComponent<ParticleSystem>();
			this.YolkWinstartSize = this.EffectYolkWinParticle.startSize;
			this.YolkWinstartSize_one = this.EffectYolkWinParticle_one.startSize;
			this.YolkWinstartSize_two = this.EffectYolkWinParticle_two.startSize;
			this.YolkWinstartSize_thr = this.EffectYolkWinParticle_thr.startSize;
			this.YolkWinstartSize_tho = this.EffectYolkWinParticle_tho.startSize;
			this.YolkWinlifetime = this.EffectYolkWinParticle.startLifetime;
			this.YolkWinlifetime_one = this.EffectYolkWinParticle_one.startLifetime;
			this.YolkWinlifetime_two = this.EffectYolkWinParticle_two.startLifetime;
			this.YolkWinlifetime_thr = this.EffectYolkWinParticle_thr.startLifetime;
			this.YolkWinlifetime_tho = this.EffectYolkWinParticle_tho.startLifetime;
			if (activeSelf)
			{
				this.EffectYolkWinParticle.startSize = this.YolkWinstartSize * x;
				this.EffectYolkWinParticle_one.startSize = this.YolkWinstartSize_one * x;
				this.EffectYolkWinParticle_two.startSize = this.YolkWinstartSize_two * x;
				this.EffectYolkWinParticle_thr.startSize = this.YolkWinstartSize_thr * x;
				this.EffectYolkWinParticle_tho.startSize = this.YolkWinstartSize_tho * x;
				this.EffectYolkWinParticle.startLifetime = this.YolkWinlifetime * x;
				this.EffectYolkWinParticle_one.startLifetime = this.YolkWinlifetime_one * x;
				this.EffectYolkWinParticle_two.startLifetime = this.YolkWinlifetime_two * x;
				this.EffectYolkWinParticle_thr.startLifetime = this.YolkWinstartSize_thr * x;
				this.EffectYolkWinParticle_tho.startLifetime = this.YolkWinstartSize_tho * x;
				flag7 = activeSelf;
			}
			this.EffectYolkWinGameObject.SetActive(activeSelf);
		}
		if (this.EffectYolkLoseGameObject != null)
		{
			bool activeSelf = this.EffectYolkLoseGameObject.activeSelf;
			localPosition = this.EffectYolkLoseTransform.localPosition;
			UnityEngine.Object.DestroyObject(this.EffectYolkLoseGameObject);
			this.EffectYolkLoseGameObject = ParticleManager.Instance.Spawn(effID8, null, Vector3.zero, 1f, false, false, true);
			this.EffectYolkLoseTransform = this.EffectYolkLoseGameObject.transform;
			this.EffectYolkLoseTransform.SetParent(this.YolkLayoutTransform);
			this.EffectYolkLoseTransform.localPosition = localPosition;
			this.EffectYolkLoseParticle = this.EffectYolkLoseTransform.GetChild(0).GetComponent<ParticleSystem>();
			this.EffectYolkLoseParticle_one = this.EffectYolkLoseTransform.GetChild(1).GetComponent<ParticleSystem>();
			this.YolkLosestartSize = this.EffectYolkLoseParticle.startSize;
			this.YolkLosestartSize_one = this.EffectYolkLoseParticle_one.startSize;
			this.YolkLoselifetime = this.EffectYolkLoseParticle.startLifetime;
			this.YolkLoselifetime_one = this.EffectYolkLoseParticle_one.startLifetime;
			if (activeSelf)
			{
				this.EffectYolkLoseParticle.startSize = this.YolkLosestartSize * x;
				this.EffectYolkLoseParticle_one.startSize = this.YolkLosestartSize_one * x;
				this.EffectYolkLoseParticle.startLifetime = this.YolkLoselifetime * x;
				this.EffectYolkLoseParticle_one.startLifetime = this.YolkLoselifetime_one * x;
				flag7 = activeSelf;
			}
			this.EffectYolkLoseGameObject.SetActive(activeSelf);
		}
		if (this.EffectYolkShieldGameObject != null)
		{
			bool activeSelf = this.EffectYolkShieldGameObject.activeSelf;
			localPosition = this.EffectYolkShieldTransform.localPosition;
			UnityEngine.Object.DestroyObject(this.EffectYolkShieldGameObject);
			this.EffectYolkShieldGameObject = ParticleManager.Instance.Spawn(effID9, null, Vector3.zero, 1f, false, false, true);
			this.EffectYolkShieldTransform = this.EffectYolkShieldGameObject.transform;
			this.EffectYolkShieldTransform.SetParent(this.YolkLayoutTransform);
			this.EffectYolkShieldTransform.localPosition = localPosition;
			this.EffectYolkShieldParticle = this.EffectYolkShieldTransform.GetChild(0).GetComponent<ParticleSystem>();
			this.EffectYolkShieldParticle_one = this.EffectYolkShieldTransform.GetChild(1).GetComponent<ParticleSystem>();
			this.EffectYolkShieldParticle_two = this.EffectYolkShieldTransform.GetChild(2).GetComponent<ParticleSystem>();
			this.EffectYolkShieldParticle_thr = this.EffectYolkShieldTransform.GetChild(3).GetComponent<ParticleSystem>();
			this.YolkShieldstartSize = this.EffectYolkShieldParticle.startSize;
			this.YolkShieldstartSize_one = this.EffectYolkShieldParticle_one.startSize;
			this.YolkShieldstartSize_two = this.EffectYolkShieldParticle_two.startSize;
			this.YolkShieldstartSize_thr = this.EffectYolkShieldParticle_thr.startSize;
			this.YolkShieldlifetime = this.EffectYolkShieldParticle.startLifetime;
			this.YolkShieldlifetime_one = this.EffectYolkShieldParticle_one.startLifetime;
			this.YolkShieldlifetime_two = this.EffectYolkShieldParticle_two.startLifetime;
			this.YolkShieldlifetime_thr = this.EffectYolkShieldParticle_thr.startLifetime;
			if (activeSelf)
			{
				this.EffectYolkShieldParticle.startSize = this.YolkShieldstartSize * x;
				this.EffectYolkShieldParticle_one.startSize = this.YolkShieldstartSize_one * x;
				this.EffectYolkShieldParticle_two.startSize = this.YolkShieldstartSize_two * x * this.YolkShieldScale;
				this.EffectYolkShieldParticle_thr.startSize = this.YolkShieldstartSize_thr * x * this.YolkShieldScale;
				this.EffectYolkShieldParticle.startLifetime = this.YolkShieldlifetime * x;
				this.EffectYolkShieldParticle_one.startLifetime = this.YolkShieldlifetime_one * x;
				flag7 = activeSelf;
			}
			this.EffectYolkShieldGameObject.SetActive(activeSelf);
		}
		if (this.EffectBigYolkWinGameObject != null)
		{
			bool activeSelf = this.EffectBigYolkWinGameObject.activeSelf;
			localPosition = this.EffectBigYolkWinTransform.localPosition;
			UnityEngine.Object.DestroyObject(this.EffectBigYolkWinGameObject);
			this.EffectBigYolkWinGameObject = ParticleManager.Instance.Spawn(effID10, null, Vector3.zero, 1f, false, false, true);
			this.EffectBigYolkWinTransform = this.EffectBigYolkWinGameObject.transform;
			this.EffectBigYolkWinTransform.SetParent(this.YolkLayoutTransform);
			this.EffectBigYolkWinTransform.localPosition = localPosition;
			this.EffectBigYolkWinParticle = this.EffectBigYolkWinTransform.GetChild(0).GetComponent<ParticleSystem>();
			this.EffectBigYolkWinParticle_one = this.EffectBigYolkWinTransform.GetChild(1).GetComponent<ParticleSystem>();
			this.EffectBigYolkWinParticle_two = this.EffectBigYolkWinTransform.GetChild(2).GetComponent<ParticleSystem>();
			this.EffectBigYolkWinParticle_thr = this.EffectBigYolkWinTransform.GetChild(3).GetComponent<ParticleSystem>();
			this.EffectBigYolkWinParticle_for = this.EffectBigYolkWinTransform.GetChild(4).GetComponent<ParticleSystem>();
			this.BigYolkWinstartSize = this.EffectBigYolkWinParticle.startSize;
			this.BigYolkWinstartSize_one = this.EffectBigYolkWinParticle_one.startSize;
			this.BigYolkWinstartSize_two = this.EffectBigYolkWinParticle_two.startSize;
			this.BigYolkWinstartSize_thr = this.EffectBigYolkWinParticle_thr.startSize;
			this.BigYolkWinstartSize_for = this.EffectBigYolkWinParticle_for.startSize;
			this.BigYolkWinlifetime = this.EffectBigYolkWinParticle.startLifetime;
			this.BigYolkWinlifetime_one = this.EffectBigYolkWinParticle_one.startLifetime;
			this.BigYolkWinlifetime_two = this.EffectBigYolkWinParticle_two.startLifetime;
			this.BigYolkWinlifetime_thr = this.EffectBigYolkWinParticle_thr.startLifetime;
			this.BigYolkWinlifetime_for = this.EffectBigYolkWinParticle_for.startLifetime;
			if (activeSelf)
			{
				this.EffectBigYolkWinParticle.startSize = this.BigYolkWinstartSize * x;
				this.EffectBigYolkWinParticle_one.startSize = this.BigYolkWinstartSize_one * x;
				this.EffectBigYolkWinParticle_two.startSize = this.BigYolkWinstartSize_two * x;
				this.EffectBigYolkWinParticle_thr.startSize = this.BigYolkWinstartSize_thr * x;
				this.EffectBigYolkWinParticle_for.startSize = this.BigYolkWinstartSize_for * x;
				this.EffectBigYolkWinParticle.startLifetime = this.BigYolkWinlifetime * x;
				this.EffectBigYolkWinParticle_one.startLifetime = this.BigYolkWinlifetime_one * x;
				this.EffectBigYolkWinParticle_two.startLifetime = this.BigYolkWinlifetime_two * x;
				this.EffectBigYolkWinParticle_thr.startLifetime = this.BigYolkWinlifetime_thr * x;
				this.EffectBigYolkWinParticle_for.startLifetime = this.BigYolkWinlifetime_for * x;
				flag7 = activeSelf;
			}
			this.EffectBigYolkWinGameObject.SetActive(activeSelf);
		}
		if (this.EffectBigYolkLoseGameObject != null)
		{
			bool activeSelf = this.EffectBigYolkLoseGameObject.activeSelf;
			localPosition = this.EffectBigYolkLoseTransform.localPosition;
			UnityEngine.Object.DestroyObject(this.EffectBigYolkLoseGameObject);
			this.EffectBigYolkLoseGameObject = ParticleManager.Instance.Spawn(effID11, null, Vector3.zero, 1f, false, false, true);
			this.EffectBigYolkLoseTransform = this.EffectBigYolkLoseGameObject.transform;
			this.EffectBigYolkLoseTransform.SetParent(this.YolkLayoutTransform);
			this.EffectBigYolkLoseTransform.localPosition = localPosition;
			this.EffectBigYolkLoseParticle = this.EffectBigYolkLoseTransform.GetChild(0).GetComponent<ParticleSystem>();
			this.EffectBigYolkLoseParticle_one = this.EffectBigYolkLoseTransform.GetChild(1).GetComponent<ParticleSystem>();
			this.EffectBigYolkLoseParticle_two = this.EffectBigYolkLoseTransform.GetChild(2).GetComponent<ParticleSystem>();
			this.BigYolkLosestartSize = this.EffectBigYolkLoseParticle.startSize;
			this.BigYolkLosestartSize_one = this.EffectBigYolkLoseParticle_one.startSize;
			this.BigYolkLosestartSize_two = this.EffectBigYolkLoseParticle_two.startSize;
			this.BigYolkLoselifetime = this.EffectBigYolkLoseParticle.startLifetime;
			this.BigYolkLosestartSize_one = this.EffectBigYolkLoseParticle_one.startSize;
			this.BigYolkLosestartSize_two = this.EffectBigYolkLoseParticle_two.startSize;
			if (activeSelf)
			{
				this.EffectBigYolkLoseParticle.startSize = this.BigYolkLosestartSize * x;
				this.EffectBigYolkLoseParticle_one.startSize = this.BigYolkLosestartSize_one * x;
				this.EffectBigYolkLoseParticle_two.startSize = this.BigYolkLosestartSize_two * x;
				this.EffectBigYolkLoseParticle.startLifetime = this.BigYolkLoselifetime * x;
				this.EffectBigYolkLoseParticle_one.startLifetime = this.BigYolkLoselifetime_one * x;
				this.EffectBigYolkLoseParticle_two.startLifetime = this.BigYolkLoselifetime_two * x;
				flag7 = activeSelf;
			}
			this.EffectBigYolkLoseGameObject.SetActive(activeSelf);
		}
		if (this.EffectBigYolkShieldGameObject != null)
		{
			bool activeSelf = this.EffectBigYolkShieldGameObject.activeSelf;
			localPosition = this.EffectBigYolkShieldTransform.localPosition;
			UnityEngine.Object.DestroyObject(this.EffectBigYolkShieldGameObject);
			this.EffectBigYolkShieldGameObject = ParticleManager.Instance.Spawn(effID12, null, Vector3.zero, 1f, false, false, true);
			this.EffectBigYolkShieldTransform = this.EffectBigYolkShieldGameObject.transform;
			this.EffectBigYolkShieldTransform.SetParent(this.YolkLayoutTransform);
			this.EffectBigYolkShieldTransform.localPosition = localPosition;
			this.EffectBigYolkShieldParticle = this.EffectBigYolkShieldTransform.GetChild(0).GetComponent<ParticleSystem>();
			this.EffectBigYolkShieldParticle_one = this.EffectBigYolkShieldTransform.GetChild(1).GetComponent<ParticleSystem>();
			this.EffectBigYolkShieldParticle_two = this.EffectBigYolkShieldTransform.GetChild(2).GetComponent<ParticleSystem>();
			this.EffectBigYolkShieldParticle_thr = this.EffectBigYolkShieldTransform.GetChild(3).GetComponent<ParticleSystem>();
			this.BigYolkShieldstartSize = this.EffectBigYolkShieldParticle.startSize;
			this.BigYolkShieldstartSize_one = this.EffectBigYolkShieldParticle_one.startSize;
			this.BigYolkShieldstartSize_two = this.EffectBigYolkShieldParticle_two.startSize;
			this.BigYolkShieldstartSize_thr = this.EffectBigYolkShieldParticle_thr.startSize;
			this.BigYolkShieldlifetime = this.EffectBigYolkShieldParticle.startLifetime;
			this.BigYolkShieldlifetime_one = this.EffectBigYolkShieldParticle_one.startLifetime;
			this.BigYolkShieldlifetime_two = this.EffectBigYolkShieldParticle_two.startLifetime;
			this.BigYolkShieldlifetime_thr = this.EffectBigYolkShieldParticle_thr.startLifetime;
			if (activeSelf)
			{
				this.EffectBigYolkShieldParticle.startSize = this.BigYolkShieldstartSize * x;
				this.EffectBigYolkShieldParticle_one.startSize = this.BigYolkShieldstartSize_one * x;
				this.EffectBigYolkShieldParticle_two.startSize = this.BigYolkShieldstartSize_two * x * this.YolkShieldScale;
				this.EffectBigYolkShieldParticle_thr.startSize = this.BigYolkShieldstartSize_thr * x * this.YolkShieldScale;
				this.EffectBigYolkShieldParticle.startLifetime = this.BigYolkShieldlifetime * x;
				this.EffectBigYolkShieldParticle_one.startLifetime = this.BigYolkShieldlifetime_one * x;
				flag7 = activeSelf;
			}
			this.EffectBigYolkShieldGameObject.SetActive(activeSelf);
		}
		if (flag7)
		{
			this.setEffect(this.Yolkrow, this.Yolkcol, DataManager.MapDataController.zoomSize);
		}
		for (int num7 = 0; num7 < this.EffectWinGameObject.Length; num7++)
		{
			for (int num8 = 0; num8 < this.EffectWinGameObject[num7].Length; num8++)
			{
				flag7 = false;
				if (this.EffectWinGameObject[num7][num8] != null)
				{
					localPosition = this.EffectWinTransform[num7][num8].localPosition;
					UnityEngine.Object.DestroyObject(this.EffectWinGameObject[num7][num8]);
					this.EffectWinGameObject[num7][num8] = ParticleManager.Instance.Spawn(effID, null, Vector3.zero, 1f, false, false, true);
					this.EffectWinTransform[num7][num8] = this.EffectWinGameObject[num7][num8].transform;
					this.EffectWinTransform[num7][num8].SetParent(this.WinLayoutTransform);
					this.EffectWinTransform[num7][num8].localPosition = localPosition;
					this.EffectWinParticle[num7][num8] = this.EffectWinTransform[num7][num8].GetChild(0).GetComponent<ParticleSystem>();
					if (!flag)
					{
						this.WinstartSize = this.EffectWinParticle[num7][num8].startSize;
						this.Winlifetime = this.EffectWinParticle[num7][num8].startLifetime;
						flag = true;
					}
					this.EffectWinParticle[num7][num8].startSize = this.WinstartSize * x;
					this.EffectWinParticle[num7][num8].startLifetime = this.Winlifetime * x;
					this.EffectWinGameObject[num7][num8].SetActive(true);
					flag7 = true;
				}
				if (this.EffectLoseGameObject[num7][num8] != null)
				{
					localPosition = this.EffectLoseTransform[num7][num8].localPosition;
					UnityEngine.Object.DestroyObject(this.EffectLoseGameObject[num7][num8]);
					this.EffectLoseGameObject[num7][num8] = ParticleManager.Instance.Spawn(effID2, null, Vector3.zero, 1f, false, false, true);
					this.EffectLoseTransform[num7][num8] = this.EffectLoseGameObject[num7][num8].transform;
					this.EffectLoseTransform[num7][num8].SetParent(this.LoseLayoutTransform);
					this.EffectLoseTransform[num7][num8].localPosition = localPosition;
					this.EffectLoseParticle[num7][num8] = this.EffectLoseTransform[num7][num8].GetChild(0).GetComponent<ParticleSystem>();
					if (!flag2)
					{
						this.LosestartSize = this.EffectLoseParticle[num7][num8].startSize;
						this.Loselifetime = this.EffectLoseParticle[num7][num8].startLifetime;
						flag2 = true;
					}
					this.EffectLoseParticle[num7][num8].startSize = this.LosestartSize * x;
					this.EffectLoseParticle[num7][num8].startLifetime = this.Loselifetime * x;
					this.EffectLoseGameObject[num7][num8].SetActive(true);
					flag7 = true;
				}
				if (this.EffectShieldGameObject[num7][num8] != null)
				{
					localPosition = this.EffectShieldTransform[num7][num8].localPosition;
					UnityEngine.Object.DestroyObject(this.EffectShieldGameObject[num7][num8]);
					this.EffectShieldGameObject[num7][num8] = ParticleManager.Instance.Spawn(effID3, null, Vector3.zero, 1f, false, false, true);
					this.EffectShieldTransform[num7][num8] = this.EffectShieldGameObject[num7][num8].transform;
					this.EffectShieldTransform[num7][num8].SetParent(this.ShieldLayoutTransform);
					this.EffectShieldTransform[num7][num8].localPosition = localPosition;
					this.EffectShieldParticle[num7][num8] = this.EffectShieldTransform[num7][num8].GetChild(0).GetComponent<ParticleSystem>();
					this.EffectShieldParticle_one[num7][num8] = this.EffectShieldTransform[num7][num8].GetChild(1).GetComponent<ParticleSystem>();
					if (!flag4)
					{
						this.ShieldstartSize = this.EffectShieldParticle[num7][num8].startSize;
						flag4 = true;
					}
					this.EffectShieldParticle[num7][num8].startSize = this.ShieldstartSize * x;
					this.EffectShieldParticle_one[num7][num8].startSize = this.ShieldstartSize * x;
					this.EffectShieldGameObject[num7][num8].SetActive(true);
					flag7 = true;
				}
				if (this.EffectConveyGameObject[num7][num8] != null)
				{
					localPosition = this.EffectConveyTransform[num7][num8].localPosition;
					UnityEngine.Object.DestroyObject(this.EffectConveyGameObject[num7][num8]);
					this.EffectConveyGameObject[num7][num8] = ParticleManager.Instance.Spawn(effID4, null, Vector3.zero, 1f, false, false, true);
					this.EffectConveyTransform[num7][num8] = this.EffectConveyGameObject[num7][num8].transform;
					this.EffectConveyTransform[num7][num8].SetParent(this.ConveyLayoutTransform);
					this.EffectConveyTransform[num7][num8].localPosition = localPosition;
					this.EffectConveyParticle[num7][num8] = this.EffectConveyTransform[num7][num8].GetChild(0).GetComponent<ParticleSystem>();
					this.EffectConveyParticle_one[num7][num8] = this.EffectConveyTransform[num7][num8].GetChild(1).GetComponent<ParticleSystem>();
					this.EffectConveyParticle_two[num7][num8] = this.EffectConveyTransform[num7][num8].GetChild(2).GetComponent<ParticleSystem>();
					this.EffectConveyParticle_thr[num7][num8] = this.EffectConveyTransform[num7][num8].GetChild(3).GetComponent<ParticleSystem>();
					if (!flag5)
					{
						this.ConveystartSize = this.EffectConveyParticle[num7][num8].startSize;
						this.Conveylifetime = this.EffectConveyParticle[num7][num8].startLifetime;
						this.ConveystartSize_one = this.EffectConveyParticle_one[num7][num8].startSize;
						this.Conveylifetime_one = this.EffectConveyParticle_one[num7][num8].startLifetime;
						this.ConveystartSize_two = this.EffectConveyParticle_two[num7][num8].startSize;
						this.Conveylifetime_two = this.EffectConveyParticle_two[num7][num8].startLifetime;
						this.ConveystartSize_thr = this.EffectConveyParticle_thr[num7][num8].startSize;
						this.Conveylifetime_thr = this.EffectConveyParticle_thr[num7][num8].startLifetime;
						flag5 = true;
					}
					this.EffectConveyParticle[num7][num8].startSize = this.ConveystartSize * x;
					this.EffectConveyParticle[num7][num8].startLifetime = this.Conveylifetime * x;
					this.EffectConveyParticle_one[num7][num8].startSize = this.ConveystartSize_one * x;
					this.EffectConveyParticle_one[num7][num8].startLifetime = this.Conveylifetime_one * x;
					this.EffectConveyParticle_two[num7][num8].startSize = this.ConveystartSize_two * x;
					this.EffectConveyParticle_two[num7][num8].startLifetime = this.Conveylifetime_two * x;
					this.EffectConveyParticle_thr[num7][num8].startSize = this.ConveystartSize_thr * x;
					this.EffectConveyParticle_thr[num7][num8].startLifetime = this.Conveylifetime_thr * x;
					this.EffectConveyGameObject[num7][num8].SetActive(true);
					flag7 = true;
				}
				if (this.EffectNPCCityConveyGameObject[num7][num8] != null)
				{
					localPosition = this.EffectNPCCityConveyTransform[num7][num8].localPosition;
					UnityEngine.Object.DestroyObject(this.EffectNPCCityConveyGameObject[num7][num8]);
					this.EffectNPCCityConveyGameObject[num7][num8] = ParticleManager.Instance.Spawn(effID6, null, Vector3.zero, 1f, false, false, true);
					this.EffectNPCCityConveyTransform[num7][num8] = this.EffectNPCCityConveyGameObject[num7][num8].transform;
					this.EffectNPCCityConveyTransform[num7][num8].SetParent(this.NPCCityConveyLayoutTransform);
					this.EffectNPCCityConveyTransform[num7][num8].localPosition = localPosition;
					this.EffectNPCCityConveyParticle[num7][num8] = this.EffectNPCCityConveyTransform[num7][num8].GetChild(0).GetComponent<ParticleSystem>();
					this.EffectNPCCityConveyParticle_one[num7][num8] = this.EffectNPCCityConveyTransform[num7][num8].GetChild(1).GetComponent<ParticleSystem>();
					this.EffectNPCCityConveyParticle_two[num7][num8] = this.EffectNPCCityConveyTransform[num7][num8].GetChild(2).GetComponent<ParticleSystem>();
					this.EffectNPCCityConveyParticle_thr[num7][num8] = this.EffectNPCCityConveyTransform[num7][num8].GetChild(3).GetComponent<ParticleSystem>();
					if (!flag6)
					{
						this.NPCCityConveystartSize = this.EffectNPCCityConveyParticle[num7][num8].startSize;
						this.NPCCityConveylifetime = this.EffectNPCCityConveyParticle[num7][num8].startLifetime;
						this.NPCCityConveystartSize_one = this.EffectNPCCityConveyParticle_one[num7][num8].startSize;
						this.NPCCityConveylifetime_one = this.EffectNPCCityConveyParticle_one[num7][num8].startLifetime;
						this.NPCCityConveystartSize_two = this.EffectNPCCityConveyParticle_two[num7][num8].startSize;
						this.NPCCityConveylifetime_two = this.EffectNPCCityConveyParticle_two[num7][num8].startLifetime;
						this.NPCCityConveystartSize_thr = this.EffectNPCCityConveyParticle_thr[num7][num8].startSize;
						this.NPCCityConveylifetime_thr = this.EffectNPCCityConveyParticle_thr[num7][num8].startLifetime;
						flag6 = true;
					}
					this.EffectNPCCityConveyParticle[num7][num8].startSize = this.NPCCityConveystartSize * x;
					this.EffectNPCCityConveyParticle[num7][num8].startLifetime = this.NPCCityConveylifetime * x;
					this.EffectNPCCityConveyParticle_one[num7][num8].startSize = this.NPCCityConveystartSize_one * x;
					this.EffectNPCCityConveyParticle_one[num7][num8].startLifetime = this.NPCCityConveylifetime_one * x;
					this.EffectNPCCityConveyParticle_two[num7][num8].startSize = this.NPCCityConveystartSize_two * x;
					this.EffectNPCCityConveyParticle_two[num7][num8].startLifetime = this.NPCCityConveylifetime_two * x;
					this.EffectNPCCityConveyParticle_thr[num7][num8].startSize = this.NPCCityConveystartSize_thr * x;
					this.EffectNPCCityConveyParticle_thr[num7][num8].startLifetime = this.NPCCityConveylifetime_thr * x;
					this.EffectNPCCityConveyGameObject[num7][num8].SetActive(true);
					flag7 = true;
				}
				if (this.EffectEnemyLoseGameObject[num7][num8] != null)
				{
					localPosition = this.EffectEnemyLoseTransform[num7][num8].localPosition;
					UnityEngine.Object.DestroyObject(this.EffectEnemyLoseGameObject[num7][num8]);
					this.EffectEnemyLoseGameObject[num7][num8] = ParticleManager.Instance.Spawn(effID5, null, Vector3.zero, 1f, false, false, true);
					this.EffectEnemyLoseTransform[num7][num8] = this.EffectEnemyLoseGameObject[num7][num8].transform;
					this.EffectEnemyLoseTransform[num7][num8].SetParent(this.EnemyLoseLayoutTransform);
					this.EffectEnemyLoseTransform[num7][num8].localPosition = localPosition;
					this.EffectEnemyLoseParticle[num7][num8] = this.EffectEnemyLoseTransform[num7][num8].GetChild(0).GetComponent<ParticleSystem>();
					if (!flag3)
					{
						this.EnemyLosestartSize = this.EffectEnemyLoseParticle[num7][num8].startSize;
						this.EnemyLoselifetime = this.EffectEnemyLoseParticle[num7][num8].startLifetime;
						flag3 = true;
					}
					this.EffectEnemyLoseParticle[num7][num8].startSize = this.EnemyLosestartSize * x;
					this.EffectEnemyLoseParticle[num7][num8].startLifetime = this.EnemyLoselifetime * x;
					this.EffectEnemyLoseGameObject[num7][num8].SetActive(true);
					flag7 = true;
				}
				if (flag7)
				{
					this.setEffect(num8, num7, DataManager.MapDataController.zoomSize);
				}
			}
		}
		GC.Collect();
	}

	// Token: 0x040024F8 RID: 9464
	private const ushort EffectWinID = 60102;

	// Token: 0x040024F9 RID: 9465
	private const ushort EffectLoseID = 60101;

	// Token: 0x040024FA RID: 9466
	private const ushort EffectShieldID = 60103;

	// Token: 0x040024FB RID: 9467
	private const ushort EffectConveyID = 60111;

	// Token: 0x040024FC RID: 9468
	private const ushort EffectEnemyLoseID = 60110;

	// Token: 0x040024FD RID: 9469
	private const ushort EffectYolkWinID = 60104;

	// Token: 0x040024FE RID: 9470
	private const ushort EffectYolkLoseID = 60105;

	// Token: 0x040024FF RID: 9471
	private const ushort EffectYolkShieldID = 60106;

	// Token: 0x04002500 RID: 9472
	private const ushort EffectBigYolkWinID = 60107;

	// Token: 0x04002501 RID: 9473
	private const ushort EffectBigYolkLoseID = 60108;

	// Token: 0x04002502 RID: 9474
	private const ushort EffectBigYolkShieldID = 60109;

	// Token: 0x04002503 RID: 9475
	private const ushort EffectWinID_Back = 198;

	// Token: 0x04002504 RID: 9476
	private const ushort EffectLoseID_Back = 197;

	// Token: 0x04002505 RID: 9477
	private const ushort EffectShieldID_Back = 199;

	// Token: 0x04002506 RID: 9478
	private const ushort EffectConveyID_Back = 332;

	// Token: 0x04002507 RID: 9479
	private const ushort EffectEnemyLoseID_Back = 387;

	// Token: 0x04002508 RID: 9480
	private const ushort EffectYolkWinID_Back = 379;

	// Token: 0x04002509 RID: 9481
	private const ushort EffectYolkLoseID_Back = 380;

	// Token: 0x0400250A RID: 9482
	private const ushort EffectYolkShieldID_Back = 381;

	// Token: 0x0400250B RID: 9483
	private const ushort EffectBigYolkWinID_Back = 383;

	// Token: 0x0400250C RID: 9484
	private const ushort EffectBigYolkLoseID_Back = 384;

	// Token: 0x0400250D RID: 9485
	private const ushort EffectBigYolkShieldID_Back = 385;

	// Token: 0x0400250E RID: 9486
	private const ushort EffectNPCCityConveyID = 60112;

	// Token: 0x0400250F RID: 9487
	private const ushort EffectNPCCityConveyID_Back = 390;

	// Token: 0x04002510 RID: 9488
	private const ushort EffectBallDownID = 60501;

	// Token: 0x04002511 RID: 9489
	private const ushort EffectBallBigYolkID = 60502;

	// Token: 0x04002512 RID: 9490
	private const ushort EffectBallYolkID = 60503;

	// Token: 0x04002513 RID: 9491
	private const ushort EffectBallNPCCityID = 60504;

	// Token: 0x04002514 RID: 9492
	private const ushort EffectBallOutID = 60505;

	// Token: 0x04002515 RID: 9493
	private const ushort EffectBallKickID = 60506;

	// Token: 0x04002516 RID: 9494
	private const ushort EffectMapWeaponHurtID = 60601;

	// Token: 0x04002517 RID: 9495
	public bool active = true;

	// Token: 0x04002518 RID: 9496
	private Transform RealmGroup;

	// Token: 0x04002519 RID: 9497
	private Transform EffectLayoutTransform;

	// Token: 0x0400251A RID: 9498
	private Transform WinLayoutTransform;

	// Token: 0x0400251B RID: 9499
	private Transform LoseLayoutTransform;

	// Token: 0x0400251C RID: 9500
	private Transform ShieldLayoutTransform;

	// Token: 0x0400251D RID: 9501
	private Transform ConveyLayoutTransform;

	// Token: 0x0400251E RID: 9502
	private Transform YolkLayoutTransform;

	// Token: 0x0400251F RID: 9503
	private Transform EnemyLoseLayoutTransform;

	// Token: 0x04002520 RID: 9504
	private Transform NPCCityConveyLayoutTransform;

	// Token: 0x04002521 RID: 9505
	private Transform MapWeaponHurtLayoutTransform;

	// Token: 0x04002522 RID: 9506
	private Transform BallDownLayoutTransform;

	// Token: 0x04002523 RID: 9507
	private Transform BallBigYolkLayoutTransform;

	// Token: 0x04002524 RID: 9508
	private Transform BallYolkLayoutTransform;

	// Token: 0x04002525 RID: 9509
	private Transform BallNPCCityLayoutTransform;

	// Token: 0x04002526 RID: 9510
	private Transform BallOutLayoutTransform;

	// Token: 0x04002527 RID: 9511
	private Transform BallKickLayoutTransform;

	// Token: 0x04002528 RID: 9512
	private GameObject[][] EffectWinGameObject;

	// Token: 0x04002529 RID: 9513
	private GameObject[][] EffectLoseGameObject;

	// Token: 0x0400252A RID: 9514
	private GameObject[][] EffectShieldGameObject;

	// Token: 0x0400252B RID: 9515
	private GameObject[][] EffectConveyGameObject;

	// Token: 0x0400252C RID: 9516
	private GameObject[][] EffectEnemyLoseGameObject;

	// Token: 0x0400252D RID: 9517
	private GameObject[][] EffectNPCCityConveyGameObject;

	// Token: 0x0400252E RID: 9518
	private GameObject[][] EffectMapWeaponHurtGameObject;

	// Token: 0x0400252F RID: 9519
	private GameObject[][] EffectBallDownGameObject;

	// Token: 0x04002530 RID: 9520
	private GameObject[][] EffectBallBigYolkGameObject;

	// Token: 0x04002531 RID: 9521
	private GameObject[][] EffectBallYolkGameObject;

	// Token: 0x04002532 RID: 9522
	private GameObject[][] EffectBallNPCCityGameObject;

	// Token: 0x04002533 RID: 9523
	private GameObject[][] EffectBallOutGameObject;

	// Token: 0x04002534 RID: 9524
	private GameObject[][] EffectBallKickGameObject;

	// Token: 0x04002535 RID: 9525
	private GameObject EffectYolkWinGameObject;

	// Token: 0x04002536 RID: 9526
	private GameObject EffectYolkLoseGameObject;

	// Token: 0x04002537 RID: 9527
	private GameObject EffectYolkShieldGameObject;

	// Token: 0x04002538 RID: 9528
	private GameObject EffectBigYolkWinGameObject;

	// Token: 0x04002539 RID: 9529
	private GameObject EffectBigYolkLoseGameObject;

	// Token: 0x0400253A RID: 9530
	private GameObject EffectBigYolkShieldGameObject;

	// Token: 0x0400253B RID: 9531
	private Transform[][] EffectWinTransform;

	// Token: 0x0400253C RID: 9532
	private Transform[][] EffectLoseTransform;

	// Token: 0x0400253D RID: 9533
	private Transform[][] EffectShieldTransform;

	// Token: 0x0400253E RID: 9534
	private Transform[][] EffectConveyTransform;

	// Token: 0x0400253F RID: 9535
	private Transform[][] EffectEnemyLoseTransform;

	// Token: 0x04002540 RID: 9536
	private Transform[][] EffectNPCCityConveyTransform;

	// Token: 0x04002541 RID: 9537
	private Transform[][] EffectMapWeaponHurtTransform;

	// Token: 0x04002542 RID: 9538
	private Transform[][] EffectBallDownTransform;

	// Token: 0x04002543 RID: 9539
	private Transform[][] EffectBallBigYolkTransform;

	// Token: 0x04002544 RID: 9540
	private Transform[][] EffectBallYolkTransform;

	// Token: 0x04002545 RID: 9541
	private Transform[][] EffectBallNPCCityTransform;

	// Token: 0x04002546 RID: 9542
	private Transform[][] EffectBallOutTransform;

	// Token: 0x04002547 RID: 9543
	private Transform[][] EffectBallKickTransform;

	// Token: 0x04002548 RID: 9544
	private Transform EffectYolkWinTransform;

	// Token: 0x04002549 RID: 9545
	private Transform EffectYolkLoseTransform;

	// Token: 0x0400254A RID: 9546
	private Transform EffectYolkShieldTransform;

	// Token: 0x0400254B RID: 9547
	private Transform EffectBigYolkWinTransform;

	// Token: 0x0400254C RID: 9548
	private Transform EffectBigYolkLoseTransform;

	// Token: 0x0400254D RID: 9549
	private Transform EffectBigYolkShieldTransform;

	// Token: 0x0400254E RID: 9550
	private ParticleSystem[][] EffectWinParticle;

	// Token: 0x0400254F RID: 9551
	private ParticleSystem[][] EffectLoseParticle;

	// Token: 0x04002550 RID: 9552
	private ParticleSystem[][] EffectShieldParticle;

	// Token: 0x04002551 RID: 9553
	private ParticleSystem[][] EffectShieldParticle_one;

	// Token: 0x04002552 RID: 9554
	private ParticleSystem[][] EffectConveyParticle;

	// Token: 0x04002553 RID: 9555
	private ParticleSystem[][] EffectConveyParticle_one;

	// Token: 0x04002554 RID: 9556
	private ParticleSystem[][] EffectConveyParticle_two;

	// Token: 0x04002555 RID: 9557
	private ParticleSystem[][] EffectConveyParticle_thr;

	// Token: 0x04002556 RID: 9558
	private ParticleSystem[][] EffectEnemyLoseParticle;

	// Token: 0x04002557 RID: 9559
	private ParticleSystem[][] EffectNPCCityConveyParticle;

	// Token: 0x04002558 RID: 9560
	private ParticleSystem[][] EffectNPCCityConveyParticle_one;

	// Token: 0x04002559 RID: 9561
	private ParticleSystem[][] EffectNPCCityConveyParticle_two;

	// Token: 0x0400255A RID: 9562
	private ParticleSystem[][] EffectNPCCityConveyParticle_thr;

	// Token: 0x0400255B RID: 9563
	private ParticleSystem[][][] EffectMapWeaponHurtParticle;

	// Token: 0x0400255C RID: 9564
	private ParticleSystem[][][] EffectBallDownParticle;

	// Token: 0x0400255D RID: 9565
	private ParticleSystem[][][] EffectBallBigYolkParticle;

	// Token: 0x0400255E RID: 9566
	private ParticleSystem[][][] EffectBallYolkParticle;

	// Token: 0x0400255F RID: 9567
	private ParticleSystem[][][] EffectBallNPCCityParticle;

	// Token: 0x04002560 RID: 9568
	private ParticleSystem[][][] EffectBallOutParticle;

	// Token: 0x04002561 RID: 9569
	private ParticleSystem[][][] EffectBallKickParticle;

	// Token: 0x04002562 RID: 9570
	private ParticleSystem EffectYolkWinParticle;

	// Token: 0x04002563 RID: 9571
	private ParticleSystem EffectYolkWinParticle_one;

	// Token: 0x04002564 RID: 9572
	private ParticleSystem EffectYolkWinParticle_two;

	// Token: 0x04002565 RID: 9573
	private ParticleSystem EffectYolkWinParticle_thr;

	// Token: 0x04002566 RID: 9574
	private ParticleSystem EffectYolkWinParticle_tho;

	// Token: 0x04002567 RID: 9575
	private ParticleSystem EffectYolkLoseParticle;

	// Token: 0x04002568 RID: 9576
	private ParticleSystem EffectYolkLoseParticle_one;

	// Token: 0x04002569 RID: 9577
	private ParticleSystem EffectYolkShieldParticle;

	// Token: 0x0400256A RID: 9578
	private ParticleSystem EffectYolkShieldParticle_one;

	// Token: 0x0400256B RID: 9579
	private ParticleSystem EffectYolkShieldParticle_two;

	// Token: 0x0400256C RID: 9580
	private ParticleSystem EffectYolkShieldParticle_thr;

	// Token: 0x0400256D RID: 9581
	private ParticleSystem EffectBigYolkWinParticle;

	// Token: 0x0400256E RID: 9582
	private ParticleSystem EffectBigYolkWinParticle_one;

	// Token: 0x0400256F RID: 9583
	private ParticleSystem EffectBigYolkWinParticle_two;

	// Token: 0x04002570 RID: 9584
	private ParticleSystem EffectBigYolkWinParticle_thr;

	// Token: 0x04002571 RID: 9585
	private ParticleSystem EffectBigYolkWinParticle_for;

	// Token: 0x04002572 RID: 9586
	private ParticleSystem EffectBigYolkLoseParticle;

	// Token: 0x04002573 RID: 9587
	private ParticleSystem EffectBigYolkLoseParticle_one;

	// Token: 0x04002574 RID: 9588
	private ParticleSystem EffectBigYolkLoseParticle_two;

	// Token: 0x04002575 RID: 9589
	private ParticleSystem EffectBigYolkShieldParticle;

	// Token: 0x04002576 RID: 9590
	private ParticleSystem EffectBigYolkShieldParticle_one;

	// Token: 0x04002577 RID: 9591
	private ParticleSystem EffectBigYolkShieldParticle_two;

	// Token: 0x04002578 RID: 9592
	private ParticleSystem EffectBigYolkShieldParticle_thr;

	// Token: 0x04002579 RID: 9593
	private GameObject[][] EffectWinGameObjectPools;

	// Token: 0x0400257A RID: 9594
	private GameObject[][] EffectLoseGameObjectPools;

	// Token: 0x0400257B RID: 9595
	private GameObject[][] EffectShieldGameObjectPools;

	// Token: 0x0400257C RID: 9596
	private GameObject[][] EffectConveyGameObjectPools;

	// Token: 0x0400257D RID: 9597
	private GameObject[][] EffectEnemyLoseGameObjectPools;

	// Token: 0x0400257E RID: 9598
	private GameObject[][] EffectNPCCityConveyGameObjectPools;

	// Token: 0x0400257F RID: 9599
	private GameObject[][] EffectMapWeaponHurtGameObjectPools;

	// Token: 0x04002580 RID: 9600
	private GameObject[][] EffectBallDownGameObjectPools;

	// Token: 0x04002581 RID: 9601
	private GameObject[][] EffectBallBigYolkGameObjectPools;

	// Token: 0x04002582 RID: 9602
	private GameObject[][] EffectBallYolkGameObjectPools;

	// Token: 0x04002583 RID: 9603
	private GameObject[][] EffectBallNPCCityGameObjectPools;

	// Token: 0x04002584 RID: 9604
	private GameObject[][] EffectBallOutGameObjectPools;

	// Token: 0x04002585 RID: 9605
	private GameObject[][] EffectBallKickGameObjectPools;

	// Token: 0x04002586 RID: 9606
	private Transform[][] EffectWinTransformPools;

	// Token: 0x04002587 RID: 9607
	private Transform[][] EffectLoseTransformPools;

	// Token: 0x04002588 RID: 9608
	private Transform[][] EffectShieldTransformPools;

	// Token: 0x04002589 RID: 9609
	private Transform[][] EffectConveyTransformPools;

	// Token: 0x0400258A RID: 9610
	private Transform[][] EffectEnemyLoseTransformPools;

	// Token: 0x0400258B RID: 9611
	private Transform[][] EffectNPCCityConveyTransformPools;

	// Token: 0x0400258C RID: 9612
	private Transform[][] EffectMapWeaponHurtTransformPools;

	// Token: 0x0400258D RID: 9613
	private Transform[][] EffectBallDownTransformPools;

	// Token: 0x0400258E RID: 9614
	private Transform[][] EffectBallBigYolkTransformPools;

	// Token: 0x0400258F RID: 9615
	private Transform[][] EffectBallYolkTransformPools;

	// Token: 0x04002590 RID: 9616
	private Transform[][] EffectBallNPCCityTransformPools;

	// Token: 0x04002591 RID: 9617
	private Transform[][] EffectBallOutTransformPools;

	// Token: 0x04002592 RID: 9618
	private Transform[][] EffectBallKickTransformPools;

	// Token: 0x04002593 RID: 9619
	private ParticleSystem[][] EffectWinParticlePools;

	// Token: 0x04002594 RID: 9620
	private ParticleSystem[][] EffectLoseParticlePools;

	// Token: 0x04002595 RID: 9621
	private ParticleSystem[][] EffectShieldParticlePools;

	// Token: 0x04002596 RID: 9622
	private ParticleSystem[][] EffectShieldParticlePools_one;

	// Token: 0x04002597 RID: 9623
	private ParticleSystem[][] EffectConveyParticlePools;

	// Token: 0x04002598 RID: 9624
	private ParticleSystem[][] EffectConveyParticlePools_one;

	// Token: 0x04002599 RID: 9625
	private ParticleSystem[][] EffectConveyParticlePools_two;

	// Token: 0x0400259A RID: 9626
	private ParticleSystem[][] EffectConveyParticlePools_thr;

	// Token: 0x0400259B RID: 9627
	private ParticleSystem[][] EffectEnemyLoseParticlePools;

	// Token: 0x0400259C RID: 9628
	private ParticleSystem[][] EffectNPCCityConveyParticlePools;

	// Token: 0x0400259D RID: 9629
	private ParticleSystem[][] EffectNPCCityConveyParticlePools_one;

	// Token: 0x0400259E RID: 9630
	private ParticleSystem[][] EffectNPCCityConveyParticlePools_two;

	// Token: 0x0400259F RID: 9631
	private ParticleSystem[][] EffectNPCCityConveyParticlePools_thr;

	// Token: 0x040025A0 RID: 9632
	private ParticleSystem[][][] EffectMapWeaponHurtParticlePools;

	// Token: 0x040025A1 RID: 9633
	private ParticleSystem[][][] EffectBallDownParticlePools;

	// Token: 0x040025A2 RID: 9634
	private ParticleSystem[][][] EffectBallBigYolkParticlePools;

	// Token: 0x040025A3 RID: 9635
	private ParticleSystem[][][] EffectBallYolkParticlePools;

	// Token: 0x040025A4 RID: 9636
	private ParticleSystem[][][] EffectBallNPCCityParticlePools;

	// Token: 0x040025A5 RID: 9637
	private ParticleSystem[][][] EffectBallOutParticlePools;

	// Token: 0x040025A6 RID: 9638
	private ParticleSystem[][][] EffectBallKickParticlePools;

	// Token: 0x040025A7 RID: 9639
	private int[] WinpoolCounter;

	// Token: 0x040025A8 RID: 9640
	private int WinpoolsCounter;

	// Token: 0x040025A9 RID: 9641
	private int[] LosepoolCounter;

	// Token: 0x040025AA RID: 9642
	private int LosepoolsCounter;

	// Token: 0x040025AB RID: 9643
	private int[] ShieldpoolCounter;

	// Token: 0x040025AC RID: 9644
	private int ShieldpoolsCounter;

	// Token: 0x040025AD RID: 9645
	private int[] ConveypoolCounter;

	// Token: 0x040025AE RID: 9646
	private int ConveypoolsCounter;

	// Token: 0x040025AF RID: 9647
	private int[] EnemyLosepoolCounter;

	// Token: 0x040025B0 RID: 9648
	private int EnemyLosepoolsCounter;

	// Token: 0x040025B1 RID: 9649
	private int[] NPCCityConveypoolCounter;

	// Token: 0x040025B2 RID: 9650
	private int NPCCityConveypoolsCounter;

	// Token: 0x040025B3 RID: 9651
	private int[] MapWeaponHurtpoolCounter;

	// Token: 0x040025B4 RID: 9652
	private int MapWeaponHurtpoolsCounter;

	// Token: 0x040025B5 RID: 9653
	private int[] BallDownpoolCounter;

	// Token: 0x040025B6 RID: 9654
	private int BallDownpoolsCounter;

	// Token: 0x040025B7 RID: 9655
	private int[] BallBigYolkpoolCounter;

	// Token: 0x040025B8 RID: 9656
	private int BallBigYolkpoolsCounter;

	// Token: 0x040025B9 RID: 9657
	private int[] BallYolkpoolCounter;

	// Token: 0x040025BA RID: 9658
	private int BallYolkpoolsCounter;

	// Token: 0x040025BB RID: 9659
	private int[] BallNPCCitypoolCounter;

	// Token: 0x040025BC RID: 9660
	private int BallNPCCitypoolsCounter;

	// Token: 0x040025BD RID: 9661
	private int[] BallOutpoolCounter;

	// Token: 0x040025BE RID: 9662
	private int BallOutpoolsCounter;

	// Token: 0x040025BF RID: 9663
	private int[] BallKickpoolCounter;

	// Token: 0x040025C0 RID: 9664
	private int BallKickpoolsCounter;

	// Token: 0x040025C1 RID: 9665
	private Vector3 inipos = new Vector3(0f, 1024f, 0f);

	// Token: 0x040025C2 RID: 9666
	private float WinstartSize;

	// Token: 0x040025C3 RID: 9667
	private float Winlifetime;

	// Token: 0x040025C4 RID: 9668
	private float LosestartSize;

	// Token: 0x040025C5 RID: 9669
	private float Loselifetime;

	// Token: 0x040025C6 RID: 9670
	private float ShieldstartSize;

	// Token: 0x040025C7 RID: 9671
	private float Conveylifetime;

	// Token: 0x040025C8 RID: 9672
	private float Conveylifetime_one;

	// Token: 0x040025C9 RID: 9673
	private float Conveylifetime_two;

	// Token: 0x040025CA RID: 9674
	private float Conveylifetime_thr;

	// Token: 0x040025CB RID: 9675
	private float ConveystartSize;

	// Token: 0x040025CC RID: 9676
	private float ConveystartSize_one;

	// Token: 0x040025CD RID: 9677
	private float ConveystartSize_two;

	// Token: 0x040025CE RID: 9678
	private float ConveystartSize_thr;

	// Token: 0x040025CF RID: 9679
	private float EnemyLosestartSize;

	// Token: 0x040025D0 RID: 9680
	private float EnemyLoselifetime;

	// Token: 0x040025D1 RID: 9681
	private float NPCCityConveylifetime;

	// Token: 0x040025D2 RID: 9682
	private float NPCCityConveylifetime_one;

	// Token: 0x040025D3 RID: 9683
	private float NPCCityConveylifetime_two;

	// Token: 0x040025D4 RID: 9684
	private float NPCCityConveylifetime_thr;

	// Token: 0x040025D5 RID: 9685
	private float NPCCityConveystartSize;

	// Token: 0x040025D6 RID: 9686
	private float NPCCityConveystartSize_one;

	// Token: 0x040025D7 RID: 9687
	private float NPCCityConveystartSize_two;

	// Token: 0x040025D8 RID: 9688
	private float NPCCityConveystartSize_thr;

	// Token: 0x040025D9 RID: 9689
	private float[] MapWeaponHurtlifetime;

	// Token: 0x040025DA RID: 9690
	private float[] MapWeaponHurtstartSize;

	// Token: 0x040025DB RID: 9691
	private float[] BallDownlifetime;

	// Token: 0x040025DC RID: 9692
	private float[] BallDownstartSize;

	// Token: 0x040025DD RID: 9693
	private float[] BallBigYolklifetime;

	// Token: 0x040025DE RID: 9694
	private float[] BallBigYolkstartSize;

	// Token: 0x040025DF RID: 9695
	private float[] BallYolklifetime;

	// Token: 0x040025E0 RID: 9696
	private float[] BallYolkstartSize;

	// Token: 0x040025E1 RID: 9697
	private float[] BallNPCCitylifetime;

	// Token: 0x040025E2 RID: 9698
	private float[] BallNPCCitystartSize;

	// Token: 0x040025E3 RID: 9699
	private float[] BallOutlifetime;

	// Token: 0x040025E4 RID: 9700
	private float[] BallOutstartSize;

	// Token: 0x040025E5 RID: 9701
	private float[] BallKicklifetime;

	// Token: 0x040025E6 RID: 9702
	private float[] BallKickstartSize;

	// Token: 0x040025E7 RID: 9703
	private float YolkWinstartSize;

	// Token: 0x040025E8 RID: 9704
	private float YolkWinstartSize_one;

	// Token: 0x040025E9 RID: 9705
	private float YolkWinstartSize_two;

	// Token: 0x040025EA RID: 9706
	private float YolkWinstartSize_thr;

	// Token: 0x040025EB RID: 9707
	private float YolkWinstartSize_tho;

	// Token: 0x040025EC RID: 9708
	private float YolkWinlifetime;

	// Token: 0x040025ED RID: 9709
	private float YolkWinlifetime_one;

	// Token: 0x040025EE RID: 9710
	private float YolkWinlifetime_two;

	// Token: 0x040025EF RID: 9711
	private float YolkWinlifetime_thr;

	// Token: 0x040025F0 RID: 9712
	private float YolkWinlifetime_tho;

	// Token: 0x040025F1 RID: 9713
	private float YolkLosestartSize;

	// Token: 0x040025F2 RID: 9714
	private float YolkLosestartSize_one;

	// Token: 0x040025F3 RID: 9715
	private float YolkLoselifetime;

	// Token: 0x040025F4 RID: 9716
	private float YolkLoselifetime_one;

	// Token: 0x040025F5 RID: 9717
	private float YolkShieldstartSize;

	// Token: 0x040025F6 RID: 9718
	private float YolkShieldstartSize_one;

	// Token: 0x040025F7 RID: 9719
	private float YolkShieldstartSize_two;

	// Token: 0x040025F8 RID: 9720
	private float YolkShieldstartSize_thr;

	// Token: 0x040025F9 RID: 9721
	private float YolkShieldlifetime;

	// Token: 0x040025FA RID: 9722
	private float YolkShieldlifetime_one;

	// Token: 0x040025FB RID: 9723
	private float YolkShieldlifetime_two;

	// Token: 0x040025FC RID: 9724
	private float YolkShieldlifetime_thr;

	// Token: 0x040025FD RID: 9725
	private float BigYolkWinstartSize;

	// Token: 0x040025FE RID: 9726
	private float BigYolkWinstartSize_one;

	// Token: 0x040025FF RID: 9727
	private float BigYolkWinstartSize_two;

	// Token: 0x04002600 RID: 9728
	private float BigYolkWinstartSize_thr;

	// Token: 0x04002601 RID: 9729
	private float BigYolkWinstartSize_for;

	// Token: 0x04002602 RID: 9730
	private float BigYolkWinlifetime;

	// Token: 0x04002603 RID: 9731
	private float BigYolkWinlifetime_one;

	// Token: 0x04002604 RID: 9732
	private float BigYolkWinlifetime_two;

	// Token: 0x04002605 RID: 9733
	private float BigYolkWinlifetime_thr;

	// Token: 0x04002606 RID: 9734
	private float BigYolkWinlifetime_for;

	// Token: 0x04002607 RID: 9735
	private float BigYolkLosestartSize;

	// Token: 0x04002608 RID: 9736
	private float BigYolkLosestartSize_one;

	// Token: 0x04002609 RID: 9737
	private float BigYolkLosestartSize_two;

	// Token: 0x0400260A RID: 9738
	private float BigYolkLoselifetime;

	// Token: 0x0400260B RID: 9739
	private float BigYolkLoselifetime_one;

	// Token: 0x0400260C RID: 9740
	private float BigYolkLoselifetime_two;

	// Token: 0x0400260D RID: 9741
	private float BigYolkShieldstartSize;

	// Token: 0x0400260E RID: 9742
	private float BigYolkShieldstartSize_one;

	// Token: 0x0400260F RID: 9743
	private float BigYolkShieldstartSize_two;

	// Token: 0x04002610 RID: 9744
	private float BigYolkShieldstartSize_thr;

	// Token: 0x04002611 RID: 9745
	private float BigYolkShieldlifetime;

	// Token: 0x04002612 RID: 9746
	private float BigYolkShieldlifetime_one;

	// Token: 0x04002613 RID: 9747
	private float BigYolkShieldlifetime_two;

	// Token: 0x04002614 RID: 9748
	private float BigYolkShieldlifetime_thr;

	// Token: 0x04002615 RID: 9749
	private float YolkShieldScale = 1.33333337f;

	// Token: 0x04002616 RID: 9750
	private int Yolkrow = -1;

	// Token: 0x04002617 RID: 9751
	private int Yolkcol = -1;

	// Token: 0x04002618 RID: 9752
	private ParticleSystem.Particle[] particles = new ParticleSystem.Particle[64];

	// Token: 0x04002619 RID: 9753
	private byte bBack = 1;

	// Token: 0x0400261A RID: 9754
	private bool bFront;

	// Token: 0x0400261B RID: 9755
	private float[][] Particletimer;

	// Token: 0x0400261C RID: 9756
	private byte[][] Particlekind;
}
