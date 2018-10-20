using System;
using UnityEngine;

// Token: 0x020007E8 RID: 2024
public interface IUpDateScrollPanel
{
	// Token: 0x06002A07 RID: 10759
	void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId);

	// Token: 0x06002A08 RID: 10760
	void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId);
}
