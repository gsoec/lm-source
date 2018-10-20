using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000191 RID: 401
public class EmojiCenter
{
	// Token: 0x060005BA RID: 1466 RVA: 0x0007F230 File Offset: 0x0007D430
	public EmojiCenter()
	{
		this.EmojiUnitPoolCount = 0;
		this.EmojiUnitPool = new List<EmojiUnit>(128);
		this.IconIdMapEmojiSprites = new Dictionary<ushort, EmojiCenter.EmojiSprite>();
	}

	// Token: 0x060005BB RID: 1467 RVA: 0x0007F268 File Offset: 0x0007D468
	public void EmojiCenterIni()
	{
		if (this.EmojiAB == null)
		{
			GameObject gameObject = new GameObject("EmojiCenter");
			this.EmojiCenterLayout = gameObject.transform;
			gameObject = new GameObject("EmojiSprites");
			this.EmojiSpriteLayout = gameObject.transform;
			this.EmojiSpriteLayout.SetParent(this.EmojiCenterLayout, false);
			gameObject = new GameObject("ImagePool");
			this.ImagePoolLayout = gameObject.transform;
			this.ImagePoolLayout.SetParent(this.EmojiCenterLayout, false);
			gameObject = new GameObject("SpriteRendererPool");
			this.SpriteRendererPoolLayout = gameObject.transform;
			this.SpriteRendererPoolLayout.SetParent(this.EmojiCenterLayout, false);
			CString cstring = StringManager.Instance.SpawnString(30);
			cstring.ClearString();
			cstring.Append("UI/Map_NPC_Blood");
			this.EmojiAB = AssetManager.GetAssetBundle(cstring, out this.EmojiABKey);
			for (ushort num = 0; num < 8; num += 1)
			{
				this.AddEmojiSprite(num);
			}
			this.AddEmojiSprite(ushort.MaxValue);
			Image component = this.EmojiSpriteLayout.GetChild(0).GetComponent<Image>();
			this.basesize = (float)DataManager.MapDataController.EmojiDataTable.GetRecordByKey(1).sizeX;
			if (this.basesize == 0f)
			{
				this.basesize = 60f;
			}
			this.EmojiImageMaterial = component.material;
			this.EmojiSpriteRendererMaterial = new Material(this.EmojiImageMaterial);
			this.EmojiSpriteRendererMaterial.renderQueue = 2665;
			RectTransform rectTransform = this.EmojiSpriteLayout.GetChild(this.EmojiSpriteLayout.childCount - 1) as RectTransform;
			this.basebacksize = rectTransform.sizeDelta.x;
			if (this.basebacksize < rectTransform.sizeDelta.y)
			{
				this.basebacksize = rectTransform.sizeDelta.y;
			}
			if (this.basebacksize == 0f)
			{
				this.basebacksize = 73f;
			}
			this.basebackoffset = this.basebacksize - this.basesize * 0.9f;
		}
		if (this.ImagePoolLayout == null)
		{
			GameObject gameObject2 = new GameObject("ImagePool");
			this.ImagePoolLayout = gameObject2.transform;
			this.ImagePoolLayout.SetParent(this.EmojiCenterLayout, false);
		}
		if (this.SpriteRendererPoolLayout == null)
		{
			GameObject gameObject3 = new GameObject("SpriteRendererPool");
			this.SpriteRendererPoolLayout = gameObject3.transform;
			this.SpriteRendererPoolLayout.SetParent(this.EmojiCenterLayout, false);
		}
	}

	// Token: 0x060005BC RID: 1468 RVA: 0x0007F4FC File Offset: 0x0007D6FC
	public void OnDestroy()
	{
	}

