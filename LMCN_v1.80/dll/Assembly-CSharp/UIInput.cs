using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200087C RID: 2172
public class UIInput : InputField, ISerializationCallbackReceiver
{
	// Token: 0x06002D18 RID: 11544 RVA: 0x0048E6A8 File Offset: 0x0048C8A8
	public UIInput()
	{
		base.onEndEdit.AddListener(delegate(string text)
		{
			this.OnEndInput(text);
		});
	}

	// Token: 0x06002D1A RID: 11546 RVA: 0x0048E6CC File Offset: 0x0048C8CC
	public void Destroy()
	{
		this.onAdjust = null;
		if (InputField.m_Keyboard != null)
		{
			InputField.m_Keyboard.active = false;
			InputField.m_Keyboard = null;
		}
	}

	// Token: 0x06002D1B RID: 11547 RVA: 0x0048E6FC File Offset: 0x0048C8FC
	protected void OnEndInput(string text)
	{
		if (this.onEndInput != null && this.KeyboardDone && !UIInput.KeyboardReturn)
		{
			this.onEndInput(text);
		}
		this.Close();
	}

	// Token: 0x06002D1C RID: 11548 RVA: 0x0048E73C File Offset: 0x0048C93C
	public void Close()
	{
		UIInput.KeyboardReturn = false;
		if (InputField.m_Keyboard != null)
		{
			InputField.m_Keyboard.active = false;
		}
	}

	// Token: 0x06002D1D RID: 11549 RVA: 0x0048E75C File Offset: 0x0048C95C
	public void Open()
	{
		base.ActivateInputField();
		this.HideMobileInput = true;
	}

	// Token: 0x06002D1E RID: 11550 RVA: 0x0048E76C File Offset: 0x0048C96C
	public void OnBeforeSerialize()
	{
	}

	// Token: 0x06002D1F RID: 11551 RVA: 0x0048E770 File Offset: 0x0048C970
	public void OnAfterDeserialize()
	{
		base.shouldHideMobileInput = false;
	}

	// Token: 0x06002D20 RID: 11552 RVA: 0x0048E77C File Offset: 0x0048C97C
	protected override void LateUpdate()
	{
		if (this.HideMobileInput && this.shouldHideMobileInput)
		{
			base.shouldHideMobileInput = true;
		}
		base.LateUpdate();
		if (this.HideMobileInput || (double)NetworkManager.SynchTime >= 0.5)
		{
			if (this.HideMobileInput)
			{
				base.shouldHideMobileInput = (this.HideMobileInput = false);
			}
			if (TouchScreenKeyboard.visible && this.onAdjust != null)
			{
				using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				{
					using (AndroidJavaObject androidJavaObject = new AndroidJavaObject("android.graphics.Rect", new object[0]))
					{
						androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer").Call<AndroidJavaObject>("getView", new object[0]).Call("getWindowVisibleDisplayFrame", new object[]
						{
							androidJavaObject
						});
						this.onAdjust(Screen.height - androidJavaObject.Call<int>("height", new object[0]));
					}
				}
			}
		}
	}

	// Token: 0x06002D21 RID: 11553 RVA: 0x0048E8CC File Offset: 0x0048CACC
	public override void OnSubmit(BaseEventData eventData)
	{
		if (this.IsActive() && this.IsInteractable() && !base.isFocused)
		{
			this.HideMobileInput = true;
			base.OnSubmit(eventData);
		}
	}

	// Token: 0x06002D22 RID: 11554 RVA: 0x0048E908 File Offset: 0x0048CB08
	public override void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Left)
		{
			return;
		}
		base.ActivateInputField();
		this.HideMobileInput = true;
	}

	// Token: 0x06002D23 RID: 11555 RVA: 0x0048E924 File Offset: 0x0048CB24
	public override void OnSelect(BaseEventData eventData)
	{
		base.OnSelect(eventData);
		base.ActivateInputField();
		this.HideMobileInput = true;
	}

	// Token: 0x06002D24 RID: 11556 RVA: 0x0048E93C File Offset: 0x0048CB3C
	public override void OnDeselect(BaseEventData eventData)
	{
		if (InputField.m_Keyboard != null)
		{
			this.KeyboardDone = InputField.m_Keyboard.done;
		}
		base.DeactivateInputField();
		base.OnDeselect(eventData);
		if (this.onAdjust != null)
		{
			this.onAdjust(0);
		}
	}

	// Token: 0x06002D25 RID: 11557 RVA: 0x0048E988 File Offset: 0x0048CB88
	public static bool IsOpen()
	{
		UIInput.KeyboardReturn = true;
		return InputField.m_Keyboard != null;
	}

	// Token: 0x040079B0 RID: 31152
	protected bool HideMobileInput;

	// Token: 0x040079B1 RID: 31153
	protected bool KeyboardDone;

	// Token: 0x040079B2 RID: 31154
	private static bool KeyboardReturn;

	// Token: 0x040079B3 RID: 31155
	public new bool shouldHideMobileInput;

	// Token: 0x040079B4 RID: 31156
	public UIInput.AdjustHeight onAdjust;

	// Token: 0x040079B5 RID: 31157
	public UIInput.EndEdit onEndInput;

	// Token: 0x0200089A RID: 2202
	// (Invoke) Token: 0x06002DB0 RID: 11696
	public delegate void AdjustHeight(int height);

	// Token: 0x0200089B RID: 2203
	// (Invoke) Token: 0x06002DB4 RID: 11700
	public delegate void EndEdit(string text);
}
