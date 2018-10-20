using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020007EF RID: 2031
public class ScrollPanel_Horizontal : MonoBehaviour, IValueChanged, IScrollPanelItemHandler
{
	// Token: 0x06002A12 RID: 10770 RVA: 0x00467214 File Offset: 0x00465414
	public void onValueChanged()
	{
		this.MyUpdate();
	}

	// Token: 0x06002A13 RID: 10771 RVA: 0x0046721C File Offset: 0x0046541C
	public void ButtonOnClick(ScrollPanelItem sender)
	{
		if (this.m_handler != null)
		{
			this.m_handler.ButtonOnClick(sender.gameObject, sender.m_BtnID1, this.m_ScrollPanelID);
		}
	}

	// Token: 0x06002A14 RID: 10772 RVA: 0x00467254 File Offset: 0x00465454
	public void IntiScrollPanel(float _PanelWidth, float _Border, float _Range, List<float> _DataHeight, int _PanelObjectsCount, IUpDateScrollPanel _handler)
	{
		this.m_PanelWidth = _PanelWidth;
		this.m_Border = _Border;
		this.m_Range = _Range;
		this.m_MaxItemOfPage = _PanelObjectsCount;
		this.m_handler = _handler;
		this.m_TotalWidth = this.GetTotalWidth(_DataHeight, _Border, _Range);
		CScrollRect rect = this.CreateCScrollRect();
		this.m_Content = this.CreateContent(rect, out this.ContentRect, this.m_TotalWidth);
		RectTransform component = base.gameObject.GetComponent<RectTransform>();
		this.m_PanelSize = component.rect.size;
		this.CreatePanelObjects(out this.m_PanelObjects, this.m_MaxItemOfPage);
		this.UpdatePanelPostion(this.m_FirstIdx);
		if (this.m_customItem)
		{
			this.m_customItem.SetActive(false);
		}
		this.MyUpdate();
	}

	// Token: 0x06002A15 RID: 10773 RVA: 0x0046731C File Offset: 0x0046551C
	public int GetBeginIdx()
	{
		return this.beginIndex;
	}

	// Token: 0x06002A16 RID: 10774 RVA: 0x00467324 File Offset: 0x00465524
	public int GetTopIdx()
	{
		if (this.ContentRect == null || this.m_PanelObjects == null)
		{
			return -1;
		}
		float num = -this.ContentRect.anchoredPosition.x;
		for (int i = 0; i < this.m_MaxItemOfPage; i++)
		{
			int btnID = this.m_PanelObjects[i].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1;
			if (btnID != -1 && (Mathf.Approximately(num, this.m_PanelObjects[i].rectTransform.anchoredPosition.x) || num >= this.m_PanelObjects[i].rectTransform.anchoredPosition.x) && num <= this.m_PanelObjects[i].rectTransform.anchoredPosition.x + this.m_PanelObjects[i].rectTransform.sizeDelta.x + this.m_Range)
			{
				return btnID;
			}
		}
		return -1;
	}

	// Token: 0x06002A17 RID: 10775 RVA: 0x00467430 File Offset: 0x00465630
	public void AddItem(float width, bool bMoveToLast = false)
	{
		ItemData_H itemData_H = new ItemData_H();
		itemData_H.m_Width = width;
		itemData_H.m_LimitLeft = this.m_TotalWidth;
		this.m_DataList.Add(itemData_H);
		this.m_TotalWidth += width + this.m_Range;
		this.ContentRect.sizeDelta = new Vector2(this.m_TotalWidth, 0f);
		int idx;
		if (this.m_DataList.Count >= this.m_FirstIdx)
		{
			idx = this.m_FirstIdx;
		}
		else
		{
			idx = 0;
			this.m_LastIdx = 0;
		}
		this.UpdatePanelPostion(idx);
		if (bMoveToLast)
		{
			if (this.ContentRect.sizeDelta.y >= this.m_PanelWidth)
			{
				this.ContentRect.anchoredPosition = new Vector2(0f, 0f);
			}
			else
			{
				this.ContentRect.anchoredPosition = new Vector2(-(this.m_TotalWidth - this.m_PanelWidth), 0f);
			}
		}
		this.MyUpdate();
	}

