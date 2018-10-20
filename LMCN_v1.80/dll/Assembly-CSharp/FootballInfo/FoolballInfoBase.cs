using System;
using UnityEngine;

namespace FootballInfo
{
	// Token: 0x02000369 RID: 873
	public class FoolballInfoBase
	{
		// Token: 0x060011F8 RID: 4600 RVA: 0x001F2398 File Offset: 0x001F0598
		public virtual void OnButtonClick(UIButton sender)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu(false);
		}

		// Token: 0x060011F9 RID: 4601 RVA: 0x001F23C0 File Offset: 0x001F05C0
		public virtual void OnClose()
		{
		}

		// Token: 0x060011FA RID: 4602 RVA: 0x001F23C4 File Offset: 0x001F05C4
		public virtual int GetRowCount()
		{
			return 0;
		}

		// Token: 0x060011FB RID: 4603 RVA: 0x001F23C8 File Offset: 0x001F05C8
		public virtual void CreateItem(int index, Transform transform, Font font)
		{
		}

		// Token: 0x060011FC RID: 4604 RVA: 0x001F23CC File Offset: 0x001F05CC
		public virtual void UpdateRowData(int index)
		{
		}

		// Token: 0x040038C4 RID: 14532
		protected UIFootBallInfo InfoUI;

		// Token: 0x040038C5 RID: 14533
		protected bool IsKvk;
	}
}
