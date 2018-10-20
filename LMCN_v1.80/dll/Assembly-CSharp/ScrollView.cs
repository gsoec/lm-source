using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020007F0 RID: 2032
public class ScrollView : MonoBehaviour, IValueChanged, IScrollItemHandler
{
	// Token: 0x06002A2C RID: 10796 RVA: 0x00468604 File Offset: 0x00466804
	private void Update()
	{
		if (this.bVertical)
		{
			if (this.initState == ScrollView.e_InitState.e_first)
			{
				this.bInitScroll = false;
				this.gameObjectLink = new ItemObject[this.countX * (this.countY + 2)];
				this.resGameObjs = new GameObject[this.countX];
				this.btnIndexs = new int[this.countX];
				this.initState = ScrollView.e_InitState.e_middle;
			}
			if (this.initState == ScrollView.e_InitState.e_middle)
			{
				this.posV2.x = this.borderX;
				this.posV2.y = -this.borderY - (float)this.initInddex * (this.btnSzieY + this.rangeSzieY);
				for (int i = 0; i < this.countX; i++)
				{
					this.posV2.x = this.borderX + (float)i * (this.btnSzieX + this.rangeSzieX);
					int num = i + this.countX * this.initInddex;
					if (this.itemPosArray != null && this.idArray != null)
					{
						int num2 = i + this.countX * this.initInddex;
						if (num2 >= 0 && num2 < this.idArray.Length)
						{
							num = this.idArray[num2];
						}
						this.posV2.y = this.GetPosByContentPosY(num2);
					}
					ItemObject itemObject = this.AddContentObj(this.posV2, num, this.customItem);
					if (this.tempGameObjectLinkIndex < this.initDataSize && num < this.MaxSize)
					{
						itemObject.gameObject.SetActive(true);
					}
					else
					{
						itemObject.gameObject.SetActive(false);
					}
					this.gameObjectLink[this.tempGameObjectLinkIndex] = itemObject;
					this.resGameObjs[i] = itemObject.gameObject;
					this.btnIndexs[i] = num;
					this.tempGameObjectLinkIndex++;
				}
				if (this.handler != null)
				{
					this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
				}
				this.endIndex = this.tempGameObjectLinkIndex - 1;
				this.customItem.SetActive(false);
				this.initInddex++;
				if (this.initInddex >= this.countY + 2)
				{
					this.initState = ScrollView.e_InitState.e_last;
				}
			}
			if (this.initState == ScrollView.e_InitState.e_last)
			{
				this.showSize = base.gameObject.GetComponent<RectTransform>().sizeDelta.y;
				this.initState = ScrollView.e_InitState.e_end;
				if (this.idArray != null)
				{
					this.SetScrollViewIndexValue(this.scrollValue);
				}
				if (this.handler != null)
				{
					this.handler.Initialized();
				}
				this.UpdateScrollRect();
				this.bInitScroll = true;
			}
		}
		else
		{
			if (this.initState == ScrollView.e_InitState.e_first)
			{
				this.gameObjectLink = new ItemObject[(this.countX + 2) * this.countY];
				this.resGameObjs = new GameObject[this.countY];
				this.btnIndexs = new int[this.countY];
				this.initState = ScrollView.e_InitState.e_middle;
			}
			if (this.initState == ScrollView.e_InitState.e_middle)
			{
				if (this.tempGameObjectLinkIndex < this.initDataSize)
				{
					this.customItem.SetActive(true);
				}
				if (this.Arrangement == ScrollView.e_Arrangement.LeftToRight)
				{
					this.posV2.x = this.borderX + (float)this.initInddex * (this.btnSzieX + this.rangeSzieX);
					this.posV2.y = -this.borderY;
					for (int j = 0; j < this.countY; j++)
					{
						this.posV2.y = -this.borderY - (float)j * (this.btnSzieY + this.rangeSzieY);
						int num = j + this.countY * this.initInddex;
						ItemObject itemObject2 = this.AddContentObj(this.posV2, num, this.customItem);
						this.gameObjectLink[this.tempGameObjectLinkIndex] = itemObject2;
						this.resGameObjs[j] = itemObject2.gameObject;
						this.btnIndexs[j] = num;
						this.tempGameObjectLinkIndex++;
					}
					if (this.handler != null)
					{
						this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
					}
					this.endIndex = this.tempGameObjectLinkIndex - 1;
					if (this.initInddex >= this.countY + 2)
					{
						this.initState = ScrollView.e_InitState.e_last;
					}
				}
			}
			if (this.initState == ScrollView.e_InitState.e_last)
			{
				this.showSize = base.gameObject.GetComponent<RectTransform>().sizeDelta.x;
				this.initState = ScrollView.e_InitState.e_end;
				if (this.handler != null)
				{
					this.handler.Initialized();
				}
				this.UpdateScrollRect();
			}
		}
	}

