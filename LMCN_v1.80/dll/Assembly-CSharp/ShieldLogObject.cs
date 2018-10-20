using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004A7 RID: 1191
internal class ShieldLogObject
{
	// Token: 0x0600183D RID: 6205 RVA: 0x0028CC20 File Offset: 0x0028AE20
	public ShieldLogObject()
	{
		this.NomalColor = new Color(1f, 1f, 1f, 1f);
		this.MarkColor = new Color(0.0313f, 0.9568f, 0.2901f, 1f);
		this.Name = null;
		this.Begin = null;
		this.End = null;
		this.CStr = new CString[2];
		this.EnableColor = false;
		for (int i = 0; i < 2; i++)
		{
			if (this.CStr[i] == null)
			{
				this.CStr[i] = StringManager.Instance.SpawnString(30);
			}
		}
	}

	// Token: 0x0600183E RID: 6206 RVA: 0x0028CCCC File Offset: 0x0028AECC
	public void Setup(UIText name, UIText begin, UIText end, Transform trans)
	{
		this.Name = name;
		this.Begin = begin;
		this.End = end;
		this.Trans = trans;
		this.Name.font = GUIManager.Instance.GetTTFFont();
		this.Begin.font = GUIManager.Instance.GetTTFFont();
		this.End.font = GUIManager.Instance.GetTTFFont();
	}

	// Token: 0x0600183F RID: 6207 RVA: 0x0028CD38 File Offset: 0x0028AF38
	public void SetEnableColor(bool enable)
	{
		this.EnableColor = enable;
	}

	// Token: 0x06001840 RID: 6208 RVA: 0x0028CD44 File Offset: 0x0028AF44
	public void SetName(ushort itemID)
	{
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(itemID);
		this.Name.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.EquipName);
		this.Name.SetAllDirty();
		this.Name.cachedTextGenerator.Invalidate();
		this.Name.color = ((!this.EnableColor) ? this.NomalColor : this.MarkColor);
	}

	// Token: 0x06001841 RID: 6209 RVA: 0x0028CDC8 File Offset: 0x0028AFC8
	public void SetBeginTime(long time)
	{
		DateTime dateTime = GameConstants.GetDateTime(time);
		this.Begin.text = dateTime.ToLocalTime().ToString("MM/dd/yy HH:mm:ss");
		this.Begin.SetAllDirty();
		this.Begin.cachedTextGenerator.Invalidate();
		this.Begin.color = ((!this.EnableColor) ? this.NomalColor : this.MarkColor);
	}

	// Token: 0x06001842 RID: 6210 RVA: 0x0028CE40 File Offset: 0x0028B040
	public void SetEndTime(long time)
	{
		DateTime dateTime = GameConstants.GetDateTime(time);
		this.CStr[1].ClearString();
		if (this.EnableColor)
		{
			this.CStr[1].Append(DataManager.Instance.mStringTable.GetStringByID(11263u));
			this.CStr[1].Append(" ");
		}
		this.CStr[1].Append(dateTime.ToString("MM/dd/yy HH:mm:ss"));
		this.End.text = this.CStr[1].ToString();
		this.End.SetAllDirty();
		this.End.cachedTextGenerator.Invalidate();
		this.End.color = ((!this.EnableColor) ? this.NomalColor : this.MarkColor);
	}

	// Token: 0x06001843 RID: 6211 RVA: 0x0028CF14 File Offset: 0x0028B114
	public void SetEmpty()
	{
		this.EnableColor = false;
		this.Name.text = string.Empty;
		this.Begin.text = string.Empty;
		this.End.text = string.Empty;
		this.Name.SetAllDirty();
		this.Begin.SetAllDirty();
		this.End.SetAllDirty();
		this.Name.cachedTextGenerator.Invalidate();
		this.Begin.cachedTextGenerator.Invalidate();
		this.End.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001844 RID: 6212 RVA: 0x0028CFAC File Offset: 0x0028B1AC
	public void Show()
	{
		this.Trans.gameObject.SetActive(true);
	}

	// Token: 0x06001845 RID: 6213 RVA: 0x0028CFC0 File Offset: 0x0028B1C0
	public void Hide()
	{
		this.Trans.gameObject.SetActive(false);
	}

	// Token: 0x06001846 RID: 6214 RVA: 0x0028CFD4 File Offset: 0x0028B1D4
	public void Refresh_FontTexture()
	{
		if (this.Name != null && this.Name.enabled)
		{
			this.Name.enabled = false;
			this.Name.enabled = true;
		}
		if (this.Begin != null && this.Begin.enabled)
		{
			this.Begin.enabled = false;
			this.Begin.enabled = true;
		}
		if (this.End != null && this.End.enabled)
		{
			this.End.enabled = false;
			this.End.enabled = true;
		}
	}

	// Token: 0x06001847 RID: 6215 RVA: 0x0028D08C File Offset: 0x0028B28C
	public void DeSpawnString()
	{
		for (int i = 0; i < this.CStr.Length; i++)
		{
			if (this.CStr != null && this.CStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.CStr[i]);
				this.CStr[i] = null;
			}
		}
	}

	// Token: 0x0400473F RID: 18239
	private Color NomalColor;

	// Token: 0x04004740 RID: 18240
	private Color MarkColor;

	// Token: 0x04004741 RID: 18241
	private Transform Trans;

	// Token: 0x04004742 RID: 18242
	private UIText Name;

	// Token: 0x04004743 RID: 18243
	private UIText Begin;

	// Token: 0x04004744 RID: 18244
	private UIText End;

	// Token: 0x04004745 RID: 18245
	private CString[] CStr;

	// Token: 0x04004746 RID: 18246
	private bool EnableColor;
}
