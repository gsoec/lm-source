using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000753 RID: 1875
public class _MapHud
{
	// Token: 0x0600240C RID: 9228 RVA: 0x0041D890 File Offset: 0x0041BA90
	public void Init(Transform transform)
	{
		GUIManager instance = GUIManager.Instance;
		this.ThisTransform = transform;
		CustomImage component = this.ThisTransform.GetComponent<CustomImage>();
		instance.m_ItemInfo.LoadCustomImage(component, component.ImageName, component.TextureName);
		component = this.ThisTransform.GetChild(0).GetComponent<CustomImage>();
		instance.m_ItemInfo.LoadCustomImage(component, component.ImageName, component.TextureName);
		component = this.ThisTransform.GetChild(1).GetComponent<CustomImage>();
		instance.m_ItemInfo.LoadCustomImage(component, component.ImageName, component.TextureName);
		this.MsgStr = StringManager.Instance.SpawnString(150);
		this.Alpha = this.ThisTransform.GetComponent<CanvasGroup>();
		this.RectTextBack = this.ThisTransform.GetChild(0).GetComponent<RectTransform>();
		this.MsgText = this.RectTextBack.GetChild(0).GetComponent<UIText>();
		this.MsgText.font = GUIManager.Instance.GetTTFFont();
		this.MsgText.text = string.Empty;
		this.SkipMessage = 0;
	}

	// Token: 0x0600240D RID: 9229 RVA: 0x0041D9A4 File Offset: 0x0041BBA4
	public void AddChangeKindomMapMsg()
	{
		if (this.SkipMessage > 0)
		{
			return;
		}
		CString tmpS = StringManager.Instance.StaticString1024();
		this.MsgStr.ClearString();
		DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.FocusKingdomID, ref tmpS);
		this.MsgStr.StringToFormat(tmpS);
		this.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(802u));
		this.MsgText.text = this.MsgStr.ToString();
		this.MsgText.SetAllDirty();
		this.MsgText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x0600240E RID: 9230 RVA: 0x0041DA48 File Offset: 0x0041BC48
	public void AddManorMsg()
	{
		this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(716u);
	}

	// Token: 0x0600240F RID: 9231 RVA: 0x0041DA6C File Offset: 0x0041BC6C
	public void AddWorldMsg()
	{
		this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(803u);
	}

	// Token: 0x06002410 RID: 9232 RVA: 0x0041DA90 File Offset: 0x0041BC90
	public void AddChapterMsg()
	{
		switch (DataManager.StageDataController._stageMode)
		{
		case StageMode.Full:
			this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(716u + (uint)DataManager.StageDataController.currentChapterID);
			break;
		case StageMode.Lean:
			this.MsgStr.ClearString();
			this.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(60u));
			this.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(716u + (uint)DataManager.StageDataController.currentChapterID));
			this.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(59u));
			this.MsgText.text = this.MsgStr.ToString();
			this.MsgText.SetAllDirty();
			this.MsgText.cachedTextGenerator.Invalidate();
			break;
		case StageMode.Corps:
			if (DataManager.StageDataController.StageRecord[2] != DataManager.StageDataController.limitRecord[2])
			{
				this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID((uint)(716 + DataManager.StageDataController.StageRecord[2] + 1));
			}
			break;
		case StageMode.Dare:
			this.MsgStr.ClearString();
			this.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(10042u));
			this.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(716u + (uint)DataManager.StageDataController.currentChapterID));
			this.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(59u));
			this.MsgText.text = this.MsgStr.ToString();
			this.MsgText.SetAllDirty();
			this.MsgText.cachedTextGenerator.Invalidate();
			break;
		}
	}

	// Token: 0x06002411 RID: 9233 RVA: 0x0041DC90 File Offset: 0x0041BE90
	public void AddGambleMsg()
	{
		if (this.ThisTransform.gameObject.activeSelf)
		{
			this.ThisTransform.gameObject.SetActive(false);
		}
		if (BattleController.GambleMode == EGambleMode.Normal)
		{
			this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(9171u);
		}
		else
		{
			this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(9179u);
		}
	}

	// Token: 0x06002412 RID: 9234 RVA: 0x0041DD10 File Offset: 0x0041BF10
	public void SkipMsg()
	{
		this.SkipMessage = 1;
	}

	// Token: 0x06002413 RID: 9235 RVA: 0x0041DD1C File Offset: 0x0041BF1C
	public void ShowMsg()
	{
		if (this.SkipMessage > 0)
		{
			this.SkipMessage = 0;
			return;
		}
		if (this.MsgText.text == string.Empty || this.ThisTransform.gameObject.activeSelf)
		{
			return;
		}
		this.ThisTransform.gameObject.SetActive(true);
		this.Alpha.alpha = 1f;
		this.ShowTime = 0.5f;
		this.bStartCountdown = false;
		if (this.MsgText.preferredWidth > this.RectTextBack.sizeDelta.x)
		{
			Vector2 sizeDelta = this.RectTextBack.sizeDelta;
			sizeDelta.x = this.MsgText.preferredWidth;
			this.RectTextBack.sizeDelta = sizeDelta;
		}
	}

	// Token: 0x06002414 RID: 9236 RVA: 0x0041DDF0 File Offset: 0x0041BFF0
	public void StartCountdown()
	{
		this.bStartCountdown = true;
	}

	// Token: 0x06002415 RID: 9237 RVA: 0x0041DDFC File Offset: 0x0041BFFC
	public void Update()
	{
		if (!this.bStartCountdown || this.ThisTransform == null || !this.ThisTransform.gameObject.activeSelf)
		{
			return;
		}
		float num = -0.2f;
		if (this.ShowTime < 0f)
		{
			this.Alpha.alpha = 1f - this.ShowTime / num;
			if (this.ShowTime < num)
			{
				this.MsgText.text = string.Empty;
				this.ThisTransform.gameObject.SetActive(false);
			}
		}
		this.ShowTime -= Time.unscaledDeltaTime;
	}

	// Token: 0x06002416 RID: 9238 RVA: 0x0041DEAC File Offset: 0x0041C0AC
	public void Destroy()
	{
		StringManager.Instance.DeSpawnString(this.MsgStr);
	}

	// Token: 0x04006DF4 RID: 28148
	public Transform ThisTransform;

	// Token: 0x04006DF5 RID: 28149
	public CanvasGroup Alpha;

	// Token: 0x04006DF6 RID: 28150
	public RectTransform RectTextBack;

	// Token: 0x04006DF7 RID: 28151
	public UIText MsgText;

	// Token: 0x04006DF8 RID: 28152
	private CString MsgStr;

	// Token: 0x04006DF9 RID: 28153
	public float ShowTime;

	// Token: 0x04006DFA RID: 28154
	private bool bStartCountdown;

	// Token: 0x04006DFB RID: 28155
	private byte SkipMessage;
}
