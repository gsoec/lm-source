using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace uTools
{
	// Token: 0x02000804 RID: 2052
	[AddComponentMenu("uTools/Tween/Slider Colors(uTools)")]
	public class uSliderColors : MonoBehaviour
	{
		// Token: 0x06002AA3 RID: 10915 RVA: 0x0046F71C File Offset: 0x0046D91C
		private void Start()
		{
			this.mSlider = base.GetComponent<Slider>();
			if (this.mSlider == null)
			{
				Debug.LogError(" 'uSliderColors' can't find 'Slider'.");
				return;
			}
			if (this.target == null)
			{
				this.target = this.mSlider.GetComponentInChildren<Image>();
			}
			UnityAction<float> call = new UnityAction<float>(this.OnValueChanged);
			this.mSlider.onValueChanged.AddListener(call);
			this.OnValueChanged(this.mSlider.value);
		}

		// Token: 0x06002AA4 RID: 10916 RVA: 0x0046F7A4 File Offset: 0x0046D9A4
		public void OnValueChanged(float value)
		{
			float num = value * (float)(this.colors.Length - 1);
			int num2 = Mathf.FloorToInt(num);
			Color color = this.colors[0];
			if (num2 + 1 < this.colors.Length)
			{
				color = Color.Lerp(this.colors[num2], this.colors[num2 + 1], num - (float)num2);
			}
			else if (num2 < this.colors.Length)
			{
				color = this.colors[num2];
			}
			this.target.color = color;
		}

		// Token: 0x04007665 RID: 30309
		public Image target;

		// Token: 0x04007666 RID: 30310
		public Color[] colors = new Color[]
		{
			Color.red,
			Color.yellow,
			Color.green
		};

		// Token: 0x04007667 RID: 30311
		private Slider mSlider;
	}
}
