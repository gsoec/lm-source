using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000218 RID: 536
public class UI_NewTerritory : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x060009CD RID: 2509 RVA: 0x000CDCA8 File Offset: 0x000CBEA8
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_transform = base.transform;
		Font ttffont = this.GM.GetTTFFont();
		if (this.GM.bOpenOnIPhoneX)
		{
			((RectTransform)this.m_transform).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0f);
			((RectTransform)this.m_transform).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0f);
		}
		int index = -1;
		int num = -1;
		this.GM.BuildingData.GetManorGroup((ushort)arg1, ref index, ref num);
		BuildManorData recordByIndex = this.DM.BuildManorData.GetRecordByIndex(index);
		if (recordByIndex.Kind < 1 || recordByIndex.Kind > 6)
		{
			return;
		}
		uint id;
		if (recordByIndex.MapGroup == 8)
		{
			this.ShowKind[0] = 3;
			this.ShowKind[1] = 6;
			id = 12105u;
		}
		else
		{
			this.ShowKind[0] = (ushort)recordByIndex.Kind;
			if (this.ShowKind[0] == 1)
			{
				id = 4065u;
			}
			else if (this.ShowKind[0] == 2)
			{
				id = 4066u;
			}
			else
			{
				id = 4067u;
			}
		}
		this.Back01T = this.m_transform.GetChild(0);
		this.TitleImgT = this.m_transform.GetChild(1);
		this.Back02T = this.m_transform.GetChild(2);
		this.Back03T = this.m_transform.GetChild(3);
		this.Back04T = this.m_transform.GetChild(4);
		for (int i = 0; i < 10; i++)
		{
			if (i < 5)
			{
				this.BuildingT[i] = this.Back03T.GetChild(i);
			}
			else
			{
				this.BuildingT[i] = this.Back04T.GetChild(i - 5);
			}
			this.BuildingImage[i] = this.BuildingT[i].GetChild(0).GetComponent<Image>();
			this.BuildingImage[i].material = this.GM.BuildingData.mapspriteManager.SpriteUIMaterial;
			this.BuildingImage[i].preserveAspect = true;
			this.BuildingImage[i].rectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
			this.BuildingText[i] = this.BuildingT[i].GetChild(1).GetComponent<UIText>();
			this.BuildingText[i].font = ttffont;
		}
		this.TitleText01T = this.m_transform.GetChild(5);
		this.RBText[0] = this.TitleText01T.GetComponent<UIText>();
		this.RBText[0].text = this.DM.mStringTable.GetStringByID(3810u);
		this.RBText[0].font = ttffont;
		this.TitleText02T = this.m_transform.GetChild(6);
		this.RBText[1] = this.TitleText02T.GetComponent<UIText>();
		this.RBText[1].text = this.DM.mStringTable.GetStringByID((uint)recordByIndex.ChapterID);
		this.RBText[1].font = ttffont;
		this.TitleText03T = this.m_transform.GetChild(7);
		this.RBText[2] = this.TitleText03T.GetComponent<UIText>();
		this.RBText[2].text = this.DM.mStringTable.GetStringByID(id);
		this.RBText[2].font = ttffont;
		this.CloseBtnT = this.m_transform.GetChild(8);
		this.CloseBtnT.GetComponent<UIButton>().m_Handler = this;
		int num2 = 0;
		for (int j = 0; j < this.ShowKind.Length; j++)
		{
			if (this.ShowKind[j] != 0)
			{
				ushort[] array = this.BuildID[(int)(this.ShowKind[j] - 1)];
				int num3 = 0;
				while (num3 < array.Length && num2 < 10)
				{
					BuildTypeData recordByKey = this.DM.BuildsTypeData.GetRecordByKey(array[num3]);
					if (recordByKey.BuildID == array[num3])
					{
						if (this.ShowKind[j] < 3 || this.ShowKind[j] > 6 || (this.GM.BuildingData.GetBuildNumByID(array[num3]) <= 0 && this.GM.BuildingData.AllBuildsData[(int)this.GM.BuildingData.BuildingManorID].BuildID != array[num3]))
						{
							this.BuildingText[num2].text = this.DM.mStringTable.GetStringByID((uint)recordByKey.NameID);
							this.BuildingImage[num2].sprite = this.GM.BuildingData.GetBuildSprite(array[num3], 1);
							UIButtonHint uibuttonHint = this.BuildingImage[num2].gameObject.AddComponent<UIButtonHint>();
							uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
							uibuttonHint.m_Handler = this;
							uibuttonHint.Parm1 = recordByKey.StringID;
							this.BuildingImage[num2].gameObject.AddComponent<ArabicItemTextureRot>();
							this.BuildingT[num2].gameObject.SetActive(true);
							num2++;
						}
					}
					num3++;
				}
			}
		}
		if (num2 > 5)
		{
			this.Back04T.gameObject.SetActive(true);
			Vector2 b = new Vector2(0f, 72f);
			((RectTransform)this.TitleImgT).anchoredPosition += b;
			((RectTransform)this.Back02T).anchoredPosition += b;
			((RectTransform)this.Back03T).anchoredPosition += b;
			((RectTransform)this.Back04T).anchoredPosition += b;
			((RectTransform)this.TitleText01T).anchoredPosition += b;
			((RectTransform)this.TitleText02T).anchoredPosition += b;
			((RectTransform)this.TitleText03T).anchoredPosition += b;
			((RectTransform)this.CloseBtnT).anchoredPosition += b;
			b.Set(0f, 144f);
			((RectTransform)this.Back01T).sizeDelta += b;
		}
		else if (num2 > 0 && num2 < 5)
		{
			int num4 = 640 / num2;
			Vector2 zero = Vector2.zero;
			for (int k = 0; k < num2; k++)
			{
				zero.Set((float)(-320 + num4 * (k + 1)) - (float)num4 * 0.5f, 0f);
				((RectTransform)this.BuildingT[k]).anchoredPosition = zero;
			}
		}
		Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.HideFightButton();
		}
	}

	// Token: 0x060009CE RID: 2510 RVA: 0x000CE3E0 File Offset: 0x000CC5E0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			for (int i = 0; i < this.BuildingText.Length; i++)
			{
				if (this.BuildingText[i] != null && this.BuildingText[i].enabled)
				{
					this.BuildingText[i].enabled = false;
					this.BuildingText[i].enabled = true;
				}
			}
			for (int j = 0; j < this.RBText.Length; j++)
			{
				if (this.RBText[j] != null && this.RBText[j].enabled)
				{
					this.RBText[j].enabled = false;
					this.RBText[j].enabled = true;
				}
			}
		}
	}

	// Token: 0x060009CF RID: 2511 RVA: 0x000CE4B8 File Offset: 0x000CC6B8
	public void OnButtonClick(UIButton sender)
	{
		DataManager.msgBuffer[0] = 20;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x060009D0 RID: 2512 RVA: 0x000CE4D0 File Offset: 0x000CC6D0
	public void OnButtonDown(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, (int)sender.Parm1, 0, Vector2.zero, UIButtonHint.ePosition.Original);
	}

	// Token: 0x060009D1 RID: 2513 RVA: 0x000CE504 File Offset: 0x000CC704
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(false);
	}

	// Token: 0x040020F9 RID: 8441
	private const byte MaxBuildCount = 10;

	// Token: 0x040020FA RID: 8442
	private Transform m_transform;

	// Token: 0x040020FB RID: 8443
	private Transform Back01T;

	// Token: 0x040020FC RID: 8444
	private Transform TitleImgT;

	// Token: 0x040020FD RID: 8445
	private Transform Back02T;

	// Token: 0x040020FE RID: 8446
	private Transform Back03T;

	// Token: 0x040020FF RID: 8447
	private Transform Back04T;

	// Token: 0x04002100 RID: 8448
	private Transform TitleText01T;

	// Token: 0x04002101 RID: 8449
	private Transform TitleText02T;

	// Token: 0x04002102 RID: 8450
	private Transform TitleText03T;

	// Token: 0x04002103 RID: 8451
	private Transform CloseBtnT;

	// Token: 0x04002104 RID: 8452
	private Transform[] BuildingT = new Transform[10];

	// Token: 0x04002105 RID: 8453
	private Image[] BuildingImage = new Image[10];

	// Token: 0x04002106 RID: 8454
	private UIText[] BuildingText = new UIText[10];

	// Token: 0x04002107 RID: 8455
	private GUIManager GM = GUIManager.Instance;

	// Token: 0x04002108 RID: 8456
	private DataManager DM = DataManager.Instance;

	// Token: 0x04002109 RID: 8457
	private ushort[] ShowKind = new ushort[2];

	// Token: 0x0400210A RID: 8458
	private ushort[][] BuildID = new ushort[][]
	{
		new ushort[]
		{
			1,
			2,
			3,
			4
		},
		new ushort[]
		{
			5,
			6,
			7
		},
		new ushort[]
		{
			9,
			10,
			11,
			13,
			14,
			15,
			17,
			18,
			19
		},
		new ushort[]
		{
			8
		},
		new ushort[]
		{
			12,
			16
		},
		new ushort[]
		{
			20,
			21,
			22,
			23
		}
	};

	// Token: 0x0400210B RID: 8459
	private UIText[] RBText = new UIText[3];
}
