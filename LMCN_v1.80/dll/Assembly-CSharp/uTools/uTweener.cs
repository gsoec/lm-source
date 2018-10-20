using System;
using UnityEngine;
using UnityEngine.Events;

namespace uTools
{
	// Token: 0x02000811 RID: 2065
	public abstract class uTweener : MonoBehaviour
	{
		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06002AEC RID: 10988 RVA: 0x004702E8 File Offset: 0x0046E4E8
		// (set) Token: 0x06002AED RID: 10989 RVA: 0x004702F0 File Offset: 0x0046E4F0
		public float factor
		{
			get
			{
				return this.mFactor;
			}
			set
			{
				this.mFactor = Mathf.Clamp01(value);
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06002AEE RID: 10990 RVA: 0x00470300 File Offset: 0x0046E500
		public float amountPerDelta
		{
			get
			{
				if (this.mDuration != this.duration)
				{
					this.mDuration = this.duration;
					this.mAmountPerDelta = ((this.duration <= 0f) ? 1000f : (1f / this.duration));
				}
				return this.mAmountPerDelta;
			}
		}

		// Token: 0x06002AEF RID: 10991 RVA: 0x0047035C File Offset: 0x0046E55C
		private void Start()
		{
			this.Update();
		}

		// Token: 0x06002AF0 RID: 10992 RVA: 0x00470364 File Offset: 0x0046E564
		private void Update()
		{
			float num = (!this.ignoreTimeScale) ? Time.deltaTime : Time.unscaledDeltaTime;
			float num2 = (!this.ignoreTimeScale) ? Time.time : Time.unscaledTime;
			if (this.mStartTime < 0f)
			{
				this.mStartTime = num2 + this.delay;
			}
			if (num2 < this.mStartTime)
			{
				return;
			}
			this.mFactor += this.amountPerDelta * num;
			if (this.loopStyle == LoopStyle.Loop)
			{
				if (this.mFactor > 1f)
				{
					this.mFactor -= Mathf.Floor(this.mFactor);
				}
			}
			else if (this.loopStyle == LoopStyle.PingPong)
			{
				if (this.mFactor > 1f)
				{
					this.mFactor = 1f - (this.mFactor - Mathf.Floor(this.mFactor));
					this.mAmountPerDelta = -this.mAmountPerDelta;
				}
				else if (this.mFactor < 0f)
				{
					this.mFactor = -this.mFactor;
					this.mFactor -= Mathf.Floor(this.mFactor);
					this.mAmountPerDelta = -this.mAmountPerDelta;
				}
			}
			if (this.loopStyle == LoopStyle.Once && (this.duration == 0f || this.mFactor > 1f || this.mFactor < 0f))
			{
				this.mFactor = Mathf.Clamp01(this.mFactor);
				this.Sample(this.mFactor, true);
				base.enabled = false;
				if (this.onFinished != null)
				{
					this.onFinished.Invoke();
				}
			}
			else
			{
				this.Sample(this.mFactor, false);
			}
		}

		// Token: 0x06002AF1 RID: 10993 RVA: 0x00470538 File Offset: 0x0046E738
		public void Sample(float _factor, bool _isFinished)
		{
			float num = Mathf.Clamp01(_factor);
			num = ((this.easeType != EaseType.none) ? EaseManager.EasingFromType(0f, 1f, num, this.easeType) : this.animationCurve.Evaluate(num));
			this.OnUpdate(num, _isFinished);
		}

		// Token: 0x06002AF2 RID: 10994 RVA: 0x00470588 File Offset: 0x0046E788
		protected virtual void OnUpdate(float _factor, bool _isFinished)
		{
		}

		// Token: 0x06002AF3 RID: 10995 RVA: 0x0047058C File Offset: 0x0046E78C
		public void Reset()
		{
			base.enabled = true;
			this.easeType = EaseType.linear;
			this.loopStyle = LoopStyle.Once;
			this.delay = 0f;
			this.duration = 1f;
			this.ignoreTimeScale = true;
			this.onFinished = null;
			this.mAmountPerDelta = 1000f;
			this.mDuration = 0f;
			this.mStartTime = -1f;
			this.mFactor = 0f;
		}

		// Token: 0x06002AF4 RID: 10996 RVA: 0x00470600 File Offset: 0x0046E800
		public static T Begin<T>(GameObject _go, float _duration) where T : uTweener
		{
			T t = _go.GetComponent<T>();
			if (t == null)
			{
				t = _go.AddComponent<T>();
			}
			t.Reset();
			t.duration = _duration;
			t.enabled = true;
			return t;
		}

		// Token: 0x06002AF5 RID: 10997 RVA: 0x00470654 File Offset: 0x0046E854
		public void Play(PlayDirection dir = PlayDirection.Forward)
		{
			this.mAmountPerDelta = ((dir != PlayDirection.Reverse) ? Mathf.Abs(this.amountPerDelta) : (-Mathf.Abs(this.amountPerDelta)));
			base.enabled = true;
			this.Update();
		}

		// Token: 0x06002AF6 RID: 10998 RVA: 0x00470698 File Offset: 0x0046E898
		public void Toggle()
		{
			this.mAmountPerDelta *= -1f;
			base.enabled = true;
		}

		// Token: 0x06002AF7 RID: 10999 RVA: 0x004706B4 File Offset: 0x0046E8B4
		[ContextMenu("Set 'From' to current value")]
		public virtual void SetStartToCurrentValue()
		{
		}

		// Token: 0x06002AF8 RID: 11000 RVA: 0x004706B8 File Offset: 0x0046E8B8
		[ContextMenu("Set 'To' to current value")]
		public virtual void SetEndToCurrentValue()
		{
		}

		// Token: 0x06002AF9 RID: 11001 RVA: 0x004706BC File Offset: 0x0046E8BC
		[ContextMenu("Assume value of 'From'")]
		public virtual void SetCurrentValueToStart()
		{
		}

		// Token: 0x06002AFA RID: 11002 RVA: 0x004706C0 File Offset: 0x0046E8C0
		[ContextMenu("Assume value of 'To'")]
		public virtual void SetCurrentValueToEnd()
		{
		}

		// Token: 0x0400768C RID: 30348
		public AnimationCurve animationCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f, 0f, 1f),
			new Keyframe(1f, 1f, 1f, 0f)
		});

		// Token: 0x0400768D RID: 30349
		public EaseType easeType;

		// Token: 0x0400768E RID: 30350
		public LoopStyle loopStyle;

		// Token: 0x0400768F RID: 30351
		public float delay;

		// Token: 0x04007690 RID: 30352
		public float duration = 1f;

		// Token: 0x04007691 RID: 30353
		public bool ignoreTimeScale = true;

		// Token: 0x04007692 RID: 30354
		public UnityEvent onFinished;

		// Token: 0x04007693 RID: 30355
		private float mAmountPerDelta = 1000f;

		// Token: 0x04007694 RID: 30356
		private float mDuration;

		// Token: 0x04007695 RID: 30357
		private float mStartTime = -1f;

		// Token: 0x04007696 RID: 30358
		private float mFactor;
	}
}
