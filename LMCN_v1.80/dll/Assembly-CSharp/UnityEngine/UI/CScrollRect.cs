using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using uTools;

namespace UnityEngine.UI
{
	// Token: 0x020007D2 RID: 2002
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[SelectionBase]
	[AddComponentMenu("UI/Scroll Rect", 33)]
	public class CScrollRect : UIBehaviour, IBeginDragHandler, IDragHandler, IScrollHandler, IInitializePotentialDragHandler, IEndDragHandler, ICanvasElement, IEventSystemHandler
	{
		// Token: 0x06002955 RID: 10581 RVA: 0x00459210 File Offset: 0x00457410
		protected CScrollRect()
		{
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06002956 RID: 10582 RVA: 0x004592F4 File Offset: 0x004574F4
		// (set) Token: 0x06002957 RID: 10583 RVA: 0x004592FC File Offset: 0x004574FC
		public RectTransform content
		{
			get
			{
				return this.m_Content;
			}
			set
			{
				this.m_Content = value;
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06002958 RID: 10584 RVA: 0x00459308 File Offset: 0x00457508
		// (set) Token: 0x06002959 RID: 10585 RVA: 0x00459310 File Offset: 0x00457510
		public bool horizontal
		{
			get
			{
				return this.m_Horizontal;
			}
			set
			{
				this.m_Horizontal = value;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600295A RID: 10586 RVA: 0x0045931C File Offset: 0x0045751C
		// (set) Token: 0x0600295B RID: 10587 RVA: 0x00459324 File Offset: 0x00457524
		public bool vertical
		{
			get
			{
				return this.m_Vertical;
			}
			set
			{
				this.m_Vertical = value;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600295C RID: 10588 RVA: 0x00459330 File Offset: 0x00457530
		// (set) Token: 0x0600295D RID: 10589 RVA: 0x00459338 File Offset: 0x00457538
		public CScrollRect.MovementType movementType
		{
			get
			{
				return this.m_MovementType;
			}
			set
			{
				this.m_MovementType = value;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x0600295E RID: 10590 RVA: 0x00459344 File Offset: 0x00457544
		// (set) Token: 0x0600295F RID: 10591 RVA: 0x0045934C File Offset: 0x0045754C
		public float elasticity
		{
			get
			{
				return this.m_Elasticity;
			}
			set
			{
				this.m_Elasticity = value;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06002960 RID: 10592 RVA: 0x00459358 File Offset: 0x00457558
		// (set) Token: 0x06002961 RID: 10593 RVA: 0x00459360 File Offset: 0x00457560
		public bool inertia
		{
			get
			{
				return this.m_Inertia;
			}
			set
			{
				this.m_Inertia = value;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06002962 RID: 10594 RVA: 0x0045936C File Offset: 0x0045756C
		// (set) Token: 0x06002963 RID: 10595 RVA: 0x00459374 File Offset: 0x00457574
		public float decelerationRate
		{
			get
			{
				return this.m_DecelerationRate;
			}
			set
			{
				this.m_DecelerationRate = value;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06002964 RID: 10596 RVA: 0x00459380 File Offset: 0x00457580
		// (set) Token: 0x06002965 RID: 10597 RVA: 0x00459388 File Offset: 0x00457588
		public float scrollSensitivity
		{
			get
			{
				return this.m_ScrollSensitivity;
			}
			set
			{
				this.m_ScrollSensitivity = value;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06002966 RID: 10598 RVA: 0x00459394 File Offset: 0x00457594
		// (set) Token: 0x06002967 RID: 10599 RVA: 0x0045939C File Offset: 0x0045759C
		public Scrollbar horizontalScrollbar
		{
			get
			{
				return this.m_HorizontalScrollbar;
			}
			set
			{
				if (this.m_HorizontalScrollbar)
				{
					this.m_HorizontalScrollbar.onValueChanged.RemoveListener(new UnityAction<float>(this.SetHorizontalNormalizedPosition));
				}
				this.m_HorizontalScrollbar = value;
				if (this.m_HorizontalScrollbar)
				{
					this.m_HorizontalScrollbar.onValueChanged.AddListener(new UnityAction<float>(this.SetHorizontalNormalizedPosition));
				}
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06002968 RID: 10600 RVA: 0x00459408 File Offset: 0x00457608
		// (set) Token: 0x06002969 RID: 10601 RVA: 0x00459410 File Offset: 0x00457610
		public Scrollbar verticalScrollbar
		{
			get
			{
				return this.m_VerticalScrollbar;
			}
			set
			{
				if (this.m_VerticalScrollbar)
				{
					this.m_VerticalScrollbar.onValueChanged.RemoveListener(new UnityAction<float>(this.SetVerticalNormalizedPosition));
				}
				this.m_VerticalScrollbar = value;
				if (this.m_VerticalScrollbar)
				{
					this.m_VerticalScrollbar.onValueChanged.AddListener(new UnityAction<float>(this.SetVerticalNormalizedPosition));
				}
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x0600296A RID: 10602 RVA: 0x0045947C File Offset: 0x0045767C
		// (set) Token: 0x0600296B RID: 10603 RVA: 0x00459484 File Offset: 0x00457684
		public CScrollRect.ScrollRectEvent onValueChanged
		{
			get
			{
				return this.m_OnValueChanged;
			}
			set
			{
				this.m_OnValueChanged = value;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600296C RID: 10604 RVA: 0x00459490 File Offset: 0x00457690
		protected RectTransform viewRect
		{
			get
			{
				if (this.m_ViewRect == null)
				{
					this.m_ViewRect = (RectTransform)base.transform;
				}
				return this.m_ViewRect;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600296D RID: 10605 RVA: 0x004594C8 File Offset: 0x004576C8
		// (set) Token: 0x0600296E RID: 10606 RVA: 0x004594D0 File Offset: 0x004576D0
		public Vector2 velocity
		{
			get
			{
				return this.m_Velocity;
			}
			set
			{
				this.m_Velocity = value;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x0600296F RID: 10607 RVA: 0x004594DC File Offset: 0x004576DC
		public ListViewState ViewState
		{
			get
			{
				return this.m_ViewState;
			}
		}

		// Token: 0x06002970 RID: 10608 RVA: 0x004594E4 File Offset: 0x004576E4
		public virtual void Rebuild(CanvasUpdate executing)
		{
			if (executing != CanvasUpdate.PostLayout)
			{
				return;
			}
			this.UpdateBounds();
			this.UpdateScrollbars(Vector2.zero);
			this.UpdatePrevData();
			this.m_HasRebuiltLayout = true;
		}

		// Token: 0x06002971 RID: 10609 RVA: 0x00459518 File Offset: 0x00457718
		protected override void OnEnable()
		{
			base.OnEnable();
			if (this.m_HorizontalScrollbar)
			{
				this.m_HorizontalScrollbar.onValueChanged.AddListener(new UnityAction<float>(this.SetHorizontalNormalizedPosition));
			}
			if (this.m_VerticalScrollbar)
			{
				this.m_VerticalScrollbar.onValueChanged.AddListener(new UnityAction<float>(this.SetVerticalNormalizedPosition));
			}
			CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild(this);
			if (this.bPageMoving)
			{
				this.setCurrentIndex(this.NowPageIndex, true);
				if (this.m_PageMoveHandler != null)
				{
					this.m_PageMoveHandler.EndPageMove();
				}
				this.MoveEndX = -1f;
				this.bPageMoving = false;
			}
		}

		// Token: 0x06002972 RID: 10610 RVA: 0x004595CC File Offset: 0x004577CC
		protected override void OnDisable()
		{
			CanvasUpdateRegistry.UnRegisterCanvasElementForRebuild(this);
			if (this.m_HorizontalScrollbar)
			{
				this.m_HorizontalScrollbar.onValueChanged.RemoveListener(new UnityAction<float>(this.SetHorizontalNormalizedPosition));
			}
			if (this.m_VerticalScrollbar)
			{
				this.m_VerticalScrollbar.onValueChanged.RemoveListener(new UnityAction<float>(this.SetVerticalNormalizedPosition));
			}
			this.m_HasRebuiltLayout = false;
			base.OnDisable();
		}

		// Token: 0x06002973 RID: 10611 RVA: 0x00459644 File Offset: 0x00457844
		public override bool IsActive()
		{
			return base.IsActive() && this.m_Content != null;
		}

		// Token: 0x06002974 RID: 10612 RVA: 0x00459660 File Offset: 0x00457860
		private void EnsureLayoutHasRebuilt()
		{
			if (!this.m_HasRebuiltLayout && !CanvasUpdateRegistry.IsRebuildingLayout())
			{
				Canvas.ForceUpdateCanvases();
			}
		}

		// Token: 0x06002975 RID: 10613 RVA: 0x0045967C File Offset: 0x0045787C
		public virtual void StopMovement()
		{
			this.m_Velocity = Vector2.zero;
		}

		// Token: 0x06002976 RID: 10614 RVA: 0x0045968C File Offset: 0x0045788C
		public bool Get_Dragging()
		{
			return this.m_Dragging;
		}

		// Token: 0x06002977 RID: 10615 RVA: 0x00459694 File Offset: 0x00457894
		public virtual void OnScroll(PointerEventData data)
		{
			if (!this.IsActive())
			{
				return;
			}
			this.EnsureLayoutHasRebuilt();
			this.UpdateBounds();
			Vector2 scrollDelta = data.scrollDelta;
			scrollDelta.y *= -1f;
			if (this.vertical && !this.horizontal)
			{
				if (Mathf.Abs(scrollDelta.x) > Mathf.Abs(scrollDelta.y))
				{
					scrollDelta.y = scrollDelta.x;
				}
				scrollDelta.x = 0f;
			}
			if (this.horizontal && !this.vertical)
			{
				if (Mathf.Abs(scrollDelta.y) > Mathf.Abs(scrollDelta.x))
				{
					scrollDelta.x = scrollDelta.y;
				}
				scrollDelta.y = 0f;
			}
			Vector2 vector = this.m_Content.anchoredPosition;
			vector += scrollDelta * this.m_ScrollSensitivity;
			if (this.m_MovementType == CScrollRect.MovementType.Clamped)
			{
				vector += this.CalculateOffset(vector - this.m_Content.anchoredPosition);
			}
			this.SetContentAnchoredPosition(vector);
			this.UpdateBounds();
		}

		// Token: 0x06002978 RID: 10616 RVA: 0x004597C4 File Offset: 0x004579C4
		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
			this.m_Velocity = Vector2.zero;
		}

		// Token: 0x06002979 RID: 10617 RVA: 0x004597D4 File Offset: 0x004579D4
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.button != PointerEventData.InputButton.Left)
			{
				return;
			}
			if (!this.IsActive())
			{
				return;
			}
			this.startPos = eventData.position;
			if (this.bPageMove)
			{
				this.bPageMoving = true;
				this._pos1 = (this._pos2 = eventData.position);
				this._time1 = (this._time2 = Time.realtimeSinceStartup);
				if (this.m_PageMoveHandler != null)
				{
					this.m_PageMoveHandler.BeginPageMove();
				}
			}
			this.UpdateBounds();
			this.m_PointerStartLocalCursor = Vector2.zero;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(this.viewRect, eventData.position, eventData.pressEventCamera, out this.m_PointerStartLocalCursor);
			this.m_ContentStartPosition = this.m_Content.anchoredPosition;
			this.m_Dragging = true;
		}

		// Token: 0x0600297A RID: 10618 RVA: 0x004598A0 File Offset: 0x00457AA0
		public virtual void OnEndDrag(PointerEventData eventData)
		{
			if (eventData.button != PointerEventData.InputButton.Left)
			{
				return;
			}
			float num = Vector2.Distance(this.startPos, eventData.position);
			float num2 = Screen.dpi / 2.54f;
			if (num < num2 * 0.15f)
			{
				uButtonScale uButtonScale = eventData.pointerPressRaycast.gameObject.GetComponent(typeof(uButtonScale)) as uButtonScale;
				if (uButtonScale != null)
				{
					uButtonScale.OnPointerClick(eventData);
				}
				else
				{
					IPointerClickHandler pointerClickHandler = eventData.pointerPressRaycast.gameObject.GetComponent(typeof(IPointerClickHandler)) as IPointerClickHandler;
					if (pointerClickHandler != null)
					{
						pointerClickHandler.OnPointerClick(eventData);
					}
					else
					{
						byte b = 3;
						Transform transform = eventData.pointerPressRaycast.gameObject.transform;
						while (b > 0 && transform.parent)
						{
							ScrollPanelItem component = transform.parent.GetComponent<ScrollPanelItem>();
							if (component)
							{
								pointerClickHandler = (transform.parent.GetComponent(typeof(IPointerClickHandler)) as IPointerClickHandler);
								if (pointerClickHandler != null)
								{
									pointerClickHandler.OnPointerClick(eventData);
								}
								break;
							}
							b -= 1;
							transform = transform.parent;
						}
					}
				}
				this.startPos = Vector2.zero;
			}
			if (this.m_bInitViewState && (this.ViewState == ListViewState.LVS_PULL_REFRESH || this.ViewState == ListViewState.LVS_PULL_REFRESH_UP))
			{
				this.SwitchViewState(ListViewState.LVS_NORMAL);
			}
			if (this.bPageMove)
			{
				float num3 = Time.realtimeSinceStartup - this._time2;
				float num4 = eventData.position.x - this._pos2.x;
				float num5 = num4 / num3;
				if (GUIManager.Instance.IsArabic)
				{
					if (this.NowPageIndex > 0 && (num5 < -500f || (double)(this.m_Content.anchoredPosition.x - this.m_ContentStartPosition.x) >= (double)this.PageWidth * 0.5))
					{
						this.setCurrentIndex((byte)(this.NowPageIndex - 1), false);
					}
					else if (this.NowPageIndex < this.PageQuantity - 1 && (num5 > 500f || (double)(-(double)(this.m_Content.anchoredPosition.x - this.m_ContentStartPosition.x)) >= (double)this.PageWidth * 0.5))
					{
						this.setCurrentIndex((byte)(this.NowPageIndex + 1), false);
					}
					else
					{
						this.setCurrentIndex(this.NowPageIndex, false);
					}
				}
				else if (this.NowPageIndex > 0 && (num5 > 500f || (double)(this.m_Content.anchoredPosition.x - this.m_ContentStartPosition.x) >= (double)this.PageWidth * 0.5))
				{
					this.setCurrentIndex((byte)(this.NowPageIndex - 1), false);
				}
				else if (this.NowPageIndex < this.PageQuantity - 1 && (num5 < -500f || (double)(-(double)(this.m_Content.anchoredPosition.x - this.m_ContentStartPosition.x)) >= (double)this.PageWidth * 0.5))
				{
					this.setCurrentIndex((byte)(this.NowPageIndex + 1), false);
				}
				else
				{
					this.setCurrentIndex(this.NowPageIndex, false);
				}
			}
			this.m_Dragging = false;
		}

		// Token: 0x0600297B RID: 10619 RVA: 0x00459C2C File Offset: 0x00457E2C
		public virtual void OnDrag(PointerEventData eventData)
		{
			if (eventData.button != PointerEventData.InputButton.Left)
			{
				return;
			}
			if (!this.IsActive())
			{
				return;
			}
			if (this.m_bInitViewState && this.CheckBeLoad())
			{
				return;
			}
			if (this.startPos != Vector2.zero)
			{
				float num = Vector2.Distance(this.startPos, eventData.position);
				float num2 = Screen.dpi / 2.54f;
				if (eventData.pointerPressRaycast.gameObject != null && num > num2 * 0.15f)
				{
					uButtonScale uButtonScale = eventData.pointerPressRaycast.gameObject.GetComponent(typeof(uButtonScale)) as uButtonScale;
					if (uButtonScale != null)
					{
						uButtonScale.OnPointerExit(eventData);
					}
				}
			}
			if (this.bPageMove)
			{
				this._pos2 = this._pos1;
				this._time2 = this._time1;
				this._pos1 = eventData.position;
				this._time1 = Time.realtimeSinceStartup;
			}
			Vector2 a;
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(this.viewRect, eventData.position, eventData.pressEventCamera, out a))
			{
				return;
			}
			this.UpdateBounds();
			Vector2 b = a - this.m_PointerStartLocalCursor;
			Vector2 vector = this.m_ContentStartPosition + b;
			Vector2 b2 = this.CalculateOffset(vector - this.m_Content.anchoredPosition);
			vector += b2;
			if (this.m_MovementType == CScrollRect.MovementType.Elastic)
			{
				if (b2.x != 0f)
				{
					vector.x -= CScrollRect.RubberDelta(b2.x, this.m_ViewBounds.size.x);
				}
				if (b2.y != 0f)
				{
					vector.y -= CScrollRect.RubberDelta(b2.y, this.m_ViewBounds.size.y);
				}
			}
			this.SetContentAnchoredPosition(vector);
			if (this.m_Vertical && this.m_Inertia)
			{
				if (!this.m_bStopViewState && b2.y > 0f)
				{
					switch (this.m_ViewState)
					{
					case ListViewState.LVS_NORMAL:
						this.SwitchViewState(ListViewState.LVS_PULL_REFRESH);
						break;
					case ListViewState.LVS_PULL_REFRESH:
						if (b2.y > this.m_HeadContentHeight)
						{
							this.SwitchViewState(ListViewState.LVS_RELEASE_REFRESH);
						}
						break;
					case ListViewState.LVS_RELEASE_REFRESH:
						if (b2.y <= this.m_HeadContentHeight)
						{
							this.m_Back = true;
							this.SwitchViewState(ListViewState.LVS_PULL_REFRESH);
						}
						break;
					}
				}
				else if (!this.m_bStopViewState_Up && b2.y < 0f)
				{
					ListViewState viewState = this.m_ViewState;
					if (viewState != ListViewState.LVS_PULL_REFRESH_UP)
					{
						if (viewState != ListViewState.LVS_RELEASE_REFRESH_UP)
						{
							if (viewState == ListViewState.LVS_NORMAL)
							{
								this.SwitchViewState(ListViewState.LVS_PULL_REFRESH_UP);
							}
						}
						else if (b2.y >= -this.m_HeadContentHeight)
						{
							this.m_Back = true;
							this.SwitchViewState(ListViewState.LVS_PULL_REFRESH_UP);
						}
					}
					else if (b2.y < -this.m_HeadContentHeight)
					{
						this.SwitchViewState(ListViewState.LVS_RELEASE_REFRESH_UP);
					}
				}
				else
				{
					this.SwitchViewState(ListViewState.LVS_NORMAL);
				}
			}
		}

		// Token: 0x0600297C RID: 10620 RVA: 0x00459F74 File Offset: 0x00458174
		protected virtual void SetContentAnchoredPosition(Vector2 position)
		{
			if (!this.m_Horizontal)
			{
				position.x = this.m_Content.anchoredPosition.x;
			}
			if (!this.m_Vertical)
			{
				position.y = this.m_Content.anchoredPosition.y;
			}
			if (position != this.m_Content.anchoredPosition)
			{
				this.m_Content.anchoredPosition = position;
				this.UpdateBounds();
			}
		}

		// Token: 0x0600297D RID: 10621 RVA: 0x00459FF4 File Offset: 0x004581F4
		protected virtual void LateUpdate()
		{
			if (!this.m_Content)
			{
				return;
			}
			if (this.m_bInitViewState && this.CheckBeLoad())
			{
				if (this.m_ViewState == ListViewState.LVS_WAITLOADING || this.m_ViewState == ListViewState.LVS_WAITLOADING_UP)
				{
					this.m_VSImageRC.Rotate(Vector3.forward * Time.smoothDeltaTime * -200f);
				}
				return;
			}
			this.EnsureLayoutHasRebuilt();
			this.UpdateBounds();
			float smoothDeltaTime = Time.smoothDeltaTime;
			Vector2 vector = this.CalculateOffset(Vector2.zero);
			if (!this.bPageMove && !this.m_Dragging && (vector != Vector2.zero || this.m_Velocity != Vector2.zero))
			{
				Vector2 vector2 = this.m_Content.anchoredPosition;
				for (int i = 0; i < 2; i++)
				{
					if (this.m_MovementType == CScrollRect.MovementType.Elastic && vector[i] != 0f)
					{
						float value = this.m_Velocity[i];
						vector2[i] = Mathf.SmoothDamp(this.m_Content.anchoredPosition[i], this.m_Content.anchoredPosition[i] + vector[i], ref value, this.m_Elasticity, float.PositiveInfinity, smoothDeltaTime);
						this.m_Velocity[i] = value;
					}
					else if (this.m_Inertia)
					{
						ref Vector2 ptr = ref this.m_Velocity;
						int index2;
						int index = index2 = i;
						float num = ptr[index2];
						this.m_Velocity[index] = num * Mathf.Pow(this.m_DecelerationRate, smoothDeltaTime);
						if (Mathf.Abs(this.m_Velocity[i]) < 1f)
						{
							this.m_Velocity[i] = 0f;
						}
						ref Vector2 ptr2 = ref vector2;
						int index3 = index2 = i;
						num = ptr2[index2];
						vector2[index3] = num + this.m_Velocity[i] * smoothDeltaTime;
					}
					else
					{
						this.m_Velocity[i] = 0f;
					}
				}
				if (this.m_Velocity != Vector2.zero)
				{
					if (this.m_MovementType == CScrollRect.MovementType.Clamped)
					{
						vector = this.CalculateOffset(vector2 - this.m_Content.anchoredPosition);
						vector2 += vector;
					}
					if (this.m_bInitViewState)
					{
						if (this.m_ViewState == ListViewState.LVS_RELEASE_REFRESH && vector.y <= this.m_HeadContentHeight)
						{
							this.SwitchViewState(ListViewState.LVS_LOADING);
							return;
						}
						if (this.m_ViewState == ListViewState.LVS_RELEASE_REFRESH_UP && vector.y >= -this.m_HeadContentHeight)
						{
							this.SwitchViewState(ListViewState.LVS_LOADING_UP);
							return;
						}
					}
					this.SetContentAnchoredPosition(vector2);
				}
			}
			if (this.bPageMove && !this.m_Dragging)
			{
				if (this.MoveEndX != -1f)
				{
					if (this.m_Content.anchoredPosition.x == this.MoveEndX)
					{
						this.MoveEndX = -1f;
					}
					else
					{
						Vector2 anchoredPosition = this.m_Content.anchoredPosition;
						anchoredPosition[0] = Mathf.SmoothDamp(this.m_Content.anchoredPosition.x, this.MoveEndX, ref this.PageMoveSpeed, this.m_Elasticity, float.PositiveInfinity, Time.unscaledDeltaTime);
						this.SetContentAnchoredPosition(anchoredPosition);
						if (Mathf.Abs(Mathf.Abs(anchoredPosition[0]) - Mathf.Abs(this.MoveEndX)) <= 1f)
						{
							this.MoveEndX = -1f;
						}
					}
				}
				else if (this.m_PageMoveHandler != null && this.bPageMoving)
				{
					this.m_PageMoveHandler.EndPageMove();
					this.bPageMoving = false;
				}
			}
			if (this.m_Dragging && this.m_Inertia)
			{
				Vector3 to = (this.m_Content.anchoredPosition - this.m_PrevPosition) / smoothDeltaTime;
				this.m_Velocity = Vector3.Lerp(this.m_Velocity, to, smoothDeltaTime * 10f);
			}
			if (this.m_ViewBounds != this.m_PrevViewBounds || this.m_ContentBounds != this.m_PrevContentBounds || this.m_Content.anchoredPosition != this.m_PrevPosition)
			{
				this.UpdateScrollbars(vector);
				if (this.m_Handler != null)
				{
					this.m_Handler.onValueChanged();
				}
				this.UpdatePrevData();
			}
		}

		// Token: 0x0600297E RID: 10622 RVA: 0x0045A47C File Offset: 0x0045867C
		private void UpdatePrevData()
		{
			if (this.m_Content == null)
			{
				this.m_PrevPosition = Vector2.zero;
			}
			else
			{
				this.m_PrevPosition = this.m_Content.anchoredPosition;
			}
			this.m_PrevViewBounds = this.m_ViewBounds;
			this.m_PrevContentBounds = this.m_ContentBounds;
		}

		// Token: 0x0600297F RID: 10623 RVA: 0x0045A4D4 File Offset: 0x004586D4
		private void UpdateScrollbars(Vector2 offset)
		{
			if (this.m_HorizontalScrollbar)
			{
				this.m_HorizontalScrollbar.size = Mathf.Clamp01((this.m_ViewBounds.size.x - Mathf.Abs(offset.x)) / this.m_ContentBounds.size.x);
				this.m_HorizontalScrollbar.value = this.horizontalNormalizedPosition;
			}
			if (this.m_VerticalScrollbar)
			{
				this.m_VerticalScrollbar.size = Mathf.Clamp01((this.m_ViewBounds.size.y - Mathf.Abs(offset.y)) / this.m_ContentBounds.size.y);
				this.m_VerticalScrollbar.value = this.verticalNormalizedPosition;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06002980 RID: 10624 RVA: 0x0045A5AC File Offset: 0x004587AC
		// (set) Token: 0x06002981 RID: 10625 RVA: 0x0045A5C0 File Offset: 0x004587C0
		public Vector2 normalizedPosition
		{
			get
			{
				return new Vector2(this.horizontalNormalizedPosition, this.verticalNormalizedPosition);
			}
			set
			{
				this.SetNormalizedPosition(value.x, 0);
				this.SetNormalizedPosition(value.y, 1);
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06002982 RID: 10626 RVA: 0x0045A5E0 File Offset: 0x004587E0
		// (set) Token: 0x06002983 RID: 10627 RVA: 0x0045A6A8 File Offset: 0x004588A8
		public float horizontalNormalizedPosition
		{
			get
			{
				this.UpdateBounds();
				if (this.m_ContentBounds.size.x <= this.m_ViewBounds.size.x)
				{
					return (float)((this.m_ViewBounds.min.x <= this.m_ContentBounds.min.x) ? 0 : 1);
				}
				return (this.m_ViewBounds.min.x - this.m_ContentBounds.min.x) / (this.m_ContentBounds.size.x - this.m_ViewBounds.size.x);
			}
			set
			{
				this.SetNormalizedPosition(value, 0);
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06002984 RID: 10628 RVA: 0x0045A6B4 File Offset: 0x004588B4
		// (set) Token: 0x06002985 RID: 10629 RVA: 0x0045A77C File Offset: 0x0045897C
		public float verticalNormalizedPosition
		{
			get
			{
				this.UpdateBounds();
				if (this.m_ContentBounds.size.y <= this.m_ViewBounds.size.y)
				{
					return (float)((this.m_ViewBounds.min.y <= this.m_ContentBounds.min.y) ? 0 : 1);
				}
				return (this.m_ViewBounds.min.y - this.m_ContentBounds.min.y) / (this.m_ContentBounds.size.y - this.m_ViewBounds.size.y);
			}
			set
			{
				this.SetNormalizedPosition(value, 1);
			}
		}

		// Token: 0x06002986 RID: 10630 RVA: 0x0045A788 File Offset: 0x00458988
		private void SetHorizontalNormalizedPosition(float value)
		{
			this.SetNormalizedPosition(value, 0);
		}

		// Token: 0x06002987 RID: 10631 RVA: 0x0045A794 File Offset: 0x00458994
		private void SetVerticalNormalizedPosition(float value)
		{
			this.SetNormalizedPosition(value, 1);
		}

		// Token: 0x06002988 RID: 10632 RVA: 0x0045A7A0 File Offset: 0x004589A0
		private void SetNormalizedPosition(float value, int axis)
		{
			this.EnsureLayoutHasRebuilt();
			this.UpdateBounds();
			float num = this.m_ContentBounds.size[axis] - this.m_ViewBounds.size[axis];
			float num2 = this.m_ViewBounds.min[axis] - value * num;
			float num3 = this.m_Content.localPosition[axis] + num2 - this.m_ContentBounds.min[axis];
			Vector3 localPosition = this.m_Content.localPosition;
			if (Mathf.Abs(localPosition[axis] - num3) > 0.01f)
			{
				localPosition[axis] = num3;
				this.m_Content.localPosition = localPosition;
				this.m_Velocity[axis] = 0f;
				this.UpdateBounds();
			}
		}

		// Token: 0x06002989 RID: 10633 RVA: 0x0045A880 File Offset: 0x00458A80
		private static float RubberDelta(float overStretching, float viewSize)
		{
			return (1f - 1f / (Mathf.Abs(overStretching) * 0.55f / viewSize + 1f)) * viewSize * Mathf.Sign(overStretching);
		}

		// Token: 0x0600298A RID: 10634 RVA: 0x0045A8AC File Offset: 0x00458AAC
		private void UpdateBounds()
		{
			this.m_ViewBounds = new Bounds(this.viewRect.rect.center, this.viewRect.rect.size);
			this.m_ContentBounds = this.GetBounds();
			if (this.m_Content == null)
			{
				return;
			}
			Vector3 size = this.m_ContentBounds.size;
			Vector3 center = this.m_ContentBounds.center;
			Vector3 vector = this.m_ViewBounds.size - size;
			if (vector.x > 0f)
			{
				center.x -= vector.x * (this.m_Content.pivot.x - 0.5f);
				size.x = this.m_ViewBounds.size.x;
			}
			if (vector.y > 0f)
			{
				center.y -= vector.y * (this.m_Content.pivot.y - 0.5f);
				size.y = this.m_ViewBounds.size.y;
			}
			this.m_ContentBounds.size = size;
			this.m_ContentBounds.center = center;
		}

		// Token: 0x0600298B RID: 10635 RVA: 0x0045AA10 File Offset: 0x00458C10
		private Bounds GetBounds()
		{
			if (this.m_Content == null)
			{
				return default(Bounds);
			}
			Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			Vector3 vector2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			Matrix4x4 worldToLocalMatrix = this.viewRect.worldToLocalMatrix;
			this.m_Content.GetWorldCorners(this.m_Corners);
			for (int i = 0; i < 4; i++)
			{
				Vector3 lhs = worldToLocalMatrix.MultiplyPoint3x4(this.m_Corners[i]);
				vector = Vector3.Min(lhs, vector);
				vector2 = Vector3.Max(lhs, vector2);
			}
			Bounds result = new Bounds(vector, Vector3.zero);
			result.Encapsulate(vector2);
			return result;
		}

		// Token: 0x0600298C RID: 10636 RVA: 0x0045AAD8 File Offset: 0x00458CD8
		private Vector2 CalculateOffset(Vector2 delta)
		{
			Vector2 zero = Vector2.zero;
			if (this.m_MovementType == CScrollRect.MovementType.Unrestricted)
			{
				return zero;
			}
			Vector2 vector = this.m_ContentBounds.min;
			Vector2 vector2 = this.m_ContentBounds.max;
			if (this.m_Horizontal)
			{
				vector.x += delta.x;
				vector2.x += delta.x;
				if (vector.x > this.m_ViewBounds.min.x)
				{
					zero.x = this.m_ViewBounds.min.x - vector.x;
				}
				else if (vector2.x < this.m_ViewBounds.max.x)
				{
					zero.x = this.m_ViewBounds.max.x - vector2.x;
				}
			}
			if (this.m_Vertical)
			{
				vector.y += delta.y;
				vector2.y += delta.y;
				if (vector2.y < this.m_ViewBounds.max.y)
				{
					zero.y = this.m_ViewBounds.max.y - vector2.y;
				}
				else if (vector.y > this.m_ViewBounds.min.y)
				{
					zero.y = this.m_ViewBounds.min.y - vector.y;
				}
			}
			return zero;
		}

		// Token: 0x0600298D RID: 10637 RVA: 0x0045AC9C File Offset: 0x00458E9C
		public void InitViewState(UIText tmpT, Image tmpI)
		{
			if (!this.m_bInitViewState)
			{
				this.m_bInitViewState = true;
				this.m_VSText = tmpT;
				this.m_VSImage = tmpI;
				this.m_VSImageRC = this.m_VSImage.rectTransform;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x0600298E RID: 10638 RVA: 0x0045ACD0 File Offset: 0x00458ED0
		// (set) Token: 0x0600298F RID: 10639 RVA: 0x0045ACD8 File Offset: 0x00458ED8
		public bool bStopViewState
		{
			get
			{
				return this.m_bStopViewState;
			}
			set
			{
				if (this.m_bStopViewState == value)
				{
					return;
				}
				this.m_bStopViewState = value;
				if (this.m_ViewState >= ListViewState.LVS_PULL_REFRESH && this.m_ViewState <= ListViewState.LVS_WAITLOADING)
				{
					this.m_ViewState = ListViewState.LVS_NORMAL;
					if (this.m_bInitViewState)
					{
						this.m_VSImage.enabled = false;
						this.m_VSText.enabled = false;
					}
				}
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06002990 RID: 10640 RVA: 0x0045AD3C File Offset: 0x00458F3C
		// (set) Token: 0x06002991 RID: 10641 RVA: 0x0045AD44 File Offset: 0x00458F44
		public bool bStopViewState_Up
		{
			get
			{
				return this.m_bStopViewState_Up;
			}
			set
			{
				if (this.m_bStopViewState_Up == value)
				{
					return;
				}
				this.m_bStopViewState_Up = value;
				if (this.m_ViewState >= ListViewState.LVS_PULL_REFRESH_UP && this.m_ViewState <= ListViewState.LVS_WAITLOADING_UP)
				{
					this.m_ViewState = ListViewState.LVS_NORMAL;
					if (this.m_bInitViewState)
					{
						this.m_VSImage.enabled = false;
						this.m_VSText.enabled = false;
					}
				}
			}
		}

		// Token: 0x06002992 RID: 10642 RVA: 0x0045ADA8 File Offset: 0x00458FA8
		public void SwitchViewState(ListViewState state)
		{
			if (!this.m_bInitViewState)
			{
				return;
			}
			switch (state)
			{
			case ListViewState.LVS_NORMAL:
				this.m_VSImage.enabled = false;
				this.m_VSText.enabled = false;
				break;
			case ListViewState.LVS_PULL_REFRESH:
			case ListViewState.LVS_PULL_REFRESH_UP:
				this.m_VSImage.enabled = true;
				this.m_VSText.enabled = true;
				if (state == ListViewState.LVS_PULL_REFRESH)
				{
					this.m_VSText.text = DataManager.Instance.mStringTable.GetStringByID(179u);
				}
				else
				{
					this.m_VSText.text = DataManager.Instance.mStringTable.GetStringByID(200u);
				}
				if (this.m_Back)
				{
					this.m_Back = false;
				}
				break;
			case ListViewState.LVS_RELEASE_REFRESH:
			case ListViewState.LVS_RELEASE_REFRESH_UP:
				this.m_VSImage.enabled = true;
				this.m_VSText.enabled = true;
				this.m_VSText.text = DataManager.Instance.mStringTable.GetStringByID(180u);
				break;
			case ListViewState.LVS_LOADING:
			case ListViewState.LVS_LOADING_UP:
				this.m_VSImage.enabled = true;
				this.m_VSText.enabled = false;
				break;
			}
			this.m_ViewState = state;
		}

		// Token: 0x06002993 RID: 10643 RVA: 0x0045AEE4 File Offset: 0x004590E4
		public bool CheckBeLoad()
		{
			return this.m_ViewState == ListViewState.LVS_LOADING || this.m_ViewState == ListViewState.LVS_WAITLOADING || this.m_ViewState == ListViewState.LVS_LOADING_UP || this.m_ViewState == ListViewState.LVS_WAITLOADING_UP;
		}

		// Token: 0x06002994 RID: 10644 RVA: 0x0045AF24 File Offset: 0x00459124
		public void setCurrentIndex(byte value, bool immediate = false)
		{
			if (!this.bPageMove)
			{
				return;
			}
			if (this.NowPageIndex != value)
			{
				this.NowPageIndex = value;
			}
			if (immediate)
			{
				this.m_Content.anchoredPosition = new Vector2((float)this.NowPageIndex * -this.PageWidth, this.m_Content.anchoredPosition.y);
			}
			else
			{
				this.MoveEndX = (float)this.NowPageIndex * -this.PageWidth;
			}
			if (this.m_PageMoveHandler != null)
			{
				this.m_PageMoveHandler.PageIndexChange(this.NowPageIndex);
			}
		}

		// Token: 0x06002995 RID: 10645 RVA: 0x0045AFC0 File Offset: 0x004591C0
		public void ChangePageWidth(float NewWidth)
		{
			if (this.bPageMove && this.m_Content != null)
			{
				this.MoveEndX = -1f;
				this.PageWidth = NewWidth;
				this.m_Content.sizeDelta = new Vector2(this.PageWidth * (float)this.PageQuantity, this.m_Content.sizeDelta.y);
				this.m_Content.anchoredPosition = new Vector2((float)this.NowPageIndex * -this.PageWidth, this.m_Content.anchoredPosition.y);
				for (int i = 0; i < (int)this.PageQuantity; i++)
				{
					RectTransform component = this.m_Content.GetChild(i).GetComponent<RectTransform>();
					component.sizeDelta = new Vector2(this.PageWidth, component.sizeDelta.y);
					component.anchoredPosition = new Vector2(this.PageWidth * (float)i, component.anchoredPosition.y);
				}
			}
		}

		// Token: 0x06002996 RID: 10646 RVA: 0x0045B0CC File Offset: 0x004592CC
		public bool IsAtLast()
		{
			return this.m_Content != null && this.m_Content.sizeDelta.y - this.m_Content.anchoredPosition.y <= this.viewRect.sizeDelta.y;
		}

        // Token: 0x06002997 RID: 10647 RVA: 0x0045B12C File Offset: 0x0045932C
        protected virtual Transform get_transform()
		{
			return base.transform;
		}

        // Token: 0x06002998 RID: 10648 RVA: 0x0045B134 File Offset: 0x00459334
        protected virtual bool IsDestroyed()
		{
			return base.IsDestroyed();
		}

		// Token: 0x0400746B RID: 29803
		[SerializeField]
		private RectTransform m_Content;

		// Token: 0x0400746C RID: 29804
		[SerializeField]
		private bool m_Horizontal = true;

		// Token: 0x0400746D RID: 29805
		[SerializeField]
		private bool m_Vertical = true;

		// Token: 0x0400746E RID: 29806
		[SerializeField]
		private CScrollRect.MovementType m_MovementType = CScrollRect.MovementType.Elastic;

		// Token: 0x0400746F RID: 29807
		[SerializeField]
		private float m_Elasticity = 0.1f;

		// Token: 0x04007470 RID: 29808
		[SerializeField]
		private bool m_Inertia = true;

		// Token: 0x04007471 RID: 29809
		[SerializeField]
		private float m_DecelerationRate = 0.135f;

		// Token: 0x04007472 RID: 29810
		[SerializeField]
		private float m_ScrollSensitivity = 1f;

		// Token: 0x04007473 RID: 29811
		[SerializeField]
		private Scrollbar m_HorizontalScrollbar;

		// Token: 0x04007474 RID: 29812
		[SerializeField]
		private Scrollbar m_VerticalScrollbar;

		// Token: 0x04007475 RID: 29813
		[SerializeField]
		private CScrollRect.ScrollRectEvent m_OnValueChanged = new CScrollRect.ScrollRectEvent();

		// Token: 0x04007476 RID: 29814
		private Vector2 m_PointerStartLocalCursor = Vector2.zero;

		// Token: 0x04007477 RID: 29815
		private Vector2 m_ContentStartPosition = Vector2.zero;

		// Token: 0x04007478 RID: 29816
		private RectTransform m_ViewRect;

		// Token: 0x04007479 RID: 29817
		private Bounds m_ContentBounds;

		// Token: 0x0400747A RID: 29818
		private Bounds m_ViewBounds;

		// Token: 0x0400747B RID: 29819
		private Vector2 m_Velocity;

		// Token: 0x0400747C RID: 29820
		private bool m_Dragging;

		// Token: 0x0400747D RID: 29821
		private Vector2 m_PrevPosition = Vector2.zero;

		// Token: 0x0400747E RID: 29822
		private Bounds m_PrevContentBounds;

		// Token: 0x0400747F RID: 29823
		private Bounds m_PrevViewBounds;

		// Token: 0x04007480 RID: 29824
		[NonSerialized]
		private bool m_HasRebuiltLayout;

		// Token: 0x04007481 RID: 29825
		public IValueChanged m_Handler;

		// Token: 0x04007482 RID: 29826
		private ListViewState m_ViewState;

		// Token: 0x04007483 RID: 29827
		private bool m_bInitViewState;

		// Token: 0x04007484 RID: 29828
		private bool m_bStopViewState = true;

		// Token: 0x04007485 RID: 29829
		private bool m_bStopViewState_Up = true;

		// Token: 0x04007486 RID: 29830
		private bool m_Back;

		// Token: 0x04007487 RID: 29831
		private float m_HeadContentHeight = 50f;

		// Token: 0x04007488 RID: 29832
		private UIText m_VSText;

		// Token: 0x04007489 RID: 29833
		private Image m_VSImage;

		// Token: 0x0400748A RID: 29834
		private RectTransform m_VSImageRC;

		// Token: 0x0400748B RID: 29835
		public bool bPageMove;

		// Token: 0x0400748C RID: 29836
		public bool bPageMoving;

		// Token: 0x0400748D RID: 29837
		public byte NowPageIndex;

		// Token: 0x0400748E RID: 29838
		public byte PageQuantity = 2;

		// Token: 0x0400748F RID: 29839
		public float PageWidth = 433f;

		// Token: 0x04007490 RID: 29840
		public Vector2 _pos1 = Vector2.zero;

		// Token: 0x04007491 RID: 29841
		public Vector2 _pos2 = Vector2.zero;

		// Token: 0x04007492 RID: 29842
		public float _time1;

		// Token: 0x04007493 RID: 29843
		public float _time2;

		// Token: 0x04007494 RID: 29844
		public float MoveEndX = -1f;

		// Token: 0x04007495 RID: 29845
		public float PageMoveSpeed;

		// Token: 0x04007496 RID: 29846
		public IPagemove m_PageMoveHandler;

		// Token: 0x04007497 RID: 29847
		private Vector2 startPos = default(Vector2);

		// Token: 0x04007498 RID: 29848
		private readonly Vector3[] m_Corners = new Vector3[4];

		// Token: 0x020007D3 RID: 2003
		public enum MovementType
		{
			// Token: 0x0400749A RID: 29850
			Unrestricted,
			// Token: 0x0400749B RID: 29851
			Elastic,
			// Token: 0x0400749C RID: 29852
			Clamped
		}

		// Token: 0x020007D4 RID: 2004
		[Serializable]
		public class ScrollRectEvent : UnityEvent<Vector2>
		{
		}
	}
}