	// Token: 0x06002A18 RID: 10776 RVA: 0x00467534 File Offset: 0x00465734
	public void AddNewDataHeight(List<float> _DataWidth, bool IsSetBeginPos = true, bool bSoptMove = true)
	{
		this.m_DataList.Clear();
		this.m_TotalWidth = this.m_Border;
		for (int i = 0; i < _DataWidth.Count; i++)
		{
			ItemData_H itemData_H = new ItemData_H();
			itemData_H.m_Width = _DataWidth[i];
			itemData_H.m_LimitLeft = this.m_TotalWidth;
			this.m_DataList.Add(itemData_H);
			this.m_TotalWidth += _DataWidth[i] + this.m_Range;
		}
		this.ContentRect.sizeDelta = new Vector2(this.m_TotalWidth, 0f);
		if (IsSetBeginPos)
		{
			this.ContentRect.anchoredPosition = new Vector2(0f, 0f);
			this.beginIndex = 0;
			this.m_FirstIdx = 0;
			this.m_LastIdx = 0;
		}
		if (_DataWidth.Count > 0 && this.beginIndex >= _DataWidth.Count)
		{
			this.beginIndex = _DataWidth.Count - 1;
		}
		this.UpdatePanelPostion(this.m_FirstIdx);
		this.MyUpdate();
		if (bSoptMove)
		{
			CScrollRect component = base.gameObject.GetComponent<CScrollRect>();
			if (component != null)
			{
				component.StopMovement();
			}
		}
	}

	// Token: 0x06002A19 RID: 10777 RVA: 0x00467668 File Offset: 0x00465868
	public void AddNewDataHeight(List<float> _DataHeight, float newWidth, bool IsSetBeginPos = true)
	{
		this.m_TotalWidth = newWidth;
		this.m_DataList.Clear();
		this.m_TotalWidth = this.m_Border;
		for (int i = 0; i < _DataHeight.Count; i++)
		{
			ItemData_H itemData_H = new ItemData_H();
			itemData_H.m_Width = _DataHeight[i];
			itemData_H.m_LimitLeft = this.m_TotalWidth;
			this.m_DataList.Add(itemData_H);
			this.m_TotalWidth += _DataHeight[i] + this.m_Range;
		}
		this.ContentRect.sizeDelta = new Vector2(this.m_TotalWidth, 0f);
		if (IsSetBeginPos)
		{
			this.ContentRect.anchoredPosition = new Vector2(0f, 0f);
			this.beginIndex = 0;
			this.m_FirstIdx = 0;
			this.m_LastIdx = 0;
		}
		this.UpdatePanelPostion(this.m_FirstIdx);
		this.MyUpdate();
		CScrollRect component = base.gameObject.GetComponent<CScrollRect>();
		if (component != null)
		{
			component.StopMovement();
		}
	}

	// Token: 0x06002A1A RID: 10778 RVA: 0x00467770 File Offset: 0x00465970
	public void GoTo(int itemidx, float width)
	{
		if (itemidx < 0 || itemidx >= this.m_DataList.Count || this.ContentRect.sizeDelta.x <= this.m_PanelWidth)
		{
			return;
		}
		CScrollRect component = base.gameObject.GetComponent<CScrollRect>();
		if (component != null)
		{
			component.StopMovement();
		}
		this.beginIndex = itemidx;
		float num = 0f;
		if (itemidx > 0)
		{
			num = this.m_Border;
		}
		for (int i = 0; i < itemidx; i++)
		{
			num += this.m_DataList[i].m_Width + this.m_Range;
			if (num > this.m_TotalWidth - this.m_PanelWidth)
			{
				this.beginIndex = i;
				num = this.m_TotalWidth - this.m_PanelSize.x;
				break;
			}
		}
		this.m_FirstIdx = 0;
		this.m_LastIdx = this.m_MaxItemOfPage - 1;
		this.UpdatePanelPostion(this.m_FirstIdx);
		this.ContentRect.anchoredPosition = new Vector2(width, 0f);
		this.MyUpdate();
	}