	// Token: 0x06002A2D RID: 10797 RVA: 0x00468AA0 File Offset: 0x00466CA0
	public void InitScrollView(ScrollViewIndexValue _value, bool _bIsBatch, float posY = 0f, float[] _itemPosArray = null, float _contentHeight = 0f, int[] _idArray = null)
	{
		this.preContentPosY = posY;
		this.bIsBatch = _bIsBatch;
		CScrollRect cscrollRect = base.gameObject.AddComponent<CScrollRect>();
		cscrollRect.m_Handler = this;
		cscrollRect.horizontal = !this.bVertical;
		cscrollRect.vertical = this.bVertical;
		cscrollRect.inertia = true;
		cscrollRect.decelerationRate = 0.35f;
		cscrollRect.scrollSensitivity = 1f;
		this.mask = base.gameObject.AddComponent<Mask>();
		this.mask.enabled = true;
		this.mask.showMaskGraphic = false;
		this.rt = base.gameObject.GetComponent<RectTransform>();
		this.Content = new GameObject();
		this.Content.name = "Content";
		this.rt = this.Content.AddComponent<RectTransform>();
		cscrollRect.content = this.rt;
		this.Content.transform.SetParent(base.gameObject.transform, false);
		this.posV2.x = 0f;
		this.posV2.y = this.preContentPosY;
		if (this.bVertical)
		{
			this.tempV2.y = (float)(this.countY + 2) * (this.btnSzieY + this.rangeSzieY) + this.rangeSzieY;
		}
		else
		{
			this.tempV2.x = (float)(this.countX + 1) * (this.btnSzieX + this.rangeSzieX) + this.rangeSzieX;
		}
		if (this.preContentPosY > 0f)
		{
			this.tempV2.y = _contentHeight;
		}
		this.SetPos(this.rt, this.tempV2, this.posV2);
		this.itemPosArray = _itemPosArray;
		this.idArray = _idArray;
		this.scrollValue = _value;
		if (this.bIsBatch)
		{
			if (this.bVertical)
			{
				this.gameObjectLink = new ItemObject[this.countX * (this.countY + 2)];
				this.resGameObjs = new GameObject[this.countX];
				this.btnIndexs = new int[this.countX];
				for (int i = 0; i < this.countY + 2; i++)
				{
					this.posV2.x = this.borderX;
					this.posV2.y = -this.borderY - (float)i * (this.btnSzieY + this.rangeSzieY);
					for (int j = 0; j < this.countX; j++)
					{
						this.posV2.x = this.borderX + (float)j * (this.btnSzieX + this.rangeSzieX);
						int num = j + this.countX * i;
						ItemObject itemObject = this.AddContentObj(this.posV2, num, this.customItem);
						this.gameObjectLink[this.tempGameObjectLinkIndex] = itemObject;
						this.resGameObjs[j] = itemObject.gameObject;
						this.btnIndexs[j] = num;
						this.tempGameObjectLinkIndex++;
					}
					if (this.handler != null)
					{
						this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
					}
				}
				this.endIndex = this.tempGameObjectLinkIndex - 1;
				this.showSize = base.gameObject.GetComponent<RectTransform>().sizeDelta.y;
			}
			else
			{
				this.gameObjectLink = new ItemObject[(this.countX + 2) * this.countY];
				this.resGameObjs = new GameObject[this.countY];
				this.btnIndexs = new int[this.countY];
				if (this.Arrangement == ScrollView.e_Arrangement.LeftToRight)
				{
					for (int k = 0; k < this.countX + 2; k++)
					{
						this.posV2.x = this.borderX + (float)k * (this.btnSzieX + this.rangeSzieX);
						this.posV2.y = -this.borderY;
						for (int l = 0; l < this.countY; l++)
						{
							this.posV2.y = -this.borderY - (float)l * (this.btnSzieY + this.rangeSzieY);
							int num = l + this.countY * k;
							ItemObject itemObject2 = this.AddContentObj(this.posV2, num, this.customItem);
							this.gameObjectLink[this.tempGameObjectLinkIndex] = itemObject2;
							this.resGameObjs[l] = itemObject2.gameObject;
							this.btnIndexs[l] = num;
							this.tempGameObjectLinkIndex++;
						}
						if (this.handler != null)
						{
							this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
						}
					}
					this.endIndex = this.tempGameObjectLinkIndex - 1;
					this.showSize = base.gameObject.GetComponent<RectTransform>().sizeDelta.x;
				}
			}
			this.initState = ScrollView.e_InitState.e_end;
			this.customItem.SetActive(false);
			this.SetContentSize(1);
			this.UpdateScrollRect();
		}
	}

