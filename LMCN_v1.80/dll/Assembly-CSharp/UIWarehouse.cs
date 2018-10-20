using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006BA RID: 1722
public class UIWarehouse : GUIWindow, IBuildingWindowType, UILoadImageHander
{
	// Token: 0x060020DE RID: 8414 RVA: 0x003E699C File Offset: 0x003E4B9C
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.AssetName = "BuildingWindow";
		this.m_BW = this.GUIM.AddSpriteAsset(this.AssetName);
		Transform transform = base.gameObject.transform;
		uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PROTCTION);
		this.mBD = this.GUIM.BuildingData.GetBuildData(9, 0);
		this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData(9, this.mBD.Level);
		float num = (10000u + effectBaseVal) / 10000f;
		this.m_Value[0] = GameConstants.appCeil(this.mBR.Value1 * num);
		if (this.mBR.ExtEffect1 != 0 && this.mBR.Value1 != 0u)
		{
			this.m_Value[1] = GameConstants.appCeil(this.mBR.Value1 * num);
		}
		for (int i = 0; i < 4; i++)
		{
			this.mListT[i] = transform.GetChild(i);
			this.mListRT[i] = this.mListT[i].GetComponent<RectTransform>();
			this.tmp_CusImg = this.mListT[i].GetComponent<CustomImage>();
			this.tmp_CusImg.hander = this;
			this.tmp_CusImg = this.mListT[i].GetChild(0).GetComponent<CustomImage>();
			this.tmp_CusImg.hander = this;
			this.text_tmpStr[i] = this.mListT[i].GetChild(1).GetComponent<UIText>();
			this.text_tmpStr[i].font = this.TTFont;
			this.text_tmpStr[i].text = this.DM.mStringTable.GetStringByID((uint)((ushort)(3937 + i)));
			this.text_ListValue[i] = this.mListT[i].GetChild(2).GetComponent<UIText>();
			this.text_ListValue[i].font = this.TTFont;
			this.tmpString.Length = 0;
			this.tmpString.AppendFormat("{0:N0}", this.m_Value[0]);
			this.text_ListValue[i].text = this.tmpString.ToString();
		}
		this.mListT[4] = transform.GetChild(4);
		this.tmp_CusImg = this.mListT[4].GetComponent<CustomImage>();
		this.tmp_CusImg.hander = this;
		this.tmp_CusImg = this.mListT[4].GetChild(0).GetComponent<CustomImage>();
		this.tmp_CusImg.hander = this;
		this.text_tmpStr[4] = this.mListT[4].GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[4].font = this.TTFont;
		this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(3936u);
		this.text_ListValue[4] = this.mListT[4].GetChild(2).GetComponent<UIText>();
		this.text_ListValue[4].font = this.TTFont;
		this.tmpString.Length = 0;
		this.tmpString.AppendFormat("{0:N0}", this.m_Value[1]);
		this.text_ListValue[4].text = this.tmpString.ToString();
		if (this.m_Value[1] != 0u)
		{
			for (int j = 0; j < 4; j++)
			{
				this.mListRT[j].anchoredPosition = new Vector2(this.mListRT[j].anchoredPosition.x, this.Img_top2 - (float)(j * 92));
			}
			this.mListT[4].gameObject.SetActive(true);
		}
		this.B_ID = arg1;
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x060020DF RID: 8415 RVA: 0x003E6D8C File Offset: 0x003E4F8C
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		if (this.AssetName != null)
		{
			GUIManager.Instance.RemoveSpriteAsset(this.AssetName);
		}
	}

	// Token: 0x060020E0 RID: 8416 RVA: 0x003E6DC8 File Offset: 0x003E4FC8
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing)
		{
			if (this.m_Value[1] != 0u)
			{
				this.mListT[4].gameObject.SetActive(true);
			}
			for (int i = 0; i < 4; i++)
			{
				this.mListT[i].gameObject.SetActive(true);
			}
		}
		else
		{
			for (int j = 0; j < 5; j++)
			{
				this.mListT[j].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x060020E1 RID: 8417 RVA: 0x003E6E54 File Offset: 0x003E5054
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		if (TextureName.Equals("UI_main") && this.door != null)
		{
			img.sprite = this.door.LoadSprite(ImageName);
			img.material = this.door.LoadMaterial();
		}
		else
		{
			img.sprite = this.GUIM.LoadSprite(this.AssetName, ImageName);
			img.material = this.m_BW;
		}
	}

	// Token: 0x060020E2 RID: 8418 RVA: 0x003E6ED0 File Offset: 0x003E50D0
	private void Start()
	{
		this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		byte level = GUIManager.Instance.BuildingData.AllBuildsData[this.B_ID].Level;
		this.baseBuild.InitBuildingWindow(9, (ushort)this.B_ID, 1, level);
		this.baseBuild.baseTransform.SetAsFirstSibling();
	}

	// Token: 0x060020E3 RID: 8419 RVA: 0x003E6F48 File Offset: 0x003E5148
	private void Update()
	{
	}

	// Token: 0x060020E4 RID: 8420 RVA: 0x003E6F4C File Offset: 0x003E514C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			if (this.baseBuild != null)
			{
				this.baseBuild.MyUpdate(0, false);
			}
			break;
		default:
			if (networkNews != NetworkNews.Refresh_BuildBase)
			{
				if (networkNews != NetworkNews.Refresh_AttribEffectVal)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						this.Refresh_FontTexture();
						if (this.baseBuild != null)
						{
							this.baseBuild.Refresh_FontTexture();
						}
					}
				}
				else
				{
					if (this.baseBuild != null)
					{
						this.baseBuild.MyUpdate(0, false);
					}
					uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STOREHOUSE_PROTECTION);
					uint effectBaseVal2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PROTCTION);
					float num = (10000u + effectBaseVal2) / 10000f;
					this.m_Value[0] = GameConstants.appCeil(effectBaseVal * num);
					for (int i = 0; i < 4; i++)
					{
						this.tmpString.Length = 0;
						this.tmpString.AppendFormat("{0:N0}", this.m_Value[0]);
						this.text_ListValue[i].text = this.tmpString.ToString();
					}
					if (this.m_Value[1] != 0u)
					{
						this.m_Value[1] = GameConstants.appCeil(effectBaseVal * num);
						this.tmpString.Length = 0;
						this.tmpString.AppendFormat("{0:N0}", this.m_Value[1]);
						this.text_ListValue[4].text = this.tmpString.ToString();
					}
				}
			}
			else
			{
				if (meg[1] == 1)
				{
					this.door.CloseMenu(true);
				}
				else if (this.baseBuild != null)
				{
					this.baseBuild.MyUpdate(meg[1], false);
				}
				this.mBD = this.GUIM.BuildingData.GetBuildData(9, 0);
				this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData(9, this.mBD.Level);
				uint effectBaseVal3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STOREHOUSE_PROTECTION);
				this.m_Value[0] = effectBaseVal3;
				if (this.mBR.ExtEffect1 != 0 && this.mBR.Value1 != 0u)
				{
					this.m_Value[1] = effectBaseVal3;
				}
				if (this.m_Value[1] != 0u)
				{
					for (int j = 0; j < 4; j++)
					{
						this.mListRT[j].anchoredPosition = new Vector2(this.mListRT[j].anchoredPosition.x, this.Img_top2 - (float)(j * 92));
					}
					this.mListT[4].gameObject.SetActive(true);
				}
			}
			break;
		}
	}

	// Token: 0x060020E5 RID: 8421 RVA: 0x003E722C File Offset: 0x003E542C
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < 5; i++)
		{
			if (this.text_ListValue[i] != null && this.text_ListValue[i].enabled)
			{
				this.text_ListValue[i].enabled = false;
				this.text_ListValue[i].enabled = true;
			}
			if (this.text_tmpStr[i] != null && this.text_tmpStr[i].enabled)
			{
				this.text_tmpStr[i].enabled = false;
				this.text_tmpStr[i].enabled = true;
			}
		}
	}

	// Token: 0x040067B2 RID: 26546
	private DataManager DM;

	// Token: 0x040067B3 RID: 26547
	private GUIManager GUIM;

	// Token: 0x040067B4 RID: 26548
	private RectTransform[] mListRT = new RectTransform[4];

	// Token: 0x040067B5 RID: 26549
	private Transform[] mListT = new Transform[5];

	// Token: 0x040067B6 RID: 26550
	private UIText[] text_ListValue = new UIText[5];

	// Token: 0x040067B7 RID: 26551
	private UIText[] text_tmpStr = new UIText[5];

	// Token: 0x040067B8 RID: 26552
	private CustomImage tmp_CusImg;

	// Token: 0x040067B9 RID: 26553
	private StringBuilder tmpString = new StringBuilder();

	// Token: 0x040067BA RID: 26554
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x040067BB RID: 26555
	private BuildingWindow baseBuild;

	// Token: 0x040067BC RID: 26556
	private RoleBuildingData mBD;

	// Token: 0x040067BD RID: 26557
	private BuildLevelRequest mBR;

	// Token: 0x040067BE RID: 26558
	private Material m_BW;

	// Token: 0x040067BF RID: 26559
	private int B_ID;

	// Token: 0x040067C0 RID: 26560
	private float Img_top2 = 125f;

	// Token: 0x040067C1 RID: 26561
	private Door door;

	// Token: 0x040067C2 RID: 26562
	private string AssetName;

	// Token: 0x040067C3 RID: 26563
	private uint[] m_Value = new uint[2];
}
