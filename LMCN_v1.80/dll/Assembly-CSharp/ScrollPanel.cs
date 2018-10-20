using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020007E7 RID: 2023
public class ScrollPanel : MonoBehaviour, IValueChanged, IScrollPanelItemHandler
{
	// Token: 0x060029F5 RID: 10741 RVA: 0x00465730 File Offset: 0x00463930
	public void IntiScrollPanel(float _PanelHeight, float _Border, float _Range, List<float> _DataHeight, int _PanelObjectsCount, IUpDateScrollPanel _handler)
	{
		this.m_PanelHeight = _PanelHeight;
		this.m_Border = _Border;
		this.m_Range = _Range;
		this.m_MaxItemOfPage = _PanelObjectsCount;
		this.m_handler = _handler;
		this.m_TotalHeight = this.m_Border;
		this.m_DataList = new List<ItemData>(_DataHeight.Count);
		for (int i = 0; i < _DataHeight.Count; i++)
		{
			ItemData itemData = new ItemData();
			itemData.m_Height = _DataHeight[i];
			itemData.m_limitTop = this.m_TotalHeight;
			this.m_DataList.Add(itemData);
			this.m_TotalHeight += _DataHeight[i] + this.m_Range;
		}
		if (this.m_DataList.Count > this.beginIndex)
		{
			this.viewheight += this.m_DataList[this.beginIndex].m_Height + this.m_Range;
		}
		CScrollRect cscrollRect = base.gameObject.AddComponent<CScrollRect>();
		cscrollRect.m_Handler = this;
		cscrollRect.horizontal = false;
		cscrollRect.vertical = true;
		cscrollRect.inertia = true;
		cscrollRect.decelerationRate = 0.35f;
		cscrollRect.scrollSensitivity = 1f;
		Mask mask = base.gameObject.AddComponent<Mask>();
		mask.enabled = true;
		mask.showMaskGraphic = false;
		RectTransform component = base.gameObject.GetComponent<RectTransform>();
		this.m_PanelSize = component.rect.size;
		this.m_Content = new GameObject();
		this.m_Content.name = "Content";
		this.ContentRect = this.m_Content.AddComponent<RectTransform>();
		this.ContentRect.anchorMax = new Vector2(0f, 1f);
		this.ContentRect.anchorMin = new Vector2(0f, 1f);
		this.ContentRect.pivot = new Vector2(0f, 1f);
		this.ContentRect.sizeDelta = new Vector2(0f, this.m_TotalHeight);
		cscrollRect.content = this.ContentRect;
		this.m_Content.transform.SetParent(base.gameObject.transform, false);
		this.m_PanelObjects = new PanelObject[this.m_MaxItemOfPage];
		for (int j = 0; j < this.m_MaxItemOfPage; j++)
		{
			Vector2 pos = new Vector2(0f, -this.m_Border);
			this.m_PanelObjects[j] = this.AddContentObj(-1, this.m_customItem, pos, 0f, this.m_Content);
			this.m_LastIdx = j;
		}
		int num = this.m_FirstIdx;
		int num2 = 0;
		while (num2 < this.m_MaxItemOfPage && num2 < this.m_DataList.Count)
		{
			if (this.m_handler != null && this.beginIndex + num2 < this.m_DataList.Count)
			{
				this.m_PanelObjects[num].rectTransform.sizeDelta = new Vector2(this.m_PanelObjects[num].rectTransform.sizeDelta.x, this.m_DataList[this.beginIndex + num2].m_Height);
				Vector2 a = new Vector2(0f, this.m_DataList[this.beginIndex + num2].m_limitTop);
				this.m_PanelObjects[num].rectTransform.anchoredPosition = -a;
				this.m_PanelObjects[num].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + num2;
				this.m_handler.UpDateRowItem(this.m_PanelObjects[num].gameObject, this.beginIndex + num2, num, this.m_ScrollPanelID);
				num++;
				if (num >= this.m_MaxItemOfPage)
				{
					num = 0;
				}
			}
			num2++;
		}
		if (this.m_customItem)
		{
			this.m_customItem.SetActive(false);
		}
		this.MyUpdate();
	}

