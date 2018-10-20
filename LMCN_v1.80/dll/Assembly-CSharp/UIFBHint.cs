using System;
using UnityEngine;

// Token: 0x02000408 RID: 1032
public class UIFBHint
{
	// Token: 0x0600152D RID: 5421 RVA: 0x00241A80 File Offset: 0x0023FC80
	public UIFBHint()
	{
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UIFBMission", out this.BundleKey, false);
		if (assetBundle == null)
		{
			return;
		}
		UnityEngine.Object @object = assetBundle.Load("Hint");
		if (@object == null)
		{
			return;
		}
		GUIManager instance = GUIManager.Instance;
		Font ttffont = instance.GetTTFFont();
		this.gameobject = (GameObject)UnityEngine.Object.Instantiate(@object);
		this.recttransform = (this.gameobject.transform as RectTransform);
		this.FrameArray = this.recttransform.GetChild(0).GetComponent<UISpritesArray>();
		this.canvasGroup = this.recttransform.GetComponent<CanvasGroup>();
		this.MissionHint = new FBMissionHint(this.recttransform.GetChild(0).GetChild(0), ttffont);
		this.FriendHint = new FBFriendHint(this.recttransform.GetChild(0).GetChild(1), ttffont, this.recttransform.GetChild(1));
		this.recttransform.SetParent(instance.FindMenu(EGUIWindow.UI_MissionFB).transform, false);
		this.recttransform.SetAsLastSibling();
		this.blockGameObj = this.recttransform.GetChild(1).gameObject;
		this.Hide(null);
	}

	// Token: 0x0600152E RID: 5422 RVA: 0x00241BB4 File Offset: 0x0023FDB4
	public void UpdateData()
	{
		this.MissionHint.UpdateData();
		this.FriendHint.UpdateData();
		if (this.FriendHint.gameobject.activeSelf)
		{
			float height = this.FriendHint.Height;
			this.recttransform.sizeDelta = new Vector2(this.FriendHint.Width, height);
			if (this.HintTrans != null)
			{
				this.GetTipPosition(this.HintTrans, UIButtonHint.ePosition.LeftSide, new Vector3?(new Vector3(-30f, 0f, 0f)));
			}
			if (this.FriendHint.FriendCount > 0)
			{
				this.blockGameObj.SetActive(true);
				this.canvasGroup.blocksRaycasts = true;
			}
			else
			{
				this.blockGameObj.SetActive(false);
				this.canvasGroup.blocksRaycasts = false;
			}
		}
	}

	// Token: 0x0600152F RID: 5423 RVA: 0x00241C94 File Offset: 0x0023FE94
	public void UpdateTime()
	{
		this.FriendHint.UpdateTime();
	}

	// Token: 0x06001530 RID: 5424 RVA: 0x00241CA4 File Offset: 0x0023FEA4
	public void TextRefresh()
	{
		this.MissionHint.TextRefresh();
		this.FriendHint.TextRefresh();
	}