	// Token: 0x06002A2E RID: 10798 RVA: 0x00468F88 File Offset: 0x00467188
	private ItemObject AddContentObj(Vector2 pos, int btnID, GameObject item = null)
	{
		ItemObject itemObject = new ItemObject();
		GameObject gameObject = UnityEngine.Object.Instantiate(this.customItem) as GameObject;
		ScrollItem component = gameObject.GetComponent<ScrollItem>();
		component.m_BtnID1 = btnID;
		component.m_Handler = this;
		RectTransform component2 = gameObject.GetComponent<RectTransform>();
		if (component2)
		{
			this.tempV2.x = this.btnSzieX;
			this.tempV2.y = this.btnSzieY;
			this.SetPos(component2, this.tempV2, pos);
			gameObject.transform.SetParent(this.Content.transform, false);
		}
		itemObject.rectTransform = component2;
		itemObject.scrollItem = component;
		itemObject.gameObject = gameObject;
		return itemObject;
	}

	// Token: 0x06002A2F RID: 10799 RVA: 0x00469030 File Offset: 0x00467230
	private void SetPos(RectTransform rt, Vector2 size, Vector2 pos)
	{
		rt.anchorMax = this.AnchorMaxV2;
		rt.anchorMin = this.AnchorMinV2;
		rt.pivot = this.PovitV2;
		rt.sizeDelta = size;
		rt.anchoredPosition = pos;
	}

