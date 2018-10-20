using System;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x02000700 RID: 1792
public class UILoadingTalk : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x0600224C RID: 8780 RVA: 0x004059E0 File Offset: 0x00403BE0
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_transform = base.transform;
		Font ttffont = this.GM.GetTTFFont();
		AudioManager.Instance.LoadSFXObj();
		this.BackT = this.m_transform.GetChild(0);
		this.TalkTextLRC = this.m_transform.GetChild(1).GetComponent<RectTransform>();
		this.TalkTextL = this.TalkTextLRC.GetChild(1).GetComponent<UIText>();
		this.TalkTextL.font = ttffont;
		this.TalkTextRRC = this.m_transform.GetChild(2).GetComponent<RectTransform>();
		this.TalkTextR = this.TalkTextRRC.GetChild(1).GetComponent<UIText>();
		this.TalkTextR.font = ttffont;
		this.NowText = this.TalkTextL;
		this.NowTextRC = this.TalkTextLRC;
		this.QuestionRC = this.m_transform.GetChild(3).GetComponent<RectTransform>();
		UIButton component = this.QuestionRC.GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1;
		component.SoundIndex = byte.MaxValue;
		component = this.QuestionRC.GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 2;
		component.SoundIndex = byte.MaxValue;
		this.SelectText1 = this.QuestionRC.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.SelectText1.font = ttffont;
		this.SelectText2 = this.QuestionRC.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.SelectText2.font = ttffont;
		this.QuestionRC.gameObject.SetActive(true);
		this.QuestBtn1 = this.QuestionRC.GetChild(0).gameObject;
		this.QuestBtn2 = this.QuestionRC.GetChild(1).gameObject;
		this.QuestBtnRC1 = this.QuestionRC.GetChild(0).GetComponent<RectTransform>();
		this.QuestBtnRC2 = this.QuestionRC.GetChild(1).GetComponent<RectTransform>();
		this.QuestBtn1.SetActive(false);
		this.QuestBtn2.SetActive(false);
		this.ActorT[0] = this.m_transform.GetChild(4);
		this.ActorT[1] = this.m_transform.GetChild(5);
		this.ActorT[2] = this.m_transform.GetChild(6);
		this.LightGO[0] = this.m_transform.GetChild(7).gameObject;
		this.LightGO[1] = this.m_transform.GetChild(8).gameObject;
		this.LightGO[2] = this.m_transform.GetChild(9).gameObject;
		this.LoadActor();
	}

	// Token: 0x0600224D RID: 8781 RVA: 0x00405C80 File Offset: 0x00403E80
	public override void OnClose()
	{
		for (int i = 0; i < 3; i++)
		{
			if (this.AssetKey[i] != 0)
			{
				AssetManager.UnloadAssetBundle(this.AssetKey[i], true);
			}
		}
		this.GM.CloseLoadingTalk_TBox();
	}

	// Token: 0x0600224E RID: 8782 RVA: 0x00405CC8 File Offset: 0x00403EC8
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 10)
		{
			if (this.TalkTextL != null && this.TalkTextL.enabled)
			{
				this.TalkTextL.enabled = false;
				this.TalkTextL.enabled = true;
			}
			if (this.TalkTextR != null && this.TalkTextR.enabled)
			{
				this.TalkTextR.enabled = false;
				this.TalkTextR.enabled = true;
			}
			if (this.SelectText1 != null && this.SelectText1.enabled)
			{
				this.SelectText1.enabled = false;
				this.SelectText1.enabled = true;
			}
			if (this.SelectText2 != null && this.SelectText2.enabled)
			{
				this.SelectText2.enabled = false;
				this.SelectText2.enabled = true;
			}
			return;
		}
		this.NowKey += 1;
		LoadingTalk recordByKey = this.GM.LoadingTalkTable.GetRecordByKey(this.NowKey);
		while (recordByKey.ID != 0 && recordByKey.Kind >= 3)
		{
			this.NowKey += 1;
			recordByKey = this.GM.LoadingTalkTable.GetRecordByKey(this.NowKey);
		}
		this.LoadByKey(this.NowKey);
	}

	// Token: 0x0600224F RID: 8783 RVA: 0x00405E38 File Offset: 0x00404038
	private void Update()
	{
		if (!this.bLoadAllActor)
		{
			this.SetActor();
		}
		if (this.bCheckWaitTime)
		{
			if (this.bWaitSelect)
			{
				this.WaitSelectTime -= Time.deltaTime;
				if (this.WaitSelectTime <= 0f)
				{
					this.QuestBtn2.SetActive(true);
					uTweenScale uTweenScale = uTweenScale.Begin(this.QuestBtn2, Vector3.zero, Vector3.one, 1.3f, 0f);
					if (uTweenScale)
					{
						uTweenScale.easeType = EaseType.easeOutBounce;
					}
					AudioManager.Instance.PlayUISFX(UIKind.BuildUp);
					this.bWaitSelect = false;
					this.SelectCountTime = 3.5f;
					this.bSelectCount = false;
				}
			}
			else
			{
				if (this.NowData.Kind == 2 && this.SelectCountTime >= 0f)
				{
					if (this.bSelectCount)
					{
						this.SelectCountTime2 -= Time.deltaTime;
						if (this.SelectCountTime2 <= 0f)
						{
							uTweenScale.Begin(this.QuestBtn2, new Vector3(1.1f, 1.1f, 1.1f), Vector3.one, 0.5f, 0f);
							this.bSelectCount = false;
							AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
						}
					}
					this.SelectCountTime -= Time.deltaTime;
					if (this.SelectCountTime <= 0f)
					{
						this.SelectCountTime = 3.5f;
						this.bSelectCount = true;
						this.SelectCountTime2 = 0.1f;
						uTweenScale.Begin(this.QuestBtn1, new Vector3(1.1f, 1.1f, 1.1f), Vector3.one, 0.5f, 0f);
						AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
					}
				}
				this.WaitTime -= Time.deltaTime;
				if (this.WaitTime <= 0f)
				{
					if (this.NowData.Kind == 2)
					{
						this.NowKey = this.NowData.TimeUpGotoID;
						AudioManager.Instance.PlayUISFX(UIKind.HeroEnhance);
					}
					else
					{
						this.NowKey += 1;
						LoadingTalk recordByKey = this.GM.LoadingTalkTable.GetRecordByKey(this.NowKey);
						while (recordByKey.ID != 0 && recordByKey.Kind >= 3)
						{
							this.NowKey += 1;
							recordByKey = this.GM.LoadingTalkTable.GetRecordByKey(this.NowKey);
						}
					}
					this.LoadByKey(this.NowKey);
				}
			}
		}
	}

	// Token: 0x06002250 RID: 8784 RVA: 0x004060DC File Offset: 0x004042DC
	public void OnButtonClick(UIButton sender)
	{
		AudioManager.Instance.PlayUISFX(UIKind.HUDMsg);
		this.NowKey = (ushort)this.NowData.Select[(sender.m_BtnID1 != 1) ? 1 : 0].GotoID;
		this.LoadByKey(this.NowKey);
	}

	// Token: 0x06002251 RID: 8785 RVA: 0x00406134 File Offset: 0x00404334
	private void LoadActor()
	{
		if (this.LoadActorIndex < 3)
		{
			if (this.LoadActorIndex == 0)
			{
				this.AB[(int)this.LoadActorIndex] = AssetManager.GetAssetBundle("Role/hero_00001", out this.AssetKey[(int)this.LoadActorIndex], false);
			}
			else if (this.LoadActorIndex == 1)
			{
				this.AB[(int)this.LoadActorIndex] = AssetManager.GetAssetBundle("Role/hero_00007", out this.AssetKey[(int)this.LoadActorIndex], false);
			}
			else if (this.LoadActorIndex == 2)
			{
				this.AB[(int)this.LoadActorIndex] = AssetManager.GetAssetBundle("Role/hero_00009", out this.AssetKey[(int)this.LoadActorIndex], false);
			}
			this.AR[(int)this.LoadActorIndex] = this.AB[(int)this.LoadActorIndex].LoadAsync("m", typeof(GameObject));
		}
		else
		{
			this.bLoadAllActor = true;
			this.LoadByKey(this.NowKey);
		}
	}

	// Token: 0x06002252 RID: 8786 RVA: 0x0040623C File Offset: 0x0040443C
	private void SetActor()
	{
		if (this.LoadActorIndex < 3 && this.AR[(int)this.LoadActorIndex].isDone)
		{
			this.ActorGO[(int)this.LoadActorIndex] = (GameObject)UnityEngine.Object.Instantiate(this.AR[(int)this.LoadActorIndex].asset);
			this.ActorGO[(int)this.LoadActorIndex].transform.SetParent(this.ActorT[(int)this.LoadActorIndex], false);
			this.ActorGO[(int)this.LoadActorIndex].transform.localPosition = Vector3.zero;
			this.ActorGO[(int)this.LoadActorIndex].transform.localRotation = new Quaternion(0f, -180f, 0f, 0f);
			this.ActorGO[(int)this.LoadActorIndex].transform.localScale = new Vector3(180f, 180f, 180f);
			GUIManager.Instance.SetLayer(this.ActorGO[(int)this.LoadActorIndex], 5);
			if (this.ActorGO[(int)this.LoadActorIndex] != null)
			{
				this.ActorAnimation[(int)this.LoadActorIndex] = this.ActorGO[(int)this.LoadActorIndex].GetComponent<Animation>();
				this.ActorAnimation[(int)this.LoadActorIndex].wrapMode = WrapMode.Loop;
				this.ActorAnimation[(int)this.LoadActorIndex].clip = this.ActorAnimation[(int)this.LoadActorIndex].GetClip("idle");
				this.ActorAnimation[(int)this.LoadActorIndex].Play("idle");
			}
			this.LoadActorIndex += 1;
			this.LoadActor();
		}
	}

	// Token: 0x06002253 RID: 8787 RVA: 0x004063EC File Offset: 0x004045EC
	private void HideQuestBtn()
	{
		this.QuestBtnRC1.localScale = Vector3.zero;
		this.QuestBtnRC2.localScale = Vector3.zero;
		this.QuestBtn1.SetActive(false);
		this.QuestBtn2.SetActive(false);
		this.SelectCountTime = -1f;
	}

	// Token: 0x06002254 RID: 8788 RVA: 0x0040643C File Offset: 0x0040463C
	private void LoadByKey(ushort Key)
	{
		this.NowData = this.GM.LoadingTalkTable.GetRecordByKey(Key);
		if (this.NowData.ID != 0)
		{
			if (this.NowType != (eLoadingTalkType)this.NowData.TalkType)
			{
				switch (this.NowType)
				{
				case eLoadingTalkType.Knight3DL:
					this.BackT.gameObject.SetActive(false);
					this.ActorT[0].gameObject.SetActive(false);
					break;
				case eLoadingTalkType.Knight3DR:
					this.BackT.gameObject.SetActive(false);
					this.ActorT[1].gameObject.SetActive(false);
					break;
				case eLoadingTalkType.Knight3Dl2DR:
					this.BackT.gameObject.SetActive(false);
					this.ActorT[0].gameObject.SetActive(false);
					break;
				case eLoadingTalkType.Priest3D:
					this.BackT.gameObject.SetActive(false);
					this.ActorT[2].gameObject.SetActive(false);
					break;
				case eLoadingTalkType.GetKnight:
				case eLoadingTalkType.GetSecond:
				case eLoadingTalkType.GetCrystal:
					this.GM.CloseLoadingTalk_TBox();
					break;
				}
				this.NowType = (eLoadingTalkType)this.NowData.TalkType;
				switch (this.NowType)
				{
				case eLoadingTalkType.Knight3DL:
					this.BackT.gameObject.SetActive(true);
					this.ActorT[0].gameObject.SetActive(true);
					break;
				case eLoadingTalkType.Knight3DR:
					this.BackT.gameObject.SetActive(true);
					this.ActorT[1].gameObject.SetActive(true);
					break;
				case eLoadingTalkType.Knight3Dl2DR:
					this.BackT.gameObject.SetActive(true);
					this.ActorT[0].gameObject.SetActive(true);
					break;
				case eLoadingTalkType.Priest3D:
					this.BackT.gameObject.SetActive(true);
					this.ActorT[2].gameObject.SetActive(true);
					break;
				case eLoadingTalkType.GetKnight:
				case eLoadingTalkType.GetSecond:
				case eLoadingTalkType.GetCrystal:
					this.GM.OpenLoadingTalk_TBox((int)((byte)this.NowType - 1), 0);
					AudioManager.Instance.PlayUISFX(UIKind.DominanceLevelup);
					break;
				}
			}
			if (this.NowType == eLoadingTalkType.GetKnight || this.NowType == eLoadingTalkType.GetSecond || this.NowType == eLoadingTalkType.GetCrystal)
			{
				this.NowTextRC.gameObject.SetActive(false);
				this.HideQuestBtn();
			}
			else
			{
				this.NowTextRC.gameObject.SetActive(false);
				switch (this.NowData.TalkType)
				{
				case 1:
				case 3:
				case 6:
					this.NowText = this.TalkTextL;
					this.NowTextRC = this.TalkTextLRC;
					break;
				case 2:
				case 4:
				case 5:
					this.NowText = this.TalkTextR;
					this.NowTextRC = this.TalkTextRRC;
					break;
				}
				this.NowType = (eLoadingTalkType)this.NowData.TalkType;
				this.NowTextRC.gameObject.SetActive(true);
				if (this.NowData.Kind == 2)
				{
					AudioManager.Instance.PlayUISFX(UIKind.BuildUp);
					this.QuestBtn1.SetActive(true);
					uTweenScale uTweenScale = uTweenScale.Begin(this.QuestBtn1, Vector3.zero, Vector3.one, 1.3f, 0f);
					if (uTweenScale)
					{
						uTweenScale.easeType = EaseType.easeOutBounce;
					}
					this.bWaitSelect = true;
					this.WaitSelectTime = 0.8f;
					this.NowText.text = this.DM.mStringTable.GetStringByID((uint)this.NowData.StringID);
					this.SelectText1.text = this.DM.mStringTable.GetStringByID((uint)this.NowData.Select[0].StringID);
					this.SelectText2.text = this.DM.mStringTable.GetStringByID((uint)this.NowData.Select[1].StringID);
					switch (this.NowData.TalkType)
					{
					case 1:
						this.NowTextRC.anchoredPosition = new Vector2(138.5f, 57.5f);
						this.QuestionRC.anchoredPosition = new Vector2(157.5f, -124.5f);
						break;
					case 3:
					case 6:
						this.NowTextRC.anchoredPosition = new Vector2(118.5f, 87.5f);
						this.QuestionRC.anchoredPosition = new Vector2(137.5f, -94.5f);
						break;
					case 4:
						this.NowTextRC.anchoredPosition = new Vector2(-116.5f, 87.5f);
						this.QuestionRC.anchoredPosition = new Vector2(-133.5f, -94.5f);
						break;
					}
				}
				else
				{
					this.HideQuestBtn();
					this.NowText.text = this.DM.mStringTable.GetStringByID((uint)this.NowData.StringID);
					switch (this.NowData.TalkType)
					{
					case 1:
						this.NowTextRC.anchoredPosition = new Vector2(143.5f, -19.5f);
						break;
					case 2:
					case 5:
						this.NowTextRC.anchoredPosition = new Vector2(-69.5f, 184.5f);
						break;
					case 3:
					case 6:
						this.NowTextRC.anchoredPosition = new Vector2(118.5f, 87.5f);
						break;
					case 4:
						this.NowTextRC.anchoredPosition = new Vector2(-116.5f, 87.5f);
						break;
					}
				}
			}
			this.WaitTime = (float)this.NowData.WaitTime;
			if ((int)Key == this.GM.LoadingTalkTable.TableCount)
			{
				this.bCheckWaitTime = false;
			}
			else
			{
				this.bCheckWaitTime = true;
			}
		}
		else
		{
			this.bCheckWaitTime = false;
		}
	}

	// Token: 0x04006B13 RID: 27411
	private const float SelectWaveTime = 3.5f;

	// Token: 0x04006B14 RID: 27412
	private const int MaxActorCount = 3;

	// Token: 0x04006B15 RID: 27413
	private DataManager DM = DataManager.Instance;

	// Token: 0x04006B16 RID: 27414
	private GUIManager GM = GUIManager.Instance;

	// Token: 0x04006B17 RID: 27415
	private Transform m_transform;

	// Token: 0x04006B18 RID: 27416
	private Transform BackT;

	// Token: 0x04006B19 RID: 27417
	private UIText TalkTextL;

	// Token: 0x04006B1A RID: 27418
	private UIText TalkTextR;

	// Token: 0x04006B1B RID: 27419
	private UIText SelectText1;

	// Token: 0x04006B1C RID: 27420
	private UIText SelectText2;

	// Token: 0x04006B1D RID: 27421
	private UIText NowText;

	// Token: 0x04006B1E RID: 27422
	private RectTransform QuestionRC;

	// Token: 0x04006B1F RID: 27423
	private RectTransform TalkTextLRC;

	// Token: 0x04006B20 RID: 27424
	private RectTransform TalkTextRRC;

	// Token: 0x04006B21 RID: 27425
	private RectTransform NowTextRC;

	// Token: 0x04006B22 RID: 27426
	private GameObject[] LightGO = new GameObject[3];

	// Token: 0x04006B23 RID: 27427
	private RectTransform QuestBtnRC1;

	// Token: 0x04006B24 RID: 27428
	private RectTransform QuestBtnRC2;

	// Token: 0x04006B25 RID: 27429
	private GameObject QuestBtn1;

	// Token: 0x04006B26 RID: 27430
	private GameObject QuestBtn2;

	// Token: 0x04006B27 RID: 27431
	private LoadingTalk NowData;

	// Token: 0x04006B28 RID: 27432
	private eLoadingTalkType NowType;

	// Token: 0x04006B29 RID: 27433
	private ushort NowKey;

	// Token: 0x04006B2A RID: 27434
	private bool bCheckWaitTime;

	// Token: 0x04006B2B RID: 27435
	private float WaitTime;

	// Token: 0x04006B2C RID: 27436
	private bool bWaitSelect;

	// Token: 0x04006B2D RID: 27437
	private float WaitSelectTime;

	// Token: 0x04006B2E RID: 27438
	private float SelectCountTime = -1f;

	// Token: 0x04006B2F RID: 27439
	private float SelectCountTime2 = -1f;

	// Token: 0x04006B30 RID: 27440
	private bool bSelectCount;

	// Token: 0x04006B31 RID: 27441
	private byte LoadActorIndex;

	// Token: 0x04006B32 RID: 27442
	private int[] AssetKey = new int[3];

	// Token: 0x04006B33 RID: 27443
	private AssetBundle[] AB = new AssetBundle[3];

	// Token: 0x04006B34 RID: 27444
	private AssetBundleRequest[] AR = new AssetBundleRequest[3];

	// Token: 0x04006B35 RID: 27445
	private GameObject[] ActorGO = new GameObject[3];

	// Token: 0x04006B36 RID: 27446
	private Animation[] ActorAnimation = new Animation[3];

	// Token: 0x04006B37 RID: 27447
	private Transform[] ActorT = new Transform[3];

	// Token: 0x04006B38 RID: 27448
	private bool bLoadAllActor;
}