	// Token: 0x06002A1B RID: 10779 RVA: 0x0046788C File Offset: 0x00465A8C
	public void GoTo(int itemidx)
	{
		if (itemidx < 0 || itemidx >= this.m_DataList.Count || this.ContentRect.sizeDelta.x <= this.m_PanelWidth)
		{
			return;
		}
		CScrollRect component = base.gameObject.GetComponent<CScrollRect>();
		if (component != null)
		{
			component.StopMovement();
		}
		this.beginIndex = itemidx;
		float num = 0f;
		if (itemidx > 0)
		{
			num = this.m_Border;
		}
		for (int i = 0; i < itemidx; i++)
		{
			num += this.m_DataList[i].m_Width + this.m_Range;
			if (num > this.m_TotalWidth - this.m_PanelWidth)
			{
				this.beginIndex = i;
				num = this.m_TotalWidth - this.m_PanelSize.x;
				break;
			}
		}
		this.m_FirstIdx = 0;
		this.m_LastIdx = this.m_MaxItemOfPage - 1;
		this.UpdatePanelPostion(this.m_FirstIdx);
		this.ContentRect.anchoredPosition = new Vector2(-num, 0f);
		this.MyUpdate();
	}

	// Token: 0x06002A1C RID: 10780 RVA: 0x004679A8 File Offset: 0x00465BA8
	public float GetContentPos()
	{
		return this.ContentRect.anchoredPosition.x;
	}

	// Token: 0x06002A1D RID: 10781 RVA: 0x004679C8 File Offset: 0x00465BC8
	public void GoToLast()
	{
		if (!this.CheckAtLast())
		{
			this.GoTo(this.m_DataList.Count - 1, -(this.ContentRect.sizeDelta.x - this.m_PanelWidth));
		}
	}

	// Token: 0x06002A1E RID: 10782 RVA: 0x00467A10 File Offset: 0x00465C10
	private PanelObject AddContentObj(int btnID, GameObject item, Vector2 pos, float height, GameObject content)
	{
		RectTransform component = item.GetComponent<RectTransform>();
		if (component != null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(item) as GameObject;
			if (gameObject != null)
			{
				RectTransform component2 = gameObject.GetComponent<RectTransform>();
				ScrollPanelItem component3 = gameObject.GetComponent<ScrollPanelItem>();
				if (component2 != null && component3 != null)
				{
					component3.m_BtnID1 = btnID;
					component3.m_Handler = this;
					component2.anchoredPosition = pos;
					component2.anchorMax = new Vector2(0f, 1f);
					component2.anchorMin = new Vector2(0f, 1f);
					component2.pivot = new Vector2(0f, 1f);
					component2.sizeDelta = new Vector2(component.sizeDelta.x, component.sizeDelta.y);
					PanelObject panelObject = new PanelObject();
					panelObject.gameObject = gameObject;
					panelObject.rectTransform = component2;
					gameObject.transform.SetParent(content.transform, false);
					return panelObject;
				}
			}
		}
		return null;
	}