	// Token: 0x060005BD RID: 1469 RVA: 0x0007F50C File Offset: 0x0007D70C
	public EmojiUnit pullIcon(ushort iconid, byte defaultSpriteID = 0, bool isSpriteRenderer = false)
	{
		this.EmojiCenterIni();
		if (!this.IconIdMapEmojiSprites.ContainsKey(iconid) && !this.AddEmojiSprite(iconid))
		{
			iconid = 0;
		}
		EmojiCenter.EmojiSprite emojiSprite = this.IconIdMapEmojiSprites[iconid];
		EmojiUnit emojiUnit;
		if (this.EmojiUnitPoolCount == 0)
		{
			emojiUnit = new EmojiUnit();
			emojiUnit.poolID = this.EmojiUnitPool.Count;
			this.EmojiUnitPool.Add(emojiUnit);
		}
		else
		{
			emojiUnit = this.EmojiUnitPool[--this.EmojiUnitPoolCount];
			emojiUnit.poolID = this.EmojiUnitPoolCount;
		}
		emojiUnit.EmojiUnitIni(defaultSpriteID);
		emojiUnit.IconID = iconid;
		emojiUnit.SpriteMove = this.EmojiSpriteLayout.GetChild(emojiSprite.LayoutID).GetComponent<UISpritesArray>().m_Sprites;
		GameObject gameObject;
		if (isSpriteRenderer)
		{
			if (this.SpriteRendererPoolLayout.childCount == 0)
			{
				gameObject = new GameObject("eicon_sr");
				gameObject.AddComponent<SpriteRenderer>().material = this.EmojiSpriteRendererMaterial;
			}
			else
			{
				gameObject = this.SpriteRendererPoolLayout.GetChild(this.SpriteRendererPoolLayout.childCount - 1).gameObject;
				gameObject.transform.SetParent(null, false);
			}
			emojiUnit.EmojiImage = null;
			emojiUnit.EmojiSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
			if (emojiUnit.SpriteMove.Length <= 1)
			{
				emojiUnit.EmojiSpriteRenderer.sprite = emojiUnit.SpriteMove[0];
			}
		}
		else
		{
			if (this.ImagePoolLayout.childCount == 0)
			{
				gameObject = new GameObject("eicon_ig");
				gameObject.AddComponent<Image>().material = this.EmojiImageMaterial;
			}
			else
			{
				gameObject = this.ImagePoolLayout.GetChild(this.ImagePoolLayout.childCount - 1).gameObject;
				gameObject.transform.SetParent(null, false);
			}
			emojiUnit.EmojiSpriteRenderer = null;
			emojiUnit.EmojiImage = gameObject.GetComponent<Image>();
			emojiUnit.setImagePivot();
		}
		emojiUnit.EmojiTransform = gameObject.transform;
		gameObject.SetActive(true);
		return emojiUnit;
	}

	// Token: 0x060005BE RID: 1470 RVA: 0x0007F700 File Offset: 0x0007D900
	public void pushIcon(EmojiUnit inIcon)
	{
		inIcon.EmojiTransform.gameObject.SetActive(false);
		if (inIcon.EmojiSpriteRenderer == null)
		{
			inIcon.EmojiImage.type = Image.Type.Simple;
			inIcon.EmojiImage.material = this.EmojiImageMaterial;
			inIcon.EmojiTransform.localPosition = Vector3.zero;
			inIcon.EmojiTransform.localScale = Vector3.one;
			inIcon.EmojiTransform.SetParent(this.ImagePoolLayout, false);
			inIcon.EmojiImage.SetNativeSize();
			inIcon.EmojiImage = null;
		}
		else
		{
			inIcon.EmojiSpriteRenderer.material = this.EmojiSpriteRendererMaterial;
			inIcon.EmojiTransform.localPosition = Vector3.zero;
			inIcon.EmojiTransform.localScale = Vector3.one;
			inIcon.EmojiTransform.SetParent(this.SpriteRendererPoolLayout, false);
			inIcon.EmojiSpriteRenderer = null;
		}
		inIcon.EmojiTransform = null;
		inIcon.SpriteMove = null;
		if (inIcon.poolID != this.EmojiUnitPoolCount)
		{
			EmojiUnit emojiUnit = this.EmojiUnitPool[this.EmojiUnitPoolCount];
			this.EmojiUnitPool[this.EmojiUnitPoolCount] = inIcon;
			this.EmojiUnitPool[inIcon.poolID] = emojiUnit;
			emojiUnit.poolID = inIcon.poolID;
			inIcon.poolID = this.EmojiUnitPoolCount;
		}
		this.EmojiUnitPoolCount++;
	}

