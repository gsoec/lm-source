using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005C3 RID: 1475
public class UIJailRoom : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001D2D RID: 7469 RVA: 0x00344D3C File Offset: 0x00342F3C
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		GUIManager instance = GUIManager.Instance;
		this.door = (instance.FindMenu(EGUIWindow.Door) as Door);
		for (int i = 0; i < this.tmpString.Length; i++)
		{
			this.tmpString[i] = StringManager.Instance.SpawnString(30);
		}
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		Image component = this.AGS_Form.GetChild(1).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = this.door.LoadMaterial();
		component.enabled = !GUIManager.Instance.bOpenOnIPhoneX;
		UIButton component2 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.image.sprite = this.door.LoadSprite("UI_main_close");
		component2.image.material = this.door.LoadMaterial();
		component2.m_EffectType = e_EffectType.e_Scale;
		UIText component3 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(4056u);
		component3 = this.AGS_Form.GetChild(12).GetComponent<UIText>();
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(13).GetComponent<UIText>();
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(14).GetComponent<UIText>();
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(15).GetComponent<UIText>();
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(17).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(7764u);
		component3 = this.AGS_Form.GetChild(18).GetComponent<UIText>();
		component3.font = ttffont;
		component2 = this.AGS_Form.GetChild(19).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_EffectType = e_EffectType.e_Scale;
		component3 = this.AGS_Form.GetChild(19).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(7765u);
		component2 = this.AGS_Form.GetChild(20).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_EffectType = e_EffectType.e_Scale;
		component3 = this.AGS_Form.GetChild(20).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(7763u);
		component2 = this.AGS_Form.GetChild(21).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_EffectType = e_EffectType.e_Scale;
		component3 = this.AGS_Form.GetChild(21).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(7762u);
		component2 = this.AGS_Form.GetChild(22).GetComponent<UIButton>();
		component2.m_Handler = this;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component4 = this.AGS_Form.GetChild(22).gameObject.GetComponent<RectTransform>();
			component4.localScale = new Vector3(-1f, 1f, 1f);
		}
		component2 = this.AGS_Form.GetChild(23).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_EffectType = e_EffectType.e_Scale;
		component3 = this.AGS_Form.GetChild(23).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(4535u);
		component2 = this.AGS_Form.GetChild(24).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_EffectType = e_EffectType.e_Scale;
		float x = GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x;
		float num = (GUIManager.Instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x - 853f) / 2f;
		component2 = this.AGS_Form.GetChild(27).GetComponent<UIButton>();
		component2.m_Handler = this;
		this.LBtn = component2.transform;
		if (num > 0f && this.LBtn.localPosition.x + num > x / 2f)
		{
			num = x / 2f - this.LBtn.localPosition.x;
		}
		this.MoveTime1 = this.LBtn.localPosition.x - num;
		component2 = this.AGS_Form.GetChild(28).GetComponent<UIButton>();
		component2.m_Handler = this;
		this.RBtn = component2.transform;
		this.MoveTime2 = this.RBtn.localPosition.x + num;
		this.Pos3D1 = this.AGS_Form.GetChild(5);
		this.Pos3D2 = this.AGS_Form.GetChild(6);
		Vector3 localPosition = this.Pos3D1.localPosition;
		localPosition.z = -500f;
		this.Pos3D1.localPosition = localPosition;
		localPosition = this.Pos3D2.localPosition;
		localPosition.z = -500f;
		this.Pos3D2.localPosition = localPosition;
		for (int j = 7; j < this.AGS_Form.childCount; j++)
		{
			Transform child = this.AGS_Form.GetChild(j);
			localPosition = child.localPosition;
			localPosition.z = -1000f;
			child.localPosition = localPosition;
		}
		this.PrisonStateChanged = false;
		this.LoadingStep = UIJailRoom.eModelLoadingStep.Start;
		this.SetPrisoner((byte)arg1);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001D2E RID: 7470 RVA: 0x0034535C File Offset: 0x0034355C
	public override void OnClose()
	{
		this.Destory3DObject(true);
		for (int i = 0; i < this.tmpString.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.tmpString[i]);
		}
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_JailMoney) != null)
		{
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_JailMoney);
		}
		if (this.openOkBox)
		{
			GUIManager.Instance.CloseOKCancelBox();
		}
	}

	// Token: 0x06001D2F RID: 7471 RVA: 0x003453D4 File Offset: 0x003435D4
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		this.openOkBox = false;
		if (bOK)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_RELEASE_PRISONER;
			messagePacket.AddSeqId();
			messagePacket.Add(this.DMIdx);
			messagePacket.Send(false);
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001D30 RID: 7472 RVA: 0x0034542C File Offset: 0x0034362C
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			RectTransform component = this.AGS_Form.GetChild(11).GetComponent<RectTransform>();
			long num = this.DM.PrisonerList[(int)this.DMIdx].StartActionTime + (long)((ulong)this.DM.PrisonerList[(int)this.DMIdx].TotalTime) - this.DM.ServerTime;
			if (num < 0L)
			{
				num = 0L;
			}
			UIText component2;
			switch (this.DM.PrisonerList[(int)this.DMIdx].nowStat)
			{
			case PrisonerState.WaitForRelease:
			case PrisonerState.Poisoned:
			{
				float num2 = (float)num / this.DM.PrisonerList[(int)this.DMIdx].TotalTime;
				num2 = Mathf.Clamp01(1f - num2);
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 305f);
				break;
			}
			case PrisonerState.WaitForExecute:
				this.tmpString[0].ClearString();
				if (num > 21600L)
				{
					this.tmpString[0].Append(this.DM.mStringTable.GetStringByID(7759u));
					num -= 21600L;
					float num2 = (float)num / (this.DM.PrisonerList[(int)this.DMIdx].TotalTime - 21600u);
					num2 = Mathf.Clamp01(1f - num2);
					component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 305f);
				}
				else
				{
					this.tmpString[0].Append(this.DM.mStringTable.GetStringByID(7758u));
					float num2 = (float)num / 21600f;
					num2 = Mathf.Clamp01(1f - num2);
					component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 305f);
					this.AGS_Form.GetChild(10).gameObject.SetActive(true);
					this.AGS_Form.GetChild(21).gameObject.SetActive(true);
					this.AGS_Form.GetChild(22).gameObject.SetActive(false);
					if (!this.PrisonStateChanged)
					{
						this.PrisonStateChanged = true;
						if (this.openOkBox)
						{
							GUIManager.Instance.CloseOKCancelBox();
						}
					}
				}
				component2 = this.AGS_Form.GetChild(12).GetComponent<UIText>();
				component2.text = this.tmpString[0].ToString();
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				break;
			}
			component2 = this.AGS_Form.GetChild(13).GetComponent<UIText>();
			this.tmpString[1].ClearString();
			GameConstants.GetTimeString(this.tmpString[1], (uint)num, true, true, true, false, true);
			component2.text = this.tmpString[1].ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			float preferredWidth = component2.preferredWidth;
			component2 = this.AGS_Form.GetChild(12).GetComponent<UIText>();
			component2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300f - preferredWidth);
		}
	}

	// Token: 0x06001D31 RID: 7473 RVA: 0x00345720 File Offset: 0x00343920
	public override void UpdateUI(int arg1, int arg2)
	{
		this.nowSortedIdx = JailManage.FindPrisonerSortIndex(this.DMIdx);
		this.SetPrisoner(this.nowSortedIdx);
	}

	// Token: 0x06001D32 RID: 7474 RVA: 0x00345740 File Offset: 0x00343940
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
			GUIManager.Instance.CloseOKCancelBox();
			this.door.CloseMenu(false);
			break;
		case NetworkNews.Fallout:
			this.openOkBox = false;
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
			break;
		case NetworkNews.Refresh_Asset:
			if (meg[2] == 2 && GameConstants.ConvertBytesToUInt(meg, 3) == (uint)this.NowHeroID)
			{
				this.Destory3DObject(true);
				this.Create3DObjects();
			}
			break;
		}
	}

	// Token: 0x06001D33 RID: 7475 RVA: 0x003457D4 File Offset: 0x003439D4
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			switch (sender.m_BtnID2)
			{
			case 0:
				this.door.CloseMenu(false);
				break;
			case 1:
				this.SetNext(true);
				break;
			case 2:
				this.SetNext(false);
				break;
			}
			break;
		case 1:
		{
			UIJailMoney uijailMoney = (UIJailMoney)GUIManager.Instance.OpenMenu(EGUIWindow.UI_JailMoney, 0, (int)this.DMIdx, false, true, false);
			if (this.DM.PrisonerList[(int)this.DMIdx].Ransom > 0u)
			{
				uijailMoney.SetMoney(this.DM.PrisonerList[(int)this.DMIdx].Ransom);
			}
			break;
		}
		case 2:
			this.openOkBox = true;
			GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(3971u), this.DM.mStringTable.GetStringByID(7793u), 0, 0, null, null);
			break;
		case 3:
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_EXECUTE_PRISONER;
			messagePacket.AddSeqId();
			messagePacket.Add(this.DMIdx);
			messagePacket.Send(false);
			this.door.CloseMenu(false);
			break;
		}
		case 4:
			this.DM.ShowLordProfile(this.DM.PrisonerList[(int)this.DMIdx].name.ToString());
			break;
		case 5:
			DataManager.Instance.Letter_ReplyName = this.DM.PrisonerList[(int)this.DMIdx].name.ToString();
			this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 2, 0, false);
			break;
		case 6:
			GUIManager.Instance.OpenSpendWindow_ItemID(3, this.DM.mStringTable.GetStringByID(4957u), 1314, (int)this.DMIdx, 0, null, null, null);
			this.openOkBox = true;
			break;
		}
	}

	// Token: 0x06001D34 RID: 7476 RVA: 0x003459F0 File Offset: 0x00343BF0
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(12).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(13).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(15).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(17).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(18).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(19).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(20).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(21).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(23).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
	}

	// Token: 0x06001D35 RID: 7477 RVA: 0x00345C84 File Offset: 0x00343E84
	private void SetPrisoner(byte idx)
	{
		this.nowSortedIdx = idx;
		this.DMIdx = this.DM.sortedPrisonerList[(int)this.nowSortedIdx];
		this.LBtn.gameObject.SetActive(true);
		this.RBtn.gameObject.SetActive(true);
		if (this.nowSortedIdx == 0)
		{
			this.LBtn.gameObject.SetActive(false);
		}
		if ((int)(this.nowSortedIdx + 1) == this.DM.PrisonerList.Length || this.DM.PrisonerList[(int)this.DM.sortedPrisonerList[(int)(this.nowSortedIdx + 1)]].nowStat == PrisonerState.None)
		{
			this.RBtn.gameObject.SetActive(false);
		}
		UIText component = this.AGS_Form.GetChild(12).GetComponent<UIText>();
		UISpritesArray component2 = this.AGS_Form.GetChild(11).GetComponent<UISpritesArray>();
		this.tmpString[0].ClearString();
		long num = this.DM.PrisonerList[(int)this.DMIdx].StartActionTime + (long)((ulong)this.DM.PrisonerList[(int)this.DMIdx].TotalTime) - this.DM.ServerTime;
		if (num < 0L)
		{
			num = 0L;
		}
		RectTransform component3 = this.AGS_Form.GetChild(11).GetComponent<RectTransform>();
		switch (this.DM.PrisonerList[(int)this.DMIdx].nowStat)
		{
		case PrisonerState.WaitForRelease:
		{
			this.tmpString[0].Append(this.DM.mStringTable.GetStringByID(7768u));
			component2.SetSpriteIndex(2);
			this.AGS_Form.GetChild(10).gameObject.SetActive(false);
			this.AGS_Form.GetChild(21).gameObject.SetActive(false);
			this.AGS_Form.GetChild(22).gameObject.SetActive(false);
			this.AGS_Form.GetChild(19).gameObject.SetActive(true);
			float num2 = (float)num / this.DM.PrisonerList[(int)this.DMIdx].TotalTime;
			num2 = Mathf.Clamp01(1f - num2);
			component3.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 305f);
			break;
		}
		case PrisonerState.WaitForExecute:
			if (num > 21600L)
			{
				num -= 21600L;
				this.tmpString[0].Append(this.DM.mStringTable.GetStringByID(7759u));
				component2.SetSpriteIndex(1);
				this.AGS_Form.GetChild(10).gameObject.SetActive(false);
				this.AGS_Form.GetChild(21).gameObject.SetActive(false);
				this.AGS_Form.GetChild(22).gameObject.SetActive(true);
				this.AGS_Form.GetChild(19).gameObject.SetActive(true);
				float num2 = (float)num / (this.DM.PrisonerList[(int)this.DMIdx].TotalTime - 21600u);
				num2 = Mathf.Clamp01(1f - num2);
				component3.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 305f);
			}
			else
			{
				this.tmpString[0].Append(this.DM.mStringTable.GetStringByID(7758u));
				component2.SetSpriteIndex(0);
				this.AGS_Form.GetChild(10).gameObject.SetActive(true);
				this.AGS_Form.GetChild(21).gameObject.SetActive(true);
				this.AGS_Form.GetChild(22).gameObject.SetActive(false);
				this.AGS_Form.GetChild(19).gameObject.SetActive(true);
				component2 = this.AGS_Form.GetChild(10).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(0);
				float num2 = (float)num / 21600f;
				num2 = Mathf.Clamp01(1f - num2);
				component3.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 305f);
			}
			break;
		case PrisonerState.Poisoned:
		{
			this.tmpString[0].Append(this.DM.mStringTable.GetStringByID(15008u));
			component2.SetSpriteIndex(3);
			this.AGS_Form.GetChild(10).gameObject.SetActive(true);
			this.AGS_Form.GetChild(21).gameObject.SetActive(false);
			this.AGS_Form.GetChild(22).gameObject.SetActive(true);
			this.AGS_Form.GetChild(19).gameObject.SetActive(true);
			component2 = this.AGS_Form.GetChild(10).GetComponent<UISpritesArray>();
			component2.SetSpriteIndex(1);
			float num2 = (float)num / this.DM.PrisonerList[(int)this.DMIdx].TotalTime;
			num2 = Mathf.Clamp01(1f - num2);
			component3.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 305f);
			break;
		}
		}
		component.text = this.tmpString[0].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(13).GetComponent<UIText>();
		this.tmpString[1].ClearString();
		GameConstants.GetTimeString(this.tmpString[1], (uint)num, true, true, true, false, true);
		component.text = this.tmpString[1].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(14).GetComponent<UIText>();
		this.tmpString[2].ClearString();
		this.tmpString[2].IntToFormat((long)this.DM.PrisonerList[(int)this.DMIdx].LordLevel, 1, false);
		this.tmpString[2].AppendFormat(this.DM.mStringTable.GetStringByID(7757u));
		component.text = this.tmpString[2].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(15).GetComponent<UIText>();
		this.tmpString[3].ClearString();
		GameConstants.GetNameString(this.tmpString[3], this.DM.PrisonerList[(int)this.DMIdx].KingdomID, this.DM.PrisonerList[(int)this.DMIdx].name, this.DM.PrisonerList[(int)this.DMIdx].AlliTag, false);
		component.text = this.tmpString[3].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(18).GetComponent<UIText>();
		component.gameObject.SetActive(true);
		this.AGS_Form.GetChild(16).gameObject.SetActive(true);
		this.AGS_Form.GetChild(17).gameObject.SetActive(true);
		this.tmpString[4].ClearString();
		if (this.DM.PrisonerList[(int)this.DMIdx].Ransom > 0u)
		{
			this.tmpString[4].IntToFormat((long)((ulong)this.DM.PrisonerList[(int)this.DMIdx].Ransom), 1, true);
			this.tmpString[4].AppendFormat("{0:N}");
		}
		else
		{
			this.tmpString[4].Append(this.DM.mStringTable.GetStringByID(7786u));
		}
		component.text = this.tmpString[4].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(19).GetChild(0).GetComponent<UIText>();
		if (this.DM.PrisonerList[(int)this.DMIdx].Ransom > 0u)
		{
			component.text = this.DM.mStringTable.GetStringByID(7767u);
		}
		else
		{
			component.text = this.DM.mStringTable.GetStringByID(7765u);
		}
		this.NowHeroID = this.DM.PrisonerList[(int)this.DMIdx].head;
		this.Create3DObjects();
	}

	// Token: 0x06001D36 RID: 7478 RVA: 0x003464D8 File Offset: 0x003446D8
	private void Create3DObjects()
	{
		if (this.NowHeroID == this.LastHeroID)
		{
			return;
		}
		if (this.LoadingStep > UIJailRoom.eModelLoadingStep.WaitforHero)
		{
			this.Destory3DObject(false);
		}
		if (this.LoadingStep == UIJailRoom.eModelLoadingStep.Start)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.Append("Role/cage");
			this.bundle = AssetManager.GetAssetBundle(cstring, out this.AssetKey1);
			this.bundleRequest = this.bundle.LoadAsync("m", typeof(GameObject));
			this.LoadingStep = UIJailRoom.eModelLoadingStep.WaitforCage;
			return;
		}
		this.LastHeroID = this.NowHeroID;
		this.heroData = DataManager.Instance.HeroTable.GetRecordByKey(this.NowHeroID);
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring2.IntToFormat((long)this.heroData.Modle, 5, false);
		cstring2.AppendFormat("Role/hero_{0}");
		this.bundle = AssetManager.GetAssetBundle(cstring2, out this.AssetKey2);
		if (this.bundle == null)
		{
			this.LoadingStep = UIJailRoom.eModelLoadingStep.Done;
			return;
		}
		this.bundleRequest = this.bundle.LoadAsync("m", typeof(GameObject));
		this.LoadingStep = UIJailRoom.eModelLoadingStep.WaitforHero;
	}

	// Token: 0x06001D37 RID: 7479 RVA: 0x0034660C File Offset: 0x0034480C
	private void Destory3DObject(bool ReleaseAll = true)
	{
		if (this.Holder1 != null)
		{
			UnityEngine.Object.Destroy(this.Holder1);
			this.Holder1 = null;
		}
		this.bundle = null;
		if (this.AssetKey1 != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey1, false);
		}
		this.LoadingStep = UIJailRoom.eModelLoadingStep.ReadyToLoadHero;
		if (!ReleaseAll)
		{
			return;
		}
		if (this.AssetKey2 != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey2, false);
		}
		if (this.Holder2 != null)
		{
			UnityEngine.Object.Destroy(this.Holder2);
			this.Holder2 = null;
		}
		this.LoadingStep = UIJailRoom.eModelLoadingStep.Start;
	}

	// Token: 0x06001D38 RID: 7480 RVA: 0x003466AC File Offset: 0x003448AC
	public void Update()
	{
		this.TmpTime += Time.smoothDeltaTime * 40f;
		if (this.TmpTime >= 40f)
		{
			this.TmpTime = 0f;
		}
		float num = (this.TmpTime <= 20f) ? this.TmpTime : (40f - this.TmpTime);
		if (num < 0f)
		{
			num = 0f;
		}
		this.Vec3Instance.Set(this.MoveTime1 - num, this.LBtn.localPosition.y, this.LBtn.localPosition.z);
		this.LBtn.localPosition = this.Vec3Instance;
		this.Vec3Instance.Set(this.MoveTime2 + num, this.RBtn.localPosition.y, this.RBtn.localPosition.z);
		this.RBtn.localPosition = this.Vec3Instance;
		this.GetPointTime += Time.smoothDeltaTime;
		if (this.GetPointTime >= 2f)
		{
			this.GetPointTime = 0f;
		}
		float a = (this.GetPointTime <= 1f) ? this.GetPointTime : (2f - this.GetPointTime);
		Image component = this.AGS_Form.GetChild(10).GetComponent<Image>();
		if (component.gameObject.activeInHierarchy)
		{
			component.color = new Color(1f, 1f, 1f, a);
		}
		switch (this.LoadingStep)
		{
		case UIJailRoom.eModelLoadingStep.WaitforCage:
			if (this.bundleRequest.isDone)
			{
				this.Pos3D2.gameObject.SetActive(true);
				this.Holder2 = (GameObject)UnityEngine.Object.Instantiate(this.bundleRequest.asset);
				this.Holder2.transform.SetParent(this.Pos3D2, false);
				Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
				localRotation.eulerAngles = new Vector3(0f, 6f, 0f);
				this.Holder2.transform.localRotation = localRotation;
				this.Holder2.transform.localScale = new Vector3(55f, 50f, 55f);
				this.Holder2.transform.localPosition = Vector3.zero;
				GUIManager.Instance.SetLayer(this.Holder2, 5);
				this.Holder2.GetComponentInChildren<MeshRenderer>().useLightProbes = false;
				this.LastHeroID = this.NowHeroID;
				this.heroData = DataManager.Instance.HeroTable.GetRecordByKey(this.NowHeroID);
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.ClearString();
				cstring.IntToFormat((long)this.heroData.DyingSound, 3, false);
				cstring.AppendFormat("Role/{0}");
				AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.HeroSFX, this.heroData.DyingSound, false);
				CString cstring2 = StringManager.Instance.StaticString1024();
				cstring2.IntToFormat((long)this.heroData.Modle, 5, false);
				cstring2.AppendFormat("Role/hero_{0}");
				if (!AssetManager.GetAssetBundleDownload(cstring2, AssetPath.Role, AssetType.Hero, this.heroData.Modle, false))
				{
					this.LoadingStep = UIJailRoom.eModelLoadingStep.Done;
					return;
				}
				this.bundle = AssetManager.GetAssetBundle(cstring2, out this.AssetKey2);
				if (this.bundle == null)
				{
					this.LoadingStep = UIJailRoom.eModelLoadingStep.Done;
					return;
				}
				this.bundleRequest = this.bundle.LoadAsync("m", typeof(GameObject));
				this.LoadingStep = UIJailRoom.eModelLoadingStep.WaitforHero;
			}
			break;
		case UIJailRoom.eModelLoadingStep.WaitforHero:
			if (this.bundleRequest.isDone)
			{
				this.Pos3D1.gameObject.SetActive(true);
				this.Holder1 = (GameObject)UnityEngine.Object.Instantiate(this.bundleRequest.asset);
				this.Holder1.transform.SetParent(this.Pos3D1, false);
				Quaternion localRotation2 = new Quaternion(0f, 0f, 0f, 0f);
				localRotation2.eulerAngles = new Vector3(0f, (float)this.heroData.Camera_Horizontal, 0f);
				this.Holder1.transform.localRotation = localRotation2;
				this.Holder1.transform.localScale = new Vector3((float)this.heroData.CameraScaleRate, (float)this.heroData.CameraScaleRate, (float)this.heroData.CameraScaleRate) * 0.9f;
				this.Holder1.transform.localPosition = Vector3.zero;
				GUIManager.Instance.SetLayer(this.Holder1, 5);
				Transform transform = this.Holder1.transform;
				if (transform != null)
				{
					transform.GetComponentInChildren<SkinnedMeshRenderer>().useLightProbes = false;
					transform.GetComponentInChildren<SkinnedMeshRenderer>().updateWhenOffscreen = true;
					Animation component2 = transform.GetComponent<Animation>();
					component2.cullingType = AnimationCullingType.AlwaysAnimate;
					component2.clip = component2.GetClip(AnimationUnit.ANIM_STRING[9]);
					component2[AnimationUnit.ANIM_STRING[9]].layer = 0;
					component2[AnimationUnit.ANIM_STRING[9]].wrapMode = WrapMode.Loop;
					component2.Play(AnimationUnit.ANIM_STRING[9], PlayMode.StopAll);
				}
				this.LoadingStep = UIJailRoom.eModelLoadingStep.Done;
			}
			break;
		}
	}

	// Token: 0x06001D39 RID: 7481 RVA: 0x00346C38 File Offset: 0x00344E38
	private void SetNext(bool revert = false)
	{
		this.PrisonStateChanged = false;
		if (revert)
		{
			this.SetPrisoner(this.nowSortedIdx - 1);
		}
		else
		{
			this.SetPrisoner(this.nowSortedIdx + 1);
		}
	}

	// Token: 0x04005920 RID: 22816
	private Transform AGS_Form;

	// Token: 0x04005921 RID: 22817
	private DataManager DM;

	// Token: 0x04005922 RID: 22818
	private Door door;

	// Token: 0x04005923 RID: 22819
	private CString[] tmpString = new CString[5];

	// Token: 0x04005924 RID: 22820
	private byte nowSortedIdx;

	// Token: 0x04005925 RID: 22821
	public byte DMIdx;

	// Token: 0x04005926 RID: 22822
	private ushort NowHeroID;

	// Token: 0x04005927 RID: 22823
	private ushort LastHeroID;

	// Token: 0x04005928 RID: 22824
	private Transform Pos3D1;

	// Token: 0x04005929 RID: 22825
	private Transform Pos3D2;

	// Token: 0x0400592A RID: 22826
	private Hero heroData;

	// Token: 0x0400592B RID: 22827
	private int AssetKey1;

	// Token: 0x0400592C RID: 22828
	private int AssetKey2;

	// Token: 0x0400592D RID: 22829
	private AssetBundle bundle;

	// Token: 0x0400592E RID: 22830
	private AssetBundleRequest bundleRequest;

	// Token: 0x0400592F RID: 22831
	private GameObject Holder1;

	// Token: 0x04005930 RID: 22832
	private GameObject Holder2;

	// Token: 0x04005931 RID: 22833
	private UIJailRoom.eModelLoadingStep LoadingStep;

	// Token: 0x04005932 RID: 22834
	private Transform LBtn;

	// Token: 0x04005933 RID: 22835
	private Transform RBtn;

	// Token: 0x04005934 RID: 22836
	private float TmpTime;

	// Token: 0x04005935 RID: 22837
	private Vector3 Vec3Instance;

	// Token: 0x04005936 RID: 22838
	private float MoveTime1;

	// Token: 0x04005937 RID: 22839
	private float MoveTime2;

	// Token: 0x04005938 RID: 22840
	private float GetPointTime;

	// Token: 0x04005939 RID: 22841
	private bool openOkBox;

	// Token: 0x0400593A RID: 22842
	private bool PrisonStateChanged;

	// Token: 0x020005C4 RID: 1476
	private enum e_AGS_UI_JailRoom_Editor
	{
		// Token: 0x0400593C RID: 22844
		bgPanel,
		// Token: 0x0400593D RID: 22845
		CloseDeco,
		// Token: 0x0400593E RID: 22846
		BGL,
		// Token: 0x0400593F RID: 22847
		BGR,
		// Token: 0x04005940 RID: 22848
		BGFrameTitle,
		// Token: 0x04005941 RID: 22849
		T3DObj1,
		// Token: 0x04005942 RID: 22850
		T3DObj2,
		// Token: 0x04005943 RID: 22851
		Shadow,
		// Token: 0x04005944 RID: 22852
		TitleBox,
		// Token: 0x04005945 RID: 22853
		BarBg,
		// Token: 0x04005946 RID: 22854
		BarLight,
		// Token: 0x04005947 RID: 22855
		Bar,
		// Token: 0x04005948 RID: 22856
		BarStat,
		// Token: 0x04005949 RID: 22857
		BarTime,
		// Token: 0x0400594A RID: 22858
		BarLevel,
		// Token: 0x0400594B RID: 22859
		BarName,
		// Token: 0x0400594C RID: 22860
		Banner,
		// Token: 0x0400594D RID: 22861
		BannerTitle,
		// Token: 0x0400594E RID: 22862
		BannerMoney,
		// Token: 0x0400594F RID: 22863
		SetMoney,
		// Token: 0x04005950 RID: 22864
		Release,
		// Token: 0x04005951 RID: 22865
		Execute,
		// Token: 0x04005952 RID: 22866
		SpeedExecute,
		// Token: 0x04005953 RID: 22867
		Profile,
		// Token: 0x04005954 RID: 22868
		Mail,
		// Token: 0x04005955 RID: 22869
		SideBar,
		// Token: 0x04005956 RID: 22870
		SideBar2,
		// Token: 0x04005957 RID: 22871
		LBtn,
		// Token: 0x04005958 RID: 22872
		RBtn
	}

	// Token: 0x020005C5 RID: 1477
	private enum eModelLoadingStep
	{
		// Token: 0x0400595A RID: 22874
		Start,
		// Token: 0x0400595B RID: 22875
		WaitforCage,
		// Token: 0x0400595C RID: 22876
		ReadyToLoadHero,
		// Token: 0x0400595D RID: 22877
		WaitforHero,
		// Token: 0x0400595E RID: 22878
		Done
	}
}