	// Token: 0x06002A1F RID: 10783 RVA: 0x00467B1C File Offset: 0x00465D1C
	private void MyUpdate()
	{
		if (this.m_Content == null || this.m_PanelObjects == null)
		{
			return;
		}
		float num = -this.ContentRect.anchoredPosition.x;
		if (this.beginIndex < this.m_DataList.Count)
		{
			float num2 = this.m_DataList[this.beginIndex].m_LimitLeft + this.m_DataList[this.beginIndex].m_Width;
			float num3 = 0f;
			if (this.beginIndex > 0)
			{
				num3 = this.m_DataList[this.beginIndex - 1].m_LimitLeft + this.m_DataList[this.beginIndex - 1].m_Width + this.m_Range;
			}
			bool flag = true;
			int num4 = Mathf.Clamp(this.m_MaxItemOfPage / 2, 1, this.m_MaxItemOfPage);
			while (flag && (num > num2 || num < num3) && num4 > 0)
			{
				if (num > num2)
				{
					flag = this.AddToLast();
				}
				else if (num < num3)
				{
					flag = this.AddToFirst();
				}
				num2 = this.m_DataList[this.beginIndex].m_LimitLeft + this.m_DataList[this.beginIndex].m_Width;
				if (this.beginIndex > 0)
				{
					num3 = this.m_DataList[this.beginIndex - 1].m_LimitLeft + this.m_DataList[this.beginIndex - 1].m_Width + this.m_Range;
				}
				num4--;
			}
		}
		this.HideOutsideObjects(num);
	}