	// Token: 0x060029F6 RID: 10742 RVA: 0x00465B34 File Offset: 0x00463D34
	public void onValueChanged()
	{
		this.MyUpdate();
	}

	// Token: 0x060029F7 RID: 10743 RVA: 0x00465B3C File Offset: 0x00463D3C
	public int GetBeginIdx()
	{
		return this.beginIndex;
	}

	// Token: 0x060029F8 RID: 10744 RVA: 0x00465B44 File Offset: 0x00463D44
	public int GetTopIdx()
	{
		if (this.ContentRect == null || this.m_PanelObjects == null)
		{
			return -1;
		}
		float y = this.ContentRect.anchoredPosition.y;
		for (int i = 0; i < this.m_MaxItemOfPage; i++)
		{
			int btnID = this.m_PanelObjects[i].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1;
			if (btnID != -1 && (Mathf.Approximately(y, -this.m_PanelObjects[i].rectTransform.anchoredPosition.y) || y >= -this.m_PanelObjects[i].rectTransform.anchoredPosition.y) && y <= -this.m_PanelObjects[i].rectTransform.anchoredPosition.y + this.m_PanelObjects[i].rectTransform.sizeDelta.y + this.m_Range)
			{
				return btnID;
			}
		}
		return -1;
	}

	// Token: 0x060029F9 RID: 10745 RVA: 0x00465C50 File Offset: 0x00463E50
	public void AddItem(float height, bool bMoveToLast = false)
	{
		ItemData itemData = new ItemData();
		itemData.m_Height = height;
		itemData.m_limitTop = this.m_TotalHeight;
		this.m_DataList.Add(itemData);
		this.m_TotalHeight += height + this.m_Range;
		this.ContentRect.sizeDelta = new Vector2(0f, this.m_TotalHeight);
		int num;
		if (this.m_DataList.Count >= this.m_FirstIdx)
		{
			num = this.m_FirstIdx;
		}
		else
		{
			num = 0;
			this.m_LastIdx = 0;
		}
		int num2 = 0;
		while (num2 < this.m_MaxItemOfPage && num2 < this.m_DataList.Count)
		{
			if (this.m_handler != null && this.beginIndex + num2 < this.m_DataList.Count)
			{
				this.m_PanelObjects[num].rectTransform.sizeDelta = new Vector2(this.m_PanelObjects[num].rectTransform.sizeDelta.x, this.m_DataList[this.beginIndex + num2].m_Height);
				Vector2 a = new Vector2(0f, this.m_DataList[this.beginIndex + num2].m_limitTop);
				this.m_PanelObjects[num].rectTransform.anchoredPosition = -a;
				this.m_PanelObjects[num].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + num2;
				this.m_handler.UpDateRowItem(this.m_PanelObjects[num].gameObject, this.beginIndex + num2, num, this.m_ScrollPanelID);
			}
			else
			{
				Vector2 anchoredPosition = new Vector2(0f, this.ContentRect.anchoredPosition.y + this.m_PanelObjects[num].rectTransform.sizeDelta.y + this.m_Range);
				this.m_PanelObjects[num].rectTransform.anchoredPosition = anchoredPosition;
				this.m_PanelObjects[num].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = -1;
			}
			num++;
			if (num >= this.m_MaxItemOfPage)
			{
				num = 0;
			}
			num2++;
		}
		this.MyUpdate();
		if (bMoveToLast)
		{
			if (this.ContentRect.sizeDelta.y <= this.m_PanelHeight)
			{
				this.ContentRect.anchoredPosition = new Vector2(0f, 0f);
			}
			else
			{
				this.ContentRect.anchoredPosition = new Vector2(0f, this.m_TotalHeight - this.m_PanelHeight);
			}
		}
	}

