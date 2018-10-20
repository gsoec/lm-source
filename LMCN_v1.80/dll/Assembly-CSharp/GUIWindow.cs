using System;
using UnityEngine;

// Token: 0x02000198 RID: 408
public class GUIWindow : MonoBehaviour
{
	// Token: 0x060005D6 RID: 1494 RVA: 0x00081EF4 File Offset: 0x000800F4
	public virtual void OnOpen(int arg1, int arg2)
	{
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x00081EF8 File Offset: 0x000800F8
	public virtual void OnClose()
	{
	}

	// Token: 0x060005D8 RID: 1496 RVA: 0x00081EFC File Offset: 0x000800FC
	public virtual void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x060005D9 RID: 1497 RVA: 0x00081F00 File Offset: 0x00080100
	public virtual void UpdateNetwork(byte[] meg)
	{
	}

	// Token: 0x060005DA RID: 1498 RVA: 0x00081F04 File Offset: 0x00080104
	public virtual void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
	}

	// Token: 0x060005DB RID: 1499 RVA: 0x00081F08 File Offset: 0x00080108
	public virtual bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x060005DC RID: 1500 RVA: 0x00081F0C File Offset: 0x0008010C
	public virtual void ReOnOpen()
	{
	}

	// Token: 0x060005DD RID: 1501 RVA: 0x00081F10 File Offset: 0x00080110
	public virtual void UpdateTime(bool bOnSecond)
	{
	}

	// Token: 0x040017A0 RID: 6048
	public EGUIWindow m_eWindow;

	// Token: 0x040017A1 RID: 6049
	public AssetBundle m_AssetBundle;

	// Token: 0x040017A2 RID: 6050
	public int m_AssetBundleKey;

	// Token: 0x040017A3 RID: 6051
	public bool m_bDontDestroyOnSwitch;
}
