using System;
using System.Text;
using UnityEngine.UI;

// Token: 0x020002BE RID: 702
public class AllianceJoin : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06000E57 RID: 3671 RVA: 0x0017AE3C File Offset: 0x0017903C
	private void Start()
	{
	}

	// Token: 0x06000E58 RID: 3672 RVA: 0x0017AE40 File Offset: 0x00179040
	private void Update()
	{
	}

	// Token: 0x06000E59 RID: 3673 RVA: 0x0017AE44 File Offset: 0x00179044
	public override void OnOpen(int arg1, int arg2)
	{
		base.transform.GetChild(6).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(4).GetChild(1).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(4).GetChild(2).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(4).GetChild(3).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
		base.transform.GetChild(4).GetChild(8).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(4).GetChild(9).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(4).GetChild(10).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(4).GetChild(15).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
		this.m_IAllianceJoinText[0] = base.transform.GetChild(4).GetChild(15).GetChild(0).GetComponent<Text>();
		base.transform.GetChild(4).GetChild(17).GetChild(0).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
		this.m_IAllianceJoinText[1] = base.transform.GetChild(4).GetChild(17).GetChild(0).GetComponent<Text>();
		base.transform.GetChild(4).GetChild(22).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(4).GetChild(23).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(4).GetChild(24).GetComponent<UIButton>().m_Handler = this;
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
	}

	// Token: 0x06000E5A RID: 3674 RVA: 0x0017B040 File Offset: 0x00179240
	public override void OnClose()
	{
	}

	// Token: 0x06000E5B RID: 3675 RVA: 0x0017B044 File Offset: 0x00179244
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x06000E5C RID: 3676 RVA: 0x0017B070 File Offset: 0x00179270
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < 2; i++)
		{
			if (this.m_IAllianceJoinText[i] != null && this.m_IAllianceJoinText[i].enabled)
			{
				this.m_IAllianceJoinText[i].enabled = false;
				this.m_IAllianceJoinText[i].enabled = true;
			}
		}
	}

	// Token: 0x06000E5D RID: 3677 RVA: 0x0017B0D0 File Offset: 0x001792D0
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 4)
		{
			string text = new string('\0', 13);
			string data = "777";
			ushort data2 = 8;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_CREATE;
			messagePacket.AddSeqId();
			messagePacket.Add((byte)Encoding.UTF8.GetByteCount(text));
			messagePacket.Add(text, 20);
			messagePacket.Add(data, 3);
			messagePacket.Add(data2);
			messagePacket.Send(false);
		}
		else if (sender.m_BtnID1 == 9)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x04002E2B RID: 11819
	private Door door;

	// Token: 0x04002E2C RID: 11820
	protected Text[] m_IAllianceJoinText = new Text[2];
}
