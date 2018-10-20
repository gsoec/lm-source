using System;
using UnityEngine;

namespace FootballInfo
{
	// Token: 0x0200036B RID: 875
	public class FootballActInfo : FoolballInfoBase
	{
		// Token: 0x06001202 RID: 4610 RVA: 0x001F2774 File Offset: 0x001F0974
		public FootballActInfo(UIFootBallInfo InfoUI)
		{
			this.InfoUI = InfoUI;
			EActivityState kvKState = ActivityManager.Instance.GetKvKState();
			if (kvKState > EActivityState.EAS_None && kvKState < EActivityState.EAS_ReplayRanking)
			{
				this.IsKvk = true;
			}
			else
			{
				this.IsKvk = false;
			}
			if (this.IsKvk)
			{
				this.IDs = new uint[3];
				this.Fontsize = new int[3];
				this.LineSpace = new int[3];
				InfoUI.TitleText.text = DataManager.Instance.mStringTable.GetStringByID(14751u);
				this.IDs[0] = 12223u;
				this.IDs[1] = 12241u;
				this.IDs[2] = 14752u;
				this.Fontsize[0] = 17;
				this.Fontsize[1] = 19;
				this.Fontsize[2] = 17;
				this.LineSpace[0] = 22;
				this.LineSpace[1] = 0;
				this.LineSpace[2] = 22;
			}
			else
			{
				this.IDs = new uint[5];
				this.Fontsize = new int[5];
				this.LineSpace = new int[5];
				InfoUI.TitleText.text = DataManager.Instance.mStringTable.GetStringByID(12225u);
				this.IDs[0] = 12223u;
				this.IDs[1] = 12224u;
				this.IDs[2] = 12240u;
				this.IDs[3] = 12241u;
				this.IDs[4] = 12242u;
				this.Fontsize[0] = 17;
				this.Fontsize[1] = 19;
				this.Fontsize[2] = 17;
				this.Fontsize[3] = 19;
				this.Fontsize[4] = 17;
				this.LineSpace[0] = 22;
				this.LineSpace[1] = 0;
				this.LineSpace[2] = 22;
				this.LineSpace[3] = 0;
				this.LineSpace[4] = 22;
			}
		}

		// Token: 0x06001203 RID: 4611 RVA: 0x001F2958 File Offset: 0x001F0B58
		public override int GetRowCount()
		{
			return FootballManager.Instance.FootBallSkillTable.TableCount + 2;
		}

		// Token: 0x06001204 RID: 4612 RVA: 0x001F296C File Offset: 0x001F0B6C
		public override void CreateItem(int index, Transform transform, Font font)
		{
			if (index == 0)
			{
				this.InfoUI.ScrollItems[index] = new UIFootBallInfo.ItemTextMulti((byte)this.IDs.Length, this.InfoUI.ItemTypeTrans.GetChild(1), font);
				this.InfoUI.ScrollItems[index].recttransform.SetParent(transform, false);
				this.InfoUI.ScrollItems[index].SetData(this.IDs, this.Fontsize, this.LineSpace);
			}
			else
			{
				if (index == 1)
				{
					this.InfoUI.ScrollItems[index] = new UIFootBallInfo.ItemTitle(this.InfoUI.ItemTypeTrans.GetChild(2), font);
				}
				else
				{
					this.InfoUI.ScrollItems[index] = new UIFootBallInfo.ItemSkill(this.InfoUI.ItemTypeTrans.GetChild(3), font, this.InfoUI.SkillIconArray, this.InfoUI);
				}
				this.InfoUI.ScrollItems[index].recttransform.SetParent(transform, false);
			}
		}

		// Token: 0x06001205 RID: 4613 RVA: 0x001F2A6C File Offset: 0x001F0C6C
		public override void UpdateRowData(int index)
		{
			if (index == 0)
			{
				this.InfoUI.ScrollItems[index].SetData(this.IDs, this.Fontsize, this.LineSpace);
			}
			else if (index == 1)
			{
				this.InfoUI.ScrollItems[index].SetData(17201);
			}
			else
			{
				this.InfoUI.ScrollItems[index].SetData(index - 2);
			}
		}

		// Token: 0x040038C9 RID: 14537
		private uint[] IDs;

		// Token: 0x040038CA RID: 14538
		private int[] Fontsize;

		// Token: 0x040038CB RID: 14539
		private int[] LineSpace;
	}
}
