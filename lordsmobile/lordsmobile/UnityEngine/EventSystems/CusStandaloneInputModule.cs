using System;

namespace UnityEngine.EventSystems
{
	// Token: 0x02000054 RID: 84
	[AddComponentMenu("Event/Standalone Input Module")]
	public class CusStandaloneInputModule : CusPointerInputModule
	{
		// Token: 0x06000249 RID: 585 RVA: 0x0001E910 File Offset: 0x0001CB10
		protected CusStandaloneInputModule()
		{
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600024A RID: 586 RVA: 0x0001E950 File Offset: 0x0001CB50
		[Obsolete("Mode is no longer needed on input module as it handles both mouse and keyboard simultaneously.", false)]
		public CusStandaloneInputModule.InputMode inputMode
		{
			get
			{
				return CusStandaloneInputModule.InputMode.Mouse;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600024B RID: 587 RVA: 0x0001E954 File Offset: 0x0001CB54
		// (set) Token: 0x0600024C RID: 588 RVA: 0x0001E95C File Offset: 0x0001CB5C
		public bool allowActivationOnMobileDevice
		{
			get
			{
				return this.m_AllowActivationOnMobileDevice;
			}
			set
			{
				this.m_AllowActivationOnMobileDevice = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600024D RID: 589 RVA: 0x0001E968 File Offset: 0x0001CB68
		// (set) Token: 0x0600024E RID: 590 RVA: 0x0001E970 File Offset: 0x0001CB70
		public float inputActionsPerSecond
		{
			get
			{
				return this.m_InputActionsPerSecond;
			}
			set
			{
				this.m_InputActionsPerSecond = value;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600024F RID: 591 RVA: 0x0001E97C File Offset: 0x0001CB7C
		// (set) Token: 0x06000250 RID: 592 RVA: 0x0001E984 File Offset: 0x0001CB84
		public string horizontalAxis
		{
			get
			{
				return this.m_HorizontalAxis;
			}
			set
			{
				this.m_HorizontalAxis = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000251 RID: 593 RVA: 0x0001E990 File Offset: 0x0001CB90
		// (set) Token: 0x06000252 RID: 594 RVA: 0x0001E998 File Offset: 0x0001CB98
		public string verticalAxis
		{
			get
			{
				return this.m_VerticalAxis;
			}
			set
			{
				this.m_VerticalAxis = value;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000253 RID: 595 RVA: 0x0001E9A4 File Offset: 0x0001CBA4
		// (set) Token: 0x06000254 RID: 596 RVA: 0x0001E9AC File Offset: 0x0001CBAC
		public string submitButton
		{
			get
			{
				return this.m_SubmitButton;
			}
			set
			{
				this.m_SubmitButton = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000255 RID: 597 RVA: 0x0001E9B8 File Offset: 0x0001CBB8
		// (set) Token: 0x06000256 RID: 598 RVA: 0x0001E9C0 File Offset: 0x0001CBC0
		public string cancelButton
		{
			get
			{
				return this.m_CancelButton;
			}
			set
			{
				this.m_CancelButton = value;
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0001E9CC File Offset: 0x0001CBCC
		public override void UpdateModule()
		{
			this.m_LastMousePosition = this.m_MousePosition;
			this.m_MousePosition = Input.mousePosition;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0001E9EC File Offset: 0x0001CBEC
		public override bool IsModuleSupported()
		{
			return this.m_AllowActivationOnMobileDevice || Input.mousePresent;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0001EA04 File Offset: 0x0001CC04
		public override bool ShouldActivateModule()
		{
			if (!base.ShouldActivateModule())
			{
				return false;
			}
			bool flag = Input.GetButtonDown(this.m_SubmitButton);
			flag |= Input.GetButtonDown(this.m_CancelButton);
			flag |= !Mathf.Approximately(Input.GetAxisRaw(this.m_HorizontalAxis), 0f);
			flag |= !Mathf.Approximately(Input.GetAxisRaw(this.m_VerticalAxis), 0f);
			flag |= ((this.m_MousePosition - this.m_LastMousePosition).sqrMagnitude > 0f);
			return flag | Input.GetMouseButtonDown(0);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0001EA9C File Offset: 0x0001CC9C
		public override void ActivateModule()
		{
			base.ActivateModule();
			this.m_MousePosition = Input.mousePosition;
			this.m_LastMousePosition = Input.mousePosition;
			GameObject gameObject = base.eventSystem.currentSelectedGameObject;
			if (gameObject == null)
			{
				gameObject = base.eventSystem.lastSelectedGameObject;
			}
			if (gameObject == null)
			{
				gameObject = base.eventSystem.firstSelectedGameObject;
			}
			base.eventSystem.SetSelectedGameObject(gameObject, this.GetBaseEventData());
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0001EB20 File Offset: 0x0001CD20
		public override void DeactivateModule()
		{
			base.DeactivateModule();
			base.ClearSelection();
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0001EB30 File Offset: 0x0001CD30
		public override void Process()
		{
			bool flag = this.SendUpdateEventToSelectedObject();
			this.MaskRay = null;
			if (base.eventSystem.sendNavigationEvents)
			{
				if (!flag)
				{
					flag |= this.SendMoveEventToSelectedObject();
				}
				if (!flag)
				{
					this.SendSubmitEventToSelectedObject();
				}
			}
			this.ProcessMouseEvent();
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0001EB88 File Offset: 0x0001CD88
		private bool SendSubmitEventToSelectedObject()
		{
			if (base.eventSystem.currentSelectedGameObject == null)
			{
				return false;
			}
			BaseEventData baseEventData = this.GetBaseEventData();
			if (Input.GetButtonDown(this.m_SubmitButton))
			{
				ExecuteEvents.Execute<ISubmitHandler>(base.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.submitHandler);
			}
			if (Input.GetButtonDown(this.m_CancelButton))
			{
				ExecuteEvents.Execute<ICancelHandler>(base.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.cancelHandler);
			}
			return baseEventData.used;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0001EC08 File Offset: 0x0001CE08
		private bool AllowMoveEventProcessing(float time)
		{
			bool flag = Input.GetButtonDown(this.m_HorizontalAxis);
			flag |= Input.GetButtonDown(this.m_VerticalAxis);
			return flag | time > this.m_NextAction;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0001EC3C File Offset: 0x0001CE3C
		private Vector2 GetRawMoveVector()
		{
			Vector2 zero = Vector2.zero;
			zero.x = Input.GetAxisRaw(this.m_HorizontalAxis);
			zero.y = Input.GetAxisRaw(this.m_VerticalAxis);
			if (Input.GetButtonDown(this.m_HorizontalAxis))
			{
				if (zero.x < 0f)
				{
					zero.x = -1f;
				}
				if (zero.x > 0f)
				{
					zero.x = 1f;
				}
			}
			if (Input.GetButtonDown(this.m_VerticalAxis))
			{
				if (zero.y < 0f)
				{
					zero.y = -1f;
				}
				if (zero.y > 0f)
				{
					zero.y = 1f;
				}
			}
			return zero;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0001ED08 File Offset: 0x0001CF08
		private bool SendMoveEventToSelectedObject()
		{
			float unscaledTime = Time.unscaledTime;
			if (!this.AllowMoveEventProcessing(unscaledTime))
			{
				return false;
			}
			Vector2 rawMoveVector = this.GetRawMoveVector();
			AxisEventData axisEventData = this.GetAxisEventData(rawMoveVector.x, rawMoveVector.y, 0.6f);
			if (!Mathf.Approximately(axisEventData.moveVector.x, 0f) || !Mathf.Approximately(axisEventData.moveVector.y, 0f))
			{
				ExecuteEvents.Execute<IMoveHandler>(base.eventSystem.currentSelectedGameObject, axisEventData, ExecuteEvents.moveHandler);
			}
			this.m_NextAction = unscaledTime + 1f / this.m_InputActionsPerSecond;
			return axisEventData.used;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0001EDB8 File Offset: 0x0001CFB8
		private void ProcessMouseEvent()
		{
			CusPointerInputModule.MouseState mousePointerEventData = this.GetMousePointerEventData();
			bool pressed = mousePointerEventData.AnyPressesThisFrame();
			bool released = mousePointerEventData.AnyReleasesThisFrame();
			CusPointerInputModule.MouseButtonEventData eventData = mousePointerEventData.GetButtonState(PointerEventData.InputButton.Left, 0).eventData;
			if (!CusStandaloneInputModule.UseMouse(pressed, released, eventData.buttonData))
			{
				return;
			}
			this.ProcessMousePress(eventData);
			this.ProcessMove(eventData.buttonData);
			this.ProcessDrag(eventData.buttonData);
			this.ProcessMousePress(mousePointerEventData.GetButtonState(PointerEventData.InputButton.Right, 0).eventData);
			this.ProcessDrag(mousePointerEventData.GetButtonState(PointerEventData.InputButton.Right, 0).eventData.buttonData);
			this.ProcessMousePress(mousePointerEventData.GetButtonState(PointerEventData.InputButton.Middle, 0).eventData);
			this.ProcessDrag(mousePointerEventData.GetButtonState(PointerEventData.InputButton.Middle, 0).eventData.buttonData);
			if (!Mathf.Approximately(eventData.buttonData.scrollDelta.sqrMagnitude, 0f))
			{
				GameObject eventHandler = ExecuteEvents.GetEventHandler<IScrollHandler>(eventData.buttonData.pointerCurrentRaycast.gameObject);
				ExecuteEvents.ExecuteHierarchy<IScrollHandler>(eventHandler, eventData.buttonData, ExecuteEvents.scrollHandler);
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0001EEC4 File Offset: 0x0001D0C4
		private static bool UseMouse(bool pressed, bool released, PointerEventData pointerData)
		{
			return pressed || released || pointerData.IsPointerMoving() || pointerData.IsScrolling();
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0001EEEC File Offset: 0x0001D0EC
		private bool SendUpdateEventToSelectedObject()
		{
			if (base.eventSystem.currentSelectedGameObject == null)
			{
				return false;
			}
			BaseEventData baseEventData = this.GetBaseEventData();
			ExecuteEvents.Execute<IUpdateSelectedHandler>(base.eventSystem.currentSelectedGameObject, baseEventData, ExecuteEvents.updateSelectedHandler);
			return baseEventData.used;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0001EF38 File Offset: 0x0001D138
		private void ProcessMousePress(CusPointerInputModule.MouseButtonEventData data)
		{
			PointerEventData buttonData = data.buttonData;
			GameObject gameObject = buttonData.pointerCurrentRaycast.gameObject;
			if (data.PressedThisFrame())
			{
				if (!UIHintMask.bPassThrough)
				{
					RaycastResult? maskRay = this.MaskRay;
					if (maskRay != null && gameObject != null && gameObject.name[0] != '~')
					{
						CusPointerInputModule.MouseButtonEventData eventData = this.m_MaskMouseState.GetButtonState(PointerEventData.InputButton.Left, 0).eventData;
						PointerEventData buttonData2 = eventData.buttonData;
						if (buttonData2.pointerCurrentRaycast.gameObject.activeInHierarchy)
						{
							return;
						}
					}
				}
				buttonData.eligibleForClick = true;
				buttonData.delta = Vector2.zero;
				buttonData.dragging = false;
				buttonData.useDragThreshold = true;
				buttonData.pressPosition = buttonData.position;
				buttonData.pointerPressRaycast = buttonData.pointerCurrentRaycast;
				base.DeselectIfSelectionChanged(gameObject, buttonData);
				GameObject gameObject2 = ExecuteEvents.ExecuteHierarchy<IPointerDownHandler>(gameObject, buttonData, ExecuteEvents.pointerDownHandler);
				if (gameObject2 == null)
				{
					gameObject2 = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject);
				}
				float unscaledTime = Time.unscaledTime;
				if (gameObject2 == buttonData.lastPress)
				{
					float num = unscaledTime - buttonData.clickTime;
					if (num < 0.3f)
					{
						buttonData.clickCount++;
					}
					else
					{
						buttonData.clickCount = 1;
					}
					buttonData.clickTime = unscaledTime;
				}
				else
				{
					buttonData.clickCount = 1;
				}
				buttonData.pointerPress = gameObject2;
				buttonData.rawPointerPress = gameObject;
				buttonData.clickTime = unscaledTime;
				buttonData.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(gameObject);
				if (buttonData.pointerDrag != null)
				{
					ExecuteEvents.Execute<IInitializePotentialDragHandler>(buttonData.pointerDrag, buttonData, ExecuteEvents.initializePotentialDrag);
				}
			}
			if (data.ReleasedThisFrame())
			{
				RaycastResult? maskRay2 = this.MaskRay;
				if (maskRay2 != null)
				{
					CusPointerInputModule.MouseButtonEventData eventData2 = this.m_MaskMouseState.GetButtonState(PointerEventData.InputButton.Left, 0).eventData;
					PointerEventData buttonData3 = eventData2.buttonData;
					if (buttonData3.pointerCurrentRaycast.gameObject.activeInHierarchy)
					{
						ExecuteEvents.Execute<IPointerClickHandler>(buttonData3.pointerCurrentRaycast.gameObject, buttonData3, ExecuteEvents.pointerClickHandler);
						if (!UIHintMask.bPassThrough && gameObject != null && gameObject.name[0] != '~')
						{
							buttonData.eligibleForClick = false;
							buttonData.pointerPress = null;
							buttonData.rawPointerPress = null;
							buttonData.dragging = false;
							buttonData.pointerDrag = null;
							if (gameObject != buttonData.pointerEnter)
							{
								base.HandlePointerExitAndEnter(buttonData, null);
								base.HandlePointerExitAndEnter(buttonData, gameObject);
							}
							return;
						}
					}
				}
				ExecuteEvents.Execute<IPointerUpHandler>(buttonData.pointerPress, buttonData, ExecuteEvents.pointerUpHandler);
				GameObject eventHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(gameObject);
				if (buttonData.pointerPress == eventHandler && buttonData.eligibleForClick)
				{
					ExecuteEvents.Execute<IPointerClickHandler>(buttonData.pointerPress, buttonData, ExecuteEvents.pointerClickHandler);
				}
				else if (buttonData.pointerDrag != null)
				{
					ExecuteEvents.ExecuteHierarchy<IDropHandler>(gameObject, buttonData, ExecuteEvents.dropHandler);
				}
				buttonData.eligibleForClick = false;
				buttonData.pointerPress = null;
				buttonData.rawPointerPress = null;
				if (buttonData.pointerDrag != null && buttonData.dragging)
				{
					ExecuteEvents.Execute<IEndDragHandler>(buttonData.pointerDrag, buttonData, ExecuteEvents.endDragHandler);
				}
				buttonData.dragging = false;
				buttonData.pointerDrag = null;
				if (gameObject != buttonData.pointerEnter)
				{
					base.HandlePointerExitAndEnter(buttonData, null);
					base.HandlePointerExitAndEnter(buttonData, gameObject);
				}
			}
		}

		// Token: 0x0400042F RID: 1071
		private float m_NextAction;

		// Token: 0x04000430 RID: 1072
		private Vector2 m_LastMousePosition;

		// Token: 0x04000431 RID: 1073
		private Vector2 m_MousePosition;

		// Token: 0x04000432 RID: 1074
		[SerializeField]
		private string m_HorizontalAxis = "Horizontal";

		// Token: 0x04000433 RID: 1075
		[SerializeField]
		private string m_VerticalAxis = "Vertical";

		// Token: 0x04000434 RID: 1076
		[SerializeField]
		private string m_SubmitButton = "Submit";

		// Token: 0x04000435 RID: 1077
		[SerializeField]
		private string m_CancelButton = "Cancel";

		// Token: 0x04000436 RID: 1078
		[SerializeField]
		private float m_InputActionsPerSecond = 10f;

		// Token: 0x04000437 RID: 1079
		[SerializeField]
		private bool m_AllowActivationOnMobileDevice;

		// Token: 0x02000055 RID: 85
		[Obsolete("Mode is no longer needed on input module as it handles both mouse and keyboard simultaneously.", false)]
		public enum InputMode
		{
			// Token: 0x04000439 RID: 1081
			Mouse,
			// Token: 0x0400043A RID: 1082
			Buttons
		}
	}
}
