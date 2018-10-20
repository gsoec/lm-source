using System;
using UnityEngine.UI;

// Token: 0x020006C2 RID: 1730
public class InputBox2 : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
	// Token: 0x06002133 RID: 8499 RVA: 0x003F24D4 File Offset: 0x003F06D4
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
		img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
		img.material = GUIManager.Instance.GetFrameMaterial();
	}

	// Token: 0x06002134 RID: 8500 RVA: 0x003F2538 File Offset: 0x003F0738
	public void OnButtonClick(UIButton sender)
	{
	}

	// Token: 0x06002135 RID: 8501 RVA: 0x003F253C File Offset: 0x003F073C
	public void Refresh_FontTexture()
	{
	}
}
