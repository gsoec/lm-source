using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace UnityEngine.EventSystems
{
	// Token: 0x02000050 RID: 80
	public abstract class CusPointerInputModule : BaseInputModule
	{
		// Token: 0x0600022D RID: 557 RVA: 0x0001DF00 File Offset: 0x0001C100
		protected bool GetPointerData(int id, out PointerEventData data, bool create)
		{
			if (!this.m_PointerData.TryGetValue(id, out data) && create)
			{
				data = new PointerEventData(base.eventSystem)
				{
					pointerId = id
				};
				this.m_PointerData.Add(id, data);
				return true;
			}
			return false;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0001DF4C File Offset: 0x0001C14C
		protected void RemovePointerData(PointerEventData data)
		{
			this.m_PointerData.Remove(data.pointerId);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0001DF60 File Offset: 0x0001C160
		protected PointerEventData GetTouchPointerEventData(Touch input, out bool pressed, out bool released)
		{
			PointerEventData pointerEventData;
			bool pointerData = this.GetPointerData(input.fingerId, out pointerEventData, true);
			pointerEventData.Reset();
			pressed = (pointerData || input.phase == TouchPhase.Began);
			released = (input.phase == TouchPhase.Canceled || input.phase == TouchPhase.Ended);
			if (pointerData)
			{
				pointerEventData.position = input.position;
			}
			if (pressed)
			{
				pointerEventData.delta = Vector2.zero;
			}
			else
			{
				pointerEventData.delta = input.position - pointerEventData.position;
			}
			pointerEventData.position = input.position;
			pointerEventData.button = PointerEventData.InputButton.Left;
			base.eventSystem.RaycastAll(pointerEventData, this.m_RaycastResultCache);
			RaycastResult pointerCurrentRaycast = this.FindFirstRaycast(this.m_RaycastResultCache, 0);
			pointerEventData.pointerCurrentRaycast = pointerCurrentRaycast;
			this.m_RaycastResultCache.Clear();
			RaycastResult? maskRay = this.MaskRay;
			if (maskRay != null && this.MaskEvent == null)
			{
				pointerData = this.GetPointerData(999, out this.MaskEvent, true);
				this.MaskEvent.Reset();
				pressed = (pointerData || input.phase == TouchPhase.Began);
				released = (input.phase == TouchPhase.Canceled || input.phase == TouchPhase.Ended);
				if (pointerData)
				{
					this.MaskEvent.position = input.position;
				}
				if (pressed)
				{
					this.MaskEvent.delta = Vector2.zero;
				}
				else
				{
					this.MaskEvent.delta = input.position - this.MaskEvent.position;
				}
				this.MaskEvent.position = input.position;
				this.MaskEvent.button = PointerEventData.InputButton.Left;
				this.MaskEvent.pointerCurrentRaycast = this.MaskRay.Value;
			}
			return pointerEventData;
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0001E138 File Offset: 0x0001C338
		private void CopyFromTo(PointerEventData from, PointerEventData to)
		{
			to.position = from.position;
			to.delta = from.delta;
			to.scrollDelta = from.scrollDelta;
			to.pointerCurrentRaycast = from.pointerCurrentRaycast;
			to.pointerEnter = from.pointerEnter;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0001E184 File Offset: 0x0001C384
		protected static PointerEventData.FramePressState StateForMouseButton(int buttonId)
		{
			bool mouseButtonDown = Input.GetMouseButtonDown(buttonId);
			bool mouseButtonUp = Input.GetMouseButtonUp(buttonId);
			if (mouseButtonDown && mouseButtonUp)
			{
				return PointerEventData.FramePressState.PressedAndReleased;
			}
			if (mouseButtonDown)
			{
				return PointerEventData.FramePressState.Pressed;
			}
			if (mouseButtonUp)
			{
				return PointerEventData.FramePressState.Released;
			}
			return PointerEventData.FramePressState.NotChanged;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0001E1C0 File Offset: 0x0001C3C0
		protected virtual CusPointerInputModule.MouseState GetMousePointerEventData()
		{
			PointerEventData pointerEventData;
			bool pointerData = this.GetPointerData(-1, out pointerEventData, true);
			pointerEventData.Reset();
			if (pointerData)
			{
				pointerEventData.position = Input.mousePosition;
			}
			Vector2 vector = Input.mousePosition;
			pointerEventData.delta = vector - pointerEventData.position;
			pointerEventData.position = vector;
			pointerEventData.scrollDelta = Input.mouseScrollDelta;
			pointerEventData.button = PointerEventData.InputButton.Left;
			base.eventSystem.RaycastAll(pointerEventData, this.m_RaycastResultCache);
			RaycastResult pointerCurrentRaycast = this.FindFirstRaycast(this.m_RaycastResultCache, 0);
			pointerEventData.pointerCurrentRaycast = pointerCurrentRaycast;
			this.m_RaycastResultCache.Clear();
			PointerEventData pointerEventData2;
			this.GetPointerData(-2, out pointerEventData2, true);
			this.CopyFromTo(pointerEventData, pointerEventData2);
			pointerEventData2.button = PointerEventData.InputButton.Right;
			PointerEventData pointerEventData3;
			this.GetPointerData(-3, out pointerEventData3, true);
			this.CopyFromTo(pointerEventData, pointerEventData3);
			pointerEventData3.button = PointerEventData.InputButton.Middle;
			this.m_MouseState.SetButtonState(PointerEventData.InputButton.Left, CusPointerInputModule.StateForMouseButton(0), pointerEventData);
			this.m_MouseState.SetButtonState(PointerEventData.InputButton.Right, CusPointerInputModule.StateForMouseButton(1), pointerEventData2);
			this.m_MouseState.SetButtonState(PointerEventData.InputButton.Middle, CusPointerInputModule.StateForMouseButton(2), pointerEventData3);
			RaycastResult? maskRay = this.MaskRay;
			if (maskRay != null)
			{
				pointerData = this.GetPointerData(999, out pointerEventData, true);
				if (pointerData)
				{
					pointerEventData.pointerCurrentRaycast = this.MaskRay.Value;
				}
				this.GetPointerData(-2, out pointerEventData2, true);
				this.CopyFromTo(pointerEventData, pointerEventData2);
				pointerEventData2.button = PointerEventData.InputButton.Right;
				this.GetPointerData(-3, out pointerEventData3, true);
				this.CopyFromTo(pointerEventData, pointerEventData3);
				pointerEventData3.button = PointerEventData.InputButton.Middle;
				this.m_MaskMouseState.SetButtonState(PointerEventData.InputButton.Left, CusPointerInputModule.StateForMouseButton(0), pointerEventData);
				this.m_MaskMouseState.SetButtonState(PointerEventData.InputButton.Right, CusPointerInputModule.StateForMouseButton(1), pointerEventData2);
				this.m_MaskMouseState.SetButtonState(PointerEventData.InputButton.Middle, CusPointerInputModule.StateForMouseButton(2), pointerEventData3);
			}
			return this.m_MouseState;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0001E38C File Offset: 0x0001C58C
		protected unsafe RaycastResult FindFirstRaycast(List<RaycastResult> candidates, int id)
		{
			for (int i = 0; i < candidates.Count; i++)
			{
				if (!(candidates[i].gameObject == null))
				{
					fixed (string text = candidates[i].gameObject.name)
					{
						fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
						{
							if (*ptr == '*')
							{
								this.MaskRay = new RaycastResult?(candidates[i]);
							}
							else
							{
								text = null;
								if (id == 0)
								{
									return candidates[i];
								}
								id--;
							}
						}
					}
				}
			}
			return default(RaycastResult);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0001E430 File Offset: 0x0001C630
		protected PointerEventData GetLastPointerEventData(int id)
		{
			PointerEventData result;
			this.GetPointerData(id, out result, false);
			return result;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0001E44C File Offset: 0x0001C64C
		private static bool ShouldStartDrag(Vector2 pressPos, Vector2 currentPos, float threshold, bool useDragThreshold)
		{
			return !useDragThreshold || (pressPos - currentPos).sqrMagnitude >= threshold * threshold;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0001E478 File Offset: 0x0001C678
		protected virtual void ProcessMove(PointerEventData pointerEvent)
		{
			GameObject gameObject = pointerEvent.pointerCurrentRaycast.gameObject;
			base.HandlePointerExitAndEnter(pointerEvent, gameObject);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0001E49C File Offset: 0x0001C69C
		protected virtual void ProcessDrag(PointerEventData pointerEvent)
		{
			bool flag = pointerEvent.IsPointerMoving();
			if (flag && pointerEvent.pointerDrag != null && !pointerEvent.dragging && CusPointerInputModule.ShouldStartDrag(pointerEvent.pressPosition, pointerEvent.position, (float)base.eventSystem.pixelDragThreshold, pointerEvent.useDragThreshold))
			{
				ExecuteEvents.Execute<IBeginDragHandler>(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.beginDragHandler);
				pointerEvent.dragging = true;
			}
			if (pointerEvent.dragging && flag && pointerEvent.pointerDrag != null)
			{
				if (pointerEvent.pointerPress != pointerEvent.pointerDrag)
				{
					ExecuteEvents.Execute<IPointerUpHandler>(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerUpHandler);
					pointerEvent.eligibleForClick = false;
					pointerEvent.pointerPress = null;
					pointerEvent.rawPointerPress = null;
				}
				ExecuteEvents.Execute<IDragHandler>(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.dragHandler);
			}
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0001E584 File Offset: 0x0001C784
		public override bool IsPointerOverGameObject(int pointerId)
		{
			PointerEventData lastPointerEventData = this.GetLastPointerEventData(pointerId);
			return lastPointerEventData != null && lastPointerEventData.pointerEnter != null;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0001E5B0 File Offset: 0x0001C7B0
		protected void ClearSelection()
		{
			BaseEventData baseEventData = this.GetBaseEventData();
			foreach (PointerEventData currentPointerData in this.m_PointerData.Values)
			{
				base.HandlePointerExitAndEnter(currentPointerData, null);
			}
			this.m_PointerData.Clear();
			base.eventSystem.SetSelectedGameObject(null, baseEventData);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0001E63C File Offset: 0x0001C83C
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder("<b>Pointer Input Module of type: </b>" + base.GetType());
			stringBuilder.AppendLine();
			foreach (KeyValuePair<int, PointerEventData> keyValuePair in this.m_PointerData)
			{
				if (keyValuePair.Value != null)
				{
					stringBuilder.AppendLine("<B>Pointer:</b> " + keyValuePair.Key);
					stringBuilder.AppendLine(keyValuePair.Value.ToString());
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0001E700 File Offset: 0x0001C900
		protected void DeselectIfSelectionChanged(GameObject currentOverGo, BaseEventData pointerEvent)
		{
			GameObject eventHandler = ExecuteEvents.GetEventHandler<ISelectHandler>(currentOverGo);
			if (eventHandler != base.eventSystem.currentSelectedGameObject)
			{
				base.eventSystem.SetSelectedGameObject(null, pointerEvent);
			}
		}

		// Token: 0x04000421 RID: 1057
		public const int kMouseLeftId = -1;

		// Token: 0x04000422 RID: 1058
		public const int kMouseRightId = -2;

		// Token: 0x04000423 RID: 1059
		public const int kMouseMiddleId = -3;

		// Token: 0x04000424 RID: 1060
		public const int kFakeTouchesId = -4;

		// Token: 0x04000425 RID: 1061
		protected Dictionary<int, PointerEventData> m_PointerData = new Dictionary<int, PointerEventData>();

		// Token: 0x04000426 RID: 1062
		protected RaycastResult? MaskRay;

		// Token: 0x04000427 RID: 1063
		protected PointerEventData MaskEvent;

		// Token: 0x04000428 RID: 1064
		private readonly CusPointerInputModule.MouseState m_MouseState = new CusPointerInputModule.MouseState();

		// Token: 0x04000429 RID: 1065
		protected readonly CusPointerInputModule.MouseState m_MaskMouseState = new CusPointerInputModule.MouseState();

		// Token: 0x02000051 RID: 81
		protected class ButtonState
		{
			// Token: 0x1700001B RID: 27
			// (get) Token: 0x0600023D RID: 573 RVA: 0x0001E740 File Offset: 0x0001C940
			// (set) Token: 0x0600023E RID: 574 RVA: 0x0001E748 File Offset: 0x0001C948
			public CusPointerInputModule.MouseButtonEventData eventData
			{
				get
				{
					return this.m_EventData;
				}
				set
				{
					this.m_EventData = value;
				}
			}

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x0600023F RID: 575 RVA: 0x0001E754 File Offset: 0x0001C954
			// (set) Token: 0x06000240 RID: 576 RVA: 0x0001E75C File Offset: 0x0001C95C
			public PointerEventData.InputButton button
			{
				get
				{
					return this.m_Button;
				}
				set
				{
					this.m_Button = value;
				}
			}

			// Token: 0x0400042A RID: 1066
			private PointerEventData.InputButton m_Button;

			// Token: 0x0400042B RID: 1067
			private CusPointerInputModule.MouseButtonEventData m_EventData;
		}

		// Token: 0x02000052 RID: 82
		protected class MouseState
		{
			// Token: 0x06000242 RID: 578 RVA: 0x0001E77C File Offset: 0x0001C97C
			public bool AnyPressesThisFrame()
			{
				for (int i = 0; i < this.m_TrackedButtons.Count; i++)
				{
					if (this.m_TrackedButtons[i].eventData.PressedThisFrame())
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x06000243 RID: 579 RVA: 0x0001E7C4 File Offset: 0x0001C9C4
			public bool AnyReleasesThisFrame()
			{
				for (int i = 0; i < this.m_TrackedButtons.Count; i++)
				{
					if (this.m_TrackedButtons[i].eventData.ReleasedThisFrame())
					{
						return true;
					}
				}
				return false;
			}

			// Token: 0x06000244 RID: 580 RVA: 0x0001E80C File Offset: 0x0001CA0C
			public CusPointerInputModule.ButtonState GetButtonState(PointerEventData.InputButton button, int id = 0)
			{
				CusPointerInputModule.ButtonState buttonState = null;
				for (int i = 0; i < this.m_TrackedButtons.Count; i++)
				{
					if (this.m_TrackedButtons[i].button == button)
					{
						if (id == 0)
						{
							buttonState = this.m_TrackedButtons[i];
						}
						else
						{
							id--;
						}
						break;
					}
				}
				if (buttonState == null)
				{
					buttonState = new CusPointerInputModule.ButtonState
					{
						button = button,
						eventData = new CusPointerInputModule.MouseButtonEventData()
					};
					this.m_TrackedButtons.Add(buttonState);
				}
				return buttonState;
			}

			// Token: 0x06000245 RID: 581 RVA: 0x0001E8A0 File Offset: 0x0001CAA0
			public void SetButtonState(PointerEventData.InputButton button, PointerEventData.FramePressState stateForMouseButton, PointerEventData data)
			{
				CusPointerInputModule.ButtonState buttonState = this.GetButtonState(button, 0);
				buttonState.eventData.buttonState = stateForMouseButton;
				buttonState.eventData.buttonData = data;
			}

			// Token: 0x0400042C RID: 1068
			private List<CusPointerInputModule.ButtonState> m_TrackedButtons = new List<CusPointerInputModule.ButtonState>();
		}

		// Token: 0x02000053 RID: 83
		public class MouseButtonEventData
		{
			// Token: 0x06000247 RID: 583 RVA: 0x0001E8D8 File Offset: 0x0001CAD8
			public bool PressedThisFrame()
			{
				return this.buttonState == PointerEventData.FramePressState.Pressed || this.buttonState == PointerEventData.FramePressState.PressedAndReleased;
			}

			// Token: 0x06000248 RID: 584 RVA: 0x0001E8F4 File Offset: 0x0001CAF4
			public bool ReleasedThisFrame()
			{
				return this.buttonState == PointerEventData.FramePressState.Released || this.buttonState == PointerEventData.FramePressState.PressedAndReleased;
			}

			// Token: 0x0400042D RID: 1069
			public PointerEventData.FramePressState buttonState;

			// Token: 0x0400042E RID: 1070
			public PointerEventData buttonData;
		}
	}
}