	// Token: 0x06002A30 RID: 10800 RVA: 0x00469070 File Offset: 0x00467270
	private void AddToHead()
	{
		if (this.bVertical)
		{
			this.tempV2.x = 0f;
			this.tempV2.y = this.btnSzieY + this.rangeSzieY;
			ItemObject itemObject = this.gameObjectLink[this.headIndex];
			if (itemObject == null)
			{
				return;
			}
			this.posV2 = itemObject.rectTransform.anchoredPosition;
			this.NowIndex--;
			for (int i = this.countX - 1; i >= 0; i--)
			{
				this.tempV2.x = this.btnSzieX + this.rangeSzieX;
				ItemObject itemObject2 = this.gameObjectLink[this.endIndex];
				Vector2 anchoredPosition = itemObject2.rectTransform.anchoredPosition;
				anchoredPosition.y = Mathf.Round(this.tempV2.y + this.posV2.y);
				itemObject2.rectTransform.anchoredPosition = anchoredPosition;
				this.headIndex = this.endIndex;
				if (this.headIndex >= 1)
				{
					this.endIndex--;
				}
				else
				{
					this.headIndex = 0;
					this.endIndex = this.gameObjectLink.Length - 1;
				}
				this.resGameObjs[i] = itemObject2.gameObject;
				int num = (this.NowIndex - 1) * this.countX + i;
				this.btnIndexs[i] = num;
				itemObject2.scrollItem.m_BtnID1 = num;
			}
		}
		else
		{
			this.tempV2.x = -this.btnSzieX - this.rangeSzieX;
			this.tempV2.y = 0f;
			ItemObject itemObject = this.gameObjectLink[this.headIndex];
			if (itemObject == null)
			{
				return;
			}
			this.posV2 = itemObject.rectTransform.anchoredPosition;
			this.NowIndex--;
			for (int j = this.countY - 1; j >= 0; j--)
			{
				this.tempV2.y = -this.btnSzieY - this.rangeSzieY;
				ItemObject itemObject2 = this.gameObjectLink[this.endIndex];
				Vector2 anchoredPosition = itemObject2.rectTransform.anchoredPosition;
				anchoredPosition.x = Mathf.Round(this.tempV2.x + this.posV2.x);
				itemObject2.rectTransform.anchoredPosition = anchoredPosition;
				this.headIndex = this.endIndex;
				if (this.headIndex >= 1)
				{
					this.endIndex--;
				}
				else
				{
					this.headIndex = 0;
					this.endIndex = this.gameObjectLink.Length - 1;
				}
				this.resGameObjs[j] = itemObject2.gameObject;
				int num = (this.NowIndex - 1) * this.countY + j;
				this.btnIndexs[j] = num;
				itemObject2.scrollItem.m_BtnID1 = num;
			}
		}
		if (this.handler != null)
		{
			this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
		}
	}

	// Token: 0x06002A31 RID: 10801 RVA: 0x0046935C File Offset: 0x0046755C
	private void AddToEnd()
	{
		if (this.bVertical)
		{
			this.tempV2.x = 0f;
			this.tempV2.y = -this.btnSzieY + -this.rangeSzieY;
			ItemObject itemObject = this.gameObjectLink[this.endIndex];
			if (itemObject == null)
			{
				return;
			}
			this.posV2 = itemObject.rectTransform.anchoredPosition;
			this.NowIndex++;
			for (int i = 0; i < this.countX; i++)
			{
				this.tempV2.x = this.btnSzieX + this.rangeSzieX;
				ItemObject itemObject2 = this.gameObjectLink[this.headIndex];
				Vector2 anchoredPosition = itemObject2.rectTransform.anchoredPosition;
				anchoredPosition.y = Mathf.Round(this.tempV2.y + this.posV2.y);
				itemObject2.rectTransform.anchoredPosition = anchoredPosition;
				this.endIndex = this.headIndex;
				if (this.headIndex < this.gameObjectLink.Length - 1)
				{
					this.headIndex++;
				}
				else
				{
					this.headIndex = 0;
				}
				int num = (this.NowIndex + this.countY) * this.countX + i;
				this.resGameObjs[i] = itemObject2.gameObject;
				this.btnIndexs[i] = num;
				itemObject2.scrollItem.m_BtnID1 = num;
			}
		}
		else
		{
			this.tempV2.x = this.btnSzieX + this.rangeSzieX;
			this.tempV2.y = 0f;
			ItemObject itemObject = this.gameObjectLink[this.endIndex];
			if (itemObject == null)
			{
				return;
			}
			this.posV2 = itemObject.rectTransform.anchoredPosition;
			this.NowIndex++;
			for (int j = 0; j < this.countY; j++)
			{
				this.tempV2.y = this.btnSzieY + this.rangeSzieY;
				ItemObject itemObject2 = this.gameObjectLink[this.headIndex];
				Vector2 anchoredPosition = itemObject2.rectTransform.anchoredPosition;
				anchoredPosition.x = Mathf.Round(this.tempV2.x + this.posV2.x);
				itemObject2.rectTransform.anchoredPosition = anchoredPosition;
				this.endIndex = this.headIndex;
				if (this.headIndex < this.gameObjectLink.Length - 1)
				{
					this.headIndex++;
				}
				else
				{
					this.headIndex = 0;
				}
				int num = (this.NowIndex + this.countX) * this.countY + j;
				this.resGameObjs[j] = itemObject2.gameObject;
				this.btnIndexs[j] = num;
				itemObject2.scrollItem.m_BtnID1 = num;
			}
		}
		if (this.handler != null)
		{
			this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
		}
	}

