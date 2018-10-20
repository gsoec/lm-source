using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002C0 RID: 704
public class UIName : GUIWindow, UILoadImageHander, IUIButtonClickHandler
{
	// Token: 0x06000E71 RID: 3697 RVA: 0x0017C5DC File Offset: 0x0017A7DC
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

	// Token: 0x06000E72 RID: 3698 RVA: 0x0017C640 File Offset: 0x0017A840
	private void ValueChange(string input)
	{
		if (input != string.Empty)
		{
			this.CheckTime = 1f;
			this.Tagging += 1;
		}
		this.Hint.Length = 0;
		this.m_character.text = this.Hint.AppendFormat(this.DM.mStringTable.GetStringByID(4614u), this.Limits - Encoding.UTF8.GetByteCount(input)).ToString();
	}

	// Token: 0x06000E73 RID: 3699 RVA: 0x0017C6CC File Offset: 0x0017A8CC
	public override void OnOpen(int arg1, int arg2)
	{
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			((RectTransform)base.transform).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)base.transform).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		this.Transformer = base.transform.GetChild(0);
		base.transform.gameObject.AddComponent<UIButton>().m_Handler = this;
		this.Transformer.GetChild(4).GetComponent<UIButton>().m_Handler = this;
		this.Transformer.GetChild(6).GetComponent<UIButton>().m_Handler = this;
		this.m_Name = this.Transformer.GetChild(4).GetChild(0).GetComponent<Text>();
		this.m_Name.text = this.DM.mStringTable.GetStringByID(4716u);
		this.m_Name.font = GUIManager.Instance.GetTTFFont();
		this.m_Nick = this.Transformer.GetChild(6).GetChild(0).GetComponent<Text>();
		this.m_Nick.text = this.DM.mStringTable.GetStringByID(9099u);
		this.m_Nick.font = GUIManager.Instance.GetTTFFont();
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
	}

	// Token: 0x06000E74 RID: 3700 RVA: 0x0017C844 File Offset: 0x0017AA44
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x06000E75 RID: 3701 RVA: 0x0017C874 File Offset: 0x0017AA74
	public void Refresh_FontTexture()
	{
		if (this.m_Name != null && this.m_Name.enabled)
		{
			this.m_Name.enabled = false;
			this.m_Name.enabled = true;
		}
		if (this.m_Nick != null && this.m_Nick.enabled)
		{
			this.m_Nick.enabled = false;
			this.m_Nick.enabled = true;
		}
	}

	// Token: 0x06000E76 RID: 3702 RVA: 0x0017C8F4 File Offset: 0x0017AAF4
	public void OnButtonClick(UIButton sender)
	{
		GUIManager.Instance.CloseMenu(this.m_eWindow);
		if (sender.m_BtnID1 == 21)
		{
			GUIManager.Instance.UseOrSpend(1006, this.DM.mStringTable.GetStringByID(4957u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
		}
		else if (sender.m_BtnID1 == 22)
		{
			GUIManager.Instance.UseOrSpend(1253, this.DM.mStringTable.GetStringByID(4957u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
		}
	}

	// Token: 0x04002E47 RID: 11847
	protected Door door;

	// Token: 0x04002E48 RID: 11848
	protected Text[] m_InputBoxText = new Text[3];

	// Token: 0x04002E49 RID: 11849
	protected Text m_Name;

	// Token: 0x04002E4A RID: 11850
	protected Text m_Nick;

	// Token: 0x04002E4B RID: 11851
	protected Text m_error;

	// Token: 0x04002E4C RID: 11852
	protected Text m_content;

	// Token: 0x04002E4D RID: 11853
	protected Text m_descript;

	// Token: 0x04002E4E RID: 11854
	protected Text m_character;

	// Token: 0x04002E4F RID: 11855
	protected InputField s_input;

	// Token: 0x04002E50 RID: 11856
	protected InputField m_input;

	// Token: 0x04002E51 RID: 11857
	protected UISpritesArray USArray;

	// Token: 0x04002E52 RID: 11858
	protected Transform Transformer;

	// Token: 0x04002E53 RID: 11859
	protected GameObject Tick;

	// Token: 0x04002E54 RID: 11860
	protected GameObject Invalid;

	// Token: 0x04002E55 RID: 11861
	protected float CheckTime;

	// Token: 0x04002E56 RID: 11862
	public Protocol Checking;

	// Token: 0x04002E57 RID: 11863
	public Protocol Sending;

	// Token: 0x04002E58 RID: 11864
	public byte Tagging;

	// Token: 0x04002E59 RID: 11865
	public int Typing;

	// Token: 0x04002E5A RID: 11866
	public int Length;

	// Token: 0x04002E5B RID: 11867
	public int Limits;

	// Token: 0x04002E5C RID: 11868
	public int Counts;

	// Token: 0x04002E5D RID: 11869
	public long ItemID;

	// Token: 0x04002E5E RID: 11870
	public DataManager DM = DataManager.Instance;

	// Token: 0x04002E5F RID: 11871
	public StringBuilder Hint = new StringBuilder();
}
