using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	// Token: 0x020007D5 RID: 2005
	[RequireComponent(typeof(RectTransform))]
	public class CSlider : Selectable, IDragHandler, IInitializePotentialDragHandler, ICanvasElement, IEventSystemHandler
	{
		// Token: 0x0600299A RID: 10650 RVA: 0x0045B144 File Offset: 0x00459344
		protected CSlider()
		{
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x0600299B RID: 10651 RVA: 0x0045B18C File Offset: 0x0045938C
		// (set) Token: 0x0600299C RID: 10652 RVA: 0x0045B194 File Offset: 0x00459394
		public RectTransform fillRect
		{
			get
			{
				return this.m_FillRect;
			}
			set
			{
				if (SetPropertyUtility.SetClass<RectTransform>(ref this.m_FillRect, value))
				{
					this.UpdateCachedReferences();
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600299D RID: 10653 RVA: 0x0045B1B4 File Offset: 0x004593B4
		// (set) Token: 0x0600299E RID: 10654 RVA: 0x0045B1BC File Offset: 0x004593BC
		public RectTransform handleRect
		{
			get
			{
				return this.m_HandleRect;
			}
			set
			{
				if (SetPropertyUtility.SetClass<RectTransform>(ref this.m_HandleRect, value))
				{
					this.UpdateCachedReferences();
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600299F RID: 10655 RVA: 0x0045B1DC File Offset: 0x004593DC
		// (set) Token: 0x060029A0 RID: 10656 RVA: 0x0045B1E4 File Offset: 0x004593E4
		public CSlider.Direction direction
		{
			get
			{
				return this.m_Direction;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<CSlider.Direction>(ref this.m_Direction, value))
				{
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060029A1 RID: 10657 RVA: 0x0045B200 File Offset: 0x00459400
		// (set) Token: 0x060029A2 RID: 10658 RVA: 0x0045B208 File Offset: 0x00459408
		public double minValue
		{
			get
			{
				return this.m_MinValue;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<double>(ref this.m_MinValue, value))
				{
					this.Set(this.m_Value);
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060029A3 RID: 10659 RVA: 0x0045B230 File Offset: 0x00459430
		// (set) Token: 0x060029A4 RID: 10660 RVA: 0x0045B238 File Offset: 0x00459438
		public double maxValue
		{
			get
			{
				return this.m_MaxValue;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<double>(ref this.m_MaxValue, value))
				{
					this.Set(this.m_Value);
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060029A5 RID: 10661 RVA: 0x0045B260 File Offset: 0x00459460
		// (set) Token: 0x060029A6 RID: 10662 RVA: 0x0045B268 File Offset: 0x00459468
		public bool wholeNumbers
		{
			get
			{
				return this.m_WholeNumbers;
			}
			set
			{
				if (SetPropertyUtility.SetStruct<bool>(ref this.m_WholeNumbers, value))
				{
					this.Set(this.m_Value);
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060029A7 RID: 10663 RVA: 0x0045B290 File Offset: 0x00459490
		// (set) Token: 0x060029A8 RID: 10664 RVA: 0x0045B2B0 File Offset: 0x004594B0
		public double value
		{
			get
			{
				if (this.wholeNumbers)
				{
					return Math.Round(this.m_Value);
				}
				return this.m_Value;
			}
			set
			{
				this.Set(value);
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060029A9 RID: 10665 RVA: 0x0045B2BC File Offset: 0x004594BC
		// (set) Token: 0x060029AA RID: 10666 RVA: 0x0045B308 File Offset: 0x00459508
		public double normalizedValue
		{
			get
			{
				if (Mathf.Approximately((float)this.minValue, (float)this.maxValue))
				{
					return 0.0;
				}
				return (double)Mathf.InverseLerp((float)this.minValue, (float)this.maxValue, (float)this.value);
			}
			set
			{
				if (value < 0.0)
				{
					this.value = this.minValue;
				}
				else if (value > 1.0)
				{
					this.value = this.maxValue;
				}
				else
				{
					this.value = this.minValue + value * (this.maxValue - this.minValue);
				}
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060029AB RID: 10667 RVA: 0x0045B374 File Offset: 0x00459574
		// (set) Token: 0x060029AC RID: 10668 RVA: 0x0045B37C File Offset: 0x0045957C
		public CSlider.SliderEvent onValueChanged
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

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060029AD RID: 10669 RVA: 0x0045B388 File Offset: 0x00459588
		private double stepSize
		{
			get
			{
				return (!this.wholeNumbers) ? ((this.maxValue - this.minValue) * 0.1) : 1.0;
			}
		}

		// Token: 0x060029AE RID: 10670 RVA: 0x0045B3C8 File Offset: 0x004595C8
		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		// Token: 0x060029AF RID: 10671 RVA: 0x0045B3CC File Offset: 0x004595CC
		protected override void OnEnable()
		{
			base.OnEnable();
			this.UpdateCachedReferences();
			this.Set(this.m_Value, false);
			this.UpdateVisuals();
		}

		// Token: 0x060029B0 RID: 10672 RVA: 0x0045B3F0 File Offset: 0x004595F0
		protected override void OnDisable()
		{
			this.m_Tracker.Clear();
			base.OnDisable();
		}

		// Token: 0x060029B1 RID: 10673 RVA: 0x0045B404 File Offset: 0x00459604
		private void UpdateCachedReferences()
		{
			if (this.m_FillRect)
			{
				this.m_FillTransform = this.m_FillRect.transform;
				this.m_FillImage = this.m_FillRect.GetComponent<Image>();
				if (this.m_FillTransform.parent != null)
				{
					this.m_FillContainerRect = this.m_FillTransform.parent.GetComponent<RectTransform>();
				}
			}
			else
			{
				this.m_FillContainerRect = null;
				this.m_FillImage = null;
			}
			if (this.m_HandleRect)
			{
				this.m_HandleTransform = this.m_HandleRect.transform;
				if (this.m_HandleTransform.parent != null)
				{
					this.m_HandleContainerRect = this.m_HandleTransform.parent.GetComponent<RectTransform>();
				}
			}
			else
			{
				this.m_HandleContainerRect = null;
			}
		}

		// Token: 0x060029B2 RID: 10674 RVA: 0x0045B4DC File Offset: 0x004596DC
		private void Set(double input)
		{
			this.Set(input, true);
		}

		// Token: 0x060029B3 RID: 10675 RVA: 0x0045B4E8 File Offset: 0x004596E8
		private void Set(double input, bool sendCallback)
		{
			double num;
			if (input < this.minValue)
			{
				num = this.minValue;
			}
			else if (input > this.maxValue)
			{
				num = this.maxValue;
			}
			else
			{
				num = input;
			}
			if (this.wholeNumbers)
			{
				num = Math.Round(num);
			}
			if (this.m_Value == num)
			{
				return;
			}
			this.m_Value = num;
			this.UpdateVisuals();
			if (sendCallback)
			{
				this.m_OnValueChanged.Invoke(num);
			}
		}

		// Token: 0x060029B4 RID: 10676 RVA: 0x0045B570 File Offset: 0x00459770
		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			if (!this.IsActive())
			{
				return;
			}
			this.UpdateVisuals();
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060029B5 RID: 10677 RVA: 0x0045B58C File Offset: 0x0045978C
		private CSlider.Axis axis
		{
			get
			{
				return (this.m_Direction != CSlider.Direction.LeftToRight && this.m_Direction != CSlider.Direction.RightToLeft) ? CSlider.Axis.Vertical : CSlider.Axis.Horizontal;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060029B6 RID: 10678 RVA: 0x0045B5AC File Offset: 0x004597AC
		private bool reverseValue
		{
			get
			{
				return this.m_Direction == CSlider.Direction.RightToLeft || this.m_Direction == CSlider.Direction.TopToBottom;
			}
		}

		// Token: 0x060029B7 RID: 10679 RVA: 0x0045B5C8 File Offset: 0x004597C8
		private void UpdateVisuals()
		{
			this.m_Tracker.Clear();
			if (this.m_FillContainerRect != null)
			{
				this.m_Tracker.Add(this, this.m_FillRect, DrivenTransformProperties.Anchors);
				Vector2 zero = Vector2.zero;
				Vector2 one = Vector2.one;
				if (this.m_FillImage != null && this.m_FillImage.type == Image.Type.Filled)
				{
					this.m_FillImage.fillAmount = (float)this.normalizedValue;
				}
				else if (this.reverseValue)
				{
					zero[(int)this.axis] = 1f - (float)this.normalizedValue;
				}
				else
				{
					one[(int)this.axis] = (float)this.normalizedValue;
				}
				this.m_FillRect.anchorMin = zero;
				this.m_FillRect.anchorMax = one;
			}
			if (this.m_HandleContainerRect != null)
			{
				this.m_Tracker.Add(this, this.m_HandleRect, DrivenTransformProperties.Anchors);
				Vector2 zero2 = Vector2.zero;
				Vector2 one2 = Vector2.one;
				int axis = (int)this.axis;
				float value = (!this.reverseValue) ? ((float)this.normalizedValue) : (1f - (float)this.normalizedValue);
				one2[(int)this.axis] = value;
				zero2[axis] = value;
				this.m_HandleRect.anchorMin = zero2;
				this.m_HandleRect.anchorMax = one2;
			}
		}

		// Token: 0x060029B8 RID: 10680 RVA: 0x0045B734 File Offset: 0x00459934
		private void UpdateDrag(PointerEventData eventData, Camera cam)
		{
			RectTransform rectTransform = this.m_HandleContainerRect ?? this.m_FillContainerRect;
			if (rectTransform != null && rectTransform.rect.size[(int)this.axis] > 0f)
			{
				Vector2 a;
				if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, cam, out a))
				{
					return;
				}
				a -= rectTransform.rect.position;
				double num;
				if ((a - this.m_Offset)[(int)this.axis] < 0f)
				{
					num = 0.0;
				}
				else if ((a - this.m_Offset)[(int)this.axis] > rectTransform.rect.size[(int)this.axis])
				{
					num = (double)rectTransform.rect.size[(int)this.axis];
				}
				else
				{
					num = (double)((a - this.m_Offset)[(int)this.axis] / rectTransform.rect.size[(int)this.axis]);
				}
				this.normalizedValue = ((!this.reverseValue) ? num : (1.0 - num));
			}
		}

		// Token: 0x060029B9 RID: 10681 RVA: 0x0045B8B4 File Offset: 0x00459AB4
		private bool MayDrag(PointerEventData eventData)
		{
			return this.IsActive() && this.IsInteractable() && eventData.button == PointerEventData.InputButton.Left;
		}

		// Token: 0x060029BA RID: 10682 RVA: 0x0045B8E4 File Offset: 0x00459AE4
		public override void OnPointerDown(PointerEventData eventData)
		{
			if (!this.MayDrag(eventData))
			{
				return;
			}
			base.OnPointerDown(eventData);
			this.m_Offset = Vector2.zero;
			if (this.m_HandleContainerRect != null && RectTransformUtility.RectangleContainsScreenPoint(this.m_HandleRect, eventData.position, eventData.enterEventCamera))
			{
				Vector2 offset;
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(this.m_HandleRect, eventData.position, eventData.pressEventCamera, out offset))
				{
					this.m_Offset = offset;
				}
			}
			else
			{
				this.UpdateDrag(eventData, eventData.pressEventCamera);
			}
		}

		// Token: 0x060029BB RID: 10683 RVA: 0x0045B974 File Offset: 0x00459B74
		public virtual void OnDrag(PointerEventData eventData)
		{
			if (!this.MayDrag(eventData))
			{
				return;
			}
			this.UpdateDrag(eventData, eventData.pressEventCamera);
		}

		// Token: 0x060029BC RID: 10684 RVA: 0x0045B990 File Offset: 0x00459B90
		public override void OnMove(AxisEventData eventData)
		{
			if (!this.IsActive() || !this.IsInteractable())
			{
				base.OnMove(eventData);
				return;
			}
			switch (eventData.moveDir)
			{
			case MoveDirection.Left:
				if (this.axis == CSlider.Axis.Horizontal && this.FindSelectableOnLeft() == null)
				{
					this.Set((!this.reverseValue) ? (this.value - this.stepSize) : (this.value + this.stepSize));
				}
				else
				{
					base.OnMove(eventData);
				}
				break;
			case MoveDirection.Up:
				if (this.axis == CSlider.Axis.Vertical && this.FindSelectableOnUp() == null)
				{
					this.Set((!this.reverseValue) ? (this.value + this.stepSize) : (this.value - this.stepSize));
				}
				else
				{
					base.OnMove(eventData);
				}
				break;
			case MoveDirection.Right:
				if (this.axis == CSlider.Axis.Horizontal && this.FindSelectableOnRight() == null)
				{
					this.Set((!this.reverseValue) ? (this.value + this.stepSize) : (this.value - this.stepSize));
				}
				else
				{
					base.OnMove(eventData);
				}
				break;
			case MoveDirection.Down:
				if (this.axis == CSlider.Axis.Vertical && this.FindSelectableOnDown() == null)
				{
					this.Set((!this.reverseValue) ? (this.value - this.stepSize) : (this.value + this.stepSize));
				}
				else
				{
					base.OnMove(eventData);
				}
				break;
			}
		}

		// Token: 0x060029BD RID: 10685 RVA: 0x0045BB54 File Offset: 0x00459D54
		public override Selectable FindSelectableOnLeft()
		{
			if (base.navigation.mode == Navigation.Mode.Automatic && this.axis == CSlider.Axis.Horizontal)
			{
				return null;
			}
			return base.FindSelectableOnLeft();
		}

		// Token: 0x060029BE RID: 10686 RVA: 0x0045BB88 File Offset: 0x00459D88
		public override Selectable FindSelectableOnRight()
		{
			if (base.navigation.mode == Navigation.Mode.Automatic && this.axis == CSlider.Axis.Horizontal)
			{
				return null;
			}
			return base.FindSelectableOnRight();
		}

		// Token: 0x060029BF RID: 10687 RVA: 0x0045BBBC File Offset: 0x00459DBC
		public override Selectable FindSelectableOnUp()
		{
			if (base.navigation.mode == Navigation.Mode.Automatic && this.axis == CSlider.Axis.Vertical)
			{
				return null;
			}
			return base.FindSelectableOnUp();
		}

		// Token: 0x060029C0 RID: 10688 RVA: 0x0045BBF4 File Offset: 0x00459DF4
		public override Selectable FindSelectableOnDown()
		{
			if (base.navigation.mode == Navigation.Mode.Automatic && this.axis == CSlider.Axis.Vertical)
			{
				return null;
			}
			return base.FindSelectableOnDown();
		}

		// Token: 0x060029C1 RID: 10689 RVA: 0x0045BC2C File Offset: 0x00459E2C
		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = false;
		}

		// Token: 0x060029C2 RID: 10690 RVA: 0x0045BC38 File Offset: 0x00459E38
		public void SetDirection(CSlider.Direction direction, bool includeRectLayouts)
		{
			CSlider.Axis axis = this.axis;
			bool reverseValue = this.reverseValue;
			this.direction = direction;
			if (!includeRectLayouts)
			{
				return;
			}
			if (this.axis != axis)
			{
				RectTransformUtility.FlipLayoutAxes(base.transform as RectTransform, true, true);
			}
			if (this.reverseValue != reverseValue)
			{
				RectTransformUtility.FlipLayoutOnAxis(base.transform as RectTransform, (int)this.axis, true, true);
			}
		}

        // Token: 0x060029C3 RID: 10691 RVA: 0x0045BCA4 File Offset: 0x00459EA4
        protected virtual Transform get_transform()
		{
			return base.transform;
		}

        // Token: 0x060029C4 RID: 10692 RVA: 0x0045BCAC File Offset: 0x00459EAC
        protected virtual bool IsDestroyed()
		{
			return base.IsDestroyed();
		}

		// Token: 0x0400749D RID: 29853
		[SerializeField]
		private RectTransform m_FillRect;

		// Token: 0x0400749E RID: 29854
		[SerializeField]
		private RectTransform m_HandleRect;

		// Token: 0x0400749F RID: 29855
		[Space(6f)]
		[SerializeField]
		private CSlider.Direction m_Direction;

		// Token: 0x040074A0 RID: 29856
		[SerializeField]
		private double m_MinValue;

		// Token: 0x040074A1 RID: 29857
		[SerializeField]
		private double m_MaxValue = 1.0;

		// Token: 0x040074A2 RID: 29858
		[SerializeField]
		private bool m_WholeNumbers;

		// Token: 0x040074A3 RID: 29859
		[SerializeField]
		private double m_Value = 1.0;

		// Token: 0x040074A4 RID: 29860
		[Space(6f)]
		[SerializeField]
		private CSlider.SliderEvent m_OnValueChanged = new CSlider.SliderEvent();

		// Token: 0x040074A5 RID: 29861
		private Image m_FillImage;

		// Token: 0x040074A6 RID: 29862
		private Transform m_FillTransform;

		// Token: 0x040074A7 RID: 29863
		private RectTransform m_FillContainerRect;

		// Token: 0x040074A8 RID: 29864
		private Transform m_HandleTransform;

		// Token: 0x040074A9 RID: 29865
		private RectTransform m_HandleContainerRect;

		// Token: 0x040074AA RID: 29866
		private Vector2 m_Offset = Vector2.zero;

		// Token: 0x040074AB RID: 29867
		private DrivenRectTransformTracker m_Tracker;

		// Token: 0x020007D6 RID: 2006
		public enum Direction
		{
			// Token: 0x040074AD RID: 29869
			LeftToRight,
			// Token: 0x040074AE RID: 29870
			RightToLeft,
			// Token: 0x040074AF RID: 29871
			BottomToTop,
			// Token: 0x040074B0 RID: 29872
			TopToBottom
		}

		// Token: 0x020007D7 RID: 2007
		[Serializable]
		public class SliderEvent : UnityEvent<double>
		{
		}

		// Token: 0x020007D8 RID: 2008
		private enum Axis
		{
			// Token: 0x040074B2 RID: 29874
			Horizontal,
			// Token: 0x040074B3 RID: 29875
			Vertical
		}
	}
}
