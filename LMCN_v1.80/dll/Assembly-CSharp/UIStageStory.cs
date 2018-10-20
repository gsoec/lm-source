using System;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x020004BF RID: 1215
public class UIStageStory : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001895 RID: 6293 RVA: 0x002947E8 File Offset: 0x002929E8
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_transform = base.transform;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		if (instance2.bOpenOnIPhoneX)
		{
			((RectTransform)this.m_transform).offsetMin = new Vector2(-instance2.IPhoneX_DeltaX, 0f);
			((RectTransform)this.m_transform).offsetMax = new Vector2(instance2.IPhoneX_DeltaX, 0f);
		}
		Transform child = this.m_transform.GetChild(0);
		child.GetComponent<uTweenScale>().duration = 0.5f;
		this.CloseBtnT = child.GetChild(7);
		this.CloseBtn = this.CloseBtnT.GetComponent<UIButton>();
		this.CloseBtn.m_Handler = this;
		this.Text3 = this.CloseBtnT.GetChild(0).GetComponent<UIText>();
		this.Text3.font = ttffont;
		this.Text3.text = instance.mStringTable.GetStringByID(189u);
		this.Text1 = child.GetChild(8).GetComponent<UIText>();
		this.Text1.font = ttffont;
		this.Text2 = child.GetChild(9).GetComponent<UIText>();
		this.Text2.font = ttffont;
		if (DataManager.StageDataController._stageMode == StageMode.Corps)
		{
			CorpsStage recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey((ushort)arg1);
			this.Text1.text = string.Empty;
			if (arg2 == 0)
			{
				this.Text2.text = instance.mStringTable.GetStringByID((uint)recordByKey.StageForeword);
			}
			else
			{
				this.Text2.text = instance.mStringTable.GetStringByID((uint)recordByKey.StageEndword);
			}
		}
		else
		{
			Chapter recordByKey2 = DataManager.StageDataController.ChapterTable.GetRecordByKey((ushort)arg1);
			this.Text1.text = string.Empty;
			this.Text2.text = instance.mStringTable.GetStringByID((uint)recordByKey2.OpenTipsID);
		}
		this.ActorPosT = child.GetChild(10);
		this.AB = AssetManager.GetAssetBundle("Role/Priest", out this.AssetKey, false);
		this.AR = this.AB.LoadAsync("Priest", typeof(GameObject));
		this.bABInitial = false;
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.HideFightButton();
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
	}

	// Token: 0x06001896 RID: 6294 RVA: 0x00294A64 File Offset: 0x00292C64
	public override void OnClose()
	{
		AssetManager.UnloadAssetBundle(this.AssetKey, true);
	}

	// Token: 0x06001897 RID: 6295 RVA: 0x00294A74 File Offset: 0x00292C74
	private void Update()
	{
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
	}

	// Token: 0x06001898 RID: 6296 RVA: 0x00294DFC File Offset: 0x00292FFC
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			if (this.Text3 != null && this.Text3.enabled)
			{
				this.Text3.enabled = false;
				this.Text3.enabled = true;
			}
			if (this.Text2 != null && this.Text2.enabled)
			{
				this.Text2.enabled = false;
				this.Text2.enabled = true;
			}
			if (this.Text1 != null && this.Text1.enabled)
			{
				this.Text1.enabled = false;
				this.Text1.enabled = true;
			}
		}
	}

	// Token: 0x06001899 RID: 6297 RVA: 0x00294ECC File Offset: 0x002930CC
	private void CloseSelf()
	{
		this.Text2.text = string.Empty;
		DataManager.msgBuffer[0] = 16;
		if (DataManager.StageDataController.isNotFirstInChapter[(int)DataManager.StageDataController._stageMode] == 0)
		{
			DataManager.StageDataController.isNotFirstInChapter[(int)DataManager.StageDataController._stageMode] = 1;
			DataManager.StageDataController.SaveisNotFirstInChapter();
		}
		else if (DataManager.StageDataController.limitRecord[(int)DataManager.StageDataController._stageMode] > DataManager.StageDataController.StageRecord[(int)DataManager.StageDataController._stageMode])
		{
			DataManager.StageDataController.isNotFirstInChapter[(int)DataManager.StageDataController._stageMode] = 0;
			DataManager.StageDataController.SaveisNotFirstInChapter();
		}
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x0600189A RID: 6298 RVA: 0x00294F8C File Offset: 0x0029318C
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			this.CloseSelf();
		}
	}

	// Token: 0x0600189B RID: 6299 RVA: 0x00294FA0 File Offset: 0x002931A0
	public override bool OnBackButtonClick()
	{
		this.CloseSelf();
		return true;
	}

	// Token: 0x04004884 RID: 18564
	private Transform m_transform;

	// Token: 0x04004885 RID: 18565
	private Transform ActorPosT;

	// Token: 0x04004886 RID: 18566
	private Transform CloseBtnT;

	// Token: 0x04004887 RID: 18567
	private UIButton CloseBtn;

	// Token: 0x04004888 RID: 18568
	private UIText Text1;

	// Token: 0x04004889 RID: 18569
	private UIText Text2;

	// Token: 0x0400488A RID: 18570
	private UIText Text3;

	// Token: 0x0400488B RID: 18571
	private int AssetKey;

	// Token: 0x0400488C RID: 18572
	private AssetBundle AB;

	// Token: 0x0400488D RID: 18573
	private AssetBundleRequest AR;

	// Token: 0x0400488E RID: 18574
	private bool bABInitial;

	// Token: 0x0400488F RID: 18575
	private GameObject PriestGO;

	// Token: 0x04004890 RID: 18576
	private Animation PriestAnimation;

	// Token: 0x04004891 RID: 18577
	private float CrossFadeTime = 0.4f;

	// Token: 0x04004892 RID: 18578
	private float ReRandomTime;

	// Token: 0x04004893 RID: 18579
	private float RandomTime;

	// Token: 0x04004894 RID: 18580
	private float[] PlayTime1 = new float[2];

	// Token: 0x04004895 RID: 18581
	private float[] PlayTime2 = new float[3];

	// Token: 0x04004896 RID: 18582
	private string[] AnName1 = new string[]
	{
		"idle",
		"idle04"
	};

	// Token: 0x04004897 RID: 18583
	private string[] AnName2 = new string[]
	{
		"idle02",
		"idle03",
		"talk"
	};

	// Token: 0x04004898 RID: 18584
	private int lastIdx;
}
