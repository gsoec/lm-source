using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000490 RID: 1168
internal class LvUpAnimation
{
	// Token: 0x060017B7 RID: 6071 RVA: 0x00286788 File Offset: 0x00284988
	public void Init(Image expImg, UIText expText)
	{
		this.EXP_IMG_POS[0] = new KeyValuePair<float, Vector2>(0f, new Vector2(0f, -30f));
		this.EXP_IMG_POS[1] = new KeyValuePair<float, Vector2>(0.5f, new Vector2(0f, 0f));
		this.EXP_IMG_POS[2] = new KeyValuePair<float, Vector2>(1f, new Vector2(0f, 30f));
		this.EXP_IMG_ALPHA[0] = new KeyValuePair<float, float>(0f, 0f);
		this.EXP_IMG_ALPHA[1] = new KeyValuePair<float, float>(0.5f, 1f);
		this.EXP_IMG_ALPHA[2] = new KeyValuePair<float, float>(1f, 0f);
		this.TEXT_IMG_POS[0] = new KeyValuePair<float, Vector2>(0f, new Vector2(0f, -30f));
		this.TEXT_IMG_POS[1] = new KeyValuePair<float, Vector2>(1f, new Vector2(0f, 30f));
		this.TEXT_IMG_ALPHA[0] = new KeyValuePair<float, float>(0f, 1f);
		this.TEXT_IMG_ALPHA[1] = new KeyValuePair<float, float>(1f, 1f);
		this.m_ChangeTime[0] = 0f;
		this.m_ChangeTime[1] = 0f;
		this.m_ChangeTime[1] = 0f;
		this.m_SetChage[0] = false;
		this.m_SetChage[1] = false;
		this.m_SetChage[2] = true;
		this.Set(expImg, expText, null);
	}

	// Token: 0x060017B8 RID: 6072 RVA: 0x00286954 File Offset: 0x00284B54
	public void Init(Image expImg, UIText expText, Image icon)
	{
		this.ICON_IMG_ROTATION[0] = new KeyValuePair<float, float>(0f, 0f);
		this.ICON_IMG_ROTATION[1] = new KeyValuePair<float, float>(0.5f, 180f);
		this.EXP_IMG_POS[0] = new KeyValuePair<float, Vector2>(0.5f, new Vector2(0f, -30f));
		this.EXP_IMG_POS[1] = new KeyValuePair<float, Vector2>(0.75f, new Vector2(0f, 0f));
		this.EXP_IMG_POS[2] = new KeyValuePair<float, Vector2>(1.5f, new Vector2(0f, 30f));
		this.EXP_IMG_ALPHA[0] = new KeyValuePair<float, float>(0.5f, 0f);
		this.EXP_IMG_ALPHA[1] = new KeyValuePair<float, float>(0.75f, 1f);
		this.EXP_IMG_ALPHA[2] = new KeyValuePair<float, float>(1.5f, 0f);
		this.TEXT_IMG_POS[0] = new KeyValuePair<float, Vector2>(0.5f, new Vector2(0f, -30f));
		this.TEXT_IMG_POS[1] = new KeyValuePair<float, Vector2>(1.5f, new Vector2(0f, 30f));
		this.TEXT_IMG_ALPHA[0] = new KeyValuePair<float, float>(0.5f, 1f);
		this.TEXT_IMG_ALPHA[1] = new KeyValuePair<float, float>(1f, 1f);
		this.ICON_IMG_ROTATION2[0] = new KeyValuePair<float, float>(1.5f, 180f);
		this.ICON_IMG_ROTATION2[1] = new KeyValuePair<float, float>(2.5f, 0f);
		Image component = icon.transform.GetChild(0).gameObject.GetComponent<Image>();
		component.sprite = GUIManager.Instance.LoadFrameSprite("sk");
		component.material = GUIManager.Instance.GetFrameMaterial();
		this.m_ChangeTime[0] = 0.25f;
		this.m_ChangeTime[1] = 1.75f;
		this.m_ChangeTime[2] = 0.5f;
		this.m_SetChage[0] = true;
		this.m_SetChage[1] = true;
		this.m_SetChage[1] = true;
		this.m_SkillID = 1;
		this.Set(expImg, expText, icon);
	}

