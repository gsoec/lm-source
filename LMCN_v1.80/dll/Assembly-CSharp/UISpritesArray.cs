using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000883 RID: 2179
public class UISpritesArray : MonoBehaviour
{
	// Token: 0x06002D44 RID: 11588 RVA: 0x0048FB94 File Offset: 0x0048DD94
	public Sprite GetSprite(int index)
	{
		Sprite[] sprites;
		if (this.m_SourceSpritesArray != null)
		{
			sprites = this.m_SourceSpritesArray.m_Sprites;
		}
		else
		{
			sprites = this.m_Sprites;
		}
		if (sprites == null || index >= sprites.Length)
		{
			return null;
		}
		return sprites[index];
	}

	// Token: 0x06002D45 RID: 11589 RVA: 0x0048FBE0 File Offset: 0x0048DDE0
	public void SetSpriteIndex(int index)
	{
		Sprite sprite = this.GetSprite(index);
		if (sprite == null)
		{
			return;
		}
		this.m_Image.sprite = sprite;
		this.m_SpriteIndex = index;
	}

	// Token: 0x040079E6 RID: 31206
	public Sprite[] m_Sprites;

	// Token: 0x040079E7 RID: 31207
	public UISpritesArray m_SourceSpritesArray;

	// Token: 0x040079E8 RID: 31208
	public Image m_Image;

	// Token: 0x040079E9 RID: 31209
	public int m_SpriteIndex;
}
