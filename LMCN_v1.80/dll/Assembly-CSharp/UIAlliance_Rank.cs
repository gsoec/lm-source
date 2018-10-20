using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200030E RID: 782
public class UIAlliance_Rank : IUIButtonDownUpHandler
{
	// Token: 0x06000FFC RID: 4092 RVA: 0x001C6B18 File Offset: 0x001C4D18
	public void OnOpen(Transform transform)
	{
		this.transform = transform;
		byte b = 0;
		while ((int)b < this.RankPoint.Length)
		{
			GUIManager.Instance.SetAllyRankImage(transform.GetChild(0).GetChild((int)b).GetChild(0).GetComponent<Image>(), b);
			this.Widths[(int)b] = transform.GetChild(0).GetChild((int)b).GetComponent<RectTransform>().sizeDelta.x;
			UIButtonHint uibuttonHint = transform.GetChild(0).GetChild((int)b).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_DownUpHandler = this;
			uibuttonHint.Parm1 = (ushort)(1028 - (int)b);
			this.RankPoint[(int)b] = transform.GetChild(1).GetChild((int)b);
			b += 1;
		}
		this.ImgUpRect = transform.GetChild(0).GetChild(5).GetComponent<RectTransform>();
		this.ImgUp = this.ImgUpRect.GetComponent<Image>();
		this.ImgDownRect = transform.GetChild(0).GetChild(6).GetComponent<RectTransform>();
		this.ImgDown = this.ImgDownRect.GetComponent<Image>();
		this.RankAnime.Initial(transform.GetChild(1).GetChild(5).GetComponent<Image>());
	}

	// Token: 0x06000FFD RID: 4093 RVA: 0x001C6C48 File Offset: 0x001C4E48
	public void UpdateRank()
	{
		if (this.AMRank == DataManager.Instance.RoleAlliance.AMRank && this.mMobilizationFutureRank == MobilizationManager.Instance.mMobilizationFutureRank && this.RankAnime.animImg.sprite != null)
		{
			return;
		}
		this.AMRank = DataManager.Instance.RoleAlliance.AMRank;
		this.mMobilizationFutureRank = MobilizationManager.Instance.mMobilizationFutureRank;
		byte b = (byte)Mathf.Clamp((int)this.mMobilizationFutureRank, 0, 4);
		byte b2 = (byte)Mathf.Clamp((int)this.AMRank, 0, 4);
		this.ImgUpRect.gameObject.SetActive(false);
		this.ImgDownRect.gameObject.SetActive(false);
		UIAlliance_Control.eRankState eRankState;
		if (b != b2)
		{
			if (b > b2)
			{
				eRankState = UIAlliance_Control.eRankState.RankUp;
			}
			else if (b < b2)
			{
				eRankState = UIAlliance_Control.eRankState.RankDown;
			}
			else
			{
				eRankState = UIAlliance_Control.eRankState.RankEqual;
			}
		}
		else
		{
			eRankState = UIAlliance_Control.eRankState.RankEqual;
		}
		bool flag = false;
		if (b != b2)
		{
			if (!byte.TryParse(PlayerPrefs.GetString("Alliance_RankAM"), out this.SavedData))
			{
				if (eRankState != UIAlliance_Control.eRankState.RankEqual)
				{
					flag = true;
				}
			}
			else if (this.SavedData / 10 != b || this.SavedData % 10 != b2)
			{
				flag = true;
			}
		}
		this.SavedData = b * 10 + b2;
		PlayerPrefs.SetString("Alliance_RankAM", this.SavedData.ToString());
		this.RankAnime.SetAnimState(eRankState);
		if (flag)
		{
			if (eRankState == UIAlliance_Control.eRankState.RankUp)
			{
				this.RankAnime.rectTransform.localPosition = new Vector3(this.RankPoint[(int)b2].localPosition.x, this.RankPoint[(int)b2].localPosition.y, 0f);
				float angle = 135f;
				this.ImgUpRect.gameObject.SetActive(true);
				this.ImgUpRect.anchoredPosition = new Vector2(this.ImgUpRect.anchoredPosition.x, 55f + 66f * (float)b2 - -2f);
				this.RankAnime.MoveTo(this.RankPoint[(int)b], 0f, angle, 1f);
			}
			else if (eRankState == UIAlliance_Control.eRankState.RankDown)
			{
				this.RankAnime.rectTransform.localPosition = new Vector3(this.RankPoint[(int)b2].localPosition.x, this.RankPoint[(int)b2].localPosition.y, 0f);
				float angle = 315f;
				this.ImgDownRect.gameObject.SetActive(true);
				this.ImgDownRect.anchoredPosition = new Vector2(this.ImgDownRect.anchoredPosition.x, -43f + 66f * (float)b2 - -2f);
				this.RankAnime.MoveTo(this.RankPoint[(int)b], 0f, angle, 1f);
			}
		}
		else
		{
			if (eRankState == UIAlliance_Control.eRankState.RankUp)
			{
				this.ImgUpRect.gameObject.SetActive(true);
				this.ImgUpRect.anchoredPosition = new Vector2(this.ImgUpRect.anchoredPosition.x, 55f + 66f * (float)b2 - -2f);
			}
			else if (eRankState == UIAlliance_Control.eRankState.RankDown)
			{
				this.ImgDownRect.gameObject.SetActive(true);
				this.ImgDownRect.anchoredPosition = new Vector2(this.ImgDownRect.anchoredPosition.x, -43f + 66f * (float)b2 - -2f);
			}
			this.RankAnime.rectTransform.localPosition = new Vector3(this.RankPoint[(int)b].localPosition.x, this.RankPoint[(int)b].localPosition.y, 0f);
		}
	}

