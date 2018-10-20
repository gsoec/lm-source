using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000421 RID: 1057
public class _MissionSlot
{
	// Token: 0x0600157F RID: 5503 RVA: 0x0024D4F8 File Offset: 0x0024B6F8
	public void Init(Transform transform, UIMissionItem win)
	{
		this.transform = transform;
		this.NameStr = StringManager.Instance.SpawnString(100);
		this.NameText = transform.GetChild(0).GetComponent<UIText>();
		transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
		this.Reward = transform.GetChild(1).GetComponent<UIButton>();
		this.Reward.m_Handler = win;
		this.Reward.m_BtnID1 = 7;
		this.ItemBtn = transform.GetComponent<UIButton>();
		this.ItemBtn.m_BtnID1 = 11;
		this.RewardAlpha = transform.GetChild(1).GetChild(0).GetComponent<CanvasGroup>();
		UIText component = transform.GetChild(1).GetChild(1).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(1542u);
		this.SelectTrans = transform.GetChild(2);
	}

	// Token: 0x06001580 RID: 5504 RVA: 0x0024D5E0 File Offset: 0x0024B7E0
	public void SetText(CString Text)
	{
		this.NameStr.ClearString();
		this.NameStr.Append(Text);
		this.NameText.text = this.NameStr.ToString();
		this.NameText.SetAllDirty();
		this.NameText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001581 RID: 5505 RVA: 0x0024D638 File Offset: 0x0024B838
	public void Destroy()
	{
		StringManager.Instance.DeSpawnString(this.NameStr);
	}

	// Token: 0x06001582 RID: 5506 RVA: 0x0024D64C File Offset: 0x0024B84C
	public void Update()
	{
		if (!this.Reward.gameObject.activeSelf || this.TimdHandle == null)
		{
			return;
		}
		float deltaTime = this.TimdHandle.GetDeltaTime();
		float alpha = (deltaTime <= 1f) ? deltaTime : (2f - deltaTime);
		this.RewardAlpha.alpha = alpha;
	}

	// Token: 0x04003FA5 RID: 16293
	public Transform transform;

	// Token: 0x04003FA6 RID: 16294
	public Transform SelectTrans;

	// Token: 0x04003FA7 RID: 16295
	public UIText NameText;

	// Token: 0x04003FA8 RID: 16296
	public UIButton Reward;

	// Token: 0x04003FA9 RID: 16297
	public UIButton ItemBtn;

	// Token: 0x04003FAA RID: 16298
	public CString NameStr;

	// Token: 0x04003FAB RID: 16299
	private CanvasGroup RewardAlpha;

	// Token: 0x04003FAC RID: 16300
	public iMissionTimeDelta TimdHandle;

	// Token: 0x02000422 RID: 1058
	public enum UIControl
	{
		// Token: 0x04003FAE RID: 16302
		Text,
		// Token: 0x04003FAF RID: 16303
		RewardBtn,
		// Token: 0x04003FB0 RID: 16304
		Select
	}
}
