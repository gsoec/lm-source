using System;
using UnityEngine;

// Token: 0x02000405 RID: 1029
public class FBFriendHint : IUIButtonClickHandler
{
	// Token: 0x06001524 RID: 5412 RVA: 0x002416BC File Offset: 0x0023F8BC
	public FBFriendHint(Transform transform, Font font, Transform blockTrans)
	{
		this.gameobject = transform.gameObject;
		this.UISelf = new _UIFBSelf(transform.GetChild(0), font);
		this.UIFriends = new _UIFBFriends(transform.GetChild(1), font, this, blockTrans);
	}

	// Token: 0x06001525 RID: 5413 RVA: 0x00241704 File Offset: 0x0023F904
	void IUIButtonClickHandler.OnButtonClick(UIButton sender)
	{
		Debug.Log("IUIButtonClickHandler.OnButtonClick");
		SocialFriend socialFriend;
		DataManager.FBMissionDataManager.GetFriendSocialInfo((byte)sender.m_BtnID1, sender.m_BtnID2, out socialFriend, true);
		if (socialFriend != null)
		{
			DataManager.Instance.ShowLordProfile(socialFriend.Name.ToString());
		}
	}

	// Token: 0x06001526 RID: 5414 RVA: 0x00241750 File Offset: 0x0023F950
	public void Show(ushort ID)
	{
		this.gameobject.SetActive(true);
		this.Progress = (byte)ID;
		this.FriendCount = DataManager.FBMissionDataManager.GetFriendCountByProgress(this.Progress);
		Debug.Log("count = " + this.FriendCount);
		if (this.FriendCount > 0)
		{
			if (!DataManager.FBMissionDataManager.IsInTime() || DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex == 12 || DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex != this.Progress)
			{
				this.UISelf.Hide();
				this.UIFriends.Show(this.Progress, this.FriendCount);
				this.UIFriends.Top = 0f;
				this.Height = this.UIFriends.Height;
				this.Width = this.UIFriends.Width;
			}
			else
			{
				this.UISelf.Top = -15f;
				this.UISelf.Height = 79f;
				this.UISelf.Show(_UIFBSelf._Style.Wide);
				this.UIFriends.Show(this.Progress, this.FriendCount);
				this.UIFriends.Top = -79f;
				this.Height = this.UIFriends.Height + 79f;
				this.Width = this.UIFriends.Width;
			}
		}
		else if (DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex != this.Progress)
		{
			this.UISelf.Hide();
			this.UIFriends.Hide();
			this.Height = -1f;
		}
		else
		{
			this.UISelf.Top = 0f;
			this.UISelf.Height = 100f;
			this.UISelf.Show(_UIFBSelf._Style.Narrow);
			this.UIFriends.Hide();
			this.Height = this.UISelf.Height;
			this.Width = this.UISelf.Width;
		}
	}

	// Token: 0x06001527 RID: 5415 RVA: 0x00241960 File Offset: 0x0023FB60
	private void SetStyle(FBFriendHint._Style style)
	{
		if (style == FBFriendHint._Style.Own)
		{
			this.Height = this.UISelf.Height;
		}
	}

	// Token: 0x06001528 RID: 5416 RVA: 0x0024197C File Offset: 0x0023FB7C
	public void Hide()
	{
		this.gameobject.SetActive(false);
	}

	// Token: 0x06001529 RID: 5417 RVA: 0x0024198C File Offset: 0x0023FB8C
	public void TextRefresh()
	{
		this.UISelf.TextRefresh();
		this.UIFriends.TextRefresh();
	}

	// Token: 0x0600152A RID: 5418 RVA: 0x002419A4 File Offset: 0x0023FBA4
	public void Destroy()
	{
		this.UIFriends.Destroy();
	}

	// Token: 0x0600152B RID: 5419 RVA: 0x002419B4 File Offset: 0x0023FBB4
	public void UpdateData()
	{
		if (!this.gameobject.activeSelf)
		{
			return;
		}
		byte friendCountByProgress = DataManager.FBMissionDataManager.GetFriendCountByProgress(this.Progress);
		if (DataManager.FBMissionDataManager.UpdateFriendSerialNo == 255 || this.FriendCount != friendCountByProgress)
		{
			this.Show((ushort)this.Progress);
			if (friendCountByProgress == 0 && DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex == this.Progress && !DataManager.FBMissionDataManager.IsInTime())
			{
				this.Hide();
				this.Height = -1f;
			}
			DataManager.FBMissionDataManager.UpdateFriendSerialNo = byte.MaxValue;
		}
		else
		{
			this.UIFriends.UpdateData();
		}
	}

	// Token: 0x0600152C RID: 5420 RVA: 0x00241A70 File Offset: 0x0023FC70
	public void UpdateTime()
	{
		this.UIFriends.UpdateTime();
	}

	// Token: 0x04003E19 RID: 15897
	public GameObject gameobject;

	// Token: 0x04003E1A RID: 15898
	private _UIFBSelf UISelf;

	// Token: 0x04003E1B RID: 15899
	private _UIFBFriends UIFriends;

	// Token: 0x04003E1C RID: 15900
	public float Height;

	// Token: 0x04003E1D RID: 15901
	public float Width;

	// Token: 0x04003E1E RID: 15902
	public byte FriendCount;

	// Token: 0x04003E1F RID: 15903
	public byte Progress;

	// Token: 0x02000406 RID: 1030
	private enum UIControl
	{
		// Token: 0x04003E21 RID: 15905
		Self,
		// Token: 0x04003E22 RID: 15906
		Friends
	}

	// Token: 0x02000407 RID: 1031
	private enum _Style
	{
		// Token: 0x04003E24 RID: 15908
		Own,
		// Token: 0x04003E25 RID: 15909
		Friend,
		// Token: 0x04003E26 RID: 15910
		Both
	}
}