	// Token: 0x06001531 RID: 5425 RVA: 0x00241CBC File Offset: 0x0023FEBC
	public void Destroy()
	{
		this.MissionHint.Destroy();
		this.FriendHint.Destroy();
		if (this.BundleKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.BundleKey, true);
			this.BundleKey = 0;
			UnityEngine.Object.Destroy(this.gameobject);
			this.gameobject = null;
		}
	}

	// Token: 0x06001532 RID: 5426 RVA: 0x00241D10 File Offset: 0x0023FF10
	public void Show(ushort ID, Transform sender)
	{
		this.gameobject.SetActive(true);
		this.blockGameObj.SetActive(false);
		this.FriendHint.Hide();
		this.canvasGroup.blocksRaycasts = false;
		this.FrameArray.SetSpriteIndex(0);
		this.MissionHint.Show(ID);
		float height = this.MissionHint.Height;
		this.recttransform.sizeDelta = new Vector2(this.MissionHint.Width, height);
		if (sender != null)
		{
			this.GetTipPosition(sender, UIButtonHint.ePosition.LeftSide, new Vector3?(new Vector3(-30f, 0f, 0f)));
		}
		this.HintTrans = sender;
	}

	// Token: 0x06001533 RID: 5427 RVA: 0x00241DC0 File Offset: 0x0023FFC0
	public void ShowFriend(ushort ID, Transform sender)
	{
		CanvasGroup component = sender.GetComponent<CanvasGroup>();
		if (component != null && component.alpha < 0.1f)
		{
			return;
		}
		this.gameobject.SetActive(true);
		this.MissionHint.Hide();
		this.FrameArray.SetSpriteIndex(1);
		this.FriendHint.Show(ID);
		if (this.FriendHint.FriendCount > 0)
		{
			this.blockGameObj.SetActive(true);
			this.canvasGroup.blocksRaycasts = true;
		}
		else
		{
			this.blockGameObj.SetActive(false);
			this.canvasGroup.blocksRaycasts = false;
		}
		this.HintTrans = sender;
		float height = this.FriendHint.Height;
		if (height > 0f)
		{
			this.recttransform.sizeDelta = new Vector2(this.FriendHint.Width, height);
			if (sender != null)
			{
				this.GetTipPosition(sender, UIButtonHint.ePosition.LeftSide, new Vector3?(new Vector3(-30f, 0f, 0f)));
			}
		}
		else
		{
			this.Hide(null);
		}
	}

	// Token: 0x06001534 RID: 5428 RVA: 0x00241EDC File Offset: 0x002400DC
	public void GetTipPosition(Transform HintTransform, UIButtonHint.ePosition position = UIButtonHint.ePosition.Original, Vector3? upsetPoint = null)
	{
		RectTransform rectTransform = HintTransform as RectTransform;
		RectTransform rectTransform2 = this.recttransform;
		if (rectTransform == null)
		{
			return;
		}
		Vector2 size = GUIManager.Instance.m_MessageBoxLayer.rect.size;
		rectTransform2.position = rectTransform.position;
		Vector3 vector = rectTransform2.anchoredPosition3D;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			size.x -= GUIManager.Instance.IPhoneX_DeltaX * 2f;
		}
		if (position == UIButtonHint.ePosition.Original)
		{
			vector.x += rectTransform.rect.x;
			vector.y += rectTransform.rect.y;
		}
		else
		{
			vector.x -= rectTransform2.rect.width;
			vector.y += rectTransform.rect.y - rectTransform.rect.height;
		}
		if (upsetPoint != null)
		{
			vector += upsetPoint.Value;
		}
		vector.z = 0f;
		if (vector.x + rectTransform2.sizeDelta.x > size.x)
		{
			vector.x = size.x - rectTransform2.sizeDelta.x;
		}
		else if (vector.x < 0f)
		{
			vector.x = 0f;
		}
		if (vector.y + rectTransform.rect.height + rectTransform2.sizeDelta.y <= 0f)
		{
			vector.y += rectTransform.rect.height + rectTransform2.sizeDelta.y;
		}
		else if (-1f * vector.y + rectTransform2.sizeDelta.y > size.y)
		{
			vector.y = -1f * (size.y - rectTransform2.sizeDelta.y);
		}
		if (vector.y > -60f)
		{
			vector.y = -60f;
		}
		rectTransform2.anchoredPosition3D = vector;
	}

	// Token: 0x06001535 RID: 5429 RVA: 0x0024214C File Offset: 0x0024034C
	public void Hide(Transform sender = null)
	{
		if (this.gameobject != null && (sender == null || this.HintTrans == sender))
		{
			this.gameobject.SetActive(false);
			this.HintTrans = null;
		}
	}

	// Token: 0x04003E27 RID: 15911
	private int BundleKey;

	// Token: 0x04003E28 RID: 15912
	public GameObject gameobject;

	// Token: 0x04003E29 RID: 15913
	private GameObject blockGameObj;

	// Token: 0x04003E2A RID: 15914
	private RectTransform recttransform;

	// Token: 0x04003E2B RID: 15915
	private FBMissionHint MissionHint;

	// Token: 0x04003E2C RID: 15916
	private FBFriendHint FriendHint;

	// Token: 0x04003E2D RID: 15917
	private UISpritesArray FrameArray;

	// Token: 0x04003E2E RID: 15918
	private CanvasGroup canvasGroup;

	// Token: 0x04003E2F RID: 15919
	private Transform HintTrans;
}