	// Token: 0x060029FA RID: 10746 RVA: 0x00465EE8 File Offset: 0x004640E8
	public void AddNewDataHeight(List<float> _DataHeight, bool IsSetBeginPos = true, bool bSoptMove = true)
	{
		this.m_DataList.Clear();
		this.m_TotalHeight = this.m_Border;
		for (int i = 0; i < _DataHeight.Count; i++)
		{
			ItemData itemData = new ItemData();
			itemData.m_Height = _DataHeight[i];
			itemData.m_limitTop = this.m_TotalHeight;
			this.m_DataList.Add(itemData);
			this.m_TotalHeight += _DataHeight[i] + this.m_Range;
		}
		this.ContentRect.sizeDelta = new Vector2(0f, this.m_TotalHeight);
		if (IsSetBeginPos)
		{
			this.ContentRect.anchoredPosition = new Vector2(0f, 0f);
			this.beginIndex = 0;
			this.m_FirstIdx = 0;
			this.m_LastIdx = 0;
		}
		if (_DataHeight.Count > 0 && this.beginIndex >= _DataHeight.Count)
		{
			this.beginIndex = _DataHeight.Count - 1;
		}
		int num = this.m_FirstIdx;
		for (int j = 0; j < this.m_MaxItemOfPage; j++)
		{
			if (this.m_handler != null)
			{
				if (this.beginIndex + j >= 0 && this.beginIndex + j < _DataHeight.Count)
				{
					Vector2 a = new Vector2(0f, this.m_DataList[this.beginIndex + j].m_limitTop);
					this.m_PanelObjects[num].rectTransform.anchoredPosition = -a;
					this.m_PanelObjects[num].rectTransform.sizeDelta = new Vector2(this.m_PanelObjects[num].rectTransform.sizeDelta.x, _DataHeight[this.beginIndex + j]);
					this.m_PanelObjects[num].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + j;
					this.m_handler.UpDateRowItem(this.m_PanelObjects[num].gameObject, this.beginIndex + j, num, this.m_ScrollPanelID);
				}
				else
				{
					Vector2 anchoredPosition = new Vector2(0f, this.ContentRect.anchoredPosition.y + this.m_PanelObjects[num].rectTransform.sizeDelta.y + this.m_Range);
					this.m_PanelObjects[num].rectTransform.anchoredPosition = anchoredPosition;
					this.m_PanelObjects[num].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = -1;
				}
				num++;
				if (num >= this.m_MaxItemOfPage)
				{
					num = 0;
				}
			}
		}
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

	// Token: 0x060029FB RID: 10747 RVA: 0x004661A4 File Offset: 0x004643A4
	public void AddNewDataHeight(List<float> _DataHeight, float newHeight, bool IsSetBeginPos = true)
	{
		this.m_PanelHeight = newHeight;
		this.m_DataList.Clear();
		this.m_TotalHeight = this.m_Border;
		for (int i = 0; i < _DataHeight.Count; i++)
		{
			ItemData itemData = new ItemData();
			itemData.m_Height = _DataHeight[i];
			itemData.m_limitTop = this.m_TotalHeight;
			this.m_DataList.Add(itemData);
			this.m_TotalHeight += _DataHeight[i] + this.m_Range;
		}
		this.ContentRect.sizeDelta = new Vector2(0f, this.m_TotalHeight);
		if (IsSetBeginPos)
		{
			this.ContentRect.anchoredPosition = new Vector2(0f, 0f);
			this.beginIndex = 0;
			this.m_FirstIdx = 0;
			this.m_LastIdx = 0;
		}
		int num = this.m_FirstIdx;
		for (int j = 0; j < this.m_MaxItemOfPage; j++)
		{
			if (this.m_handler != null)
			{
				if (this.beginIndex + j < _DataHeight.Count)
				{
					Vector2 a = new Vector2(0f, this.m_DataList[this.beginIndex + j].m_limitTop);
					this.m_PanelObjects[num].rectTransform.anchoredPosition = -a;
					this.m_PanelObjects[num].rectTransform.sizeDelta = new Vector2(this.m_PanelObjects[num].rectTransform.sizeDelta.x, _DataHeight[this.beginIndex + j]);
					this.m_PanelObjects[num].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + j;
					this.m_handler.UpDateRowItem(this.m_PanelObjects[num].gameObject, this.beginIndex + j, num, this.m_ScrollPanelID);
				}
				else
				{
					Vector2 anchoredPosition = new Vector2(0f, this.ContentRect.anchoredPosition.y + this.m_PanelObjects[num].rectTransform.sizeDelta.y + this.m_Range);
					this.m_PanelObjects[num].rectTransform.anchoredPosition = anchoredPosition;
					this.m_PanelObjects[num].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = -1;
				}
				num++;
				if (num >= this.m_MaxItemOfPage)
				{
					num = 0;
				}
			}
		}
		this.MyUpdate();
		CScrollRect component = base.gameObject.GetComponent<CScrollRect>();
		if (component != null)
		{
			component.StopMovement();
		}
	}

	// Token: 0x060029FC RID: 10748 RVA: 0x00466428 File Offset: 0x00464628
	public void GoTo(int itemidx)
	{
		if (itemidx < 0 || itemidx >= this.m_DataList.Count || this.ContentRect.sizeDelta.y <= this.m_PanelHeight)
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
			num += this.m_DataList[i].m_Height + this.m_Range;
			if (num > this.m_TotalHeight - this.m_PanelHeight)
			{
				this.beginIndex = i;
				num = this.m_TotalHeight - this.m_PanelSize.y;
				break;
			}
		}
		this.ContentRect.anchoredPosition = new Vector2(0f, num);
		int num2 = 0;
		this.m_FirstIdx = 0;
		this.m_LastIdx = this.m_MaxItemOfPage - 1;
		int num3 = 0;
		while (num3 < this.m_MaxItemOfPage && num3 < this.m_DataList.Count)
		{
			if (this.m_handler != null && this.beginIndex + num3 < this.m_DataList.Count)
			{
				this.m_PanelObjects[num2].rectTransform.sizeDelta = new Vector2(this.m_PanelObjects[num2].rectTransform.sizeDelta.x, this.m_DataList[this.beginIndex + num3].m_Height);
				Vector2 a = new Vector2(0f, this.m_DataList[this.beginIndex + num3].m_limitTop);
				this.m_PanelObjects[num2].rectTransform.anchoredPosition = -a;
				this.m_PanelObjects[num2].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + num3;
				this.m_handler.UpDateRowItem(this.m_PanelObjects[num2].gameObject, this.beginIndex + num3, num2, this.m_ScrollPanelID);
			}
			else
			{
				Vector2 anchoredPosition = new Vector2(0f, this.ContentRect.anchoredPosition.y + this.m_PanelObjects[num2].rectTransform.sizeDelta.y + this.m_Range);
				this.m_PanelObjects[num2].rectTransform.anchoredPosition = anchoredPosition;
				this.m_PanelObjects[num2].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = -1;
			}
			num2++;
			if (num2 >= this.m_MaxItemOfPage)
			{
				num2 = 0;
			}
			num3++;
		}
		this.MyUpdate();
	}