	// Token: 0x06000FFE RID: 4094 RVA: 0x001C703C File Offset: 0x001C523C
	public void OnClose()
	{
		this.RankAnime.Destroy();
	}

	// Token: 0x06000FFF RID: 4095 RVA: 0x001C704C File Offset: 0x001C524C
	public void SetActive(bool bActive)
	{
		this.transform.gameObject.SetActive(bActive);
		if (bActive)
		{
			this.UpdateRank();
			this.SetAnimVisible = true;
		}
	}

	// Token: 0x1700007C RID: 124
	// (set) Token: 0x06001000 RID: 4096 RVA: 0x001C7080 File Offset: 0x001C5280
	public bool SetAnimVisible
	{
		set
		{
			this.RankAnime.rectTransform.gameObject.SetActive(value);
			this.ImgDown.enabled = value;
			this.ImgUp.enabled = value;
		}
	}

	// Token: 0x06001001 RID: 4097 RVA: 0x001C70BC File Offset: 0x001C52BC
	public void UpdateUI(int arg1, int arg2)
	{
		this.UpdateRank();
	}

	// Token: 0x06001002 RID: 4098 RVA: 0x001C70C4 File Offset: 0x001C52C4
	public void UpdateTime(bool bOnSecond)
	{
		if (!this.transform.gameObject.activeSelf)
		{
			return;
		}
		this.RankAnime.Update();
	}

	// Token: 0x06001003 RID: 4099 RVA: 0x001C70E8 File Offset: 0x001C52E8
	public void UpdateNetwork(byte[] meg)
	{
	}

	// Token: 0x06001004 RID: 4100 RVA: 0x001C70EC File Offset: 0x001C52EC
	public void OnButtonDown(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 277f, 20, (int)sender.Parm1, 0, new Vector2(this.Widths[(int)(4 - (sender.Parm1 - 1024))] * 0.5f, 0f), UIButtonHint.ePosition.Original);
	}

	// Token: 0x06001005 RID: 4101 RVA: 0x001C7140 File Offset: 0x001C5340
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(false);
	}

	// Token: 0x04003484 RID: 13444
	private const float ZVal = 0f;

	// Token: 0x04003485 RID: 13445
	private Transform transform;

	// Token: 0x04003486 RID: 13446
	private Transform[] RankPoint = new Transform[5];

	// Token: 0x04003487 RID: 13447
	private float[] Widths = new float[5];

	// Token: 0x04003488 RID: 13448
	private UIAlliance_Control RankAnime = new UIAlliance_Control();

	// Token: 0x04003489 RID: 13449
	private RectTransform ImgUpRect;

	// Token: 0x0400348A RID: 13450
	private RectTransform ImgDownRect;

	// Token: 0x0400348B RID: 13451
	private Image ImgDown;

	// Token: 0x0400348C RID: 13452
	private Image ImgUp;

	// Token: 0x0400348D RID: 13453
	private byte SavedData;

	// Token: 0x0400348E RID: 13454
	private byte AMRank;

	// Token: 0x0400348F RID: 13455
	private byte mMobilizationFutureRank;

	// Token: 0x0200030F RID: 783
	private enum UIControl
	{
		// Token: 0x04003491 RID: 13457
		Rank,
		// Token: 0x04003492 RID: 13458
		AnimPoint
	}
}
