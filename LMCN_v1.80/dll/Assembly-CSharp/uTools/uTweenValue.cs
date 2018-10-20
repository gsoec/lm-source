using System;

namespace uTools
{
	// Token: 0x02000810 RID: 2064
	public class uTweenValue : uTweener
	{
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06002AE7 RID: 10983 RVA: 0x0047020C File Offset: 0x0046E40C
		// (set) Token: 0x06002AE8 RID: 10984 RVA: 0x00470214 File Offset: 0x0046E414
		public float value
		{
			get
			{
				return this.mValue;
			}
			set
			{
				this.mValue = value;
			}
		}

		// Token: 0x06002AE9 RID: 10985 RVA: 0x00470220 File Offset: 0x0046E420
		protected virtual void ValueUpdate(float value, bool isFinished)
		{
		}

		// Token: 0x06002AEA RID: 10986 RVA: 0x00470224 File Offset: 0x0046E424
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
			this.ValueUpdate(this.value, isFinished);
		}

		// Token: 0x04007689 RID: 30345
		public float from;

		// Token: 0x0400768A RID: 30346
		public float to;

		// Token: 0x0400768B RID: 30347
		private float mValue;
	}
}
