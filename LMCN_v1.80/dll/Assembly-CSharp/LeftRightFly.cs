using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006E0 RID: 1760
public class LeftRightFly
{
	// Token: 0x060021A5 RID: 8613 RVA: 0x00401C34 File Offset: 0x003FFE34
	private LeftRightFly()
	{
		this.mFlyStage = LeftRightFly.FlyStage.Idle;
	}

	// Token: 0x170000C1 RID: 193
	// (get) Token: 0x060021A7 RID: 8615 RVA: 0x00401D60 File Offset: 0x003FFF60
	public static LeftRightFly Instance
	{
		get
		{
			if (LeftRightFly._instance == null)
			{
				LeftRightFly._instance = new LeftRightFly();
			}
			return LeftRightFly._instance;
		}
	}

	// Token: 0x060021A8 RID: 8616 RVA: 0x00401D7C File Offset: 0x003FFF7C
	public void init()
	{
		if (this.initialed)
		{
			return;
		}
		this.Base = new GameObject("LeftRightFly");
		this.Base.layer = 5;
		RectTransform rectTransform = this.Base.AddComponent<RectTransform>();
		rectTransform.SetParent(GUIManager.Instance.m_TopLayer, false);
		RectTransform rectTransform2 = rectTransform;
		Vector2 zero = Vector2.zero;
		rectTransform.anchorMin = zero;
		rectTransform2.sizeDelta = zero;
		rectTransform.anchorMax = Vector2.one;
		this.m_bg = GUIManager.Instance.AddSpriteAsset(this.BGNameStr);
		GameObject gameObject = new GameObject("TransBg");
		gameObject.transform.SetParent(this.Base.transform, false);
		RectTransform rectTransform3 = gameObject.AddComponent<RectTransform>();
		this.BGImage = gameObject.AddComponent<Image>();
		this.BGImage.material = this.m_bg;
		this.BGImage.sprite = GUIManager.Instance.LoadSprite(this.BGNameStr, "black_gogo_b");
		this.BGImage.type = Image.Type.Sliced;
		this.BGImage.color = new Color32(byte.MaxValue, byte.MaxValue, 225, 182);
		rectTransform3.localPosition = new Vector3(0f, 0f, 0f);
		rectTransform3.anchoredPosition = new Vector2(0f, -46f);
		rectTransform3.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0f);
		rectTransform3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 210f);
		rectTransform3.anchorMin = new Vector2(1f, 0.5f);
		rectTransform3.anchorMax = new Vector2(1f, 0.5f);
		this.BGUnit = rectTransform3;
		gameObject = new GameObject("TextBase");
		gameObject.transform.SetParent(this.Base.transform, false);
		rectTransform3 = gameObject.AddComponent<RectTransform>();
		this.TextBaseUnit = rectTransform3;
		this.TextBaseUnit.anchoredPosition = new Vector2(this.FlyInTextStartRight, -46f);
		gameObject = new GameObject("Text1");
		gameObject.transform.SetParent(this.TextBaseUnit.transform, false);
		rectTransform3 = gameObject.AddComponent<RectTransform>();
		rectTransform3.anchoredPosition = new Vector2(0f, 65f);
		rectTransform3.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 500f);
		rectTransform3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 120f);
		UIText uitext = gameObject.AddComponent<UIText>();
		uitext.font = GUIManager.Instance.GetTTFFont();
		uitext.resizeTextForBestFit = true;
		uitext.resizeTextMinSize = 24;
		uitext.resizeTextMaxSize = 55;
		uitext.alignment = TextAnchor.LowerCenter;
		uitext.text = string.Empty;
		this.Text1 = uitext;
		this.ol1 = gameObject.AddComponent<Outline>();
		this.sha1 = gameObject.AddComponent<Shadow>();
		gameObject = new GameObject("Text2");
		gameObject.transform.SetParent(this.TextBaseUnit.transform, false);
		rectTransform3 = gameObject.AddComponent<RectTransform>();
		rectTransform3.anchoredPosition = new Vector2(0f, -65f);
		rectTransform3.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 500f);
		rectTransform3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 120f);
		uitext = gameObject.AddComponent<UIText>();
		uitext.font = GUIManager.Instance.GetTTFFont();
		uitext.resizeTextForBestFit = true;
		uitext.resizeTextMinSize = 24;
		uitext.resizeTextMaxSize = 60;
		uitext.alignment = TextAnchor.UpperCenter;
		uitext.text = string.Empty;
		this.Text2 = uitext;
		this.ol2 = gameObject.AddComponent<Outline>();
		this.sha2 = gameObject.AddComponent<Shadow>();
		gameObject = new GameObject("Text3");
		gameObject.transform.SetParent(this.TextBaseUnit.transform, false);
		rectTransform3 = gameObject.AddComponent<RectTransform>();
		rectTransform3.anchoredPosition = new Vector2(0f, 0f);
		rectTransform3.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 800f);
		rectTransform3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 200f);
		uitext = gameObject.AddComponent<UIText>();
		uitext.font = GUIManager.Instance.GetTTFFont();
		uitext.resizeTextForBestFit = true;
		uitext.resizeTextMinSize = 24;
		uitext.resizeTextMaxSize = 120;
		uitext.alignment = TextAnchor.MiddleCenter;
		uitext.text = DataManager.Instance.mStringTable.GetStringByID(17508u);
		this.Text3 = uitext;
		Outline outline = gameObject.AddComponent<Outline>();
		Shadow shadow = gameObject.AddComponent<Shadow>();
		uitext.color = this.winingColorSet[0];
		outline.effectColor = this.winingColorSet[1];
		shadow.effectColor = this.winingColorSet[2];
		gameObject = new GameObject("Text4");
		gameObject.transform.SetParent(this.Base.transform, false);
		rectTransform3 = gameObject.AddComponent<RectTransform>();
		rectTransform3.anchoredPosition = new Vector2(0f, -155f);
		rectTransform3.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 800f);
		rectTransform3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 240f);
		uitext = gameObject.AddComponent<UIText>();
		uitext.font = GUIManager.Instance.GetTTFFont();
		uitext.resizeTextForBestFit = true;
		uitext.resizeTextMinSize = 24;
		uitext.resizeTextMaxSize = 120;
		uitext.alignment = TextAnchor.MiddleCenter;
		gameObject.SetActive(false);
		uitext.text = string.Empty;
		this.Text4 = uitext;
		outline = gameObject.AddComponent<Outline>();
		shadow = gameObject.AddComponent<Shadow>();
		uitext.color = this.winingColorSet[0];
		outline.effectColor = this.winingColorSet[1];
		shadow.effectColor = this.winingColorSet[2];
		this.initialed = true;
	}

	// Token: 0x060021A9 RID: 8617 RVA: 0x004022F4 File Offset: 0x004004F4
	public void Update(bool addtime = true)
	{
		if (!this.initialed)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		if (addtime)
		{
			this.currentTime += deltaTime;
		}
		switch (this.mFlyStage)
		{
		case LeftRightFly.FlyStage.Flyin:
		{
			float num = this.currentTime / 0.3f;
			num = Mathf.Clamp01(num);
			if (this.FromRight)
			{
				float num2 = DamageValueManager.easeInCubic(1f, 0f, num);
				this.BGUnit.anchorMin = new Vector2(num2, 0.5f);
				num2 = DamageValueManager.easeInCubic(this.FlyInTextStartRight, 0f, num);
				this.TextBaseUnit.anchoredPosition = new Vector2(num2, -46f);
			}
			else
			{
				float num2 = DamageValueManager.easeInCubic(0f, 1f, num);
				this.BGUnit.anchorMax = new Vector2(num2, 0.5f);
				num2 = DamageValueManager.easeInCubic(this.FlyInTextStartLeft, 0f, num);
				this.TextBaseUnit.anchoredPosition = new Vector2(num2, -46f);
			}
			if (this.currentTime > 0.3f)
			{
				this.mFlyStage = LeftRightFly.FlyStage.Waiting;
				this.currentTime = 0f;
			}
			break;
		}
		case LeftRightFly.FlyStage.Waiting:
			if (this.currentTime > 1f)
			{
				if (this.isWinning)
				{
					this.mFlyStage = LeftRightFly.FlyStage.Flyout;
				}
				else
				{
					this.mFlyStage = LeftRightFly.FlyStage.FallOut;
				}
				this.currentTime = 0f;
			}
			break;
		case LeftRightFly.FlyStage.Flyout:
		{
			float num = this.currentTime / 0.5f;
			num = Mathf.Clamp01(num);
			if (this.FromRight)
			{
				float num2 = DamageValueManager.easeInCubic(0f, 1f, num);
				this.BGUnit.anchorMin = new Vector2(num2, 0.5f);
				num2 = DamageValueManager.easeInCubic(0f, this.FlyInTextStartRight, num);
				this.TextBaseUnit.anchoredPosition = new Vector2(num2, -46f);
			}
			else
			{
				float num2 = DamageValueManager.easeInCubic(1f, 0f, num);
				this.BGUnit.anchorMax = new Vector2(num2, 0.5f);
				num2 = DamageValueManager.easeInExpo(0f, this.FlyInTextStartLeft, num);
				this.TextBaseUnit.anchoredPosition = new Vector2(num2, -46f);
			}
			if (this.currentTime > 0.5f)
			{
				this.mFlyStage = LeftRightFly.FlyStage.End;
				this.currentTime = 0f;
			}
			break;
		}
		case LeftRightFly.FlyStage.FallOut:
		{
			float num = this.currentTime / 0.4f;
			num = (1f - Mathf.Clamp01(num)) * 255f;
			float num2 = DamageValueManager.easeInBack2(this.currentTime, 0f, 1f, 0.4f);
			this.TextBaseUnit.anchoredPosition = new Vector2(0f, -46f - this.FallOutDist * num2);
			Color32 c = new Color32(this.losingColorSet[0].r, this.losingColorSet[0].g, this.losingColorSet[0].b, (byte)num);
			this.Text1.color = c;
			this.Text2.color = c;
			c = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, (byte)(num * 0.7f));
			this.BGImage.color = c;
			if (this.currentTime > 0.4f)
			{
				this.mFlyStage = LeftRightFly.FlyStage.End;
				this.currentTime = 0f;
			}
			break;
		}
		case LeftRightFly.FlyStage.CountDown:
		{
			this.Text4.text = this.counting.ToString();
			float num;
			if (this.currentTime < 0.5f)
			{
				num = DamageValueManager.easeOutQuart(this.CountingSize, 1f, this.currentTime * 2f);
			}
			else
			{
				num = 1f;
			}
			if (GUIManager.Instance.IsArabic)
			{
				this.Text4.rectTransform.localScale = new Vector3(-1f, 1f, 1f) * num;
			}
			else
			{
				this.Text4.rectTransform.localScale = Vector3.one * num;
			}
			if (this.currentTime >= 1f)
			{
				this.counting--;
				this.currentTime = 0f;
				if (this.counting <= 0)
				{
					this.Text4.gameObject.SetActive(false);
					this.mFlyStage = LeftRightFly.FlyStage.Flyin;
					AudioManager.Instance.PlaySFX(40058, 0f, PitchKind.NoPitch, null, null);
				}
				else if (this.counting <= 3)
				{
					AudioManager.Instance.PlaySFX(40055, 0f, PitchKind.NoPitch, null, null);
				}
			}
			break;
		}
		case LeftRightFly.FlyStage.End:
			this.mFlyStage = LeftRightFly.FlyStage.Idle;
			this.setStartValue(true, LeftRightFly.TransferType.Win);
			this.OnAnimaFinish();
			break;
		case LeftRightFly.FlyStage.WaitCount:
			if (this.currentTime > 1f)
			{
				this.currentTime = 0f;
				this.Text4.gameObject.SetActive(true);
				this.mFlyStage = LeftRightFly.FlyStage.CountDown;
			}
			break;
		}
	}

	// Token: 0x060021AA RID: 8618 RVA: 0x00402820 File Offset: 0x00400A20
	public static void Release()
	{
		if (LeftRightFly._instance == null)
		{
			return;
		}
		LeftRightFly._instance.mFlyStage = LeftRightFly.FlyStage.Idle;
		UnityEngine.Object.Destroy(LeftRightFly._instance.Base);
		LeftRightFly._instance.Base = null;
		LeftRightFly._instance = null;
	}

	// Token: 0x060021AB RID: 8619 RVA: 0x00402864 File Offset: 0x00400A64
	public void SetMove(string Title, ushort SecendLine, bool fromRight, bool isWinning, float time = 0f, bool playSound = true)
	{
		if (!this.initialed)
		{
			return;
		}
		this.CutInStartTime = NetworkManager.ServerTime - (double)time;
		if (isWinning)
		{
			if (playSound)
			{
				AudioManager.Instance.PlayMP3SFX(BGMType.LegionVictory, false, 1f);
			}
			if (time > 1.8f)
			{
				this.mFlyStage = LeftRightFly.FlyStage.Idle;
				this.setStartValue(fromRight, LeftRightFly.TransferType.Win);
				return;
			}
		}
		else
		{
			if (playSound)
			{
				AudioManager.Instance.PlayMP3SFX(BGMType.LegionDefeat, false, 1f);
			}
			if (time > 1.69999993f)
			{
				this.mFlyStage = LeftRightFly.FlyStage.Idle;
				this.setStartValue(fromRight, LeftRightFly.TransferType.Win);
				return;
			}
		}
		this.currentTime = 0f;
		this.mFlyStage = LeftRightFly.FlyStage.Flyin;
		this.FromRight = fromRight;
		this.BattleStart = false;
		this.isWinning = isWinning;
		this.TextStr1 = Title;
		this.TextStr1 = string.Format(DataManager.Instance.mStringTable.GetStringByID(14620u), Title);
		this.Text1.text = this.TextStr1;
		if (isWinning)
		{
			this.Text2.text = DataManager.Instance.mStringTable.GetStringByID(14621u);
			this.setStartValue(fromRight, LeftRightFly.TransferType.Win);
		}
		else
		{
			this.Text2.text = DataManager.Instance.mStringTable.GetStringByID(14622u);
			this.setStartValue(fromRight, LeftRightFly.TransferType.Lose);
		}
		this.currentTime = time;
		this.Update(false);
		if (time > 0.3f)
		{
			this.currentTime = time - 0.3f;
			this.Update(false);
		}
		if (time > 1.3f)
		{
			this.currentTime = time - 0.3f - 1f;
			this.Update(false);
		}
	}

	// Token: 0x060021AC RID: 8620 RVA: 0x00402A14 File Offset: 0x00400C14
	public void SetCountDown(float time = 0f)
	{
		if (!this.initialed)
		{
			return;
		}
		if (time >= 11.8f)
		{
			this.mFlyStage = LeftRightFly.FlyStage.Idle;
			this.setStartValue(this.FromRight, LeftRightFly.TransferType.BattleStart);
			return;
		}
		this.counting = 10;
		this.currentTime = 0f;
		this.mFlyStage = LeftRightFly.FlyStage.CountDown;
		this.FromRight = true;
		this.isWinning = true;
		this.BattleStart = true;
		this.setStartValue(this.FromRight, LeftRightFly.TransferType.BattleStart);
		this.Text3.gameObject.SetActive(true);
		this.Text4.gameObject.SetActive(true);
		this.Text3.text = DataManager.Instance.mStringTable.GetStringByID(17508u);
		if (GUIManager.Instance.IsArabic)
		{
			this.Text4.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		else
		{
			this.Text4.rectTransform.localScale = Vector3.one;
		}
		ActivityManager.Instance.SetActivityWindowTimeVisible(false);
		this.CutInStartTime = NetworkManager.ServerTime - (double)time;
		if (time == 0f)
		{
			return;
		}
		if (time < 10f)
		{
			this.mFlyStage = LeftRightFly.FlyStage.CountDown;
			this.counting = Mathf.CeilToInt(10f - time);
			this.currentTime = time % 1f;
			this.Text4.gameObject.SetActive(true);
			this.Update(false);
		}
		else if (time < 11.8f)
		{
			float num = time - 10f;
			this.Text4.gameObject.SetActive(false);
			this.mFlyStage = LeftRightFly.FlyStage.Flyin;
			this.currentTime = num;
			this.Update(false);
			if (num > 0.3f)
			{
				this.currentTime = num - 0.3f;
				this.Update(false);
			}
			if (num > 1.3f)
			{
				this.currentTime = num - 0.3f - 1f;
				this.Update(false);
			}
		}
		if (time == 10f)
		{
			AudioManager.Instance.PlaySFX(40058, 0f, PitchKind.NoPitch, null, null);
		}
	}

	// Token: 0x060021AD RID: 8621 RVA: 0x00402C38 File Offset: 0x00400E38
	public void setStartValue(bool fromRight, LeftRightFly.TransferType type)
	{
		if (!this.initialed)
		{
			return;
		}
		if (fromRight)
		{
			this.BGUnit.anchorMin = new Vector2(1f, 0.5f);
			this.BGUnit.anchorMax = new Vector2(1f, 0.5f);
			this.TextBaseUnit.anchoredPosition = new Vector2(this.FlyInTextStartRight, -46f);
		}
		else
		{
			this.BGUnit.anchorMin = new Vector2(0f, 0.5f);
			this.BGUnit.anchorMax = new Vector2(0f, 0.5f);
			this.TextBaseUnit.anchoredPosition = new Vector2(this.FlyInTextStartLeft, -46f);
		}
		if (type == LeftRightFly.TransferType.BattleStart)
		{
			this.Text1.gameObject.SetActive(false);
			this.Text2.gameObject.SetActive(false);
			this.Text3.gameObject.SetActive(true);
			this.Text4.gameObject.SetActive(false);
		}
		else
		{
			this.Text1.gameObject.SetActive(true);
			this.Text2.gameObject.SetActive(true);
			this.Text3.gameObject.SetActive(false);
			this.Text4.gameObject.SetActive(false);
		}
		if (type != LeftRightFly.TransferType.Lose)
		{
			this.Text1.color = this.winingColorSet[0];
			this.Text2.color = this.winingColorSet[0];
			this.ol1.effectColor = this.winingColorSet[1];
			this.ol2.effectColor = this.winingColorSet[1];
			this.sha1.effectColor = this.winingColorSet[2];
			this.sha2.effectColor = this.winingColorSet[2];
		}
		else
		{
			this.Text1.color = this.losingColorSet[0];
			this.Text2.color = this.losingColorSet[0];
			this.ol1.effectColor = this.losingColorSet[1];
			this.ol2.effectColor = this.losingColorSet[1];
			this.sha1.effectColor = this.losingColorSet[2];
			this.sha2.effectColor = this.losingColorSet[2];
		}
		this.BGImage.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 182);
	}

	// Token: 0x060021AE RID: 8622 RVA: 0x00402F50 File Offset: 0x00401150
	public void Refresh_FontTexture()
	{
		if (this.Text1 != null && this.Text1.enabled)
		{
			this.Text1.enabled = false;
			this.Text1.enabled = true;
		}
		if (this.Text2 != null && this.Text2.enabled)
		{
			this.Text2.enabled = false;
			this.Text2.enabled = true;
		}
		if (this.Text3 != null && this.Text3.enabled)
		{
			this.Text3.enabled = false;
			this.Text3.enabled = true;
		}
		if (this.Text4 != null && this.Text4.enabled)
		{
			this.Text4.enabled = false;
			this.Text4.enabled = true;
		}
	}

	// Token: 0x060021AF RID: 8623 RVA: 0x00403044 File Offset: 0x00401244
	private void OnAnimaFinish()
	{
		ActivityManager.Instance.SetActivityWindowTimeVisible(true);
	}

	// Token: 0x060021B0 RID: 8624 RVA: 0x00403054 File Offset: 0x00401254
	public void SetEnable(bool enable)
	{
		if (this.Base != null)
		{
			this.Base.SetActive(enable);
		}
	}

	// Token: 0x060021B1 RID: 8625 RVA: 0x00403074 File Offset: 0x00401274
	public void UpdateCutinStat()
	{
		if (this.mFlyStage != LeftRightFly.FlyStage.Idle)
		{
			if (this.BattleStart)
			{
				this.SetCountDown((float)(NetworkManager.ServerTime - this.CutInStartTime));
			}
			else
			{
				this.SetMove(this.TextStr1, 0, this.FromRight, this.isWinning, (float)(NetworkManager.ServerTime - this.CutInStartTime), false);
			}
		}
	}

	// Token: 0x04006A3F RID: 27199
	private const int countDown = 10;

	// Token: 0x04006A40 RID: 27200
	private const float FlyInTime = 0.3f;

	// Token: 0x04006A41 RID: 27201
	private const float StayTime = 1f;

	// Token: 0x04006A42 RID: 27202
	private const float FlyOutTime = 0.5f;

	// Token: 0x04006A43 RID: 27203
	private const float FallOutTime = 0.4f;

	// Token: 0x04006A44 RID: 27204
	private const float WinFlyTime = 1.8f;

	// Token: 0x04006A45 RID: 27205
	private const float LoseFlyTime = 1.69999993f;

	// Token: 0x04006A46 RID: 27206
	public const float skipBegin = 10f;

	// Token: 0x04006A47 RID: 27207
	private float FlyInTextStartRight = -1000f;

	// Token: 0x04006A48 RID: 27208
	private float FlyInTextStartLeft = 1000f;

	// Token: 0x04006A49 RID: 27209
	private float FallOutDist = 330f;

	// Token: 0x04006A4A RID: 27210
	private float CountingSize = 4f;

	// Token: 0x04006A4B RID: 27211
	private bool initialed;

	// Token: 0x04006A4C RID: 27212
	private bool FromRight;

	// Token: 0x04006A4D RID: 27213
	private bool isWinning;

	// Token: 0x04006A4E RID: 27214
	private bool BattleStart;

	// Token: 0x04006A4F RID: 27215
	private LeftRightFly.FlyStage mFlyStage;

	// Token: 0x04006A50 RID: 27216
	private float currentTime;

	// Token: 0x04006A51 RID: 27217
	private int counting;

	// Token: 0x04006A52 RID: 27218
	private double CutInStartTime;

	// Token: 0x04006A53 RID: 27219
	private Material m_bg;

	// Token: 0x04006A54 RID: 27220
	private string BGNameStr = "Transitions1";

	// Token: 0x04006A55 RID: 27221
	private GameObject Base;

	// Token: 0x04006A56 RID: 27222
	private Image BGImage;

	// Token: 0x04006A57 RID: 27223
	private RectTransform BGUnit;

	// Token: 0x04006A58 RID: 27224
	private RectTransform TextBaseUnit;

	// Token: 0x04006A59 RID: 27225
	private UIText Text1;

	// Token: 0x04006A5A RID: 27226
	private UIText Text2;

	// Token: 0x04006A5B RID: 27227
	private UIText Text3;

	// Token: 0x04006A5C RID: 27228
	private UIText Text4;

	// Token: 0x04006A5D RID: 27229
	private Shadow sha1;

	// Token: 0x04006A5E RID: 27230
	private Shadow sha2;

	// Token: 0x04006A5F RID: 27231
	private Outline ol1;

	// Token: 0x04006A60 RID: 27232
	private Outline ol2;

	// Token: 0x04006A61 RID: 27233
	private string TextStr1;

	// Token: 0x04006A62 RID: 27234
	private string TextStr2;

	// Token: 0x04006A63 RID: 27235
	private Color32[] winingColorSet = new Color32[]
	{
		new Color32(253, 228, 111, byte.MaxValue),
		new Color32(byte.MaxValue, 114, 0, byte.MaxValue),
		new Color32(146, 0, 0, byte.MaxValue)
	};

	// Token: 0x04006A64 RID: 27236
	private Color32[] losingColorSet = new Color32[]
	{
		new Color32(0, 221, 151, byte.MaxValue),
		new Color32(0, 139, 179, byte.MaxValue),
		new Color32(0, 86, 135, byte.MaxValue)
	};

	// Token: 0x04006A65 RID: 27237
	public static LeftRightFly _instance;

	// Token: 0x020006E1 RID: 1761
	public enum TransferType
	{
		// Token: 0x04006A67 RID: 27239
		Win,
		// Token: 0x04006A68 RID: 27240
		Lose,
		// Token: 0x04006A69 RID: 27241
		BattleStart
	}

	// Token: 0x020006E2 RID: 1762
	public enum FlyStage
	{
		// Token: 0x04006A6B RID: 27243
		Idle,
		// Token: 0x04006A6C RID: 27244
		Flyin,
		// Token: 0x04006A6D RID: 27245
		Waiting,
		// Token: 0x04006A6E RID: 27246
		Flyout,
		// Token: 0x04006A6F RID: 27247
		FallOut,
		// Token: 0x04006A70 RID: 27248
		CountDown,
		// Token: 0x04006A71 RID: 27249
		End,
		// Token: 0x04006A72 RID: 27250
		WaitCount
	}
}
