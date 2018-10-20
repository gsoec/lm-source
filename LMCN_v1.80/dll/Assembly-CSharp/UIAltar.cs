using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004CD RID: 1229
public class UIAltar : GUIWindow, IBuildingWindowType
{
	// Token: 0x060018C8 RID: 6344 RVA: 0x002989F8 File Offset: 0x00296BF8
	public override void OnOpen(int arg1, int arg2)
	{
		this.TTF = GUIManager.Instance.GetTTFFont();
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.GM.AddSpriteAsset(this.SpAssName);
		this.m_Mat = this.GM.LoadMaterial(this.SpAssName, this.SpAssName_m);
		this.m_ManorID = (ushort)arg1;
		this.m_Particle = ParticleManager.Instance.Spawn(8, base.transform, new Vector3(-154f, 64f, -796f), 1f, false, true, true);
		GUIManager.Instance.SetLayer(this.m_Particle, 5);
		for (int i = 0; i < 2; i++)
		{
			this.m_AltarPanel[i] = base.transform.GetChild(i);
		}
		this.m_DarkTf = this.m_AltarPanel[0].GetChild(1);
		this.m_LightTf = this.m_AltarPanel[0].GetChild(2);
		this.m_TimeBar = this.m_AltarPanel[0].GetChild(3).GetComponent<UITimeBar>();
		this.m_TimeText = this.m_AltarPanel[0].GetChild(4).GetComponent<UIText>();
		this.m_TimeText.font = this.TTF;
		this.m_TimeText.text = this.DM.mStringTable.GetStringByID(5755u);
		this.m_DisableTf = this.m_AltarPanel[0].GetChild(5);
		Image component = this.m_AltarPanel[0].GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[4]);
		component.material = this.m_Mat;
		this.m_TitleText = this.m_AltarPanel[0].GetChild(0).GetChild(0).GetComponent<UIText>();
		this.m_TitleText.font = this.TTF;
		this.m_TitleText.text = this.DM.mStringTable.GetStringByID(5751u);
		component = this.m_AltarPanel[0].GetChild(5).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[6]);
		component.material = this.m_Mat;
		UIText component2 = this.m_AltarPanel[0].GetChild(5).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(5752u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		for (int j = 0; j < 4; j++)
		{
			component = this.m_AltarPanel[1].GetChild(j).GetChild(0).GetComponent<Image>();
			component.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[5]);
			component.material = this.m_Mat;
			this.m_ValueText[j].Icon = this.m_AltarPanel[1].GetChild(j).GetChild(1).GetComponent<Image>();
			this.m_ValueText[j].TitleText = this.m_AltarPanel[1].GetChild(j).GetChild(2).GetComponent<UIText>();
			this.m_ValueText[j].TitleText.font = this.TTF;
			this.m_ValueText[j].ValueText = this.m_AltarPanel[1].GetChild(j).GetChild(3).GetComponent<UIText>();
			this.m_ValueText[j].ValueText.font = this.TTF;
			this.m_ValueText[j].TitleStr = StringManager.Instance.SpawnString(30);
			this.m_ValueText[j].ValueStr = StringManager.Instance.SpawnString(30);
			this.m_ValueText[j].TempStr = StringManager.Instance.SpawnString(30);
		}
		this.GM.CreateTimerBar(this.m_TimeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
		this.SetType();
		this.m_BaseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.m_BaseBuild.m_Handler = this;
		this.m_BaseBuild.InitBuildingWindow(19, this.m_ManorID, 2, 0);
		this.m_BaseBuild.baseTransform.SetAsFirstSibling();
		this.m_BGFrame = base.transform.GetChild(0).GetChild(0).GetComponent<Image>();
		this.m_MainImage = base.transform.GetChild(0).GetChild(5).GetChild(1).GetComponent<Image>();
		this.m_ParticleMat = GUIManager.Instance.LoadMaterial("BuildingWindow", "BuildingWindow_m2");
		this.m_BGFrame.material = this.m_ParticleMat;
		this.m_MainImage.material = this.m_ParticleMat;
		this.GM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x060018C9 RID: 6345 RVA: 0x00298EF4 File Offset: 0x002970F4
	public override void OnClose()
	{
		for (int i = 0; i < 4; i++)
		{
			if (this.m_ValueText[i].TitleStr != null)
			{
				StringManager.Instance.DeSpawnString(this.m_ValueText[i].TitleStr);
			}
			if (this.m_ValueText[i].ValueStr != null)
			{
				StringManager.Instance.DeSpawnString(this.m_ValueText[i].ValueStr);
			}
			if (this.m_ValueText[i].TempStr != null)
			{
				StringManager.Instance.DeSpawnString(this.m_ValueText[i].TempStr);
			}
		}
		if (this.m_BaseBuild != null)
		{
			this.m_BaseBuild.DestroyBuildingWindow();
		}
		if (this.m_Particle)
		{
			ParticleManager.Instance.DeSpawn(this.m_Particle);
		}
		this.GM.RemoveSpriteAsset(this.SpAssName);
		this.GM.RemoverTimeBaarToList(this.m_TimeBar);
	}

	// Token: 0x060018CA RID: 6346 RVA: 0x00299008 File Offset: 0x00297208
	public override void UpdateUI(int arg1, int arg2)
	{
		this.SetType();
	}

	// Token: 0x060018CB RID: 6347 RVA: 0x00299010 File Offset: 0x00297210
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_BuildBase)
			{
				if (networkNews != NetworkNews.Refresh_AttribEffectVal)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						this.Refresh_FontTexture();
					}
				}
				else
				{
					this.SetType();
					this.m_BaseBuild.MyUpdate(0, false);
				}
			}
			else
			{
				this.SetType();
				this.m_BaseBuild.MyUpdate(meg[1], false);
			}
		}
		else
		{
			this.SetType();
			this.m_BaseBuild.MyUpdate(0, false);
		}
	}

	// Token: 0x060018CC RID: 6348 RVA: 0x0029909C File Offset: 0x0029729C
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
		{
			for (int i = 0; i < 2; i++)
			{
				this.m_AltarPanel[i].gameObject.SetActive(true);
			}
			if (this.m_Particle)
			{
				if (this.DM.m_AltarEffect.BeginTime > 0L)
				{
					this.m_Particle.gameObject.SetActive(true);
				}
				else
				{
					this.m_Particle.gameObject.SetActive(false);
				}
			}
		}
		else
		{
			if (this.m_Particle)
			{
				this.m_Particle.gameObject.SetActive(false);
			}
			for (int j = 0; j < 2; j++)
			{
				this.m_AltarPanel[j].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x060018CD RID: 6349 RVA: 0x0029917C File Offset: 0x0029737C
	private void SetType()
	{
		if (this.DM.m_AltarEffect.BeginTime != 0L)
		{
			this.SetValue(this.Color_Green);
			this.m_DisableTf.gameObject.SetActive(false);
			GUIManager.Instance.SetTimerBar(this.m_TimeBar, this.DM.m_AltarEffect.BeginTime, this.DM.m_AltarEffect.BeginTime + (long)((ulong)this.DM.m_AltarEffect.RequireTime), 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
			this.m_TimeBar.gameObject.SetActive(true);
			this.m_Particle.gameObject.SetActive(true);
			this.m_TimeText.gameObject.SetActive(true);
			this.m_DarkTf.gameObject.SetActive(false);
			this.m_LightTf.gameObject.SetActive(true);
			this.m_TitleText.text = this.DM.mStringTable.GetStringByID(5904u);
		}
		else
		{
			this.SetValue(this.Color_Red);
			this.m_TimeBar.gameObject.SetActive(false);
			this.m_DisableTf.gameObject.SetActive(true);
			this.m_Particle.gameObject.SetActive(false);
			this.m_TimeText.gameObject.SetActive(false);
			this.m_DarkTf.gameObject.SetActive(true);
			this.m_LightTf.gameObject.SetActive(false);
			this.m_TitleText.text = this.DM.mStringTable.GetStringByID(5751u);
		}
		this.m_TimeBar.gameObject.transform.GetChild(4).gameObject.SetActive(false);
		this.m_TimeBar.gameObject.transform.GetChild(5).gameObject.SetActive(false);
	}

	// Token: 0x060018CE RID: 6350 RVA: 0x00299358 File Offset: 0x00297558
	private void SetValue(Color color)
	{
		byte b = 0;
		if ((int)this.m_ManorID < this.GM.BuildingData.AllBuildsData.Length && this.m_ManorID >= 0)
		{
			b = this.GM.BuildingData.AllBuildsData[(int)this.m_ManorID].Level;
		}
		if (b <= 0)
		{
			b = 1;
		}
		BuildLevelRequest buildLevelRequestData = this.GM.BuildingData.GetBuildLevelRequestData(19, b);
		this.m_EffectTemp[0].Effect = buildLevelRequestData.Effect1;
		this.m_EffectTemp[1].Effect = buildLevelRequestData.Effect2;
		this.m_EffectTemp[2].Effect = buildLevelRequestData.Effect3;
		this.m_EffectTemp[3].Effect = buildLevelRequestData.Effect4;
		this.m_EffectTemp[0].Value = (ushort)buildLevelRequestData.Value1;
		this.m_EffectTemp[1].Value = (ushort)buildLevelRequestData.Value2;
		this.m_EffectTemp[2].Value = buildLevelRequestData.Value3;
		this.m_EffectTemp[3].Value = buildLevelRequestData.Value4;
		for (int i = 0; i < this.m_EffectTemp.Length; i++)
		{
			this.SetValueIcon(i, this.m_EffectTemp[i].Effect);
			GameConstants.GetEffectValue(this.m_ValueText[i].TitleStr, this.m_EffectTemp[i].Effect, 0u, 0, 0f);
			this.m_ValueText[i].TitleText.text = this.m_ValueText[i].TitleStr.ToString();
			this.m_ValueText[i].TitleText.SetAllDirty();
			this.m_ValueText[i].TitleText.cachedTextGenerator.Invalidate();
			GameConstants.GetEffectValue(this.m_ValueText[i].ValueStr, this.m_EffectTemp[i].Effect, (uint)this.m_EffectTemp[i].Value, 3, 0f);
			this.m_ValueText[i].TempStr.ClearString();
			if (this.GM.IsArabic)
			{
				this.m_ValueText[i].TempStr.Append(this.m_ValueText[i].ValueStr);
				this.m_ValueText[i].TempStr.Append(this.DM.mStringTable.GetStringByID(5805u));
			}
			else
			{
				this.m_ValueText[i].TempStr.Append(this.DM.mStringTable.GetStringByID(5805u));
				this.m_ValueText[i].TempStr.Append(this.m_ValueText[i].ValueStr);
			}
			this.m_ValueText[i].ValueText.text = this.m_ValueText[i].TempStr.ToString();
			this.m_ValueText[i].ValueText.color = color;
			this.m_ValueText[i].ValueText.SetAllDirty();
			this.m_ValueText[i].ValueText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x060018CF RID: 6351 RVA: 0x002996D0 File Offset: 0x002978D0
	private void SetValueIcon(int valueIdx, ushort effect)
	{
		if (valueIdx >= 0 && valueIdx < this.m_ValueText.Length)
		{
			switch (effect)
			{
			case 216:
				this.m_ValueText[valueIdx].Icon.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[0]);
				this.m_ValueText[valueIdx].Icon.material = this.m_Mat;
				this.m_ValueText[valueIdx].Icon.SetNativeSize();
				break;
			case 217:
				this.m_ValueText[valueIdx].Icon.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[1]);
				this.m_ValueText[valueIdx].Icon.material = this.m_Mat;
				this.m_ValueText[valueIdx].Icon.SetNativeSize();
				break;
			case 218:
				this.m_ValueText[valueIdx].Icon.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[2]);
				this.m_ValueText[valueIdx].Icon.material = this.m_Mat;
				this.m_ValueText[valueIdx].Icon.SetNativeSize();
				break;
			case 220:
				this.m_ValueText[valueIdx].Icon.sprite = this.GM.LoadSprite(this.SpAssName, this.IconName[3]);
				this.m_ValueText[valueIdx].Icon.material = this.m_Mat;
				this.m_ValueText[valueIdx].Icon.SetNativeSize();
				break;
			}
		}
	}

	// Token: 0x060018D0 RID: 6352 RVA: 0x002998B4 File Offset: 0x00297AB4
	public void Refresh_FontTexture()
	{
		if (this.m_TimeText != null && this.m_TimeText.enabled)
		{
			this.m_TimeText.enabled = false;
			this.m_TimeText.enabled = true;
		}
		if (this.m_TitleText != null && this.m_TitleText.enabled)
		{
			this.m_TitleText.enabled = false;
			this.m_TitleText.enabled = true;
		}
		if (this.m_ValueText != null)
		{
			for (int i = 0; i < this.m_ValueText.Length; i++)
			{
				if (this.m_ValueText[i].TitleText != null && this.m_ValueText[i].TitleText.enabled)
				{
					this.m_ValueText[i].TitleText.enabled = false;
					this.m_ValueText[i].TitleText.enabled = true;
				}
			}
		}
		if (this.m_TempText != null)
		{
			for (int j = 0; j < this.m_TempText.Length; j++)
			{
				if (this.m_TempText[j] != null && this.m_TempText[j].enabled)
				{
					this.m_TempText[j].enabled = false;
					this.m_TempText[j].enabled = true;
				}
			}
		}
		if (this.m_TimeBar != null && this.m_TimeBar.enabled)
		{
			this.m_TimeBar.Refresh_FontTexture();
		}
	}

	// Token: 0x0400491D RID: 18717
	private const int MaxTempTextNum = 2;

	// Token: 0x0400491E RID: 18718
	private GUIManager GM;

	// Token: 0x0400491F RID: 18719
	private DataManager DM;

	// Token: 0x04004920 RID: 18720
	private Font TTF;

	// Token: 0x04004921 RID: 18721
	private Color Color_Red = new Color(1f, 0.352f, 0.443f, 1f);

	// Token: 0x04004922 RID: 18722
	private Color Color_Green = new Color(0.207f, 0.968f, 0.423f, 1f);

	// Token: 0x04004923 RID: 18723
	private Transform[] m_AltarPanel = new Transform[2];

	// Token: 0x04004924 RID: 18724
	private Transform m_DarkTf;

	// Token: 0x04004925 RID: 18725
	private Transform m_LightTf;

	// Token: 0x04004926 RID: 18726
	private Transform m_DisableTf;

	// Token: 0x04004927 RID: 18727
	private BuildingWindow m_BaseBuild;

	// Token: 0x04004928 RID: 18728
	private UITimeBar m_TimeBar;

	// Token: 0x04004929 RID: 18729
	private UIText m_TimeText;

	// Token: 0x0400492A RID: 18730
	private UIText m_TitleText;

	// Token: 0x0400492B RID: 18731
	private ValueObj[] m_ValueText = new ValueObj[4];

	// Token: 0x0400492C RID: 18732
	private EffectTemp[] m_EffectTemp = new EffectTemp[4];

	// Token: 0x0400492D RID: 18733
	private Material m_Mat;

	// Token: 0x0400492E RID: 18734
	private GameObject m_Particle;

	// Token: 0x0400492F RID: 18735
	private Image m_BGFrame;

	// Token: 0x04004930 RID: 18736
	private Image m_MainImage;

	// Token: 0x04004931 RID: 18737
	private Material m_ParticleMat;

	// Token: 0x04004932 RID: 18738
	private ushort m_ManorID;

	// Token: 0x04004933 RID: 18739
	private string SpAssName = "BuildingWindow";

	// Token: 0x04004934 RID: 18740
	private string SpAssName_m = "BuildingWindow_m";

	// Token: 0x04004935 RID: 18741
	private string[] IconName = new string[]
	{
		"UI_con_icons_01",
		"UI_con_icons_03",
		"UI_con_icons_02",
		"UI_con_icons_04",
		"UI_con_frame_13",
		"UI_con_frame_25",
		"UI_altar_box_02"
	};

	// Token: 0x04004936 RID: 18742
	private UIText[] m_TempText = new UIText[2];

	// Token: 0x04004937 RID: 18743
	private int m_TempTextIdx;
}
