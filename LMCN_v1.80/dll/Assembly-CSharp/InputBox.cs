using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002BF RID: 703
public class InputBox : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
	// Token: 0x06000E5F RID: 3679 RVA: 0x0017B1A0 File Offset: 0x001793A0
	private void Update()
	{
		if (this.CheckTime > 0f && (this.CheckTime -= Time.deltaTime) <= 0f)
		{
			this.OnCheck(this.m_input.text);
		}
	}

	// Token: 0x06000E60 RID: 3680 RVA: 0x0017B1F0 File Offset: 0x001793F0
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
		img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
		img.material = GUIManager.Instance.GetFrameMaterial();
	}

	// Token: 0x06000E61 RID: 3681 RVA: 0x0017B254 File Offset: 0x00179454
	private void ValueChange(string input)
	{
		if (this.Type <= ECaseByCaseType.ECBCT_ReNickName && (input != string.Empty || this.Type == ECaseByCaseType.ECBCT_ReNickName))
		{
			this.CheckTime = 1f;
			this.Tagging += 1;
		}
		this.Hint.Length = 0;
		this.m_character.text = this.Hint.AppendFormat(this.DM.mStringTable.GetStringByID(4614u), this.Limits - input.Length).ToString();
	}

	// Token: 0x06000E62 RID: 3682 RVA: 0x0017B2F4 File Offset: 0x001794F4
	public override void OnOpen(int arg1, int arg2)
	{
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			((RectTransform)base.transform).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)base.transform).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		this.Transformer = base.transform.GetChild(0);
		this.Transformer.GetChild(4).GetComponent<CustomImage>().hander = this;
		this.Transformer.GetChild(4).GetComponent<UIButton>().m_Handler = this;
		this.Transformer.GetChild(11).GetComponent<UIButton>().m_Handler = this;
		this.Transformer.GetChild(7).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
		this.m_InputBoxText[0] = this.Transformer.GetChild(7).GetChild(0).GetComponent<Text>();
		this.Transformer.GetChild(8).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
		this.m_InputBoxText[1] = this.Transformer.GetChild(8).GetComponent<Text>();
		this.Transformer.GetChild(5).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
		this.m_InputBoxText[2] = this.Transformer.GetChild(5).GetChild(0).GetComponent<Text>();
		this.m_character = this.Transformer.GetChild(12).GetComponent<Text>();
		this.m_character.font = GUIManager.Instance.GetTTFFont();
		this.m_content = this.Transformer.GetChild(5).GetChild(1).GetComponent<Text>();
		this.m_content.font = GUIManager.Instance.GetTTFFont();
		this.m_content.text = this.DM.mStringTable.GetStringByID(4613u);
		this.m_descript = this.Transformer.GetChild(13).GetComponent<Text>();
		this.m_descript.font = GUIManager.Instance.GetTTFFont();
		this.m_error = this.Transformer.GetChild(9).GetChild(0).GetComponent<Text>();
		this.m_error.font = GUIManager.Instance.GetTTFFont();
		this.m_input = this.Transformer.GetChild(5).GetChild(0).GetComponent<UIEmojiInput>();
		this.m_input.onValueChange.AddListener(delegate(string input)
		{
			this.ValueChange(input);
		});
		this.m_input.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
		this.m_butt = this.Transformer.GetChild(4).GetChild(0).GetComponent<Text>();
		this.m_butt.font = GUIManager.Instance.GetTTFFont();
		this.m_butt.text = this.DM.mStringTable.GetStringByID(4715u);
		this.m_butt.color = (((this.Type = (ECaseByCaseType)arg1) >= ECaseByCaseType.ECBCT_ReNickName) ? Color.white : this.m_error.color);
		this.Transformer.GetChild(10).gameObject.AddComponent<ArabicItemTextureRot>();
		UnityEngine.Object.Destroy(base.transform.GetChild(0).GetChild(0).GetComponent<IgnoreRaycast>());
		HelperUIButton helperUIButton = base.gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID1 = 22;
		ECaseByCaseType type = this.Type;
		switch (type)
		{
		case ECaseByCaseType.ECBCT_ReNickName:
		{
			this.m_descript.text = this.DM.mStringTable.GetStringByID(9069u);
			Text component = this.Transformer.GetChild(8).GetComponent<Text>();
			string stringByID = this.DM.mStringTable.GetStringByID(9099u);
			this.Transformer.GetChild(7).GetChild(0).GetComponent<Text>().text = stringByID;
			component.text = stringByID;
			break;
		}
		case ECaseByCaseType.ECBCT_SaveTalent:
		{
			this.m_descript.text = this.DM.mStringTable.GetStringByID(9069u);
			Text component2 = this.Transformer.GetChild(8).GetComponent<Text>();
			string stringByID = this.DM.mStringTable.GetStringByID(931u);
			this.Transformer.GetChild(7).GetChild(0).GetComponent<Text>().text = stringByID;
			component2.text = stringByID;
			break;
		}
		case ECaseByCaseType.ECBCT_EquipMemorySetup:
		{
			this.m_descript.text = this.DM.mStringTable.GetStringByID(9069u);
			Text component3 = this.Transformer.GetChild(8).GetComponent<Text>();
			string stringByID = this.DM.mStringTable.GetStringByID(9704u);
			this.Transformer.GetChild(7).GetChild(0).GetComponent<Text>().text = stringByID;
			component3.text = stringByID;
			break;
		}
		default:
			if (type != ECaseByCaseType.ECBCT_AllianceRename)
			{
				if (type != ECaseByCaseType.ECBCT_AllianceTag)
				{
					this.Sending = Protocol._MSG_REQUEST_ROLE_RENAME;
					this.Checking = Protocol._MSG_REQUEST_ROLE_NAME_CHECK;
					this.m_content.text = this.DM.mStringTable.GetStringByID(4718u);
					this.m_descript.text = this.DM.mStringTable.GetStringByID(4615u);
					this.Transformer.GetChild(7).GetChild(0).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4717u);
					this.Transformer.GetChild(8).GetComponent<Text>().text = this.DM.mStringTable.GetStringByID(4716u);
				}
				else
				{
					this.Checking = Protocol._MSG_REQUEST_ALLIANCE_TAGCHECK;
					this.Sending = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_TAG;
					this.m_content.text = this.DM.mStringTable.GetStringByID(4617u);
					this.m_descript.text = this.DM.mStringTable.GetStringByID(4618u);
					Text component4 = this.Transformer.GetChild(8).GetComponent<Text>();
					string stringByID = this.DM.mStringTable.GetStringByID(4616u);
					this.Transformer.GetChild(7).GetChild(0).GetComponent<Text>().text = stringByID;
					component4.text = stringByID;
				}
			}
			else
			{
				this.Checking = Protocol._MSG_REQUEST_ALLIANCE_NAMECHACK;
				this.Sending = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_NAME;
				this.m_content.text = this.DM.mStringTable.GetStringByID(4613u);
				this.m_descript.text = this.DM.mStringTable.GetStringByID(4615u);
				Text component5 = this.Transformer.GetChild(8).GetComponent<Text>();
				string stringByID = this.DM.mStringTable.GetStringByID(4612u);
				this.Transformer.GetChild(7).GetChild(0).GetComponent<Text>().text = stringByID;
				component5.text = stringByID;
			}
			break;
		case ECaseByCaseType.ECBCT_Preselectedteam:
		{
			this.m_descript.text = this.DM.mStringTable.GetStringByID(9069u);
			Text component6 = this.Transformer.GetChild(8).GetComponent<Text>();
			string stringByID = this.DM.mStringTable.GetStringByID(992u);
			this.Transformer.GetChild(7).GetChild(0).GetComponent<Text>().text = stringByID;
			component6.text = stringByID;
			this.m_content.text = this.DM.mStringTable.GetStringByID(4617u);
			break;
		}
		}
		this.Invalid = this.Transformer.GetChild(9).gameObject;
		this.Tick = this.Transformer.GetChild(10).gameObject;
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
	}

	// Token: 0x06000E63 RID: 3683 RVA: 0x0017BAD4 File Offset: 0x00179CD4
	protected void OnCheck(string name)
	{
		if (this.Type == ECaseByCaseType.ECBCT_ReNickName)
		{
			this.SetStatus(DataManager.Instance.m_BannedWord.ChackHasBannedWord(name), string.Empty);
		}
		else if ((this.Checking != Protocol._MSG_REQUEST_ALLIANCE_NAMECHACK && name.Length >= 3) || this.Checking == Protocol._MSG_REQUEST_ALLIANCE_NAMECHACK)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = this.Checking;
			messagePacket.AddSeqId();
			messagePacket.Add(this.Tagging);
			if (this.Type != ECaseByCaseType.ECBCT_AllianceTag)
			{
				messagePacket.Add((byte)Encoding.UTF8.GetByteCount(name));
			}
			messagePacket.Add(name, this.Limits);
			messagePacket.Send(false);
		}
		else
		{
			this.SetStatus(true, string.Empty);
		}
		this.CheckTime = 0f;
	}

	// Token: 0x06000E64 RID: 3684 RVA: 0x0017BBB4 File Offset: 0x00179DB4
	protected char OnValidateInput(string text, int index, char check)
	{
		if (this.Type > ECaseByCaseType.ECBCT_EquipMemorySetup)
		{
			return check;
		}
		if (this.Type == ECaseByCaseType.ECBCT_AllianceTag)
		{
			return (check < '!' || check > '~') ? '\0' : check;
		}
		if (this.Type == ECaseByCaseType.ECBCT_ReNickName || this.Type == ECaseByCaseType.ECBCT_SaveTalent || this.Type == ECaseByCaseType.ECBCT_EquipMemorySetup)
		{
			return ((check >= '0' || check == ' ') && (check <= '9' || check >= 'A') && (check <= 'Z' || check >= 'a') && (check <= 'z' || check >= '~')) ? check : '\0';
		}
		return ((check < 'A' || check > 'Z') && (check < 'a' || check > 'z') && (check < '0' || check > '9') && check != ' ') ? '\0' : check;
	}

	// Token: 0x06000E65 RID: 3685 RVA: 0x0017BCA4 File Offset: 0x00179EA4
	public override void OnClose()
	{
		this.m_input.onValueChange.RemoveAllListeners();
	}

	// Token: 0x06000E66 RID: 3686 RVA: 0x0017BCB8 File Offset: 0x00179EB8
	public void SetStatus(bool Asshole, string KissMyAss = "")
	{
		this.Invalid.SetActive(Asshole);
		this.Tick.SetActive(!Asshole);
		if (KissMyAss.Equals(string.Empty))
		{
			this.m_error.text = this.DM.mStringTable.GetStringByID((this.Type != ECaseByCaseType.ECBCT_AllianceRename && this.Type != ECaseByCaseType.ECBCT_AllianceTag) ? 362u : 437u);
		}
		else
		{
			this.m_error.text = KissMyAss;
		}
		this.m_butt.color = ((!Asshole) ? Color.white : this.m_error.color);
	}

	// Token: 0x06000E67 RID: 3687 RVA: 0x0017BD6C File Offset: 0x00179F6C
	public void SetLimit(int limit)
	{
		if (this.m_input)
		{
			this.m_input.characterLimit = limit;
			this.Limits = limit;
			this.Counts = limit;
		}
		this.Hint.Length = 0;
		this.m_character.text = this.Hint.AppendFormat(this.DM.mStringTable.GetStringByID(4614u), this.Limits).ToString();
	}

	// Token: 0x06000E68 RID: 3688 RVA: 0x0017BDF0 File Offset: 0x00179FF0
	public void SetContent(string text)
	{
		if (this.m_input)
		{
			this.m_input.text = text;
		}
	}

	// Token: 0x06000E69 RID: 3689 RVA: 0x0017BE10 File Offset: 0x0017A010
	public void SetDescriptive(string text)
	{
		if (this.m_descript)
		{
			this.m_descript.text = text;
		}
	}

	// Token: 0x06000E6A RID: 3690 RVA: 0x0017BE30 File Offset: 0x0017A030
	public void Congrats(string name)
	{
		byte b = 0;
		ushort num = 0;
		if (DataManager.Instance.GetCurItemQuantity((ushort)this.ItemID, 0) == 0)
		{
			b = 1;
			num = DataManager.Instance.TotalShopItemData.Find((ushort)this.ItemID);
		}
		if (this.Type >= ECaseByCaseType.ECBCT_ReNickName)
		{
			if (b == 0)
			{
				DataManager.Instance.UseItem((ushort)this.ItemID, 1, 0, 0, 0, 0u, name, false);
			}
			else
			{
				DataManager.Instance.sendBuyItem(1, num, (ushort)this.ItemID, true, null, 0, 0, 0u, name, false, 1);
			}
			GUIManager.Instance.CloseMenu(this.m_eWindow);
		}
		else if (GUIManager.Instance.ShowUILock(EUILock.AllianceCreate))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = this.Sending;
			messagePacket.AddSeqId();
			messagePacket.Add(b);
			messagePacket.Add(num);
			messagePacket.Add((ushort)this.ItemID);
			if (this.Type != ECaseByCaseType.ECBCT_AllianceTag)
			{
				messagePacket.Add((byte)Encoding.UTF8.GetByteCount(name));
			}
			messagePacket.Add(name, this.Limits);
			messagePacket.Send(false);
			this.CheckTime = 0f;
		}
	}

	// Token: 0x06000E6B RID: 3691 RVA: 0x0017BF5C File Offset: 0x0017A15C
	public override void UpdateUI(int arg1, int arg2)
	{
		if ((int)this.Tagging == arg1)
		{
			if (this.Type == ECaseByCaseType.ECBCT_Rename)
			{
				this.SetStatus(arg2 > 0, this.DM.mStringTable.GetStringByID((arg2 != 1) ? 362u : 363u));
			}
			else
			{
				this.SetStatus(arg2 > 0, this.DM.mStringTable.GetStringByID((uint)(arg2 + ((this.Type != ECaseByCaseType.ECBCT_AllianceRename) ? 435 : 433))));
			}
		}
	}

	// Token: 0x06000E6C RID: 3692 RVA: 0x0017BFF0 File Offset: 0x0017A1F0
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			if ((this.Type == ECaseByCaseType.ECBCT_AllianceRename || this.Type == ECaseByCaseType.ECBCT_AllianceTag) && this.DM.RoleAlliance.Rank != AllianceRank.RANK5)
			{
				GUIManager.Instance.CloseMenu(this.m_eWindow);
			}
			else if (meg[0] == 0)
			{
				this.CheckTime = 0.1f;
			}
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Inputbox)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else if (meg[1] > 0)
			{
				if (this.Type == ECaseByCaseType.ECBCT_Rename)
				{
					this.SetStatus(meg[1] > 0, this.DM.mStringTable.GetStringByID((meg[1] != 3) ? 362u : 363u));
				}
				else
				{
					this.SetStatus(meg[1] > 0, this.DM.mStringTable.GetStringByID((uint)meg[1] + ((this.Type != ECaseByCaseType.ECBCT_AllianceRename) ? 433u : 431u)));
				}
			}
			else
			{
				GUIManager.Instance.CloseMenu(this.m_eWindow);
			}
			break;
		}
	}

	// Token: 0x06000E6D RID: 3693 RVA: 0x0017C13C File Offset: 0x0017A33C
	public void Refresh_FontTexture()
	{
		if (this.m_butt != null && this.m_butt.enabled)
		{
			this.m_butt.enabled = false;
			this.m_butt.enabled = true;
		}
		if (this.m_error != null && this.m_error.enabled)
		{
			this.m_error.enabled = false;
			this.m_error.enabled = true;
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
		if (this.m_character != null && this.m_character.enabled)
		{
			this.m_character.enabled = false;
			this.m_character.enabled = true;
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.m_InputBoxText[i] != null && this.m_InputBoxText[i].enabled)
			{
				this.m_InputBoxText[i].enabled = false;
				this.m_InputBoxText[i].enabled = true;
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
	}

	// Token: 0x06000E6E RID: 3694 RVA: 0x0017C364 File Offset: 0x0017A564
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 21)
		{
			if (this.Type == ECaseByCaseType.ECBCT_SaveTalent)
			{
				CString cstring = StringManager.Instance.StaticString1024();
				this.m_input.text.Trim();
				cstring.Append(this.m_input.text);
				DataManager.Instance.SaveTalentData[0].SetTagName(cstring);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Talent, -2, 0);
				GUIManager.Instance.CloseMenu(this.m_eWindow);
				return;
			}
			if (this.Type == ECaseByCaseType.ECBCT_EquipMemorySetup)
			{
				this.m_input.text.Trim();
				UILordEquipSetEdit.showingSet.Name.ClearString();
				UILordEquipSetEdit.showingSet.Name.Append(this.m_input.text);
				UILordEquipSetEdit.ThingsChanged = true;
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquipSetEdit, 1, 0);
				GUIManager.Instance.CloseMenu(this.m_eWindow);
				return;
			}
			if (this.Type == ECaseByCaseType.ECBCT_Preselectedteam)
			{
				this.m_input.text.Trim();
				DataManager.Instance.TeamName.ClearString();
				DataManager.Instance.TeamName.Append(this.m_input.text);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Expedition, 3, 0);
				GUIManager.Instance.CloseMenu(this.m_eWindow);
				return;
			}
			if (this.Type >= ECaseByCaseType.ECBCT_ReNickName)
			{
				this.OnCheck(this.m_input.text);
			}
			if (this.CheckTime > 0f || this.Tick.activeSelf)
			{
				this.Congrats(this.m_input.text.Trim());
			}
		}
		else
		{
			if (this.Type == ECaseByCaseType.ECBCT_Rename)
			{
				string text = this.DM.RoleAttr.Name.ToString();
				if (text.Substring(0, 3) == "ID." && NewbieManager.bShowRenameMessage)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(8055u), 255, true);
				}
				NewbieManager.bShowRenameMessage = false;
			}
			GUIManager.Instance.CloseMenu(this.m_eWindow);
		}
	}

	// Token: 0x04002E2D RID: 11821
	protected Door door;

	// Token: 0x04002E2E RID: 11822
	protected Text[] m_InputBoxText = new Text[3];

	// Token: 0x04002E2F RID: 11823
	protected Text m_butt;

	// Token: 0x04002E30 RID: 11824
	protected Text m_error;

	// Token: 0x04002E31 RID: 11825
	protected Text m_content;

	// Token: 0x04002E32 RID: 11826
	protected Text m_descript;

	// Token: 0x04002E33 RID: 11827
	protected Text m_character;

	// Token: 0x04002E34 RID: 11828
	protected InputField s_input;

	// Token: 0x04002E35 RID: 11829
	protected UIEmojiInput m_input;

	// Token: 0x04002E36 RID: 11830
	protected UISpritesArray USArray;

	// Token: 0x04002E37 RID: 11831
	protected Transform Transformer;

	// Token: 0x04002E38 RID: 11832
	protected GameObject Tick;

	// Token: 0x04002E39 RID: 11833
	protected GameObject Invalid;

	// Token: 0x04002E3A RID: 11834
	protected float CheckTime;

	// Token: 0x04002E3B RID: 11835
	public Protocol Checking;

	// Token: 0x04002E3C RID: 11836
	public Protocol Sending;

	// Token: 0x04002E3D RID: 11837
	public bool Check;

	// Token: 0x04002E3E RID: 11838
	public byte Tagging;

	// Token: 0x04002E3F RID: 11839
	public int Typing;

	// Token: 0x04002E40 RID: 11840
	public int Length;

	// Token: 0x04002E41 RID: 11841
	public int Limits;

	// Token: 0x04002E42 RID: 11842
	public int Counts;

	// Token: 0x04002E43 RID: 11843
	public long ItemID;

	// Token: 0x04002E44 RID: 11844
	public DataManager DM = DataManager.Instance;

	// Token: 0x04002E45 RID: 11845
	public StringBuilder Hint = new StringBuilder();

	// Token: 0x04002E46 RID: 11846
	private ECaseByCaseType Type;
}