	// Token: 0x060017B9 RID: 6073 RVA: 0x00286BE4 File Offset: 0x00284DE4
	private void Set(Image expImg, UIText expText, Image icon = null)
	{
		this.m_ExpImg = expImg;
		this.m_ExpText = expText;
		this.m_Icon = icon;
		this.End();
	}

	// Token: 0x060017BA RID: 6074 RVA: 0x00286C04 File Offset: 0x00284E04
	public void Run()
	{
		if (this.m_State == LvUpAnimation.EAnimState.eStart)
		{
			this.m_AnimationTime += Time.deltaTime;
			this.RunLvImg(this.m_AnimationTime);
			this.RunExpText(this.m_AnimationTime);
			this.RunRotation1(this.m_AnimationTime);
			this.RunRotation2(this.m_AnimationTime);
			if (this.m_AnimationTime > this.m_TotalTime)
			{
				this.End();
			}
			if (this.m_SetChage[0] && this.m_AnimationTime >= this.m_ChangeTime[0])
			{
				this.Change(this.m_SkillID);
				this.m_SetChage[0] = false;
			}
			if (this.m_SetChage[1] && this.m_AnimationTime >= this.m_ChangeTime[1])
			{
				this.Change(0);
				this.m_SetChage[1] = false;
			}
			if (this.m_SetChage[2] && this.m_AnimationTime >= this.m_ChangeTime[2])
			{
				if (this.m_ExpText != null)
				{
					this.m_ExpText.enabled = true;
				}
				this.m_SetChage[2] = false;
			}
		}
	}

	// Token: 0x060017BB RID: 6075 RVA: 0x00286D20 File Offset: 0x00284F20
	public void RunLvImg(float animationTime)
	{
		if (this.m_ExpImg != null)
		{
			for (int i = 0; i < this.EXP_IMG_POS.Length - 1; i++)
			{
				float num = this.EXP_IMG_POS[i + 1].Key - this.EXP_IMG_POS[i].Key;
				if (num > 0f)
				{
					float t = (animationTime - this.EXP_IMG_POS[i].Key) / num;
					if (this.m_AnimationTime > this.EXP_IMG_POS[i].Key && this.m_AnimationTime <= this.EXP_IMG_POS[i + 1].Key)
					{
						this.m_ExpImg.rectTransform.anchoredPosition = Vector2.Lerp(this.EXP_IMG_POS[i].Value, this.EXP_IMG_POS[i + 1].Value, t);
					}
				}
			}
			for (int j = 0; j < this.EXP_IMG_ALPHA.Length - 1; j++)
			{
				float num = this.EXP_IMG_POS[j + 1].Key - this.EXP_IMG_POS[j].Key;
				if (num > 0f)
				{
					float t = (animationTime - this.EXP_IMG_ALPHA[j].Key) / num;
					if (this.m_AnimationTime > this.EXP_IMG_ALPHA[j].Key && this.m_AnimationTime <= this.EXP_IMG_ALPHA[j + 1].Key)
					{
						Color color = this.m_ExpImg.color;
						color.a = Mathf.Lerp(this.EXP_IMG_ALPHA[j].Value, this.EXP_IMG_ALPHA[j + 1].Value, t);
						this.m_ExpImg.color = color;
					}
				}
			}
		}
	}

