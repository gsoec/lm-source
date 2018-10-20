using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004FD RID: 1277
public class UIBlackList : GUIWindow, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001992 RID: 6546 RVA: 0x002B70F0 File Offset: 0x002B52F0
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_transform = base.transform;
		this.m_Font = this.GM.GetTTFFont();
		GUIManager.Instance.InitianHeroItemImg(this.m_transform.GetChild(5).GetChild(0), eHeroOrItem.Hero, 1, 2, 0, 0, false, false, true, false);
		this.m_transform.GetChild(6).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(6).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(6).GetChild(0).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(6).GetComponent<CustomImage>().enabled = false;
		}
		this.ScrollBL = this.m_transform.GetChild(4).GetComponent<ScrollPanel>();
		UIText component = this.m_transform.GetChild(2).GetComponent<UIText>();
		component.font = this.m_Font;
		component.text = this.DM.mStringTable.GetStringByID(6040u);
		this.NoMessageGO = this.m_transform.GetChild(3).gameObject;
		component = this.m_transform.GetChild(3).GetChild(0).GetComponent<UIText>();
		component.font = this.m_Font;
		component.text = this.DM.mStringTable.GetStringByID(8243u);
		for (int i = 0; i < 8; i++)
		{
			this.bFindScrollComp2[i] = false;
		}
		this.UpDateList(true);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001993 RID: 6547 RVA: 0x002B7290 File Offset: 0x002B5490
	private void SetIndexArray()
	{
		this.DataCount = (byte)this.DM.TalkData_BlackList.Count;
		if (this.DataCount > 0)
		{
			int num = 0;
			byte b = 0;
			while ((int)b < this.DM.TalkData_BlackList.Length && num < this.IndexArray.Length)
			{
				if (this.DM.TalkData_BlackList.Values[(int)b] != null)
				{
					this.IndexArray[num] = b;
					num++;
				}
				b += 1;
			}
		}
	}

	// Token: 0x06001994 RID: 6548 RVA: 0x002B7318 File Offset: 0x002B5518
	public override void UpdateUI(int arg1, int arg2)
	{
		this.UpDateList(false);
	}

	// Token: 0x06001995 RID: 6549 RVA: 0x002B7324 File Offset: 0x002B5524
	public void UpDateList(bool bFirst = false)
	{
		this.SetIndexArray();
		this.NowHeightList2.Clear();
		for (int i = 0; i < (int)this.DataCount; i++)
		{
			this.NowHeightList2.Add(85f);
		}
		if (this.DataCount > 0)
		{
			this.NoMessageGO.SetActive(false);
		}
		else
		{
			this.NoMessageGO.SetActive(true);
		}
		if (bFirst)
		{
			this.ScrollBL.IntiScrollPanel(525f, 0f, 0f, this.NowHeightList2, 8, this);
			this.ScrollRectBL = this.ScrollBL.GetComponent<CScrollRect>();
		}
		else
		{
			this.ScrollIndex = this.ScrollBL.GetTopIdx();
			this.ScrollPos = this.ScrollRectBL.content.anchoredPosition.y;
			this.ScrollBL.AddNewDataHeight(this.NowHeightList2, true, true);
			this.ScrollBL.GoTo(this.ScrollIndex, this.ScrollPos);
		}
	}

	// Token: 0x06001996 RID: 6550 RVA: 0x002B742C File Offset: 0x002B562C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < 8)
		{
			if (!this.bFindScrollComp2[panelObjectIdx])
			{
				this.bFindScrollComp2[panelObjectIdx] = true;
				Transform transform = item.transform;
				Transform child = transform.GetChild(2);
				this.Scroll_2_Comp[panelObjectIdx].unLockBtn = child.GetComponent<UIButton>();
				this.Scroll_2_Comp[panelObjectIdx].unLockBtn.m_Handler = this;
				UIText component = child.GetChild(0).GetComponent<UIText>();
				component.font = this.m_Font;
				component.text = this.DM.mStringTable.GetStringByID(8213u);
				this.Scroll_2_Comp[panelObjectIdx].PlayerT = transform.GetChild(0);
				this.Scroll_2_Comp[panelObjectIdx].PlayerText = transform.GetChild(1).GetComponent<UIText>();
				this.Scroll_2_Comp[panelObjectIdx].PlayerText.font = this.m_Font;
			}
			if (dataIdx < (int)this.DataCount)
			{
				byte b = this.IndexArray[dataIdx];
				this.Scroll_2_Comp[panelObjectIdx].unLockBtn.m_BtnID2 = (int)b;
				this.Scroll_2_Comp[panelObjectIdx].PlayerText.text = this.DM.TalkData_BlackList.Values[(int)b].PlayerName.ToString();
				GUIManager.Instance.ChangeHeroItemImg(this.Scroll_2_Comp[panelObjectIdx].PlayerT, eHeroOrItem.Hero, this.DM.TalkData_BlackList.Values[(int)b].PlayerPicID, 11, 0, 0);
			}
		}
	}

	// Token: 0x06001997 RID: 6551 RVA: 0x002B75B0 File Offset: 0x002B57B0
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			(this.GM.FindMenu(EGUIWindow.Door) as Door).CloseMenu(false);
		}
		else if (sender.m_BtnID1 == 2)
		{
			this.DM.RemoveBlackList(this.DM.TalkData_BlackList.Values[sender.m_BtnID2].PlayerName.GetHashCode(false), sender.m_BtnID2);
		}
	}

	// Token: 0x06001998 RID: 6552 RVA: 0x002B7624 File Offset: 0x002B5824
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001999 RID: 6553 RVA: 0x002B7628 File Offset: 0x002B5828
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x04004C13 RID: 19475
	private const int UnitCount2 = 8;

	// Token: 0x04004C14 RID: 19476
	private Transform m_transform;

	// Token: 0x04004C15 RID: 19477
	private DataManager DM = DataManager.Instance;

	// Token: 0x04004C16 RID: 19478
	private GUIManager GM = GUIManager.Instance;

	// Token: 0x04004C17 RID: 19479
	private ScrollPanel ScrollBL;

	// Token: 0x04004C18 RID: 19480
	private CScrollRect ScrollRectBL;

	// Token: 0x04004C19 RID: 19481
	private Font m_Font;

	// Token: 0x04004C1A RID: 19482
	private List<float> NowHeightList2 = new List<float>();

	// Token: 0x04004C1B RID: 19483
	private bool[] bFindScrollComp2 = new bool[8];

	// Token: 0x04004C1C RID: 19484
	private UnitComp2N[] Scroll_2_Comp = new UnitComp2N[8];

	// Token: 0x04004C1D RID: 19485
	private int ScrollIndex;

	// Token: 0x04004C1E RID: 19486
	private float ScrollPos;

	// Token: 0x04004C1F RID: 19487
	private byte DataCount;

	// Token: 0x04004C20 RID: 19488
	private byte[] IndexArray = new byte[100];

	// Token: 0x04004C21 RID: 19489
	private GameObject NoMessageGO;
}
