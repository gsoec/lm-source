using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200062B RID: 1579
public class UIMall_FT : GUIWindow, UILoadImageHander, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x170000BB RID: 187
	// (get) Token: 0x06001E78 RID: 7800 RVA: 0x003A4F0C File Offset: 0x003A310C
	public Door door
	{
		get
		{
			if (this.m_door == null)
			{
				this.m_door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
			}
			return this.m_door;
		}
	}

	// Token: 0x06001E79 RID: 7801 RVA: 0x003A4F3C File Offset: 0x003A313C
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.MM = MallManager.Instance;
		this.m_transform = base.transform;
		this.tmpFont = this.GM.GetTTFFont();
		this.LightT = this.m_transform.GetChild(0);
		this.tmpCB = this.DM.ComboBoxTable.GetRecordByKey(47);
		for (int i = 0; i < 4; i++)
		{
			this.Hbtn_Items[i] = this.m_transform.GetChild(5 + i).GetComponent<UIHIBtn>();
			this.Hbtn_Items[i].m_Handler = this;
			if (i == 0)
			{
				this.GM.InitianHeroItemImg(this.Hbtn_Items[i].transform, eHeroOrItem.Item, this.tmpCB.ItemData[i].ItemID, 0, 0, (int)this.tmpCB.ItemData[i].ItemCount, true, true, true, false);
			}
			else
			{
				this.GM.InitianHeroItemImg(this.Hbtn_Items[i].transform, eHeroOrItem.Item, this.tmpCB.ItemData[i].ItemID, 0, 0, 0, true, true, true, false);
			}
			if (this.Hbtn_Items[i].TextImage != null)
			{
				this.Hbtn_Items[i].TextImage.transform.SetParent(this.m_transform.GetChild(10), true);
			}
			if (this.Hbtn_Items[i].LvOrNum != null)
			{
				this.Hbtn_Items[i].LvOrNum.transform.SetParent(this.m_transform.GetChild(11), true);
			}
		}
		this.MessageText = this.m_transform.GetChild(13).GetComponent<UIText>();
		this.MessageText.font = this.tmpFont;
		this.MessageText.text = this.DM.mStringTable.GetStringByID(10185u);
		this.TitleText = this.m_transform.GetChild(12).GetComponent<UIText>();
		this.TitleText.font = this.tmpFont;
		this.TitleText.text = this.DM.mStringTable.GetStringByID(10190u);
		this.NumText1 = this.m_transform.GetChild(14).GetComponent<UIText>();
		this.NumText1.font = this.tmpFont;
		this.NumStr1 = StringManager.Instance.SpawnString(30);
		this.NumStr1.ClearString();
		this.NumStr1.IntToFormat((long)this.tmpCB.ItemData[1].ItemCount, 1, true);
		if (this.GM.IsArabic)
		{
			this.NumStr1.AppendFormat("{0}x");
		}
		else
		{
			this.NumStr1.AppendFormat("x{0}");
		}
		this.NumText1.text = this.NumStr1.ToString();
		this.NumText2 = this.m_transform.GetChild(15).GetComponent<UIText>();
		this.NumText2.font = this.tmpFont;
		this.NumStr2 = StringManager.Instance.SpawnString(30);
		this.NumStr2.ClearString();
		this.NumStr2.IntToFormat((long)this.tmpCB.ItemData[2].ItemCount, 1, true);
		if (this.GM.IsArabic)
		{
			this.NumStr2.AppendFormat("{0}x");
		}
		else
		{
			this.NumStr2.AppendFormat("x{0}");
		}
		this.NumText2.text = this.NumStr2.ToString();
		this.NumText3 = this.m_transform.GetChild(16).GetComponent<UIText>();
		this.NumText3.font = this.tmpFont;
		this.NumStr3 = StringManager.Instance.SpawnString(30);
		this.NumStr3.ClearString();
		this.NumStr3.IntToFormat((long)this.tmpCB.ItemData[3].ItemCount, 1, true);
		if (this.GM.IsArabic)
		{
			this.NumStr3.AppendFormat("{0}x");
		}
		else
		{
			this.NumStr3.AppendFormat("x{0}");
		}
		this.NumText3.text = this.NumStr3.ToString();
		this.m_transform.GetChild(9).GetComponent<CustomImage>().hander = this;
		UIButtonHint uibuttonHint = this.m_transform.GetChild(9).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = this.tmpCB.ItemData[0].ItemID;
		this.m_transform.GetChild(9).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(4).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(4).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(4).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(4).GetComponent<CustomImage>().enabled = false;
		}
		this.ActorPosT = this.m_transform.GetChild(17);
		((RectTransform)this.ActorPosT).localPosition = new Vector3(-300f, -300f, 290f);
		this.AB = AssetManager.GetAssetBundle("Role/hero_00029", out this.AssetKey, false);
		if (this.AB != null)
		{
			this.AR = this.AB.LoadAsync("m", typeof(GameObject));
			this.bABInitial = false;
		}
		Transform component = this.m_transform.GetChild(18).GetComponent<Transform>();
		component.localPosition = new Vector3(component.localPosition.x, component.localPosition.y, component.localPosition.z + 580f);
		component = this.m_transform.GetChild(19).GetComponent<Transform>();
		component.localPosition = new Vector3(component.localPosition.x, component.localPosition.y, component.localPosition.z + 580f);
		component = this.m_transform.GetChild(20).GetComponent<Transform>();
		component.localPosition = new Vector3(component.localPosition.x, component.localPosition.y, component.localPosition.z + 580f);
		this.door.m_Background.localPosition = new Vector3(this.door.m_Background.localPosition.x, this.door.m_Background.localPosition.y, 1000f);
		this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
	}

	// Token: 0x06001E7A RID: 7802 RVA: 0x003A566C File Offset: 0x003A386C
	public override void OnClose()
	{
		this.door.m_Background.localPosition = new Vector3(this.door.m_Background.localPosition.x, this.door.m_Background.localPosition.y, 0f);
		StringManager.Instance.DeSpawnString(this.NumStr1);
		StringManager.Instance.DeSpawnString(this.NumStr2);
		StringManager.Instance.DeSpawnString(this.NumStr3);
		AssetManager.UnloadAssetBundle(this.AssetKey, true);
	}

	// Token: 0x06001E7B RID: 7803 RVA: 0x003A5704 File Offset: 0x003A3904
	private void Update()
	{
		if (this.bClose)
		{
			this.bClose = false;
			if (this.door)
			{
				this.door.CloseMenu(false);
			}
			return;
		}
		if (this.LightT != null)
		{
			this.LightT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		if (!this.bABInitial && this.AR != null && this.AR.isDone)
		{
			this.bABInitial = true;
			this.PriestGO = (GameObject)UnityEngine.Object.Instantiate(this.AR.asset);
			if (this.PriestGO != null)
			{
				this.PriestGO.transform.SetParent(this.ActorPosT, false);
				this.PriestGO.transform.localPosition = Vector3.zero;
				this.PriestGO.transform.localRotation = new Quaternion(0f, -180f, 0f, 0f);
				this.PriestGO.transform.localScale = new Vector3(360f, 360f, 360f);
				GUIManager.Instance.SetLayer(this.PriestGO, 5);
				this.PriestAnimation = this.PriestGO.GetComponent<Animation>();
				this.PriestAnimation.wrapMode = WrapMode.Default;
				this.PriestAnimation["idle"].wrapMode = WrapMode.Loop;
				this.lastIdx = 4;
				this.PriestGO.GetComponentInChildren<SkinnedMeshRenderer>().useLightProbes = false;
			}
		}
	}

	// Token: 0x06001E7C RID: 7804 RVA: 0x003A58A4 File Offset: 0x003A3AA4
	private void UpdateTime()
	{
	}

	// Token: 0x06001E7D RID: 7805 RVA: 0x003A58A8 File Offset: 0x003A3AA8
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				if (this.MessageText != null && this.MessageText.enabled)
				{
					this.MessageText.enabled = false;
					this.MessageText.enabled = true;
				}
				if (this.TitleText != null && this.TitleText.enabled)
				{
					this.TitleText.enabled = false;
					this.TitleText.enabled = true;
				}
				if (this.NumText1 != null && this.NumText1.enabled)
				{
					this.NumText1.enabled = false;
					this.NumText1.enabled = true;
				}
				if (this.NumText2 != null && this.NumText2.enabled)
				{
					this.NumText2.enabled = false;
					this.NumText2.enabled = true;
				}
				if (this.NumText3 != null && this.NumText3.enabled)
				{
					this.NumText3.enabled = false;
					this.NumText3.enabled = true;
				}
				for (int i = 0; i < 4; i++)
				{
					if (this.Hbtn_Items[i] != null && this.Hbtn_Items[i].enabled)
					{
						this.Hbtn_Items[i].Refresh_FontTexture();
					}
				}
			}
			break;
		}
	}

	// Token: 0x06001E7E RID: 7806 RVA: 0x003A5A44 File Offset: 0x003A3C44
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 0)
		{
			this.UpdateTime();
		}
	}

	// Token: 0x06001E7F RID: 7807 RVA: 0x003A5A54 File Offset: 0x003A3C54
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1 && this.door)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001E80 RID: 7808 RVA: 0x003A5A8C File Offset: 0x003A3C8C
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		if (this.door)
		{
			img.sprite = this.door.LoadSprite(ImageName);
			img.material = this.door.LoadMaterial();
			if (img.sprite == null)
			{
				img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
				img.material = GUIManager.Instance.GetFrameMaterial();
			}
		}
	}

	// Token: 0x06001E81 RID: 7809 RVA: 0x003A5B00 File Offset: 0x003A3D00
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06001E82 RID: 7810 RVA: 0x003A5B04 File Offset: 0x003A3D04
	public void OnButtonDown(UIButtonHint sender)
	{
		this.GM.m_SimpleItemInfo.Show(sender, sender.Parm1, -1, UIButtonHint.ePosition.Original, null);
	}

	// Token: 0x06001E83 RID: 7811 RVA: 0x003A5B34 File Offset: 0x003A3D34
	public void OnButtonUp(UIButtonHint sender)
	{
		this.GM.m_SimpleItemInfo.Hide(sender);
	}

	// Token: 0x0400606D RID: 24685
	private Transform m_transform;

	// Token: 0x0400606E RID: 24686
	private Transform ActorPosT;

	// Token: 0x0400606F RID: 24687
	private Transform LightT;

	// Token: 0x04006070 RID: 24688
	private DataManager DM;

	// Token: 0x04006071 RID: 24689
	private GUIManager GM;

	// Token: 0x04006072 RID: 24690
	private MallManager MM;

	// Token: 0x04006073 RID: 24691
	private Font tmpFont;

	// Token: 0x04006074 RID: 24692
	private Door m_door;

	// Token: 0x04006075 RID: 24693
	private int AssetKey;

	// Token: 0x04006076 RID: 24694
	private AssetBundle AB;

	// Token: 0x04006077 RID: 24695
	private AssetBundleRequest AR;

	// Token: 0x04006078 RID: 24696
	private bool bABInitial;

	// Token: 0x04006079 RID: 24697
	private GameObject PriestGO;

	// Token: 0x0400607A RID: 24698
	private Animation PriestAnimation;

	// Token: 0x0400607B RID: 24699
	private float CrossFadeTime = 0.4f;

	// Token: 0x0400607C RID: 24700
	private float ReRandomTime;

	// Token: 0x0400607D RID: 24701
	private float RandomTime;

	// Token: 0x0400607E RID: 24702
	private float[] PlayTime1 = new float[2];

	// Token: 0x0400607F RID: 24703
	private float[] PlayTime2 = new float[3];

	// Token: 0x04006080 RID: 24704
	private string[] AnName1 = new string[]
	{
		"idle",
		"idle04"
	};

	// Token: 0x04006081 RID: 24705
	private string[] AnName2 = new string[]
	{
		"idle02",
		"idle03",
		"talk"
	};

	// Token: 0x04006082 RID: 24706
	private int lastIdx;

	// Token: 0x04006083 RID: 24707
	private UIText MessageText;

	// Token: 0x04006084 RID: 24708
	private UIText TitleText;

	// Token: 0x04006085 RID: 24709
	private UIText NumText1;

	// Token: 0x04006086 RID: 24710
	private UIText NumText2;

	// Token: 0x04006087 RID: 24711
	private UIText NumText3;

	// Token: 0x04006088 RID: 24712
	private CString NumStr1;

	// Token: 0x04006089 RID: 24713
	private CString NumStr2;

	// Token: 0x0400608A RID: 24714
	private CString NumStr3;

	// Token: 0x0400608B RID: 24715
	private bool bClose;

	// Token: 0x0400608C RID: 24716
	private ComboBox tmpCB;

	// Token: 0x0400608D RID: 24717
	private UIHIBtn[] Hbtn_Items = new UIHIBtn[4];
}
