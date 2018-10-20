using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000626 RID: 1574
public class UIMall_FG : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
	// Token: 0x170000B9 RID: 185
	// (get) Token: 0x06001E5B RID: 7771 RVA: 0x003A3184 File Offset: 0x003A1384
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

	// Token: 0x06001E5C RID: 7772 RVA: 0x003A31B4 File Offset: 0x003A13B4
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.MM = MallManager.Instance;
		this.m_transform = base.transform;
		this.tmpFont = this.GM.GetTTFFont();
		this.LightT = this.m_transform.GetChild(0);
		this.m_transform.GetChild(1).GetComponent<UIButton>().m_Handler = this;
		this.RatioImage = this.m_transform.GetChild(1).GetChild(0).GetComponent<Image>();
		this.RatioText = this.m_transform.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.RatioText.font = this.tmpFont;
		this.RatioStr = StringManager.Instance.SpawnString(30);
		this.NeedCrystalText = this.m_transform.GetChild(2).GetChild(1).GetComponent<UIText>();
		this.NeedCrystalText.font = this.tmpFont;
		this.NeedCrystalStr = StringManager.Instance.SpawnString(50);
		this.MessageText = this.m_transform.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.MessageText.font = this.tmpFont;
		this.MessageStr = StringManager.Instance.SpawnString(500);
		this.TitleText = this.m_transform.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.TitleText.font = this.tmpFont;
		this.TitleText.text = this.DM.mStringTable.GetStringByID(17514u);
		this.TimeText = this.m_transform.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.TimeText.font = this.tmpFont;
		this.TimeStr = StringManager.Instance.SpawnString(30);
		this.m_transform.GetChild(6).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(7).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(7).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(7).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(7).GetComponent<CustomImage>().enabled = false;
		}
		this.ActorPosT = this.m_transform.GetChild(8);
		((RectTransform)this.ActorPosT).anchoredPosition = new Vector2(-300f, -470f);
		this.AB = AssetManager.GetAssetBundle("Role/Priest", out this.AssetKey, false);
		this.AR = this.AB.LoadAsync("Priest", typeof(GameObject));
		this.bABInitial = false;
		this.UpdateAll();
		if (this.MM.FullGift_Deadline == 0L)
		{
			this.bClose = true;
		}
	}

	// Token: 0x06001E5D RID: 7773 RVA: 0x003A34B4 File Offset: 0x003A16B4
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.RatioStr);
		StringManager.Instance.DeSpawnString(this.NeedCrystalStr);
		StringManager.Instance.DeSpawnString(this.MessageStr);
		StringManager.Instance.DeSpawnString(this.TimeStr);
		AssetManager.UnloadAssetBundle(this.AssetKey, true);
	}

	// Token: 0x06001E5E RID: 7774 RVA: 0x003A3514 File Offset: 0x003A1714
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
		if (!this.bABInitial && this.AR.isDone)
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
				for (int i = 0; i < 2; i++)
				{
					this.PriestAnimation[this.AnName1[i]].layer = 1;
					this.PlayTime1[i] = this.PriestAnimation[this.AnName1[i]].length;
				}
				for (int j = 0; j < 3; j++)
				{
					this.PriestAnimation[this.AnName2[j]].layer = 1;
					this.PlayTime2[j] = this.PriestAnimation[this.AnName2[j]].length;
				}
				this.PriestAnimation["idle"].layer = 0;
				this.PriestAnimation.Play("idle");
				this.PriestAnimation.CrossFade("talk");
				this.ReRandomTime = this.PriestAnimation["talk"].length;
				this.lastIdx = 4;
				this.PriestGO.GetComponentInChildren<SkinnedMeshRenderer>().useLightProbes = false;
			}
		}
		if (this.bABInitial)
		{
			this.ReRandomTime -= Time.smoothDeltaTime;
			if (this.ReRandomTime <= 0f)
			{
				this.ReRandomTime = this.RandomTime;
				int num = UnityEngine.Random.Range(1, 101);
				if (num > 40)
				{
					int num2;
					if (this.lastIdx == 0)
					{
						num2 = 1;
					}
					else if (this.lastIdx == 1)
					{
						num2 = 0;
					}
					else
					{
						num2 = num % this.PlayTime1.Length;
					}
					this.PriestAnimation.CrossFade(this.AnName1[num2], this.CrossFadeTime);
					this.ReRandomTime += this.PlayTime1[num2];
					this.lastIdx = num2;
				}
				else
				{
					int num3 = 0;
					if (this.lastIdx >= this.PlayTime1.Length)
					{
						this.lastIdx -= this.PlayTime1.Length;
						if (this.lastIdx >= 0 && this.lastIdx < this.PlayTime2.Length)
						{
							do
							{
								num3 = UnityEngine.Random.Range(0, this.PlayTime2.Length);
							}
							while (num3 == this.lastIdx);
						}
					}
					else
					{
						num3 = num % this.PlayTime2.Length;
					}
					this.PriestAnimation.CrossFade(this.AnName2[num3], this.CrossFadeTime);
					this.ReRandomTime += this.PlayTime2[num3];
					this.lastIdx = num3 + this.PlayTime1.Length;
				}
			}
		}
		if (this.TimeText != null)
		{
			this.ResourceRedTime += Time.deltaTime;
			if (this.ResourceRedTime >= 0.5f)
			{
				this.ResourceRedTime = 0f;
				this.bResourceRed = !this.bResourceRed;
				if (this.bResourceRed)
				{
					this.TimeText.color = Color.red;
				}
				else
				{
					this.TimeText.color = Color.white;
				}
			}
		}
	}

	// Token: 0x06001E5F RID: 7775 RVA: 0x003A397C File Offset: 0x003A1B7C
	private void UpdateTime()
	{
		if (this.TimeText == null)
		{
			return;
		}
		this.TimeStr.Length = 0;
		uint sec = (this.MM.FullGift_Deadline > this.DM.ServerTime) ? ((uint)(this.MM.FullGift_Deadline - this.DM.ServerTime)) : 0u;
		GameConstants.GetTimeString(this.TimeStr, sec, false, false, true, false, true);
		this.TimeText.text = this.TimeStr.ToString();
		this.TimeText.SetAllDirty();
		this.TimeText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001E60 RID: 7776 RVA: 0x003A3A24 File Offset: 0x003A1C24
	private void UpdateAll()
	{
		if (this.MessageText == null || this.MM.FullGift_Deadline == 0L)
		{
			return;
		}
		this.UpdateTime();
		uint num = this.MM.FullGift_MaxCrystal - this.MM.FullGift_NowCrystal;
		float num2 = (this.MM.FullGift_MaxCrystal != 0u) ? ((float)(this.MM.FullGift_NowCrystal / this.MM.FullGift_MaxCrystal)) : 0f;
		this.NeedCrystalStr.Length = 0;
		this.NeedCrystalStr.IntToFormat((long)((ulong)num), 1, true);
		this.NeedCrystalStr.AppendFormat(this.DM.mStringTable.GetStringByID(17513u));
		this.NeedCrystalText.text = this.NeedCrystalStr.ToString();
		this.NeedCrystalText.SetAllDirty();
		this.NeedCrystalText.cachedTextGenerator.Invalidate();
		this.MessageStr.Length = 0;
		this.MessageStr.IntToFormat((long)((ulong)num), 1, true);
		this.MessageStr.AppendFormat(this.DM.mStringTable.GetStringByID(17512u));
		this.MessageText.text = this.MessageStr.ToString();
		this.MessageText.SetAllDirty();
		this.MessageText.cachedTextGenerator.Invalidate();
		this.RatioStr.Length = 0;
		this.RatioStr.IntToFormat((long)((int)(num2 * 100f)), 1, false);
		this.RatioStr.AppendFormat("{0}%");
		this.RatioText.text = this.RatioStr.ToString();
		this.RatioText.SetAllDirty();
		this.RatioText.cachedTextGenerator.Invalidate();
		this.RatioImage.fillAmount = num2;
	}

	// Token: 0x06001E61 RID: 7777 RVA: 0x003A3BF4 File Offset: 0x003A1DF4
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
				if (this.RatioText != null && this.RatioText.enabled)
				{
					this.RatioText.enabled = false;
					this.RatioText.enabled = true;
				}
				if (this.NeedCrystalText != null && this.NeedCrystalText.enabled)
				{
					this.NeedCrystalText.enabled = false;
					this.NeedCrystalText.enabled = true;
				}
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
				if (this.TimeText != null && this.TimeText.enabled)
				{
					this.TimeText.enabled = false;
					this.TimeText.enabled = true;
				}
			}
			break;
		}
	}

	// Token: 0x06001E62 RID: 7778 RVA: 0x003A3D4C File Offset: 0x003A1F4C
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 0)
		{
			this.UpdateTime();
		}
		else if (arg1 == 1 || arg1 == 2)
		{
			if (this.MM.FullGift_Deadline == 0L && this.door)
			{
				this.door.CloseMenu(false);
			}
			this.UpdateAll();
		}
	}

	// Token: 0x06001E63 RID: 7779 RVA: 0x003A3DAC File Offset: 0x003A1FAC
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			if (this.door)
			{
				this.door.CloseMenu(false);
			}
		}
		else if (sender.m_BtnID1 == 2)
		{
			this.MM.Send_TREASUREBACK_PRIZEINFO();
		}
	}

	// Token: 0x06001E64 RID: 7780 RVA: 0x003A3E00 File Offset: 0x003A2000
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		if (this.door)
		{
			img.sprite = this.door.LoadSprite(ImageName);
			img.material = this.door.LoadMaterial();
		}
	}

	// Token: 0x04006004 RID: 24580
	private Transform m_transform;

	// Token: 0x04006005 RID: 24581
	private Transform ActorPosT;

	// Token: 0x04006006 RID: 24582
	private Transform LightT;

	// Token: 0x04006007 RID: 24583
	private DataManager DM;

	// Token: 0x04006008 RID: 24584
	private GUIManager GM;

	// Token: 0x04006009 RID: 24585
	private MallManager MM;

	// Token: 0x0400600A RID: 24586
	private Font tmpFont;

	// Token: 0x0400600B RID: 24587
	private Door m_door;

	// Token: 0x0400600C RID: 24588
	private int AssetKey;

	// Token: 0x0400600D RID: 24589
	private AssetBundle AB;

	// Token: 0x0400600E RID: 24590
	private AssetBundleRequest AR;

	// Token: 0x0400600F RID: 24591
	private bool bABInitial;

	// Token: 0x04006010 RID: 24592
	private GameObject PriestGO;

	// Token: 0x04006011 RID: 24593
	private Animation PriestAnimation;

	// Token: 0x04006012 RID: 24594
	private float CrossFadeTime = 0.4f;

	// Token: 0x04006013 RID: 24595
	private float ReRandomTime;

	// Token: 0x04006014 RID: 24596
	private float RandomTime;

	// Token: 0x04006015 RID: 24597
	private float[] PlayTime1 = new float[2];

	// Token: 0x04006016 RID: 24598
	private float[] PlayTime2 = new float[3];

	// Token: 0x04006017 RID: 24599
	private string[] AnName1 = new string[]
	{
		"idle",
		"idle04"
	};

	// Token: 0x04006018 RID: 24600
	private string[] AnName2 = new string[]
	{
		"idle02",
		"idle03",
		"talk"
	};

	// Token: 0x04006019 RID: 24601
	private int lastIdx;

	// Token: 0x0400601A RID: 24602
	private UIText RatioText;

	// Token: 0x0400601B RID: 24603
	private UIText NeedCrystalText;

	// Token: 0x0400601C RID: 24604
	private UIText MessageText;

	// Token: 0x0400601D RID: 24605
	private UIText TitleText;

	// Token: 0x0400601E RID: 24606
	private UIText TimeText;

	// Token: 0x0400601F RID: 24607
	private CString RatioStr;

	// Token: 0x04006020 RID: 24608
	private CString NeedCrystalStr;

	// Token: 0x04006021 RID: 24609
	private CString MessageStr;

	// Token: 0x04006022 RID: 24610
	private CString TimeStr;

	// Token: 0x04006023 RID: 24611
	private Image RatioImage;

	// Token: 0x04006024 RID: 24612
	private bool bResourceRed;

	// Token: 0x04006025 RID: 24613
	private float ResourceRedTime;

	// Token: 0x04006026 RID: 24614
	private bool bClose;
}