	// Token: 0x060005BF RID: 1471 RVA: 0x0007F85C File Offset: 0x0007DA5C
	public void Clear()
	{
		if (this.SpriteRendererPoolLayout != null)
		{
			UnityEngine.Object.Destroy(this.SpriteRendererPoolLayout.gameObject);
			this.SpriteRendererPoolLayout = null;
		}
		if (this.ImagePoolLayout != null)
		{
			UnityEngine.Object.Destroy(this.ImagePoolLayout.gameObject);
			this.ImagePoolLayout = null;
		}
		if (this.EmojiUnitPool != null && this.EmojiUnitPoolCount != 0)
		{
			this.EmojiUnitPool.RemoveRange(0, this.EmojiUnitPoolCount);
			this.EmojiUnitPoolCount = 0;
			for (int i = 0; i < this.EmojiUnitPool.Count; i++)
			{
				this.EmojiUnitPool[i].poolID = i;
			}
		}
	}

	// Token: 0x060005C0 RID: 1472 RVA: 0x0007F918 File Offset: 0x0007DB18
	public void Run()
	{
		for (int i = this.EmojiUnitPool.Count - 1; i >= this.EmojiUnitPoolCount; i--)
		{
			this.EmojiUnitPool[i].Run();
		}
	}

	// Token: 0x060005C1 RID: 1473 RVA: 0x0007F95C File Offset: 0x0007DB5C
	private bool AddEmojiSprite(ushort Iconid)
	{
		EmojiCenter.EmojiSprite value = default(EmojiCenter.EmojiSprite);
		value.LayoutID = this.EmojiSpriteLayout.childCount;
		CString cstring = StringManager.Instance.SpawnString(30);
		cstring.ClearString();
		cstring.IntToFormat((long)Iconid, 5, false);
		cstring.AppendFormat("UI/Emoji_icon_{0}");
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out value.IconABKey);
		StringManager.Instance.DeSpawnString(cstring);
		if (assetBundle == null)
		{
			return false;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
		gameObject.SetActive(false);
		gameObject.transform.SetParent(this.EmojiSpriteLayout, false);
		this.IconIdMapEmojiSprites.Add(Iconid, value);
		return true;
	}

	// Token: 0x04001690 RID: 5776
	public AssetBundle EmojiAB;

	// Token: 0x04001691 RID: 5777
	public float basesize;

	// Token: 0x04001692 RID: 5778
	public float basebacksize;

	// Token: 0x04001693 RID: 5779
	public float basebackoffset;

	// Token: 0x04001694 RID: 5780
	private int EmojiABKey;

	// Token: 0x04001695 RID: 5781
	private int EmojiUnitPoolCount;

	// Token: 0x04001696 RID: 5782
	private Transform EmojiCenterLayout;

	// Token: 0x04001697 RID: 5783
	private Transform EmojiSpriteLayout;

	// Token: 0x04001698 RID: 5784
	private Transform ImagePoolLayout;

	// Token: 0x04001699 RID: 5785
	private Transform SpriteRendererPoolLayout;

	// Token: 0x0400169A RID: 5786
	private Material EmojiImageMaterial;

	// Token: 0x0400169B RID: 5787
	private Material EmojiSpriteRendererMaterial;

	// Token: 0x0400169C RID: 5788
	private List<EmojiUnit> EmojiUnitPool;

	// Token: 0x0400169D RID: 5789
	private Dictionary<ushort, EmojiCenter.EmojiSprite> IconIdMapEmojiSprites;

	// Token: 0x02000192 RID: 402
	private struct EmojiSprite
	{
		// Token: 0x0400169E RID: 5790
		public int LayoutID;

		// Token: 0x0400169F RID: 5791
		public int IconABKey;
	}
}
