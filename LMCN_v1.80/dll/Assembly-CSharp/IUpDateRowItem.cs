using System;
using UnityEngine;

// Token: 0x020007F3 RID: 2035
public interface IUpDateRowItem
{
	// Token: 0x06002A44 RID: 10820
	void UpDateRowItem(GameObject[] gameObjs, int[] btnIndexs);

	// Token: 0x06002A45 RID: 10821
	void ButtonOnClick(GameObject gameObject, int dataIndex);

	// Token: 0x06002A46 RID: 10822
	void OnScroll(RectTransform rt);

	// Token: 0x06002A47 RID: 10823
	void Initialized();
}
