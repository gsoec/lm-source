using System;
using System.Collections.Generic;
using UnityEngine;

namespace uTools
{
	// Token: 0x02000807 RID: 2055
	public class uTweenPath : uTweenValue
	{
		// Token: 0x06002AB1 RID: 10929 RVA: 0x0046F9E4 File Offset: 0x0046DBE4
		private void Cache()
		{
			this.mCache = true;
			if (this.paths.Count > 1)
			{
				this.mPathsCount = this.paths.Count - 1;
			}
			if (this.target == null)
			{
				this.target = base.GetComponent<RectTransform>();
			}
			this.from = 0f;
			this.to = (float)this.mPathsCount;
		}

		// Token: 0x06002AB2 RID: 10930 RVA: 0x0046FA54 File Offset: 0x0046DC54
		private void Update()
		{
		}

		// Token: 0x06002AB3 RID: 10931 RVA: 0x0046FA58 File Offset: 0x0046DC58
		protected override void ValueUpdate(float _factor, bool _isFinished)
		{
			if (!this.mCache)
			{
				this.Cache();
			}
			this.pathIndex = Mathf.FloorToInt(_factor);
			Debug.Log(this.pathIndex);
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06002AB4 RID: 10932 RVA: 0x0046FA94 File Offset: 0x0046DC94
		// (set) Token: 0x06002AB5 RID: 10933 RVA: 0x0046FA9C File Offset: 0x0046DC9C
		private int pathIndex
		{
			get
			{
				return this.mIndex;
			}
			set
			{
				if (this.mIndex != value)
				{
					this.mIndex = value;
					Debug.Log(this.target.localPosition);
					uTweenPosition.Begin(this.target.gameObject, this.target.localPosition, this.paths[this.mIndex], this.duration / (float)this.paths.Count, 0f).loopStyle = LoopStyle.Loop;
				}
			}
		}

		// Token: 0x0400766F RID: 30319
		public RectTransform target;

		// Token: 0x04007670 RID: 30320
		public List<Vector3> paths;

		// Token: 0x04007671 RID: 30321
		private int mIndex = -1;

		// Token: 0x04007672 RID: 30322
		private int mPathsCount;

		// Token: 0x04007673 RID: 30323
		private bool mCache;
	}
}
