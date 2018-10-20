using System;
using UnityEngine;

// Token: 0x02000270 RID: 624
public class Damage
{
	// Token: 0x06000BAD RID: 2989 RVA: 0x0010E3E8 File Offset: 0x0010C5E8
	public Damage(Transform parentTransform, Font TextFront)
	{
		this.DamageString = new CString(10);
		this.DamageGameObject = new GameObject("damage");
		this.DamageText = this.DamageGameObject.AddComponent<TextMesh>();
		this.DamageText.font = TextFront;
		this.DamageText.color = Color.red;
		MeshRenderer component = this.DamageGameObject.GetComponent<MeshRenderer>();
		component.material = TextFront.material;
		this.DamageTransform = this.DamageGameObject.transform;
		this.DamageTransform.SetParent(parentTransform, false);
		this.SetActive(false);
	}

	// Token: 0x06000BAE RID: 2990 RVA: 0x0010E484 File Offset: 0x0010C684
	public void Tick(float deltaTime)
	{
		if (this.DamageNPC != null)
		{
			Damage.DamageState damageState = this.damageState;
			if (damageState != Damage.DamageState.Scale)
			{
				if (damageState == Damage.DamageState.Fadeout)
				{
					this.DamageAlpha -= deltaTime * 0.8333333f;
					if (this.DamageAlpha < 0f)
					{
						this.DamageAlpha = 0f;
						this.DamageNPC.DelDamage(this);
						return;
					}
					this.DamageYoffset += deltaTime * 0.25f;
					Color color = this.DamageText.color;
					color.a = this.DamageAlpha;
					this.DamageText.color = color;
				}
			}
			else
			{
				this.DamageScale += deltaTime * 25f;
				if (this.DamageScale >= 10f)
				{
					this.DamageScale = 10f;
					this.damageState = Damage.DamageState.Fadeout;
				}
				this.DamageTransform.localScale = new Vector3(this.DamageScale, this.DamageScale, this.DamageScale);
			}
			this.DamageTransform.position = new Vector3(this.DamageNPC.NPCPos.x + 1f, this.DamageNPC.NPCPos.y + this.DamageYoffset, 37f);
		}
	}

	// Token: 0x06000BAF RID: 2991 RVA: 0x0010E5D0 File Offset: 0x0010C7D0
	public void Release()
	{
		this.DamageGameObject = null;
		this.DamageTransform = null;
		this.DamageText = null;
		this.DamageNPC = null;
	}

	// Token: 0x06000BB0 RID: 2992 RVA: 0x0010E5F0 File Offset: 0x0010C7F0
	public void updateDamage(NPC npc)
	{
		this.DamageNPC = npc;
	}

	// Token: 0x06000BB1 RID: 2993 RVA: 0x0010E5FC File Offset: 0x0010C7FC
	public void updateDamage(float DamageValue)
	{
		this.DamageString.ClearString();
		this.DamageString.FloatToFormat(DamageValue, 2, true);
		if (GUIManager.Instance.IsArabic)
		{
			this.DamageString.AppendFormat("%{0}-");
		}
		else
		{
			this.DamageString.AppendFormat("-{0}%");
		}
		this.DamageText.text = this.DamageString.ToString();
		this.DamageScale = 0f;
		this.DamageTransform.localScale = new Vector3(this.DamageScale, this.DamageScale, this.DamageScale);
		this.damageState = Damage.DamageState.Scale;
		this.DamageAlpha = 1f;
		Color color = this.DamageText.color;
		color.a = this.DamageAlpha;
		this.DamageText.color = color;
		this.DamageYoffset = 0f;
	}

	// Token: 0x06000BB2 RID: 2994 RVA: 0x0010E6DC File Offset: 0x0010C8DC
	public void SetActive(bool active)
	{
		if (!active)
		{
			this.DamageNPC = null;
			this.damageState = Damage.DamageState.None;
		}
		this.DamageGameObject.SetActive(active);
	}

	// Token: 0x04002742 RID: 10050
	private Damage.DamageState damageState;

	// Token: 0x04002743 RID: 10051
	private GameObject DamageGameObject;

	// Token: 0x04002744 RID: 10052
	private Transform DamageTransform;

	// Token: 0x04002745 RID: 10053
	private TextMesh DamageText;

	// Token: 0x04002746 RID: 10054
	private CString DamageString;

	// Token: 0x04002747 RID: 10055
	private NPC DamageNPC;

	// Token: 0x04002748 RID: 10056
	private float DamageScale;

	// Token: 0x04002749 RID: 10057
	private float DamageAlpha;

	// Token: 0x0400274A RID: 10058
	private float DamageYoffset;

	// Token: 0x02000271 RID: 625
	private enum DamageState : byte
	{
		// Token: 0x0400274C RID: 10060
		None,
		// Token: 0x0400274D RID: 10061
		Scale,
		// Token: 0x0400274E RID: 10062
		Fadeout
	}
}