	// Token: 0x06002A32 RID: 10802 RVA: 0x00469640 File Offset: 0x00467840
	private void Check(ItemObject itemObject)
	{
		if (itemObject != null)
		{
			if (itemObject.scrollItem.m_BtnID1 >= this.MaxSize)
			{
				itemObject.gameObject.SetActive(false);
			}
			else
			{
				itemObject.gameObject.SetActive(true);
			}
		}
	}

	// Token: 0x06002A33 RID: 10803 RVA: 0x0046967C File Offset: 0x0046787C
	private void CheckCanShowInMaskPanel()
	{
		if (this.bVertical)
		{
			float num = this.rt.anchoredPosition.y;
			float num2 = num + this.showSize;
			for (int i = 0; i < this.gameObjectLink.Length; i++)
			{
				int btnID = this.gameObjectLink[i].scrollItem.m_BtnID1;
				float num3 = Mathf.Abs(this.gameObjectLink[i].rectTransform.anchoredPosition.y);
				float num4 = num3 + this.gameObjectLink[i].rectTransform.sizeDelta.y;
				if (num > num4 || num2 < num3 || btnID >= this.MaxSize)
				{
					if (this.gameObjectLink[i].gameObject.activeSelf)
					{
						this.gameObjectLink[i].gameObject.SetActive(false);
					}
				}
				else if (!this.gameObjectLink[i].gameObject.activeSelf)
				{
					this.gameObjectLink[i].gameObject.SetActive(true);
				}
			}
		}
		else
		{
			float num = Mathf.Abs(this.rt.anchoredPosition.x);
			float num2 = num + this.showSize;
			for (int j = 0; j < this.gameObjectLink.Length; j++)
			{
				float num3 = Mathf.Abs(this.gameObjectLink[j].rectTransform.anchoredPosition.x);
				float num4 = num3 + this.gameObjectLink[j].rectTransform.sizeDelta.x;
				int btnID = this.gameObjectLink[j].scrollItem.m_BtnID1;
				if (num > num4 || num2 < num3 || btnID >= this.MaxSize)
				{
					if (this.gameObjectLink[j].gameObject.activeSelf)
					{
						this.gameObjectLink[j].gameObject.SetActive(false);
					}
				}
				else if (!this.gameObjectLink[j].gameObject.activeSelf)
				{
					this.gameObjectLink[j].gameObject.SetActive(true);
				}
			}
		}
	}

	// Token: 0x06002A34 RID: 10804 RVA: 0x004698CC File Offset: 0x00467ACC
	public void SetContentSize(int size)
	{
		if (this.initState != ScrollView.e_InitState.e_end)
		{
			return;
		}
		if (size <= 0)
		{
			this.MaxSize = 0;
			this.MaxIndex = 0;
		}
		else if (this.bVertical)
		{
			this.MaxSize = size;
			int num;
			if (this.MaxSize % this.countX == 0)
			{
				num = this.MaxSize / this.countX;
			}
			else
			{
				num = this.MaxSize / this.countX + 1;
			}
			this.tempV2.y = (float)num * (this.btnSzieY + this.rangeSzieY) + this.rangeSzieY;
			this.tempV2.x = this.rt.sizeDelta.x;
			this.rt.sizeDelta = this.tempV2;
			this.MaxIndex = num - this.countY;
		}
		else
		{
			this.MaxSize = size;
			int num2;
			if (this.MaxSize % this.countY == 0)
			{
				num2 = this.MaxSize / this.countY;
			}
			else
			{
				num2 = this.MaxSize / this.countY + 1;
			}
			this.tempV2.x = (float)num2 * (this.btnSzieX + this.rangeSzieX) + this.rangeSzieX;
			this.tempV2.y = this.rt.sizeDelta.y;
			this.rt.sizeDelta = this.tempV2;
			this.MaxIndex = num2 - this.countX;
		}
		int num3 = this.gameObjectLink.Length;
		for (int i = 0; i < num3; i++)
		{
			if (this.gameObjectLink[i] != null && this.gameObjectLink[i].gameObject != null)
			{
				this.Check(this.gameObjectLink[i]);
			}
		}
	}

