using System;
using UnityEngine;
using UnityEngine.UI;

namespace FootballInfo
{
	// Token: 0x02000368 RID: 872
	public struct _FootSkillIcon
	{
		// Token: 0x060011F3 RID: 4595 RVA: 0x001F225C File Offset: 0x001F045C
		public _FootSkillIcon(RectTransform recttransform, Font font, UISpritesArray IconArray)
		{
			this.recttransform = recttransform;
			this.IconArray = IconArray;
			this.SkillImg = recttransform.GetComponent<Image>();
			this.DistText = recttransform.GetChild(1).GetComponent<UIText>();
			this.DistText.font = font;
			this.DistStr = StringManager.Instance.SpawnString(30);
		}

		// Token: 0x060011F4 RID: 4596 RVA: 0x001F22B4 File Offset: 0x001F04B4
		public void SetData(ref FootBallSkillData Data)
		{
			this.DistStr.ClearString();
			this.DistStr.IntToFormat((long)Data.SkillStrength, 1, false);
			this.DistStr.AppendFormat("{0}");
			this.DistText.text = this.DistStr.ToString();
			this.DistText.SetAllDirty();
			this.DistText.cachedTextGenerator.Invalidate();
			int num = (int)Data.SkillIcon;
			if (num == 0 || num > this.IconArray.m_Sprites.Length)
			{
				num = 1;
			}
			this.SkillImg.sprite = this.IconArray.GetSprite(num - 1);
		}

		// Token: 0x060011F5 RID: 4597 RVA: 0x001F2360 File Offset: 0x001F0560
		public void TextRefresh()
		{
			this.DistText.enabled = false;
			this.DistText.enabled = true;
		}

		// Token: 0x060011F6 RID: 4598 RVA: 0x001F237C File Offset: 0x001F057C
		public void OnClose()
		{
			StringManager.Instance.DeSpawnString(this.DistStr);
		}

		// Token: 0x040038BF RID: 14527
		public RectTransform recttransform;

		// Token: 0x040038C0 RID: 14528
		private UIText DistText;

		// Token: 0x040038C1 RID: 14529
		private Image SkillImg;

		// Token: 0x040038C2 RID: 14530
		private CString DistStr;

		// Token: 0x040038C3 RID: 14531
		private UISpritesArray IconArray;
	}
}
