using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace uTools
{
	// Token: 0x02000800 RID: 2048
	[AddComponentMenu("uTools/Internal/Play Tween(uTools)")]
	public class uPlayTween : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler, IPointerExitHandler, IEventSystemHandler, IPointerEnterHandler, uIPointHandler
	{
		// Token: 0x06002A87 RID: 10887 RVA: 0x0046F3E8 File Offset: 0x0046D5E8
		private void Start()
		{
			if (this.tweenTarget == null)
			{
				this.tweenTarget = base.GetComponent<uTweener>();
			}
		}

		// Token: 0x06002A88 RID: 10888 RVA: 0x0046F408 File Offset: 0x0046D608
		public void OnPointerEnter(PointerEventData eventData)
		{
			this.TriggerPlay(Trigger.OnPointerEnter);
		}

		// Token: 0x06002A89 RID: 10889 RVA: 0x0046F414 File Offset: 0x0046D614
		public void OnPointerDown(PointerEventData eventData)
		{
			this.TriggerPlay(Trigger.OnPointerDown);
		}

		// Token: 0x06002A8A RID: 10890 RVA: 0x0046F420 File Offset: 0x0046D620
		public void OnPointerClick(PointerEventData eventData)
		{
			this.TriggerPlay(Trigger.OnPointerClick);
		}

		// Token: 0x06002A8B RID: 10891 RVA: 0x0046F42C File Offset: 0x0046D62C
		public void OnPointerUp(PointerEventData eventData)
		{
			this.TriggerPlay(Trigger.OnPointerUp);
		}

		// Token: 0x06002A8C RID: 10892 RVA: 0x0046F438 File Offset: 0x0046D638
		public void OnPointerExit(PointerEventData eventData)
		{
			this.TriggerPlay(Trigger.OnPointerExit);
		}

		// Token: 0x06002A8D RID: 10893 RVA: 0x0046F444 File Offset: 0x0046D644
		private void TriggerPlay(Trigger _trigger)
		{
			if (_trigger == this.trigger)
			{
				this.Play();
			}
		}

		// Token: 0x06002A8E RID: 10894 RVA: 0x0046F458 File Offset: 0x0046D658
		private void Play()
		{
			if (this.playDirection == PlayDirection.Toggle)
			{
				this.tweenTarget.Toggle();
			}
			else
			{
				this.tweenTarget.Play(this.playDirection);
			}
		}

		// Token: 0x0400765B RID: 30299
		public uTweener tweenTarget;

		// Token: 0x0400765C RID: 30300
		public PlayDirection playDirection = PlayDirection.Forward;

		// Token: 0x0400765D RID: 30301
		public Trigger trigger = Trigger.OnPointerClick;
	}
}