	// Token: 0x060017BC RID: 6076 RVA: 0x00286F0C File Offset: 0x0028510C
	public void RunExpText(float animationTime)
	{
		if (this.m_ExpText != null)
		{
			Color color = this.m_ExpText.color;
			for (int i = 0; i < this.TEXT_IMG_POS.Length - 1; i++)
			{
				float num = this.TEXT_IMG_POS[i + 1].Key - this.TEXT_IMG_POS[i].Key;
				if (num > 0f)
				{
					float t = (animationTime - this.TEXT_IMG_POS[i].Key) / num;
					if (this.m_AnimationTime > this.TEXT_IMG_POS[i].Key && this.m_AnimationTime <= this.TEXT_IMG_POS[i + 1].Key)
					{
						this.m_ExpText.rectTransform.anchoredPosition = Vector2.Lerp(this.TEXT_IMG_POS[i].Value, this.TEXT_IMG_POS[i + 1].Value, t);
					}
				}
			}
			for (int j = 0; j < this.TEXT_IMG_ALPHA.Length - 1; j++)
			{
				float num = this.TEXT_IMG_ALPHA[j + 1].Key - this.TEXT_IMG_ALPHA[j].Key;
				if (num > 0f)
				{
					float t = (animationTime - this.TEXT_IMG_POS[j].Key) / num;
					if (this.m_AnimationTime > this.TEXT_IMG_POS[j].Key && this.m_AnimationTime <= this.TEXT_IMG_ALPHA[j + 1].Key)
					{
						color = this.m_ExpText.color;
						color.a = Mathf.Lerp(this.TEXT_IMG_ALPHA[j].Value, this.TEXT_IMG_ALPHA[j + 1].Value, t);
						this.m_ExpText.color = color;
					}
				}
			}
		}
	}

	// Token: 0x060017BD RID: 6077 RVA: 0x00287104 File Offset: 0x00285304
	private void RunRotation1(float animationTime)
	{
		if (this.m_Icon != null)
		{
			for (int i = 0; i < this.ICON_IMG_ROTATION.Length - 1; i++)
			{
				float num = this.ICON_IMG_ROTATION[i + 1].Key - this.ICON_IMG_ROTATION[i].Key;
				if (num > 0f)
				{
					float t = (animationTime - this.ICON_IMG_ROTATION[i].Key) / num;
					if (this.m_AnimationTime > this.ICON_IMG_ROTATION[i].Key && this.m_AnimationTime <= this.ICON_IMG_ROTATION[i + 1].Key)
					{
						float y = Mathf.Lerp(this.ICON_IMG_ROTATION[i].Value, this.ICON_IMG_ROTATION[i + 1].Value, t);
						this.m_Icon.transform.localRotation = Quaternion.Euler(new Vector3(0f, y, 0f));
					}
				}
			}
		}
	}

	// Token: 0x060017BE RID: 6078 RVA: 0x00287214 File Offset: 0x00285414
	private void RunRotation2(float animationTime)
	{
		if (this.m_Icon != null)
		{
			for (int i = 0; i < this.ICON_IMG_ROTATION2.Length - 1; i++)
			{
				float num = this.ICON_IMG_ROTATION2[i + 1].Key - this.ICON_IMG_ROTATION2[i].Key;
				if (num > 0f)
				{
					float t = (animationTime - this.ICON_IMG_ROTATION2[i].Key) / num;
					if (animationTime > this.ICON_IMG_ROTATION2[i].Key && animationTime <= this.ICON_IMG_ROTATION2[i + 1].Key)
					{
						float y = Mathf.Lerp(this.ICON_IMG_ROTATION2[i].Value, this.ICON_IMG_ROTATION2[i + 1].Value, t);
						this.m_Icon.transform.localRotation = Quaternion.Euler(new Vector3(0f, y, 0f));
					}
				}
			}
		}
	}

	// Token: 0x060017BF RID: 6079 RVA: 0x0028731C File Offset: 0x0028551C
	private void Change(ushort skillID)
	{
		if (this.m_Icon != null)
		{
			this.m_Icon.sprite = PetManager.Instance.LoadPetSkillIcon(skillID);
			this.m_Icon.material = GUIManager.Instance.GetSkillMaterial();
		}
	}

