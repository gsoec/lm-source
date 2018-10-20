using System;
using UnityEngine;
using UnityEngine.Events;

namespace uTools
{
	// Token: 0x02000812 RID: 2066
	public abstract class uTweenerEX : MonoBehaviour
	{
		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06002AFC RID: 11004 RVA: 0x004707BC File Offset: 0x0046E9BC
		// (set) Token: 0x06002AFD RID: 11005 RVA: 0x004707C4 File Offset: 0x0046E9C4
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

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06002AFE RID: 11006 RVA: 0x004707D4 File Offset: 0x0046E9D4
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

		// Token: 0x06002AFF RID: 11007 RVA: 0x00470830 File Offset: 0x0046EA30
		private void Start()
		{
			this.Update();
		}

		// Token: 0x06002B00 RID: 11008 RVA: 0x00470838 File Offset: 0x0046EA38
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

		// Token: 0x06002B01 RID: 11009 RVA: 0x00470A0C File Offset: 0x0046EC0C
		public void Sample(float _factor, bool _isFinished)
		{
			float num = Mathf.Clamp01(_factor);
			if (this.mAmountPerDelta >= 0f)
			{
				num = ((this.easeType1 != EaseType.none) ? EaseManager.EasingFromType(0f, 1f, num, this.easeType1) : this.animationCurve1.Evaluate(num));
			}
			else
			{
				num = ((this.easeType2 != EaseType.none) ? EaseManager.EasingFromType(0f, 1f, num, this.easeType2) : this.animationCurve2.Evaluate(num));
			}
			this.OnUpdate(num, _isFinished);
		}

		// Token: 0x06002B02 RID: 11010 RVA: 0x00470AA4 File Offset: 0x0046ECA4
		protected virtual void OnUpdate(float _factor, bool _isFinished)
		{
		}

		// Token: 0x06002B03 RID: 11011 RVA: 0x00470AA8 File Offset: 0x0046ECA8
		public void Reset()
		{
			base.enabled = true;
			this.easeType1 = EaseType.linear;
			this.easeType2 = EaseType.linear;
			this.loopStyle = LoopStyle.PingPong;
			this.delay = 0f;
			this.duration = 1f;
			this.ignoreTimeScale = true;
			this.onFinished = null;
			this.mAmountPerDelta = 1000f;
			this.mDuration = 0f;
			this.mStartTime = -1f;
			this.mFactor = 0f;
		}

		// Token: 0x06002B04 RID: 11012 RVA: 0x00470B24 File Offset: 0x0046ED24
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

		// Token: 0x06002B05 RID: 11013 RVA: 0x00470B78 File Offset: 0x0046ED78
		public void Play(PlayDirection dir = PlayDirection.Forward)
		{
			this.mAmountPerDelta = ((dir != PlayDirection.Reverse) ? Mathf.Abs(this.amountPerDelta) : (-Mathf.Abs(this.amountPerDelta)));
			base.enabled = true;
			this.Update();
		}

		// Token: 0x06002B06 RID: 11014 RVA: 0x00470BBC File Offset: 0x0046EDBC
		public void Toggle()
		{
			this.mAmountPerDelta *= -1f;
			base.enabled = true;
		}

		// Token: 0x06002B07 RID: 11015 RVA: 0x00470BD8 File Offset: 0x0046EDD8
		[ContextMenu("Set 'From' to current value")]
		public virtual void SetStartToCurrentValue()
		{
		}

		// Token: 0x06002B08 RID: 11016 RVA: 0x00470BDC File Offset: 0x0046EDDC
		[ContextMenu("Set 'To' to current value")]
		public virtual void SetEndToCurrentValue()
		{
		}

		// Token: 0x06002B09 RID: 11017 RVA: 0x00470BE0 File Offset: 0x0046EDE0
		[ContextMenu("Assume value of 'From'")]
		public virtual void SetCurrentValueToStart()
		{
		}

		// Token: 0x06002B0A RID: 11018 RVA: 0x00470BE4 File Offset: 0x0046EDE4
		[ContextMenu("Assume value of 'To'")]
		public virtual void SetCurrentValueToEnd()
		{
		}

		// Token: 0x04007697 RID: 30359
		public AnimationCurve animationCurve1 = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f, 0f, 1f),
			new Keyframe(1f, 1f, 1f, 0f)
		});

		// Token: 0x04007698 RID: 30360
		public AnimationCurve animationCurve2 = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f, 0f, 1f),
			new Keyframe(1f, 1f, 1f, 0f)
		});

		// Token: 0x04007699 RID: 30361
		public EaseType easeType1;

		// Token: 0x0400769A RID: 30362
		public EaseType easeType2;

		// Token: 0x0400769B RID: 30363
		private LoopStyle loopStyle = LoopStyle.PingPong;

		// Token: 0x0400769C RID: 30364
		public float delay;

		// Token: 0x0400769D RID: 30365
		public float duration = 1f;

		// Token: 0x0400769E RID: 30366
		public bool ignoreTimeScale = true;

		// Token: 0x0400769F RID: 30367
		public UnityEvent onFinished;

		// Token: 0x040076A0 RID: 30368
		private float mAmountPerDelta = 1000f;

		// Token: 0x040076A1 RID: 30369
		private float mDuration;

		// Token: 0x040076A2 RID: 30370
		private float mStartTime = -1f;

		// Token: 0x040076A3 RID: 30371
		private float mFactor;
	}
}
