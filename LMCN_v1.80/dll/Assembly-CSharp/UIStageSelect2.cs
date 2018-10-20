using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004BE RID: 1214
public class UIStageSelect2 : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
	// Token: 0x0600188B RID: 6283 RVA: 0x00294054 File Offset: 0x00292254
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.m_transform = base.transform;
		Font ttffont = this.GM.GetTTFFont();
		this.m_transform.GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(4).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(4).GetComponent<Image>().enabled = false;
		}
		this.StageName = this.m_transform.GetChild(5).GetComponent<UIText>();
		this.StageName.font = ttffont;
		Transform child = this.m_transform.GetChild(6);
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
		this.m_HelpAlertL = this.m_transform.GetChild(6).GetChild(3).GetComponent<CustomImage>();
		this.m_HelpAlertR = this.m_transform.GetChild(6).GetChild(4).GetComponent<CustomImage>();
		this.m_transform.GetChild(6).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(6).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(6).GetChild(2).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(6).GetChild(3).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(6).GetChild(4).GetComponent<CustomImage>().hander = this;
		if (this.GM.IsArabic)
		{
			this.m_HelpAlertL.gameObject.AddComponent<ArabicItemTextureRot>();
			this.m_HelpAlertR.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		CorpsStage recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey((ushort)arg1);
		this.StageName.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.StageName);
		this.GM.UpdateUI(EGUIWindow.Door, 1, 5);
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door && door.m_GroundInfo.bOpenPvePanel)
		{
			door.m_GroundInfo.OpenPvePanel(true, (ushort)arg1);
		}
		this.CheckHelpAlertState();
	}

	// Token: 0x0600188C RID: 6284 RVA: 0x00294340 File Offset: 0x00292540
	public override void OnClose()
	{
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

	// Token: 0x0600188D RID: 6285 RVA: 0x00294394 File Offset: 0x00292594
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.CheckHelpAlertState();
		}
	}

	// Token: 0x0600188E RID: 6286 RVA: 0x002943A4 File Offset: 0x002925A4
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

	// Token: 0x0600188F RID: 6287 RVA: 0x00294474 File Offset: 0x00292674
	public void CloseFunction()
	{
		DataManager.msgBuffer[0] = 4;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06001890 RID: 6288 RVA: 0x0029448C File Offset: 0x0029268C
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			this.CloseFunction();
		}
		else if (sender.m_BtnID1 == 2)
		{
			DataManager.msgBuffer[0] = 18;
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

	// Token: 0x06001891 RID: 6289 RVA: 0x00294510 File Offset: 0x00292710
	public override bool OnBackButtonClick()
	{
		this.CloseFunction();
		return true;
	}

	// Token: 0x06001892 RID: 6290 RVA: 0x0029451C File Offset: 0x0029271C
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

	// Token: 0x06001893 RID: 6291 RVA: 0x0029472C File Offset: 0x0029292C
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x04004877 RID: 18551
	private Transform m_transform;

	// Token: 0x04004878 RID: 18552
	private UIText StageName;

	// Token: 0x04004879 RID: 18553
	private DataManager DM;

	// Token: 0x0400487A RID: 18554
	private GUIManager GM;

	// Token: 0x0400487B RID: 18555
	private UIButton m_HelpAlert;

	// Token: 0x0400487C RID: 18556
	private RectTransform m_HelpAlertRC;

	// Token: 0x0400487D RID: 18557
	private UIText m_HelpAlertext;

	// Token: 0x0400487E RID: 18558
	private CString m_HelpAlertStr;

	// Token: 0x0400487F RID: 18559
	private GameObject m_HelpAlertImageGO;

	// Token: 0x04004880 RID: 18560
	private UIText m_HelpAlertext2;

	// Token: 0x04004881 RID: 18561
	private CString m_HelpAlertStr2;

	// Token: 0x04004882 RID: 18562
	private CustomImage m_HelpAlertL;

	// Token: 0x04004883 RID: 18563
	private CustomImage m_HelpAlertR;
}