	// Token: 0x060017C0 RID: 6080 RVA: 0x00287368 File Offset: 0x00285568
	public void Start(CString str, uint exp, ushort skillID)
	{
		this.m_State = LvUpAnimation.EAnimState.eStart;
		this.m_AnimationTime = 0f;
		this.m_SetChage[0] = true;
		this.m_SetChage[1] = true;
		this.m_SetChage[2] = true;
		if (this.m_ExpImg != null && !this.m_ExpImg.gameObject.activeInHierarchy)
		{
			this.m_ExpImg.gameObject.SetActive(true);
			this.m_ExpText.enabled = false;
		}
		if (this.m_ExpText != null && !this.m_ExpText.gameObject.activeInHierarchy)
		{
			this.m_ExpText.gameObject.SetActive(true);
		}
		if (this.m_ExpText != null && this.m_ExpText != null)
		{
			str.ClearString();
			str.IntToFormat((long)((ulong)exp), 1, true);
			str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(55u));
			this.m_ExpText.text = str.ToString();
		}
		this.m_SkillID = skillID;
		AudioManager.Instance.PlayUISFX(UIKind.PetAddExp);
	}

	// Token: 0x060017C1 RID: 6081 RVA: 0x00287490 File Offset: 0x00285690
	public void End()
	{
		this.m_State = LvUpAnimation.EAnimState.eEnd;
		this.m_AnimationTime = this.m_TotalTime;
		if (this.m_Icon != null)
		{
			this.m_Icon.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
		}
		this.Change(0);
		if (this.m_ExpImg != null && this.m_ExpImg.gameObject.activeSelf)
		{
			this.m_ExpImg.gameObject.SetActive(false);
		}
		if (this.m_ExpText != null && this.m_ExpText.gameObject.activeSelf)
		{
			this.m_ExpText.gameObject.SetActive(false);
		}
	}

	// Token: 0x04004677 RID: 18039
	private const int MAX_STEP = 3;

	// Token: 0x04004678 RID: 18040
	private KeyValuePair<float, float>[] ICON_IMG_ROTATION = new KeyValuePair<float, float>[3];

	// Token: 0x04004679 RID: 18041
	private KeyValuePair<float, float>[] ICON_IMG_ROTATION2 = new KeyValuePair<float, float>[3];

	// Token: 0x0400467A RID: 18042
	private KeyValuePair<float, Vector2>[] EXP_IMG_POS = new KeyValuePair<float, Vector2>[3];

	// Token: 0x0400467B RID: 18043
	private KeyValuePair<float, float>[] EXP_IMG_ALPHA = new KeyValuePair<float, float>[3];

	// Token: 0x0400467C RID: 18044
	private KeyValuePair<float, Vector2>[] TEXT_IMG_POS = new KeyValuePair<float, Vector2>[3];

	// Token: 0x0400467D RID: 18045
	private KeyValuePair<float, float>[] TEXT_IMG_ALPHA = new KeyValuePair<float, float>[4];

	// Token: 0x0400467E RID: 18046
	private float m_AnimationTime;

	// Token: 0x0400467F RID: 18047
	private float m_TotalTime = 3f;

	// Token: 0x04004680 RID: 18048
	private float[] m_ChangeTime = new float[3];

	// Token: 0x04004681 RID: 18049
	private bool[] m_SetChage = new bool[3];

	// Token: 0x04004682 RID: 18050
	private Image m_ExpImg;

	// Token: 0x04004683 RID: 18051
	private UIText m_ExpText;

	// Token: 0x04004684 RID: 18052
	private Image m_Icon;

	// Token: 0x04004685 RID: 18053
	private LvUpAnimation.EAnimState m_State;

	// Token: 0x04004686 RID: 18054
	private ushort m_SkillID;

	// Token: 0x02000491 RID: 1169
	private enum EAnimState
	{
		// Token: 0x04004688 RID: 18056
		eStart,
		// Token: 0x04004689 RID: 18057
		eChange1,
		// Token: 0x0400468A RID: 18058
		eChange2,
		// Token: 0x0400468B RID: 18059
		eEnd
	}
}
