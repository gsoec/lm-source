using System;
using UnityEngine;

namespace FootballInfo
{
	// Token: 0x0200036A RID: 874
	public class FootballSkillInfo : FoolballInfoBase
	{
		// Token: 0x060011FD RID: 4605 RVA: 0x001F23D0 File Offset: 0x001F05D0
		public FootballSkillInfo(UIFootBallInfo InfoUI)
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

		// Token: 0x060011FE RID: 4606 RVA: 0x001F25B4 File Offset: 0x001F07B4
		public override int GetRowCount()
		{
			return FootballManager.Instance.FootBallSkillTable.TableCount + 2;
		}

		// Token: 0x060011FF RID: 4607 RVA: 0x001F25C8 File Offset: 0x001F07C8
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

		// Token: 0x06001200 RID: 4608 RVA: 0x001F26C8 File Offset: 0x001F08C8
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

		// Token: 0x06001201 RID: 4609 RVA: 0x001F273C File Offset: 0x001F093C
		public override void OnButtonClick(UIButton sender)
		{
			GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_FootBall, 0, 0, false, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBall, 6, 0);
			base.OnButtonClick(sender);
		}

		// Token: 0x040038C6 RID: 14534
		private uint[] IDs;

		// Token: 0x040038C7 RID: 14535
		private int[] Fontsize;

		// Token: 0x040038C8 RID: 14536
		private int[] LineSpace;
	}
}