	// Token: 0x06002A35 RID: 10805 RVA: 0x00469A98 File Offset: 0x00467C98
	public void UpdateScrollRect()
	{
		if (this.initState != ScrollView.e_InitState.e_end)
		{
			return;
		}
		if (this.bVertical)
		{
			float num = (float)this.NowIndex * (this.btnSzieY + this.rangeSzieY);
			float num2 = (float)(this.NowIndex - 1) * (this.btnSzieY + this.rangeSzieY);
			if (this.rt.anchoredPosition.y > num && this.NowIndex < this.MaxIndex - 1)
			{
				this.AddToEnd();
			}
			else if (this.NowIndex > 1 && this.rt.anchoredPosition.y < num2)
			{
				this.AddToHead();
			}
		}
		else
		{
			float num = (float)(-(float)this.NowIndex) * (this.btnSzieX + this.rangeSzieX);
			float num2 = (float)(this.NowIndex - 1) * (-this.btnSzieX + -this.rangeSzieX);
			if (this.rt.anchoredPosition.x < num && this.NowIndex < this.MaxIndex - 1)
			{
				this.AddToEnd();
			}
			else if (this.NowIndex > 1 && this.rt.anchoredPosition.x > num2)
			{
				this.AddToHead();
			}
		}
		if (this.handler != null)
		{
			this.handler.OnScroll(this.rt);
		}
		this.CheckCanShowInMaskPanel();
	}

	// Token: 0x06002A36 RID: 10806 RVA: 0x00469C0C File Offset: 0x00467E0C
	public void Clear()
	{
	}

	// Token: 0x06002A37 RID: 10807 RVA: 0x00469C10 File Offset: 0x00467E10
	public void Show()
	{
	}

	// Token: 0x06002A38 RID: 10808 RVA: 0x00469C14 File Offset: 0x00467E14
	private float GetPosByContentPosY(int idx)
	{
		if (this.itemPosArray != null && idx >= 0 && idx < this.itemPosArray.Length)
		{
			return this.itemPosArray[idx];
		}
		return 0f;
	}

	// Token: 0x06002A39 RID: 10809 RVA: 0x00469C50 File Offset: 0x00467E50
	public float[] GetItemsPos()
	{
		int childCount = base.transform.GetChild(0).childCount;
		float[] array = new float[childCount];
		for (int i = 0; i < childCount; i++)
		{
			array[i] = base.transform.GetChild(0).GetChild(i).GetComponent<RectTransform>().anchoredPosition.y;
		}
		return (childCount <= 0) ? null : array;
	}

	// Token: 0x06002A3A RID: 10810 RVA: 0x00469CC0 File Offset: 0x00467EC0
	public int[] GetItemsBtnID()
	{
		int childCount = base.transform.GetChild(0).childCount;
		int[] array = new int[childCount];
		for (int i = 0; i < childCount; i++)
		{
			array[i] = base.transform.GetChild(0).GetChild(i).GetComponent<ScrollItem>().m_BtnID1;
		}
		return (childCount <= 0) ? null : array;
	}

