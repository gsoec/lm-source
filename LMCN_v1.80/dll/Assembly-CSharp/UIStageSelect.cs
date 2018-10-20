using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004BD RID: 1213
public class UIStageSelect : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
	// Token: 0x06001880 RID: 6272 RVA: 0x00292E80 File Offset: 0x00291080
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.m_transform = base.transform;
		Font ttffont = this.GM.GetTTFFont();
		this.tmpString = StringManager.Instance.SpawnString(30);
		this.tmpString2 = StringManager.Instance.SpawnString(30);
		DataManager.StageDataController.ReBackCurrentChapter();
		this.NFlash = this.m_transform.GetChild(1).GetChild(0).gameObject;
		this.NormalText = this.m_transform.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.NormalText.font = ttffont;
		this.NormalText.text = this.DM.mStringTable.GetStringByID(40u);
		this.EliteT = this.m_transform.GetChild(2);
		this.EFlash = this.EliteT.GetChild(0).gameObject;
		this.EliteText = this.EliteT.GetChild(1).GetComponent<UIText>();
		this.EliteText.font = ttffont;
		this.EliteText.text = this.DM.mStringTable.GetStringByID(41u);
		this.AllianceT = this.m_transform.GetChild(3);
		this.AFlash = this.AllianceT.GetChild(0).gameObject;
		this.AllianceText = this.AllianceT.GetChild(1).GetComponent<UIText>();
		this.AllianceText.font = ttffont;
		this.AllianceText.text = this.DM.mStringTable.GetStringByID(42u);
		this.Left_T = this.m_transform.GetChild(4);
		this.Right_T = this.m_transform.GetChild(5);
		this.LeftPosX = this.Left_T.localPosition.x + 20f;
		this.RightPosX = this.Right_T.localPosition.x - 20f;
		this.MoveX = 0f;
		this.m_transform.GetChild(1).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(2).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(3).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(4).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(5).GetComponent<UIButton>().m_Handler = this;
		this.m_ExitBtn = this.m_transform.GetChild(6).GetChild(0).GetComponent<UIButton>();
		this.m_ExitBtn.m_Handler = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(6).GetComponent<Image>().enabled = false;
		}
		this.NormalObj = this.m_transform.GetChild(7).gameObject;
		this.EliteObj = this.m_transform.GetChild(8).gameObject;
		this.AllianceObj1 = this.m_transform.GetChild(0).gameObject;
		this.AllianceObj2 = this.m_transform.GetChild(9).gameObject;
		this.chapName = this.m_transform.GetChild(10).GetComponent<UIText>();
		this.chapName.font = ttffont;
		this.StageName = this.m_transform.GetChild(11).GetComponent<UIText>();
		this.StageName.font = ttffont;
		Transform child = this.m_transform.GetChild(12);
		this.m_HelpAlert = child.GetComponent<UIButton>();
		this.m_HelpAlert.m_Handler = this;
		this.m_HelpAlertImageGO = child.GetChild(0).gameObject;
		this.m_HelpAlertext2 = child.GetChild(1).GetComponent<UIText>();
		this.m_HelpAlertext2.font = this.GM.GetTTFFont();
		this.m_HelpAlertStr2 = StringManager.Instance.SpawnString(30);
		child = child.GetChild(2);
		this.m_HelpAlertRC = child.GetComponent<RectTransform>();
		this.m_HelpAlertext = child.GetChild(0).GetComponent<UIText>();
		this.m_HelpAlertext.font = this.GM.GetTTFFont();
		this.m_HelpAlertStr = StringManager.Instance.SpawnString(30);
		this.m_HelpAlertL = this.m_transform.GetChild(12).GetChild(3).GetComponent<CustomImage>();
		this.m_HelpAlertR = this.m_transform.GetChild(12).GetChild(4).GetComponent<CustomImage>();
		this.m_transform.GetChild(12).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(12).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(12).GetChild(2).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(12).GetChild(3).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(12).GetChild(4).GetComponent<CustomImage>().hander = this;
		if (this.GM.IsArabic)
		{
			this.m_HelpAlertL.gameObject.AddComponent<ArabicItemTextureRot>();
			this.m_HelpAlertR.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.CheckHelpAlertState();
		this.CheckLRBtn();
		this.GM.UpdateUI(EGUIWindow.Door, 1, 5);
	}

	// Token: 0x06001881 RID: 6273 RVA: 0x002933CC File Offset: 0x002915CC
	public override void OnClose()
	{
		if (this.tmpString != null)
		{
			StringManager.Instance.DeSpawnString(this.tmpString);
			this.tmpString = null;
		}
		if (this.tmpString2 != null)
		{
			StringManager.Instance.DeSpawnString(this.tmpString2);
			this.tmpString2 = null;
		}
		if (this.m_HelpAlertStr != null)
		{
			StringManager.Instance.DeSpawnString(this.m_HelpAlertStr);
			this.m_HelpAlertStr = null;
		}
		if (this.m_HelpAlertStr2 != null)
		{
			StringManager.Instance.DeSpawnString(this.m_HelpAlertStr2);
			this.m_HelpAlertStr2 = null;
		}
	}

	// Token: 0x06001882 RID: 6274 RVA: 0x00293468 File Offset: 0x00291668
	public void CheckHelpAlertState()
	{
		if (DataManager.Instance.mHelpDataList.Count > 0)
		{
			this.m_HelpAlertStr.Length = 0;
			this.m_HelpAlertStr.IntToFormat((long)DataManager.Instance.mHelpDataList.Count, 1, false);
			this.m_HelpAlertStr.AppendFormat("{0}");
			this.m_HelpAlertext.text = this.m_HelpAlertStr.ToString();
			this.m_HelpAlertext.SetAllDirty();
			this.m_HelpAlertext.cachedTextGenerator.Invalidate();
			this.m_HelpAlertext.cachedTextGeneratorForLayout.Invalidate();
			this.m_HelpAlertRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_HelpAlertext.preferredWidth), 51f);
			this.m_HelpAlertRC.gameObject.SetActive(true);
			this.m_HelpAlert.gameObject.SetActive(true);
			if (DataManager.Instance.AllianceMoneyBonusRate > 100)
			{
				Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
				if (door != null)
				{
					int num = (int)(DataManager.Instance.AllianceMoneyBonusRate / 100 - 2);
					if (num >= 0 && num < door.m_HelpAlertSA.m_Sprites.Length)
					{
						this.m_HelpAlertL.sprite = door.m_HelpAlertSA.GetSprite(num);
					}
					else
					{
						this.m_HelpAlertL.sprite = door.m_HelpAlertSA.GetSprite(0);
					}
					this.m_HelpAlertL.gameObject.SetActive(true);
					this.m_HelpAlertR.gameObject.SetActive(true);
				}
				else
				{
					this.m_HelpAlertL.gameObject.SetActive(false);
					this.m_HelpAlertR.gameObject.SetActive(false);
				}
				this.m_HelpAlertImageGO.SetActive(true);
			}
			else
			{
				this.m_HelpAlertImageGO.SetActive(false);
				this.m_HelpAlertL.gameObject.SetActive(false);
				this.m_HelpAlertR.gameObject.SetActive(false);
			}
		}
		else
		{
			this.m_HelpAlert.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001883 RID: 6275 RVA: 0x00293678 File Offset: 0x00291878
	private void CheckLRBtn()
	{
		StageManager stageDataController = DataManager.StageDataController;
		Chapter recordByKey = stageDataController.ChapterTable.GetRecordByKey((ushort)stageDataController.currentChapterID);
		this.StageName.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.ChapterName);
		this.tmpString.Length = 0;
		this.tmpString.IntToFormat((long)stageDataController.currentChapterID, 1, false);
		this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(56u));
		this.chapName.text = this.tmpString.ToString();
		this.chapName.SetAllDirty();
		this.chapName.cachedTextGenerator.Invalidate();
		if (stageDataController.currentChapterID <= 1)
		{
			this.Left_T.gameObject.SetActive(false);
		}
		else
		{
			this.Left_T.gameObject.SetActive(true);
		}
		if (stageDataController.currentChapterID < stageDataController.ChapterID || ((int)stageDataController.ChapterID < stageDataController.ChapterTable.TableCount && stageDataController.limitRecord[(int)stageDataController._stageMode] == stageDataController.StageRecord[(int)stageDataController._stageMode]))
		{
			this.Right_T.gameObject.SetActive(true);
		}
		else
		{
			this.Right_T.gameObject.SetActive(false);
		}
		bool flag = stageDataController.StageRecord[0] >= GameConstants.StagePointNum[0] && stageDataController.StageRecord[2] > 1;
		if (flag)
		{
			this.EliteT.gameObject.SetActive(true);
		}
		else
		{
			this.EliteT.gameObject.SetActive(false);
		}
		bool flag2 = stageDataController.StageRecord[1] >= 4 * GameConstants.StagePointNum[1];
		if (flag2)
		{
			this.AllianceT.gameObject.SetActive(true);
		}
		else
		{
			this.AllianceT.gameObject.SetActive(false);
		}
		if (stageDataController._stageMode == StageMode.Lean)
		{
			this.NFlash.SetActive(false);
			this.EFlash.SetActive(true);
			this.AFlash.SetActive(false);
			this.NormalObj.SetActive(false);
			this.EliteObj.SetActive(true);
			this.AllianceObj1.SetActive(false);
			this.AllianceObj2.SetActive(false);
		}
		else if (stageDataController._stageMode == StageMode.Dare)
		{
			this.NFlash.SetActive(false);
			this.EFlash.SetActive(false);
			this.AFlash.SetActive(true);
			this.NormalObj.SetActive(false);
			this.EliteObj.SetActive(false);
			this.AllianceObj1.SetActive(true);
			this.AllianceObj2.SetActive(true);
		}
		else
		{
			if (flag || flag2)
			{
				this.NFlash.SetActive(true);
			}
			this.EFlash.SetActive(false);
			this.AFlash.SetActive(false);
			this.NormalObj.SetActive(true);
			this.EliteObj.SetActive(false);
			this.AllianceObj1.SetActive(false);
			this.AllianceObj2.SetActive(false);
		}
	}

	// Token: 0x06001884 RID: 6276 RVA: 0x0029398C File Offset: 0x00291B8C
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.CheckHelpAlertState();
		}
		else
		{
			this.CheckLRBtn();
			DataManager.StageDataController.SaveUserStageMode(DataManager.StageDataController._stageMode);
		}
	}

	// Token: 0x06001885 RID: 6277 RVA: 0x002939C8 File Offset: 0x00291BC8
	private void Update()
	{
		if (this.Left_T == null)
		{
			return;
		}
		this.MoveX += Time.smoothDeltaTime * 40f;
		if (this.MoveX >= 40f)
		{
			this.MoveX = 0f;
		}
		float num = (this.MoveX <= 20f) ? this.MoveX : (40f - this.MoveX);
		if (num < 0f)
		{
			num = 0f;
		}
		this.BtnPos.Set(this.LeftPosX - num, this.Left_T.localPosition.y, this.Left_T.localPosition.z);
		this.Left_T.localPosition = this.BtnPos;
		this.BtnPos.Set(this.RightPosX + num, this.Right_T.localPosition.y, this.Right_T.localPosition.z);
		this.Right_T.localPosition = this.BtnPos;
	}

	// Token: 0x06001886 RID: 6278 RVA: 0x00293AE8 File Offset: 0x00291CE8
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			if (this.StageName != null && this.StageName.enabled)
			{
				this.StageName.enabled = false;
				this.StageName.enabled = true;
			}
			if (this.NormalText != null && this.NormalText.enabled)
			{
				this.NormalText.enabled = false;
				this.NormalText.enabled = true;
			}
			if (this.EliteText != null && this.EliteText.enabled)
			{
				this.EliteText.enabled = false;
				this.EliteText.enabled = true;
			}
			if (this.AllianceText != null && this.AllianceText.enabled)
			{
				this.AllianceText.enabled = false;
				this.AllianceText.enabled = true;
			}
			if (this.chapName != null && this.chapName.enabled)
			{
				this.chapName.enabled = false;
				this.chapName.enabled = true;
			}
			if (this.m_HelpAlertext != null && this.m_HelpAlertext.enabled)
			{
				this.m_HelpAlertext.enabled = false;
				this.m_HelpAlertext.enabled = true;
			}
			if (this.m_HelpAlertext2 != null && this.m_HelpAlertext2.enabled)
			{
				this.m_HelpAlertext2.enabled = false;
				this.m_HelpAlertext2.enabled = true;
			}
		}
	}

	// Token: 0x06001887 RID: 6279 RVA: 0x00293C9C File Offset: 0x00291E9C
	public void OnButtonClick(UIButton sender)
	{
		StageManager stageDataController = DataManager.StageDataController;
		if (sender.m_BtnID1 == 1)
		{
			if (sender.m_BtnID2 == 1)
			{
				if (stageDataController._stageMode == StageMode.Full)
				{
					return;
				}
				this.NFlash.SetActive(true);
				this.EFlash.SetActive(false);
				this.AFlash.SetActive(false);
				this.GM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeStage);
			}
			else if (sender.m_BtnID2 == 2)
			{
				if (stageDataController._stageMode == StageMode.Lean)
				{
					return;
				}
				this.NFlash.SetActive(false);
				this.EFlash.SetActive(true);
				this.AFlash.SetActive(false);
				this.GM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeStage);
			}
			else if (sender.m_BtnID2 == 3)
			{
				if (stageDataController._stageMode == StageMode.Dare)
				{
					return;
				}
				this.NFlash.SetActive(false);
				this.EFlash.SetActive(false);
				this.AFlash.SetActive(true);
				this.GM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeStage);
			}
		}
		else if (sender.m_BtnID1 == 2)
		{
			if (sender.m_BtnID2 == 1)
			{
				this.GM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.PrevStage);
			}
			else if (sender.m_BtnID2 == 2)
			{
				if (stageDataController.currentChapterID >= stageDataController.ChapterID && stageDataController.StageRecord[(int)stageDataController._stageMode] >= stageDataController.limitRecord[(int)stageDataController._stageMode])
				{
					if (stageDataController._stageMode == StageMode.Full && stageDataController.StageRecord[0] >= stageDataController.StageRecord[2] * GameConstants.StagePointNum[0])
					{
						this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(668u), 255, true);
					}
					else if (stageDataController._stageMode == StageMode.Lean && stageDataController.StageRecord[1] * GameConstants.LinePointNum[0] >= stageDataController.StageRecord[0])
					{
						this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1593u), 255, true);
					}
					else if (stageDataController._stageMode == StageMode.Dare && stageDataController.StageRecord[3] >= stageDataController.StageRecord[1] / GameConstants.StagePointNum[1] * GameConstants.StagePointNum[3])
					{
						this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1035u), 255, true);
					}
					else
					{
						this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8597u), 255, true);
					}
				}
				else
				{
					this.GM.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.NextStage);
				}
			}
		}
		else if (sender.m_BtnID1 == 3)
		{
			NewbieManager.CheckRemovePressXFlag();
			DataManager.StageDataController.SaveUserStageMode(DataManager.StageDataController._stageMode);
			DataManager.msgBuffer[0] = 4;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
		else if (sender.m_BtnID1 == 23)
		{
			Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.OpenMenu(EGUIWindow.UI_Alliance_HelpSpeedup, 0, 0, false);
			}
		}
	}

	// Token: 0x06001888 RID: 6280 RVA: 0x00293FDC File Offset: 0x002921DC
	public override bool OnBackButtonClick()
	{
		DataManager.StageDataController.SaveUserStageMode(DataManager.StageDataController._stageMode);
		DataManager.msgBuffer[0] = 4;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		return true;
	}

	// Token: 0x06001889 RID: 6281 RVA: 0x00294008 File Offset: 0x00292208
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x04004854 RID: 18516
	private Transform m_transform;

	// Token: 0x04004855 RID: 18517
	private Transform Left_T;

	// Token: 0x04004856 RID: 18518
	private Transform Right_T;

	// Token: 0x04004857 RID: 18519
	private Transform EliteT;

	// Token: 0x04004858 RID: 18520
	private Transform AllianceT;

	// Token: 0x04004859 RID: 18521
	private UIText StageName;

	// Token: 0x0400485A RID: 18522
	private UIText NormalText;

	// Token: 0x0400485B RID: 18523
	private UIText EliteText;

	// Token: 0x0400485C RID: 18524
	private UIText AllianceText;

	// Token: 0x0400485D RID: 18525
	private UIText chapName;

	// Token: 0x0400485E RID: 18526
	public GameObject NormalObj;

	// Token: 0x0400485F RID: 18527
	public GameObject EliteObj;

	// Token: 0x04004860 RID: 18528
	public GameObject AllianceObj1;

	// Token: 0x04004861 RID: 18529
	public GameObject AllianceObj2;

	// Token: 0x04004862 RID: 18530
	public GameObject NFlash;

	// Token: 0x04004863 RID: 18531
	public GameObject EFlash;

	// Token: 0x04004864 RID: 18532
	public GameObject AFlash;

	// Token: 0x04004865 RID: 18533
	private DataManager DM;

	// Token: 0x04004866 RID: 18534
	private GUIManager GM;

	// Token: 0x04004867 RID: 18535
	private CString tmpString;

	// Token: 0x04004868 RID: 18536
	private CString tmpString2;

	// Token: 0x04004869 RID: 18537
	private Vector3 BtnPos;

	// Token: 0x0400486A RID: 18538
	private float MoveX;

	// Token: 0x0400486B RID: 18539
	private float LeftPosX;

	// Token: 0x0400486C RID: 18540
	private float RightPosX;

	// Token: 0x0400486D RID: 18541
	private UIButton m_HelpAlert;

	// Token: 0x0400486E RID: 18542
	private RectTransform m_HelpAlertRC;

	// Token: 0x0400486F RID: 18543
	private UIText m_HelpAlertext;

	// Token: 0x04004870 RID: 18544
	private CString m_HelpAlertStr;

	// Token: 0x04004871 RID: 18545
	private GameObject m_HelpAlertImageGO;

	// Token: 0x04004872 RID: 18546
	private UIText m_HelpAlertext2;

	// Token: 0x04004873 RID: 18547
	private CString m_HelpAlertStr2;

	// Token: 0x04004874 RID: 18548
	private CustomImage m_HelpAlertL;

	// Token: 0x04004875 RID: 18549
	private CustomImage m_HelpAlertR;

	// Token: 0x04004876 RID: 18550
	public UIButton m_ExitBtn;
}
