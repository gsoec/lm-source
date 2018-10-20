using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002BD RID: 701
public class AllianceHint : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06000E3A RID: 3642 RVA: 0x00174FE4 File Offset: 0x001731E4
	public override void OnOpen(int arg1, int arg2)
	{
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			RectTransform rectTransform = (RectTransform)base.transform;
			Vector2 vector = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)base.transform.GetChild(2)).offsetMin = vector;
			rectTransform.offsetMin = vector;
			RectTransform rectTransform2 = (RectTransform)base.transform;
			vector = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)base.transform.GetChild(2)).offsetMax = vector;
			rectTransform2.offsetMax = vector;
		}
		for (int i = 0; i < 7; i++)
		{
			this.ItemTag[i] = new Text[6];
		}
		UIButton component = base.transform.GetChild(0).GetChild(6).GetComponent<UIButton>();
		component.m_Handler = this;
		component = base.transform.GetChild(0).GetChild(8).GetComponent<UIButton>();
		component.m_Handler = this;
		component = base.transform.GetChild(0).GetChild(12).GetComponent<UIButton>();
		component.m_Handler = this;
		this.m_label[0] = base.transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<Text>();
		this.m_label[0].text = this.DM.mStringTable.GetStringByID(4609u);
		this.m_label[0].font = this.Font;
		this.m_label[1] = base.transform.GetChild(0).GetChild(7).GetChild(0).GetComponent<Text>();
		this.m_label[1].text = this.DM.mStringTable.GetStringByID((!this.DM.CheckPrizeFlag(0)) ? 746u : 4602u);
		this.m_label[1].font = this.Font;
		this.m_label[2] = base.transform.GetChild(0).GetChild(8).GetChild(0).GetComponent<Text>();
		this.m_label[2].text = this.DM.mStringTable.GetStringByID(4610u);
		this.m_label[2].font = this.Font;
		this.m_label[3] = base.transform.GetChild(0).GetChild(10).GetComponent<Text>();
		this.m_label[3].text = this.DM.mStringTable.GetStringByID(4601u);
		this.m_label[3].font = this.Font;
		this.m_label[4] = base.transform.GetChild(0).GetChild(13).GetChild(0).GetComponent<Text>();
		this.m_label[4].text = this.DM.mStringTable.GetStringByID(746u);
		this.m_label[4].font = this.Font;
		this.m_label[5] = base.transform.GetChild(0).GetChild(13).GetChild(1).GetComponent<Text>();
		this.m_label[5].text = this.DM.mStringTable.GetStringByID(4604u);
		this.m_label[5].font = this.Font;
		this.m_label[6] = base.transform.GetChild(0).GetChild(13).GetChild(2).GetComponent<Text>();
		this.m_label[6].text = this.DM.mStringTable.GetStringByID(4605u);
		this.m_label[6].font = this.Font;
		this.m_label[7] = base.transform.GetChild(0).GetChild(13).GetChild(3).GetComponent<Text>();
		this.m_label[7].text = this.DM.mStringTable.GetStringByID(4606u);
		this.m_label[7].font = this.Font;
		this.m_label[8] = base.transform.GetChild(0).GetChild(13).GetChild(4).GetComponent<Text>();
		this.m_label[8].text = this.DM.mStringTable.GetStringByID(4607u);
		this.m_label[8].font = this.Font;
		this.m_label[9] = base.transform.GetChild(0).GetChild(13).GetChild(5).GetComponent<Text>();
		this.m_label[9].text = this.DM.mStringTable.GetStringByID(4608u);
		this.m_label[9].font = this.Font;
		float num = 0f;
		for (ushort num2 = 4; num2 <= 8; num2 += 1)
		{
			if (this.DM.CheckPrizeFlag(0) && num2 == 4)
			{
				base.transform.GetChild(0).GetChild(13).GetChild(0).gameObject.SetActive(false);
				base.transform.GetChild(0).GetChild(13).GetChild(6).gameObject.SetActive(false);
				base.transform.GetChild(0).GetChild(13).localPosition -= new Vector3(0f, 8f, 0f);
			}
			else
			{
				this.SearchPosition = new Vector3(0f, (float)((this.m_label[(int)num2].preferredHeight <= 32f) ? 32 : ((int)Math.Ceiling((double)(this.m_label[(int)num2].preferredHeight / 32f)) * 32)), 0f);
				num += this.SearchPosition.y - 32f;
			}
			this.m_label[(int)(num2 + 1)].transform.localPosition = this.m_label[(int)num2].transform.localPosition - this.SearchPosition;
			base.transform.GetChild(0).GetChild(13).GetChild((int)(num2 + 3)).localPosition = base.transform.GetChild(0).GetChild(13).GetChild((int)(num2 + 2)).localPosition - this.SearchPosition;
		}
		this.SearchPosition = new Vector3(0f, num / 2f, 0f);
		base.transform.GetChild(0).GetChild(6).localPosition -= this.SearchPosition;
		base.transform.GetChild(0).GetChild(8).localPosition -= this.SearchPosition;
		base.transform.GetChild(0).GetChild(12).localPosition += this.SearchPosition;
		this.Join = (RectTransform)base.transform.GetChild(0);
		this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.Join.sizeDelta.y + num);
		this.Join = (RectTransform)base.transform.GetChild(0).GetChild(0);
		this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.Join.sizeDelta.y + num);
		this.Join = base.transform.GetChild(1).GetChild(8).GetComponent<RectTransform>();
		this.ApplyList = base.transform.GetChild(1).GetChild(10).GetComponent<RectTransform>();
		this.SearchList = base.transform.GetChild(1).GetChild(8).GetComponent<RectTransform>();
		this.SearchSize = this.SearchList.sizeDelta;
		this.SearchPosition = this.SearchList.localPosition;
		this.Join.sizeDelta = this.ApplyList.sizeDelta;
		this.Join.localPosition = this.ApplyList.localPosition;
		this.USArray = base.transform.GetComponent<UISpritesArray>();
		GUIManager.Instance.InitBadgeTotem(base.transform.GetChild(1).GetChild(9).GetChild(2).GetChild(1), 0);
		this.s_input = base.transform.GetChild(1).GetChild(3).GetChild(15).GetComponent<UIEmojiInput>();
		this.m_default[0] = base.transform.GetChild(1).GetChild(3).GetChild(17).GetChild(1).GetComponent<Text>();
		this.m_default[0].text = this.DM.mStringTable.GetStringByID(794u);
		this.m_default[0].font = GUIManager.Instance.GetTTFFont();
		this.m_default[1] = this.s_input.placeholder.GetComponent<Text>();
		this.m_default[1].text = this.DM.mStringTable.GetStringByID(793u);
		this.m_default[1].font = GUIManager.Instance.GetTTFFont();
		this.m_default[2] = base.transform.GetChild(1).GetChild(11).GetChild(0).GetComponent<Text>();
		this.m_default[2].text = this.DM.mStringTable.GetStringByID(4725u);
		this.m_default[2].font = GUIManager.Instance.GetTTFFont();
		base.transform.GetChild(1).GetChild(5).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		if (this.DM.RoleAlliance.ApplyList == null)
		{
			this.DM.RoleAlliance.ApplyList = new uint[10];
		}
		if (AllianceHint.Search == null)
		{
			AllianceHint.Search = new AllianceSearch[101];
		}
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		Image component2 = base.transform.GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_black");
		component2.material = this.door.LoadMaterial();
		if (this.DM.SetSelectRequest == 0)
		{
			AllianceHint.SearchLang = (AllianceHint.SearchName = (AllianceHint.SeekName = (AllianceHint.FilterName = (AllianceHint.ValidName = (AllianceHint.ValidTag = string.Empty)))));
			this.DM.SetSelectLanguage = (int)(this.DM.CurSelectLanguage = (AllianceHint.GenuineLang = (AllianceHint.GenuineName = (AllianceHint.GenuineTag = (AllianceHint.FilterIdx = (AllianceHint.SetRequest = 0))))));
			this.DM.CurSelectBadge = (ushort)(UnityEngine.Random.Range(1, 64) - 1 << 6 | (UnityEngine.Random.Range(0, 7) << 3 | UnityEngine.Random.Range(0, 7)));
			AllianceHint.GenuineLang = (AllianceHint.SeekLang = this.DM.GetUserLanguageID());
			if (arg1 == 0)
			{
				this.RequestApplyList();
			}
			AllianceHint.Clearing = false;
			AllianceHint.Shooting = false;
			AllianceHint.Positioning = -1;
			AllianceHint.SeekKind = byte.MaxValue;
			AllianceHint.Scrolling = (AllianceHint.CheckTime = 0f);
			this.door.UpdateUI(1, 1);
			if (DataManager.Instance.RoleAlliance.Apply > 0)
			{
				this.door.UpdateUI(1, 2);
				this.UpdateUI(13, 0);
			}
		}
		else if (DataManager.Instance.SetSelectLanguage > 0 || DataManager.Instance.SetSelectRequest > 0 || AllianceHint.SetRequest > 0)
		{
			if (DataManager.Instance.SetSelectLanguage == 1)
			{
				if (DataManager.Instance.SetSelectRequest == 41)
				{
					this.SetFilterName(AllianceHint.FilterIdx = DataManager.Instance.CurSelectLanguage);
				}
				else
				{
					AllianceHint.GenuineLang = DataManager.Instance.CurSelectLanguage;
				}
				DataManager.Instance.SetSelectLanguage = 0;
			}
			this.door.UpdateUI(1, 2);
			this.UpdateUI((int)AllianceHint.SetRequest, 0);
			if (AllianceHint.SetRequest > 0)
			{
				arg1 = 0;
			}
		}
		this.m_search = base.transform.GetChild(1).GetChild(3).GetChild(4).GetChild(2).GetComponent<Text>();
		this.m_search.font = GUIManager.Instance.GetTTFFont();
		this.m_search.text = AllianceHint.SearchName;
		this.m_filter = base.transform.GetChild(1).GetChild(3).GetChild(5).GetChild(1).GetComponent<Text>();
		this.m_filter.font = GUIManager.Instance.GetTTFFont();
		this.m_filter.text = AllianceHint.SearchLang;
		this.m_limit = base.transform.GetChild(2).GetChild(0).GetChild(12).GetComponent<Text>();
		this.m_limit.font = GUIManager.Instance.GetTTFFont();
		base.transform.GetChild(2).GetChild(0).GetChild(4).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4715u);
		base.transform.GetChild(2).GetChild(0).GetChild(4).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
		base.transform.GetChild(2).GetChild(0).GetChild(5).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
		base.transform.GetChild(2).GetChild(0).GetChild(7).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
		base.transform.GetChild(2).GetChild(0).GetChild(8).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
		base.transform.GetChild(1).GetChild(4).GetChild(29).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(4).GetChild(30).GetComponent<UIButton>().m_Handler = this;
		this.m_label[10] = base.transform.GetChild(2).GetChild(0).GetChild(7).GetChild(0).GetComponent<Text>();
		this.m_title = base.transform.GetChild(2).GetChild(0).GetChild(8).GetComponent<Text>();
		this.m_input = base.transform.GetChild(2).GetChild(0).GetChild(5).GetChild(0).GetComponent<UIEmojiInput>();
		this.m_input.onValueChange.AddListener(delegate(string input)
		{
			this.ValueChange(input);
		});
		this.s_input.onValueChange.AddListener(delegate(string input)
		{
			AllianceHint.SearchChange(input);
		});
		this.s_input.characterLimit = 20;
		this.m_error = base.transform.GetChild(2).GetChild(0).GetChild(9).GetChild(0).GetComponent<Text>();
		this.m_error.font = GUIManager.Instance.GetTTFFont();
		this.m_button = base.transform.GetChild(2).GetChild(0).GetChild(4).GetChild(0).GetComponent<Text>();
		this.m_button.font = GUIManager.Instance.GetTTFFont();
		this.m_button.text = this.DM.mStringTable.GetStringByID(4715u);
		this.m_content = base.transform.GetChild(2).GetChild(0).GetChild(5).GetChild(1).GetComponent<Text>();
		this.m_content.font = GUIManager.Instance.GetTTFFont();
		this.m_descript = base.transform.GetChild(2).GetChild(0).GetChild(13).GetComponent<Text>();
		this.m_descript.font = GUIManager.Instance.GetTTFFont();
		this.Invalid = base.transform.GetChild(2).GetChild(0).GetChild(9);
		this.Tick = base.transform.GetChild(2).GetChild(0).GetChild(10);
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		for (int j = 0; j < 10; j++)
		{
			this.m_label[j].enabled = false;
			this.m_label[j].enabled = true;
		}
		if (GUIManager.Instance.IsArabic)
		{
			this.Tick.gameObject.AddComponent<ArabicItemTextureRot>();
			base.transform.GetChild(1).GetChild(4).GetChild(27).gameObject.AddComponent<ArabicItemTextureRot>();
			base.transform.GetChild(1).GetChild(4).GetChild(28).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		if (arg1 > 0)
		{
			this.UpdateUI(arg1, 0);
			this.door.UpdateUI(1, 2);
		}
	}

	// Token: 0x06000E3B RID: 3643 RVA: 0x0017611C File Offset: 0x0017431C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		this.ItemTag[panelObjectIdx][0] = item.transform.GetChild(2).GetChild(9).GetComponent<Text>();
		this.ItemTag[panelObjectIdx][0].font = this.Font;
		this.ItemTag[panelObjectIdx][0].text = "[" + AllianceHint.Search[dataIdx].Tag + "]  " + AllianceHint.Search[dataIdx].Name;
		this.ItemTag[panelObjectIdx][1] = item.transform.GetChild(2).GetChild(11).GetComponent<Text>();
		this.ItemTag[panelObjectIdx][1].font = this.Font;
		this.Path.Length = 0;
		this.ItemTag[panelObjectIdx][1].text = AllianceHint.Search[dataIdx].Power.ToString("N0");
		this.ItemTag[panelObjectIdx][2] = item.transform.GetChild(2).GetChild(12).GetComponent<Text>();
		this.ItemTag[panelObjectIdx][2].font = this.Font;
		this.Path.Length = 0;
		this.ItemTag[panelObjectIdx][2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4723u), AllianceHint.Search[dataIdx].GiftLv).ToString();
		this.ItemTag[panelObjectIdx][3] = item.transform.GetChild(2).GetChild(13).GetComponent<Text>();
		this.ItemTag[panelObjectIdx][3].font = this.Font;
		this.Path.Length = 0;
		this.ItemTag[panelObjectIdx][3].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(795u), AllianceHint.Search[dataIdx].Member).ToString();
		this.ItemTag[panelObjectIdx][4] = item.transform.GetChild(2).GetChild(14).GetComponent<Text>();
		this.ItemTag[panelObjectIdx][4].font = this.Font;
		this.ItemTag[panelObjectIdx][4].text = DataManager.Instance.GetLanguageStr(AllianceHint.Search[dataIdx].Language);
		this.Transformer = item.transform.GetChild(2).GetChild(1);
		ushort emblem = AllianceHint.Search[dataIdx].Emblem;
		int num = (int)(emblem & 7);
		int num2 = emblem >> 3 & 7;
		int num3 = num2 * 8 + num + 1;
		if (num3 > 64)
		{
			num3 = 64;
		}
		int num4 = (emblem >> 6 & 63) + 1;
		if (num4 > 64)
		{
			num4 = 64;
		}
		GUIManager.Instance.SetBadgeTotemImg(this.Transformer, num3, num4);
		UIButton component = item.transform.GetChild(2).GetChild(7).GetComponent<UIButton>();
		component.m_BtnID1 = dataIdx;
		component.m_BtnID2 = 1;
		component.m_Handler = this;
		component = item.transform.GetChild(2).GetChild(8).GetComponent<UIButton>();
		component.m_BtnID1 = dataIdx;
		component.m_BtnID2 = 2;
		component.m_Handler = this;
		this.ItemTag[panelObjectIdx][5] = component.transform.GetChild(0).GetComponent<Text>();
		if (AllianceHint.SetRequest == 13)
		{
			component.transform.GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4724u);
			component.image.sprite = this.USArray.GetSprite(0);
		}
		else
		{
			if (AllianceHint.Search[dataIdx].Approval > 0)
			{
				component.transform.GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4707u);
			}
			else
			{
				component.transform.GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4706u);
			}
			component.image.sprite = this.USArray.GetSprite((AllianceHint.Search[dataIdx].Approval <= 0) ? 0 : 1);
			AllianceHint.Search[100].ID = 0u;
			while (AllianceHint.Search[100].ID < (uint)this.DM.RoleAlliance.Apply && this.DM.RoleAlliance.ApplyList != null)
			{
				if (this.DM.RoleAlliance.ApplyList[(int)((UIntPtr)AllianceHint.Search[100].ID)] == AllianceHint.Search[dataIdx].ID)
				{
					component.transform.GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4708u);
					component.image.sprite = this.USArray.GetSprite(2);
				}
				AllianceSearch[] search = AllianceHint.Search;
				int num5 = 100;
				search[num5].ID = search[num5].ID + 1u;
			}
		}
		if (!this.m_panel[panelObjectIdx])
		{
			this.m_panel[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			item.transform.GetChild(3).GetChild(7).GetComponent<Text>().font = this.Font;
			component.transform.GetChild(0).GetComponent<Text>().font = this.Font;
		}
		item.transform.GetChild(2).gameObject.SetActive(AllianceHint.Search[dataIdx].ID > 0u);
		item.transform.GetChild(3).gameObject.SetActive(AllianceHint.Search[dataIdx].ID == 0u);
		if (AllianceHint.Proceeding == 1L && AllianceHint.Pending == 0L && AllianceHint.Search[dataIdx].ID == 0u)
		{
			this.UpdateUI(22, 0);
		}
	}

	// Token: 0x06000E3C RID: 3644 RVA: 0x00176738 File Offset: 0x00174938
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06000E3D RID: 3645 RVA: 0x0017673C File Offset: 0x0017493C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK && arg1 < AllianceHint.SearchNum)
		{
			this.RevokeApplyList(AllianceHint.Search[arg1].ID);
		}
	}

	// Token: 0x06000E3E RID: 3646 RVA: 0x00176768 File Offset: 0x00174968
	private void SetFilterName(byte Filter)
	{
		AllianceHint.FilterIdx = Filter;
		base.transform.GetChild(1).GetChild(3).GetChild(17).GetChild(1).gameObject.SetActive(Filter == 0);
		base.transform.GetChild(1).GetChild(3).GetChild(20).gameObject.SetActive(AllianceHint.FilterIdx > 0);
		if (AllianceHint.FilterIdx > 0)
		{
			base.transform.GetChild(1).GetChild(3).GetChild(17).GetChild(0).GetComponent<Text>().text = this.DM.GetLanguageStr(Filter);
		}
		else
		{
			base.transform.GetChild(1).GetChild(3).GetChild(17).GetChild(0).GetComponent<Text>().text = string.Empty;
		}
	}

	// Token: 0x06000E3F RID: 3647 RVA: 0x00176848 File Offset: 0x00174A48
	private static void SearchChange(string input)
	{
		AllianceHint.FilterName = input;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceHint, 15, 0);
	}

	// Token: 0x06000E40 RID: 3648 RVA: 0x00176860 File Offset: 0x00174A60
	private void ValueChange(string input)
	{
		if (input != string.Empty)
		{
			AllianceHint.ValueChanged();
		}
		this.SetLimit(input);
	}

	// Token: 0x06000E41 RID: 3649 RVA: 0x00176880 File Offset: 0x00174A80
	public void RevokeApplyList(uint revoke)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		GUIManager.Instance.ShowUILock(EUILock.AllianceCreate);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_USER_CANCELAPPLY;
		messagePacket.AddSeqId();
		messagePacket.Add(revoke);
		messagePacket.Send(false);
	}

	// Token: 0x06000E42 RID: 3650 RVA: 0x001768C8 File Offset: 0x00174AC8
	public void RequestApplyList()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_APPLYALLIANCELIST;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06000E43 RID: 3651 RVA: 0x001768FC File Offset: 0x00174AFC
	public override void OnClose()
	{
		this.m_input.onValueChange.RemoveAllListeners();
		this.s_input.onValueChange.RemoveAllListeners();
		if (this.m_scroll)
		{
			AllianceHint.Scrolling = this.SearchRT.anchoredPosition.y;
			AllianceHint.Positioning = this.m_scroll.GetTopIdx();
		}
		this.door = null;
	}

	// Token: 0x06000E44 RID: 3652 RVA: 0x00176968 File Offset: 0x00174B68
	public override void UpdateUI(int arg1, int arg2)
	{
		if (AllianceHint.Search == null)
		{
			return;
		}
		if (arg2 > 2)
		{
			if ((arg2 > 3 && (this.NameTick.gameObject.activeInHierarchy || this.NameInvalid.gameObject.activeInHierarchy || this.DM.SetSelectRequest > 0)) || arg2 == 3)
			{
				if (AllianceHint.GenuineName > 0)
				{
					this.NameInvalid.gameObject.SetActive(true);
					this.NameTick.gameObject.SetActive(false);
				}
				else if (AllianceHint.ValidName != string.Empty)
				{
					this.NameTick.gameObject.SetActive(true);
				}
			}
			if ((arg2 > 3 && (this.TagTick.gameObject.activeInHierarchy || this.TagInvalid.gameObject.activeInHierarchy || this.DM.SetSelectRequest > 0)) || arg2 == 3)
			{
				if (AllianceHint.GenuineTag > 0)
				{
					this.TagInvalid.gameObject.SetActive(true);
					this.TagTick.gameObject.SetActive(false);
				}
				else if (AllianceHint.ValidTag != string.Empty)
				{
					this.TagTick.gameObject.SetActive(true);
				}
			}
		}
		else if (arg2 > 1)
		{
			this.Tick.gameObject.SetActive(arg1 < 1);
			this.Invalid.gameObject.SetActive(arg1 > 0);
			this.m_error.text = this.DM.mStringTable.GetStringByID((uint)(arg1 + ((this.DM.SetSelectRequest != 7) ? 435 : 433)));
			this.m_button.color = ((arg1 <= 0) ? Color.white : this.m_error.color);
			if (!base.transform.GetChild(2).gameObject.activeInHierarchy)
			{
				this.UpdateUI(0, 3);
			}
		}
		else if (arg2 > 0 && arg1 > 0)
		{
			if (arg1 < 6)
			{
				this.CheckAll();
			}
			if (arg1 == 5)
			{
				GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(5811u), 255, true);
			}
			else if (arg1 > 13)
			{
				GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(1049u), 255, true);
			}
			else if (arg1 == 13)
			{
				GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(15016u), 255, true);
			}
			else if (arg1 == 12)
			{
				GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9583u), 255, true);
			}
			else if (arg1 < 9)
			{
				GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID((uint)(arg1 + 433)), 255, true);
			}
		}
		if (arg2 > 0)
		{
			return;
		}
		if (arg1 > 10 & arg1 < 14)
		{
			if (GUIManager.Instance.bOpenOnIPhoneX)
			{
				base.transform.GetChild(1).GetChild(5).GetComponent<Image>().enabled = false;
			}
			RectTransform rectTransform = (RectTransform)base.transform;
			Vector2 zero = Vector2.zero;
			((RectTransform)base.transform).offsetMax = zero;
			rectTransform.offsetMin = zero;
		}
		switch (arg1)
		{
		case 0:
		case 1:
		case 5:
		case 6:
		case 7:
		case 8:
		{
			this.Transformer = base.transform.GetChild(1);
			this.Transformer.GetChild(4).GetChild(15).GetComponent<UIButton>().m_Handler = this;
			this.Name = this.Transformer.GetChild(4).GetChild(15).GetChild(0).GetComponent<Text>();
			this.Name.font = GUIManager.Instance.GetTTFFont();
			this.Name.text = ((!(AllianceHint.ValidName != string.Empty)) ? this.DM.mStringTable.GetStringByID(4613u) : AllianceHint.ValidName);
			this.Name.color = ((!(AllianceHint.ValidName != string.Empty)) ? this.Transformer.GetChild(4).GetChild(15).GetChild(1).GetComponent<Text>().color : this.Transformer.GetChild(4).GetChild(20).GetChild(0).GetComponent<Text>().color);
			this.Transformer.GetChild(4).GetChild(17).GetComponent<UIButton>().m_Handler = this;
			this.Tag = this.Transformer.GetChild(4).GetChild(17).GetChild(0).GetComponent<Text>();
			this.Tag.font = GUIManager.Instance.GetTTFFont();
			this.Tag.text = ((!(AllianceHint.ValidTag != string.Empty)) ? this.DM.mStringTable.GetStringByID(4617u) : AllianceHint.ValidTag);
			this.Tag.color = ((!(AllianceHint.ValidTag != string.Empty)) ? this.Transformer.GetChild(4).GetChild(17).GetChild(1).GetComponent<Text>().color : this.Transformer.GetChild(4).GetChild(20).GetChild(0).GetComponent<Text>().color);
			this.Transformer.GetChild(4).GetChild(4).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4612u);
			this.Transformer.GetChild(4).GetChild(5).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4616u);
			this.Transformer.GetChild(4).GetChild(22).GetComponent<UIButton>().m_Handler = this;
			this.Transformer.GetChild(4).GetChild(20).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.Transformer.GetChild(4).GetChild(21).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.Transformer.GetChild(4).GetChild(20).GetChild(0).GetComponent<Text>().text = DataManager.Instance.GetLanguageStr(AllianceHint.GenuineLang);
			this.Transformer.GetChild(4).GetChild(22).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.Transformer.GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.TagInvalid = this.Transformer.GetChild(4).GetChild(26);
			this.NameInvalid = (RectTransform)this.Transformer.GetChild(4).GetChild(25);
			this.NameTick = (RectTransform)this.Transformer.GetChild(4).GetChild(27);
			this.TagTick = this.Transformer.GetChild(4).GetChild(28);
			this.Transformer = this.Transformer.GetChild(4).GetChild(18).GetChild(1);
			ushort curSelectBadge = this.DM.CurSelectBadge;
			int num = (int)(curSelectBadge & 7);
			int num2 = curSelectBadge >> 3 & 7;
			int num3 = num2 * 8 + num + 1;
			if (num3 > 64)
			{
				num3 = 64;
			}
			int num4 = (curSelectBadge >> 6 & 63) + 1;
			if (num4 > 64)
			{
				num4 = 64;
			}
			GUIManager.Instance.SetBadgeTotemImg(this.Transformer, num3, num4);
			this.UpdateUI(0, 4);
			break;
		}
		case 10:
			if (AllianceHint.SearchNum > 0)
			{
				for (int i = 0; i < AllianceHint.SearchNum; i++)
				{
					if (AllianceHint.SetRequest != 13)
					{
						AllianceHint.Search[i].ID = 0u;
					}
					if (this.ItemsHeight.Count < AllianceHint.SearchNum)
					{
						this.ItemsHeight.Add(96f);
					}
				}
				if (this.ItemsHeight.Count > AllianceHint.SearchNum)
				{
					this.ItemsHeight.RemoveRange(AllianceHint.SearchNum - 1, this.ItemsHeight.Count - AllianceHint.SearchNum);
				}
			}
			else
			{
				this.ItemsHeight.Clear();
				AllianceHint.SearchIdx = 0;
			}
			if (this.m_scroll)
			{
				this.m_scroll.gameObject.SetActive(true);
				this.m_scroll.AddNewDataHeight(this.ItemsHeight, true, true);
			}
			this.m_default[2].transform.parent.gameObject.SetActive(AllianceHint.SearchNum == 0);
			break;
		case 11:
			base.transform.GetChild(0).gameObject.SetActive(false);
			base.transform.GetChild(1).gameObject.SetActive(true);
			base.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
			base.transform.GetChild(1).GetChild(7).gameObject.SetActive(false);
			base.transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
			base.transform.GetComponent<Image>().enabled = false;
			this.Transformer = base.transform.GetChild(1).GetChild(3);
			this.Transformer.GetChild(3).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4701u);
			this.Transformer.GetChild(3).GetChild(0).GetComponent<Text>().font = this.Font;
			this.m_label[11] = this.Transformer.GetChild(3).GetChild(0).GetComponent<Text>();
			this.Transformer.GetChild(4).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4702u);
			this.Transformer.GetChild(4).GetChild(0).GetComponent<Text>().font = this.Font;
			this.m_label[12] = this.Transformer.GetChild(4).GetChild(0).GetComponent<Text>();
			this.Transformer.GetChild(5).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4704u);
			this.Transformer.GetChild(5).GetChild(0).GetComponent<Text>().font = this.Font;
			this.m_label[13] = this.Transformer.GetChild(5).GetChild(0).GetComponent<Text>();
			if (this.Transformer.GetChild(15).GetChild(0).GetComponent<Text>())
			{
				this.Transformer.GetChild(15).GetChild(0).GetComponent<Text>().font = this.Font;
				this.m_label[14] = this.Transformer.GetChild(15).GetChild(0).GetComponent<Text>();
			}
			if (this.Transformer.GetChild(15).GetChild(1).GetComponent<Text>())
			{
				this.Transformer.GetChild(15).GetChild(1).GetComponent<Text>().font = this.Font;
				this.m_label[15] = this.Transformer.GetChild(15).GetChild(1).GetComponent<Text>();
			}
			this.Transformer.GetChild(16).GetComponent<UIButton>().m_Handler = this;
			this.Transformer.GetChild(17).GetComponent<UIButton>().m_Handler = this;
			this.Transformer.GetChild(17).GetChild(0).GetComponent<Text>().font = this.Font;
			this.m_label[16] = this.Transformer.GetChild(17).GetChild(0).GetComponent<Text>();
			this.Transformer.GetChild(17).GetChild(1).GetComponent<Text>().font = this.Font;
			this.m_label[17] = this.Transformer.GetChild(17).GetChild(1).GetComponent<Text>();
			this.m_PageBack = this.Transformer.GetChild(8).GetChild(0).GetComponent<Image>();
			this.Transformer.GetChild(20).GetComponent<UIButton>().m_Handler = this;
			this.Transformer.GetChild(21).GetComponent<UIButton>().m_Handler = this;
			this.Transformer.GetChild(8).GetComponent<UIButton>().m_Handler = this;
			this.Transformer.GetChild(9).GetComponent<UIButton>().m_Handler = this;
			this.Transformer.GetChild(10).GetComponent<UIButton>().m_Handler = this;
			base.transform.GetChild(1).GetChild(8).gameObject.SetActive(true);
			if (!AllianceHint.Shooting && !AllianceHint.Clearing)
			{
				AllianceHint.Shooting = true;
				this.ItemsHeight.Clear();
				if (this.m_scroll)
				{
					this.m_scroll.AddNewDataHeight(this.ItemsHeight, true, true);
				}
				this.s_input.text = AllianceHint.FilterName;
				this.Path.Length = 0;
				AllianceHint.Proceeding = 1L;
				this.m_default[2].transform.parent.gameObject.SetActive(false);
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_SEARCH;
				messagePacket.AddSeqId();
				if (AllianceHint.SeekName.Length > 0 && AllianceHint.SeekLang > 0)
				{
					messagePacket.Add(AllianceHint.SeekLang);
					messagePacket.Add((byte)AllianceHint.SeekName.Length);
					messagePacket.Add(AllianceHint.SeekName, AllianceHint.SeekName.Length);
					this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(735u), AllianceHint.SeekName, this.DM.GetLanguageStr(AllianceHint.SeekLang)).ToString();
				}
				else if (AllianceHint.SeekName.Length > 0)
				{
					messagePacket.Add(AllianceHint.SeekLang);
					messagePacket.Add((byte)AllianceHint.SeekName.Length);
					messagePacket.Add(AllianceHint.SeekName, AllianceHint.SeekName.Length);
					this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709u), AllianceHint.SeekName).ToString();
				}
				else if (AllianceHint.SeekKind > 20)
				{
					byte seekLang = AllianceHint.SeekLang;
					switch (seekLang)
					{
					case 21:
					case 22:
					case 23:
					case 24:
					case 27:
					case 31:
					case 33:
					case 37:
					case 39:
					case 40:
					case 41:
					case 42:
						break;
					default:
						switch (seekLang)
						{
						case 11:
						case 12:
						case 15:
							break;
						default:
							if (seekLang != 2 && seekLang != 7)
							{
								AllianceHint.SeekLang = 12;
							}
							break;
						}
						break;
					}
					messagePacket.Add(AllianceHint.SeekLang);
					messagePacket.Add(AllianceHint.SeekKind);
					this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709u), this.DM.GetLanguageStr(AllianceHint.SeekLang)).ToString();
				}
				else if (AllianceHint.SeekLang > 0)
				{
					messagePacket.Add(AllianceHint.SeekLang);
					this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709u), this.DM.GetLanguageStr(AllianceHint.SeekLang)).ToString();
				}
				else
				{
					messagePacket.Add(AllianceHint.SeekLang);
					this.m_default[2].transform.parent.gameObject.SetActive(false);
				}
				if ((int)AllianceHint.SeekKind == AllianceHint.SeekName.Length)
				{
					this.Path.Length = 0;
					this.m_filter.text = (AllianceHint.SearchLang = ((AllianceHint.SeekLang <= 0) ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703u), this.DM.GetLanguageStr(AllianceHint.SeekLang)).ToString()));
					this.Path.Length = 0;
					this.m_search.text = (AllianceHint.SearchName = ((AllianceHint.SeekName.Length <= 0) ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703u), AllianceHint.SeekName).ToString()));
				}
				messagePacket.Send(false);
			}
			else if (AllianceHint.SearchNum == 0)
			{
				this.Path.Length = 0;
				this.m_default[2].transform.parent.gameObject.SetActive(true);
				if (AllianceHint.Clearing)
				{
					this.m_default[2].text = this.DM.mStringTable.GetStringByID(736u);
				}
				else if (AllianceHint.SeekName.Length > 0 && AllianceHint.SeekLang > 0)
				{
					this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(735u), AllianceHint.SeekName, this.DM.GetLanguageStr(AllianceHint.SeekLang)).ToString();
				}
				else if (AllianceHint.SeekName.Length > 0)
				{
					this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709u), AllianceHint.SeekName).ToString();
				}
				else if (AllianceHint.SeekLang > 0)
				{
					this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709u), this.DM.GetLanguageStr(AllianceHint.SeekLang)).ToString();
				}
				else
				{
					this.m_default[2].transform.parent.gameObject.SetActive(false);
				}
			}
			else
			{
				this.m_default[2].transform.parent.gameObject.SetActive(false);
			}
			this.Transformer.GetChild(16).gameObject.SetActive(AllianceHint.FilterName.Length > 0);
			this.SetFilterName(AllianceHint.FilterIdx);
			if (!this.m_scroll)
			{
				this.m_scroll = base.transform.GetChild(1).GetChild(8).GetComponent<ScrollPanel>();
				this.m_scroll.IntiScrollPanel(420f, 3f, 4f, this.ItemsHeight, 7, this);
				this.SearchRT = this.m_scroll.transform.GetChild(0).GetComponent<RectTransform>();
				this.m_scroll.AddNewDataHeight(this.ItemsHeight, true, true);
				this.m_panel = new ScrollPanelItem[7];
				if (this.DM.SetSelectRequest == 11 || this.DM.SetSelectRequest == 41)
				{
					this.s_input.text = AllianceHint.FilterName;
					for (int j = 0; j < AllianceHint.SearchNum; j++)
					{
						this.ItemsHeight.Add(96f);
					}
					this.m_scroll.AddNewDataHeight(this.ItemsHeight, true, true);
					this.m_scroll.GoTo(AllianceHint.Positioning, AllianceHint.Scrolling);
				}
				this.Join.sizeDelta = this.SearchSize;
				this.Join.localPosition = this.SearchPosition;
			}
			else
			{
				this.Join.sizeDelta = this.SearchSize;
				this.Join.localPosition = this.SearchPosition;
			}
			DataManager.Instance.SetSelectRequest = arg1;
			AllianceHint.SetRequest = (byte)arg1;
			AllianceHint.CheckTime = 0f;
			AllianceHint.Pulling = 0;
			break;
		case 12:
			base.transform.GetChild(0).gameObject.SetActive(false);
			base.transform.GetChild(1).gameObject.SetActive(true);
			base.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
			base.transform.GetChild(1).GetChild(7).gameObject.SetActive(false);
			base.transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
			base.transform.GetComponent<Image>().enabled = false;
			base.transform.GetChild(1).GetChild(8).gameObject.SetActive(false);
			this.Transformer = base.transform.GetChild(1);
			this.Transformer.GetChild(4).GetChild(1).GetComponent<UIButton>().m_Handler = this;
			this.Transformer.GetChild(4).GetChild(2).GetComponent<UIButton>().m_Handler = this;
			this.Transformer.GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4620u);
			this.Transformer.GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.m_label[18] = this.Transformer.GetChild(4).GetChild(1).GetChild(0).GetComponent<Text>();
			this.Transformer.GetChild(4).GetChild(2).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4611u);
			this.Transformer.GetChild(4).GetChild(2).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.m_label[19] = this.Transformer.GetChild(4).GetChild(2).GetChild(0).GetComponent<Text>();
			this.Transformer.GetChild(4).GetChild(3).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4611u);
			this.Transformer.GetChild(4).GetChild(3).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.m_label[20] = this.Transformer.GetChild(4).GetChild(3).GetChild(0).GetComponent<Text>();
			this.Transformer.GetChild(4).GetChild(4).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4612u);
			this.Transformer.GetChild(4).GetChild(4).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.m_label[21] = this.Transformer.GetChild(4).GetChild(4).GetChild(0).GetComponent<Text>();
			this.Transformer.GetChild(4).GetChild(5).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4616u);
			this.Transformer.GetChild(4).GetChild(5).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.m_label[22] = this.Transformer.GetChild(4).GetChild(5).GetChild(0).GetComponent<Text>();
			this.Transformer.GetChild(4).GetChild(6).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4619u);
			this.Transformer.GetChild(4).GetChild(6).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.m_label[23] = this.Transformer.GetChild(4).GetChild(6).GetChild(0).GetComponent<Text>();
			this.Transformer.GetChild(4).GetChild(20).GetChild(1).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4622u);
			this.Transformer.GetChild(4).GetChild(20).GetChild(1).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.m_label[24] = this.Transformer.GetChild(4).GetChild(20).GetChild(1).GetComponent<Text>();
			this.Transformer.GetChild(4).GetChild(21).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4621u);
			this.Transformer.GetChild(4).GetChild(21).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.m_label[25] = this.Transformer.GetChild(4).GetChild(21).GetChild(0).GetComponent<Text>();
			this.Transformer.GetChild(4).GetChild(22).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4623u);
			this.Transformer.GetChild(4).GetChild(22).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.m_label[26] = this.Transformer.GetChild(4).GetChild(22).GetChild(0).GetComponent<Text>();
			this.m_PageBack = this.Transformer.GetChild(4).GetChild(10).GetChild(0).GetComponent<Image>();
			this.Transformer.GetChild(4).GetChild(8).GetComponent<UIButton>().m_Handler = this;
			this.Transformer.GetChild(4).GetChild(9).GetComponent<UIButton>().m_Handler = this;
			this.Transformer.GetChild(4).GetChild(10).GetComponent<UIButton>().m_Handler = this;
			DataManager.Instance.SetSelectRequest = arg1;
			AllianceHint.SetRequest = (byte)arg1;
			AllianceHint.CheckTime = 0f;
			this.UpdateUI(1, 0);
			break;
		case 13:
			base.transform.GetChild(0).gameObject.SetActive(false);
			base.transform.GetChild(1).gameObject.SetActive(true);
			base.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
			base.transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
			base.transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
			base.transform.GetComponent<Image>().enabled = false;
			this.Transformer = base.transform.GetChild(1).GetChild(7);
			this.Transformer.GetChild(3).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4722u);
			this.Transformer.GetChild(3).GetChild(0).GetComponent<Text>().font = this.Font;
			this.m_PageBack = this.Transformer.GetChild(9).GetChild(0).GetComponent<Image>();
			this.m_label[27] = this.Transformer.GetChild(3).GetChild(0).GetComponent<Text>();
			this.Transformer.GetChild(8).GetComponent<UIButton>().m_Handler = this;
			this.Transformer.GetChild(9).GetComponent<UIButton>().m_Handler = this;
			this.Transformer.GetChild(10).GetComponent<UIButton>().m_Handler = this;
			base.transform.GetChild(1).GetChild(8).gameObject.SetActive(true);
			if (!this.m_scroll)
			{
				this.m_scroll = base.transform.GetChild(1).GetChild(8).GetComponent<ScrollPanel>();
				this.m_scroll.IntiScrollPanel(420f, 3f, 4f, this.ItemsHeight, 7, this);
				this.SearchRT = this.m_scroll.transform.GetChild(0).GetComponent<RectTransform>();
				this.m_scroll.AddNewDataHeight(this.ItemsHeight, true, true);
				this.m_panel = new ScrollPanelItem[7];
			}
			else
			{
				this.ItemsHeight.Clear();
				this.m_scroll.AddNewDataHeight(this.ItemsHeight, true, true);
				this.Join.sizeDelta = this.ApplyList.sizeDelta;
				this.Join.localPosition = this.ApplyList.localPosition;
			}
			this.RequestApplyList();
			DataManager.Instance.SetSelectRequest = arg1;
			AllianceHint.SetRequest = (byte)arg1;
			AllianceHint.CheckTime = 0f;
			break;
		case 15:
			base.transform.GetChild(1).GetChild(3).GetChild(16).gameObject.SetActive(AllianceHint.FilterName.Length > 0);
			break;
		case 21:
			AllianceHint.SearchPage = 0;
			while (AllianceHint.SearchPage < AllianceHint.SearchNum && this.m_scroll && AllianceHint.SearchPage < this.m_panel.Length && this.m_panel[AllianceHint.SearchPage] && this.m_panel[AllianceHint.SearchPage].m_BtnID1 >= 0)
			{
				this.UpDateRowItem(this.m_panel[AllianceHint.SearchPage].gameObject, this.m_panel[AllianceHint.SearchPage].m_BtnID1, 0, 0);
				AllianceHint.SearchPage++;
			}
			break;
		case 22:
			if ((AllianceHint.SearchNum / 10 > (int)AllianceHint.SearchIdx || (AllianceHint.SearchNum / 10 == (int)AllianceHint.SearchIdx && AllianceHint.SearchNum % 10 != 0)) && NetworkManager.Connected())
			{
				byte searchIdx = AllianceHint.SearchIdx;
				AllianceHint.SearchIdx = searchIdx + 1;
				AllianceHint.Pending = (long)searchIdx;
				MessagePacket messagePacket2 = new MessagePacket(1024);
				messagePacket2.Protocol = Protocol._MSG_REQUEST_ALLIANCE_SEARCHRESULT;
				messagePacket2.AddSeqId();
				messagePacket2.Add(AllianceHint.SearchIdx);
				messagePacket2.Send(false);
			}
			else if (AllianceHint.SetRequest == 11)
			{
				this.Revert = true;
			}
			break;
		case 23:
			if (this.m_scroll)
			{
				this.m_scroll.gameObject.SetActive(false);
			}
			break;
		case 24:
			if (this.m_scroll && AllianceHint.SetRequest == 11)
			{
				this.m_scroll.gameObject.SetActive(true);
			}
			break;
		case 25:
			if (this.m_scroll)
			{
				this.m_scroll.AddItem(96f, false);
			}
			break;
		case 26:
			this.door.AllianceOnClick();
			break;
		}
	}

	// Token: 0x06000E45 RID: 3653 RVA: 0x00178A00 File Offset: 0x00176C00
	public static void RecvAllianceCreate(MessagePacket MP)
	{
		GUIWindow guiwindow = GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceHint);
		Protocol protocol = MP.Protocol;
		switch (protocol)
		{
		case Protocol._MSG_RESP_ALLIANCE_APPLY:
		{
			AllianceHint.Pulling = 0;
			byte b = MP.ReadByte(-1);
			if (b == 0)
			{
				if (DataManager.Instance.RoleAlliance.Apply < 10)
				{
					if (DataManager.Instance.RoleAlliance.ApplyList == null)
					{
						DataManager.Instance.RoleAlliance.ApplyList = new uint[10];
					}
					uint[] applyList = DataManager.Instance.RoleAlliance.ApplyList;
					DataManager instance = DataManager.Instance;
					byte b2;
					instance.RoleAlliance.Apply = (b2 = instance.RoleAlliance.Apply) + 1;
					applyList[(int)b2] = MP.ReadUInt(-1);
					if (guiwindow)
					{
						guiwindow.UpdateUI(21, 0);
					}
					GUIManager.Instance.AddHUDMessage(string.Format(DataManager.Instance.mStringTable.GetStringByID(599u), MP.ReadString(20, -1)), 255, true);
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.UIAlliance_publicinfo, 2, 0);
			}
			else if (b > 1)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID((uint)b + 414u), 255, true);
			}
			else
			{
				DataManager.Instance.SendAskKind = 3;
				DataManager.Instance.LastTime = DataManager.Instance.ServerTime;
				DataManager.Instance.SendAskData(1, 1, DataManager.Instance.SendAskKind, 0L, DataManager.Instance.ServerTime + 60L);
			}
			if (b == 6 && guiwindow)
			{
				AllianceHint.Shooting = false;
				guiwindow.UpdateUI((int)AllianceHint.SetRequest, 0);
			}
			GUIManager.Instance.HideUILock(EUILock.AllianceCreate);
			break;
		}
		default:
			switch (protocol)
			{
			case Protocol._MSG_RESP_ALLIANCE_SEARCH:
				if ((DataManager.msgBuffer[1] = MP.ReadByte(-1)) == 255)
				{
					GUIManager.Instance.HideUILock(EUILock.AllianceCreate);
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(796u), 255, true);
					AllianceHint.SearchIdx = 0;
				}
				else if (guiwindow)
				{
					AllianceHint.Pending = (long)(AllianceHint.SearchNum = Mathf.Min((int)DataManager.msgBuffer[1], 100));
					guiwindow.UpdateUI(10, 0);
				}
				else
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_SearchList, 0, 10);
				}
				if (AllianceHint.SearchNum == 0)
				{
					GUIManager.Instance.HideUILock(EUILock.AllianceCreate);
				}
				break;
			default:
				if (protocol != Protocol._MSG_RESP_ROLE_PRIZEFLAG)
				{
					if (protocol == Protocol._MSG_RESP_ALLIANCE_APPLYALLIANCELIST)
					{
						if (!guiwindow || DataManager.Instance.RoleAlliance.ApplyList == null || AllianceHint.Search == null)
						{
							return;
						}
						AllianceHint.SearchNum = (int)(DataManager.Instance.RoleAlliance.Apply = (byte)Mathf.Min((int)MP.ReadByte(-1), 10));
						AllianceHint.SearchPage = 0;
						while (AllianceHint.SearchPage < (int)DataManager.Instance.RoleAlliance.Apply)
						{
							DataManager.Instance.RoleAlliance.ApplyList[AllianceHint.SearchPage] = (AllianceHint.Search[100].ID = MP.ReadUInt(-1));
							AllianceHint.Search[100].Tag = MP.ReadString(3, -1);
							AllianceHint.Search[100].Name = MP.ReadString(20, -1);
							AllianceHint.Search[100].Emblem = MP.ReadUShort(-1);
							AllianceHint.Search[100].Member = MP.ReadByte(-1);
							AllianceHint.Search[100].Language = MP.ReadByte(-1);
							AllianceHint.Search[100].GiftLv = MP.ReadByte(-1);
							AllianceHint.Search[100].Power = MP.ReadULong(-1);
							AllianceHint.Search[100].Approval = MP.ReadByte(-1);
							if (AllianceHint.SetRequest == 13)
							{
								AllianceHint.SearchNum = (int)DataManager.Instance.RoleAlliance.Apply;
								Array.Copy(AllianceHint.Search, 100, AllianceHint.Search, AllianceHint.SearchPage, 1);
							}
							AllianceHint.SearchPage++;
						}
						guiwindow.UpdateUI((AllianceHint.SetRequest != 13) ? 21 : 10, 0);
					}
				}
				else
				{
					byte b2 = MP.ReadByte(-1);
					if (b2 != 0)
					{
						if (b2 == 1)
						{
							DataManager instance2 = DataManager.Instance;
							instance2.RoleAttr.PrizeFlag = MP.ReadUInt(-1);
							DataManager.StageDataController.RoleAttrLevelUp(MP, 24);
							instance2.RoleAttr.Power = MP.ReadULong(-1);
							instance2.Resource[0].Stock = MP.ReadUInt(-1);
							instance2.Resource[1].Stock = MP.ReadUInt(-1);
							instance2.Resource[2].Stock = MP.ReadUInt(-1);
							instance2.Resource[3].Stock = MP.ReadUInt(-1);
							instance2.Resource[4].Stock = MP.ReadUInt(-1);
							instance2.RoleAttr.VipPoint = MP.ReadUInt(-1);
							instance2.RoleAttr.VIPLevel = instance2.GetVIPLevel(instance2.RoleAttr.VipPoint);
							GameManager.OnRefresh(NetworkNews.Refresh, null);
							GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_VipLevelUp, (int)DataManager.Instance.RoleAttr.VIPLevel, 2, false, 0);
						}
					}
					else
					{
						GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_TreasureBox, 2, 0, false, 0);
						DataManager.Instance.RoleAttr.PrizeFlag = MP.ReadUInt(-1);
						DataManager.Instance.RoleAttr.Diamond = MP.ReadUInt(-1);
						DataManager.Instance.Resource[4].Stock = MP.ReadUInt(-1);
						DataManager.Instance.RoleAlliance.Money = MP.ReadUInt(-1);
						GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
						GameManager.OnRefresh(NetworkNews.Refresh_Attr, null);
						GameManager.OnRefresh(NetworkNews.Refresh_Alliance, null);
						GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
						GameManager.OnRefresh(NetworkNews.Refresh, null);
					}
				}
				break;
			case Protocol._MSG_RESP_ALLIANCE_SRARCHRESULT:
			{
				GUIManager.Instance.HideUILock(EUILock.AllianceCreate);
				GUIWindow guiwindow2 = GUIManager.Instance.FindMenu(EGUIWindow.UI_SearchList);
				if (guiwindow2)
				{
					if (MP.ReadByte(-1) > 0 || (AllianceHint.SearchIdx = MP.ReadByte(-1)) == 0 || AllianceHint.SearchIdx > 10 || AllianceHint.Search == null)
					{
						AllianceHint.Pending = (AllianceHint.Proceeding = (long)(AllianceHint.SearchNum = 0));
						guiwindow2.UpdateUI(1, 10);
					}
					else
					{
						DataManager.msgBuffer[1] = MP.ReadByte(-1);
						AllianceHint.SearchPage = (int)((AllianceHint.SearchIdx - 1) * 10);
						AllianceHint.Pending = 0L;
						while (AllianceHint.Pending < (long)Mathf.Min((int)DataManager.msgBuffer[1], 10))
						{
							AllianceHint.Search[AllianceHint.SearchPage].ID = MP.ReadUInt(-1);
							AllianceHint.Search[AllianceHint.SearchPage].Tag = MP.ReadString(3, -1);
							AllianceHint.Search[AllianceHint.SearchPage].Name = MP.ReadString(20, -1);
							AllianceHint.Search[AllianceHint.SearchPage].Emblem = MP.ReadUShort(-1);
							AllianceHint.Search[AllianceHint.SearchPage].Member = MP.ReadByte(-1);
							AllianceHint.Search[AllianceHint.SearchPage].Language = MP.ReadByte(-1);
							AllianceHint.Search[AllianceHint.SearchPage].GiftLv = MP.ReadByte(-1);
							AllianceHint.Search[AllianceHint.SearchPage].Power = MP.ReadULong(-1);
							AllianceHint.Search[AllianceHint.SearchPage].Approval = MP.ReadByte(-1);
							AllianceHint.SearchPage++;
							AllianceHint.Pending += 1L;
						}
						AllianceHint.Pending = 0L;
						guiwindow2.UpdateUI(2, 1);
					}
					return;
				}
				if (!guiwindow || MP.ReadByte(-1) > 0 || (AllianceHint.SearchIdx = MP.ReadByte(-1)) == 0 || AllianceHint.SearchIdx > 10 || AllianceHint.Search == null)
				{
					AllianceHint.Pending = (AllianceHint.Proceeding = 0L);
					if (guiwindow && AllianceHint.SetRequest == 11)
					{
						AllianceHint.SearchNum = 0;
						guiwindow.UpdateUI(10, 0);
					}
					return;
				}
				DataManager.msgBuffer[1] = MP.ReadByte(-1);
				AllianceHint.SearchPage = (int)((AllianceHint.SearchIdx - 1) * 10);
				AllianceHint.Pending = 0L;
				while (AllianceHint.Pending < (long)Mathf.Min((int)DataManager.msgBuffer[1], 10))
				{
					AllianceHint.Search[AllianceHint.SearchPage].ID = MP.ReadUInt(-1);
					AllianceHint.Search[AllianceHint.SearchPage].Tag = MP.ReadString(3, -1);
					AllianceHint.Search[AllianceHint.SearchPage].Name = MP.ReadString(20, -1);
					AllianceHint.Search[AllianceHint.SearchPage].Emblem = MP.ReadUShort(-1);
					AllianceHint.Search[AllianceHint.SearchPage].Member = MP.ReadByte(-1);
					AllianceHint.Search[AllianceHint.SearchPage].Language = MP.ReadByte(-1);
					AllianceHint.Search[AllianceHint.SearchPage].GiftLv = MP.ReadByte(-1);
					AllianceHint.Search[AllianceHint.SearchPage].Power = MP.ReadULong(-1);
					AllianceHint.Search[AllianceHint.SearchPage].Approval = MP.ReadByte(-1);
					AllianceHint.SearchPage++;
					AllianceHint.Pending += 1L;
				}
				AllianceHint.Pending = 0L;
				guiwindow.UpdateUI(21, 0);
				break;
			}
			}
			break;
		case Protocol._MSG_RESP_ALLIANCE_USER_CANCELAPPLY:
			GUIManager.Instance.HideUILock(EUILock.AllianceCreate);
			if (MP.ReadByte(-1) == 0)
			{
				AllianceHint.Search[100].ID = MP.ReadUInt(-1);
				if (DataManager.Instance.RoleAlliance.Apply > 0 && guiwindow && AllianceHint.Search != null)
				{
					AllianceHint.SearchPage = 0;
					while (AllianceHint.SearchPage < (int)DataManager.Instance.RoleAlliance.Apply)
					{
						if (DataManager.Instance.RoleAlliance.ApplyList[AllianceHint.SearchPage] == AllianceHint.Search[100].ID)
						{
							DataManager instance3 = DataManager.Instance;
							if ((int)(instance3.RoleAlliance.Apply = instance3.RoleAlliance.Apply - 1) > AllianceHint.SearchPage)
							{
								Array.Copy(DataManager.Instance.RoleAlliance.ApplyList, AllianceHint.SearchPage + 1, DataManager.Instance.RoleAlliance.ApplyList, AllianceHint.SearchPage, (int)DataManager.Instance.RoleAlliance.Apply - AllianceHint.SearchPage);
								if (AllianceHint.SetRequest == 13)
								{
									Array.Copy(AllianceHint.Search, AllianceHint.SearchPage + 1, AllianceHint.Search, AllianceHint.SearchPage, (int)DataManager.Instance.RoleAlliance.Apply - AllianceHint.SearchPage);
								}
							}
							else
							{
								DataManager.Instance.RoleAlliance.ApplyList[AllianceHint.SearchPage] = 0u;
							}
							break;
						}
						AllianceHint.SearchPage++;
					}
					if (AllianceHint.SetRequest == 13 && AllianceHint.SearchNum > 0)
					{
						AllianceHint.SearchNum--;
						guiwindow.UpdateUI(10, 0);
					}
				}
				DataManager.Instance.RoleAlliance.Apply = MP.ReadByte(-1);
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4725u), 255, true);
			}
			break;
		}
	}

	// Token: 0x06000E46 RID: 3654 RVA: 0x001795D8 File Offset: 0x001777D8
	public override bool OnBackButtonClick()
	{
		if (base.transform.GetChild(2).gameObject.activeInHierarchy)
		{
			base.transform.GetChild(2).gameObject.SetActive(false);
			if (this.DM.SetSelectRequest == 7)
			{
				AllianceHint.ValidName = this.m_input.text;
			}
			else
			{
				AllianceHint.ValidTag = this.m_input.text;
			}
			this.DM.SetSelectRequest = 0;
			if (AllianceHint.CheckTime > 0f)
			{
				this.CheckName(this.m_input.text);
			}
			this.UpdateUI(0, 3);
			this.UpdateUI(this.DM.SetSelectRequest, 0);
			return true;
		}
		if (base.transform.GetChild(1).gameObject.activeInHierarchy)
		{
			base.transform.GetChild(1).gameObject.SetActive(false);
			base.transform.GetChild(0).gameObject.SetActive(true);
			base.transform.GetComponent<Image>().enabled = true;
			this.door.UpdateUI(1, 1);
		}
		else
		{
			DataManager.Instance.SetSelectRequest = 0;
		}
		return false;
	}

	// Token: 0x06000E47 RID: 3655 RVA: 0x00179710 File Offset: 0x00177910
	protected void Update()
	{
		if (AllianceHint.CheckTime > 0f && (AllianceHint.CheckTime -= Time.deltaTime) <= 0f)
		{
			this.CheckName(this.m_input.text);
		}
		if (this.m_PageBack)
		{
			this.TeaTime += Time.smoothDeltaTime;
			if (this.TeaTime >= 0f)
			{
				if (this.TeaTime >= 2f)
				{
					this.TeaTime = 0f;
				}
				float a = (this.TeaTime <= 1f) ? this.TeaTime : (2f - this.TeaTime);
				this.m_PageBack.color = new Color(1f, 1f, 1f, a);
			}
		}
		if (this.Revert)
		{
			AllianceHint.Shooting = (this.Revert = false);
			this.UpdateUI((int)AllianceHint.SetRequest, 0);
		}
	}

	// Token: 0x06000E48 RID: 3656 RVA: 0x00179814 File Offset: 0x00177A14
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Alliance)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
		}
		else
		{
			AllianceHint.SearchIdx = 100;
			GUIManager.Instance.CloseOKCancelBox();
		}
	}

	// Token: 0x06000E49 RID: 3657 RVA: 0x00179870 File Offset: 0x00177A70
	public void Refresh_FontTexture()
	{
		if (this.m_limit != null && this.m_limit.enabled)
		{
			this.m_limit.enabled = false;
			this.m_limit.enabled = true;
		}
		if (this.m_title != null && this.m_title.enabled)
		{
			this.m_title.enabled = false;
			this.m_title.enabled = true;
		}
		if (this.m_error != null && this.m_error.enabled)
		{
			this.m_error.enabled = false;
			this.m_error.enabled = true;
		}
		if (this.m_filter != null && this.m_filter.enabled)
		{
			this.m_filter.enabled = false;
			this.m_filter.enabled = true;
		}
		if (this.m_search != null && this.m_search.enabled)
		{
			this.m_search.enabled = false;
			this.m_search.enabled = true;
		}
		if (this.m_button != null && this.m_button.enabled)
		{
			this.m_button.enabled = false;
			this.m_button.enabled = true;
		}
		if (this.m_content != null && this.m_content.enabled)
		{
			this.m_content.enabled = false;
			this.m_content.enabled = true;
		}
		if (this.m_descript != null && this.m_descript.enabled)
		{
			this.m_descript.enabled = false;
			this.m_descript.enabled = true;
		}
		if (this.Name != null && this.Name.enabled)
		{
			this.Name.enabled = false;
			this.Name.enabled = true;
		}
		if (this.Tag != null && this.Tag.enabled)
		{
			this.Tag.enabled = false;
			this.Tag.enabled = true;
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.m_default[i] != null && this.m_default[i].enabled)
			{
				this.m_default[i].enabled = false;
				this.m_default[i].enabled = true;
			}
		}
		for (int j = 0; j < 7; j++)
		{
			int num = 0;
			while (j < 6)
			{
				if (this.ItemTag[j][num] != null && this.ItemTag[j][num].enabled)
				{
					this.ItemTag[j][num].enabled = false;
					this.ItemTag[j][num].enabled = true;
				}
				j++;
			}
		}
		for (int k = 0; k < 28; k++)
		{
			if (this.m_label[k] != null && this.m_label[k].enabled)
			{
				this.m_label[k].enabled = false;
				this.m_label[k].enabled = true;
			}
		}
		if (this.m_input != null)
		{
			if (this.m_input.textComponent != null && this.m_input.textComponent.enabled)
			{
				this.m_input.textComponent.enabled = false;
				this.m_input.textComponent.enabled = true;
			}
			if (this.m_input.placeholder != null && this.m_input.placeholder.enabled)
			{
				this.m_input.placeholder.enabled = false;
				this.m_input.placeholder.enabled = true;
			}
		}
		if (this.s_input != null)
		{
			if (this.s_input.textComponent != null && this.s_input.textComponent.enabled)
			{
				this.s_input.textComponent.enabled = false;
				this.s_input.textComponent.enabled = true;
			}
			if (this.s_input.placeholder != null && this.s_input.placeholder.enabled)
			{
				this.s_input.placeholder.enabled = false;
				this.s_input.placeholder.enabled = true;
			}
		}
	}

	// Token: 0x06000E4A RID: 3658 RVA: 0x00179D24 File Offset: 0x00177F24
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID2 <= 0)
		{
			if (sender.m_BtnID1 == 1)
			{
				if (this.DM.IsNewbie())
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(438u), 255, true);
				}
				else
				{
					this.UpdateUI(12, 0);
					this.door.UpdateUI(1, 2);
				}
			}
			else if (sender.m_BtnID1 == 2)
			{
				this.UpdateUI(11, 0);
				this.door.UpdateUI(1, 2);
			}
			else if (sender.m_BtnID1 == 3)
			{
				if (this.door && !this.OnBackButtonClick())
				{
					this.door.CloseMenu(false);
				}
			}
			else if (sender.m_BtnID1 == 4)
			{
				if (this.DM.IsNewbie())
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(438u), 255, true);
					return;
				}
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_CREATE;
				messagePacket.AddSeqId();
				messagePacket.Add((byte)Encoding.UTF8.GetByteCount(AllianceHint.ValidName));
				messagePacket.Add(AllianceHint.ValidName, 20);
				messagePacket.Add(AllianceHint.ValidTag, 3);
				messagePacket.Add(this.DM.CurSelectBadge);
				messagePacket.Add(AllianceHint.GenuineLang);
				messagePacket.Send(false);
			}
			else if (sender.m_BtnID1 == 5)
			{
				AllianceHint.Shooting = false;
				DataManager.Instance.SetSelectRequest = sender.m_BtnID1;
				this.door.OpenMenu(EGUIWindow.UIAlliance_Badge, 0, 0, false);
			}
			else if (sender.m_BtnID1 == 6)
			{
				AllianceHint.Shooting = false;
				DataManager.Instance.CurSelectLanguage = AllianceHint.GenuineLang;
				DataManager.Instance.SetSelectLanguage = 1;
				DataManager.Instance.SetSelectRequest = sender.m_BtnID1;
				this.door.OpenMenu(EGUIWindow.UI_LanguageSelect, 0, 0, false);
			}
			else if (sender.m_BtnID1 == 7)
			{
				base.transform.GetChild(2).gameObject.SetActive(true);
				base.transform.GetChild(2).GetChild(0).GetChild(4).GetComponent<UIButton>().m_BtnID1 = 3;
				base.transform.GetChild(2).GetChild(0).GetChild(4).GetComponent<UIButton>().m_Handler = this;
				base.transform.GetChild(2).GetChild(0).GetChild(11).GetComponent<UIButton>().m_Handler = this;
				Text text = this.m_label[10];
				string stringByID = this.DM.mStringTable.GetStringByID(4612u);
				this.m_title.text = stringByID;
				text.text = stringByID;
				this.m_descript.text = this.DM.mStringTable.GetStringByID(4615u);
				AllianceHint.Checking = Protocol._MSG_REQUEST_ALLIANCE_NAMECHACK;
				this.Invalid.gameObject.SetActive(false);
				this.Tick.gameObject.SetActive(false);
				this.m_input.characterLimit = 20;
				this.m_content.text = this.DM.mStringTable.GetStringByID(4613u);
				this.m_input.text = AllianceHint.ValidName;
				this.SetLimit(AllianceHint.ValidName);
				this.DM.SetSelectRequest = sender.m_BtnID1;
				this.m_button.color = ((!this.NameTick.gameObject.activeSelf) ? this.m_error.color : Color.white);
				if (this.m_input.text != string.Empty)
				{
					AllianceHint.CheckTime = 1f;
				}
				AllianceHint.Naming += 1;
			}
			else if (sender.m_BtnID1 == 8)
			{
				base.transform.GetChild(2).gameObject.SetActive(true);
				base.transform.GetChild(2).GetChild(0).GetChild(4).GetComponent<UIButton>().m_Handler = this;
				base.transform.GetChild(2).GetChild(0).GetChild(11).GetComponent<UIButton>().m_Handler = this;
				base.transform.GetChild(2).GetChild(0).GetChild(4).GetComponent<UIButton>().m_BtnID1 = 3;
				Text text2 = this.m_label[10];
				string stringByID = this.DM.mStringTable.GetStringByID(4616u);
				this.m_title.text = stringByID;
				text2.text = stringByID;
				this.m_descript.text = this.DM.mStringTable.GetStringByID(4618u);
				AllianceHint.Checking = Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK;
				this.Invalid.gameObject.SetActive(false);
				this.Tick.gameObject.SetActive(false);
				this.m_input.characterLimit = 3;
				this.m_content.text = this.DM.mStringTable.GetStringByID(4617u);
				this.m_input.text = AllianceHint.ValidTag;
				this.SetLimit(AllianceHint.ValidTag);
				this.DM.SetSelectRequest = sender.m_BtnID1;
				this.m_button.color = ((!this.TagTick.gameObject.activeSelf) ? this.m_error.color : Color.white);
				if (this.m_input.text != string.Empty)
				{
					AllianceHint.CheckTime = 1f;
				}
				AllianceHint.Tagging += 1;
			}
			else if (sender.m_BtnID1 == 21)
			{
				base.transform.GetChild(2).gameObject.SetActive(false);
				AllianceHint.CheckTime = 0f;
				AllianceHint.Tagging += 1;
			}
			else if (sender.m_BtnID1 == 22)
			{
				base.transform.GetChild(2).gameObject.SetActive(false);
				AllianceHint.CheckTime = 0f;
				AllianceHint.Naming += 1;
			}
			else if (sender.m_BtnID1 == 11)
			{
				this.m_default[2].transform.parent.gameObject.SetActive(AllianceHint.Clearing);
				this.m_default[2].text = this.DM.mStringTable.GetStringByID(736u);
				this.UpdateUI(sender.m_BtnID1, 0);
			}
			else if (sender.m_BtnID1 == 12)
			{
				if (this.DM.IsNewbie())
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(438u), 255, true);
				}
				else
				{
					this.UpdateUI(sender.m_BtnID1, 0);
					this.m_default[2].transform.parent.gameObject.SetActive(false);
				}
			}
			else if (sender.m_BtnID1 == 13)
			{
				AllianceHint.Shooting = false;
				this.UpdateUI(sender.m_BtnID1, 0);
				this.m_default[2].text = this.DM.mStringTable.GetStringByID(4725u);
				this.m_default[2].transform.parent.gameObject.SetActive(this.DM.RoleAlliance.Apply == 0);
			}
			else if (sender.m_BtnID1 == 31)
			{
				if (AllianceHint.SearchIdx == 99 || !this.m_scroll.gameObject.activeSelf)
				{
					return;
				}
				if (AllianceHint.FilterIdx == 0 && AllianceHint.FilterName.Length == 0)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4711u), 255, true);
					AllianceHint.GenuineLang = (AllianceHint.SeekLang = this.DM.GetUserLanguageID());
					AllianceHint.Shooting = (AllianceHint.Clearing = false);
					AllianceHint.SeekName = string.Empty;
					AllianceHint.SeekKind = byte.MaxValue;
					this.UpdateUI(11, 0);
					return;
				}
				if (AllianceHint.FilterName.Length > 0 && AllianceHint.FilterName.Length < 3)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4710u), 255, true);
					return;
				}
				AllianceHint.Pulling = 0;
				AllianceHint.Proceeding = 1L;
				this.Path.Length = 0;
				this.ItemsHeight.Clear();
				this.m_scroll.AddNewDataHeight(this.ItemsHeight, true, true);
				AllianceHint.SearchIdx = 99;
				GUIManager.Instance.ShowUILock(EUILock.AllianceCreate);
				MessagePacket messagePacket2 = new MessagePacket(1024);
				messagePacket2.Protocol = Protocol._MSG_REQUEST_ALLIANCE_SEARCH;
				messagePacket2.AddSeqId();
				messagePacket2.Add(AllianceHint.FilterIdx);
				if (AllianceHint.FilterName.Length > 0)
				{
					messagePacket2.Add((byte)AllianceHint.FilterName.Length);
					messagePacket2.Add(AllianceHint.FilterName, AllianceHint.FilterName.Length);
				}
				if (AllianceHint.FilterName.Length > 0 && AllianceHint.FilterIdx > 0)
				{
					this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(735u), AllianceHint.FilterName, this.DM.GetLanguageStr(AllianceHint.FilterIdx)).ToString();
				}
				else if (AllianceHint.FilterName.Length > 0)
				{
					this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709u), AllianceHint.FilterName).ToString();
				}
				else if (AllianceHint.FilterIdx > 0)
				{
					this.m_default[2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4709u), this.DM.GetLanguageStr(AllianceHint.FilterIdx)).ToString();
				}
				this.m_default[2].transform.parent.gameObject.SetActive(false);
				this.Path.Length = 0;
				this.m_filter.text = (AllianceHint.SearchLang = ((AllianceHint.FilterIdx <= 0) ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703u), this.DM.GetLanguageStr(AllianceHint.FilterIdx)).ToString()));
				this.Path.Length = 0;
				this.m_search.text = (AllianceHint.SearchName = ((AllianceHint.FilterName.Length <= 0) ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703u), AllianceHint.FilterName).ToString()));
				AllianceHint.SeekKind = (byte)AllianceHint.FilterName.Length;
				AllianceHint.SeekName = AllianceHint.FilterName;
				AllianceHint.SeekLang = AllianceHint.FilterIdx;
				AllianceHint.Clearing = false;
				messagePacket2.Send(false);
			}
			else if (sender.m_BtnID1 == 32)
			{
				this.DM.SetSelectLanguage = 1;
				this.DM.SetSelectRequest = 41;
				this.DM.CurSelectLanguage = AllianceHint.FilterIdx;
				AllianceHint.Positioning = this.m_scroll.GetTopIdx();
				AllianceHint.Scrolling = this.SearchRT.anchoredPosition.y;
				this.door.OpenMenu(EGUIWindow.UI_LanguageSelect, 0, 0, false);
			}
			else if (sender.m_BtnID1 == 33)
			{
				this.s_input.text = string.Empty;
				AllianceHint.Clearing = true;
				this.ClearName();
				AllianceHint.SearchNum = 0;
				this.UpdateUI(10, 0);
			}
			else if (sender.m_BtnID1 == 34)
			{
				this.SetFilterName(0);
				this.ClearLanguage();
				AllianceHint.Clearing = true;
				AllianceHint.SearchNum = 0;
				this.UpdateUI(10, 0);
			}
			else if (sender.m_BtnID1 != 35)
			{
				if (sender.m_BtnID1 == 41)
				{
				}
			}
			return;
		}
		if (AllianceHint.Pulling > 0)
		{
			return;
		}
		int btnID = sender.m_BtnID2;
		if (btnID != 1)
		{
			if (btnID == 2)
			{
				if (AllianceHint.SetRequest == 13)
				{
					GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4726u), this.DM.mStringTable.GetStringByID(4727u), sender.m_BtnID1, 0, this.DM.mStringTable.GetStringByID(4728u), this.DM.mStringTable.GetStringByID(4729u));
				}
				else
				{
					this.door.AllianceOnJoin(AllianceHint.Search[sender.m_BtnID1].ID, AllianceHint.Search[sender.m_BtnID1].Approval);
					AllianceHint.Pulling = (byte)sender.m_BtnID2;
				}
			}
		}
		else
		{
			this.DM.SetSelectRequest = 41;
			AllianceHint.Positioning = this.m_scroll.GetTopIdx();
			AllianceHint.Scrolling = this.SearchRT.anchoredPosition.y;
			this.DM.AllianceView.Id = AllianceHint.Search[sender.m_BtnID1].ID;
			this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5, 0, false);
		}
	}

	// Token: 0x06000E4B RID: 3659 RVA: 0x0017AABC File Offset: 0x00178CBC
	public void SetLimit(string limit)
	{
		this.Path.Length = 0;
		this.m_limit.text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4614u), this.m_input.characterLimit - Encoding.UTF8.GetByteCount(limit)).ToString();
	}

	// Token: 0x06000E4C RID: 3660 RVA: 0x0017AB24 File Offset: 0x00178D24
	public void ClearName()
	{
		this.m_search.text = (AllianceHint.SearchName = (AllianceHint.SeekName = string.Empty));
		this.m_default[2].text = this.DM.mStringTable.GetStringByID(736u);
	}

	// Token: 0x06000E4D RID: 3661 RVA: 0x0017AB70 File Offset: 0x00178D70
	public void ClearLanguage()
	{
		AllianceHint.SeekKind = byte.MaxValue;
		this.m_filter.text = (AllianceHint.SearchLang = string.Empty);
		this.m_default[2].text = this.DM.mStringTable.GetStringByID(736u);
		AllianceHint.GenuineLang = (AllianceHint.SeekLang = this.DM.GetUserLanguageID());
	}

	// Token: 0x06000E4E RID: 3662 RVA: 0x0017ABD8 File Offset: 0x00178DD8
	public static int Sequencing(Protocol type = Protocol._MSG_INVALID)
	{
		AllianceHint.Incoming = type;
		if (type > Protocol._MSG_INVALID)
		{
			return (int)((type != Protocol._MSG_RESP_ALLIANCE_TAGCHECK) ? AllianceHint.Naming : AllianceHint.Tagging);
		}
		return (int)((AllianceHint.Checking != Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK) ? AllianceHint.Naming : AllianceHint.Tagging);
	}

	// Token: 0x06000E4F RID: 3663 RVA: 0x0017AC2C File Offset: 0x00178E2C
	public static byte Sequencing(byte arg1)
	{
		if (AllianceHint.Incoming == Protocol._MSG_RESP_ALLIANCE_TAGCHECK || AllianceHint.Incoming == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK)
		{
			AllianceHint.GenuineTag = arg1;
		}
		else
		{
			AllianceHint.GenuineName = arg1;
		}
		return arg1;
	}

	// Token: 0x06000E50 RID: 3664 RVA: 0x0017AC6C File Offset: 0x00178E6C
	public static void ValueChanged()
	{
		if (AllianceHint.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK)
		{
			AllianceHint.Tagging += 1;
		}
		else
		{
			AllianceHint.Naming += 1;
		}
		AllianceHint.CheckTime = 1f;
	}

	// Token: 0x06000E51 RID: 3665 RVA: 0x0017ACB4 File Offset: 0x00178EB4
	protected void CheckAll()
	{
		AllianceHint.Checking = Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK;
		this.CheckName(AllianceHint.ValidTag);
		AllianceHint.Checking = Protocol._MSG_REQUEST_ALLIANCE_NAMECHACK;
		this.CheckName(AllianceHint.ValidName);
	}

	// Token: 0x06000E52 RID: 3666 RVA: 0x0017ACEC File Offset: 0x00178EEC
	protected void CheckName(string name)
	{
		AllianceHint.CheckTime = 0f;
		if ((AllianceHint.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK && name.Length == 3) || (AllianceHint.Checking != Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK && name.Length >= 3))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = AllianceHint.Checking;
			messagePacket.AddSeqId();
			messagePacket.Add((byte)AllianceHint.Sequencing(Protocol._MSG_INVALID));
			if (AllianceHint.Checking != Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK)
			{
				messagePacket.Add((byte)Encoding.UTF8.GetByteCount(name));
			}
			messagePacket.Add(name, (AllianceHint.Checking == Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK) ? 3 : 20);
			messagePacket.Send(false);
		}
		else
		{
			AllianceHint.Incoming = AllianceHint.Checking;
			AllianceHint.Sequencing(2);
			this.UpdateUI(2, 2);
		}
	}

	// Token: 0x06000E53 RID: 3667 RVA: 0x0017ADC8 File Offset: 0x00178FC8
	public static void OpenAllianceBox(ushort Type, int CharLimit, bool CheckOnly, long Para)
	{
		InputBox inputBox = GUIManager.Instance.OpenMenu(EGUIWindow.UI_AllianceInput, (int)Type, (!CheckOnly) ? 0 : 1, false, true, false) as InputBox;
		if (inputBox)
		{
			inputBox.SetLimit(CharLimit);
			inputBox.ItemID = Para;
		}
	}

	// Token: 0x04002DE4 RID: 11748
	protected Door door;

	// Token: 0x04002DE5 RID: 11749
	protected Text[] m_label = new Text[28];

	// Token: 0x04002DE6 RID: 11750
	protected Text m_limit;

	// Token: 0x04002DE7 RID: 11751
	protected Text m_title;

	// Token: 0x04002DE8 RID: 11752
	protected Text m_error;

	// Token: 0x04002DE9 RID: 11753
	protected Text m_filter;

	// Token: 0x04002DEA RID: 11754
	protected Text m_search;

	// Token: 0x04002DEB RID: 11755
	protected Text m_button;

	// Token: 0x04002DEC RID: 11756
	protected Text m_content;

	// Token: 0x04002DED RID: 11757
	protected Text[] m_default = new Text[3];

	// Token: 0x04002DEE RID: 11758
	protected Text m_descript;

	// Token: 0x04002DEF RID: 11759
	protected Image m_PageBack;

	// Token: 0x04002DF0 RID: 11760
	protected UIEmojiInput s_input;

	// Token: 0x04002DF1 RID: 11761
	protected UIEmojiInput m_input;

	// Token: 0x04002DF2 RID: 11762
	protected ScrollPanel m_scroll;

	// Token: 0x04002DF3 RID: 11763
	protected ScrollPanelItem[] m_panel;

	// Token: 0x04002DF4 RID: 11764
	protected UISpritesArray USArray;

	// Token: 0x04002DF5 RID: 11765
	protected Transform Transformer;

	// Token: 0x04002DF6 RID: 11766
	protected Transform Tick;

	// Token: 0x04002DF7 RID: 11767
	protected Transform Invalid;

	// Token: 0x04002DF8 RID: 11768
	protected Transform TagTick;

	// Token: 0x04002DF9 RID: 11769
	protected Transform TagInvalid;

	// Token: 0x04002DFA RID: 11770
	protected RectTransform Join;

	// Token: 0x04002DFB RID: 11771
	protected RectTransform NameTick;

	// Token: 0x04002DFC RID: 11772
	protected RectTransform NameInvalid;

	// Token: 0x04002DFD RID: 11773
	protected RectTransform SearchRT;

	// Token: 0x04002DFE RID: 11774
	protected RectTransform SearchList;

	// Token: 0x04002DFF RID: 11775
	protected RectTransform ApplyList;

	// Token: 0x04002E00 RID: 11776
	protected Vector3 SearchPosition;

	// Token: 0x04002E01 RID: 11777
	protected Vector2 SearchSize;

	// Token: 0x04002E02 RID: 11778
	protected bool Revert;

	// Token: 0x04002E03 RID: 11779
	protected Text Name;

	// Token: 0x04002E04 RID: 11780
	protected Text Tag;

	// Token: 0x04002E05 RID: 11781
	protected Text[][] ItemTag = new Text[7][];

	// Token: 0x04002E06 RID: 11782
	protected float TeaTime;

	// Token: 0x04002E07 RID: 11783
	public static float CheckTime;

	// Token: 0x04002E08 RID: 11784
	public static float Scrolling;

	// Token: 0x04002E09 RID: 11785
	public static long Proceeding;

	// Token: 0x04002E0A RID: 11786
	public static long Pending;

	// Token: 0x04002E0B RID: 11787
	public static byte Pulling;

	// Token: 0x04002E0C RID: 11788
	public static byte Tagging;

	// Token: 0x04002E0D RID: 11789
	public static byte Naming;

	// Token: 0x04002E0E RID: 11790
	public static bool Clearing;

	// Token: 0x04002E0F RID: 11791
	public static bool Shooting;

	// Token: 0x04002E10 RID: 11792
	public static int Positioning;

	// Token: 0x04002E11 RID: 11793
	public static Protocol Checking;

	// Token: 0x04002E12 RID: 11794
	public static Protocol Incoming;

	// Token: 0x04002E13 RID: 11795
	public static string Text;

	// Token: 0x04002E14 RID: 11796
	public static string pendingText;

	// Token: 0x04002E15 RID: 11797
	public static string FilterName;

	// Token: 0x04002E16 RID: 11798
	public static string ValidName;

	// Token: 0x04002E17 RID: 11799
	public static string ValidTag;

	// Token: 0x04002E18 RID: 11800
	public static string SeekName;

	// Token: 0x04002E19 RID: 11801
	public static string SearchName;

	// Token: 0x04002E1A RID: 11802
	public static string SearchLang;

	// Token: 0x04002E1B RID: 11803
	public static byte GenuineLang;

	// Token: 0x04002E1C RID: 11804
	public static byte GenuineName;

	// Token: 0x04002E1D RID: 11805
	public static byte GenuineTag;

	// Token: 0x04002E1E RID: 11806
	public static byte SetRequest;

	// Token: 0x04002E1F RID: 11807
	public static byte FilterIdx;

	// Token: 0x04002E20 RID: 11808
	public static byte SearchIdx;

	// Token: 0x04002E21 RID: 11809
	public static byte SeekKind;

	// Token: 0x04002E22 RID: 11810
	public static byte SeekLang;

	// Token: 0x04002E23 RID: 11811
	public static int SearchNum;

	// Token: 0x04002E24 RID: 11812
	public static int SearchPage;

	// Token: 0x04002E25 RID: 11813
	public static AllianceSearch[] Search;

	// Token: 0x04002E26 RID: 11814
	public DataManager DM = DataManager.Instance;

	// Token: 0x04002E27 RID: 11815
	public Font Font = GUIManager.Instance.GetTTFFont();

	// Token: 0x04002E28 RID: 11816
	public StringBuilder Path = new StringBuilder();

	// Token: 0x04002E29 RID: 11817
	private List<float> ItemsHeight = new List<float>();
}
