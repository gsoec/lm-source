using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020007DF RID: 2015
public class DemandResources : MonoBehaviour, IUIButtonClickHandler
{
	// Token: 0x060029DB RID: 10715 RVA: 0x004653EC File Offset: 0x004635EC
	public void OnButtonClick(UIButton sender)
	{
		int num = sender.m_BtnID1 - 999;
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			DataManager.Instance.bSoldierSave = true;
			DataManager.Instance.bSetExpediton = true;
			door.OpenMenu(EGUIWindow.UI_BagFilter, 1 + (4 + num << 16), (int)this.tmpValue[num - 1], false);
		}
	}

	// Token: 0x060029DC RID: 10716 RVA: 0x00465454 File Offset: 0x00463654
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < 5; i++)
		{
			if (this.TextResources[i] != null && this.TextResources[i].enabled)
			{
				this.TextResources[i].enabled = false;
				this.TextResources[i].enabled = true;
			}
		}
	}

	// Token: 0x04007544 RID: 30020
	public ushort DRID;

	// Token: 0x04007545 RID: 30021
	public int OutputValue;

	// Token: 0x04007546 RID: 30022
	public Image[] BtnResources;

	// Token: 0x04007547 RID: 30023
	public Image[] ImgResources;

	// Token: 0x04007548 RID: 30024
	public UIText[] TextResources;

	// Token: 0x04007549 RID: 30025
	public uint[] tmpValue = new uint[5];

	// Token: 0x0400754A RID: 30026
	private StringBuilder tmpString = new StringBuilder();
}
