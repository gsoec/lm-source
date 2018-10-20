using System;
using System.Collections.Generic;
using System.Text;

namespace UnityEngine.EventSystems
{
	// Token: 0x02000056 RID: 86
	[AddComponentMenu("Event/Touch Input Module")]
	public class CusTouchInputModule : CusPointerInputModule
	{
		// Token: 0x06000265 RID: 613 RVA: 0x0001F2A0 File Offset: 0x0001D4A0
		protected CusTouchInputModule()
		{
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000266 RID: 614 RVA: 0x0001F2A8 File Offset: 0x0001D4A8
		// (set) Token: 0x06000267 RID: 615 RVA: 0x0001F2B0 File Offset: 0x0001D4B0
		public bool allowActivationOnStandalone
		{
			get
			{
				return this.m_AllowActivationOnStandalone;
			}
			set
			{
				this.m_AllowActivationOnStandalone = value;
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0001F2BC File Offset: 0x0001D4BC
		public override void UpdateModule()
		{
			this.m_LastMousePosition = this.m_MousePosition;
			this.m_MousePosition = Input.mousePosition;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0001F2DC File Offset: 0x0001D4DC
		public override bool IsModuleSupported()
		{
			return this.m_AllowActivationOnStandalone || Input.touchSupported;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0001F2F4 File Offset: 0x0001D4F4
		public override bool ShouldActivateModule()
		{
			if (!base.ShouldActivateModule())
			{
				return false;
			}
			if (this.UseFakeInput())
			{
				bool mouseButtonDown = Input.GetMouseButtonDown(0);
				return mouseButtonDown | (this.m_MousePosition - this.m_LastMousePosition).sqrMagnitude > 0f;
			}
			for (int i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);
				if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0001F38C File Offset: 0x0001D58C
		private bool UseFakeInput()
		{
			return !Input.touchSupported;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0001F398 File Offset: 0x0001D598
		public override void Process()
		{
			if (this.UseFakeInput())
			{
				this.FakeTouches();
			}
			else
			{
				this.ProcessTouchEvents();
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0001F3B8 File Offset: 0x0001D5B8
		private void FakeTouches()
		{
			CusPointerInputModule.MouseState mousePointerEventData = this.GetMousePointerEventData();
			CusPointerInputModule.MouseButtonEventData eventData = mousePointerEventData.GetButtonState(PointerEventData.InputButton.Left, 0).eventData;
			if (eventData.PressedThisFrame())
			{
				eventData.buttonData.delta = Vector2.zero;
			}
			this.ProcessTouchPress(eventData.buttonData, eventData.PressedThisFrame(), eventData.ReleasedThisFrame());
			if (Input.GetMouseButton(0))
			{
				this.ProcessMove(eventData.buttonData);
				this.ProcessDrag(eventData.buttonData);
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0001F430 File Offset: 0x0001D630
		private void ProcessTouchEvents()
		{
			this.MaskEvent = null;
			this.MaskRay = null;
			for (int i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);
				bool pressed;
				bool flag;
				PointerEventData touchPointerEventData = base.GetTouchPointerEventData(touch, out pressed, out flag);
				this.ProcessTouchPress(touchPointerEventData, pressed, flag);
				if (!flag)
				{
					this.ProcessMove(touchPointerEventData);
					this.ProcessDrag(touchPointerEventData);
				}
				else
				{
					base.RemovePointerData(touchPointerEventData);
				}
			}
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0001F4AC File Offset: 0x0001D6AC
		private void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
		{
			GameObject gameObject = pointerEvent.pointerCurrentRaycast.gameObject;
			if (pressed)
			{
				if (!UIHintMask.bPassThrough)
				{
					RaycastResult? maskRay = this.MaskRay;
					if (maskRay != null && this.MaskEvent != null && gameObject != null && gameObject.name[0] != '~')
					{
						return;
					}
				}
				pointerEvent.eligibleForClick = true;
				pointerEvent.delta = Vector2.zero;
				pointerEvent.dragging = false;
				pointerEvent.useDragThreshold = true;
				pointerEvent.pressPosition = pointerEvent.position;
				pointerEvent.pointerPressRaycast = pointerEvent.pointerCurrentRaycast;
				base.DeselectIfSelectionChanged(gameObject, pointerEvent);
				if (pointerEvent.pointerEnter != gameObject)
				{
					base.HandlePointerExitAndEnter(pointerEvent, gameObject);
					pointerEvent.pointerEnter = gameObject;
				}
				GameObject gameObject2 = ExecuteEvents.ExecuteHierarchy<IPointerDownHandler>(gameObject, pointerEvent, ExecuteEvents.pointerDownHandler);
				if (gameObject2 == null)
				{
					gameObject2 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject);
				}
				float unscaledTime = Time.unscaledTime;
				if (gameObject2 == pointerEvent.lastPress)
				{
					float num = unscaledTime - pointerEvent.clickTime;
					if (num < 0.3f)
					{
						pointerEvent.clickCount++;
					}
					else
					{
						pointerEvent.clickCount = 1;
					}
					pointerEvent.clickTime = unscaledTime;
				}
				else
				{
					pointerEvent.clickCount = 1;
				}
				pointerEvent.pointerPress = gameObject2;
				pointerEvent.rawPointerPress = gameObject;
				pointerEvent.clickTime = unscaledTime;
				pointerEvent.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(gameObject);
				if (pointerEvent.pointerDrag != null)
				{
					ExecuteEvents.Execute<IInitializePotentialDragHandler>(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.initializePotentialDrag);
				}
			}
			if (released)
			{
				RaycastResult? maskRay2 = this.MaskRay;
				if (maskRay2 != null)
				{
					ExecuteEvents.Execute<IPointerClickHandler>(this.MaskEvent.pointerCurrentRaycast.gameObject, this.MaskEvent, ExecuteEvents.pointerClickHandler);
					if (!UIHintMask.bPassThrough && gameObject != null && gameObject.name[0] != '~')
					{
						pointerEvent.eligibleForClick = false;
						pointerEvent.pointerPress = null;
						pointerEvent.rawPointerPress = null;
						pointerEvent.dragging = false;
						pointerEvent.pointerDrag = null;
						pointerEvent.pointerEnter = null;
						return;
					}
				}
				ExecuteEvents.Execute<IPointerUpHandler>(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerUpHandler);
				GameObject eventHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject);
				if (pointerEvent.pointerPress == eventHandler && pointerEvent.eligibleForClick)
				{
					ExecuteEvents.Execute<IPointerClickHandler>(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerClickHandler);
				}
				else if (pointerEvent.pointerDrag != null)
				{
					ExecuteEvents.ExecuteHierarchy<IDropHandler>(gameObject, pointerEvent, ExecuteEvents.dropHandler);
				}
				pointerEvent.eligibleForClick = false;
				pointerEvent.pointerPress = null;
				pointerEvent.rawPointerPress = null;
				if (pointerEvent.pointerDrag != null && pointerEvent.dragging)
				{
					ExecuteEvents.Execute<IEndDragHandler>(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.endDragHandler);
				}
				pointerEvent.dragging = false;
				pointerEvent.pointerDrag = null;
				if (pointerEvent.pointerDrag != null)
				{
					ExecuteEvents.Execute<IEndDragHandler>(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.endDragHandler);
				}
				pointerEvent.pointerDrag = null;
				ExecuteEvents.ExecuteHierarchy<IPointerExitHandler>(pointerEvent.pointerEnter, pointerEvent, ExecuteEvents.pointerExitHandler);
				pointerEvent.pointerEnter = null;
			}
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0001F7C8 File Offset: 0x0001D9C8
		public override void DeactivateModule()
		{
			base.DeactivateModule();
			base.ClearSelection();
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0001F7D8 File Offset: 0x0001D9D8
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine((!this.UseFakeInput()) ? "Input: Touch" : "Input: Faked");
			if (this.UseFakeInput())
			{
				PointerEventData lastPointerEventData = base.GetLastPointerEventData(-1);
				if (lastPointerEventData != null)
				{
					stringBuilder.AppendLine(lastPointerEventData.ToString());
				}
			}
			else
			{
				foreach (KeyValuePair<int, PointerEventData> keyValuePair in this.m_PointerData)
				{
					stringBuilder.AppendLine(keyValuePair.ToString());
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0400043B RID: 1083
		private Vector2 m_LastMousePosition;

		// Token: 0x0400043C RID: 1084
		private Vector2 m_MousePosition;

		// Token: 0x0400043D RID: 1085
		[SerializeField]
		private bool m_AllowActivationOnStandalone;
	}
}
