using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200085F RID: 2143
public class UIBtnDrag : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler, IEventSystemHandler
{
	// Token: 0x06002C38 RID: 11320 RVA: 0x00488780 File Offset: 0x00486980
	public void ReSetHero()
	{
		this.tmpX = 0f;
		this.CameraQuaternion.eulerAngles = new Vector3(0f, this.tmpX, 0f);
		this.mHero.localRotation = this.CameraQuaternion;
	}

	// Token: 0x06002C39 RID: 11321 RVA: 0x004887CC File Offset: 0x004869CC
	public void OnPointerDown(PointerEventData eventData)
	{
	}

	// Token: 0x06002C3A RID: 11322 RVA: 0x004887D0 File Offset: 0x004869D0
	public void OnPointerUp(PointerEventData eventData)
	{
	}

	// Token: 0x06002C3B RID: 11323 RVA: 0x004887D4 File Offset: 0x004869D4
	public virtual void OnDrag(PointerEventData eventData)
	{
		if (!GUIManager.Instance.IsArabic)
		{
			this.tmpX -= eventData.delta.x / 2f;
		}
		else
		{
			this.tmpX += eventData.delta.x / 2f;
		}
		this.CameraQuaternion.eulerAngles = new Vector3(0f, this.tmpX, 0f);
		this.mHero.localRotation = this.CameraQuaternion;
	}

	// Token: 0x06002C3C RID: 11324 RVA: 0x00488868 File Offset: 0x00486A68
	private void Start()
	{
		this.tmpX = 0f;
		this.CameraQuaternion.eulerAngles = Vector3.zero;
	}

	// Token: 0x06002C3D RID: 11325 RVA: 0x00488888 File Offset: 0x00486A88
	private void Update()
	{
	}

	// Token: 0x040078F0 RID: 30960
	public RectTransform mHero;

	// Token: 0x040078F1 RID: 30961
	public Quaternion CameraQuaternion = Quaternion.identity;

	// Token: 0x040078F2 RID: 30962
	public float tmpX;
}
