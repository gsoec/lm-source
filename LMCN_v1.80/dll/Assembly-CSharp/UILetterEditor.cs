using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005CE RID: 1486
public class UILetterEditor : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001D74 RID: 7540 RVA: 0x003661CC File Offset: 0x003643CC
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.m_Mat = this.door.LoadMaterial();
		this.mEditorKind = arg1;
		this.mEditorType = arg2;
		this.text_tmpStr[0] = this.GameT.GetChild(0).GetChild(3).GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(5398u);
		this.mInputName = this.GameT.GetChild(1).GetChild(0).GetComponent<UIEmojiInput>();
		this.mInputName.textComponent.font = this.TTFont;
		this.tmptext = (this.mInputName.placeholder as UIText);
		this.tmptext.font = this.TTFont;
		this.text_Name = this.GameT.GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
		this.text_Name.font = this.TTFont;
		this.mInputTitle = this.GameT.GetChild(2).GetChild(0).GetComponent<UIEmojiInput>();
		this.mInputTitle.textComponent.font = this.TTFont;
		this.tmptext = (this.mInputTitle.placeholder as UIText);
		this.tmptext.font = this.TTFont;
		this.text_Title = this.GameT.GetChild(2).GetChild(0).GetChild(1).GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.mInputTitle.onEndEdit.AddListener(delegate(string id)
		{
			this.ChangText(id);
		});
		this.mInputTitle.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
		this.mInputEditor = this.GameT.GetChild(3).GetChild(0).GetComponent<UIEmojiInput>();
		this.mInputEditor.textComponent.font = this.TTFont;
		this.tmptext = (this.mInputEditor.placeholder as UIText);
		this.tmptext.font = this.TTFont;
		this.text_Editor = this.GameT.GetChild(3).GetChild(0).GetChild(1).GetComponent<UIText>();
		this.text_Editor.font = this.TTFont;
		this.text_tmpStr[1] = this.GameT.GetChild(3).GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(5399u);
		this.text_Editor2 = this.GameT.GetChild(3).GetChild(2).GetComponent<UIText>();
		this.text_Editor2.font = this.TTFont;
		this.btn_BookMarks = this.GameT.GetChild(4).GetComponent<UIButton>();
		this.btn_BookMarks.m_Handler = this;
		this.btn_BookMarks.m_BtnID1 = 1;
		this.btn_BookMarks.m_EffectType = e_EffectType.e_Scale;
		this.btn_BookMarks.transition = Selectable.Transition.None;
		this.btn_BookMarks.gameObject.SetActive(false);
		this.btn_btn_SendLetter = this.GameT.GetChild(5).GetComponent<UIButton>();
		this.btn_btn_SendLetter.m_Handler = this;
		this.btn_btn_SendLetter.m_BtnID1 = 2;
		this.btn_btn_SendLetter.m_EffectType = e_EffectType.e_Scale;
		this.btn_btn_SendLetter.transition = Selectable.Transition.None;
		this.text_tmpStr[2] = this.GameT.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[2].font = this.TTFont;
		this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(5400u);
		if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 8)
		{
			this.btn_btn_SendLetter.image.color = Color.gray;
		}
		this.tmpImg = this.GameT.GetChild(6).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		switch (this.mEditorKind)
		{
		case 1:
			this.mInputName.text = this.DM.Letter_ReplyName_KTN.ToString();
			this.mInputTitle.text = this.DM.Letter_ReplyTitle_Alliance.ToString();
			this.mInputName.interactable = false;
			this.mInputTitle.interactable = false;
			break;
		case 2:
		case 3:
			this.mInputName.text = this.DM.Letter_ReplyName.ToString();
			this.mInputName.interactable = false;
			break;
		}
		if (this.DM.bMailAddBookMark)
		{
			if (this.DM.Letter_ReplyName != null)
			{
				this.mInputName.text = this.DM.Letter_ReplyName;
			}
			if (this.DM.Letter_ReplyTitle != null)
			{
				this.mInputTitle.text = this.DM.Letter_ReplyTitle;
			}
			if (this.DM.Letter_ReplyEditor != null)
			{
				this.mInputEditor.text = this.DM.Letter_ReplyEditor;
			}
		}
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001D75 RID: 7541 RVA: 0x00366834 File Offset: 0x00364A34
	public override void OnClose()
	{
	}

	// Token: 0x06001D76 RID: 7542 RVA: 0x00366838 File Offset: 0x00364A38
	public void ChangText(string ID)
	{
		this.text_Title.text = ID;
		this.text_Title.SetAllDirty();
		this.text_Title.cachedTextGenerator.Invalidate();
		this.mInputTitle.text = StringManager.InputTemp;
		this.mInputTitle.text = ID;
	}

	// Token: 0x06001D77 RID: 7543 RVA: 0x00366888 File Offset: 0x00364A88
	protected char OnValidateInput(string text, int index, char check)
	{
		int num = Encoding.UTF8.GetByteCount(text) + Encoding.UTF8.GetByteCount(check.ToString());
		if (num > 64)
		{
			return '\0';
		}
		this.text_Title.text = text;
		this.text_Title.SetAllDirty();
		this.text_Title.cachedTextGenerator.Invalidate();
		return check;
	}

	// Token: 0x06001D78 RID: 7544 RVA: 0x003668E8 File Offset: 0x00364AE8
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
		{
			byte[] bytes = Encoding.UTF8.GetBytes(this.mInputEditor.text);
			if (bytes.Length > 0)
			{
				this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(6034u), this.DM.mStringTable.GetStringByID(6035u), 1, 0, this.DM.mStringTable.GetStringByID(6036u), this.DM.mStringTable.GetStringByID(6037u));
			}
			else
			{
				this.door.CloseMenu(false);
			}
			this.DM.bMailAddBookMark = false;
			break;
		}
		case 2:
		{
			if (sender.image.color == Color.gray)
			{
				this.GUIM.MsgStr.ClearString();
				this.GUIM.MsgStr.IntToFormat(8L, 1, false);
				this.GUIM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(9167u));
				this.GUIM.AddHUDMessage(this.GUIM.MsgStr.ToString(), 255, true);
				return;
			}
			if (this.mEditorKind == 3 && this.DM.RoleAlliance.Rank < AllianceRank.RANK2)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4753u), 255, true);
				return;
			}
			char[] array = this.mInputTitle.text.ToCharArray();
			char[] array2 = this.mInputEditor.text.ToCharArray();
			if (this.DM.Letter_ReplyTitle == null)
			{
				this.DM.Letter_ReplyTitle = string.Empty;
			}
			char[] array3 = this.DM.Letter_ReplyTitle.ToCharArray();
			if (this.DM.Letter_ReplyName == null)
			{
				this.DM.Letter_ReplyName = string.Empty;
			}
			char[] array4 = this.DM.Letter_ReplyName.ToCharArray();
			if (this.DM.m_BannedWord != null)
			{
				this.DM.m_BannedWord.CheckBannedWord(array);
				this.DM.m_BannedWord.CheckBannedWord(array2);
				this.DM.m_BannedWord.CheckBannedWord(array3);
				this.DM.m_BannedWord.CheckBannedWord(array4);
			}
			byte[] bytes2 = Encoding.UTF8.GetBytes(array);
			byte[] bytes3 = Encoding.UTF8.GetBytes(array2);
			byte[] bytes4 = Encoding.UTF8.GetBytes(this.mInputName.text);
			byte[] bytes5 = Encoding.UTF8.GetBytes(array3);
			byte[] bytes6 = Encoding.UTF8.GetBytes(array4);
			int num = 0;
			int num2 = 0;
			while (num2 <= 32 && num2 < bytes6.Length)
			{
				if (bytes6[num2] == 0)
				{
					break;
				}
				if (bytes6[num2] != 0)
				{
					num++;
				}
				num2++;
			}
			if (this.mEditorKind == 0)
			{
				if (bytes4.Length > 13)
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5379u), 255, true);
					return;
				}
			}
			else if (this.mEditorKind != 3 && num > 13)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5379u), 255, true);
				return;
			}
			int num3 = 0;
			for (int i = 0; i < 10; i++)
			{
				if (this.DM.RoleBookMark.SelectBookMarkIndex[i] != 0)
				{
					num3++;
				}
			}
			this.text_Editor2.text = this.mInputEditor.text;
			float preferredHeight = this.text_Editor2.preferredHeight;
			if (preferredHeight > 557f)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6049u), 255, true);
				return;
			}
			num = 0;
			int num4 = 0;
			while (num4 <= 64 && num4 < bytes2.Length)
			{
				if (bytes2[num4] == 0)
				{
					break;
				}
				if (bytes2[num4] != 0)
				{
					num++;
				}
				num4++;
			}
			if (((this.mEditorKind == 0 || this.mEditorKind == 2) && num > 64) || (this.mEditorKind == 3 && bytes5.Length > 64) || (this.mEditorKind == 1 && this.mEditorType != 1 && num > 64))
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6018u), 255, true);
				return;
			}
			if (bytes3.Length > 1024)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6017u), 255, true);
				return;
			}
			if (GUIManager.Instance.ShowUILock(EUILock.LetterEditor))
			{
				uint data = 0u;
				MessagePacket messagePacket = new MessagePacket(1124);
				if (this.mEditorKind != 3)
				{
					messagePacket.Protocol = Protocol._MSG_REQUEST_SENDREGMAIL;
				}
				else
				{
					messagePacket.Protocol = Protocol._MSG_REQUEST_SENDALLIMAIL;
				}
				messagePacket.AddSeqId();
				if (this.mEditorKind != 3)
				{
					if (this.mEditorKind == 1)
					{
						data = this.DM.Letter_ReplyID;
					}
					messagePacket.Add(data);
					if (this.mEditorKind == 0)
					{
						messagePacket.Add(this.mInputName.text, 13);
					}
					else
					{
						messagePacket.Add(this.DM.Letter_ReplyName, 13);
					}
				}
				if (this.DM.ServerVersionMajor != 0)
				{
					byte data2;
					if (ArabicTransfer.Instance.IsArabicStr(this.mInputEditor.text))
					{
						data2 = 2;
					}
					else
					{
						data2 = 1;
					}
					messagePacket.Add(data2);
				}
				if (this.mEditorKind == 1)
				{
					messagePacket.Add((byte)bytes5.Length);
					messagePacket.Add((ushort)bytes3.Length);
					messagePacket.Add((byte)num3);
					messagePacket.Add(bytes5, 0, 0);
				}
				else
				{
					messagePacket.Add((byte)bytes2.Length);
					messagePacket.Add((ushort)bytes3.Length);
					messagePacket.Add((byte)num3);
					messagePacket.Add(bytes2, 0, 0);
				}
				messagePacket.Add(bytes3, 0, 0);
				messagePacket.Add(this.DM.RoleBookMark.SelectBookMarkIndex, 0, 0);
				messagePacket.Send(false);
			}
			break;
		}
		}
	}

	// Token: 0x06001D79 RID: 7545 RVA: 0x00366F90 File Offset: 0x00365190
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001D7A RID: 7546 RVA: 0x00366FA4 File Offset: 0x003651A4
	public override void UpdateNetwork(byte[] meg)
	{
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
			else if (this.DM.RoleAlliance.Id == 0u && (this.mEditorKind == 2 || this.mEditorKind == 3))
			{
				this.door.CloseMenu_Alliance(EGUIWindow.UI_LetterEditor);
				return;
			}
		}
		else if (this.DM.RoleAlliance.Id == 0u && (this.mEditorKind == 2 || this.mEditorKind == 3))
		{
			this.door.CloseMenu_Alliance(EGUIWindow.UI_LetterEditor);
			return;
		}
	}

	// Token: 0x06001D7B RID: 7547 RVA: 0x0036705C File Offset: 0x0036525C
	public void Refresh_FontTexture()
	{
		if (this.text_Name != null && this.text_Name.enabled)
		{
			this.text_Name.enabled = false;
			this.text_Name.enabled = true;
		}
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Editor != null && this.text_Editor.enabled)
		{
			this.text_Editor.enabled = false;
			this.text_Editor.enabled = true;
		}
		if (this.text_Editor2 != null && this.text_Editor2.enabled)
		{
			this.text_Editor2.enabled = false;
			this.text_Editor2.enabled = true;
		}
		if (this.mInputName != null && this.mInputName.textComponent.enabled)
		{
			this.mInputName.textComponent.enabled = false;
			this.mInputName.textComponent.enabled = true;
		}
		if (this.mInputName != null && this.mInputName.placeholder.enabled)
		{
			this.mInputName.placeholder.enabled = false;
			this.mInputName.placeholder.enabled = true;
		}
		if (this.mInputTitle != null && this.mInputTitle.textComponent.enabled)
		{
			this.mInputTitle.textComponent.enabled = false;
			this.mInputTitle.textComponent.enabled = true;
		}
		if (this.mInputTitle != null && this.mInputTitle.placeholder.enabled)
		{
			this.mInputTitle.placeholder.enabled = false;
			this.mInputTitle.placeholder.enabled = true;
		}
		if (this.mInputEditor != null && this.mInputEditor.textComponent.enabled)
		{
			this.mInputEditor.textComponent.enabled = false;
			this.mInputEditor.textComponent.enabled = true;
		}
		if (this.mInputEditor != null && this.mInputEditor.placeholder.enabled)
		{
			this.mInputEditor.placeholder.enabled = false;
			this.mInputEditor.placeholder.enabled = true;
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.text_tmpStr[i] != null && this.text_tmpStr[i].enabled)
			{
				this.text_tmpStr[i].enabled = false;
				this.text_tmpStr[i].enabled = true;
			}
		}
	}

	// Token: 0x06001D7C RID: 7548 RVA: 0x00367350 File Offset: 0x00365550
	private void Start()
	{
	}

	// Token: 0x06001D7D RID: 7549 RVA: 0x00367354 File Offset: 0x00365554
	private void Update()
	{
	}

	// Token: 0x04005AB0 RID: 23216
	private Transform GameT;

	// Token: 0x04005AB1 RID: 23217
	private UIButton btn_EXIT;

	// Token: 0x04005AB2 RID: 23218
	private UIButton btn_BookMarks;

	// Token: 0x04005AB3 RID: 23219
	private UIButton btn_btn_SendLetter;

	// Token: 0x04005AB4 RID: 23220
	private Image tmpImg;

	// Token: 0x04005AB5 RID: 23221
	private UIText tmptext;

	// Token: 0x04005AB6 RID: 23222
	private UIText text_Name;

	// Token: 0x04005AB7 RID: 23223
	private UIText text_Title;

	// Token: 0x04005AB8 RID: 23224
	private UIText text_Editor;

	// Token: 0x04005AB9 RID: 23225
	private UIText text_Editor2;

	// Token: 0x04005ABA RID: 23226
	private UIText[] text_tmpStr = new UIText[3];

	// Token: 0x04005ABB RID: 23227
	private UIEmojiInput mInputName;

	// Token: 0x04005ABC RID: 23228
	private UIEmojiInput mInputTitle;

	// Token: 0x04005ABD RID: 23229
	private UIEmojiInput mInputEditor;

	// Token: 0x04005ABE RID: 23230
	private DataManager DM;

	// Token: 0x04005ABF RID: 23231
	private GUIManager GUIM;

	// Token: 0x04005AC0 RID: 23232
	private Font TTFont;

	// Token: 0x04005AC1 RID: 23233
	private Door door;

	// Token: 0x04005AC2 RID: 23234
	private Material m_Mat;

	// Token: 0x04005AC3 RID: 23235
	private int mEditorKind;

	// Token: 0x04005AC4 RID: 23236
	private int mEditorType;
}