	// Token: 0x06002A3B RID: 10811 RVA: 0x00469D28 File Offset: 0x00467F28
	public ScrollViewIndexValue GetScrollViewIndexValue()
	{
		ScrollViewIndexValue result;
		result.headIndex = this.headIndex;
		result.endIndex = this.endIndex;
		result.NowIndex = this.NowIndex;
		result.MaxIndex = this.MaxIndex;
		result.MaxSize = this.MaxSize;
		return result;
	}

	// Token: 0x06002A3C RID: 10812 RVA: 0x00469D78 File Offset: 0x00467F78
	public void SetScrollViewIndexValue(ScrollViewIndexValue _velue)
	{
		this.headIndex = _velue.headIndex;
		this.endIndex = _velue.endIndex;
		this.NowIndex = _velue.NowIndex;
		this.MaxIndex = _velue.MaxIndex;
		this.MaxSize = _velue.MaxSize;
	}

    // Token: 0x06002A3D RID: 10813 RVA: 0x00469DC8 File Offset: 0x00467FC8
    public void SetContentPos(float posY = 0f, float[] _itemPosArray = null, float height = 0f, int[] _idArray = null, ScrollViewIndexValue _value = new ScrollViewIndexValue())
	{
		int childCount = base.transform.GetChild(0).childCount;
		RectTransform component = base.transform.GetChild(0).GetComponent<RectTransform>();
		Vector2 anchoredPosition = component.anchoredPosition;
		anchoredPosition.y = posY;
		component.anchoredPosition = anchoredPosition;
	}

	// Token: 0x06002A3E RID: 10814 RVA: 0x00469E10 File Offset: 0x00468010
	public void AddHender(IUpDateRowItem _handler, bool bIsBatch = true, int _initDataSize = 0, int _MaxSize = 0, float posY = 0f, float[] _itemPosArray = null, float height = 0f, int[] _idArray = null, ScrollViewIndexValue _value = new ScrollViewIndexValue())
	{
		if (this.handler == null)
		{
			this.handler = _handler;
			this.InitScrollView(_value, bIsBatch, posY, _itemPosArray, height, _idArray);
			this.initDataSize = _initDataSize;
			this.MaxSize = _MaxSize;
		}
	}

	// Token: 0x06002A3F RID: 10815 RVA: 0x00469E50 File Offset: 0x00468050
	public void UpDateAllItem()
	{
		if (this.initState != ScrollView.e_InitState.e_end)
		{
			return;
		}
		int num = this.gameObjectLink.Length;
		int num2 = 0;
		for (int i = 0; i < this.resGameObjs.Length; i++)
		{
			this.UpdateScrollRect();
		}
		if (this.handler != null)
		{
			for (int j = 0; j < num; j++)
			{
				this.resGameObjs[num2] = this.gameObjectLink[j].gameObject;
				this.btnIndexs[num2] = this.gameObjectLink[j].scrollItem.m_BtnID1;
				num2++;
				if (num2 >= this.resGameObjs.Length)
				{
					this.handler.UpDateRowItem(this.resGameObjs, this.btnIndexs);
					num2 = 0;
				}
			}
		}
	}

	// Token: 0x06002A40 RID: 10816 RVA: 0x00469F0C File Offset: 0x0046810C
	public void ButtonOnClick(ScrollItem sender)
	{
		if (sender && this.handler != null)
		{
			this.handler.ButtonOnClick(sender.gameObject, sender.m_BtnID1);
		}
	}

	// Token: 0x06002A41 RID: 10817 RVA: 0x00469F3C File Offset: 0x0046813C
	public void onValueChanged()
	{
		this.UpdateScrollRect();
	}

	// Token: 0x06002A42 RID: 10818 RVA: 0x00469F44 File Offset: 0x00468144
	public bool IsInitState()
	{
		return this.initState == ScrollView.e_InitState.e_middle;
	}

	// Token: 0x06002A43 RID: 10819 RVA: 0x00469F50 File Offset: 0x00468150
	public bool CheckInitScroll()
	{
		return this.bInitScroll;
	}

	// Token: 0x04007582 RID: 30082
	private ItemObject[] gameObjectLink;