	// Token: 0x060029FD RID: 10749 RVA: 0x004666E0 File Offset: 0x004648E0
	public void GoTo(int itemidx, float height)
	{
		if (itemidx < 0 || itemidx >= this.m_DataList.Count || this.ContentRect.sizeDelta.y <= this.m_PanelHeight)
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
			num += this.m_DataList[i].m_Height + this.m_Range;
			if (num > this.m_TotalHeight - this.m_PanelHeight)
			{
				this.beginIndex = i;
				num = this.m_TotalHeight - this.m_PanelSize.y;
				break;
			}
		}
		int num2 = 0;
		this.m_FirstIdx = 0;
		this.m_LastIdx = this.m_MaxItemOfPage - 1;
		int num3 = 0;
		while (num3 < this.m_MaxItemOfPage && num3 < this.m_DataList.Count)
		{
			if (this.m_handler != null && this.beginIndex + num3 < this.m_DataList.Count)
			{
				this.m_PanelObjects[num2].rectTransform.sizeDelta = new Vector2(this.m_PanelObjects[num2].rectTransform.sizeDelta.x, this.m_DataList[this.beginIndex + num3].m_Height);
				Vector2 a = new Vector2(0f, this.m_DataList[this.beginIndex + num3].m_limitTop);
				this.m_PanelObjects[num2].rectTransform.anchoredPosition = -a;
				this.m_PanelObjects[num2].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = this.beginIndex + num3;
				this.m_handler.UpDateRowItem(this.m_PanelObjects[num2].gameObject, this.beginIndex + num3, num2, this.m_ScrollPanelID);
			}
			else
			{
				Vector2 anchoredPosition = new Vector2(0f, this.ContentRect.anchoredPosition.y + this.m_PanelObjects[num2].rectTransform.sizeDelta.y + this.m_Range);
				this.m_PanelObjects[num2].rectTransform.anchoredPosition = anchoredPosition;
				this.m_PanelObjects[num2].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 = -1;
			}
			num2++;
			if (num2 >= this.m_MaxItemOfPage)
			{
				num2 = 0;
			}
			num3++;
		}
		this.ContentRect.anchoredPosition = new Vector2(0f, height);
		this.MyUpdate();
	}

	// Token: 0x060029FE RID: 10750 RVA: 0x00466998 File Offset: 0x00464B98
	public float GetContentPos()
	{
		return this.ContentRect.anchoredPosition.y;
	}

	// Token: 0x060029FF RID: 10751 RVA: 0x004669B8 File Offset: 0x00464BB8
	public void GoToLast()
	{
		if (!this.CheckAtLast())
		{
			this.GoTo(this.m_DataList.Count - 1);
		}
	}

	// Token: 0x06002A00 RID: 10752 RVA: 0x004669D8 File Offset: 0x00464BD8
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
					component2.sizeDelta = new Vector2(component.sizeDelta.x, height);
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

	// Token: 0x06002A01 RID: 10753 RVA: 0x00466AD4 File Offset: 0x00464CD4
	private void MyUpdate()
	{
		if (this.m_Content == null || this.m_PanelObjects == null)
		{
			return;
		}
		float y = this.ContentRect.anchoredPosition.y;
		if (this.beginIndex < this.m_DataList.Count)
		{
			float num = this.m_DataList[this.beginIndex].m_limitTop + this.m_DataList[this.beginIndex].m_Height;
			float num2 = 0f;
			if (this.beginIndex > 0)
			{
				num2 = this.m_DataList[this.beginIndex - 1].m_limitTop + this.m_DataList[this.beginIndex - 1].m_Height + this.m_Range;
			}
			bool flag = true;
			int num3 = Mathf.Clamp(this.m_MaxItemOfPage / 2, 1, this.m_MaxItemOfPage);
			while (flag && (y > num || y < num2) && num3 > 0)
			{
				if (y > num)
				{
					flag = this.AddToLast();
				}
				else if (y < num2)
				{
					flag = this.AddToFirst();
				}
				num = this.m_DataList[this.beginIndex].m_limitTop + this.m_DataList[this.beginIndex].m_Height;
				if (this.beginIndex > 0)
				{
					num2 = this.m_DataList[this.beginIndex - 1].m_limitTop + this.m_DataList[this.beginIndex - 1].m_Height + this.m_Range;
				}
				num3--;
			}
		}
		for (int i = 0; i < this.m_MaxItemOfPage; i++)
		{
			if (this.m_PanelObjects[i].rectTransform.anchoredPosition.y - this.m_PanelObjects[i].rectTransform.sizeDelta.y < -y && this.m_PanelObjects[i].rectTransform.anchoredPosition.y > -this.m_PanelSize.y - y && this.m_PanelObjects[i].gameObject.GetComponent<ScrollPanelItem>().m_BtnID1 != -1)
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

	// Token: 0x06002A02 RID: 10754 RVA: 0x00466D80 File Offset: 0x00464F80
	private bool AddToLast()
	{
		RectTransform rectTransform = this.m_PanelObjects[this.m_FirstIdx].rectTransform;
		int firstIdx = this.m_FirstIdx;
		if (this.beginIndex + this.m_MaxItemOfPage >= this.m_DataList.Count)
		{
			return false;
		}
		float height = this.m_DataList[this.beginIndex + this.m_MaxItemOfPage].m_Height;
		float limitTop = this.m_DataList[this.beginIndex + this.m_MaxItemOfPage].m_limitTop;
		Vector2 a = new Vector2(0f, limitTop);
		rectTransform.anchoredPosition = -a;
		rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);
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

	// Token: 0x06002A03 RID: 10755 RVA: 0x00466EE0 File Offset: 0x004650E0
	private bool AddToFirst()
	{
		RectTransform rectTransform = this.m_PanelObjects[this.m_LastIdx].rectTransform;
		RectTransform rectTransform2 = this.m_PanelObjects[this.m_FirstIdx].rectTransform;
		if (this.beginIndex - 1 >= this.m_DataList.Count || this.beginIndex - 1 < 0)
		{
			return false;
		}
		float height = this.m_DataList[this.beginIndex - 1].m_Height;
		float limitTop = this.m_DataList[this.beginIndex - 1].m_limitTop;
		Vector2 a = new Vector2(0f, limitTop);
		rectTransform.anchoredPosition = -a;
		rectTransform.sizeDelta = new Vector2(rectTransform2.sizeDelta.x, height);
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

	// Token: 0x06002A04 RID: 10756 RVA: 0x00467040 File Offset: 0x00465240
	public bool CheckAtLast()
	{
		return this.ContentRect == null || this.ContentRect.sizeDelta.y - this.ContentRect.anchoredPosition.y <= this.m_PanelHeight;
	}

	// Token: 0x06002A05 RID: 10757 RVA: 0x00467094 File Offset: 0x00465294
	public bool CheckInPanel(int itemidx)
	{
		if (itemidx >= 0 && itemidx < this.m_DataList.Count && this.ContentRect != null && this.m_PanelObjects != null)
		{
			float y = this.ContentRect.anchoredPosition.y;
			float num = this.ContentRect.anchoredPosition.y + this.m_PanelHeight;
			float limitTop = this.m_DataList[itemidx].m_limitTop;
			float num2 = this.m_DataList[itemidx].m_limitTop + this.m_DataList[itemidx].m_Height;
			if (num2 >= y && limitTop <= num)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06002A06 RID: 10758 RVA: 0x00467150 File Offset: 0x00465350
	public void ButtonOnClick(ScrollPanelItem sender)
	{
		if (this.m_handler != null)
		{
			this.m_handler.ButtonOnClick(sender.gameObject, sender.m_BtnID1, this.m_ScrollPanelID);
		}
	}

	// Token: 0x04007555 RID: 30037
	private float m_PanelHeight = 600f;

	// Token: 0x04007556 RID: 30038
	private float m_Border = 10f;

	// Token: 0x04007557 RID: 30039
	private float m_Range = 10f;

	// Token: 0x04007558 RID: 30040
	private int m_MaxItemOfPage;

	// Token: 0x04007559 RID: 30041
	private int beginIndex;

	// Token: 0x0400755A RID: 30042
	private float viewheight;

	// Token: 0x0400755B RID: 30043
	private float m_TotalHeight;

	// Token: 0x0400755C RID: 30044
	private List<ItemData> m_DataList;

	// Token: 0x0400755D RID: 30045
	private Vector2 m_PanelSize;

	// Token: 0x0400755E RID: 30046
	private GameObject m_Content;

	// Token: 0x0400755F RID: 30047
	private RectTransform ContentRect;

	// Token: 0x04007560 RID: 30048
	public GameObject m_customItem;

	// Token: 0x04007561 RID: 30049
	public PanelObject[] m_PanelObjects;

	// Token: 0x04007562 RID: 30050
	public int m_FirstIdx;

	// Token: 0x04007563 RID: 30051
	public int m_LastIdx;

	// Token: 0x04007564 RID: 30052
	public IUpDateScrollPanel m_handler;

	// Token: 0x04007565 RID: 30053
	public int m_ScrollPanelID;
}
