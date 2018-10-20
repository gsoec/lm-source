using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000205 RID: 517
public class UIChallegeTreasure : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06000983 RID: 2435 RVA: 0x000C3CB4 File Offset: 0x000C1EB4
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager instance = GUIManager.Instance;
		StringTable mStringTable = DataManager.Instance.mStringTable;
		Font ttffont = instance.GetTTFFont();
		this.FrameWidth = base.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
		this.TitleText = base.transform.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.TitleText.font = ttffont;
		this.TitleText.text = mStringTable.GetStringByID(12052u);
		this.ConfirmText = base.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>();
		this.ConfirmText.font = ttffont;
		this.ConfirmText.text = mStringTable.GetStringByID(189u);
		this.ConText = base.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
		this.ConText.font = ttffont;
		this.ConText.resizeTextForBestFit = false;
		this.ConText.rectTransform.sizeDelta = new Vector2(367.1f, 35f);
		this.LitTitleText = base.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
		this.LitTitleText.font = ttffont;
		this.LitTitleText.text = mStringTable.GetStringByID(12057u);
		this.DiamonStr = StringManager.Instance.SpawnString(30);
		this.LightT = base.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
		this.Light1T = base.transform.GetChild(0).GetChild(1).GetComponent<RectTransform>();
		this.ItemRect = base.transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
		instance.InitianHeroItemImg(this.ItemRect, eHeroOrItem.Item, 1224, 0, 0, arg1, true, false, true, false);
		this.DiamonCount = base.transform.GetChild(0).GetChild(2).GetChild(4).GetComponent<UIText>();
		this.Diamon = (ushort)arg1;
		this.DiamonStr.IntToFormat((long)this.Diamon, 1, true);
		this.DiamonStr.AppendFormat("{0}");
		this.DiamonCount.text = this.DiamonStr.ToString();
		this.ItemTitleStr = StringManager.Instance.SpawnString(30);
		this.ItemTitleText = base.transform.GetChild(0).GetChild(7).GetComponent<UIText>();
		this.ItemTitleText.font = ttffont;
		this.ItemTitleStr.IntToFormat((long)this.Diamon, 1, true);
		this.ItemTitleStr.AppendFormat(mStringTable.GetStringByID(8473u));
		this.ItemTitleText.text = this.ItemTitleStr.ToString();
		base.transform.GetChild(0).GetChild(3).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(1).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.UnlockImg = base.transform.GetChild(0).GetChild(6).GetComponent<Image>();
		this.ContStr = StringManager.Instance.SpawnString(30);
		int num = arg2 >> 8;
		int num2 = arg2 & 255;
		if (num2 >= 3)
		{
			this.LitTitleText.gameObject.SetActive(false);
			this.UnlockImg.gameObject.SetActive(false);
			this.SetSmallSize();
			return;
		}
		if (num2 > 0)
		{
			if (num2 == 1)
			{
				this.ContStr.IntToFormat(2L, 1, false);
			}
			else
			{
				this.ContStr.IntToFormat(3L, 1, false);
			}
			this.ContStr.AppendFormat(mStringTable.GetStringByID(12058u));
			this.ConText.text = this.ContStr.ToString();
			this.UpdateLockPos();
		}
		else
		{
			this.LitTitleText.gameObject.SetActive(false);
			this.UnlockImg.gameObject.SetActive(false);
			this.SetSmallSize();
		}
	}

	// Token: 0x06000984 RID: 2436 RVA: 0x000C40B8 File Offset: 0x000C22B8
	private void UpdateLockPos()
	{
		if (this.ConText.preferredWidth > 328f)
		{
			while (this.ConText.fontSize > 10 && this.ConText.preferredWidth > 328f)
			{
				this.ConText.fontSize--;
				this.ConText.SetLayoutDirty();
				this.ConText.cachedTextGeneratorForLayout.Invalidate();
			}
		}
		Vector2 vector = this.UnlockImg.rectTransform.anchoredPosition;
		vector.x = this.ConText.preferredWidth * -0.5f - 33f + 28.5f;
		this.UnlockImg.rectTransform.anchoredPosition = vector;
		vector = this.LitTitleText.rectTransform.anchoredPosition;
		vector.x = this.FrameWidth * 0.5f - this.ConText.preferredWidth * 0.5f + 33f - 3.3f;
		this.LitTitleText.rectTransform.anchoredPosition = vector;
		vector = this.LitTitleText.rectTransform.sizeDelta;
		vector.x = this.FrameWidth - this.LitTitleText.rectTransform.anchoredPosition.x - 55f;
		this.LitTitleText.rectTransform.sizeDelta = vector;
		vector = this.ConText.rectTransform.anchoredPosition;
		vector.x += 28.5f;
		this.ConText.rectTransform.anchoredPosition = vector;
	}

	// Token: 0x06000985 RID: 2437 RVA: 0x000C4250 File Offset: 0x000C2450
	private void SetSmallSize()
	{
		Vector2 anchoredPosition = this.LightT.anchoredPosition;
		anchoredPosition.y -= 30.5f;
		this.LightT.anchoredPosition = anchoredPosition;
		this.Light1T.anchoredPosition = anchoredPosition;
		RectTransform rectTransform = this.ItemTitleText.rectTransform;
		anchoredPosition = rectTransform.anchoredPosition;
		anchoredPosition.y -= 30.5f;
		rectTransform.anchoredPosition = anchoredPosition;
		rectTransform = base.transform.GetChild(0).GetChild(3).GetComponent<RectTransform>();
		anchoredPosition = rectTransform.anchoredPosition;
		anchoredPosition.y += 30.5f;
		rectTransform.anchoredPosition = anchoredPosition;
		base.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(481f, 493f);
	}

	// Token: 0x06000986 RID: 2438 RVA: 0x000C4320 File Offset: 0x000C2520
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1000)
		{
			GUIManager instance = GUIManager.Instance;
			base.transform.gameObject.SetActive(true);
			Array.Clear(instance.SE_Kind, 0, instance.SE_Kind.Length);
			Array.Clear(instance.SE_ItemID, 0, instance.SE_ItemID.Length);
			instance.m_SpeciallyEffect.mDiamondValue = (uint)this.Diamon;
			instance.SE_Kind[0] = SpeciallyEffect_Kind.TreasureBoxEX;
			instance.SE_ItemID[1] = 0;
			Vector2 sizeDelta = instance.m_UICanvas.GetComponent<RectTransform>().sizeDelta;
			instance.m_SpeciallyEffect.AddIconShow(new Vector2(sizeDelta.x * 0.5f, sizeDelta.y * 0.5f - 32f), instance.SE_Kind, instance.SE_ItemID, false);
		}
	}

	// Token: 0x06000987 RID: 2439 RVA: 0x000C43EC File Offset: 0x000C25EC
	public override void UpdateNetwork(byte[] meg)
	{
		if (meg[0] == 35)
		{
			this.TitleText.enabled = false;
			this.TitleText.enabled = true;
			this.ConfirmText.enabled = false;
			this.ConfirmText.enabled = true;
			this.DiamonCount.enabled = false;
			this.DiamonCount.enabled = true;
			this.ItemTitleText.enabled = false;
			this.ItemTitleText.enabled = true;
			this.LitTitleText.enabled = false;
			this.LitTitleText.enabled = true;
			this.ConText.enabled = false;
			this.ConText.enabled = true;
		}
	}

	// Token: 0x06000988 RID: 2440 RVA: 0x000C4494 File Offset: 0x000C2694
	public override void UpdateTime(bool bOnSecond)
	{
		this.LightT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		this.Light1T.Rotate(Vector3.forward * Time.smoothDeltaTime * 50f);
	}

	// Token: 0x06000989 RID: 2441 RVA: 0x000C44EC File Offset: 0x000C26EC
	public void OnButtonClick(UIButton sender)
	{
		GUIManager.Instance.CloseMenu(this.m_eWindow);
	}

	// Token: 0x0600098A RID: 2442 RVA: 0x000C4500 File Offset: 0x000C2700
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.DiamonStr);
		StringManager.Instance.DeSpawnString(this.ContStr);
		StringManager.Instance.DeSpawnString(this.ItemTitleStr);
	}

	// Token: 0x04001FC8 RID: 8136
	private UIText TitleText;

	// Token: 0x04001FC9 RID: 8137
	private UIText ConfirmText;

	// Token: 0x04001FCA RID: 8138
	private UIText DiamonCount;

	// Token: 0x04001FCB RID: 8139
	private UIText ConText;

	// Token: 0x04001FCC RID: 8140
	private UIText ItemTitleText;

	// Token: 0x04001FCD RID: 8141
	private UIText LitTitleText;

	// Token: 0x04001FCE RID: 8142
	private CString DiamonStr;

	// Token: 0x04001FCF RID: 8143
	private CString ContStr;

	// Token: 0x04001FD0 RID: 8144
	private CString ItemTitleStr;

	// Token: 0x04001FD1 RID: 8145
	private RectTransform LightT;

	// Token: 0x04001FD2 RID: 8146
	private RectTransform Light1T;

	// Token: 0x04001FD3 RID: 8147
	private RectTransform ItemRect;

	// Token: 0x04001FD4 RID: 8148
	private Image UnlockImg;

	// Token: 0x04001FD5 RID: 8149
	private float FrameWidth;

	// Token: 0x04001FD6 RID: 8150
	private ushort Diamon;

	// Token: 0x02000206 RID: 518
	private enum UIControl
	{
		// Token: 0x04001FD8 RID: 8152
		Frame,
		// Token: 0x04001FD9 RID: 8153
		Title
	}

	// Token: 0x02000207 RID: 519
	private enum TitleControl
	{
		// Token: 0x04001FDB RID: 8155
		Close,
		// Token: 0x04001FDC RID: 8156
		Title
	}

	// Token: 0x02000208 RID: 520
	private enum FrameControl
	{
		// Token: 0x04001FDE RID: 8158
		Light,
		// Token: 0x04001FDF RID: 8159
		Light1,
		// Token: 0x04001FE0 RID: 8160
		Item,
		// Token: 0x04001FE1 RID: 8161
		Confirm,
		// Token: 0x04001FE2 RID: 8162
		LitTitle,
		// Token: 0x04001FE3 RID: 8163
		Cont,
		// Token: 0x04001FE4 RID: 8164
		Unlock,
		// Token: 0x04001FE5 RID: 8165
		ItemTitle
	}
}
