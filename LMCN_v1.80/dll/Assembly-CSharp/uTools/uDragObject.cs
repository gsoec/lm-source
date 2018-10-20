using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace uTools
{
	// Token: 0x020007FD RID: 2045
	[AddComponentMenu("uTools/Internal/Drag Object(uTools)")]
	public class uDragObject : MonoBehaviour, IDragHandler, IEventSystemHandler
	{
		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06002A82 RID: 10882 RVA: 0x0046F340 File Offset: 0x0046D540
		private RectTransform cacheTarget
		{
			get
			{
				if (this.target == null)
				{
					this.target = base.GetComponent<RectTransform>();
				}
				return this.target;
			}
		}

		// Token: 0x06002A83 RID: 10883 RVA: 0x0046F368 File Offset: 0x0046D568
		private void Start()
		{
		}

		// Token: 0x06002A84 RID: 10884 RVA: 0x0046F36C File Offset: 0x0046D56C
		private void Update()
		{
		}

		// Token: 0x06002A85 RID: 10885 RVA: 0x0046F370 File Offset: 0x0046D570
		public void OnDrag(PointerEventData eventData)
		{
			Vector3 localPosition = this.cacheTarget.localPosition;
			Vector3 to = localPosition + new Vector3(eventData.delta.x, eventData.delta.y, 0f);
			uTweenPosition.Begin(base.gameObject, localPosition, to, 0.02f, 0f);
		}

		// Token: 0x04007650 RID: 30288
		public RectTransform target;
	}
}
