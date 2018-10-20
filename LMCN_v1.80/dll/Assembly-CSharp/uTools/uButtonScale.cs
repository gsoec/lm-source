using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace uTools
{
	// Token: 0x02000802 RID: 2050
	[AddComponentMenu("uTools/Tween/Button Scale(uTools)")]
	public class uButtonScale : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler, IPointerExitHandler, IEventSystemHandler, IPointerEnterHandler, uIPointHandler, IUIButtonScaleHandler
	{
		// Token: 0x06002A92 RID: 10898 RVA: 0x0046F4C8 File Offset: 0x0046D6C8
		private void Start()
		{
			if (this.tweenTarget == null)
			{
				this.tweenTarget = base.GetComponent<RectTransform>();
			}
			this.CheckTargetScale();
		}

		// Token: 0x06002A93 RID: 10899 RVA: 0x0046F4F0 File Offset: 0x0046D6F0
		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		// Token: 0x06002A94 RID: 10900 RVA: 0x0046F4F4 File Offset: 0x0046D6F4
		public void OnPointerExit(PointerEventData eventData)
		{
			if (this.bPress == 1)
			{
				this.Scale(this.mScale, 0f);
				this.ClearPara();
			}
		}

		// Token: 0x06002A95 RID: 10901 RVA: 0x0046F51C File Offset: 0x0046D71C
		public void OnPointerDown(PointerEventData eventData)
		{
			if (uButtonScale.bLock && this.bPress != 0)
			{
				return;
			}
			this.Scale(this.down, 0f);
			this.bPress = 1;
			uButtonScale.bLock = true;
		}

		// Token: 0x06002A96 RID: 10902 RVA: 0x0046F560 File Offset: 0x0046D760
		public void OnPointerUp(PointerEventData eventData)
		{
		}

		// Token: 0x06002A97 RID: 10903 RVA: 0x0046F564 File Offset: 0x0046D764
		public void OnPointerClick(PointerEventData eventData)
		{
			if (uButtonScale.bLock && this.bPress == 0)
			{
				return;
			}
			if (this.bPress == 1)
			{
				this.Scale(this.mScale, 0.05f);
				this.bPress = 2;
			}
		}

		// Token: 0x06002A98 RID: 10904 RVA: 0x0046F5AC File Offset: 0x0046D7AC
		public void CheckTargetScale()
		{
			if (this.tweenTarget == null)
			{
				return;
			}
			this.mScale = this.tweenTarget.localScale;
			if (this.mScale.x < 0f)
			{
				this.down.x = -this.down.x;
			}
		}

		// Token: 0x06002A99 RID: 10905 RVA: 0x0046F608 File Offset: 0x0046D808
		public void Reset()
		{
			if (this.bPress == 1)
			{
				this.Scale(this.mScale, 0f);
			}
			this.ClearPara();
		}

		// Token: 0x06002A9A RID: 10906 RVA: 0x0046F630 File Offset: 0x0046D830
		private void Scale(Vector3 to, float spduration = 0f)
		{
			uTweenScaleButton uTweenScaleButton = uTweenScaleButton.Begin(this.tweenTarget.gameObject, this.tweenTarget.localScale, to, (spduration != 0f) ? spduration : this.duration, 0f);
			uTweenScaleButton.m_Handler = this;
		}

		// Token: 0x06002A9B RID: 10907 RVA: 0x0046F680 File Offset: 0x0046D880
		public void OnFinish()
		{
			if (this.bPress == 2)
			{
				this.ClearPara();
				if (this.m_Handler != null)
				{
					this.m_Handler.OnFinish();
				}
			}
		}

		// Token: 0x06002A9C RID: 10908 RVA: 0x0046F6B8 File Offset: 0x0046D8B8
		public void ClearPara()
		{
			this.bPress = 0;
			uButtonScale.bLock = false;
		}

		// Token: 0x0400765E RID: 30302
		public IUIButtonScaleHandler2 m_Handler;

		// Token: 0x0400765F RID: 30303
		public RectTransform tweenTarget;

		// Token: 0x04007660 RID: 30304
		public Vector3 down = new Vector3(1.2f, 1.2f, 1.2f);

		// Token: 0x04007661 RID: 30305
		public float duration = 0.015f;

		// Token: 0x04007662 RID: 30306
		private Vector3 mScale;

		// Token: 0x04007663 RID: 30307
		private byte bPress;

		// Token: 0x04007664 RID: 30308
		private static bool bLock;
	}
}
