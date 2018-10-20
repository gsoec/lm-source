using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000291 RID: 657
public class ChatChannel
{
	// Token: 0x04002944 RID: 10564
	public RectTransform MainRC;

	// Token: 0x04002945 RID: 10565
	public UIButton m_Button;

	// Token: 0x04002946 RID: 10566
	public UIText[] m_ChatText = new UIText[2];

	// Token: 0x04002947 RID: 10567
	public RectTransform[] m_ChatTextRC = new RectTransform[2];

	// Token: 0x04002948 RID: 10568
	public RectTransform[] m_ChatEmojiRC = new RectTransform[2];

	// Token: 0x04002949 RID: 10569
	public EmojiUnit[] EUnit = new EmojiUnit[2];
}
