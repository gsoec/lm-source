using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200027F RID: 639
public class Totality : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler, IEventSystemHandler
{
	// Token: 0x06000C35 RID: 3125 RVA: 0x001196E8 File Offset: 0x001178E8
	protected void Awake()
	{
		GameObject gameObject = new GameObject("Totality3D");
		this.Totality_3DTransform = gameObject.transform;
		this.Totality_3DTransform.localScale = Vector3.one * DataManager.MapDataController.worldZoomSize;
		this.InPutLock = false;
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/WorldBase", out this.WorldMapBaseABKey, false);
		GameObject gameObject2 = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
		RectTransform component = gameObject2.GetComponent<RectTransform>();
		this.Canvasrectran = GUIManager.Instance.pDVMgr.CanvasRT;
		component.sizeDelta = this.Canvasrectran.sizeDelta;
		if (GUIManager.Instance.m_UICanvas.renderMode == RenderMode.ScreenSpaceCamera)
		{
			DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale = this.Canvasrectran.localScale.x;
		}
		this.worldMapController = gameObject2.GetComponent<WorldMap>();
		if (this.worldMapController == null)
		{
			this.worldMapController = gameObject2.AddComponent<WorldMap>();
		}
		component.SetParent(GUIManager.Instance.m_UICanvas.transform.GetChild(0), false);
		component.SetAsFirstSibling();
		this.yolkController = new WorldMapYolk(base.transform, this.worldMapController.TileSprites);
		this.mapNameController = new WorldMapName(base.transform, this.worldMapController.TileSprites);
		this.mapGraphicController = new WorldMapGraphic(base.transform, this.worldMapController.TileSprites);
		this.mapEffectController = new WorldMapEffect(this.Totality_3DTransform, this.worldMapController.TileBaseScale);
		this.worldMapController.setEffect(this.mapEffectController);
		this.worldMapController.setRealmGroup_3DTransform(this.Totality_3DTransform);
		this.worldMapController.setKingdomYolk(this.yolkController);
		this.worldMapController.setKingdomName(this.mapNameController);
		this.worldMapController.setKingdomGraphic(this.mapGraphicController);
	}

	// Token: 0x06000C36 RID: 3126 RVA: 0x001198C8 File Offset: 0x00117AC8
	protected void OnDestroy()
	{
		this.ClearEffect();
		if (this.mapNameController != null)
		{
			this.mapNameController.OnDestroy();
		}
		this.mapNameController = null;
		if (this.yolkController != null)
		{
			this.yolkController.OnDestroy();
		}
		this.yolkController = null;
		if (this.worldMapController != null)
		{
			UnityEngine.Object.DestroyObject(this.worldMapController.gameObject);
		}
		this.worldMapController = null;
		this.Canvasrectran = null;
		if (this.Totality_3DTransform != null)
		{
			UnityEngine.Object.DestroyObject(this.Totality_3DTransform.gameObject);
		}
		this.Totality_3DTransform = null;
		AssetManager.UnloadAssetBundle(this.WorldMapBaseABKey, true);
		AssetManager.UnloadAssetBundle(this.WorldMapGraphicABKey, true);
	}

	// Token: 0x06000C37 RID: 3127 RVA: 0x00119984 File Offset: 0x00117B84
	protected void Update()
	{
		this.mapNameController.myPosImageRun();
		this.yolkController.updateYolkImage();
	}

	// Token: 0x06000C38 RID: 3128 RVA: 0x0011999C File Offset: 0x00117B9C
	public void OnDrag(PointerEventData eventData)
	{
		if (this.InPutLock)
		{
			return;
		}
		this.worldMapController.OnDrag(eventData);
		this.worldMapController.Movedelta = Vector2.zero;
	}

	// Token: 0x06000C39 RID: 3129 RVA: 0x001199D4 File Offset: 0x00117BD4
	public void OnPointerDown(PointerEventData eventData)
	{
		if (this.InPutLock)
		{
			return;
		}
		this.worldMapController.OnPointerDown(eventData);
	}

	// Token: 0x06000C3A RID: 3130 RVA: 0x001199F0 File Offset: 0x00117BF0
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.InPutLock)
		{
			return;
		}
		this.worldMapController.OnPointerUp(eventData);
	}

	// Token: 0x06000C3B RID: 3131 RVA: 0x00119A0C File Offset: 0x00117C0C
	public void UpdateNetwork()
	{
	}

	// Token: 0x06000C3C RID: 3132 RVA: 0x00119A10 File Offset: 0x00117C10
	public void UpdateKingdom(byte kingdomtableid, byte updatekind)
	{
		this.worldMapController.UpdateKingdom(kingdomtableid, updatekind);
	}

	// Token: 0x06000C3D RID: 3133 RVA: 0x00119A20 File Offset: 0x00117C20
	public void ClearEffect()
	{
	}

	// Token: 0x06000C3E RID: 3134 RVA: 0x00119A24 File Offset: 0x00117C24
	public void MoveToKingdom(ushort KingdomID)
	{
		this.worldMapController.moveToKingdom(KingdomID);
	}

	// Token: 0x06000C3F RID: 3135 RVA: 0x00119A34 File Offset: 0x00117C34
	public void WorldMapNameFontTextureRebuilt()
	{
		if (this.mapNameController != null)
		{
			this.mapNameController.WorldKingdomNameRebuilt();
		}
	}

	// Token: 0x04002821 RID: 10273
	public WorldMap worldMapController;

	// Token: 0x04002822 RID: 10274
	public Transform Totality_3DTransform;

	// Token: 0x04002823 RID: 10275
	public bool InPutLock;

	// Token: 0x04002824 RID: 10276
	public WorldMapGraphic mapGraphicController;

	// Token: 0x04002825 RID: 10277
	private RectTransform Canvasrectran;

	// Token: 0x04002826 RID: 10278
	private int WorldMapBaseABKey;

	// Token: 0x04002827 RID: 10279
	private int WorldMapGraphicABKey;

	// Token: 0x04002828 RID: 10280
	private WorldMapYolk yolkController;

	// Token: 0x04002829 RID: 10281
	private WorldMapName mapNameController;

	// Token: 0x0400282A RID: 10282
	private WorldMapEffect mapEffectController;
}