	// Token: 0x06002A20 RID: 10784 RVA: 0x00467CCC File Offset: 0x00465ECC
	private bool AddToLast()
	{
		RectTransform rectTransform = this.m_PanelObjects[this.m_FirstIdx].rectTransform;
		int firstIdx = this.m_FirstIdx;
		if (this.beginIndex + this.m_MaxItemOfPage >= this.m_DataList.Count)
		{
			return false;
		}
		float width = this.m_DataList[this.beginIndex + this.m_MaxItemOfPage].m_Width;
		float limitLeft = this.m_DataList[this.beginIndex + this.m_MaxItemOfPage].m_LimitLeft;
		Vector2 anchoredPosition = new Vector2(limitLeft, 0f);
		rectTransform.anchoredPosition = anchoredPosition;
		rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);
		this.m_LastIdx = this.m_FirstIdx;
		if (this.m_FirstIdx + 1 >= this.m_MaxItemOfPage)
		{
			this.m_FirstIdx = 0;
		}
		else
		{
			this.m_FirstIdx++;
		}
		this.beginIndex++;
		rectTransform.gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + this.m_MaxItemOfPage - 1;
		if (this.m_handler != null)
		{
			this.m_handler.UpDateRowItem(rectTransform.gameObject, this.beginIndex + this.m_MaxItemOfPage - 1, firstIdx, this.m_ScrollPanelID);
		}
		return true;
	}

	// Token: 0x06002A21 RID: 10785 RVA: 0x00467E28 File Offset: 0x00466028
	private bool AddToFirst()
	{
		RectTransform rectTransform = this.m_PanelObjects[this.m_LastIdx].rectTransform;
		RectTransform rectTransform2 = this.m_PanelObjects[this.m_FirstIdx].rectTransform;
		if (this.beginIndex - 1 >= this.m_DataList.Count || this.beginIndex - 1 < 0)
		{
			return false;
		}
		float width = this.m_DataList[this.beginIndex - 1].m_Width;
		float limitLeft = this.m_DataList[this.beginIndex - 1].m_LimitLeft;
		Vector2 anchoredPosition = new Vector2(limitLeft, 0f);
		rectTransform.anchoredPosition = anchoredPosition;
		rectTransform.sizeDelta = new Vector2(width, rectTransform2.sizeDelta.y);
		this.m_FirstIdx = this.m_LastIdx;
		if (this.m_LastIdx == 0)
		{
			this.m_LastIdx = this.m_MaxItemOfPage - 1;
		}
		else
		{
			this.m_LastIdx--;
		}
		this.beginIndex--;
		rectTransform.gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex;
		if (this.m_handler != null)
		{
			this.m_handler.UpDateRowItem(rectTransform.gameObject, this.beginIndex, this.m_FirstIdx, this.m_ScrollPanelID);
		}
		return true;
	}

	// Token: 0x06002A22 RID: 10786 RVA: 0x00467F80 File Offset: 0x00466180
	public bool CheckAtLast()
	{
		return this.ContentRect == null || this.ContentRect.sizeDelta.x + this.ContentRect.anchoredPosition.x <= this.m_PanelWidth;
	}

	// Token: 0x06002A23 RID: 10787 RVA: 0x00467FD4 File Offset: 0x004661D4
	public bool CheckInPanel(int itemidx, bool CheckMiddle = false)
	{
		if (itemidx >= 0 && itemidx < this.m_DataList.Count && this.ContentRect != null)
		{
			float num = -this.ContentRect.anchoredPosition.x;
			if (CheckMiddle)
			{
				float num2 = this.m_DataList[itemidx].m_Width / 2f;
				if (this.m_DataList[itemidx].m_LimitLeft + num2 > num && this.m_DataList[itemidx].m_LimitLeft + num2 < this.m_PanelSize.x + num)
				{
					return true;
				}
			}
			else if (this.m_DataList[itemidx].m_LimitLeft + this.m_DataList[itemidx].m_Width > num && this.m_DataList[itemidx].m_LimitLeft < this.m_PanelSize.x + num)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06002A24 RID: 10788 RVA: 0x004680D4 File Offset: 0x004662D4
	private float GetTotalWidth(List<float> _DataWidth, float border, float range)
	{
		float num = border;
		this.m_DataList = new List<ItemData_H>(_DataWidth.Count);
		for (int i = 0; i < _DataWidth.Count; i++)
		{
			ItemData_H itemData_H = new ItemData_H();
			itemData_H.m_Width = _DataWidth[i];
			itemData_H.m_LimitLeft = num;
			this.m_DataList.Add(itemData_H);
			num += _DataWidth[i] + range;
		}
		return num;
	}

	// Token: 0x06002A25 RID: 10789 RVA: 0x00468140 File Offset: 0x00466340
	private CScrollRect CreateCScrollRect()
	{
		CScrollRect cscrollRect = base.gameObject.AddComponent<CScrollRect>();
		cscrollRect.m_Handler = this;
		cscrollRect.horizontal = true;
		cscrollRect.vertical = false;
		cscrollRect.inertia = true;
		cscrollRect.decelerationRate = 0.35f;
		cscrollRect.scrollSensitivity = 1f;
		Mask mask = base.gameObject.AddComponent<Mask>();
		mask.enabled = true;
		mask.showMaskGraphic = false;
		return cscrollRect;
	}

	// Token: 0x06002A26 RID: 10790 RVA: 0x004681AC File Offset: 0x004663AC
	private GameObject CreateContent(CScrollRect rect, out RectTransform _ContentRect, float _TotalWidth)
	{
		GameObject gameObject = new GameObject();
		gameObject.name = "Content";
		_ContentRect = gameObject.AddComponent<RectTransform>();
		_ContentRect.anchorMax = new Vector2(0f, 1f);
		_ContentRect.anchorMin = new Vector2(0f, 1f);
		_ContentRect.pivot = new Vector2(0f, 1f);
		_ContentRect.sizeDelta = new Vector2(_TotalWidth, 0f);
		rect.content = _ContentRect;
		_ContentRect.transform.SetParent(base.gameObject.transform, false);
		return gameObject;
	}

	// Token: 0x06002A27 RID: 10791 RVA: 0x00468248 File Offset: 0x00466448
	private void CreatePanelObjects(out PanelObject[] m_PanelObjects, int Max)
	{
		m_PanelObjects = new PanelObject[this.m_MaxItemOfPage];
		for (int i = 0; i < this.m_MaxItemOfPage; i++)
		{
			Vector2 pos = new Vector2(this.m_Border, 0f);
			m_PanelObjects[i] = this.AddContentObj(-1, this.m_customItem, pos, 0f, this.m_Content);
			this.m_LastIdx = i;
		}
	}

	// Token: 0x06002A28 RID: 10792 RVA: 0x004682B0 File Offset: 0x004664B0
	private void UpdatePanelPostion()
	{
		this.UpdatePanelPostion(this.m_FirstIdx);
	}

	// Token: 0x06002A29 RID: 10793 RVA: 0x004682C0 File Offset: 0x004664C0
	private void UpdatePanelPostion(int _idx)
	{
		int num = _idx;
		for (int i = 0; i < this.m_MaxItemOfPage; i++)
		{
			if (this.m_PanelObjects[num] != null)
			{
				if (this.m_handler != null && this.beginIndex + i < this.m_DataList.Count)
				{
					this.m_PanelObjects[num].rectTransform.sizeDelta = new Vector2(this.m_DataList[this.beginIndex + i].m_Width, this.m_PanelObjects[num].rectTransform.sizeDelta.y);
					Vector2 anchoredPosition = new Vector2(this.m_DataList[this.beginIndex + i].m_LimitLeft, 0f);
					this.m_PanelObjects[num].rectTransform.anchoredPosition = anchoredPosition;
					this.m_PanelObjects[num].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + i;
					this.m_handler.UpDateRowItem(this.m_PanelObjects[num].gameObject, this.beginIndex + i, num, this.m_ScrollPanelID);
				}
				else
				{
					float num2 = -this.ContentRect.anchoredPosition.y - this.m_PanelObjects[num].rectTransform.sizeDelta.x - this.m_Range;
					Vector2 anchoredPosition2 = new Vector2(-num2, 0f);
					this.m_PanelObjects[num].rectTransform.anchoredPosition = anchoredPosition2;
					this.m_PanelObjects[num].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = -1;
				}
				num++;
				if (num >= this.m_MaxItemOfPage)
				{
					num = 0;
				}
			}
		}
	}

	// Token: 0x06002A2A RID: 10794 RVA: 0x00468468 File Offset: 0x00466668
	private void HideOutsideObjects(float moveheight)
	{
		for (int i = 0; i < this.m_MaxItemOfPage; i++)
		{
			if (this.m_PanelObjects[i].rectTransform.anchoredPosition.x + this.m_PanelObjects[i].rectTransform.sizeDelta.x > moveheight && this.m_PanelObjects[i].rectTransform.anchoredPosition.x < this.m_PanelSize.x + moveheight && this.m_PanelObjects[i].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 != -1)
			{
				if (!this.m_PanelObjects[i].gameObject.activeSelf)
				{
					this.m_PanelObjects[i].gameObject.SetActive(true);
				}
			}
			else if (this.m_PanelObjects[i].gameObject.activeSelf)
			{
				this.m_PanelObjects[i].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x04007571 RID: 30065
	private float m_PanelWidth = 600f;

	// Token: 0x04007572 RID: 30066
	private float m_Border = 10f;

	// Token: 0x04007573 RID: 30067
	private float m_Range = 10f;

	// Token: 0x04007574 RID: 30068
	private int m_MaxItemOfPage;

	// Token: 0x04007575 RID: 30069
	private int beginIndex;

	// Token: 0x04007576 RID: 30070
	private float viewheight;

	// Token: 0x04007577 RID: 30071
	private float m_TotalWidth;

	// Token: 0x04007578 RID: 30072
	private List<ItemData_H> m_DataList;

	// Token: 0x04007579 RID: 30073
	private Vector2 m_PanelSize;

	// Token: 0x0400757A RID: 30074
	private GameObject m_Content;

	// Token: 0x0400757B RID: 30075
	private RectTransform ContentRect;

	// Token: 0x0400757C RID: 30076
	public GameObject m_customItem;

	// Token: 0x0400757D RID: 30077
	public PanelObject[] m_PanelObjects;

	// Token: 0x0400757E RID: 30078
	public int m_FirstIdx;

	// Token: 0x0400757F RID: 30079
	public int m_LastIdx;

	// Token: 0x04007580 RID: 30080
	public IUpDateScrollPanel m_handler;

	// Token: 0x04007581 RID: 30081
	public int m_ScrollPanelID;
}