	// Token: 0x04007583 RID: 30083
	private int headIndex;

	// Token: 0x04007584 RID: 30084
	private int endIndex;

	// Token: 0x04007585 RID: 30085
	private int NowIndex = 1;

	// Token: 0x04007586 RID: 30086
	private int MaxIndex;

	// Token: 0x04007587 RID: 30087
	private int MaxSize;

	// Token: 0x04007588 RID: 30088
	private IUpDateRowItem handler;

	// Token: 0x04007589 RID: 30089
	private GameObject[] resGameObjs;

	// Token: 0x0400758A RID: 30090
	private int[] btnIndexs;

	// Token: 0x0400758B RID: 30091
	private GameObject Content;

	// Token: 0x0400758C RID: 30092
	private RectTransform rt;

	// Token: 0x0400758D RID: 30093
	private RectTransform contentRt;

	// Token: 0x0400758E RID: 30094
	private Vector2 PovitV2 = new Vector2(0f, 1f);

	// Token: 0x0400758F RID: 30095
	private Vector2 AnchorMaxV2 = new Vector2(0f, 1f);

	// Token: 0x04007590 RID: 30096
	private Vector2 AnchorMinV2 = new Vector2(0f, 1f);

	// Token: 0x04007591 RID: 30097
	private Vector2 tempV2 = new Vector2(0f, 0f);

	// Token: 0x04007592 RID: 30098
	private Vector2 posV2 = new Vector2(100f, 100f);

	// Token: 0x04007593 RID: 30099
	public GameObject customItem;

	// Token: 0x04007594 RID: 30100
	public int countX;

	// Token: 0x04007595 RID: 30101
	public int countY;

	// Token: 0x04007596 RID: 30102
	public float btnSzieX;

	// Token: 0x04007597 RID: 30103
	public float btnSzieY;

	// Token: 0x04007598 RID: 30104
	public float rangeSzieX;

	// Token: 0x04007599 RID: 30105
	public float rangeSzieY;

	// Token: 0x0400759A RID: 30106
	public float borderX;

	// Token: 0x0400759B RID: 30107
	public float borderY;

	// Token: 0x0400759C RID: 30108
	private float showSize;

	// Token: 0x0400759D RID: 30109
	public bool bVertical = true;

	// Token: 0x0400759E RID: 30110
	public bool bShowInEditor;

	// Token: 0x0400759F RID: 30111
	private bool bIsBatch = true;

	// Token: 0x040075A0 RID: 30112
	private ScrollView.e_InitState initState;

	// Token: 0x040075A1 RID: 30113
	private int initInddex;

	// Token: 0x040075A2 RID: 30114
	private int tempGameObjectLinkIndex;

	// Token: 0x040075A3 RID: 30115
	private int initDataSize;

	// Token: 0x040075A4 RID: 30116
	private float preContentPosY;

	// Token: 0x040075A5 RID: 30117
	private float[] itemPosArray;

	// Token: 0x040075A6 RID: 30118
	private int[] idArray;

	// Token: 0x040075A7 RID: 30119
	private ScrollViewIndexValue scrollValue;

	// Token: 0x040075A8 RID: 30120
	private bool bInitScroll = true;

	// Token: 0x040075A9 RID: 30121
	private ScrollView.e_Arrangement Arrangement;

	// Token: 0x040075AA RID: 30122
	private Mask mask;

	// Token: 0x020007F1 RID: 2033
	private enum e_InitState
	{
		// Token: 0x040075AC RID: 30124
		e_first,
		// Token: 0x040075AD RID: 30125
		e_middle,
		// Token: 0x040075AE RID: 30126
		e_last,
		// Token: 0x040075AF RID: 30127
		e_end
	}

	// Token: 0x020007F2 RID: 2034
	public enum e_Arrangement
	{
		// Token: 0x040075B1 RID: 30129
		LeftToRight,
		// Token: 0x040075B2 RID: 30130
		RightToLeft
	}
}
